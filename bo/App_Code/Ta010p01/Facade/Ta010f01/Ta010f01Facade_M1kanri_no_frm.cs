using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta010p01.Formvo;
using com.xebio.bo.Ta010p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Ta010p01.Facade
{
  /// <summary>
  /// Ta010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta010f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1kanri_no)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1kanri_no)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1KANRI_NO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1KANRI_NO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Ta010f01Form prevVo = (Ta010f01Form)facadeContext.FormVO;
				Ta010f02Form nextVo = (Ta010f02Form)facadeContext.GetUserObject(Ta010p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");
				// 選択行の情報を取得する。
				Ta010f01M1Form prevM1Vo = (Ta010f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();
				#endregion
				#region 業務チェック
				#endregion
				#region 検索処理
				FindSqlResultTable rtSearch = null;
				String strSqlId = "";
				// 未申請の場合
				if (ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1.Equals(prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1SHINSEI_FLG]))
				{
					strSqlId = Ta010p01Constant.SQL_ID_03;
				// 申請済みの場合
				}
				else if (ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2.Equals(prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1SHINSEI_FLG]))
				{
					strSqlId = Ta010p01Constant.SQL_ID_04;
				}
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(strSqlId, facadeContext.DBContext);

				// -------------------------------------------
				// バインド変数の置き換え
				// -------------------------------------------
				// 店舗コード
				rtSearch.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD].ToString()));
				// 管理番号
				rtSearch.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO], "0")));
				// 処理日付
				rtSearch.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD], "0")));
				// 区分コード
				rtSearch.BindValue("BIND_KBN_CD1", Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));
				// 区分コード（未申請の場合）
				if (ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1.Equals(prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1SHINSEI_FLG]))
				{
					rtSearch.BindValue("BIND_KBN_CD2", Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));
					rtSearch.BindValue("BIND_KBN_CD3", Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));
				}

				// -------------------------------------------
				//検索結果取得
				// -------------------------------------------
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableList = rtSearch.Execute();
				// 件数チェック
				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}

				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// -------------------------------------------
				//転記処理（管理Noクリック）
				// -------------------------------------------
				decimal[] dRetList = DoDetailCopy(prevM1Vo, nextM1List, tableList);
				#endregion
				#region 後処理
				// 合計欄の設定
				nextVo.Gokei_irai_su = dRetList[0].ToString();			// 合計依頼数量
				nextVo.Gokei_genkakin = dRetList[1].ToString();			// 合計原価金額
				#region カード部設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"];
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_NM"];
				// 選択モードNO
				// 申請モードで申請状態が申請済みの場合（申請後の再クリック）
				if (BoSystemConstant.MODE_APPLY.Equals(prevVo.Modeno)
				 && ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2.Equals(prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1SHINSEI_FLG]))
				{
					nextVo.Stkmodeno = BoSystemConstant.MODE_REF;
				}
				else
				{
					nextVo.Stkmodeno = prevVo.Stkmodeno;
				}
				// 区分コード
				nextVo.Kbn_cd = (string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1KBN_CD];
				// 発注日
				nextVo.Hattyu_ymd = prevM1Vo.M1hattyu_ymd;
				// 担当者コード
				nextVo.Tantosya_cd = (string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1TANTOSYA_CD];
				// 担当者名
				nextVo.Hanbaiin_nm = prevM1Vo.M1hanbaiin_nm;
				// 依頼理由コード
				//nextVo.Irairiyu_cd = (string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1IRAIRIYU_CD];
				Ta010p01Util.SetIrairiyu_cd<Ta010f02Form>(nextVo, (string)prevM1Vo.Dictionary[Ta010p01Constant.DIC_M1IRAIRIYU_CD]);

				// 単品登録モードフラグ
				nextVo.Dictionary[Ta010p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG] = Ta010p01Constant.FLG_OFF.ToString();
				// 選択明細のVO
				nextVo.Dictionary[Ta010p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Ta010p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
				#endregion
				#endregion
			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoM1KANRI_NO_FRM");
		}
		#endregion
	}
}
