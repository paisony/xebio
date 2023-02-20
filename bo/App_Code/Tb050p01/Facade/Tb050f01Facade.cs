using com.xebio.bo.Tb050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01008;
using Common.Business.C99999.StringUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using System;
using System.Collections;

namespace com.xebio.bo.Tb050p01.Facade
{
  /// <summary>
  /// Tb050f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tb050f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tb050p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tb050f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tb050f01Facade()
			: base()
		{
		}
		#endregion

		#region Tb050f01画面データを作成する。
		/// <summary>
		/// Tb050f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
			//	//DBコンテキストを設定する。
			//	SetDBContext(facadeContext);
			//	//コネクションを開きます。
			//	OpenConnection(facadeContext);
				
			//	//以下に業務ロジックを記述する。
				
			//	//カード部を取得します。
			//	Tb050f01Form tb050f01Form = (Tb050f01Form)facadeContext.FormVO;
				
			//	//モデル層処理ロジックを記述してください。
			//	//カード部 データを取得(要実装)........
				
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
			//	//コネクションを開放する。
			//	CloseConnection(facadeContext);
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

      LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();
			Tb050f01Form formVo = (Tb050f01Form)facadeContext.FormVO;
			IDataList m1List = formVo.GetList("M1");
			AddRowCls.AddEmptyRow<Tb050f01M1Form>("M1", "M1rowno", (Tb050f01Form)facadeContext.FormVO, m1List.DispRow);
			IList m1DataList = formVo.GetPageViewList("M1");

            // 権限取得部品の戻り値が"FALSE"の場合
            if (!CheckKengenCls.CheckKengen(loginInfVo))
			{
				// 明細部チェックボックスの制御
				for (int index = 0; index < m1DataList.Count; index++)
				{
					Tb050f01M1Form tb050f01M1Form = (Tb050f01M1Form)m1DataList[index];

					// [Ｍ１店舗コード]にログイン情報の店舗コードを設定
					tb050f01M1Form.M1tenpo_cd = loginInfVo.TnpCd;
					// [Ｍ１店舗名]にログイン情報の所属店舗名を設定
					tb050f01M1Form.M1tenpo_nm = loginInfVo.Tnprksmes;
				}
			}

		}
		#endregion

		#region 共通関数を作成する

		/// <summary>
		/// 不足行数を追加し、有効現在行数を返す。
		/// </summary>
		/// <param name="form">一覧画面のVO</param>
		/// <param name="addCnt">追加行数</param>
		/// <returns>有効現在行数</returns>
		private int addRequireRow(Tb050f01Form form, int addCnt)
		{
			// 有効現在行数
			int curRowCnt = 0;

			// 明細オブジェクト取得
			IDataList m1List = form.GetList("M1");

				
				for (int i = m1List.Count - 1; i >= 0; i--)
			{
				// 行オブジェクト取得
				Tb050f01M1Form m1Form = (Tb050f01M1Form)m1List[i];

				if (   (   CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo())
						&& !string.IsNullOrEmpty(m1Form.M1tenpo_cd))
					|| !string.IsNullOrEmpty(m1Form.M1scan_cd)
					|| !string.IsNullOrEmpty(m1Form.M1kensu)
					)
				{
					// いずれかの入力項目が入力されている場合
					curRowCnt = i + 1;
					break;
				}
			}

			// 不足行数
			int requiredCnt = curRowCnt + addCnt - m1List.Count;

			if (requiredCnt > 0)
			{
				// 追加ページ数
				int addPageCnt = (int)Math.Floor(new decimal((requiredCnt - 1) / m1List.DispRow)) + 1;
				// 追加行数
				int addRowCnt = m1List.DispRow * addPageCnt;

				// 行追加
				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

				Hashtable defVal = null;

				// 権限取得部品の戻り値が"FALSE"の場合
				if (!CheckKengenCls.CheckKengen(loginInfVo))
				{
					// [Ｍ１店舗コード]にログイン情報の店舗コードを設定
					// [Ｍ１店舗名]にログイン情報の所属店舗名を設定
					defVal = new Hashtable();

					defVal.Add("M1tenpo_cd", loginInfVo.TnpCd);
					defVal.Add("M1tenpo_nm", loginInfVo.Tnprksmes);
				}

				AddRowCls.AddEmptyRow<Tb050f01M1Form>("M1", "M1rowno", form, addRowCnt, defVal);
			}

			return curRowCnt;

		}

		/// <summary>
		/// 合計欄を計算し設定する。
		/// </summary>
		/// <param name="form">一覧画面のVO</param>
		private void setGokei(Tb050f01Form form)
		{

			// 明細オブジェクト取得
			IDataList m1List = form.GetList("M1");

			// 合計数計算
			Decimal dGokei_kensu = 0;
			Decimal dGokeigenka_kin = 0;

			// 明細計算
			for (int i = 0; i < m1List.Count; i++)
			{
				Tb050f01M1Form m1Form = (Tb050f01M1Form)m1List[i];

				// Ｍ１検数の合計
				dGokei_kensu += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1kensu, "0").ToString());
				// Ｍ１原価金額の合計
				dGokeigenka_kin += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1genka_kin, "0").ToString());
			}

			form.Gokei_kensu = dGokei_kensu.ToString();									// 合計検数
			form.Genka_kin_gokei = dGokeigenka_kin.ToString();							// 合計原価金額

		}

		#endregion

	}
}
