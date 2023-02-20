using com.xebio.bo.Te080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01007;
using Common.Business.V01000.V01006;
using Common.Standard.Base;
using Common.Standard.Login;
using System;
using System.Collections;

namespace com.xebio.bo.Te080p01.Facade
{
  /// <summary>
  /// Te080f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Te080f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Te080p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Te080f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te080f01Facade()
			: base()
		{
		}
		#endregion

		#region Te080f01画面データを作成する。
		/// <summary>
		/// Te080f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				//カード部を取得します。
				Te080f01Form te080f01Form = (Te080f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// 合計数初期化
				te080f01Form.Scm_gokei = "0";
				te080f01Form.Denpyo_gokei = "0";

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
				//コネクションを開放する。
				CloseConnection(facadeContext);
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

			AddRowCls.AddEmptyRow<Te080f01M1Form>("M1", "M1rowno", (Te080f01Form)facadeContext.FormVO, Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));

			// 1行目の「会社」に自社を表示する
			Te080f01Form f01VO = (Te080f01Form)facadeContext.FormVO;
			IDataList m1List = f01VO.GetList("M1");
			Te080f01M1Form f01m1VO = (Te080f01M1Form)m1List[0];
			LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();

			// 会社コード
			f01m1VO.M1kaisya_cd = loginInfVo.CopCd;
			// 会社名
			f01m1VO.M1kaisya_nm = string.Empty;
			if (!string.IsNullOrEmpty(f01m1VO.M1kaisya_cd))
			{
				string kaisya_cd = Convert.ToInt16(f01m1VO.M1kaisya_cd).ToString();
				Hashtable resultHash = new Hashtable();
				resultHash = V01006Check.CheckKaisya(kaisya_cd, facadeContext);

				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01m1VO.M1kaisya_nm = (string)resultHash["MEISYO_NM"];
				}
			}

		}
		#endregion


		#region 合計行を計算する。
		/// <summary>
		/// 合計行を計算する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void SetGokeiGyo(IFacadeContext facadeContext)
		{

			// FormVO取得
			// 画面より情報を取得する。
			Te080f01Form f01VO = (Te080f01Form)facadeContext.FormVO;
			IDataList m1List = f01VO.GetList("M1");

			// 合計行の加算
			decimal scmCnt = 0;
			decimal denCnt = 0;
			for (int i = 0; i < m1List.Count; i++)
			{
				Te080f01M1Form m1VO = (Te080f01M1Form)m1List[i];

				if (!string.IsNullOrEmpty(m1VO.M1scmden_cd))
				{
					bool scmSameFlg = false;
					bool denSameFlg = false;

					// 自分より下の行をチェックする
					for (int j = i + 1; j < m1List.Count; j++)
					{
						Te080f01M1Form m1VO2 = (Te080f01M1Form)m1List[j];

						// 同じ行が存在したら加算対象にしない。
						if (m1VO.M1scm_cd.Equals(m1VO2.M1scm_cd))
						{
							scmSameFlg = true;
						}
						if (m1VO.M1denpyo_bango.Equals(m1VO2.M1denpyo_bango))
						{
							denSameFlg = true;
						}
						if (scmSameFlg && denSameFlg)
						{
							break;
						}
					}

					// 同じ行が存在しなければ加算する。
					if (!scmSameFlg)
					{
						scmCnt++;
					}
					if (!denSameFlg)
					{
						denCnt++;
					}
				}
			}
			f01VO.Scm_gokei = scmCnt.ToString();
			f01VO.Denpyo_gokei = denCnt.ToString();

		}
		#endregion

	}
}
