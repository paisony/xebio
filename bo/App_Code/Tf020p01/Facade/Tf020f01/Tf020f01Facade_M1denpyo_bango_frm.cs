using com.xebio.bo.Tf020p01.Constant;
using com.xebio.bo.Tf020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tf020p01.Facade
{
  /// <summary>
  /// Tf020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf020f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1denpyo_bango)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1denpyo_bango)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1DENPYO_BANGO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tf020f01Form prevVo = (Tf020f01Form)facadeContext.FormVO;
				Tf020f02Form nextVo = (Tf020f02Form)facadeContext.GetUserObject(Tf020p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tf020f01M1Form prevM1Vo = (Tf020f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック

				#endregion

				#region 検索処理

				string sSqlId = "";

				// [テーブル区分]が「1」（経費振替申請）の場合、経費振替申請（B)テーブルから検索する。
				if ("1".Equals((string)prevM1Vo.Dictionary[Tf020p01Constant.DIC_M1TBLFLG].ToString()))
				{
					sSqlId = Tf020p01Constant.SQL_ID_06;
				}
				else
				{
					sSqlId = Tf020p01Constant.SQL_ID_07;
				}

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// 店舗コード
				rtSeach.BindValue(Tf020p01Constant.SQL_ID_06_REP_TENPO_CD, BoSystemFormat.formatTenpoCd(prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"].ToString()));
				// 処理日
				rtSeach.BindValue(Tf020p01Constant.SQL_ID_06_REP_SYORI_YMD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tf020p01Constant.DIC_M1SYORI_YMD]));
				// 伝票番号
				rtSeach.BindValue(Tf020p01Constant.SQL_ID_06_REP_DENPYO_BANGO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tf020p01Constant.DIC_M1DENPYO_BANGO]));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				decimal dSuryoSum = 0;		// 数量合計
				decimal dKinSum = 0;		// 原価金額合計

				foreach (Hashtable rec in tableList)
				{
					Tf020f02M1Form f02m1VO = new Tf020f02M1Form();

					f02m1VO.M1rowno = rec["DENPYOGYO_NO"].ToString();									// Ｍ１行NO
					f02m1VO.M1bumon_cd = BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString());		// Ｍ１部門コード
					f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();							// Ｍ１部門カナ名
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();								// Ｍ１ブランド名
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();									// Ｍ１メーカー品番
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();										// Ｍ１色
					f02m1VO.M1scan_cd = BoSystemFormat.formatJanCd(rec["JAN_CD"].ToString());			// Ｍ１スキャンコード
					f02m1VO.M1suryo = rec["SURYO"].ToString();											// Ｍ１数量
					f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();										// Ｍ１原単価
					f02m1VO.M1genka_kin = (Convert.ToDecimal(f02m1VO.M1gen_tnk) * Convert.ToDecimal(f02m1VO.M1suryo)).ToString();
																										// Ｍ１原価金額
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();						// Ｍ１品種略名称
					f02m1VO.M1jisya_hbn = BoSystemFormat.formatJisyaHbn(rec["JISYA_HBN"].ToString());	// Ｍ１自社品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();										// Ｍ１商品名(カナ)
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();										// Ｍ１サイズ
					f02m1VO.M1genbaika_tnk = rec["BAIKA_TNK"].ToString();								// Ｍ１現売価
					f02m1VO.M1gokeibaika_kin = (Convert.ToDecimal(f02m1VO.M1genbaika_tnk) * Convert.ToDecimal(f02m1VO.M1suryo)).ToString();
																										// Ｍ１売価金額
					f02m1VO.M1suryo_hdn = f02m1VO.M1suryo;												// Ｍ１数量(隠し)
					f02m1VO.M1genka_kin_hdn = f02m1VO.M1genka_kin;										// Ｍ１原価金額(隠し)

					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;							// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;						// Ｍ１確定処理フラグ(隠し)
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;							// Ｍ１明細色区分(隠し)

					// 合計値加算
					dSuryoSum += Convert.ToDecimal(f02m1VO.M1suryo);
					dKinSum += Convert.ToDecimal(f02m1VO.M1genka_kin);

					// ディクショナリ
					f02m1VO.Dictionary[Tf020p01Constant.DIC_M1HINSYU_CD] = BoSystemFormat.formatHinsyuCd(rec["HINSYU_CD"].ToString());		// 品種コード
					f02m1VO.Dictionary[Tf020p01Constant.DIC_M1BURANDO_CD] = BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString());		// ブランドコード
					f02m1VO.Dictionary[Tf020p01Constant.DIC_M1IRO_CD] = BoSystemFormat.formatIroCd(rec["IRO_CD"].ToString());				// 色コード
					f02m1VO.Dictionary[Tf020p01Constant.DIC_M1SIZE_CD] = BoSystemFormat.formatSizeCd(rec["SIZE_CD"].ToString());			// サイズコード
					f02m1VO.Dictionary[Tf020p01Constant.DIC_M1SYOHIN_CD] = rec["SYOHIN_CD"].ToString();										// 商品コード

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

				}

				// 合計欄の設定
				nextVo.Gokei_suryo = dSuryoSum.ToString();
				nextVo.Genka_kin_gokei = dKinSum.ToString();

				// 0件チェック
				if (nextM1List.Count == 0)
				{
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					return;
				}

				#region カード部設定

				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]); ;
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)]; ;
				// 選択モードNO
				nextVo.Stkmodeno = prevVo.Stkmodeno;

				// 申請日
				nextVo.Apply_ymd = BoSystemFormat.formatDate(prevM1Vo.M1apply_ymd);
				// 申請理由区分
				nextVo.Sinseiriyu_kb = (string)prevM1Vo.Dictionary[Tf020p01Constant.DIC_M1SINSEIRIYU_KB];
				// 申請理由
				nextVo.Sinseiriyu = (string)prevM1Vo.Dictionary[Tf020p01Constant.DIC_M1SINSEIRIYU];
				// 伝票番号
				nextVo.Denpyo_bango = (string)prevM1Vo.Dictionary[Tf020p01Constant.DIC_M1DENPYO_BANGO];
				// 科目コード
				nextVo.Kamoku_cd = prevM1Vo.M1kamoku_cd;
				// 科目名
				nextVo.Kamoku_nm = prevM1Vo.M1kamoku_nm;
				// 却下理由
				nextVo.Kyakkariyu = prevM1Vo.M1kyakkariyu;
				// 受理番号
				nextVo.Jyuri_no = prevM1Vo.M1jyuri_no;
				// 承認状態名称
				nextVo.Syonin_flg_nm = (string)prevM1Vo.Dictionary[Tf020p01Constant.DIC_M1SYONINSTATUS];

				// 選択明細のVO
				nextVo.Dictionary[Tf020p01Constant.DIC_M1SELECTVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tf020p01Constant.DIC_M1SELECTROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

				#endregion

				#endregion

			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
			//	//トランザクションをロールバックする。
			//	RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

		}
		#endregion
	}
}
