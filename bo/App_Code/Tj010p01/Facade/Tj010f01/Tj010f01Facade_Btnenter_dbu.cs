using com.xebio.bo.Tj010p01.Constant;
using com.xebio.bo.Tj010p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.ReportUtil;
using Common.Business.V01000.V01001;
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

namespace com.xebio.bo.Tj010p01.Facade
{
  /// <summary>
  /// Tj010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj010f01Facade : StandardBaseFacade
	{
		#region データベース更新処理を行います。(ボタンID : Btnenter)
		/// <summary>
		/// データベース更新処理を行います。
		/// ボタンID(Btnenter)
		/// アクションID(DBU)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_DBU(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
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

                //カード部を取得します。
                Tj010f01Form f01VO = (Tj010f01Form)facadeContext.FormVO;

                // 営業日取得
 				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);
                #endregion

                #region 業務チェック
               
				#region ① ヘッダ店舗コード
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
               //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
               if (MessageDisplayUtil.HasError(facadeContext))
               {
                   return;
               }
                #endregion

                #region ② 棚卸データ 期間
                //棚卸期間外の場合、エラー
				//共通部品化
				Hashtable TanaoroshiYmdList = SearchInventory.SearchMdit0030(
										f01VO.Head_tenpo_cd,
										sysDateVO.Sysdate.ToString(),     //エラーが発生した場合、その時点でチェックを中止しクライアント側
										facadeContext,
										1);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

                #region ③ 棚卸データ 期間

                //[営業日]　< [棚卸実施日]の場合エラー
				if (sysDateVO.Sysdate < (decimal)TanaoroshiYmdList["TANAOROSIJISSI_YMD"])
                {
                    // 実施日(YYYY/MM/DD)まで送信できません。
					ErrMsgCls.AddErrMsg("E152", BoSystemFormat.formatDate((decimal)TanaoroshiYmdList["TANAOROSIJISSI_YMD"], 1), facadeContext);
					return;
                }

                #endregion

                #region ④ 棚卸データ 終了処理済チェック

