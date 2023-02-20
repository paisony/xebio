using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta010p01.Formvo;
using com.xebio.bo.Ta010p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LogUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Ta010p01.Facade
{
  /// <summary>
  /// Ta010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta010f01Facade : StandardBaseFacade
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
			//使用時にコメントアウトをはずす。
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
				Ta010f01Form f01VO = (Ta010f01Form)facadeContext.FormVO;
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
				ChkUpdSingleItem(facadeContext, f01VO, sysDateVO);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 排他チェック
				ChkUpdHaita(facadeContext, m1List, f01VO.Modeno);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 更新処理
				int iUpdSelCnt = 0;
				foreach (Ta010f01M1Form f01m1VO in m1List.ListData)
				{
					// 対象行のみ実施
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// [選択モードNo]が「申請」の場合
						if (BoSystemConstant.MODE_APPLY.Equals(f01VO.Modeno))
						{
							// [補充依頼申請TBL(H)]を更新する。
							BoSystemLog.logOut("[補充依頼申請TBL(H)]を更新[MODE=" + f01VO.Modeno + "] START");
							int UpdCntH_Order_Apply = Ta010p01Util.Upd_OrderAplly(facadeContext, f01m1VO, logininfo, sysDateVO, f01VO.Modeno);
							BoSystemLog.logOut("[補充依頼申請TBL(H)]を更新 END");
							// [返補充依頼申請TBL(B)]を検索し、[返補充依頼確定TBL(B)]を登録する。
							BoSystemLog.logOut("[補充依頼申請TBL(B)]を検索し、[補充依頼確定TBL(B)]を登録 START");
							int InsCntB_Order_Apply = Ins_DetailOrderAplly(facadeContext, f01m1VO);
							BoSystemLog.logOut("[補充依頼申請TBL(B)]を検索し、[補充依頼確定TBL(B)]を登録 END");
							// 対象行の[Dictionary.区分コード]が"1"(補充依頼)の場合	
							BoSystemLog.logOut("[KBN_CD=" + (string)f01m1VO.Dictionary[Ta010p01Constant.DIC_M1KBN_CD] + "]");
							if (ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN1.Equals((string)f01m1VO.Dictionary[Ta010p01Constant.DIC_M1KBN_CD]))
							{
								// [補充依頼確定TBL(B)]を更新する。
								BoSystemLog.logOut("[補充依頼確定TBL(B)]を更新 START");
								int InsCntH_Order_Apply_Msg = Ins_HeadOrderAplly_Msg(facadeContext, f01m1VO);
								BoSystemLog.logOut("[補充依頼確定TBL(B)]を更新 END");
							}
							// [補充依頼申請TBL(H)]を検索し、[補充依頼確定TBL(H)]を登録する。
							BoSystemLog.logOut("[補充依頼申請TBL(H)]を検索し、[補充依頼確定TBL(H)]を登録 START");
							int InsCntH_Order = Ta010p01Util.Ins_HeadOrderAplly(facadeContext, f01m1VO, logininfo, sysDateVO, Ta010p01Constant.REG_GAMEN_ITIRAN, 0, 0);
							BoSystemLog.logOut("[補充依頼申請TBL(H)]を検索し、[補充依頼確定TBL(H)]を登録 END");
						}
						// [選択モードNo]が「取消」の場合
						else if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno))
						{
							// 会社がXの場合
							if (CheckCompanyCls.IsXebio())
							{
								// [補充依頼申請TBL(H)]を更新する。
								BoSystemLog.logOut("[補充依頼申請TBL(H)]を更新[COPCD=" + logininfo.CopCd + "] START");
								int UpdCntH_Order_Apply = Ta010p01Util.Upd_OrderAplly(facadeContext, f01m1VO, logininfo, sysDateVO, f01VO.Modeno);
								BoSystemLog.logOut("[補充依頼申請TBL(H)]を更新 END");
							}
							// [補充依頼確定TBL(H)]を削除する。	
							BoSystemLog.logOut("[補充依頼確定TBL(H)]を削除 START");
							int DelCntH_Order = Ta010p01Util.Del_Order(facadeContext, f01m1VO, Ta010p01Constant.DEL_KBN_KAKUTEI_HEAD);
							BoSystemLog.logOut("[補充依頼確定TBL(H)]を削除 END");
							// [補充依頼確定TBL(B)]を削除する。	
							BoSystemLog.logOut("[補充依頼確定TBL(B)]を削除 START");
							int DelCntB_Order = Ta010p01Util.Del_Order(facadeContext, f01m1VO, Ta010p01Constant.DEL_KBN_KAKUTEI_BODY);
							BoSystemLog.logOut("[補充依頼確定TBL(B)]を削除 END");
						}
					}
					iUpdSelCnt++;
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
	
		}
		#endregion
	}
}
