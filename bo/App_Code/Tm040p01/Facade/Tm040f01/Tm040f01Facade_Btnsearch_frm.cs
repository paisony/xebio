using com.xebio.bo.Tm040p01.Constant;
using com.xebio.bo.Tm040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01006;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tm040p01.Facade
{
  /// <summary>
  /// Tm040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm040f01Facade : StandardBaseFacade
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
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化

				// ログイン情報取得
				LoginInfoVO loginInfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tm040f01Form f01VO = (Tm040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// Dictionaryの初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				#endregion

				#region 業務チェック

				#region 入力値チェック

				// 1-1 出荷店コード
				// Dictionary.[FormID]が"TD020F01"(返品入力（ﾏﾆｭｱﾙ)）、かつ[指示番号]が設定されている時
				// [出荷店コード]が未設定の場合、エラー
				if (f01VO.Dictionary[Tm040p01Constant.DIC_FORM_ID].Equals(Tm040p01Constant.FORMID_TD020F01)
					&& !string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(f01VO.Siji_bango))
					&& string.IsNullOrEmpty(BoSystemString.AllZeroToEmpty(f01VO.Syukkaten_cd)))
				{
					// エラーメッセージ追加
					ErrMsgCls.AddErrMsg("E220", string.Empty, facadeContext);
				}

				// 1-2 出荷店コード
				// Dictionary.[FormID]が"TE020F01"(移動出荷入力（ﾏﾆｭｱﾙ)）、かつ[指示番号]が設定されている時
				// [出荷店コード]が未設定の場合、エラー
				if (f01VO.Dictionary[Tm040p01Constant.DIC_FORM_ID].Equals(Tm040p01Constant.FORMID_TE020F01)
					&& !string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(f01VO.Siji_bango))
					&& string.IsNullOrEmpty(BoSystemString.AllZeroToEmpty(f01VO.Syukkaten_cd)))
				{
					// エラーメッセージ追加
					ErrMsgCls.AddErrMsg("E221", string.Empty, facadeContext);
				}

				// 1-3 自社品番、スキャンコード
				// 自社品番とスキャンコードの両方とも未入力の場合、エラー
				if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn)
					&& string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					// エラーメッセージ追加
					ErrMsgCls.AddErrMsg("E212", string.Empty, facadeContext, new[] { "Old_jisya_hbn", "Scan_cd" });
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region マスタチェック

				// 2-1 入荷会社コード
				// 名称MST(KASY)に存在しない場合エラー
				if (!string.IsNullOrEmpty(BoSystemString.AllZeroToEmpty(f01VO.Jyuryokaisya_cd)))
				{
					// 入荷会社コードの前0除去
					string unformatJyuryokaisyaCd = Convert.ToInt32(f01VO.Jyuryokaisya_cd).ToString();

					Hashtable kaisyaInfo = V01006Check.CheckKaisya(unformatJyuryokaisyaCd, facadeContext);
					if (kaisyaInfo == null)
					{
						ErrMsgCls.AddErrMsg("E145", string.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// 3-1 自社品番
				// 発注MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					// 自社品番が入力されている場合

					// 発注マスタ検索用VOの設定
					SearchHachuVO vo = new SearchHachuVO();
					vo.Scancd = f01VO.Old_jisya_hbn;											// 自社品番
					vo.Tencd = BoSystemString.AllZeroToEmpty(f01VO.Tenpo_cd);					// 店舗コード
					vo.Pluflg = Convert.ToInt32(f01VO.Pluflg);									// 店別単価マスタ検索フラグ
					vo.Priceflg = Convert.ToInt32(f01VO.Priceflg);								// 売変検索フラグ
					vo.Zaikoflg = Convert.ToInt32(f01VO.Zaikoflg);								// 店在庫検索フラグ	
					vo.Nyukaflg = Convert.ToInt32(f01VO.Nyukaflg);								// 入荷予定数検索フラグ
					vo.Uriflg = Convert.ToInt32(f01VO.Uriflg);									// 売上実績数検索フラグ
					vo.Hojuflg = Convert.ToInt32(f01VO.Hojuflg);								// 依頼集計数(補充)検索フラグ
					vo.Tanpinflg = Convert.ToInt32(f01VO.Tanpinflg);							// 依頼集計数(単品)検索フラグ
					vo.Sijiflg = Convert.ToInt32(f01VO.Sijiflg);								// 指示検索フラグ
					vo.Sijino = BoSystemString.ZeroToEmpty(f01VO.Siji_bango);					// 指示番号
					vo.Syukakaisyacd = BoSystemString.AllZeroToEmpty(f01VO.Syukkakaisya_cd);	// 出荷会社コード
					vo.Nyukakaisyacd = BoSystemString.AllZeroToEmpty(f01VO.Jyuryokaisya_cd);	// 入荷会社コード
					vo.Sijitencd = BoSystemString.AllZeroToEmpty(f01VO.Syukkaten_cd);			// 出荷店コード

					// ■発注マスタ取得（自社品番）
					V01003Check.CheckXebioCd(vo, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });
				}

				// 3-2 スキャンコード
				// 発注MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					// スキャンコードが入力されている場合
					// 発注マスタ検索用VOの設定
					SearchHachuVO vo = new SearchHachuVO();
					vo.Scancd = f01VO.Scan_cd;													// スキャンコード
					vo.Tencd = BoSystemString.AllZeroToEmpty(f01VO.Tenpo_cd);					// 店舗コード
					vo.Pluflg = Convert.ToInt32(f01VO.Pluflg);									// 店別単価マスタ検索フラグ
					vo.Priceflg = Convert.ToInt32(f01VO.Priceflg);								// 売変検索フラグ
					vo.Zaikoflg = Convert.ToInt32(f01VO.Zaikoflg);								// 店在庫検索フラグ	
					vo.Nyukaflg = Convert.ToInt32(f01VO.Nyukaflg);								// 入荷予定数検索フラグ
					vo.Uriflg = Convert.ToInt32(f01VO.Uriflg);									// 売上実績数検索フラグ
					vo.Hojuflg = Convert.ToInt32(f01VO.Hojuflg);								// 依頼集計数(補充)検索フラグ
					vo.Tanpinflg = Convert.ToInt32(f01VO.Tanpinflg);							// 依頼集計数(単品)検索フラグ
					vo.Sijiflg = Convert.ToInt32(f01VO.Sijiflg);								// 指示検索フラグ
					vo.Sijino = BoSystemString.ZeroToEmpty(f01VO.Siji_bango);					// 指示番号
					vo.Syukakaisyacd = BoSystemString.AllZeroToEmpty(f01VO.Syukkakaisya_cd);	// 出荷会社コード
					vo.Nyukakaisyacd = BoSystemString.AllZeroToEmpty(f01VO.Jyuryokaisya_cd);	// 入荷会社コード
					vo.Sijitencd = BoSystemString.AllZeroToEmpty(f01VO.Syukkaten_cd);			// 出荷店コード

					// ■発注マスタ取得（スキャンコード）
					V01004Check.CheckScanCd(vo, facadeContext, "スキャンコード", new[] { "Scan_cd" });
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tm040p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 検索条件設定
				AddWhere(f01VO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				#region 件数チェック
				if (tableList.Count == 0)
				{
					// 0件の場合
					ErrMsgCls.AddErrMsg("E145", string.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;

					if (iCnt == 1)
					{
						#region カード部項目
						f01VO.Bumon_nm = rec["BUMON_NM"].ToString();				// 部門名
						f01VO.Hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// 品種略名称
						f01VO.Burando_nm = rec["BURANDO_NMK"].ToString();			// ブランド名
						f01VO.Maker_hbn = rec["HIN_NBR"].ToString();				// メーカー品番
						f01VO.Syonmk = rec["SYONMK"].ToString();					// 商品名(カナ)
						#endregion
					}

					#region 明細部項目
					Tm040f01M1Form f01m1VO = new Tm040f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();															// Ｍ１行NO
					f01m1VO.Dictionary[Tm040p01Constant.DIC_M1IRO_NM] = rec["IRO_NM"].ToString();				// Ｍ１色リンク
					f01m1VO.Dictionary[Tm040p01Constant.DIC_M1MAKERCOLOR_CD] = rec["MAKERCOLOR_CD"].ToString();	// Ｍ１色コード
					f01m1VO.Dictionary[Tm040p01Constant.DIC_M1TENKAI_KB] = rec["TENKAI_KB"].ToString();			// Ｍ１展開区分

					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;									// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;								// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;									// Ｍ１明細色区分(隠し)

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
					#endregion
				}

				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// 検索条件退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
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

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Tm040f01Form</param>
		/// <param name="stmt">SQL実行部品</param>
		private void AddWhere(Tm040f01Form f01VO, FindSqlResultTable stmt)
		{
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();
			BindInfoVO bindVO = null;

			#region 検索条件設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			#region 自社品番
			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				// 自社品番のフォーマット処理
				string formatedOldJisyaHbn = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn);

				if (formatedOldJisyaHbn.Length == 8)
				{
					// 8桁の場合
					sRepSql.Append(" AND M1.XEBIO_CD = :OLD_JISYA_HBN ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "OLD_JISYA_HBN";
					bindVO.Value = formatedOldJisyaHbn;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);
				}
				else if (formatedOldJisyaHbn.Length == 10)
				{
					// 10桁の場合
					sRepSql.Append(" AND M1.OLD_XEBIO_CD = :OLD_JISYA_HBN ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "OLD_JISYA_HBN";
					bindVO.Value = formatedOldJisyaHbn;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);
				}
			}
			#endregion

			#region スキャンコード
			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				if (f01VO.Scan_cd.Length == 18)
				{
					// 18桁の場合
					sRepSql.Append(" AND M1.SYOHIN_CD_SERCH = :SCAN_CD ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "SCAN_CD";
					bindVO.Value = BoSystemFormat.syohinCdGetSearch(f01VO.Scan_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);
				}
				else
				{
					// 18桁以外の場合
					sRepSql.Append(" AND M1.JAN_CD = :SCAN_CD ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "SCAN_CD";
					bindVO.Value = BoSystemFormat.formatJanCd(f01VO.Scan_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);
				}
			}
			#endregion

			#region 移動指示
			if (f01VO.Dictionary[Tm040p01Constant.DIC_FORM_ID].Equals(Tm040p01Constant.FORMID_TE020F01)
				&& !string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(f01VO.Siji_bango)))
			{
				// 呼出元画面IDが"TE020F01"(移動出荷入力(ﾏﾆｭｱﾙ)）、かつ指示番号が入力されている場合

				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append("         SELECT  1 ");
				sRepSql.Append("         FROM    MDUT0031 ST1 ");	// 移動指示TBL(B)
				sRepSql.Append("         WHERE   ST1.JAN_CD          = M1.JAN_CD ");
				sRepSql.Append("         AND     ST1.SIJI_BANGO      = :SIJI_BANGO ");
				sRepSql.Append("         AND     ST1.SYUKKAKAISYA_CD = :SYUKKAKAISYA_CD ");
				sRepSql.Append("         AND     ST1.SYUKKATEN_CD    = :TENPO_CD ");
				sRepSql.Append("         AND     ST1.JYURYOKAISYA_CD = :JYURYOKAISYA_CD ");
				sRepSql.Append("         AND     ST1.JYURYOTEN_CD    = :JYURYOTEN_CD ");
				sRepSql.Append("     ) ");

				// 指示番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "SIJI_BANGO";
				bindVO.Value = BoSystemFormat.IdoSijiNoGetSijino(f01VO.Siji_bango);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 数値
				bindList.Add(bindVO);

				// 出荷会社コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "SYUKKAKAISYA_CD";
				bindVO.Value = f01VO.Syukkakaisya_cd;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 数値
				bindList.Add(bindVO);

				// 出荷店コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Syukkaten_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 文字列
				bindList.Add(bindVO);

				// 入荷会社コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "JYURYOKAISYA_CD";
				bindVO.Value = BoSystemFormat.IdoSijiNoGetNyukaKaisya(f01VO.Siji_bango);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 数値
				bindList.Add(bindVO);

				// 入荷店コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "JYURYOTEN_CD";
				bindVO.Value = BoSystemFormat.IdoSijiNoGetNyukaTen(f01VO.Siji_bango);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 文字列
				bindList.Add(bindVO);
			}
			#endregion

			#region 返品指示
			if (f01VO.Dictionary[Tm040p01Constant.DIC_FORM_ID].Equals(Tm040p01Constant.FORMID_TD020F01)
				&& !string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(f01VO.Siji_bango)))
			{
				// 呼出元画面IDが"TD020F01"(返品入力(ﾏﾆｭｱﾙ)）、かつ指示番号が入力されている場合

				sRepSql.Append(" AND EXISTS ( ");
				sRepSql.Append("         SELECT  1 ");
				sRepSql.Append("         FROM    MDRT0041 ST1 ");	// 返品指示TBL(B)
				sRepSql.Append("         WHERE   ST1.JAN_CD      = M1.JAN_CD ");
				sRepSql.Append("         AND     ST1.SIJI_BANGO  = :SIJI_BANGO ");
				sRepSql.Append("         AND     ST1.TENPO_CD    = :TENPO_CD ");
				sRepSql.Append("     ) ");

				// 指示番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "SIJI_BANGO";
				bindVO.Value = BoSystemFormat.HenpinSijiNoGetSijino(f01VO.Siji_bango);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 数値
				bindList.Add(bindVO);

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Syukkaten_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 文字列
				bindList.Add(bindVO);
			}
			#endregion

			#region 他社マスタチェック
			// 会社コードの前0除去
			int unformatSyukkakaisyaCd;
			int.TryParse(f01VO.Syukkakaisya_cd, out unformatSyukkakaisyaCd);
			int unformatJyuryokaisyaCd;
			int.TryParse(f01VO.Jyuryokaisya_cd, out unformatJyuryokaisyaCd);

			if ((!string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(unformatSyukkakaisyaCd))
				&& !string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(unformatJyuryokaisyaCd)))
				&& unformatSyukkakaisyaCd != unformatJyuryokaisyaCd)
			{
				// 出荷会社コードと入荷会社コードが異なる場合
				sRepSql.Append(" AND EXISTS	( ");
				sRepSql.Append("         SELECT  1 ");
				sRepSql.Append("         FROM    MDMT0130_").Append(unformatJyuryokaisyaCd).Append(" TASYA0130 ");
				sRepSql.Append("         WHERE   TASYA0130.JAN_CD = M1.JAN_CD ");
				sRepSql.Append("     )");
			}
			#endregion

			BoSystemSql.AddSql(stmt, Tm040p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion
		}
		#endregion

	}
}
