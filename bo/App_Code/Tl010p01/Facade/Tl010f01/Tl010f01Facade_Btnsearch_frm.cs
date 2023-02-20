using com.xebio.bo.Tl010p01.Constant;
using com.xebio.bo.Tl010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
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

namespace com.xebio.bo.Tl010p01.Facade
{
  /// <summary>
  /// Tl010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl010f01Facade : StandardBaseFacade
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
				Tl010f01Form formVO = (Tl010f01Form)facadeContext.FormVO;
				IDataList m1List = formVO.GetList("M1");

				// 営業日の取得
				SysDateVO sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				#region 初期化

				// ディクショナリのクリア
				formVO.Dictionary.Clear();

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				#region 1. 単項目チェック

				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
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

				// 1-2 旧自社品番
				//       発注MSTを検索し、存在しない場合エラー
				formVO.Dictionary[Tl010p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Old_jisya_hbn,	// 旧自社品番
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });
					if (hs != null)
					{
						// 自社品番をディクショナリに退避
						formVO.Dictionary[Tl010p01Constant.DIC_SEARCH_XEBIOCD] = (string)hs["XEBIO_CD"];
					}
				}


				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 2. 関連チェック

				// 2-1 部門コードFROM、部門コードTO
				//       部門コードＦＲＯＭ > 部門コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(formVO.Bumon_cd_from) &&
					!string.IsNullOrEmpty(formVO.Bumon_cd_to))
				{
					V03002Check.CodeFromToChk(formVO.Bumon_cd_from,
											  formVO.Bumon_cd_to,
											  facadeContext,
											  "部門",
											  new[] { "Bumon_cd_from", "Bumon_cd_to" }
											 );
				}

				// 2-2 売変開始日FROM、売変開始日TO
				//       売変開始日FROM > 売変開始日TOの場合エラー
				if (!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from) &&
					!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
				{
					V03001Check.DateFromToChk(formVO.Baihenkaisi_ymd_from,
											  formVO.Baihenkaisi_ymd_to,
											  facadeContext,
											  "開始日",
											  new[] { "Baihenkaisi_ymd_from", "Baihenkaisi_ymd_to" }
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

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tl010p01Constant.SQL_ID_01, facadeContext.DBContext);
				// 検索条件設定
				ReplaceWherePart(formVO, rtChk, sysDateVO, "1");

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

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tl010p01Constant.SQL_ID_02, facadeContext.DBContext);
				// 検索条件設定
				ReplaceWherePart(formVO, rtSeach, sysDateVO, "2");

				#region SQL実行

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
                    iCnt++;
					Tl010f01M1Form m1formVO = new Tl010f01M1Form();

					// Ｍ１行NO
					m1formVO.M1rowno = iCnt.ToString();

					// Ｍ１売変開始日
					if (!"0".Equals(rec["BAIHENKAISI_YMD"].ToString()))
					{
						m1formVO.M1baihenkaisi_ymd = rec["BAIHENKAISI_YMD"].ToString();
					}
					else
					{
						m1formVO.M1baihenkaisi_ymd = string.Empty;
					}
					// Ｍ１品番数
					m1formVO.M1hinban_su = rec["HINBAN_SU"].ToString();
					// Ｍ１在庫数
					m1formVO.M1zaiko_su = rec["ZAIKO_SU"].ToString();

					// Ｍ１選択フラグ(隠し)
					m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					// Dictionary保存
					// Ｍ１部門コード
					m1formVO.Dictionary.Add(Tl010p01Constant.DIC_M1BUMON_CD, rec["BUMON_CD"].ToString());
					// Ｍ１部門名
					m1formVO.Dictionary.Add(Tl010p01Constant.DIC_M1BUMON_NM, rec["BUMONKANA_NM"].ToString());
					m1formVO.Dictionary.Add(Tl010p01Constant.DIC_M1BUMON_NM_MEISAI, rec["BUMON_NM"].ToString());

					// Ｍ１売変NO
					m1formVO.Dictionary.Add(Tl010p01Constant.DIC_M1BAIHEN_NO, rec["BAIHEN_NO"].ToString());
					// Ｍ１申請コメント
					m1formVO.Dictionary.Add(Tl010p01Constant.DIC_M1SINSEICOMMENT_NM, rec["SINSEICOMMENT_NM"].ToString());
					// Ｍ１開始状態
					m1formVO.Dictionary.Add(Tl010p01Constant.DIC_M1KAISISTATE, rec["KAISISTATE"].ToString());
					// Ｍ１開始状態名
					m1formVO.Dictionary.Add(Tl010p01Constant.DIC_M1KAISISTATE_NM, rec["KAISISTATE_NM"].ToString());


					//リストオブジェクトにM1Formを追加します。
					m1List.Add(m1formVO, true);
				}

				#region カード部

				// [出力シール]の名称取得
				if (formVO.Dictionary[Tl010p01Constant.DIC_SYUTSURYOKU_SEAL] == null)
				{
					CalcTaxCls tax = new CalcTaxCls();
					formVO.Dictionary.Add(Tl010p01Constant.DIC_SYUTSURYOKU_SEAL, tax.GetTaxDispControlInfo(facadeContext));
				}

				#endregion

				// 検索件数の設定
				formVO.Searchcnt = m1List.Count.ToString();

				#endregion

				#endregion

				#region Dictionary保存（カード部）

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(formVO);

				// 出力シールラジオボタンに"8%"を設定
				formVO.Shuturyoku_seal = Tl010p01Constant.ZEI_KBN_8;

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
		/// <param name="formVO">Tl010f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="sysDateVO">SysDateVO</param>
		/// <param name="mode">String</param>
		/// <returns></returns>
		private void ReplaceWherePart(Tl010f01Form formVO, FindSqlResultTable reader, SysDateVO sysDateVO, String mode)
        {

			// 店舗コードを設定
			reader.ReplaceAdd("REPLACE_ID_TENPO_CD", " AND MDCT0010.TENPO_CD = ");
			reader.ReplaceAddBind("REPLACE_ID_TENPO_CD", "BIND01");
			reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));


			// 開始状態
			string strKaishiJyotai = string.Empty;
			// 開始済
			if (ConditionKaishi_jyotai.VALUE_KAISHI_JYOTAI1.Equals(formVO.Kaishi_jyotai))
			{
				strKaishiJyotai = " AND MDCT0010.BAIHENKAISI_YMD <= ";
					//+ sysDateVO.Sysdate.ToString();
			}
			// 開始予定
			else if (ConditionKaishi_jyotai.VALUE_KAISHI_JYOTAI2.Equals(formVO.Kaishi_jyotai))
			{
				strKaishiJyotai = " AND MDCT0010.BAIHENKAISI_YMD > ";
					//+ sysDateVO.Sysdate.ToString();
			}
			else
			{
			}
			reader.ReplaceAdd("REPLACE_ID_KAISHI_JYOTAI", strKaishiJyotai);
			reader.ReplaceAddBind("REPLACE_ID_KAISHI_JYOTAI", "BIND_SYSDATE");
			reader.BindValue("BIND_SYSDATE", sysDateVO.Sysdate);

			// 部門コードFROM-TO
			string strBumoncd = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Bumon_cd_from) ||
				!string.IsNullOrEmpty(formVO.Bumon_cd_to))
			{
				string strBumoncd_from = string.Empty;
				string strBumoncd_to   = string.Empty;

				// 部門コードFROM
				if (string.IsNullOrEmpty(formVO.Bumon_cd_from))
				{
					strBumoncd_from = "000";
				}
				else
				{
					strBumoncd_from = BoSystemFormat.formatBumonCd(formVO.Bumon_cd_from);
				}

				// 部門コードTO
				if (string.IsNullOrEmpty(formVO.Bumon_cd_to))
				{
					strBumoncd_to = "999";
				}
				else
				{
					strBumoncd_to = BoSystemFormat.formatBumonCd(formVO.Bumon_cd_to);
				}
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD", " AND MDCT0010.BUMON_CD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD", "BIND_BUMON_CD_FROM");
				reader.BindValue("BIND_BUMON_CD_FROM", strBumoncd_from);
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD", "BIND_BUMON_CD_TO");
				reader.BindValue("BIND_BUMON_CD_TO", strBumoncd_to);
			}
			else
			{
			}

			// 売変開始日FROM-TO
			if (!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from) ||
				!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
			{
				decimal strBaihenkaisiymd_from = 0;
				decimal strBaihenkaisiymd_to = 99999999;

				// 売変開始日FROM
				if (!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from))
				{
					strBaihenkaisiymd_from = decimal.Parse(BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_from));
				}

				// 売変開始日TO
				if (!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
				
				{
					strBaihenkaisiymd_to = decimal.Parse(BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_to));
				}

				reader.ReplaceAdd("REPLACE_ID_BAIHENKAISI_YMD", " AND MDCT0010.BAIHENKAISI_YMD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_BAIHENKAISI_YMD", "BIND_BAIHEN_KAISI_FROM");
				reader.BindValue("BIND_BAIHEN_KAISI_FROM", strBaihenkaisiymd_from);
				reader.ReplaceAdd("REPLACE_ID_BAIHENKAISI_YMD", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_BAIHENKAISI_YMD", "BIND_BAIHEN_KAISI_TO");
				reader.BindValue("BIND_BAIHEN_KAISI_TO", strBaihenkaisiymd_to);
			}
			else
			{
			}

			// 自社品番
			string strJisyahbn = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn))
			{
				strJisyahbn = strJisyahbn + " AND EXISTS ( ";
				strJisyahbn = strJisyahbn + " SELECT 1 ";
				strJisyahbn = strJisyahbn + " FROM MDCT0010 TBL_1 ";
				strJisyahbn = strJisyahbn + " WHERE TBL_1.TENPO_CD        = MDCT0010.TENPO_CD ";
				strJisyahbn = strJisyahbn + " AND   TBL_1.BAIHENKAISI_YMD = MDCT0010.BAIHENKAISI_YMD ";
				strJisyahbn = strJisyahbn + " AND   TBL_1.BUMON_CD        = MDCT0010.BUMON_CD ";
				strJisyahbn = strJisyahbn + " AND	TBL_1.JISYA_HBN		  = ";

				//if (formVO.Old_jisya_hbn.Length == 10)
				//{
				//	strJisyahbn = strJisyahbn + " AND (TBL_1.JISYA_HBN,TBL_1.IRO_CD) IN ( ";
				//	strJisyahbn = strJisyahbn + "        SELECT MDMT0130.XEBIO_CD, MAKERCOLOR_CD ";
				//	strJisyahbn = strJisyahbn + "        FROM   MDMT0130 ";
				//	strJisyahbn = strJisyahbn + "        WHERE  MDMT0130.OLD_XEBIO_CD = '" + formVO.Old_jisya_hbn + "'";
				//	strJisyahbn = strJisyahbn + " ) ";
				//}
				//else
				//{
				//strJisyahbn = strJisyahbn + " AND TBL_1.JISYA_HBN = '" + formVO.Dictionary[Tl010p01Constant.DIC_SEARCH_XEBIOCD] + "'";
				//}
				//strJisyahbn = strJisyahbn + " ) ";
		
				reader.ReplaceAdd("REPLACE_ID_JISYA_HBN", strJisyahbn);
				reader.ReplaceAddBind("REPLACE_ID_JISYA_HBN", "BIND_XEBIOCD");
				reader.BindValue("BIND_XEBIOCD", formVO.Dictionary[Tl010p01Constant.DIC_SEARCH_XEBIOCD]);
				reader.ReplaceAdd("REPLACE_ID_JISYA_HBN", " ) ");
			}
			// 件数チェック
			if ("1".Equals(mode))
			{
				// バインド値の置き換え
				// 店舗コード
				reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
			}
			// 検索
			else
			{
				// バインド値の置き換え
				// 店舗コード
				reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
				// 開始状態
				reader.BindValue("BIND_KAISISTATE", formVO.Kaishi_jyotai);
				reader.BindValue("BIND_KAISISTATE2", formVO.Kaishi_jyotai);
			}

		}
		#endregion
	}
}
