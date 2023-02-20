using com.xebio.bo.Td040p01.Constant;
using com.xebio.bo.Td040p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;

namespace com.xebio.bo.Td040p01.Facade
{
  /// <summary>
  /// Td040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td040f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnprint)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnprint)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNPRINT_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td040f01Form f01VO = (Td040f01Form)facadeContext.FormVO;

				#endregion

				#region 印刷処理

				// 帳票ID
				string chohyoId = string.Empty;
				// Xの場合
				if (CheckCompanyCls.IsXebio())
				{
					chohyoId = BoSystemConstant.REPORTID_HENPINJISSEKIKAKUNINLIST_X;
				}
				// X以外の場合
				else
				{
					chohyoId = BoSystemConstant.REPORTID_HENPINJISSEKIKAKUNINLIST_V;
				}

				string pdfFileNm = string.Empty;

				//// 帳票ツールに渡すパラメータを格納
				//InputData inputData = new InputData();

				// 条件パラメータ
				InputData inputData = this.AddWhere(f01VO);

				//// 条件１
				//inputData.AddScreenParameter(1, paraWhere);
				//// 回数
				//inputData.AddScreenParameter(2, BoSystemString.Nvl((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Kai_su)]));

				OutputInfo output = new OutputInfo();
				BoSystemReport reportCls = new BoSystemReport();
				// PDFファイル名
				pdfFileNm = string.Format("{0}.{1}",
											BoSystemReport.CreateFileName(chohyoId),
											BoSystemConstant.RPT_PDF_EXTENSION
											);
				// 帳票を出力
				output = reportCls.MdGeneratePDF(inputData,
												chohyoId,
												Td040p01Constant.FORMID_01,
												Td040p01Constant.PGID,
												pdfFileNm
												);

