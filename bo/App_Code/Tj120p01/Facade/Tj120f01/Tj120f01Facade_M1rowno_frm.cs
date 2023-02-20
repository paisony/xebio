using com.xebio.bo.Tj120p01.Constant;
using com.xebio.bo.Tj120p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tj120p01.Facade
{
  /// <summary>
  /// Tj120f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj120f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1rowno)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1rowno)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ROWNO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			//StartMethod(facadeContext, this.GetType().Name + ".DoM1ROWNO_FRM");

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
				Tj120f01Form prevVo = (Tj120f01Form)facadeContext.FormVO;
				Tj120f02Form nextVo = (Tj120f02Form)facadeContext.GetUserObject(Tj120p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");
				// 選択行の情報を取得する。
				Tj120f01M1Form prevM1Vo = (Tj120f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理

				decimal dGokeiscan_su = 0;	// 合計スキャン数量

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj120p01Constant.SQL_ID_03, facadeContext.DBContext);

				// バインド値の置き換え
				// T1.[店舗コード]	＝		Dictionary.[ヘッダ店舗コード]									
				// T1.[フェイス№]	=		選択行.Dictionary.[Ｍ１フェイス№]									
				// T1.[棚段]		=		選択行.Dictionary.[Ｍ１棚段]									
				// T1.[回数]		=		選択行.[Ｍ１回数]									
				// T1.[棚卸日]		=		選択行.Dictionary.[Ｍ１棚卸日]									
				// T1.[送信回数]	=		選択行.Dictionary.[Ｍ１送信回数]									

				// 店舗コード
				rtSeach.BindValue("BIND_TENPO_CD", BoSystemFormat.formatTenpoCd((String)(prevVo.Dictionary[SearchConditionSaveCls.PREFIX + Tj120p01Constant.DIC_TENPO_CD])));
				// フェイス№
				rtSeach.BindValue("BIND_FACE_NO", Convert.ToDecimal((string)prevM1Vo.Dictionary[Tj120p01Constant.DIC_M1FACE_NO]));
				// 棚段
				rtSeach.BindValue("BIND_TANA_DAN", Convert.ToDecimal((string)prevM1Vo.Dictionary[Tj120p01Constant.DIC_M1TANA_DAN]));
				// 回数
				rtSeach.BindValue("BIND_KAI_SU", Convert.ToDecimal((string)prevM1Vo.M1kai_su));
				// 棚卸日
				rtSeach.BindValue("BIND_TANAOROSI_YMD", Convert.ToDecimal((string)prevM1Vo.Dictionary[Tj120p01Constant.DIC_M1TANAOROSI_YMD]));
				// 送信回数
				rtSeach.BindValue("BIND_SOSINKAI_SU", Convert.ToDecimal((string)prevM1Vo.Dictionary[Tj120p01Constant.DIC_M1SOSINKAI_SU]));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

				if (tableList == null || tableList.Count <= 0)
				{
					// 対象件数が0件の場合、エラー
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

				#region 明細部設定
				foreach (Hashtable rec in tableList)
				{
					Tj120f02M1Form f02m1VO = new Tj120f02M1Form();
					// 明細項目設定
					f02m1VO.M1rowno				= rec["GYO_NBR"].ToString();			// Ｍ１行NO
					f02m1VO.M1bumon_cd			= rec["BUMON_CD"].ToString();			// Ｍ１部門コード
					f02m1VO.M1bumonkana_nm		= rec["BUMONKANA_NM"].ToString();		// Ｍ１部門カナ名
					f02m1VO.M1hinsyu_ryaku_nm	= rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
					f02m1VO.M1burando_nm		= rec["BURANDO_NMK"].ToString();		// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn			= rec["JISYA_HBN"].ToString();			// Ｍ１自社品番
					f02m1VO.M1maker_hbn			= rec["MAKER_HBN"].ToString();			// Ｍ１メーカー品番
					f02m1VO.M1syonmk			= rec["SYONMK"].ToString();				// Ｍ１商品名(カナ)
					f02m1VO.M1iro_nm			= rec["IRO_NM"].ToString();				// Ｍ１色
					f02m1VO.M1size_nm			= rec["SIZE_NM"].ToString();			// Ｍ１サイズ
					f02m1VO.M1scan_cd			= rec["JAN_CD"].ToString();				// Ｍ１スキャンコード
					f02m1VO.M1scan_su			= rec["TANAOROSIGOKEI_SU"].ToString();	// Ｍ１スキャン数量

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

					// 合計値加算
					dGokeiscan_su += Convert.ToDecimal(f02m1VO.M1scan_su);
				}
				#endregion

				#region カード部設定
				nextVo.Head_tenpo_cd = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + Tj120p01Constant.DIC_TENPO_CD].ToString();		// ヘッダ店舗コード
				nextVo.Head_tenpo_nm = prevVo.Dictionary[SearchConditionSaveCls.PREFIX + Tj120p01Constant.DIC_TENPO_NM].ToString();		// ヘッダ店舗名																					// ヘッダ店舗名
				nextVo.Modeno = prevVo.Modeno;																				// モードNO
				nextVo.Stkmodeno = prevVo.Stkmodeno;																		// 選択モードNO
				nextVo.Face_no = prevM1Vo.Dictionary[Tj120p01Constant.DIC_M1FACE_NO].ToString();							// フェイスNo
				nextVo.Tana_dan = prevM1Vo.Dictionary[Tj120p01Constant.DIC_M1TANA_DAN].ToString();							// 棚段
				nextVo.Kai_su = prevM1Vo.M1kai_su;																			// 回数
				nextVo.Nyuryokutan_cd = prevM1Vo.Dictionary[Tj120p01Constant.DIC_M1NYURYOKUTAN_CD].ToString();				// 入力担当者コード
				nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;															// 入力担当者名称
				nextVo.Nyuryoku_ymd = prevM1Vo.M1nyuryoku_ymd;																// 入力日

				// 選択明細のVO
				nextVo.Dictionary[Tj120p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tj120p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

				// 合計欄の設定
				nextVo.Gokeiscan_su = dGokeiscan_su.ToString();

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1ROWNO_FRM");

		}
		#endregion
	}
}
