using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01011;
using Common.Business.V01000.V01012;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f02Facade : StandardBaseFacade
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

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj190f02Form f01VO = (Tj190f02Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧画面選択行のVO
				Tj190f01M1Form f01M1Form = (Tj190f01M1Form)f01VO.Dictionary[Tj190p01Constant.DIC_M1SELCETVO];

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				#region 業務チェック

				#region 行数チェック

				// 1-1 明細行
				// Ｍ１スキャンコードが入力されている明細が0行の場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E133", string.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tj190f02M1Form f02m1VO = (Tj190f02M1Form)m1List[i];
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						ErrMsgCls.AddErrMsg("E133", string.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 入力値チェック

				// 2-1 品種指定フラグ、品種コード
				// 品種指定フラグが「品種指定」の場合に、品種コードが未入力の場合、エラー
				if (ConditionHinsyu_sitei_flg.VALUE_HINSYU_SITEI_FLG2.Equals(f01VO.Hinsyu_sitei_flg)
					&& string.IsNullOrEmpty(f01VO.Hinsyu_cd))
				{
					ErrMsgCls.AddErrMsg("E205", string.Empty, facadeContext);
				}

				// 2-2 ブランド指定フラグ、ブランドコード
				// ブランド指定フラグが「ブランド指定」の場合に、ブランドコード(～7)が全て未入力の場合、、エラー
				if (ConditionBurando_sitei_flg.VALUE_BURANDO_SITEI_FLG2.Equals(f01VO.Burando_sitei_flg)
					&& string.IsNullOrEmpty(f01VO.Burando_cd)
					&& string.IsNullOrEmpty(f01VO.Burando_cd1)
					&& string.IsNullOrEmpty(f01VO.Burando_cd2)
					&& string.IsNullOrEmpty(f01VO.Burando_cd3)
					&& string.IsNullOrEmpty(f01VO.Burando_cd4)
					&& string.IsNullOrEmpty(f01VO.Burando_cd5)
					&& string.IsNullOrEmpty(f01VO.Burando_cd6)
					&& string.IsNullOrEmpty(f01VO.Burando_cd7))
				{
					ErrMsgCls.AddErrMsg("E206", string.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region マスタチェック

				// 3-1 品種コード
				// 品種MSTに存在しない場合、エラー
				f01VO.Hinsyu_ryaku_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01011Check.CheckHinsyu(f01VO.Bumon_cd_bo, f01VO.Hinsyu_cd, facadeContext, "品種", new[] { "Hinsyu_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Hinsyu_ryaku_nm = (string)resultHash["HINSYU_RYAKU_NM"];
					}
				}

				// 3-2 ブランドコード～ブランドコード7
				// ブランドMSTを検索し、存在しない場合エラー
				f01VO.Burando_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd, facadeContext, "ブランド1", new[] { "Burando_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm = (string)resultHash["BURANDO_NMK"];
					}
				}

				f01VO.Burando_nm1 = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd1))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd1, facadeContext, "ブランド2", new[] { "Burando_cd1" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm1 = (string)resultHash["BURANDO_NMK"];
					}
				}

				f01VO.Burando_nm2 = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd2))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd2, facadeContext, "ブランド3", new[] { "Burando_cd2" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm2 = (string)resultHash["BURANDO_NMK"];
					}
				}

				f01VO.Burando_nm3 = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd3))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd3, facadeContext, "ブランド4", new[] { "Burando_cd3" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm3 = (string)resultHash["BURANDO_NMK"];
					}
				}

				f01VO.Burando_nm4 = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd4))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd4, facadeContext, "ブランド5", new[] { "Burando_cd4" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm4 = (string)resultHash["BURANDO_NMK"];
					}
				}

				f01VO.Burando_nm5 = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd5))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd5, facadeContext, "ブランド6", new[] { "Burando_cd5" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm5 = (string)resultHash["BURANDO_NMK"];
					}
				}

				f01VO.Burando_nm6 = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd6))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd6, facadeContext, "ブランド7", new[] { "Burando_cd6" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm6 = (string)resultHash["BURANDO_NMK"];
					}
				}

				f01VO.Burando_nm7 = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd7))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd7, facadeContext, "ブランド8", new[] { "Burando_cd7" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm7 = (string)resultHash["BURANDO_NMK"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連チェック

				// 4-1 ブランドコード
				// 入力されたブランドコード(～7)に重複があった場合、エラー
				string[] errlist = new string[8] {"","","","","","","",""};
				int iErrF = 0;
				// ブランドコード1
				if (!string.IsNullOrEmpty(f01VO.Burando_cd))
				{
					if (f01VO.Burando_cd.Equals(f01VO.Burando_cd1)
						|| f01VO.Burando_cd.Equals(f01VO.Burando_cd2)
						|| f01VO.Burando_cd.Equals(f01VO.Burando_cd3)
						|| f01VO.Burando_cd.Equals(f01VO.Burando_cd4)
						|| f01VO.Burando_cd.Equals(f01VO.Burando_cd5)
						|| f01VO.Burando_cd.Equals(f01VO.Burando_cd6)
						|| f01VO.Burando_cd.Equals(f01VO.Burando_cd7))
					{
						iErrF = 1;
						errlist.SetValue("Burando_cd", 0);
					}
				}

				// ブランドコード2
				if (!string.IsNullOrEmpty(f01VO.Burando_cd1))
				{
					if (f01VO.Burando_cd1.Equals(f01VO.Burando_cd)
						|| f01VO.Burando_cd1.Equals(f01VO.Burando_cd2)
						|| f01VO.Burando_cd1.Equals(f01VO.Burando_cd3)
						|| f01VO.Burando_cd1.Equals(f01VO.Burando_cd4)
						|| f01VO.Burando_cd1.Equals(f01VO.Burando_cd5)
						|| f01VO.Burando_cd1.Equals(f01VO.Burando_cd6)
						|| f01VO.Burando_cd1.Equals(f01VO.Burando_cd7))
					{
						iErrF = 1;
						errlist.SetValue("Burando_cd1", 1);
					}
				}

				// ブランドコード3
				if (!string.IsNullOrEmpty(f01VO.Burando_cd2))
				{
					if (f01VO.Burando_cd2.Equals(f01VO.Burando_cd)
						|| f01VO.Burando_cd2.Equals(f01VO.Burando_cd1)
						|| f01VO.Burando_cd2.Equals(f01VO.Burando_cd3)
						|| f01VO.Burando_cd2.Equals(f01VO.Burando_cd4)
						|| f01VO.Burando_cd2.Equals(f01VO.Burando_cd5)
						|| f01VO.Burando_cd2.Equals(f01VO.Burando_cd6)
						|| f01VO.Burando_cd2.Equals(f01VO.Burando_cd7))
					{
						iErrF = 1;
						errlist.SetValue("Burando_cd2", 2);
					}
				}

				// ブランドコード4
				if (!string.IsNullOrEmpty(f01VO.Burando_cd3))
				{
					if (f01VO.Burando_cd3.Equals(f01VO.Burando_cd)
						|| f01VO.Burando_cd3.Equals(f01VO.Burando_cd1)
						|| f01VO.Burando_cd3.Equals(f01VO.Burando_cd2)
						|| f01VO.Burando_cd3.Equals(f01VO.Burando_cd4)
						|| f01VO.Burando_cd3.Equals(f01VO.Burando_cd5)
						|| f01VO.Burando_cd3.Equals(f01VO.Burando_cd6)
						|| f01VO.Burando_cd3.Equals(f01VO.Burando_cd7))
					{
						iErrF = 1;
						errlist.SetValue("Burando_cd3", 3);
					}
				}

				// ブランドコード5
				if (!string.IsNullOrEmpty(f01VO.Burando_cd4))
				{
					if (f01VO.Burando_cd4.Equals(f01VO.Burando_cd)
						|| f01VO.Burando_cd4.Equals(f01VO.Burando_cd1)
						|| f01VO.Burando_cd4.Equals(f01VO.Burando_cd2)
						|| f01VO.Burando_cd4.Equals(f01VO.Burando_cd3)
						|| f01VO.Burando_cd4.Equals(f01VO.Burando_cd5)
						|| f01VO.Burando_cd4.Equals(f01VO.Burando_cd6)
						|| f01VO.Burando_cd4.Equals(f01VO.Burando_cd7))
					{
						iErrF = 1;
						errlist.SetValue("Burando_cd4", 4);
					}
				}

				// ブランドコード6
				if (!string.IsNullOrEmpty(f01VO.Burando_cd5))
				{
					if (f01VO.Burando_cd5.Equals(f01VO.Burando_cd)
						|| f01VO.Burando_cd5.Equals(f01VO.Burando_cd1)
						|| f01VO.Burando_cd5.Equals(f01VO.Burando_cd2)
						|| f01VO.Burando_cd5.Equals(f01VO.Burando_cd3)
						|| f01VO.Burando_cd5.Equals(f01VO.Burando_cd4)
						|| f01VO.Burando_cd5.Equals(f01VO.Burando_cd6)
						|| f01VO.Burando_cd5.Equals(f01VO.Burando_cd7))
					{
						iErrF = 1;
						errlist.SetValue("Burando_cd5", 5);
					}
				}

				// ブランドコード7
				if (!string.IsNullOrEmpty(f01VO.Burando_cd6))
				{
					if (f01VO.Burando_cd6.Equals(f01VO.Burando_cd)
						|| f01VO.Burando_cd6.Equals(f01VO.Burando_cd1)
						|| f01VO.Burando_cd6.Equals(f01VO.Burando_cd2)
						|| f01VO.Burando_cd6.Equals(f01VO.Burando_cd3)
						|| f01VO.Burando_cd6.Equals(f01VO.Burando_cd4)
						|| f01VO.Burando_cd6.Equals(f01VO.Burando_cd5)
						|| f01VO.Burando_cd6.Equals(f01VO.Burando_cd7))
					{
						iErrF = 1;
						errlist.SetValue("Burando_cd6", 6);
					}
				}

				// ブランドコード8
				if (!string.IsNullOrEmpty(f01VO.Burando_cd7))
				{
					if (f01VO.Burando_cd7.Equals(f01VO.Burando_cd)
						|| f01VO.Burando_cd7.Equals(f01VO.Burando_cd1)
						|| f01VO.Burando_cd7.Equals(f01VO.Burando_cd2)
						|| f01VO.Burando_cd7.Equals(f01VO.Burando_cd3)
						|| f01VO.Burando_cd7.Equals(f01VO.Burando_cd4)
						|| f01VO.Burando_cd7.Equals(f01VO.Burando_cd5)
						|| f01VO.Burando_cd7.Equals(f01VO.Burando_cd6))
					{
						iErrF = 1;
						errlist.SetValue("Burando_cd7", 7);
					}
				}

				// 重複が一件でもあった場合エラー
				if (iErrF == 1)
				{
					ErrMsgCls.AddErrMsg("E207", string.Empty, facadeContext, errlist);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 入力値チェック(明細)

				for (int i = 0; i < m1List.Count; i++)
				{
					Tj190f02M1Form f02m1VO = (Tj190f02M1Form)m1List[i];
					// ※スキャンコードが入力されている行がチェック対象
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
					{
						// 5-1 Ｍ１スキャンコード
						// 他の明細行と、Ｍ１スキャンコードが重複した場合エラー
						for (int j = 0; j < m1List.Count; j++)
						{
							if (i == j)
							{
								// 自身は対象外
								continue;
							}

							Tj190f02M1Form m1form2VO = (Tj190f02M1Form)m1List[j];
							if (!string.IsNullOrEmpty(m1form2VO.M1scan_cd))
							{
								if (f02m1VO.M1scan_cd.Equals(m1form2VO.M1scan_cd))
								{
									ErrMsgCls.AddErrMsg("E157",
														String.Empty,
														facadeContext,
														new[] { "M1scan_cd"},
														f02m1VO.M1rowno,
														(i).ToString(),
														"M1");
									break;
								}
							}
						}

						// 5-2 Ｍ１実棚数
						// 未入力の場合、エラー
						if (string.IsNullOrEmpty(f02m1VO.M1jitana_su)) 
						{
							ErrMsgCls.AddErrMsg("E121",
												"実棚数",
												facadeContext,
												new[] { "M1jitana_su" },
												f02m1VO.M1rowno,
												(i).ToString(),
												"M1");
						}

						// 5-3 Ｍ１実棚数
						// 0が入力された場合、エラー
						if ("0".Equals(f02m1VO.M1jitana_su))
						{
							ErrMsgCls.AddErrMsg("E103",
												"実棚数",
												facadeContext,
												new[] { "M1jitana_su" },
												f02m1VO.M1rowno,
												(i).ToString(),
												"M1");
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region マスタチェック(明細)

				for (int i = 0; i < m1List.Count; i++)
				{
					Tj190f02M1Form f02m1VO = (Tj190f02M1Form)m1List[i];
					// ※スキャンコードが入力されている行がチェック対象
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
					{
						// 6-1 Ｍ１スキャンコード
						// 発注MSTに存在しない場合、エラー

						SearchHachuVO searchConditionVO = new SearchHachuVO(
							f02m1VO.M1scan_cd,		// スキャンコード
							f01VO.Tenpo_cd_hdn,		// 店舗コード
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

						if (syohinData != null)
						{
							// 発注マスタ検索値をフォームビーン再設定
							f02m1VO.M1hinsyu_ryaku_nm = (string)syohinData["HINSYU_RYAKU_NM"];									// Ｍ１品種略名称
							f02m1VO.M1burando_nm = (string)syohinData["BURANDO_NMK"].ToString();								// Ｍ１ブランド名
							f02m1VO.M1jisya_hbn = (string)syohinData["XEBIO_CD"].ToString();									// Ｍ１自社品番
							f02m1VO.M1maker_hbn = (string)syohinData["HIN_NBR"].ToString();										// Ｍ１メーカー品番
							f02m1VO.M1syonmk = (string)syohinData["SYONMK"].ToString();											// Ｍ１商品名(カナ)
							f02m1VO.M1iro_nm = (string)syohinData["IRO_NM"].ToString();											// Ｍ１色
							f02m1VO.M1size_nm = (string)syohinData["SIZE_NM"].ToString();										// Ｍ１サイズ
							f02m1VO.M1scan_cd = (string)syohinData["JAN_CD"].ToString();										// Ｍ１スキャンコード
							f02m1VO.M1hyoka_tnk = (string)syohinData["HYOKA_TNK"].ToString();									// Ｍ１評価単価
							f02m1VO.M1tanajityobo_su = (string)syohinData["TYOBOZAIKO_SU"].ToString();							// Ｍ１棚時帳簿数
							f02m1VO.M1tanajisekiso_su = (string)syohinData["SEKISO_SU"].ToString();								// Ｍ１棚時積送数

							// Dictionary（更新用）
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1BUMON_CD] = syohinData["BUMON_CD"].ToString();			// 部門コード
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1HINSYU_CD] = syohinData["HINSYU_CD"].ToString();			// 品種コード
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD] = syohinData["BURANDO_CD"].ToString();		// ブランドコード
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1OLD_XEBIO_CD] = syohinData["OLD_XEBIO_CD"].ToString();	// 旧自社品番
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1MAKERCOLOR_CD] = syohinData["MAKERCOLOR_CD"].ToString();	// 色コード
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1SIZE_CD] = syohinData["SIZE_CD"].ToString();				// サイズコード
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1SYOHIN_CD] = syohinData["SYOHIN_CD"].ToString();			// 商品コード
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1SLPR] = syohinData["SLPR"].ToString();					// 上代１(現売価)
							f02m1VO.Dictionary[Tj190p01Constant.DIC_M1JODAI2_TNK] = syohinData["JODAI2_TNK"].ToString();		// 上代２(メーカー単価)

							// チェック用変数退避
							string sChkBumon_cd = syohinData["BUMON_CD"].ToString();
							string sChkHinsyu_cd = BoSystemFormat.formatHinsyuCd(syohinData["HINSYU_CD"].ToString());
							string sChkBurando_cd = syohinData["BURANDO_CD"].ToString();

							// 6-2 Ｍ１スキャンコード
							// 品種指定が選択され、品種が異なる場合、エラー
							if (ConditionHinsyu_sitei_flg.VALUE_HINSYU_SITEI_FLG2.Equals(f01VO.Hinsyu_sitei_flg))
							{
								if (!f01VO.Bumon_cd_bo.Equals(sChkBumon_cd) || (f01VO.Bumon_cd_bo.Equals(sChkBumon_cd) && !f01VO.Hinsyu_cd.Equals(sChkHinsyu_cd)))
								{
									ErrMsgCls.AddErrMsg("E127",
														String.Empty,
														facadeContext,
														new[] { "M1scan_cd"},
														f02m1VO.M1rowno,
														(i).ToString(),
														"M1");
								}
							}

							
							// 6-3 Ｍ１スキャンコード
							// ブランド指定が選択され、ブランドが異なる場合、エラー
							if (ConditionBurando_sitei_flg.VALUE_BURANDO_SITEI_FLG2.Equals(f01VO.Burando_sitei_flg))
							{
								// いずれかが一致すれば正常
								if ((BoSystemFormat.formatBrandCd(f01VO.Burando_cd).Equals(sChkBurando_cd))
								|| (BoSystemFormat.formatBrandCd(f01VO.Burando_cd1).Equals(sChkBurando_cd))
								|| (BoSystemFormat.formatBrandCd(f01VO.Burando_cd2).Equals(sChkBurando_cd))
								|| (BoSystemFormat.formatBrandCd(f01VO.Burando_cd3).Equals(sChkBurando_cd))
								|| (BoSystemFormat.formatBrandCd(f01VO.Burando_cd4).Equals(sChkBurando_cd))
								|| (BoSystemFormat.formatBrandCd(f01VO.Burando_cd5).Equals(sChkBurando_cd))
								|| (BoSystemFormat.formatBrandCd(f01VO.Burando_cd6).Equals(sChkBurando_cd))
								|| (BoSystemFormat.formatBrandCd(f01VO.Burando_cd7).Equals(sChkBurando_cd)))
								{
								}
								else
								{
									ErrMsgCls.AddErrMsg("E128",
														String.Empty,
														facadeContext,
														new[] { "M1scan_cd" },
														f02m1VO.M1rowno,
														(i).ToString(),
														"M1");
								}
							}

							// 6-4 Ｍ１スキャンコード
							// 指定した部門、品種、ブランドに一致しない商品が存在する場合、エラー
							if (!f01VO.Bumon_cd_bo.Equals(sChkBumon_cd))
							{
								ErrMsgCls.AddErrMsg("E150",
													String.Empty,
													facadeContext,
													new[] { "M1scan_cd" },
													f02m1VO.M1rowno,
													(i).ToString(),
													"M1");
								f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_MEISAI_ERROR;	// Ｍ１明細色区分(隠し)
								f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;		// 確定処理フラグ
							}
						}
					}
				}// for

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック

				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
				sRepSql.Append(" AND RINTANA_KANRI_NO = :BIND_RINTANA_KANRI_NO");
				sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD ");

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_hdn);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 臨棚管理№
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_RINTANA_KANRI_NO";
				bindVO.Value = BoSystemString.Nvl(f01VO.Rintana_kanri_no,"0");
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 処理日付
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Dictionary[Tj190p01Constant.DIC_SYORI_YMD].ToString());
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 排他チェック
				V03003Check.CheckHaitaMaxVal(
						Convert.ToDecimal((string)f01VO.Dictionary[Tj190p01Constant.DIC_M1UPD_YMD]),
						Convert.ToDecimal((string)f01VO.Dictionary[Tj190p01Constant.DIC_M1UPD_TM]),
						facadeContext,
						"MDIT0120",
						sRepSql.ToString(),
						bindList,
						1,
						null,
						null,
						null,
						null,
						0
				);

				#endregion

				#endregion

				#region 更新処理

				// [臨時棚卸TBL(B)]を削除する。
				BoSystemLog.logOut("[臨時棚卸TBL(B)]を削除 START");
				int Delcnt = Del_Rintanab(facadeContext, f01VO, logininfo);
				BoSystemLog.logOut("[臨時棚卸TBL(B)]を削除 END");

				// [臨時棚卸TBL(B)]を登録する。
				BoSystemLog.logOut("[臨時棚卸TBL(B)]を登録 START");
				int Inscnt = Ins_Rintanab(facadeContext, f01VO, logininfo);
				BoSystemLog.logOut("[臨時棚卸TBL(B)]を登録 END");

				// [臨時棚卸TBL(H)]を更新する。
				BoSystemLog.logOut("[臨時棚卸TBL(H)]を更新 START");
				int Updcnt = Upd_Rintanah(facadeContext, f01VO, logininfo, sysDateVO);
				BoSystemLog.logOut("[臨時棚卸TBL(H)]を更新 END");

				#endregion

				#region 画面表示
				// ヘッダ情報を更新する。

				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;							// 確定処理フラグ
				f01M1Form.M1hinsyu_ryaku_nm = f01VO.Hinsyu_ryaku_nm;										// Ｍ１品種略名称
				f01M1Form.M1burando_nm1 = f01VO.Burando_nm;													// Ｍ１ブランド名1
				f01M1Form.M1burando_nm2 = f01VO.Burando_nm1;												// Ｍ１ブランド名2
				f01M1Form.M1burando_nm3 = f01VO.Burando_nm2;												// Ｍ１ブランド名3
				f01M1Form.M1burando_nm4 = f01VO.Burando_nm3;												// Ｍ１ブランド名4
				f01M1Form.M1burando_nm5 = f01VO.Burando_nm4;												// Ｍ１ブランド名5
				f01M1Form.M1burando_nm6 = f01VO.Burando_nm5;												// Ｍ１ブランド名6
				f01M1Form.M1burando_nm7 = f01VO.Burando_nm6;												// Ｍ１ブランド名7
				f01M1Form.M1burando_nm8 = f01VO.Burando_nm7;												// Ｍ１ブランド名8
				f01M1Form.M1tanajityobo_su = f01VO.Gokeitanajityobo_su;										// Ｍ１棚時帳簿数
				f01M1Form.M1tanajisekiso_su = f01VO.Gokeitanajisekiso_su;									// Ｍ１棚時積送数
				f01M1Form.M1jitana_su = f01VO.Gokeijitana_su;												// Ｍ１実棚数
				f01M1Form.M1loss_su = f01VO.Gokeiloss_su;													// Ｍ１ロス数
				f01M1Form.M1loss_kin = f01VO.Gokeiloss_kin;													// Ｍ１ロス金額
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;							// Ｍ１確定処理フラグ(隠し)

				// Dictionaryの設定
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1UPD_YMD] = sysDateVO.Sysdate.ToString();		// Ｍ１更新日
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1UPD_TM] = sysDateVO.Systime_mili.ToString();	// Ｍ１更新時間
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1HINSYU_SITEI_FLG] = f01VO.Hinsyu_sitei_flg;		// Ｍ１品種指定フラグ
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1HINSYU_CD] = f01VO.Hinsyu_cd;					// Ｍ１品種コード
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_SITEI_FLG] = f01VO.Burando_sitei_flg;	// Ｍ１ブランド指定フラグ
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD] = f01VO.Burando_cd;					// Ｍ１ブランドコード
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD1] = f01VO.Burando_cd1;				// Ｍ１ブランドコード1
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD2] = f01VO.Burando_cd2;				// Ｍ１ブランドコード2
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD3] = f01VO.Burando_cd3;				// Ｍ１ブランドコード3
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD4] = f01VO.Burando_cd4;				// Ｍ１ブランドコード4
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD5] = f01VO.Burando_cd5;				// Ｍ１ブランドコード5
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD6] = f01VO.Burando_cd6;				// Ｍ１ブランドコード6
				f01M1Form.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD7] = f01VO.Burando_cd7;				// Ｍ１ブランドコード7

				// 一覧画面の合計項目最新化
				Tj190f01Form form1VO = (Tj190f01Form)f01VO.Dictionary[Tj190p01Constant.DIC_M1VO];
				IDataList form1m1List = form1VO.GetList("M1");
				Decimal dGokeitanajityobo_su = 0;
				Decimal dGokeitanajisekiso_su = 0;
				Decimal dGokeijitana_su = 0;
				Decimal dGokeiloss_su = 0;
				Decimal dGokeiloss_kin = 0;
				for (int i = 0; i < form1m1List.Count; i++)
				{
					Tj190f01M1Form f01m1VO = (Tj190f01M1Form)form1m1List[i];

					// Ｍ１棚時帳簿数の合計
					dGokeitanajityobo_su += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tanajityobo_su, "0"));
					// Ｍ１棚時積送数の合計
					dGokeitanajisekiso_su += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tanajisekiso_su, "0"));
					// Ｍ１実棚数の合計
					dGokeijitana_su += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1jitana_su, "0"));
					// Ｍ１ロス数の合計
					dGokeiloss_su += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1loss_su, "0"));
					// Ｍ１ロス金額の合計
					dGokeiloss_kin += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1loss_kin, "0"));

				}

				// 合計棚時帳簿数
				form1VO.Gokeitanajityobo_su = dGokeitanajityobo_su.ToString();
				// 合計棚時積送数
				form1VO.Gokeitanajisekiso_su = dGokeitanajisekiso_su.ToString();
				// 合計実棚数
				form1VO.Gokeijitana_su = dGokeijitana_su.ToString();
				// 合計ロス数
				form1VO.Gokeiloss_su = dGokeiloss_su.ToString();
				// 合計ロス金額
				form1VO.Gokeiloss_kin = dGokeiloss_kin.ToString();

				#endregion

				//以下に業務ロジックを記述する。
			
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

		#region ユーザー定義関数

		#region [臨時棚卸TBL(B)]を削除する。
		/// <summary>
		/// [臨時棚卸TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_Rintanab(IFacadeContext facadeContext,
									Tj190f02Form f02Form,
									LoginInfoVO loginInfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_07, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(f02Form.Tenpo_cd_hdn));
			// 臨棚管理No
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_KANRI_NO, Convert.ToDecimal(BoSystemString.Nvl(f02Form.Rintana_kanri_no, "0")));
			// 処理日付
			reader.BindValue(Tj190p01Constant.SQL_ID_06_BIND_SYORI_YMD, Convert.ToDecimal(BoSystemString.Nvl((string)f02Form.Dictionary[Tj190p01Constant.DIC_SYORI_YMD], "0")));


			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [臨時棚卸TBL(B)]を登録する。
		/// <summary>
		/// [臨時棚卸TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Ins_Rintanab(IFacadeContext facadeContext, Tj190f02Form f02VO, LoginInfoVO loginInfo)
		{
			int iRownum = 0;
			IDataList m1List = f02VO.GetList("M1");

			String stenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd_hdn);								// 店舗コード
			decimal dkanri_no = Convert.ToDecimal(BoSystemString.Nvl(f02VO.Rintana_kanri_no, "0"));				// 臨棚管理№
			decimal dsyori_ymd = Convert.ToDecimal(BoSystemString.Nvl((string)f02VO.Dictionary[Tj190p01Constant.DIC_SYORI_YMD], "0"));	// 処理日付
			decimal dsyori_tm = Convert.ToDecimal(BoSystemString.Nvl((string)f02VO.Dictionary[Tj190p01Constant.DIC_SYORI_TM], "0"));	// 処理時間


			// Oracleコマンドの生成
			OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
			// トランザクションの設定
			command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
			// SQLの実行タイプ
			command.CommandType = CommandType.Text;


			IList<Mdrt0011VO> insertBodyList = new List<Mdrt0011VO>();	// 更新データリスト

			// パラメータバインド処理
			IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();
			int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）

			for (int i = 0; i < m1List.Count; i++)
			{
				Tj190f02M1Form f02m1VO = (Tj190f02M1Form)m1List[i];
				// スキャンコードが入力されている行が対象
				if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
				{
					counter++;
					iRownum++;

					Dictionary<string, string> bindDic = new Dictionary<string, string>();

					// 店舗コード
					BoSystemDb.setInsertVal("TENPO_CD", iRownum.ToString(), stenpo_cd, ref bindDic, ref command);
					// 臨棚管理№
					BoSystemDb.setInsertVal("RINTANA_KANRI_NO", iRownum.ToString(), dkanri_no, ref bindDic, ref command);
					// 処理日付
					BoSystemDb.setInsertVal("SYORI_YMD", iRownum.ToString(), dsyori_ymd, ref bindDic, ref command);
					// 処理時間
					BoSystemDb.setInsertVal("SYORI_TM", iRownum.ToString(), dsyori_tm, ref bindDic, ref command);
					// 行№
					BoSystemDb.setInsertVal("GYO_NO", iRownum.ToString(), iRownum, ref bindDic, ref command);
					// 部門コード
					BoSystemDb.setInsertVal("BUMON_CD", iRownum.ToString(), BoSystemFormat.formatBumonCd(f02m1VO.Dictionary[Tj190p01Constant.DIC_M1BUMON_CD].ToString()), ref bindDic, ref command);
					// 品種コード
					BoSystemDb.setInsertVal("HINSYU_CD", iRownum.ToString(), BoSystemFormat.formatHinsyuCd(f02m1VO.Dictionary[Tj190p01Constant.DIC_M1HINSYU_CD].ToString()), ref bindDic, ref command);
					// ブランドコード
					BoSystemDb.setInsertVal("BURANDO_CD", iRownum.ToString(), BoSystemFormat.formatBrandCd(f02m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD].ToString()), ref bindDic, ref command);
					// 自社品番
					BoSystemDb.setInsertVal("JISYA_HBN", iRownum.ToString(), f02m1VO.M1jisya_hbn, ref bindDic, ref command);
					// 旧自社品番
					BoSystemDb.setInsertVal("OLD_JISYA_HBN", iRownum.ToString(), f02m1VO.Dictionary[Tj190p01Constant.DIC_M1OLD_XEBIO_CD].ToString(), ref bindDic, ref command);
					// メーカー品番
					BoSystemDb.setInsertVal("MAKER_HBN", iRownum.ToString(), f02m1VO.M1maker_hbn, ref bindDic, ref command);
					// 商品名(カナ)
					BoSystemDb.setInsertVal("SYONMK", iRownum.ToString(), f02m1VO.M1syonmk, ref bindDic, ref command);
					// 色コード
					BoSystemDb.setInsertVal("IRO_CD", iRownum.ToString(), BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tj190p01Constant.DIC_M1MAKERCOLOR_CD].ToString()), ref bindDic, ref command);
					// サイズコード
					BoSystemDb.setInsertVal("SIZE_CD", iRownum.ToString(), BoSystemFormat.formatSizeCd(f02m1VO.Dictionary[Tj190p01Constant.DIC_M1SIZE_CD].ToString()), ref bindDic, ref command);
					// サイズ
					BoSystemDb.setInsertVal("SIZE_NM", iRownum.ToString(), f02m1VO.M1size_nm, ref bindDic, ref command);
					// ＪＡＮコード
					BoSystemDb.setInsertVal("JAN_CD", iRownum.ToString(), BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd), ref bindDic, ref command);
					// 商品コード
					BoSystemDb.setInsertVal("SYOHIN_CD", iRownum.ToString(), f02m1VO.Dictionary[Tj190p01Constant.DIC_M1SYOHIN_CD].ToString(), ref bindDic, ref command);
					// 上代１
					BoSystemDb.setInsertVal("SLPR", iRownum.ToString(), f02m1VO.Dictionary[Tj190p01Constant.DIC_M1SLPR].ToString(), ref bindDic, ref command);
					// 上代２
					BoSystemDb.setInsertVal("JODAI2_TNK", iRownum.ToString(), f02m1VO.Dictionary[Tj190p01Constant.DIC_M1JODAI2_TNK].ToString(), ref bindDic, ref command);
					// 評価単価
					BoSystemDb.setInsertVal("HYOKA_TNK", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1hyoka_tnk, "0")), ref bindDic, ref command);
					// 棚時帳簿数
					BoSystemDb.setInsertVal("TANAJITYOBO_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1tanajityobo_su, "0")), ref bindDic, ref command);
					// 棚時積送数
					BoSystemDb.setInsertVal("TANAJISEKISO_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1tanajisekiso_su, "0")), ref bindDic, ref command);
					// 実棚数
					BoSystemDb.setInsertVal("JITANA_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1jitana_su, "0")), ref bindDic, ref command);
					// ロス数
					BoSystemDb.setInsertVal("LOSS_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1loss_su, "0")), ref bindDic, ref command);
					// ロス金額
					BoSystemDb.setInsertVal("LOSS_KIN", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1loss_kin, "0")), ref bindDic, ref command);


					insertBindList.Add(bindDic);

					// 一括処理単位に達した場合は、マルチインサートを実行
					if (counter == 20)
					{
						// カウンタのリセット
						counter = 0;

						// マルチインサートの実行
						command.CommandText = GetSqlMultiInsT_Rinjitanaorosib(insertBindList);
						command.ExecuteNonQuery();

						// 配列、バインドパラメータのクリア
						insertBindList.Clear();
						command.Parameters.Clear();
					}
				}

			}// for

			// 未登録レコードの登録
			if (counter > 0)
			{
				// マルチインサートの実行
				command.CommandText = GetSqlMultiInsT_Rinjitanaorosib(insertBindList);
				command.ExecuteNonQuery();
			}

			return iRownum;
		}
		#endregion

		#region [臨時棚卸TBL(B)]へのマルチインサート文作成。
		/// <summary>
		/// [臨時棚卸TBL(B)]へのマルチインサートを行うSQL文を取得する。
		/// </summary>
		/// <param name="insertBindList">バインドテキスト</param>
		private string GetSqlMultiInsT_Rinjitanaorosib(IList<Dictionary<string, string>> insertBindList)
		{
			IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

			// バインドテキストのデータ分INSERT文を作成
			foreach (Dictionary<string, string> bindDic in insertBindList)
			{
				StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文
				insertSql.Append("    INTO MDIT0121 VALUES ( ");
				insertSql.Append(bindDic["TENPO_CD"]).Append(" , ");
				insertSql.Append(bindDic["RINTANA_KANRI_NO"]).Append(" , ");
				insertSql.Append(bindDic["SYORI_YMD"]).Append(" , ");
				insertSql.Append(bindDic["SYORI_TM"]).Append(" , ");
				insertSql.Append(bindDic["GYO_NO"]).Append(" , ");
				insertSql.Append(bindDic["BUMON_CD"]).Append(" , ");
				insertSql.Append(bindDic["HINSYU_CD"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD"]).Append(" , ");
				insertSql.Append(bindDic["JISYA_HBN"]).Append(" , ");
				insertSql.Append(bindDic["OLD_JISYA_HBN"]).Append(" , ");
				insertSql.Append(bindDic["MAKER_HBN"]).Append(" , ");
				insertSql.Append(bindDic["SYONMK"]).Append(" , ");
				insertSql.Append(bindDic["IRO_CD"]).Append(" , ");
				insertSql.Append(bindDic["SIZE_CD"]).Append(" , ");
				insertSql.Append(bindDic["SIZE_NM"]).Append(" , ");
				insertSql.Append(bindDic["JAN_CD"]).Append(" , ");
				insertSql.Append(bindDic["SYOHIN_CD"]).Append(" , ");
				insertSql.Append(bindDic["SLPR"]).Append(" , ");
				insertSql.Append(bindDic["JODAI2_TNK"]).Append(" , ");
				insertSql.Append(bindDic["HYOKA_TNK"]).Append(" , ");
				insertSql.Append(bindDic["TANAJITYOBO_SU"]).Append(" , ");
				insertSql.Append(bindDic["TANAJISEKISO_SU"]).Append(" , ");
				insertSql.Append(bindDic["JITANA_SU"]).Append(" , ");
				insertSql.Append(bindDic["LOSS_SU"]).Append(" , ");
				insertSql.Append(bindDic["LOSS_KIN"]);
				insertSql.Append(" ) ");

				insertSqlList.Add(insertSql.ToString());
			}

			// 単一INSERTをまとめて、マルチインサート文を作成
			StringBuilder sql = new StringBuilder();
			sql.AppendLine("INSERT ALL");
			foreach (string sqlpart in insertSqlList)
			{
				sql.AppendLine(sqlpart);
			}
			sql.AppendLine("SELECT 1 FROM DUAL");
			BoSystemLog.logOut("[臨時棚卸TBL(B)]へのマルチインサート。 sql:" + sql.ToString());


			return sql.ToString();
		}
		#endregion

		#region [臨時棚卸TBL(H)]を更新する。
		/// <summary>
		/// [臨時棚卸TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Upd_Rintanah(IFacadeContext facadeContext,
									Tj190f02Form f02Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 品種指定フラグ
			reader.BindValue("BIND_HINSYU_SITEI_FLG", Convert.ToDecimal(BoSystemString.Nvl(f02Form.Hinsyu_sitei_flg, "0")));
			reader.BindValue("BIND_HINSYU_SITEI_FLG_2", Convert.ToDecimal(BoSystemString.Nvl(f02Form.Hinsyu_sitei_flg, "0")));
			// 品種コード
			if (!string.IsNullOrEmpty(f02Form.Hinsyu_cd))
			{
				reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(f02Form.Hinsyu_cd));
			}
			else
			{
				reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(BoSystemString.Nvl(f02Form.Hinsyu_cd, "0")));
			}
			// ブランド指定フラグ
			reader.BindValue("BIND_BURANDO_SITEI_FLG", Convert.ToDecimal(BoSystemString.Nvl(f02Form.Burando_sitei_flg, "0")));
			// ブランドコード1
			reader.BindValue("BIND_BURANDO_CD1", BoSystemFormat.formatBrandCd(f02Form.Burando_cd));
			// ブランドコード2
			reader.BindValue("BIND_BURANDO_CD2", BoSystemFormat.formatBrandCd(f02Form.Burando_cd1));
			// ブランドコード3
			reader.BindValue("BIND_BURANDO_CD3", BoSystemFormat.formatBrandCd(f02Form.Burando_cd2));
			// ブランドコード4
			reader.BindValue("BIND_BURANDO_CD4", BoSystemFormat.formatBrandCd(f02Form.Burando_cd3));
			// ブランドコード5
			reader.BindValue("BIND_BURANDO_CD5", BoSystemFormat.formatBrandCd(f02Form.Burando_cd4));
			// ブランドコード6
			reader.BindValue("BIND_BURANDO_CD6", BoSystemFormat.formatBrandCd(f02Form.Burando_cd5));
			// ブランドコード7
			reader.BindValue("BIND_BURANDO_CD7", BoSystemFormat.formatBrandCd(f02Form.Burando_cd6));
			// ブランドコード8
			reader.BindValue("BIND_BURANDO_CD8", BoSystemFormat.formatBrandCd(f02Form.Burando_cd7));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Tenpo_cd_hdn));
			// 管理No
			reader.BindValue("BIND_RINTANA_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl(f02Form.Rintana_kanri_no, "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f02Form.Dictionary[Tj190p01Constant.DIC_SYORI_YMD], "0")));



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
