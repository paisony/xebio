using com.xebio.bo.Tm070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01018;
using Common.IntegrationMD.Constant;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Tm070p01.Facade
{
  /// <summary>
  /// Tm070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm070f01Facade : StandardBaseFacade
	{
		#region M1明細の行を一括で増やします。(ボタンID : Btnpageins)
		/// <summary>
		/// M1明細の行を増やします。
		/// ボタンID(Btnpageins)
		/// アクションID(MINSX)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNPAGEINS_MINSX(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPAGEINS_MINSX");
			//M1明細リストを取得
			Tm070f01Form f01VO = (Tm070f01Form)facadeContext.FormVO;
			IDataList m1List = f01VO.GetList("M1");
			//明細フォーカスセット用インデックスをセットします。
			facadeContext.SetUserObject(MdSystemConstant.DETAIL_FOCUS_INDEX, GetDetailFocusIndex(m1List));

			//1度に追加する行数を設定します。
			int addCount = m1List.DispRow;
			//表示している件数を取得
			int rowCount = m1List.Count;
			//表示後件数
			int afterCount = addCount + rowCount;

			#region 件数チェック

			// コンフィグファイルより最大件数を取得
			Decimal dCnt = GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper());

			if (afterCount > dCnt)
			{
				// 最大件数を超えている場合、エラーとする。
				ErrMsgCls.AddErrMsg("E147", dCnt.ToString(), facadeContext);
			}

			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}
			#endregion

			// ページを追加
			Hashtable defVal = new Hashtable();
			defVal["M1henko_tenpo_cd"] = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)];
			defVal["M1henko_tenpo_nm"] = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_nm)];

			AddRowCls.AddEmptyRow<Tm070f01M1Form>("M1", "M1rowno", (Tm070f01Form)facadeContext.FormVO, m1List.DispRow, defVal);
			SetPageIndex(m1List, m1List.DispRow);

			// 表示ページ設定
			int dispPageNo = afterCount / m1List.DispRow;
			m1List.SetPage(dispPageNo);

			// 検索件数の設定
			f01VO.Searchcnt = m1List.Count.ToString();

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPAGEINS_MINSX");

		}
		#endregion
	}
}
