using com.xebio.bo.Th010p01.Constant;
using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03004;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Th010p01.Facade
{
  /// <summary>
  /// Th010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th010f02Facade : StandardBaseFacade
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
				// 画面より情報を取得する。
				Th010f02Form prevVo = (Th010f02Form)facadeContext.FormVO;
				#endregion

				#region 検索処理

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();

				StringBuilder sRepHint = new StringBuilder();
				StringBuilder sRepSqlOeder = new StringBuilder();

				SearchHachuVO searchCsvoutVO2 = new SearchHachuVO();

				
				#region 退避検索条件を取得
				string strTenpoCd = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD".ToUpper()].ToString();				// 店舗コード
				string strSiiresakiCd = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SIIRESAKI_CD".ToUpper()].ToString();				// 仕入先コード
				string strBurandoCd = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD".ToUpper()].ToString();					// ブランドコード
				string strMakerHbn = BoSystemString.ChangeZenHankaku(prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "MAKER_HBN".ToUpper()].ToString(), 1);					// メーカー品番
				string strGenkaFlg = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "GENKA_FLG".ToUpper()].ToString();					// 原価フラグ
				string strGenka = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "GENKA".ToUpper()].ToString();							// 原価
				string strGenbaikaTnkFlg = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "GENBAIKA_FLG".ToUpper()].ToString();			// 現売価フラグ
				string strGenbaikaTnk = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "GENBAIKA_TNK".ToUpper()].ToString();				// 現売価
				string strMakerkakakuTnkFlg = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "MAKERKAKAKU_FLG".ToUpper()].ToString();	// メーカー価格フラグ
				string strMakerkakakuTnk = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "MAKERKAKAKU_TNK".ToUpper()].ToString();		// メーカー価格
				#endregion

				//共通部品[C01012]_パラメータ
				SearchHachuVO HinnbrVO2 = new SearchHachuVO(
									"1",					// JANフラグ
									strTenpoCd,				// 店舗コード
									1,						// 店別単価マスタ検索フラグ
									0,						// 売変検索フラグ
									0,						// 店在庫検索フラグ
									0,						// 入荷予定数検索フラグ
									0,						// 売上実績数検索フラグ
									0,						// 依頼集計数(補充)検索フラグ
									0,						// 依頼集計数(単品)検索フラグ
									0,						// ヒント文
									"",						// 指示数
									"",						// 出荷会社コード
									"",						// 入荷会社コード
									""						// 指示店舗コード
				);
				searchCsvoutVO2 = HinnbrVO2;

				#region 抽出条件設定・バインド設定

				// 仕入先コード
				sRepSql.Append(" AND	SYOHIN.SIIRESAKI_CD = :BIND_SIIRESAKI_CD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(strSiiresakiCd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				//ブランドコード
				sRepSql.Append(" AND	SYOHIN.BURANDO_CD = :BIND_BURANDO_CD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD";
				bindVO.Value = BoSystemFormat.formatBrandCd(strBurandoCd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);


				//メーカー品番
				if (!string.IsNullOrEmpty(strMakerHbn))
				{
					sRepSql.Append(" AND	SYOHIN.HIN_NBR	LIKE :BIND_HIN_NBR ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_HIN_NBR";
					bindVO.Value = "%" + strMakerHbn + "%";
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 原価
				if (strGenkaFlg.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					sRepSql.Append(" AND	SYOHIN.GENKA = :BIND_GENBAIKA ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_GENBAIKA";
					bindVO.Value = strGenka;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 現売価
				if (strGenbaikaTnkFlg.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					sRepSql.Append(" AND	SYOHIN.SLPR = :BIND_SLPR ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SLPR";
					bindVO.Value = strGenbaikaTnk;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// メーカー価格
				if (strMakerkakakuTnkFlg.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					sRepSql.Append(" AND	SYOHIN.JODAI2_TNK = :BIND_JODAI2_TNK ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JODAI2_TNK";
					bindVO.Value = strMakerkakakuTnk;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				//削除フラグ
				sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
				#endregion

				#region ソート条件設定
				sRepSqlOeder.Append(" ORDER BY ");
				sRepSqlOeder.Append("  SIIRESAKI_CD ");
				sRepSqlOeder.Append(" ,BUMON_CD ");
				sRepSqlOeder.Append(" ,BURANDO_CD ");
				sRepSqlOeder.Append(" ,XEBIO_CD ");
				#endregion

				// 発注MST検索(件数取得)
				IList<Hashtable> GetHachuMstCnt = SearchHachu.SearchHachuMst(searchCsvoutVO2
					, facadeContext.DBContext
					, 1
					, sRepSql
					, bindList
					, sRepHint.ToString()
					, sRepSqlOeder.ToString()
					, 1
					);
				
				#region 件数チェック
				Decimal dCnt = 0;
				if (GetHachuMstCnt == null || GetHachuMstCnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = GetHachuMstCnt[0];
					dCnt = (Decimal)resultTbl["CNT"];

					// 0件チェック
					if (dCnt <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						// 最大件数チェック
						V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 検索結果を取得
				IList<IList<string>> csvList = new List<IList<string>>();

				// ヘッダ項目の設定
				csvList.Add(this.getCsvHeader());

				// 発注MST検索
				IList<Hashtable> GetHachuMst = SearchHachu.SearchHachuMst(searchCsvoutVO2
					, facadeContext.DBContext
					, 1
					, sRepSql
					, bindList
					, sRepHint.ToString()
					, sRepSqlOeder.ToString()
					);

				foreach (Hashtable rec in GetHachuMst)
				{
					IList<string> csvListDate = new List<string>();

					csvListDate.Add(prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD".ToUpper()].ToString());	// 店舗コード
					csvListDate.Add(prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_NM".ToUpper()].ToString());	// 店舗名
					csvListDate.Add(rec["SIIRESAKI_CD"].ToString());		// 仕入先コード
					csvListDate.Add(rec["SIIRESAKI_RYAKU_NM"].ToString());	// 仕入先名
					csvListDate.Add(rec["BUMON_CD"].ToString());			// 部門コード
					csvListDate.Add(rec["BUMONKANA_NM"].ToString());		// 部門名
					csvListDate.Add(rec["HINSYU_CD"].ToString());			// 品種コード
					csvListDate.Add(rec["HINSYU_RYAKU_NM"].ToString());		// 品種名
					csvListDate.Add(rec["BURANDO_CD"].ToString());			// ブランドコード
					csvListDate.Add(rec["BURANDO_NMK"].ToString());			// ブランド名
					csvListDate.Add(rec["XEBIO_CD"].ToString());			// 自社品番
					csvListDate.Add(rec["HIN_NBR"].ToString());				// メーカー品番
					csvListDate.Add(rec["SYONMK"].ToString());				// 商品名
					csvListDate.Add(rec["IRO_NM"].ToString());				// 色
					csvListDate.Add(rec["SIZE_NM"].ToString());				// サイズ
					csvListDate.Add(rec["JAN_CD"].ToString());				// スキャンコード
					csvListDate.Add(rec["SLPR"].ToString());				// 現売価
					csvListDate.Add(rec["JODAI2_TNK"].ToString());			// メーカー価格
					csvListDate.Add(rec["BAIKA"].ToString());				// 最新売価
					csvListDate.Add(rec["GENKA"].ToString());				// 原価
					csvListDate.Add(rec["HANBAIKANRYO_YMD"].ToString());	// 販売完了日
					csvListDate.Add(rec["SYOHIN_ZOKUSEI"].ToString());		// コア属性

					//リストオブジェクトにM1Formを追加します。
					csvList.Add(csvListDate);
				}
				#endregion

				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, Th010p01Constant.PGID, BoSystemConstant.CSVID_SYOHIN);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Th010p01Constant.FCDUO_CSV_FLNM, tmpFileName);

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
			csvListData.Add("仕入先コード");
			csvListData.Add("仕入先名称");
			csvListData.Add("部門コード");
			csvListData.Add("部門名");
			csvListData.Add("品種コード");
			csvListData.Add("品種名");
			csvListData.Add("ブランドコード");
			csvListData.Add("ブランド名");
			csvListData.Add("自社品番");
			csvListData.Add("メーカー品番");
			csvListData.Add("商品名");
			csvListData.Add("色");
			csvListData.Add("サイズ");
			csvListData.Add("スキャンコード");
			csvListData.Add("現売価");
			csvListData.Add("メーカー価格");
			csvListData.Add("最新売価");
			csvListData.Add("原価");
			csvListData.Add("販売完了日");
			csvListData.Add("コア属性");

			return csvListData;
		}
		#endregion
	}
}
