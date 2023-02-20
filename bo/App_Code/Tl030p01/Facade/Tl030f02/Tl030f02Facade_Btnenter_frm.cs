using com.xebio.bo.Tl030p01.Constant;
using com.xebio.bo.Tl030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C99999.ApiUtil;
using Common.Business.C99999.ApiUtil.Ncr050a01;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tl030p01.Facade
{
  /// <summary>
  /// Tl030f02のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tl030f02Facade : StandardBaseFacade
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
				Tl030f02Form f02VO = (Tl030f02Form)facadeContext.FormVO;
				IDataList m1List = f02VO.GetList("M1");

				// 一覧の選択行情報を取得
				Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				#endregion

				#region 業務チェック

				#region 入力値チェック

				// 1-1 Ｍ１承認状態、Ｍ１却下フラグ
				// すべて選択されていない場合エラー
				if (m1List == null || m1List.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
				}
				else
				{
					bool checkErrflg = true;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tl030f02M1Form f02m1VO = (Tl030f02M1Form)m1List[i];
						if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_SYONIN)
							|| jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_KYAKKA))
						{
							checkErrflg = false;
							break;
						}
					}
					if (checkErrflg)
					{
						ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 明細チェック(入力値チェック)

				for (int i = 0; i < m1List.Count; i++)
				{

					Tl030f02M1Form f02m1VO = (Tl030f02M1Form)m1List[i];

					// 1-2 Ｍ１確定売価
					// 入力されていない場合、エラー
					bool inputErrflg = false;

					if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_KAKUTEI)
						|| jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_NORMAL))
					{
						// チェックボックス未選択行と確定行は処理しない
						continue;
					}
					else if (string.IsNullOrEmpty(f02m1VO.M1kakuteibaika_tnk))
					{
						inputErrflg = true;
					}

					if (inputErrflg)
					{
						ErrMsgCls.AddErrMsg("E121",
											"確定売価",
											facadeContext,
											new[] { "M1kakuteibaika_tnk" },
											f02m1VO.M1rowno,
											(i).ToString(),
											"M1");
					}
					else
					{
						decimal yoboBaika = Convert.ToDecimal(f02m1VO.M1yobobaika_tnk);
						decimal kauteiBaika = Convert.ToDecimal(f02m1VO.M1kakuteibaika_tnk);
						decimal jodai = Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JODAI1_TNK].ToString());

						// 1-3 Ｍ１確定売価
						// [Ｍ１要望売価]＞[Ｍ１確定売価]の場合、エラー
						if (yoboBaika > kauteiBaika)
						{
							ErrMsgCls.AddErrMsg("E137",
												string.Empty,
												facadeContext,
												new[] { "M1kakuteibaika_tnk" },
												f02m1VO.M1rowno,
												(i).ToString(),
												"M1");
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 明細チェック(関連チェック)

				// 1-5 Ｍ１承認状態
				// 一覧の対象行.[申請元区分]="2"(店舗判断)で、チェックされた明細が、作業開始日～開始日の売変指示の場合、エラー
				if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
				{
					// 承認対象が存在しない場合チェックしない
					bool changeRangeFlg  =false;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tl030f02M1Form f02m1VO = (Tl030f02M1Form)m1List[i];
						if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_SYONIN))
						{
							changeRangeFlg = true;
							break;
						}
					}
					if (changeRangeFlg)
					{
						if (PricechangeRangeChk(facadeContext, f02VO, sysDateVO) == -1)
						{
							ErrMsgCls.AddErrMsg("W108", string.Empty, facadeContext);
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 明細チェック(警告)
				// 2-1 選択状態
				// 確定データにカラー別売変不可商品が含まれている場合警告表示

				// 警告メッセージの応答結果を取得
				string waningFlg = BoSystemString.Nvl(facadeContext.GetUserObject(BoSystemConstant.WARNING_FCD_KEY) as String, "0");

				if (!waningFlg.Equals("1"))
				{
					bool colorSyohinFlg = false;

					for (int i = 0; i < m1List.Count; i++)
					{
						// 一覧の対象行.[Ｍ１旧自社品番カラー展開フラグ] ="1"、
						// 一覧の対象行.[Ｍ１自社品番件数] >1の明細で、
						// [Ｍ１承認状態]が1の場合、警告メッセージを表示する。
						Tl030f02M1Form f02m1VO = (Tl030f02M1Form)m1List[i];
						if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_SYONIN)
							&& ("1").Equals(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_COLOR_TENKAI_FLG].ToString())
							&& Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_KENSU].ToString()) > 1)
						{
							colorSyohinFlg = true;
							break;
						}
					}

					if (colorSyohinFlg)
					{
						// 警告メッセージを表示する
						InfoMsgCls.AddWarnMsg("W101", String.Empty, facadeContext);
					}

					// 警告メッセージ表示
					if (InfoMsgCls.HasWarn(facadeContext))
					{
						return;
					}
				}

				#endregion

				#region 排他チェック

				// 検索時に取得した更新日、更新時間とDB上の更新日、更新時間を比較し異なる場合、エラー

				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");				// 店舗コード
				sRepSql.Append(" AND BAIHENKAISI_YMD = :BIND_BAIHENKAISI_YMD");	// 売変開始日
				sRepSql.Append(" AND BAIHEN_NO = :BIND_BAIHEN_NO");				// 売変№
				sRepSql.Append(" AND KAKUTEI_FLG = 0");							// 確定フラグ

				ArrayList bindList = new ArrayList();
				BindInfoVO bindVO = new BindInfoVO();
				String tableId = String.Empty;

				// 選択行(Dictionary)[Ｍ１申請元区分] が「本部」の場合
				if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
				{
					// SQL設定
					tableId = Tl030p01Constant.TABLE_MDCT0010;
				}
				// 選択行(Dictionary)[Ｍ１申請元区分] が「店舗」の場合

				else if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
				{
					tableId = Tl030p01Constant.TABLE_MDCT0020;
				}

				// 店舗コード
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_TENPO_CD";
				bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 売変開始日
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BAIHENKAISI_YMD";
				bindVO.Value = BoSystemFormat.formatDate(f02VO.Baihenkaisi_ymd);
				bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 売変№
				bindVO = new BindInfoVO();
				bindVO.BindId = "BIND_BAIHEN_NO";
				bindVO.Value = BoSystemFormat.formatBaihen_shiji_no(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString());
				bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
				bindList.Add(bindVO);

				// 排他チェック
				V03003Check.CheckHaita(
						Convert.ToDecimal((string)prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1UPD_YMD]),
						Convert.ToDecimal((string)prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1UPD_TM]),
						facadeContext,
						tableId,
						sRepSql.ToString(),
						bindList,
						1
				);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 更新処理

				// 明細単位で以下の処理を実施する。
				for (int i = 0; i < m1List.Count; i++)
				{

					Tl030f02M1Form f02m1VO = (Tl030f02M1Form)m1List[i];

					// チェックボックスが未選択または既に確定している行は飛ばす
					if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_NORMAL)
						|| jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_KAKUTEI))
					{
						continue;
					}

					// [Ｍ１申請元区分] が「本部」の場合
					if (ConditionSinseimoto.VALUE_SINSEIMOTO1.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
					{

						// [Ｍ１承認状態]が"1"の場合
						if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_SYONIN))
						{

							// [売価変更指示TBL]を更新する。
							BoSystemLog.logOut("[売価変更指示TBL]を更新する。 START");
							int iUpdateBaikaHenkoSijiRet = UpdateBaikaHenkoSiji(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
							BoSystemLog.logOut("[売価変更指示TBL]を更新する。 END");

							// 旧自社品番カラー展開フラグが0の場合（カラー管理商品以外の場合)
							if (("0").Equals(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_COLOR_TENKAI_FLG]))
							{

								// 事前売変データ存在チェック
								// 存在した場合。更新処理は行わない
								decimal dCnt = jizenBaihenCheck(facadeContext, f02VO, f02m1VO);

								if (dCnt == 0)
								{
									// [自動売変延長データTBL]を削除する。
									BoSystemLog.logOut("[自動売変延長データTBL]を削除する。 START");
									int iDeleteJidoBaihenEntyoRet = DeleteJidoBaihenEntyo(facadeContext, f02VO, f02m1VO);
									BoSystemLog.logOut("[自動売変延長データTBL]を削除する。 END");

									// [事前売変データTBL]を登録する。
									BoSystemLog.logOut("[事前売変データTBL]を登録する。 START");
									int iInsertJizenBaihenRet = InsertJizenBaihen(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
									BoSystemLog.logOut("[事前売変データTBL]を登録する。 END");

									// [売変確定一時TBL]を登録する。
									BoSystemLog.logOut("[売変確定一時TBL]を登録する。 START");
									int iInsertBaihenKakuteiTempRet = InsertBaihenKakuteiTemp(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
									BoSystemLog.logOut("[売変確定一時TBL]を登録する。 END");
								}

							}

							// それ以外の場合（カラー管理商品の場合）
							else
							{
								// 事前売変データ存在チェック
								// 存在した場合。更新処理は行わない
								decimal dCnt = jizenBaihenCheck(facadeContext, f02VO, f02m1VO);

								if (dCnt == 0)
								{
									// [自動売変延長データTBL]を削除する。
									BoSystemLog.logOut("[自動売変延長データTBL]を削除する(カラー管理商品) START");
									int iDeleteJidoBaihenEntyoColorSyohinRet = DeleteJidoBaihenEntyoColorSyohin	(facadeContext, f02VO, f02m1VO);
									BoSystemLog.logOut("[自動売変延長データTBL]を削除する(カラー管理商品) END");

									// [売変確定一時TBL]を登録する。
									BoSystemLog.logOut("[売変確定一時TBL]を登録する(カラー管理商品) START");
									int iInsertBaihenKakuteiTempColorSyohinet = InsertBaihenKakuteiTempColorSyohin(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
									BoSystemLog.logOut("[売変確定一時TBL]を登録する(カラー管理商品) END");

									// [事前売変データTBL]を登録する。
									BoSystemLog.logOut("[事前売変データTBL]を登録する(カラー管理商品) START");
									int iInsertJizenBaihenColorSyohinRet = InsertJizenBaihenColorSyohin(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
									BoSystemLog.logOut("[事前売変データTBL]を登録する(カラー管理商品) END");
								}
							}

						}

						//[Ｍ１却下フラグ]が"1"の場合
						else if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_KYAKKA))
						{

							// 旧自社品番カラー展開フラグが0の場合（カラー管理商品以外の場合)
							if (("0").Equals(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_COLOR_TENKAI_FLG]))
							{

								// [自動売変延長データTBL]を削除する。
								BoSystemLog.logOut("[自動売変延長データTBL]を削除する。 START");
								int iDeleteJidoBaihenEntyoRet = DeleteJidoBaihenEntyo(facadeContext, f02VO, f02m1VO);
								BoSystemLog.logOut("[自動売変延長データTBL]を削除する。 END");

								// [自動売変延長データTBL]を登録する。
								BoSystemLog.logOut("[自動売変延長データTBL]を登録する。 START");
								int iInsertJidouEntyoRet = InsertJidouEntyo(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[自動売変延長データTBL]を登録する。 END");

							}

							// それ以外の場合（カラー管理商品の場合）
							else
							{

								// [自動売変延長データTBL]を削除する。
								BoSystemLog.logOut("[自動売変延長データTBL]を削除する。 START");
								int iDeleteJidoBaihenEntyoColorSyohinRet = DeleteJidoBaihenEntyoColorSyohin(facadeContext, f02VO, f02m1VO);
								BoSystemLog.logOut("[自動売変延長データTBL]を削除する。 END");

								// [自動売変延長データTBL]を登録する。
								BoSystemLog.logOut("[自動売変延長データTBL]を登録する。 START");
								int iInsertJidouEntyoColorSyohinRet = InsertJidouEntyoColorSyohin(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[自動売変延長データTBL]を登録する。 END");

							}
						}
					}
					
					// [Ｍ１申請元区分] が「店舗」の場合
					else if (ConditionSinseimoto.VALUE_SINSEIMOTO2.Equals(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1SINSEIMOTO_KBN].ToString()))
					{
						// 旧自社品番カラー展開フラグが0の場合（カラー管理商品以外の場合)
						if (("0").Equals(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_COLOR_TENKAI_FLG]))
						{
							// [店舗売変確定TBL]を登録する。
							BoSystemLog.logOut("[店舗売変確定TBL]を登録する。 START");
							int iInsertTenpoBaikaKakuteiRet = InsertTenpoBaikaKakutei(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
							BoSystemLog.logOut("[店舗売変確定TBL]を登録する。 END");


							// [Ｍ１承認状態]が"1"の場合
							if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_SYONIN))
							{
								// [売変確定一時TBL]を登録する。
								BoSystemLog.logOut("[売変確定一時TBL]を登録する。 START");
								int iInsertBaihenKakuteiTempTenpoRet = InsertBaihenKakuteiTemp(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[売変確定一時TBL]を登録する。 END");

							}
						}

						// それ以外の場合（カラー管理商品の場合）
						else
						{
							// [店舗売変確定TBL]を登録する。
							BoSystemLog.logOut("[店舗売変確定TBL]を登録する。 START");
							int iInsertTenpoBaikaKakuteiColorSyohinRet = InsertTenpoBaikaKakuteiColorSyohin(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
							BoSystemLog.logOut("[店舗売変確定TBL]を登録する。 END");

							// [Ｍ１承認状態]が"1"の場合
							if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_SYONIN))
							{
								// [売変確定一時TBL]を登録する。
								BoSystemLog.logOut("[売変確定一時TBL]を登録する。 START");
								int iInsertBaihenKakuteiTempColorSyohinRet = InsertBaihenKakuteiTempTenpoColorSyohin(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
								BoSystemLog.logOut("[売変確定一時TBL]を登録する。 END");

							}

						}

						// [店舗売変予定TBL]を更新する。
						BoSystemLog.logOut("[店舗売変予定TBL]を更新する。 START");
						int iUpdateTenpoBaihenYoteiRet = UpdateTenpoBaihenYotei(facadeContext, f02VO, f02m1VO, sysDateVO, logininfo);
						BoSystemLog.logOut("[店舗売変予定TBL]を更新する。 END");
					}
				}// for


				// API対象データが存在する場合、API連携を実施する
				// 売変確定一時TBLの件数取得,存在した場合API起動
				if (getTempCount(facadeContext) > 0)
				{
					// API(売価変更)を起動する。
					BoSystemLog.logOut("API(売価変更)を起動する。 START");
					int ApiRet = ApiConnectPriceChage(facadeContext, f02VO, sysDateVO, logininfo);
					BoSystemLog.logOut("API(売価変更)を起動する。 END");

					// エラー判定
					//  0:正常終了
					// -1:異常終了(APIエラー)
					// -2:自社品番エラー(インフォメーション)
					if (ApiRet == 0)
					{
						// 正常終了

					}
					else if (ApiRet == -1)
					{
						// 異常終了。ロールバックし処理を終了する
						RollbackTransaction(facadeContext);
						return;
					}
					else if (ApiRet == -2)
					{
						// 自社品番エラー、インフォメーションを表示する
						// 部品内でメッセージ情報は作成済み
					}
					else if (ApiRet == -3)
					{
						// DBエラーの場合、システムエラー画面を表示
						// 部品内でスロー済み
					}
				}
				else
				{
					// 売変データなし
				}

				// [店別単価MST]を更新する。
				BoSystemLog.logOut("[店別単価MST]を更新する。 START");
				int iUpdatePLUPosRt = UpdatePLUPos(facadeContext);
				BoSystemLog.logOut("[店別単価MST]を更新する。 END");

				// [売変確定ワークTBL]を登録する。
				BoSystemLog.logOut("[売変確定ワークTBL]を登録する。 START");
				int iInsertBaihenKakuteiWorkRet = InsertBaihenKakuteiWork(facadeContext, f02VO, sysDateVO, logininfo);
				BoSystemLog.logOut("[売変確定ワークTBL]を登録する。 END");


				#endregion

				#region 画面編集処理

				// 確定フラグ
				prevM1Vo.M1entersyoriflg = ConditionKakuteisyori_flg.VALUE_ARI;

				int iMikakuteiGyoCount = 0;
				for (int i = 0; i < m1List.Count; i++)
				{
					Tl030f02M1Form f02m1VO = (Tl030f02M1Form)m1List[i];
					// 未確定行が存在した場合、選択可能
					if (Tl030p01Constant.JOTAI_NORMAL.Equals(jotaiCheck(f02m1VO)))
					{
						iMikakuteiGyoCount++;
						break;
					}
				}
				if (iMikakuteiGyoCount == 0)
				{
					prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1NOTSELECTFLG] = Tl030p01Constant.ITIRAN_SENTAKU_FUKA;
					// 行は未選択状態とする
					prevM1Vo.M1selectorcheckbox = BoSystemConstant.CHECKBOX_OFF;
				}

				#endregion

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

		#region ユーザー定義関数

		#region 売変期間チェック
		/// <summary>
		/// PricechangeRangeChk 売変期間チェック
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <returns>0:正常 -1:異常</returns>
		private int PricechangeRangeChk(IFacadeContext facadeContext, Tl030f02Form f02VO, SysDateVO sysDateVO)
		{

			int iRt = -1;
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();
			StringBuilder sBindId = new StringBuilder();

			FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_16, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];
			IDataList m1List = f02VO.GetList("M1");


			#region 店舗コード

			// 	店舗コード
			sRepSql.Append(" AND MDCT0010.TENPO_CD = :BIND_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region システム日付

			sRepSql.Append(" AND MDCT0010.BAIHENSAGYOKAISI_YMD <=  :BIND_SYS_YMD_01");
			sRepSql.Append(" AND MDCT0010.BAIHENKAISI_YMD >=  :BIND_SYS_YMD_02");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYS_YMD_01";
			bindVO.Value = sysDateVO.Sysdate.ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_SYS_YMD_02";
			bindVO.Value = sysDateVO.Sysdate.ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region 部門コード
			sRepSql.Append(" AND MDCT0010.BUMON_CD = :BIND_BUMON_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_BUMON_CD";
			bindVO.Value = BoSystemFormat.formatBumonCd(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1BUMON_CD].ToString());
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);
			
			#endregion

			#region 色コード、自社品番

			String First_flg = "S";

			// 条件設定
			for (int i = 0; i < m1List.Count; i++)
			{
				Tl030f02M1Form f02m1VO = (Tl030f02M1Form)m1List[i];

				// 承認にチェックが入っている行が対象
				if (jotaiCheck(f02m1VO).Equals(Tl030p01Constant.JOTAI_SYONIN))
				{

					//1件目はカンマをつけない。
					if (First_flg == "S")
					{
						sRepSql.Append(" AND (MDCT0010.JISYA_HBN,MDCT0010.IRO_CD) IN (");
						//初回フラグを終了させる
						First_flg = "E";
					}
					else
					{
						sRepSql.Append(",");
					}

					sRepSql.Append(("("));

					// 自社品番
					sBindId = new StringBuilder();
					sBindId.Append("BIND_JISYA_HBN").Append(i.ToString("0000"));
					sRepSql.Append(" :").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn);
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 色コード
					sBindId = new StringBuilder();
					sBindId.Append("BIND_IRO_CD").Append(i.ToString("0000"));
					sRepSql.Append(" ,:").Append(sBindId.ToString());

					bindVO = new BindInfoVO();
					bindVO.BindId = sBindId.ToString();
					bindVO.Value = BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD].ToString());
					bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
					bindList.Add(bindVO);
					sRepSql.Append((")"));

				}
			}
			sRepSql.Append((")"));

			#endregion

			BoSystemSql.AddSql(rtSeach, Tl030p01Constant.SQL_ID_16_REP_WHERE, sRepSql.ToString(), bindList);

			//検索結果を取得します
			rtSeach.CreateDbCommand();

			IList<Hashtable> tableList = rtSeach.Execute();

			BoSystemLog.logOut("SQL: " + rtSeach.LogSql);

			decimal dCnt = 0;

			// 存在しない場合、正常
			if (tableList == null || tableList.Count <= 0)
			{
				// 正常
				iRt = 0;
			}
			else
			{
				Hashtable resultTbl = tableList[0];
				dCnt = (Decimal)resultTbl["CNT"];

				// 0件チェック
				if (dCnt <= 0)
				{
					// エラー
					iRt = 0;
				}
			}

			return iRt;

		}
		#endregion

		#region 選択状態判定
		/// <summary>
		/// jotaiCheck 選択状態判定
		/// </summary>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <returns>0:チェックなし、1:承認、2:却下、3:確定済み</returns>
		private string jotaiCheck(Tl030f02M1Form f01m1VO)
		{
			// デフォルトはチェックなし
			String sJotai = Tl030p01Constant.JOTAI_NORMAL;

			// 承認フラグがチェックされていた場合
			if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1syonin_flg))
			{
				sJotai = Tl030p01Constant.JOTAI_SYONIN;
			}
			// 却下フラグがチェックされていた場合
			else if (BoSystemConstant.CHECKBOX_ON.Equals(f01m1VO.M1kyakka_flg))
			{
				sJotai = Tl030p01Constant.JOTAI_KYAKKA;
			}

			// すでに確定されているか、Ｍ１カラー展開売変可能フラグが0の場合更新しない
			if (f01m1VO.Dictionary[Tl030p01Constant.DIC_M1ENTERSYORIFLG].Equals(ConditionKakuteisyori_flg.VALUE_ARI)
				|| ("0").Equals(f01m1VO.Dictionary[Tl030p01Constant.DIC_M1COLOR_TENKAI_BAIKA_KAHEN_FLG]))
			{
				sJotai = Tl030p01Constant.JOTAI_KAKUTEI;
			}

			return sJotai;
		}
		#endregion

		#region [売価変更指示TBL]を更新する。

		/// <summary>
		/// UpdateBaikaHenkoSiji [売価変更指示TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int UpdateBaikaHenkoSiji(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_17, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_DEL_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 店舗コード1
			reader.BindValue("BIND_TENPO_CD_01", sTenpo_cd);
			// 店舗コード2
			reader.BindValue("BIND_TENPO_CD_02", sTenpo_cd);
			// 店舗コード3
			reader.BindValue("BIND_TENPO_CD_03", sTenpo_cd);
			// 店舗コード4
			reader.BindValue("BIND_TENPO_CD_04", sTenpo_cd);

			// カラー管理商品の場合、半角スペースを設定
			String sIro_Cd = BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD].ToString());
			if (("1").Equals(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JISYA_HBN_COLOR_TENKAI_FLG])) 
			{
				sIro_Cd = " ";
			}
			// 色コード1
			reader.BindValue("BIND_IRO_CD_01", sIro_Cd);
			// 色コード2
			reader.BindValue("BIND_IRO_CD_02", sIro_Cd);
			// 色コード3
			reader.BindValue("BIND_IRO_CD_03", sIro_Cd);
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 売変行No
			reader.BindValue("BIND_BAIHENGYO_NO", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENGYO_NO].ToString()));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f02VO.Dictionary[Tl030p01Constant.DIC_GENBAIKA_SHIJIBAIKA_FLG].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 事前売変データ存在チェック

		/// <summary>
		/// jizenBaihenCheck 事前売変データ存在チェック
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <returns>件数</returns>
		private decimal jizenBaihenCheck(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_18, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 店舗コード1
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);

			// カラー管理商品の場合、半角スペースを設定
			String sIro_Cd = BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD].ToString());
			if (string.IsNullOrEmpty(sIro_Cd))
			{
				sIro_Cd = " ";
			}
			// 色コード1
			reader.BindValue("BIND_IRO_CD_01", sIro_Cd);
			// 色コード2
			reader.BindValue("BIND_IRO_CD_02", sIro_Cd);
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 売変行No
			reader.BindValue("BIND_BAIHENGYO_NO", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENGYO_NO].ToString()));

			//クエリを実行する。
			reader.CreateDbCommand();

			IList<Hashtable> tableList = reader.Execute();

			BoSystemLog.logOut("SQL: " + reader.LogSql);

			decimal dCnt = 0;

			if (tableList == null || tableList.Count <= 0)
			{
				dCnt = 0;
			}
			else
			{
				Hashtable resultTbl = tableList[0];
				dCnt = (Decimal)resultTbl["CNT"];
			}

			return dCnt;
		}
		#endregion

		#region [事前売変データTBL]を登録する。

		/// <summary>
		/// InsertJizenBaihen [事前売変データTBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertJizenBaihen(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_19, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変終了日
			reader.BindValue("BIND_BAIHENSYURYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENSYURYO_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 売変行№
			reader.BindValue("BIND_BAIHENGYO_NO", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENGYO_NO].ToString()));
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD].ToString()));
			// 現売価
			reader.BindValue("BIND_GENBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1mtobaika_tnk));
			// 指示売価
			reader.BindValue("BIND_SIJIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1yobobaika_tnk));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [売変確定一時TBL]を登録する。

		/// <summary>
		/// InsertBaihenKakuteiTemp [売変確定一時TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertBaihenKakuteiTemp(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_20, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD].ToString()));
			// 確定売価
			reader.BindValue("BIND_KAKUTEIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1kakuteibaika_tnk));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime.ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [事前売変データTBL]を登録する(カラー管理商品)

		/// <summary>
		/// InsertJizenBaihenColorSyohin [事前売変データTBL]を登録する(カラー管理商品)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertJizenBaihenColorSyohin(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_21, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 自社品番1
			reader.BindValue("BIND_JISYA_HBN_01", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 自社品番2
			reader.BindValue("BIND_JISYA_HBN_02", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 現売価
			reader.BindValue("BIND_GENBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1mtobaika_tnk));
			// 指示売価
			reader.BindValue("BIND_SIJIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1yobobaika_tnk));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変終了日
			reader.BindValue("BIND_BAIHENSYURYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENSYURYO_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f02VO.Dictionary[Tl030p01Constant.DIC_GENBAIKA_SHIJIBAIKA_FLG].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [売変確定一時TBL]を登録する(カラー管理商品)

		/// <summary>
		/// InsertBaihenKakuteiTempColorSyohin [売変確定一時TBL]を登録する(カラー管理商品)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertBaihenKakuteiTempColorSyohin(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_22, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 自社品番1
			reader.BindValue("BIND_JISYA_HBN_01", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 自社品番2
			reader.BindValue("BIND_JISYA_HBN_02", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 指示売価
			reader.BindValue("BIND_KAKUTEIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1kakuteibaika_tnk));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime.ToString()));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変終了日
			reader.BindValue("BIND_BAIHENSYURYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENSYURYO_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f02VO.Dictionary[Tl030p01Constant.DIC_GENBAIKA_SHIJIBAIKA_FLG].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [自動売変延長データTBL]を削除する。

		/// <summary>
		/// DeleteJidoBaihenEntyo [自動売変延長データTBL]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <returns>件数</returns>
		private int DeleteJidoBaihenEntyo(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_23, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 売変行№
			reader.BindValue("BIND_BAIHENGYO_NO", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENGYO_NO].ToString()));
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [自動売変延長データTBL]を登録する。

		/// <summary>
		/// InsertJidouEntyo [自動売変延長データTBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertJidouEntyo(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_24, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変終了日
			reader.BindValue("BIND_BAIHENSYURYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENSYURYO_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 売変行№
			reader.BindValue("BIND_BAIHENGYO_NO", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENGYO_NO].ToString()));
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD].ToString()));
			// 現売価
			reader.BindValue("BIND_GENBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1mtobaika_tnk));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [自動売変延長データTBL]を削除する(カラー管理商品)

		/// <summary>
		/// DeleteJidoBaihenEntyoColorSyohin [自動売変延長データTBL]を削除する(カラー管理商品)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <returns>件数</returns>
		private int DeleteJidoBaihenEntyoColorSyohin(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_25, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変終了日
			reader.BindValue("BIND_BAIHENSYURYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENSYURYO_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f02VO.Dictionary[Tl030p01Constant.DIC_GENBAIKA_SHIJIBAIKA_FLG].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [自動売変延長データTBL]を登録する(カラー管理商品)

		/// <summary>
		/// InsertJidouEntyoColorSyohin [自動売変延長データTBL]を登録する(カラー管理商品)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertJidouEntyoColorSyohin(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_26, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変終了日
			reader.BindValue("BIND_BAIHENSYURYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENSYURYO_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 処理日付
			reader.BindValue("BIND_SYORI_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 現売価＝指示売価のみフラグ
			reader.BindValue("BIND_BAIKAEQUAL_FLG", Convert.ToDecimal(f02VO.Dictionary[Tl030p01Constant.DIC_GENBAIKA_SHIJIBAIKA_FLG].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [店舗売変確定TBL]を登録する。

		/// <summary>
		/// InsertTenpoBaikaKakutei [店舗売変確定TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertTenpoBaikaKakutei(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_27, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変終了日
			reader.BindValue("BIND_BAIHENSYURYO_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENSYURYO_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 売変行№
			reader.BindValue("BIND_BAIHENGYO_NO", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENGYO_NO].ToString()));
			// 部門コード
			reader.BindValue("BIND_BUMON_CD", BoSystemFormat.formatBumonCd(f02VO.Bumon_cd));
			// 品種コード
			reader.BindValue("BIND_HINSYU_CD", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1HINSYU_CD].ToString()));
			// ブランドコード
			reader.BindValue("BIND_BURANDO_CD", BoSystemFormat.formatBrandCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BURANDO_CD].ToString()));
			// 商品名(カナ)
			reader.BindValue("BIND_SYONMK", f02m1VO.M1syonmk);
			// メーカー品番
			reader.BindValue("BIND_MAKER_HBN", f02m1VO.M1maker_hbn);
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));
			// 色コード
			reader.BindValue("BIND_IRO_CD", BoSystemFormat.formatIroCd(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1IRO_CD].ToString()));
			// シーズン
			reader.BindValue("BIND_SEASON_KB", Convert.ToDecimal(f02m1VO.M1season_kb));
			// 上代1
			reader.BindValue("BIND_JODAI1_TNK", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1JODAI1_TNK].ToString()));
			// 現売価
			reader.BindValue("BIND_GENBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1mtobaika_tnk));
			// 原単価
			reader.BindValue("BIND_GEN_TNK", Convert.ToDecimal(f02m1VO.M1gen_tnk));
			// 指示売価
			reader.BindValue("BIND_SIJIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1yobobaika_tnk));
			// 確定売価
			reader.BindValue("BIND_KAKUTEIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1kakuteibaika_tnk));
			// 在庫数
			reader.BindValue("BIND_ZAIKO_SU", Convert.ToDecimal(f02m1VO.M1zaiko_su));
			// 売上数
			reader.BindValue("BIND_URIAGE_SU", Convert.ToDecimal(f02m1VO.M1uriage_su));
			// ハンドラベル
			reader.BindValue("BIND_HANDLBL_KB", Convert.ToDecimal(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1HANDLBL_KB]));
			// 承認状態
			reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(jotaiCheck(f02m1VO)));
			// 申請担当者コード
			reader.BindValue("BIND_SINSEITAN_CD", BoSystemFormat.formatTantoCd(f02VO.Sinseitan_cd));
			// 確定担当者コード
			reader.BindValue("BIND_KAKUTEITAN_CD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// HHTシリアル番号
			reader.BindValue("BIND_HHTSERIAL_NO", prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1HHTSERIAL_NO].ToString());
			// HHTシーケンスNo.
			reader.BindValue("BIND_HHTSEQUENCE_NO", Convert.ToDecimal(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1HHTSEQUENCE_NO].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [店舗売変予定TBL]を更新する。

		/// <summary>
		/// UpdateTenpoBaihenYotei [店舗売変予定TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int UpdateTenpoBaihenYotei(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_28, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 更新日1
			reader.BindValue("BIND_UPD_YMD_01", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新日2
			reader.BindValue("BIND_UPD_YMD_02", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間1
			reader.BindValue("BIND_UPD_TM_01", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新時間2
			reader.BindValue("BIND_UPD_TM_02", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変№
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [店舗売変確定TBL]を登録する（カラー管理商品)

		/// <summary>
		/// InsertTenpoBaikaKakuteiColorSyohin [店舗売変確定TBL]を登録する（カラー管理商品)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertTenpoBaikaKakuteiColorSyohin(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_29, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 指示売価
			reader.BindValue("BIND_SIJIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1yobobaika_tnk));
			// 確定売価
			reader.BindValue("BIND_KAKUTEIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1kakuteibaika_tnk));
			// 店舗コード1
			reader.BindValue("BIND_TENPO_CD_01", sTenpo_cd);
			// 店舗コード2
			reader.BindValue("BIND_TENPO_CD_02", sTenpo_cd);
			// 店舗コード3
			reader.BindValue("BIND_TENPO_CD_03", sTenpo_cd);
			// 承認状態
			reader.BindValue("BIND_SYONIN_FLG", Convert.ToDecimal(jotaiCheck(f02m1VO)));
			// 申請担当者コード
			reader.BindValue("BIND_SINSEITAN_CD", BoSystemFormat.formatTantoCd(f02VO.Sinseitan_cd));
			// 確定担当者コード
			reader.BindValue("BIND_KAKUTEITAN_CD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 登録日
			reader.BindValue("BIND_ADD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 登録時間
			reader.BindValue("BIND_ADD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 登録担当者コード
			reader.BindValue("BIND_ADD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 更新担当者コード
			reader.BindValue("BIND_UPD_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));
			// 削除日
			reader.BindValue("BIND_SAKUJYO_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// HHTシリアル番号
			reader.BindValue("BIND_HHTSERIAL_NO", prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1HHTSERIAL_NO].ToString());
			// HHTシーケンスNo.
			reader.BindValue("BIND_HHTSEQUENCE_NO", Convert.ToDecimal(prevM1Vo.Dictionary[Tl030p01Constant.DIC_M1HHTSEQUENCE_NO].ToString()));
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 店舗コード4
			reader.BindValue("BIND_TENPO_CD_04", sTenpo_cd);
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [店舗売変確定TBL]を登録する（カラー管理商品)

		/// <summary>
		/// InsertBaihenKakuteiTempColorSyohin [店舗売変確定TBL]を登録する（カラー管理商品)
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="Tl030f02M1Form">明細情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertBaihenKakuteiTempTenpoColorSyohin(IFacadeContext facadeContext, Tl030f02Form f02VO, Tl030f02M1Form f02m1VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_30, facadeContext.DBContext);

			// 一覧の選択行情報を取得
			Tl030f01M1Form prevM1Vo = (Tl030f01M1Form)f02VO.Dictionary[Tl030p01Constant.DIC_M1SELCETVO];

			// 店舗コード
			String sTenpo_cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// 確定売価
			reader.BindValue("BIND_KAKUTEIBAIKA_TNK", Convert.ToDecimal(f02m1VO.M1kakuteibaika_tnk));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime.ToString()));
			// 店舗コード
			reader.BindValue("BIND_TENPO_CD", sTenpo_cd);
			// 売変開始日
			reader.BindValue("BIND_BAIHENKAISI_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHENKAISI_YMD].ToString())));
			// 売変No
			reader.BindValue("BIND_BAIHEN_NO", BoSystemFormat.formatBaihen_shiji_no(f02m1VO.Dictionary[Tl030p01Constant.DIC_M1BAIHEN_NO].ToString()));
			// 自社品番
			reader.BindValue("BIND_JISYA_HBN", BoSystemFormat.formatJisyaHbn(f02m1VO.M1jisya_hbn));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [売変確定ワークTBL]を登録する

		/// <summary>
		/// InsertBaihenKakuteiWork [売変確定ワークTBL]を登録する
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>件数</returns>
		private int InsertBaihenKakuteiWork(IFacadeContext facadeContext, Tl030f02Form f02VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_31, facadeContext.DBContext);

			// SEQ
			reader.BindValue("BIND_SEQ", Convert.ToDecimal(f02VO.Dictionary[Tl030p01Constant.DIC_SEQ].ToString()));
			// 更新日
			reader.BindValue("BIND_UPD_YMD", Convert.ToDecimal(sysDateVO.Sysdate.ToString()));
			// 更新時間
			reader.BindValue("BIND_UPD_TM", Convert.ToDecimal(sysDateVO.Systime_mili.ToString()));
			// 担当者コード
			reader.BindValue("BIND_TANCD", BoSystemFormat.formatTantoCd(logininfo.TtsCd));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region API(売価変更)を起動する。

		/// <summary>
		/// ApiConnectPriceChage API(売価変更)を起動する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="Tl030f02Form">画面情報</param>
		/// <param name="sysDateVO">システム日付</param>
		/// <param name="LoginInfoVO">ログイン情報</param>
		/// <returns>0:正常終了 -1:異常終了(エラー) -2:自社品番エラー(インフォメーション)</returns>
		private int ApiConnectPriceChage(IFacadeContext facadeContext, Tl030f02Form f02VO, SysDateVO sysDateVO, LoginInfoVO logininfo)
		{

			// 店舗コード
			String stenpo_Cd = BoSystemFormat.formatTenpoCd(f02VO.Head_tenpo_cd);

			// エラー判定フラグ
			//  0:正常終了
			// -1:異常終了(エラー)
			// -2:自社品番エラー(インフォメーション)
			// -3:DBエラー(システムエラー)
			int Errkbn = 0;

			// API起動
			ApiResponseVO<Ncr050a01ResponseVO> resVo = Ncr050a01Api.ApiConnectPriceChage(facadeContext, stenpo_Cd, Tl030p01Constant.FORMID_02.ToUpper(), sysDateVO, logininfo);

			#region ■■応答データ取得

			// APIステータスの取得
			string errcd = resVo.ERROR.ERRORCD.ToString();

			if (resVo != null && errcd.Equals(BoSystemApi.APISTATUS_NOMAL))
			{
				// 正常終了の場合
				Errkbn = 0;
			}
			// 業務エラー
			else if (errcd.Equals(BoSystemApi.APISTATUS_GYOMUERR))
			{
				// 異常終了の場合
				List<ErrorDetailVO> ErrList = resVo.ERROR.ERRORS;
				string sErrCd = string.Empty;
				if (ErrList.Count == 0)
				{
					Errkbn = -1;
				}
				else
				{
					for (int i = 0; i < ErrList.Count; i++)
					{
						if (i == 0)
						{
							sErrCd = ErrList[i].ERRORID;

							// 明細行ごとにエラーを判定
							if (!string.IsNullOrEmpty(sErrCd))
							{
								if (sErrCd.Equals("E830")
									|| sErrCd.Equals("E831")
									)
								{
									/*
									 E830:会社コードエラー
									 E831:店舗コードエラー
									 */
									// 異常（API連携エラー）
									Errkbn = -1;
									break;
								}
								else
								{
									/*
									 E834:自社品番エラー
									 E835:カラーエラー
									 */
									Errkbn = -2;
									break;
								}
							}
							else
							{
								// 異常（API連携エラー）
								Errkbn = -1;
								break;
							}
						}
					}
				}
			}
			// 異常エラー
			else
			{
				Errkbn = -1;
			}
			#endregion

			#region ■■応答結果によりエラー、インフォメーションを表示する

			// E834:自社品番エラー、E835:カラーエラーの行が存在した場合、インフォメーションダイアログを表示
			if (Errkbn == -2)
			{
				// インフォメーション情報一行目は固定「以下の商品がPOSに正しく登録されませんでした。」
				InfoMsgCls.AddInfoMsg("I115", string.Empty, facadeContext);

				List<ErrorDetailVO> ErrorMessegeList = resVo.ERROR.ERRORS;

				// 2行目以降はエラー行の情報を元にメッセージ作成
				if (ErrorMessegeList.Count > 0)
				{
					for (int i = 0; i < ErrorMessegeList.Count; i++)
					{
						if (ErrorMessegeList[i].ERRORID.Equals("E834")
							|| ErrorMessegeList[i].ERRORID.Equals("E835"))
						{
							InfoMsgCls.AddInfoMsg("I116",
												BoSystemApi.messageSplit(ErrorMessegeList[i].ERRORMESSAGE),
												facadeContext);
						}
					}
				}
			}
			// 異常終了、E830:会社コードエラー、E831:店舗コードエラーの場合
			else if (Errkbn == -1)
			{
				// POS連携に失敗しました
				ErrMsgCls.AddErrMsg("E226", string.Empty, facadeContext);
			}

			#endregion

			return Errkbn;
		}
		#endregion

		#region [店別単価MST]を更新する。

		/// <summary>
		/// UpdatePLUPos [店別単価MST]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>件数</returns>
		private int UpdatePLUPos(IFacadeContext facadeContext)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_14, facadeContext.DBContext);

			// 条件なしで更新する

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}

		#endregion

		#region [売変確定一時TBL]を取得する。

		/// <summary>
		/// getTempCount [売変確定一時TBL]を更新する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <returns>件数</returns>
		private int getTempCount(IFacadeContext facadeContext)
		{
			int iRt = 0;

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tl030p01Constant.SQL_ID_34, facadeContext.DBContext);

			//検索結果を取得します
			reader.CreateDbCommand();

			IList<Hashtable> tableList = reader.Execute();

			BoSystemLog.logOut("SQL: " + reader.LogSql);

			// 存在しない場合、0件とする
			if (tableList == null || tableList.Count <= 0)
			{
				iRt = 0;
			}
			else
			{
				Hashtable resultTbl = tableList[0];
				iRt = Convert.ToInt16(resultTbl["CNT"]);
			}

			return iRt;
		}

		#endregion

		#endregion

	}
}
