using com.xebio.bo.Th010p01.Constant;
using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01010;
using Common.Business.V01000.V01011;
using Common.Business.V01000.V01012;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Conditions;
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
		
		#region フォームを呼び出します。(ボタンID : Btnsearch)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsearch)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEARCH_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

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
				// 画面より情報を取得する。
				Th010f01Form f01VO = (Th010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				//Dictionaryの初期化
				f01VO.Dictionary.Clear();
				#endregion

				#region 業務チェック

				#region 単項目チェック[ヘッダ店舗コード]
				// 店舗マスタを検索し、存在しない場合エラー
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

				#region 選択モードが「自社品番」の場合
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_JISHAHINBAN)){

				#region 関連チェック[旧自社品番FROM, 旧自社品番TO]
				int iErrF = 0;
				// 旧自社品番FROMと旧自社品番TOが両方未入力の場合エラー
				if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from) 
					&& string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
				{
					ErrMsgCls.AddErrMsg("E192", string.Empty, facadeContext, new[] { "Old_jisya_hbn_from", "Old_jisya_hbn_to" });
					iErrF = 1;
				}

				// 旧自社品番FROMと旧自社品番TOの桁数が異なる場合エラー
				if (iErrF == 0
					&& !string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from) 
					&& !string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
				{
					if (f01VO.Old_jisya_hbn_from.Length != f01VO.Old_jisya_hbn_to.Length)
					{
						ErrMsgCls.AddErrMsg("E106", "自社品番", facadeContext, new[] { "Old_jisya_hbn_from", "Old_jisya_hbn_to" });
						iErrF = 1;
					}
						
				}

				// 旧自社品番FROM > 旧自社品番TOの場合エラー
				if (iErrF == 0
					&& !string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from) 
					&& !string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Old_jisya_hbn_from,
									f01VO.Old_jisya_hbn_to,
									facadeContext,
									"自社品番",
									new[] { "Old_jisya_hbn_from", "Old_jisya_hbn_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				
				}
				#endregion

				#region 選択モードが「スキャンコード」の場合
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_SCANCD)){

				#region 単項目チェック[スキャンコード]
				// スキャンコードが未入力だった場合エラー
				if (string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					ErrMsgCls.AddErrMsg("E121", "スキャンコード", facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 単項目チェック[スキャンコード]
				// 発注MSTを検索し、存在しない場合エラー
				SearchHachuVO searchConditionVO = new SearchHachuVO(
					f01VO.Scan_cd,			// スキャンコード
					f01VO.Head_tenpo_cd,	// 店舗コード
					0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
					0,						// 売変 検索フラグ 0:検索しない 1:検索する
					0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
					0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
					0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
					0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
					0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
					0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
					"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
					"",						// 出荷会社コード（移動出荷マニュアル)
					"",						// 入荷会社コード（移動出荷マニュアル)
					""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
				);
				Hashtable hs = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "スキャンコード", new[] { "Scan_cd" });

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				}
				#endregion

				#region 選択モードが「その他」の場合
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_SONOTA)){

				//品種コード入力時、部門コードが未入力の場合、エラー
				//if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd) && string.IsNullOrEmpty(f01VO.Bumon_cd))
				//{
				//	ErrMsgCls.AddErrMsg("E183", string.Empty, facadeContext);
				//}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				//if (MessageDisplayUtil.HasError(facadeContext))
				//{
				//	return;
				//}

				#region 単項目チェック[部門コード]
				// 部門コードが未入力だった場合エラー
				if (string.IsNullOrEmpty(f01VO.Bumon_cd))
				{
					ErrMsgCls.AddErrMsg("E121", "部門コード", facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 単項目チェック
				//部門MSTを検索し、存在しない場合エラー
				Hashtable resultHashBUMON = new Hashtable();
				resultHashBUMON = V01010Check.CheckBumon(f01VO.Bumon_cd
														, facadeContext
														, string.Empty
														, null
														, "部門"
														, new[] { "Bumon_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);

				//品種MSTを検索し、存在しない場合エラー
				Hashtable resultHashHINSYU = new Hashtable();
				resultHashHINSYU = V01011Check.CheckHinsyu(f01VO.Bumon_cd
														, f01VO.Hinsyu_cd
														, facadeContext
														, string.Empty
														, null
														, "品種"
														, new[] { "Hinsyu_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);

				//仕入先MSTを検索し、存在しない場合エラー
				Hashtable resultHashSIIRESAKI = new Hashtable();
				resultHashSIIRESAKI = V01002Check.CheckShiiresaki(f01VO.Siiresaki_cd
																, facadeContext
																, string.Empty
																, null
																, "仕入先"
																, new[] { "Siiresaki_cd" }
																, null
																, null
																, null
																, 0
																, 0
																);

				//ブランドMSTを検索し、存在しない場合エラー
				Hashtable resultHashBURANDO = new Hashtable();
				resultHashBURANDO = V01012Check.CheckBrand(f01VO.Burando_cd
														, facadeContext
														, string.Empty
														, null
														, "ブランド"
														, new[] { "Burando_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連チェック
				//品種コード入力時、部門コードが未入力の場合、エラー
				//if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd) && string.IsNullOrEmpty(f01VO.Bumon_cd))
				//{
				//	ErrMsgCls.AddErrMsg("E183", string.Empty, facadeContext);
				//}
		
				//現売価FROM > 現売価TOの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Genbaika_tnk_from) && !string.IsNullOrEmpty(f01VO.Genbaika_tnk_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Genbaika_tnk_from,
									f01VO.Genbaika_tnk_to,
									facadeContext,
									"現売価",
									new[] { "Genbaika_tnk_from", "Genbaika_tnk_to" }
									);
				}

				//メーカー価格FROM > メーカー価格TOの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Makerkakaku_tnk_from) && !string.IsNullOrEmpty(f01VO.Makerkakaku_tnk_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Makerkakaku_tnk_from,
									f01VO.Makerkakaku_tnk_to,
									facadeContext,
									"メーカー価格",
									new[] { "Makerkakaku_tnk_from", "Makerkakaku_tnk_to" }
									);
				}

				//販売完了日FROM > 販売完了日TOの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_from) && !string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Hanbaikanryo_ymd_from,
									f01VO.Hanbaikanryo_ymd_to,
									facadeContext,
									"販売完了日",
									new[] { "Hanbaikanryo_ymd_from", "Hanbaikanryo_ymd_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				}
				#endregion

				#region 選択モードが「メーカ品番」の場合
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_MAKERHBN))
				{
					// メーカー品番が未入力だった場合エラー
					if (string.IsNullOrEmpty(f01VO.Maker_hbn))
					{
						ErrMsgCls.AddErrMsg("E121", "メーカー品番", facadeContext);
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				#endregion

				#endregion

				#region 検索処理

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();

				StringBuilder sRepHint = new StringBuilder();
				StringBuilder sRepSqlOeder = new StringBuilder();

				SearchHachuVO searchVO = new SearchHachuVO();

				switch (f01VO.Modeno)
				{

					#region [選択モードNo]が「自社品番」の場合
					case BoSystemConstant.MODE_JISHAHINBAN:

						//共通部品[C01012]_パラメータ
						SearchHachuVO JishahinbanVO = new SearchHachuVO(
											"3",					// JANフラグ
											f01VO.Head_tenpo_cd,	// 店舗コード
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
						searchVO = JishahinbanVO;

						string strWkOldJisyaHbnFrom = f01VO.Old_jisya_hbn_from ;	// 作業用旧自社品番FROM
						string strWkOldJisyaHbnTo = f01VO.Old_jisya_hbn_to ;		// 作業用旧自社品番TO

						//[旧自社品番FROM].桁数が"8"あるいは[旧自社品番TO].桁数が"8"の場合
						if (f01VO.Old_jisya_hbn_from.Length == 8
							|| f01VO.Old_jisya_hbn_to.Length == 8)
						{
							//[旧自社品番FROM]=未入力の場合"00000000"を設定
							if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from))
							{
								strWkOldJisyaHbnFrom = "00000001";
							}
							//[旧自社品番TO]=未入力の場合"99999999"を設定
							if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
							{
								strWkOldJisyaHbnTo = "99999999";
							}

							//抽出条件設定
							sRepSql.Append(" AND	SYOHIN.XEBIO_CD BETWEEN	:BIND_OLD_JISYA_HBN_FROM AND :BIND_OLD_JISYA_HBN_TO ");
							sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
						}

						//[旧自社品番FROM].桁数が"10"あるいは[旧自社品番TO].桁数が"10"の場合
						if (f01VO.Old_jisya_hbn_from.Length == 10
							|| f01VO.Old_jisya_hbn_to.Length == 10)
						{
							//[旧自社品番FROM]=未入力の場合"0000000000"を設定
							if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from))
							{
								strWkOldJisyaHbnFrom = "0000000001";
							}
							//[旧自社品番TO]=未入力の場合"9999999999"を設定
							if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
							{
								strWkOldJisyaHbnTo = "9999999999";
							}

							//抽出条件設定
							sRepSql.Append(" AND (SYOHIN.XEBIO_CD, SYOHIN.MAKERCOLOR_CD) IN ");
							sRepSql.Append(" ( ");
							sRepSql.Append("	SELECT	A.XEBIO_CD , A.MAKERCOLOR_CD ");
							sRepSql.Append("	FROM	MDMT0130 A ");
							sRepSql.Append("	WHERE	A.OLD_XEBIO_CD BETWEEN :BIND_OLD_JISYA_HBN_FROM AND :BIND_OLD_JISYA_HBN_TO ");
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
						#endregion

						break;
					#endregion

					#region [選択モードNo]が「スキャンコード」の場合
					case BoSystemConstant.MODE_SCANCD:

						//共通部品[C01012]_パラメータ
						SearchHachuVO ScancdVO = new SearchHachuVO(
											"3",					// JANフラグ
											f01VO.Head_tenpo_cd,	// 店舗コード
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
						searchVO = ScancdVO;

						string strWkScanCd = f01VO.Scan_cd ; // 作業用スキャンコード

						//[スキャンコード].桁数が"18"の場合
						if (f01VO.Scan_cd.Length == 18)
						{
							//[スキャンコード]前３文字を削除して設定
							strWkScanCd = f01VO.Scan_cd.Remove(0, 3);

							//抽出条件設定
							sRepSql.Append(" AND EXISTS (	SELECT	1 ");
							sRepSql.Append("			FROM	MDMT0130 MDMT0130_A ");
							sRepSql.Append("			WHERE	MDMT0130_A.XEBIO_CD = SYOHIN.XEBIO_CD ");
							sRepSql.Append("			AND		MDMT0130_A.SYOHIN_CD_SERCH = :BIND_SCAN_CD ");
							sRepSql.Append(" ) ");
							sRepSql.Append(" AND		SYOHIN.SAKUJYO_FLG = 0 ");
						}
						else
						{
							//抽出条件設定
							sRepSql.Append(" AND EXISTS (	SELECT	1 ");
							sRepSql.Append("			FROM	MDMT0130 MDMT0130_A ");
							sRepSql.Append("			WHERE	MDMT0130_A.XEBIO_CD = SYOHIN.XEBIO_CD ");
							sRepSql.Append("			AND		MDMT0130_A.JAN_CD = :BIND_SCAN_CD ");
							sRepSql.Append(" ) ");
							sRepSql.Append(" AND		SYOHIN.SAKUJYO_FLG = 0 ");
						}

						#region バインド設定
						// スキャンコード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SCAN_CD";
						bindVO.Value = BoSystemFormat.formatJanCd(strWkScanCd);
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
					case BoSystemConstant.MODE_MAKERHBN:

						//共通部品[C01012]_パラメータ
						SearchHachuVO MakerhbnVO = new SearchHachuVO(
											"4",					// JANフラグ
											f01VO.Head_tenpo_cd,	// 店舗コード
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
						searchVO = MakerhbnVO;

						// バインド設定
						// メーカー品番
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_HIN_NBR";

						//[ログイン情報.会社コード]＝「1:ゼビオ」の場合
						if (CheckCompanyCls.IsXebio())
						{
							//抽出条件設定
							sRepSql.Append(" AND	SYOHIN.HIN_NBR	LIKE :BIND_HIN_NBR ESCAPE '\\' ");
							sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
							bindVO.Value = BoSystemString.ChangeZenHankaku(f01VO.Maker_hbn, 1) + "%";
						}
						else
						{
							//抽出条件設定
							sRepSql.Append(" AND	SYOHIN.HIN_NBR	LIKE :BIND_HIN_NBR ESCAPE '\\' ");
							sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");

							bindVO.Value = "%" + BoSystemString.ChangeZenHankaku(f01VO.Maker_hbn, 1) + "%";
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
					case BoSystemConstant.MODE_SONOTA:

						//共通部品[C01012]_パラメータ
						SearchHachuVO SonotaVO = new SearchHachuVO(
											"3",					// JANフラグ
											f01VO.Head_tenpo_cd,	// 店舗コード
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
						searchVO = SonotaVO;

						#region 抽出条件設定・バインド設定

						// 部門コード
						sRepSql.Append(" AND	SYOHIN.BUMON_CD = :BIND_BUMON_CD ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_BUMON_CD";
						bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						//品種コード
						if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd))
						{
							sRepSql.Append(" AND	SYOHIN.HINSYU_CD = :BIND_HINSYU_CD ");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_HINSYU_CD";
							bindVO.Value = BoSystemFormat.formatHinsyuCd(f01VO.Hinsyu_cd);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);
						}

						//ブランドコード
						if (!string.IsNullOrEmpty(f01VO.Burando_cd))
						{
							sRepSql.Append(" AND	SYOHIN.BURANDO_CD = :BIND_BURANDO_CD ");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_BURANDO_CD";
							bindVO.Value = BoSystemFormat.formatBrandCd(f01VO.Burando_cd);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);
						}

						// 仕入先コード
						if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
						{
							sRepSql.Append(" AND	SYOHIN.SIIRESAKI_CD = :BIND_SIIRESAKI_CD ");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SIIRESAKI_CD";
							bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);
						}

						// 現売価FROM
						if (!string.IsNullOrEmpty(f01VO.Genbaika_tnk_from))
						{
							sRepSql.Append(" AND	SYOHIN.SLPR >= :BIND_GENBAIKA_TNK_FROM ");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_GENBAIKA_TNK_FROM";
							bindVO.Value = f01VO.Genbaika_tnk_from;
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);
						}

						// 現売価TO
						if (!string.IsNullOrEmpty(f01VO.Genbaika_tnk_to))
						{
							sRepSql.Append(" AND	SYOHIN.SLPR <= :BIND_GENBAIKA_TNK_TO");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_GENBAIKA_TNK_TO";
							bindVO.Value = f01VO.Genbaika_tnk_to;
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);
						}

						// ﾒｰｶｰ価格FROM
						if (!string.IsNullOrEmpty(f01VO.Makerkakaku_tnk_from))
						{
							sRepSql.Append(" AND	SYOHIN.JODAI2_TNK >= :BIND_MAKERKAKAKU_TNK_FROM ");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_MAKERKAKAKU_TNK_FROM";
							bindVO.Value = f01VO.Makerkakaku_tnk_from;
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);
						}

						// ﾒｰｶｰ価格TO
						if (!string.IsNullOrEmpty(f01VO.Makerkakaku_tnk_to))
						{
							sRepSql.Append(" AND	SYOHIN.JODAI2_TNK <= :BIND_MAKERKAKAKU_TNK_TO ");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_MAKERKAKAKU_TNK_TO";
							bindVO.Value = f01VO.Makerkakaku_tnk_to;
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);
						}

						//販売完了日FROM
						if (!string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_from))
						{
							sRepSql.Append(" AND	SYOHIN.HANBAIKANRYO_YMD >= :BIND_HANBAIKANRYO_YMD_FROM ");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_HANBAIKANRYO_YMD_FROM";
							bindVO.Value = BoSystemFormat.formatDate(f01VO.Hanbaikanryo_ymd_from);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);
						}

						// 販売完了日TO
						if (!string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd_to))
						{
							sRepSql.Append(" AND	SYOHIN.HANBAIKANRYO_YMD <= :BIND_HANBAIKANRYO_YMD_TO ");

							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_HANBAIKANRYO_YMD_TO";
							bindVO.Value = BoSystemFormat.formatDate(f01VO.Hanbaikanryo_ymd_to);
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

						break;
					#endregion

					default:
						//どのモードにも当てはまらない
						return;
				}

				// 発注MST検索(件数取得)
				IList<Hashtable> GetHachuMstCnt = SearchHachu.SearchHachuMst(searchVO
																			, facadeContext.DBContext
																			, 4
																			, sRepSql
																			, bindList
																			, sRepHint.ToString()
																			, sRepSqlOeder.ToString()
																			,1
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

				// 検索件数の設定
				f01VO.Searchcnt = dCnt.ToString();

				#endregion

				#region 検索結果を取得
				// 発注MST検索
				IList<Hashtable> GetHachuMst = SearchHachu.SearchHachuMst(searchVO
																			, facadeContext.DBContext
																			, 4
																			, sRepSql
																			, bindList
																			, sRepHint.ToString()
																			, sRepSqlOeder.ToString()
																		);

				int iCnt = 0;
				foreach (Hashtable rec in GetHachuMst)
				{
					iCnt++;
					Th010f01M1Form f01m1VO = new Th010f01M1Form();

					f01m1VO.M1rowno					= iCnt.ToString();							//Ｍ１行NO
					f01m1VO.M1siiresaki_cd			= rec["SIIRESAKI_CD"].ToString();			//Ｍ１仕入先コード
					f01m1VO.M1siiresaki_ryaku_nm	= rec["SIIRESAKI_RYAKU_NM"].ToString();		//Ｍ１仕入先名称
					f01m1VO.M1bumon_cd				= rec["BUMON_CD"].ToString();				//Ｍ１部門コード
					f01m1VO.M1bumonkana_nm			= rec["BUMONKANA_NM"].ToString();			//Ｍ１部門カナ名
					f01m1VO.M1hinsyu_cd				= rec["HINSYU_CD"].ToString();				//Ｍ１品種コード
					f01m1VO.M1hinsyu_ryaku_nm		= rec["HINSYU_RYAKU_NM"].ToString();		//Ｍ１品種略名称
					f01m1VO.M1burando_nm			= rec["BURANDO_NMK"].ToString();			//Ｍ１ブランド名
					f01m1VO.M1syohin_zokusei		= rec["SYOHIN_ZOKUSEI"].ToString();			//Ｍ１商品属性
					f01m1VO.M1maker_hbn				= rec["HIN_NBR"].ToString();				//Ｍ１メーカー品番
					f01m1VO.M1syonmk				= rec["SYONMK"].ToString();					//Ｍ１商品名(カナ)
					f01m1VO.M1iro_nm				= rec["IRO_NM"].ToString();					//Ｍ１色
					f01m1VO.M1hanbaikanryo_ymd		= rec["HANBAIKANRYO_YMD"].ToString();		//Ｍ１販売完了日
					f01m1VO.M1zeiritsu				= rec["TAX"].ToString() + '%';				//Ｍ１税率
					f01m1VO.M1saisinbaika_tnk		= rec["BAIKA"].ToString();					//Ｍ１最新売価
					f01m1VO.M1genka					= rec["GENKA"].ToString();					//Ｍ１原価
					f01m1VO.M1genbaika_tnk			= rec["SLPR"].ToString();					//Ｍ１現売価
					f01m1VO.M1makerkakaku_tnk		= rec["JODAI2_TNK"].ToString();				//Ｍ１メーカー価格
					f01m1VO.M1selectorcheckbox		= BoSystemConstant.CHECKBOX_OFF;			//Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg			= ConditionKakuteisyori_flg.VALUE_NASI;		//Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn				= ConditionMeisaiiro_kbn.VALUE_NOMAL;		//Ｍ１明細色区分(隠し)
					
					// Dictionary
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1XEBIO_CD, rec["XEBIO_CD"].ToString());				// 自社品番
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1OLD_XEBIO_CD, rec["OLD_XEBIO_CD"].ToString());		// 旧自社品番

					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1TENKAI_KB, rec["TENKAI_KB"].ToString());				// Ｍ１展開区分
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1BURANDO_CD, rec["BURANDO_CD"].ToString());			// Ｍ１ブランドコード
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1MAKERCOLOR_CD, rec["MAKERCOLOR_CD"].ToString());		// Ｍ１色コード

					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1SIIRESAKI_CD, rec["SIIRESAKI_CD"].ToString());				// Ｍ１仕入先コード
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1SIIRESAKI_RYAKU_NM, rec["SIIRESAKI_RYAKU_NM"].ToString());	// Ｍ１仕入先名称
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_BUMON_NM, rec["BUMON_NM"].ToString());							// 部門名
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1BURANDO_NM, rec["BURANDO_NMK"].ToString());					// Ｍ１ブランド名
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1MAKER_HBN, rec["HIN_NBR"].ToString());						// Ｍ１メーカー品番
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1GENKA, rec["GENKA"].ToString());								// Ｍ１原価
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1GENBAIKA_TNK, rec["SLPR"].ToString());						// Ｍ１現売価
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1MAKERKAKAKU_TNK, rec["JODAI2_TNK"].ToString());				// Ｍ１メーカー価格

					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1ITEMKBN, rec["ITEMKBN"].ToString());							// Ｍ１商品区分
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1SIIRE_KB, rec["SIIRE_KB"].ToString());						// Ｍ１仕入区分
					f01m1VO.Dictionary.Add(Th010p01Constant.DIC_M1TYOTATSU_KB, rec["TYOTATSU_KB"].ToString());					// Ｍ１調達区分

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}
				#endregion

				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// 商品マスタ検索選択を「サイズ別／プライス」へ設定
				f01VO.Syohinmst_serchstk = ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK13;

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion
	}
}
