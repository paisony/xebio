using com.xebio.bo.Ti010p01.Constant;
using com.xebio.bo.Ti010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.ApiUtil;
using Common.Business.C99999.ApiUtil.Ncr010a01;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Ti010p01.Facade
{
  /// <summary>
  /// Ti010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ti010f01Facade : StandardBaseFacade
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
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

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
						
				// FormVO取得
				// 画面より情報を取得する。
				Ti010f01Form f01VO = (Ti010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

			

				#endregion

				#region 業務チェック

				// 1-1 ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー
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

				#region API起動

				// リクエストクラス
				ApiRequestVO<Ncr010a01RequestVO> reqVo = new ApiRequestVO<Ncr010a01RequestVO>();

				// ★暗号コード
				reqVo.HEADER.ANGOCD = null;
				// ★重複チェックフラグ
				reqVo.HEADER.CHOFUKUCHECKFLG = false;
				// ★リクエスト元のプラグラムID
				reqVo.HEADER.REQPROGRAM = Ti010p01Constant.PGID;

				// ■■APIパラメータ(ボディ)

				// 共通ヘッダの設定
				BoSystemApi.SetNcrHeader(reqVo.BODY);
				// 要求運用日付
				reqVo.BODY.REQUNYOUYMD = BoSystemFormat.formatDate(f01VO.Eigyo_ymd);
				// 要求店舗コード
				reqVo.BODY.REQTENCD = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
				// 要求POSNO
				reqVo.BODY.REQPOSNO = "0";
				// ■■API起動
				ApiResponseVO<Ncr010a01ResponseVO> resVo = BoSystemApi.RunApi<Ncr010a01RequestVO, Ncr010a01ResponseVO>(BoSystemConstant.API_PGID_KYAKUSU, reqVo, 1);



				// APIステータスの取得
				string errcd = resVo.ERROR.ERRORCD.ToString();
				string sKyakusu = "";
				if (resVo != null && errcd.Equals(BoSystemApi.APISTATUS_NOMAL))
				{
					// 正常の場合、客数取得
					Ncr010a01MesaiResponseVO resM1VO = (Ncr010a01MesaiResponseVO)resVo.BODY.MEISAI[0];
					sKyakusu = BoSystemString.Nvl(resM1VO.KYAKUSU.ToString());
				}
				else
				{
					// エラー発生時、空白とする。
					sKyakusu = "";
				}
				#endregion

				#region 印刷処理
				string pdfFileNm = "";


				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();
				#region ■帳票パラメータ設定

				// 店舗コード
				inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
				// 営業日
				inputData.AddScreenParameter(2, BoSystemFormat.formatDate(f01VO.Eigyo_ymd));
				// 客数
				inputData.AddScreenParameter(3, sKyakusu);
				#endregion


				// 印刷処理
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_BUMONBETUKANRIHYO),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_BUMONBETUKANRIHYO,
												Ti010p01Constant.FORMID_01,
												Ti010p01Constant.PGID,
												pdfFileNm
												);
						 

				if (output.ReportState == ReportState.DataNotFound)
				{
					// 検索結果が0件の場合エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Ti010p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
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
