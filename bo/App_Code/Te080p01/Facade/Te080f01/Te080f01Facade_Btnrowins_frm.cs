using com.xebio.bo.Te080p01.Constant;
using com.xebio.bo.Te080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01025;
using Common.Business.C01000.C01027;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01006;
using Common.Business.V01000.V01026;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Te080p01.Facade
{
  /// <summary>
  /// Te080f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te080f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnrowins)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnrowins)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNROWINS_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
				//OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Te080f01Form f01VO = (Te080f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				Int32 selectRow = Convert.ToInt32(BoSystemString.Nvl(f01VO.Selectrowno, "0"));
				// 対象行のフォームを取得
				Te080f01M1Form m1VO = (Te080f01M1Form)m1List.GetRowAt(selectRow);

				// 会社、出荷店以外を初期化する
				m1VO.M1tenpolc_kbn_hdn = string.Empty;	// Ｍ１店舗ＬＣ区分(隠し)
				m1VO.M1scm_cd = string.Empty;			// Ｍ１SCMコード
				m1VO.M1denpyo_bango = string.Empty;		// Ｍ１伝票番号
				m1VO.M1syukka_ymd = string.Empty;		// Ｍ１出荷日
				m1VO.M1yotei_su = string.Empty;			// Ｍ１予定数量
				m1VO.M1kyakucyu = string.Empty;			// Ｍ１客注
				m1VO.M1negaki = string.Empty;			// Ｍ１値書
				f01VO.Dictionary[Te080p01Constant.DIC_LIST_COUNT] = 0;	// 取得行数(Dictionary)

				// 会社コード、出荷店コード、SCM／伝票番号が数値型でなければ処理終了
				decimal d;
				if (!decimal.TryParse(BoSystemString.Nvl(m1VO.M1kaisya_cd, "0"), out d)
					|| !decimal.TryParse(BoSystemString.Nvl(m1VO.M1syukkaten_cd, "0"), out d)
					|| !decimal.TryParse(BoSystemString.Nvl(m1VO.M1scmden_cd, "0"), out d))
				{
					// エラーフラグを設定
					m1VO.Dictionary[Te080p01Constant.DIC_M1ERRFLG] = "1";

					return;
				}

				// 会社名が消えていたら会社名を取得する
				if (!string.IsNullOrEmpty(m1VO.M1kaisya_cd) && string.IsNullOrEmpty(m1VO.M1kaisya_nm))
				{
					Hashtable resultHash = V01006Check.CheckKaisya(m1VO.M1kaisya_cd, facadeContext);
					if (resultHash != null)
					{
						m1VO.M1kaisya_nm = (string)resultHash["MEISYO_NM"];
					}
				}

				// 出荷店名が消えていたら出荷店名を取得する
				if (!string.IsNullOrEmpty(m1VO.M1syukkaten_cd) && string.IsNullOrEmpty(m1VO.M1syukkaten_nm))
				{
					Hashtable resultHash = V01026Check.CheckTenpoAll(m1VO.M1kaisya_cd, m1VO.M1syukkaten_cd, facadeContext);
					if (resultHash != null)
					{
						m1VO.M1syukkaten_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// SCM／伝票番号を編集する
				if (!string.IsNullOrEmpty(m1VO.M1scmden_cd))
				{
					// 6桁以内(伝票番号)の場合、6桁にゼロ埋めする
					if (m1VO.M1scmden_cd.Length < 6)
					{
						string denpyo_bango = "000000" + m1VO.M1scmden_cd;
						m1VO.M1scmden_cd = denpyo_bango.Substring(denpyo_bango.Length - 6, 6);
					}
					// 14桁(SCMコード)で先頭5桁が"00918"の場合、先頭6桁をゼロ埋めする
					else
					{
						m1VO.M1scmden_cd = BoSystemFormat.formatScmCd(m1VO.M1scmden_cd);
					}
				}

				#endregion

				#region 明細検索

				// 入力値チェック
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd)
					&& !string.IsNullOrEmpty(m1VO.M1scmden_cd)
					&& (ScmCodeCls.CheckLength(m1VO.M1scmden_cd)
						|| (m1VO.M1scmden_cd.Length <= 6 && !string.IsNullOrEmpty(m1VO.M1kaisya_cd) && !string.IsNullOrEmpty(m1VO.M1syukkaten_cd))))
				{

					// 検索条件を設定
					SearchIdoYoteiVO searchConditionVO = new SearchIdoYoteiVO();

					// 入荷店コード
					searchConditionVO.jyuryoten_cd = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
					// 出荷会社コード
					searchConditionVO.Syukkakaisya_cd = BoSystemString.Nvl(m1VO.M1kaisya_cd);
					// 出荷店コード
					searchConditionVO.Syukkatencd = BoSystemFormat.formatTenpoCd(m1VO.M1syukkaten_cd);
					// SCM／伝票番号
					searchConditionVO.Scmdencd = BoSystemString.Nvl(m1VO.M1scmden_cd);

					// 検索
					IList<Hashtable> list = SearchIdoYotei.SearchScmDenpyo(searchConditionVO, facadeContext.DBContext);

					if (list == null || list.Count <= 0)
					{
						// 14桁の場合、または20桁で先頭6桁が"000491"か先頭7桁が"0000000"か先頭2桁が"01""02""03""04"のどれかの場合
						if (ScmCodeCls.CheckFormatIdo(m1VO.M1scmden_cd))
						{
							// システム日付取得
							SysDateVO sysDateVO = new SysDateVO();
							sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

							// [移動入荷予定未存在リストTBL]を削除する。
							BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を削除 START");
							int Delcntmisonzai = Del_Misonzai(facadeContext, f01VO, logininfo, sysDateVO, m1VO.M1scmden_cd);
							BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を削除 END");

							// [移動入荷予定未存在リストTBL]を登録する。
							BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を登録 START");
							int Inscntmisonzai = Ins_Misonzai(facadeContext, f01VO, logininfo, sysDateVO, m1VO.M1scmden_cd);
							BoSystemLog.logOut("[移動入荷予定未存在リストTBL]を登録 END");
						}
						// エラーフラグを設定
						Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[selectRow];
						f01m1VO.Dictionary[Te080p01Constant.DIC_M1ERRFLG] = "1";
					}
					else
					{
						#region 複数伝票の挿入チェック

						// SCMコードに複数伝票存在した場合、チェックする。
						if (list.Count >= 2)
						{
							bool bKaraGyo = false;
							int gyoCnt = 0;

							// 自分より下の行を取得した伝票行数分空き行があるかチェックする。
							for (int i = selectRow; i < m1List.Count; i++)
							{
								Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[i];
								gyoCnt++;

								// 自分より下の行をチェックする。
								if (i > selectRow)
								{
									// 入力済みの行が存在したらエラーにする。(但し同じSCMコードはエラーにしない)
									if (!string.IsNullOrEmpty(f01m1VO.M1scmden_cd) && !f01m1VO.M1scmden_cd.Equals(searchConditionVO.Scmdencd))
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
								ErrMsgCls.AddErrMsg("E224", string.Empty, facadeContext, new[] { "M1scmden_cd" }, m1VO.M1rowno, selectRow.ToString(), "M1", m1List.DispRow);
							}
						}

						//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}

						#endregion

						for (int i = 0; i < list.Count; i++)
						{

							Te080f01M1Form setm1VO = (Te080f01M1Form)m1List.GetRowAt(selectRow + i);
							Hashtable selectht = list[i];

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

						// 取得行数をDictionaryに保持する
						f01VO.Dictionary[Te080p01Constant.DIC_LIST_COUNT] = list.Count;
					}
				}
				else if (!string.IsNullOrEmpty(m1VO.M1scmden_cd))
				{
					// 入力はされているが、検索する条件を満たしていない場合
					// エラーフラグを設定
					m1VO.Dictionary[Te080p01Constant.DIC_M1ERRFLG] = "1";
				}

				// 合計行の設定
				SetGokeiGyo(facadeContext);
															
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_FRM");

		}
		#endregion
	}
}
