using com.xebio.bo.Tg010p01.Constant;
using com.xebio.bo.Tg010p01.Formvo;
using com.xebio.bo.Tg010p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Conditions;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tg010p01.Facade
{
  /// <summary>
  /// Tg010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg010f01Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				// サイズ検索にて選択したレコードを取得
				IList<Hashtable> hachuMstInfo = (IList<Hashtable>)facadeContext.GetUserObject(Tg010p01Constant.DIC_SIZE_SEARCH_RESULT);

				// 画面より情報を取得する。
				Tg010f01Form f01VO = (Tg010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				
				// 有効現在行数
				int curRowCnt =Tg010p01Util.GetRowCnt(f01VO.GetList("M1"));

				// 設定店舗
				string setTenpoCd = f01VO.Head_tenpo_cd;
				string setTenpoNm = f01VO.Head_tenpo_nm;

				// 不足行数
				int requiredCnt = curRowCnt + hachuMstInfo.Count - m1List.Count;

                if (requiredCnt > 0)
                {
                    // 追加ページ数
                    int addPageCnt = (int)Math.Floor(new decimal((requiredCnt - 1) / m1List.DispRow)) + 1;
                    // 追加行数
                    int addRowCnt = m1List.DispRow * addPageCnt;

                    // 行追加
                    AddRowCls.AddEmptyRow<Tg010f01M1Form>("M1", "M1rowno", f01VO, addRowCnt);
                }

				// 税率計算クラス
				CalcTaxCls calcTax = new CalcTaxCls(facadeContext);
				TaxVO taxvo = new TaxVO();

				int index = curRowCnt;
                foreach (Hashtable hachuMstRow in hachuMstInfo)
                {
					Tg010f01M1Form f01m1VO = (Tg010f01M1Form)m1List[index];

					f01m1VO.M1bumon_cd = hachuMstRow["BUMON_CD"].ToString();
					f01m1VO.M1bumonkana_nm = hachuMstRow["BUMONKANA_NM"].ToString();
					f01m1VO.M1hinsyu_cd = hachuMstRow["HINSYU_CD"].ToString();
					f01m1VO.M1hinsyu_ryaku_nm = hachuMstRow["HINSYU_RYAKU_NM"].ToString();
					f01m1VO.M1burando_nm = hachuMstRow["BURANDO_NMK"].ToString();
					f01m1VO.M1jisya_hbn = hachuMstRow["XEBIO_CD"].ToString();
					f01m1VO.M1maker_hbn = hachuMstRow["HIN_NBR"].ToString();
					f01m1VO.M1syonmk = hachuMstRow["SYONMK"].ToString();
					f01m1VO.M1iro_nm = hachuMstRow["IRO_NM"].ToString();
					f01m1VO.M1size_nm = hachuMstRow["SIZE_NM"].ToString();
					f01m1VO.M1hanbaikanryo_ymd = hachuMstRow["HANBAIKANRYO_YMD"].ToString();
					f01m1VO.M1scan_cd = hachuMstRow["JAN_CD"].ToString();
					f01m1VO.M1baihenkaisi_ymd = hachuMstRow["BAIHENKAISI_YMD"].ToString();
					f01m1VO.M1sijibaika_tnk = hachuMstRow["SIJIBAIKA_TNK"].ToString();
					f01m1VO.M1saisinbaika_tnk = hachuMstRow["SLPR"].ToString();
					f01m1VO.M1maisu	= hachuMstRow["INPUT_SURYO"].ToString();
					f01m1VO.M1itemkbn = hachuMstRow["ITEMKBN"].ToString();
					f01m1VO.M1siire_kb = hachuMstRow["SIIRE_KB"].ToString();
					f01m1VO.M1tyotatsu_kb = hachuMstRow["TYOTATSU_KB"].ToString();
					f01m1VO.M1makerkakaku_tnk = hachuMstRow["JODAI2_TNK"].ToString();
					// 税込金額計算
					taxvo = calcTax.calcTax(hachuMstRow["SLPR"].ToString(), Convert.ToDecimal(hachuMstRow["ZEI_KB"]));

					f01m1VO.M1baika_zei = taxvo.Zeikomi.ToString();
					f01m1VO.M1burando_cd = hachuMstRow["BURANDO_CD"].ToString();
					f01m1VO.M1bumon_nm = hachuMstRow["BUMON_NM"].ToString();
					f01m1VO.M1siiresaki_cd_bo1 = hachuMstRow["SIIRESAKI_CD"].ToString();
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					index++;
                }
			
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
					AddRowCls.AddEmptyRow<Tg010f01M1Form>("M1", "M1rowno", f01VO, m1List.DispRow);
				}
				m1List.SetPage(dispPageNo);
				// フォーカス行インデックス設定
				facadeContext.SetUserObject(Tg010p01Constant.DIC_FOCUS_INDEX, focusIndex.ToString());

				f01VO.Searchcnt = m1List.Count.ToString();

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSIZSTK_FRM");

		}
		#endregion
	}
}
