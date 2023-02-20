using com.xebio.bo.Tk020p01.Constant;
using com.xebio.bo.Tk020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Standard.Base;
using Common.Standard.Message;
using System;

namespace com.xebio.bo.Tk020p01.Facade
{
  /// <summary>
  /// Tk020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk020f01Facade : StandardBaseFacade
	{
		#region M1明細の行を増やします。(ボタンID : Btnrowins)
		/// <summary>
		/// M1明細の行を増やします。
		/// ボタンID(Btnrowins)
		/// アクションID(MADD)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNROWINS_MADD(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");

			//M1明細リストを取得
			Tk020f01Form tk020f01Form = (Tk020f01Form)facadeContext.FormVO;
			IDataList m1List = tk020f01Form.GetList("M1");

			int index = m1List.Count; // 行追加時のインデックス

			// 最大件数チェック
			//V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), m1List.Count + 1, facadeContext);

			#region 最大件数チェック
			// コンフィグファイルより最大件数を取得
			Decimal dCnt = GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper());

			// 最大件数を超えている場合、エラーとする。
			if (m1List.Count + 1 > dCnt)
			{
				// 最大行数です。これ以上は追加できません。
				ErrMsgCls.AddErrMsg("E147", dCnt.ToString(), facadeContext);
			}
			#endregion

			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}

			AddRowCls.AddEmptyRow<Tk020f01M1Form>("M1", "M1rowno", (Tk020f01Form)facadeContext.FormVO, 1);

			// 管理NOを空白でDictionaryに追加
			Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List[index];
			f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_KANRI_NO, string.Empty);	// 管理NO
			f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_GYO_NBR, index + 1);		// 行NO

			f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_BUMON_NM, string.Empty);	// 部門名
			f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HINSYU_NM, string.Empty);	// 品種名称

			tk020f01Form.Searchcnt = (m1List.Count).ToString(); 
			////行オブジェクトを生成し、リストに追加する。
			//Tk020f01M1Form tk020f01M1Form = new Tk020f01M1Form();
			//tk020f01M1Form.Commode = DbuModeCode.INSERT;
	
			//m1List.Add(tk020f01M1Form, true);
			//m1List.SetBtmPage();

			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNROWINS_MADD");

		}
		#endregion
	}
}
