using com.xebio.bo.Tf010p01.Constant;
using com.xebio.bo.Tf010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01015;
using Common.Business.V01000.V01021;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tf010p01.Facade
{
  /// <summary>
  /// Tf010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf010f02Facade : StandardBaseFacade
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
				Tf010f02Form f02VO = (Tf010f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Tf010f01M1Form f01M1Form = (Tf010f01M1Form)f02VO.Dictionary[Tf010p01Constant.DIC_M1SELECTVO];

				#endregion

				#region 業務チェック

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
						Tf010f02M1Form f02m1VO = (Tf010f02M1Form)m1List[i];

						// モードが「確定」「修正」で、[Ｍ１スキャンコード]が入力済の場合
						if (   (BoSystemConstant.MODE_KAKUTEI.Equals(f02VO.Stkmodeno) || BoSystemConstant.MODE_UPD.Equals(f02VO.Stkmodeno))
							&& !string.Empty.Equals(f02m1VO.M1scan_cd))
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

				#region マスタチェック

				// 1-１ 科目コード
				//       科目マスタを検索し、存在しない場合エラー
				f02VO.Kamoku_nm = string.Empty;
				if (!string.IsNullOrEmpty(f02VO.Kamoku_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01021Check.CheckKamoku(f02VO.Kamoku_cd, facadeContext, "科目コード", new[] { "Kamoku_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f02VO.Kamoku_nm = (string)resultHash["KAMOKU_NM"];
					}
				}
				# endregion

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf010f02M1Form f02m1VO = (Tf010f02M1Form)m1List[i];

					// スキャンコードが入力されている行のみチェックを行う
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
					{
						#region 入力値チェック

						// 数量が未入力の場合エラー
						if (string.IsNullOrEmpty(f02m1VO.M1suryo))
						{
							ErrMsgCls.AddErrMsg("E121", new[] { "数量" }, facadeContext, new[] { "M1suryo" }, f02m1VO.M1rowno, i.ToString(), "M1");
						}
						else
						{
							// 0が入力された場合、エラー
							if (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1suryo, "0")) == 0)
							{
								ErrMsgCls.AddErrMsg("E103", new[] { "数量" }, facadeContext, new[] { "M1suryo" }, f02m1VO.M1rowno, i.ToString(), "M1");
							}
						}

						#endregion

						#region マスタチェック

						// 1-2 Ｍ１スキャンコード
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
							resultHash = V01004Check.CheckScanCd(searchConditionVO,
																	facadeContext,
																	"スキャンコード",
																	new[] { "M1scan_cd" },
																	f02m1VO.M1rowno,
																	i.ToString(),
																	"M1",
																	0);

							// 取得エラー時は次の行へ移動
							if (resultHash == null)
							{
								continue;
							}

							// 確定フラグがONの場合は取得し直す
							if (BoSystemConstant.CHECKBOX_ON.Equals(f02m1VO.M1entersyoriflg))
							{
								// 名称をラベルに設定
								f02m1VO.M1bumon_cd = BoSystemFormat.formatBumonCd(resultHash["BUMON_CD"].ToString());										// 部門コード
								f02m1VO.M1bumonkana_nm = resultHash["BUMONKANA_NM"].ToString();																// 部門名
								f02m1VO.M1hinsyu_ryaku_nm = resultHash["HINSYU_RYAKU_NM"].ToString();														// 品種
								f02m1VO.M1burando_nm = resultHash["BURANDO_NMK"].ToString();																// ブランド名
								f02m1VO.M1jisya_hbn = BoSystemFormat.formatJisyaHbn((string)resultHash["XEBIO_CD"].ToString());								// 自社品番
								f02m1VO.M1maker_hbn = resultHash["HIN_NBR"].ToString();																		// メーカー品番
								f02m1VO.M1syonmk = resultHash["SYONMK"].ToString();																			// 商品名
								f02m1VO.M1iro_nm = resultHash["IRO_NM"].ToString();																			// 色
								f02m1VO.M1size_nm = resultHash["SIZE_NM"].ToString();																		// サイズ
								f02m1VO.M1gen_tnk = resultHash["HYOKA_TNK"].ToString();																		// 原価
								f02m1VO.M1genbaika_tnk = resultHash["SLPR"].ToString();																		// 原売価

								// ディクショナリ
								f02m1VO.Dictionary[Tf010p01Constant.DIC_M1HINSYU_CD] = BoSystemFormat.formatHinsyuCd(resultHash["HINSYU_CD"].ToString());	// 品種コード
								f02m1VO.Dictionary[Tf010p01Constant.DIC_M1IRO_CD] = BoSystemFormat.formatIroCd(resultHash["MAKERCOLOR_CD"].ToString());		// 色コード
								f02m1VO.Dictionary[Tf010p01Constant.DIC_M1SIZE_CD] = BoSystemFormat.formatSizeCd(resultHash["SIZE_CD"].ToString());			// サイズコード
								f02m1VO.Dictionary[Tf010p01Constant.DIC_M1SYOHIN_CD] = resultHash["SYOHIN_CD"].ToString();									// 商品コード
								f02m1VO.Dictionary[Tf010p01Constant.DIC_M1BURANDO_CD] = BoSystemFormat.formatBrandCd(resultHash["BURANDO_CD"].ToString());	// ブランドコード
							}
						}

						#endregion
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#region 排他チェック
				string sTable = string.Empty;
				// 「確定」モードの場合
				if (BoSystemConstant.MODE_KAKUTEI.Equals(f02VO.Stkmodeno))
				{
					sTable = Tf010p01Constant.TABLE_ID_MDAT0020;
				}
				// 「修正」モードの場合
				else
				{
					sTable = Tf010p01Constant.TABLE_ID_MDAT0030;
				}

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD		= :BIND_TENPO_CD");
				sRepSql.Append(" AND DENPYO_BANGO	= :BIND_DENPYO_BANGO");
				sRepSql.Append(" AND SYORI_YMD		= :BIND_SYORI_YMD");

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Shinsei_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 伝票番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f02VO.Denpyo_bango);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 処理日
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD";
				bindVO.Value = BoSystemFormat.formatDate((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 排他チェック
				V03003Check.CheckHaitaMaxVal(
						Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1UPD_YMD]),
						Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1UPD_TM]),
						facadeContext,
						sTable,
						sRepSql.ToString(),
						bindList,
						1
				);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 更新処理

				decimal sumBaika = 0;

				// モードが「確定」の場合
				if (BoSystemConstant.MODE_KAKUTEI.Equals(f02VO.Stkmodeno))
				{
					// [経費振替申請TBL(H)]を更新する。
					BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 START");
					int Updcntsinseih = Upd_Mei_Kakutei_KeihiFurikaeSinseih(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 END");

					// [経費振替確定TBL(H)]を登録する。
					BoSystemLog.logOut("[経費振替確定TBL(H)]を登録 START");
					int Inscntkakuteih = Ins_Mei_Kakutei_KeihiFurikaeKakuteih(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[経費振替確定TBL(H)]を登録 END");

					int index = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf010f02M1Form f02m1VO = (Tf010f02M1Form)m1List[i];

						// スキャンコードが入力されている行のみ処理を行う
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							index++;

							// [経費振替確定TBL(B)]を登録する。
							BoSystemLog.logOut("[経費振替確定TBL(B)]を登録 START");
							int Inscntkakuteib = Ins_Mei_Kakutei_KeihiFurikaeKakuteib(facadeContext, f02VO, f01M1Form, f02m1VO, logininfo, sysDateVO, index);
							BoSystemLog.logOut("[経費振替確定TBL(B)]を登録 END");

							sumBaika = sumBaika + (Convert.ToDecimal(f02m1VO.M1suryo) * Convert.ToDecimal(f02m1VO.M1genbaika_tnk));
						}
					}
				}

				// モードが「修正」の場合
				if (BoSystemConstant.MODE_UPD.Equals(f02VO.Stkmodeno))
				{
					// [経費振替申請TBL(H)]を更新する。
					BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 START");
					int Updcntsinseih = Upd_Mei_Shusei_KeihiFurikaeSinseih(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 END");

					// [経費振替確定TBL(H)]を更新する。
					BoSystemLog.logOut("[経費振替確定TBL(H)]を更新 START");
					int Updcntkakuteih = Upd_Mei_Shusei_KeihiFurikaeKakuteih(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[経費振替確定TBL(H)]を更新 END");

					// [経費振替確定TBL(B)]を削除する。
					BoSystemLog.logOut("[経費振替確定TBL(B)]を削除 START");
					int Delcntkakuteih = Del_Shusei_KeihiFurikaeKakuteib(facadeContext, f02VO, f01M1Form, logininfo, sysDateVO);
					BoSystemLog.logOut("[経費振替確定TBL(B)]を削除 END");

					int index = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf010f02M1Form f02m1VO = (Tf010f02M1Form)m1List[i];

						// スキャンコードが入力されている行のみ処理を行う
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{

							index++;

							// [経費振替確定TBL(B)]を登録する。
							BoSystemLog.logOut("[経費振替確定TBL(B)]を登録 START");
							int Inscntkakuteib = Ins_Shusei_KeihiFurikaeKakuteib(facadeContext, f02VO, f01M1Form, f02m1VO, logininfo, sysDateVO, index);
							BoSystemLog.logOut("[経費振替確定TBL(B)]を登録 END");

							sumBaika = sumBaika + (Convert.ToDecimal(f02m1VO.M1suryo) * Convert.ToDecimal(f02m1VO.M1genbaika_tnk));
						}
					}
				}

				#endregion

				#region 一覧画面項目の設定

				// Ｍ１確定日
				f01M1Form.M1kakutei_ymd = sysDateVO.Sysdate.ToString();
				// Ｍ１業務稟議No
				f01M1Form.M1gyomuringi_no = f02VO.Gyomuringi_no;
				// Ｍ１数量
				f01M1Form.M1suryo = f02VO.Gokei_suryo;
				// Ｍ１原価金額
				f01M1Form.M1genka_kin = f02VO.Genka_kin_gokei1;
				// Ｍ１申請理由
				Hashtable tmpMeisho = V01015Check.CheckMeisyo(
															  "KHRY",				// 識別コード（伝票状態）
															  f02VO.Sinseiriyu_kb,	// 名称コード（確定）
															  facadeContext
															  );

				f01M1Form.M1sinseiriyu = tmpMeisho["MEISYO_NM"].ToString() + f02VO.Sinseiriyu;
				if (System.Text.Encoding.GetEncoding(932).GetByteCount(f01M1Form.M1sinseiriyu) > 30)
				{
					f01M1Form.M1sinseiriyu = BoSystemString.LeftB(f01M1Form.M1sinseiriyu, 30);
				}																									// Ｍ１申請理由


				// Ｍ１却下理由
				f01M1Form.M1kyakkariyu = f02VO.Kyakkariyu;

				// Ｍ１承認状態
				// Ｍ１却下フラグ
				string syoninFlg = string.Empty;
				if (string.Empty.Equals(f02VO.Kyakkariyu))
				{
					f01M1Form.M1syonin_flg = BoSystemConstant.CHECKBOX_ON;
					f01M1Form.M1kyakka_flg = BoSystemConstant.CHECKBOX_OFF;
					syoninFlg = ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1;
				}
				else
				{
					f01M1Form.M1syonin_flg = BoSystemConstant.CHECKBOX_OFF;
					f01M1Form.M1kyakka_flg = BoSystemConstant.CHECKBOX_ON;
					syoninFlg = ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2;
				}

				// Ｍ１承認状態名称
				Hashtable tmpSyonin = V01015Check.CheckMeisyo(
															  "KHSN",				// 識別コード（承認状態）
															  syoninFlg,			// 名称コード（承認）
															  facadeContext
															  );
				f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYONINSTATUS] = tmpSyonin["MEISYO_NM"].ToString();

				// Ｍ１科目コード
				f01M1Form.M1kamoku_cd = f02VO.Kamoku_cd;
				// Ｍ１科目名
				f01M1Form.M1kamoku_nm = f02VO.Kamoku_nm;
				// Ｍ１売価金額
				f01M1Form.M1baika_kin = sumBaika.ToString();
				// Ｍ１確定担当者名称
				f01M1Form.M1kakuteitan_nm = logininfo.TtsMei;

				// Ｍ１申請理由区分
				f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SINSEIRIYU_KB] = f02VO.Sinseiriyu_kb;
				// Ｍ１申請理由
				f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SINSEIRIYU] = f02VO.Sinseiriyu;
				// Ｍ１更新日
				f01M1Form.Dictionary[Tf010p01Constant.DIC_M1UPD_YMD] = sysDateVO.Sysdate.ToString();
				// Ｍ１更新時間
				f01M1Form.Dictionary[Tf010p01Constant.DIC_M1UPD_TM] = sysDateVO.Systime_mili.ToString();
				// Ｍ１確定担当者コード
				f01M1Form.Dictionary[Tf010p01Constant.DIC_M1KAKUTEITANTOCD] = BoSystemFormat.formatTantoCd(logininfo.TtsCd);

				// モードが「確定」の場合
				if (BoSystemConstant.MODE_KAKUTEI.Equals(f02VO.Stkmodeno))
				{
					// Ｍ１テーブル区分
					f01M1Form.Dictionary[Tf010p01Constant.DIC_M1TBLFLG] = "2";
				}
				// 確定フラグの設定
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;

				// Ｍ１明細画面確定フラグ
				f01M1Form.Dictionary[Tf010p01Constant.DIC_M1F02ENTERSYORI_FLG] = BoSystemConstant.CHECKBOX_ON;

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 印刷処理

				// 却下理由が未入力の場合
				if (string.IsNullOrEmpty(f02VO.Kyakkariyu))
				{

					// 帳票ツールに渡すパラメータを格納
					InputData inputData = new InputData();

					// 店舗コード
					inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f02VO.Shinsei_tenpo_cd));
					// 処理日付
					inputData.AddScreenParameter(2, BoSystemFormat.formatDate((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
					// 伝票番号
					inputData.AddScreenParameter(3, BoSystemFormat.formatDenpyoNo(f02VO.Denpyo_bango));
					// テーブル区分
					inputData.AddScreenParameter(4, (string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1TBLFLG]);
					// 会社コード
					inputData.AddScreenParameter(5, logininfo.CopCd);
					// 店舗控え出力フラグ
					inputData.AddScreenParameter(6, "0");

					OutputInfo output = new OutputInfo();
					BoSystemReport reportCls = new BoSystemReport();

					// 帳票ID
					string chohyoId = string.Empty;

					string pdfFileNm = string.Empty;

					// 帳票ID
					chohyoId = BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_X;

					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(chohyoId),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													chohyoId,
													Tf010p01Constant.FORMID_02,
													Tf010p01Constant.PGID,
													pdfFileNm
													);

					// PDFをファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tf010p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				}

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

		#region [経費振替申請TBL(H)]を更新
		/// <summary>
		/// [経費振替申請TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_Mei_Kakutei_KeihiFurikaeSinseih(IFacadeContext facadeContext,
											Tf010f02Form f02Form,
											Tf010f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新内容
			// 決裁フラグ
			reader.BindValue("BIND_KESSAI_FLG", 1);
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

			// 更新条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02Form.Denpyo_bango)));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(H)]の登録
		/// <summary>
		/// [経費振替確定TBL(H)]の登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_Mei_Kakutei_KeihiFurikaeKakuteih(IFacadeContext facadeContext,
														Tf010f02Form f02Form,
														Tf010f01M1Form f01M1Form,
														LoginInfoVO loginInfo,
														SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 登録内容
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02Form.Denpyo_bango)));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_TM]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Shinsei_tenpo_cd));
			// 科目コード
			reader.BindValue("BIND_KAMOKU_CD", Convert.ToDecimal(f02Form.Kamoku_cd));
			// 申請理由区分
			reader.BindValue("BIND_SINSEIRIYU_KB", Convert.ToDecimal(f02Form.Sinseiriyu_kb));
			// 申請理由
			reader.BindValue("BIND_SINSEIRIYU", f02Form.Sinseiriyu);
			// 却下理由
			reader.BindValue("BIND_KYAKKARIYU", f02Form.Kyakkariyu);

			// 承認状態
			// 却下理由が未入力の場合
			if (string.Empty.Equals(f02Form.Kyakkariyu))
			{
				reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1));
			}
			else
			{
				reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2));
			}

			// 盗難品管理番号
			reader.BindValue("BIND_TONANHINKANRI_NO", (string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1TONANHINKANRI_NO]);
			// 盗難品処理日付
			reader.BindValue("BIND_TONANHINSYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1TONANHINSYORI_YMD]));
			// 盗難品店舗コード
			reader.BindValue("BIND_TONANHINTENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1TONANHINTENPO_CD]));
			// 受理番号
			reader.BindValue("BIND_JYURI_NO", f02Form.Jyuri_no);
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", 0);
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", string.Empty);
			// 移動伝票番号
			reader.BindValue("BIND_IDODENPYO_BANGO", 0);
			// 申請日
			reader.BindValue("BIND_APPLY_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02Form.Apply_ymd)));
			// 申請担当者コード
			reader.BindValue("BIND_SINSEITAN_CD", BoSystemFormat.formatTantoCd(f02Form.Sinseitan_cd));
			// 業務稟議No
			reader.BindValue("BIND_GYOMURINGI_NO", BoSystemString.Nvl(f02Form.Gyomuringi_no, "0"));
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
			// 申請データ送信済フラグ
			reader.BindValue("BIND_SSI_SSNZUMI_FLG", 0);
			// 申請データ送信日
			reader.BindValue("BIND_SSI_SSN_YMD", 0);
			// 申請データ送信時間
			reader.BindValue("BIND_SSI_SSN_TM", 0);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(B)]を登録
		/// <summary>
		/// [経費振替確定TBL(B)]の登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="index">インデックス</param>
		/// <returns>更新件数</returns>
		private int Ins_Mei_Kakutei_KeihiFurikaeKakuteib(IFacadeContext facadeContext,
														Tf010f02Form f02Form,
														Tf010f01M1Form f01M1Form,
														Tf010f02M1Form f02M1Form,
														LoginInfoVO loginInfo,
														SysDateVO sysDateVO,
														int index)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 登録内容
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02Form.Denpyo_bango)));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_TM]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Shinsei_tenpo_cd));
			// 伝票行No
			reader.BindValue("BIND_DENPYOGYO_NO", index);
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f02M1Form.M1bumon_cd));
			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(BoSystemFormat.formatHinsyuCd((string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1HINSYU_CD])));
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1BURANDO_CD]));
			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f02M1Form.M1maker_hbn);
			// 商品名（カナ）
			reader.BindValue("BIND_SYONMK", f02M1Form.M1syonmk);
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02M1Form.M1jisya_hbn));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1IRO_CD]));
			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd((string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1SIZE_CD]));
			// サイズ
			reader.BindValue("BIND_SIZE_NM", f02M1Form.M1size_nm);
			// JANコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f02M1Form.M1scan_cd));
			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", (string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1SYOHIN_CD]);
			// 数量
			reader.BindValue("BIND_SURYO", Convert.ToDecimal(f02M1Form.M1suryo));
			// 原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(f02M1Form.M1gen_tnk));
			// 売価
			reader.BindValue("BIND_BAIKA_TNK", Convert.ToDecimal(f02M1Form.M1genbaika_tnk));


			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替申請TBL(H)]を更新
		/// <summary>
		/// [経費振替申請TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_Mei_Shusei_KeihiFurikaeSinseih(IFacadeContext facadeContext,
											Tf010f02Form f02Form,
											Tf010f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新内容
			// 決裁フラグ
			reader.BindValue("BIND_KESSAI_FLG", 1);
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

			// 更新条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02Form.Denpyo_bango)));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(H)]の更新
		/// <summary>
		/// [経費振替確定TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_Mei_Shusei_KeihiFurikaeKakuteih(IFacadeContext facadeContext,
														Tf010f02Form f02Form,
														Tf010f01M1Form f01M1Form,
														LoginInfoVO loginInfo,
														SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_15, facadeContext.DBContext);

			// 更新内容
			// 科目コード
			reader.BindValue("BIND_KAMOKU_CD", Convert.ToDecimal(f02Form.Kamoku_cd));
			// 申請理由区分
			reader.BindValue("BIND_SINSEIRIYU_KB", Convert.ToDecimal(f02Form.Sinseiriyu_kb));
			// 申請理由
			reader.BindValue("BIND_SINSEIRIYU", f02Form.Sinseiriyu);
			// 却下理由
			reader.BindValue("BIND_KYAKKARIYU", f02Form.Kyakkariyu);
			// 承認状態
			if(string.IsNullOrEmpty(f02Form.Kyakkariyu))
			{
				reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1));
			}
			else
			{
				reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2));
			}
			// 業務稟議No
			reader.BindValue("BIND_GYOMURINGI_NO", BoSystemString.Nvl(f02Form.Gyomuringi_no, "0"));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 更新条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02Form.Denpyo_bango)));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region [経費振替確定TBL(B)]を削除
		/// <summary>
		/// [経費振替確定TBL(B)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="index">インデックス</param>
		/// <returns>削除件数</returns>
		private int Del_Shusei_KeihiFurikaeKakuteib(IFacadeContext facadeContext,
														Tf010f02Form f02Form,
														Tf010f01M1Form f01M1Form,
														LoginInfoVO loginInfo,
														SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_16, facadeContext.DBContext);

			// 削除条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02Form.Denpyo_bango)));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(B)]を登録
		/// <summary>
		/// [経費振替確定TBL(B)]の登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="index">インデックス</param>
		/// <returns>更新件数</returns>
		private int Ins_Shusei_KeihiFurikaeKakuteib(IFacadeContext facadeContext,
													Tf010f02Form f02Form,
													Tf010f01M1Form f01M1Form,
													Tf010f02M1Form f02M1Form,
													LoginInfoVO loginInfo,
													SysDateVO sysDateVO,
													int index)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 登録内容
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02Form.Denpyo_bango)));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_TM]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Shinsei_tenpo_cd));
			// 伝票行No
			reader.BindValue("BIND_DENPYOGYO_NO", index);
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f02M1Form.M1bumon_cd));
			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(BoSystemFormat.formatHinsyuCd((string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1HINSYU_CD])));
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1BURANDO_CD]));
			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f02M1Form.M1maker_hbn);
			// 商品名（カナ）
			reader.BindValue("BIND_SYONMK", f02M1Form.M1syonmk);
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02M1Form.M1jisya_hbn));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1IRO_CD]));
			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd((string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1SIZE_CD]));
			// サイズ
			reader.BindValue("BIND_SIZE_NM", f02M1Form.M1size_nm);
			// JANコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f02M1Form.M1scan_cd));
			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", (string)f02M1Form.Dictionary[Tf010p01Constant.DIC_M1SYOHIN_CD]);
			// 数量
			reader.BindValue("BIND_SURYO", Convert.ToDecimal(f02M1Form.M1suryo));
			// 原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(f02M1Form.M1gen_tnk));
			// 売価
			reader.BindValue("BIND_BAIKA_TNK", Convert.ToDecimal(f02M1Form.M1genbaika_tnk));


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
