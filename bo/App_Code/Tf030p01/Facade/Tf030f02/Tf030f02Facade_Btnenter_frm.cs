using com.xebio.bo.Tf030p01.Constant;
using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01002;
using Common.Business.V01000.V01005;
using Common.Business.V01000.V01023;
using Common.Business.V03000.V03001;
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

namespace com.xebio.bo.Tf030p01.Facade
{
  /// <summary>
  /// Tf030f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf030f02Facade : StandardBaseFacade
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
				Tf030f02Form f02VO = (Tf030f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// システム日付
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				#endregion

				#region 業務チェック

				#region 件数チェック

				// 1-1 入力件数
				//       Ｍ１SCM/伝票コードが1件も入力されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					// 登録データがありません。
					ErrMsgCls.AddErrMsg("E133", String.Empty, facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tf030f02M1Form f02m1VO = (Tf030f02M1Form)m1List[i];

						if (!string.IsNullOrEmpty(f02m1VO.M1tekiyo_cd))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						// 登録データがありません。
						ErrMsgCls.AddErrMsg("E133", String.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 単項目チェック（ヘッダ情報）

				// 2-1 店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
				f02VO.Tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f02VO.Tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f02VO.Tenpo_cd, facadeContext, "店舗", new[] { "Tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f02VO.Tenpo_nm = (string)resultHash["TENPO_NM"];
					}
				}

				// 2-2 検品者コード
				//       担当者マスタを検索し、存在しない場合エラー
				f02VO.Kenpinsya_nm = string.Empty;
				if (!string.IsNullOrEmpty(f02VO.Kenpinsya_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01005Check.CheckTanto(f02VO.Kenpinsya_cd, facadeContext, "検品者", new[] { "Kenpinsya_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f02VO.Kenpinsya_nm = (string)resultHash["HANBAIIN_NM"];
					}
				}

				// 2-3 仕入先コード
				//       仕入先マスタを検索し、存在しない場合エラー
				f02VO.Siiresaki_ryaku_nm = string.Empty;
				if (!string.IsNullOrEmpty(f02VO.Siiresaki_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01002Check.CheckShiiresaki(f02VO.Siiresaki_cd, facadeContext, "取引先", new[] { "Siiresaki_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f02VO.Siiresaki_ryaku_nm = (string)resultHash["SIIRESAKI_RYAKU_NM"];
					}
				}

				// 2-4 伝票番号
				//       伝票番号、登録日、店舗コードをキーに経費未払TBL(H)を検索し存在した場合、エラー
				// [選択モードNo]が「新規作成」の場合
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					Decimal dCnt = Chk_KeihiMibaraiH(facadeContext, f02VO);
					if (dCnt != 0)
					{
						// 伝票番号が重複しています。
						ErrMsgCls.AddErrMsg("E227", string.Empty, facadeContext, new[] { "Denpyo_bango" });
					}
				}

				// 2-5 納品日
				// 未来日付が入力された場合、エラー
				if (!string.IsNullOrEmpty(f02VO.Nohin_ymd))
				{
					if (V03001Check.DateFromToChk(f02VO.Nohin_ymd, sysDateVO.Sysdate.ToString()) > 0)
					{
						// 報告日＞システム日付の場合
						ErrMsgCls.AddErrMsg("E215", "納品日", facadeContext, new string[] { "Nohin_ymd" });
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 単項目チェック（明細）

				for (int i = 0; i < m1List.Count; i++)
				{
					Tf030f02M1Form f02m1VO = (Tf030f02M1Form)m1List[i];

					// 摘要が入力された行をチェックする
					if (!string.IsNullOrEmpty(f02m1VO.M1tekiyo_cd))
					{
						// 3-1 Ｍ１摘要コード
						//       摘要MSTに存在しない場合、エラー
						f02m1VO.M1tekiyo_nm = string.Empty;
						Hashtable resultHash = new Hashtable();
						resultHash = V01023Check.CheckTekiyo(f02m1VO.M1tekiyo_cd,
														facadeContext,
														"摘要",
														new[] { "M1tekiyo_cd" },
														f02m1VO.M1rowno,
														i.ToString(),
														"M1",
														Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));

						// 名称をラベルに設定
						if (resultHash != null)
						{
							f02m1VO.M1tekiyo_nm = (string)resultHash["TEKIYO_NM"];
						}

						// 3-2 Ｍ１数量
						//       数量が入力されていない場合、エラー
						if (string.IsNullOrEmpty(f02m1VO.M1suryo))
						{
							ErrMsgCls.AddErrMsg("E121", "数量", facadeContext, new[] { "M1suryo" }, f02m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						}

						// 3-3 Ｍ１数量
						//       0が入力された場合、エラー
						if (f02m1VO.M1suryo.Equals("0"))
						{
							ErrMsgCls.AddErrMsg("E103", "数量", facadeContext, new[] { "M1suryo" }, f02m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						}

						// 3-4 Ｍ１単価
						//       単価が入力されていない場合、エラー
						if (string.IsNullOrEmpty(f02m1VO.M1tnk))
						{
							ErrMsgCls.AddErrMsg("E121", "単価", facadeContext, new[] { "M1tnk" }, f02m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						}

						// 3-5 Ｍ１単価
						//       0が入力された場合、エラー
						if (f02m1VO.M1tnk.Equals("0"))
						{
							ErrMsgCls.AddErrMsg("E103", "単価", facadeContext, new[] { "M1tnk" }, f02m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
						}

						// 3-6 Ｍ１金額
						//       Ｍ１金額（Ｍ１数量×Ｍ１単価）が9,999,999,999（10桁）より大きかったらエラー
						if (!string.IsNullOrEmpty(f02m1VO.M1suryo) && !string.IsNullOrEmpty(f02m1VO.M1tnk))
						{
							decimal kingaku = System.Math.Abs(Convert.ToDecimal(f02m1VO.M1suryo) * Convert.ToDecimal(f02m1VO.M1tnk));
							if (kingaku > 9999999999)
							{
								ErrMsgCls.AddErrMsg("E102", "金額", facadeContext, new[] { "M1suryo", "M1tnk" }, f02m1VO.M1rowno, i.ToString(), "M1", Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper())));
							}
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

				// 4-1 排他チェック
				// [選択モードNo]が「修正」の場合
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
				{
					StringBuilder sRepSql = new StringBuilder();

					sRepSql.Append(" AND DENPYO_BANGO = :BIND_DENPYO_BANGO");
					sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");
					sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");

					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();

					// 伝票番号
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_DENPYO_BANGO";
					bindVO.Value = BoSystemFormat.formatDenpyoNo(f02VO.Denpyo_bango);
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 処理日付
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYORI_YMD";
					bindVO.Value = (string)f02VO.Dictionary[Tf030p01Constant.DIC_SYORI_YMD];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 店舗コード（変更前の店舗コード）
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_TENPO_CD";
					bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Dictionary[Tf030p01Constant.DIC_MOTO_TENPO_CD].ToString());
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 排他チェック
					V03003Check.CheckHaitaMaxVal(
							Convert.ToDecimal((string)f02VO.Dictionary[Tf030p01Constant.DIC_UPD_YMD]),
							Convert.ToDecimal((string)f02VO.Dictionary[Tf030p01Constant.DIC_UPD_TM]),
							facadeContext,
							"MDAT0010",
							sRepSql.ToString(),
							bindList,
							1
					);
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
				// 初期化処理で取得
				//SysDateVO sysDateVO = new SysDateVO();
				//sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// [選択モードNo]が「新規作成」の場合
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					// [経費未払TBL(H)]を登録する。
					BoSystemLog.logOut("[経費未払TBL(H)]を登録 START");
					int Inscntmibaraih = Ins_KeihiMibaraiH(facadeContext, f02VO, logininfo, sysDateVO);
					BoSystemLog.logOut("[経費未払TBL(H)]を登録 END");
				}
				// [選択モードNo]が「修正」の場合
				else if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
				{
					// [経費未払TBL(H)]を更新する。
					BoSystemLog.logOut("[経費未払TBL(H)]を更新 START");
					int Updcntmibaraih = Upd_KeihiMibaraiH(facadeContext, f02VO, logininfo, sysDateVO);
					BoSystemLog.logOut("[経費未払TBL(H)]を更新 END");

					// [経費未払TBL(B)]を削除する。
					BoSystemLog.logOut("[経費未払TBL(B)]を削除 START");
					int Updcntmibaraib = Del_KeihiMibaraiB(facadeContext, f02VO);
					BoSystemLog.logOut("[経費未払TBL(B)]を削除 END");
				}

				decimal denpyogyoNo = 0;
				for (int i = 0; i < m1List.Count; i++)
				{
					Tf030f02M1Form f02m1VO = (Tf030f02M1Form)m1List[i];
					if (!string.IsNullOrEmpty(f02m1VO.M1tekiyo_cd))
					{
						denpyogyoNo++;
						// [経費未払TBL(B)]を登録する。
						BoSystemLog.logOut("[経費未払TBL(B)]を登録 START");
						int Inscntmibaraib = Ins_KeihiMibaraiB(facadeContext, f02VO, f02m1VO, sysDateVO, denpyogyoNo);
						BoSystemLog.logOut("[経費未払TBL(B)]を登録 END");
					}
				}

				#endregion

				#region 一覧画面項目の設定

				// [選択モードNo]が「修正」の場合
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
				{
					// 一覧画面選択行のVO
					Tf030f01M1Form f01m1VO = (Tf030f01M1Form)f02VO.Dictionary[Tf030p01Constant.DIC_M1SELCETVO];

					// Ｍ１店舗コード
					f01m1VO.M1tenpo_cd = f02VO.Tenpo_cd;
					// Ｍ１店舗名
					f01m1VO.M1tenpo_nm = f02VO.Tenpo_nm;
					// Ｍ１仕入先コード
					f01m1VO.M1siiresaki_cd = f02VO.Siiresaki_cd;
					// Ｍ１仕入先略式名称
					f01m1VO.M1siiresaki_ryaku_nm = f02VO.Siiresaki_ryaku_nm;
					// Ｍ１元伝票番号
					f01m1VO.M1motodenpyo_bango = f02VO.Motodenpyo_bango;
					// Ｍ１納品日
					f01m1VO.M1nohin_ymd = f02VO.Nohin_ymd;
					// Ｍ１数量
					f01m1VO.M1itemsu = f02VO.Gokei_suryo;
					// Ｍ１金額
					f01m1VO.M1kingaku = f02VO.Gokei_kin;
					// Ｍ１確定処理フラグ(隠し)
					f01m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;

					// Dictionary
					// 検品者コード
					f01m1VO.Dictionary[Tf030p01Constant.DIC_M1KENPINSYA_CD] = BoSystemFormat.formatTantoCd(f02VO.Kenpinsya_cd);
					// 検品者名称
					f01m1VO.Dictionary[Tf030p01Constant.DIC_M1KENPINSYA_NM] = f02VO.Kenpinsya_nm;
					// 更新日
					f01m1VO.Dictionary[Tf030p01Constant.DIC_M1UPD_YMD] = sysDateVO.Sysdate.ToString();
					// 更新時間
					f01m1VO.Dictionary[Tf030p01Constant.DIC_M1UPD_TM] = sysDateVO.Systime_mili.ToString();
				}

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#region 印刷処理

				// 帳票ツールに渡すパラメータを格納
				InputData inputData = new InputData();

				// 処理日付
				string syori_ymd = string.Empty;
				// [選択モードNo]が「新規作成」の場合
				if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_INSERT))
				{
					syori_ymd = BoSystemFormat.formatDate(sysDateVO.Sysdate);
				}
				// [選択モードNo]が「修正」の場合
				else if (f02VO.Stkmodeno.Equals(BoSystemConstant.MODE_UPD))
				{
					syori_ymd = BoSystemFormat.formatDate(f02VO.Dictionary[Tf030p01Constant.DIC_SYORI_YMD].ToString());
				}

				// 伝票番号
				inputData.AddScreenParameter(1, BoSystemFormat.formatDenpyoNo(f02VO.Denpyo_bango));
				// 処理日付
				inputData.AddScreenParameter(2, BoSystemFormat.formatDate(syori_ymd));
				// 店舗コード
				inputData.AddScreenParameter(3, BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));

				// PDFファイル名
				string pdfFileNm = string.Format(
					"{0}.{1}",
					BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_KEIHIMIBARAILIST),
					BoSystemConstant.RPT_PDF_EXTENSION
					);

				// 帳票を出力
				OutputInfo output = new BoSystemReport().MdGeneratePDF(
					inputData,
					BoSystemConstant.REPORTID_KEIHIMIBARAILIST,
					Tf030p01Constant.FORMID_01,
					Tf030p01Constant.PGID,
					pdfFileNm
					);

				BoSystemLog.logOut("ReportState［" + output.ReportState + "］");
				if (output.Ex != null)
				{
					// 例外
					BoSystemLog.logOut(output.Ex.ToString());
					//throw output.Ex;
				}

				// PDFをファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tf030p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

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

		#region [経費未払TBL(H)]を登録する。
		/// <summary>
		/// [経費未払TBL(H)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Ins_KeihiMibaraiH(IFacadeContext facadeContext,
									Tf030f02Form f02VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TF030P01-06", facadeContext.DBContext);

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(f02VO.Denpyo_bango));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", sysDateVO.Sysdate);
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", sysDateVO.Systime_mili);
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 入力者コード
			reader.BindValue("BIND_NYURYOKUSHA_CD", BoSystemFormat.formatTantoCd(f02VO.Kenpinsya_cd));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f02VO.Siiresaki_cd));
			// 元伝票番号
			if (!string.IsNullOrEmpty(f02VO.Motodenpyo_bango))
			{
				reader.BindValue("BIND_MOTODENPYO_BANGO", Convert.ToDecimal(f02VO.Motodenpyo_bango));
			}
			else
			{
				reader.BindValue("BIND_MOTODENPYO_BANGO", DBNull.Value);
			}
			// 納品書日付
			reader.BindValue("BIND_NOHINSYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02VO.Nohin_ymd)));
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

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費未払TBL(B)]を登録する。
		/// <summary>
		/// [経費未払TBL(B)]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">画面のVO</param>
		/// <param name="f02m1VO">画面選択行のVO</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="denpyogyoNo">伝票行No.</param>
		/// <returns>更新件数</returns>
		private int Ins_KeihiMibaraiB(IFacadeContext facadeContext,
									Tf030f02Form f02VO,
									Tf030f02M1Form f02m1VO,
									SysDateVO sysDateVO,
									decimal denpyogyoNo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TF030P01-07", facadeContext.DBContext);

			// 処理日付、処理時間を取得する。
			decimal syori_ymd = 0;
			decimal syori_tm = 0;
			// モードが「新規作成」の場合
			if (BoSystemConstant.MODE_INSERT.Equals(f02VO.Stkmodeno))
			{
				// システム日付
				syori_ymd = sysDateVO.Sysdate;
				syori_tm = sysDateVO.Systime_mili;
			}
			// モードが「修正」の場合
			else if (BoSystemConstant.MODE_UPD.Equals(f02VO.Stkmodeno))
			{
				// 経費未払TBL(H)の処理日付、処理時間
				syori_ymd = Convert.ToDecimal(f02VO.Dictionary[Tf030p01Constant.DIC_SYORI_YMD].ToString());
				syori_tm = Convert.ToDecimal(f02VO.Dictionary[Tf030p01Constant.DIC_SYORI_TM].ToString());
			}

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(f02VO.Denpyo_bango));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", syori_ymd);
			// 処理時間
			reader.BindValue("BIND_SYORI_TM", syori_tm);
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 伝票行№
			reader.BindValue("BIND_DENPYOGYO_NO", denpyogyoNo);
			// 摘要コード
			reader.BindValue("BIND_TEKIYO_CD", f02m1VO.M1tekiyo_cd);
			// 数量
			reader.BindValue("BIND_SURYO", Convert.ToDecimal(f02m1VO.M1suryo));
			// 単価
			reader.BindValue("BIND_TNK", Convert.ToDecimal(f02m1VO.M1tnk));
			// 金額
			reader.BindValue("BIND_KINGAKU", Convert.ToDecimal(f02m1VO.M1kingaku));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費未払TBL(H)]を更新する。
		/// <summary>
		/// [経費未払TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">画面のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <returns>更新件数</returns>
		private int Upd_KeihiMibaraiH(IFacadeContext facadeContext,
									Tf030f02Form f02VO,
									LoginInfoVO loginInfo,
									SysDateVO sysDateVO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TF030P01-08", facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd));
			// 入力者コード
			reader.BindValue("BIND_NYURYOKUSHA_CD", BoSystemFormat.formatTantoCd(f02VO.Kenpinsya_cd));
			// 仕入先コード
			reader.BindValue("BIND_SIIRESAKI_CD", BoSystemFormat.formatSiiresakiCd(f02VO.Siiresaki_cd));
			// 元伝票番号
			if (!string.IsNullOrEmpty(f02VO.Motodenpyo_bango))
			{
				reader.BindValue("BIND_MOTODENPYO_BANGO", Convert.ToDecimal(f02VO.Motodenpyo_bango));
			}
			else
			{
				reader.BindValue("BIND_MOTODENPYO_BANGO", DBNull.Value);
			}
			// 納品書日付
			reader.BindValue("BIND_NOHINSYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02VO.Nohin_ymd)));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));

			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(f02VO.Denpyo_bango));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f02VO.Dictionary[Tf030p01Constant.DIC_SYORI_YMD].ToString()));
			// 店舗コード（変更前の店舗コード）
			reader.BindValue("BIND_TENPO_CD2", BoSystemFormat.formatTenpoCd(f02VO.Dictionary[Tf030p01Constant.DIC_MOTO_TENPO_CD].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費未払TBL(B)]を削除する。
		/// <summary>
		/// [経費未払TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">画面のVO</param>
		/// <returns>更新件数</returns>
		private int Del_KeihiMibaraiB(IFacadeContext facadeContext,
									Tf030f02Form f02VO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TF030P01-05", facadeContext.DBContext);
			// 伝票番号
			reader.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(f02VO.Denpyo_bango));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(f02VO.Dictionary[Tf030p01Constant.DIC_SYORI_YMD].ToString()));
			// 店舗コード（変更前の店舗コード）
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Dictionary[Tf030p01Constant.DIC_MOTO_TENPO_CD].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [経費未払TBL(H)]を存在チェックする。
		/// <summary>
		/// [経費未払TBL(H)]を存在チェックする。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f02VO">画面のVO</param>
		/// <returns>件数</returns>
		private Decimal Chk_KeihiMibaraiH(IFacadeContext facadeContext,
									Tf030f02Form f02VO)
		{
			Decimal dCnt = 0;

			FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Tf030p01Constant.SQL_ID_01, facadeContext.DBContext);

			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 検索条件を設定 -----------
			sRepSql = new StringBuilder();

			// 伝票番号
			sRepSql.Append(" AND T1.DENPYO_BANGO = :BIND_DENPYO_BANGO");
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_DENPYO_BANGO";
			bindVO.Value = BoSystemFormat.formatDenpyoNo(f02VO.Denpyo_bango);
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 処理日付(登録日)を設定
			sRepSql.Append(" AND T1.SYORI_YMD = :BIND_SYORI_YMD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYORI_YMD";
			bindVO.Value = BoSystemFormat.formatDate(f02VO.Add_ymd);
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 店舗コードを設定
			sRepSql.Append(" AND T1.TENPO_CD = :BIND_TENPO_CD");
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			BoSystemSql.AddSql(rtChk, Tf030p01Constant.REP_ADD_WHERE, sRepSql.ToString(), bindList);

			//検索結果を取得します
			rtChk.CreateDbCommand();
			IList<Hashtable> tableListcnt = rtChk.Execute();

			BoSystemLog.logOut("SQL: " + rtChk.LogSql);

			if (tableListcnt != null && tableListcnt.Count > 0)
			{
				Hashtable resultTbl = tableListcnt[0];
				dCnt = (Decimal)resultTbl["CNT"];
			}

			return dCnt;
		}
		#endregion

		#endregion
	}
}
