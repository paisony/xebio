using com.xebio.bo.Tm040p01.Constant;
using com.xebio.bo.Tm040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01012;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tm040p01.Facade
{
  /// <summary>
  /// Tm040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tm040f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1iro_nm)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1iro_nm)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1IRO_NM_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1IRO_NM_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				////コネクションを取得して、トランザクションを開始する。
				//BeginTransactionWithConnect(facadeContext);
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。

				// 業務ロジック↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Tm040f01Form prevVo = (Tm040f01Form)facadeContext.FormVO;
				Tm040f02Form nextVo = (Tm040f02Form)facadeContext.GetUserObject(Tm040p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				int selectIndex = Convert.ToInt32(facadeContext.GetUserObject(Tm040p01Constant.DIC_SELECT_ROWIDX));
				Tm040f01M1Form prevM1Vo = (Tm040f01M1Form)prevM1List.GetPageViewList()[selectIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理

				#region 検索情報VO設定
				SearchHachuVO condition = new SearchHachuVO();
				condition.Tencd = BoSystemString.AllZeroToEmpty(prevVo.Tenpo_cd);					// 店舗コード
				condition.Pluflg = Convert.ToInt32(prevVo.Pluflg);									// 店別単価マスタ検索フラグ
				condition.Priceflg = Convert.ToInt32(prevVo.Priceflg);								// 売変検索フラグ
				condition.Zaikoflg = Convert.ToInt32(prevVo.Zaikoflg);								// 店在庫検索フラグ
				condition.Nyukaflg = Convert.ToInt32(prevVo.Nyukaflg);								// 入荷予定数検索フラグ
				condition.Uriflg = Convert.ToInt32(prevVo.Uriflg);									// 売上実績数検索フラグ
				condition.Hojuflg = Convert.ToInt32(prevVo.Hojuflg);								// 依頼集計数(補充)検索フラグ
				condition.Tanpinflg = Convert.ToInt32(prevVo.Tanpinflg);							// 依頼集計数(単品)検索フラグ
				condition.Sijiflg = Convert.ToInt32(prevVo.Sijiflg);								// 指示検索フラグ
				condition.Sijino = BoSystemString.ZeroToEmpty(prevVo.Siji_bango);					// 指示番号
				condition.Syukakaisyacd = BoSystemString.AllZeroToEmpty(prevVo.Syukkakaisya_cd);	// 出荷会社コード
				condition.Nyukakaisyacd = BoSystemString.AllZeroToEmpty(prevVo.Jyuryokaisya_cd);	// 入荷会社コード
				condition.Sijitencd = BoSystemString.AllZeroToEmpty(prevVo.Syukkaten_cd);			// 出荷店コード
				#endregion

				#region 追加抽出条件設定
				StringBuilder addSql = new StringBuilder();
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = null;

				#region 自社品番
				// 自社品番のフォーマット処理
				string formatedOldJisyaHbn = BoSystemFormat.formatJisyaHbn(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Old_jisya_hbn)].ToString());

				if (formatedOldJisyaHbn.Length == 8)
				{
					// 8桁の場合
					addSql.Append(" AND SYOHIN.XEBIO_CD = :OLD_JISYA_HBN ").AppendLine();

					bindVO = new BindInfoVO();
					bindVO.BindId = "OLD_JISYA_HBN";
					bindVO.Value = formatedOldJisyaHbn;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);
				}
				else if (formatedOldJisyaHbn.Length == 10)
				{
					// 10桁の場合
					addSql.Append(" AND SYOHIN.OLD_XEBIO_CD = :OLD_JISYA_HBN ").AppendLine();

					bindVO = new BindInfoVO();
					bindVO.BindId = "OLD_JISYA_HBN";
					bindVO.Value = formatedOldJisyaHbn;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);
				}
				#endregion

				#region スキャンコード
				string scanCd = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd)].ToString();

				if (!string.IsNullOrEmpty(scanCd))
				{
					if (scanCd.Length == 18)
					{
						// 18桁の場合
						addSql.Append(" AND SYOHIN.SYOHIN_CD_SERCH = :SCAN_CD ").AppendLine();

						bindVO = new BindInfoVO();
						bindVO.BindId = "SCAN_CD";
						bindVO.Value = BoSystemFormat.syohinCdGetSearch(scanCd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;
						bindList.Add(bindVO);
					}
					else
					{
						// 18桁以外の場合
						addSql.Append(" AND SYOHIN.JAN_CD = :SCAN_CD ").AppendLine();

						bindVO = new BindInfoVO();
						bindVO.BindId = "SCAN_CD";
						bindVO.Value = BoSystemFormat.formatJanCd(scanCd);
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;
						bindList.Add(bindVO);
					}
				}
				#endregion

				#region 色コード
				string m1TenkaiKb = prevM1Vo.Dictionary[Tm040p01Constant.DIC_M1TENKAI_KB].ToString();
				string formatedMakercolorCd = BoSystemFormat.formatIroCd(prevM1Vo.Dictionary[Tm040p01Constant.DIC_M1MAKERCOLOR_CD].ToString());

				if (string.IsNullOrEmpty(scanCd)
					&& m1TenkaiKb.Equals(BoSystemConstant.TENKAI_KB_SIZE))
				{
					// [スキャンコード]が空白で、Dictionary.[Ｍ１展開区分]が1(サイズ展開)の場合
					addSql.Append(" AND SYOHIN.MAKERCOLOR_CD = :MAKERCOLOR_CD ").AppendLine();

					bindVO = new BindInfoVO();
					bindVO.BindId = "MAKERCOLOR_CD";
					bindVO.Value = formatedMakercolorCd;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;
					bindList.Add(bindVO);
				}
				#endregion

				#endregion

				// ヒント句設定
				string hint = string.Empty;

				// ソート条件設定
				string orderBy = " ORDER BY DECODE(SYOHIN.TENKAI_KB, 1, SYOHIN.SIZE_NM, SYOHIN.MAKERCOLOR_CD) ";

				// 発注マスタ取得部品呼び出し
				IList<Hashtable> hachuMstInfo = SearchHachu.SearchHachuMst(condition, facadeContext.DBContext, 1, addSql, bindList, hint, orderBy);

				int rowNo = 1;		// 行NO
				foreach (Hashtable rec in hachuMstInfo)
				{
					if (rowNo == 1)
					{
						#region カード部設定
						nextVo.Stkmodeno = prevVo.Stkmodeno;						// 選択モードNO
						nextVo.Old_jisya_hbn = rec["XEBIO_CD"].ToString();			// 自社品番
						nextVo.Bumon_nm = rec["BUMON_NM"].ToString();				// 部門名
						nextVo.Hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// 品種略名称
						nextVo.Burando_nm = rec["BURANDO_NMK"].ToString();			// ブランド名
						nextVo.Maker_hbn = rec["HIN_NBR"].ToString();				// メーカー品番
						nextVo.Syonmk = rec["SYONMK"].ToString();					// 商品名(カナ)
						if (prevM1Vo.Dictionary[Tm040p01Constant.DIC_M1TENKAI_KB].Equals(BoSystemConstant.TENKAI_KB_COLOR))
						{
							// カラー展開の場合
							nextVo.Iro_nm = string.Empty;							// 色
						}
						else
						{
							nextVo.Iro_nm = rec["IRO_NM"].ToString();				// 色
						}

						// ディクショナリ
						nextVo.Dictionary[Tm040p01Constant.DIC_FORM_ID] = prevVo.Dictionary[Tm040p01Constant.DIC_FORM_ID];			// 呼出元画面ID
						nextVo.Dictionary[Tm040p01Constant.DIC_CUR_ROW_CNT] = prevVo.Dictionary[Tm040p01Constant.DIC_CUR_ROW_CNT];	// 現在行数
						nextVo.Dictionary[Tm040p01Constant.DIC_MAX_ROW_CNT] = prevVo.Dictionary[Tm040p01Constant.DIC_MAX_ROW_CNT];	// 最大行数

						nextVo.Dictionary[Tm040p01Constant.DIC_SELECT_ROWIDX] = selectIndex.ToString();								// 選択行のインデックスを設定
						#endregion
					}

					#region 明細部設定
					Tm040f02M1Form f02m1VO = new Tm040f02M1Form();

					f02m1VO.M1rowno = rowNo.ToString();								// Ｍ１行NO
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
					f02m1VO.M1lot_su = rec["MOTOMIYALOT_SU"].ToString();			// Ｍ１ロット数
					f02m1VO.M1haibunkano_su = rec["HAIBUNKANO_SU"].ToString();		// Ｍ１配分可能数
					f02m1VO.M1itemsu = string.Empty;								// Ｍ１数量

					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;		// Ｍ１明細色区分(隠し)

					// 発注マスタ情報を保持
					f02m1VO.Dictionary[Tm040p01Constant.DIC_M1HACHU_MST_INFO] = rec;

					// リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
					#endregion

					rowNo++;
				}

				#endregion
				// 業務ロジック↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

				////トランザクションをコミットする。
				//CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				////トランザクションをロールバックする。
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1IRO_NM_FRM");

		}
		#endregion
	}
}
