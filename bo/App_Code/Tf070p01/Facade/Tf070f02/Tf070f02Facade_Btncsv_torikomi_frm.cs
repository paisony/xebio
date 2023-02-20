using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01005;
using Common.Conditions;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f02Facade : StandardBaseFacade
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
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				// CSV取込にて取り込んだレコードを取得
				IList<Hashtable> hachuMstInfo = (IList<Hashtable>)facadeContext.GetUserObject(Tf070p01Constant.DIC_CSV_IMPORT_RESULT);

				// フォームオブジェクト取得
				Tf070f02Form form = (Tf070f02Form)facadeContext.FormVO;

				// 明細オブジェクト取得
				IDataList m1List = form.GetList("M1");

				// 有効現在行数
				int curRowCnt = (int)form.Dictionary[Tf070p01Constant.DIC_CUR_ROW_CNT];

				// 不足行数
				int requiredCnt = curRowCnt + hachuMstInfo.Count - m1List.Count;

				if (requiredCnt > 0)
				{
					// 追加ページ数
					int addPageCnt = (int)Math.Floor(new decimal((requiredCnt - 1) / m1List.DispRow)) + 1;
					// 追加行数
					int addRowCnt = m1List.DispRow * addPageCnt;

					// 行追加
					AddRowCls.AddEmptyRow<Tf070f02M1Form>("M1", "M1rowno", form, addRowCnt);
				}

				// 合計項目
				decimal gokeiSinseiSu;
				decimal.TryParse(form.Gokeisinsei_su, out gokeiSinseiSu);
				decimal gokeiJyuriSu;
				decimal.TryParse(form.Gokeijyuri_su, out gokeiJyuriSu);
				decimal gokeiBaikaKin;
				decimal.TryParse(form.Gokeibaika_kin, out gokeiBaikaKin);

				int index = curRowCnt;
				foreach (Hashtable hachuMstRow in hachuMstInfo)
				{
					Tf070f02M1Form m1Form = (Tf070f02M1Form)m1List[index];

					m1Form.M1hassei_tm = hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_HASSEI_JIKAN].ToString();				// 発生時間
					m1Form.M1hasseibasyo = hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_HASSEI_BASHO].ToString();			// 発生場所
					m1Form.M1bumon_cd = BoSystemFormat.formatBumonCd(hachuMstRow["BUMON_CD"].ToString());				// 部門コード
					m1Form.M1bumonkana_nm = hachuMstRow["BUMONKANA_NM"].ToString();										// 部門カナ名
					m1Form.M1hinsyu_ryaku_nm = hachuMstRow["HINSYU_RYAKU_NM"].ToString();								// 品種略名称
					m1Form.M1hakkentan_cd = BoSystemFormat.formatTantoCd(hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_HAKKENSHA_CD].ToString());	// 発見者コード
					m1Form.M1hakkentan_nm = V01005Check.CheckTanto(m1Form.M1hakkentan_cd, facadeContext)["HANBAIIN_NM"].ToString();				// 担当者名
					m1Form.M1burando_nm = hachuMstRow["BURANDO_NMK"].ToString();										// ブランド名カナ
					m1Form.M1jisya_hbn = BoSystemFormat.formatJisyaHbn(hachuMstRow["XEBIO_CD"].ToString());				// 自社品番
					m1Form.M1hakkenjyokyo_kb = hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_HAKKENJOKYO_KBN].ToString();	// 発見状況区分
					if (m1Form.M1hakkenjyokyo_kb.Equals(ConditionHakkenjyokyo_kb.VALUE_HAKKENJYOKYO_KB7))
					{
						// その他の場合
						m1Form.M1hakkenjyokyo_nm = hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_HAKKENJOKYO_TEXT].ToString().Trim();	// 発見状況テキスト
					}
					else
					{
						m1Form.M1hakkenjyokyo_nm = string.Empty;
					}
					m1Form.M1maker_hbn = hachuMstRow["HIN_NBR"].ToString();		// メーカー品番
					m1Form.M1syonmk = hachuMstRow["SYONMK"].ToString();			// 商品略式名称カナ
					m1Form.M1iro_nm = hachuMstRow["IRO_NM"].ToString();			// 色略式名称カナ
					m1Form.M1size_nm = hachuMstRow["SIZE_NM"].ToString();		// サイズ略名称カナ
					m1Form.M1scan_cd = hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_SCAN_CD].ToString();			// スキャンコード
					m1Form.M1sinsei_su = hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_SINSEI_SU].ToString();		// 申請数
					m1Form.M1sinsei_su_hdn = hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_SINSEI_SU].ToString();	// 申請数（隠し）
					m1Form.M1jyuri_su = BoSystemString.ZeroToEmpty(BoSystemString.Nvl(hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_JURI_SU].ToString(), "0"));	// 受理数
					m1Form.M1jyuri_su_hdn = BoSystemString.Nvl(hachuMstRow[Tf070p01Constant.CSV_ITEM_ID_JURI_SU].ToString(), "0");	// 受理数（隠し）
					m1Form.M1baika_hon = hachuMstRow["BAIKA"].ToString();		// 店別単価

					// 売価金額計算
					decimal baikaKin = this.CalcBaikaKin(form.Stkmodeno, m1Form);
					m1Form.M1baika_kin = baikaKin.ToString();					// 売価金額	
					m1Form.M1baika_kin_hdn = baikaKin.ToString();				// 売価金額（隠し）

					m1Form.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// 未選択
					m1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;	// 確定済
					m1Form.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;		// 通常

					// 合計項目加算
					gokeiSinseiSu += Convert.ToDecimal(m1Form.M1sinsei_su);		// 合計申請数
					gokeiJyuriSu += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1jyuri_su, "0"));	// 合計受理数
					gokeiBaikaKin += Convert.ToDecimal(m1Form.M1baika_kin);		// 合計売価金額

					index++;
				}

				// 合計項目設定
				form.Gokeisinsei_su = gokeiSinseiSu.ToString();		// 合計申請数
				form.Gokeijyuri_su = gokeiJyuriSu.ToString();		// 合計受理数
				form.Gokeibaika_kin = gokeiBaikaKin.ToString();		// 合計売価金額

				int dispPageNo;	// 表示ページ番号
				int focusIndex;	// フォーカス行インデックス
				if (index == decimal.ToInt32(GetMaxCntCls.GetMaxCnt(FORMID.ToUpper(), Tf070p01Constant.MAX_CNT_EDABAN_SHINKI)))
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
					AddRowCls.AddEmptyRow<Tf070f02M1Form>("M1", "M1rowno", form, m1List.DispRow);
				}
				m1List.SetPage(dispPageNo);
				// フォーカス行インデックス設定
				facadeContext.SetUserObject(Tf070p01Constant.DIC_FOCUS_INDEX, focusIndex.ToString());
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_TORIKOMI_FRM");

		}
		#endregion
	}
}
