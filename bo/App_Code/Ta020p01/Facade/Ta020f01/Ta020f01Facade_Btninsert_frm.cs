using com.xebio.bo.Ta020p01.Constant;
using com.xebio.bo.Ta020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01007;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Ta020p01.Facade
{
  /// <summary>
  /// Ta020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta020f01Facade : StandardBaseFacade
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
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNINSERT_FRM");

			try
			{

				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);

				//	//以下に業務ロジックを記述する。
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Ta020f01Form prevVo = (Ta020f01Form)facadeContext.FormVO;
				Ta020f02Form nextVo = (Ta020f02Form)facadeContext.GetUserObject(Ta020p01Constant.FCDUO_NEXTVO);
				IDataList nextM1List = nextVo.GetList("M1");

				// 一覧の初期化
				nextM1List.Clear();
				#endregion
				#region 業務チェック
				// 単項目チェック
				ChkSelSingleItem(facadeContext, prevVo, Ta020p01Constant.CHECK_MODE_BTNINSERT);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				// 関連項目チェック
				ChkSelRelatedItem(facadeContext, prevVo, Ta020p01Constant.CHECK_MODE_BTNINSERT);
				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				// 明細をページ分追加
				AddRowCls.AddEmptyPage<Ta020f02M1Form>("M1", "M1rowno", nextVo);
				#region カード部設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = prevVo.Head_tenpo_cd;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = prevVo.Head_tenpo_nm;
				// 選択モードNO
				nextVo.Stkmodeno = BoSystemConstant.MODE_INSERT;

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 依頼日
				nextVo.Irai_ymd = sysDateVO.Sysdate.ToString();
				// 担当者コード
				nextVo.Tantosya_cd = logininfo.TtsCd;
				// 担当者名
				nextVo.Hanbaiin_nm = logininfo.TtsMei;
				// 依頼理由コード
				nextVo.Irairiyu_cd = "";
				// 合計欄の設定
				nextVo.Gokei_irai_su = "0";				// 合計依頼数量
				nextVo.Gokei_genkakin = "0";			// 合計原価金額

				// 選択明細のVO
				nextVo.Dictionary[Ta020p01Constant.DIC_M1SELCETVO] = "";
				// 選択行のインデックスを設定
				nextVo.Dictionary[Ta020p01Constant.DIC_M1SELCETROWIDX] = "";

				// 選択モードの設定
				prevVo.Stkmodeno = BoSystemConstant.MODE_INSERT;
				#endregion

			}
			catch (System.Exception ex)
			{
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
