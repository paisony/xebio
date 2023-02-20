using com.xebio.bo.Tj170p01.Constant;
using com.xebio.bo.Tj170p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01012;
using Common.Business.V01000.V01019;
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

namespace com.xebio.bo.Tj170p01.Facade
{
  /// <summary>
  /// Tj170f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj170f01Facade : StandardBaseFacade
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

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj170f01Form f01VO = (Tj170f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);
				f01VO.Dictionary.Clear();

				#endregion

				#region 業務チェック
				// 警告結果感知
				string warningflg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0");
				if (!warningflg.Equals("1"))
				{

					#region 項目チェック
					// 1 単項目チェック
					// 1-1ヘッダ店舗コード												
					// 店舗MSTを検索し、存在しない場合エラー
					f01VO.Head_tenpo_nm = string.Empty;
					if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01019Check.CheckTenpoTanaorosijissiYmd(f01VO.Head_tenpo_cd, f01VO.Modeno, "1", facadeContext, "店舗", new[] { "Head_tenpo_cd" });
						// 名称をラベルに設定
						if (resultHash != null)
						{
							f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
							f01VO.Tanaorosikijun_ymd = resultHash["TANAOROSIKIJUN_YMD_KONKAI"].ToString();
							f01VO.Tanaorosijissi_ymd1 = resultHash["TANAOROSIJISSI_YMD_KONKAI"].ToString();
							f01VO.Tanaorosikikan_from1 = resultHash["TANAOROSIKIKAN_FROM_KONKAI"].ToString();
							f01VO.Tanaorosikikan_to1 = resultHash["TANAOROSIKIKAN_TO_KONAKI"].ToString();
							f01VO.Tanaorosikijun_ymd1 = resultHash["TANAOROSIKIJUN_YMD_ZENKAI"].ToString();
							f01VO.Tanaorosijissi_ymd11 = resultHash["TANAOROSIJISSI_YMD_ZENKAI"].ToString();
							f01VO.Tanaorosikikan_from11 = resultHash["TANAOROSIKIKAN_FROM_ZENKAI"].ToString();
							f01VO.Tanaorosikikan_to11 = resultHash["TANAOROSIKIKAN_TO_ZENKAI"].ToString();
						}
					}
					// 1-2 商品群1コード												
					// 商品群1MSTを検索し、存在しない場合エラー
					f01VO.Syohingun1_ryaku_nm = string.Empty;
					if (!string.IsNullOrEmpty(f01VO.Syohingun1_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01008Check.CheckSyohingun(f01VO.Syohingun1_cd
															, facadeContext
															, string.Empty
															, null
															, "商品群1"
															, new[] { "Syohingun1_cd" }
															, null
															, null
															, null
															, 0
															, 0
															);
						// 名称をラベルに設定
						if (resultHash != null)
						{
							f01VO.Syohingun1_ryaku_nm = (string)resultHash["SYOHINGUN1_RYAKU_NM"];
						}
					}
					// 1-3 商品群２コード
					// 商品群２マスタ（グループマスタ）を検索し、存在しない場合エラー
					f01VO.Grpnm = string.Empty;
					if (!string.IsNullOrEmpty(f01VO.Syohingun2_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01009Check.CheckSyohingun2(f01VO.Syohingun2_cd
															, facadeContext
															, string.Empty
															, null
															, "商品群2"
															, new[] { "Syohingun2_cd" }
															, null
															, null
															, null
															, 0
															, 0
															);
						// 名称をラベルに設定
						if (resultHash != null)
						{
							f01VO.Grpnm = (string)resultHash["GRPNM"];
						}
					}
					// 1-4 ブランドコード
					// ブランドMSTを検索し、存在しない場合エラー
					f01VO.Burando_nm = string.Empty;
					if (!string.IsNullOrEmpty(f01VO.Burando_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01012Check.CheckBrand(f01VO.Burando_cd
															, facadeContext
															, string.Empty
															, null
															, "ブランド"
															, new[] { "Burando_cd" }
															, null
															, null
															, null
															, 0
															, 0
															);
						// 名称をラベルに設定
						if (resultHash != null)
						{
							f01VO.Burando_nm = (string)resultHash["BURANDO_NMK"];
						}
					}
					#endregion
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#region 関連チェック
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

					// 2-2 部門コードFROM、品種コードFROM
					// 部門コードＦＲＯＭが未入力で、品種コードFROMを入力した場合エラー
					if (string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Hinsyu_cd_from))
					{
						ErrMsgCls.AddErrMsg("E183", string.Empty, facadeContext, new[] { "Bumon_cd_from", "Hinsyu_cd_from" });
					}

					// 2-3 部門コードTO、品種コードTO
					// 部門コードTOが未入力で、品種コードTOを入力した場合エラー
					if (string.IsNullOrEmpty(f01VO.Bumon_cd_to) && !string.IsNullOrEmpty(f01VO.Hinsyu_cd_to))
					{
						ErrMsgCls.AddErrMsg("E183", string.Empty, facadeContext, new[] { "Bumon_cd_to", "Hinsyu_cd_to" });
					}

					// 2-4 部門コードFROM、部門コードTO、品種コードFROM、品種コードTO
					// 部門コードFROM、部門コードTOが同じ値で、品種コードFROM＞品種コードTOの場合エラー
					if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Bumon_cd_to) && f01VO.Bumon_cd_from.Equals(f01VO.Bumon_cd_to))
					{
						if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd_from) && !string.IsNullOrEmpty(f01VO.Hinsyu_cd_to))
						{
							V03002Check.CodeFromToChk(
											f01VO.Hinsyu_cd_from,
											f01VO.Hinsyu_cd_to,
											facadeContext,
											"品種",
											new[] { "Hinsyu_cd_from", "Hinsyu_cd_to" }
											);
						}
					}
					#endregion
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#region 業者棚卸データ存在チェック
					FindSqlResultTable rtGyosyaChk = FindSqlUtil.CreateFindSqlResultTable(Tj170p01Constant.SQL_ID_05, facadeContext.DBContext);

					// 店舗コード
					rtGyosyaChk.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸日
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KONKAI))
					{
						// 今回
						rtGyosyaChk.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01VO.Tanaorosikijun_ymd)));
					}
					else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_ZENKAI))
					{
						// 前回
						rtGyosyaChk.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01VO.Tanaorosikijun_ymd1)));
					}
					//検索結果を取得します
					rtGyosyaChk.CreateDbCommand();
					IList<Hashtable> tabaleListGyosya = rtGyosyaChk.Execute();
					if (tabaleListGyosya.Count == 0)
					{
						// 警告メッセージを設定する
						InfoMsgCls.AddWarnMsg("W121", String.Empty, facadeContext);
					}
					else
					{
						Hashtable result = tabaleListGyosya[0];
						decimal dCntGyosya = (Decimal)result["CNT"];
						if (dCntGyosya == 0)
						{
							// 警告メッセージを設定する
							InfoMsgCls.AddWarnMsg("W121", String.Empty, facadeContext);
						}
					}
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}
					#endregion
				}

				#region 件数チェック
				// 3 検索件数チェック
				Decimal dCnt = 0;
				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj170p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 検索テーブル設定
				AddFrom(f01VO, rtChk);

				// 検索条件設定
				AddWhere(f01VO, rtChk, 0);

				// 集計条件設定
				AddGroupBy(f01VO, rtChk);

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
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 検索処理

				// 検索処理
				// ボディ部(カード)の条件を元に[棚卸確定TBL(H)]の検索処理を実行する。
				FindSqlResultTable rtSsarch = FindSqlUtil.CreateFindSqlResultTable(Tj170p01Constant.SQL_ID_02, facadeContext.DBContext);

				// 検索項目設定
				AddSelect(f01VO, rtSsarch);

				// 検索テーブル設定
				AddFrom(f01VO, rtSsarch);

				// 検索条件設定
				AddWhere(f01VO, rtSsarch, 1);

				// 集計条件設定
				AddGroupBy(f01VO, rtSsarch);

				// ソート条件設定
				AddSort(f01VO, rtSsarch);

				//検索結果を取得します
				rtSsarch.CreateDbCommand();
				IList<Hashtable> tableList = rtSsarch.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tj170f01M1Form f01m1VO = new Tj170f01M1Form();
					f01m1VO.M1rowno = iCnt.ToString();
					f01m1VO.M1syohingun2_cd = rec["SYOHINGUN2_CD"].ToString();
					f01m1VO.M1grpnm = rec["GRPNM"].ToString();
					f01m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();
					f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();
					f01m1VO.M1tanajityobo_su = rec["TANAJITYOBO_SU"].ToString();
					f01m1VO.M1tanajisekiso_su = rec["TANAJISEKISO_SU"].ToString();
					f01m1VO.M1jitana_su = rec["JITANA_SU"].ToString();
					f01m1VO.M1ikoukebarai_su = rec["IKOUKEBARAI_SU"].ToString();
					f01m1VO.M1rironzaiko_su = rec["RIRONZAIKO_SU"].ToString();
					f01m1VO.M1rirontanaorosi_su = rec["RIRONTANAOROSI_SU"].ToString();
					f01m1VO.M1loss_su = rec["LOSS_SU"].ToString();
					f01m1VO.M1loss_kin = rec["LOSS_KIN"].ToString();
					f01m1VO.M1selectorcheckbox = "0";													// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = "0";														// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = "0";															// Ｍ１明細色区分(隠し)

					// Dictionary
					f01m1VO.Dictionary.Add(Tj170p01Constant.DIC_M1SYOHINGUN1_CD, BoSystemFormat.formatSyohingunCd(rec["SYOHINGUN1_CD"].ToString()));	// 色コード
					f01m1VO.Dictionary.Add(Tj170p01Constant.DIC_M1SYOHINGUN1_RYAKU_NM, (rec["SYOHINGUN1_RYAKU_NM"].ToString()));	// 色コード


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

				// ラジオ[出力帳票]の初期値設定
				f01VO.Shuturyoku_print = ConditionShuturyoku_print.VALUE_SHUTURYOKU_PRINT1;

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
		#region ユーザー定義関数

		#region 出力項目
		private void AddSelect(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			StringBuilder sRepSql = new StringBuilder();
			if (f01VO.Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI1))
			{
				sRepSql.Append(" ,'' AS SYOHINGUN2_CD");
				sRepSql.Append(" ,'' AS GRPNM");
				sRepSql.Append(" ,'' AS BUMON_CD");
				sRepSql.Append(" ,'' AS BUMONKANA_NM");
			}
			else if (f01VO.Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI2))
			{
				sRepSql.Append(" ,A.SYOHINGUN2_CD	AS SYOHINGUN2_CD	");
				sRepSql.Append(" ,(SELECT STMT0060.GRPNM FROM STMT0060 WHERE A.SYOHINGUN2_CD = TO_NUMBER(STMT0060.GRPCD) AND STMT0060.SOSIKI = '0001' AND TENCD = '0000') GRPNM");
				sRepSql.Append(" ,'' AS BUMON_CD");
				sRepSql.Append(" ,'' AS BUMONKANA_NM");
			}
			else if (f01VO.Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI3))
			{
				sRepSql.Append(" ,A.SYOHINGUN2_CD	AS SYOHINGUN2_CD");
				sRepSql.Append(" ,(SELECT STMT0060.GRPNM FROM STMT0060 WHERE A.SYOHINGUN2_CD = TO_NUMBER(STMT0060.GRPCD) AND STMT0060.SOSIKI = '0001' AND TENCD = '0000') GRPNM");
				sRepSql.Append(" ,A.BUMON_CD	AS BUMON_CD");
				sRepSql.Append(" ,(SELECT BOMT0060.BUMONKANA_NM FROM BOMT0060 WHERE A.BUMON_CD = BOMT0060.BUMON_CD) BUMONKANA_NM");
			}
			BoSystemSql.AddSql(reader, Tj170p01Constant.REP_ADD_SELECT, sRepSql.ToString());
		}
		#endregion

		#region 検索テーブル
		private void AddFrom(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			#region モード/ロス有フラグ

			string modeNo = f01VO.Modeno;
			string lossAriFlg = f01VO.Loss_ari_flg;
			StringBuilder sRepSql = new StringBuilder();

			if (!string.IsNullOrEmpty(f01VO.Loss_tensu))
			{
				lossAriFlg = ConditionSelect_flg.VALUE_ARI;
			}

			sRepSql.Append(" FROM ");
			// [選択モードNo]が｢今回｣かつ、[ロス有フラグ]が選択の場合、[棚卸ロス(今回)ロス有りTBL]から検索する。
			if (modeNo.Equals(BoSystemConstant.MODE_KONKAI)
				&& lossAriFlg.Equals(ConditionSelect_flg.VALUE_ARI))
			{
				sRepSql.Append(" MDIT0104 A");
			}
			// [選択モードNo]が｢今回｣かつ、[ロス有フラグ]が未選択の場合、[棚卸ロス(今回)部門サマリTBL]から検索する。
			else if (modeNo.Equals(BoSystemConstant.MODE_KONKAI)
				&& lossAriFlg.Equals(ConditionSelect_flg.VALUE_NASI))
			{
				sRepSql.Append(" MDIT0102 A");
			}
			// [選択モードNo]が｢前回｣かつ、[ロス有フラグ]が選択の場合、[棚卸ロス(前回)[ロス有フラグ]TBL]から検索する。
			else if (modeNo.Equals(BoSystemConstant.MODE_ZENKAI)
				&& lossAriFlg.Equals(ConditionSelect_flg.VALUE_ARI))
			{
				sRepSql.Append(" MDIT0105 A");
			}
			// [選択モードNo]が｢前回｣かつ、[ロス有フラグ]が未選択の場合、[棚卸ロス(前回)部門サマリTBL]から検索する。"																								
			else if (modeNo.Equals(BoSystemConstant.MODE_ZENKAI)
				&& lossAriFlg.Equals(ConditionSelect_flg.VALUE_NASI))
			{
				sRepSql.Append(" MDIT0103 A");
			}


			BoSystemSql.AddSql(reader, Tj170p01Constant.SQL_ID_REP_TABLE, sRepSql.ToString());

			#endregion
		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Tj170f01Form">f01VO</param>
		/// <returns></returns>
		private void AddWhere(Tj170f01Form f01VO, FindSqlResultTable reader, int flg)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" WHERE 0=0 ");
			#region 店舗コード
			sRepSql.Append(" AND A.TENPO_CD = :BIND_TENPO_CD" + flg.ToString());

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD" + flg.ToString();
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			#endregion
			#region 棚卸基準日
			sRepSql.Append(" AND A.TANAOROSI_YMD = :BIND_TANAOROSI_YMD" + flg.ToString());
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TANAOROSI_YMD" + flg.ToString();
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KONKAI))
			{
				// 今回
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Tanaorosikijun_ymd);
			}
			else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_ZENKAI))
			{
				// 前回
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Tanaorosikijun_ymd1);
			}
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);


			#endregion
			#region 商品群1
			if (!string.IsNullOrEmpty(f01VO.Syohingun1_cd))
			{
				sRepSql.Append("	AND A.SYOHINGUN1_CD   = :BIND_SYOHINGIN1_CD" + flg.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYOHINGIN1_CD" + flg.ToString();
				bindVO.Value = f01VO.Syohingun1_cd;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region 商品群2
			if (!string.IsNullOrEmpty(f01VO.Syohingun2_cd))
			{
				sRepSql.Append("	AND A.SYOHINGUN2_CD   = :BIND_SYOHINGIN2_CD" + flg.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYOHINGIN2_CD" + flg.ToString();
				bindVO.Value = f01VO.Syohingun2_cd;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region 部門コードFROM、品種コードFROM

			String sBumonCdFrom = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_from);
			String sHInshuCdFrom = BoSystemFormat.formatHinsyuCd(f01VO.Hinsyu_cd_from);
			// [部門コードFROM]が入力されていない場合"000"に置き換える。[品種コードFROM]が入力されていない場合"00"に置き換える。
			if (string.IsNullOrEmpty(sBumonCdFrom))
			{
				sBumonCdFrom = "000";
			}
			if (string.IsNullOrEmpty(sHInshuCdFrom))
			{
				sHInshuCdFrom = "00";
			}

			// [部門コードFROM]と[品種コードFROM]を文字結合した結果が"00000"以外の場合に条件とする。
			if (!"00000".Equals(sBumonCdFrom + sHInshuCdFrom))
			{
				sRepSql.Append(" AND (TRIM(TO_CHAR(A.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(A.HINSYU_CD,'00'),'00'))) >= :BIND_BUMON_FROM" + flg.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_FROM" + flg.ToString();
				bindVO.Value = sBumonCdFrom + sHInshuCdFrom;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region 部門コードTO、品種コードTO

			String sBumonCdTo = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_to);
			String sHInshuCdTo = BoSystemFormat.formatHinsyuCd(f01VO.Hinsyu_cd_to);
			// [部門コードTO]が入力されていない場合"000"に置き換える。[品種コードTO]が入力されていない場合"00"に置き換える。
			if (string.IsNullOrEmpty(sBumonCdTo))
			{
				sBumonCdTo = "999";
			}
			if (string.IsNullOrEmpty(sHInshuCdTo))
			{
				sHInshuCdTo = "99";
			}

			// [部門コードTO]と[品種コードTO]を文字結合した結果が"00000"以外の場合に条件とする。
			if (!"99999".Equals(sBumonCdTo + sHInshuCdTo))
			{
				sRepSql.Append(" AND (TRIM(TO_CHAR(A.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(A.HINSYU_CD,'00'),'00'))) <= :BIND_BUMON_TO" + flg.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_TO" + flg.ToString();
				bindVO.Value = sBumonCdTo + sHInshuCdTo;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region ブランド
			if (!string.IsNullOrEmpty(f01VO.Burando_cd))
			{
				sRepSql.Append("	AND A.BURANDO_CD = :BIND_BURANDO_CD" + flg.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD" + flg.ToString();
				bindVO.Value = BoSystemFormat.formatBrandCd(f01VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region ロス点数
			if (!string.IsNullOrEmpty(f01VO.Loss_tensu))
			{
				sRepSql.Append("	AND ABS(A.LOSS_SU)  >= :BIND_LOSS_SU" + flg.ToString());

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_LOSS_SU" + flg.ToString();
				bindVO.Value = f01VO.Loss_tensu;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			string nm = string.Empty;
			nm = Tj170p01Constant.REP_ADD_WHERE + flg.ToString();

			BoSystemSql.AddSql(reader, nm, sRepSql.ToString(), bindList);
		}
		#endregion

		#region 集計条件設定
		private void AddGroupBy(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			#region 出力単位
			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" GROUP BY ");
			if (f01VO.Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI1))
			{
				sRepSql.Append(" 	A.TENPO_CD");
				sRepSql.Append(" 	,A.TANAOROSI_YMD");
				sRepSql.Append(" 	,A.SYOHINGUN1_CD");
			}
			else if (f01VO.Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI2))
			{
				sRepSql.Append(" 	A.TENPO_CD");
				sRepSql.Append(" 	,A.TANAOROSI_YMD");
				sRepSql.Append(" 	,A.SYOHINGUN1_CD");
				sRepSql.Append(" 	,A.SYOHINGUN2_CD");
			}
			else if (f01VO.Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI3))
			{
				sRepSql.Append(" 	A.TENPO_CD");
				sRepSql.Append(" 	,A.TANAOROSI_YMD");
				sRepSql.Append(" 	,A.SYOHINGUN1_CD");
				sRepSql.Append(" 	,A.SYOHINGUN2_CD");
				sRepSql.Append(" 	,A.BUMON_CD");
			}
			BoSystemSql.AddSql(reader, Tj170p01Constant.REP_ADD_GROUP_BY, sRepSql.ToString());
			#endregion
		}

		#endregion

		#region ソート条件
		private void AddSort(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" ORDER BY ");
			sRepSql.Append(" TENPO_CD ");
			sRepSql.Append(" ,TANAOROSI_YMD");

			if (f01VO.Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN1)
				|| f01VO.Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN4))
			{
				sRepSql.Append(" 	,SYOHINGUN1_CD");
				sRepSql.Append(" 	,SYOHINGUN2_CD");
				sRepSql.Append(" 	,BUMON_CD");
			}
			else if (f01VO.Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN2))
			{
				sRepSql.Append("	,LOSS_SU DESC ");
				sRepSql.Append("	,SYOHINGUN1_CD ");
				sRepSql.Append("	,SYOHINGUN2_CD");
				sRepSql.Append(" 	,BUMON_CD");
			}
			else if (f01VO.Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN3))
			{
				sRepSql.Append("	,LOSS_KIN DESC");
				sRepSql.Append("	,SYOHINGUN1_CD ");
				sRepSql.Append("	,SYOHINGUN2_CD");
				sRepSql.Append(" 	,BUMON_CD");
			}
			BoSystemSql.AddSql(reader, Tj170p01Constant.REP_ADD_ORDER_BY, sRepSql.ToString());

		}
		#endregion

		#endregion
	}
}
