using com.xebio.bo.Td050p01.Constant;
using com.xebio.bo.Td050p01.Formvo;
using com.xebio.bo.Td050p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Td050p01.Facade
{
  /// <summary>
  /// Td050f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td050f02Facade : StandardBaseFacade
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
				Td050f02Form f02VO = (Td050f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Td050f01M1Form f01M1Form = (Td050f01M1Form)f02VO.Dictionary[Td050p01Constant.DIC_M1SELCETVO];


				#endregion
				#region 業務チェック
				// 行数チェック
				ChkRowCount(facadeContext, m1List);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 単項目チェック
				decimal[] dSumList = ChkUpdSingleItem(facadeContext, f02VO, m1List, f01M1Form);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 排他チェック
				ChkUpdHaita(facadeContext, f02VO, f01M1Form);
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 更新処理
				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				decimal denno = 0;
				// 明細検索用伝票No取得
				if (string.IsNullOrEmpty((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1KURODENPYO_BANGO]))
				{
					denno = Convert.ToDecimal((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1MOTODENPYO_BANGO]); ;
				}
				else
				{
					denno = Convert.ToDecimal((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1KURODENPYO_BANGO]);
				}

				// 赤伝票番号採番
				decimal dAkaDenno = Td050p01Util.AutoNumber_HenpinDenNo(facadeContext
																	, f02VO.Head_tenpo_cd
																	, (string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD]
																	, logininfo);
				if (dAkaDenno < 0)
				{
					// 採番不可。
					ErrMsgCls.AddErrMsg("E230", String.Empty, facadeContext);
					return;
				}
				// 黒伝票番号採番
				decimal dKuroDenno = Td050p01Util.AutoNumber_HenpinDenNo(facadeContext
																	, f02VO.Head_tenpo_cd
																	, (string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD]
																	, logininfo);
				if (dKuroDenno < 0)
				{
					// 採番不可。
					ErrMsgCls.AddErrMsg("E230", String.Empty, facadeContext);
					return;
				}
				// [返品確定TBL(H)]を更新する。(新黒以外)
				BoSystemLog.logOut("[返品確定TBL(H)]を更新 START");
				int updcnth = Td050p01Util.Upd_HenpinKakuteih(facadeContext, f01M1Form, logininfo, sysDateVO, false, denno);
				BoSystemLog.logOut("[返品確定TBL(H)]を更新 END");

				#region  赤伝票
				// [返品確定TBL(B)]を登録する。
				BoSystemLog.logOut("[返品確定TBL(H)]を登録（赤伝票） START");
				int Inscntb_aka = Ins_HenpinKakuteib_sel(facadeContext, f01M1Form, logininfo, sysDateVO, denno, dAkaDenno);
				BoSystemLog.logOut("[返品確定TBL(H)]を登録（赤伝票） END");

				// [返品確定TBL(h)]を登録する。
				BoSystemLog.logOut("[返品確定TBL(H)]を登録（赤伝票） START");
				int Inscnth_aka = Ins_HenpinKakuteih_sel(facadeContext, f01M1Form, logininfo, sysDateVO, false, true, f02VO.Biko, denno, dAkaDenno);
				BoSystemLog.logOut("[返品確定TBL(H)]を登録（赤伝票） END");

				// [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。(確定で作った赤の伝票なので履歴的には黒)
				BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録（赤伝票） START");
				int Inscntrirekih_aka = Td050p01Util.Ins_HenpinRirekih(facadeContext, f01M1Form, logininfo, sysDateVO, false, Td050p01Util.GetShori_sb((String)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SOSINZUMI_FLG]), dAkaDenno);
				BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録（赤伝票） END");

				// [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。(確定で作った赤の伝票なので履歴的には黒)
				BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録（赤伝票） START");
				int Inscntrirekib_aka = Td050p01Util.Ins_HenpinRirekib(facadeContext, f01M1Form, logininfo, sysDateVO, false, dAkaDenno);
				BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録（赤伝票） END");
				#endregion

				#region  黒伝票
				// [返品確定TBL(H)]を登録する。
				BoSystemLog.logOut("[返品確定TBL(H)]を登録（黒伝票） START");
				int Inscnth_kuro = Ins_HenpinKakuteih(facadeContext, f01M1Form, f02VO, logininfo, sysDateVO, denno, dKuroDenno);
				BoSystemLog.logOut("[返品確定TBL(H)]を登録（黒伝票） END");

				// [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。
				BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録（黒伝票） START");
				int Inscntrirekih_kuro = Td050p01Util.Ins_HenpinRirekih(facadeContext, f01M1Form, logininfo, sysDateVO, false, Td050p01Util.GetShori_sb((String)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SOSINZUMI_FLG]), dKuroDenno);
				BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録（黒伝票） END");

				// 明細単位で以下の処理を実施する。
				foreach (Td050f02M1Form f02m1VO in m1List.ListData)
				{
					// スキャンコードが設定されているもの
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
					{
						// [返品確定TBL(B)]を登録する。
						BoSystemLog.logOut("[返品確定TBL(B)]を登録（黒伝票） START");
						int Inscntb_kuro = Ins_HenpinKakuteib(facadeContext, f01M1Form, f02VO, f02m1VO, logininfo, sysDateVO, dKuroDenno);
						BoSystemLog.logOut("[返品確定TBL(B)]を登録（黒伝票） END");
					}
				}
				// [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。
				BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録（赤伝票） START");
				int Inscntrirekib_kuro = Td050p01Util.Ins_HenpinRirekib(facadeContext, f01M1Form, logininfo, sysDateVO, false, dKuroDenno);
				BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録（赤伝票） END");

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
				#endregion

				#region 印刷処理
				string pdfFileNm = "";

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				// 検索区分(1:伝票番号で検索、2:元伝票番号で検索)
				inputData.AddScreenParameter(1, "2");
				// 店舗コード
				inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
				// 元伝票番号
				//inputData.AddScreenParameter(3, f02VO.Denpyo_bango);
				inputData.AddScreenParameter(3, denno.ToString());
				// 処理日
				inputData.AddScreenParameter(4, f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD].ToString());
				// 店舗控え印刷フラグ
				inputData.AddScreenParameter(5, "1");

				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// PDFファイル名(TD050L01_YYYYMMDDHHMMSSSSS_ログイン情報.[会社コード]_ログイン情報.[所属店舗コード]_ログイン情報.[担当者コード].pdf)
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HENPINTEISEIDENPYO),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_HENPINTEISEIDENPYO,
												Td050p01Constant.FORMID_02,
												Td050p01Constant.PGID,
												pdfFileNm
												);

				// PDFファイルをユーザマップに設定
				facadeContext.SetUserObject(Td050p01Constant.FCDUO_PRT_FLNM, pdfFileNm);
				#endregion
				#region 画面表示
				// 明細情報を更新する。
				f01M1Form.M1teisei_suryo = dSumList[0].ToString();						// 訂正数　　　		←　合計訂正数量
				f01M1Form.M1genkakin = dSumList[1].ToString();							// 原価金額　　		←　合計金額
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;		// Ｍ１確定処理フラグ(隠し)
				f01M1Form.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;				// Ｍ１明細色区分(隠し)

				// 明細リンク用情報更新
				f01M1Form.Dictionary.Remove(Td050p01Constant.DIC_M1KURODENPYO_BANGO);
				f01M1Form.Dictionary.Add(Td050p01Constant.DIC_M1KURODENPYO_BANGO, dKuroDenno.ToString());    // Ｍ１黒伝票番号

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
	}
}
