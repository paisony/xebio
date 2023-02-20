using com.xebio.bo.Ta080p01.Constant;
using com.xebio.bo.Ta080p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01023;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DateUtil;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Ta080p01.Util
{
  /// <summary>
  /// Ta080p01のユーティリティクラスです
  /// </summary>
  public partial class Ta080p01Util
	{
		#region 検索ボタン_検索条件設定
		/// <summary>
		/// 検索ボタン_検索条件設定
		/// </summary>
		/// <param name="f01VO"></param>
		/// <param name="reader"></param>
		public static void SetBindDoSelect(Ta080f01Form f01VO, FindSqlResultTable reader)
		{
			BindInfoVO bindVO = new BindInfoVO();
			ArrayList bindListT10 = new ArrayList();
			ArrayList bindListT11 = new ArrayList();
			ArrayList bindListT12 = new ArrayList();
			ArrayList bindListT13 = new ArrayList();
			ArrayList bindListT20 = new ArrayList();
			ArrayList bindListT21 = new ArrayList();
			ArrayList bindListT22 = new ArrayList();
			ArrayList bindListT23 = new ArrayList();
			ArrayList bindListT24 = new ArrayList();
			StringBuilder sRepSqlT10 = new StringBuilder();
			StringBuilder sRepSqlT11 = new StringBuilder();
			StringBuilder sRepSqlT12 = new StringBuilder();
			StringBuilder sRepSqlT13 = new StringBuilder();
			StringBuilder sRepSqlT20 = new StringBuilder();
			StringBuilder sRepSqlT21 = new StringBuilder();
			StringBuilder sRepSqlT22 = new StringBuilder();
			StringBuilder sRepSqlT23 = new StringBuilder();
			StringBuilder sRepSqlT24 = new StringBuilder();

			// T10 単品レポート_仕入枠
			AddItiranWhere(f01VO, bindVO, bindListT10, sRepSqlT10, "T10");
			// T11 単品レポート_未申請データ
			AddItiranWhere(f01VO, bindVO, bindListT11, sRepSqlT11, "T11");
			// T12 単品レポート_申請データ
			AddItiranWhere(f01VO, bindVO, bindListT12, sRepSqlT12, "T12");
			// T20 補充依頼_仕入枠
			AddItiranWhere(f01VO, bindVO, bindListT20, sRepSqlT20, "T20");
			// T21 補充依頼_未申請データ
			AddItiranWhere(f01VO, bindVO, bindListT21, sRepSqlT21, "T21");
			// T22 補充依頼_申請データ
			AddItiranWhere(f01VO, bindVO, bindListT22, sRepSqlT22, "T22");
			// T23 補充依頼_申請データ、実績データ
			AddItiranWhere(f01VO, bindVO, bindListT23, sRepSqlT23, "T23");

			// T13 単品レポート_リンク先データ
			addSql(f01VO, bindVO, bindListT13, sRepSqlT13, "T13");
			// T24 補充依頼_リンク先データ
			addSql(f01VO, bindVO, bindListT24, sRepSqlT24, "T24");

			BoSystemSql.AddSql(reader, "ADD_WHERE_T10", sRepSqlT10.ToString(), bindListT10);
			BoSystemSql.AddSql(reader, "ADD_WHERE_T11", sRepSqlT11.ToString(), bindListT11);
			BoSystemSql.AddSql(reader, "ADD_WHERE_T12", sRepSqlT12.ToString(), bindListT12);
			BoSystemSql.AddSql(reader, "ADD_WHERE_T20", sRepSqlT20.ToString(), bindListT20);
			BoSystemSql.AddSql(reader, "ADD_WHERE_T21", sRepSqlT21.ToString(), bindListT21);
			BoSystemSql.AddSql(reader, "ADD_WHERE_T22", sRepSqlT22.ToString(), bindListT22);
			BoSystemSql.AddSql(reader, "ADD_WHERE_T23", sRepSqlT23.ToString(), bindListT23);

			BoSystemSql.AddSql(reader, "ADD_SQL_T13", sRepSqlT13.ToString(), bindListT13);
			BoSystemSql.AddSql(reader, "ADD_SQL_T24", sRepSqlT24.ToString(), bindListT24);

			// バインド変数設定
			// [ヘッダ店舗コード]
			reader.BindValue("TENPO_CD_T10", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			reader.BindValue("TENPO_CD_T11", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			reader.BindValue("TENPO_CD_T12", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			reader.BindValue("TENPO_CD_T20", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			reader.BindValue("TENPO_CD_T21", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			reader.BindValue("TENPO_CD_T22", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			reader.BindValue("TENPO_CD_T23", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
		}

		#endregion

		#region 検索ボタン_検索条件設定_AddWhere
		/// <summary>
		/// 検索ボタン_検索条件設定_AddWhere
		/// </summary>
		/// <param name="f01VO"></param>
		/// <param name="bindVO"></param>
		/// <param name="bindList"></param>
		/// <param name="sRepSql"></param>
		/// <param name="sTblnm"></param>
		public static void AddItiranWhere(Ta080f01Form f01VO, BindInfoVO bindVO, ArrayList bindList, StringBuilder sRepSql, string sTblnm)
		{
			string sWkTblnm = "";
			#region [年月度FROM]
			if (!string.IsNullOrEmpty(f01VO.Yosan_ymd_from))
			{
				// ※未申請データは システム日付とぶつける
				if (sTblnm.Equals("T11")
					|| sTblnm.Equals("T21")
				)
				{
					sRepSql.Append(" AND TO_NUMBER(TO_CHAR(ADD_MONTHS(SYSDATE, 0), 'YYYYMM')) >= :YOSAN_YMD_FROM_" + sTblnm);
				}
				else
				{
					sRepSql.Append(" AND " + sTblnm + ".YOSAN_YMD >= :YOSAN_YMD_FROM_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "YOSAN_YMD_FROM_" + sTblnm;
				bindVO.Value = f01VO.Yosan_ymd_from.Substring(0, 6);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region [年月度TO]
			if (!string.IsNullOrEmpty(f01VO.Yosan_ymd_to))
			{
				// ※未申請データは システム日付とぶつける
				if (sTblnm.Equals("T11")
					|| sTblnm.Equals("T21")
				)
				{
					sRepSql.Append(" AND TO_NUMBER(TO_CHAR(ADD_MONTHS(SYSDATE, 0), 'YYYYMM')) <= :YOSAN_YMD_TO_" + sTblnm);
				}
				else
				{
					sRepSql.Append(" AND " + sTblnm + ".YOSAN_YMD <= :YOSAN_YMD_TO_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "YOSAN_YMD_TO_" + sTblnm;
				bindVO.Value = f01VO.Yosan_ymd_to.Substring(0, 6);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region [仕入枠ｸﾞﾙｰﾌﾟｺｰﾄﾞFROM]
			if (!string.IsNullOrEmpty(f01VO.Yosan_cd_from))
			{
				// ※単品レポートデータは "000000"とぶつける
				if (sTblnm.Equals("T11")
					|| sTblnm.Equals("T12")
				)
				{
					sRepSql.Append(" AND '000000' >= :YOSAN_CD_FROM_" + sTblnm);
				}
				// 補充依頼データ
				else
				{
					// 補充依頼かつ補充依頼申請TBL参照の場合、
					if (sTblnm.Equals("T21"))
					{
						sWkTblnm = "M21";
					}
					else
					{
						sWkTblnm = sTblnm;
					}
					sRepSql.Append(" AND " + sWkTblnm + ".YOSAN_CD 	>= :YOSAN_CD_FROM_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "YOSAN_CD_FROM_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatYosan_Cd(f01VO.Yosan_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region [仕入枠ｸﾞﾙｰﾌﾟｺｰﾄﾞTO]
			if (!string.IsNullOrEmpty(f01VO.Yosan_cd_to))
			{
				// ※単品レポートデータは "000000"とぶつける
				if (sTblnm.Equals("T11")
					|| sTblnm.Equals("T12")
				)
				{
					sRepSql.Append(" AND '000000' <= :YOSAN_CD_TO_" + sTblnm);
				}
				// 補充依頼データ
				else
				{
					// 補充依頼かつ補充依頼申請TBL参照の場合、
					if (sTblnm.Equals("T21"))
					{
						sWkTblnm = "M21";
					}
					else
					{
						sWkTblnm = sTblnm;
					}
					sRepSql.Append(" AND " + sWkTblnm + ".YOSAN_CD 	<= :YOSAN_CD_TO_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "YOSAN_CD_TO_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatYosan_Cd(f01VO.Yosan_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region [申請種別]
			//（-1:空白／11:店舗補充／20:単品レポート／02:仕入稟議)
			if (!string.IsNullOrEmpty(f01VO.Sinsei_sb) && !f01VO.Sinsei_sb.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				// 申請種別_区分コード部分（1桁目）
				string Sinsei_sb_kbn_cd = f01VO.Sinsei_sb.Substring(0, 1);
				// 仕入枠データの場合
				if (sTblnm.Equals("T10")
				|| sTblnm.Equals("T20"))
				{
					// 抽出対象項目は区分コード（補充依頼/単品データ）（1桁目使用）
					// かつ
					// 一覧明細検索では｢仕入稟議｣は｢店舗補充｣とみなす（0を1に置き換え）
					bindVO = new BindInfoVO();
					bindVO.Value = Sinsei_sb_kbn_cd.Replace("0", "1");

					if (sTblnm.Equals("T10"))
					{
						// 単品レポートデータ
						sRepSql.Append(" AND 2	= :SINSEI_SB_KBN_" + sTblnm);

					}
					else if (sTblnm.Equals("T20"))
					{
						// 補充依頼データ
						sRepSql.Append(" AND 1	= :SINSEI_SB_KBN_" + sTblnm);

					}
					bindVO.BindId = "SINSEI_SB_KBN_" + sTblnm;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER; // 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				// 未申請データの場合
				// 明細項目も抽出条件に含むため
				else if (
					sTblnm.Equals("T11")
				|| sTblnm.Equals("T21")
				)
				{
					// ｢仕入稟議｣が選択された場合、該当条件は0件となる
					// ⇒区分コードに｢申請種別｣の1桁目を直に当てる（
					// ⇒⇒｢申請種別_仕入稟議｣が選択された場合、where (1 or 2) = 0となるため
					// 必ず0件となる

					bindVO = new BindInfoVO();
					bindVO.Value = Sinsei_sb_kbn_cd;

					if (sTblnm.Equals("T11"))
					{
						// 単品レポートデータ
						sRepSql.Append(" AND 2	= :SINSEI_SB_KBN_" + sTblnm);
					}
					else if (sTblnm.Equals("T21"))
					{
						// 補充依頼データ
						sRepSql.Append(" AND 1	= :SINSEI_SB_KBN_" + sTblnm);
					}
					bindVO.BindId = "SINSEI_SB_KBN_" + sTblnm;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER; // 1:文字列、2:数値
					bindList.Add(bindVO);

				}
				// 一覧画面集計データの場合（申請済データ ＋ 実績データ）
				// 明細画面項目による抽出は行わない
				else if (
					sTblnm.Equals("T12")
				|| sTblnm.Equals("T22")
				|| sTblnm.Equals("T23")
				)
				{ }
			}
			#endregion
			// 未申請データ（T11、T21）の場合のみ、明細画面項目の絞込みを行う。
			if (sTblnm.Equals("T11") || sTblnm.Equals("T21"))
			{
				#region [登録日FROM]
				if (!String.IsNullOrEmpty(f01VO.Add_ymd_from))
				{	// 未申請データの場合、登録日
					sRepSql.Append(" AND " + sTblnm + ".ADD_YMD	>= :ADD_YMD_FROM_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "ADD_YMD_FROM_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region [登録日TO]
				if (!String.IsNullOrEmpty(f01VO.Add_ymd_to))
				{
					// 未申請データの場合、登録日
					sRepSql.Append(" AND " + sTblnm + ".ADD_YMD	<= :ADD_YMD_TO_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "ADD_YMD_TO_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region [担当者コード]
				if (!String.IsNullOrEmpty(f01VO.Tantosya_cd))
				{
					// 未申請データの場合、登録担当者コード
					sRepSql.Append(" AND " + sTblnm + ".ADDTAN_CD = :ADD_TAN_CD_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "ADD_TAN_CD_" + sTblnm;
					bindVO.Value = f01VO.Tantosya_cd;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region [申請日FROM]
				if (!String.IsNullOrEmpty(f01VO.Apply_ymd_from))
				{
					// 未申請データの場合、集計抽出条件から除外する。
				}
				#endregion
				#region [申請日TO]
				if (!String.IsNullOrEmpty(f01VO.Apply_ymd_to))
				{
					// 未申請データの場合、集計抽出条件から除外する。
				}
				#endregion
				#region [依頼理由]
				// ※[申請種別]と連動、区分値はマスタから取得
				// 申請種別が店舗補充の場合
				if (ConditionSinsei_sb.VALUE_SINSEI_SB1.Equals(f01VO.Sinsei_sb))
				{	// 依頼理由から判断
					if (!String.IsNullOrEmpty(f01VO.Irairiyu_cd) && !f01VO.Irairiyu_cd.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						// 依頼理由
						sRepSql.Append(" AND " + sTblnm + ".IRAIRIYU_CD = :IRAIRIYU_CD_" + sTblnm);
						bindVO = new BindInfoVO();
						bindVO.BindId = "IRAIRIYU_CD_" + sTblnm;
						bindVO.Value = f01VO.Irairiyu_cd;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}
				}
				// 申請種別が単品レポートの場合
				else if(ConditionSinsei_sb.VALUE_SINSEI_SB2.Equals(f01VO.Sinsei_sb))
				{	// 依頼理由1から判断
					if (!String.IsNullOrEmpty(f01VO.Irairiyu_cd1) && !f01VO.Irairiyu_cd1.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
					{
						// 依頼理由
						sRepSql.Append(" AND " + sTblnm + ".IRAIRIYU_CD = :IRAIRIYU_CD_" + sTblnm);
						bindVO = new BindInfoVO();
						bindVO.BindId = "IRAIRIYU_CD_" + sTblnm;
						bindVO.Value = f01VO.Irairiyu_cd1;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}
				}
				#endregion
				#region [状態]
				// ※	-1:空白
				//		 1:未申請						
				//		 0:申請							
				//		10:納品依頼中							
				//		20:仕入先→ＬＣ							
				//		25:仕入先→店舗							
				//		30:ＬＣ仕入							
				//		40:出荷指示中							
				//		50:ＤＣ出荷							
				//		55:店舗出荷							
				//		90:店舗仕入／店舗入荷							
				//		95:欠品							
				//		96:没伝							
				//		98:却下							
				//		99:エラー							

				if (!String.IsNullOrEmpty(f01VO.Jotai_kbn) && !f01VO.Jotai_kbn.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					sRepSql.Append(" AND 1 = :JOTAI_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "JOTAI_" + sTblnm;
					bindVO.Value = f01VO.Jotai_kbn;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

				}
				#endregion
				#region [旧自社品番]
				if (!String.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					sRepSql.Append(" AND "+ sTblnm + ".JISYA_HBN = :JISYA_HBN_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "JISYA_HBN_" + sTblnm;
					//bindVO.Value = f01VO.Old_jisya_hbn;
					bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Dictionary[Ta080p01Constant.DIC_SEARCH_XEBIOCD].ToString());
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region [スキャンコード]
				if (!String.IsNullOrEmpty(f01VO.Scan_cd))
				{
					sRepSql.Append(" AND " + sTblnm + ".JAN_CD = :JAN_CD_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "JAN_CD_" + sTblnm;
					bindVO.Value = f01VO.Scan_cd;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
			}
			// モード「稟議結果照会」の場合、単品レポートデータの表示をしない
			if( BoSystemConstant.MODE_REF_RINGIKEKKA.Equals(f01VO.Modeno)
			&& sTblnm.Equals("T10"))
			{
				sRepSql.Append(" AND 0 = 1");
			}
		}
		#endregion

		#region 検索ボタン_検索条件設定_AddSql
		/// <summary>
		/// リンク先件数取得用SQL設定
		/// </summary>
		/// <param name="f01VO"></param>
		/// <param name="bindVO"></param>
		/// <param name="bindList"></param>
		/// <param name="sRepSql"></param>
		/// <param name="sTblnm"></param>
		public static void addSql(Ta080f01Form f01VO, BindInfoVO bindVO, ArrayList bindList, StringBuilder sRepSql, string sTblnm)
		{
			#region モード[申請]、[申請前修正]
			// [選択モードNo]が「申請」、「申請前修正」の場合、補充依頼申請TBL(MDOT0110)を検索
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_APPLY)
			|| f01VO.Modeno.Equals(BoSystemConstant.MODE_SINSEIMAEUPD)
			)
			{
				if (sTblnm.Equals("T13"))
				{
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T13.TENPO_CD");
					sRepSql.Append(" 	,TO_NUMBER(TO_CHAR(ADD_MONTHS(SYSDATE, 0), 'YYYYMM')) AS YOSAN_YMD");
					sRepSql.Append(" 	,'000000' AS YOSAN_CD");
					sRepSql.Append(" 	,T13.KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T13.UPD_YMD || LPAD(T13.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0110 T13");
					sRepSql.Append(" WHERE 0 = 0");

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm, 1);

					sRepSql.Append(" AND T13.KBN_CD		 = 2");		// 単品レポート
					sRepSql.Append(" AND T13.SHINSEI_FLG = 0");		// 未申請
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T13.TENPO_CD");
					sRepSql.Append(" 	,T13.KBN_CD");
				}
				else if (sTblnm.Equals("T24"))
				{
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T24.TENPO_CD");
					sRepSql.Append(" 	,TO_NUMBER(TO_CHAR(ADD_MONTHS(SYSDATE, 0), 'YYYYMM')) AS YOSAN_YMD");
					sRepSql.Append(" 	,M24.YOSAN_CD");
					sRepSql.Append(" 	,T24.KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T24.UPD_YMD || LPAD(T24.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0110 T24");
					sRepSql.Append(" LEFT JOIN");
					sRepSql.Append(" 	MDMT0130 M24");
					sRepSql.Append(" ON");
					sRepSql.Append(" 	M24.JAN_CD 	     = T24.JAN_CD");
					sRepSql.Append(" WHERE 0 = 0");

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm, 1);

					sRepSql.Append(" AND T24.KBN_CD		 = 1");	// 補充依頼 	
					sRepSql.Append(" AND T24.SHINSEI_FLG = 0");	// 未申請	
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T24.TENPO_CD");
					sRepSql.Append(" 	,M24.YOSAN_CD");
					sRepSql.Append(" 	,T24.KBN_CD");
				}
			}
			#endregion
			#region モード[申請取消]
			// [選択モードNo]が「申請取消」の場合、補充依頼確定TBL
			else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_SINSEIZUMITORIKESI))
			{
				if (sTblnm.Equals("T13"))
				{
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T13.TENPO_CD");
					sRepSql.Append(" 	,T13.YOSAN_YMD");
					sRepSql.Append(" 	,T13.YOSAN_CD");
					sRepSql.Append(" 	,T13.KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T13.UPD_YMD || LPAD(T13.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0120 T13");
					sRepSql.Append(" WHERE 0 = 0");

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm, 2);

					sRepSql.Append(" AND T13.KBN_CD			 = 2"); // 単品レポート
					sRepSql.Append(" AND T13.SOSINZUMI_FLG	 = 0"); // 未送信
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T13.TENPO_CD");
					sRepSql.Append(" 	,T13.YOSAN_YMD");
					sRepSql.Append(" 	,T13.YOSAN_CD");
					sRepSql.Append(" 	,T13.KBN_CD");
				}
				else if (sTblnm.Equals("T24"))
				{
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T24.TENPO_CD");
					sRepSql.Append(" 	,T24.YOSAN_YMD");
					sRepSql.Append(" 	,T24.YOSAN_CD");
					sRepSql.Append(" 	,T24.KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T24.UPD_YMD || LPAD(T24.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0120 T24");
					sRepSql.Append(" WHERE 0 = 0");

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm, 2);

					sRepSql.Append(" AND T24.KBN_CD			 = 1"); // 補充依頼
					sRepSql.Append(" AND T24.SOSINZUMI_FLG	 = 0"); // 未送信			
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T24.TENPO_CD");
					sRepSql.Append(" 	,T24.YOSAN_YMD");
					sRepSql.Append(" 	,T24.YOSAN_CD");
					sRepSql.Append(" 	,T24.KBN_CD");
				}

			}
			#endregion
			#region モード[登録履歴照会]
			// [選択モードNo]が「登録履歴照会」の場合、補充依頼申請TBL、補充依頼確定TBL
			else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_REF_TOROKURIREKI))
			{
				if (sTblnm.Equals("T13"))
				{
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T13.TENPO_CD");
					sRepSql.Append(" 	,T13.YOSAN_YMD");
					sRepSql.Append(" 	,T13.YOSAN_CD");
					sRepSql.Append(" 	,T13.KBN_CD");
					sRepSql.Append(" 	,SUM(T13.LINKED_ITEM_SU) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T13.LINKED_LAST_UPD_DATETIME) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" (");
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T131.TENPO_CD");
					sRepSql.Append(" 	,TO_NUMBER(TO_CHAR(ADD_MONTHS(SYSDATE, 0), 'YYYYMM')) AS YOSAN_YMD");
					sRepSql.Append(" 	,'000000' AS YOSAN_CD");
					sRepSql.Append(" 	,T131.KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T131.UPD_YMD || LPAD(T131.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0110 T131");
					sRepSql.Append(" WHERE 0 = 0");

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm + "1", 1);

					sRepSql.Append(" AND T131.KBN_CD	  = 2"); // 単品レポート 	
					sRepSql.Append(" AND T131.SHINSEI_FLG = 0"); // 未申請		
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T131.TENPO_CD");
					sRepSql.Append(" 	,T131.KBN_CD");

					sRepSql.Append(" UNION ALL");

					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T132.TENPO_CD");
					sRepSql.Append(" 	,T132.YOSAN_YMD");
					sRepSql.Append(" 	,T132.YOSAN_CD");
					sRepSql.Append(" 	,T132.KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T132.UPD_YMD || LPAD(T132.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0120 T132");
					sRepSql.Append(" WHERE 0 = 0");

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm + "2", 2);

					sRepSql.Append(" AND T132.KBN_CD		 = 2"); // 単品レポート
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T132.TENPO_CD");
					sRepSql.Append(" 	,T132.YOSAN_YMD");
					sRepSql.Append(" 	,T132.YOSAN_CD");
					sRepSql.Append(" 	,T132.KBN_CD");
					sRepSql.Append(" ) T13");
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T13.TENPO_CD");
					sRepSql.Append(" 	,T13.YOSAN_YMD");
					sRepSql.Append(" 	,T13.YOSAN_CD");
					sRepSql.Append(" 	,T13.KBN_CD");


				}
				else if (sTblnm.Equals("T24"))
				{
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T24.TENPO_CD");
					sRepSql.Append(" 	,T24.YOSAN_YMD");
					sRepSql.Append(" 	,T24.YOSAN_CD");
					sRepSql.Append(" 	,T24.KBN_CD");
					sRepSql.Append(" 	,SUM(T24.LINKED_ITEM_SU) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T24.LINKED_LAST_UPD_DATETIME) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" (");
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T241.TENPO_CD");
					sRepSql.Append(" 	,TO_NUMBER(TO_CHAR(ADD_MONTHS(SYSDATE, 0), 'YYYYMM')) AS YOSAN_YMD");
					sRepSql.Append(" 	,M241.YOSAN_CD");
					sRepSql.Append(" 	,T241.KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T241.UPD_YMD || LPAD(T241.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0110 T241");
					sRepSql.Append(" LEFT JOIN");
					sRepSql.Append(" 	MDMT0130 M241");
					sRepSql.Append(" ON");
					sRepSql.Append(" 	M241.JAN_CD 	 = T241.JAN_CD");
					sRepSql.Append(" WHERE 0 = 0");

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm + "1", 1);

					sRepSql.Append(" AND T241.KBN_CD	  = 1"); // 補充依頼 	 
					sRepSql.Append(" AND T241.SHINSEI_FLG = 0"); // 未申請	
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T241.TENPO_CD");
					sRepSql.Append(" 	,M241.YOSAN_CD");
					sRepSql.Append(" 	,T241.KBN_CD");

					sRepSql.Append(" UNION ALL");

					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T242.TENPO_CD");
					sRepSql.Append(" 	,T242.YOSAN_YMD");
					sRepSql.Append(" 	,T242.YOSAN_CD");
					sRepSql.Append(" 	,T242.KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T242.UPD_YMD || LPAD(T242.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0120 T242");
					sRepSql.Append(" WHERE 0 = 0");
					sRepSql.Append(" AND T242.KBN_CD			 = 1"); // 補充依頼

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm + "2", 2);

					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T242.TENPO_CD");
					sRepSql.Append(" 	,T242.YOSAN_YMD");
					sRepSql.Append(" 	,T242.YOSAN_CD");
					sRepSql.Append(" 	,T242.KBN_CD");
					sRepSql.Append(" ) T24");
					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T24.TENPO_CD");
					sRepSql.Append(" 	,T24.YOSAN_YMD");
					sRepSql.Append(" 	,T24.YOSAN_CD");
					sRepSql.Append(" 	,T24.KBN_CD");
				}
			}
			#endregion
			#region モード[稟議結果照会]
			// [選択モードNo]が「稟議結果照会」の場合、店舗補充実績TBL(H)
			else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_REF_RINGIKEKKA))
			{
				// 単品レポートデータの場合
				if (sTblnm.Equals("T13"))
				{
					// 実績データに単品レポートデータは存在しない
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	NULL as TENPO_CD");
					sRepSql.Append(" 	,NULL AS YOSAN_YMD");
					sRepSql.Append(" 	,NULL AS YOSAN_CD");
					sRepSql.Append(" 	,0    AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,NULL AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM DUAL");
				}
				// 補充依頼データの場合
				else if (sTblnm.Equals("T24"))
				{
					sRepSql.Append(" SELECT");
					sRepSql.Append(" 	T241.TENPO_CD");
					sRepSql.Append(" 	,T241.YOSAN_YMD");
					sRepSql.Append(" 	,T241.YOSAN_CD");
					sRepSql.Append(" 	,1 AS KBN_CD");
					sRepSql.Append(" 	,COUNT(*) AS LINKED_ITEM_SU");
					sRepSql.Append(" 	,MAX(T242.UPD_YMD || LPAD(T242.UPD_TM, 9, 0)) AS LINKED_LAST_UPD_DATETIME");
					sRepSql.Append(" FROM");
					sRepSql.Append(" 	MDOT0130 T241");
					sRepSql.Append(" INNER JOIN");
					sRepSql.Append(" 	MDOT0131 T242");
					sRepSql.Append(" ON");
					sRepSql.Append(" 	T242.TENPO_CD = T241.TENPO_CD");
					sRepSql.Append(" AND T242.YOSAN_YMD = T241.YOSAN_YMD");
					sRepSql.Append(" AND T242.YOSAN_CD = T241.YOSAN_CD");
					sRepSql.Append(" WHERE 0 = 0");

					Ta080p01Util.addMeisaiWhere(f01VO, bindVO, bindList, sRepSql, sTblnm + "2", 3);

					sRepSql.Append(" GROUP BY");
					sRepSql.Append(" 	T241.TENPO_CD");
					sRepSql.Append(" 	,T241.YOSAN_YMD");
					sRepSql.Append(" 	,T241.YOSAN_CD");
				}
			}
			#endregion
		}

		#endregion

		#region 明細画面検索条件_一覧画面項目
		/// <summary>
		/// 明細画面検索条件_一覧画面項目
		/// 検索条件設定
		/// </summary>
		/// <param name="f01VO"></param>
		/// <param name="bindVO"></param>
		/// <param name="bindList"></param>
		/// <param name="sRepSql"></param>
		/// <param name="sTblnm"></param>
		/// <param name="iTblKbn">1：補充依頼申請TBL / 2：補充依頼確定TBL / 3：店舗補充実績TBL </param>
		/// <param name="iActionKbn">1：一覧画面検索処理 / 2：一覧画面リンク処理 / 3：一覧画面排他処理 </param>
		public static void addMeisaiWhere(Ta080f01Form f01VO, Ta080f01M1Form f01MVO, BindInfoVO bindVO, ArrayList bindList, StringBuilder sRepSql, string sTblnm, int iTblKbn, int iActionKbn)
		{
			string sWkTblnm = "";
			#region [店舗コード]
			sRepSql.Append(" AND " + sTblnm + ".TENPO_CD  = :TENPO_CD_" + sTblnm);
			bindVO = new BindInfoVO();
			bindVO.BindId = "TENPO_CD_" + sTblnm;
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			#endregion

			#region 一覧画面_検索処理（リンク先情報取得）の場合
			if (iActionKbn == 1)
			{
				#region [年月度FROM]
				if (!string.IsNullOrEmpty(f01VO.Yosan_ymd_from))
				{
					// ※未申請データは システム日付とぶつける
					if (sTblnm.Equals("T13")
						|| sTblnm.Equals("T131")
						|| sTblnm.Equals("T24")
						|| sTblnm.Equals("T241")
					)
					{
						sRepSql.Append(" AND TO_NUMBER(TO_CHAR(ADD_MONTHS(SYSDATE, 0), 'YYYYMM')) >= :YOSAN_YMD_FROM_" + sTblnm);
					}
					else
					{
						sRepSql.Append(" AND " + sTblnm + ".YOSAN_YMD >= :YOSAN_YMD_FROM_" + sTblnm);
					}
					bindVO = new BindInfoVO();
					bindVO.BindId = "YOSAN_YMD_FROM_" + sTblnm;
					bindVO.Value = f01VO.Yosan_ymd_from.Substring(0, 6);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region [年月度TO]
				if (!string.IsNullOrEmpty(f01VO.Yosan_ymd_to))
				{
					// ※未申請データは システム日付とぶつける
					if (sTblnm.Equals("T13")
						|| sTblnm.Equals("T131")
						|| sTblnm.Equals("T24")
						|| sTblnm.Equals("T241")
					)
					{
						sRepSql.Append(" AND TO_NUMBER(TO_CHAR(ADD_MONTHS(SYSDATE, 0), 'YYYYMM')) <= :YOSAN_YMD_TO_" + sTblnm);
					}
					else
					{
						sRepSql.Append(" AND " + sTblnm + ".YOSAN_YMD <= :YOSAN_YMD_TO_" + sTblnm);
					}
					bindVO = new BindInfoVO();
					bindVO.BindId = "YOSAN_YMD_TO_" + sTblnm;
					bindVO.Value = f01VO.Yosan_ymd_to.Substring(0, 6);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region [仕入枠ｸﾞﾙｰﾌﾟｺｰﾄﾞFROM]
				if (!string.IsNullOrEmpty(f01VO.Yosan_cd_from))
				{
					// ※単品レポートデータは "000000"とぶつける
					if (sTblnm.Substring(0, 3).Equals("T13"))
					{
						sRepSql.Append(" AND '000000' >= :YOSAN_CD_FROM_" + sTblnm);
					}
					// 補充依頼データ
					else
					{
						// 補充依頼かつ補充依頼申請TBL参照の場合、
						if (iTblKbn == 1)
						{
							sWkTblnm = sTblnm.Replace("T", "M");
						}
						else
						{
							sWkTblnm = sTblnm;
						}
						sRepSql.Append(" AND " + sWkTblnm + ".YOSAN_CD 	>= :YOSAN_CD_FROM_" + sTblnm);
					}
					bindVO = new BindInfoVO();
					bindVO.BindId = "YOSAN_CD_FROM_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatYosan_Cd(f01VO.Yosan_cd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region [仕入枠ｸﾞﾙｰﾌﾟｺｰﾄﾞTO]
				if (!string.IsNullOrEmpty(f01VO.Yosan_cd_to))
				{
					// ※単品レポートデータは "000000"とぶつける
					if (sTblnm.Substring(0, 3).Equals("T13"))
					{
						sRepSql.Append(" AND '000000' <= :YOSAN_CD_TO_" + sTblnm);
					}
					else
					{
						// 補充依頼かつ補充依頼申請TBL参照の場合、
						if (iTblKbn == 1)
						{
							sWkTblnm = sTblnm.Replace("T", "M");
						}
						else
						{
							sWkTblnm = sTblnm;
						}
						sRepSql.Append(" AND " + sWkTblnm + ".YOSAN_CD 	<= :YOSAN_CD_TO_" + sTblnm);
					}
					bindVO = new BindInfoVO();
					bindVO.BindId = "YOSAN_CD_TO_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatYosan_Cd(f01VO.Yosan_cd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region [申請種別] 区分コード部分（1桁目）
				// （-1:空白／11:店舗補充／20:単品レポート／02:仕入稟議)
				if (!string.IsNullOrEmpty(f01VO.Sinsei_sb) && !f01VO.Sinsei_sb.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 申請種別_区分コード部分（1桁目）
					string Sinsei_sb_kbn_cd = f01VO.Sinsei_sb.Substring(0, 1);

					// 店舗補充実績TBLの場合、抽出条件から除外する
					if (iTblKbn != 3)
					{
						bindVO = new BindInfoVO();
						// 補充依頼申請TBLの場合
						if(iTblKbn == 1)
						{
							// 補充依頼申請TBL. 区分コード = [申請種別]の1桁目
							sRepSql.Append(" AND " + sTblnm + ".KBN_CD = :SINSEI_SB_KBN_" + sTblnm);
							bindVO.Value = Sinsei_sb_kbn_cd;
						}
						// 補充依頼確定TBLの場合
						else if(iTblKbn == 2)
						{
							// 補充依頼確定TBL. 区分コード = [申請種別]の1桁目
							sRepSql.Append(" AND " + sTblnm + ".KBN_CD = :SINSEI_SB_KBN_" + sTblnm);
							bindVO.Value = Sinsei_sb_kbn_cd;
						}
						bindVO.BindId = "SINSEI_SB_KBN_" + sTblnm;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}
				}
				#endregion
			}
			#endregion
			#region 一覧画面_リンク処理（明細画面遷移）の場合
			else if (iActionKbn == 2)
			{
				#region 選択行.年月度
				// 補充依頼申請TBLの場合、抽出条件から除外
				if (iTblKbn != 1)
				{
					sRepSql.Append(" AND " + sTblnm + ".YOSAN_YMD  = :M1_YOSAN_YMD_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "M1_YOSAN_YMD_" + sTblnm;
					bindVO.Value = f01MVO.M1yosan_ymd;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region 選択行.仕入枠グループコード
				// 選択行が単品レポートデータの場合、抽出条件から除外
				if (!f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString().Equals(Ta080p01Constant.KBN_KBN_CD_TANPINREPORT))
				{
					// 補充依頼かつ補充依頼申請TBL参照の場合、
					if (iTblKbn == 1)
					{
						sWkTblnm = sTblnm.Substring(0, 2).Replace("T", "M");
					}
					else
					{
						sWkTblnm = sTblnm;
					}
					sRepSql.Append(" AND " + sWkTblnm + ".YOSAN_CD  = :M1_YOSAN_CD_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "M1_YOSAN_CD_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatYosan_Cd(f01MVO.Dictionary[Ta080p01Constant.DIC_M1YOSAN_CD].ToString());
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region 選択行.区分コード
				// 店舗補充実績TBLの場合、抽出条件から除外
				if (iTblKbn != 3)
				{
					sRepSql.Append(" AND " + sTblnm + ".KBN_CD  = :M1_KBN_CD_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "M1_KBN_CD_" + sTblnm;
					bindVO.Value = f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString();
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
			}
			#endregion
			#region 一覧画面_排他処理の場合
			else if (iActionKbn == 3)
			{
				if(iTblKbn == 1){
					sRepSql.AppendLine(" AND " + sTblnm + ".SHINSEI_FLG = 0");
				}
				else if (iTblKbn == 2)
				{

					sRepSql.AppendLine(" AND " + sTblnm + ".SOSINZUMI_FLG = 0");
				}
				#region 選択行.年月度
				// 補充依頼申請TBLの場合、抽出条件から除外
				if (iTblKbn != 1)
				{
					sRepSql.Append(" AND " + sTblnm + ".YOSAN_YMD  = :M1_YOSAN_YMD_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "M1_YOSAN_YMD_" + sTblnm;
					bindVO.Value = f01MVO.M1yosan_ymd;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region 選択行.仕入枠グループコード
				// 店舗補充実績TBLの場合、抽出条件から除外
				if (iTblKbn != 3)
				{
					// 補充依頼申請BLの場合
					if(iTblKbn == 1){
						sRepSql.AppendLine();
						sRepSql.AppendLine(" AND (	2 = " + sTblnm + ".KBN_CD");
						sRepSql.AppendLine(" 		OR");
						sRepSql.AppendLine(" 		EXISTS( SELECT 1 FROM MDMT0130 M1	/* 発注MST */");
						sRepSql.AppendLine(" 				WHERE");
						sRepSql.AppendLine(" 					M1.JAN_CD = " + sTblnm + ".JAN_CD");
						sRepSql.AppendLine(" 				AND M1.YOSAN_CD = :M1_YOSAN_CD_" + sTblnm);
						sRepSql.AppendLine(" 	))							/* 仕入枠グループコード ※単品レポートの場合は対象外 */");

						bindVO = new BindInfoVO();
						bindVO.BindId = "M1_YOSAN_CD_" + sTblnm;
						bindVO.Value = BoSystemFormat.formatYosan_Cd(f01MVO.Dictionary[Ta080p01Constant.DIC_M1YOSAN_CD].ToString());
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						bindVO = new BindInfoVO();
					}
					// 補充依頼確定TBLの場合
					else if (iTblKbn == 2)
					{
						sRepSql.Append(" AND " + sTblnm + ".YOSAN_CD  = :M1_YOSAN_CD_" + sTblnm);
						bindVO = new BindInfoVO();
						bindVO.BindId = "M1_YOSAN_CD_" + sTblnm;
						bindVO.Value = BoSystemFormat.formatYosan_Cd(f01MVO.Dictionary[Ta080p01Constant.DIC_M1YOSAN_CD].ToString());
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}
				}
				#endregion
				#region 選択行.区分コード
				// 店舗補充実績TBLの場合、抽出条件から除外
				if (iTblKbn != 3)
				{
					sRepSql.Append(" AND " + sTblnm + ".KBN_CD  = :M1_KBN_CD_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "M1_KBN_CD_" + sTblnm;
					bindVO.Value = f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString();
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion

			}
			#endregion

			#region [申請種別] 補充稟議区分部分（2桁目）
			if (!string.IsNullOrEmpty(f01VO.Sinsei_sb) && !f01VO.Sinsei_sb.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				// 店舗補充実績TBLの場合のみ抽出条件とする
				if (iTblKbn == 3)
				{
					// 申請種別_補充稟議区分部分（2桁目）
					string Sinsei_sb_hojuringi_kbn = f01VO.Sinsei_sb.Substring(1, 1);
					sRepSql.Append(" AND " + sTblnm + ".HOJURINGI_KBN = :HOJURINGI_KBN_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "HOJURINGI_KBN_" + sTblnm;
					bindVO.Value = Sinsei_sb_hojuringi_kbn;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}
			#endregion
			#region [登録日FROM]
			if (!String.IsNullOrEmpty(f01VO.Add_ymd_from))
			{
				// 店舗補充実績TBLの場合、抽出条件の対象外とする
				if (iTblKbn != 3)
				{
					// 補充依頼申請TBLの場合、登録日
					if (iTblKbn == 1)
					{
						sRepSql.Append(" AND " + sTblnm + ".ADD_YMD	>= :ADD_YMD_FROM_" + sTblnm);
					}
					// 補充依頼確定TBLの場合、HHT登録日
					else if (iTblKbn == 2)
					{
						sRepSql.Append(" AND " + sTblnm + ".HHTADD_YMD	>= :ADD_YMD_FROM_" + sTblnm);
					}
					bindVO = new BindInfoVO();
					bindVO.BindId = "ADD_YMD_FROM_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}
			#endregion
			#region [登録日TO]
			if (!String.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				// 店舗補充実績TBLの場合、抽出条件の対象外とする
				if (iTblKbn != 3)
				{
					// 補充依頼申請TBLの場合、登録日
					if (iTblKbn == 1)
					{
						sRepSql.Append(" AND " + sTblnm + ".ADD_YMD <= :ADD_YMD_TO_" + sTblnm);
					}
					// 補充依頼確定TBLの場合、HHT登録日
					else if (iTblKbn == 2)
					{
						sRepSql.Append(" AND " + sTblnm + ".HHTADD_YMD <= :ADD_YMD_TO_" + sTblnm);
					}
					bindVO = new BindInfoVO();
					bindVO.BindId = "ADD_YMD_TO_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}
			#endregion
			#region [担当者コード]
			if (!String.IsNullOrEmpty(f01VO.Tantosya_cd))
			{
				// 補充依頼申請TBLの場合、登録担当者コード
				if (iTblKbn == 1)
				{
					sRepSql.Append(" AND " + sTblnm + ".ADDTAN_CD = :ADD_TAN_CD_" + sTblnm);
				}
				// 補充依頼確定TBLの場合、HHT登録担当者コード
				else if (iTblKbn == 2)
				{
					sRepSql.Append(" AND " + sTblnm + ".HHTADDTAN_CD = :ADD_TAN_CD_" + sTblnm);
				}
				// 店舗補充実績TBLの場合、担当者コード
				else if (iTblKbn == 3)
				{
					sRepSql.Append(" AND " + sTblnm + ".TANTOSYA_CD = :ADD_TAN_CD_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "ADD_TAN_CD_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Tantosya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region [申請日FROM]
			if (!String.IsNullOrEmpty(f01VO.Apply_ymd_from))
			{
				// 補充依頼申請TBLの場合、抽出条件から除外
				if (iTblKbn != 1)
				{
					// 補充依頼確定TBLの場合、申請日
					// 店舗補充実績TBLの場合、申請日
					sRepSql.Append(" AND " + sTblnm + ".APPLY_YMD >= :APPLY_YMD_FROM_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "APPLY_YMD_FROM_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Apply_ymd_from);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}
			#endregion
			#region [申請日TO]
			if (!String.IsNullOrEmpty(f01VO.Apply_ymd_to))
			{
				// 補充依頼申請TBLの場合、抽出条件から除外
				if (iTblKbn != 1)
				{
					// 補充依頼確定TBLの場合、申請日
					// 店舗補充実績TBLの場合、申請日
					sRepSql.Append(" AND " + sTblnm + ".APPLY_YMD <= :APPLY_YMD_TO_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "APPLY_YMD_TO_" + sTblnm;
					bindVO.Value = BoSystemFormat.formatDate(f01VO.Apply_ymd_to);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}
			#endregion
			#region [依頼理由]
			// ※[申請種別]と連動、区分値はマスタから取得
			if(!String.IsNullOrEmpty(f01VO.Sinsei_sb) 
			&& f01VO.Sinsei_sb.Equals(ConditionSinsei_sb.VALUE_SINSEI_SB1)
			&& !String.IsNullOrEmpty(f01VO.Irairiyu_cd) 
			&& !f01VO.Irairiyu_cd.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				// 依頼理由_補充依頼
				sRepSql.Append(" AND " + sTblnm + ".IRAIRIYU_CD = :IRAIRIYU_CD_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "IRAIRIYU_CD_" + sTblnm;
				bindVO.Value = f01VO.Irairiyu_cd;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}
			else if(!String.IsNullOrEmpty(f01VO.Sinsei_sb) 
			&& f01VO.Sinsei_sb.Equals(ConditionSinsei_sb.VALUE_SINSEI_SB2)
			&& !String.IsNullOrEmpty(f01VO.Irairiyu_cd1) 
			&& !f01VO.Irairiyu_cd1.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				// 依頼理由_単品レポート
				sRepSql.Append(" AND " + sTblnm + ".IRAIRIYU_CD = :IRAIRIYU_CD_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "IRAIRIYU_CD_" + sTblnm;
				bindVO.Value = f01VO.Irairiyu_cd1;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region [状態]
			// ※	-1:空白 
			//		 1:未申請
			//		 0:申請
			//		10:納品依頼中
			//		20:仕入先→ＬＣ
			//		25:仕入先→店舗
			//		30:ＬＣ仕入
			//		40:出荷指示中
			//		50:ＤＣ出荷
			//		55:店舗出荷
			//		90:店舗仕入／店舗入荷
			//		95:欠品
			//		96:没伝
			//		98:却下
			//		99:エラー
			if (!String.IsNullOrEmpty(f01VO.Jotai_kbn) && !f01VO.Jotai_kbn.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				// 補充依頼申請TBLの場合、
				if (iTblKbn == 1)
				{
					sRepSql.Append(" AND 1 = :JOTAI_" + sTblnm);
				}
				// 補充依頼確定TBLの場合、
				else if (iTblKbn == 2)
				{
					sRepSql.Append(" AND 0 = :JOTAI_" + sTblnm);
				}
				// 店舗補充実績TBLの場合
				else if (iTblKbn == 3)
				{
					sRepSql.Append(" AND " + sTblnm + ".JOTAI_KBN = :JOTAI_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "JOTAI_" + sTblnm;
				bindVO.Value = f01VO.Jotai_kbn;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region [旧自社品番]
			if (!String.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{
				sRepSql.Append(" AND " + sTblnm + ".JISYA_HBN = :JISYA_HBN_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "JISYA_HBN_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Dictionary[Ta080p01Constant.DIC_SEARCH_XEBIOCD].ToString());
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region [スキャンコード]
			if (!String.IsNullOrEmpty(f01VO.Scan_cd))
			{
				sRepSql.Append(" AND " + sTblnm + ".JAN_CD = :JAN_CD_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "JAN_CD_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatScmCd(f01VO.Scan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
		}

		#region 一覧検索用
		/// <summary>
		/// 一覧画面_検索処理_検索条件設定
		/// </summary>
		/// <param name="f01VO"></param>
		/// <param name="bindVO"></param>
		/// <param name="bindList"></param>
		/// <param name="sRepSql"></param>
		/// <param name="sTblnm"></param>
		/// <param name="iTblKbn">1：補充依頼申請TBL / 2：補充依頼確定TBL / 3：店舗補充実績TBL </param>
		public static void addMeisaiWhere(Ta080f01Form f01VO, BindInfoVO bindVO, ArrayList bindList, StringBuilder sRepSql, string sTblnm, int iTblKbn)
		{
			addMeisaiWhere(f01VO, null, bindVO, bindList, sRepSql, sTblnm, iTblKbn, 1);
		}
		#endregion

		#endregion

		#region 明細画面検索条件_明細画面項目
		public static void addMeisaiWhere2(Ta080f03Form f03VO,BindInfoVO bindVO, ArrayList bindList, StringBuilder sRepSql, string sTblnm, int iTblKbn)
		{
			string sWkTblnm = "";
			string sWkItemnm = "";

//			sRepSql.AppendLine().AppendLine(" /* テスト** 以下明細画面項目条件 ***テスト */ "); ;
			#region 部門コードFROM
			if (!String.IsNullOrEmpty(f03VO.Bumon_cd_from))
			{
				sRepSql.Append(" AND " + sTblnm + ".BUMON_CD >= :BUMON_CD_FROM_M_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BUMON_CD_FROM_M_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatBumonCd(f03VO.Bumon_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region 部門コードTO
			if (!String.IsNullOrEmpty(f03VO.Bumon_cd_to))
			{
				sRepSql.Append(" AND " + sTblnm + ".BUMON_CD <= :BUMON_CD_TO_M_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BUMON_CD_TO_M_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatBumonCd(f03VO.Bumon_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region 品種
			sRepSql.Append(" AND " + sTblnm + ".HINSYU_CD IN (");
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd1))
			{
				sRepSql.Append("1, ");
			}
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd2))
			{
				sRepSql.Append("2, ");
			}
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd3))
			{
				sRepSql.Append("3, ");
			}
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd4))
			{
				sRepSql.Append("4, ");
			}
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd5))
			{
				sRepSql.Append("5, ");
			}
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd6))
			{
				sRepSql.Append("6, ");
			}
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd7))
			{
				sRepSql.Append("7, ");
			}
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd8))
			{
				sRepSql.Append("8, ");
			}
			if (BoSystemConstant.CHECKBOX_ON.Equals(f03VO.Hinsyu_cd9))
			{
				sRepSql.Append("9, ");
			}
			sRepSql.Append("-1)");

			#endregion
			#region ブランドコード
			if (!String.IsNullOrEmpty(f03VO.Burando_cd))
			{
				sRepSql.Append(" AND " + sTblnm + ".BURANDO_CD = :BURANDO_CD_M_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "BURANDO_CD_M_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatBrandCd(f03VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region 旧自社品番
			if (!String.IsNullOrEmpty(f03VO.Old_jisya_hbn))
			{
				sRepSql.Append(" AND " + sTblnm + ".JISYA_HBN = :JISYA_HBN_M_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "JISYA_HBN_M_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatJisyaHbn(f03VO.Dictionary[Ta080p01Constant.DIC_SEARCH_XEBIOCD].ToString());
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region スキャンコード
			if (!String.IsNullOrEmpty(f03VO.Scan_cd))
			{
				sRepSql.Append(" AND " + sTblnm + ".JAN_CD = :JAN_CD_M_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "JAN_CD_M_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatScmCd(f03VO.Scan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region 登録日FROM
			if (!String.IsNullOrEmpty(f03VO.Add_ymd_from))
			{
				// 補充依頼申請TBLの場合、登録日
				if (iTblKbn == 1)
				{
					sRepSql.Append(" AND " + sTblnm + ".ADD_YMD	>= :ADD_YMD_FROM_M_" + sTblnm);
				}
				// 補充依頼確定TBLの場合、HHT登録日
				else if (iTblKbn == 2)
				{
					sRepSql.Append(" AND " + sTblnm + ".HHTADD_YMD	>= :ADD_YMD_FROM_M_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "ADD_YMD_FROM_M_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatDate(f03VO.Add_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region 登録日TO
			if (!String.IsNullOrEmpty(f03VO.Add_ymd_to))
			{
				// 補充依頼申請TBLの場合、登録日
				if (iTblKbn == 1)
				{
					sRepSql.Append(" AND " + sTblnm + ".ADD_YMD <= :ADD_YMD_TO_M_" + sTblnm);
				}
				// 補充依頼確定TBLの場合、HHT登録日
				else if (iTblKbn == 2)
				{
					sRepSql.Append(" AND " + sTblnm + ".HHTADD_YMD <= :ADD_YMD_TO_M_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "ADD_YMD_TO_M_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatDate(f03VO.Add_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

			}

			#endregion
			#region 登録担当者
			if (!String.IsNullOrEmpty(f03VO.Tantosya_cd))
			{
				// 補充依頼申請TBLの場合、登録担当者コード
				if (iTblKbn == 1)
				{
					sRepSql.Append(" AND " + sTblnm + ".ADDTAN_CD = :ADD_TAN_CD_M_" + sTblnm);
				}
				// 補充依頼確定TBLの場合、HHT登録担当者コード
				else if (iTblKbn == 2)
				{
					sRepSql.Append(" AND " + sTblnm + ".HHTADDTAN_CD = :ADD_TAN_CD_M_" + sTblnm);
				}
				bindVO = new BindInfoVO();
				bindVO.BindId = "ADD_TAN_CD_M_" + sTblnm;
				bindVO.Value = BoSystemFormat.formatTantoCd(f03VO.Tantosya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion
			#region 依頼理由
			if (Ta080p01Constant.FLG_ON.ToString().Equals(f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG].ToString()))
			{
				if (!String.IsNullOrEmpty(f03VO.Irairiyu_cd2)
				&& !f03VO.Irairiyu_cd2.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 依頼理由_補充依頼
					sRepSql.Append(" AND " + sTblnm + ".IRAIRIYU_CD = :IRAIRIYU_CD_M_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "IRAIRIYU_CD_M_" + sTblnm;
					bindVO.Value = f03VO.Irairiyu_cd2;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}
			else
			{
				if (!String.IsNullOrEmpty(f03VO.Irairiyu_cd1)
				&& !f03VO.Irairiyu_cd1.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
				{
					// 依頼理由_単品レポート
					sRepSql.Append(" AND " + sTblnm + ".IRAIRIYU_CD = :IRAIRIYU_CD_M_" + sTblnm);
					bindVO = new BindInfoVO();
					bindVO.BindId = "IRAIRIYU_CD_M_" + sTblnm;
					bindVO.Value = f03VO.Irairiyu_cd1;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			#endregion
			#region 店評価
			if (!String.IsNullOrEmpty(f03VO.Hyoka_kb_mise)
			&& !f03VO.Hyoka_kb_mise.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				if (iTblKbn == 1)
				{
					sWkTblnm = "T2";
					sWkItemnm = ".HYOKA_KB";
				}
				else
				{
					sWkTblnm = sTblnm;
					sWkItemnm = ".TEN_HYOKA_KB";
				}
				sRepSql.Append(" AND " + sWkTblnm + sWkItemnm+ " = :TEN_HYOKA_KB_M_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "TEN_HYOKA_KB_M_" + sTblnm;
				bindVO.Value = ChgHyokaKbCondToDB(f03VO.Hyoka_kb_mise);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
			#region 全評価
			if (!String.IsNullOrEmpty(f03VO.Hyoka_kb_all)
			&& !f03VO.Hyoka_kb_all.Equals(BoSystemConstant.DROPDOWNLIST_MISENTAKU))
			{
				if (iTblKbn == 1)
				{
					sWkTblnm = "T3";
					sWkItemnm = ".HYOKA_KB";
				}
				else
				{
					sWkTblnm = sTblnm;
					sWkItemnm = ".ALL_HYOKA_KB";
				}
				sRepSql.Append(" AND " + sWkTblnm + sWkItemnm + " = :ALL_HYOKA_KB_M_" + sTblnm);
				bindVO = new BindInfoVO();
				bindVO.BindId = "ALL_HYOKA_KB_M_" + sTblnm;
				bindVO.Value = ChgHyokaKbCondToDB(f03VO.Hyoka_kb_all);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}
			#endregion
		}
		#endregion 

		#region 明細画面検索ソート条件
		public static void addMeisaiSort(Ta080f03Form f03VO, StringBuilder sRepSql, string sTblnm, Boolean bLinkFlg)
		{
			if (bLinkFlg)
			{
				//  1:「商品順」「昇順」
				// 14:「登録日」「昇順」
				// 13:「担当者」「昇順」

				addMeisaiSort("1", Ta080p01Constant.KBN_SORTOPTION1, sRepSql, sTblnm);
				addMeisaiSort("14", Ta080p01Constant.KBN_SORTOPTION1, sRepSql, sTblnm);
				addMeisaiSort("13", Ta080p01Constant.KBN_SORTOPTION1, sRepSql, sTblnm);
			}
			else
			{
				addMeisaiSort(f03VO.Sortkb1, f03VO.Sortoptionkb1, sRepSql, sTblnm);
				addMeisaiSort(f03VO.Sortkb2, f03VO.Sortoptionkb2, sRepSql, sTblnm);
				addMeisaiSort(f03VO.Sortkb3, f03VO.Sortoptionkb3, sRepSql, sTblnm);
			}

		}
		#endregion

		#region 明細画面検索ソート条件設定

		public static void addMeisaiSort(string sortkb, string sortoptionkb, StringBuilder sRepSql, string sTblnm)
		{
			String[] sortItems = new String[0];

			switch (sortkb)
			{
				case "1": sortItems = Ta080p01Constant.KBN_SORT_1.Split(',');
					break;
				case "2": sortItems = Ta080p01Constant.KBN_SORT_2.Split(',');
					break;
				case "3": sortItems = Ta080p01Constant.KBN_SORT_3.Split(',');
					break;
				case "4": sortItems = Ta080p01Constant.KBN_SORT_4.Split(',');
					break;
				case "5": sortItems = Ta080p01Constant.KBN_SORT_5.Split(',');
					break;
				case "6": sortItems = Ta080p01Constant.KBN_SORT_6.Split(',');
					break;
				case "7": sortItems = Ta080p01Constant.KBN_SORT_7.Split(',');
					break;
				case "8": sortItems = Ta080p01Constant.KBN_SORT_8.Split(',');
					break;
				case "9": sortItems = Ta080p01Constant.KBN_SORT_9.Split(',');
					break;
				case "10": sortItems = Ta080p01Constant.KBN_SORT_10.Split(',');
					break;
				case "11": sortItems = Ta080p01Constant.KBN_SORT_11.Split(',');
					break;
				case "12": sortItems = Ta080p01Constant.KBN_SORT_12.Split(',');
					break;
				case "13": sortItems = Ta080p01Constant.KBN_SORT_13.Split(',');
					break;
				case "14": sortItems = Ta080p01Constant.KBN_SORT_14.Split(',');
					break;
				case "15": sortItems = Ta080p01Constant.KBN_SORT_15.Split(',');
					break;
				default:
					break;
			}

			for (int i = 0; i < sortItems.Length; i++)
			{
				if (sRepSql.Length == 0)
				{
					sRepSql.Append(" ORDER BY ");
				}
				else
				{
					sRepSql.Append(", ");
				}

				sRepSql.Append(sTblnm + ".");
				sRepSql.Append(sortItems[i]);

				// 昇順/降順
				if (sortoptionkb.Equals(ConditionSortoption.VALUE_SORTOPTION1))
				{
					sRepSql.Append(Ta080p01Constant.KBN_SORTOPTION1);
				}
				else if (sortoptionkb.Equals(ConditionSortoption.VALUE_SORTOPTION2))
				{
					sRepSql.Append(Ta080p01Constant.KBN_SORTOPTION2);
				}
			}
		}
		#endregion

		#region 明細転記処理
		/// <summary>
		/// 明細画面転記処理
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="result"></param>
		/// <param name="f01VO"></param>
		/// <param name="f01MVO"></param>
		/// <param name="m1List"></param>
		/// <returns></returns>
		public static decimal[] DoMeisaiCopy(IFacadeContext facadeContext, IList<Hashtable> result, Ta080f01Form f01VO, Ta080f01M1Form f01MVO, IDataList m1List)
		{
			decimal dIraiSum = 0;	// 合計依頼数量
			decimal dKinSum = 0;	// 合計原価金額
			int iCnt = 0;

			// システム日付取得
			SysDateVO sysDateVO = new SysDateVO();
			sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

			#region モード[稟議結果照会]の場合（実績明細画面）
			if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_REF_RINGIKEKKA))
			{
				foreach (Hashtable rec in result)
				{
					iCnt++;
					Ta080f02M1Form f02MVO = new Ta080f02M1Form();
					#region 明細転記
					f02MVO.M1rowno = iCnt.ToString();																	// Ｍ１行NO
					if (rec["APPLY_YMD"].ToString().Equals("0"))
					{
						f02MVO.M1apply_ymd = "";																		// Ｍ１申請日 yymmdd
					}
					else
					{
						f02MVO.M1apply_ymd = BoSystemFormat.formatDate_yyMMdd(rec["APPLY_YMD"].ToString());				// Ｍ１申請日 yymmdd
					}
					f02MVO.M1sinsei_sb = rec["SINSEI_SB"].ToString();													// Ｍ１申請種別
					f02MVO.M1hanbaiin_cd = rec["TANTOSYA_CD"].ToString();												// Ｍ１登録担当者コード
					f02MVO.M1hanbaiin_nm = rec["HANBAIIN_NM"].ToString();												// Ｍ１登録担当者名
					f02MVO.M1irai_riyu = rec["IRAIRIYU_NM"].ToString();													// Ｍ１依頼理由
					f02MVO.M1bumon_cd = rec["BUMON_CD"].ToString();														// Ｍ１部門コード
					f02MVO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();												// Ｍ１部門カナ名
					f02MVO.M1hinsyu_cd = rec["HINSYU_CD"].ToString();													// Ｍ１品種コード
					f02MVO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();										// Ｍ１品種名略称
					f02MVO.M1burando_nm = rec["BURANDO_NMK"].ToString();												// Ｍ１ブランド名
					f02MVO.M1jisya_hbn = rec["JISYA_HBN"].ToString();													// Ｍ１自社品番
					f02MVO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();											// Ｍ１商品属性
					f02MVO.M1maker_hbn = rec["HIN_NBR"].ToString();														// Ｍ１メーカー品番
					f02MVO.M1syonmk = rec["SYONMK"].ToString();															// Ｍ１商品名(カナ)
					f02MVO.M1iro_nm = rec["IRO_NM"].ToString();															// Ｍ１色
					f02MVO.M1size_nm = rec["SIZE_NM"].ToString();														// Ｍ１サイズ
					f02MVO.M1scan_cd = rec["JAN_CD"].ToString();														// Ｍ１スキャンコード
					if (rec["NYUKAYOTEI_YMD"].ToString().Equals("0"))
					{
						f02MVO.M1nyukayotei_ymd = "";																	// Ｍ１入荷予定日 yyyy/mm/dd
					}
					else
					{
						f02MVO.M1nyukayotei_ymd = rec["NYUKAYOTEI_YMD"].ToString();										// Ｍ１入荷予定日 yyyy/mm/dd
					}
					f02MVO.M1season_nm = rec["SEASON_NM"].ToString();													// Ｍ１シーズン
					f02MVO.M1hanbaikanryo_ymd = BoSystemFormat.formatDate_yyMMdd(rec["HANBAIKANRYO_YMD"].ToString());	// Ｍ１販売完了日 yymmdd
					f02MVO.M1apply_su = rec["APPLY_SU"].ToString();														// Ｍ１申請数
					f02MVO.M1apply_kin = rec["APPLY_KIN"].ToString();													// Ｍ１申請金額
					f02MVO.M1jisseki_su = rec["JISSEKI_SU"].ToString();													// Ｍ１実績数
					f02MVO.M1jisseki_kin = rec["JISSEKI_KIN"].ToString();												// Ｍ１実績金額
					f02MVO.M1jotai_kbn_nm = rec["JOTAI_NM"].ToString();													// Ｍ１状態
					f02MVO.M1comment_nm = rec["COMMENT_NM"].ToString();													// Ｍ１コメント
					#endregion
					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f02MVO, true);
				}
			}
			#endregion

			#region モード[稟議結果照会]以外の場合（明細画面）
			else
			{
				foreach (Hashtable rec in result)
				{
					iCnt++;
					Ta080f03M1Form f03MVO = new Ta080f03M1Form();
					#region 明細転記
					f03MVO.M1rowno = iCnt.ToString();																			// Ｍ１行NO
					f03MVO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();														// Ｍ１部門カナ名
					f03MVO.M1ten_hyoka_kb = rec["TEN_HYOKA_KB"].ToString();														// Ｍ１店評価
					f03MVO.M1all_hyoka_kb = rec["ALL_HYOKA_KB"].ToString();														// Ｍ１全評価
					f03MVO.M1tosyu_uriage_su = rec["TOSYU_URIAGE_SU"].ToString();												// Ｍ１当週売
					f03MVO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();												// Ｍ１品種略名称
					f03MVO.M1zensyu_uriage_su = rec["ZENSYU_URIAGE_SU"].ToString();												// Ｍ１前売
					f03MVO.M1zenzensyu_uriage_su = rec["ZENZENSYU_URIAGE_SU"].ToString();										// Ｍ１前々売
					f03MVO.M1burando_nm = rec["BURANDO_NMK"].ToString();														// Ｍ１ブランド名
					f03MVO.M1nyukayotei_su = rec["NYUKAYOTEI_SU"].ToString();													// Ｍ１入荷
					f03MVO.M1tenzaiko_su = rec["TENZAIKO_SU"].ToString();														// Ｍ１在庫
					f03MVO.M1jido_su = rec["JIDO_SU"].ToString();																// Ｍ１自動定数
					f03MVO.M1haibunkano_su = rec["HAIBUNKANO_SU"].ToString();													// Ｍ１配分可能数
					f03MVO.M1jisya_hbn = rec["JISYA_HBN"].ToString();															// Ｍ１自社品番
					f03MVO.M1keikaku_ymd = BoSystemFormat.formatDate_yyyyMM(rec["HANBAIKANRYO_YMD"].ToString());				// Ｍ１計画期間 販売完了日の期末の月 yyyymm
					f03MVO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();													// Ｍ１商品属性
					f03MVO.M1lot_su = rec["LOT_SU"].ToString();																	// Ｍ１ロット数
					f03MVO.M1maker_hbn = rec["HIN_NBR"].ToString();																// Ｍ１メーカー品番
					f03MVO.M1syonmk = rec["SYONMK"].ToString();																	// Ｍ１商品名(カナ)
					f03MVO.M1iro_nm = rec["IRO_NM"].ToString();																	// Ｍ１色
					f03MVO.M1size_nm = rec["SIZE_NM"].ToString();																// Ｍ１サイズ
					f03MVO.M1scan_cd = rec["JAN_CD"].ToString();																// Ｍ１スキャンコード 
					f03MVO.M1irai_su = rec["IRAI_SU"].ToString();																// Ｍ１依頼数量
					f03MVO.M1genkakin = rec["IRAI_KIN"].ToString();																// Ｍ１原価金額
					f03MVO.M1hanbaiin_nm = rec["HANBAIIN_NM"].ToString();														// Ｍ１登録担当者名
					if (f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString().Equals(Ta080p01Constant.KBN_KBN_CD_HOJUIRAI))
					{
						f03MVO.M1irairiyu_cd1 = rec["IRAIRIYU_CD"].ToString();													// Ｍ１依頼理由コード（補充依頼）
					}
					else
					{
						f03MVO.M1irairiyu_cd2 = rec["IRAIRIYU_CD"].ToString();													// Ｍ１依頼理由コード（単品レポート）
					}
					f03MVO.M1add_ymd = BoSystemFormat.formatDate_yyMMdd(rec["ADD_YMD"].ToString());								// Ｍ１登録日 yymmdd
					f03MVO.M1hanbaikanryo_ymd = BoSystemFormat.formatDate_yyMMdd(rec["HANBAIKANRYO_YMD"].ToString());			// Ｍ１販売完了日 yymmdd
					f03MVO.M1irai_su_hdn = rec["IRAI_SU"].ToString();															// Ｍ１依頼数量(隠し)
					if (f01MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD].ToString().Equals(Ta080p01Constant.KBN_KBN_CD_HOJUIRAI))
					{
						f03MVO.M1irairiyu_cd_hdn1 = rec["IRAIRIYU_CD"].ToString();												// Ｍ１依頼理由コード(隠し)（補充依頼）
					}
					else
					{
						f03MVO.M1irairiyu_cd_hdn2 = rec["IRAIRIYU_CD"].ToString();												// Ｍ１依頼理由コード(隠し)（単品レポート）
					}
					f03MVO.M1gen_tnk = rec["GEN_TNK"].ToString();																// Ｍ１原単価(隠し)
					f03MVO.M1genkakin_hdn = rec["IRAI_KIN"].ToString();															// Ｍ１原価金額(隠し)
					f03MVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;													// Ｍ１選択フラグ(隠し)
					f03MVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;												// Ｍ１確定処理フラグ(隠し)
					f03MVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;													// Ｍ１明細色区分(隠し)

					// 未申請データの場合
					if (Ta080p01Constant.TBLID_HOJUIARI_SINSEI.Equals(rec["TBL_NM"].ToString()))
					{
						// 過去4週売上を設定(メッセージの判定に使用)
						f03MVO.M1uriage_su_hdn = rec["URIAGE_SU"].ToString();
						// 発注メッセージ取得、Dictionaryにメッセージ区分設定
						f03MVO.M1hatchu_msg = Ta080p01Util.GetHtms(f03MVO, sysDateVO);
					}
					// 申請済データの場合
					else
					{
						f03MVO.M1hatchu_msg = rec["MESSEGE_NM"].ToString();
					}																											// Ｍ１発注メッセージ

					#region 明細Dictionary

					// 店舗コード
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1TENPO_CD] = rec["TENPO_CD"].ToString();
					// 区分コード
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD] = rec["KBN_CD"].ToString();
					// 処理日付 
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1SYORI_YMD] = rec["SYORI_YMD"].ToString();
					// 管理№ 
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1KANRI_NO] = rec["KANRI_NO"].ToString();
					// 行№ 
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1GYO_NO] = rec["GYO_NO"].ToString();
					// 更新日
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1UPD_YMD] = rec["UPD_YMD"].ToString();
					// 更新時間
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1UPD_TM] = rec["UPD_TM"].ToString();
					// 当初売価
					f03MVO.Dictionary[Ta080p01Constant.DIC_M1TOSYOBAIKA_TNK] = rec["TOSYOBAIKA_TNK"].ToString();

					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						f03MVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;									// Ｍ１明細色区分(隠し)
					}
					else
					{
						f03MVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;										// Ｍ１明細色区分(隠し)
					}

					#region 各項色変更フラグ設定
					// 計画期間
					// 計画期間を過ぎている場合は文字色を青とする。
					if (Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1keikaku_ymd, "0")) < Convert.ToDecimal(BoSystemFormat.formatDate_yyyyMM(sysDateVO.Sysdate.ToString())))
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1KEIKAKU_YMD] = Ta080p01Constant.FLG_ON;
					}
					else
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1KEIKAKU_YMD] = Ta080p01Constant.FLG_OFF;
					}
					// スキャンコード
					// 担当者名
					// [選択モードNo]が「申請」かつ同一商品が存在する場合、文字を青色表示。
					if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_APPLY)
					&& Convert.ToDecimal(BoSystemString.Nvl(rec["CHOHUKU_ITEM_SU"].ToString(), "0")) > 1)
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1SCAN_CD] = Ta080p01Constant.FLG_ON;
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIIN_NM] = Ta080p01Constant.FLG_ON;
					}
					else
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1SCAN_CD] = Ta080p01Constant.FLG_OFF;
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIIN_NM] = Ta080p01Constant.FLG_OFF;
					}

					// 依頼数
					// 数量が基準値を超える場合、フォントカラーを青色にする。
					// 基準値（過去2週の売上×5個以上）
					if (Convert.ToDecimal(f03MVO.M1irai_su) >= (Convert.ToDecimal(f03MVO.M1tosyu_uriage_su) + Convert.ToDecimal(f03MVO.M1zensyu_uriage_su)) * 5)
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1IRAI_SU] = Ta080p01Constant.FLG_ON;
					}
					else
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1IRAI_SU] = Ta080p01Constant.FLG_OFF;
					}

					// 販売完了日
					// システム日付の＋7日以内の場合赤色表示
					if (Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1hanbaikanryo_ymd, "0")) <= Convert.ToDecimal(BoSystemFormat.formatDate_yyMMdd(BoSystemFormat.formatDate(BoSystemDate.toDatetime(BoSystemFormat.formatDate(sysDateVO.Sysdate)).AddDays(7).ToString()))))
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIKANRYO_YMD] = Ta080p01Constant.FLG_ON;
					}
					else
					{
						f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIKANRYO_YMD] = Ta080p01Constant.FLG_OFF;
					}
					#endregion

					#endregion

					#endregion 

					// 合計値加算
					dIraiSum += Convert.ToDecimal(f03MVO.M1irai_su);				// Ｍ１依頼数量の合計
					dKinSum += Convert.ToDecimal(f03MVO.M1genkakin);				// Ｍ１原価金額の合計

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f03MVO, true);
				}
			}
			#endregion
			return new decimal[] { dIraiSum, dKinSum };
		}
		#endregion

		#region 明細転記処理
		/// <summary>
		/// 明細画面転記処理
		/// </summary>
		/// <param name="facadeContext"></param>
		/// <param name="result"></param>
		/// <param name="f01VO"></param>
		/// <param name="f01MVO"></param>
		/// <param name="m1List"></param>
		/// <returns></returns>
		public static void DoMstMeisaiCopy(IFacadeContext facadeContext, Ta080f03M1Form f03MVO, Hashtable rec)
		{

			// システム日付取得
			SysDateVO sysDateVO = new SysDateVO();
			sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

			#region 明細転記
			//f03MVO.M1rowno = iCnt.ToString();											// Ｍ１行NO
			f03MVO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();						// Ｍ１部門カナ名
			f03MVO.M1ten_hyoka_kb = rec["TEN_HYOKA"].ToString();						// Ｍ１店評価
			f03MVO.M1all_hyoka_kb = rec["ALL_HYOKA"].ToString();						// Ｍ１全評価
			f03MVO.M1tosyu_uriage_su = rec["URI_SU_TOU"].ToString();					// Ｍ１当週売
			f03MVO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();				// Ｍ１品種略名称
			f03MVO.M1zensyu_uriage_su = rec["URI_SU_1TH"].ToString();					// Ｍ１前売
			f03MVO.M1zenzensyu_uriage_su = rec["URI_SU_2TH"].ToString();				// Ｍ１前々売
			f03MVO.M1burando_nm = rec["BURANDO_NMK"].ToString();						// Ｍ１ブランド名
			f03MVO.M1nyukayotei_su = rec["NYUKA_SU"].ToString();						// Ｍ１入荷
			f03MVO.M1tenzaiko_su = rec["REAL_SU"].ToString();							// Ｍ１在庫
			f03MVO.M1jido_su = rec["JIDO_SU"].ToString();								// Ｍ１自動定数
			f03MVO.M1haibunkano_su = rec["HAIBUNKANO_SU"].ToString();					// Ｍ１配分可能数
			f03MVO.M1jisya_hbn = rec["XEBIO_CD"].ToString();							// Ｍ１自社品番
			f03MVO.M1keikaku_ymd = rec["KEIKAKU_YMD"].ToString();						// Ｍ１計画期間 販売完了日の期末の月 yyyymm
			f03MVO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();					// Ｍ１商品属性
			f03MVO.M1lot_su = rec["MOTOMIYALOT_SU"].ToString();							// Ｍ１ロット数
			f03MVO.M1maker_hbn = rec["HIN_NBR"].ToString();								// Ｍ１メーカー品番
			f03MVO.M1syonmk = rec["SYONMK"].ToString();									// Ｍ１商品名(カナ)
			f03MVO.M1iro_nm = rec["IRO_NM"].ToString();									// Ｍ１色
			f03MVO.M1size_nm = rec["SIZE_NM"].ToString();								// Ｍ１サイズ
			f03MVO.M1scan_cd = rec["JAN_CD"].ToString();								// Ｍ１スキャンコード 
			f03MVO.M1irai_su = rec[OpenTm040p01Cls.COLUMN_INPUT_SURYO].ToString();		// Ｍ１依頼数量
			f03MVO.M1genkakin = (Convert.ToDecimal(f03MVO.M1irai_su) * Convert.ToDecimal(rec["GENKA"])).ToString();
																						// Ｍ１原価金額
			//f03MVO.M1hanbaiin_nm = rec["HANBAIIN_NM"].ToString();						// Ｍ１登録担当者名
			//if (kbnCd.Equals(Ta080p01Constant.KBN_KBN_CD_HOJUIRAI))
			//{
			//	f03MVO.M1irairiyu_cd1 = rec["IRAIRIYU_CD"].ToString();					// Ｍ１依頼理由コード（補充依頼）
			//}
			//else
			//{
			//	f03MVO.M1irairiyu_cd2 = rec["IRAIRIYU_CD"].ToString();					// Ｍ１依頼理由コード（単品レポート）
			//}
			//f03MVO.M1add_ymd = BoSystemFormat.formatDate_yyMMdd(rec["ADD_YMD"].ToString());								// Ｍ１登録日 yymmdd
			f03MVO.M1hanbaikanryo_ymd = BoSystemFormat.formatDate_yyMMdd(rec["HANBAIKANRYO_YMD"].ToString());
																						// Ｍ１販売完了日 yymmdd
			f03MVO.M1irai_su_hdn = rec[OpenTm040p01Cls.COLUMN_INPUT_SURYO].ToString();									// Ｍ１依頼数量(隠し)
			//if (kbnCd.Equals(Ta080p01Constant.KBN_KBN_CD_HOJUIRAI))
			//{
			//	f03MVO.M1irairiyu_cd_hdn1 = rec["IRAIRIYU_CD"].ToString();				// Ｍ１依頼理由コード(隠し)（補充依頼）
			//}
			//else
			//{
			//	f03MVO.M1irairiyu_cd_hdn2 = rec["IRAIRIYU_CD"].ToString();				// Ｍ１依頼理由コード(隠し)（単品レポート）
			//}
			f03MVO.M1gen_tnk = rec["GENKA"].ToString();									// Ｍ１原単価(隠し)
			f03MVO.M1genkakin_hdn = f03MVO.M1genkakin;									// Ｍ１原価金額(隠し)

			f03MVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;					// Ｍ１選択フラグ(隠し)
			f03MVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;				// Ｍ１確定処理フラグ(隠し)
			f03MVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;					// Ｍ１明細色区分(隠し)


			// 過去4週売上を設定(メッセージの判定に使用)
			f03MVO.M1uriage_su_hdn = rec["URI_SU"].ToString();
			// 発注メッセージ取得
			f03MVO.M1hatchu_msg = Ta080p01Util.GetHtms(f03MVO, sysDateVO);				// Ｍ１発注メッセージ
			#endregion

			#region 明細Dictionary

			//// 店舗コード
			//f03MVO.Dictionary[Ta080p01Constant.DIC_M1TENPO_CD] = rec["TENPO_CD"].ToString();
			//// 区分コード
			//f03MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD] = rec["KBN_CD"].ToString();
			//// 処理日付 
			//f03MVO.Dictionary[Ta080p01Constant.DIC_M1SYORI_YMD] = rec["SYORI_YMD"].ToString();
			//// 管理№ 
			//f03MVO.Dictionary[Ta080p01Constant.DIC_M1KANRI_NO] = rec["KANRI_NO"].ToString();
			//// 行№ 
			//f03MVO.Dictionary[Ta080p01Constant.DIC_M1GYO_NO] = rec["GYO_NO"].ToString();
			//// 更新日
			//f03MVO.Dictionary[Ta080p01Constant.DIC_M1UPD_YMD] = rec["UPD_YMD"].ToString();
			//// 更新時間
			//f03MVO.Dictionary[Ta080p01Constant.DIC_M1UPD_TM] = rec["UPD_TM"].ToString();
			// 当初売価
			f03MVO.Dictionary[Ta080p01Constant.DIC_M1TOSYOBAIKA_TNK] = rec["TOSYOBAIKA_TNK"].ToString();
			#endregion

			#region 各項色変更フラグ設定
			// 計画期間
			// 計画期間を過ぎている場合は文字色を青とする。
			if (Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1keikaku_ymd, "0")) < Convert.ToDecimal(BoSystemFormat.formatDate_yyyyMM(sysDateVO.Sysdate.ToString())))
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1KEIKAKU_YMD] = Ta080p01Constant.FLG_ON;
			}
			else
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1KEIKAKU_YMD] = Ta080p01Constant.FLG_OFF;
			}
			
			f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1SCAN_CD] = Ta080p01Constant.FLG_OFF;
			f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIIN_NM] = Ta080p01Constant.FLG_OFF;

			// 依頼数
			// 数量が基準値を超える場合、フォントカラーを青色にする。
			// 基準値（過去2週の売上×5個以上）
			if (Convert.ToDecimal(f03MVO.M1irai_su) >= (Convert.ToDecimal(f03MVO.M1tosyu_uriage_su) + Convert.ToDecimal(f03MVO.M1zensyu_uriage_su)) * 5)
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1IRAI_SU] = Ta080p01Constant.FLG_ON;
			}
			else
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1IRAI_SU] = Ta080p01Constant.FLG_OFF;
			}

			// 販売完了日
			// システム日付の7日以降の場合赤色表示
			if (Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1hanbaikanryo_ymd, "0")) <= Convert.ToDecimal(BoSystemFormat.formatDate_yyMMdd(BoSystemFormat.formatDate(BoSystemDate.toDatetime(BoSystemFormat.formatDate(sysDateVO.Sysdate)).AddDays(7).ToString()))))
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIKANRYO_YMD] = Ta080p01Constant.FLG_ON;
			}
			else
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_IROFLG_M1_M1HANBAIKANRYO_YMD] = Ta080p01Constant.FLG_OFF;
			}
			#endregion

		}
		#endregion

		#region 発注メッセージ取得
		/// <summary>
		/// 未申請データ発注メッセージ取得
		/// </summary>
		/// <param name="Ta080f03M1Form">f02m1VO</param>
		/// <returns>発注メッセージ</returns>
		public static string GetHtms(Ta080f03M1Form f03MVO, SysDateVO sysDateVO)
		{
			string sHtms = "";
			// [Ｍ１自動定数]＞0の場合、"本部配分"固定
			if (Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1jido_su, "0")) > 0)
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB] = Ta080p01Constant.HTMS_HONBU_KB;
				sHtms = Ta080p01Constant.HTMS_HONBU;
			}
			// [Ｍ１店在庫数]＞0 かつ [Ｍ１売上実績数（過去4週売上）＜＝0 の場合、"売上実績なし"固定
			else if (Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1tenzaiko_su, "0")) > 0
				  && Convert.ToDecimal(f03MVO.M1uriage_su_hdn) <= 0)
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB] = Ta080p01Constant.HTMS_URI_KB;
				sHtms = Ta080p01Constant.HTMS_URI;
			}
			// [Ｍ１依頼数量]＞0かつ[Ｍ１依頼数量]＜＝（[Ｍ１入荷予定数]）の場合、"入荷予定あり"固定
			else if (Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1irai_su, "0")) >  0 &&
					 Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1irai_su, "0")) <= Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1nyukayotei_su, "0")))
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB] = Ta080p01Constant.HTMS_NYU_KB;
				sHtms = Ta080p01Constant.HTMS_NYU;
			}
			//[Ｍ１販売完了日]＜＝システム日付＋7の場合、"販売完了間近"
			else if (Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1hanbaikanryo_ymd, "0")) <=	Convert.ToDecimal(																BoSystemFormat.formatDate(
																										BoSystemDate.toDatetime(
																											BoSystemFormat.formatDate(
																												sysDateVO.Sysdate)
																											).AddDays(7)
																										.ToString()
																									).Substring(2, 6)
																								)
					&& Convert.ToDecimal(sysDateVO.Sysdate.ToString().Substring(2, 6)) <= Convert.ToDecimal(BoSystemString.Nvl(f03MVO.M1hanbaikanryo_ymd, "0"))
				)
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB] = Ta080p01Constant.HTMS_HANKAN_MADIKA_KB;
				sHtms = Ta080p01Constant.HTMS_HANKAN_MADIKA;
			}
			//[Ｍ１店評価]が空白の場合、"自店舗未展開"
			else if (String.IsNullOrEmpty(f03MVO.M1ten_hyoka_kb))
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB] = Ta080p01Constant.HTMS_JITENPO_MITENKAI_KB;
				sHtms = Ta080p01Constant.HTMS_JITENPO_MITENKAI;
			}
			//[Ｍ１店評価]="-"の場合、"投入直後"
			else if ((Ta080p01Constant.KBN_HYOKA_HYPHEN).Equals(f03MVO.M1ten_hyoka_kb))
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB] = Ta080p01Constant.HTMS_TONYUTYOKUGO_KB;
				sHtms = Ta080p01Constant.HTMS_TONYUTYOKUGO;
			}			
			//その他の場合、空白固定
			else
			{
				f03MVO.Dictionary[Ta080p01Constant.DIC_M1MESSEGE_KB] = 0m;
				sHtms = "";
			}

			return sHtms;
		}
		#endregion

		#region 現在行数取得
		/// <summary>
		/// 現在行数取得
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <returns>現在行数</returns>
		public static int GetRowCnt(IDataList m1List)
		{
			// 現在行数
			int curRowCnt = 0;
			// 後方から検索
			for (int i = m1List.Count - 1; i >= 0; i--)
			{
				// 行オブジェクト取得
				Ta080f03M1Form F03MVO = (Ta080f03M1Form)m1List[i];

				// スキャンコード　または　依頼数に入力がある場合
				if (!string.IsNullOrEmpty(F03MVO.M1scan_cd)
				 || !string.IsNullOrEmpty(F03MVO.M1irai_su))
				{
					curRowCnt = i + 1;
					break;
				}
			}
			return curRowCnt;
		}
		#endregion

		#region 排他処理
		/// <summary>
		/// 明細リンク先の最新更新日時とリンク先件数を元に排他チェックを行う。
		/// </summary>
		/// <param name="updYmd">更新日付(未存在時は-1を設定)</param>
		/// <param name="updTm">更新時間</param>
		/// <param name="itemSu">リンク先件数</param>
		/// <param name="facadeContext">IFacadeContext</param>
		/// <param name="tableId">テーブル名</param>
		/// <param name="pSql">SQL文</param>
		/// <param name="bindList">バインド情報VOのリスト</param>
		/// <param name="haitaF">排他フラグ</param>
		/// <param name="item">エラー反転項目ID</param>
		/// <param name="num">行番号</param>
		/// <param name="index">明細のインデックス</param>
		/// <param name="meisaiid">明細ID</param>
		/// <param name="dispRow">表示件数</param>
		/// <returns></returns>
		public static Boolean CheckHaitaMaxVal_local(
						decimal updYmd,
						decimal updTm,
						decimal itemSu,
						IFacadeContext facadeContext,
						string tableId,
						string pSql,
						ArrayList bindList,
						int haitaF,
						string[] item,
						string num,
						string index,
						string meisaiid,
						int dispRow
		){
			string MESSEGEID_HAITAERR = "E169";
			Boolean bRtn = false;

			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TA080P01-07", facadeContext.DBContext);

			// テーブルIDの追加
			BoSystemSql.AddSql(reader, "ADD_TABLEID", tableId);
			// 追加の条件
			BoSystemSql.AddSql(reader, "ADD_WHERE", pSql, bindList);
			// FOR UPDATE の追加
			if (haitaF == 1)
			{
				BoSystemSql.AddSql(reader, "ADD_FORUPDATE", "FOR UPDATE NOWAIT");
			}

			// SQL実行
			IList<Hashtable> ItemList = null;
			try
			{
				ItemList = reader.Execute();
			}
			catch (OracleException oe)
			{
				string oraErr = BoSystemDb.GetOraErrToException(oe.Message);
				if (oraErr.Equals(BoSystemConstant.HAITA_NOWAIT_ERR))
				{
					// 排他エラーの場合、処理終了
					ErrMsgCls.AddErrMsg(MESSEGEID_HAITAERR, string.Empty, facadeContext, item, num, index, meisaiid, dispRow);
					return false;
				}
				else
				{
                    throw;
                }
			}

			if (ItemList.Count == 0)
			{
				// 排他エラーの場合、処理終了
				ErrMsgCls.AddErrMsg(MESSEGEID_HAITAERR, string.Empty, facadeContext, item, num, index, meisaiid, dispRow);
				bRtn = false;
			}
			else
			{
				// 取得した更新日付、時間、明細件数とパラメータの更新日付、時間、リンク先件数を比較
				Hashtable htItem = (Hashtable)ItemList[0];
				decimal dbUpdYmd = (decimal)htItem["UPD_YMD"];
				decimal dbUpdTm = (decimal)htItem["UPD_TM"];
				decimal dbItemSu = (decimal)htItem["CNT"];

				if (dbUpdYmd != updYmd || dbUpdTm != updTm || dbItemSu != itemSu)
				{
					// 排他エラーの場合、処理終了
					ErrMsgCls.AddErrMsg(MESSEGEID_HAITAERR, string.Empty, facadeContext, item, num, index, meisaiid, dispRow);
					bRtn = false;
				}
				else
				{
					bRtn = true;
				}
			}
			return bRtn;
		}
		#endregion 

		#region キー項目バインド設定
		/// <summary>
		/// 補充依頼申請TBLキー項目（店舗コード、区分コード、処理日、管理№、行№）のWhere条件設定
		/// </summary>
		/// <param name="f03MVO"></param>
		/// <param name="bindVO"></param>
		/// <param name="bindList"></param>
		/// <param name="sRepSql"></param>
		public static void setKeyMdot0110(Ta080f03M1Form f03MVO, BindInfoVO bindVO, ArrayList bindList, StringBuilder sRepSql)
		{
			sRepSql.AppendLine(" AND T1.TENPO_CD = :TENPO_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "TENPO_CD";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1TENPO_CD];
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			sRepSql.AppendLine(" AND T1.KBN_CD = :KBN_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "KBN_CD";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			sRepSql.AppendLine(" AND T1.SYORI_YMD = :SYORI_YMD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "SYORI_YMD";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1SYORI_YMD];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			sRepSql.AppendLine(" AND T1.KANRI_NO = :KANRI_NO");
			bindVO = new BindInfoVO();
			bindVO.BindId = "KANRI_NO";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1KANRI_NO];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			sRepSql.AppendLine(" AND T1.GYO_NO = :GYO_NO");
			bindVO = new BindInfoVO();
			bindVO.BindId = "GYO_NO";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1GYO_NO];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);
		}

		/// <summary>
		/// 補充依頼確定TBLキー項目（店舗コード、区分コード、処理日、管理№、行№）のWhere条件設定
		/// </summary>
		/// <param name="f03MVO"></param>
		/// <param name="bindVO"></param>
		/// <param name="bindList"></param>
		/// <param name="sRepSql"></param>
		public static void setKeyMdot0120(Ta080f03M1Form f03MVO, BindInfoVO bindVO, ArrayList bindList, StringBuilder sRepSql)
		{
			sRepSql.AppendLine(" AND T1.TENPO_CD = :TENPO_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "TENPO_CD";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1TENPO_CD];
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			sRepSql.AppendLine(" AND T1.KBN_CD = :KBN_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "KBN_CD";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1KBN_CD];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			sRepSql.AppendLine(" AND T1.SYORI_YMD = :SYORI_YMD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "SYORI_YMD";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1SYORI_YMD];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			sRepSql.AppendLine(" AND T1.KANRI_NO = :KANRI_NO");
			bindVO = new BindInfoVO();
			bindVO.BindId = "KANRI_NO";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1KANRI_NO];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			sRepSql.AppendLine(" AND T1.GYO_NO = :GYO_NO");
			bindVO = new BindInfoVO();
			bindVO.BindId = "GYO_NO";
			bindVO.Value = (String)f03MVO.Dictionary[Ta080p01Constant.DIC_M1GYO_NO];
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);
		}

		#endregion

		#region 補充依頼申請TBL未申請
		public static void setFlgMdot0110Mishinsei(FindSqlResultTable reader, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// 更新項目バインド変数の値を設定
			// 申請状態			:"0"
			reader.BindValue("BIND_SHINSEI_FLG", Ta080p01Constant.FLG_OFF);
			// 更新日			:システム日付(YYYYMMDD)
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間			:システム時刻(HH24MISSFF3)
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード	:ログイン情報.担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日			:システム日付(YYYYMMDD)
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ		:"0"
			reader.BindValue("BIND_SAKUJYO_FLG", Ta080p01Constant.FLG_OFF);
			// 抽出申請状態		:"1"
			reader.BindValue("BIND_WHERE_SHINSEI_FLG", Ta080p01Constant.FLG_ON);
		}
		#endregion

		#region 補充依頼申請TBL申請
		public static void setFlgMdot0110Shinsei(FindSqlResultTable reader, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// 更新項目バインド変数の値を設定
			// 申請状態			:"1"
			reader.BindValue("BIND_SHINSEI_FLG", Ta080p01Constant.FLG_ON);
			// 更新日			:システム日付(YYYYMMDD)
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間			:システム時刻(HH24MISSFF3)
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード	:ログイン情報.担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日			:システム日付(YYYYMMDD)
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ		:"1"
			reader.BindValue("BIND_SAKUJYO_FLG", Ta080p01Constant.FLG_ON);
			// 抽出申請状態		:"0"
			reader.BindValue("BIND_WHERE_SHINSEI_FLG", Ta080p01Constant.FLG_OFF);
		}
		#endregion

		#region 補充依頼申請TBL修正
		public static void setFlgMdot0110Shusei(FindSqlResultTable reader, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			// 更新項目バインド変数の値を設定
			// 申請状態			:"0"
			reader.BindValue("BIND_SHINSEI_FLG", Ta080p01Constant.FLG_OFF);
			// 更新日			:システム日付(YYYYMMDD)
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間			:システム時刻(HH24MISSFF3)
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード	:ログイン情報.担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日			:システム日付(YYYYMMDD)
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ		:"0"
			reader.BindValue("BIND_SAKUJYO_FLG", Ta080p01Constant.FLG_OFF);
			// 抽出申請状態		:"0"
			reader.BindValue("BIND_WHERE_SHINSEI_FLG", Ta080p01Constant.FLG_OFF);
		}
		#endregion

		#region 補充依頼申請TBL編集項目設定
		public static void addUpdMdot0110(Ta080f03Form f03VO,Ta080f03M1Form f03MVO, BindInfoVO bindVO, ArrayList bindList, StringBuilder sRepSql)
		{
			// 依頼理由コード	補充・仕入稟議検索-明細	Ｍ１依頼理由コード
			sRepSql.AppendLine(" ,IRAIRIYU_CD = :IRAIRIYU_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "IRAIRIYU_CD";
			string v_IRAIRIYU_CD = "";
			if("000000".Equals(f03VO.Yosan_cd))
			{
				v_IRAIRIYU_CD = f03MVO.M1irairiyu_cd2;
			}
			else
			{
				v_IRAIRIYU_CD = f03MVO.M1irairiyu_cd1;
			}
			bindVO.Value = BoSystemString.Nvl(v_IRAIRIYU_CD, "0");
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 部門コード		補充・仕入稟議検索-明細(Dictionary)	Ｍ１部門コード		
			sRepSql.AppendLine(" ,BUMON_CD = :BUMON_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "BUMON_CD";
			bindVO.Value = f03MVO.Dictionary[Ta080p01Constant.DIC_M1BUMON_CD].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
	
			// 品種コード		補充・仕入稟議検索-明細(Dictionary)	Ｍ１品種コード		
			sRepSql.AppendLine(" ,HINSYU_CD = :HINSYU_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "HINSYU_CD";
			bindVO.Value = f03MVO.Dictionary[Ta080p01Constant.DIC_M1HINSYU_CD].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// ブランドコード	補充・仕入稟議検索-明細(Dictionary)	Ｍ１ブランドコード
			sRepSql.AppendLine(" ,BURANDO_CD = :BURANDO_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "BURANDO_CD";
			bindVO.Value = f03MVO.Dictionary[Ta080p01Constant.DIC_M1BURANDO_CD].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 自社品番			補充・仕入稟議検索-明細				Ｍ１自社品番		
			sRepSql.AppendLine(" ,JISYA_HBN = :JISYA_HBN");
			bindVO = new BindInfoVO();
			bindVO.BindId = "JISYA_HBN";
			bindVO.Value = f03MVO.M1jisya_hbn;
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 色コード			補充・仕入稟議検索-明細(Dictionary)	Ｍ１色コード		
			sRepSql.AppendLine(" ,IRO_CD = :IRO_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "IRO_CD";
			bindVO.Value = f03MVO.Dictionary[Ta080p01Constant.DIC_M1IRO_CD].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// サイズコード		補充・仕入稟議検索-明細(Dictionary)	Ｍ１サイズコード	
			sRepSql.AppendLine(" ,SIZE_CD = :SIZE_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "SIZE_CD";
			bindVO.Value = f03MVO.Dictionary[Ta080p01Constant.DIC_M1SIZE_CD].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// サイズ名			補充・仕入稟議検索-明細				Ｍ１サイズ			
			sRepSql.AppendLine(" ,SIZE_NM = :SIZE_NM");
			bindVO = new BindInfoVO();
			bindVO.BindId = "SIZE_NM";
			bindVO.Value = f03MVO.M1size_nm;
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// ＪＡＮコード		補充・仕入稟議検索-明細				Ｍ１スキャンコード
			sRepSql.AppendLine(" ,JAN_CD = :JAN_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "JAN_CD";
			bindVO.Value = f03MVO.M1scan_cd;
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 商品コード		補充・仕入稟議検索-明細(Dictionary)	Ｍ１商品コード		
			sRepSql.AppendLine(" ,SYOHIN_CD = :SYOHIN_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "SYOHIN_CD";
			bindVO.Value = f03MVO.Dictionary[Ta080p01Constant.DIC_M1SYOHIN_CD].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// メーカー品番		補充・仕入稟議検索-明細				Ｍ１メーカー品番	
			sRepSql.AppendLine(" ,HIN_NBR = :HIN_NBR");
			bindVO = new BindInfoVO();
			bindVO.BindId = "HIN_NBR";
			bindVO.Value = f03MVO.M1maker_hbn;
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 商品名(カナ)		補充・仕入稟議検索-明細				Ｍ１商品名(カナ)	
			sRepSql.AppendLine(" ,SYONMK = :SYONMK");
			bindVO = new BindInfoVO();
			bindVO.BindId = "SYONMK";
			bindVO.Value = f03MVO.M1syonmk;
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
	
			// 原単価			補充・仕入稟議検索-明細				Ｍ１原単価(隠し)	
			sRepSql.AppendLine(" ,GEN_TNK = :GEN_TNK");
			bindVO = new BindInfoVO();
			bindVO.BindId = "GEN_TNK";
			bindVO.Value = BoSystemString.Nvl(f03MVO.M1gen_tnk, "0");
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			
			// 当初売価			補充・仕入稟議検索-明細(Dictionary)	Ｍ１当初売価		
			sRepSql.AppendLine(" ,TOSYOBAIKA_TNK = :TOSYOBAIKA_TNK");
			bindVO = new BindInfoVO();
			bindVO.BindId = "TOSYOBAIKA_TNK";
			bindVO.Value = BoSystemString.Nvl(f03MVO.Dictionary[Ta080p01Constant.DIC_M1TOSYOBAIKA_TNK].ToString(), "0");
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 依頼数量			補充・仕入稟議検索-明細				Ｍ１依頼数量		
			sRepSql.AppendLine(" ,IRAI_SU = :IRAI_SU");
			bindVO = new BindInfoVO();
			bindVO.BindId = "IRAI_SU";
			bindVO.Value = BoSystemString.Nvl(f03MVO.M1irai_su, "0");
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 依頼金額			補充・仕入稟議検索-明細				Ｍ１原価金額		
			sRepSql.AppendLine(" ,IRAI_KIN = :IRAI_KIN");
			bindVO = new BindInfoVO();
			bindVO.BindId = "IRAI_KIN";
			bindVO.Value = BoSystemString.Nvl(f03MVO.M1genkakin, "0");
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);
		}
		#endregion

		#region 単品レポートメッセージ出力(ヘッダ)
		/// <summary>
		/// 単品レポートメッセージ出力(ヘッダ)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="bool">blErr</param>
		/// <returns></returns>
		public static bool setTanpinMsg(IFacadeContext facadeContext
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
		public static void setTanpinReportMsg(string id, string param, IFacadeContext facadeContext, string[] item, string num, string index, string meisaiid, int dispRow
											, ArrayList tanpinErrList)
		{
			//bool blRet = blErr;
			// 明細画面
			Ta080f03Form f03VO = (Ta080f03Form)facadeContext.FormVO;

			if (f03VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			{
				// 単品登録モード
				string tanpinF = BoSystemString.Nvl(((string)f03VO.Dictionary[Ta080p01Constant.DIC_TANPIN_TOUROKU_MODE_FLG]), "0");
				// 単品登録モードがＯＮの場合、メッセージ出力はしない
				if (!Convert.ToString(Ta080p01Constant.FLG_ON).Equals(tanpinF))
				{
					//// 単品レポートエラーヘッダメッセージ設定
					//blRet = Ta080p01Util.setTanpinMsg(facadeContext, blErr);
					//// 単品レポートエラーメッセージ設定
					//InfoMsgCls.AddWarnMsg(id, param, facadeContext, item, num, index, meisaiid, dispRow);

					// 単品レポートエラーメッセージ設定
					TanpinErrMsgVO tanpinErrVo = new TanpinErrMsgVO(id, param, item, num, index, meisaiid, dispRow);
					tanpinErrList.Add(tanpinErrVo);
					
				}
			}
			else
			{
				// エラーメッセージ出力
				ErrMsgCls.AddErrMsg(id, param, facadeContext, item, num, index, meisaiid, dispRow);
			}

		}
		#endregion

		#region 単品レポートメッセージ出力一覧
		/// <summary>
		/// setTanpinReportMsg 単品レポートメッセージ出力一覧
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="bool">blErr</param>
		/// <returns></returns>
		public static void setTanpinReportMsgList(IFacadeContext facadeContext, ArrayList tanpinErrList)
		{
			// 単品レポートエラーヘッダメッセージ設定
			if (tanpinErrList.Count > 0)
			{
				Ta080p01Util.setTanpinMsg(facadeContext, false);
			}
			for (int i = 0; i < tanpinErrList.Count; i++)
			{
				TanpinErrMsgVO tanpinErrVo = (TanpinErrMsgVO) tanpinErrList[i];
				InfoMsgCls.AddWarnMsg(tanpinErrVo.Id
									, tanpinErrVo.Param
									, facadeContext
									, tanpinErrVo.Item
									, tanpinErrVo.Num
									, tanpinErrVo.Index
									, tanpinErrVo.Meisaiid
									, tanpinErrVo.DispRow
									);
			}

		}
		#endregion

		#region 代表自社品番振替メッセージ出力(ヘッダ)
		/// <summary>
		/// 代表自社品番振替メッセージ出力(ヘッダ)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="bool">blErr</param>
		/// <returns></returns>
		public static bool setDaihyoHeadMsg(IFacadeContext facadeContext, bool blErr)
		{
			bool blRet = blErr;
			if (!blErr)
			{
				InfoMsgCls.AddWarnMsg("I118", String.Empty, facadeContext);
				blRet = true;
			}
			return blRet;
		}
		#endregion
		#region 代表自社品番振替メッセージ出力
		/// <summary>
		/// setTanpinReportMsg 代表自社品番振替メッセージ出力
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="bool">blErr</param>
		/// <returns></returns>
		public static Boolean setDaihyoMsg(string id, string[] param, IFacadeContext facadeContext, string[] item, string num, string index, string meisaiid, int dispRow, bool blErr)
		{
			bool blRet = blErr;

			//// 明細画面
			//Ta080f03Form f03VO = (Ta080f03Form)facadeContext.FormVO;

			//if (f03VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
			//{
				// 単品レポートエラーヘッダメッセージ設定
				blRet = Ta080p01Util.setDaihyoHeadMsg(facadeContext, blErr);
				// 単品レポートエラーメッセージ設定
				InfoMsgCls.AddWarnMsg(id, param, facadeContext, item, num, index, meisaiid, dispRow);
			//}
			//else
			//{
			//	// エラーメッセージ出力
			//	ErrMsgCls.AddErrMsg(id, param, facadeContext, item, num, index, meisaiid, dispRow);
			//}
			return blRet;

		}
		#endregion

		#region 代表自社品番振替用明細転記処理
		/// <summary>
		/// 代表自社品番振替用明細画面転記処理
		/// </summary>
		/// <param name="m1List"></param>
		/// <returns></returns>
		public static void DoDaihyoShouhinCopy(IDataList m1List, SysDateVO sysDateVO)
		{

			for (int i = 0; i < m1List.Count; i++)
			{
				Ta080f03M1Form f03M1VO = (Ta080f03M1Form) m1List[i];
				if (BoSystemString.Nvl((string)f03M1VO.Dictionary[Ta080p01Constant.DIC_M1DAIHYO_JISYAHB_HK_FLG], "0").Equals(Ta080p01Constant.FLG_ON.ToString()))
				{
					BackDetailVO f03M1BackVO = (BackDetailVO)f03M1VO.Dictionary[Ta080p01Constant.DIC_M1DAIHYOF_SYOHININF];
					// 明細転記
					f03M1VO.M1bumonkana_nm = f03M1BackVO.M1bumonkana_nm;				// Ｍ１部門カナ名
					f03M1VO.M1ten_hyoka_kb = f03M1BackVO.M1ten_hyoka_kb;				// Ｍ１店評価
					f03M1VO.M1all_hyoka_kb = f03M1BackVO.M1all_hyoka_kb;				// Ｍ１全評価
					f03M1VO.M1tosyu_uriage_su = f03M1BackVO.M1tosyu_uriage_su;			// Ｍ１当週売
					f03M1VO.M1hinsyu_ryaku_nm = f03M1BackVO.M1hinsyu_ryaku_nm;			// Ｍ１品種略名称
					f03M1VO.M1zensyu_uriage_su = f03M1BackVO.M1zensyu_uriage_su;		// Ｍ１前売
					f03M1VO.M1zenzensyu_uriage_su = f03M1BackVO.M1zenzensyu_uriage_su;	// Ｍ１前々売
					f03M1VO.M1burando_nm = f03M1BackVO.M1burando_nm;					// Ｍ１ブランド名
					f03M1VO.M1nyukayotei_su = f03M1BackVO.M1nyukayotei_su;				// Ｍ１入荷
					f03M1VO.M1tenzaiko_su = f03M1BackVO.M1tenzaiko_su;					// Ｍ１在庫
					f03M1VO.M1jido_su = f03M1BackVO.M1jido_su;							// Ｍ１自動定数
					f03M1VO.M1haibunkano_su = f03M1BackVO.M1haibunkano_su;				// Ｍ１配分可能数
					f03M1VO.M1jisya_hbn = f03M1BackVO.M1jisya_hbn;						// Ｍ１自社品番
					f03M1VO.M1keikaku_ymd = f03M1BackVO.M1keikaku_ymd;					// Ｍ１計画期間 販売完了日の期末の月 yyyymm
					f03M1VO.M1syohin_zokusei = f03M1BackVO.M1syohin_zokusei;			// Ｍ１商品属性
					f03M1VO.M1lot_su = f03M1BackVO.M1lot_su;							// Ｍ１ロット数
					f03M1VO.M1maker_hbn = f03M1BackVO.M1maker_hbn;							// Ｍ１メーカー品番
					f03M1VO.M1syonmk = f03M1BackVO.M1syonmk;							// Ｍ１商品名(カナ)
					f03M1VO.M1iro_nm = f03M1BackVO.M1iro_nm;							// Ｍ１色
					f03M1VO.M1size_nm = f03M1BackVO.M1size_nm;							// Ｍ１サイズ
					f03M1VO.M1scan_cd = f03M1BackVO.M1scan_cd;							// Ｍ１スキャンコード 
					f03M1VO.M1gen_tnk = f03M1BackVO.M1gen_tnk;							// Ｍ１原単価(隠し)
					f03M1VO.M1genkakin = f03M1BackVO.M1genkakin;						// Ｍ１原価金額
					f03M1VO.M1hanbaikanryo_ymd = f03M1BackVO.M1hanbaikanryo_ymd;		// Ｍ１販売完了日 yymmdd
					f03M1VO.M1genkakin_hdn = f03M1BackVO.M1genkakin_hdn;				// Ｍ１原価金額(隠し)
					f03M1BackVO.M1hatchu_msg = Ta080p01Util.GetHtms(f03M1VO, sysDateVO);  // メッセージ区分

				}
			}
		}
		#endregion

		#region 評価区分変換
		/// <summary>
		/// 評価区分のコンディションバリューをDBの値に変換
		/// </summary>
		/// <param name="hyoka"></param>
		/// <returns></returns>
		public static string ChgHyokaKbCondToDB(string hyoka)
		{
			string HyokaDb = string.Empty;

			switch (hyoka){
				case ConditionHyoka_kbn.VALUE_HYOKA_KBN1:
					HyokaDb = Ta080p01Constant.KBN_HYOKA_A;
				break;
				case ConditionHyoka_kbn.VALUE_HYOKA_KBN2:
					HyokaDb = Ta080p01Constant.KBN_HYOKA_B;
				break;
				case ConditionHyoka_kbn.VALUE_HYOKA_KBN3:
					HyokaDb = Ta080p01Constant.KBN_HYOKA_C;
				break;
				case ConditionHyoka_kbn.VALUE_HYOKA_KBN4:
					HyokaDb = Ta080p01Constant.KBN_HYOKA_HYPHEN;
				break;
				default:
				break;
			}

			return HyokaDb;
		}
		#endregion
	}
}
