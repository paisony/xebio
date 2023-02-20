using com.xebio.bo.Tf070p01.Constant;
using com.xebio.bo.Tf070p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tf070p01.Facade
{
  /// <summary>
  /// Tf070f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf070f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1tonanhinkanri_no)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1tonanhinkanri_no)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1TONANHINKANRI_NO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1TONANHINKANRI_NO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tf070f01Form prevVo = (Tf070f01Form)facadeContext.FormVO;
				Tf070f02Form nextVo = (Tf070f02Form)facadeContext.GetUserObject(Tf070p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tf070f01M1Form prevM1Vo = (Tf070f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];
				#endregion

				#region 検索処理
				// SQL実行部品生成
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tf070p01Constant.SQL_ID_03, facadeContext.DBContext);

				// バインド値の置き換え
				// 店舗コード
				rtSeach.BindValue(Tf070p01Constant.SQL_BIND_TENPO_CD, BoSystemFormat.formatTenpoCd(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString()));
				// 管理No
				rtSeach.BindValue(Tf070p01Constant.SQL_BIND_KANRI_NO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO]));
				// 処理日付
				rtSeach.BindValue(Tf070p01Constant.SQL_BIND_SYORI_YMD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tf070p01Constant.DIC_M1SYORI_YMD]));

				// 検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				#region 件数チェック
				if (tableList == null || tableList.Count <= 0)
				{
					// 検索件数が０件の場合
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 画面編集

				#region カード部
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)];
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];
				// 選択モードNO
				nextVo.Stkmodeno = prevVo.Stkmodeno;

				// 盗難品管理番号
				nextVo.Tonanhinkanri_no = (string)prevM1Vo.Dictionary[Tf070p01Constant.DIC_M1KANRI_NO];
				// 事故発生日
				nextVo.Jikohassei_ymd = prevM1Vo.M1jikohassei_ymd;
				// 報告日
				nextVo.Hokoku_ymd = prevM1Vo.M1hokoku_ymd;
				// 報告担当者コード
				nextVo.Hokokutan_cd = (string)prevM1Vo.Dictionary[Tf070p01Constant.DIC_M1HOKOKUTAN_CD];
				// 報告担当者名称
				nextVo.Hokokutan_nm = prevM1Vo.M1hokokutan_nm;
				// 店長担当者コード
				nextVo.Tentyotan_cd = (string)prevM1Vo.Dictionary[Tf070p01Constant.DIC_M1TENTYOTAN_CD];
				// 店長担当者名称
				nextVo.Tentyotan_nm = prevM1Vo.M1tentyotan_nm;
				// 警察届出日
				nextVo.Keisatsutodoke_ymd = prevM1Vo.M1keisatsutodoke_ymd;
				// 届出先警察署名
				nextVo.Todokedesakikeisatsu_nm = prevM1Vo.M1todokedesakikeisatsu_nm;
				// 受理番号
				nextVo.Jyuri_no = prevM1Vo.M1jyuri_no;

				// 選択明細のVO
				nextVo.Dictionary[Tf070p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択明細のインデックス
				nextVo.Dictionary[Tf070p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
				// 選択明細のＭ１確定処理フラグ
				nextVo.Dictionary[Tf070p01Constant.DIC_KAKUTEISYORI_FLG] = prevM1Vo.M1entersyoriflg;
				#endregion

				#region 明細部
				decimal gokeiSinseiSu = decimal.Zero;	// 合計申請数
				decimal gokeiJyuriSu = decimal.Zero;	// 合計受理数
				decimal gokeiBaikaKin = decimal.Zero;	// 合計売価金額

				// 明細初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				foreach (Hashtable rec in tableList)
				{
					Tf070f02M1Form nextM1Vo = new Tf070f02M1Form();

					nextM1Vo.M1rowno = rec["DENPYOGYO_NO"].ToString();								// Ｍ１行NO
					nextM1Vo.M1hassei_tm = rec["HASSEI_TM"].ToString();								// Ｍ１発生時間
					nextM1Vo.M1hasseibasyo = rec["HASSEIBASYO"].ToString();							// Ｍ１発生場所
					nextM1Vo.M1bumon_cd = rec["BUMON_CD"].ToString();								// Ｍ１部門コード
					nextM1Vo.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();						// Ｍ１部門カナ名
					nextM1Vo.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();					// Ｍ１品種略名称
					nextM1Vo.M1hakkentan_cd = rec["HAKKENTAN_CD"].ToString();						// Ｍ１発見担当者コード
					nextM1Vo.M1hakkentan_nm = rec["HANBAIIN_NM"].ToString();						// Ｍ１発見担当者名称
					nextM1Vo.M1burando_nm = rec["BURANDO_NMK"].ToString();							// Ｍ１ブランド名
					nextM1Vo.M1jisya_hbn = rec["JISYA_HBN"].ToString();								// Ｍ１自社品番
					nextM1Vo.M1hakkenjyokyo_kb = rec["HAKKENJYOKYO_KB"].ToString();					// Ｍ１発見状況区分
					nextM1Vo.M1hakkenjyokyo_nm = rec["HAKKENJYOKYO_NM"].ToString();					// Ｍ１発見状況
					nextM1Vo.M1maker_hbn = rec["MAKER_HBN"].ToString();								// Ｍ１メーカー品番
					nextM1Vo.M1syonmk = rec["SYONMK"].ToString();									// Ｍ１商品名(カナ)
					nextM1Vo.M1iro_nm = rec["IRO_NM"].ToString();									// Ｍ１色
					nextM1Vo.M1size_nm = rec["SIZE_NM"].ToString();									// Ｍ１サイズ
					nextM1Vo.M1scan_cd = rec["JAN_CD"].ToString();									// Ｍ１スキャンコード
					nextM1Vo.M1sinsei_su = rec["SINSEI_SU"].ToString();								// Ｍ１申請数
					nextM1Vo.M1jyuri_su = BoSystemString.ZeroToEmpty(rec["JYURI_SU"].ToString());	// Ｍ１受理数
					nextM1Vo.M1baika_hon = rec["BAIKA_TNK"].ToString();								// Ｍ１売価（本体）
					nextM1Vo.M1baika_kin = CalcBaikaKin(prevVo, prevM1Vo, nextM1Vo);				// Ｍ１売価金額
					nextM1Vo.M1sinsei_su_hdn = rec["SINSEI_SU"].ToString();							// Ｍ１申請数（隠し）
					nextM1Vo.M1jyuri_su_hdn = rec["JYURI_SU"].ToString();							// Ｍ１受理数（隠し）
					nextM1Vo.M1baika_kin_hdn = CalcBaikaKin(prevVo, prevM1Vo, nextM1Vo);			// Ｍ１売価金額（隠し）

					nextM1Vo.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;					// Ｍ１選択フラグ(隠し)
					nextM1Vo.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;				// Ｍ１確定処理フラグ(隠し)
					nextM1Vo.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;						// Ｍ１明細色区分(隠し)

					// 合計値加算
					gokeiSinseiSu += Convert.ToDecimal(nextM1Vo.M1sinsei_su);							// 合計申請数
					gokeiJyuriSu += Convert.ToDecimal(BoSystemString.Nvl(nextM1Vo.M1jyuri_su, "0"));	// 合計受理数
					gokeiBaikaKin += Convert.ToDecimal(nextM1Vo.M1baika_kin);							// 合計売価金額

					// リストオブジェクトにM1Formを追加します。
					nextM1List.Add(nextM1Vo, true);
				}

				// 合計欄の設定
				nextVo.Gokeisinsei_su = gokeiSinseiSu.ToString();
				nextVo.Gokeijyuri_su = gokeiJyuriSu.ToString();
				nextVo.Gokeibaika_kin = gokeiBaikaKin.ToString();
				#endregion

				#endregion

				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1TONANHINKANRI_NO_FRM");

		}
		#endregion

		#region 売価金額計算処理（Ｍ１管理番号リンク押下時）
		/// <summary>
		///  売価金額計算処理（Ｍ１管理番号リンク押下時）
		/// </summary>
		/// <param name="prevVo">一覧画面VO</param>
		/// <param name="prevM1Vo">一覧画面M1VO</param>
		/// <param name="nextM1Vo">明細画面M1VO</param>
		/// <returns>計算結果</returns>
		private static string CalcBaikaKin(Tf070f01Form prevVo, Tf070f01M1Form prevM1Vo, Tf070f02M1Form nextM1Vo)
		{
			// 計算結果
			decimal result = decimal.Zero;

			// 経費申請フラグ
			string keihisinseiFlg = (string)prevM1Vo.Dictionary[Tf070p01Constant.DIC_M1KEIHISINSEI_FLG];

			if (	(	prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_REF)					// 照会モード
					&&	keihisinseiFlg.Equals(ConditionSinsei_jotai.VALUE_SINSEI_JOTAI1)	// 未申請
					)
				||	prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_UPD)						// 修正モード
				||	prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_DEL)						// 取消モード
				)
			{
				// [選択モードNO]が「照会」、かつDictionary.[Ｍ１経費申請フラグ]が"0"（未申請）の場合
				// または[選択モードNO]が「修正」、「取消」のいずれかの場合

				// [Ｍ１売価（本体）]×[Ｍ１申請数]
				result = Convert.ToDecimal(nextM1Vo.M1baika_hon) * Convert.ToDecimal(nextM1Vo.M1sinsei_su);
			}
			else
			{
				// [選択モードNO]が「照会」、かつDictionary.[Ｍ１経費申請フラグ]が"1"（申請済）の場合
				// または[選択モードNO]が「経費申請」、「申請済取消」のいずれかの場合

				// [Ｍ１売価（本体）]×[Ｍ１受理数]
				result = Convert.ToDecimal(nextM1Vo.M1baika_hon) * Convert.ToDecimal(BoSystemString.Nvl(nextM1Vo.M1jyuri_su, "0"));
			}

			return result.ToString();
		}
		#endregion
	}
}
