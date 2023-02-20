using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using com.xebio.bo.Ta080p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.Standard.Base;
using Common.Standard.Constant;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f03のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f03Facade : StandardBaseFacade
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
				LoginInfoVO loginInfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Ta080f03Form f03VO = (Ta080f03Form)facadeContext.FormVO;
				IDataList m1List = f03VO.GetList("M1");

				// 検索時一覧画面情報
				Ta080f01Form f01VOSearched = (Ta080f01Form)f03VO.Dictionary[Ta080p01Constant.DIC_SEARCH_F01VO];

				// 一覧画面選択行のVO
				Ta080f01M1Form f01MVOSelected = new Ta080f01M1Form();

				// 代表自社品番確認
				bool DaihyoConfF = false;

				// 新規作成でない場合
				if (!BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
				{
					f01MVOSelected = (Ta080f01M1Form)f03VO.Dictionary[Ta080p01Constant.DIC_M1SELCETVO];
				}

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				

				#endregion

				// 警告メッセージ設定チェック
				decimal warninngFlg = Convert.ToDecimal(BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0"));
				if (warninngFlg != 1)
				{
					#region 代表自社品番振替、単品レポートメッセージ処理
					string tanpinFlg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.TANPIN_FCD_KEY) as string, "0");
					// 代表自社品番振替メッセージで「はい」が押下された場合
					if ("3".Equals(tanpinFlg))
					{
						// 代表自社品番振替フラグを　ＯＦＦ　に設定
						f03VO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG] = Ta080p01Constant.FLG_OFF.ToString();
						// JANコードを置き換える設定
						Ta080p01Util.DoDaihyoShouhinCopy(m1List, sysDateVO);
						// 単品レポート警告がある場合、設定
						ArrayList tanpinErrList = (ArrayList) f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_ERRLIST];
						Ta080p01Util.setTanpinReportMsgList(facadeContext, tanpinErrList);
						DaihyoConfF = true;
					}
					// 単品レポートメッセージ「はい」が押下された場合
					else if ("1".Equals(tanpinFlg))
					{
						// 明細情報を更新して終了
						DoCopyTanpinReport(f03VO);
						// 単品登録モードフラグを　ＯＮ　に設定
						f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG] = Ta080p01Constant.FLG_ON.ToString();
						return;
					}
					#endregion

					#region 業務チェック

					// 代表自社品番の確認メッセージ後以外
					if (!DaihyoConfF)
					{

						#region 行チェック
						ChkUpd1_4(facadeContext, f03VO, m1List);
						#endregion
						// ------------------------------------------------------------------------------------
						// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						// ------------------------------------------------------------------------------------
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}

						#region モード｢新規作成｣｢申請｣｢申請前修正｣の場合、ストアド(補充依頼チェック処理)を起動する。
						if (BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno)
						|| BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno)
						|| BoSystemConstant.MODE_SINSEIMAEUPD.Equals(f03VO.Stkmodeno)
						)
						{
							// 明細単位で以下の処理を実施する。	
							// ストアド(補充依頼チェック処理)を起動する。
							// 更新処理用にスキャンコードに紐付く明細項目のコード値をDictionaryにセットする
							ArrayList tanpinErrList = new ArrayList();
							f03VO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG] = Ta080p01Constant.FLG_OFF.ToString();
							ChkUpd3_6(facadeContext, f03VO, m1List, tanpinErrList);
							if (((string)f03VO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG]).Equals(Ta080p01Constant.FLG_OFF.ToString())
								&& tanpinErrList.Count > 0
								&& !MessageDisplayUtil.HasError(facadeContext)
								)
							{
								// 代表自社品番振替がなく単品エラーありかつ通常エラーなしの場合
								// 単品レポートエラーメッセージをワーニングに設定する。
								Ta080p01Util.setTanpinReportMsgList(facadeContext, tanpinErrList);
							}
							else if (((string)f03VO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG]).Equals(Ta080p01Constant.FLG_ON.ToString())
								&& !MessageDisplayUtil.HasError(facadeContext)
								)
							{
								// 代表自社品番振替ありの場合
								f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_ERRLIST] = tanpinErrList;
								return;
							}
							else
							{
								if (MessageDisplayUtil.HasError(facadeContext))
								{
									// メッセージリストから警告分のみ削除
									List<MessageInfoVO> buflist = new List<MessageInfoVO>();
									List<MessageInfoVO> list = MessageDisplayUtil.GetMessageList(facadeContext);

									if (list != null)
									{
										foreach (MessageInfoVO msgInfoVO in list)
										{
											if (msgInfoVO.MessageLevel == MessageLevel.ERROR)
											{
												buflist.Add(msgInfoVO);
											}
										}
									}
									facadeContext.SetUserObject(PageConstant.MESSAGE_LIST, buflist);
								}
							}
						}
						#endregion
						// ------------------------------------------------------------------------------------
						// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						// ------------------------------------------------------------------------------------
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}
						// ------------------------------------------------------------------------------------
						// [選択モードNo]が[申請]「申請前修正」の場合、単品レポート用のエラーメッセージリストにエラーが存在する場合、処理を終了し、エラーを表示する。
						// ------------------------------------------------------------------------------------
						if(BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno)
						|| BoSystemConstant.MODE_SINSEIMAEUPD.Equals(f03VO.Stkmodeno)){
							if (InfoMsgCls.HasWarn(facadeContext))
							{
								return;
							}
						}
					}

					#region 排他チェック
					ChkUpd7(facadeContext, f03VO, m1List);
					#endregion
					// ------------------------------------------------------------------------------------
					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}

					#region [選択モードNo]が「申請」かつ[仕入枠グループコード]＝"000000"(単品レポート)の場合、売上金額 警告チェック
					if (BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno)
					&& "000000".Equals(f03VO.Yosan_cd))
					{
						// 売上金額 警告チェックする。
						ChkUpd8(facadeContext, f03VO, m1List);
						// ------------------------------------------------------------------------------------
						// ワーニングが発生した場合、その時点でチェックを中止しクライアント側へワーニング内容を返却する。
						// ------------------------------------------------------------------------------------
						if (InfoMsgCls.HasWarn(facadeContext))
						{
							return;
						}
					}
					#endregion

					#endregion
				}

				#region 更新処理

				#region モード｢新規作成｣の場合
				if (BoSystemConstant.MODE_INSERT.Equals(f03VO.Stkmodeno))
				{
					DoUpdInsert(facadeContext, f03VO, m1List, loginInfo, sysDateVO);
				}
				#endregion

				#region モード｢申請｣、｢申請前修正｣の場合
				else if (BoSystemConstant.MODE_APPLY.Equals(f03VO.Stkmodeno)
				|| BoSystemConstant.MODE_SINSEIMAEUPD.Equals(f03VO.Stkmodeno))
				{
					DoUpdShinseiOrShinseiUpd(facadeContext, f03VO, m1List, loginInfo, sysDateVO);
				}
				#endregion

				#region モード｢申請前取消｣の場合
				else if(BoSystemConstant.MODE_SINSEIZUMITORIKESI.Equals(f03VO.Stkmodeno))
				{
					DoUpdShinseiTorikeshi(facadeContext, f03VO, m1List, loginInfo, sysDateVO);
				}
				#endregion

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 後処理
				// 一覧明細_選択行の値の更新
				DoAfterUpd(facadeContext, f01VOSearched, f01MVOSelected, f03VO);
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
