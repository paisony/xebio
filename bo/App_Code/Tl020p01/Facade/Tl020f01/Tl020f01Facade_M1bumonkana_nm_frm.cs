using com.xebio.bo.Tl020p01.Constant;
using com.xebio.bo.Tl020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Conditions;
using Common.Entitys;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Common.Standard.Util;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tl020p01.Facade
{
  /// <summary>
  /// Tl020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl020f01Facade : StandardBaseFacade
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
				Tl020f01Form prevVo = (Tl020f01Form)facadeContext.FormVO;
				Tl020f02Form nextVo = (Tl020f02Form)facadeContext.GetUserObject(Tl020p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tl020f01M1Form prevM1Vo = (Tl020f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#region 業務チェック
				#endregion

				#region 検索処理

				// 営業日取得
				SysDateVO sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 確定状態
				string strKakuteijyotai = (String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Kakutei_jyotai".ToUpper()];
				// 申請元区分
				string strSinseimotokbn = (String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1SINSEIMOTO_KBN];

				string sSqlId = String.Empty;

				// 確定状態：確定
				if (ConditionKakutei_jyotai.VALUE_KAKUTEI_JYOTAI1.Equals(strKakuteijyotai))
				{
					// 申請元
					switch (strSinseimotokbn)
					{
						case ConditionSinseimoto.VALUE_SINSEIMOTO1:		// 本部
							sSqlId = Tl020p01Constant.SQL_ID_06;	// MDCT0010
							break;
						case ConditionSinseimoto.VALUE_SINSEIMOTO2:		// 店舗
							sSqlId = Tl020p01Constant.SQL_ID_05;	// MDCT0030
							break;
						default:
							break;
					}
				}
				else
				{
					// 申請元
					switch (strSinseimotokbn)
					{
						case ConditionSinseimoto.VALUE_SINSEIMOTO1:		// 本部
							sSqlId = Tl020p01Constant.SQL_ID_06;	// MDCT0010
							break;
						case ConditionSinseimoto.VALUE_SINSEIMOTO2:		// 店舗
							sSqlId = Tl020p01Constant.SQL_ID_04;	// MDCT0020
							break;
						default:
							break;
					}

				}


				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				switch (sSqlId)
				{
					case Tl020p01Constant.SQL_ID_04:	// 予定
						// 店舗コード
						rtSeach.BindValue("BIND_TENPO_CD11", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD12", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD13", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));

						rtSeach.BindValue("BIND_TENPO_CD1", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD2", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));

						// 売変開始日
						rtSeach.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate((String)prevM1Vo.M1baihenkaisi_ymd)));

						// 売変No
						// Dictionaryから取得する
						rtSeach.BindValue("BIND_BAIHEN_NO", prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString());

						// 部門コード
						rtSeach.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BUMON_CD]));
						break;

					case Tl020p01Constant.SQL_ID_05:	// 確定
						// 店舗コード
						rtSeach.BindValue("BIND_TENPO_CD1", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD2", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						// 売変開始日
						rtSeach.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate((String)prevM1Vo.M1baihenkaisi_ymd)));

						// 売変No
						// Dictionaryから取得する
						rtSeach.BindValue("BIND_BAIHEN_NO", prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString());

						// 部門コード
						rtSeach.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BUMON_CD]));
						break;

					case Tl020p01Constant.SQL_ID_06:	// 指示
						// 店舗コード
						rtSeach.BindValue("BIND_TENPO_CD11", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD12", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD13", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD14", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD15", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD16", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));

						rtSeach.BindValue("BIND_TENPO_CD1", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));
						rtSeach.BindValue("BIND_TENPO_CD2", BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]));

						// 売変開始日
						rtSeach.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate((String)prevM1Vo.M1baihenkaisi_ymd)));

						// 売変No
						// Dictionaryから取得する
						rtSeach.BindValue("BIND_BAIHEN_NO", prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString());

						// 確定フラグ
						rtSeach.BindValue("BIND_KAKUTEI_FLG1", Convert.ToDecimal(strKakuteijyotai));
						rtSeach.BindValue("BIND_KAKUTEI_FLG2", Convert.ToDecimal(strKakuteijyotai));

						// 部門コード
						rtSeach.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd((String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BUMON_CD]));

						// 売変作業開始日
						// Dictionaryから取得する
						rtSeach.BindValue("BIND_BAIHENSAGYOKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BAIHENSAGYOKAISI_YMD].ToString())));

						// 売変理由
						rtSeach.BindValue("BIND_BAIHEN_RIYTU", (String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_RIYTU]);
						break;

					default:
						break;
				}
				
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
					Tl020f02M1Form m1formVO = new Tl020f02M1Form();

					// Ｍ１行NO
					m1formVO.M1rowno = iCnt.ToString();

					// Ｍ１品種略名称
					m1formVO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();
					// Ｍ１ブランド名
					m1formVO.M1burando_nm = rec["BURANDO_NMK"].ToString();
					// Ｍ１自社品番
					m1formVO.M1jisya_hbn = rec["JISYA_HBN"].ToString();
					// Ｍ１メーカー品番
					m1formVO.M1maker_hbn = rec["MAKER_HBN"].ToString();
					// Ｍ１商品名(カナ)
					m1formVO.M1syonmk = rec["SYONMK"].ToString();
					// Ｍ１色
					m1formVO.M1iro_nm = rec["IRO_NM"].ToString();
					// Ｍ１シーズン
					m1formVO.M1season_kb = rec["SEASON_KB"].ToString();
					// Ｍ１販売完了日
					m1formVO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();
					// Ｍ１元売価
					m1formVO.M1mtobaika_tnk = rec["GENBAIKA_TNK"].ToString();
					// Ｍ１原単価
					m1formVO.M1gen_tnk = rec["GEN_TNK"].ToString();
					// Ｍ１新売価
					if (Tl020p01Constant.SQL_ID_05.Equals(sSqlId))
					{
						m1formVO.M1shinbaika_tnk = rec["KAKUTEIBAIKA_TNK"].ToString();
					}
					else
					{
						m1formVO.M1shinbaika_tnk = rec["SIJIBAIKA_TNK"].ToString();
					}

					// Ｍ１値入率現行
					// （[Ｍ１元売価] - 原単価）÷ [Ｍ１元売価] × 100
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
					// （[Ｍ１新売価] - 原単価）÷ [Ｍ１新売価] × 100
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

					// Ｍ１承認状態名称
					string strMeisyocd = rec["SYONIN_FLG"].ToString();
					Mdmt0100DA mdmt0100DA = new Mdmt0100DA();
					Mdmt0100Key mdmt0100Key = new Mdmt0100Key("PCSN", strMeisyocd);

					mdmt0100DA.Context = facadeContext.DBContext;
					Mdmt0100VO mdmt0100VO = mdmt0100DA.FindByPrimaryKey(mdmt0100Key);
					//マスタからレコード取得
					string strSyoninflgnm = string.Empty;
					if (mdmt0100VO != null)
					{
						strSyoninflgnm = mdmt0100VO.Meisyo_nm;
					}

					if (Tl020p01Constant.SQL_ID_05.Equals(sSqlId))			// 確定
					{
						m1formVO.M1syonin_flg_nm = strSyoninflgnm;
					}
					else if (Tl020p01Constant.SQL_ID_04.Equals(sSqlId))		// 予定
					{
						m1formVO.M1syonin_flg_nm = string.Empty;
					}
					else
					{
						m1formVO.M1syonin_flg_nm = strSyoninflgnm;
					}

					// Ｍ１選択フラグ(隠し)
					m1formVO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
					// Ｍ１確定処理フラグ(隠し)
					m1formVO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;
					// Ｍ１明細色区分(隠し)
					if (m1formVO.M1jisya_hbn.Equals((string)prevVo.Dictionary[Tl020p01Constant.DIC_SEARCH_XEBIOCD]))
					{
						// 一覧の検索条件で指定した自社品番と一致する場合、背景色を変える
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
					}
					else
					{
						m1formVO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
					}

					// 売変行No
					m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENGYO_NO] = rec["BAIHENGYO_NO"].ToString();


					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(m1formVO, true);
				}

				#region カード部設定

				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd((String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()]);
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (String)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_nm".ToUpper()];

				// 申請元
				nextVo.Shinseimoto_nm = ConditionUtil.GetLabel("SINSEIMOTO", (String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1SINSEIMOTO_KBN]);

				// 申請担当者コード
				nextVo.Sinseitan_cd = (String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1SINSEITAN_CD];
				// 申請担当者名
				nextVo.Sinseitan_nm = prevM1Vo.M1sinseitan_nm;

				// 部門コード
				nextVo.Bumon_cd = BoSystemFormat.formatBumonCd((String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BUMON_CD]);
				// 部門名
				nextVo.Bumon_nm = (String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BUMON_NM_MEISAI];

				// 売変指示No
				nextVo.Baihen_shiji_no = BoSystemFormat.formatBaihen_shiji_no(prevM1Vo.M1baihen_shiji_no);
				// 売変理由
				nextVo.Baihen_riyu_nm = prevM1Vo.M1baihen_riyu_nm;

				// 登録確定者コード
				nextVo.Torokukak_cd = (String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1TOROKUKAK_CD];
				// 登録確定者名
				nextVo.Torokukak_nm = prevM1Vo.M1torokukak_nm;

				// コメント
				nextVo.Comment_nm = (String)prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1SINSEICOMMENT_NM];

				// 作業開始日
				nextVo.Aihensagyokaisi_ymd = prevM1Vo.M1baihensagyokaisi_ymd;
				// 開始日
				nextVo.Baihenkaisi_ymd = prevM1Vo.M1baihenkaisi_ymd;


				// 選択明細のVO
				nextVo.Dictionary[Tl020p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tl020p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

				// 申請元区分
				nextVo.Dictionary[Tl020p01Constant.DIC_M1SINSEIMOTO_KBN] = prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1SINSEIMOTO_KBN].ToString();
				// 売変理由コード
				nextVo.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_RIYTU] = prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_RIYTU].ToString();
				// 確定状態
				nextVo.Dictionary[Tl020p01Constant.DIC_KAKUTEI_JYOTAI] = prevVo.Kakutei_jyotai.ToString();

				// Dictionaryに設定する
				// 売変No
				nextVo.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO] = prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString();
				// 売変作業開始日
				nextVo.Dictionary[Tl020p01Constant.DIC_M1BAIHENSAGYOKAISI_YMD] = prevM1Vo.Dictionary[Tl020p01Constant.DIC_M1BAIHENSAGYOKAISI_YMD].ToString();
				// [出力シール]の名称取得
				if (nextVo.Dictionary[Tl020p01Constant.DIC_SYUTSURYOKU_SEAL] == null)
				{
					CalcTaxCls tax = new CalcTaxCls();
					nextVo.Dictionary.Add(Tl020p01Constant.DIC_SYUTSURYOKU_SEAL, tax.GetTaxDispControlInfo(facadeContext));
				}

				#endregion

				#endregion

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1BUMONKANA_NM_FRM");

		}
		#endregion
	}
}
