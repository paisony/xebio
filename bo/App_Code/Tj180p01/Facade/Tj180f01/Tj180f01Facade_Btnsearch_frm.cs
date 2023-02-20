using com.xebio.bo.Tj180p01.Constant;
using com.xebio.bo.Tj180p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.FormatUtil;
using Common.Business.V01000.V01001;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tj180p01.Facade
{
  /// <summary>
  /// Tj180f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj180f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnsearch)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnsearch)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNSEARCH_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);
				
				//以下に業務ロジックを記述する。

				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// FormVO取得
				// 画面より情報を取得する。
				Tj180f01Form f01VO = (Tj180f01Form)facadeContext.FormVO;

				//検索条件のDictionaryを初期化する。
				f01VO.Dictionary.Clear();
				#endregion

				#region 業務チェック

				#region マスタ存在チェック
				// ヘッダ店舗コード
				//       店舗マスタを検索し、存在しない場合エラー
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

				#region 棚卸基準日の取得
				// 棚卸基準日の初期化
				string strTanaorosikijun_ymd = string.Empty;

				string strTanaorosijissi_ymd = string.Empty;

				// 棚卸実施日TBLの検索
				Hashtable hsMdit0030 = new Hashtable();
				hsMdit0030 = SearchInventory.SearchMdit0030(BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd),
															sysDateVO.Sysdate.ToString(),
															facadeContext,
															0);
				#endregion

				// 棚卸基準日の設定
				if (hsMdit0030 != null)
				{
					strTanaorosikijun_ymd = Convert.ToString(hsMdit0030["TANAOROSIKIJUN_YMD"]);

					strTanaorosijissi_ymd = Convert.ToString(hsMdit0030["TANAOROSIJISSI_YMD"]);


					#region 入力値チェック
					// 棚卸実施日TBLの検索
					string retTanaorosisyuryo_flg = SearchInventory.CheckInventoryEnd(f01VO.Head_tenpo_cd,
																					  strTanaorosikijun_ymd,
																					  facadeContext,
																					  1);

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						//「-」表示(エラー時)
						DispErr(f01VO);

						return;
					}
					#endregion

				#endregion

				#region 検索処理
					FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj180p01Constant.SQL_ID_03, facadeContext.DBContext);

					#region バインド値の置き換え

					#region 基準日前日帳簿在庫数
					// 店舗コード
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TENPO_CD + "1", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸基準日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TANAOROSIKIJUN_YMD + "1", Convert.ToDecimal(strTanaorosikijun_ymd));
					#endregion

					#region 当日売上数
					// 営業日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_EIGYO_YMD + "1", sysDateVO.Sysdate);

					// 棚卸実施日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TANAOROSIJISSI_YMD + "1", Convert.ToDecimal(strTanaorosijissi_ymd));

					// 店舗コード
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TENPO_CD + "2", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸基準日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TANAOROSIKIJUN_YMD + "2", Convert.ToDecimal(strTanaorosikijun_ymd));
				
					// 店舗コード
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TENPO_CD + "3", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					#endregion

					#region 当日入出荷数
					// 営業日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_EIGYO_YMD + "2", sysDateVO.Sysdate);
					// 棚卸実施日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TANAOROSIJISSI_YMD + "2", Convert.ToDecimal(strTanaorosijissi_ymd));

					// 店舗コード
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TENPO_CD + "4", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸基準日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TANAOROSIKIJUN_YMD + "4", Convert.ToDecimal(strTanaorosikijun_ymd));

					// 店舗コード
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TENPO_CD + "5", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));

					// 店舗コード
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TENPO_CD + "6", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸基準日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TANAOROSIKIJUN_YMD + "6", Convert.ToDecimal(strTanaorosikijun_ymd));
					#endregion

					#region 店舗棚卸数
					// 店舗コード
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TENPO_CD + "7", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸基準日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TANAOROSIKIJUN_YMD + "7", Convert.ToDecimal(strTanaorosikijun_ymd));
					#endregion

					#region 業者棚卸数
					// 店舗コード
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TENPO_CD + "8", BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd));
					// 棚卸基準日
					rtSeach.BindValue(Tj180p01Constant.SQL_ID_03_REP_TANAOROSIKIJUN_YMD + "8", Convert.ToDecimal(strTanaorosikijun_ymd));
					#endregion

					#endregion

					//検索結果を取得します
					rtSeach.CreateDbCommand();
					IList<Hashtable> tableList = rtSeach.Execute();

					foreach (Hashtable rec in tableList)
					{
						f01VO.Kijunbi_zen_tyobozaiko_su = rec["KIJUNBIZENJITUTYOUBOZAIKO"].ToString();	// 基準日前日帳簿在庫数 
						f01VO.Tojitsuuri_su = rec["TOJITUURIAGE"].ToString();							// 当日売上数
						f01VO.Tojitsunyusyukka_su = rec["TOJITUNYUSYUKKA"].ToString();					// 当日入出荷数
						f01VO.Tojitsuyosokuzai_su = rec["TOJITSUYOSOKUZAI_SU"].ToString();				// 当日予測在庫数 
						f01VO.Tenpotanaorosi_su = rec["TENPOTANAOROSI"].ToString();						// 店舗棚卸数 
						f01VO.Gyosyatanaorosi_su = rec["GYOSYATANAOROSI"].ToString();					// 業者棚卸数 
						f01VO.Sai_su = rec["SAI_SU"].ToString();										// 差異数
				
						// Dictionary
						//f01VO.Dictionary.Add(Tj180p01Constant.DIC_KIJUNBIZENJITUTYOUBOZAIKO, rec["KIJUNBIZENJITUTYOUBOZAIKO"].ToString());
						//f01VO.Dictionary.Add(Tj180p01Constant.DIC_TOJITUURIAGE, rec["TOJITUURIAGE"].ToString());
						//f01VO.Dictionary.Add(Tj180p01Constant.DIC_TOJITUNYUSYUKKA, rec["TOJITUNYUSYUKKA"].ToString());
						//f01VO.Dictionary.Add(Tj180p01Constant.DIC_TOJITSUYOSOKUZAI_SU, rec["TOJITSUYOSOKUZAI_SU"].ToString());
						//f01VO.Dictionary.Add(Tj180p01Constant.DIC_TENPOTANAOROSI, rec["TENPOTANAOROSI"].ToString());
						//f01VO.Dictionary.Add(Tj180p01Constant.DIC_GYOSYATANAOROSI, rec["GYOSYATANAOROSI"].ToString());
						//f01VO.Dictionary.Add(Tj180p01Constant.DIC_SAI_SU, rec["SAI_SU"].ToString());
					}
				}
				else
				{
					//	エラー表示
					DispErr(f01VO);
				}

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(f01VO);

				#endregion

				//トランザクションをコミットする。
				//CommitTransaction(facadeContext);
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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNSEARCH_FRM");

		}
		#endregion

		#region 「-」表示(エラー時)
		/// <summary>
		/// 「-」表示(エラー時)
		/// </summary>
		/// <param name="f01VO">Tj180f01Form</param>
		/// <param name=""></param>
		/// <returns></returns>
		private void DispErr(Tj180f01Form f01VO)
		{
			// 各項目を"-"表示する
			f01VO.Kijunbi_zen_tyobozaiko_su = "-";
			f01VO.Tojitsuuri_su = "-";
			f01VO.Tojitsunyusyukka_su = "-";
			f01VO.Tojitsuyosokuzai_su = "-";
			f01VO.Tenpotanaorosi_su = "-";
			f01VO.Gyosyatanaorosi_su = "-";
			f01VO.Sai_su = "-";
		}

		#endregion

	}
}
