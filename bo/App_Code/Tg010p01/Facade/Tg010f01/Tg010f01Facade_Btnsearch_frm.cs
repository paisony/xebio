using com.xebio.bo.Tg010p01.Constant;
using com.xebio.bo.Tg010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01010;
using Common.Business.V01000.V01011;
using Common.Business.V01000.V01012;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tg010p01.Facade
{
  /// <summary>
  /// Tg010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg010f01Facade : StandardBaseFacade
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
				Tg010f01Form f01VO = (Tg010f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();
				
				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				#endregion

				#region 業務チェック
				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
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
				//[選択モードNo]が「スキャンコード」の場合
				if (f01VO.Modeno == BoSystemConstant.MODE_JISHAHINBAN)
				{
					if (   (string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
						&& (string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
						&& (string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
						&& (string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
						&& (string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
						)
					{
						ErrMsgCls.AddErrMsg("E121", "自社品番", facadeContext, new[] { "Old_jisya_hbn", "Old_jisya_hbn2", "Old_jisya_hbn3", "Old_jisya_hbn4", "Old_jisya_hbn5" });	
					}
				}
				//[選択モードNo]が「その他」の場合
				else if (f01VO.Modeno == BoSystemConstant.MODE_SONOTA)
				{
					// 2-1 部門コード
					//		部門MSTを検索し、存在しない場合エラー
					if (string.IsNullOrEmpty(f01VO.Bumon_cd))
					{
						// 部門コード 必須チェックエラー
						ErrMsgCls.AddErrMsg("E121", "部門", facadeContext, new[] { "Bumon_cd" });
						return;
					}
					else
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
					// 2-2 品種コード
					//		品種MSTを検索し、存在しない場合エラー
					if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01011Check.CheckHinsyu(f01VO.Bumon_cd
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
						// 名称をラベルに設定
						if (resultHash != null)
						{
							f01VO.Hinsyu_ryaku_nm = (string)resultHash["HINSYU_RYAKU_NM"];
						}
					}

					//2-3 ブランドコード
					//		ブランドMSTを検索し、存在しない場合エラー
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
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				
				#endregion

				#region 検索処理

				#region 検索情報VO設定
				SearchHachuVO condition = new SearchHachuVO();
				condition.Tencd = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);				// 店舗コード
				condition.Pluflg = 1;			// 店別単価マスタ検索フラグ
				condition.Priceflg = 1;			// 売変検索フラグ
				condition.Zaikoflg = 0;			// 店在庫検索フラグ
				condition.Nyukaflg = 0;			// 入荷予定数検索フラグ
				condition.Uriflg = 0;			// 売上実績数検索フラグ
				condition.Hojuflg = 0;			// 依頼集計数(補充)検索フラグ
				condition.Tanpinflg = 0;		// 依頼集計数(単品)検索フラグ
				condition.Sijiflg = 0;			// 指示検索フラグ
				condition.Sijino		= "";	// 指示番号
				condition.Syukakaisyacd = "";	// 出荷会社コード
				condition.Nyukakaisyacd = "";	// 入荷会社コード
				condition.Sijitencd = "";		// 出荷店コード
				#endregion

				#region 追加抽出条件設定
				StringBuilder addSql = new StringBuilder();
				StringBuilder subAddSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = null;
				string orderBy = string.Empty;

				#region モード自社品番の場合
				if (f01VO.Modeno == BoSystemConstant.MODE_JISHAHINBAN)
				{

					#region 自社品番
					addSql.Append(" AND /* 開始→ */ ");
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
					{
						string formatedOldJisyaHbn = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn);
						if (formatedOldJisyaHbn.Length == 10)
						{
							subAddSql.Append(" SYOHIN.OLD_XEBIO_CD = :OLD_JISYA_HBN1");

						}
						else if (formatedOldJisyaHbn.Length == 8)
						{
							subAddSql.Append("	SYOHIN.XEBIO_CD  = :OLD_JISYA_HBN1 ");
						}
					} if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
					{
						string formatedOldJisyaHbn = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn2);
						if (subAddSql.Length != 0)
						{
							subAddSql.Append(" OR ");
						}
						if (formatedOldJisyaHbn.Length == 10)
						{
							subAddSql.Append(" SYOHIN.OLD_XEBIO_CD = :OLD_JISYA_HBN2");			
						}
						else if (formatedOldJisyaHbn.Length == 8)
						{
							subAddSql.Append(" SYOHIN.XEBIO_CD  = :OLD_JISYA_HBN2 ");
						}
					} if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
					{
						string formatedOldJisyaHbn = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn3);
						if (subAddSql.Length != 0)
						{
							subAddSql.Append(" OR ");
						}

						if (formatedOldJisyaHbn.Length == 10)
						{
							subAddSql.Append(" SYOHIN.OLD_XEBIO_CD = :OLD_JISYA_HBN3");
						}
						else if (formatedOldJisyaHbn.Length == 8)
						{
							subAddSql.Append(" SYOHIN.XEBIO_CD  = :OLD_JISYA_HBN3 ");
						}
					} if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
					{
						string formatedOldJisyaHbn = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn4);
						if (subAddSql.Length != 0)
						{
							subAddSql.Append(" OR ");
						}

						if (formatedOldJisyaHbn.Length == 10)
						{
							subAddSql.Append(" SYOHIN.OLD_XEBIO_CD = :OLD_JISYA_HBN4");
						}
						else if (formatedOldJisyaHbn.Length == 8)
						{ subAddSql.Append(" SYOHIN.XEBIO_CD  = :OLD_JISYA_HBN4 "); }
					} if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
					{
						string formatedOldJisyaHbn = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn5);
						if (subAddSql.Length != 0)
						{
							subAddSql.Append(" OR ");
						}

						if (formatedOldJisyaHbn.Length == 10)
						{
							subAddSql.Append(" SYOHIN.OLD_XEBIO_CD = :OLD_JISYA_HBN5");

						}
						else if (formatedOldJisyaHbn.Length == 8)
						{ subAddSql.Append(" SYOHIN.XEBIO_CD  = :OLD_JISYA_HBN5 "); }
					}

					addSql.Append(subAddSql.ToString());

					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
					{
						bindVO = new BindInfoVO();
						bindVO.BindId = "OLD_JISYA_HBN1";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					} if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
					{
						bindVO = new BindInfoVO();
						bindVO.BindId = "OLD_JISYA_HBN2";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn2);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					} if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
					{
						bindVO = new BindInfoVO();
						bindVO.BindId = "OLD_JISYA_HBN3";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn3);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					} if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
					{
						bindVO = new BindInfoVO();
						bindVO.BindId = "OLD_JISYA_HBN4";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn4);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					} if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
					{
						bindVO = new BindInfoVO();
						bindVO.BindId = "OLD_JISYA_HBN5";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn5);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}

					#endregion
					//					}
					// ソート条件設定
					orderBy = "  ORDER BY SYOHIN.BUMON_CD, SYOHIN.BURANDO_CD, SYOHIN.XEBIO_CD, SYOHIN.MAKERCOLOR_CD, SYOHIN.SIZE_NM, SYOHIN.JAN_CD";
				}
				#endregion
				#region モードその他の場合
				else if (f01VO.Modeno == BoSystemConstant.MODE_SONOTA)
				{
					#region 部門コード
					addSql.Append(" AND SYOHIN.BUMON_CD = :BUMON_CD");
					bindVO = new BindInfoVO();
					bindVO.BindId = "BUMON_CD";
					bindVO.Value = f01VO.Bumon_cd;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);
					#endregion

					#region 品種コード
					if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd))
					{
						addSql.Append(" AND SYOHIN.HINSYU_CD = :HINSYU_CD");
						bindVO = new BindInfoVO();
						bindVO.BindId = "HINSYU_CD";
						bindVO.Value = f01VO.Hinsyu_cd;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
						bindList.Add(bindVO);
					}
					#endregion

					#region ブランドコード
					if (!string.IsNullOrEmpty(f01VO.Burando_cd))
					{
						addSql.Append(" AND SYOHIN.BURANDO_CD = :BURANDO_CD");
						bindVO = new BindInfoVO();
						bindVO.BindId = "BURANDO_CD";
						bindVO.Value = f01VO.Burando_cd;
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;
						bindList.Add(bindVO);
					}
					#endregion
					// ソート条件設定
					orderBy = " ORDER BY SYOHIN.SIIRESAKI_CD, SYOHIN.BUMON_CD, SYOHIN.BURANDO_CD, SYOHIN.XEBIO_CD, SYOHIN.SIZE_NM";

				}

				#endregion

				// ヒント句設定
				string hint = string.Empty;
				
				#endregion
	
				#region 件数チェック 
				// 件数チェック追加
				//FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable("TG010P01-01", facadeContext.DBContext);
				//BoSystemSql.AddSql(rtSeach, "ADD_WHERE", addSql.ToString(), bindList);
				//検索結果を取得
				//rtSeach.CreateDbCommand();
				//IList<Hashtable> tableListcnt = rtSeach.Execute();

				// 発注マスタ取得部品呼び出し
				IList<Hashtable> tableListcnt = SearchHachu.SearchHachuMst(condition, facadeContext.DBContext, 1, addSql, bindList, hint, orderBy, 1);

				Decimal dCnt = 0;
				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					// 取得件数
					Hashtable resultTbl = tableListcnt[0];
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

				// 発注マスタ取得部品呼び出し
				IList<Hashtable> hachuMstInfo = SearchHachu.SearchHachuMst(condition, facadeContext.DBContext, 1, addSql, bindList, hint, orderBy);

				//#region 件数チェック
				//if (hachuMstInfo == null || hachuMstInfo.Count <= 0)
				//{
				//	// エラー
				//	ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				//}
				//else
				//{
				//	// 最大件数チェック
				//	V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), hachuMstInfo.Count, facadeContext);

				//}
				////エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				//if (MessageDisplayUtil.HasError(facadeContext))
				//{
				//	return;
				//}
				//#endregion

				int iCnt = 0;
				foreach (Hashtable rec in hachuMstInfo)
				{
					iCnt++;
					Tg010f01M1Form f01m1VO = new Tg010f01M1Form();
					f01m1VO.M1rowno = iCnt.ToString();									// Ｍ１行NO									
					f01m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();					// Ｍ１部門コード
					f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();			// Ｍ１部門カナ名
					f01m1VO.M1hinsyu_cd = rec["HINSYU_CD"].ToString();					// Ｍ１品種コード
					f01m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();		// Ｍ１品種略名称
					f01m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();				// Ｍ１ブランド名
					f01m1VO.M1jisya_hbn = rec["XEBIO_CD"].ToString();					// Ｍ１自社品番
					f01m1VO.M1maker_hbn = rec["HIN_NBR"].ToString();					// Ｍ１メーカー品番
					f01m1VO.M1syonmk = rec["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					f01m1VO.M1iro_nm = rec["IRO_NM"].ToString();						// Ｍ１色
					f01m1VO.M1size_nm = rec["SIZE_NM"].ToString();						// Ｍ１サイズ
					f01m1VO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();	// Ｍ１販売完了日
					f01m1VO.M1scan_cd = rec["JAN_CD"].ToString();						// Ｍ１スキャンコード
					f01m1VO.M1baihenkaisi_ymd = rec["BAIHENKAISI_YMD"].ToString();		// Ｍ１売変開始日
					f01m1VO.M1sijibaika_tnk = rec["SIJIBAIKA_TNK"].ToString();			// Ｍ１指示売価
					f01m1VO.M1saisinbaika_tnk = rec["BAIKA"].ToString();				// Ｍ１最新売価
					f01m1VO.M1maisu = "1";												// Ｍ１枚数
					f01m1VO.M1itemkbn = rec["ITEMKBN"].ToString();						// Ｍ１商品区分(隠し)
					f01m1VO.M1siire_kb = rec["SIIRE_KB"].ToString();					// Ｍ１仕入区分(隠し)
					f01m1VO.M1tyotatsu_kb = rec["TYOTATSU_KB"].ToString();				// Ｍ１調達区分(隠し)
					f01m1VO.M1makerkakaku_tnk = rec["JODAI2_TNK"].ToString();			// Ｍ１メーカー希望小売価格（隠し）
					f01m1VO.M1burando_cd = rec["BURANDO_CD"].ToString();				// Ｍ１ブランドコード（隠し）
					f01m1VO.M1bumon_nm = rec["BUMON_NM"].ToString();					// Ｍ１部門名全角（隠し）
					f01m1VO.M1siiresaki_cd_bo1 = rec["SIIRESAKI_CD"].ToString();		// Ｍ１仕入先コード（隠し）
					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;			// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;		// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
					m1List.Add(f01m1VO, true);

				}
				// 検索件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// [出力シール]の名称取得
				if (!f01VO.Dictionary.Contains(Tg010p01Constant.DIC_SYUTSURYOKU_SEAL)
					|| f01VO.Dictionary[Tg010p01Constant.DIC_SYUTSURYOKU_SEAL] == null)
				{
					CalcTaxCls tax = new CalcTaxCls();
					f01VO.Dictionary.Add(Tg010p01Constant.DIC_SYUTSURYOKU_SEAL, tax.GetTaxDispControlInfo(facadeContext));
				}

				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;
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