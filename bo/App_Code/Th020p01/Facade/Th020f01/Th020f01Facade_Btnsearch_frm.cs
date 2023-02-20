using com.xebio.bo.Th020p01.Constant;
using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C01000.C01019;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01001;
using Common.Business.V01000.V01003;
using Common.Business.V01000.V01006;
using Common.Business.V03000.V03002;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Th020p01.Facade
{
  /// <summary>
  /// Th020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th020f01Facade : StandardBaseFacade
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
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Th020f01Form f01VO = (Th020f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 一覧の初期化
				m1List.ClearCacheData();
				m1List.Clear();

				// 選択モードの初期化
				f01VO.Stkmodeno = string.Empty;

				// 検索条件のDictionaryを初期化
				SearchConditionSaveCls.SearchConditionRemove(f01VO);

				// 会社コード
				String sKaisya_cd = string.Empty;

				// エリアコード(エリア別画面用)
				String sArea_cd = string.Empty;

				#endregion

				#region 業務チェック

				#region モード共通チェック

				// 1-1 ヘッダ店舗コード
				// 店舗MSTを検索し、存在しない場合エラー
				f01VO.Head_tenpo_nm = string.Empty;
				if (!string.IsNullOrEmpty(f01VO.Head_tenpo_cd))
				{
					Hashtable resultHash = new Hashtable();
					resultHash = V01001Check.CheckTenpo(f01VO.Head_tenpo_cd, facadeContext, "店舗", new[] { "Head_tenpo_cd" });
					// 名称をラベルに設定
					if (resultHash != null)
					{
						f01VO.Head_tenpo_nm = (string)resultHash["TENPO_NM"].ToString();
						sArea_cd = (string)resultHash["AREA_CD"].ToString();
					}
				}

				//エラーが発生した場合、モード別単項目チェックを行う

				#endregion

				#region モード別チェック

				switch (f01VO.Modeno)
				{
					case BoSystemConstant.MODE_JISHAHINBAN:		// モード自社品番

						// 2-1 旧自社品番FROM、旧自社品番TO
						// 両方が未入力の場合エラー
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from) && string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
						{
							ErrMsgCls.AddErrMsg("E121", "自社品番", facadeContext, new[] { "Old_jisya_hbn_from", "Old_jisya_hbn_to" });
						}

						// 2-2 会社コード
						// 未入力の場合エラー
						if (string.IsNullOrEmpty(f01VO.Kaisya_cd))
						{
							ErrMsgCls.AddErrMsg("E121", "会社", facadeContext, new[] { "Kaisya_cd" });
						}

						// 2-3 会社コード
						// 名称MSTを検索し、存在しない場合エラー
						f01VO.Kaisya_nm = string.Empty;
						if (!string.IsNullOrEmpty(f01VO.Kaisya_cd))
						{
							Hashtable resultHash = new Hashtable();
							resultHash = V01006Check.CheckKaisya(f01VO.Kaisya_cd
																, facadeContext
																, string.Empty
																, null
																, "会社"
																, new[] { "Kaisya_cd" }
																, null
																, null
																, null
																, 0
																, 0
																);
							// 名称をラベルに設定
							if (resultHash != null)
							{
								f01VO.Kaisya_nm = resultHash["MEISYO_NM"].ToString();
							}
						}

						//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}

						// 6-1 旧自社品番FROM、旧自社品番TO
						// 旧自社品番FROMと旧自社品番TOの桁数が異なる場合エラー
						if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from) && !string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to)
							&& !f01VO.Old_jisya_hbn_from.Length.Equals(f01VO.Old_jisya_hbn_to.Length))
						{
							ErrMsgCls.AddErrMsg("E191", string.Empty, facadeContext, new[] { "Old_jisya_hbn_from", "Old_jisya_hbn_to" });	
						}

						// 6-2 旧自社品番FROM、旧自社品番TO
						// 旧自社品番FROM > 旧自社品番TOの場合エラー
						if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from) && !string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
						{
							V03002Check.CodeFromToChk(
											f01VO.Old_jisya_hbn_from,
											f01VO.Old_jisya_hbn_to,
											facadeContext,
											"自社品番",
											new[] { "Old_jisya_hbn_from", "Old_jisya_hbn_to" }
											);
						}

						//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}

						// 会社コードを設定
						sKaisya_cd = f01VO.Kaisya_cd;

						break;

					case BoSystemConstant.MODE_JISYAHBNFUKUSU:	// モード自社品番(複数)

						// 3-1 旧自社品番、旧自社品番２、旧自社品番３、旧自社品番４、旧自社品番５
						// すべて未入力の場合エラー
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn)
							&& string.IsNullOrEmpty(f01VO.Old_jisya_hbn2)
							&& string.IsNullOrEmpty(f01VO.Old_jisya_hbn3)
							&& string.IsNullOrEmpty(f01VO.Old_jisya_hbn4)
							&& string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
						{
							ErrMsgCls.AddErrMsg("E121", "自社品番", facadeContext, new[] { "Old_jisya_hbn", "Old_jisya_hbn2", "Old_jisya_hbn3", "Old_jisya_hbn4", "Old_jisya_hbn5" });	
						}

						// 自社品番、スキャンコード存在チェック用
						// 発注条件VOを定義
						SearchHachuVO searchConditionVO = new SearchHachuVO();
						searchConditionVO.Tencd = f01VO.Head_tenpo_cd;	// 店舗コード

						// 1-5 旧自社品番、旧自社品番2、旧自社品番3、旧自社品番4、旧自社品番5
						// 発注MSTを検索し、存在しない場合エラー

						// 旧自社品番
						if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
						{
							searchConditionVO.Scancd = f01VO.Old_jisya_hbn;	// 旧自社品番
							Hashtable resultHash = new Hashtable();
							resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番1", new[] { "Old_jisya_hbn" });
						}

						// 旧自社品番２
						if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
						{
							searchConditionVO.Scancd = f01VO.Old_jisya_hbn2;	// 旧自社品番２
							Hashtable resultHash = new Hashtable();
							resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番2", new[] { "Old_jisya_hbn2" });
						}

						// 旧自社品番３
						if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
						{
							searchConditionVO.Scancd = f01VO.Old_jisya_hbn3;	// 旧自社品番３
							Hashtable resultHash = new Hashtable();
							resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番3", new[] { "Old_jisya_hbn3" });
						}

						// 旧自社品番４
						if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
						{
							searchConditionVO.Scancd = f01VO.Old_jisya_hbn4;	// 旧自社品番４
							Hashtable resultHash = new Hashtable();
							resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番4", new[] { "Old_jisya_hbn4" });
						}

						// 旧自社品番５
						if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
						{
							searchConditionVO.Scancd = f01VO.Old_jisya_hbn5;	// 旧自社品番５
							Hashtable resultHash = new Hashtable();
							resultHash = V01003Check.CheckXebioCd(searchConditionVO, facadeContext, "自社品番5", new[] { "Old_jisya_hbn5" });
						}

						// 3-2 会社コード
						// 未入力の場合エラー
						if (string.IsNullOrEmpty(f01VO.Kaisya_cd2))
						{
							ErrMsgCls.AddErrMsg("E121", "会社", facadeContext, new[] { "Kaisya_cd2" });
						}

						// 3-3 会社コード
						// 名称MSTを検索し、存在しない場合エラー
						f01VO.Kaisya_nm2 = string.Empty;
						if (!string.IsNullOrEmpty(f01VO.Kaisya_cd2))
						{
							Hashtable resultHash = new Hashtable();
							resultHash = V01006Check.CheckKaisya(f01VO.Kaisya_cd2
																, facadeContext
																, string.Empty
																, null
																, "会社"
																, new[] { "Kaisya_cd2" }
																, null
																, null
																, null
																, 0
																, 0
																);
							// 名称をラベルに設定
							if (resultHash != null)
							{
								f01VO.Kaisya_nm2 = resultHash["MEISYO_NM"].ToString();
							}
						}

						//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}

						// 会社コードを設定
						sKaisya_cd = f01VO.Kaisya_cd2;

						break;

					case BoSystemConstant.MODE_SCANCD:			// モードスキャンコード

						// 4-1 スキャンコードFROM、スキャンコードTO												
						// 両方が未入力の場合エラー
						if (string.IsNullOrEmpty(f01VO.Scan_cd_from) && string.IsNullOrEmpty(f01VO.Scan_cd_to))
						{
							ErrMsgCls.AddErrMsg("E121", "スキャンコード", facadeContext, new[] { "Scan_cd_from", "Scan_cd_to" });	
						}

						// 4-2 会社コード
						// 未入力の場合エラー
						if (string.IsNullOrEmpty(f01VO.Kaisya_cd3))
						{
							ErrMsgCls.AddErrMsg("E121", "会社", facadeContext, new[] { "Kaisya_cd3" });
						}

						// 4-3 会社コード
						// 名称MSTを検索し、存在しない場合エラー
						f01VO.Kaisya_nm3 = string.Empty;
						if (!string.IsNullOrEmpty(f01VO.Kaisya_cd3))
						{
							Hashtable resultHash = new Hashtable();
							resultHash = V01006Check.CheckKaisya(f01VO.Kaisya_cd3
																, facadeContext
																, string.Empty
																, null
																, "会社"
																, new[] { "Kaisya_cd3" }
																, null
																, null
																, null
																, 0
																, 0
																);
							// 名称をラベルに設定
							if (resultHash != null)
							{
								f01VO.Kaisya_nm3 = resultHash["MEISYO_NM"].ToString();
							}
						}

						//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}

						// 7-1 スキャンコード
						// スキャンコードFROMとスキャンコードTOの桁数が異なる場合エラー
						if (!string.IsNullOrEmpty(f01VO.Scan_cd_from) && !string.IsNullOrEmpty(f01VO.Scan_cd_to)
							&& !f01VO.Scan_cd_from.Length.Equals(f01VO.Scan_cd_to.Length))
						{
							ErrMsgCls.AddErrMsg("E191", string.Empty, facadeContext, new[] { "Scan_cd_from", "Scan_cd_to" });
						}

						// 7-2 スキャンコード
						// スキャンコードFROM > スキャンコードTOの場合エラー
						if (!string.IsNullOrEmpty(f01VO.Scan_cd_from) && !string.IsNullOrEmpty(f01VO.Scan_cd_to))
						{
							V03002Check.CodeFromToChk(
											f01VO.Scan_cd_from,
											f01VO.Scan_cd_to,
											facadeContext,
											"スキャンコード",
											new[] { "Scan_cd_from", "Scan_cd_to" }
											);
						}

						//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}

						// 会社コードを設定
						sKaisya_cd = f01VO.Kaisya_cd3;

						break;

					case BoSystemConstant.MODE_MAKERHBN:		// モードメーカー品番

						// 5-1 メーカー品番
						// 未入力の場合エラー
						if (string.IsNullOrEmpty(f01VO.Maker_hbn))
						{
							ErrMsgCls.AddErrMsg("E121", "メーカー品番", facadeContext, new[] { "Maker_hbn" });	
						}

						// 5-2 会社コード
						// 未入力の場合エラー
						if (string.IsNullOrEmpty(f01VO.Kaisya_cd4))
						{
							ErrMsgCls.AddErrMsg("E121", "会社", facadeContext, new[] { "Kaisya_cd4" });
						}

						// 5-3 会社コード
						// 名称MSTを検索し、存在しない場合エラー
						f01VO.Kaisya_nm4 = string.Empty;
						if (!string.IsNullOrEmpty(f01VO.Kaisya_cd4))
						{
							Hashtable resultHash = new Hashtable();
							resultHash = V01006Check.CheckKaisya(f01VO.Kaisya_cd4
																, facadeContext
																, string.Empty
																, null
																, "会社"
																, new[] { "Kaisya_cd4" }
																, null
																, null
																, null
																, 0
																, 0
																);
							// 名称をラベルに設定
							if (resultHash != null)
							{
								f01VO.Kaisya_nm4 = resultHash["MEISYO_NM"].ToString();
							}
						}

						//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
						if (MessageDisplayUtil.HasError(facadeContext))
						{
							return;
						}

						// 会社コードを設定
						sKaisya_cd = f01VO.Kaisya_cd4;

						break;
					default:
						break;
				}

				#endregion

				#region 件数チェック

				// 検索件数
				Decimal dCnt = 0;

				// テーブルID
				String tableId = String.Empty;

				FindSqlResultTable rtChk = FindSqlUtil.CreateFindSqlResultTable(Th020p01Constant.SQL_ID_01, facadeContext.DBContext);

				// テーブルID設定				
				tableId = "MDMT0130_" + sKaisya_cd.Substring(sKaisya_cd.Length - 1, 1) + " MDMT0130";
				BoSystemSql.AddSql(rtChk, Th020p01Constant.REP_ADD_TABLE, tableId);

				// 検索条件設定
				this.AddWhere(f01VO, rtChk);

				//検索結果を取得します
				rtChk.CreateDbCommand();
				IList<Hashtable> tableListcnt = rtChk.Execute();

				BoSystemLog.logOut("SQL: " + rtChk.LogSql);

				if (tableListcnt == null || tableListcnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = tableListcnt[0];
					dCnt = (Decimal)resultTbl["CNT"];

					// 0件チェック
					if (dCnt <= 0)
					{
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						// 最大件数チェック
						V03004Check.MaxCountCheck(facadeContext.CommandInfo.FormId.ToUpper(), dCnt, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 検索処理

				// 発注MST_会社コードより検索する
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Th020p01Constant.SQL_ID_02, facadeContext.DBContext);

				// テーブルID設定
				BoSystemSql.AddSql(rtSeach, Th020p01Constant.REP_ADD_TABLE, tableId);

				// テーブル結合SQL作成
				this.AddJoin(f01VO, rtSeach);

				// 検索条件設定
				this.AddWhere(f01VO, rtSeach);

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				int iCnt = 0;

				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Th020f01M1Form f01m1VO = new Th020f01M1Form();
					f01m1VO.M1rowno = iCnt.ToString();													// Ｍ１行NO
					f01m1VO.M1bumon_cd = BoSystemFormat.formatBumonCd(rec["BUMON_CD"].ToString());		// Ｍ１部門コード
					f01m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();							// Ｍ１部門カナ名					
					f01m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();						// Ｍ１品種略名称
					f01m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();								// Ｍ１ブランド名
					f01m1VO.Dictionary[Th020p01Constant.DIC_M1JISYA_HBN] = rec["XEBIO_CD"].ToString();	// Ｍ１自社品番リンク
					f01m1VO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();						// Ｍ１商品属性
					f01m1VO.M1maker_hbn = rec["HIN_NBR"].ToString();									// Ｍ１メーカー品番
					f01m1VO.M1syonmk = rec["SYONMK"].ToString();										// Ｍ１商品名(カナ)
					f01m1VO.M1iro_nm = BoSystemString.Nvl(rec["IRO_NM"].ToString());					// Ｍ１色
					f01m1VO.M1tenzaiko_su = rec["JI_FREEZAIKO_SU"].ToString();							// Ｍ１店在庫数
					f01m1VO.M1zentenzaiko_su = rec["FREEZAIKO_SU"].ToString();							// Ｍ１全店在庫数
					f01m1VO.M1syoka_rtu = BoSystemString.Nvl(rec["SYOKART"].ToString(),"0.0");			// Ｍ１消化率

					// Dictionary
					f01m1VO.Dictionary.Add(Th020p01Constant.DIC_M1MAKERCOLOR_CD, BoSystemFormat.formatIroCd(rec["MAKERCOLOR_CD"].ToString()));	// 色コード
					f01m1VO.Dictionary.Add(Th020p01Constant.DIC_M1BUMON_NM, rec["BUMON_NM"].ToString());										// 部門名
					f01m1VO.Dictionary.Add(Th020p01Constant.DIC_M1HINSYU_CD, BoSystemFormat.formatIroCd(rec["HINSYU_CD"].ToString()));			// 品種コード
					f01m1VO.Dictionary.Add(Th020p01Constant.DIC_M1BURANDO_CD, BoSystemFormat.formatIroCd(rec["BURANDO_CD"].ToString()));		// ブランドコード

					//リストオブジェクトにM1Formを追加します。
					m1List.Add(f01m1VO, true);
				}

				// 選択モードNO設定
				f01VO.Stkmodeno = f01VO.Modeno;

				// 件数設定
				f01VO.Searchcnt = m1List.Count.ToString();

				// 在庫検索選択 X:自エリア店別、V:全店
				// Xの場合
				if (CheckCompanyCls.IsXebio())
				{
					// 会社コード
					String sCopCd = string.Empty;

					// 会社コードと検索条件が一致しない場合自エリア店別は選択不可
					switch (f01VO.Stkmodeno)
					{
						case BoSystemConstant.MODE_JISHAHINBAN:		// モード自社品番
							sCopCd = f01VO.Kaisya_cd;
							break;
						case BoSystemConstant.MODE_JISYAHBNFUKUSU:	// モード自社品番(複数)
							sCopCd = f01VO.Kaisya_cd2;
							break;
						case BoSystemConstant.MODE_SCANCD:			// モードスキャンコード
							sCopCd = f01VO.Kaisya_cd3;
							break;
						case BoSystemConstant.MODE_MAKERHBN:		// モードメーカー品番
							sCopCd = f01VO.Kaisya_cd4;
							break;
						default:
							sCopCd = string.Empty;
							break;
					}

					if (Convert.ToDecimal(BoSystemString.Nvl(logininfo.CopCd, "0")) != Convert.ToDecimal(BoSystemString.Nvl(sCopCd, "0")))
					{
						f01VO.Zaiko_serchstk = ConditionZaiko_serchstk.VALUE_ZAIKO_SERCHSTK3;
					}
					else
					{
						f01VO.Zaiko_serchstk = ConditionZaiko_serchstk.VALUE_ZAIKO_SERCHSTK2;
					}
				}
				// X以外の場合
				else
				{
					f01VO.Zaiko_serchstk = ConditionZaiko_serchstk.VALUE_ZAIKO_SERCHSTK3;
				}

				#endregion

				#region 検索条件をDictionaryに設定

				// 検索時のformVOを保持
				SearchConditionSaveCls.SearchConditionSave(f01VO);
				// 検索用
				f01VO.Dictionary[Th020p01Constant.DIC_AREA_CD] = sArea_cd;
				// 背景色変更用
				f01VO.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE] = sArea_cd;

				#endregion


			}
			catch (System.Exception ex)
			{

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

		#region ユーザー定義関数

		#region 検索条件設定
		/// <summary>
		/// AddWhere 検索条件設定
		/// </summary>
		/// <param name="Th020f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void AddWhere(Th020f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 会社コードと検索条件が一致しない場合自エリア店別は選択不可
			switch (f01VO.Modeno)
			{
				case BoSystemConstant.MODE_JISHAHINBAN:		// モード自社品番

					#region 自社品番検索

					String sOld_jisya_hbn_from = string.Empty;		// 自社品番FROM
					String sOld_jisya_hbn_to = string.Empty;		// 自社品番TO

					// 自社品番で検索
					if (f01VO.Old_jisya_hbn_from.Length == 8 || f01VO.Old_jisya_hbn_to.Length == 8)
					{
						// FROMが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from))
						{
							sOld_jisya_hbn_from = "00000000";
						}　
						else　
						{
							sOld_jisya_hbn_from = f01VO.Old_jisya_hbn_from;
						}

						// TOが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
						{
							sOld_jisya_hbn_to = "99999999";
						}
						else
						{
							sOld_jisya_hbn_to = f01VO.Old_jisya_hbn_to;
						}

						sRepSql.Append(" AND MDMT0130.XEBIO_CD BETWEEN :BIND_JISHAHIN_FROM AND :BIND_JISHAHIN_TO");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISHAHIN_FROM";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_from);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISHAHIN_TO";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_to);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}
					// 旧自社品番で検索
					else
					{

						// FROMが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from))
						{
							// 0000000000は除外する
							sOld_jisya_hbn_from = "0000000001";
						}
						else
						{
							sOld_jisya_hbn_from = f01VO.Old_jisya_hbn_from;
						}

						// TOが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
						{
							sOld_jisya_hbn_to = "9999999999";
						}
						else
						{
							sOld_jisya_hbn_to = f01VO.Old_jisya_hbn_to;
						}

						sRepSql.Append(" AND MDMT0130.XEBIO_CD IN (");
						sRepSql.Append(" SELECT	SUB.XEBIO_CD FROM MDMT0130_").Append(f01VO.Kaisya_cd.Substring(f01VO.Kaisya_cd.Length - 1, 1)).Append(" SUB ");
						sRepSql.Append(" WHERE	SUB.OLD_XEBIO_CD BETWEEN :BIND_JISHAHIN_FROM AND :BIND_JISHAHIN_TO");
						sRepSql.Append("	) ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISHAHIN_FROM";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_from);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JISHAHIN_TO";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_to);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
					}
					#endregion

					break;
				case BoSystemConstant.MODE_JISYAHBNFUKUSU:	// モード自社品番(複数)

					#region 自社品番(複数)検索

					String sjisya_hbn_1 = string.Empty;			// 自社品番1
					String sjisya_hbn_2 = string.Empty;			// 自社品番2
					String sjisya_hbn_3 = string.Empty;			// 自社品番3
					String sjisya_hbn_4 = string.Empty;			// 自社品番4
					String sjisya_hbn_5 = string.Empty;			// 自社品番5

					String sold_jisya_hbn_1 = string.Empty;		// 旧自社品番1
					String sold_jisya_hbn_2 = string.Empty;		// 旧自社品番2
					String sold_jisya_hbn_3 = string.Empty;		// 旧自社品番3
					String sold_jisya_hbn_4 = string.Empty;		// 旧自社品番4
					String sold_jisya_hbn_5 = string.Empty;		// 旧自社品番5

					// 自社品番 1
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
					{
						if (f01VO.Old_jisya_hbn.Length == 8)
						{
							sjisya_hbn_1 = f01VO.Old_jisya_hbn;
						}
						else
						{
							sold_jisya_hbn_1 = f01VO.Old_jisya_hbn;
						}
					}

					// 自社品番 2
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
					{
						if (f01VO.Old_jisya_hbn2.Length == 8)
						{
							sjisya_hbn_2 = f01VO.Old_jisya_hbn2;
						}
						else
						{
							sold_jisya_hbn_2 = f01VO.Old_jisya_hbn2;
						}
					}

					// 自社品番 3
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
					{
						if (f01VO.Old_jisya_hbn3.Length == 8)
						{
							sjisya_hbn_3 = f01VO.Old_jisya_hbn3;
						}
						else
						{
							sold_jisya_hbn_3 = f01VO.Old_jisya_hbn3;
						}
					}

					// 自社品番 4
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
					{
						if (f01VO.Old_jisya_hbn4.Length == 8)
						{
							sjisya_hbn_4 = f01VO.Old_jisya_hbn4;
						}
						else
						{
							sold_jisya_hbn_4 = f01VO.Old_jisya_hbn4;
						}
					}

					// 自社品番 5
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
					{
						if (f01VO.Old_jisya_hbn5.Length == 8)
						{
							sjisya_hbn_5 = f01VO.Old_jisya_hbn5;
						}
						else
						{
							sold_jisya_hbn_5 = f01VO.Old_jisya_hbn5;
						}
					}

					sRepSql.Append(" AND MDMT0130.XEBIO_CD IN ( ");
					sRepSql.Append(" 	SELECT :BIND_JISHAHIN_1 FROM DUAL UNION ALL ");
					sRepSql.Append(" 	SELECT :BIND_JISHAHIN_2 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_JISHAHIN_3 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_JISHAHIN_4 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_JISHAHIN_5 FROM DUAL UNION ALL ");
					sRepSql.Append("	(SELECT	SUB.XEBIO_CD ");
					sRepSql.Append("	FROM	MDMT0130_").Append(f01VO.Kaisya_cd2.Substring(f01VO.Kaisya_cd2.Length - 1, 1)).Append(" SUB ");
					sRepSql.Append("	WHERE	SUB.OLD_XEBIO_CD IN (:BIND_OLDJISHAHIN_1, :BIND_OLDJISHAHIN_2, :BIND_OLDJISHAHIN_3, :BIND_OLDJISHAHIN_4, :BIND_OLDJISHAHIN_5)) ");
					sRepSql.Append("	) ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISHAHIN_1";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sjisya_hbn_1);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISHAHIN_2";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sjisya_hbn_2);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISHAHIN_3";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sjisya_hbn_3);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISHAHIN_4";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sjisya_hbn_4);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JISHAHIN_5";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sjisya_hbn_5);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_OLDJISHAHIN_1";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_1);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_OLDJISHAHIN_2";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_2);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_OLDJISHAHIN_3";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_3);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_OLDJISHAHIN_4";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_4);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_OLDJISHAHIN_5";
					bindVO.Value = BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_5);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					#endregion

					break;

				case BoSystemConstant.MODE_SCANCD:			// モードスキャンコード

					#region スキャンコード検索

					String sScan_cd_from = string.Empty;		// スキャンコードFROM
					String sScan_cd_to = string.Empty;			// スキャンコードTO

					// JANで検索
					if ((f01VO.Scan_cd_from.Length == 8 || f01VO.Scan_cd_from.Length == 13)
						|| (f01VO.Scan_cd_to.Length == 8 || f01VO.Scan_cd_to.Length == 13))
					{
						// FROMが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Scan_cd_from))
						{
							sScan_cd_from = "0000000000000";
						}
						else
						{
							sScan_cd_from = f01VO.Scan_cd_from;
						}

						// TOが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Scan_cd_to))
						{
							sScan_cd_to = "9999999999999";
						}
						else
						{
							sScan_cd_to = f01VO.Scan_cd_to;
						}

						sRepSql.Append(" AND MDMT0130.XEBIO_CD IN (");
						sRepSql.Append(" SELECT	SUB.XEBIO_CD FROM MDMT0130_").Append(f01VO.Kaisya_cd3.Substring(f01VO.Kaisya_cd3.Length - 1, 1)).Append(" SUB ");
						sRepSql.Append(" WHERE	SUB.JAN_CD BETWEEN :BIND_JAN_CD_FROM AND :BIND_JAN_CD_TO");
						sRepSql.Append(" ) ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JAN_CD_FROM";
						bindVO.Value = BoSystemFormat.formatJanCd(sScan_cd_from);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JAN_CD_TO";
						bindVO.Value = BoSystemFormat.formatJanCd(sScan_cd_to);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

					}
					// 商品コードで検索
					else
					{
						// FROMが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Scan_cd_from))
						{
							sScan_cd_from = "000000000000000";
						}
						else
						{
							sScan_cd_from = BoSystemFormat.syohinCdGetSearch(f01VO.Scan_cd_from);
						}

						// TOが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Scan_cd_to))
						{
							sScan_cd_to = "9999999999999";
						}
						else
						{
							sScan_cd_to = BoSystemFormat.syohinCdGetSearch(f01VO.Scan_cd_to);
						}

						sRepSql.Append(" AND MDMT0130.XEBIO_CD IN (");
						sRepSql.Append(" SELECT	SUB.XEBIO_CD FROM MDMT0130_").Append(f01VO.Kaisya_cd3.Substring(f01VO.Kaisya_cd3.Length - 1, 1)).Append(" SUB ");
						sRepSql.Append(" WHERE	SUB.SYOHIN_CD_SERCH BETWEEN :BIND_JAN_CD_FROM AND :BIND_JAN_CD_TO");
						sRepSql.Append(" ) ");

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JAN_CD_FROM";
						bindVO.Value = sScan_cd_from;
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_JAN_CD_TO";
						bindVO.Value = sScan_cd_to;
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

					}

					#endregion

					break;

				case BoSystemConstant.MODE_MAKERHBN:		// モードメーカー品番

					#region メーカー品番検索

					sRepSql.Append(" AND MDMT0130.HIN_NBR = :BIND_MEKERHIN");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_MEKERHIN";
					bindVO.Value = BoSystemString.ChangeZenHankaku(f01VO.Maker_hbn, 1);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					#endregion

					break;

				default:
					break;

			} // switch
			BoSystemSql.AddSql(reader, Th020p01Constant.REP_ADD_WHERE, sRepSql.ToString(), bindList);
		}
		#endregion

		#region 結合条件設定
		/// <summary>
		/// AddJoin 結合条件設定
		/// </summary>
		/// <param name="Th020f01Form">f01VO</param>
		/// <param name="FindSqlResultTable">reader</param>
		/// <returns></returns>
		private void AddJoin(Th020f01Form f01VO, FindSqlResultTable reader)
		{
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			// 会社コード
			String sCopCd = string.Empty;
			// 店舗コード
			String sTenpo_Cd = string.Empty;

			switch (f01VO.Modeno)
			{
				case BoSystemConstant.MODE_JISHAHINBAN:		// モード自社品番
					sCopCd = f01VO.Kaisya_cd;
					break;
				case BoSystemConstant.MODE_JISYAHBNFUKUSU:	// モード自社品番(複数)
					sCopCd = f01VO.Kaisya_cd2;
					break;
				case BoSystemConstant.MODE_SCANCD:			// モードスキャンコード
					sCopCd = f01VO.Kaisya_cd3;
					break;
				case BoSystemConstant.MODE_MAKERHBN:		// モードメーカー品番
					sCopCd = f01VO.Kaisya_cd4;
					break;
				default:
					sCopCd = string.Empty;
					break;
			}

			sCopCd = Convert.ToDecimal(BoSystemString.Nvl(sCopCd, "0")).ToString();

			sTenpo_Cd = BoSystemFormat.formatTenpoCd(f01VO.Head_tenpo_cd);

			// 在庫抽出
			sRepSql.Append(" LEFT JOIN");
			sRepSql.Append(" ( ");
			sRepSql.Append(" SELECT JAN_CD, SUM(FREEZAIKO_SU) FREEZAIKO_SU, SUM(DECODE(TENPO_CD, :BIND_TENPO_CD_01, NVL(FREEZAIKO_SU, 0), 0)) JI_FREEZAIKO_SU , SUM(URIAGERUISEKI_SU) URIAGERUISEKI_SU");
			sRepSql.Append(" FROM (");

			//	店舗コード
			bindList.Add(new BindInfoVO("BIND_TENPO_CD_01", sTenpo_Cd, BoSystemSql.BINDTYPE_STRING));

			// 在庫抽出サブクエリ
			switch (f01VO.Modeno)
			{
				case BoSystemConstant.MODE_JISHAHINBAN:		// モード自社品番

					#region 自社品番検索

					String sOld_jisya_hbn_from = string.Empty;		// 自社品番FROM
					String sOld_jisya_hbn_to = string.Empty;		// 自社品番TO

					// 自社品番で検索
					if (f01VO.Old_jisya_hbn_from.Length == 8 || f01VO.Old_jisya_hbn_to.Length == 8)
					{

						// FROMが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from))
						{
							sOld_jisya_hbn_from = "00000000";
						}
						else
						{
							sOld_jisya_hbn_from = f01VO.Old_jisya_hbn_from;
						}

						// TOが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
						{
							sOld_jisya_hbn_to = "99999999";
						}
						else
						{
							sOld_jisya_hbn_to = f01VO.Old_jisya_hbn_to;
						}

						// 前日在庫テーブル 
						sRepSql.Append(" SELECT /*+ INDEX(MDBT0030 MDBT0030_INDEX5) */");
						sRepSql.Append("	MDBT0030.TENPO_CD ");
						sRepSql.Append("	,MDBT0030.JAN_CD ");
						sRepSql.Append("	,MDBT0030.FREEZAIKO_SU ");
						sRepSql.Append("	,MDBT0030.URIAGERUISEKI_SU ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0030_").Append(sCopCd).Append(" MDBT0030 ");
						sRepSql.Append(" WHERE JISYA_HBN BETWEEN :BIND_J_JISHAHIN_FROM_01 AND :BIND_J_JISHAHIN_TO_01");

						sRepSql.Append(" UNION ALL ");

						// 当日受払テーブル
						sRepSql.Append(" SELECT");
						sRepSql.Append("	MDBT0040.TENPO_CD ");
						sRepSql.Append("	,MDBT0040.JAN_CD ");
						sRepSql.Append("	,MDBT0040.FREEZAIKO_SU ");
						sRepSql.Append("	,0 ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0040_").Append(sCopCd).Append(" MDBT0040 ");
						sRepSql.Append(" WHERE JISYA_HBN BETWEEN :BIND_J_JISHAHIN_FROM_02 AND :BIND_J_JISHAHIN_TO_02");

						sRepSql.Append(" UNION ALL ");

						//// 受払履歴テーブル
						sRepSql.Append(" SELECT ");
						sRepSql.Append("	MDBT0060.TENPO_CD ");
						sRepSql.Append("	,MDBT0060.JAN_CD ");
						sRepSql.Append("	,MDBT0060.FREEZAIKO_SU ");
						sRepSql.Append("	,0 ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0060_").Append(sCopCd).Append(" MDBT0060 ");
						sRepSql.Append(" WHERE JISYA_HBN BETWEEN :BIND_J_JISHAHIN_FROM_03 AND :BIND_J_JISHAHIN_TO_03");

						// 自社品番FROM、自社品番TO
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_FROM_01", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_TO_01", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_to), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_FROM_02", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_TO_02", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_to), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_FROM_03", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_TO_03", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_to), BoSystemSql.BINDTYPE_STRING));
					}
					// 旧自社品番で検索
					else
					{
						// FROMが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_from))
						{
							// 0000000000は除外する
							sOld_jisya_hbn_from = "0000000001";
						}
						else
						{
							sOld_jisya_hbn_from = f01VO.Old_jisya_hbn_from;
						}

						// TOが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Old_jisya_hbn_to))
						{
							sOld_jisya_hbn_to = "9999999999";
						}
						else
						{
							sOld_jisya_hbn_to = f01VO.Old_jisya_hbn_to;
						}

						// 前日在庫テーブル 
						sRepSql.Append(" SELECT /*+ INDEX(MDBT0030 MDBT0030_INDEX5) */");
						sRepSql.Append("	MDBT0030.TENPO_CD ");
						sRepSql.Append("	,MDBT0030.JAN_CD ");
						sRepSql.Append("	,MDBT0030.FREEZAIKO_SU ");
						sRepSql.Append("	,MDBT0030.URIAGERUISEKI_SU ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0030_").Append(sCopCd).Append(" MDBT0030 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE OLD_XEBIO_CD BETWEEN :BIND_J_JISHAHIN_FROM_01 AND :BIND_J_JISHAHIN_TO_01)");

						sRepSql.Append(" UNION ALL ");

						// 当日受払テーブル
						sRepSql.Append(" SELECT ");
						sRepSql.Append("	MDBT0040.TENPO_CD ");
						sRepSql.Append("	,MDBT0040.JAN_CD ");
						sRepSql.Append("	,MDBT0040.FREEZAIKO_SU ");
						sRepSql.Append("	,0 ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0040_").Append(sCopCd).Append(" MDBT0040 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE OLD_XEBIO_CD BETWEEN :BIND_J_JISHAHIN_FROM_02 AND :BIND_J_JISHAHIN_TO_02)");

						sRepSql.Append(" UNION ALL ");

						// 受払履歴テーブル
						sRepSql.Append(" SELECT ");
						sRepSql.Append("	MDBT0060.TENPO_CD ");
						sRepSql.Append("	,MDBT0060.JAN_CD ");
						sRepSql.Append("	,MDBT0060.FREEZAIKO_SU ");
						sRepSql.Append("	,0 ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0060_").Append(sCopCd).Append(" MDBT0060 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE OLD_XEBIO_CD BETWEEN :BIND_J_JISHAHIN_FROM_03 AND :BIND_J_JISHAHIN_TO_03)");

						// 自社品番FROM、自社品番TO
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_FROM_01", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_TO_01", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_to), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_FROM_02", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_TO_02", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_to), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_FROM_03", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_TO_03", BoSystemFormat.formatJisyaHbn(sOld_jisya_hbn_to), BoSystemSql.BINDTYPE_STRING));

					}

					#endregion

					break;
				case BoSystemConstant.MODE_JISYAHBNFUKUSU:	// モード自社品番(複数)

					#region 自社品番(複数)検索

					String sjisya_hbn_1 = string.Empty;			// 自社品番1
					String sjisya_hbn_2 = string.Empty;			// 自社品番2
					String sjisya_hbn_3 = string.Empty;			// 自社品番3
					String sjisya_hbn_4 = string.Empty;			// 自社品番4
					String sjisya_hbn_5 = string.Empty;			// 自社品番5

					String sold_jisya_hbn_1 = string.Empty;		// 旧自社品番1
					String sold_jisya_hbn_2 = string.Empty;		// 旧自社品番2
					String sold_jisya_hbn_3 = string.Empty;		// 旧自社品番3
					String sold_jisya_hbn_4 = string.Empty;		// 旧自社品番4
					String sold_jisya_hbn_5 = string.Empty;		// 旧自社品番5

					// 自社品番 1
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn))
					{
						if (f01VO.Old_jisya_hbn.Length == 8)
						{
							sjisya_hbn_1 = f01VO.Old_jisya_hbn;
						}
						else
						{
							sold_jisya_hbn_1 = f01VO.Old_jisya_hbn;
						}
					}

					// 自社品番 2
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn2))
					{
						if (f01VO.Old_jisya_hbn2.Length == 8)
						{
							sjisya_hbn_2 = f01VO.Old_jisya_hbn2;
						}
						else
						{
							sold_jisya_hbn_2 = f01VO.Old_jisya_hbn2;
						}
					}

					// 自社品番 3
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn3))
					{
						if (f01VO.Old_jisya_hbn3.Length == 8)
						{
							sjisya_hbn_3 = f01VO.Old_jisya_hbn3;
						}
						else
						{
							sold_jisya_hbn_3 = f01VO.Old_jisya_hbn3;
						}
					}

					// 自社品番 4
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn4))
					{
						if (f01VO.Old_jisya_hbn4.Length == 8)
						{
							sjisya_hbn_4 = f01VO.Old_jisya_hbn4;
						}
						else
						{
							sold_jisya_hbn_4 = f01VO.Old_jisya_hbn4;
						}
					}

					// 自社品番 5
					if (!string.IsNullOrEmpty(f01VO.Old_jisya_hbn5))
					{
						if (f01VO.Old_jisya_hbn5.Length == 8)
						{
							sjisya_hbn_5 = f01VO.Old_jisya_hbn5;
						}
						else
						{
							sold_jisya_hbn_5 = f01VO.Old_jisya_hbn5;
						}
					}

					// 前日在庫テーブル 
					sRepSql.Append(" SELECT /*+ INDEX(MDBT0030 MDBT0030_INDEX5) */");
					sRepSql.Append("	MDBT0030.TENPO_CD ");
					sRepSql.Append("	,MDBT0030.JAN_CD ");
					sRepSql.Append("	,MDBT0030.FREEZAIKO_SU ");
					sRepSql.Append("	,MDBT0030.URIAGERUISEKI_SU ");
					sRepSql.Append(" FROM ");
					sRepSql.Append("	 MDBT0030_").Append(sCopCd).Append(" MDBT0030 ");
					sRepSql.Append(" WHERE JISYA_HBN IN  ( ");
					sRepSql.Append(" 	SELECT :BIND_J_JISHAHIN_01 FROM DUAL UNION ALL ");
					sRepSql.Append(" 	SELECT :BIND_J_JISHAHIN_02 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_03 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_04 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_05 FROM DUAL UNION ALL ");
					sRepSql.Append("	(SELECT	XEBIO_CD ");
					sRepSql.Append("	FROM	MDMT0130_").Append(sCopCd);
					sRepSql.Append("	WHERE	OLD_XEBIO_CD IN (:BIND_J_OLDJISHAHIN_01, :BIND_J_OLDJISHAHIN_02, :BIND_J_OLDJISHAHIN_03, :BIND_J_OLDJISHAHIN_04, :BIND_J_OLDJISHAHIN_05)) ");
					sRepSql.Append("	) ");

					// 自社品番1～5
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_01", BoSystemFormat.formatJisyaHbn(sjisya_hbn_1), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_02", BoSystemFormat.formatJisyaHbn(sjisya_hbn_2), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_03", BoSystemFormat.formatJisyaHbn(sjisya_hbn_3), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_04", BoSystemFormat.formatJisyaHbn(sjisya_hbn_4), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_05", BoSystemFormat.formatJisyaHbn(sjisya_hbn_5), BoSystemSql.BINDTYPE_STRING));

					// 旧自社品番1～5
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_01", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_1), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_02", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_2), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_03", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_3), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_04", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_4), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_05", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_5), BoSystemSql.BINDTYPE_STRING));

					sRepSql.Append(" UNION ALL ");

					// 当日受払テーブル
					sRepSql.Append(" SELECT ");
					sRepSql.Append("	MDBT0040.TENPO_CD ");
					sRepSql.Append("	,MDBT0040.JAN_CD ");
					sRepSql.Append("	,MDBT0040.FREEZAIKO_SU ");
					sRepSql.Append("	,0 ");
					sRepSql.Append(" FROM ");
					sRepSql.Append("	 MDBT0040_").Append(sCopCd).Append(" MDBT0040 ");
					sRepSql.Append(" WHERE JISYA_HBN IN  ( ");
					sRepSql.Append(" 	SELECT :BIND_J_JISHAHIN_06 FROM DUAL UNION ALL ");
					sRepSql.Append(" 	SELECT :BIND_J_JISHAHIN_07 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_08 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_09 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_10 FROM DUAL UNION ALL ");
					sRepSql.Append("	(SELECT	XEBIO_CD ");
					sRepSql.Append("	FROM	MDMT0130_").Append(sCopCd);
					sRepSql.Append("	WHERE	OLD_XEBIO_CD IN (:BIND_J_OLDJISHAHIN_06, :BIND_J_OLDJISHAHIN_07, :BIND_J_OLDJISHAHIN_08, :BIND_J_OLDJISHAHIN_09, :BIND_J_OLDJISHAHIN_10)) ");
					sRepSql.Append("	) ");

					// 自社品番6～10
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_06", BoSystemFormat.formatJisyaHbn(sjisya_hbn_1), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_07", BoSystemFormat.formatJisyaHbn(sjisya_hbn_2), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_08", BoSystemFormat.formatJisyaHbn(sjisya_hbn_3), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_09", BoSystemFormat.formatJisyaHbn(sjisya_hbn_4), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_10", BoSystemFormat.formatJisyaHbn(sjisya_hbn_5), BoSystemSql.BINDTYPE_STRING));

					// 旧自社品番6～10
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_06", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_1), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_07", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_2), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_08", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_3), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_09", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_4), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_10", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_5), BoSystemSql.BINDTYPE_STRING));

					sRepSql.Append(" UNION ALL ");

					// 受払履歴テーブル
					sRepSql.Append(" SELECT ");
					sRepSql.Append("	MDBT0060.TENPO_CD ");
					sRepSql.Append("	,MDBT0060.JAN_CD ");
					sRepSql.Append("	,MDBT0060.FREEZAIKO_SU ");
					sRepSql.Append("	,0 ");
					sRepSql.Append(" FROM ");
					sRepSql.Append("	 MDBT0060_").Append(sCopCd).Append(" MDBT0060 ");
					sRepSql.Append(" WHERE JISYA_HBN IN  ( ");
					sRepSql.Append(" 	SELECT :BIND_J_JISHAHIN_11 FROM DUAL UNION ALL ");
					sRepSql.Append(" 	SELECT :BIND_J_JISHAHIN_12 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_13 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_14 FROM DUAL UNION ALL ");
					sRepSql.Append("	SELECT :BIND_J_JISHAHIN_15 FROM DUAL UNION ALL ");
					sRepSql.Append("	(SELECT	XEBIO_CD ");
					sRepSql.Append("	FROM	MDMT0130_").Append(sCopCd);
					sRepSql.Append("	WHERE	OLD_XEBIO_CD IN (:BIND_J_OLDJISHAHIN_11, :BIND_J_OLDJISHAHIN_12, :BIND_J_OLDJISHAHIN_13, :BIND_J_OLDJISHAHIN_14, :BIND_J_OLDJISHAHIN_15)) ");
					sRepSql.Append("	) ");

					// 自社品番11～15
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_11", BoSystemFormat.formatJisyaHbn(sjisya_hbn_1), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_12", BoSystemFormat.formatJisyaHbn(sjisya_hbn_2), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_13", BoSystemFormat.formatJisyaHbn(sjisya_hbn_3), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_14", BoSystemFormat.formatJisyaHbn(sjisya_hbn_4), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_JISHAHIN_15", BoSystemFormat.formatJisyaHbn(sjisya_hbn_5), BoSystemSql.BINDTYPE_STRING));

					// 旧自社品番11～15
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_11", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_1), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_12", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_2), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_13", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_3), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_14", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_4), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_OLDJISHAHIN_15", BoSystemFormat.formatJisyaHbn(sold_jisya_hbn_5), BoSystemSql.BINDTYPE_STRING));

					#endregion

					break;
				case BoSystemConstant.MODE_SCANCD:			// モードスキャンコード

					#region スキャンコード検索

					String sScan_cd_from = string.Empty;		// スキャンコードFROM
					String sScan_cd_to = string.Empty;			// スキャンコードTO

					// JANで検索
					if ((f01VO.Scan_cd_from.Length == 8 || f01VO.Scan_cd_from.Length == 13)
						|| (f01VO.Scan_cd_to.Length == 8 || f01VO.Scan_cd_to.Length == 13))
					{

						// FROMが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Scan_cd_from))
						{
							sScan_cd_from = "0000000000000";
						}
						else
						{
							sScan_cd_from = f01VO.Scan_cd_from;
						}

						// TOが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Scan_cd_to))
						{
							sScan_cd_to = "9999999999999";
						}
						else
						{
							sScan_cd_to = f01VO.Scan_cd_to;
						}

						// 前日在庫テーブル 
						sRepSql.Append(" SELECT /*+ INDEX(MDBT0030 MDBT0030_INDEX5) */");
						sRepSql.Append("	MDBT0030.TENPO_CD ");
						sRepSql.Append("	,MDBT0030.JAN_CD ");
						sRepSql.Append("	,MDBT0030.FREEZAIKO_SU ");
						sRepSql.Append("	,MDBT0030.URIAGERUISEKI_SU ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0030_").Append(sCopCd).Append(" MDBT0030 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE JAN_CD BETWEEN :BIND_J_SCAN_CD_FROM_01 AND :BIND_J_SCAN_CD_TO_01)");

						sRepSql.Append(" UNION ALL ");

						// 当日受払テーブル
						sRepSql.Append(" SELECT ");
						sRepSql.Append("	MDBT0040.TENPO_CD ");
						sRepSql.Append("	,MDBT0040.JAN_CD ");
						sRepSql.Append("	,MDBT0040.FREEZAIKO_SU ");
						sRepSql.Append("	,0 ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0040_").Append(sCopCd).Append(" MDBT0040 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE JAN_CD BETWEEN :BIND_J_SCAN_CD_FROM_02 AND :BIND_J_SCAN_CD_TO_02)");

						sRepSql.Append(" UNION ALL ");

						// 受払履歴テーブル
						sRepSql.Append(" SELECT ");
						sRepSql.Append("	MDBT0060.TENPO_CD ");
						sRepSql.Append("	,MDBT0060.JAN_CD ");
						sRepSql.Append("	,MDBT0060.FREEZAIKO_SU ");
						sRepSql.Append("	,0 ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0060_").Append(sCopCd).Append(" MDBT0060 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE JAN_CD BETWEEN :BIND_J_SCAN_CD_FROM_03 AND :BIND_J_SCAN_CD_TO_03)");

						// スキャンコードFROMTO
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_FROM_01", BoSystemFormat.formatJanCd(sScan_cd_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_TO_01", BoSystemFormat.formatJanCd(sScan_cd_to), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_FROM_02", BoSystemFormat.formatJanCd(sScan_cd_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_TO_02", BoSystemFormat.formatJanCd(sScan_cd_to), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_FROM_03", BoSystemFormat.formatJanCd(sScan_cd_from), BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_TO_03", BoSystemFormat.formatJanCd(sScan_cd_to), BoSystemSql.BINDTYPE_STRING));

					}
					// 商品コードで検索
					else
					{
						// FROMが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Scan_cd_from))
						{
							sScan_cd_from = "000000000000000";
						}
						else
						{
							sScan_cd_from = BoSystemFormat.syohinCdGetSearch(f01VO.Scan_cd_from);
						}

						// TOが空の場合、最小値設定
						if (string.IsNullOrEmpty(f01VO.Scan_cd_to))
						{
							sScan_cd_to = "9999999999999";
						}
						else
						{
							sScan_cd_to = BoSystemFormat.syohinCdGetSearch(f01VO.Scan_cd_to);
						}

						// 前日在庫テーブル 
						sRepSql.Append(" SELECT /*+ INDEX(MDBT0030 MDBT0030_INDEX5) */");
						sRepSql.Append("	MDBT0030.TENPO_CD ");
						sRepSql.Append("	,MDBT0030.JAN_CD ");
						sRepSql.Append("	,MDBT0030.FREEZAIKO_SU ");
						sRepSql.Append("	,MDBT0030.URIAGERUISEKI_SU ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0030_").Append(sCopCd).Append(" MDBT0030 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE SYOHIN_CD_SERCH BETWEEN :BIND_J_SCAN_CD_FROM_01 AND :BIND_J_SCAN_CD_TO_01)");

						sRepSql.Append(" UNION ALL ");

						// 当日受払テーブル
						sRepSql.Append(" SELECT ");
						sRepSql.Append("	MDBT0040.TENPO_CD ");
						sRepSql.Append("	,MDBT0040.JAN_CD ");
						sRepSql.Append("	,MDBT0040.FREEZAIKO_SU ");
						sRepSql.Append("	,0 ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0040_").Append(sCopCd).Append(" MDBT0040 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE SYOHIN_CD_SERCH BETWEEN :BIND_J_SCAN_CD_FROM_02 AND :BIND_J_SCAN_CD_TO_02)");

						sRepSql.Append(" UNION ALL ");

						// 受払履歴テーブル
						sRepSql.Append(" SELECT ");
						sRepSql.Append("	MDBT0060.TENPO_CD ");
						sRepSql.Append("	,MDBT0060.JAN_CD ");
						sRepSql.Append("	,MDBT0060.FREEZAIKO_SU ");
						sRepSql.Append("	,0 ");
						sRepSql.Append(" FROM ");
						sRepSql.Append("	 MDBT0060_").Append(sCopCd).Append(" MDBT0060 ");
						sRepSql.Append(" WHERE JISYA_HBN IN (SELECT XEBIO_CD FROM MDMT0130 WHERE SYOHIN_CD_SERCH BETWEEN :BIND_J_SCAN_CD_FROM_03 AND :BIND_J_SCAN_CD_TO_03)");

						// スキャンコードFROMTO
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_FROM_01", sScan_cd_from, BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_TO_01", sScan_cd_to, BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_FROM_02", sScan_cd_from, BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_TO_02", sScan_cd_to, BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_FROM_03", sScan_cd_from, BoSystemSql.BINDTYPE_STRING));
						bindList.Add(new BindInfoVO("BIND_J_SCAN_CD_TO_03", sScan_cd_to, BoSystemSql.BINDTYPE_STRING));
					}


					#endregion

					break;
				case BoSystemConstant.MODE_MAKERHBN:		// モードメーカー品番

					#region メーカー品番検索

					// 前日在庫テーブル 
					sRepSql.Append(" SELECT /*+ INDEX(MDBT0030 MDBT0030_INDEX4) */");
					sRepSql.Append("	MDBT0030.TENPO_CD ");
					sRepSql.Append("	,MDBT0030.JAN_CD ");
					sRepSql.Append("	,MDBT0030.FREEZAIKO_SU ");
					sRepSql.Append("	,MDBT0030.URIAGERUISEKI_SU ");
					sRepSql.Append(" FROM ");
					sRepSql.Append("	 MDBT0030_").Append(sCopCd).Append(" MDBT0030 ");
					sRepSql.Append(" WHERE MDBT0030.MAKER_HBN = :BIND_J_MEKERHIN_01");

					sRepSql.Append(" UNION ALL ");

					// 当日受払テーブル
					sRepSql.Append(" SELECT ");
					sRepSql.Append("	MDBT0040.TENPO_CD ");
					sRepSql.Append("	,MDBT0040.JAN_CD ");
					sRepSql.Append("	,MDBT0040.FREEZAIKO_SU ");
					sRepSql.Append("	,0 ");
					sRepSql.Append(" FROM ");
					sRepSql.Append("	 MDBT0040_").Append(sCopCd).Append(" MDBT0040 ");
					sRepSql.Append(" WHERE MDBT0040.MAKER_HBN = :BIND_J_MEKERHIN_02");

					sRepSql.Append(" UNION ALL ");

					// 受払履歴テーブル
					sRepSql.Append(" SELECT ");
					sRepSql.Append("	MDBT0060.TENPO_CD ");
					sRepSql.Append("	,MDBT0060.JAN_CD ");
					sRepSql.Append("	,MDBT0060.FREEZAIKO_SU ");
					sRepSql.Append("	,0 ");
					sRepSql.Append(" FROM ");
					sRepSql.Append("	 MDBT0060_").Append(sCopCd).Append(" MDBT0060 ");
					sRepSql.Append(" WHERE MDBT0060.MAKER_HBN = :BIND_J_MEKERHIN_03");

					// メーカー品番
					bindList.Add(new BindInfoVO("BIND_J_MEKERHIN_01", BoSystemString.ChangeZenHankaku(f01VO.Maker_hbn, 1), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_MEKERHIN_02", BoSystemString.ChangeZenHankaku(f01VO.Maker_hbn, 1), BoSystemSql.BINDTYPE_STRING));
					bindList.Add(new BindInfoVO("BIND_J_MEKERHIN_03", BoSystemString.ChangeZenHankaku(f01VO.Maker_hbn, 1), BoSystemSql.BINDTYPE_STRING));

					#endregion

					break;
				default:

					break;
			}

			sRepSql.Append(" ) GROUP BY JAN_CD ");
			sRepSql.Append(" ) ZAIKO");	// 在庫抽出クエリ
			sRepSql.Append(" ON    MDMT0130.JAN_CD = ZAIKO.JAN_CD");	// 在庫抽出クエリ

			// 部門MST
			sRepSql.Append(" LEFT JOIN");
			sRepSql.Append(" BOMT0060_").Append(sCopCd).Append(" BOMT0060 ");
			sRepSql.Append(" ON    MDMT0130.BUMON_CD = BOMT0060.BUMON_CD");

			// 品種MST
			sRepSql.Append(" LEFT JOIN");
			sRepSql.Append(" MDMT0070_").Append(sCopCd).Append(" MDMT0070 ");
			sRepSql.Append(" ON    MDMT0130.BUMON_CD  = MDMT0070.BUMON_CD");
			sRepSql.Append(" AND   MDMT0130.HINSYU_CD = MDMT0070.HINSYU_CD");

			// ブランドMST
			sRepSql.Append(" LEFT JOIN");
			sRepSql.Append(" STMT0500_").Append(sCopCd).Append(" STMT0500 ");
			sRepSql.Append(" ON    MDMT0130.BURANDO_CD = STMT0500.BURANDO_CD");

			// 色MST
			sRepSql.Append(" LEFT JOIN");
			sRepSql.Append(" MDMT0080_").Append(sCopCd).Append(" MDMT0080 ");
			sRepSql.Append(" ON    MDMT0130.MAKERCOLOR_CD = MDMT0080.IRO_CD");

			BoSystemSql.AddSql(reader, Th020p01Constant.REP_ADD_JOIN, sRepSql.ToString(), bindList);

		}

		#endregion

		#endregion

	}
}
