using com.xebio.bo.Tj040p01.Constant;
using com.xebio.bo.Tj040p01.Formvo;
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
using Common.Business.V01000.V01005;
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

namespace com.xebio.bo.Tj040p01.Facade
{
  /// <summary>
  /// Tj040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj040f01Facade : StandardBaseFacade
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
                Tj040f01Form formVO = (Tj040f01Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                #region 初期化

                // ディクショナリのクリア
                formVO.Dictionary.Clear();

				// 選択モードNoの初期化
				formVO.Stkmodeno = string.Empty;

                // 一覧の初期化
                m1List.ClearCacheData();
                m1List.Clear();

                #endregion

				#region 業務チェック

				if (formVO.Modeno.Equals(BoSystemConstant.MODE_UPD)
					|| formVO.Modeno.Equals(BoSystemConstant.MODE_DEL))
				{
					// 取消モードの場合
					// 店舗／業者、送信日、送信状態の条件を初期化
					formVO.Tenpo_gyosya_kb = BoSystemConstant.DROPDOWNLIST_MISENTAKU;
					formVO.Sosin_ymd_from = String.Empty;
					formVO.Sosin_ymd_to = String.Empty;
					formVO.Sosin_jyotai = BoSystemConstant.DROPDOWNLIST_MISENTAKU;
				}

                #region 1. 単項目チェック

                // 1-1 ヘッダ店舗コード
                //       店舗マスタを検索し、存在しない場合エラー
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

                // 1-2 棚段FROM
                //       1～16の範囲内でない場合、エラー
                if (!string.IsNullOrEmpty(formVO.Tana_dan_from))
                {
                    if (!(int.Parse(formVO.Tana_dan_from) >= 1 &&
						  int.Parse(formVO.Tana_dan_from) <= BoSystemConstant.TANA_DAN_MAX_X))
                    {
						ErrMsgCls.AddErrMsg("E173", new[] { "棚段FROM", "1", BoSystemConstant.TANA_DAN_MAX_X.ToString() }, facadeContext, new[] { "Tana_dan_from" });
                    }
                }

                // 1-3 棚段TO
                //       1～16の範囲内でない場合、エラー
                if (!string.IsNullOrEmpty(formVO.Tana_dan_to))
                {
                    if (!(int.Parse(formVO.Tana_dan_to) >= 1 &&
						  int.Parse(formVO.Tana_dan_to) <= BoSystemConstant.TANA_DAN_MAX_X))
                    {
						ErrMsgCls.AddErrMsg("E173", new[] { "棚段TO", "1", BoSystemConstant.TANA_DAN_MAX_X.ToString() }, facadeContext, new[] { "Tana_dan_to" });
                    }
                }

                // 1-4 入力担当者コード
                //       担当者MSTを検索し、存在しない場合エラー
                if (!string.IsNullOrEmpty(formVO.Nyuryokutan_cd))
                {
                    Hashtable resultHash = new Hashtable();
                    resultHash = V01005Check.CheckTanto(formVO.Nyuryokutan_cd
														, facadeContext
														, string.Empty
														, null
														, "入力担当者"
														, new[] { "Nyuryokutan_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
                    // 名称をラベルに設定
                    if (resultHash != null)
                    {
						formVO.Nyuryokutan_nm = (string)resultHash["HANBAIIN_NM"];
                    }
                }

                // 1-5 旧自社品番～旧自社品番５
				//       発注MSTを検索し、存在しない場合エラー
				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD1] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD1] = (string)hs["XEBIO_CD"];
					}
                }

				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD2] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD2] = (string)hs["XEBIO_CD"];
					}
                }

				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD3] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD3] = (string)hs["XEBIO_CD"];
					}
                }

				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD4] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD4] = (string)hs["XEBIO_CD"];
					}
                }

				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD5] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD5] = (string)hs["XEBIO_CD"];
					}
                }

                // 1-6 スキャンコード～スキャンコード５
				//       発注MSTを検索し、存在しない場合エラー
				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD1] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD1] = (string)hs["JAN_CD"];
					}
                }

				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD2] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD2] = (string)hs["JAN_CD"];
					}
                }

				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD3] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD3] = (string)hs["JAN_CD"];
					}
                }

				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD4] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD4] = (string)hs["JAN_CD"];
					}
                }

				formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD5] = string.Empty;
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
						formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD5] = (string)hs["JAN_CD"];
					}
                }


                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion


                #region 2. 関連チェック

                // 2-1 フェイス№FROM、フェイス№TO
                //       フェイス№FROM > フェイス№TOの場合エラー
                if (!string.IsNullOrEmpty(formVO.Face_no_from) &&
                    !string.IsNullOrEmpty(formVO.Face_no_to))
                {
					V03002Check.CodeFromToChk(formVO.Face_no_from,
												formVO.Face_no_to,
												facadeContext,
												"フェイスNo",
												new[] { "Face_no_from", "Face_no_to" }
												);
                }

                // 2-2 棚段FROM、棚段TO
                //       棚段FROM > 棚段TOの場合エラー
                if (!string.IsNullOrEmpty(formVO.Tana_dan_from) &&
                    !string.IsNullOrEmpty(formVO.Tana_dan_to))
                {
                    V03002Check.CodeFromToChk(formVO.Tana_dan_from,
                                              formVO.Tana_dan_to,
                                              facadeContext,
                                              "棚段",
                                              new[] { "Tana_dan_from", "Tana_dan_to" }
                                             );
                }

                // 2-3 入力日FROM、入力日TO
                //       入力日FROM > 入力日TOの場合エラー
                if (!string.IsNullOrEmpty(formVO.Nyuryoku_ymd_from) &&
                    !string.IsNullOrEmpty(formVO.Nyuryoku_ymd_to))
                {
                    V03001Check.DateFromToChk(formVO.Nyuryoku_ymd_from,
                                              formVO.Nyuryoku_ymd_to,
                                              facadeContext,
                                              "入力日",
                                              new[] { "Nyuryoku_ymd_from", "Nyuryoku_ymd_to" }
                                             );
                }

                // 2-4 送信日FROM、送信日TO
                //       送信日FROM > 送信日TOの場合エラー
                if (!string.IsNullOrEmpty(formVO.Sosin_ymd_from) &&
                    !string.IsNullOrEmpty(formVO.Sosin_ymd_to))
                {
                    V03001Check.DateFromToChk(formVO.Sosin_ymd_from,
                                              formVO.Sosin_ymd_to,
                                              facadeContext,
                                              "送信日",
                                              new[] { "Sosin_ymd_from", "Sosin_ymd_to" }
                                             );
                }


                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion


                #region 3. 関連チェック

				//// 3-1 店舗／業者区分
				////       モードが修正、取消の場合、業者を選択した場合エラー                
				//if (!string.IsNullOrEmpty(formVO.Tenpo_gyosya_kb))
				//{
				//	if (ConditionTenpo_gyosya_kbn.VALUE_GYOSYA.Equals(formVO.Tenpo_gyosya_kb))
				//	{
				//		if (BoSystemConstant.MODE_UPD.Equals(formVO.Modeno))
				//		{
				//			ErrMsgCls.AddErrMsg("E155", "修正", facadeContext, new[] { "Tenpo_gyosya_kb" });
				//		}
				//		else if (BoSystemConstant.MODE_DEL.Equals(formVO.Modeno))
				//		{
				//			ErrMsgCls.AddErrMsg("E155", "取消", facadeContext, new[] { "Tenpo_gyosya_kb" });
				//		}
				//	}
				//}

                // 3-2 ヘッダ店舗コード
                //       モードが修正、取消の場合、棚卸終了の場合エラー                
				if (BoSystemConstant.MODE_UPD.Equals(formVO.Modeno) ||
					BoSystemConstant.MODE_DEL.Equals(formVO.Modeno))
                {
                    // 営業日の取得
                    SysDateVO chkSysDateVO = SysdateCls.GetSysdateTime(facadeContext);

                    // 棚卸実施日TBLの検索
                    string retTanaorosisyuryo_flg = SearchInventory.CheckInventoryEnd(formVO.Head_tenpo_cd,
                                                                                      chkSysDateVO.Sysdate.ToString(),
                                                                                      facadeContext,
                                                                                      0);
                    // 棚卸終了フラグが"1"の場合、エラーとする
                    if ("1".Equals(retTanaorosisyuryo_flg))
                    {
                        ErrMsgCls.AddErrMsg("E172", string.Empty, facadeContext);
                    }
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }                
                
                #endregion

				#endregion

				#region 棚卸実施日TBL取得、棚卸終了チェック

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 棚卸実施日TBL取得
				Hashtable hashTable = new Hashtable();

				int iErrF = 0;
				hashTable = SearchInventory.SearchMdit0030(formVO.Head_tenpo_cd, sysDateVO.Sysdate.ToString(), facadeContext, iErrF);
				String tanaorosikijun_Ymd = "-1";

				if (hashTable != null)
				{
					tanaorosikijun_Ymd = hashTable["TANAOROSIKIJUN_YMD"].ToString();
				}

				// 棚卸終了チェック
				// 取消モードの場合、
				iErrF = 1;
				if (formVO.Modeno.Equals(BoSystemConstant.MODE_DEL) || formVO.Modeno.Equals(BoSystemConstant.MODE_UPD))
				{
					SearchInventory.CheckInventoryEnd(formVO.Head_tenpo_cd, tanaorosikijun_Ymd, facadeContext, iErrF);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

                #region 件数チェック


				//#region 棚卸基準日の取得

				//string strTanaorosikijun_ymd = string.Empty;

				//// 棚卸実施日TBLの検索
				//Hashtable hsMdit0030 = new Hashtable();
				//hsMdit0030 = SearchInventory.SearchMdit0030(BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd),
				//											sysDateVO.Sysdate.ToString(),
				//											facadeContext,
				//											0);
				//// 棚卸基準日の設定
				//if (hsMdit0030 != null)
				//{
				//	strTanaorosikijun_ymd = Convert.ToString(hsMdit0030["TANAOROSIKIJUN_YMD"]);
				//}

				//#endregion

                FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_01, facadeContext.DBContext);
                // 検索条件設定
				ReplaceWherePart(formVO, rtChk, tanaorosikijun_Ymd);

                #region SQL実行

                Decimal dCnt = 0;

                //検索結果を取得します
                rtChk.CreateDbCommand();
                IList<Hashtable> tableListcnt = rtChk.Execute();

                if (logger.IsDebugEnabled)
                {
					BoSystemLog.logOut("SQL: " + rtChk.LogSql);
                }

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

                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_02, facadeContext.DBContext);
                // 検索条件設定
				ReplaceWherePart(formVO, rtSeach, tanaorosikijun_Ymd);

                #region SQL実行

                //検索結果を取得します
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
                    iCnt++;
                    Tj040f01M1Form m1formVO = new Tj040f01M1Form();

                    // Ｍ１行NO
                    m1formVO.M1rowno = iCnt.ToString();

                    // Ｍ１棚段
                    m1formVO.M1tana_dan = rec["TANA_DAN"].ToString();
                    // Ｍ１回数
                    m1formVO.M1kai_su = rec["KAI_SU"].ToString();
                    // Ｍ１点数棚卸入力数
                    m1formVO.M1tensutanaorosinyuryoku_su = rec["TENSUTANAOROSINYURYOKU_SU"].ToString();
                    // Ｍ１点数棚卸訂正数
                    m1formVO.M1tensutanaorositeisei_su = rec["TENSUTANAOROSITEISEI_SU"].ToString();
                    // Ｍ１点数棚卸合計数
                    m1formVO.M1tensutanaorosigokei_su = rec["TENSUTANAOROSIGOKEI_SU"].ToString();
                    // Ｍ１スキャン数量
                    m1formVO.M1scan_su = rec["TANAOROSISCAN_SU"].ToString();
                    // Ｍ１訂正数量
                    m1formVO.M1teisei_suryo = rec["TANAOROSITEISEI_SU"].ToString();
                    // Ｍ１合計数量
                    m1formVO.M1gokei_suryo = rec["TANAOROSIGOKEI_SU"].ToString();
                    // Ｍ１入力担当者名称
                    m1formVO.M1nyuryokutan_nm = rec["ADDTAN_NM"].ToString();
                    // Ｍ１訂正担当者名称
                    m1formVO.M1teiseitan_nm = rec["UPDTAN_NM"].ToString();
                    // Ｍ１理由コメント情報
                    if (rec["TANAOROSIRIYU_NM"].ToString().Length > 8)
                    {
                        m1formVO.M1riyucomment_nm = rec["TANAOROSIRIYU_NM"].ToString().Substring(8);
                    }
                    else
                    {
                        m1formVO.M1riyucomment_nm = rec["TANAOROSIRIYU_NM"].ToString();
                    }
                    // Ｍ１入力日
					if (!"0".Equals(rec["ADD_YMD"].ToString()))
					{
						m1formVO.M1nyuryoku_ymd = rec["ADD_YMD"].ToString();
					}
					else
					{
						m1formVO.M1nyuryoku_ymd = string.Empty;
					}
                    // Ｍ１送信日
					if (!"0".Equals(rec["SOSIN_YMD"].ToString()))
					{
						m1formVO.M1sosin_ymd = rec["SOSIN_YMD"].ToString();
					}
					else
					{
						m1formVO.M1sosin_ymd = string.Empty;
					}
                    // Ｍ１業者
                    if (ConditionTenpo_gyosya_kbn.VALUE_GYOSYA.Equals(rec["DATASB"].ToString()))
                    {
                        m1formVO.M1gyosya = "○";
                    }
                    else
                    {
                        m1formVO.M1gyosya = string.Empty;
                    }

                    // Ｍ１選択フラグ(隠し)
                    m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
                    // Ｍ１確定処理フラグ(隠し)
                    m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
                    // Ｍ１明細色区分(隠し)
                    m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					// 送信済み行は色変更
					if (ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(rec["DATASB"].ToString())
						&& ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
					{
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;											// Ｍ１明細色区分(隠し)
					}

                    // Dictionary保存
                    // 更新日
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());
                    // 更新時間
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());
                    // 棚卸日
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1TANAOROSI_YMD, rec["TANAOROSI_YMD"].ToString());
                    // 送信回数
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1SOSINKAI_SU, rec["SOSINKAI_SU"].ToString());
                    // 入力担当者コード
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1NYURYOKUTAN_CD, rec["ADDTAN_CD"].ToString());
                    // 訂正担当者コード
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1TEISEITAN_CD, rec["UPD_TANCD"].ToString());
                    // 理由コード
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1RIYUCOMMENT_CD, rec["TANAOROSIRIYU_CD"].ToString());
                    // 店舗／業者区分
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1TENPO_GYOSYA_KB, rec["DATASB"].ToString());

					// 訂正フラグ
					m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1TEISEI_FLG, rec["TEISEI_FLG"].ToString());

                    // Ｍ１フェイスＮｏ
                    m1formVO.Dictionary.Add(Tj040p01Constant.DIC_M1FACE_NO, rec["FACE_NO"].ToString());


                    //リストオブジェクトにM1Formを追加します。
                    m1List.Add(m1formVO, true);
                }

				// 検索件数の設定
				formVO.Searchcnt = m1List.Count.ToString();

                #endregion

                #endregion

                #region 選択モードNOの設定

                // 選択モードNOの設定
                formVO.Stkmodeno = formVO.Modeno;

                #endregion

                #region Dictionary保存（カード部）

                // 検索条件を退避
                SearchConditionSaveCls.SearchConditionSave(formVO);

                // 棚卸基準日
				formVO.Dictionary.Add(Tj040p01Constant.DIC_TANAOROSIKIJUN_YMD, tanaorosikijun_Ymd);

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
        /// <param name="formVO">Tj040f01Form</param>
        /// <param name="FindSqlResultTable">rtChk</param>
        /// <returns></returns>
        private void ReplaceWherePart(Tj040f01Form formVO, FindSqlResultTable reader, string prmTanaorosikijun_ymd)
        {
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindList = new ArrayList();
            #region 店舗棚卸データ

            // 店舗／業者区分を設定
            if (!ConditionTenpo_gyosya_kbn.VALUE_GYOSYA.Equals(formVO.Tenpo_gyosya_kb))
            {
                string strTenpoGyosyaKb = " 0=0";
                reader.ReplaceAdd("REPLACE_ID_TENPO_GYOSYA_KB", strTenpoGyosyaKb);
            }
            else
            {
                string strTenpoGyosyaKb = " 0=1";
                reader.ReplaceAdd("REPLACE_ID_TENPO_GYOSYA_KB", strTenpoGyosyaKb);
            }

            // 店舗コードを設定
            reader.ReplaceAdd("REPLACE_ID_TENPO_CD", " AND T1.TENPO_CD = ");
            reader.ReplaceAddBind("REPLACE_ID_TENPO_CD", "BIND01");
            reader.BindValue("BIND01", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

            // フェイスＮｏFROMを設定
            if (!string.IsNullOrEmpty(formVO.Face_no_from))
            {
                reader.ReplaceAdd("REPLACE_ID_FACE_NO_FROM", " AND T1.FACE_NO >= ");
                reader.ReplaceAddBind("REPLACE_ID_FACE_NO_FROM", "BIND02");
                reader.BindValue("BIND02", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no_from, "0")));
            }

            // フェイスＮｏTOを設定
            if (!string.IsNullOrEmpty(formVO.Face_no_to))
            {
                reader.ReplaceAdd("REPLACE_ID_FACE_NO_TO", " AND T1.FACE_NO <= ");
                reader.ReplaceAddBind("REPLACE_ID_FACE_NO_TO", "BIND03");
                reader.BindValue("BIND03", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no_to, "0")));
            }

            // 棚段FROMを設定
            if (!string.IsNullOrEmpty(formVO.Tana_dan_from))
            {
                reader.ReplaceAdd("REPLACE_ID_TANA_DAN_FROM", " AND T1.TANA_DAN >= ");
                reader.ReplaceAddBind("REPLACE_ID_TANA_DAN_FROM", "BIND04");
                reader.BindValue("BIND04", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan_from, "0")));
            }

            // 棚段TOを設定
            if (!string.IsNullOrEmpty(formVO.Tana_dan_to))
            {
                reader.ReplaceAdd("REPLACE_ID_TANA_DAN_TO", " AND T1.TANA_DAN <= ");
                reader.ReplaceAddBind("REPLACE_ID_TANA_DAN_TO", "BIND05");
                reader.BindValue("BIND05", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan_to, "0")));
            }

            // 入力日FROMを設定
            if (!string.IsNullOrEmpty(formVO.Nyuryoku_ymd_from))
            {
                reader.ReplaceAdd("REPLACE_ID_NYURYOKU_YMD_FROM", " AND T1.ADD_YMD >= ");
                reader.ReplaceAddBind("REPLACE_ID_NYURYOKU_YMD_FROM", "BIND06");
                reader.BindValue("BIND06", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Nyuryoku_ymd_from)));
            }

            // 入力日TOを設定
            if (!string.IsNullOrEmpty(formVO.Nyuryoku_ymd_to))
            {
                reader.ReplaceAdd("REPLACE_ID_NYURYOKU_YMD_TO", " AND T1.ADD_YMD <= ");
                reader.ReplaceAddBind("REPLACE_ID_NYURYOKU_YMD_TO", "BIND07");
                reader.BindValue("BIND07", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Nyuryoku_ymd_to)));
            }

			// [選択モードNo]が「照会」の場合
			if (BoSystemConstant.MODE_REF.Equals(formVO.Modeno))
			{
				// 送信日FROMを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_ymd_from))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_FROM", " AND T1.SOSIN_YMD >= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_FROM", "BIND08");
					reader.BindValue("BIND08", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_ymd_from)));
				}

				// 送信日TOを設定
				if (!string.IsNullOrEmpty(formVO.Sosin_ymd_to))
				{
					reader.ReplaceAdd("REPLACE_ID_SOSIN_YMD_TO", " AND T1.SOSIN_YMD <= ");
					reader.ReplaceAddBind("REPLACE_ID_SOSIN_YMD_TO", "BIND09");
					reader.BindValue("BIND09", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Sosin_ymd_to)));
				}
			}

            // 入力担当者コードを設定
            if (!string.IsNullOrEmpty(formVO.Nyuryokutan_cd))
            {
                reader.ReplaceAdd("REPLACE_ID_NYURYOKUTAN_CD", " AND T1.ADDTAN_CD = ");
                reader.ReplaceAddBind("REPLACE_ID_NYURYOKUTAN_CD", "BIND10");
                reader.BindValue("BIND10", BoSystemFormat.formatTantoCd(formVO.Nyuryokutan_cd));
            }

            // 自社品番を設定
            if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn)  ||
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
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN01 ";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN01";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD1];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn2))
                {
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn2).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn2) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN02";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN02";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD2];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn3))
                {
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn3).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn3) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN03 ";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN03";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD3];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn4))
                {
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn4).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn4) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN04 ";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN04";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD4];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn5))
                {
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn5).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn5) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN05 ";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN05";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD5];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                // 最初の""OR を削除
                strjisya_hbn = strjisya_hbn.Substring(3);

                string strSqljisya_hbn = string.Empty;
                strSqljisya_hbn = strSqljisya_hbn + " AND EXISTS ( ";
                strSqljisya_hbn = strSqljisya_hbn + "      SELECT 1 ";
                strSqljisya_hbn = strSqljisya_hbn + "      FROM   MDIT0011 T2 ";
                strSqljisya_hbn = strSqljisya_hbn + "      WHERE  T2.TENPO_CD      = T1.TENPO_CD ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.FACE_NO       = T1.FACE_NO ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.TANA_DAN      = T1.TANA_DAN ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.KAI_SU        = T1.KAI_SU ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.TANAOROSI_YMD = T1.TANAOROSI_YMD ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.SOSINKAI_SU   = T1.SOSINKAI_SU ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    ( " + strjisya_hbn + ")";
                strSqljisya_hbn = strSqljisya_hbn + "    ) ";

				BoSystemSql.AddSql(reader, "REPLACE_ID_JISYA_HBN", strSqljisya_hbn, bindList);
			}

            // スキャンコードを設定
			bindList = new ArrayList();
            if (!string.IsNullOrEmpty(formVO.Scan_cd)  ||
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
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD1];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }
                if (!string.IsNullOrEmpty(formVO.Scan_cd2))
                {
					strScancd = strScancd + ", :BIND_SCAN_CD02 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD02";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD2];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }
                if (!string.IsNullOrEmpty(formVO.Scan_cd3))
                {
					strScancd = strScancd + ", :BIND_SCAN_CD03";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD03";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD3];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }
                if (!string.IsNullOrEmpty(formVO.Scan_cd4))
                {
					strScancd = strScancd + ", :BIND_SCAN_CD04 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD04";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD4];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }
                if (!string.IsNullOrEmpty(formVO.Scan_cd5))
                {
					strScancd = strScancd + ", :BIND_SCAN_CD05 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD05";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD5];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }

                // 最初のカンマを削除
                strScancd = strScancd.Substring(1);

                string strSqlScancd = string.Empty;
                strSqlScancd = strSqlScancd + " AND EXISTS ( ";
                strSqlScancd = strSqlScancd + "      SELECT 1 ";
                strSqlScancd = strSqlScancd + "      FROM   MDIT0011 T3 ";
                strSqlScancd = strSqlScancd + "      WHERE  T3.TENPO_CD      = T1.TENPO_CD ";
                strSqlScancd = strSqlScancd + "      AND    T3.FACE_NO       = T1.FACE_NO ";
                strSqlScancd = strSqlScancd + "      AND    T3.TANA_DAN      = T1.TANA_DAN ";
                strSqlScancd = strSqlScancd + "      AND    T3.KAI_SU        = T1.KAI_SU ";
                strSqlScancd = strSqlScancd + "      AND    T3.TANAOROSI_YMD = T1.TANAOROSI_YMD ";
                strSqlScancd = strSqlScancd + "      AND    T3.SOSINKAI_SU   = T1.SOSINKAI_SU ";
                strSqlScancd = strSqlScancd + "      AND    T3.JAN_CD IN(" + strScancd + ")";
                strSqlScancd = strSqlScancd + "    ) ";

				BoSystemSql.AddSql(reader, "REPLACE_ID_SCAN_CD", strSqlScancd, bindList);
			}

            // 訂正フラグを設定
            if (BoSystemConstant.CHECKBOX_ON.Equals(formVO.Teisei_flg))
            {
                string strTeiseiflg = "AND T1.TEISEI_FLG = 1";
                reader.ReplaceAdd("REPLACE_ID_TEISEI_FLG", strTeiseiflg);
            }


            // [選択モードNo]が「修正」,「取消」の場合
            if (BoSystemConstant.MODE_UPD.Equals(formVO.Modeno) ||
				BoSystemConstant.MODE_DEL.Equals(formVO.Modeno))
            {
                // 送信依頼フラグを設定
                string strSosiniraiflg = "AND T1.SOSINIRAI_FLG = 0";
                reader.ReplaceAdd("REPLACE_ID_SOSINIRAI_FLG", strSosiniraiflg);

                // 送信済フラグを設定
                string strSosinzumiflg = "AND T1.SOSINZUMI_FLG = 0";
                reader.ReplaceAdd("REPLACE_ID_SOSINZUMI_FLG", strSosinzumiflg);

                // 棚卸日を設定
                if (!string.IsNullOrEmpty(prmTanaorosikijun_ymd))
                {
                    reader.ReplaceAdd("REPLACE_ID_TANAOROSI_YMD", " AND T1.TANAOROSI_YMD = ");
                    reader.ReplaceAddBind("REPLACE_ID_TANAOROSI_YMD", "BIND11");
                    reader.BindValue("BIND11", Convert.ToDecimal(BoSystemString.Nvl(prmTanaorosikijun_ymd, "0")));
                }
            }
            // [選択モードNo]が「照会」の場合
			else if (BoSystemConstant.MODE_REF.Equals(formVO.Modeno))
            {
                // 送信済フラグを設定
				if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(formVO.Sosin_jyotai))
                {
					// 未送信
					if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI1.Equals(formVO.Sosin_jyotai))
					{
						reader.ReplaceAdd("REPLACE_ID_SOSINZUMI_FLG", " AND T1.SOSINZUMI_FLG = 0 ");
					}
					// 送信済
					else if (ConditionSosin_jotai.VALUE_SOSIN_JOTAI2.Equals(formVO.Sosin_jyotai))
					{
						reader.ReplaceAdd("REPLACE_ID_SOSINZUMI_FLG", " AND T1.SOSINZUMI_FLG = 1 ");
					}
                }
			}

            #endregion

            #region 業者棚卸データ

            // 店舗／業者区分を設定
            if (!ConditionTenpo_gyosya_kbn.VALUE_TENPO.Equals(formVO.Tenpo_gyosya_kb))
            {
				// モードが照会の場合
				if (BoSystemConstant.MODE_REF.Equals(formVO.Modeno))
				{
					string strTenpoGyosyaKb = " 0=0";
					reader.ReplaceAdd("REPLACE_ID_TENPO_GYOSYA_KB2", strTenpoGyosyaKb);
				}
				else
				{
					string strTenpoGyosyaKb = " 0=1";
					reader.ReplaceAdd("REPLACE_ID_TENPO_GYOSYA_KB2", strTenpoGyosyaKb);
				}
            }
            else
            {
                string strTenpoGyosyaKb = " 0=1";
                reader.ReplaceAdd("REPLACE_ID_TENPO_GYOSYA_KB2", strTenpoGyosyaKb);
            }

            // 店舗コードを設定
            reader.ReplaceAdd("REPLACE_ID_TENPO_CD2", " AND T1.TENPO_CD = ");
            reader.ReplaceAddBind("REPLACE_ID_TENPO_CD2", "BIND21");
            reader.BindValue("BIND21", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));

            // フェイスＮｏFROMを設定
            if (!string.IsNullOrEmpty(formVO.Face_no_from))
            {
                reader.ReplaceAdd("REPLACE_ID_FACE_NO_FROM2", " AND T1.FACE_NO >= ");
                reader.ReplaceAddBind("REPLACE_ID_FACE_NO_FROM2", "BIND22");
                reader.BindValue("BIND22", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no_from, "0")));
            }

            // フェイスＮｏTOを設定
            if (!string.IsNullOrEmpty(formVO.Face_no_to))
            {
                reader.ReplaceAdd("REPLACE_ID_FACE_NO_TO2", " AND T1.FACE_NO <= ");
                reader.ReplaceAddBind("REPLACE_ID_FACE_NO_TO2", "BIND23");
                reader.BindValue("BIND23", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no_to, "0")));
            }

            // 棚段FROMを設定
            if (!string.IsNullOrEmpty(formVO.Tana_dan_from))
            {
                reader.ReplaceAdd("REPLACE_ID_TANA_DAN_FROM2", " AND T1.TANA_DAN >= ");
                reader.ReplaceAddBind("REPLACE_ID_TANA_DAN_FROM2", "BIND24");
                reader.BindValue("BIND24", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan_from, "0")));
            }

            // 棚段TOを設定
            if (!string.IsNullOrEmpty(formVO.Tana_dan_to))
            {
                reader.ReplaceAdd("REPLACE_ID_TANA_DAN_TO2", " AND T1.TANA_DAN <= ");
                reader.ReplaceAddBind("REPLACE_ID_TANA_DAN_TO2", "BIND25");
                reader.BindValue("BIND25", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan_to, "0")));
            }

            // 入力日FROMを設定
            if (!string.IsNullOrEmpty(formVO.Nyuryoku_ymd_from))
            {
                reader.ReplaceAdd("REPLACE_ID_NYURYOKU_YMD_FROM2", " AND T1.SYORI_YMD >= ");
                reader.ReplaceAddBind("REPLACE_ID_NYURYOKU_YMD_FROM2", "BIND26");
                reader.BindValue("BIND26", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Nyuryoku_ymd_from)));
            }

            // 入力日TOを設定
            if (!string.IsNullOrEmpty(formVO.Nyuryoku_ymd_to))
            {
                reader.ReplaceAdd("REPLACE_ID_NYURYOKU_YMD_TO2", " AND T1.SYORI_YMD <= ");
                reader.ReplaceAddBind("REPLACE_ID_NYURYOKU_YMD_TO2", "BIND27");
                reader.BindValue("BIND27", Convert.ToDecimal(BoSystemFormat.formatDate(formVO.Nyuryoku_ymd_to)));
            }

            // 自社品番を設定
			bindList = new ArrayList();
            if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn) ||
                !string.IsNullOrEmpty(formVO.Old_jisya_hbn2) ||
                !string.IsNullOrEmpty(formVO.Old_jisya_hbn3) ||
                !string.IsNullOrEmpty(formVO.Old_jisya_hbn4) ||
                !string.IsNullOrEmpty(formVO.Old_jisya_hbn5))
            {
                string strjisya_hbn = string.Empty;
                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn))
                {
                    // [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN06 ";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN06";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD1];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn2))
                {
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn2).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn2) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN07 ";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN07";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD2];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn3))
                {
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn3).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn3) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN08 ";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN08";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD3];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn4))
                {
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn4).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn4) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN09";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN09";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD4];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                if (!string.IsNullOrEmpty(formVO.Old_jisya_hbn5))
                {
					//// [旧自社品番]が10桁の場合
					//if (10 == BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn5).Length)
					//{
					//	strjisya_hbn = strjisya_hbn + "OR " + "T2.JAN_CD IN( ";
					//	strjisya_hbn = strjisya_hbn + " SELECT M1.JAN_CD ";
					//	strjisya_hbn = strjisya_hbn + " FROM   MDMT0130 M1 ";
					//	strjisya_hbn = strjisya_hbn + " WHERE  M1.OLD_XEBIO_CD = '" + BoSystemFormat.formatJisyaHbn(formVO.Old_jisya_hbn5) + "'";
					//	strjisya_hbn = strjisya_hbn + " ) ";
					//}
					//else
					//{
					strjisya_hbn = strjisya_hbn + "OR " + "T2.JISYA_HBN = :BIND_JISYA_HBN10 ";
                    //}
						// バインド変数設定
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISYA_HBN10";
						bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_XEBIOCD5];
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
                }

                // 最初の""OR を削除
                strjisya_hbn = strjisya_hbn.Substring(3);

                string strSqljisya_hbn = string.Empty;
                strSqljisya_hbn = strSqljisya_hbn + " AND EXISTS ( ";
                strSqljisya_hbn = strSqljisya_hbn + "      SELECT 1 ";
                strSqljisya_hbn = strSqljisya_hbn + "      FROM   MDIT0091 T2 ";
                strSqljisya_hbn = strSqljisya_hbn + "      WHERE  T2.TENPO_CD      = T1.TENPO_CD ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.FACE_NO       = T1.FACE_NO ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.TANA_DAN      = T1.TANA_DAN ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.KAI_SU        = T1.KAI_SU ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.TANAOROSI_YMD = T1.TANAOROSI_YMD ";
				strSqljisya_hbn = strSqljisya_hbn + "      AND    T2.SYORI_YMD     = T1.SYORI_YMD ";
                strSqljisya_hbn = strSqljisya_hbn + "      AND    ( " + strjisya_hbn + ")";
                strSqljisya_hbn = strSqljisya_hbn + "    ) ";

				BoSystemSql.AddSql(reader, "REPLACE_ID_JISYA_HBN2", strSqljisya_hbn, bindList);

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
					strScancd = strScancd + ", :BIND_SCAN_CD06 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD06";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD1];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }
                if (!string.IsNullOrEmpty(formVO.Scan_cd2))
                {
					strScancd = strScancd + ", :BIND_SCAN_CD07 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD07";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD2];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }
                if (!string.IsNullOrEmpty(formVO.Scan_cd3))
                {
					strScancd = strScancd + ", :BIND_SCAN_CD08 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD08";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD3];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }
                if (!string.IsNullOrEmpty(formVO.Scan_cd4))
                {
					strScancd = strScancd + ", :BIND_SCAN_CD09 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD09";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD4];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }
                if (!string.IsNullOrEmpty(formVO.Scan_cd5))
                {
					strScancd = strScancd + ", :BIND_SCAN_CD10 ";
					// バインド変数設定
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SCAN_CD10";
					bindVO.Value = (string)formVO.Dictionary[Tj040p01Constant.DIC_SEARCH_JANCD5];
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
                }

                // 最初のカンマを削除
                strScancd = strScancd.Substring(1);

                string strSqlScancd = string.Empty;
                strSqlScancd = strSqlScancd + " AND EXISTS ( ";
                strSqlScancd = strSqlScancd + "      SELECT 1 ";
                strSqlScancd = strSqlScancd + "      FROM   MDIT0091 T3 ";
                strSqlScancd = strSqlScancd + "      WHERE  T3.TENPO_CD      = T1.TENPO_CD ";
                strSqlScancd = strSqlScancd + "      AND    T3.FACE_NO       = T1.FACE_NO ";
                strSqlScancd = strSqlScancd + "      AND    T3.TANA_DAN      = T1.TANA_DAN ";
                strSqlScancd = strSqlScancd + "      AND    T3.KAI_SU        = T1.KAI_SU ";
                strSqlScancd = strSqlScancd + "      AND    T3.TANAOROSI_YMD = T1.TANAOROSI_YMD ";
				strSqlScancd = strSqlScancd + "      AND    T3.SYORI_YMD     = T1.SYORI_YMD ";
                strSqlScancd = strSqlScancd + "      AND    T3.JAN_CD IN(" + strScancd + ")";
                strSqlScancd = strSqlScancd + "    ) ";

				BoSystemSql.AddSql(reader, "REPLACE_ID_SCAN_CD2", strSqlScancd, bindList);
			}

            #endregion

        }
        #endregion
	}
}
