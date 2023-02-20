using com.xebio.bo.Tl020p01.Constant;
using com.xebio.bo.Tl020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.LabelUtil.vo;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01024;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tl020p01.Facade
{
  /// <summary>
  /// Tl020f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl020f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnseal)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnseal)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEAL_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEAL_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// ログイン情報取得
				LoginInfoVO loginInfVO = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tl020f02Form formVO = (Tl020f02Form)facadeContext.FormVO;
				IDataList m1List = formVO.GetList("M1");

				#region 業務チェック

				#region 1. 選択行チェック

				// 1-1 選択行
				//       1件も選択されていない場合、エラー 
				if (m1List == null || m1List.Count <= 0)
				{
					// 印刷する行を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tl020f02M1Form m1formVO = (Tl020f02M1Form)m1List[i];
						if (m1formVO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 印刷する行を選択して下さい。
						ErrMsgCls.AddErrMsg("E119", "印刷する行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 2. 単項目チェック

				// 2-1 ラベル発行機名
				//       ラベル発行機名が空白（未選択）の場合、エラー 
				if (string.IsNullOrEmpty(formVO.Label_nm))
				{
					// ラベル発行機を選択して下さい。
					ErrMsgCls.AddErrMsg("E119", "ラベル発行機", facadeContext);
				}


				// 2-2 ラベル発行機名
				//       ラベル発行機が存在しない場合、エラー 
				Hashtable labelTbl = V01024Check.CheckLabel(BoSystemFormat.formatTenpoCd(loginInfVO.TnpCd)
										   , formVO.Label_cd
										   , facadeContext
										   , "ラベル発行機"
										   , new[] { "Label_nm" });

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region シール発行処理

				// 税率計算クラス
				TaxVO taxvo = new TaxVO();

				// 印刷用CSV出力用データ取得
				FindSqlResultTable rtSealSeach = FindSqlUtil.CreateFindSqlResultTable(Tl020p01Constant.SQL_ID_08, facadeContext.DBContext);
				ReplaceWhereSeal(formVO, rtSealSeach);

				//検索結果を取得します
				rtSealSeach.CreateDbCommand();

				IList<Hashtable> tableList = rtSealSeach.Execute();

				if (tableList == null || tableList.Count <= 0)
				{
					// 抽出件数は0件です。
					ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
				}

				String sPrvBaika = string.Empty;		// 1行前の売価
				String sPrvBumonCd = string.Empty;		// 1行前の部門

				// 売変シールのレイアウト
				string printID = string.Empty;
				// 売変シールのCSVデータ
				string tmpFileName = string.Empty;

				// 売変シールデータを設定
				List<PriceChangeSealVO> sealList = new List<PriceChangeSealVO>();

				// 前行の部門コード
				string prevBumoncd = string.Empty;
				// 前行のハンドラベル
				string prevHandLbl = string.Empty;

				var sealIds = new List<string>();

				// 売変用CSV作成
				foreach (Hashtable rec in tableList)
				{
					// 在庫数が1以上の行を対象とする
					if (Convert.ToInt16(rec["FREEZAIKO_SU"].ToString()) > 0)
					{
						// 現在行の部門コード、ハンドラベルを取得
						string nowBumonCd = rec["BUMON_CD"].ToString();
						string nowHandLbl = rec["HANDLBL_KB"].ToString();

						// 部門コードとハンドラベルがブレークしたらメッセージを差し込む
						if (!prevBumoncd.Equals(nowBumonCd) || !prevHandLbl.Equals(nowHandLbl))
						{
							PriceChangeSealVO sealVo_msg = new PriceChangeSealVO();
							sealVo_msg.Baika = BoSystemLabelData.PriceChangeSealConfirmMsgStr(rec["BUMON_NM"].ToString(), rec["MEISYO_NM"].ToString());	// 売価
							sealVo_msg.Labelnm = string.Empty;			// ラベル名
							sealVo_msg.Zeikomikakaku = string.Empty;	// 税込価格
							sealVo_msg.Hakosu = "1";					// 発行枚数
							sealVo_msg.KoteiMongon = string.Empty;		// 固定文言
							sealVo_msg.Layoutnm = string.Empty;			// シールレイアウト情報を取得
							sealList.Add(sealVo_msg);
						}

						string sealtype = "4";	// シールタイプ(Def:10%)
						if (BoSystemString.Nvl(formVO.Shuturyoku_seal, "0").Equals("9"))
						{
							// 自動判別の場合
							sealtype = rec["TAX_CD"].ToString();
						}
						else
						{
							// その他の場合
							sealtype = BoSystemString.Nvl(formVO.Shuturyoku_seal, "4");
						}
						CalcTaxCls calcTax = new CalcTaxCls(facadeContext, Convert.ToInt32(sealtype));

						// 税込金額計算
						taxvo = calcTax.calcTax(Convert.ToDecimal(rec["KAKUTEIBAIKA_TNK2"].ToString()), Convert.ToDecimal(rec["ZEI_KB"].ToString()));

						PriceChangeSealVO sealVo = new PriceChangeSealVO();
						sealVo.Baika = rec["KAKUTEIBAIKA_TNK"].ToString();				// 売価
						sealVo.Labelnm = rec["MEISYO_NM"].ToString();					// ラベル名
						sealVo.Zeikomikakaku = taxvo.Zeikomi.ToString();				// 税込価格
						sealVo.Hakosu = rec["FREEZAIKO_SU"].ToString();					// 発行枚数
						// 固定文言を設定
						sealVo.KoteiMongon = sealtype.Equals(BoSystemConstant.PRICECHANGESEAL_HYOJUNCD) ? BoSystemConstant.PRICECHANGESEAL_KOTEISTRING : string.Empty;
						// シールレイアウト情報を取得
						printID = BoSystemLabelData.GetPriceChangeSealLayout(Convert.ToInt16(sealtype)) + BoSystemConstant.LABEL_NM_EXTENTS;
						sealVo.Layoutnm = printID;
						if (!sealIds.Contains(printID))
							sealIds.Add(printID);
						sealList.Add(sealVo);

						// 前行の値を設定
						prevBumoncd = rec["BUMON_CD"].ToString();
						prevHandLbl = rec["HANDLBL_KB"].ToString();
					}
				}


				// 売変シールのCSVデータ作成
				tmpFileName = BoSystemLabelData.CreateCsvPriceChangeSeal(PGID, sealList, printID);

				// CSVファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tl020p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
				// レイアウトファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tl020p01Constant.FCDUO_SEAL_LAYOUTNM, sealIds);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEAL_FRM");

		}
		#endregion

		#region 検索条件設定
		/// <summary>
		/// ReplaceWhereSeal 検索条件設定
		/// </summary>
		/// <param name="formVO">Tl020f01Form</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void ReplaceWhereSeal(Tl020f02Form formVO, FindSqlResultTable reader)
		{

			// 退避検索条件を取得
			String tenpocd = BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd);

			// 確定用検索条件
			StringBuilder sRepSqlKakutei = new StringBuilder();
			StringBuilder sRepSqlKakuteiMax = new StringBuilder();
			ArrayList bindListKakutei = new ArrayList();
			ArrayList bindListKakuteiMax = new ArrayList();
			int iCnt = 1;
			sRepSqlKakutei.Append(" AND (MDCT0030.TENPO_CD,MDCT0030.BAIHENKAISI_YMD, MDCT0030.BAIHEN_NO, MDCT0030.BUMON_CD,MDCT0030.BAIHENGYO_NO) IN (");
			sRepSqlKakuteiMax.Append(" AND (MDCT0030_MAX.TENPO_CD,MDCT0030_MAX.BAIHENKAISI_YMD, MDCT0030_MAX.BAIHEN_NO, MDCT0030_MAX.BUMON_CD,MDCT0030_MAX.BAIHENGYO_NO) IN (");

			// 指示用検索条件
			StringBuilder sRepSqlSiji = new StringBuilder();
			StringBuilder sRepSqlSijiMax = new StringBuilder();
			ArrayList bindListSiji = new ArrayList();
			ArrayList bindListSijiMax = new ArrayList();

			int iCnt2 = 1;
			sRepSqlSiji.Append(" AND (MDCT0010.TENPO_CD,MDCT0010.BAIHENKAISI_YMD, MDCT0010.BAIHEN_NO, MDCT0010.BUMON_CD,MDCT0010.BAIHENGYO_NO,MDCT0010.BAIHENSAGYOKAISI_YMD, MDCT0010.BAIHEN_RIYTU) IN (");
			sRepSqlSijiMax.Append(" AND (MDCT0010_MAX.TENPO_CD,MDCT0010_MAX.BAIHENKAISI_YMD, MDCT0010_MAX.BAIHEN_NO, MDCT0010_MAX.BUMON_CD,MDCT0010_MAX.BAIHENGYO_NO , MDCT0010_MAX.BAIHENSAGYOKAISI_YMD, MDCT0010_MAX.BAIHEN_RIYTU) IN (");

			IDataList m1List = formVO.GetList("M1");

			for (int i = 0; i < m1List.Count; i++)
			{
				Tl020f02M1Form m1formVO = (Tl020f02M1Form)m1List[i];

				// 選択明細のみ対象
				if (BoSystemConstant.CHECKBOX_ON.Equals(m1formVO.M1selectorcheckbox))
				{
					// 申請元ごとに作成
					switch (formVO.Dictionary[Tl020p01Constant.DIC_M1SINSEIMOTO_KBN].ToString())
					{
						case ConditionSinseimoto.VALUE_SINSEIMOTO2:		// 店舗

							#region 確定データ条件

							// 確定データ
							if (iCnt != 1)
							{
								sRepSqlKakutei.Append(" , ");
								sRepSqlKakuteiMax.Append(" , ");
							}

							// 検索条件1 確定
							sRepSqlKakutei.Append(" ( ");
							sRepSqlKakutei.Append(" :BIND1_TENPO_CD").Append(iCnt.ToString("000"));				// 店舗コード
							sRepSqlKakutei.Append(" ,:BIND1_BAIHENKAISI_YMD").Append(iCnt.ToString("000"));		// 売変開始日
							sRepSqlKakutei.Append(" ,:BIND1_BAIHEN_NO").Append(iCnt.ToString("000"));			// 売変No
							sRepSqlKakutei.Append(" ,:BIND1_BUMON_CD").Append(iCnt.ToString("000"));			// 部門コード
							sRepSqlKakutei.Append(" ,:BIND1_BAIHENGYO_NO").Append(iCnt.ToString("000"));		// 売変行No
							sRepSqlKakutei.Append(" ) ");

							// 店舗コード
							bindListKakutei.Add(new BindInfoVO("BIND1_TENPO_CD" + iCnt.ToString("000")
														, tenpocd
														, BoSystemSql.BINDTYPE_STRING)
														);

							// 売変開始日
							bindListKakutei.Add(new BindInfoVO("BIND1_BAIHENKAISI_YMD" + iCnt.ToString("000")
														, BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd)
														, BoSystemSql.BINDTYPE_NUMBER)
														);
							// 売変No
							// Dictionaryから取得する
							bindListKakutei.Add(new BindInfoVO("BIND1_BAIHEN_NO" + iCnt.ToString("000")
														, BoSystemFormat.formatBaihen_shiji_no(formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString())
														, BoSystemSql.BINDTYPE_STRING));

							// 部門コード
							bindListKakutei.Add(new BindInfoVO("BIND1_BUMON_CD" + iCnt.ToString("000")
														, BoSystemFormat.formatBumonCd(formVO.Bumon_cd)
														, BoSystemSql.BINDTYPE_STRING));

							// 売変行No
							bindListKakutei.Add(new BindInfoVO("BIND1_BAIHENGYO_NO" + iCnt.ToString("000")
														, m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENGYO_NO].ToString()
														, BoSystemSql.BINDTYPE_NUMBER));


							// 検索条件2 確定 最大売変No
							sRepSqlKakuteiMax.Append(" ( ");
							sRepSqlKakuteiMax.Append(" :BIND2_TENPO_CD").Append(iCnt.ToString("000"));				// 店舗コード
							sRepSqlKakuteiMax.Append(" ,:BIND2_BAIHENKAISI_YMD").Append(iCnt.ToString("000"));		// 売変開始日
							sRepSqlKakuteiMax.Append(" ,:BIND2_BAIHEN_NO").Append(iCnt.ToString("000"));			// 売変No
							sRepSqlKakuteiMax.Append(" ,:BIND2_BUMON_CD").Append(iCnt.ToString("000"));				// 部門コード
							sRepSqlKakuteiMax.Append(" ,:BIND2_BAIHENGYO_NO").Append(iCnt.ToString("000"));			// 売変行No
							sRepSqlKakuteiMax.Append(" ) ");

							// 店舗コード
							bindListKakuteiMax.Add(new BindInfoVO("BIND2_TENPO_CD" + iCnt.ToString("000")
														, tenpocd
														, BoSystemSql.BINDTYPE_STRING)
														);

							// 売変開始日
							bindListKakuteiMax.Add(new BindInfoVO("BIND2_BAIHENKAISI_YMD" + iCnt.ToString("000")
														, BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd)
														, BoSystemSql.BINDTYPE_NUMBER)
														);
							// 売変No
							// Dictionaryから取得する
							bindListKakuteiMax.Add(new BindInfoVO("BIND2_BAIHEN_NO" + iCnt.ToString("000")
							, BoSystemFormat.formatBaihen_shiji_no(formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString())
							, BoSystemSql.BINDTYPE_STRING));

							// 部門コード
							bindListKakuteiMax.Add(new BindInfoVO("BIND2_BUMON_CD" + iCnt.ToString("000")
														, BoSystemFormat.formatBumonCd(formVO.Bumon_cd)
														, BoSystemSql.BINDTYPE_STRING));

							// 売変行No
							bindListKakuteiMax.Add(new BindInfoVO("BIND2_BAIHENGYO_NO" + iCnt.ToString("000")
														, m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENGYO_NO].ToString()
														, BoSystemSql.BINDTYPE_NUMBER));

							iCnt = iCnt + 1;
							#endregion

							break;

						case ConditionSinseimoto.VALUE_SINSEIMOTO1:		// 本部

							#region 指示データ条件

							// 指示データ
							if (iCnt2 != 1)
							{
								sRepSqlSiji.Append(" , ");
								sRepSqlSijiMax.Append(" , ");
							}

							// 検索条件3 指示
							sRepSqlSiji.Append(" ( ");
							sRepSqlSiji.Append(" :BIND3_TENPO_CD").Append(iCnt2.ToString("000"));				// 店舗コード
							sRepSqlSiji.Append(" ,:BIND3_BAIHENKAISI_YMD").Append(iCnt2.ToString("000"));		// 売変開始日
							sRepSqlSiji.Append(" ,:BIND3_BAIHEN_NO").Append(iCnt2.ToString("000"));				// 売変No
							sRepSqlSiji.Append(" ,:BIND3_BUMON_CD").Append(iCnt2.ToString("000"));				// 部門コード
							sRepSqlSiji.Append(" ,:BIND3_BAIHENGYO_NO").Append(iCnt2.ToString("000"));			// 売変行No
							sRepSqlSiji.Append(" ,:BIND3_SAGYOKAISI").Append(iCnt2.ToString("000"));			// 作業開始日
							sRepSqlSiji.Append(" ,:BIND3_BAIHEN_RIYTU").Append(iCnt2.ToString("000"));			// 売変理由
							sRepSqlSiji.Append(" ) ");

							// 店舗コード
							bindListSiji.Add(new BindInfoVO("BIND3_TENPO_CD" + iCnt2.ToString("000")
														, tenpocd
														, BoSystemSql.BINDTYPE_STRING)
														);

							// 売変開始日
							bindListSiji.Add(new BindInfoVO("BIND3_BAIHENKAISI_YMD" + iCnt2.ToString("000")
														, BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd)
														, BoSystemSql.BINDTYPE_NUMBER)
														);
							// 売変No
							// Dictionaryから取得する
							bindListSiji.Add(new BindInfoVO("BIND3_BAIHEN_NO" + iCnt2.ToString("000")
														, BoSystemFormat.formatBaihen_shiji_no(formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString())
														, BoSystemSql.BINDTYPE_STRING));

							// 部門コード
							bindListSiji.Add(new BindInfoVO("BIND3_BUMON_CD" + iCnt2.ToString("000")
														, BoSystemFormat.formatBumonCd(formVO.Bumon_cd)
														, BoSystemSql.BINDTYPE_STRING));

							// 売変行No
							bindListSiji.Add(new BindInfoVO("BIND3_BAIHENGYO_NO" + iCnt2.ToString("000")
														, m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENGYO_NO].ToString()
														, BoSystemSql.BINDTYPE_NUMBER));

							// 作業開始日
							// Dictionaryから取得する
							bindListSiji.Add(new BindInfoVO("BIND3_SAGYOKAISI" + iCnt2.ToString("000")
							, BoSystemFormat.formatDate(formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENSAGYOKAISI_YMD].ToString())
							, BoSystemSql.BINDTYPE_NUMBER));

							// 売変理由
							bindListSiji.Add(new BindInfoVO("BIND3_BAIHEN_RIYTU" + iCnt2.ToString("000")
														, formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_RIYTU].ToString()
														, BoSystemSql.BINDTYPE_NUMBER));


							// 検索条件4 指示 最大売変No
							sRepSqlSijiMax.Append(" ( ");
							sRepSqlSijiMax.Append(" :BIND4_TENPO_CD").Append(iCnt2.ToString("000"));					// 店舗コード
							sRepSqlSijiMax.Append(" ,:BIND4_BAIHENKAISI_YMD").Append(iCnt2.ToString("000"));			// 売変開始日
							sRepSqlSijiMax.Append(" ,:BIND4_BAIHEN_NO").Append(iCnt2.ToString("000"));					// 売変No
							sRepSqlSijiMax.Append(" ,:BIND4_BUMON_CD").Append(iCnt2.ToString("000"));					// 部門コード
							sRepSqlSijiMax.Append(" ,:BIND4_BAIHENGYO_NO").Append(iCnt2.ToString("000"));				// 売変行No
							sRepSqlSijiMax.Append(" ,:BIND4_SAGYOKAISI").Append(iCnt2.ToString("000"));					// 作業開始日
							sRepSqlSijiMax.Append(" ,:BIND4_BAIHEN_RIYTU").Append(iCnt2.ToString("000"));				// 売変理由
							sRepSqlSijiMax.Append(" ) ");

							// 店舗コード
							bindListSijiMax.Add(new BindInfoVO("BIND4_TENPO_CD" + iCnt2.ToString("000")
														, tenpocd
														, BoSystemSql.BINDTYPE_STRING)
														);

							// 売変開始日
							bindListSijiMax.Add(new BindInfoVO("BIND4_BAIHENKAISI_YMD" + iCnt2.ToString("000")
														, BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd)
														, BoSystemSql.BINDTYPE_NUMBER)
														);
							// 売変No
							// Dictionaryから取得する
							bindListSijiMax.Add(new BindInfoVO("BIND4_BAIHEN_NO" + iCnt2.ToString("000")
														, BoSystemFormat.formatBaihen_shiji_no(formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_NO].ToString())
														, BoSystemSql.BINDTYPE_STRING));

							// 部門コード
							bindListSijiMax.Add(new BindInfoVO("BIND4_BUMON_CD" + iCnt2.ToString("000")
														, BoSystemFormat.formatBumonCd(formVO.Bumon_cd)
														, BoSystemSql.BINDTYPE_STRING));

							// 売変行No
							bindListSijiMax.Add(new BindInfoVO("BIND4_BAIHENGYO_NO" + iCnt2.ToString("000")
														, m1formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENGYO_NO].ToString()
														, BoSystemSql.BINDTYPE_NUMBER));

							// 作業開始日
							// Dictionaryから取得する
							bindListSijiMax.Add(new BindInfoVO("BIND4_SAGYOKAISI" + iCnt2.ToString("000")
							, BoSystemFormat.formatDate(formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHENSAGYOKAISI_YMD].ToString())
							, BoSystemSql.BINDTYPE_NUMBER));

							// 売変理由
							bindListSijiMax.Add(new BindInfoVO("BIND4_BAIHEN_RIYTU" + iCnt2.ToString("000")
														, formVO.Dictionary[Tl020p01Constant.DIC_M1BAIHEN_RIYTU].ToString()
														, BoSystemSql.BINDTYPE_NUMBER));

							iCnt2 = iCnt2 + 1;

							#endregion

							break;

						default:
							break;
					}
				}
			} // for

			sRepSqlKakutei.Append(" ) ");
			sRepSqlKakuteiMax.Append(" ) ");
			sRepSqlSiji.Append(" ) ");
			sRepSqlSijiMax.Append(" ) ");

			//売変確定データが選ばれていなかった場合、条件文を初期化する。
			if (iCnt == 1)
			{
				sRepSqlKakutei.Length = 0;
				sRepSqlKakuteiMax.Length = 0;
				bindListKakutei.Clear();
				bindListKakuteiMax.Clear();
				sRepSqlKakutei.Append(" AND 1 = 0");
				sRepSqlKakuteiMax.Append(" AND 1 = 0");

			}

			// 売変指示データが選ばれていなかった場合、条件文を初期化する。
			if (iCnt2 == 1)
			{
				sRepSqlSiji.Length = 0;
				sRepSqlSijiMax.Length = 0;
				bindListSiji.Clear();
				bindListSijiMax.Clear();
				sRepSqlSiji.Append(" AND 1 = 0");
				sRepSqlSijiMax.Append(" AND 1 = 0");

			}

			// 検索条件1 確定
			BoSystemSql.AddSql(reader, "REPLACE_WHERE_1", sRepSqlKakutei.ToString(), bindListKakutei);
			// 検索条件2 確定 最大売変No
			BoSystemSql.AddSql(reader, "REPLACE_WHERE_2", sRepSqlKakuteiMax.ToString(), bindListKakuteiMax);
			// 検索条件3 指示
			BoSystemSql.AddSql(reader, "REPLACE_WHERE_3", sRepSqlSiji.ToString(), bindListSiji);
			// 検索条件4 指示 最大売変No
			BoSystemSql.AddSql(reader, "REPLACE_WHERE_4", sRepSqlSijiMax.ToString(), bindListSijiMax);

		}
		#endregion
	}
}
