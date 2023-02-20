using com.xebio.bo.Tl010p01.Constant;
using com.xebio.bo.Tl010p01.Formvo;
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
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tl010p01.Facade
{
  /// <summary>
  /// Tl010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl010f02Facade : StandardBaseFacade
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
				Tl010f02Form formVO = (Tl010f02Form)facadeContext.FormVO;
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
						Tl010f02M1Form m1formVO = (Tl010f02M1Form)m1List[i];
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

				String sTenpo_cd = BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd);

				// プライスシールのレイアウト
				string printID = string.Empty;
				// プライスシールのCSVデータ
				string tmpFileName = string.Empty;

				// プライスシールのレイアウト名を取得
				int zeikbn = Convert.ToInt16(formVO.Shuturyoku_seal);
				string sealID = BoSystemLabelData.GetPriceSealLayout(Convert.ToInt16(zeikbn), 1);

				// プライスシールデータを設定
				List<PriceSealVO> sealList = new List<PriceSealVO>();

				// プライスシール情報取得
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tl010p01Constant.SQL_ID_05, facadeContext.DBContext);
				// 検索条件設定
				ReplaceWhereSeal(formVO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();

				IList<Hashtable> tableList = rtSeach.Execute();

				string sealtype = "4";	// シールタイプ(Def:10%)

				var sealIds = new List<string>();

				foreach (Hashtable rec in tableList)
				{
					if(zeikbn == 9)
					{
						// 自動判別の場合
						sealtype = rec["TAX_CD"].ToString();
					}
					else
					{
						// その他の場合
						sealtype = BoSystemString.Nvl(formVO.Shuturyoku_seal, "4");
					}
					CalcTaxCls Tax = new CalcTaxCls(facadeContext, Convert.ToInt32(sealtype));

					PriceSealVO sealVo = new PriceSealVO();
					// 税計算処理
					TaxVO taxVo = Tax.calcTax(rec["SIJIBAIKA_TNK"].ToString(), Convert.ToDecimal(rec["ZEI_KB"].ToString()));

					sealVo.Tenpocd = sTenpo_cd;														// 店舗コード
					sealVo.Bumoncd = rec["BUMON_CD"].ToString();									// 部門コード
					sealVo.Hinsyucd = BoSystemFormat.formatHinsyuCd(rec["HINSYU_CD"].ToString());	// 品種コード
					sealVo.Brandnm = BoSystemFormat.formatHinsyuCd(rec["BURANDO_NMK"].ToString());	// ブランド名
					sealVo.Hinmei = rec["MAKER_HBN"].ToString();									// 品名(メーカー品番)
					sealVo.Jisyahbn = BoSystemFormat.formatJisyaHbn(rec["JISYA_HBN"].ToString());	// 自社品番
					sealVo.Iro = rec["IRO_NM"].ToString();											// 色
					sealVo.Size = rec["SIZE_NM"].ToString();										// サイズ
					sealVo.Syohinkb = rec["ITEMKBN"].ToString();									// 商品区分
					sealVo.Siirekb = rec["SIIRE_KB"].ToString();									// 仕入区分
					sealVo.Hanbaikanryo = rec["HANBAIKANRYO_YMD"].ToString();						// 販売完了日
					sealVo.Chotatsu = rec["TYOTATSU_KB"].ToString();								// 調達区分
					sealVo.Makerkibokakaku = rec["JODAI2_TNK"].ToString();							// メーカー希望小売価格
					sealVo.Baika = taxVo.Zeinuki.ToString();										// 売価
					sealVo.Zeikomikakaku = taxVo.Zeikomi.ToString();								// 税込価格
					sealVo.Jan = rec["JAN_CD"].ToString();											// JAN
					sealVo.Siirecd = rec["SIIRESAKI_CD"].ToString();								// 仕入先コード
					sealVo.Makerhbn = rec["MAKER_HBN"].ToString();									// メーカー品番
					sealVo.Hakosu = rec["FREEZAIKO_SU"].ToString();									// 発行枚数
					// シールレイアウト情報を取得
					sealVo.Layoutnm = BoSystemLabelData.GetPriceSealLayout(Convert.ToInt16(sealtype), 1) + BoSystemConstant.LABEL_NM_EXTENTS;
					if (!sealIds.Contains(sealVo.Layoutnm))
						sealIds.Add(sealVo.Layoutnm);
					sealList.Add(sealVo);

				}

				// プライスシールのCSVデータ作成
				tmpFileName = BoSystemLabelData.CreateCsvPriceSeal(PGID, sealList, sealID);
				// CSVファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tl010p01Constant.FCDUO_SEAL_CSVFLNM, tmpFileName);
				// レイアウトファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tl010p01Constant.FCDUO_SEAL_LAYOUTNM, sealIds);

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
        /// ReplaceWherePart 検索条件設定
        /// </summary>
		/// <param name="formVO">Tl010f01Form</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void ReplaceWhereSeal(Tl010f02Form formVO, FindSqlResultTable reader)
		{
			// 店舗コードを設定
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(formVO.Head_tenpo_cd);

			reader.BindValue("BIND1_TENPO_CD", sTenpo_cd);
			reader.BindValue("BIND2_TENPO_CD", sTenpo_cd);
			reader.BindValue("BIND3_TENPO_CD", sTenpo_cd);
			reader.BindValue("BIND4_TENPO_CD", sTenpo_cd);

			// 検索条件
			StringBuilder sRepSql = new StringBuilder();
			StringBuilder sRepSqlMax = new StringBuilder();
			ArrayList bindListSql = new ArrayList();
			ArrayList bindListSqlMax = new ArrayList();

			int iCnt = 1;
			sRepSql.Append(" AND (MDCT0010.TENPO_CD, MDCT0010.BAIHENKAISI_YMD, MDCT0010.BUMON_CD, MDCT0010.JISYA_HBN, MDCT0010.IRO_CD,MDCT0010.BAIHEN_NO)  IN (");
			sRepSqlMax.Append(" AND (MDCT0010_MAX.TENPO_CD, MDCT0010_MAX.BAIHENKAISI_YMD, MDCT0010_MAX.BUMON_CD, MDCT0010_MAX.JISYA_HBN, MDCT0010_MAX.IRO_CD,MDCT0010_MAX.BAIHEN_NO)  IN (");

			IDataList m1List = formVO.GetList("M1");

			for (int i = 0; i < m1List.Count; i++)
			{
				Tl010f02M1Form m1formVO = (Tl010f02M1Form)m1List[i];

				// 選択明細のみ対象
				if (BoSystemConstant.CHECKBOX_ON.Equals(m1formVO.M1selectorcheckbox))
				{

					if (iCnt != 1)
					{
						sRepSql.Append(" , ");
						sRepSqlMax.Append(" , ");
					}

					sRepSql.Append(" ( ");
					sRepSql.Append(" :BIND5_TENPO_CD").Append(iCnt.ToString("000"));			// 店舗コード
					sRepSql.Append(" ,:BIND5_BAIHENKAISI_YMD").Append(iCnt.ToString("000"));	// 売変開始日
					sRepSql.Append(" ,:BIND5_BUMON_CD").Append(iCnt.ToString("000"));			// 部門コード
					sRepSql.Append(" ,:BIND5_JISYA_HBN").Append(iCnt.ToString("000"));			// 自社品番
					sRepSql.Append(" ,:BIND5_IRO_CD").Append(iCnt.ToString("000"));				// 色
					sRepSql.Append(" ,:BIND5_BAIHEN_NO").Append(iCnt.ToString("000"));			// 売変No
					sRepSql.Append(" ) ");

					// 店舗コード
					bindListSql.Add(new BindInfoVO("BIND5_TENPO_CD" + iCnt.ToString("000")
												, sTenpo_cd
												, BoSystemSql.BINDTYPE_STRING)
												);
					// 売変開始日
					bindListSql.Add(new BindInfoVO("BIND5_BAIHENKAISI_YMD" + iCnt.ToString("000")
												, BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd)
												, BoSystemSql.BINDTYPE_NUMBER));
					// 部門コード
					bindListSql.Add(new BindInfoVO("BIND5_BUMON_CD" + iCnt.ToString("000")
												, BoSystemFormat.formatBumonCd(formVO.Bumon_cd_bo)
												, BoSystemSql.BINDTYPE_STRING));

					// 自社品番
					bindListSql.Add(new BindInfoVO("BIND5_JISYA_HBN" + iCnt.ToString("000")
												, BoSystemFormat.formatJisyaHbn(m1formVO.M1jisya_hbn)
												, BoSystemSql.BINDTYPE_STRING));
					// 色
					bindListSql.Add(new BindInfoVO("BIND5_IRO_CD" + iCnt.ToString("000")
												, BoSystemFormat.formatIroCd(m1formVO.Dictionary[Tl010p01Constant.DIC_M1IRO_CD].ToString())
												, BoSystemSql.BINDTYPE_STRING));

					// 売変No
					bindListSql.Add(new BindInfoVO("BIND5_BAIHEN_NO" + iCnt.ToString("000")
												, BoSystemFormat.formatBaihen_shiji_no(formVO.Dictionary[Tl010p01Constant.DIC_M1BAIHEN_NO].ToString())
												, BoSystemSql.BINDTYPE_STRING));

					sRepSqlMax.Append(" ( ");
					sRepSqlMax.Append(" :BIND6_TENPO_CD").Append(iCnt.ToString("000"));				// 店舗コード
					sRepSqlMax.Append(" ,:BIND6_BAIHENKAISI_YMD").Append(iCnt.ToString("000"));		// 売変開始日
					sRepSqlMax.Append(" ,:BIND6_BUMON_CD").Append(iCnt.ToString("000"));			// 部門コード
					sRepSqlMax.Append(" ,:BIND6_JISYA_HBN").Append(iCnt.ToString("000"));			// 自社品番
					sRepSqlMax.Append(" ,:BIND6_IRO_CD").Append(iCnt.ToString("000"));				// 色
					sRepSqlMax.Append(" ,:BIND6_BAIHEN_NO").Append(iCnt.ToString("000"));			// 売変No
					sRepSqlMax.Append(" ) ");

					// 店舗コード
					bindListSqlMax.Add(new BindInfoVO("BIND6_TENPO_CD" + iCnt.ToString("000")
												, sTenpo_cd
												, BoSystemSql.BINDTYPE_STRING)
												);
					// 売変開始日
					bindListSqlMax.Add(new BindInfoVO("BIND6_BAIHENKAISI_YMD" + iCnt.ToString("000")
												, BoSystemFormat.formatDate(formVO.Baihenkaisi_ymd)
												, BoSystemSql.BINDTYPE_NUMBER));
					// 部門コード
					bindListSqlMax.Add(new BindInfoVO("BIND6_BUMON_CD" + iCnt.ToString("000")
												, BoSystemFormat.formatBumonCd(formVO.Bumon_cd_bo)
												, BoSystemSql.BINDTYPE_STRING));

					// 自社品番
					bindListSqlMax.Add(new BindInfoVO("BIND6_JISYA_HBN" + iCnt.ToString("000")
												, BoSystemFormat.formatJisyaHbn(m1formVO.M1jisya_hbn)
												, BoSystemSql.BINDTYPE_NUMBER));
					// 色
					bindListSqlMax.Add(new BindInfoVO("BIND6_IRO_CD" + iCnt.ToString("000")
												, BoSystemFormat.formatIroCd(m1formVO.Dictionary[Tl010p01Constant.DIC_M1IRO_CD].ToString())
												, BoSystemSql.BINDTYPE_STRING));

					// 売変No
					bindListSqlMax.Add(new BindInfoVO("BIND6_BAIHEN_NO" + iCnt.ToString("000")
												, BoSystemFormat.formatBaihen_shiji_no(formVO.Dictionary[Tl010p01Constant.DIC_M1BAIHEN_NO].ToString())
												, BoSystemSql.BINDTYPE_STRING));


					iCnt = iCnt + 1;

				}
			}

			sRepSql.Append(" ) ");
			sRepSqlMax.Append(" ) ");

			// 検索条件1
			BoSystemSql.AddSql(reader, "REPLACE_ADD_WHERE_01", sRepSql.ToString(), bindListSql);
			// 検索条件2
			BoSystemSql.AddSql(reader, "REPLACE_ADD_WHERE_02", sRepSqlMax.ToString(), bindListSqlMax);

		}
		#endregion

	}
}
