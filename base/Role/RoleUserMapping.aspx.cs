// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using System.Text;

public partial class Role_RoleUserMapping : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			string roleId = Convert.ToString(HttpContext.Current.Items["RoleId"]);
			ViewState["RoleId"] = roleId;

			LoginUserInfoVO infoVO = new LoginUserInfoVO();
			infoVO.LoginId = LoginUserContext.LoginId;
			RoleService service = new RoleService(infoVO);
			DataResult<DataTable> res = service.GetRole(new RoleKey(roleId));
			if (!res.IsSuccess)
			{
				//エラー
				throw new ApplicationException("ロール情報取得に失敗しました。");
			}

			if (res.ResultData.Rows.Count > 0)
			{
				RoleIdValueLbl.Text = Convert.ToString(res.ResultData.Rows[0]["ROLE_ID"]);
				RoleNameLbl.Text = Convert.ToString(res.ResultData.Rows[0]["ROLE_NAME"]);
				SessionManager.SetObject(res.ResultData, "Role", "RoleUserMap");
			}
			else
			{
				//排他エラー
				MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
				BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
				BusinessErrorMessage.Visible = true;

				UpdateBtn.Enabled = false;
				SearchBtn.Enabled = false;
				AddBtn.Enabled = false;
				DelBtn.Enabled = false;
				return;
			}

			#region DDLにデータをバインド
			//組織リストにバインド
			DataTable compDt = CompanyMst.GetAllCompanyList();
			CompanyList.DataSource = compDt;
			CompanyList.DataTextField = "COMPANY_NAME";
			CompanyList.DataValueField = "COMPANY_ID";

			CompanyList.DataBind();
			CompanyList.Items.Insert(0, new ListItem());
			#endregion

			#region ロールのユーザを取得
			DataResult<DataTable> userRes = service.GetRoleUserByRoleId(roleId);
			if (!userRes.IsSuccess)
				throw new ApplicationException("ロールユーザマッピング情報取得に失敗しました。");

			//セッションに詰めておく
			SessionManager.SetObject(userRes.ResultData, "RoleUserList", "RoleUserMap");
			RoleUserList.DataSource = userRes.ResultData;
			RoleUserList.DataBind();
			#endregion

		}

		//初期化
		BusinessErrorMessage.Visible = false;
	}

	/// <summary>
	/// フォームのデータを表示する。
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			FormResource resource = ResourceManager.GetInstance().GetFormResource("RoleUserMapping");

			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			RoleLbl.Text = resource.GetString("RoleLbl");
			SearchBtn.Text = resource.GetString("SearchBtn");
			AddBtn.Text = resource.GetString("AddBtn");
			DelBtn.Text = resource.GetString("DelBtn");
			UpdateBtn.Text = resource.GetString("UpdateBtn");
			CancelBtn.Text = resource.GetString("CancelBtn");
			QueryLbl.Text = resource.GetString("QueryLbl");
			CompanyLbl.Text = resource.GetString("CompanyLbl");
			LoginIdLbl.Text = resource.GetString("LoginIdLbl");
			NameLbl.Text = resource.GetString("NameLbl");
			// エラーメッセージ
			//LoginIdInvalidCharValid.Text = resource.GetString("LoginIdInvalidCharValid");
			//NameInvalidCharValid.Text = resource.GetString("NameInvalidCharValid");
		}
	}

	#region バインドイベント

	/// <summary>
	/// ロールユーザリストのバインドイベント
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void RoleUserList_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string companyId = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "COMPANY_ID"));
			//会社名
			Label compLbl = (Label)e.Row.FindControl("CompanyLbl");
			compLbl.Text = CompanyMst.GetCompanyName(companyId);
		}
	}

	/// <summary>
	/// 検索結果リストのバインドイベント
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void SearchList_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			DataTable userDt = (DataTable)SessionManager.GetObject("RoleUserList", "RoleUserMap");

			string loginId = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "LOGIN_ID"));
			string companyId = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "COMPANY_ID"));

			//ロールユーザリストに追加されているものは非表示に
			DataRow[] rows = userDt.Select("LOGIN_ID = '" + loginId + "'");

			foreach (DataRow row in rows)
			{
				if (loginId == Convert.ToString(row["LOGIN_ID"]))
				{
					e.Row.Visible = false;
					return;
				}
			}

			//会社名
			Label compLbl = (Label)e.Row.FindControl("CompanyLbl");
			compLbl.Text = CompanyMst.GetCompanyName(companyId);
		}
	}

	#endregion

	#region クリックイベント

	/// <summary>
	/// 検索ボタンクリックイベント
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void SearchBtn_Click(object sender, EventArgs e)
	{
		//組織と役職の条件からユーザを一覧表示
		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		LoginUserService service = new LoginUserService(infoVO);

		QueryObject query = new QueryObject();
		//ログインID
		if (!string.IsNullOrEmpty(LoginIdBox.Text))
			query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, LoginIdBox.Text));
		//名前
		if (!string.IsNullOrEmpty(NameBox.Text))
			query.AddFinder(Criteria.Contain("NAME", "N", null, NameBox.Text));
		//会社
		if (!string.IsNullOrEmpty(CompanyList.SelectedValue))
			query.AddFinder(Criteria.Equal("COMPANY_ID", null, null, CompanyList.SelectedValue));

		query.AddFinder(Criteria.Equal("USER_TYPE", null, null, WebConstantUtil.LOGIN_USER_TYPE_GENERAL));

		//データ取得
		DataResult<DataTable> res = service.FindLoginUser(query);

		//エラー処理
		if (!res.IsSuccess)
		{
			throw new ApplicationException("利用者情報検索に失敗しました。");
		}

		SearchList.DataSource = res.ResultData;
		SearchList.DataBind();

		SessionManager.SetObject(res.ResultData, "SearchList", "RoleUserMap");
	}

	/// <summary>
	/// 追加ボタンクリックイベント
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void AddBtn_Click(object sender, EventArgs e)
	{
		DataTable searchDt = (DataTable)SessionManager.GetObject("SearchList", "RoleUserMap");
		DataTable userDt = (DataTable)SessionManager.GetObject("RoleUserList", "RoleUserMap");

		foreach (GridViewRow row in SearchList.Rows)
		{
			CheckBox checkBox = (CheckBox)row.FindControl("UserCheckBox");
			if (checkBox.Checked)
			{
				userDt.Rows.Add(searchDt.Rows[row.RowIndex].ItemArray);
			}
		}

		SearchList.DataSource = searchDt;
		SearchList.DataBind();

		RoleUserList.DataSource = userDt;
		RoleUserList.DataBind();
	}

	/// <summary>
	/// 削除ボタンクリックイベント
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void DelBtn_Click(object sender, EventArgs e)
	{
		DataTable searchDt = (DataTable)SessionManager.GetObject("SearchList", "RoleUserMap");
		DataTable userDt = (DataTable)SessionManager.GetObject("RoleUserList", "RoleUserMap");

		for (int i = RoleUserList.Rows.Count - 1; i >= 0; --i)
		{
			CheckBox checkBox = (CheckBox)RoleUserList.Rows[i].FindControl("UserCheckBox");
			if (checkBox.Checked)
			{
				userDt.Rows.RemoveAt(RoleUserList.Rows[i].RowIndex);
			}
		}

		SearchList.DataSource = searchDt;
		SearchList.DataBind();

		RoleUserList.DataSource = userDt;
		RoleUserList.DataBind();
	}

	/// <summary>
	/// キャンセルボタンクリックイベント
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void CancelBtn_Click(object sender, EventArgs e)
	{
		SessionManager.SessionRemoveByPgID("RoleUserMap");
		Server.Transfer("RoleList.aspx");
	}

	/// <summary>
	/// 更新ボタンクリックイベント
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void UpdateBtn_Click(object sender, EventArgs e)
	{
		DataTable roleDt = (DataTable)SessionManager.GetObject("Role", "RoleUserMap");
		RoleVO roleVO = new RoleVO();
		roleVO.RoleId = Convert.ToString(roleDt.Rows[0]["ROLE_ID"]);
		roleVO.RoleName = Convert.ToString(roleDt.Rows[0]["ROLE_NAME"]);
		roleVO.RoleNote = Convert.ToString(roleDt.Rows[0]["ROLE_NOTE"]);
		roleVO.RowUpdateId = Convert.ToString(roleDt.Rows[0]["ROW_UPDATE_ID"]);


		DataTable mapDt = (DataTable)SessionManager.GetObject("RoleUserList", "RoleUserMap");
		List<RoleUserMapVO> list = new List<RoleUserMapVO>();
		foreach (DataRow row in mapDt.Rows)
		{
			RoleUserMapVO vo = new RoleUserMapVO();
			vo.LoginId = Convert.ToString(row["LOGIN_ID"]);
			vo.RoleId = Convert.ToString(ViewState["RoleId"]);
			list.Add(vo);
		}

		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		RoleService service = new RoleService(infoVO);
		Result res = service.UpdateRoleUserMap(roleVO, list.ToArray());

		if (!res.IsSuccess)
		{
			if (res.HasError)
			{
				//排他エラーもしくはビジネスエラー
				MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
				BusinessErrorMessage.Text = resource.GetString(res.Errors[0].ErrorCode);
				BusinessErrorMessage.Visible = true;
				return;
			}
			else
			{
				throw new ApplicationException("ロールユーザ更新に失敗しました。");
			}
		}

		FunctionAuthorizationMst.ClearCache();

		LoginMst.SetLoginInfo(LoginUserContext.LoginId);

		SessionManager.SessionRemoveByPgID("RoleUserMap");
		Server.Transfer("RoleList.aspx");
	}

	#endregion

	protected void AllCheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		foreach (GridViewRow row in SearchList.Rows)
		{
			if (row.RowType == DataControlRowType.DataRow && row.Visible)
			{
				CheckBox checkBox = (CheckBox)row.FindControl("UserCheckBox");
				checkBox.Checked = ((CheckBox)sender).Checked;
			}
		}
	}

	protected void AllCheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		foreach (GridViewRow row in RoleUserList.Rows)
		{
			if (row.RowType == DataControlRowType.DataRow && row.Visible)
			{
				CheckBox checkBox = (CheckBox)row.FindControl("UserCheckBox");
				checkBox.Checked = ((CheckBox)sender).Checked;
			}
		}
	}
}
