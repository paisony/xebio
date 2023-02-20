using com.xebio.bo.Te040p01.Constant;
using com.xebio.bo.Te040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Te040p01.Facade
{
  /// <summary>
  /// Te040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te040f01Facade : StandardBaseFacade
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
				Te040f01Form f01VO = (Te040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				bool blWorn = false;
				#endregion
				#region ワーニング処理
				decimal warninngFlg = Convert.ToDecimal(BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0"));
				if (!Te040p01Constant.FLG_ON.Equals(warninngFlg))
				{
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
					// 警告チェック
					blWorn = ChkUpdWarn(facadeContext, f01VO, m1List);
					// ------------------------------------------------------------------------------------
					// ワーニングが発生した場合、その時点でチェックを中止しクライアント側へワーニング内容を返却する。
					// ------------------------------------------------------------------------------------
					BoSystemLog.logOut("ワーニング有無[" + blWorn.ToString() + "]");
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}
					#endregion
				}
				#endregion
				#region 更新処理
				// [移動出荷確定一時TBL]を登録する。
				BoSystemLog.logOut("[移動出荷確定一時TBL]を登録 START");
				int InsTempcnt = Ins_TempTransfer(facadeContext, f01VO, logininfo, sysDateVO);
				BoSystemLog.logOut("[移動出荷確定一時TBL]を登録 END");

				// ストアド(移動出荷入力登録処理)を起動する
				BoSystemLog.logOut("移動出荷入力登録処理を起動 START");
				ArrayList al = prcInsertTransferOut(facadeContext);
				BoSystemLog.logOut("移動出荷入力登録処理を起動 END");

				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点で処理を中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// ストアド(再入荷防止TBL登録処理)を起動する。
				BoSystemLog.logOut("再入荷防止TBL登録処理を起動 START");
				prcInsertStopOrder(facadeContext, f01VO);
				BoSystemLog.logOut("再入荷防止TBL登録処理を起動 END");
				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 印刷処理

				// 帳票ID
				string chohyoId = BoSystemConstant.REPORTID_IDOUSYUKKADENPYO;

				string pdfFileNm = string.Empty;

				ArrayList alCur = new ArrayList();

				if (al != null && al.Count >= 2)
				{
					alCur = (ArrayList)al[1];
				}

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				foreach (Hashtable rec in alCur)
				{
					//出荷店コード
					inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(rec["SYUKKATEN_CD"].ToString()));
					//出荷会社コード
					inputData.AddScreenParameter(2, rec["SYUKKAKAISYA_CD"].ToString());
					//伝票番号
					inputData.AddScreenParameter(3, rec["DENPYO_BANGO"].ToString());
					//出荷日
					inputData.AddScreenParameter(4, BoSystemFormat.formatDate(rec["SYUKKA_YMD"].ToString()));
					// 店舗控えフラグ(1:印刷あり)
					inputData.AddScreenParameter(5, "1");
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
												Te040p01Constant.FORMID_01,
												Te040p01Constant.PGID,
												pdfFileNm
												);

				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Te040p01Constant.FCDUO_PRT_FLNM, pdfFileNm);

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
