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
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;

public partial class UserMst_UserMst : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			SessionManager.SessionRemoveByPgID("LoginUserEdit");
			#region 会社DDLにデータをバインド
			CompanyDrop.DataSource = CompanyMst.GetAllCompanyList();
			CompanyDrop.DataTextField = "COMPANY_NAME";
			CompanyDrop.DataValueField = "COMPANY_ID";
			CompanyDrop.DataBind();
			CompanyDrop.Items.Insert(0, new ListItem());
			#endregion
			if (!string.IsNullOrEmpty(Request.Params.Get("IsInit")))
			{
				SessionManager.SessionRemoveByPgID("LoginUser");
			}
			#region 再検索
			//セッションから検索条件取得
			QueryObject query = (QueryObject)SessionManager.GetObject("ResearchCondition", "LoginUser");
			if (query != null)
			{

				LoginUserInfoVO infoVO = new LoginUserInfoVO();
				infoVO.LoginId = LoginUserContext.LoginId;
				LoginUserService service1 = new LoginUserService(infoVO);

				int pageindex = Convert.ToInt32(SessionManager.GetObject("PageIndex", "LoginUser"));

				//検索結果件数取得
				DataResult<int> res2 = service1.FindCountLoginUser(query);
				int a = 0;
				if (res2.ResultData % Pager.PageSize != 0)
				{
					a = 1;
				}
				int b = res2.ResultData / Pager.PageSize + a - 1;
				if (b < 0)
					b = 0;
				if (pageindex > b)
				{
					pageindex = b;
				}

				query.StartRow = Pager.PageSize * pageindex;
				query.MaxRowCount = Pager.PageSize;

				DataResult<DataTable> res1 = service1.FindLoginUser(query);

				//GridViewにバインド
				M1.DataSource = res1.ResultData;
				M1.DataBind();

				//検索結果全件数
				Pager.VirtualItemCount = res2.ResultData;

				Pager.CurrentPageIndex = pageindex;

			}
			#endregion
		}
	}

	/// <summary>
	/// フォームのデータを表示する。
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			#region 標題セット
			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginUser01");

			//標題をセットする
			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			AddBtn.Text = resource.GetString("AddBtn");
			LoginIdLbl.Text = resource.GetString("LoginIdLbl");
			UsernameLbl.Text = resource.GetString("UsernameLbl");
			CompanyLbl.Text = resource.GetString("CompanyLbl");
			UploadBtn.Text = resource.GetString("UploadBtn");
			SearchBtn.Text = resource.GetString("SearchBtn");

			M1.Columns[0].HeaderText = resource.GetString("M1_COMPANY");
			M1.Columns[1].HeaderText = resource.GetString("M1_ID");
			M1.Columns[2].HeaderText = resource.GetString("M1_NAME");
			M1.Columns[3].HeaderText = resource.GetString("M1_UPDATE");
			M1.Columns[4].HeaderText = resource.GetString("M1_DELETE");
			M1.Columns[5].HeaderText = resource.GetString("M1_ROLE");

			//ボタンフィールド中のボタンのテキスト表示
			((ButtonField)M1.Columns[3]).Text = resource.GetString("M1_UpdBtn");
			((ButtonField)M1.Columns[4]).Text = resource.GetString("M1_DelBtn");
			((ButtonField)M1.Columns[5]).Text = resource.GetString("M1_RoleBtn");

			//エラーメッセージ
			//LoginIdInvalidCharValid.Text = resource.GetString("LoginIdInvalidCharValid");
			//UserNameInvalidCharValid.Text = resource.GetString("UserNameInvalidCharValid");
			#endregion

			#region ボタンの表示
			if (SystemSettings.LoginUserSynchroBent == LoginUserConstantUtil.LOGIN_USER_SYNCHRO_IN)
			{
				//ボタンを無効にする
				AddBtn.Enabled = false;
				UploadBtn.Enabled = false;
				M1.Columns[3].Visible = false;
				M1.Columns[4].Visible = false;

			}
			#endregion
		}
	}

	protected void AddBtn_Click(object sender, EventArgs e)
	{
		Server.Transfer("LoginUser02.aspx");
	}

	protected void M1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int index = Convert.ToInt32(e.CommandArgument);
		string loginId = ((Label)M1.Rows[index].FindControl("GridLoginIDLbl")).Text;
		HttpContext.Current.Items.Add("loginId", loginId);
		if (e.CommandName == "EditRow")
		{
			//編集ボタンイベント
			Server.Transfer("LoginUser02.aspx");
		}
		else if (e.CommandName == "DeleteRow")
		{
			//削除ボタンイベント
			Server.Transfer("LoginUser04.aspx");
		}
		else if (e.CommandName == "RoleRow")
		{
			//ロール設定ボタンイベント
			Server.Transfer("LoginUserRoleMapping.aspx");
		}
	}
	/// <summary>
	/// 検索ボタンクリックイベント
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void SearchBtn_Click(object sender, EventArgs e)
	{
		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		LoginUserService service = new LoginUserService(infoVO);
		QueryObject query = new QueryObject();

		//ログインID
		if (!string.IsNullOrEmpty(LoginIdBox.Text))
			query.AddFinder(Criteria.Equal("LOGIN_ID", null, null, LoginIdBox.Text));
		//名前
		if (!string.IsNullOrEmpty(UsernameBox.Text))
			query.AddFinder(Criteria.Contain("NAME", "N", null, UsernameBox.Text));
		//会社
		if (!string.IsNullOrEmpty(CompanyDrop.SelectedValue))
			query.AddFinder(Criteria.Equal("COMPANY_ID", null, null, CompanyDrop.SelectedValue));

		//一般ユーザのみ表示
		query.AddFinder(Criteria.Equal("USER_TYPE", null, null, WebConstantUtil.LOGIN_USER_TYPE_GENERAL));

		query.StartRow = 0;
		query.MaxRowCount = Pager.PageSize;

		//検索結果件数取得
		DataResult<int> res = service.FindCountLoginUser(query);

		//データ取得
		DataResult<DataTable> res2 = service.FindLoginUser(query);

		//エラー処理
		if (!res.IsSuccess)
		{
			throw new ApplicationException("利用者情報検索に失敗しました。");
		}

		M1.DataSource = res2.ResultData;
		M1.DataBind();

		//検索結果全件数
		Pager.VirtualItemCount = res.ResultData;

		//現在のページ番号
		Pager.CurrentPageIndex = 0;
		SessionManager.SetObject(0, "PageIndex", "LoginUser");

		//検索条件セッション保存
		SessionManager.SetObject(query, "ResearchCondition", "LoginUser");

	}

	/// <summary>
	/// ページングイベント
	/// </summary>
	/// <param name="source"></param>
	/// <param name="e"></param>
	protected void Pager_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
	{

		//セッションから検索条件取得
		QueryObject query = (QueryObject)SessionManager.GetObject("ResearchCondition", "LoginUser");
		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		LoginUserService service = new LoginUserService(infoVO);
		//検索結果件数取得
		DataResult<int> res = service.FindCountLoginUser(query);

		//ページデータ取得
		query.StartRow = Pager.PageSize * e.NewPageIndex;
		query.MaxRowCount = Pager.PageSize;

		DataResult<DataTable> res1 = service.FindLoginUser(query);

		//GridViewにバインド
		M1.DataSource = res1.ResultData;
		M1.DataBind();


		//検索結果全件数
		Pager.VirtualItemCount = res.ResultData;
		//現在のページ設定
		Pager.CurrentPageIndex = e.NewPageIndex;
		SessionManager.SetObject(e.NewPageIndex, "PageIndex", "LoginUser");

		//検索条件セッション保存
		SessionManager.SetObject(query, "ResearchCondition", "LoginUser");
	}

	protected void M1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string companyId = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "COMPANY_ID"));

			Label companyLbl = (Label)e.Row.FindControl("GridCompanyLbl");
			companyLbl.Text = CompanyMst.GetCompanyName(companyId);


		}
	}
	protected void UploadBtn_Click(object sender, EventArgs e)
	{
		Server.Transfer("UserUpload.aspx");
	}
}
