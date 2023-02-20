using com.xebio.bo.Tb050p01.Constant;
using com.xebio.bo.Tb050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01004;
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
using System.Data;

namespace com.xebio.bo.Tb050p01.Facade
{
  /// <summary>
  /// Tb050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb050f01Facade : StandardBaseFacade
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
				Tb050f01Form f01VO = (Tb050f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 件数チェック

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
						Tb050f01M1Form f01m1VO = (Tb050f01M1Form)m1List[i];

						if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd))
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

				if (ConditionBiko_kbn.VALUE_BIKO_KBN2.Equals(f01VO.Biko_kb))
				{
					// 2-2 備考１
					//  半角数字以外の場合はエラー
					if (!V03006Check.CsvHalfNumCheck(f01VO.Biko1))
					{
						// ①は半角数字のみで入力して下さい。。
						ErrMsgCls.AddErrMsg("E116", new[] { "①" }, facadeContext, new[] { "Biko1" });
					}

					// 2-3 備考１
					//	7桁以上の場合はエラー
					if (f01VO.Biko1.Length >= 7)
					{
						// ①は6桁以内で入力して下さい。
						ErrMsgCls.AddErrMsg("E108", new[] { "①", "6" }, facadeContext, new[] { "Biko1" });
					}

					// 2-4 備考２
					//	未入力の場合はエラー
					if (string.IsNullOrEmpty(f01VO.Biko2))
					{
						// ②を入力して下さい。
						ErrMsgCls.AddErrMsg("E121", "②", facadeContext, new[] { "Biko2" });
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
					Tb050f01M1Form f01m1VO = (Tb050f01M1Form)m1List[i];

					// スキャンコードが入力されている行のみチェックを行う
					if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd))
					{
						Hashtable resultHash = null;
						decimal genka_kin = 0;

						// 3-1 Ｍ１店舗コード
						//    入力されていない場合、エラー
						if (string.IsNullOrEmpty(f01m1VO.M1tenpo_cd))
						{
                            // 店舗を入力して下さい。
                            ErrMsgCls.AddErrMsg("E121", "店舗", facadeContext, new[] { "M1tenpo_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
                            continue;
						}

						// 3-2 Ｍ１店舗コード
						//       店舗マスタを検索し、存在しない場合エラー
						f01m1VO.M1tenpo_nm = string.Empty;
						resultHash = new Hashtable();

						resultHash = V01001Check.CheckTenpo(  f01m1VO.M1tenpo_cd
															, facadeContext
															, "店舗"
															, new[] { "M1tenpo_cd" }
															, f01m1VO.M1rowno
															, i.ToString()
															, "M1"
                              , m1List.DispRow);

                // 名称をラベルに設定
                if (resultHash != null)
						{
							f01m1VO.M1tenpo_nm = (string)resultHash["TENPO_NM"];
						}

						// 3-3 Ｍ１スキャンコード
						//       発注マスタを検索し、存在しない場合エラー
						SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01m1VO.M1scan_cd,		// スキャンコード
						f01m1VO.M1tenpo_cd,		// 店舗コード
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

						resultHash = new Hashtable();
						resultHash = V01004Check.CheckScanCd(   searchConditionVO, 
																facadeContext,
																"スキャンコード",
																new[] { "M1scan_cd" },
																f01m1VO.M1rowno,
																i.ToString(),
																"M1",
                                m1List.DispRow);

                // 取得エラー時は次の行へ移動
                if (resultHash == null)
						{
							continue;
						}

						// 名称をラベルに設定
						f01m1VO.M1bumon_cd = BoSystemFormat.formatBumonCd(resultHash["BUMON_CD"].ToString());						// 部門コード
						f01m1VO.M1bumonkana_nm = resultHash["BUMONKANA_NM"].ToString();						   						// 部門名カナ
						f01m1VO.M1hinsyu_ryaku_nm = resultHash["HINSYU_RYAKU_NM"].ToString();						   				// 品種
						f01m1VO.M1burando_nm = resultHash["BURANDO_NMK"].ToString();								   				// ブランド名
						f01m1VO.M1jisya_hbn = BoSystemFormat.formatJisyaHbn((string)resultHash["XEBIO_CD"].ToString());				// 自社品番
						f01m1VO.M1maker_hbn = resultHash["HIN_NBR"].ToString();										   				// メーカー品番
						f01m1VO.M1syonmk = resultHash["SYONMK"].ToString();											   				// 商品名
						f01m1VO.M1iro_nm = resultHash["IRO_NM"].ToString();											   				// 色
						f01m1VO.M1size_nm = resultHash["SIZE_NM"].ToString();										   				// サイズ
						f01m1VO.M1scan_cd = resultHash["JAN_CD"].ToString();										   				// JANコード
						f01m1VO.M1gen_tnk = resultHash["GENKA"].ToString();											   				// 原価

						// 登録情報をディクショナリに設定
						f01m1VO.Dictionary[Tb050p01Constant.DIC_M1SYOHIN_CD] = resultHash["SYOHIN_CD"].ToString();					// 商品コード
						f01m1VO.Dictionary[Tb050p01Constant.DIC_M1HINSYU_CD] = resultHash["HINSYU_CD"].ToString();					// 品種コード
						f01m1VO.Dictionary[Tb050p01Constant.DIC_M1SIIRESAKI_CD] = resultHash["SIIRESAKI_CD"].ToString();			// 仕入先コード
						f01m1VO.Dictionary[Tb050p01Constant.DIC_M1IRO_CD] = resultHash["MAKERCOLOR_CD"].ToString();					// 色コード
						f01m1VO.Dictionary[Tb050p01Constant.DIC_M1SIZE_CD] = resultHash["SIZE_CD"].ToString();						// サイズコード
						f01m1VO.Dictionary[Tb050p01Constant.DIC_M1SUBSIIRESAKI_CD] = resultHash["SUBSIIRESAKI_CD"].ToString();		// サブ仕入先コード
						f01m1VO.Dictionary[Tb050p01Constant.DIC_M1BURANDO_CD] = resultHash["BURANDO_CD"].ToString();				//ブランドコード
						f01m1VO.Dictionary[Tb050p01Constant.DIC_M1SLPR] = resultHash["SLPR"].ToString();							// 上代１（現売価）


						if(!string.IsNullOrEmpty(f01m1VO.M1kensu))
						{	// 原価金額
							genka_kin = Convert.ToDecimal(f01m1VO.M1kensu) * Convert.ToDecimal(f01m1VO.M1gen_tnk);
						}


						// 3-4 Ｍ１スキャンコード
						// 原単価がマイナスの場合、エラー
						if (Convert.ToDecimal(f01m1VO.M1gen_tnk) < 0)
						{
                            // 原価がマイナスの商品は入力できません。
                            ErrMsgCls.AddErrMsg("E146", string.Empty, facadeContext, new[] { "M1scan_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
                            continue;
						}

						// 3-5 Ｍ１スキャンコード
						// 承り品番の場合、エラー
						if ("5".Equals(resultHash["HINKBN"].ToString()))
						{
                            // 承り品番の商品は入力できません。
                            ErrMsgCls.AddErrMsg("E162", string.Empty, facadeContext, new[] { "M1scan_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
                            continue;
						}

						// 3-6 Ｍ１検数
						//    入力されていない場合、エラー
						if (string.IsNullOrEmpty(f01m1VO.M1kensu))
						{
                            // 検数を入力して下さい。
                            ErrMsgCls.AddErrMsg("E121", "検数", facadeContext, new[] { "M1kensu" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
                            continue;
						}

						// 3-7 Ｍ１検数
						//    0が入力された場合、エラー
						if ("0".Equals(f01m1VO.M1kensu))
						{
                            // 検数に0は入力できません。
                            ErrMsgCls.AddErrMsg("E103", "検数", facadeContext, new[] { "M1kensu" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
                            continue;
						}

						#region 関連項目チェック（明細部）

						// 4-1 Ｍ１検数
						//    [Ｍ１原単価]×[Ｍ１検数]＞999999999（９桁）の場合、エラー
						if (genka_kin > 999999999)
						{
                            // 検数に0は入力できません。
                            ErrMsgCls.AddErrMsg("E102", "原価金額", facadeContext, new[] { "M1kensu" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
                            continue;
						}

						#endregion

						// 原価金額の設定
						f01m1VO.M1genka_kin = genka_kin.ToString();
						f01m1VO.M1genka_kin_hdn = f01m1VO.M1genka_kin;

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

				for (int i = 0; i < m1List.Count; i++)
				{
					Tb050f01M1Form f01m1VO = (Tb050f01M1Form)m1List[i];

					// スキャンコードが入力されている場合
					if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd))
					{
						// [仕入確定一時TBL]を登録
						BoSystemLog.logOut("[仕入確定一時TBL]を登録 START");
						int Inscntrirekiakah = Ins_ShiireKakuteiTmp(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[仕入確定一時TBL]を登録 END  ");

					}
				}

				// ストアド呼び出し
				// ■仕入入荷確定登録処理呼び出し
				ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDPURCHASE_UPDATE.insertManual", new ArrayList());

				#region ■例外処理
				if (al != null && al.Count > 0)
				{
					// エラーコード
					string errCd = al[0].ToString();

					if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
					{
						// 正常終了
					}
					else if (errCd.Equals(BoSystemConstant.STORED_NUMBERING_ERR))
					{
						// 採番不可の場合
						ErrMsgCls.AddErrMsg("E230", string.Empty, facadeContext);
					}
					else
					{
						// それ以外の場合
						throw new SystemException("ストアド［MDPURCHASE_UPDATE.insertManual］実行時にエラーが発生しました。エラーコード：" + errCd);
					}
				}
				else
				{
					// OUTパラメータが取得できない場合
					throw new SystemException("ストアド［MDPURCHASE_UPDATE.insertManual］実行時にエラーが発生しました。");
				}
				#endregion

				//エラーが発生した場合、その時点で処理を中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion
				
				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 印刷処理

				// 帳票ID
				string chohyoId = BoSystemConstant.REPORTID_MANUALSIIREDENPYO;

				string pdfFileNm = string.Empty;

				ArrayList alCur = new ArrayList();

				if (al != null && al.Count >= 2)
				{
					alCur = (ArrayList)al[1];
				}

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				// 帳票出力帳票
				foreach (Hashtable rec in alCur)
				{

					// 会社コード
					inputData.AddScreenParameter(1, logininfo.CopCd);
					// 仕入先コード
					inputData.AddScreenParameter(2, BoSystemFormat.formatSiiresakiCd(rec["SIIRESAKI_CD"].ToString()));
					// 伝票番号
					inputData.AddScreenParameter(3, BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));
					// 指定納品日
					inputData.AddScreenParameter(4, BoSystemFormat.formatDate(rec["SITEINOHIN_YMD"].ToString()));
					// 店舗コード
					inputData.AddScreenParameter(5, BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));
					// 店舗控え出力フラグ
					inputData.AddScreenParameter(6, "1");

				}

				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(chohyoId),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												chohyoId,
												Tb050p01Constant.FORMID_01,
												Tb050p01Constant.PGID,
												pdfFileNm
												);

				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tb050p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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

		#region [仕入確定一時TBL]を登録
		/// <summary>
		/// [仕入確定一時TBL]の登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_ShiireKakuteiTmp(IFacadeContext facadeContext,
										Tb050f01Form f01Form,
										Tb050f01M1Form f01M1Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tb050p01Constant.SQL_ID_01, facadeContext.DBContext);

			reader.BindValue("BIND_KAKUTEI_SB", "1");																											// 3 確定種別
			reader.BindValue("BIND_SIIRE_CD", BoSystemFormat.formatSiiresakiCd((string)f01M1Form.Dictionary[Tb050p01Constant.DIC_M1SIIRESAKI_CD]));				// 4 仕入先コード
			reader.BindValue("BIND_DENPYO_BANGO", string.Empty);																								// 5 伝票番号
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01M1Form.M1tenpo_cd));																// 6 店舗コード
			reader.BindValue("BIND_SUBSIIRE_CD", BoSystemFormat.formatSiiresakiCd((string)f01M1Form.Dictionary[Tb050p01Constant.DIC_M1SUBSIIRESAKI_CD]));		// 7 サブ仕入先コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f01M1Form.M1bumon_cd));																// 8 部門コード
			reader.BindValue("BIND_BIKO_KB", Convert.ToDecimal(f01Form.Biko_kb));																				// 9 備考区分
			reader.BindValue("BIND_BIKO1", f01Form.Biko1);																										// 10 備考1
			reader.BindValue("BIND_BIKO2", f01Form.Biko2);																										// 11 備考2
			if (ConditionBiko_kbn.VALUE_BIKO_KBN2.Equals(f01Form.Biko_kb))
			{
				reader.BindValue("BIND_MOTO_BANGO", f01Form.Biko1);
			}
			else
			{
				reader.BindValue("BIND_MOTO_BANGO", string.Empty);
			}																																					// 12 元伝票番号
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);																								// 13 更新日
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);																							// 14 更新時間
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));																	// 15 更新担当者コード
			reader.BindValue("BIND_DENPYOGYO_NO", string.Empty);																								// 16 伝票行№
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(f01M1Form.Dictionary[Tb050p01Constant.DIC_M1HINSYU_CD].ToString()));							// 17 品種コード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f01M1Form.Dictionary[Tb050p01Constant.DIC_M1BURANDO_CD]));					// 18 ブランドコード
			reader.BindValue("BIND_MAKER_HBN", f01M1Form.M1maker_hbn);																							// 19 メーカー品番
			reader.BindValue("BIND_SYONMK", f01M1Form.M1syonmk);																								// 20 商品名(カナ)
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f01M1Form.M1jisya_hbn));															// 21 自社品番
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f01M1Form.Dictionary[Tb050p01Constant.DIC_M1IRO_CD]));							// 22 色コード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd((string)f01M1Form.Dictionary[Tb050p01Constant.DIC_M1SIZE_CD]));						// 23 サイズコード
			reader.BindValue("BIND_SIZE_NM", f01M1Form.M1size_nm);																								// 24 サイズ
			reader.BindValue("BIND_YOTEI_SU", 0);																												// 25 予定数量
			reader.BindValue("BIND_JISSEKI_SU", Convert.ToDecimal(f01M1Form.M1kensu));																			// 26 実績数量
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f01M1Form.M1scan_cd));																	// 27 ＪＡＮコード
			reader.BindValue("BIND_SYOHIN_CD", f01M1Form.Dictionary[Tb050p01Constant.DIC_M1SYOHIN_CD]);															// 28 商品コード
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(f01M1Form.M1gen_tnk));																			// 29 原単価
			reader.BindValue("BIND_JODAI1_TNK", Convert.ToDecimal(f01M1Form.Dictionary[Tb050p01Constant.DIC_M1SLPR].ToString()));								// 30 上代１
			reader.BindValue("BIND_KYAKUDEN_NO", "0");																											// 31 客注伝票番号
			reader.BindValue("BIND_KYAKUTYU_FLG", 0);																											// 32 客注フラグ
			reader.BindValue("BIND_INSTORE_FLG", 0);																											// 33 インストアフラグ
			reader.BindValue("BIND_NEGAKIHIN_FLG", 0);																											// 34 値書き品フラグ

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
