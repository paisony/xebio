using com.xebio.bo.Tg010p01.Constant;
using com.xebio.bo.Tg010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01018;
using Common.Business.C02000.C02002;
using Common.Business.C99999.LogUtil;
using Common.Business.V01000.V01001;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections;

namespace com.xebio.bo.Tg010p01.Facade
{
  /// <summary>
  /// Tg010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg010f01Facade : StandardBaseFacade
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

				// FormVO取得
				// 画面より情報を取得する。
				Tg010f01Form f01VO = (Tg010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック
				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#region ページ追加
				// 初期値設定
				Hashtable defVal = new Hashtable();
				
				// ページを追加
				AddRowCls.AddEmptyRow<Tg010f01M1Form>("M1", "M1rowno", (Tg010f01Form)facadeContext.FormVO, m1List.DispRow);
				SetPageIndex(m1List, m1List.DispRow);

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();
				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;
				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);


				#endregion
				#endregion

				// [出力シール]の名称取得
				if (!f01VO.Dictionary.Contains(Tg010p01Constant.DIC_SYUTSURYOKU_SEAL)
					|| f01VO.Dictionary[Tg010p01Constant.DIC_SYUTSURYOKU_SEAL] == null)
				{
					CalcTaxCls tax = new CalcTaxCls();
					f01VO.Dictionary.Add(Tg010p01Constant.DIC_SYUTSURYOKU_SEAL, tax.GetTaxDispControlInfo(facadeContext));
				}
			}
			catch (System.Exception ex)
			{
				BoSystemLog.logOut("□デバック確認□err " + ex.StackTrace);
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
