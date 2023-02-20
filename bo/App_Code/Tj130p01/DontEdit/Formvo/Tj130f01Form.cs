using com.xebio.bo.Tj130p01.Formvo.Baseform;
using Common.Advanced.Formvo;
using Common.Advanced.Info;
using System;

namespace com.xebio.bo.Tj130p01.Formvo
{
  /// <summary>
  /// Tj130f01のFormオブジェクトです。
  /// </summary>
  [Serializable]
	public class Tj130f01Form : Tj130f01BaseForm
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
		public Tj130f01Form() : base()
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
			IFormInfo formInfo = FormInfoManager.GetFormInfo("Tj130p01","Tj130f01");
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
