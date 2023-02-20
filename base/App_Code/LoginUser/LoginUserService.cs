// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/03/16 WT)Banno OT1障害対応[QA-0664]

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.LoginUser.Dac;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.LoginUser.BC;
using System.Transactions;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Common.Model.BC;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.Certification.BC;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Certification.Dac;
using Oracle.ManagedDataAccess.Client;

namespace Com.Fujitsu.SmartBase.Base.LoginUser
{

	/// <summary>
	/// LoginUserService の概要の説明です
	/// </summary>
	public class LoginUserService : BaseService
	{
		#region コンストラクタ
		public LoginUserService(LoginUserInfoVO loginUserInfo)
			: base(loginUserInfo)
		{
		}
		#endregion

		#region 利用者情報
		#region GetLoginUserData
		/// <summary>
		/// 一覧画面の編集または削除ボタンが押されたとき、
		/// ログインID・利用者名・名前カナ・会社コードを取得して返します。
		/// </summary>
		/// <returns>
		/// </returns>
		public DataResult<DataTable> GetLoginUserData(LoginUserKey key)
		{
			DataResult<DataTable> res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//LoginUserDac loginuserDac = new LoginUserDac(connection);
					//dt = loginuserDac.Select(key);
					//res = new DataResult<DataTable>(dt != null, dt);
					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					DataTable dt = bc.GetLoginUserData(key);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}

			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetLoginUserData", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region DeleteLoginUser
		/// <summary>
		/// 削除確認画面の確認ボタンが押されたとき、
		/// 対応する一行の情報を削除します。
		/// </summary>
		public Result DeleteLoginUser(LoginUserVO vo)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.DeleteLoginUser(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteLoginUser", ex);
			}
		}
		#endregion

		#region UpdateLoginUser
		/// <summary>
		/// 編集確認後確認ボタンが押されたとき、
		/// 対応一行の情報を更新します。
		/// </summary>
		public Result UpdateLoginUser(LoginUserVO vo)
		{
			Result res;
			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.UpdateLoginUser(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateLoginUser", ex);
			}
		}
		#endregion

		#region InsertLoginUser
		/// <summary>
		/// 新規情報を入力確認後確認ボタンが押されたとき、
		/// 新しい情報を一行挿入します。
		/// </summary>
		public Result InsertLoginUser(LoginUserVO vo)
		{
			Result res;

			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.InsertLoginUser(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("InsertLoginUser", ex);
			}
		}

