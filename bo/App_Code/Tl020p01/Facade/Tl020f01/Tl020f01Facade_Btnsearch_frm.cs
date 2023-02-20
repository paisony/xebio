using com.xebio.bo.Tl020p01.Constant;
using com.xebio.bo.Tl020p01.Formvo;
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
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01005;
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

namespace com.xebio.bo.Tl020p01.Facade
{
  /// <summary>
  /// Tl020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl020f01Facade : StandardBaseFacade
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
				Tl020f01Form formVO = (Tl020f01Form)facadeContext.FormVO;
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
				formVO.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
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
						formVO.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD] = (string)hs["XEBIO_CD"];
					}
				}

				// 1-3 登録確定者コード
				//       担当者MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(formVO.Torokukak_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(formVO.Torokukak_cd
													, facadeContext
													, string.Empty
													, null
													, "登録確定者"
													, new[] { "Torokukak_cd" }
													, null
													, null
													, null
													, 0
													, 0
													);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						formVO.Torokukak_nm = (string)resultHash["HANBAIIN_NM"];
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

				// 2-2 売変指示ＮｏFROM、売変指示ＮｏTO
				//       売変指示ＮｏＦＲＯＭ > 売変指示ＮｏＴＯの場合エラー
				if (!string.IsNullOrEmpty(formVO.Baihen_shiji_no_from) &&
					!string.IsNullOrEmpty(formVO.Baihen_shiji_no_to))
				{
					V03002Check.CodeFromToChk(formVO.Baihen_shiji_no_from,
											  formVO.Baihen_shiji_no_to,
											  facadeContext,
											  "売変指示No",
											  new[] { "Baihen_shiji_no_from", "Baihen_shiji_no_to" }
											 );
				}

				// 2-3 売変作業開始日FROM、売変作業開始日TO
				//       売変作業開始日FROM > 売変作業開始日TOの場合エラー
				if (!string.IsNullOrEmpty(formVO.Baihensagyokaisi_ymd_from) &&
					!string.IsNullOrEmpty(formVO.Baihensagyokaisi_ymd_to))
				{
					V03001Check.DateFromToChk(formVO.Baihensagyokaisi_ymd_from,
											  formVO.Baihensagyokaisi_ymd_to,
											  facadeContext,
											  "作業開始日",
											  new[] { "Baihensagyokaisi_ymd_from", "Baihensagyokaisi_ymd_to" }
											 );
				}

				// 2-4 売変開始日FROM、売変開始日TO
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

				// 2-5 確定日FROM、確定日TO
				//       確定日FROM > 確定日TOの場合エラー
				if (!string.IsNullOrEmpty(formVO.Kakutei_ymd_from) &&
					!string.IsNullOrEmpty(formVO.Kakutei_ymd_to))
				{
					V03001Check.DateFromToChk(formVO.Kakutei_ymd_from,
											  formVO.Kakutei_ymd_to,
											  facadeContext,
											  "確定日",
											  new[] { "Kakutei_ymd_from", "Kakutei_ymd_to" }
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

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tl020p01Constant.SQL_ID_01, facadeContext.DBContext);
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

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tl020p01Constant.SQL_ID_02, facadeContext.DBContext);
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
					Tl020f01M1Form m1formVO = new Tl020f01M1Form();

					// Ｍ１行NO
					m1formVO.M1rowno = iCnt.ToString();

					// Ｍ１申請元名称
					m1formVO.M1shinseimoto_nm = rec["SINSEIMOTO_NM"].ToString();
					// Ｍ１申請担当者名称
					m1formVO.M1sinseitan_nm = rec["SINSEITAN_NM"].ToString();

					// 申請元が店舗の場合非表示

					// Ｍ１売変指示Ｎｏ
					if (rec["SINSEIMOTO_KBN"].ToString().Equals(ConditionSinseimoto.VALUE_SINSEIMOTO2))
					{
						m1formVO.M1baihen_shiji_no = string.Empty;
					}
					else
					{
						m1formVO.M1baihen_shiji_no = BoSystemFormat.formatBaihen_shiji_no(rec["BAIHEN_NO"].ToString());
					}

					// Ｍ１売変作業開始日
					// ALL9の場合に非表示とする
					if ("99999999".Equals(rec["BAIHENSAGYOKAISI_YMD"].ToString()))
					{
						m1formVO.M1baihensagyokaisi_ymd = string.Empty;
					}
					else if (!"0".Equals(rec["BAIHENSAGYOKAISI_YMD"].ToString()))
					{
						m1formVO.M1baihensagyokaisi_ymd = rec["BAIHENSAGYOKAISI_YMD"].ToString();
					}
					else
					{
						m1formVO.M1baihensagyokaisi_ymd = string.Empty;
					}
					// Ｍ１売変開始日
					if (!"0".Equals(rec["BAIHENKAISI_YMD"].ToString()))
					{
						m1formVO.M1baihenkaisi_ymd = rec["BAIHENKAISI_YMD"].ToString();
					}
					else
					{
						m1formVO.M1baihenkaisi_ymd = string.Empty;
					}
					// Ｍ１売変理由名称
					m1formVO.M1baihen_riyu_nm = rec["BAIHEN_RIYTU_NM"].ToString();

					// Ｍ１品番数
					m1formVO.M1hinban_su = rec["HINBAN_SU"].ToString();
					// Ｍ１在庫数
					m1formVO.M1zaiko_su = rec["ZAIKO_SU"].ToString();

					// Ｍ１登録確定者名称
					m1formVO.M1torokukak_nm = rec["ADDTAN_NM"].ToString();

					// Ｍ１選択フラグ(隠し)
					m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					// Ｍ１明細色区分(隠し)
					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;
					}
					// Dictionary保存
					// Ｍ１部門コード
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1BUMON_CD, rec["BUMON_CD"].ToString());
					// Ｍ１部門名
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1BUMON_NM, rec["BUMONKANA_NM"].ToString());
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1BUMON_NM_MEISAI, rec["BUMON_NM"].ToString());

					// Ｍ１申請元区分
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1SINSEIMOTO_KBN, rec["SINSEIMOTO_KBN"].ToString());
					// Ｍ１申請担当者コード
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1SINSEITAN_CD, rec["SINSEITAN_CD"].ToString());
					// Ｍ１登録確定者コード
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1TOROKUKAK_CD, rec["KAKUTEITAN_CD"].ToString());
					// Ｍ１申請コメント
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1SINSEICOMMENT_NM, rec["SINSEICOMMENT_NM"].ToString());
					// Ｍ１売変理由コード
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1BAIHEN_RIYTU, rec["BAIHEN_RIYTU"].ToString());
					// Ｍ１売変指示Ｎｏ
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1BAIHEN_NO, BoSystemFormat.formatBaihen_shiji_no(rec["BAIHEN_NO"].ToString()));
					// Ｍ１作業開始日
					m1formVO.Dictionary.Add(Tl020p01Constant.DIC_M1BAIHENSAGYOKAISI_YMD, rec["BAIHENSAGYOKAISI_YMD"].ToString());

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(m1formVO, true);
				}

				// 検索件数の設定
				formVO.Searchcnt = m1List.Count.ToString();

				#endregion

				#endregion

				#region Dictionary保存（カード部）

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(formVO);
				// [出力シール]の名称取得
				if (formVO.Dictionary[Tl020p01Constant.DIC_SYUTSURYOKU_SEAL] == null)
				{
					CalcTaxCls tax = new CalcTaxCls();
					formVO.Dictionary.Add(Tl020p01Constant.DIC_SYUTSURYOKU_SEAL, tax.GetTaxDispControlInfo(facadeContext));
				}
				#endregion

			}
			catch (System.Exception ex)
			{
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
		/// <param name="formVO">Tl020f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="sysDateVO">SysDateVO</param>
		/// <param name="mode">String</param>
		/// <returns></returns>
		private void ReplaceWherePart(Tl020f01Form formVO, FindSqlResultTable reader, SysDateVO sysDateVO, String mode)
		{
			// 参照テーブルの設定
			// 確定状態と申請元により、参照テーブルを制御する
			string tbl_flg = string.Empty;
			// 確定状態：確定
			if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI1.Equals(formVO.Kakutei_jyotai))
			{
				// 申請元
				switch (formVO.Sinseimoto)
				{
					case ConditionSinseimoto.VALUE_SINSEIMOTO1:		// 本部
						tbl_flg = "2";	// MDCT0010
						break;
					case ConditionSinseimoto.VALUE_SINSEIMOTO2:		// 店舗
						tbl_flg = "1";	// MDCT0030
						break;
					default:										// 空白
						tbl_flg = "3";	// MDCT0030
						break;
				}
			}
			// 確定状態：未確定
			else
			{
				// 申請元
				switch (formVO.Sinseimoto)
				{
					case ConditionSinseimoto.VALUE_SINSEIMOTO1:		// 本部
						tbl_flg = "2";	// MDCT0010
						break;
					case ConditionSinseimoto.VALUE_SINSEIMOTO2:		// 店舗
						tbl_flg = "0";	// MDCT0020
						break;
					default:										// 空白
						tbl_flg = "4";	// MDCT0020
						break;
				}
			}


			//// 現売価<>指示売価 Or 現売価＝指示売価
			//// 【0】現売価＝指示売価以外【1】現売価＝指示売価対応のみ
			//string Baikaequal_flg = "0";

			//// 確定状態：確定 かつ 申請元：本部の場合、 Baikaequal_flgに[1]を設定
			//if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI1.Equals(formVO.Kakutei_jyotai) &&
			//	ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(formVO.Sinseimoto))
			//{
			//	Baikaequal_flg = "1";
			//}

			#region 予定データ

			// 条件有無を設定
			string strJyouken1 = string.Empty;
			if ("0".Equals(tbl_flg) || "4".Equals(tbl_flg))
			{
				strJyouken1 = " AND 0=0 ";
			}
			else
			{
				strJyouken1 = " AND 0=1 ";
			}
			reader.ReplaceAdd("REPLACE_ID_JYOUKEN_UMU1", strJyouken1);


			// 店舗コードを設定
			reader.ReplaceAdd("REPLACE_ID_TENPO_CD1", " AND MDCT0020.TENPO_CD = ");
			reader.ReplaceAddBind("REPLACE_ID_TENPO_CD1", "BIND01");
			reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

			reader.BindValue("BIND_TENPO_CD1", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

			if ("2".Equals(mode))
			{
				reader.BindValue("BIND_TENPO_CD11", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
				reader.BindValue("BIND_TENPO_CD12", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
				reader.BindValue("BIND_TENPO_CD13", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
			}

			// 部門コードFROM-TO
			string strBumoncd1 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Bumon_cd_from) ||
				!string.IsNullOrEmpty(formVO.Bumon_cd_to))
			{
				string strBumoncd_from1 = string.Empty;
				string strBumoncd_to1 = string.Empty;

				// 部門コードFROM
				if (string.IsNullOrEmpty(formVO.Bumon_cd_from))
				{
					strBumoncd_from1 = "000";
				}
				else
				{
					strBumoncd_from1 = BoSystemFormat.formatBumonCd(formVO.Bumon_cd_from);
				}

				// 部門コードTO
				if (string.IsNullOrEmpty(formVO.Bumon_cd_to))
				{
					strBumoncd_to1 = "999";
				}
				else
				{
					strBumoncd_to1 = BoSystemFormat.formatBumonCd(formVO.Bumon_cd_to);
				}

				//strBumoncd1 = " AND MDCT0020.BUMON_CD BETWEEN '" + strBumoncd_from1 + "' AND '" + strBumoncd_to1 + "'";
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD1", " AND MDCT0020.BUMON_CD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD1", "BIND_BUMON_CD_FROM1");
				reader.BindValue("BIND_BUMON_CD_FROM1", strBumoncd_from1);
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD1", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD1", "BIND_BUMON_CD_TO1");
				reader.BindValue("BIND_BUMON_CD_TO1", strBumoncd_to1);
			}
			else
			{
				strBumoncd1 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_BUMON_CD1", strBumoncd1);


			// 売変指示NoFROM-TO
			string strBaihenshijino1 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Baihen_shiji_no_from) ||
				!string.IsNullOrEmpty(formVO.Baihen_shiji_no_to))
			{
				string strBaihenshijino_from1 = string.Empty;
				string strBaihenshijino_to1 = string.Empty;

				// 売変指示NoFROM
				if (string.IsNullOrEmpty(formVO.Baihen_shiji_no_from))
				{
					strBaihenshijino_from1 = "000000000000000000000000";
				}
				else
				{
					strBaihenshijino_from1 = BoSystemString.RightB(BoSystemFormat.formatBaihen_shiji_no(formVO.Baihen_shiji_no_from), 10);
				}

				// 売変指示NoTO
				if (string.IsNullOrEmpty(formVO.Baihen_shiji_no_to))
				{
					strBaihenshijino_to1 = "999999999999999999999999";
				}
				else
				{
					strBaihenshijino_to1 = BoSystemString.RightB(BoSystemFormat.formatBaihen_shiji_no(formVO.Baihen_shiji_no_to), 10);
				}

				//strBaihenshijino1 = " AND MDCT0020.BAIHEN_NO BETWEEN '" + strBaihenshijino_from1 + "' AND '" + strBaihenshijino_to1 + "'";
				reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO1", " AND MDCT0020.BAIHEN_NO BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_BAIHENSIJI_NO1", "BIND_BAIHEN_NO_FROM1");
				reader.BindValue("BIND_BAIHEN_NO_FROM1", strBaihenshijino_from1);
				reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO1", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_BAIHENSIJI_NO1", "BIND_BAIHEN_NO_TO1");
				reader.BindValue("BIND_BAIHEN_NO_TO1", strBaihenshijino_to1);
			}
			else
			{
				strBaihenshijino1 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO1", strBaihenshijino1);


			// 作業開始日FROM-TO
			// 売価変更指示TBLの場合のみ参照
			string strBaihensagyokaisiymd1 = string.Empty;
			reader.ReplaceAdd("REPLACE_ID_SAGYOKAISI_YMD1", strBaihensagyokaisiymd1);

			// 開始日FROM-TO
			string strBaihenkaisiymd1 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from) ||
				!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
			{
				string strBaihenkaisiymd_from1 = string.Empty;
				string strBaihenkaisiymd_to1 = string.Empty;

				// 売変開始日FROM
				if (string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from))
				{
					strBaihenkaisiymd_from1 = "0";
				}
				else
				{
					strBaihenkaisiymd_from1 = BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_from);
				}

				// 売変開始日TO
				if (string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
				{
					strBaihenkaisiymd_to1 = "99999999";
				}
				else
				{
					strBaihenkaisiymd_to1 = BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_to);
				}

				//				//strBaihenkaisiymd1 = " AND MDCT0020.BAIHENKAISI_YMD BETWEEN " + strBaihenkaisiymd_from1 + " AND " + strBaihenkaisiymd_to1;
				reader.ReplaceAdd("REPLACE_ID_KAISI_YMD1", " AND MDCT0020.BAIHENKAISI_YMD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_KAISI_YMD1", "BIND_BAIHENKAISI_YMD_FROM1");
				reader.BindValue("BIND_BAIHENKAISI_YMD_FROM1", decimal.Parse(strBaihenkaisiymd_from1));
				reader.ReplaceAdd("REPLACE_ID_KAISI_YMD1", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_KAISI_YMD1", "BIND_BAIHENKAISI_YMD_TO1");
				reader.BindValue("BIND_BAIHENKAISI_YMD_TO1", decimal.Parse(strBaihenkaisiymd_to1));
			}
			else
			{
				strBaihenkaisiymd1 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_KAISI_YMD1", strBaihenkaisiymd1);

			// 確定日FROM-TO
			// 確定状態：確定の場合のみ検索条件とする
			string strKakuteiymd1 = string.Empty;
			if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI1.Equals(formVO.Kakutei_jyotai))
			{
				if (!string.IsNullOrEmpty(formVO.Kakutei_ymd_from) ||
					!string.IsNullOrEmpty(formVO.Kakutei_ymd_to))
				{
					string strKakuteiymd_from1 = string.Empty;
					string strKakuteiymd_to1 = string.Empty;

					// 売変開始日FROM
					if (string.IsNullOrEmpty(formVO.Kakutei_ymd_from))
					{
						strKakuteiymd_from1 = "0";
					}
					else
					{
						strKakuteiymd_from1 = BoSystemFormat.formatDate(formVO.Kakutei_ymd_from);
					}

					// 売変開始日TO
					if (string.IsNullOrEmpty(formVO.Kakutei_ymd_to))
					{
						strKakuteiymd_to1 = "99999999";
					}
					else
					{
						strKakuteiymd_to1 = BoSystemFormat.formatDate(formVO.Kakutei_ymd_to);
					}

					//					strKakuteiymd1 = " AND MDCT0020.UPD_YMD BETWEEN " + strKakuteiymd_from1 + " AND " + strKakuteiymd_to1;
					reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD1", " AND MDCT0020.UPD_YMD BETWEEN ");
					reader.ReplaceAddBind("REPLACE_ID_KAKUTEI_YMD1", "BIND_KAKUTEI_YMD_FROM1");
					reader.BindValue("BIND_KAKUTEI_YMD_FROM1", decimal.Parse(strKakuteiymd_from1));
					reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD1", " AND ");
					reader.ReplaceAddBind("REPLACE_ID_KAKUTEI_YMD1", "BIND_KAKUTEI_YMD_TO1");
					reader.BindValue("BIND_KAKUTEI_YMD_TO1", decimal.Parse(strKakuteiymd_to1));
				}
				else
				{
					strKakuteiymd1 = string.Empty;
				}
			}
			//reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD1", strKakuteiymd1);


			// 確定フラグ
			// 確定テーブル参照時以外は確定時に確定フラグを設定
			string strKakuteiflg1 = string.Empty;
			if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI1.Equals(formVO.Kakutei_jyotai))
			{
				strKakuteiflg1 = "1";
			}
			else
			{
				strKakuteiflg1 = "0";
			}
			reader.ReplaceAdd("REPLACE_ID_KAKUTEI_FLG1", " AND MDCT0020.KAKUTEI_FLG = ");
			reader.ReplaceAddBind("REPLACE_ID_KAKUTEI_FLG1", "BIND_KAKUTEI_FLG1");
			reader.BindValue("BIND_KAKUTEI_FLG1", decimal.Parse(strKakuteiflg1));


			// 自社品番
			string strJisyahbn1 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn))
			{
				strJisyahbn1 = strJisyahbn1 + " AND EXISTS ( ";
				strJisyahbn1 = strJisyahbn1 + " SELECT 1 ";
				strJisyahbn1 = strJisyahbn1 + " FROM MDCT0020 TBL_1 ";
				strJisyahbn1 = strJisyahbn1 + " WHERE TBL_1.TENPO_CD        = MDCT0020.TENPO_CD ";
				strJisyahbn1 = strJisyahbn1 + " AND   TBL_1.BAIHENKAISI_YMD = MDCT0020.BAIHENKAISI_YMD ";
				strJisyahbn1 = strJisyahbn1 + " AND   TBL_1.BAIHEN_NO       = MDCT0020.BAIHEN_NO ";
				strJisyahbn1 = strJisyahbn1 + " AND   TBL_1.BUMON_CD        = MDCT0020.BUMON_CD ";

				// 確定状態：未確定の場合、確定フラグを設定
				if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI2.Equals(formVO.Kakutei_jyotai))
				{
					strJisyahbn1 = strJisyahbn1 + " AND   TBL_1.KAKUTEI_FLG     = 0 ";
				}

				//if (formVO.Old_jisya_hbn.Length == 10)
				//{
				//	strJisyahbn1 = strJisyahbn1 + " AND (TBL_1.JISYA_HBN,TBL_1.IRO_CD) IN ( ";
				//	strJisyahbn1 = strJisyahbn1 + "        SELECT MDMT0130.XEBIO_CD, MAKERCOLOR_CD ";
				//	strJisyahbn1 = strJisyahbn1 + "        FROM   MDMT0130 ";
				//	strJisyahbn1 = strJisyahbn1 + "        WHERE  MDMT0130.OLD_XEBIO_CD = '" + formVO.Old_jisya_hbn + "'";
				//	strJisyahbn1 = strJisyahbn1 + " ) ";
				//}
				//else
				//{
				//strJisyahbn1 = strJisyahbn1 + " AND TBL_1.JISYA_HBN = '" + formVO.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD] + "'";
				//}
				//strJisyahbn1 = strJisyahbn1 + " ) ";
				strJisyahbn1 = strJisyahbn1 + " AND TBL_1.JISYA_HBN = ";
				reader.ReplaceAdd("REPLACE_ID_JISYA_HBN1", strJisyahbn1);
				reader.ReplaceAddBind("REPLACE_ID_JISYA_HBN1", "BIND_JISYA_HBN1");
				reader.BindValue("BIND_JISYA_HBN1", BoSystemFormat.formatJisyaHbn(formVO.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD].ToString()));
				reader.ReplaceAdd("REPLACE_ID_JISYA_HBN1", " ) ");

			}
			else
			{
				strJisyahbn1 = string.Empty;
			}


			// 確定者コード
			// 確定テーブルの場合のみ参照
			string strKakuteitancd1 = string.Empty;
			reader.ReplaceAdd("REPLACE_ID_KAKUTEITAN_CD1", strKakuteitancd1);


			// 売変理由
			// 売価変更指示TBLの場合のみ参照
			string strBaihenriytu1 = string.Empty;
			reader.ReplaceAdd("REPLACE_ID_BAIHEN_RIYTU1", strBaihenriytu1);

			#endregion

			#region 確定データ

			// 条件有無を設定
			string strJyouken2 = string.Empty;
			if ("1".Equals(tbl_flg) || "3".Equals(tbl_flg))
			{
				strJyouken2 = " AND 0=0 ";
			}
			else
			{
				strJyouken2 = " AND 0=1 ";
			}
			reader.ReplaceAdd("REPLACE_ID_JYOUKEN_UMU2", strJyouken2);


			// 店舗コードを設定
			reader.ReplaceAdd("REPLACE_ID_TENPO_CD2", " AND MDCT0030.TENPO_CD = ");
			reader.ReplaceAddBind("REPLACE_ID_TENPO_CD2", "BIND21");
			reader.BindValue("BIND21", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

			reader.BindValue("BIND_TENPO_CD2", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));


			// 部門コードFROM-TO
			string strBumoncd2 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Bumon_cd_from) ||
				!string.IsNullOrEmpty(formVO.Bumon_cd_to))
			{
				string strBumoncd_from2 = string.Empty;
				string strBumoncd_to2 = string.Empty;

				// 部門コードFROM
				if (string.IsNullOrEmpty(formVO.Bumon_cd_from))
				{
					strBumoncd_from2 = "000";
				}
				else
				{
					strBumoncd_from2 = BoSystemFormat.formatBumonCd(formVO.Bumon_cd_from);
				}

				// 部門コードTO
				if (string.IsNullOrEmpty(formVO.Bumon_cd_to))
				{
					strBumoncd_to2 = "999";
				}
				else
				{
					strBumoncd_to2 = BoSystemFormat.formatBumonCd(formVO.Bumon_cd_to);
				}

				//strBumoncd2 = " AND MDCT0030.BUMON_CD BETWEEN '" + strBumoncd_from2 + "' AND '" + strBumoncd_to2 + "'";
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD2", " AND MDCT0030.BUMON_CD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD2", "BIND_BUMON_CD_FROM2");
				reader.BindValue("BIND_BUMON_CD_FROM2", strBumoncd_from2);
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD2", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD2", "BIND_BUMON_CD_TO2");
				reader.BindValue("BIND_BUMON_CD_TO2", strBumoncd_to2);
			}
			else
			{
				strBumoncd2 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_BUMON_CD2", strBumoncd2);


			// 売変指示NoFROM-TO
			string strBaihenshijino2 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Baihen_shiji_no_from) ||
				!string.IsNullOrEmpty(formVO.Baihen_shiji_no_to))
			{
				string strBaihenshijino_from2 = string.Empty;
				string strBaihenshijino_to2 = string.Empty;

				// 売変指示NoFROM
				if (string.IsNullOrEmpty(formVO.Baihen_shiji_no_from))
				{
					strBaihenshijino_from2 = "000000000000000000000000";
				}
				else
				{
					strBaihenshijino_from2 = BoSystemString.RightB(BoSystemFormat.formatBaihen_shiji_no(formVO.Baihen_shiji_no_from), 10);
				}

				// 売変指示NoTO
				if (string.IsNullOrEmpty(formVO.Baihen_shiji_no_to))
				{
					strBaihenshijino_to2 = "999999999999999999999999";
				}
				else
				{
					strBaihenshijino_to2 = BoSystemString.RightB(BoSystemFormat.formatBaihen_shiji_no(formVO.Baihen_shiji_no_to), 10);
				}

				//strBaihenshijino2 = " AND MDCT0030.BAIHEN_NO BETWEEN '" + strBaihenshijino_from2 + "' AND '" + strBaihenshijino_to2 + "'";
				reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO2", " AND MDCT0030.BAIHEN_NO BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_BAIHENSIJI_NO2", "BIND_BAIHEN_NO_FROM2");
				reader.BindValue("BIND_BAIHEN_NO_FROM2", strBaihenshijino_from2);
				reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO2", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_BAIHENSIJI_NO2", "BIND_BAIHEN_NO_TO2");
				reader.BindValue("BIND_BAIHEN_NO_TO2", strBaihenshijino_to2);
			}
			else
			{
				strBaihenshijino2 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO2", strBaihenshijino2);


			// 作業開始日FROM-TO
			// 売価変更指示TBLの場合のみ参照
			string strBaihensagyokaisiymd2 = string.Empty;
			reader.ReplaceAdd("REPLACE_ID_SAGYOKAISI_YMD2", strBaihensagyokaisiymd2);


			// 開始日FROM-TO
			string strBaihenkaisiymd2 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from) ||
				!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
			{
				string strBaihenkaisiymd_from2 = string.Empty;
				string strBaihenkaisiymd_to2 = string.Empty;

				// 売変開始日FROM
				if (string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from))
				{
					strBaihenkaisiymd_from2 = "0";
				}
				else
				{
					strBaihenkaisiymd_from2 = BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_from);
				}

				// 売変開始日TO
				if (string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
				{
					strBaihenkaisiymd_to2 = "99999999";
				}
				else
				{
					strBaihenkaisiymd_to2 = BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_to);
				}

				//strBaihenkaisiymd2 = " AND MDCT0030.BAIHENKAISI_YMD BETWEEN " + strBaihenkaisiymd_from2 + " AND " + strBaihenkaisiymd_to2;
				reader.ReplaceAdd("REPLACE_ID_KAISI_YMD2", " AND MDCT0030.BAIHENKAISI_YMD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_KAISI_YMD2", "BIND_BAIHENKAISI_YMD_FROM2");
				reader.BindValue("BIND_BAIHENKAISI_YMD_FROM2", decimal.Parse(strBaihenkaisiymd_from2));
				reader.ReplaceAdd("REPLACE_ID_KAISI_YMD2", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_KAISI_YMD2", "BIND_BAIHENKAISI_YMD_TO2");
				reader.BindValue("BIND_BAIHENKAISI_YMD_TO2", decimal.Parse(strBaihenkaisiymd_to2));
			}
			else
			{
				strBaihenkaisiymd2 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_KAISI_YMD2", strBaihenkaisiymd2);


			// 確定日FROM-TO
			// 確定状態：確定の場合のみ検索条件とする
			string strKakuteiymd2 = string.Empty;
			if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI1.Equals(formVO.Kakutei_jyotai))
			{
				if (!string.IsNullOrEmpty(formVO.Kakutei_ymd_from) ||
					!string.IsNullOrEmpty(formVO.Kakutei_ymd_to))
				{
					string strKakuteiymd_from2 = string.Empty;
					string strKakuteiymd_to2 = string.Empty;

					// 売変開始日FROM
					if (string.IsNullOrEmpty(formVO.Kakutei_ymd_from))
					{
						strKakuteiymd_from2 = "0";
					}
					else
					{
						strKakuteiymd_from2 = BoSystemFormat.formatDate(formVO.Kakutei_ymd_from);
					}

					// 売変開始日TO
					if (string.IsNullOrEmpty(formVO.Kakutei_ymd_to))
					{
						strKakuteiymd_to2 = "99999999";
					}
					else
					{
						strKakuteiymd_to2 = BoSystemFormat.formatDate(formVO.Kakutei_ymd_to);
					}

					//strKakuteiymd2 = " AND MDCT0030.UPD_YMD BETWEEN " + strKakuteiymd_from2 + " AND " + strKakuteiymd_to2;
					reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD2", " AND MDCT0030.UPD_YMD BETWEEN ");
					reader.ReplaceAddBind("REPLACE_ID_KAKUTEI_YMD2", "BIND_KAKUTEI_YMD_FROM2");
					reader.BindValue("BIND_KAKUTEI_YMD_FROM2", decimal.Parse(strKakuteiymd_from2));
					reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD2", " AND ");
					reader.ReplaceAddBind("REPLACE_ID_KAKUTEI_YMD2", "BIND_KAKUTEI_YMD_TO2");
					reader.BindValue("BIND_KAKUTEI_YMD_TO2", decimal.Parse(strKakuteiymd_to2));
				}
				else
				{
					strKakuteiymd2 = string.Empty;
				}
			}
			//reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD2", strKakuteiymd2);


			// 確定フラグ
			// 確定テーブル参照時以外は確定時に確定フラグを設定
			string strKakuteiflg2 = string.Empty;
			reader.ReplaceAdd("REPLACE_ID_KAKUTEI_FLG2", strKakuteiflg2);


			// 自社品番
			string strJisyahbn2 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn))
			{
				strJisyahbn2 = strJisyahbn2 + " AND EXISTS ( ";
				strJisyahbn2 = strJisyahbn2 + " SELECT 1 ";
				strJisyahbn2 = strJisyahbn2 + " FROM MDCT0030 TBL_1 ";
				strJisyahbn2 = strJisyahbn2 + " WHERE TBL_1.TENPO_CD        = MDCT0030.TENPO_CD ";
				strJisyahbn2 = strJisyahbn2 + " AND   TBL_1.BAIHENKAISI_YMD = MDCT0030.BAIHENKAISI_YMD ";
				strJisyahbn2 = strJisyahbn2 + " AND   TBL_1.BAIHEN_NO       = MDCT0030.BAIHEN_NO ";
				strJisyahbn2 = strJisyahbn2 + " AND   TBL_1.BUMON_CD        = MDCT0030.BUMON_CD ";

				//if (formVO.Old_jisya_hbn.Length == 10)
				//{
				//	strJisyahbn2 = strJisyahbn2 + " AND (TBL_1.JISYA_HBN,TBL_1.IRO_CD) IN ( ";
				//	strJisyahbn2 = strJisyahbn2 + "        SELECT MDMT0130.XEBIO_CD, MAKERCOLOR_CD ";
				//	strJisyahbn2 = strJisyahbn2 + "        FROM   MDMT0130 ";
				//	strJisyahbn2 = strJisyahbn2 + "        WHERE  MDMT0130.OLD_XEBIO_CD = '" + formVO.Old_jisya_hbn + "'";
				//	strJisyahbn2 = strJisyahbn2 + " ) ";
				//}
				//else
				//{
				//strJisyahbn2 = strJisyahbn2 + " AND TBL_1.JISYA_HBN = '" + formVO.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD] + "'";
				//}
				//strJisyahbn2 = strJisyahbn2 + " ) ";
				strJisyahbn2 = strJisyahbn2 + " AND TBL_1.JISYA_HBN = ";
				reader.ReplaceAdd("REPLACE_ID_JISYA_HBN2", strJisyahbn2);
				reader.ReplaceAddBind("REPLACE_ID_JISYA_HBN2", "BIND_JISYA_HBN2");
				reader.BindValue("BIND_JISYA_HBN2", BoSystemFormat.formatJisyaHbn(formVO.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD].ToString()));
				reader.ReplaceAdd("REPLACE_ID_JISYA_HBN2", " ) ");

			}
			else
			{
				strJisyahbn2 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_JISYA_HBN2", strJisyahbn2);

			// 確定者コード
			// 確定テーブルの場合のみ参照
			string strKakuteitancd2 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Torokukak_cd))
			{
				//strKakuteitancd2 = " AND MDCT0030.KAKUTEITAN_CD = '" + BoSystemFormat.formatTantoCd(formVO.Torokukak_cd) + "'";
				strKakuteitancd2 = " AND MDCT0030.KAKUTEITAN_CD = ";
				reader.ReplaceAdd("REPLACE_ID_KAKUTEITAN_CD2", strKakuteitancd2);
				reader.ReplaceAddBind("REPLACE_ID_KAKUTEITAN_CD2", "BIND_KAKUTEITAN_CD2");
				reader.BindValue("BIND_KAKUTEITAN_CD2", BoSystemFormat.formatTantoCd(formVO.Torokukak_cd));
			}
			//reader.ReplaceAdd("REPLACE_ID_KAKUTEITAN_CD2", strKakuteitancd2);

			// 売変理由
			// 売価変更指示TBLの場合のみ参照
			string strBaihenriytu2 = string.Empty;
			reader.ReplaceAdd("REPLACE_ID_BAIHEN_RIYTU2", strBaihenriytu2);

			#endregion

			#region 指示データ

			// 条件有無を設定
			string strJyouken3 = string.Empty;
			if ("2".Equals(tbl_flg) || "3".Equals(tbl_flg) || "4".Equals(tbl_flg))
			{
				strJyouken3 = " AND 0=0 ";
			}
			else
			{
				strJyouken3 = " AND 0=1 ";
			}
			reader.ReplaceAdd("REPLACE_ID_JYOUKEN_UMU3", strJyouken3);


			// 店舗コードを設定
			reader.ReplaceAdd("REPLACE_ID_TENPO_CD3", " AND MDCT0010.TENPO_CD = ");
			reader.ReplaceAddBind("REPLACE_ID_TENPO_CD3", "BIND31");
			reader.BindValue("BIND31", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

			reader.BindValue("BIND_TENPO_CD3", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

			reader.BindValue("BIND_TENPO_CD31", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
			reader.BindValue("BIND_TENPO_CD32", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
			reader.BindValue("BIND_TENPO_CD33", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

			if ("2".Equals(mode))
			{
				reader.BindValue("BIND_TENPO_CD34", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
				reader.BindValue("BIND_TENPO_CD35", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
				reader.BindValue("BIND_TENPO_CD36", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
			}


			// 部門コードFROM-TO
			string strBumoncd3 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Bumon_cd_from) ||
				!string.IsNullOrEmpty(formVO.Bumon_cd_to))
			{
				string strBumoncd_from3 = string.Empty;
				string strBumoncd_to3 = string.Empty;

				// 部門コードFROM
				if (string.IsNullOrEmpty(formVO.Bumon_cd_from))
				{
					strBumoncd_from3 = "000";
				}
				else
				{
					strBumoncd_from3 = BoSystemFormat.formatBumonCd(formVO.Bumon_cd_from);
				}

				// 部門コードTO
				if (string.IsNullOrEmpty(formVO.Bumon_cd_to))
				{
					strBumoncd_to3 = "999";
				}
				else
				{
					strBumoncd_to3 = BoSystemFormat.formatBumonCd(formVO.Bumon_cd_to);
				}

				//strBumoncd3 = " AND MDCT0010.BUMON_CD BETWEEN '" + strBumoncd_from3 + "' AND '" + strBumoncd_to3 + "'";
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD3", " AND MDCT0010.BUMON_CD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD3", "BIND_BUMON_CD_FROM3");
				reader.BindValue("BIND_BUMON_CD_FROM3", strBumoncd_from3);
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD3", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD3", "BIND_BUMON_CD_TO3");
				reader.BindValue("BIND_BUMON_CD_TO3", strBumoncd_to3);
			}
			else
			{
				strBumoncd3 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_BUMON_CD3", strBumoncd3);


			// 売変指示NoFROM-TO
			string strBaihenshijino3 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Baihen_shiji_no_from) ||
				!string.IsNullOrEmpty(formVO.Baihen_shiji_no_to))
			{
				string strBaihenshijino_from3 = string.Empty;
				string strBaihenshijino_to3 = string.Empty;

				// 売変指示NoFROM
				if (string.IsNullOrEmpty(formVO.Baihen_shiji_no_from))
				{
					strBaihenshijino_from3 = "000000000000000000000000";
				}
				else
				{
					strBaihenshijino_from3 = BoSystemString.RightB(BoSystemFormat.formatBaihen_shiji_no(formVO.Baihen_shiji_no_from), 10);
				}

				// 売変指示NoTO
				if (string.IsNullOrEmpty(formVO.Baihen_shiji_no_to))
				{
					strBaihenshijino_to3 = "999999999999999999999999";
				}
				else
				{
					strBaihenshijino_to3 = BoSystemString.RightB(BoSystemFormat.formatBaihen_shiji_no(formVO.Baihen_shiji_no_to), 10);
				}

				//strBaihenshijino3 = " AND MDCT0010.BAIHEN_NO BETWEEN '" + strBaihenshijino_from3 + "' AND '" + strBaihenshijino_to3 + "'";
				reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO3", " AND MDCT0010.BAIHEN_NO BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_BAIHENSIJI_NO3", "BIND_BAIHEN_NO_FROM3");
				reader.BindValue("BIND_BAIHEN_NO_FROM3", strBaihenshijino_from3);
				reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO3", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_BAIHENSIJI_NO3", "BIND_BAIHEN_NO_TO3");
				reader.BindValue("BIND_BAIHEN_NO_TO3", strBaihenshijino_to3);
			}
			else
			{
				strBaihenshijino3 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_BAIHENSIJI_NO3", strBaihenshijino3);


			// 作業開始日FROM-TO
			string strBaihensagyokaisiymd3 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Baihensagyokaisi_ymd_from) ||
				!string.IsNullOrEmpty(formVO.Baihensagyokaisi_ymd_to))
			{
				string strBaihensagyokaisiymd_from3 = string.Empty;
				string strBaihensagyokaisiymd_to3 = string.Empty;

				// 作業開始日FROM
				if (string.IsNullOrEmpty(formVO.Baihensagyokaisi_ymd_from))
				{
					strBaihensagyokaisiymd_from3 = "0";
				}
				else
				{
					strBaihensagyokaisiymd_from3 = BoSystemFormat.formatDate(formVO.Baihensagyokaisi_ymd_from);
				}

				// 作業開始日TO
				if (string.IsNullOrEmpty(formVO.Baihensagyokaisi_ymd_to))
				{
					strBaihensagyokaisiymd_to3 = "99999999";
				}
				else
				{
					strBaihensagyokaisiymd_to3 = BoSystemFormat.formatDate(formVO.Baihensagyokaisi_ymd_to);
				}

				//strBaihensagyokaisiymd3 = " AND MDCT0010.BAIHENSAGYOKAISI_YMD BETWEEN " + strBaihensagyokaisiymd_from3 + " AND " + strBaihensagyokaisiymd_to3;
				reader.ReplaceAdd("REPLACE_ID_SAGYOKAISI_YMD3", " AND MDCT0010.BAIHENSAGYOKAISI_YMD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_SAGYOKAISI_YMD3", "BIND_SAGYOKAISI_YMD_FROM3");
				reader.BindValue("BIND_SAGYOKAISI_YMD_FROM3", decimal.Parse(strBaihensagyokaisiymd_from3));
				reader.ReplaceAdd("REPLACE_ID_SAGYOKAISI_YMD3", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_SAGYOKAISI_YMD3", "BIND_SAGYOKAISI_YMD_TO3");
				reader.BindValue("BIND_SAGYOKAISI_YMD_TO3", decimal.Parse(strBaihensagyokaisiymd_to3));
			}
			else
			{
				strBaihensagyokaisiymd3 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_SAGYOKAISI_YMD3", strBaihensagyokaisiymd3);







			// 開始日FROM-TO
			string strBaihenkaisiymd3 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from) ||
				!string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
			{
				string strBaihenkaisiymd_from3 = string.Empty;
				string strBaihenkaisiymd_to3 = string.Empty;

				// 売変開始日FROM
				if (string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_from))
				{
					strBaihenkaisiymd_from3 = "0";
				}
				else
				{
					strBaihenkaisiymd_from3 = BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_from);
				}

				// 売変開始日TO
				if (string.IsNullOrEmpty(formVO.Baihenkaisi_ymd_to))
				{
					strBaihenkaisiymd_to3 = "99999999";
				}
				else
				{
					strBaihenkaisiymd_to3 = BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd_to);
				}

				//strBaihenkaisiymd3 = " AND MDCT0010.BAIHENKAISI_YMD BETWEEN " + strBaihenkaisiymd_from3 + " AND " + strBaihenkaisiymd_to3;
				reader.ReplaceAdd("REPLACE_ID_KAISI_YMD3", " AND MDCT0010.BAIHENKAISI_YMD BETWEEN ");
				reader.ReplaceAddBind("REPLACE_ID_KAISI_YMD3", "BIND_BAIHENKAISI_YMD_FROM3");
				reader.BindValue("BIND_BAIHENKAISI_YMD_FROM3", decimal.Parse(strBaihenkaisiymd_from3));
				reader.ReplaceAdd("REPLACE_ID_KAISI_YMD3", " AND ");
				reader.ReplaceAddBind("REPLACE_ID_KAISI_YMD3", "BIND_BAIHENKAISI_YMD_TO3");
				reader.BindValue("BIND_BAIHENKAISI_YMD_TO3", decimal.Parse(strBaihenkaisiymd_to3));
			}
			else
			{
				strBaihenkaisiymd3 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_KAISI_YMD3", strBaihenkaisiymd3);


			// 確定日FROM-TO
			// 確定状態：確定の場合のみ検索条件とする
			string strKakuteiymd3 = string.Empty;
			if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI1.Equals(formVO.Kakutei_jyotai))
			{
				if (!string.IsNullOrEmpty(formVO.Kakutei_ymd_from) ||
					!string.IsNullOrEmpty(formVO.Kakutei_ymd_to))
				{
					string strKakuteiymd_from3 = string.Empty;
					string strKakuteiymd_to3 = string.Empty;

					// 確定日FROM
					if (string.IsNullOrEmpty(formVO.Kakutei_ymd_from))
					{
						strKakuteiymd_from3 = "0";
					}
					else
					{
						strKakuteiymd_from3 = BoSystemFormat.formatDate(formVO.Kakutei_ymd_from);
					}

					// 確定日TO
					if (string.IsNullOrEmpty(formVO.Kakutei_ymd_to))
					{
						strKakuteiymd_to3 = "99999999";
					}
					else
					{
						strKakuteiymd_to3 = BoSystemFormat.formatDate(formVO.Kakutei_ymd_to);
					}

					//strKakuteiymd3 = " AND NVL(MDCT0040.UPD_YMD, MDCT0010.UPD_YMD) BETWEEN " + strKakuteiymd_from3 + " AND " + strKakuteiymd_to3;
					reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD3", "AND NVL(MDCT0040.UPD_YMD, MDCT0010.UPD_YMD) BETWEEN ");
					reader.ReplaceAddBind("REPLACE_ID_KAKUTEI_YMD3", "BIND_KAKUTEI_YMD_FROM3");
					reader.BindValue("BIND_KAKUTEI_YMD_FROM3", decimal.Parse(strKakuteiymd_from3));
					reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD3", " AND ");
					reader.ReplaceAddBind("REPLACE_ID_KAKUTEI_YMD3", "BIND_KAKUTEI_YMD_TO3");
					reader.BindValue("BIND_KAKUTEI_YMD_TO3", decimal.Parse(strKakuteiymd_to3));
				}
				else
				{
					strKakuteiymd3 = string.Empty;
				}
			}
			//reader.ReplaceAdd("REPLACE_ID_KAKUTEI_YMD3", strKakuteiymd3);


			// 確定フラグ
			// 確定テーブル参照時以外は確定時に確定フラグを設定
			string strKakuteiflg3 = string.Empty;
			if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI1.Equals(formVO.Kakutei_jyotai))
			{
				strKakuteiflg3 = "1";
			}
			else
			{
				strKakuteiflg3 = "0";
			}
			//reader.ReplaceAdd("REPLACE_ID_KAKUTEI_FLG3", strKakuteiflg3);
			reader.ReplaceAdd("REPLACE_ID_KAKUTEI_FLG3", " AND MDCT0010.KAKUTEI_FLG = ");
			reader.ReplaceAddBind("REPLACE_ID_KAKUTEI_FLG3", "BIND_KAKUTEI_FLG3");
			reader.BindValue("BIND_KAKUTEI_FLG3", decimal.Parse(strKakuteiflg3));

			// 自社品番
			string strJisyahbn3 = string.Empty;
			if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn))
			{
				strJisyahbn3 = strJisyahbn3 + " AND EXISTS ( ";
				strJisyahbn3 = strJisyahbn3 + " SELECT 1 ";
				strJisyahbn3 = strJisyahbn3 + " FROM MDCT0010 TBL_1 ";
				strJisyahbn3 = strJisyahbn3 + " WHERE TBL_1.TENPO_CD        = MDCT0010.TENPO_CD ";
				strJisyahbn3 = strJisyahbn3 + " AND   TBL_1.BAIHENKAISI_YMD = MDCT0010.BAIHENKAISI_YMD ";
				strJisyahbn3 = strJisyahbn3 + " AND   TBL_1.BAIHEN_NO       = MDCT0010.BAIHEN_NO ";
				strJisyahbn3 = strJisyahbn3 + " AND   TBL_1.BUMON_CD        = MDCT0010.BUMON_CD ";

				// 確定状態：未確定の場合、確定フラグを設定
				if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI2.Equals(formVO.Kakutei_jyotai))
				{
					strJisyahbn3 = strJisyahbn3 + " AND   TBL_1.KAKUTEI_FLG     = 0 ";
				}

				//if (formVO.Old_jisya_hbn.Length == 10)
				//{
				//	strJisyahbn3 = strJisyahbn3 + " AND (TBL_1.JISYA_HBN,TBL_1.IRO_CD) IN ( ";
				//	strJisyahbn3 = strJisyahbn3 + "        SELECT MDMT0130.XEBIO_CD, MAKERCOLOR_CD ";
				//	strJisyahbn3 = strJisyahbn3 + "        FROM   MDMT0130 ";
				//	strJisyahbn3 = strJisyahbn3 + "        WHERE  MDMT0130.OLD_XEBIO_CD = '" + formVO.Old_jisya_hbn + "'";
				//	strJisyahbn3 = strJisyahbn3 + " ) ";
				//}
				//else
				//{
				//strJisyahbn3 = strJisyahbn3 + " AND TBL_1.JISYA_HBN = '" + formVO.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD] + "'";
				//}
				//strJisyahbn3 = strJisyahbn3 + " ) ";
				strJisyahbn3 = strJisyahbn3 + " AND TBL_1.JISYA_HBN = ";
				reader.ReplaceAdd("REPLACE_ID_JISYA_HBN3", strJisyahbn3);
				reader.ReplaceAddBind("REPLACE_ID_JISYA_HBN3", "BIND_JISYA_HBN3");
				reader.BindValue("BIND_JISYA_HBN3", BoSystemFormat.formatJisyaHbn(formVO.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD].ToString()));
				reader.ReplaceAdd("REPLACE_ID_JISYA_HBN3", " ) ");
			}
			else
			{
				strJisyahbn3 = string.Empty;
			}
			//reader.ReplaceAdd("REPLACE_ID_JISYA_HBN3", strJisyahbn3);

			// 確定者コード
			// 確定テーブルの場合のみ参照
			string strKakuteitancd3 = string.Empty;
			reader.ReplaceAdd("REPLACE_ID_KAKUTEITAN_CD3", strKakuteitancd3);


			// 売変理由
			// 売変指示テーブルの場合のみ参照
			string strBaihenriytu3 = string.Empty;
			if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(formVO.Baihen_riytu))
			{
				//strBaihenriytu3 = strBaihenriytu3 + " AND MDCT0010.BAIHEN_RIYTU = '" + formVO.Baihen_riytu + "'";
				strBaihenriytu3 = strBaihenriytu3 + " AND MDCT0010.BAIHEN_RIYTU = ";
				reader.ReplaceAdd("REPLACE_ID_BAIHEN_RIYTU3", strBaihenriytu3);
				reader.ReplaceAddBind("REPLACE_ID_BAIHEN_RIYTU3", "BIND_BAIHEN_RIYU3");
				reader.BindValue("BIND_BAIHEN_RIYU3", decimal.Parse(formVO.Baihen_riytu));
			}
			//reader.ReplaceAdd("REPLACE_ID_BAIHEN_RIYTU3", strBaihenriytu3);

			#endregion


		}
		#endregion
	}
}
