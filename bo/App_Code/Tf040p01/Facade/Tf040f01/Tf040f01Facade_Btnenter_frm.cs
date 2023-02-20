using com.xebio.bo.Tf040p01.Constant;
using com.xebio.bo.Tf040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01004;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01021;
using Common.Conditions;
using Common.IntegrationMD.Report;
using Common.ListFactory.Model;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;

namespace com.xebio.bo.Tf040p01.Facade
{
  /// <summary>
  /// Tf040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf040f01Facade : StandardBaseFacade
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
				Tf040f01Form f01VO = (Tf040f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO SysDateVO = SysdateCls.GetSysdateTime(facadeContext);
				string strSysDate = SysDateVO.Sysdate.ToString();

				// 比較日付
				DateTime dtSysDate = DateTime.ParseExact(strSysDate, "yyyyMMdd", null);		// システム日付
				DateTime dtSysDateFst = new DateTime(dtSysDate.Year, dtSysDate.Month, 1);	// システム日付(1日)
				DateTime dtLastMon = dtSysDate.AddMonths(-1);
				DateTime dtLastMonFst = dtSysDateFst.AddMonths(-1);

				// 科目コードなし件数
				Decimal dNonkamokuCdCnt = 0;

				// Ｍ１管理Ｎｏ
				ArrayList M1KanriNo = new ArrayList();
				M1KanriNo = GetM1KanriNo(m1List, M1KanriNo);	// 管理No取得
				#endregion

				#region 業務チェック

				#region ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// エラーが発生した場合、処理を終了する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region Ｍ１科目コード[件数チェック]

				for (int i=0;i < m1List.Count; i++)
				{
					Tf040f01M1Form f01m1VO = (Tf040f01M1Form)m1List[i];

					// ※科目コードが入力されている行がチェック対象。
					if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)
						&& !string.IsNullOrEmpty(f01m1VO.M1kamoku_cd.ToString()))
					{
						dNonkamokuCdCnt++;
						break;
					}
				}

				if (dNonkamokuCdCnt == 0)
				{
					// 確定対象がありません。
					ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
				}

				// エラーが発生した場合、処理を終了する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion


				// 明細単位でチェック
				#region 入力値チェック

				for (int index = 0 ; index < m1List.Count; index++)
				{
					Tf040f01M1Form f01m1VO = (Tf040f01M1Form)m1List[index];

					// 活性化されているＭ１科目コードが入力されている行が1行も存在しない場合、エラー
					// ※科目コードが入力されている行がチェック対象。
					if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)
						&& !string.IsNullOrEmpty(f01m1VO.M1kamoku_cd.ToString()))
					{


						#region Ｍ１計上日付
						// 入力されていない場合、エラー
						if (string.IsNullOrEmpty(f01m1VO.M1keijo_ymd))
						{
							// {日付}を入力して下さい。
							ErrMsgCls.AddErrMsg(
								"E121"
								, "日付"
								, facadeContext
								, new[] { "M1keijo_ymd" }
								, f01m1VO.M1rowno
								, index.ToString()
								, "M1"
                , m1List.DispRow
                            );
						}
						else
						{ 

							int iErrFlg = 0;

							//※システム日付が1日の場合
							if (dtSysDate.Day.ToString().Equals("1"))
							{ 
								// 前月の1日～システム日付の範囲内でなければエラー
								if (!( dtLastMonFst <= DateTime.ParseExact(BoSystemFormat.formatDate(f01m1VO.M1keijo_ymd), "yyyyMMdd", null)
									&& DateTime.ParseExact(BoSystemFormat.formatDate(f01m1VO.M1keijo_ymd), "yyyyMMdd", null) <= dtSysDate))
								{
									iErrFlg = 1;
								}
							}
							else {
								// 当月の1日～システム日付の範囲内でなければ、エラー
								if (!(dtSysDateFst <= DateTime.ParseExact(BoSystemFormat.formatDate(f01m1VO.M1keijo_ymd), "yyyyMMdd", null)
									&& DateTime.ParseExact(BoSystemFormat.formatDate(f01m1VO.M1keijo_ymd), "yyyyMMdd", null) <= dtSysDate))
								{
									iErrFlg = 1;
								}
							}
					
							if (iErrFlg == 1)
							{
								// 当月内の日付を入力して下さい。
								ErrMsgCls.AddErrMsg(
									"E177"
									, string.Empty
									, facadeContext
									, new[] { "M1keijo_ymd" }
									, f01m1VO.M1rowno
									, index.ToString()
									, "M1"
                  , m1List.DispRow
                                );
							}
						}
						#endregion

						#region Ｍ１科目コード
						if (!string.IsNullOrEmpty(f01m1VO.M1kamoku_cd))
						{
							Hashtable resultHash = new Hashtable();
							resultHash = V01021Check.CheckKamoku(
								f01m1VO.M1kamoku_cd
								, facadeContext
								, "科目コード"
								, new[] { "M1kamoku_cd" }
								, f01m1VO.M1rowno
								, index.ToString()
								, "M1"
                , m1List.DispRow
							);
							// 名称をラベルに設定
							if (resultHash != null)
							{
								f01m1VO.M1kamoku_nm = (string)resultHash["KAMOKU_NM"];
							}
						}
						#endregion

						#region Ｍ１入金、Ｍ１出金
						// Ｍ１入金、またはＭ１出金に0が入力された場合、エラー
						if (f01m1VO.M1nyukin.Equals("0") || f01m1VO.M1syukkin.Equals("0"))
						{
							if (f01m1VO.M1nyukin.Equals("0"))
							{
								// {入金}に0は入力できません。
								ErrMsgCls.AddErrMsg(
									"E103"
									, "入金"
									, facadeContext
									, new[] { "M1nyukin" }
									, f01m1VO.M1rowno
									, index.ToString()
									, "M1"
                  , m1List.DispRow
                                );
							}
							else
							{
								// {出金}に0は入力できません。
								ErrMsgCls.AddErrMsg(
									"E103"
									, "出金"
									, facadeContext
									, new[] { "M1syukkin" }
									, f01m1VO.M1rowno
									, index.ToString()
									, "M1"
                  , m1List.DispRow
                                );
							}
						}

						decimal dNyukin = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1nyukin, "0"));
						decimal dSyukin = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1syukkin, "0"));
						if (dNyukin < 0)
						{
							// {入金}にマイナスはできません。
							ErrMsgCls.AddErrMsg("E104"
												, "入金"
												, facadeContext
												, new[] { "M1nyukin" }
												, f01m1VO.M1rowno
												, index.ToString()
												, "M1"
                        , m1List.DispRow
                            );
						}

						if (dSyukin < 0)
						{
							// {出金}にマイナスは入力できません。
							ErrMsgCls.AddErrMsg("E104"
												, "出金"
												, facadeContext
												, new[] { "M1syukkin" }
												, f01m1VO.M1rowno
												, index.ToString()
												, "M1"
                        , m1List.DispRow
                            );
						}

						#endregion

						#region Ｍ１摘要
						// 入力されていない場合、エラー
						if (string.IsNullOrEmpty(f01m1VO.M1tekiyou))
						{
							// 摘要を入力して下さい。
							ErrMsgCls.AddErrMsg(
								"E121"
								, "摘要"
								, facadeContext
								, new[] { "M1tekiyou" }
								, f01m1VO.M1rowno
								, index.ToString()
								, "M1"
                , m1List.DispRow
                            );
						}
						#endregion

						#region Ｍ１振替店舗コード
						// 店舗マスタを検索し、存在しない場合エラー
						if (!string.IsNullOrEmpty(f01m1VO.M1hurikaetenpo_cd))
						{
							Hashtable resultHash = new Hashtable();
							resultHash = V01001Check.CheckTenpo(
								f01m1VO.M1hurikaetenpo_cd
								, facadeContext
								, "振替店舗"
								, new[] { "M1hurikaetenpo_cd" }
								, f01m1VO.M1rowno
								, index.ToString()
								, "M1"
                , m1List.DispRow
                            );
							// 名称をラベルに設定
							if (resultHash != null)
							{
								f01m1VO.M1hurikaetenpo_nm = (string)resultHash["TENPO_NM"];
							}
						}
						#endregion
					}
				}

				// エラーが発生した場合、処理を終了する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 関連チェック

				for (int index = 0; index < m1List.Count; index++)
				{
					Tf040f01M1Form f01m1VO = (Tf040f01M1Form)m1List[index];

					// 活性化されているＭ１科目コードが入力されている行が1行も存在しない場合、エラー
					// ※科目コードが入力されている行がチェック対象。
					if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI)
						&& !string.IsNullOrEmpty(f01m1VO.M1kamoku_cd.ToString()))
					{
						#region Ｍ１入金、Ｍ１出金[関連チェック]
						// どちらも入力されていない場合、または両方入力された場合、エラー
						if ((string.IsNullOrEmpty(f01m1VO.M1nyukin) && string.IsNullOrEmpty(f01m1VO.M1syukkin))
						|| (!string.IsNullOrEmpty(f01m1VO.M1nyukin) && !string.IsNullOrEmpty(f01m1VO.M1syukkin)))
						{
							// 入金、出金はどちらか片方のみを必ず入力して下さい。
							ErrMsgCls.AddErrMsg(
								"E180"
								, string.Empty
								, facadeContext
								, new[] { "M1nyukin" , "M1syukkin" }
								, f01m1VO.M1rowno
								, index.ToString()
								, "M1"
                , m1List.DispRow
                            );	
						}
						#endregion

						#region Ｍ１管理No、Ｍ１元管理No[関連チェック]
						// 画面に表示されている元管理No

						Decimal dNotEqKanriNoCnt = 0;	// 管理No不一致件数

						for (int iRowKanriNo = 0; iRowKanriNo < M1KanriNo.Count; iRowKanriNo++)
						{
                            //Ｍ１元管理Noが画面に表示されているＭ１管理Noと１つも一致しない場合、エラー
                            decimal inputKanrino = Convert.ToDecimal(BoSystemString.Nvl(f01m1VO.M1motokanri_no, "0"));
                            decimal itiranKanrino = Convert.ToDecimal(BoSystemString.Nvl((string)M1KanriNo[iRowKanriNo], "-1"));

                            if (inputKanrino != itiranKanrino)
                            {
                                dNotEqKanriNoCnt++;
							}
						}

						if (dNotEqKanriNoCnt == M1KanriNo.Count)
						{
							// 元管理Noに入力がある場合
							if (!string.IsNullOrEmpty(f01m1VO.M1motokanri_no))
							{ 
								// 管理Noは存在しません。
								ErrMsgCls.AddErrMsg(
									"E111"
									, "管理No"
									, facadeContext
									, new[] { "M1motokanri_no" }
									, f01m1VO.M1rowno
									, index.ToString()
									, "M1"
                  , m1List.DispRow
                                );
							}
						}
						#endregion

					}
				}

				// エラーが発生した場合、処理を終了する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				
				#region 残高桁数チェック
				if (Convert.ToDecimal(BoSystemString.Nvl(f01VO.Gokei_zandaka,"0")) >= 0)
				{
					if (f01VO.Gokei_zandaka.Length > 9)
					{
						// {残高}が有効桁数を超えています。
						ErrMsgCls.AddErrMsg(
							"E102"
							, "残高"
							, facadeContext
							, new[] { "Gokei_zandaka" }
						);
					}
				}
				else
				{
					if (f01VO.Gokei_zandaka.Length > 10)
					{
						// {残高}が有効桁数を超えています。
						ErrMsgCls.AddErrMsg(
							"E102"
							, "残高"
							, facadeContext
							, new[] { "Gokei_zandaka" }
						);
					}
				}

				// エラーが発生した場合、次明細をチェックする。
				//	※科目コードが入力されている行がチェック対象。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion
				

				#endregion
				
				#region 更新処理
				Decimal dSyoriYmd = SysDateVO.Sysdate;			// 処理日付
				Decimal dSyoriTime = SysDateVO.Systime_mili;	// 処理時間
				
				// 条件式の初期化
				string seq = string.Empty;
				string strParaWhere = string.Empty;

				// 更新処理
				for (int iRow = 0; iRow < m1List.Count; iRow++)
				{
					// 一覧画面のVO
					Tf040f01M1Form f01m1VO = (Tf040f01M1Form)m1List[iRow];

					// Ｍ１科目コードが活性化され入力済の場合
					if (f01m1VO.M1entersyoriflg.Equals(ConditionKakuteisyori_flg.VALUE_ARI) 
						&& !string.IsNullOrEmpty(f01m1VO.M1kamoku_cd))
					{
						//管理Noを採番し、[管理No]として保持
						seq = NumberingCls.Numbering( facadeContext
													, BoSystemConstant.AUTONUM_KOGUTI_KANRINO
													, "0000"
													, logininfo.LoginId);

						// [当日小口現金TBL]を登録する。
						Ins_MDAT0080(facadeContext, f01VO, f01m1VO, logininfo, dSyoriYmd, dSyoriTime, SysDateVO, seq);

						// 印刷処理用の条件式を作成し[条件式]として保持する。
						// [条件式]＝""の場合
						if (string.IsNullOrEmpty(strParaWhere))
						{
							strParaWhere = "(" + seq;
						}
						else
						{
							strParaWhere = strParaWhere + "," + seq;
						}
					}
				}
				if (!string.IsNullOrEmpty(strParaWhere))
				{
					strParaWhere = strParaWhere + ")";
				}

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
				#endregion

				#region 印刷処理
				// Xの場合
				if (CheckCompanyCls.IsXebio(logininfo.CopCd))
				{
					string pdfFileNm = "";

					// 帳票ツールに渡すパラメータを格納
					InputData inputData = new InputData();

					// パラメータ設定
					// 小口現金登録パラメータ
					inputData.AddScreenParameter(1, (1).ToString());
					// 店舗コード
					inputData.AddScreenParameter(2, BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()].ToString()));
					// 処理日
					inputData.AddScreenParameter(3, BoSystemFormat.formatDate(dSyoriYmd.ToString()));
					// 管理No
					inputData.AddScreenParameter(4, strParaWhere);
					// 計上日
					inputData.AddScreenParameter(5, SysDateVO.Sysdate.ToString());

					OutputInfo output = new OutputInfo();
					BoSystemReport reportCls = new BoSystemReport();

					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_KOGUTIGENKINSUITOTYO),
												BoSystemConstant.RPT_PDF_EXTENSION
												);

					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_KOGUTIGENKINSUITOTYO,
													Tf040p01Constant.FORMID_01,
													Tf040p01Constant.PGID,
													pdfFileNm
													);

					// PDFをファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tf040p01Constant.FCDUO_RRT_FLNM, pdfFileNm);
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

		#region [管理No]取得
		/// <summary>
		/// 画面に表示されている管理Noを取得
		/// </summary>
		/// <param name="m1List">明細リスト</param>
		/// <param name="M1KanriNo">Ｍ１管理No</param>
		private static ArrayList GetM1KanriNo(IDataList m1List, ArrayList M1KanriNo)
		{
			for (int index = 0; index < m1List.Count; index++)
			{
				Tf040f01M1Form f01m1VO = (Tf040f01M1Form)m1List[index];

				// Ｍ１管理No
				M1KanriNo.Add(f01m1VO.M1kanri_no);
			}

			return M1KanriNo;
		}

		#endregion

		#region [当日小口現金TBL]を登録
		/// <summary>
		/// [当日小口現金TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="f02VO">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Ins_MDAT0080(	IFacadeContext facadeContext
									, Tf040f01Form f01VO
									, Tf040f01M1Form f01m1VO
									, LoginInfoVO loginInfo
									, Decimal SyoriYmd
									, Decimal SyoriTime
									, SysDateVO sysDateVO 
									, String seq)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf040p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.PREFIX + "Head_tenpo_cd".ToUpper()].ToString()));
			
			// 計上日付
			reader.BindValue("BIND_KEIJO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01m1VO.M1keijo_ymd)));

			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", SyoriYmd);

			// 処理時間
			reader.BindValue("BIND_SYORI_TM", SyoriTime);

			// 管理№
			reader.BindValue("BIND_KANRI_NO", seq);

			// 科目コード
			reader.BindValue("BIND_KAMOKU_CD", Convert.ToDecimal(f01m1VO.M1kamoku_cd));

			// 摘要
			reader.BindValue("BIND_TEKIYOU", f01m1VO.M1tekiyou);

			// 入出金区分
			if (!string.IsNullOrEmpty(f01m1VO.M1nyukin))
			{
				// M１入金が入力されている場合："0"(入金)
				reader.BindValue("BIND_NYUSYUKKIN_KB", 0);
			}
			else
			{
				// それ以外（M１出金が入力されている）の場合："1"(出金)
				reader.BindValue("BIND_NYUSYUKKIN_KB", 1);
			}

			// 入金
			if (!string.IsNullOrEmpty(f01m1VO.M1nyukin))
			{ 
				reader.BindValue("BIND_NYUKIN", Convert.ToDecimal(f01m1VO.M1nyukin));
			}
			else
			{
				reader.BindValue("BIND_NYUKIN", 0);
			}

			// 出金
			if (!string.IsNullOrEmpty(f01m1VO.M1syukkin))
			{
				reader.BindValue("BIND_SYUKKIN", Convert.ToDecimal(f01m1VO.M1syukkin));
			}
			else 
			{
				reader.BindValue("BIND_SYUKKIN", 0);
			}
			
			// 振替店舗コード
			reader.BindValue("BIND_HURIKAETENPO_CD", BoSystemFormat.formatTenpoCd(f01m1VO.M1hurikaetenpo_cd));

			// 元日付
			//reader.BindValue("BIND_MOTOHIDUKE", 0);
					
			// 元管理No
			if (!string.IsNullOrEmpty(f01m1VO.M1motokanri_no))
			{
				reader.BindValue("BIND_MOTOKANRI_NO", f01m1VO.M1motokanri_no);
			}
			else
			{
				reader.BindValue("BIND_MOTOKANRI_NO", 0);
			}

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
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate_yyyyMM(sysDateVO.Sysdate.ToString()) + "01"));

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
