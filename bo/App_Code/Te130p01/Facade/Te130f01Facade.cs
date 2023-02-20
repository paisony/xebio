using com.xebio.bo.Te130p01.Constant;
using com.xebio.bo.Te130p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.V01000.V01006;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using System;
using System.Collections;

namespace com.xebio.bo.Te130p01.Facade
{
  /// <summary>
  /// Te130f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Te130f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Te130p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Te130f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te130f01Facade()
			: base()
		{
		}
		#endregion

		#region Te130f01画面データを作成する。
		/// <summary>
		/// Te130f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				//カード部を取得します。
				Te130f01Form te130f01Form = (Te130f01Form)facadeContext.FormVO;
			
				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				LoginInfoVO loginInfVo = LoginInfoUtil.GetLoginInfo();
				// 入荷店コード
					te130f01Form.Jyuryoten_cd = loginInfVo.TnpCd;
				// 入荷店名
				te130f01Form.Juryoten_nm = loginInfVo.Tnprksmes;
				// 会社コード
				te130f01Form.Jyuryokaisya_cd = loginInfVo.CopCd;
				// 会社名
				te130f01Form.Nyukakaisya_nm = string.Empty;
				if (!string.IsNullOrEmpty(te130f01Form.Jyuryokaisya_cd))
				{
					string kaisya_cd = Convert.ToInt16(te130f01Form.Jyuryokaisya_cd).ToString();
					Hashtable resultHash = new Hashtable();
					resultHash = V01006Check.CheckKaisya(kaisya_cd, facadeContext);

					// 名称をラベルに設定
					if (resultHash != null)
					{
						te130f01Form.Nyukakaisya_nm = (string)resultHash["MEISYO_NM"];
					}
				}
				// 伝票状態の初期設定
				te130f01Form.Denpyo_jyotai = ConditionKigyokan_denpyo_jotai.VALUE_DENPYO_JOTAI1;

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

		#region 検索単項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te010f01Form">f01VO</param>
		/// <param name="String">mode</param>
		/// <returns>Decimal</returns>

		private void ChkRowCount ( IFacadeContext facadeContext, IDataList m1List, LoginInfoVO loginInfo, string mode )
		{
			bool blError = false;
			if (m1List == null || m1List.Count <= 0)
			{
				blError = true;
			}
			else
			{
				int inputflg = 0;
				int inputPrtflg = 0;
				foreach (Te130f01M1Form f01m1VO in m1List.ListData)
				{
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						inputflg = 1;
						// 印刷時は、以下のチェックを行う
						if (Te130p01Constant.CHECK_MODE_BTNPRINT.Equals(mode))
						{
							// Dictionary.[Ｍ１参照テーブル]が"2"(移動出荷履歴TBL)の行 または
							// ログイン情報．権限が、"2"（店舗）で、Dictionary.[Ｍ１送信済フラグ]が"1"(送信済)の行
							if (Te130p01Constant.REF_TBL_RIREKI.Equals(f01m1VO.Dictionary[Te130p01Constant.DIC_REF_TBL].ToString()))
						//	|| (loginInfo.Kengenkbn == BoSystemConstant.TANTO_KENGEN_TENCHO && BoSystemConstant.SOSINZUMI_FLG_SOSINZUMI.Equals(f01m1VO.Dictionary[Te130p01Constant.DIC_M1SOSINZUMI_FLG].ToString())))
							{
								// 次の行
								continue;
							}
							else
							{
								inputPrtflg = 1;
								break;
							}
						}
						else
						{
							break;
						}
					}
				}
				if (inputflg == 0)
				{
					blError = true;
				}
				// 印刷モード印刷対象行がない場合
				if (Te130p01Constant.CHECK_MODE_BTNPRINT.Equals(mode) && inputflg == 1 && inputPrtflg == 0)
				{
					// 抽出件数は0件です。
					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
				}
			}
			if (blError)
			{

				if (Te130p01Constant.CHECK_MODE_BTNPRINT.Equals(mode))
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);

				}
				else
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
			}
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
