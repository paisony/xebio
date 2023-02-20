using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01007;
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
		
		#region フォームを呼び出します。(ボタンID : Btninsert)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btninsert)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNINSERT_FRM(IFacadeContext facadeContext)
		{
		
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNINSERT_FRM");

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
				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// FormVO取得
				// 画面より情報を取得する。
				Ta080f01Form prevVo = (Ta080f01Form)facadeContext.FormVO;
				Ta080f03Form nextVo = (Ta080f03Form)facadeContext.GetUserObject(Ta080p01Constant.FCDUO_NEXTVO_03);
				IDataList nextM1List = nextVo.GetList("M1");

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();
				#endregion
				#region 業務チェック
				// 1.マスタ存在チェック
				ChkInsert1(facadeContext, prevVo);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
			
				#endregion
				#region カード部設定

				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = prevVo.Head_tenpo_cd;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = prevVo.Head_tenpo_nm;
				// 選択モードNO
				nextVo.Stkmodeno = BoSystemConstant.MODE_INSERT;
				// 明細モードNO
				nextVo.Meisai_modeno = "";
				// 明細選択モードNO
				nextVo.Meisai_stkmodeno = "0";
				// 年月度
				nextVo.Yosan_ymd = sysDateVO.Sysdate.ToString().Substring(0, 6); ;
				// 仕入枠グループコード
				nextVo.Yosan_cd = "";
				// 仕入枠グループ名
				nextVo.Yosan_nm = "";
				// 予算金額
				nextVo.Yosan_kin = "";
				// 未申請数
				nextVo.Misinsei_su = "";
				// 未申請金額
				nextVo.Misinsei_kin = "";
				// 申請数
				nextVo.Apply_su = "";
				// 申請金額
				nextVo.Apply_kin = "";
				// 実績数
				nextVo.Jisseki_su = "";
				// 実績金額
				nextVo.Jisseki_kin = "";
				// 残金額
				nextVo.Zan_kin = "";

				// 前画面.選択モードの設定
				prevVo.Stkmodeno = BoSystemConstant.MODE_INSERT;

				#endregion
				#region 明細部設定

				// 空白明細をページ分追加
				AddRowCls.AddEmptyPage<Ta080f03M1Form>("M1", "M1rowno", nextVo);
			
				
				#endregion
				#region フッター部設定
				// 合計欄の設定
				nextVo.Gokei_irai_su = "0";				// 合計依頼数量
				nextVo.Gokei_genkakin = "0";			// 合計原価金額
				nextVo.Footer_zan_kin = "";					// 残金

				#endregion
				#region dictionary設定
				// 単品登録モードフラグ
				nextVo.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG] = Ta010p01Constant.FLG_OFF.ToString();
				// 選択明細のVO
				nextVo.Dictionary[Ta080p01Constant.DIC_M1SELCETVO] = string.Empty;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Ta080p01Constant.DIC_M1SELCETROWIDX] = string.Empty;
				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNINSERT_FRM");

		}
		#endregion
	}
}
