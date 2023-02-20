using com.xebio.bo.Te010p01.Constant;
using com.xebio.bo.Te010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LogUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Te010p01.Facade
{
  /// <summary>
  /// Te010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te010f01Facade : StandardBaseFacade
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
				Te010f01Form f01VO = (Te010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion
				#region 業務チェック
				// 行数チェック
				ChkRowCount(facadeContext, m1List, logininfo, Te010p01Constant.CHECK_MODE_BTNKAKUTEI);
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
				// 排他チェック
				ChkUpdHaita(facadeContext, m1List);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 更新処理
				foreach (Te010f01M1Form f01m1VO in m1List.ListData)
				{
					// 対象行の更新を行う。
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// [移動入荷予定TBL(H)]を削除する。
						BoSystemLog.logOut("[移動入荷予定TBL(H)]を削除 START");
						int delYHCnt = Del_IdouTbl(facadeContext, f01m1VO, Te010p01Constant.DEL_KBN_YOTEI_HEAD);
						BoSystemLog.logOut("[移動入荷予定TBL(H)]を削除 END 削除件数【" + delYHCnt + "】");
						// [移動入荷予定TBL(B)]を削除する。
						BoSystemLog.logOut("[移動入荷予定TBL(B)]を削除 START");
						int delYBCnt = Del_IdouTbl(facadeContext, f01m1VO, Te010p01Constant.DEL_KBN_YOTEI_BODY);
						BoSystemLog.logOut("[移動入荷予定TBL(B)]を削除 END 削除件数【" + delYBCnt + "】");

						// [移動出荷確定TBL(H)]を検索し、[移動出荷履歴TBL(H)]を登録する。
						BoSystemLog.logOut("[移動出荷確定TBL(H)]を検索し、[移動出荷履歴TBL(H)]を登録 START");
						int insRirekHCnt = Ins_Rireki(facadeContext, f01m1VO, sysDateVO, Te010p01Constant.INS_KBN_HEAD);
						BoSystemLog.logOut("[移動出荷確定TBL(H)]を検索し、[移動出荷履歴TBL(H)]を登録 END 登録件数【" + insRirekHCnt + "】");
						// [移動出荷確定TBL(B)]を検索し、[移動出荷履歴TBL(B)]を登録する。
						BoSystemLog.logOut("[移動出荷確定TBL(B)]を検索し、[移動出荷履歴TBL(B)]を登録 START");
						int insRirekBCnt = Ins_Rireki(facadeContext, f01m1VO, sysDateVO, Te010p01Constant.INS_KBN_BODY);
						BoSystemLog.logOut("[移動出荷確定TBL(B)]を検索し、[移動出荷履歴TBL(B)]を登録 END 登録件数【" + insRirekBCnt + "】");

						// [移動出荷確定TBL(H)]を削除する。
						BoSystemLog.logOut("[移動出荷確定TBL(H)]を削除 START");
						int delKHCnt = Del_IdouTbl(facadeContext, f01m1VO, Te010p01Constant.DEL_KBN_KAKUTEI_HEAD);
						BoSystemLog.logOut("[移動出荷確定TBL(H)]を削除 END 削除件数【" + delKHCnt + "】");
						// [移動出荷確定TBL(B)]を削除する。
						BoSystemLog.logOut("[移動出荷確定TBL(B)]を削除 START");
						int delKBCnt = Del_IdouTbl(facadeContext, f01m1VO, Te010p01Constant.DEL_KBN_KAKUTEI_BODY);
						BoSystemLog.logOut("[移動出荷確定TBL(B)]を削除 END 削除件数【" + delKBCnt + "】");
					}
				}
				#endregion

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
