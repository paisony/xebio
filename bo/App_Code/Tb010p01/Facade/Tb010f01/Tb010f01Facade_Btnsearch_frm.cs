using com.xebio.bo.Tb010p01.Constant;
using com.xebio.bo.Tb010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01010;
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
using System.Text;

namespace com.xebio.bo.Tb010p01.Facade
{
  /// <summary>
  /// Tb010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb010f01Facade : StandardBaseFacade
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
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tb010f01Form f01VO = (Tb010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				#region 入力値チェック
				// 1-1 伝票状態、仕入先コード
				// 伝票状態と仕入先コードのどちらかが入力されていない場合、エラーとする。
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Denpyo_jyotai) && string.IsNullOrEmpty(f01VO.Siiresaki_cd))
				{
					ErrMsgCls.AddErrMsg("E175", string.Empty, facadeContext, new[] { "Denpyo_jyotai", "Siiresaki_cd" });
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 単項目チェック
				// 2-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
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

				// 2-2 仕入先コード
				//       仕入先マスタを検索し、存在しない場合エラー
				f01VO.Siiresaki_ryaku_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01002Check.CheckShiiresaki(f01VO.Siiresaki_cd
															, facadeContext
															, string.Empty
															, null
															, "仕入先"
															, new[] { "Siiresaki_cd" }
															, null
															, null
															, null
															, 0
															, 0
															);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Siiresaki_ryaku_nm = (string)resultHash["SIIRESAKI_RYAKU_NM"];
					}
				}

				// 2-3 自社品番
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Maker_hbn = string.Empty;
				f01VO.Dictionary[Tb010p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01VO.Old_jisya_hbn,	// 自社品番
						f01VO.Head_tenpo_cd,	// 店舗コード
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

					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });

					// 名称をラベルに設定
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Tb010p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
						f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
					}
				}

				// 2-4 スキャンコード
				//       発注マスタを検索し、存在しない場合エラー
				f01VO.Dictionary[Tb010p01Constant.DIC_SEARCH_JANCD] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01VO.Scan_cd,			// スキャンコード
						f01VO.Head_tenpo_cd,	// 店舗コード
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

					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "スキャンコード", new[] { "Scan_cd" });

					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Tb010p01Constant.DIC_SEARCH_JANCD] = (string)resultHash["JAN_CD"];
					}

				}

				// 部門コードFrom(名称取得、チェックは行わない)
				//       部門マスタを検索し、名前を設定する。
				f01VO.Bumon_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_from, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_from = (string)resultHash["BUMON_NM"];
					}
				}

				// 部門コードTo(名称取得、チェックは行わない)
				//       部門マスタを検索し、名前を設定する。
				f01VO.Bumon_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_to, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_to = (string)resultHash["BUMON_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連項目チェック

				// 3-1 入荷予定日FROM、入荷予定日TO
				//       入荷予定日ＦＲＯＭ > 入荷予定日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from) && !string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Nyukayotei_ymd_from,
									f01VO.Nyukayotei_ymd_to,
									facadeContext,
									"入荷予定日",
									new[] { "Nyukayotei_ymd_from", "Nyukayotei_ymd_to" }
									);
				}

				// 3-2 仕入確定日FROM、仕入確定日TO
				//       仕入確定日ＦＲＯＭ > 返品確定日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from) && !string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Siire_kakutei_ymd_from,
									f01VO.Siire_kakutei_ymd_to,
									facadeContext,
									"返品確定日",
									new[] { "Siire_kakutei_ymd_from", "Siire_kakutei_ymd_to" }
									);
				}

				// 3-3 部門コードFROM、部門コードTO
				//       部門コードＦＲＯＭ > 部門コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Bumon_cd_from,
									f01VO.Bumon_cd_to,
									facadeContext,
									"部門コード",
									new[] { "Bumon_cd_from", "Bumon_cd_to" }
									);
				}

				// 3-4 伝票番号FROM、伝票番号TO
				//       伝票番号ＦＲＯＭ > 伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from) && !string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Denpyo_bango_from,
									f01VO.Denpyo_bango_to,
									facadeContext,
									"伝票番号",
									new[] { "Denpyo_bango_from", "Denpyo_bango_to" }
									);
				}

				// 3-5 元伝票番号FROM、元伝票番号TO
				//       元伝票番号ＦＲＯＭ > 元伝票番号ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from) && !string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Motodenpyo_bango_from,
									f01VO.Motodenpyo_bango_to,
									facadeContext,
									"元伝票番号",
									new[] { "Motodenpyo_bango_from", "Motodenpyo_bango_to" }
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

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				Decimal dCnt = 0;
				String sSqlId_chk = null;
				String sSqlId_src = null;
				String sTblId1 = null;
				String sTblId2 = null;

				// 伝票状態によってSQL、テーブルを変更する
				switch (f01VO.Denpyo_jyotai)
				{
					// 「未処理」「仕掛中」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI2:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI3:
						sSqlId_chk = Tb010p01Constant.SQL_ID_02;
						sSqlId_src = Tb010p01Constant.SQL_ID_04;
						sTblId1 = Tb010p01Constant.TABLE_ID_MDPT0010;	// 仕入入荷予定テーブル(H)
						break;

					// 「確定」「ﾏﾆｭｱﾙ仕入」「差異あり」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI1:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI4:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI5:
						sSqlId_chk = Tb010p01Constant.SQL_ID_02;
						sSqlId_src = Tb010p01Constant.SQL_ID_05;
						sTblId1 = Tb010p01Constant.TABLE_ID_MDPT0020;	// 仕入入荷確定テーブル(H)
						break;

					// 「登録履歴」「取消履歴」の場合
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI6:
					case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI7:
						sSqlId_chk = Tb010p01Constant.SQL_ID_02;
						sSqlId_src = Tb010p01Constant.SQL_ID_06;
						sTblId1 = Tb010p01Constant.TABLE_ID_MDPT0060;	// 仕入入荷履歴テーブル(H)
						break;

					// 空白の場合
					default:
						sSqlId_chk = Tb010p01Constant.SQL_ID_01;
						sSqlId_src = Tb010p01Constant.SQL_ID_03;
						sTblId1 = Tb010p01Constant.TABLE_ID_MDPT0010;	// 仕入入荷予定テーブル(H)
						sTblId2 = Tb010p01Constant.TABLE_ID_MDPT0020;	// 仕入入荷確定テーブル(H)
						break;
				}

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(sSqlId_chk, facadeContext.DBContext);

				#region テーブルID設定
				// テーブルIDを設定 -----------

				BoSystemSql.AddSql(rtChk, Tb010p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);

				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Denpyo_jyotai))
				{
					BoSystemSql.AddSql(rtChk, Tb010p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhere(f01VO, rtChk, sTblId1, Tb010p01Constant.SQL_ID_01_REP_ADD_WHERE1);

				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Denpyo_jyotai))
				{
					this.AddWhere(f01VO, rtChk, sTblId2, Tb010p01Constant.SQL_ID_01_REP_ADD_WHERE2);
				}

				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();

				BoSystemLog.logOut("SQL: " + rtChk.LogSql);

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

				#region 検索処理

				// 仕入入荷テーブルから検索する。

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId_src, facadeContext.DBContext);

				#region テーブルID設定

				// テーブルIDを設定 -----------
				BoSystemSql.AddSql(rtSeach, Tb010p01Constant.SQL_ID_01_REP_TABLE_ID1, sTblId1 + " T1", bindList);
				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Denpyo_jyotai))
				{
					BoSystemSql.AddSql(rtSeach, Tb010p01Constant.SQL_ID_01_REP_TABLE_ID2, sTblId2 + " T1", bindList);
				}

				#endregion

				// 検索条件設定
				this.AddWhere(f01VO, rtSeach, sTblId1, Tb010p01Constant.SQL_ID_01_REP_ADD_WHERE1);
				// 伝票状態が空白の場合
				if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Denpyo_jyotai))
				{
					this.AddWhere(f01VO, rtSeach, sTblId2, Tb010p01Constant.SQL_ID_01_REP_ADD_WHERE2);
				}

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tb010f01M1Form f01m1VO = new Tb010f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１ＮＯ
					f01m1VO.M1bumon_cd = BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString());							// Ｍ１部門コード
					f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();											// Ｍ１部門カナ名
					f01m1VO.M1siiresaki_cd = BoSystemFormat.formatSiiresakiCd(rec["SIIRESAKI_CD"].ToString());			// Ｍ１仕入先コード
					f01m1VO.M1siiresaki_ryaku_nm = rec["SIIRESAKI_RYAKU_NM"].ToString();								// Ｍ１仕入先名称
					f01m1VO.M1nyukayotei_ymd = BoSystemFormat.formatDate(rec["SITEINOHIN_YMD"].ToString());				// Ｍ１入荷予定日
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1DENPYO_BANGO, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));
																														// Ｍ１伝票番号リンク
					f01m1VO.M1motodenpyo_bango =  BoSystemFormat.formatDenpyoNo(rec["MOTODENPYO_BANGO"].ToString());	// Ｍ１元伝票番号
					f01m1VO.M1nohin_su = rec["SIIREYOTEIGOKEI_SU"].ToString();											// Ｍ１納品数
					f01m1VO.M1kensu = rec["SIIREJISSEKIGOKEI_SU"].ToString();											// Ｍ１検数
					// 伝票状態が「確定」以外(「未処理」、「仕掛中」データ)の場合
					if (!string.IsNullOrEmpty(rec["DENPYO_JYOTAI"].ToString())
						&& !ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI1.Equals(rec["DENPYO_JYOTAI"].ToString()))
					{
						f01m1VO.M1genka_kin = rec["SIIREYOTEIGOKEI_KIN"].ToString();									// Ｍ１原価金額
					}
					else
					{
						f01m1VO.M1genka_kin = rec["SIIREJISSEKIGOKEI_KIN"].ToString();									// Ｍ１原価金額
					}
					f01m1VO.M1siire_kakutei_ymd = BoSystemFormat.formatDate(rec["JYURYO_YMD"].ToString());				// Ｍ１仕入確定日
					f01m1VO.M1denpyo_jyotainm = rec["DENPYO_JYOTAI_NM"].ToString();										// Ｍ１伝票状態名称
					f01m1VO.M1syorinm = rec["SYORI_SHUBETU"].ToString();												// Ｍ１処理名称
					f01m1VO.M1syoriymd = BoSystemFormat.formatDate(rec["SYORI_YMD"].ToString());						// Ｍ１処理日
					if(string.IsNullOrEmpty(rec["SYORI_TM"].ToString()))
					{
						f01m1VO.M1syori_tm = rec["SYORI_TM"].ToString();												// Ｍ１処理時間
					}
					else
					{
						f01m1VO.M1syori_tm = BoSystemFormat.formatTime(rec["SYORI_TM"].ToString());						// Ｍ１処理時間
					}
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)

					if (   ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString())
						&& (   BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Denpyo_jyotai)
							|| ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI4.Equals(f01VO.Denpyo_jyotai)
							|| ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI1.Equals(f01VO.Denpyo_jyotai)
							|| ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI5.Equals(f01VO.Denpyo_jyotai)
							)
						)
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}

					// Dictionary
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1TANTOSYA_CD,  BoSystemFormat.formatTantoCd(rec["UPD_TANCD"].ToString()));			// 担当者コード
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1TANTOSYA_NM, rec["TANTOSYA_NM"].ToString());										// 担当者名
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1DENPYO_JYOTAI, rec["DENPYO_JYOTAI"].ToString());									// 伝票状態
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1KAKUTEI_SB, rec["KAKUTEI_SB"].ToString());										// 確定種別
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1BUMON_NM, rec["BUMON_NM"].ToString());											// 部門名
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1RIREKI_NO, rec["RIREKI_NO"].ToString());											// 履歴No
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1AKAKURO_KBN, rec["AKAKURO_KBN"].ToString());										// 赤黒区分
					f01m1VO.Dictionary.Add(Tb010p01Constant.DIC_M1SOSINZUMI_FLG, rec["SOSINZUMI_FLG"].ToString());									// 送信済フラグ

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				#endregion

				//トランザクションをコミットする。
