using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f02Facade : StandardBaseFacade
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
				////DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				// サイズ検索にて選択したレコードを取得
				IList<Hashtable> hachuMstInfo = (IList<Hashtable>)facadeContext.GetUserObject(Tg040p01Constant.DIC_SIZE_SEARCH_RESULT);

				// 画面より情報を取得する。
				Tg040f02Form form = (Tg040f02Form)facadeContext.FormVO;
				IDataList m1List = form.GetList("M1");

				// 有効現在行数
				int curRowCnt = 0;

				for (int i = m1List.Count - 1; i >= 0; i--)
				{
					// 行オブジェクト取得
					Tg040f02M1Form m1Form = (Tg040f02M1Form)m1List[i];

					// いずれかの入力項目が入力されている場合
					if (!string.IsNullOrEmpty(m1Form.M1scan_cd) || !string.IsNullOrEmpty(m1Form.M1suryo))
					{
						// 有効現在行数が未設定の場合
						if (curRowCnt == 0)
						{
							curRowCnt = i + 1;
							break;
						}
					}
				}

				// 不足行数
				int requiredCnt = curRowCnt + hachuMstInfo.Count - m1List.Count;

				if (requiredCnt > 0)
				{
					// 追加行数
					int addRowCnt = requiredCnt;
					// 行追加
					AddRowCls.AddEmptyRow<Tg040f02M1Form>("M1", "M1rowno", form, addRowCnt);

					// 新規作成時は、ページ追加
					if (BoSystemConstant.MODE_INSERT.Equals(form.Stkmodeno))
					{
						// ページ追加
						AddRowCls.AddEmptyPage<Tg040f02M1Form>("M1", "M1rowno", form);
					}

				}
				//if (requiredCnt > 0)
				//{
				//	// 追加ページ数
				//	int addPageCnt = (int)Math.Floor(new decimal((requiredCnt - 1) / m1List.DispRow));

				//	// 追加行数
				//	int addRowCnt = 0;
				//	if (addPageCnt == 0)
				//	{
				//		addRowCnt = requiredCnt;
				//	}
				//	else
				//	{
				//		addRowCnt = m1List.DispRow * addPageCnt;
				//	}

				//	AddRowCls.AddEmptyRow<Tg040f02M1Form>("M1", "M1rowno", form, addRowCnt);
				//}
				int index = curRowCnt;

				// 合計数計算
				Decimal dGokei_suryo = 0;

				foreach (Hashtable hachuMstRow in hachuMstInfo)
				{
					Tg040f02M1Form m1Form = (Tg040f02M1Form)m1List[index];

					m1Form.M1bumon_cd = hachuMstRow["BUMON_CD"].ToString();					// Ｍ１部門コード
					m1Form.M1bumonkana_nm = hachuMstRow["BUMONKANA_NM"].ToString();			// Ｍ１部門カナ名
					m1Form.M1hinsyu_ryaku_nm = hachuMstRow["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
					m1Form.M1burando_nm = hachuMstRow["BURANDO_NMK"].ToString();			// Ｍ１ブランド名
					m1Form.M1jisya_hbn = hachuMstRow["XEBIO_CD"].ToString();				// Ｍ１自社品番
					m1Form.M1maker_hbn = hachuMstRow["HIN_NBR"].ToString();					// Ｍ１メーカー品番
					m1Form.M1syonmk = hachuMstRow["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					m1Form.M1scan_cd = hachuMstRow["JAN_CD"].ToString();					// Ｍ１スキャンコード
					m1Form.M1hanbaikanryo_ymd = hachuMstRow["HANBAIKANRYO_YMD"].ToString();	// Ｍ１販売完了日
					m1Form.M1iro_nm = hachuMstRow["IRO_NM"].ToString();						// Ｍ１色
					m1Form.M1size_nm = hachuMstRow["SIZE_NM"].ToString();					// Ｍ１サイズ
					m1Form.M1suryo = hachuMstRow["INPUT_SURYO"].ToString();					// Ｍ１数量
					m1Form.M1suryo_hdn = m1Form.M1suryo;									// Ｍ１数量（隠し）
					m1Form.M1hinsyu_cd = hachuMstRow["HINSYU_CD"].ToString();				// Ｍ１品種コード

					m1Form.M1selectorcheckbox = ConditionKakuteisyori_flg.VALUE_NASI;		// Ｍ１選択フラグ(隠し)
					m1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;			// Ｍ１確定処理フラグ(隠し)
					m1Form.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;				// Ｍ１明細色区分(隠し)

					index++;
				}

				// 明細計算
				for (int i = 0; i < m1List.Count; i++)
				{
					Tg040f02M1Form m1Form = (Tg040f02M1Form)m1List[i];

					// Ｍ１数量の合計
					dGokei_suryo += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1suryo, "0").ToString());
				}
				form.Gokei_suryo = dGokei_suryo.ToString();									// 合計数量

				// 表示ページ設定
				int dispPageNo;	// 表示ページ番号
				int focusIndex;	// フォーカス行インデックス

				if (BoSystemConstant.MODE_INSERT.Equals(form.Stkmodeno))
				{
					// 新規作成の場合
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
						AddRowCls.AddEmptyRow<Tg040f02M1Form>("M1", "M1rowno", form, m1List.DispRow);
					}
				}
				else
				{
					// 新規作成以外の場合
					dispPageNo = (int)Math.Floor(new decimal((m1List.Count - 1) / m1List.DispRow)) + 1;
					focusIndex = (index - 1) % m1List.DispRow;
				}

				m1List.SetPage(dispPageNo);
				// フォーカス行インデックス設定
				facadeContext.SetUserObject(Tg040p01Constant.DIC_FOCUS_INDEX, focusIndex.ToString());


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
				////コネクションを開放する。
				//CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

		}
		#endregion
	}
}
