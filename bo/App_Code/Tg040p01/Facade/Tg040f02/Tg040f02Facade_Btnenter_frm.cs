using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01004;
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

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f02Facade : StandardBaseFacade
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
				// FormVO取得
				// 画面より情報を取得する。
				Tg040f02Form f02VO = (Tg040f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Tg040f01M1Form f01m1VO = (Tg040f01M1Form)f02VO.Dictionary[Tg040p01Constant.FCDUO_FOCUSITEM];

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// スキャンコード取得
				ArrayList M1ScanCd = new ArrayList();
				M1ScanCd = GetM1ScanCd(m1List, M1ScanCd);

				// 印刷パラメータ
				ArrayList printPara = new ArrayList();
				#endregion

				#region 業務チェック

				#region 1-1 件数チェック
				// Ｍ１スキャンコード：スキャンコードが1件も入力されていない場合、エラー
				decimal dscanCnt = 0;	// スキャンコードカウンタ
				int iRow;
				for (iRow = 0; iRow < m1List.Count; iRow++)
				{
					// 明細情報取得
					Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1List[iRow];
					
					// スキャンコードが未入力の場合
					if (string.IsNullOrEmpty(f02m1VO.M1scan_cd))
					{
						dscanCnt ++;
					}
				}
				if (iRow == dscanCnt)
				{
					ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
				}
			
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 1-2 入力値チェック
				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細情報取得
					Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1List[i];

					// スキャンコードか数量が入力されている行がチェック対象
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd) || !string.IsNullOrEmpty(f02m1VO.M1suryo))
					{
						//Ｍ１スキャンコード：発注MSTに存在しない場合、エラー
						SearchHachuVO searchConditionVO = new SearchHachuVO(
							f02m1VO.M1scan_cd,		// スキャンコード
							f02VO.Head_tenpo_cd,	// 店舗コード
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
                m1List.DispRow);

						if (syohinData != null)
						{
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1BURANDO_CD] = syohinData["BURANDO_CD"];	// Ｍ１ブランドコード
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1IRO_CD] = syohinData["MAKERCOLOR_CD"];	// Ｍ１色コード
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SIZE_CD] = syohinData["SIZE_CD"];			// Ｍ１サイズコード
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SYOHIN_CD] = syohinData["SYOHIN_CD"];		// Ｍ１商品コード

							// 新規作成用
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1BUMON_CD] = syohinData["BUMON_CD"];		// Ｍ１部門コード
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HINSYU_CD] = syohinData["HINSYU_CD"];		// Ｍ１品種コード
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1XEBIO_CD] = syohinData["XEBIO_CD"];		// Ｍ１自社品番
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HIN_NBR] = syohinData["HIN_NBR"];			// Ｍ１メーカー品番
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SYONMK] = syohinData["SYONMK"];			// Ｍ１商品名(カナ)
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HANBAIKANRYO_YMD] = syohinData["HANBAIKANRYO_YMD"];	// Ｍ１販売完了日
							f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SIZE_NM] = syohinData["SIZE_NM"];			// サイズ略名称カナ
						}

						//Ｍ１数量：入力されていない場合、エラー
						if (string.IsNullOrEmpty(f02m1VO.M1suryo))
						{
							ErrMsgCls.AddErrMsg("E121",
												"数量",
												facadeContext,
												new[] { "M1suryo" },
												f02m1VO.M1rowno,
												(i).ToString(),
                        "M1",
                        m1List.DispRow);
            }

                        //Ｍ１数量：入力した数量が"0"の場合、エラー
            if (("0").Equals(f02m1VO.M1suryo))
						{
							ErrMsgCls.AddErrMsg("E103",
												"数量",
												facadeContext,
												new[] { "M1suryo" },
												f02m1VO.M1rowno,
												(i).ToString(),
                        "M1",
                        m1List.DispRow);
                        }

                        //数量・スキャンコード：数量が入力されていてスキャンコードが入力れされていない場合エラー
                        if (!string.IsNullOrEmpty(f02m1VO.M1suryo) && string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							ErrMsgCls.AddErrMsg("E121",
												"スキャンコード",
												facadeContext,
												new[] { "M1scan_cd" },
												f02m1VO.M1rowno,
												(i).ToString(),
                        "M1",
                        m1List.DispRow);
                        }
                    }
				}

				//エラーが発生した場合、次明細をチェックする。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 1-3 関連チェック
				decimal dsuryoSum = 0;	// 数量計算
				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細情報取得
					Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1List[i];

					// スキャンコードが入力されている行がチェック対象
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
					{
						if (!CheckInsert(f02VO))
						{	//[商品ｽﾄｯｸ明細書発行－一覧.[日付リンク]]により遷移した場合
							// Ｍ１スキャンコード：修正時、同一のスキャンコードが複数存在する場合、エラー
							decimal hitCnt = 0;
							for (int iScanIndex = 0; iScanIndex < M1ScanCd.Count; iScanIndex++)
							{
								// 画面に表示されているスキャンコードが２件以上存在する場合
								if (f02m1VO.M1scan_cd.Equals(M1ScanCd[iScanIndex]))
								{
									hitCnt++;
								}
							}
							if (hitCnt >= 2)
							{
								ErrMsgCls.AddErrMsg("E130",
													string.Empty,
													facadeContext,
													new[] { "M1scan_cd" },
													f02m1VO.M1rowno,
													(i).ToString(),
                          "M1",
                          m1List.DispRow);
                            }
                        }
						else
						{	// [商品ｽﾄｯｸ明細書発行－一覧.[新規作成]]により遷移した場合
							// Ｍ１数量：新規登録の場合、スキャンコード単位の数量の合計が9桁を超える場合、エラー
							
							// 同一スキャンコード処理
							for (int iScanIndex = 0; iScanIndex < M1ScanCd.Count; iScanIndex++)
							{
								if (f02m1VO.M1scan_cd.Equals(M1ScanCd[iScanIndex]))
								{
									// 本ループとキャンコード処理が同一の場合のみ
									if (i == iScanIndex)
									{ 
										dsuryoSum += Convert.ToDecimal(f02m1VO.M1suryo);
									}
								}
							}

							// 数量の合計が4桁を超える場合
							if (dsuryoSum.ToString().Length > 4)
							{
								ErrMsgCls.AddErrMsg("E102",
													"数量",
													facadeContext,
													new[] { "M1suryo" },
													f02m1VO.M1rowno,
													(i).ToString(),
                          "M1",
                          m1List.DispRow);
                            }
                        }
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				#endregion

				#endregion

				#region 排他チェック
				// [商品ｽﾄｯｸ明細書発行－一覧.[日付リンク]]により遷移した場合、排他チェックを行う。
				if (!CheckInsert(f02VO))
				{
					for (int ii = 0; ii < m1List.Count; ii++)
					{
						Tg040f02M1Form f02m1VO_Haita = (Tg040f02M1Form)m1List[ii];

						// 選択行の場合
						if (f02m1VO_Haita.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							StringBuilder sRepSql = new StringBuilder();
							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗コード
							sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPO_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd.ToString());
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 管理No
							sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_KANRI_NO";
							bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f02VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO]);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 処理日付
							sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYORI_YMD";
							bindVO.Value = (string)f02VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal((string)f02VO.Dictionary[Tg040p01Constant.DIC_UPD_YMD]),
									Convert.ToDecimal((string)f02VO.Dictionary[Tg040p01Constant.DIC_UPD_TM]),
									facadeContext,
									"MDBT0020",
									sRepSql.ToString(),
									bindList,
									1,
									null,
									f02m1VO_Haita.M1rowno,
									ii.ToString(),
									"M1",
									100
							);

							// ＳＱＬ文初期化
							sRepSql.Length = 0;
						}
					}
				}
				
				#endregion

				#region 更新処理
				if (CheckInsert(f02VO))
				{	// [商品ｽﾄｯｸ明細書発行－一覧.[新規作成]]により遷移した場合
					for (int i = 0; i < m1List.Count; i++)
					{
						Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1List[i];

						// [Ｍ１スキャンコード]が入力されていた場合
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							// [商品明細書一時TBL]を登録する。
							int InscntMDBT0020tmp_1 = Ins_MDBT0020tmp(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
						}
					}

					// ストアド(商品明細書(H)(B)、 新規更新)を起動する。
					printPara = prcInsertBackStockNew(facadeContext, f02VO);

					//エラーが発生した場合、その時点で処理を中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				else
				{	// [商品ｽﾄｯｸ明細書発行－一覧.[日付リンク]]により遷移した場合
					// [商品明細書TBL(H)]を更新する。
					int UpdcntMDBT0020_1 = Upd_MDBT0020(facadeContext, f02VO, sysDateVO, logininfo);

					// [商品明細書TBL(B)]を削除する。
					int DelcntMDBT0021_2 = Del_MDBT0021(facadeContext, f02VO);

					for (int i = 0; i < m1List.Count; i++)
					{
						Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1List[i];

						// [Ｍ１スキャンコード]が入力されていた場合
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							// [商品明細書TBL(B)]を登録する。
							int InscntMDBT0020_3 = Ins_MDBT0021(facadeContext, f02VO, f02m1VO);
						}
					}
				}

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
				#endregion

				#region 印刷処理
				string pdfFileNm = "";

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				// 新規作成の場合
				if (CheckInsert(f02VO))
				{
					foreach (Hashtable ht in printPara)
					{
						// 店舗コード
						inputData.AddScreenParameter(1, (string)f02VO.Head_tenpo_cd);
						// 管理No 
						inputData.AddScreenParameter(2, ht["KANRI_NO"].ToString());
						// 処理日付
						inputData.AddScreenParameter(3, ht["SYORI_YMD"].ToString());
					}
				}
				else
				{
					// 店舗コード
					inputData.AddScreenParameter(1, (string)f02VO.Head_tenpo_cd);
					// 管理No 
					inputData.AddScreenParameter(2, f02VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO].ToString());
					// 処理日付
					inputData.AddScreenParameter(3, f02VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD].ToString());
				}

				// 帳票を出力
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
								BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINSTOCKMEISAISYO),
								BoSystemConstant.RPT_PDF_EXTENSION
							);

				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
							BoSystemConstant.REPORTID_SYOHINSTOCKMEISAISYO,
							Tg040p01Constant.FORMID_01,
							Tg040p01Constant.PGID,
							pdfFileNm
						);

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg040p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
				#endregion

				#region 一覧画面項目の設定
				// 日付リンクの場合
				if (!CheckInsert(f02VO))
				{ 
					// Ｍ１日付リンク
					f01m1VO.Dictionary[Tg040p01Constant.DIC_M1YMD] = BoSystemFormat.formatDate(f02VO.Dictionary[Tg040p01Constant.DIC_M1YMD_DISP].ToString(), 1);
				
					// Ｍ１時間
					f01m1VO.M1tm = BoSystemFormat.formatTime(f02VO.Dictionary[Tg040p01Constant.DIC_M1TM_DISP].ToString().ToString());

					// Ｍ１担当者名
					f01m1VO.M1hanbaiin_nm = logininfo.TtsMei;

					// Ｍ１数量
					f01m1VO.M1suryo = f02VO.Gokei_suryo.ToString();

					// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;
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

		#region 入力値スキャンコードを取得
		/// <summary>
		/// 画面に表示されているスキャンコードを取得
		/// </summary>
		/// <param name="m1List">明細リスト</param>
		/// <param name="M1ScanCd">Ｍ１スキャンコード</param>
		private static ArrayList GetM1ScanCd(IDataList m1List, ArrayList M1ScanCd)
		{
			for (int index = 0; index < m1List.Count; index++)
			{
				Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1List[index];

				// Ｍ１スキャンコード
				M1ScanCd.Add(f02m1VO.M1scan_cd);
			}

			return M1ScanCd;
		}

		#endregion

		#region 新規作成チェック
		/// <summary>
		/// 画面遷移トリガが「新規作成」であるかチェックを行う
		/// </summary>
		/// <param name="m1List">明細リスト</param>
		/// <param name="M1ScanCd">Ｍ１スキャンコード</param>
		private static Boolean CheckInsert(Tg040f02Form f02VO)
		{
			// 以下の項目が空白の場合、遷移元は「新規作成」がトリガ
			// ストック№・日付・時間・入力担当者コード・入力担当者コード

			if (    !string.IsNullOrEmpty(f02VO.Stock_no)
				 && !string.IsNullOrEmpty(f02VO.Ymd)
				 && !string.IsNullOrEmpty(f02VO.Tm)
				 && !string.IsNullOrEmpty(f02VO.Nyuryokutan_cd)
				 && !string.IsNullOrEmpty(f02VO.Nyuryokutan_nm))
			{
				return false;
			}

			return true;
		}

		#endregion

		#region ストアド(商品明細書(H)(B)、 新規更新)を起動
		/// <summary>
		/// ストアド(商品明細書(H)(B)、 新規更新)を起動する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>エラーコード</returns>
		public static ArrayList prcInsertBackStockNew(IFacadeContext facadeContext, Tg040f02Form f02VO)
		{
			#region ■パラメータ設定
			ArrayList paramList = new ArrayList();

			#endregion

			// ■商品明細書(H)(B)、 新規更新処理呼び出し
			ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDOTHER.insertBackStockNew", paramList);

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
					return al;
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［MDOTHER.insertBackStockNew］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［MDOTHER.insertBackStockNew］実行時にエラーが発生しました。");
			}
			#endregion

			// 印刷用パラメータ設定
			ArrayList alResult = (ArrayList)al[1];

			return alResult;
		}
		#endregion

		#region 商品明細書一時ＴＢＬ＿登録
		/// <summary>
		/// 商品明細書一時ＴＢＬ＿登録
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		private int Ins_MDBT0020tmp(IFacadeContext facadeContext, Tg040f02Form f02VO, Tg040f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tg040p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 登録日
			reader.BindValue("BIND_SYSDATE", sysDateVO.Sysdate);

			// 登録時間
			reader.BindValue("BIND_SYSTIME", sysDateVO.Systime_mili);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd.ToString()));

			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(logininfo.TtsCd.ToString()));

			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1BUMON_CD].ToString()));

			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HINSYU_CD].ToString()));
			
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1BURANDO_CD].ToString()));
			
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1XEBIO_CD].ToString()));
			
			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HIN_NBR].ToString());
			
			// 商品名(カナ)
			reader.BindValue("BIND_SYONMK", f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SYONMK].ToString());
			
			// 販売完了日
			reader.BindValue("BIND_HANBAIKANRYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HANBAIKANRYO_YMD].ToString())));
			
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1IRO_CD].ToString()));
			
			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SIZE_CD].ToString()));
			
			// サイズ名
			reader.BindValue("BIND_SIZE_NM", f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SIZE_NM].ToString());
			
			// ＪＡＮコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd.ToString()));
			
			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SYOHIN_CD].ToString());
			
			// 予定数量
			reader.BindValue("BIND_YOTEI_SU", Convert.ToDecimal(f02m1VO.M1suryo));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 商品明細書ＴＢＬ（Ｈ）＿更新
		/// <summary>
		/// 商品明細書ＴＢＬ（Ｈ）＿更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		private int Upd_MDBT0020(IFacadeContext facadeContext, Tg040f02Form f02VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tg040p01Constant.SQL_ID_07, facadeContext.DBContext);

			#region 更新部
			// 合計予定数量
			reader.BindValue("BIND_GOKEIYOTEI_SU", Convert.ToDecimal(f02VO.Gokei_suryo));
			
			// 更新日
			reader.BindValue("BIND_SYSDATE_UPD", sysDateVO.Sysdate);
			f02VO.Dictionary[Tg040p01Constant.DIC_M1YMD_DISP] = sysDateVO.Sysdate.ToString();

			// 更新時間
			reader.BindValue("BIND_SYSTIME", sysDateVO.Systime_mili);
			f02VO.Dictionary[Tg040p01Constant.DIC_M1TM_DISP] = sysDateVO.Systime_mili.ToString();
			
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd.ToString()));
			
			// 削除日
			reader.BindValue("BIND_SYSDATE_DEL", sysDateVO.Sysdate);
			#endregion

			#region 条件部
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd.ToString()));

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f02VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO].ToString()));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f02VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD].ToString()));
			#endregion

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 商品明細書ＴＢＬ（Ｂ）＿削除
		/// <summary>
		/// 評価損申請ＴＢＬ＿更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		private int Del_MDBT0021(IFacadeContext facadeContext, Tg040f02Form f02VO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tg040p01Constant.SQL_ID_08, facadeContext.DBContext);

			#region 条件部
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd.ToString()));

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f02VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO].ToString()));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f02VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD].ToString()));
			#endregion

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 商品明細書ＴＢＬ（Ｂ）＿登録
		/// <summary>
		/// 評価損申請ＴＢＬ＿更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		private int Ins_MDBT0021(IFacadeContext facadeContext, Tg040f02Form f02VO, Tg040f02M1Form f02m1VO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tg040p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd.ToString()));

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f02VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO].ToString()));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f02VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD].ToString()));

			// 処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal(f02VO.Dictionary[Tg040p01Constant.DIC_SYORI_TM].ToString()));

			// 行№
			reader.BindValue("BIND_GYO_NO", Convert.ToDecimal(f02m1VO.M1rowno));

			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1BUMON_CD].ToString()));

			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HINSYU_CD].ToString()));

			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1BURANDO_CD].ToString()));

			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1XEBIO_CD].ToString()));

			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HIN_NBR].ToString());

			// 商品名(カナ)
			reader.BindValue("BIND_SYONMK", f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SYONMK].ToString());

			// 販売完了日
			reader.BindValue("BIND_HANBAIKANRYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1HANBAIKANRYO_YMD].ToString())));

			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1IRO_CD].ToString()));

			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd(f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SIZE_CD].ToString()));

			// サイズ
			reader.BindValue("BIND_SIZE_NM", f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SIZE_NM].ToString());

			// ＪＡＮコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd.ToString()));

			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SYOHIN_CD].ToString());

			// 予定数量
			reader.BindValue("BIND_YOTEI_SU", Convert.ToDecimal(f02m1VO.M1suryo));

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
