using com.xebio.bo.Tk020p01.Constant;
using com.xebio.bo.Tk020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01004;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C04000.C04001;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tk020p01.Facade
{
  /// <summary>
  /// Tk020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk020f01Facade : StandardBaseFacade
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

				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tk020f01Form f01VO = (Tk020f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// カウンタ
				int iNonSelect = 0;		// 選択フラグ
				int iNonM1scanCnt = 0;	// スキャンコード

				// 警告メッセージの応答結果を取得
				string waningflg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				// システム日付(DateTime型)
				DateTime dtsysDate = DateTime.ParseExact(sysDateVO.Sysdate.ToString(), "yyyyMMdd", null);
				#endregion

				#region 業務チェック
				for (int iRow = 0; iRow < m1List.Count; iRow++)
				{
					// 明細情報
					Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List[iRow];

					// 選択フラグ
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_OFF))
					{	// 選択なし
						iNonSelect++;
					}
					else
					{	// 選択あり
						// 入力なしスキャンコードカウント
						if (string.IsNullOrEmpty(f01m1VO.M1scan_cd))
						{
							iNonM1scanCnt++;
						}
						else
						{
							#region 単項目チェック
							#region スキャンコード
							// 発注マスタを検索し、存在しない場合エラー
							if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd))
							{
								SearchHachuVO searchConditionVO = new SearchHachuVO(
									f01m1VO.M1scan_cd,		// スキャンコード
									f01VO.Head_tenpo_cd,	// 店舗コード
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
								Hashtable hs = V01004Check.CheckScanCd(
									searchConditionVO
									, facadeContext
									, "スキャンコード"
									, new[] { "Scan_cd" }
									, f01m1VO.M1rowno
									, iRow.ToString()
									, "M1"
									, Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper()))
								);

								// Dictionary（更新用）
								if (hs != null)
								{
									f01m1VO.Dictionary[Tk020p01Constant.DIC_BURANDO_CD] = hs["BURANDO_CD"].ToString();		// ブランドコード
									f01m1VO.Dictionary[Tk020p01Constant.DIC_SYOHIN_CD] = hs["SYOHIN_CD"].ToString();		// 商品コード
									f01m1VO.Dictionary[Tk020p01Constant.DIC_IRO_CD] = hs["MAKERCOLOR_CD"].ToString();		// 色コード
									f01m1VO.Dictionary[Tk020p01Constant.DIC_SIZE_CD] = hs["SIZE_CD"].ToString();			// サイズコード
									f01m1VO.Dictionary[Tk020p01Constant.DIC_TYOTATSU_KB] = hs["TYOTATSU_KB"].ToString();	// 調達区分

									f01m1VO.Dictionary[Tk020p01Constant.DIC_BUMON_CD] = hs["BUMON_CD"].ToString();						// [部門コード]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_HINSYU_CD] = hs["HINSYU_CD"].ToString();					// [品種コード]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_JISYA_HBN] = hs["XEBIO_CD"].ToString();						// [自社品番]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_HANBAIKANRYO_YMD] = hs["HANBAIKANRYO_YMD"].ToString();		// [販売完了日]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_MAKER_HBN] = hs["HIN_NBR"].ToString();						// [メーカー品番]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_SYONMK] = hs["SYONMK"].ToString();							// [商品名(カナ)]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_JAN_CD] = hs["JAN_CD"].ToString();							// [ＪＡＮコード]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_SIZE_NM] = hs["SIZE_NM"].ToString();						// [サイズ名]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_JODAI1_TNK] = hs["SLPR"].ToString();						// [上代1]
									f01m1VO.Dictionary[Tk020p01Constant.DIC_GEN_TNK] = hs["GENKA"].ToString();							// [原単価]

									// 行追加の場合
									if (string.IsNullOrEmpty(BoSystemString.Nvl(f01m1VO.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString())))
									{
										f01m1VO.Dictionary[Tk020p01Constant.DIC_SAISHINSEI_FLG] = (0).ToString();				// 再申請フラグ

										f01m1VO.Dictionary[Tk020p01Constant.DIC_SYORI_YMD] = sysDateVO.Sysdate.ToString();		// 処理日付
										f01m1VO.Dictionary[Tk020p01Constant.DIC_SYORI_TM] = sysDateVO.Systime_mili.ToString();	// 処理時間

										f01m1VO.Dictionary[Tk020p01Constant.DIC_HYOKASON_SU] = f01m1VO.M1hyokason_su.ToString();			// [評価損数量]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_HYOKASONSYUBETSU_KB] = f01m1VO.M1hyokason_su.ToString();	// [評価損種別区分]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_HYOKASONRIYU_KB] = f01m1VO.M1hyokason_su.ToString();		// [評価損理由区分]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_HYOKASONRIYU] = f01m1VO.M1hyokason_su.ToString(); ;			// [評価損理由]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_SYONIN_JOTAI_KB] = (1).ToString();							// [承認状態]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_KESSAI_JOTAI_KB] = (0).ToString(); ;						// [決裁状態]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_APPLY_YMD] = sysDateVO.Sysdate.ToString();					// [申請日]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_ADD_YMD] = sysDateVO.Sysdate.ToString();					// [登録日]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_ADD_TM] = sysDateVO.Systime_mili.ToString();				// [登録時間]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_ADDTAN_CD] = logininfo.TtsCd.ToString();					// [登録担当者コード]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_HHTSERIAL_NO] = null;					// [HHTシリアル番号]
										f01m1VO.Dictionary[Tk020p01Constant.DIC_HHTSEQUENCE_NO] = (0).ToString();				// [HHTシーケンスNo.]
									}
								}
							}
							#endregion

							#region Ｍ１数量
							if (!string.IsNullOrEmpty(f01m1VO.M1hyokason_su))
							{
								if (f01m1VO.M1hyokason_su.Equals("0"))
								{
									// "0"が入力された場合、エラー

									// {数量}に0は入力できません。
									ErrMsgCls.AddErrMsg(
										"E103"
										, "数量"
										, facadeContext
										, new[] { "M1hyokason_su" }
										, f01m1VO.M1rowno
										, iRow.ToString()
										, "M1"
									);
								}
							}
							else
							{
								// 入力されていない場合、エラー

								// {数量}を入力して下さい。
								ErrMsgCls.AddErrMsg(
									"E121"
									, "数量"
									, facadeContext
									, new[] { "M1hyokason_su" }
									, f01m1VO.M1rowno
									, iRow.ToString()
									, "M1"
								);
							}
							#endregion

							#region Ｍ１評価損種別区分
							// [評価損種別]で[経年品]選択時
							if (f01m1VO.M1hyokasonsyubetsu_kb.Equals(ConditionHyokason_syubetsu.VALUE_HYOKASON_SYUBETSU2))
							{
								// [評価損理由]を[経年商品]に設定
								f01m1VO.M1hyokasonriyu_kb = ConditionHyokason_riyiu.VALUE_HYOKASON_RIYIU12;
							}

							// 空白が選ばれている場合、エラー
							if (f01m1VO.M1hyokasonsyubetsu_kb.ToString().Equals("-1"))
							{
								// {評価損種別}を入力して下さい。
								ErrMsgCls.AddErrMsg(
									"E121"
									, "評価損種別"
									, facadeContext
									, new[] { "M1hyokasonsyubetsu_kb" }
									, f01m1VO.M1rowno
									, iRow.ToString()
									, "M1"
								);
							}
							#endregion

							#region Ｍ１評価損理由
							// 空白が選ばれている場合、エラー
							if (f01m1VO.M1hyokasonriyu_kb.ToString().Equals("-1"))
							{
								// {評価損理由}を入力して下さい。
								ErrMsgCls.AddErrMsg(
									"E121"
									, "評価損理由"
									, facadeContext
									, new[] { "M1hyokasonriyu_kb" }
									, f01m1VO.M1rowno
									, iRow.ToString()
									, "M1"
								);
							}
							#endregion

							#region Ｍ１評価損理由区分
							// [Ｍ１評価損理由区分]で[その他]選択時、入力されていない場合、エラー
							if (f01m1VO.M1hyokasonriyu_kb.Equals(ConditionHyokason_riyiu.VALUE_HYOKASON_RIYIU13))
							{
								if (string.IsNullOrEmpty(f01m1VO.M1hyokasonriyu))
								{
									// {その他選択時、評価損理由}は必ず入力して下さい。
									ErrMsgCls.AddErrMsg(
										"E118"
										, "その他選択時、評価損理由"
										, facadeContext
										, new[] { "M1hyokasonriyu" }
										, f01m1VO.M1rowno
										, iRow.ToString()
										, "M1"
									);
								}
							}

							#region 関連チェック
							// [Ｍ１評価損種別区分]が「経年品」の場合、[Ｍ１販売完了日]が当期の4期より前でない場合エラー
							if (f01m1VO.M1hyokasonsyubetsu_kb.Equals(ConditionHyokason_syubetsu.VALUE_HYOKASON_SYUBETSU2))
							{
								//経年品の場合、販売完了日が4期より前でない場合エラーとする。
								int intHanbaiKanryoDate = int.Parse(BoSystemFormat.formatDate(f01m1VO.M1hanbaikanryo_ymd.ToString()));

								//システム日付の2年前を取得し、期末日を求める。
								int intbeforedate = int.Parse(TermEndDate.getTermEndDate(dtsysDate.AddYears(-2).ToString()));

								if (intHanbaiKanryoDate > intbeforedate)
								{
									// 経年商品として登録できません。
									ErrMsgCls.AddErrMsg(
										"E197"
										, string.Empty
										, facadeContext
										, new[] { "M1scan_cd" }
										, f01m1VO.M1rowno
										, iRow.ToString()
										, "M1"
									);
								}
							}
							#endregion

							#endregion
							#endregion
						}
					}
				}

				#region 件数チェック
				if (m1List.ListRemovedData.Count == 0 && (iNonSelect == m1List.Count || iNonM1scanCnt == m1List.Count - iNonSelect))
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
				}
				#endregion

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				
				#endregion

				#region ワーニング　Ｍ１数量
				for (int iRow = 0; iRow < m1List.Count; iRow++)
				{
					// 明細情報
					Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List[iRow];

					// 選択済み
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// 入力済みスキャンコード
						if (!string.IsNullOrEmpty(f01m1VO.M1scan_cd))
						{
							if (!"1".Equals(waningflg))
							{
								// 4桁以上入力されている場合、警告 
								// 絶対値取得
								if (Math.Abs(Convert.ToDecimal(f01m1VO.M1hyokason_su)).ToString().Length >= 4)
								{
									// 数量が4桁以上入力されていますが、よろしいですか？
									InfoMsgCls.AddWarnMsg(
										"W103"
										, string.Empty
										, facadeContext
										, new[] { "M1hyokason_su" }
										, f01m1VO.M1rowno
										, iRow.ToString()
										, "M1"
									);
								}
							}
						}
					}
				}

				if (InfoMsgCls.HasWarn(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック
				StringBuilder sRepSql = new StringBuilder();

				string strTableId = string.Empty;

				// [選択モードNo]が「再申請」の場合
				if (!f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REAPPLY))
				{
					strTableId = "MDIT0060";
				}
				else
				{
					strTableId = "MDIT0070";
				}

				for (int i = 0; i < m1List.Count; i++)
				{
					Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List[i];

					// 行追加の場合、チェックなし
					if (!string.IsNullOrEmpty(f01m1VO.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()))
					{
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗コード
							sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPO_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 管理No
							sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_KANRI_NO";
							bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tk020p01Constant.DIC_KANRI_NO]);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 処理日付
							sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYORI_YMD";
							bindVO.Value = (string)f01m1VO.Dictionary[Tk020p01Constant.DIC_SYORI_YMD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 行No
							sRepSql.Append(" AND GYO_NBR = :BIND_GYO_NBR");
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_GYO_NBR";
							bindVO.Value = (string)f01m1VO.Dictionary[Tk020p01Constant.DIC_GYO_NBR];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal((string)f01m1VO.Dictionary[Tk020p01Constant.DIC_UPD_YMD]),
									Convert.ToDecimal((string)f01m1VO.Dictionary[Tk020p01Constant.DIC_UPD_TM]),
									facadeContext,
									strTableId,
									sRepSql.ToString(),
									bindList,
									1,
									null,
									f01m1VO.M1rowno,
									i.ToString(),
									"M1",
									100
							);

							// ＳＱＬ文初期化
							sRepSql.Length = 0;
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 更新処理

				// 行追加用インデックス
				int iGyoNo = 0;
				// 行追加フラグ
				bool bAddF = false;

				// 行削除が行われた明細の場合
				for (int i = 0; i < m1List.ListRemovedData.Count; i++)
				{
					Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List.ListRemovedData[i];

					// [選択モードNo]が「申請」の場合
					if(f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_APPLY))
					{
						// [評価損申請履歴ＴＢＬ]を作成する。
						int InscntMDIT0050_1 = Ins_MDIT0050(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, 1, 1);
						// [評価損申請ＴＢＬ]を削除する。
						int DelcntMDIT0060_2 = Del_MDIT0060(facadeContext, f01m1VO);
					}
					//[選択モードNo]が「修正」の場合
					else
					{
						//[評価損申請履歴ＴＢＬ]を作成する。
						int InscntMDIT0050_1 = Ins_MDIT0050(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, 1, 1);
						//[評価損申請ＴＢＬ]を削除する。
						int DelcntMDIT0060_2 = Del_MDIT0060(facadeContext, f01m1VO);
					}
				}

				// [Ｍ１選択フラグ(隠し)]が"1"の場合
				for (int i = 0; i < m1List.Count; i++)
				{
					Tk020f01M1Form f01m1VO = (Tk020f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON) && !string.IsNullOrEmpty(f01m1VO.M1scan_cd))
					{
						// [選択モードNo]が「申請」の場合
						if(f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_APPLY))
						{
							// 対象行の[Dictionary.M１管理No]が空白でない場合
							if (!string.IsNullOrEmpty(f01m1VO.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()))
							{
								// [評価損申請履歴ＴＢＬ]を作成する。
								int InscntMDIT0050_1 = Ins_MDIT0050(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, 1, 0);
								// [評価損申請ＴＢＬ]を更新する。
								int UpdcntMDIT0060_2 = Upd_MDIT0060(facadeContext, f01m1VO, logininfo, sysDateVO, f01VO);
								// [評価損申請履歴ＴＢＬ]を作成する。
								int InscntMDIT0050_3 = Ins_MDIT0050(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, 0, 0);
							}
							// 対象行の[Dictionary.M１管理No]が空白の場合
							else
							{
								iGyoNo++;
								bAddF = true;
								// [評価損一時ＴＢＬ]を作成する。
								int InscntMDIT0060tmp_1 = Ins_MDIT0060tmp(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, iGyoNo);
								// 申請ＴＢＬ、履歴は最後に一括で登録する
							}
						}
						// [選択モードNo]が「修正」の場合
						else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
						{
							// 対象行の[Dictionary.M１管理No]が空白でない場合
							if (!string.IsNullOrEmpty(BoSystemString.Nvl(f01m1VO.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString())))
							{
								// [評価損申請履歴ＴＢＬ]を作成する。
								int InscntMDIT0050_1 = Ins_MDIT0050(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, 1, 0);
								// [評価損申請ＴＢＬ]を更新する。
								int UpdcntMDIT0060_2 = Upd_MDIT0060(facadeContext, f01m1VO, logininfo, sysDateVO, f01VO);
								// [評価損申請履歴ＴＢＬ]を作成する。
								int InscntMDIT0050_3 = Ins_MDIT0050(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, 0, 0);
							}
							// 対象行の[Dictionary.M１管理No]が空白の場合
							else
							{
								iGyoNo++;
								bAddF = true;
								// [評価損一時ＴＢＬ]を作成する。
								int InscntMDIT0060tmp_1 = Ins_MDIT0060tmp(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, iGyoNo);
								// 申請ＴＢＬ、履歴は最後に一括で登録する
							}
						}
						// [選択モードNo]が「再申請」の場合
						else
						{
							iGyoNo++;
							bAddF = true;
							// [評価損一時ＴＢＬ]を作成する。
							int InscntMDIT0060tmp_1 = Ins_MDIT0060tmp(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, iGyoNo);
							// 申請ＴＢＬ、履歴は最後に一括で登録す
							
							// [評価損確定ＴＢＬ]を更新する。
							int InscntMDIT0060_4 = Upd_MDIT0070(facadeContext, f01m1VO);
						}
					}
				}

				// 行追加または再申請の場合
				if (bAddF)
				{
					// 申請TBL作成
					int InscntMDIT0060 = Ins_MDIT0060(facadeContext, f01VO, logininfo);
					// 履歴(新規行)作成
					int InscntMDIT0050_AddRow = Ins_MDIT0050_AddRow(facadeContext, f01VO, logininfo, sysDateVO);
				}

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#endregion

				#region 印刷処理
				//[選択モードNo]が「申請」「再申請」の場合
				if(f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_APPLY)
				|| f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REAPPLY))
				{
					string pdfFileNm = "";

					// 帳票ツールに渡すパラメータを格納
					InputData inputData = new InputData();

					// [店舗コード]
					inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
					// [処理]
					inputData.AddScreenParameter(2, (string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "SYORI_YM".ToUpper()]);
					// [モードNO]
					inputData.AddScreenParameter(3, f01VO.Stkmodeno.ToString());
					// [更新日]
					inputData.AddScreenParameter(4, sysDateVO.Sysdate.ToString());
					// [更新時間]
					inputData.AddScreenParameter(5, sysDateVO.Systime_mili.ToString());


					// 帳票を出力
					OutputInfo output = new OutputInfo();
					BoSystemReport reportCls = new BoSystemReport();

					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HYOKASONSINSEISYO),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_HYOKASONSINSEISYO,
													Tk020p01Constant.FORMID_01,
													Tk020p01Constant.PGID,
													pdfFileNm
													);

					// PDFをファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tk020p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
				}
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

		#region ユーザー定義関数

		#region 評価損申請履歴ＴＢＬ＿作成
		/// <summary>
		/// 評価損申請履歴ＴＢＬ＿作成
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_MDIT0050( IFacadeContext facadeContext,
										Tk020f01Form f01Form,
										Tk020f01M1Form f01M1Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO,
										int iAkaKuro,
										int iDelFlg)
		{
			// 履歴NO取得
			int iRirekiNo = GET_KanriNo(facadeContext, f01M1Form);

			// 赤黒判定
			int iDispKb = 0;	// 履歴画面表示区分

			if (iDelFlg == 0)
			{
				if (iAkaKuro == 0)
				{	// 黒伝票
					iDispKb = 1;
				}
				else
				{	// 赤伝票
					iDispKb = 0;
				}
			}
			else
			{	// 行削除
				iAkaKuro = 1;
				iDispKb = 1;
			}

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK020P01-05", facadeContext.DBContext);

			// 履歴No
			// パターンによって可変とする
			// 赤,新規:+1
			// 黒:赤と同一
			if (iAkaKuro == 1)
			{
				reader.BindValue("BIND_RIREKI_NO", iRirekiNo + 1);
			}
			else
			{
				reader.BindValue("BIND_RIREKI_NO", iRirekiNo);
			}

			// 赤黒区分
			reader.BindValue("BIND_AKAKURO_KBN", iAkaKuro);

			// 履歴処理日付
			reader.BindValue("BIND_RIREKI_SYORI_YMD", sysDateVO.Sysdate);

			// 履歴処理時間
			reader.BindValue("BIND_RIREKI_SYORI_TM", sysDateVO.Systime_mili);

			// 評価損数量
			if (iAkaKuro == 1)
			{ 
				// 赤伝票
				if (!f01M1Form.M1hyokason_su.Equals(f01M1Form.Dictionary[Tk020p01Constant.DIC_HYOKASON_SU].ToString()))
				{ 
					reader.BindValue("BIND_HYOKASON_SU", (-1) * int.Parse(f01M1Form.Dictionary[Tk020p01Constant.DIC_HYOKASON_SU].ToString()));
					f01M1Form.Dictionary[Tk020p01Constant.DIC_HYOKASON_SU] = f01M1Form.M1hyokason_su.ToString();
				}
				else
				{
					reader.BindValue("BIND_HYOKASON_SU", (-1) * int.Parse(f01M1Form.M1hyokason_su));
				}
			}
			else
			{
				// 黒伝票
				if (!f01M1Form.M1hyokason_su.Equals(f01M1Form.Dictionary[Tk020p01Constant.DIC_HYOKASON_SU].ToString()))
				{
					reader.BindValue("BIND_HYOKASON_SU", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_HYOKASON_SU].ToString()));
					f01M1Form.Dictionary[Tk020p01Constant.DIC_HYOKASON_SU] = f01M1Form.M1hyokason_su.ToString();
				}
				else
				{
					reader.BindValue("BIND_HYOKASON_SU", Convert.ToDecimal(f01M1Form.M1hyokason_su));
				}
			}

			// 履歴画面表示区分
			reader.BindValue("BIND_RIREKI_DISP_KB", iDispKb);

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);

			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);

			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			#region 検索条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));

			// 再申請モードでない場合
			if (!f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_REAPPLY))
			{
				// 管理№
				// 処理日付
				if (!string.IsNullOrEmpty(f01M1Form.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()))
				{ // 存在する場合
					reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()));
					reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_SYORI_YMD].ToString()));
					// 行№
					reader.BindValue("BIND_GYO_NBR", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_GYO_NBR].ToString()));
				}
				else
				{
					// 別メソッドで実施
				}
			}
			else
			{
				// 別メソッドで実施
			}
			#endregion

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 評価損申請ＴＢＬ＿削除
		/// <summary>
		/// 評価損申請ＴＢＬ＿削除
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Del_MDIT0060(IFacadeContext facadeContext, Tk020f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK020P01-06", facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_TENPO_CD]));

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_SYORI_YMD].ToString()));

			// 行№
			reader.BindValue("BIND_GYO_NBR", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 評価損申請ＴＢＬ＿更新
		/// <summary>
		/// [評価損申請ＴＢＬ]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_MDIT0060(IFacadeContext facadeContext,
										Tk020f01M1Form f01M1Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO,
										Tk020f01Form f01Form)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK020P01-07", facadeContext.DBContext);

			#region 更新部
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f01M1Form.M1bumon_cd.ToString()));

			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(f01M1Form.M1hinsyu_cd));

			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_BURANDO_CD]));

			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f01M1Form.M1maker_hbn.ToString());

			// 商品名(カナ)
			reader.BindValue("BIND_SYONMK", f01M1Form.M1syonmk.ToString());

			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f01M1Form.M1jisya_hbn));

			// ＪＡＮコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f01M1Form.M1scan_cd));

			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", ((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_SYOHIN_CD]));

			// 評価損数量
			reader.BindValue("BIND_HYOKASON_SU", Convert.ToDecimal(f01M1Form.M1hyokason_su));

			// 販売完了日
			reader.BindValue("BIND_HANBAIKANRYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1hanbaikanryo_ymd)));

			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f01M1Form.Dictionary[Tk020p01Constant.DIC_IRO_CD].ToString()));

			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd(f01M1Form.Dictionary[Tk020p01Constant.DIC_SIZE_CD].ToString()));

			// サイズ名
			reader.BindValue("BIND_SIZE_NM", f01M1Form.M1size_nm.ToString());

			// 原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(f01M1Form.M1gen_tnk));

			// 上代1
			reader.BindValue("BIND_JODAI1_TNK", Convert.ToDecimal(f01M1Form.M1genbaika_tnk));

			// 評価損種別区分
			reader.BindValue("BIND_HYOKASONSYUBETSU_KB", Convert.ToDecimal(f01M1Form.M1hyokasonsyubetsu_kb));

			// 評価損理由区分
			reader.BindValue("BIND_HYOKASONRIYU_KB", Convert.ToDecimal(f01M1Form.M1hyokasonriyu_kb));

			// 評価損理由
			reader.BindValue("BIND_HYOKASONRIYU", f01M1Form.M1hyokasonriyu.ToString());

			// 申請状態
			// 修正モードの場合０
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
			{
				reader.BindValue("BIND_SHINSEI_FLG", 0);
			}
			else
			{
				reader.BindValue("BIND_SHINSEI_FLG", 1);
			}

			// 決裁状態
			reader.BindValue("BIND_KESSAI_FLG", 0);

			// 申請日
			// 修正モードの場合０
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
			{
				reader.BindValue("BIND_APPLY_YMD", 0);
			}
			else
			{
				reader.BindValue("BIND_APPLY_YMD", sysDateVO.Sysdate);
			}

			// 調達区分
			reader.BindValue("BIND_TYOTATSU_KB", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_TYOTATSU_KB].ToString()));

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);

			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);

			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 修正モードの場合０
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
			{

				// 削除フラグ
				reader.BindValue("BIND_SAKUJYO_FLG", 0);
			}
			else
			{
				// 削除フラグ
				reader.BindValue("BIND_SAKUJYO_FLG", 1);
			}

			#endregion

			#region 条件部
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_TENPO_CD]));

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_SYORI_YMD].ToString()));

			// 行№
			reader.BindValue("BIND_GYO_NBR", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_GYO_NBR].ToString()));
			#endregion

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 評価損一時ＴＢＬ＿作成
		/// <summary>
		/// 評価損一時ＴＢＬ＿作成
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_MDIT0060tmp(IFacadeContext facadeContext,
										Tk020f01Form f01Form,
										Tk020f01M1Form f01M1Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO,
										int iRow )
		{
			// テーブル初期化は最初に実施する
			//int IniCnt = Ini_MDIT0060tmp(facadeContext);

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK020P01-08", facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));

			// 管理№("0"で登録、申請TBLには採番した値)
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString(), (0).ToString())));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);

			// 処理時間
			reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);

			// 行№(iRowはインデックス値)
			reader.BindValue("BIND_GYO_NBR", iRow);
			// Dictionary設定
			f01M1Form.Dictionary.Add(Tk020p01Constant.DIC_GYONBR_SAI, (iRow).ToString());

			// 行№(iRowはインデックス値)
			//reader.BindValue("BIND_GYO_NBR", (iRow + 1).ToString());
			// Dictionary設定
			//f01M1Form.Dictionary.Add(Tk020p01Constant.DIC_GYONBR_SAI, (iRow + 1).ToString());

			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f01M1Form.M1bumon_cd.ToString()));

			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(f01M1Form.M1hinsyu_cd));

			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_BURANDO_CD]));

			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f01M1Form.M1maker_hbn.ToString());

			// 商品名(カナ)
			reader.BindValue("BIND_SYONMK", f01M1Form.M1syonmk.ToString());

			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f01M1Form.M1jisya_hbn));

			// ＪＡＮコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f01M1Form.M1scan_cd));

			// 商品コード
			reader.BindValue("BIND_SYOHIN_CD", f01M1Form.Dictionary[Tk020p01Constant.DIC_SYOHIN_CD].ToString());

			// 評価損数量
			reader.BindValue("BIND_HYOKASON_SU", Convert.ToDecimal(f01M1Form.M1hyokason_su));

			// 販売完了日
			reader.BindValue("BIND_HANBAIKANRYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1hanbaikanryo_ymd)));

			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_IRO_CD]));

			// サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_SIZE_CD]));

			// サイズ名
			reader.BindValue("BIND_SIZE_NM", f01M1Form.M1size_nm.ToString());

			// 原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(f01M1Form.M1gen_tnk));

			// 上代1
			reader.BindValue("BIND_JODAI1_TNK", Convert.ToDecimal(f01M1Form.M1genbaika_tnk));

			// 評価損種別区分
			reader.BindValue("BIND_HYOKASONSYUBETSU_KB", Convert.ToDecimal(f01M1Form.M1hyokasonsyubetsu_kb));

			// 評価損理由区分
			reader.BindValue("BIND_HYOKASONRIYU_KB", Convert.ToDecimal(f01M1Form.M1hyokasonriyu_kb));

			// 評価損理由
			reader.BindValue("BIND_HYOKASONRIYU", f01M1Form.M1hyokasonriyu.ToString());

			// 申請状態
			// [選択モードNo]が「修正」の場合
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
			{
				reader.BindValue("BIND_SHINSEI_FLG", 0);
			}
			else
			{
				reader.BindValue("BIND_SHINSEI_FLG", 1);
			}

			// 決裁状態
			reader.BindValue("BIND_KESSAI_FLG", 0);

			// 再申請フラグ
			// [選択モードNo]が「再申請」の場合、1(固定値)
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_REAPPLY))
			{
				reader.BindValue("BIND_SAISHINSEI_FLG", 1);
			}
			else
			{
				reader.BindValue("BIND_SAISHINSEI_FLG", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_SAISHINSEI_FLG].ToString()));
			}

			// 申請日
			// [選択モードNo]が「修正」の場合、0(固定値)
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
			{
				reader.BindValue("BIND_APPLY_YMD", 0);
			}
			else
			{
				reader.BindValue("BIND_APPLY_YMD", sysDateVO.Sysdate);
			}

			// 調達区分
			reader.BindValue("BIND_TYOTATSU_KB", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_TYOTATSU_KB].ToString()));

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);

			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);

			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 削除フラグ
			// [選択モードNo]が「再申請」の場合、1(固定値)
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_REAPPLY))
			{
				reader.BindValue("BIND_SAKUJYO_FLG", 1);
			}
			else
			{
				reader.BindValue("BIND_SAKUJYO_FLG", 0);
			}

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 評価損申請ＴＢＬ＿作成
		/// <summary>
		/// 評価損申請ＴＢＬ＿作成
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_MDIT0060(IFacadeContext facadeContext, Tk020f01Form f01Form, LoginInfoVO loginInfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK020P01-09", facadeContext.DBContext);

			// 採番を行う
			string num = NumberingCls.Numbering(facadeContext,
											BoSystemConstant.AUTONUM_HYOKASON_KANRINO,
//											f01Form.Head_tenpo_cd,
											"0000",
											loginInfo.LoginId);

			decimal dKanrino = Convert.ToDecimal(num);

			// 管理№
			reader.BindValue("BIND_KANRI_NO", dKanrino);

			// Dictionary設定
			f01Form.Dictionary[Tk020p01Constant.DIC_NUMBERING] = dKanrino;

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 評価損確定ＴＢＬ＿更新
		/// <summary>
		/// 評価損確定ＴＢＬ＿更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		private int Upd_MDIT0070(	IFacadeContext facadeContext, Tk020f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK020P01-10", facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_TENPO_CD]));

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_SYORI_YMD].ToString()));

			// 行№
			reader.BindValue("BIND_GYO_NBR", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_GYO_NBR].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 評価損申請履歴TBL(履歴NO)＿取得
		/// <summary>
		/// 評価損申請履歴TBL(履歴NO)＿取得
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int GET_KanriNo(IFacadeContext facadeContext, Tk020f01M1Form f01M1Form)
		{
			string KanriNo = string.Empty;

			// XMLからSQLを取得する。
			FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable("TK020P01-11", facadeContext.DBContext);

			// 管理№が存在する場合
			if (!string.IsNullOrEmpty(f01M1Form.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()))
			{ 
				// 店舗コード
				rtSeach.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Tk020p01Constant.DIC_TENPO_CD]));

				// 管理№
				rtSeach.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_KANRI_NO].ToString()));

				// 処理日付
				rtSeach.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_SYORI_YMD].ToString()));

				// 行№
				rtSeach.BindValue("BIND_GYO_NBR", Convert.ToDecimal(f01M1Form.Dictionary[Tk020p01Constant.DIC_GYO_NBR].ToString()));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				// 検索件数が0件の場合
				if (tableList.Count == 0)
				{
					KanriNo = (0).ToString();
				}

				foreach (Hashtable rec in tableList)
				{
					KanriNo = rec["RIREKI_NO"].ToString();
				}
			}
			else
			{
				// 行追加の場合
				KanriNo = (0).ToString();
			}

			return int.Parse(KanriNo.ToString());
		}
		#endregion

		#region 評価損一時ＴＢＬ＿初期化
		/// <summary>
		/// 評価損一時ＴＢＬ＿作成
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>更新件数</returns>
		private int Ini_MDIT0060tmp(IFacadeContext facadeContext)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable readerWk = FindSqlUtil.CreateFindSqlResultTable("TK020P01-12", facadeContext.DBContext);

			//クエリを実行する。
			using (IDbCommand cmd = readerWk.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 評価損申請履歴ＴＢＬ（新規行）＿作成
		/// <summary>
		/// 評価損申請履歴（新規行）ＴＢＬ＿作成
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_MDIT0050_AddRow(IFacadeContext facadeContext,
										Tk020f01Form f01Form,
										LoginInfoVO loginInfo,
										SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK020P01-13", facadeContext.DBContext);

			// 履歴処理日付
			reader.BindValue("BIND_RIREKI_SYORI_YMD", sysDateVO.Sysdate);

			// 履歴処理時間
			reader.BindValue("BIND_RIREKI_SYORI_TM", sysDateVO.Systime_mili);

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);

			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);

			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));

			// 管理No
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01Form.Dictionary[Tk020p01Constant.DIC_NUMBERING].ToString()));
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#endregion
	}
}
