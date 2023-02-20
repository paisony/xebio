using com.xebio.bo.Td010p01.Constant;
using com.xebio.bo.Td010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace com.xebio.bo.Td010p01.Facade
{
  /// <summary>
  /// Td010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Td010f01Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : M1kanri_no)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(M1kanri_no)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1KANRI_NO_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1KANRI_NO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				BeginTransactionWithConnect(facadeContext);

				//以下に業務ロジックを記述する。
				logger.Debug("");
				#region 初期化

				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Td010f01Form prevVo = (Td010f01Form)facadeContext.FormVO;
				Td010f02Form nextVo = (Td010f02Form)facadeContext.GetUserObject(Td010p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");
				// 選択行の情報を取得する。
				Td010f01M1Form prevM1Vo = (Td010f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();

				#endregion

				#region 業務チェック
				#endregion

				#region 検索処理

				// [選択モードNO]が「返品確定」「確定前修正」「確定前取消」の場合、返品予定テーブルから検索する。
				string sSqlId = "";
				if (prevVo.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
					|| prevVo.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
					|| prevVo.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					sSqlId = Td010p01Constant.SQL_ID_04;
				}
				else
				{
					sSqlId = Td010p01Constant.SQL_ID_05;
				}
				FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(sSqlId, facadeContext.DBContext);

				// バインド値の置き換え
				// [選択モードNO]が「返品確定」「確定前修正」「確定前取消」の場合、
				if (prevVo.Modeno.Equals(BoSystemConstant.MODE_HENPINKAKUTEI)
					|| prevVo.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEUPD)
					|| prevVo.Modeno.Equals(BoSystemConstant.MODE_KAKUTEIMAEDEL))
				{
					// 管理No
					rtSeach.BindValue(Td010p01Constant.SQL_ID_04_REP_KANRI_NO, Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Td010p01Constant.DIC_M1KANRI_NO], "0")));
				}
				else
				{
					// 伝票番号
					rtSeach.BindValue(Td010p01Constant.SQL_ID_04_REP_DENPYO_BANGO, Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Td010p01Constant.DIC_M1DENPYO_BANGO].ToString(), "0")));
				}
				// 処理日付
				rtSeach.BindValue(Td010p01Constant.SQL_ID_04_REP_SYORI_YMD, Convert.ToDecimal(BoSystemString.Nvl((string)prevM1Vo.Dictionary[Td010p01Constant.DIC_M1SYORI_YMD], "0")));
				// 店舗コード
				rtSeach.BindValue(Td010p01Constant.SQL_ID_04_REP_TENPO_CD, (string)prevM1Vo.Dictionary[Td010p01Constant.DIC_M1TENPO_CD]);


				
				//検索結果を取得します
				rtSeach.CreateDbCommand();
				IList<Hashtable> tableList = rtSeach.Execute();

				#region 件数チェック

				if (0 == tableList.Count)
				{
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
				foreach (Hashtable rec in tableList)
				{
					Td010f02M1Form f02m1VO = new Td010f02M1Form();

					f02m1VO.M1rowno = rec["DENPYOGYO_NO"].ToString();				// Ｍ１行NO
					f02m1VO.M1hinsyu_ryaku_nm = rec["HINSYU_RYAKU_NM"].ToString();	// Ｍ１品種略名称
					f02m1VO.M1jisya_hbn = rec["JISYA_HBN"].ToString();				// Ｍ１自社品番
					f02m1VO.M1maker_hbn = rec["MAKER_HBN"].ToString();				// Ｍ１メーカー品番
					f02m1VO.M1syonmk = rec["SYONMK"].ToString();					// Ｍ１商品名(カナ)
					f02m1VO.M1iro_nm = rec["IRO_NM"].ToString();					// Ｍ１色
					f02m1VO.M1size_nm = rec["SIZE_NM"].ToString();					// Ｍ１サイズ
					f02m1VO.M1scan_cd = rec["JAN_CD"].ToString();					// Ｍ１スキャンコード
					f02m1VO.M1suryo = rec["SURYO"].ToString();						// Ｍ１数量
					f02m1VO.M1gen_tnk = rec["GEN_TNK"].ToString();					// Ｍ１原単価
					f02m1VO.M1genkakin = rec["GENKA_KIN"].ToString();				// Ｍ１原価金額
					f02m1VO.M1suryo_hdn = f02m1VO.M1suryo;							// Ｍ１数量(隠し)
					f02m1VO.M1genkakin_hdn = f02m1VO.M1genkakin;					// Ｍ１原価金額(隠し)
					f02m1VO.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;		// Ｍ１選択フラグ(隠し)
					f02m1VO.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_NASI;	// Ｍ１確定処理フラグ(隠し)
					string jancd = (string)prevVo.Dictionary[Td010p01Constant.DIC_SEARCH_JANCD];
					if (jancd.Equals(f02m1VO.M1scan_cd))
					{
						// 一覧画面で入力されたスキャンコードが一致する場合、背景色変更
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_SHOHIN_SHITEI;	// Ｍ１明細色区分(隠し)
					}
					else
					{
						f02m1VO.M1dtlirokbn = ConditionMeisaiiro_kbn.VALUE_NOMAL;			// Ｍ１明細色区分(隠し)
					}

					// 合計値加算
					dSuryoSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1suryo, "0"));
					dKinSum += Convert.ToDecimal(BoSystemString.Nvl(f02m1VO.M1genkakin, "0"));

					//リストオブジェクトにM1Formを追加します。
					nextM1List.Add(f02m1VO, true);

				}

				// 合計欄の設定
				nextVo.Gokei_suryo = dSuryoSum.ToString();
				nextVo.Genka_kin_gokei = dKinSum.ToString();


				#region カード部設定
				// ヘッダ店舗コード
				//nextVo.Head_tenpo_cd = prevVo.Head_tenpo_cd;
				nextVo.Head_tenpo_cd = BoSystemFormat.formatTenpoCd((string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_cd)]);
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.GetKey(() => prevVo.Head_tenpo_nm)];
				// 選択モードNO
				nextVo.Stkmodeno = prevVo.Stkmodeno;

				// 指示番号
				nextVo.Siji_bango = prevM1Vo.M1siji_bango;
				// 管理番号
				nextVo.Kanri_no = (string) prevM1Vo.Dictionary[Td010p01Constant.DIC_M1KANRI_NO];
				// 伝票番号
				nextVo.Denpyo_bango = prevM1Vo.Dictionary[Td010p01Constant.DIC_M1DENPYO_BANGO].ToString();
				// 仕入先コード
				nextVo.Siiresaki_cd = prevM1Vo.M1siiresaki_cd;
				// 仕入先名
				nextVo.Siiresaki_ryaku_nm = prevM1Vo.M1siiresaki_ryaku_nm;
				// 入力担当者コード
				nextVo.Nyuryokutan_cd = (string)prevM1Vo.Dictionary[Td010p01Constant.DIC_M1TANTOSYA_CD];
				// 入力担当者名
				nextVo.Nyuryokutan_nm = prevM1Vo.M1nyuryokutan_nm;
				// 部門コード
				nextVo.Bumon_cd = prevM1Vo.M1bumon_cd;
				// 部門名
				nextVo.Bumon_nm = (string)prevM1Vo.Dictionary[Td010p01Constant.DIC_M1BUMON_NM];
				// ブランドコード
				nextVo.Burando_cd = (string)prevM1Vo.Dictionary[Td010p01Constant.DIC_M1BURANDO_CD];
				// ブランド名
				nextVo.Burando_nm = prevM1Vo.M1burando_nm;
				// 返品理由
				nextVo.Henpin_riyu_nm = prevM1Vo.M1henpin_riyu_nm;
				// 返品確定日
				nextVo.Henpin_kakutei_ymd = prevM1Vo.M1henpin_kakutei_ymd;
				// 登録日
				nextVo.Add_ymd = prevM1Vo.M1add_ymd;

				// 選択明細のVO
				nextVo.Dictionary[Td010p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Td010p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
				
				#endregion

				#endregion

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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1KANRI_NO_FRM");

		}
		#endregion
	}
}
