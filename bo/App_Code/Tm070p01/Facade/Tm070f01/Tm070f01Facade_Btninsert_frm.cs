using com.xebio.bo.Tm070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.V01000.V01001;
using Common.Standard.Base;
using Common.Standard.Login;
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
		
		#region フォームを呼び出します。(ボタンID : Btninsert)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btninsert)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNINSERT_FRM(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNINSERT_FRM");

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
				Tm070f01Form f01VO = (Tm070f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				////業務日付を取得する
				//SysDateVO sysDateVO = new SysDateVO();
				//sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件を初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				// 選択モードNoを初期化
				f01VO.Stkmodeno = string.Empty;

				#endregion

				#region 業務チェック

				#region マスタ存在チェック
				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 画面編集

				// 検索項目の初期化
				f01VO.Henko_ymd_from = String.Empty;		// 変更日From
				f01VO.Henko_ymd_to = String.Empty;			// 変更日To
				f01VO.Moto_tenpo_cd_from = String.Empty;	// 元店舗コードFrom
				f01VO.Moto_tenpo_nm_from = String.Empty;	// 元店舗名From
				f01VO.Moto_tenpo_cd_to = String.Empty;		// 元店舗コードTo
				f01VO.Moto_tenpo_nm_to = String.Empty;		// 元店舗名To
				f01VO.Tan_cd_from = String.Empty;			// 担当者コードFrom
				f01VO.Tan_nm_from = String.Empty;			// 担当者名From
				f01VO.Tan_cd_to = String.Empty;				// 担当者コードTo
				f01VO.Tan_nm_to = String.Empty;				// 担当者名To

				// ページを追加
				Hashtable defVal = new Hashtable();
				defVal["M1henko_tenpo_cd"] = f01VO.Head_tenpo_cd;
				defVal["M1henko_tenpo_nm"] = f01VO.Head_tenpo_nm;

				AddRowCls.AddEmptyRow<Tm070f01M1Form>("M1", "M1rowno", (Tm070f01Form)facadeContext.FormVO, m1List.DispRow, defVal);
				SetPageIndex(m1List, m1List.DispRow);

				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				#endregion

				// 選択モードNoを「新規作成」に設定
				f01VO.Stkmodeno = BoSystemConstant.MODE_INSERT;

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
				//RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNINSERT_FRM");

		}
		#endregion
	}
}
