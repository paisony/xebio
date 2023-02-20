using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using com.xebio.bo.Ta080p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.Constant;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Ta080p01.Facade
{
  /// <summary>
  /// Ta080f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Ta080f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1yosan_cd)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1yosan_cd)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1YOSAN_CD_FRM(IFacadeContext facadeContext)
		{
			////メソッドの開始処理を実行する。
			//StartMethod(facadeContext, this.GetType().Name + ".DoM1YOSAN_CD_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化(共通部分)
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// 画面より情報を取得
				// 遷移元画面
				// Form
				Ta080f01Form prevVo = (Ta080f01Form)facadeContext.FormVO;
				Ta080f01Form prevVoSearchd = (Ta080f01Form)prevVo.Dictionary[Ta080p01Constant.DIC_SEARCH_F01VO];		// 検索実行時の一覧画面
				// 明細リスト
				IDataList prevM1List = prevVo.GetList("M1");
				// 選択行情報取得
				Ta080f01M1Form prevM1Vo = (Ta080f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];
				#endregion

				#region モード[稟議結果照会]の場合
				if (prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_REF_RINGIKEKKA))
				{
					#region 初期化_実績明細

					// 遷移先画面
					// Form
					Ta080f02Form nextVo_02 = (Ta080f02Form)facadeContext.GetUserObject(Ta080p01Constant.FCDUO_NEXTVO_02);
					// 明細リスト
					IDataList nextM1List_02 = nextVo_02.GetList("M1");
					// 一覧の初期化
					nextM1List_02.ClearCacheData();
					nextM1List_02.Clear();

					#endregion

					#region 業務チェック
					// 処理無し
					#endregion

					#region 件数チェック
					// 検索処理の結果件数で判断
					#endregion

					#region 検索処理
					IList<Hashtable> result = DoSelectLink(facadeContext, prevVoSearchd, prevM1Vo);
					// ------------------------------------------------------------------------------------
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion

					#region 後処理

					#region カード部設定

					//	ヘッダ店舗コード	:ヘッダ店舗コード
					nextVo_02.Head_tenpo_cd = prevVoSearchd.Head_tenpo_cd;
					//	ヘッダ店舗名		:ヘッダ店舗名
					nextVo_02.Head_tenpo_nm = prevVoSearchd.Head_tenpo_nm;
					//	年月度				:Ｍ１年月度
					nextVo_02.Yosan_ymd = prevM1Vo.M1yosan_ymd;
					//	仕入枠グループコード:Dictionary.Ｍ１仕入枠グループコード
					nextVo_02.Yosan_cd = prevM1Vo.Dictionary[Ta080p01Constant.DIC_M1YOSAN_CD].ToString();
					//	仕入枠グループ名	:Dictionary.Ｍ１仕入枠グループ名
					nextVo_02.Yosan_nm = prevM1Vo.Dictionary[Ta080p01Constant.DIC_M1YOSAN_NM].ToString();
					//	予算金額			:Ｍ１予算金額
					nextVo_02.Yosan_kin = prevM1Vo.M1yosan_kin;
					//	未申請数			:Ｍ１未申請数
					nextVo_02.Misinsei_su = prevM1Vo.M1misinsei_su;
					//	未申請金額			:Ｍ１未申請金額
					nextVo_02.Misinsei_kin = prevM1Vo.M1misinsei_kin;
					//	申請数				:Ｍ１申請数
					nextVo_02.Apply_su = prevM1Vo.M1applygokei_su;
					//	申請金額			:Ｍ１申請金額
					nextVo_02.Apply_kin	 = prevM1Vo.M1applygokei_kin;
					//	実績数				:Ｍ１実績数
					nextVo_02.Jisseki_su_bo2 = prevM1Vo.M1jissekigokei_su;
					//	実績金額			:Ｍ１実績金額
					nextVo_02.Jisseki_kin = prevM1Vo.M1jissekigokei_kin;
					//	残金額				:Ｍ１残金額
					nextVo_02.Zan_kin = prevM1Vo.M1zan_kin;

					#endregion

					#region 明細部設定
					Ta080p01Util.DoMeisaiCopy(facadeContext, result, prevVoSearchd, prevM1Vo, nextM1List_02);
					#endregion 

					#region フッター部設定
					// フッター部なし
					#endregion

					#region Dictionary設定
					// 選択明細のVO
					nextVo_02.Dictionary[Ta080p01Constant.DIC_M1SELCETVO] = prevM1Vo;
					// 選択行のインデックスを設定
					nextVo_02.Dictionary[Ta080p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
					#endregion
					#endregion
				}
				#endregion

				#region  モード[稟議結果照会]以外の場合
				else
				{
					#region 初期化_明細
					// 遷移先画面
					// Form
					Ta080f03Form nextVo_03 = (Ta080f03Form)facadeContext.GetUserObject(Ta080p01Constant.FCDUO_NEXTVO_03);
					// 明細リスト
					IDataList nextM1List_03 = nextVo_03.GetList("M1");
					// 一覧の初期化
					nextM1List_03.ClearCacheData();
					nextM1List_03.Clear();
					#endregion

					#region 業務チェック
					// 処理無し
					#endregion

					#region 件数チェック
					// 検索処理の結果件数で判断
					#endregion

					#region 検索処理
					IList<Hashtable> result = DoSelectLink(facadeContext, prevVoSearchd, prevM1Vo);
					// ------------------------------------------------------------------------------------
					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					// ------------------------------------------------------------------------------------
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion

					#region 後処理

					#region カード部設定
					// ヘッダ店舗コード
					nextVo_03.Head_tenpo_cd = prevVoSearchd.Head_tenpo_cd;
					// ヘッダ店舗名
					nextVo_03.Head_tenpo_nm = prevVoSearchd.Head_tenpo_nm;
					// 選択モードNO
					nextVo_03.Stkmodeno = prevVoSearchd.Stkmodeno;
					// 明細モードNO			:「予算情報」
					nextVo_03.Meisai_modeno = "Yosan";
					// 明細選択モードNO		:"0"
					nextVo_03.Meisai_stkmodeno = "0";

					#region モード｢予算情報｣項目
					// 年月度				:Ｍ１年月度
					nextVo_03.Yosan_ymd = nextVo_03.Yosan_ymd1 = prevM1Vo.M1yosan_ymd;
					// 仕入枠グループコード	:Ｍ１仕入枠グループリンク
					nextVo_03.Yosan_cd = nextVo_03.Yosan_cd1 = prevM1Vo.Dictionary[Ta080p01Constant.DIC_M1YOSAN_CD].ToString();
					// 仕入枠グループ名		:Ｍ１仕入枠グループリンク
					nextVo_03.Yosan_nm = nextVo_03.Yosan_nm1 = prevM1Vo.Dictionary[Ta080p01Constant.DIC_M1YOSAN_NM].ToString();
					// 予算金額				:Ｍ１予算金額
					nextVo_03.Yosan_kin = prevM1Vo.M1yosan_kin;
					// 未申請数				:Ｍ１未申請数
					nextVo_03.Misinsei_su = prevM1Vo.M1misinsei_su;
					// 未申請金額			:Ｍ１未申請金額
					nextVo_03.Misinsei_kin = prevM1Vo.M1misinsei_kin;
					// 申請数				:Ｍ１申請数
					nextVo_03.Apply_su = prevM1Vo.M1applygokei_su;
					// 申請金額				:Ｍ１申請金額
					nextVo_03.Apply_kin = prevM1Vo.M1applygokei_kin;
					// 実績数				:Ｍ１実績数
					nextVo_03.Jisseki_su = prevM1Vo.M1jissekigokei_su;
					// 実績金額				:Ｍ１実績金額
					nextVo_03.Jisseki_kin = prevM1Vo.M1jissekigokei_kin;
					// 残金額				:Ｍ１残金額
					nextVo_03.Zan_kin = prevM1Vo.M1zan_kin;
					#endregion
					#region モード｢絞込み｣項目

					// 部門コードＦＲＯＭ	:空白
					// 部門名ＦＲＯＭ		:空白
					// 部門コードＴＯ		:空白
					// 部門名ＴＯ			:空白
					// ブランドコード		:空白
					// ブランド名			:空白
					// 旧自社品番			:空白
					// メーカー品番			:空白
					// スキャンコード		:空白
					// 登録日ＦＲＯＭ		:空白
					// 登録日ＴＯ			:空白
					// 登録担当者コード		:空白
					// 登録担当者名			:空白
					nextVo_03.Bumon_cd_from =
					nextVo_03.Bumon_nm_from =
					nextVo_03.Bumon_cd_to =
					nextVo_03.Bumon_nm_from =
					nextVo_03.Burando_cd =
					nextVo_03.Burando_nm =
					nextVo_03.Old_jisya_hbn =
					nextVo_03.Maker_hbn =
					nextVo_03.Scan_cd =
					nextVo_03.Add_ymd_from =
					nextVo_03.Add_ymd_to =
					nextVo_03.Tantosya_cd =
					nextVo_03.Hanbaiin_nm = "";
								
					// 依頼理由コード:空白(ドロップダウン)
					// 店舗評価:空白(ドロップダウン)
					// 全社評価:空白(ドロップダウン)
					nextVo_03.Irairiyu_cd1 =
					nextVo_03.Irairiyu_cd2 =
					nextVo_03.Hyoka_kb_mise =
					nextVo_03.Hyoka_kb_all = BoSystemConstant.DROPDOWNLIST_MISENTAKU;

					// 品種 すべてチェック有
					nextVo_03.Hinsyu_cd_all = 
					nextVo_03.Hinsyu_cd1 = 
					nextVo_03.Hinsyu_cd2 = 
					nextVo_03.Hinsyu_cd3 = 
					nextVo_03.Hinsyu_cd4 = 
					nextVo_03.Hinsyu_cd5 = 
					nextVo_03.Hinsyu_cd6 = 
					nextVo_03.Hinsyu_cd7 = 
					nextVo_03.Hinsyu_cd8 = 
					nextVo_03.Hinsyu_cd9 = "1";

					// 並び順 1:商品順、2:登録日、3:担当者
					nextVo_03.Sortkb1 = "1";
					nextVo_03.Sortkb2 = "14";
					nextVo_03.Sortkb3 = "13";
					// 並び順 オプション1、2、3:昇順
					nextVo_03.Sortoptionkb1 =
					nextVo_03.Sortoptionkb2 =
					nextVo_03.Sortoptionkb3 = ConditionSortoption.VALUE_SORTOPTION1;
					#endregion

					#endregion 

					#region 明細部設定
					decimal[] dRetList = Ta080p01Util.DoMeisaiCopy(facadeContext, result, prevVoSearchd, prevM1Vo, nextM1List_03);
					#endregion 

					#region フッター部設定
					// 合計依頼数量			:Ｍ１依頼数量の合計値
					nextVo_03.Gokei_irai_su = dRetList[0].ToString();
					// 合計原価金額			:Ｍ１原価金額の合計値
					nextVo_03.Gokei_genkakin = dRetList[1].ToString();
					// 残金額				:Ｍ１残金額
					nextVo_03.Footer_zan_kin = prevM1Vo.M1zan_kin;
					#endregion

					#region Dictionary設定
					// 単品フラグ
					if (Ta080p01Constant.KBN_KBN_CD_HOJUIRAI.Equals(prevM1Vo.Dictionary[Ta080p01Constant.DIC_M1KBN_CD]))
					{
						nextVo_03.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG] = Ta080p01Constant.FLG_OFF.ToString();
					}
					else{
						nextVo_03.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG] = Ta080p01Constant.FLG_ON.ToString();
					}
					// 検索時一覧画面のVO
					nextVo_03.Dictionary[Ta080p01Constant.DIC_SEARCH_F01VO] = prevVoSearchd;
					// 選択明細のVO
					nextVo_03.Dictionary[Ta080p01Constant.DIC_M1SELCETVO] = prevM1Vo;
					// 選択行のインデックスを設定
					nextVo_03.Dictionary[Ta080p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

					// 初期合計値をDictionaryに保持 明細画面確定時の一覧明細の更新に使用
					nextVo_03.Dictionary[Ta080p01Constant.DIC_ATODENAMAEKAERU] = dRetList;

					#endregion

					#endregion
				}
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1YOSAN_CD_FRM");

		}
		#endregion
	}
}
