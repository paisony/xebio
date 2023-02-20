using com.xebio.bo.Te050p01.Constant;
using com.xebio.bo.Te050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Advanced.Util;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DateUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01010;
using Common.Business.V01000.V01012;
using Common.Business.V01000.V01013;
using Common.Business.V01000.V01027;
using Common.Business.V03000.V03003;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Te050p01.Facade
{
  /// <summary>
  /// Te050f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Te050f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Te050p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Te050f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te050f01Facade()
			: base()
		{
		}
		#endregion

		#region Te050f01画面データを作成する。
		/// <summary>
		/// Te050f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			////メソッドの開始処理を実行する。
			//StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			//try
			//{
			//	//DBコンテキストを設定する。
			//	SetDBContext(facadeContext);
			//	//コネクションを開きます。
			//	OpenConnection(facadeContext);
				
			//	//以下に業務ロジックを記述する。
				
			//	//カード部を取得します。
			//	Te050f01Form te050f01Form = (Te050f01Form)facadeContext.FormVO;
				
			//	//モデル層処理ロジックを記述してください。
			//	//カード部 データを取得(要実装)........
				
			//	//M1明細部のデータを作成します。
			//	DoM1ListLoad(facadeContext);
				
			//}
			//catch (System.Exception ex)
			//{
			//	//例外処理を実行する。
			//	ThrowException(ex, facadeContext);
			//}
			//finally
			//{
			//	//コネクションを開放する。
			//	CloseConnection(facadeContext);
			//}
			////メソッドの終了処理を実行する。
			//EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
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
			
		}
		#endregion

		#region 検索単項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te050f01Form">f01VO</param>
		/// <returns>Decimal</returns>
		private void ChkSelSingleItem ( IFacadeContext facadeContext, Te050f01Form f01VO ,String mode)
		{
			#region 単項目チェック

			// 1-1 ヘッダ店舗コード
			//       店舗マスタを検索し、存在しない場合エラー
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

			// 検索時は、以下のチェックを行う
			if(Te050p01Constant.CHECK_MODE_BTNSEARCH.Equals(mode))
			{

				// 1-2 仕入先コード
				//       仕入先マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01002Check.CheckShiiresaki(f01VO.Siiresaki_cd
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
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Siiresaki_ryaku_nm = (string)resultHash["SIIRESAKI_RYAKU_NM"];
					}
				}
				// 1-3 部門コード
				//       部門マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd
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
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm = (string)resultHash["BUMON_NM"];
					}
				}
				// 1-4 ブランドコード
				//       ブランドマスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Burando_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd
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
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm = (string)resultHash["BURANDO_NMK"];
					}
				}
			}
			#endregion
		}
		#endregion
		#region 検索関連項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索関連項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te050f01Form">f01VO</param>
		/// <returns>Decimal</returns>
		private void ChkSelRelatedItem ( IFacadeContext facadeContext, Te050f01Form f01VO )
		{
		}
		#endregion
		#region 件数チェック
		/// <summary>
		/// ChkCount 件数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IList<Hashtable>">tableListcnt</param>
		/// <returns>Decimal</returns>
		private Decimal ChkCount ( IFacadeContext facadeContext, IList<Hashtable> tableListcnt )
		{
			Hashtable resultTbl = tableListcnt[0];
			Decimal dCnt = (Decimal)resultTbl["CNT"];
			if (tableListcnt == null || tableListcnt.Count <= 0)
			{
				// エラー
				ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
			}
			else
			{

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
			return dCnt;
		}
		#endregion
		#region 明細行数チェック
		/// <summary>
		/// ChkDetailCount 明細行数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Decimal">dCnt</param>
		/// <returns>Decimal</returns>
		private void ChkDetailCount ( IFacadeContext facadeContext, Decimal cnt )
		{
			// コンフィグファイルより最大件数を取得
			Decimal dCnt = GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper());

			if (cnt > dCnt)
			{
				// 最大件数を超えている場合、エラーとする。
				ErrMsgCls.AddErrMsg("E147", dCnt.ToString(), facadeContext);
			}
		}
		#endregion
		#region 検索処理
		/// <summary>
		/// DoSelect 検索処理
		/// </summary>
		/// <param name="Te050f01Form">f01VO</param>
		/// <param name="IDBContext">DBContext</param>
		/// <param name="blCount">blCount</param>
		/// <returns>IList<Hashtable></returns>
		private IList<Hashtable> DoSelect ( Te050f01Form f01VO, IDBContext DBContext, bool blCount )
		{
			FindSqlResultTable rtSearch = null;
			if (blCount)
			{
				// 件数取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te050p01Constant.SQL_ID_01, DBContext);
			}
			else
			{
				// 検索結果取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te050p01Constant.SQL_ID_02, DBContext);
			}

			// 検索条件設定
			SetBind(f01VO, rtSearch, blCount);

			//検索結果を取得します
			rtSearch.CreateDbCommand();
			IList<Hashtable> result = rtSearch.Execute();
			BoSystemLog.logOut("SQL: " + rtSearch.LogSql);
			return result;
		}
		#endregion
		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Te050f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="blCount">blCount</param>
		/// <returns></returns>
		private void SetBind ( Te050f01Form f01VO, FindSqlResultTable reader, bool blCount )
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定
			// 検索結果取得の場合
			if (!blCount)
			{
			}

			// 店舗コードを設定
			String strTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			reader.BindValue("BIND_TENPO_CD1", strTenpoCd);
			reader.BindValue("BIND_TENPO_CD2", strTenpoCd);

			// 登録区分を設定
			reader.BindValue("BIND_SIKIBETSU_CD", Te050p01Constant.SIKIBETSU_CD_ADKB);

			// 商品区分を設定("0"(商品対象外))
			reader.BindValue("BIND_ITEMKBN", Te050p01Constant.ITEMKBN_TAISHO_GAI);

			// 仕入先コードを設定
			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				sRepSql.Append(" AND T1.SIIRESAKI_CD = :BIND_SIIRESAKI_CD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門コードを設定
			if (!string.IsNullOrEmpty(f01VO.Bumon_cd))
			{
				sRepSql.Append(" AND T1.BUMON_CD = :BIND_BUMON_CD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// ブランドコードを設定
			if (!string.IsNullOrEmpty(f01VO.Burando_cd))
			{
				sRepSql.Append(" AND T1.BURANDO_CD = :BIND_BURANDO_CD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD";
				bindVO.Value = BoSystemFormat.formatBrandCd(f01VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			BoSystemSql.AddSql(reader, Te050p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion

		}

		#endregion
		#region 転記処理(検索結果)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="tableList">取得情報</param>
		public void DoCopy ( Te050f01Form f01VO, IDataList m1List, IList<Hashtable> tableList )
		{
			int iCnt = 0;
			foreach (Hashtable rec in tableList)
			{
				iCnt++;
				Te050f01M1Form f01m1VO = new Te050f01M1Form();
				#region 明細転記
				f01m1VO.M1rowno = iCnt.ToString();										// Ｍ１行NO
				f01m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();						// Ｍ１部門コード
				f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();				// Ｍ１部門カナ名
				f01m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();			// Ｍ１品種略名称
				f01m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();					// Ｍ１ブランド名
				f01m1VO.M1jisya_hbn = rec["XEBIO_CD"].ToString();						// Ｍ１自社品番
				f01m1VO.M1maker_hbn = rec["HIN_NBR"].ToString();						// Ｍ１メーカー品番
				f01m1VO.M1syonmk = rec["SYONMK"].ToString();							// Ｍ１商品名(カナ)
				f01m1VO.M1iro_cd = rec["MAKERCOLOR_CD"].ToString();						// Ｍ１色コード
				f01m1VO.M1iro_nm = rec["IRO_NM"].ToString();							// Ｍ１色
				f01m1VO.M1stop_ymd = BoSystemString.ZeroToEmpty(rec["STOP_YMD"].ToString());	// Ｍ１防止期限
				f01m1VO.M1add_ymd = BoSystemString.ZeroToEmpty(rec["UPD_YMD"].ToString());		// Ｍ１登録日
				f01m1VO.M1honbutenpokbnnm = rec["MEISYO_NM"].ToString();				// Ｍ１本部店舗区分名称

				f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;				// Ｍ１選択フラグ(隠し)
				f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;			// Ｍ１確定処理フラグ(隠し)
				if (ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
				{
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;							// Ｍ１明細色区分(隠し)
				}
				else
				{
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;								// Ｍ１明細色区分(隠し)
				}

				// Dictionary
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1TENPO_CD, rec["TENPO_CD"].ToString());					// 店舗コード 
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());						// 更新日
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());						// 更新時間
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1SYOHINGUN1_CD, rec["SYOHINGUN1_CD"].ToString());			// 商品群1コード
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1HANBAIKANRYO_YMD, rec["HANBAIKANRYO_YMD"].ToString());	// 販売完了日
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1BURANDO_CD, rec["BURANDO_CD"].ToString());				// ブランドコード
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1SIIRESAKI_CD, rec["SIIRESAKI_CD"].ToString());			// 仕入先コード
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1HINSYU_CD, rec["HINSYU_CD"].ToString());					// 品種コード
				f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1ADD_KBN, rec["ADD_KBN"].ToString());						// 登録区分

				#endregion
				m1List.Add(f01m1VO, true);
			}
		}
		#endregion
		#region 明細初期処理(行追加)
		/// <summary>
		/// DoCopy 明細初期処理
		/// </summary>
		/// <param name="string">Head_tenpo_cd</param>
		/// <param name="Te050f01M1Form">f01m1VO</param>
		public void DoInitDetail ( string Head_tenpo_cd, Te050f01M1Form f01m1VO )
		{
			#region 初期化
			// Dictionary
			f01m1VO.Dictionary.Add(Te050p01Constant.DIC_M1TENPO_CD, Head_tenpo_cd);	// 店舗コード 
			#endregion
		}
		#endregion

		#region 行数チェック
		/// <summary>
		/// ChkRowCount 行数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void ChkRowCount ( IFacadeContext facadeContext, IDataList m1List )
		{
			int inputflg = 0;
			foreach (Te050f01M1Form f01m1VO in m1List.ListData)
			{
				// 確定処理フラグがONの場合
				if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
				{
					inputflg = 1;
					break;
				}
			}
			if (inputflg == 0)
			{
				// 確定対象がありません。
				ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
			}
		}
		#endregion
		#region 更新単項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te050f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void ChkUpdSingleItem ( IFacadeContext facadeContext, Te050f01Form f01VO, IDataList m1List, SysDateVO sysDateVO )
		{
			#region 単項目チェック
			// システム日付の5年後を取得
			decimal dFiveYear = Convert.ToDecimal(BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).AddYears(5).ToString("yyyyMMdd"));
			int iCnt = 0;
			string TenpoCd = f01VO.Head_tenpo_cd;
			foreach (Te050f01M1Form f01m1VO in m1List.ListData)
			{
				// 対象行のチェックを行う。
				// 確定処理フラグがONの場合
				if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
				{
					Boolean meisaiErr = false;
					#region 自社品番
					// 2-1 自社品番
					//     対象行が未入力の場合、エラー
					if (string.IsNullOrEmpty(f01m1VO.M1jisya_hbn))
					{
						meisaiErr = true;
						ErrMsgCls.AddErrMsg("E121", "自社品番", facadeContext, new[] { "M1jisya_hbn" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

					}
					else {
						// 2-2 自社品番
						//     重複チェック
						int iCheckCnt = 0;
						foreach (Te050f01M1Form f01m1VOcheck in m1List.ListData)
						{
							if (iCheckCnt != iCnt)
							{
								if (!string.IsNullOrEmpty(f01m1VOcheck.M1jisya_hbn)
									&& f01m1VOcheck.M1jisya_hbn.Equals(f01m1VO.M1jisya_hbn)
									&& f01m1VOcheck.M1iro_cd.Equals(f01m1VO.M1iro_cd)
									&& f01m1VOcheck.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI))
								{
									meisaiErr = true;
									ErrMsgCls.AddErrMsg("E132", String.Empty, facadeContext, new[] { "M1jisya_hbn" }
										, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

								}
							}
							iCheckCnt ++;
						}
						if (!meisaiErr)
						{
							// その他の場合
							if (f01VO.Modeno.Equals(BoSystemConstant.MODE_SONOTA))
							{
								TenpoCd = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Te050p01Constant.DIC_M1TENPO_CD]);
							}
							// 2-2 自社品番
							//     発注マスタを検索し、存在しない場合エラー

							Hashtable syohinData = null;
							if (String.IsNullOrEmpty(f01m1VO.M1iro_cd))
							{

								SearchHachuVO searchConditionVO = new SearchHachuVO(
									f01m1VO.M1jisya_hbn,	// 自社品番
									TenpoCd,				// 店舗コード
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
								syohinData = V01003Check.CheckXebioCd(searchConditionVO
																				, facadeContext
																				, "自社品番"
																				, new string[] { "M1jisya_hbn" }
																				, f01m1VO.M1rowno
																				, iCnt.ToString()
																				, "M1"
																				, m1List.DispRow);

							}
							else
							{
								SearchHachuVO searchConditionVO = new SearchHachuVO(
									f01m1VO.M1jisya_hbn,	// 自社品番
									f01m1VO.M1iro_cd,		// 色
									TenpoCd,				// 店舗コード
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
								syohinData = V01027Check.CheckXebioIroCd(searchConditionVO
																		, facadeContext
																		, "自社品番"
																		, new string[] { "M1jisya_hbn", "M1iro_cd" }
																		, f01m1VO.M1rowno
																		, iCnt.ToString()
																		, "M1"
																		, m1List.DispRow);
							}
							if (syohinData != null)
							{
								// 発注マスタ検索値をフォームビーン再設定
								f01m1VO.M1hinsyu_ryaku_nm = (string)syohinData["HINSYU_RYAKU_NM"];	// 品種名
								f01m1VO.M1jisya_hbn = (string)syohinData["XEBIO_CD"];				// 自社品番
								f01m1VO.M1maker_hbn = (string)syohinData["HIN_NBR"];				// メーカー品番
								f01m1VO.M1syonmk = (string)syohinData["SYONMK"];					// 商品名
								f01m1VO.M1bumon_cd = (string)syohinData["BUMON_CD"];				// 部門コード
								f01m1VO.M1burando_nm = (string)syohinData["BURANDO_NMK"];			// ブランド名カナ

								// Dictionary
								f01m1VO.Dictionary[Te050p01Constant.DIC_M1SYOHINGUN1_CD] = BoSystemFormat.SyohingunCd((decimal)syohinData["SYOHINGUN1_CD"]);		// 商品群1コード
								f01m1VO.Dictionary[Te050p01Constant.DIC_M1HANBAIKANRYO_YMD] = BoSystemString.ZeroToEmpty((decimal)syohinData["HANBAIKANRYO_YMD"]);	// 販売完了日 
								f01m1VO.Dictionary[Te050p01Constant.DIC_M1BURANDO_CD] = (string)syohinData["BURANDO_CD"];											// ブランドコード
								f01m1VO.Dictionary[Te050p01Constant.DIC_M1SIIRESAKI_CD] = (string)syohinData["SIIRESAKI_CD"];										// 仕入先コード
								f01m1VO.Dictionary[Te050p01Constant.DIC_M1HINSYU_CD] = BoSystemFormat.formatHinsyuCd((decimal)syohinData["HINSYU_CD"]);				// 品種コード
							}
							else
							{
								meisaiErr = true;
							}
						}
					}
					#endregion
					#region 色コード
					// 2-3 色コード
					//     色マスタを検索し、存在しない場合エラー
					if (!meisaiErr)
					{
						if (!string.IsNullOrEmpty(f01m1VO.M1iro_cd))
						{
							Hashtable resultHash = new Hashtable();
							resultHash = V01013Check.CheckIro(f01m1VO.M1iro_cd, facadeContext, "色", new[] { "M1iro_cd" }
							, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

							// 名称をラベルに設定
							if (resultHash != null)
							{
								f01m1VO.M1iro_nm = (string)resultHash["IRO_NM"];
							}
							else
							{
								meisaiErr = true;
							}
						}
					}
					#endregion
					#region 防止期限
					// 2-4 防止期限
					//     対象行が未入力の場合、エラー
					if (!meisaiErr)
					{
						if (string.IsNullOrEmpty(f01m1VO.M1stop_ymd))
						{
							meisaiErr = true;
							ErrMsgCls.AddErrMsg("E121", "防止期限", facadeContext, new[] { "M1stop_ymd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

						}
						else
						{
							// 2-5 防止期限
							//     過去日付の場合、エラー
							if (Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1stop_ymd)) < sysDateVO.Sysdate)
							{
								meisaiErr = true;
								ErrMsgCls.AddErrMsg("E105", "防止期限", facadeContext, new[] { "M1stop_ymd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							}
							// 2-6 防止期限
							//     防止期限が5年以上未来の場合、エラー
							if (Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1stop_ymd)) >= dFiveYear)
							{
								meisaiErr = true;
								ErrMsgCls.AddErrMsg("E187", string.Empty, facadeContext, new[] { "M1stop_ymd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							}

						}
					}
					#endregion
				}
				iCnt++;
			}
			#endregion
		}
		#endregion
		#region 排他チェック
		/// <summary>
		/// ChkUpdHaita 排他チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void ChkUpdHaita ( IFacadeContext facadeContext, IDataList m1List )
		{
			#region 排他チェック

			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
			sRepSql.Append(" AND JISYA_HBN = :BIND_JISYA_HBN");
			sRepSql.Append(" AND IRO_CD = :BIND_IRO_CD");
			int iCnt = 0;
			foreach (Te050f01M1Form f01m1VO in m1List.ListData)
			{

				// 対象行のみかつ登録日が設定かつ更新行
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
					&& !string.IsNullOrEmpty(f01m1VO.M1add_ymd)
					&& !DbuModeCode.INSERT.ToString().Equals(f01m1VO.Commode.ToString()))
				{
					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					// 店舗コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Te050p01Constant.DIC_M1TENPO_CD]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 自社品番
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISYA_HBN";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(f01m1VO.M1jisya_hbn);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 色コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_IRO_CD";
					bindVO.Value = BoSystemFormat.formatIroCd(f01m1VO.M1iro_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal((string)f01m1VO.Dictionary[Te050p01Constant.DIC_M1UPD_YMD]),
							Convert.ToDecimal((string)f01m1VO.Dictionary[Te050p01Constant.DIC_M1UPD_TM]),
							facadeContext,
							"MDST0010",
							sRepSql.ToString(),
							bindList,
							1,
							null,
							f01m1VO.M1rowno,
							iCnt.ToString(),
							"M1",
							m1List.DispRow
					);
				}
				iCnt++;
			}
			#endregion
		}
		#endregion
		#region [再入荷防止TBL]を更新(MERGE)する。(SQL_ID_03,SQL_ID_04)
		/// <summary>
		/// [再入荷防止TBL]を更新(MERGE)する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Merge_SaiNyukaBousi ( IFacadeContext facadeContext
											, Te050f01Form f01Form
											, Te050f01M1Form f01M1Form
											, LoginInfoVO loginInfo
											, SysDateVO sysDateVO
		)
		{
			FindSqlResultTable reader;
			// [Ｍ１色コードがNULL、もしくは空白の場合
			if (string.IsNullOrEmpty(f01M1Form.M1iro_cd))
			{
				// XMLからSQLを取得する。
				reader = FindSqlUtil.CreateFindSqlResultTable(Te050p01Constant.SQL_ID_03, facadeContext.DBContext);
				// 自社品番
				reader.BindValue("BIND_JISYA_HBN_SEL", BoSystemFormat.formatJisyaHbn(f01M1Form.M1jisya_hbn));
			}
			// [Ｍ１色コード]がNULL、 もしくは空白以外の場合
			else
			{
				// XMLからSQLを取得する。
				reader = FindSqlUtil.CreateFindSqlResultTable(Te050p01Constant.SQL_ID_04, facadeContext.DBContext);
				// 色コード
				reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f01M1Form.M1iro_cd));
			}
			// 店舗コード
			//reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Te050p01Constant.DIC_M1TENPO_CD]));
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f01M1Form.M1jisya_hbn));
			// 商品群1コード
			reader.BindValue("BIND_SYOHINGUN1_CD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Te050p01Constant.DIC_M1SYOHINGUN1_CD], "0")));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd((string)f01M1Form.Dictionary[Te050p01Constant.DIC_M1SIIRESAKI_CD]));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f01M1Form.M1bumon_cd));
			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal((string)f01M1Form.Dictionary[Te050p01Constant.DIC_M1HINSYU_CD]));
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f01M1Form.Dictionary[Te050p01Constant.DIC_M1BURANDO_CD]));
			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f01M1Form.M1maker_hbn);
			// 販売完了日
			reader.BindValue("BIND_HANBAIKANRYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f01M1Form.Dictionary[Te050p01Constant.DIC_M1HANBAIKANRYO_YMD], "0"))));
			// 防止期限
			reader.BindValue("BIND_STOP_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1stop_ymd)));
			// 登録区分
			reader.BindValue("BIND_ADD_KBN", Te050p01Constant.ADD_KBN_TENPO);
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", Te050p01Constant.FLG_OFF);						// 0（なし）
			// 送信依頼フラグ
			reader.BindValue("BIND_SOSINIRAI_FLG", Convert.ToDecimal(ConditionSosinirai_flg.VALUE_ARI));			// 1（送信対象）
			// 送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", Convert.ToDecimal(ConditionSosinzumi_flg.VALUE_MISOSIN));		// 0（未送信）
			// 受信日
			reader.BindValue("BIND_JYUSIN_YMD", 0);
			// 受信時間
			reader.BindValue("BIND_JYUSIN_TM", 0);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion
	}
}