				#region 件数チェック
				if (output.ReportState == ReportState.DataNotFound)
				{
					// 抽出件数は0件です。
					ErrMsgCls.AddErrMsg("E174", string.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Td040p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNPRINT_FRM");

		}
		#endregion

		#region 帳票用パラメータ設定
		/// <summary>
		/// AddWhere 帳票用パラメータ設定
		/// </summary>
		/// <param name="f01VO">Td040f01Form</param>
		/// <returns></returns>
		private InputData AddWhere(Td040f01Form f01VO)
		{
			InputData inputData = new InputData();

			// ①店舗コード
			string tmpTenpo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)];
			inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(tmpTenpo));
			// ②伝票番号FROM
			inputData.AddScreenParameter(2, (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Denpyo_bango_from)]);
			// ③伝票番号TO
			inputData.AddScreenParameter(3, (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Denpyo_bango_to)]);
			// ④仕入先コード
			string tmpSiireCd = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Siiresaki_cd)];
			inputData.AddScreenParameter(4, BoSystemFormat.formatSiiresakiCd(tmpSiireCd));
			// ⑤ブランドコード
			string tmpBurandCd = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Burando_cd)];
			inputData.AddScreenParameter(5, BoSystemFormat.formatBrandCd(tmpBurandCd));
			// ⑥部門コードFROM
			string tmpBumonCdFrom = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Bumon_cd_from)];
			inputData.AddScreenParameter(6, BoSystemFormat.formatBumonCd(tmpBumonCdFrom));
			// ⑦部門コードTO
			string tmpBumonCdTo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Bumon_cd_to)];
			inputData.AddScreenParameter(7, BoSystemFormat.formatBumonCd(tmpBumonCdTo));
			// ⑧入力担当者コード
			string tmpNyuryokuTanCd = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Nyuryokutan_cd)];
			inputData.AddScreenParameter(8, BoSystemFormat.formatTantoCd(tmpNyuryokuTanCd));
			// ⑨返品日FORM
			string tmpHenpinYmdFrom = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Henpin_kakutei_ymd_from)];
			inputData.AddScreenParameter(9, BoSystemFormat.formatDate(tmpHenpinYmdFrom));
			// ⑩返品日TO
			string tmpHenpinYmdTo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Henpin_kakutei_ymd_to)];
			inputData.AddScreenParameter(10, BoSystemFormat.formatDate(tmpHenpinYmdTo));
			// ⑪登録日FROM
			string tmpAddYmdFrom = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Add_ymd_from)];
			inputData.AddScreenParameter(11, BoSystemFormat.formatDate(tmpAddYmdFrom));
			// ⑫登録日TO
			string tmpAddYmdTo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Add_ymd_to)];
			inputData.AddScreenParameter(12, BoSystemFormat.formatDate(tmpAddYmdTo));
			// ⑬返品理由
			string tmpHenpinRiyu = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Henpin_riyu)];
			inputData.AddScreenParameter(13, tmpHenpinRiyu);
			// ⑭自社品番
			string tmpJishaHbn = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Old_jisya_hbn)];
			inputData.AddScreenParameter(14, BoSystemFormat.formatJisyaHbn(tmpJishaHbn));
			// ⑮JANコード
			string tmpScanCd = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Scan_cd)];
			inputData.AddScreenParameter(15, BoSystemFormat.formatJanCd(tmpScanCd));
			// ⑯回数
			string tmpKaisu = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Kai_su)];
			inputData.AddScreenParameter(16, tmpKaisu);


			return inputData;

			/*
			StringBuilder sRepSql = new StringBuilder();


			#region 検索条件パラメータ設定

			// 検索条件を設定 -----------

			sRepSql = new StringBuilder();

			string tmpTenpo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)];

			// 店舗コードを設定
			sRepSql.Append(" AND T1.TENPO_CD = '").Append(BoSystemFormat.formatTenpoCd(tmpTenpo)).Append("'");

			// 伝票番号FROMを設定
			string tmpDenpyoFrom = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Denpyo_bango_from)];

			if (!string.IsNullOrEmpty(tmpDenpyoFrom))
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO >= ").Append(BoSystemFormat.formatDenpyoNo(tmpDenpyoFrom));
			}

			// 伝票番号TOを設定
			string tmpDenpyoTo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Denpyo_bango_to)];

			if (!string.IsNullOrEmpty(tmpDenpyoTo))
			{
				sRepSql.Append(" AND T1.DENPYO_BANGO <= ").Append(BoSystemFormat.formatDenpyoNo(tmpDenpyoTo));
			}

			// 仕入先コードを設定

			if (!string.IsNullOrEmpty(tmpSiireCd))
			{
				sRepSql.Append(" AND T1.SIIRESAKI_CD = '").Append(BoSystemFormat.formatSiiresakiCd(tmpSiireCd)).Append("'");
			}

			// ブランドコードを設定
			string tmpBurandCd = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Burando_cd)];

			if (!string.IsNullOrEmpty(tmpBurandCd))
			{
				sRepSql.Append(" AND T1.BURANDO_CD = '").Append(BoSystemFormat.formatBrandCd(tmpBurandCd)).Append("'");
			}

			// 部門FROMを設定
			string tmpBumonCdFrom = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Bumon_cd_from)];

			if (!string.IsNullOrEmpty(tmpBumonCdFrom))
			{
				sRepSql.Append(" AND T1.BUMON_CD >= '").Append(BoSystemFormat.formatBumonCd(tmpBumonCdFrom)).Append("'");
			}

			// 部門TOを設定
			string tmpBumonCdTo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Bumon_cd_to)];

			if (!string.IsNullOrEmpty(tmpBumonCdTo))
			{
				sRepSql.Append(" AND T1.BUMON_CD <= '").Append(BoSystemFormat.formatBumonCd(tmpBumonCdTo)).Append("'");
			}

			// 入力担当者コードを設定
			string tmpNyuryokuTanCd = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Nyuryokutan_cd)];

			if (!string.IsNullOrEmpty(tmpNyuryokuTanCd))
			{
				sRepSql.Append(" AND T1.UPD_TANCD = '").Append(BoSystemFormat.formatTantoCd(tmpNyuryokuTanCd)).Append("'");
			}

			// 返品確定日FROMを設定
			string tmpHenpinYmdFrom = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Henpin_kakutei_ymd_from)];

			if (!string.IsNullOrEmpty(tmpHenpinYmdFrom))
			{
				sRepSql.Append(" AND T1.HENPIN_YMD >= ").Append(BoSystemFormat.formatDate(tmpHenpinYmdFrom));
			}

			// 返品確定日TOを設定
			string tmpHenpinYmdTo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Henpin_kakutei_ymd_to)];

			if (!string.IsNullOrEmpty(tmpHenpinYmdTo))
			{
				sRepSql.Append(" AND T1.HENPIN_YMD <= ").Append(BoSystemFormat.formatDate(tmpHenpinYmdTo));
			}

			// 登録日FROMを設定
			string tmpAddYmdFrom = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Add_ymd_from)];

			if (!string.IsNullOrEmpty(tmpAddYmdFrom))
			{
				sRepSql.Append(" AND CASE WHEN T1.KANRI_NO = 0");
				sRepSql.Append("     THEN T1.ADD_YMD");
				sRepSql.Append("     ELSE T1.HHTADD_YMD");
				sRepSql.Append("     END        >= ").Append(BoSystemFormat.formatDate(tmpAddYmdFrom));
			}

			// 登録日TOを設定
			string tmpAddYmdTo = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Add_ymd_to)];

			if (!string.IsNullOrEmpty(tmpAddYmdTo))
			{
				sRepSql.Append(" AND CASE WHEN T1.KANRI_NO = 0");
				sRepSql.Append("     THEN T1.ADD_YMD");
				sRepSql.Append("     ELSE T1.HHTADD_YMD");
				sRepSql.Append("     END        <= ").Append(BoSystemFormat.formatDate(tmpAddYmdTo));
			}

			// 返品理由を設定
			string tmpHenpinRiyu = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Henpin_riyu)];

			if (!string.IsNullOrEmpty(tmpHenpinRiyu) && !BoSystemConstant.DROPDOWNLIST_MISENTAKU.Equals(tmpHenpinRiyu))
			{
				sRepSql.Append(" AND T1.HENPIN_RIYU = ").Append(tmpHenpinRiyu);
			}

			// スキャンコードを設定
			string tmpScanCd = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Scan_cd)];

			if (!string.IsNullOrEmpty(tmpScanCd))
			{
				sRepSql.Append(" AND T2.JAN_CD = '").Append(tmpScanCd).Append("'");
			}

			// 自社品番を設定
			string tmpJishaHbn = (string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Old_jisya_hbn)];

			if (!string.IsNullOrEmpty(tmpJishaHbn))
			{
				// 自社品番が10桁の場合
				if (f01VO.Old_jisya_hbn.Length == 10)
				{
					sRepSql.Append(" AND T2.JAN_CD IN (");
					sRepSql.Append("					SELECT");
					sRepSql.Append("						MDMT0130.JAN_CD");
					sRepSql.Append("					FROM MDMT0130");
					sRepSql.Append("					WHERE MDMT0130.OLD_XEBIO_CD = '").Append(tmpJishaHbn).Append("'");
					sRepSql.Append("					)");

				}
				// 自社品番が10桁以外の場合
				else
				{
					sRepSql.Append(" AND T2.JISYA_HBN = '").Append(tmpJishaHbn).Append("'");
				}
			}

			return sRepSql.ToString();

			#endregion
			*/
		}

		#endregion

	}
}
