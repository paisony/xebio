using com.xebio.bo.Te060p01.Constant;
using com.xebio.bo.Te060p01.Formvo;
using com.xebio.bo.Te060p01.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DateUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01010;
using Common.Business.V03000.V03001;
using Common.Business.V03000.V03003;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Te060p01.Facade
{
  /// <summary>
  /// Te060f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Te060f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Te060p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Te060f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Te060f01Facade()
			: base()
		{
		}
		#endregion

		#region Te060f01画面データを作成する。
		/// <summary>
		/// Te060f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。
				//カード部を取得します。
				Te060f01Form te060f01Form = (Te060f01Form)facadeContext.FormVO;
				if (string.IsNullOrEmpty(te060f01Form.Modeno))
				{
					// ソート順設定
					te060f01Form.Sort_jun = ConditionSainyukabosi_jun.VALUE_SAINYUKABOSI_JUN1;
					// システム日付取得
					SysDateVO sysDateVO = new SysDateVO();
					sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
					te060f01Form.Hanbaikanryo_ymd = Te060p01Util.GetHanbaikanryoYmdInit(sysDateVO);
				}
			//	//モデル層処理ロジックを記述してください。
			//	//カード部 データを取得(要実装)........
				
			//	//M1明細部のデータを作成します。
			//	DoM1ListLoad(facadeContext);
				
			}
			catch (System.Exception ex)
			{
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
		}
		#endregion
		#region M1明細部データの作成をする。
		/// <summary>
		/// M1明細部データの作成をする。
		/// 明細ID(M1)の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ListLoad(IFacadeContext facadeContext)
		{
			//このメソッドは、M1の明細のデータを生成するために、
			//画面のLoad処理と改ページ処理で呼ばれます。
			//コネクションの開始・終了は呼び出しもとのメソッドで管理されます。
			//必要な処理を実装してください。
			
		}
		#endregion

		#region 検索単項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te060f01Form">f01VO</param>
		/// <returns>Decimal</returns>
		private void ChkSelSingleItem ( IFacadeContext facadeContext, Te060f01Form f01VO )
		{
			#region 単項目チェック
			// 1-1 ヘッダ店舗コード
			//       店舗マスタを検索し、存在しない場合エラー
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
			// 1-2 商品群１
			//       商品群１マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Syohingun1_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01008Check.CheckSyohingun(f01VO.Syohingun1_cd
														, facadeContext
														, string.Empty
														, null
														, "商品群１"
														, new[] { "Syohingun1_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Syohingun1_ryaku_nm = (string)resultHash["SYOHINGUN1_RYAKU_NM"];
				}
			}
			// 1-3 仕入先コード
			//       仕入先マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01002Check.CheckShiiresaki(f01VO.Siiresaki_cd
														, facadeContext
														, string.Empty
														, null
														, "仕入先"
														, new[] { "Siiresaki_cd" }
														, null
														, null
														, null
														, 0
														, 0
														);
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Siiresaki_ryaku_nm = (string)resultHash["SIIRESAKI_RYAKU_NM"];
				}
			}
			// 1-4 部門コード
			//       部門マスタを検索し、存在しない場合エラー
			if (!string.IsNullOrEmpty(f01VO.Bumon_cd))
			{
				Hashtable resultHash = new Hashtable();
				resultHash = V01010Check.CheckBumon(f01VO.Bumon_cd
													, facadeContext
													, string.Empty
													, null
													, "部門"
													, new[] { "Bumon_cd" }
													, null
													, null
													, null
													, 0
													, 0
													);
				// 名称をラベルに設定
				if (resultHash != null)
				{
					f01VO.Bumon_nm = (string)resultHash["BUMON_NM"];
				}
			}
			#endregion
		}
		#endregion
		#region 検索関連項目チェック
		/// <summary>
		/// ChkSelSingleItem 検索関連項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te060f01Form">f01VO</param>
		/// <returns>Decimal</returns>
		private void ChkSelRelatedItem ( IFacadeContext facadeContext, Te060f01Form f01VO )
		{
			#region 関連項目チェック
			// 2-1　モードNOが「修正」で、削除区分が「無効」の場合
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_UPD)
			  && ConditionSakujo_kbn.VALUE_SAKUJO_KBN2.Equals(f01VO.Sakujo_kbn))
			{
				ErrMsgCls.AddErrMsg("E199", "修正", facadeContext, new[] { "Sakujo_kbn" });
			}

			// 2-2 モードNOが「取消」で、削除区分が「無効」の場合
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_DEL)
			  && ConditionSakujo_kbn.VALUE_SAKUJO_KBN2.Equals(f01VO.Sakujo_kbn))
			{
				ErrMsgCls.AddErrMsg("E199", "取消", facadeContext, new[] { "Sakujo_kbn" });
			}

			// 2-3 登録日ＦＲＯＭ > 登録日ＴＯの場合エラー
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_from) && !string.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				V03001Check.DateFromToChk(
								f01VO.Add_ymd_from,
								f01VO.Add_ymd_to,
								facadeContext,
								"登録日",
								new[] { "Add_ymd_from", "Add_ymd_to" }
								);
			}
			#endregion
		}
		#endregion
		#region 件数チェック
		/// <summary>
		/// ChkCount 件数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IList<Hashtable>">tableListcnt</param>
		/// <returns>Decimal</returns>
		private Decimal ChkCount ( IFacadeContext facadeContext, IList<Hashtable> tableListcnt )
		{
			Hashtable resultTbl = tableListcnt[0];
			Decimal dCnt = (Decimal)resultTbl["CNT"];
			if (tableListcnt == null || tableListcnt.Count <= 0)
			{
				// エラー
				ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
			}
			else
			{

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
			return dCnt;
		}
		#endregion
		#region 検索処理
		/// <summary>
		/// DoSelect 検索処理
		/// </summary>
		/// <param name="Te060f01Form">f01VO</param>
		/// <param name="IDBContext">DBContext</param>
		/// <param name="blCount">blCount</param>
		/// <returns>IList<Hashtable></returns>
		private IList<Hashtable> DoSelect ( Te060f01Form f01VO, IDBContext DBContext, bool blCount )
		{
			FindSqlResultTable rtSearch = null;
			if (blCount)
			{
				// 件数取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te060p01Constant.SQL_ID_01, DBContext);
			}
			else
			{
				// 検索結果取得
				rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te060p01Constant.SQL_ID_02, DBContext);
			}

			// 検索条件設定
			SetBind(f01VO, rtSearch, blCount);

			//検索結果を取得します
			rtSearch.CreateDbCommand();
			IList<Hashtable> result = rtSearch.Execute();
			BoSystemLog.logOut("SQL: " + rtSearch.LogSql);
			return result;
		}
		#endregion
		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Te060f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">rtChk</param>
		/// <param name="blCount">blCount</param>
		/// <returns></returns>
		private void SetBind ( Te060f01Form f01VO, FindSqlResultTable reader, bool blCount )
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			#region 検索条件設定
			// 検索結果取得の場合
			if (!blCount)
			{
				// 登録区分を設定
				reader.BindValue("BIND_SIKIBETSU_CD", Te060p01Constant.SIKIBETSU_CD_ADKB);
			}
			// 店舗コードを設定
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD").AppendLine();

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 商品群1コードを設定
			if (!string.IsNullOrEmpty(f01VO.Syohingun1_cd))
			{
				sRepSql.Append(" AND T1.SYOHINGUN1_CD = :BIND_SYOHINGUN1").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYOHINGUN1";
				bindVO.Value = f01VO.Syohingun1_cd;
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 仕入先コードを設定
			if (!string.IsNullOrEmpty(f01VO.Siiresaki_cd))
			{
				sRepSql.Append(" AND T1.SIIRESAKI_CD = :BIND_SIIRESAKI_CD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 部門コードを設定
			if (!string.IsNullOrEmpty(f01VO.Bumon_cd))
			{
				sRepSql.Append(" AND T1.BUMON_CD = :BIND_BUMON_CD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BUMON_CD";
				bindVO.Value = BoSystemFormat.formatBumonCd(f01VO.Bumon_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 販売完了日を設定
			if (!string.IsNullOrEmpty(f01VO.Hanbaikanryo_ymd))
			{
				sRepSql.Append(" AND T1.HANBAIKANRYO_YMD >= :BIND_HANBAIKANRYO_YMD").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_HANBAIKANRYO_YMD";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Hanbaikanryo_ymd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日FROMを設定
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_from))
			{
				sRepSql.Append(" AND T1.UPD_YMD >= :BIND_UPD_YMD_FROM").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_FROM";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 登録日TOを設定
			if (!string.IsNullOrEmpty(f01VO.Add_ymd_to))
			{
				sRepSql.Append(" AND T1.UPD_YMD <= :BIND_UPD_YMD_TO").AppendLine();

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_UPD_YMD_TO";
				bindVO.Value = BoSystemFormat.formatDate(f01VO.Add_ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
			}

			// 削除区分が「有効」の場合
			if (!BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(f01VO.Sakujo_kbn))
			{
				sRepSql.Append(" AND T1.SAKUJYO_FLG = ").Append(f01VO.Sakujo_kbn).AppendLine();
			}
			#endregion
			#region ソート順番設定
			if (!blCount)
			{
				// [ソート順]が「部門/ブランド/メーカー品番順」の場合
				if (ConditionSainyukabosi_jun.VALUE_SAINYUKABOSI_JUN1.Equals(f01VO.Sort_jun))
				{
					sRepSql.Append(" ORDER BY ").AppendLine();
					sRepSql.Append("     T1.BUMON_CD ").AppendLine();				// 部門コード
					sRepSql.Append("    ,T1.HINSYU_CD ").AppendLine();				// 品種コード
					sRepSql.Append("    ,T1.BURANDO_CD ").AppendLine();				// ブランドコード
					sRepSql.Append("    ,T1.MAKER_HBN ").AppendLine();				// メーカー品番
					sRepSql.Append("    ,T1.IRO_CD ").AppendLine();					// 色コード
				}
				// [ソート順]が「登録日順」の場合
				else if (ConditionSainyukabosi_jun.VALUE_SAINYUKABOSI_JUN2.Equals(f01VO.Sort_jun))
				{
					sRepSql.Append(" ORDER BY ").AppendLine();
					sRepSql.Append("     T1.UPD_YMD DESC ").AppendLine();			// 更新日 降順
					sRepSql.Append("    ,T1.BUMON_CD ").AppendLine();				// 部門コード
					sRepSql.Append("    ,T1.HINSYU_CD ").AppendLine();				// 品種コード
					sRepSql.Append("    ,T1.BURANDO_CD ").AppendLine();				// ブランドコード
					sRepSql.Append("    ,T1.MAKER_HBN ").AppendLine();				// メーカー品番
					sRepSql.Append("    ,T1.IRO_CD ").AppendLine();					// 色コード

				}
			}
			BoSystemSql.AddSql(reader, Te060p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
			#endregion

		}

		#endregion
		#region 転記処理(検索結果)
		/// <summary>
		/// DoCopy 明細転記処理
		/// </summary>
		/// <param name="IDataList">m1List</param>
		/// <param name="tableList">取得情報</param>
		public void DoCopy ( Te060f01Form f01VO, IDataList m1List, IList<Hashtable> tableList )
		{
			int iCnt = 0;
			foreach (Hashtable rec in tableList)
			{
				iCnt++;
				Te060f01M1Form f01m1VO = new Te060f01M1Form();
				#region 明細転記
				f01m1VO.M1rowno = iCnt.ToString();								// Ｍ１行NO
				f01m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();				// Ｍ１部門コード
				f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();		// Ｍ１部門カナ名
				f01m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
				f01m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();			// Ｍ１ブランド名
				f01m1VO.M1jisya_hbn1 = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
				f01m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();				// Ｍ１メーカー品番
				f01m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名(カナ)
				f01m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
				f01m1VO.M1stop_ymd = rec["STOP_YMD"].ToString();				// Ｍ１防止期限
				f01m1VO.M1add_ymd = rec["UPD_YMD"].ToString();					// Ｍ１登録日
				f01m1VO.M1honbutenpokbnnm = rec["MEISYO_NM"].ToString();		// Ｍ１本部店舗区分名称

				f01m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
				f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
				if (rec["SOSINZUMI_FLG"].ToString().Equals(ConditionSosinzumi_flg.VALUE_SOSINZUMI))
				{
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SOSINZUMI;		// Ｍ１明細色区分(隠し)
				}
				else
				{
					f01m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
				}

				// Dictionary
				f01m1VO.Dictionary.Add(Te060p01Constant.DIC_M1TENPO_CD, rec["TENPO_CD"].ToString());					// 店舗コード 
				f01m1VO.Dictionary.Add(Te060p01Constant.DIC_M1UPD_YMD, rec["UPD_YMD"].ToString());						// 更新日
				f01m1VO.Dictionary.Add(Te060p01Constant.DIC_M1UPD_TM, rec["UPD_TM"].ToString());						// 更新時間
				f01m1VO.Dictionary.Add(Te060p01Constant.DIC_M1IRO_CD, rec["IRO_CD"].ToString());						// 色

				#endregion
				m1List.Add(f01m1VO, true);
			}
		}
		#endregion

		#region 行数チェック
		/// <summary>
		/// ChkRowCount 行数チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void ChkRowCount ( IFacadeContext facadeContext, IDataList m1List )
		{
			if (m1List == null || m1List.Count <= 0)
			{
				// 対象行を選択して下さい。
				ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
			}
			else
			{
				int inputflg = 0;
				foreach (Te060f01M1Form f01m1VO in m1List.ListData)
				{
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						inputflg = 1;
						break;
					}
				}
				if (inputflg == 0)
				{
					// 対象行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
			}
		}
		#endregion
		#region 更新単項目チェック
		/// <summary>
		/// ChkSelSingleItem 更新単項目チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Te060f01Form">f01VO</param>
		/// <param name="SysDateVO">sysDateVO</param>
		/// <returns>Decimal</returns>
		private void ChkUpdSingleItem ( IFacadeContext facadeContext, Te060f01Form f01VO, SysDateVO sysDateVO )
		{
			#region 単項目チェック
			// 修正モードで防止期限が未入力の場合、エラー
			if (f01VO.Modeno.Equals(BoSystemConstant.MODE_UPD)
			  && string.IsNullOrEmpty(f01VO.Stop_ymd))
			{
				ErrMsgCls.AddErrMsg("E121", "防止期限", facadeContext, new[] { "Stop_ymd" });
			}
			// 防止期限が過去日付の場合、エラー
			if (!string.IsNullOrEmpty(f01VO.Stop_ymd))
			{
				if (Convert.ToDecimal(BoSystemFormat.formatDate(f01VO.Stop_ymd)) < sysDateVO.Sysdate)
				{
					ErrMsgCls.AddErrMsg("E105", "防止期限", facadeContext, new[] { "Stop_ymd" });
				}
			}
			// 防止期限が5年以上未来の場合、エラー
			if (!string.IsNullOrEmpty(f01VO.Stop_ymd))
			{
				decimal dFiveYear = Convert.ToDecimal(BoSystemDate.toDatetime(Convert.ToString(sysDateVO.Sysdate)).AddYears(5).ToString("yyyyMMdd"));
				if (Convert.ToDecimal(BoSystemFormat.formatDate(f01VO.Stop_ymd)) >= dFiveYear)
				{
					ErrMsgCls.AddErrMsg("E187", string.Empty, facadeContext, new[] { "Stop_ymd" });
				}
			}
			#endregion
		}
		#endregion
		#region 排他チェック
		/// <summary>
		/// ChkUpdHaita 排他チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="IDataList">m1List</param>
		/// <returns></returns>
		private void ChkUpdHaita ( IFacadeContext facadeContext, IDataList m1List )
		{
			#region 排他チェック

			StringBuilder sRepSql = new StringBuilder();
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
			sRepSql.Append(" AND JISYA_HBN = :BIND_JISYA_HBN");
			sRepSql.Append(" AND IRO_CD = :BIND_IRO_CD");
			int iCnt = 0;
			foreach (Te060f01M1Form f01m1VO in m1List.ListData)
			{

				// 対象行のみ実施
				if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					// 店舗コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Te060p01Constant.DIC_M1TENPO_CD]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 自社品番
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISYA_HBN";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(f01m1VO.M1jisya_hbn1);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 色コード
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_IRO_CD";
					bindVO.Value = BoSystemFormat.formatIroCd((string)f01m1VO.Dictionary[Te060p01Constant.DIC_M1IRO_CD]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal((string)f01m1VO.Dictionary[Te060p01Constant.DIC_M1UPD_YMD]),
							Convert.ToDecimal((string)f01m1VO.Dictionary[Te060p01Constant.DIC_M1UPD_TM]),
							facadeContext,
							"MDST0010",
							sRepSql.ToString(),
							bindList,
							1,
							null,
							f01m1VO.M1rowno,
							iCnt.ToString(),
							"M1",
							m1List.DispRow
					);
				}
				iCnt++;
			}
			#endregion
		}
		#endregion
		#region [再入荷防止TBL]を更新する。(SQL_ID_03,SQL_ID_04)
		/// <summary>
		/// [再入荷防止TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="mode">選択モード</param>
		/// <param name="stopYmd">防止期限</param>
		/// <returns>更新件数</returns>
		public static int Upd_SaiNyuKa ( IFacadeContext facadeContext,
									Te060f01M1Form f01M1Form,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO,
									string mode,
									string stopYmd )
		{
			FindSqlResultTable reader = null;
			decimal dSakujyoFlg = 0;
			// XMLからSQLを取得する。
			// モードNOが「修正」
			if (mode.Equals(BoSystemConstant.MODE_UPD))
			{
				reader = FindSqlUtil.CreateFindSqlResultTable(Te060p01Constant.SQL_ID_03, facadeContext.DBContext);
				// 防止期限
				reader.BindValue("BIND_STOP_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(stopYmd)));
				// 登録区分
				reader.BindValue("BIND_ADD_KBN", Te060p01Constant.ADD_KBN_TENPO);
				// 削除フラグ
				dSakujyoFlg = Te060p01Constant.FLG_OFF;
			}
			// モードNOが「取消」
			else if (mode.Equals(BoSystemConstant.MODE_DEL))
			{
				reader = FindSqlUtil.CreateFindSqlResultTable(Te060p01Constant.SQL_ID_04, facadeContext.DBContext);
				// 削除フラグ
				dSakujyoFlg = Te060p01Constant.FLG_ON;
			}
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", dSakujyoFlg);
			// 送信依頼フラグ
			reader.BindValue("BIND_SOSINIRAI_FLG", Convert.ToDecimal(ConditionSosinirai_flg.VALUE_ARI));			// 1（送信対象）
			// 送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", Convert.ToDecimal(ConditionSosinzumi_flg.VALUE_MISOSIN));		// 0（未送信）

			// 更新ＫＥＹ
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Te060p01Constant.DIC_M1TENPO_CD]));
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f01M1Form.M1jisya_hbn1));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd((string)f01M1Form.Dictionary[Te060p01Constant.DIC_M1IRO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion
	}
}
