using com.xebio.bo.Tb090p01.Constant;
using com.xebio.bo.Tb090p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01004;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V03000.V03003;
using Common.Business.V03000.V03006;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tb090p01.Facade
{
  /// <summary>
  /// Tb090f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb090f02Facade : StandardBaseFacade
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
				
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tb090f02Form f02VO = (Tb090f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Tb090f01M1Form f01M1Form = (Tb090f01M1Form)f02VO.Dictionary[Tb090p01Constant.DIC_M1SELCETVO];

				#endregion

				#region 業務チェック

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				
				decimal warninngFlg = Convert.ToDecimal(BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0"));
				if (warninngFlg != 1)
				{

					#region 単項目チェック(カード部)

					if (ConditionBiko_kbn.VALUE_BIKO_KBN2.Equals(f02VO.Biko_kb))
					{
						// 備考１
						//  半角数字以外の場合はエラー
						if (!V03006Check.CsvHalfNumCheck(f02VO.Biko1))
						{
							// ①は半角数字のみで入力して下さい。。
							ErrMsgCls.AddErrMsg("E116", new[] { "①" }, facadeContext, new[] { "Biko1" });
						}

						// 備考１
						//	7桁以上の場合はエラー
						if (f02VO.Biko1.Length >= 7)
						{
							// ①は6桁以内で入力して下さい。
							ErrMsgCls.AddErrMsg("E108", new[] { "①", "6" }, facadeContext, new[] { "Biko1" });
						}

						// 備考２
						//	未入力の場合はエラー
						if (string.IsNullOrEmpty(f02VO.Biko2))
						{
							// ②を入力して下さい。
							ErrMsgCls.AddErrMsg("E121", "②", facadeContext, new[] { "Biko2" });
						}
					}

					#endregion

					#region 行数チェック

					if (m1List == null || m1List.Count <= 0)
					{
						// 確定対象がありません。
						ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#endregion

					#region 入力値チェック

					for (int i = 0; i < m1List.Count; i++)
					{
						Tb090f02M1Form f02m1VO = (Tb090f02M1Form)m1List[i];

						// スキャンコードが未入力の場合エラー
						if (string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							ErrMsgCls.AddErrMsg("E118", new[] { "スキャンコード" }, facadeContext, new[] { "M1scan_cd" }, f02m1VO.M1rowno, i.ToString(), "M1");
						}

						// 1 マニュアル以外の場合、納品数＜訂正数量の場合エラー
						if (!((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]).Equals(BoSystemConstant.KAKUTEI_SB_SHIIRE_MANUAL)
							&& !((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]).Equals(BoSystemConstant.KAKUTEI_SB_SHIIRE_MANUAL_TEISEI))
						{
							if (!string.IsNullOrEmpty(f02m1VO.M1teisei_suryo)
								&& Convert.ToDecimal(f02m1VO.M1nohin_su) < Convert.ToDecimal(f02m1VO.M1teisei_suryo))
							{
								ErrMsgCls.AddErrMsg("E120", new[] { "納品数" }, facadeContext, new[] { "M1teisei_suryo" }, f02m1VO.M1rowno, i.ToString(), "M1");
							}
						}
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#endregion

					#region 単項目チェック(明細部)

					for (int i = 0; i < m1List.Count; i++)
					{
						Tb090f02M1Form f02m1VO = (Tb090f02M1Form)m1List[i];

						// スキャンコードが入力されている行のみチェックを行う
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							// 2-1 スキャンコード
							//       発注マスタを検索し、存在しない場合エラー
							if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
							{
								SearchHachuVO searchConditionVO = new SearchHachuVO(
								f02m1VO.M1scan_cd,		// スキャンコード
								f02VO.Head_tenpo_cd,	// 店舗コード
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
								resultHash = V01004Check.CheckScanCd(   searchConditionVO, 
																		facadeContext,
																		"スキャンコード",
																		new[] { "M1scan_cd" },
																		f02m1VO.M1rowno,
																		i.ToString(),
																		"M1",
																		0);
	
								// 取得エラー時は次の行へ移動
								if(resultHash == null)
								{
									continue;
								}

								// 名称をラベルに設定
								if (!f02m1VO.M1scan_cd.Equals((string)f02m1VO.Dictionary[Tb090p01Constant.DIC_M1SCAN_CD]))
								{
									f02m1VO.M1hinsyu_ryaku_nm = resultHash["HINSYU_RYAKU_NM"].ToString();														// 品種
									f02m1VO.M1burando_nm = resultHash["BURANDO_NMK"].ToString();																// ブランド名
									f02m1VO.M1jisya_hbn = BoSystemFormat.formatJisyaHbn((string)resultHash["XEBIO_CD"].ToString());								// 自社品番
									f02m1VO.M1maker_hbn = resultHash["HIN_NBR"].ToString();																		// メーカー品番
									f02m1VO.M1syonmk = resultHash["SYONMK"].ToString();																			// 商品名
									f02m1VO.M1iro_nm = resultHash["IRO_NM"].ToString();																			// 色
									f02m1VO.M1size_nm = resultHash["SIZE_NM"].ToString();																		// サイズ
									f02m1VO.M1scan_cd = resultHash["JAN_CD"].ToString();																		// JANコード 
									f02m1VO.M1gen_tnk = resultHash["GENKA"].ToString();																			// 原価
									f02m1VO.Dictionary[Tb090p01Constant.DIC_M1SYOHIN_CD] = resultHash["SYOHIN_CD"].ToString();									// 商品コード
									f02m1VO.Dictionary[Tb090p01Constant.DIC_M1SIZE_CD] = BoSystemFormat.formatSizeCd(resultHash["SIZE_CD"].ToString());			// サイズコード
									f02m1VO.Dictionary[Tb090p01Constant.DIC_M1HINSYU_CD] = BoSystemFormat.formatHinsyuCd(resultHash["HINSYU_CD"].ToString());	// 品種コード
									f02m1VO.Dictionary[Tb090p01Constant.DIC_M1BURANDO_CD] = BoSystemFormat.formatBrandCd(resultHash["BURANDO_CD"].ToString());	// ブランドコード
									f02m1VO.Dictionary[Tb090p01Constant.DIC_M1IRO_CD] = BoSystemFormat.formatIroCd(resultHash["MAKERCOLOR_CD"].ToString());		// 色コード
								}
							}

							// 変更前の自社品番と異なる場合はエラー
							if (!BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn).Equals((string)f02m1VO.Dictionary[Tb090p01Constant.DIC_M1JISYA_HBN]))
							{
								ErrMsgCls.AddErrMsg("E178", string.Empty, facadeContext, new[] { "M1scan_cd" }, f02m1VO.M1rowno, i.ToString(), "M1");
							}
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

					sRepSql.Append(" AND KAKUTEI_SB			= :BIND_KAKUTEI_SB");
					sRepSql.Append(" AND SIIRESAKI_CD		= :BIND_SIIRESAKI_CD");
					sRepSql.Append(" AND DENPYO_BANGO		= :BIND_DENPYO_BANGO");
					sRepSql.Append(" AND SITEINOHIN_YMD		= :BIND_SITEINOHIN_YMD");
					sRepSql.Append(" AND TENPO_CD			= :BIND_TENPO_CD");

					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					// 確定種別
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KAKUTEI_SB";
					bindVO.Value = (string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 仕入先コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SIIRESAKI_CD";
					bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 伝票番号
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DENPYO_BANGO";
					bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1DENPYO_BANGO]);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 指定納品日
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SITEINOHIN_YMD";
					bindVO.Value = BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 店舗コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1UPD_YMD]),
							Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1UPD_TM]),
							facadeContext,
							"MDPT0020",
							sRepSql.ToString(),
							bindList,
							1
					);
					#endregion

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#region 警告チェック
					for (int i = 0; i < m1List.Count; i++)
					{
						Tb090f02M1Form f02m1VO = (Tb090f02M1Form)m1List[i];

						// マニュアル以外の場合、納品数＞検数の場合、警告
						if (!((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]).Equals(BoSystemConstant.KAKUTEI_SB_SHIIRE_MANUAL)
							&& !((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]).Equals(BoSystemConstant.KAKUTEI_SB_SHIIRE_MANUAL_TEISEI))
						{
							if (!string.IsNullOrEmpty(f02m1VO.M1teisei_suryo)
								&& Convert.ToDecimal(f02m1VO.M1nohin_su) > Convert.ToDecimal(f02m1VO.M1teisei_suryo))
							{
								InfoMsgCls.AddWarnMsg("W118", String.Empty, facadeContext, new[] { "M1teisei_suryo" }, f02m1VO.M1rowno, i.ToString(), "M1");
							}
						}
					}

					#endregion

					// ------------------------------------------------------------------------------------
					// ワーニングが発生した場合、その時点でチェックを中止しクライアント側へワーニング内容を返却する。
					// ------------------------------------------------------------------------------------
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}

				}

				#endregion

				#region 更新処理

				// [仕入入荷確定TBL(H)]を更新
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を更新 START");
				int Updcntkakuh = Upd_ShiireKakuteiMeisaih(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を更新 END  ");

				// 伝票番号採番
				decimal dDennoAka = AutoNumber_TeiseiDenNo(facadeContext,
															f02VO,
															f01M1Form,
															logininfo
								);
				if (dDennoAka < 0)
				{
					// 採番不可。
					ErrMsgCls.AddErrMsg("E230", String.Empty, facadeContext);
					return;
				}

				f01M1Form.Dictionary.Add(Tb090p01Constant.DIC_M1AKADENPYO_BANGO, BoSystemFormat.formatDenpyoNo(dDennoAka));	// 赤伝票番号

				// [仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【赤伝】を登録
				BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【赤伝】を登録 START");
				int Inscntkakub = Ins_ShiireKakuteiAkab(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
				BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【赤伝】を登録 END  ");

				// [仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【赤伝】を登録
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【赤伝】を登録 START");
				int Inscntkakuh = Ins_ShiireKakuteiAkah(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【赤伝】を登録 END  ");

				// [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録を登録
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録 START");
				int Inscntrirekiakah = Ins_ShiireRirekiAkaDenh(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録 END  ");

				// [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録
				BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録 START");
				int Inscntrirekiakab = Ins_ShiireRirekiAkaDenb(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
				BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録 END  ");


				// 伝票番号採番
				decimal dDennoKuro = AutoNumber_TeiseiDenNo(facadeContext,
															f02VO,
															f01M1Form,
															logininfo
								);
				if (dDennoKuro < 0)
				{
					// 採番不可。
					ErrMsgCls.AddErrMsg("E230", String.Empty, facadeContext);
					return;
				}

				f01M1Form.Dictionary.Add(Tb090p01Constant.DIC_M1KURODENPYO_BANGO, BoSystemFormat.formatDenpyoNo(dDennoKuro));	// 黒伝票番号

				// 実績数合計
				Decimal dTeiseiSuSum = 0;
				// 実績金額合計
				Decimal dKinSum = 0;

				// 明細情報リスト
				Dictionary<string, Tb090f02M1Form> dicM1List = new Dictionary<string, Tb090f02M1Form>();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tb090f02M1Form f02m1VO = (Tb090f02M1Form)m1List[i];

					// [仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【黒伝】を登録
					BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【黒伝】を登録 START");
					int Inscntkakukurob = Ins_ShiireKakuteiKurob(facadeContext, f02VO, f01M1Form, f02m1VO, logininfo, sysDateVO);
					BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【黒伝】を登録 END  ");

					// [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録
					BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録 START");
					int Inscntrirekikurob = Ins_ShiireRirekiKuroDenb(facadeContext, f02VO, f01M1Form, f02m1VO, logininfo, sysDateVO);
					BoSystemLog.logOut("[仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録 END  ");

					// 合計値加算
					decimal teiseiSu = Convert.ToDecimal(f02m1VO.M1kensu);
					if(!string.IsNullOrEmpty(f02m1VO.M1teisei_suryo))
					{
						teiseiSu = Convert.ToDecimal(f02m1VO.M1teisei_suryo);
					}

					// Dictionaryに明細情報を設定
					dicM1List.Add(f02m1VO.M1rowno, f02m1VO);

					dTeiseiSuSum += teiseiSu;
					dKinSum += teiseiSu * Convert.ToDecimal(f02m1VO.M1gen_tnk);
				}

				// [仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【黒伝】を登録
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【黒伝】を登録 START");
				int Inscntkakukuroh = Ins_ShiireKakuteiKuroh(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO, dTeiseiSuSum, dKinSum);
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【黒伝】を登録 END  ");

				// [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録 START");
				int Inscntrirekikuroh = Ins_ShiireRirekiKuroDenh(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
				BoSystemLog.logOut("[仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録 END  ");

				#endregion

				#region 一覧画面項目の設定

				// 合計金額、合計数の設定
				f01M1Form.M1teisei_suryo = dTeiseiSuSum.ToString();
				f01M1Form.M1genkakin = dKinSum.ToString();

				// 確定フラグの設定
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;

				// 備考の設定
				f01M1Form.Dictionary[Tb090p01Constant.DIC_M1BIKO_KB] = f02VO.Biko_kb;
				f01M1Form.Dictionary[Tb090p01Constant.DIC_M1BIKO1] = f02VO.Biko1;
				f01M1Form.Dictionary[Tb090p01Constant.DIC_M1BIKO2] = f02VO.Biko2;

				// 明細情報の設定
				f01M1Form.Dictionary[Tb090p01Constant.DIC_M1MEISAILIST] = dicM1List;

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 印刷処理

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				// 赤伝票
				// 伝票種別(1:伝票番号、2:元伝票番号)
				inputData.AddScreenParameter(1, "1");
				// 会社コード
				inputData.AddScreenParameter(2, logininfo.CopCd);
				// 確定種別
				inputData.AddScreenParameter(3, f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);
				// 仕入先コード
				inputData.AddScreenParameter(4, BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
				// 伝票番号
				inputData.AddScreenParameter(5, BoSystemFormat.formatDenpyoNo(dDennoAka));
				// 指定納品日
				inputData.AddScreenParameter(6, BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd));
				// 店舗コード
				inputData.AddScreenParameter(7, BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
				// 店舗控え出力フラグ
				inputData.AddScreenParameter(8, "1");

				// 新黒伝票
				// 伝票種別(1:伝票番号、2:元伝票番号)
				inputData.AddScreenParameter(1, "1");
				// 会社コード
				inputData.AddScreenParameter(2, logininfo.CopCd);
				// 確定種別
				inputData.AddScreenParameter(3, f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);
				// 仕入先コード
				inputData.AddScreenParameter(4, BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
				// 伝票番号
				inputData.AddScreenParameter(5, BoSystemFormat.formatDenpyoNo(dDennoKuro));
				// 指定納品日
				inputData.AddScreenParameter(6, BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd));
				// 店舗コード
				inputData.AddScreenParameter(7, BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
				// 店舗控え出力フラグ
				inputData.AddScreenParameter(8, "1");

				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				// 帳票ID
				string chohyoId = string.Empty;

				string pdfFileNm = string.Empty;

				// 帳票ID
				chohyoId = BoSystemConstant.REPORTID_SIIRETEISEIDENPYO;

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(chohyoId),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												chohyoId,
												Tb090p01Constant.FORMID_01,
												Tb090p01Constant.PGID,
												pdfFileNm
												);

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tb090p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				#endregion

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

		#region 訂正伝票番号の採番を行う。
		/// <summary>
		/// 訂正伝票番号の採番を行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>訂正伝票番号 ※採番不可の場合は、-1を戻す</returns>
		private decimal AutoNumber_TeiseiDenNo( IFacadeContext facadeContext,
												Tb090f02Form f02Form,
												Tb090f01M1Form f01M1Form,
												LoginInfoVO loginInfo)
		{

			Boolean loop = true;
			decimal loopCnt = 0;
			string denno = string.Empty;

			while (loop)
			{
				// 採番を行う
				denno = NumberingCls.Numbering(
											facadeContext,
											BoSystemConstant.AUTONUM_SHIIRE_TEISEINO,
											"0000",
											loginInfo.LoginId
						);
				decimal dDenno = Convert.ToDecimal(denno);


				// 採番値が既にテーブルで使用されていないかチェック(※されている場合は次の番号を採番)
				// XMLからSQLを取得する。
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_01, facadeContext.DBContext);

				// テーブルID指定
				BoSystemSql.AddSql(reader, "TABLE_ID1", "MDPT0020 T1");

				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				sRepSql.Append(" AND T1.KAKUTEI_SB			= :BIND_KAKUTEI_SB");
				sRepSql.Append(" AND T1.DENPYO_BANGO		= :BIND_DENPYO_BANGO");
				sRepSql.Append(" AND T1.SITEINOHIN_YMD		= :BIND_SITEINOHIN_YMD");
				sRepSql.Append(" AND T1.TENPO_CD			= :BIND_TENPO_CD");

				// 確定種別
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KAKUTEI_SB";
				bindVO.Value = (string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 伝票番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(dDenno);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 指定納品日
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SITEINOHIN_YMD";
				bindVO.Value = BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 追加の条件
				BoSystemSql.AddSql(reader, "ADD_WHERE1", sRepSql.ToString(), bindList);

				// SQL実行
				IList<Hashtable> ItemList = reader.Execute();

				if (ItemList == null || ItemList.Count <= 0)
				{
					// 伝票番号が未存在の場合、採番OK
					loop = false;
				}
				else
				{
					Hashtable ht = (Hashtable)ItemList[0];
					if ((decimal)ht["CNT"] <= 0)
					{
						// 伝票番号が未存在の場合、採番OK
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
			return Convert.ToDecimal(BoSystemString.Nvl(denno, "-1"));
		}

		#endregion

		#region [仕入入荷確定TBL(H)]を更新する。
		/// <summary>
		/// [仕入入荷確定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_ShiireKakuteiMeisaih(  IFacadeContext facadeContext,
												Tb090f02Form f02Form,
												Tb090f01M1Form f01M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新内容
			// 新黒フラグ
			reader.BindValue("BIND_SHINKURO_FLG", Convert.ToDecimal(BoSystemConstant.SHINKURO_FLG_NOT_SHINKURO));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 更新条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region [仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【赤伝】を登録する。
		/// <summary>
		/// [仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【赤伝】を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireKakuteiAkab(  IFacadeContext facadeContext,
											Tb090f02Form f02Form,
											Tb090f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_09, facadeContext.DBContext);

			decimal kakuteiSb = Convert.ToDecimal(f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);

			// 登録内容
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_1", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1AKADENPYO_BANGO])));

			// 検索条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_3", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_2", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region [仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【赤伝】を登録する。
		/// <summary>
		/// [仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【赤伝】を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireKakuteiAkah(  IFacadeContext facadeContext,
											Tb090f02Form f02Form,
											Tb090f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_10, facadeContext.DBContext);

			decimal kakuteiSb = Convert.ToDecimal(f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);

			// 登録内容
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_1", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1AKADENPYO_BANGO])));
			// 備考区分
			reader.BindValue("BIND_BIKO_KB", Convert.ToDecimal(f02Form.Biko_kb));
			// 備考１
			reader.BindValue("BIND_BIKO1", f02Form.Biko1);
			// 備考２
			reader.BindValue("BIND_BIKO2", f02Form.Biko2);
			// 元確定種別
			reader.BindValue("BIND_MOTOKAKUTEI_SB", kakuteiSb);
			// 更新日
			reader.BindValue("BIND_UPD_YMD_1", sysDateVO.Sysdate);
			reader.BindValue("BIND_UPD_YMD_2", sysDateVO.Sysdate);
			reader.BindValue("BIND_UPD_YMD_3", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM_1", sysDateVO.Systime_mili);
			reader.BindValue("BIND_UPD_TM_2", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD_1", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			reader.BindValue("BIND_UPD_TANCD_2", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 検索条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_3", kakuteiSb);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_2", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1DENPYO_BANGO])));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録
		/// <summary>
		/// [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekiAkaDenh( IFacadeContext facadeContext,
												Tb090f02Form f02Form,
												Tb090f01M1Form f01M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_04, facadeContext.DBContext);

			decimal syoriSb = 3;
			// 送信済フラグが未送信の場合は処理種別＝４
			if (BoSystemConstant.SOSINZUMI_FLG_MISOSIN.Equals((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1SOSINZUMI_FLG]))
			{
				syoriSb = 4;
			}
			decimal akakuroKbn = 1;
			decimal kakuteiSb = Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);

			// 処理種別（[3]訂正 [4]訂正修正 [5]訂正取消）
			reader.BindValue("BIND_SYORI_SB_1", syoriSb);
			reader.BindValue("BIND_SYORI_SB_2", syoriSb);
			reader.BindValue("BIND_SYORI_SB_3", syoriSb);
			reader.BindValue("BIND_SYORI_SB_4", syoriSb);
			reader.BindValue("BIND_SYORI_SB_5", syoriSb);
			// 赤黒区分（[1]黒伝 [2]赤伝）
			reader.BindValue("BIND_AKAKURO_KBN_1", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_2", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_3", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_4", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_5", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_6", akakuroKbn);
			// 履歴処理日
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_3", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1AKADENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録
		/// <summary>
		/// [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekiAkaDenb( IFacadeContext facadeContext,
												Tb090f02Form f02Form,
												Tb090f01M1Form f01M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_05, facadeContext.DBContext);


			decimal syoriSb = 3;
			// 送信済フラグが未送信の場合は処理種別＝４
			if (BoSystemConstant.SOSINZUMI_FLG_MISOSIN.Equals((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1SOSINZUMI_FLG]))
			{
				syoriSb = 4;
			}
			decimal akakuroKbn = 1;
			decimal kakuteiSb = Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);
			decimal denpyogyoNo = 0;

			// 処理種別（[3]訂正 [4]訂正修正 [5]訂正取消）
			reader.BindValue("BIND_SYORI_SB_1", syoriSb);
			reader.BindValue("BIND_SYORI_SB_2", syoriSb);
			// 赤黒区分（[1]黒伝 [2]赤伝）
			reader.BindValue("BIND_AKAKURO_KBN_1", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_2", akakuroKbn);

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1AKADENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 伝票行№(伝票単位のため0を設定)
			reader.BindValue("BIND_DENPYOGYO_NO_1", denpyogyoNo);
			reader.BindValue("BIND_DENPYOGYO_NO_2", denpyogyoNo);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【黒伝】を登録する。
		/// <summary>
		/// [仕入入荷確定TBL(B)]を検索し、[仕入入荷確定TBL(B)]【黒伝】を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireKakuteiKurob(IFacadeContext facadeContext,
											Tb090f02Form f02Form,
											Tb090f01M1Form f01M1Form,
											Tb090f02M1Form f02M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_11, facadeContext.DBContext);

			decimal kakuteiSb = Convert.ToDecimal(f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);

			// 登録内容
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_1", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KURODENPYO_BANGO])));
			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(BoSystemFormat.formatHinsyuCd((string)f02M1Form.Dictionary[Tb090p01Constant.DIC_M1HINSYU_CD])));
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f02M1Form.Dictionary[Tb090p01Constant.DIC_M1BURANDO_CD]));
			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f02M1Form.M1maker_hbn);
			// 商品名（カナ）
			reader.BindValue("BIND_SYONMK", f02M1Form.M1syonmk);
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02M1Form.M1jisya_hbn));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f02M1Form.Dictionary[Tb090p01Constant.DIC_M1IRO_CD]));
			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd((string)f02M1Form.Dictionary[Tb090p01Constant.DIC_M1SIZE_CD]));
			// サイズ
			reader.BindValue("BIND_SIZE_NM", f02M1Form.M1size_nm);
			// 実績数
			if (string.IsNullOrEmpty(f02M1Form.M1teisei_suryo))
			{
				reader.BindValue("BIND_JISSEKI_SU", Convert.ToDecimal(f02M1Form.M1kensu));
			}
			else
			{
				reader.BindValue("BIND_JISSEKI_SU", Convert.ToDecimal(f02M1Form.M1teisei_suryo));
			}
			// スキャンコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f02M1Form.M1scan_cd));
			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", (string)f02M1Form.Dictionary[Tb090p01Constant.DIC_M1SYOHIN_CD]);
			// 原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(f02M1Form.M1gen_tnk));

			// 検索条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_3", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_2", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1DENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 伝票行No
			reader.BindValue("BIND_DENPYOGYO_NO", Convert.ToDecimal(f02M1Form.M1rowno));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録
		/// <summary>
		/// [仕入入荷確定TBL(B)]を検索し、[仕入入荷履歴TBL(B)]【黒伝】を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekiKuroDenb(   IFacadeContext facadeContext,
												Tb090f02Form f02Form,
												Tb090f01M1Form f01M1Form,
												Tb090f02M1Form f02M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_05, facadeContext.DBContext);


			decimal syoriSb = 3;
			// 送信済フラグが未送信の場合は処理種別＝４
			if (BoSystemConstant.SOSINZUMI_FLG_MISOSIN.Equals((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1SOSINZUMI_FLG]))
			{
				syoriSb = 4;
			}
			decimal akakuroKbn = 1;
			decimal kakuteiSb = Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);
			decimal denpyogyoNo = Convert.ToDecimal(f02M1Form.M1rowno);

			// 処理種別（[3]訂正 [4]訂正修正 [5]訂正取消）
			reader.BindValue("BIND_SYORI_SB_1", syoriSb);
			reader.BindValue("BIND_SYORI_SB_2", syoriSb);
			// 赤黒区分（[1]黒伝 [2]赤伝）
			reader.BindValue("BIND_AKAKURO_KBN_1", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_2", akakuroKbn);

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KURODENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 伝票行№(伝票単位のため0を設定)
			reader.BindValue("BIND_DENPYOGYO_NO_1", denpyogyoNo);
			reader.BindValue("BIND_DENPYOGYO_NO_2", denpyogyoNo);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【黒伝】を登録する。
		/// <summary>
		/// [仕入入荷確定TBL(H)]を検索し、[仕入入荷確定TBL(H)]【黒伝】を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireKakuteiKuroh(IFacadeContext facadeContext,
											Tb090f02Form f02Form,
											Tb090f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO,
											decimal dTeiseiSuSum,
											decimal dKinSum)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_12, facadeContext.DBContext);

			decimal kakuteiSb = Convert.ToDecimal(f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);

			// 登録内容
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_1", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KURODENPYO_BANGO])));
			// 仕入実績合計数量
			reader.BindValue("BIND_JISSEKIKEI_1", dTeiseiSuSum);
			reader.BindValue("BIND_JISSEKIKEI_2", dTeiseiSuSum);

			// 仕入実績合計金額
			reader.BindValue("BIND_JISSEKIKEI_KIN", dKinSum);
			// 備考区分
			reader.BindValue("BIND_BIKO_KB", Convert.ToDecimal(f02Form.Biko_kb));
			// 備考１
			reader.BindValue("BIND_BIKO1", f02Form.Biko1);
			// 備考２
			reader.BindValue("BIND_BIKO2", f02Form.Biko2);
			// 元確定種別
			reader.BindValue("BIND_MOTOKAKUTEI_SB", kakuteiSb);
			// 更新日
			reader.BindValue("BIND_UPD_YMD_1", sysDateVO.Sysdate);
			reader.BindValue("BIND_UPD_YMD_2", sysDateVO.Sysdate);
			reader.BindValue("BIND_UPD_YMD_3", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM_1", sysDateVO.Systime_mili);
			reader.BindValue("BIND_UPD_TM_2", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD_1", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			reader.BindValue("BIND_UPD_TANCD_2", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 検索条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_3", kakuteiSb);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_2", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1DENPYO_BANGO])));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録
		/// <summary>
		/// [仕入入荷確定TBL(H)]を検索し、[仕入入荷履歴TBL(H)]【黒伝】を登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireRirekiKuroDenh(IFacadeContext facadeContext,
												Tb090f02Form f02Form,
												Tb090f01M1Form f01M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb090p01Constant.SQL_ID_04, facadeContext.DBContext);

			decimal syoriSb = 3;
			// 送信済フラグが未送信の場合は処理種別＝４
			if (BoSystemConstant.SOSINZUMI_FLG_MISOSIN.Equals((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1SOSINZUMI_FLG]))
			{
				syoriSb = 4;
			}
			decimal akakuroKbn = 1;
			decimal kakuteiSb = Convert.ToDecimal((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KAKUTEI_SB]);

			// 処理種別（[3]訂正 [4]訂正修正 [5]訂正取消）
			reader.BindValue("BIND_SYORI_SB_1", syoriSb);
			reader.BindValue("BIND_SYORI_SB_2", syoriSb);
			reader.BindValue("BIND_SYORI_SB_3", syoriSb);
			reader.BindValue("BIND_SYORI_SB_4", syoriSb);
			reader.BindValue("BIND_SYORI_SB_5", syoriSb);
			// 赤黒区分（[1]黒伝 [2]赤伝）
			reader.BindValue("BIND_AKAKURO_KBN_1", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_2", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_3", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_4", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_5", akakuroKbn);
			reader.BindValue("BIND_AKAKURO_KBN_6", akakuroKbn);
			// 履歴処理日
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_1", kakuteiSb);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 登録条件
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB_2", kakuteiSb);
			reader.BindValue("BIND_KAKUTEI_SB_3", kakuteiSb);
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tb090p01Constant.DIC_M1KURODENPYO_BANGO])));
			// 指定納品日
			reader.BindValue("BIND_SITEINOHIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1nyukayotei_ymd)));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#endregion
	}
}
