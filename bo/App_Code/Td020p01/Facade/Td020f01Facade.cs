using com.xebio.bo.Td020p01.Constant;
using com.xebio.bo.Td020p01.Formvo;
using com.xebio.bo.Td020p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01023;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01018;
using Common.Conditions;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Td020p01.Facade
{
  /// <summary>
  /// Td020f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Td020f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Td020p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Td020f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td020f01Facade()
			: base()
		{
		}
		#endregion

		#region Td020f01画面データを作成する。
		/// <summary>
		/// Td020f01画面データを作成する。
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
				Td020f01Form Td020f01Form = (Td020f01Form)facadeContext.FormVO;

				//モデル層処理ロジックを記述してください。
				//カード部 データを取得(要実装)........

				// 返品理由に"不良品"を設定
				Td020f01Form.Henpin_riyu = ConditionHenpin_riyu_kbn.VALUE_HENPIN_RIYU_KBN2;

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
			Td020f01Form f01VO = (Td020f01Form)facadeContext.FormVO;
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
			AddRowCls.AddEmptyRow<Td020f01M1Form>("M1", "M1rowno", (Td020f01Form)facadeContext.FormVO, m1List.DispRow, defVal);
			SetPageIndex(m1List, m1List.DispRow);
			#endregion

			#region 初期設定
			// 権限取得部品の戻り値が"FALSE"の場合
			if (!CheckKengenCls.CheckKengen(logininfo))
			{
				// 明細部チェックボックスの制御
				for (int index = 0; index < m1List.Count; index++)
				{
					Td020f01M1Form tb020f01M1Form = (Td020f01M1Form)m1List[index];

					// [Ｍ１店舗コード]にログイン情報の店舗コードを設定
					tb020f01M1Form.M1tenpo_cd = logininfo.TnpCd;
					// [Ｍ１店舗名]にログイン情報の所属店舗名を設定
					tb020f01M1Form.M1tenpo_nm = logininfo.Tnprksmes;
				}
			}
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
		/// <param name="bool">Ｃｓｖ取込フラグ</param>
		/// <returns></returns>
		public void DoShohinCopy ( Td020f01M1Form f01m1VO, Hashtable syohinData, string TenpoCd, bool blSize, bool blTorikomi )
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
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1TENPO_CD] = TenpoCd;												// 店舗コード
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1HINSYU_CD] = syohinData["HINSYU_CD"].ToString();					// 品種コード
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1BURANDO_CD] = syohinData["BURANDO_CD"].ToString();				// ブランドコード
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1IRO_CD] = syohinData["MAKERCOLOR_CD"].ToString();					// 色コード
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1SIZE_CD] = syohinData["SIZE_CD"].ToString();						// サイズコード
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1SYOHIN_CD] = syohinData["SYOHIN_CD"].ToString();					// 商品コード
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1SIIRESAKI_CD] = syohinData["SIIRESAKI_CD"].ToString();			// 仕入先コード
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1SUBSIIRESAKI_CD] = syohinData["SUBSIIRESAKI_CD"].ToString();		// ｻﾌﾞ仕入先コード

			// チェック用
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1SAISIN_SIIRE_YMD] = syohinData["SAISIN_SIIRE_YMD"].ToString();							// 最新仕入日
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1HATTYUSYO_MONGON_INSATSU_FLG] = syohinData["HATTYUSYO_MONGON_INSATSU_FLG"].ToString();	// 発注書文言印刷フラグ
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1TYOTATSU_KB] = syohinData["TYOTATSU_KB"].ToString();										// 調達区分
			f01m1VO.Dictionary[Td020p01Constant.DIC_M1HOSYOUSYO_HAKKOU_FLG] = syohinData["HOSYOUSYO_HAKKOU_FLG"].ToString();					// 保証書発行フラグ
			// サイズ選択戻り及びＣＳＶ取込戻り時
			if (blSize || blTorikomi)
			{
				if (blSize)
				{
					f01m1VO.M1itemsu = syohinData[OpenTm040p01Cls.COLUMN_INPUT_SURYO].ToString();					// Ｍ１数量
				}

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
		/// <param name="Td020f01Form">f02VO</param>
		/// <returns></returns>
		public void SumGoukeiDetail ( Td020f01Form f01VO )
		{
			decimal dSumSu = 0;		// 合計数量
			decimal dSumKin = 0;	// 合計金額

			foreach (Td020f01M1Form f01m1VO in f01VO.GetList("M1").ListData)
			{
				dSumSu += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1itemsu, "0"));					// 合計数量
				dSumKin += Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1genkakin, "0"));				// 合計金額
			}
			f01VO.Gokei_suryo = dSumSu.ToString();
			f01VO.Genka_kin_gokei = dSumKin.ToString();
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
			foreach (Td020f01M1Form f01m1VO in m1List.ListData)
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
		/// <param name="Td020f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void ChkUpdSingleItem ( IFacadeContext facadeContext, Td020f01Form f01VO, IDataList m1List, SysDateVO sysDateVO )
		{
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
			// 1-1 ヘッダ店舗コード
			//       店舗マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Head_tenpo_nm = resultHash["TENPO_NM"].ToString();

					// 1-2 ヘッダ店舗コード 
					if (Td020p01Constant.TENPOKEITAI_KB_LC.Equals(resultHash["TENPOKEITAI_KB"].ToString()))
					{
						ErrMsgCls.AddErrMsg("E125", string.Empty, facadeContext, new[] { "Head_tenpo_cd" });
					}
				}
			}
			// 1-3 指示番号
			//     返品理由が「本部指示」で未入力の場合、エラー
			if (ConditionHenpin_riyu_kbn.VALUE_HENPIN_RIYU_KBN1.Equals(f01VO.Henpin_riyu))
			{
				if (string.IsNullOrEmpty(f01VO.Siji_bango))
				{
					ErrMsgCls.AddErrMsg("E121", new string[] { "指示番号" }, facadeContext, new[] { "Siji_bango" });
				}
			}
			// 1-4 指示番号
			//     返品指示TBLを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Siji_bango))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01018Check.CheckHenpinSiji(
													  f01VO.Head_tenpo_cd
													, f01VO.Siji_bango
													, facadeContext, "指示番号", new[] { "Siji_bango" });
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Siiresaki_cd = resultHash["SIIRESAKI_CD"].ToString();					// 仕入先コード
					f01VO.Siiresaki_ryaku_nm = resultHash["SIIRESAKI_RYAKU_NM"].ToString();		// 仕入先名
				}
			}
			// 1-5 仕入先コード
			//       仕入先マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01002Check.CheckShiiresaki(f01VO.Siiresaki_cd, facadeContext, "仕入先", new[] { "Siiresaki_cd" });
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Siiresaki_ryaku_nm = resultHash["SIIRESAKI_RYAKU_NM"].ToString();
				}
			}
		}
		#endregion
		#region 更新単項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Td020f01Form">f01VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void ChkUpdSingleItemDetail ( IFacadeContext facadeContext, Td020f01Form f01VO, IDataList m1List, SysDateVO sysDateVO )
		{
			decimal dSumSu = 0;		// 合計数量
			decimal dSumKin = 0;	// 合計金額
			decimal genkakin = 0;	// 明細合計金額
			int iCnt = 0;
			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

			foreach (Td020f01M1Form f01m1VO in m1List.ListData)
			{
				bool meisaiErr = false;
				genkakin = 0;
				// スキャンコードが入力されている場合
				if (!meisaiErr && !string.IsNullOrEmpty(f01m1VO.M1scan_cd.Trim()))
				{
					// 権限取得部品の戻り値が"FALSE"の場合、ヘッダ店舗をM1店舗コードに埋め込む
					if (!CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo()))
					{
						f01m1VO.M1tenpo_cd = f01VO.Head_tenpo_cd;
					}

					// Ｍ１店舗コード
					//     店舗マスタを検索し、存在しない場合エラー
					if (!string.IsNullOrEmpty(f01m1VO.M1tenpo_cd))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01001Check.CheckTenpo(f01m1VO.M1tenpo_cd, facadeContext, "店舗", new[] { "M1tenpo_cd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						// 名称をラベルに設定
						if (resultHash != null)
						{
							f01m1VO.M1tenpo_nm = resultHash["TENPO_NM"].ToString();

							// 存在チェックにて取得した店舗MST.[店舗形態区分] = 2（LC） の場合、エラー 
							if (Td020p01Constant.TENPOKEITAI_KB_LC.Equals(resultHash["TENPOKEITAI_KB"].ToString()))
							{
								ErrMsgCls.AddErrMsg("E125", string.Empty, facadeContext, new[] { "M1tenpo_cd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
								meisaiErr = true;
							}
						}
					}
					else
					{
						// 入力されていない場合、エラー
						ErrMsgCls.AddErrMsg("E121", "店舗", facadeContext, new[] { "M1tenpo_cd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						meisaiErr = true;
					}

					// Ｍ１店舗コード
					//     指示番号入力時、Ｍ１店舗コード、指示番号で返品指示TBLに存在しない場合、エラー
					if (!meisaiErr && !string.IsNullOrEmpty(f01VO.Siji_bango))
					{
						Hashtable resultHash = new Hashtable();
						resultHash = V01018Check.CheckHenpinSiji(
															  f01m1VO.M1tenpo_cd
															, f01VO.Siji_bango
															, facadeContext);
						// 名称をラベルに設定
						if (resultHash == null)
						{
							// 存在しない場合、エラー
							ErrMsgCls.AddErrMsg("E198", string.Empty, facadeContext, new[] { "M1tenpo_cd" }
									, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							meisaiErr = true;
						}
					}

					#region Ｍ１スキャンコード
					// 発注MSTに存在しない場合、エラー
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						f01m1VO.M1scan_cd,		// スキャンコード
						f01m1VO.M1tenpo_cd,		// 店舗コード
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
						DoShohinCopy(f01m1VO, syohinData, f01m1VO.M1tenpo_cd, false, false);

						Decimal wkSuryo = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1itemsu, "0"));
						genkakin = decimal.Parse(syohinData["GENKA"].ToString()) * wkSuryo;
						f01m1VO.M1genkakin = genkakin.ToString();							// 原価金額

						dSumSu += wkSuryo;													// 合計数量
						dSumKin += genkakin;												// 合計金額
					}
					else
					{
						meisaiErr = true;
					}
					#endregion
					#region Ｍ１スキャンコード
					if (!meisaiErr)
					{
						// 原価がマイナスの場合、エラー
						if (Convert.ToDecimal(f01m1VO.M1gen_tnk) < 0)
						{
							meisaiErr = true;
							ErrMsgCls.AddErrMsg("E146", String.Empty, facadeContext, new[] { "M1scan_cd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);

						}
					}
					#endregion
					#region Ｍ１スキャンコード
					// 指示番号入力時は、指示に存在しない商品はエラー
					if (!meisaiErr && !string.IsNullOrEmpty(f01VO.Siji_bango))
					{
						SearchHachuVO searchSijiConditionVO = new SearchHachuVO(
							f01m1VO.M1scan_cd,		// スキャンコード
							f01m1VO.M1tenpo_cd,		// 店舗コード
							0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
							0,						// 売変 検索フラグ 0:検索しない 1:検索する
							0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
							0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
							0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
							0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
							0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
							2,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
							f01VO.Siji_bango,		// 指示NO（移動出荷マニュアル、返品マニュアル用）
							string.Empty,			// 出荷会社コード（移動出荷マニュアル)
							string.Empty,			// 入荷会社コード（移動出荷マニュアル)
							f01VO.Head_tenpo_cd		// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
						);
						Hashtable syohinDataSiji = V01004Check.CheckScanCd(
															searchSijiConditionVO,
															facadeContext
													);
						if (syohinDataSiji == null)
						{
							ErrMsgCls.AddErrMsg("E149", string.Empty, facadeContext, new[] { "M1scan_cd" }
									, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							meisaiErr = true;
						}
					}
					#endregion
					#region Ｍ１スキャンコード
					// 仕入先入力時は、仕入先の商品以外はエラー
					if (!meisaiErr && !string.IsNullOrEmpty(f01VO.Siiresaki_cd))
					{
						// 存在チェックにて取得した発注MST.[仕入先コード]が[仕入先コード]と異なる場合、エラー
						if(!f01VO.Siiresaki_cd.Equals(f01m1VO.Dictionary[Td020p01Constant.DIC_M1SIIRESAKI_CD].ToString()))
						{
							ErrMsgCls.AddErrMsg("E148", String.Empty, facadeContext, new[] { "M1scan_cd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							meisaiErr = true;
						}
					}
					#endregion

					// 画面の返品理由が「本部指示」でない場合、返品不可商品チェックを行う。
					if (!meisaiErr && !ConditionHenpin_riyu_kbn.VALUE_HENPIN_RIYU_KBN1.Equals(f01VO.Henpin_riyu))
					{
						if(Td020p01Util.ChkHenpinFuka (facadeContext,  f01m1VO , sysDateVO ))
						{
							ErrMsgCls.AddErrMsg("E229", String.Empty, facadeContext, new[] { "M1scan_cd" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							meisaiErr = true;
						}
					}

					#region Ｍ１数量
					// 数量が未入力の場合、エラー
					if (!meisaiErr && string.IsNullOrEmpty(f01m1VO.M1itemsu))
					{
						ErrMsgCls.AddErrMsg("E121", "数量", facadeContext, new[] { "M1itemsu" }
								, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
					}
					else
					{
						// 0が入力された場合、エラー
						if ("0".Equals(f01m1VO.M1itemsu))
						{
							ErrMsgCls.AddErrMsg("E103", "数量", facadeContext, new[] { "M1itemsu" }
									, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						}
					}
					#endregion
					if (!meisaiErr && genkakin > 999999999)
					{
						ErrMsgCls.AddErrMsg("E102", "原価金額", facadeContext, new[] { "M1itemsu" }
									, f01m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
					}

				}
				iCnt++;
			}


			// 合計金額設定
			f01VO.Gokei_suryo = dSumSu.ToString();
			f01VO.Genka_kin_gokei = dSumKin.ToString();
		}
		#endregion
		#region [返品予定一時TBL]を登録する。
		/// <summary>
		/// [返品予定一時TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">一覧画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TempReturn ( IFacadeContext facadeContext, Td020f01Form f01VO, LoginInfoVO loginInfo, SysDateVO sysDateVO )
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

			// 指示番号設定
			decimal dSijiNo = Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.HenpinSijiNoGetSijino(f01VO.Siji_bango), "0"));
			// 備考
			string sBiko = BoSystemString.Nvl(f01VO.Biko);

			foreach (Td020f01M1Form f01m1VO in f01VO.GetList("M1").ListData)
			{
				// スキャンコードが入力されている行が対象
				if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd.Trim()))
				{
					counter++;
					iRownum++;

					Dictionary<string, string> bindDic = new Dictionary<string, string>();
					//  1.仕入先コード
					BoSystemDb.setInsertVal("SIIRESAKI_CD", iRownum.ToString(), BoSystemFormat.formatSiiresakiCd(f01m1VO.Dictionary[Td020p01Constant.DIC_M1SIIRESAKI_CD].ToString()), ref bindDic, ref command);
					//  2.サブ仕入先コード
					BoSystemDb.setInsertVal("SUBSIIRESAKI_CD", iRownum.ToString(), BoSystemFormat.formatSiiresakiCd(f01m1VO.Dictionary[Td020p01Constant.DIC_M1SUBSIIRESAKI_CD].ToString()), ref bindDic, ref command);
					//  3.返品理由
					BoSystemDb.setInsertVal("HENPIN_RIYU", iRownum.ToString(), f01VO.Henpin_riyu, ref bindDic, ref command);
					//  4.担当者コード
					BoSystemDb.setInsertVal("TANTOSYA_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(loginInfo.TtsCd), ref bindDic, ref command);
					//  5.備考
					BoSystemDb.setInsertVal("BIKO", iRownum.ToString(), sBiko, ref bindDic, ref command);
					//  6.登録日
					BoSystemDb.setInsertVal("ADD_YMD", iRownum.ToString(), sysDateVO.Sysdate, ref bindDic, ref command);
					//  7.登録時間
					BoSystemDb.setInsertVal("ADD_TM", iRownum.ToString(), sysDateVO.Systime_mili, ref bindDic, ref command);
					//  8.登録担当者コード
					BoSystemDb.setInsertVal("ADDTAN_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(loginInfo.TtsCd), ref bindDic, ref command);
					//  9.店舗コード
					BoSystemDb.setInsertVal("TENPO_CD", iRownum.ToString(), BoSystemFormat.formatTenpoCd(f01m1VO.M1tenpo_cd), ref bindDic, ref command);
					// 10.部門コード
					BoSystemDb.setInsertVal("BUMON_CD", iRownum.ToString(), BoSystemFormat.formatBumonCd(f01m1VO.M1bumon_cd), ref bindDic, ref command);
					// 11.品種コード
					BoSystemDb.setInsertVal("HINSYU_CD", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.Dictionary[Td020p01Constant.DIC_M1HINSYU_CD].ToString(), "0")), ref bindDic, ref command);
					// 12.ブランドコード
					BoSystemDb.setInsertVal("BURANDO_CD", iRownum.ToString(), BoSystemFormat.formatBrandCd(f01m1VO.Dictionary[Td020p01Constant.DIC_M1BURANDO_CD].ToString()), ref bindDic, ref command);
					// 13.自社品番
					BoSystemDb.setInsertVal("JISYA_HBN", iRownum.ToString(), f01m1VO.M1jisya_hbn, ref bindDic, ref command);
					// 14.メーカー品番
					BoSystemDb.setInsertVal("MAKER_HBN", iRownum.ToString(), f01m1VO.M1maker_hbn, ref bindDic, ref command);
					// 15.商品名(カナ)
					BoSystemDb.setInsertVal("SYONMK", iRownum.ToString(), f01m1VO.M1syonmk, ref bindDic, ref command);
					// 16.色コード
					BoSystemDb.setInsertVal("IRO_CD", iRownum.ToString(), BoSystemFormat.formatIroCd((string)f01m1VO.Dictionary[Td020p01Constant.DIC_M1IRO_CD]), ref bindDic, ref command);
					// 17.サイズコード
					BoSystemDb.setInsertVal("SIZE_CD", iRownum.ToString(), BoSystemFormat.formatSizeCd((string)f01m1VO.Dictionary[Td020p01Constant.DIC_M1SIZE_CD]), ref bindDic, ref command);
					// 18.サイズ
					BoSystemDb.setInsertVal("SIZE_NM", iRownum.ToString(), f01m1VO.M1size_nm, ref bindDic, ref command);
					// 19.ＪＡＮコード
					BoSystemDb.setInsertVal("JAN_CD", iRownum.ToString(), BoSystemFormat.formatJanCd(f01m1VO.M1scan_cd), ref bindDic, ref command);
					// 20.商品コード
					BoSystemDb.setInsertVal("SYOHIN_CD", iRownum.ToString(), (string)f01m1VO.Dictionary[Td020p01Constant.DIC_M1SYOHIN_CD], ref bindDic, ref command);
					// 21.返品予定数
					BoSystemDb.setInsertVal("HENPINYOTEI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1itemsu, "0")), ref bindDic, ref command);
					// 22.原単価
					BoSystemDb.setInsertVal("GEN_TNK", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1gen_tnk, "0")), ref bindDic, ref command);
					// 23.返品指示No
					BoSystemDb.setInsertVal("HENPIN_SIJI_NO", iRownum.ToString(), dSijiNo, ref bindDic, ref command);

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

		#region [返品予定一時TBL]へのマルチインサート文作成。
		/// <summary>
		/// 返品予定一時TBLへのマルチインサートを行うSQL文を取得する。
		/// </summary>
		/// <param name="insertBindList">バインドテキスト</param>
		private string GetSqlMultiInsT_TempTransfer ( IList<Dictionary<string, string>> insertBindList )
		{
			IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

			// バインドテキストのデータ分INSERT文を作成
			foreach (Dictionary<string, string> bindDic in insertBindList)
			{
				StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文
				insertSql.Append("    INTO MDRT0010_TEMP VALUES ( ");
				insertSql.Append(bindDic["SIIRESAKI_CD"]).Append(" , ");	//  1.仕入先コード
				insertSql.Append(bindDic["SUBSIIRESAKI_CD"]).Append(" , ");	//  2.サブ仕入先コード
				insertSql.Append(bindDic["HENPIN_RIYU"]).Append(" , ");		//  3.返品理由
				insertSql.Append(bindDic["TANTOSYA_CD"]).Append(" , ");		//  4.担当者コード
				insertSql.Append(bindDic["BIKO"]).Append(" , ");			//  5.備考
				insertSql.Append(bindDic["ADD_YMD"]).Append(" , ");			//  6.登録日
				insertSql.Append(bindDic["ADD_TM"]).Append(" , ");			//  7.登録時間
				insertSql.Append(bindDic["ADDTAN_CD"]).Append(" , ");		//  8.登録担当者コード
				insertSql.Append(bindDic["TENPO_CD"]).Append(" , ");		//  9.店舗コード
				insertSql.Append(bindDic["BUMON_CD"]).Append(" , ");		// 10.部門コード
				insertSql.Append(bindDic["HINSYU_CD"]).Append(" , ");		// 11.品種コード
				insertSql.Append(bindDic["BURANDO_CD"]).Append(" , ");		// 12.ブランドコード
				insertSql.Append(bindDic["JISYA_HBN"]).Append(" , ");		// 13.自社品番
				insertSql.Append(bindDic["MAKER_HBN"]).Append(" , ");		// 14.メーカー品番
				insertSql.Append(bindDic["SYONMK"]).Append(" , ");			// 15.商品名(カナ)
				insertSql.Append(bindDic["IRO_CD"]).Append(" , ");			// 16.色コード
				insertSql.Append(bindDic["SIZE_CD"]).Append(" , ");			// 17.サイズコード
				insertSql.Append(bindDic["SIZE_NM"]).Append(" , ");			// 18.サイズ
				insertSql.Append(bindDic["JAN_CD"]).Append(" , ");			// 19.ＪＡＮコード
				insertSql.Append(bindDic["SYOHIN_CD"]).Append(" , ");		// 20.商品コード
				insertSql.Append(bindDic["HENPINYOTEI_SU"]).Append(" , ");	// 21.返品予定数
				insertSql.Append(bindDic["GEN_TNK"]).Append(" , ");			// 22.原単価
				insertSql.Append(bindDic["HENPIN_SIJI_NO"]);	// 23.返品指示NO
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
		#region ストアド(返品登録処理)を起動
		/// <summary>
		/// ストアド(返品登録処理)を起動する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>エラーコード</returns>
		public static ArrayList prcInsertReturnNew(IFacadeContext facadeContext)
		{
			#region ■パラメータ設定
			ArrayList paramList = new ArrayList();

			#endregion

			// ■返品登録処理呼び出し
			ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDRETURNNEW.insertReturnNew", paramList);

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
					throw new SystemException("ストアド［MDRETURNNEW.insertReturnNew］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［MDRETURNNEW.insertReturnNew］実行時にエラーが発生しました。");
			}
			#endregion

			return al;
		}
		#endregion
	}
}
