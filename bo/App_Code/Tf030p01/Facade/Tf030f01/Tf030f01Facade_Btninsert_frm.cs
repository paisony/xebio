using com.xebio.bo.Tf030p01.Constant;
using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01008;
using Common.Business.C99999.Constant;
using Common.Business.V01000.V01001;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Tf030p01.Facade
{
  /// <summary>
  /// Tf030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf030f01Facade : StandardBaseFacade
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

				// ログイン情報取得
				LoginInfoVO loginInfo = LoginInfoUtil.GetLoginInfo();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// FormVO取得
				// 画面より情報を取得する。
				Tf030f01Form prevVo = (Tf030f01Form)facadeContext.FormVO;
				Tf030f02Form nextVo = (Tf030f02Form)facadeContext.GetUserObject(Tf030p01Constant.FCDUO_NEXTVO);

				IDataList nextM1List = nextVo.GetList("M1");

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				prevVo.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(prevVo.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(prevVo.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						prevVo.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
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
				// 選択モードNO
				nextVo.Stkmodeno = BoSystemConstant.MODE_INSERT;
				// 登録日
				nextVo.Add_ymd = sysDateVO.Sysdate.ToString();

				// 店舗コード・店舗名
				if (CheckKengenCls.CheckKengen(loginInfo))
				{
					nextVo.Tenpo_cd = string.Empty;
					nextVo.Tenpo_nm = string.Empty;
				}
				else
				{
					nextVo.Tenpo_cd = loginInfo.TnpCd;
					nextVo.Tenpo_nm = loginInfo.Tnprksmes;
				}

				// 検品者コード
				nextVo.Kenpinsya_cd = string.Empty;
				// 検品者名
				nextVo.Kenpinsya_nm = string.Empty;
				// 仕入先コード
				nextVo.Siiresaki_cd = string.Empty;
				// 仕入先略式名称
				nextVo.Siiresaki_ryaku_nm = string.Empty;
				// 伝票番号
				nextVo.Denpyo_bango = string.Empty;
				// 元伝票番号
				nextVo.Motodenpyo_bango = string.Empty;
				// 入力担当者コード
				nextVo.Nyuryokutan_cd = loginInfo.TtsCd;
				// 入力担当者名称
				nextVo.Nyuryokutan_nm = loginInfo.TtsMei;
				// 納品日
				nextVo.Nohin_ymd = string.Empty;

				// 明細部
				// コンフィグファイルより次画面の最大件数を取得
				Decimal dMaxCnt = GetMaxCntCls.GetMaxCnt(Tf030p01Constant.FORMID_02.ToUpper());

				for (int i = 0; i < dMaxCnt; i++)
				{
					Tf030f02M1Form f02m1VO = new Tf030f02M1Form();

					// Ｍ１行NO
					f02m1VO.M1rowno = (i + 1).ToString();

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				}

				// 合計数量
				nextVo.Gokei_suryo = "0";
				// 合計金額
				nextVo.Gokei_kin = "0";

				// モードNoを「新規作成」に設定
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
