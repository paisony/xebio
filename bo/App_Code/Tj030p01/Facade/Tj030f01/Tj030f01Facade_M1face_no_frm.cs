using com.xebio.bo.Tj030p01.Constant;
using com.xebio.bo.Tj030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tj030p01.Facade
{
  /// <summary>
  /// Tj030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj030f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1face_no)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1face_no)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1FACE_NO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1FACE_NO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj030f01Form prevVo = (Tj030f01Form)facadeContext.FormVO;
				Tj030f02Form nextVo = (Tj030f02Form)facadeContext.GetUserObject(Tj030p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");
				// 選択行の情報を取得する。
				Tj030f01M1Form prevM1Vo = (Tj030f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理
				// 「Ｍ１店舗／業者区分」の内容に応じて、検索テーブルを変更する。
				// 「Ｍ１店舗／業者区分」 = 店舗の場合、棚卸確定TBL(H)を取得
				// 「Ｍ１店舗／業者区分」 = 店舗の場合、業者棚卸TBL(H)を取得
				string sSqlId = "";
				if (prevM1Vo.Dictionary[Tj030p01Constant.DIC_M1TENPO_GYOSYA_KB].Equals(ConditionTenpo_gyosya_kbn.VALUE_TENPO))
				{
					sSqlId = Tj030p01Constant.SQL_ID_04;
				}
				else
				{
					sSqlId = Tj030p01Constant.SQL_ID_05;
				}
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// 店舗コード
				rtSeach.BindValue(Tj030p01Constant.SQL_ID_04_REP_TENCD, BoSystemFormat.formatTenpoCd((String)(prevVo.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_CD])));
				// フェイス№
				rtSeach.BindValue(Tj030p01Constant.SQL_ID_04_REP_FACE_NO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tj030p01Constant.DIC_M1FACE_NO]));
				// 棚段
				rtSeach.BindValue(Tj030p01Constant.SQL_ID_04_REP_TANA_DAN, Convert.ToDecimal((string)prevM1Vo.M1tana_dan));
				// 回数
				rtSeach.BindValue(Tj030p01Constant.SQL_ID_04_REP_KAI_SU, Convert.ToDecimal((string)prevM1Vo.M1kai_su));
				// 棚卸日
				rtSeach.BindValue(Tj030p01Constant.SQL_ID_04_REP_TANAOROSI_YMD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tj030p01Constant.DIC_M1TANAOROSI_YMD]));
				// 送信回数/処理日付
				rtSeach.BindValue(Tj030p01Constant.SQL_ID_04_REP_SOSINKAI_SU, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tj030p01Constant.DIC_M1SOSINKAI_SU]));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				
				IList<Hashtable> tableList = rtSeach.Execute();

				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 明細部設定

				decimal dGokeiscan_su = 0;	// 合計スキャン数量

				//// 明細色変更フラグ

				// 検索時の自社品番、スキャンコードを取得
				string xebiocd1 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD1];
				string xebiocd2 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD2];
				string xebiocd3 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD3];
				string xebiocd4 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD4];
				string xebiocd5 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_XEBIOCD5];
				string scanCd1 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD1];
				string scanCd2 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD2];
				string scanCd3 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD3];
				string scanCd4 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD4];
				string scanCd5 = (string)prevVo.Dictionary[Tj030p01Constant.DIC_SEARCH_JANCD5];

				// デフォルト明細色
				String M1dtlirokbnValue = string.Empty;

				foreach (Hashtable rec in tableList)
				{
					Tj030f02M1Form f02m1VO = new Tj030f02M1Form();
					// 明細項目設定
					f02m1VO.M1rowno = rec["GYO_NBR"].ToString();						// Ｍ１行NO
					f02m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();					// Ｍ１部門コード
					f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();			// Ｍ１部門カナ名
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();		// Ｍ１品種略名称
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();				// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();					// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();					// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();						// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();						// Ｍ１サイズ
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();						// Ｍ１スキャンコード
					f02m1VO.M1scan_su = rec["TANAOROSIGOKEI_SU"].ToString();			// Ｍ１スキャン数量
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;			// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;		// Ｍ１確定処理フラグ(隠し)
                    
					// 検索条件（自社品番、スキャンコード）対象行の色を変える
					M1dtlirokbnValue = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					// スキャンコードが一致するか検査
					if (f02m1VO.M1jisya_hbn.Equals(xebiocd1)
						|| f02m1VO.M1jisya_hbn.Equals(xebiocd2)
						|| f02m1VO.M1jisya_hbn.Equals(xebiocd3)
						|| f02m1VO.M1jisya_hbn.Equals(xebiocd4)
						|| f02m1VO.M1jisya_hbn.Equals(xebiocd5)
						|| f02m1VO.M1scan_cd.Equals(scanCd1)
						|| f02m1VO.M1scan_cd.Equals(scanCd2)
						|| f02m1VO.M1scan_cd.Equals(scanCd3)
						|| f02m1VO.M1scan_cd.Equals(scanCd4)
						|| f02m1VO.M1scan_cd.Equals(scanCd5))
					{
						M1dtlirokbnValue = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
					}
					f02m1VO.M1dtlirokbn = M1dtlirokbnValue.ToString();					// Ｍ１明細色区分(隠し)
					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

					// 合計値加算
					dGokeiscan_su += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1scan_su, "0"));
				}
				#endregion

				#region カード部設定
				nextVo.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_CD].ToString();		// ヘッダ店舗コード
				nextVo.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_NM].ToString();		// ヘッダ店舗名																					// ヘッダ店舗名
				nextVo.Modeno = prevVo.Stkmodeno;																			// モードNO
				nextVo.Stkmodeno = prevVo.Stkmodeno;																		// 選択モードNO
				nextVo.Face_no = prevM1Vo.Dictionary[Tj030p01Constant.DIC_M1FACE_NO].ToString();							// フェイスNo
				nextVo.Tana_dan = prevM1Vo.M1tana_dan;																		// 棚段
				nextVo.Kai_su = prevM1Vo.M1kai_su;																			// 回数

				// [店舗／業者区分]が"1"の場合：”店舗"
				// [店舗／業者区分]が"2"の場合：”業者"																				
				nextVo.Tenpo_gyosya_nm = ConditionUtil.GetLabel(ConditionTenpo_gyosya_kbn.ID, prevM1Vo.Dictionary[Tj030p01Constant.DIC_M1TENPO_GYOSYA_KB].ToString());
																															// 店舗／業者名
				nextVo.Tenpo_gyosya_kb = prevM1Vo.Dictionary[Tj030p01Constant.DIC_M1TENPO_GYOSYA_KB].ToString();			// 店舗／業者区分
				nextVo.Nyuryokutan_cd = prevM1Vo.Dictionary[Tj030p01Constant.DIC_M1NYURYOKUTAN_CD].ToString();				// 入力担当者コード
				nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;															// 入力担当者名称
				nextVo.Nyuryoku_ymd = prevM1Vo.M1nyuryoku_ymd;																// 入力日
				nextVo.Sosin_ymd = prevM1Vo.M1sosin_ymd;																	// 送信日

				// 選択明細のVO
				nextVo.Dictionary[Tj030p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tj030p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

				// 合計欄の設定
				nextVo.Gokeiscan_su = dGokeiscan_su.ToString();

				#endregion

				//トランザクションをコミットする。
				// CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				// RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoM1FACE_NO_FRM");

		}
		#endregion
	}
}
