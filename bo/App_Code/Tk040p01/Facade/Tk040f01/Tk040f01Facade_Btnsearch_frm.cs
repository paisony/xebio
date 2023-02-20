using com.xebio.bo.Tk040p01.Constant;
using com.xebio.bo.Tk040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01004;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tk040p01.Facade
{
  /// <summary>
  /// Tk040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk040f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnsearch)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsearch)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEARCH_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// ログイン情報取得
				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tk040f01Form formVO = (Tk040f01Form)facadeContext.FormVO;
				IDataList m1List = formVO.GetList("M1");

				#region 初期化

				// ディクショナリのクリア
				formVO.Dictionary.Clear();

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				#region 1. 単項目チェック

				// 1-1 ヘッダ店舗コード
				//       店舗MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(formVO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(formVO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						formVO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// 1-2 旧自社品番～旧自社品番５
				//       発注MSTを検索し、存在しない場合エラー
				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD1] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Old_jisya_hbn,	// 旧自社品番
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番1", new[] { "Old_jisya_hbn" });
					if (hs != null)
					{
						// 自社品番をディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD1] = (string)hs["XEBIO_CD"];
					}
				}

				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD2] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn2))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Old_jisya_hbn2,	// 旧自社品番
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番2", new[] { "Old_jisya_hbn2" });
					if (hs != null)
					{
						// 自社品番をディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD2] = (string)hs["XEBIO_CD"];
					}
				}

				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD3] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn3))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Old_jisya_hbn3,	// 旧自社品番
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番3", new[] { "Old_jisya_hbn3" });
					if (hs != null)
					{
						// 自社品番をディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD3] = (string)hs["XEBIO_CD"];
					}
				}

				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD4] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn4))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Old_jisya_hbn4,	// 旧自社品番
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番4", new[] { "Old_jisya_hbn4" });
					if (hs != null)
					{
						// 自社品番をディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD4] = (string)hs["XEBIO_CD"];
					}
				}

				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD5] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn5))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Old_jisya_hbn5,	// 旧自社品番
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番5", new[] { "Old_jisya_hbn5" });
					if (hs != null)
					{
						// 自社品番をディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD5] = (string)hs["XEBIO_CD"];
					}
				}

				// 1-3 スキャンコード～スキャンコード５
				//       発注MSTを検索し、存在しない場合エラー
				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD1] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Scan_cd))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Scan_cd,			// スキャンコード
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ1", new[] { "Scan_cd" });
					if (hs != null)
					{
						// JANコードをディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD1] = (string)hs["JAN_CD"];
					}
				}

				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD2] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Scan_cd2))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Scan_cd2,		// スキャンコード
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ2", new[] { "Scan_cd2" });
					if (hs != null)
					{
						// JANコードをディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD2] = (string)hs["JAN_CD"];
					}
				}

				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD3] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Scan_cd3))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Scan_cd3,		// スキャンコード
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ3", new[] { "Scan_cd3" });
					if (hs != null)
					{
						// JANコードをディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD3] = (string)hs["JAN_CD"];
					}
				}

				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD4] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Scan_cd4))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Scan_cd4,		// スキャンコード
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ4", new[] { "Scan_cd4" });
					if (hs != null)
					{
						// JANコードをディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD4] = (string)hs["JAN_CD"];
					}
				}

				formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD5] = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Scan_cd5))
				{
					SearchHachuVO searchConditionVO = new SearchHachuVO(
						formVO.Scan_cd5,		// スキャンコード
						formVO.Head_tenpo_cd,	// 店舗コード
						0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
						0,						// 売変 検索フラグ 0:検索しない 1:検索する
						0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
						0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
						0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
						0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
						0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
						"",						// 指示NO（移動出荷マニュアル、返品マニュアル用）
						"",						// 出荷会社コード（移動出荷マニュアル)
						"",						// 入荷会社コード（移動出荷マニュアル)
						""						// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
					);
					Hashtable hs = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ5", new[] { "Scan_cd5" });
					if (hs != null)
					{
						// JANコードをディクショナリに退避
						formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD5] = (string)hs["JAN_CD"];
					}
				}


				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 2. 関連チェック

				// 2-1 部門コードFROM、部門コードTO
				//       部門コードＦＲＯＭ > 部門コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(formVO.Bumon_cd_from) &&
					!string.IsNullOrEmpty(formVO.Bumon_cd_to))
				{
					V03002Check.CodeFromToChk(formVO.Bumon_cd_from,
											  formVO.Bumon_cd_to,
											  facadeContext,
											  "部門",
											  new[] { "Bumon_cd_from", "Bumon_cd_to" }
											 );
				}

				// 2-2 販売完了日FROM、販売完了日TO
				//       販売完了日FROM > 販売完了日TOの場合エラー
				if (!string.IsNullOrEmpty(formVO.Hanbaikanryo_ymd_from) &&
					!string.IsNullOrEmpty(formVO.Hanbaikanryo_ymd_to))
				{
					V03001Check.DateFromToChk(formVO.Hanbaikanryo_ymd_from,
											  formVO.Hanbaikanryo_ymd_to,
											  facadeContext,
											  "販売完了日",
											  new[] { "Hanbaikanryo_ymd_from", "Hanbaikanryo_ymd_to" }
											 );
				}


				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 2. 関連チェック

				// 3-1 棚卸データ
				//       棚卸実施日テーブルを取得し、指定店舗の最大棚卸基準日を取得できなかった場合エラー

				// 営業日の取得
				SysDateVO sysDateChkVO = SysdateCls.GetSysdateTime(facadeContext);

				// 棚卸実施日TBLの検索
				formVO.Dictionary[Tk040p01Constant.DIC_TANAOROSHIKIJUNYMD] = string.Empty;
				Hashtable hsMdit0030Chk = new Hashtable();
				hsMdit0030Chk = SearchInventory.SearchMdit0030Last(BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd),
																	sysDateChkVO.Sysdate.ToString(),
																	facadeContext,
																	0);
				if (hsMdit0030Chk == null)
				{
					ErrMsgCls.AddErrMsg("E170", string.Empty, facadeContext, new[] { "Head_tenpo_cd" });
				}
				else
				{
					formVO.Dictionary[Tk040p01Constant.DIC_TANAOROSHIKIJUNYMD] = Convert.ToString(hsMdit0030Chk["TANAOROSIKIJUN_YMD"]);
				}


				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 件数チェック

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tk040p01Constant.SQL_ID_01, facadeContext.DBContext);
				// 検索条件設定
				ReplaceWherePart(formVO, rtChk, (string)formVO.Dictionary[Tk040p01Constant.DIC_TANAOROSHIKIJUNYMD]);

				#region SQL実行

				Decimal dCnt = 0;

				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();
				BoSystemLog.logOut("SQL: " + rtChk.LogSql);

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];
					dCnt = (Decimal)resultTbl["CNT"];

					// 0件チェック
					if (dCnt <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						// 最大件数チェック
						V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tk040p01Constant.SQL_ID_02, facadeContext.DBContext);
				// 検索条件設定
				ReplaceWherePart(formVO, rtSeach, (string)formVO.Dictionary[Tk040p01Constant.DIC_TANAOROSHIKIJUNYMD]);

				#region SQL実行

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				// 検索時の自社品番、スキャンコードを取得
				string xebiocd1 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD1];
				string xebiocd2 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD2];
				string xebiocd3 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD3];
				string xebiocd4 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD4];
				string xebiocd5 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD5];
				string scanCd1 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD1];
				string scanCd2 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD2];
				string scanCd3 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD3];
				string scanCd4 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD4];
				string scanCd5 = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD5];

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tk040f01M1Form m1formVO = new Tk040f01M1Form();

					// Ｍ１行NO
					m1formVO.M1rowno = iCnt.ToString();
					// Ｍ１部門コード
					m1formVO.M1bumon_cd = rec["BUMON_CD"].ToString();
					// Ｍ１部門カナ名
					m1formVO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();
					// Ｍ１品種略名称
					m1formVO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();
					// Ｍ１ブランド名
					m1formVO.M1burando_nm = rec["BURANDO_NMK"].ToString();
					// Ｍ１自社品番
					m1formVO.M1jisya_hbn = rec["JISYA_HBN"].ToString();
					// Ｍ１メーカー品番
					m1formVO.M1maker_hbn = rec["MAKER_HBN"].ToString();
					// Ｍ１商品名(カナ)
					m1formVO.M1syonmk = rec["SYONMK"].ToString();
					// Ｍ１販売完了日
					if ("0".Equals(rec["HANBAIKANRYO_YMD"].ToString()))
					{
						m1formVO.M1hanbaikanryo_ymd = string.Empty;
					}
					else
					{
						m1formVO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();
					}
					// Ｍ１色
					m1formVO.M1iro_nm = rec["IRO_NM"].ToString();
					// Ｍ１サイズ
					m1formVO.M1size_nm = rec["SIZE_NM"].ToString();
					// Ｍ１スキャンコード
					m1formVO.M1scan_cd = rec["JAN_CD"].ToString();
					// Ｍ１フェイスＮｏ
					m1formVO.M1face_no = rec["FACE_NO"].ToString();
					// Ｍ１棚段
					m1formVO.M1tana_dan = rec["TANA_DAN"].ToString();
					// Ｍ１棚卸数量
					m1formVO.M1tanaorosi_su = rec["TANAOROSIGOKEI_SU"].ToString();

					// Ｍ１選択フラグ(隠し)
					m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					// Ｍ１明細色区分(隠し)
					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;
					}
					else
					{
						if (m1formVO.M1jisya_hbn.Equals(xebiocd1)
							|| m1formVO.M1jisya_hbn.Equals(xebiocd2)
							|| m1formVO.M1jisya_hbn.Equals(xebiocd3)
							|| m1formVO.M1jisya_hbn.Equals(xebiocd4)
							|| m1formVO.M1jisya_hbn.Equals(xebiocd5)
							|| m1formVO.M1scan_cd.Equals(xebiocd1)
							|| m1formVO.M1scan_cd.Equals(scanCd2)
							|| m1formVO.M1scan_cd.Equals(scanCd3)
							|| m1formVO.M1scan_cd.Equals(scanCd4)
							|| m1formVO.M1scan_cd.Equals(scanCd5))
						{
							// 一覧の検索条件で指定した自社品番、スキャンコードと一致する場合、背景色を変える
							m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
						}
						else
						{
							m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
						}
					}

					// Dictionary保存
					//// 更新日
					//m1formVO.Dictionary.Add(Tk040p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());
					//// 更新時間
					//m1formVO.Dictionary.Add(Tk040p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());

					//// 回数
					//m1formVO.Dictionary.Add(Tk040p01Constant.DIC_M1KAI_SU, rec["KAI_SU"].ToString());
					//// 棚卸日
					//m1formVO.Dictionary.Add(Tk040p01Constant.DIC_M1TANAOROSI_YMD, rec["TANAOROSI_YMD"].ToString());
					//// 送信回数
					//m1formVO.Dictionary.Add(Tk040p01Constant.DIC_M1SOSINKAI_SU, rec["SOSINKAI_SU"].ToString());


					//リストオブジェクトにM1Formを追加します。
					m1List.Add(m1formVO, true);
				}

				// 検索件数の設定
				formVO.Searchcnt = m1List.Count.ToString();

				#endregion

				#endregion

				#region Dictionary保存（カード部）

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(formVO);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// ReplaceWherePart 検索条件設定
		/// </summary>
		/// <param name="formVO">Tk040f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="prmTanaorosikijun_ymd">棚卸基準日</param>
		/// <returns></returns>
		private void ReplaceWherePart(Tk040f01Form formVO, FindSqlResultTable reader, string prmTanaorosikijun_ymd)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
			// 店舗コードを設定
			reader.ReplaceAdd("REPLACE_ID_TENPO_CD", " AND T1.TENPO_CD = ");
			reader.ReplaceAddBind("REPLACE_ID_TENPO_CD", "BIND01");
			reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

			// 棚卸日を設定
			if (!string.IsNullOrEmpty(prmTanaorosikijun_ymd))
			{
				reader.ReplaceAdd("REPLACE_ID_TANAOROSI_YMD", " AND T1.TANAOROSI_YMD = ");
				reader.ReplaceAddBind("REPLACE_ID_TANAOROSI_YMD", "BIND02");
				reader.BindValue("BIND02", Convert.ToDecimal(BoSystemString.Nvl(prmTanaorosikijun_ymd, "0")));
			}

			// 部門コードFROMを設定
			if (!string.IsNullOrEmpty(formVO.Bumon_cd_from))
			{
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD_FROM", " AND T1.BUMON_CD >= ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD_FROM", "BIND03");
				reader.BindValue("BIND03", BoSystemFormat.formatBumonCd(formVO.Bumon_cd_from));
			}

			// 部門コードTOを設定
			if (!string.IsNullOrEmpty(formVO.Bumon_cd_to))
			{
				reader.ReplaceAdd("REPLACE_ID_BUMON_CD_TO", " AND T1.BUMON_CD <= ");
				reader.ReplaceAddBind("REPLACE_ID_BUMON_CD_TO", "BIND04");
				reader.BindValue("BIND04", BoSystemFormat.formatBumonCd(formVO.Bumon_cd_to));
			}

			// 販売完了日FROMを設定
			if (!string.IsNullOrEmpty(formVO.Hanbaikanryo_ymd_from))
			{
				reader.ReplaceAdd("REPLACE_ID_HANBAIKANRYO_YMD_FROM", " AND T1.HANBAIKANRYO_YMD >= ");
				reader.ReplaceAddBind("REPLACE_ID_HANBAIKANRYO_YMD_FROM", "BIND05");
				reader.BindValue("BIND05", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Hanbaikanryo_ymd_from)));
			}

			// 販売完了日TOを設定
			if (!string.IsNullOrEmpty(formVO.Hanbaikanryo_ymd_to))
			{
				reader.ReplaceAdd("REPLACE_ID_HANBAIKANRYO_YMD_TO", " AND T1.HANBAIKANRYO_YMD <= ");
				reader.ReplaceAddBind("REPLACE_ID_HANBAIKANRYO_YMD_TO", "BIND06");
				reader.BindValue("BIND06", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Hanbaikanryo_ymd_to)));
			}

			// 自社品番を設定
			if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn) ||
				!string.IsNullOrEmpty(formVO.Old_jisya_hbn2) ||
				!string.IsNullOrEmpty(formVO.Old_jisya_hbn3) ||
				!string.IsNullOrEmpty(formVO.Old_jisya_hbn4) ||
				!string.IsNullOrEmpty(formVO.Old_jisya_hbn5))
			{
				string strjisya_hbn = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn))
				{
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T1.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T1.JISYA_HBN = :BIND_JISYA_HBN01 ";
					//}
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISYA_HBN01";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD1];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn2))
				{
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn2).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T1.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn2) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T1.JISYA_HBN = :BIND_JISYA_HBN02";
					//}
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISYA_HBN02";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD2];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn3))
				{
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn3).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T1.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn3) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T1.JISYA_HBN = :BIND_JISYA_HBN03 ";
					//}
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISYA_HBN03";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD3];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn4))
				{
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn4).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T1.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn4) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T1.JISYA_HBN = :BIND_JISYA_HBN04 ";
					//}
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISYA_HBN04";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD4];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn5))
				{
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn5).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T1.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn5) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T1.JISYA_HBN = :BIND_JISYA_HBN05 ";
					//}
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISYA_HBN05";
					bindVO.Value =  (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_XEBIOCD5] ;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 最初の""OR を削除
				strjisya_hbn = strjisya_hbn.Substring(3);

				string strSqljisyahbn = string.Empty;
				strSqljisyahbn = strSqljisyahbn + " AND (" + strjisya_hbn + ")";

				BoSystemSql.AddSql(reader, "REPLACE_ID_JISYA_HBN", strSqljisyahbn, bindList);
			}

			// スキャンコードを設定
			bindList = new ArrayList();
			if (!string.IsNullOrEmpty(formVO.Scan_cd) ||
				!string.IsNullOrEmpty(formVO.Scan_cd2) ||
				!string.IsNullOrEmpty(formVO.Scan_cd3) ||
				!string.IsNullOrEmpty(formVO.Scan_cd4) ||
				!string.IsNullOrEmpty(formVO.Scan_cd5))
			{
				string strScancd = string.Empty;
				if (!string.IsNullOrEmpty(formVO.Scan_cd))
				{
					strScancd = strScancd + ", :BIND_SCAN_CD01 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD01";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD1];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				if (!string.IsNullOrEmpty(formVO.Scan_cd2))
				{
					strScancd = strScancd + ", :BIND_SCAN_CD02 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD02";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD2];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				if (!string.IsNullOrEmpty(formVO.Scan_cd3))
				{
					strScancd = strScancd + ", :BIND_SCAN_CD03";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD03";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD3];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				if (!string.IsNullOrEmpty(formVO.Scan_cd4))
				{
					strScancd = strScancd + ", :BIND_SCAN_CD04 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD04";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD4];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				if (!string.IsNullOrEmpty(formVO.Scan_cd5))
				{
					strScancd = strScancd + ", :BIND_SCAN_CD05 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD05";
					bindVO.Value = (string)formVO.Dictionary[Tk040p01Constant.DIC_SEARCH_JANCD5];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 最初のカンマを削除
				strScancd = strScancd.Substring(1);

				string strSqlScancd = string.Empty;
				strSqlScancd = strSqlScancd + " AND T1.JAN_CD IN(" + strScancd + ")";

				BoSystemSql.AddSql(reader, "REPLACE_ID_SCAN_CD", strSqlScancd, bindList);
			}

		}
		#endregion
	}
}
