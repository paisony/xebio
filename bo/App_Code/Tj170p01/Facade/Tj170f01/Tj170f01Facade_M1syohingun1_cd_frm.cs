using com.xebio.bo.Tj170p01.Constant;
using com.xebio.bo.Tj170p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Tj170p01.Facade
{
  /// <summary>
  /// Tj170f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj170f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1syohingun1_cd)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1syohingun1_cd)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1SYOHINGUN1_CD_FRM(IFacadeContext facadeContext)
		{
			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1SYOHINGUN1_CD_FRM");

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
				Tj170f01Form prevVo = (Tj170f01Form)facadeContext.FormVO;
				Tj170f02Form nextVo = (Tj170f02Form)facadeContext.GetUserObject(Tj170p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tj170f01M1Form prevM1Vo = (Tj170f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理
				FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(Tj170p01Constant.SQL_ID_03, facadeContext.DBContext);

				// テーブル設定
				AddFromF2(prevVo, rtSearch);
				// 
				AddHatyuMST(prevVo, rtSearch);
				// 検索条件設定
				AddWhereF2(prevVo, prevM1Vo, rtSearch);
				// ソート条件設定
				AddSortF2(prevVo, rtSearch);

				IList<Hashtable> tableList = rtSearch.Execute();
				BoSystemLog.logOut("SQL: " + rtSearch.LogSql);
				#region 件数チェック
				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
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
				#endregion

				#region 明細部設定

				int iCnt = 0;

				// 合計数計算
				Decimal dGokeitanajityobo_su	= 0;
				Decimal dGokeitanajisekiso_su	= 0;
				Decimal dGokeijitana_su			= 0;
				Decimal dGokeiloss_su			= 0;
				Decimal dGokeiloss_kin			= 0;
				Decimal dGokeiikoukebarai_su	= 0;
				Decimal dGokeirirontanaorosi_su = 0;
				Decimal dGokeiirironzaiko_su	= 0;
				
				foreach (Hashtable rec in tableList)
				{
					Tj170f02M1Form f02m1VO = new Tj170f02M1Form();
					if (iCnt == 0)
					{
						dGokeitanajityobo_su = (decimal)rec["GOKEI_TANAJITYOBO_SU"];
						dGokeitanajisekiso_su = (decimal)rec["GOKEI_TANAJISEKISO_SU"];
						dGokeijitana_su = (decimal)rec["GOKEI_JITANA_SU"];
						dGokeiloss_su = (decimal)rec["GOKEI_LOSS_SU"];
						dGokeiloss_kin = (decimal)rec["GOKEI_LOSS_KIN"];
						dGokeiikoukebarai_su = (decimal)rec["GOKEI_IKOUKEBARAI_SU"];
						dGokeirirontanaorosi_su = (decimal)rec["GOKEI_RIRONTANAOROSI_SU"];
						dGokeiirironzaiko_su = (decimal)rec["GOKEI_RIRONZAIKO_SU"];
					}
					iCnt++;
					f02m1VO.M1rowno = iCnt.ToString();									// Ｍ１行NO
					f02m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();					// Ｍ１部門コード									
					f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();			// Ｍ１部門カナ名									
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();		// Ｍ１品種略名称
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();				// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();					// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();					// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();						// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();						// Ｍ１サイズ
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();						// Ｍ１スキャンコード
					f02m1VO.M1genbaika_tnk = rec["GENBAIKA"].ToString();				// Ｍ１現売価									
					f02m1VO.M1hyoka_tnk = rec["HYOKA_TNK"].ToString();					// Ｍ１評価単価
					f02m1VO.M1tanajityobo_su = rec["TANAJITYOBO_SU"].ToString();		// Ｍ１棚時帳簿数
					f02m1VO.M1tanajisekiso_su = rec["TANAJISEKISO_SU"].ToString();		// Ｍ１棚時積送数
					f02m1VO.M1jitana_su = rec["JITANA_SU"].ToString();					// Ｍ１実棚数
					f02m1VO.M1ikoukebarai_su = rec["IKOUKEBARAI_SU"].ToString();		// Ｍ１以降受払数									
					f02m1VO.M1rironzaiko_su = rec["RIRONZAIKO_SU"].ToString();			// Ｍ１理論在庫数									
					f02m1VO.M1rirontanaorosi_su = rec["RIRONTANAOROSI_SU"].ToString();	// Ｍ１理論棚卸数									
					f02m1VO.M1loss_su = rec["LOSS_SU"].ToString();						// Ｍ１ロス数
					f02m1VO.M1loss_kin = rec["LOSS_KIN"].ToString();					// Ｍ１ロス金額
					f02m1VO.M1face_no = BoSystemString.ZeroToEmpty(rec["FACE_NO"].ToString());						// Ｍ１フェイス№									
					f02m1VO.M1tana_dan = BoSystemString.ZeroToEmpty(rec["TANA_DAN"].ToString());					// Ｍ１棚段		

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				
				}

				#endregion

				#region カード部設定

				nextVo.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)].ToString();		// ヘッダ店舗コード
				nextVo.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)].ToString();		// ヘッダ店舗名
				nextVo.Stkmodeno = prevVo.Stkmodeno;																				// 選択モード
				nextVo.Syohingun1_cd = BoSystemFormat.formatSyohingunCd(prevM1Vo.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_CD].ToString());
				nextVo.Syohingun1_ryaku_nm = prevM1Vo.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_RYAKU_NM].ToString();
				nextVo.Syohingun2_cd = BoSystemFormat.formatSyohingun2Cd(prevM1Vo.M1syohingun2_cd);
				nextVo.Grpnm = prevM1Vo.M1grpnm;
				nextVo.Gokeitanajityobo_su = dGokeitanajityobo_su.ToString();														// 合計棚時帳簿数
				nextVo.Gokeitanajisekiso_su = dGokeitanajisekiso_su.ToString();														// 合計棚時積送数
				nextVo.Gokeijitana_su = dGokeijitana_su.ToString();																	// 合計実棚数
				nextVo.Gokeiikoukebarai_su = dGokeiikoukebarai_su.ToString();														// 合計以降受払数
				nextVo.Gokeirirontanaorosi_su = dGokeirirontanaorosi_su.ToString();													// 合計論理棚卸数
				nextVo.Gokeirironzaiko_su = dGokeiirironzaiko_su.ToString();														// 合計論理在庫数
				nextVo.Gokeiloss_su = dGokeiloss_su.ToString();																		// 合計ロス数
				nextVo.Gokeiloss_kin = dGokeiloss_kin.ToString();																	// 合計ロス金額
			
				// VOをディクショナリに設定
				//nextVo.Dictionary[Tj170p01Constant.DIC_M1VO] = prevVo;
				// 選択明細のVO
				nextVo.Dictionary[Tj170p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tj170p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1SYOHINGUN1_CD_FRM");

		}
		#endregion
		#region ユーザー定義関数
		#region 検索条件設定
		/// <summary>
		///  条件設定
		/// </summary>
		/// <param name="Tj170f01Form">f01VO</param>
		/// <param name="">f01VO</param>
		/// <returns></returns>
		private void AddWhereF2(Tj170f01Form prevVo, Tj170f01M1Form prevM1Vo, FindSqlResultTable reader)
		{	
			for (int i = 1; i <= 9; i++)
			{
				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				StringBuilder sRepSql = new StringBuilder();
				#region 棚卸基準日
				string tanaoroshi_ymd = string.Empty;
				sRepSql.Append(" AND A.TANAOROSI_YMD = :BIND_TANAOROSI_YMD" + i.ToString());
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TANAOROSI_YMD" + i.ToString();
				if (prevVo.Stkmodeno.Equals(BoSystemConstant.MODE_KONKAI))
				{
					tanaoroshi_ymd = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Tanaorosikijun_ymd".ToUpper()];
				}
				else
				{
					tanaoroshi_ymd = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "Tanaorosikijun_ymd1".ToUpper()];
				}
				bindVO.Value = BoSystemFormat.formatDate(tanaoroshi_ymd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				#endregion
				#region M1商品群1コード
				sRepSql.Append("	AND A.SYOHINGUN1_CD   = :BIND_M1SYOHINGIN1_CD" + i.ToString());
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_M1SYOHINGIN1_CD" + i.ToString();
				bindVO.Value = prevM1Vo.Dictionary[Tj170p01Constant.DIC_M1SYOHINGUN1_CD].ToString();
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				#endregion
				#region M1商品群2コード
				if (!string.IsNullOrEmpty(prevM1Vo.M1syohingun2_cd))
				{
					sRepSql.Append("	AND A.SYOHINGUN2_CD   = :BIND_M1SYOHINGIN2_CD" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_M1SYOHINGIN2_CD" + i.ToString();
					bindVO.Value = prevM1Vo.M1syohingun2_cd.ToString();
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region M1部門コード
				if (!string.IsNullOrEmpty(prevM1Vo.M1bumon_cd))
				{
					sRepSql.Append("	AND A.BUMON_CD   = :BIND_BUMON_CD" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_BUMON_CD" + i.ToString();
					bindVO.Value = BoSystemFormat.formatBumonCd(prevM1Vo.M1bumon_cd);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region 店舗コード
				sRepSql.Append("	AND A.TENPO_CD   = :BIND_TENPO_CD" + i.ToString());
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD" + i.ToString();
				bindVO.Value = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"]);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);
				#endregion
				#region 商品群1
//				if (!string.IsNullOrEmpty((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN1_CD"]))
//				{
//					sRepSql.Append("	AND A.SYOHINGUN1_CD   = :BIND_SYOHINGIN1_CD" + i.ToString());
//					bindVO = new BindInfoVO();
//					bindVO.BindId = "BIND_SYOHINGIN1_CD" + i.ToString();
//					bindVO.Value = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN1_CD"];
//					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
//					bindList.Add(bindVO);
//				}
				#endregion
				#region 商品群2
				if (!string.IsNullOrEmpty((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN2_CD"]))
				{
					sRepSql.Append("	AND A.SYOHINGUN2_CD   = :BIND_SYOHINGIN2_CD" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_SYOHINGIN2_CD" + i.ToString();
					bindVO.Value = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "SYOHINGUN2_CD"];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region 部門コードFROM、品種コードFROM
				String sBumonCdFrom = BoSystemFormat.formatBumonCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "BUMON_CD_FROM"]);
				String sHInshuCdFrom = BoSystemFormat.formatHinsyuCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HINSYU_CD_FROM"]);
				// [部門コードFROM]が入力されていない場合"000"に置き換える。[品種コードFROM]が入力されていない場合"00"に置き換える。
				if (string.IsNullOrEmpty(sBumonCdFrom))
				{
					sBumonCdFrom = "000";
				}
				if (string.IsNullOrEmpty(sHInshuCdFrom))
				{
					sHInshuCdFrom = "00";
				}
				// [部門コードFROM]と[品種コードFROM]を文字結合した結果が"00000"以外の場合に条件とする。
				if (!"00000".Equals(sBumonCdFrom + sHInshuCdFrom))
				{
					sRepSql.Append(" AND (TRIM(TO_CHAR(A.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(A.HINSYU_CD,'00'),'00'))) >= :BIND_BUMON_FROM" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_BUMON_FROM" + i.ToString();
					bindVO.Value = sBumonCdFrom + sHInshuCdFrom;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region 部門コードTO、品種コードTO
				String sBumonCdTo = BoSystemFormat.formatBumonCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "BUMON_CD_TO"]);
				String sHInshuCdTo = BoSystemFormat.formatHinsyuCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HINSYU_CD_TO"]);
				// [部門コードTO]が入力されていない場合"000"に置き換える。[品種コードTO]が入力されていない場合"00"に置き換える。
				if (string.IsNullOrEmpty(sBumonCdTo))
				{
					sBumonCdTo = "999";
				}
				if (string.IsNullOrEmpty(sHInshuCdTo))
				{
					sHInshuCdTo = "99";
				}
				// [部門コードTO]と[品種コードTO]を文字結合した結果が"00000"以外の場合に条件とする。
				if (!"99999".Equals(sBumonCdTo + sHInshuCdTo))
				{
					sRepSql.Append(" AND (TRIM(TO_CHAR(A.BUMON_CD,'000')) || TRIM(TO_CHAR(NVL(A.HINSYU_CD,'00'),'00'))) <= :BIND_BUMON_TO" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_BUMON_TO" + i.ToString();
					bindVO.Value = sBumonCdTo + sHInshuCdTo;
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region ブランド
				if (!string.IsNullOrEmpty((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD"]))
				{
					sRepSql.Append("	AND A.BURANDO_CD   = :BIND_BURANDO_CD" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_BURANDO_CD" + i.ToString();
					bindVO.Value = BoSystemFormat.formatBumonCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "BURANDO_CD"]);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region ロス点数
				if (!string.IsNullOrEmpty((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "LOSS_TENSU"]))
				{
					sRepSql.Append("	AND ABS(A.LOSS_SU)  >= :BIND_LOSS_SU" + i.ToString());
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_LOSS_SU" + i.ToString();
					bindVO.Value = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "LOSS_TENSU"];
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);
				}
				#endregion
				#region ロス有フラグ
				if (((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "LOSS_ARI_FLG"]).Equals(ConditionSelect_flg.VALUE_ARI))
				{
					sRepSql.Append(" AND ( A.LOSS_SU <> 0 OR A.LOSS_KIN <> 0 ) ");
				}
				#endregion
				string replaceNm = Tj170p01Constant.REP_ADD_WHERE + i.ToString();
				BoSystemSql.AddSql(reader, replaceNm, sRepSql.ToString(), bindList);				
			}
		}
		#endregion

		#region テーブル設定
		/// <summary>
		///  条件設定
		/// </summary>
		/// <param name="Tj170f01Form">f01VO</param>
		/// <returns></returns>
		private void AddFromF2(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			StringBuilder sRepSql = new StringBuilder();
			// モード今回の場合
			if (BoSystemConstant.MODE_KONKAI.Equals(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Stkmodeno)].ToString()))
			{
				sRepSql.Append(" MDIT0100 ");
			}
			// モード前回の場合
			else
			{
				sRepSql.Append(" MDIT0101 ");
			}
			for (int i = 1; i <= 9; i++)
			{
				string replaceNm = Tj170p01Constant.SQL_ID_REP_TABLE + i.ToString();
				BoSystemSql.AddSql(reader, replaceNm, sRepSql.ToString());
			}
		}
		#endregion

		#region 発注マスタ設定
		/// <summary>
		///  条件設定
		/// </summary>
		/// <param name="Tj170f01Form">f01VO</param>
		/// <returns></returns>
		private void AddHatyuMST(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			StringBuilder sRepSql = new StringBuilder();
			// ソート順がメーカー品番の場合
			if ((f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Sort_jun)].ToString()).Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN4))
			{
				sRepSql.Append(" INNER JOIN MDMT0130 ");
				sRepSql.Append(" ON	A.JAN_CD = MDMT0130.JAN_CD ");
				BoSystemSql.AddSql(reader, Tj170p01Constant.REP_ADD_HATYUMST, sRepSql.ToString());
			}
		}
		#endregion

		#region ソート条件設定
		/// <summary>
		///  ソート条件設定
		/// </summary>
		/// <param name="Tj170f01Form">f01VO</param>
		/// <returns></returns>
		private void AddSortF2(Tj170f01Form f01VO, FindSqlResultTable reader)
		{
			#region 出力単位/ソート順
			StringBuilder sRepSql = new StringBuilder();
			string Shuturyoku_tani = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Shuturyoku_tani)].ToString();
			string Sort_jun = f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Sort_jun)].ToString();	
			sRepSql.Append(" ORDER BY ");
			// ■出力単位 1:商品群１
			if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI1))
			{
				// ○ソート順　1:商品分類順
				if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN1))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");

				}
				// ○ソート順　2:ロス数
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN2))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.LOSS_SU DESC");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
				}
				// ○ソート順　3:ロス金額
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN3))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.LOSS_KIN DESC");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
				}
				// ○ソート順　4:メーカー品番
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN4))
				{
					sRepSql.Append(" A.MAKER_HBN");
					sRepSql.Append(",MDMT0130.SIIRESAKI_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
					sRepSql.Append(",A.JAN_CD");
				}
			}
			// ■出力単位  2:商品群２
			else if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI2))
			{
				// ○ソート順　1:商品分類順
				if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN1))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
				}
				// ○ソート順　2:ロス数
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN2))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.LOSS_SU DESC");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
				}
				// ○ソート順　3:ロス金額
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN3))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.LOSS_KIN DESC");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
				}
				// ○ソート順　4:メーカー品番
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN4))
				{
					sRepSql.Append(" A.MAKER_HBN");
					sRepSql.Append(",MDMT0130.SIIRESAKI_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
					sRepSql.Append(",A.JAN_CD");
				}
			}
			// ■出力単位 3:部門
			else if (Shuturyoku_tani.Equals(ConditionShuturyoku_tani.VALUE_SHUTURYOKU_TANI3))
			{
				// ○ソート順　1:商品分類順
				if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN1))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
				}
				// ○ソート順　2:ロス数
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN2))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.LOSS_SU DESC");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
				}
				// ○ソート順　3:ロス金額
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN3))
				{
					sRepSql.Append(" A.SYOHINGUN1_CD");
					sRepSql.Append(",A.SYOHINGUN2_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.LOSS_KIN DESC");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.MAKER_HBN");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
				}
				// ○ソート順　4:メーカー品番
				else if (Sort_jun.Equals(ConditionMeisai_sort_tj170f01.VALUE_SORT_JUN4))
				{
					sRepSql.Append(" A.MAKER_HBN");
					sRepSql.Append(",MDMT0130.SIIRESAKI_CD");
					sRepSql.Append(",A.BURANDO_CD");
					sRepSql.Append(",A.BUMON_CD");
					sRepSql.Append(",A.HINSYU_CD");
					sRepSql.Append(",A.IRO_CD");
					sRepSql.Append(",A.SIZE_CD");
					sRepSql.Append(",A.JAN_CD");
				}
			}

			BoSystemSql.AddSql(reader, Tj170p01Constant.REP_ADD_ORDER_BY, sRepSql.ToString());
			#endregion
		}
		#endregion
		#endregion

	}
}
