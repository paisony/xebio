using com.xebio.bo.Tb040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01020;
using Common.Business.C01000.C01021;
using Common.Business.C99999.FormatUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01016;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tb040p01.Facade
{
  /// <summary>
  /// Tb040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb040f01Facade : StandardBaseFacade
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
				Tb040f01Form f01VO = (Tb040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				// 仕入共通部品更新用配列
				TbCommonConfirmReg commonReg = new TbCommonConfirmReg(facadeContext, logininfo);

				#region 行数チェック

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
						Tb040f01M1Form f01m1VO = (Tb040f01M1Form)m1List[i];
						
						if (!string.IsNullOrEmpty(f01m1VO.M1denpyo_barcode))
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
				
				
				#region 単項目チェック
				
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

				// 重複チェック
				Dictionary<string, TbCommonRegVO> rowNum = new Dictionary<string, TbCommonRegVO>();
				SortedDictionary<decimal, string> errRowNum = new SortedDictionary<decimal, string>();

				Boolean isInfo = false;

				for (int i = 0; i < m1List.Count; i++)
				{
					Tb040f01M1Form f01m1VO = (Tb040f01M1Form)m1List[i];

					// 伝票バーコードが入力されている行のみチェックを行う
					if (!string.IsNullOrEmpty(f01m1VO.M1denpyo_barcode))
					{
						// 2-2 Ｍ１仕入先コード、Ｍ１伝票バーコード
						//     6桁の伝票番号のみ入力されている場合エラー
						if (f01m1VO.M1denpyo_barcode.Length == 6 && string.IsNullOrEmpty(f01m1VO.M1siiresaki_cd))
						{
							ErrMsgCls.AddErrMsg("E121", "仕入先", facadeContext, new[] { "M1siiresaki_cd" }, f01m1VO.M1rowno, i.ToString(), "M1");
						}

						// 2-3 Ｍ１仕入先コード
						//       仕入先マスタを検索し、存在しない場合エラー
						if (!string.IsNullOrEmpty(f01m1VO.M1siiresaki_cd) || f01m1VO.M1denpyo_barcode.Length == 10)
						{
							Hashtable resultHash = new Hashtable();
							string siiresakiCd = f01m1VO.M1siiresaki_cd;

							// 伝票バーコードが10桁の場合
							if (f01m1VO.M1denpyo_barcode.Length == 10)
							{
								resultHash = V01002Check.CheckShiiresaki(f01m1VO.M1denpyo_barcode.Substring(0, 4),
																		facadeContext,
																		"仕入先",
																		new[] { "M1denpyo_barcode" },
																		f01m1VO.M1rowno,
																		i.ToString(),
																		"M1",
																		Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
							}
							else
							{
								resultHash = V01002Check.CheckShiiresaki(f01m1VO.M1siiresaki_cd,
																		facadeContext,
																		"仕入先",
																		new[] { "M1siiresaki_cd" },
																		f01m1VO.M1rowno,
																		i.ToString(),
																		"M1",
																		Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));

							}

							// 名称をラベルに設定
							if (resultHash != null && resultHash.Count > 0)
							{
								f01m1VO.M1siiresaki_ryaku_nm = (string)resultHash["SIIRESAKI_RYAKU_NM"];
							}

						}
						
						// 2-4 Ｍ１仕入先コード
						// 仕入入荷予定TBL(H)に存在しない場合、エラー
						if (f01m1VO.M1denpyo_barcode.Length > 6
							|| (!string.IsNullOrEmpty(f01m1VO.M1denpyo_barcode) && !string.IsNullOrEmpty(f01m1VO.M1siiresaki_cd)))
						{
							SearchSiireYoteiVO searchConditionVO = new SearchSiireYoteiVO(
																					f01m1VO.M1siiresaki_cd,			// 仕入先コード
																					f01m1VO.M1denpyo_barcode,		// 伝票バーコード
																					f01VO.Head_tenpo_cd				// 店舗コード
																					);

							Hashtable resultHash = new Hashtable();

							resultHash = V01016Check.CheckDenpyo(searchConditionVO, facadeContext, "伝票番号", new[] { "M1denpyo_barcode" }, f01m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));

							#region 仕入確定データ取得処理
							if (resultHash != null && resultHash.Count > 0)
							{
								TbCommonRegVO regVO = new TbCommonRegVO();

								// 行番号
								regVO.Gyo_no = i.ToString();

								// 明細番号
								regVO.Rowno = f01m1VO.M1rowno;

								// 仕入先コード
								regVO.Siiresaki_cd = BoSystemFormat.formatSiiresakiCd(resultHash["SIIRESAKI_CD"].ToString());

								// 伝票番号
								regVO.Denpyo_bango = BoSystemFormat.formatDenpyoNo(resultHash["DENPYO_BANGO"].ToString());

								// 入荷予定日
								regVO.Nyukayotei_ymd = BoSystemFormat.formatDate(resultHash["SITEINOHIN_YMD"].ToString());

								// 店舗コード
								regVO.Tenpo_cd = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);

								// 納品書日付
								regVO.Nohinsyo_ymd = BoSystemFormat.formatDate(resultHash["NOHINSYO_YMD"].ToString());

								// 部門コード
								regVO.Bumon_cd = BoSystemFormat.formatBumonCd(resultHash["BUMON_CD"].ToString());

								// サブ仕入先コード
								regVO.Subsiiresaki_cd = BoSystemFormat.formatSiiresakiCd(resultHash["SUBSIIRESAKI_CD"].ToString());

								// 仕入予定合計数量
								regVO.Siireyoteigokei_su = resultHash["SIIREYOTEIGOKEI_SU"].ToString();

								// 仕入予定合計金額
								regVO.Siireyoteigokei_kin = resultHash["SIIREYOTEIGOKEI_KIN"].ToString();

								// 更新日
								regVO.Upd_ymd = BoSystemFormat.formatDate(resultHash["UPD_YMD"].ToString());

								// 更新時間
								regVO.Upd_tm = (string)resultHash["UPD_TM"].ToString();

								// 仕入先コード＋伝票番号が重複しない場合のみ追加
								string dicKey =regVO.Siiresaki_cd + regVO.Denpyo_bango;
								try
								{
									// 仕入先コード＋伝票番号で仕入共通データを格納
									rowNum.Add(dicKey, regVO);

									// 未確定データの場合はデータを格納
									if ("0".Equals(resultHash["KAKUTEI_FLG"].ToString()))
									{
										// 仕入共通データをListに格納
										commonReg.AddList(regVO);
									}
									// 確定データの場合はWARNフラグを立てる
									else
									{
										isInfo = true;
									}


								}
								// 仕入先コード＋伝票番号が重複する場合はエラーDictionaryに行番号と明細番号を設定
								catch (ArgumentException)
								{
									errRowNum[Convert.ToDecimal(rowNum[dicKey].Gyo_no)] = rowNum[dicKey].Rowno;
									errRowNum.Add(i, regVO.Rowno);
								}
							}

							#endregion
						}
					}
				}

				// エラーDictionaryからエラー内容を出力する。
				foreach (decimal errKey in errRowNum.Keys)
				{
					ErrMsgCls.AddErrMsg("E210", "伝票番号", facadeContext, new[] { "M1denpyo_barcode" }, errRowNum[errKey], errKey.ToString(), "M1");
				}


				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// WARNフラグが立っている場合は警告メッセージを追加
				if(isInfo)
				{
					InfoMsgCls.AddInfoMsg("I114", String.Empty, facadeContext);
				}

				#endregion

				#endregion

				// 共通部品で更新を行う。
				if (commonReg.GetListCnt() > 0)
				{
					#region 排他チェック

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (commonReg.isCheckHaita())
					{
						return;
					}

					#endregion

					#region 更新処理

					commonReg.updData();

					#endregion
				}

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
