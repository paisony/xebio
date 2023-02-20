using com.xebio.bo.Td050p01.Constant;
using com.xebio.bo.Td050p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01004;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DateUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Td050p01.Util
{
  /// <summary>
  /// Td050f01のユーティリティクラスです
  /// </summary>
  public partial class Td050p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Td050p01Util ()
		{
		}
		#endregion
		#region 返品確定日初期値取得
		/// <summary>
		/// 返品確定日初期値取得
		/// </summary>
		/// <param name="sysDateVO">SysDateVO</param>
		/// <returns>返品確定日</returns>
		public static string GetHenpinKakuteiYmdInit ( SysDateVO sysDateVO )
		{
			StringBuilder sbVal = new StringBuilder();
			sbVal.Append("");
			// 前月を取得
			sbVal.Append(BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).AddMonths(-1).ToString("yyyyMM"));
			sbVal.Append(Td050p01Constant.HENPIN_KAKUTEI_YMD_INIT);
			return sbVal.ToString();
		}
		#endregion
		#region 返品伝票番号の採番を行う。(SQL_ID_01によりチェック含む)
		/// <summary>
		/// 返品伝票番号の採番を行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="tenpo_cd_p">店舗コード</param>
		/// <param name="syori_ymd_p">処理日付</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>伝票番号 ※採番不可の場合は、-1を戻す</returns>
		public static decimal AutoNumber_HenpinDenNo ( IFacadeContext facadeContext,
												String tenpo_cd_p,
												String syori_ymd_p,
												LoginInfoVO loginInfo )
		{

			Boolean loop = true;
			decimal loopCnt = 0;
			string denno = string.Empty;

			while (loop)
			{
				// 採番を行う
				denno = NumberingCls.Numbering(
											facadeContext,
											BoSystemConstant.AUTONUM_HENPIN_TEISEINO,
											"0000",
											loginInfo.LoginId
						);
				decimal dDenno = Convert.ToDecimal(denno);


				// 採番値が既にテーブルで使用されていないかチェック(※されている場合は次の番号を採番)
				// XMLからSQLを取得する。
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_01, facadeContext.DBContext);

				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
				sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");
				sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(tenpo_cd_p);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 伝票番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(dDenno);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 処理日付
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD";
				bindVO.Value = syori_ymd_p;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 追加の条件
				BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);

				// SQL実行
				IList<Hashtable> ItemList = reader.Execute();

				if (ItemList == null || ItemList.Count <= 0)
				{
					// 伝票番号が未存在の場合、採番OK
					loop = false;
				}
				else
				{
					Hashtable ht = (Hashtable)ItemList[0];
					if ((decimal)ht["CNT"] <= 0)
					{
						// 伝票番号が未存在の場合、採番OK
						loop = false;
					}
				}

				loopCnt++;

				if (loopCnt >= Td050p01Constant.HENPIN_DENPYO_BANGO_MAX)
				{
					// 採番可能数を超えた場合、処理終了
					return -1;
				}
			}
			return Convert.ToDecimal(BoSystemString.Nvl(denno, "-1"));
		}
		#endregion
		#region [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。(SQL_ID_04)
		/// <summary>
		/// [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="akakuro_flg">赤黒フラグ(true:赤,false:黒)</param>
		/// <param name="dDenno_p">伝票番号</param>
		/// <returns>更新件数</returns>
		public static int Ins_HenpinRirekih ( IFacadeContext facadeContext,
									Td050f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									Boolean akakuro_flg,
									decimal syori_sb,
									decimal dDenban )
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_04, facadeContext.DBContext);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_INS", dDenban);
			reader.BindValue("BIND_DENPYO_BANGO", dDenban);
			// 赤黒区分
			decimal dAkakuro = 0;
			if (akakuro_flg)
			{
				dAkakuro = Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_AKA);
			}
			else
			{
				dAkakuro = Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_KURO);
			}
			reader.BindValue("BIND_AKAKURO_KBN", dAkakuro);
			reader.BindValue("BIND_AKAKURO_KBN2", dAkakuro);
			reader.BindValue("BIND_AKAKURO_KBN3", dAkakuro);
			// 履歴画面表示区分
			reader.BindValue("BIND_RIREKI_DISP_KB",Convert.ToDecimal(BoSystemConstant.RIREKI_DISP_KB_HYOJI));
			// 履歴処理日付
			reader.BindValue("BIND_RIREKI_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("BIND_RIREKI_SYORI_TM", sysDateVO.Systime_mili);
			// 処理種別（訂正取消）
			reader.BindValue("BIND_SYORI_SB", syori_sb);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 処理日
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion
		#region [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。(SQL_ID_05)
		/// <summary>
		/// [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="akakuro_flg">赤黒フラグ(true:赤,false:黒)</param>
		/// <param name="dDenno_p">伝票番号</param>
		/// <returns>更新件数</returns>
		public static int Ins_HenpinRirekib ( IFacadeContext facadeContext,
									Td050f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									Boolean akakuro_flg,
									decimal dDenban )
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_05, facadeContext.DBContext);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO_INS", dDenban);
			reader.BindValue("BIND_DENPYO_BANGO", dDenban);
			// 赤黒区分
			decimal dAkakuro = 0;
			if (akakuro_flg)
			{
				dAkakuro = Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_AKA);
			}
			else
			{
				dAkakuro = Convert.ToDecimal(BoSystemConstant.AKAKURO_KBN_KURO);
			}
			reader.BindValue("BIND_AKAKURO_KBN", dAkakuro);
			reader.BindValue("BIND_AKAKURO_KBN2", dAkakuro);

			// 処理日
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion
		#region [返品確定TBL(H)]を更新する。(SQL_ID_08)
		/// <summary>
		/// [返品確定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="shinkuro_flg">新黒フラグ true:新黒,false:新黒以外</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		public static int Upd_HenpinKakuteih ( IFacadeContext facadeContext,
									Td050f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									Boolean shinkuro_flg,
									decimal dDenban )
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Td050p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 新黒フラグ
			decimal dShinkuro = 0;
			if (shinkuro_flg)
			{
				dShinkuro = Convert.ToDecimal(BoSystemConstant.SHINKURO_FLG_SHINKURO);
			}
			else
			{
				dShinkuro = Convert.ToDecimal(BoSystemConstant.SHINKURO_FLG_NOT_SHINKURO);
			}
			reader.BindValue("BIND_SHINKURO_FLG", dShinkuro);

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));


			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1TENPO_CD]));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenban);
			// 処理日
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td050p01Constant.DIC_M1SYORI_YMD], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion
		#region 処理種別取得
		/// <summary>
		/// 処理種別取得
		/// </summary>
		/// <param name="sosinzumi_flg">送信済みフラグ</param>
		/// <returns>チェック結果（true:エラー、false：エラーなし）</returns>
		public static decimal GetShori_sb ( String sosinzumi_flg )
		{
			// 処理種別 訂正を初期値に設定
			decimal dsyori_sb = Td050p01Constant.SYORI_SB_TEISEI;
			// Dictionary.[Ｍ１送信済フラグ]が、0（未送信）の場合
			if (ConditionSosinzumi_flg.VALUE_MISOSIN.Equals(sosinzumi_flg))
			{
				dsyori_sb = Td050p01Constant.SYORI_SB_TEISEI_UPD;			// 処理種別（訂正修正）

			}
			return dsyori_sb;
		}
		#endregion
	}
}
