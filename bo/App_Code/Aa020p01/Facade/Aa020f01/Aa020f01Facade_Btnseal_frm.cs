using com.xebio.bo.Aa020p01.Constant;
using com.xebio.bo.Aa020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.LabelUtil.vo;
using Common.Standard.Base;
using System.Collections.Generic;

namespace com.xebio.bo.Aa020p01.Facade
{
  /// <summary>
  /// Aa020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Aa020f01Facade : StandardBaseFacade
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
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				Aa020f01Form f01VO = (Aa020f01Form)facadeContext.FormVO;

				// プライスシールのレイアウト
				string printID = string.Empty;
				// プライスシールのCSVデータ
				string tmpFileName = string.Empty;


				if (f01VO.Head_tenpo_cd.Equals("0299"))
				{
					#region プライスシール
					// プライスシールデータを設定
					List<PriceSealVO> sealList = new List<PriceSealVO>();

					PriceSealVO sealVo = new PriceSealVO();
					sealVo.Tenpocd = "0299";			// 店舗コード
					sealVo.Bumoncd = "123";				// 部門コード
					sealVo.Hinsyucd = "1";				// 品種コード
					sealVo.Brandnm = "NIKE";			// ブランド名
					sealVo.Hinmei = "ｼﾞｬｰｼﾞ";			// 品名
					sealVo.Jisyahbn = "00000123";		// 自社品番
					sealVo.Iro = "RED";					// 色
					sealVo.Size = "LL";					// サイズ
					sealVo.Syohinkb = "1";				// 商品区分
					sealVo.Siirekb = "2";				// 仕入区分
					sealVo.Hanbaikanryo = "20160331";	// 販売完了日
					sealVo.Chotatsu = "3";				// 調達区分
					sealVo.Makerkibokakaku = "9999";	// メーカー希望小売価格
					sealVo.Baika = "7777";				// 売価
					sealVo.Zeikomikakaku = "8888";		// 税込価格
					sealVo.Jan = "2600000033060";		// JAN
					sealVo.Siirecd = "0005";			// 仕入先コード
					sealVo.Makerhbn = "R1230909-1";		// メーカー品番
					sealVo.Hakosu = "1";				// 発行枚数
					sealList.Add(sealVo);

					sealVo = new PriceSealVO();
					sealVo.Tenpocd = "0299";			// 店舗コード
					sealVo.Bumoncd = "123";				// 部門コード
					sealVo.Hinsyucd = "1";				// 品種コード
					sealVo.Brandnm = "NIKE";			// ブランド名
					sealVo.Hinmei = "ｼﾞｬｰｼﾞ";			// 品名
					sealVo.Jisyahbn = "00000123";		// 自社品番
					sealVo.Iro = "RED";					// 色
					sealVo.Size = "LL";					// サイズ
					sealVo.Syohinkb = "1";				// 商品区分
					sealVo.Siirekb = "2";				// 仕入区分
					sealVo.Hanbaikanryo = "20160331";	// 販売完了日
					sealVo.Chotatsu = "3";				// 調達区分
					sealVo.Makerkibokakaku = "9999";	// メーカー希望小売価格
					sealVo.Baika = "7777";				// 売価
					sealVo.Zeikomikakaku = "8888";		// 税込価格
					sealVo.Jan = "49772050";			// JAN
					sealVo.Siirecd = "0005";			// 仕入先コード
					sealVo.Makerhbn = "R1230909-1";		// メーカー品番
					sealVo.Hakosu = "1";				// 発行枚数
					sealList.Add(sealVo);



					// プライスシールのレイアウト名を取得
					printID = BoSystemLabelData.GetPriceSealLayout(1, 1);

					// プライスシールのCSVデータ作成
					tmpFileName = BoSystemLabelData.CreateCsvPriceSeal(PGID, sealList, printID);
					#endregion
				}
				else if (f01VO.Head_tenpo_cd.Equals("0309"))
				{
					#region 売変シール
					// 売変シールデータを設定
					List<PriceChangeSealVO> sealList = new List<PriceChangeSealVO>();

					PriceChangeSealVO sealVo = new PriceChangeSealVO();
					sealVo.Zeikomikakaku = "9999";		// 税込価格
					sealVo.Labelnm = "特別売価";		// ラベル名
					sealVo.Baika = "8888";				// 売価
					sealVo.Hakosu = "4";				// 発行数
					sealList.Add(sealVo);

					sealVo = new PriceChangeSealVO();
					sealVo.Zeikomikakaku = "12345";		// 税込価格
					sealVo.Labelnm = "特別売価";		// ラベル名
					sealVo.Baika = "11234";				// 売価
					sealVo.Hakosu = "2";				// 発行数
					sealList.Add(sealVo);

					// 売変シールのレイアウト名を取得
					printID = BoSystemLabelData.GetPriceChangeSealLayout(1);

					// 売変シールのCSVデータ作成
					tmpFileName = BoSystemLabelData.CreateCsvPriceChangeSeal(PGID, sealList, printID);
					#endregion
				}
				else if (f01VO.Head_tenpo_cd.Equals("0018"))
				{
					#region 割引シール
					// 割引シールデータを設定
					List<DiscountSealVO> sealList = new List<DiscountSealVO>();

					DiscountSealVO sealVo = new DiscountSealVO();
					sealVo.Comment = "表示価格から";	// コメント
					sealVo.Discountitem = "50";			// 割引項目
					sealVo.Discountsb = "1";			// 種別
					sealVo.Hakosu = "1";				// 発行数
					sealList.Add(sealVo);

					sealVo = new DiscountSealVO();
					sealVo.Comment = "表示金額から";	// コメント
					sealVo.Discountitem = "5000";		// 割引項目
					sealVo.Discountsb = "2";			// 種別
					sealVo.Hakosu = "1";				// 発行数
					sealList.Add(sealVo);

					// 割引シールのレイアウト名を取得
					printID = BoSystemLabelData.GetDiscountSealLayout();

					// 割引シールのCSVデータ作成
					tmpFileName = BoSystemLabelData.CreateCsvtDiscountSeal(PGID, sealList, printID);
					#endregion
				}
				else if (f01VO.Head_tenpo_cd.Equals("0029"))
				{
					#region 社員シール
					// 社員シールデータを設定
					List<EmployeecodeSealVO> sealList = new List<EmployeecodeSealVO>();

					EmployeecodeSealVO sealVo = new EmployeecodeSealVO();
					sealVo.Syaincd = "2999991";		// 社員コード
					sealVo.Syainnm = "富士通担当者（Ｘシステム";	// 社員名
					sealVo.Hakosu = "1";			// 発行数
					sealList.Add(sealVo);

					// 社員シールのレイアウト名を取得
					printID = BoSystemLabelData.GetEmployeeCodeSealLayout();

					// 社員シールのCSVデータ作成
					tmpFileName = BoSystemLabelData.CreateCsvEmployeeCodeSeal(PGID, sealList, printID);
					#endregion
				}

				// CSVファイルをユーザマップに設定
				facadeContext.UserMap.Add(Aa020p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
				// レイアウトファイルをユーザマップに設定
				facadeContext.UserMap.Add(Aa020p01Constant.FCDUO_SEAL_LAYOUTNM, printID + BoSystemConstant.LABEL_NM_EXTENTS);
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
