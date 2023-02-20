using com.xebio.bo.Th010p01.Constant;
using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03004;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Th010p01.Facade
{
  /// <summary>
  /// Th010f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th010f02Facade : StandardBaseFacade
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
				// FormVO取得
				// 画面より情報を取得する。
				Th010f02Form prevVo = (Th010f02Form)facadeContext.FormVO;
				Th010f03Form nextVo = (Th010f03Form)facadeContext.GetUserObject(Th010p01Constant.FCDUO_NEXTVO_03);

				IDataList prevM1List = prevVo.GetList("M1");

				// 一覧の初期化
				prevM1List.ClearCacheData();
				prevM1List.Clear();

				//検索条件のDictionaryを初期化
				prevVo.Dictionary.Clear();
				#endregion

				#region 検索処理

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();

				StringBuilder sRepHint = new StringBuilder();
				StringBuilder sRepSqlOeder = new StringBuilder();

				SearchHachuVO searchVO = new SearchHachuVO();


				//共通部品[C01012]_パラメータ
				SearchHachuVO HinnbrVO2 = new SearchHachuVO(
									"3",					// JANフラグ
									prevVo.Head_tenpo_cd,	// 店舗コード
									1,						// 店別単価マスタ検索フラグ
									0,						// 売変検索フラグ
									0,						// 店在庫検索フラグ
									0,						// 入荷予定数検索フラグ
									0,						// 売上実績数検索フラグ
									0,						// 依頼集計数(補充)検索フラグ
									0,						// 依頼集計数(単品)検索フラグ
									0,						// ヒント文
									"",						// 指示数
									"",						// 出荷会社コード
									"",						// 入荷会社コード
									""						// 指示店舗コード
				);
				searchVO = HinnbrVO2;

				#region 抽出条件設定・バインド設定

				// 仕入先コード
				sRepSql.Append(" AND	SYOHIN.SIIRESAKI_CD = :BIND_SIIRESAKI_CD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_SIIRESAKI_CD";
				bindVO.Value = BoSystemFormat.formatSiiresakiCd(prevVo.Siiresaki_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				//ブランドコード
				sRepSql.Append(" AND	SYOHIN.BURANDO_CD = :BIND_BURANDO_CD ");

				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BURANDO_CD";
				bindVO.Value = BoSystemFormat.formatBrandCd(prevVo.Burando_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);


				//メーカー品番
				if (!string.IsNullOrEmpty(prevVo.Maker_hbn))
				{
					sRepSql.Append(" AND	SYOHIN.HIN_NBR	LIKE :BIND_HIN_NBR ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_HIN_NBR";
					bindVO.Value = "%" + BoSystemString.ChangeZenHankaku(prevVo.Maker_hbn, 1) + "%";
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 原価
				if (prevVo.Genka_flg.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					sRepSql.Append(" AND	SYOHIN.GENKA = :BIND_GENBAIKA ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_GENBAIKA";
					bindVO.Value = prevVo.Genka;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// 現売価
				if (prevVo.Genbaika_flg.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					sRepSql.Append(" AND	SYOHIN.SLPR = :BIND_SLPR ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SLPR";
					bindVO.Value = prevVo.Genbaika_tnk;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				// メーカー価格
				if (prevVo.Makerkakaku_flg.Equals(BoSystemConstant.CHECKBOX_ON))
				{
					sRepSql.Append(" AND	SYOHIN.JODAI2_TNK = :BIND_JODAI2_TNK ");

					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_JODAI2_TNK";
					bindVO.Value = prevVo.Makerkakaku_tnk;
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}

				//削除フラグ
				sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
				#endregion

				#region ソート条件設定
				sRepSqlOeder.Append(" ORDER BY ");
				sRepSqlOeder.Append("  SIIRESAKI_CD ");
				sRepSqlOeder.Append(" ,BUMON_CD ");
				sRepSqlOeder.Append(" ,BURANDO_CD ");
				sRepSqlOeder.Append(" ,XEBIO_CD ");
				#endregion

				// 発注MST検索(件数取得)
				IList<Hashtable> GetHachuMstCnt = SearchHachu.SearchHachuMst(searchVO
									, facadeContext.DBContext
									, 4
									, sRepSql
									, bindList
									, sRepHint.ToString()
									, sRepSqlOeder.ToString()
									, 1
									);
				
				#region 件数チェック
				Decimal dCnt = 0;
				if (GetHachuMstCnt == null || GetHachuMstCnt.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}
				else
				{
					Hashtable resultTbl = GetHachuMstCnt[0];
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

				// 検索件数の設定
				prevVo.Searchcnt = dCnt.ToString();

				#endregion

				#region 検索結果を取得
				// 発注MST検索
				IList<Hashtable> GetHachuMst = SearchHachu.SearchHachuMst(searchVO
									, facadeContext.DBContext
									, 4
									, sRepSql
									, bindList
									, sRepHint.ToString()
									, sRepSqlOeder.ToString()
									);

				int iCnt = 0;
				foreach (Hashtable rec in GetHachuMst)
				{
					iCnt++;
					Th010f02M1Form f01m2VO = new Th010f02M1Form();

					f01m2VO.M1rowno = iCnt.ToString();										// Ｍ１行NO
					f01m2VO.M1siiresaki_cd = rec["SIIRESAKI_CD"].ToString();				// Ｍ１仕入先コード
					f01m2VO.M1siiresaki_ryaku_nm = rec["SIIRESAKI_RYAKU_NM"].ToString();	// Ｍ１仕入先名称
					f01m2VO.M1bumon_cd = rec["BUMON_CD"].ToString();						// Ｍ１部門コード
					f01m2VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();				// Ｍ１部門カナ名
					f01m2VO.M1hinsyu_cd = rec["HINSYU_CD"].ToString();						// Ｍ１品種コード
					f01m2VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();			// Ｍ１品種略名称
					f01m2VO.M1burando_nm = rec["BURANDO_NMK"].ToString();					// Ｍ１ブランド名
					
					// Ｍ１自社品番リンク
					// Ｍ１旧自社品番リンク

					f01m2VO.M1syohin_zokusei = rec["SYOHIN_ZOKUSEI"].ToString();			// Ｍ１商品属性
					f01m2VO.M1maker_hbn = rec["HIN_NBR"].ToString();						// Ｍ１メーカー品番
					f01m2VO.M1syonmk = rec["SYONMK"].ToString();							// Ｍ１商品名(カナ)
					f01m2VO.M1iro_nm = rec["IRO_NM"].ToString();							// Ｍ１色
					f01m2VO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();		// Ｍ１販売完了日
					f01m2VO.M1saisinbaika_tnk = rec["BAIKA"].ToString();					// Ｍ１最新売価
					f01m2VO.M1genka = rec["GENKA"].ToString();								// Ｍ１原価
					f01m2VO.M1genbaika_tnk = rec["SLPR"].ToString();						// Ｍ１現売価
					f01m2VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;				// Ｍ１選択フラグ(隠し)
					f01m2VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;			// Ｍ１確定処理フラグ(隠し)
					f01m2VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;				// Ｍ１明細色区分(隠し)
					f01m2VO.M1makerkakaku_tnk = rec["JODAI2_TNK"].ToString();				// Ｍ１メーカー価格


					//Dictionary
					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_M1XEBIO_CD, rec["XEBIO_CD"].ToString());
					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_M1OLD_XEBIO_CD, rec["OLD_XEBIO_CD"].ToString());

					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_M1TENKAI_KB, rec["TENKAI_KB"].ToString());			// Ｍ１展開区分
					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_M1BURANDO_CD, rec["BURANDO_CD"].ToString());		// Ｍ１ブランドコード
					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_M1MAKERCOLOR_CD, rec["MAKERCOLOR_CD"].ToString());	// Ｍ１色コード

					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_BUMON_NM, rec["BUMON_NM"].ToString());							// 部門名
					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_M1ITEMKBN, rec["ITEMKBN"].ToString());							// Ｍ１商品区分
					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_M1SIIRE_KB, rec["SIIRE_KB"].ToString());						// Ｍ１仕入区分
					f01m2VO.Dictionary.Add(Th010p01Constant.DIC_M1TYOTATSU_KB, rec["TYOTATSU_KB"].ToString());					// Ｍ１調達区分

					//リストオブジェクトにM1Formを追加します。
					prevM1List.Add(f01m2VO, true);
				}
				#endregion

				// 商品マスタ検索選択を「サイズ別／プライス」へ設定
				prevVo.Syohinmst_serchstk = ConditionSyohinmst_serchstk2.VALUE_SYOHINMST_SERCHSTK13;

				// 検索条件を退避
				SearchConditionSaveCls.SearchConditionSave(prevVo);

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
	}
}
