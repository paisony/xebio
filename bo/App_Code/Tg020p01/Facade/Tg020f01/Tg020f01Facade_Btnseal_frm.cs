using com.xebio.bo.Tg020p01.Constant;
using com.xebio.bo.Tg020p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.LabelUtil.vo;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01024;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Util;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tg020p01.Facade
{
  /// <summary>
  /// Tg020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg020f01Facade : StandardBaseFacade
	{
		
		// フォームを呼び出します。(ボタンID : Btnseal)
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

			////メソッドの開始処理を実行する。
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
				Tg020f01Form f01VO = (Tg020f01Form)facadeContext.FormVO;

				// 選択モードNoの初期化
				f01VO.Stkmodeno = string.Empty;

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				#endregion

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
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
				// 1-2  ラベル発行機名が空白（未選択）の場合、エラー
				if (string.IsNullOrEmpty(f01VO.Label_nm))
				{
					ErrMsgCls.AddErrMsg("E119", "ラベル発行機", facadeContext, new[] { "Label_nm" });
				}
				else
				{
					// 1-3 ラベル発行機が存在しない場合、エラー
					Hashtable resultHashLABELCD = new Hashtable();

					resultHashLABELCD = V01024Check.CheckLabel(logininfo.TnpCd, f01VO.Label_cd, facadeContext, "ラベル発行機", new[] { "Label_cd" });
				}
				
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				
				//[選択モードNo]が[%OFF]の場合 BTNMODE 
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_PERCENTOFF))
				{
					// 2-1 割引率が"0"の場合、エラー
					if (f01VO.Waririt.Equals("0"))
					{
						ErrMsgCls.AddErrMsg("E103", "割引率", facadeContext, new[] { "Waririt" });
					}
					else
					{
						//割引率が空白の場合、エラー
						if (string.IsNullOrEmpty(f01VO.Waririt))
						{
							ErrMsgCls.AddErrMsg("E121", "割引率", facadeContext, new[] { "Waririt" });
						}
					}

					// 2-2 枚数が全て"0"の場合、エラー
					if (f01VO.Maisu.Equals("0"))
					{
						ErrMsgCls.AddErrMsg("E103", "発行枚数", facadeContext, new[] { "Maisu" });
					}
					else
					{
						//枚数が空白の場合、エラー
						if (string.IsNullOrEmpty(f01VO.Maisu))
						{
							ErrMsgCls.AddErrMsg("E121", "発行枚数", facadeContext, new[] { "Maisu" });
						}
					}
				}


				// [選択モードNo]が[円引き]の場合 BTNMODEYENHIKI
				else
				{
					// 3-1 割引額が"0"の場合、エラー
					if (f01VO.Warigak.Equals("0"))
					{
						ErrMsgCls.AddErrMsg("E103", "割引額", facadeContext, new[] { "Warigak" });
					}
					else
					{
						//割引額が空白の場合、エラー
						if (string.IsNullOrEmpty(f01VO.Warigak))
						{
							ErrMsgCls.AddErrMsg("E121", "割引額", facadeContext, new[] { "Warigak" });
						}
					}

					// 3-2 枚数２が"0"の場合、エラー
					if (f01VO.Maisu2.Equals("0"))
					{
						ErrMsgCls.AddErrMsg("E103", "発行枚数", facadeContext, new[] { "Maisu2" });
					}
					else
					{
						//枚数２が空白の場合、エラー
						if (string.IsNullOrEmpty(f01VO.Maisu2))
						{
							ErrMsgCls.AddErrMsg("E121", "発行枚数", facadeContext, new[] { "Maisu2" });
						}
					}
				}
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。f
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				
				#endregion

				#region 割引シール発行

				// プライスシールのレイアウト
				string printID = string.Empty;
				// プライスシールのCSVデータ
				string tmpFileName = string.Empty;

				// プライスシールデータを設定
				List<DiscountSealVO> sealList = new List<DiscountSealVO>();

				DiscountSealVO sealVo = new DiscountSealVO();
				//[選択モードNo]が[%OFF]の場合 BTNMODE 
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_PERCENTOFF))
				{
					if (f01VO.Inji_comment == "3")
					{
						sealVo.Comment = f01VO.Inji_comment_nm;
					}else
					{
						sealVo.Comment = ConditionUtil.GetLabel(ConditionInji_comment.ID, f01VO.Inji_comment);		// 01 コメント１
					}
						sealVo.Discountitem = f01VO.Waririt;								//  02 割引項目
						sealVo.Discountsb = "1";											// 種別
						sealVo.Hakosu = f01VO.Maisu;										// 発行数	
					

				}
				else
				{
					if (f01VO.Inji_comment2 == "3")
					{
						sealVo.Comment = f01VO.Inji_comment_nm2;
					}
					else
					{
						sealVo.Comment = ConditionUtil.GetLabel(ConditionInji_comment.ID, f01VO.Inji_comment2);		// 01 コメント１
					}

					sealVo.Discountitem = f01VO.Warigak;								//  02 割引項目
					sealVo.Discountsb = "2";											// 種別
					sealVo.Hakosu = f01VO.Maisu2;										// 発行数	

				}

				sealList.Add(sealVo);

				// 割引シールのレイアウト名を取得
				printID = BoSystemLabelData.GetDiscountSealLayout();

				// 割引シールのCSVデータ作成
				tmpFileName = BoSystemLabelData.CreateCsvtDiscountSeal(PGID, sealList, printID);

				// CSVファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg020p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
				// レイアウトファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg020p01Constant.FCDUO_SEAL_LAYOUTNM, new List<string>() { printID + BoSystemConstant.LABEL_NM_EXTENTS });

				#endregion

			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
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

	}
}
