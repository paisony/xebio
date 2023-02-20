using com.xebio.bo.Te090p01.Constant;
using com.xebio.bo.Te090p01.Formvo;
using com.xebio.bo.Te090p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
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
  /// Te090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te090f01Facade : StandardBaseFacade
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

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Te090f01Form f01VO = (Te090f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				#endregion

				#region 業務チェック

				#region 選択チェック
				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				bool selFlg = false;
				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細行オブジェクト取得
					Te090f01M1Form m1Form = (Te090f01M1Form)m1List[i];

					if (m1Form.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
						&& !m1Form.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
					{
						// Ｍ１選択フラグＯＮ、確定フラグが1:確定以外の場合
						selFlg = true;
						break;
					}
				}

				if (!selFlg)
				{
					// 対象行を選択してください。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}

				// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック

				StringBuilder sRepSql = new StringBuilder();

				if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
				{
					// [選択モードNo]が「入荷確定」の場合

					// テーブルID
					string tableId = "MDNT0010";	// 移動入荷予定TBL(H)

					// 抽出条件
					sRepSql.Append(" AND TENPOLC_KBN = :BIND_TENPOLC_KBN");			// 店舗ＬＣ区分
					sRepSql.Append(" AND SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD");	// 出荷会社コード
					sRepSql.Append(" AND SYUKKATEN_CD = :BIND_SYUKKATEN_CD");		// 出荷店コード
					sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");		// 伝票番号

					for (int i = 0; i < m1List.Count; i++)
					{
						Te090f01M1Form f01m1VO = (Te090f01M1Form)m1List[i];

						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
							&& !f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
						{
							// Ｍ１選択フラグＯＮ、確定フラグが1:確定以外の場合

							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗ＬＣ区分
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPOLC_KBN";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 出荷会社コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYUKKAKAISYA_CD";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 出荷店コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYUKKATEN_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;
							bindList.Add(bindVO);

							// 伝票番号
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_DENPYO_BANGO";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaita(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_YOTEI]),	// Ｍ１更新日（予定）
								Convert.ToDecimal((string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_TM_YOTEI]),		// Ｍ１更新時間（予定）
								facadeContext,
								tableId,
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								m1List.DispRow
								);
						}
					}
				}
				else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KAKUTEIGODEL))
				{
					// [選択モードNo]が「確定後取消」の場合

					// テーブルID
					string tableId = "MDNT0010";	// 移動入荷予定TBL(H)

					// 抽出条件
					sRepSql.Append(" AND TENPOLC_KBN = :BIND_TENPOLC_KBN");			// 店舗ＬＣ区分
					sRepSql.Append(" AND SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD");	// 出荷会社コード
					sRepSql.Append(" AND SYUKKATEN_CD = :BIND_SYUKKATEN_CD");		// 出荷店コード
					sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");		// 伝票番号

					for (int i = 0; i < m1List.Count; i++)
					{
						Te090f01M1Form f01m1VO = (Te090f01M1Form)m1List[i];

						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
							&& !f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
						{
							// Ｍ１選択フラグＯＮ、確定フラグが1:確定以外の場合

							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗ＬＣ区分
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPOLC_KBN";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 出荷会社コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYUKKAKAISYA_CD";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 出荷店コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYUKKATEN_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;
							bindList.Add(bindVO);

							// 伝票番号
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_DENPYO_BANGO";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaita(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_YOTEI]),	// Ｍ１更新日（予定）
								Convert.ToDecimal((string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_TM_YOTEI]),		// Ｍ１更新時間（予定）
								facadeContext,
								tableId,
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								m1List.DispRow
								);
						}
					}

					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					// テーブルID
					tableId = "MDNT0020";	// 移動入荷確定TBL(H)

					// 抽出条件
					sRepSql.Length = 0;
					sRepSql.Append(" AND TENPOLC_KBN = :BIND_TENPOLC_KBN");			// 店舗ＬＣ区分
					sRepSql.Append(" AND SYUKKAKAISYA_CD = :BIND_SYUKKAKAISYA_CD");	// 出荷会社コード
					sRepSql.Append(" AND SYUKKATEN_CD = :BIND_SYUKKATEN_CD");		// 出荷店コード
					sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");		// 伝票番号
					sRepSql.Append(" AND SYUKKA_YMD = :BIND_SYUKKA_YMD");			// 出荷日

					for (int i = 0; i < m1List.Count; i++)
					{
						Te090f01M1Form f01m1VO = (Te090f01M1Form)m1List[i];

						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
							&& !f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
						{
							// Ｍ１選択フラグＯＮ、確定フラグが1:確定以外の場合

							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗ＬＣ区分
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPOLC_KBN";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 出荷会社コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYUKKAKAISYA_CD";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 出荷店コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYUKKATEN_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;
							bindList.Add(bindVO);

							// 伝票番号
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_DENPYO_BANGO";
							bindVO.Value = (string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 出荷日
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYUKKA_YMD";
							bindVO.Value = BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaita(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_YMD_KAKUTEI]),	// Ｍ１更新日（確定）
								Convert.ToDecimal((string)f01m1VO.Dictionary[Te090p01Constant.DIC_M1UPD_TM_KAKUTEI]),		// Ｍ１更新時間（確定）
								facadeContext,
								tableId,
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								m1List.DispRow
								);
						}
					}
				}

				// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 更新処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				for (int i = 0; i < m1List.Count; i++)
				{
					Te090f01M1Form f01m1VO = (Te090f01M1Form)m1List[i];
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
						&& !f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
					{
						// Ｍ１選択フラグＯＮ、確定フラグが1:確定以外の場合
						if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
						{
							#region 入荷確定
							// [移動入荷予定TBL(H)]を更新する。
							BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 START");
							int updCntH = Te090p01Util.Upd_NyukaYoteiH(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO, 0m);
							BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 END");

							// [移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録する。
							BoSystemLog.logOut("[移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録 START");
							int insCntH = Te090p01Util.Ins_NyukaKakuteiH(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録 END");

							// [移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録する。
							BoSystemLog.logOut("[移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録 START");
							int insCntB = Te090p01Util.Ins_NyukaKakuteiB(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録 END");

							// [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録する。
							BoSystemLog.logOut("[移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録 START");
							int insCntRH = Te090p01Util.Ins_NyukaRirekiH(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO, Te090p01Constant.AKAKURO_KURO);
							BoSystemLog.logOut("[移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録 END");

							// [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録する。
							BoSystemLog.logOut("[移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録 START");
							int insCntRB = Te090p01Util.Ins_NyukaRirekiB(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO, Te090p01Constant.AKAKURO_KURO);
							BoSystemLog.logOut("[移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録 END");

							if (f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN].Equals(Te090p01Constant.TENPO_LC_KBN_TENPO))
							{
								// 対象行のDictionary.[店舗LC区分]が0(店舗)の場合

								// [移動出荷確定TBL(H)]を更新する。
								BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 START");
								int updCntSyukkaH = Te090p01Util.Upd_SyukkaKakuteiH(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
								BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 END");

								// [移動出荷確定TBL(B)]を更新する。
								BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 START");
								int updCntSyukkkaB = Te090p01Util.Upd_SyukkaKakuteiB(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
								BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 END");
							}

							// [移動入荷予定未存在リストTBL]を更新する。
							BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を更新 START");
							int updCntL = Te090p01Util.Upd_MisonzaiList(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO, (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);
							BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を更新 END");
							#endregion
						}
						else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KAKUTEIGODEL))
						{
							#region 確定後取消
							// [移動入荷予定TBL(H)]を更新する。
							BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 START");
							int updCntH = Te090p01Util.Upd_NyukaYoteiH(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 END");

							// [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録する。
							BoSystemLog.logOut("[移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録 START");
							int insCntH = Te090p01Util.Ins_NyukaRirekiH(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO, Te090p01Constant.AKAKURO_AKA);
							BoSystemLog.logOut("[移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録 END");

							// [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録する。
							BoSystemLog.logOut("[移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録 START");
							int insCntB = Te090p01Util.Ins_NyukaRirekiB(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO, Te090p01Constant.AKAKURO_AKA);
							BoSystemLog.logOut("[移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録 END");

							// [移動入荷確定TBL(B)]を削除する。
							BoSystemLog.logOut("[移動入荷確定TBL(B)]を削除 START");
							int delCntB = Te090p01Util.Del_NyukaKakuteiB(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷確定TBL(B)]を削除 END");

							// [移動入荷確定TBL(H)]を削除する。
							BoSystemLog.logOut("[移動入荷確定TBL(H)]を削除 START");
							int delCntH = Te090p01Util.Del_NyukaKakuteiH(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷確定TBL(H)]を削除 END");

							if (f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN].Equals(Te090p01Constant.TENPO_LC_KBN_TENPO))
							{
								// 対象行のDictionary.[店舗LC区分]が0(店舗)の場合

								// [移動出荷差異リスト]を削除する。
								BoSystemLog.logOut("[移動出荷差異リスト]を削除 START");
								int delCntL = Te090p01Util.Del_SyukkaSaiL(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
								BoSystemLog.logOut("[移動出荷差異リスト]を削除 END");

								// [移動出荷確定TBL(H)]を更新する。
								BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 START");
								int updCntSyukkaH = Te090p01Util.Upd_SyukkaKakuteiH(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
								BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 END");

								// [移動出荷確定TBL(B)]を更新する。
								BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 START");
								int updCntSyukkaB = Te090p01Util.Upd_SyukkaKakuteiB(facadeContext, f01VO.Stkmodeno, f01m1VO, logininfo, sysDateVO);
								BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 END");
							}
							#endregion
						}
					}
				}
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

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
