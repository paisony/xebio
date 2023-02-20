using com.xebio.bo.Td030p01.Constant;
using com.xebio.bo.Td030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Td030p01.Facade
{
  /// <summary>
  /// Td030f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Td030f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Td030p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Td030f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Td030f01Facade()
			: base()
		{
		}
		#endregion

		#region Td030f01画面データを作成する。
		/// <summary>
		/// Td030f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを開きます。
				OpenConnection(facadeContext);

				//カード部を取得します。
				Td030f01Form td030f01Form = (Td030f01Form)facadeContext.FormVO;

				//[伝票状態]：「確定」
				td030f01Form.Denpyo_jyotai = ConditionHenpin_denpyo_jotai.VALUE_HENPIN_DENPYO_JOTAI1;

				//業務日付を取得する
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				DateTime date = DateTime.Parse(sysDateVO.Sysdate.ToString().Insert(4, "/").Insert(7, "/"));

				//返品確定日From：前月1日
				td030f01Form.Henpin_kakutei_ymd_from = new DateTime(date.Year, date.Month, 1).AddMonths(-1).ToString("yyyyMMdd");
				//返品確定日To：業務日付
				td030f01Form.Henpin_kakutei_ymd_to = sysDateVO.Sysdate.ToString();

				////M1明細部のデータを作成します。
				//DoM1ListLoad(facadeContext);

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

		#region 明細画面(Td030f02)のデータを作成する。
		/// <summary>
		/// 明細画面(Td030f02)のデータを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void SetMeisaiFormData(IFacadeContext facadeContext)
		{
			BoSystemLog.logOut("");
			#region 初期化

			// ログイン情報取得
			LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

			// FormVO取得
			// 画面より情報を取得する。
			Td030f01Form prevVo = (Td030f01Form)facadeContext.FormVO;
			Td030f02Form nextVo = (Td030f02Form)facadeContext.GetUserObject(Td030p01Constant.FCDUO_NEXTVO);

			IDataList prevM1List = prevVo.GetList("M1");
			IDataList nextM1List = nextVo.GetList("M1");
			// 選択行の情報を取得する。
			Td030f01M1Form prevM1Vo = (Td030f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

			// 一覧の初期化
			nextM1List.ClearCacheData();
			nextM1List.Clear();

			#endregion

			#region 検索処理

			string sTblKbn = (string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1TBL_KBN];
			string sSqlId = "";
			// [参照テーブル]が「返品予定テーブル」の場合、返品予定TBL(B)から検索する。
			if (sTblKbn.Equals(Td030p01Constant.TBL_YOTEI))
			{
				sSqlId = Td030p01Constant.SQL_ID_07;
			}
			// [参照テーブル]が「返品確定テーブル」の場合、返品確定TBL(B)から検索する。
			else if (sTblKbn.Equals(Td030p01Constant.TBL_KAKUTEI))
			{
				sSqlId = Td030p01Constant.SQL_ID_08;
			}
			// [参照テーブル]が「返品確定履歴テーブル」の場合、返品確定履歴TBL(B)から検索する。
			else if (sTblKbn.Equals(Td030p01Constant.TBL_RIREKI))
			{
				sSqlId = Td030p01Constant.SQL_ID_09;
			}

			FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

			// バインド値の置き換え
			if (sTblKbn.Equals(Td030p01Constant.TBL_YOTEI))
			{
				// 管理No
				rtSeach.BindValue(Td030p01Constant.SQL_REP_KANRI_NO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1KANRI_NO]));
			}
			else
			{
				// 伝票番号
				rtSeach.BindValue(Td030p01Constant.SQL_REP_DENPYO_BANGO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1DENPYO_BANGO]));
			}
			// 処理日付
			rtSeach.BindValue(Td030p01Constant.SQL_REP_SYORI_YMD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			rtSeach.BindValue(Td030p01Constant.SQL_REP_TENPO_CD, (string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1TENPO_CD]);
			if (sTblKbn.Equals(Td030p01Constant.TBL_RIREKI))
			{
				// 履歴No
				rtSeach.BindValue(Td030p01Constant.SQL_REP_RIREKI_NO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1RIREKI_NO]));
				// 赤黒区分
				rtSeach.BindValue(Td030p01Constant.SQL_REP_AKAKURO_KBN, Convert.ToDecimal((string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1AKAKURO_KBN]));
			}

			//検索結果を取得します
			rtSeach.CreateDbCommand();
			IList<Hashtable> tableList = rtSeach.Execute();

			#region 検索件数チェック
			if (tableList == null || tableList.Count <= 0)
			{
				// エラー
				ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
			}
			//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
			if (MessageDisplayUtil.HasError(facadeContext))
			{
				return;
			}
			#endregion

			decimal dSuryoSum = 0;	// 数量合計
			decimal dKinSum = 0;	// 原価金額合計

			//string scan_cd = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd)];
			//string old_jisya_hbn = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Old_jisya_hbn)];
			string scan_cd = (string)prevVo.Dictionary[Td030p01Constant.DIC_SEARCH_JANCD];
			string old_jisya_hbn = (string)prevVo.Dictionary[Td030p01Constant.DIC_SEARCH_XEBIOCD];

			foreach (Hashtable rec in tableList)
			{
				Td030f02M1Form f02m1VO = new Td030f02M1Form();

				f02m1VO.M1rowno = rec["DENPYOGYO_NO"].ToString();				// Ｍ１行NO
				f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
				f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
				f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();				// Ｍ１メーカー品番
				f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名(カナ)
				f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
				f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
				f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード
				f02m1VO.M1itemsu = rec["SURYO"].ToString();						// Ｍ１数量
				f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();					// Ｍ１原単価
				f02m1VO.M1genkakin = rec["GENKA_KIN"].ToString();				// Ｍ１原価金額
				f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
				f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
				if (scan_cd.Equals(f02m1VO.M1scan_cd) || old_jisya_hbn.Equals(f02m1VO.M1jisya_hbn))
				{
					// 一覧画面で入力されたスキャンコード、自社品番、旧自社品番のいずれが一致する場合、背景色変更
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)
				}
				else
				{
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
				}

				// 合計値加算
				dSuryoSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1itemsu, "0"));
				dKinSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0"));

				//リストオブジェクトにM1Formを追加します。
				nextM1List.Add(f02m1VO, true);

			}

			// 合計欄の設定
			nextVo.Gokei_suryo = dSuryoSum.ToString();
			nextVo.Genka_kin_gokei = dKinSum.ToString();

			#region カード部設定

			// ヘッダ店舗コード（検索押下時の内容）
			nextVo.Head_tenpo_cd = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)];
			// ヘッダ店舗名（検索押下時の内容）
			nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];

			// 管理番号
			nextVo.Kanri_no = (string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1KANRI_NO];
			// 伝票番号
			nextVo.Denpyo_bango = (string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1DENPYO_BANGO];
			// 入力担当者コード
			nextVo.Nyuryokutan_cd = (string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1NYURYOKUTAN_CD];
			// 入力担当者名
			nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;
			// 確定担当者コード
			nextVo.Kakuteitan_cd = (string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1KAKUTEITAN_CD];
			// 確定担当者名
			nextVo.Kakuteitan_nm = prevM1Vo.M1kakuteitan_nm;
			// 返品理由名称
			nextVo.Henpin_riyu_nm = prevM1Vo.M1henpin_riyu_nm;
			// 仕入先コード
			nextVo.Siiresaki_cd = prevM1Vo.M1siiresaki_cd;
			// 仕入先名
			nextVo.Siiresaki_ryaku_nm = prevM1Vo.M1siiresaki_ryaku_nm;
			// 部門コード
			nextVo.Bumon_cd = prevM1Vo.M1bumon_cd_bo1;
			// 部門名
			nextVo.Bumon_nm = (string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1BUMON_NM];
			// ブランドコード
			nextVo.Burando_cd = (string)prevM1Vo.Dictionary[Td030p01Constant.DIC_M1BURANDO_CD];
			// ブランド名
			nextVo.Burando_nm = prevM1Vo.M1burando_nm;
			// 指示番号
			nextVo.Siji_bango = prevM1Vo.M1siji_bango;
			// 返品確定日
			nextVo.Henpin_kakutei_ymd = prevM1Vo.M1henpin_kakutei_ymd;
			// 登録日
			nextVo.Add_ymd = prevM1Vo.M1add_ymd;
			// 伝票状態名称
			nextVo.Denpyo_jyotainm = prevM1Vo.M1denpyo_jyotainm;
			// 元伝票番号
			nextVo.Motodenpyo_bango = prevM1Vo.M1motodenpyo_bango;
			// 処理名称
			nextVo.Syorinm = prevM1Vo.M1syorinm;
			// 処理日
			nextVo.Syoriymd = prevM1Vo.M1syoriymd;
			// 処理時間
			nextVo.Syori_tm = prevM1Vo.M1syori_tm;

			// 選択明細のVO
			nextVo.Dictionary[Td030p01Constant.DIC_M1SELCETVO] = prevM1Vo;
			// 選択行のインデックスを設定
			nextVo.Dictionary[Td030p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

			#endregion

			#endregion

		}
		#endregion

	}
}
