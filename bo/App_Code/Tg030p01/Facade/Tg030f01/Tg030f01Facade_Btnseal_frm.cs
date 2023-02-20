using com.xebio.bo.Tg030p01.Constant;
using com.xebio.bo.Tg030p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.LabelUtil.vo;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01024;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tg030p01.Facade
{
  /// <summary>
  /// Tg030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg030f01Facade : StandardBaseFacade
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
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// FormVO取得
				// 画面より情報を取得する。
				Tg030f01Form f01VO = (Tg030f01Form)facadeContext.FormVO;

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;

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

				// 1-2 枚数
				// 枚数が全て"0"の場合、エラー
				if (f01VO.Maisu.Equals("0"))
				{
					//ErrMsgCls.AddErrMsg("E103", string.Empty, facadeContext);
					ErrMsgCls.AddErrMsg("E103", "発行枚数", facadeContext, new[] { "Label_nm" });
				}
					
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				

				// 1-3 担当者コード
				//  担当者MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tantosya_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Tantosya_cd, facadeContext, "担当者コード", new[] { "Tantosya_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Hanbaiin_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 1-4 担当者コード２
				//	担当者コード２と担当者コード比較、違うならエラー
				if (f01VO.Tantosya_cd != f01VO.Tantosya_cd2)
				{
					ErrMsgCls.AddErrMsg("E153", string.Empty, facadeContext);
				}
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				

				// 1-5 ラベル発行機名
				// ラベル発行機名が空白（未選択）の場合、エラー
				if (string.IsNullOrEmpty(f01VO.Label_nm))
				{
					ErrMsgCls.AddErrMsg("E119", "ラベル発行機", facadeContext, new[] { "Label_nm" });
				}

				// ラベル発行機が存在しない場合、エラー
				Hashtable resultHashLABELCD = new Hashtable();

				resultHashLABELCD = V01024Check.CheckLabel(logininfo.TnpCd, f01VO.Label_cd, facadeContext, "ラベル発行機", new[] { "Label_cd" });

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 社員シール

				// プライスシールのレイアウト
				string printID = string.Empty;
				// プライスシールのCSVデータ
				string tmpFileName = string.Empty;

				// プライスシールデータを設定
				List<EmployeecodeSealVO> sealList = new List<EmployeecodeSealVO>();

				EmployeecodeSealVO sealVo = new EmployeecodeSealVO();

				sealVo.Syaincd = f01VO.Tantosya_cd;											// 社員コード
				sealVo.Syainnm = f01VO.Hanbaiin_nm;											// 社員名
				sealVo.Hakosu = f01VO.Maisu;												// 発行枚数											
				sealList.Add(sealVo);


				// 社員シールのレイアウト名を取得
				printID = BoSystemLabelData.GetEmployeeCodeSealLayout();

				// 社員シールのCSVデータ作成
				tmpFileName = BoSystemLabelData.CreateCsvEmployeeCodeSeal(PGID, sealList, printID);
				#endregion

				// CSVファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg030p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
				// レイアウトファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg030p01Constant.FCDUO_SEAL_LAYOUTNM, new List<string>(){ printID + BoSystemConstant.LABEL_NM_EXTENTS });

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
		