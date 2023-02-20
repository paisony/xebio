using com.xebio.bo.Tf060p01.Constant;
using com.xebio.bo.Tf060p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.V01000.V01001;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tf060p01.Facade
{
  /// <summary>
  /// Tf060f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf060f01Facade : StandardBaseFacade
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

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				//業務日付を取得する
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				DateTime date = DateTime.Parse(sysDateVO.Sysdate.ToString().Insert(4, "/").Insert(7, "/"));

				// FormVO取得
				// 画面より情報を取得する。
				Tf060f01Form f01VO = (Tf060f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
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

				// 1-2 月度
				//       当月か翌月以外が入力された場合、エラー
				if (!string.IsNullOrEmpty(f01VO.Getudo))
				{
					//当月
					int tougetsu = Convert.ToInt16(date.ToString("MM"));
					//翌月
					int yokugetsu = Convert.ToInt16(new DateTime(date.Year, date.Month, date.Day).AddMonths(1).ToString("MM"));

					if (Convert.ToInt16(f01VO.Getudo) != tougetsu && Convert.ToInt16(f01VO.Getudo) != yokugetsu)
					{
						//月度は当月／翌月のみ入力可能です。
						ErrMsgCls.AddErrMsg("E142", String.Empty, facadeContext);
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

				// 日販部門予算TBLを検索
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tf060p01Constant.SQL_ID_01, facadeContext.DBContext);

				// バインド値の置き換え
				// 店舗コード
				rtSeach.BindValue(Tf060p01Constant.REP_TENPO_CD, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
				// 月度
				rtSeach.BindValue(Tf060p01Constant.REP_GETUDO, f01VO.Getudo.PadLeft(2, '0'));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				#endregion

				#region 明細表示

				// 年月取得
				int iYear = Convert.ToInt16(this.getYear(f01VO.Getudo, date));
				int iMonth = Convert.ToInt16(f01VO.Getudo);

				// 年月をDictionaryに退避
				f01VO.Dictionary[Tf060p01Constant.DIC_YYYYMM] = iYear.ToString() + f01VO.Getudo.PadLeft(2, '0');

				// 月度内の日数を取得
				int iDaysInMonth = DateTime.DaysInMonth(iYear, iMonth);

				int iDay = 0;
				for (int i = 0; i < iDaysInMonth; i++)
				{
					iDay++;
					Tf060f01M1Form f01m1VO = new Tf060f01M1Form();

					// Ｍ１月内日付
					f01m1VO.M1getunai_hiduke = iDay.ToString();

					// Ｍ１曜日
					f01m1VO.M1yobi = getYobi(new DateTime(iYear, iMonth, iDay));

					// Ｍ１部門(１～５)予算額
					decimal dHibetuGokei = 0;
					string colum_name = "YOSAN" + iDay.ToString() + "_KIN";
					foreach (Hashtable rec in tableList)
					{
						if (rec["NIPPANBUMON_CD"].ToString().Equals("1"))	
						{
							f01m1VO.M1bumon1_yosan_kin = rec[colum_name].ToString();		// Ｍ１部門１予算額
							f01m1VO.M1bumon1_yosan_kin_hdn = rec[colum_name].ToString();	// Ｍ１部門１予算額(隠し)
						}
						else if (rec["NIPPANBUMON_CD"].ToString().Equals("2"))
						{
							f01m1VO.M1bumon2_yosan_kin = rec[colum_name].ToString();		// Ｍ１部門２予算額
							f01m1VO.M1bumon2_yosan_kin_hdn = rec[colum_name].ToString();	// Ｍ１部門２予算額(隠し)
						}
						else if (rec["NIPPANBUMON_CD"].ToString().Equals("3"))
						{
							f01m1VO.M1bumon3_yosan_kin = rec[colum_name].ToString();		// Ｍ１部門３予算額
							f01m1VO.M1bumon3_yosan_kin_hdn = rec[colum_name].ToString();	// Ｍ１部門３予算額(隠し)
						}
						else if (rec["NIPPANBUMON_CD"].ToString().Equals("4"))
						{
							f01m1VO.M1bumon4_yosan_kin = rec[colum_name].ToString();		// Ｍ１部門４予算額
							f01m1VO.M1bumon4_yosan_kin_hdn = rec[colum_name].ToString();	// Ｍ１部門４予算額(隠し)
						}
						else if (rec["NIPPANBUMON_CD"].ToString().Equals("5"))
						{
							f01m1VO.M1bumon5_yosan_kin = rec[colum_name].ToString();		// Ｍ１部門５予算額
							f01m1VO.M1bumon5_yosan_kin_hdn = rec[colum_name].ToString();	// Ｍ１部門５予算額(隠し)
						}

						if (rec["NIPPANBUMON_CD"].ToString().Equals("1")
							|| rec["NIPPANBUMON_CD"].ToString().Equals("2")
							|| rec["NIPPANBUMON_CD"].ToString().Equals("3")
							|| rec["NIPPANBUMON_CD"].ToString().Equals("4")
							|| rec["NIPPANBUMON_CD"].ToString().Equals("5"))
						{
							dHibetuGokei += Convert.ToDecimal(rec[colum_name]);
						}
					}

					// Ｍ１日別予算額
					f01m1VO.M1hibetu_yosan_kin = dHibetuGokei.ToString();

					f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;				// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;			// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;				// Ｍ１明細色区分(隠し)

					// リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// 月別部門(１～５)予算額
				// 部門(１～５)予算額合計
				f01VO.Tukibetu_bumon1_yosan_kin = string.Empty;
				f01VO.Tukibetu_bumon2_yosan_kin = string.Empty;
				f01VO.Tukibetu_bumon3_yosan_kin = string.Empty;
				f01VO.Tukibetu_bumon4_yosan_kin = string.Empty;
				f01VO.Tukibetu_bumon5_yosan_kin = string.Empty;
				f01VO.Bumon1_yosangokei_kin = "0";
				f01VO.Bumon2_yosangokei_kin = "0";
				f01VO.Bumon3_yosangokei_kin = "0";
				f01VO.Bumon4_yosangokei_kin = "0";
				f01VO.Bumon5_yosangokei_kin = "0";
				decimal dYosanGokei = 0;

				ArrayList upd_ymd_list = new ArrayList();
				ArrayList upd_tm_list = new ArrayList();
				for (int i = 0; i < 5; i++)
				{
					upd_ymd_list.Add(string.Empty);
					upd_tm_list.Add(string.Empty);
				}

				foreach (Hashtable rec in tableList)
				{
					if (rec["NIPPANBUMON_CD"].ToString().Equals("1"))
					{
						f01VO.Tukibetu_bumon1_yosan_kin = rec["YOSANGOKEI_KIN"].ToString();	// 月別部門１予算額
						f01VO.Bumon1_yosangokei_kin = rec["YOSANGOKEI_KIN"].ToString();		// 部門１予算額合計
						upd_ymd_list[0] = rec["UPD_YMD"].ToString();						// 更新日(部門１)
						upd_tm_list[0] = rec["UPD_TM"].ToString();							// 更新時間(部門１)
					}
					else if (rec["NIPPANBUMON_CD"].ToString().Equals("2"))
					{
						f01VO.Tukibetu_bumon2_yosan_kin = rec["YOSANGOKEI_KIN"].ToString();	// 月別部門２予算額
						f01VO.Bumon2_yosangokei_kin = rec["YOSANGOKEI_KIN"].ToString();		// 部門２予算額合計
						upd_ymd_list[1] = rec["UPD_YMD"].ToString();						// 更新日(部門２)
						upd_tm_list[1] = rec["UPD_TM"].ToString();							// 更新時間(部門２)
					}
					else if (rec["NIPPANBUMON_CD"].ToString().Equals("3"))
					{
						f01VO.Tukibetu_bumon3_yosan_kin = rec["YOSANGOKEI_KIN"].ToString();	// 月別部門３予算額
						f01VO.Bumon3_yosangokei_kin = rec["YOSANGOKEI_KIN"].ToString();		// 部門３予算額合計
						upd_ymd_list[2] = rec["UPD_YMD"].ToString();						// 更新日(部門３)
						upd_tm_list[2] = rec["UPD_TM"].ToString();							// 更新時間(部門３)
					}
					else if (rec["NIPPANBUMON_CD"].ToString().Equals("4"))
					{
						f01VO.Tukibetu_bumon4_yosan_kin = rec["YOSANGOKEI_KIN"].ToString();	// 月別部門４予算額
						f01VO.Bumon4_yosangokei_kin = rec["YOSANGOKEI_KIN"].ToString();		// 部門４予算額合計
						upd_ymd_list[3] = rec["UPD_YMD"].ToString();						// 更新日(部門４)
						upd_tm_list[3] = rec["UPD_TM"].ToString();							// 更新時間(部門４)
					}
					else if (rec["NIPPANBUMON_CD"].ToString().Equals("5"))
					{
						f01VO.Tukibetu_bumon5_yosan_kin = rec["YOSANGOKEI_KIN"].ToString();	// 月別部門５予算額
						f01VO.Bumon5_yosangokei_kin = rec["YOSANGOKEI_KIN"].ToString();		// 部門５予算額合計
						upd_ymd_list[4] = rec["UPD_YMD"].ToString();						// 更新日(部門５)
						upd_tm_list[4] = rec["UPD_TM"].ToString();							// 更新時間(部門５)
					}

					if (rec["NIPPANBUMON_CD"].ToString().Equals("1")
						|| rec["NIPPANBUMON_CD"].ToString().Equals("2")
						|| rec["NIPPANBUMON_CD"].ToString().Equals("3")
						|| rec["NIPPANBUMON_CD"].ToString().Equals("4")
						|| rec["NIPPANBUMON_CD"].ToString().Equals("5"))
					{
						dYosanGokei += Convert.ToDecimal(rec["YOSANGOKEI_KIN"]);
					}
				}

				// 月別予算額合計
				f01VO.Tukibetu_yosan_kin_gokei = dYosanGokei.ToString();
				// 予算額合計
				f01VO.Yosangokei_kin = dYosanGokei.ToString();

				// Dictionary
				f01VO.Dictionary[Tf060p01Constant.DIC_UPD_YMD_LIST] = upd_ymd_list;		// 更新日(配列)
				f01VO.Dictionary[Tf060p01Constant.DIC_UPD_TM_LIST] = upd_tm_list;		// 更新時間(配列)

				// 検索条件を退避
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

		#region 曜日取得
		/// <summary>
		/// getYobi 曜日取得
		/// </summary>
		/// <param name="date">日付</param>
		/// <returns></returns>
		private string getYobi(DateTime date)
		{
			string yobi;

			yobi = ("日月火水木金土").Substring(int.Parse(date.DayOfWeek.ToString("d")), 1);

			return yobi;
		}
		#endregion

	}
}
