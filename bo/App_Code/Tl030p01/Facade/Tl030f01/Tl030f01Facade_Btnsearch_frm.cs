using com.xebio.bo.Tl030p01.Constant;
using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01004;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01010;
using Common.Business.V01000.V01024;
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

namespace com.xebio.bo.Tl030p01.Facade
{
  /// <summary>
  /// Tl030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl030f01Facade : StandardBaseFacade
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
				Tl030f01Form f01VO = (Tl030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				#endregion

				#region 業務チェック

				#region マスタ存在チェック

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

				// 1-2 申請担当者コード
				// 担当者MSTを検索し、存在しない場合エラー
				f01VO.Sinseitan_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Sinseitan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Sinseitan_cd
														, facadeContext
														, string.Empty
														, null
														, "申請担当者"
														, new[] { "Sinseitan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Sinseitan_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 部門名FROM
				f01VO.Bumon_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_from
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_from = (string)resultHash["BUMON_NM"];
					}
				}

				// 部門名TO
				f01VO.Bumon_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_to
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
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

				#region 入力値チェック

				// 2-1 部門コードFROM、部門コードTO
				// 部門コードＦＲＯＭ > 部門コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Bumon_cd_from,
									f01VO.Bumon_cd_to,
									facadeContext,
									"部門",
									new[] { "Bumon_cd_from", "Bumon_cd_to" }
									);
				}

				// 2-2 売変指示NoFROM、売変指示NoTO
				// 売変指示NoＦＲＯＭ > 売変指示NoＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Baihen_shiji_no_from) && !string.IsNullOrEmpty(f01VO.Baihen_shiji_no_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Baihen_shiji_no_from,
									f01VO.Baihen_shiji_no_to,
									facadeContext,
									"売変指示No",
									new[] { "Baihen_shiji_no_from", "Baihen_shiji_no_to" }
									);
				}

				// 2-3 作業開始日FROM、作業開始日TO
				// 作業開始日ＦＲＯＭ > 作業開始日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Baihensagyokaisi_ymd_from) && !string.IsNullOrEmpty(f01VO.Baihensagyokaisi_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Baihensagyokaisi_ymd_from,
									f01VO.Baihensagyokaisi_ymd_to,
									facadeContext,
									"作業開始日",
									new[] { "Baihensagyokaisi_ymd_from", "Baihensagyokaisi_ymd_to" }
									);
				}

				// 2-4 開始日FROM、開始日TO
				// 開始日ＦＲＯＭ > 開始日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Baihenkaisi_ymd_from) && !string.IsNullOrEmpty(f01VO.Baihenkaisi_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Baihenkaisi_ymd_from,
									f01VO.Baihenkaisi_ymd_to,
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

				// 現売価 = 指示売価にチェックが入っている場合、申請元を本部とする
				if (BoSystemConstant.CHECKBOX_ON.Equals(f01VO.Genbaika_shijibaika_flg))
				{
					f01VO.Sinseimoto = ConditionSinseimoto.VALUE_SINSEIMOTO1;
				}

				// 検索件数
				Decimal dCnt = 0;
				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_01, facadeContext.DBContext);

				// WHERE句設定
				AddWhere(f01VO, rtChk);

				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();
				// BoSystemLog.logOut("SQL: " + rtChk.LogSql);

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

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_02, facadeContext.DBContext);

				// WHERE句設定
				AddWhere(f01VO, rtSeach);

				// SELECT句設定(売価変更指示TBL)
				AddSelect(f01VO, rtSeach, Tl030p01Constant.SQL_ID_01_REP_SELECT_MDCT0010);
				// SELECT句設定(店舗売変予定TBL)
				AddSelect(f01VO, rtSeach, Tl030p01Constant.SQL_ID_01_REP_SELECT_MDCT0020);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tl030f01M1Form f01m1VO = new Tl030f01M1Form();
					f01m1VO.M1rowno = iCnt.ToString();														// Ｍ１行NO
					f01m1VO.M1shinseimoto_nm = rec["SIMSEIMOTO_NM"].ToString();								// Ｍ１申請元名称
					f01m1VO.M1sinseitan_nm = rec["HANBAIIN_NM"].ToString();									// Ｍ１申請担当者名称

					// 申請元が本部の場合のみ設定
					if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(rec["SINSEIMOTO_KBN"].ToString()))
					{
						f01m1VO.M1baihen_shiji_no = rec["BAIHEN_NO"].ToString();							// Ｍ１売変指示No
					}
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1BUMON_CD, rec["BUMON_CD"].ToString());	// Ｍ１部門リンク
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1BUMONKANA_NM, rec["BUMONKANA_NM"].ToString());// Ｍ１部門名リンク
					f01m1VO.M1baihensagyokaisi_ymd = BoSystemString.ZeroToEmpty(rec["BAIHENSAGYOKAISI_YMD"].ToString());				
																											// Ｍ１売変作業開始日
					f01m1VO.M1baihenkaisi_ymd = rec["BAIHENKAISI_YMD"].ToString();							// Ｍ１売変開始日
					f01m1VO.M1baihen_riyu_nm = rec["BAIHEN_RIYTU_NM"].ToString();							// Ｍ１売変理由名称
					f01m1VO.M1hinban_su = BoSystemString.Nvl(rec["HINBAN_SU"].ToString(),"0");				// Ｍ１品番数
					f01m1VO.M1zaiko_su = rec["ZAIKO_SU"].ToString();										// Ｍ１在庫数
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;								// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;							// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;								// Ｍ１明細色区分(隠し)

					// Dictionary 

					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1HHTSERIAL_NO, rec["HHTSERIAL_NO"].ToString());		// HHTシリアル番号
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1HHTSEQUENCE_NO, rec["HHTSEQUENCE_NO"].ToString());	// HHTシーケンスNo.
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());					// Ｍ１更新日
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());					// Ｍ１更新時間
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1SINSEITAN_CD, rec["SINSEITAN_CD"].ToString());		// Ｍ１申請担当者コード 
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1BAIHEN_NO, rec["BAIHEN_NO"].ToString());				// Ｍ１売変№
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1BAIHEN_RIYTU, rec["BAIHEN_RIYTU"].ToString());		// Ｍ１売変理由
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1SINSEIMOTO_KBN, rec["SINSEIMOTO_KBN"].ToString());	// Ｍ１申請元区分
					f01m1VO.Dictionary.Add(Tl030p01Constant.DIC_M1BUMON_NM, rec["BUMON_NM"].ToString());				// Ｍ１部門名
					f01m1VO.Dictionary[Tl030p01Constant.DIC_M1NOTSELECTFLG] = Tl030p01Constant.ITIRAN_SENTAKU_KA;

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);

				}
				f01VO.Searchcnt = m1List.Count.ToString();

				#endregion

				#region ラベル発行機情報設定

				if (!string.IsNullOrEmpty(f01VO.Label_cd))
				{
					// ラベル発行機ＩＤ
					f01VO.Label_ip = string.Empty;
					f01VO.Label_nm = string.Empty;

					Hashtable resultHash = new Hashtable();
					resultHash = V01024Check.CheckLabel(BoSystemFormat.formatTenpoCd(logininfo.TnpCd), f01VO.Label_cd, facadeContext);

					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Label_ip = (string)resultHash["LABEL_IP"];
						f01VO.Label_nm = (string)resultHash["LABEL_NM"];
					}
				}
				#endregion

				#region 採番処理を行う

				// 採番を行う
				decimal dSeq = AutoNumber_Seq(facadeContext,logininfo);
				f01VO.Dictionary[Tl030p01Constant.DIC_SEQ] = dSeq.ToString();

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

		#region 検索テーブル判定
		/// <summary>
		/// AddWhere 検索テーブル判定
		/// </summary>
		/// <param name="Tl030f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void AddWhere(Tl030f01Form f01VO, FindSqlResultTable reader)
		{

			StringBuilder sRepSql = new StringBuilder();

			// [申請元]の内容に応じて、検索テーブルを変更する。

			if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(f01VO.Sinseimoto))
			{
				// [申請元]が「本部」の場合

				// 売価変更指示TBLを検索
				RepWhere(f01VO, reader, Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0010);

				// 店舗売変予定TBLは検索しない
				sRepSql = new StringBuilder();
				sRepSql.Append("	AND 1 = 0");
				BoSystemSql.AddSql(reader, Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0020, sRepSql.ToString());
			}
			else if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(f01VO.Sinseimoto))
			{
				// [申請元]が「店舗」の場合

				// 売価変更指示TBLは検索しない
				sRepSql = new StringBuilder();
				sRepSql.Append("	AND 1 = 0");
				BoSystemSql.AddSql(reader, Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0010, sRepSql.ToString());

				// 店舗売変予定TBLを検索
				RepWhere(f01VO, reader, Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0020);
			}

			else
			{
				// [申請元]が「空白」の場合

				// 売価変更指示TBLを検索
				RepWhere(f01VO, reader, Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0010);

				// 店舗売変予定TBLを検索
				RepWhere(f01VO, reader, Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0020);
			}

		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// RepWhere 検索条件設定
		/// </summary>
		/// <param name="Tl030f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="String">リプレースID</param>
		/// <returns></returns>
		private void RepWhere(Tl030f01Form f01VO, FindSqlResultTable reader, String sRepId)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 店舗コード

			// 	店舗コード
			sRepSql.Append(" AND T1.TENPO_CD = :").Append(sRepId).Append("_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = sRepId + "_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region 部門コード From - To

			// 部門コード From - To
			if (!(string.IsNullOrEmpty(f01VO.Bumon_cd_from) && string.IsNullOrEmpty(f01VO.Bumon_cd_to)))
			{
				String searchBumonCdFrom = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_from);
				String searchBumonCdTo = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_to);

				// 部門コード From
				if (string.IsNullOrEmpty(searchBumonCdFrom))
				{
					searchBumonCdFrom = "000";
				}

				// 部門コード To
				if (string.IsNullOrEmpty(searchBumonCdTo))
				{
					searchBumonCdTo = "999";
				}

				sRepSql.Append(" AND T1.BUMON_CD BETWEEN :").Append(sRepId).Append("_BUMON_FROM").Append(" AND :").Append(sRepId).Append("_BUMON_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_BUMON_FROM";
				bindVO.Value = searchBumonCdFrom;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_BUMON_TO";
				bindVO.Value = searchBumonCdTo;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 売変指示No From - To
			
			// 売変指示No From - To
			if (!(string.IsNullOrEmpty(f01VO.Baihen_shiji_no_from) && string.IsNullOrEmpty(f01VO.Baihen_shiji_no_to)))
			{
				String searchBaihenShijiNoFrom = f01VO.Baihen_shiji_no_from;
				String searchBaihenShijiNoTo = f01VO.Baihen_shiji_no_to;

				if (searchBaihenShijiNoFrom.Length > 10)
				{
					searchBaihenShijiNoFrom = searchBaihenShijiNoFrom.Substring(searchBaihenShijiNoFrom.Length-10, 10);
				}
				if (searchBaihenShijiNoTo.Length > 10)
				{
					searchBaihenShijiNoTo = searchBaihenShijiNoTo.Substring(searchBaihenShijiNoTo.Length-10, 10);
				}

				// 売変指示No From
				if (string.IsNullOrEmpty(searchBaihenShijiNoFrom))
				{
					searchBaihenShijiNoFrom = "000000000000000000000000";
				}

				// 売変指示No To
				if (string.IsNullOrEmpty(searchBaihenShijiNoTo))
				{
					searchBaihenShijiNoTo = "999999999999999999999999";
				}

				sRepSql.Append(" AND T1.BAIHEN_NO BETWEEN :").Append(sRepId).Append("_SHIJI_NO_FROM").Append(" AND :").Append(sRepId).Append("_SHIJI_NO_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_SHIJI_NO_FROM";
				bindVO.Value = BoSystemFormat.formatBaihen_shiji_no(searchBaihenShijiNoFrom);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_SHIJI_NO_TO";
				bindVO.Value = BoSystemFormat.formatBaihen_shiji_no(searchBaihenShijiNoTo);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			#endregion

			#region 申請担当者コード (店舗売変予定TBLの場合のみ参照)

			// 申請担当者コード
			if (sRepId.Equals(Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0020))
			{
				if (!string.IsNullOrEmpty(f01VO.Sinseitan_cd))
				{
					sRepSql.Append(" AND T1.SINSEITAN_CD = :").Append(sRepId).Append("_SINSEITAN_CD");

					bindVO = new BindInfoVO();
					bindVO.BindId = sRepId + "_SINSEITAN_CD";
					bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Sinseitan_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			#endregion

			#region 作業開始日 From - To　売変理由は期間売変以外(売価変更指示TBLの場合のみ参照)

			// 作業開始日 From - To　売変理由は期間売変以外(売価変更指示TBLの場合のみ参照)
			if (sRepId.Equals(Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0010))
			{
				if (!(string.IsNullOrEmpty(f01VO.Baihensagyokaisi_ymd_from) && string.IsNullOrEmpty(f01VO.Baihensagyokaisi_ymd_to)))
				{
					String searchSagyoKaisiDateFrom = BoSystemFormat.formatDate(f01VO.Baihensagyokaisi_ymd_from);
					String searchSagyoKaisiDateTo = BoSystemFormat.formatDate(f01VO.Baihensagyokaisi_ymd_to);

					// 売変作業開始日 From
					if (string.IsNullOrEmpty(f01VO.Baihensagyokaisi_ymd_from))
					{
						searchSagyoKaisiDateFrom = "0";
					}

					// 売変作業開始日 To
					if (string.IsNullOrEmpty(f01VO.Baihensagyokaisi_ymd_to))
					{
						searchSagyoKaisiDateTo = "99999999";
					}

					sRepSql.Append(" AND T1.BAIHENSAGYOKAISI_YMD BETWEEN :").Append(sRepId).Append("_SAGYOKAISI_FROM").Append(" AND :").Append(sRepId).Append("_SAGYOKAISI_TO");
					sRepSql.Append(" AND T1.BAIHENSAGYOKAISI_YMD <> '99999999'");

					bindVO = new BindInfoVO();
					bindVO.BindId = sRepId + "_SAGYOKAISI_FROM";
					bindVO.Value = searchSagyoKaisiDateFrom;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = sRepId + "_SAGYOKAISI_TO";
					bindVO.Value = searchSagyoKaisiDateTo;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 売変理由が期間売変は対象外とする。
				sRepSql.Append(" AND T1.BAIHEN_RIYTU <> :").Append(sRepId).Append("_BAIHEN_RIYTU");

				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_BAIHEN_RIYTU";
				bindVO.Value = ConditionBaihen_riytu.VALUE_BAIHEN_RIYTU3;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 開始日 From - To

			// 開始日 From - To
			if (!(string.IsNullOrEmpty(f01VO.Baihenkaisi_ymd_from) && string.IsNullOrEmpty(f01VO.Baihenkaisi_ymd_to)))
			{

				String searchKaisiDateFrom = BoSystemFormat.formatDate(f01VO.Baihenkaisi_ymd_from);
				String searchKaisiDateTo = BoSystemFormat.formatDate(f01VO.Baihenkaisi_ymd_to);

				// 開始日 From
				if (string.IsNullOrEmpty(searchKaisiDateFrom))
				{
					searchKaisiDateFrom = "0";
				}

				// 開始日 To
				if (string.IsNullOrEmpty(searchKaisiDateTo))
				{
					searchKaisiDateTo = "99999999";
				}

				sRepSql.Append(" AND T1.BAIHENKAISI_YMD BETWEEN  :").Append(sRepId).Append("_KAISI_YMD_FROM").Append(" AND :").Append(sRepId).Append("_KAISI_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_KAISI_YMD_FROM";
				bindVO.Value = searchKaisiDateFrom;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_KAISI_YMD_TO";
				bindVO.Value = searchKaisiDateTo;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			#endregion

			#region その他条件

			// 確定フラグ = 0(未確定)
			sRepSql.Append(" AND T1.KAKUTEI_FLG = 0");

			// 売価変更指示TBLの場合の条件
			if (sRepId.Equals(Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0010))
			{
				// 緊急売変を除く（指示テーブル参照時のみ）
				sRepSql.Append(" AND T1.ADD_KBN = 1");

				// 固定条件
				sRepSql.Append(" AND EXISTS (");
				sRepSql.Append(" 	SELECT 1");
				sRepSql.Append(" 	FROM");
				sRepSql.Append("		 MDMT0130");
				sRepSql.Append(" 		,STMT0091");
				sRepSql.Append("  	WHERE");
				sRepSql.Append(" 		MDMT0130.XEBIO_CD      = T1.JISYA_HBN");
				sRepSql.Append(" 	AND	MDMT0130.MAKERCOLOR_CD = T1.IRO_CD");
				sRepSql.Append(" 	AND	STMT0091.SOSIKI        = '0001'");
				sRepSql.Append(" 	AND	STMT0091.TENCD         = :").Append(sRepId).Append("_TEN_CD_01");
				sRepSql.Append(" 	AND	STMT0091.SKU           = MDMT0130.JAN_CD");
				sRepSql.Append("  )");

				// 指示売価=現売価
				sRepSql.Append(" AND( ");
				if (BoSystemConstant.CHECKBOX_OFF.Equals(f01VO.Genbaika_shijibaika_flg))
				{
					sRepSql.Append("		(	T1.SIJIBAIKA_TNK <> T1.GENBAIKA_TNK");
				}
				else if (BoSystemConstant.CHECKBOX_ON.Equals(f01VO.Genbaika_shijibaika_flg)) 
				{
					sRepSql.Append("		(	T1.SIJIBAIKA_TNK = T1.GENBAIKA_TNK");
				}
				sRepSql.Append("		AND	T1.ADD_KBN = '1'");
				sRepSql.Append("		) OR	");
				sRepSql.Append(" 		(");
				sRepSql.Append(" 			T1.ADD_KBN = '2'");
				sRepSql.Append("		)");
				sRepSql.Append(" )	");

				sRepSql.Append(" AND( ");
			// 本部指示の場合在庫数>0の条件を入れる
				sRepSql.Append("		((");
				sRepSql.Append(" 			CASE");
				sRepSql.Append("				WHEN T1.KAKUTEI_FLG = 0 THEN");
				sRepSql.Append("				( NVL((SELECT SUM(MDBT0030.FREEZAIKO_SU) FROM MDBT0030 WHERE MDBT0030.TENPO_CD = :TEN_CD_02 AND MDBT0030.TENPO_CD = T1.TENPO_CD AND MDBT0030.JISYA_HBN = T1.JISYA_HBN AND MDBT0030.IRO_CD = T1.IRO_CD), 0)");
				sRepSql.Append(" 				+ NVL((SELECT SUM(MDBT0040.FREEZAIKO_SU) FROM MDBT0040 WHERE MDBT0040.TENPO_CD = :TEN_CD_03 AND MDBT0040.TENPO_CD = T1.TENPO_CD AND MDBT0040.JISYA_HBN = T1.JISYA_HBN AND MDBT0040.IRO_CD = T1.IRO_CD), 0)");
				sRepSql.Append(" 				+ NVL((SELECT SUM(MDBT0060.FREEZAIKO_SU) FROM MDBT0060 WHERE MDBT0060.TENPO_CD = :TEN_CD_04 AND MDBT0060.TENPO_CD = T1.TENPO_CD AND MDBT0060.JISYA_HBN = T1.JISYA_HBN AND MDBT0060.IRO_CD = T1.IRO_CD), 0))");
				sRepSql.Append("				ELSE");
				sRepSql.Append(" 					T1.ZAIKO_SU");
				sRepSql.Append(" 			END");
				sRepSql.Append(" 		) > 0");
				sRepSql.Append(" 		AND	T1.ADD_KBN = '1'");
				sRepSql.Append("		) OR	");
				sRepSql.Append(" 		(");
				sRepSql.Append(" 			T1.ADD_KBN = '2'");
				sRepSql.Append(" 		)");
				sRepSql.Append(" )	");

				//	店舗コード1
				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_TEN_CD_01";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				
				//	店舗コード2
				bindVO = new BindInfoVO();
				bindVO.BindId = "TEN_CD_02";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				//	店舗コード3
				bindVO = new BindInfoVO();
				bindVO.BindId = "TEN_CD_03";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				//	店舗コード4
				bindVO = new BindInfoVO();
				bindVO.BindId = "TEN_CD_04";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 店舗売変予定TBLの場合の条件
			if (sRepId.Equals(Tl030p01Constant.SQL_ID_01_REP_WHERE_MDCT0020))
			{
				// 固定条件
				sRepSql.Append(" AND EXISTS (");
				sRepSql.Append(" 	SELECT 1");
				sRepSql.Append(" 	FROM");
				sRepSql.Append("		 MDMT0130");
				sRepSql.Append(" 		,STMT0091");
				sRepSql.Append("  	WHERE");
				sRepSql.Append(" 		MDMT0130.XEBIO_CD      = T1.JISYA_HBN");
				sRepSql.Append(" 	AND	MDMT0130.MAKERCOLOR_CD = T1.IRO_CD");
				sRepSql.Append(" 	AND	STMT0091.SOSIKI        = '0001'");
				sRepSql.Append(" 	AND	STMT0091.TENCD         = :").Append(sRepId).Append("_TEN_CD_01");
				sRepSql.Append(" 	AND	STMT0091.SKU           = MDMT0130.JAN_CD");
				sRepSql.Append("  )");

				// 指示売価=現売価
				if (BoSystemConstant.CHECKBOX_OFF.Equals(f01VO.Genbaika_shijibaika_flg))
				{
					sRepSql.Append(" AND		T1.SIJIBAIKA_TNK <> T1.GENBAIKA_TNK");
				}
				else if (BoSystemConstant.CHECKBOX_ON.Equals(f01VO.Genbaika_shijibaika_flg))
				{
					sRepSql.Append(" AND		T1.SIJIBAIKA_TNK = T1.GENBAIKA_TNK");
				}

				//	店舗コード1
				bindVO = new BindInfoVO();
				bindVO.BindId = sRepId + "_TEN_CD_01";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			BoSystemSql.AddSql(reader, sRepId, sRepSql.ToString(), bindList);

		}
		#endregion

		#region SELECT条件設定
		/// <summary>
		/// AddSelect SELECT条件設定
		/// </summary>
		/// <param name="Tl030f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="String">リプレースID</param>
		/// <returns></returns>
		private void AddSelect(Tl030f01Form f01VO, FindSqlResultTable reader, String sRepId)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			sRepSql.Append(" 	,SUM(");
			sRepSql.Append(" 		  NVL((SELECT SUM(MDBT0030.FREEZAIKO_SU) FROM MDBT0030 WHERE MDBT0030.TENPO_CD = :").Append(sRepId).Append("_TENPO_CD_01").Append(" AND MDBT0030.TENPO_CD = T1.TENPO_CD AND MDBT0030.JISYA_HBN = T1.JISYA_HBN AND MDBT0030.IRO_CD = T1.IRO_CD), 0)");
			sRepSql.Append(" 		+ NVL((SELECT SUM(MDBT0040.FREEZAIKO_SU) FROM MDBT0040 WHERE MDBT0040.TENPO_CD = :").Append(sRepId).Append("_TENPO_CD_02").Append(" AND MDBT0040.TENPO_CD = T1.TENPO_CD AND MDBT0040.JISYA_HBN = T1.JISYA_HBN AND MDBT0040.IRO_CD = T1.IRO_CD), 0)");
			sRepSql.Append("		+ NVL((SELECT SUM(MDBT0060.FREEZAIKO_SU) FROM MDBT0060 WHERE MDBT0060.TENPO_CD = :").Append(sRepId).Append("_TENPO_CD_03").Append(" AND MDBT0060.TENPO_CD = T1.TENPO_CD AND MDBT0060.JISYA_HBN = T1.JISYA_HBN AND MDBT0060.IRO_CD = T1.IRO_CD), 0)");
			sRepSql.Append(" 	) ");

			//	店舗コード1
			bindVO = new BindInfoVO();
			bindVO.BindId = sRepId + "_TENPO_CD_01";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			//	店舗コード2
			bindVO = new BindInfoVO();
			bindVO.BindId = sRepId + "_TENPO_CD_02";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			//	店舗コード3
			bindVO = new BindInfoVO();
			bindVO.BindId = sRepId + "_TENPO_CD_03";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			BoSystemSql.AddSql(reader, sRepId, sRepSql.ToString(), bindList);

		}

		#endregion

		#region	シーケンスの採番
		/// <summary>
		/// シーケンスの採番を行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>シーケンス ※採番不可の場合は、-1を戻す</returns>
		private decimal AutoNumber_Seq(IFacadeContext facadeContext, LoginInfoVO loginInfo)
		{

			Boolean loop = true;
			decimal loopCnt = 0;
			string seq = string.Empty;

			while (loop)
			{
				// 採番を行う
				seq = NumberingCls.Numbering(
											facadeContext,
											BoSystemConstant.AUTONUM_BAIHENPC_SEQWK,
											"0000",
											loginInfo.LoginId
						);
				decimal dSeq = Convert.ToDecimal(seq);


				// 採番値が既にテーブルで使用されていないかチェック(※されている場合は次の番号を採番)
				// XMLからSQLを取得する。
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_03, facadeContext.DBContext);


				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				sRepSql.Append(" AND SEQ			= :BIND_SEQ");

				// 確定種別
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SEQ";
				bindVO.Value = dSeq.ToString();
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 追加の条件
				BoSystemSql.AddSql(reader, "ADD_WHERE1", sRepSql.ToString(), bindList);

				// SQL実行
				IList<Hashtable> ItemList = reader.Execute();

				if (ItemList == null || ItemList.Count <= 0)
				{
					// シーケンスが未存在の場合、採番OK
					loop = false;
				}
				else
				{
					Hashtable ht = (Hashtable)ItemList[0];
					if ((decimal)ht["CNT"] <= 0)
					{
						// シーケンスが未存在の場合、採番OK
						loop = false;
					}
				}

				loopCnt++;

				if (loopCnt >= 999999)
				{
					// 採番可能数を超えた場合、処理終了
					return -1;
				}
			}
			return Convert.ToDecimal(BoSystemString.Nvl(seq, "-1"));
		}

		#endregion

		#endregion


	}
}
