using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f01Facade : StandardBaseFacade
	{
		#region データベース更新処理を行います。(ボタンID : Btnenter)
		/// <summary>
		/// データベース更新処理を行います。
		/// ボタンID(Btnenter)
		/// アクションID(DBU)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_DBU(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
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
				Ta080f01Form f01VO = (Ta080f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				
				// 検索時画面情報
				Ta080f01Form f01VOSearched = (Ta080f01Form)f01VO.Dictionary[Ta080p01Constant.DIC_SEARCH_F01VO];
				

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				#region 業務チェック
				#region モード共通チェック
				// 1:選択チェック
				ChkUpd1(facadeContext, m1List);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion 
						
				#region モード「申請」の場合
				if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_APPLY))
				{
					// 2:仕入枠チェック	
					ChkUpd2(facadeContext, m1List);
					// ------------------------------------------------------------------------------------
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
	
					// 5:排他チェック1_｢申請｣
					ChkUpd5(facadeContext, f01VOSearched, m1List);
					// ------------------------------------------------------------------------------------
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					// 3:単項目チェック
					// 4:単品レポートチェック ※ストア度にて実行
					ChkUpd3_4(facadeContext, f01VOSearched, m1List);
					// ------------------------------------------------------------------------------------
					//エラーが発生した場合、処理終了。
					//※一覧情報に紐づく商品全てのチェックを行う。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				#endregion
				#region モード「申請取消」の場合
				else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_SINSEIZUMITORIKESI))
				{
					// 6:排他チェック2_｢申請取消｣
					ChkUpd6(facadeContext, f01VOSearched, m1List);
					// ------------------------------------------------------------------------------------
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				#endregion
				#endregion

				#region 更新処理
				#region モード「申請」の場合
				if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_APPLY))
				{
					DoUpdShinsei(facadeContext, f01VOSearched, m1List, logininfo, sysDateVO);
				}
				#endregion
				#region モード「申請取消」の場合
				else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_SINSEIZUMITORIKESI))
				{
					DoUpdShinseiTorikeshi(facadeContext, f01VOSearched, m1List, logininfo, sysDateVO);
				}
				#endregion
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
	
		}
		#endregion
	}
}
