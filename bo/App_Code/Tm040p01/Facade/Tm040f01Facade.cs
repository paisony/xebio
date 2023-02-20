using com.xebio.bo.Tm040p01.Constant;
using com.xebio.bo.Tm040p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using System.Collections;

namespace com.xebio.bo.Tm040p01.Facade
{
  /// <summary>
  /// Tm040f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tm040f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tm040p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tm040f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm040f01Facade()
			: base()
		{
		}
		#endregion

		#region Tm040f01画面データを作成する。
		/// <summary>
		/// Tm040f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				////DBコンテキストを設定する。
				//SetDBContext(facadeContext);
				////コネクションを開きます。
				//OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				//カード部を取得します。
				Tm040f01Form tm040f01Form = (Tm040f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 画面編集処理
				// コードビハインドで設定したプログラムVOのディクショナリを取得
				IDictionary pgFormDic = (IDictionary)facadeContext.GetUserObject(Tm040p01Constant.FCDUO_PGFORM_DICTIONARY);

				tm040f01Form.Dictionary[Tm040p01Constant.DIC_FORM_ID] = pgFormDic[Tm040p01Constant.DIC_FORM_ID];			// 呼出元画面ID
				tm040f01Form.Dictionary[Tm040p01Constant.DIC_CUR_ROW_CNT] = pgFormDic[Tm040p01Constant.DIC_CUR_ROW_CNT];	// 現在行数
				tm040f01Form.Dictionary[Tm040p01Constant.DIC_MAX_ROW_CNT] = pgFormDic[Tm040p01Constant.DIC_MAX_ROW_CNT];	// 最大行数
				tm040f01Form.Tenpo_cd = (string)pgFormDic[Tm040p01Constant.DIC_TENPO_CD];									// 店舗コード

				tm040f01Form.Siji_bango = (string)pgFormDic[Tm040p01Constant.DIC_SIJI_BANGO];								// 指示番号
				tm040f01Form.Syukkakaisya_cd = (string)pgFormDic[Tm040p01Constant.DIC_SYUKKA_KAISYA_CD];					// 出荷会社コード
				tm040f01Form.Jyuryokaisya_cd = (string)pgFormDic[Tm040p01Constant.DIC_JURYO_KAISYA_CD];						// 入荷会社コード
				tm040f01Form.Syukkaten_cd = (string)pgFormDic[Tm040p01Constant.DIC_SYUKKA_TEN_CD];							// 出荷店コード

				// 呼出元画面IDにより、各検索フラグを設定
				switch ((string)pgFormDic[Tm040p01Constant.DIC_FORM_ID])
				{
					#region 補充依頼入力-明細
					case Tm040p01Constant.FORMID_TA010F02:

						tm040f01Form.Pluflg = "0";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "0";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "1";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "1";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "1";			// 売上実績数検索フラグ
						if (pgFormDic[Tm040p01Constant.DIC_HOJUIRAI_KBN].Equals(ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN1))
						{
							tm040f01Form.Hojuflg = "1";		// 依頼集計数(補充)検索フラグ
						}
						else
						{
							tm040f01Form.Hojuflg = "0";		// 依頼集計数(補充)検索フラグ
						}
						if (pgFormDic[Tm040p01Constant.DIC_HOJUIRAI_KBN].Equals(ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN2))
						{
							tm040f01Form.Tanpinflg = "1";	// 依頼集計数(単品)検索フラグ
						}
						else
						{
							tm040f01Form.Tanpinflg = "0";	// 依頼集計数(単品)検索フラグ
						}
						tm040f01Form.Sijiflg = "0";			// 指示検索フラグ

						break;
					#endregion

					#region 補充・仕入稟議検索-明細
					case Tm040p01Constant.FORMID_TA080F03:

						tm040f01Form.Pluflg = "0";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "0";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "1";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "1";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "1";			// 売上実績数検索フラグ
						tm040f01Form.Hojuflg = "1";			// 依頼集計数(補充)検索フラグ
						tm040f01Form.Tanpinflg = "0";		// 依頼集計数(単品)検索フラグ
						tm040f01Form.Sijiflg = "0";			// 指示検索フラグ

						break;
					#endregion

					#region 出荷要望入力-明細
					case Tm040p01Constant.FORMID_TA020F02:

						tm040f01Form.Pluflg = "0";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "0";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "1";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "1";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "1";			// 売上実績数検索フラグ
						tm040f01Form.Hojuflg = "0";			// 依頼集計数(補充)検索フラグ
						tm040f01Form.Tanpinflg = "0";		// 依頼集計数(単品)検索フラグ
						tm040f01Form.Sijiflg = "0";			// 指示検索フラグ

						break;
					#endregion

					#region 自動定数変更
					case Tm040p01Constant.FORMID_TA070F01:

						tm040f01Form.Pluflg = "0";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "0";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "0";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "0";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "1";			// 売上実績数検索フラグ
						tm040f01Form.Hojuflg = "0";			// 依頼集計数(補充)検索フラグ
						tm040f01Form.Tanpinflg = "0";		// 依頼集計数(単品)検索フラグ
						tm040f01Form.Sijiflg = "0";			// 指示検索フラグ

						break;
					#endregion

					#region 返品入力（ﾏﾆｭｱﾙ）
					case Tm040p01Constant.FORMID_TD020F01:

						tm040f01Form.Pluflg = "0";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "0";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "0";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "0";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "0";			// 売上実績数検索フラグ
						tm040f01Form.Hojuflg = "0";			// 依頼集計数(補充)検索フラグ
						tm040f01Form.Tanpinflg = "0";		// 依頼集計数(単品)検索フラグ
						if (!string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(tm040f01Form.Siji_bango)))
						{
							// 指示番号が設定されている場合
							tm040f01Form.Sijiflg = "2";		// 指示検索フラグ
						}
						else
						{
							tm040f01Form.Sijiflg = "0";		// 指示検索フラグ
						}

						break;
					#endregion

					#region 移動出荷入力（ﾏﾆｭｱﾙ）
					case Tm040p01Constant.FORMID_TE020F01:

						tm040f01Form.Pluflg = "0";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "0";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "0";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "0";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "0";			// 売上実績数検索フラグ
						tm040f01Form.Hojuflg = "0";			// 依頼集計数(補充)検索フラグ
						tm040f01Form.Tanpinflg = "0";		// 依頼集計数(単品)検索フラグ
						if (!string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(tm040f01Form.Siji_bango)))
						{
							// 指示番号が設定されている場合
							tm040f01Form.Sijiflg = "1";		// 指示検索フラグ
						}
						else
						{
							tm040f01Form.Sijiflg = "0";		// 指示検索フラグ
						}

