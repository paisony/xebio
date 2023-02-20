using com.xebio.bo.Tj030p01.Constant;
using com.xebio.bo.Tj030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tj030p01.Facade
{
  /// <summary>
  /// Tj030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj030f01Facade : StandardBaseFacade
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
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// ログインユーザIDを取得
				string loginId = Convert.ToString(logininfo.LoginId);

				// FormVO取得
				// 画面より情報を取得する。
				Tj030f01Form f01VO = (Tj030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 店舗コード Dictionaryより取得
				String tenpocd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_CD]);

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
						Tj030f01M1Form f01m1VO = (Tj030f01M1Form)m1List[i];
						if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 確定対象がありません。
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

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj030p01Constant.SQL_ID_03, facadeContext.DBContext);

				// 検索条件設定
				// 店舗用WHERE句設定
				AddWhere(f01VO, rtSeach, m1List, ConditionTenpo_gyosya_kbn.VALUE_TENPO);
				// 業者用用WHERE句設定
				AddWhere(f01VO, rtSeach, m1List, ConditionTenpo_gyosya_kbn.VALUE_GYOSYA);

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
				csvListHeader.Add("フェイス№");
				csvListHeader.Add("棚段");
				csvListHeader.Add("回数");
				csvListHeader.Add("送信回数");
				csvListHeader.Add("入力日");
				csvListHeader.Add("送信日");
				csvListHeader.Add("入力担当者コード");
				csvListHeader.Add("入力担当者名");
				csvListHeader.Add("部門コード");
				csvListHeader.Add("部門名");
				csvListHeader.Add("品種コード");
				csvListHeader.Add("品種名");
				csvListHeader.Add("ブランドコード");
				csvListHeader.Add("ブランド名");
				csvListHeader.Add("自社品番");
				csvListHeader.Add("メーカー品番");
				csvListHeader.Add("商品名");
				csvListHeader.Add("色名");
				csvListHeader.Add("サイズ名");
				csvListHeader.Add("スキャンコード");
				csvListHeader.Add("スキャン数");
				csvListHeader.Add("店舗／業者");

				csvList.Add(csvListHeader);

				foreach (Hashtable rec in tableList)
				{
					IList<string> csvListData = new List<string>();
					csvListData.Add(BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));			// 店舗コード
					csvListData.Add(rec["TENPO_NM"].ToString());										// 店舗名
					csvListData.Add(rec["FACE_NO"].ToString());											// フェイス№
					csvListData.Add(rec["TANA_DAN"].ToString());										// 棚段
					csvListData.Add(rec["KAI_SU"].ToString());											// 回数
					csvListData.Add(rec["SOSINKAI_SU"].ToString());										// 送信回数
					csvListData.Add(rec["ADD_YMD"].ToString());											// 入力日
					csvListData.Add(rec["SOSIN_YMD"].ToString());										// 送信日
					csvListData.Add(rec["ADDTAN_CD"].ToString());										// 入力担当者コード
					csvListData.Add(rec["HANBAIIN_NM"].ToString());										// 入力担当者名
					csvListData.Add(BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString()));			// 部門コード
					csvListData.Add(rec["BUMONKANA_NM"].ToString());									// 部門名
					csvListData.Add(BoSystemFormat.formatHinsyuCd(rec["HINSYU_CD"].ToString()));		// 品種コード
					csvListData.Add(rec["HINSYU_RYAKU_NM"].ToString());									// 品種名
					csvListData.Add(BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString()));		// ブランドコード
					csvListData.Add(rec["BURANDO_NMK"].ToString());										// ブランド名
					csvListData.Add(BoSystemFormat.formatJisyaHbn(rec["JISYA_HBN"].ToString()));		// 自社品番
					csvListData.Add(rec["MAKER_HBN"].ToString());										// メーカー品番
					csvListData.Add(rec["SYONMK"].ToString());											// 商品名
					csvListData.Add(rec["IRO_NM"].ToString());											// 色名
					csvListData.Add(rec["SIZE_NM"].ToString());											// サイズ名
					csvListData.Add(rec["JAN_CD"].ToString());											// スキャンコード
					csvListData.Add(rec["TANAOROSIGOKEI_SU"].ToString());								// スキャン数
					csvListData.Add(rec["TANASB"].ToString());											// 店舗／業者
					csvList.Add(csvListData);
				}
				
				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, PGID, BoSystemConstant.CSVID_TANA_V);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj030p01Constant.FCDUO_CSV_FLNM, tmpFileName);

				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Tj030f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="IDataList">f01m1VO</param>
		/// <param name="String">tenpoGyosyaKb(1:店舗、2:業者)</param>
		/// <returns></returns>
		private void AddWhere(Tj030f01Form f01VO, FindSqlResultTable reader, IDataList m1List, String tenpoGyosyaKb)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			String sREP_ID = String.Empty;
			String sTableId = String.Empty;

			// バインドIDを作成
			StringBuilder sBindId = new StringBuilder();

			ArrayList aF01m1VO = new ArrayList();

			// 店舗コード Dictionaryより取得
			String tenpocd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_CD]);

			#region 店舗抽出、業者抽出

			// 店舗、業者によって設定するWHERE句、テーブルを決定する
			if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
			{
				sREP_ID = Tj030p01Constant.SQL_ID_01_REP_ADD_WHERE_1;
				sTableId = "MDIT0010";	// [棚卸確定TBL(H)]
			}
			else
			{
				sREP_ID = Tj030p01Constant.SQL_ID_01_REP_ADD_WHERE_2;
				sTableId = "MDIT0090";	// [業者棚卸TBL(H)]
			}

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();
			Boolean bConmaF = false;
			for (int i = 0; i < m1List.Count; i++)
			{
				Tj030f01M1Form f01m1VO = (Tj030f01M1Form)m1List[i];

				// 選択されている行の場合
				if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
				{
					// 「Ｍ１店舗／業者区分」が"1"の場合
					if (tenpoGyosyaKb.Equals(f01m1VO.Dictionary[Tj030p01Constant.DIC_M1TENPO_GYOSYA_KB]))
					{
						if (bConmaF)
						{
							sRepSql.Append(" , ");
						}
						else
						{
							sRepSql.Append(" AND (");
							sRepSql.Append(sTableId).Append(".TENPO_CD").Append(",");
							sRepSql.Append(sTableId).Append(".FACE_NO").Append(",");
							sRepSql.Append(sTableId).Append(".TANA_DAN").Append(",");
							sRepSql.Append(sTableId).Append(".KAI_SU").Append(",");
							sRepSql.Append(sTableId).Append(".TANAOROSI_YMD").Append(",");

							// 店舗参照時は"送信回数"、業者参照時は"処理日付"
							if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(tenpoGyosyaKb))
							{
								sRepSql.Append(sTableId).Append(".SOSINKAI_SU");
							}
							else
							{
								sRepSql.Append(sTableId).Append(".SYORI_YMD");
							}
							sRepSql.Append(" ) IN (");
						}

						// 条件設定
						sRepSql.Append(" ( ");

						// 店舗コード
						sBindId = new StringBuilder();
						sBindId.Append("BIND_TENPO_CD").Append(i.ToString("0000")).Append(tenpoGyosyaKb); ;
						sRepSql.Append(" :").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = BoSystemFormat.formatTenpoCd(tenpocd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// フェイス№
						sBindId = new StringBuilder();
						sBindId.Append("BIND_FACE_NO").Append(i.ToString("0000")).Append(tenpoGyosyaKb); ;
						sRepSql.Append(" ,:").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = (string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1FACE_NO];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 棚段
						sBindId = new StringBuilder();
						sBindId.Append("BIND_TANA_DAN").Append(i.ToString("0000")).Append(tenpoGyosyaKb); ;
						sRepSql.Append(" ,:").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = (string)f01m1VO.M1tana_dan;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 回数
						sBindId = new StringBuilder();
						sBindId.Append("BIND_KAI_SU").Append(i.ToString("0000")).Append(tenpoGyosyaKb); ;
						sRepSql.Append(" ,:").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = (string)f01m1VO.M1kai_su;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 棚卸日
						sBindId = new StringBuilder();
						sBindId.Append("BIND_TANAOROSI_YMD").Append(i.ToString("0000")).Append(tenpoGyosyaKb); ;
						sRepSql.Append(" ,:").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = BoSystemFormat.formatDate((string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1TANAOROSI_YMD]);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 送信回数/処理日付
						sBindId = new StringBuilder();
						sBindId.Append("BIND_SOSINKAI_SU").Append(i.ToString("0000")).Append(tenpoGyosyaKb); ;
						sRepSql.Append(" ,:").Append(sBindId.ToString());

						bindVO = new BindInfoVO();
						bindVO.BindId = sBindId.ToString();
						bindVO.Value = (string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1SOSINKAI_SU];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						sRepSql.Append(" ) ");

						// フラグ更新
						bConmaF = true;
					}
				}
			}

			if (bConmaF)
			{
				sRepSql.Append(" )");
			}
			else
			{
				sRepSql.Append(" AND 1 = 0");
			}

			#endregion

			BoSystemSql.AddSql(reader, sREP_ID, sRepSql.ToString(), bindList);

		}

		#endregion
	}
}
