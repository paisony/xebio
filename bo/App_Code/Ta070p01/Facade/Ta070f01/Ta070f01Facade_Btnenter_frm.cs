using com.xebio.bo.Ta070p01.Constant;
using com.xebio.bo.Ta070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Ta070p01.Facade
{
  /// <summary>
  /// Ta070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta070f01Facade : StandardBaseFacade
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
				Ta070f01Form f01VO = (Ta070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				bool blWorn = false;
				#endregion
				#region ワーニング処理
				decimal warninngFlg = Convert.ToDecimal(BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0"));
				if (!Ta070p01Constant.FLG_ON.Equals(warninngFlg))
				{
					#region 業務チェック
					// 行数チェック
					ChkRowCount(facadeContext, m1List, f01VO.Stkmodeno);
					// ------------------------------------------------------------------------------------
					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					// 更新入力値チェック
					ChkUpdInput(facadeContext, f01VO, m1List, sysDateVO);
					// ------------------------------------------------------------------------------------
					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					// 更新マスタチェック
					ChkUpdMst(facadeContext, f01VO, m1List, sysDateVO);
					// ------------------------------------------------------------------------------------
					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					// 更新関連項目チェック
					ChkUpdRelatedItem(facadeContext, f01VO, m1List);
					// ------------------------------------------------------------------------------------
					// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
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
				// 排他チェック
				ChkUpdHaita(facadeContext, m1List, f01VO.Stkmodeno);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#region 更新処理
				int iCnt = 0;
				// -------------------------------------------------------
				// [選択モードNo]が「新規」、「修正」の場合
				// -------------------------------------------------------
				if (BoSystemConstant.MODE_INSERT.Equals(f01VO.Stkmodeno)
				 || BoSystemConstant.MODE_UPD.Equals(f01VO.Stkmodeno))
				{
					// 明細単位で以下の処理を実施する。
					foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
					{
						// 新規作成の場合はスキャンコード入力時、修正の場合は確定処理フラグがONの場合
						if ((f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT) && !string.IsNullOrEmpty(f01m1VO.M1scan_cd))
							|| (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD) && f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)))
						{

							// [自動定数依頼TBL]を更新(MERGE)する。
							BoSystemLog.logOut("[自動定数依頼TBL]を更新(MERGE) START");
							int MergeCnt_Auto = Merge_Auto(facadeContext, f01m1VO, logininfo, sysDateVO, f01VO.Stkmodeno);
							BoSystemLog.logOut("[自動定数依頼TBL]を更新(MERGE) END");
							iCnt++;
						}
					}
				}
				// -------------------------------------------------------
				// [選択モードNo]が「取消」の場合
				// -------------------------------------------------------
				else if (BoSystemConstant.MODE_DEL.Equals(f01VO.Stkmodeno))
				{
					// 明細単位で以下の処理を実施する。
					foreach (Ta070f01M1Form f01m1VO in m1List.ListData)
					{
						// 対象行の[選択フラグ]が1の場合、以下の処理を実施する。
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// [自動定数依頼TBL]を削除する。
							BoSystemLog.logOut("[自動定数依頼TBL]を削除 START");
							int DelCnt_Auto = Del_Auto(facadeContext, f01m1VO);
							BoSystemLog.logOut("[自動定数依頼TBL]を削除 END");
						}
						iCnt++;
					}
				}
				#endregion
				#region 画面表示
				// 明細情報を更新する。
				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
				//トランザクションをロールバックする。
//				RollbackTransaction(facadeContext);
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
