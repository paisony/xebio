using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnsizstk)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsizstk)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSIZSTK_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

			try
			{
				//DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);

			
				//以下に業務ロジックを記述する。
				// サイズ検索にて選択したレコードを取得
				IList<Hashtable> hachuMstInfo = (IList<Hashtable>)facadeContext.GetUserObject(Tj190p01Constant.DIC_SIZE_SEARCH_RESULT);

				// 画面より情報を取得する。
				Tj190f02Form form = (Tj190f02Form)facadeContext.FormVO;
				IDataList m1List = form.GetList("M1");

				// 有効現在行数
				int curRowCnt = 0;

				for (int i = m1List.Count - 1; i >= 0; i--)
				{
					// 行オブジェクト取得
					Tj190f02M1Form m1Form = (Tj190f02M1Form)m1List[i];

					if (!string.IsNullOrEmpty(m1Form.M1scan_cd)
						|| !string.IsNullOrEmpty(m1Form.M1jitana_su)
						)
					{
						// いずれかの入力項目が入力されている場合
						if (curRowCnt == 0)
						{
							// 有効現在行数が未設定の場合
							curRowCnt = i + 1;
							break;
						}
					}
				}

				// 不足行数
				int requiredCnt = curRowCnt + hachuMstInfo.Count - m1List.Count;

				if (requiredCnt > 0)
				{
					// 追加ページ数
					int addPageCnt = (int)Math.Floor(new decimal((requiredCnt - 1) / m1List.DispRow));

					// 追加行数
					int addRowCnt = 0;
					if (addPageCnt == 0)
					{
						addRowCnt = requiredCnt;
					}
					else
					{
						addRowCnt = m1List.DispRow * addPageCnt;
					}

					// 行追加
					AddRowCls.AddEmptyRow<Tj190f02M1Form>("M1", "M1rowno", form, addRowCnt);
				}
				int index = curRowCnt;

				// 合計数計算
				Decimal dGokeitanajityobo_su = 0;
				Decimal dGokeitanajisekiso_su = 0;
				Decimal dGokeijitana_su = 0;
				Decimal dGokeiloss_su = 0;
				Decimal dGokeiloss_kin = 0;

				string old_xebio_cd = string.Empty;

				foreach (Hashtable hachuMstRow in hachuMstInfo)
				{
					Tj190f02M1Form m1Form = (Tj190f02M1Form)m1List[index];

					m1Form.M1hinsyu_ryaku_nm = hachuMstRow["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
					m1Form.M1burando_nm = hachuMstRow["BURANDO_NMK"].ToString();			// Ｍ１ブランド名
					m1Form.M1jisya_hbn = hachuMstRow["XEBIO_CD"].ToString();				// Ｍ１自社品番
					m1Form.M1maker_hbn = hachuMstRow["HIN_NBR"].ToString();					// Ｍ１メーカー品番
					m1Form.M1syonmk = hachuMstRow["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					m1Form.M1iro_nm = hachuMstRow["IRO_NM"].ToString();						// Ｍ１色
					m1Form.M1size_nm = hachuMstRow["SIZE_NM"].ToString();					// Ｍ１サイズ
					m1Form.M1scan_cd = hachuMstRow["JAN_CD"].ToString();					// Ｍ１スキャンコード
					m1Form.M1hyoka_tnk = hachuMstRow["HYOKA_TNK"].ToString();				// Ｍ１評価単価
					m1Form.M1tanajityobo_su = hachuMstRow["TYOBOZAIKO_SU"].ToString();		// Ｍ１棚時帳簿数
					m1Form.M1tanajisekiso_su = hachuMstRow["SEKISO_SU"].ToString();			// Ｍ１棚時積送数
					m1Form.M1jitana_su = hachuMstRow["INPUT_SURYO"].ToString();				// Ｍ１実棚数
					m1Form.M1jitana_su1_hdn = hachuMstRow["INPUT_SURYO"].ToString();		// Ｍ１実棚数（隠し）
					// ロス数計算 Ｍ１棚時帳簿数 - Ｍ１棚時積送数 - Ｍ１実棚数
					m1Form.M1loss_su = (Convert.ToDecimal(m1Form.M1tanajityobo_su) - Convert.ToDecimal(m1Form.M1tanajisekiso_su) - Convert.ToDecimal(m1Form.M1jitana_su)).ToString();
																							// Ｍ１ロス数
					// ロス金額計算 Ｍ１ロス数 * Ｍ１評価単価
					m1Form.M1loss_kin = (Convert.ToDecimal(m1Form.M1loss_su) * Convert.ToDecimal(m1Form.M1hyoka_tnk)).ToString();
																							// Ｍ１ロス金額

					m1Form.M1selectorcheckbox = "0";										// Ｍ１選択フラグ(隠し)
					m1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;			// Ｍ１確定処理フラグ(隠し)

					m1Form.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					index++;
				}

				// 明細計算
				for (int i = 0; i < m1List.Count; i++)
				{
					Tj190f02M1Form m1Form = (Tj190f02M1Form)m1List[i];

					// Ｍ１棚時帳簿数の合計
					dGokeitanajityobo_su += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1tanajityobo_su,"0"));
					// Ｍ１棚時積送数の合計
					dGokeitanajisekiso_su += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1tanajisekiso_su,"0"));
					// Ｍ１実棚数の合計
					dGokeijitana_su += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1jitana_su,"0"));
					// Ｍ１ロス数の合計
					dGokeiloss_su += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1loss_su,"0"));
					// Ｍ１ロス金額の合計
					dGokeiloss_kin += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1loss_kin,"0"));
				}


				form.Dictionary[Tj190p01Constant.DIC_TENPO_CD] = form.Tenpo_cd_hdn;			// 店舗コード(隠し)
				form.Gokeitanajityobo_su = dGokeitanajityobo_su.ToString();					// 合計棚時帳簿数
				form.Gokeitanajisekiso_su = dGokeitanajisekiso_su.ToString();				// 合計棚時積送数
				form.Gokeijitana_su = dGokeijitana_su.ToString();							// 合計実棚数
				form.Gokeiloss_su = dGokeiloss_su.ToString();								// 合計ロス数
				form.Gokeiloss_kin = dGokeiloss_kin.ToString();								// 合計ロス金額

				// 表示ページ設定
				int dispPageNo = (int)Math.Floor(new decimal((m1List.Count - 1) / m1List.DispRow)) + 1;
				m1List.SetPage(dispPageNo);

				// フォーカス行インデックス
				facadeContext.SetUserObject(Tj190p01Constant.DIC_FOCUS_INDEX, ((index - 1) % m1List.DispRow).ToString());

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
				//CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

		}
		#endregion
	}
}
