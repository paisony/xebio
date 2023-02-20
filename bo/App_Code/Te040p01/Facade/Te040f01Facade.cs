using com.xebio.bo.Te040p01.Constant;
using com.xebio.bo.Te040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01023;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DateUtil;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01006;
using Common.Business.V01000.V01026;
using Common.Conditions;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Te040p01.Facade
{
  /// <summary>
  /// Te040f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Te040f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Te040p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Te040f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te040f01Facade()
			: base()
		{
		}
		#endregion

		#region Te040f01画面データを作成する。
		/// <summary>
		/// Te040f01画面データを作成する。
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
				Te040f01Form Te040f01Form = (Te040f01Form)facadeContext.FormVO;

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// 出荷理由に"店舗判断"を設定
				Te040f01Form.Shukkariyu_kbn = ConditionShukkariyu_kbn.VALUE_SHUKKARIYU_KBN2;
				// 会社コード
				Te040f01Form.Kaisya_cd = logininfo.CopCd;
				// 会社名称
				Te040f01Form.Kaisya_nm = "";
				Hashtable resultHash = new Hashtable();
				resultHash = V01006Check.CheckKaisya(Te040f01Form.Kaisya_cd, facadeContext);
				// 名称をラベルに設定
				if (resultHash != null)
				{
					Te040f01Form.Kaisya_nm = (string)resultHash["MEISYO_NM"];
				}
				// 出荷日
				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				Te040f01Form.Syukka_ymd = BoSystemFormat.formatDate(sysDateVO.Sysdate);
				// 防止期限日　営業日の1年後 -1日
				String wkStopYmd = BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).AddYears(+1).AddDays(-1).ToString("yyyyMMdd");
				Te040f01Form.Stop_ymd = wkStopYmd;
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
			#region 初期化

			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

			// FormVO取得
			// 画面より情報を取得する。
			Te040f01Form f01VO = (Te040f01Form)facadeContext.FormVO;
			IDataList m1List = f01VO.GetList("M1");

			// 一覧の初期化
			m1List.ClearCacheData();
			m1List.Clear();
			// 検索条件を初期化
			SearchConditionSaveCls.SearchConditionRemove(f01VO);

			#endregion
			#region ページ追加
			// 初期値設定
			Hashtable defVal = new Hashtable();

			// ページを追加
			AddRowCls.AddEmptyRow<Te040f01M1Form>("M1", "M1rowno", (Te040f01Form)facadeContext.FormVO, m1List.DispRow, defVal);
			SetPageIndex(m1List, m1List.DispRow);
			#endregion
			
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
		#region 転記処理(発注マスタ)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="Hashtable">取得情報</param>
		/// <param name="string">店舗コード</param>
		/// <param name="bool">サイズ選択フラグ</param>
		/// <returns></returns>
		public void DoShohinCopy ( Te040f01M1Form f01m1VO, Hashtable syohinData, string TenpoCd, bool blSize )
		{
			// 発注マスタ検索値をフォームビーン再設定
			f01m1VO.M1bumon_cd = syohinData["BUMON_CD"].ToString();													// Ｍ１部門コード
			f01m1VO.M1bumonkana_nm = syohinData["BUMONKANA_NM"].ToString();											// Ｍ１部門カナ名
			f01m1VO.M1hinsyu_ryaku_nm = syohinData["HINSYU_RYAKU_NM"].ToString();									// Ｍ１品種略名称
			f01m1VO.M1burando_nm = syohinData["BURANDO_NMK"].ToString();											// Ｍ１ブランド名
			f01m1VO.M1jisya_hbn = syohinData["XEBIO_CD"].ToString();												// Ｍ１自社品番
			f01m1VO.M1maker_hbn = syohinData["HIN_NBR"].ToString();													// Ｍ１メーカー品番
			f01m1VO.M1syonmk = syohinData["SYONMK"].ToString();														// Ｍ１商品名(カナ)
			f01m1VO.M1iro_nm = syohinData["IRO_NM"].ToString();														// Ｍ１色
			f01m1VO.M1size_nm = syohinData["SIZE_NM"].ToString();													// Ｍ１サイズ
			f01m1VO.M1scan_cd = syohinData["JAN_CD"].ToString();													// Ｍ１スキャンコード
			f01m1VO.M1gen_tnk = syohinData["GENKA"].ToString();														// Ｍ１原単価

			// 更新用
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1TENPO_CD] = TenpoCd;												// 店舗コード
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1HINSYU_CD] = syohinData["HINSYU_CD"].ToString();					// 品種コード
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1BURANDO_CD] = syohinData["BURANDO_CD"].ToString();				// ブランドコード
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1IRO_CD] = syohinData["MAKERCOLOR_CD"].ToString();					// 色コード
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1SIZE_CD] = syohinData["SIZE_CD"].ToString();						// サイズコード
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1SYOHIN_CD] = syohinData["SYOHIN_CD"].ToString();					// 商品コード
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1SIIRESAKI_CD] = syohinData["SIIRESAKI_CD"].ToString();			// 仕入先コード
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1SYOHINGUN1_CD] = syohinData["SYOHINGUN1_CD"].ToString();			// 商品群１コード
			f01m1VO.Dictionary[Te040p01Constant.DIC_M1HYOKA_TNK] = syohinData["HYOKA_TNK"].ToString();					// 評価単価
			// サイズ選択戻り及びＣＳＶ取込戻り時
			if (blSize)
			{
				f01m1VO.M1syukka_su = syohinData[OpenTm040p01Cls.COLUMN_INPUT_SURYO].ToString();					// Ｍ１出荷数量

				f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
				f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;										// Ｍ１確定処理フラグ(隠し)
				f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;											// Ｍ１明細色区分(隠し)
			}
		}
		#endregion
		#region 合計計算処理
		/// <summary>
		/// SumGoukeiDetail 合計計算処理
		/// </summary>
		/// <param name="Te040f01Form">f02VO</param>
		/// <returns></returns>
		public void SumGoukeiDetail ( Te040f01Form f02VO )
		{
			decimal dSumSu = 0;		// 合計数量
			decimal dSumKin = 0;	// 合計金額

			foreach (Te040f01M1Form f01m1VO in f02VO.GetList("M1").ListData)
			{
				dSumSu += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1syukka_su, "0"));					// 合計数量
				dSumKin += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1genka_kin, "0"));					// 合計金額
			}
			f02VO.Syukkasuryo_gokei = dSumSu.ToString();
			f02VO.Genka_kin_gokei = dSumKin.ToString();
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
			foreach (Te040f01M1Form f01m1VO in m1List.ListData)
			{
				// スキャンコードが入力されている場合
				if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd.Trim()))
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
		/// <param name="Te040f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void ChkUpdSingleItem ( IFacadeContext facadeContext, Te040f01Form f01VO, IDataList m1List, SysDateVO sysDateVO )
		{
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			// システム日付の5年後を取得
			decimal dFiveYear = Convert.ToDecimal(BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).AddYears(5).ToString("yyyyMMdd"));
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
					// 1-2 ヘッダ店舗コード
					//     LC物流店舗コードが入力された場合エラー
					// 存在チェックにて取得した店舗MST.[店舗形態区分] = 2（LC） の場合、エラー 
					if (Te040p01Constant.TENPOKEITAI_KB_LC.Equals(resultHash["TENPOKEITAI_KB"].ToString()))
					{
						ErrMsgCls.AddErrMsg("E257", string.Empty, facadeContext, new[] { "Head_tenpo_cd" });
					}

				}
			}
			// 1-3 会社コード
			//       名称マスタ（識別コード＝'KASY'）を検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Kaisya_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01006Check.CheckKaisya(f01VO.Kaisya_cd, facadeContext, "会社", new[] { "Kaisya_cd" });
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Kaisya_nm = (string)resultHash["MEISYO_NM"];
				}
			}
			// 1-4 入荷店コード
			//     店舗コードと同一店舗が入力された場合エラー
			if (!string.IsNullOrEmpty(f01VO.Jyuryoten_cd))
			{
				if (f01VO.Jyuryoten_cd.Equals(f01VO.Head_tenpo_cd))
				{
					ErrMsgCls.AddErrMsg("E161", string.Empty, facadeContext, new[] { "Jyuryoten_cd" });
				}
			}
			// 1-5 入荷店コード
			//       店舗マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Jyuryoten_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01026Check.CheckTenpoAll(f01VO.Kaisya_cd, f01VO.Jyuryoten_cd, facadeContext, "入荷店", new[] { "Jyuryoten_cd" });
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Juryoten_nm = (string)resultHash["TENPO_NM"];
					// 1-6 入荷店コード
					//     LC物流店舗コードが入力された場合エラー
					// 存在チェックにて取得した店舗MST.[店舗形態区分] = 2（LC） の場合、エラー 
					if (Te040p01Constant.TENPOKEITAI_KB_LC.Equals(resultHash["TENPOKEITAI_KB"].ToString()))
					{
						ErrMsgCls.AddErrMsg("E125", string.Empty, facadeContext, new[] { "Jyuryoten_cd" });
					}
				}
			}
			// 1-7 防止期限
			//     過去日付の場合、エラー
			if (Convert.ToDecimal(BoSystemFormat.formatDate(f01VO.Stop_ymd)) < sysDateVO.Sysdate)
			{
				ErrMsgCls.AddErrMsg("E105", "防止期限", facadeContext, new[] { "M1stop_ymd" });
			}
			// 1-8 防止期限
			//     防止期限が5年以上未来の場合、エラー
			if (Convert.ToDecimal(BoSystemFormat.formatDate(f01VO.Stop_ymd)) >= dFiveYear)
			{
				ErrMsgCls.AddErrMsg("E187", string.Empty, facadeContext, new[] { "M1stop_ymd" });
			}
		}
		#endregion
		#region 更新単項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te040f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void ChkUpdSingleItemDetail ( IFacadeContext facadeContext, Te040f01Form f01VO, IDataList m1List, SysDateVO sysDateVO )
		{
			decimal dSumSu = 0;		// 合計数量
			decimal dSumKin = 0;	// 合計金額
			int iCnt = 0;
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

			foreach (Te040f01M1Form f01m1VO in m1List.ListData)
			{
				bool meisaiErr = false;
				// スキャンコードが入力されている場合
				if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd.Trim()))
				{
					string checkJanCd = string.Empty;			// チェック用ＪＡＮコード
					decimal checkShukkaGenkaKin = decimal.Zero;	// チェック用出荷原価金額
					decimal checkNyukaGenkaKin = decimal.Zero;	// チェック用入荷原価金額

					#region Ｍ１スキャンコード
					// 発注MSTに存在しない場合、エラー
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01m1VO.M1scan_cd,		// スキャンコード
						f01VO.Head_tenpo_cd,	// 店舗コード
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
														f01m1VO.M1rowno,
														iCnt.ToString(),
														"M1",
														m1List.DispRow
												);
					if (syohinData != null)
					{
						// 発注マスタ情報設定
						DoShohinCopy(f01m1VO, syohinData, f01VO.Head_tenpo_cd, false);

						Decimal wkSuryo = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1syukka_su, "0"));
						Decimal genkakin = (decimal)syohinData["GENKA"] * wkSuryo;
						f01m1VO.M1genka_kin = genkakin.ToString();							// 原価金額

						dSumSu += wkSuryo;													// 合計数量
						dSumKin += genkakin;												// 合計金額

						// チェック用ＪＡＮコード設定
						checkJanCd = syohinData["JAN_CD"].ToString();
						// チェック用出荷原価金額設定
						checkShukkaGenkaKin = genkakin;
					}
					else
					{
						meisaiErr = true;
					}
					// 画面の会社コードが他社の場合、他社の発注マスタに存在しなければエラー
					decimal nyukaKaishaCd = Convert.ToDecimal(BoSystemString.Nvl(f01VO.Kaisya_cd, "0"));
					decimal shukkaKaishaCd = Convert.ToDecimal(BoSystemString.Nvl(logininfo.CopCd, "0"));
					if (!meisaiErr
						&& nyukaKaishaCd != shukkaKaishaCd)
					{
						// 他社の発注MST取得
						FindSqlResultTable stmt = FindSqlUtil.CreateFindSqlResultTable(Te040p01Constant.SQL_ID_01, facadeContext.DBContext);

						// ＪＡＮコードのバインド
						stmt.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(checkJanCd));

						// テーブルIDのリプレイス
						StringBuilder repSql = new StringBuilder("MDMT0130_").Append(nyukaKaishaCd).Append(" M1");
						BoSystemSql.AddSql(stmt, Te040p01Constant.REP_TABLE_ID, repSql.ToString());

						//検索結果を取得します
						stmt.CreateDbCommand();
						IList<Hashtable> hatchuInfo = stmt.Execute();

						if (hatchuInfo != null
							&& hatchuInfo.Count > 0)
						{
							// 取得できた場合
							Hashtable syohinDataEtc = hatchuInfo[0];

							Decimal wkSuryo = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1syukka_su, "0"));
							Decimal genkakin = (decimal)syohinDataEtc["GENKA"] * wkSuryo;

							// チェック用入荷原価金額設定
							checkNyukaGenkaKin = genkakin;
						}
						else
						{
							// 存在しない場合
							ErrMsgCls.AddErrMsg("E168", string.Empty, facadeContext, new[] { "M1scan_cd" }
									, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							meisaiErr = true;
						}
					}
					#endregion
					#region Ｍ１出荷数量
					// 出荷数量が未入力の場合、エラー
					if (string.IsNullOrEmpty(f01m1VO.M1syukka_su))
					{
						ErrMsgCls.AddErrMsg("E121", "出荷数量", facadeContext, new[] { "M1syukka_su" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						meisaiErr = true;
					}
					else
					{
						// 0が入力された場合、エラー
						if ("0".Equals(f01m1VO.M1syukka_su))
						{
							ErrMsgCls.AddErrMsg("E103", "出荷数量", facadeContext, new[] { "M1syukka_su" }
									, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							meisaiErr = true;
						}
					}
					#endregion
					#region 金額オーバーフローチェック
					// 自社（出荷側）の[発注MST.原価]×[Ｍ１数量]＞999999999（９桁）の場合、エラー
					// （他社入力時）他社（入荷側）の[発注MST.原価]×[Ｍ１数量]＞999999999（９桁）の場合、エラー
					if (checkShukkaGenkaKin > 999999999m
						|| checkNyukaGenkaKin > 999999999m)
					{
						ErrMsgCls.AddErrMsg("E102", "原価金額", facadeContext, new[] { "M1syukka_su" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						meisaiErr = true;
					}
					#endregion
				}
				iCnt++;
			}
		}
		#endregion
		#region 更新警告チェック
		/// <summary>
		/// ChkSelSingleItem 更新警告チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te040f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <returns>bool(true:警告あり、false:警告なし)</returns>
		private bool ChkUpdWarn ( IFacadeContext facadeContext, Te040f01Form f01VO, IDataList m1List )
		{
			bool blWorn = false;
			#region 単項目チェック
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			int iCnt = 0;
			foreach (Te040f01M1Form f01m1VO in m1List.ListData)
			{
				// スキャンコードが入力されている場合
				if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd.Trim()))
				{
					if (!string.IsNullOrEmpty(f01m1VO.M1syukka_su))
					{
						// Ｍ１出荷数量
						//     4桁以上を入力した場合、警告を行う。
						if (f01m1VO.M1syukka_su.Length >= 4)
						{
							InfoMsgCls.AddWarnMsg("W103", String.Empty, facadeContext, new[] { "M1syukka_su" }
												, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							blWorn = true;
						}
					}
				}

				iCnt++;
			}
			#endregion
			return blWorn;
		}
		#endregion
		#region 移動指示理由を取得する。
		/// <summary>
		/// 移動指示理由を取得する。
		/// </summary>
		/// <returns>移動指示理由</returns>
		public static decimal GetSijiRiyu ( Te040f01Form f01VO)
		{
			decimal dRiyu = Convert.ToDecimal(Te040p01Constant.IDOU_SIJI_RIYU_DEF);

			// [出荷理由]="3"(店舗客注)の場合、[移動指示理由]="1"(客注)とする。
			if (ConditionShukkariyu_kbn.VALUE_SHUKKARIYU_KBN3.Equals(f01VO.Shukkariyu_kbn))
			{
				dRiyu = Convert.ToDecimal(Te040p01Constant.IDOU_SIJI_RIYU_CUSTORDER);
			}
			else
			{
				dRiyu = Convert.ToDecimal(Te040p01Constant.IDOU_SIJI_RIYU_DEF);
			}
			return dRiyu;
		}
		#endregion
		#region [移動出荷確定一時TBL]を登録する。
		/// <summary>
		/// [移動出荷確定一時TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TempTransfer ( IFacadeContext facadeContext, Te040f01Form f01VO, LoginInfoVO loginInfo, SysDateVO sysDateVO )
		{
			int iRownum = 0;
			IDataList m1List = f01VO.GetList("M1");

			// Oracleコマンドの生成
			OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
			// トランザクションの設定
			command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
			// SQLの実行タイプ
			command.CommandType = CommandType.Text;


			IList<Mdrt0011VO> insertBodyList = new List<Mdrt0011VO>();	// 更新データリスト

			// パラメータバインド処理
			IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();
			int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）

			// 移動指示理由取得
			decimal dSijiRiyu = GetSijiRiyu(f01VO);
			// 出荷日
			decimal dSyukkaYmd = Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f01VO.Syukka_ymd), "0"));
			// 出荷会社コード
			decimal dSyukkaKaisya = Convert.ToDecimal(BoSystemString.Nvl(loginInfo.CopCd, "0"));
			// 入荷会社コード
			decimal dJyuryoKaisya = Convert.ToDecimal(BoSystemString.Nvl(f01VO.Kaisya_cd, "0"));

			foreach (Te040f01M1Form f01m1VO in f01VO.GetList("M1").ListData)
			{
				// スキャンコードが入力されている行が対象
				if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd.Trim()))
				{
					counter++;
					iRownum++;

					Dictionary<string, string> bindDic = new Dictionary<string, string>();
					//  1.伝票番号
					BoSystemDb.setInsertVal("DENPYO_BANGO", iRownum.ToString(), "", ref bindDic, ref command);
					//  2.出荷日
					BoSystemDb.setInsertVal("SYUKKA_YMD", iRownum.ToString(), dSyukkaYmd, ref bindDic, ref command);
					//  3.出荷会社コード
					BoSystemDb.setInsertVal("SYUKKAKAISYA_CD", iRownum.ToString(), dSyukkaKaisya, ref bindDic, ref command);
					//  4.出荷店コード
					BoSystemDb.setInsertVal("SYUKKATEN_CD", iRownum.ToString(), BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd), ref bindDic, ref command);
					//  5.入荷会社コード
					BoSystemDb.setInsertVal("JYURYOKAISYA_CD", iRownum.ToString(), dJyuryoKaisya, ref bindDic, ref command);
					//  6.入荷店コード
					BoSystemDb.setInsertVal("JYURYOTEN_CD", iRownum.ToString(), BoSystemFormat.formatTenpoCd(f01VO.Jyuryoten_cd), ref bindDic, ref command);
					//  7.確定種別
					BoSystemDb.setInsertVal("KAKUTEI_SB", iRownum.ToString(), Te040p01Constant.KAKUTEI_SB_MANUAL, ref bindDic, ref command);
					//  8.登録日
					BoSystemDb.setInsertVal("ADD_YMD", iRownum.ToString(), sysDateVO.Sysdate, ref bindDic, ref command);
					//  9.登録時間
					BoSystemDb.setInsertVal("ADD_TM", iRownum.ToString(), sysDateVO.Systime_mili, ref bindDic, ref command);
					// 10.登録担当者コード
					BoSystemDb.setInsertVal("ADDTAN_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(loginInfo.TtsCd), ref bindDic, ref command);
					// 11.商品群1コード
					BoSystemDb.setInsertVal("SYOHINGUN1_CD", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.Dictionary[Te040p01Constant.DIC_M1SYOHINGUN1_CD].ToString(), "0")), ref bindDic, ref command);
					// 12.部門コード
					BoSystemDb.setInsertVal("BUMON_CD", iRownum.ToString(), BoSystemFormat.formatBumonCd(f01m1VO.M1bumon_cd), ref bindDic, ref command);
					// 13.品種コード
					BoSystemDb.setInsertVal("HINSYU_CD", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.Dictionary[Te040p01Constant.DIC_M1HINSYU_CD].ToString(), "0")), ref bindDic, ref command);
					// 14.ブランドコード
					BoSystemDb.setInsertVal("BURANDO_CD", iRownum.ToString(), BoSystemFormat.formatBrandCd(f01m1VO.Dictionary[Te040p01Constant.DIC_M1BURANDO_CD].ToString()), ref bindDic, ref command);
					// 15.メーカー品番
					BoSystemDb.setInsertVal("MAKER_HBN", iRownum.ToString(), f01m1VO.M1maker_hbn, ref bindDic, ref command);
					// 16.商品名(カナ)
					BoSystemDb.setInsertVal("SYONMK", iRownum.ToString(), f01m1VO.M1syonmk, ref bindDic, ref command);
					// 17.自社品番
					BoSystemDb.setInsertVal("JISYA_HBN", iRownum.ToString(), f01m1VO.M1jisya_hbn, ref bindDic, ref command);
					// 18.色コード
					BoSystemDb.setInsertVal("IRO_CD", iRownum.ToString(), BoSystemFormat.formatIroCd((string)f01m1VO.Dictionary[Te040p01Constant.DIC_M1IRO_CD]), ref bindDic, ref command);
					// 19.サイズコード
					BoSystemDb.setInsertVal("SIZE_CD", iRownum.ToString(), BoSystemFormat.formatSizeCd((string)f01m1VO.Dictionary[Te040p01Constant.DIC_M1SIZE_CD]), ref bindDic, ref command);
					// 20.サイズ
					BoSystemDb.setInsertVal("SIZE_NM", iRownum.ToString(), f01m1VO.M1size_nm, ref bindDic, ref command);
					// 21.ＪＡＮコード
					BoSystemDb.setInsertVal("JAN_CD", iRownum.ToString(), BoSystemFormat.formatJanCd(f01m1VO.M1scan_cd), ref bindDic, ref command);
					// 22.商品コード
					BoSystemDb.setInsertVal("SYOHIN_CD", iRownum.ToString(), (string)f01m1VO.Dictionary[Te040p01Constant.DIC_M1SYOHIN_CD], ref bindDic, ref command);
					// 23.移動実績数
					BoSystemDb.setInsertVal("IDOJISSEKI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1syukka_su, "0")), ref bindDic, ref command);
					// 24.原単価
					BoSystemDb.setInsertVal("GEN_TNK", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1gen_tnk, "0")), ref bindDic, ref command);
					// 25.仕入先コード
					BoSystemDb.setInsertVal("SIIRESAKI_CD", iRownum.ToString(), BoSystemFormat.formatSiiresakiCd(f01m1VO.Dictionary[Te040p01Constant.DIC_M1SIIRESAKI_CD].ToString()), ref bindDic, ref command);
					// 26.移動理由
					BoSystemDb.setInsertVal("IDO_RIYU", iRownum.ToString(), f01VO.Shukkariyu_kbn, ref bindDic, ref command);
					// 27.出荷指示No
					BoSystemDb.setInsertVal("SYUKKA_SIJI_NO", iRownum.ToString(), 0, ref bindDic, ref command);
					// 28.防止期限
					BoSystemDb.setInsertVal("STOP_YMD", iRownum.ToString(), 0, ref bindDic, ref command);
					// 29.評価単価
					BoSystemDb.setInsertVal("HYOKA_TNK", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.Dictionary[Te040p01Constant.DIC_M1HYOKA_TNK].ToString(), "0")), ref bindDic, ref command);
					// 30.移動指示理由
					BoSystemDb.setInsertVal("IDORIYU_KB", iRownum.ToString(), dSijiRiyu, ref bindDic, ref command);
					// 31.オフラインNo
					BoSystemDb.setInsertVal("OFFLINE_NO", iRownum.ToString(), null, ref bindDic, ref command);

					insertBindList.Add(bindDic);

					// 一括処理単位に達した場合は、マルチインサートを実行
					if (counter == 20)
					{
						// カウンタのリセット
						counter = 0;

						// マルチインサートの実行
						command.CommandText = GetSqlMultiInsT_TempTransfer(insertBindList);
						//OutPutLog(command.CommandText);
						command.ExecuteNonQuery();

						// 配列、バインドパラメータのクリア
						insertBindList.Clear();
						command.Parameters.Clear();
					}
				}

			}// for

			// 未登録レコードの登録
			if (counter > 0)
			{
				// マルチインサートの実行
				command.CommandText = GetSqlMultiInsT_TempTransfer(insertBindList);
				command.ExecuteNonQuery();
			}

			return iRownum;
		}
		#endregion

		#region [移動出荷確定一時TBL]へのマルチインサート文作成。
		/// <summary>
		/// 移動出荷確定一時TBLへのマルチインサートを行うSQL文を取得する。
		/// </summary>
		/// <param name="insertBindList">バインドテキスト</param>
		private string GetSqlMultiInsT_TempTransfer ( IList<Dictionary<string, string>> insertBindList )
		{
			IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

			// バインドテキストのデータ分INSERT文を作成
			foreach (Dictionary<string, string> bindDic in insertBindList)
			{
				StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文
				insertSql.Append("    INTO MDUT0010_TEMP VALUES ( ");
				insertSql.Append(bindDic["DENPYO_BANGO"]).Append(" , ");			//  1.伝票番号
				insertSql.Append(bindDic["SYUKKA_YMD"]).Append(" , ");				//  2.出荷日
				insertSql.Append(bindDic["SYUKKAKAISYA_CD"]).Append(" , ");			//  3.出荷会社コード
				insertSql.Append(bindDic["SYUKKATEN_CD"]).Append(" , ");			//  4.出荷店コード
				insertSql.Append(bindDic["JYURYOKAISYA_CD"]).Append(" , ");			//  5.入荷会社コード
				insertSql.Append(bindDic["JYURYOTEN_CD"]).Append(" , ");			//  6.入荷店コード
				insertSql.Append(bindDic["KAKUTEI_SB"]).Append(" , ");				//  7.確定種別
				insertSql.Append(bindDic["ADD_YMD"]).Append(" , ");					//  8.登録日
				insertSql.Append(bindDic["ADD_TM"]).Append(" , ");					//  9.登録時間
				insertSql.Append(bindDic["ADDTAN_CD"]).Append(" , ");				// 10.登録担当者コード
				insertSql.Append(bindDic["SYOHINGUN1_CD"]).Append(" , ");			// 11.商品群1コード
				insertSql.Append(bindDic["BUMON_CD"]).Append(" , ");				// 12.部門コード
				insertSql.Append(bindDic["HINSYU_CD"]).Append(" , ");				// 13.品種コード
				insertSql.Append(bindDic["BURANDO_CD"]).Append(" , ");				// 14.ブランドコード
				insertSql.Append(bindDic["MAKER_HBN"]).Append(" , ");				// 15.メーカー品番
				insertSql.Append(bindDic["SYONMK"]).Append(" , ");					// 16.商品名(カナ)
				insertSql.Append(bindDic["JISYA_HBN"]).Append(" , ");				// 17.自社品番
				insertSql.Append(bindDic["IRO_CD"]).Append(" , ");					// 18.色コード
				insertSql.Append(bindDic["SIZE_CD"]).Append(" , ");					// 19.サイズコード
				insertSql.Append(bindDic["SIZE_NM"]).Append(" , ");					// 20.サイズ
				insertSql.Append(bindDic["JAN_CD"]).Append(" , ");					// 21.ＪＡＮコード
				insertSql.Append(bindDic["SYOHIN_CD"]).Append(" , ");				// 22.商品コード
				insertSql.Append(bindDic["IDOJISSEKI_SU"]).Append(" , ");			// 23.移動実績数
				insertSql.Append(bindDic["GEN_TNK"]).Append(" , ");					// 24.原単価
				insertSql.Append(bindDic["SIIRESAKI_CD"]).Append(" , ");			// 25.仕入先コード
				insertSql.Append(bindDic["IDO_RIYU"]).Append(" , ");				// 26.移動理由
				insertSql.Append(bindDic["SYUKKA_SIJI_NO"]).Append(" , ");			// 27.出荷指示No
				insertSql.Append(bindDic["STOP_YMD"]).Append(" , ");				// 28.防止期限
				insertSql.Append(bindDic["HYOKA_TNK"]).Append(" , ");				// 29.評価単価
				insertSql.Append(bindDic["IDORIYU_KB"]).Append(" , ");				// 30.移動指示理由
				insertSql.Append(bindDic["OFFLINE_NO"]);							// 31.オフライン伝票NO
				insertSql.Append(" ) ");

				insertSqlList.Add(insertSql.ToString());
			}

			// 単一INSERTをまとめて、マルチインサート文を作成
			StringBuilder sql = new StringBuilder();
			sql.AppendLine("INSERT ALL");
			foreach (string sqlpart in insertSqlList)
			{
				sql.AppendLine(sqlpart);
			}
			sql.AppendLine("SELECT 1 FROM DUAL");

			return sql.ToString();
		}
		#endregion
		#region ストアド(移動出荷入力登録処理)を起動
		/// <summary>
		/// ストアド(移動出荷入力登録処理)を起動する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>エラーコード</returns>
		public static ArrayList prcInsertTransferOut(IFacadeContext facadeContext)
		{

			// ■移動出荷入力登録処理呼び出し
			ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDTRANSFEROUTNEW.insertTransferOut", new ArrayList());

			#region ■例外処理
			if (al != null && al.Count > 0)
			{
				// エラーコード
				string errCd = al[0].ToString();

				if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
				{
					// 正常終了
				}
				else if (errCd.Equals(BoSystemConstant.STORED_NUMBERING_ERR))
				{
					// 採番不可の場合
					ErrMsgCls.AddErrMsg("E230", string.Empty, facadeContext);
					return al;
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［MDTRANSFEROUTNEW.insertTransferOut］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［MDTRANSFEROUTNEW.insertTransferOut］実行時にエラーが発生しました。");
			}
			#endregion

			return al;
		}
		#endregion
		#region ストアド(再入荷防止TBL登録処理)を起動
		/// <summary>
		/// ストアド(再入荷防止TBL登録処理)を起動する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>エラーコード</returns>
		public static void prcInsertStopOrder ( IFacadeContext facadeContext, Te040f01Form f01VO )
		{
			#region ■パラメータ設定
			ArrayList paramList = new ArrayList();

			// 防止期限日
			StoredProcedureCls.SetStoredParam(ref paramList, "v_STOP_YMD", OracleDbType.Varchar2, ParameterDirection.Input, Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f01VO.Stop_ymd), "0")));
			#endregion

			// ■再入荷防止TBL登録処理呼び出し
			ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDSTOPORDER.insertStopOrder", paramList);

			#region ■例外処理
			if (al != null && al.Count > 0)
			{
				// エラーコード
				string errCd = al[0].ToString();

				if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
				{
					// 正常終了
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［MDSTOPORDER.insertStopOrder］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［MDSTOPORDER.insertStopOrder］実行時にエラーが発生しました。");
			}
			#endregion
		}
		#endregion
	}
}
