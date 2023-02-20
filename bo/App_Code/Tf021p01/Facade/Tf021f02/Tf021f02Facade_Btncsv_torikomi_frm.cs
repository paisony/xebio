using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01024;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using com.xebio.bo.Tf021p01.Constant;
using com.xebio.bo.Tf021p01.Formvo;
using Common.Standard.Base;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using System;
using System.Collections;
using System.Collections.Generic;
	
namespace com.xebio.bo.Tf021p01.Facade
{
	/// <summary>
	/// Tf021f02のFacadeクラスです
	/// 各アクションの業務ロジックを実装します。
	/// </summary>
	public partial class Tf021f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btncsv_torikomi)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv_torikomi)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNCSV_TORIKOMI_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_TORIKOMI_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。
				// CSV取込にて取り込んだレコードを取得
				IList<Hashtable> csvInfo = (IList<Hashtable>)facadeContext.GetUserObject(Tf021p01Constant.DIC_CSV_IMPORT_RESULT);

				// フォームオブジェクト取得
				Tf021f02Form form = (Tf021f02Form)facadeContext.FormVO;
				IDataList m1List = form.GetList("M1");

				// CSVチェック情報取得
				CsvCheckInfoVO checkInfo = (CsvCheckInfoVO)form.Dictionary[Tf021p01Constant.DIC_CSV_CHECK_INFO];

				// 不足行数の追加
				int index = addRequireRow(form, csvInfo.Count);

				foreach (Hashtable csvRow in csvInfo)
				{
					Tf021f02M1Form m1Form = (Tf021f02M1Form)m1List[index];

					m1Form.M1bumon_cd = csvRow["BUMON_CD"].ToString();									// Ｍ１部門コード
					m1Form.M1bumonkana_nm = csvRow["BUMONKANA_NM"].ToString();							// Ｍ１部門カナ名
					m1Form.M1hinsyu_ryaku_nm = csvRow["HINSYU_RYAKU_NM"].ToString();					// Ｍ１品種略名称
					m1Form.M1burando_nm = csvRow["BURANDO_NMK"].ToString();								// Ｍ１ブランド名
					m1Form.M1jisya_hbn = csvRow["XEBIO_CD"].ToString();									// Ｍ１自社品番
					m1Form.M1maker_hbn = csvRow["HIN_NBR"].ToString();									// Ｍ１メーカー品番
					m1Form.M1syonmk = csvRow["SYONMK"].ToString();										// Ｍ１商品名(カナ)
					m1Form.M1iro_nm = csvRow["IRO_NM"].ToString();										// Ｍ１色
					m1Form.M1size_nm = csvRow["SIZE_NM"].ToString();									// Ｍ１サイズ
					m1Form.M1scan_cd = csvRow[checkInfo.List_csv_item_info[0].Item_id].ToString();		// Ｍ１スキャンコード
					m1Form.M1suryo = csvRow[checkInfo.List_csv_item_info[1].Item_id].ToString();		// Ｍ１数量
					m1Form.M1gen_tnk = csvRow["HYOKA_TNK"].ToString();									// Ｍ１原単価
					m1Form.M1genka_kin = (decimal.Parse(m1Form.M1gen_tnk) * decimal.Parse(m1Form.M1suryo)).ToString();
																										// Ｍ１原価金額
					m1Form.M1genbaika_tnk = csvRow["SLPR"].ToString();									// Ｍ１現売価
					m1Form.M1gokeibaika_kin = (decimal.Parse(m1Form.M1genbaika_tnk) * decimal.Parse(m1Form.M1suryo)).ToString();
																										// Ｍ１売価金額
					m1Form.M1suryo_hdn = m1Form.M1suryo;												// Ｍ１数量（隠し）
					m1Form.M1genka_kin_hdn = m1Form.M1genka_kin;										// Ｍ１原価金額（隠し）

					m1Form.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;							// Ｍ１選択フラグ(隠し)
					m1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;						// Ｍ１確定処理フラグ(隠し)
					m1Form.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;							// Ｍ１明細色区分(隠し)

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
					AddRowCls.AddEmptyRow<Tf021f02M1Form>("M1", "M1rowno", form, m1List.DispRow);
				}
				m1List.SetPage(dispPageNo);
				// フォーカス行インデックス設定
				facadeContext.SetUserObject(Tf021p01Constant.DIC_FOCUS_INDEX, focusIndex.ToString());
				
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
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_TORIKOMI_FRM");

		}
		#endregion

		#region ユーザー定義関数

		/// <summary>
		/// 不足行数を追加し、有効現在行数を返す。
		/// </summary>
		/// <param name="form">一覧画面のVO</param>
		/// <param name="addCnt">追加行数</param>
		/// <returns>有効現在行数</returns>
		private int addRequireRow(Tf021f02Form form, int addCnt)
		{
			// 有効現在行数
			int curRowCnt = 0;

			// 明細オブジェクト取得
			IDataList m1List = form.GetList("M1");


			for (int i = m1List.Count - 1; i >= 0; i--)
			{
				// 行オブジェクト取得
				Tf021f02M1Form m1Form = (Tf021f02M1Form)m1List[i];

				if (!string.IsNullOrEmpty(m1Form.M1scan_cd)
					|| !string.IsNullOrEmpty(m1Form.M1suryo))
				{
					// いずれかの入力項目が入力されている場合
					curRowCnt = i + 1;
					break;
				}
			}

			// 不足行数
			int requiredCnt = curRowCnt + addCnt - m1List.Count;

			if (requiredCnt > 0)
			{
				// 追加ページ数
				int addPageCnt = (int)Math.Floor(new decimal((requiredCnt - 1) / m1List.DispRow)) + 1;
				// 追加行数
				int addRowCnt = m1List.DispRow * addPageCnt;

				// 行追加
				Hashtable defVal = null;

				AddRowCls.AddEmptyRow<Tf021f02M1Form>("M1", "M1rowno", form, addRowCnt, defVal);
			}

			return curRowCnt;

		}

		/// <summary>
		/// 合計欄を計算し設定する。
		/// </summary>
		/// <param name="form">一覧画面のVO</param>
		private void setGokei(Tf021f02Form form)
		{

			// 明細オブジェクト取得
			IDataList m1List = form.GetList("M1");

			// 合計数計算
			Decimal dGokei_suryo = 0;
			Decimal dGokeigenka_kin = 0;

			// 明細計算
			for (int i = 0; i < m1List.Count; i++)
			{
				Tf021f02M1Form m1Form = (Tf021f02M1Form)m1List[i];

				// Ｍ１検数の合計
				dGokei_suryo += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1suryo, "0").ToString());
				// Ｍ１原価金額の合計
				dGokeigenka_kin += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1genka_kin, "0").ToString());
			}

			form.Gokei_suryo = dGokei_suryo.ToString();									// 合計数量
			form.Genka_kin_gokei = dGokeigenka_kin.ToString();							// 合計原価金額

		}

		#endregion
	}
}
