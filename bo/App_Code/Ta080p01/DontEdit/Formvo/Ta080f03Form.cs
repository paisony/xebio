using com.xebio.bo.Ta080p01.Formvo.Baseform;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using System;

namespace com.xebio.bo.Ta080p01.Formvo
{
  /// <summary>
  /// Ta080f03のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Ta080f03Form : Ta080f03BaseForm
	{

		#region 実装不可コメント
		//
		// 原則として、このクラスは修正しないで下さい。
		//
		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Ta080f03Form() : base()
		{
			//明細リストVOを初期化する
			InitList();
		}
		#endregion
		
		/// <summary>
		/// 指定明細IDにより明細を初期化する
		/// </summary>
		public void InitList()
		{
			//明細設計情報を取得
			IFormInfo formInfo = FormInfoManager.GetFormInfo("Ta080p01","Ta080f03");
			IListInfo listInfo = null;
			
			listInfo = formInfo.GetListInfo("M1");
			//明細リストVOの初期化
			m1List=DataListFactory.GetDataList(listInfo);
			
			//RepeaterコントロールのstartIndexを指定する。
			m1List.AdjustIndex = 1;
			//明細データを全件チェックモードに設定する場合は、コメントを解除して下さい。
			//このコードを使用するために、Common.Advanced.Utilをusingに追加してください。
			//using Common.Advanced.Util;
			//m1List.ListCheck = ListCheckCode.ALL;
		}

	}
}
