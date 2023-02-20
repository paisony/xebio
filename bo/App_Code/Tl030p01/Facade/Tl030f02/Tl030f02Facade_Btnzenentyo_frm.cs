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
		
		#region フォームを呼び出します。(ボタンID : Btnzenentyo)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnzenentyo)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNZENENTYO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNZENENTYO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				// 画面より情報を取得する。
				Tl030f02Form f01VO = (Tl030f02Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧画面の選択明細行情報取得
				Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f01VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

				// システム日付取得
				String sysDateVO = f01VO.Dictionary[Tl030p01Constant.DIC_SYSDATE].ToString();

				// チェック可能な延長を全て選択状態にする。
				// 売変を全て未選択状態にする。
				for (int i = 0; i < m1List.Count; i++)
				{
					Tl030f02M1Form f01m1VO = (Tl030f02M1Form)m1List[i];

					// 開始日-1、開始日+2を取得
					DateTime kaisi_ymd;

					if (DateTime.TryParse(BoSystemFormat.formatDate(f01VO.Baihenkaisi_ymd,1), out kaisi_ymd))
					{
						DateTime kaisi_ymd_bf = kaisi_ymd.AddDays(-1);
						DateTime kaisi_ymd_af = kaisi_ymd.AddDays(2);
						if (kaisi_ymd_bf <= DateTime.Parse(BoSystemFormat.formatDate(sysDateVO, 1)) && DateTime.Parse(BoSystemFormat.formatDate(sysDateVO, 1)) <= kaisi_ymd_af
							&& ConditionBaihen_riytu.VALUE_BAIHEN_RIYTU1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_RIYTU].ToString()))
						{
							f01m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_ON;
							// 確定フラグを設定する
							f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;
						}
						else
						{
							// チェックしない
						}
					}

					// 売変を全て未選択状態にする。
					f01m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_OFF;
				}
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNZENENTYO_FRM");

		}
		#endregion
	}
}