						break;
					#endregion

					#region プライスシール発行
					case Tm040p01Constant.FORMID_TG010F01:

						tm040f01Form.Pluflg = "1";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "1";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "0";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "0";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "0";			// 売上実績数検索フラグ
						tm040f01Form.Hojuflg = "0";			// 依頼集計数(補充)検索フラグ
						tm040f01Form.Tanpinflg = "0";		// 依頼集計数(単品)検索フラグ
						tm040f01Form.Sijiflg = "0";			// 指示検索フラグ

						break;
					#endregion

					#region 臨時棚卸検索-明細
					case Tm040p01Constant.FORMID_TJ190F02:

						tm040f01Form.Pluflg = "0";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "0";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "2";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "0";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "0";			// 売上実績数検索フラグ
						tm040f01Form.Hojuflg = "0";			// 依頼集計数(補充)検索フラグ
						tm040f01Form.Tanpinflg = "0";		// 依頼集計数(単品)検索フラグ
						tm040f01Form.Sijiflg = "0";			// 指示検索フラグ

						break;
					#endregion

					#region それ以外
					default:

						tm040f01Form.Pluflg = "0";			// 店別単価マスタ検索フラグ
						tm040f01Form.Priceflg = "0";		// 売変検索フラグ
						tm040f01Form.Zaikoflg = "0";		// 店在庫検索フラグ
						tm040f01Form.Nyukaflg = "0";		// 入荷予定数検索フラグ
						tm040f01Form.Uriflg = "0";			// 売上実績数検索フラグ
						tm040f01Form.Hojuflg = "0";			// 依頼集計数(補充)検索フラグ
						tm040f01Form.Tanpinflg = "0";		// 依頼集計数(単品)検索フラグ
						tm040f01Form.Sijiflg = "0";			// 指示検索フラグ

						break;
					#endregion
				}
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				//M1明細部のデータを作成します。
				DoM1ListLoad(facadeContext);

			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				////コネクションを開放する。
				//CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
		}
		#endregion

		
		#region M1明細部データの作成をする。
		/// <summary>
		/// M1明細部データの作成をする。
		/// 明細ID(M1)の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ListLoad(IFacadeContext facadeContext)
		{
			//このメソッドは、M1の明細のデータを生成するために、
			//画面のLoad処理と改ページ処理で呼ばれます。
			//コネクションの開始・終了は呼び出しもとのメソッドで管理されます。
			//必要な処理を実装してください。
			
		}
		#endregion
	}
}
