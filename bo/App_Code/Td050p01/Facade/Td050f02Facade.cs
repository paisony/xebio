using com.xebio.bo.Td050p01.Constant;
using com.xebio.bo.Td050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Td050p01.Facade
{
  /// <summary>
  /// Td050f02のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Td050f02Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Td050p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Td050f02";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td050f02Facade()
			: base()
		{
		}
		#endregion

		#region Td050f02画面データを作成する。
		/// <summary>
		/// Td050f02画面データを作成する。
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
			//	Td050f02Form td050f02Form = (Td050f02Form)facadeContext.FormVO;
				
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

		#region 行数チェック
		/// <summary>
		/// ChkRowCount 行数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void ChkRowCount ( IFacadeContext facadeContext, IDataList m1List )
		{
			// UPD_STR チェック削除 -------------------------------------------
			//int inputflg = 0;
			//foreach (Td050f02M1Form f02m1VO in m1List.ListData)
			//if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
			//{
			//	inputflg = 1;
			//	break;
			//}
			//if (inputflg == 0)
			//{
			//	// 登録データがありません。
			//	ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
			//}
			// DEL_END チェック削除 -------------------------------------------
		}
		#endregion
		#region 更新単項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Td050f02Form">f02VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="Td050f01M1Form">f01M1Form</param>
		/// <returns>Decimal</returns>
		private decimal[] ChkUpdSingleItem ( IFacadeContext facadeContext, Td050f02Form f02VO, IDataList m1List,Td050f01M1Form f01M1Form)
		{
			decimal dSumSu = 0;		// 合計数量
			decimal dSumKin = 0;	// 合計金額
			decimal[] dRet = null;
			#region 単項目チェック
			int iCnt = 0;
			foreach (Td050f02M1Form f02m1VO in m1List.ListData)
			{
				Boolean meisaiErr = false;
				// スキャンコードが入力されている場合
				if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
				{
					#region １．Ｍ１スキャンコード
					// 発注MSTに存在しない場合、エラー

					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f02m1VO.M1scan_cd,		// スキャンコード
						f02VO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						string.Empty,			// 指示NO（移動出荷マニュアル、返品マニュアル用）
						string.Empty,			// 出荷会社コード（移動出荷マニュアル)
						string.Empty,			// 入荷会社コード（移動出荷マニュアル)
						string.Empty			// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);

					Hashtable syohinData = V01004Check.CheckScanCd(
														searchConditionVO,
														facadeContext,
														"スキャンコード",
														new[] { "M1scan_cd" },
														f02m1VO.M1rowno,
														iCnt.ToString(),
														"M1",
														m1List.DispRow
												);
					if (syohinData != null)
					{
						// 発注マスタ検索値をフォームビーン再設定
						f02m1VO.M1hinsyu_ryaku_nm = (string)syohinData["HINSYU_RYAKU_NM"];	// 品種名
						f02m1VO.M1jisya_hbn = (string)syohinData["XEBIO_CD"];				// 自社品番
						f02m1VO.M1maker_hbn = (string)syohinData["HIN_NBR"];				// メーカー品番
						f02m1VO.M1syonmk = (string)syohinData["SYONMK"];					// 商品名
						f02m1VO.M1iro_nm = (string)syohinData["IRO_NM"];					// 色
						f02m1VO.M1size_nm = (string)syohinData["SIZE_NM"];					// サイズ
						f02m1VO.M1scan_cd = (string)syohinData["JAN_CD"];					// スキャンコード
						f02m1VO.M1gen_tnk = ((decimal)syohinData["GENKA"]).ToString();		// 原単価
						Decimal wkSuryo = Decimal.Zero;
						if (String.Empty.Equals(f02m1VO.M1teisei_suryo))
						{
							wkSuryo = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kakutei_su, "0"));
						}
						else
						{
							wkSuryo = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1teisei_suryo, "0"));
						}

						Decimal genkakin = (decimal)syohinData["GENKA"] * wkSuryo;
						f02m1VO.M1genka_kin = genkakin.ToString();							// 原価金額

						f02m1VO.Dictionary[Td050p01Constant.DIC_M1HINSYU_CD] = ((decimal)syohinData["HINSYU_CD"]).ToString();	// 品種コード
						f02m1VO.Dictionary[Td050p01Constant.DIC_M1IRO_CD] = (string)syohinData["MAKERCOLOR_CD"];				// 色コード
						f02m1VO.Dictionary[Td050p01Constant.DIC_M1SIZE_CD] = (string)syohinData["SIZE_CD"];						// サイズコード
						f02m1VO.Dictionary[Td050p01Constant.DIC_M1SYOHIN_CD] = (string)syohinData["SYOHIN_CD"];					// 商品コード
						dSumSu += wkSuryo;													// 合計訂正数量
						dSumKin += genkakin;												// 合計金額
					}
					else
					{
						meisaiErr = true;
					}

					#region ２．Ｍ１スキャンコード
					if (!meisaiErr)
					{
						// 原価がマイナスの場合、エラー
						if (Convert.ToDecimal(f02m1VO.M1gen_tnk) < 0)
						{
							meisaiErr = true;
							ErrMsgCls.AddErrMsg("E146", String.Empty, facadeContext, new[] { "M1scan_cd" }
								, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
														
						}
					}
					#endregion
					#region ３．Ｍ１スキャンコード
					if (!meisaiErr)
					{
						// 返品理由が本部指示の場合
						if (ConditionHenpin_riyu_kbn.VALUE_HENPIN_RIYU_KBN1.Equals((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1HENPIN_RIYU]))
						{
							//// 返品指示存在チェック
							if (HenpinShijiCHk(facadeContext, f02VO.Head_tenpo_cd, f02VO.Siji_bango, f02m1VO.M1scan_cd, f02m1VO.M1rowno, iCnt, m1List.DispRow))
							{
								// エラー
								meisaiErr = true;
							}
						}
					}
					#endregion
					#region ４．Ｍ１スキャンコード
					if (!meisaiErr)
					{
						// 修正前のＭ１スキャンコードの自社品番と異なる自社品番のスキャンコードの場合
						if (!BoSystemString.Nvl((string)f02m1VO.Dictionary[Td050p01Constant.DIC_M1JISYA_HBN]).Equals(f02m1VO.M1jisya_hbn))
						{
							meisaiErr = true;
							ErrMsgCls.AddErrMsg("E184", String.Empty, facadeContext, new[] { "M1scan_cd" }
								, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						}
					}
					#endregion
					#endregion
				}
				else
				{
					dSumKin += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genka_kin, "0"));			// 合計金額

				}
				iCnt++;
			}
			#endregion
			#region 関連項目チェック
			#region １．Ｍ１訂正数量
			if (dSumSu > 99999999)
			{
				ErrMsgCls.AddErrMsg("E102", "合計訂正数", facadeContext);

			}
			#endregion
			#region ２．Ｍ１訂正数量
			if (dSumKin > 999999999)
			{
				ErrMsgCls.AddErrMsg("E102", "合計原価金額", facadeContext);

			}
			#endregion
			#endregion
			dRet = new decimal[] { dSumSu, dSumKin };
			return dRet;
		}
		#endregion
		#region 排他チェック
		/// <summary>
		/// ChkUpdHaita 排他チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Td050f02Form">f02VO</param>
		/// <param name="Td050f01M1Form">f01M1Form</param>
		/// <returns></returns>
		private void ChkUpdHaita ( IFacadeContext facadeContext, Td050f02Form f02VO, Td050f01M1Form f01M1Form )
		{
			#region 排他チェック

			



			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
			sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");
			sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");

			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();

			// 店舗コード
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 伝票番号
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_DENPYO_BANGO";
			if (string.IsNullOrEmpty((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1KURODENPYO_BANGO]))
			{
				bindVO.Value = BoSystemFormat.formatDenpyoNo(f02VO.Denpyo_bango);
			}
			else
			{
				bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1KURODENPYO_BANGO]);
			}
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 処理日付
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYORI_YMD";
			bindVO.Value = (string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);


			// 排他チェック
			V03003Check.CheckHaitaMaxVal(
					Convert.ToDecimal((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1UPD_YMD]),
					Convert.ToDecimal((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1UPD_TM]),
					facadeContext,
					"MDRT0020",
					sRepSql.ToString(),
					bindList,
					1
			);
			#endregion
		}
		#endregion

		#region 返品指示存在チェックを行う。(SQL_ID_09)
		/// <summary>
		/// 返品指示存在チェックを行う
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>チェック結果（true:エラー、false：エラーなし）</returns>
		public static Boolean HenpinShijiCHk ( IFacadeContext facadeContext
											, String tenpo_cd
											, String siji_bango
											, String scan_cd
											, String rowno
											, int iCntPara
											, int DispRow
			)
		{
			Boolean blRet = false;
			// 返品指示存在チェック
			FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_09, facadeContext.DBContext);
			// 店舗コードのバインド
			rtChk.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(tenpo_cd));
			// 指示番号のバインド
			rtChk.BindValue("BIND_SIJI_BANGO", Convert.ToDecimal(BoSystemString.Nvl(siji_bango, "0")));
			// スキャンコードのバインド
			rtChk.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(scan_cd));
			//検索結果を取得します
			rtChk.CreateDbCommand();
			IList<Hashtable> tableListcnt = rtChk.Execute();
			Hashtable resultTbl = tableListcnt[0];
			Decimal dCnt = (Decimal)resultTbl["CNT"];
			if (tableListcnt == null || tableListcnt.Count <= 0)
			{
				// エラー
				blRet = true;
				ErrMsgCls.AddErrMsg("E149", String.Empty, facadeContext, new[] { "M1scan_cd" }
								, rowno, iCntPara.ToString(), "M1", DispRow);
			}
			else
			{
				// 0件チェック
				if (dCnt <= 0)
				{
					blRet = true;
					ErrMsgCls.AddErrMsg("E149", String.Empty, facadeContext, new[] { "M1scan_cd" }
								, rowno, iCntPara.ToString(), "M1", DispRow);
				}
			}
			return blRet;
		}
		#endregion
		#region [返品確定TBL(B)]を検索し、[返品確定TBL(B)]を登録する。(SQL_ID_10)
		/// <summary>
		/// [返品確定TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno_sel">伝票番号</param>
		/// <param name="dDenno">伝票番号（採番）</param>
		/// <returns>更新件数</returns>
		public static int Ins_HenpinKakuteib_sel ( IFacadeContext facadeContext,
									Td050f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									decimal dDenban_sel,
									decimal dDenban )
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_10, facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_INS", dDenban);
			reader.BindValue("BIND_DENPYO_BANGO", dDenban_sel);
			// 処理日
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion
		#region [返品確定TBL(H)]を検索し、[返品確定TBL(H)]を登録する。(SQL_ID_11)
		/// <summary>
		/// [返品確定TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="shinkuro_flg">新黒フラグ true:新黒,false:新黒以外</param>
		/// <param name="akakuro_flg">赤黒フラグ(true:赤,false:黒)</param>
		/// <param name="biko">備考</param>
		/// <param name="dDenno_sel">伝票番号</param>
		/// <param name="dDenno">伝票番号（採番）</param>
		/// <returns>更新件数</returns>
		public static int Ins_HenpinKakuteih_sel ( IFacadeContext facadeContext,
									Td050f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									Boolean shinkuro_flg,
									Boolean akakuro_flg,
									String biko,
									decimal dDenban_sel,
									decimal dDenban )
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_INS", dDenban);
			reader.BindValue("BIND_DENPYO_BANGO", dDenban_sel);
			// 確定種別
			// Dictionary.[Ｍ１確定種別]が、0（通常）の場合は2（通常訂正）、1（ﾏﾆｭｱﾙ返品）の場合は3（ﾏﾆｭｱﾙ訂正）、それ以外の場合はDictionary.[Ｍ１確定種別]を設定する。
			String strKakutei_sb = (string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1KAKUTEI_SB];
			if (BoSystemConstant.KAKUTEI_SB_HENPIN_TSUJO.Equals(strKakutei_sb))
			{
				strKakutei_sb = BoSystemConstant.KAKUTEI_SB_HENPIN_TSUJO_TEISEI;
			}
			else if (BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL.Equals(strKakutei_sb))
			{
				strKakutei_sb = BoSystemConstant.KAKUTEI_SB_HENPIN_MANUAL_TEISEI;
			}
			reader.BindValue("BIND_KAKUTEI_SB", Convert.ToDecimal(BoSystemString.Nvl(strKakutei_sb, "0")));
			// 新黒フラグ
			decimal dShinkuro = 0;
			if (shinkuro_flg)
			{
				dShinkuro = Convert.ToDecimal(BoSystemConstant.SHINKURO_FLG_SHINKURO);
			}
			else
			{
				dShinkuro = Convert.ToDecimal(BoSystemConstant.SHINKURO_FLG_NOT_SHINKURO);
			}
			reader.BindValue("BIND_SHINKURO_FLG", dShinkuro);
			// 備考
			reader.BindValue("BIND_BIKO", biko);
			// 赤黒区分
			decimal dAkakuro = 0;
			if (akakuro_flg)
			{
				dAkakuro = Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_AKA);
			}
			else
			{
				dAkakuro = Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_KURO);
			}
			reader.BindValue("BIND_AKAKURO_KBN", dAkakuro);
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// 処理日
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion
		#region [返品確定TBL(H)]を登録する。(SQL_ID_12)
		/// <summary>
		/// [返品確定TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="f02VO">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		public static int Ins_HenpinKakuteih ( IFacadeContext facadeContext,
									Td050f01M1Form f01M1Form,
									Td050f02Form f02VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									decimal motoDenno,
									decimal dDenno )
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_TM], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));
			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1KANRI_NO], "0")));
			// 確定種別
			decimal dKakutei_sb = Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1KAKUTEI_SB], "0"));
			reader.BindValue("BIND_KAKUTEI_SB", dKakutei_sb);
			reader.BindValue("BIND_KAKUTEI_SB2", dKakutei_sb);
			// 返品日
			reader.BindValue("BIND_HENPIN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02VO.Henpin_kakutei_ymd)));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f02VO.Bumon_cd));
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1BURANDO_CD]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f02VO.Siiresaki_cd));
			// サブ仕入先コード
			reader.BindValue("BIND_SUBSIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SUBSIIRESAKI_CD]));
			// 返品予定合計数量
			reader.BindValue("BIND_YOTEIGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1HENPINYOTEIGOKEI_SU], "0")));
			// 返品予定合計金額
			reader.BindValue("BIND_YOTEIGOUKEI_KIN", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1HENPINYOTEIGOUKEI_KIN], "0")));
			// 返品実績合計数量
			reader.BindValue("BIND_JISSEKIGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl(f02VO.Gokeiteisei_suryo, "0")));
			// 返品実績合計原価金額
			reader.BindValue("BIND_JISSEKIGOUKEI_KIN", Convert.ToDecimal(BoSystemString.Nvl(f02VO.Genka_kin_gokei, "0")));
			// 指示番号
			reader.BindValue("BIND_SIJI_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f02VO.Siji_bango, "0")));
			// 返品理由
			reader.BindValue("BIND_HENPIN_RIYU", Convert.ToDecimal((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1HENPIN_RIYU]));
			// 担当者コード
			reader.BindValue("BIND_TANTOSYA_CD", BoSystemFormat.formatTantoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TANTOSYA_CD]));
			// 備考
			reader.BindValue("BIND_BIKO", f02VO.Biko);
			// 元伝票番号
			//reader.BindValue("BIND_MOTODENPYO_BANGO", BoSystemFormat.formatDenpyoNo(f02VO.Denpyo_bango));
			reader.BindValue("BIND_MOTODENPYO_BANGO", motoDenno);
			// HHT登録日
			reader.BindValue("BIND_HHTADD_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02VO.Add_ymd)));
			// HHT登録担当者コード
			reader.BindValue("BIND_HHTADDTAN_CD", BoSystemFormat.formatTantoCd(f02VO.Nyuryokutan_cd));
			// 新黒フラグ
			reader.BindValue("BIND_SHINKURO_FLG", Convert.ToDecimal(BoSystemConstant.SHINKURO_FLG_SHINKURO));		// 1（新黒）
			// 赤黒区分
			reader.BindValue("BIND_AKAKURO_KBN", Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_KURO));				// 0（黒伝）
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
			reader.BindValue("BIND_SAKUJYO_FLG", Td050p01Constant.FLG_OFF);						// 0（なし）
			// 送信依頼フラグ
			reader.BindValue("BIND_SOSINIRAI_FLG", Convert.ToDecimal(ConditionSosinirai_flg.VALUE_ARI));			// 1（送信対象）
			// 送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", Convert.ToDecimal(ConditionSosinzumi_flg.VALUE_MISOSIN));		// 0（未送信）
			// 送信日
			reader.BindValue("BIND_SOSIN_YMD", 0);
			// 送信時間
			reader.BindValue("BIND_SOSIN_TM", 0);
			// HHTシリアル番号
			reader.BindValue("BIND_HHTSERIAL_NO", (string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1HHTSERIAL_NO]);
			// HHTシーケンスNo.
			reader.BindValue("BIND_HHTSEQUENCE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1HHTSEQUENCE_NO], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#region [返品確定TBL(B)]を登録する。(SQL_ID_13)
		/// <summary>
		/// [返品確定TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="f02VO">明細画面のVO</param>
		/// <param name="f02VO">明細画面の一覧VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		public static int Ins_HenpinKakuteib ( IFacadeContext facadeContext,
									Td050f01M1Form f01M1Form,
									Td050f02Form f02VO,
									Td050f02M1Form f02m1VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									decimal dDenno )
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));	// 返品伝票訂正-一覧(Dictionary)．Ｍ１処理日付
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_TM], "0")));	// 返品伝票訂正-一覧(Dictionary)．Ｍ１処理時間
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));					// 返品伝票訂正-明細．ヘッダ店舗コード
			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1KANRI_NO], "0")));	// 返品伝票訂正-一覧(Dictionary)．Ｍ１管理№
			// 伝票行№
			reader.BindValue("BIND_DENPYOGYO_NO", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1rowno, "0")));												// 返品伝票訂正-明細．Ｍ１行NO
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f02VO.Bumon_cd));																// 返品伝票訂正-明細．部門コード
			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(BoSystemString.Nvl((string)f02m1VO.Dictionary[Td050p01Constant.DIC_M1HINSYU_CD], "0")));	// 返品伝票訂正-明細(Dictionary)。Ｍ１品種コード
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1BURANDO_CD]));				// 返品伝票訂正-一覧(Dictionary)	。Ｍ１ブランドコード
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));															// 返品伝票訂正-明細	。Ｍ１自社品番
			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f02m1VO.M1maker_hbn);																						// 返品伝票訂正-明細。Ｍ１メーカー品番
			// 商品名(カナ)	
			reader.BindValue("BIND_SYONMK", f02m1VO.M1syonmk);																								// 返品伝票訂正-明細。Ｍ１商品名(カナ)									
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f02m1VO.Dictionary[Td050p01Constant.DIC_M1IRO_CD]));							// 返品伝票訂正-明細(Dictionary)。Ｍ１色コード
			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd((string)f02m1VO.Dictionary[Td050p01Constant.DIC_M1SIZE_CD]));						// 返品伝票訂正-明細(Dictionary)。Ｍ１サイズコード	
			// サイズ
			reader.BindValue("BIND_SIZE_NM", f02m1VO.M1size_nm);																							// 返品伝票訂正-明細。Ｍ１サイズ
			// ＪＡＮコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd));																	// 返品伝票訂正-明細。Ｍ１スキャンコード	
			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", BoSystemString.Nvl((string)f02m1VO.Dictionary[Td050p01Constant.DIC_M1SYOHIN_CD], "0"));						// 返品伝票訂正-明細(Dictionary)。Ｍ１商品コード	
			// 返品予定数
			reader.BindValue("BIND_HENPINYOTEI_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1yotei_su, "0")));										// 返品伝票訂正-明細。Ｍ１予定数量
			// 返品実績数
			decimal dHenpinjisseki = decimal.Zero;
			// [Ｍ１訂正数量]が未入力の場合
			if (String.Empty.Equals(f02m1VO.M1teisei_suryo))
			{
				dHenpinjisseki = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1kakutei_su, "0"));								// 返品伝票訂正-明細。Ｍ１確定数量
			}
			else
			{
				dHenpinjisseki = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1teisei_suryo, "0"));							// 返品伝票訂正-明細。Ｍ１訂正数量
			}
			reader.BindValue("BIND_HENPINJISSEKI_SU", dHenpinjisseki);
			// 原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0")));												// 返品伝票訂正-明細。Ｍ１原単価	
			// 指示番号
			reader.BindValue("BIND_SIJI_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f02VO.Siji_bango, "0")));												// 返品伝票訂正-明細。指示番号
			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
