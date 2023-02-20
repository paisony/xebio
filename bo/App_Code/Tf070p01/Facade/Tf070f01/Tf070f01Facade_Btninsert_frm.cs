using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.V01000.V01001;
using Common.Standard.Base;
using Common.Standard.Message;

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f01Facade : StandardBaseFacade
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
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// 画面情報取得
				Tf070f01Form f01VO = (Tf070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 保持していた検索条件を初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);
				#endregion

				#region 業務チェック
				// 1-1 ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー
				V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new string[] { "Head_tenpo_cd" });

				// エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 画面編集
				// 明細画面情報取得
				Tf070f02Form f02VO = (Tf070f02Form)facadeContext.GetUserObject(Tf070p01Constant.FCDUO_NEXTVO);

				// カード部
				f02VO.Head_tenpo_cd = f01VO.Head_tenpo_cd;			// ヘッダ店舗コード
				f02VO.Head_tenpo_nm = f01VO.Head_tenpo_nm;			// ヘッダ店舗名
				f02VO.Stkmodeno = BoSystemConstant.MODE_INSERT;		// 選択モードNo
				f02VO.Tonanhinkanri_no = string.Empty;				// 盗難品管理番号
				f02VO.Jikohassei_ymd = string.Empty;				// 事故発生日
				f02VO.Hokoku_ymd = string.Empty;					// 報告日
				f02VO.Hokokutan_cd = string.Empty;					// 報告担当者コード
				f02VO.Hokokutan_nm = string.Empty;					// 報告担当者名称
				f02VO.Tentyotan_cd = string.Empty;					// 店長担当者コード
				f02VO.Tentyotan_nm = string.Empty;					// 店長担当者名称
				f02VO.Keisatsutodoke_ymd = string.Empty;			// 警察届出日
				f02VO.Todokedesakikeisatsu_nm = string.Empty;		// 届出先警察署名
				f02VO.Jyuri_no = string.Empty;						// 受理番号

				// 明細部
				// 初期化
				f02VO.GetList("M1").ClearCacheData();
				f02VO.GetList("M1").Clear();
				// ページ追加
				AddRowCls.AddEmptyPage<Tf070f02M1Form>("M1", "M1rowno", f02VO);

				f02VO.Gokeisinsei_su = string.Empty;				// 合計申請数
				f02VO.Gokeijyuri_su = string.Empty;					// 合計受理数
				f02VO.Gokeibaika_kin = string.Empty;				// 合計売価金額
				#endregion

				// 選択モードの設定
				f01VO.Stkmodeno = BoSystemConstant.MODE_INSERT;
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
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
