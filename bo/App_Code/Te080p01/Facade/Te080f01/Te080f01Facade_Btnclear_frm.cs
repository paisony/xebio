using com.xebio.bo.Te080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Business.V01000.V01006;
using Common.Standard.Base;
using Common.Standard.Login;
using System;
using System.Collections;

namespace com.xebio.bo.Te080p01.Facade
{
  /// <summary>
  /// Te080f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te080f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnclear)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnclear)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNCLEAR_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNCLEAR_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// FormVO取得
				// 画面より情報を取得する。
				Te080f01Form f01VO = (Te080f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				AddRowCls.AddEmptyRow<Te080f01M1Form>("M1", "M1rowno", (Te080f01Form)facadeContext.FormVO, Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));

				// 1行目の「会社」に自社を表示する
				Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[0];
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();
				// 会社コード
				f01m1VO.M1kaisya_cd = loginInfVo.CopCd;
				// 会社名
				f01m1VO.M1kaisya_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01m1VO.M1kaisya_cd))
				{
					string kaisya_cd = Convert.ToInt16(f01m1VO.M1kaisya_cd).ToString();
					Hashtable resultHash = new Hashtable();
					resultHash = V01006Check.CheckKaisya(kaisya_cd, facadeContext);

					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01m1VO.M1kaisya_nm = (string)resultHash["MEISYO_NM"];
					}
				}

				// 合計欄の初期化
				f01VO.Scm_gokei = "0";
				f01VO.Denpyo_gokei = "0";

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCLEAR_FRM");

		}
		#endregion
	}
}
