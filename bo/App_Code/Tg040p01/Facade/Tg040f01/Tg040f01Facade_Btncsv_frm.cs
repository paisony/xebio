using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f01Facade : StandardBaseFacade
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

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化
				// FormVO取得
				Tg040f01Form f01VO = (Tg040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");
				#endregion

				#region 業務チェック
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
						Tg040f01M1Form f01m1VO = (Tg040f01M1Form)m1List[i];
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

				#region 検索処理
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tg040p01Constant.SQL_ID_03, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(f01VO, m1List, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				// 1-2 対象件数
				// 対象件数が0件の場合エラー
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

				#region CSV出力処理
				// CSV出力用リスト
				IList<IList<string>> csvList = new List<IList<string>>();

				// ヘッダ項目の設定
				csvList.Add(this.getCsvHeader());

				foreach (Hashtable rec in tableList)
				{
					IList<string> csvListDate = new List<string>();

					csvListDate.Add(BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));		//店舗コード
					csvListDate.Add(rec["TENPO_NM"].ToString());			//店舗名
					csvListDate.Add(rec["STOCK_NO"].ToString());			//ストック№
					csvListDate.Add(rec["SYORI_YMD"].ToString());			//入力日
					csvListDate.Add(rec["UPD_TM"].ToString());				//入力時間
					csvListDate.Add(rec["UPD_TANCD"].ToString());			//入力担当者コード
					csvListDate.Add(rec["HANBAIIN_NM"].ToString());			//入力担当者名
					csvListDate.Add(rec["GOKEIYOTEI_SU"].ToString());		//合計数量
					csvListDate.Add(rec["GYO_NO"].ToString());				//行№
					csvListDate.Add(BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString()));		//部門コード
					csvListDate.Add(rec["BUMONKANA_NM"].ToString());		//部門名
					csvListDate.Add(rec["HINSYU_CD"].ToString());			//品種コード
					csvListDate.Add(rec["HINSYU_RYAKU_NM"].ToString());		//品種名
					csvListDate.Add(BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString()));	//ブランドコード
					csvListDate.Add(rec["BURANDO_NMK"].ToString());			//ブランド名
					csvListDate.Add(rec["JISYA_HBN"].ToString());			//自社品番
					csvListDate.Add(rec["MAKER_HBN"].ToString());			//メーカー品番
					csvListDate.Add(rec["SYONMK"].ToString());				//商品名
					csvListDate.Add(rec["HANBAIKANRYO_YMD"].ToString());	//販売完了日
					csvListDate.Add(rec["IRO_NM"].ToString());				//色
					csvListDate.Add(rec["SIZE_NM"].ToString());				//サイズ
					csvListDate.Add(rec["JAN_CD"].ToString());				//スキャンコード
					csvListDate.Add(rec["YOTEI_SU"].ToString());			//数量


					//リストオブジェクトにM1Formを追加します。
					csvList.Add(csvListDate);
				}
				#endregion

				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, Tg040p01Constant.PGID, BoSystemConstant.CSVID_STOCK);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg040p01Constant.FCDUO_CSV_FLNM, tmpFileName);

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
		/// <param name="Tg040f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void AddWhere(Tg040f01Form f01VO, IDataList m1List, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 初回フラグ
			String First_flg = "S";

			// バインドIDを作成
			StringBuilder sBindId = new StringBuilder();

			// 条件設定
			for (int iRow = 0; iRow < m1List.Count; iRow++)
			{
				// 明細行の情報を取得する。
				Tg040f01M1Form f01M1VO = (Tg040f01M1Form)m1List[iRow];

				// 選択フラグ
				if (f01M1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					//1件目はカンマをつけない。
					if (First_flg.Equals("S"))
					{
						sRepSql.Append(" ( ");

						//初回フラグを終了させる
						First_flg = "E";
					}
					else
					{
						sRepSql.Append(" ,( ");
					}

					// [ヘッダ店舗コード]
					sBindId = new StringBuilder();
					sBindId.Append("BIND_TENPO_CD").Append(iRow.ToString("0000"));
					sRepSql.Append(" :").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();	
					bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 対象行.Dictionary.[Ｍ１管理№]
					sBindId = new StringBuilder();
					sBindId.Append("BIND_KANRI_NO").Append(iRow.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();	
					bindVO.Value = (string)f01M1VO.Dictionary[Tg040p01Constant.DIC_KANRI_NO];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 対象行.Dictionary.[Ｍ１処理日付]
					sBindId = new StringBuilder();
					sBindId.Append("BIND_SYORI_YMD").Append(iRow.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = (string)f01M1VO.Dictionary[Tg040p01Constant.DIC_SYORI_YMD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					sRepSql.Append(" ) ");
				}
			}
			BoSystemSql.AddSql(reader, Tg040p01Constant.SQL_ID_03_REP_ADD_WHERE, sRepSql.ToString(), bindList);
		}
		#endregion

		#region CSVヘッダ項目設定
		/// <summary>
		/// getCsvHeader CSVヘッダ項目設定
		/// </summary>
		/// <returns>IList</returns>
		private IList<string> getCsvHeader()
		{

			IList<string> csvListData = new List<string>();

			csvListData.Add("店舗コード");
			csvListData.Add("店舗名");
			csvListData.Add("ストックNo");
			csvListData.Add("入力日");
			csvListData.Add("入力時間");
			csvListData.Add("入力担当者コード");
			csvListData.Add("入力担当者名");
			csvListData.Add("合計数量");
			csvListData.Add("行No");
			csvListData.Add("部門コード");
			csvListData.Add("部門名");
			csvListData.Add("品種コード");
			csvListData.Add("品種名");
			csvListData.Add("ブランドコード");
			csvListData.Add("ブランド名");
			csvListData.Add("自社品番");
			csvListData.Add("メーカー品番");
			csvListData.Add("商品名");
			csvListData.Add("販売完了日");
			csvListData.Add("色");
			csvListData.Add("サイズ");
			csvListData.Add("スキャンコード");
			csvListData.Add("数量");

			return csvListData;
		}
		#endregion
	}
}
