using com.xebio.bo.Tc010p01.Constant;
using com.xebio.bo.Tc010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03001;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Tc010p01.Facade
{
  /// <summary>
  /// Tc010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tc010f01Facade : StandardBaseFacade
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

			////メソッドの開始処理を実行する。
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
				Tc010f01Form f01VO = (Tc010f01Form)facadeContext.FormVO;
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
			
			
				// 2 関連チェック
				// 2-1 入荷予定日FROM、入荷予定日TO
				//       入荷予定日ＦＲＯＭ > 入荷予定日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_from) && !string.IsNullOrEmpty(f01VO.Nyukayotei_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Nyukayotei_ymd_from,
									f01VO.Nyukayotei_ymd_to,
									facadeContext,
									"入荷予定日",
									new[] { "Nyukayotei_ymd_from", "Nyukayotei_ymd_to" }
									);
				}
			
				// 2-2 仕入確定日FROM、仕入確定日TO
				//       仕入確定日ＦＲＯＭ > 仕入確定日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_from) && !string.IsNullOrEmpty(f01VO.Siire_kakutei_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Siire_kakutei_ymd_from,
									f01VO.Siire_kakutei_ymd_to,
									facadeContext,
									"仕入確定日",
									new[] { "Siire_kakutei_ymd_from", "Siire_kakutei_ymd_to" }
									);
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
			
				#endregion


				#region 印刷処理
				string pdfFileNm = "";


				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();
				#region ■帳票パラメータ設定

				string ymdFrom1 = string.Empty;
				string ymdTo1 = string.Empty;
				string ymdFrom2 = string.Empty;
				string ymdTo2 = string.Empty;

				// 伝票状態が入荷済みの場合
				if(f01VO.Denpyo_jyotai == ConditionKyakuchu_denpyo_jotai.VALUE_KYAKUCHU_DENPYO_JOTAI1)
				{
					ymdFrom1 = BoSystemFormat.formatDate(f01VO.Siire_kakutei_ymd_from);		//このままだと処理時間まで入ってる
					ymdTo1 = BoSystemFormat.formatDate(f01VO.Siire_kakutei_ymd_to);
				}
				// 伝票状態が未入荷の場合
				else if(f01VO.Denpyo_jyotai == ConditionKyakuchu_denpyo_jotai.VALUE_KYAKUCHU_DENPYO_JOTAI2)
				{
					ymdFrom2 = BoSystemFormat.formatDate(f01VO.Nyukayotei_ymd_from);
					ymdTo2 = BoSystemFormat.formatDate(f01VO.Nyukayotei_ymd_to);
				}
				// 伝票状態が空白の場合
				else if (f01VO.Denpyo_jyotai == BoSystemConstant.DROPDOWNLIST_MISENTAKU)
				{
					ymdFrom1 = BoSystemFormat.formatDate(f01VO.Siire_kakutei_ymd_from);
					ymdTo1 = BoSystemFormat.formatDate(f01VO.Siire_kakutei_ymd_to);
					ymdFrom2 = BoSystemFormat.formatDate(f01VO.Nyukayotei_ymd_from);
					ymdTo2 = BoSystemFormat.formatDate(f01VO.Nyukayotei_ymd_to);
				}
				



				// 店舗コード
				inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
				// 仕入確定日FROM
				inputData.AddScreenParameter(2, ymdFrom1);
				// 仕入確定日TO
				inputData.AddScreenParameter(3, ymdTo1);
				// 状態
				if (f01VO.Denpyo_jyotai.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 未選択の場合、0を設定
					inputData.AddScreenParameter(4, "0");
				}
				else
				{
					inputData.AddScreenParameter(4, f01VO.Denpyo_jyotai);
				}
				// 会社コード(ゼビオかそれ以外か)
				inputData.AddScreenParameter(5, BoSystemFormat.formatKaisyaCd(logininfo.CopCd));
				// 入荷予定日FROM
				inputData.AddScreenParameter(6, ymdFrom2);
				// 入荷予定日TO
				inputData.AddScreenParameter(7, ymdTo2);
				#endregion


				// 印刷処理
				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_KYAKUTYUNYUKALIST),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_KYAKUTYUNYUKALIST,
												Tc010p01Constant.FORMID_01,
												Tc010p01Constant.PGID,
												pdfFileNm
												);
		
		
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
				facadeContext.UserMap.Add(Tc010p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
				#endregion


				//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
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
