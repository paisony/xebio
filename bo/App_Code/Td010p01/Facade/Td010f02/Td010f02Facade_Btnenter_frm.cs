using com.xebio.bo.Td010p01.Constant;
using com.xebio.bo.Td010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01003;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01004;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Td010p01.Facade
{
  /// <summary>
  /// Td010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td010f02Facade : StandardBaseFacade
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
				Td010f02Form f02VO = (Td010f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Td010f01M1Form f01M1Form = (Td010f01M1Form)f02VO.Dictionary[Td010p01Constant.DIC_M1SELCETVO];

				decimal dSumSu = 0;		// 合計数量
				decimal dSumKin = 0;	// 合計金額

				#endregion

				#region 業務チェック

				#region 行数チェック

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
						Td010f02M1Form f02m1VO = (Td010f02M1Form)m1List[i];
						if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
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

				#region 単項目チェック

				for (int i = 0; i < m1List.Count; i++)
				{
					Td010f02M1Form f02m1VO = (Td010f02M1Form)m1List[i];

					// スキャンコードが入力されている場合
					f02m1VO.Dictionary[Td010p01Constant.DIC_M1JANCD] = string.Empty;
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
					{

						#region Ｍ１スキャンコード
						int meisaiErr = 0;
						// 発注MSTに存在しない場合、エラー
						SearchHachuVO searchConditionVO = new SearchHachuVO(
							f02m1VO.M1scan_cd,		// スキャンコード
							f02VO.Head_tenpo_cd,	// 店舗コード
							0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
							0,						// 売変 検索フラグ 0:検索しない 1:検索する
							0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
							0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
							0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
							0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
							0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
							0,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
							string.Empty,			// 指示NO（移動出荷マニュアル、返品マニュアル用）
							string.Empty,			// 出荷会社コード（移動出荷マニュアル)
							string.Empty,			// 入荷会社コード（移動出荷マニュアル)
							string.Empty			// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
						);

						Hashtable syohinData = V01004Check.CheckScanCd(
															searchConditionVO,
															facadeContext,
															"スキャンコード",
															new[] { "M1scan_cd" },
															f02m1VO.M1rowno,
															i.ToString(),
															"M1",
															Convert.ToInt32(GetMaxCntCls.GetMaxCnt(facadeContext.CommandInfo.FormId.ToUpper()))
													);
						if (syohinData != null) {
							// 発注マスタ検索値をフォームビーン再設定
							f02m1VO.M1hinsyu_ryaku_nm = (string)syohinData["HINSYU_RYAKU_NM"];	// 品種名
							f02m1VO.M1jisya_hbn = (string)syohinData["XEBIO_CD"];				// 自社品番
							f02m1VO.M1maker_hbn = (string)syohinData["HIN_NBR"];				// メーカー品番
							f02m1VO.M1syonmk = (string)syohinData["SYONMK"];					// 商品名
							f02m1VO.M1iro_nm = (string)syohinData["IRO_NM"];					// 色
							f02m1VO.M1size_nm = (string)syohinData["SIZE_NM"];					// サイズ
							f02m1VO.M1gen_tnk = ((decimal)syohinData["GENKA"]).ToString();		// 原単価
							Decimal genkakin = (decimal)syohinData["GENKA"] * Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1suryo, "0"));
							f02m1VO.M1genkakin = genkakin.ToString();							// 原価金額

							f02m1VO.Dictionary[Td010p01Constant.DIC_M1HINSYU_CD] = ((decimal)syohinData["HINSYU_CD"]).ToString();	// 品種コード
							f02m1VO.Dictionary[Td010p01Constant.DIC_M1IRO_CD] = (string)syohinData["MAKERCOLOR_CD"];				// 色コード
							f02m1VO.Dictionary[Td010p01Constant.DIC_M1SIZE_CD] = (string)syohinData["SIZE_CD"];						// サイズコード
							f02m1VO.Dictionary[Td010p01Constant.DIC_M1SYOHIN_CD] = (string)syohinData["SYOHIN_CD"];					// 商品コード
							f02m1VO.Dictionary[Td010p01Constant.DIC_M1JANCD] = (string)syohinData["JAN_CD"];						// JANコード
							
							string siiresakicd = (string)syohinData["SIIRESAKI_CD"];
							string bumoncd = (string)syohinData["BUMON_CD"];
							string brandcd = (string)syohinData["BURANDO_CD"];

							dSumSu += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1suryo, "0"));		// 合計数量
							dSumKin += genkakin;								// 合計金額


							// ヘッダ情報と仕入先が異なる場合、エラー
							if (meisaiErr == 0)
							{
								if (!f02VO.Siiresaki_cd.Equals(siiresakicd))
								{
									meisaiErr = 1;
									ErrMsgCls.AddErrMsg("E100", "仕入先", facadeContext, new[] { "M1scan_cd" }, f02m1VO.M1rowno, i.ToString(), "M1");
								}
							}

							// ヘッダ情報と部門が異なる場合、エラー
							if (meisaiErr == 0)
							{
								if (!f02VO.Bumon_cd.Equals(bumoncd))
								{
									meisaiErr = 1;
									ErrMsgCls.AddErrMsg("E100", "部門", facadeContext, new[] { "M1scan_cd" }, f02m1VO.M1rowno, i.ToString(), "M1");
								}
							}

							// ヘッダ情報とブランドが異なる場合、エラー
							if (meisaiErr == 0)
							{
								if (!f02VO.Burando_cd.Equals(brandcd))
								{
									meisaiErr = 1;
									ErrMsgCls.AddErrMsg("E100", "ブランド", facadeContext, new[] { "M1scan_cd" }, f02m1VO.M1rowno, i.ToString(), "M1");
								}
							}

							// 原価がマイナスの場合、エラー
							if (meisaiErr == 0)
							{
								if (Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0")) < 0)
								{
									meisaiErr = 1;
									ErrMsgCls.AddErrMsg("E146", String.Empty, facadeContext, new[] { "M1scan_cd" }, f02m1VO.M1rowno, i.ToString(), "M1");
								}
							}

							// 入力されている場合、指示番号チェック
							if (!string.IsNullOrEmpty(f02VO.Siji_bango))
							{
								SearchHachuVO searchSijiConditionVO = new SearchHachuVO(
									f02m1VO.M1scan_cd,		// スキャンコード
									f02VO.Head_tenpo_cd,	// 店舗コード
									0,						// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
									0,						// 売変 検索フラグ 0:検索しない 1:検索する
									0,						// 店在庫 検索フラグ 0:検索しない 1:検索する
									0,						// 入荷予定数 検索フラグ 0:検索しない 1:検索する
									0,						// 売上実績数 検索フラグ 0:検索しない 1:検索する
									0,						// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
									0,						// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
									2,						// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
									f02VO.Siji_bango,		// 指示NO（移動出荷マニュアル、返品マニュアル用）
									string.Empty,			// 出荷会社コード（移動出荷マニュアル)
									string.Empty,			// 入荷会社コード（移動出荷マニュアル)
									f02VO.Head_tenpo_cd		// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
								);
								Hashtable syohinDataSiji = V01004Check.CheckScanCd(
																	searchSijiConditionVO,
																	facadeContext
															);
								if (syohinDataSiji == null)
								{
									ErrMsgCls.AddErrMsg("E149"
														, string.Empty
														, facadeContext
														, new[] { "M1scan_cd" }
														, f02m1VO.M1rowno
														, i.ToString()
														, "M1"
														, m1List.DispRow
														);
									meisaiErr = 1;
								}

							}

						}
						#endregion

						#region Ｍ１数量
						// 入力されていない場合、エラー

						if (string.IsNullOrEmpty(f02m1VO.M1suryo.Trim()))
						{
							meisaiErr = 1;
							ErrMsgCls.AddErrMsg("E121", "数量", facadeContext, new[] { "M1suryo" }, f02m1VO.M1rowno, i.ToString(), "M1");
						}

						// 0が入力された場合、エラー
						if (meisaiErr == 0)
						{
							if (f02m1VO.M1suryo.Trim().Equals("0"))
							{
								meisaiErr = 1;
								ErrMsgCls.AddErrMsg("E103", "数量", facadeContext, new[] { "M1suryo" }, f02m1VO.M1rowno, i.ToString(), "M1");
							}
						}
						#endregion


					}
				}

				#region スキャンコード 重複チェック
				for (int i = 0; i < m1List.Count; i++)
				{
					Td010f02M1Form f02m1VO = (Td010f02M1Form)m1List[i];
					// スキャンコードが入力されている場合
					if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
					{

						for (int j = 0; j < m1List.Count; j++)
						{
							if (i == j)
							{
								// 現在行と一致する場合、読み飛ばす
								continue;
							}

							Td010f02M1Form f02m1VOChk = (Td010f02M1Form)m1List[j];
							string jancd = (string)f02m1VO.Dictionary[Td010p01Constant.DIC_M1JANCD];
							string jancdchk = (string)f02m1VOChk.Dictionary[Td010p01Constant.DIC_M1JANCD];
							// スキャンコードが入力されている場合
							if (jancd.Equals(jancdchk))
							{
								// 重複エラー
								ErrMsgCls.AddErrMsg("E130", string.Empty, facadeContext, new[] { "M1scan_cd" }, f02m1VO.M1rowno, i.ToString(), "M1");

							}
						}
					}
				}
				#endregion

				#region 有効桁数チェック

				#region 合計数量
				if (f02VO.Gokei_suryo.Length > 8)
				{
					// 合計数量が有効桁数を超えています。
					ErrMsgCls.AddErrMsg("E102", "合計数量", facadeContext);
				}
				#endregion

				#region 原価金額合計
				if (f02VO.Genka_kin_gokei.Length > 9)
				{
					// 原価金額合計が有効桁数を超えています。
					ErrMsgCls.AddErrMsg("E102", "原価金額合計", facadeContext);
				}
				#endregion

				#endregion

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 排他チェック

				StringBuilder sRepSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");
				sRepSql.Append(" AND KANRI_NO = :BIND_KANRI_NO");
				sRepSql.Append(" AND SYORI_YMD = :BIND_SYORI_YMD");

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 管理No
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_KANRI_NO";
				bindVO.Value = BoSystemFormat.formatDenpyoNo((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1KANRI_NO]);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 処理日付
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SYORI_YMD";
				bindVO.Value = (string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD];
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);


				// 排他チェック
				V03003Check.CheckHaitaMaxVal(
						Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1UPD_YMD], "0")),
						Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1UPD_TM], "0")),
						facadeContext,
						"MDRT0010",
						sRepSql.ToString(),
						bindList,
						1,
					//new[] { "M1kanri_no" },
						null,
						null,
						null,
						null,
						0
				);

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

				// [返品予定TBL(B)]を削除する。
				BoSystemLog.logOut("[返品予定TBL(B)]を削除 START");
				int Delcnt = Del_HenpinYoteib(facadeContext, f01M1Form, f02VO, logininfo);
				BoSystemLog.logOut("[返品予定TBL(B)]を削除 END");

				// [返品予定TBL(B)]を登録する。
				BoSystemLog.logOut("[返品予定TBL(B)]を登録 START");
				int Intcnt = Ins_HenpinYoteib(facadeContext, f01M1Form, f02VO, logininfo);
				BoSystemLog.logOut("[返品予定TBL(B)]を登録 END");

				// [返品予定TBL(H)]を更新する。
				BoSystemLog.logOut("[返品予定TBL(H)]を更新 START");
				int Updcnt = Upd_HenpinYoteih(facadeContext, f01M1Form, f02VO, logininfo, dSumSu, dSumKin, sysDateVO);
				BoSystemLog.logOut("[返品予定TBL(H)]を更新 END");

				#endregion

				#region 画面表示
				// ヘッダ情報を更新する。
				f01M1Form.M1suryo = dSumSu.ToString();		// 合計数量
				f01M1Form.M1genkakin = dSumKin.ToString();	// 合計金額
				f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;	// 確定処理フラグ

				f01M1Form.Dictionary[Td010p01Constant.DIC_M1UPD_YMD] = sysDateVO.Sysdate.ToString();		// 更新日付
				f01M1Form.Dictionary[Td010p01Constant.DIC_M1UPD_TM] = sysDateVO.Systime_mili.ToString();	// 更新時間
				f01M1Form.Dictionary[Td010p01Constant.DIC_M1UPD_TANCD] = logininfo.TtsCd;					// 更新担当者コード

				#endregion

				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
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

		#region [返品予定TBL(B)]を削除する。
		/// <summary>
		/// [返品予定TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="f02VO">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_HenpinYoteib(IFacadeContext facadeContext, Td010f01M1Form f01M1Form, Td010f02Form f02VO, LoginInfoVO loginInfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-06", facadeContext.DBContext);

			// 店舗コードのバインド
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
			// 管理Noのバインド
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02VO.Kanri_no)));
			// 処理日のバインド
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));


			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [返品予定TBL(B)]を登録する。
		/// <summary>
		/// [返品予定TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="f02VO">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Ins_HenpinYoteib(IFacadeContext facadeContext, Td010f01M1Form f01M1Form, Td010f02Form f02VO, LoginInfoVO loginInfo)
		{
			int iRownum = 0;
			IDataList m1List = f02VO.GetList("M1");

			decimal dKanriNo = Convert.ToDecimal(BoSystemFormat.formatDenpyoNo((String)f01M1Form.Dictionary[Td010p01Constant.DIC_M1KANRI_NO]));	// 管理№
			decimal Syori_ymd =  Convert.ToDecimal(BoSystemString.Nvl((String)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0"));	// 処理日付
			decimal Syori_tm = Convert.ToDecimal(BoSystemString.Nvl((String)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_TM], "0"));		// 処理時間
			decimal dSijiNo = Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1siji_bango, "0"));												// 指示番号


			// Oracleコマンドの生成
			OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
			// トランザクションの設定
			command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
			// SQLの実行タイプ
			command.CommandType = CommandType.Text;


			IList<Mdrt0011VO> insertBodyList = new List<Mdrt0011VO>();	// 更新データリスト

			// パラメータバインド処理
			IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();
			int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）

			for (int i = 0; i < m1List.Count; i++)
			{
				Td010f02M1Form f02m1VO = (Td010f02M1Form) m1List[i];
				// スキャンコードが入力されている行が対象
				if (!string.IsNullOrEmpty(f02m1VO.M1scan_cd.Trim()))
				{
					counter++;
					iRownum++;

					Dictionary<string, string> bindDic = new Dictionary<string, string>();

					// 管理№
					BoSystemDb.setInsertVal("KANRI_NO", iRownum.ToString(), dKanriNo, ref bindDic, ref command);
					// 処理日付
					BoSystemDb.setInsertVal("SYORI_YMD", iRownum.ToString(), Syori_ymd, ref bindDic, ref command);
					// 処理時間
					BoSystemDb.setInsertVal("SYORI_TM", iRownum.ToString(), Syori_tm, ref bindDic, ref command);
					// 店舗コード
					BoSystemDb.setInsertVal("TENPO_CD", iRownum.ToString(), BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd), ref bindDic, ref command);
					// 伝票行№
					BoSystemDb.setInsertVal("DENPYOGYO_NO", iRownum.ToString(), iRownum, ref bindDic, ref command);
					// 部門コード
					BoSystemDb.setInsertVal("BUMON_CD", iRownum.ToString(), f02VO.Bumon_cd, ref bindDic, ref command);
					// 品種コード
					BoSystemDb.setInsertVal("HINSYU_CD", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl((string)f02m1VO.Dictionary[Td010p01Constant.DIC_M1HINSYU_CD], "0")), ref bindDic, ref command);
					// ブランドコード
					BoSystemDb.setInsertVal("BURANDO_CD", iRownum.ToString(), BoSystemFormat.formatBrandCd(f02VO.Burando_cd), ref bindDic, ref command);
					// 自社品番
					BoSystemDb.setInsertVal("JISYA_HBN", iRownum.ToString(), BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn), ref bindDic, ref command);
					// メーカー品番
					BoSystemDb.setInsertVal("MAKER_HBN", iRownum.ToString(), f02m1VO.M1maker_hbn, ref bindDic, ref command);
					// 商品名(カナ)
					BoSystemDb.setInsertVal("SYONMK", iRownum.ToString(), f02m1VO.M1syonmk, ref bindDic, ref command);
					// 色コード
					BoSystemDb.setInsertVal("IRO_CD", iRownum.ToString(), BoSystemFormat.formatIroCd((string)f02m1VO.Dictionary[Td010p01Constant.DIC_M1IRO_CD]), ref bindDic, ref command);
					// サイズコード
					BoSystemDb.setInsertVal("SIZE_CD", iRownum.ToString(), BoSystemFormat.formatSizeCd((string)f02m1VO.Dictionary[Td010p01Constant.DIC_M1SIZE_CD]), ref bindDic, ref command);
					// サイズ
					BoSystemDb.setInsertVal("SIZE_NM", iRownum.ToString(), f02m1VO.M1size_nm, ref bindDic, ref command);
					// ＪＡＮコード
					//BoSystemDb.setInsertVal("JAN_CD", iRownum.ToString(), BoSystemFormat.formatJanCd(f02m1VO.M1scan_cd), ref bindDic, ref command);
					BoSystemDb.setInsertVal("JAN_CD", iRownum.ToString(), BoSystemFormat.formatJanCd((string)f02m1VO.Dictionary[Td010p01Constant.DIC_M1JANCD]), ref bindDic, ref command);
					// 商品コード
					BoSystemDb.setInsertVal("SYOHIN_CD", iRownum.ToString(), (string)f02m1VO.Dictionary[Td010p01Constant.DIC_M1SYOHIN_CD], ref bindDic, ref command);
					// 返品予定数
					BoSystemDb.setInsertVal("HENPINYOTEI_SU", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1suryo, "0")), ref bindDic, ref command);
					// 原単価
					BoSystemDb.setInsertVal("GEN_TNK", iRownum.ToString(), Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1gen_tnk, "0")), ref bindDic, ref command);
					// 指示番号
					BoSystemDb.setInsertVal("SIJI_BANGO", iRownum.ToString(), dSijiNo, ref bindDic, ref command);

					insertBindList.Add(bindDic);

					// 一括処理単位に達した場合は、マルチインサートを実行
					if (counter == 20)
					{
						// カウンタのリセット
						counter = 0;

						// マルチインサートの実行
						command.CommandText = GetSqlMultiInsT_HenpinYoteib(insertBindList);
						//OutPutLog(command.CommandText);
						command.ExecuteNonQuery();

						// 配列、バインドパラメータのクリア
						insertBindList.Clear();
						command.Parameters.Clear();
					}
				}

			}// for

			// 未登録レコードの登録
			if (counter > 0)
			{
				// マルチインサートの実行
				command.CommandText = GetSqlMultiInsT_HenpinYoteib(insertBindList);
				command.ExecuteNonQuery();
			}

			return iRownum;
		}
		#endregion

		#region [返品予定TBL(B)]へのマルチインサート文作成。
		/// <summary>
		/// 返品予定Bへのマルチインサートを行うSQL文を取得する。
		/// </summary>
		/// <param name="insertBindList">バインドテキスト</param>
		private string GetSqlMultiInsT_HenpinYoteib(IList<Dictionary<string, string>> insertBindList)
		{
			IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

			// バインドテキストのデータ分INSERT文を作成
			foreach (Dictionary<string, string> bindDic in insertBindList)
			{
				StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文
				insertSql.Append("    INTO MDRT0011 VALUES ( ");
				insertSql.Append(bindDic["KANRI_NO"]).Append(" , ");
				insertSql.Append(bindDic["SYORI_YMD"]).Append(" , ");
				insertSql.Append(bindDic["SYORI_TM"]).Append(" , ");
				insertSql.Append(bindDic["TENPO_CD"]).Append(" , ");
				insertSql.Append(bindDic["DENPYOGYO_NO"]).Append(" , ");
				insertSql.Append(bindDic["BUMON_CD"]).Append(" , ");
				insertSql.Append(bindDic["HINSYU_CD"]).Append(" , ");
				insertSql.Append(bindDic["BURANDO_CD"]).Append(" , ");
				insertSql.Append(bindDic["JISYA_HBN"]).Append(" , ");
				insertSql.Append(bindDic["MAKER_HBN"]).Append(" , ");
				insertSql.Append(bindDic["SYONMK"]).Append(" , ");
				insertSql.Append(bindDic["IRO_CD"]).Append(" , ");
				insertSql.Append(bindDic["SIZE_CD"]).Append(" , ");
				insertSql.Append(bindDic["SIZE_NM"]).Append(" , ");
				insertSql.Append(bindDic["JAN_CD"]).Append(" , ");
				insertSql.Append(bindDic["SYOHIN_CD"]).Append(" , ");
				insertSql.Append(bindDic["HENPINYOTEI_SU"]).Append(" , ");
				insertSql.Append(bindDic["GEN_TNK"]).Append(" , ");
				insertSql.Append(bindDic["SIJI_BANGO"]);
				insertSql.Append(" ) ");

				insertSqlList.Add(insertSql.ToString());
			}

			// 単一INSERTをまとめて、マルチインサート文を作成
			StringBuilder sql = new StringBuilder();
			sql.AppendLine("INSERT ALL");
			foreach (string sqlpart in insertSqlList)
			{
				sql.AppendLine(sqlpart);
			}
			sql.AppendLine("SELECT 1 FROM DUAL");

			return sql.ToString();
		}
		#endregion

		#region [返品予定TBL(H)]を更新する。
		/// <summary>
		/// [返品予定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="f02VO">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Upd_HenpinYoteih(IFacadeContext facadeContext, Td010f01M1Form f01M1Form, Td010f02Form f02VO, LoginInfoVO loginInfo, Decimal dSumSu, Decimal dSumKin, SysDateVO sysDateVO)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TD010P01-07", facadeContext.DBContext);

			// 返品予定合計数量
			reader.BindValue("BIND_HENPINYOTEIGOKEI_SU", dSumSu);
			// 返品予定合計原価金額
			reader.BindValue("BIND_HENPINYOTEIGOUKEI_KIN", dSumKin);
			// 担当者コード
			reader.BindValue("BIND_TANTOSYA_CD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime_mili);
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", sysDateVO.Sysdate);

			// 店舗コードのバインド
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd));
			// 管理Noのバインド
			reader.BindValue("BIND_KANRI_NO", Convert.ToDecimal(BoSystemFormat.formatDenpyoNo(f02VO.Kanri_no)));
			// 処理日のバインド
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(BoSystemString.Nvl((string)f01M1Form.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));


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
