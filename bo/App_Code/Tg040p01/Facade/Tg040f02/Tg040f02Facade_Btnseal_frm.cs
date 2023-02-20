using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.LabelUtil.vo;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01024;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnseal)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnseal)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEAL_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEAL_FRM");

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
				Tg040f02Form f02VO = (Tg040f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				#endregion

				#region 業務チェック
				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1List[i];
						if (f02m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						ErrMsgCls.AddErrMsg("E119", "発行する行", facadeContext);
					}
				}

				#region ラベル発行機名
				// 1-2 
				// ラベル発行機名が空白（未選択）の場合、エラー
				if (string.IsNullOrEmpty(f02VO.Label_nm))
				{
					ErrMsgCls.AddErrMsg("E119", "ラベル発行機", facadeContext, new[] { "Label_nm" });
				}

				// 1-3 
				// ラベル発行機が存在しない場合、エラー
				Hashtable resultHashLABELCD = new Hashtable();

				resultHashLABELCD = V01024Check.CheckLabel(logininfo.TnpCd, f02VO.Label_cd, facadeContext, "ラベル発行機", new[] { "Label_cd" });

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				#endregion

				#region スキャンコード

				string sealtype = "4";									// 初期値設定
				var DicSealType = new Dictionary<string, string>();		// 初期値設定

				for (int iRow = 0; iRow < m1List.Count; iRow++)
				{
					// 明細情報取得
					Tg040f02M1Form f02m1VO_scan = (Tg040f02M1Form)m1List[iRow];

					// スキャンコードか数量が入力されている行がチェック対象
					if (!string.IsNullOrEmpty(f02m1VO_scan.M1scan_cd) && !string.IsNullOrEmpty(f02m1VO_scan.M1suryo))
					{
						//Ｍ１スキャンコード：発注MSTに存在しない場合、エラー
						SearchHachuVO searchConditionVO = new SearchHachuVO(
							f02m1VO_scan.M1scan_cd,	// スキャンコード
							f02VO.Head_tenpo_cd,	// 店舗コード
							0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
							0,						// 売変 検索フラグ 0:検索しない 1:検索する
							2,						// 店在庫 検索フラグ 0:検索しない 1:検索する
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
								f02m1VO_scan.M1rowno,
								iRow.ToString(),
								"M1",
								Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper()))
						);

						if (syohinData != null)
						{
							// シール発行
							f02m1VO_scan.M1bumon_cd = syohinData["BUMON_CD"].ToString();					// 部門コード
							f02m1VO_scan.M1hinsyu_cd = syohinData["HINSYU_CD"].ToString();					// 品種コード
							f02m1VO_scan.M1burando_nm = syohinData["BURANDO_NMK"].ToString();				// ブランド名
							f02m1VO_scan.M1syonmk = syohinData["SYONMK"].ToString();						// 品名
							f02m1VO_scan.M1jisya_hbn = syohinData["XEBIO_CD"].ToString();					// 自社品番
							f02m1VO_scan.M1iro_nm = syohinData["IRO_NM"].ToString();						// 色
							f02m1VO_scan.M1size_nm = syohinData["SIZE_NM"].ToString();						// サイズ
							f02m1VO_scan.M1hanbaikanryo_ymd = syohinData["HANBAIKANRYO_YMD"].ToString();	// 販売完了日
							f02m1VO_scan.M1maker_hbn = syohinData["HIN_NBR"].ToString();					// メーカー品番
							f02m1VO_scan.Dictionary[Tg040p01Constant.DIC_M1ZEI_KB] = (decimal)syohinData["ZEI_KB"];		// Ｍ１税区分
							f02m1VO_scan.Dictionary[Tg040p01Constant.DIC_M1ITEMKBN] = syohinData["ITEMKBN"].ToString();			// Ｍ１商品区分
							f02m1VO_scan.Dictionary[Tg040p01Constant.DIC_M1SIIRE_KB] = syohinData["SIIRE_KB"].ToString();		// Ｍ１仕入区分
							f02m1VO_scan.Dictionary[Tg040p01Constant.DIC_M1TYOTATSU_KB] = syohinData["TYOTATSU_KB"].ToString();	// Ｍ１調達区分

							f02m1VO_scan.Dictionary[Tg040p01Constant.DIC_SLPR] = (decimal)syohinData["SLPR"];			// 最新売価
							f02m1VO_scan.Dictionary[Tg040p01Constant.DIC_JODAI2_TNK] = syohinData["JODAI2_TNK"].ToString();		// メーカー希望小売価格
							f02m1VO_scan.Dictionary[Tg040p01Constant.DIC_SIIRESAKI_CD] = syohinData["SIIRESAKI_CD"].ToString();	// 仕入先コード
						}
						sealtype = syohinData["TAX_CD"].ToString();					// 税率コードを取得
						DicSealType.Add(f02m1VO_scan.M1rowno, sealtype);			// dictinaryで行数をKeyに税率コードをValueで格納
					}
				}
				#endregion

				#region シール発行処理

				// プライスシールのレイアウト
				string printID = string.Empty;
				// プライスシールのCSVデータ
				string tmpFileName = string.Empty;

				// プライスシールデータを設定
				List<PriceSealVO> sealList = new List<PriceSealVO>();

				var sealIds = new List<string>();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tg040f02M1Form f02m1VO = (Tg040f02M1Form)m1List[i];

					// 選択されている行が対象
					if (!string.IsNullOrEmpty(f02m1VO.M1selectorcheckbox) 
						&& f02m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON)
						&& !string.IsNullOrEmpty(f02m1VO.M1scan_cd)
						&& !string.IsNullOrEmpty(f02m1VO.M1suryo)
						)
					{
						PriceSealVO sealVo = new PriceSealVO();

						// 行番号で税率コードを取得し、税別に計算を行う
						sealtype = DicSealType[f02m1VO.M1rowno];
						CalcTaxCls Tax = new CalcTaxCls(facadeContext, Convert.ToInt32(sealtype));
						TaxVO taxVo = Tax.calcTax((decimal)f02m1VO.Dictionary[Tg040p01Constant.DIC_SLPR]
												, (decimal)f02m1VO.Dictionary[Tg040p01Constant.DIC_M1ZEI_KB]);			
						sealVo.Tenpocd = f02VO.Head_tenpo_cd;												// 店舗コード
						sealVo.Bumoncd = f02m1VO.M1bumon_cd;												// 部門コード
						sealVo.Hinsyucd = f02m1VO.M1hinsyu_cd;												// 品種コード
						sealVo.Brandnm = f02m1VO.M1burando_nm;												// ブランド名
						sealVo.Hinmei = f02m1VO.M1syonmk;													// 品名
						sealVo.Jisyahbn = f02m1VO.M1jisya_hbn;												// 自社品番
						sealVo.Iro = f02m1VO.M1iro_nm;														// 色
						sealVo.Size = f02m1VO.M1size_nm;													// サイズ
						sealVo.Syohinkb = (string)f02m1VO.Dictionary[Tg040p01Constant.DIC_M1ITEMKBN];		// 商品区分
						sealVo.Siirekb = (string)f02m1VO.Dictionary[Tg040p01Constant.DIC_M1SIIRE_KB];		// 仕入区分
						sealVo.Hanbaikanryo = f02m1VO.M1hanbaikanryo_ymd;									// 販売完了日
						sealVo.Chotatsu = (string)f02m1VO.Dictionary[Tg040p01Constant.DIC_M1TYOTATSU_KB];	// 調達区分
						sealVo.Makerkibokakaku = (string)f02m1VO.Dictionary[Tg040p01Constant.DIC_JODAI2_TNK];	// メーカー希望小売価格
						sealVo.Baika = taxVo.Zeinuki.ToString();											// 売価
						sealVo.Zeikomikakaku = taxVo.Zeikomi.ToString();									// 税込価格
						sealVo.Jan = f02m1VO.M1scan_cd;														// JAN
						sealVo.Siirecd = (string)f02m1VO.Dictionary[Tg040p01Constant.DIC_SIIRESAKI_CD];			// 仕入先コード
						sealVo.Makerhbn = f02m1VO.M1maker_hbn;												// メーカー品番
						sealVo.Hakosu = BoSystemString.Nvl(f02m1VO.M1suryo, "0");							// 発行枚数
						// シールレイアウト情報を取得
						sealVo.Layoutnm = BoSystemLabelData.GetPriceSealLayout(Convert.ToInt16(sealtype), 1) + BoSystemConstant.LABEL_NM_EXTENTS;
						if (!sealIds.Contains(sealVo.Layoutnm))
							sealIds.Add(sealVo.Layoutnm);

						sealList.Add(sealVo);
					}
				}

				if (sealList.Count > 0)
				{

					//// プライスシールのレイアウト名を取得
					printID = BoSystemLabelData.GetPriceSealLayout(4, 1);	// 10%固定
					// プライスシールのCSVデータ作成
					tmpFileName = BoSystemLabelData.CreateCsvPriceSeal(PGID, sealList, printID);

					// CSVファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tg040p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
					// レイアウトファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tg040p01Constant.FCDUO_SEAL_LAYOUTNM, sealIds);

				}
				#endregion

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEAL_FRM");

		}
		#endregion
	}
}
