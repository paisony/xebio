using com.xebio.bo.Tj170p01.Constant;
using com.xebio.bo.Tj170p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
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

namespace com.xebio.bo.Tj170p01.Facade
{
  /// <summary>
  /// Tj170f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj170f01Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj170f01Form f01VO = (Tj170f01Form)facadeContext.FormVO;
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
						Tj170f01M1Form f01m1VO = (Tj170f01M1Form)m1List[i];
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

				FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(Tj170p01Constant.SQL_ID_04, facadeContext.DBContext);

				// テーブル設定
				//AddFromCSV(f01VO, rtSearch);
				AddFromF2(f01VO, rtSearch);
				// 
				AddHatyuMST(f01VO, rtSearch);
				//
				AddSub(f01VO, m1List, rtSearch);
				// 検索条件設定
				AddWhereCSV(f01VO, m1List, rtSearch);
				// ソート条件設定
				AddSortCSV(f01VO, rtSearch);

				//検索結果を取得します
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableList = rtSearch.Execute();

				BoSystemLog.logOut("SQL: " + rtSearch.LogSql);

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
				csvListHeader.Add("商品群１コード");
				csvListHeader.Add("商品群名１");
				csvListHeader.Add("商品群２コード");
				csvListHeader.Add("商品群名２");
				csvListHeader.Add("部門コード");
				csvListHeader.Add("部門名");
				csvListHeader.Add("部門合計_棚時帳簿数");
				csvListHeader.Add("部門合計_棚時積送数");
				csvListHeader.Add("部門合計_実棚数");
				csvListHeader.Add("部門合計_以降受払数");
				csvListHeader.Add("部門合計_理論在庫数");
				csvListHeader.Add("部門合計_理論棚卸数");
				csvListHeader.Add("部門合計_ロス数");
				csvListHeader.Add("部門合計_ロス金額");
				csvListHeader.Add("品種コード");
				csvListHeader.Add("品種名");
				csvListHeader.Add("ブランドコード");
				csvListHeader.Add("ブランド名");
				csvListHeader.Add("メーカー品番");
				csvListHeader.Add("商品名");
				csvListHeader.Add("自社品番");
				csvListHeader.Add("色");
				csvListHeader.Add("サイズ");
				csvListHeader.Add("旧自社品番");
				csvListHeader.Add("ｽｷｬﾝｺｰﾄﾞ");
				csvListHeader.Add("現売価");
				csvListHeader.Add("ﾒｰｶｰ価格");
				csvListHeader.Add("評価単価");
				csvListHeader.Add("棚時帳簿数");
				csvListHeader.Add("棚時積送数");
				csvListHeader.Add("実棚数");
				csvListHeader.Add("以降受払数");
				csvListHeader.Add("理論在庫数");
				csvListHeader.Add("理論棚卸数");
				csvListHeader.Add("ロス数");
				csvListHeader.Add("ロス金額");
				csvListHeader.Add("フェイスNo");
				csvListHeader.Add("棚段");

