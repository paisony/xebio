using com.xebio.bo.Tm050p01.Constant;
using com.xebio.bo.Tm050p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01024;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01015;
using Common.Business.V03000.V03005;
using Common.Business.V03000.V03006;
using Common.Business.V03000.V03007;
using Common.Business.V03000.V03008;
using Common.Business.V03000.V03009;
using Common.Business.V03000.V03010;
using Common.Business.V03000.V03011;
using Common.Business.V03000.V03012;
using Common.Business.V03000.V03013;
using Common.Business.V03000.V03014;
using Common.Standard.Base;
using Common.Standard.Constant;
using Common.Standard.Csv;
using Common.Standard.FileLoad;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tm050p01.Facade
{
  /// <summary>
  /// Tm050f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm050f01Facade : StandardBaseFacade
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
			//	//コネクションを取得して、トランザクションを開始する。
			//	BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//	//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				BoSystemLog.logOut("▼初期化▼");
				#region 初期化
				// FormVO取得
				// 画面より情報を取得する。
				Tm050f01Form f01VO = (Tm050f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 呼出元画面ID
				string formId = (string)f01VO.Dictionary[Tm050p01Constant.DIC_FORM_ID];

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();
				#endregion
				BoSystemLog.logOut("▲初期化▲");

				BoSystemLog.logOut("▼CSV読込▼");
				#region CSV読込
				// アップロード情報取得
                IList<UploadInfo> list = facadeContext.GetUserObject(Tm050p01Constant.FCDUO_UPLOAD_INFO) as IList<UploadInfo>;

				// CSV読込部品取得
				StandardCsvReader reader = StandardCsvReader.GetInstance();

				// CSV読込
				IList<IList<string>> csvData = reader.GetCsvList(list[0].getFullPath());
				#endregion
				BoSystemLog.logOut("▲CSV読込▲");

				BoSystemLog.logOut("▼業務チェック▼");
				#region 業務チェック
				// 2-1 取込件数
				// Dictionary.[最大件数]＞Dictionary.[現在行数]＋CSV件数の場合、エラー
				if (!formId.Equals(Tm050p01Constant.FORMID_TF060F01))
				{
					// 予算登録（TF060F01）以外の場合

					int maxCnt = Convert.ToInt32(f01VO.Dictionary[Tm050p01Constant.DIC_MAX_ROW_CNT]);	// 最大件数
					int curCnt = Convert.ToInt32(f01VO.Dictionary[Tm050p01Constant.DIC_CUR_ROW_CNT]);	// 現在件数

					if (maxCnt < curCnt + csvData.Count)
					{
						// 取込結果が%1件を超えています。
						ErrMsgCls.AddErrMsg("E154", maxCnt.ToString(), facadeContext);
					}
				}

				if (MessageDisplayUtil.HasError(facadeContext))
				{
					// エラーが存在した場合、明細表示
					#region 画面編集
					this.EditForm(facadeContext);
					#endregion

					return;
				}
				#endregion
				BoSystemLog.logOut("▲業務チェック▲");

				BoSystemLog.logOut("▼CSV項目チェック▼");
				#region CSV項目チェック
				IList<Hashtable> importInfo = this.CheckCsv(facadeContext, csvData, formId);

				if (MessageDisplayUtil.HasError(facadeContext))
				{
					// エラーが存在した場合、明細表示
					#region 画面編集
					this.EditForm(facadeContext);
					#endregion

					return;
				}
				#endregion
				BoSystemLog.logOut("▲CSV項目チェック▲");

				if (!MessageDisplayUtil.HasError(facadeContext))
				{
					// ファサードコンテキストに取込情報を設定
					facadeContext.SetUserObject(Tm050p01Constant.FCDUO_IMPORT_INFO, importInfo);
				}
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

			//	//トランザクションをコミットする。
			//	CommitTransaction(facadeContext);
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion

		#region 画面編集処理
		/// <summary>
		/// 画面編集処理
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		private void EditForm(IFacadeContext facadeContext)
		{
			// 明細データ取得
			IDataList m1List = ((Tm050f01Form)facadeContext.FormVO).GetList("M1");

			// メッセージリスト取得
			List<MessageInfoVO> messageList = MessageDisplayUtil.GetMessageList(facadeContext);

			int rowNo = 0;
			foreach (MessageInfoVO msgInf in messageList)
			{
				rowNo++;

				if (rowNo > 100)
				{
					// エラーが100件を超過した場合
					break;
				}

				Tm050f01M1Form m1 = new Tm050f01M1Form();

				m1.M1rowno = rowNo.ToString();	// Ｍ１行番号
				m1.M1err_nm = msgInf.Message;	// Ｍ１エラー内容

				// 明細追加
				m1List.Add(m1, true);
			}

			// メッセージリスト削除
			facadeContext.RemoveUserObject(PageConstant.MESSAGE_LIST);

			if (rowNo > 100)
			{
				// 100件超過メッセージを表示
				ErrMsgCls.AddErrMsg("E225", string.Empty, facadeContext);
			}
		}
		#endregion

		#region CSVチェック処理
		/// <summary>
		/// CSVチェック処理
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="csvData">CSVデータ</param>
		/// <param name="formId">呼出元画面ID</param>
		/// <returns>取込情報</returns>
		private IList<Hashtable> CheckCsv(IFacadeContext facadeContext, IList<IList<string>> csvData, string formId)
		{
			// 取込情報
			IList<Hashtable> importInfo = new List<Hashtable>();

			// CSVチェック情報取得
			CsvCheckInfoVO checkInfo = (CsvCheckInfoVO)((Tm050f01Form)facadeContext.FormVO).Dictionary[Tm050p01Constant.DIC_CSV_CHECK_INFO];

			// メッセージ格納用変数
			IList<IList<string>> messageList = new List<IList<string>>();

			// スキャンコード格納用変数
			IList<string> scanCdList = new List<string>();

			// 取込対象フラグリスト
			IList<bool> importFlgList = new List<bool>();

			// 発注MST情報
			IList<Hashtable> hachuMstInfo = null;

			// 対象行の日リスト（予算登録用）
			IList<int> targetDayList = new List<int>();
			targetDayList.Add(0);

			// 月度の末日（予算登録用）
			int lastDay = 0;
			if (formId.Equals(Tm050p01Constant.FORMID_TF060F01))
			{
				// 予算登録（TF060F01）の場合
				// 対象の月度
				DateTime target;
				if (DateTime.TryParseExact(checkInfo.Monthly, "yyyyMM", null, System.Globalization.DateTimeStyles.None, out target))
				{
					// 末日
					lastDay = DateTime.DaysInMonth(target.Year, target.Month);
				}
			}

			int rowNo = 0;
			foreach (IList<string> csvRow in csvData)
			{
				rowNo++;

				#region ●項目数チェック
				if (csvRow.Count > 0
					&& !V03010Check.CsvColumnsCheck(csvRow, checkInfo.List_csv_item_info.Count, facadeContext, rowNo))
				{
					// エラーの場合
					// チェック中止
					return null;
				}
				#endregion
			}

			rowNo = 0;
			foreach (IList<string> csvRow in csvData)
			{
				rowNo++;

				#region 取込対象行判定
				bool isTarget = true;
				if (csvRow.Count == 0)
				{
					// 空白行の場合
					isTarget = false;
				}
				else if (formId.Equals(Tm050p01Constant.FORMID_TF060F01))
				{
					// 予算登録（TF060F01）の場合
					isTarget = false;
					int day;
					if (int.TryParse(csvRow[checkInfo.Index_day], out day)
						&& (day <= 0 || day > lastDay))
					{
						// 日が月度に存在しない日付の場合
						for (int i = checkInfo.Index_day + 1; i < csvRow.Count; i++)
						{
							if (!string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(csvRow[i])))
							{
								// 部門１～５に0以外が設定されていた場合
								isTarget = true;

								// 対象行の日リストに追加
								targetDayList.Add(day);

								break;
							}
						}
					}
					else
					{
						// 変換失敗、または存在する日付の場合
						isTarget = true;

						if (day != 0)
						{
							// 変換成功時
							// 対象行の日リストに追加
							targetDayList.Add(day);
						}
					}
				}

				// 取込対象フラグ設定
				importFlgList.Add(isTarget);

				if (!isTarget)
				{
					// 対象外
					// 空のリストを設定
					messageList.Add(new List<string>());
					continue;
				}
				#endregion

				#region ●入力値チェック
				for (int i = 0; i < csvRow.Count; i++)
				{
					// 要素取得
					string value = csvRow[i];

					// 項目チェック情報取得
					CsvCheckItemInfoVO itemInfo = checkInfo.List_csv_item_info[i];

					#region ■必須チェック
					if (itemInfo.Required_flg)
					{
						V03005Check.CsvRequiredCheck(value, facadeContext, rowNo, itemInfo.Item_name);
					}
					#endregion

					#region ■属性チェック
					switch (itemInfo.Type_kbn)
					{
						case CsvCheckItemInfoVO.TYPE_KBN_HALF_NUM:
							// 半角数字のみ
							V03006Check.CsvHalfNumCheck(value, facadeContext, rowNo, itemInfo.Item_name);
							break;

						case CsvCheckItemInfoVO.TYPE_KBN_NUMERIC_HYPHEN:
							// 数値のみ
							V03012Check.CsvNumericCheck(value, facadeContext, rowNo, itemInfo.Item_name);
							break;

						case CsvCheckItemInfoVO.TYPE_KBN_NUMERIC:
							// 数値のみ（0以上）
							V03012Check.CsvNumericCheck(value, facadeContext, rowNo, itemInfo.Item_name);
							V03009Check.CsvMinusCheck(value, facadeContext, rowNo, itemInfo.Item_name);
							break;

						case CsvCheckItemInfoVO.TYPE_KBN_ILLEGAL:
							// 禁則文字以外
							V03013Check.CsvIllegalCharCheck(value, facadeContext, rowNo, itemInfo.Item_name);
							break;

						default:
							break;
					}
					#endregion

					#region ■桁数チェック
					if (i == checkInfo.Index_scan_cd)
					{
						// スキャンコード
						V03011Check.CsvScanCdLengthCheck(value, facadeContext, rowNo, itemInfo.Item_name);
					}
					else if (itemInfo.Max_length > 0)
					{
						V03007Check.CsvLengthCheck(value, itemInfo.Max_length, facadeContext, rowNo, itemInfo.Item_name);
					}
					#endregion

					#region ■バイト数チェック
					if (itemInfo.Max_byte > 0)
					{
						V03014Check.CsvByteLengthCheck(value, itemInfo.Max_byte, facadeContext, rowNo, itemInfo.Item_name);
					}
					#endregion

					#region ■０チェック
					if (itemInfo.Zero_check_flg)
					{
						V03008Check.CsvZeroCheck(value, facadeContext, rowNo, itemInfo.Item_name);
					}
					#endregion

					#region ■出荷店コードチェック
					if (!string.IsNullOrEmpty(itemInfo.Shukka_ten_cd)
						&& !string.IsNullOrEmpty(value))
					{
						// 出荷店コードが設定されている場合
						if (!BoSystemFormat.formatTenpoCd(value).Equals(BoSystemFormat.formatTenpoCd(itemInfo.Shukka_ten_cd)))
						{
							// 一致しない場合
							ErrMsgCls.AddErrMsg("E200", string.Empty, facadeContext, null, rowNo.ToString(), null, null);
						}
					}
					#endregion

					#region ■入荷店コードチェック
					if (!string.IsNullOrEmpty(itemInfo.Nyuka_ten_cd)
						&& !string.IsNullOrEmpty(value))
					{
						// 入荷店コードが設定されている場合
						if (!BoSystemFormat.formatTenpoCd(value).Equals(BoSystemFormat.formatTenpoCd(itemInfo.Nyuka_ten_cd)))
						{
							// 一致しない場合
							ErrMsgCls.AddErrMsg("E201", string.Empty, facadeContext, null, rowNo.ToString(), null, null);
						}
					}
					#endregion
				}

				if (MessageDisplayUtil.HasError(facadeContext))
				{
					// エラーがある場合
					// メッセージリストに移動
					messageList.Add(MoveMessageList(facadeContext));
					continue;
				}
				#endregion

				#region ●関連チェック
				for (int i = 0; i < csvRow.Count; i++)
				{
					// 要素取得
					string value = csvRow[i];

					// 項目チェック情報取得
					CsvCheckItemInfoVO itemInfo = checkInfo.List_csv_item_info[i];

					#region ■店舗コード存在チェック
					if (itemInfo.Mst_check_id.Equals(CsvCheckItemInfoVO.MST_CHECK_ID_TENPO))
					{
						BoSystemLog.logOut("▼ " + DateTime.Now.ToString("HH:mm:ss.fff") + " 店舗コード存在チェック" + rowNo + " ▼", BoSystemLog.LOGLEVEL_INFO);
						// 店舗MSTチェック
						Hashtable tenpoInfo = V01001Check.CheckTenpo(
							BoSystemFormat.formatTenpoCd(value),	// 店舗コード
							facadeContext,							// ファサードコンテキスト
							itemInfo.Item_name,						// 項目名（メッセージパラメータ）
							new string[] { string.Empty },			// エラー項目ID
							rowNo.ToString(),						// 行番号
							null,									// インデックス
							null,									// 明細ID
							0										// 表示件数
							);
						BoSystemLog.logOut("▲ " + DateTime.Now.ToString("HH:mm:ss.fff") + " 店舗コード存在チェック" + rowNo + " ▲", BoSystemLog.LOGLEVEL_INFO);
					}
					#endregion

					#region ■担当者コード存在チェック
					if (itemInfo.Mst_check_id.Equals(CsvCheckItemInfoVO.MST_CHECK_ID_TANTOSHA))
					{
						Hashtable tantoshaInfo = V01005Check.CheckTanto(
							BoSystemFormat.formatTantoCd(value),	// 担当者コード
							facadeContext,							// ファサードコンテキスト
							itemInfo.Item_name,						// 項目名（メッセージパラメータ）
							new string[] { string.Empty },			// エラー項目ID
							rowNo.ToString(),						// 行番号
							null,									// インデックス
							null,									// 明細ID
							0										// 表示件数
							);
					}
					#endregion

					#region ■名称コード存在チェック
					if (itemInfo.Mst_check_id.Equals(CsvCheckItemInfoVO.MST_CHECK_ID_MEISHO))
					{
						Hashtable meishoInfo = V01015Check.CheckMeisyo(
							itemInfo.Sikibetsu_cd,			// 識別コード
							value,							// 名称コード
							facadeContext,					// ファサードコンテキスト
							itemInfo.Item_name,				// 項目名（メッセージパラメータ）
							new string[] { string.Empty },	// エラー項目ID
							rowNo.ToString(),				// 行番号
							null,							// インデックス
							null,							// 明細ID
							0								// 表示件数
							);
					}
					#endregion

					#region ■スキャンコード存在チェック（リスト追加のみ）
					if (i == checkInfo.Index_scan_cd
						&& itemInfo.Mst_check_id.Equals(CsvCheckItemInfoVO.MST_CHECK_ID_HATCHU)
						&& !string.IsNullOrEmpty(value))
					{
						// スキャンコードリストに追加
						scanCdList.Add(value);
						// メッセージリストに追加
						MessageDisplayUtil.AddErrorMessage("scan_cd", facadeContext);
					}
					#endregion

					#region ■日付連番チェック
					if (formId.Equals(Tm050p01Constant.FORMID_TF060F01))
					{
						// 予算登録（TF060F01）の場合
						
						// 1日から画面で入力した月度の末日まで、全ての日付が連番で入力されてなければエラー
						if (i == checkInfo.Index_day)
						{
							int day;
							int.TryParse(value, out day);

							if (day > 0
								&& day <= lastDay
								&& day != (targetDayList[targetDayList.Count - 2] + 1))
							{
								// 日が連番になっていない場合
								ErrMsgCls.AddErrMsg("E179", string.Empty, facadeContext, null, rowNo.ToString(), null, null);
							}
						}
					}
					#endregion
				}

				#region ■日付存在チェック
				if (formId.Equals(Tm050p01Constant.FORMID_TF060F01))
				{
					// 予算登録（TF060F01）の場合
					// 日の項目チェック情報
					CsvCheckItemInfoVO dayInfo = checkInfo.List_csv_item_info[checkInfo.Index_day];

					int dayValue;
					int.TryParse(csvRow[checkInfo.Index_day], out dayValue);

					// 月度に存在しない日付かつ部門１～５に0以外が設定されている場合、エラー
					if (dayValue <= 0
						|| dayValue > lastDay)
					{
						// 日が月度に存在しない日付の場合
						for (int i = checkInfo.Index_day + 1; i < csvRow.Count; i++)
						{
							if (!string.IsNullOrEmpty(BoSystemString.ZeroToEmpty(csvRow[i])))
							{
								// 部門１～５に0以外が設定されていた場合
								ErrMsgCls.AddErrMsg("E111", dayInfo.Item_name, facadeContext, null, rowNo.ToString(), null, null);
								break;
							}
						}
					}
				}
				#endregion

				if (MessageDisplayUtil.HasError(facadeContext))
				{
					// エラーがある場合
					// メッセージリストに移動
					messageList.Add(MoveMessageList(facadeContext));
					continue;
				}
				#endregion

				// エラーが存在しなかった場合、空のリストを設定
				messageList.Add(new List<string>());
			}

			#region ■日付連番チェック
			if (formId.Equals(Tm050p01Constant.FORMID_TF060F01))
			{
				// 予算登録（TF060F01）の場合
				if (targetDayList[targetDayList.Count - 1] != lastDay)
				{
					// 最終行の日が月度の末日と一致しない場合
					ErrMsgCls.AddErrMsg("E179", string.Empty, facadeContext);
				}
			}
			#endregion

			if (MessageDisplayUtil.HasError(facadeContext))
			{
				// エラーがある場合
				// メッセージリストに移動
				messageList.Add(MoveMessageList(facadeContext));
			}

			#region ■スキャンコード存在チェック（発注MST検索）
			if (scanCdList.Count > 0)
			{
				BoSystemLog.logOut("▼ " + DateTime.Now.ToString("HH:mm:ss.fff") + " スキャンコード存在チェック ▼", BoSystemLog.LOGLEVEL_INFO);
				#region 検索処理

				#region 検索情報VO設定
				SearchHachuVO condition = new SearchHachuVO();
				if (
					formId.Equals(Tm050p01Constant.FORMID_TF020F02)		// 商品経費振替申請(V)-明細
					|| formId.Equals(Tm050p01Constant.FORMID_TF021F02)	// 商品経費振替申請(X)-明細
					|| formId.Equals(Tm050p01Constant.FORMID_TF070F02)	// 盗難品登録-明細
					)
				{
					// 店舗コード
					condition.Tencd = checkInfo.Tenpo_cd;

					// 店別単価マスタ検索フラグＯＮ
					condition.Pluflg = 1;
				}
				#endregion

				#region 追加抽出条件設定
				StringBuilder addSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = null;

				#region スキャンコード
				StringBuilder sbJanCd = new StringBuilder();
				StringBuilder sbSyohinCd = new StringBuilder();

				// ＪＡＮコードのバインド
				for (int i = 0; i < scanCdList.Count; i++)
				{
					// スキャンコード
					string scanCd = scanCdList[i];

					if (scanCd.Length != 18)
					{
						// 18桁以外の場合

						// バインドID連番（バインド数に応じて0埋め）
						string bindIdNumber = i.ToString().PadLeft(scanCdList.Count.ToString().Length, '0');

						if (sbJanCd.Length > 0)
						{
							sbJanCd.Append(",");
						}
						sbJanCd.Append(" :SCAN_CD").Append(bindIdNumber);

						bindVO = new BindInfoVO();
						bindVO.BindId = "SCAN_CD" + bindIdNumber;
						bindVO.Value = BoSystemFormat.formatJanCd(scanCd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;
						bindList.Add(bindVO);
					}
				}

				// 商品コード検索用のバインド
				for (int i = 0; i < scanCdList.Count; i++)
				{
					// スキャンコード
					string scanCd = scanCdList[i];

					if (scanCd.Length == 18)
					{
						// 18桁の場合

						// バインドID連番（バインド数に応じて0埋め）
						string bindIdNumber = i.ToString().PadLeft(scanCdList.Count.ToString().Length, '0');

						if (sbSyohinCd.Length > 0)
						{
							sbSyohinCd.Append(",");
						}
						sbSyohinCd.Append(" :SCAN_CD").Append(bindIdNumber);

						bindVO = new BindInfoVO();
						bindVO.BindId = "SCAN_CD" + bindIdNumber;
						bindVO.Value = BoSystemFormat.syohinCdGetSearch(scanCd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;
						bindList.Add(bindVO);
					}
				}

				if (sbJanCd.Length > 0
					|| sbSyohinCd.Length > 0)
				{
					addSql.Append(" AND (").AppendLine();

					if (sbJanCd.Length > 0)
					{
						addSql.Append("     SYOHIN.JAN_CD IN (").Append(sbJanCd).Append(")").AppendLine();
					}
					if (sbJanCd.Length > 0
						&& sbSyohinCd.Length > 0)
					{
						addSql.Append("     OR").AppendLine();
					}
					if (sbSyohinCd.Length > 0)
					{
						addSql.Append("     SYOHIN.SYOHIN_CD_SERCH IN (").Append(sbSyohinCd).Append(")").AppendLine();
					}

					addSql.Append(" )").AppendLine();
				}
				#endregion

				#endregion

				// ヒント句設定
				string hint = string.Empty;

				// ソート条件設定
				string orderBy = string.Empty;

				// 発注マスタ取得部品呼び出し
				hachuMstInfo = SearchHachu.SearchHachuMst(condition, facadeContext.DBContext, 1, addSql, bindList, hint, orderBy);

				#endregion
				BoSystemLog.logOut("▲ " + DateTime.Now.ToString("HH:mm:ss.fff") + " スキャンコード存在チェック ▲", BoSystemLog.LOGLEVEL_INFO);
			}
			#endregion

			for (int i = 0; i < csvData.Count; i++)
			{
				if (!importFlgList[i])
				{
					// 対象外
					continue;
				}

				// CSV行データ
				IList<string> csvRow = csvData[i];
				// CSVエラーリスト
				IList<string> msgRow = messageList[i];
				// 発注MST行データ
				Hashtable hachuRow = new Hashtable();

				#region ■エラー情報設定
				foreach (string message in msgRow)
				{
					if (message.Equals("scan_cd"))
					{
						#region ■スキャンコード存在チェック（エラー判定）
						// スキャンコード
						string scanCd = csvRow[checkInfo.Index_scan_cd];
						// JANコード
						string janCd = string.Empty;
						// 商品コード検索用
						string syohinCdSerch = string.Empty;

						if (scanCd.Length == 18)
						{
							// 商品コード検索用
							syohinCdSerch = BoSystemFormat.syohinCdGetSearch(scanCd);
						}
						else
						{
							// ＪＡＮコード
							janCd = BoSystemFormat.formatJanCd(scanCd);
						}

						bool isError = true;
						foreach (Hashtable row in hachuMstInfo)
						{
							if (janCd.Equals(row["JAN_CD"])
								|| syohinCdSerch.Equals(row["SYOHIN_CD_SERCH"]))
							{
								// ＪＡＮコード、または商品コード検索用に一致した場合
								hachuRow = GetCopy(row);
								isError = false;
								break;
							}
						}
						if (isError)
						{
							// エラーメッセージ追加
							ErrMsgCls.AddErrMsg("E111", checkInfo.List_csv_item_info[checkInfo.Index_scan_cd].Item_name, facadeContext, null, (i + 1).ToString(), null, null);
						}
						#endregion
					}
					else
					{
						// エラー情報設定
						MessageDisplayUtil.AddErrorMessage(message, facadeContext);
					}
				}
				#endregion

				#region ■取込情報編集
				if (!MessageDisplayUtil.HasError(facadeContext))
				{
					for (int j = 0; j < checkInfo.List_csv_item_info.Count; j++)
					{
						// 発注MST情報にCSV情報を追加設定
						hachuRow.Add(checkInfo.List_csv_item_info[j].Item_id, csvRow[j]);
					}

					// 取込情報に追加
					importInfo.Add(hachuRow);
				}
				#endregion
			}

			#region ■エラー情報設定（項目・行単位でないエラー）
			for (int i = csvData.Count; i < messageList.Count; i++)
			{
				foreach (string message in messageList[i])
				{
					// エラー情報設定
					MessageDisplayUtil.AddErrorMessage(message, facadeContext);
				}
			}
			#endregion

			return importInfo;
		}
		#endregion

		#region ファサードコンテキストのメッセージリストを変数に移動
		/// <summary>
		/// ファサードコンテキストのメッセージリストを変数に移動し、戻り値とします。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>移動先のメッセージリスト</returns>
		private static IList<string> MoveMessageList(IFacadeContext facadeContext)
		{
			// 移動先メッセージリスト
			IList<string> messageListTo = new List<string>();

			// メッセージリスト取得
			List<MessageInfoVO> messageList = MessageDisplayUtil.GetMessageList(facadeContext);

			if (messageList != null)
			{
				// メッセージ移動
				foreach (MessageInfoVO msgInfo in messageList)
				{
					messageListTo.Add(msgInfo.Message);
				}

				// メッセージリスト削除
				facadeContext.RemoveUserObject(PageConstant.MESSAGE_LIST);
			}

			return messageListTo;
		}
		#endregion

		#region Hashtableのコピーを取得
		/// <summary>
		/// Hashtableのコピーを取得
		/// </summary>
		/// <param name="src">コピー元</param>
		/// <returns>コピー元のコピー</returns>
		private static Hashtable GetCopy(Hashtable src)
		{
			if (src == null)
			{
				return null;
			}

			Hashtable dst = new Hashtable();

			foreach(DictionaryEntry de in src)
			{
				dst[de.Key] = de.Value;
			}

			return dst;
		}
		#endregion
	}
}
