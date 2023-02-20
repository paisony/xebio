using com.xebio.bo.Tl010p01.Constant;
using com.xebio.bo.Tl010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tl010p01.Facade
{
  /// <summary>
  /// Tl010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl010f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1bumonkana_nm)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1bumonkana_nm)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1BUMONKANA_NM_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1BUMONKANA_NM_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tl010f01Form prevVo = (Tl010f01Form)facadeContext.FormVO;
				Tl010f02Form nextVo = (Tl010f02Form)facadeContext.GetUserObject(Tl010p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tl010f01M1Form prevM1Vo = (Tl010f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#region 業務チェック
				#endregion

				#region 検索処理

				// 営業日取得
				SysDateVO sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				string sSqlId = Tl010p01Constant.SQL_ID_04;

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// 営業日
				rtSeach.BindValue("BIND_SYSDATE", sysDateVO.Sysdate);
				// 店舗コード
				rtSeach.BindValue("BIND_TENPO_CD1", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
				rtSeach.BindValue("BIND_TENPO_CD2", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
				// 売変開始日
				rtSeach.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate((String)prevM1Vo.M1baihenkaisi_ymd)));
				// 部門コード
				rtSeach.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((String)prevM1Vo.Dictionary[Tl010p01Constant.DIC_M1BUMON_CD]));
				// 売変No
				rtSeach.BindValue("BIND_BAIHEN_NO", (String)prevM1Vo.Dictionary[Tl010p01Constant.DIC_M1BAIHEN_NO]);

				// 検索結果の取得
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				#region 件数チェック

				if (0 == tableList.Count)
				{
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tl010f02M1Form m1formVO = new Tl010f02M1Form();

					// Ｍ１行NO
					m1formVO.M1rowno = iCnt.ToString();

					// Ｍ１ブランド名
					m1formVO.M1burando_nm = rec["BURANDO_NMK"].ToString();
					// Ｍ１自社品番
					m1formVO.M1jisya_hbn = rec["JISYA_HBN"].ToString();
					// Ｍ１メーカー品番
					m1formVO.M1maker_hbn = rec["MAKER_HBN"].ToString();
					// Ｍ１色
					m1formVO.M1iro_nm = rec["IRO_NM"].ToString();
					// Ｍ１原単価
					m1formVO.M1gen_tnk = rec["GEN_TNK"].ToString();
					// Ｍ１現売価
					m1formVO.M1genbaika_tnm1k = rec["JODAI1_TNK"].ToString();
					// Ｍ１元売価
					m1formVO.M1mtobaika_tnk = rec["GENBAIKA_TNK"].ToString();
					// Ｍ１新売価
					m1formVO.M1shinbaika_tnk = rec["SIJIBAIKA_TNK"].ToString();

					// Ｍ１値入率現行
					// （[Ｍ１元売価] - 売価変更指示TBL．原単価）÷ [Ｍ１元売価] × 100
					decimal dMtobaikaTnk  = Convert.ToDecimal(m1formVO.M1mtobaika_tnk);
					decimal dGenTnk       = Convert.ToDecimal(m1formVO.M1gen_tnk);
					decimal dShinbaikaTnk = Convert.ToDecimal(m1formVO.M1shinbaika_tnk);
					if (dMtobaikaTnk != 0)
					{
						m1formVO.M1neire_rtu_genko = ((dMtobaikaTnk - dGenTnk) / dMtobaikaTnk * 100).ToString();
					}
					else
					{
						m1formVO.M1neire_rtu_genko = "0";
					}
					// Ｍ１値入率売変後
					// （[Ｍ１新売価] - 売価変更指示TBL．原単価）÷ [Ｍ１新売価] × 100
					if (dShinbaikaTnk != 0)
					{
						m1formVO.M1neire_rtu_baihengo = ((dShinbaikaTnk - dGenTnk) / dShinbaikaTnk * 100).ToString();
					}
					else
					{
						m1formVO.M1neire_rtu_baihengo = "0";
					}

					// Ｍ１在庫数
					m1formVO.M1zaiko_su = rec["ZAIKO_SU"].ToString();
					// Ｍ１売上数
					m1formVO.M1uriage_su = rec["URIAGE_SU"].ToString();
					// Ｍ１商品名(カナ)
					m1formVO.M1syonmk = rec["SYONMK"].ToString();

					// Ｍ１選択フラグ(隠し)
					m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					if (m1formVO.M1jisya_hbn.Equals((string)prevVo.Dictionary[Tl010p01Constant.DIC_SEARCH_XEBIOCD]))
					{
						// 一覧の検索条件で指定した自社品番と一致する場合、背景色を変える
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
					}
					else
					{
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					}


					// Ｍ１明細色区分(隠し)
					m1formVO.Dictionary[Tl010p01Constant.DIC_M1IRO_CD] = rec["IRO_CD"].ToString();


					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(m1formVO, true);
				}

				#region カード部設定

				// [出力シール]の名称取得
				if (nextVo.Dictionary[Tl010p01Constant.DIC_SYUTSURYOKU_SEAL] == null)
				{
					CalcTaxCls tax = new CalcTaxCls();
					nextVo.Dictionary.Add(Tl010p01Constant.DIC_SYUTSURYOKU_SEAL, tax.GetTaxDispControlInfo(facadeContext));
				}

				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_nm".ToUpper()];

				// 部門コード
				nextVo.Bumon_cd_bo = BoSystemFormat.formatBumonCd((String)prevM1Vo.Dictionary[Tl010p01Constant.DIC_M1BUMON_CD]);
				// 部門名
				nextVo.Bumon_nm = (String)prevM1Vo.Dictionary[Tl010p01Constant.DIC_M1BUMON_NM_MEISAI];

				// 売変開始日
				nextVo.Baihenkaisi_ymd = BoSystemFormat.formatDate((String)prevM1Vo.M1baihenkaisi_ymd);

				// 開始状態名称
				nextVo.Kaishi_jyotai_nm = (String)prevM1Vo.Dictionary[Tl010p01Constant.DIC_M1KAISISTATE_NM];

				// コメント
				nextVo.Comment_nm = (String)prevM1Vo.Dictionary[Tl010p01Constant.DIC_M1SINSEICOMMENT_NM];

				// 売変No
				nextVo.Dictionary[Tl010p01Constant.DIC_M1BAIHEN_NO] = prevM1Vo.Dictionary[Tl010p01Constant.DIC_M1BAIHEN_NO].ToString();
				// 出力シールの初期値設定
				nextVo.Shuturyoku_seal = Tl010p01Constant.ZEI_KBN_8;


				// 選択明細のVO
				nextVo.Dictionary[Tl010p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tl010p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1BUMONKANA_NM_FRM");

		}
		#endregion
	}
}
