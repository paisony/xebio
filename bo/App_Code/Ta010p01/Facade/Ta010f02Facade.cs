using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta010p01.Formvo;
using com.xebio.bo.Ta010p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01007;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01019;
using Common.Business.C01000.C01023;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01015;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Entitys;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Ta010p01.Facade
{
  /// <summary>
  /// Ta010f02のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Ta010f02Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Ta010p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Ta010f02";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Ta010f02Facade()
			: base()
		{
		}
		#endregion

		#region Ta010f02画面データを作成する。
		/// <summary>
		/// Ta010f02画面データを作成する。
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
			//	Ta010f02Form ta010f02Form = (Ta010f02Form)facadeContext.FormVO;
				
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
		/// <param name="string">Modeno</param>
		/// <returns></returns>
		private void ChkRowCount ( IFacadeContext facadeContext, IDataList m1List, string Modeno)
		{
			int inputflg = 0;
			// [選択モードNo]が「申請」の場合、選択行数チェック
			if (BoSystemConstant.MODE_APPLY.Equals(Modeno))
			{
				if (m1List == null || m1List.Count <= 0)
				{
					// 対象行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
				else
				{
					foreach (Ta010f02M1Form f02m1VO in m1List.ListData)
					{
						if (f02m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 対象行を選択して下さい。
						ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					}
				}
			}
			// [選択モードNo]が「申請」以外の場合、行数チェック（スキャンコード存在行）
			else
			{

				foreach (Ta010f02M1Form f02m1VO in m1List.ListData)
				{
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
					{
						inputflg = 1;
						break;
					}
				}
				if (inputflg == 0)
				{
					// 登録データがありません。
					ErrMsgCls.AddErrMsg("E133", String.Empty, facadeContext);
				}
			}
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

		#region 明細行数チェック 枝番あり
		/// <summary>
		/// ChkDetailCount 明細行数チェック 枝番あり
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Decimal">dCnt</param>
		/// <param name="String">sEdaban</param>
		/// <returns>Decimal</returns>
		private void ChkDetailCount(IFacadeContext facadeContext, Decimal cnt, String sEdaban)
		{
			// コンフィグファイルより最大件数を取得
			Decimal dCnt = GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper(), sEdaban);

			if (cnt > dCnt)
			{
				// 最大件数を超えている場合、エラーとする。
				ErrMsgCls.AddErrMsg("E147", dCnt.ToString(), facadeContext);
			}
		}
		#endregion
		#region 更新単項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta010f02Form">f02VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="Ta010f01M1Form">f01M1Form</param>
		/// <returns>Decimal</returns>
		private decimal[] ChkUpdSingleItem ( IFacadeContext facadeContext, Ta010f02Form f02VO, IDataList m1List )
		{
			decimal dSumSu = 0;		// 合計数量
			decimal dSumKin = 0;	// 合計金額
			decimal[] dRet = null;
			// [選択モードNo]が「申請」の場合、合計の計算
			if (BoSystemConstant.MODE_APPLY.Equals(f02VO.Stkmodeno))
			{
				foreach (Ta010f02M1Form f02m1VO in m1List.ListData)
				{
					// 選択行のみ
					if (f02m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						dSumSu += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1irai_su, "0"));					// 合計数量
						dSumKin += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0"));					// 合計金額
					}
				}
			}
			else
			{
				#region 単項目チェック
				int iCnt = 0;
				foreach (Ta010f02M1Form f02m1VO in m1List.ListData)
				{
					bool meisaiErr = false;
					// スキャンコードが入力されている場合
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
					{
						#region Ｍ１スキャンコード
						// 発注MSTに存在しない場合、エラー
						SearchHachuVO searchConditionVO = new SearchHachuVO(
							f02m1VO.M1scan_cd,		// スキャンコード
							f02VO.Head_tenpo_cd,	// 店舗コード
							1,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
							0,						// 売変 検索フラグ 0:検索しない 1:検索する
							1,						// 店在庫 検索フラグ 0:検索しない 1:検索する
							1,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
							1,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
							1,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
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
							// 発注マスタ情報設定
							DoShohinCopy(f02m1VO, syohinData, false);

							Decimal wkSuryo = Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1irai_su, "0"));
							Decimal genkakin = (decimal)syohinData["GENKA"] * wkSuryo;
							f02m1VO.M1genkakin = genkakin.ToString();							// 原価金額

							dSumSu += wkSuryo;													// 合計数量
							dSumKin += genkakin;												// 合計金額
							// 原価がマイナスの場合、エラー
							if (Convert.ToDecimal(f02m1VO.M1gen_tnk) < 0)
							{
								meisaiErr = true;
								ErrMsgCls.AddErrMsg("E146", String.Empty, facadeContext, new[] { "M1scan_cd" }
									, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							}
						}
						else
						{
							meisaiErr = true;
						}
						#endregion
						#region Ｍ１依頼数量
						// 依頼数量が未入力の場合、エラー
						if (string.IsNullOrEmpty(f02m1VO.M1irai_su))
						{
							meisaiErr = true;
							ErrMsgCls.AddErrMsg("E121", "依頼数", facadeContext, new[] { "M1irai_su" }
									, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
						}
						else
						{
							// 0が入力された場合、エラー
							if ("0".Equals(f02m1VO.M1irai_su))
							{
								meisaiErr = true;
								ErrMsgCls.AddErrMsg("E103", "依頼数", facadeContext, new[] { "M1irai_su" }
										, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							}

							// [Ｍ１原価金額]＞9999999（７桁）の場合、エラー
							if (!meisaiErr
								&& Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0")) > 9999999m)
							{
								meisaiErr = true;
								ErrMsgCls.AddErrMsg("E102", "原価金額", facadeContext, new[] { "M1irai_su" }
									, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow);
							}
						}
						#endregion
					}
					iCnt++;
				}
				#endregion
			}

			f02VO.Gokei_irai_su = dSumSu.ToString();
			f02VO.Gokei_genkakin = dSumKin.ToString();
			dRet = new decimal[] { dSumSu, dSumKin };
			return dRet;
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
		public void DoShohinCopy ( Ta010f02M1Form f02m1VO, Hashtable syohinData, bool blSize )
		{
			// 発注マスタ検索値をフォームビーン再設定
			f02m1VO.M1bumonkana_nm = syohinData["BUMONKANA_NM"].ToString();			// 部門カナ名
			f02m1VO.M1hyoka_kb = syohinData["HYOKA_NM"].ToString();					// 評価区分
			f02m1VO.M1kahi_nm = syohinData["HATYUTAISYO_NM"].ToString();			// 可否名称
			f02m1VO.M1tenzaiko_su = syohinData["REAL_SU"].ToString();				// 店在庫数
			f02m1VO.M1hinsyu_ryaku_nm = syohinData["HINSYU_RYAKU_NM"].ToString();	// 品種略名称
			f02m1VO.M1nyukayotei_su = syohinData["NYUKA_SU"].ToString();			// 入荷予定数
			f02m1VO.M1uriage_su = syohinData["URI_SU"].ToString();					// 売上実績数
			f02m1VO.M1burando_nm = syohinData["BURANDO_NMK"].ToString();			// ブランド名
			f02m1VO.M1jido_su = syohinData["JIDO_SU"].ToString();					// Ｍ１自動定数
			f02m1VO.M1haibunkano_su = syohinData["HAIBUNKANO_SU"].ToString();		// 配分可能数
			f02m1VO.M1jisya_hbn = syohinData["XEBIO_CD"].ToString();				// 自社品番
			f02m1VO.M1irai_syukei = syohinData["HOJU_SU"].ToString();				// 依頼集計
			f02m1VO.M1syohin_zokusei = syohinData["SYOHIN_ZOKUSEI"].ToString();		// 商品属性
			//f02m1VO.M1lot_su = syohinData["LOT_SU"].ToString();						// ロット数
			f02m1VO.M1lot_su = syohinData["MOTOMIYALOT_SU"].ToString();				// ロット数
			f02m1VO.M1iro_nm = syohinData["IRO_NM"].ToString();						// 色
			f02m1VO.M1size_nm = syohinData["SIZE_NM"].ToString();					// サイズ
			f02m1VO.M1maker_hbn = syohinData["HIN_NBR"].ToString();					// メーカー品番
			f02m1VO.M1syonmk = syohinData["SYONMK"].ToString();						// 商品名(カナ)
			f02m1VO.M1scan_cd = syohinData["JAN_CD"].ToString();					// Ｍ１スキャンコード
			f02m1VO.M1gen_tnk = syohinData["GENKA"].ToString();						// 原単価

			// Dictionary
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1BUMON_CD] = syohinData["BUMON_CD"].ToString();							// 部門コード
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HINSYU_CD] = syohinData["HINSYU_CD"].ToString();							// 品種コード
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1BURANDO_CD] = syohinData["BURANDO_CD"].ToString();						// ブランドコード
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1IRO_CD] = syohinData["MAKERCOLOR_CD"].ToString();							// 色コード
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1SIZE_CD] = syohinData["SIZE_CD"].ToString();								// サイズコード
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1SYOHIN_CD] = syohinData["SYOHIN_CD"].ToString();							// 商品コード
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HANBAIKANRYO_YMD] = syohinData["HANBAIKANRYO_YMD"].ToString();			// 販売完了日
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HATYUTAISYO_KB] = syohinData["HATYUTAISYO_KB"].ToString();				// 補充区分
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HYOKA_KB] = syohinData["HYOKA_KB"].ToString();							// 評価区分
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1KANOUSUGOE_FLG] = syohinData["KANOUSUGOE_KANOUTORIHIKI_FLG"].ToString();	// 可能数越可能取引フラグ
			f02m1VO.Dictionary[Ta010p01Constant.DIC_M1MOTOMIYASYOHIN_FLG] = syohinData["MOTOMIYASYOHIN_FLG"].ToString();		// 本宮商品フラグ

			if (blSize)
			{
				//f02m1VO.M1scan_cd = syohinData["JAN_CD"].ToString();												// Ｍ１スキャンコード
				f02m1VO.M1irai_su = syohinData[OpenTm040p01Cls.COLUMN_INPUT_SURYO].ToString();						// Ｍ１依頼数量

				f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;											// Ｍ１選択フラグ(隠し)
				f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;										// Ｍ１確定処理フラグ(隠し)
				f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;											// Ｍ１明細色区分(隠し)
			}
		}
		#endregion
		#region 単品レポートチェック
		/// <summary>
		/// ChkTanpinReport 単品レポートチェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta010f02Form">f02VO</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="Ta010f02M1Form">f01M1Form</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void ChkTanpinReport ( IFacadeContext facadeContext, Ta010f02Form f02VO, IDataList m1List, SysDateVO sysDateVO )
		{
			// [選択モードNo]が「新規作成」「修正」以外は、処理しない。
			if (!BoSystemConstant.MODE_INSERT.Equals(f02VO.Stkmodeno)
			 && !BoSystemConstant.MODE_UPD.Equals(f02VO.Stkmodeno))
			{
				return;
			}
			// [選択モードNo]が「修正」で区分が単品レポートの場合は、処理しない。
			if (BoSystemConstant.MODE_UPD.Equals(f02VO.Stkmodeno)
			 && ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN2.Equals(f02VO.Kbn_cd))
			{
				return;
			}
			// [選択モードNo]が「新規作成」で区分が単品レポートかつ単品登録モードがONでない場合は、処理しない。
			if (BoSystemConstant.MODE_INSERT.Equals(f02VO.Stkmodeno)
			 && ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN2.Equals(f02VO.Kbn_cd)
			 && !Convert.ToString(Ta010p01Constant.FLG_ON).Equals((string)f02VO.Dictionary[Ta010p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
			{
				return;
			}


			int iCnt = 0;
			bool blErr = false;
			foreach (Ta010f02M1Form f02m1VO in m1List.ListData)
			{
				bool meisaiErr = false;
				// スキャンコードが入力されていない場合、次明細
				if (string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
				{
					continue;
				}

				/// 単品レポート数量修正フラグ設定 ＯＦＦ
//				f02VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_UPD_FLG] = Convert.ToString(Ta010p01Constant.FLG_OFF);
				f02m1VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_UPD_FLG] = Convert.ToString(Ta010p01Constant.FLG_OFF);

				// 4-1 補充発注対象商品区分
				// [補充発注対象商品区分]＝"0"の場合、エラー
				if(!meisaiErr && "0".Equals((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HATYUTAISYO_KB]))
				{
					// エラーメッセージ設定
					blErr = Ta010p01Util.setTanpinReportMsg("E185", String.Empty, facadeContext, new[] { "M1scan_cd" }
										, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow
										, blErr);
					meisaiErr = true;
				}
			
				// 4-2 販売完了日
				// 自動補充区分が1(DC)、3(DC自動)の場合、販売完了日チェックはしない
				string jidokb = (string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1MOTOMIYASYOHIN_FLG];
				if (jidokb.Equals("2") || jidokb.Equals("4"))
				{
					if (!meisaiErr && Convert.ToDecimal(BoSystemFormat.formatDate((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HANBAIKANRYO_YMD])) <= sysDateVO.Sysdate)
					{
						// エラーメッセージ設定
						blErr = Ta010p01Util.setTanpinReportMsg("E182", String.Empty, facadeContext, new[] { "M1scan_cd" }
											, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow
											, blErr);
						meisaiErr = true;
					}
				} 

				// 4-3 ロット数
				//     [ロット数]の整数倍でない場合、エラー
				if(!meisaiErr && Ta010p01Util.ChkLotIrai(f02m1VO.M1lot_su, f02m1VO.M1irai_su))
				{
					// エラーメッセージ設定
					blErr = Ta010p01Util.setTanpinReportMsg("E112", "依頼数", facadeContext, new[] { "M1irai_su" }
										, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow
										, blErr);
					// 単品レポート数量修正フラグ設定 ＯＮ
					f02m1VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_UPD_FLG] = Convert.ToString(Ta010p01Constant.FLG_ON);
					meisaiErr = true;
				}

				// 4-4 配分可能数数
				//     [仕入先MST.可能数超可能取引フラグ]＝"1"で発注MST.[配分可能数]＜Ｍ１依頼数量の場合、エラー
				if (!meisaiErr 
				&& "1".Equals((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1KANOUSUGOE_FLG])
				&& Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1haibunkano_su, "0")) < Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1irai_su, "0")))
				{
					// エラーメッセージ設定
					blErr = Ta010p01Util.setTanpinReportMsg("E113", "依頼数", facadeContext, new[] { "M1irai_su" }
										, f02m1VO.M1rowno, iCnt.ToString(), "M1", m1List.DispRow
										, blErr);
					// 単品レポート数量修正フラグ設定 ＯＮ
					f02m1VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_UPD_FLG] = Convert.ToString(Ta010p01Constant.FLG_ON);
					meisaiErr = true;
				}

				// チェック結果により、単品レポートフラグを設定
				if (meisaiErr)
				{
					// 単品レポートフラグ設定 ＯＮ
					f02VO.Dictionary[Ta010p01Constant.DIC_TANPIN_REPORT_FLG] = Convert.ToString(Ta010p01Constant.FLG_ON);
					// 単品レポートフラグ設定（明細単位） ＯＮ
					f02m1VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_REPORT_FLG] = Convert.ToString(Ta010p01Constant.FLG_ON);
				}
				else
				{
					// 単品レポートフラグ設定（明細単位） ＯＦＦ
					f02m1VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_REPORT_FLG] = Convert.ToString(Ta010p01Constant.FLG_OFF);
				}

				iCnt++;
			}
		}
		#endregion
		#region 単品レポートモード表示
		/// <summary>
		/// ChkTanpinReport 単品レポートモード表示
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void DoCopyTanpinReport ( Ta010f02Form f02VO )
		{
			int iCnt = 0;
			IDataList m1List = f02VO.GetList("M1");

			decimal[] iDelRow = new decimal[m1List.Count];
			foreach (Ta010f02M1Form f02m1VO in m1List.ListData)
			{
				// スキャンコードが入力されていない場合、次明細
				if (string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
				{
					iDelRow[iCnt] = Ta010p01Constant.FLG_OFF;
					iCnt++;
					continue;
				}
				// 単品レポートフラグ設定（明細単位） がＯＮの場合
				if(Convert.ToString(Ta010p01Constant.FLG_ON).Equals(f02m1VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_REPORT_FLG]))
				{
					iDelRow[iCnt] = Ta010p01Constant.FLG_OFF;
				}
				else
				{
					iDelRow[iCnt] = Ta010p01Constant.FLG_ON;
				}
				iCnt++;
			}

			// 明細情報を削除
			for (int iFCnt = iDelRow.Length - 1; iFCnt >= 0; iFCnt--)
			{
				if (iDelRow[iFCnt] == Ta010p01Constant.FLG_ON)
				{
					m1List.ListData.RemoveAt(iFCnt);
					m1List.RecordCount = m1List.RecordCount - 1;
				}
			}
			iCnt = 1;
			foreach (Ta010f02M1Form f02m1VO in m1List.ListData)
			{
				f02m1VO.M1rowno = (iCnt).ToString();
				iCnt++;
			}

			// 合計計算処理
			SumGoukeiDetail(f02VO);

			// 削除した分のページを追加
			AddRowCls.AddEmptyPage<Ta010f02M1Form>("M1", "M1rowno", f02VO);
		}
		#endregion
		#region 合計計算処理
		/// <summary>
		/// SumGoukeiDetail 合計計算処理
		/// </summary>
		/// <param name="Ta010f02Form">f02VO</param>
		/// <returns></returns>
		public void SumGoukeiDetail ( Ta010f02Form f02VO)
		{
			decimal dSumSu = 0;		// 合計数量
			decimal dSumKin = 0;	// 合計金額

			foreach (Ta010f02M1Form f02m1VO in  f02VO.GetList("M1").ListData)
			{
				dSumSu += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1irai_su, "0"));					// 合計数量
				dSumKin += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0"));					// 合計金額
			}
			f02VO.Gokei_irai_su = dSumSu.ToString();
			f02VO.Gokei_genkakin = dSumKin.ToString();
		}
		#endregion
		#region 排他チェック
		/// <summary>
		/// ChkUpdHaita 排他チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta010f01M1Form">f01M1Form</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="string">sModeNo</param>
		/// <returns></returns>
		private void ChkUpdHaita ( IFacadeContext facadeContext, Ta010f01M1Form f01M1Form, IDataList m1List, string sModeno)
		{
			#region 排他チェック

			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
			sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
			sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
			sRepSql.Append(" AND KBN_CD = :BIND_KBN_CD");
			String sHaitaTable = "";
			// [選択モードNo]が「申請」の場合
			if (BoSystemConstant.MODE_APPLY.Equals(sModeno))
			{
				// 補充依頼申請TBL(H)を設定
				sHaitaTable = "MDOT0010";
			}
			// [選択モードNo]が「修正」の場合
			else if (BoSystemConstant.MODE_UPD.Equals(sModeno))
			{
				// 会社がXの場合
				if (CheckCompanyCls.IsXebio())
				{
					// 補充依頼申請TBL(H)を設定
					sHaitaTable = "MDOT0010";
				}
				else
				{
					// 補充依頼確定TBL(H)を設定
					sHaitaTable = "MDOT0020";
				}
			}
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();

			// 店舗コード
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD]);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 管理No
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_KANRI_NO";
			bindVO.Value = (string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 処理日付
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYORI_YMD";
			bindVO.Value = (string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 区分コード
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_KBN_CD";
			bindVO.Value = (string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 排他チェック
			V03003Check.CheckHaitaMaxVal(
					Convert.ToDecimal((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1UPD_YMD]),
					Convert.ToDecimal((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1UPD_TM]),
					facadeContext,
					sHaitaTable,
					sRepSql.ToString(),
					bindList,
					1
			);
			#endregion
		}
		#endregion
		#region ストアド(補充依頼／単品レポート登録処理)を起動
		/// <summary>
		/// ストアド(補充依頼／単品レポート登録処理)を起動する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>エラーコード</returns>
		public static void prcInsertOrder ( IFacadeContext facadeContext )
		{
			#region ■パラメータ設定
			ArrayList paramList = new ArrayList();

			#endregion

			// ■補充依頼／単品レポート登録処理呼び出し
			ArrayList al = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, "MDORDER.insertOrder", paramList);

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
					return;
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［MDORDER.insertOrder］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［MDORDER.insertOrder］実行時にエラーが発生しました。");
			}
			#endregion
		}
		#endregion
		#region [補充発注一時TBL]を登録する。(SQL_ID_10,SQL_ID_13,SQL_ID_14)
		/// <summary>
		/// 補充発注明細情報を登録
		///  [補充発注一時TBL][補充依頼申請(B)][補充依頼確定(B)]
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Ta010f01M1Form">f01M1Form 一覧明細選択行</param>
		/// <param name="Ta010f02Form">明細画面のVO</param>
		/// <param name="Ta010f02M1Form">f01M1Form</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="regKbn">登録区分 0:申請TBL 1:確定TBL 2:TempTBL</param>
		/// <param name="dRowNo">行Ｎｏ 登録区分 0:申請TBL 1:確定TBL 2の時、有効</param>
		/// <returns>更新件数</returns>
		public static int Ins_Order ( IFacadeContext facadeContext,
									  Ta010f01M1Form f01M1Form,
									  Ta010f02Form f02VO,
									  Ta010f02M1Form f02m1VO,
									  LoginInfoVO loginInfo,
									  SysDateVO sysDateVO,
									  decimal regKbn,
									  decimal dRowNo)
		{
			FindSqlResultTable reader = null;

			// 登録区分が申請TBLの場合
			if (Ta010p01Constant.REG_KBN_SHINSEI == regKbn)
			{
				// 申請ＴＢＬ更新
				reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_13, facadeContext.DBContext);
			}
			// 登録区分が確定TBLの場合
			else if (Ta010p01Constant.REG_KBN_KAKUTEI == regKbn)
			{
				// 申請ＴＢＬ更新
				reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_14, facadeContext.DBContext);
			}
			// 登録区分がTempTBLの場合
			else if (Ta010p01Constant.REG_KBN_TEMP == regKbn)
			{
				// 申請ＴＢＬ更新
				reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_10, facadeContext.DBContext);
				// 担当者コード
				reader.BindValue("BIND_TANTOSYA_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
				// 依頼理由コード
				reader.BindValue("BIND_IRAIRIYU_CD", Convert.ToDecimal(Ta010p01Util.GetIrairiyu_cd<Ta010f02Form>(f02VO)));
				// 登録日
				reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
				// 登録時間
				reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
				// 登録担当者コード
				reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
				// 単品レポートフラグ設定（明細単位） ＯＮ 単品レポート数量修正フラグ設定 ＯＦＦ かつ 単品登録モードフラグがＯＮの場合は、補充依頼で登録
				if ( Convert.ToString(Ta010p01Constant.FLG_OFF).Equals(f02m1VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_REPORT_FLG])
				 &&  Convert.ToString(Ta010p01Constant.FLG_OFF).Equals(f02m1VO.Dictionary[Ta010p01Constant.DIC_M1TANPIN_UPD_FLG])
				 &&  Convert.ToString(Ta010p01Constant.FLG_ON).Equals(f02VO.Dictionary[Ta010p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
				{
					// 区分コード
					reader.BindValue("BIND_KBN_CD", Convert.ToDecimal(ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN1));			// 補充依頼
				}
				else
				{
					// 区分コード
					reader.BindValue("BIND_KBN_CD", Convert.ToDecimal(BoSystemString.Nvl(f02VO.Kbn_cd, "0")));
				}
			}

			// -------------------------------------------
			// バインド変数の置き換え
			// -------------------------------------------
			// -----------------------------------------------------------------
			// 登録区分がTempTBLでない場合
			if (Ta010p01Constant.REG_KBN_TEMP != regKbn)
			{
				// 管理№
				reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO], "0")));	// 補充依頼入力-一覧(Dictionary)．Ｍ１管理№
				// 処理日付
				reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD], "0")));	// 補充依頼入力-一覧(Dictionary)．Ｍ１処理日付
				// 処理時間
				reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_TM], "0")));	// 補充依頼入力-一覧(Dictionary)．Ｍ１処理時間
				// 行No
				reader.BindValue("BIND_GYO_NO", dRowNo);
				// 依頼数量
				reader.BindValue("BIND_IRAI_KIN", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0")));										// 補充依頼入力-明細．Ｍ１原価金額
				// 区分コード
				reader.BindValue("BIND_KBN_CD", Convert.ToDecimal(f02VO.Kbn_cd));
			}

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1BUMON_CD]));			// 補充依頼入力-明細(Dictionary)．Ｍ１部門コード
			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(BoSystemString.Nvl((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HINSYU_CD], "0")));	// 補充依頼入力-明細(Dictionary)。Ｍ１品種コード
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1BURANDO_CD]));		// 補充依頼入力-明細(Dictionary)．Ｍ１ブランドコード
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));													// 補充依頼入力-明細．Ｍ１自社品番
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1IRO_CD]));					// 補充依頼入力-明細(Dictionary)．Ｍ１色コード
			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1SIZE_CD]));				// 補充依頼入力-明細(Dictionary)．Ｍ１サイズコード	
			// サイズ
			reader.BindValue("BIND_SIZE_NM", f02m1VO.M1size_nm);																					// 補充依頼入力-明細．Ｍ１サイズ
			// JANコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd));															// 補充依頼入力-明細．Ｍ１スキャンコード
			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", BoSystemString.Nvl((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1SYOHIN_CD], "0"));				// 補充依頼入力-明細(Dictionary)．Ｍ１商品コード
			// メーカー品番
			reader.BindValue("BIND_HIN_NBR", f02m1VO.M1maker_hbn);																					// 補充依頼入力-明細。Ｍ１メーカー品番
			// 商品名(カナ)	
			reader.BindValue("BIND_SYONMK", f02m1VO.M1syonmk);																						// 補充依頼入力-明細。Ｍ１商品名(カナ)									
			// 原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0")));										// 補充依頼入力-明細．Ｍ１原単価(隠し)
			// 依頼数量
			reader.BindValue("BIND_IRAI_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1irai_su, "0")));										// 補充依頼入力-明細．Ｍ１依頼数量

			// -----------------------------------------------------------------
			// 登録区分が申請TBL以外の場合
			if (Ta010p01Constant.REG_KBN_SHINSEI != regKbn)
			{
				// 補充発注対象商品区分
				reader.BindValue("BIND_HATYUTAISYO_KB", Convert.ToDecimal(BoSystemString.Nvl((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HATYUTAISYO_KB], "0")));									// 補充依頼入力-明細(Dictionary)．Ｍ１補充発注対象商品区分
				// 評価区分
				reader.BindValue("BIND_HYOKA_KB", BoSystemString.Nvl((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HYOKA_KB]));																		// 補充依頼入力-明細(Dictionary)．Ｍ１評価区分
				// 販売完了日
				reader.BindValue("BIND_HANBAIKANRYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1HANBAIKANRYO_YMD], "0"))));	// 補充依頼入力-明細(Dictionary)．Ｍ１販売完了日
				// 店在庫数
				reader.BindValue("BIND_TENZAIKO_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1tenzaiko_su, "0")));								// 補充依頼入力-明細．Ｍ１店在庫数
				// 入荷予定数
				reader.BindValue("BIND_NYUKAYOTEI_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1nyukayotei_su, "0")));							// 補充依頼入力-明細．Ｍ１入荷予定数
				// 売上実績数
				reader.BindValue("BIND_URIAGE_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1uriage_su, "0")));									// 補充依頼入力-明細．Ｍ１売上実績数
				// 自動定数
				//reader.BindValue("BIND_JIDO_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1jido_su, "0")));										// 補充依頼入力-明細．Ｍ１自動定数
				reader.BindValue("BIND_JIDO_SU", f02m1VO.M1jido_su);																					// 補充依頼入力-明細．Ｍ１自動定数
				// 配分可能数
				reader.BindValue("BIND_HAIBUNKANO_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1haibunkano_su, "0")));							// 補充依頼入力-明細．Ｍ１配分可能数
				// ロット数
				reader.BindValue("BIND_LOT_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1lot_su, "0")));											// 補充依頼入力-明細．Ｍ１ロット数
				// 週合計
				reader.BindValue("BIND_SYUGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1irai_syukei, "0")));								// 補充依頼入力-明細．Ｍ１依頼集計
				// メッセージ区分
				reader.BindValue("BIND_MESSEGE_KB", Convert.ToDecimal(BoSystemString.Nvl(BoSystemString.Nvl((string)f02m1VO.Dictionary[Ta010p01Constant.DIC_M1MESSEGE_KB], "0"))));						// 補充依頼入力-明細．メッセージ区分
			}
			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#region 補充依頼申請TBL(H)を更新する。(SQL_ID_11),(SQL_ID_12)
		/// <summary>
		/// 補充依頼申請TBL(H)を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Ta010f01M1Form">f01M1Form 一覧明細選択行</param>
		/// <param name="Ta010f02Form">f01Form</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="regKbn">登録区分 0:申請TBL 1:確定TBL</param>
		/// <returns>更新件数</returns>
		public static int Upd_Order ( IFacadeContext facadeContext,
									Ta010f01M1Form f01M1Form,
									Ta010f02Form f02Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									decimal regKbn )
		{
			FindSqlResultTable reader = null;

			// 登録区分が申請TBLの場合
			if(Ta010p01Constant.REG_KBN_SHINSEI == regKbn)
			{
				// 申請ＴＢＬ更新
				reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_11, facadeContext.DBContext);
				// 申請状態(0:未申請)
				reader.BindValue("BIND_SHINSEI_FLG", Convert.ToDecimal(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1));
			}
			// 登録区分が確定TBLの場合
			else if(Ta010p01Constant.REG_KBN_KAKUTEI == regKbn)
			{
				// 申請ＴＢＬ更新
				reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_12, facadeContext.DBContext);
				// 申請日
				reader.BindValue("BIND_APPLY_YMD", sysDateVO.Sysdate);
			}
			// 依頼理由コード
			reader.BindValue("BIND_IRAIRIYU_CD", Convert.ToDecimal(Ta010p01Util.GetIrairiyu_cd<Ta010f02Form>(f02Form)));
			// 合計依頼数量
			reader.BindValue("BIND_IRAIGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl(f02Form.Gokei_irai_su, "0")));
			// 合計依頼金額
			reader.BindValue("BIND_IRAIGOKEI_KIN", Convert.ToDecimal(BoSystemString.Nvl(f02Form.Gokei_genkakin, "0")));

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// ---------------------------------
			// 更新ＫＥＹ
			// ---------------------------------
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD]));
			// 管理No
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD]))));
			// 区分コード
			reader.BindValue("BIND_KBN_CD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#region 更新後表示処理
		/// <summary>
		/// DoCopyUpdAfter 更新後表示処理
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Ta010f02Form">f02Form</param>
		/// <param name="Ta010f01M1Form">f01M1Form</param>
		/// <param name="IDataList">m1List</param>
		/// <param name="LoginInfoVO">loginInfo</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <param name="decimal[]">dSumList</param>
		/// <returns></returns>
		private void DoCopyUpdAfter ( IFacadeContext facadeContext
									, Ta010f02Form f02Form
									, Ta010f01M1Form f01M1Form
									, IDataList m1List
									, LoginInfoVO loginInfo
									, SysDateVO sysDateVO
									, decimal[] dSumList)
		{
			// [選択モードNo]が「新規作成」の場合
			if (BoSystemConstant.MODE_INSERT.Equals(f02Form.Stkmodeno))
			{
				// コードビハインド側で設定
				return;
			}

			// 担当者名取得
			Hashtable resultTanto = V01005Check.CheckTanto(loginInfo.TtsCd, facadeContext);
			// 理由名取得
			Mdmt0180Key riyuKey = new Mdmt0180Key();
			if (ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN1.Equals(f02Form.Kbn_cd))
			{
				riyuKey.Gyomu_kb = Ta010p01Constant.RIYU_GYOMU_HOJYU;
			}
			else
			{
				riyuKey.Gyomu_kb = Ta010p01Constant.RIYU_GYOMU_TANPIN;
			}
			riyuKey.Riyu_cd = Convert.ToDecimal(Ta010p01Util.GetIrairiyu_cd<Ta010f02Form>(f02Form));
			Mdmt0180DA riyuDa = CreateDA<Mdmt0180DA>(facadeContext);
			Mdmt0180VO riyuVo = new Mdmt0180VO();
			riyuVo = riyuDa.FindByPrimaryKey(riyuKey);

			// 明細情報を更新する。
			f01M1Form.M1itemsu = dSumList[0].ToString();							// Ｍ１数量　　　		←　Ｍ１依頼数量合計
			f01M1Form.M1genkakin = dSumList[1].ToString();							// Ｍ１原価金額　　		←　Ｍ１原価金額合計
			f01M1Form.M1hanbaiin_nm = resultTanto["HANBAIIN_NM"].ToString();		// Ｍ１担当者名
			f01M1Form.M1irai_riyu = riyuVo.Riyucomment_nm;							// Ｍ１依頼理由

			f01M1Form.Dictionary[Ta010p01Constant.DIC_M1IRAIRIYU_CD] = Ta010p01Util.GetIrairiyu_cd<Ta010f02Form>(f02Form);		// 依頼理由コード

			// [選択モードNo]が「修正」の場合
			if (BoSystemConstant.MODE_UPD.Equals(f02Form.Stkmodeno))
			{
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;												// Ｍ１確定処理フラグ(隠し)
				f01M1Form.Dictionary[Ta010p01Constant.DIC_M1UPD_YMD] = BoSystemFormat.formatDate(sysDateVO.Sysdate);			// 更新日
				f01M1Form.Dictionary[Ta010p01Constant.DIC_M1UPD_TM] = sysDateVO.Systime_mili.ToString();						// 更新時間
			}
			// [選択モードNo]が「申請」の場合
			else if (BoSystemConstant.MODE_APPLY.Equals(f02Form.Stkmodeno))
			{
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;												// Ｍ１確定処理フラグ(隠し)
				Hashtable resultShinsei = V01015Check.CheckMeisyo(Ta010p01Constant.MEISHO_SIKIBETSU_CD_SHINSEI, ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2, facadeContext);
				f01M1Form.M1sinsei_jotainm = resultShinsei["MEISYO_NM"].ToString();		// Ｍ１申請状態名称
				// 申請状態を申請済に変更
				f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SHINSEI_FLG] = ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2;
			}
		}
		#endregion

	}
}
