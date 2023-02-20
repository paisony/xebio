// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Systems;
using System.Text.RegularExpressions;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using Com.Fujitsu.SmartBase.Base.DataLog;

public partial class Role_RoleEdit : System.Web.UI.Page
{
	#region ページロード
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			#region 初期データをセット
			string roleId = Convert.ToString(HttpContext.Current.Items["RoleId"]);
			RoleVO roleVO = (RoleVO)SessionManager.GetObject("RoleVO", "RoleEdit");

			// 編集
			if (!string.IsNullOrEmpty(roleId))
			{
				//ロールID編集不可
				RoleId.Enabled = false;

				//ＤＢから初期データ取得
				LoginUserInfoVO loginInfo = new LoginUserInfoVO();
				loginInfo.LoginId = LoginUserContext.LoginId;

				RoleService rolesv = new RoleService(loginInfo);

				#region ロール情報

				RoleKey key = new RoleKey(roleId);
				DataResult<DataTable> roleRes = rolesv.GetRole(key);

				//ロール情報
				if (roleRes.IsSuccess)
				{
					if (roleRes.ResultData.Rows.Count > 0)
					{
						roleVO = new RoleVO();

						roleVO.RoleId = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_ID"]);
						roleVO.RoleName = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_NAME"]);
						roleVO.RoleNote = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_NOTE"]);
						roleVO.RowUpdateId = Convert.ToString(roleRes.ResultData.Rows[0]["ROW_UPDATE_ID"]);

						RoleId.Text = roleVO.RoleId;
						RoleName.Text = roleVO.RoleName;
						RoleNote.Text = roleVO.RoleNote;

						SessionManager.SetObject(roleVO, "RoleVO", "RoleEdit");
					}
					else
					{
						//排他エラー
						MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
						BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
						BusinessErrorMessage.Visible = true;

						UpdateBtn.Enabled = false;
						return;
					}

				}
				else
				{
					throw new ApplicationException("ロール情報取得に失敗しました。");
				}

				#endregion

				#region システム使用許可取得

				Dictionary<string, string> systemAuthorization = new Dictionary<string, string>();
				//システム使用許可取得
				DataResult<DataTable> authRes = rolesv.GetSystemAuthorizationByRoleId(roleId);
				if (!authRes.IsSuccess)
					throw new ApplicationException("システム使用許可情報取得に失敗しました。");
				foreach (DataRow row in authRes.ResultData.Rows)
				{
					string solutionId = Convert.ToString(row["SOLUTION_ID"]);
					string sortNo = Convert.ToString(row["SORT_NO"]);
					systemAuthorization.Add(solutionId, sortNo);
				}

				SessionManager.SetObject(systemAuthorization, "SystemAuthorization", "RoleEdit");

				#endregion

				#region 機能使用許可情報

				DataResult<DataTable> funcRes = rolesv.GetFunctionAuthorizationByRoleId(roleId);

				//機能使用許可情報
				if (funcRes.IsSuccess)
				{
					SessionManager.SetObject(funcRes.ResultData, "FunctionAuthorization", "RoleEdit");
				}
				else
				{
					throw new ApplicationException("機能使用許可情報取得に失敗しました。");
				}

				#endregion

			}
			//確認画面から遷移
			else if (roleVO != null)
			{
				RoleName.Text = roleVO.RoleName;
				RoleNote.Text = roleVO.RoleNote;
			}
			//新規作成
			else
			{
				SessionManager.SetObject(new RoleVO(), "RoleVO", "RoleEdit");
			}

			//ソリューション情報取得
			SystemService syssv = new SystemService();
			DataResult<DataTable> solRes = syssv.GetAllSolution();

