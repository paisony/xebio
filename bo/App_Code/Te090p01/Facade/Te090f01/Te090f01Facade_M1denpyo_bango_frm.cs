using com.xebio.bo.Te090p01.Constant;
using com.xebio.bo.Te090p01.Formvo;
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

namespace com.xebio.bo.Te090p01.Facade
{
  /// <summary>
  /// Te090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te090f01Facade : StandardBaseFacade
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
				Te090f01Form prevVo = (Te090f01Form)facadeContext.FormVO;
				Te090f02Form nextVo = (Te090f02Form)facadeContext.GetUserObject(Te090p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Te090f01M1Form prevM1Vo = (Te090f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];
				#endregion

				#region 検索処理
				string selSqlId = string.Empty;
				if (prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI))
				{
					// 入荷確定モードの場合
					selSqlId = Te090p01Constant.SQL_ID_05;
				}
				else
				{
					// 入荷確定モード以外の場合
					selSqlId = Te090p01Constant.SQL_ID_06;
				}

				// SQL実行部品生成
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(selSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// 店舗ＬＣ区分
				rtSeach.BindValue(Te090p01Constant.SQL_BIND_TENPOLC_KBN, Convert.ToDecimal((string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1TENPOLC_KBN]));
				// 出荷会社コード
				rtSeach.BindValue(Te090p01Constant.SQL_BIND_SYUKKAKAISYA_CD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]));
				// 出荷店コード
				rtSeach.BindValue(Te090p01Constant.SQL_BIND_SYUKKATEN_CD, BoSystemFormat.formatTenpoCd(prevM1Vo.M1syukkaten_cd));
				// 伝票番号
				rtSeach.BindValue(Te090p01Constant.SQL_BIND_DENPYO_BANGO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]));
				// 出荷日
				rtSeach.BindValue(Te090p01Constant.SQL_BIND_SYUKKA_YMD, Convert.ToDecimal((string)BoSystemFormat.formatDate(prevM1Vo.M1syukka_ymd)));

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
				nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];
				// 選択モードNO
				nextVo.Stkmodeno = prevVo.Stkmodeno;

				// 伝票番号
				nextVo.Denpyo_bango = BoSystemFormat.formatDenpyoNo((string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1DENPYO_BANGO]);
				// SCMコード
				nextVo.Scm_cd = BoSystemFormat.formatViewScmCd(prevM1Vo.M1scm_cd);
				// 入荷担当者コード
				nextVo.Nyukatan_cd = BoSystemFormat.formatTantoCd((string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1NYUKATAN_CD]);
				// 入荷担当者名称
				nextVo.Nyukatan_nm = (string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1NYUKATAN_NM];
				// 入荷日
				nextVo.Jyuryo_ymd = BoSystemFormat.formatDate(prevM1Vo.M1jyuryo_ymd);
				if (BoSystemFormat.formatKaisyaCd((string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]).Equals(BoSystemFormat.formatKaisyaCd(logininfo.CopCd)))
				{
					// 自社の場合
					// 会社コード
					nextVo.Kaisya_cd = string.Empty;
					// 会社名称
					nextVo.Kaisya_nm = string.Empty;
				}
				else
				{
					// 自社以外の場合
					// 会社コード
					nextVo.Kaisya_cd = BoSystemFormat.formatKaisyaCd((string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1KAISYA_CD]);
					// 会社名称
					nextVo.Kaisya_nm = (string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1KAISYA_NM];
				}
				// 出荷店コード
				nextVo.Syukkaten_cd = BoSystemFormat.formatTenpoCd(prevM1Vo.M1syukkaten_cd);
				// 出荷店名称
				nextVo.Syukkaten_nm = prevM1Vo.M1syukkaten_nm;
				// 出荷担当者コード
				nextVo.Syukkatan_cd = BoSystemFormat.formatTantoCd((string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1SYUKKATAN_CD]);
				// 出荷担当者名称
				nextVo.Syukkatan_nm = (string)prevM1Vo.Dictionary[Te090p01Constant.DIC_M1SYUKKATAN_NM];
				// 出荷日
				nextVo.Syukka_ymd = BoSystemFormat.formatDate(prevM1Vo.M1syukka_ymd);
				// 伝票状態名称
				nextVo.Denpyo_jyotainm = prevM1Vo.M1denpyo_jyotainm;

				// 選択明細のVO
				nextVo.Dictionary[Te090p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択明細のインデックス（ページ内）
				nextVo.Dictionary[Te090p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
				#endregion

				#region 明細部
				decimal gokeiYoteiSu = decimal.Zero;	// 合計予定数
				decimal gokeiKakuteiSu = decimal.Zero;	// 合計確定数
				decimal gokeiGenkaKin = decimal.Zero;	// 合計原価金額

				// 明細初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				foreach (Hashtable rec in tableList)
				{
					Te090f02M1Form nextM1Vo = new Te090f02M1Form();

					// Ｍ１行NO
					nextM1Vo.M1rowno = rec["DENPYOGYO_NO"].ToString();
					// Ｍ１部門コード
					nextM1Vo.M1bumon_cd = BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString());
					// Ｍ１部門カナ名
					nextM1Vo.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();
					// Ｍ１品種略名称
					nextM1Vo.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();
					// Ｍ１ブランド名
					nextM1Vo.M1burando_nm = rec["BURANDO_NMK"].ToString();
					// Ｍ１自社品番
					nextM1Vo.M1jisya_hbn = rec["JISYA_HBN"].ToString();
					// Ｍ１メーカー品番
					nextM1Vo.M1maker_hbn = rec["MAKER_HBN"].ToString();
					// Ｍ１商品名(カナ)
					nextM1Vo.M1syonmk = rec["SYONMK"].ToString();
					// Ｍ１色
					nextM1Vo.M1iro_nm = rec["IRO_NM"].ToString();
					// Ｍ１サイズ
					nextM1Vo.M1size_nm = rec["SIZE_NM"].ToString();
					// Ｍ１スキャンコード
					nextM1Vo.M1scan_cd = BoSystemFormat.formatJanCd(rec["JAN_CD"].ToString());
					// Ｍ１予定数量
					nextM1Vo.M1yotei_su = rec["NYUKAYOTEI_SU"].ToString();
					if (prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI)
						&& prevM1Vo.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_NASI))
					{
						// 入荷確定モード、かつ未確定の場合
						// Ｍ１確定数量
						nextM1Vo.M1kakutei_su = string.Empty;
					}
					else
					{
						// それ以外の場合
						// Ｍ１確定数量
						nextM1Vo.M1kakutei_su = rec["NYUKAJISSEKI_SU"].ToString();
					}
					// Ｍ１原単価
					nextM1Vo.M1gen_tnk = rec["GEN_TNK"].ToString();
					if (prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_NYUKAKAKUTEI)
						&& prevM1Vo.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_NASI))
					{
						// 入荷確定モード、かつ未確定の場合
						// Ｍ１原価金額
						decimal m1YoteiSu;
						decimal m1GenTnk;
						decimal.TryParse(nextM1Vo.M1yotei_su, out m1YoteiSu);
						decimal.TryParse(nextM1Vo.M1gen_tnk, out m1GenTnk);
						nextM1Vo.M1genka_kin = (m1GenTnk * m1YoteiSu).ToString();
					}
					else
					{
						// それ以外の場合
						// Ｍ１原価金額
						decimal m1KakuteiSu;
						decimal m1GenTnk;
						decimal.TryParse(nextM1Vo.M1kakutei_su, out m1KakuteiSu);
						decimal.TryParse(nextM1Vo.M1gen_tnk, out m1GenTnk);
						nextM1Vo.M1genka_kin = (m1GenTnk * m1KakuteiSu).ToString();
					}
					// Ｍ１確定数量（隠し）
					nextM1Vo.M1kakutei_su_hdn = BoSystemString.Nvl(nextM1Vo.M1kakutei_su, nextM1Vo.M1yotei_su);
					// Ｍ１原価金額（隠し）
					nextM1Vo.M1genkakin_hdn = nextM1Vo.M1genka_kin;
					// Ｍ１選択フラグ(隠し)
					nextM1Vo.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					nextM1Vo.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					nextM1Vo.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;

					// 合計値加算
					// 合計予定数量
					gokeiYoteiSu += Convert.ToDecimal(nextM1Vo.M1yotei_su);
					// 合計確定数量
					gokeiKakuteiSu += Convert.ToDecimal(BoSystemString.Nvl(nextM1Vo.M1kakutei_su, nextM1Vo.M1yotei_su));
					// 合計原価金額
					gokeiGenkaKin += Convert.ToDecimal(nextM1Vo.M1genka_kin);							

					// リストオブジェクトにM1Formを追加します。
					nextM1List.Add(nextM1Vo, true);
				}

				// 合計欄の設定
				nextVo.Gokeiyotei_su = gokeiYoteiSu.ToString();
				nextVo.Gokeikakutei_su = gokeiKakuteiSu.ToString();
				nextVo.Genka_kin_gokei = gokeiGenkaKin.ToString();
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

		}
		#endregion
	}
}