		/// <summary>
		/// 新規情報を入力確認後確認ボタンが押されたとき、
		/// 新しい情報を一括アップロードします。
		/// </summary>
		public Result InsertLoginUser(LoginUserVO[] vos, bool isUpdate)
		{
			Result res;

			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.InsertLoginUser(vos, isUpdate));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("InsertLoginUser", ex);
			}
		}

		/// <summary>
		/// 新規情報を入力確認後確認ボタンが押されたとき、
		/// 新しい情報を一括アップロードします。
		/// </summary>
		public Result InsertLoginUser(LoginUserVO[] vos, RoleUserMapVO[] maps, bool isUpdate)
		{
			Result res;

			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.InsertLoginUser(vos, maps, isUpdate));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("InsertLoginUser", ex);
			}
		}
		#endregion

		#region InsertUpdateLoginUser
		/// <summary>
		/// 1～n件の利用者情報を追加登録します（削除は行いません）。
		/// 利用者IDが存在しない場合は新規登録を、すでに存在する場合は「社員コード」「ログイン名」「ログイン名カナ」のみ更新します（その他のデータは何が入力されていても無視する）。複数行アップロードする場合、エラー行があると全ての行は登録されません。
		/// APIが実行された時刻は、共通機能のログに出力されます。
		/// </summary>
		public Result InsertUpdateLoginUser(LoginUserVO[] vos, RoleUserMapVO[] maps)
		{
			Result res;

			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.InsertUpdateLoginUser(vos, maps));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("InsertUpdateLoginUser", ex);
			}
		}
		#endregion

		#region FindLoginUser
		/// <summary>
		/// 検索条件で一致したレコードを返します。
		/// </summary>
		/// <returns>一致レコード数</returns>
		public DataResult<DataTable> FindLoginUser(QueryObject queryObj)
		{
			DataResult<DataTable> res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					DataTable dt = bc.FindLoginUser(queryObj);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("FindLoginUser", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region FindCountLoginUser
		/// <summary>
		/// 検索条件で一致したレコード数を返します。
		/// </summary>
		/// <returns>一致レコード数</returns>
		public DataResult<int> FindCountLoginUser(QueryObject queryObj)
		{
			DataResult<int> res;
			int count;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					DbCommand cmd = connection.CreateCommand();

					LoginUserDac loginuserDac = new LoginUserDac(connection);
					count = loginuserDac.FindCount(cmd, queryObj);
					res = new DataResult<int>(count >= 0, count);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<int>)base.HandleException("FindCountLoginUser", ex, typeof(DataResult<int>));
			}
		}
		#endregion

		#region UpdatePasswordLoginUser
		/// <summary>
		/// パスワードを更新します。
		/// </summary>
		/// <param name="vo">利用者情報が格納されたvo</param>
		/// <param name="oldPassword">古いパスワード</param>
		/// <param name="pwdLogNum">パスワード履歴の保存数</param>
		public Result UpdatePasswordLoginUser(LoginUserVO vo, string oldPassword)
		{
			int pwdLogNum = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdLogNumber"].Value);
			Result res;
			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.UpdatePasswordLoginUser(vo, oldPassword, pwdLogNum));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdatePasswordLoginUser", ex);
			}
		}
		#endregion

		#region CheckLoginAvailable
		/// <summary>
		/// 引数のID/PASSWORDでログイン可能かチェックします。 
		/// </summary>
		/// <param name="infoVo">ログイン者情報が格納されたvo</param>
		/// <param name="password">パスワード</param>
		/// <param name="userType">ユーザ権限</param>
		/// <returns>検証が成功した場合はResult.IsSuccessにtrueをセットし返却します。</returns>
		public Result CheckLoginAvailable(ExLoginUserInfoVO infoVo, string password, string userType)
		{
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					return bc.CheckLoginAvailable(infoVo, password,  userType);
				}

			}
			catch (Exception ex)
			{
				return base.HandleException("CheckLoginAvailable", ex);
			}
		}
		#endregion

		#region CheckLoginAvailableOperation
		/// <summary>
		/// 運用時間内かチェックします。 
		/// </summary>
		/// <param name="infoVo">ログイン者情報が格納されたvo</param>
		/// <param name="loginId">ログインＩＤ</param>
		/// <param name="userType">ユーザ権限</param>
		/// <returns>検証が成功した場合はResult.IsSuccessにtrueをセットし返却します。</returns>
		public Boolean CheckLoginAvailableOperation(ExLoginUserInfoVO infoVo, string loginId, string userType)
		{
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					return bc.CheckLoginAvailableOperation(infoVo, loginId, userType);
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion

		// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add Start ---------------
		#region CheckLoginAvailableOnline
		/// <summary>
		/// オンライン中かチェックします。 
		/// </summary>
		/// <param name="infoVo">ログイン者情報が格納されたvo</param>
		/// <returns>検証が成功した場合はResult.IsSuccessにtrueをセットし返却します。</returns>
		public Boolean CheckLoginAvailableOnline(ExLoginUserInfoVO infoVo)
		{
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					return bc.CheckLoginAvailableOnline(infoVo.LoginId, null);
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion
		// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add  END ---------------

		#region UpdateLockFlag

		/// <summary>
		/// 利用者ロック状態管理画面のロック（解除）ボタンが押されたとき、
		/// 利用者をロック（解除）します。
		/// </summary>
		public Result UpdateLockFlag(LoginUserVO vo)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.UpdateLockFlag(vo));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateLockFlag", ex);
			}
		}
		#endregion

		#region GetRoleUserMapByLoginId
		/// <summary>
		/// ログインIDからロールIDデータを取得します。
		/// </summary>
		/// <param name="loginId">ログインID</param>
		/// <returns></returns>
		public DataResult<DataTable> GetRoleUserMapByLoginId(string loginId)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					RoleUserMapDac dac = new RoleUserMapDac(connection);
					dt = dac.SelectByLoginId(cmd, loginId);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetRoleUserMapByLoginId", ex, typeof(DataResult<DataTable>));
			}
		}

		/// <summary>
		/// ログインIDのメニューパターンコードからロールIDデータを取得します。
		/// </summary>
		/// <param name="menuPtnCd">メニューパターンＣＤ</param>
		/// <returns></returns>
		public DataResult<DataTable> GetRoleUserMapByMenuPtnCd(string menuPtnCd)
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					RoleUserMapDac dac = new RoleUserMapDac(connection);
					dt = dac.SelectByLoginId(cmd, menuPtnCd);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetRoleUserMapByLoginId", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region UpdateUserRoleMap
		/// <summary>
		/// 利用者とロールのマッピング情報を更新します。
		/// </summary>
		/// <param name="userVO">利用者VO</param>
		/// <param name="mapVOs">ロールとのマッピング情報VO</param>
		/// <returns></returns>
		public Result UpdateUserRoleMap(LoginUserVO userVO, RoleUserMapVO[] mapVOs)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.UpdateUserRoleMap(userVO, mapVOs));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("UpdateUserRoleMap", ex);
			}
		}
		#endregion

		#region IsExistRoleId
		/// <summary>
		/// ロールIDが存在するかどうかをチェックします。
		/// </summary>
		/// <param name="keyValues">RoleUserMapVOの配列</param>
		/// <returns>true:存在する false:存在しない</returns>
		public Result IsExistRoleId(RoleUserMapVO[] mapVOs)
		{
			Result res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.IsExistRoleId(cmd, mapVOs));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("IsExistRoleId", ex);
			}
		}
		#endregion

		#region CheckPwdValid
		/// <summary>
		/// パスワードの有効期限をチェックします。
		/// </summary>
		/// <remarks>
		/// 設定ファイルからパスワード有効期間とパスワード変更事前通知日を取得、
		/// パスワード更新日時と比較して現在のパスワードが有効であるかをチェックします。
		/// </remarks>
		/// <param name="pwdUpdateDT">パスワード更新日時</param>
		/// <exception cref="ApplicationException">
		/// ・設定ファイルから取得したパスワード有効期間がパスワード変更事前通知日と同値か小さい時
		/// ・利用者のパスワード更新日時が不正(更新日時が現在時刻よりも未来の場合など時間の不整合)
		/// </exception>
		/// <returns>
		/// 戻り値
		/// 1:パスワード有効期間内(パスワード変更警告期間を除く)
		/// 2:パスワード変更警告期間
		/// 3:パスワード無効期間
		/// </returns>
		public int CheckPwdValid(DateTime pwdUpdateDT)
		{
			//パスワード有効期間（日）の取得
			int validDays = SystemSettings.PwdValidDuration;
			//パスワード変更事前通知日（日）の取得
			int promoteDays = SystemSettings.PwdChangePromoteDuration;
			if (promoteDays >= validDays) throw new ApplicationException("設定ファイルの設定値が不正です。“パスワード有効期間”は“パスワード有効期限通知日”よりも大きい値を設定してください。");

			//有効期間
			TimeSpan validSpan = new TimeSpan(validDays, 0, 0, 0);
			//警告期間（有効期限日から逆算するため、マイナス期間）
			TimeSpan promoteSpan = new TimeSpan(-promoteDays, 0, 0, 0);

			//有効期限日
			DateTime expiresDT = pwdUpdateDT.Add(validSpan);
			//警告開始日
			DateTime promoteStartDT = expiresDT.Add(promoteSpan);
			//現在時刻を取得
			DateTime nowDT = DateTime.Now;

			if (nowDT.CompareTo(pwdUpdateDT) >= 0 && nowDT.CompareTo(promoteStartDT) == -1)
			{
				//パスワード有効期間内(パスワード変更警告期間を除く)
				return 1;
			}
			else if (nowDT.CompareTo(promoteStartDT) >= 0 && nowDT.CompareTo(expiresDT) <= 0)
			{
				//パスワード警告期間内
				return 2;
			}
			else if (nowDT.CompareTo(expiresDT) == 1)
			{
				//パスワード無効期間
				return 3;
			}
			else
			{
				//どの期間にも属さない
				throw new ApplicationException("ログイン者のパスワード更新日時が不正です。");
			}
		}
		#endregion
		#endregion

		#region 会社情報
		#region GetAllCompany
		/// <summary>
		/// 全てのデータSELECTします。
		/// </summary>
		public DataResult<DataTable> GetAllCompany()
		{
			DataResult<DataTable> res;
			DataTable dt;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					CompanyDac companyDac = new CompanyDac(connection);
					dt = companyDac.SelectAll(cmd);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}
			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("GetAllCompany", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region InsertCompany
		/// <summary>
		/// 会社情報を登録する。
		/// すでに登録済の場合は更新、
		/// 存在しない場合は登録する。
		/// </summary>
		public Result InsertCompany(params CompanyVO[] vos)
		{
			Result res;

			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CompanyBC bc = new CompanyBC(loginUserInfo, connection);
					res = new Result(bc.InsertCompany(vos));

					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("InsertCompany", ex);
			}
		}
		#endregion

		#region DeleteCompany
		/// <summary>
		/// 会社情報を登録する。
		/// すでに登録済の場合は更新、
		/// 存在しない場合は登録する。
		/// </summary>
		public Result DeleteCompany(params CompanyKey[] keys)
		{
			Result res;

			// データをテーブルに追加
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CompanyBC bc = new CompanyBC(loginUserInfo, connection);
					res = new Result(bc.DeleteCompany(keys));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteCompany", ex);
			}
		}
		#endregion
		#endregion


		#region Smart SOA連携
		#region FindSyncLoginUser
		/// <summary>
		/// Smart SOA 連携用抽出メソッド
		/// 検索条件で一致したレコードを返します。削除済ユーザも対象
		/// </summary>
		/// <returns>一致レコード数</returns>
		public DataResult<DataTable> FindSyncLoginUser(QueryObject queryObj)
		{
			DataResult<DataTable> res;
			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					OracleCommand cmd = connection.CreateCommand() as OracleCommand;

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					DataTable dt = bc.FindSyncLoginUser(cmd, queryObj);
					res = new DataResult<DataTable>(dt != null, dt);

					return res;
				}

			}
			catch (Exception ex)
			{
				return (DataResult<DataTable>)base.HandleException("FindSyncLoginUser", ex, typeof(DataResult<DataTable>));
			}
		}
		#endregion

		#region DeleteAllLoginUser
		/// <summary>
		/// すべてのユーザを削除する
		/// </summary>
		public Result DeleteAllLoginUser()
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.DeleteAllLoginUser());
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteAllLoginUser", ex);
			}
		}
		#endregion

		#region ImportLoginUser
		/// <summary>
		/// 利用者のインポート Delete-Insert
		/// </summary>
		public Result ImportLoginUser(params LoginUserVO[] vos)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.ImportLoginUser(vos));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("ImportLoginUser", ex);
			}
		}
		#endregion

		#region ImportDiffLoginUser
		/// <summary>
		/// 利用者の差分インポート
		/// </summary>
		/// <param name="updVos">追加・更新情報のVOの配列</param>
		/// <param name="delKeys">削除する情報のKeyの配列</param>
		public Result ImportDiffLoginUser(LoginUserVO[] updVos, LoginUserKey[] delKeys)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					res = new Result(bc.ImportDiffLoginUser(updVos, delKeys));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("ImportDiffLoginUser", ex);
			}
		}
		#endregion

		#region DeleteAllCompany
		/// <summary>
		/// すべての会社を削除する
		/// </summary>
		public Result DeleteAllCompany()
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CompanyBC bc = new CompanyBC(loginUserInfo, connection);
					res = new Result(bc.DeleteAllCompany());
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("DeleteAllCompany", ex);
			}
		}
		#endregion

		#region ImportCompany
		/// <summary>
		/// すべての会社情報をインポートする。Delete-Insert
		/// </summary>
		public Result ImportCompany(params CompanyVO[] vos)
		{
			Result res;

			try
			{
				using (OracleConnection connection = GetConnection())
				{
					connection.Open();
					//DbCommand cmd = connection.CreateCommand();

					CompanyBC bc = new CompanyBC(loginUserInfo, connection);
					res = new Result(bc.ImportCompany(vos));
					return res;
				}
			}
			catch (Exception ex)
			{
				return base.HandleException("ImportCompany", ex);
			}
		}
		#endregion
		#endregion


		#region privateメソッド
		/// <summary>
		/// ログイン失敗履歴をリセットします。
		/// </summary>
		/// <remarks>ログイン失敗履歴のレコードが存在しない場合は何もしません</remarks>
		/// <param name="vo">ユーザ情報が格納されたvo</param>
		public Result ResetLoginFailureHistory(LoginUserInfoVO vo)
		{
			// データをテーブルに追加
			using (OracleConnection connection = GetConnection())
			{
				OracleCommand cmd = null;
				try
				{
					connection.Open();
					cmd = connection.CreateCommand() as OracleCommand;

					OracleTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) as OracleTransaction;
					cmd.Transaction = transaction;

					//Exclusionテーブルを削除
					LoginInfoDac infoDac = new LoginInfoDac(connection);
					infoDac.ExclusionDelete(cmd, loginUserInfo.LoginId);

					LoginFailureDac dac = new LoginFailureDac(connection);
					LoginUserBC bc = new LoginUserBC(loginUserInfo, connection);
					if (dac.CheckLoginId(cmd, vo.LoginId))
					{
						//レコードが存在する
						LoginFailureVO failVo = new LoginFailureVO();
						failVo.LoginId = vo.LoginId;
						failVo.FailureCount = 0;
						bc.UpdateLoginFailure(cmd, failVo);
					}
					return new Result(true);
				}
				catch (Exception ex)
				{
					cmd.Transaction.Rollback();
					return base.HandleException("ResetLoginFailureHistory", ex);
				}
				finally
				{
					if (cmd.Transaction != null)
					{
						cmd.Transaction.Commit();
					}
				}
			}
		}
		#endregion
	}
}