				csvList.Add(csvListHeader);
				foreach (Hashtable rec in tableList)
				{
					IList<string> csvListData = new List<string>();
					csvListData.Add(BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));		// 店舗コード
					csvListData.Add(rec["TENPO_NM"].ToString());		// 店舗名
					csvListData.Add(BoSystemFormat.formatSyohingunCd(rec["SYOHINGUN1_CD"].ToString()));// 商品群１コード
					csvListData.Add(rec["SYOHINGUN1_RYAKU_NM"].ToString());// 商品群名１
					csvListData.Add(BoSystemFormat.formatSyohingun2Cd(rec["SYOHINGUN2_CD"].ToString()));// 商品群２コード
					csvListData.Add(rec["GRPNM"].ToString());// 商品群名２
					csvListData.Add(BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString()));	// 部門コード
					csvListData.Add(rec["BUMON_NM"].ToString());// 部門名
					csvListData.Add(rec["GOKEI_TANAJITYOBO_SU"].ToString());// 合計_棚時帳簿数
					csvListData.Add(rec["GOKEI_TANAJISEKISO_SU"].ToString());// 合計_棚時積送数
					csvListData.Add(rec["GOKEI_JITANA_SU"].ToString());// 合計_実棚数
					csvListData.Add(rec["GOKEI_IKOUKEBARAI_SU"].ToString());// 合計_以降受払数
					csvListData.Add(rec["GOKEI_RIRONZAIKO_SU"].ToString());// 合計_理論在庫数
					csvListData.Add(rec["GOKEI_RIRONTANAOROSI_SU"].ToString());// 合計_理論棚卸数
					csvListData.Add(rec["GOKEI_LOSS_SU"].ToString());// 合計_ロス数
					csvListData.Add(rec["GOKEI_LOSS_KIN"].ToString());// 合計_ロス金額
					csvListData.Add(rec["HINSYU_CD"].ToString());// 品種コード
					csvListData.Add(rec["HINSYU_RYAKU_NM"].ToString());	// 品種名
					csvListData.Add(BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString()));	// ブランドコード
					csvListData.Add(rec["BURANDO_NMK"].ToString());// ブランド名
					csvListData.Add(rec["MAKER_HBN"].ToString());// メーカー品番
					csvListData.Add(rec["SYONMK"].ToString());// 商品名
					csvListData.Add(rec["JISYA_HBN"].ToString());// 自社品番
					csvListData.Add(rec["IRO_NM"].ToString());// 色
					csvListData.Add(rec["SIZE_NM"].ToString());// サイズ
					csvListData.Add(rec["OLD_JISYA_HBN"].ToString());// 旧自社品番
					csvListData.Add(rec["JAN_CD"].ToString());// スキャンコード
					csvListData.Add(rec["SLPR"].ToString());// 現売価
					csvListData.Add(rec["JODAI2_TNK"].ToString());// ﾒｰｶｰ価格
					csvListData.Add(rec["HYOKA_TNK"].ToString());// 評価単価
					csvListData.Add(rec["TANAJITYOBO_SU"].ToString());// 棚時帳簿数
					csvListData.Add(rec["TANAJISEKISO_SU"].ToString());// 棚時積送数
					csvListData.Add(rec["JITANA_SU"].ToString());// 実棚数
					csvListData.Add(rec["IKOUKEBARAI_SU"].ToString());// 以降受払数
					csvListData.Add(rec["RIRONZAIKO_SU"].ToString());// 理論在庫数
					csvListData.Add(rec["RIRONTANAOROSI_SU"].ToString());// 理論棚卸数
					csvListData.Add(rec["LOSS_SU"].ToString());// ロス数
					csvListData.Add(rec["LOSS_KIN"].ToString());// ロス金額
					csvListData.Add(rec["FACE_NO"].ToString());// フェイスNo
					csvListData.Add(rec["TANA_DAN"].ToString());// 棚段

					csvList.Add(csvListData);
				}

				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, PGID, BoSystemConstant.CSVID_LOSS);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tj170p01Constant.FCDUO_CSV_FLNM, tmpFileName);

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
		#region ユーザー定義関数
		#region テーブル設定
		/// <summary>
		///  条件設定FROM句
		/// </summary>
		/// <param name="Tj170f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">f01VO</param>
		/// <returns></returns>
		private void AddFromCSV(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			StringBuilder sRepSql = new StringBuilder();
			// モード今回の場合
			if (BoSystemConstant.MODE_KONKAI.Equals(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Stkmodeno)].ToString()))
			{
				sRepSql.Append(" MDIT0100 ");
			}
			// モード前回の場合
			else
			{
				sRepSql.Append(" MDIT0101 ");
			}
			BoSystemSql.AddSql(reader, Tj170p01Constant.SQL_ID_REP_TABLE, sRepSql.ToString());
		}

		#endregion
		#region 集計用サブクエリ設定
		private void AddSub(Tj170f01Form f01VO, IDataList m1List, FindSqlResultTable reader)
		{
			for (int i = 1; i <= 8; i++)
			{
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				#region 棚卸基準日
				string tanaoroshi_ymd = string.Empty;
				sRepSql.Append(" AND AA.TANAOROSI_YMD = :BIND_TANAOROSI_YMD" + i.ToString());
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TANAOROSI_YMD" + i.ToString();
				if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KONKAI))
				{
					tanaoroshi_ymd = (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Tanaorosikijun_ymd".ToUpper()];
				}
				else
				{
					tanaoroshi_ymd = (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Tanaorosikijun_ymd1".ToUpper()];
				}
				bindVO.Value = BoSystemFormat.formatDate(tanaoroshi_ymd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				#endregion
				#region M1商品群1コード
				//			sRepSql.Append("	AND AA.SYOHINGUN1_CD   = :BIND_M1SYOHINGIN1_CD" + i.ToString());
				//			bindVO = new BindInfoVO();
				//			bindVO.BindId = "BIND_M1SYOHINGIN1_CD" + i.ToString();
				//			bindVO.Value = prevM1Vo.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_CD].ToString();
				//			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				//			bindList.Add(bindVO);
				#endregion
				#region M1商品群2コード
				//			if (!string.IsNullOrEmpty(prevM1Vo.M1syohingun2_cd))
				//			{
				//				sRepSql.Append("	AND AA.SYOHINGUN2_CD   = :BIND_M1SYOHINGIN2_CD" + i.ToString());
				//				bindVO = new BindInfoVO();
				//				bindVO.BindId = "BIND_M1SYOHINGIN2_CD" + i.ToString();
				//				bindVO.Value = prevM1Vo.M1syohingun2_cd.ToString();
				//				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				//				bindList.Add(bindVO);
				//			}
				#endregion
				#region M1部門コード
				//			if (!string.IsNullOrEmpty(prevM1Vo.M1bumon_cd))
				//			{
				//				sRepSql.Append("	AND AA.BUMON_CD   = :BIND_BUMON_CD" + i.ToString());
				//				bindVO = new BindInfoVO();
				//				bindVO.BindId = "BIND_BUMON_CD" + i.ToString();
				//				bindVO.Value = BoSystemFormat.formatBumonCd(prevM1Vo.M1bumon_cd);
				//				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				//				bindList.Add(bindVO);
				//			}
				#endregion
				#region 店舗コード
				sRepSql.Append("	AND AA.TENPO_CD   = :BIND_TENPO_CD" + i.ToString());
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD" + i.ToString();
				bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				#endregion
				#region 商品群1
				//				if (!string.IsNullOrEmpty((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN1_CD"]))
				//				{
				//					sRepSql.Append("	AND AA.SYOHINGUN1_CD   = :BIND_SYOHINGIN1_CD" + i.ToString());
				//					bindVO = new BindInfoVO();
				//					bindVO.BindId = "BIND_SYOHINGIN1_CD" + i.ToString();
				//					bindVO.Value = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN1_CD"];
				//					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				//					bindList.Add(bindVO);
				//				}
				#endregion
				#region 商品群2
				//		if (!string.IsNullOrEmpty((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN2_CD"]))
				//		{
				//			sRepSql.Append("	AND AA.SYOHINGUN2_CD   = :BIND_SYOHINGIN2_CD" + i.ToString());
				//			bindVO = new BindInfoVO();
				//			bindVO.BindId = "BIND_SYOHINGIN2_CD" + i.ToString();
				//			bindVO.Value = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN2_CD"];
				//			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				//			bindList.Add(bindVO);
				//		}
				#endregion
				#region 部門コードFROM、品種コードFROM
				//			String sBumonCdFrom = BoSystemFormat.formatBumonCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "BUMON_CD_FROM"]);
				//			String sHInshuCdFrom = BoSystemFormat.formatHinsyuCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HINSYU_CD_FROM"]);
				//			// [部門コードFROM]が入力されていない場合"000"に置き換える。[品種コードFROM]が入力されていない場合"00"に置き換える。
				//			if (string.IsNullOrEmpty(sBumonCdFrom))
				//			{
				//				sBumonCdFrom = "000";
				//			}
				//			if (string.IsNullOrEmpty(sHInshuCdFrom))
				//			{
				//				sHInshuCdFrom = "00";
				//			}
				//			// [部門コードFROM]と[品種コードFROM]を文字結合した結果が"00000"以外の場合に条件とする。
				//			if (!"00000".Equals(sBumonCdFrom + sHInshuCdFrom))
				//			{
				//				sRepSql.Append(" AND (TRIM(TO_CHAR(AA.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(AA.HINSYU_CD,'00'),'00'))) >= :BIND_BUMON_FROM" + i.ToString());
				//				bindVO = new BindInfoVO();
				//				bindVO.BindId = "BIND_BUMON_FROM" + i.ToString();
				//				bindVO.Value = sBumonCdFrom + sHInshuCdFrom;
				//				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				//				bindList.Add(bindVO);
				//			}
				#endregion
				#region 部門コードTO、品種コードTO
				//			String sBumonCdTo = BoSystemFormat.formatBumonCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "BUMON_CD_TO"]);
				//			String sHInshuCdTo = BoSystemFormat.formatHinsyuCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HINSYU_CD_TO"]);
				//			// [部門コードTO]が入力されていない場合"000"に置き換える。[品種コードTO]が入力されていない場合"00"に置き換える。
				//			if (string.IsNullOrEmpty(sBumonCdTo))
				//			{
				//				sBumonCdTo = "999";
				//			}
				//			if (string.IsNullOrEmpty(sHInshuCdTo))
				//			{
				//				sHInshuCdTo = "99";
				//			}
				//			// [部門コードTO]と[品種コードTO]を文字結合した結果が"00000"以外の場合に条件とする。
				//			if (!"99999".Equals(sBumonCdTo + sHInshuCdTo))
				//			{
				//				sRepSql.Append(" AND (TRIM(TO_CHAR(AA.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(AA.HINSYU_CD,'00'),'00'))) <= :BIND_BUMON_TO" + i.ToString());
				//				bindVO = new BindInfoVO();
				//				bindVO.BindId = "BIND_BUMON_TO" + i.ToString();
				//				bindVO.Value = sBumonCdTo + sHInshuCdTo;
				//				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				//				bindList.Add(bindVO);
				//			}
				#endregion
				#region ブランド
				if (!string.IsNullOrEmpty((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD"]))
				{
					sRepSql.Append("	AND AA.BURANDO_CD   = :BIND_BURANDO_CD" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_BURANDO_CD" + i.ToString();
					bindVO.Value = BoSystemFormat.formatBumonCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD"]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region ロス点数
				if (!string.IsNullOrEmpty((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "LOSS_TENSU"]))
				{
					sRepSql.Append("	AND ABS(AA.LOSS_SU)  >= :BIND_LOSS_SU" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_LOSS_SU" + i.ToString();
					bindVO.Value = (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "LOSS_TENSU"];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region ロス有フラグ
				if (((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "LOSS_ARI_FLG"]).Equals(ConditionSelect_flg.VALUE_ARI))
				{
					sRepSql.Append(" AND ( AA.LOSS_SU <> 0 OR AA.LOSS_KIN <> 0 ) ");
				}
				#endregion
				string replaceNm = Tj170p01Constant.REP_SUB + i.ToString();
				BoSystemSql.AddSql(reader, replaceNm, sRepSql.ToString(), bindList);
			}
		}
		#endregion
		#region 検索条件設定
		/// <summary>
		///  条件設定WHERE句
		/// </summary>
		/// <param name="Tj170f01Form">f01VO</param>
		/// <param name="IDataList">f01VO</param>
		/// <param name="FindSqlResultTable">f01VO</param>
		/// <param name="">f01VO</param>
		/// <returns></returns>
		private void AddWhereCSV(Tj170f01Form f01VO, IDataList m1List, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();
			StringBuilder sRepSql2 = new StringBuilder();
			#region カード部条件
			#region 棚卸基準日
			string tanaoroshi_ymd = string.Empty;
			sRepSql.Append(" AND A.TANAOROSI_YMD = :BIND_TANAOROSI_YMD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TANAOROSI_YMD";
			if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KONKAI))
			{
				tanaoroshi_ymd = (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Tanaorosikijun_ymd".ToUpper()];
			}
			else
			{
				tanaoroshi_ymd = (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Tanaorosikijun_ymd1".ToUpper()];
			}
			bindVO.Value = BoSystemFormat.formatDate(tanaoroshi_ymd);
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			#endregion
			#region 店舗コード
			sRepSql.Append("	AND A.TENPO_CD   = :BIND_TENPO_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"]);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			#endregion
			#region 商品群1
			//				if (!string.IsNullOrEmpty((string)F01VO.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN1_CD"]))
			//				{
			//					sRepSql.Append("	AND A.SYOHINGUN1_CD   = :BIND_SYOHINGIN1_CD");
			//					bindVO = new BindInfoVO();
			//					bindVO.BindId = "BIND_SYOHINGIN1_CD";
			//					bindVO.Value = (string)F01VO.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN1_CD"];
			//					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			//					bindList.Add(bindVO);
			//				}
			#endregion
			#region 商品群2
			if (!string.IsNullOrEmpty((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN2_CD"]))
			{
				sRepSql.Append("	AND A.SYOHINGUN2_CD   = :BIND_SYOHINGIN2_CD");
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYOHINGIN2_CD";
				bindVO.Value = (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN2_CD"];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region 部門コードFROM、品種コードFROM
			String sBumonCdFrom = BoSystemFormat.formatBumonCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BUMON_CD_FROM"]);
			String sHInshuCdFrom = BoSystemFormat.formatHinsyuCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HINSYU_CD_FROM"]);
			// [部門コードFROM]が入力されていない場合"000"に置き換える。[品種コードFROM]が入力されていない場合"00"に置き換える。
			if (string.IsNullOrEmpty(sBumonCdFrom))
			{
				sBumonCdFrom = "000";
			}
			if (string.IsNullOrEmpty(sHInshuCdFrom))
			{
				sHInshuCdFrom = "00";
			}
			// [部門コードFROM]と[品種コードFROM]を文字結合した結果が"00000"以外の場合に条件とする。
			if (!"00000".Equals(sBumonCdFrom + sHInshuCdFrom))
			{
				sRepSql.Append(" AND (TRIM(TO_CHAR(A.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(A.HINSYU_CD,'00'),'00'))) >= :BIND_BUMON_FROM");
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_FROM";
				bindVO.Value = sBumonCdFrom + sHInshuCdFrom;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region 部門コードTO、品種コードTO
			String sBumonCdTo = BoSystemFormat.formatBumonCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BUMON_CD_TO"]);
			String sHInshuCdTo = BoSystemFormat.formatHinsyuCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HINSYU_CD_TO"]);
			// [部門コードTO]が入力されていない場合"000"に置き換える。[品種コードTO]が入力されていない場合"00"に置き換える。
			if (string.IsNullOrEmpty(sBumonCdTo))
			{
				sBumonCdTo = "999";
			}
			if (string.IsNullOrEmpty(sHInshuCdTo))
			{
				sHInshuCdTo = "99";
			}
			// [部門コードTO]と[品種コードTO]を文字結合した結果が"00000"以外の場合に条件とする。
			if (!"99999".Equals(sBumonCdTo + sHInshuCdTo))
			{
				sRepSql.Append(" AND (TRIM(TO_CHAR(A.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(A.HINSYU_CD,'00'),'00'))) <= :BIND_BUMON_TO");
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_TO";
				bindVO.Value = sBumonCdTo + sHInshuCdTo;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region ブランド
			if (!string.IsNullOrEmpty((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD"]))
			{
				sRepSql.Append("	AND A.BURANDO_CD   = :BIND_BURANDO_CD");
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD";
				bindVO.Value = BoSystemFormat.formatBumonCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD"]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region ロス点数
			if (!string.IsNullOrEmpty((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "LOSS_TENSU"]))
			{
				sRepSql.Append("	AND ABS(A.LOSS_SU)  >= :BIND_LOSS_SU");
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_LOSS_SU";
				bindVO.Value = (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD"];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region ロス有フラグ
			if (((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "LOSS_ARI_FLG"]).Equals(ConditionSelect_flg.VALUE_ARI))
			{
				sRepSql.Append(" AND ( A.LOSS_SU <> 0 OR A.LOSS_KIN <> 0 ) ");
			}
			#endregion
			#endregion
			#region 選択明細条件
			// Ｍ１選択フラグ(隠し)が"1"の場合、以下の処理を実施する。
			string Shuturyoku_tani = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Shuturyoku_tani)].ToString();
			if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI1))
			{
				sRepSql.Append(" AND A.SYOHINGUN1_CD IN (");
			}
			else if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI2))
			{
				sRepSql.Append(" AND ( A.SYOHINGUN1_CD, A.SYOHINGUN2_CD ) IN (");
			}
			else if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI3))
			{
				sRepSql.Append(" AND ( A.SYOHINGUN1_CD, A.SYOHINGUN2_CD, A.BUMON_CD ) IN (");
			}
			for (int i = 0; i < m1List.Count; i++)
			{
				Tj170f01M1Form f01m1VO = (Tj170f01M1Form)m1List[i];
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					if (sRepSql2.Length != 0)
					{
						sRepSql2.Append(", ");
					}
					if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI1))
					{
						#region M1商品群1コード
						sRepSql2.Append("	:BIND_M1SYOHINGUN1_CD" + i.ToString("0000"));
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_M1SYOHINGUN1_CD" + i.ToString("0000");
						bindVO.Value = f01m1VO.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_CD].ToString();
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion
					}
					else if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI2))
					{
						sRepSql2.Append(" ( :BIND_M1SYOHINGUN1_CD" + i.ToString("0000") + ", :BIND_M1SYOHINGUN2_CD" + i.ToString("0000") + ") ");
						#region M1商品群1コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_M1SYOHINGUN1_CD" + i.ToString("0000");
						bindVO.Value = f01m1VO.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_CD].ToString();
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion
						#region M2商品群2コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_M1SYOHINGUN2_CD" + i.ToString("0000");
						bindVO.Value = f01m1VO.M1syohingun2_cd.ToString();
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion
					}
					else if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI3))
					{
						sRepSql2.Append(" ( :BIND_M1SYOHINGUN1_CD" + i.ToString("0000") + ", :BIND_M1SYOHINGUN2_CD" + i.ToString("0000") + ", :BIND_M1BUMON_CD" + i.ToString("0000") + ") ");
						#region M1商品群1コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_M1SYOHINGUN1_CD" + i.ToString("0000");
						bindVO.Value = f01m1VO.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_CD].ToString();
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion
						#region M1商品群2コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_M1SYOHINGUN2_CD" + i.ToString("0000");
						bindVO.Value = f01m1VO.M1syohingun2_cd.ToString();
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion
						#region M1部門コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_M1BUMON_CD" + i.ToString("0000");
						bindVO.Value = f01m1VO.M1bumon_cd.ToString();
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion
					}
				}
			}
			sRepSql.Append(sRepSql2.ToString()).Append(" ) ");
			#endregion
			BoSystemSql.AddSql(reader, Tj170p01Constant.REP_ADD_WHERE, sRepSql.ToString(), bindList);
		}
		#endregion
		#region ソート条件設定
		/// <summary>
		///  ソート条件設定
		/// </summary>
		/// <param name="Tj170f01Form">f01VO</param>
		/// <returns></returns>
		private void AddSortCSV(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			string Sort_jun = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Sort_jun)].ToString();	
			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" ORDER BY ");
			// ■出力単位 1:商品群１
			// ○ソート順　1:商品分類順
			if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN1))
			{
				sRepSql.Append(" A.SYOHINGUN1_CD");
				sRepSql.Append(",A.SYOHINGUN2_CD");
				sRepSql.Append(",A.BUMON_CD");
				sRepSql.Append(",A.HINSYU_CD");
				sRepSql.Append(",A.BURANDO_CD");
				sRepSql.Append(",A.MAKER_HBN");
				sRepSql.Append(",A.IRO_CD");
				sRepSql.Append(",A.SIZE_CD");
			}
			// ○ソート順　2:ロス数
			else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN2))
			{
				sRepSql.Append("A.LOSS_SU DESC");
				sRepSql.Append(",A.SYOHINGUN1_CD");
				sRepSql.Append(",A.SYOHINGUN2_CD");
				sRepSql.Append(",A.BUMON_CD");
				sRepSql.Append(",A.HINSYU_CD");
				sRepSql.Append(",A.BURANDO_CD");
				sRepSql.Append(",A.MAKER_HBN");
				sRepSql.Append(",A.IRO_CD");
				sRepSql.Append(",A.SIZE_CD");
			}
			// ○ソート順　3:ロス金額
			else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN3))
			{
				sRepSql.Append(" A.LOSS_KIN DESC");
				sRepSql.Append(", A.SYOHINGUN1_CD");
				sRepSql.Append(",A.SYOHINGUN2_CD");
				sRepSql.Append(",A.BUMON_CD");
				sRepSql.Append(",A.HINSYU_CD");
				sRepSql.Append(",A.BURANDO_CD");
				sRepSql.Append(",A.MAKER_HBN");
				sRepSql.Append(",A.IRO_CD");
				sRepSql.Append(",A.SIZE_CD");
			}
			// ○ソート順　4:メーカー品番
			else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN4))
			{
				sRepSql.Append(" A.MAKER_HBN");
				sRepSql.Append(",MDMT0130.SIIRESAKI_CD");
				sRepSql.Append(",A.BURANDO_CD");
				sRepSql.Append(",A.BUMON_CD");
				sRepSql.Append(",A.HINSYU_CD");
				sRepSql.Append(",A.IRO_CD");
				sRepSql.Append(",A.SIZE_CD");
				sRepSql.Append(",A.JAN_CD");
			}
			BoSystemSql.AddSql(reader, Tj170p01Constant.REP_ADD_ORDER_BY, sRepSql.ToString());
		}
		#endregion
		#endregion
	}
}
