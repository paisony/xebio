using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Business.V01000.V01001;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btninsert)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btninsert)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNINSERT_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNINSERT_FRM");

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
				Tg040f01Form prevVo = (Tg040f01Form)facadeContext.FormVO;
				Tg040f02Form nextVo = (Tg040f02Form)facadeContext.GetUserObject(Tg040p01Constant.FCDUO_NEXTVO);

				// 選択モードNoの初期化
				prevVo.Stkmodeno = string.Empty;

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 一覧の初期化
				prevM1List.ClearCacheData(); 
				nextM1List.ClearCacheData();
				prevM1List.Clear();
				nextM1List.Clear();
				#endregion

				#region 業務チェック
				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(prevVo.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(prevVo.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						nextVo.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}
				
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 次画面の項目設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = prevVo.Head_tenpo_cd;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = prevVo.Head_tenpo_nm;
				// 選択モードNO
				nextVo.Stkmodeno = BoSystemConstant.MODE_INSERT;
				// ストック№
				nextVo.Stock_no = string.Empty;
				//日付
				nextVo.Ymd = string.Empty;
				//時間
				nextVo.Tm = string.Empty;
				//入力担当者コード
				nextVo.Nyuryokutan_cd = string.Empty;
				//入力担当者名称
				nextVo.Nyuryokutan_nm = string.Empty;

                // Cookieが存在する場合、保存したラベル発行機IDを設定、存在しない場合は空白
                //ラベル発行機ＩＤ
                //ラベル発行機ＩＰ
                //ラベル発行機名

                // 明細部

                // 次画面の初期表示件数
                Decimal dInitCnt = nextM1List.DispRow;

                for (int i = 0; i < dInitCnt; i++)
				{
					Tg040f02M1Form f02m1VO = new Tg040f02M1Form();

					// Ｍ１行NO
					f02m1VO.M1rowno = (i + 1).ToString();

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				}

				// 合計数量
				nextVo.Gokei_suryo = string.Empty;

				// モードNo
				prevVo.Stkmodeno = BoSystemConstant.MODE_INSERT;
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNINSERT_FRM");

		}
		#endregion
	}
}
