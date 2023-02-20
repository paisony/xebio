using com.xebio.bo.Te010p01.Constant;
using com.xebio.bo.Te010p01.Formvo;
using com.xebio.bo.Te010p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01006;
using Common.Business.V01000.V01026;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03003;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Te010p01.Facade
{
  /// <summary>
  /// Te010f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Te010f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Te010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Te010f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te010f01Facade()
			: base()
		{
		}
		#endregion

		#region Te010f01画面データを作成する。
		/// <summary>
		/// Te010f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				//カード部を取得します。
				Te010f01Form te010f01Form = (Te010f01Form)facadeContext.FormVO;
				if (string.IsNullOrEmpty(te010f01Form.Modeno))
				{
					// 伝票状態設定
					te010f01Form.Denpyo_jyotai = ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI1;
				}

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				////M1明細部のデータを作成します。
				//DoM1ListLoad(facadeContext);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
		}
		#endregion

		
		#region M1明細部データの作成をする。
		/// <summary>
		/// M1明細部データの作成をする。
		/// 明細ID(M1)の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ListLoad(IFacadeContext facadeContext)
		{
			//このメソッドは、M1の明細のデータを生成するために、
			//画面のLoad処理と改ページ処理で呼ばれます。
			//コネクションの開始・終了は呼び出しもとのメソッドで管理されます。
			//必要な処理を実装してください。
			
		}
		#endregion

		#region 検索単項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te010f01Form">f01VO</param>
		/// <param name="String">mode</param>
		/// <returns>Decimal</returns>
		private void ChkSelSingleItem ( IFacadeContext facadeContext, Te010f01Form f01VO )
		{
			#region 単項目チェック
			// 1-1 ヘッダ店舗コード
			//       店舗マスタを検索し、存在しない場合エラー
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

			// 1-2 会社コード
			//       名称マスタ（識別コード＝'KASY'）を検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Kaisya_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01006Check.CheckKaisya(f01VO.Kaisya_cd
													, facadeContext
													, string.Empty
													, null
													, "会社"
													, new[] { "Kaisya_cd" }
													, null
													, null
													, null
													, 0
													, 0
													);
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Kaisya_nm = (string)resultHash["MEISYO_NM"];
				}
			}

			// 1-3 入荷店コード
			//       店舗マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Jyuryoten_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01026Check.CheckTenpoAll(f01VO.Kaisya_cd
													, f01VO.Jyuryoten_cd
													, facadeContext
													, string.Empty
													, null
													, "入荷店"
													, new[] { "Jyuryoten_cd" }
													, null
													, null
													, null
													, 0
													, 0
													);
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Juryoten_nm = (string)resultHash["TENPO_NM"];
				}
			}

			// 1-4 入力担当者コード
			//       担当者マスタを検索し、存在しない場合エラー
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

			// 1-5 自社品番
			//     発注マスタを検索し、存在しない場合エラー
			f01VO.Dictionary[Te010p01Constant.DIC_SEARCH_XEBIOCD] = string.Empty;
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
				Hashtable resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });
				// メーカー品番をラベルに設定
				if (resultHash != null)
				{
					// 自社品番をディクショナリに退避
					f01VO.Dictionary[Te010p01Constant.DIC_SEARCH_XEBIOCD] = (string)resultHash["XEBIO_CD"];
					f01VO.Maker_hbn = (string)resultHash["HIN_NBR"];
				}
			}

			// 1-6 スキャンコード
			//     発注マスタを検索し、存在しない場合エラー
			f01VO.Dictionary[Te010p01Constant.DIC_SEARCH_JANCD] = string.Empty;
			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				SearchHachuVO searchConditionVO2 = new SearchHachuVO(
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
				Hashtable hs = V01004Check.CheckScanCd(searchConditionVO2, facadeContext, "スキャンコード", new[] { "Scan_cd" });
				if (hs != null)
				{
					// JANコードをディクショナリに退避
					f01VO.Dictionary[Te010p01Constant.DIC_SEARCH_JANCD] = (string)hs["JAN_CD"];
				}
			}

			// 1-7 ｵﾌﾗｲﾝ伝票No（Xのみ）
			//     20桁でない場合、エラー
			if (!string.IsNullOrEmpty(f01VO.Offline_no))
			{
				if (f01VO.Offline_no.Length != Te010p01Constant.CHECK_OFFLINE_NO)
				{
					ErrMsgCls.AddErrMsg("E107", new string[]{"ｵﾌﾗｲﾝ伝票No","20"}, facadeContext, new[] { "Offline_no" });
				}
			}
			#endregion
		}
		#endregion
		#region 検索関連項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索関連項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te010f01Form">f01VO</param>
		/// <returns>Decimal</returns>
		private void ChkSelRelatedItem ( IFacadeContext facadeContext, Te010f01Form f01VO )
		{
			#region 関連項目チェック
			// 2-1 伝票番号FROM、伝票番号TO 
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


			// 2-2 指示番号FROM、指示番号TO 
			//       指示番号ＦＲＯＭ と 指示番号ＴＯの桁数が違う場合エラー
			int iErrF = 0;
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_from) && !string.IsNullOrEmpty(f01VO.Siji_bango_to))
			{
				if (f01VO.Siji_bango_from.Length != f01VO.Siji_bango_to.Length)
				{
					ErrMsgCls.AddErrMsg("E194", string.Empty, facadeContext, new[] { "Siji_bango_from", "Siji_bango_to" });
					iErrF = 1;
				}

			}

			// 2-3 指示番号FROM、指示番号TO 
			//       指示番号ＦＲＯＭ > 指示番号ＴＯの場合エラー
			if (iErrF == 0)
			{
				if (!string.IsNullOrEmpty(f01VO.Siji_bango_from) && !string.IsNullOrEmpty(f01VO.Siji_bango_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Siji_bango_from,
									f01VO.Siji_bango_to,
									facadeContext,
									"指示番号",
									new[] { "Siji_bango_from", "Siji_bango_to" }
									);
				}
			}

			// 2-4 出荷日FROM、出荷日TO
			//       出荷日ＦＲＯＭ > 出荷日ＴＯの場合エラー
			if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_from) && !string.IsNullOrEmpty(f01VO.Syukka_ymd_to))
			{
				V03001Check.DateFromToChk(
								f01VO.Syukka_ymd_from,
								f01VO.Syukka_ymd_to,
								facadeContext,
								"出荷日",
								new[] { "Syukka_ymd_from", "Syukka_ymd_to" }
								);
			}

			// 2-5 部門コードFROM、部門コードTO
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
			#endregion
		}
		#endregion
		#region 件数チェック
		/// <summary>
		/// ChkCount 件数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IList">tableListcnt</param>
		/// <returns>Decimal</returns>
		private Decimal ChkCount ( IFacadeContext facadeContext, IList<Hashtable> tableListcnt )
		{
			Hashtable resultTbl = tableListcnt[0];
			Decimal dCnt = (Decimal)resultTbl["CNT"];
			if (tableListcnt == null || tableListcnt.Count <= 0)
			{
				// エラー
				ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
			}
			else
			{

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
			return dCnt;
		}
		#endregion
		#region 行数チェック
		/// <summary>
		/// ChkRowCount 行数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="mode">チェックモード</param>
		/// <returns></returns>
		private void ChkRowCount ( IFacadeContext facadeContext, IDataList m1List, LoginInfoVO loginInfo, string mode )
		{
			bool blError = false;
			if (m1List == null || m1List.Count <= 0)
			{
				blError = true;
			}
			else
			{
				int inputflg = 0;
				int inputPrtflg = 0;
				foreach (Te010f01M1Form f01m1VO in m1List.ListData)
				{
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						inputflg = 1;
						// 印刷時は、以下のチェックを行う
						if (Te010p01Constant.CHECK_MODE_BTNPRINT.Equals(mode))
						{
							// Dictionary.[Ｍ１参照テーブル]が"2"(移動出荷履歴TBL)の行 または
							// ログイン情報．権限が、"2"（店舗）で、Dictionary.[Ｍ１送信済フラグ]が"1"(送信済)の行
							if(Te010p01Constant.REF_TBL_RIREKI.Equals(f01m1VO.Dictionary[Te010p01Constant.DIC_REF_TBL].ToString())
							|| (loginInfo.Kengenkbn == BoSystemConstant.TANTO_KENGEN_TENCHO && BoSystemConstant.SOSINZUMI_FLG_SOSINZUMI.Equals(f01m1VO.Dictionary[Te010p01Constant.DIC_M1SOSINZUMI_FLG].ToString())))
							{
								// 次の行
								continue;
							}
							else
							{
								inputPrtflg = 1;
								break;
							}
						}
						else
						{
							break;
						}
					}
				}
				if (inputflg == 0)
				{
					blError = true;
				}
				// 印刷モード印刷対象行がない場合
				if (Te010p01Constant.CHECK_MODE_BTNPRINT.Equals(mode) && inputflg == 1 && inputPrtflg == 0)
				{
//					// 抽出件数は0件です。
//					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}
			}
			if (blError)
			{

				if (Te010p01Constant.CHECK_MODE_BTNPRINT.Equals(mode))
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);

				}
				else
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
			}
		}
		#endregion
		#region 検索処理
		/// <summary>
		/// DoSelect 検索処理
		/// </summary>
		/// <param name="Te010f01Form">f01VO</param>
		/// <param name="IDBContext">DBContext</param>
		/// <param name="blCount">bool</param>
		/// <returns>IList></returns>
		private IList<Hashtable> DoSelect ( Te010f01Form f01VO, IDBContext DBContext, bool blCount)
		{
			FindSqlResultTable rtSearch = null;
			if (blCount)
			{
				// 件数取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te010p01Constant.SQL_ID_01, DBContext);
			}
			else
			{
				// [伝票状態]が空白、「確定」、「ﾏﾆｭｱﾙ出荷」、「入荷店未処理」、「差異あり」の場合、移動出荷確定テーブルから検索する。
				if (Te010p01Constant.REF_TBL_KAKU.Equals(Te010p01Util.GetRefTbl(f01VO.Denpyo_jyotai)))
				{
					// 検索結果取得
					rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te010p01Constant.SQL_ID_02, DBContext);
				}
				else
				{
					// 検索結果取得
					rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te010p01Constant.SQL_ID_03, DBContext);
				}
			}

			// 検索条件設定
			SetBind(f01VO, rtSearch, blCount);

			//検索結果を取得します
			rtSearch.CreateDbCommand();
			IList<Hashtable> result = rtSearch.Execute();
			BoSystemLog.logOut("SQL: " + rtSearch.LogSql);
			return result;
		}
		#endregion
		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Te010f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="bool">blCount</param>
		/// <returns></returns>
		private void SetBind ( Te010f01Form f01VO, FindSqlResultTable reader, bool blCount)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

			string[] sTblID = new string[2];
			// [伝票状態]が空白、「確定」、「ﾏﾆｭｱﾙ出荷」、「入荷店未処理」、「差異あり」の場合、移動出荷確定テーブルから検索する。
			if (Te010p01Constant.REF_TBL_KAKU.Equals(Te010p01Util.GetRefTbl(f01VO.Denpyo_jyotai)))
			{
				// 移動出荷確定テーブル
				sTblID[0] = "MDUT0010";
				// 移動出荷確定テーブル(B)
				sTblID[1] = "MDUT0011";
			}
			// [伝票状態]が「登録履歴」、「取消履歴」の場合、移動出荷履歴テーブルから検索する。
			else
			{
				// 移動出荷履歴テーブル
				sTblID[0] = "MDUT0020";
				// 移動出荷履歴テーブル[B]
				sTblID[1] = "MDUT0021";
			}

			// 検索結果取得の場合
			if (!blCount)
			{
				// 会社コード（ORDER BY句）
				reader.BindValue("BIND_KAISYA_CD_ORDER", Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatKaisyaCd(logininfo.CopCd),"0")));
			}
			// 件数取得時
			else
			{
				// テーブル設定
				BoSystemSql.AddSql(reader, Te010p01Constant.SQL_ADD_TBLID, sTblID[0] + " T1");
			}

			// 出荷会社コードを設定
			sRepSql.Append(" AND T1.SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD").AppendLine();
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYUKKAKAISYA_CD";
			bindVO.Value = BoSystemFormat.formatKaisyaCd(logininfo.CopCd);
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 出荷店舗コードを設定
			sRepSql.Append(" AND T1.SYUKKATEN_CD = :BIND_SYUKKATEN_CD").AppendLine();
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYUKKATEN_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 確定テーブル参照時のみの検索条件
			if (Te010p01Constant.REF_TBL_KAKU.Equals(Te010p01Util.GetRefTbl(f01VO.Denpyo_jyotai)))
			{
				// [モードNO]が「取消」の場合に条件とする。
				if(BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)) 
				{
					// 送信済みフラグ（0(未送信)）
					sRepSql.Append(" AND T1.SOSINZUMI_FLG = :BIND_SOSINZUMI_FLG").AppendLine();
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SOSINZUMI_FLG";
					bindVO.Value = ConditionSosinzumi_flg.VALUE_MISOSIN;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
					// 確定フラグ（0 (未確定))）
					sRepSql.Append(" AND T2.KAKUTEI_FLG = :BIND_KAKUTEI_FLG").AppendLine();
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KAKUTEI_FLG";
					bindVO.Value = ConditionKakuteisyori_flg.VALUE_NASI;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				// [モードNO]が「照会」の場合に条件とする。
				else
				{
					//[伝票状態]が「確定」の場合に条件とする。または
					//[伝票状態]が「ﾏﾆｭｱﾙ出荷」の場合に条件とする。
					if(ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI1.Equals(f01VO.Denpyo_jyotai)
					|| ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI2.Equals(f01VO.Denpyo_jyotai))
					{
						// 確定種別
						sRepSql.Append(" AND T1.KAKUTEI_SB = :BIND_KAKUTEI_SB").AppendLine();
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_KAKUTEI_SB";
						//[伝票状態]が「確定」の場合に条件とする
						if(ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI1.Equals(f01VO.Denpyo_jyotai))
						{
							// 通常を設定
							bindVO.Value = Te010p01Constant.KAKUTEI_SB_IDOU_TSUJO;
						//[伝票状態]が「ﾏﾆｭｱﾙ出荷」の場合に条件とする。
						} else {
							// マニュアル出荷を設定
							bindVO.Value = Te010p01Constant.KAKUTEI_SB_IDOU_MANUAL;
						}
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}
					// [伝票状態]が「入荷店未処理」の場合に条件とする。
					else if(ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI6.Equals(f01VO.Denpyo_jyotai))
					{
						// 入荷日
						sRepSql.Append(" AND T1.JYURYO_YMD = :BIND_JYURYO_YMD").AppendLine();
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JYURYO_YMD";
						bindVO.Value = "0";
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

					}
					// [伝票状態]が「差異あり」の場合に条件とする。
					else if (ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI3.Equals(f01VO.Denpyo_jyotai))
					{
						// 出荷実績合計数量と入荷実績合計数量が異なる条件
						sRepSql.Append(" AND T1.SYUKKAJISSEKIGOKEI_SU <> T1.NYUKAJISSEKIGOUKEI_SU").AppendLine();

						// 入荷日
						sRepSql.Append(" AND T1.JYURYO_YMD <> :BIND_JYURYO_YMD").AppendLine();
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JYURYO_YMD";
						bindVO.Value = "0";
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}
				}
			}

			// 伝票番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_from) )
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO >= :BIND_DENPYO_BANGO_FROM").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO_FROM";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 伝票番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Denpyo_bango_to) )
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO <= :BIND_DENPYO_BANGO_TO").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO_TO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Denpyo_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 指示番号FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_from))
			{
				string wkSiji_bango_from = f01VO.Siji_bango_from;
				if(f01VO.Siji_bango_from.Length == 10)
				{
					sRepSql.Append(" AND T1.SIJI_BANGO >= :BIND_SIJI_BANGO_FROM").AppendLine();
				} else {
					wkSiji_bango_from = BoSystemString.RightB(f01VO.Siji_bango_from, 16);
					sRepSql.Append(" AND LPAD(T1.JYURYOKAISYA_CD,2,'0') || LPAD(T1.JYURYOTEN_CD,4,'0') || LPAD(T1.SIJI_BANGO,10,'0') >= :BIND_SIJI_BANGO_FROM").AppendLine();
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIJI_BANGO_FROM";
				bindVO.Value = BoSystemFormat.formatIdoSijiNo(wkSiji_bango_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}


			// 指示番号TOを設定
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_to))
			{
				string wkSiji_bango_to = f01VO.Siji_bango_to;
				if (f01VO.Siji_bango_to.Length == 10)
				{
					sRepSql.Append(" AND T1.SIJI_BANGO <= :BIND_SIJI_BANGO_TO").AppendLine();
				}
				else
				{
					wkSiji_bango_to = BoSystemString.RightB(f01VO.Siji_bango_to, 16);
					sRepSql.Append(" AND LPAD(T1.JYURYOKAISYA_CD,2,'0') || LPAD(T1.JYURYOTEN_CD,4,'0') || LPAD(T1.SIJI_BANGO,10,'0') <= :BIND_SIJI_BANGO_TO").AppendLine();
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIJI_BANGO_TO";
				bindVO.Value = BoSystemFormat.formatIdoSijiNo(wkSiji_bango_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			
			// 指示番号を設定
			if (!string.IsNullOrEmpty(f01VO.Siji_bango_from) || !string.IsNullOrEmpty(f01VO.Siji_bango_to))
			{
				sRepSql.Append(" AND T1.SIJI_BANGO <> 0").AppendLine();
			}

			// 出荷日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_from))
			{
				sRepSql.Append(" AND T1.SYUKKA_YMD >= :BIND_SYUKKA_YMD_FROM").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKA_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Syukka_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 出荷日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Syukka_ymd_to))
			{
				sRepSql.Append(" AND T1.SYUKKA_YMD <= :BIND_SYUKKA_YMD_TO").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKA_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Syukka_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 会社コードを設定
			if (!string.IsNullOrEmpty(f01VO.Kaisya_cd))
			{
				sRepSql.Append(" AND T1.JYURYOKAISYA_CD = :BIND_JYURYOKAISYA_CD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JYURYOKAISYA_CD";
				bindVO.Value = BoSystemFormat.formatKaisyaCd(f01VO.Kaisya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 入荷店コードを設定
			if (!string.IsNullOrEmpty(f01VO.Jyuryoten_cd))
			{
				sRepSql.Append(" AND T1.JYURYOTEN_CD = :BIND_JYURYOTEN_CD").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JYURYOTEN_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Jyuryoten_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 入力担当者コードを設定
			if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
			{
				sRepSql.Append(" AND T1.ADDTAN_CD = :BIND_ADDTAN_CD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADDTAN_CD";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Nyuryokutan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門コードを設定
			if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) || !string.IsNullOrEmpty(f01VO.Bumon_cd_to))
			{
				sRepSql.Append(" AND EXISTS( SELECT 1").AppendLine();
				sRepSql.Append("               FROM ").Append(sTblID[1]).Append(" T6").AppendLine();
				sRepSql.Append("              WHERE ").AppendLine();
				sRepSql.Append("                    T6.DENPYO_BANGO    = T1.DENPYO_BANGO ").AppendLine();		// 伝票番号
				sRepSql.Append("                AND T6.SYUKKA_YMD      = T1.SYUKKA_YMD ").AppendLine();			// 出荷日
				sRepSql.Append("                AND T6.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD ").AppendLine();	// 出荷会社コード
				sRepSql.Append("                AND T6.SYUKKATEN_CD    = T1.SYUKKATEN_CD ").AppendLine();		// 出荷店
				// 部門FROMを設定
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
				{
					sRepSql.Append("                AND T6.BUMON_CD >= :BIND_BUMON_CD_FROM").AppendLine();

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_BUMON_CD_FROM";
					bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 部門TOを設定
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					sRepSql.Append("                AND T6.BUMON_CD <= :BIND_BUMON_CD_TO").AppendLine();

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_BUMON_CD_TO";
					bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				sRepSql.Append(" ) ").AppendLine();

			}

			// 出荷理由を設定
			if (!string.IsNullOrEmpty(f01VO.Shukkariyu_kbn) && !f01VO.Shukkariyu_kbn.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				sRepSql.Append(" AND T1.IDO_RIYU = :BIND_IDO_RIYU").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_IDO_RIYU";
				bindVO.Value = f01VO.Shukkariyu_kbn;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 旧自社品番
			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				sRepSql.Append(" AND EXISTS( SELECT 1").AppendLine();
				sRepSql.Append("               FROM ").Append(sTblID[1]).Append(" T3").AppendLine();
				sRepSql.Append("              WHERE ").AppendLine();
				sRepSql.Append("                    T3.DENPYO_BANGO    = T1.DENPYO_BANGO ").AppendLine();		// 伝票番号
				sRepSql.Append("                AND T3.SYUKKA_YMD      = T1.SYUKKA_YMD ").AppendLine();			// 出荷日
				sRepSql.Append("                AND T3.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD ").AppendLine();	// 出荷会社コード
				sRepSql.Append("                AND T3.SYUKKATEN_CD    = T1.SYUKKATEN_CD ").AppendLine();		// 出荷店

				//// 旧自社品番の桁数が10桁の場合
				//if (f01VO.Old_jisya_hbn.Length == 10)
				//{
				//	// ＪＡＮコード　IN サブクエリ．旧自社品番
				//	sRepSql.Append("                AND	T3.JAN_CD IN (SELECT SM1.JAN_CD FROM MDMT0130 SM1").AppendLine();
				//	sRepSql.Append("                                                   WHERE SM1.OLD_XEBIO_CD = :BIND_OLD_JISYA_HBN)").AppendLine();
				//}
				//else
				//{
					// 自社品番
					sRepSql.Append("                AND T3.JISYA_HBN    = :BIND_OLD_JISYA_HBN").AppendLine();
				//}
				sRepSql.Append(" )").AppendLine();
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_OLD_JISYA_HBN";
				bindVO.Value = (string)f01VO.Dictionary[Te010p01Constant.DIC_SEARCH_XEBIOCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// スキャンコードを設定
			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				sRepSql.Append(" AND EXISTS( SELECT 1").AppendLine();
				sRepSql.Append("               FROM ").Append(sTblID[1]).Append(" T4").AppendLine();
				sRepSql.Append("              WHERE ").AppendLine();
				sRepSql.Append("                    T4.DENPYO_BANGO    = T1.DENPYO_BANGO ").AppendLine();		// 伝票番号
				sRepSql.Append("                AND T4.SYUKKA_YMD      = T1.SYUKKA_YMD ").AppendLine();			// 出荷日
				sRepSql.Append("                AND T4.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD ").AppendLine();	// 出荷会社コード
				sRepSql.Append("                AND T4.SYUKKATEN_CD    = T1.SYUKKATEN_CD ").AppendLine();		// 出荷店
				sRepSql.Append("                AND T4.JAN_CD          = :BIND_SCAN_CD").AppendLine();			// ＪＡＮコード ← スキャンコード
				sRepSql.Append(" )");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SCAN_CD";
				bindVO.Value = (string)f01VO.Dictionary[Te010p01Constant.DIC_SEARCH_JANCD];
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// オフライン伝票Noを設定
			if (!string.IsNullOrEmpty(f01VO.Offline_no))
			{
				sRepSql.Append(" AND EXISTS( SELECT 1").AppendLine();
				sRepSql.Append("               FROM MDUT0040 T5").AppendLine();
				sRepSql.Append("              WHERE ").AppendLine();
				sRepSql.Append("                    T5.DENPYO_BANGO    = T1.DENPYO_BANGO ").AppendLine();		// 伝票番号
				sRepSql.Append("                AND T5.SYUKKA_YMD      = T1.SYUKKA_YMD ").AppendLine();			// 出荷日
				sRepSql.Append("                AND T5.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD ").AppendLine();	// 出荷会社コード
				sRepSql.Append("                AND T5.SYUKKATEN_CD    = T1.SYUKKATEN_CD ").AppendLine();		// 出荷店
				sRepSql.Append("                AND T5.OFFLINE_NO      = :BIND_OFFLINE_NO").AppendLine();		// オフライン伝票No
				sRepSql.Append(" )");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_OFFLINE_NO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f01VO.Offline_no);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 履歴テーブル参照時のみの検索条件
			if (Te010p01Constant.REF_TBL_RIREKI.Equals(Te010p01Util.GetRefTbl(f01VO.Denpyo_jyotai)))
			{
				// [伝票状態]が「取消履歴」の場合に条件とする。
				if (ConditionIdoshukka_denpyo_jotai.VALUE_DENPYO_JOTAI5.Equals(f01VO.Denpyo_jyotai))
				{
					sRepSql.Append(" AND EXISTS( SELECT 1").AppendLine();
					sRepSql.Append("               FROM MDUT0020 T7").AppendLine();
					sRepSql.Append("              WHERE ").AppendLine();
					sRepSql.Append("                    T7.DENPYO_BANGO    = T1.DENPYO_BANGO ").AppendLine();		// 伝票番号
					sRepSql.Append("                AND T7.SYUKKA_YMD      = T1.SYUKKA_YMD ").AppendLine();			// 出荷日
					sRepSql.Append("                AND T7.SYUKKAKAISYA_CD = T1.SYUKKAKAISYA_CD ").AppendLine();	// 出荷会社コード
					sRepSql.Append("                AND T7.SYUKKATEN_CD    = T1.SYUKKATEN_CD ").AppendLine();		// 出荷店
					sRepSql.Append("                AND T7.SYORI_SB        = 2 ").AppendLine();						// 処理種別　← 2 (取消)
					sRepSql.Append(" )");
				}
				// 履歴画面表示フラグを設定
				sRepSql.Append(" AND T1.RIREKI_DISP_KB = 1").AppendLine();		// 1 (表示)

			}

			// 検索条件設定
			BoSystemSql.AddSql(reader, Te010p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);

		}
		#endregion
		#region 転記処理(検索結果)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="Te010f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="tableList">取得情報</param>
		/// <param name="string">ref_tbl</param>
		/// <returns></returns>
		public void DoCopy ( Te010f01Form f01VO, IDataList m1List, IList<Hashtable> tableList)
		{
			int iCnt = 0;
			foreach (Hashtable rec in tableList)
			{
				iCnt++;
				Te010f01M1Form f01m1VO = new Te010f01M1Form();

				// 会社コード取得
				LoginInfoVO logininfVO = LoginInfoUtil.GetLoginInfo();
				Decimal dJisyaKaisyacd = Convert.ToDecimal(BoSystemString.Nvl(logininfVO.CopCd, "0"));
				Decimal dNyukaKaisyacd = Convert.ToDecimal(BoSystemString.Nvl(rec["JYURYOKAISYA_CD"].ToString(), "0"));

				#region 明細転記
				f01m1VO.M1rowno = iCnt.ToString();																	// Ｍ１行NO

				if (dJisyaKaisyacd == dNyukaKaisyacd)
				{
					// 自社の場合は空白を設定する
					f01m1VO.M1kaisyakana_nm =  string.Empty;														// Ｍ１会社カナ名	←　入荷会社名カナ
				}
				else
				{
					f01m1VO.M1kaisyakana_nm = rec["JYURYOKAISYA_KANA_NM"].ToString();								// Ｍ１会社カナ名	←　入荷会社名カナ
				}
				f01m1VO.M1jyuryoten_cd = rec["JYURYOTEN_CD"].ToString();											// Ｍ１入荷店コード
				f01m1VO.M1juryoten_nm =  rec["JYURYOTEN_NM"].ToString();											// Ｍ１入荷店名称
				f01m1VO.M1scm_cd =  rec["SCM_CD"].ToString();														// Ｍ１SCMコード
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1DENPYO_BANGO] = 
							BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString());							// Ｍ１伝票番号リンク
				f01m1VO.M1siji_bango =  BoSystemFormat.IdoSijiNoGetSijino(BoSystemString.ZeroToEmpty(rec["SIJI_BANGO"].ToString()));	// Ｍ１指示番号
				f01m1VO.M1syukka_ymd = BoSystemFormat.formatDate_yyMMdd(BoSystemString.ZeroToEmpty(rec["SYUKKA_YMD"].ToString()));	// Ｍ１出荷日
				f01m1VO.M1jyuryo_ymd =  BoSystemFormat.formatDate_yyMMdd(BoSystemString.ZeroToEmpty(rec["JYURYO_YMD"].ToString()));	// Ｍ１入荷日
				f01m1VO.M1syukka_su =  rec["SYUKKAJISSEKIGOKEI_SU"].ToString();										// Ｍ１出荷数量（梱包単位） ←　出荷数量（出荷実績合計数量）
				if (string.IsNullOrEmpty(f01m1VO.M1jyuryo_ymd))
				{
					// 未確定の場合空白表示
					f01m1VO.M1kakutei_su = string.Empty;															// Ｍ１確定数量             ←　確定数量（入荷実績合計金額）
				}
				else
				{
					f01m1VO.M1kakutei_su = rec["NYUKAJISSEKIGOUKEI_SU"].ToString();									// Ｍ１確定数量             ←　確定数量（入荷実績合計金額）
				}
				f01m1VO.M1nyuryokutan_nm = rec["ADDTAN_NM"].ToString();												// Ｍ１入力担当者名称
				f01m1VO.M1shukkariyu_nm = rec["SYUKKA_RIYU"].ToString();											// Ｍ１出荷理由名称
				f01m1VO.M1syorinm =  rec["SYORI_NM"].ToString();													// Ｍ１処理名称
				f01m1VO.M1syoriymd = BoSystemFormat.formatDate_yyMMdd(BoSystemString.ZeroToEmpty(rec["SYORI_YMD"].ToString()));	// Ｍ１処理日
				f01m1VO.M1syori_tm = BoSystemFormat.formatTime(BoSystemString.ZeroToEmpty(rec["SYORI_TM"].ToString()),1);		// Ｍ１処理時間
				f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
				f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;										// Ｍ１確定処理フラグ(隠し)
				// Ｍ１明細色区分(隠し)初期値設定
				f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;		// Ｍ１明細色区分(隠し)　←　"0"（通常）

				// 移動出荷確定TBL(H)参照時
				if (Te010p01Constant.REF_TBL_KAKU.Equals(Te010p01Util.GetRefTbl(f01VO.Denpyo_jyotai)))
				{
					// 送信済フラグが"1"(送信済)の場合は"1"(送信済)、それ以外は"0"(通常時)
					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}
				}

				// Dictionary
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1TENPO_CD] = f01VO.Head_tenpo_cd;									// 店舗コード		←　ヘッダ店舗コード
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1UPD_YMD_SYUKKA] = rec["UPD_YMD_SYUKKA"].ToString();				// 更新日			←　更新日付（出荷確定）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1UPD_TM_SYUKKA] = rec["UPD_TM_SYUKKA"].ToString();					// 更新時間			←　更新時間（出荷確定）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1UPD_YMD_NYUKA] = rec["UPD_YMD_NYUKA"].ToString();					// 更新日			←　更新日付（入荷予定）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1UPD_TM_NYUKA] = rec["UPD_TM_NYUKA"].ToString();					// 更新時間			←　更新時間（入荷予定）

				f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYUKKA_YMD] = BoSystemString.ZeroToEmpty(rec["SYUKKA_YMD"].ToString());						// 出荷日
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1JYURYO_YMD] = BoSystemString.ZeroToEmpty(rec["JYURYO_YMD"].ToString());						// 入荷日
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYORI_YMD] = BoSystemString.ZeroToEmpty(rec["SYORI_YMD"].ToString());							// 処理日付

				f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYORI_TM] = rec["SYORI_TM"].ToString();							// 処理時間

				f01m1VO.Dictionary[Te010p01Constant.DIC_M1NYUKATAN_NM] = rec["NYUKATAN_NM"].ToString();						// 入荷担当者名称（隠し）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1NYUKATAN_CD] = rec["NYUKATAN_CD"].ToString();						// 入荷担当者コード（隠し）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1ADDTAN_NM] = rec["ADDTAN_NM"].ToString();							// 登録担当者名（隠し）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1ADDTAN_CD] = rec["ADDTAN_CD"].ToString();							// 登録担当者コード（隠し）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1SOSINZUMI_FLG] = rec["SOSINZUMI_FLG"].ToString();					// 送信済みフラグ（出荷確定）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1KAKUTEI_FLG] = rec["KAKUTEI_FLG"].ToString();						// 確定フラグ（入荷予定）
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1JYURYOKAISYA_CD] = rec["JYURYOKAISYA_CD"].ToString();				// 入荷会社コード
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1JYURYOKAISYA_NM] = rec["JYURYOKAISYA_NM"].ToString();				// 入荷会社名
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1JYURYOKAISYA_KANA_NM] = rec["JYURYOKAISYA_KANA_NM"].ToString();	// 入荷会社名カナ
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYUKKAKAISYA_CD] = rec["SYUKKAKAISYA_CD"].ToString();				// 出荷会社コード
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYUKKAKAISYA_NM] = rec["SYUKKAKAISYA_NM"].ToString();				// 出荷会社名
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYUKKAKAISYA_KANA_NM] = rec["SYUKKAKAISYA_KANA_NM"].ToString();	// 出荷会社名カナ
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1SORTKEY] = rec["SORTKEY"].ToString();								// 出力順
				// ZeroToEmptyは不要
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1RIREKI_NO] = rec["RIREKI_NO"].ToString();		// 履歴No(履歴テーブル用)
				f01m1VO.Dictionary[Te010p01Constant.DIC_M1AKAKURO_KBN] = rec["AKAKURO_KBN"].ToString();	// 赤黒区分(履歴テーブル用)
				// f01m1VO.Dictionary[Te010p01Constant.DIC_M1RIREKI_NO] = BoSystemString.ZeroToEmpty(rec["RIREKI_NO"].ToString());		// 履歴No(履歴テーブル用)
				// f01m1VO.Dictionary[Te010p01Constant.DIC_M1AKAKURO_KBN] = BoSystemString.ZeroToEmpty(rec["AKAKURO_KBN"].ToString());	// 赤黒区分(履歴テーブル用)
				f01m1VO.Dictionary[Te010p01Constant.DIC_REF_TBL] = Te010p01Util.GetRefTbl(f01VO.Denpyo_jyotai);				// 参照テーブル
				#endregion

				//リストオブジェクトにM1Formを追加します。
				m1List.Add(f01m1VO, true);
			}
			f01VO.Dictionary[Te010p01Constant.DIC_REF_TBL] = Te010p01Util.GetRefTbl(f01VO.Denpyo_jyotai);					// 参照テーブル

		}
		#endregion
		#region 転記処理(伝票番号リンク)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="Te010f01Form">prevVo</param>
		/// <param name="Te010f01M1Form">prevM1Vo</param>
		/// <param name="IDataList">nextM1List</param>
		/// <param name="tableList">取得情報</param>
		/// <returns></returns>
		public void DoDetailCopy ( Te010f01Form prevVo, Te010f01M1Form prevM1Vo, Te010f02Form nextVo, IDataList nextM1List, IList<Hashtable> tableList )
		{

			decimal dSyukkaSum = 0;		// 合計出荷数量
			decimal dKakuteiSum = 0;	// 合計確定数量
			decimal dKinSum = 0;		// 合計原価金額
			foreach (Hashtable rec in tableList)
			{
				Te010f02M1Form f02m1VO = new Te010f02M1Form();
				f02m1VO.M1rowno = rec["GYO_NO"].ToString();						// Ｍ１行NO
				f02m1VO.M1bumon_cd =  rec["BUMON_CD"].ToString();				// Ｍ１部門コード
				f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();		// Ｍ１部門カナ名
				f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
				f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();			// Ｍ１ブランド名
				f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
				f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();				// Ｍ１メーカー品番
				f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名(カナ)
				f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
				f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
				f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード			← JANコード
				f02m1VO.M1syukka_su =  rec["IDOJISSEKI_SU"].ToString();			// Ｍ１出荷数量（梱包単位）		← 出荷数量（移動実績数）
				if (string.IsNullOrEmpty(prevM1Vo.Dictionary[Te010p01Constant.DIC_M1JYURYO_YMD].ToString()))
				{
					// 未確定データの場合、空白
					f02m1VO.M1kakutei_su =  string.Empty;		// Ｍ１確定数量					← 確定数量（入荷実績数）
				}
				else
				{
					f02m1VO.M1kakutei_su =  rec["NYUKAJISSEKI_SU"].ToString();		// Ｍ１確定数量					← 確定数量（入荷実績数）
				}
				f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();					// Ｍ１原単価

				// 原価金額設定
				Te010p01Util.SetGenkaKin(prevM1Vo.M1jyuryo_ymd, f02m1VO);

				f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
				f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)

				// [Ｍ１自社品番]が移動出荷検索一覧.[旧自社品番]と等しい
				// または[Ｍ１スキャンコード]が移動出荷検索一覧.[スキャンコード]と等しい場合
				if (f02m1VO.M1jisya_hbn.Equals((string)prevVo.Dictionary[Te010p01Constant.DIC_SEARCH_XEBIOCD])
				 || f02m1VO.M1scan_cd.Equals((string)prevVo.Dictionary[Te010p01Constant.DIC_SEARCH_JANCD]))
				{
					// 一覧画面で入力されたスキャンコードが一致する場合、背景色変更
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)  ←　"2"（自社品番/スキャンコード検索）
				}
				else
				{
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)　←　"0"（通常）
				}

				// 合計値加算
				dSyukkaSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1syukka_su, "0"));				// Ｍ１出荷数量（梱包単位）
				dKakuteiSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kakutei_su, "0"));			// Ｍ１確定数量
				dKinSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0"));					// Ｍ１原価金額の合計

				//リストオブジェクトにM1Formを追加します。
				nextM1List.Add(f02m1VO, true);

			}

			// 合計情報設定
			nextVo.Syukkasuryo_gokei = dSyukkaSum.ToString();					 // 出荷数量合計
			nextVo.Gokeikakutei_su = dKakuteiSum.ToString();					// 合計確定数量
			nextVo.Genka_kin_gokei = dKinSum.ToString();						// 原価金額合計
		}
		#endregion
		#region 更新単項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te010f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void ChkUpdSingleItem ( IFacadeContext facadeContext, Te010f01Form f01VO, IDataList m1List, SysDateVO sysDateVO )
		{
		}
		#endregion
		#region 排他チェック
		/// <summary>
		/// ChkUpdHaita 排他チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void ChkUpdHaita ( IFacadeContext facadeContext, IDataList m1List )
		{
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

			//// 移動出荷確定テーブル初期設定
			//StringBuilder sRepSql = new StringBuilder();
			//sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");					// 伝票番号
			//sRepSql.Append(" AND SYUKKA_YMD = :BIND_SYUKKA_YMD");						// 出荷日
			//sRepSql.Append(" AND SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD");				// 出荷会社コード
			//sRepSql.Append(" AND SYUKKATEN_CD = :BIND_SYUKKATEN_CD");					// 出荷店コード

			// 移動入荷予定テーブル初期設定
			StringBuilder sRepSql2 = new StringBuilder();
			sRepSql2.Append(" AND TENPOLC_KBN = 0");									// 店舗ＬＣ区分
			sRepSql2.Append(" AND SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD");			// 出荷会社コード
			sRepSql2.Append(" AND SYUKKATEN_CD = :BIND_SYUKKATEN_CD");					// 出荷店コード
			sRepSql2.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");					// 伝票番号

			#region 排他チェック
			int iCnt = 0;
			foreach (Te010f01M1Form f01m1VO in m1List.ListData)
			{

				// 対象行のみ
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					// ------------------------------------------------------------------------------------
					// 移動出荷のみで更新されることはないので、移動入荷予定のチェックのみを行う。※現行仕様
					// ------------------------------------------------------------------------------------

					//#region 移動出荷確定テーブル
					//ArrayList bindList = new ArrayList();
					//BindInfoVO bindVO = new BindInfoVO();
					//// 伝票番号を設定
					//bindVO = new BindInfoVO();
					//bindVO.BindId = "BIND_DENPYO_BANGO";
					//bindVO.Value = BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Te010p01Constant.DIC_M1DENPYO_BANGO].ToString());
					//bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					//bindList.Add(bindVO);

					//// 出荷日を設定
					//bindVO = new BindInfoVO();
					//bindVO.BindId = "BIND_SYUKKA_YMD";
					//bindVO.Value = BoSystemFormat.formatDate(f01m1VO.Dictionary[Te010p01Constant.DIC_M1SYUKKA_YMD].ToString());
					//bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					//bindList.Add(bindVO);

					//// 出荷会社コードを設定
					//bindVO = new BindInfoVO();
					//bindVO.BindId = "BIND_SYUKKAKAISYA_CD";
					//bindVO.Value = BoSystemFormat.formatKaisyaCd(logininfo.CopCd);
					//bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					//bindList.Add(bindVO);

					//// 出荷店舗コードを設定
					//bindVO = new BindInfoVO();
					//bindVO.BindId = "BIND_SYUKKATEN_CD";
					//bindVO.Value = BoSystemFormat.formatTenpoCd(f01m1VO.Dictionary[Te010p01Constant.DIC_M1TENPO_CD].ToString());
					//bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					//bindList.Add(bindVO);

					//// 排他チェック
					//bool blRef = V03003Check.CheckHaitaMaxVal(
					//			Convert.ToDecimal(f01m1VO.Dictionary[Te010p01Constant.DIC_M1UPD_YMD_SYUKKA].ToString()),
					//			Convert.ToDecimal(f01m1VO.Dictionary[Te010p01Constant.DIC_M1UPD_TM_SYUKKA].ToString()),
					//			facadeContext,
					//			"MDUT0010",
					//			sRepSql.ToString(),
					//			bindList,
					//			1,
					//			null,
					//			f01m1VO.M1rowno,
					//			iCnt.ToString(),
					//			"M1",
					//			m1List.DispRow
					//);
					//#endregion

					#region 移動入荷予定テーブル
					//// 移動出荷確定テーブルでエラーとなった場合は、処理しない。
					//if (blRef)
					//{

					ArrayList bindList2 = new ArrayList();
					BindInfoVO bindVO2 = new BindInfoVO();

					// 出荷会社コードを設定
					bindVO2 = new BindInfoVO();
					bindVO2.BindId = "BIND_SYUKKAKAISYA_CD";
					bindVO2.Value = BoSystemFormat.formatKaisyaCd(logininfo.CopCd);
					bindVO2.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList2.Add(bindVO2);

					// 出荷店舗コードを設定
					bindVO2 = new BindInfoVO();
					bindVO2.BindId = "BIND_SYUKKATEN_CD";
					bindVO2.Value = BoSystemFormat.formatTenpoCd(f01m1VO.Dictionary[Te010p01Constant.DIC_M1TENPO_CD].ToString());
					bindVO2.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList2.Add(bindVO2);

					// 伝票番号を設定
					bindVO2 = new BindInfoVO();
					bindVO2.BindId = "BIND_DENPYO_BANGO";
					bindVO2.Value = BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Te010p01Constant.DIC_M1DENPYO_BANGO].ToString());
					bindVO2.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList2.Add(bindVO2);

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal(f01m1VO.Dictionary[Te010p01Constant.DIC_M1UPD_YMD_NYUKA].ToString()),
							Convert.ToDecimal(f01m1VO.Dictionary[Te010p01Constant.DIC_M1UPD_TM_NYUKA].ToString()),
							facadeContext,
							"MDNT0010_" + f01m1VO.Dictionary[Te010p01Constant.DIC_M1JYURYOKAISYA_CD],
							sRepSql2.ToString(),
							bindList2,
							1,
							null,
							f01m1VO.M1rowno,
							iCnt.ToString(),
							"M1",
							m1List.DispRow
					);

					//}
					#endregion
				}
				iCnt++;
			}
			#endregion
		}
		#endregion
		#region 移動出荷検索_一覧 [移動入荷予定TBL(H,B)、移動出荷確定TBL(H,B)]を削除する。(SQL_ID_05、SQL_ID_08)
		/// <summary>
		/// 移動出荷検索_一覧 [移動入荷予定TBL(H,B)]を削除
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Te010f01M1Form">f01M1Form</param>
		/// <param name="decimal">delKbn</param>
		/// <returns>更新件数</returns>
		public static int Del_IdouTbl ( IFacadeContext facadeContext
												 , Te010f01M1Form f01M1Form
												 , decimal delKbn )

		{
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			FindSqlResultTable reader = null;
			string sTblID = "";
			string sWkJyuryoKaisyaCd = "";
			if (Te010p01Constant.DEL_KBN_YOTEI_HEAD == delKbn
			|| Te010p01Constant.DEL_KBN_YOTEI_BODY == delKbn)
			{
				reader = FindSqlUtil.CreateFindSqlResultTable(Te010p01Constant.SQL_ID_05, facadeContext.DBContext);
				// 入荷会社コード設定
				sWkJyuryoKaisyaCd = Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.Dictionary[Te010p01Constant.DIC_M1JYURYOKAISYA_CD].ToString(), "0")).ToString();
				if (Te010p01Constant.DEL_KBN_YOTEI_HEAD == delKbn)
				{
					// 削除TBL（移動入荷予定H）＋　入荷会社コード
					sTblID = "MDNT0010_" + sWkJyuryoKaisyaCd;
				}
				else if (Te010p01Constant.DEL_KBN_YOTEI_BODY == delKbn)
				{
					// 削除TBL（移動入荷予定B）＋　入荷会社コード
					sTblID = "MDNT0011_" + sWkJyuryoKaisyaCd;
				}
			}
			else
			{
				reader = FindSqlUtil.CreateFindSqlResultTable(Te010p01Constant.SQL_ID_08, facadeContext.DBContext);
				if (Te010p01Constant.DEL_KBN_KAKUTEI_HEAD == delKbn)
				{
					// 削除TBL（移動出荷確定H）
					sTblID = "MDUT0010";
				}
				else if (Te010p01Constant.DEL_KBN_KAKUTEI_BODY == delKbn)
				{
					// 削除TBL（移動出荷確定B）
					sTblID = "MDUT0011";
				}
			}
			// 削除テーブル設定
			BoSystemSql.AddSql(reader, Te010p01Constant.SQL_ADD_TBLID, sTblID);

			// -------------------------------------------
			// バインド変数の置き換え
			// -------------------------------------------
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(logininfo.CopCd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01M1Form.Dictionary[Te010p01Constant.DIC_M1TENPO_CD].ToString()));
			// 出荷日
			reader.BindValue("BIND_SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01M1Form.Dictionary[Te010p01Constant.DIC_M1SYUKKA_YMD].ToString(),"0"))));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.Dictionary[Te010p01Constant.DIC_M1DENPYO_BANGO].ToString(), "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#region 移動出荷検索_一覧 移動出荷履歴TBL(H,B)を登録する。(SQL_ID_06、SQL_ID_07)
		/// <summary>
		/// 移動出荷検索_一覧 [移動入荷予定TBL(H,B)]を削除
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Te010f01M1Form">f01M1Form</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="decimal">delKbn</param>
		/// <returns>更新件数</returns>
		public static int Ins_Rireki ( IFacadeContext facadeContext
												 , Te010f01M1Form f01M1Form
												 , SysDateVO sysDateVO
												 , decimal insKbn )
		{
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			FindSqlResultTable reader = null;
			// SQL設定
			if (Te010p01Constant.INS_KBN_HEAD == insKbn)
			{
				reader = FindSqlUtil.CreateFindSqlResultTable(Te010p01Constant.SQL_ID_06, facadeContext.DBContext);
			}
			else
			{
				reader = FindSqlUtil.CreateFindSqlResultTable(Te010p01Constant.SQL_ID_07, facadeContext.DBContext);
			}

			// -------------------------------------------
			// バインド変数の置き換え
			// -------------------------------------------
			// HEADの登録の場合
			if (Te010p01Constant.INS_KBN_HEAD == insKbn)
			{
				// 履歴処理日付
				reader.BindValue("BIND_RIREKI_UPD_YMD", sysDateVO.Sysdate);
				// 履歴処理時間
				reader.BindValue("BIND_RIREKI_UPD_TM", sysDateVO.Systime_mili);
				// 更新日
				reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
				// 更新時間
				reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
				// 更新担当者コード
				reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));

			}
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(logininfo.CopCd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01M1Form.Dictionary[Te010p01Constant.DIC_M1TENPO_CD].ToString()));
			// 出荷日
			reader.BindValue("BIND_SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01M1Form.Dictionary[Te010p01Constant.DIC_M1SYUKKA_YMD].ToString(), "0"))));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.Dictionary[Te010p01Constant.DIC_M1DENPYO_BANGO].ToString(), "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
