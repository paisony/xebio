using com.xebio.bo.Tm040p01.Constant;
using com.xebio.bo.Tm040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01023;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tm040p01.Facade
{
  /// <summary>
  /// Tm040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm040f02Facade : StandardBaseFacade
	{

		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tm040f02Form f02VO = (Tm040f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 入力のある明細リスト
				List<Tm040f02M1Form> inputM1List = new List<Tm040f02M1Form>();

				// 呼出元画面ID
				string parentFormId = ((string)f02VO.Dictionary[Tm040p01Constant.DIC_FORM_ID]).ToUpper();
				#endregion

				#region 業務チェック

				#region 行数チェック
				// 1-1 [Ｍ１数量]が入力されている明細が0行の場合、エラー
				for (int i = 0; i < m1List.Count; i++)
				{
					Tm040f02M1Form m1Row = (Tm040f02M1Form)m1List[i];

					if (!string.IsNullOrEmpty(m1Row.M1itemsu))
					{
						// 入力されている場合
						// インデックス設定
						m1Row.Dictionary[Tm040p01Constant.DIC_INDEX] = i.ToString();
						// リストに追加
						inputM1List.Add(m1Row);
					}
				}

				if (inputM1List.Count == 0)
				{
					// 登録データがありません。
					ErrMsgCls.AddErrMsg("E133", String.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 件数チェック
				// 2-1 パラメータ.画面表示最大件数＜パラメータ.現在行数＋[Ｍ１数量]が入力している行数の場合、エラー
				int maxCnt = Convert.ToInt32(f02VO.Dictionary[Tm040p01Constant.DIC_MAX_ROW_CNT]);	// 最大件数
				int curCnt = Convert.ToInt32(f02VO.Dictionary[Tm040p01Constant.DIC_CUR_ROW_CNT]);	// 現在件数

				if (maxCnt < curCnt + inputM1List.Count)
				{
					// 明細は%1行以上登録できません。
					ErrMsgCls.AddErrMsg("E213", maxCnt.ToString(), facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 入力値チェック
				foreach (Tm040f02M1Form m1Row in inputM1List)
				{
					// 3-1 [Ｍ１数量]が有効桁数を超えた場合、エラー
					decimal maxSuryo = decimal.Zero;
					// 各画面の数量最大値を取得
					switch (parentFormId)
					{
						case Tm040p01Constant.FORMID_TA010F02:	// 補充依頼入力-明細
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TA010F02_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TA080F03:	// 補充・仕入稟議検索-明細
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TA080F03_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TA020F02:	// 出荷要望入力-明細
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TA020F02_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TA070F01:	// 自動定数変更
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TA070F01_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TB050F01:	// マニュアル仕入
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TB050F01_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TD020F01:	// 返品入力（ﾏﾆｭｱﾙ）
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TD020F01_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TE020F01:	// 移動出荷入力（ﾏﾆｭｱﾙ）
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TE020F01_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TE040F01:	// 移動出荷入力（再入荷防止）
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TE040F01_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TG010F01:	// プライスシール発行
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TG010F01_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TG040F02:	// 商品ｽﾄｯｸ明細書発行-明細
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TG040F02_MAX_SURYO);
							break;
						case Tm040p01Constant.FORMID_TJ190F02:	// 臨時棚卸検索-明細
							maxSuryo = Convert.ToDecimal(Tm040p01Constant.TJ190F02_MAX_SURYO);
							break;
						default:
							break;
					}
					if (maxSuryo > decimal.Zero)
					{
						// 有効桁数が設定されている場合
						decimal m1Itemsu = Convert.ToDecimal(m1Row.M1itemsu);

						if (m1Itemsu > maxSuryo)
						{
							// %1が有効桁数を超えています。
							ErrMsgCls.AddErrMsg("E102", "数量", facadeContext, new[] { "M1itemsu" },
								m1Row.M1rowno, (string)m1Row.Dictionary[Tm040p01Constant.DIC_INDEX], "M1", Tm040p01Constant.TM040F02M1_DISP_CNT);
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 発注マスタ情報リストを生成
				// 発注マスタ情報リスト
				IList<Hashtable> hachuMstInfo = new List<Hashtable>();

				foreach (Tm040f02M1Form m1Row in inputM1List)
				{
					// 発注マスタ情報
					Hashtable hachuMstRow = (Hashtable)m1Row.Dictionary[Tm040p01Constant.DIC_M1HACHU_MST_INFO];

					// 数量項目追加
					hachuMstRow[OpenTm040p01Cls.COLUMN_INPUT_SURYO] = m1Row.M1itemsu;

					// リストに追加
					hachuMstInfo.Add(hachuMstRow);
				}

				// ファサードコンテキストに設定
				facadeContext.SetUserObject(Tm040p01Constant.FCDUO_HACHU_MST_INFO, hachuMstInfo);
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion
	}
}
