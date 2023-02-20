using com.xebio.bo.Tb020p01.Constant;
using com.xebio.bo.Tb020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tb020p01.Facade
{
  /// <summary>
  /// Tb020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb020f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1scm_cd)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1scm_cd)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1SCM_CD_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1SCM_CD_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				logger.Debug("");

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tb020f01Form prevVo = (Tb020f01Form)facadeContext.FormVO;
				Tb020f02Form nextVo = (Tb020f02Form)facadeContext.GetUserObject(Tb020p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				// ■仮対応 選択行が-2されている
				Tb020f01M1Form prevM1Vo = (Tb020f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];
				//Tb020f01M1Form prevM1Vo = (Tb020f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex + 2];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 件数チェック
				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tb020p01Constant.SQL_ID_04, facadeContext.DBContext);

				#region テーブルID設定

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				Decimal dCnt = 0;

				// [SCM状態]が"未処理"の場合、SCM予定テーブルから検索
				if (prevVo.Scm_jotai.Equals(ConditionScm_jotai.VALUE_SCM_JOTAI1))
				{
					// SCM予定TBL(B)
					sRepSql.Append("MDPT0031 T1 ");
				}
				// [SCM状態]が"確定"の場合、SCM確定テーブルから検索
				else
				{
					// SCM確定TBL(H)
					sRepSql.Append("MDPT0041 T1 ");
				}

				BoSystemSql.AddSql(rtChk, Tb020p01Constant.SQL_ID_01_REP_TABLE_ID, sRepSql.ToString(), bindList);

				// バインド値の置き換え
				// 店舗コード
				rtChk.BindValue(Tb020p01Constant.SQL_ID_04_REP_TENPO_CD, BoSystemFormat.formatTenpoCd((string)prevM1Vo.Dictionary[Tb020p01Constant.DIC_M1TENPO_CD]));
				// SCMコード
				rtChk.BindValue(Tb020p01Constant.SQL_ID_04_REP_SCM_CD, BoSystemFormat.formatScmCd((string)prevM1Vo.Dictionary[Tb020p01Constant.DIC_M1SCM_CD]));
				// 納入先着予定日
				rtChk.BindValue(Tb020p01Constant.SQL_ID_04_REP_NONYUTYAKUYOTEI_YMD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tb020p01Constant.DIC_M1NONYUTYAKUYOTEI_YMD]));


				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();

				//ログ出力
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
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 検索処理

				// [SCM状態]が"未処理"の場合、SCM予定テーブルから検索
				string sSqlId = "";
				if (prevVo.Scm_jotai.Equals(ConditionScm_jotai.VALUE_SCM_JOTAI1))
				{
					sSqlId = Tb020p01Constant.SQL_ID_05;
				}
				else
				{
					sSqlId = Tb020p01Constant.SQL_ID_06;
				}

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// 店舗コード
				rtSeach.BindValue(Tb020p01Constant.SQL_ID_04_REP_TENPO_CD, BoSystemFormat.formatTenpoCd((string)prevM1Vo.Dictionary[Tb020p01Constant.DIC_M1TENPO_CD]));
				// SCMコード
				rtSeach.BindValue(Tb020p01Constant.SQL_ID_04_REP_SCM_CD, BoSystemFormat.formatScmCd((string)prevM1Vo.Dictionary[Tb020p01Constant.DIC_M1SCM_CD]));
				// 納入先着予定日
				rtSeach.BindValue(Tb020p01Constant.SQL_ID_04_REP_NONYUTYAKUYOTEI_YMD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tb020p01Constant.DIC_M1NONYUTYAKUYOTEI_YMD]));


				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				decimal dSuryoSum = 0;	// 数量合計
				decimal dKinSum = 0;	// 原価金額合計

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tb020f02M1Form f02m1VO = new Tb020f02M1Form();

					f02m1VO.M1rowno = iCnt.ToString();								// M1ROWNO(No.)
					f02m1VO.M1denpyo_bango = rec["DENPYO_BANGO"].ToString();		// M1DENPYO_BANGO(伝票)
					f02m1VO.M1denpyogyo_no = rec["DENPYOGYO_NO"].ToString();		// M1DENPYOGYO_NO(行)
					f02m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();				// M1BUMON_CD(部門)
					f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();		// M1BUMONKANA_NM(部門)
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// M1HINSYU_RYAKU_NM(品種)
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();			// M1BURANDO_NMK(ブランド)
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// M1JISYA_HBN(自社品番)
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();				// M1MAKER_HBN(メーカー品番)
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// M1SYONMK(商品名)
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// M1IRO_NM(色)
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// M1SIZE_NM(サイズ)
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// M1SCAN_CD(スキャンコード)
					f02m1VO.M1itemsu = rec["SYUKKA_SU"].ToString();					// M1ITEMSU(数量)
					f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();					// M1GEN_TNK(原単価)
					f02m1VO.M1genka_kin = rec["GENKA_KIN"].ToString();				// M1GENKA_KIN(原価金額)
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// M1SELECTORCHECKBOX()
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// M1ENTERSYORIFLG()
					f02m1VO.M1dtlirokbn =  ConditionMeisaiiro_kbn.VALUE_NOMAL;		// M1DTLIROKBN()

					// 合計値加算
					dSuryoSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1itemsu, "0"));
					dKinSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genka_kin, "0"));

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

				}

				// 合計欄の設定
				nextVo.Gokei_suryo = dSuryoSum.ToString();
				nextVo.Genka_kin_gokei = dKinSum.ToString();


				#region カード部設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];

				// SCMコード
				nextVo.Scm_cd = BoSystemFormat.formatViewScmCd((string)prevM1Vo.Dictionary[Tb020p01Constant.DIC_M1SCM_CD]);
				// 仕入先
				nextVo.Siiresaki_cd = prevM1Vo.M1siiresaki_cd;
				nextVo.Siiresaki_ryaku_nm = prevM1Vo.M1siiresaki_ryaku_nm;
				// 入荷予
				nextVo.Nyukayotei_ymd = prevM1Vo.M1nyukayotei_ymd;
				// 仕入確定日
				nextVo.Siire_kakutei_ymd = prevM1Vo.M1siire_kakutei_ymd;
				// SCM状態
				nextVo.Scm_jotainm = ConditionUtil.GetLabel(ConditionScm_jotai.ID, prevVo.Scm_jotai);


				// 選択明細のVO
				nextVo.Dictionary[Tb020p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tb020p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

				#endregion

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1SCM_CD_FRM");

		}
		#endregion
	}
}