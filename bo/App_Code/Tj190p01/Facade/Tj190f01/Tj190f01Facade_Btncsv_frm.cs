using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btncsv)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNCSV_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

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
				Tj190f01Form f01VO = (Tj190f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 行数チェック

				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						ErrMsgCls.AddErrMsg("E119", "CSV出力する行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_10, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(m1List,rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
				}
				else
				{
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region CSV出力設定

				// CSV出力用リスト
				IList<IList<string>> csvList = new List<IList<string>>();

				// ヘッダーを定義する
				IList<string> csvListHeader = new List<string>();
				csvListHeader.Add("店舗コード");
				csvListHeader.Add("店舗名");
				csvListHeader.Add("部門コード");
				csvListHeader.Add("部門名");
				csvListHeader.Add("品種コード");
				csvListHeader.Add("品種名");
				csvListHeader.Add("ブランドコード");
				csvListHeader.Add("ブランド名");
				csvListHeader.Add("自社品番");
				csvListHeader.Add("メーカー品番");
				csvListHeader.Add("商品名");
				csvListHeader.Add("色");
				csvListHeader.Add("サイズ");
				csvListHeader.Add("スキャンコード");
				csvListHeader.Add("評価単価");
				csvListHeader.Add("棚時帳簿数");
				csvListHeader.Add("棚時積送数");
				csvListHeader.Add("実棚数");
				csvListHeader.Add("ロス数");
				csvListHeader.Add("ロス金額");
				csvListHeader.Add("ロス計算日");
				csvListHeader.Add("ロス管理No");

				csvList.Add(csvListHeader);

				foreach (Hashtable rec in tableList)
				{
					IList<string> csvListData = new List<string>();
					csvListData.Add(BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));		// 店舗コード
					csvListData.Add(rec["TENPO_NM"].ToString());									// 店舗名
					csvListData.Add(BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString()));		// 部門コード
					csvListData.Add(rec["BUMONKANA_NM"].ToString());								// 部門名
					csvListData.Add(rec["HINSYU_CD"].ToString());									// 品種コード
					csvListData.Add(rec["HINSYU_RYAKU_NM"].ToString());								// 品種名
					csvListData.Add(BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString()));	// ブランドコード
					csvListData.Add(rec["BURANDO_NMK"].ToString());									// ブランド名
					csvListData.Add(rec["JISYA_HBN"].ToString());									// 自社品番
					csvListData.Add(rec["MAKER_HBN"].ToString());									// メーカー品番
					csvListData.Add(rec["SYONMK"].ToString());										// 商品名
					csvListData.Add(rec["IRO_NM"].ToString());										// 色名
					csvListData.Add(rec["SIZE_NM"].ToString());										// サイズ名
					csvListData.Add(rec["JAN_CD"].ToString());										// スキャンコード
					csvListData.Add(rec["HYOKA_TNK"].ToString());									// 評価単価
					csvListData.Add(rec["TANAJITYOBO_SU"].ToString());								// 棚時帳簿数
					csvListData.Add(rec["TANAJISEKISO_SU"].ToString());								// 棚時積送数
					csvListData.Add(rec["JITANA_SU"].ToString());									// 数量
					csvListData.Add(rec["LOSS_SU"].ToString());										// ロス数
					csvListData.Add(rec["LOSS_KIN"].ToString());									// ロス金額
					csvListData.Add(rec["LOSSKEISAN_YMD"].ToString());								// ロス計算日
					csvListData.Add(rec["LOSS_KANRI_NO"].ToString());								// ロス管理No
					csvList.Add(csvListData);
				}

				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, PGID, BoSystemConstant.CSVID_RINTANA);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj190p01Constant.FCDUO_CSV_FLNM, tmpFileName);

				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

		}
		#endregion

		#region 条件設定
		/// <summary>
		/// AddWhere 条件設定
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void AddWhere(IDataList m1List, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();
			StringBuilder sBindId = new StringBuilder();

			String First_flg = "S";

			// 条件設定
			for (int i = 0; i < m1List.Count; i++)
			{

				Tj190f01M1Form f01m1VO = (Tj190f01M1Form)m1List[i];

				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					//1件目はカンマをつけない。
					if (First_flg == "S")
					{
						sRepSql.Append(" AND (A.TENPO_CD, A.LOSS_KANRI_NO, A.SYORI_YMD) IN (");
						//初回フラグを終了させる
						First_flg = "E";
					}
					else
					{
						sRepSql.Append(",");
					}
					sRepSql.Append(("("));
					// 店舗コード
					sBindId = new StringBuilder();
					sBindId.Append("BIND_TENPO_CD").Append(i.ToString("0000"));
					sRepSql.Append(" :").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 管理No
					sBindId = new StringBuilder();
					sBindId.Append("BIND_KANRI_NO").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = (string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1LOSS_KANRI_NO];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 処理日付
					sBindId = new StringBuilder();
					sBindId.Append("BIND_SYORI_YMD").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = (string)f01m1VO.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
					sRepSql.Append((")"));
				}
			}
			sRepSql.Append((")"));

			BoSystemSql.AddSql(reader, Tj190p01Constant.SQL_ID_10_REP_ID_WHERE, sRepSql.ToString(), bindList);

		}
		#endregion

	}
}
