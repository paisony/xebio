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
using System.Drawing;

public partial class Access_UserLock : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//他のページから遷移する場合
		if (!Page.IsPostBack)
		{
			//検索条件をクリアする
			SessionManager.SessionRemoveByPgID("ResearchCondition");

			#region 会社DDLにデータをバインド
			CompanyDrop.DataSource = CompanyMst.GetAllCompanyList();
			CompanyDrop.DataTextField = "COMPANY_NAME";
			CompanyDrop.DataValueField = "COMPANY_ID";
			CompanyDrop.DataBind();
			CompanyDrop.Items.Insert(0, new ListItem());
			#endregion

			if (!string.IsNullOrEmpty(Request.Params.Get("IsInit")))
				SessionManager.SessionRemoveByPgID("LoginUser");
		}
	}

	/// <summary>
	/// フォームのデータを表示する。
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		//他のページから遷移する場合
		if (!base.IsPostBack)
		{
			#region 標題セット
			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("UserLock");

			//「ロック状態」項目のラジオボタンの初期化

			RadioListLock.Items.Add(new ListItem(resource.GetString("CAPTION_ALL"), "2"));
			RadioListLock.Items.Add(new ListItem(resource.GetString("CAPTION_LOCK"), "1"));
			RadioListLock.Items.Add(new ListItem(resource.GetString("CAPTION_OPEN"), "0"));

			//表示状態ラジオボタンの値をセット：全て
			RadioListLock.SelectedValue = "2";

			//標題をセットする
			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			BackBtn.Text = resource.GetString("BackBtn");
			LoginIdLbl.Text = resource.GetString("LoginIdLbl");
			UsernameLbl.Text = resource.GetString("UsernameLbl");
			CompanyLbl.Text = resource.GetString("CompanyLbl");
			LockLbl.Text = resource.GetString("LockLbl");
			SearchBtn.Text = resource.GetString("SearchBtn");

			M1.Columns[0].HeaderText = resource.GetString("M1_COMPANY");
			M1.Columns[1].HeaderText = resource.GetString("M1_ID");
			M1.Columns[2].HeaderText = resource.GetString("M1_NAME");
			M1.Columns[3].HeaderText = resource.GetString("M1_LOCK");

			// エラーメッセージ
//			LoginIdInvalidCharValid.Text = resource.GetString("LoginIdInvalidCharValid");
//			UserNameInvalidCharValid.Text = resource.GetString("UserNameInvalidCharValid");
			#endregion

			#region ボタンの表示
			//if (SystemSettings.LoginUserSynchroBent == LoginUserConstantUtil.LOGIN_USER_SYNCHRO_IN)
			//{
			//    //ボタンを無効にする
			//    M1.Columns[3].Visible = false;
			//}
			#endregion
		}
		//ページ内のボタン（リンク）が押される場合
		else
		{
			#region 検索（再検索）
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
				//ページ数(b)取得
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
				//ボタンテキスト表示
				foreach (DataRow row in res1.ResultData.Rows)
				{
					if (row["LOCK_FLAG"].ToString() == "1")
					{
						row["LOCK_FLAG"] = "解 除";
					}
					else
					{
						row["LOCK_FLAG"] = "ロック";
					}
				}
				//GridViewにバインド
				M1.DataSource = res1.ResultData;
				M1.DataBind();
				//ロックされている利用者の行の色を赤に変える
				for (int index = 0; index < res1.ResultData.Rows.Count; index++)
				{
					if (((Label)M1.Rows[index].FindControl("GridLockFlagLbl")).Text == "解 除")
					{
						M1.Rows[index].BackColor = Color.Red;
						M1.Rows[index].ForeColor = Color.Wheat;
						M1.Rows[index].Font.Bold = true;
					}
				}
				//検索結果全件数
				Pager.VirtualItemCount = res2.ResultData;

				Pager.CurrentPageIndex = pageindex;
			}
			#endregion
		}
	}

	#region 利用者ロック状態変更
	protected void M1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int index = Convert.ToInt32(e.CommandArgument);
		string loginId = ((Label)M1.Rows[index].FindControl("GridLoginIDLbl")).Text;
		HttpContext.Current.Items.Add("loginId", loginId);

		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;

		LoginUserService service = new LoginUserService(infoVO);
		LoginUserKey key = new LoginUserKey(loginId);
		DataResult<DataTable> res = service.GetLoginUserData(key);
		if (res.ResultData.Rows.Count == 0)
		{
			return;
		}
		//VOにセットする
		LoginUserVO vo = new LoginUserVO();
		vo.LoginId = Convert.ToString(res.ResultData.Rows[0]["LOGIN_ID"]);
		if (((Label)M1.Rows[index].FindControl("GridLockFlagLbl")).Text == "ロック"
			&& Convert.ToString(res.ResultData.Rows[0]["LOCK_FLAG"]) == "0")
		{
			vo.LockFlag = "0";
		}
		else if (((Label)M1.Rows[index].FindControl("GridLockFlagLbl")).Text == "解 除"
			&& Convert.ToString(res.ResultData.Rows[0]["LOCK_FLAG"]) == "1")
		{
			vo.LockFlag = "1";
		}
		else
		{
			return;
		}
		vo.RowUpdateId = Convert.ToString(res.ResultData.Rows[0]["ROW_UPDATE_ID"]);

		if (e.CommandName == "LockRow")
		{
			//ロック状態更新
			Result res1 = service.UpdateLockFlag(vo);
			if (!res1.IsSuccess)
				throw new ApplicationException("利用者のロック状態更新時にエラーが発生しました。");
		}
	}
	#endregion

	#region 検索
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
		//ロック状態
		if (!string.IsNullOrEmpty(RadioListLock.SelectedValue))
			if (RadioListLock.SelectedValue == "0" || RadioListLock.SelectedValue == "1")
			{
				query.AddFinder(Criteria.Equal("LOCK_FLAG", null, null, RadioListLock.SelectedValue));
			}
		//一般ユーザのみ表示
		query.AddFinder(Criteria.Equal("USER_TYPE", null, null, WebConstantUtil.LOGIN_USER_TYPE_GENERAL));

		query.StartRow = 0;
		query.MaxRowCount = Pager.PageSize;

		//現在のページ番号
		Pager.CurrentPageIndex = 0;
		SessionManager.SetObject(0, "PageIndex", "LoginUser");

		//検索条件セッション保存
		SessionManager.SetObject(query, "ResearchCondition", "LoginUser");
	}
	#endregion

	#region ページ遷移
	/// <summary>
	/// ページングイベント
	/// </summary>
	/// <param name="source"></param>
	/// <param name="e"></param>
	protected void Pager_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
	{
		//セッションから検索条件取得
		QueryObject query = (QueryObject)SessionManager.GetObject("ResearchCondition", "LoginUser");

		//ページデータ取得
		query.StartRow = Pager.PageSize * e.NewPageIndex;
		query.MaxRowCount = Pager.PageSize;

		//現在のページ設定
		Pager.CurrentPageIndex = e.NewPageIndex;
		SessionManager.SetObject(e.NewPageIndex, "PageIndex", "LoginUser");

		//検索条件セッション保存
		SessionManager.SetObject(query, "ResearchCondition", "LoginUser");
	}
	#endregion

	#region 会社名表示
	protected void M1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string companyId = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "COMPANY_ID"));

			Label companyLbl = (Label)e.Row.FindControl("GridCompanyLbl");
			companyLbl.Text = CompanyMst.GetCompanyName(companyId);
		}
	}
	#endregion

	#region 戻る
	/// <summary>
	/// 戻るボタン押下
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void BackBtn_Click(object sender, EventArgs e)
	{
		Server.Transfer("AccessMenu.aspx");
	}
	#endregion
}
