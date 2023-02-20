using com.xebio.bo.Tk030p01.Constant;
using com.xebio.bo.Tk030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tk030p01.Facade
{
  /// <summary>
  /// Tk030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk030f01Facade : StandardBaseFacade
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
				// FormVO取得
				// 画面より情報を取得する。
				Tk030f01Form f01VO = (Tk030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// Dictionaryの初期化
				f01VO.Dictionary.Clear();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				#region 業務チェック

				#region マスタ存在チェック[ヘッダ店舗コード]
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

				#region 関連チェック[店舗コードFROM, 店舗コードTO]
				// 店舗コードＦＲＯＭ > 店舗コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from) && !string.IsNullOrEmpty(f01VO.Tenpo_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Tenpo_cd_from,
									f01VO.Tenpo_cd_to,
									facadeContext,
									"店舗",
									new[] { "Tenpo_cd_from", "Tenpo_cd_to" }
									);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 検索処理
				// SQL作成
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tk030p01Constant.SQL_ID_01, facadeContext.DBContext);

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();

				// 店舗コード FROM
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from.ToString()))
				{ 
					sRepSql.Append(" AND MDIT0060.TENPO_CD >= :BIND_TENPO_CD_FROM ");
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD_FROM";
					bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
					BoSystemSql.AddSql(rtSeach, Tk030p01Constant.REPLACE_ID_TENPO_CD_FROM, sRepSql.ToString(), bindList);
					
					// 初期化
					sRepSql.Length = 0;
					bindList.Clear();
				}

				// 店舗コード TO
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_to.ToString()))
				{
					sRepSql.Append(" AND MDIT0060.TENPO_CD <= :BIND_TENPO_CD_TO ");
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD_TO";
					bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
					BoSystemSql.AddSql(rtSeach, Tk030p01Constant.REPLACE_ID_TENPO_CD_TO, sRepSql.ToString(), bindList);
					
					// 初期化
					sRepSql.Length = 0;
					bindList.Clear();
				}

				// 処理月
				if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Syori_ym.ToString()))
				{ 
					sRepSql.Append(" AND MDIT0060.SYORI_YMD LIKE :BIND_SYORI_YM ");
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYORI_YM";
					bindVO.Value = f01VO.Syori_ym.Substring(0, 6) + "__";
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
					BoSystemSql.AddSql(rtSeach, Tk030p01Constant.REPLACE_ID_SYORI_YM, sRepSql.ToString(), bindList);
					// 初期化
					sRepSql.Length = 0;
				}

				// 調達区分
				sRepSql.Append(" AND SUBSTR(MDIT0060.TYOTATSU_KB,-1,1) BETWEEN 1 AND 4 ");
				BoSystemSql.AddSql(rtSeach, Tk030p01Constant.REPLACE_ID_TYOTATSU_KB, sRepSql.ToString(), null);

				//検索結果を取得
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				#endregion

				#region 件数チェック
				Decimal dCnt = 0;
				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					// 取得件数
					dCnt = tableList.Count;

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

				#region 画面の表示
				int iCnt = 0;
				decimal dSumSu = 0;		// 合計数量
				decimal dSumGenTnk = 0;	// 原価金額合計
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tk030f01M1Form f01m1VO = new Tk030f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();									// Ｍ１行NO
					f01m1VO.M1tenpo_cd = rec["TENPO_CD"].ToString();					// Ｍ１店舗コード
					f01m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();					// Ｍ１部門コード
					f01m1VO.M1hinsyu_cd = rec["HINSYU_CD"].ToString();					// Ｍ１品種コード
					f01m1VO.M1burando_nm = rec["BURANDOKANA"].ToString();				// Ｍ１ブランド名
					f01m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();					// Ｍ１自社品番
					f01m1VO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();	// Ｍ１販売完了日
					f01m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();					// Ｍ１メーカー品番
					f01m1VO.M1syonmk = rec["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					f01m1VO.M1scan_cd = rec["JAN_CD"].ToString();						// Ｍ１スキャンコード
					f01m1VO.M1iro_nm = rec["IRO_NM"].ToString();						// Ｍ１色
					f01m1VO.M1size_nm = rec["SIZE_NM"].ToString();						// Ｍ１サイズ
					f01m1VO.M1genbaika_tnk = rec["JODAI1_TNK"].ToString();				// Ｍ１現売価
					f01m1VO.M1hyokason_su = rec["HYOKASON_SU"].ToString();				// Ｍ１数量
					f01m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();						// Ｍ１原単価

					//Ｍ１原価金額
					f01m1VO.M1haibun_kin = (int.Parse(f01m1VO.M1hyokason_su) * int.Parse(f01m1VO.M1gen_tnk)).ToString();

					f01m1VO.M1nyuryoku_ymd = BoSystemFormat.formatDate_yyMMdd(rec["ADD_YMD"].ToString());	// Ｍ１入力日
					f01m1VO.M1apply_ymd = BoSystemFormat.formatDate_yyMMdd(rec["APPLY_YMD"].ToString());	// Ｍ１申請日
					f01m1VO.M1nyuryokusha_cd = rec["ADDTAN_CD"].ToString();					// Ｍ１入力者コード
					f01m1VO.M1sinseisya_cd = rec["UPD_TANCD"].ToString();					// Ｍ１申請者コード
					f01m1VO.M1hyokasonsyubetsu_kb = rec["HYOKASONSYUBETSU_NM"].ToString();	// Ｍ１評価損種別区分

					// Ｍ１評価損理由
					// 識別コード＝"HKRY"、名称コード＝[評価損申請TBL].[評価損理由区分]をキーに検索した名称名と、
					// [評価損申請TBL].[評価損理由]を結合して表示。
					// ※ただし、[評価損理由区分]が[その他]の場合は、[評価損理由]のみ表示する。
					if (rec["HYOKASONRIYU_KB"].ToString().Equals(ConditionHyokason_riyiu.VALUE_HYOKASON_RIYIU13))
					{
						f01m1VO.M1hyokasonriyu = rec["HYOKASONRIYU"].ToString();
					}
					else
					{
						f01m1VO.M1hyokasonriyu = rec["HYOKASONRIYU_NM"].ToString() + " " + rec["HYOKASONRIYU"].ToString();
					}
					
					f01m1VO.M1kyakkariyu_kb = rec["KYAKKARIYU_NM"].ToString();				// Ｍ１却下理由区分
					f01m1VO.M1kyakkariyu = string.Empty;									// Ｍ１却下理由
					f01m1VO.M1syonin_flg = BoSystemConstant.CHECKBOX_OFF;					// Ｍ１承認
					f01m1VO.M1kyakka_flg = BoSystemConstant.CHECKBOX_OFF;					// Ｍ１却下
					f01m1VO.M1selectorcheckbox= BoSystemConstant.CHECKBOX_OFF;				// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg	 =ConditionKakuteisyori_flg.VALUE_NASI;			// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;				// Ｍ１明細色区分(隠し)

					// 更新用、排他用に以下の項目をDictionaryに保持する。
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_UPD_YMD, rec["UPD_YMD"].ToString());							// [Ｍ１更新日] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_UPD_TM, rec["UPD_TM"].ToString());								// [Ｍ１更新時間] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_KANRI_NO, rec["KANRI_NO"].ToString());							// [Ｍ１管理№] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_SYORI_YMD, rec["SYORI_YMD"].ToString());						// [Ｍ１処理日付] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_SYORI_TM, rec["SYORI_TM"].ToString());							// [Ｍ１処理時間] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_GYO_NBR, rec["GYO_NBR"].ToString());							// [Ｍ１行№] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_BURANDO_CD, rec["BURANDO_CD"].ToString());						// [Ｍ１ブランドコード] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_IRO_CD, rec["IRO_CD"].ToString());								// [Ｍ１色コード] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_SIZE_CD, rec["SIZE_CD"].ToString());							// [Ｍ１サイズコード] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_SYOHIN_CD, rec["SYOHIN_CD"].ToString());						// [Ｍ１商品コード] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_TYOTATSU_KB, rec["TYOTATSU_KB"].ToString());					// [Ｍ１調達区分] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_HYOKASONSYUBETSU_KB_WK, rec["HYOKASONSYUBETSU_KB"].ToString());	// [Ｍ１評価損種別区分_編集] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_HYOKASONRIYU_KB, rec["HYOKASONRIYU_KB"].ToString());			// [Ｍ１評価損理由区分] 
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_HYOKASONRIYU_WK, rec["HYOKASONRIYU"].ToString());				// [Ｍ１評価損理由_編集]
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_M1APPLY_YMD, rec["APPLY_YMD"].ToString());						// M1申請日(yyyymmdd
					f01m1VO.Dictionary.Add(Tk030p01Constant.DIC_TENPO_CD, rec["TENPO_CD"].ToString());							// [Ｍ１店舗コード] 

					// ツールチップ用にDictionaryに設定
					f01m1VO.Dictionary[Tk030p01Constant.DIC_TENPO_NM] = rec["TENPO_NM"].ToString();
					f01m1VO.Dictionary[Tk030p01Constant.DIC_BUMONKANA_NM] = rec["BUMONKANA"].ToString();
					f01m1VO.Dictionary[Tk030p01Constant.DIC_HINSYU_RYAKU_NM] = rec["HINSYU_RYAKU_NM"].ToString();

					#region フッタ部計算
					// 合計数量
					dSumSu += (Convert.ToDecimal(f01m1VO.M1hyokason_su));

					// 原価金額合計
					dSumGenTnk += (Convert.ToDecimal(f01m1VO.M1haibun_kin));
					#endregion

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}
				#endregion

				// 合計数量の設定
				f01VO.Gokei_suryo = dSumSu.ToString();

				// 原価金額合計の設定
				f01VO.Haibun_kin_gokei = dSumGenTnk.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);
				f01VO.Dictionary.Add(Tk030p01Constant.DIC_SYSDATE, sysDateVO.Sysdate.ToString());

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
