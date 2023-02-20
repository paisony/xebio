using com.xebio.bo.Tg010p01.Constant;
using com.xebio.bo.Tg010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
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

namespace com.xebio.bo.Tg010p01.Facade
{
  /// <summary>
  /// Tg010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg010f01Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEAL_FRM");

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

				#endregion

				#region 業務チェック

				#region 1 入力値チェック

				#region 1-1 選択行
				// 1件も選択されていない場合、エラー 
				if (m1List == null || m1List.Count <= 0)
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tg010f01M1Form m1formVO = (Tg010f01M1Form)m1List[i];
						if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 印刷する行を選択して下さい。
						ErrMsgCls.AddErrMsg("E119", "発行する行", facadeContext);
					}
				}
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#region 1-2 ラベル発行機名
				// ラベル発行機名が空白（未選択）の場合、エラー 
				if (string.IsNullOrEmpty(f01VO.Label_nm))
				{
					// ラベル発行機を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "ラベル発行機", facadeContext);
				}
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 2 単項目チェック
				// 選択状態がONの明細行がチェック対象
				for (int i = 0; i < m1List.Count; i++)
				{
					Tg010f01M1Form f01m1VO = (Tg010f01M1Form)m1List[i];
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						#region 2-1 Ｍ１スキャンコード
						// スキャンコードが未入力の場合、エラー :E121 ①"スキャンコード"
						if (string.IsNullOrEmpty(f01m1VO.M1scan_cd))
						{
							ErrMsgCls.AddErrMsg("E121", "スキャンコード", facadeContext, new[] { "M1scan_cd" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
						#endregion

						#region 2-2 Ｍ１枚数
						// 枚数が未入力の場合、エラー :E121 ①"枚数"
						if (string.IsNullOrEmpty(f01m1VO.M1maisu))
						{
							ErrMsgCls.AddErrMsg("E121", "枚数", facadeContext, new[] { "M1maisu" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
						#endregion
						#region 2-3 Ｍ１枚数
						// 枚数が"0"の場合、エラー :E188 -								
						if (f01m1VO.M1maisu == "0")
						{
							ErrMsgCls.AddErrMsg("E188", string.Empty, facadeContext, new[] { "M1maisu" }, f01m1VO.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
						#endregion
					}
				}
				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#region 3 マスタチェック
				// 選択状態がONの明細行がチェック対象

				var SealTypeDic = new Dictionary<string, string>();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tg010f01M1Form f01m1VO = (Tg010f01M1Form)m1List[i];
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						#region 3-1 Ｍ１スキャンコード
						// V01004			
						SearchHachuVO searchConditionVO = new SearchHachuVO(
							f01m1VO.M1scan_cd,		// スキャンコード
							f01VO.Head_tenpo_cd,	// 店舗コード
							1,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
							1,						// 売変 検索フラグ 0:検索しない 1:検索する
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

						Hashtable resultHash = V01004Check.CheckScanCd(
																searchConditionVO,
																facadeContext,
																"スキャンコード",
																new[] { "M1scan_cd" },
																f01m1VO.M1rowno,
																i.ToString(),
																"M1",
																m1List.DispRow
														);

                        // 取得エラー時は次の行へ移動
                        if (resultHash == null)
                        {
                            continue;
                        }

						// 税率計算クラス
						string sealtype = "4";	// シールタイプ(Def:10%)
						if (BoSystemString.Nvl(f01VO.Syutsuryoku_seal, "0").Equals("9"))
						{
							// 自動判別の場合
							sealtype = resultHash["TAX_CD"].ToString();
						}
						else
						{
							// その他の場合
							sealtype = BoSystemString.Nvl(f01VO.Syutsuryoku_seal, "4");
						}
						// ディクショナリにシールタイプ情報を設定
						SealTypeDic.Add(f01m1VO.M1rowno, sealtype);
						CalcTaxCls calcTax = new CalcTaxCls(facadeContext, Convert.ToInt32(sealtype));
						TaxVO taxvo = new TaxVO();

          // 税込金額計算
          taxvo = calcTax.calcTax(resultHash["BAIKA"].ToString(), Convert.ToDecimal(resultHash["ZEI_KB"]));

						f01m1VO.M1baika_zei = taxvo.Zeikomi.ToString();						// Ｍ１税込価格（隠し）
						#endregion
					}
				}
				#region 3-2 ラベル発行機名
				// ラベル発行機が存在しない場合、エラー 
				Hashtable labelTbl = V01024Check.CheckLabel(BoSystemFormat.formatTenpoCd(logininfo.TnpCd)
										   , f01VO.Label_cd
										   , facadeContext
										   , "ラベル発行機"
										   , new[] { "Label_nm" });
				#endregion

				#endregion
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region シール発行処理

				string sealID = string.Empty;

				// シールのCSVデータ
				string tmpFileName = string.Empty;

				// プライスシールデータを設定
				List<PriceSealVO> sealList = new List<PriceSealVO>();

				var sealIds = new List<string>();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tg010f01M1Form f01m1VO = (Tg010f01M1Form)m1List[i];

					// 選択されている行が対象
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// シールレイアウト情報を取得
						sealID = BoSystemLabelData.GetPriceSealLayout(Convert.ToInt16(SealTypeDic[f01m1VO.M1rowno]), 1);
						if (!sealIds.Contains(sealID + BoSystemConstant.LABEL_NM_EXTENTS))
							sealIds.Add(sealID + BoSystemConstant.LABEL_NM_EXTENTS);

						PriceSealVO sealVo = new PriceSealVO();
						sealVo.Tenpocd = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);					// 店舗コード
						sealVo.Bumoncd = BoSystemFormat.formatBumonCd(f01m1VO.M1bumon_cd);					// 部門コード
						sealVo.Hinsyucd = BoSystemFormat.formatHinsyuCd(f01m1VO.M1hinsyu_cd);				// 品種コード
						sealVo.Brandnm = f01m1VO.M1burando_nm;												// ブランド名
						sealVo.Hinmei = f01m1VO.M1syonmk;													// 品名
						sealVo.Jisyahbn = BoSystemFormat.formatJisyaHbn(f01m1VO.M1jisya_hbn);				// 自社品番
						sealVo.Iro = f01m1VO.M1iro_nm;														// 色
						sealVo.Size = f01m1VO.M1size_nm;													// サイズ
						sealVo.Syohinkb = f01m1VO.M1itemkbn;												// 商品区分
						sealVo.Siirekb = f01m1VO.M1siire_kb;												// 仕入区分
						sealVo.Hanbaikanryo = f01m1VO.M1hanbaikanryo_ymd;									// 販売完了日
						sealVo.Chotatsu = f01m1VO.M1tyotatsu_kb;											// 調達区分
						sealVo.Makerkibokakaku = f01m1VO.M1makerkakaku_tnk;									// メーカー希望小売価格
						sealVo.Baika = f01m1VO.M1saisinbaika_tnk;											// 売価
						sealVo.Zeikomikakaku = f01m1VO.M1baika_zei;											// 税込価格
						sealVo.Jan = BoSystemFormat.formatJanCd(f01m1VO.M1scan_cd);							// JAN
						sealVo.Siirecd = BoSystemFormat.formatSiiresakiCd(f01m1VO.M1siiresaki_cd_bo1);		// 仕入先コード
						sealVo.Makerhbn = f01m1VO.M1maker_hbn;												// メーカー品番
						sealVo.Hakosu = f01m1VO.M1maisu;													// 発行枚数
						sealVo.Layoutnm = sealID + BoSystemConstant.LABEL_NM_EXTENTS;						// シールレイアウト情報
						sealList.Add(sealVo);
					}
				}

				// プライスシールのCSVデータ作成
				tmpFileName = BoSystemLabelData.CreateCsvPriceSeal(PGID, sealList, sealID);
				// CSVファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg010p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
				// レイアウトファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg010p01Constant.FCDUO_SEAL_LAYOUTNM, sealIds);

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
