using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01004;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01019;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V01000.V01005;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tf070f02Form f02VO = (Tf070f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Tf070f01M1Form f01m1VO = (Tf070f01M1Form)f02VO.Dictionary[Tf070p01Constant.DIC_M1SELCETVO];

				// システム日付情報取得
				SysDateVO sysDateInfo = SysdateCls.GetSysdateTime(facadeContext);

				// 合計項目（更新用）
				decimal gokeisinseiSu = decimal.Zero;
				decimal gokeijyuriSu = decimal.Zero;
				decimal gokeibaikaKin = decimal.Zero;

				// 経費振替伝票番号
				decimal dDenno = decimal.Zero;
				#endregion

				#region 業務チェック

				#region 件数チェック
				// 1-1 Ｍ１スキャンコード
				// Ｍ１スキャンコードが1件も入力されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
				else
				{
					bool inputFlg = false;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf070f02M1Form f02m1VO = (Tf070f02M1Form)m1List[i];
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd))
						{
							// Ｍ１スキャンコードが入力されている場合
							inputFlg = true;
							break;
						}
					}
					if (!inputFlg)
					{
						// 確定対象がありません。
						ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 単項目チェック（カード部）
				// 2-1 事故発生日
				// 未来日付が入力された場合、エラー
				if (!string.IsNullOrEmpty(f02VO.Jikohassei_ymd))
				{
					if (V03001Check.DateFromToChk(f02VO.Jikohassei_ymd, sysDateInfo.Sysdate.ToString()) > 0)
					{
						// 事故発生日＞システム日付の場合
						ErrMsgCls.AddErrMsg("E215", "事故発生日", facadeContext, new string[] { "Jikohassei_ymd" });
					}
				}

				// 2-2 報告日
				// [選択モードNO]が「経費申請」、または[受理番号]が入力されている時、入力されていない場合はエラー
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)
					|| !string.IsNullOrEmpty(f02VO.Jyuri_no))
				{
					if (string.IsNullOrEmpty(f02VO.Hokoku_ymd))
					{
						ErrMsgCls.AddErrMsg("E121", "報告日", facadeContext, new string[] { "Hokoku_ymd" });
					}
				}

				// 2-3 報告日
				// 未来日付が入力された場合、エラー
				if (!string.IsNullOrEmpty(f02VO.Hokoku_ymd))
				{
					if (V03001Check.DateFromToChk(f02VO.Hokoku_ymd, sysDateInfo.Sysdate.ToString()) > 0)
					{
						// 報告日＞システム日付の場合
						ErrMsgCls.AddErrMsg("E215", "報告日", facadeContext, new string[] { "Hokoku_ymd" });
					}
				}

				// 2-4 報告担当者コード
				// 担当者MSTに存在しない場合、エラー
				if (!string.IsNullOrEmpty(f02VO.Hokokutan_cd))
				{
					Hashtable tantoInfo = V01005Check.CheckTanto(f02VO.Hokokutan_cd, facadeContext, "報告者", new string[] { "Hokokutan_cd" });

					if (tantoInfo != null)
					{
						// 名称設定
						f02VO.Hokokutan_nm = tantoInfo["HANBAIIN_NM"].ToString();
					}
				}

				// 2-5 店長担当者コード
				// 担当者MSTに存在しない場合、エラー
				if (!string.IsNullOrEmpty(f02VO.Tentyotan_cd))
				{
					Hashtable tantoInfo = V01005Check.CheckTanto(f02VO.Tentyotan_cd, facadeContext, "店長", new string[] { "Tentyotan_cd" });

					if (tantoInfo != null)
					{
						// 名称設定
						f02VO.Tentyotan_nm = tantoInfo["HANBAIIN_NM"].ToString();
					}
				}

				// 2-6 警察届出日
				// [選択モードNO]が「経費申請」、または[受理番号]が入力されている時、入力されていない場合はエラー
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)
					|| !string.IsNullOrEmpty(f02VO.Jyuri_no))
				{
					if (string.IsNullOrEmpty(f02VO.Keisatsutodoke_ymd))
					{
						ErrMsgCls.AddErrMsg("E121", "警察届出日", facadeContext, new string[] { "Keisatsutodoke_ymd" });
					}
				}

				// 2-7 届出先警察署名
				// [選択モードNO]が「経費申請」、または[受理番号]が入力されている時、入力されていない場合はエラー
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)
					|| !string.IsNullOrEmpty(f02VO.Jyuri_no))
				{
					if (string.IsNullOrEmpty(f02VO.Todokedesakikeisatsu_nm))
					{
						ErrMsgCls.AddErrMsg("E121", "届出警察署", facadeContext, new string[] { "Todokedesakikeisatsu_nm" });
					}
				}

				// 2-8 受理番号
				// [選択モードNO]が「経費申請」の時、入力されていない場合はエラー
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI))
				{
					if (string.IsNullOrEmpty(f02VO.Jyuri_no))
					{
						ErrMsgCls.AddErrMsg("E121", "受理番号", facadeContext, new string[] { "Jyuri_no" });
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連チェック（カード部）
				// 3-1 報告日
				// 事故発生日 > 報告日の場合エラー
				if (!string.IsNullOrEmpty(f02VO.Jikohassei_ymd)
					&& !string.IsNullOrEmpty(f02VO.Hokoku_ymd))
				{
					if (V03001Check.DateFromToChk(f02VO.Jikohassei_ymd, f02VO.Hokoku_ymd) > 0)
					{
						// 事故発生日＞報告日の場合
						ErrMsgCls.AddErrMsg("E186", string.Empty, facadeContext, new string[] { "Hokoku_ymd" });
					}
				}

				// 3-2 警察届出日
				// 事故発生日 > 警察届出日の場合エラー
				if (!string.IsNullOrEmpty(f02VO.Jikohassei_ymd)
					&& !string.IsNullOrEmpty(f02VO.Keisatsutodoke_ymd))
				{
					if (V03001Check.DateFromToChk(f02VO.Jikohassei_ymd, f02VO.Keisatsutodoke_ymd) > 0)
					{
						// 事故発生日＞警察届出日の場合
						ErrMsgCls.AddErrMsg("E233", string.Empty, facadeContext, new string[] { "Keisatsutodoke_ymd" });
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細行オブジェクト取得
					Tf070f02M1Form m1Form = (Tf070f02M1Form)m1List[i];

					if (string.IsNullOrEmpty(m1Form.M1scan_cd))
					{
						// Ｍ１スキャンコードが入力されていない場合、チェック対象外
						continue;
					}

					#region 単項目チェック（明細部）
					// 4-1 Ｍ１発生時間
					// 入力されていない場合、エラー
					if (string.IsNullOrEmpty(m1Form.M1hassei_tm))
					{
						ErrMsgCls.AddErrMsg("E121", "時間", facadeContext, new string[] { "M1hassei_tm" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
					}

					// 4-2 Ｍ１発生時間
					// 0～23以外の場合、エラー
					if (!string.IsNullOrEmpty(m1Form.M1hassei_tm))
					{ 
						int hasseiTm = int.Parse(m1Form.M1hassei_tm);
						if (hasseiTm < 0 || hasseiTm > 23)
						{
							ErrMsgCls.AddErrMsg("E135", "時間", facadeContext, new string[] { "M1hassei_tm" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
					}

					// 4-3 Ｍ１発生場所
					// 入力されていない場合、エラー
					if (string.IsNullOrEmpty(m1Form.M1hasseibasyo))
					{
						ErrMsgCls.AddErrMsg("E121", "発生場所", facadeContext, new string[] { "M1hasseibasyo" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
					}

					// 4-4 Ｍ１発見担当者コード
					// 入力されていない場合、エラー
					if (string.IsNullOrEmpty(m1Form.M1hakkentan_cd))
					{
						ErrMsgCls.AddErrMsg("E121", "発見者", facadeContext, new string[] { "M1hakkentan_cd" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
					}

					// 4-5 Ｍ１発見担当者コード
					// 担当者MSTに存在しない場合、エラー
					if (!string.IsNullOrEmpty(m1Form.M1hakkentan_cd))
					{
						Hashtable tantoInfo = V01005Check.CheckTanto(
							m1Form.M1hakkentan_cd,
							facadeContext,
							"発見者",
							new string[] { "M1hakkentan_cd" },
							m1Form.M1rowno,
							i.ToString(),
							"M1",
							m1List.DispRow
							);

						if (tantoInfo != null)
						{
							// 名称設定
							m1Form.M1hakkentan_nm = tantoInfo["HANBAIIN_NM"].ToString();
						}
					}

					// 4-6 Ｍ１発見状況区分
					// ドロップダウンリストが空白の場合、エラー
					if (m1Form.M1hakkenjyokyo_kb.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						ErrMsgCls.AddErrMsg("E119", "発見状況", facadeContext, new string[] { "M1hakkenjyokyo_kb" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
					}

					// 4-7 Ｍ１発見状況
					// [Ｍ１発見状況区分]が「その他」で、入力されていない場合、エラー
					if (m1Form.M1hakkenjyokyo_kb.Equals(ConditionHakkenjyokyo_kb.VALUE_HAKKENJYOKYO_KB7))
					{
						if (string.IsNullOrEmpty(m1Form.M1hakkenjyokyo_nm))
						{
							ErrMsgCls.AddErrMsg("E121", "発見状況", facadeContext, new string[] { "M1hakkenjyokyo_nm" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
					}

					// 4-8 Ｍ１スキャンコード
					// 発注MSTに存在しない場合、エラー
					SearchHachuVO hachuVO = new SearchHachuVO(
						m1Form.M1scan_cd,		// スキャンコード
						f02VO.Head_tenpo_cd,	// 店舗コード
						1,						// 店別単価マスタ検索フラグ		1:検索する
						0,						// 売変検索フラグ				0:検索しない
						0,						// 店在庫検索フラグ				0:検索しない
						0,						// 入荷予定数検索フラグ			0:検索しない
						0,						// 売上実績数検索フラグ			0:検索しない
						0,						// 依頼集計数(補充)検索フラグ	0:検索しない
						0,						// 依頼集計数(単品)検索フラグ	0:検索しない
						0,						// 指示検索検索フラグ			0:検索しない
						string.Empty,			// 指示NO（移動出荷マニュアル、返品マニュアル用）
						string.Empty,			// 出荷会社コード（移動出荷マニュアル)
						string.Empty,			// 入荷会社コード（移動出荷マニュアル)
						string.Empty			// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
						);

					Hashtable hachuInfo = V01004Check.CheckScanCd(
						hachuVO,
						facadeContext,
						"スキャンコード",
						new string[] { "M1scan_cd" },
						m1Form.M1rowno,
						i.ToString(),
						"M1",
						m1List.DispRow
						);

					if (hachuInfo != null)
					{
						// 明細項目設定
						m1Form.M1bumon_cd = BoSystemFormat.formatBumonCd(hachuInfo["BUMON_CD"].ToString());		// 部門コード
						m1Form.M1bumonkana_nm = hachuInfo["BUMONKANA_NM"].ToString();				// 部門カナ名
						m1Form.M1hinsyu_ryaku_nm = hachuInfo["HINSYU_RYAKU_NM"].ToString();			// 品種略名称
						m1Form.M1burando_nm = hachuInfo["BURANDO_NMK"].ToString();					// ブランド名カナ
						m1Form.M1jisya_hbn = BoSystemFormat.formatJisyaHbn(hachuInfo["XEBIO_CD"].ToString());	// 自社品番
						m1Form.M1maker_hbn = hachuInfo["HIN_NBR"].ToString();						// メーカー品番
						m1Form.M1syonmk = hachuInfo["SYONMK"].ToString();							// 商品略式名称カナ
						m1Form.M1iro_nm = hachuInfo["IRO_NM"].ToString();							// 色略式名称カナ
						m1Form.M1size_nm = hachuInfo["SIZE_NM"].ToString();							// サイズ略名称カナ
						m1Form.M1baika_hon = hachuInfo["BAIKA"].ToString();							// 店別単価
						// 売価金額計算
						decimal baikaKin = this.CalcBaikaKin(f02VO.Stkmodeno, m1Form);
						m1Form.M1baika_kin = baikaKin.ToString();									// 売価金額	

						// 更新用にディクショナリに保持
						m1Form.Dictionary[Tf070p01Constant.DIC_M1HINSYU_CD] = hachuInfo["HINSYU_CD"].ToString();			// 品種コード
						m1Form.Dictionary[Tf070p01Constant.DIC_M1BURANDO_CD] = hachuInfo["BURANDO_CD"].ToString();			// ブランドコード
						m1Form.Dictionary[Tf070p01Constant.DIC_M1MAKERCOLOR_CD] = hachuInfo["MAKERCOLOR_CD"].ToString();	// 色コード
						m1Form.Dictionary[Tf070p01Constant.DIC_M1SIZE_CD] = hachuInfo["SIZE_CD"].ToString();				// サイズコード
						m1Form.Dictionary[Tf070p01Constant.DIC_M1JAN_CD] = hachuInfo["JAN_CD"].ToString();					// ＪＡＮコード
						m1Form.Dictionary[Tf070p01Constant.DIC_M1SYOHIN_CD] = hachuInfo["SYOHIN_CD"].ToString();			// 商品コード

						// 合計項目（更新用）加算
						gokeisinseiSu += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1sinsei_su, "0"));	// 合計申請数
						gokeijyuriSu += Convert.ToDecimal(BoSystemString.Nvl(m1Form.M1jyuri_su, "0"));		// 合計受理数
						gokeibaikaKin += baikaKin;															// 合計売価金額
					}

					// 4-9 Ｍ１申請数
					// 入力されていない場合、エラー
					if (string.IsNullOrEmpty(m1Form.M1sinsei_su))
					{
						ErrMsgCls.AddErrMsg("E121", "申請数", facadeContext, new string[] { "M1sinsei_su" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
					}

					// 4-10 Ｍ１申請数
					// 0が入力された場合、エラー
					if (!string.IsNullOrEmpty(m1Form.M1sinsei_su))
					{
						if (m1Form.M1sinsei_su.Equals("0"))
						{
							ErrMsgCls.AddErrMsg("E103", "申請数", facadeContext, new string[] { "M1sinsei_su" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
					}

					// 4-11 Ｍ１受理数
					// [選択モードNO]が「経費申請」、または[受理番号]が入力されている時、入力されていない場合はエラー
					if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)
						|| !string.IsNullOrEmpty(f02VO.Jyuri_no))
					{
						if (string.IsNullOrEmpty(m1Form.M1jyuri_su))
						{
							ErrMsgCls.AddErrMsg("E121", "受理数", facadeContext, new string[] { "M1jyuri_su" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
					}

					// 4-12 Ｍ１受理数
					// 0が入力された場合、エラー
					if (!string.IsNullOrEmpty(m1Form.M1jyuri_su))
					{
						if (m1Form.M1jyuri_su.Equals("0"))
						{
							ErrMsgCls.AddErrMsg("E103", "受理数", facadeContext, new string[] { "M1jyuri_su" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
					}

					// エラーが発生した場合、次明細をチェックする。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						continue;
					}
					#endregion

					#region 関連チェック（明細部）
					// 5-1 Ｍ１受理数
					// [Ｍ１受理数] > [Ｍ１申請数]の場合エラー
					if (!string.IsNullOrEmpty(m1Form.M1sinsei_su)
						&& !string.IsNullOrEmpty(m1Form.M1jyuri_su))
					{
						int sinseiSu = int.Parse(m1Form.M1sinsei_su);
						int jyuriSu = int.Parse(m1Form.M1jyuri_su);

						if (jyuriSu > sinseiSu)
						{
							ErrMsgCls.AddErrMsg("E156", string.Empty, facadeContext, new string[] { "M1jyuri_su" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
					}

					// 5-2 Ｍ１売価金額
					// [Ｍ１売価（本体）]×[Ｍ１申請数] ＞ 99999999（8桁）の場合、エラー
					if (!string.IsNullOrEmpty(m1Form.M1sinsei_su)
						&& !string.IsNullOrEmpty(m1Form.M1baika_hon))
					{
						decimal sinseiSu = decimal.Parse(m1Form.M1sinsei_su);
						decimal baikaHon = decimal.Parse(m1Form.M1baika_hon);

						if ((baikaHon * sinseiSu) > 99999999m)
						{
							ErrMsgCls.AddErrMsg("E102", "売価金額", facadeContext, new string[] { "M1sinsei_su" }, m1Form.M1rowno, i.ToString(), "M1", m1List.DispRow);
						}
					}

					// エラーが発生した場合、次明細をチェックする。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						continue;
					}
					#endregion
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI)
					|| f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
				{
					// 経費申請モード、または修正モードの場合

					#region 排他チェック
					StringBuilder sRepSql = new StringBuilder();
					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					string tableId = "MDAT0040";	// 盗難品TBL(H)

					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
					sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
					sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");

					// 店舗コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);

					// 管理No
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_KANRI_NO";
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f02VO.Tonanhinkanri_no);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
					bindList.Add(bindVO);

					// 処理日付
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYORI_YMD";
					bindVO.Value = (string)f01m1VO.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;
					bindList.Add(bindVO);

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
						Convert.ToDecimal(f01m1VO.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]),
						Convert.ToDecimal(f01m1VO.Dictionary[Tf070p01Constant.DIC_M1UPD_TM]),
						facadeContext,
						tableId,
						sRepSql.ToString(),
						bindList,
						1,
						null,
						null,
						null,
						null,
						0
					);

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion
				}
				#endregion

				#region 更新処理
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					#region 新規作成
					// [盗難品一時TBL]を登録する。
					BoSystemLog.logOut("[盗難品一時TBL]を登録 START");
					int inscnt = Ins_TonanhinT(facadeContext, f02VO, logininfo, sysDateInfo);
					BoSystemLog.logOut("[盗難品一時TBL]を登録 END");

					// ストアド(盗難品登録処理)を起動する。
					BoSystemLog.logOut("ストアド(盗難品登録処理)を起動 START");
					ExceInsertStolenItem(facadeContext);
					BoSystemLog.logOut("ストアド(盗難品登録処理)を起動 END");
					#endregion

					//エラーが発生した場合、その時点で処理を中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				else
				{
					#region 経費申請、修正
					// [盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（赤）を登録する。
					BoSystemLog.logOut("[盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（赤）を登録 START");
					int insCntRirekiB_Aka = Ins_TonanhinRirekiB_Aka(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo);
					BoSystemLog.logOut("[盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（赤）を登録 END");

					// [盗難品TBL(B)]を削除する。
					BoSystemLog.logOut("[盗難品TBL(B)]を削除 START");
					int delCntB = Del_TonanhinB(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo);
					BoSystemLog.logOut("[盗難品TBL(B)]を削除 END");

					// [盗難品TBL(B)]を登録する。
					BoSystemLog.logOut("[盗難品TBL(B)]を登録 START");
					int insCntB = Ins_TonanhinB(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo);
					BoSystemLog.logOut("[盗難品TBL(B)]を登録 END");

					// [盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（黒）を登録する。
					BoSystemLog.logOut("[盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（黒）を登録 START");
					int insCntRirekiB_Kuro = Ins_TonanhinRirekiB_Kuro(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo);
					BoSystemLog.logOut("[盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（黒）を登録 END");

					// [盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]（赤）を登録する。
					BoSystemLog.logOut("[盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]（赤）を登録 START");
					int insCntRirekiH_Aka = Ins_TonanhinRirekiH_Aka(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo);
					BoSystemLog.logOut("[盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（赤）を登録 END");

					// [盗難品TBL(H)]を更新する。
					BoSystemLog.logOut("[盗難品TBL(H)]を更新 START");
					int updCntH = Upd_TonanhinH(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo, gokeisinseiSu, gokeijyuriSu, gokeibaikaKin);
					BoSystemLog.logOut("[盗難品TBL(H)]を更新 END");

					// [盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]（黒）を登録する。
					BoSystemLog.logOut("[盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]（黒）を登録 START");
					int insCntRirekiH_Kuro = Ins_TonanhinRirekiH_Kuro(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo);
					BoSystemLog.logOut("[盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]（黒）を登録 END");

					if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI))
					{
						#region 経費申請
						// 経費振替伝票番号を採番する。
						dDenno = AutoNumber_KeiFuriDenNo(
							facadeContext,
							f02VO,
							f01m1VO,
							logininfo
							);
						if (dDenno < 0)
						{
							// 採番不可
							ErrMsgCls.AddErrMsg("E230", String.Empty, facadeContext);
							return;
						}

						// [盗難品TBL(H)]を検索し、[経費振替申請TBL(H)]を登録する。
						BoSystemLog.logOut("[盗難品TBL(H)]を検索し、[経費振替申請TBL(H)]を登録 START");
						int insCntKeihiShinseiH = Ins_KeihiShinseiH(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo, dDenno);
						BoSystemLog.logOut("[盗難品TBL(H)]を検索し、[経費振替申請TBL(H)]を登録 END");

						// [盗難品TBL(B)]、[発注MST]を検索し、[経費振替申請TBL(B)]を登録する。
						BoSystemLog.logOut("[盗難品TBL(B)]、[発注MST]を検索し、[経費振替申請TBL(B)]を登録 START");
						int insCntKeihiShinseiB = Ins_KeihiShinseiB(facadeContext, f01m1VO, f02VO, logininfo, sysDateInfo, dDenno);
						BoSystemLog.logOut("[盗難品TBL(B)]、[発注MST]を検索し、[経費振替申請TBL(B)]を登録 END");
						#endregion
					}
					#endregion
				}
				#endregion

				#region 画面編集
				if (!f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					// 新規作成モード以外
					f01m1VO.M1jikohassei_ymd = f02VO.Jikohassei_ymd;								// Ｍ１事故発生日
					f01m1VO.M1hokoku_ymd = f02VO.Hokoku_ymd;										// Ｍ１報告日
					f01m1VO.Dictionary[Tf070p01Constant.DIC_M1HOKOKUTAN_CD] = f02VO.Hokokutan_cd;	// Ｍ１報告担当者コード
					f01m1VO.M1hokokutan_nm = f02VO.Hokokutan_nm;									// Ｍ１報告担当者名称
					f01m1VO.Dictionary[Tf070p01Constant.DIC_M1TENTYOTAN_CD] = f02VO.Tentyotan_cd;	// Ｍ１店長担当者コード
					f01m1VO.M1tentyotan_nm = f02VO.Tentyotan_nm;									// Ｍ１店長担当者名称
					f01m1VO.M1keisatsutodoke_ymd = f02VO.Keisatsutodoke_ymd;						// Ｍ１警察届出日
					f01m1VO.M1todokedesakikeisatsu_nm = f02VO.Todokedesakikeisatsu_nm;				// Ｍ１届出先警察署名
					f01m1VO.M1jyuri_no = f02VO.Jyuri_no;											// Ｍ１受理番号

					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;					// Ｍ１確定処理フラグ
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;						// Ｍ１明細色区分

					if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI))
					{
						// 経費申請モード
						f01m1VO.Dictionary[Tf070p01Constant.DIC_M1KEIHISINSEI_FLG] = BoSystemConstant.KEIHISINSEI_FLG_SINSEIZUMI;	// Ｍ１経費申請フラグ
					}
					else
					{
						// 修正モード
						f01m1VO.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD] = sysDateInfo.Sysdate;		// Ｍ１更新日
						f01m1VO.Dictionary[Tf070p01Constant.DIC_M1UPD_TM] = sysDateInfo.Systime_mili;	// Ｍ１更新時間
					}
				}
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 印刷処理
				string tenpohikae_f = Tf070p01Constant.TENPO_HIKAE_FLG_ON;	// 出力あり

				// 出力PDFファイル名のリスト
				List<string> pdfFileNmList = new List<string>();
				// 複数ファイルダウンロード用ディレクトリパス
				string multiDownloadPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);

				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{

					#region 新規作成
					// 登録伝票情報取得
					ArrayList torokuDenpyoList = facadeContext.UserMap[Tf070p01Constant.FCDUO_TOROKU_DENPYO_JOHO] as ArrayList;

					if (torokuDenpyoList != null && torokuDenpyoList.Count > 0)
					{
						#region 帳票パラメータ設定
						// 帳票ツールに渡すパラメータを格納
						InputData inputData = new InputData();

						// Xの場合、店舗控えの出力は行わない
						if (CheckCompanyCls.IsXebio())
						{
							tenpohikae_f = Tf070p01Constant.TENPO_HIKAE_FLG_OFF;	// 出力なし
						}

						foreach (Hashtable denpyoInfo in torokuDenpyoList)
						{
							// 店舗コード
							inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(denpyoInfo["TENPO_CD"].ToString()));
							// 管理№
							inputData.AddScreenParameter(2, denpyoInfo["KANRI_NO"].ToString());
							// 処理日付
							inputData.AddScreenParameter(3, denpyoInfo["SYORI_YMD"].ToString());
							// 印刷モード
							inputData.AddScreenParameter(4, Tf070p01Constant.PRINT_MODE_SHINKISAKUSEI);	// 新規作成
							// 店舗控えフラグ
							inputData.AddScreenParameter(5, tenpohikae_f);								// 出力あり
						}
						#endregion

						// 商品盗難事故報告書を出力する。
						// PDFファイル名
						string pdfFileNm = string.Format(
							"{0}.{1}",
							BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINTOUNANJIKOHOKOKUSYO),
							BoSystemConstant.RPT_PDF_EXTENSION
							);

						// 帳票を出力
						OutputInfo output = new BoSystemReport().MdGeneratePDF(
							inputData,
							BoSystemConstant.REPORTID_SYOHINTOUNANJIKOHOKOKUSYO,
							Tf070p01Constant.FORMID_01,
							Tf070p01Constant.PGID,
							pdfFileNm
							);

						BoSystemLog.logOut("ReportState［" + output.ReportState + "］");

						// PDFをファイルをユーザマップに設定
//						facadeContext.UserMap.Add(Tf070p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
		
						// PDFファイル名（ダウンロード用）
						pdfFileNm = string.Format(
							"{0}.{1}",
							BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SYOHINTOUNANJIKOHOKOKUSYO),
							BoSystemConstant.RPT_PDF_EXTENSION
							);

						if (!string.IsNullOrEmpty(output.TransferFile))
						{
							// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
							File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
						}

						// ファイル名をリストに追加
						pdfFileNmList.Add(pdfFileNm);
					}
					#endregion
				}
				else if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI))
				{
					#region 経費申請
//					// 出力PDFファイル名のリスト
//					List<string> pdfFileNmList = new List<string>();
					// 出力PDFファイル名
					string pdfFileNm = string.Empty;
					// 出力PDFファイル名（内部用）
					string pdfFileNmNaibu = string.Empty;

					// 帳票入力パラメータ
					InputData inputData;
					// 帳票出力情報
					OutputInfo output;
//					// 複数ファイルダウンロード用ディレクトリパス
//					string multiDownloadPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);

					#region 商品盗難事故報告書

					#region 帳票パラメータ設定
					// 帳票ツールに渡すパラメータを格納
					inputData = new InputData();

					// Xの場合、店舗控えの出力は行わない
					if (CheckCompanyCls.IsXebio())
					{
						tenpohikae_f = Tf070p01Constant.TENPO_HIKAE_FLG_OFF;	// 出力なし
					}

					// 店舗コード
					inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
					// 管理№
					inputData.AddScreenParameter(2, f02VO.Tonanhinkanri_no);
					// 処理日付
					inputData.AddScreenParameter(3, f01m1VO.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]);
					// 印刷モード
					inputData.AddScreenParameter(4, Tf070p01Constant.PRINT_MODE_KEIHISHINSEI);	// 経費申請
					// 店舗控えフラグ
					inputData.AddScreenParameter(5, tenpohikae_f);
					#endregion

					// 商品盗難事故報告書を出力する。
					// PDFファイル名（内部用）
					pdfFileNmNaibu = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINTOUNANJIKOHOKOKUSYO),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					// 帳票を出力
					output = new BoSystemReport().MdGeneratePDF(
						inputData,
						BoSystemConstant.REPORTID_SYOHINTOUNANJIKOHOKOKUSYO,
						Tf070p01Constant.FORMID_01,
						Tf070p01Constant.PGID,
						pdfFileNmNaibu
						);

					BoSystemLog.logOut("ReportState［" + output.ReportState + "］");

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(BoSystemConstant.REPORTNM_SYOHINTOUNANJIKOHOKOKUSYO),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					if (!string.IsNullOrEmpty(output.TransferFile))
					{
						// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
						File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
					}

					// ファイル名をリストに追加
					pdfFileNmList.Add(pdfFileNm);
					#endregion

					#region 商品経費振替伝票

					#region 帳票パラメータ設定
					// 帳票ツールに渡すパラメータを格納
					inputData = new InputData();

					// 店舗コード
					inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
					// 処理日
					inputData.AddScreenParameter(2, f01m1VO.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]);
					// 伝票番号
					inputData.AddScreenParameter(3, dDenno.ToString());
					// テーブル区分
					inputData.AddScreenParameter(4, Tf070p01Constant.TABLE_KBN_SHINSEI);	// 申請
					// 会社コード
					inputData.AddScreenParameter(5, BoSystemFormat.formatKaisyaCd(logininfo.CopCd));
					// 店舗控えフラグ
					inputData.AddScreenParameter(6, Tf070p01Constant.TENPO_HIKAE_FLG_ON);	// 出力あり
					#endregion

					// 商品経費振替伝票を出力する。
					string reportId;	// 帳票ID
					string reportNm;	// 帳票名
					if (CheckCompanyCls.IsXebio())
					{
						// Xの場合
						reportId = BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_X;
						reportNm = BoSystemConstant.REPORTNM_SYOHINKEIHIFURIKAEDENPYO_X;
					}
					else
					{
						reportId = BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_V;
						reportNm = BoSystemConstant.REPORTNM_SYOHINKEIHIFURIKAEDENPYO_V;
					}

					// PDFファイル名
					pdfFileNmNaibu = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(reportId),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					// 帳票を出力
					output = new BoSystemReport().MdGeneratePDF(
						inputData,
						reportId,
						Tf070p01Constant.FORMID_01,
						Tf070p01Constant.PGID,
						pdfFileNmNaibu
						);

					BoSystemLog.logOut("ReportState［" + output.ReportState + "］");

					// PDFファイル名（ダウンロード用）
					pdfFileNm = string.Format(
						"{0}.{1}",
						BoSystemReport.CreateFileName(reportNm),
						BoSystemConstant.RPT_PDF_EXTENSION
						);

					if (!string.IsNullOrEmpty(output.TransferFile))
					{
						// 出力されたPDFを複数ファイルダウンロード用ディレクトリにコピー
						File.Copy(output.TransferFile, multiDownloadPath + Path.DirectorySeparatorChar + pdfFileNm);
					}

					// ファイル名をリストに追加
					pdfFileNmList.Add(pdfFileNm);
					#endregion

					// 出力PDFファイル名のリストをユーザマップに設定
					//facadeContext.UserMap.Add(Tf070p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);
					#endregion
				}
				// 出力PDFファイル名のリストをユーザマップに設定
				facadeContext.UserMap.Add(Tf070p01Constant.FCDUO_RRT_FLNM, pdfFileNmList);
					
				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

		#region 売価金額計算処理（確定ボタン押下時）
		/// <summary>
		/// 売価金額計算処理（確定ボタン押下時）
		/// </summary>
		/// <param name="stkmodeno">選択モードNo</param>
		/// <param name="m1Form">明細画面の明細VO</param>
		/// <returns>売価金額</returns>
		private decimal CalcBaikaKin(string stkmodeno, Tf070f02M1Form m1Form)
		{
			// 売価金額
			decimal baikaKin = decimal.Zero;

			// Ｍ１申請数
			decimal sinseiSu;
			decimal.TryParse(m1Form.M1sinsei_su, out sinseiSu);

			// Ｍ１受理量
			decimal jyuriSu;
			decimal.TryParse(m1Form.M1jyuri_su, out jyuriSu);

			// Ｍ１売価（本体）
			decimal baikaHon;
			decimal.TryParse(m1Form.M1baika_hon, out baikaHon);

			// ■Ｍ１売価金額の算出
			if (stkmodeno.Equals(BoSystemConstant.MODE_INSERT)
				|| stkmodeno.Equals(BoSystemConstant.MODE_UPD)
				)
			{
				// 新規作成モード、修正モード
				// [Ｍ１売価（本体）]×[Ｍ１申請数]
				baikaKin = baikaHon * sinseiSu;
			}
			else
			{
				// 経費申請モード
				// [Ｍ１売価（本体）]×[Ｍ１受理数]
				baikaKin = baikaHon * jyuriSu;
			}

			return baikaKin;
		}
		#endregion

		#region 盗難品一時TBL登録
		/// <summary>
		/// [盗難品一時TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TonanhinT(IFacadeContext facadeContext, Tf070f02Form f02VO, LoginInfoVO loginInfo, SysDateVO sysDateInfo)
		{
			int iRownum = 0;
			IDataList m1List = f02VO.GetList("M1");

			// Oracleコマンドの生成
			OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
			// トランザクションの設定
			command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
			// SQLの実行タイプ
			command.CommandType = CommandType.Text;

			// パラメータバインド処理
			IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();
			int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）

			for (int i = 0; i < m1List.Count; i++)
			{
				Tf070f02M1Form f02m1VO = (Tf070f02M1Form)m1List[i];
				// スキャンコードが入力されている行が対象
				if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
				{
					counter++;
					iRownum++;

					Dictionary<string, string> bindDic = new Dictionary<string, string>();

					// 店舗コード
					BoSystemDb.setInsertVal("TENPO_CD", iRownum.ToString(), BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd), ref bindDic, ref command);
					// 担当者コード
					BoSystemDb.setInsertVal("TANTOSYA_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(loginInfo.TtsCd), ref bindDic, ref command);
					// 処理日付
					BoSystemDb.setInsertVal("SYORI_YMD", iRownum.ToString(), sysDateInfo.Sysdate, ref bindDic, ref command);
					// 処理時間
					BoSystemDb.setInsertVal("SYORI_TM", iRownum.ToString(), sysDateInfo.Systime_mili, ref bindDic, ref command);
					// 事故発生日
					BoSystemDb.setInsertVal("JIKOHASSEI_YMD", iRownum.ToString(), Convert.ToDecimal(BoSystemFormat.formatDate(f02VO.Jikohassei_ymd)), ref bindDic, ref command);
					// 報告日
					BoSystemDb.setInsertVal("HOKOKU_YMD", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f02VO.Hokoku_ymd), "0")), ref bindDic, ref command);
					// 報告担当者コード
					BoSystemDb.setInsertVal("HOKOKUTAN_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(f02VO.Hokokutan_cd), ref bindDic, ref command);
					// 部門コード
					BoSystemDb.setInsertVal("BUMON_CD", iRownum.ToString(), BoSystemFormat.formatBumonCd(f02m1VO.M1bumon_cd), ref bindDic, ref command);
					// 品種コード
					BoSystemDb.setInsertVal("HINSYU_CD", iRownum.ToString(), Convert.ToDecimal(f02m1VO.Dictionary[Tf070p01Constant.DIC_M1HINSYU_CD]), ref bindDic, ref command);
					// ブランドコード
					BoSystemDb.setInsertVal("BURANDO_CD", iRownum.ToString(), BoSystemFormat.formatBrandCd((string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1BURANDO_CD]), ref bindDic, ref command);
					// メーカー品番
					BoSystemDb.setInsertVal("MAKER_HBN", iRownum.ToString(), f02m1VO.M1maker_hbn, ref bindDic, ref command);
					// 商品名(カナ)
					BoSystemDb.setInsertVal("SYONMK", iRownum.ToString(), f02m1VO.M1syonmk, ref bindDic, ref command);
					// 自社品番
					BoSystemDb.setInsertVal("JISYA_HBN", iRownum.ToString(), f02m1VO.M1jisya_hbn, ref bindDic, ref command);
					// 色コード
					BoSystemDb.setInsertVal("IRO_CD", iRownum.ToString(), BoSystemFormat.formatIroCd((string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1MAKERCOLOR_CD]), ref bindDic, ref command);
					// サイズコード
					BoSystemDb.setInsertVal("SIZE_CD", iRownum.ToString(), BoSystemFormat.formatSizeCd((string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1SIZE_CD]), ref bindDic, ref command);
					// サイズ
					BoSystemDb.setInsertVal("SIZE_NM", iRownum.ToString(), f02m1VO.M1size_nm, ref bindDic, ref command);
					// ＪＡＮコード
					BoSystemDb.setInsertVal("JAN_CD", iRownum.ToString(), BoSystemFormat.formatJanCd((string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1JAN_CD]), ref bindDic, ref command);
					// 商品コード
					BoSystemDb.setInsertVal("SYOHIN_CD", iRownum.ToString(), (string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1SYOHIN_CD], ref bindDic, ref command);
					// 申請数
					BoSystemDb.setInsertVal("SINSEI_SU", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1sinsei_su), ref bindDic, ref command);
					// 売価
					BoSystemDb.setInsertVal("BAIKA_TNK", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1baika_hon), ref bindDic, ref command);
					// 発生時間
					BoSystemDb.setInsertVal("HASSEI_TM", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1hassei_tm), ref bindDic, ref command);
					// 発生場所
					BoSystemDb.setInsertVal("HASSEIBASYO", iRownum.ToString(), f02m1VO.M1hasseibasyo, ref bindDic, ref command);
					// 発見担当者コード
					BoSystemDb.setInsertVal("HAKKENTAN_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(f02m1VO.M1hakkentan_cd), ref bindDic, ref command);
					// 発見状況区分
					BoSystemDb.setInsertVal("HAKKENJYOKYO_KB", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1hakkenjyokyo_kb), ref bindDic, ref command);
					// 発見状況
					BoSystemDb.setInsertVal("HAKKENJYOKYO_NM", iRownum.ToString(), f02m1VO.M1hakkenjyokyo_nm, ref bindDic, ref command);
					// 受理数
					BoSystemDb.setInsertVal("JYURI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1jyuri_su, "0")), ref bindDic, ref command);
					// 店長担当者コード
					BoSystemDb.setInsertVal("TENTYOTAN_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(f02VO.Tentyotan_cd), ref bindDic, ref command);
					// 警察届出日
					BoSystemDb.setInsertVal("KEISATSUTODOKE_YMD", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f02VO.Keisatsutodoke_ymd), "0")), ref bindDic, ref command);
					// 届出先警察署名
					BoSystemDb.setInsertVal("TODOKEDESAKIKEISATSU_NM", iRownum.ToString(), f02VO.Todokedesakikeisatsu_nm, ref bindDic, ref command);
					// 受理番号
					BoSystemDb.setInsertVal("JYURI_NO", iRownum.ToString(), f02VO.Jyuri_no, ref bindDic, ref command);

					insertBindList.Add(bindDic);

					// 一括処理単位に達した場合は、マルチインサートを実行
					if (counter == 20)
					{
						// カウンタのリセット
						counter = 0;

						// マルチインサートの実行
						command.CommandText = GetSqlMultiInsT_TonanhinT(insertBindList);
						command.ExecuteNonQuery();

						// 配列、バインドパラメータのクリア
						insertBindList.Clear();
						command.Parameters.Clear();
					}
				}

			}// for

			// 未登録レコードの登録
			if (counter > 0)
			{
				// マルチインサートの実行
				command.CommandText = GetSqlMultiInsT_TonanhinT(insertBindList);
				command.ExecuteNonQuery();
			}

			return iRownum;
		}
		#endregion

		#region 盗難品一時TBLへのマルチインサート文作成
		/// <summary>
		/// [盗難品一時TBL]へのマルチインサートを行うSQL文を取得する。
		/// </summary>
		/// <param name="insertBindList">バインドテキスト</param>
		/// <returns>SQL文</returns>
		private string GetSqlMultiInsT_TonanhinT(IList<Dictionary<string, string>> insertBindList)
		{
			IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

			// バインドテキストのデータ分INSERT文を作成
			foreach (Dictionary<string, string> bindDic in insertBindList)
			{
				StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文
				insertSql.Append("    INTO MDAT0040_TEMP VALUES ( ");
				insertSql.Append(bindDic["TENPO_CD"]).Append(" , ");				// 店舗コード
				insertSql.Append(bindDic["TANTOSYA_CD"]).Append(" , ");				// 担当者コード
				insertSql.Append(bindDic["SYORI_YMD"]).Append(" , ");				// 処理日付
				insertSql.Append(bindDic["SYORI_TM"]).Append(" , ");				// 処理時間
				insertSql.Append(bindDic["JIKOHASSEI_YMD"]).Append(" , ");			// 事故発生日
				insertSql.Append(bindDic["HOKOKU_YMD"]).Append(" , ");				// 報告日
				insertSql.Append(bindDic["HOKOKUTAN_CD"]).Append(" , ");			// 報告担当者コード
				insertSql.Append(bindDic["BUMON_CD"]).Append(" , ");				// 部門コード
				insertSql.Append(bindDic["HINSYU_CD"]).Append(" , ");				// 品種コード
				insertSql.Append(bindDic["BURANDO_CD"]).Append(" , ");				// ブランドコード
				insertSql.Append(bindDic["MAKER_HBN"]).Append(" , ");				// メーカー品番
				insertSql.Append(bindDic["SYONMK"]).Append(" , ");					// 商品名(カナ)
				insertSql.Append(bindDic["JISYA_HBN"]).Append(" , ");				// 自社品番
				insertSql.Append(bindDic["IRO_CD"]).Append(" , ");					// 色コード
				insertSql.Append(bindDic["SIZE_CD"]).Append(" , ");					// サイズコード
				insertSql.Append(bindDic["SIZE_NM"]).Append(" , ");					// サイズ
				insertSql.Append(bindDic["JAN_CD"]).Append(" , ");					// ＪＡＮコード
				insertSql.Append(bindDic["SYOHIN_CD"]).Append(" , ");				// 商品コード
				insertSql.Append(bindDic["SINSEI_SU"]).Append(" , ");				// 申請数
				insertSql.Append(bindDic["BAIKA_TNK"]).Append(" , ");				// 売価
				insertSql.Append(bindDic["HASSEI_TM"]).Append(" , ");				// 発生時間
				insertSql.Append(bindDic["HASSEIBASYO"]).Append(" , ");				// 発生場所
				insertSql.Append(bindDic["HAKKENTAN_CD"]).Append(" , ");			// 発見担当者コード
				insertSql.Append(bindDic["HAKKENJYOKYO_KB"]).Append(" , ");			// 発見状況区分
				insertSql.Append(bindDic["HAKKENJYOKYO_NM"]).Append(" , ");			// 発見状況
				insertSql.Append(bindDic["JYURI_SU"]).Append(" , ");				// 受理数
				insertSql.Append(bindDic["TENTYOTAN_CD"]).Append(" , ");			// 店長担当者コード
				insertSql.Append(bindDic["KEISATSUTODOKE_YMD"]).Append(" , ");		// 警察届出日
				insertSql.Append(bindDic["TODOKEDESAKIKEISATSU_NM"]).Append(" , ");	// 届出先警察署名
				insertSql.Append(bindDic["JYURI_NO"]);								// 受理番号
				insertSql.Append(" ) ");

				insertSqlList.Add(insertSql.ToString());
			}

			// 単一INSERTをまとめて、マルチインサート文を作成
			StringBuilder sql = new StringBuilder();
			sql.AppendLine("INSERT ALL");
			foreach (string sqlpart in insertSqlList)
			{
				sql.AppendLine(sqlpart);
			}
			sql.AppendLine("SELECT 1 FROM DUAL");

			return sql.ToString();
		}
		#endregion

		#region ストアド（盗難品登録処理）起動
		/// <summary>
		/// ストアド（盗難品登録処理）起動
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		private void ExceInsertStolenItem(IFacadeContext facadeContext)
		{
			#region ■パラメータ設定
			ArrayList inParamList = new ArrayList();
			#endregion

			// ■ストアド呼び出し
			ArrayList outParamList = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, Tf070p01Constant.PROC_NAME_INSERT_STOLEN_ITEM, inParamList);

			#region ■例外処理
			if (outParamList != null && outParamList.Count > 0)
			{
				// エラーコード
				string errCd = outParamList[0].ToString();

				if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
				{
					// 正常終了
				}
				else if (errCd.Equals(BoSystemConstant.STORED_NUMBERING_ERR))
				{
					// 採番不可の場合
					ErrMsgCls.AddErrMsg("E230", string.Empty, facadeContext);
					return;
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［" + Tf070p01Constant.PROC_NAME_INSERT_STOLEN_ITEM + "］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［" + Tf070p01Constant.PROC_NAME_INSERT_STOLEN_ITEM + "］実行時にエラーが発生しました。");
			}
			#endregion

			// 登録伝票情報を設定
			facadeContext.UserMap[Tf070p01Constant.FCDUO_TOROKU_DENPYO_JOHO] = outParamList[1];
		}
		#endregion

		#region 盗難品履歴TBL(B)登録（赤）
		/// <summary>
		/// [盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（赤）を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面で選択した明細VO</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TonanhinRirekiB_Aka(
			IFacadeContext facadeContext,
			Tf070f01M1Form f01M1Form,
			Tf070f02Form f02Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f02Form.Tonanhinkanri_no));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品TBL(B)削除
		/// <summary>
		/// [盗難品TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面で選択した明細VO</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Del_TonanhinB(
			IFacadeContext facadeContext,
			Tf070f01M1Form f01M1Form,
			Tf070f02Form f02Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f02Form.Tonanhinkanri_no));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品TBL(B)登録
		/// <summary>
		/// [盗難品TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01m1VO">一覧画面で選択した明細VO</param>
		/// <param name="f02VO">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TonanhinB(IFacadeContext facadeContext, Tf070f01M1Form f01m1VO, Tf070f02Form f02VO, LoginInfoVO loginInfo, SysDateVO sysDateInfo)
		{
			int iRownum = 0;
			IDataList m1List = f02VO.GetList("M1");

			// Oracleコマンドの生成
			OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
			// トランザクションの設定
			command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
			// SQLの実行タイプ
			command.CommandType = CommandType.Text;

			// パラメータバインド処理
			IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();
			int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）

			for (int i = 0; i < m1List.Count; i++)
			{
				Tf070f02M1Form f02m1VO = (Tf070f02M1Form)m1List[i];
				// スキャンコードが入力されている行が対象
				if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
				{
					counter++;
					iRownum++;

					Dictionary<string, string> bindDic = new Dictionary<string, string>();

					// 管理№
					BoSystemDb.setInsertVal("KANRI_NO", iRownum.ToString(), Convert.ToDecimal(f02VO.Tonanhinkanri_no), ref bindDic, ref command);
					// 処理日付
					BoSystemDb.setInsertVal("SYORI_YMD", iRownum.ToString(), Convert.ToDecimal(f01m1VO.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]), ref bindDic, ref command);
					// 処理時間
					BoSystemDb.setInsertVal("SYORI_TM", iRownum.ToString(), Convert.ToDecimal(f01m1VO.Dictionary[Tf070p01Constant.DIC_M1SYORI_TM]), ref bindDic, ref command);
					// 店舗コード
					BoSystemDb.setInsertVal("TENPO_CD", iRownum.ToString(), BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd), ref bindDic, ref command);
					// 伝票行№
					BoSystemDb.setInsertVal("DENPYOGYO_NO", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1rowno), ref bindDic, ref command);
					// 部門コード
					BoSystemDb.setInsertVal("BUMON_CD", iRownum.ToString(), BoSystemFormat.formatBumonCd(f02m1VO.M1bumon_cd), ref bindDic, ref command);
					// 品種コード
					BoSystemDb.setInsertVal("HINSYU_CD", iRownum.ToString(), Convert.ToDecimal(f02m1VO.Dictionary[Tf070p01Constant.DIC_M1HINSYU_CD]), ref bindDic, ref command);
					// ブランドコード
					BoSystemDb.setInsertVal("BURANDO_CD", iRownum.ToString(), BoSystemFormat.formatBrandCd((string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1BURANDO_CD]), ref bindDic, ref command);
					// メーカー品番
					BoSystemDb.setInsertVal("MAKER_HBN", iRownum.ToString(), f02m1VO.M1maker_hbn, ref bindDic, ref command);
					// 商品名(カナ)
					BoSystemDb.setInsertVal("SYONMK", iRownum.ToString(), f02m1VO.M1syonmk, ref bindDic, ref command);
					// 自社品番
					BoSystemDb.setInsertVal("JISYA_HBN", iRownum.ToString(), f02m1VO.M1jisya_hbn, ref bindDic, ref command);
					// 色コード
					BoSystemDb.setInsertVal("IRO_CD", iRownum.ToString(), BoSystemFormat.formatIroCd((string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1MAKERCOLOR_CD]), ref bindDic, ref command);
					// サイズコード
					BoSystemDb.setInsertVal("SIZE_CD", iRownum.ToString(), BoSystemFormat.formatSizeCd((string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1SIZE_CD]), ref bindDic, ref command);
					// サイズ
					BoSystemDb.setInsertVal("SIZE_NM", iRownum.ToString(), f02m1VO.M1size_nm, ref bindDic, ref command);
					// ＪＡＮコード
					BoSystemDb.setInsertVal("JAN_CD", iRownum.ToString(), BoSystemFormat.formatJanCd((string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1JAN_CD]), ref bindDic, ref command);
					// 商品コード
					BoSystemDb.setInsertVal("SYOHIN_CD", iRownum.ToString(), (string)f02m1VO.Dictionary[Tf070p01Constant.DIC_M1SYOHIN_CD], ref bindDic, ref command);
					// 申請数
					BoSystemDb.setInsertVal("SINSEI_SU", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1sinsei_su), ref bindDic, ref command);
					// 受理数
					BoSystemDb.setInsertVal("JYURI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1jyuri_su, "0")), ref bindDic, ref command);
					// 売価
					BoSystemDb.setInsertVal("BAIKA_TNK", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1baika_hon), ref bindDic, ref command);
					// 発生時間
					BoSystemDb.setInsertVal("HASSEI_TM", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1hassei_tm), ref bindDic, ref command);
					// 発生場所
					BoSystemDb.setInsertVal("HASSEIBASYO", iRownum.ToString(), f02m1VO.M1hasseibasyo, ref bindDic, ref command);
					// 発見担当者コード
					BoSystemDb.setInsertVal("HAKKENTAN_CD", iRownum.ToString(), BoSystemFormat.formatTantoCd(f02m1VO.M1hakkentan_cd), ref bindDic, ref command);
					// 発見状況区分
					BoSystemDb.setInsertVal("HAKKENJYOKYO_KB", iRownum.ToString(), Convert.ToDecimal(f02m1VO.M1hakkenjyokyo_kb), ref bindDic, ref command);
					// 発見状況
					BoSystemDb.setInsertVal("HAKKENJYOKYO_NM", iRownum.ToString(), f02m1VO.M1hakkenjyokyo_nm, ref bindDic, ref command);

					insertBindList.Add(bindDic);

					// 一括処理単位に達した場合は、マルチインサートを実行
					if (counter == 20)
					{
						// カウンタのリセット
						counter = 0;

						// マルチインサートの実行
						command.CommandText = GetSqlMultiInsT_TonanhinB(insertBindList);
						command.ExecuteNonQuery();

						// 配列、バインドパラメータのクリア
						insertBindList.Clear();
						command.Parameters.Clear();
					}
				}

			}// for

			// 未登録レコードの登録
			if (counter > 0)
			{
				// マルチインサートの実行
				command.CommandText = GetSqlMultiInsT_TonanhinB(insertBindList);
				command.ExecuteNonQuery();
			}

			return iRownum;
		}
		#endregion

		#region 盗難品TBL(B)へのマルチインサート文作成
		/// <summary>
		/// [盗難品TBL(B)]へのマルチインサートを行うSQL文を取得する。
		/// </summary>
		/// <param name="insertBindList">バインドテキスト</param>
		/// <returns>SQL文</returns>
		private string GetSqlMultiInsT_TonanhinB(IList<Dictionary<string, string>> insertBindList)
		{
			IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

			// バインドテキストのデータ分INSERT文を作成
			foreach (Dictionary<string, string> bindDic in insertBindList)
			{
				StringBuilder insertSql = new StringBuilder();		// 単一のINSERT文
				insertSql.Append("    INTO MDAT0041 VALUES ( ");	// 盗難品TBL(B)
				insertSql.Append(bindDic["KANRI_NO"]).Append(" , ");		// 管理№
				insertSql.Append(bindDic["SYORI_YMD"]).Append(" , ");		// 処理日付
				insertSql.Append(bindDic["SYORI_TM"]).Append(" , ");		// 処理時間
				insertSql.Append(bindDic["TENPO_CD"]).Append(" , ");		// 店舗コード
				insertSql.Append(bindDic["DENPYOGYO_NO"]).Append(" , ");	// 伝票行№
				insertSql.Append(bindDic["BUMON_CD"]).Append(" , ");		// 部門コード
				insertSql.Append(bindDic["HINSYU_CD"]).Append(" , ");		// 品種コード
				insertSql.Append(bindDic["BURANDO_CD"]).Append(" , ");		// ブランドコード
				insertSql.Append(bindDic["MAKER_HBN"]).Append(" , ");		// メーカー品番
				insertSql.Append(bindDic["SYONMK"]).Append(" , ");			// 商品名(カナ)
				insertSql.Append(bindDic["JISYA_HBN"]).Append(" , ");		// 自社品番
				insertSql.Append(bindDic["IRO_CD"]).Append(" , ");			// 色コード
				insertSql.Append(bindDic["SIZE_CD"]).Append(" , ");			// サイズコード
				insertSql.Append(bindDic["SIZE_NM"]).Append(" , ");			// サイズ
				insertSql.Append(bindDic["JAN_CD"]).Append(" , ");			// ＪＡＮコード
				insertSql.Append(bindDic["SYOHIN_CD"]).Append(" , ");		// 商品コード
				insertSql.Append(bindDic["SINSEI_SU"]).Append(" , ");		// 申請数
				insertSql.Append(bindDic["JYURI_SU"]).Append(" , ");		// 受理数
				insertSql.Append(bindDic["BAIKA_TNK"]).Append(" , ");		// 売価
				insertSql.Append(bindDic["HASSEI_TM"]).Append(" , ");		// 発生時間
				insertSql.Append(bindDic["HASSEIBASYO"]).Append(" , ");		// 発生場所
				insertSql.Append(bindDic["HAKKENTAN_CD"]).Append(" , ");	// 発見担当者コード
				insertSql.Append(bindDic["HAKKENJYOKYO_KB"]).Append(" , ");	// 発見状況区分
				insertSql.Append(bindDic["HAKKENJYOKYO_NM"]);				// 発見状況
				insertSql.Append(" ) ");

				insertSqlList.Add(insertSql.ToString());
			}

			// 単一INSERTをまとめて、マルチインサート文を作成
			StringBuilder sql = new StringBuilder();
			sql.AppendLine("INSERT ALL");
			foreach (string sqlpart in insertSqlList)
			{
				sql.AppendLine(sqlpart);
			}
			sql.AppendLine("SELECT 1 FROM DUAL");

			BoSystemLog.logOut(sql.ToString());

			return sql.ToString();
		}
		#endregion

		#region 盗難品履歴TBL(B)登録（黒）
		/// <summary>
		/// [盗難品TBL(B)]を検索し、[盗難品履歴TBL(B)]（黒）を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面で選択した明細VO</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TonanhinRirekiB_Kuro(
			IFacadeContext facadeContext,
			Tf070f01M1Form f01M1Form,
			Tf070f02Form f02Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f02Form.Tonanhinkanri_no));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品履歴TBL(H)登録（赤）
		/// <summary>
		/// [盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]（赤）を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面で選択した明細VO</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TonanhinRirekiH_Aka(
			IFacadeContext facadeContext,
			Tf070f01M1Form f01M1Form,
			Tf070f02Form f02Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 履歴処理日付
			reader.BindValue("RIREKI_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("RIREKI_SYORI_TM", sysDateVO.Systime_mili);

			// 更新日
			reader.BindValue("UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", sysDateVO.Sysdate);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f02Form.Tonanhinkanri_no));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品TBL(H)更新
		/// <summary>
		/// [盗難品TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面で選択した明細VO</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="gokeisinseiSu">合計申請数</param>
		/// <param name="gokeijyuriSu">合計受理数</param>
		/// <param name="gokeibaikaKin">合計売価金額</param>
		/// <returns>更新件数</returns>
		private int Upd_TonanhinH(
			IFacadeContext facadeContext,
			Tf070f01M1Form f01M1Form,
			Tf070f02Form f02Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO,
			decimal gokeisinseiSu,
			decimal gokeijyuriSu,
			decimal gokeibaikaKin
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_15, facadeContext.DBContext);

			// 事故発生日
			reader.BindValue("JIKOHASSEI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02Form.Jikohassei_ymd)));
			// 報告日
			reader.BindValue("HOKOKU_YMD", Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f02Form.Hokoku_ymd), "0")));
			// 報告担当者コード
			reader.BindValue("HOKOKUTAN_CD", BoSystemFormat.formatTantoCd(f02Form.Hokokutan_cd));
			// 店長担当者コード
			reader.BindValue("TENTYOTAN_CD", BoSystemFormat.formatTantoCd(f02Form.Tentyotan_cd));
			// 警察届出日
			reader.BindValue("KEISATSUTODOKE_YMD", Convert.ToDecimal(BoSystemString.Nvl(BoSystemFormat.formatDate(f02Form.Keisatsutodoke_ymd), "0")));
			// 届出先警察署名
			reader.BindValue("TODOKEDESAKIKEISATSU_NM", f02Form.Todokedesakikeisatsu_nm);
			// 受理番号
			reader.BindValue("JYURI_NO", f02Form.Jyuri_no);
			// 合計申請数
			reader.BindValue("GOKEISINSEI_SU", gokeisinseiSu);
			// 合計受理数
			reader.BindValue("GOKEIJYURI_SU", gokeijyuriSu);
			// 合計売価金額
			reader.BindValue("GOKEIBAIKA_KIN", gokeibaikaKin);
			// 経費申請フラグ
			if (f02Form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI))
			{
				// [選択モードNO]が「経費申請」の場合
				reader.BindValue("KEIHISINSEI_FLG", Convert.ToDecimal(BoSystemConstant.KEIHISINSEI_FLG_SINSEIZUMI));
			}
			else
			{
				// [選択モードNO]が「修正」の場合
				reader.BindValue("KEIHISINSEI_FLG", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KEIHISINSEI_FLG]));
			}
			// 経費申請日
			if (f02Form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI))
			{
				// [選択モードNO]が「経費申請」の場合
				reader.BindValue("KEIHISINSEI_YMD", sysDateVO.Sysdate);
			}
			else
			{
				// [選択モードNO]が「修正」の場合
				reader.BindValue("KEIHISINSEI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1KEIHISINSEI_YMD]));
			}
			// 更新日
			reader.BindValue("UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			if (f02Form.Stkmodeno.Equals(BoSystemConstant.MODE_KEIHISINSEI))
			{
				// [選択モードNO]が「経費申請」の場合
				reader.BindValue("SAKUJYO_FLG", 1);
			}
			else
			{
				// [選択モードNO]が「修正」の場合
				reader.BindValue("SAKUJYO_FLG", 0);
			}

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f02Form.Tonanhinkanri_no));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 盗難品履歴TBL(H)登録（黒）
		/// <summary>
		/// [盗難品TBL(H)]を検索し、[盗難品履歴TBL(H)]（黒）を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面で選択した明細VO</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_TonanhinRirekiH_Kuro(
			IFacadeContext facadeContext,
			Tf070f01M1Form f01M1Form,
			Tf070f02Form f02Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_16, facadeContext.DBContext);

			// 履歴処理日付
			reader.BindValue("RIREKI_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("RIREKI_SYORI_TM", sysDateVO.Systime_mili);

			// 更新日
			reader.BindValue("UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", sysDateVO.Sysdate);

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f02Form.Tonanhinkanri_no));
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 経費振替伝票番号採番
		/// <summary>
		/// 経費振替伝票番号の採番を行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>伝票番号 ※採番不可の場合は、-1を戻す</returns>
		private decimal AutoNumber_KeiFuriDenNo(
			IFacadeContext facadeContext,
			Tf070f02Form f02Form,
			Tf070f01M1Form f01M1Form,
			LoginInfoVO loginInfo
			)
		{
			Boolean loop = true;
			decimal loopCnt = 0;
			string denno = string.Empty;

			while (loop)
			{
				// 採番を行う
				denno = NumberingCls.Numbering(
					facadeContext,
					BoSystemConstant.AUTONUM_KEIHURI_DENPYONO,
					"0000",
					loginInfo.LoginId
					);

				decimal dDenno = Convert.ToDecimal(denno);

				// 採番値が既にテーブルで使用されていないかチェック(※されている場合は次の番号を採番)
				// XMLからSQLを取得する。
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_17, facadeContext.DBContext);

				// 店舗コード
				reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
				// 伝票番号
				reader.BindValue("DENPYO_BANGO", dDenno);
				// 処理日付
				reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

				// SQL実行
				IList<Hashtable> ItemList = reader.Execute();

				if (ItemList == null || ItemList.Count <= 0)
				{
					// 伝票番号が未存在の場合、採番OK
					break;
				}
				else
				{
					Hashtable ht = (Hashtable)ItemList[0];
					if ((decimal)ht["CNT"] <= 0)
					{
						// 伝票番号が未存在の場合、採番OK
						break;
					}
				}

				loopCnt++;

				if (loopCnt >= 999999)
				{
					// 採番可能数を超えた場合、処理終了
					return -1;
				}
			}
			return Convert.ToDecimal(BoSystemString.Nvl(denno, "-1"));
		}
		#endregion

		#region 経費振替申請TBL(H)登録
		/// <summary>
		/// [盗難品TBL(H)]を検索し、[経費振替申請TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面で選択した明細VO</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="denpyoBango">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_KeihiShinseiH(
			IFacadeContext facadeContext,
			Tf070f01M1Form f01M1Form,
			Tf070f02Form f02Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO,
			decimal denpyoBango
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_18, facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("DENPYO_BANGO", denpyoBango);
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));
			// 処理時間
			reader.BindValue("SYORI_TM", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_TM]));
			// 申請日
			reader.BindValue("APPLY_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));
			// 登録日
			reader.BindValue("ADD_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));
			// 登録時間
			reader.BindValue("ADD_TM", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_TM]));
			// 登録担当者コード
			reader.BindValue("ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("UPD_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));
			// 更新時間
			reader.BindValue("UPD_TM", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_TM]));
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f02Form.Tonanhinkanri_no));
			// 処理日付
			reader.BindValue("SYORI_YMD2", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 経費振替申請TBL(B)登録
		/// <summary>
		/// [盗難品TBL(B)]、[発注MST]を検索し、[経費振替申請TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面で選択した明細VO</param>
		/// <param name="f02Form">明細画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="denpyoBango">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_KeihiShinseiB(
			IFacadeContext facadeContext,
			Tf070f01M1Form f01M1Form,
			Tf070f02Form f02Form,
			LoginInfoVO loginInfo,
			SysDateVO sysDateVO,
			decimal denpyoBango
			)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_19, facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("DENPYO_BANGO", denpyoBango);
			// 処理日付
			reader.BindValue("SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_YMD]));
			// 処理時間
			reader.BindValue("SYORI_TM", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1UPD_TM]));

			// 店舗コード
			reader.BindValue("TENPO_CD", BoSystemFormat.formatTenpoCd(f02Form.Head_tenpo_cd));
			// 管理№
			reader.BindValue("KANRI_NO", Convert.ToDecimal(f02Form.Tonanhinkanri_no));
			// 処理日付
			reader.BindValue("SYORI_YMD2", Convert.ToDecimal(f01M1Form.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
	}
}
