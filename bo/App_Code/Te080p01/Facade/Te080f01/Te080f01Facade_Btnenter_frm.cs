using com.xebio.bo.Te080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01025;
using Common.Business.C01000.C01027;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01006;
using Common.Business.V01000.V01015;
using Common.Business.V01000.V01026;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Te080p01.Facade
{
  /// <summary>
  /// Te080f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te080f01Facade : StandardBaseFacade
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
				Te080f01Form f01VO = (Te080f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 件数チェック
				// 1-1 入力件数
				//       Ｍ１SCM/伝票コードが1件も入力されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[i];

						if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 確定対象がありません。
						ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 単項目チェック（カード部）

				// 2-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
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

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 単項目チェック（明細部）

				for (int i = 0; i < m1List.Count; i++)
				{
					Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[i];

					// 会社、出荷店以外を初期化する
					f01m1VO.M1tenpolc_kbn_hdn = string.Empty;	// Ｍ１店舗ＬＣ区分(隠し)
					f01m1VO.M1scm_cd = string.Empty;			// Ｍ１SCMコード
					f01m1VO.M1denpyo_bango = string.Empty;		// Ｍ１伝票番号
					f01m1VO.M1syukka_ymd = string.Empty;		// Ｍ１出荷日
					f01m1VO.M1yotei_su = string.Empty;			// Ｍ１予定数量
					f01m1VO.M1kyakucyu = string.Empty;			// Ｍ１客注
					f01m1VO.M1negaki = string.Empty;			// Ｍ１値書

					// SCM／伝票番号を編集する
					if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd))
					{
						// 6桁以内(伝票番号)の場合、6桁にゼロ埋めする
						if (f01m1VO.M1scmden_cd.Length < 6)
						{
							string denpyo_bango = "000000" + f01m1VO.M1scmden_cd;
							f01m1VO.M1scmden_cd = denpyo_bango.Substring(denpyo_bango.Length - 6, 6);
						}
						else
						{
							// 14桁(SCMコード)で先頭5桁が"00918"の場合、先頭6桁をゼロ埋めする
							f01m1VO.M1scmden_cd = BoSystemFormat.formatScmCd(f01m1VO.M1scmden_cd);
						}
					}

					// 3-1 Ｍ１会社コード
					//       Ｍ１SCM/伝票コードに6桁の伝票番号が入力されて、Ｍ１会社コードが未入力の場合、エラー
					if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd) && f01m1VO.M1scmden_cd.Length <= 6)
					{
						if (string.IsNullOrEmpty(f01m1VO.M1kaisya_cd))
						{
							ErrMsgCls.AddErrMsg("E121", "会社", facadeContext, new[] { "M1kaisya_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						}
					}

					// 3-2 Ｍ１会社コード
					//       名称マスタ(識別コード＝'KASY')を検索し、存在しない場合エラー
					f01m1VO.M1kaisya_nm = string.Empty;
					if (!string.IsNullOrEmpty(f01m1VO.M1kaisya_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01006Check.CheckKaisya(f01m1VO.M1kaisya_cd,
														facadeContext,
														"会社",
														new[] { "M1kaisya_cd" },
														f01m1VO.M1rowno,
														i.ToString(),
														"M1",
														Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));

						// 名称をラベルに設定
						if (resultHash != null)
						{
							f01m1VO.M1kaisya_nm = (string)resultHash["MEISYO_NM"];
						}
					}

					// 3-3 Ｍ１出荷店コード
					//       Ｍ１SCM/伝票コードに6桁の伝票番号が入力されて、Ｍ１出荷店コードが未入力の場合、エラー
					if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd) && f01m1VO.M1scmden_cd.Length <= 6)
					{
						if (string.IsNullOrEmpty(f01m1VO.M1syukkaten_cd))
						{
							ErrMsgCls.AddErrMsg("E121", "出荷店", facadeContext, new[] { "M1syukkaten_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						}
					}

					// 3-4 Ｍ１出荷店コード
					//       店舗マスタを検索し、存在しない場合エラー
					f01m1VO.M1syukkaten_nm = string.Empty;
					if (!string.IsNullOrEmpty(f01m1VO.M1syukkaten_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01026Check.CheckTenpoAll(
							f01m1VO.M1kaisya_cd,
							f01m1VO.M1syukkaten_cd,
							facadeContext,
							"出荷店",
							new[] { "M1syukkaten_cd" },
							f01m1VO.M1rowno,
							i.ToString(),
							"M1",
							Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper()))
							);
						
						// 名称をラベルに設定
						if (resultHash != null)
						{
							f01m1VO.M1syukkaten_nm = (string)resultHash["TENPO_NM"];
						}
					}

					// 3-5 Ｍ１SCM/伝票コード
					//       6桁、14桁、20桁以外の場合、エラー
					if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd))
					{
						if (f01m1VO.M1scmden_cd.Length != 6 && !ScmCodeCls.CheckLength(f01m1VO.M1scmden_cd))
						{
							ErrMsgCls.AddErrMsg("E208", string.Empty, facadeContext, new[] { "M1scmden_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						}
					}

					// 3-6 Ｍ１SCM/伝票コード
					//       14桁か20桁の場合、先頭2桁が "00"、"01"、"02"、"03"、"04"以外ならエラー
					bool scmErr = false;
					if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd)
						&& ScmCodeCls.CheckLength(f01m1VO.M1scmden_cd)
						&& !ScmCodeCls.CheckFormat(f01m1VO.M1scmden_cd))
					{
						ErrMsgCls.AddErrMsg("E209", string.Empty, facadeContext, new[] { "M1scmden_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						scmErr = true;
					}

					// 3-7 Ｍ１SCM/伝票コード
					//       移動入荷予定TBL(H)に存在しない場合、エラー
					if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd) && scmErr == false)
					{
						if (ScmCodeCls.CheckLength(f01m1VO.M1scmden_cd)
							|| (f01m1VO.M1scmden_cd.Length <= 6 && !string.IsNullOrEmpty(f01m1VO.M1kaisya_cd) && !string.IsNullOrEmpty(f01m1VO.M1syukkaten_cd)))
						{
							SearchIdoYoteiVO searchConditionVO = new SearchIdoYoteiVO(
																					f01VO.Head_tenpo_cd,			// 入荷店コード
																					f01m1VO.M1kaisya_cd,			// 出荷会社コード
																					f01m1VO.M1syukkaten_cd,			// 出荷店コード
																					f01m1VO.M1scmden_cd				// SCM/伝票コード
																					);

							string param = "";
							if (f01m1VO.M1scmden_cd.Length <= 6)
							{
								param = "伝票番号";
							}
							else
							{
								param = "SCMコード";
							}

							// 検索
							IList<Hashtable> list = SearchIdoYotei.SearchScmDenpyo(searchConditionVO, facadeContext.DBContext);

							if (list == null || list.Count <= 0)
							{
								ErrMsgCls.AddErrMsg("E111", param, facadeContext, new[] { "M1scmden_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
							}
							else
							{
								// SCMコードに複数伝票存在した場合、チェックする。
								if (list.Count >= 2)
								{
									bool bKaraGyo = false;
									int gyoCnt = 0;

									// 自分より下の行を取得した伝票行数分空き行があるかチェックする。
									for (int j = i; j < m1List.Count; j++)
									{
										Te080f01M1Form chkm1VO = (Te080f01M1Form)m1List[j];
										gyoCnt++;

										// 自分より下の行をチェックする。
										if (j > i)
										{
											// 入力済みの行が存在したらエラーにする。(但し同じSCMコードはエラーにしない)
											if (!string.IsNullOrEmpty(chkm1VO.M1scmden_cd) && !chkm1VO.M1scmden_cd.Equals(searchConditionVO.Scmdencd))
											{
												break;
											}
										}

										// 取得した伝票数分の空行があれば正常
										if (gyoCnt == list.Count)
										{
											bKaraGyo = true;
											break;
										}
									}

									// 空行が無い場合エラー
									if (!bKaraGyo)
									{
										// 複数伝票を追加することができません。
										ErrMsgCls.AddErrMsg("E224", string.Empty, facadeContext, new[] { "M1scmden_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
									}

									//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
									if (MessageDisplayUtil.HasError(facadeContext))
									{
										return;
									}
								}

								for (int j = 0; j < list.Count; j++)
								{
									// 2レコード目以降はメインループのカウンタをアップする
									if (j != 0)
									{
										i++;
									}

									// 画面項目に設定
									Te080f01M1Form setm1VO = (Te080f01M1Form)m1List.GetRowAt(i);
									Hashtable selectht = list[j];

									setm1VO.M1tenpolc_kbn_hdn = selectht["TENPOLC_KBN"].ToString();									// Ｍ１店舗ＬＣ区分(隠し)
									setm1VO.M1kaisya_cd = BoSystemFormat.formatKaisyaCd(selectht["SYUKKAKAISYA_CD"].ToString());	// Ｍ１会社コード
									setm1VO.M1kaisya_nm = selectht["SYUKKAKAISYA_NM"].ToString();									// Ｍ１会社名称
									setm1VO.M1syukkaten_cd = BoSystemFormat.formatTenpoCd(selectht["SYUKKATEN_CD"].ToString());		// Ｍ１出荷店コード
									setm1VO.M1syukkaten_nm = selectht["SYUKKATEN_NM"].ToString();									// Ｍ１出荷店名称

									if (string.IsNullOrEmpty(setm1VO.M1scmden_cd))
									{
										// SCM内に複数伝票あった場合、同じSCMコードを設定する
										setm1VO.M1scmden_cd = BoSystemFormat.formatViewScmCd(searchConditionVO.Scmdencd);			// Ｍ１SCM／伝票番号
										setm1VO.M1entersyoriflg = "1";																// Ｍ１確定処理フラグ(隠し)
									}

									setm1VO.M1scm_cd = BoSystemFormat.formatViewScmCd(selectht["SCM_CD"].ToString());				// Ｍ１SCMコード
									setm1VO.M1denpyo_bango = BoSystemFormat.formatDenpyoNo(selectht["DENPYO_BANGO"].ToString());	// Ｍ１伝票番号
									setm1VO.M1syukka_ymd = selectht["SYUKKA_YMD"].ToString();										// Ｍ１出荷日
									setm1VO.M1yotei_su = selectht["NYUKAYOTEIGOKEI_SU"].ToString();									// Ｍ１予定数量
									setm1VO.M1kyakucyu = selectht["KYAKUCYU"].ToString();											// Ｍ１客注
									setm1VO.M1negaki = selectht["NEGAKI"].ToString();												// Ｍ１値書
								}
							}
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連チェック

				// 4-1 Ｍ１SCM/伝票コード
				//       Ｍ１伝票番号が同じ行が存在した場合、エラー
				for (int i = 0; i < m1List.Count; i++)
				{
					Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[i];

					if (!string.IsNullOrEmpty(f01m1VO.M1denpyo_bango))
					{
						for (int j = 0; j < m1List.Count; j++)
						{
							Te080f01M1Form f01m1VO2 = (Te080f01M1Form)m1List[j];

							if (i != j && f01m1VO.M1denpyo_bango.Equals(f01m1VO2.M1denpyo_bango))
							{
								ErrMsgCls.AddErrMsg("E132", string.Empty, facadeContext, new[] { "M1denpyo_bango" }, f01m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
								break;
							}
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
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

				bool bKakuteizumiAri = false;

				for (int i = 0; i < m1List.Count; i++)
				{
					Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[i];
					if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd))
					{

						// [移動入荷予定TBL(H)]を更新する。
						BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 START");
						int Updcntyoteih = Upd_IdoNyukaYoteiH(facadeContext, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[移動入荷予定TBL(H)]を更新 END");

						// [移動入荷予定TBL(H)]が更新できなかった場合(確定済みだった場合)
						if (Updcntyoteih == 0)
						{
							// 確定済みデータありのメッセージを表示
							// I114「確定済みの伝票が存在しました。」
							bKakuteizumiAri = true;
						}
						else
						{
							// [移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録する。
							BoSystemLog.logOut("[移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録 START");
							int Inscntkakuteih = Ins_IdoNyukaKakuteiH(facadeContext, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録 END");

							// [移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録する。
							BoSystemLog.logOut("[移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録 START");
							int Inscntkakuteib = Ins_IdoNyukaKakuteiB(facadeContext, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録 END");

							// [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録する。
							BoSystemLog.logOut("[移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録 START");
							int Inscntrirekih = Ins_IdoNyukaRirekiH(facadeContext, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録 END");

							// [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録する。
							BoSystemLog.logOut("[移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録 START");
							int Inscntrirekib = Ins_IdoNyukaRirekiB(facadeContext, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録 END");

							// 店舗LC区分が"0"(店舗)の場合
							if (f01m1VO.M1tenpolc_kbn_hdn.Equals("0"))
							{
								// [移動出荷確定TBL(H)]を更新する。
								BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 START");
								int Updcntkakuteih = Upd_IdoSyukkaKakuteiH(facadeContext, f01m1VO, logininfo, sysDateVO);
								BoSystemLog.logOut("[移動出荷確定TBL(H)]を更新 END");

								// [移動出荷確定TBL(B)]を更新する。
								BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 START");
								int Updcntkakuteib = Upd_IdoSyukkaKakuteiB(facadeContext, f01m1VO, logininfo, sysDateVO);
								BoSystemLog.logOut("[移動出荷確定TBL(B)]を更新 END");
							}

							// [移動入荷予定未存在リストTBL]を更新する。
							BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を更新 START");
							int Updcntmisonzai = Upd_Misonzai(facadeContext, f01VO, logininfo, sysDateVO, f01m1VO.M1scm_cd);
							BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を更新 END");
						}
					}
				}

				// 確定済みデータが存在した場合
				if (bKakuteizumiAri)
				{
					//「確定済みの伝票が存在しました。」
					InfoMsgCls.AddInfoMsg("I114", string.Empty, facadeContext);
				}

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

		#region ユーザー定義関数

		#region [移動入荷予定TBL(H)]を更新する。
		/// <summary>
		/// [移動入荷予定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_IdoNyukaYoteiH(IFacadeContext facadeContext,
									Te080f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-01", facadeContext.DBContext);

			// 差異フラグ
			reader.BindValue("BIND_SAI_FLG", 0);
			// 伝票状態
			reader.BindValue("BIND_DENPYO_JYOTAI", 1);
			// 確定フラグ
			reader.BindValue("BIND_KAKUTEI_FLG", 1);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 1);

			// 店舗ＬＣ区分
			reader.BindValue("BIND_TENPOLC_KBN", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tenpolc_kbn_hdn, "0")));
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1denpyo_bango, "0")));
			// 確定フラグ
			reader.BindValue("BIND_KAKUTEI_FLG_2", 0);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録する。
		/// <summary>
		/// [移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_IdoNyukaKakuteiH(IFacadeContext facadeContext,
									Te080f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-02", facadeContext.DBContext);

			// 入荷日
			reader.BindValue("BIND_JYURYO_YMD", sysDateVO.Sysdate);
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 0);
			// 送信依頼フラグ
			reader.BindValue("BIND_SOSINIRAI_FLG", 1);
			// 送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", 0);
			// 送信日
			reader.BindValue("BIND_SOSIN_YMD", 0);
			// 送信時間
			reader.BindValue("BIND_SOSIN_TM", 0);
			// 処理済フラグ
			reader.BindValue("BIND_SYORIZUMI_FLG", 0);
			// 経費伝票番号
			reader.BindValue("BIND_KEIHI_DENPYO_BANGO", 0);

			// 店舗ＬＣ区分
			reader.BindValue("BIND_TENPOLC_KBN", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tenpolc_kbn_hdn, "0")));
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1denpyo_bango, "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録する。
		/// <summary>
		/// [移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_IdoNyukaKakuteiB(IFacadeContext facadeContext,
									Te080f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-03", facadeContext.DBContext);

			// 出荷差異数
			reader.BindValue("BIND_SYUKKASAI_SU", 0);

			// 店舗ＬＣ区分
			reader.BindValue("BIND_TENPOLC_KBN", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tenpolc_kbn_hdn, "0")));
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1denpyo_bango, "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録する。
		/// <summary>
		/// [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_IdoNyukaRirekiH(IFacadeContext facadeContext,
									Te080f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-04", facadeContext.DBContext);

			// 赤黒区分
			reader.BindValue("BIND_AKAKURO_KBN", 0);
			// 履歴処理日付
			reader.BindValue("BIND_RIREKI_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("BIND_RIREKI_SYORI_TM", sysDateVO.Systime_mili);
			// 処理種別
			reader.BindValue("BIND_SYORI_SB", 1);
			// 履歴画面表示区分
			reader.BindValue("BIND_RIREKI_DISP_KB", 1);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 1);
			// 処理済フラグ
			reader.BindValue("BIND_SYORIZUMI_FLG", 0);

			// 店舗ＬＣ区分
			reader.BindValue("BIND_TENPOLC_KBN", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tenpolc_kbn_hdn, "0")));
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1denpyo_bango, "0")));
			// 出荷日
			reader.BindValue("BIND_SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd, 0)));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録する。
		/// <summary>
		/// [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_IdoNyukaRirekiB(IFacadeContext facadeContext,
									Te080f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-05", facadeContext.DBContext);

			// 赤黒区分
			reader.BindValue("BIND_AKAKURO_KBN", 0);

			// 店舗ＬＣ区分
			reader.BindValue("BIND_TENPOLC_KBN", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1tenpolc_kbn_hdn, "0")));
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1denpyo_bango, "0")));
			// 出荷日
			reader.BindValue("BIND_SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd, 0)));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動出荷確定TBL(H)]を更新する。
		/// <summary>
		/// [移動出荷確定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_IdoSyukkaKakuteiH(IFacadeContext facadeContext,
									Te080f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-06", facadeContext.DBContext);

			// 入荷担当者コード
			reader.BindValue("BIND_NYUKATAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 入荷日
			reader.BindValue("BIND_JYURYO_YMD", sysDateVO.Sysdate);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 出荷日
			reader.BindValue("BIND_SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd, 0)));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1denpyo_bango, "0")));

			// ■リプレイス
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// テーブルID（シノニム）
			sRepSql.Append("MDUT0010_").Append(Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0"))).Append(" MDUT0010");

			BoSystemSql.AddSql(reader, "TABLE_ID", sRepSql.ToString(), bindList);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動出荷確定TBL(B)]を更新する。
		/// <summary>
		/// [移動出荷確定TBL(B)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_IdoSyukkaKakuteiB(IFacadeContext facadeContext,
									Te080f01M1Form f01m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-07", facadeContext.DBContext);

			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 出荷日
			reader.BindValue("BIND_SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd, 0)));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1denpyo_bango, "0")));

			// ■リプレイス
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// テーブルID（シノニム）
			sRepSql.Append("MDUT0011_").Append(Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1kaisya_cd, "0"))).Append(" MDUT0011");

			BoSystemSql.AddSql(reader, "TABLE_ID", sRepSql.ToString(), bindList);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷予定未存在リストTBL]を更新する。
		/// <summary>
		/// [移動入荷予定未存在リストTBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="scmcd">SCMコード</param>
		/// <returns>更新件数</returns>
		private int Upd_Misonzai(IFacadeContext facadeContext,
									Te080f01Form f01VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									string scmcd)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-08", facadeContext.DBContext);

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 1);

			// 入荷会社コード
			reader.BindValue("BIND_JYURYOKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(loginInfo.CopCd, "0")));
			// 入荷店コード
			reader.BindValue("BIND_JYURYOTEN_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// SCMコード
			reader.BindValue("BIND_SCM_CD", BoSystemFormat.formatScmCd(scmcd));
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG_2", 0);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷予定未存在リストTBL]を削除する。
		/// <summary>
		/// [移動入荷予定未存在リストTBL]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="scmcd">SCMコード</param>
		/// <returns>更新件数</returns>
		private int Del_Misonzai(IFacadeContext facadeContext,
									Te080f01Form f01VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									string scmcd)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-09", facadeContext.DBContext);

			// 入荷会社コード
			reader.BindValue("BIND_JYURYOKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(loginInfo.CopCd, "0")));
			// 入荷店コード
			reader.BindValue("BIND_JYURYOTEN_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// SCMコード
			reader.BindValue("BIND_SCM_CD", BoSystemFormat.formatScmCd(scmcd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷予定未存在リストTBL]を登録する。
		/// <summary>
		/// [移動入荷予定未存在リストTBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="scmcd">SCMコード</param>
		/// <returns>更新件数</returns>
		private int Ins_Misonzai(IFacadeContext facadeContext,
									Te080f01Form f01VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									string scmcd)
		{

			string syukkakaisya_cd = "";	// 出荷会社コード
			string syukkaten_cd = "";		// 出荷店コード

			scmcd = BoSystemFormat.formatScmCd(scmcd);
			if (scmcd.Length == 14)
			{
				// 14桁の場合（既存SCMなので自社間での移動）
				// 出荷会社コード
				syukkakaisya_cd = loginInfo.CopCd;		// ログイン情報.会社コード
				// 出荷店コード
				syukkaten_cd = scmcd.Substring(1, 4);	// SCMコード（2～5桁目）
			}
			else if (scmcd.Length == 20)
			{
				// 20桁の場合
				if (scmcd.Substring(0, 5).Equals("00049"))
				{
					// 先頭5桁が"00049"の場合
					Hashtable resultHash = new Hashtable();

					// 出荷会社コード
					resultHash = V01015Check.CheckMeisyo("CONM", "1", facadeContext);
					if (resultHash != null)
					{
						syukkakaisya_cd = resultHash["MEISYOKANA_NM"].ToString();	// 名称MST(CONM).名称カナ名
					}

					// 出荷店コード
					resultHash = V01015Check.CheckMeisyo("LCCD", "1", facadeContext);
					if (resultHash != null)
					{
						syukkaten_cd = resultHash["MEISYO_NM"].ToString();			// 名称MST(LCCD).名称名
					}
				}
				else if (scmcd.Substring(0, 6).Equals("000000"))
				{
					// 先頭6桁が"000000"の場合
					Hashtable resultHash = new Hashtable();

					// 出荷会社コード
					resultHash = V01015Check.CheckMeisyo("CONM", "1", facadeContext);
					if (resultHash != null)
					{
						syukkakaisya_cd = resultHash["MEISYOKANA_NM"].ToString();	// 名称MST(CONM).名称カナ名
					}

					// 出荷店コード
					syukkaten_cd = scmcd.Substring(7, 4);							// SCMコード（8～11桁目）
				}
				else if (scmcd.Substring(0, 2).Equals(ScmCodeCls.IDO_TSUJO)
					|| scmcd.Substring(0, 2).Equals(ScmCodeCls.IDO_DC))
				{
					// 先頭2桁が"01"、"02"の場合
					// 出荷会社コード
					syukkakaisya_cd = scmcd.Substring(2, 2);	// SCMコード（3～4桁目）
					// 出荷店コード
					syukkaten_cd = scmcd.Substring(4, 4);		// SCMコード（5～8桁目）
				}
				else if (scmcd.Substring(0, 2).Equals(ScmCodeCls.IDO_LC_MISEBETSU)
					|| scmcd.Substring(0, 2).Equals(ScmCodeCls.IDO_LC_SORYO))
				{
					// 先頭2桁が"03"、"04"の場合

					// 出荷会社コード
					syukkakaisya_cd = scmcd.Substring(2, 2);	// SCMコード（3～4桁目）

					// 出荷店コード
					// XMLからSQLを取得
					FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable("TE080P01-11", facadeContext.DBContext);
					// バインド会社コード
					stmt.BindValue("BIND_KAISYA_CD", Convert.ToDecimal(syukkakaisya_cd));	// 出荷会社コード
					//クエリを実行する。
					IList<Hashtable> resultHash = stmt.Execute();
					if (resultHash != null && resultHash.Count > 0)
					{
						syukkaten_cd = resultHash[0]["TENPO_CD"].ToString();	// 店舗MST(全企業).店舗コード
					}
				}
				else
				{
					// 出荷会社コード
					syukkakaisya_cd = scmcd.Substring(2, 2);	// SCMコード（3～4桁目）
					// 出荷店コード
					syukkaten_cd = scmcd.Substring(4, 4);		// SCMコード（5～8桁目）
				}
			}

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TE080P01-10", facadeContext.DBContext);

			// 入荷会社コード
			reader.BindValue("BIND_JYURYOKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(loginInfo.CopCd, "0")));
			// 入荷店コード
			reader.BindValue("BIND_JYURYOTEN_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);
			// SCMコード
			reader.BindValue("BIND_SCM_CD", BoSystemFormat.formatScmCd(scmcd));
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(BoSystemString.Nvl(syukkakaisya_cd, "0")));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemString.Nvl(BoSystemFormat.formatTenpoCd(syukkaten_cd), " "));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 0);
			// HHTシリアル番号
			reader.BindValue("BIND_HHTSERIAL_NO", string.Empty);
			// HHTシーケンスNO.
			reader.BindValue("BIND_HHTSEQUENCE_NO", 0);

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
