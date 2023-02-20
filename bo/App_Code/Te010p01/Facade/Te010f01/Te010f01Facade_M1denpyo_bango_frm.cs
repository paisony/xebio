using com.xebio.bo.Te010p01.Constant;
using com.xebio.bo.Te010p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01005;
using Common.Business.C01000.C01018;
using Common.Business.C99999.FormatUtil;
using Common.Business.C99999.SqlUtil;
using Common.Business.C99999.StringUtil;
using Common.Standard.Base;
using Common.Standard.Login;
using Common.Standard.Message;
using Common.Standard.Model.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace com.xebio.bo.Te010p01.Facade
{
  /// <summary>
  /// Te010f01のFacadeクラスです
  /// 各アクションの業務ロジックを実装します。
  /// </summary>
  public partial class Te010f01Facade : StandardBaseFacade
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
		
			//使用時にコメントアウトをはずす。
			//モックアップテンプレートと共有している処理をコメントアウト。
			//必要に応じて処理を有効にしてください。

			//メソッドの開始処理を実行する。
			StartMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

			try
			{
				//DBコンテキストを設定する。
				SetDBContext(facadeContext);
				//コネクションを取得して、トランザクションを開始する。
				OpenConnection(facadeContext);

				//以下に業務ロジックを記述する。
				#region 初期化
				// ログイン情報取得
				LoginInfoVO logininfo = LoginInfoUtil.GetLoginInfo();

				// FormVO取得
				// 画面より情報を取得する。
				Te010f01Form prevVo = (Te010f01Form)facadeContext.FormVO;
				Te010f02Form nextVo = (Te010f02Form)facadeContext.GetUserObject(Te010p01Constant.FCDUO_NEXTVO);

				IDataList prevM1List = prevVo.GetList("M1");
				IDataList nextM1List = nextVo.GetList("M1");
				// 選択行の情報を取得する。
				Te010f01M1Form prevM1Vo = (Te010f01M1Form)prevM1List.GetPageViewList()[facadeContext.CommandInfo.ListIndex];

				// 一覧の初期化
				nextM1List.ClearCacheData();
				nextM1List.Clear();
				#endregion
				#region 検索処理
				FindSqlResultTable rtSearch = FindSqlUtil.CreateFindSqlResultTable(Te010p01Constant.SQL_ID_04, facadeContext.DBContext);
				string sTblID = "";
				// 移動出荷確定TBL(H)参照時
				if (Te010p01Constant.REF_TBL_KAKU.Equals(prevVo.Dictionary[Te010p01Constant.DIC_REF_TBL].ToString()))
				{
					// 移動出荷確定テーブル(B)
					sTblID = "MDUT0011";
				}
				// 移動出荷履歴TBL(H)参照時
				else
				{
					// 移動出荷履歴テーブル[B]
					sTblID = "MDUT0021";
				}
				// テーブル設定
				BoSystemSql.AddSql(rtSearch, Te010p01Constant.SQL_ADD_TBLID, sTblID);
				// -------------------------------------------
				// バインド変数の置き換え
				// -------------------------------------------
				// 出荷会社コード
				rtSearch.BindValue("BIND_SYUKKAKAISYA_CD", Convert.ToDecimal(logininfo.CopCd));
				// 出荷店コード
				rtSearch.BindValue("BIND_SYUKKATEN_CD", BoSystemFormat.formatTenpoCd(prevM1Vo.Dictionary[Te010p01Constant.DIC_M1TENPO_CD].ToString()));
				// 出荷日
				rtSearch.BindValue("BIND_SYUKKA_YMD", Convert.ToDecimal(BoSystemFormat.formatDate(prevM1Vo.Dictionary[Te010p01Constant.DIC_M1SYUKKA_YMD].ToString())));
				// 伝票番号
				rtSearch.BindValue("BIND_DENPYO_BANGO", Convert.ToDecimal(BoSystemString.Nvl(prevM1Vo.Dictionary[Te010p01Constant.DIC_M1DENPYO_BANGO].ToString(), "0")));
				// 移動出荷履歴TBL(H)参照時
				if (Te010p01Constant.REF_TBL_RIREKI.Equals(prevVo.Dictionary[Te010p01Constant.DIC_REF_TBL].ToString()))
				{

					ArrayList bindList = new ArrayList();
					BindInfoVO bindVO = new BindInfoVO();
					StringBuilder sRepSql = new StringBuilder();
					// 履歴Noを設定
					sRepSql.Append(" AND T1.RIREKI_NO = :BIND_RIREKI_NO");
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_RIREKI_NO";
					bindVO.Value = prevM1Vo.Dictionary[Te010p01Constant.DIC_M1RIREKI_NO].ToString();
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// 赤黒区分を設定
					sRepSql.Append(" AND T1.AKAKURO_KBN = :BIND_AKAKURO_KBN").AppendLine();
					bindVO = new BindInfoVO();
					bindVO.BindId = "BIND_AKAKURO_KBN";
					bindVO.Value = prevM1Vo.Dictionary[Te010p01Constant.DIC_M1AKAKURO_KBN].ToString();
					bindVO.Type = BoSystemSql.BINDTYPE_NUMBER;	// 1:文字列、2:数値
					bindList.Add(bindVO);

					// ADD_WHERE追加
					BoSystemSql.AddSql(rtSearch, Te010p01Constant.SQL_ID_01_REP_ADD_WHERE, sRepSql.ToString(), bindList);
				}

				// -------------------------------------------
				//検索結果取得
				// -------------------------------------------
				rtSearch.CreateDbCommand();
				IList<Hashtable> tableList = rtSearch.Execute();
				// 件数チェック
				if (tableList == null || tableList.Count <= 0)
				{
					// エラー
					ErrMsgCls.AddErrMsg("E145", String.Empty, facadeContext);
				}

				// ------------------------------------------------------------------------------------
				//エラーが発生した場合、その時点でチェックを中止しクライアント側へエラー内容を返却する。
				// ------------------------------------------------------------------------------------
				if (MessageDisplayUtil.HasError(facadeContext))
				{
					return;
				}

				// -------------------------------------------
				//転記処理（管理Noクリック）
				// -------------------------------------------
				DoDetailCopy(prevVo, prevM1Vo, nextVo, nextM1List, tableList);
				#region カード部設定
				// ヘッダ店舗コード
				nextVo.Head_tenpo_cd = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_CD"];
				// ヘッダ店舗名
				nextVo.Head_tenpo_nm = (string)prevVo.Dictionary[SearchConditionSaveCls.PREFIX + "HEAD_TENPO_NM"];
				// 伝票番号
				nextVo.Denpyo_bango = (string)prevM1Vo.Dictionary[Te010p01Constant.DIC_M1DENPYO_BANGO];
				// 指示番号
				nextVo.Siji_bango =  prevM1Vo.M1siji_bango;
				// SCMコード
				nextVo.Scm_cd =  prevM1Vo.M1scm_cd;
				// 出荷理由名称
				nextVo.Shukkariyu_nm =  prevM1Vo.M1shukkariyu_nm;
				// 出荷担当者コード
				nextVo.Syukkatan_cd = prevM1Vo.Dictionary[Te010p01Constant.DIC_M1ADDTAN_CD].ToString();
				// 出荷担当者名称
				nextVo.Syukkatan_nm = prevM1Vo.M1nyuryokutan_nm;
				// 出荷日
				nextVo.Syukka_ymd =  prevM1Vo.Dictionary[Te010p01Constant.DIC_M1SYUKKA_YMD].ToString();
				// [入荷会社コード]がログイン情報.[会社コード]と同じ場合
				// [入荷会社コード]
				int jyuryokaisyaCd = Convert.ToInt32(BoSystemString.Nvl(prevM1Vo.Dictionary[Te010p01Constant.DIC_M1JYURYOKAISYA_CD].ToString(), "0"));
				// ログイン情報.[会社コード]
				int loginCopCd = Convert.ToInt32(BoSystemString.Nvl(logininfo.CopCd, "0"));
				if (jyuryokaisyaCd == loginCopCd)
				{
					// 会社コード
					nextVo.Kaisya_cd = "";
					// 会社名称
					nextVo.Kaisya_nm = "";
				}
				else
				{
					// 会社コード
					nextVo.Kaisya_cd = prevM1Vo.Dictionary[Te010p01Constant.DIC_M1JYURYOKAISYA_CD].ToString();
					// 会社名称
					nextVo.Kaisya_nm = prevM1Vo.Dictionary[Te010p01Constant.DIC_M1JYURYOKAISYA_NM].ToString();
				}

				// 入荷店コード
				nextVo.Jyuryoten_cd = prevM1Vo.M1jyuryoten_cd;
				// 入荷店名称
				nextVo.Juryoten_nm = prevM1Vo.M1juryoten_nm;
				// 入荷担当者コード
				nextVo.Nyukatan_cd = prevM1Vo.Dictionary[Te010p01Constant.DIC_M1NYUKATAN_CD].ToString();
				// 入荷担当者名称
				nextVo.Nyukatan_nm = prevM1Vo.Dictionary[Te010p01Constant.DIC_M1NYUKATAN_NM].ToString();
				// 入荷日
				nextVo.Jyuryo_ymd =  prevM1Vo.Dictionary[Te010p01Constant.DIC_M1JYURYO_YMD].ToString();
				// 処理名称
				nextVo.Syorinm = prevM1Vo.M1syorinm;
				// 処理日
				nextVo.Syoriymd =  prevM1Vo.Dictionary[Te010p01Constant.DIC_M1SYORI_YMD].ToString();
				// 処理時間
				nextVo.Syori_tm =  prevM1Vo.M1syori_tm;
				// 選択明細のVO
				nextVo.Dictionary[Te010p01Constant.DIC_M1SELCETVO] = prevM1Vo;
				// 選択行のインデックスを設定
				nextVo.Dictionary[Te010p01Constant.DIC_M1SELCETROWIDX] = facadeContext.CommandInfo.ListIndex.ToString();
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
			EndMethod(facadeContext, this.GetType().Name + ".DoM1DENPYO_BANGO_FRM");

		}
		#endregion
	}
}
