using com.xebio.bo.Tm030p01.Constant;
using com.xebio.bo.Tm030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01019;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace com.xebio.bo.Tm030p01.Facade
{
  /// <summary>
  /// Tm030f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tm030f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tm030p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tm030f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm030f01Facade()
			: base()
		{
		}
		#endregion

		#region Tm030f01画面データを作成する。
		/// <summary>
		/// Tm030f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				//カード部を取得します。
				Tm030f01Form tm030f01Form = (Tm030f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

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

			// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			// 画面オブジェクト取得
			Tm030f01Form form = (Tm030f01Form)facadeContext.FormVO;
			// ログイン情報取得
			LoginInfoVO loginInfo = LoginInfoUtil.GetLoginInfo();

			#region 検索処理
			// 営業日取得
			SysDateVO sysdateVO = SysdateCls.GetSysdateTime(facadeContext);
			form.Dictionary[Tm030p01Constant.DIC_SYSDATE_VO] = sysdateVO;

			// 棚卸基準日取得
			string tanaorosikijunYmd = GetTanaorosikijunYmd(facadeContext, sysdateVO);

			// 表示対象レコードNoリスト
			IList<string> recNoList = new List<string>();

			// 印刷済みリスト
			IList<string> printList = new List<string>();

			#region ■明細の表示判定■

			#region ●返品指示変更リスト
			int cntHenpinSijiHenko = GetCntHenpinSijiHenko(facadeContext, printList);

			// 一括印刷ボタン表示フラグを初期化
			form.Dictionary[Tm030p01Constant.DIC_ALLPRINT_F] = "0";

			if (cntHenpinSijiHenko > 0)
			{
				// 1件以上の場合
				recNoList.Add("1");
	
				// 一括印刷ボタン表示フラグを設定
				form.Dictionary[Tm030p01Constant.DIC_ALLPRINT_F] = "1";
			}
			#endregion

			if (!CheckKengenCls.CheckKengen(loginInfo))
			{
				// 店舗の場合

				#region ●移動出荷差異リスト
				int cntIdoShukkaSai = GetCntIdoShukkaSai(facadeContext, sysdateVO, printList);

				if (cntIdoShukkaSai > 0)
				{
					// 1件以上の場合
					recNoList.Add("2");

					// 一括印刷ボタン表示フラグを設定
					form.Dictionary[Tm030p01Constant.DIC_ALLPRINT_F] = "1";
				}
				#endregion

				#region ●棚卸重複データ
				int cntTanaoroshiChofuku = GetCntTanaoroshiChofuku(facadeContext, tanaorosikijunYmd);

				if (cntTanaoroshiChofuku >= 2)
				{
					// 2件以上の場合
					recNoList.Add("3");
				}
				#endregion

				if (cntTanaoroshiChofuku < 2)
				{
					// 棚卸重複データが1件以下の場合

					#region ●棚卸アンマッチデータ
					int cntTanaoroshiUnMatch = GetCntTanaoroshiUnMatch(facadeContext, tanaorosikijunYmd);

					if (cntTanaoroshiUnMatch > 0)
					{
						// 1件以上の場合
						recNoList.Add("4");
					}
					#endregion
				}

				#region ●経費振替決裁データ
				int cntKeihiFurikaeKessai = GetCntKeihiFurikaeKessai(facadeContext, sysdateVO);

				if (cntKeihiFurikaeKessai > 0)
				{
					// 1件以上の場合
					recNoList.Add("5");
				}
				#endregion

				#region ●エラー品番リスト
				int cntErrorHinban = GetCntErrorHinban(facadeContext, sysdateVO, printList);

				if (cntErrorHinban > 0)
				{
					// 1件以上の場合
					recNoList.Add("6");

					// 一括印刷ボタン表示フラグを設定
					form.Dictionary[Tm030p01Constant.DIC_ALLPRINT_F] = "1";
				}
				#endregion

				#region ●インストアコード振替リスト
				int cntInStoreCodeFurikae = GetCntInStoreCodeFurikae(facadeContext, printList);

				if (cntInStoreCodeFurikae > 0)
				{
					// 1件以上の場合
					recNoList.Add("7");

					// 一括印刷ボタン表示フラグを設定
					form.Dictionary[Tm030p01Constant.DIC_ALLPRINT_F] = "1";
				}
				#endregion
			}

			if (CheckCompanyCls.IsXebio())
			{
				// Xの場合

				#region ●売変作業指示対象データ（X）
				int cntBaihenSagyoSiji = GetCntBaihenSagyoSiji_X(facadeContext, sysdateVO);

				if (cntBaihenSagyoSiji > 0)
				{
					// 1件以上の場合
					recNoList.Add("8");
				}
				#endregion
			}
			else
			{
				// それ以外の場合

				#region ●売変作業指示対象データ（V）
				int cntBaihenSagyoSiji = GetCntBaihenSagyoSiji_V(facadeContext, sysdateVO);

				if (cntBaihenSagyoSiji > 0)
				{
					// 1件以上の場合
					recNoList.Add("8");
				}
				#endregion
			}

			if (!CheckKengenCls.CheckKengen(loginInfo)
				&& CheckCompanyCls.IsVictoria())
			{
				// 店舗、かつX以外の場合

				#region ●客注入荷リスト
				int cntKyakuchuNyuka = GetCntKyakuchuNyuka(facadeContext, sysdateVO);

				if (cntKyakuchuNyuka > 0)
				{
					// 1件以上の場合
					recNoList.Add("9");

					// 一括印刷ボタン表示フラグを設定
					form.Dictionary[Tm030p01Constant.DIC_ALLPRINT_F] = "1";
				}
				#endregion
			}
			#endregion

			#region ■明細情報取得■
			IList<Hashtable> oshiraseInfo = GetOshiraseInfo(facadeContext, recNoList);
			#endregion

			#endregion

			#region 画面編集処理
			// 明細オブジェクト取得
			IDataList m1List = ((Tm030f01Form)facadeContext.FormVO).GetList("M1");

			// バッチ帳票格納パス
			string listPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.BO_CONFIG_BATCH_LIST_PATH)
				+ sysdateVO.Sysdate
				+ Path.DirectorySeparatorChar;
			
			Boolean dirExists = Directory.Exists(listPath);

			for (int i = 0; i < oshiraseInfo.Count; i++)
			{
				// 明細行オブジェクト生成
				Tm030f01M1Form m1Form = new Tm030f01M1Form();

				// Ｍ１行番号
				m1Form.M1rowno = (i + 1).ToString();
				// Ｍ１メッセージ
				m1Form.M1comment_nm = oshiraseInfo[i]["COMMENT_NM"].ToString();

				if (oshiraseInfo[i]["PRINT_ID"] != null && !oshiraseInfo[i]["PRINT_ID"].Equals(DBNull.Value)
					&& oshiraseInfo[i]["PRINT_NM"] != null && !oshiraseInfo[i]["PRINT_NM"].Equals(DBNull.Value)
					&& dirExists)
				{

					// ファイル名パターン
					string pattern = string.Format(
						"{0}_{1}{2}_{3}_{4}_{5}.{6}",
						oshiraseInfo[i]["PRINT_ID"],					// 帳票ID
						sysdateVO.Sysdate,								// システム日付
						"?????????",									// システム時刻（ワイルドカード）
						BoSystemFormat.formatKaisyaCd(loginInfo.CopCd),	// 会社コード
						BoSystemFormat.formatTenpoCd(loginInfo.TnpCd),	// 店舗コード
						Tm030p01Constant.TANCD_BATCH,					// 担当者コード（バッチ）
						BoSystemConstant.RPT_PDF_EXTENSION				// 拡張子（pdf）
						);

					// ファイル名取得
					string[] files = Directory.GetFiles(listPath, pattern);

					if (files.Length > 0)
					{
						// ファイルが存在する場合
						// Ｍ１帳票ID
						m1Form.Dictionary[Tm030p01Constant.DIC_M1TYOHYO_ID] = oshiraseInfo[i]["PRINT_ID"];

						string sPrintedWord = string.Empty;
						string sRecNo = oshiraseInfo[i]["REC_NO"].ToString();
						for (int printCnt = 0; printCnt < printList.Count; printCnt++)
						{
							string sBuf = printList[printCnt].ToString();
							if (sRecNo.Equals(sBuf))
							{
								sPrintedWord = "【印刷済】";
							}
						}
						m1Form.Dictionary[Tm030p01Constant.DIC_M1TYOHYO_NM] = sPrintedWord + oshiraseInfo[i]["PRINT_NM"];
						// Ｍ１PDFファイルパス
						m1Form.Dictionary[Tm030p01Constant.DIC_M1PDF_PATH] = files[0];
					}
				}

				// Ｍ１選択フラグ(隠し)
				m1Form.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
				// Ｍ１確定処理フラグ(隠し)
				m1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
				// Ｍ１明細色区分(隠し)
				m1Form.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

				m1List.Add(m1Form, true);
			}

			if (dirExists)
			{
				// 一括印刷のボタン
				// ファイル名パターン
				string patternallprint = string.Format(
					"{0}_{1}{2}_{3}_{4}_{5}.{6}",
					Tm030p01Constant.LIST_ID_TZ900L01,				// 帳票ID
					sysdateVO.Sysdate,								// システム日付
					"?????????",									// システム時刻（ワイルドカード）
					BoSystemFormat.formatKaisyaCd(loginInfo.CopCd),	// 会社コード
					BoSystemFormat.formatTenpoCd(loginInfo.TnpCd),	// 店舗コード
					Tm030p01Constant.TANCD_BATCH,					// 担当者コード（バッチ）
					BoSystemConstant.RPT_PDF_EXTENSION				// 拡張子（pdf）
					);

				// ファイル名取得
				string[] allprintfiles = Directory.GetFiles(listPath, patternallprint);

				if (allprintfiles.Length > 0)
				{
					form.Dictionary[Tm030p01Constant.DIC_ALLPRINTPDF_PATH] = allprintfiles[0];
				}
			}

			#endregion
			// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
		}
		#endregion

		// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
		#region 棚卸基準日取得
		/// <summary>
		/// 棚卸基準日取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>棚卸基準日</returns>
		private static string GetTanaorosikijunYmd(IFacadeContext facadeContext, SysDateVO sysdateVO)
		{
			// ログイン情報取得
			LoginInfoVO loginInfo = LoginInfoUtil.GetLoginInfo();

			// 棚卸実施日TBL取得部品呼出
			Hashtable mdit0030Info = SearchInventory.SearchMdit0030(loginInfo.TnpCd, sysdateVO.Sysdate.ToString(), facadeContext);

			if (mdit0030Info != null)
			{
				// 棚卸基準日を返却
				return mdit0030Info["TANAOROSIKIJUN_YMD"].ToString();
			}
			else
			{
				return "0";
			}
		}
		#endregion

		#region 返品指示変更リスト件数取得
		/// <summary>
		/// 返品指示変更リスト件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="printList">印刷済みList</param>
		/// <returns>返品指示変更リスト件数</returns>
		private static int GetCntHenpinSijiHenko(IFacadeContext facadeContext, IList<string> printList)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_01, facadeContext.DBContext);

			// バインド変数設定
			// 店舗コード
			stmt.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			if (!result[0]["INSATSUZUMI_FLG"].ToString().Equals("0"))
			{
				printList.Add("1");
			}

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region 移動出荷差異リスト件数取得
		/// <summary>
		/// 移動出荷差異リスト件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <param name="printList">印刷済みList</param>
		/// <returns>移動出荷差異リスト件数</returns>
		private static int GetCntIdoShukkaSai(IFacadeContext facadeContext, SysDateVO sysdateVO, IList<string> printList)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_02, facadeContext.DBContext);

			// バインド変数設定
			// 出荷店コード
			stmt.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			if (!result[0]["INSATSUZUMI_FLG"].ToString().Equals("0"))
			{
				printList.Add("2");
			}

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region 棚卸重複データ件数取得
		/// <summary>
		/// 棚卸重複データ件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="tanaorosikijunYmd">棚卸基準日</param>
		/// <returns>棚卸重複データ件数</returns>
		private static int GetCntTanaoroshiChofuku(IFacadeContext facadeContext, string tanaorosikijunYmd)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_03, facadeContext.DBContext);

			// バインド変数設定
			// 店舗コード
			stmt.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			// 棚卸日
			stmt.BindValue("TANAOROSI_YMD", Convert.ToDecimal(tanaorosikijunYmd));

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region 棚卸アンマッチデータ件数取得
		/// <summary>
		/// 棚卸アンマッチデータ件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="tanaorosikijunYmd">棚卸基準日</param>
		/// <returns>棚卸アンマッチデータ件数</returns>
		private static int GetCntTanaoroshiUnMatch(IFacadeContext facadeContext, string tanaorosikijunYmd)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_04, facadeContext.DBContext);

			// バインド変数設定
			// 店舗コード
			stmt.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			// 棚卸日
			stmt.BindValue("TANAOROSI_YMD", Convert.ToDecimal(tanaorosikijunYmd));

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region 経費振替決裁データ件数取得
		/// <summary>
		/// 経費振替決裁データ件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>経費振替決裁データ件数</returns>
		private static int GetCntKeihiFurikaeKessai(IFacadeContext facadeContext, SysDateVO sysdateVO)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_05, facadeContext.DBContext);

			// バインド変数設定
			// 店舗コード
			stmt.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			// 処理日付
			// システム日付 - 1日
			DateTime sysdate;
			DateTime.TryParseExact(sysdateVO.Sysdate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sysdate);
			decimal syoriYmd;
			decimal.TryParse(sysdate.AddDays(-1D).ToString("yyyyMMdd"), out syoriYmd);
			stmt.BindValue("SYORI_YMD", syoriYmd);

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region エラー品番リスト件数取得
		/// <summary>
		/// エラー品番リスト件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <param name="printList">印刷済みList</param>
		/// <returns>エラー品番リスト件数</returns>
		private static int GetCntErrorHinban(IFacadeContext facadeContext, SysDateVO sysdateVO, IList<string> printList)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_06, facadeContext.DBContext);

			// バインド変数設定
			// 会社コード
			stmt.BindValue("KAISYA_CD", Convert.ToDecimal(LoginInfoUtil.GetLoginInfo().CopCd));
			// 店舗コード
			stmt.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			// 伝票日付
			// システム日付 - 1日
			DateTime sysdate;
			DateTime.TryParseExact(sysdateVO.Sysdate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sysdate);
			decimal denpyoYmd;
			decimal.TryParse(sysdate.AddDays(-1D).ToString("yyyyMMdd"), out denpyoYmd);
			stmt.BindValue("DENPYO_YMD", denpyoYmd);

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			if (!result[0]["INSATSUZUMI_FLG"].ToString().Equals("0"))
			{
				printList.Add("6");
			}

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region インストアコード振替リスト件数取得
		/// <summary>
		/// インストアコード振替リスト件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>インストアコード振替リスト件数</returns>
		private static int GetCntInStoreCodeFurikae(IFacadeContext facadeContext, IList<string> printList)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_07, facadeContext.DBContext);

			// バインド変数設定
			// 会社コード
			stmt.BindValue("KAISYA_CD", Convert.ToDecimal(LoginInfoUtil.GetLoginInfo().CopCd));
			// 店舗コード
			stmt.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			if (!result[0]["INSATSUZUMI_FLG"].ToString().Equals("0"))
			{
				printList.Add("7");
			}

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region 売変作業指示対象データ件数取得（X）
		/// <summary>
		/// 売変作業指示対象データ件数取得（X）
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>売変作業指示対象データ件数</returns>
		private static int GetCntBaihenSagyoSiji_X(IFacadeContext facadeContext, SysDateVO sysdateVO)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_08, facadeContext.DBContext);

			// バインド変数設定
			// 店舗コード
			stmt.BindValue("TENPO_CD1", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			stmt.BindValue("TENPO_CD2", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			// 売変開始日
			stmt.BindValue("BAIHENKAISI_YMD", sysdateVO.Sysdate);

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region 売変作業指示対象データ件数取得（V）
		/// <summary>
		/// 売変作業指示対象データ件数取得（V）
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>売変作業指示対象データ件数</returns>
		private static int GetCntBaihenSagyoSiji_V(IFacadeContext facadeContext, SysDateVO sysdateVO)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_09, facadeContext.DBContext);

			// バインド変数設定
			// 店舗コード
			stmt.BindValue("TENPO_CD1", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			stmt.BindValue("TENPO_CD2", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			// 売変開始日
			stmt.BindValue("BAIHENKAISI_YMD", sysdateVO.Sysdate);

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region 客注入荷リスト件数取得
		/// <summary>
		/// 客注入荷リスト件数取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="sysdateVO">システム日付情報</param>
		/// <returns>客注入荷リスト件数</returns>
		private static int GetCntKyakuchuNyuka(IFacadeContext facadeContext, SysDateVO sysdateVO)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_10, facadeContext.DBContext);

			// バインド変数設定
			// 店舗コード
			stmt.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(LoginInfoUtil.GetLoginInfo().TnpCd));
			// 指定納品日
			stmt.BindValue("SITEINOHIN_YMD", sysdateVO.Sysdate);

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			return int.Parse(result[0]["CNT"].ToString());
		}
		#endregion

		#region お知らせ情報取得
		/// <summary>
		/// お知らせ情報取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="recNoList">レコードNoリスト</param>
		/// <returns>お知らせ情報</returns>
		private static IList<Hashtable> GetOshiraseInfo(IFacadeContext facadeContext, IList<string> recNoList)
		{
			// SQL実行部品生成
			FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Tm030p01Constant.SQL_ID_11, facadeContext.DBContext);

			#region リプレイス変数設定
			StringBuilder addSql = new StringBuilder();
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = null;

			#region レコードNo
			StringBuilder sbRecNo = new StringBuilder();

			// レコードNoのバインド
			for (int i = 0; i < recNoList.Count; i++)
			{
				// バインドID連番（バインド数に応じて0埋め）
				string bindIdNumber = i.ToString().PadLeft(recNoList.Count.ToString().Length, '0');

				if (sbRecNo.Length > 0)
				{
					sbRecNo.Append(",");
				}
				sbRecNo.Append(" :REC_NO").Append(bindIdNumber);

				bindVO = new BindInfoVO();
				bindVO.BindId = "REC_NO" + bindIdNumber;
				bindVO.Value = recNoList[i];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}

			if (recNoList.Count == 0)
			{
				// レコードNoリストが0件の場合
				// ダミーのレコードNo
				sbRecNo.Append(" :REC_NO ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "REC_NO";
				bindVO.Value = "0";
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
				bindList.Add(bindVO);
			}

			// レコードNoのIN句
			BoSystemSql.AddSql(stmt, "REC_NO_IN", sbRecNo.ToString(), bindList);
			#endregion

			#endregion

			// 検索結果を取得します
			stmt.CreateDbCommand();
			IList<Hashtable> result = stmt.Execute();

			return result;
		}
		#endregion
		// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
	}
}
