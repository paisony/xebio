using com.xebio.bo.Tj190p01.Constant;
using com.xebio.bo.Tj190p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
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
using Common.Business.V01000.V01010;
using Common.Business.V01000.V01011;
using Common.Business.V01000.V01012;
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
using System.Text;

namespace com.xebio.bo.Tj190p01.Facade
{
  /// <summary>
  /// Tj190f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj190f01Facade : StandardBaseFacade
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
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tj190f01Form f01VO = (Tj190f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 選択モードの初期化
				f01VO.Stkmodeno = string.Empty;

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				// 店舗MSTを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// 1-2 入力担当者コード
				// 担当者MSTを検索し、存在しない場合エラー
				f01VO.Nyuryokutan_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f01VO.Nyuryokutan_cd
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
						f01VO.Nyuryokutan_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 1-3 ブランドコード
				// ブランドMSTを検索し、存在しない場合エラー
				f01VO.Burando_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Burando_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01012Check.CheckBrand(f01VO.Burando_cd
														, facadeContext
														, string.Empty
														, null
														, "ブランド"
														, new[] { "Burando_cd" }
														, null
														, null
														, null
														, 0
														, 0);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Burando_nm = (string)resultHash["BURANDO_NMK"];
					}
				}

				// 自社品番、スキャンコード存在チェック用
				// 発注条件VOを定義
				SearchHachuVO searchConditionVO = new SearchHachuVO();
				searchConditionVO.Tencd = f01VO.Head_tenpo_cd;	// 店舗コード

				// 1-4 旧自社品番
				// 発注MSTを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
				{
					searchConditionVO.Scancd = f01VO.Old_jisya_hbn;	// 旧自社品番
					Hashtable resultHash = new Hashtable();
					resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番", new[] { "Old_jisya_hbn" });
				}

				// 1-5 スキャンコード
				// 発注MSTを検索し、存在しない場合エラー

				// スキャンコード
				if (!string.IsNullOrEmpty(f01VO.Scan_cd))
				{
					searchConditionVO.Scancd = f01VO.Scan_cd;	// スキャンコード
					Hashtable resultHash = new Hashtable();
					resultHash = V01004Check.CheckScanCd(searchConditionVO, facadeContext, "ｽｷｬﾝｺｰﾄﾞ", new[] { "Scan_cd" });
				}

				// 条件部店舗コード、部門、品種名称取得

				// 店舗コードFROM
				f01VO.Tenpo_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Tenpo_cd_from
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Tenpo_nm_from = (string)resultHash["TENPO_NM"];
					}
				}

				// 店舗コードTO
				f01VO.Tenpo_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Tenpo_cd_to
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Tenpo_nm_to = (string)resultHash["TENPO_NM"];
					}
				}

				// 部門名FROM
				f01VO.Bumon_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_from
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_from = (string)resultHash["BUMON_NM"];
					}
				}

				// 部門名TO
				f01VO.Bumon_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd_to
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Bumon_nm_to = (string)resultHash["BUMON_NM"];
					}
				}

				// 品種略名称FROM
				f01VO.Hinsyu_ryaku_nm_from = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd_from))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01011Check.CheckHinsyu(f01VO.Bumon_cd_from
														, f01VO.Hinsyu_cd_from
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Hinsyu_ryaku_nm_from = (string)resultHash["HINSYU_RYAKU_NM"];
					}
				}

				// 品種略名称TO
				f01VO.Hinsyu_ryaku_nm_to = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd_to))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01011Check.CheckHinsyu(f01VO.Bumon_cd_to
														, f01VO.Hinsyu_cd_to
														, facadeContext
														, string.Empty
														, null
														, null
														, null
														, null
														, null
														, null
														, 0
														, 0
														);
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Hinsyu_ryaku_nm_to = (string)resultHash["HINSYU_RYAKU_NM"];
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連チェック

				// 2-1 入力日FROM、入力日TO
				// 入力日ＦＲＯＭ > 入力日ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_from) && !string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Nyuryoku_ymd_from,
									f01VO.Nyuryoku_ymd_to,
									facadeContext,
									"入力日",
									new[] { "Nyuryoku_ymd_from", "Nyuryoku_ymd_to" }
									);
				}

				// 2-2 店舗コードFROM、店舗コードTO
				// 店舗コードＦＲＯＭ > 店舗コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from) && !string.IsNullOrEmpty(f01VO.Tenpo_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Tenpo_cd_from,
									f01VO.Tenpo_cd_to,
									facadeContext,
									"店舗",
									new[] { "Tenpo_cd_from", "Tenpo_cd_to" }
									);
				}

				// 2-3 部門コードFROM、部門コードTO
				// 部門コードＦＲＯＭ > 部門コードＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Bumon_cd_to))
				{
					V03002Check.CodeFromToChk(
									f01VO.Bumon_cd_from,
									f01VO.Bumon_cd_to,
									facadeContext,
									"部門",
									new[] { "Bumon_cd_from", "Bumon_cd_to" }
									);
				}

				// 2-4 部門コードFROM、品種コードFROM
				// 部門コードＦＲＯＭが未入力で、品種コードFROMを入力した場合エラー
				if (string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Hinsyu_cd_from))
				{
					ErrMsgCls.AddErrMsg("E183", string.Empty, facadeContext, new[] { "Bumon_cd_from", "Hinsyu_cd_from" });
				}

				// 2-5 部門コードTO、品種コードTO
				// 部門コードTOが未入力で、品種コードTOを入力した場合エラー
				if (string.IsNullOrEmpty(f01VO.Bumon_cd_to) && !string.IsNullOrEmpty(f01VO.Hinsyu_cd_to))
				{
					ErrMsgCls.AddErrMsg("E183", string.Empty, facadeContext, new[] { "Bumon_cd_to", "Hinsyu_cd_to" });
				}

				// 2-6 部門コードFROM、部門コードTO、品種コードFROM、品種コードTO
				// 部門コードFROM、部門コードTOが同じ値で、品種コードFROM＞品種コードTOの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Bumon_cd_from) && !string.IsNullOrEmpty(f01VO.Bumon_cd_to) && f01VO.Bumon_cd_from.Equals(f01VO.Bumon_cd_to))
				{
					if (!string.IsNullOrEmpty(f01VO.Hinsyu_cd_from) && !string.IsNullOrEmpty(f01VO.Hinsyu_cd_to))
					{
						V03002Check.CodeFromToChk(
										f01VO.Hinsyu_cd_from,
										f01VO.Hinsyu_cd_to,
										facadeContext,
										"品種",
										new[] { "Hinsyu_cd_from", "Hinsyu_cd_to" }
										);
					}			
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 件数チェック

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 検索件数
				Decimal dCnt = 0;
				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_01, facadeContext.DBContext);

				// 検索条件設定
				String TableId = string.Empty;
				// [選択モードNo]が「修正」、「取消」、「照会」、「ロス計算」の場合、[臨時棚卸TBL(H)]から検索する。
				if (BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)
					|| BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
					|| BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
					|| BoSystemConstant.MODE_LOSSKEISAN.Equals(f01VO.Modeno))
				{
					TableId = Tj190p01Constant.RINJI_TABLE_H;
				}
				// [選択モードNo]が「ロス取消」、「ロス照会」の場合、[臨時棚卸ロスTBL(H)]から検索する。
				else if (BoSystemConstant.MODE_LOSSDEL.Equals(f01VO.Modeno)
					|| BoSystemConstant.MODE_LOSSREF.Equals(f01VO.Modeno))
				{
					TableId = Tj190p01Constant.RINJI_LOSS_TABLE_H;
				}
				else
				{

				}

				BoSystemSql.AddSql(rtChk, Tj190p01Constant.SQL_ID_01_REP_TABLE, TableId);

				// WHERE句設定
				AddWhere(f01VO, rtChk, sysDateVO);

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

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj190p01Constant.SQL_ID_02, facadeContext.DBContext);
				// テーブルID設定
				BoSystemSql.AddSql(rtSeach, Tj190p01Constant.SQL_ID_01_REP_TABLE, TableId);

				// SELECT項目設定
				AddSelect(rtSeach,TableId);
				// WHERE句設定
				AddWhere(f01VO, rtSeach, sysDateVO);
				// ソート条件設定
				AddSort(f01VO, rtSeach, TableId);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				// 合計数計算
				Decimal dGokeitanajityobo_su = 0;
				Decimal dGokeitanajisekiso_su = 0;
				Decimal dGokeijitana_su = 0;
				Decimal dGokeiloss_su = 0;
				Decimal dGokeiloss_kin = 0;

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tj190f01M1Form f01m1VO = new Tj190f01M1Form();
					f01m1VO.M1rowno = iCnt.ToString();										// Ｍ１行NO
					f01m1VO.M1tenpo_cd = rec["TENPO_CD"].ToString();						// Ｍ１店舗コード
					f01m1VO.M1tenpo_nm = rec["TENPO_NM"].ToString();						// Ｍ１店舗名
					f01m1VO.M1nyuryoku_ymd = BoSystemString.ZeroToEmpty(rec["ADD_YMD"].ToString());	
																							// Ｍ１入力日
					f01m1VO.M1rintana_kanri_no = BoSystemString.ZeroToEmpty(rec["RINTANA_KANRI_NO"].ToString());		// Ｍ１臨棚管理№	
					f01m1VO.M1loss_kanri_no = BoSystemString.ZeroToEmpty(rec["LOSS_KANRI_NO"].ToString());

					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BUMON_CD] = rec["BUMON_CD"].ToString();
																							// Ｍ１部門リンク
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BUMON_NM] = rec["BUMONKANA_NM"].ToString();
																							// Ｍ１部門カナ名リンク
					f01m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();			// Ｍ１品種略名称
					f01m1VO.M1burando_nm1 = rec["BURANDO_NMK1"].ToString();					// Ｍ１ブランド名1
					f01m1VO.M1burando_nm2 = rec["BURANDO_NMK2"].ToString();					// Ｍ１ブランド名2
					f01m1VO.M1burando_nm3 = rec["BURANDO_NMK3"].ToString();					// Ｍ１ブランド名3
					f01m1VO.M1burando_nm4 = rec["BURANDO_NMK4"].ToString();					// Ｍ１ブランド名4
					f01m1VO.M1burando_nm5 = rec["BURANDO_NMK5"].ToString();					// Ｍ１ブランド名5
					f01m1VO.M1burando_nm6 = rec["BURANDO_NMK6"].ToString();					// Ｍ１ブランド名6
					f01m1VO.M1burando_nm7 = rec["BURANDO_NMK7"].ToString();					// Ｍ１ブランド名7
					f01m1VO.M1burando_nm8 = rec["BURANDO_NMK8"].ToString();					// Ｍ１ブランド名8
					f01m1VO.M1tanajityobo_su = rec["GOKEITANAJITYOBO_SU"].ToString();		// Ｍ１棚時帳簿数
					f01m1VO.M1tanajisekiso_su = rec["GOKEITANAJISEKISO_SU"].ToString();		// Ｍ１棚時積送数
					f01m1VO.M1jitana_su = rec["GOKEIJITANA_SU"].ToString();					// Ｍ１実棚数
					f01m1VO.M1nyuryokutan_nm = rec["HANBAIIN_NM"].ToString();				// Ｍ１入力担当者名称
					f01m1VO.M1loss_su = rec["GOKEILOSS_SU"].ToString();						// Ｍ１ロス数
					f01m1VO.M1loss_kin = rec["GOKEILOSS_KIN"].ToString();					// Ｍ１ロス金額
					f01m1VO.M1losskeisan_ymd = BoSystemString.ZeroToEmpty(rec["LOSSKEISAN_YMD"].ToString());
																							// Ｍ１ロス計算日
					f01m1VO.M1losskeisan_tm = BoSystemString.ZeroToEmpty(rec["LOSSKEISAN_TM"].ToString());
					if (!string.IsNullOrEmpty(f01m1VO.M1losskeisan_tm))
					{
						f01m1VO.M1losskeisan_tm = BoSystemFormat.formatTime(f01m1VO.M1losskeisan_tm);
					}
																							// Ｍ１ロス計算時間
					f01m1VO.M1selectorcheckbox = "0";										// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = "0";											// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = "0";												// Ｍ１明細色区分(隠し)

					// 送信済み行は色変更
					if (ConditionSosinzumi_flg.VALUE_SOSINZUMI.Equals(rec["SOSINZUMI_FLG"].ToString()))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;		// Ｍ１明細色区分(隠し)
					}

					// Ｍ１棚時帳簿数の合計
					dGokeitanajityobo_su += Convert.ToDecimal(BoSystemString.Nvl(rec["GOKEITANAJITYOBO_SU"].ToString(), "0"));
					// Ｍ１棚時積送数の合計
					dGokeitanajisekiso_su += Convert.ToDecimal(BoSystemString.Nvl(rec["GOKEITANAJISEKISO_SU"].ToString(), "0"));
					// Ｍ１実棚数の合計
					dGokeijitana_su += Convert.ToDecimal(BoSystemString.Nvl(rec["GOKEIJITANA_SU"].ToString(), "0"));
					// Ｍ１ロス数の合計
					dGokeiloss_su += Convert.ToDecimal(BoSystemString.Nvl(rec["GOKEILOSS_SU"].ToString(), "0"));
					// Ｍ１ロス金額の合計
					dGokeiloss_kin += Convert.ToDecimal(BoSystemString.Nvl(rec["GOKEILOSS_KIN"].ToString(), "0"));

					// Dictionaryの設定
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1UPD_YMD] = rec["UPD_YMD"].ToString();						// Ｍ１更新日
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1UPD_TM] = rec["UPD_TM"].ToString();						// Ｍ１更新時間
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1RINTANA_KANRI_NO] = rec["RINTANA_KANRI_NO"].ToString();	// Ｍ１臨棚管理№
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1LOSS_KANRI_NO] = rec["LOSS_KANRI_NO"].ToString();			// Ｍ１ロス管理№
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1SYORI_YMD] = rec["SYORI_YMD"].ToString();					// Ｍ１処理日付
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1SYORI_TM] = rec["SYORI_TM"].ToString();					// Ｍ１処理時間
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1NYURYOKUTAN_CD] = rec["ADDTAN_CD"].ToString();			// Ｍ１入力担当者コード
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1HINSYU_SITEI_FLG] = rec["HINSYU_SITEI_FLG"].ToString();	// Ｍ１品種指定フラグ
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1HINSYU_CD] = rec["HINSYU_CD"].ToString();					// Ｍ１品種コード
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_SITEI_FLG] = rec["BURANDO_SITEI_FLG"].ToString();	// Ｍ１ブランド指定フラグ
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD] = rec["BURANDO_CD1"].ToString();				// Ｍ１ブランドコード
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD1] = rec["BURANDO_CD2"].ToString();				// Ｍ１ブランドコード1
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD2] = rec["BURANDO_CD3"].ToString();				// Ｍ１ブランドコード2
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD3] = rec["BURANDO_CD4"].ToString();				// Ｍ１ブランドコード3
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD4] = rec["BURANDO_CD5"].ToString();				// Ｍ１ブランドコード4
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD5] = rec["BURANDO_CD6"].ToString();				// Ｍ１ブランドコード5
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD6] = rec["BURANDO_CD7"].ToString();				// Ｍ１ブランドコード6
					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BURANDO_CD7] = rec["BURANDO_CD8"].ToString();				// Ｍ１ブランドコード7

					f01m1VO.Dictionary[Tj190p01Constant.DIC_M1BUMON_NM_MEISAI] = rec["BUMON_NM"].ToString();			// 部門名（明細表示用）

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);			
				}

				// 合計欄の設定

				// 合計棚時帳簿数
				f01VO.Gokeitanajityobo_su = dGokeitanajityobo_su.ToString();
				// 合計棚時積送数
				f01VO.Gokeitanajisekiso_su = dGokeitanajisekiso_su.ToString();
				// 合計実棚数
				f01VO.Gokeijitana_su = dGokeijitana_su.ToString();
				// 合計ロス数
				f01VO.Gokeiloss_su = dGokeiloss_su.ToString();
				// 合計ロス金額
				f01VO.Gokeiloss_kin = dGokeiloss_kin.ToString();

				// 件数の設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 選択モードNO設定
				f01VO.Stkmodeno = f01VO.Modeno;

				#endregion

				#region 検索条件をDictionaryに設定

				// 検索時のformVOを保持
				SearchConditionSaveCls.SearchConditionSave(f01VO);

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

		#region ユーザー定義関数

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Tj190f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns></returns>
		private void AddWhere(Tj190f01Form f01VO, FindSqlResultTable reader,SysDateVO sysDateVO)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 明細テーブル決定
			String meisaitableId = string.Empty;
			// [選択モードNo]が「修正」、「取消」、「照会」、「ロス計算」の場合に臨時棚卸TBL(B)を検索する
			if (BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)
				|| BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
				|| BoSystemConstant.MODE_REF.Equals(f01VO.Modeno)
				|| BoSystemConstant.MODE_LOSSKEISAN.Equals(f01VO.Modeno))
			{
				meisaitableId = Tj190p01Constant.RINJI_TABLE_B;
			}
			// [選択モードNo]が「ロス取消」、「ロス照会」の場合、[臨時棚卸ロスTBL(H)]から検索する。
			else if (BoSystemConstant.MODE_LOSSDEL.Equals(f01VO.Modeno)
				|| BoSystemConstant.MODE_LOSSREF.Equals(f01VO.Modeno))
			{
				meisaitableId = Tj190p01Constant.RINJI_LOSS_TABLE_B;
			}
			else
			{

			}

			#region モード

			// [臨時棚卸TBL(H)]検索の場合
			if (Tj190p01Constant.RINJI_TABLE_B.Equals(meisaitableId))
			{

				// [選択モードNo]が「修正」、「取消」、「ロス計算」の場合、条件とする。
				if (BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)
				|| BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
				|| BoSystemConstant.MODE_LOSSKEISAN.Equals(f01VO.Modeno))
				{
					sRepSql.Append("  AND A.SYORI_YMD = :BIND_SYORI_YMD");
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYORI_YMD";
					bindVO.Value = BoSystemFormat.formatDate(sysDateVO.Sysdate);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}
			// [臨時棚卸ロスTBL(H)]検索の場合
			else if (Tj190p01Constant.RINJI_LOSS_TABLE_B.Equals(meisaitableId))
			{
				// [選択モードNo]が「ロス取消」の場合、条件とする
				if (BoSystemConstant.MODE_LOSSDEL.Equals(f01VO.Modeno))
				{
					// 処理日付
					sRepSql.Append("  AND A.SYORI_YMD = :BIND_SYORI_YMD");
					// 送信済みフラグ
					sRepSql.Append("  AND A.SOSINZUMI_FLG = '0'");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYORI_YMD";
					bindVO.Value = BoSystemFormat.formatDate(sysDateVO.Sysdate);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
			}

			#endregion

			#region 入力日FROM

			if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_from)) {

				sRepSql.Append("  AND A.ADD_YMD >= :BIND_ADD_YMD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADD_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 入力日TO

			if (!string.IsNullOrEmpty(f01VO.Nyuryoku_ymd_to))
			{

				sRepSql.Append("  AND A.ADD_YMD <= :BIND_ADD_YMD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADD_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Nyuryoku_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 店舗コードFFROM

			if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_from)){
				sRepSql.Append("	AND A.TENPO_CD >= :BIND_TENPO_CD_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD_FROM";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 店舗コードTO

			if (!string.IsNullOrEmpty(f01VO.Tenpo_cd_to))
			{
				sRepSql.Append("	AND A.TENPO_CD <= :BIND_TENPO_CD_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD_TO";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Tenpo_cd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 入力担当者コード

			if (!string.IsNullOrEmpty(f01VO.Nyuryokutan_cd))
			{
				sRepSql.Append("	AND A.ADDTAN_CD = :BIND_ADDTAN_CD");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_ADDTAN_CD";
				bindVO.Value = BoSystemFormat.formatTantoCd(f01VO.Nyuryokutan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 部門コードFROM、品種コードFROM

			String sBumonCdFrom = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_from);
			String sHInshuCdFrom = BoSystemFormat.formatHinsyuCd(f01VO.Hinsyu_cd_from);
			// [部門コードFROM]が入力されていない場合"000"に置き換える。[品種コードFROM]が入力されていない場合"00"に置き換える。
			if (string.IsNullOrEmpty(sBumonCdFrom))
			{
				sBumonCdFrom = "000";
			}
			if (string.IsNullOrEmpty(sHInshuCdFrom))
			{
				sHInshuCdFrom = "00";
			}

			// [部門コードFROM]と[品種コードFROM]を文字結合した結果が"00000"以外の場合に条件とする。
			if (!"00000".Equals(sBumonCdFrom + sHInshuCdFrom))
			{
				sRepSql.Append(" AND (TRIM(TO_CHAR(A.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(A.HINSYU_CD,'00'),'00'))) >= :BIND_BUMON_FROM");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_FROM";
				bindVO.Value = sBumonCdFrom + sHInshuCdFrom;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 部門コードTO、品種コードTO

			String sBumonCdTo = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd_to);
			String sHInshuCdTo = BoSystemFormat.formatHinsyuCd(f01VO.Hinsyu_cd_to);
			// [部門コードTO]が入力されていない場合"000"に置き換える。[品種コードTO]が入力されていない場合"00"に置き換える。
			if (string.IsNullOrEmpty(sBumonCdTo))
			{
				sBumonCdTo = "999";
			}
			if (string.IsNullOrEmpty(sHInshuCdTo))
			{
				sHInshuCdTo = "99";
			}

			// [部門コードTO]と[品種コードTO]を文字結合した結果が"00000"以外の場合に条件とする。
			if (!"99999".Equals(sBumonCdTo + sHInshuCdTo))
			{
				sRepSql.Append(" AND (TRIM(TO_CHAR(A.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(A.HINSYU_CD,'00'),'00'))) <= :BIND_BUMON_TO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_TO";
				bindVO.Value = sBumonCdTo + sHInshuCdTo;
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region ブランドコード

			if (!string.IsNullOrEmpty(f01VO.Burando_cd))
			{
				sRepSql.Append("	AND :BIND_BURANDO_CD IN (A.BURANDO_CD1,A.BURANDO_CD2,A.BURANDO_CD3,A.BURANDO_CD4,A.BURANDO_CD5,A.BURANDO_CD6,A.BURANDO_CD7,A.BURANDO_CD8)");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD";
				bindVO.Value = BoSystemFormat.formatBrandCd(f01VO.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region 自社品番

			if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
			{

				sRepSql.Append("	AND EXISTS ( ");
				sRepSql.Append("		SELECT 1 ");
				sRepSql.Append("		FROM  ").Append(meisaitableId).Append(" B");
				sRepSql.Append("		WHERE A.TENPO_CD = B.TENPO_CD");

				if (Tj190p01Constant.RINJI_TABLE_B.Equals(meisaitableId))
				{
					sRepSql.Append("		AND A.RINTANA_KANRI_NO = B.RINTANA_KANRI_NO");
				}
				else if (Tj190p01Constant.RINJI_LOSS_TABLE_B.Equals(meisaitableId))
				{
					sRepSql.Append("		AND A.LOSS_KANRI_NO = B.LOSS_KANRI_NO");
				}
				sRepSql.Append("		AND A.SYORI_YMD = B.SYORI_YMD");

				// 自社品番が10桁だった場合
				if (f01VO.Old_jisya_hbn.Length.Equals(10))
				{
					sRepSql.Append("	AND B.JAN_CD IN	(");
					sRepSql.Append("						SELECT	M1.JAN_CD");
					sRepSql.Append("						FROM	MDMT0130 M1");
					sRepSql.Append("						WHERE	M1.OLD_XEBIO_CD = :BIND_OLD_XEBIO_CD");
					sRepSql.Append("						)");
				}
				else
				{
					sRepSql.Append("	AND B.JISYA_HBN	= :BIND_OLD_XEBIO_CD");
				}

				sRepSql.Append("	)");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_OLD_XEBIO_CD";
				bindVO.Value = BoSystemFormat.formatJisyaHbn(f01VO.Old_jisya_hbn);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region スキャンコード

			if (!string.IsNullOrEmpty(f01VO.Scan_cd))
			{
				sRepSql.Append("	AND EXISTS ( ");
				sRepSql.Append("		SELECT 1 ");
				sRepSql.Append("		FROM  ").Append(meisaitableId).Append(" C");
				sRepSql.Append("		WHERE A.TENPO_CD = C.TENPO_CD");

				if (Tj190p01Constant.RINJI_TABLE_B.Equals(meisaitableId))
				{
					sRepSql.Append("		AND A.RINTANA_KANRI_NO = C.RINTANA_KANRI_NO");
				}
				else if (Tj190p01Constant.RINJI_LOSS_TABLE_B.Equals(meisaitableId))
				{
					sRepSql.Append("		AND A.LOSS_KANRI_NO = C.LOSS_KANRI_NO");
				}
				sRepSql.Append("		AND A.SYORI_YMD = C.SYORI_YMD");
				sRepSql.Append("		AND C.JAN_CD = :BIND_JAN_CD");
				sRepSql.Append("	)");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_JAN_CD";
				bindVO.Value = BoSystemFormat.formatJanCd(f01VO.Scan_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			#region ロス管理No

			if (!string.IsNullOrEmpty(f01VO.Loss_kanri_no))
			{
				sRepSql.Append("	AND A.LOSS_KANRI_NO = :BIND_LOSS_KANRI_NO");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_LOSS_KANRI_NO";
				bindVO.Value = f01VO.Loss_kanri_no;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			#endregion

			BoSystemSql.AddSql(reader, Tj190p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);

		}

		#endregion

		#region SELECT項目設定
		/// <summary>
		/// AddSelect SELECT項目設定
		/// </summary>
		/// <param name="Tj190f01Form">f01VO</param>
		/// <param name="String">TABLEID</param>
		/// <returns></returns>
		private void AddSelect(FindSqlResultTable reader, String TABLEID)
		{
			StringBuilder sRepSql = new StringBuilder();
			// 臨時棚卸ロスTBL(H)から取得する際には、"0"を設定する。
			// 臨時棚卸ロスTBL(H)から取得する際には、送信済みフラグも取得する
			if (Tj190p01Constant.RINJI_TABLE_H.Equals(TABLEID)) 
			{
				sRepSql.Append(",A.RINTANA_KANRI_NO RINTANA_KANRI_NO");
				sRepSql.Append(",0 SOSINZUMI_FLG");
			}
			else
			{
				sRepSql.Append(",0 RINTANA_KANRI_NO");
				sRepSql.Append(",A.SOSINZUMI_FLG SOSINZUMI_FLG");

			}
			BoSystemSql.AddSql(reader, Tj190p01Constant.SQL_ID_01_REP_SELECT_KANRI_NO, sRepSql.ToString());

		}
		#endregion

		#region SORT条件設定
		/// <summary>
		/// AddSelect SORT条件設定
		/// </summary>
		/// <param name="Tj190f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <param name="String">TABLEID</param>
		/// <returns></returns>
		private void AddSort(Tj190f01Form f01VO ,FindSqlResultTable reader, String TABLEID)
		{
			StringBuilder sRepSql = new StringBuilder();
			// 臨時棚卸TBL(H)検索時のソート条件設定
			if (Tj190p01Constant.RINJI_TABLE_H.Equals(TABLEID))
			{
				// [明細ソート]が「部門／品種／ブランド順」の場合
				if (ConditionMeisai_sort_tj190f01.VALUE_MEISAI_SORT_TJ190F011.Equals(f01VO.Meisai_sort)) {

					sRepSql.Append(" A.BUMON_CD");
					sRepSql.Append(" ,A.HINSYU_SITEI_FLG");
					sRepSql.Append(" ,A.HINSYU_CD");
					sRepSql.Append(" ,A.BURANDO_SITEI_FLG");
					sRepSql.Append(" ,A.BURANDO_CD1");
					sRepSql.Append(" ,A.BURANDO_CD2");
					sRepSql.Append(" ,A.BURANDO_CD3");
					sRepSql.Append(" ,A.BURANDO_CD4");
					sRepSql.Append(" ,A.BURANDO_CD5");
					sRepSql.Append(" ,A.BURANDO_CD6");
					sRepSql.Append(" ,A.BURANDO_CD7");
					sRepSql.Append(" ,A.BURANDO_CD8");
					sRepSql.Append(" ,A.TENPO_CD");
					sRepSql.Append(" ,A.ADD_YMD DESC");
					sRepSql.Append(" ,A.ADD_TM DESC");
					sRepSql.Append(" ,A.RINTANA_KANRI_NO DESC");

				}
				// [明細ソート]が「登録順」の場合
				else if (ConditionMeisai_sort_tj190f01.VALUE_MEISAI_SORT_TJ190F012.Equals(f01VO.Meisai_sort))
				{
					sRepSql.Append(" A.TENPO_CD");
					sRepSql.Append(" ,A.ADD_YMD DESC");
					sRepSql.Append(" ,A.ADD_TM DESC");
					sRepSql.Append(" ,A.RINTANA_KANRI_NO DESC");
				}
				// [明細ソート]が「店舗／部門／品種／ブランド順」の場合
				else if (ConditionMeisai_sort_tj190f01.VALUE_MEISAI_SORT_TJ190F013.Equals(f01VO.Meisai_sort))
				{
					sRepSql.Append(" A.TENPO_CD");
					sRepSql.Append(" ,A.BUMON_CD");
					sRepSql.Append(" ,A.HINSYU_SITEI_FLG");
					sRepSql.Append(" ,A.HINSYU_CD");
					sRepSql.Append(" ,A.BURANDO_SITEI_FLG");
					sRepSql.Append(" ,A.BURANDO_CD1");
					sRepSql.Append(" ,A.BURANDO_CD2");
					sRepSql.Append(" ,A.BURANDO_CD3");
					sRepSql.Append(" ,A.BURANDO_CD4");
					sRepSql.Append(" ,A.BURANDO_CD5");
					sRepSql.Append(" ,A.BURANDO_CD6");
					sRepSql.Append(" ,A.BURANDO_CD7");
					sRepSql.Append(" ,A.BURANDO_CD8");
					sRepSql.Append(" ,A.ADD_YMD DESC");
					sRepSql.Append(" ,A.ADD_TM DESC");
					sRepSql.Append(" ,A.RINTANA_KANRI_NO DESC");
				}
			}
			else
			{
				// [明細ソート]が「部門／品種／ブランド順」の場合
				if (ConditionMeisai_sort_tj190f01.VALUE_MEISAI_SORT_TJ190F011.Equals(f01VO.Meisai_sort))
				{

					sRepSql.Append(" A.BUMON_CD");
					sRepSql.Append(" ,A.HINSYU_SITEI_FLG");
					sRepSql.Append(" ,A.HINSYU_CD");
					sRepSql.Append(" ,A.BURANDO_SITEI_FLG");
					sRepSql.Append(" ,A.BURANDO_CD1");
					sRepSql.Append(" ,A.BURANDO_CD2");
					sRepSql.Append(" ,A.BURANDO_CD3");
					sRepSql.Append(" ,A.BURANDO_CD4");
					sRepSql.Append(" ,A.BURANDO_CD5");
					sRepSql.Append(" ,A.BURANDO_CD6");
					sRepSql.Append(" ,A.BURANDO_CD7");
					sRepSql.Append(" ,A.BURANDO_CD8");
					sRepSql.Append(" ,A.TENPO_CD");
					sRepSql.Append(" ,A.ADD_YMD DESC");
					sRepSql.Append(" ,A.ADD_TM DESC");
					sRepSql.Append(" ,A.LOSS_KANRI_NO DESC");

				}
				// [明細ソート]が「登録順」の場合
				else if (ConditionMeisai_sort_tj190f01.VALUE_MEISAI_SORT_TJ190F012.Equals(f01VO.Meisai_sort))
				{
					sRepSql.Append(" A.TENPO_CD");
					sRepSql.Append(" ,A.ADD_YMD DESC");
					sRepSql.Append(" ,A.ADD_TM DESC");
					sRepSql.Append(" ,A.LOSS_KANRI_NO DESC");
				}
				// [明細ソート]が「店舗／部門／品種／ブランド順」の場合
				else if (ConditionMeisai_sort_tj190f01.VALUE_MEISAI_SORT_TJ190F013.Equals(f01VO.Meisai_sort))
				{
					sRepSql.Append(" A.TENPO_CD");
					sRepSql.Append(" ,A.BUMON_CD");
					sRepSql.Append(" ,A.HINSYU_SITEI_FLG");
					sRepSql.Append(" ,A.HINSYU_CD");
					sRepSql.Append(" ,A.BURANDO_SITEI_FLG");
					sRepSql.Append(" ,A.BURANDO_CD1");
					sRepSql.Append(" ,A.BURANDO_CD2");
					sRepSql.Append(" ,A.BURANDO_CD3");
					sRepSql.Append(" ,A.BURANDO_CD4");
					sRepSql.Append(" ,A.BURANDO_CD5");
					sRepSql.Append(" ,A.BURANDO_CD6");
					sRepSql.Append(" ,A.BURANDO_CD7");
					sRepSql.Append(" ,A.BURANDO_CD8");
					sRepSql.Append(" ,A.ADD_YMD DESC");
					sRepSql.Append(" ,A.ADD_TM DESC");
					sRepSql.Append(" ,A.LOSS_KANRI_NO DESC");
				}
			}
			BoSystemSql.AddSql(reader, Tj190p01Constant.SQL_ID_01_REP_ID_SORT, sRepSql.ToString());
		}
		#endregion

		#endregion
	}
}
