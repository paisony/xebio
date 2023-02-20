using com.xebio.bo.Tf030p01.Constant;
using com.xebio.bo.Tf030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Tf030p01.Facade
{
  /// <summary>
  /// Tf030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tf030f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1denpyo_bango)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1denpyo_bango)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1DENPYO_BANGO_FRM(IFacadeContext facadeContext)
		{

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				BoSystemLog.logOut("");
				#region 初期化

				// FormVO取得
				// 画面より情報を取得する。
				Tf030f01Form prevVo = (Tf030f01Form)facadeContext.FormVO;
				Tf030f02Form nextVo = (Tf030f02Form)facadeContext.GetUserObject(Tf030p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");
				// 選択行の情報を取得する。
				Tf030f01M1Form prevM1Vo = (Tf030f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 検索処理

				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tf030p01Constant.SQL_ID_03, facadeContext.DBContext);

				// バインド値の置き換え
				// 伝票番号
				rtSeach.BindValue(Tf030p01Constant.REP_DENPYO_BANGO, Convert.ToDecimal((string)prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1DENPYO_BANGO]));
				// 処理日付
				rtSeach.BindValue(Tf030p01Constant.REP_SYORI_YMD, Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.M1add_ymd)));
				// 店舗コード
				rtSeach.BindValue(Tf030p01Constant.REP_TENPO_CD, BoSystemFormat.formatTenpoCd(prevM1Vo.M1tenpo_cd));

				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				#region 検索件数チェック
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

				decimal dSuryoSum = 0;	// 数量合計
				decimal dKinSum = 0;	// 原価金額合計

				int iCnt = 0;
				foreach (Hashtable rec in tableList)
				{
					iCnt++;
					Tf030f02M1Form f02m1VO = new Tf030f02M1Form();

					f02m1VO.M1rowno = iCnt.ToString();								// Ｍ１行NO
					f02m1VO.M1tekiyo_cd = rec["TEKIYO_CD"].ToString();				// Ｍ１摘要コード
					f02m1VO.M1tekiyo_nm = rec["TEKIYO_NM"].ToString();				// Ｍ１摘要名
					f02m1VO.M1suryo = rec["SURYO"].ToString();						// Ｍ１数量
					f02m1VO.M1tnk = rec["TNK"].ToString();							// Ｍ１単価
					f02m1VO.M1kingaku = rec["KINGAKU"].ToString();					// Ｍ１金額
					f02m1VO.M1suryo_hdn = rec["SURYO"].ToString();					// Ｍ１数量(隠し)
					f02m1VO.M1kingaku_hdn = rec["KINGAKU"].ToString();				// Ｍ１金額(隠し)
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
					f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;		// Ｍ１明細色区分(隠し)

					// 合計値加算
					dSuryoSum += Convert.ToDecimal(f02m1VO.M1suryo);
					dKinSum += Convert.ToDecimal(f02m1VO.M1kingaku);

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);
				}

				// 合計欄の設定
				nextVo.Gokei_suryo = dSuryoSum.ToString();
				nextVo.Gokei_kin = dKinSum.ToString();

				#region カード部設定

				// ヘッダ店舗コード（検索押下時の内容）
				nextVo.Head_tenpo_cd = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)];
				// ヘッダ店舗名（検索押下時の内容）
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];
				// 選択モードNO（検索押下時の内容）
				nextVo.Stkmodeno = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Stkmodeno)];

				// 登録日
				nextVo.Add_ymd = prevM1Vo.M1add_ymd;
				// 店舗コード
				nextVo.Tenpo_cd = prevM1Vo.M1tenpo_cd;
				// 店舗名
				nextVo.Tenpo_nm = prevM1Vo.M1tenpo_nm;
				// 検品者コード
				nextVo.Kenpinsya_cd = (string)prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1KENPINSYA_CD];
				// 検品者名称
				nextVo.Kenpinsya_nm = (string)prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1KENPINSYA_NM];
				// 仕入先コード
				nextVo.Siiresaki_cd = prevM1Vo.M1siiresaki_cd;
				// 仕入先名
				nextVo.Siiresaki_ryaku_nm = prevM1Vo.M1siiresaki_ryaku_nm;
				// 伝票番号
				nextVo.Denpyo_bango = (string)prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1DENPYO_BANGO];
				// 元伝票番号
				nextVo.Motodenpyo_bango = prevM1Vo.M1motodenpyo_bango;
				// 入力担当者コード
				nextVo.Nyuryokutan_cd = (string)prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1NYURYOKUTAN_CD];
				// 入力担当者名
				nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;
				// 納品日
				nextVo.Nohin_ymd = prevM1Vo.M1nohin_ymd;

				// Dictionary
				// 変更前の店舗コード
				nextVo.Dictionary[Tf030p01Constant.DIC_MOTO_TENPO_CD] = prevM1Vo.M1tenpo_cd;
				// 処理日付
				nextVo.Dictionary[Tf030p01Constant.DIC_SYORI_YMD] = prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1SYORI_YMD];
				// 処理時間
				nextVo.Dictionary[Tf030p01Constant.DIC_SYORI_TM] = prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1SYORI_TM];
				// 更新日
				nextVo.Dictionary[Tf030p01Constant.DIC_UPD_YMD] = prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1UPD_YMD];
				// 更新時間
				nextVo.Dictionary[Tf030p01Constant.DIC_UPD_TM] = prevM1Vo.Dictionary[Tf030p01Constant.DIC_M1UPD_TM];

				// 選択明細のVO
				nextVo.Dictionary[Tf030p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Tf030p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

		}
		#endregion
	}
}
