using com.xebio.bo.Td010p01.Constant;
using com.xebio.bo.Td010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01004;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Td010p01.Facade
{
  /// <summary>
  /// Td010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td010f01Facade : StandardBaseFacade
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

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td010f01Form f01VO = (Td010f01Form) facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 行数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Td010f01M1Form f01m1VO = (Td010f01M1Form) m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 確定対象がありません。
						ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック

				StringBuilder sRepSql = new StringBuilder();

				// [選択モードNo]が「返品確定」「確定前取消」の場合、
				if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI) || f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{

					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
					sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
					sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");

					for (int i = 0; i < m1List.Count; i++)
					{
						Td010f01M1Form f01m1VO = (Td010f01M1Form)m1List[i];

						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPO_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 管理No
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_KANRI_NO";
							bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1KANRI_NO]);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 処理日付
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYORI_YMD";
							bindVO.Value = (string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);


							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1UPD_YMD], "0")),
									Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1UPD_TM], "0")),
									facadeContext,
									"MDRT0010",
									sRepSql.ToString(),
									bindList,
									1,
									//new[] { "M1kanri_no" },
									null,
									f01m1VO.M1rowno,
									i.ToString(),
									"M1",
									100
							);
						}
					}
				}
				// [選択モードNo]が「確定後取消」の場合、
				else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KAKUTEIGODEL))
				{

					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
					sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");
					sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");

					for (int i = 0; i < m1List.Count; i++)
					{
						Td010f01M1Form f01m1VO = (Td010f01M1Form)m1List[i];

						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							ArrayList bindList = new ArrayList();
							BindInfoVO bindVO = new BindInfoVO();

							// 店舗コード
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_TENPO_CD";
							bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]);
							bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 伝票番号
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_DENPYO_BANGO";
							bindVO.Value = BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Td010p01Constant.DIC_M1DENPYO_BANGO].ToString());
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 処理日付
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_SYORI_YMD";
							bindVO.Value = (string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);


							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1UPD_YMD], "0")),
									Convert.ToDecimal(BoSystemString.Nvl((string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1UPD_TM], "0")),
									facadeContext,
									"MDRT0020",
									sRepSql.ToString(),
									bindList,
									1,
									//new[] { "M1kanri_no" },
									null,
									f01m1VO.M1rowno,
									i.ToString(),
									"M1",
									100
							);
						}
					}

				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#endregion

				#region 更新処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				for (int i = 0; i < m1List.Count; i++)
				{
					Td010f01M1Form f01m1VO = (Td010f01M1Form)m1List[i];
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						#region 返品確定更新
						// [選択モードNo]が「返品確定」の場合、
						if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI))
						{
							// 伝票番号採番
							decimal dDenno = AutoNumber_HenpinDenNo(facadeContext,
																	f01VO,
																	f01m1VO,
																	logininfo
											);
							if (dDenno < 0)
							{
								// 採番不可。
								ErrMsgCls.AddErrMsg("E230", String.Empty, facadeContext);
								return;
							}
							// 採番した伝票番号をディクショナリに格納
							f01m1VO.Dictionary[Td010p01Constant.DIC_M1AOUNUM_DENNO] = dDenno.ToString();

							// [返品確定TBL(H)]を登録する。
							BoSystemLog.logOut("[返品確定TBL(H)]を登録 START");
							int Inscnth = Ins_HenpinKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[返品確定TBL(H)]を登録 END");

							// [返品予定TBL(B)]を検索し、[返品確定TBL(B)]を登録する。
							BoSystemLog.logOut("[返品予定TBL(B)]を検索し、[返品確定TBL(B)]を登録 START");
							int Inscntb = Ins_HenpinKakuteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[返品予定TBL(B)]を検索し、[返品確定TBL(B)]を登録 END");

							// [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。
							BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録 START");
							int Inscntrirekih = Ins_HenpinRirekih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録 END");

							// [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。
							BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録 START");
							int Inscntrirekib = Ins_HenpinRirekib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録 END");

							// [返品予定TBL(H)]を更新する。
							BoSystemLog.logOut("[返品予定TBL(H)]を更新 START");
							int Updcntyoteih = Upd_HenpinYoteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[返品予定TBL(H)]を更新 END");

						}
						#endregion

						#region 確定前取消更新
						// [選択モードNo]が「確定前取消」の場合、
						else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
						{
							// [返品予定TBL(B)]を削除する。
							BoSystemLog.logOut("[返品予定TBL(B)]を削除 START");
							int Delcntyoteib = Del_HenpinYoteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[返品予定TBL(B)]を削除 END");

							// [返品予定TBL(H)]を削除する。
							BoSystemLog.logOut("[返品予定TBL(H)]を削除 START");
							int Delcntyoteih = Del_HenpinYoteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[返品予定TBL(H)]を削除 END");

						}
						#endregion

						#region 確定前取消更新
						// [選択モードNo]が「確定後取消」の場合、
						else if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_KAKUTEIGODEL))
						{
							// 伝票番号
							decimal dDenno = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.Dictionary[Td010p01Constant.DIC_M1DENPYO_BANGO].ToString(), "0"));

							// [返品予定TBL(H)]を更新する。
							BoSystemLog.logOut("[返品予定TBL(H)]を更新 START");
							int Updcntyoteih = Upd_HenpinYoteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[返品予定TBL(H)]を更新 END");

							// [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。
							BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録 START");
							int Inscntrirekih = Ins_HenpinRirekih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録 END");

							// [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。
							BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録 START");
							int Inscntrirekib = Ins_HenpinRirekib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録 END");

							// [返品確定TBL(B)]を削除する。
							BoSystemLog.logOut("[返品確定TBL(B)]を削除 START");
							int Delcnkakuteib = Del_HenpinKakuteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[返品確定TBL(B)]を削除 END");

							// [返品確定TBL(H)]を削除する。
							BoSystemLog.logOut("[返品確定TBL(H)]を削除 START");
							int Delcnkakuteih = Del_HenpinKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[返品確定TBL(H)]を削除 END");


						}
						#endregion
					}
				}

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 印刷処理
				// [選択モードNo]が「返品確定」の場合、
				facadeContext.UserMap.Remove(Td010p01Constant.FCDUO_RRT_FLNM);
				if (f01VO.Stkmodeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI))
				{

					// 帳票ツールに渡すパラメータを格納
					InputData inputData = new InputData();

					for (int i = 0; i < m1List.Count; i++)
					{
						Td010f01M1Form f01m1VO = (Td010f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							// 店舗コード
							inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd((string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));
							// 伝票番号
							inputData.AddScreenParameter(2, (string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1AOUNUM_DENNO]);
							// 処理日付
							inputData.AddScreenParameter(3, (string)f01m1VO.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD]);
							// 店舗控え出力フラグ
							inputData.AddScreenParameter(4, "1");
						}
					}

					string pdfFileNm = "";
					OutputInfo output = new OutputInfo();
					BoSystemReport reportCls = new BoSystemReport();
					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_HENPINDENPYO),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_HENPINDENPYO,
													Td010p01Constant.FORMID_01,
													Td010p01Constant.PGID,
													pdfFileNm
													);

					// PDFをファイルをユーザマップに設定
					facadeContext.UserMap.Add(Td010p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
				}
				#endregion

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


		#region ユーザー定義関数

		#region 返品伝票番号の採番を行う。
		/// <summary>
		/// 返品伝票番号の採番を行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>伝票番号 ※採番不可の場合は、-1を戻す</returns>
		private decimal AutoNumber_HenpinDenNo(IFacadeContext facadeContext,
												Td010f01Form f01Form,
												Td010f01M1Form f01M1Form,
												LoginInfoVO loginInfo)
		{

			Boolean loop = true;
			decimal loopCnt = 0;
			string denno = string.Empty;

			while (loop)
			{
				// 採番を行う
				denno = NumberingCls.Numbering(
											facadeContext,
											BoSystemConstant.AUTONUM_HENPIN_DENPYONO,
											"0000",
											loginInfo.LoginId
						);
				decimal dDenno = Convert.ToDecimal(BoSystemString.Nvl(denno, "0"));


				// 採番値が既にテーブルで使用されていないかチェック(※されている場合は次の番号を採番)
				// XMLからSQLを取得する。
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-01", facadeContext.DBContext);

				// テーブルID指定
				BoSystemSql.AddSql(reader, "TABLE_ID", "MDRT0020");

				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
				sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");
				sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 伝票番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(dDenno);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 処理日付
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD";
				bindVO.Value = (string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 追加の条件
				BoSystemSql.AddSql(reader, "ADD_WHERE", sRepSql.ToString(), bindList);

				// SQL実行
				IList<Hashtable> ItemList = reader.Execute();

				if (ItemList == null || ItemList.Count <= 0)
				{
					// 伝票番号が未存在の場合、採番OK
					loop = false;
				}
				else
				{
					Hashtable ht = (Hashtable)ItemList[0];
					if ((decimal)ht["CNT"] <= 0)
					{
						// 伝票番号が未存在の場合、採番OK
						loop = false;
					}
				}

				loopCnt++;

				if (loopCnt >= 999999)
				{
					// 採番可能数を超えた場合、処理終了
					return -1;
				}
			}
			return Convert.ToDecimal(BoSystemString.Nvl(denno, "-1"));
		}
		#endregion


		#region [返品確定TBL(H)]を登録する。
		/// <summary>
		/// [返品確定TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_HenpinKakuteih(IFacadeContext facadeContext, 
									Td010f01Form f01Form, 
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO, 
									decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-08", facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string) f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_TM], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));
			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1KANRI_NO], "0")));
			// 確定種別
			reader.BindValue("BIND_KAKUTEI_SB", 0);
			// 返品日
			reader.BindValue("BIND_HENPIN_YMD", sysDateVO.Sysdate);
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f01M1Form.M1bumon_cd));
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1BURANDO_CD]));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f01M1Form.M1siiresaki_cd));
			// サブ仕入先コード
			reader.BindValue("BIND_SUBSIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SUBSIIRESAKI_CD]));
			// 返品予定合計数量
			reader.BindValue("BIND_YOTEIGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1suryo, "0")));
			// 返品予定合計金額
			reader.BindValue("BIND_YOTEIGOUKEI_KIN", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1genkakin, "0")));
			// 返品実績合計数量
			reader.BindValue("BIND_JISSEKIGOKEI_SU", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1suryo, "0")));
			// 返品実績合計原価金額
			reader.BindValue("BIND_JISSEKIGOUKEI_KIN", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1genkakin, "0")));
			// 指示番号
			reader.BindValue("BIND_SIJI_BANGO", Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1siji_bango, "0")));
			// 返品理由
			reader.BindValue("BIND_HENPIN_RIYU", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1HENPIN_RIYU], "0")));
			// 担当者コード
			reader.BindValue("BIND_TANTOSYA_CD", BoSystemFormat.formatTantoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TANTOSYA_CD]));
			// 備考
			reader.BindValue("BIND_BIKO", DBNull.Value);
			// 元伝票番号
			reader.BindValue("BIND_MOTODENPYO_BANGO", DBNull.Value);
			// HHT登録日
			reader.BindValue("BIND_HHTADD_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1UPD_YMD], "0")));
			// HHT登録担当者コード
			reader.BindValue("BIND_HHTADDTAN_CD", BoSystemFormat.formatTantoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1UPD_TANCD]));
			// 新黒フラグ
			reader.BindValue("BIND_SHINKURO_FLG", 1);
			// 赤黒区分
			reader.BindValue("BIND_AKAKURO_KBN", 0);	// 黒伝
			// 登録日
			reader.BindValue("BIND_ADD_YMD", sysDateVO.Sysdate);
			// 登録時間
			reader.BindValue("BIND_ADD_TM", sysDateVO.Systime_mili);
			// 登録担当者コード
			reader.BindValue("BIND_ADDTAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 0);
			// 送信依頼フラグ
			reader.BindValue("BIND_SOSINIRAI_FLG", 1);
			// 送信済フラグ
			reader.BindValue("BIND_SOSINZUMI_FLG", 0);
			// 送信日
			reader.BindValue("BIND_SOSIN_YMD", 0);
			// 送信時間
			reader.BindValue("BIND_SOSIN_TM", 0);
			// HHTシリアル番号
			reader.BindValue("BIND_HHTSERIAL_NO", (string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1HHTSERIAL_NO]);
			// HHTシーケンスNo.
			reader.BindValue("BIND_HHTSEQUENCE_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1HHTSEQUENCE_NO], "0")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [返品予定TBL(B)]を検索し、[返品確定TBL(B)]を登録する。
		/// <summary>
		/// [返品予定TBL(B)]を検索し、[返品確定TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_HenpinKakuteib(IFacadeContext facadeContext, 
									Td010f01Form f01Form, 
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO, 
									decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-09", facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		
		#endregion

		#region [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。
		/// <summary>
		/// [返品確定TBL(H)]を検索し、[返品確定履歴TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_HenpinRirekih(IFacadeContext facadeContext,
									Td010f01Form f01Form,
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO,	
									decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-10", facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO1", dDenno);
			reader.BindValue("BIND_DENPYO_BANGO2", dDenno);
			reader.BindValue("BIND_DENPYO_BANGO3", dDenno);
			// 処理種別
			decimal dSyorisb = 1;
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI))
			{
				// 「返品確定」の場合は"1"(返品確定)
				dSyorisb = 1;
			}
			else
			{
				// 「確定後取消」の場合は"2"(取消)
				dSyorisb = 2;
			}
			reader.BindValue("BIND_SYORI_SB1", dSyorisb);
			reader.BindValue("BIND_SYORI_SB2", dSyorisb);
			reader.BindValue("BIND_SYORI_SB3", dSyorisb);
			reader.BindValue("BIND_SYORI_SB4", dSyorisb);
			reader.BindValue("BIND_SYORI_SB5", dSyorisb);
			// 処理日
			reader.BindValue("BIND_SYORI_YMD1", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			reader.BindValue("BIND_SYORI_YMD2", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD1", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));
			reader.BindValue("BIND_TENPO_CD2", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));
			// 履歴処理日付
			reader.BindValue("BIND_RIREKI_SYORI_YMD", sysDateVO.Sysdate);
			// 履歴処理時間
			reader.BindValue("BIND_RIREKI_SYORI_TM", sysDateVO.Systime_mili);
			// 履歴画面表示区分
			reader.BindValue("BIND_RIREKI_DISP_KB", 1);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 0);


			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		
		#endregion

		#region [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。
		/// <summary>
		/// [返品確定TBL(B)]を検索し、[返品確定履歴TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_HenpinRirekib(IFacadeContext facadeContext, 
									Td010f01Form f01Form, 
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO, 
									decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-11", facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO1", dDenno);
			reader.BindValue("BIND_DENPYO_BANGO2", dDenno);
			reader.BindValue("BIND_DENPYO_BANGO3", dDenno);
			// 処理種別
			decimal dSyorisb = 1;
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI))
			{
				// 「返品確定」の場合は"1"(返品確定)
				dSyorisb = 1;
			}
			else
			{
				// 「確定後取消」の場合は"2"(取消)
				dSyorisb = 2;
			}
			reader.BindValue("BIND_SYORI_SB1", dSyorisb);
			reader.BindValue("BIND_SYORI_SB2", dSyorisb);
			reader.BindValue("BIND_SYORI_SB3", dSyorisb);
			// 処理日
			reader.BindValue("BIND_SYORI_YMD1", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			reader.BindValue("BIND_SYORI_YMD2", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD1", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));
			reader.BindValue("BIND_TENPO_CD2", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		
		#endregion

		#region [返品予定TBL(H)]を更新する。
		/// <summary>
		/// [返品予定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_HenpinYoteih(IFacadeContext facadeContext, 
									Td010f01Form f01Form, 
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-12", facadeContext.DBContext);

			// 確定フラグ
			decimal dKakuteiF = 0;
			// 削除フラグ
			decimal dDelF = 0;
			if (f01Form.Stkmodeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI))
			{
				// 「返品確定」の場合は"1"
				dKakuteiF = 1;
				dDelF = 1;
			}
			else
			{
				// その他の場合は"0"
				dKakuteiF = 0;
				dDelF = 0;
			}
			reader.BindValue("BIND_KAKUTEI_FLG", dKakuteiF);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", dDelF);

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		
		#endregion

		#region [返品予定TBL(B)]を削除する。
		/// <summary>
		/// [返品予定TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Del_HenpinYoteib(IFacadeContext facadeContext, 
									Td010f01Form f01Form, 
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-13", facadeContext.DBContext);

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [返品予定TBL(H)]を削除する。
		/// <summary>
		/// [返品予定TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Del_HenpinYoteih(IFacadeContext facadeContext, 
									Td010f01Form f01Form, 
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-14", facadeContext.DBContext);

			// 管理№
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1KANRI_NO], "0")));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		
		#endregion

		#region [返品確定TBL(B)]を削除する。
		/// <summary>
		/// [返品予定TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Del_HenpinKakuteib(IFacadeContext facadeContext, 
									Td010f01Form f01Form, 
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO, 
									decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-15", facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [返品確定TBL(H)]を削除する。
		/// <summary>
		/// [返品予定TBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">伝票番号</param>
		/// <returns>更新件数</returns>
		private int Del_HenpinKakuteih(IFacadeContext facadeContext, 
									Td010f01Form f01Form, 
									Td010f01M1Form f01M1Form, 
									LoginInfoVO loginInfo, 
									SysDateVO sysDateVO, 
									decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-16", facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#endregion
	}
}
