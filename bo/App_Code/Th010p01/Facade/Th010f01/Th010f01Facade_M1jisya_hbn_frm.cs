using com.xebio.bo.Th010p01.Constant;
using com.xebio.bo.Th010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C02000.C02002;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.SqlUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Th010p01.Facade
{
  /// <summary>
  /// Th010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th010f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1jisya_hbn)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1jisya_hbn)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1JISYA_HBN_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1JISYA_HBN_FRM");

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

				// FormVO取得
				// 画面より情報を取得する。
				Th010f01Form prevVo = (Th010f01Form)facadeContext.FormVO;
				Th010f02Form nextVo02 = (Th010f02Form)facadeContext.GetUserObject(Th010p01Constant.FCDUO_NEXTVO_02);
				Th010f03Form nextVo03 = (Th010f03Form)facadeContext.GetUserObject(Th010p01Constant.FCDUO_NEXTVO_03);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List02 = nextVo02.GetList("M1");
				IDataList nextM1List03 = nextVo03.GetList("M1");

				// 選択行の情報を取得する。
				Th010f01M1Form prevM1Vo = (Th010f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List02.ClearCacheData();
				nextM1List02.Clear();

				nextM1List03.ClearCacheData();
				nextM1List03.Clear();
				#endregion

				#region 検索処理

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();

				StringBuilder sRepHint = new StringBuilder();
				StringBuilder sRepSqlOeder = new StringBuilder();

				SearchHachuVO searchVO = new SearchHachuVO();

				// [商品マスタ検索選択]が「サイズ別／プライス」の場合
				if (prevVo.Syohinmst_serchstk.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK13))
				{
					// Dictionary.[Ｍ１展開区分]が2の場合
					if (prevM1Vo.Dictionary[Th010p01Constant.DIC_M1TENKAI_KB].ToString().Equals("2"))
					{
						//共通部品[C01012]_パラメータ
						SearchHachuVO TenkaiKbEq2VO = new SearchHachuVO(
											"1",					// JANフラグ
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
						searchVO = TenkaiKbEq2VO;

						#region 抽出条件設定
						sRepSql.Append(" AND	SYOHIN.XEBIO_CD = :BIND_XEBIO_CD ");
						sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
						#endregion

						#region バインド設定
						// [Ｍ１自社品番]
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_XEBIO_CD";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(prevM1Vo.Dictionary[Th010p01Constant.DIC_M1XEBIO_CD].ToString());
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion

						#region ソート条件設定
						sRepSqlOeder.Append(" ORDER BY ");
						sRepSqlOeder.Append("  DECODE(TENKAI_KB, 1, SIZE_CD, MAKERCOLOR_CD) ");
						#endregion
					}

					// Dictionary.[Ｍ１展開区分]が2以外の場合
					else
					{
						//共通部品[C01012]_パラメータ
						SearchHachuVO TenkaiKbNotEq2VO = new SearchHachuVO(
											"1",					// JANフラグ
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
						searchVO = TenkaiKbNotEq2VO;

						#region 抽出条件設定
						sRepSql.Append(" AND	SYOHIN.XEBIO_CD = :BIND_XEBIO_CD ");
						sRepSql.Append(" AND	SYOHIN.MAKERCOLOR_CD = :BIND_MAKERCOLOR_CD ");
						sRepSql.Append(" AND	SYOHIN.SAKUJYO_FLG = 0 ");
						#endregion

						#region バインド設定
						// [Ｍ１自社品番]
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_XEBIO_CD";
						bindVO.Value = BoSystemFormat.formatJisyaHbn(prevM1Vo.Dictionary[Th010p01Constant.DIC_M1XEBIO_CD].ToString());
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 対象行.Dictionary[色コード]
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_MAKERCOLOR_CD";
						bindVO.Value = BoSystemFormat.formatIroCd(prevM1Vo.Dictionary[Th010p01Constant.DIC_M1MAKERCOLOR_CD].ToString());
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);
						#endregion

						#region ソート条件設定
						sRepSqlOeder.Append(" ORDER BY ");
						sRepSqlOeder.Append("  DECODE(TENKAI_KB, 1, SIZE_CD, MAKERCOLOR_CD) ");
						#endregion
					}

					// 発注MST検索
					IList<Hashtable> GetHachuMst = SearchHachu.SearchHachuMst(searchVO
																, facadeContext.DBContext
																, 1
																, sRepSql
																, bindList
																, sRepHint.ToString()
																, sRepSqlOeder.ToString()
															);

					#region 件数チェック
					Decimal dCnt = 0;

					if (GetHachuMst == null || GetHachuMst.Count <= 0)
					{
						// エラー
						ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
					}
					else
					{
						Hashtable resultTbl = GetHachuMst[0];
						dCnt = GetHachuMst.Count;

						// 0件チェック
						if (dCnt <= 0)
						{
							ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
						}
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion

					#region 検索結果を取得
					int iCnt = 0;
					foreach (Hashtable rec in GetHachuMst)
					{
						iCnt++;
						Th010f03M1Form f03m1VO = new Th010f03M1Form();

						f03m1VO.M1rowno = iCnt.ToString();				// Ｍ１行NO
						f03m1VO.M1iro_nm = rec["IRO_NM"].ToString();	// Ｍ１色
						f03m1VO.M1size_nm = rec["SIZE_NM"].ToString();	// Ｍ１サイズ
						f03m1VO.M1scan_cd = rec["JAN_CD"].ToString();	// Ｍ１スキャンコード
						f03m1VO.M1maisu = "";							// Ｍ１枚数
						f03m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF; ;	// Ｍ１選択フラグ(隠し)
						f03m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
						f03m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;		// Ｍ１明細色区分(隠し)

						// Dictionary
						f03m1VO.Dictionary.Add(Th010p01Constant.DIC_M1ROWNUM, iCnt.ToString());			//Ｍ１行NO
						f03m1VO.Dictionary.Add(Th010p01Constant.DIC_M1ZEI_KB, Convert.ToDecimal(rec["ZEI_KB"]));	// Ｍ１税区分
						f03m1VO.Dictionary[Th010p01Constant.DIC_M1SAISINBAIKA_TNK] = rec["BAIKA"].ToString();	// Ｍ１最新売価
						f03m1VO.Dictionary[Th010p01Constant.DIC_M1ZEIRITSU_CD] = rec["TAX_CD"].ToString();		// Ｍ１税率コード

						//リストオブジェクトにM1Formを追加します。
						nextM1List03.Add(f03m1VO, true);
					}
					#endregion
				}
				#endregion

				#region 画面の表示(カード部設定)
				if (prevVo.Syohinmst_serchstk.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK12))
				{
					// メーカー品番検索画面へ遷移する場合
					nextVo02.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD".ToUpper()].ToString();	// Dictionary.[ヘッダ店舗コード]
					nextVo02.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_NM".ToUpper()].ToString();	// Dictionary.[ヘッダ店舗名]
					nextVo02.Siiresaki_cd = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1SIIRESAKI_CD].ToString();						// Dictionary.[Ｍ１仕入先コード]
					nextVo02.Siiresaki_ryaku_nm = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1SIIRESAKI_RYAKU_NM].ToString();			// Dictionary.[Ｍ１仕入先名称]
					nextVo02.Burando_cd = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1BURANDO_CD].ToString();							// Dictionary.[Ｍ１ブランドコード]
					nextVo02.Burando_nm = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1BURANDO_NM].ToString();							// Dictionary.[Ｍ１ブランド名]
					nextVo02.Maker_hbn = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1MAKER_HBN].ToString();								// Dictionary.[Ｍ１メーカー品番]
					nextVo02.Genka = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1GENKA].ToString();										// Dictionary.[Ｍ１原価]
					nextVo02.Genbaika_tnk = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1GENBAIKA_TNK].ToString();						// Dictionary.[Ｍ１現売価]
					nextVo02.Makerkakaku_tnk = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1MAKERKAKAKU_TNK].ToString();					// Dictionary.[Ｍ１メーカー価格]

					// 選択行のインデックスを設定
					nextVo02.Dictionary[Th010p01Constant.DIC_M1BACKID] = Th010p01Constant.FORMID_01;
					nextVo02.Dictionary[Th010p01Constant.DIC_M1ID] = Th010p01Constant.M1JISYA_HBN;
					nextVo02.Dictionary[Th010p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

					// 商品マスタ検索選択
					nextVo02.Syohinmst_serchstk = ConditionSyohinmst_serchstk2.VALUE_SYOHINMST_SERCHSTK13;

					// 選択モードNO
					nextVo02.Stkmodeno = prevVo.Stkmodeno;

				}
				if(prevVo.Syohinmst_serchstk.Equals(ConditionSyohinmst_serchstk1.VALUE_SYOHINMST_SERCHSTK13))
				{
					// サイズ別プライスへ遷移する場合
					nextVo03.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD".ToUpper()].ToString();	// Dictionary.[ヘッダ店舗コード]
					nextVo03.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_NM".ToUpper()].ToString();	// Dictionary.[ヘッダ店舗名]
					nextVo03.Siiresaki_cd = prevM1Vo.M1siiresaki_cd;				// Ｍ１仕入先コード
					nextVo03.Siiresaki_ryaku_nm = prevM1Vo.M1siiresaki_ryaku_nm;	// Ｍ１仕入先名称
					nextVo03.Bumon_cd = prevM1Vo.M1bumon_cd;						// Ｍ１部門コード
					nextVo03.Bumon_nm = prevM1Vo.Dictionary[Th010p01Constant.DIC_BUMON_NM].ToString();			// Ｍ１部門カナ名(部門名に変更)
					nextVo03.Hinsyu_cd = prevM1Vo.M1hinsyu_cd;						// Ｍ１品種コード
					nextVo03.Hinsyu_ryaku_nm = prevM1Vo.M1hinsyu_ryaku_nm;			// Ｍ１品種略名称
					nextVo03.Burando_cd = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1BURANDO_CD].ToString();	// Dictionary.[Ｍ１ブランドコード]
					nextVo03.Burando_nm = prevM1Vo.M1burando_nm;					// Ｍ１ブランド名

					// 自社品番、旧自社品番を持っていない為,
					nextVo03.Jisya_hbn = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1XEBIO_CD].ToString();			// Ｍ１自社品番
					nextVo03.Old_jisya_hbn = prevM1Vo.Dictionary[Th010p01Constant.DIC_M1OLD_XEBIO_CD].ToString();	// Ｍ１旧自社品番

					nextVo03.Maker_hbn = prevM1Vo.M1maker_hbn;					// Ｍ１メーカー品番
					nextVo03.Syonmk = prevM1Vo.M1syonmk;						// Ｍ１商品名(カナ)
					nextVo03.Syohin_zokusei = prevM1Vo.M1syohin_zokusei;		// Ｍ１商品属性
					nextVo03.Hanbaikanryo_ymd = prevM1Vo.M1hanbaikanryo_ymd;	// Ｍ１販売完了日
					nextVo03.Saisinbaika_tnk = prevM1Vo.M1saisinbaika_tnk;		// Ｍ１最新売価
					nextVo03.Genka = prevM1Vo.M1genka;							// Ｍ１原価
					nextVo03.Genbaika_tnk = prevM1Vo.M1genbaika_tnk;			// Ｍ１現売価
					nextVo03.Makerkakaku_tnk = prevM1Vo.M1makerkakaku_tnk;		// Ｍ１メーカー価格

					// 選択行のインデックスを設定
					nextVo03.Dictionary[Th010p01Constant.DIC_M1BACKID] = Th010p01Constant.FORMID_01;
					nextVo03.Dictionary[Th010p01Constant.DIC_M1ID] = Th010p01Constant.M1JISYA_HBN;
					nextVo03.Dictionary[Th010p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

					// 隠し項目として以下の値を設定
					nextVo03.Dictionary[Th010p01Constant.DIC_M1ITEMKBN] = (string)prevM1Vo.Dictionary[Th010p01Constant.DIC_M1ITEMKBN];			// Ｍ１商品区分
					nextVo03.Dictionary[Th010p01Constant.DIC_M1SIIRE_KB] = (string)prevM1Vo.Dictionary[Th010p01Constant.DIC_M1SIIRE_KB];		// Ｍ１仕入区分
					nextVo03.Dictionary[Th010p01Constant.DIC_M1TYOTATSU_KB] = (string)prevM1Vo.Dictionary[Th010p01Constant.DIC_M1TYOTATSU_KB];	// Ｍ１調達区分

					// [出力シール]の名称取得
					if (nextVo03.Dictionary[Th010p01Constant.DIC_SYUTSURYOKU_SEAL] == null)
					{
						CalcTaxCls tax = new CalcTaxCls();
						nextVo03.Dictionary.Add(Th010p01Constant.DIC_SYUTSURYOKU_SEAL, tax.GetTaxDispControlInfo(facadeContext));
					}

					// レイアウト
					nextVo03.Layout = ConditionLayout.VALUE_LAYOUT1;

					// 選択モードNO
					nextVo03.Stkmodeno = prevVo.Stkmodeno;

					// ラベル情報を設定
					BoSystemLabelUtil.SetLabelInfo<Th010f03Form>(nextVo03, facadeContext);
				}
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1JISYA_HBN_FRM");

		}
		#endregion
	}
}
