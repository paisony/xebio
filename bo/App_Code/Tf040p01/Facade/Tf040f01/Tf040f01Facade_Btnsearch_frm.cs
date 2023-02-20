using com.xebio.bo.Tf040p01.Constant;
using com.xebio.bo.Tf040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tf040p01.Facade
{
  /// <summary>
  /// Tf040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf040f01Facade : StandardBaseFacade
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
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tf040f01Form f01VO = (Tf040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				//Dictionaryの初期化
				f01VO.Dictionary.Clear();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				#endregion

				#region 業務チェック
				// ヘッダ店舗コード
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

				#region 検索処理

				#region 検索条件取得

				// 営業日の取得
				SysDateVO chkSysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				Decimal decKeijoYmd = chkSysDateVO.Sysdate ;	// 計上日
				Decimal decDateAdjust = 0 ;						// 日付調整変数

				//Xebio以外の場合、[日付調整変数]に"1"を設定する。
				if (!CheckCompanyCls.IsXebio(logininfo.CopCd))
				{
					decDateAdjust = 1;
				}

				// 月次繰越件数、小口現金件数取得
				FindSqlResultTable rtGetCondition = FindSqlUtil.CreateFindSqlResultTable(Tf040p01Constant.SQL_ID_01, facadeContext.DBContext);

				#region バインド設定
				#region 月次繰越件数取得
				// 店舗コード
				rtGetCondition.BindValue(Tf040p01Constant.REP_TENPO_CD + "1", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
				// 計上日
				rtGetCondition.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "1", decKeijoYmd);
				// 日付調整変数
				rtGetCondition.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "1", decDateAdjust);
				#endregion

				#region 小口現金件数取得
				// 店舗コード
				rtGetCondition.BindValue(Tf040p01Constant.REP_TENPO_CD + "2", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));

				// 店舗コード
				rtGetCondition.BindValue(Tf040p01Constant.REP_TENPO_CD + "3", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
				// 計上日
				rtGetCondition.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "3",decKeijoYmd);
				// 日付調整変数
				rtGetCondition.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "3", decDateAdjust);
				#endregion
				#endregion

				// 検索結果を取得
				rtGetCondition.CreateDbCommand();
				IList<Hashtable> ConditionList = rtGetCondition.Execute();

				// 条件設定
				string strGetujiKurikosiCnt = string.Empty;	// 月次繰越件数
				string strKogutiGenkinCnt = string.Empty;	// 小口現金件数
				foreach (Hashtable rec in ConditionList)
				{
					strGetujiKurikosiCnt = rec["GETUJIKURIKOSICNT"].ToString();	
					strKogutiGenkinCnt = rec["KOGUTIGENKINCNT"].ToString();		
				}
				#endregion

				#region SQLID設定
				string strSqlID = string.Empty;
				// 今月に対応する小口現金繰越が存在し、かつ当月の小口現金が存在する
				if(!strGetujiKurikosiCnt.Equals("0") && !strKogutiGenkinCnt.Equals("0"))
				{
					strSqlID = Tf040p01Constant.SQL_ID_02;
				}
				// 今月に対応する小口現金繰越が存在し、かつ当月の小口現金も存在しない
				else if (!strGetujiKurikosiCnt.Equals("0") && strKogutiGenkinCnt.Equals("0"))
				{
					strSqlID = Tf040p01Constant.SQL_ID_03;
				}
				// 今月に対応する小口現金繰越が存在し、かつ当月の小口現金が存在する
				else if (strGetujiKurikosiCnt.Equals("0") && !strKogutiGenkinCnt.Equals("0"))
				{
					strSqlID = Tf040p01Constant.SQL_ID_04;
				}
				// 今月に対応する小口現金繰越が存在し、かつ当月の小口現金も存在しない
				else
				{
					strSqlID = Tf040p01Constant.SQL_ID_05;
				}
				#endregion

				#region 明細検索処理
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(strSqlID, facadeContext.DBContext);

				#region バインド設定

				switch (strSqlID)
				{
					case Tf040p01Constant.SQL_ID_02:
						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_MDAT0080", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_MDAT0070", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_MDAT0070", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_MDAT0070", decDateAdjust);

						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_KGS1", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_KGS1_1", decKeijoYmd);
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_KGS1_2", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_KGS1", decDateAdjust);	

						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_KGGK1", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_KGGK1", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_KGGK1", decDateAdjust);

						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD , BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD, decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST , decDateAdjust);
						break;

					case Tf040p01Constant.SQL_ID_03:
						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_MDAT0060", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_MDAT0060", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_MDAT0060", decDateAdjust);
						break;

					case Tf040p01Constant.SQL_ID_04:
						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_MDAT0080", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_MDAT0070", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_MDAT0070", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_MDAT0070", decDateAdjust);

						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_KGS1", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_KGS1_1", decKeijoYmd);
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_KGS1_2", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_KGS1", decDateAdjust);

						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_KGSZ1", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_KGSZ1", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_KGSZ1", decDateAdjust);

						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_KGGK1", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_KGGK1", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_KGGK1", decDateAdjust);

						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD, decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST, decDateAdjust);
						break;

					case Tf040p01Constant.SQL_ID_05:
						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_MDAT0070", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_MDAT0070_1", decKeijoYmd);
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_MDAT0070_2", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_MDAT0070_1", decDateAdjust);
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_MDAT0070_2", decDateAdjust);

						// 店舗コード
						rtSeach.BindValue(Tf040p01Constant.REP_TENPO_CD + "_MDAT0060", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
						// 計上日
						rtSeach.BindValue(Tf040p01Constant.REP_KEIJO_YMD + "_MDAT0060", decKeijoYmd);
						// 日付調整変数
						rtSeach.BindValue(Tf040p01Constant.REP_DATE_ADJUST + "_MDAT0060", decDateAdjust);
						break;
				}
				#endregion

				// 検索結果を取得
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				#endregion

				#region 明細表示件数設定
				decimal dSumZandaka = 0;				// 合計残高

				int iM1Cnt = tableList.Count;			// 明細件数(表示分の件数)
				int iDivCnt;							// 割り算回数

				// 表示する明細件数を設定
				if (iM1Cnt > Tf040p01Constant.PAGE_PER_COUNT)
				{
					// 明細件数が100で割り切れる場合、編集なし
					if (0 != iM1Cnt % Tf040p01Constant.PAGE_PER_COUNT)
					{
						// ページ単位で割って、左端の数字を取得
						for (iDivCnt = 0; ; iDivCnt++)
						{
                            if (iM1Cnt < Tf040p01Constant.PAGE_PER_COUNT)
                            {
                                break;
							}
							iM1Cnt /= Tf040p01Constant.PAGE_PER_COUNT;
						}

						iM1Cnt += 1;
						
						// 割った回数分掛ける
						for (int i = 0; i < iDivCnt; i++)
						{
							iM1Cnt *= m1List.DispRow;
						}
					}
				}
				else
				{
					iM1Cnt = Tf040p01Constant.PAGE_PER_COUNT;
				}
				#endregion

				#region カード部設定
				if ( tableList.Count != 0
					 && !string.IsNullOrEmpty(tableList[0]["ZENJITU_ZANDAKA"].ToString())
					 && !string.IsNullOrEmpty(tableList[0]["ZENGETU_ZANDAKA"].ToString()) )
				{
					f01VO.Zenjitu_zandaka = tableList[0]["ZENJITU_ZANDAKA"].ToString();	// 前日残高 
					f01VO.Zengetu_zandaka = tableList[0]["ZENGETU_ZANDAKA"].ToString();	// 前月残高 
				}
				else
				{
					f01VO.Zenjitu_zandaka = (0).ToString();
					f01VO.Zengetu_zandaka = (0).ToString();
				}
				dSumZandaka += Convert.ToDecimal(BoSystemString.Nvl(f01VO.Zengetu_zandaka, "0"));
				#endregion

				#region 明細部設定
				for (int iRow = 0; iRow < iM1Cnt; iRow++)
				{
					Tf040f01M1Form f04m1VO = new Tf040f01M1Form();

					f04m1VO.M1rowno	= 	(iRow + 1).ToString();										//Ｍ１行NO

					if ((  strSqlID.Equals(Tf040p01Constant.SQL_ID_02) 
						|| strSqlID.Equals(Tf040p01Constant.SQL_ID_04))
						&& tableList.Count > iRow)
					{
						f04m1VO.M1kanri_no = tableList[iRow]["KANRI_NO"].ToString();				//Ｍ１管理No
						f04m1VO.M1motokanri_no = tableList[iRow]["MOTOKANRI_NO"].ToString();		//Ｍ１元管理No
						f04m1VO.M1keijo_ymd = tableList[iRow]["KEIJO_YMD"].ToString();				//Ｍ１計上日付
						f04m1VO.M1kamoku_cd = tableList[iRow]["KAMOKU_CD"].ToString();				//Ｍ１科目コード
						f04m1VO.M1kamoku_nm = tableList[iRow]["KAMOKU_NM"].ToString();				//Ｍ１科目名

						// 入出金区分で表示をわける
						if (tableList[iRow]["NYUSYUKKIN_KB"].ToString().Equals(Tf040p01Constant.CONST_NYUKIN_KB))
						{
							f04m1VO.M1nyukin = tableList[iRow]["NYUKIN"].ToString();	// Ｍ１入金
							f04m1VO.M1syukkin = string.Empty;							// Ｍ１出金
						}
						else
						{
							f04m1VO.M1nyukin = string.Empty;							//Ｍ１入金
							f04m1VO.M1syukkin = tableList[iRow]["SYUKKIN"].ToString();	//Ｍ１出金
						}
						
						f04m1VO.M1tekiyou = tableList[iRow]["TEKIYOU"].ToString();					//Ｍ１摘要
						f04m1VO.M1hurikaetenpo_cd = tableList[iRow]["HURIKAETENPO_CD"].ToString();	//Ｍ１振替店舗コード
						f04m1VO.M1hurikaetenpo_nm = tableList[iRow]["TENPO_NM"].ToString();			//Ｍ１振替店舗名

						if (tableList[iRow]["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
						{
							f04m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;			// Ｍ１明細色区分(隠し)
						}
						else
						{
							f04m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;				// Ｍ１明細色区分(隠し)
						}

						// 隠し項目
						f04m1VO.M1nyukin_hdn = tableList[iRow]["NYUKIN"].ToString();					//Ｍ１入金(隠し)
						f04m1VO.M1syukkin_hdn = tableList[iRow]["SYUKKIN"].ToString();					//Ｍ１出金(隠し)

						// 合計値加算
						dSumZandaka += (Convert.ToDecimal(f04m1VO.M1nyukin_hdn) - Convert.ToDecimal(f04m1VO.M1syukkin_hdn));

					}
					else 
					{ 
						// 空白設定
						f04m1VO.M1kanri_no = string.Empty;			//Ｍ１管理No
						f04m1VO.M1motokanri_no = string.Empty;		//Ｍ１元管理No
						f04m1VO.M1keijo_ymd = sysDateVO.Sysdate.ToString();			//Ｍ１計上日付
						f04m1VO.M1kamoku_cd = string.Empty;			//Ｍ１科目コード
						f04m1VO.M1kamoku_nm = string.Empty;			//Ｍ１科目名
						f04m1VO.M1nyukin = string.Empty;			//Ｍ１入金
						f04m1VO.M1syukkin = string.Empty;			//Ｍ１出金
						f04m1VO.M1tekiyou = string.Empty;			//Ｍ１摘要
						f04m1VO.M1hurikaetenpo_cd = string.Empty;	//Ｍ１振替店舗コード
						f04m1VO.M1hurikaetenpo_nm = string.Empty;	//Ｍ１振替店舗名

						f04m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
					}

					f04m1VO.M1selectorcheckbox	= BoSystemConstant.CHECKBOX_OFF;			// Ｍ１選択フラグ(隠し)
					f04m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;			// Ｍ１確定処理フラグ(隠し)

					// 隠し項目
					f04m1VO.M1nyukin_hdn = (0).ToString();			//Ｍ１入金(隠し)
					f04m1VO.M1syukkin_hdn = (0).ToString();			//Ｍ１出金(隠し)

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f04m1VO, true);

				}
				#endregion

				// 合計欄の設定
				f01VO.Gokei_zandaka = dSumZandaka.ToString();

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				// Dictionary(行追加用)
				f01VO.Dictionary[Tf040p01Constant.DIC_SYSDATE] = sysDateVO.Sysdate.ToString();		// システム日付

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
	}
}
