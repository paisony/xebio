using com.xebio.bo.Tj030p01.Constant;
using com.xebio.bo.Tj030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
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
using System.Text;

namespace com.xebio.bo.Tj030p01.Facade
{
  /// <summary>
  /// Tj030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj030f01Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj030f01Form f01VO = (Tj030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				#endregion

				#region 業務チェック

				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL))
				{
					// 取消モードの場合
					// 店舗／業者、送信日、送信状態の条件を初期化
					f01VO.Tenpo_gyosya_kb = BoSystemConstant.DROPDOWNLIST_MISENTAKU;
					f01VO.Sosin_ymd_from = String.Empty;
					f01VO.Sosin_ymd_to = String.Empty;
					f01VO.Sosin_jyotai = BoSystemConstant.DROPDOWNLIST_MISENTAKU;
				}

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

				// 1-2 棚段FROM
				// 1～10の範囲内でない場合、エラー
				if (!string.IsNullOrEmpty(f01VO.Tana_dan_from))
				{
					if (!IsRange(Convert.ToDecimal((string)f01VO.Tana_dan_from), 1, BoSystemConstant.TANA_DAN_MAX_V))
					{
						ErrMsgCls.AddErrMsg("E173", new[] { "棚段FROM", "1", BoSystemConstant.TANA_DAN_MAX_V.ToString() }, facadeContext, new[] { "Tana_dan_from" });
					}
				}

				// 1-3 棚段TO
				// 1～10の範囲内でない場合、エラー
				if (!string.IsNullOrEmpty(f01VO.Tana_dan_to))
				{
					if (!IsRange(Convert.ToDecimal((string)f01VO.Tana_dan_to), 1, BoSystemConstant.TANA_DAN_MAX_V))
					{
						ErrMsgCls.AddErrMsg("E173", new[] { "棚段TO", "1", BoSystemConstant.TANA_DAN_MAX_V.ToString() }, facadeContext, new[] { "Tana_dan_to" });
					}
				}
				// 1-4 入力担当者コード
				// 担当者MSTを検索し、存在しない場合エラー
				f01VO.Nyuryokutan_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Nyuryokutan_cd
														, facadeContext
														, string.Empty
														, null
														, "入力担当者"
														, new[] { "Nyuryokutan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Nyuryokutan_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 自社品番、スキャンコード存在チェック用
				// 発注条件VOを定義
				SearchHachuVO searchConditionVO = new SearchHachuVO();
				searchConditionVO.Tencd = f01VO.Head_tenpo_cd;	// 店舗コード

				// 1-5 旧自社品番、旧自社品番2、旧自社品番3、旧自社品番4、旧自社品番5
				// 発注MSTを検索し、存在しない場合エラー
			
				// 旧自社品番
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD1] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					searchConditionVO.Scancd = f01VO.Old_jisya_hbn;	// 旧自社品番
					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番1", new[] { "Old_jisya_hbn" });
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD1] = (string)resultHash["XEBIO_CD"];
					}
				}

				// 旧自社品番２
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD2] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
				{
					searchConditionVO.Scancd = f01VO.Old_jisya_hbn2;	// 旧自社品番２
					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番2", new[] { "Old_jisya_hbn2" });
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD2] = (string)resultHash["XEBIO_CD"];
					}
				}

				// 旧自社品番３
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD3] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
				{
					searchConditionVO.Scancd = f01VO.Old_jisya_hbn3;	// 旧自社品番３
					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番3", new[] { "Old_jisya_hbn3" });
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD3] = (string)resultHash["XEBIO_CD"];
					}
				}

				// 旧自社品番４
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD4] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
				{
					searchConditionVO.Scancd = f01VO.Old_jisya_hbn4;	// 旧自社品番４
					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番4", new[] { "Old_jisya_hbn4" });
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD4] = (string)resultHash["XEBIO_CD"];
					}
				}

				// 旧自社品番５
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD5] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
				{
					searchConditionVO.Scancd = f01VO.Old_jisya_hbn5;	// 旧自社品番５
					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番5", new[] { "Old_jisya_hbn5" });
					if (resultHash != null)
					{
						// 自社品番をディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD5] = (string)resultHash["XEBIO_CD"];
					}
				}

				// 1-6 スキャンコード、スキャンコード2、スキャンコード3、スキャンコード4、スキャンコード5
				// 発注MSTを検索し、存在しない場合エラー

				// スキャンコード
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD1] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					searchConditionVO.Scancd = f01VO.Scan_cd;	// スキャンコード
					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ1", new[] { "Scan_cd" });
					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD1] = (string)resultHash["JAN_CD"];
					}
				}

				// スキャンコード２
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD2] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd2))
				{
					searchConditionVO.Scancd = f01VO.Scan_cd2;	// スキャンコード２
					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ2", new[] { "Scan_cd2" });
					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD2] = (string)resultHash["JAN_CD"];
					}
				}

				// スキャンコード３
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD3] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd3))
				{
					searchConditionVO.Scancd = f01VO.Scan_cd3;	// スキャンコード３
					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ3", new[] { "Scan_cd3" });
					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD3] = (string)resultHash["JAN_CD"];
					}
				}

				// スキャンコード４
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD4] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd4))
				{
					searchConditionVO.Scancd = f01VO.Scan_cd4;	// スキャンコード４
					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ4", new[] { "Scan_cd4" });
					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD4] = (string)resultHash["JAN_CD"];
					}
				}

				// スキャンコード５
				f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD5] = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Scan_cd5))
				{
					searchConditionVO.Scancd = f01VO.Scan_cd5;	// スキャンコード５
					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ5", new[] { "Scan_cd5" });
					if (resultHash != null)
					{
						// JANコードをディクショナリに退避
						f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD5] = (string)resultHash["JAN_CD"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連チェック(1)

				// 2-1 フェイスＮｏFROM、フェイスＮｏTO
				// フェイスＮｏFROM > フェイスＮｏTOの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Face_no_from) && !string.IsNullOrEmpty(f01VO.Face_no_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Face_no_from,
									f01VO.Face_no_to,
									facadeContext,
									"フェイスＮｏ",
									new[] { "Face_no_from", "Face_no_to" }
									);
				}

				// 2-2 棚段FROM、棚段TO
				// 棚段ＦＲＯＭ > 棚段ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tana_dan_from) && !string.IsNullOrEmpty(f01VO.Tana_dan_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Tana_dan_from,
									f01VO.Tana_dan_to,
									facadeContext,
									"棚段",
									new[] { "Tana_dan_from", "Tana_dan_to" }
									);
				}

				// 2-3 入力日FROM、入力日TO
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

				// 2-4 送信日FROM、送信日TO
				// 送信日ＦＲＯＭ > 送信日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Sosin_ymd_from) && !string.IsNullOrEmpty(f01VO.Sosin_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Sosin_ymd_from,
									f01VO.Sosin_ymd_to,
									facadeContext,
									"送信日",
									new[] { "Sosin_ymd_from", "Sosin_ymd_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連チェック(2)
				//// 3-1 店舗／業者区分
				//// モードが取消の時、業者を選択した場合、エラー
				//if (f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL)
				//	&& f01VO.Tenpo_gyosya_kb.Equals(ConditionTenpo_gyosya_kbn.VALUE_GYOSYA))
				//{
				//	ErrMsgCls.AddErrMsg("E155", "取消", facadeContext, new[] { "Tenpo_gyosya_kb" });
				//}

				////エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				//if (MessageDisplayUtil.HasError(facadeContext))
				//{
				//	return;
				//}
				#endregion

				#region 棚卸実施日TBL取得、棚卸終了チェック

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 棚卸実施日TBL取得
				Hashtable hashTable = new Hashtable();

				int iErrF = 0;
				hashTable = SearchInventory.SearchMdit0030(f01VO.Head_tenpo_cd, sysDateVO.Sysdate.ToString(), facadeContext, iErrF);
				String tanaorosikijun_Ymd = "-1";

				if (hashTable != null)
				{
					tanaorosikijun_Ymd = hashTable["TANAOROSIKIJUN_YMD"].ToString();
				}

				// 棚卸終了チェック
				// 取消モードの場合、
				iErrF = 1;
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL)) {
					SearchInventory.CheckInventoryEnd(f01VO.Head_tenpo_cd, tanaorosikijun_Ymd, facadeContext, iErrF);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 件数チェック

				// 検索件数
				Decimal dCnt = 0;

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj030p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 検索条件設定
				// 店舗用WHERE句設定
				AddWhere(f01VO, rtChk, hashTable, ConditionTenpo_gyosya_kbn.VALUE_TENPO);
				// 業者用用WHERE句設定
				AddWhere(f01VO, rtChk, hashTable, ConditionTenpo_gyosya_kbn.VALUE_GYOSYA);

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

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj030p01Constant.SQL_ID_02, facadeContext.DBContext);

				// 検索条件設定
				// 店舗用WHERE句設定
				AddWhere(f01VO, rtSeach, hashTable, ConditionTenpo_gyosya_kbn.VALUE_TENPO);
				// 業者用用WHERE句設定
				AddWhere(f01VO, rtSeach, hashTable, ConditionTenpo_gyosya_kbn.VALUE_GYOSYA);

				// スキャン数設定
				// 店舗用設定
				AddScan_Su(f01VO, rtSeach, ConditionTenpo_gyosya_kbn.VALUE_TENPO);
				// 業者用設定
				AddScan_Su(f01VO, rtSeach, ConditionTenpo_gyosya_kbn.VALUE_GYOSYA);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tj030f01M1Form f01m1VO = new Tj030f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
					f01m1VO.Dictionary.Add(Tj030p01Constant.DIC_M1FACE_NO, rec["FACE_NO"].ToString().PadLeft(5, '0'));	// Ｍ１フェイスNoリンク
					f01m1VO.M1tana_dan = rec["TANA_DAN"].ToString();													// Ｍ１棚段
					f01m1VO.M1kai_su = rec["KAI_SU"].ToString();														// Ｍ１回数
					f01m1VO.M1scan_su = rec["TANAOROSIGOKEI_SU"].ToString();											// Ｍ１スキャン数量
					f01m1VO.M1nyuryokutan_nm = rec["HANBAIIN_NM"].ToString();											// Ｍ１入力担当者名称
					f01m1VO.M1nyuryoku_ymd = rec["ADD_YMD"].ToString();													// Ｍ１入力日
					f01m1VO.M1sosin_ymd = BoSystemString.ZeroToEmpty(rec["SOSIN_YMD"].ToString());						// Ｍ１送信日
					// 送信依頼が0の場合、設定されていても表示しない
					if (("0").Equals(rec["SOSINIRAI_FLG"].ToString()))
					{
						f01m1VO.M1sosin_ymd = string.Empty;
					}

					// 業者データの場合"○"を設定
					if (ConditionTenpo_gyosya_kbn.VALUE_GYOSYA.Equals(rec["DATASB"].ToString()))
					{
						f01m1VO.M1gyosya = "○";																		// Ｍ１業者
					}
					else
					{
						f01m1VO.M1gyosya = string.Empty;																// Ｍ１業者
					}
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;											// Ｍ１明細色区分(隠し)

					// 送信済み行は色変更
					if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(rec["DATASB"].ToString())
						&& ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;											// Ｍ１明細色区分(隠し)
					}

					// Dictionary 
					f01m1VO.Dictionary.Add(Tj030p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());					// Ｍ１更新日
					f01m1VO.Dictionary.Add(Tj030p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());					// Ｍ１更新時間
					f01m1VO.Dictionary.Add(Tj030p01Constant.DIC_M1TANAOROSI_YMD, rec["TANAOROSI_YMD"].ToString());		// Ｍ１棚卸日
					f01m1VO.Dictionary.Add(Tj030p01Constant.DIC_M1SOSINKAI_SU, rec["SOSINKAI_SU"].ToString());			// Ｍ１送信回数/処理日
					f01m1VO.Dictionary.Add(Tj030p01Constant.DIC_M1NYURYOKUTAN_CD, rec["ADDTAN_CD"].ToString());			// Ｍ１入力担当者コード
					f01m1VO.Dictionary.Add(Tj030p01Constant.DIC_M1TENPO_GYOSYA_KB, rec["DATASB"].ToString());			// Ｍ１店舗/業者区分

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				f01VO.Searchcnt = m1List.Count.ToString();

				//// 選択モードNO設定
				f01VO.Stkmodeno = f01VO.Modeno;
				#endregion

				#region 検索条件をDictionaryに設定

				// 検索時のformVOを保持
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				#endregion


				//トランザクションをコミットする。
				// CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				// RollbackTransaction(facadeContext);
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

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// 店舗抽出時はMDIT0010テーブル用の抽出条件、業者抽出時はMDIT0090テーブル用の抽出条件を設定します
		/// </summary>
		/// <param name="Tj030f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="Hashtable">searchMdit0030</param>
		/// <param name="String">tenpoGyosyaKb(1:店舗、2:業者)</param>
		/// <returns></returns>
		private void AddWhere(Tj030f01Form f01VO, FindSqlResultTable reader, Hashtable searchMdit0030 ,String tenpoGyosyaKb)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			String sREP_ID = String.Empty;
			String sTableId = String.Empty;

			// バインドIDを作成
			StringBuilder sbindId = new StringBuilder();

			#region 店舗抽出、業者抽出

			// 店舗、業者によって設定するWHERE句、テーブルを決定する
			if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
			{
				sREP_ID = Tj030p01Constant.SQL_ID_01_REP_ADD_WHERE_1;
				sTableId = "MDIT0011";	// [棚卸確定TBL(B)]
			}
			else
			{
				sREP_ID = Tj030p01Constant.SQL_ID_01_REP_ADD_WHERE_2;
				sTableId = "MDIT0091";	//  [業者棚卸TBL(B)]
			}


			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			// WHERE句を作成するかどうか判定する

			// 店舗
			if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
			{
				// モードが照会で[店舗／業者区分]が「業者」の場合作成しない(1=0の条件のみ設定し終了）
				if (f01VO.Tenpo_gyosya_kb.Equals(ConditionTenpo_gyosya_kbn.VALUE_GYOSYA)
					&& f01VO.Modeno.Equals(BoSystemConstant.MODE_REF))
				{
					sRepSql.Append("	AND 1 = 0");
					BoSystemSql.AddSql(reader, sREP_ID, sRepSql.ToString(), bindList);
					return;
				}

			}
			else
			{
				// [店舗／業者区分]が「店舗」の場合の場合作成しない(1=0の条件のみ設定し終了）
				if (f01VO.Tenpo_gyosya_kb.Equals(ConditionTenpo_gyosya_kbn.VALUE_TENPO))
				{
					sRepSql.Append("	AND 1 = 0");
					BoSystemSql.AddSql(reader, sREP_ID, sRepSql.ToString(), bindList);
					return;
				}

				// [選択モードNo]が「取消」の場合作成しない(1=0の条件のみ設定し終了）
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL))
				{
					sRepSql.Append("	AND 1 = 0");
					BoSystemSql.AddSql(reader, sREP_ID, sRepSql.ToString(), bindList);
					return;
				}
			}

			#endregion

			#region 店舗コード

			sbindId = new StringBuilder();
			sbindId.Append("BIND_TENPO_CD").Append(tenpoGyosyaKb.ToString());

			// 店舗コードを設定
			sRepSql.Append("	AND T1.TENPO_CD = :").Append(sbindId.ToString());

			bindVO = new BindInfoVO();
			bindVO.BindId = sbindId.ToString();
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region フェイス№FROM

			// フェイス№FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Face_no_from))
			{
				sbindId = new StringBuilder();
				sbindId.Append("BIND_FACE_NO_FROM").Append(tenpoGyosyaKb.ToString());

				sRepSql.Append(" AND T1.FACE_NO >= :").Append(sbindId.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = sbindId.ToString();
				bindVO.Value = f01VO.Face_no_from;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region フェイス№TO

			// フェイス№TOを設定
			if (!string.IsNullOrEmpty(f01VO.Face_no_to))
			{
				sbindId = new StringBuilder();
				sbindId.Append("BIND_FACE_NO_TO").Append(tenpoGyosyaKb.ToString());

				sRepSql.Append("	AND T1.FACE_NO <= :").Append(sbindId.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = sbindId.ToString();
				bindVO.Value = f01VO.Face_no_to;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 棚段FROM

			// 棚段FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Tana_dan_from))
			{
				sbindId = new StringBuilder();
				sbindId.Append("BIND_TANA_DAN_FROM").Append(tenpoGyosyaKb.ToString());

				sRepSql.Append("	AND T1.TANA_DAN >= :").Append(sbindId.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = sbindId.ToString();
				bindVO.Value = f01VO.Tana_dan_from;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 棚段TO

			// 棚段TOを設定
			if (!string.IsNullOrEmpty(f01VO.Tana_dan_to))
			{
				sbindId = new StringBuilder();
				sbindId.Append("BIND_TANA_DAN_TO").Append(tenpoGyosyaKb.ToString());

				sRepSql.Append("	AND T1.TANA_DAN <= :").Append(sbindId.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = sbindId.ToString();
				bindVO.Value = f01VO.Tana_dan_to;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 入力日FROM

			// 入力日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_from))
			{
				sbindId = new StringBuilder();
				sbindId.Append("BIND_NYURYOKU_YMD_FROM").Append(tenpoGyosyaKb.ToString());

				if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
				{
					sRepSql.Append("	AND T1.ADD_YMD >= :").Append(sbindId.ToString());
				}
				// 業者の場合入力日を見る
				else
				{
					sRepSql.Append("	AND T1.SYORI_YMD >= :").Append(sbindId.ToString());
				}

				bindVO = new BindInfoVO();
				bindVO.BindId = sbindId.ToString();
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 入力日TO

			// 入力日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_to))
			{
				sbindId = new StringBuilder();
				sbindId.Append("BIND_NYURYOKU_YMD_TO").Append(tenpoGyosyaKb.ToString());

				if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
				{
					sRepSql.Append("	AND T1.ADD_YMD <= :").Append(sbindId.ToString());
				}
				// 業者の場合入力日を見る
				else
				{
					sRepSql.Append("	AND T1.SYORI_YMD <= :").Append(sbindId.ToString());
				}

				bindVO = new BindInfoVO();
				bindVO.BindId = sbindId.ToString();
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 送信日

			// 送信日は店舗抽出時、かつ照会モードの場合のみ
			if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb)
				&& f01VO.Modeno.Equals(BoSystemConstant.MODE_REF))
			{

				#region 送信日FROM
				// 送信日FROMを設定
				if (!string.IsNullOrEmpty(f01VO.Sosin_ymd_from))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_SOSIN_YMD_FROM").Append(tenpoGyosyaKb.ToString());
					sRepSql.Append("	AND T1.SOSIN_YMD >= :").Append(sbindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Sosin_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				#endregion

				#region 送信日TO

				// 送信日TOを設定
				if (!string.IsNullOrEmpty(f01VO.Sosin_ymd_to))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_SOSIN_YMD_TO").Append(tenpoGyosyaKb.ToString());

					sRepSql.Append("	AND T1.SOSIN_YMD <= :").Append(sbindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Sosin_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			
				#endregion
			}

			#endregion

			#region 入力担当者コード

			// 入力担当者コードは店舗抽出時のみ
			if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
			{

				// 入力担当者コードを設定
				if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_NYURYOKUTAN_CD").Append(tenpoGyosyaKb.ToString());
					sRepSql.Append("	AND T1.ADDTAN_CD = :").Append(sbindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Nyuryokutan_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			#endregion

			#region 旧自社品番

			// 旧自社品番を設定
			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn)
				|| !string.IsNullOrEmpty(f01VO.Old_jisya_hbn2)
				|| !string.IsNullOrEmpty(f01VO.Old_jisya_hbn3)
				|| !string.IsNullOrEmpty(f01VO.Old_jisya_hbn4)
				|| !string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
			{
				sRepSql.Append("AND EXISTS(");
				sRepSql.Append("		SELECT	1 FROM ").Append(sTableId).Append(" T2");
				sRepSql.Append("		WHERE	0 = 0");
				sRepSql.Append("		AND		T2.TENPO_CD = T1.TENPO_CD");
				sRepSql.Append("		AND		T2.FACE_NO = T1.FACE_NO");
				sRepSql.Append("		AND		T2.TANA_DAN = T1.TANA_DAN");
				sRepSql.Append("		AND		T2.KAI_SU = T1.KAI_SU");
				sRepSql.Append("		AND		T2.TANAOROSI_YMD = T1.TANAOROSI_YMD");
				// 店舗参照時は"送信回数"、業者参照時は"処理日付"
				if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
				{
					sRepSql.Append("		AND		T2.SOSINKAI_SU = T1.SOSINKAI_SU");
				}
				else
				{
					sRepSql.Append("		AND		T2.SYORI_YMD = T1.SYORI_YMD");
				}
				sRepSql.Append("		AND		(");

				// OR条件付加
				String sOrF = string.Empty;

				// 旧自社品番1が設定されていた場合
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{

					sbindId = new StringBuilder();
					sbindId.Append("BIND_OLD_XEBIO_CD01").Append(tenpoGyosyaKb.PadLeft(2,'0'));

					//// 旧自社品番1が10桁の場合
					//if (f01VO.Old_jisya_hbn.Length.Equals(10))
					//{
					//	sRepSql.Append("	T2.JAN_CD IN	(");
					//	sRepSql.Append("						SELECT	M1.JAN_CD");
					//	sRepSql.Append("						FROM	MDMT0130 M1");
					//	sRepSql.Append("						WHERE	M1.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append("						)");
					//}
					//else
					//{
						sRepSql.Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD1];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}

				}

				// 旧自社品番2が設定されていた場合
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
				{

					sbindId = new StringBuilder();
					sbindId.Append("BIND_OLD_XEBIO_CD02").Append(tenpoGyosyaKb.PadLeft(2, '0'));

					//// 旧自社品番2が10桁の場合
					//if (f01VO.Old_jisya_hbn2.Length.Equals(10))
					//{
					//	sRepSql.Append(sOrF).Append("	T2.JAN_CD IN	(");
					//	sRepSql.Append("						SELECT	M1.JAN_CD");
					//	sRepSql.Append("						FROM	MDMT0130 M1");
					//	sRepSql.Append("						WHERE	M1.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append("						)");
					//}
					//else
					//{
						sRepSql.Append(sOrF).Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD2];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}
				}

				// 旧自社品番3が設定されていた場合
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_OLD_XEBIO_CD3").Append(tenpoGyosyaKb.PadLeft(2, '0'));

					//// 旧自社品番1が10桁の場合
					//if (f01VO.Old_jisya_hbn3.Length.Equals(10))
					//{
					//	sRepSql.Append(sOrF).Append("	T2.JAN_CD IN	(");
					//	sRepSql.Append("						SELECT	M1.JAN_CD");
					//	sRepSql.Append("						FROM	MDMT0130 M1");
					//	sRepSql.Append("						WHERE	M1.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append("						)");
					//}
					//else
					//{
						sRepSql.Append(sOrF).Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD3];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}
				}

				// 旧自社品番4が設定されていた場合
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_OLD_XEBIO_CD4").Append(tenpoGyosyaKb.PadLeft(2, '0'));

					//// 旧自社品番1が10桁の場合
					//if (f01VO.Old_jisya_hbn4.Length.Equals(10))
					//{
					//	sRepSql.Append(sOrF).Append("	T2.JAN_CD IN	(");
					//	sRepSql.Append("						SELECT	M1.JAN_CD");
					//	sRepSql.Append("						FROM	MDMT0130 M1");
					//	sRepSql.Append("						WHERE	M1.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append("						)");
					//}
					//else
					//{
						sRepSql.Append(sOrF).Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD4];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}
				}

				// 旧自社品番5が設定されていた場合
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
				{

					sbindId = new StringBuilder();
					sbindId.Append("BIND_OLD_XEBIO_CD5").Append(tenpoGyosyaKb.PadLeft(2, '0'));

					//// 旧自社品番1が10桁の場合
					//if (f01VO.Old_jisya_hbn5.Length.Equals(10))
					//{
					//	sRepSql.Append(sOrF).Append("	T2.JAN_CD IN	(");
					//	sRepSql.Append("						SELECT	M1.JAN_CD");
					//	sRepSql.Append("						FROM	MDMT0130 M1");
					//	sRepSql.Append("						WHERE	M1.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append("						)");
					//}
					//else
					//{
						sRepSql.Append(sOrF).Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());

					//}

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD5];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
					sRepSql.Append("		)");
					sRepSql.Append("	)");

			}
			#endregion

			#region スキャンコード

			// スキャンコードを設定
			if (!string.IsNullOrEmpty(f01VO.Scan_cd)
				|| !string.IsNullOrEmpty(f01VO.Scan_cd2)
				|| !string.IsNullOrEmpty(f01VO.Scan_cd3)
				|| !string.IsNullOrEmpty(f01VO.Scan_cd4)
				|| !string.IsNullOrEmpty(f01VO.Scan_cd5))
			{
				sRepSql.Append("AND EXISTS(");
				sRepSql.Append("		SELECT	1 FROM ").Append(sTableId).Append(" T2");
				sRepSql.Append("		WHERE	0 = 0");
				sRepSql.Append("		AND		T2.TENPO_CD = T1.TENPO_CD");
				sRepSql.Append("		AND		T2.FACE_NO = T1.FACE_NO");
				sRepSql.Append("		AND		T2.TANA_DAN = T1.TANA_DAN");
				sRepSql.Append("		AND		T2.KAI_SU = T1.KAI_SU");
				sRepSql.Append("		AND		T2.TANAOROSI_YMD = T1.TANAOROSI_YMD");
				// 店舗参照時は"送信回数"、業者参照時は"処理日付"
				if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
				{
					sRepSql.Append("		AND		T2.SOSINKAI_SU = T1.SOSINKAI_SU");
				}
				else
				{
					sRepSql.Append("		AND		T2.SYORI_YMD = T1.SYORI_YMD");
				}
				sRepSql.Append("		AND		T2.JAN_CD IN (");

				// 条件が設定されたかどうか判定する
				int setFlg = 0;

				// スキャンコード
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{

					sbindId = new StringBuilder();
					sbindId.Append("BIND_SCAN_CD01").Append(tenpoGyosyaKb.ToString());

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD1];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}

				// スキャンコード２
				if (!string.IsNullOrEmpty(f01VO.Scan_cd2))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_SCAN_CD02").Append(tenpoGyosyaKb.ToString());

					if (setFlg == 1)
					{
						sRepSql.Append(" , ");
					}

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD2];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}

				// スキャンコード３
				if (!string.IsNullOrEmpty(f01VO.Scan_cd3))
				{

					sbindId = new StringBuilder();
					sbindId.Append("BIND_SCAN_CD03").Append(tenpoGyosyaKb.ToString());


					if (setFlg == 1)
					{
						sRepSql.Append(" , ");
					}

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD3];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}

				// スキャンコード４
				if (!string.IsNullOrEmpty(f01VO.Scan_cd4))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_SCAN_CD04").Append(tenpoGyosyaKb.ToString());

					if (setFlg == 1)
					{
						sRepSql.Append(" , ");
					}

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD4];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}

				// スキャンコード５
				if (!string.IsNullOrEmpty(f01VO.Scan_cd5))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_SCAN_CD05").Append(tenpoGyosyaKb.ToString());

					if (setFlg == 1)
					{
						sRepSql.Append(" , ");
					}

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD5];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}
				sRepSql.Append("		)");
				sRepSql.Append("	)");

			}

			#endregion

			#region モード
			// 店舗抽出時のみ設定する
			if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
			{
				// [選択モードNo]が「取消」の場合
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL))
				{

					sbindId = new StringBuilder();
					sbindId.Append("BIND_TANAOROSI_YMD").Append(tenpoGyosyaKb.ToString());

					sRepSql.Append(" AND T1.SOSINIRAI_FLG = 0");
					sRepSql.Append(" AND T1.SOSINZUMI_FLG = 0");
					sRepSql.Append(" AND T1.TANAOROSI_YMD = :").Append(sbindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = BoSystemFormat.formatDate(searchMdit0030["TANAOROSIKIJUN_YMD"].ToString());
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				// [選択モードNo]が「照会」の場合
				else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_REF))
				{
					// [送信状態]が「未送信」の場合
					if (f01VO.Sosin_jyotai.Equals(ConditionSosin_jotai.VALUE_SOSIN_JOTAI1))
					{
						sRepSql.Append("	AND T1.SOSINZUMI_FLG = 0");
					}
					// [送信状態]が「送信済み」の場合
					else if (f01VO.Sosin_jyotai.Equals(ConditionSosin_jotai.VALUE_SOSIN_JOTAI2))
					{
						sRepSql.Append("	AND T1.SOSINZUMI_FLG = 1");
					}
				}
			}

			#endregion

			BoSystemSql.AddSql(reader, sREP_ID, sRepSql.ToString(), bindList);

		}

		#endregion

		#region スキャン数設定
		/// <summary>
		/// AddScan_Su スキャン数設定
		/// スキャン数抽出用の検索条件を返します。
		/// </summary>
		/// <param name="Tj030f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="String">tenpoGyosyaKb(1:店舗、2:業者)</param>
		/// <returns></returns>
		private void AddScan_Su(Tj030f01Form f01VO, FindSqlResultTable reader, String tenpoGyosyaKb)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			String sREP_ID = String.Empty;
			String sTableId = String.Empty;

			// 店舗、業者によって設定するWHERE句、テーブルを決定する
			if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
			{
				sREP_ID = Tj030p01Constant.SQL_ID_02_REP_TANAOROSIGOKEI_SU_1;
				sTableId = "MDIT0011";	//	[棚卸確定TBL(B)]
			}
			else
			{
				sREP_ID = Tj030p01Constant.SQL_ID_02_REP_TANAOROSIGOKEI_SU_2;
				sTableId = "MDIT0091";	//  [業者棚卸TBL(B)]
			}

			// バインドIDを作成
			StringBuilder sbindId = new StringBuilder();

			// 自社品番入力フラグ
			int ijisya_hbnF = 0;
			// スキャンコード入力フラグ
			int iScan_cdF = 0;

			// 自社品番が入力されているかチェック
			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn)
				|| !string.IsNullOrEmpty(f01VO.Old_jisya_hbn2)
				|| !string.IsNullOrEmpty(f01VO.Old_jisya_hbn3)
				|| !string.IsNullOrEmpty(f01VO.Old_jisya_hbn4)
				|| !string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
			{
				ijisya_hbnF = 1;
			}

			// スキャンコードが入力されているかチェック
			if (!string.IsNullOrEmpty(f01VO.Scan_cd)
				|| !string.IsNullOrEmpty(f01VO.Scan_cd2)
				|| !string.IsNullOrEmpty(f01VO.Scan_cd3)
				|| !string.IsNullOrEmpty(f01VO.Scan_cd4)
				|| !string.IsNullOrEmpty(f01VO.Scan_cd5))
			{
				iScan_cdF = 1;
			}

			// 自社品番、スキャンコードが未入力の場合、ヘッダーの棚卸合計数量を取得する
			if (ijisya_hbnF == 0 && iScan_cdF == 0)
			{
				BoSystemSql.AddSql(reader, sREP_ID, ",T1.TANAOROSIGOKEI_SU TANAOROSIGOKEI_SU", bindList);
				return;
			}

			// 自社品番、スキャンコードが入力された場合、明細より集計して取得
			sRepSql.Append(" ,(");
			sRepSql.Append("		SELECT");
			sRepSql.Append("				SUM(TANAOROSIGOKEI_SU)");
			sRepSql.Append("		FROM");
			sRepSql.Append("				").Append(sTableId).Append(" T2");
			sRepSql.Append("		WHERE");
			sRepSql.Append("			T1.TENPO_CD			= T2.TENPO_CD");
			sRepSql.Append("		AND	T1.FACE_NO			= T2.FACE_NO");
			sRepSql.Append("		AND	T1.TANA_DAN			= T2.TANA_DAN");
			sRepSql.Append("		AND	T1.KAI_SU			= T2.KAI_SU");
			sRepSql.Append("		AND	T1.TANAOROSI_YMD	= T2.TANAOROSI_YMD");
			// 店舗参照時は"送信回数"、業者参照時は"処理日付"
			if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
			{
				sRepSql.Append(" AND	T2.SOSINKAI_SU = T1.SOSINKAI_SU");
			}
			else
			{
				sRepSql.Append(" AND	T2.SYORI_YMD = T1.SYORI_YMD");
			}

			#region 条件編集
			sRepSql.Append(" AND ( ");

			#region 旧自社品番
			// 自社品番による検索条件を設定する
			if (ijisya_hbnF == 1)
			{

				// OR条件付加
				String sOrF = string.Empty;

				// 自社品番1
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_JISYA_HBN01").Append(tenpoGyosyaKb.ToString());

					//if (f01VO.Old_jisya_hbn.Length == 10)
					//{
					//	sRepSql.Append("	T2.JAN_CD IN ( ");
					//	sRepSql.Append("   		SELECT	MDMT0130.JAN_CD");
					//	sRepSql.Append("   		FROM	MDMT0130");
					//	sRepSql.Append("   		WHERE	MDMT0130.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append(" 	) ");
					//}
					//else
					//{
						sRepSql.Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD1];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}
				}

				// 自社品番2
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_JISYA_HBN02").Append(tenpoGyosyaKb.ToString());

					//if (f01VO.Old_jisya_hbn2.Length == 10)
					//{
					//	sRepSql.Append(sOrF).Append("	T2.JAN_CD IN ( ");
					//	sRepSql.Append("   		SELECT	MDMT0130.JAN_CD");
					//	sRepSql.Append("   		FROM	MDMT0130");
					//	sRepSql.Append("   		WHERE	MDMT0130.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append(" 	) ");
					//}
					//else
					//{
						sRepSql.Append(sOrF).Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD2];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}
				}

				// 自社品番3
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_JISYA_HBN03").Append(tenpoGyosyaKb.ToString());

					//if (f01VO.Old_jisya_hbn3.Length == 10)
					//{
					//	sRepSql.Append(sOrF).Append("	T2.JAN_CD IN ( ");
					//	sRepSql.Append("   		SELECT	MDMT0130.JAN_CD");
					//	sRepSql.Append("   		FROM	MDMT0130");
					//	sRepSql.Append("   		WHERE	MDMT0130.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append(" 	) ");
					//}
					//else
					//{
						sRepSql.Append(sOrF).Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD3];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}
				}

				// 自社品番4
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_JISYA_HBN04").Append(tenpoGyosyaKb.ToString());

					//if (f01VO.Old_jisya_hbn4.Length == 10)
					//{
					//	sRepSql.Append(sOrF).Append("	T2.JAN_CD IN ( ");
					//	sRepSql.Append("   		SELECT	MDMT0130.JAN_CD");
					//	sRepSql.Append("   		FROM	MDMT0130");
					//	sRepSql.Append("   		WHERE	MDMT0130.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append(" 	) ");
					//}
					//else
					//{
						sRepSql.Append(sOrF).Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD4];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}
				}

				// 自社品番5
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_JISYA_HBN05").Append(tenpoGyosyaKb.ToString());

					//if (f01VO.Old_jisya_hbn5.Length == 10)
					//{
					//	sRepSql.Append(sOrF).Append("	T2.JAN_CD IN ( ");
					//	sRepSql.Append("   		SELECT	MDMT0130.JAN_CD");
					//	sRepSql.Append("   		FROM	MDMT0130");
					//	sRepSql.Append("   		WHERE	MDMT0130.OLD_XEBIO_CD = :").Append(sbindId.ToString());
					//	sRepSql.Append(" 	) ");
					//}
					//else
					//{
						sRepSql.Append(sOrF).Append("	T2.JISYA_HBN	= :").Append(sbindId.ToString());
					//}

					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD5];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					if (string.IsNullOrEmpty(sOrF))
					{
						sOrF = " OR";
					}
				}
			}
			#endregion

			#region スキャンコード

			// 旧自社品番による条件が設定されている場合,ORで条件指定を行う
			if (iScan_cdF == 1 && ijisya_hbnF == 1)
			{
				sRepSql.Append(" OR ");
			}
			else
			{
			}

			if (iScan_cdF == 1)
			{
				sRepSql.Append(" T2.JAN_CD IN (");

				// 条件が設定されたかどうか判定する
				int setFlg = 0;

				// スキャンコード
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{

					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_SCAN_CD01").Append(tenpoGyosyaKb.ToString());

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD1];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}

				// スキャンコード２
				if (!string.IsNullOrEmpty(f01VO.Scan_cd2))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_SCAN_CD02").Append(tenpoGyosyaKb.ToString());

					if (setFlg == 1)
					{
						sRepSql.Append(" , ");
					}

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD2];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}

				// スキャンコード３
				if (!string.IsNullOrEmpty(f01VO.Scan_cd3))
				{

					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_SCAN_CD03").Append(tenpoGyosyaKb.ToString());


					if (setFlg == 1)
					{
						sRepSql.Append(" , ");
					}

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD3];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}

				// スキャンコード４
				if (!string.IsNullOrEmpty(f01VO.Scan_cd4))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_SCAN_CD04").Append(tenpoGyosyaKb.ToString());

					if (setFlg == 1)
					{
						sRepSql.Append(" , ");
					}

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD4];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}

				// スキャンコード５
				if (!string.IsNullOrEmpty(f01VO.Scan_cd5))
				{
					sbindId = new StringBuilder();
					sbindId.Append("BIND_S_SCAN_CD05").Append(tenpoGyosyaKb.ToString());

					if (setFlg == 1)
					{
						sRepSql.Append(" , ");
					}

					sRepSql.Append("		:").Append(sbindId.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = sbindId.ToString();
					bindVO.Value = (string)f01VO.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD5];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 条件が設定されたためフラグ更新
					setFlg = 1;
				}
				sRepSql.Append(" )");
			}

			#endregion

			sRepSql.Append("   ) ");
			sRepSql.Append(" ) TANAOROSIGOKEI_SU");
			#endregion

			BoSystemSql.AddSql(reader, sREP_ID, sRepSql.ToString(), bindList);

		}

		#endregion

		#endregion

	}
}