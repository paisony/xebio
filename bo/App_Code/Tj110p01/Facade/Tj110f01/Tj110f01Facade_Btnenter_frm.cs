using com.xebio.bo.Tj110p01.Constant;
using com.xebio.bo.Tj110p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.DbUtil;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Conditions;
using Common.Entitys.VO;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tj110p01.Facade
{
  /// <summary>
  /// Tj110f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj110f01Facade : StandardBaseFacade
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
			//メソッドの開始処理を実行する。
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
				Tj110f01Form f01VO = (Tj110f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// 店舗コード Dictionaryより取得
				string keyHeadTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

				#endregion

				#region 業務チェック

				#region 単項目チェック

				// 1-1 ヘッダ店舗コード
				// 棚卸終了処理が行われている場合、エラー

				// 棚卸終了チェック

				SearchInventory.CheckInventoryEnd(keyHeadTenpoCd, f01VO.Dictionary[Tj110p01Constant.DIC_TANAOROSIKIJUN_YMD].ToString(), facadeContext, 1);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 選択チェック

				// 2-1 選択状態
				// 1件も変更されていない場合、エラー
				int inputflg = 0;
				for (int i = 0; i < m1List.Count; i++)
				{
					Tj110f01M1Form f01m1VO = (Tj110f01M1Form)m1List[i];

					// 1列目のNoが空白の場合、処理は行わない
					if (string.IsNullOrEmpty(f01m1VO.M1rowno))
					{
						continue;
					}

					// 検索時の欠番フラグと選択状態が全て一致する場合、変更なし	
					if (!IsMatch(f01m1VO.M1selectorcheckbox, f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG1].ToString(), f01m1VO.M1rowno)
						|| !IsMatch(f01m1VO.M1selectorcheckbox2, f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG2].ToString(), f01m1VO.M1rowno2)
						|| !IsMatch(f01m1VO.M1selectorcheckbox3, f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG3].ToString(), f01m1VO.M1rowno3)
						|| !IsMatch(f01m1VO.M1selectorcheckbox4, f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG4].ToString(), f01m1VO.M1rowno4)
						|| !IsMatch(f01m1VO.M1selectorcheckbox5, f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG5].ToString(), f01m1VO.M1rowno5)
						|| !IsMatch(f01m1VO.M1selectorcheckbox6, f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG6].ToString(), f01m1VO.M1rowno6)
						|| !IsMatch(f01m1VO.M1selectorcheckbox7, f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG7].ToString(), f01m1VO.M1rowno7))
					{
						inputflg = 1;
						break;
					}
				}
				if (inputflg == 0)
				{
					ErrMsgCls.AddErrMsg("E140", string.Empty, facadeContext);
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 排他チェック

				HaitaCheck(facadeContext, f01VO);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 棚卸確定TBL(H)存在チェック

				// 欠番登録対象行の棚卸確定TBL存在チェック

				// 明細データの編集
				ArrayList al = MeisaiEdit(f01VO);

				Boolean boo = true;
				for (int i = 0; i < al.Count; i++)
				{
					Hashtable ht = (Hashtable)al[i];

					// 選択されている場合
					if (BoSystemConstant.CHECKBOX_ON.Equals(ht["SELECTOR"].ToString()))
					{
						// 存在チェック
						boo = IsTanaorosiCheck(facadeContext, f01VO, ht);
						if (!boo)
						{
							ErrMsgCls.AddErrMsg("E169", string.Empty, facadeContext);
							break;
						}
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 更新処理

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 取漏れ／欠番区分が「取漏れ」以外の場合、[棚卸欠番TBL]の削除処理を行う
				if (!ConditionTorimore_ketsuban_kbn.VALUE_TORIMORE.Equals(f01VO.Torimore_ketsuban))
				{
					// [棚卸欠番TBL]を削除する。
					BoSystemLog.logOut("[棚卸欠番TBL]を削除 START");
					int Delcnt = Del_tanaorosiKetuban(facadeContext, f01VO, logininfo);
					BoSystemLog.logOut("[棚卸欠番TBL]を削除 END");
				}

				// [棚卸欠番TBL]を登録する
				BoSystemLog.logOut("[棚卸欠番TBL]を登録 START");
				int Intcnt = Ins_tanaorosiKetuban(facadeContext, f01VO, logininfo, sysDateVO);
				BoSystemLog.logOut("[棚卸欠番TBL]を登録 END");

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

		#region 行変更チェック
		/// <summary>
		/// 行変更チェック
		/// </summary>
		/// <param name="String">選択状態</param>
		/// <param name="String">検索時の状態</param>
		/// <param name="String">NO</param>
		/// <returns>TRUE:変更なし FALSE:変更有</returns>
		private Boolean IsMatch(String selectorcheckbox, String Flg, String NO)
		{
			Boolean boo = false;

			// NOが空白の場合TRUE
			if (String.IsNullOrEmpty(NO))
			{
				boo = true;
			}
			else
			{
				boo = selectorcheckbox.Equals(Flg);
			}
			return boo;
		}
		#endregion

		#region 排他チェック
		/// <summary>
		/// 排他チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Tj110f01Form">f01VO</param>
		private void HaitaCheck(IFacadeContext facadeContext, Tj110f01Form f01VO)
		{

			// 店舗コード Dictionaryより取得
			string keyHeadTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			StringBuilder sRepSql = new StringBuilder();

			sRepSql.Append(" AND TENCD = :BIND_TENPO_CD");
			sRepSql.Append(" AND TANAOROSIKIJUN_YMD = :BIND_TANAOROSIKIJUN_YMD");
			sRepSql.Append(" AND FACE_NO BETWEEN :BIND_FACE_NOFROM AND :BIND_FACE_NOTO");
			
			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();

			// 店舗コード
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			// カード部のDictionaryより取得
			bindVO.Value = keyHeadTenpoCd;
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// 棚卸基準日
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TANAOROSIKIJUN_YMD";
			// 明細部のDictionaryより取得
			bindVO.Value = BoSystemFormat.formatDate((string)f01VO.Dictionary[Tj110p01Constant.DIC_TANAOROSIKIJUN_YMD]);
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// フェイス№FROM
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_FACE_NOFROM";
			// 明細部のDictionaryより取得
			bindVO.Value = BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from)].ToString(), "-1");
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			// フェイス№TO
			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_FACE_NOTO";
			// 明細部のDictionaryより取得
			bindVO.Value = BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to)].ToString(), "-1");
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);


			// 排他チェック
			V03003Check.CheckHaitaMaxVal(
					Convert.ToDecimal((string)f01VO.Dictionary[Tj110p01Constant.DIC_UPD_YMD]),
					Convert.ToDecimal((string)f01VO.Dictionary[Tj110p01Constant.DIC_UPD_TIM]),
					facadeContext,
					"MDIT0040",
					sRepSql.ToString(),
					bindList,
					1,
					null,
					null,
					null,
					null,
					0
			);
		}
		#endregion

		#region 棚卸確定TBL(H)存在チェック
		/// <summary>
		/// 棚卸確定TBL(H)存在チェック
		/// </summary>
		/// <param name="IFacadeContext">facadeContext</param>
		/// <param name="Tj110f01Form">f01VO</param>
		/// <param name="Hashtable">ht</param>
		private Boolean IsTanaorosiCheck(IFacadeContext facadeContext, Tj110f01Form f01VO, Hashtable ht)
		{
			FindSqlResultTable rtSeach = FindSqlUtil.CreateFindSqlResultTable(Tj110p01Constant.SQL_ID_03, facadeContext.DBContext);

			// 店舗コード Dictionaryより取得
			string keyHeadTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());

			ArrayList bindList = new ArrayList();
			BindInfoVO bindVO = new BindInfoVO();
			StringBuilder sRepSql = new StringBuilder();

			Boolean boo = true;

			#region 店舗コード

			// 店舗コードを設定
			sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TENPO_CD";
			bindVO.Value = keyHeadTenpoCd;
			bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region フェイスNo

			// フェイスNoを設定
			sRepSql.Append(" AND FACE_NO = :BIND_FACE_NO");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_FACE_NO";
			bindVO.Value = ht["FACE_NO"].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region 棚段

			// 棚段を設定
			sRepSql.Append(" AND TANA_DAN = :BIND_TANA_DAN");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TANA_DAN";
			bindVO.Value = ht["TANA_DAN"].ToString();
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion

			#region 棚卸基準日

			// 棚卸基準日を設定
			sRepSql.Append(" AND TANAOROSI_YMD = :BIND_TANAOROSI_YMD");

			bindVO = new BindInfoVO();
			bindVO.BindId = "BIND_TANAOROSI_YMD";
			bindVO.Value = BoSystemFormat.formatDate(f01VO.Dictionary[Tj110p01Constant.DIC_TANAOROSIKIJUN_YMD].ToString());
			bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
			bindList.Add(bindVO);

			#endregion
			BoSystemSql.AddSql(rtSeach, Tj110p01Constant.SQL_ID_03_REP_ADD_WHERE, sRepSql.ToString(), bindList);

			//検索結果を取得します
			rtSeach.CreateDbCommand();

			IList<Hashtable> tableList = rtSeach.Execute();

			if (tableList == null || tableList.Count <= 0)
			{
				// 正常終了
				boo = true;
			}
			else
			{
				Hashtable resultTbl = tableList[0];
				Decimal dCnt = (Decimal)resultTbl["CNT"];

				// 存在した場合エラー
				if (dCnt > 0)
				{
					boo = false;
				}
			}

			return boo;
		}
		#endregion

		#region 明細編集
		/// <summary>
		/// 明細を編集する
		/// 
		/// </summary>
		/// <param name="Tj110f01M1Form">f01m1VO</param>
		/// <returns>明細配列(NO,フェイスNO,棚段,チェック状態,検索時欠番フラグ)</returns>
		private ArrayList MeisaiEdit(Tj110f01Form f01VO)
		{
			// 処理用ワーク作成

			// 1頁の行数カウンタ
			int gyo = 9;
			// 処理対象列
			int retu = 1;
			// 処理開始行カウンタ
			int MCount = 0;
			// MAX列
			int MaxRetu = 7;
			IDataList m1List = f01VO.GetList("M1");
			ArrayList al = new ArrayList(int.Parse(f01VO.Searchcnt) - 1);

			do
				for (int i = MCount; i < m1List.Count; i++)
				{
					Tj110f01M1Form f01m1VO = (Tj110f01M1Form)m1List[i];

					// 1列目のNoが空白の場合、処理は行わない
					if (string.IsNullOrEmpty(f01m1VO.M1rowno))
					{
						continue;
					}

					// 1列目
					if (retu == 1)
					{

						Hashtable map = new Hashtable();
						map["NO"] = f01m1VO.M1rowno.ToString();
						map["FACE_NO"] = f01m1VO.M1face_no.ToString();
						map["TANA_DAN"] = BoSystemString.Nvl(f01m1VO.M1tana_dan.ToString(), "0");
						map["SELECTOR"] = f01m1VO.M1selectorcheckbox.ToString();
						map["FLG"] = f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG1].ToString();
						al.Add(map);

					}

					// 2列目
					if (retu == 2)
					{

						Hashtable map = new Hashtable();
						map["NO"] = f01m1VO.M1rowno2.ToString();
						map["FACE_NO"] = f01m1VO.M1face_no2.ToString();
						map["TANA_DAN"] = BoSystemString.Nvl(f01m1VO.M1tana_dan2.ToString(), "0");
						map["SELECTOR"] = f01m1VO.M1selectorcheckbox2.ToString();
						map["FLG"] = f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG2].ToString();
						al.Add(map);
					}

					// 3列目
					if (retu == 3)
					{

						Hashtable map = new Hashtable();
						map["NO"] = f01m1VO.M1rowno3.ToString();
						map["FACE_NO"] = f01m1VO.M1face_no3.ToString();
						map["TANA_DAN"] = BoSystemString.Nvl(f01m1VO.M1tana_dan3.ToString(), "0");
						map["SELECTOR"] = f01m1VO.M1selectorcheckbox3.ToString();
						map["FLG"] = f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG3].ToString();
						al.Add(map);
					}

					// 4列目
					if (retu == 4)
					{

						Hashtable map = new Hashtable();
						map["NO"] = f01m1VO.M1rowno4.ToString();
						map["FACE_NO"] = f01m1VO.M1face_no4.ToString();
						map["TANA_DAN"] = BoSystemString.Nvl(f01m1VO.M1tana_dan4.ToString(), "0");
						map["SELECTOR"] = f01m1VO.M1selectorcheckbox4.ToString();
						map["FLG"] = f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG4].ToString();
						al.Add(map);
					}

					// 5列目
					if (retu == 5)
					{

						Hashtable map = new Hashtable();
						map["NO"] = f01m1VO.M1rowno5.ToString();
						map["FACE_NO"] = f01m1VO.M1face_no5.ToString();
						map["TANA_DAN"] = BoSystemString.Nvl(f01m1VO.M1tana_dan5.ToString(), "0");
						map["SELECTOR"] = f01m1VO.M1selectorcheckbox5.ToString();
						map["FLG"] = f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG5].ToString();
						al.Add(map);
					}

					// 6列目
					if (retu == 6)
					{

						Hashtable map = new Hashtable();
						map["NO"] = f01m1VO.M1rowno6.ToString();
						map["FACE_NO"] = f01m1VO.M1face_no6.ToString();
						map["TANA_DAN"] = BoSystemString.Nvl(f01m1VO.M1tana_dan6.ToString(), "0");
						map["SELECTOR"] = f01m1VO.M1selectorcheckbox6.ToString();
						map["FLG"] = f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG6].ToString();
						al.Add(map);
					}

					// 7列目
					if (retu == 7)
					{

						Hashtable map = new Hashtable();
						map["NO"] = f01m1VO.M1rowno7.ToString();
						map["FACE_NO"] = f01m1VO.M1face_no7.ToString();
						map["TANA_DAN"] = BoSystemString.Nvl(f01m1VO.M1tana_dan7.ToString(), "0");
						map["SELECTOR"] = f01m1VO.M1selectorcheckbox7.ToString();
						map["FLG"] = f01m1VO.Dictionary[Tj110p01Constant.DIC_M1FLG7].ToString();
						al.Add(map);
					}

					// カウントが最大件数を超えたら終了
					if (0 == al.Count.ToString().CompareTo(f01VO.Searchcnt))
					{
						break;
					}

					// 10行目が終了したら0から再始動
					if (i >= gyo)
					{
						// 7列目まで処理したら次のページ
						if (retu >= MaxRetu)
						{
							// 1列目よりスタート
							retu = 1;
							MCount = MCount + 10;
							gyo += 10;
						}
						else
						{
							// 次の列を処理
							retu++;
						}
						break;
					}
				}
			while (0 != al.Count.ToString().CompareTo(f01VO.Searchcnt));

			return al;
		}
		#endregion

		#region [棚卸欠番TBL]を削除する。
		/// <summary>
		/// [棚卸欠番TBL]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01VO">一覧画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_tanaorosiKetuban(IFacadeContext facadeContext, Tj110f01Form f01VO, LoginInfoVO loginInfo)
		{
			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj110p01Constant.SQL_ID_02, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue("BIND_TENCD", BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString()));
			// 棚卸基準日
			reader.BindValue("BIND_TANAOROSIKIJUN_YMD", Convert.ToDecimal(BoSystemFormat.formatDate((string)f01VO.Dictionary[Tj110p01Constant.DIC_TANAOROSIKIJUN_YMD])));
			// フェイスNOFROM
			reader.BindValue("BIND_FACE_NO_FROM", Convert.ToDecimal(BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_from)].ToString(), "-1")));
			// フェイスNOTO1
			reader.BindValue("BIND_FACE_NO_TO", Convert.ToDecimal(BoSystemString.Nvl(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Face_no_to)].ToString(), "-1")));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [棚卸欠番TBL]を登録する。
		/// <summary>
		/// [棚卸欠番TBL]を登録する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="f02VO">明細画面VO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Ins_tanaorosiKetuban(IFacadeContext facadeContext, Tj110f01Form f01VO, LoginInfoVO loginInfo, SysDateVO sysDateVO)
		{
			int iRownum = 0;

			// 共通項目定義
			// 店舗コード
			string HeadTenpoCd = BoSystemFormat.formatTenpoCd(f01VO.Dictionary[SearchConditionSaveCls.GetKey(() => f01VO.Head_tenpo_cd)].ToString());
			// 棚卸基準日
			decimal tanaorosi_ymd = Convert.ToDecimal(BoSystemFormat.formatDate((string)f01VO.Dictionary[Tj110p01Constant.DIC_TANAOROSIKIJUN_YMD]));

			// Oracleコマンドの生成
			OracleCommand command = facadeContext.DBContext.Connection.CreateCommand() as OracleCommand;
			// トランザクションの設定
			command.Transaction = facadeContext.DBContext.Transaction as OracleTransaction;
			// SQLの実行タイプ
			command.CommandType = CommandType.Text;

			IList<Mdrt0011VO> insertBodyList = new List<Mdrt0011VO>();	// 更新データリスト

			// パラメータバインド処理
			IList<Dictionary<string, string>> insertBindList = new List<Dictionary<string, string>>();
			int counter = 0;    // 制御用カウンタ（一括処理単位のカウンタ）

			// 明細データの編集
			ArrayList al = MeisaiEdit(f01VO);

			for (int i = 0; i < al.Count; i++)
			{
				// 選択されている行が対象
				Hashtable ht = (Hashtable)al[i];

				// NOが設定かつ選択されている
				// 一行目
				if (BoSystemConstant.CHECKBOX_ON.Equals(ht["SELECTOR"].ToString()))
				{
					counter++;
					iRownum++;

					Dictionary<string, string> bindDic = new Dictionary<string, string>();

					// 店舗コード
					BoSystemDb.setInsertVal("TENCD", iRownum.ToString("000"), HeadTenpoCd, ref bindDic, ref command);
					// 棚卸基準日
					BoSystemDb.setInsertVal("TANAOROSIKIJUN_YMD", iRownum.ToString("000"), tanaorosi_ymd, ref bindDic, ref command);
					// フェイスNO
					BoSystemDb.setInsertVal("FACE_NO", iRownum.ToString("000"), Convert.ToDecimal(ht["FACE_NO"].ToString()), ref bindDic, ref command);
					// 棚段
					BoSystemDb.setInsertVal("TANA_DAN", iRownum.ToString("000"), Convert.ToDecimal(ht["TANA_DAN"].ToString()), ref bindDic, ref command);
					// 登録日
					BoSystemDb.setInsertVal("ADD_YMD", iRownum.ToString("000"), sysDateVO.Sysdate, ref bindDic, ref command);
					// 登録時間
					BoSystemDb.setInsertVal("ADD_TM", iRownum.ToString("000"), sysDateVO.Systime_mili, ref bindDic, ref command);
					// 登録担当者コード
					BoSystemDb.setInsertVal("ADDTAN_CD", iRownum.ToString("000"), BoSystemFormat.formatTantoCd(loginInfo.TtsCd), ref bindDic, ref command);
					// 更新日
					BoSystemDb.setInsertVal("UPD_YMD", iRownum.ToString("000"), sysDateVO.Sysdate, ref bindDic, ref command);
					// 更新時間
					BoSystemDb.setInsertVal("UPD_TM", iRownum.ToString("000"), sysDateVO.Systime_mili, ref bindDic, ref command);
					// 更新担当者コード
					BoSystemDb.setInsertVal("UPD_TANCD", iRownum.ToString("000"), BoSystemFormat.formatTantoCd(loginInfo.TtsCd), ref bindDic, ref command);
					// 削除日
					BoSystemDb.setInsertVal("SAKUJYO_YMD", iRownum.ToString("000"), sysDateVO.Sysdate, ref bindDic, ref command);
					// 削除フラグ
					BoSystemDb.setInsertVal("SAKUJYO_FLG", iRownum.ToString("000"), "0", ref bindDic, ref command);

				


					insertBindList.Add(bindDic);

					// 一括処理単位に達した場合は、マルチインサートを実行
					if (counter == 20)
					{
						// カウンタのリセット
						counter = 0;

						// マルチインサートの実行
						command.CommandText = GetSqlMultiInsT_tanaorosiketuban(insertBindList);
						//OutPutLog(command.CommandText);
						command.ExecuteNonQuery();

						// 配列、バインドパラメータのクリア
						insertBindList.Clear();
						command.Parameters.Clear();
					}
				}

			}

			// 未登録レコードの登録
			if (counter > 0)
			{
				// マルチインサートの実行
				command.CommandText = GetSqlMultiInsT_tanaorosiketuban(insertBindList);
				command.ExecuteNonQuery();
			}

			return iRownum;
		}
		#endregion

		#region [棚卸欠番TBL]へのマルチインサート文作成。
		/// <summary>
		/// [棚卸欠番TBL]へのマルチインサートを行うSQL文を取得する。
		/// </summary>
		/// <param name="insertBindList">バインドテキスト</param>
		private string GetSqlMultiInsT_tanaorosiketuban(IList<Dictionary<string, string>> insertBindList)
		{
			IList<string> insertSqlList = new List<string>();    // 単一のINSERT文を保持するリスト

			// バインドテキストのデータ分INSERT文を作成
			foreach (Dictionary<string, string> bindDic in insertBindList)
			{
				StringBuilder insertSql = new StringBuilder();    // 単一のINSERT文
				insertSql.Append("    INTO MDIT0040 VALUES ( ");
				insertSql.Append(bindDic["TENCD"]).Append(" , ");
				insertSql.Append(bindDic["TANAOROSIKIJUN_YMD"]).Append(" , ");
				insertSql.Append(bindDic["FACE_NO"]).Append(" , ");
				insertSql.Append(bindDic["TANA_DAN"]).Append(" , ");
				insertSql.Append(bindDic["ADD_YMD"]).Append(" , ");
				insertSql.Append(bindDic["ADD_TM"]).Append(" , ");
				insertSql.Append(bindDic["ADDTAN_CD"]).Append(" , ");
				insertSql.Append(bindDic["UPD_YMD"]).Append(" , ");
				insertSql.Append(bindDic["UPD_TM"]).Append(" , ");
				insertSql.Append(bindDic["UPD_TANCD"]).Append(" , ");
				insertSql.Append(bindDic["SAKUJYO_YMD"]).Append(" , ");
				insertSql.Append(bindDic["SAKUJYO_FLG"]);
				insertSql.Append(" ) ");

				insertSqlList.Add(insertSql.ToString());
			}

			// 単一INSERTをまとめて、マルチインサート文を作成
			StringBuilder sql = new StringBuilder();
			sql.AppendLine("INSERT ALL");
			foreach (string sqlpart in insertSqlList)
			{
				sql.AppendLine(sqlpart);
			}
			sql.AppendLine("SELECT 1 FROM DUAL");

			return sql.ToString();
		}
		#endregion

		#endregion

	}
}
