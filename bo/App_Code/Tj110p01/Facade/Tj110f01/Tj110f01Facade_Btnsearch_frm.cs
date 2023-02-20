using com.xebio.bo.Tj110p01.Constant;
using com.xebio.bo.Tj110p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

namespace com.xebio.bo.Tj110p01.Facade
{
  /// <summary>
  /// Tj110f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj110f01Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj110f01Form f01VO = (Tj110f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 棚卸基準日
				String tanaorosikijun_Ymd = "-1";

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				// 店舗MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];

						// 1-2 ヘッダ店舗コード
						// 棚卸期間外の場合、エラー
						Hashtable TanaoroshiYmdList = SearchInventory.SearchMdit0030(
												f01VO.Head_tenpo_cd,
												sysDateVO.Sysdate.ToString(),     //エラーが発生した場合、その時点でチェックを中止しクライアント側
												facadeContext,
												1);

						if (TanaoroshiYmdList != null)
						{
							tanaorosikijun_Ymd = TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString();
						}
					}
				}

				// フェイスNoに0は使用不可
				if (("0").Equals(f01VO.Face_no_from))
				{
					ErrMsgCls.AddErrMsg("E103", "フェイスNoFROM", facadeContext, new[] { "Face_no_from" });
				}

				if (("0").Equals(f01VO.Face_no_to))
				{
					ErrMsgCls.AddErrMsg("E103", "フェイスNoTo", facadeContext, new[] { "Face_no_to" });
				}


				#endregion

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				
				#region 関連チェック

				// フェイス№FROM > フェイス№TOの場合エラー
				V03002Check.CodeFromToChk(
								f01VO.Face_no_from,
								f01VO.Face_no_to,
								facadeContext,
								"フェイスNo",
								new[] { "Face_no_from", "Face_no_to" }
								);
		
				#endregion

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				
				#region 件数チェック

				// 検索
				ArrayList rtChk = doSelectDataBase(f01VO, tanaorosikijun_Ymd, Tj110p01Constant.ORACLE_PACKAGE_01_COUNT, facadeContext);

				// カーソル取得
				ArrayList rtChkList = (ArrayList)rtChk[1];
				Hashtable htChkList = (Hashtable)rtChkList[0];

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

				#endregion

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 検索処理

				// 検索
				ArrayList rtSeach = doSelectDataBase(f01VO, tanaorosikijun_Ymd, Tj110p01Constant.ORACLE_PACKAGE_01, facadeContext);

				// カーソル取得
				ArrayList rtSeachList = (ArrayList)rtSeach[1];

				foreach (Hashtable rec in rtSeachList)
				{
					Tj110f01M1Form f01m1VO = new Tj110f01M1Form();

					// 行NO1
					f01m1VO.M1rowno = rec["NO1"].ToString();				// Ｍ１行NO
					f01m1VO.M1face_no = rec["FACE_NO1"].ToString();			// Ｍ１フェイス№
					f01m1VO.M1tana_dan = BoSystemString.ZeroToEmpty(rec["TANA_DAN1"].ToString());		// Ｍ１棚段
					f01m1VO.M1selectorcheckbox = rec["FLG1"].ToString();	// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = "0";							// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = "3";								// Ｍ１明細色区分(隠し)

					// 行NO2
					f01m1VO.M1rowno2 = rec["NO2"].ToString();				// Ｍ１行NO２
					f01m1VO.M1face_no2 = rec["FACE_NO2"].ToString();		// Ｍ１フェイス№２
					f01m1VO.M1tana_dan2 = BoSystemString.ZeroToEmpty(rec["TANA_DAN2"].ToString());		// Ｍ１棚段２
					f01m1VO.M1selectorcheckbox2 = rec["FLG2"].ToString();	// Ｍ１選択フラグ(隠し)2
					f01m1VO.M1entersyoriflg2 = "0";							// Ｍ１確定処理フラグ(隠し)２
					f01m1VO.M1dtlirokbn2 = "3";								// Ｍ１明細色区分(隠し)２

					// 行NO3
					f01m1VO.M1rowno3 = rec["NO3"].ToString();				// Ｍ１行NO３
					f01m1VO.M1face_no3 = rec["FACE_NO3"].ToString();		// Ｍ１フェイス№３
					f01m1VO.M1tana_dan3 = BoSystemString.ZeroToEmpty(rec["TANA_DAN3"].ToString());		// Ｍ１棚段３
					f01m1VO.M1selectorcheckbox3 = rec["FLG3"].ToString();	// Ｍ１選択フラグ(隠し)３
					f01m1VO.M1entersyoriflg3 = "0";							// Ｍ１確定処理フラグ(隠し)３
					f01m1VO.M1dtlirokbn3 = "3";								// Ｍ１明細色区分(隠し)３

					// 行NO4
					f01m1VO.M1rowno4 = rec["NO4"].ToString();				// Ｍ１行NO４
					f01m1VO.M1face_no4 = rec["FACE_NO4"].ToString();		// Ｍ１フェイス№４
					f01m1VO.M1tana_dan4 = BoSystemString.ZeroToEmpty(rec["TANA_DAN4"].ToString());		// Ｍ１棚段４
					f01m1VO.M1selectorcheckbox4 = rec["FLG4"].ToString();	// Ｍ１選択フラグ(隠し)４
					f01m1VO.M1entersyoriflg4 = "0";							// Ｍ１確定処理フラグ(隠し)４
					f01m1VO.M1dtlirokbn4 = "3";								// Ｍ１明細色区分(隠し)４

					// 行NO5
					f01m1VO.M1rowno5 = rec["NO5"].ToString();				// Ｍ１行NO５
					f01m1VO.M1face_no5 = rec["FACE_NO5"].ToString();		// Ｍ１フェイス№５
					f01m1VO.M1tana_dan5 = BoSystemString.ZeroToEmpty(rec["TANA_DAN5"].ToString());		// Ｍ１棚段５
					f01m1VO.M1selectorcheckbox5 = rec["FLG5"].ToString();	// Ｍ１選択フラグ(隠し)５
					f01m1VO.M1entersyoriflg5 = "0";							// Ｍ１確定処理フラグ(隠し)５
					f01m1VO.M1dtlirokbn5 = "3";								// Ｍ１明細色区分(隠し)５

					// 行NO6
					f01m1VO.M1rowno6 = rec["NO6"].ToString();				// Ｍ１行NO６
					f01m1VO.M1face_no6 = rec["FACE_NO6"].ToString();		// Ｍ１フェイス№６
					f01m1VO.M1tana_dan6 = BoSystemString.ZeroToEmpty(rec["TANA_DAN6"].ToString());		// Ｍ１棚段６
					f01m1VO.M1selectorcheckbox6 = rec["FLG6"].ToString();	// Ｍ１選択フラグ(隠し)６
					f01m1VO.M1entersyoriflg6 = "0";							// Ｍ１確定処理フラグ(隠し)６
					f01m1VO.M1dtlirokbn6 = "3";								// Ｍ１明細色区分(隠し)６

					// 行NO7
					f01m1VO.M1rowno7 = rec["NO7"].ToString();				// Ｍ１行NO７
					f01m1VO.M1face_no7 = rec["FACE_NO7"].ToString();		// Ｍ１フェイス№７
					f01m1VO.M1tana_dan7 = BoSystemString.ZeroToEmpty(rec["TANA_DAN7"].ToString());		// Ｍ１棚段７
					f01m1VO.M1selectorcheckbox7 = rec["FLG7"].ToString();	// Ｍ１選択フラグ(隠し)７
					f01m1VO.M1entersyoriflg7 = "0";							// Ｍ１確定処理フラグ(隠し)７
					f01m1VO.M1dtlirokbn7 = "3";								// Ｍ１明細色区分(隠し)７

					// Dictionary
					// 店舗コード
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1TENPO_CD1, rec["TENCD1"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1TENPO_CD2, rec["TENCD2"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1TENPO_CD3, rec["TENCD3"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1TENPO_CD4, rec["TENCD4"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1TENPO_CD5, rec["TENCD5"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1TENPO_CD6, rec["TENCD6"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1TENPO_CD7, rec["TENCD7"].ToString());

					// 欠番フラグ
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1FLG1, rec["FLG1"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1FLG2, rec["FLG2"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1FLG3, rec["FLG3"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1FLG4, rec["FLG4"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1FLG5, rec["FLG5"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1FLG6, rec["FLG6"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1FLG7, rec["FLG7"].ToString());

					// 列
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1RETU1, rec["RETU1"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1RETU2, rec["RETU2"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1RETU3, rec["RETU3"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1RETU4, rec["RETU4"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1RETU5, rec["RETU5"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1RETU6, rec["RETU6"].ToString());
					f01m1VO.Dictionary.Add(Tj110p01Constant.DIC_M1RETU7, rec["RETU7"].ToString());

					////リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// 表示は最大(10行)まで行う
				int iMod = 0;
				iMod = m1List.Count % m1List.DispRow;
				if (iMod > 0)
				{
					for (int i = 0; i < m1List.DispRow - iMod; i++)
					{
						m1List.Add(new Tj110f01M1Form(), true);
					}
				}

				// 最大行設定
				Hashtable hsListOne = (Hashtable)rtSeachList[0];
				f01VO.Searchcnt = hsListOne["MAXNO"].ToString();

				// Dictionary設定
				f01VO.Dictionary[Tj110p01Constant.DIC_UPD_YMD] = BoSystemString.Nvl(BoSystemString.ZeroToEmpty(hsListOne["UPD_YMD1"].ToString()), "-1");		// 更新日
				f01VO.Dictionary[Tj110p01Constant.DIC_UPD_TIM] = BoSystemString.Nvl(BoSystemString.ZeroToEmpty(hsListOne["UPD_TIM1"].ToString()), "-1");	// 更新時間
				f01VO.Dictionary[Tj110p01Constant.DIC_TANAOROSIKIJUN_YMD] = tanaorosikijun_Ymd.ToString();		// 棚卸基準日

				#endregion

				#region 検索条件をDictionaryに設定

				// 検索時のformVOを保持
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				#endregion
			
				//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
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
		/// <param name="Tj110f01Form">f01VO</param>
		/// <param name="String">tanaorosikijun_Ymd</param>
		/// <param name="String">packageId</param>
		/// <returns>結果</returns>
		public ArrayList doSelectDataBase(Tj110f01Form f01VO, String tanaorosikijun_Ymd, String packageId, IFacadeContext facadeContext)
		{
			// 取漏れ／欠番区分、空白の場合0を設定
			String storiKbn = f01VO.Torimore_ketsuban;

			if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Torimore_ketsuban))
			{
				storiKbn = "0";
			}

			// ストアド呼び出し
			// 棚卸取漏れ/欠番検索(カウント用)（取漏れ欠番処理）
			// ■パラメータ設定
			ArrayList paramList = new ArrayList();

			// 店舗コード
			StoredProcedureCls.SetStoredParam(ref paramList, "v_tencd", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// 棚卸日
			StoredProcedureCls.SetStoredParam(ref paramList, "v_tanaorosijissi_ymd", OracleDbType.Decimal, ParameterDirection.Input,
				Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(tanaorosikijun_Ymd), "-1")));
			// フェイスNoFrom
			StoredProcedureCls.SetStoredParam(ref paramList, "v_face_no_from", OracleDbType.Decimal, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(f01VO.Face_no_from, "-1")));
			// フェイスNoTo
			StoredProcedureCls.SetStoredParam(ref paramList, "v_face_no_to", OracleDbType.Decimal, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(f01VO.Face_no_to, "-1")));
			// フラグ 0：空白、1：取漏れ、2:欠番
			StoredProcedureCls.SetStoredParam(ref paramList, "v_flg", OracleDbType.Decimal, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(storiKbn, "0")));


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

		#endregion
	}
}
