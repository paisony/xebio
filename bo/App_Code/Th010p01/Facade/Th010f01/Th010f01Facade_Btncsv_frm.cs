using com.xebio.bo.Th010p01.Constant;
using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03004;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Th010p01.Facade
{
  /// <summary>
  /// Th010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th010f01Facade : StandardBaseFacade
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
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				Th010f01Form f01VO = (Th010f01Form)facadeContext.FormVO;
				#endregion

				#region 検索処理

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();

				StringBuilder sRepHint = new StringBuilder();
				StringBuilder sRepSqlOeder = new StringBuilder();

				SearchHachuVO searchCsvoutVO = new SearchHachuVO();

				// 検索時の条件取得
				int iserchMode;	// 検索モード
				string strModeno = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "MODENO".ToUpper()].ToString();					// モード
				string strTenpoCd = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD".ToUpper()].ToString();			// 店舗コード

				switch (strModeno)
				{

					#region [選択モードNo]が「自社品番」の場合
					case BoSystemConstant.MODE_JISHAHINBAN:

						#region 退避検索条件を取得
						string strOldJisyaHbnFrom = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "OLD_JISYA_HBN_FROM".ToUpper()].ToString();	// 自社品番
						string strOldJisyaHbnTo = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "OLD_JISYA_HBN_TO".ToUpper()].ToString();		// 旧自社品番
						#endregion

						string strWkOldJisyaHbnFrom = strOldJisyaHbnFrom ;	// 作業用旧自社品番FROM
						string strWkOldJisyaHbnTo = strOldJisyaHbnTo ;		// 作業用旧自社品番TO

						//共通部品[C01012]_パラメータ
						SearchHachuVO JishahinbanVO = new SearchHachuVO(
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
						searchCsvoutVO = JishahinbanVO;
						iserchMode = 1;

						//[旧自社品番FROM].桁数が"8"あるいは[旧自社品番TO].桁数が"8"の場合
						if (strOldJisyaHbnFrom.Length == 8 || strOldJisyaHbnTo.Length == 8)
						{
							//[旧自社品番FROM]=未入力の場合"00000000"を設定
							if (string.IsNullOrEmpty(strOldJisyaHbnFrom))
							{
								strWkOldJisyaHbnFrom = "00000001";
							}
							//[旧自社品番TO]=未入力の場合"99999999"を設定
							if (string.IsNullOrEmpty(strOldJisyaHbnTo))
							{
								strWkOldJisyaHbnTo = "99999999";
							}

							//抽出条件設定
							sRepSql.Append(" AND	SYOHIN.XEBIO_CD ");
							sRepSql.Append("  BETWEEN	:BIND_OLD_JISYA_HBN_FROM");
							sRepSql.Append("  AND		:BIND_OLD_JISYA_HBN_TO");
							sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
						}

						//[旧自社品番FROM].桁数が"10"あるいは[旧自社品番TO].桁数が"10"の場合
						if (strOldJisyaHbnFrom.Length == 10 || strOldJisyaHbnTo.Length == 10)
						{
							//[旧自社品番FROM]=未入力の場合"0000000000"を設定
							if (string.IsNullOrEmpty(strOldJisyaHbnFrom))
							{
								strWkOldJisyaHbnFrom = "0000000001";
							}
							//[旧自社品番TO]=未入力の場合"9999999999"を設定
							if (string.IsNullOrEmpty(strOldJisyaHbnTo))
							{
								strWkOldJisyaHbnTo = "9999999999";
							}

							//抽出条件設定
							sRepSql.Append(" AND (SYOHIN.XEBIO_CD, SYOHIN.MAKERCOLOR_CD) IN ");
							sRepSql.Append(" ( ");
							sRepSql.Append("	SELECT	A.XEBIO_CD , A.MAKERCOLOR_CD ");
							sRepSql.Append("	FROM	MDMT0130 A");
							sRepSql.Append("	WHERE	A.OLD_XEBIO_CD ");
							sRepSql.Append("	BETWEEN	:BIND_OLD_JISYA_HBN_FROM");
							sRepSql.Append("	AND		:BIND_OLD_JISYA_HBN_TO");
							sRepSql.Append("	AND		SYOHIN.SAKUJYO_FLG = 0 ");
							sRepSql.Append(" ) ");
						}

						#region バインド設定
						// 旧自社品番FROM
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_OLD_JISYA_HBN_FROM";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(strWkOldJisyaHbnFrom);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 旧自社品番TO
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_OLD_JISYA_HBN_TO";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(strWkOldJisyaHbnTo);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion

						#region ソート条件設定
						sRepSqlOeder.Append(" ORDER BY ");
						sRepSqlOeder.Append("  SIIRESAKI_CD ");
						sRepSqlOeder.Append(" ,BUMON_CD ");
						sRepSqlOeder.Append(" ,BURANDO_CD ");
						sRepSqlOeder.Append(" ,XEBIO_CD ");
						sRepSqlOeder.Append(" ,SIZE_CD ");
						#endregion

						break;
					#endregion

					#region [選択モードNo]が「スキャンコード」の場合
					case BoSystemConstant.MODE_SCANCD :

					#region 退避検索条件を取得
					string strScanCd = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "SCAN_CD".ToUpper()].ToString();	// スキャンコード
					#endregion


					//共通部品[C01012]_パラメータ
					SearchHachuVO ScancdVO = new SearchHachuVO(
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
					searchCsvoutVO = ScancdVO;
					iserchMode = 1;

					//[スキャンコード].桁数が"18"の場合
					if (strScanCd.Length == 18)
					{
						//[スキャンコード]前３文字を削除して設定
						strScanCd = strScanCd.Remove(0, 3);

						//抽出条件設定
						sRepSql.Append(" AND EXISTS (	SELECT	1 ");
						sRepSql.Append("			FROM	MDMT0130 MDMT0130_A ");
						sRepSql.Append("			WHERE	MDMT0130_A.XEBIO_CD = SYOHIN.XEBIO_CD ");
						sRepSql.Append("			AND		MDMT0130_A.SYOHIN_CD_SERCH = :BIND_SCAN_CD ");
						sRepSql.Append(" ) ");
						sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
					}
					else
					{
						//抽出条件設定
						sRepSql.Append(" AND EXISTS (	SELECT	1 ");
						sRepSql.Append("			FROM	MDMT0130 MDMT0130_A ");
						sRepSql.Append("			WHERE	MDMT0130_A.XEBIO_CD = SYOHIN.XEBIO_CD ");
						sRepSql.Append("			AND		MDMT0130_A.JAN_CD = :BIND_SCAN_CD ");
						sRepSql.Append(" ) ");
						sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
					}

					#region バインド設定
					// スキャンコード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD";
					bindVO.Value = BoSystemFormat.formatJanCd(strScanCd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
					#endregion

					#region ソート条件設定
					sRepSqlOeder.Append(" ORDER BY ");
					sRepSqlOeder.Append("  SIIRESAKI_CD ");
					sRepSqlOeder.Append(" ,BUMON_CD ");
					sRepSqlOeder.Append(" ,BURANDO_CD ");
					sRepSqlOeder.Append(" ,XEBIO_CD ");
					#endregion

					break;
				#endregion

					#region [選択モードNo]が「メーカー品番」の場合
					case BoSystemConstant.MODE_MAKERHBN :

					#region 退避検索条件を取得
					string strMakerHbn = BoSystemString.ChangeZenHankaku(f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "MAKER_HBN".ToUpper()].ToString(), 1);	// メーカー品番
					#endregion

					//共通部品[C01012]_パラメータ
					SearchHachuVO MakerhbnVO = new SearchHachuVO(
										"4",					// JANフラグ
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
					searchCsvoutVO = MakerhbnVO;
					iserchMode = 4;

					// バインド設定
					// メーカー品番
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_HIN_NBR";

					//[ログイン情報.会社コード]＝「1:ゼビオ」の場合
					if (CheckCompanyCls.IsXebio(logininfo.CopCd))
					{
						//抽出条件設定
						sRepSql.Append(" AND	SYOHIN.HIN_NBR	LIKE :BIND_HIN_NBR ESCAPE '\\' ");
						sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");

						bindVO.Value = strMakerHbn + "%";
					}
					else
					{
						//抽出条件設定
						sRepSql.Append(" AND	SYOHIN.HIN_NBR	LIKE :BIND_HIN_NBR ESCAPE '\\' ");
						sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");

						bindVO.Value = "%" + strMakerHbn + "%";
					}

					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					#region ソート条件設定
					sRepSqlOeder.Append(" ORDER BY ");
					sRepSqlOeder.Append("  SIIRESAKI_CD ");
					sRepSqlOeder.Append(" ,BUMON_CD ");
					sRepSqlOeder.Append(" ,BURANDO_CD ");
					sRepSqlOeder.Append(" ,XEBIO_CD ");
					#endregion

					#region ヒント文
					sRepHint.Append(" /*+ INDEX(SYOHIN MDMT0130_INDEX4) */ ");
					#endregion

					break;
				#endregion

					#region [選択モードNo]が「その他」の場合
					case BoSystemConstant.MODE_SONOTA :

					#region 退避検索条件を取得
					string strBumonCd = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BUMON_CD".ToUpper()].ToString();							// 部門コード
					string strHinsyuCd = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HINSYU_CD".ToUpper()].ToString();						// 品種コード
					string strBurandoCd = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD".ToUpper()].ToString();						// ブランドコード
					string strSiiresakiCd = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "SIIRESAKI_CD".ToUpper()].ToString();					// 仕入先コード
					string strGenbaikaTnkFrom = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "GENBAIKA_TNK_FROM".ToUpper()].ToString();			// 現売価FROM
					string strGenbaikaTnkTo = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "GENBAIKA_TNK_TO".ToUpper()].ToString();				// 現売価TO
					string strMakerkakakuTnkFrom = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "MAKERKAKAKU_TNK_FROM".ToUpper()].ToString();	// ﾒｰｶｰ価格FROM
					string strMakerkakakuTnkTo = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "MAKERKAKAKU_TNK_TO".ToUpper()].ToString();		// ﾒｰｶｰ価格TO
					string strHanbaikanryoYmdFrom = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HANBAIKANRYO_YMD_FROM".ToUpper()].ToString();	// 販売完了日FROM
					string strHanbaikanryoYmdTo = f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HANBAIKANRYO_YMD_TO".ToUpper()].ToString();		// 販売完了日TO
					#endregion


					//共通部品[C01012]_パラメータ
					SearchHachuVO SonotaVO = new SearchHachuVO(
										"3",					// JANフラグ
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
					searchCsvoutVO = SonotaVO;
					iserchMode = 1;

					#region 抽出条件設定・バインド設定
					// 部門コード
					sRepSql.Append(" AND	SYOHIN.BUMON_CD = :BIND_BUMON_CD ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_BUMON_CD";
					bindVO.Value = BoSystemFormat.formatBumonCd(strBumonCd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					//品種コード
					if (!string.IsNullOrEmpty(strHinsyuCd))
					{
						sRepSql.Append(" AND	SYOHIN.HINSYU_CD = :BIND_HINSYU_CD ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_HINSYU_CD";
						bindVO.Value = BoSystemFormat.formatHinsyuCd(strHinsyuCd);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					//ブランドコード
					if (!string.IsNullOrEmpty(strBurandoCd))
					{
						sRepSql.Append(" AND	SYOHIN.BURANDO_CD = :BIND_BURANDO_CD ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_BURANDO_CD";
						bindVO.Value = BoSystemFormat.formatBrandCd(strBurandoCd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					// 仕入先コードを設定
					if (!string.IsNullOrEmpty(strSiiresakiCd))
					{
						sRepSql.Append(" AND	SYOHIN.SIIRESAKI_CD = :BIND_SIIRESAKI_CD ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SIIRESAKI_CD";
						bindVO.Value = BoSystemFormat.formatSiiresakiCd(strSiiresakiCd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					// 現売価FROMを設定
					if (!string.IsNullOrEmpty(strGenbaikaTnkFrom))
					{
						sRepSql.Append(" AND	SYOHIN.SLPR >= :BIND_GENBAIKA_TNK_FROM ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_GENBAIKA_TNK_FROM";
						bindVO.Value = strGenbaikaTnkFrom;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					// 現売価TOを設定
					if (!string.IsNullOrEmpty(strGenbaikaTnkTo))
					{
						sRepSql.Append(" AND	SYOHIN.SLPR <= :BIND_GENBAIKA_TNK_TO ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_GENBAIKA_TNK_TO";
						bindVO.Value = strGenbaikaTnkTo;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					// ﾒｰｶｰ価格FROMを設定
					if (!string.IsNullOrEmpty(strMakerkakakuTnkFrom))
					{
						sRepSql.Append(" AND	SYOHIN.JODAI2_TNK >= :BIND_MAKERKAKAKU_TNK_FROM ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_MAKERKAKAKU_TNK_FROM";
						bindVO.Value = strMakerkakakuTnkFrom;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					// ﾒｰｶｰ価格TOを設定
					if (!string.IsNullOrEmpty(strMakerkakakuTnkTo))
					{
						sRepSql.Append(" AND	SYOHIN.JODAI2_TNK <= :BIND_MAKERKAKAKU_TNK_TO ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_MAKERKAKAKU_TNK_TO";
						bindVO.Value = strMakerkakakuTnkTo;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					//販売完了日FROMを設定
					if (!string.IsNullOrEmpty(strHanbaikanryoYmdFrom))
					{
						sRepSql.Append(" AND	SYOHIN.HANBAIKANRYO_YMD >= :BIND_HANBAIKANRYO_YMD_FROM ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_HANBAIKANRYO_YMD_FROM";
						bindVO.Value = BoSystemFormat.formatDate(strHanbaikanryoYmdFrom);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					// 販売完了日TOを設定
					if (!string.IsNullOrEmpty(strHanbaikanryoYmdTo))
					{
						sRepSql.Append(" AND	SYOHIN.HANBAIKANRYO_YMD <= :BIND_HANBAIKANRYO_YMD_TO ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_HANBAIKANRYO_YMD_TO";
						bindVO.Value = BoSystemFormat.formatDate(strHanbaikanryoYmdTo);
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

					break ;
				#endregion

					default:
						//どのモードにも当てはまらない
						return;
				}

				// 発注MST検索(件数取得)
				IList<Hashtable> GetHachuMstCnt = SearchHachu.SearchHachuMst(searchCsvoutVO
																			, facadeContext.DBContext
																			, iserchMode
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
				IList<Hashtable> GetHachuMst = SearchHachu.SearchHachuMst(searchCsvoutVO
																			, facadeContext.DBContext
																			, iserchMode
																			, sRepSql
																			, bindList
																			, sRepHint.ToString()
																			, sRepSqlOeder.ToString()
																		);

				foreach (Hashtable rec in GetHachuMst)
				{
					IList<string> csvListDate = new List<string>();

					csvListDate.Add(f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD".ToUpper()].ToString());	// 店舗コード
					csvListDate.Add(f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_NM".ToUpper()].ToString());	// 店舗名
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
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, Th010p01Constant.PGID , BoSystemConstant.CSVID_SYOHIN);

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
