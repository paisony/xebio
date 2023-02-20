using com.xebio.bo.Ta010p01.Constant;
using com.xebio.bo.Ta010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Data;
using System.Reflection;

namespace com.xebio.bo.Ta010p01.Util
{
  /// <summary>
  /// Td050f01のユーティリティクラスです
  /// </summary>
  public partial class Ta010p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Ta010p01Util ()
		{
		}
		#endregion
		#region 現在行数取得
		/// <summary>
		/// 処理種別取得
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <returns>現在行数</returns>
		public static int GetRowCnt ( IDataList m1List )
		{
			// 現在行数
			int curRowCnt = 0;
			// 後方から検索
			for (int i = m1List.Count - 1; i >= 0; i--)
			{
				// 行オブジェクト取得
				Ta010f02M1Form m1FormVO = (Ta010f02M1Form)m1List[i];

				// スキャンコード　または　依頼数に入力がある場合
				if (!string.IsNullOrEmpty(m1FormVO.M1scan_cd)
				 || !string.IsNullOrEmpty(m1FormVO.M1irai_su))
				{
					curRowCnt = i + 1;
					break;
				}
			}
			return curRowCnt;
		}
		#endregion
		#region 発注メッセージ取得
		/// <summary>
		/// 処理種別取得
		/// </summary>
		/// <param name="Ta010f02M1Form">f02m1VO</param>
		/// <returns>発注メッセージ</returns>
		public static string GetHtms ( Ta010f02M1Form f02m1VO )
		{
			string sHtms = "";
			// [Ｍ１自動定数]＞0の場合、"本部配分"固定
			if (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1jido_su, "0")) > 0)
			{
				sHtms = Ta010p01Constant.HTMS_HONBU;
			}
			// [Ｍ１店在庫数]＞0 かつ [Ｍ１売上実績数＜＝0 の場合、"売上実績なし"固定
			else if (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1tenzaiko_su, "0")) > 0
				  && Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1uriage_su, "0")) <= 0)
			{
				sHtms = Ta010p01Constant.HTMS_URI;
			}
			// [Ｍ１依頼数量]＜＝（[Ｍ１入荷予定数]）の場合、"入荷予定あり"固定
			else if (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1irai_su, "0")) >  0 &&
					 Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1irai_su, "0")) <= Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1nyukayotei_su, "0")))
			{
				sHtms = Ta010p01Constant.HTMS_NYU;
			}
			return sHtms;
		}
		#endregion
		#region 単品レポートメッセージ出力
		/// <summary>
		/// 単品レポートメッセージ出力
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="bool">blErr</param>
		/// <returns></returns>
		public static bool setTanpinMsg ( IFacadeContext facadeContext
										 , bool blErr
		)
		{
			bool blRet = blErr;
			if (!blErr)
 			{
				InfoMsgCls.AddWarnMsg("I104", String.Empty, facadeContext);
				blRet = true;
			}
			return blRet;
		}
		#endregion
		#region 単品レポートメッセージ出力
		/// <summary>
		/// setTanpinReportMsg 単品レポートメッセージ出力
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="bool">blErr</param>
		/// <returns></returns>
		public static bool setTanpinReportMsg(string id, string param, IFacadeContext facadeContext, string[] item, string num, string index, string meisaiid, int dispRow
											, bool blErr)
		{
			bool blRet = blErr;
			// 明細画面
			Ta010f02Form f02VO = (Ta010f02Form)facadeContext.FormVO;

			// [選択モードNo]が「修正」で区分が補充依頼の場合は、エラー
			if (BoSystemConstant.MODE_UPD.Equals(f02VO.Stkmodeno)
			 && ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN1.Equals(f02VO.Kbn_cd))
			{
				// エラーメッセージ出力
				ErrMsgCls.AddErrMsg(id, param, facadeContext, item, num, index, meisaiid, dispRow);
			}
			else
			{
				// 単品登録モードがＯＮの場合、メッセージ出力はしない
				if (!Convert.ToString(Ta010p01Constant.FLG_ON).Equals((string)f02VO.Dictionary[Ta010p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]))
				{
					// 単品レポートエラーヘッダメッセージ設定
					blRet = Ta010p01Util.setTanpinMsg(facadeContext, blErr);
					// 単品レポートエラーメッセージ設定
					InfoMsgCls.AddWarnMsg(id, param, facadeContext, item, num, index, meisaiid, dispRow);
				}

			}
			return blRet;
		}
		#endregion
		#region ロット数チェック
		/// <summary>
		/// ロット数チェック
		/// </summary>
		/// <param name="string">lot_su</param>
		/// <param name="string">irai_su</param>
		/// <returns>bool(true:エラー,false:正常)</returns>
		public static bool ChkLotIrai ( string lot_su, string irai_su )
		{
			bool blRet = false;
			decimal wkLot = Convert.ToDecimal(BoSystemString.Nvl(lot_su, "0"));
			decimal wkIrai = Convert.ToDecimal(BoSystemString.Nvl(irai_su, "0"));

			// ロット数が０の場合
			if (wkLot == 0)
			{
				blRet = true;
			}
			// ロット数の方が大きい場合
			else if(wkLot > wkIrai)
			{
				blRet = true;
			}
			else
			{
				// 依頼数からロット数の剰余を計算
				decimal wkAmari = wkIrai % wkLot;
				// 余りが０でない場合は、エラー
				if (wkAmari != 0)
				{
					blRet = true;
				}
			}
			return blRet;
		}
		#endregion
		#region 補充依頼申請TBL(H)を更新する。(SQL_ID_05)
		/// <summary>
		/// 補充依頼申請TBL(H)を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Ta010f01M1Form">f01M1Form</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="mode">選択モード</param>
		/// <returns>更新件数</returns>
		public static int Upd_OrderAplly ( IFacadeContext facadeContext,
									Ta010f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									string mode )
		{
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_05, facadeContext.DBContext);
			// XMLからSQLを取得する。
			// モードNOが「申請」
			if (mode.Equals(BoSystemConstant.MODE_APPLY))
			{
				// 申請状態(1:申請済)
				reader.BindValue("BIND_SHINSEI_FLG", Convert.ToDecimal(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI2));
				// 削除フラグ
				reader.BindValue("BIND_SAKUJYO_FLG", Ta010p01Constant.FLG_ON);
			}
			// モードNOが「取消」
			else if (mode.Equals(BoSystemConstant.MODE_DEL))
			{
				// 申請状態(0:未申請)
				reader.BindValue("BIND_SHINSEI_FLG", Convert.ToDecimal(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1));
				// 削除フラグ
				reader.BindValue("BIND_SAKUJYO_FLG", Ta010p01Constant.FLG_OFF);
			}

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// ---------------------------------
			// 更新ＫＥＹ
			// ---------------------------------
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD]));
			// 管理No
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD]))));
			// 区分コード
			reader.BindValue("BIND_KBN_CD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#region [補充依頼申請TBL(H)]を検索し、[補充依頼確定TBL(H)]を登録する。(SQL_ID_08)
		/// <summary>
		/// [補充依頼申請TBL(H)]を検索し、[補充依頼確定TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Ins_HeadOrderAplly ( IFacadeContext facadeContext
											, Ta010f01M1Form f01M1Form
											, LoginInfoVO loginInfo
											, SysDateVO sysDateVO
											, decimal dRegGamen
											, decimal iraiGoukeiSu
											, decimal iraiGoukeiKin
		)
		{
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_08, facadeContext.DBContext);
			// -------------------------------------------
			// バインド変数の置き換え
			// -------------------------------------------
			// 登録画面：ＳＱＬ分岐用
			reader.BindValue("BIND_REG_KBN1", dRegGamen);
			reader.BindValue("BIND_REG_KBN2", dRegGamen);
			// 合計依頼数量
			reader.BindValue("BIND_IRAIGOKEI_SU", iraiGoukeiSu);
			// 合計依頼金額
			reader.BindValue("BIND_IRAIGOKEI_KIN", iraiGoukeiKin);
			// 申請日
			reader.BindValue("BIND_APPLY_YMD", sysDateVO.Sysdate);
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", Ta010p01Constant.FLG_OFF);						// 0（なし）
			// 送信依頼フラグ
			reader.BindValue("BIND_SOSINIRAI_FLG", Convert.ToDecimal(ConditionSosinirai_flg.VALUE_ARI));	// 1（送信対象）
			// 送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", Convert.ToDecimal(ConditionSosinzumi_flg.VALUE_MISOSIN));		// 0（未送信）

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD]));
			// 管理No
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD]))));
			// 区分コード
			reader.BindValue("BIND_KBN_CD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion
		#region 補充依頼確定TBL(H,B)を削除する。(SQL_ID_09)
		/// <summary>
		/// 補充依頼確定TBL(B)更新（メッセージ区分）
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Ta010f01M1Form">f01M1Form</param>
		/// <param name="decimal">delKbn</param>
		/// <returns>更新件数</returns>
		public static int Del_Order ( IFacadeContext facadeContext,
									Ta010f01M1Form f01M1Form,
									decimal delKbn )
		{
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Ta010p01Constant.SQL_ID_09, facadeContext.DBContext);
			string sTblID = "";
			if (Ta010p01Constant.DEL_KBN_SHINSEI_HEAD == delKbn)
			{
				// 削除TBL（補充依頼確定H）
				sTblID = "MDOT0010";
			}
			else if (Ta010p01Constant.DEL_KBN_SHINSEI_BODY == delKbn)
			{
				// 削除TBL（補充依頼確定B）
				sTblID = "MDOT0011";
			}
			else if (Ta010p01Constant.DEL_KBN_KAKUTEI_HEAD == delKbn)
			{
				// 削除TBL（補充依頼確定H）
				sTblID = "MDOT0020";
			}
			else if (Ta010p01Constant.DEL_KBN_KAKUTEI_BODY == delKbn)
			{
				// 削除TBL（補充依頼確定B）
				sTblID = "MDOT0021";
			}
			// 削除テーブル設定
			BoSystemSql.AddSql(reader, Ta010p01Constant.SQL_ADD_TBLID, sTblID);

			// -------------------------------------------
			// バインド変数の置き換え
			// -------------------------------------------
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1TENPO_CD]));
			// 管理No
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1SYORI_YMD]))));
			// 区分コード
			reader.BindValue("BIND_KBN_CD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Ta010p01Constant.DIC_M1KBN_CD], "0")));
			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 依頼理由のGetter/Setter
		/// <summary>
		/// GetIrairiyu_cd 依頼理由区分取得
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <returns></returns>
		public static string GetIrairiyu_cd<FormT>(IFormVO formVO)
		{
			// 区分コードを取得
			string kbncd = string.Empty;
			PropertyInfo kbncdInfo = formVO.GetType().GetProperty("Kbn_cd");

			if (kbncdInfo != null)
			{
				kbncd = (string)kbncdInfo.GetValue(formVO, null);
			}

			if (kbncd.Equals(ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN1))
			{
				// 補充依頼の場合
				PropertyInfo riyuInfo = formVO.GetType().GetProperty("Irairiyu_cd1");
				if (riyuInfo != null)
				{
					return (string)riyuInfo.GetValue(formVO, null);
				}
			}
			else if (kbncd.Equals(ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN2))
			{
				// 単品レポートの場合
				PropertyInfo riyuInfo = formVO.GetType().GetProperty("Irairiyu_cd2");
				if (riyuInfo != null)
				{
					return (string)riyuInfo.GetValue(formVO, null);
				}

			}
			// その他の場合
			return string.Empty;
		}
		/// <summary>
		/// SetIrairiyu_cd 依頼理由区分設定
		/// </summary>
		/// <param name="formVO">フォームVO</param>
		/// <returns></returns>
		public static void SetIrairiyu_cd<FormT>(IFormVO formVO, string val)
		{
			// 区分コードを取得
			string kbncd = string.Empty;
			PropertyInfo kbncdInfo = formVO.GetType().GetProperty("Kbn_cd");

			if (kbncdInfo != null)
			{
				kbncd = (string)kbncdInfo.GetValue(formVO, null);
			}

			if (kbncd.Equals(ConditionHojuirai_kbn.VALUE_HOJUIRAI_KBN1))
			{
				// 補充依頼の場合
				PropertyInfo riyuInfo = formVO.GetType().GetProperty("Irairiyu_cd1");
				if (riyuInfo != null)
				{
					riyuInfo.SetValue(formVO, val, null);
				}
			}
			else
			{
				// 単品レポートの場合
				PropertyInfo riyuInfo = formVO.GetType().GetProperty("Irairiyu_cd2");
				if (riyuInfo != null)
				{
					riyuInfo.SetValue(formVO, val, null);
				}
			}
		}
		#endregion
	}
}
