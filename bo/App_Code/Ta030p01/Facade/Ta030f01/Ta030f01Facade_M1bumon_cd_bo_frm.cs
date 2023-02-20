using com.xebio.bo.Ta030p01.Constant;
using com.xebio.bo.Ta030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Ta030p01.Facade
{
  /// <summary>
  /// Ta030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta030f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1bumon_cd_bo)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1bumon_cd_bo)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1BUMON_CD_BO_FRM(IFacadeContext facadeContext)
		{

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1BUMON_CD_BO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				//明細画面(Ta030f02)のデータを作成する。
				//SetMeisaiFormData(facadeContext);
				#region 明細画面(Ta030f02)のデータを作成する。
				/// <summary>
				/// 明細画面(Ta030f02)のデータを作成する。
				/// </summary>
				/// <param name="facadeContext">ファサードコンテキスト</param>

				//BoSystemLog.logOut("");
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Ta030f01Form prevVo = (Ta030f01Form)facadeContext.FormVO;
				Ta030f02Form nextVo = (Ta030f02Form)facadeContext.GetUserObject(Ta030p01Constant.FCDUO_NEXTVO);
				//Ta030f02Form nextVo = (Ta030f02Form)facadeContext.FormVO;

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");
				// 選択行の情報を取得する。
				Ta030f01M1Form prevM1Vo = (Ta030f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// Dictionaryから検索条件を取得
				String tenpoCd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
				String tenpoNm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 検索処理
			
				#region SQLID設定
				FindSqlResultTable rtSearch = new FindSqlResultTable();
				ArrayList bindList = new ArrayList();
				BindInfoVO	bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;


				BoSystemLog.logOut("[補充依頼結果TBL(B)]を検索 START");

				//[区分]が補充依頼または単品レポートの場合
				//if (prevVo.Kbn_cd.Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN21) || prevVo.Kbn_cd.Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN22))
				if (prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1KBN_CD].Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN21) || prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1KBN_CD].Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN22))
				{
					//「申請状態」が未申請の場合（SQL①）
					if (prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1SHINSEI_FLG].Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1))
					{
						rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_01, facadeContext.DBContext);
						AddWhere_DETAIL(prevM1Vo, rtSearch, Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE);

					}
					//「申請状態」が申請済の場合（SQL②）
					else
					{
						rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_02, facadeContext.DBContext);
						AddWhere_DETAIL(prevM1Vo, rtSearch, Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE);
					}
				}
				//[区分]が出荷要望の場合
				else
				{
					//「申請状態」が未申請の場合（SQL③）
					if (prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1SHINSEI_FLG].Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1))
					{
						rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_03, facadeContext.DBContext);
						AddWhere_DETAIL(prevM1Vo, rtSearch, Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE);
					}
					//「申請状態」が申請済の場合（SQL④）
					else
					{
						rtSearch = FindSqlUtil.CreateFindSqlResultTable(Ta030p01Constant.SQL_DETAIL_ID_04, facadeContext.DBContext);
						AddWhere_DETAIL(prevM1Vo, rtSearch, Ta030p01Constant.SQL_DETAIL_ID_04_ADD_WHERE);

					}
				}
				BoSystemLog.logOut("[補充依頼結果TBL(B)]を検索 END");




				// バインド値の置き換え


				////店舗コード
				////rtSearch.BindValue(Ta030p01Constant.SQL_REP_TENPO_CD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1TENPO_CD]));
				//rtSearch.BindValue(Ta030p01Constant.SQL_REP_TENPO_CD, BoSystemFormat.formatTenpoCd(prevVo.Head_tenpo_cd));
				//// 区分
				//rtSearch.BindValue(Ta030p01Constant.SQL_REP_KBN_CD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1KBN_CD]));
				//// 申請状態
				//// [区分]が(1:補充発注 2:単品レポート)の場合のみ設定
				//if (prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1KBN_CD].Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN21) || prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1KBN_CD].Equals(ConditionHojuirai_kbn2.VALUE_HOJUIRAI_KBN22))
				//{
				//	rtSearch.BindValue(Ta030p01Constant.SQL_REP_SHINSEI_FLG, Convert.ToDecimal((string)prevM1Vo.Dictionary[Ta030p01Constant.DIC_M1SHINSEI_FLG]));
				//}

				//// 「仕入先コード」が空白でない場合のみ適用
				//if (!string.IsNullOrEmpty(prevVo.Siiresaki_cd))
				//{
				//	// 「仕入先コード」を設定
				//	sRepSql.Append(" AND  EXISTS ( ");
				//	sRepSql.Append("       SELECT 1");
				//	sRepSql.Append("       FROM MDMT0130 M1");
				//	sRepSql.Append("       WHERE M1.JAN_CD = T2.JAN_CD");
				//	sRepSql.Append("       AND    M1.SIIRESAKI_CD = ");
				//	rtSearch.BindValue(Ta030p01Constant.SQL_REP_SIIRESAKI_CD_str, (string)sRepSql.ToString().Replace("'", ""));
				//	rtSearch.BindValue(Ta030p01Constant.SQL_REP_SIIRESAKI_CD, BoSystemFormat.formatSiiresakiCd(prevVo.Siiresaki_cd));
				//	rtSearch.BindValue(Ta030p01Constant.SQL_REP_SIIRESAKI_CD_end, (string)" 	  )".Replace("'", ""));
				//}



				

				//検索結果を取得します
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtSearch.Execute();

				if (logger.IsDebugEnabled)
				{
					logger.Debug("SQL: " + rtSearch.LogSql);
				}

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					//Hashtable resultTbl = tableListcnt.Count;
					dCnt = (Decimal)tableListcnt.Count;

					//0件チェック
					if (dCnt <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					//else
					//{
					//	// 最大件数チェック
					//	V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
					//}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion


				#region 検索結果の表示
				//検索結果を取得します
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableList = rtSearch.Execute();

				decimal sumSuryoGokei = 0;	    // 数量合計
				decimal sumKingakuGokei = 0;	// 金額合計

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Ta030f02M1Form f02m1VO = new Ta030f02M1Form();

					f02m1VO.M1rowno = iCnt.ToString();								// Ｍ１行NO
					f02m1VO.M1hojuirai_kbn_nm = rec["KBN_NM"].ToString();			// Ｍ１区分
					f02m1VO.M1sinsei_jotainm = rec["SHINSEI_NM"].ToString();	    // Ｍ１状態区分

					f02m1VO.M1bumon_cd_bo = rec["BUMON_CD"].ToString();				// Ｍ１部門コード
					f02m1VO.M1bumonkana_nm = rec["BUMON_NM"].ToString();			// Ｍ１部門名
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種名
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();			// Ｍ１ブランド
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
					f02m1VO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();	// Ｍ１コア(商品属性）
					f02m1VO.M1maker_hbn = rec["HIN_NBR"].ToString();				// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名
					f02m1VO.M1iro_nm = rec["IRO_RYAKU_NM"].ToString();				// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード
					f02m1VO.M1itemsu = rec["IRAI_SU"].ToString();					// Ｍ１数量
					f02m1VO.M1kingaku = rec["IRAI_KIN"].ToString();					// Ｍ１金額
					f02m1VO.M1hattyu_ymd = rec["UPD_YMD"].ToString();				// Ｍ１発注日
					f02m1VO.M1hanbaiin_nm = rec["HANBAIIN_NM"].ToString();			// Ｍ１担当者
					
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)

					// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１確定処理フラグ(隠し)
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					// Ｍ１明細色区分(隠し)
					string xebiocd = (string)prevVo.Dictionary[Ta030p01Constant.DIC_SEARCH_XEBIOCD];
					string jancd = (string)prevVo.Dictionary[Ta030p01Constant.DIC_SEARCH_JANCD];
					if (xebiocd.Equals(f02m1VO.M1jisya_hbn) || jancd.Equals(f02m1VO.M1scan_cd))
					{
						// 一覧画面で入力されたスキャンコードが一致する場合、背景色変更
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)
					}
					else
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
					}

					// Dictionary
					f02m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1BUMON_CD, rec["BUMON_CD"].ToString());		// 部門コード
					f02m1VO.Dictionary.Add(Ta030p01Constant.DIC_M1BUMONKANA_NM, rec["BUMON_NM"].ToString());	// 部門カナ名                    				
					// 選択明細のVO
					nextVo.Dictionary[Ta030p01Constant.DIC_M1SELCETVO] = prevM1Vo;
					// 選択行のインデックスを設定
					nextVo.Dictionary[Ta030p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

					// 合計値加算
					sumSuryoGokei += Convert.ToDecimal(f02m1VO.M1itemsu);
					sumKingakuGokei += Convert.ToDecimal(f02m1VO.M1kingaku);

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				}

				// 合計欄の設定
				nextVo.Gokei_itemsu = sumSuryoGokei.ToString();
				nextVo.Gokei_kingaku = sumKingakuGokei.ToString();

				// 選択モードNoを明細画面のディクショナリに設定
				nextVo.Dictionary[Ta030p01Constant.DIC_MODENO] = prevVo.Stkmodeno;		//選択モードNo

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(prevVo);

				#endregion

				#region カード部設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = tenpoCd;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = tenpoNm;
				#endregion


				#endregion
				#endregion


				//一覧画面戻り時のフォーカス項目
				Ta030f01Form f01VO = (Ta030f01Form)facadeContext.FormVO;
				f01VO.Dictionary[Ta030p01Constant.DIC_FOCUS_ITEM] = "M1bumon_cd_bo";
				
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1BUMON_CD_BO_FRM");
		}
		#endregion

		#region 検索条件設定
		private void AddWhere_DETAIL(Ta030f01M1Form preM1Vo, FindSqlResultTable reader, string add_where_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 検索条件を設定 -----------
			sRepSql = new StringBuilder();

			// バインド変数
			string add_bind = "";
			if (add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE))
			{
				add_bind = "01";
			}
			else if (add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE))
			{
				add_bind = "02";
			}
			else if (add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE))
			{
				add_bind = "03";
			}
			else if (add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_04_ADD_WHERE))
			{
				add_bind = "04";
			}

			// 「店舗コード」を設定
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD_" + add_bind);
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD_" + add_bind;
			bindVO.Value = BoSystemFormat.formatTenpoCd((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1TENPO_CD]);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			//// 区分を設定
			// 補充発注申請または補充依頼確定の場合のみ設定
			if (add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_02_ADD_WHERE))
			{ 
			sRepSql.Append(" AND T1.KBN_CD = :BIND_KBN_CD_" + add_bind);
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_KBN_CD_" + add_bind;
			//bindVO.Value = (string)f03VO.Dictionary[Ta030p01Constant.DIC_M1KBN_CD];
			bindVO.Value = (string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1KBN_CD];
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			}

			//// 申請状態を設定
			// 補充発注申請または出荷要望申請の場合のみ適用
			if (add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_01_ADD_WHERE) || add_where_id.Equals(Ta030p01Constant.SQL_DETAIL_ID_03_ADD_WHERE))
			{
				sRepSql.Append(" AND T1.SHINSEI_FLG = :BIND_SHINSEI_FLG_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SHINSEI_FLG_" + add_bind;
				bindVO.Value = "0";
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);				
			}

			// 「仕入先コード」を設定
			// 「仕入先コード」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1SIIRESAKI_CD]))
			{
				sRepSql.Append(" AND  EXISTS ( ");
				sRepSql.Append("       SELECT 1");
				sRepSql.Append("       FROM MDMT0130 M1");
				sRepSql.Append("       WHERE M1.JAN_CD = T2.JAN_CD");
				sRepSql.Append("       AND    M1.SIIRESAKI_CD = :BIND_SIIRESAKI_CD_" + add_bind);
				sRepSql.Append(" 	  )");
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatSiiresakiCd((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1SIIRESAKI_CD]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 「部門コード」を設定
			// 「部門コード」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1BUMON_CD]))
			{
				sRepSql.Append(" AND T2.BUMON_CD = :BIND_BUMON_CD_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatBumonCd((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1BUMON_CD]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 「ブランドコード」を設定
			// 「ブランドコード」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1BURANDO_CD]))
			{
				sRepSql.Append(" AND T2.BURANDO_CD = :BIND_BURANDO_CD_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatBrandCd((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1BURANDO_CD]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			//「発注日FROM」を設定
			// 「発注日FROM」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1UPD_YMD_FROM]))
			{
				sRepSql.Append(" AND T1.UPD_YMD >= :BIND_UPD_YMD_FROM_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_FROM_" + add_bind;
				bindVO.Value = BoSystemFormat.formatDate((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1UPD_YMD_FROM]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			//「発注日TO」を設定
			// 「発注日TO」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1UPD_YMD_TO]))
			{
				sRepSql.Append(" AND T1.UPD_YMD <= :BIND_UPD_YMD_TO_" + add_bind);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_TO_" + add_bind;
				bindVO.Value = BoSystemFormat.formatDate((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1UPD_YMD_TO]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 「自社品番」を設定
			// 「自社品番」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1JISYA_HBN]))
			{
				// [自社品番]が10桁の場合
				if (preM1Vo.Dictionary[Ta030p01Constant.DIC_M1JISYA_HBN].ToString().Length == 10)
				{
					sRepSql.Append(" AND  EXISTS ( ");
					sRepSql.Append("       SELECT 1");
					sRepSql.Append("       FROM MDMT0130 M1");
					sRepSql.Append("       WHERE M1.JAN_CD = T2.JAN_CD");
					sRepSql.Append("       AND   M1.OLD_XEBIO_CD = :BIND_JISYA_HBN_" + add_bind);
					sRepSql.Append(" 	  )");
				}
				else
				{
					sRepSql.Append("AND	T2.JISYA_HBN = :BIND_JISYA_HBN_" + add_bind);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JISYA_HBN_" + add_bind;
				bindVO.Value = BoSystemFormat.formatJisyaHbn((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1JISYA_HBN]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 「スキャンコード」を設定
			// 「スキャンコード」が空白でない場合のみ適用
			if (!string.IsNullOrEmpty((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1JAN_CD]))
			{
				// [スキャンコード]が13桁の場合、JANで検索
				if (preM1Vo.Dictionary[Ta030p01Constant.DIC_M1JAN_CD].ToString().Length == 13)
				{
					sRepSql.Append(" AND T2.JAN_CD = :BIND_JAN_CD_" + add_bind);
				}
				// [スキャンコード]が18桁の場合、商品コードで検索
				else
				{
					sRepSql.Append(" AND T2.SYOHIN_CD = :BIND_JAN_CD_" + add_bind);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JAN_CD_" + add_bind;
				bindVO.Value = BoSystemFormat.formatJanCd((string)preM1Vo.Dictionary[Ta030p01Constant.DIC_M1JAN_CD]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}


			BoSystemSql.AddSql(reader, add_where_id, sRepSql.ToString(), bindList);


		}
		#endregion


	}
}
