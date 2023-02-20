using com.xebio.bo.Tk020p01.Constant;
using com.xebio.bo.Tk020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tk020p01.Facade
{
  /// <summary>
  /// Tk020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk020f01Facade : StandardBaseFacade
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
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tk020f01Form f01VO = (Tk020f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// Dictionaryの初期化
				f01VO.Dictionary.Clear();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				#region 業務チェック

				#region 単項目チェック[ヘッダ店舗コード]
				// 店舗マスタを検索し、存在しない場合エラー
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

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連チェック
				// 申請モード、再申請モードの場合、１日２回以上行った場合エラー
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_APPLY) || f01VO.Modeno.Equals(BoSystemConstant.MODE_REAPPLY))
				{
					// 件数カウント
					FindSqlResultTable rtCnt = FindSqlUtil.CreateFindSqlResultTable(Tk020p01Constant.SQL_ID_04, facadeContext.DBContext);

					// バインド値の置き換え
					// [店舗コード]
					rtCnt.BindValue(Tk020p01Constant.SQL_ID_04_REP_TENPO_CD, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// [申請日]
					rtCnt.BindValue(Tk020p01Constant.SQL_ID_04_REP_APPLY_YMD, sysDateVO.Sysdate);
					// [再申請フラグ]
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_APPLY))
					{
						//	申請モードの場合、０（申請）
						rtCnt.BindValue(Tk020p01Constant.SQL_ID_04_REP_SAISHINSEI_FLG, 0);
					}
					else
					{
						//	再申請モードの場合、１（再申請）
						rtCnt.BindValue(Tk020p01Constant.SQL_ID_04_REP_SAISHINSEI_FLG, 1);
					}

					// 回数を取得
					rtCnt.CreateDbCommand();
					IList<Hashtable> tableCntList = rtCnt.Execute();

					// 検索条件設定
					string strCheckFlg = string.Empty;
					foreach (Hashtable rec in tableCntList)
					{
						strCheckFlg = rec["CNT"].ToString();
					}

					// １日２回以上行った場合エラー
					if(int.Parse(strCheckFlg) >= 1)
					{
						// 申請・再申請処理は1日各1回ずつ可能です。翌日以降再申請を行って下さい。
						ErrMsgCls.AddErrMsg("E196", string.Empty, facadeContext);
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

				FindSqlResultTable rtSeach;

				#region [選択モードNo]が「申請」「修正」の場合、評価損申請TBLから検索
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_APPLY) || f01VO.Modeno.Equals(BoSystemConstant.MODE_UPD))
				{
					// SQL作成
					rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tk020p01Constant.SQL_ID_01, facadeContext.DBContext);

					// バインド値の置き換え
					// [店舗コード]
					rtSeach.BindValue(Tk020p01Constant.SQL_ID_01_REP_TENPO_CD, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// [処理日]
					if (!string.IsNullOrEmpty(f01VO.Syori_ym))
					{ 
						rtSeach.BindValue(Tk020p01Constant.SQL_ID_01_REP_SYORI_YMD, f01VO.Syori_ym.Substring(0,6) + "__");
					}
					else
					{
						rtSeach.BindValue(Tk020p01Constant.SQL_ID_01_REP_SYORI_YMD, "________");
					}
					// [申請フラグ]
					rtSeach.BindValue(Tk020p01Constant.SQL_ID_01_REP_SAISHINSEI_FLG, 0);
				}
				#endregion

				#region [選択モードNo]が「再申請」「照会」の場合、評価損確定TBLと評価損申請TBLから検索
				else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_REAPPLY) || f01VO.Modeno.Equals(BoSystemConstant.MODE_REF))
				{
					// SQL作成
					rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tk020p01Constant.SQL_ID_02, facadeContext.DBContext);

					// バインド値の置き換え
					// [選択モードNo]
					rtSeach.BindValue(Tk020p01Constant.SQL_ID_02_MODE, f01VO.Modeno);
					// 「照会」モード
					rtSeach.BindValue(Tk020p01Constant.SQL_ID_02_CONS_MODEREF, BoSystemConstant.MODE_REF);
					// [店舗コード]
					rtSeach.BindValue(Tk020p01Constant.SQL_ID_02_REP_TENPO_CD, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// [処理日]
					if (!string.IsNullOrEmpty(f01VO.Syori_ym))
					{
						rtSeach.BindValue(Tk020p01Constant.SQL_ID_02_REP_SYORI_YMD, f01VO.Syori_ym.Substring(0, 6) + "__");
					}
					else
					{
						rtSeach.BindValue(Tk020p01Constant.SQL_ID_01_REP_SYORI_YMD, "________");
					}

					// 条件設定
					AddWhere(f01VO, rtSeach, Tk020p01Constant.SQL_ID_02);
				}
				#endregion

				#region[選択モードNo]が「決裁状況」の場合、評価損確定TBLと評価損申請TBLから検索
				//else if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KESSAIJYOKYO))
				else
				{
					// SQL作成
					rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tk020p01Constant.SQL_ID_03, facadeContext.DBContext);

					// バインド値の置き換え
					// [店舗コード1]
					rtSeach.BindValue(Tk020p01Constant.SQL_ID_03_REP_TENPO_CD + "1", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// [店舗コード2]
					rtSeach.BindValue(Tk020p01Constant.SQL_ID_03_REP_TENPO_CD + "2", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));

					// [申請日1]
					// [申請日2]
					if (!string.IsNullOrEmpty(f01VO.Syori_ym))
					{
						rtSeach.BindValue(Tk020p01Constant.SQL_ID_03_REP_SYORI_YMD + "1", f01VO.Syori_ym.Substring(0, 6) + "__");
						rtSeach.BindValue(Tk020p01Constant.SQL_ID_03_REP_SYORI_YMD + "2", f01VO.Syori_ym.Substring(0, 6) + "__");
					}
					else
					{
						rtSeach.BindValue(Tk020p01Constant.SQL_ID_03_REP_SYORI_YMD + "1", "________");
						rtSeach.BindValue(Tk020p01Constant.SQL_ID_03_REP_SYORI_YMD + "2", "________");
					}
					
					// 条件設定
					AddWhere(f01VO, rtSeach, Tk020p01Constant.SQL_ID_03);

				}
				#endregion

				// ソート条件を設定
				AddOrder(f01VO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				#endregion

				#region 件数をチェック
				Decimal dCnt = tableList.Count;
				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					// 0件チェック
					if (tableList.Count <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						// 最大件数チェック
						V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), tableList.Count, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// 検索件数の設定
				f01VO.Searchcnt = dCnt.ToString();
				#endregion

				#region 画面の表示
				int iCnt = 0;
				decimal dSumSu = 0;		// 合計数量
				decimal dSumGenTnk = 0;	// 原価金額合計
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tk020f01M1Form f01m1VO = new Tk020f01M1Form();

					f01m1VO.M1rowno = iCnt.ToString();									// Ｍ１行NO
					f01m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();					// Ｍ１部門コード
					f01m1VO.M1hinsyu_cd = rec["HINSYU_CD"].ToString();					// Ｍ１品種コード
					f01m1VO.M1burando_nm = rec["BURANDOKANA"].ToString();				// Ｍ１ブランド名
					f01m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();					// Ｍ１自社品番
					f01m1VO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();	// Ｍ１販売完了日
					f01m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();					// Ｍ１メーカー品番
					f01m1VO.M1syonmk = rec["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					f01m1VO.M1scan_cd = rec["JAN_CD"].ToString();						// Ｍ１スキャンコード
					f01m1VO.M1iro_nm = rec["COLORNM"].ToString();						// Ｍ１色
					f01m1VO.M1size_nm = rec["SIZE_NM"].ToString();						// Ｍ１サイズ
					f01m1VO.M1genbaika_tnk = rec["JODAI1_TNK"].ToString();				// Ｍ１現売価
					f01m1VO.M1hyokason_su = rec["HYOKASON_SU"].ToString();				// Ｍ１数量
					f01m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();						// Ｍ１原単価
					f01m1VO.M1haibun_kin = (int.Parse(f01m1VO.M1hyokason_su) * int.Parse(f01m1VO.M1gen_tnk)).ToString();		// Ｍ１原価金額

					// Ｍ１入力日
					// Ｍ１入力者コード
					// 決裁状況の場合、登録日の項目名が異なる
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KESSAIJYOKYO))
					{
						f01m1VO.M1nyuryoku_ymd = BoSystemFormat.formatDate_yyMMdd(rec["ADD_YMD060"].ToString());
						f01m1VO.M1nyuryokusha_cd = rec["ADDTAN_CD060"].ToString();
					}
					else
					{
						f01m1VO.M1nyuryoku_ymd = BoSystemFormat.formatDate_yyMMdd(rec["ADD_YMD"].ToString());
						f01m1VO.M1nyuryokusha_cd = rec["ADDTAN_CD"].ToString();
					}
					if (rec["APPLY_YMD"].ToString() == "0")
					{
						f01m1VO.M1apply_ymd = "";
						f01m1VO.M1sinseisya_cd = "";
					}
					else
					{
						f01m1VO.M1apply_ymd = BoSystemFormat.formatDate_yyMMdd(rec["APPLY_YMD"].ToString());						// Ｍ１申請日
						f01m1VO.M1sinseisya_cd = rec["UPD_TANCD"].ToString();					// Ｍ１申請者コード
					}
					
					f01m1VO.M1hyokasonsyubetsu_kb = rec["HYOKASONSYUBETSU_KB"].ToString();	// Ｍ１評価損種別区分
					f01m1VO.M1hyokasonriyu_kb = rec["HYOKASONRIYU_KB"].ToString();			// Ｍ１評価損理由区分
					f01m1VO.M1hyokasonriyu = rec["HYOKASONRIYU"].ToString();				// Ｍ１評価損理由

					// Ｍ１却下理由
					/* [評価損確定TBL].[却下理由区分]が「その他」の場合、[評価損確定TBL].「却下理由」のみ表示。					*
					 * それ以外の場合、識別コード＝"HKKR"、名称コード＝[評価損確定TBL].[却下理由区分]をキーに検索した名称名と	*
					 * [評価損確定TBL].「却下理由」を結合して表示。																*/
					if (rec["KYAKKARIYU_KB"].ToString().Equals(ConditionKyakkariyu_kbn.VALUE_KYAKKARIYU_KBN5))
					{
						f01m1VO.M1kyakkariyu = rec["KYAKKARIYU"].ToString();
					}
					else
					{
						f01m1VO.M1kyakkariyu = rec["KYAKKARIYU_NM"].ToString() + " " + rec["KYAKKARIYU"].ToString();
					}
					
					// Ｍ１調達区分名称
					// [調達区分]の下1桁が1以上4以下の場合、"NB"を設定、それ以外の場合、空白
					int ilen = rec["TYOTATSU_KB"].ToString().Length;
					if (int.Parse(rec["TYOTATSU_KB"].ToString().Substring(ilen-1, 1)) >= 1
						&& int.Parse(rec["TYOTATSU_KB"].ToString().Substring(ilen - 1, 1)) <= 4)
					{
						f01m1VO.M1tyotatsu_nm = ("NB").ToString();
					}
					else
					{
						f01m1VO.M1tyotatsu_nm = string.Empty;
					}

					// 再申請モードの場合空白
					if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_REAPPLY))
					{
						f01m1VO.M1syonin_nm = rec["SYONIN_NM"].ToString();						// Ｍ１承認状態名称
					}
					f01m1VO.M1hyokason_su_hdn = f01m1VO.M1hyokason_su;						// Ｍ１数量(隠し)
					f01m1VO.M1haibun_kin_hdn = f01m1VO.M1haibun_kin;						// Ｍ１原価金額(隠し)
					f01m1VO.M1selectorcheckbox = (0).ToString();							// Ｍ１選択フラグ(隠し)
					f01m1VO.M1entersyoriflg = (0).ToString();								// Ｍ１確定処理フラグ(隠し)
					// Ｍ１明細色区分(隠し)
					if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;
					}
					else
					{
						f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					}

					// Dictionary設定
					#region 明細表示用
					string strSyonin = string.Empty; // 決裁状態区分
					string strKessai = string.Empty; // 承認状態区分

					// [決裁状態区分] = 評価損申請ＴＢＬ参照時：[決裁状態]	、評価損確定TBL参照時：	1(決裁済み)
					// [承認状態区分] = 評価損申請ＴＢＬ参照時：0			、評価損確定TBL参照時：	[承認状態]
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_APPLY) || f01VO.Modeno.Equals(BoSystemConstant.MODE_UPD))
					{
						// 評価損申請ＴＢＬ参照時
						strSyonin = rec["SYONIN_FLG"].ToString();
						strKessai = (0).ToString();
					}
					else 
					{
						// 評価損確定ＴＢＬ参照時
						strSyonin = (1).ToString();
						strKessai = rec["SYONIN_FLG"].ToString();
					}
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_KESSAI_JOTAI_KB, strSyonin);
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_SYONIN_JOTAI_KB, strKessai);
					#endregion

					#region 排他用、更新用、チェック用
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_TENPO_CD, f01VO.Head_tenpo_cd);						// [店舗コード]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_SAISHINSEI_FLG, rec["SAISHINSEI_FLG"].ToString());	// [Ｍ１再申請フラグ]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_UPD_YMD, rec["UPD_YMD"].ToString());				// [Ｍ１更新日]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_UPD_TM, rec["UPD_TM"].ToString());					// [Ｍ１更新時間]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_KANRI_NO, rec["KANRI_NO"].ToString());				// [Ｍ１管理No]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_SYORI_YMD, rec["SYORI_YMD"].ToString());			// [Ｍ１処理日付]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_SYORI_TM, rec["SYORI_TM"].ToString());				// [Ｍ１処理時間]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_GYO_NBR, rec["GYO_NBR"].ToString());				// [Ｍ１行No]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_BURANDO_CD, rec["BURANDO_CD"].ToString());			// [Ｍ１ブランドコード]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_IRO_CD, rec["IRO_CD"].ToString());					// [Ｍ１色コード]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_SIZE_CD, rec["SIZE_CD"].ToString());				// [Ｍ１サイズコード]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_SYOHIN_CD, rec["SYOHIN_CD"].ToString());			// [Ｍ１商品コード]

					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_BUMON_CD, rec["BUMON_CD"].ToString());							// [部門コード]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HINSYU_CD, rec["HINSYU_CD"].ToString());						// [品種コード]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_MAKER_HBN, rec["MAKER_HBN"].ToString());						// [メーカー品番]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_SYONMK, rec["SYONMK"].ToString());								// [商品名(カナ)]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_JISYA_HBN, rec["JISYA_HBN"].ToString());						// [自社品番]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_JAN_CD, rec["JAN_CD"].ToString());								// [ＪＡＮコード]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HYOKASON_SU, rec["HYOKASON_SU"].ToString());					// [評価損数量]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HANBAIKANRYO_YMD, rec["HANBAIKANRYO_YMD"].ToString());			// [販売完了日]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_SIZE_NM, rec["SIZE_NM"].ToString());							// [サイズ名]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_GEN_TNK, rec["GEN_TNK"].ToString());							// [原単価]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_JODAI1_TNK, rec["JODAI1_TNK"].ToString());						// [上代1]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HYOKASONSYUBETSU_KB, rec["HYOKASONSYUBETSU_KB"].ToString());	// [評価損種別区分]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HYOKASONRIYU_KB, rec["HYOKASONRIYU_KB"].ToString());			// [評価損理由区分]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HYOKASONRIYU, rec["HYOKASONRIYU"].ToString());					// [評価損理由]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_APPLY_YMD, rec["APPLY_YMD"].ToString());						// [申請日]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_TYOTATSU_KB, rec["TYOTATSU_KB"].ToString());					// [調達区分]

					// ツールチップ
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_BUMON_NM, rec["BUMONNM"].ToString());		// [部門名]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HINSYU_NM, rec["HINSYUNM"].ToString());		// [品種略名称]

					// [登録日]
					// [登録時間]
					// [登録担当者コード]
					// 決裁状況の場合、登録日の項目名が異なる
					if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KESSAIJYOKYO))
					{
						f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_ADD_YMD, rec["ADD_YMD060"].ToString());
						f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_ADD_TM, rec["ADD_TM060"].ToString());
						f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_ADDTAN_CD, rec["ADDTAN_CD060"].ToString());
					}
					else
					{
						f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_ADD_YMD, rec["ADD_YMD"].ToString());
						f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_ADD_TM, rec["ADD_TM"].ToString());
						f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_ADDTAN_CD, rec["ADDTAN_CD"].ToString());
					}

					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HHTSERIAL_NO, rec["HHTSERIAL_NO"].ToString());					// [HHTシリアル番号]
					f01m1VO.Dictionary.Add(Tk020p01Constant.DIC_HHTSEQUENCE_NO, rec["HHTSEQUENCE_NO"].ToString());				// [HHTシーケンスNo.]
					#endregion

					#region フッタ部計算
					// 合計数量
					dSumSu += (Convert.ToDecimal(f01m1VO.M1hyokason_su));

					// 原価金額合計
					dSumGenTnk += (Convert.ToDecimal(f01m1VO.M1haibun_kin));
					#endregion

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}
				#endregion

				// モードNoを選択モードNoへ設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// [選択モードNo]が「決裁状況」「照会」以外の場合、チェックなしにする
				if (!(f01VO.Modeno.Equals(BoSystemConstant.MODE_KESSAIJYOKYO) || f01VO.Modeno.Equals(BoSystemConstant.MODE_REF)))
				{
					f01VO.Kyakka_flg = BoSystemConstant.CHECKBOX_OFF; // 却下フラグ
				}

				// 合計数量の設定
				f01VO.Gokei_suryo = dSumSu.ToString();

				// 原価金額合計の設定
				f01VO.Haibun_kin_gokei = dSumGenTnk.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);
				f01VO.Dictionary.Add(Tk020p01Constant.DIC_SYSDATE, sysDateVO.Sysdate.ToString());

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

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="f01VO">Td010f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
		private void AddWhere(Tk020f01Form f01VO, FindSqlResultTable reader, String sql_id)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql1 = new StringBuilder();
			StringBuilder sRepSql2 = new StringBuilder();
			StringBuilder sRepSql3 = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------
			if(sql_id.Equals(Tk020p01Constant.SQL_ID_02))
			{
				#region 承認状態
				// [選択モードNo]が「再申請」の場合、または、「照会」の場合で[却下フラグ]=1の場合
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_REAPPLY)
					 || (f01VO.Modeno.Equals(BoSystemConstant.MODE_REF) && f01VO.Kyakka_flg.Equals(BoSystemConstant.CHECKBOX_ON))
					)
				{
					sRepSql1.Append(" AND IT070.SYONIN_FLG = 2 ");
					BoSystemSql.AddSql(reader, Tk020p01Constant.REPLACE_ID_SYONIN_FLG, sRepSql1.ToString(), bindList);
				}
				#endregion

				#region 再申請済みフラグ
				// [選択モードNo]が「再申請」の場合
				if (f01VO.Modeno.Equals(BoSystemConstant.MODE_REAPPLY))
				{
					sRepSql2.Append(" AND IT070.SAISHINSEIZUMI_FLG = 0 ");
					BoSystemSql.AddSql(reader, Tk020p01Constant.REPLACE_ID_SAISHINSEIZUMI_FLG, sRepSql2.ToString(), bindList);
				}
				#endregion
			}
			else
			{
				#region 却下データのみ
				// [却下フラグ]=1の場合
				if (f01VO.Kyakka_flg.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					sRepSql1.Append(" AND IT070.SYONIN_FLG = 2 ");
					BoSystemSql.AddSql(reader, Tk020p01Constant.REPLACE_ID_SYONIN_FLG, sRepSql1.ToString(), bindList);
				}
				#endregion
			}

			// 決済状況かつ却下フラグありの場合、申請テーブルは見ない
			if (sql_id.Equals(Tk020p01Constant.SQL_ID_03)
				&& f01VO.Kyakka_flg.Equals(BoSystemConstant.CHECKBOX_ON))
			{
				sRepSql3.Append(" AND 1 = 0 ");
				BoSystemSql.AddSql(reader, Tk020p01Constant.SQL_ID_03_REPLACE_ID_KYAKKA_FLG, sRepSql3.ToString());
			}
			else if (sql_id.Equals(Tk020p01Constant.SQL_ID_03))
			{
				sRepSql3.Append(" AND 1 = 1");
				BoSystemSql.AddSql(reader, Tk020p01Constant.SQL_ID_03_REPLACE_ID_KYAKKA_FLG, sRepSql3.ToString());
			}
			else
			{
				// 条件なし
			}

		}
		#endregion

		#endregion

		#region 明細ソート条件設定
		/// <summary>
		/// REPLACE_ID_ORDER_BY 検索条件設定
		/// </summary>
		/// <param name="f01VO">Tk020f01Form</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <returns></returns>
		private void AddOrder(Tk020f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定

			// ソート条件を設定 -----------
			switch (f01VO.Meisai_sort)
			{
				// 登録順
				case ConditionMeisai_sort_tk020f01.VALUE_MEISAI_SORT_TK020F011:

					// [選択モードNo]が「決裁状況」の場合、T2,T1のソート順が含まれる
					if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_KESSAIJYOKYO))
					{ 
						sRepSql.Append(" ADD_YMD DESC ");		// [評価損申請TBL].[登録日]
						sRepSql.Append(" ,ADD_TM DESC ");		// [評価損申請TBL].[登録時間]
					}
					else
					{
						sRepSql.Append(" ADD_YMD060 DESC ");	// [評価損申請TBL].[登録日]
						sRepSql.Append(" ,ADD_TM060 DESC ");	// [評価損申請TBL].[登録時間]
					}
					sRepSql.Append(" ,GYO_NBR ");				// T1.[行№]
					sRepSql.Append(" ,BUMON_CD ");				// T1.[部門コード]
					sRepSql.Append(" ,HINSYU_CD ");				// T1.[品種コード]
					sRepSql.Append(" ,BURANDO_CD ");			// T1.[ブランドコード]
					sRepSql.Append(" ,MAKER_HBN ");				// T1.[メーカー品番]

					break;

				// メーカ品番順
				case ConditionMeisai_sort_tk020f01.VALUE_MEISAI_SORT_TK020F012:
					sRepSql.Append(" MAKER_HBN ");		// T1.[メーカー品番]
					sRepSql.Append(" ,BUMON_CD ");		// T1.[部門コード]
					sRepSql.Append(" ,HINSYU_CD ");		// T1.[品種コード]
					sRepSql.Append(" ,BURANDO_CD ");	// T1.[ブランドコード]
					
					break;

				// 入力者／メーカ品番順
				case ConditionMeisai_sort_tk020f01.VALUE_MEISAI_SORT_TK020F013:
					// [選択モードNo]が「決裁状況」の場合、T2,T1のソート順が含まれる
					if (!f01VO.Modeno.Equals(BoSystemConstant.MODE_KESSAIJYOKYO))
					{
						sRepSql.Append(" ADDTAN_CD ");		// T1.[登録担当者コード]
					}
					else
					{
						sRepSql.Append(" ADDTAN_CD060 ");	// T1.[登録担当者コード]
					}
					sRepSql.Append(" ,MAKER_HBN ");			// T1.[メーカー品番]
					sRepSql.Append(" ,BUMON_CD ");			// T1.[部門コード]
					sRepSql.Append(" ,HINSYU_CD ");			// T1.[品種コード]
					sRepSql.Append(" ,BURANDO_CD ");		// T1.[ブランドコード]

					break;
				
				// 調達順
				case ConditionMeisai_sort_tk020f01.VALUE_MEISAI_SORT_TK020F014:
					sRepSql.Append(" TYOTATSU_KB ");	// T1.[調達区分]
					sRepSql.Append(" ,BUMON_CD ");		// T1.[部門コード]
					sRepSql.Append(" ,HINSYU_CD ");		// T1.[品種コード]
					sRepSql.Append(" ,BURANDO_CD ");	// T1.[ブランドコード]
					sRepSql.Append(" ,MAKER_HBN ");		// T1.[メーカー品番]
					
					break;
			}

			// [選択モードNo]が「決裁状況」の場合、テーブルソートが含まれる
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_KESSAIJYOKYO))
			{
				sRepSql.Append(" ,TBL_SORT ");		// テーブル順

			}

			BoSystemSql.AddSql(reader, Tk020p01Constant.REP_ADD_ORDER, sRepSql.ToString(), bindList);
			#endregion

		}
		#endregion
	}
}
