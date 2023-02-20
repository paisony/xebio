using com.xebio.bo.Tb050p01.Constant;
using com.xebio.bo.Tb050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Conditions;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tb050p01.Facade
{
  /// <summary>
  /// Tb050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb050f01Facade : StandardBaseFacade
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

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

			try
			{
			//	//DBコンテキストを設定する。
			//	SetDBContext(facadeContext);
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				
				//以下に業務ロジックを記述する。

				// サイズ検索にて選択したレコードを取得
				IList<Hashtable> hachuMstInfo = (IList<Hashtable>)facadeContext.GetUserObject(Tb050p01Constant.DIC_SIZE_SEARCH_RESULT);

				// 画面より情報を取得する。
				Tb050f01Form form = (Tb050f01Form)facadeContext.FormVO;
				IDataList m1List = form.GetList("M1");

				// 不足行数の追加
				int index = this.addRequireRow(form, hachuMstInfo.Count);

				foreach (Hashtable hachuMstRow in hachuMstInfo)
				{
					Tb050f01M1Form m1Form = (Tb050f01M1Form)m1List[index];

					m1Form.M1tenpo_cd = form.Head_tenpo_cd;									// Ｍ１店舗コード
					m1Form.M1tenpo_nm = form.Head_tenpo_nm;									// Ｍ１店舗名
					m1Form.M1bumon_cd = hachuMstRow["BUMON_CD"].ToString();					// Ｍ１部門コード
					m1Form.M1bumonkana_nm = hachuMstRow["BUMONKANA_NM"].ToString();			// Ｍ１部門カナ名
					m1Form.M1hinsyu_ryaku_nm = hachuMstRow["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
					m1Form.M1burando_nm = hachuMstRow["BURANDO_NMK"].ToString();			// Ｍ１ブランド名
					m1Form.M1jisya_hbn = hachuMstRow["XEBIO_CD"].ToString();				// Ｍ１自社品番
					m1Form.M1maker_hbn = hachuMstRow["HIN_NBR"].ToString();					// Ｍ１メーカー品番
					m1Form.M1syonmk = hachuMstRow["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					m1Form.M1iro_nm = hachuMstRow["IRO_NM"].ToString();						// Ｍ１色
					m1Form.M1size_nm = hachuMstRow["SIZE_NM"].ToString();					// Ｍ１サイズ
					m1Form.M1scan_cd = hachuMstRow["JAN_CD"].ToString();					// Ｍ１スキャンコード
					m1Form.M1gen_tnk = hachuMstRow["GENKA"].ToString();						// Ｍ１原単価
					m1Form.M1kensu = hachuMstRow["INPUT_SURYO"].ToString();					// Ｍ１検数
					m1Form.M1genka_kin = (Convert.ToDecimal(m1Form.M1kensu) * Convert.ToDecimal(m1Form.M1gen_tnk)).ToString();
																							// Ｍ１原価金額
					m1Form.M1kensu_hdn = m1Form.M1kensu;									// Ｍ１検数（隠し）
					m1Form.M1genka_kin_hdn = m1Form.M1genka_kin;							// Ｍ１原価金額（隠し）

					m1Form.M1selectorcheckbox = ConditionKakuteisyori_flg.VALUE_NASI;		// Ｍ１選択フラグ(隠し)
					m1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;			// Ｍ１確定処理フラグ(隠し)
					m1Form.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;				// Ｍ１明細色区分(隠し)

					index++;
				}

				// 合計数計算
				this.setGokei(form);

				// 表示ページ設定
				int dispPageNo;	// 表示ページ番号
				int focusIndex;	// フォーカス行インデックス
				if (index == decimal.ToInt32(GetMaxCntCls.GetMaxCnt(FORMID.ToUpper())))
				{
					// 最終行まで設定された場合
					dispPageNo = decimal.ToInt32(Math.Floor(new decimal((index - 1) / m1List.DispRow))) + 1;
					focusIndex = (index - 1) % m1List.DispRow;
				}
				else
				{
					dispPageNo = decimal.ToInt32(Math.Floor(new decimal(index / m1List.DispRow))) + 1;
					focusIndex = index % m1List.DispRow;
				}
				// 表示ページ設定
				if (dispPageNo > m1List.PageCount)
				{
					// ページ追加処理
					AddRowCls.AddEmptyRow<Tb050f01M1Form>("M1", "M1rowno", form, m1List.DispRow);
				}
				m1List.SetPage(dispPageNo);
				// フォーカス行インデックス設定
				facadeContext.SetUserObject(Tb050p01Constant.DIC_FOCUS_INDEX, focusIndex.ToString());


			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
			//	//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
			//	//コネクションを開放する。
			//	CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

		}
		#endregion
	}
}
