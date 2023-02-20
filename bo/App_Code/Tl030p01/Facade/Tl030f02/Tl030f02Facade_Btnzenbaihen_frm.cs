using com.xebio.bo.Tl030p01.Constant;
using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Conditions;
using Common.Standard.Base;
using System;

namespace com.xebio.bo.Tl030p01.Facade
{
  /// <summary>
  /// Tl030f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl030f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnzenbaihen)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenbaihen)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNZENBAIHEN_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENBAIHEN_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				// 画面より情報を取得する。
				Tl030f02Form f01VO = (Tl030f02Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				String sysDateVO = f01VO.Dictionary[Tl030p01Constant.DIC_SYSDATE].ToString();

				// チェック可能な売変を全て選択状態にする。
				// 延長を全て未選択状態にする。
				for (int i = 0; i < m1List.Count; i++)
				{
					Tl030f02M1Form f01m1VO = (Tl030f02M1Form)m1List[i];

					// Ｍ１承認状態

					// 作業開始日＜システム日付かつ、Ｍ１確定処理フラグ(隠し)="0"の行を対象とする
					// 作業開始日、開始日を設定
					DateTime dtSagyokaisi_ymd;

					// 作業開始日が正常な日付だった場合
					if (DateTime.TryParse(BoSystemFormat.formatDate(f01VO.Aihensagyokaisi_ymd,1), out dtSagyokaisi_ymd))
					{
						if (dtSagyokaisi_ymd <= DateTime.Parse(BoSystemFormat.formatDate(sysDateVO, 1))
							&& f01m1VO.Dictionary[Tl030p01Constant.DIC_M1ENTERSYORIFLG].ToString().Equals(ConditionKakuteisyori_flg.VALUE_NASI))
						{

							f01m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_ON;
							// 確定フラグを設定する
							f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;
						}
						else
						{
							// チェックしない
						}
					}

					// 延長を全て未選択状態にする。
					f01m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_OFF;
				}

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENBAIHEN_FRM");

		}
		#endregion
	}
}
