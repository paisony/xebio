using com.xebio.bo.Tg090p01.Constant;
using com.xebio.bo.Tg090p01.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01008;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.CsvUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01005;
using Common.Business.V03000.V03001;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tg090p01.Facade
{
  /// <summary>
  /// Tg090f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg090f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btncsv)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btncsv)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNCSV_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

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
				Tg090f01Form f01VO = (Tg090f01Form)facadeContext.FormVO;
				#endregion

				#region 業務チェック

				// 1-1 ヘッダ店舗コード
				// 店舗マスタを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;

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


				// 2 関連チェック
				// 2-1 日付FROM、日付TO
				//       日付ＦＲＯＭ > 日付ＴＯの場合エラー
				if (!string.IsNullOrEmpty(f01VO.Ymd_from) && !string.IsNullOrEmpty(f01VO.Ymd_to))
				{
					V03001Check.DateFromToChk(
									f01VO.Ymd_from,
									f01VO.Ymd_to,
									facadeContext,
									"日付",
									new[] { "Ymd_from", "Ymd_to" }
									);
				}

				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// 2-2 担当者コード
				// 担当者MSTに存在しない場合、エラー
				if (!string.IsNullOrEmpty(f01VO.Tantosya_cd))
				{
					Hashtable tantoInfo = V01005Check.CheckTanto(f01VO.Tantosya_cd, facadeContext, "担当者", new string[] { "Tantosya_cd" });

					if (tantoInfo != null)
					{
						// 名称設定
						f01VO.Hanbaiin_nm = tantoInfo["HANBAIIN_NM"].ToString();
					}
				}

				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

                #region 検索処理
                FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tg090p01Constant.SQL_ID_01, facadeContext.DBContext);

                // 検索条件設定
                AddWhere(f01VO, rtSeach);

                //検索結果を取得します
                rtSeach.CreateDbCommand();
                IList<Hashtable> tableList = rtSeach.Execute();

                // 1-2 対象件数
                // 対象件数が0件の場合エラー
                if (tableList == null || tableList.Count <= 0)
                {
                    // エラー
                    ErrMsgCls.AddErrMsg("E174", String.Empty, facadeContext);
                }
                else
                {
                }

                //エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
                if (MessageDisplayUtil.HasError(facadeContext))
                {
                    return;
                }
                #endregion

				#region CSV出力処理
				// CSV出力用リスト
				IList<IList<string>> csvList = new List<IList<string>>();

				// ヘッダ項目の設定
				csvList.Add(this.getCsvHeader());

                foreach (Hashtable rec in tableList)
                {
                    IList<string> csvListDate = new List<string>();

                    csvListDate.Add(BoSystemFormat.formatDenpyoNo(rec["DENPYO_BANGO"].ToString()));		//伝票番号
                    csvListDate.Add(rec["ADD_YMD"].ToString());	                                        //登録日
                    csvListDate.Add(rec["KAISYA_CD"].ToString());			                            //会社コード
                    csvListDate.Add(rec["KAISYA_NM"].ToString());			                            //会社名
                    csvListDate.Add(BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString()));		    //店舗コード
                    csvListDate.Add(rec["TENPO_NM"].ToString());			                            //店舗名
                    csvListDate.Add(BoSystemFormat.formatTantoCd(rec["ADDTAN_CD"].ToString()));	        //登録担当者コード
                    csvListDate.Add(rec["HANBAIIN_NM"].ToString());			                            //登録担当者名
                    csvListDate.Add(BoSystemFormat.formatSiiresakiCd(rec["SIIRESAKI_CD"].ToString()));	//仕入先コード
                    csvListDate.Add(rec["SIIRESAKI_RYAKU_NM"].ToString());		                        //仕入先名
                    csvListDate.Add("");		                                                        //委託会社
                    csvListDate.Add("");		                                                        //工場
                    csvListDate.Add(BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString()));		    //部門コード
                    csvListDate.Add(rec["BUMONKANA_NM"].ToString());		                            //部門名
                    csvListDate.Add(BoSystemFormat.formatHinsyuCd(rec["HINSYU_CD"].ToString()));		//品種コード
                    csvListDate.Add(rec["HINSYU_RYAKU_NM"].ToString());		                            //品種名
                    csvListDate.Add(BoSystemFormat.formatBrandCd(rec["BURANDO_CD"].ToString()));	    //ブランドコード
                    csvListDate.Add(rec["BURANDO_NMK"].ToString());			                            //ブランド名
                    csvListDate.Add(rec["SYONMK"].ToString());				                            //商品名
                    csvListDate.Add(rec["MAKER_HBN"].ToString());			                            //メーカー品番
                    csvListDate.Add(rec["JAN_CD"].ToString());				                            //スキャンコード
                    csvListDate.Add(rec["JISYA_HBN"].ToString());			                            //自社品番
                    csvListDate.Add(rec["IRO_NM"].ToString());				                            //色
                    csvListDate.Add(rec["SIZE_NM"].ToString());				                            //サイズ
                    csvListDate.Add(rec["SURYO"].ToString());			                                //数量
                    csvListDate.Add(rec["TYOTATSUNM"].ToString());			                            //調達区分
                    csvListDate.Add(rec["SIYOJYOKYO"].ToString());			                            //使用状況
                    csvListDate.Add(rec["HINSITUHURYO"].ToString());		                            //品質不良内容
                    csvListDate.Add(rec["HURYONAIYO"].ToString());				                        //不良内容

                    //リストオブジェクトにM1Formを追加します。
                    csvList.Add(csvListDate);
                }
				#endregion

				// CSV出力
				string tmpFileName = BoSystemCsvUtil.CsvOut(csvList, Tg090p01Constant.PGID, BoSystemConstant.CSVID_HURYOHIN);

				// 一時ファイルをユーザマップに設定
				facadeContext.UserMap.Add(Tg090p01Constant.FCDUO_CSV_FLNM, tmpFileName);

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
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNCSV_FRM");

		}
		#endregion

		#region 条件設定
		/// <summary>
		/// AddWhere 条件設定
		/// </summary>
		/// <param name="Tg090f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void AddWhere(Tg090f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
            ArrayList bindList2 = new ArrayList();
            BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();
            StringBuilder sRepSql2 = new StringBuilder();

			#region 検索条件設定

			// 検索条件を設定 -----------
			// バインドIDを作成
			StringBuilder sBindId = new StringBuilder();


            //店舗の場合、自店のみを対象とする。
            if (!CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo()))
            {
                sRepSql.Append("	AND T1.TENPO_CD = :BIND_TENPO_CD1");
                sRepSql2.Append("	AND T2.TENPO_CD = :BIND_TENPO_CD2");

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_TENPO_CD1";
                bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList.Add(bindVO);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_TENPO_CD2";
                bindVO.Value = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList2.Add(bindVO);
            }

			// 日付FROM-TOを設定

			if (!string.IsNullOrEmpty(f01VO.Ymd_from) || !string.IsNullOrEmpty(f01VO.Ymd_to))
			{
				String ymd_from = f01VO.Ymd_from;
				String ymd_to = f01VO.Ymd_to;

				// 日付FROM
				if (string.IsNullOrEmpty(f01VO.Ymd_from))
				{
					ymd_from = "0";
				}

				// 日付TO
				if (string.IsNullOrEmpty(f01VO.Ymd_to))
				{
					ymd_to = "99999999";
				}

				sRepSql.Append("	AND T1.ADD_YMD BETWEEN :BIND_SITEI_FRM1 AND :BIND_SITEI_TO1");
                sRepSql2.Append("	AND T2.ADD_YMD BETWEEN :BIND_SITEI_FRM2 AND :BIND_SITEI_TO2");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SITEI_FRM1";
				bindVO.Value = BoSystemFormat.formatDate(ymd_from);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SITEI_TO1";
				bindVO.Value = BoSystemFormat.formatDate(ymd_to);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_SITEI_FRM2";
                bindVO.Value = BoSystemFormat.formatDate(ymd_from);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList2.Add(bindVO);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_SITEI_TO2";
                bindVO.Value = BoSystemFormat.formatDate(ymd_to);
                bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
                bindList2.Add(bindVO);

			}

			// 担当者コードを設定

			if (!string.IsNullOrEmpty(f01VO.Tantosya_cd))
			{
				sRepSql.Append("	AND T1.ADDTAN_CD = :BIND_TANTO_CD1");
                sRepSql2.Append("	AND T2.ADDTAN_CD = :BIND_TANTO_CD2");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TANTO_CD1";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Tantosya_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

                bindVO = new BindInfoVO();
                bindVO.BindId = "BIND_TANTO_CD2";
                bindVO.Value = BoSystemFormat.formatSiiresakiCd(f01VO.Tantosya_cd);
                bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
                bindList2.Add(bindVO);

			}

			//PB/NB
			if (f01VO.Tyotatsu_kb.Equals("2")) //PB
			{
                sRepSql.Append(" AND SUBSTR(T1.TYOTATSU_KB,-1,1) NOT BETWEEN 1 AND 4 ");
                sRepSql2.Append(" AND SUBSTR(T2.TYOTATSU_KB,-1,1) NOT BETWEEN 1 AND 4 ");

            }
			else if (f01VO.Tyotatsu_kb.Equals("3")) //NB
			{
                sRepSql.Append(" AND SUBSTR(T1.TYOTATSU_KB,-1,1) BETWEEN 1 AND 4 ");
                sRepSql2.Append(" AND SUBSTR(T2.TYOTATSU_KB,-1,1) BETWEEN 1 AND 4 ");
            }

            if (!CheckKengenCls.CheckKengen(LoginInfoUtil.GetLoginInfo()))
            {
                if (CheckCompanyCls.IsXebio())
                {
                    //ヴィクトリア側の店舗は出さない。
                    sRepSql2.Append(" AND 1 = 0 ");
                }
                else
                {
                    //ゼビオ側の店舗は出さない。
                    sRepSql.Append(" AND 1 = 0 ");
                }

            }

	
			#endregion

			BoSystemSql.AddSql(reader, Tg090p01Constant.SQL_ID_01_REP_ADD_WHERE1, sRepSql.ToString(), bindList);
            BoSystemSql.AddSql(reader, Tg090p01Constant.SQL_ID_01_REP_ADD_WHERE2, sRepSql2.ToString(), bindList2);
        }
		#endregion

		#region CSVヘッダ項目設定
		/// <summary>
		/// getCsvHeader CSVヘッダ項目設定
		/// </summary>
		/// <returns>IList</returns>
		private IList<string> getCsvHeader()
		{

			IList<string> csvListData = new List<string>();

			csvListData.Add("伝票No");
			csvListData.Add("登録日");
			csvListData.Add("会社コード");
			csvListData.Add("会社名");
			csvListData.Add("店舗コード");
			csvListData.Add("店舗名");
			csvListData.Add("登録担当者コード");
			csvListData.Add("登録担当者名");
			csvListData.Add("仕入先");
			csvListData.Add("仕入先名");
			csvListData.Add("委託会社");
			csvListData.Add("工場");
			csvListData.Add("部門コード");
			csvListData.Add("部門名");
			csvListData.Add("品種コード");
			csvListData.Add("品種名");
			csvListData.Add("ブランドコード");
			csvListData.Add("ブランド名");
			csvListData.Add("商品名");
			csvListData.Add("メーカー品番");
			csvListData.Add("スキャンコード");
			csvListData.Add("自社品番");
			csvListData.Add("色");
			csvListData.Add("サイズ");
			csvListData.Add("数量");
      csvListData.Add("PB/NB/SMU");
      csvListData.Add("使用状況");
			csvListData.Add("品質不良内容");
			csvListData.Add("不良内容");
			return csvListData;
		}
		#endregion
	}
}
