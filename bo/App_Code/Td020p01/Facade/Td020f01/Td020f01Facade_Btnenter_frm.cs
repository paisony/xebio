using com.xebio.bo.Td020p01.Constant;
using com.xebio.bo.Td020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Td020p01.Facade
{
  /// <summary>
  /// Td020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td020f01Facade : StandardBaseFacade
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
				Td020f01Form f01VO = (Td020f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion
				#region 業務チェック
				// 行数チェック
				ChkRowCount(facadeContext, m1List);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 単項目チェック
				ChkUpdSingleItem(facadeContext, f01VO, m1List, sysDateVO);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 単項目チェック
				ChkUpdSingleItemDetail(facadeContext, f01VO, m1List, sysDateVO);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 更新処理
				// [移動出荷確定一時TBL]を登録する。
				BoSystemLog.logOut("[返品予定一時TBL]を登録 START");
				int InsTempcnt = Ins_TempReturn(facadeContext, f01VO, logininfo, sysDateVO);
				BoSystemLog.logOut("[返品予定一時TBL]を登録 END");

				// ストアド(移動出荷入力登録処理)を起動する
				BoSystemLog.logOut("返品確定登録処理を起動 START");
				ArrayList al = prcInsertReturnNew(facadeContext);
				BoSystemLog.logOut("返品確定登録処理を起動 END");

				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点で処理を中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
				#endregion
				#region 印刷処理
				string pdfFileNm = "";

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				foreach (Hashtable rec in (ArrayList)al[1])
				{

					// 店舗コード
					inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));
					// 伝票番号
					inputData.AddScreenParameter(2, rec["DENPYO_BANGO"].ToString());
					// 処理日付
					inputData.AddScreenParameter(3, rec["SYORI_YMD"].ToString());
					// 店舗控え出力フラグ
					inputData.AddScreenParameter(4, "1");
				}

				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();

				// PDFファイル名(返品伝票_YYYYMMDD_ログイン情報.[会社コード]_ログイン情報.[所属店舗コード]_ログイン情報.[担当者コード].pdf)
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HENPINDENPYO),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												BoSystemConstant.REPORTID_HENPINDENPYO,
												Td020p01Constant.FORMID_01,
												Td020p01Constant.PGID,
												pdfFileNm
												);

				// PDFファイルをユーザマップに設定
				facadeContext.SetUserObject(Td020p01Constant.FCDUO_PRT_FLNM, pdfFileNm);
				#endregion
				#region 画面表示
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
