using com.xebio.bo.Te090p01.Constant;
using com.xebio.bo.Te090p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Te090p01.Util
{
  /// <summary>
  /// Te090p01Utilのユーティリティクラスです
  /// </summary>
  public partial class Te090p01Util
	{
		#region 定数を設定します
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		private Te090p01Util()
		{
		}
		#endregion

		#region [移動入荷予定TBL(H)]更新
		/// <summary>
		/// [移動入荷予定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="saiflg">差異フラグ</param
		/// <returns>更新件数</returns>
		public static int Upd_NyukaYoteiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO, decimal saiflg)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_15, facadeContext.DBContext);

			if (mode.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI) || mode.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD))
			{
				// 入荷確定／確定後修正の場合
				// 差異フラグ
				reader.BindValue("BIND_SAI_FLG", saiflg);
				// 伝票状態
				reader.BindValue("BIND_DENPYO_JYOTAI", 1);
				// 履歴処理日付
				reader.BindValue("BIND_KAKUTEI_FLG", 1);
			}
			else
			{
				// 確定後取消の場合
				// 差異フラグ
				reader.BindValue("BIND_SAI_FLG", 0);
				// 伝票状態
				reader.BindValue("BIND_DENPYO_JYOTAI", 0);
				// 履歴処理日付
				reader.BindValue("BIND_KAKUTEI_FLG", 0);

			}
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			if (mode.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI) || mode.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD))
			{
				// 入荷確定／確定後修正の場合
				// 削除フラグ
				reader.BindValue("BIND_SAKUJYO_FLG", 1);
			}
			else
			{
				// 確定後取消の場合
				// 削除フラグ
				reader.BindValue("BIND_SAKUJYO_FLG", 0);
			}
			// 店舗ＬＣ区分
			reader.BindValue("BIND_TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		/// <summary>
		/// [移動入荷予定TBL(H)]を更新する。(差異なし)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">一覧画面のVO</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param
		/// <returns>更新件数</returns>
		public static int Upd_NyukaYoteiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			return Upd_NyukaYoteiH(facadeContext, mode, f01m1VO, logininfo, sysDateVO, 0);
		}
		#endregion

		#region [移動入荷確定TBL(H)]登録
		/// <summary>
		/// [移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="saiflg">差異フラグ</param>
		/// <param name="kakutei_su">確定数</param>
		/// <param name="kakutei_kin">確定金額</param>
		/// <returns>更新件数</returns>
		public static int Ins_NyukaKakuteiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO, decimal saiflg, decimal kakutei_su, decimal kakutei_kin)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 入荷日
			reader.BindValue("JYURYO_YMD", sysDateVO.Sysdate);

			// 差異フラグ
			reader.BindValue("SAI_FLG1", saiflg);
			reader.BindValue("SAI_FLG2", saiflg);
			reader.BindValue("SAI_FLG3", saiflg);

			if (saiflg == 0)
			{
				// 差異がない場合

				// 入荷実績合計数量
				reader.BindValue("NYUKAJISSEKIGOUKEI_SU", 0);
				// 入荷実績合計金額
				reader.BindValue("NYUKAJISSEKIGOUKEI_KIN", 0);
			}
			else
			{
				// 差異がある場合

				// 入荷実績合計数量
				reader.BindValue("NYUKAJISSEKIGOUKEI_SU", kakutei_su);
				// 入荷実績合計金額
				reader.BindValue("NYUKAJISSEKIGOUKEI_KIN", kakutei_kin);
			}

			// 登録日
			reader.BindValue("ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("ADDTAN_CD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", sysDateVO.Sysdate);
			// 店舗ＬＣ区分
			reader.BindValue("TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		
		/// <summary>
		/// [移動入荷予定TBL(H)]を検索し、[移動入荷確定TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Ins_NyukaKakuteiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			return Ins_NyukaKakuteiH(facadeContext, mode, f01m1VO, logininfo, sysDateVO, 0, 0, 0);
		}
		#endregion

		#region [移動入荷確定TBL(B)]登録
		/// <summary>
		/// [移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Ins_NyukaKakuteiB(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_10, facadeContext.DBContext);

			// 店舗ＬＣ区分
			reader.BindValue("TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷確定TBL(B)]登録(明細用)
		/// <summary>
		/// [移動入荷予定TBL(B)]を検索し、[移動入荷確定TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="gyono">行No</param>
		/// <param name="kakuteisu">確定数</param>
		/// <returns>更新件数</returns>
		public static int Ins_NyukaKakuteiB_Detail(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO, decimal gyono, decimal kakuteisu)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 確定数
			reader.BindValue("NYUKAJISSEKI_SU1", kakuteisu);
			reader.BindValue("NYUKAJISSEKI_SU2", kakuteisu);

			// 店舗ＬＣ区分
			reader.BindValue("TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 伝票番号
			reader.BindValue("DENPYOGYO_NO", gyono);

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷確定TBL(H)]更新
		/// <summary>
		/// [移動入荷確定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="saiflg">差異フラグ</param>
		/// <param name="kakutei_su">確定数</param>
		/// <param name="kakutei_kin">確定金額</param>
		/// <returns>更新件数</returns>
		public static int Upd_NyukaKakuteiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO, decimal saiflg, decimal kakutei_su, decimal kakutei_kin)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_11, facadeContext.DBContext);


			// 入荷実績合計数量
			reader.BindValue("BIND_NYUKAJISSEKIGOUKEI_SU", kakutei_su);
			// 入荷実績合計金額
			reader.BindValue("NYUKAJISSEKIGOUKEI_KIN1", kakutei_kin);
			reader.BindValue("NYUKAJISSEKIGOUKEI_KIN2", kakutei_kin);
			// 差異フラグ
			reader.BindValue("BIND_SAI_FLG", saiflg);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// 店舗ＬＣ区分
			reader.BindValue("BIND_TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("BIND_SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// [移動入荷確定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Upd_NyukaKakuteiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			return Upd_NyukaKakuteiH(facadeContext, mode, f01m1VO, logininfo, sysDateVO, 0, 0, 0);
		}
		#endregion

		#region [移動入荷履歴TBL(H)]登録
		/// <summary>
		/// [移動入荷確定TBL(H)]を検索し、[移動入荷履歴TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="akakuroKb">赤黒区分 0:黒伝、1:赤伝</param>
		/// <returns>更新件数</returns>
		public static int Ins_NyukaRirekiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO, decimal akakuroKb)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_16, facadeContext.DBContext);

			// 処理種別
			reader.BindValue("SYORI_SB1", getSyoriSb(mode));
			reader.BindValue("SYORI_SB2", getSyoriSb(mode));
			reader.BindValue("SYORI_SB3", getSyoriSb(mode));

			// 赤黒区分
			reader.BindValue("AKAKURO_KBN1", akakuroKb);
			reader.BindValue("AKAKURO_KBN2", akakuroKb);
			reader.BindValue("AKAKURO_KBN3", akakuroKb);
			reader.BindValue("AKAKURO_KBN4", akakuroKb);
			reader.BindValue("AKAKURO_KBN5", akakuroKb);

			// 履歴処理日付
			reader.BindValue("RIREKI_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("RIREKI_SYORI_TM", sysDateVO.Systime_mili);
			// 更新日
			reader.BindValue("UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", sysDateVO.Sysdate);
			// 店舗ＬＣ区分
			reader.BindValue("TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷履歴TBL(B)]登録
		/// <summary>
		/// [移動入荷確定TBL(B)]を検索し、[移動入荷履歴TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="akakuroKb">赤黒区分 0:黒伝、1:赤伝</param>
		/// <returns>更新件数</returns>
		public static int Ins_NyukaRirekiB(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO, decimal akakuroKb)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_17, facadeContext.DBContext);

			// 赤黒区分
			reader.BindValue("AKAKURO_KBN1", akakuroKb);
			reader.BindValue("AKAKURO_KBN2", akakuroKb);

			// 店舗ＬＣ区分
			reader.BindValue("TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷確定TBL(B)]削除
		/// <summary>
		/// [移動入荷確定TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Del_NyukaKakuteiB(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_18, facadeContext.DBContext);

			// 店舗ＬＣ区分
			reader.BindValue("TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷確定TBL(H)]削除
		/// <summary>
		/// [移動入荷確定TBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Del_NyukaKakuteiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_19, facadeContext.DBContext);

			// 店舗ＬＣ区分
			reader.BindValue("TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動出荷差異リスト]削除
		/// <summary>
		/// [移動出荷差異リスト]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Del_SyukkaSaiL(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_20, facadeContext.DBContext);

			// ■バインド
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));

			// ■リプレイス
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// テーブルID（シノニム）
			sRepSql.Append("MDNT0030_").Append(Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD])).Append(" T1");

			BoSystemSql.AddSql(reader, Te090p01Constant.SQL_REP_TABLE_ID, sRepSql.ToString(), bindList);

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動出荷確定TBL(H)]更新
		/// <summary>
		/// [移動出荷確定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Upd_SyukkaKakuteiH(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader;
			if (mode.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI) || mode.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD))
			{
				// 入荷確定、確定後修正
				reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_23, facadeContext.DBContext);
			}
			else
			{
				// 確定後取消
				reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_21, facadeContext.DBContext);
			}

			// ■バインド
			if (mode.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI) || mode.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD))
			{
				// 入荷確定、確定後修正
				// 入荷担当者コード
				reader.BindValue("NYUKATAN_CD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
				// 入荷日
				reader.BindValue("JYURYO_YMD", sysDateVO.Sysdate);
			}
			// 更新日
			reader.BindValue("UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", sysDateVO.Sysdate);

			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));

			// ■リプレイス
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// テーブルID（シノニム）
			sRepSql.Append("MDUT0010_").Append(Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD])).Append(" T1");

			BoSystemSql.AddSql(reader, Te090p01Constant.SQL_REP_TABLE_ID, sRepSql.ToString(), bindList);

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動出荷確定TBL(B)]更新
		/// <summary>
		/// [移動出荷確定TBL(B)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Upd_SyukkaKakuteiB(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader;
			if (mode.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI) || mode.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD))
			{
				// 入荷確定、確定後修正
				reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_24, facadeContext.DBContext);
			}
			else
			{
				// 確定後取消
				reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_22, facadeContext.DBContext);
			}

			// ■バインド
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));

			// ■リプレイス
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// テーブルID（シノニム）
			sRepSql.Append("MDUT0011_").Append(Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD])).Append(" T1");

			BoSystemSql.AddSql(reader, Te090p01Constant.SQL_REP_TABLE_ID, sRepSql.ToString(), bindList);

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動入荷未存在リストTBL(B)]更新
		/// <summary>
		/// [移動入荷未存在リストTBL(B)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="nyukaten">入荷店コード</param>
		/// <returns>更新件数</returns>
		public static int Upd_MisonzaiList(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO, string nyukaten)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// 入荷会社コード
			reader.BindValue("BIND_JYURYOKAISYA_CD", Convert.ToDecimal(logininfo.CopCd));
			// 入荷店コード
			reader.BindValue("BIND_JYURYOTEN_CD", BoSystemFormat.formatTenpoCd(nyukaten));
			// SCMコード
			reader.BindValue("BIND_SCM_CD", f01m1VO.M1scm_cd);


			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [移動出荷差異リスト]登録
		/// <summary>
		/// [移動出荷差異リスト]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="mode">モード</param>
		/// <param name="f01m1VO">一覧画面選択行のVO</param>
		/// <param name="logininfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		public static int Ins_SyukkaSaiL(IFacadeContext facadeContext, string mode, Te090f01M1Form f01m1VO, LoginInfoVO logininfo, SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Te090p01Constant.SQL_ID_25, facadeContext.DBContext);

			// ■バインド
			// 登録日
			reader.BindValue("ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("ADDTAN_CD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("SAKUJYO_YMD", sysDateVO.Sysdate);

			// 店舗LC区分コード
			reader.BindValue("TENPOLC_KBN", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
			// 出荷会社コード
			reader.BindValue("SYUKKAKAISYA_CD", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
			// 出荷店コード
			reader.BindValue("SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1syukkaten_cd));
			// 伝票番号
			reader.BindValue("DENPYO_BANGO", Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
			// 出荷日
			reader.BindValue("SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1syukka_ymd)));

			// ■リプレイス
			ArrayList bindList = new ArrayList();
			StringBuilder sRepSql = new StringBuilder();

			// テーブルID（シノニム）
			sRepSql.Append("MDNT0030_").Append(Convert.ToDecimal(f01m1VO.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));

			BoSystemSql.AddSql(reader, Te090p01Constant.SQL_REP_TABLE_ID, sRepSql.ToString(), bindList);

			// クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 処理種別取得
		/// <summary>
		/// 処理種別取得を取得します。
		/// </summary>
		/// <param name="f01VO">一覧画面のVO</param>
		/// <returns>処理種別</returns>
		public static decimal getSyoriSb(string mode)
		{
			decimal syorisb = 1;

			if (mode.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
			{
				// 入荷確定の場合
				syorisb = Te090p01Constant.SYORI_SB_NYUKAKAKUTEI;
			}
			else if (mode.Equals(BoSystemConstant.MODE_KAKUTEIGOUPD))
			{
				// 確定後修正の場合
				syorisb = Te090p01Constant.SYORI_SB_UPD;
			}
			else
			{
				// 確定後取消の場合
				syorisb = Te090p01Constant.SYORI_SB_DEL;
			}

			return syorisb;
		}
		#endregion
	}
}
