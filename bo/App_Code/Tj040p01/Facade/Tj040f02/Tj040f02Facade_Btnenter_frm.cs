using com.xebio.bo.Tj040p01.Constant;
using com.xebio.bo.Tj040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01017;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Entitys;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tj040p01.Facade
{
  /// <summary>
  /// Tj040f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj040f02Facade : StandardBaseFacade
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

                // ログイン情報取得
                LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

                // FormVO取得
                // 画面より情報を取得する。
                Tj040f02Form formVO = (Tj040f02Form)facadeContext.FormVO;
                IDataList m1List = formVO.GetList("M1");

                // 一覧画面選択行のVO
                Tj040f01M1Form f01M1Form = (Tj040f01M1Form)formVO.Dictionary[Tj040p01Constant.DIC_M1SELCETVO];

				decimal dSumTeiseiSu = 0;	// 訂正数量
				decimal dSumGoukeiSu = 0;	// 合計数量

				// 警告メッセージの応答結果を取得
				string waningflg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0");

				#region 業務チェック

				if (!"1".Equals(waningflg))
				{

					#region 1. 選択チェック

					//// 1-1 選択状態
					////       1件も選択されていない場合、エラー 
					//if (m1List == null || m1List.Count <= 0)
					//{
					//	// 確定対象がありません。
					//	ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					//}
					//else
					//{
					//	int inputflg = 0;
					//	for (int i = 0; i < m1List.Count; i++)
					//	{
					//		Tj040f02M1Form m1formVO = (Tj040f02M1Form)m1List[i];
					//		if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					//		{
					//			inputflg = 1;
					//			break;
					//		}
					//	}
					//	if (inputflg == 0)
					//	{
					//		// 確定対象がありません。
					//		ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					//	}
					//}

					////エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					//if (MessageDisplayUtil.HasError(facadeContext))
					//{
					//	return;
					//}

					#endregion

					#region 2. マスタ存在チェック

					// 2-1 フェイスＮｏ、棚段
					//       棚卸確定ＴＢＬを検索し、存在していた場合、警告メッセージを表示する。 
					if (Chk_FaceTanada(facadeContext, formVO))
					{
						InfoMsgCls.AddWarnMsg("W100", string.Empty, facadeContext);
					}

					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}

					#endregion

				}

                #region 3. 入力値チェック

                // 3-1 棚段
                //       1～16の範囲内でない場合、エラー
                if (!string.IsNullOrEmpty(formVO.Tana_dan))
                {
                    if (int.Parse(formVO.Tana_dan) < 1 ||
                        int.Parse(formVO.Tana_dan) > 16)
                    {
                        // 棚段は1以上16以下で入力して下さい。
                        ErrMsgCls.AddErrMsg("E173", string.Empty, facadeContext);
                    }
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #region 4. マスタ存在チェック（明細）

                for (int i = 0; i < m1List.Count; i++)
                {
                    Tj040f02M1Form m1formVO = (Tj040f02M1Form)m1List[i];

                    #region Ｍ１スキャンコード

                    // 4-1 Ｍ１スキャンコード
                    //       発注MSTに存在しない場合、エラー
                    if (!string.IsNullOrEmpty(m1formVO.M1scan_cd.Trim()))
                    {
                        SearchHachuVO searchConditionVO = new SearchHachuVO(
                            m1formVO.M1scan_cd,		// スキャンコード
                            formVO.Head_tenpo_cd,	// 店舗コード
                            0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
                            0,						// 売変 検索フラグ 0:検索しない 1:検索する
                            0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
                            0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
                            0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
                            0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
                            0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
                            0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
                            string.Empty,			// 指示NO（移動出荷マニュアル、返品マニュアル用）
                            string.Empty,			// 出荷会社コード（移動出荷マニュアル)
                            string.Empty,			// 入荷会社コード（移動出荷マニュアル)
                            string.Empty			// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
                        );

                        Hashtable syohinData = V01004Check.CheckScanCd(
                                                            searchConditionVO,
                                                            facadeContext,
                                                            "スキャンコード",
                                                            new[] { "M1scan_cd" },
                                                            m1formVO.M1rowno,
                                                            i.ToString(),
                                                            "M1",
                                                            Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper()))
                                                    );
                        if (syohinData != null)
                        {
                            // 発注マスタ検索値をフォームビーン再設定

                            // 部門コード
                            m1formVO.M1bumon_cd = (string)syohinData["BUMON_CD"];
                            // 部門名
                            m1formVO.M1bumonkana_nm = (string)syohinData["BUMON_NM"];
                            // 品種名
                            m1formVO.M1hinsyu_ryaku_nm = (string)syohinData["HINSYU_RYAKU_NM"];
                            // ブランド名
                            m1formVO.M1burando_nm = (string)syohinData["BURANDO_NMK"];
                            // 自社品番
                            m1formVO.M1jisya_hbn = (string)syohinData["XEBIO_CD"];
                            // メーカー品番
                            m1formVO.M1maker_hbn = (string)syohinData["HIN_NBR"];
                            // 商品名
                            m1formVO.M1syonmk = (string)syohinData["SYONMK"];
                            // 色
                            m1formVO.M1iro_nm = (string)syohinData["IRO_NM"];
                            // サイズ
                            m1formVO.M1size_nm = (string)syohinData["SIZE_NM"];
                            // 商品コード
                            m1formVO.M1hyoji_syohin_cd = BoSystemFormat.formatViewSyohinCd((string)syohinData["SYOHIN_CD"]);


                            // ブランドコード
                            m1formVO.Dictionary[Tj040p01Constant.DIC_M1BURANDO_CD] = (string)syohinData["BURANDO_CD"];
                            // 品種コード
                            m1formVO.Dictionary[Tj040p01Constant.DIC_M1HINSYU_CD] = ((decimal)syohinData["HINSYU_CD"]).ToString();
                            // 色コード
                            m1formVO.Dictionary[Tj040p01Constant.DIC_M1IRO_CD] = (string)syohinData["MAKERCOLOR_CD"];
                            // サイズコード
                            m1formVO.Dictionary[Tj040p01Constant.DIC_M1SIZE_CD] = (string)syohinData["SIZE_CD"];
							// 登録用商品コード
							m1formVO.Dictionary[Tj040p01Constant.DIC_M1SYOHIN_CD] = (string)syohinData["SYOHIN_CD"].ToString();


							dSumTeiseiSu += Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1teisei_suryo, "0"));		// 訂正数量
							dSumGoukeiSu += Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1gokei_suryo,  "0"));		// 合計数量
                        }
                    }
					else
					{
						// 未入力エラー
						ErrMsgCls.AddErrMsg("E118",
											new[] { "スキャンコード" },
											facadeContext,
											new[] { "M1scan_cd" },
											m1formVO.M1rowno,
											i.ToString(),
											"M1");
					}

                    #endregion

					#region Ｍ１訂正数量

					if (string.IsNullOrEmpty(m1formVO.M1teisei_suryo))
					{
						// 未入力エラー
						ErrMsgCls.AddErrMsg("E118",
											new[] { "訂正数量" },
											facadeContext,
											new[] { "M1teisei_suryo" },
											m1formVO.M1rowno,
											i.ToString(),
											"M1");
					}

					#endregion

					#region Ｍ１訂正数量

					if (!string.IsNullOrEmpty(m1formVO.M1gokei_suryo))
					{
						if (int.Parse(m1formVO.M1gokei_suryo) > 9999)
						{
							// 桁数エラー
							ErrMsgCls.AddErrMsg("E108",
												new[] { "合計数量", "4" },
												facadeContext,
												new[] { "M1teisei_suryo" },
												m1formVO.M1rowno,
												i.ToString(),
												"M1");
						}
					}

					#endregion
				}

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }

                #endregion

                #region 5. 排他チェック

                // 5-1 更新日時
                //       検索時に取得した更新日、更新時間とDB上の更新日、更新時間を比較し異なる場合、エラー

                StringBuilder sRepSql = new StringBuilder();

                ArrayList bindList = new ArrayList();
                BindInfoVO bindVO = new BindInfoVO();

                sRepSql.Append(" AND TENPO_CD      = :BIND_TENPO_CD");
                sRepSql.Append(" AND FACE_NO       = :BIND_FACE_NO");
                sRepSql.Append(" AND TANA_DAN      = :BIND_TANA_DAN");
                sRepSql.Append(" AND KAI_SU        = :BIND_KAI_SU");
                sRepSql.Append(" AND TANAOROSI_YMD = :BIND_TANAOROSI_YMD");
                sRepSql.Append(" AND SOSINKAI_SU   = :BIND_SOSINKAI_SU");

                // 店舗コード
                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_TENPO_CD";
                bindVO.Value  = BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd);
                bindVO.Type   = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // フェイス№
                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_FACE_NO";
                bindVO.Value  = (string)formVO.Dictionary[Tj040p01Constant.DIC_FACE_NO];
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // 棚段
                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_TANA_DAN";
                bindVO.Value  = (string)formVO.Dictionary[Tj040p01Constant.DIC_TANA_DAN];
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // 回数
                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_KAI_SU";
                bindVO.Value  = formVO.Kai_su;
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // 棚卸日
                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_TANAOROSI_YMD";
                bindVO.Value  = (string)formVO.Dictionary[Tj040p01Constant.DIC_TANAOROSI_YMD];
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                // 送信回数
                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_SOSINKAI_SU";
                bindVO.Value  = (string)formVO.Dictionary[Tj040p01Constant.DIC_SOSINKAI_SU];
                bindVO.Type   = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList.Add(bindVO);


                // 排他チェック
				V03003Check.CheckHaitaMaxVal(
						Convert.ToDecimal((string)formVO.Dictionary[Tj040p01Constant.DIC_M1UPD_YMD]),
						Convert.ToDecimal((string)formVO.Dictionary[Tj040p01Constant.DIC_M1UPD_TM]),
                        facadeContext,
                        "MDIT0010",
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

                #endregion

                #region 更新処理

                // システム日付取得
                SysDateVO sysDateVO = new SysDateVO();
                sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

                #region 棚卸基準日の取得

                string strTanaorosikijun_ymd = string.Empty;

                // 棚卸実施日TBLの検索
                Hashtable hsMdit0030 = new Hashtable();
                hsMdit0030 = SearchInventory.SearchMdit0030(BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd),
                                                            sysDateVO.Sysdate.ToString(),
                                                            facadeContext,
                                                            0);
                // 棚卸基準日の設定
                if (hsMdit0030 != null)
                {
                    strTanaorosikijun_ymd = Convert.ToString(hsMdit0030["TANAOROSIKIJUN_YMD"]);
                }

                #endregion

                #region 訂正有無の取得

                string strTeiseiflg = "0";

                for (int i = 0; i < m1List.Count; i++)
                {
                    Tj040f02M1Form m1formVO = (Tj040f02M1Form)m1List[i];

                    if (!string.IsNullOrEmpty(m1formVO.M1teisei_suryo) &&
                        !"0".Equals(m1formVO.M1teisei_suryo))
                    {
                        strTeiseiflg = "1";
                        break;
                    }
                }

                #endregion

				#region 回数の取得

				string strKaisu = Get_Kaisu(facadeContext, formVO);

				#endregion

                // [棚卸確定TBL(H)]]を更新する。
				BoSystemLog.logOut("[棚卸確定TBL(H)]]を更新 START");
				int UpdMdit0010cnt = Upd_Mdit0010(facadeContext, formVO, logininfo, strTeiseiflg, strKaisu, dSumTeiseiSu, dSumGoukeiSu, sysDateVO);
				BoSystemLog.logOut("[棚卸確定TBL(H)]]を更新 END");

                // [棚卸確定TBL(B)]を削除する。
				BoSystemLog.logOut("[棚卸確定TBL(B)]を削除 START");
                int DelMdit0011cnt = Del_Mdit0011(facadeContext, formVO, logininfo);
				BoSystemLog.logOut("[棚卸確定TBL(B)]を削除 END");

                // [棚卸確定TBL(B)]を登録する。
				BoSystemLog.logOut("[棚卸確定TBL(B)]を登録 START");
				int IntMdit0011cnt = Ins_Mdit0011(facadeContext, formVO, strKaisu, logininfo);
				BoSystemLog.logOut("[棚卸確定TBL(B)]を登録 END");

                // [棚卸欠番TBL]を削除する。
				BoSystemLog.logOut("[棚卸欠番TBL]を削除 START");
                int DelMdit0040cnt = Del_Mdit0040(facadeContext, formVO, logininfo, strTanaorosikijun_ymd);
				BoSystemLog.logOut("[棚卸欠番TBL]を削除 END");

                #endregion

				#region 画面表示

				// ヘッダ情報を更新する。
				f01M1Form.M1kai_su = strKaisu;                                      // 回数

				f01M1Form.M1tensutanaorositeisei_su = formVO.Teisei_suryo;			// 点数棚卸訂正数
				f01M1Form.M1tensutanaorosigokei_su  = formVO.Gokei_suryo;			// 点数棚卸合計数
				f01M1Form.M1teisei_suryo  = dSumTeiseiSu.ToString();		        // 訂正数量
				f01M1Form.M1gokei_suryo   = dSumGoukeiSu.ToString();	            // 合計数量

				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;	// 確定処理フラグ

				// 更新日
				f01M1Form.Dictionary[Tj040p01Constant.DIC_M1UPD_YMD] = sysDateVO.Sysdate.ToString();
				// 更新時間
				f01M1Form.Dictionary[Tj040p01Constant.DIC_M1UPD_TM] = sysDateVO.Systime_mili.ToString();

				// Ｍ１フェイスＮｏ
				f01M1Form.Dictionary[Tj040p01Constant.DIC_M1FACE_NO] = formVO.Face_no;
				// Ｍ１棚段
				f01M1Form.M1tana_dan = formVO.Tana_dan;

				// Ｍ１訂正担当者
				f01M1Form.Dictionary[Tj040p01Constant.DIC_M1TEISEITAN_CD] = BoSystemFormat.formatTantoCd(logininfo.TtsCd);
				f01M1Form.M1teiseitan_nm = logininfo.TtsMei;

				// Ｍ１棚卸履理由
				Mdmt0180DA mdmt0180DA = new Mdmt0180DA();
				Mdmt0180Key mdmt0180Key = new Mdmt0180Key("017", Convert.ToDecimal(formVO.Riyu_cd));

				mdmt0180DA.Context = facadeContext.DBContext;
				Mdmt0180VO mdmt0180VO = mdmt0180DA.FindByPrimaryKey(mdmt0180Key);
				//マスタからレコード取得
				if (mdmt0180VO != null)
				{
					f01M1Form.M1riyucomment_nm = mdmt0180VO.Riyucomment_nm;
				}
				else
				{
					f01M1Form.M1riyucomment_nm = string.Empty;
				}

				#endregion

				//トランザクションをコミットする。
                CommitTransaction(facadeContext);
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

		#region フェイスＮｏ、棚段の存在チェック
		/// <summary>
		/// フェイスＮｏ、棚段の存在チェックの存在チェックを行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="formVO">明細画面VO</param>
		/// <returns>TRUE or FALSE</returns>
		private bool Chk_FaceTanada(IFacadeContext facadeContext, Tj040f02Form formVO)
		{
			bool ret = false;

			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 検索条件設定
			// 店舗コードのバインド
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
			// フェイス№のバインド
			reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no, "0")));
			// 棚段のバインド
			reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan, "0")));
			// 棚卸日のバインド
			reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANAOROSI_YMD], "0")));

			// 変更前以外
			// 店舗コードのバインド
			reader.BindValue("BIND_MOTO_TENPO_CD", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
			// フェイス№のバインド
			reader.BindValue("BIND_MOTO_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_FACE_NO], "0")));
			// 棚段のバインド
			reader.BindValue("BIND_MOTO_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANA_DAN], "0")));
			// 回数のバインド
			reader.BindValue("BIND_MOTO_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(formVO.Kai_su, "0")));
			// 棚卸日のバインド
			reader.BindValue("BIND_MOTO_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANAOROSI_YMD], "0")));
			// 送信回数のバインド
			reader.BindValue("BIND_MOTO_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_SOSINKAI_SU], "0")));

			#region SQL実行

			//検索結果を取得します
			reader.CreateDbCommand();
			IList<Hashtable> tableListcnt = reader.Execute();

			if (logger.IsDebugEnabled)
			{
				BoSystemLog.logOut("SQL: " + reader.LogSql);
			}

			if (tableListcnt == null || tableListcnt.Count <= 0)
			{
			}
			else
			{
				Hashtable resultTbl = tableListcnt[0];
				Decimal dCnt = (Decimal)resultTbl["CNT"];

				// 0件チェック
				if (dCnt > 0)
				{
					ret = true;
				}
			}

			#endregion

			return ret;
		}
		#endregion

		#region 回数の取得
		/// <summary>
		/// 回数を取得する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="formVO">明細画面VO</param>
		/// <returns>訂正フラグ</returns>
		private string Get_Kaisu(IFacadeContext facadeContext, Tj040f02Form formVO)
		{
			string retKaisu = "0";

			// フェイスNo,棚段に変更ない場合、画面の回数とする
			if (formVO.Face_no.Equals((String)formVO.Dictionary[Tj040p01Constant.DIC_FACE_NO]) &&
				formVO.Tana_dan.Equals((String)formVO.Dictionary[Tj040p01Constant.DIC_TANA_DAN]))
			{
				// 画面の回数
				retKaisu = formVO.Kai_su;
			}
			else
			{
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_10, facadeContext.DBContext);

				// 検索条件設定
				// 店舗コードのバインド
				reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
				// フェイス№のバインド
				reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no, "0")));
				// 棚段のバインド
				reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan, "0")));
				// 棚卸日のバインド
				reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANAOROSI_YMD], "0")));
				// 送信回数のバインド
				reader.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_SOSINKAI_SU], "0")));

				#region SQL実行

				//検索結果を取得します
				reader.CreateDbCommand();
				IList<Hashtable> tableListcnt = reader.Execute();

				if (logger.IsDebugEnabled)
				{
					BoSystemLog.logOut("SQL: " + reader.LogSql);
				}

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// 画面の回数
					retKaisu = formVO.Kai_su;
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];

					if (String.IsNullOrEmpty(resultTbl["KAI_SU"].ToString()))
					{
						// 画面の回数
						retKaisu = formVO.Kai_su;
					}
					else
					{
						retKaisu = Convert.ToString((Decimal)resultTbl["KAI_SU"] + 1);
					}
				}

				#endregion
			}

			return retKaisu;
		}
		#endregion

        #region [棚卸確定TBL(H)]を更新する。
        /// <summary>
        /// [棚卸確定TBL(H)]を更新する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">明細画面VO</param>
        /// <param name="loginInfo">ログイン情報</param>
        /// <param name="prmTeiseiflg">訂正有無</param>
		/// <param name="prmKaisu">回数</param>
		/// <param name="sysDateVO">システム日付</param>
        /// <returns>更新件数</returns>
		private int Upd_Mdit0010(IFacadeContext facadeContext, Tj040f02Form formVO, LoginInfoVO loginInfo, String prmTeiseiflg, String prmKaisu, Decimal dSumTeiseiSu, Decimal dSumGoukeiSu, SysDateVO sysDateVO)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_09, facadeContext.DBContext);

            // フェイス№
            reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no, "0")));
            // 棚段
            reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan, "0")));
			// 回数
			reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(prmKaisu, "0")));
            // 点数棚卸訂正数
            reader.BindValue("BIND_TENSUTANATEISEI_SU", Convert.ToDecimal(BoSystemString.Nvl(formVO.Teisei_suryo, "0")));
            // 点数棚卸合計数
			reader.BindValue("BIND_TENSUTANAGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl(formVO.Gokei_suryo, "0")));
            // 棚卸訂正数量
			reader.BindValue("BIND_TANATEISEI_SU", dSumTeiseiSu);
            // 棚卸合計数量
			reader.BindValue("BIND_TANAGOKEI_SU", dSumGoukeiSu);

            // 差異フラグ
            if (Convert.ToDecimal(formVO.Gokei_suryo) != Convert.ToDecimal(formVO.All_gokei_suryo))
            {
                reader.BindValue("BIND_SAI_FLG", 1);
            }
            else
            {
                reader.BindValue("BIND_SAI_FLG", 0);
            }

            // 訂正フラグ
			reader.BindValue("BIND_TEISEI_FLG", Convert.ToDecimal(BoSystemString.Nvl(prmTeiseiflg, "0")));

            // 更新日
            reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
            // 更新時間
            reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
            // 更新担当者コード
            reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
            // 削除日
            reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

            // 元フェイス№
			reader.BindValue("BIND_MOTO_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_FACE_NO], "0")));
            // 元棚段
			reader.BindValue("BIND_MOTO_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANA_DAN], "0")));
            // 元回数
            reader.BindValue("BIND_MOTO_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(formVO.Kai_su, "0")));
            // 棚卸理由コード
            reader.BindValue("BIND_TANAOROSIRIYU_CD", Convert.ToDecimal(BoSystemString.Nvl(formVO.Riyu_cd, "0")));


            // WHERE句
            // 店舗コードのバインド
            reader.BindValue("BIND_WHERE_TENPO_CD", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
            // フェイス№のバインド
			reader.BindValue("BIND_WHERE_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_FACE_NO], "0")));
            // 棚段のバインド
			reader.BindValue("BIND_WHERE_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANA_DAN], "0")));
            // 回数のバインド
            reader.BindValue("BIND_WHERE_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(formVO.Kai_su, "0")));
            // 棚卸日のバインド
			reader.BindValue("BIND_WHERE_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANAOROSI_YMD], "0")));
            // 送信回数のバインド
			reader.BindValue("BIND_WHERE_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_SOSINKAI_SU], "0")));


            //クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region [棚卸確定TBL(B)]を削除する。
        /// <summary>
        /// [棚卸確定TBL(B)]を削除する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">明細画面VO</param>
        /// <param name="loginInfo">ログイン情報</param>
        /// <returns>更新件数</returns>
        private int Del_Mdit0011(IFacadeContext facadeContext, Tj040f02Form formVO, LoginInfoVO loginInfo)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_07, facadeContext.DBContext);

            // 店舗コードのバインド
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
            // フェイス№のバインド
			reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_FACE_NO], "0")));
            // 棚段のバインド
			reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANA_DAN], "0")));
            // 回数のバインド
            reader.BindValue("BIND_KAI_SU", Convert.ToDecimal(BoSystemString.Nvl(formVO.Kai_su, "0")));
            // 棚卸日のバインド
			reader.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANAOROSI_YMD], "0")));
            // 送信回数のバインド
			reader.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_SOSINKAI_SU], "0")));

            //クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region [棚卸確定TBL(B)]を登録する。
        /// <summary>
        /// [棚卸確定TBL(B)]を登録する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">明細画面VO</param>
		/// <param name="prmKaisu">回数</param>
		/// <param name="loginInfo">ログイン情報</param>
        /// <returns>更新件数</returns>
		private int Ins_Mdit0011(IFacadeContext facadeContext, Tj040f02Form formVO, String prmKaisu, LoginInfoVO loginInfo)
        {
            int iRownum = 0;
            IDataList m1List = formVO.GetList("M1");

            // Oracleコマンドの生成
            OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
            // トランザクションの設定
            command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
            // SQLの実行タイプ
            command.CommandType = CommandType.Text;


            IList<Mdit0011VO> insertBodyList = new List<Mdit0011VO>();	// 更新データリスト

            // パラメータバインド処理
            IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();

            int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）

            for (int i = 0; i < m1List.Count; i++)
            {
                Tj040f02M1Form m1formVO = (Tj040f02M1Form)m1List[i];

                // スキャンコードが入力されている行が対象
                if (!string.IsNullOrEmpty(m1formVO.M1scan_cd.Trim()))
                {
                    counter++;
                    iRownum++;

                    Dictionary<string, string> bindDic = new Dictionary<string, string>();

                    // 店舗コード
                    BoSystemDb.setInsertVal("TENPO_CD", iRownum.ToString(), BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd), ref bindDic, ref command);
                    // フェイス№
                    BoSystemDb.setInsertVal("FACE_NO", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no, "0")), ref bindDic, ref command);
                    // 棚段
                    BoSystemDb.setInsertVal("TANA_DAN", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan, "0")), ref bindDic, ref command);
					// 回数
					BoSystemDb.setInsertVal("KAI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(prmKaisu, "0")), ref bindDic, ref command);
                    // 棚卸日
					BoSystemDb.setInsertVal("TANAOROSI_YMD", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_TANAOROSI_YMD], "0")), ref bindDic, ref command);
                    // 送信回数
					BoSystemDb.setInsertVal("SOSINKAI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl((string)formVO.Dictionary[Tj040p01Constant.DIC_SOSINKAI_SU], "0")), ref bindDic, ref command);
                    // 行№
                    BoSystemDb.setInsertVal("GYO_NBR", iRownum.ToString(), iRownum, ref bindDic, ref command);

                    // 部門コード
                    BoSystemDb.setInsertVal("BUMON_CD", iRownum.ToString(), m1formVO.M1bumon_cd, ref bindDic, ref command);
                    // 品種コード
                    BoSystemDb.setInsertVal("HINSYU_CD", iRownum.ToString(), Convert.ToDecimal(m1formVO.Dictionary[Tj040p01Constant.DIC_M1HINSYU_CD]), ref bindDic, ref command);
                    // ブランドコード
                    BoSystemDb.setInsertVal("BURANDO_CD", iRownum.ToString(), BoSystemFormat.formatBrandCd((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1BURANDO_CD]), ref bindDic, ref command);
                    // メーカー品番
                    BoSystemDb.setInsertVal("MAKER_HBN", iRownum.ToString(), m1formVO.M1maker_hbn, ref bindDic, ref command);
                    // 商品名(カナ)
                    BoSystemDb.setInsertVal("SYONMK", iRownum.ToString(), m1formVO.M1syonmk, ref bindDic, ref command);
                    // 自社品番
                    BoSystemDb.setInsertVal("JISYA_HBN", iRownum.ToString(), BoSystemFormat.formatJisyaHbn(m1formVO.M1jisya_hbn), ref bindDic, ref command);
                    // ＪＡＮコード
                    BoSystemDb.setInsertVal("JAN_CD", iRownum.ToString(), BoSystemFormat.formatJanCd(m1formVO.M1scan_cd), ref bindDic, ref command);
                    // 商品コード
					BoSystemDb.setInsertVal("SYOHIN_CD", iRownum.ToString(), m1formVO.Dictionary[Tj040p01Constant.DIC_M1SYOHIN_CD].ToString(), ref bindDic, ref command);
                    // 棚卸スキャン数
                    BoSystemDb.setInsertVal("TANAOROSISCAN_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1scan_su, "0")), ref bindDic, ref command);
                    // 棚卸訂正数
                    BoSystemDb.setInsertVal("TANAOROSITEISEI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1teisei_suryo, "0")), ref bindDic, ref command);
                    // 棚卸合計数
                    BoSystemDb.setInsertVal("TANAOROSIGOKEI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(m1formVO.M1gokei_suryo, "0")), ref bindDic, ref command);
                    // 色コード
                    BoSystemDb.setInsertVal("IRO_CD", iRownum.ToString(), BoSystemFormat.formatIroCd((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1IRO_CD]), ref bindDic, ref command);
                    // サイズコード
                    BoSystemDb.setInsertVal("SIZE_CD", iRownum.ToString(), BoSystemFormat.formatSizeCd((string)m1formVO.Dictionary[Tj040p01Constant.DIC_M1SIZE_CD]), ref bindDic, ref command);
                    // サイズ名
                    BoSystemDb.setInsertVal("SIZE_NM", iRownum.ToString(), m1formVO.M1size_nm, ref bindDic, ref command);

                    insertBindList.Add(bindDic);

                    // 一括処理単位に達した場合は、マルチインサートを実行
                    if (counter == 20)
                    {
                        // カウンタのリセット
                        counter = 0;

                        // マルチインサートの実行
                        command.CommandText = GetSqlMultiInsT_HenpinYoteib(insertBindList);
                        //OutPutLog(command.CommandText);
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
                command.CommandText = GetSqlMultiInsT_HenpinYoteib(insertBindList);
                command.ExecuteNonQuery();
            }

            return iRownum;
        }
        #endregion

        #region [棚卸確定TBL(B)]へのマルチインサート文作成。
        /// <summary>
        /// 棚卸確定Bへのマルチインサートを行うSQL文を取得する。
        /// </summary>
        /// <param name="insertBindList">バインドテキスト</param>
        private string GetSqlMultiInsT_HenpinYoteib(IList<Dictionary<string, string>> insertBindList)
        {
            IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

            // バインドテキストのデータ分INSERT文を作成
            foreach (Dictionary<string, string> bindDic in insertBindList)
            {
                StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文
                insertSql.Append("    INTO MDIT0011 VALUES ( ");
                insertSql.Append(bindDic["TENPO_CD"]).Append(" , ");
                insertSql.Append(bindDic["FACE_NO"]).Append(" , ");
                insertSql.Append(bindDic["TANA_DAN"]).Append(" , ");
                insertSql.Append(bindDic["KAI_SU"]).Append(" , ");
                insertSql.Append(bindDic["TANAOROSI_YMD"]).Append(" , ");
                insertSql.Append(bindDic["SOSINKAI_SU"]).Append(" , ");
                insertSql.Append(bindDic["GYO_NBR"]).Append(" , ");
                insertSql.Append(bindDic["BUMON_CD"]).Append(" , ");
                insertSql.Append(bindDic["HINSYU_CD"]).Append(" , ");
                insertSql.Append(bindDic["BURANDO_CD"]).Append(" , ");
                insertSql.Append(bindDic["MAKER_HBN"]).Append(" , ");
                insertSql.Append(bindDic["SYONMK"]).Append(" , ");
                insertSql.Append(bindDic["JISYA_HBN"]).Append(" , ");
                insertSql.Append(bindDic["JAN_CD"]).Append(" , ");
                insertSql.Append(bindDic["SYOHIN_CD"]).Append(" , ");
                insertSql.Append(bindDic["TANAOROSISCAN_SU"]).Append(" , ");
                insertSql.Append(bindDic["TANAOROSITEISEI_SU"]).Append(" , ");
                insertSql.Append(bindDic["TANAOROSIGOKEI_SU"]).Append(" , ");
                insertSql.Append(bindDic["IRO_CD"]).Append(" , ");
                insertSql.Append(bindDic["SIZE_CD"]).Append(" , ");
                insertSql.Append(bindDic["SIZE_NM"]);
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

        #region [棚卸欠番TBL]を削除する。
        /// <summary>
        /// [棚卸欠番TBL]を削除する。
        /// </summary>
        /// <param name="facadeContext">ファサードコンテキスト</param>
        /// <param name="formVO">明細画面VO</param>
        /// <param name="loginInfo">ログイン情報</param>
        /// <param name="prmTanaorosikijun_ymd">棚卸基準日</param>
        /// <returns>更新件数</returns>
        private int Del_Mdit0040(IFacadeContext facadeContext, Tj040f02Form formVO, LoginInfoVO loginInfo, String prmTanaorosikijun_ymd)
        {
            // XMLからSQLを取得する。
            FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj040p01Constant.SQL_ID_08, facadeContext.DBContext);

            // 店舗コードのバインド
            reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd));
            // 棚卸基準日のバインド
			reader.BindValue("BIND_TANAOROSIKIJUN_YMD", Convert.ToDecimal(BoSystemString.Nvl(prmTanaorosikijun_ymd, "0")));
            // フェイス№のバインド
            reader.BindValue("BIND_FACE_NO", Convert.ToDecimal(BoSystemString.Nvl(formVO.Face_no, "0")));
            // 棚段のバインド
            // reader.BindValue("BIND_TANA_DAN", Convert.ToDecimal(BoSystemString.Nvl(formVO.Tana_dan, "0")));

            //クエリを実行する。
            using (IDbCommand cmd = reader.CreateDbCommand())
            {
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion
	}
}
