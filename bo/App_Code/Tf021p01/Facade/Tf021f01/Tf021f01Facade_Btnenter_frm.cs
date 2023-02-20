using com.xebio.bo.Tf021p01.Constant;
using com.xebio.bo.Tf021p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01004;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01015;
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

namespace com.xebio.bo.Tf021p01.Facade
{
  /// <summary>
  /// Tf021f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf021f01Facade : StandardBaseFacade
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
				Tf021f01Form f01VO = (Tf021f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				#endregion

				#region 業務チェック

				#region 行数チェック

				if (m1List == null || m1List.Count <= 0)
				{
					// 対象行がありません。
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf021f01M1Form f01m1VO = (Tf021f01M1Form)m1List[i];

						// [Ｍ１選択フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
						{
							inputflg = 1;
							break;
						}
					}

					if (inputflg == 0)
					{
						// 対象行がありません。
						ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region マスタチェック

				decimal jidoSyoninKin = 0;

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf021f01M1Form f01m1VO = (Tf021f01M1Form)m1List[i];

					// 2-1 Ｍ１業務稟議No
					//       [選択モードNo]が「申請」で[Ｍ１選択フラグ(隠し)]が"1"、かつ[申請理由]＝"7"(グループ間取引)の以外の場合
					if (   BoSystemConstant.MODE_APPLY.Equals(f01VO.Modeno)
						&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox)
						&& !Tf021p01Constant.SINSEI_KB_GROUP.Equals(f01m1VO.Dictionary[Tf021p01Constant.DIC_M1SINSEIRIYU_KB].ToString()))
					{
					// M１自動承認金額の取得
					Hashtable tmpJidoSyonin = V01015Check.CheckMeisyo(
																	"KHJK",				// 識別コード（自動承認金額）
																	"1",				// 名称コード
																	facadeContext
																	);

					if(!string.IsNullOrEmpty(tmpJidoSyonin["MEISYO_NM"].ToString()))
					{
						jidoSyoninKin = Convert.ToDecimal(tmpJidoSyonin["MEISYO_NM"]);
					}

					decimal maxBaika = 0;
					if (!string.IsNullOrEmpty(f01m1VO.Dictionary[Tf021p01Constant.DIC_M1MAX_BAIKA_TNK].ToString()))
					{
						maxBaika = Convert.ToDecimal(f01m1VO.Dictionary[Tf021p01Constant.DIC_M1MAX_BAIKA_TNK]);
					}

					// 売価が名称MSTから取得した金額以上の商品が存在し、Ｍ１業務稟議Noが入力されていない場合、エラー
					if (   jidoSyoninKin <= maxBaika
						&& string.IsNullOrEmpty(f01m1VO.M1gyomuringi_no))
						{
                            // 業務稟議Noを入力して下さい。
                            ErrMsgCls.AddErrMsg("E121", "業務稟議No", facadeContext, new[] { "M1gyomuringi_no" }, f01m1VO.M1rowno, i.ToString(), "M1");
                        }
                    }

				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 排他チェック

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD		= :BIND_TENPO_CD");
				sRepSql.Append(" AND SYORI_YMD		= :BIND_SYORI_YMD");

				if (BoSystemConstant.MODE_APPLY.Equals(f01VO.Modeno)
					|| BoSystemConstant.MODE_SINSEIMAEDEL.Equals(f01VO.Modeno))
				{
					sRepSql.Append(" AND KANRI_NO		= :BIND_KANRI_NO");
				}
				else
				{
					sRepSql.Append(" AND DENPYO_BANGO	= :BIND_DENPYO_BANGO");
				}

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf021f01M1Form f01m1VO = (Tf021f01M1Form)m1List[i];

					// [Ｍ１確定フラグ(隠し)]が"1"の場合
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 店舗コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 処理日
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SYORI_YMD";
						bindVO.Value = BoSystemFormat.formatDate((string)f01m1VO.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);


						// モードが「申請」「申請前取消」の場合
						if (BoSystemConstant.MODE_APPLY.Equals(f01VO.Modeno)
						|| BoSystemConstant.MODE_SINSEIMAEDEL.Equals(f01VO.Modeno))
						{
							// 管理番号
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_KANRI_NO";
							bindVO.Value = (string)f01m1VO.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO];
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal((string)f01m1VO.Dictionary[Tf021p01Constant.DIC_M1UPD_YMD]),
									Convert.ToDecimal((string)f01m1VO.Dictionary[Tf021p01Constant.DIC_M1UPD_TM]),
									facadeContext,
									"MDAT0100",
									sRepSql.ToString(),
									bindList,
									1,
									null,
									f01m1VO.M1rowno,
									i.ToString(),
									"M1",
									100
							);
						}

						// モードが「申請後取消」の場合
						if (BoSystemConstant.MODE_SINSEIGODEL.Equals(f01VO.Modeno))
						{
							// 伝票番号
							bindVO = new BindInfoVO();
							bindVO.BindId = "BIND_DENPYO_BANGO";
							bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01m1VO.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO]);
							bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
							bindList.Add(bindVO);

							// 排他チェック
							V03003Check.CheckHaitaMaxVal(
									Convert.ToDecimal((string)f01m1VO.Dictionary[Tf021p01Constant.DIC_M1UPD_YMD]),
									Convert.ToDecimal((string)f01m1VO.Dictionary[Tf021p01Constant.DIC_M1UPD_TM]),
									facadeContext,
									"MDAT0020",
									sRepSql.ToString(),
									bindList,
									1,
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

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf021f01M1Form f01m1VO = (Tf021f01M1Form)m1List[i];

					// [Ｍ１選択フラグ(隠し)]が"1"の場合
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
					{

						#region 申請モード

						// モードが「申請」の場合
						if (BoSystemConstant.MODE_APPLY.Equals(f01VO.Modeno))
						{

							// 自動承認フラグの取得
							int jidouSyoninflg = this.GetJidoSyoninFlg(facadeContext,
																		f01VO,
																		f01m1VO,
																		jidoSyoninKin
																		);
						

							// [経費振替予定TBL(H)]を更新する。
							BoSystemLog.logOut("[経費振替予定TBL(H)]を更新 START");
							int Updcntyoteih = Upd_Apl_KeihiFurikaeYoteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, jidouSyoninflg);
							BoSystemLog.logOut("[経費振替予定TBL(H)]を更新 END");

							//経費振替 伝票番号採番
							decimal dDenno = AutoNumber_KeihiHuriDenNo(facadeContext,
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

							// [経費振替申請TBL(H)]を登録する。
							BoSystemLog.logOut("[経費振替申請TBL(H)]を登録 START");
							int Inscntsinseih = Ins_Apl_KeihiFurikaeSinseih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno, jidouSyoninflg);
							BoSystemLog.logOut("[経費振替申請TBL(H)]を登録 END");

							// [経費振替申請TBL(B)]を登録する。
							BoSystemLog.logOut("[経費振替申請TBL(B)]を登録 START");
							int Inscntsinseib = Ins_Apl_KeihiFurikaeSinseib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
							BoSystemLog.logOut("[経費振替申請TBL(B)]を登録 END");

							// 自動承認有りの場合
							if(jidouSyoninflg == 1)
							{
								// [経費振替確定TBL(H)]を登録する。
								BoSystemLog.logOut("[経費振替確定TBL(H)]を登録 START");
								int Inscntkakuteih = Ins_Apl_KeihiFurikaeKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
								BoSystemLog.logOut("[経費振替確定TBL(H)]を登録 END");

								// [経費振替確定TBL(B)]を登録する。
								BoSystemLog.logOut("[経費振替確定TBL(B)]を登録 START");
								int Inscntkakuteib = Ins_Apl_KeihiFurikaeKakuteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO, dDenno);
								BoSystemLog.logOut("[経費振替確定TBL(B)]を登録 END");

								f01m1VO.Dictionary[Tf021p01Constant.DIC_M1TBLFLG] = "2";
							}
							// 自動承認なしの場合
							else
							{
								f01m1VO.Dictionary[Tf021p01Constant.DIC_M1TBLFLG] = "1";
							}

							f01m1VO.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO] = BoSystemFormat.formatDenpyoNo(dDenno);
						}

						#endregion

						#region 申請前取消モード

						// モードが「申請前取消の場合
						if (BoSystemConstant.MODE_SINSEIMAEDEL.Equals(f01VO.Modeno))
						{

							// [経費振替予定TBL(H)]を削除する。
							BoSystemLog.logOut("[経費振替予定TBL(H)]を削除 START");
							int DelcntYotehi = Del_BefTori_KeihiFurikaeYoteih(facadeContext, f01VO, f01m1VO);
							BoSystemLog.logOut("[経費振替予定TBL(H)]を削除 END  ");

							// [経費振替予定TBL(B)]を削除する。
							BoSystemLog.logOut("[経費振替予定TBL(B)]を削除 START");
							int DelcntYoteib = Del_BefTori_KeihiFurikaeYoteib(facadeContext, f01VO, f01m1VO);
							BoSystemLog.logOut("[経費振替予定TBL(B)]を削除 END  ");
						}

						#endregion

						#region 申請後取消モード

						// モードが「申請後取消」の場合
						if (BoSystemConstant.MODE_SINSEIGODEL.Equals(f01VO.Modeno))
						{

							// [経費振替申請TBL(H)]を削除する。
							BoSystemLog.logOut("[経費振替申請TBL(H)]を削除 START");
							int DelcntSinseih = Del_AftTori_KeihiFurikaeSinseih(facadeContext, f01VO, f01m1VO);
							BoSystemLog.logOut("[経費振替申請TBL(H)]を削除 END  ");

							// [経費振替申請TBL(B)]を削除する。
							BoSystemLog.logOut("[経費振替申請TBL(B)]を削除 START");
							int DelcntSinseib = Del_AftTori_KeihiFurikaeSinseib(facadeContext, f01VO, f01m1VO);
							BoSystemLog.logOut("[経費振替申請TBL(B)]を削除 END  ");

							// [経費振替予定TBL(H)]を更新する。
							BoSystemLog.logOut("[経費振替予定TBL(H)]を更新 START");
							int Updcntyoteih = Upd_AftTori_KeihiFurikaeYoteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
							BoSystemLog.logOut("[経費振替予定TBL(H)]を更新 END");

						}

						#endregion
					}

				}

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 印刷処理

				// モードが「申請」の場合
				if (BoSystemConstant.MODE_APPLY.Equals(f01VO.Modeno))
				{
					// 帳票ツールに渡すパラメータを格納

					InputData inputData = new InputData();

					for (int i = 0; i < m1List.Count; i++)
					{
						Tf021f01M1Form f01m1VO = (Tf021f01M1Form)m1List[i];

						// [Ｍ１選択フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
						{
							// 店舗コード
							inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)]));
							// 処理日付
							inputData.AddScreenParameter(2, BoSystemFormat.formatDate(f01m1VO.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD].ToString()));
							// 伝票番号
							inputData.AddScreenParameter(3, BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO].ToString()));
							// テーブル区分
							inputData.AddScreenParameter(4, f01m1VO.Dictionary[Tf021p01Constant.DIC_M1TBLFLG].ToString());
							// 会社コード
							inputData.AddScreenParameter(5, logininfo.CopCd);
							// 店舗控え出力フラグ
							inputData.AddScreenParameter(6, "1");
						}
					}

					string pdfFileNm = string.Empty;
					OutputInfo output = new OutputInfo();
					BoSystemReport reportCls = new BoSystemReport();

					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_X),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEDENPYO_X,
													Tf021p01Constant.FORMID_02,
													Tf021p01Constant.PGID,
													pdfFileNm
													);

					// PDFをファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tf021p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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

		#region 自動承認有無の取得
		/// <summary>
		/// 自動承認有無の取得を行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>自動承認フラグ　0：無／1：有</returns>
		private int GetJidoSyoninFlg(IFacadeContext facadeContext,
									Tf021f01Form f01Form,
									Tf021f01M1Form f01M1Form,
									decimal jidoSyoninKin)
		{
			int jidouSyoninflg = 0;

			// Dictionary.[M１申請理由区分]＝"7"(グループ間取引)の場合
			if (Tf021p01Constant.SINSEI_KB_GROUP.Equals(f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SINSEIRIYU_KB].ToString()))
			{
				jidouSyoninflg = 1;
			}
			// Dictionary.[M１申請理由区分]＝"7"(グループ間取引)以外の場合
			else
			{
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_01, facadeContext.DBContext);

				// テーブルID指定
				BoSystemSql.AddSql(rtSeach, Tf021p01Constant.SQL_ID_01_REP_TABLE_ID1, Tf021p01Constant.TABLE_ID_MDAT0101 + " T1");

				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD		= :BIND_TENPO_CD");
				sRepSql.Append(" AND SYORI_YMD		= :BIND_SYORI_YMD");
				sRepSql.Append(" AND KANRI_NO		= :BIND_KANRI_NO");
				sRepSql.Append(" AND BAIKA_TNK	   >= :BIND_BAIKA_TNK");


				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				// 処理日付
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD";
				bindVO.Value = BoSystemFormat.formatDate((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				// 管理番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KANRI_NO";
				bindVO.Value = (string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				// 自動承認金額
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BAIKA_TNK";
				bindVO.Value = jidoSyoninKin.ToString();
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);


				// 追加の条件
				BoSystemSql.AddSql(rtSeach, Tf021p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql.ToString(), bindList);

				// SQL実行
				IList<Hashtable> ItemList = rtSeach.Execute();

				// 未存在の場合
				if (ItemList == null || ItemList.Count <= 0)
				{
					jidouSyoninflg = 0;
				}
				else
				{
					Hashtable ht = (Hashtable)ItemList[0];
					// 対象データが０件の場合は自動承認ありとする。
					if ((decimal)ht["CNT"] == 0)
					{
						jidouSyoninflg = 1;
					}
				}
			}

			return jidouSyoninflg;

		}

		#endregion

		#region 経費振替伝票番号の採番を行う。(SQL_ID_01によりチェック含む)
		/// <summary>
		/// 経費振替伝票番号の採番を行う。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>経費振替伝票番号 ※採番不可の場合は、-1を戻す</returns>
		public static decimal AutoNumber_KeihiHuriDenNo(IFacadeContext facadeContext,
														Tf021f01Form f01Form,
														Tf021f01M1Form f01M1Form,
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
											BoSystemConstant.AUTONUM_KEIHURI_DENPYONO,
											"0000",
											loginInfo.LoginId
						);
				decimal dDenno = Convert.ToDecimal(denno);


				// 採番値が既にテーブルで使用されていないかチェック(※されている場合は次の番号を採番)
				// XMLからSQLを取得する。
				FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_01, facadeContext.DBContext);

				// テーブルID指定
				BoSystemSql.AddSql(reader, Tf021p01Constant.SQL_ID_01_REP_TABLE_ID1, Tf021p01Constant.TABLE_ID_MDAT0020 + " T1");

				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				sRepSql.Append(" AND T1.DENPYO_BANGO	= :BIND_DENPYO_BANGO");
				sRepSql.Append(" AND T1.SYORI_YMD		= :BIND_SYORI_YMD");
				sRepSql.Append(" AND T1.TENPO_CD		= :BIND_TENPO_CD");

				// 伝票番号
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_DENPYO_BANGO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo(dDenno);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 処理日付
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD";
				bindVO.Value = BoSystemFormat.formatDate((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 追加の条件
				BoSystemSql.AddSql(reader, Tf021p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql.ToString(), bindList);

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

				if (loopCnt >= Tf021p01Constant.KEIHIHURI_DENPYO_BANGO_MAX)
				{
					// 採番可能数を超えた場合、処理終了
					return -1;
				}
			}
			return Convert.ToDecimal(BoSystemString.Nvl(denno, "-1"));
		}
		#endregion

		#region [経費振替予定TBL(H)]の更新
		/// <summary>
		/// [経費振替予定TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="jidouSyoninflg">自動承認有無フラグ</param>
		/// <returns>更新件数</returns>
		private int Upd_Apl_KeihiFurikaeYoteih(IFacadeContext facadeContext,
											Tf021f01Form f01Form,
											Tf021f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO,
											int	jidouSyoninflg)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_10, facadeContext.DBContext);

			decimal gyomuringiNo = 0;
			if (!string.IsNullOrEmpty(f01M1Form.M1gyomuringi_no))
			{
				gyomuringiNo = Convert.ToDecimal(f01M1Form.M1gyomuringi_no);
			}

			// 更新内容
			// 申請フラグ
			reader.BindValue("BIND_SINSEI_FLG", 1);
			// 業務稟議No
			reader.BindValue("BIND_GYOMURINGI_NO1", gyomuringiNo);
			reader.BindValue("BIND_GYOMURINGI_NO2", gyomuringiNo);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", jidouSyoninflg);

			// 更新条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));
			// 管理番号
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替申請TBL(H)]の登録
		/// <summary>
		/// [経費振替申請TBL(H)]の登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">採番した伝票番号</param>
		/// <param name="jidouSyoninflg">自動承認有無フラグ</param>
		/// <returns>更新件数</returns>
		private int Ins_Apl_KeihiFurikaeSinseih(IFacadeContext facadeContext,
												Tf021f01Form f01Form,
												Tf021f01M1Form f01M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO,
												decimal dDenno,
												int jidouSyoninflg)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 登録内容
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);
			// 決済状態
			reader.BindValue("BIND_KESSAI_FLG", jidouSyoninflg);
			// 申請日
			reader.BindValue("BIND_APPLY_YMD", sysDateVO.Sysdate);
			// 申請担当者コード
			reader.BindValue("BIND_SINSEITAN_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
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
			reader.BindValue("BIND_SAKUJYO_FLG", jidouSyoninflg);

			// 登録条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));
			// 管理番号
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替申請TBL(B)]の登録
		/// <summary>
		/// [経費振替申請TBL(B)]の登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">採番した伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_Apl_KeihiFurikaeSinseib(IFacadeContext facadeContext,
												Tf021f01Form f01Form,
												Tf021f01M1Form f01M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO,
												decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 登録内容
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);

			// 登録条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));
			// 管理番号
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(H)]の登録
		/// <summary>
		/// [経費振替確定TBL(H)]の登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">採番した伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_Apl_KeihiFurikaeKakuteih(IFacadeContext facadeContext,
												Tf021f01Form f01Form,
												Tf021f01M1Form f01M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO,
												decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 登録条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(B)]の登録
		/// <summary>
		/// [経費振替確定TBL(B)]の登録を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="dDenno">採番した伝票番号</param>
		/// <returns>更新件数</returns>
		private int Ins_Apl_KeihiFurikaeKakuteib(IFacadeContext facadeContext,
												Tf021f01Form f01Form,
												Tf021f01M1Form f01M1Form,
												LoginInfoVO loginInfo,
												SysDateVO sysDateVO,
												decimal dDenno)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 登録条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", dDenno);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替予定TBL(H)]の削除
		/// <summary>
		/// [経費振替予定TBL(H)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_BefTori_KeihiFurikaeYoteih(IFacadeContext facadeContext,
													Tf021f01Form f01Form,
													Tf021f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_15, facadeContext.DBContext);

			// 削除条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));
			// 管理番号
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替予定TBL(B)]の削除
		/// <summary>
		/// [経費振替予定TBL(B)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_BefTori_KeihiFurikaeYoteib(IFacadeContext facadeContext,
													Tf021f01Form f01Form,
													Tf021f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_16, facadeContext.DBContext);

			// 削除条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));
			// 管理番号
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替申請TBL(H)]の削除
		/// <summary>
		/// [経費振替確定TBL(H)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_AftTori_KeihiFurikaeSinseih(IFacadeContext facadeContext,
													Tf021f01Form f01Form,
													Tf021f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_17, facadeContext.DBContext);

			// 削除条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替申請TBL(B)]の削除
		/// <summary>
		/// [経費振替確定TBL(B)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_AftTori_KeihiFurikaeSinseib(IFacadeContext facadeContext,
													Tf021f01Form f01Form,
													Tf021f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_18, facadeContext.DBContext);

			// 削除条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替予定TBL(H)]の更新(申請後取消モード)
		/// <summary>
		/// [経費振替予定TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_AftTori_KeihiFurikaeYoteih(IFacadeContext facadeContext,
													Tf021f01Form f01Form,
													Tf021f01M1Form f01M1Form,
													LoginInfoVO loginInfo,
													SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf021p01Constant.SQL_ID_10, facadeContext.DBContext);

			// 更新内容
			// 決裁フラグ
			reader.BindValue("BIND_SINSEI_FLG", 0);
			// 業務稟議No
			reader.BindValue("BIND_GYOMURINGI_NO1", -1);
			reader.BindValue("BIND_GYOMURINGI_NO2", -1);
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

			// 更新条件
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01Form.Dictionary[SearchConditionSaveCls.GetKey(() => f01Form.Head_tenpo_cd)]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1SYORI_YMD]));
			// 管理番号
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Tf021p01Constant.DIC_M1KANRI_NO], "0")));

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
