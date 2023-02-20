using com.xebio.bo.Tk020p01.Constant;
using com.xebio.bo.Tk030p01.Constant;
using com.xebio.bo.Tk030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tk030p01.Facade
{
  /// <summary>
  /// Tk030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tk030f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tk030f01Form f01VO = (Tk030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// フラグカウンタ
				int iFlgCnt = 0;


				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				#endregion

				#region 業務チェック
				for (int iRow = 0; iRow < m1List.Count; iRow++)
				{
					// 明細情報
					Tk030f01M1Form f01m1VO = (Tk030f01M1Form)m1List[iRow];

					// 承認／却下にチェックがされていない場合
					if(f01m1VO.M1kyakka_flg.Equals(BoSystemConstant.CHECKBOX_OFF)
						&& f01m1VO.M1syonin_flg.Equals(BoSystemConstant.CHECKBOX_OFF))
					{
						iFlgCnt++;
					}

					#region 関連項目チェック[Ｍ１却下, Ｍ１却下理由区分, Ｍ１却下理由]
					// Ｍ１却下が選択されている場合
					if(f01m1VO.M1kyakka_flg.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// Ｍ１却下理由区分が「その他」の時、Ｍ１却下理由が入力されていない場合、エラー
						if (f01m1VO.M1kyakkariyu_kb.Equals(ConditionHyokason_kyakkariyu.VALUE_HYOKASON_KYAKKARIYU5)
							&& string.IsNullOrEmpty(f01m1VO.M1kyakkariyu.ToString()))
						{
							// {その他選択時、却下理由}を入力して下さい。
							ErrMsgCls.AddErrMsg(
								"E118"
								, "その他選択時、却下理由"
								, facadeContext
								, new[] { "M1kyakkariyu" }
								, f01m1VO.M1rowno
								, iRow.ToString()
								, "M1"
							);
						}
					}
					#endregion
				}

				#region 件数チェック
				if (iFlgCnt == m1List.Count)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
				}
				#endregion

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				
				#endregion

				#region 排他チェック
				StringBuilder sRepSql = new StringBuilder();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tk030f01M1Form f01m1VO = (Tk030f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 店舗コード
						sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Tk030p01Constant.DIC_TENPO_CD]);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 管理No
						sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_KANRI_NO";
						bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tk030p01Constant.DIC_KANRI_NO]);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 処理日付
						sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SYORI_YMD";
						bindVO.Value = (string)f01m1VO.Dictionary[Tk030p01Constant.DIC_SYORI_YMD];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 行No
						sRepSql.Append(" AND GYO_NBR = :BIND_GYO_NBR");
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_GYO_NBR";
						bindVO.Value = (string)f01m1VO.Dictionary[Tk030p01Constant.DIC_GYO_NBR];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tk020p01Constant.DIC_UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tk020p01Constant.DIC_UPD_TM]),
								facadeContext,
								"MDIT0060",
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								100
						);

						// ＳＱＬ文初期化
						sRepSql.Length = 0;
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}
				#endregion

				#region 更新処理
				for (int i = 0; i < m1List.Count; i++)
				{
					// 明細情報
					Tk030f01M1Form f01m1VO = (Tk030f01M1Form)m1List[i];
					
					// [Ｍ１承認]または[Ｍ１却下]が選択されている場合
					if (f01m1VO.M1kyakka_flg.Equals(BoSystemConstant.CHECKBOX_ON)
						|| f01m1VO.M1syonin_flg.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						// [評価損確定TBL]を登録する。
						int InscntMDIT0060 = Ins_MDIT0070(facadeContext, f01m1VO, sysDateVO, logininfo);
						// [評価損申請TBL]を更新する。
						int UpdcntMDIT0060 = Upd_MDIT0060(facadeContext, f01VO, f01m1VO, sysDateVO);
					}
				}
				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

		#region 評価損確定ＴＢＬ＿作成
		/// <summary>
		/// [評価損確定TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_MDIT0070(IFacadeContext facadeContext,
										Tk030f01M1Form f01M1Form,
										SysDateVO sysDateVO,
										LoginInfoVO logininfo )
		{
			decimal dDate = 0; // システム日付
			decimal dTime = 0; // システム時刻

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK030P01-02", facadeContext.DBContext);

			//店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01M1Form.M1tenpo_cd));

			//管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_KANRI_NO].ToString()));

			//処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_SYORI_YMD].ToString()));

			//処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_SYORI_TM].ToString()));

			//行№
			reader.BindValue("BIND_GYO_NBR", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_GYO_NBR].ToString()));

			//部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f01M1Form.M1bumon_cd));

			//品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(f01M1Form.M1hinsyu_cd));

			//ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd(f01M1Form.Dictionary[Tk030p01Constant.DIC_BURANDO_CD].ToString()));

			//メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f01M1Form.M1maker_hbn.ToString());

			//商品名(カナ)
			reader.BindValue("BIND_SYONMK", f01M1Form.M1syonmk.ToString());

			//自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f01M1Form.M1jisya_hbn));

			//ＪＡＮコード
			reader.BindValue("BIND_JAN_CD", BoSystemFormat.formatJanCd(f01M1Form.M1scan_cd));

			//商品コード
			reader.BindValue("BIND_SYOHIN_CD", f01M1Form.Dictionary[Tk030p01Constant.DIC_SYOHIN_CD].ToString());

			//評価損数量
			reader.BindValue("BIND_HYOKASON_SU", Convert.ToDecimal(f01M1Form.M1hyokason_su));

			//販売完了日
			reader.BindValue("BIND_HANBAIKANRYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1hanbaikanryo_ymd)));

			//色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f01M1Form.Dictionary[Tk030p01Constant.DIC_IRO_CD].ToString()));

			//サイズコード
			reader.BindValue("BIND_SIZE_CD", BoSystemFormat.formatSizeCd(f01M1Form.Dictionary[Tk030p01Constant.DIC_SIZE_CD].ToString()));

			//サイズ名
			reader.BindValue("BIND_SIZE_NM", f01M1Form.M1size_nm.ToString());

			//原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(f01M1Form.M1gen_tnk));

			//上代1
			reader.BindValue("BIND_JODAI1_TNK", Convert.ToDecimal(f01M1Form.M1genbaika_tnk));

			//評価損種別区分
			reader.BindValue("BIND_HYOKASONSYUBETSU_KB", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_HYOKASONSYUBETSU_KB_WK].ToString()));

			//評価損理由区分
			reader.BindValue("BIND_HYOKASONRIYU_KB", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_HYOKASONRIYU_KB].ToString()));

			//評価損理由
			reader.BindValue("BIND_HYOKASONRIYU", f01M1Form.Dictionary[Tk030p01Constant.DIC_HYOKASONRIYU_WK].ToString());

			//却下理由区分
			// [評価損NB一括確定].[Ｍ１承認]="1"の場合、"0"、それ以外の場合、[評価損NB一括確定].[Ｍ１却下理由区分]
			if (f01M1Form.M1syonin_flg.ToString().Equals(BoSystemConstant.CHECKBOX_ON))
			{
				reader.BindValue("BIND_KYAKKARIYU_KB", 0);
			}
			else
			{
				reader.BindValue("BIND_KYAKKARIYU_KB", Convert.ToDecimal(f01M1Form.M1kyakkariyu_kb));

			}
			
			//却下理由
			// [評価損NB一括確定].[Ｍ１承認]="1"の場合、NULL、それ以外の場合、[評価損NB一括確定].[Ｍ１却下理由]
			if (f01M1Form.M1syonin_flg.ToString().Equals(BoSystemConstant.CHECKBOX_ON))
			{
				reader.BindValue("BIND_KYAKKARIYU", string.Empty);
			}
			else
			{
				reader.BindValue("BIND_KYAKKARIYU", f01M1Form.M1kyakkariyu.ToString());
			}
			

			//承認状態
			// [評価損NB一括確定].[Ｍ１承認]="1"の場合、"1"、[評価損NB一括確定].[Ｍ１却下]="1"の場合、"2"
			if (f01M1Form.M1syonin_flg.ToString().Equals(BoSystemConstant.CHECKBOX_ON))
			{
				reader.BindValue("BIND_SYONIN_FLG", 1);
			}
			if (f01M1Form.M1kyakka_flg.ToString().Equals(BoSystemConstant.CHECKBOX_ON))
			{
				reader.BindValue("BIND_SYONIN_FLG", 2);
			}

			//再申請済みフラグ
			reader.BindValue("BIND_SAISHINSEIZUMI_FLG", 0);

			//申請日
			reader.BindValue("BIND_APPLY_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_M1APPLY_YMD].ToString()));

			//調達区分
			reader.BindValue("BIND_TYOTATSU_KB", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_TYOTATSU_KB].ToString()));

			//登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate));

			//登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili));

			//登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));

			// 評価損申請ＴＢＬ＿更新用にDictionary追加
			dDate = sysDateVO.Sysdate;
			dTime = sysDateVO.Systime_mili;
			f01M1Form.Dictionary.Add(Tk030p01Constant.DIC_SYSDATE, dDate.ToString());
			f01M1Form.Dictionary.Add(Tk030p01Constant.DIC_SYSTIME, dTime.ToString());

			//更新日
			reader.BindValue("BIND_UPD_YMD", dDate);

			//更新時間
			reader.BindValue("BIND_UPD_TM", dTime);

			//更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));

			//削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			//削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 1);

			//送信依頼フラグ
			// [評価損NB一括確定].[Ｍ１承認]="1"の場合、"1"、それ以外の場合、"0"
			if (f01M1Form.M1syonin_flg.ToString().Equals(BoSystemConstant.CHECKBOX_ON))
			{
				reader.BindValue("BIND_SOSINIRAI_FLG", 1);
			}
			else
			{
				reader.BindValue("BIND_SOSINIRAI_FLG", 0);
			}
			
			//送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", 0);

			//送信日
			reader.BindValue("BIND_SOSIN_YMD", 0);

			//送信時間
			reader.BindValue("BIND_SOSIN_TM", 0);

			//申請データ送信済フラグ
			reader.BindValue("BIND_SHINSEI_SOSINZUMI_FLG", 0);

			//申請データ送信日
			reader.BindValue("BIND_SHINSEI_SOSIN_YMD", 0);

			//申請データ送信時間
			reader.BindValue("BIND_SHINSEI_SOSIN_TM", 0);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 評価損申請ＴＢＬ＿更新
		/// <summary>
		/// 評価損申請ＴＢＬ＿更新
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		private int Upd_MDIT0060(IFacadeContext facadeContext, Tk030f01Form f01Form, Tk030f01M1Form f01M1Form, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TK030P01-03", facadeContext.DBContext);

			#region 更新部
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);

			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			#endregion

			#region 条件部
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Tk030p01Constant.DIC_TENPO_CD].ToString()));

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_KANRI_NO].ToString()));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_SYORI_YMD].ToString()));

			// 行№
			reader.BindValue("BIND_GYO_NBR", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_GYO_NBR].ToString()));

			// システム日付
			reader.BindValue("BIND_SYSDATE", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_SYSDATE].ToString()));

			// システム時刻
			reader.BindValue("BIND_SYSTIME", Convert.ToDecimal(f01M1Form.Dictionary[Tk030p01Constant.DIC_SYSTIME].ToString()));
			#endregion

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

	}
}