			if (solRes.IsSuccess)
			{
				AuthorizationList.DataSource = solRes.ResultData;
				AuthorizationList.DataBind();
			}
			else
			{
				throw new ApplicationException("ソリューション情報取得に失敗しました。");
			}
			#endregion
		}
		BusinessErrorMessage.Visible = false;
	}
	#endregion

	#region フォームのデータを表示
	/// <summary>
	/// フォームのデータを表示する。
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("RoleEdit");

			//標題をセットする
			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			NoteLbl.Text = resource.GetString("NoteLbl");
			UpdateBtn.Text = resource.GetString("EditNew");
			BackBtn.Text = resource.GetString("EditClose");
			RoleCutline.Text = resource.GetString("RoleCutline");
			RoleNameLbl.Text = resource.GetString("RoleNameLbl");
			RoleNoteCutline.Text = resource.GetString("RoleNoteCutline");
			RoleIDLbl.Text = resource.GetString("RoleIDLbl");
			RoleIdCutline.Text = resource.GetString("RoleIdCutline");
			//エラーメッセージ
			RoleNameReqValid.ErrorMessage = resource.GetString("RoleNameReqValid");
			//RoleNameInvalidCharValid.Text = resource.GetString("RoleNameInvalidCharValid");
			//RoleNoteInvalidCharValid.Text = resource.GetString("RoleNoteInvalidCharValid");
			RoleNoteRegValid.ErrorMessage = resource.GetString("RoleNoteValid");
			SortValid.ErrorMessage = resource.GetString("SortValid");
			RoleIdReqValid.ErrorMessage = resource.GetString("RoleIdReqValid");
			RoleIdRegValid.ErrorMessage = resource.GetString("RoleIdRegValid");



		}
	}
	#endregion

	#region 戻るボタン押下時
	/// <summary>
	/// 戻るボタン押下時
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void BackBtn_Click(object sender, EventArgs e)
	{
		SessionManager.SessionRemoveByPgID("RoleEdit");
		Server.Transfer("RoleList.aspx");
	}
	#endregion

	protected void AuthorizationList_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string solutionId = ((Label)e.Row.FindControl("SolutionId")).Text;

			//使用許可を取得する。
			Dictionary<string, string> systemAuthorization = (Dictionary<string, string>)SessionManager.GetObject("SystemAuthorization", "RoleEdit");

			if (systemAuthorization != null && systemAuthorization.ContainsKey(solutionId))
			{
				CheckBox allow = (CheckBox)e.Row.FindControl("AllowCheckBox");
				allow.Checked = true;
				TextBox sort = (TextBox)e.Row.FindControl("SortBox");
				sort.Text = systemAuthorization[solutionId];
			}
		}
	}

	/// <summary>
	/// ロールの更新ボタンを押下したときに発生するイベント
	/// ロールの新規作成もしくはロールの更新処理を行う
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void UpdateBtn_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid) return;

		#region ロールVOをセット
		LoginUserInfoVO loginInfo = new LoginUserInfoVO();
		loginInfo.LoginId = LoginUserContext.LoginId;
		RoleService rs = new RoleService(loginInfo);

		RoleVO roleVO = (RoleVO)SessionManager.GetObject("RoleVO", "RoleEdit");

		roleVO.RoleId = RoleId.Text;
		roleVO.RoleName = RoleName.Text;
		roleVO.RoleNote = RoleNote.Text;

		#endregion

		#region システム使用許可をセット

		List<SystemAuthorizationVO> authVOs = new List<SystemAuthorizationVO>();
		//使用可能なソリューションIDをセットしておく
		List<string> solutionIds = new List<string>();
		foreach (GridViewRow row in AuthorizationList.Rows)
		{
			if (((CheckBox)row.FindControl("AllowCheckBox")).Checked)
			{
				//チェックされていた場合は追加する
				SystemAuthorizationVO authVO = new SystemAuthorizationVO();
				authVO.RoleId = Convert.ToString(roleVO.RoleId);
				authVO.SolutionId = ((Label)row.FindControl("SolutionId")).Text;
				authVO.SortNo = Convert.ToInt32(((TextBox)row.FindControl("SortBox")).Text);
				authVOs.Add(authVO);
				solutionIds.Add(authVO.SolutionId);
			}
		}
		#endregion

		#region 機能使用許可をセット

		List<FunctionAuthorizationVO> funcVOs = new List<FunctionAuthorizationVO>();
		DataTable funcDt = (DataTable)SessionManager.GetObject("FunctionAuthorization", "RoleEdit");
		if (funcDt != null)
		{
			foreach (DataRow row in funcDt.Rows)
			{
				FunctionAuthorizationVO funcVO = new FunctionAuthorizationVO();
				funcVO.RoleId = roleVO.RoleId;
				funcVO.SolutionId = Convert.ToString(row["SOLUTION_ID"]);
				funcVO.FunctionId = Convert.ToString(row["FUNCTION_ID"]);
				//使用可能なソリューションの機能のみ追加する。
				if (solutionIds.Contains(funcVO.SolutionId))
					funcVOs.Add(funcVO);
			}
		}

		#endregion

		Result res = null;
		if (RoleId.Enabled)
		{
			// 権限情報を新規登録
			res = rs.InsertRole(roleVO, authVOs.ToArray(), funcVOs.ToArray());
		}
		else
		{
			// 権限情報を更新
			res = rs.UpdateRole(roleVO, authVOs.ToArray(), funcVOs.ToArray());
		}

		//キャッシュクリア
		FunctionAuthorizationMst.ClearCache();

		#region エラー処理
		if (!res.IsSuccess && res.HasError)
		{
			MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
			if (res.Errors[0] is DBConcurrencyError)
			{
				// 排他エラー
				BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
				BusinessErrorMessage.Visible = true;
				return;
			}
			else
			{
				//ビジネスロジックエラー
				BusinessErrorMessage.Text = resource.GetString(res.Errors[0].ErrorCode);
				BusinessErrorMessage.Visible = true;
				return;
			}
		}
		else if (!res.IsSuccess)
		{
			throw new ApplicationException("ロール情報の登録に失敗しました。" + res.ToString());
		}
		#endregion

		//セッションクリア
		SessionManager.SessionRemoveByPgID("RoleEdit");

		Server.Transfer("RoleList.aspx");
	}

	/// <summary>
	/// 表示順の入力チェック
	/// 使用許可がチェックされているものだけチェックする。
	/// </summary>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void SortValid_ServerValidate(object source, ServerValidateEventArgs args)
	{
		bool valid = true;
		foreach (GridViewRow row in AuthorizationList.Rows)
		{
			CheckBox check = (CheckBox)row.FindControl("AllowCheckBox");
			if (check.Checked)
			{
				TextBox sort = (TextBox)row.FindControl("SortBox");
				valid = valid && Regex.IsMatch(sort.Text, "^[0-9]{1,4}$");
			}
		}
		args.IsValid = valid;
	}
}