				//棚卸終了処理が行われている場合、エラー
                SearchInventory.CheckInventoryEnd(
					f01VO.Head_tenpo_cd,
					TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString(),
					facadeContext,
					1
					);

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }
                #endregion


				#region ⑤⑥共通 棚卸管理TBL 棚卸送信フラグ取得
				// 送信依頼フラグ	0:なし			SOSINIRAI_FLG_NASI
				//					1:送信対象		SOSINIRAI_FLG_SOSINTAISYO
				//					9:データなし	SOSINIRAI_FLG_NULL
				string Sosinirai_flg;

                //sql指定
                FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable("TJ010P01-01", facadeContext.DBContext);
                
          		// バインド値の置き換え
			    // 店舗コード
				rtChk.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			    // 棚卸基準日
				rtChk.BindValue("BIND_TANAOROSIKIJUN_YMD", Convert.ToDecimal(TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString()));
                
                //検索結果を取得します
                rtChk.CreateDbCommand();
                IList<Hashtable> tableList = rtChk.Execute();
				Sosinirai_flg = tableList[0]["SOSINIRAI_FLG"].ToString();           
                    
                #endregion

				#region ⑤ 棚卸データ 存在チェック、重複チェック
				// [棚卸送信状態]が「棚卸送信確定」の場合
				if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI1)
				{
					// 1:送信依頼チェック 棚卸管理TBL 
					// 送信依頼フラグが（0:なし）以外の場合エラー
					if (Sosinirai_flg != Tj010p01Constant.SOSINIRAI_FLG_NASI)
					{
						//送信データが1件もありません。
						ErrMsgCls.AddErrMsg("E131", string.Empty, facadeContext);
					
					}


					// 2:重複チェック 棚卸確定TBL(H)
					// 未送信のデータ内でフェイスNo、棚段で重複データがある場合、エラー
					FindSqlResultTable rtChk2 = FindSqlUtil.CreateFindSqlResultTable("TJ010P01-02", facadeContext.DBContext);
					
					// バインド値の置き換え
					// 店舗コード
					rtChk2.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸基準日
					rtChk2.BindValue("BIND_TANAOROSIKIJUN_YMD", Convert.ToDecimal(TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString()));
					
					// 検索結果を取得します
					rtChk2.CreateDbCommand();
					IList<Hashtable> tableList2 = rtChk2.Execute();

					// 取得件数が1を超える場合、エラー
					if ((decimal)tableList2[0]["CNT"] > 1)
					{
						//重複データがあります。
						ErrMsgCls.AddErrMsg("E158", string.Empty, facadeContext);
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}


				}
				#endregion

				#region ⑥ 棚卸データ 棚卸管理TBL(1:送信対象)存在チェック
				// [棚卸送信状態]が「棚卸送信済解除」の場合
                else if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI2)
                {

					// 送信依頼フラグが（1:送信対象）以外の場合エラー
					if (Sosinirai_flg != Tj010p01Constant.SOSINIRAI_FLG_SOSINTAISYO)
					{
						//送信済みデータが1件もありません。
						ErrMsgCls.AddErrMsg("E195", string.Empty, facadeContext);
						return;
					}
				}
				#endregion

				#endregion 業務チェック

				#region 更新処理
				//[棚卸確定TBL(H)]を更新する。
				BoSystemLog.logOut("[棚卸確定TBL(H)]を更新(棚卸送信確定) START");
				int TanaoroshiKakuteih = Upd_TanaoroshiKakuteih(facadeContext, f01VO, logininfo, sysDateVO, (decimal)TanaoroshiYmdList["TANAOROSIKIJUN_YMD"]);
				BoSystemLog.logOut("[棚卸確定TBL(H)]を更新(棚卸送信確定) END");

				//[棚卸管理TBL]を更新する。
				BoSystemLog.logOut("[棚卸管理TBL]を更新 START");
				int TanaoroshiKanri = Upd_TanaoroshiKanri(facadeContext, f01VO, logininfo, sysDateVO, (decimal)TanaoroshiYmdList["TANAOROSIKIJUN_YMD"]);
				BoSystemLog.logOut("[棚卸管理TBL]を更新 END");
				
				//トランザクションをコミットする。
				CommitTransaction(facadeContext);

				#endregion 更新処理

				#region 印刷処理

				// [棚卸送信状態]が「棚卸送信確定」の場合
				// [[棚卸修正報告書]を出力する。
				if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI1)
				{
					#region 帳票パラメータ設定
					// 棚卸修正報告書
					// ■パラメータ
					// ①店舗コード
					// ②棚卸日
					// ③送信日			←実施日
					// ④送信済みフラグ	(1:未送信データのみ出力 2: 送信済みデータのみを出力 (未設定)：両方とも出力)

					// 帳票ツールに渡すパラメータを格納
					InputData inputData = new InputData();

					//[ヘッダ店舗コード]																								
					inputData.AddScreenParameter(1, BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					//[棚卸基準日]																								
					inputData.AddScreenParameter(2, TanaoroshiYmdList["TANAOROSIKIJUN_YMD"].ToString());
					//[棚卸実施日]	
					inputData.AddScreenParameter(3, TanaoroshiYmdList["TANAOROSIJISSI_YMD"].ToString());
					// 送信処理画面では"1"固定																							
					inputData.AddScreenParameter(4, "1");

					#endregion

					#region 印刷部品
					// 印刷処理
					string pdfFileNm = "";
					OutputInfo output = new OutputInfo();
					BoSystemReport reportCls = new BoSystemReport();
					// PDFファイル名
					pdfFileNm = string.Format("{0}.{1}",
												BoSystemReport.CreateFileName(BoSystemConstant.REPORTID_TANAOROSISYUSEIHOKOKUSYO_V),
												BoSystemConstant.RPT_PDF_EXTENSION
												);
					// 帳票を出力
					output = reportCls.MdGeneratePDF(inputData,
													BoSystemConstant.REPORTID_TANAOROSISYUSEIHOKOKUSYO_V,
													Tj010p01Constant.FORMID_01,
													Tj010p01Constant.PGID,
													pdfFileNm
													);
					
					#endregion 印刷部品

					// PDFをファイルをユーザマップに設定
					facadeContext.UserMap.Add(Tj010p01Constant.FCDUO_RRT_FLNM, pdfFileNm);

				}
				#endregion 印刷処理

				
				#region 確認メッセージ
				// [棚卸送信状態]が「棚卸送信確定」の場合
				if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI1)
				{
					// メッセージI106
					InfoMsgCls.AddInfoMsg("I106", string.Empty, facadeContext);
				}
				// [棚卸送信状態]が「棚卸送信済解除」の場合
				else if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI2)
				{
					// メッセージI107
					InfoMsgCls.AddInfoMsg("I107", string.Empty, facadeContext);
				}

				
				#endregion
				#region ラジオチェック初期化
				f01VO.Tanaorosi_sosin_jyotai = ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI1;
				#endregion 


			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_DBU");
			
	
		}
		#endregion

		#region ユーザー定義関数

		#region [棚卸確定TBL(H)]更新
		/// <summary>
		/// [棚卸確定TBL(H)]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tj010f01Form">カード部のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="tanaoroshiKijunYmd">棚卸基準日</param>
		/// <returns>更新件数</returns>
		private int Upd_TanaoroshiKakuteih(IFacadeContext facadeContext,
											Tj010f01Form f01VO,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO,
											decimal tanaoroshiKijunYmd)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TJ010P01-03", facadeContext.DBContext);
			
			// [棚卸送信状態]が「棚卸送信確定」の場合
			// 送信依頼フラグ = 1
			if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI1)
			{
				// 送信依頼フラグ
				reader.BindValue("BIND_SOSINIRAI_FLG", 1);
			}
			// [棚卸送信状態]が「棚卸送信済解除」の場合
            // 送信依頼フラグ = 0
			else if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI2)
			{
				// 送信依頼フラグ
				reader.BindValue("BIND_SOSINIRAI_FLG", 0);				
			}
		
			// 削除日
			reader.BindValue("BIND_UPD_YMD1", sysDateVO.Sysdate);
			// 送信日
			reader.BindValue("BIND_UPD_YMD2", sysDateVO.Sysdate);
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// 棚卸日
			reader.BindValue("BIND_TANAOROSIKIJUN_YMD", tanaoroshiKijunYmd);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion [棚卸確定TBL(H)]更新

		#region [棚卸管理TBL]更新
		/// <summary>
		/// [棚卸管理TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tj010f01Form">カード部のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <param name="sysDateVO">システム日付情報</param>
		/// <param name="tanaoroshiKijunYmd">棚卸基準日</param>
		/// <returns>更新件数</returns>
		private int Upd_TanaoroshiKanri(IFacadeContext facadeContext,
											Tj010f01Form f01VO,
											LoginInfoVO loginInfo,
											SysDateVO sysDateVO,
											decimal tanaoroshiKijunYmd)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable("TJ010P01-04", facadeContext.DBContext);

			// [棚卸送信状態]が「棚卸送信確定」の場合
			// 送信依頼フラグ = 1
			if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI1)
			{
				// 確定フラグ
				reader.BindValue("BIND_KAKUTEI_FLG", 1);
				reader.BindValue("BIND_KAKUTEI_FLG2", 1);
				// 送信依頼フラグ
				reader.BindValue("BIND_SOSINIRAI_FLG", 1);
			}
			// [棚卸送信状態]が「棚卸送信済解除」の場合
			// 送信依頼フラグ = 0
			else if (f01VO.Tanaorosi_sosin_jyotai == ConditionTanaorosi_sosin_jyotai.VALUE_TANAOROSI_SOSIN_JYOTAI2)
			{
				// 確定フラグ
				reader.BindValue("BIND_KAKUTEI_FLG", 0);
				reader.BindValue("BIND_KAKUTEI_FLG2", 0);
				// 送信依頼フラグ
				reader.BindValue("BIND_SOSINIRAI_FLG", 0);
			}
			// 更新日 削除日
			reader.BindValue("BIND_UPD_YMD1", sysDateVO.Sysdate);
			reader.BindValue("BIND_UPD_YMD2", sysDateVO.Sysdate);
			reader.BindValue("BIND_UPD_YMD3", sysDateVO.Sysdate);
			// 更新時間
			reader.BindValue("BIND_UPD_TM", sysDateVO.Systime);
			// 更新担当者
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(loginInfo.TtsCd));
			// 店舗コード
			reader.BindValue("BIND_TEN_CD", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
			// 棚卸基準日
			reader.BindValue("BIND_TANAOROSIKIJUN_YMD",tanaoroshiKijunYmd);

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}





		}

		#endregion

		#endregion ユーザー定義関数
	}
}
