using com.xebio.bo.Tj160p01.Constant;
using com.xebio.bo.Tj160p01.Formvo;
using com.xebio.bo.Tj160p01.VO;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

namespace com.xebio.bo.Tj160p01.Facade
{
  /// <summary>
  /// Tj160f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj160f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnsearch)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsearch)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEARCH_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj160f01Form f01VO = (Tj160f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");


				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				// 店舗MSTを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連チェック
				// 2-1 フェイスＮｏFROM、フェイスＮｏTO
				// フェイスＮｏFROM > フェイスＮｏTOの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Face_no_from) && !string.IsNullOrEmpty(f01VO.Face_no_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Face_no_from,
									f01VO.Face_no_to,
									facadeContext,
									"フェイスNo",
									new[] { "Face_no_from", "Face_no_to" }
									);
				}

				// 2-2 入力日FROM、入力日TO
				// 入力日ＦＲＯＭ > 入力日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_from) && !string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Nyuryoku_ymd_from,
									f01VO.Nyuryoku_ymd_to,
									facadeContext,
									"入力日",
									new[] { "Nyuryoku_ymd_from", "Nyuryoku_ymd_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 件数チェック

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 棚卸実施日TBLより棚卸基準日を取得
				Hashtable hashTable = new Hashtable();

				int iErrF = 0;
				hashTable = SearchInventory.SearchMdit0030(f01VO.Head_tenpo_cd, sysDateVO.Sysdate.ToString(), facadeContext, iErrF);
				String tanaorosikijun_Ymd = "-1";

				if (hashTable != null)
				{
					tanaorosikijun_Ymd = hashTable["TANAOROSIKIJUN_YMD"].ToString();
				}

				// 検索
				ArrayList rtChk = doSelectDataBase(f01VO, tanaorosikijun_Ymd, Tj160p01Constant.ORACLE_PACKAGE_01_COUNT, facadeContext);

				// カーソル取得
				ArrayList rtChkList = (ArrayList)rtChk[1];
				Hashtable htChkList = (Hashtable)rtChkList[0];
				//BoSystemLog.logOut("検索結果 カウント:" + htChkList["COUNT(1)"].ToString());

				// 0件チェック
				if ((Decimal)htChkList["COUNT(1)"] == 0)
				{
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					// 最大件数チェック
					V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), (Decimal)htChkList["COUNT(1)"], facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 検索処理

				// 検索
				ArrayList rtSeach = doSelectDataBase(f01VO, tanaorosikijun_Ymd, Tj160p01Constant.ORACLE_PACKAGE_01, facadeContext);

				// カーソル取得
				ArrayList rtSeachList = (ArrayList)rtSeach[1];

				#endregion

				#region 検索結果編集

				//データ編集用の箱
				ArrayList formatDataList = new ArrayList(); 

				// 編集用の箱に詰める
				foreach (Hashtable rec in rtSeachList)
				{
					Tj160M1ModelVO　f01m1VO2 = new Tj160M1ModelVO();
					f01m1VO2.tenpo_cd = rec["TENCD"].ToString();
					f01m1VO2.tenpo_nm = rec["TENPO_NM"].ToString();
					f01m1VO2.face_no = rec["FACE_NO"].ToString();
					f01m1VO2.tana_dan = rec["TANA_DAN"].ToString();
					f01m1VO2.tyohuku = rec["JUFUKU"].ToString();
					f01m1VO2.upd_tancd = rec["UPD_TANCD"].ToString();
					f01m1VO2.hanbaiin_nm = rec["HANBAIIN_NM"].ToString();
					f01m1VO2.data_flg = rec["DATA_FLG"].ToString();
					formatDataList.Add(f01m1VO2);	
		            // ログ出力
                    BoSystemLog.logOut("検索結果編集　店舗コード:" + f01m1VO2.tenpo_cd);
                    BoSystemLog.logOut("検索結果編集　店舗名:" + f01m1VO2.tenpo_nm);
                    BoSystemLog.logOut("検索結果編集　フェイスNO:" + f01m1VO2.face_no);
                    BoSystemLog.logOut("検索結果編集　棚段:" + f01m1VO2.tana_dan);
                    BoSystemLog.logOut("検索結果編集　重複:" + f01m1VO2.tyohuku);
                    BoSystemLog.logOut("検索結果編集　担当者コード:" + f01m1VO2.upd_tancd);
                    BoSystemLog.logOut("検索結果編集　担当者名:" + f01m1VO2.hanbaiin_nm);
                    BoSystemLog.logOut("検索結果編集　データフラグ:" + f01m1VO2.data_flg);


                }

				ArrayList formatData = new ArrayList(); 

				//データの調整
				formatData = doFormatCheckListStream(formatDataList, f01VO);

				// 重複の条件により0件になってしまったら対象データなしとする
				if (formatData.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				//連続データの編集
				formatData = doFormatCheckListrenzoku(formatData, f01VO);

				// 重複なしの場合、重複データを削る
				if (ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu))
				{
					//連続データの編集
					formatData = doFormatJuhukuDelete(formatData, f01VO);
					// 重複の条件により0件になってしまったら対象データなしとする
					if (formatData.Count <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

				}

				//出力用にデータを削る
				formatData = doFormatCheckListRemove(formatData,f01VO);

				//同一フェイスNoは一度しか表示しないように編集
				formatData = doFormatCheckListFace(formatData, f01VO);

				#endregion

				#region 画面項目設定

				int iCnt = 0;
				foreach (Tj160M1ModelVO rec in formatData)
				{

					iCnt++;
					Tj160f01M1Form f01m1VO = new Tj160f01M1Form();
					f01m1VO.M1rowno = iCnt.ToString();						// Ｍ１行NO
					f01m1VO.M1face_no = formatFaceNo(rec.face_no);			// Ｍ１フェイス№
					f01m1VO.M1tana_dan = BoSystemString.ZeroToEmpty(rec.tana_dan);
																			// Ｍ１棚段
					f01m1VO.M1tyohuku = formatTyohuku(rec.tyohuku);			// Ｍ１重複
					f01m1VO.M1tantosya_cd = BoSystemString.ZeroToEmpty(rec.upd_tancd);
																			// Ｍ１担当者コード
					f01m1VO.M1hanbaiin_nm = rec.hanbaiin_nm;				// Ｍ１担当者名
					f01m1VO.M1checklist_memo = rec.memo;					// Ｍ１メモ
					f01m1VO.M1selectorcheckbox = "0";						// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = "0";							// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = "0";								// Ｍ１明細色区分(隠し)

					////リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);			

				}
				f01VO.Searchcnt = m1List.Count.ToString();

				#endregion

				#region 検索条件をDictionaryに設定

				// 検索時のformVOを保持
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion

		#region ユーザー定義関数

		#region 検索処理

		/// <summary>
		/// 検索処理
		/// </summary>
		/// <param name="IfacadeContext">facadeContext</param>
		/// <param name="Tj160f01Form">f01VO</param>
		/// <param name="String">tanaorosikijun_Ymd</param>
		/// <param name="String">packageId</param>
		/// <returns>結果</returns>
		public ArrayList doSelectDataBase(Tj160f01Form f01VO, String tanaorosikijun_Ymd, String packageId, IFacadeContext facadeContext)
		{
			// ストアド呼び出し
			// 棚卸取漏れ/欠番検索(カウント用)（取漏れ欠番処理）
			// ■パラメータ設定
			ArrayList paramList = new ArrayList();

			// 店舗コード
			StoredProcedureCls.SetStoredParam(ref paramList, "v_tencd", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// フェイスNoFrom
			StoredProcedureCls.SetStoredParam(ref paramList, "v_faceno_from", OracleDbType.Decimal, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(f01VO.Face_no_from, "-1")));
			// フェイスNoTo
			StoredProcedureCls.SetStoredParam(ref paramList, "v_faceno_to", OracleDbType.Decimal, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(f01VO.Face_no_to, "-1")));
			// 入力日From
			StoredProcedureCls.SetStoredParam(ref paramList, "v_addymd_from", OracleDbType.Decimal, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_from),"-1")));
			// 入力日To
			StoredProcedureCls.SetStoredParam(ref paramList, "v_addymd_to", OracleDbType.Decimal, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_to), "-1")));
			// 棚卸日
			StoredProcedureCls.SetStoredParam(ref paramList, "v_tanaorosikijun_ymd", OracleDbType.Decimal, ParameterDirection.Input,
                Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(tanaorosikijun_Ymd), "-1")));

            // ログ出力
            BoSystemLog.logOut("[" + packageId + "] v_tencd:" + BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
            BoSystemLog.logOut("[" + packageId + "] v_faceno_from:" + Convert.ToDecimal(BoSystemString.Nvl(f01VO.Face_no_from, "-1")).ToString());
            BoSystemLog.logOut("[" + packageId + "] v_faceno_to:" + Convert.ToDecimal(BoSystemString.Nvl(f01VO.Face_no_to, "-1")).ToString());
            BoSystemLog.logOut("[" + packageId + "] v_addymd_from:" + Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_from), "-1")).ToString());
            BoSystemLog.logOut("[" + packageId + "] v_addymd_to:" + Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_to), "-1")).ToString());
            BoSystemLog.logOut("[" + packageId + "] v_tanaorosikijun_ymd:" + Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(tanaorosikijun_Ymd), "-1")).ToString());


			// 処理呼び出し
			ArrayList rt = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, packageId, paramList);

			#region ■例外処理
			if (rt != null && rt.Count > 0)
			{
				// エラーコード
				string errCd = rt[0].ToString();

				if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
				{
					// 正常終了
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［" + packageId + "］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［" + packageId + "］実行時にエラーが発生しました。");
			}
			#endregion

			return rt;
		}

		#endregion

		#region チェックリストのデータに対して取漏れデータを編集、検索条件に一致しないデータを除外
		/// <summary>
		/// チェックリストのデータに対して取漏れデータを編集し、検索条件に一致しないデータを除外します。
		/// </summary>
		/// <param name="ArrayList">InData</param>
		/// <param name="Tj160f01Form">f01VO</param>
		/// <returns name="ArrayList">OutData</returns>
		private ArrayList doFormatCheckListStream(ArrayList inData, Tj160f01Form f01VO)
		{
			ArrayList outData = new ArrayList();

			//対象データ追加フラグ
			Boolean insert_flg = false;

			//①取漏れデータのフェイスNo,棚段をXX編集する
			//先頭から最後までループ
			for (int i = 0; i < inData.Count; i++)
			{

				//現在行取得
				Tj160M1ModelVO dataRow = (Tj160M1ModelVO)inData[i];
				//フラグ初期化
				insert_flg = false;

				// 検索条件「重複有無」によりデータの削除を行う
				// 重複有りの場合、重複データのみを設定する
				if ((ConditionUmu.VALUE_ARI.Equals(f01VO.Tyohuku_umu)))
				{
					if (int.Parse(BoSystemString.Nvl(dataRow.tyohuku,"0")) <= 1)
					{
						insert_flg = true;
					}
				}

				// 取漏れの場合
				if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(dataRow.data_flg))
				{
					//フェイスNo単位で取漏れしているもの
					if (("0").Equals(dataRow.tana_dan))
					{
						//フェイスNoをXXXXXに置き換え
						dataRow.face_no = Tj160p01Constant.DISP_PTN_NUKEBAN_5;	//フェイスNo
						//フェイスNo以外の他項目を全てSPACEに置き換える
						dataRow.tana_dan = "";		//棚段
						dataRow.tyohuku = "";		//重複回数
						dataRow.upd_tancd = "";		//担当者コード
						dataRow.hanbaiin_nm = "";	//担当者名
						dataRow.memo = "";			//メモ
					}
					else if (("1").Equals(dataRow.tana_dan))
					{
						//フェイスNo、棚段以外の項目をすべてSPACEに置き換える
						dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;	//棚段
						dataRow.tyohuku = "";		//重複回数
						dataRow.upd_tancd = "";		//担当者コード
						dataRow.hanbaiin_nm = "";	//担当者名
						dataRow.memo = "";			//メモ
					}
					else
					{
						//棚段以外の項目をすべてSPACEに置き換える
						dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;		//棚段
						dataRow.face_no = "";			//フェイスNo
						dataRow.tyohuku = "";			//重複回数
						dataRow.upd_tancd = "";			//担当者コード
						dataRow.hanbaiin_nm = "";		//担当者名
						dataRow.memo = "";				//メモ
					}
				}

				//欠番のレコードのメモに「※欠番有り」を設定する
				//データフラグ,0:正常,1:欠番,2:重複,3:取漏れ
				if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(dataRow.data_flg))
				{
					//メモを"※欠番あり"に置き換え
					dataRow.memo = Tj160p01Constant.DISP_PTN_KETUBAN;
				}

				//フラグがfalseの場合、データを追加する
				if (insert_flg == false)
				{
					//行追加
					outData.Add(dataRow);
				}
			}

			return outData;
		}

		#endregion

		#region チェックリストのデータで連続しているデータを置き換える
		/// <summary>
		/// チェックリストのデータで連続しているデータを置き換える
		/// </summary>
		/// <param name="ArrayList">InData</param>
		/// <param name="Tj160f01Form">f01VO</param>
		/// <returns name="ArrayList">OutData</returns>
		private ArrayList doFormatCheckListrenzoku(ArrayList inData, Tj160f01Form f01VO)
		{
			ArrayList outData = new ArrayList();

			//----------------------------------------------------------
			//1行目の処理(1行目は必ず設定する)
			Tj160M1ModelVO dataRow = (Tj160M1ModelVO)inData[0];
			//行追加
			outData.Add(dataRow);
			//----------------------------------------------------------

			//２行目からから最後-1までループ
			for (int i = 1; i < inData.Count - 1; i++)
			{

				//1行前取得
				Tj160M1ModelVO before_dataRow = (Tj160M1ModelVO) inData[i - 1];
				//現在行取得
				Tj160M1ModelVO now_dataRow = (Tj160M1ModelVO) inData[i];
				//1行先取得
				Tj160M1ModelVO after_dataRow = (Tj160M1ModelVO) inData[i + 1];

				//ﾊﾟﾀｰﾝ27,39,43,59用ワーク
				Tj160M1ModelVO wk_dataRow;
				//43用ワーク
				Tj160M1ModelVO wk2_dataRow;

				//1行前、1行先のデータ種別により、編集を行う。
				//左（1行前）--右(1行後)
				#region 登録--登録(ﾊﾟﾀｰﾝ1~4)
				if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_SEIJOU.Equals(after_dataRow.data_flg))
				{

					//現在行が正常(ﾊﾟﾀｰﾝ1)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段 編集
						now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;			//フェイスNo
						now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;				//棚段
						//他項目クリア
						now_dataRow.tyohuku = "";				//重複回数
						now_dataRow.upd_tancd = "";				//担当者コード
						now_dataRow.hanbaiin_nm = "";			//担当者名
						now_dataRow.memo = "";					//メモ
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ2)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ3)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段編集
						now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;			//フェイスNo
						now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;				//棚段
						//メモ無編集(既に※欠番ありになっている)
						//now_dataRow.setDetailMemo("");		//メモ
						//他項目クリア
						now_dataRow.tyohuku = "";				//重複回数
						now_dataRow.upd_tancd = "";				//担当者コード
						now_dataRow.hanbaiin_nm = "";			//担当者名
					}

					//現在行が重複(ﾊﾟﾀｰﾝ4)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}
				#endregion

				//左（1行前）--右(1行後)
				#region 登録--取漏れ(ﾊﾟﾀｰﾝ5~8)
				if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_TORIMORE.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ5)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//編集なし
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ6)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ7)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段,メモ無編集(既に※欠番ありになっている)
						//他項目クリア
						now_dataRow.tyohuku = "";				//重複回数
						now_dataRow.upd_tancd = "";				//担当者コード
						now_dataRow.hanbaiin_nm = "";			//担当者名
					}

					//現在行が重複(ﾊﾟﾀｰﾝ8)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}
				#endregion

				//左（1行前）--右(1行後)
				#region 登録--欠番(ﾊﾟﾀｰﾝ9~12)
				if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_KETUBAN.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ9)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段 編集
						now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;	//フェイスNo
						now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;		//棚段
						//他項目クリア
						now_dataRow.tyohuku	= "";		//重複回数
						now_dataRow.upd_tancd = "";		//担当者コード
						now_dataRow.hanbaiin_nm = "";	//担当者名
						now_dataRow.memo  = "";			//メモ
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ10)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ11)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段 編集
						now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;	//フェイスNo
						now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;		//棚段
						//メモは無編集
						//他項目クリア
						now_dataRow.tyohuku = "";		//重複回数
						now_dataRow.upd_tancd ="";		//担当者コード
						now_dataRow. hanbaiin_nm = "";	//担当者名
					}

					//現在行が重複(ﾊﾟﾀｰﾝ12)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}
				#endregion

				//左（1行前）--右(1行後)
				#region 登録--重複(ﾊﾟﾀｰﾝ13~16)
				if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(after_dataRow.data_flg))
				{

					//現在行が正常(ﾊﾟﾀｰﾝ13)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;			//フェイスNo
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;				//棚段
							//他項目クリア
							now_dataRow.tyohuku = "";				//重複回数
							now_dataRow.upd_tancd = "";				//担当者コード
							now_dataRow.hanbaiin_nm = "";			//担当者名
							now_dataRow.memo = "";					//メモ
						}
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ14)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ15)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;		//フェイスNo
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;			//棚段
							//他項目クリア
							now_dataRow.tyohuku = "";			//重複回数
							now_dataRow.upd_tancd = "";			//担当者コード
							now_dataRow.hanbaiin_nm = "";		//担当者名
						}
					}

					//現在行が重複(ﾊﾟﾀｰﾝ16)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}

				}
				#endregion

				//左（1行前）--右(1行後)
				#region 取漏れ--登録(ﾊﾟﾀｰﾝ17~20)
				if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_SEIJOU.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ17)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//無編集
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ18)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ19)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}

					//現在行が重複(ﾊﾟﾀｰﾝ16)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}
				#endregion

				//左（1行前）--右(1行後)
				#region 取漏れ--取漏れ(ﾊﾟﾀｰﾝ21~24)
				if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_TORIMORE.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ21)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//無編集
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ22)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ23)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						if (("0").Equals(now_dataRow.tana_dan))
						{
							//フェイスNo編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_NUKEBAN_5;			//フェイスNo
							//他項目クリア
							now_dataRow.tana_dan = "";				//棚段

						}
						else if (("1").Equals(now_dataRow.tana_dan))
						{
							//棚段編集
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;			//棚段
						}
						else
						{
							//棚段編集
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;			//棚段
							//他項目クリア
							now_dataRow.face_no = "";				//フェイスNo
						}
						//共通でクリアする項目
						now_dataRow.tyohuku = "";					//重複回数
						now_dataRow.upd_tancd = "";					//担当者コード
						now_dataRow.hanbaiin_nm = "";				//担当者名
					}

					//現在行が重複(ﾊﾟﾀｰﾝ24)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}

				}
				#endregion

				//左（1行前）--右(1行後)
				#region 取漏れ--欠番(ﾊﾟﾀｰﾝ25~28)
				if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_KETUBAN.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ25)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//無編集
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ26)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ27)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{

						//自分より先の行を検索し、正常、重複、欠番の場合は無編集。取漏れはXXXXにする。最終行は|にする
						for (int ix = i + 1; ix < inData.Count - 1; ix++)
						{
							//自分から最終行-1行までのワーク
							wk_dataRow = (Tj160M1ModelVO) inData[ix];
							if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(wk_dataRow.data_flg) || Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(wk_dataRow.data_flg))
							{
								// 無編集
								break;
							}
							else if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(wk_dataRow.data_flg))
							{
								//フェイスNo編集
								now_dataRow.face_no = Tj160p01Constant.DISP_PTN_NUKEBAN_5;			//フェイスNo
								//他項目クリア
								now_dataRow.tana_dan = "";				//棚段
								now_dataRow.tyohuku = "";				//重複回数
								now_dataRow.upd_tancd = "";				//担当者コード
								now_dataRow.hanbaiin_nm = "";			//担当者名
								break;
							}
						}
					}

					//現在行が重複(ﾊﾟﾀｰﾝ28)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}
				#endregion

				//左（1行前）--右(1行後)
				#region 取漏れ--重複(ﾊﾟﾀｰﾝ29~32)
				if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ29)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//無編集
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ30)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ31)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						if (("0").Equals(now_dataRow.tana_dan))
						{
							//フェイスNo編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_NUKEBAN_5;			//フェイスNo
							//他項目クリア
							now_dataRow.tana_dan = "";				//棚段
						}
						else if (("1").Equals(now_dataRow.tana_dan))
						{
							//棚段編集
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;			//棚段
						}
						else
						{
							//棚段編集
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;			//棚段
							//他項目クリア
							now_dataRow.face_no = "";				//フェイスNo
						}
						//共通でクリアする項目
						now_dataRow.tyohuku = "";					//重複回数
						now_dataRow.upd_tancd = "";					//担当者コード
						now_dataRow.hanbaiin_nm = "";				//担当者名
					}

					//現在行が重複(ﾊﾟﾀｰﾝ32)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}

				}
				#endregion

				//左（1行前）--右(1行後)
				#region 欠番--登録(ﾊﾟﾀｰﾝ33~36)
				if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_SEIJOU.Equals(after_dataRow.data_flg))
				{

					//現在行が正常(ﾊﾟﾀｰﾝ33)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段 編集
						now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
						now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
						//他項目クリア
						now_dataRow.tyohuku = "";		//重複回数
						now_dataRow.upd_tancd = "";		//担当者コード
						now_dataRow.hanbaiin_nm = "";	//担当者名
						now_dataRow.memo = "";			//メモ
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ34)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ35)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段 編集
						now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
						now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
						now_dataRow.tyohuku = "";					//重複回数
						now_dataRow.upd_tancd = "";					//担当者コード
						now_dataRow.hanbaiin_nm = "";				//担当者名
					}

					//現在行が重複(ﾊﾟﾀｰﾝ36)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}

				#endregion

				//左（1行前）--右(1行後)
				#region 欠番--取漏れ(ﾊﾟﾀｰﾝ37~40)
				if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_TORIMORE.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ37)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ38)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ39)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//自分より前の行を検索し、正常、重複の場合は無編集。取漏れはXXXXにする。
						for (int ix=i-1;ix > 0; ix--)
						{
							//自分から2行までのワーク
							wk_dataRow = (Tj160M1ModelVO)inData[ix];
							if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(wk_dataRow.data_flg) || Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(wk_dataRow.data_flg))
							{
								//無編集
								break;
							}
							else if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(wk_dataRow.data_flg))
							{

								if (("0").Equals(now_dataRow.tana_dan))
								{
									//フェイスNo編集
									now_dataRow.face_no = Tj160p01Constant.DISP_PTN_NUKEBAN_5;
									//他項目クリア
									now_dataRow.tana_dan = "";				//棚段
								}
								else if (("1").Equals(now_dataRow.tana_dan))
								{
									//棚段編集
									now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;			//棚段
								}
								else
								{
									//棚段編集
									now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;			//棚段
									//他項目クリア
									now_dataRow.face_no = "";
								}

								now_dataRow.tyohuku = "";					//重複回数
								now_dataRow.upd_tancd = "";					//担当者コード
								now_dataRow.hanbaiin_nm = "";				//担当者名
								break;
							}
						}
					}

					//現在行が重複(ﾊﾟﾀｰﾝ40)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}
				#endregion

				//左（1行前）--右(1行後)
				#region 欠番--欠番(ﾊﾟﾀｰﾝ41~44)
				if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_KETUBAN.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ41)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段 編集
						now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
						now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
						//他項目クリア
						now_dataRow.tyohuku = "";		//重複回数
						now_dataRow.upd_tancd = "";		//担当者コード
						now_dataRow.hanbaiin_nm = "";	//担当者名
						now_dataRow.memo = "";			//メモ
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ42)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ43)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//編集用フラグ（ﾊﾟﾀｰﾝ43のみで使用）
						Boolean flg_mae = false;
						Boolean flg_ato = false;

						//自分より先の行に欠番以外で何があるか検索
						for (int ix = i; ix < inData.Count - 1; ix++)
						{
							wk_dataRow = (Tj160M1ModelVO)inData[ix];

							//通常、重複が見つかった場合、フラグを更新しないでループ抜け
							if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(wk_dataRow.data_flg) || Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(wk_dataRow.data_flg))
							{
								break;
							}
							//取漏れが見つかった場合、フラグを更新してループ抜け
							if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(wk_dataRow.data_flg))
							{
								flg_ato = true;
								break;
							}
						}

						//自分より前の行に取漏れがあるかどうかの判断を行う
						for (int ix=i-1;ix > 0; ix--)
						{
							wk2_dataRow = (Tj160M1ModelVO)inData[ix];

							//通常、重複が見つかった場合、フラグを更新しないでループ抜け
							if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(wk2_dataRow.data_flg) || Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(wk2_dataRow.data_flg))
							{
								break;
							}

							//取漏れが見つかった場合、フラグを更新してループ抜け
							if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(wk2_dataRow.data_flg))
							{
								flg_ato = true;
								break;
							}
						}

						//前後が取漏れの場合XXXXXに編集
						if (flg_mae == true && flg_ato == true)
						{
							if (("0").Equals(now_dataRow.tana_dan))
							{
								//フェイスNo編集
								now_dataRow.face_no = Tj160p01Constant.DISP_PTN_NUKEBAN_5;
								//他項目クリア
								now_dataRow.tana_dan = "";			//棚段
							}
							else if (("1").Equals(now_dataRow.tana_dan))
							{

								//棚段編集
								now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;		//棚段
							}
							else
							{
								//棚段編集
								now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_NUKEBAN_2;		//棚段
								//他項目クリア
								now_dataRow.face_no = "";
							}

							//共通でクリアする項目
							now_dataRow.tyohuku = "";				//重複回数
							now_dataRow.upd_tancd = "";				//担当者コード
							now_dataRow.hanbaiin_nm = "";			//担当者名

						}
						else
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
							//他項目クリア
							now_dataRow.tyohuku = "";			//重複回数
							now_dataRow.upd_tancd = "";			//担当者コード
							now_dataRow.hanbaiin_nm = "";		//担当者名
						}
					}

					//現在行が重複(ﾊﾟﾀｰﾝ44)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}

				}

				#endregion

				//左（1行前）--右(1行後)
				#region 欠番--重複(ﾊﾟﾀｰﾝ45~48)
				if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(after_dataRow.data_flg))
				{

					//現在行が正常(ﾊﾟﾀｰﾝ45)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
							//他項目クリア
							now_dataRow.tyohuku = "";		//重複回数
							now_dataRow.upd_tancd = "";		//担当者コード
							now_dataRow.hanbaiin_nm = "";	//担当者名
							now_dataRow.memo = "";			//メモ
						}
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ46)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ47)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
							//他項目クリア
							now_dataRow.tyohuku = "";				//重複回数
							now_dataRow.upd_tancd = "";				//担当者コード
							now_dataRow.hanbaiin_nm ="";			//担当者名
						}
					}

					//現在行が重複(ﾊﾟﾀｰﾝ48)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}
				#endregion

				//左（1行前）--右(1行後)
				#region 重複--登録(ﾊﾟﾀｰﾝ49~52)
				if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_SEIJOU.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ49)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
							//他項目クリア
							now_dataRow.tyohuku = "";		//重複回数
							now_dataRow.upd_tancd = "";		//担当者コード
							now_dataRow.hanbaiin_nm = "";	//担当者名
							now_dataRow.memo = "";			//メモ
						}
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ50)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ51)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
							//他項目クリア
							now_dataRow.tyohuku = "";				//重複回数
							now_dataRow.upd_tancd = "";				//担当者コード
							now_dataRow.hanbaiin_nm = "";			//担当者名
						}
					}

					//現在行が重複(ﾊﾟﾀｰﾝ52)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}
				#endregion

				//左（1行前）--右(1行後)
				#region 重複--取漏れ(ﾊﾟﾀｰﾝ53~56)
				if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_TORIMORE.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ53)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						//編集なし
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ54)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ55)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}

					//現在行が重複(ﾊﾟﾀｰﾝ56)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}

				}
				#endregion

				//左（1行前）--右(1行後)
				#region 重複--欠番(ﾊﾟﾀｰﾝ57~60)
				if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_KETUBAN.Equals(after_dataRow.data_flg))
				{

					//現在行が正常(ﾊﾟﾀｰﾝ57)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
							//他項目クリア
							now_dataRow.tyohuku = "";		//重複回数
							now_dataRow.upd_tancd = "";		//担当者コード
							now_dataRow.hanbaiin_nm = "";	//担当者名
							now_dataRow.memo = "";			//メモ
						}
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ58)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ59)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
							//他項目クリア
							now_dataRow.tyohuku = "";				//重複回数
							now_dataRow.upd_tancd = "";				//担当者コード
							now_dataRow.hanbaiin_nm = "";			//担当者名
						}
					}

					//現在行が重複(ﾊﾟﾀｰﾝ56)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}

				#endregion

				//左（1行前）--右(1行後)
				#region 重複--重複(ﾊﾟﾀｰﾝ61~64)
				if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(before_dataRow.data_flg) && Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(after_dataRow.data_flg))
				{
					//現在行が正常(ﾊﾟﾀｰﾝ61)
					if (Tj160p01Constant.DATA_FLG_SEIJOU.Equals(now_dataRow.data_flg))
					{
						// 重複なし以外の場合
						if (!(ConditionUmu.VALUE_NASI.Equals(f01VO.Tyohuku_umu)))
						{
							//フェイスNo,棚段 編集
							now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
							now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
							//他項目クリア
							now_dataRow.tyohuku = "";		//重複回数
							now_dataRow.upd_tancd = "";		//担当者コード
							now_dataRow.hanbaiin_nm = "";	//担当者名
							now_dataRow.memo = "";			//メモ
						}
					}

					//現在行が取漏れ(ﾊﾟﾀｰﾝ62)
					if (Tj160p01Constant.DATA_FLG_TORIMORE.Equals(now_dataRow.data_flg))
					{
						//取漏れ時の編集はdoFormatCheckListStreamで行っているので無編集
					}

					//現在行が欠番(ﾊﾟﾀｰﾝ62)
					if (Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
					{
						//フェイスNo,棚段 編集
						now_dataRow.face_no = Tj160p01Constant.DISP_PTN_RENBAN_5;
						now_dataRow.tana_dan = Tj160p01Constant.DISP_PTN_RENBAN_2;
						//他項目クリア
						now_dataRow.tyohuku = "";				//重複回数
						now_dataRow.upd_tancd = "";				//担当者コード
						now_dataRow.hanbaiin_nm = "";			//担当者名
					}

					//現在行が重複(ﾊﾟﾀｰﾝ64)
					if (Tj160p01Constant.DATA_FLG_TYOHUKU.Equals(now_dataRow.data_flg))
					{
						//全て編集なし
					}
				}

				#endregion

				outData.Add(now_dataRow);

			}

			//----------------------------------------------------------
			//最終行目の処理(最終行目は必ず設定する)
			//2件以上ある場合処理
			if (inData.Count > 1)
			{
				dataRow = (Tj160M1ModelVO)inData[inData.Count - 1];
				//行追加
				outData.Add(dataRow);
			}

			return outData;
		}
		#endregion

		#region 重複ありデータを除外する
		/// <summary>
		/// 重複ありデータを除外する
		/// </summary>
		/// <param name="ArrayList">InData</param>
		/// <param name="Tj160f01Form">f01VO</param>
		/// <returns name="ArrayList">OutData</returns>
		private ArrayList doFormatJuhukuDelete(ArrayList inData, Tj160f01Form f01VO)
		{
			ArrayList outData = new ArrayList();

			//先頭から最後までループ
			for (int i = 0; i < inData.Count; i++)
			{
				//現在行取得
				Tj160M1ModelVO dataRow = (Tj160M1ModelVO)inData[i];

				// 重複なしのデータのみ追加
				if (int.Parse(BoSystemString.Nvl(dataRow.tyohuku, "0")) <= 1)
				{
					outData.Add(dataRow);
				}
			}
			return outData;
		}

		#endregion

		#region チェックリストのデータに対して出力用にデータを削る
		/// <summary>
		/// チェックリストのデータに対して出力用にデータを削る
		/// </summary>
		/// <param name="ArrayList">InData</param>
		/// <param name="Tj160f01Form">f01VO</param>
		/// <returns name="ArrayList">OutData</returns>
		private ArrayList doFormatCheckListRemove(ArrayList inData, Tj160f01Form f01VO)
		{
			ArrayList outData = new ArrayList();

			//行追加するフラグ
			Boolean remove_flg = false;

			//----------------------------------------------------------
			//1行目の処理(1行目は必ず設定する)	
			Tj160M1ModelVO dataRow = (Tj160M1ModelVO)inData[0];
			//行追加
			outData.Add(dataRow);
			//----------------------------------------------------------

			//先頭から最後までループ
			for (int i = 1; i < inData.Count - 1; i++)
			{
				//行追加するフラグ初期化
				remove_flg = false;

				//1行前取得
				Tj160M1ModelVO before_dataRow = (Tj160M1ModelVO)inData[i - 1];
				//現在行取得
				Tj160M1ModelVO now_dataRow = (Tj160M1ModelVO)inData[i];

				//1行前のフェイスNoが|かつ現在行のフェイスNoが|の場合、現在行不要
				if ((Tj160p01Constant.DISP_PTN_RENBAN_5).Equals(before_dataRow.face_no) && (Tj160p01Constant.DISP_PTN_RENBAN_5).Equals(now_dataRow.face_no))
				{
					remove_flg = true;
				}

				//1行前のフェイスNoがXXXXXかつ現在行のフェイスNoがXXXXXの場合、現在行不要
				if ((Tj160p01Constant.DISP_PTN_NUKEBAN_5).Equals(before_dataRow.face_no) && (Tj160p01Constant.DISP_PTN_NUKEBAN_5).Equals(now_dataRow.face_no))
				{
					remove_flg = true;
				}

				//1行前のフェイスNoがspaceかつ,棚段がXX,現在行のフェイスNoがspaceかつ,棚段がXXの場合、現在行不要
				if (("").Equals(before_dataRow.face_no) && (Tj160p01Constant.DISP_PTN_NUKEBAN_2).Equals(before_dataRow.tana_dan) &&
				   ("").Equals(now_dataRow.face_no) && (Tj160p01Constant.DISP_PTN_NUKEBAN_2).Equals(now_dataRow.tana_dan))
				{
					remove_flg = true;
				}

				//一行前のフェイスNoがSpace,|,XXXXX以外で棚段がXX,現在行のフェイスNoがspaceかつ、棚段がXXの場合、現行行不要			
				if (!(("").Equals(before_dataRow.face_no) || (Tj160p01Constant.DISP_PTN_RENBAN_5).Equals(before_dataRow.face_no) || (Tj160p01Constant.DISP_PTN_NUKEBAN_5).Equals(before_dataRow.face_no)))
				{
					if ((Tj160p01Constant.DISP_PTN_NUKEBAN_2).Equals(before_dataRow.tana_dan) &&
					   ("").Equals(now_dataRow.face_no) && (Tj160p01Constant.DISP_PTN_NUKEBAN_2).Equals(now_dataRow.tana_dan))
					{
						remove_flg = true;
					}
				}

				//削除対象でかつ、欠番の場合、前レコードにメモを移動する
				if (remove_flg == true && Tj160p01Constant.DATA_FLG_KETUBAN.Equals(now_dataRow.data_flg))
				{
					Tj160M1ModelVO dammydataRow = (Tj160M1ModelVO)outData[outData.Count - 1];
					dammydataRow.memo = now_dataRow.memo;
				}

				//削除対象でなければデータ設定
				if (remove_flg == false)
				{
					//行追加
					outData.Add(now_dataRow);
				}
			}

			//----------------------------------------------------------
			//最終行目の処理(最終行目は必ず設定する)		
			//2件以上ある場合処理
			if (inData.Count > 1)
			{
				dataRow = (Tj160M1ModelVO)inData[inData.Count - 1];
				//行追加
				outData.Add(dataRow);
			}


			return outData;
		}
		#endregion

		#region チェックリストのデータに対して同一フェイスNoは一度しか表示しないように編集
		/// <summary>
		/// チェックリストのデータに対して同一フェイスNoは一度しか表示しないように編集
		/// </summary>
		/// <param name="ArrayList">InData</param>
		/// <param name="Tj160f01Form">f01VO</param>
		/// <returns name="ArrayList">OutData</returns>
		private ArrayList doFormatCheckListFace(ArrayList inData, Tj160f01Form f01VO)
		{
			ArrayList outData = new ArrayList();

			//フェイスNoの退避項目
			String wk_face = string.Empty;

			//----------------------------------------------------------
			//1行目の処理(1行目は必ず設定する)
			Tj160M1ModelVO dataRow = (Tj160M1ModelVO)inData[0];
			//行追加
			outData.Add(dataRow);
			//----------------------------------------------------------

			wk_face = dataRow.face_no.ToUpper();

			//先頭から最後までループ
			for (int i = 1; i < inData.Count - 1; i++)
			{
				//現在行取得
				Tj160M1ModelVO now_dataRow = (Tj160M1ModelVO)inData[i];

				//フェイスNoが退避Faceと同じ場合、フェイスNoを空白に置き換える
				if (wk_face.Equals(now_dataRow.face_no, StringComparison.OrdinalIgnoreCase))
				{
					//フェイスNoを空白に置き換える
					now_dataRow.face_no = ("");
				}
				else 
				{
					//フェイスNoが違う、かつspace,XXXXXじゃない場合、フェイスNoを退避する
					if (!(("").Equals(now_dataRow.face_no) || (Tj160p01Constant.DISP_PTN_NUKEBAN_5).Equals(now_dataRow.face_no) || (Tj160p01Constant.DISP_PTN_RENBAN_5).Equals(now_dataRow.face_no)))
					{
						//1行目のフェイスNoを退避する
						wk_face = now_dataRow.face_no;
					} 
				}

				//行追加
				outData.Add(now_dataRow);
			}

			//最終行目の処理(最終行目は必ず設定する)		
			//2件以上ある場合処理
			if (inData.Count > 1)
			{
				dataRow = (Tj160M1ModelVO)inData[inData.Count - 1];
				//行追加
				outData.Add(dataRow);
			}

			return outData;
		}

		#endregion

		#region フェイスNOフォーマット編集

		/// <summary>
		/// フェイスNO編集
		/// </summary>
		/// <param name="String">FaceNo</param>
		/// <returns>結果</returns>
		public String formatFaceNo(String FaceNo)
		{
			String ret = string.Empty;
			decimal number = 0;
			// 数値だった場合、5桁の0うめ編集を行う
			bool canConvert = decimal.TryParse(FaceNo, out number);
			if (canConvert == true)
			{
				ret = BoSystemFormat.formatFaceNo(FaceNo);
			}
			else
			{
				ret = FaceNo;
			}

			return ret;

		}

		#endregion

		#region 重複フォーマット編集

		/// <summary>
		/// 重複編集
		/// </summary>
		/// <param name="String">Tyohuku</param>
		/// <returns>結果</returns>
		public String formatTyohuku(String Tyohuku)
		{
			String ret = string.Empty;
			// 1か空白か0の場合、空白を返却する、それ以外の場合、値を返却する
			if (String.IsNullOrEmpty(Tyohuku) || ("1").Equals(Tyohuku) || ("0").Equals(Tyohuku))
			{
				// 何もしない
			}
			else
			{
				ret = Tyohuku;
			}
			return ret;
		}

		#endregion

		#endregion
	}
}
