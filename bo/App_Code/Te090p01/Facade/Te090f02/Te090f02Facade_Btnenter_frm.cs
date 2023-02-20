using com.xebio.bo.Te090p01.Constant;
using com.xebio.bo.Te090p01.Formvo;
using com.xebio.bo.Te090p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01015;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Text;

namespace com.xebio.bo.Te090p01.Facade
{
  /// <summary>
  /// Te090f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te090f02Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
			//StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

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
				Te090f02Form f02VO = (Te090f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Te090f01M1Form f01M1Form = (Te090f01M1Form)f02VO.Dictionary[Te090p01Constant.DIC_M1SELCETVO];

				decimal dSumSu = 0;		// 合計数量
				decimal dSumKin = 0;	// 合計金額
				decimal saiflg = 0;		// 差異フラグ

				#endregion

				#region 業務チェック

				decimal warninngFlg = Convert.ToDecimal(BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0"));
				if (warninngFlg != 1)
				{

					#region 入力値チェック

					//int meisaiErr = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Te090f02M1Form f02m1VO = (Te090f02M1Form)m1List[i];
						
						// 1-1 Ｍ１確定数量
						//       Ｍ１予定数量＜Ｍ１確定数量の場合、エラー
						if (!string.IsNullOrEmpty(f02m1VO.M1kakutei_su)
							&& Convert.ToDecimal(f02m1VO.M1yotei_su) < Convert.ToDecimal(f02m1VO.M1kakutei_su))
						{
							//meisaiErr = 1;
							ErrMsgCls.AddErrMsg("E214", "", facadeContext, new[] { "M1kakutei_su" }, f02m1VO.M1rowno, i.ToString(), "M1");
						}


						// 合計数、合計金額の計算
						decimal su = 0;
						decimal genka = 0;
						if (string.IsNullOrEmpty(f02m1VO.M1kakutei_su))
						{
							// 未入力の場合は予定数をそのまま設定
							su = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1yotei_su, "0"));
							genka = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0"));
						}
						else
						{
							su = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kakutei_su, "0"));
							genka = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0"));
						}
						dSumSu = dSumSu + su;				// 合計数量
						dSumKin = dSumKin + (su * genka);	// 合計金額
					}

					// ------------------------------------------------------------------------------------
					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion

					#region 桁あふれチェック
					// 2-1 合計確定数量
					//       合計確定数量＞999999（6桁）の場合、エラー
					if (dSumSu > 999999)
					{
						// 合計確定数量が有効桁数を超えています。
						ErrMsgCls.AddErrMsg("E102", "合計確定数量", facadeContext);
					}

					// 2-2 原価金額合計
					//       原価金額合計＞999999999（9桁）の場合、エラー
					if (dSumKin > 999999999)
					{
						// 合計原価金額が有効桁数を超えています。
						ErrMsgCls.AddErrMsg("E102", "合計原価金額", facadeContext);
					} 
					// ------------------------------------------------------------------------------------
					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion

					#region 入力値チェック(ワーニング)

					for (int i = 0; i < m1List.Count; i++)
					{
						Te090f02M1Form f02m1VO = (Te090f02M1Form)m1List[i];

						// 1-2 Ｍ１確定数量
						//       Ｍ１予定数量＞Ｍ１確定数量の場合、警告
						if (!string.IsNullOrEmpty(f02m1VO.M1kakutei_su)
							&& Convert.ToDecimal(f02m1VO.M1yotei_su) > Convert.ToDecimal(f02m1VO.M1kakutei_su))
						{
							InfoMsgCls.AddWarnMsg("W118", String.Empty, facadeContext, new[] { "M1kakutei_su" }, f02m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}

					}
					// ------------------------------------------------------------------------------------
					// ワーニングが発生した場合、その時点でチェックを中止しクライアント側へワーニング内容を返却する。
					// ------------------------------------------------------------------------------------
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}
					#endregion

				}

				#region 排他チェック(予定)

				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				string haitaTbl = "MDNT0010";	// 移動入荷予定


				sRepSql.Append(" AND TENPOLC_KBN = :BIND_TENPOLC_KBN");
				sRepSql.Append(" AND SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD");
				sRepSql.Append(" AND SYUKKATEN_CD = :BIND_SYUKKATEN_CD");
				sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");

				// 店舗LC区分
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPOLC_KBN";
				bindVO.Value = (string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 出荷会社コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKAKAISYA_CD";
				bindVO.Value = (string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 出荷店コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYUKKATEN_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01M1Form.M1syukkaten_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 伝票番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);


				// 排他チェック
				V03003Check.CheckHaitaMaxVal(
						Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_YOTEI], "0")),
						Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1UPD_TM_YOTEI], "0")),
						facadeContext,
						haitaTbl,
						sRepSql.ToString(),
						bindList,
						1,
						//new[] { "M1kanri_no" },
						null,
						null,
						null,
						null,
						0
				);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック(確定)
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD))
				{
					// 確定後修正の場合

					sRepSql = new StringBuilder();
					bindList = new ArrayList();
					bindVO = new BindInfoVO();
					haitaTbl = "MDNT0020";	// 入荷確定


					sRepSql.Append(" AND TENPOLC_KBN = :BIND_TENPOLC_KBN");
					sRepSql.Append(" AND SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD");
					sRepSql.Append(" AND SYUKKATEN_CD = :BIND_SYUKKATEN_CD");
					sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");
					sRepSql.Append(" AND SYUKKA_YMD = :BIND_SYUKKA_YMD");


					// 店舗LC区分
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPOLC_KBN";
					bindVO.Value = (string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 出荷会社コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYUKKAKAISYA_CD";
					bindVO.Value = (string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 出荷店コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYUKKATEN_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd(f01M1Form.M1syukkaten_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 伝票番号
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DENPYO_BANGO";
					bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 出荷日
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYUKKA_YMD";
					bindVO.Value = BoSystemFormat.formatDate(f01M1Form.M1syukka_ymd);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);


					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_KAKUTEI], "0")),
							Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1UPD_TM_KAKUTEI], "0")),
							facadeContext,
							haitaTbl,
							sRepSql.ToString(),
							bindList,
							1,
							//new[] { "M1kanri_no" },
							null,
							null,
							null,
							null,
							0
					);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 更新前処理

				dSumSu = 0;		// 合計数量
				dSumKin = 0;	// 合計金額
				for (int i = 0; i < m1List.Count; i++)
				{
					Te090f02M1Form f02m1VO = (Te090f02M1Form)m1List[i];

					// 合計数、合計金額の計算
					decimal su = 0;
					decimal genka = 0;
					if (string.IsNullOrEmpty(f02m1VO.M1kakutei_su))
					{
						// 未入力の場合は予定数をそのまま設定
						su = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1yotei_su, "0"));
						genka = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0"));
					}
					else
					{
						su = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kakutei_su, "0"));
						genka = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0"));
					}
					dSumSu = dSumSu + su;				// 合計数量
					dSumKin = dSumKin + (su * genka);	// 合計金額
					if (su != Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1yotei_su, "0")))
					{
						// 確定数と予定数が異なる場合、差異フラグを立てる
						saiflg = 1;
					}
				}
				#endregion

				#region 更新処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
				{
					#region 入荷確定の更新処理
					// -----------------------------------------
					// [選択モードNo]が「入荷確定」の場合
					// -----------------------------------------

					// [移動入荷予定TBL(H)]を更新する。
					BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 START");
					int UpdCntH_NyukaYotei = Te090p01Util.Upd_NyukaYoteiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, saiflg);
					BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 END");

					// [移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録する。
					BoSystemLog.logOut("[移動入荷確定TBL(H)]を登録 START");
					int InsCntB_NyukaKakutei = Te090p01Util.Ins_NyukaKakuteiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, saiflg, dSumSu, dSumKin);
					BoSystemLog.logOut("[移動出荷確定TBL(H)]を登録 END");

					// 明細単位で以下の処理を実施する。
					for (int i = 0; i < m1List.Count; i++)
					{
						Te090f02M1Form f02m1VO = (Te090f02M1Form)m1List[i];

						// [移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録する。
						BoSystemLog.logOut("[移動入荷確定TBL(B)]を登録 START");
						decimal kakuteisu = 0;
						if (string.IsNullOrEmpty(f02m1VO.M1kakutei_su))
						{
							// 未入力の場合は予定数で登録
							kakuteisu = Convert.ToDecimal(f02m1VO.M1yotei_su);
						}
						else
						{
							kakuteisu = Convert.ToDecimal(f02m1VO.M1kakutei_su);
						}
						int InsCntB_Nyukakakutei = Te090p01Util.Ins_NyukaKakuteiB_Detail(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, Convert.ToDecimal(i + 1), kakuteisu);
						BoSystemLog.logOut("[移動入荷確定TBL(B)]を登録 END");

						// Dictionary.[店舗LC区分]が0(店舗)の場合、以下の処理を実施する。
						if (((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]).Equals(Te090p01Constant.TENPO_LC_KBN_TENPO))
						{
							// [移動入荷確定TBL(B)]を登録した値を元に[移動出荷確定TBL(B)]を更新する。
							BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 START");
							int UpdCntB_Syukka = Te090p01Util.Upd_SyukkaKakuteiB(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 END");
						}
					}

					// [Ｍ１予定数量]と[Ｍ１確定数量]の値が違う場合、かつ [店舗LC区分]が0(店舗)の場合、以下の処理を実施する。
					if (saiflg == 1 && ((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]).Equals(Te090p01Constant.TENPO_LC_KBN_TENPO))
					{
						// [移動入荷確定TBL(H)][移動入荷確定TBL(B)]を検索し、[移動出荷差異リスト]を登録する。
						BoSystemLog.logOut("[移動出荷差異リスト]を登録 START");
						int InsCntH_SyukkaSai = Te090p01Util.	Ins_SyukkaSaiL(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO);
						BoSystemLog.logOut("[移動出荷差異リスト]を登録 END");
					}

					// [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録する。
					BoSystemLog.logOut("[移動入荷履歴TBL(H)]を登録 START");
					int InsCntH_NyukaRirekiKuro = Te090p01Util.Ins_NyukaRirekiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, Te090p01Constant.AKAKURO_KURO);
					BoSystemLog.logOut("[移動入荷履歴TBL(H)]を登録 END");

					// [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録する。
					BoSystemLog.logOut("[移動入荷履歴TBL(B)]を登録 START");
					int InsCntB_NyukaRirekiKuro = Te090p01Util.Ins_NyukaRirekiB(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, Te090p01Constant.AKAKURO_KURO);
					BoSystemLog.logOut("[移動入荷履歴TBL(B)]を登録 END");

					// 対象行のDictionary.[店舗LC区分]が0(店舗)の場合、以下の処理を実施する。
					if (((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]).Equals(Te090p01Constant.TENPO_LC_KBN_TENPO))
					{
						// [移動入荷確定TBL(H)]を登録した値を元に[移動出荷確定TBL(H)]を更新する。
						BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 START");
						int UpdCntB_Syukka = Te090p01Util.Upd_SyukkaKakuteiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO);
						BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 END");
					}

					// [移動入荷予定未存在リストTBL]を更新する。
					BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を更新 START");
					int UpdCnt_Misonzai = Te090p01Util.Upd_MisonzaiList(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, f02VO.Head_tenpo_cd);
					BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を更新 END");
					#endregion
				}
				else
				{
					#region 確定後修正の更新処理
					// -----------------------------------------
					// [選択モードNo]が「確定後修正」の場合
					// -----------------------------------------

					// [移動入荷予定TBL(H)]を更新する。
					BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 START");
					int UpdCntH_NyukaYotei = Te090p01Util.Upd_NyukaYoteiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, saiflg);
					BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 END");

					// [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]（赤伝）を登録する。
					BoSystemLog.logOut("[移動入荷履歴TBL(H)]（赤伝）を登録 START");
					int InsCntH_NyukaRirekiAka = Te090p01Util.Ins_NyukaRirekiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, Te090p01Constant.AKAKURO_AKA);
					BoSystemLog.logOut("[移動入荷履歴TBL(H)]（赤伝）を登録 END");

					// [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]（赤伝）を登録する。
					BoSystemLog.logOut("[移動入荷履歴TBL(B)]（赤伝）を登録 START");
					int InsCntB_NyukaRirekiAka = Te090p01Util.Ins_NyukaRirekiB(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, Te090p01Constant.AKAKURO_AKA);
					BoSystemLog.logOut("[移動入荷履歴TBL(B)]（赤伝）を登録 END");

					// [移動入荷確定TBL(H)]を更新する。
					BoSystemLog.logOut("[移動入荷確定TBL(H)]を更新 START");
					int UpdCntH_NyukaKakutei = Te090p01Util.Upd_NyukaKakuteiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, saiflg, dSumSu, dSumKin);
					BoSystemLog.logOut("[移動入荷確定TBL(H)]を更新 END");

					// [移動入荷確定TBL(B)]を削除する。
					BoSystemLog.logOut("[移動入荷確定TBL(B)]を削除 START");
					int DelCntH_NyukaYotei = Te090p01Util.Del_NyukaKakuteiB(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[移動入荷確定TBL(B)]を削除 END");

					// [移動出荷差異リスト]を削除する。
					BoSystemLog.logOut("[移動出荷差異リスト]を削除 START");
					int DelCntH_SyukkaSai = Te090p01Util.Del_SyukkaSaiL(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[移動出荷差異リスト]を削除 END");

					// 明細単位で以下の処理を実施する。
					for (int i = 0; i < m1List.Count; i++)
					{
						Te090f02M1Form f02m1VO = (Te090f02M1Form)m1List[i];


						// [移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録する。
						BoSystemLog.logOut("[移動入荷確定TBL(B)]を登録 START");
						decimal kakuteisu = 0;
						if (string.IsNullOrEmpty(f02m1VO.M1kakutei_su))
						{
							// 未入力の場合は予定数で登録
							kakuteisu = Convert.ToDecimal(f02m1VO.M1yotei_su);
						}
						else
						{
							kakuteisu = Convert.ToDecimal(f02m1VO.M1kakutei_su);
						}
						int InsCntB_Nyukakakutei = Te090p01Util.Ins_NyukaKakuteiB_Detail(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, Convert.ToDecimal(i + 1), kakuteisu);
						BoSystemLog.logOut("[移動入荷確定TBL(B)]を登録 END");

						// Dictionary.[店舗LC区分]が0(店舗)の場合、以下の処理を実施する。
						if (((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]).Equals(Te090p01Constant.TENPO_LC_KBN_TENPO))
						{
							// [移動入荷確定TBL(B)]を登録した値を元に[移動出荷確定TBL(B)]を更新する。
							BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 START");
							int UpdCntB_Syukka = Te090p01Util.Upd_SyukkaKakuteiB(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 END");
						}
					}
					
					// [Ｍ１予定数量]と[Ｍ１確定数量]の値が違う場合、かつ [店舗LC区分]が0(店舗)の場合、以下の処理を実施する。
					if (saiflg == 1 && ((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]).Equals(Te090p01Constant.TENPO_LC_KBN_TENPO))
					{
						// [移動入荷確定TBL(H)][移動入荷確定TBL(B)]を検索し、[移動出荷差異リスト]を登録する。
						BoSystemLog.logOut("[移動出荷差異リスト]を登録 START");
						int InsCntH_SyukkaSai = Te090p01Util.Ins_SyukkaSaiL(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO);
						BoSystemLog.logOut("[移動出荷差異リスト]を登録 END");
					}

					// 対象行のDictionary.[店舗LC区分]が0(店舗)の場合、以下の処理を実施する。
					if (((string)f01M1Form.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]).Equals(Te090p01Constant.TENPO_LC_KBN_TENPO))
					{
						// [移動入荷確定TBL(H)]を更新した値を元に[移動出荷確定TBL(H)]を更新する。
						BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 START");
						int UpdCntB_Syukka = Te090p01Util.Upd_SyukkaKakuteiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO);
						BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 END");
					}

					// [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]（黒伝）を登録する。
					BoSystemLog.logOut("[移動入荷履歴TBL(H)]（黒伝）を登録 START");
					int InsCntH_NyukaRirekiKuro = Te090p01Util.Ins_NyukaRirekiH(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, Te090p01Constant.AKAKURO_KURO);
					BoSystemLog.logOut("[移動入荷履歴TBL(H)]（黒伝）を登録 END");

					// [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]（黒伝）を登録する。
					BoSystemLog.logOut("[移動入荷履歴TBL(B)]（黒伝）を登録 START");
					int InsCntB_NyukaRirekiKuro = Te090p01Util.Ins_NyukaRirekiB(facadeContext, f02VO.Stkmodeno, f01M1Form, logininfo, sysDateVO, Te090p01Constant.AKAKURO_KURO);
					BoSystemLog.logOut("[移動入荷履歴TBL(B)]（黒伝）を登録 END");

					#endregion
				}

				#endregion

				#region 画面の表示

				// ヘッダ情報を更新する。
				f01M1Form.M1jyuryo_ymd = sysDateVO.Sysdate.ToString();
				f01M1Form.M1kakutei_su = dSumSu.ToString();															// 合計数量
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;									// 確定処理フラグ
				// M１伝票状態の取得
				Hashtable tmpMeisho = V01015Check.CheckMeisyo(BoSystemConstant.MEISYOMST_SIKIBETSU_IDST,	// 識別コード（伝票状態）
															  "1",											// 名称コード（確定）
															  facadeContext
															  );

				f01M1Form.M1denpyo_jyotainm = tmpMeisho["MEISYO_NM"].ToString();

				f01M1Form.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_YOTEI] = sysDateVO.Sysdate.ToString();			// 更新日付
				f01M1Form.Dictionary[Te090p01Constant.DIC_M1UPD_TM_YOTEI] = sysDateVO.Systime_mili.ToString();		// 更新時間
				f01M1Form.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_KAKUTEI] = sysDateVO.Sysdate.ToString();		// 更新日付
				f01M1Form.Dictionary[Te090p01Constant.DIC_M1UPD_TM_KAKUTEI] = sysDateVO.Systime_mili.ToString();	// 更新時間
				f01M1Form.Dictionary[Te090p01Constant.DIC_M1NYUKATAN_CD] = logininfo.TtsCd;							// 入荷担当者コード
				f01M1Form.Dictionary[Te090p01Constant.DIC_M1NYUKATAN_NM] = logininfo.TtsMei;						// 入荷担当者名


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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion
	}
}
