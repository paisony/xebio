using com.xebio.bo.Th020p01.Constant;
using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Th020p01.Facade
{
  /// <summary>
  /// Th020f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th020f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Meisaihead_iro_nm1)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Meisaihead_iro_nm1)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoMEISAIHEAD_IRO_NM1_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoMEISAIHEAD_IRO_NM1_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Th020f02Form prevVo = (Th020f02Form)facadeContext.FormVO;
				Th020f04Form nextVo = (Th020f04Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_04);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Th020p01Constant.SQL_ID_03, facadeContext.DBContext);

				// サブクエリ
				this.AddSubQuery(prevVo, rtSeach);

				// バインド値の置き換え
				// JANコード
				rtSeach.BindValue(Th020p01Constant.REP_BIND_JAN_CD_W1, BoSystemFormat.formatJanCd(prevVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD].ToString()));
				// 店舗コード
				rtSeach.BindValue(Th020p01Constant.REP_BIND_TENPO_CD_W1, BoSystemFormat.formatTenpoCd(prevVo.Head_tenpo_cd));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					// ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
				}

				#endregion

				#region 項目設定

				// カード部設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = prevVo.Head_tenpo_cd;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = prevVo.Head_tenpo_nm;
				// 会社コード
				nextVo.Kaisya_cd = prevVo.Kaisya_cd;
				// 会社名称
				nextVo.Kaisya_nm = prevVo.Kaisya_nm;
				// 部門コード
				nextVo.Bumon_cd = BoSystemFormat.formatBumonCd(prevVo.Bumon_cd);
				// 部門名
				nextVo.Bumon_nm = prevVo.Bumon_nm;
				// 品種略名称
				nextVo.Hinsyu_ryaku_nm = prevVo.Hinsyu_ryaku_nm;
				// ブランドコード
				nextVo.Burando_cd = BoSystemFormat.formatBrandCd(prevVo.Burando_cd);
				// ブランド名
				nextVo.Burando_nm = prevVo.Burando_nm;
				// 自社品番
				nextVo.Jisya_hbn = BoSystemFormat.formatJisyaHbn(prevVo.Jisya_hbn);
				// メーカー品番
				nextVo.Maker_hbn = prevVo.Maker_hbn;
				// 商品属性
				nextVo.Syohin_zokusei = prevVo.Syohin_zokusei;
				// 商品名(カナ)
				nextVo.Syonmk = prevVo.Syonmk;

				// 色、サイズ
				// 展開区分が1の場合、色を表示、それ以外の場合サイズを表示
				if (BoSystemConstant.TENKAI_KB_SIZE.Equals(prevVo.Dictionary[Th020p01Constant.DIC_TENKAI_KBN].ToString()))
				{
					nextVo.Iro_nm = prevVo.Iro_nm;
					nextVo.Size_nm = prevVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM].ToString();
				}
				else
				{
					nextVo.Iro_nm = prevVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_SIZE_NM].ToString();
					nextVo.Size_nm = string.Empty;
				}

				// スキャンコード
				nextVo.Scan_cd = BoSystemFormat.formatJanCd(prevVo.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD].ToString());

				// 明細部設定
				int iCnt = 0;
				// 明細設定
				foreach (Hashtable rec in tableList)
				{

					Th020f04M1Form f04m1VO = new Th020f04M1Form();

					iCnt++;
					// Ｍ１行NO
					f04m1VO.M1rowno = iCnt.ToString();
					// Ｍ１店舗コード
					f04m1VO.M1tenpo_cd = BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString());
					// Ｍ１店舗名
					f04m1VO.M1tenpo_nm = rec["TENPO_NM"].ToString();
					// Ｍ１売上数
					f04m1VO.M1uriage_su = rec["URIAGERUISEKI_SU"].ToString();
					// Ｍ１販売可能在庫数
					f04m1VO.M1freezaiko_su = rec["ZAIKOSU"].ToString();
					// Ｍ１消化率
					f04m1VO.M1syoka_rtu = BoSystemString.Nvl(rec["SYOKART"].ToString(),"0.0");
					// Ｍ１帳簿在庫数
					f04m1VO.M1tyobozaiko_su = rec["TYOBOZAIKO_SU"].ToString();
					// Ｍ１預り予約数
					f04m1VO.M1azukariyoyaku_su = rec["AZUKARI_SU"].ToString();
					// Ｍ１積送数
					f04m1VO.M1sekiso_su = rec["SEKISO_SU"].ToString();
					// Ｍ１盗難品数
					f04m1VO.M1tonan_su = rec["TONANHIKIATE_SU"].ToString();
					// Ｍ１評価損申請数
					f04m1VO.M1hyokasonsinsei_su = rec["KIZUMONOHIKIATE_SU"].ToString();
					// Ｍ１選択フラグ(隠し)
					f04m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					f04m1VO.M1selectorcheckbox = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					f04m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					// 検索時の店舗コードが一致した場合色を変える
					if (BoSystemFormat.formatTenpoCd(prevVo.Dictionary[Th020p01Constant.DIC_TENPO_CD].ToString()).Equals(BoSystemFormat.formatTenpoCd(f04m1VO.M1tenpo_cd)))
					{
						f04m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
					}
				
					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f04m1VO, true);
				}

				// 画面表示モードの保持
				prevVo.Dictionary[Th020p01Constant.DIC_PREV_ACTION_MODE] = facadeContext.CommandInfo.ActionMode;
				
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
			EndMethod(facadeContext, this.GetType().Name + ".DoMEISAIHEAD_IRO_NM1_FRM");

		}
		#endregion

		#region ユーザー定義関数

		#region サブクエリ_設定
				/// <summary>
		/// AddSubQuery サブクエリ_設定
		/// </summary>
		/// <param name="Th020f02Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void AddSubQuery(Th020f02Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 会社コード設定
			String sCopCd = string.Empty;
			sCopCd = Convert.ToDecimal(BoSystemString.Nvl(f01VO.Kaisya_cd, "0")).ToString();

			// 商品×店舗

			sRepSql.Append(" ( ");
			sRepSql.Append("     SELECT BOMT0010.TENPO_CD, BOMT0010.TENPO_NM, BOMT0010.TENPOKEITAI_KB ");
			sRepSql.Append("    ,CASE WHEN MDMT0130.TENKAI_KB = 1 THEN MDMT0130.SIZE_NM ELSE MDMT0130.MAKERCOLOR_CD END SIZECOL_CD");
			sRepSql.Append("    ,MDMT0130.XEBIO_CD , MDMT0130.JAN_CD");

			sRepSql.Append("     FROM MDMT0130_").Append(sCopCd).Append(" MDMT0130 ");
			sRepSql.Append("     ,( ");
			sRepSql.Append("        SELECT * FROM BOMT0010_").Append(sCopCd).Append(" BOMT0010");
			sRepSql.Append("        WHERE SAKUJYO_FLG =0 ");

			// Xの場合
			if (CheckCompanyCls.IsXebio())
			{
				sRepSql.Append("   AND TENPOKEITAI_KB NOT IN (2)");
			}
			// それ以外の場合
			else
			{
				sRepSql.Append("   AND TENPOKEITAI_KB NOT IN (0 , 2)");
			}

			sRepSql.Append("        AND AREA_CD = (CASE WHEN :BIND1_AREA_CD IS NULL THEN AREA_CD ELSE :BIND2_AREA_CD END)");
			sRepSql.Append("     ) BOMT0010");
			sRepSql.Append("     WHERE MDMT0130.JAN_CD = :BIND3_JAN_CD");

			sRepSql.Append(" ) TNP_SHN");

			// 在庫抽出 
			// 店舗コード
			// JANコード
			// 在庫数
			// 売上数
			// 帳簿在庫数
			// 預り予約数
			// 積送数
			// 盗難品数
			// 評価損申請数

			sRepSql.Append(" ,(");

			// 前日在庫テーブル
			sRepSql.Append("     SELECT /*+ INDEX(MDBT0030 MDBT0030_PRIMARY) */ ");
			sRepSql.Append("             MDBT0030.TENPO_CD           TENPO_CD ");
			sRepSql.Append("            ,MDBT0030.JAN_CD             JAN_CD ");
			sRepSql.Append("            ,MDBT0030.FREEZAIKO_SU       FREEZAIKO_SU ");
			sRepSql.Append("            ,0                           URIAGERUISEKI_SU ");
			sRepSql.Append("            ,MDBT0030.TYOBOZAIKO_SU      TYOBOZAIKO_SU ");
			sRepSql.Append("            ,MDBT0030.AZUKARIHIKIATE_SU  AZUKARI_SU ");
			sRepSql.Append("            ,MDBT0030.SEKISO_SU          SEKISO_SU ");
			sRepSql.Append("            ,MDBT0030.TONANHIKIATE_SU    TONANHIKIATE_SU ");
			sRepSql.Append("            ,MDBT0030.KIZUMONOHIKIATE_SU KIZUMONOHIKIATE_SU ");
			sRepSql.Append("     FROM ");
			sRepSql.Append("     MDBT0030_").Append(sCopCd).Append(" MDBT0030");

			sRepSql.Append("     UNION ALL");

			// 当日受払テーブル
			sRepSql.Append("     SELECT ");
			sRepSql.Append("             MDBT0040.TENPO_CD           TENPO_CD ");
			sRepSql.Append("            ,MDBT0040.JAN_CD             JAN_CD ");
			sRepSql.Append("            ,MDBT0040.FREEZAIKO_SU       FREEZAIKO_SU ");
			sRepSql.Append("            ,0                           URIAGERUISEKI_SU ");
			sRepSql.Append("            ,MDBT0040.TYOBOZAIKO_SU      TYOBOZAIKO_SU ");
			sRepSql.Append("            ,MDBT0040.AZUKARIHIKIATE_SU  AZUKARI_SU ");
			sRepSql.Append("            ,MDBT0040.SEKISO_SU          SEKISO_SU ");
			sRepSql.Append("            ,MDBT0040.TONANHIKIATE_SU    TONANHIKIATE_SU ");
			sRepSql.Append("            ,MDBT0040.KIZUMONOHIKIATE_SU KIZUMONOHIKIATE_SU ");
			sRepSql.Append("     FROM ");
			sRepSql.Append("     MDBT0040_").Append(sCopCd).Append(" MDBT0040");

			sRepSql.Append("     UNION ALL");

			// 受払履歴テーブル
			sRepSql.Append("     SELECT ");
			sRepSql.Append("             MDBT0060.TENPO_CD");
			sRepSql.Append("            ,MDBT0060.JAN_CD");
			sRepSql.Append("            ,MDBT0060.FREEZAIKO_SU");
			sRepSql.Append("            ,0");
			sRepSql.Append("            ,MDBT0060.TYOBOZAIKO_SU      TYOBOZAIKO_SU ");
			sRepSql.Append("            ,MDBT0060.AZUKARIHIKIATE_SU  AZUKARI_SU ");
			sRepSql.Append("            ,MDBT0060.SEKISO_SU          SEKISO_SU ");
			sRepSql.Append("            ,MDBT0060.TONANHIKIATE_SU    TONANHIKIATE_SU ");
			sRepSql.Append("            ,MDBT0060.KIZUMONOHIKIATE_SU KIZUMONOHIKIATE_SU ");
			sRepSql.Append("     FROM ");
			sRepSql.Append("     MDBT0060_").Append(sCopCd).Append(" MDBT0060");

			sRepSql.Append("     UNION ALL");

			// 売上累積テーブル 
			sRepSql.Append("     SELECT /*+ INDEX(MDBT0070 MDBT0070_PRIMARY) NO_INDEX_FFS(MDBT0070 MDBT0070_PRIMARY) */");
			sRepSql.Append("             MDBT0070.TENPO_CD           TENPO_CD ");
			sRepSql.Append("            ,MDBT0070.JAN_CD             JAN_CD ");
			sRepSql.Append("            ,0");
			sRepSql.Append("            ,MDBT0070.URIAGE_SU          URIAGERUISEKI_SU ");
			sRepSql.Append("            ,0");
			sRepSql.Append("            ,0");
			sRepSql.Append("            ,0");
			sRepSql.Append("            ,0");
			sRepSql.Append("            ,0");
			sRepSql.Append("     FROM ");
			sRepSql.Append("     MDBT0070_").Append(sCopCd).Append(" MDBT0070");
			sRepSql.Append("  ) ZAIKO");
			
			// 明細(エリア別)より遷移した場合、遷移元のエリアで抽出
			if (Th020p01Constant.FORMID_03.Equals(f01VO.Dictionary[Th020p01Constant.DIC_PREV_FORMID].ToString()))
			{
				// バインド1　エリアコード
				bindList.Add(new BindInfoVO("BIND1_AREA_CD", f01VO.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString(), BoSystemSql.BINDTYPE_STRING));
				// バインド2　エリアコード
				bindList.Add(new BindInfoVO("BIND2_AREA_CD", f01VO.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString(), BoSystemSql.BINDTYPE_STRING));
			}
			// 一覧より遷移した場合かつモードが"自エリア"の場合、対象エリアを抽出
			else if (Th020p01Constant.FORMID_01.Equals(f01VO.Dictionary[Th020p01Constant.DIC_PREV_FORMID].ToString())
					&& ConditionZaiko_serchstk.VALUE_ZAIKO_SERCHSTK2.Equals(f01VO.Dictionary[Th020p01Constant.DIC_ZAIKO_SERCHSTK].ToString()))
			{
				// バインド1　エリアコード
				bindList.Add(new BindInfoVO("BIND1_AREA_CD", f01VO.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString(), BoSystemSql.BINDTYPE_STRING));
				// バインド2　エリアコード
				bindList.Add(new BindInfoVO("BIND2_AREA_CD", f01VO.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString(), BoSystemSql.BINDTYPE_STRING));
			}
			// それ以外の場合
			else
			{
				// バインド1　エリアコード
				bindList.Add(new BindInfoVO("BIND1_AREA_CD", string.Empty, BoSystemSql.BINDTYPE_STRING));
				// バインド2　エリアコード
				bindList.Add(new BindInfoVO("BIND2_AREA_CD", string.Empty, BoSystemSql.BINDTYPE_STRING));
			}

			// バインド3　JANコード
			bindList.Add(new BindInfoVO("BIND3_JAN_CD", BoSystemFormat.formatJanCd(f01VO.Dictionary[Th020p01Constant.DIC_M1HEAD_SELECT_JAN_CD].ToString()), BoSystemSql.BINDTYPE_STRING));

			BoSystemSql.AddSql(reader, Th020p01Constant.REP_ADD_SUBQUERY_1, sRepSql.ToString(), bindList);

			return;

		}

		#endregion

		#endregion

	}
}
