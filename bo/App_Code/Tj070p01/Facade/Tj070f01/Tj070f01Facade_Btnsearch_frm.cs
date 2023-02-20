using com.xebio.bo.Tj070p01.Constant;
using com.xebio.bo.Tj070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
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
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tj070p01.Facade
{
  /// <summary>
  /// Tj070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj070f01Facade : StandardBaseFacade
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
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// ログイン情報取得
				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj070f01Form formVO = (Tj070f01Form)facadeContext.FormVO;
				IDataList m1List = formVO.GetList("M1");

				#region 初期化

				// ディクショナリのクリア
				formVO.Dictionary.Clear();

				// 選択モードNoの初期化
				formVO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				#region 1. 単項目チェック

				// 1-1 ヘッダ店舗コード
				//       店舗MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(formVO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(formVO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						formVO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}


				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 2. 関連チェック

				// 2-1 店舗コードFROM、店舗コードTO
				//       店舗コードFROM > 店舗コードTOの場合エラー
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_from) &&
					!string.IsNullOrEmpty(formVO.Tenpo_cd_to))
				{
					V03002Check.CodeFromToChk(formVO.Tenpo_cd_from,
											  formVO.Tenpo_cd_to,
											  facadeContext,
											  "店舗",
											  new[] { "Tenpo_cd_from", "Tenpo_cd_to" }
											 );
				}

				// 2-2 HHT実施日FROM、HHT実施日TO
				//       HHT実施日FROM > HHT実施日TOの場合エラー
				if (!string.IsNullOrEmpty(formVO.Hhtjissi_ymd_from) &&
					!string.IsNullOrEmpty(formVO.Hhtjissi_ymd_to))
				{
					V03001Check.DateFromToChk(formVO.Hhtjissi_ymd_from,
											  formVO.Hhtjissi_ymd_to,
											  facadeContext,
											  "HHT実施日",
											  new[] { "Hhtjissi_ymd_from", "Hhtjissi_ymd_to" }
											 );
				}

				// 2-3 送信確定日FROM、送信確定日TO
				//       送信確定日FROM > 送信確定日TOの場合エラー
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_from) &&
					!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_to))
				{
					V03001Check.DateFromToChk(formVO.Sosin_kak_ymd_from,
											  formVO.Sosin_kak_ymd_to,
											  facadeContext,
											  "送信日",
											  new[] { "Sosin_kak_ymd_from", "Sosin_kak_ymd_to" }
											 );
				}


				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 件数チェック

				FindSqlResultTable rtChk = null;

				// 照会
				if (BoSystemConstant.MODE_REF.Equals(BoSystemString.Nvl(formVO.Modeno)))
				{
					rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj070p01Constant.SQL_ID_01, facadeContext.DBContext);
				}
				// 終了確認照会
				else if (BoSystemConstant.MODE_SYURYOKAKUNINREF.Equals(BoSystemString.Nvl(formVO.Modeno)))
				{
					rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj070p01Constant.SQL_ID_02, facadeContext.DBContext);
				}

				// 検索条件設定
				ReplaceWherePart(formVO, rtChk, "1");

				#region SQL実行

				Decimal dCnt = 0;

				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();

				if (logger.IsDebugEnabled)
				{
					BoSystemLog.logOut("SQL: " + rtChk.LogSql);
				}

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];
					dCnt = (Decimal)resultTbl["CNT"];

					// 0件チェック
					if (dCnt <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						// 最大件数チェック
						V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = null;

				// 照会
				if (BoSystemConstant.MODE_REF.Equals(BoSystemString.Nvl(formVO.Modeno)))
				{
					rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj070p01Constant.SQL_ID_03, facadeContext.DBContext);
				}
				// 終了確認照会
				else if (BoSystemConstant.MODE_SYURYOKAKUNINREF.Equals(BoSystemString.Nvl(formVO.Modeno)))
				{
					rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj070p01Constant.SQL_ID_04, facadeContext.DBContext);
				}

				// 検索条件設定
				ReplaceWherePart(formVO, rtSeach, "2");

				// ソート条件設定
				ReplaceOrderbyPart(formVO, rtSeach);

				#region SQL実行

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tj070f01M1Form m1formVO = new Tj070f01M1Form();

					// Ｍ１行NO
					m1formVO.M1rowno = iCnt.ToString();

					// Ｍ１店舗コード
					m1formVO.M1tenpo_cd = rec["TENCD"].ToString();
					// Ｍ１店舗名
					m1formVO.M1tenpo_nm = rec["TENPO_NM"].ToString();
					// Ｍ１HHT実施日
					if (!"0".Equals(rec["ADD_YMD"].ToString()))
					{
						m1formVO.M1hhtjissi_ymd = rec["ADD_YMD"].ToString();
					}
					else
					{
						m1formVO.M1hhtjissi_ymd = string.Empty;
					}
					// Ｍ１送信確定日
					if (!"0".Equals(rec["SOSIN_YMD"].ToString()))
					{
						m1formVO.M1sosin_kak_ymd = rec["SOSIN_YMD"].ToString();
					}
					else
					{
						m1formVO.M1sosin_kak_ymd = string.Empty;
					}
					// Ｍ１店舗確定状況
					m1formVO.M1tenpo_kakutei_jyokyo = rec["SOSINIRAI_FLG"].ToString();
					// Ｍ１店舗確定状況名称
					m1formVO.M1tenpo_kakutei_jotai_nm = rec["SOSINIRAI_NM"].ToString();
					// Ｍ１ＭＤ送信状況
					m1formVO.M1md_sosin_jyokyo = rec["SOSINZUMI_FLG"].ToString();
					// Ｍ１送信状況名称
					m1formVO.M1sosin_jotai_nm = rec["SOSINZUMI_NM"].ToString();

					// Ｍ１選択フラグ(隠し)
					m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					// Dictionary保存
					// 棚卸確定日
					m1formVO.Dictionary.Add(Tj070p01Constant.DIC_M1TANAOROSIKAKUTEI_YMD, rec["TANAOROSIKAKUTEI_YMD"].ToString());

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(m1formVO, true);
				}

				// 検索件数の設定
				formVO.Searchcnt = m1List.Count.ToString();

				#endregion

				#endregion

				#region 選択モードNOの設定

				// 選択モードNOの設定
				formVO.Stkmodeno = formVO.Modeno;

				#endregion

				#region Dictionary保存（カード部）

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(formVO);

				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
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

		#region 検索条件設定
		/// <summary>
		/// ReplaceWherePart 検索条件設定
		/// </summary>
		/// <param name="formVO">Tj070f01Form</param>
		/// <param name="rtChk">FindSqlResultTable</param>
		/// <param name="mode">String</param>
		/// <returns></returns>
		private void ReplaceWherePart(Tj070f01Form formVO, FindSqlResultTable reader, string mode)
		{

			// 照会
			if (BoSystemConstant.MODE_REF.Equals(BoSystemString.Nvl(formVO.Modeno)))
			{
				#region 1

				// 店舗コードFROMを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_FROM", " AND MDIT0020.TENCD >= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_FROM", "BIND01");
					reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_from));
				}

				// 店舗コードTOを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_TO", " AND MDIT0020.TENCD <= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_TO", "BIND02");
					reader.BindValue("BIND02", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_to));
				}


				// 店舗確定状況
				string strTenpo_kakutei_jyokyo = string.Empty;
				// 未確定
				if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO1.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo = strTenpo_kakutei_jyokyo + " AND MDIT0020.SOSINIRAI_FLG = 0 ";
				}
				// 確定済
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO2.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo = strTenpo_kakutei_jyokyo + " AND MDIT0020.SOSINIRAI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strTenpo_kakutei_jyokyo = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_TENPO_KAKUTEI_JYOKYO", strTenpo_kakutei_jyokyo);


				// 送信状態
				string strSosin_jyotai = string.Empty;
				// 未送信
				if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI1.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai = strSosin_jyotai + " AND MDIT0020.SOSINZUMI_FLG = 0 ";
				}
				// 送信済
				else if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI2.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai = strSosin_jyotai + " AND MDIT0020.SOSINZUMI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strSosin_jyotai = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_SOSIN_JYOTAI", strSosin_jyotai);


				// HHT実施日FROMを設定
				if (!string.IsNullOrEmpty(formVO.Hhtjissi_ymd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_HHTJISSI_YMD_FROM", " AND MDIT0010.ADD_YMD >= ");
					reader.ReplaceAddBind("REPLACE_ID_HHTJISSI_YMD_FROM", "BIND03");
					reader.BindValue("BIND03",  Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Hhtjissi_ymd_from)));
				}

				// HHT実施日TOを設定
				if (!string.IsNullOrEmpty(formVO.Hhtjissi_ymd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_HHTJISSI_YMD_TO", " AND MDIT0010.ADD_YMD <= ");
					reader.ReplaceAddBind("REPLACE_ID_HHTJISSI_YMD_TO", "BIND04");
					reader.BindValue("BIND04", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Hhtjissi_ymd_to)));
				}


				// 送信日FROMを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_FROM", " AND MDIT0020.SOSIN_YMD >= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_FROM", "BIND05");
					reader.BindValue("BIND05", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_from)));
				}

				// 送信日TOを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_TO", " AND MDIT0020.SOSIN_YMD <= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_TO", "BIND06");
					reader.BindValue("BIND06", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_to)));
				}


				// 今回分のみを設定
				if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Konkai_flg))
				{
					string strKonkai_flg = string.Empty;
					strKonkai_flg = " AND MDIT0020.TANAOROSIKIJUN_YMD = (SELECT MAX(B.TANAOROSIKIJUN_YMD) FROM MDIT0030 B WHERE B.TENCD = '9999') ";
					reader.ReplaceAdd("REPLACE_ID_KONKAI_FLG", strKonkai_flg);
				}

				#endregion

				#region 2

				// 店舗確定状況
				string strTenpo_kakutei_jyokyo2 = string.Empty;
				// 未終了
				if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO3.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo2 = strTenpo_kakutei_jyokyo2 + " AND MDIT0030.TANAOROSISYURYO_FLG = 0 ";
				}
				// 終了確定済み
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO4.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo2 = strTenpo_kakutei_jyokyo2 + " AND MDIT0030.TANAOROSISYURYO_FLG = 1 ";
				}
				// 終了確定済み解除
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO5.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo2 = strTenpo_kakutei_jyokyo2 + " AND MDIT0030.TANAOROSISYURYO_FLG = 9 ";
				}
				// それ以外
				else
				{
					strTenpo_kakutei_jyokyo2 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_TENPO_KAKUTEI_JYOKYO3", strTenpo_kakutei_jyokyo2);


				// 今回分のみを設定
				if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Konkai_flg))
				{
					string strKonkai_flg2 = string.Empty;
					strKonkai_flg2 = " AND MDIT0030.TANAOROSIKIJUN_YMD = (SELECT MAX(B.TANAOROSIKIJUN_YMD) FROM MDIT0030 B WHERE B.TENCD = '9999') ";
					reader.ReplaceAdd("REPLACE_ID_KONKAI_FLG3", strKonkai_flg2);
				}

				#endregion

				#region 3

				// 店舗コードFROMを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_FROM3", " AND MDIT0020.TENCD >= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_FROM3", "BIND31");
					reader.BindValue("BIND31", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_from));
				}

				// 店舗コードTOを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_TO3", " AND MDIT0020.TENCD <= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_TO3", "BIND32");
					reader.BindValue("BIND32", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_to));
				}


				// 店舗確定状況
				string strTenpo_kakutei_jyokyo3 = string.Empty;
				// 未確定
				if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO1.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo3 = strTenpo_kakutei_jyokyo3 + " AND MDIT0020.SOSINIRAI_FLG = 0 ";
				}
				// 確定済
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO2.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo3 = strTenpo_kakutei_jyokyo3 + " AND MDIT0020.SOSINIRAI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strTenpo_kakutei_jyokyo3 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_TENPO_KAKUTEI_JYOKYO3", strTenpo_kakutei_jyokyo3);


				// 送信状態
				string strSosin_jyotai3 = string.Empty;
				// 未送信
				if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI1.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai3 = strSosin_jyotai3 + " AND MDIT0020.SOSINZUMI_FLG = 0 ";
				}
				// 送信済
				else if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI2.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai3 = strSosin_jyotai3 + " AND MDIT0020.SOSINZUMI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strSosin_jyotai3 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_SOSIN_JYOTAI3", strSosin_jyotai3);


				// 送信日FROMを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_FROM3", " AND MDIT0020.SOSIN_YMD >= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_FROM3", "BIND33");
					reader.BindValue("BIND33", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_from)));
				}

				// 送信日TOを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_TO3", " AND MDIT0020.SOSIN_YMD <= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_TO3", "BIND34");
					reader.BindValue("BIND34", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_to)));
				}


				// 今回分のみを設定
				if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Konkai_flg))
				{
					string strKonkai_flg3 = string.Empty;
					strKonkai_flg3 = " AND MDIT0020.TANAOROSIKIJUN_YMD = (SELECT MAX(B.TANAOROSIKIJUN_YMD) FROM MDIT0030 B WHERE B.TENCD = '9999') ";
					reader.ReplaceAdd("REPLACE_ID_KONKAI_FLG3", strKonkai_flg3);
				}

				#endregion

				#region 4

				// 店舗確定状況
				string strTenpo_kakutei_jyokyo4 = string.Empty;
				// 未終了
				if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO3.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo4 = strTenpo_kakutei_jyokyo4 + " AND MDIT0030.TANAOROSISYURYO_FLG = 0 ";
				}
				// 終了確定済み
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO4.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo4 = strTenpo_kakutei_jyokyo4 + " AND MDIT0030.TANAOROSISYURYO_FLG = 1 ";
				}
				// 終了確定済み解除
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO5.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo4 = strTenpo_kakutei_jyokyo4 + " AND MDIT0030.TANAOROSISYURYO_FLG = 9 ";
				}
				// それ以外
				else
				{
					strTenpo_kakutei_jyokyo4 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_TENPO_KAKUTEI_JYOKYO4", strTenpo_kakutei_jyokyo4);


				// 今回分のみを設定
				if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Konkai_flg))
				{
					string strKonkai_flg4 = string.Empty;
					strKonkai_flg4 = " AND MDIT0030.TANAOROSIKIJUN_YMD = (SELECT MAX(B.TANAOROSIKIJUN_YMD) FROM MDIT0030 B WHERE B.TENCD = '9999') ";
					reader.ReplaceAdd("REPLACE_ID_KONKAI_FLG4", strKonkai_flg4);
				}

				#endregion

				#region 5

				// 店舗コードFROMを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_FROM5", " AND MDIT0020.TENCD >= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_FROM5", "BIND51");
					reader.BindValue("BIND51", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_from));
				}

				// 店舗コードTOを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_TO5", " AND MDIT0020.TENCD <= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_TO5", "BIND52");
					reader.BindValue("BIND52", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_to));
				}


				// 店舗確定状況
				string strTenpo_kakutei_jyokyo5 = string.Empty;
				// 未確定
				if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO1.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo5 = strTenpo_kakutei_jyokyo5 + " AND MDIT0020.SOSINIRAI_FLG = 0 ";
				}
				// 確定済
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO2.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo5 = strTenpo_kakutei_jyokyo5 + " AND MDIT0020.SOSINIRAI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strTenpo_kakutei_jyokyo5 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_TENPO_KAKUTEI_JYOKYO5", strTenpo_kakutei_jyokyo5);


				// 送信状態
				string strSosin_jyotai5 = string.Empty;
				// 未送信
				if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI1.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai5 = strSosin_jyotai5 + " AND MDIT0020.SOSINZUMI_FLG = 0 ";
				}
				// 送信済
				else if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI2.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai5 = strSosin_jyotai5 + " AND MDIT0020.SOSINZUMI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strSosin_jyotai5 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_SOSIN_JYOTAI5", strSosin_jyotai5);


				// HHT実施日FROMを設定
				if (!string.IsNullOrEmpty(formVO.Hhtjissi_ymd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_HHTJISSI_YMD_FROM5", " AND MDIT0010.ADD_YMD >= ");
					reader.ReplaceAddBind("REPLACE_ID_HHTJISSI_YMD_FROM5", "BIND53");
					reader.BindValue("BIND53", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Hhtjissi_ymd_from)));
				}

				// HHT実施日TOを設定
				if (!string.IsNullOrEmpty(formVO.Hhtjissi_ymd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_HHTJISSI_YMD_TO5", " AND MDIT0010.ADD_YMD <= ");
					reader.ReplaceAddBind("REPLACE_ID_HHTJISSI_YMD_TO5", "BIND54");
					reader.BindValue("BIND54", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Hhtjissi_ymd_to)));
				}


				// 送信日FROMを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_FROM5", " AND MDIT0020.SOSIN_YMD >= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_FROM5", "BIND55");
					reader.BindValue("BIND55", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_from)));
				}

				// 送信日TOを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_TO5", " AND MDIT0020.SOSIN_YMD <= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_TO5", "BIND56");
					reader.BindValue("BIND56", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_to)));
				}


				// 今回分のみを設定
				if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Konkai_flg))
				{
					string strKonkai_flg5 = string.Empty;
					strKonkai_flg5 = " AND MDIT0020.TANAOROSIKIJUN_YMD = (SELECT MAX(B.TANAOROSIKIJUN_YMD) FROM MDIT0030 B WHERE B.TENCD = '9999') ";
					reader.ReplaceAdd("REPLACE_ID_KONKAI_FLG5", strKonkai_flg5);
				}

				#endregion
			}
			// 終了確認照会
			else if (BoSystemConstant.MODE_SYURYOKAKUNINREF.Equals(BoSystemString.Nvl(formVO.Modeno)))
			{
				#region 1

				// 店舗コードFROMを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_FROM", " AND MDIT0020.TENCD >= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_FROM", "BIND01");
					reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_from));
				}

				// 店舗コードTOを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_TO", " AND MDIT0020.TENCD <= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_TO", "BIND02");
					reader.BindValue("BIND02", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_to));
				}


				// 店舗確定状況
				string strTenpo_kakutei_jyokyo = string.Empty;
				// 未確定
				if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO1.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo = " AND MDIT0020.SOSINIRAI_FLG = 0 ";
				}
				// 確定済
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO2.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo = " AND MDIT0020.SOSINIRAI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strTenpo_kakutei_jyokyo = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_TENPO_KAKUTEI_JYOKYO", strTenpo_kakutei_jyokyo);


				// 送信状態
				string strSosin_jyotai = string.Empty;
				// 未送信
				if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI1.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai = " AND MDIT0020.SOSINZUMI_FLG = 0 ";
				}
				// 送信済
				else if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI2.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai = " AND MDIT0020.SOSINZUMI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strSosin_jyotai = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_SOSIN_JYOTAI", strSosin_jyotai);


				// 送信日FROMを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_FROM", " AND MDIT0020.SOSIN_YMD >= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_FROM", "BIND03");
					reader.BindValue("BIND03", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_from)));
				}

				// 送信日TOを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_TO", " AND MDIT0020.SOSIN_YMD <= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_TO", "BIND04");
					reader.BindValue("BIND04", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_to)));
				}


				// 今回分のみを設定
				if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Konkai_flg))
				{
					string strKonkai_flg = string.Empty;
					strKonkai_flg = " AND MDIT0020.TANAOROSIKIJUN_YMD = (SELECT MAX(B.TANAOROSIKIJUN_YMD) FROM MDIT0030 B WHERE B.TENCD = '9999') ";
					reader.ReplaceAdd("REPLACE_ID_KONKAI_FLG", strKonkai_flg);
				}

				#endregion

				#region 2

				// 店舗確定状況
				string strTenpo_kakutei_jyokyo2 = string.Empty;
				// 未終了
				if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO3.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo2 = " AND MDIT0030.TANAOROSISYURYO_FLG = 0 ";
				}
				// 終了確定済み
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO4.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo2 = " AND MDIT0030.TANAOROSISYURYO_FLG = 1 ";
				}
				// 終了確定済み解除
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO5.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo2 = " AND MDIT0030.TANAOROSISYURYO_FLG = 9 ";
				}
				// それ以外
				else
				{
					strTenpo_kakutei_jyokyo2 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_TENPO_KAKUTEI_JYOKYO2", strTenpo_kakutei_jyokyo2);


				// 今回分のみを設定
				if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Konkai_flg))
				{
					string strKonkai_flg2 = string.Empty;
					strKonkai_flg2 = " AND MDIT0030.TANAOROSIKIJUN_YMD = (SELECT MAX(B.TANAOROSIKIJUN_YMD) FROM MDIT0030 B WHERE B.TENCD = '9999') ";
					reader.ReplaceAdd("REPLACE_ID_KONKAI_FLG2", strKonkai_flg2);
				}

				#endregion

				#region 3

				// 店舗コードFROMを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_FROM3", " AND MDIT0020.TENCD >= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_FROM3", "BIND31");
					reader.BindValue("BIND31", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_from));
				}

				// 店舗コードTOを設定
				if (!string.IsNullOrEmpty(formVO.Tenpo_cd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_TENPO_CD_TO3", " AND MDIT0020.TENCD <= ");
					reader.ReplaceAddBind("REPLACE_ID_TENPO_CD_TO3", "BIND32");
					reader.BindValue("BIND32", BoSystemFormat.formatTenpoCd(formVO.Tenpo_cd_to));
				}


				// 店舗確定状況
				string strTenpo_kakutei_jyokyo3 = string.Empty;
				// 未確定
				if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO1.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo3 = " AND MDIT0020.SOSINIRAI_FLG = 0 ";
				}
				// 確定済
				else if (ConditionTenpo_kakutei_jokyo.VALUE_TENPO_KAKUTEI_JOKYO2.Equals(formVO.Tenpo_kakutei_jyokyo))
				{
					strTenpo_kakutei_jyokyo3 = " AND MDIT0020.SOSINIRAI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strTenpo_kakutei_jyokyo3 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_TENPO_KAKUTEI_JYOKYO3", strTenpo_kakutei_jyokyo3);


				// 送信状態
				string strSosin_jyotai3 = string.Empty;
				// 未送信
				if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI1.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai3 = " AND MDIT0020.SOSINZUMI_FLG = 0 ";
				}
				// 送信済
				else if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI2.Equals(formVO.Sosin_jyotai))
				{
					strSosin_jyotai3 = " AND MDIT0020.SOSINZUMI_FLG = 1 ";
				}
				// それ以外
				else
				{
					strSosin_jyotai3 = string.Empty;
				}
				reader.ReplaceAdd("REPLACE_ID_SOSIN_JYOTAI", strSosin_jyotai3);

				// 送信日FROMを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_FROM3", " AND MDIT0020.SOSIN_YMD >= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_FROM3", "BIND35");
					reader.BindValue("BIND35", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_from)));
				}

				// 送信日TOを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_kak_ymd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_TO3", " AND MDIT0020.SOSIN_YMD <= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_TO3", "BIND36");
					reader.BindValue("BIND36", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_kak_ymd_to)));
				}


				// 今回分のみを設定
				if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Konkai_flg))
				{
					string strKonkai_flg3 = string.Empty;
					strKonkai_flg3 = " AND MDIT0020.TANAOROSIKIJUN_YMD = (SELECT MAX(B.TANAOROSIKIJUN_YMD) FROM MDIT0030 B WHERE B.TENCD = '9999') ";
					reader.ReplaceAdd("REPLACE_ID_KONKAI_FLG3", strKonkai_flg3);
				}

				#endregion
			}

		}
		#endregion

		#region ソート条件設定
		/// <summary>
		/// ReplaceOrderbyPart ソート条件設定
		/// </summary>
		/// <param name="formVO">Tj070f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
		private void ReplaceOrderbyPart(Tj070f01Form formVO, FindSqlResultTable reader)
		{

			string strOrderby = string.Empty;

			strOrderby = strOrderby + " ORDER BY ";

			// 店舗コード順
			if (ConditionMeisai_sort_tj070f01.VALUE_MEISAI_SORT_TJ070F011.Equals(formVO.Meisai_sort))
			{
				strOrderby = strOrderby + "  TENCD ";
				strOrderby = strOrderby + " ,TANAOROSIKIJUN_YMD ";
				strOrderby = strOrderby + " ,DECODE(ADD_YMD,0,99999999,ADD_YMD) ";
				strOrderby = strOrderby + " ,ADD_YMD ";
				strOrderby = strOrderby + " ,DECODE(SOSIN_YMD,0,99999999,SOSIN_YMD) ";
				strOrderby = strOrderby + " ,SORTFLG ";
			}
			// HHT実施日順
			else
			{
				strOrderby = strOrderby + "  DECODE(ADD_YMD,0,99999999,ADD_YMD) ";
				strOrderby = strOrderby + " ,ADD_YMD ";
				strOrderby = strOrderby + " ,TENCD ";
				strOrderby = strOrderby + " ,TANAOROSIKIJUN_YMD ";
				strOrderby = strOrderby + " ,SORTFLG ";
			}

			reader.ReplaceAdd("REPLACE_ORDER_BY", strOrderby);

		}
		#endregion
	}
}
