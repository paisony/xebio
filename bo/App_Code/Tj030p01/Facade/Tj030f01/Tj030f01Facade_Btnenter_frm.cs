using com.xebio.bo.Tj030p01.Constant;
using com.xebio.bo.Tj030p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01001;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01017;
using Common.Business.C01000.C01018;
using Common.Business.C99999.Constant;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.LogUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Business.V03000.V03003;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Data;
using System.Text;

namespace com.xebio.bo.Tj030p01.Facade
{
  /// <summary>
  /// Tj030f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Tj030f01Facade : StandardBaseFacade
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
				Tj030f01Form f01VO = (Tj030f01Form)facadeContext.FormVO;
				IDataList m1List = f01VO.GetList("M1");

				// システム日付取得
				SysDateVO sysDateVO = new SysDateVO();
				sysDateVO = SysdateCls.GetSysdateTime(facadeContext);

				// 店舗コード Dictionaryより取得
				String tenpocd = BoSystemFormat.formatTenpoCd((string)f01VO.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_CD]);

				#endregion

				#region 業務チェック

				#region 行数チェック

				// 1-1 選択状態
				// 1件も選択されていない場合、エラー
				if (m1List == null || m1List.Count <= 0)
				{
					ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
				}
				else
				{
					int inputflg = 0;
					for (int i = 0; i < m1List.Count; i++)
					{
						Tj030f01M1Form f01m1VO = (Tj030f01M1Form)m1List[i];
						if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
						{
							inputflg = 1;
							break;
						}
					}
					if (inputflg == 0)
					{
						ErrMsgCls.AddErrMsg("E119", "対象行", facadeContext);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}
				#endregion

				#region 単項目チェック

				// 2-1 ヘッダ店舗コード
				// 棚卸終了処理が行われている場合、エラー

				// 棚卸実施日TBL取得
				Hashtable hashTable = new Hashtable();

				hashTable = SearchInventory.SearchMdit0030(tenpocd, sysDateVO.Sysdate.ToString(), facadeContext, 0);
				String tanaorosikijun_Ymd = String.Empty;

				if (hashTable != null)
				{
					tanaorosikijun_Ymd = hashTable["TANAOROSIKIJUN_YMD"].ToString();
				}

				// 棚卸終了チェック
				SearchInventory.CheckInventoryEnd(tenpocd, tanaorosikijun_Ymd, facadeContext, 1);

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#region 排他チェック

				StringBuilder sRepSql = new StringBuilder();

				sRepSql.Append(" AND TENPO_CD = :BIND_TENPO_CD");			// 店舗コード
				sRepSql.Append(" AND FACE_NO = :BIND_FACE_NO");				// フェイス№
				sRepSql.Append(" AND TANA_DAN = :BIND_TANA_DAN");			// 棚段
				sRepSql.Append(" AND KAI_SU = :BIND_KAI_SU");				// 回数
				sRepSql.Append(" AND TANAOROSI_YMD = :BIND_TANAOROSI_YMD");	// 棚卸日
				sRepSql.Append(" AND SOSINKAI_SU = :BIND_SOSINKAI_SU");		// 送信回数

				for (int i = 0; i < m1List.Count; i++)
				{
					Tj030f01M1Form f01m1VO = (Tj030f01M1Form)m1List[i];

					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{
						ArrayList bindList = new ArrayList();
						BindInfoVO bindVO = new BindInfoVO();

						// 店舗コード
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TENPO_CD";
						// カード部のDictionaryより取得
						bindVO.Value = tenpocd;
						bindVO.Type = BoSystemSql.BINDTYPE_STRING;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// フェイス№
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_FACE_NO";
						// 明細部のDictionaryより取得
						bindVO.Value = (string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1FACE_NO];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 棚段
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TANA_DAN";
						// 明細部より取得
						bindVO.Value = (string)f01m1VO.M1tana_dan;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 回数
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_KAI_SU";
						// 明細部より取得
						bindVO.Value = (string)f01m1VO.M1kai_su;
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 棚卸日
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_TANAOROSI_YMD";
						// 明細部のDictionaryより取得
						bindVO.Value = BoSystemFormat.formatDate((string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1TANAOROSI_YMD]);
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 送信回数
						bindVO = new BindInfoVO();
						bindVO.BindId = "BIND_SOSINKAI_SU";
						// 明細部のDictionaryより取得
						bindVO.Value = (string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1SOSINKAI_SU];
						bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
						bindList.Add(bindVO);

						// 排他チェック
						V03003Check.CheckHaitaMaxVal(
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1UPD_YMD]),
								Convert.ToDecimal((string)f01m1VO.Dictionary[Tj030p01Constant.DIC_M1UPD_TM]),
								facadeContext,
								"MDIT0010",
								sRepSql.ToString(),
								bindList,
								1,
								null,
								f01m1VO.M1rowno,
								i.ToString(),
								"M1",
								100
						);
					}
				}

				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				#endregion

				#endregion

				#region 更新処理

				for (int i = 0; i < m1List.Count; i++)
				{
					Tj030f01M1Form f01m1VO = (Tj030f01M1Form)m1List[i];
					// Ｍ１選択フラグ(隠し)が"1"の場合、以下の処理を実施する。
					if (f01m1VO.M1selectorcheckbox.Equals(BoSystemConstant.CHECKBOX_ON))
					{

						// [棚卸確定TBL(H)]を削除する。
						BoSystemLog.logOut("[棚卸確定TBL(H)]を削除 START");
						int Delcntkakuteih = Del_tanakakuteh(facadeContext, f01VO, f01m1VO, logininfo);
						BoSystemLog.logOut("[棚卸確定TBL(H)]を削除 END");

						// [棚卸確定TBL(B)]を削除する。
						BoSystemLog.logOut("[棚卸確定TBL(H)]を削除 START");
						int Delcntkakuteib = Del_tanakakuteb(facadeContext, f01VO, f01m1VO, logininfo);
						BoSystemLog.logOut("[棚卸確定TBL(H)]を削除 END");
					}

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

		#region [棚卸確定TBL(H)]を削除する。
		/// <summary>
		/// [棚卸確定TBL(H)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_tanakakuteh(IFacadeContext facadeContext,
									Tj030f01Form f01Form,
									Tj030f01M1Form f01M1Form,
									LoginInfoVO loginInfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj030p01Constant.SQL_ID_06, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_TENCD, BoSystemFormat.formatTenpoCd((String)(f01Form.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_CD])));
			// フェイス№
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_FACE_NO, Convert.ToDecimal((string)f01M1Form.Dictionary[Tj030p01Constant.DIC_M1FACE_NO]));
			// 棚段
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_TANA_DAN, Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1tana_dan, "0")));
			// 回数
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_KAI_SU, Convert.ToDecimal(BoSystemString.Nvl(f01M1Form.M1kai_su, "0")));
			// 棚卸日
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_TANAOROSI_YMD, Convert.ToDecimal((string)f01M1Form.Dictionary[Tj030p01Constant.DIC_M1TANAOROSI_YMD]));
			// 送信回数/処理日付
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_SOSINKAI_SU, Convert.ToDecimal((string)f01M1Form.Dictionary[Tj030p01Constant.DIC_M1SOSINKAI_SU]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region [棚卸確定TBL(B)]を削除する。
		/// <summary>
		/// [棚卸確定TBL(B)]を削除する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		/// <param name="f01Form">一覧画面のVO</param>
		/// <param name="f01M1Form">一覧画面選択行のVO</param>
		/// <param name="loginInfo">ログイン情報</param>
		/// <returns>更新件数</returns>
		private int Del_tanakakuteb(IFacadeContext facadeContext,
									Tj030f01Form f01Form,
									Tj030f01M1Form f01M1Form,
									LoginInfoVO loginInfo)
		{

			// XMLからSQLを取得する。
			FindSqlResultTable reader = FindSqlUtil.CreateFindSqlResultTable(Tj030p01Constant.SQL_ID_07, facadeContext.DBContext);

			// 店舗コード
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_TENCD, BoSystemFormat.formatTenpoCd((String)(f01Form.Dictionary[SearchConditionSaveCls.PREFIX + Tj030p01Constant.DIC_TENPO_CD])));
			// フェイス№
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_FACE_NO, Convert.ToDecimal((string)f01M1Form.Dictionary[Tj030p01Constant.DIC_M1FACE_NO]));
			// 棚段
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_TANA_DAN, Convert.ToDecimal((string)f01M1Form.M1tana_dan));
			// 回数
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_KAI_SU, Convert.ToDecimal((string)f01M1Form.M1kai_su));
			// 棚卸日
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_TANAOROSI_YMD, Convert.ToDecimal((string)f01M1Form.Dictionary[Tj030p01Constant.DIC_M1TANAOROSI_YMD]));
			// 送信回数/処理日付
			reader.BindValue(Tj030p01Constant.SQL_ID_04_REP_SOSINKAI_SU, Convert.ToDecimal((string)f01M1Form.Dictionary[Tj030p01Constant.DIC_M1SOSINKAI_SU]));

			//クエリを実行する。
			using (IDbCommand cmd = reader.CreateDbCommand())
			{
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#endregion

	}

}