//				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
//				RollbackTransaction(facadeContext);
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
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Tb010f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="String">table_id</param>
		/// <param name="String">add_where_id</param>
		/// <returns></returns>
		private void AddWhere(Tb010f01Form f01VO, FindSqlResultTable reader, String table_id, String add_where_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			// 店舗コードを設定
			sRepSql.Append("	AND T1.TENPO_CD = :BIND_TENPO_CD_" + add_where_id);

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD_" + add_where_id;
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 入荷予定日FROM-TOを設定

			if (!string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from) || !string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
			{
				String nyukayotei_ymd_from = f01VO.Nyukayotei_ymd_from;
				String nyukayotei_ymd_to = f01VO.Nyukayotei_ymd_to;

				// 入荷予定日FROM
				if (string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from))
				{
					nyukayotei_ymd_from = "0";
				}

				// 入荷予定日TO
				if (string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
				{
					nyukayotei_ymd_to = "99999999";
				}

				sRepSql.Append("	AND T1.SITEINOHIN_YMD BETWEEN :BIND_SITEI_FRM_" + add_where_id + " AND :BIND_SITEI_TO_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SITEI_FRM_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatDate(nyukayotei_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SITEI_TO_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatDate(nyukayotei_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 伝票番号FROM-TOを設定

			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from) || !string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
			{
				String denpyo_bango_from = f01VO.Denpyo_bango_from;
				String denpyo_bango_to = f01VO.Denpyo_bango_to;

				// 伝票番号FROM
				if (string.IsNullOrEmpty(f01VO.Denpyo_bango_from))
				{
					denpyo_bango_from = "0";
				}

				// 伝票番号TO
				if (string.IsNullOrEmpty(f01VO.Denpyo_bango_to))
				{
					denpyo_bango_to = "999999";
				}

				sRepSql.Append(" AND T1.DENPYO_BANGO BETWEEN :BIND_DEN_FROM_" + add_where_id + " AND :BIND_DEN_TO_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DEN_FROM_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatDenpyoNo(denpyo_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DEN_TO_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatDenpyoNo(denpyo_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

				// 仕入入荷予定TBLの検索条件ではない場合
			if (!Tb010p01Constant.TABLE_ID_MDPT0010.Equals(table_id))
			{
				// 仕入確定日FROM-TOを設定

				if (!string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from) || !string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
				{
					String siire_kakutei_ymd_from = f01VO.Siire_kakutei_ymd_from;
					String siire_kakutei_ymd_to = f01VO.Siire_kakutei_ymd_to;

					// 仕入確定日FROM
					if (string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from))
					{
						siire_kakutei_ymd_from = "0";
					}

					// 仕入確定日TO
					if (string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
					{
						siire_kakutei_ymd_to = "99999999";
					}

					sRepSql.Append("	AND T1.JYURYO_YMD BETWEEN :BIND_SIIRE_FRM_" + add_where_id + " AND :BIND_SIIRE_TO_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SIIRE_FRM_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDate(siire_kakutei_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SIIRE_TO_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDate(siire_kakutei_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

				}

				// 元伝票番号FROM-TOを設定

				if (!string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from) || !string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
				{
					String motodenpyo_bango_from = f01VO.Motodenpyo_bango_from;
					String motodenpyo_bango_to = f01VO.Motodenpyo_bango_to;

					// 元伝票番号FROM
					if (string.IsNullOrEmpty(f01VO.Motodenpyo_bango_from))
					{
						motodenpyo_bango_from = "0";
					}

					// 元伝票番号TO
					if (string.IsNullOrEmpty(f01VO.Motodenpyo_bango_to))
					{
						motodenpyo_bango_to = "999999";
					}

					sRepSql.Append("	AND T1.MOTODENPYO_BANGO BETWEEN :BIND_MOTO_FROM_" + add_where_id + " AND :BIND_MOTO_TO_" + add_where_id);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_MOTO_FROM_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDenpyoNo(motodenpyo_bango_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_MOTO_TO_" + add_where_id;
					bindVO.Value = BoSystemFormat.formatDenpyoNo(motodenpyo_bango_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

				}

			}
			// 仕入先コードを設定

			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				sRepSql.Append("	AND T1.SIIRESAKI_CD = :BIND_SIIRE_CD_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRE_CD_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門FROM-TOを設定

			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) || !string.IsNullOrEmpty(f01VO.Bumon_cd_to))
			{
				String bumon_cd_from = f01VO.Bumon_cd_from;
				String bumon_cd_to = f01VO.Bumon_cd_to;

				// 部門FROM
				if (string.IsNullOrEmpty(f01VO.Bumon_cd_from))
				{
					bumon_cd_from = "000";
				}

				// 部門TO
				if (string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					bumon_cd_to = "999";
				}

				sRepSql.Append("	AND T1.BUMON_CD BETWEEN :BIND_BMNCD_FRM_" + add_where_id + " AND :BIND_BMNCD_TO_" + add_where_id);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BMNCD_FRM_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatBumonCd(bumon_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BMNCD_TO_" + add_where_id;
				bindVO.Value = BoSystemFormat.formatBumonCd(bumon_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 自社品番を設定

			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				// 仕入入荷予定テーブルの場合
				if (Tb010p01Constant.TABLE_ID_MDPT0010.Equals(table_id))
				{
					sRepSql.Append("	AND EXISTS (");
					sRepSql.Append("		SELECT 1");
					sRepSql.Append("		FROM MDPT0011 T2");
					sRepSql.Append("		WHERE T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
					sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");

					//// 自社品番が10桁の場合
					//if (f01VO.Old_jisya_hbn.Length == 10)
					//{
					//	sRepSql.Append("	AND T2.JAN_CD IN (");
					//	sRepSql.Append("			SELECT");
					//	sRepSql.Append("				MDMT0130.JAN_CD");
					//	sRepSql.Append("			FROM MDMT0130");
					//	sRepSql.Append("			WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_where_id);
					//	sRepSql.Append("		)");
					//}
					//// 自社品番が10桁以外の場合
					//else
					//{
						sRepSql.Append("	AND   T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_where_id);
					//}
					sRepSql.Append("	 )");

				// 仕入確定テーブルの場合
				}
				else if(Tb010p01Constant.TABLE_ID_MDPT0020.Equals(table_id))
				{
					sRepSql.Append("	AND EXISTS (");
					sRepSql.Append("		SELECT 1");
					sRepSql.Append("		FROM MDPT0021 T2");
					sRepSql.Append("		WHERE T2.KAKUTEI_SB = T1.KAKUTEI_SB");
					sRepSql.Append("		AND   T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
					sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
					sRepSql.Append("		AND   T2.SITEINOHIN_YMD = T1.SITEINOHIN_YMD");
					sRepSql.Append("		AND   T2.TENPO_CD = T1.TENPO_CD");

					//// 自社品番が10桁の場合
					//if (f01VO.Old_jisya_hbn.Length == 10)
					//{
					//	sRepSql.Append("	AND   T2.JAN_CD IN (");
					//	sRepSql.Append("			SELECT");
					//	sRepSql.Append("				MDMT0130.JAN_CD");
					//	sRepSql.Append("			FROM MDMT0130");
					//	sRepSql.Append("			WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_where_id);
					//	sRepSql.Append("		)");
					//}
					//// 自社品番が10桁以外の場合
					//else
					//{
						sRepSql.Append("	AND   T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_where_id);
					//}
					sRepSql.Append("	 )");

				// 仕入履歴テーブルの場合
				}
				else if (Tb010p01Constant.TABLE_ID_MDPT0060.Equals(table_id))
				{
					sRepSql.Append("	AND EXISTS (");
					sRepSql.Append("		SELECT 1");
					sRepSql.Append("		FROM MDPT0061 T2");
					sRepSql.Append("		WHERE T2.KAKUTEI_SB = T1.KAKUTEI_SB");
					sRepSql.Append("		AND   T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
					sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
					sRepSql.Append("		AND   T2.SITEINOHIN_YMD = T1.SITEINOHIN_YMD");
					sRepSql.Append("		AND   T2.TENPO_CD = T1.TENPO_CD");
					sRepSql.Append("		AND   T2.RIREKI_NO = T1.RIREKI_NO");
					sRepSql.Append("		AND   T2.AKAKURO_KBN = T1.AKAKURO_KBN");

					//// 自社品番が10桁の場合
					//if (f01VO.Old_jisya_hbn.Length == 10)
					//{
					//	sRepSql.Append("	AND   T2.JAN_CD IN (");
					//	sRepSql.Append("			SELECT");
					//	sRepSql.Append("				MDMT0130.JAN_CD");
					//	sRepSql.Append("			FROM MDMT0130");
					//	sRepSql.Append("			WHERE MDMT0130.OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_where_id);
					//	sRepSql.Append("		)");
					//}
					//// 自社品番が10桁以外の場合
					//else
					//{
						sRepSql.Append("	AND   T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_where_id);
					//}
					sRepSql.Append("	 )");
				}

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JISYA_HBN_" + add_where_id;
				//bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn);
				bindVO.Value = BoSystemFormat.formatJisyaHbn((string)f01VO.Dictionary[Tb010p01Constant.DIC_SEARCH_XEBIOCD]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// スキャンコードを設定

			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				// 仕入入荷予定テーブルの場合
				if (Tb010p01Constant.TABLE_ID_MDPT0010.Equals(table_id))
				{
					sRepSql.Append("	AND EXISTS (");
					sRepSql.Append("		SELECT 1");
					sRepSql.Append("		FROM MDPT0011 T2");
					sRepSql.Append("		WHERE T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
					sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
					sRepSql.Append("		AND   T2.JAN_CD = :BIND_JAN_CD_" + add_where_id);
					sRepSql.Append("	 )");

				// 仕入確定テーブルの場合
				}
				else if (Tb010p01Constant.TABLE_ID_MDPT0020.Equals(table_id))
				{
					sRepSql.Append("	AND EXISTS (");
					sRepSql.Append("		SELECT 1");
					sRepSql.Append("		FROM MDPT0021 T2");
					sRepSql.Append("		WHERE T2.KAKUTEI_SB = T1.KAKUTEI_SB");
					sRepSql.Append("		AND   T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
					sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
					sRepSql.Append("		AND   T2.SITEINOHIN_YMD = T1.SITEINOHIN_YMD");
					sRepSql.Append("		AND   T2.TENPO_CD = T1.TENPO_CD");
					sRepSql.Append("		AND   T2.JAN_CD = :BIND_JAN_CD_" + add_where_id);
					sRepSql.Append("	 )");

				// 仕入履歴テーブルの場合
				}
				else if (Tb010p01Constant.TABLE_ID_MDPT0060.Equals(table_id))
				{
					sRepSql.Append("	AND EXISTS (");
					sRepSql.Append("		SELECT 1");
					sRepSql.Append("		FROM MDPT0061 T2");
					sRepSql.Append("		WHERE T2.KAKUTEI_SB = T1.KAKUTEI_SB");
					sRepSql.Append("		AND   T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
					sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
					sRepSql.Append("		AND   T2.SITEINOHIN_YMD = T1.SITEINOHIN_YMD");
					sRepSql.Append("		AND   T2.TENPO_CD = T1.TENPO_CD");
					sRepSql.Append("		AND   T2.RIREKI_NO = T1.RIREKI_NO");
					sRepSql.Append("		AND   T2.AKAKURO_KBN = T1.AKAKURO_KBN");
					sRepSql.Append("		AND   T2.JAN_CD = :BIND_JAN_CD_" + add_where_id);
					sRepSql.Append("	 )");
				}

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JAN_CD_" + add_where_id;
				//bindVO.Value = BoSystemFormat.formatJanCd(f01VO.Scan_cd);
				bindVO.Value = BoSystemFormat.formatJanCd((string)f01VO.Dictionary[Tb010p01Constant.DIC_SEARCH_JANCD]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			// 伝票状態によってSQL、テーブルを変更する
			switch (f01VO.Denpyo_jyotai)
			{
				// 「未処理」の場合
				case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI3:
					sRepSql.Append("	AND T1.KAKUTEI_FLG = 0");
					sRepSql.Append("	AND T1.DENPYO_JYOTAI = 0");
					break;

				// 「仕掛中」の場合
				case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI2:
					sRepSql.Append("	AND T1.KAKUTEI_FLG = 0");
					sRepSql.Append("	AND T1.DENPYO_JYOTAI = 2");
					break;

				// 「確定」の場合
				case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI1:
					sRepSql.Append("	AND T1.KAKUTEI_SB IN (0, 2)");
					break;
				// 「ﾏﾆｭｱﾙ仕入」の場合
				case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI4:
					sRepSql.Append("	AND T1.KAKUTEI_SB IN (1, 3)");
					break;
				// 「差異あり」の場合
				case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI5:
					sRepSql.Append("	AND T1.SAI_FLG = 1");
					break;
				// 「取消履歴」の場合
				case ConditionSiiire_denpyo_jotai.VALUE_SIIIRE_DENPYO_JOTAI7:
					sRepSql.Append("	AND EXISTS (");
					sRepSql.Append("		SELECT 1");
					sRepSql.Append("		FROM MDPT0060 T2");
					sRepSql.Append("		WHERE T2.KAKUTEI_SB = T1.KAKUTEI_SB");
					sRepSql.Append("		AND   T2.SIIRESAKI_CD = T1.SIIRESAKI_CD");
					sRepSql.Append("		AND   T2.DENPYO_BANGO = T1.DENPYO_BANGO");
					sRepSql.Append("		AND   T2.SITEINOHIN_YMD = T1.SITEINOHIN_YMD");
					sRepSql.Append("		AND   T2.TENPO_CD = T1.TENPO_CD");
					sRepSql.Append("		AND   T2.SYORI_SB IN (2, 5)");
					sRepSql.Append("	 )");
					break;
				// 空白の場合
				case BoSystemConstant.DROPDOWNLIST_MISENTAKU:
				// 仕入入荷予定テーブルの場合
					if (Tb010p01Constant.TABLE_ID_MDPT0010.Equals(table_id))
					{
						sRepSql.Append("	AND T1.DENPYO_JYOTAI IN (0, 2) ");
					}
					break;
				// 「登録履歴」の場合
				default:
					break;
			}

			BoSystemSql.AddSql(reader, add_where_id, sRepSql.ToString(), bindList);

			#endregion

		}

		#endregion
	}
}
