using com.xebio.bo.Tj170p01.Constant;
using com.xebio.bo.Tj170p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Tj170p01.Facade
{
  /// <summary>
  /// Tj170f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj170f01Facade : StandardBaseFacade
	{

		#region フォームを呼び出します。(ボタンID : Btnprint)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNPRINT_FRM(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

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
				Tj170f01Form f01VO = (Tj170f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック
				//	選択行が存在しない場合はエラー		
				if (m1List == null || m1List.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tj170f01M1Form f01m1VO = (Tj170f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
					}
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 印刷処理
				// 帳票ツールに渡すパラメータを格納	
				InputData inputData = new InputData();

				#region 検索条件

				//  店舗コード
				string tenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

				//  棚卸期間フラグ	
				string kikanFlg = string.Empty;
				if (BoSystemConstant.MODE_KONKAI.Equals(f01VO.Stkmodeno))
				{
					kikanFlg = "1";
				}
				else
				{
					kikanFlg = "2";
				}

				//  棚卸日
				string tanaoroshiYmd = string.Empty;
				if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KONKAI))
				{
					tanaoroshiYmd = BoSystemFormat.formatDate(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Tanaorosikijun_ymd)].ToString());
				}
				else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_ZENKAI))
				{
					tanaoroshiYmd = BoSystemFormat.formatDate(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Tanaorosikijun_ymd1)].ToString());
				}

				//  部門コード||品種コードFROM
				String sBumonCdFrom = BoSystemFormat.formatBumonCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Bumon_cd_from)].ToString());
				String sHInshuCdFrom = BoSystemFormat.formatHinsyuCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Hinsyu_cd_from)].ToString());
				// [部門コードFROM]が入力されていない場合"000"に置き換える。[品種コードFROM]が入力されていない場合"00"に置き換える。
				if (string.IsNullOrEmpty(sBumonCdFrom))
				{
					sBumonCdFrom = "000";
				}
				if (string.IsNullOrEmpty(sHInshuCdFrom))
				{
					sHInshuCdFrom = "00";
				}
				string bumonHinsyuFrom = sBumonCdFrom + sHInshuCdFrom;

				//  部門コード||品種コードFROM
				String sBumonCdTo = BoSystemFormat.formatBumonCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Bumon_cd_to)].ToString());
				String sHInshuCdTo = BoSystemFormat.formatHinsyuCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Hinsyu_cd_to)].ToString());
				// [部門コードTO]が入力されていない場合"000"に置き換える。[品種コードTO]が入力されていない場合"00"に置き換える。
				if (string.IsNullOrEmpty(sBumonCdTo))
				{
					sBumonCdTo = "999";
				}
				if (string.IsNullOrEmpty(sHInshuCdTo))
				{
					sHInshuCdTo = "99";
				}
				string bumonHinsyuTo = sBumonCdTo + sHInshuCdTo;

				//  商品群1
				string syohingun1Cd = BoSystemFormat.formatSyohingunCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syohingun1_cd)].ToString());

				//  商品群2
				string syohingun2Cd = BoSystemFormat.formatSyohingun2Cd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Syohingun2_cd)].ToString());

				//  ブランドコード
				string brandCd = BoSystemFormat.formatBrandCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Burando_cd)].ToString());

				//  ロス点数
				string lossSu = BoSystemFormat.formatBrandCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Loss_tensu)].ToString());

				//  ロス有りフラグ
				string lussFlg = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Loss_ari_flg)].ToString();

				//  商品群/出力単位 	
				string shuturyokuTani = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Shuturyoku_tani)].ToString();

				//  ソート順			
				string sort = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Sort_jun)].ToString();
				#endregion

				#region パラメータ設定
				///棚卸ロスリスト クエリプラグインです。
				/// ■パラメータ
				/// ① 店舗コード
				/// ② 棚卸期間フラグ	(1:今回、2:前回)
				/// ③ 棚卸日
				/// ④ 商品群1
				/// ⑤ 商品群2
				/// ⑥ 部門コード||品種コードFROM
				/// ⑦ 部門コード||品種コードFROM
				/// ⑧ ブランドコード
				/// ⑨ ロス点数
				/// ⑩ ロス有りフラグ
				/// ⑪ 出力単位 	(1:商品群１ 2:商品群２ 3:部門)
				/// ⑫ ソート順		(1:商品分類順 2:ロス点数 3:ロス金額 4:メーカー品番)
				/// ⑬ M1商品群1コード
				/// ⑭ M1商品群2コード
				/// ⑮ M1部門コード

				inputData.AddScreenParameter(1, tenpoCd);
				inputData.AddScreenParameter(2, kikanFlg);
				inputData.AddScreenParameter(3, tanaoroshiYmd);
				inputData.AddScreenParameter(4, syohingun1Cd);
				inputData.AddScreenParameter(5, syohingun2Cd);
				inputData.AddScreenParameter(6, bumonHinsyuFrom);
				inputData.AddScreenParameter(7, bumonHinsyuTo);
				inputData.AddScreenParameter(8, brandCd);
				inputData.AddScreenParameter(9, lossSu);
				inputData.AddScreenParameter(10, lussFlg);
				inputData.AddScreenParameter(11, shuturyokuTani);
				inputData.AddScreenParameter(12, sort);

				#endregion

				#region 明細選択情報
				string m1Syohingun1Cd = string.Empty;
				string m1Syohingun2Cd = string.Empty;
				string m1bumonCd = string.Empty;
				for (int i = 0; i < m1List.Count; i++)
				{
					Tj170f01M1Form f01m1VO = (Tj170f01M1Form)m1List[i];
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						m1Syohingun1Cd = BoSystemFormat.formatSyohingunCd(f01m1VO.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_CD].ToString());
						m1Syohingun2Cd = BoSystemFormat.formatSyohingun2Cd(f01m1VO.M1syohingun2_cd);
						m1bumonCd = BoSystemFormat.formatBumonCd(f01m1VO.M1bumon_cd);
						inputData.AddScreenParameter(13, m1Syohingun1Cd);
						inputData.AddScreenParameter(14, m1Syohingun2Cd);
						inputData.AddScreenParameter(15, m1bumonCd);

					}
				}

				#endregion

				// 帳票を出力
				string pdfFileNm = "";
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				#region 棚卸ロスリスト
				if (f01VO.Shuturyoku_print.Equals(ConditionShuturyoku_print.VALUE_SHUTURYOKU_PRINT1))
				{
					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSILOSSLIST),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_TANAOROSILOSSLIST,
												Tj170p01Constant.FORMID_01,
												Tj170p01Constant.PGID,
												pdfFileNm
												);
				}
				#endregion

				#region 棚卸ロスリストサマリ
				else if (f01VO.Shuturyoku_print.Equals(ConditionShuturyoku_print.VALUE_SHUTURYOKU_PRINT2))
				{
					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSILOSSLISTSUMMARY),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_TANAOROSILOSSLISTSUMMARY,
													Tj170p01Constant.FORMID_01,
													Tj170p01Constant.PGID,
													pdfFileNm
													);
				}

				if (output.ReportState == ReportState.DataNotFound)
				{
					// 検索結果が0件の場合エラー
					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj170p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				#endregion


				#endregion
			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

		}
		#endregion
	}
}
