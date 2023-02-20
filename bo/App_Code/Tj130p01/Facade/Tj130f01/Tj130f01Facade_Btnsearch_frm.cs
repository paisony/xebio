using com.xebio.bo.Tj130p01.Constant;
using com.xebio.bo.Tj130p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01005;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tj130p01.Facade
{
  /// <summary>
  /// Tj130f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj130f01Facade : StandardBaseFacade
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
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj130f01Form f01VO = (Tj130f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);
				f01VO.Dictionary.Clear();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 棚卸基準日
				String tanaorosikijun_Ymd = "-1";

				#endregion

				#region 業務チェック
				#region 項目チェック
				// 1 単項目チェック
				// 1-1ヘッダ店舗コード												
				// 店舗MSTを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];

						// 1-2 ヘッダ店舗コード
						// 棚卸期間外の場合、エラー
						Hashtable TanaoroshiYmdList = SearchInventory.SearchMdit0030(
												f01VO.Head_tenpo_cd,
												sysDateVO.Sysdate.ToString(),     //エラーが発生した場合、その時点でチェックを中止しクライアント側
												facadeContext,
												1);

						if (TanaoroshiYmdList != null)
						{
							tanaorosikijun_Ymd = TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString();
						}
					}
				}

				// 1-2 入力担当者コード												
				// 担当者MSTを検索し、存在しない場合エラー
				f01VO.Nyuryokutan_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Nyuryokutan_cd
														, facadeContext
														, string.Empty
														, null
														, "入力担当者"
														, new[] { "Nyuryokutan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Nyuryokutan_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#region 関連チェック
				// 2 関連チェック
				// 2-1 フェイスNoFROM フェイスNoTO		
				// フェイスNoＦＲＯＭ > フェイスNoＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Face_no_from) && !string.IsNullOrEmpty(f01VO.Face_no_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Face_no_from,
									f01VO.Face_no_to,
									facadeContext,
									"フェイスNo",
									new[] { "Face_no_from", "Face_no_to" }
									);
				}

				// 2-2 入力日FROM 入力日TO
				// 入力日ＦＲＯＭ > 入力日ＴＯの場合エラー							

				if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_from) && !string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Nyuryoku_ymd_from,
									f01VO.Nyuryoku_ymd_to,
									facadeContext,
									"入力日",
									new[] { "Nyuryoku_ymd_from", "Nyuryoku_ymd_to" }
									);
				}
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				//#region 営業日取得
				//// 【共通部品】営業日取得を使用して、[営業日]を取得する。 	
				//SysDateVO sysDateVO = new SysDateVO();
				//sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				//#endregion
				////エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				//if (MessageDisplayUtil.HasError(facadeContext))
				//{
				//	return;
				//}
				//#region 棚卸基準日取得
				//// [棚卸実施日TBL]を検索し、[棚卸基準日]を取得する。
				//Hashtable hashTable = new Hashtable();
				//hashTable = SearchInventory.SearchMdit0030(f01VO.Head_tenpo_cd, sysDateVO.Sysdate.ToString(), facadeContext, 0);
				//String tanaorosikijun_Ymd = "-1";

				//if (hashTable != null)
				//{
				//	tanaorosikijun_Ymd = hashTable["TANAOROSIKIJUN_YMD"].ToString();
				//}
				//#endregion
				////エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				//if (MessageDisplayUtil.HasError(facadeContext))
				//{
				//	return;
				//}
				#region 件数チェック
				// 3 検索件数チェック
				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj130p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 抽出条件設定
				AddWhere(f01VO, rtChk, tanaorosikijun_Ymd);

				//検索結果を取得します
				decimal dCnt = -1;
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];
					dCnt = (Decimal)resultTbl["CNT"];

					// 0件チェック
					// 検索件数が0件の場合エラー								
					if (dCnt <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						// 最大件数チェック
						// 検索件数が最大件数を超える場合エラー
						V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
					}
				}
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 検索処理

				// 検索処理
				// ボディ部(カード)の条件を元に[棚卸確定TBL(H)]の検索処理を実行する。
				FindSqlResultTable rtSsarch = FindSqlUtil.CreateFindSqlResultTable(Tj130p01Constant.SQL_ID_02, facadeContext.DBContext);

				// 抽出条件設定
				AddWhere(f01VO, rtSsarch, tanaorosikijun_Ymd);

				//検索結果を取得します
				rtSsarch.CreateDbCommand();
				IList<Hashtable> tableList = rtSsarch.Execute();
				BoSystemLog.logOut("SQL: " + rtSsarch.LogSql);

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tj130f01M1Form f01m1VO = new Tj130f01M1Form();
					f01m1VO.M1face_no = rec["FACE_NO"].ToString();										// Ｍ１フェイス№
					f01m1VO.M1tana_dan = rec["TANA_DAN"].ToString();									// Ｍ１棚段
					f01m1VO.M1kai_su = rec["KAI_SU"].ToString();										// Ｍ１回数		
					f01m1VO.M1tensutanaorosinyuryoku_su = rec["TENSUTANAOROSINYURYOKU_SU"].ToString();	// Ｍ１点数棚卸入力数
					f01m1VO.M1tensutanaorositeisei_su = rec["TENSUTANAOROSITEISEI_SU"].ToString();		// Ｍ１点数棚卸訂正数
					f01m1VO.M1tensutanaorosigokei_su = rec["TENSUTANAOROSIGOKEI_SU"].ToString();		// Ｍ１点数棚卸合計数
					f01m1VO.M1scan_su = rec["TANAOROSISCAN_SU"].ToString();								// Ｍ１スキャン数量
					f01m1VO.M1teisei_suryo = rec["TANAOROSITEISEI_SU"].ToString();						// Ｍ１訂正数量
					f01m1VO.M1gokei_suryo = rec["TANAOROSIGOKEI_SU"].ToString();						// Ｍ１合計数量
					f01m1VO.M1nyuryokutan_nm = rec["HANBAIIN_NM"].ToString();							// Ｍ１入力担当者名称
					f01m1VO.M1riyucomment_nm = (rec["RIYUCOMMENT_NM"] ).ToString();// Ｍ１理由コメント情報 .Substring(0, 8)いる？
					f01m1VO.M1nyuryoku_ymd = rec["ADD_YMD"].ToString();									// Ｍ１入力日
					f01m1VO.M1selectorcheckbox = "0";													// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = "0";														// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = "0";															// Ｍ１明細色区分(隠し)

					#region Dictionary格納
					//更新用、チェック用、データ取得用に以下の項目をDictionaryに保持する。
					// [Ｍ１更新日]				：	棚卸確定TBL(H).[更新日]
					// [Ｍ１更新時間]			：	棚卸確定TBL(H).[更新時間]
					// [Ｍ１入力担当者コード]	：	棚卸確定TBL(H).[登録担当者コード]
					// [Ｍ１元フェイスNo]		：	棚卸確定TBL(H).[フェイス№]
					// [Ｍ１元棚段]				：	棚卸確定TBL(H).[棚段]
					// [Ｍ１棚卸日]				：	棚卸確定TBL(H).[棚卸日]
					// [Ｍ１送信回数]			：	棚卸確定TBL(H).[送信回数]
					// [Ｍ１理由コード]			：	棚卸確定TBL(H).[棚卸理由コード]
					
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1ROWNO, iCnt.ToString());
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());					// Ｍ１更新日
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());					// Ｍ１更新時間
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1NYURYOKUTAN_CD, rec["ADDTAN_CD"].ToString());			// Ｍ１入力担当者コード
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1FACE_NO, rec["FACE_NO"].ToString());					// Ｍ１フェイスNo
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1TANA_DAN, rec["TANA_DAN"].ToString());				// Ｍ１棚段
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1TANAOROSI_YMD, rec["TANAOROSI_YMD"].ToString());		// Ｍ１棚日卸
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1SOSINKAI_SU, rec["SOSINKAI_SU"].ToString());			// Ｍ１送信回数
					f01m1VO.Dictionary.Add(Tj130p01Constant.DIC_M1TANAOROSIRIYU_CD, rec["TANAOROSIRIYU_CD"].ToString());// Ｍ１理由コード
					#endregion

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}
				f01VO.Searchcnt = m1List.Count.ToString();

				//// 選択モードNO設定
				f01VO.Stkmodeno = f01VO.Modeno;
				#endregion

				#region 検索条件をDictionaryに設定

				// 検索時のformVOを保持
				SearchConditionSaveCls.SearchConditionSave(f01VO);
				f01VO.Dictionary[Tj130p01Constant.DIC_TANAOROSIKIJUN_YMD] = tanaorosikijun_Ymd; // 棚卸基準日

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
		#region ユーザー定義関数

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Tj130f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void AddWhere(Tj130f01Form f01VO, FindSqlResultTable reader, string tanaorosikijun_Ymd)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region ヘッダ店舗コード
			sRepSql.Append(" AND S2.TENPO_CD		= :TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			#endregion

			#region 棚卸基準日
			sRepSql.Append(" AND S2.TANAOROSI_YMD	= :TANAOROSI_YMD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "TANAOROSI_YMD";
			bindVO.Value = BoSystemFormat.formatDate(tanaorosikijun_Ymd);
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			#endregion

			#region フェイスNoFROM
			if (!string.IsNullOrEmpty(f01VO.Face_no_from))
			{
				sRepSql.Append(" AND S2.FACE_NO			>= :FACE_NO_FROM"); // ※
				bindVO = new BindInfoVO();
				bindVO.BindId = "FACE_NO_FROM";
				bindVO.Value = BoSystemFormat.formatFaceNo(f01VO.Face_no_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion

			#region フェイスNoTO
			if (!string.IsNullOrEmpty(f01VO.Face_no_to))
			{
				sRepSql.Append(" AND S2.FACE_NO			<= :FACE_NO_TO"); // ※
				bindVO = new BindInfoVO();
				bindVO.BindId = "FACE_NO_TO";
				bindVO.Value = BoSystemFormat.formatFaceNo(f01VO.Face_no_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion

			sRepSql.Append(" AND S2.SOSINZUMI_FLG	 = 0");

			// ※2:[入力担当者コード]、[入力日FROM]、[入力日TO]のいずれかが入力されている場合に条件とする。
			#region
			if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd)
				|| !string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_from)
				|| !string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_to))
			{
				sRepSql.Append(" AND EXISTS(");
				sRepSql.Append(" 	SELECT 1");
				sRepSql.Append(" 	FROM MDIT0010 S3");
				sRepSql.Append(" 	WHERE");
				sRepSql.Append(" 		S3.TENPO_CD			= S2.TENPO_CD");
				sRepSql.Append(" 	AND S3.FACE_NO			= S2.FACE_NO");
				sRepSql.Append(" 	AND S3.TANA_DAN			= S2.TANA_DAN");
				sRepSql.Append(" 	AND S3.TANAOROSI_YMD	= S2.TANAOROSI_YMD");
				sRepSql.Append(" 	AND S3.SOSINKAI_SU		= S2.SOSINKAI_SU");

				#region 入力担当者コード
				if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
				{
					sRepSql.Append(" 	AND S3.ADDTAN_CD		= :NYURYOKUTAN_CD");// ※
					bindVO = new BindInfoVO();
					bindVO.BindId = "NYURYOKUTAN_CD";
					bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Nyuryokutan_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion

				#region 入力日FROM
				if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_from))
				{
					sRepSql.Append(" 	AND S3.ADD_YMD		>= :NYURYOKU_YMD_FROM");// ※
					bindVO = new BindInfoVO();
					bindVO.BindId = "NYURYOKU_YMD_FROM";
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion

				#region 入力日TO
				if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_to))
				{
					sRepSql.Append(" 	AND S3.ADD_YMD		<= :NYURYOKU_YMD_TO");// ※
					bindVO = new BindInfoVO();
					bindVO.BindId = "NYURYOKU_YMD_TO";
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion

				sRepSql.Append(" )");
			#endregion

			}
			BoSystemSql.AddSql(reader, Tj130p01Constant.SQL_ID_REP_ADD_WHERE, sRepSql.ToString(), bindList);
		}
		#endregion
		#endregion

	}
}
