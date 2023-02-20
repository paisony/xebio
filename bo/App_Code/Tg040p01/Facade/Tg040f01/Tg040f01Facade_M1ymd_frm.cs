using com.xebio.bo.Tg040p01.Constant;
using com.xebio.bo.Tg040p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LabelUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tg040p01.Facade
{
  /// <summary>
  /// Tg040f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tg040f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1ymd)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1ymd)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1YMD_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1YMD_FRM");

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
				Tg040f01Form prevVo = (Tg040f01Form)facadeContext.FormVO;
				Tg040f02Form nextVo = (Tg040f02Form)facadeContext.GetUserObject(Tg040p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");

				// 選択行の情報を取得する。
				Tg040f01M1Form prevM1Vo = (Tg040f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();
				#endregion

				#region 検索処理
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tg040p01Constant.SQL_ID_02, facadeContext.DBContext);

				// バインド値の置き換え
				// 処理日付
				rtSeach.BindValue(Tg040p01Constant.REP_SYORI_YMD, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tg040p01Constant.DIC_SYORI_YMD]));
				// 管理No
				rtSeach.BindValue(Tg040p01Constant.REP_KANRI_NO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tg040p01Constant.DIC_KANRI_NO]));
				// 店舗コード
				rtSeach.BindValue(Tg040p01Constant.REP_TENPO_CD, BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"]));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();
				#endregion

				#region 件数チェック
				// 検索件数が0件の場合エラー
				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 画面の表示
				int iCnt = 0;
				decimal dSumSuryo = 0;	// 合計数量

				String xebiocd = (string)prevVo.Dictionary[Tg040p01Constant.DIC_SEARCH_XEBIOCD];
				String scanCd = (string)prevVo.Dictionary[Tg040p01Constant.DIC_SEARCH_JANCD];

				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tg040f02M1Form f02m1VO = new Tg040f02M1Form();

					f02m1VO.M1rowno = iCnt.ToString();									// Ｍ１行NO
					f02m1VO.M1bumon_cd = rec["BUMON_CD"].ToString();					// Ｍ１部門コード
					f02m1VO.M1bumonkana_nm = rec["BUMONKANA_NM"].ToString();			// Ｍ１部門カナ名
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();		// Ｍ１品種略名称
					f02m1VO.M1burando_nm = rec["BURANDO_NMK"].ToString();				// Ｍ１ブランド名
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();					// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();					// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();						// Ｍ１商品名(カナ)
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();						// Ｍ１スキャンコード
					f02m1VO.M1hanbaikanryo_ymd = rec["HANBAIKANRYO_YMD"].ToString();	// Ｍ１販売完了日
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();						// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();						// Ｍ１サイズ
					f02m1VO.M1suryo = rec["YOTEI_SU"].ToString();						// Ｍ１数量
					f02m1VO.M1suryo_hdn = rec["YOTEI_SU"].ToString();					// Ｍ１数量_隠し
					f02m1VO.M1hinsyu_cd = rec["HINSYU_CD"].ToString();					// Ｍ１品種コード

					// 合計値加算
					dSumSuryo += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1suryo, "0"));

					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;			// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;		// Ｍ１確定処理フラグ(隠し)
					// 検索条件の自社品番、スキャンコードと一致する場合
					if (f02m1VO.M1scan_cd.Equals(scanCd) || f02m1VO.M1jisya_hbn.Equals(xebiocd))
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)
					}
					else
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
					}

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				}

				#region カード部設定
				nextVo.Head_tenpo_cd = prevVo.Head_tenpo_cd;	// ヘッダ店舗コード
				nextVo.Head_tenpo_nm = prevVo.Head_tenpo_nm;	// ヘッダ店舗名
				nextVo.Stkmodeno = prevVo.Stkmodeno;			// 選択モードNO
				nextVo.Gokei_suryo = dSumSuryo.ToString();		// 合計数量

				nextVo.Stock_no = prevM1Vo.M1stock_no.ToString();									// ストックNo
				nextVo.Ymd = (string) prevM1Vo.Dictionary[Tg040p01Constant.DIC_M1YMD];				// 日付
				nextVo.Tm = prevM1Vo.M1tm.ToString();												// 時間
				nextVo.Nyuryokutan_cd = (string)prevM1Vo.Dictionary[Tg040p01Constant.DIC_TANCD];	// 入力担当者コード
				nextVo.Nyuryokutan_nm = prevM1Vo.M1hanbaiin_nm.ToString();							// 入力担当者名

				// Ｍ１管理№
				nextVo.Dictionary[Tg040p01Constant.DIC_KANRI_NO] = prevM1Vo.Dictionary[Tg040p01Constant.DIC_KANRI_NO].ToString();
				// Ｍ１処理日付
				nextVo.Dictionary[Tg040p01Constant.DIC_SYORI_YMD] = prevM1Vo.Dictionary[Tg040p01Constant.DIC_SYORI_YMD].ToString();
				// Ｍ１処理時間
				nextVo.Dictionary[Tg040p01Constant.DIC_SYORI_TM] = prevM1Vo.Dictionary[Tg040p01Constant.DIC_SYORI_TM].ToString();
				// 更新日
				nextVo.Dictionary[Tg040p01Constant.DIC_UPD_YMD] = prevM1Vo.Dictionary[Tg040p01Constant.DIC_UPD_YMD].ToString();
				// 更新時間
				nextVo.Dictionary[Tg040p01Constant.DIC_UPD_TM] = prevM1Vo.Dictionary[Tg040p01Constant.DIC_SYORI_TM].ToString();

				// 選択明細のVO
				nextVo.Dictionary[Tg040p01Constant.FCDUO_FOCUSITEM] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tg040p01Constant.FCDUO_FOCUSROW] = facadeContext.CommandInfo.ListIndex.ToString();

				// ラベル情報を設定
				BoSystemLabelUtil.SetLabelInfo<Tg040f02Form>(nextVo, facadeContext);
				#endregion

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1YMD_FRM");

		}
		#endregion
	}
}
