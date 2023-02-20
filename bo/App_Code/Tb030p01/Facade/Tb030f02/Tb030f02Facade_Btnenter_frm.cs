using com.xebio.bo.Tb030p01.Constant;
using com.xebio.bo.Tb030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01020;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V01000.V01015;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using System;
using System.Collections;

namespace com.xebio.bo.Tb030p01.Facade
{
  /// <summary>
  /// Tb030f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tb030f02Facade : StandardBaseFacade
	{
		
		#region フォームを呼び出します。(ボタンID : Btnenter)
		/// <summary>
		/// フォームを呼び出します。
		/// ボタンID(Btnenter)
		/// アクションID(FRM)
		/// の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoBTNENTER_FRM(IFacadeContext facadeContext)
		{
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			////メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

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
				Tb030f02Form f02VO = (Tb030f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧画面選択行のVO
				Tb030f01M1Form f01M1Form = (Tb030f01M1Form)f02VO.Dictionary[Tb030p01Constant.DIC_M1SELCETVO];

				#endregion

				#region 業務チェック

				decimal warninngFlg = Convert.ToDecimal(BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as string, "0"));
				if (warninngFlg != 1)
				{
					#region 入力値チェック

					for (int i = 0; i < m1List.Count; i++)
					{
						Tb030f02M1Form f02m1VO = (Tb030f02M1Form)m1List[i];

						// 納品数＜検数の場合エラー
						if (!string.IsNullOrEmpty(f02m1VO.M1kensu)
							&& Convert.ToDecimal(f02m1VO.M1nohin_su) < Convert.ToDecimal(f02m1VO.M1kensu))
						{
							ErrMsgCls.AddErrMsg("E109", new[] { "検数", "納品数" }, facadeContext, new[] { "M1kensu" }, f02m1VO.M1rowno, i.ToString(), "M1");
						}
					}

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (MessageDisplayUtil.HasError(facadeContext))
					{
						return;
					}
					#endregion

					#region 警告チェック
					for (int i = 0; i < m1List.Count; i++)
					{
						Tb030f02M1Form f02m1VO = (Tb030f02M1Form)m1List[i];

						// 納品数＞検数の場合、警告
						if (!string.IsNullOrEmpty(f02m1VO.M1kensu)
							&& Convert.ToDecimal(f02m1VO.M1nohin_su) > Convert.ToDecimal(f02m1VO.M1kensu))
						{
							InfoMsgCls.AddWarnMsg("W118", String.Empty, facadeContext, new[] { "M1kensu" }, f02m1VO.M1rowno, i.ToString(), "M1");
						}
					}

					// ------------------------------------------------------------------------------------
					// ワーニングが発生した場合、その時点でチェックを中止しクライアント側へワーニング内容を返却する。
					// ------------------------------------------------------------------------------------
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}

					#endregion

				}

				#endregion

				#region 仕入共通データ格納

				// 仕入共通部品更新用配列
				TbCommonConfirmReg commonReg = new TbCommonConfirmReg(facadeContext, logininfo);
				TbCommonRegVO regVO = new TbCommonRegVO();
				ArrayList regMeisaiDataList = new ArrayList();

				// 行番号
				regVO.Gyo_no = "0";

				// 明細番号
				regVO.Rowno = "0";

				// 仕入先コード
				regVO.Siiresaki_cd = f02VO.Siiresaki_cd;

				// 伝票番号
				regVO.Denpyo_bango = f02VO.Denpyo_bango;

				// 入荷予定日
				regVO.Nyukayotei_ymd = BoSystemFormat.formatDate(f02VO.Nyukayotei_ymd);

				// 店舗コード
				regVO.Tenpo_cd = f02VO.Head_tenpo_cd;

				// 納品書日付
				regVO.Nohinsyo_ymd = (string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1NOHINSYO_YMD];

				// 部門コード
				regVO.Bumon_cd = f02VO.Bumon_cd;

				// サブ仕入先コード
				regVO.Subsiiresaki_cd = (string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1SUBSIIRESAKI_CD];

				// 仕入予定合計数量
				regVO.Siireyoteigokei_su = (string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1SIIREYOTEIGOKEI_SU];

				// 仕入予定合計金額
				regVO.Siireyoteigokei_kin = (string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1SIIREYOTEIGOKEI_KIN];

				// 更新日
				regVO.Upd_ymd = (string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1UPD_YMD];

				// 更新時間
				regVO.Upd_tm = (string)f01M1Form.Dictionary[Tb030p01Constant.DIC_M1UPD_TM];

				// 仕入共通部品更新用明細配列
				for (int i = 0; i < m1List.Count; i++)
				{
					Tb030f02M1Form f02m1VO = (Tb030f02M1Form)m1List[i];

					TbCommonRegMeisaiVO regMeisaiVO = new TbCommonRegMeisaiVO();

					// 伝票行No
					regMeisaiVO.Denpyogyo_no = f02m1VO.M1rowno;

					// スキャンコード
					regMeisaiVO.Scan_cd = f02m1VO.M1scan_cd;

					// 実績数
					if(string.IsNullOrEmpty(f02m1VO.M1kensu))
					{
						regMeisaiVO.Jisseki_su = f02m1VO.M1nohin_su;
					}
					else
					{
						regMeisaiVO.Jisseki_su = f02m1VO.M1kensu;
					}

					// 原単価
					regMeisaiVO.Gen_tnk = f02m1VO.M1gen_tnk;

					regMeisaiDataList.Add(regMeisaiVO);

				}

				// 明細の設定
				regVO.SetList("M1", regMeisaiDataList);

				commonReg.AddList(regVO);

				#endregion

				// [選択モードNo]が「仕入確定」（共通引数が0以上）の場合、共通部品で更新を行う。
				if (commonReg.GetListCnt() > 0)
				{
					#region 仕入確定排他処理

					//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
					if (commonReg.isCheckHaita())
					{
						return;
					}

					#endregion

					#region 仕入確定更新処理

					commonReg.updData();

					#endregion

					#region 一覧画面項目の設定

					// M１伝票状態の取得
					Hashtable tmpMeisho = V01015Check.CheckMeisyo(
																  BoSystemConstant.MEISYOMST_SIKIBETSU_SKST,	// 識別コード（伝票状態）
																  "1",											// 名称コード（確定）
																  facadeContext
																  );

					f01M1Form.M1denpyo_jyotainm = tmpMeisho["MEISYO_NM"].ToString();

					// Ｍ１仕入確定日の設定
					f01M1Form.M1siire_kakutei_ymd = BoSystemFormat.formatDate(((TbCommonRegVO)commonReg.GetList()[0]).Upd_ymd);
					// Ｍ１確定担当者コードの設定
					f01M1Form.Dictionary[Tb030p01Constant.DIC_M1FIXED_TANCD] = BoSystemFormat.formatTantoCd(logininfo.TtsCd);
					// Ｍ１確定担当者名称の設定
					f01M1Form.M1kakuteitan_nm = logininfo.TtsMei;


					// 合計金額、合計数の設定
					f01M1Form.M1itemsu = ((TbCommonRegVO)commonReg.GetList()[0]).Siirejissekigokei_su;
					f01M1Form.M1genka_kin = ((TbCommonRegVO)commonReg.GetList()[0]).Siirejissekigokei_kin;

					// 確定フラグの設定
					f01M1Form.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;
					#endregion
				}
				
				
				//トランザクションをコミットする。
				CommitTransaction(facadeContext);
			}
			catch (System.Exception ex)
			{
				//トランザクションをロールバックする。
				RollbackTransaction(facadeContext);
				//例外処理を実行する。
				ThrowException(ex, facadeContext);
			}
			finally
			{
				//コネクションを開放する。
				CloseConnection(facadeContext);
			}
			//メソッドの終了処理を実行する。
			EndMethod(facadeContext, this.GetType().Name + ".DoBTNENTER_FRM");

		}
		#endregion
	}
}
