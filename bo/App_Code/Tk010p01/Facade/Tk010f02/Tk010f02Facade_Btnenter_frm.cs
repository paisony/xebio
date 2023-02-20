using com.xebio.bo.Tk010p01.Constant;
using com.xebio.bo.Tk010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tk010p01.Facade
{
  /// <summary>
  /// Tk010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk010f02Facade : StandardBaseFacade
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
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

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
				Tk010f02Form f01VO = (Tk010f02Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧画面選択行のVO
				Tk010f01M1Form f01M1Form = (Tk010f01M1Form)f01VO.Dictionary[Tk010p01Constant.DIC_M1SELCETVO];

				// 一覧画面のVO取得
				Tk010f01Form prevVo = (Tk010f01Form)f01VO.Dictionary[Tk010p01Constant.DIC_F1VO];

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				#endregion

				#region 業務チェック

				#region 件数チェック

				// 入力状態
				// スキャンコードが1件も入力されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tk010f02M1Form f02m1VO = (Tk010f02M1Form)m1List[i];
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 明細 単項目チェック

				for (int i = 0; i < m1List.Count; i++)
				{
					Tk010f02M1Form f02m1VO = (Tk010f02M1Form)m1List[i];

					// スキャンコードが未入力の場合、エラー
					if (string.IsNullOrEmpty(f02m1VO.M1scan_cd))
					{
						ErrMsgCls.AddErrMsg("E121",
											"スキャンコード",
											facadeContext,
											new[] { "M1scan_cd" },
											f02m1VO.M1rowno,
											(i).ToString(),
											"M1");
					}

					// 却下時のチェック
					if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1kyakka_flg))
					{
						// Ｍ１却下理由区分
						// 却下にチェックがされていて、却下理由が入力された場合に、入力されていない場合、エラー
						if (BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f02m1VO.M1kyakkariyu_kb))
						{
							ErrMsgCls.AddErrMsg("E119",
												"却下理由",
												facadeContext,
												new[] { "M1kyakkariyu_kb" },
												f02m1VO.M1rowno,
												(i).ToString(),
												"M1");
						}
						else
						{
							// 却下にチェックがされていて、却下理由区分で[その他]選択時、入力されていない場合、エラー
							if (string.IsNullOrEmpty(f02m1VO.M1kyakkariyu)
								&& ConditionHyokason_kyakkariyu.VALUE_HYOKASON_KYAKKARIYU5.Equals(f02m1VO.M1kyakkariyu_kb))
							{
								ErrMsgCls.AddErrMsg("E118",
													"その他選択時、却下理由",
													facadeContext,
													new[] { "M1kyakkariyu" },
													f02m1VO.M1rowno,
													(i).ToString(),
													"M1");
							}
						}
					}

					// Ｍ１数量
					// 未入力、0はエラー
					if (string.IsNullOrEmpty(f02m1VO.M1suryo))
					{
						ErrMsgCls.AddErrMsg("E121",
											"数量",
											facadeContext,
											new[] { "M1suryo" },
											f02m1VO.M1rowno,
											(i).ToString(),
											"M1");
					}

					if (("0").Equals(f02m1VO.M1suryo))
					{
						ErrMsgCls.AddErrMsg("E103",
											"数量",
											facadeContext,
											new[] { "M1suryo" },
											f02m1VO.M1rowno,
											(i).ToString(),
											"M1");
					}

				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 明細 マスタ存在チェック

				for (int i = 0; i < m1List.Count; i++)
				{
					Tk010f02M1Form f02m1VO = (Tk010f02M1Form)m1List[i];

					// Ｍ１スキャンコード
					// 発注MSTに存在しない場合、エラー
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f02m1VO.M1scan_cd,		// スキャンコード
						f01VO.Tenpo_cd,			// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						2,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						string.Empty,			// 指示NO（移動出荷マニュアル、返品マニュアル用）
						string.Empty,			// 出荷会社コード（移動出荷マニュアル)
						string.Empty,			// 入荷会社コード（移動出荷マニュアル)
						string.Empty			// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);

					Hashtable syohinData = V01004Check.CheckScanCd(
							searchConditionVO,
							facadeContext,
							"スキャンコード",
							new[] { "M1scan_cd" },
							f02m1VO.M1rowno,
							i.ToString(),
							"M1",
							Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper()))
					);

					// JANが存在した場合、商品情報を再取得する
					if (syohinData != null)
					{
						f02m1VO.M1bumon_cd = syohinData["BUMON_CD"].ToString();													// Ｍ１部門コード
						f02m1VO.M1hinsyu_cd = syohinData["HINSYU_CD"].ToString();												// Ｍ１品種コード
						f02m1VO.M1burando_nm = syohinData["BURANDO_NMK"].ToString();											// Ｍ１ブランド名
						f02m1VO.M1jisya_hbn = syohinData["XEBIO_CD"].ToString();												// Ｍ１自社品番
						f02m1VO.M1hanbaikanryo_ymd = syohinData["HANBAIKANRYO_YMD"].ToString();									// Ｍ１販売完了日
						f02m1VO.M1maker_hbn = syohinData["HIN_NBR"].ToString();													// Ｍ１メーカー品番
						f02m1VO.M1syonmk = syohinData["SYONMK"].ToString();														// Ｍ１商品名(カナ)
						f02m1VO.M1scan_cd = syohinData["JAN_CD"].ToString();													// Ｍ１スキャンコード
						f02m1VO.M1iro_nm = syohinData["IRO_NM"].ToString();														// Ｍ１色
						f02m1VO.M1size_nm = syohinData["SIZE_NM"].ToString();													// Ｍ１サイズ
						f02m1VO.M1genbaika_tnk = syohinData["SLPR"].ToString();													// Ｍ１現売価
						f02m1VO.M1gen_tnk = syohinData["HYOKA_TNK"].ToString();													// Ｍ１原単価
						f02m1VO.M1bumon_nm = syohinData["BUMONKANA_NM"].ToString();												// Ｍ１部門名カナ
						f02m1VO.M1hinsyu_ryaku_nm = syohinData["HINSYU_RYAKU_NM"].ToString();									// Ｍ１品種略称名

						// Ｍ１原価金額 ([Ｍ１原単価]×[M１数量])
						f02m1VO.M1genkakin = (Convert.ToDecimal(f02m1VO.M1gen_tnk) * Convert.ToDecimal(f02m1VO.M1suryo)).ToString();

						// Dictionary（更新用）
						f02m1VO.Dictionary[Tk010p01Constant.DIC_M1BURANDO_CD] = syohinData["BURANDO_CD"].ToString();			// ブランドコード
						f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SIZE_CD] = syohinData["SIZE_CD"].ToString();					// サイズコード
						f02m1VO.Dictionary[Tk010p01Constant.DIC_M1IRO_CD] = syohinData["MAKERCOLOR_CD"].ToString();				// 色コード
						f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYOHIN_CD] = syohinData["SYOHIN_CD"].ToString();				// 商品コード
						f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB] = syohinData["TYOTATSU_KB"].ToString();			// 調達区分

					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 排他チェック
				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				// 確定モードの場合
				if (BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Stkmodeno))
				{
					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
					sRepSql.Append(" AND APPLY_YMD = :BIND_APPLY_YMD");
					sRepSql.Append(" AND KESSAI_FLG = 0");
					sRepSql.Append(" AND SHINSEI_FLG = 1");
					sRepSql.Append(" AND SAISHINSEI_FLG = :BIND_SAISHINSEI_FLG");

					// 店舗コード
					bindList.Add(new BindInfoVO("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01M1Form.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString()), BoSystemSql.BINDTYPE_STRING));
					// 申請日
					bindList.Add(new BindInfoVO("BIND_APPLY_YMD", BoSystemFormat.formatDate(BoSystemString.Nvl(f01M1Form.M1apply_ymd, "0")), BoSystemSql.BINDTYPE_NUMBER));
					// 再申請フラグ
					bindList.Add(new BindInfoVO("BIND_SAISHINSEI_FLG", f01M1Form.Dictionary[Tk010p01Constant.DIC_M1SAISHINSEI_FLG].ToString(), BoSystemSql.BINDTYPE_NUMBER));


					// 評価損種別区分 設定されている場合のみ参照する
					if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Hyokasonsyubetsu_kb)].ToString()))
					{
						sRepSql.Append(" AND HYOKASONSYUBETSU_KB = :BIND_HYOKASONSYUBETSU_KB");
						bindList.Add(new BindInfoVO("BIND_HYOKASONSYUBETSU_KB", prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Hyokasonsyubetsu_kb)].ToString(), BoSystemSql.BINDTYPE_NUMBER));
					}

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal(f01M1Form.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD].ToString()),
							Convert.ToDecimal(f01M1Form.Dictionary[Tk010p01Constant.DIC_M1UPD_TM].ToString()),
							facadeContext,
							"MDIT0060",
							sRepSql.ToString(),
							bindList,
							1
					);
				}
				// 修正モードの場合
				else if (BoSystemConstant.MODE_UPD.Equals(f01VO.Stkmodeno))
				{
					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
					sRepSql.Append(" AND SYONIN_FLG = :BIND_SYONIN_FLG");
					sRepSql.Append(" AND APPLY_YMD = :BIND_APPLY_YMD");
					sRepSql.Append(" AND EXISTS ");
					sRepSql.Append(" ( ");
					sRepSql.Append(" SELECT '1' FROM MDIT0060 A1 ");
					sRepSql.Append(" WHERE TENPO_CD = A1.TENPO_CD ");
					sRepSql.Append(" AND   KANRI_NO = A1.KANRI_NO ");
					sRepSql.Append(" AND   SYORI_YMD = A1.SYORI_YMD ");
					sRepSql.Append(" AND   GYO_NBR = A1.GYO_NBR ");
					sRepSql.Append(" AND   A1.SAISHINSEI_FLG = :BIND_SAISHINSEI_FLG ");
					sRepSql.Append(" ) ");

					// 店舗コード
					bindList.Add(new BindInfoVO("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01M1Form.Dictionary[Tk010p01Constant.DIC_M1TENPO_CD].ToString()), BoSystemSql.BINDTYPE_STRING));
					// 承認フラグ
					bindList.Add(new BindInfoVO("BIND_SYONIN_FLG", f01M1Form.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG].ToString(), BoSystemSql.BINDTYPE_NUMBER));
					// 申請日
					bindList.Add(new BindInfoVO("BIND_APPLY_YMD", BoSystemFormat.formatDate(BoSystemString.Nvl(f01M1Form.M1apply_ymd, "0")), BoSystemSql.BINDTYPE_NUMBER));
					// 再申請フラグ
					bindList.Add(new BindInfoVO("BIND_SAISHINSEI_FLG", f01M1Form.Dictionary[Tk010p01Constant.DIC_M1SAISHINSEI_FLG].ToString(), BoSystemSql.BINDTYPE_NUMBER));

					// 評価損種別区分 設定されている場合のみ参照する
					if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Hyokasonsyubetsu_kb)].ToString()))
					{
						sRepSql.Append(" AND HYOKASONSYUBETSU_KB = :BIND_HYOKASONSYUBETSU_KB");
						bindList.Add(new BindInfoVO("BIND_HYOKASONSYUBETSU_KB", prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Hyokasonsyubetsu_kb)].ToString(), BoSystemSql.BINDTYPE_NUMBER));
					}

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal(f01M1Form.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD].ToString()),
							Convert.ToDecimal(f01M1Form.Dictionary[Tk010p01Constant.DIC_M1UPD_TM].ToString()),
							facadeContext,
							"MDIT0070",
							sRepSql.ToString(),
							bindList,
							1
					);

				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 更新処理

				// 確定モードの場合
				if (BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Stkmodeno))
				{
					for (int i = 0; i < m1List.Count; i++)
					{
						Tk010f02M1Form f02m1VO = (Tk010f02M1Form)m1List[i];

						// [Ｍ１承認状態]、[M1却下フラグ]のいずれかが"1"で、M1確定処理フラグ(隠し)が"1"の場合
						if ((BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1syonin_flg) || (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1kyakka_flg)))
							&& ConditionKakuteisyori_flg.VALUE_ARI.Equals(f02m1VO.M1entersyoriflg))
						{
							// [評価損申請TBL]を更新する。
							BoSystemLog.logOut("[評価損申請TBL]を更新する。 START");
							int updSinseiCnt = upd_sinsei(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損申請TBL]を更新する。 END");

							// [評価損確定TBL]を登録する。
							BoSystemLog.logOut("[評価損確定TBL]を登録する。 START");
							int inskakuteiCnt = ins_kakutei(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損確定TBL]を登録する。 END");

							// 明細行を確定状態とする
							f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI] = Tk010p01Constant.UPD_JOTAI_KAKUTEI;

						}
						// [Ｍ１承認状態]、[M1却下フラグ]が未選択で、M1確定処理フラグ(隠し)が"1"の場合（保留状態）
						else if ((BoSystemConstant.CHECKBOX_OFF.Equals(f02m1VO.M1syonin_flg) && (BoSystemConstant.CHECKBOX_OFF.Equals(f02m1VO.M1kyakka_flg)))
								&& ConditionKakuteisyori_flg.VALUE_ARI.Equals(f02m1VO.M1entersyoriflg))
						{
							// [評価損申請履歴TBL]（赤伝）を登録する。
							BoSystemLog.logOut("[評価損申請履歴TBL]（赤伝）を登録する。 START");
							int rireki_aka = ins_rireki_aka(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損申請履歴TBL]（赤伝）を登録する。 END");

							// [評価損申請TBL]を更新する(保留)。
							BoSystemLog.logOut("[評価損申請TBL]を更新する(保留)。 START");
							int updSinseihoryuCnt = upd_sinsei_horyu(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損申請TBL]を更新する(保留)。 END");

							// [評価損申請履歴TBL]（黒伝）を登録する。
							BoSystemLog.logOut("[評価損申請履歴TBL]（黒伝）を登録する。 START");
							int rireki_kuro = ins_rireki_kuro(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損申請履歴TBL]（黒伝）を登録する。 END");

							// 明細行を保留状態とする
							f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI] = Tk010p01Constant.UPD_JOTAI_HORYU;
						}
						else
						{
							// 評価損申請TBLの更新日付を最新化する
							int upd_dateCnt = upd_sinseiDate(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);

							// 明細行の確定状態をnullにする
							f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI] = string.Empty;
						}
					}
				}
				// 修正モードの場合
				else if (BoSystemConstant.MODE_UPD.Equals(f01VO.Stkmodeno))
				{
					for (int i = 0; i < m1List.Count; i++)
					{
						Tk010f02M1Form f02m1VO = (Tk010f02M1Form)m1List[i];

						// [Ｍ１承認状態]、[M1却下フラグ]のいずれかが"1"で、M1確定処理フラグ(隠し)が"1"の場合
						if ((BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1syonin_flg) || (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1kyakka_flg)))
							&& ConditionKakuteisyori_flg.VALUE_ARI.Equals(f02m1VO.M1entersyoriflg))
						{
							// [評価損確定TBL]を更新する。
							BoSystemLog.logOut("[評価損確定TBL]を更新する。 START");
							int updkakuteiCnt = upd_kakutei(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損確定TBL]を更新する。 END");

							// 明細行を確定状態とする
							f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI] = Tk010p01Constant.UPD_JOTAI_KAKUTEI;
						}
						// [Ｍ１承認状態]、[M1却下フラグ]が未選択で、M1確定処理フラグ(隠し)が"1"の場合（保留状態）
						else if ((BoSystemConstant.CHECKBOX_OFF.Equals(f02m1VO.M1syonin_flg) && (BoSystemConstant.CHECKBOX_OFF.Equals(f02m1VO.M1kyakka_flg)))
								&& ConditionKakuteisyori_flg.VALUE_ARI.Equals(f02m1VO.M1entersyoriflg))
						{
							// [評価損申請履歴TBL]（赤伝）を登録する。
							BoSystemLog.logOut("[評価損申請履歴TBL]（赤伝）を登録する。 START");
							int rireki_aka = ins_rireki_aka(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損申請履歴TBL]（赤伝）を登録する。 END");

							// [評価損申請TBL]を更新する(保留)。
							BoSystemLog.logOut("[評価損申請TBL]を更新する(保留)。 START");
							int updSinseihoryuCnt = upd_sinsei_horyu_syusei(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損申請TBL]を更新する(保留)。 END");

							// [評価損申請履歴TBL]（黒伝）を登録する。
							BoSystemLog.logOut("[評価損申請履歴TBL]（黒伝）を登録する。 START");
							int rireki_kuro = ins_rireki_kuro(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損申請履歴TBL]（黒伝）を登録する。 END");

							// [評価損確定TBL]を削除する。
							BoSystemLog.logOut("[評価損確定TBL]を削除する。 START");
							int delCnt = del_kakutei(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[評価損確定TBL]を削除する。 END");

							// 明細行を保留状態とする
							f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI] = Tk010p01Constant.UPD_JOTAI_HORYU;
						}
						else
						{
							// 評価損確定TBLの更新日付を最新化する
							int upd_dateCnt = upd_kakuteiDate(facadeContext, f01VO, f02m1VO, logininfo, sysDateVO);

							// 明細行の確定状態をnullにする
							f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI] = string.Empty;
						}
					}
				}	

				#endregion

				#region 画面表示

				// 明細リンク制御フラグ
				string meisaiLinkFlg = Tk010p01Constant.MEISAI_LINK_FUKA_FLG;

				// 日付更新フラグ
				bool ymdUpdFlg = false;

				// 未決済フラグ（修正モードのみ使用）
				bool mikessaiFlg = true;

				// 決済済みフラグ（確定モードのみ使用）
				bool kessaizumiFlg = true;

				// 更新結果をもとに一覧画面を編集する
				#region 確定モード
				if (BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Stkmodeno))
				{
					for (int i = 0; i < m1List.Count; i++)
					{
						Tk010f02M1Form f02m1VO = (Tk010f02M1Form)m1List[i];

						// 一覧の更新日付、時間を最新化する
						ymdUpdFlg = true;

						// 処理しなかった行は飛ばす
						if (string.IsNullOrEmpty(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI].ToString()))
						{
							// 一覧の明細リンクは使用可能
							meisaiLinkFlg = Tk010p01Constant.MEISAI_LINK_KANO_FLG;

							// 処理しなかった行が存在した場合、決済済みにはしない
							kessaizumiFlg = false;

							continue;
						}

						// 調達区分を元にNBか否かを調査
						int nbFlg = Convert.ToInt32(BoSystemString.RightB(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString(), 1));
						// 編集前の調達区分取得
						int motonbFlg = Convert.ToInt32(BoSystemString.RightB(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB_MOTO].ToString(), 1));

						// 確定行の場合、数量、原価金額を一覧の明細行から減算する
						if (Tk010p01Constant.UPD_JOTAI_KAKUTEI.Equals(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI].ToString()))
						{
							if (1 <= motonbFlg && motonbFlg <= 4)
							{
								// NB数量
								f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo) - (Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString()))).ToString();
								// NB原価金額
								f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) - (Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString()))).ToString();
							}
							else
							{
								// NB以外数量
								f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo) - (Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString()))).ToString();
								// NB以外原価金額
								f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin) - (Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString()))).ToString();
							}
						}
						// 保留行の場合、対象行の更新前と更新後の差分を設定する
						else if (Tk010p01Constant.UPD_JOTAI_HORYU.Equals(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI].ToString()))
						{
							// 一覧の明細リンクは使用可能とする
							meisaiLinkFlg = Tk010p01Constant.MEISAI_LINK_KANO_FLG;

							// 保留行が存在した場合、決済済みにはしない
							kessaizumiFlg = false;

							// 数量差分
							decimal sabunSuryo = 0;
							// 原価金額差分
							decimal sabunGenka = 0;
							if (1 <= nbFlg && nbFlg <= 4)
							{
								// 元の調達区分と比べて変更されていない場合、差分計算する 
								if (f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB_MOTO].ToString().Equals(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString()))
								{
									// 数量差分
									sabunSuryo = Convert.ToDecimal(f02m1VO.M1suryo) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString());
									// 原価金額差分
									sabunGenka += Convert.ToDecimal(f02m1VO.M1genkakin) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString());
									// Ｍ1数量
									f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo) + sabunSuryo).ToString();
									// Ｍ1原価金額
									f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) + sabunGenka).ToString();
								}
								// 元の調達区分と比べて変更されていた場合、移動する 
								else
								{
									// ------------------
									// NB以外⇒NBに移動
									// ------------------
									// NB以外の数量から元数量を引く
									f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo)
																- Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString())).ToString();
									// NB以外の原価金額から元原価金額を引く
									f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin)
																- Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString())).ToString();

									// NB数量に入力された数量を加算する
									f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo) + Convert.ToDecimal(f02m1VO.M1suryo)).ToString();

									// NB原価金額に入力された原価金額を加算する
									f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) + Convert.ToDecimal(f02m1VO.M1genkakin)).ToString();
								}

							}
							else
							{
								// 元の調達区分と比べて変更されていない場合、差分計算する 
								if (f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB_MOTO].ToString().Equals(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString()))
								{
									// 数量差分
									sabunSuryo = Convert.ToDecimal(f02m1VO.M1suryo) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString());
									// 原価金額差分
									sabunGenka += Convert.ToDecimal(f02m1VO.M1genkakin) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString());
									// Ｍ1数量
									f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo) + sabunSuryo).ToString();
									// Ｍ1原価金額
									f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin) + sabunGenka).ToString();
								}
								// 元の調達区分と比べて変更されていた場合、移動する 
								else
								{
									// ------------------
									// NB⇒NB以外に移動
									// ------------------
									// NBの数量から元数量を引く
									f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo)
																- Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString())).ToString();
									// NBの原価金額から元原価金額を引く
									f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin)
																- Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString())).ToString();

									// NB以外数量に入力された数量を加算する
									f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo) + Convert.ToDecimal(f02m1VO.M1suryo)).ToString();

									// NB以外原価金額に入力された原価金額を加算する
									f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin) + Convert.ToDecimal(f02m1VO.M1genkakin)).ToString();
								}

							}
						}
					}

				}
				#endregion

				#region  修正モード

				else if (BoSystemConstant.MODE_UPD.Equals(f01VO.Stkmodeno))
				{
					for (int i = 0; i < m1List.Count; i++)
					{
						Tk010f02M1Form f02m1VO = (Tk010f02M1Form)m1List[i];

						// 一覧選択行編集
						updMeisaiEdit(f01M1Form, f02m1VO, true);
						// 選択行に対する承認状態の行編集
						updMeisaiEdit((Tk010f01M1Form)f01VO.Dictionary[Tk010p01Constant.DIC_M1SELCETVO2], f02m1VO, false);

						// 一覧の承認状態と一致する承認状態がi件でもある場合、明細リンクを使用可能にする
						if (f01M1Form.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG].ToString().Equals(getSyoninFlg(f02m1VO)))
						{
							meisaiLinkFlg = Tk010p01Constant.MEISAI_LINK_KANO_FLG;
						}

						// 一覧の排他用更新日更新フラグ
						ymdUpdFlg = true;

						// 保留行以外の行が残っていた場合、未決済フラグをfalseにする
						if (!Tk010p01Constant.UPD_JOTAI_HORYU.Equals(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI].ToString()))
						{
							mikessaiFlg = false;
						}
					}
				}
				#endregion

				// 選択行 確定処理フラグ
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;
				// 選択行 Ｍ１店舗合計数量
				f01M1Form.M1tenpogokei_su = (Convert.ToDecimal(f01M1Form.M1nb_suryo) + Convert.ToDecimal(f01M1Form.M1notnb_suryo)).ToString();
				// 選択行 Ｍ１店舗合計原価金額
				f01M1Form.M1tenpogokei_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) + Convert.ToDecimal(f01M1Form.M1notnb_genka_kin)).ToString();
				// 選択行 明細リンク使用可能フラグ
				f01M1Form.Dictionary[Tk010p01Constant.DIC_M1LINKFLG] = meisaiLinkFlg;

				// 修正モードかつすべて保留行の場合、決済状態を変更する
				if (BoSystemConstant.MODE_UPD.Equals(f01VO.Stkmodeno)
					&& mikessaiFlg)
				{
					f01M1Form.Dictionary[Tk010p01Constant.DIC_M1KESSAI_FLG] = ConditionKessai_jotai.VALUE_KESSAI_JOTAI1;
					f01M1Form.M1kessai_flg_nm = ConditionUtil.GetLabel(ConditionKessai_jotai.ID, ConditionKessai_jotai.VALUE_KESSAI_JOTAI1);
					// 行は未選択状態
					f01M1Form.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;

				}
				// 確定モードかつ全て決済された場合、決済済みにする
				if (BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Stkmodeno)
					&& kessaizumiFlg)
				{
					f01M1Form.Dictionary[Tk010p01Constant.DIC_M1KESSAI_FLG] = ConditionKessai_jotai.VALUE_KESSAI_JOTAI2;
					f01M1Form.M1kessai_flg_nm = ConditionUtil.GetLabel(ConditionKessai_jotai.ID, ConditionKessai_jotai.VALUE_KESSAI_JOTAI2);
					// 行は未選択状態
					f01M1Form.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
				}
				if (ymdUpdFlg)
				{
					// 選択行 更新日
					f01M1Form.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD] = sysDateVO.Sysdate.ToString();
					// 選択行 更新時間
					f01M1Form.Dictionary[Tk010p01Constant.DIC_M1UPD_TM] = sysDateVO.Systime_mili.ToString();
				}

				// 対となる行がある場合、編集する
				if (f01VO.Dictionary[Tk010p01Constant.DIC_M1SELCETVO2] != null)
				{
					Tk010f01M1Form f01m1VOSub = (Tk010f01M1Form)f01VO.Dictionary[Tk010p01Constant.DIC_M1SELCETVO2];
					// Ｍ１店舗合計数量
					f01m1VOSub.M1tenpogokei_su = (Convert.ToDecimal(f01m1VOSub.M1nb_suryo) + Convert.ToDecimal(f01m1VOSub.M1notnb_suryo)).ToString();
					// Ｍ１店舗合計原価金額
					f01m1VOSub.M1tenpogokei_genka_kin = (Convert.ToDecimal(f01m1VOSub.M1nb_genka_kin) + Convert.ToDecimal(f01m1VOSub.M1notnb_genka_kin)).ToString();

					// 更新日最新化フラグが1の場合最新可
					if ((f01m1VOSub.Dictionary[Tk010p01Constant.MEISAI_DATE_UPD_FLG] != null) && ("1").Equals(f01m1VOSub.Dictionary[Tk010p01Constant.MEISAI_DATE_UPD_FLG].ToString()))
					{
						// 選択行 更新日
						f01m1VOSub.Dictionary[Tk010p01Constant.DIC_M1UPD_YMD] = sysDateVO.Sysdate.ToString();
						// 選択行 更新時間
						f01m1VOSub.Dictionary[Tk010p01Constant.DIC_M1UPD_TM] = sysDateVO.Systime_mili.ToString();
						// Dictionari初期化
						f01m1VOSub.Dictionary[Tk010p01Constant.MEISAI_DATE_UPD_FLG] = string.Empty;
					}
				}

				// 一覧の明細情報編集
				IDataList form1m1List = prevVo.GetList("M1");

				Decimal dGokei_suryo = 0;
				Decimal dGenka_kin_gokei = 0;

				for (int i = 0; i < form1m1List.Count; i++)
				{
					Tk010f01M1Form f01m1VO = (Tk010f01M1Form)form1m1List[i];
					dGokei_suryo += Convert.ToDecimal(f01m1VO.M1tenpogokei_su);
					dGenka_kin_gokei += Convert.ToDecimal(f01m1VO.M1tenpogokei_genka_kin);
				}

				// 合計数量
				prevVo.Gokei_suryo = dGokei_suryo.ToString();
				// 合計原価金額
				prevVo.Genka_kin_gokei= dGenka_kin_gokei.ToString();

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
				// RollbackTransaction(facadeContext);

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

		#region ユーザー定義関数

		#region 更新処理 [評価損申請TBL]を更新

		/// <summary>
		/// 更新処理 [評価損申請TBL]を更新
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int upd_sinsei(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損確定TBL]を登録

		/// <summary>
		/// 更新処理 [評価損確定TBL]を登録
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int ins_kakutei(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// 一覧の対象行
			Tk010f01M1Form f01M1Form = (Tk010f01M1Form)f02VO.Dictionary[Tk010p01Constant.DIC_M1SELCETVO];

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 処理時間
			reader.BindValue(Tk010p01Constant.BIND_SYORI_TM, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_TM].ToString()));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));
			// 部門コード
			reader.BindValue(Tk010p01Constant.BIND_BUMON_CD, BoSystemFormat.formatBumonCd(f02m1VO.M1bumon_cd.ToString()));
			// 品種コード
			reader.BindValue(Tk010p01Constant.BIND_HINSYU_CD, Convert.ToDecimal(f02m1VO.M1hinsyu_cd));
			// ブランドコード
			reader.BindValue(Tk010p01Constant.BIND_BURANDO_CD, BoSystemFormat.formatBrandCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1BURANDO_CD].ToString()));
			// メーカー品番
			reader.BindValue(Tk010p01Constant.BIND_MAKER_HBN, f02m1VO.M1maker_hbn);
			// 商品名(カナ)
			reader.BindValue(Tk010p01Constant.BIND_SYONMK, f02m1VO.M1syonmk);
			// 自社品番
			reader.BindValue(Tk010p01Constant.BIND_JISYA_HBN, BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// ＪＡＮコード
			reader.BindValue(Tk010p01Constant.BIND_JAN_CD, BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd));
			// 商品コード
			reader.BindValue(Tk010p01Constant.BIND_SYOHIN_CD, f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYOHIN_CD].ToString());
			// 評価損数量
			reader.BindValue(Tk010p01Constant.BIND_HYOKASON_SU, Convert.ToDecimal(f02m1VO.M1suryo));
			// 販売完了日
			reader.BindValue(Tk010p01Constant.BIND_HANBAIKANRYO_YMD, Convert.ToDecimal(f02m1VO.M1hanbaikanryo_ymd));
			// 色コード
			reader.BindValue(Tk010p01Constant.BIND_IRO_CD, BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1IRO_CD].ToString()));
			// サイズコード
			reader.BindValue(Tk010p01Constant.BIND_SIZE_CD, BoSystemFormat.formatSizeCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SIZE_CD].ToString()));
			// サイズ名
			reader.BindValue(Tk010p01Constant.BIND_SIZE_NM, f02m1VO.M1size_nm);
			// 原単価
			reader.BindValue(Tk010p01Constant.BIND_GEN_TNK, Convert.ToDecimal(f02m1VO.M1gen_tnk));
			// 上代1
			reader.BindValue(Tk010p01Constant.BIND_JODAI1_TNK, Convert.ToDecimal(f02m1VO.M1genbaika_tnk));
			// 評価損種別区分
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONSYUBETSU_KB, Convert.ToDecimal(f02m1VO.M1hyokasonsyubetsu_kb));
			// 評価損理由区分
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONRIYU_KB, Convert.ToDecimal(getHyokasonriyu_kb(f02m1VO)));
			// 評価損理由
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONRIYU, f02m1VO.M1hyokasonriyu);
			// 却下理由区分
			decimal dkyakkaRiyu = 0;
			if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1kyakka_flg))
			{
				dkyakkaRiyu = Convert.ToDecimal(f02m1VO.M1kyakkariyu_kb);
			}
			reader.BindValue(Tk010p01Constant.BIND_KYAKKARIYU_KB, dkyakkaRiyu);
			// 却下理由
			String skyakkariyu = string.Empty;
			if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1kyakka_flg))
			{
				skyakkariyu = f02m1VO.M1kyakkariyu;
			}
			// 却下理由
			reader.BindValue(Tk010p01Constant.BIND_KYAKKARIYU, skyakkariyu);
			// 承認状態
			reader.BindValue(Tk010p01Constant.BIND_SYONIN_FLG, Convert.ToDecimal(getSyoninFlg(f02m1VO)));
			// 申請日
			reader.BindValue(Tk010p01Constant.BIND_APPLY_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01M1Form.M1apply_ymd, "0"))));
			// 調達区分
			reader.BindValue(Tk010p01Constant.BIND_TYOTATSU_KB, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString()));
			// 登録日
			reader.BindValue(Tk010p01Constant.BIND_ADD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 登録時間
			reader.BindValue(Tk010p01Constant.BIND_ADD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 登録担当者コード
			reader.BindValue(Tk010p01Constant.BIND_ADD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 更新担当者コード
			reader.BindValue(Tk010p01Constant.BIND_UPD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue(Tk010p01Constant.BIND_DEL_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 送信依頼フラグ
			decimal dsosiniraiFlg = 0;
			if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1syonin_flg))
			{
				dsosiniraiFlg = 1;
			}
			reader.BindValue(Tk010p01Constant.BIND_SOSINIRAI_FLG, dsosiniraiFlg);
			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損申請履歴TBL]（赤伝）を登録する。

		/// <summary>
		/// 更新処理 [評価損申請履歴TBL]（赤伝）を登録する。
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int ins_rireki_aka(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 赤黒区分 
			reader.BindValue(Tk010p01Constant.BIND_AKAKURO_KBN, Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_AKA));
			// 履歴処理日付 
			reader.BindValue(Tk010p01Constant.BIND_RIREKI_SYORI_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 履歴処理時間
			reader.BindValue(Tk010p01Constant.BIND_RIREKI_SYORI_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 処理種別
			reader.BindValue(Tk010p01Constant.BIND_SYORI_SB, BoSystemConstant.AKAKURO_KBN_AKA);
			// 履歴画面表示区分
			reader.BindValue(Tk010p01Constant.BIND_RIREKI_DISP_KB, Convert.ToDecimal(BoSystemConstant.RIREKI_DISP_KB_HIHYOJI));
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 更新担当者コード
			reader.BindValue(Tk010p01Constant.BIND_UPD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue(Tk010p01Constant.BIND_DEL_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));
			// 履歴No種別
			reader.BindValue(Tk010p01Constant.BIND_RIREKI_SB, 1);
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD + "_SUB", BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO + "_SUB", Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD + "_SUB", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR + "_SUB", Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD + "_2SUB", BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO + "_2SUB", Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD + "_2SUB", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR + "_2SUB", Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損申請TBL]を更新(保留)

		/// <summary>
		/// 更新処理 [評価損申請TBL]を更新(保留)
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int upd_sinsei_horyu(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// 一覧の対象行
			Tk010f01M1Form f01M1Form = (Tk010f01M1Form)f02VO.Dictionary[Tk010p01Constant.DIC_M1SELCETVO];
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 部門コード
			reader.BindValue(Tk010p01Constant.BIND_BUMON_CD, BoSystemFormat.formatBumonCd(f02m1VO.M1bumon_cd.ToString()));
			// 品種コード
			reader.BindValue(Tk010p01Constant.BIND_HINSYU_CD, Convert.ToDecimal(f02m1VO.M1hinsyu_cd));
			// ブランドコード
			reader.BindValue(Tk010p01Constant.BIND_BURANDO_CD, BoSystemFormat.formatBrandCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1BURANDO_CD].ToString()));
			// メーカー品番
			reader.BindValue(Tk010p01Constant.BIND_MAKER_HBN, f02m1VO.M1maker_hbn);
			// 商品名(カナ)
			reader.BindValue(Tk010p01Constant.BIND_SYONMK, f02m1VO.M1syonmk);
			// 自社品番
			reader.BindValue(Tk010p01Constant.BIND_JISYA_HBN, BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// ＪＡＮコード
			reader.BindValue(Tk010p01Constant.BIND_JAN_CD, BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd));
			// 商品コード
			reader.BindValue(Tk010p01Constant.BIND_SYOHIN_CD, f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYOHIN_CD].ToString());
			// 評価損数量
			reader.BindValue(Tk010p01Constant.BIND_HYOKASON_SU, Convert.ToDecimal(f02m1VO.M1suryo));
			// 販売完了日
			reader.BindValue(Tk010p01Constant.BIND_HANBAIKANRYO_YMD, Convert.ToDecimal(f02m1VO.M1hanbaikanryo_ymd));
			// 色コード
			reader.BindValue(Tk010p01Constant.BIND_IRO_CD, BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1IRO_CD].ToString()));
			// サイズコード
			reader.BindValue(Tk010p01Constant.BIND_SIZE_CD, BoSystemFormat.formatSizeCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SIZE_CD].ToString()));
			// サイズ名
			reader.BindValue(Tk010p01Constant.BIND_SIZE_NM, f02m1VO.M1size_nm);
			// 原単価
			reader.BindValue(Tk010p01Constant.BIND_GEN_TNK, Convert.ToDecimal(f02m1VO.M1gen_tnk));
			// 上代1
			reader.BindValue(Tk010p01Constant.BIND_JODAI1_TNK, Convert.ToDecimal(f02m1VO.M1genbaika_tnk));
			// 評価損種別区分
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONSYUBETSU_KB, Convert.ToDecimal(f02m1VO.M1hyokasonsyubetsu_kb));
			// 評価損理由区分
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONRIYU_KB, Convert.ToDecimal(getHyokasonriyu_kb(f02m1VO)));
			// 評価損理由
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONRIYU, f02m1VO.M1hyokasonriyu);
			// 申請日
			reader.BindValue(Tk010p01Constant.BIND_APPLY_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01M1Form.M1apply_ymd, "0"))));
			// 調達区分
			reader.BindValue(Tk010p01Constant.BIND_TYOTATSU_KB, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString()));
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 更新担当者コード
			reader.BindValue(Tk010p01Constant.BIND_UPD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue(Tk010p01Constant.BIND_DEL_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損申請履歴TBL]（黒伝）を登録する。

		/// <summary>
		/// 更新処理 [評価損申請履歴TBL]（赤伝）を登録する。
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int ins_rireki_kuro(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 赤黒区分 
			reader.BindValue(Tk010p01Constant.BIND_AKAKURO_KBN, Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_KURO));
			// 履歴処理日付 
			reader.BindValue(Tk010p01Constant.BIND_RIREKI_SYORI_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 履歴処理時間
			reader.BindValue(Tk010p01Constant.BIND_RIREKI_SYORI_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 処理種別
			reader.BindValue(Tk010p01Constant.BIND_SYORI_SB, BoSystemConstant.AKAKURO_KBN_KURO);
			// 履歴画面表示区分
			reader.BindValue(Tk010p01Constant.BIND_RIREKI_DISP_KB, Convert.ToDecimal(BoSystemConstant.RIREKI_DISP_KB_HYOJI));
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 更新担当者コード
			reader.BindValue(Tk010p01Constant.BIND_UPD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue(Tk010p01Constant.BIND_DEL_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));
			// 履歴No種別
			reader.BindValue(Tk010p01Constant.BIND_RIREKI_SB, 2);
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD + "_SUB", BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO + "_SUB", Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD + "_SUB", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR + "_SUB", Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD + "_2SUB", BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO + "_2SUB", Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD + "_2SUB", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR + "_2SUB", Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損確定TBL]を更新

		/// <summary>
		/// 更新処理 [評価損確定TBL]を更新
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int upd_kakutei(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// 一覧の対象行
			Tk010f01M1Form f01M1Form = (Tk010f01M1Form)f02VO.Dictionary[Tk010p01Constant.DIC_M1SELCETVO];

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_15, facadeContext.DBContext);

			// 処理時間
			reader.BindValue(Tk010p01Constant.BIND_SYORI_TM, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_TM].ToString()));
			// 部門コード
			reader.BindValue(Tk010p01Constant.BIND_BUMON_CD, BoSystemFormat.formatBumonCd(f02m1VO.M1bumon_cd.ToString()));
			// 品種コード
			reader.BindValue(Tk010p01Constant.BIND_HINSYU_CD, Convert.ToDecimal(f02m1VO.M1hinsyu_cd));
			// ブランドコード
			reader.BindValue(Tk010p01Constant.BIND_BURANDO_CD, BoSystemFormat.formatBrandCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1BURANDO_CD].ToString()));
			// メーカー品番
			reader.BindValue(Tk010p01Constant.BIND_MAKER_HBN, f02m1VO.M1maker_hbn);
			// 商品名(カナ)
			reader.BindValue(Tk010p01Constant.BIND_SYONMK, f02m1VO.M1syonmk);
			// 自社品番
			reader.BindValue(Tk010p01Constant.BIND_JISYA_HBN, BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// ＪＡＮコード
			reader.BindValue(Tk010p01Constant.BIND_JAN_CD, BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd));
			// 商品コード
			reader.BindValue(Tk010p01Constant.BIND_SYOHIN_CD, f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYOHIN_CD].ToString());
			// 評価損数量
			reader.BindValue(Tk010p01Constant.BIND_HYOKASON_SU, Convert.ToDecimal(f02m1VO.M1suryo));
			// 販売完了日
			reader.BindValue(Tk010p01Constant.BIND_HANBAIKANRYO_YMD, Convert.ToDecimal(f02m1VO.M1hanbaikanryo_ymd));
			// 色コード
			reader.BindValue(Tk010p01Constant.BIND_IRO_CD, BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1IRO_CD].ToString()));
			// サイズコード
			reader.BindValue(Tk010p01Constant.BIND_SIZE_CD, BoSystemFormat.formatSizeCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SIZE_CD].ToString()));
			// サイズ名
			reader.BindValue(Tk010p01Constant.BIND_SIZE_NM, f02m1VO.M1size_nm);
			// 原単価
			reader.BindValue(Tk010p01Constant.BIND_GEN_TNK, Convert.ToDecimal(f02m1VO.M1gen_tnk));
			// 上代1
			reader.BindValue(Tk010p01Constant.BIND_JODAI1_TNK, Convert.ToDecimal(f02m1VO.M1genbaika_tnk));
			// 評価損種別区分
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONSYUBETSU_KB, Convert.ToDecimal(f02m1VO.M1hyokasonsyubetsu_kb));
			// 評価損理由区分
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONRIYU_KB, Convert.ToDecimal(getHyokasonriyu_kb(f02m1VO)));
			// 評価損理由
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONRIYU, f02m1VO.M1hyokasonriyu);
			// 却下理由区分
			decimal dkyakkaRiyu = 0;
			if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1kyakka_flg))
			{
				dkyakkaRiyu = Convert.ToDecimal(f02m1VO.M1kyakkariyu_kb);
			}
			reader.BindValue(Tk010p01Constant.BIND_KYAKKARIYU_KB, dkyakkaRiyu);
			// 却下理由
			String skyakkariyu = string.Empty;
			if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1kyakka_flg))
			{
				skyakkariyu = f02m1VO.M1kyakkariyu;
			}
			reader.BindValue(Tk010p01Constant.BIND_KYAKKARIYU, skyakkariyu);
			// 承認状態
			reader.BindValue(Tk010p01Constant.BIND_SYONIN_FLG, Convert.ToDecimal(getSyoninFlg(f02m1VO)));
			// 申請日
			reader.BindValue(Tk010p01Constant.BIND_APPLY_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl(f01M1Form.M1apply_ymd, "0"))));
			// 調達区分
			reader.BindValue(Tk010p01Constant.BIND_TYOTATSU_KB, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString()));
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 更新担当者コード
			reader.BindValue(Tk010p01Constant.BIND_UPD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue(Tk010p01Constant.BIND_DEL_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 送信依頼フラグ
			decimal dsosinirai_flg = 0;
			if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1syonin_flg))
			{
				dsosinirai_flg = 1;
			}
			reader.BindValue(Tk010p01Constant.BIND_SOSINIRAI_FLG, dsosinirai_flg);
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));


			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損申請TBL]を更新(修正時保留)

		/// <summary>
		/// 更新処理 [評価損申請TBL]を更新(修正時保留)
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int upd_sinsei_horyu_syusei(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// 一覧の対象行
			Tk010f01M1Form f01M1Form = (Tk010f01M1Form)f02VO.Dictionary[Tk010p01Constant.DIC_M1SELCETVO];

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_16, facadeContext.DBContext);

			// 部門コード
			reader.BindValue(Tk010p01Constant.BIND_BUMON_CD, BoSystemFormat.formatBumonCd(f02m1VO.M1bumon_cd.ToString()));
			// 品種コード
			reader.BindValue(Tk010p01Constant.BIND_HINSYU_CD, Convert.ToDecimal(f02m1VO.M1hinsyu_cd));
			// ブランドコード
			reader.BindValue(Tk010p01Constant.BIND_BURANDO_CD, BoSystemFormat.formatBrandCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1BURANDO_CD].ToString()));
			// メーカー品番
			reader.BindValue(Tk010p01Constant.BIND_MAKER_HBN, f02m1VO.M1maker_hbn);
			// 商品名(カナ)
			reader.BindValue(Tk010p01Constant.BIND_SYONMK, f02m1VO.M1syonmk);
			// 自社品番
			reader.BindValue(Tk010p01Constant.BIND_JISYA_HBN, BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// ＪＡＮコード
			reader.BindValue(Tk010p01Constant.BIND_JAN_CD, BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd));
			// 商品コード
			reader.BindValue(Tk010p01Constant.BIND_SYOHIN_CD, f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYOHIN_CD].ToString());
			// 評価損数量
			reader.BindValue(Tk010p01Constant.BIND_HYOKASON_SU, Convert.ToDecimal(f02m1VO.M1suryo));
			// 販売完了日
			reader.BindValue(Tk010p01Constant.BIND_HANBAIKANRYO_YMD, Convert.ToDecimal(f02m1VO.M1hanbaikanryo_ymd));
			// 色コード
			reader.BindValue(Tk010p01Constant.BIND_IRO_CD, BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1IRO_CD].ToString()));
			// サイズコード
			reader.BindValue(Tk010p01Constant.BIND_SIZE_CD, BoSystemFormat.formatSizeCd(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SIZE_CD].ToString()));
			// サイズ名
			reader.BindValue(Tk010p01Constant.BIND_SIZE_NM, f02m1VO.M1size_nm);
			// 原単価
			reader.BindValue(Tk010p01Constant.BIND_GEN_TNK, Convert.ToDecimal(f02m1VO.M1gen_tnk));
			// 上代1
			reader.BindValue(Tk010p01Constant.BIND_JODAI1_TNK, Convert.ToDecimal(f02m1VO.M1genbaika_tnk));
			// 評価損種別区分
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONSYUBETSU_KB, Convert.ToDecimal(f02m1VO.M1hyokasonsyubetsu_kb));
			// 評価損理由区分
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONRIYU_KB, Convert.ToDecimal(getHyokasonriyu_kb(f02m1VO)));
			// 評価損理由
			reader.BindValue(Tk010p01Constant.BIND_HYOKASONRIYU, f02m1VO.M1hyokasonriyu);
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 更新担当者コード
			reader.BindValue(Tk010p01Constant.BIND_UPD_TANCD, BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue(Tk010p01Constant.BIND_DEL_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損確定TBL]を削除

		/// <summary>
		/// 更新処理 [評価損確定TBL]を削除
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int del_kakutei(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_17, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損申請TBL]の更新日付を最新化

		/// <summary>
		/// 更新処理 [評価損申請TBL]の更新日付を最新化
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int upd_sinseiDate(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_18, facadeContext.DBContext);
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 更新処理 [評価損確定TBL]の更新日付を最新化

		/// <summary>
		/// 更新処理 [評価損確定TBL]の更新日付を最新化
		/// </summary>
		/// <param name="facadeContext">facadeContext</param>
		/// <param name="Tk010f02Form">f01VO</param>
		/// <param name="IDataList">Tk010f02M1Form</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>更新件数</returns>
		private int upd_kakuteiDate(IFacadeContext facadeContext, Tk010f02Form f02VO, Tk010f02M1Form f02m1VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tk010p01Constant.SQL_ID_19, facadeContext.DBContext);
			// 更新日
			reader.BindValue(Tk010p01Constant.BIND_UPD_YMD, Convert.ToDecimal(sysDateVO.Sysdate));
			// 更新時間
			reader.BindValue(Tk010p01Constant.BIND_UPD_TM, Convert.ToDecimal(sysDateVO.Systime_mili));
			// 店舗コード
			reader.BindValue(Tk010p01Constant.BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 管理No
			reader.BindValue(Tk010p01Constant.BIND_KANRI_NO, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1KANRI_NO].ToString()));
			// 処理日付
			reader.BindValue(Tk010p01Constant.BIND_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SYORI_YMD].ToString())));
			// 行No
			reader.BindValue(Tk010p01Constant.BIND_GYO_NBR, Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region 評価損理由区分取得
		/// <summary>
		/// 評価損理由区分取得
		/// </summary>
		/// <param name="Tk010f02M1Form">f02m1VO</param>
		private string getHyokasonriyu_kb(Tk010f02M1Form f02m1VO)
		{
			string ret = string.Empty;
			if (ConditionHyokason_syubetsu.VALUE_HYOKASON_SYUBETSU2.Equals(f02m1VO.M1hyokasonsyubetsu_kb))
			{
				ret = f02m1VO.M1hyokasonriyu_kb_keinen;
			}
			else
			{
				ret = f02m1VO.M1hyokasonriyu_kb;
			}
			return ret;
		}
		#endregion

		#region 承認状態取得
		/// <summary>
		/// 承認状態取得
		/// </summary>
		/// <param name="Tk010f02M1Form">f02m1VO</param>
		private string getSyoninFlg(Tk010f02M1Form f02m1VO)
		{
			string ret = string.Empty;
			if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1syonin_flg))
			{
				ret = ConditionSyonin_jotai2.VALUE_SYONIN_JOTAI21;
			}
			else if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1kyakka_flg))
			{
				ret = ConditionSyonin_jotai2.VALUE_SYONIN_JOTAI22;
			}
			else
			{
				// 入らない
			}
			return ret;
		}
		#endregion

		#region 一覧の明細行編集 (修正モード)
		/// <summary>
		/// 一覧の明細行編集 (修正モード)
		/// </summary>
		/// <param name="Tk010f01M1Form">f01M1Form</param>
		/// <param name="Tk010f02M1Form">f02m1VO</param>
		/// <param name="bool">selectFlg</param>
		private void updMeisaiEdit(Tk010f01M1Form f01M1Form, Tk010f02M1Form f02m1VO, bool selectFlg)
		{
			// 対象行がnullの場合処理しない
			if (f01M1Form == null)
			{
				return;
			}
			int nbFlg = Convert.ToInt32(BoSystemString.RightB(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString(), 1));
			// 編集前の調達区分取得
			int motonbFlg = Convert.ToInt32(BoSystemString.RightB(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB_MOTO].ToString(), 1));

			// 確定行または未編集行の場合
			if (Tk010p01Constant.UPD_JOTAI_KAKUTEI.Equals(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI].ToString())
						|| string.IsNullOrEmpty(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1UPD_JOTAI].ToString()))
			{
				decimal sabunSuryo = 0;
				decimal sabunGenka = 0;

				// 一覧選択行の場合
				if (selectFlg)
				{
					// 明細対象行と一覧対象行の承認状態が一致した場合
					if (f01M1Form.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG].ToString().Equals(getSyoninFlg(f02m1VO)))
					{
						// --------------------------------------
						// 数量、原価金額の差分を取り加算
						// --------------------------------------
						// NBの場合
						if (1 <= nbFlg && nbFlg <= 4)
						{
							// 元の調達区分と比べて変更されていない場合、差分計算する 
							if (f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB_MOTO].ToString().Equals(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString()))
							{
								// 数量差分
								sabunSuryo = Convert.ToDecimal(f02m1VO.M1suryo) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString());
								// 原価金額差分
								sabunGenka += Convert.ToDecimal(f02m1VO.M1genkakin) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString());
								// Ｍ1数量
								f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo) + sabunSuryo).ToString();
								// Ｍ1原価金額
								f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) + sabunGenka).ToString();
							}
							// 元の調達区分と比べて変更されていた場合、移動する 
							else
							{
								// ------------------
								// NB以外⇒NBに移動
								// ------------------
								// NB以外の数量から元数量を引く
								f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo)
															- Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString())).ToString();
								// NB以外の原価金額から元原価金額を引く
								f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin)
															- Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString())).ToString();

								// NB数量に入力された数量を加算する
								f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo) + Convert.ToDecimal(f02m1VO.M1suryo)).ToString();

								// NB原価金額に入力された原価金額を加算する
								f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) + Convert.ToDecimal(f02m1VO.M1genkakin)).ToString();
							}

						}
						// NB以外の場合
						else
						{
							// 元の調達区分と比べて変更されていない場合、差分計算する 
							if (f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB_MOTO].ToString().Equals(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1TYOTATSU_KB].ToString()))
							{
								// 数量差分
								sabunSuryo = Convert.ToDecimal(f02m1VO.M1suryo) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString());
								// 原価金額差分
								sabunGenka += Convert.ToDecimal(f02m1VO.M1genkakin) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString());
								// Ｍ1数量
								f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo) + sabunSuryo).ToString();
								// Ｍ1原価金額
								f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin) + sabunGenka).ToString();
							}
							// 元の調達区分と比べて変更されていた場合、移動する 
							else
							{
								// ------------------
								// NB⇒NB以外に移動
								// ------------------
								// NBの数量から元数量を引く
								f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo)
															- Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString())).ToString();
								// NBの原価金額から元原価金額を引く
								f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin)
															- Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString())).ToString();

								// NB以外数量に入力された数量を加算する
								f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo) + Convert.ToDecimal(f02m1VO.M1suryo)).ToString();

								// NB以外原価金額に入力された原価金額を加算する
								f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin) + Convert.ToDecimal(f02m1VO.M1genkakin)).ToString();
							}

						}
					}
					// 明細対象行と一覧対象行の承認状態が一致しなかった場合
					else
					{
						// --------------------------------------
						// 値を減算
						// --------------------------------------
						// NBの場合※編集前の調達区分で確認
						if (1 <= motonbFlg && motonbFlg <= 4)
						{
							// Ｍ1数量
							f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString())).ToString();
							// Ｍ1原価金額
							f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString())).ToString();
						}
						// NB以外の場合
						else
						{
							// Ｍ1数量
							f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString())).ToString();
							// Ｍ1原価金額
							f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString())).ToString();
						}
					}
				} // 一覧選択行の場合
				else
				// 対となる行
				{
					// 明細対象行と一覧対象行の承認状態が一致した場合加算する
					if (f01M1Form.Dictionary[Tk010p01Constant.DIC_M1SYONIN_FLG].ToString().Equals(getSyoninFlg(f02m1VO)))
					{
						// --------------------------------------
						// 値を加算
						// --------------------------------------
						// NBの場合
						if (1 <= nbFlg && nbFlg <= 4)
						{
							// Ｍ1数量
							f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo) + Convert.ToDecimal(f02m1VO.M1suryo)).ToString();
							// Ｍ1原価金額
							f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) + Convert.ToDecimal(f02m1VO.M1genkakin)).ToString();
						}
						// NB以外の場合
						else
						{
							// Ｍ1数量
							f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo) + Convert.ToDecimal(f02m1VO.M1suryo)).ToString();
							// Ｍ1原価金額
							f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin) + Convert.ToDecimal(f02m1VO.M1genkakin)).ToString();
						}

						// 明細行のリンクを使用可能にする
						f01M1Form.Dictionary[Tk010p01Constant.DIC_M1LINKFLG] = Tk010p01Constant.MEISAI_LINK_KANO_FLG;
						// 明細行の更新日を最新化する
						f01M1Form.Dictionary[Tk010p01Constant.MEISAI_DATE_UPD_FLG] = "1";
					}
				}
			}
			// 保留行の場合
			else
			{
				// 対象行の場合、保留行は減算
				if (selectFlg)
				{
					// --------------------------------------
					// 値を減算
					// --------------------------------------
					// NBの場合
					if (1 <= nbFlg && nbFlg <= 4)
					{
						// Ｍ1数量
						f01M1Form.M1nb_suryo = (Convert.ToDecimal(f01M1Form.M1nb_suryo) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString())).ToString();
						// Ｍ1原価金額
						f01M1Form.M1nb_genka_kin = (Convert.ToDecimal(f01M1Form.M1nb_genka_kin) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString())).ToString();
					}
					// NB以外の場合
					else
					{
						// Ｍ1数量
						f01M1Form.M1notnb_suryo = (Convert.ToDecimal(f01M1Form.M1notnb_suryo) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1SURYO_MOTO].ToString())).ToString();
						// Ｍ1原価金額
						f01M1Form.M1notnb_genka_kin = (Convert.ToDecimal(f01M1Form.M1notnb_genka_kin) - Convert.ToDecimal(f02m1VO.Dictionary[Tk010p01Constant.DIC_M1GENKA_KIN_MOTO].ToString())).ToString();
					}
				}
			}
		}
		#endregion

		#endregion

	}
}
