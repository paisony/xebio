using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using com.xebio.bo.Ta080p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Business.C99999.Constant;
using Common.Business.C99999.StringUtil;
using Common.Standard.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f03のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f03Facade : StandardBaseFacade
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
				//コネクションを取得を開始する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				#region 初期処理
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// サイズ検索にて選択したレコードを取得
				IList<Hashtable> hachuMstInfo = (IList<Hashtable>)facadeContext.GetUserObject(Ta080p01Constant.KEY_SIZE_SEARCH_RESULT);

				// フォームオブジェクト取得
				Ta080f03Form form = (Ta080f03Form)facadeContext.FormVO;
				// 明細オブジェクト取得
				IDataList m1List = form.GetList("M1");

				// 有効現在行数
				int curRowCnt = Ta080p01Util.GetRowCnt(m1List);
				// 設定店舗(新規作成時のみ有効のため、ヘッダ情報より設定)
				string setTenpoCd = form.Head_tenpo_cd;
				string setTenpoNm = form.Head_tenpo_nm;
				#endregion

				#region 不足行追加
				int requiredCnt = curRowCnt + hachuMstInfo.Count - m1List.Count;
				if (requiredCnt > 0)
				{
					// 追加行数
					int addRowCnt = requiredCnt;
					// 行追加
					AddRowCls.AddEmptyRow<Ta080f03M1Form>("M1", "M1rowno", form, addRowCnt);

					// 新規作成時は、ページ追加
					if (BoSystemConstant.MODE_INSERT.Equals(form.Stkmodeno))
					{
						// ページ追加
						AddRowCls.AddEmptyPage<Ta080f03M1Form>("M1", "M1rowno", form);
					}
				}
				#endregion

				int index = curRowCnt;
				foreach (Hashtable hachuMstRow in hachuMstInfo)
				{
					// 発注マスタ情報設定
					Ta080p01Util.DoMstMeisaiCopy(facadeContext, (Ta080f03M1Form)m1List[index], hachuMstRow);
					Decimal wkSuryo = Convert.ToDecimal(BoSystemString.Nvl(((Ta080f03M1Form)m1List[index]).M1irai_su, "0"));
					Decimal genkakin = Convert.ToDecimal(BoSystemString.Nvl(hachuMstRow["GENKA"].ToString(), "0")) * wkSuryo;
					if (!string.IsNullOrEmpty(hachuMstRow["GENKA"].ToString()))
					{
						((Ta080f03M1Form)m1List[index]).M1genkakin = genkakin.ToString();							// 原価金額
						((Ta080f03M1Form)m1List[index]).M1genkakin_hdn = genkakin.ToString();						// 原価金額（隠し）

						((Ta080f03M1Form)m1List[index]).M1entersyoriflg = Ta080p01Constant.FLG_ON.ToString();		// 確定処理フラグ
					}
					// 発注メッセージ取得
					((Ta080f03M1Form)m1List[index]).M1hatchu_msg = Ta080p01Util.GetHtms((Ta080f03M1Form)m1List[index], sysDateVO);
					index++;
				}

				// 合計計算処理
				SumGoukeiDetail(form);

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
						AddRowCls.AddEmptyRow<Ta080f02M1Form>("M1", "M1rowno", form, m1List.DispRow);
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
				facadeContext.SetUserObject(Ta080p01Constant.KEY_SIZE_FOCUS_INDEX, focusIndex.ToString());

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
