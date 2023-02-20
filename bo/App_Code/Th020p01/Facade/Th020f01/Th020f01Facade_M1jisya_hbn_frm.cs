using com.xebio.bo.Th020p01.Constant;
using com.xebio.bo.Th020p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace com.xebio.bo.Th020p01.Facade
{
  /// <summary>
  /// Th020f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Th020f01Facade : StandardBaseFacade
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
				//コネクションを開きます。
				OpenConnection(facadeContext);
			
				//以下に業務ロジックを記述する。

				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Th020f01Form prevVo = (Th020f01Form)facadeContext.FormVO;
				Th020f02Form nextVo02 = (Th020f02Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_02);
				Th020f03Form nextVo03 = (Th020f03Form)facadeContext.GetUserObject(Th020p01Constant.FCDUO_NEXTVO_03);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List02 = nextVo02.GetList("M1");
				IDataList nextM1List03 = nextVo03.GetList("M1");

				// 選択行の情報を取得する。
				// 明細件数が1件のみの場合、1行目の情報を設定する
				Th020f01M1Form prevM1Vo = new Th020f01M1Form();
				if (prevM1List.Count > 1) {
					prevM1Vo = (Th020f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];
				}
				else
				{
					// 1件の場合の初期設定
					prevM1Vo = (Th020f01M1Form)prevM1List[0];
				}

				// 一覧の初期化
				nextM1List02.ClearCacheData();
				nextM1List02.Clear();

				nextM1List03.ClearCacheData();
				nextM1List03.Clear();

				// 会社コード設定
				String sCopCd = string.Empty;
				String sCopNm = string.Empty;

				// 会社コードと検索条件が一致しない場合自エリア店別は選択不可
				switch (prevVo.Stkmodeno)
				{
					case BoSystemConstant.MODE_JISHAHINBAN:		// モード自社品番
						sCopCd = prevVo.Kaisya_cd;
						sCopNm = prevVo.Kaisya_nm;
						break;
					case BoSystemConstant.MODE_JISYAHBNFUKUSU:	// モード自社品番(複数)
						sCopCd = prevVo.Kaisya_cd2;
						sCopNm = prevVo.Kaisya_nm2;
						break;
					case BoSystemConstant.MODE_SCANCD:			// モードスキャンコード
						sCopCd = prevVo.Kaisya_cd3;
						sCopNm = prevVo.Kaisya_nm3;
						break;
					case BoSystemConstant.MODE_MAKERHBN:		// モードメーカー品番
						sCopCd = prevVo.Kaisya_cd4;
						sCopNm = prevVo.Kaisya_nm4;
						break;
					default:
						sCopCd = string.Empty;
						break;
				}

				sCopCd = Convert.ToDecimal(BoSystemString.Nvl(sCopCd, "0")).ToString();

				// 店舗コード Dictionaryより取得
				string keyHeadTenpoCd = BoSystemFormat.formatTenpoCd(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString());

				// 展開区分
				String tenkaiKbn = string.Empty;

				#endregion

				#region 検索処理

				// 展開区分を取得する
				FindSqlResultTable rtTenkai = FindSqlUtil.CreateFindSqlResultTable(Th020p01Constant.SQL_ID_04, facadeContext.DBContext);

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();

				// テーブルID設定
				String addTable = "FROM	MDMT0130_" + sCopCd + " MDMT0130";
				BoSystemSql.AddSql(rtTenkai, Th020p01Constant.REP_ADD_TABLE, addTable);

				// 自社品番
				rtTenkai.BindValue(Th020p01Constant.REP_BIND_JISHAHIN, BoSystemFormat.formatJisyaHbn(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1JISYA_HBN].ToString()));

				// 色コード
				rtTenkai.BindValue(Th020p01Constant.REP_BIND_IRO_CD, BoSystemFormat.formatIroCd(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD].ToString()));

				//検索結果を取得します
				rtTenkai.CreateDbCommand();
				IList<Hashtable> tableList = rtTenkai.Execute();

				BoSystemLog.logOut("SQL: " + rtTenkai.LogSql);

				// 展開区分を取得
				Hashtable hash = (Hashtable)tableList[0];
				tenkaiKbn = hash["TENKAI_KB"].ToString(); ;

				// 在庫検索
				ArrayList rtSeach = doSelectDataBase(facadeContext, prevVo, prevM1Vo, logininfo);

				// カーソル取得
				ArrayList rtSeachList = (ArrayList)rtSeach[1];

				if (rtSeachList == null || rtSeachList.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// [在庫検索選択]がエリア選択の場合、在庫検索-明細(エリア別)画面VOを作成する
				if (ConditionZaiko_serchstk.VALUE_ZAIKO_SERCHSTK1.Equals(prevVo.Zaiko_serchstk))
				{
					Hashtable HeadRec = (Hashtable)rtSeachList[0];

					// カード部設定
					// ヘッダ店舗コード
					nextVo03.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString();
					// ヘッダ店舗名
					nextVo03.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)].ToString();
					// 会社コード
					nextVo03.Kaisya_cd = sCopCd;
					// 会社名称
					nextVo03.Kaisya_nm = sCopNm;
					// 部門コード
					nextVo03.Bumon_cd = BoSystemFormat.formatBumonCd(prevM1Vo.M1bumon_cd);
					// 部門名
					nextVo03.Bumon_nm = prevM1Vo.Dictionary[Th020p01Constant.DIC_M1BUMON_NM].ToString();
					// 品種略名称
					nextVo03.Hinsyu_ryaku_nm = prevM1Vo.M1hinsyu_ryaku_nm;
					// 品種コード
					nextVo03.Hinsyu_cd = prevM1Vo.Dictionary[Th020p01Constant.DIC_M1HINSYU_CD].ToString();
					// ブランドコード
					nextVo03.Burando_cd = BoSystemFormat.formatBrandCd(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1BURANDO_CD].ToString());
					// ブランド名
					nextVo03.Burando_nm = prevM1Vo.M1burando_nm;
					// 自社品番
					nextVo03.Jisya_hbn = prevM1Vo.Dictionary[Th020p01Constant.DIC_M1JISYA_HBN].ToString();
					// メーカー品番
					nextVo03.Maker_hbn = prevM1Vo.M1maker_hbn;
					// 商品属性
					nextVo03.Syohin_zokusei = prevM1Vo.M1syohin_zokusei;
					// 商品名(カナ)
					nextVo03.Syonmk = prevM1Vo.M1syonmk;
					// 色
					nextVo03.Iro_nm = prevM1Vo.M1iro_nm;
					// 全店在庫数
					nextVo03.Zentenzaiko_su = prevM1Vo.M1zentenzaiko_su;
					// 全店消化率
					nextVo03.Zentensyoka_rtu = prevM1Vo.M1syoka_rtu;
					//明細ヘッダ色１
					nextVo03.Meisaihead_iro_nm1 = hyodaiEdit(HeadRec, "SIZE_NM01");
					//明細ヘッダ色２
					nextVo03.Meisaihead_iro_nm2 = hyodaiEdit(HeadRec,  "SIZE_NM02");
					//明細ヘッダ色３
					nextVo03.Meisaihead_iro_nm3 = hyodaiEdit(HeadRec,  "SIZE_NM03");
					//明細ヘッダ色４
					nextVo03.Meisaihead_iro_nm4 = hyodaiEdit(HeadRec,  "SIZE_NM04");
					//明細ヘッダ色５
					nextVo03.Meisaihead_iro_nm5 = hyodaiEdit(HeadRec,  "SIZE_NM05");
					//明細ヘッダ色６
					nextVo03.Meisaihead_iro_nm6 = hyodaiEdit(HeadRec,  "SIZE_NM06");
					//明細ヘッダ色７
					nextVo03.Meisaihead_iro_nm7 = hyodaiEdit(HeadRec,  "SIZE_NM07");
					//明細ヘッダ色８
					nextVo03.Meisaihead_iro_nm8 = hyodaiEdit(HeadRec,  "SIZE_NM08");
					//明細ヘッダ色９
					nextVo03.Meisaihead_iro_nm9 = hyodaiEdit(HeadRec,  "SIZE_NM09");
					//明細ヘッダ色１０
					nextVo03.Meisaihead_iro_nm10 = hyodaiEdit(HeadRec, "SIZE_NM10");
					//明細ヘッダ色１１
					nextVo03.Meisaihead_iro_nm11 = hyodaiEdit(HeadRec, "SIZE_NM11");
					//明細ヘッダ色１２
					nextVo03.Meisaihead_iro_nm12 = hyodaiEdit(HeadRec, "SIZE_NM12");
					//明細ヘッダ色１３
					nextVo03.Meisaihead_iro_nm13 = hyodaiEdit(HeadRec, "SIZE_NM13");
					//明細ヘッダ色１４
					nextVo03.Meisaihead_iro_nm14 = hyodaiEdit(HeadRec, "SIZE_NM14");
					//明細ヘッダ色１５
					nextVo03.Meisaihead_iro_nm15 = hyodaiEdit(HeadRec, "SIZE_NM15");
					//明細ヘッダ色１６
					nextVo03.Meisaihead_iro_nm16 = hyodaiEdit(HeadRec, "SIZE_NM16");
					//明細ヘッダ色１７
					nextVo03.Meisaihead_iro_nm17 = hyodaiEdit(HeadRec, "SIZE_NM17");
					//明細ヘッダ色１８
					nextVo03.Meisaihead_iro_nm18 = hyodaiEdit(HeadRec, "SIZE_NM18");
					//明細ヘッダ色１９
					nextVo03.Meisaihead_iro_nm19 = hyodaiEdit(HeadRec, "SIZE_NM19");
					//明細ヘッダ色２０
					nextVo03.Meisaihead_iro_nm20 = hyodaiEdit(HeadRec, "SIZE_NM20");
					//明細ヘッダ色２１
					nextVo03.Meisaihead_iro_nm21 = hyodaiEdit(HeadRec, "SIZE_NM21");
					//明細ヘッダ色２２
					nextVo03.Meisaihead_iro_nm22 = hyodaiEdit(HeadRec, "SIZE_NM22");
					//明細ヘッダ色２３
					nextVo03.Meisaihead_iro_nm23 = hyodaiEdit(HeadRec, "SIZE_NM23");
					//明細ヘッダ色２４
					nextVo03.Meisaihead_iro_nm24 = hyodaiEdit(HeadRec, "SIZE_NM24");
					//明細ヘッダ色２５
					nextVo03.Meisaihead_iro_nm25 = hyodaiEdit(HeadRec, "SIZE_NM25");
					//明細ヘッダ色２６
					nextVo03.Meisaihead_iro_nm26 = hyodaiEdit(HeadRec, "SIZE_NM26");
					//明細ヘッダ色２７
					nextVo03.Meisaihead_iro_nm27 = hyodaiEdit(HeadRec, "SIZE_NM27");
					//明細ヘッダ色２８
					nextVo03.Meisaihead_iro_nm28 = hyodaiEdit(HeadRec, "SIZE_NM28");
					//明細ヘッダ色２９
					nextVo03.Meisaihead_iro_nm29 = hyodaiEdit(HeadRec, "SIZE_NM29");
					//明細ヘッダ色３０
					nextVo03.Meisaihead_iro_nm30 = hyodaiEdit(HeadRec, "SIZE_NM30");

					// 明細フッター 取得した明細の1行目を設定する
					// 店舗コード
					nextVo03.Tenpo_cd = BoSystemFormat.formatTenpoCd(HeadRec["TENPO_CD"].ToString());
					// 店舗名
					nextVo03.Tenpo_nm = HeadRec["TENPO_NM"].ToString();
					// 総合計数量
					nextVo03.All_gokei_suryo = HeadRec["ZAIKOSU"].ToString();
					// 合計数量１
					nextVo03.Gokei_suryo1 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU01", "JAN_CD01");
					// 合計数量２
					nextVo03.Gokei_suryo2 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU02",  "JAN_CD02"); 
					// 合計数量３
					nextVo03.Gokei_suryo3 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU03",  "JAN_CD03"); 
					// 合計数量４
					nextVo03.Gokei_suryo4 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU04",  "JAN_CD04");
					// 合計数量５
					nextVo03.Gokei_suryo5 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU05",  "JAN_CD05");
					// 合計数量６
					nextVo03.Gokei_suryo6 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU06",  "JAN_CD06");
					// 合計数量７
					nextVo03.Gokei_suryo7 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU07",  "JAN_CD07");
					// 合計数量８
					nextVo03.Gokei_suryo8 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU08",  "JAN_CD08");
					// 合計数量９
					nextVo03.Gokei_suryo9 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU09",  "JAN_CD09");
					// 合計数量１０
					nextVo03.Gokei_suryo10 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU10", "JAN_CD10");
					// 合計数量１１
					nextVo03.Gokei_suryo11 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU11", "JAN_CD11");
					// 合計数量１２
					nextVo03.Gokei_suryo12 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU12", "JAN_CD12");
					// 合計数量１３
					nextVo03.Gokei_suryo13 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU13", "JAN_CD13");
					// 合計数量１４
					nextVo03.Gokei_suryo14 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU14", "JAN_CD14");
					// 合計数量１５
					nextVo03.Gokei_suryo15 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU15", "JAN_CD15");
					// 合計数量１６
					nextVo03.Gokei_suryo16 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU16", "JAN_CD16");
					// 合計数量１７
					nextVo03.Gokei_suryo17 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU17", "JAN_CD17");
					// 合計数量１８
					nextVo03.Gokei_suryo18 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU18", "JAN_CD18");
					// 合計数量１９
					nextVo03.Gokei_suryo19 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU19", "JAN_CD19");
					// 合計数量２０
					nextVo03.Gokei_suryo20 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU20", "JAN_CD20");
					// 合計数量２１
					nextVo03.Gokei_suryo21 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU21", "JAN_CD21");
					// 合計数量２２
					nextVo03.Gokei_suryo22 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU22", "JAN_CD22");
					// 合計数量２３
					nextVo03.Gokei_suryo23 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU23", "JAN_CD23");
					// 合計数量２４
					nextVo03.Gokei_suryo24 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU24", "JAN_CD24");
					// 合計数量２５
					nextVo03.Gokei_suryo25 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU25", "JAN_CD25");
					// 合計数量２６
					nextVo03.Gokei_suryo26 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU26", "JAN_CD26");
					// 合計数量２７
					nextVo03.Gokei_suryo27 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU27", "JAN_CD27");
					// 合計数量２８
					nextVo03.Gokei_suryo28 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU28", "JAN_CD28");
					// 合計数量２９
					nextVo03.Gokei_suryo29 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU29", "JAN_CD29");
					// 合計数量３０
					nextVo03.Gokei_suryo30 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU30", "JAN_CD30");


					// 明細ヘッダ色(1～30)
					nextVo03.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH] = HeadRec;

					// 一覧画面の選択モード
					nextVo03.Dictionary[Th020p01Constant.DIC_STKMODENO] = prevVo.Stkmodeno;
					if (prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_SCANCD))
					{
						// 一覧画面のスキャンコードFROM
						nextVo03.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM] = BoSystemString.Nvl(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd_from)].ToString());
						// 一覧画面のスキャンコードTO
						nextVo03.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO] = BoSystemString.Nvl(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd_to)].ToString());
					}
					else
					{
						// 一覧画面のスキャンコードFROM
						nextVo03.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM] = string.Empty;
						// 一覧画面のスキャンコードTO
						nextVo03.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO] = string.Empty;
					}
					// 一覧画面のスキャンコードFROM
					//nextVo03.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM] = BoSystemString.Nvl(prevVo.Scan_cd_from);
					// 一覧画面のスキャンコードTO
					//nextVo03.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO] = BoSystemString.Nvl(prevVo.Scan_cd_to);
					// 色コード
					nextVo03.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD] = BoSystemFormat.formatIroCd(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD].ToString());
					// 検索エリアコード
					nextVo03.Dictionary[Th020p01Constant.DIC_AREA_CD] = prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString();
					// 背景色変更エリアコード
					nextVo03.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE] = prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE];
					// 検索時店舗コード
					nextVo03.Dictionary[Th020p01Constant.DIC_TENPO_CD] = keyHeadTenpoCd;
					// 展開区分
					nextVo03.Dictionary[Th020p01Constant.DIC_TENKAI_KBN] = tenkaiKbn;
					// 前画面フォームID
					nextVo03.Dictionary[Th020p01Constant.DIC_PREV_FORMID] = Th020p01Constant.FORMID_01;
					// 在庫検索選択状態
					nextVo03.Dictionary[Th020p01Constant.DIC_ZAIKO_SERCHSTK] = prevVo.Zaiko_serchstk;
					// 選択行のインデックスを設定
					nextVo03.Dictionary[Th020p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

					int iCnt = -1;

					// 明細設定
					foreach (Hashtable rec in rtSeachList)
					{
						Th020f03M1Form f03m1VO = new Th020f03M1Form();

						// 一行目は在庫検索用の物流センターデータのため飛ばす
						if (iCnt == -1)
						{
							iCnt++;
							continue;
						}
						iCnt++;
						// Ｍ１行NO
						f03m1VO.M1rowno = iCnt.ToString();
						// Ｍ１エリアコード
						// f03m1VO.M1area_cd = rec["TENPO_CD"].ToString();
						// Ｍ１エリア略式名称
						f03m1VO.Dictionary[Th020p01Constant.DIC_M1AREA_NM] = rec["TENPO_NM"].ToString();
						// Ｍ１合計数量
						f03m1VO.M1gokei_suryo = rec["ZAIKOSU"].ToString();
						// Ｍ１消化率
						f03m1VO.M1syoka_rtu = BoSystemString.Nvl(rec["SYOKART"].ToString(),"0.0");
						// Ｍ１数量１
						f03m1VO.M1suryo1 = zaikoSuEdit(rec, "FREEZAIKO_SU01", "JAN_CD01");
						// Ｍ１数量２
						f03m1VO.M1suryo2 = zaikoSuEdit(rec, "FREEZAIKO_SU02", "JAN_CD02");
						// Ｍ１数量３
						f03m1VO.M1suryo3 = zaikoSuEdit(rec, "FREEZAIKO_SU03", "JAN_CD03");
						// Ｍ１数量４
						f03m1VO.M1suryo4 = zaikoSuEdit(rec, "FREEZAIKO_SU04", "JAN_CD04");
						// Ｍ１数量５
						f03m1VO.M1suryo5 = zaikoSuEdit(rec, "FREEZAIKO_SU05", "JAN_CD05");
						// Ｍ１数量６
						f03m1VO.M1suryo6 = zaikoSuEdit(rec, "FREEZAIKO_SU06", "JAN_CD06");
						// Ｍ１数量７
						f03m1VO.M1suryo7 = zaikoSuEdit(rec, "FREEZAIKO_SU07", "JAN_CD07");
						// Ｍ１数量８
						f03m1VO.M1suryo8 = zaikoSuEdit(rec, "FREEZAIKO_SU08", "JAN_CD08");
						// Ｍ１数量９
						f03m1VO.M1suryo9 = zaikoSuEdit(rec, "FREEZAIKO_SU09", "JAN_CD09");
						// Ｍ１数量１０
						f03m1VO.M1suryo10 = zaikoSuEdit(rec, "FREEZAIKO_SU10", "JAN_CD10");
						// Ｍ１数量１１
						f03m1VO.M1suryo11 = zaikoSuEdit(rec, "FREEZAIKO_SU11", "JAN_CD11");
						// Ｍ１数量１２
						f03m1VO.M1suryo12 = zaikoSuEdit(rec, "FREEZAIKO_SU12", "JAN_CD12");
						// Ｍ１数量１３
						f03m1VO.M1suryo13 = zaikoSuEdit(rec, "FREEZAIKO_SU13", "JAN_CD13");
						// Ｍ１数量１４
						f03m1VO.M1suryo14 = zaikoSuEdit(rec, "FREEZAIKO_SU14", "JAN_CD14");
						// Ｍ１数量１５
						f03m1VO.M1suryo15 = zaikoSuEdit(rec, "FREEZAIKO_SU15", "JAN_CD15");
						// Ｍ１数量１６
						f03m1VO.M1suryo16 = zaikoSuEdit(rec, "FREEZAIKO_SU16", "JAN_CD16");
						// Ｍ１数量１７
						f03m1VO.M1suryo17 = zaikoSuEdit(rec, "FREEZAIKO_SU17", "JAN_CD17");
						// Ｍ１数量１８
						f03m1VO.M1suryo18 = zaikoSuEdit(rec, "FREEZAIKO_SU18", "JAN_CD18");
						// Ｍ１数量１９
						f03m1VO.M1suryo19 = zaikoSuEdit(rec, "FREEZAIKO_SU19", "JAN_CD19");
						// Ｍ１数量２０
						f03m1VO.M1suryo20 = zaikoSuEdit(rec, "FREEZAIKO_SU20", "JAN_CD20");
						// Ｍ１数量２１
						f03m1VO.M1suryo21 = zaikoSuEdit(rec, "FREEZAIKO_SU21", "JAN_CD21");
						// Ｍ１数量２２
						f03m1VO.M1suryo22 = zaikoSuEdit(rec, "FREEZAIKO_SU22", "JAN_CD22");
						// Ｍ１数量２３
						f03m1VO.M1suryo23 = zaikoSuEdit(rec, "FREEZAIKO_SU23", "JAN_CD23");
						// Ｍ１数量２４
						f03m1VO.M1suryo24 = zaikoSuEdit(rec, "FREEZAIKO_SU24", "JAN_CD24");
						// Ｍ１数量２５
						f03m1VO.M1suryo25 = zaikoSuEdit(rec, "FREEZAIKO_SU25", "JAN_CD25");
						// Ｍ１数量２６
						f03m1VO.M1suryo26 = zaikoSuEdit(rec, "FREEZAIKO_SU26", "JAN_CD26");
						// Ｍ１数量２７
						f03m1VO.M1suryo27 = zaikoSuEdit(rec, "FREEZAIKO_SU27", "JAN_CD27");
						// Ｍ１数量２８
						f03m1VO.M1suryo28 = zaikoSuEdit(rec, "FREEZAIKO_SU28", "JAN_CD28");
						// Ｍ１数量２９
						f03m1VO.M1suryo29 = zaikoSuEdit(rec, "FREEZAIKO_SU29", "JAN_CD29");
						// Ｍ１数量３０
						f03m1VO.M1suryo30 = zaikoSuEdit(rec, "FREEZAIKO_SU30", "JAN_CD30");

						// Ｍ１選択フラグ(隠し)
						f03m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
						// Ｍ１確定処理フラグ(隠し)
						f03m1VO.M1selectorcheckbox = ConditionKakuteisyori_flg.VALUE_NASI;
						// Ｍ１明細色区分(隠し)
						// 取得したエリアコードとヘッダ店舗コードに紐づくエリアコードが一致した場合、"2"、それ以外の場合、"0"
						if (prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE].ToString().Equals(rec["TENPO_CD"].ToString()))
						{
							f03m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
						}
						else
						{
							f03m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
						}

						// M1エリアコード(Dictionary)
						f03m1VO.Dictionary[Th020p01Constant.DIC_AREA_CD] = rec["TENPO_CD"].ToString();

						//リストオブジェクトにM1Formを追加します。
						nextM1List03.Add(f03m1VO, true);
					}
				}
				// [在庫検索選択]がエリア選択以外の場合、在庫検索-明細(店舗別)画面VOを作成する
				else
				{

					Hashtable HeadRec = (Hashtable)rtSeachList[0];

					// カード部設定
					// ヘッダ店舗コード
					nextVo02.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString();
					// ヘッダ店舗名
					nextVo02.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)].ToString();
					// 会社コード
					nextVo02.Kaisya_cd = sCopCd;
					// 会社名称
					nextVo02.Kaisya_nm = sCopNm;
					// 部門コード
					nextVo02.Bumon_cd = BoSystemFormat.formatBumonCd(prevM1Vo.M1bumon_cd);
					// 部門名
					nextVo02.Bumon_nm = prevM1Vo.Dictionary[Th020p01Constant.DIC_M1BUMON_NM].ToString();
					// 品種略名称
					nextVo02.Hinsyu_ryaku_nm = prevM1Vo.M1hinsyu_ryaku_nm;
					// 品種コード
					nextVo02.Hinsyu_cd = prevM1Vo.Dictionary[Th020p01Constant.DIC_M1HINSYU_CD].ToString();
					// ブランドコード
					nextVo02.Burando_cd = BoSystemFormat.formatBrandCd(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1BURANDO_CD].ToString());
					// ブランド名
					nextVo02.Burando_nm = prevM1Vo.M1burando_nm;
					// 自社品番
					nextVo02.Jisya_hbn = prevM1Vo.Dictionary[Th020p01Constant.DIC_M1JISYA_HBN].ToString();
					// メーカー品番
					nextVo02.Maker_hbn = prevM1Vo.M1maker_hbn;
					// 商品属性
					nextVo02.Syohin_zokusei = prevM1Vo.M1syohin_zokusei;
					// 商品名(カナ)
					nextVo02.Syonmk = prevM1Vo.M1syonmk;
					// 色
					nextVo02.Iro_nm = prevM1Vo.M1iro_nm;
					// 全店在庫数
					nextVo02.Zentenzaiko_su = prevM1Vo.M1zentenzaiko_su;
					// 全店消化率
					nextVo02.Zentensyoka_rtu = prevM1Vo.M1syoka_rtu;
					// 明細ヘッダ色(1～30)
					nextVo02.Dictionary[Th020p01Constant.DIC_M1HEAD_HASH] = HeadRec;
					
					// 明細フッター 取得した明細の1行目を設定する
					// 店舗コード
					nextVo02.Tenpo_cd = BoSystemFormat.formatTenpoCd(HeadRec["TENPO_CD"].ToString());
					// 店舗名
					nextVo02.Tenpo_nm = HeadRec["TENPO_NM"].ToString();
					// 総合計数量
					nextVo02.All_gokei_suryo = HeadRec["ZAIKOSU"].ToString();
					// 数量１
					nextVo02.Suryo1 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU01", "JAN_CD01");
					// 数量２
					nextVo02.Suryo2 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU02", "JAN_CD02");
					// 数量３
					nextVo02.Suryo3 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU03", "JAN_CD03");
					// 数量４
					nextVo02.Suryo4 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU04", "JAN_CD04");
					// 数量５
					nextVo02.Suryo5 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU05", "JAN_CD05");
					// 数量６
					nextVo02.Suryo6 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU06", "JAN_CD06");
					// 数量７
					nextVo02.Suryo7 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU07", "JAN_CD07");
					// 数量８
					nextVo02.Suryo8 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU08", "JAN_CD08");
					// 数量９
					nextVo02.Suryo9 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU09", "JAN_CD09");
					// 数量１０
					nextVo02.Suryo10 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU10", "JAN_CD10");
					// 数量１１
					nextVo02.Suryo11 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU11", "JAN_CD11");
					// 数量１２
					nextVo02.Suryo12 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU12", "JAN_CD12");
					// 数量１３
					nextVo02.Suryo13 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU13", "JAN_CD13");
					// 数量１４
					nextVo02.Suryo14 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU14", "JAN_CD14");
					// 数量１５
					nextVo02.Suryo15 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU15", "JAN_CD15");
					// 数量１６
					nextVo02.Suryo16 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU16", "JAN_CD16");
					// 数量１７
					nextVo02.Suryo17 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU17", "JAN_CD17");
					// 数量１８
					nextVo02.Suryo18 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU18", "JAN_CD18");
					// 数量１９
					nextVo02.Suryo19 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU19", "JAN_CD19");
					// 数量２０
					nextVo02.Suryo20 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU20", "JAN_CD20");
					// 数量２１
					nextVo02.Suryo21 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU21", "JAN_CD21");
					// 数量２２
					nextVo02.Suryo22 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU22", "JAN_CD22");
					// 数量２３
					nextVo02.Suryo23 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU23", "JAN_CD23");
					// 数量２４
					nextVo02.Suryo24 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU24", "JAN_CD24");
					// 数量２５
					nextVo02.Suryo25 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU25", "JAN_CD25");
					// 数量２６
					nextVo02.Suryo26 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU26", "JAN_CD26");
					// 数量２７
					nextVo02.Suryo27 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU27", "JAN_CD27");
					// 数量２８
					nextVo02.Suryo28 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU28", "JAN_CD28");
					// 数量２９
					nextVo02.Suryo29 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU29", "JAN_CD29");
					// 数量３０
					nextVo02.Suryo30 = zaikoSuEdit(HeadRec, "FREEZAIKO_SU30", "JAN_CD30");


					// 一覧画面の選択モード
					nextVo02.Dictionary[Th020p01Constant.DIC_STKMODENO] = prevVo.Stkmodeno;
					if (prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_SCANCD))
					{
						// 一覧画面のスキャンコードFROM
						nextVo02.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM] = BoSystemString.Nvl(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd_from)].ToString());
						// 一覧画面のスキャンコードTO
						nextVo02.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO] = BoSystemString.Nvl(prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Scan_cd_to)].ToString());
					}
					else
					{
						// 一覧画面のスキャンコードFROM
						nextVo02.Dictionary[Th020p01Constant.DIC_SCAN_CD_FROM] = string.Empty;
						// 一覧画面のスキャンコードTO
						nextVo02.Dictionary[Th020p01Constant.DIC_SCAN_CD_TO] = string.Empty;
					}

					// 色コード
					nextVo02.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD] = BoSystemFormat.formatIroCd(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD].ToString());
					// 検索エリアコード
					nextVo02.Dictionary[Th020p01Constant.DIC_AREA_CD] = prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString();
					// 背景色変更エリアコード
					nextVo02.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE] = prevVo.Dictionary[Th020p01Constant.DIC_AREA_CD_IROCHANGE];
					// 展開区分
					nextVo02.Dictionary[Th020p01Constant.DIC_TENKAI_KBN] = tenkaiKbn;
					// 検索時店舗コード
					nextVo02.Dictionary[Th020p01Constant.DIC_TENPO_CD] = keyHeadTenpoCd;
					// 前画面フォームID
					nextVo02.Dictionary[Th020p01Constant.DIC_PREV_FORMID] = Th020p01Constant.FORMID_01;
					// 在庫検索選択状態
					nextVo02.Dictionary[Th020p01Constant.DIC_ZAIKO_SERCHSTK] = prevVo.Zaiko_serchstk;
					// 選択行のインデックスを設定
					nextVo02.Dictionary[Th020p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

					int iCnt = -1;
					// 明細設定
					foreach (Hashtable rec in rtSeachList)
					{
						Th020f02M1Form f02m1VO = new Th020f02M1Form();

						// 一行目は在庫検索用の物流センターデータのため飛ばす
						if (iCnt == -1)
						{
							iCnt++;
							continue;
						}
						iCnt++;
						// Ｍ１行NO
						f02m1VO.M1rowno = iCnt.ToString();
						// Ｍ１店舗コード
						f02m1VO.M1tenpo_cd = BoSystemFormat.formatTenpoCd(rec["TENPO_CD"].ToString());
						// Ｍ１店舗名
						f02m1VO.M1tenpo_nm = rec["TENPO_NM"].ToString();
						// Ｍ１合計数量
						f02m1VO.M1gokei_suryo = rec["ZAIKOSU"].ToString();
						// Ｍ１消化率
						f02m1VO.M1syoka_rtu = BoSystemString.Nvl(rec["SYOKART"].ToString(),"0.0");
						// Ｍ１数量１
						f02m1VO.M1suryo1 = zaikoSuEdit(rec, "FREEZAIKO_SU01",  "JAN_CD01");
						// Ｍ１数量２
						f02m1VO.M1suryo2 = zaikoSuEdit(rec, "FREEZAIKO_SU02",  "JAN_CD02");
						// Ｍ１数量３
						f02m1VO.M1suryo3 = zaikoSuEdit(rec, "FREEZAIKO_SU03",  "JAN_CD03");
						// Ｍ１数量４
						f02m1VO.M1suryo4 = zaikoSuEdit(rec, "FREEZAIKO_SU04",  "JAN_CD04");
						// Ｍ１数量５
						f02m1VO.M1suryo5 = zaikoSuEdit(rec, "FREEZAIKO_SU05",  "JAN_CD05");
						// Ｍ１数量６
						f02m1VO.M1suryo6 = zaikoSuEdit(rec, "FREEZAIKO_SU06",  "JAN_CD06");
						// Ｍ１数量７
						f02m1VO.M1suryo7 = zaikoSuEdit(rec, "FREEZAIKO_SU07",  "JAN_CD07");
						// Ｍ１数量８
						f02m1VO.M1suryo8 = zaikoSuEdit(rec, "FREEZAIKO_SU08",  "JAN_CD08");
						// Ｍ１数量９
						f02m1VO.M1suryo9 = zaikoSuEdit(rec, "FREEZAIKO_SU09",  "JAN_CD09");
						// Ｍ１数量１０
						f02m1VO.M1suryo10 = zaikoSuEdit(rec, "FREEZAIKO_SU10", "JAN_CD10");
						// Ｍ１数量１１
						f02m1VO.M1suryo11 = zaikoSuEdit(rec, "FREEZAIKO_SU11", "JAN_CD11");
						// Ｍ１数量１２
						f02m1VO.M1suryo12 = zaikoSuEdit(rec, "FREEZAIKO_SU12", "JAN_CD12");
						// Ｍ１数量１３
						f02m1VO.M1suryo13 = zaikoSuEdit(rec, "FREEZAIKO_SU13", "JAN_CD13");
						// Ｍ１数量１４
						f02m1VO.M1suryo14 = zaikoSuEdit(rec, "FREEZAIKO_SU14", "JAN_CD14");
						// Ｍ１数量１５
						f02m1VO.M1suryo15 = zaikoSuEdit(rec, "FREEZAIKO_SU15", "JAN_CD15");
						// Ｍ１数量１６
						f02m1VO.M1suryo16 = zaikoSuEdit(rec, "FREEZAIKO_SU16", "JAN_CD16");
						// Ｍ１数量１７
						f02m1VO.M1suryo17 = zaikoSuEdit(rec, "FREEZAIKO_SU17", "JAN_CD17");
						// Ｍ１数量１８
						f02m1VO.M1suryo18 = zaikoSuEdit(rec, "FREEZAIKO_SU18", "JAN_CD18");
						// Ｍ１数量１９
						f02m1VO.M1suryo19 = zaikoSuEdit(rec, "FREEZAIKO_SU19", "JAN_CD19");
						// Ｍ１数量２０
						f02m1VO.M1suryo20 = zaikoSuEdit(rec, "FREEZAIKO_SU20", "JAN_CD20");
						// Ｍ１数量２１
						f02m1VO.M1suryo21 = zaikoSuEdit(rec, "FREEZAIKO_SU21", "JAN_CD21");
						// Ｍ１数量２２
						f02m1VO.M1suryo22 = zaikoSuEdit(rec, "FREEZAIKO_SU22", "JAN_CD22");
						// Ｍ１数量２３
						f02m1VO.M1suryo23 = zaikoSuEdit(rec, "FREEZAIKO_SU23", "JAN_CD23");
						// Ｍ１数量２４
						f02m1VO.M1suryo24 = zaikoSuEdit(rec, "FREEZAIKO_SU24", "JAN_CD24");
						// Ｍ１数量２５
						f02m1VO.M1suryo25 = zaikoSuEdit(rec, "FREEZAIKO_SU25", "JAN_CD25");
						// Ｍ１数量２６
						f02m1VO.M1suryo26 = zaikoSuEdit(rec, "FREEZAIKO_SU26", "JAN_CD26");
						// Ｍ１数量２７
						f02m1VO.M1suryo27 = zaikoSuEdit(rec, "FREEZAIKO_SU27", "JAN_CD27");
						// Ｍ１数量２８
						f02m1VO.M1suryo28 = zaikoSuEdit(rec, "FREEZAIKO_SU28", "JAN_CD28");
						// Ｍ１数量２９
						f02m1VO.M1suryo29 = zaikoSuEdit(rec, "FREEZAIKO_SU29", "JAN_CD29");
						// Ｍ１数量３０
						f02m1VO.M1suryo30 = zaikoSuEdit(rec, "FREEZAIKO_SU30", "JAN_CD30");
						// Ｍ１選択フラグ(隠し)
						f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
						// Ｍ１確定処理フラグ(隠し)
						f02m1VO.M1selectorcheckbox = ConditionKakuteisyori_flg.VALUE_NASI;
						// Ｍ１明細色区分(隠し)
						// Ｍ１店舗コードとログイン情報の店舗コードが一致した場合、"2"、それ以外の場合、"0"
						if (BoSystemFormat.formatTenpoCd(keyHeadTenpoCd).Equals(BoSystemFormat.formatTenpoCd(f02m1VO.M1tenpo_cd)))
						{
							f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;
						}
						else
						{
							f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;
						}
						//リストオブジェクトにM1Formを追加します。
						nextM1List02.Add(f02m1VO, true);

					}
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

		#region ユーザー定義関数

		#region 検索処理

		/// <summary>
		/// 検索処理
		/// </summary>
		/// <param name="IfacadeContext">facadeContext</param>
		/// <param name="Th020f01Form">f01VO</param>
		/// <param name="Th020f01M1Form">prevM1Vo</param>
		/// <param name="LoginInfoVO">logininfo</param>
		/// <returns>結果</returns>
		private ArrayList doSelectDataBase(IFacadeContext facadeContext, Th020f01Form f01VO, Th020f01M1Form prevM1Vo ,LoginInfoVO logininfo)
		{
			String OraclePackageName = string.Empty;
			ArrayList paramList = new ArrayList();

			IDataList M1List = f01VO.GetList("M1");

			// 会社コード設定
			String sCopCd = string.Empty;

			// 店舗コード Dictionaryより取得
			string keyHeadTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

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

			sCopCd = Convert.ToDecimal(BoSystemString.Nvl(sCopCd, "0")).ToString();

			// [在庫検索選択]がエリア選択の場合
			if (ConditionZaiko_serchstk.VALUE_ZAIKO_SERCHSTK1.Equals(f01VO.Zaiko_serchstk))
			{
				OraclePackageName = Th020p01Constant.ORACLE_PACKAGE_ERA;
				// 会社コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_KAISYA_CD", OracleDbType.Decimal, ParameterDirection.Input, sCopCd);
				// エリアコード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_AREA_CD", OracleDbType.Char, ParameterDirection.Input, f01VO.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString());
				// 自社品番
				StoredProcedureCls.SetStoredParam(ref paramList, "V_JISHAHIN", OracleDbType.Char, ParameterDirection.Input, BoSystemFormat.formatJisyaHbn(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1JISYA_HBN].ToString()));
				// 色コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_IRO_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatIroCd(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD].ToString()));
			}
			// [在庫検索選択]がエリア選択以外の場合
			else
			{
				OraclePackageName = Th020p01Constant.ORACLE_PACKAGE_TENPO;
				// 会社コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_KAISYA_CD", OracleDbType.Decimal, ParameterDirection.Input, sCopCd);
				// エリアコード
				// [在庫検索選択]が、自エリア店別の場合のみ条件とする。
				if (ConditionZaiko_serchstk.VALUE_ZAIKO_SERCHSTK2.Equals(f01VO.Zaiko_serchstk))
				{
					StoredProcedureCls.SetStoredParam(ref paramList, "V_AREA_CD", OracleDbType.Char, ParameterDirection.Input, f01VO.Dictionary[Th020p01Constant.DIC_AREA_CD].ToString());

				}
				else
				{
					StoredProcedureCls.SetStoredParam(ref paramList, "V_AREA_CD", OracleDbType.Char, ParameterDirection.Input, string.Empty);
				}
				// 店舗コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_TENPO_CD", OracleDbType.Char, ParameterDirection.Input, keyHeadTenpoCd);
				// 自社品番
				StoredProcedureCls.SetStoredParam(ref paramList, "V_JISHAHIN", OracleDbType.Char, ParameterDirection.Input, BoSystemFormat.formatJisyaHbn(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1JISYA_HBN].ToString()));
				// 色コード
				StoredProcedureCls.SetStoredParam(ref paramList, "V_IRO_CD", OracleDbType.Varchar2, ParameterDirection.Input, BoSystemFormat.formatIroCd(prevM1Vo.Dictionary[Th020p01Constant.DIC_M1MAKERCOLOR_CD].ToString()));

			}

			// 処理呼び出し
			ArrayList rt = StoredProcedureCls.ExecStoredProcedure(facadeContext.DBContext, OraclePackageName, paramList);

			#region ■例外処理
			if (rt != null && rt.Count > 0)
			{
				// エラーコード
				string errCd = rt[0].ToString();

				if (errCd.Equals(BoSystemConstant.STORED_NOT_ERR))
				{
					// 正常終了
				}
				else
				{
					// それ以外の場合
					throw new SystemException("ストアド［" + OraclePackageName + "］実行時にエラーが発生しました。エラーコード：" + errCd);
				}
			}
			else
			{
				// OUTパラメータが取得できない場合
				throw new SystemException("ストアド［" + OraclePackageName + "］実行時にエラーが発生しました。");
			}
			#endregion

			return rt;
		}

		#endregion

		#region 明細標題設定

		/// <summary>
		/// 明細標題設定
		/// </summary>
		/// <returns>結果</returns>
		private String hyodaiEdit(Hashtable rec,  String size_nm_id)
		{
			return rec[size_nm_id].ToString();
		}

		#endregion

		#region 在庫数設定

		/// <summary>
		/// 在庫数設定
		/// </summary>
		/// <returns>結果</returns>
		private String zaikoSuEdit(Hashtable rec, String zaiko_su_id, String jan_id)
		{
			String zaiko_su = string.Empty;

			// JANコードが設定済みの場合設定
			if (!string.IsNullOrEmpty(rec[jan_id].ToString()))
			{
				zaiko_su = rec[zaiko_su_id].ToString();
			}

			return zaiko_su;
		}

		#endregion

		#endregion
	}
}
