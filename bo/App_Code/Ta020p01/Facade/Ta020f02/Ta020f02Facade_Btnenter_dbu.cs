using com.xebio.bo.Ta020p01.Constant;
using com.xebio.bo.Ta020p01.Formvo;
using com.xebio.bo.Ta020p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.StringUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Ta020p01.Facade
{
  /// <summary>
  /// Ta020f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta020f02Facade : StandardBaseFacade
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
				Ta020f02Form f02VO = (Ta020f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Ta020f01M1Form f01M1Form = new Ta020f01M1Form();
				// 新規作成でない場合
				if (!BoSystemConstant.MODE_INSERT.Equals(f02VO.Stkmodeno))
				{
					f01M1Form = (Ta020f01M1Form)f02VO.Dictionary[Ta020p01Constant.DIC_M1SELCETVO];
				}

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion
					#region 業務チェック

				decimal warningFlg = Convert.ToDecimal(BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0"));
				if (warningFlg != 1)
				{
					// 行数チェック
					ChkRowCount(facadeContext, m1List, f02VO.Stkmodeno);
					// ------------------------------------------------------------------------------------
					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				// 単項目チェック
				decimal[] dSumList = ChkUpdSingleItem(facadeContext, f02VO, m1List, warningFlg);
				// ------------------------------------------------------------------------------------
				// ワーニングが発生した場合、その時点でチェックを中止しクライアント側へワーニング内容を返却する。
				// ------------------------------------------------------------------------------------
				if (InfoMsgCls.HasWarn(facadeContext) && warningFlg != 1)
				{
					return;
				}
				// ------------------------------------------------------------------------------------
				// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#region 排他チェック
				// 排他チェック
				// [選択モードNo]が「申請」、「修正」の場合
				if (BoSystemConstant.MODE_APPLY.Equals(f02VO.Stkmodeno) || BoSystemConstant.MODE_UPD.Equals(f02VO.Stkmodeno))
				{
					ChkUpdHaita(facadeContext, f01M1Form, m1List, f02VO.Stkmodeno);
					// ------------------------------------------------------------------------------------
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				#endregion
				#region 更新処理
				int iCnt = 0;
				decimal dRowNo = 0;
				// -------------------------------------------------------
				// [選択モードNo]が「新規」の場合
				// -------------------------------------------------------
				if (BoSystemConstant.MODE_INSERT.Equals(f02VO.Stkmodeno))
				{
					// 明細単位で以下の処理を実施する。
					foreach (Ta020f02M1Form f02m1VO in m1List.ListData)
					{
						// スキャンコードが入力されていない場合、次明細
						if (string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
						{
							iCnt++;
							continue;
						}
						// 行Ｎｏをインクリメント
						dRowNo++;
						// [補充発注一時TBL]を登録する。
						BoSystemLog.logOut("[補充発注一時TBL]を登録 START");
						int InsCntB_Order = Ins_Order(facadeContext, f01M1Form, f02VO, f02m1VO, logininfo, sysDateVO, Ta020p01Constant.REG_KBN_TEMP, dRowNo);
						BoSystemLog.logOut("[補充発注一時TBL]を登録 END");
						iCnt++;
					}
					// ストアド(出荷要望／単品レポート登録処理)を起動する
					BoSystemLog.logOut("出荷要望登録処理を起動 START");
					prcInsertOrder(facadeContext);
					BoSystemLog.logOut("出荷要望登録処理を起動 END");

					// ------------------------------------------------------------------------------------
					//エラーが発生した場合、その時点で処理を中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				// -------------------------------------------------------
				// [選択モードNo]が「修正」の場合
				// -------------------------------------------------------
				else if (BoSystemConstant.MODE_UPD.Equals(f02VO.Stkmodeno))
				{
					// [ログイン情報.会社コード]＝「1:ゼビオの場合」
					if (CheckCompanyCls.IsXebio())
					{
						// [出荷要望申請TBL(H)]を更新する。
						BoSystemLog.logOut("[出荷要望申請TBL(H)]を更新 START");
						int UpdCntH_Order_Apply = Upd_Order(facadeContext, f01M1Form, f02VO, logininfo, sysDateVO, Ta020p01Constant.REG_KBN_SHINSEI);
						BoSystemLog.logOut("[出荷要望申請TBL(H)]を更新 END");
						// [出荷要望申請TBL(B)]を削除する。
						BoSystemLog.logOut("[出荷要望申請TBL(B)]を削除 START");
						int DelCntB_Order_Apply = Ta020p01Util.Del_Order(facadeContext, f01M1Form, Ta020p01Constant.DEL_KBN_SHINSEI_BODY);
						BoSystemLog.logOut("[出荷要望申請TBL(B)]を削除 END");
					}
					// その他の場合
					else
					{
						// [出荷要望申請TBL(H)]を更新する。
						BoSystemLog.logOut("[出荷要望確定TBL(H)]を更新 START");
						int UpdCntH_Order = Upd_Order(facadeContext, f01M1Form, f02VO, logininfo, sysDateVO, Ta020p01Constant.REG_KBN_KAKUTEI);
						BoSystemLog.logOut("[出荷要望確定TBL(H)]を更新 END");
						// [出荷要望確定TBL(B)]を削除する。
						BoSystemLog.logOut("[出荷要望確定TBL(B)]を削除 START");
						int DelCntB_Order = Ta020p01Util.Del_Order(facadeContext, f01M1Form, Ta020p01Constant.DEL_KBN_KAKUTEI_BODY);
						BoSystemLog.logOut("[出荷要望確定TBL(B)]を削除 END");
					}
					// 明細単位で以下の処理を実施する。
					foreach (Ta020f02M1Form f02m1VO in m1List.ListData)
					{
						// スキャンコードが入力されていない場合、次明細
						if (string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
						{
							iCnt++;
							continue;
						}
						dRowNo++;
						// [ログイン情報.会社コード]＝「1:ゼビオの場合」
						if (CheckCompanyCls.IsXebio())
						{
							// [出荷要望申請TBL(B)]を登録する。
							BoSystemLog.logOut("[出荷要望申請TBL(B)]を登録 START");
							int InsCntB_Order = Ins_Order(facadeContext, f01M1Form, f02VO, f02m1VO, logininfo, sysDateVO, Ta020p01Constant.REG_KBN_SHINSEI, dRowNo);
							BoSystemLog.logOut("[出荷要望申請TBL(B)]を登録 END");
						}
						// その他の場合
						else
						{
							// [出荷要望確定TBL(B)]を登録する。
							BoSystemLog.logOut("[出荷要望確定TBL(B)]を登録 START");
							int InsCntB_Order = Ins_Order(facadeContext, f01M1Form, f02VO, f02m1VO, logininfo, sysDateVO, Ta020p01Constant.REG_KBN_KAKUTEI, dRowNo);
							BoSystemLog.logOut("[出荷要望確定TBL(B)]を登録 END");
						}
						iCnt++;
					}
				}
				// -------------------------------------------------------
				// [選択モードNo]が「申請」の場合
				// -------------------------------------------------------
				else if (BoSystemConstant.MODE_APPLY.Equals(f02VO.Stkmodeno))
				{
					// [出荷要望申請TBL(H)]を更新する。
					BoSystemLog.logOut("[出荷要望申請TBL(H)]を更新 START");
					int UpdCntH_Order_Apply = Ta020p01Util.Upd_OrderAplly(facadeContext, f01M1Form, logininfo, sysDateVO, BoSystemConstant.MODE_APPLY);
					BoSystemLog.logOut("[出荷要望申請TBL(H)]を更新 END");
					// [出荷要望申請TBL(H)]を検索し、[出荷要望確定TBL(H)]を登録する。
					BoSystemLog.logOut("[出荷要望申請TBL(H)]を検索し、[出荷要望確定TBL(H)]を登録 START");
					int InsCntH_Order = Ta020p01Util.Ins_HeadOrderAplly(facadeContext, f01M1Form, logininfo, sysDateVO, Ta020p01Constant.REG_GAMEN_MEISAI, dSumList[0], dSumList[1]);
					BoSystemLog.logOut("[出荷要望申請TBL(H)]を検索し、[出荷要望確定TBL(H)]を登録 END");
					// 明細単位で以下の処理を実施する。
					foreach (Ta020f02M1Form f02m1VO in m1List.ListData)
					{
						// 対象行の[選択フラグ]が1の場合、以下の処理を実施する。
						if (f02m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							dRowNo++;
							// [出荷要望確定TBL(B)]を登録する。
							BoSystemLog.logOut("[出荷要望確定TBL(B)]を登録 START");
							int InsCntB_Order = Ins_Order(facadeContext, f01M1Form, f02VO, f02m1VO, logininfo, sysDateVO, Ta020p01Constant.REG_KBN_KAKUTEI, dRowNo);
							BoSystemLog.logOut("[出荷要望確定TBL(B)]を登録 END");
						}
						iCnt++;
					}
				}
				#endregion
				#region 画面表示
				// 明細情報を更新する。
				DoCopyUpdAfter(facadeContext, f02VO, f01M1Form, m1List, logininfo, sysDateVO, dSumList);
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
