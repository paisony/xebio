using com.xebio.bo.Tf021p01.Constant;
using com.xebio.bo.Tf021p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.Constant;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01015;
using Common.Business.V01000.V01021;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tf021p01.Facade
{
  /// <summary>
  /// Tf021f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf021f01Facade : StandardBaseFacade
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
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// FormVO取得
				// 画面より情報を取得する。
				Tf021f01Form prevVo = (Tf021f01Form)facadeContext.FormVO;
				Tf021f02Form nextVo = (Tf021f02Form)facadeContext.GetUserObject(Tf021p01Constant.FCDUO_NEXTVO);

				IDataList nextM1List = nextVo.GetList("M1");

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				nextVo.Head_tenpo_nm = string.Empty;
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

				#endregion

				#region 次画面の項目設定

				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = prevVo.Head_tenpo_cd;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = prevVo.Head_tenpo_nm;
				// 登録日
				nextVo.Add_ymd = sysDateVO.Sysdate.ToString();
				// 申請日
				nextVo.Apply_ymd = string.Empty;
				// 申請理由区分(商品破損)
				nextVo.Sinseiriyu_kb = "1";
				// 申請理由
				nextVo.Sinseiriyu = string.Empty;
				// 伝票番号
				nextVo.Denpyo_bango = string.Empty;
				// 管理No
				nextVo.Kanri_no = string.Empty;
				// 科目コード
				nextVo.Kamoku_cd = string.Empty;
				nextVo.Kamoku_nm = string.Empty;
				IList<Hashtable> sinseiRiyu = V01015Check.SearchMeisyo("KHRY", nextVo.Sinseiriyu_kb, facadeContext);
				if (sinseiRiyu != null)
				{
					nextVo.Kamoku_cd = ((Hashtable)sinseiRiyu[0])["MEISYOKANA_NM"].ToString();
					// 科目名
					Hashtable kamokuHash = V01021Check.CheckKamoku(nextVo.Kamoku_cd, facadeContext);
					// 名称をラベルに設定
					if (kamokuHash != null)
					{
						nextVo.Kamoku_nm = kamokuHash["KAMOKU_NM"].ToString();
					}
				}
				// 却下理由
				nextVo.Kyakkariyu = string.Empty;
				// 業務稟議No
				nextVo.Gyomuringi_no = string.Empty;
				// 受理番号
				nextVo.Jyuri_no = string.Empty;
				// 承認状態
				nextVo.Syonin_flg_nm = string.Empty;

                // 明細部
                // 次画面の初期表示件数
                Decimal dInitCnt = nextM1List.DispRow;

                for (int i = 0; i < dInitCnt; i++)
				{
					Tf021f02M1Form f02m1VO = new Tf021f02M1Form();

					// Ｍ１行NO
					f02m1VO.M1rowno = (i + 1).ToString();

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				}

				// 合計数量
				nextVo.Gokei_suryo = "0";
				// 合計金額
				nextVo.Genka_kin_gokei = "0";

				// モードNoを「新規作成」に設定
				prevVo.Stkmodeno = BoSystemConstant.MODE_INSERT;
				nextVo.Stkmodeno = BoSystemConstant.MODE_INSERT;

				#endregion

			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
			//	//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
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
