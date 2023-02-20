using com.xebio.bo.Tf010p01.Constant;
using com.xebio.bo.Tf010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Conditions;
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

namespace com.xebio.bo.Tf010p01.Facade
{
  /// <summary>
  /// Tf010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf010f01Facade : StandardBaseFacade
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
				Tf010f01Form f01VO = (Tf010f01Form)facadeContext.FormVO;
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
						Tf010f01M1Form f01m1VO = (Tf010f01M1Form)m1List[i];

						// 明細画面で確定された行はSKIP
						if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1F02ENTERSYORI_FLG].ToString()))
						{
							continue;
						}

						// モードが「確定」「修正」で、[Ｍ１承認状態]、[Ｍ１却下フラグ]のいずれかが"1"かつ、[Ｍ１確定フラグ(隠し)]が"1"の場合
						if (   (BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Modeno) || BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno))
							&& (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1syonin_flg) || BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1kyakka_flg))
							&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1entersyoriflg))
						{
							inputflg = 1;
							break;
						}

						// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
						if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
							&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
						{
							inputflg = 1;
							break;
						}
					}

					if (inputflg == 0)
					{
						// モードが「確定」「修正」
						if(BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Modeno) || BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno))
						{
							// 確定対象がありません。
							ErrMsgCls.AddErrMsg("E140", String.Empty, facadeContext);
						}
						// モードが「取消」
						else
						{
							// 対象行がありません。
							ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 関連チェック

				int kyakkaErrCnt = 0;
				for (int i = 0; i < m1List.Count; i++)
				{
					Tf010f01M1Form f01m1VO = (Tf010f01M1Form)m1List[i];

					// 2-1 却下フラグ、却下理由
					//       Ｍ１却下理由が未入力でＭ１却下フラグがチェックされている場合、エラー
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1kyakka_flg) && string.IsNullOrEmpty(f01m1VO.M1kyakkariyu))
					{
						kyakkaErrCnt++;
					}

				}

				if (kyakkaErrCnt > 0)
				{
					// {0}件却下理由が未入力の伝票が存在します。
					ErrMsgCls.AddErrMsg("E122", kyakkaErrCnt.ToString(), facadeContext);
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
				sRepSql.Append(" AND DENPYO_BANGO	= :BIND_DENPYO_BANGO");
				sRepSql.Append(" AND SYORI_YMD		= :BIND_SYORI_YMD");

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf010f01M1Form f01m1VO = (Tf010f01M1Form)m1List[i];

					// 明細画面で確定された行はSKIP
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1F02ENTERSYORI_FLG].ToString()))
					{
						continue;
					}

					// モードが「確定」で、[Ｍ１承認状態]、[Ｍ１却下フラグ]のいずれかが"1"、かつ[Ｍ１確定フラグ(隠し)]が"1"の場合
					if (   BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Modeno)
						&& (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1syonin_flg) || BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1kyakka_flg))
						&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1entersyoriflg))
					{
						this.HaitaCheck(facadeContext, f01VO, f01m1VO, sRepSql, "MDAT0020", i);
					}

					// モードが「修正」で、[Ｍ１承認状態]、[Ｍ１却下フラグ]のいずれかが"1"、かつ[Ｍ１確定フラグ(隠し)]が"1"の場合
					// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
					if (
						(BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)
							&& (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1syonin_flg) || BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1kyakka_flg))
							&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1entersyoriflg))
						||
						(BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
							&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox)))
					{
						this.HaitaCheck(facadeContext, f01VO, f01m1VO, sRepSql, "MDAT0030", i);
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
					Tf010f01M1Form f01m1VO = (Tf010f01M1Form)m1List[i];

					// 明細画面で確定された行はSKIP
					if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1F02ENTERSYORI_FLG].ToString()))
					{
						continue;
					}

					#region 確定
					// モードが「確定」で、[Ｍ１承認状態]、[Ｍ１却下フラグ]のいずれかが"1"、かつ[Ｍ１確定フラグ(隠し)]が"1"の場合
					if (BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Modeno)
						&& (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1syonin_flg) || BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1kyakka_flg))
						&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1entersyoriflg))
					{
						// [経費振替申請TBL(H)]を更新する。
						BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 START");
						int Updcntsinseih = Upd_Kakutei_KeihiFurikaeSinseih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 END");

						// [経費振替確定TBL(H)]を登録する。
						BoSystemLog.logOut("[経費振替確定TBL(H)]を登録 START");
						int Inscntkakuteih = Ins_Kakutei_KeihiFurikaeKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[経費振替確定TBL(H)]を登録 END");

						// [経費振替確定TBL(B)]を登録する。
						BoSystemLog.logOut("[経費振替確定TBL(B)]を登録 START");
						int Inscntkakuteib = Ins_Kakutei_KeihiFurikaeKakuteib(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[経費振替確定TBL(B)]を登録 END");

						// Ｍ１テーブル区分
						f01m1VO.Dictionary[Tf010p01Constant.DIC_M1TBLFLG] = "2";

					}
					#endregion

					#region 修正
					// モードが「修正」で、[Ｍ１承認状態]、[Ｍ１却下フラグ]のいずれかが"1"、かつ[Ｍ１確定フラグ(隠し)]が"1"の場合
					if (BoSystemConstant.MODE_UPD.Equals(f01VO.Modeno)
						&& (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1syonin_flg) || BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1kyakka_flg))
						&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1entersyoriflg))
					{
						// [経費振替申請TBL(H)]を更新する。
						BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 START");
						int Updcntsinseih = Upd_Shusei_KeihiFurikaeSinseih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 END");

						// [経費振替確定TBL(H)]を更新する。
						BoSystemLog.logOut("[経費振替確定TBL(H)]を更新 START");
						int Updcntkakuteih = Upd_Shusei_KeihiFurikaeKakuteih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[経費振替確定TBL(H)]を更新 END");
					}
					#endregion

					#region 取消
					// モードが「取消」で、[Ｍ１選択フラグ(隠し)]が"1"の場合
					if (BoSystemConstant.MODE_DEL.Equals(f01VO.Modeno)
						&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1selectorcheckbox))
					{

						// [経費振替確定TBL(B)]、[経費振替確定TBL(H)]の順番で削除する

						// [経費振替確定TBL(B)]を削除する。
						BoSystemLog.logOut("[経費振替確定TBL(B)]を削除 START");
						int Updcntyoteib = Del_Sakujo_KeihiFurikaeKakuteib(facadeContext, f01VO, f01m1VO);
						BoSystemLog.logOut("[経費振替確定TBL(B)]を削除 END  ");

						// [経費振替確定TBL(H)]を削除する。
						BoSystemLog.logOut("[経費振替確定TBL(H)]を削除 START");
						int Delcntkakutei = Del_Sakujo_KeihiFurikaeKakuteih(facadeContext, f01VO, f01m1VO);
						BoSystemLog.logOut("[経費振替確定TBL(H)]を削除 END  ");

						//// [経費振替確定TBL(H)]を削除する。
						//BoSystemLog.logOut("[経費振替確定TBL(H)]を削除 START");
						//int Delcntkakutei = Del_Sakujo_KeihiFurikaeKakuteih(facadeContext, f01VO, f01m1VO);
						//BoSystemLog.logOut("[経費振替確定TBL(H)]を削除 END  ");

						//// [経費振替確定TBL(B)]を削除する。
						//BoSystemLog.logOut("[経費振替確定TBL(B)]を削除 START");
						//int Updcntyoteib = Del_Sakujo_KeihiFurikaeKakuteib(facadeContext, f01VO, f01m1VO);
						//BoSystemLog.logOut("[経費振替確定TBL(B)]を削除 END  ");

						// [経費振替申請TBL(H)]を更新する。
						BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 START");
						int Updcntyoteih = Upd_Sakujo_KeihiFurikaeSinseih(facadeContext, f01VO, f01m1VO, logininfo, sysDateVO);
						BoSystemLog.logOut("[経費振替申請TBL(H)]を更新 END  ");
					}
					#endregion
				}

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 印刷処理

				// 帳票ツールに渡すパラメータを格納
				InputData inputDataProof = new InputData();

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf010f01M1Form f01m1VO = (Tf010f01M1Form)m1List[i];

					// [Ｍ１承認状態]、[Ｍ１却下フラグ]のいずれかが"1"の場合
					if ((BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1syonin_flg) || BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1kyakka_flg))
						&& BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1entersyoriflg))
					{

						// モードが「確定」の場合
						if (BoSystemConstant.MODE_KAKUTEI.Equals(f01VO.Modeno))
						{

							// 店舗コード
							inputDataProof.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01m1VO.M1shinsei_tenpo_cd));
							// 処理日付
							inputDataProof.AddScreenParameter(2, BoSystemFormat.formatDate(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD].ToString()));
							// 伝票番号
							inputDataProof.AddScreenParameter(3, BoSystemFormat.formatDenpyoNo(f01m1VO.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO].ToString()));
							// テーブル区分
							inputDataProof.AddScreenParameter(4, f01m1VO.Dictionary[Tf010p01Constant.DIC_M1TBLFLG].ToString());
							// 明細ソート
							inputDataProof.AddScreenParameter(5, f01VO.Meisai_sort);

						}
					}
				}

				if (inputDataProof.GetScreenParameterCount() > 0)
				{

					OutputInfo output = new OutputInfo();
					BoSystemReport reportCls = new BoSystemReport();

					// 出力PDFファイル名のリスト
					List<string> pdfFileNmList = new List<string>();
					// 出力PDFファイル名
					string pdfFileNm = string.Empty;
					// 出力PDFファイル名（内部用）
					string pdfFileNmNaibu = string.Empty;
					// 複数ファイルダウンロード用ディレクトリパス
					string multiDownloadPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);

					// PDFファイル名
					pdfFileNmNaibu = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEPROOFLIST),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputDataProof,
													BoSystemConstant.REPORTID_SYOHINKEIHIFURIKAEPROOFLIST,
													Tf010p01Constant.FORMID_01,
													Tf010p01Constant.PGID,
													pdfFileNmNaibu
													);

					// PDFをファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tf010p01Constant.FCDUO_RRT_FLNM, pdfFileNmNaibu);
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

		#region 排他チェック処理
		/// <summary>
		/// [排他処理チェックを行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>件数</returns>
		private void HaitaCheck(IFacadeContext facadeContext,
									Tf010f01Form f01Form,
									Tf010f01M1Form f01M1Form,
									StringBuilder sRepSql,
									string sTable,
									int i)
		{

			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();

			// 店舗コード
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f01M1Form.M1shinsei_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 伝票番号
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_DENPYO_BANGO";
			bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]);
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 処理日
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYORI_YMD";
			bindVO.Value = BoSystemFormat.formatDate((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]);
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 排他チェック
			V03003Check.CheckHaitaMaxVal(
					Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1UPD_YMD]),
					Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1UPD_TM]),
					facadeContext,
					sTable,
					sRepSql.ToString(),
					bindList,
					1,
					null,
					f01M1Form.M1rowno,
					i.ToString(),
					"M1",
					100
			);
		}

		#endregion

		#region [経費振替申請TBL(H)]の更新
		/// <summary>
		/// [経費振替申請TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_Kakutei_KeihiFurikaeSinseih(IFacadeContext facadeContext,
											Tf010f01Form f01Form,
											Tf010f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新内容
			// 決裁フラグ
			reader.BindValue("BIND_KESSAI_FLG", 1);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 1);

			// 更新条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.M1shinsei_tenpo_cd));

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
		/// <returns>更新件数</returns>
		private int Ins_Kakutei_KeihiFurikaeKakuteih(IFacadeContext facadeContext,
											Tf010f01Form f01Form,
											Tf010f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_09, facadeContext.DBContext);

			// 登録内容
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_TM]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.M1shinsei_tenpo_cd));
			// 科目コード
			reader.BindValue("BIND_KAMOKU_CD", Convert.ToDecimal(f01M1Form.M1kamoku_cd));
			// 申請理由区分
			reader.BindValue("BIND_SINSEIRIYU_KB", Convert.ToDecimal(f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SINSEIRIYU_KB].ToString()));
			// 申請理由
			reader.BindValue("BIND_SINSEIRIYU", (string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SINSEIRIYU]);
			// 却下理由
			// 却下フラグがチェックオンの場合
			if (BoSystemConstant.CHECKBOX_ON.Equals(f01M1Form.M1kyakka_flg))
			{
				reader.BindValue("BIND_KYAKKARIYU", f01M1Form.M1kyakkariyu);
			}
			else
			{
				reader.BindValue("BIND_KYAKKARIYU", string.Empty);
			}
			// 承認状態
			// 承認フラグがチェックオンの場合
			if (BoSystemConstant.CHECKBOX_ON.Equals(f01M1Form.M1syonin_flg))
			{
				reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1));

			}
			// 却下フラグがチェックオンの場合
			else if (BoSystemConstant.CHECKBOX_ON.Equals(f01M1Form.M1kyakka_flg))
			{
				reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2));
			}
			// 未チェックはあり得ないが念のため空白処理を記載
			else
			{
				reader.BindValue("BIND_SYONIN_FLG", string.Empty);
			}
			// 盗難品管理番号
			reader.BindValue("BIND_TONANHINKANRI_NO", Convert.ToDecimal(f01M1Form.Dictionary[Tf010p01Constant.DIC_M1TONANHINKANRI_NO].ToString()));
			// 盗難品処理日付
			reader.BindValue("BIND_TONANHINSYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1TONANHINSYORI_YMD]));
			// 盗難品店舗コード
			reader.BindValue("BIND_TONANHINTENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1TONANHINTENPO_CD]));
			// 受理番号
			reader.BindValue("BIND_JYURI_NO", f01M1Form.M1jyuri_no);
			// 出荷会社コード
			reader.BindValue("BIND_SYUKKAKAISYA_CD", 0);
			// 出荷店コード
			reader.BindValue("BIND_SYUKKATEN_CD", string.Empty);
			// 移動伝票番号
			reader.BindValue("BIND_IDODENPYO_BANGO", 0);
			// 申請日
			reader.BindValue("BIND_APPLY_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f01M1Form.M1apply_ymd)));
			// 申請担当者コード
			reader.BindValue("BIND_SINSEITAN_CD", BoSystemFormat.formatTantoCd((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SINSEITAN_CD]));
			// 業務稟議No
			reader.BindValue("BIND_GYOMURINGI_NO", BoSystemString.Nvl(f01M1Form.M1gyomuringi_no, "0"));
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
			// 申請データ送信済フラグ
			reader.BindValue("BIND_SSI_SSNZUMI_FLG", 0);
			// 申請データ送信日
			reader.BindValue("BIND_SSI_SSN_YMD", 0);
			// 申請データ送信時間
			reader.BindValue("BIND_SSI_SSN_TM", 0);

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
		/// <returns>更新件数</returns>
		private int Ins_Kakutei_KeihiFurikaeKakuteib(IFacadeContext facadeContext,
											Tf010f01Form f01Form,
											Tf010f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_10, facadeContext.DBContext);

			// 登録条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.M1shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替申請TBL(H)]の更新
		/// <summary>
		/// [経費振替申請TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_Shusei_KeihiFurikaeSinseih(IFacadeContext facadeContext,
													Tf010f01Form f01Form,
													Tf010f01M1Form f01M1Form,
													LoginInfoVO loginInfo,
													SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新内容
			// 決裁フラグ
			reader.BindValue("BIND_KESSAI_FLG", 1);
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);
			// 削除フラグ
			reader.BindValue("BIND_SAKUJYO_FLG", 1);

			// 更新条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.M1shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(H)]の更新
		/// <summary>
		/// [経費振替確定TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_Shusei_KeihiFurikaeKakuteih(IFacadeContext facadeContext,
													Tf010f01Form f01Form,
													Tf010f01M1Form f01M1Form,
													LoginInfoVO loginInfo,
													SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_11, facadeContext.DBContext);

			// 更新内容
			// 却下理由
			// 却下フラグがチェックオンの場合
			if (BoSystemConstant.CHECKBOX_ON.Equals(f01M1Form.M1kyakka_flg))
			{
				reader.BindValue("BIND_KYAKKARIYU", f01M1Form.M1kyakkariyu);
			}
			else
			{
				reader.BindValue("BIND_KYAKKARIYU", string.Empty);
			}
			// 承認状態
			// 承認フラグがチェックオンの場合
			if (BoSystemConstant.CHECKBOX_ON.Equals(f01M1Form.M1syonin_flg))
			{
				reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(ConditionSyonin_jotai.VALUE_SYONIN_JOTAI1));

			}
			// 却下フラグがチェックオンの場合
			else if (BoSystemConstant.CHECKBOX_ON.Equals(f01M1Form.M1kyakka_flg))
			{
				reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(ConditionSyonin_jotai.VALUE_SYONIN_JOTAI2));
			}
			// 未チェックはあり得ないが念のため空白処理を記載
			else
			{
				reader.BindValue("BIND_SYONIN_FLG", string.Empty);
			}
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 更新条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.M1shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(H)]の削除
		/// <summary>
		/// [経費振替確定TBL(H)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_Sakujo_KeihiFurikaeKakuteih(IFacadeContext facadeContext,
													Tf010f01Form f01Form,
													Tf010f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_12, facadeContext.DBContext);

			// 削除条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.M1shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替確定TBL(B)]の削除
		/// <summary>
		/// [経費振替確定TBL(B)]の削除を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <returns>更新件数</returns>
		private int Del_Sakujo_KeihiFurikaeKakuteib(IFacadeContext facadeContext,
													Tf010f01Form f01Form,
													Tf010f01M1Form f01M1Form)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_13, facadeContext.DBContext);

			// 削除条件
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.M1shinsei_tenpo_cd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費振替申請TBL(H)]の更新
		/// <summary>
		/// [経費振替申請TBL(H)]の更新を行います。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_Sakujo_KeihiFurikaeSinseih(IFacadeContext facadeContext,
											Tf010f01Form f01Form,
											Tf010f01M1Form f01M1Form,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tf010p01Constant.SQL_ID_08, facadeContext.DBContext);

			// 更新内容
			// 決裁フラグ
			reader.BindValue("BIND_KESSAI_FLG", 0);
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
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1DENPYO_BANGO]));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal((string)f01M1Form.Dictionary[Tf010p01Constant.DIC_M1SYORI_YMD]));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((string)f01M1Form.M1shinsei_tenpo_cd));

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