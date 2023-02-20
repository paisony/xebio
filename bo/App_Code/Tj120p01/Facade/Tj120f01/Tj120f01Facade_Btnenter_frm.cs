using com.xebio.bo.Tj120p01.Constant;
using com.xebio.bo.Tj120p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tj120p01.Facade
{
  /// <summary>
  /// Tj120f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj120f01Facade : StandardBaseFacade
	{

		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{

			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。
				BoSystemLog.logOut("棚卸重複検索 確定ボタン 初期化 START");
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj120f01Form f01VO = (Tj120f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// Dictionaryより店舗コード、棚卸基準日取得
				String tenpocd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + Tj120p01Constant.DIC_TENPO_CD]);
				String tanaorosi_ymd = BoSystemFormat.formatDate((string)f01VO.Dictionary[Tj120p01Constant.DIC_TANAOROSIKIJUN_YMD]);

				#endregion
				BoSystemLog.logOut("棚卸重複検索 確定ボタン 初期化 END");
				BoSystemLog.logOut("棚卸重複検索 確定ボタン 業務チェック START");
				#region 業務チェック
				// 警告結果感知
				string warningflg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0");
				if (!warningflg.Equals("1"))
				{
					#region 編集行 or 選択行チェック
					int inputflg = 0;
					// モード「修正」の場合
					//Ｍ１確定処理フラグ(隠し)＝"1"の行が存在しない場合、エラー E140			
					if(f01VO.Stkmodeno == BoSystemConstant.MODE_UPD)
					{
						#region 確定処理フラグチェック
						for (int i = 0; i < m1List.Count; i++)
						{
							Tj120f01M1Form f01m1VO = (Tj120f01M1Form)m1List[i];
							if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
							{
								inputflg = 1;
								break;
							}
						}
						if (inputflg == 0)
						{
							// 確定対象がありません。
							ErrMsgCls.AddErrMsg("E140", "", facadeContext);
						}
						#endregion
					}
					// モード「取消」の場合
					// 選択行が存在しない場合エラー E119 ①"対象行"
					else if (f01VO.Stkmodeno == BoSystemConstant.MODE_DEL)
					{
						#region 選択行チェック
						for (int i = 0; i < m1List.Count; i++)
						{
							Tj120f01M1Form f01m1VO = (Tj120f01M1Form)m1List[i];
							if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
							{
								inputflg = 1;
								break;
							}
						}
						if (inputflg == 0)
						{
							ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
						}

						#endregion
					}
					#endregion
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。	 E119①"対象行"								
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#region 棚卸データ 終了処理済チェック
					//2:マスタ存在
					//ヘッダ店舗コード 棚卸終了処理が行われている場合、エラー

					//棚卸終了処理が行われている場合、エラー
					//共通部品化
					SearchInventory.CheckInventoryEnd(tenpocd, tanaorosi_ymd, facadeContext, 1);
					#endregion
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#region 棚段範囲チェック
					// 棚段が1～10の間以外で入力されている場合、エラー
					for (int i = 0; i < m1List.Count; i++)
					{
						Tj120f01M1Form f01m1VO = (Tj120f01M1Form)m1List[i];
						decimal tanadan = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tana_dan, "0"));
						if (tanadan < 1 || tanadan > BoSystemConstant.TANA_DAN_MAX_V)
						{
							ErrMsgCls.AddErrMsg("E173"
											, new[] { "棚段", "1", BoSystemConstant.TANA_DAN_MAX_V.ToString() }
											, facadeContext
											, new[] { "M1tana_dan" }
											, f01m1VO.Dictionary[Tj120p01Constant.DIC_M1ROWNO].ToString()
											, i.ToString()
											, "M1");
						}
					}
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion

					#region 重複チェック、および警告メッセージ設定
					//3:マスタ存在 明細単位で以下の処理を実施する。
					//Ｍ１フェイス№、Ｍ１棚段			棚卸確定TBL(H)を検索し、存在していた場合、警告メッセージを表示する。
					//									明細欄に同一のフェイス№、棚段が存在するかのチェックも行う。
					//	警告が発生した場合、その時点でチェックを中止しクライアント側へ警告内容を返却する。	
					//  W100 フェイスNoと棚段が重複するデータが存在します。登録しますか？

					// モード修正の場合のみ
					if (f01VO.Stkmodeno == BoSystemConstant.MODE_UPD)
					{
						chohukuCheck(m1List, facadeContext, tenpocd, tanaorosi_ymd);

						if(InfoMsgCls.HasWarn(facadeContext))
						{
							return;
						}
					}
					#endregion
				}

				#region 排他チェック
				//4:排他チェック 明細単位で以下の処理を実施する。
				//更新日時			検索時に取得した更新日、更新時間とDB上の更新日、更新時間を比較し異なる場合、エラー
				//※検索時に取得した更新日、更新時間と[棚卸確定TBL(H)]から取得した更新日、更新時間を比較する。

				//	V03003
				//	①選択行の[Dictionary.更新日]								
				//	②選択行の[Dictionary.更新時間]								
				//	③"MDIT0010"								
				//	④左記抽出条件のカラム名								
				//	⑤左記抽出条件の値								
				//	⑥"1"(FORUPDATE実施)								
				//	⑦エラーメッセージリスト(参照)								
				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");			// 店舗コード
				sRepSql.Append(" AND FACE_NO = :BIND_FACE_NO");				// フェイス№
				sRepSql.Append(" AND TANA_DAN = :BIND_TANA_DAN");			// 棚段
				sRepSql.Append(" AND KAI_SU = :BIND_KAI_SU");				// 回数
				sRepSql.Append(" AND TANAOROSI_YMD = :BIND_TANAOROSI_YMD");	// 棚卸日
				sRepSql.Append(" AND SOSINKAI_SU = :BIND_SOSINKAI_SU");		// 送信回数

				for (int i = 0; i < m1List.Count; i++)
				{
					Tj120f01M1Form f01m1VO = (Tj120f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
						|| f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 店舗コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						// カード部のDictionaryより取得
						bindVO.Value = tenpocd;
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// フェイス№
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_FACE_NO";
						// 明細部のDictionaryより取得
						bindVO.Value = (string)f01m1VO.Dictionary[Tj120p01Constant.DIC_M1FACE_NO];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 棚段
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TANA_DAN";
						// 明細部のDictionaryより取得
						bindVO.Value = (string)f01m1VO.Dictionary[Tj120p01Constant.DIC_M1TANA_DAN];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 回数
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_KAI_SU";
						// 明細部より取得
						bindVO.Value = (string)f01m1VO.M1kai_su;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 棚卸日
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TANAOROSI_YMD";
						// 明細部のDictionaryより取得
						bindVO.Value = BoSystemFormat.formatDate((string)f01m1VO.Dictionary[Tj120p01Constant.DIC_M1TANAOROSI_YMD]);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 送信回数
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SOSINKAI_SU";
						// 明細部のDictionaryより取得
						bindVO.Value = (string)f01m1VO.Dictionary[Tj120p01Constant.DIC_M1SOSINKAI_SU];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tj120p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tj120p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								"MDIT0010",
								sRepSql.ToString(),
								bindList,
								1,
								null,
								(i + 1).ToString(),
								i.ToString(),
								"M1",
								100
						);
					}
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。		
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion
				BoSystemLog.logOut("棚卸重複検索 確定ボタン 業務チェック END");
				BoSystemLog.logOut("棚卸重複検索 確定ボタン 更新処理 START");
				#region 更新処理
				//システム日時を取得
				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				int iCnt = 0;
				//細単位で以下の処理を実施する。				
				foreach (Tj120f01M1Form check in m1List.ListData)
				{
					//	[選択モードNo]が「修正」の場合			
					if (f01VO.Stkmodeno == BoSystemConstant.MODE_UPD)
					{
						//	[Ｍ１確定処理フラグ(隠し)]が"1"の場合、以下の処理を実施する。		
						if (check.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
						{
							upd(facadeContext, f01VO, check, logininfo, sysDateVO, iCnt);
						}
					}
					//	[選択モードNo]が「取消」の場合			
					else if (f01VO.Stkmodeno == BoSystemConstant.MODE_DEL)
					{
						//	[Ｍ１選択フラグ(隠し)]が"1"の場合、以下の処理を実施する。		
						if (check.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							dlt(facadeContext, f01VO, check);
						}
					}
					iCnt++;
				}
				#endregion
				BoSystemLog.logOut("棚卸重複検索 確定ボタン 更新処理 END");
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

		#region ユーザー定義関数

		#region 数値範囲チェック

		/// <summary>
		/// 数値範囲チェック
		/// </summary>
		/// <param name="a">対象数値</param>
		/// <param name="from">範囲（開始）</param>
		/// <param name="to">範囲（終了）</param>
		/// <returns>結果</returns>
		public Boolean IsRange(Decimal a, Decimal from, Decimal to)
		{
			return (from <= a && a <= to);
		}

		#endregion


		#region 重複チェック
		/// <summary>
		/// TyohukuCheck 重複チェック
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="tenpo_cd">m1List</param>
		/// <param name="tanaorosi_ymd">m1List</param>
		/// <returns></returns>
		private Boolean chohukuCheck(IDataList m1List, IFacadeContext facadeContext, string tenpoCd, string tanaorosiYmd)
		{

			for (int i = 0; i < m1List.Count; i++)
			{
				// 比較元明細行情報取得
				Tj120f01M1Form hikakumoto = (Tj120f01M1Form)m1List[i];
				int infoM1 = 0;

				// 編集行のみをチェックの対象とする
				if (hikakumoto.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
				{
					string motoFaceNo = hikakumoto.M1face_no;
					string motoTanaDan = hikakumoto.M1tana_dan;
					#region 明細重複チェック
					for (int j = 0; j < m1List.Count; j++)
					{
						// 比較先明細行情報取得 比較対象は編集の有無を問わず
						Tj120f01M1Form hikakusaki = (Tj120f01M1Form)m1List[j];
						
						// 同行を比較対象から除外
						if (i != j)
						{
							string sakiFaceNo = hikakusaki.M1face_no;
							string sakiTanaDan = hikakusaki.M1tana_dan;
							// 比較元と先のフェイスNoと棚段を比較
							if (motoFaceNo.Equals(sakiFaceNo) && motoTanaDan.Equals(sakiTanaDan))
							{
								// すでにメッセージ登録済みの場合は除外
								if (infoM1 == 0)
								{
									// 警告メッセージを設定する
									InfoMsgCls.AddWarnMsg("W100", String.Empty, facadeContext, new[] { "M1face_no", "M1tana_dan" }, (i + 1).ToString(), i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
									infoM1 = 1;
								}
							}
						}
					}
					#endregion

					#region DB重複チェック
					//DB重複チェック
					FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_04, facadeContext.DBContext);
					reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(tenpoCd));
					reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(motoFaceNo, "0")));
					reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(motoTanaDan, "0")));
					reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl(tanaorosiYmd, "0")));
					//検索結果を取得します
					reader.CreateDbCommand();
					IList<Hashtable> tableList = reader.Execute();
					if (tableList.Count == 0)
					{
						// DB重複無し
					}
					else
					{
						// すでに明細で重複があるものはワーニングは出さない
						if (infoM1 == 0)
						{
							// 警告メッセージを設定する
							InfoMsgCls.AddWarnMsg("W100", String.Empty, facadeContext, new[] { "M1face_no", "M1tana_dan" }, (i + 1).ToString(), i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						}
					}
					#endregion
				}
			}
			return true;
		}
		#endregion

		#region  更新
		private Boolean upd(IFacadeContext facadeContext, Tj120f01Form f01Form, Tj120f01M1Form f01M1Form, LoginInfoVO loginInfo, SysDateVO sysDateVO ,int iCnt)
		{
			Boolean retFlg = true;
			string tenpoCd = BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.PREFIX + Tj120p01Constant.DIC_TENPO_CD]);
			decimal faceNo_old = Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj120p01Constant.DIC_M1FACE_NO], "0"));
			decimal faceNo_new = Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1face_no, "0"));
			decimal tanaDan_old = Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj120p01Constant.DIC_M1TANA_DAN], "0"));
			decimal tanaDan_new = Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1tana_dan, "0"));
			decimal kaiSu_old = Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1kai_su, "0"));
			decimal tanaorosi_ymd = Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj120p01Constant.DIC_M1TANAOROSI_YMD], "0"));
			decimal sosinkai_su = Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj120p01Constant.DIC_M1SOSINKAI_SU], "0"));
			decimal upd_ymd = sysDateVO.Sysdate;
			decimal upd_tm = sysDateVO.Systime_mili;
			string upd_tancd = BoSystemFormat.formatTantoCd(loginInfo.TtsCd);

			//処理過程で取得
			decimal kaiSu_new;

			#region 新回数取得
			//①新フェイスNo,棚段で存在チェックし、回数を求める。
			//	存在しなければ1→C#で設定									

			// XMLからSQLを取得する。
			FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_05, facadeContext.DBContext);
			// バインド設定
			rtSearch.BindValue("BIND_FACE_NO_OLD", faceNo_old);
			rtSearch.BindValue("BIND_TANA_DAN_OLD", tanaDan_old);
			rtSearch.BindValue("BIND_KAI_SU_OLD", kaiSu_old);
			rtSearch.BindValue("BIND_TENPO_CD", tenpoCd);
			rtSearch.BindValue("BIND_FACE_NO_NEW", faceNo_new);
			rtSearch.BindValue("BIND_TANA_DAN_NEW", tanaDan_new);
			rtSearch.BindValue("BIND_TANAOROSI_YMD", tanaorosi_ymd);

			//検索結果を取得します
			rtSearch.CreateDbCommand();
			IList<Hashtable> tableList = rtSearch.Execute();

			if (tableList.Count == 0)
			{
				kaiSu_new = 1;
			}
			else
			{
				// 重複ありで登録する場合で、回数の桁がオーバーする場合
				kaiSu_new = (decimal)tableList[0]["KAI_SU_NEW"];
				if (kaiSu_new > 99)
				{
					// エラー :回数が有効桁数を超えています。
					ErrMsgCls.AddErrMsg("E102", "回数", facadeContext, new[] { "M1face_no", "M1tana_dan" }, (iCnt + 1).ToString(), iCnt.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
					return false;
				}
			}
			#endregion
			#region [棚卸確定TBL(H)]を更新する。
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_07, facadeContext.DBContext);
			// バインド設定
			reader.BindValue("BIND_FACE_NO_NEW", faceNo_new);
			reader.BindValue("BIND_TANA_DAN_NEW", tanaDan_new);
			reader.BindValue("BIND_KAI_SU_NEW", kaiSu_new);
			reader.BindValue("BIND_UPD_YMD", upd_ymd);
			reader.BindValue("BIND_UPD_TM", upd_tm);
			reader.BindValue("BIND_UPD_TANCD", upd_tancd);
			reader.BindValue("BIND_SAKUJYO_YMD", upd_ymd);
			reader.BindValue("BIND_FACE_NO_OLD", faceNo_old);
			reader.BindValue("BIND_TANA_DAN_OLD", tanaDan_old);
			reader.BindValue("BIND_KAI_SU_OLD", kaiSu_old);
			reader.BindValue("BIND_TENPO_CD", tenpoCd);
			reader.BindValue("BIND_FACE_NO_OLD2", faceNo_old);
			reader.BindValue("BIND_TANA_DAN_OLD2", tanaDan_old);
			reader.BindValue("BIND_KAI_SU_OLD2", kaiSu_old);
			reader.BindValue("BIND_TANAOROSI_YMD", tanaorosi_ymd);
			reader.BindValue("BIND_SOSINKAI_SU", sosinkai_su);
			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				cmd.ExecuteNonQuery();
			}
			#endregion
			#region [棚卸確定TBL(H)]を更新する(棚段数更新)。
			// XMLからSQLを取得する。
			FindSqlResultTable reader2 = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_08, facadeContext.DBContext);
			reader2.BindValue("BIND_TENPO_CD", tenpoCd);
			reader2.BindValue("BIND_FACE_NO_NEW", faceNo_new);
			reader2.BindValue("BIND_KAI_SU_NEW", kaiSu_new);
			reader2.BindValue("BIND_TANAOROSI_YMD", tanaorosi_ymd);
			reader2.BindValue("BIND_SOSINKAI_SU", sosinkai_su);
			reader2.BindValue("BIND_TENPO_CD2", tenpoCd);
			reader2.BindValue("BIND_FACE_NO_NEW2", faceNo_new);
			reader2.BindValue("BIND_KAI_SU_NEW2", kaiSu_new);
			reader2.BindValue("BIND_TANAOROSI_YMD2", tanaorosi_ymd);
			reader2.BindValue("BIND_SOSINKAI_SU2", sosinkai_su);
			//クエリを実行する。
			using (IDbCommand cmd = reader2.CreateDbCommand())
			{
				cmd.ExecuteNonQuery();
			}
			#endregion
			#region [棚卸欠番TBL]を削除する。
			// XMLからSQLを取得する。
			FindSqlResultTable reader3 = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_06, facadeContext.DBContext);
			reader3.BindValue("BIND_TENPO_CD", tenpoCd);
			reader3.BindValue("BIND_TANAOROSI_YMD", tanaorosi_ymd);
			reader3.BindValue("BIND_FACE_NO_NEW", faceNo_new);
			//クエリを実行する。
			using (IDbCommand cmd = reader3.CreateDbCommand())
			{
				cmd.ExecuteNonQuery();
			}
			#endregion
			#region [棚卸確定TBL(B)]を更新する。
			// XMLからSQLを取得する。
			FindSqlResultTable reader4 = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_09, facadeContext.DBContext);
			reader4.BindValue("BIND_FACE_NO_NEW", faceNo_new);
			reader4.BindValue("BIND_TANA_DAN_NEW", tanaDan_new);
			reader4.BindValue("BIND_KAI_SU_NEW", kaiSu_new);
			reader4.BindValue("BIND_TENPO_CD", tenpoCd);
			reader4.BindValue("BIND_FACE_NO_OLD", faceNo_old);
			reader4.BindValue("BIND_TANA_DAN_OLD", tanaDan_old);
			reader4.BindValue("BIND_KAI_SU_OLD", kaiSu_old);
			reader4.BindValue("BIND_TANAOROSI_YMD", tanaorosi_ymd);
			reader4.BindValue("BIND_SOSINKAI_SU", sosinkai_su);
			//クエリを実行する。
			using (IDbCommand cmd = reader4.CreateDbCommand())
			{
				cmd.ExecuteNonQuery();
			}
			#endregion
			return retFlg;

		}

		#endregion

		#region 削除
		private Boolean dlt(IFacadeContext facadeContext, Tj120f01Form f01Form, Tj120f01M1Form f01M1Form)
		{
			Boolean retFlg = true;
			string tenpoCd = BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.PREFIX + Tj120p01Constant.DIC_TENPO_CD]);
			decimal faceNo = Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1face_no, "0"));
			decimal tanaDan = Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1tana_dan, "0"));
			decimal kaiSu = Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1kai_su, "0"));
			decimal tanaorosi_ymd = Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj120p01Constant.DIC_M1TANAOROSI_YMD], "0"));
			decimal sosinkai_su = Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tj120p01Constant.DIC_M1SOSINKAI_SU], "0"));

			//	[棚卸確定TBL(H)]を削除する。
			BoSystemLog.logOut("[棚卸確定TBL(H)]を削除 START");
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_10, facadeContext.DBContext);
			reader.BindValue("BIND_TENCD", tenpoCd);
			reader.BindValue("BIND_FACE_NO", faceNo);
			reader.BindValue("BIND_TANA_DAN", tanaDan);
			reader.BindValue("BIND_KAI_SU", kaiSu);
			reader.BindValue("BIND_TANAOROSI_YMD", tanaorosi_ymd);
			reader.BindValue("BIND_SOSINKAI_SU", sosinkai_su);
			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				cmd.ExecuteNonQuery();
			}
			BoSystemLog.logOut("[棚卸確定TBL(H)]を削除 END");
			BoSystemLog.logOut("[棚卸確定TBL(B)]を削除 START");
			//	[棚卸確定TBL(B)]を削除する。	
			FindSqlResultTable reader2 = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_11, facadeContext.DBContext);
			reader2.BindValue("BIND_TENCD", tenpoCd);
			reader2.BindValue("BIND_FACE_NO", faceNo);
			reader2.BindValue("BIND_TANA_DAN", tanaDan);
			reader2.BindValue("BIND_KAI_SU", kaiSu);
			reader2.BindValue("BIND_TANAOROSI_YMD", tanaorosi_ymd);
			reader2.BindValue("BIND_SOSINKAI_SU", sosinkai_su);
			//クエリを実行する。
			using (IDbCommand cmd = reader2.CreateDbCommand())
			{
				cmd.ExecuteNonQuery();
			}
			BoSystemLog.logOut("[棚卸確定TBL(B)]を削除 END");
			return retFlg;
		}

		#endregion

		#endregion

	}
}
