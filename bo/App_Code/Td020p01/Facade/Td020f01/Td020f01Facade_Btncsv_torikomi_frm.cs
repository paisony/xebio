using com.xebio.bo.Td020p01.Constant;
using com.xebio.bo.Td020p01.Formvo;
using com.xebio.bo.Td020p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01024;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Td020p01.Facade
{
  /// <summary>
  /// Td020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td020f01Facade : StandardBaseFacade
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
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。
				// CSV取込にて取り込んだレコードを取得
				IList<Hashtable> csvInfo = (IList<Hashtable>)facadeContext.GetUserObject(Td020p01Constant.KEY_CSV_IMPORT_RESULT);
				// フォームオブジェクト取得
				Td020f01Form form = (Td020f01Form)facadeContext.FormVO;
				// 明細オブジェクト取得
				IDataList m1List = form.GetList("M1");

				// CSVチェック情報取得
				CsvCheckInfoVO checkInfo = (CsvCheckInfoVO)form.Dictionary[Td020p01Constant.KEY_CSV_CHECK_INFO];

				// 有効現在行数
				int curRowCnt = Td020p01Util.GetRowCnt(m1List);
				// 設定店舗(新規作成時のみ有効のため、ヘッダ情報より設定)
				string setTenpoCd = form.Head_tenpo_cd;
				string setTenpoNm = form.Head_tenpo_nm;

				// 不足行数
				int requiredCnt = curRowCnt + csvInfo.Count - m1List.Count;
				if (requiredCnt > 0)
				{
					// 追加ページ数
					int addPageCnt = (int)Math.Floor(new decimal((requiredCnt - 1) / m1List.DispRow)) + 1;
					// 追加行数
					int addRowCnt = m1List.DispRow * addPageCnt;

					// 行追加
					AddRowCls.AddEmptyRow<Td020f01M1Form>("M1", "M1rowno", form, addRowCnt);
				}

				int index = curRowCnt;
				foreach (Hashtable csvRow in csvInfo)
				{
					// ＣＳＶ取込情報設定
					DoShohinCopy((Td020f01M1Form)m1List[index], csvRow, setTenpoCd, false, true);
					// ＣＳＶ固有の項目設定
					((Td020f01M1Form)m1List[index]).M1tenpo_cd = csvRow[checkInfo.List_csv_item_info[0].Item_id].ToString();		// Ｍ１店舗コード
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(((Td020f01M1Form)m1List[index]).M1tenpo_cd, facadeContext);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						((Td020f01M1Form)m1List[index]).M1tenpo_nm = resultHash["TENPO_NM"].ToString();
					}

					((Td020f01M1Form)m1List[index]).M1scan_cd = csvRow[checkInfo.List_csv_item_info[1].Item_id].ToString();			// Ｍ１スキャンコード
					((Td020f01M1Form)m1List[index]).M1itemsu = csvRow[checkInfo.List_csv_item_info[2].Item_id].ToString();			// Ｍ１数量

					Decimal wkSuryo = Convert.ToDecimal(BoSystemString.Nvl(((Td020f01M1Form)m1List[index]).M1itemsu, "0"));
					Decimal genkakin = Convert.ToDecimal(BoSystemString.Nvl(csvRow["GENKA"].ToString(), "0")) * wkSuryo;
					if (!string.IsNullOrEmpty(csvRow["GENKA"].ToString()))
					{
						((Td020f01M1Form)m1List[index]).M1genkakin = genkakin.ToString();							// 原価金額
						((Td020f01M1Form)m1List[index]).M1genka_kin_hdn = genkakin.ToString();						// 原価金額（隠し）
					}
					index++;
				}

				// 合計計算処理
				SumGoukeiDetail(form);

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
					AddRowCls.AddEmptyRow<Td020f01M1Form>("M1", "M1rowno", form, m1List.DispRow);
				}
				m1List.SetPage(dispPageNo);
				// フォーカス行インデックス設定
				facadeContext.SetUserObject(Td020p01Constant.KEY_CSV_FOCUS_INDEX, focusIndex.ToString());



				////トランザクションをコミットする。
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_TORIKOMI_FRM");

		}
		#endregion
	}
}
