using com.xebio.bo.Th010p01.Constant;
using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01019;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.LabelUtil.vo;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01024;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Th010p01.Facade
{
  /// <summary>
  /// Th010f03のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th010f03Facade : StandardBaseFacade
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
				Th010f03Form f03VO = (Th010f03Form)facadeContext.FormVO;
				IDataList m1List = f03VO.GetList("M1");

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();
				#endregion

				#region 業務チェック

				#region Ｍ１枚数
				int iNullCnt = 0;
				int iZeroCnt = 0;
				for (int iRow = 0; m1List.Count > iRow; iRow++ )
				{
					// 明細行の情報を取得する。
					Th010f03M1Form f03M1Vo = (Th010f03M1Form)m1List[iRow];

					// 枚数が未入力の場合
					if (string.IsNullOrEmpty(f03M1Vo.M1maisu))
					{
						iNullCnt ++;
					}
					// 枚数が0の場合
					if (BoSystemString.Nvl(f03M1Vo.M1maisu, "0").Equals("0"))
					{
						iZeroCnt ++;
					}
				}
				// 枚数が全て未入力の場合、エラー
				if (iNullCnt == m1List.Count)
				{
					ErrMsgCls.AddErrMsg("E121", "枚数", facadeContext, new[] { "M1maisu" });
				}
				else
				{
					// 枚数が全て"0"の場合、エラー
					if (iZeroCnt == m1List.Count)
					{
						ErrMsgCls.AddErrMsg("E188", string.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region ラベル発行機名
				// ラベル発行機名が空白（未選択）の場合、エラー
				if (string.IsNullOrEmpty(f03VO.Label_nm))
				{
					ErrMsgCls.AddErrMsg("E119", "ラベル発行機", facadeContext, new[] { "Label_nm" });
				}

				// ラベル発行機が存在しない場合、エラー
				Hashtable resultHashLABELCD = new Hashtable();

				resultHashLABELCD = V01024Check.CheckLabel(logininfo.TnpCd, f03VO.Label_cd, facadeContext, "ラベル発行機", new[] { "Label_cd" });

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region シール発行処理

				// プライスシールのレイアウト
				string printID = string.Empty;
				// プライスシールのCSVデータ
				string tmpFileName = string.Empty;


				// プライスシールデータを設定
				List<PriceSealVO> sealList = new List<PriceSealVO>();

				var sealIds = new List<string>();

				int layoutkbn;
				// Xの場合
				if (CheckCompanyCls.IsXebio())
				{
					layoutkbn = Convert.ToInt16(f03VO.Layout);
				}
				else
				{
					layoutkbn = 1;
				}
				
				for (int i = 0; i < m1List.Count; i++)
				{
					Th010f03M1Form f03m1VO = (Th010f03M1Form)m1List[i];

					// 枚数が設定されている行が対象
					if (!string.IsNullOrEmpty(f03m1VO.M1maisu) && !BoSystemString.Nvl(f03m1VO.M1maisu, "0").Equals("0"))
					{
						PriceSealVO sealVo = new PriceSealVO();
						string sealtype = "4";	// シールタイプ(Def:10%)
						if(BoSystemString.Nvl(f03VO.Syutsuryoku_seal, "0").Equals("9"))
						{
							//自動判別の場合
							sealtype = (string)f03m1VO.Dictionary[Th010p01Constant.DIC_M1ZEIRITSU_CD];
						}
						else
						{
							// その他の場合
							sealtype = BoSystemString.Nvl(f03VO.Syutsuryoku_seal, "4");
						}
						CalcTaxCls Tax = new CalcTaxCls(facadeContext, Convert.ToInt32(sealtype));

						TaxVO taxVo = Tax.calcTax(f03m1VO.Dictionary[Th010p01Constant.DIC_M1SAISINBAIKA_TNK].ToString(), (decimal)f03m1VO.Dictionary[Th010p01Constant.DIC_M1ZEI_KB]);

						sealVo.Tenpocd = f03VO.Head_tenpo_cd;											// 店舗コード
						sealVo.Bumoncd = f03VO.Bumon_cd;												// 部門コード
						sealVo.Hinsyucd = f03VO.Hinsyu_cd;												// 品種コード
						sealVo.Brandnm = f03VO.Burando_nm;												// ブランド名
						sealVo.Hinmei = f03VO.Syonmk;													// 品名
						sealVo.Jisyahbn = f03VO.Jisya_hbn;												// 自社品番
						sealVo.Iro = f03m1VO.M1iro_nm;													// 色
						sealVo.Size = f03m1VO.M1size_nm;												// サイズ
						sealVo.Syohinkb = (string)f03VO.Dictionary[Th010p01Constant.DIC_M1ITEMKBN];		// 商品区分
						sealVo.Siirekb = (string)f03VO.Dictionary[Th010p01Constant.DIC_M1SIIRE_KB];		// 仕入区分
						sealVo.Hanbaikanryo = f03VO.Hanbaikanryo_ymd;									// 販売完了日
						sealVo.Chotatsu = (string)f03VO.Dictionary[Th010p01Constant.DIC_M1TYOTATSU_KB];	// 調達区分
						sealVo.Makerkibokakaku = f03VO.Makerkakaku_tnk;									// メーカー希望小売価格
						sealVo.Baika = taxVo.Zeinuki.ToString();										// 売価
						sealVo.Zeikomikakaku = taxVo.Zeikomi.ToString();								// 税込価格
						sealVo.Jan = f03m1VO.M1scan_cd;													// JAN
						sealVo.Siirecd = f03VO.Siiresaki_cd;											// 仕入先コード
						sealVo.Makerhbn = f03VO.Maker_hbn;												// メーカー品番
						sealVo.Hakosu = f03m1VO.M1maisu;												// 発行枚数
						sealList.Add(sealVo);
						sealVo.Layoutnm = BoSystemLabelData.GetPriceSealLayout(Convert.ToInt16(sealtype), layoutkbn) + BoSystemConstant.LABEL_NM_EXTENTS;
						if (!sealIds.Contains(sealVo.Layoutnm))
							sealIds.Add(sealVo.Layoutnm);
					}
				}

				// プライスシールのレイアウト名を取得
				int zeikbn = Convert.ToInt16(f03VO.Syutsuryoku_seal);

				printID = BoSystemLabelData.GetPriceSealLayout(zeikbn, layoutkbn);
				// プライスシールのCSVデータ作成
				tmpFileName = BoSystemLabelData.CreateCsvPriceSeal(PGID, sealList, printID);

				// CSVファイルをユーザマップに設定
				facadeContext.UserMap.Add(Th010p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
				// レイアウトファイルをユーザマップに設定
				facadeContext.UserMap.Add(Th010p01Constant.FCDUO_SEAL_LAYOUTNM, sealIds);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEAL_FRM");

		}
		#endregion
	}
}
