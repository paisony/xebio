// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Web.BizMenu;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Systems;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Systems.VO;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Role.VO;

public partial class role_MenuSetting : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			#region データを取得
			string roleId = Convert.ToString(HttpContext.Current.Items["RoleId"]);

			// 編集
			if (!string.IsNullOrEmpty(roleId))
			{
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
						RoleVO roleVO = new RoleVO();

						roleVO.RoleId = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_ID"]);
						roleVO.RoleName = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_NAME"]);
						roleVO.RoleNote = Convert.ToString(roleRes.ResultData.Rows[0]["ROLE_NOTE"]);
						roleVO.RowUpdateId = Convert.ToString(roleRes.ResultData.Rows[0]["ROW_UPDATE_ID"]);

						SessionManager.SetObject(roleVO, "RoleVO", "Menu");
					}
					else
					{
						//排他エラー
						MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
						BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
						BusinessErrorMessage.Visible = true;

						OKBtn.Enabled = false;
						return;
					}
				}
				else
					throw new ApplicationException("ロール情報取得に失敗しました。");


				#endregion

				#region システム使用許可取得

				Dictionary<string, int> systemAuthorization = new Dictionary<string, int>();
				//システム使用許可取得
				DataResult<DataTable> authRes = rolesv.GetSystemAuthorizationByRoleId(roleId);
				if (!authRes.IsSuccess)
					throw new ApplicationException("システム使用許可情報取得に失敗しました。");
				foreach (DataRow row in authRes.ResultData.Rows)
				{
					string solutionId = Convert.ToString(row["SOLUTION_ID"]);
					int sortNo = Convert.ToInt32(row["SORT_NO"]);
					systemAuthorization.Add(solutionId, sortNo);
				}

				SessionManager.SetObject(systemAuthorization, "SystemAuthorization", "Menu");

				#endregion

				#region 機能使用許可情報

				DataResult<DataTable> funcRes = rolesv.GetFunctionAuthorizationByRoleId(roleId);

				//機能使用許可情報
				if (funcRes.IsSuccess)
				{
					SessionManager.SetObject(funcRes.ResultData, "FunctionAuthorization", "Menu");
				}
				else
					throw new ApplicationException("機能使用許可情報取得に失敗しました。");


				#endregion

			}
			else
				throw new ApplicationException("ロールID取得に失敗しました。");

			#endregion

			DataTable funcAuthDt = (DataTable)SessionManager.GetObject("FunctionAuthorization", "Menu");
			if (funcAuthDt == null)
			{
				//新規作成の場合はnullなのでスキーマを作成
				funcAuthDt = new DataTable();
				funcAuthDt.Columns.Add(new DataColumn("ROLE_ID"));
				funcAuthDt.Columns.Add(new DataColumn("SOLUTION_ID"));
				funcAuthDt.Columns.Add(new DataColumn("FUNCTION_ID"));
				SessionManager.SetObject(funcAuthDt, "FunctionAuthorization", "Menu");
			}

			//使用許可されたソリューションID取得
			Dictionary<string, int> dic = (Dictionary<string, int>)SessionManager.GetObject("SystemAuthorization", "Menu");
			List<string> solutionIds = new List<string>();
			foreach (string solutionId in dic.Keys)
			{
				solutionIds.Add(solutionId);
			}

			GenerateMenuSetVO root = new GenerateMenuSetVO();
			foreach (string solutionId in solutionIds)
			{
				DataTable dt = FunctionViewMst.GetFunctionView(solutionId, 1, false);
				foreach (DataRow row in dt.Rows)
				{
					GenerateMenuVO vo = new GenerateMenuVO(row);
					root.GenerateMenuVOs.Add(vo);
					SetMenuVO(vo);
				}
			}

			MenuList1.DataSource = root.GenerateMenuVOs;
			MenuList1.DataBind();

			SessionManager.SetObject(root, "MenuVOs", "Menu");
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
			FormResource resource = ResourceManager.GetInstance().GetFormResource("MenuSetting");

			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			OKBtn.Text = resource.GetString("OKBtn");
			CancelBtn.Text = resource.GetString("CancelBtn");

			AllCheck.Value = resource.GetString("AllCheck");
			AllUndo.Value = resource.GetString("AllUndo");

		}
	}

	#region イベント処理

	protected void CancelBtn_Click(object sender, EventArgs e)
	{
		SessionManager.SessionRemoveByPgID("Menu");
		Server.Transfer("RoleList.aspx");
	}

	protected void OKBtn_Click(object sender, EventArgs e)
	{
		DataTable dt = (DataTable)SessionManager.GetObject("FunctionAuthorization", "Menu");
		dt.Clear();
		SetAllowFunction(MenuList1, 1, dt);

		#region 登録処理

		#region ロールVOをセット
		LoginUserInfoVO loginInfo = new LoginUserInfoVO();
		loginInfo.LoginId = LoginUserContext.LoginId;
		RoleService rs = new RoleService(loginInfo);

		RoleVO roleVO = (RoleVO)SessionManager.GetObject("RoleVO", "Menu");

		#endregion

		#region システム使用許可をセット

		Dictionary<string, int> systemAuthorization = (Dictionary<string, int>)SessionManager.GetObject("SystemAuthorization", "Menu");
		List<SystemAuthorizationVO> authVOs = new List<SystemAuthorizationVO>();
		foreach (string solId in systemAuthorization.Keys)
		{
			//チェックされていた場合は追加する
			SystemAuthorizationVO authVO = new SystemAuthorizationVO();
			authVO.RoleId = roleVO.RoleId;
			authVO.SolutionId = solId;
			authVO.SortNo = systemAuthorization[solId];
			authVOs.Add(authVO);
		}

		#endregion

		#region 機能使用許可をセット

		List<FunctionAuthorizationVO> funcVOs = new List<FunctionAuthorizationVO>();
		if (dt != null)
		{
			foreach (DataRow row in dt.Rows)
			{
				FunctionAuthorizationVO funcVO = new FunctionAuthorizationVO();
				funcVO.RoleId = roleVO.RoleId;
				funcVO.SolutionId = Convert.ToString(row["SOLUTION_ID"]);
				funcVO.FunctionId = Convert.ToString(row["FUNCTION_ID"]);
				funcVOs.Add(funcVO);
			}
		}

		#endregion

		// 権限情報を新規登録もしくは更新
		Result res = rs.UpdateRole(roleVO, authVOs.ToArray(), funcVOs.ToArray());

		//キャッシュクリア
		FunctionAuthorizationMst.ClearCache();

		#region エラー処理
		if (!res.IsSuccess && res.HasError && res.Errors[0] is DBConcurrencyError)
		{
			// 排他エラー
			MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
			BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
			BusinessErrorMessage.Visible = true;
			return;
		}
		else if (!res.IsSuccess)
		{
			throw new ApplicationException("ロール情報の登録に失敗しました。" + res.ToString());
		}
		#endregion

		#endregion

		//セッションクリア
		SessionManager.SessionRemoveByPgID("Menu");

		Server.Transfer("RoleList.aspx");
	}

	#endregion

	#region Gridイベント
	protected void MenuList1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			HtmlAnchor displayBtn = (HtmlAnchor)e.Row.FindControl("DisplayBtn");
			HtmlControl div = (HtmlControl)e.Row.FindControl("display1");
			displayBtn.Attributes.Add("onClick", "displayDitail('" + div.ClientID + "')");

			List<GenerateMenuVO> list = (List<GenerateMenuVO>)DataBinder.GetPropertyValue(e.Row.DataItem, "GenerateMenuVOs");

			GridView grid = (GridView)e.Row.FindControl("MenuList2");
			grid.DataSource = list;
			grid.DataBind();
		}
	}
	protected void MenuList2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			HtmlAnchor displayBtn = (HtmlAnchor)e.Row.FindControl("DisplayBtn");
			HtmlControl div = (HtmlControl)e.Row.FindControl("display2");
			displayBtn.Attributes.Add("onClick", "displayDitail('" + div.ClientID + "')");

			List<GenerateMenuVO> list = (List<GenerateMenuVO>)DataBinder.GetPropertyValue(e.Row.DataItem, "GenerateMenuVOs");

			if (list.Count > 0)
			{
				GridView grid = (GridView)e.Row.FindControl("MenuList3");
				grid.DataSource = list;
				grid.DataBind();
			}
			else
			{
				displayBtn.Visible = false;
				CheckBox allow = (CheckBox)e.Row.FindControl("AllowCheckBox");
				allow.Visible = true;

				string solutionId = ((Label)e.Row.FindControl("SolutionId")).Text;
				string functionId = ((Label)e.Row.FindControl("FunctionId")).Text;

				DataTable dt = (DataTable)SessionManager.GetObject("FunctionAuthorization", "Menu");
				DataRow[] rows = dt.Select("SOLUTION_ID = '" + solutionId + "' AND FUNCTION_ID = '" + functionId + "'");
				if (rows.Length > 0)
					allow.Checked = true;
			}
		}
	}

	protected void MenuList3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			HtmlAnchor displayBtn = (HtmlAnchor)e.Row.FindControl("DisplayBtn");
			HtmlControl div = (HtmlControl)e.Row.FindControl("display3");
			displayBtn.Attributes.Add("onClick", "displayDitail('" + div.ClientID + "')");

			List<GenerateMenuVO> list = (List<GenerateMenuVO>)DataBinder.GetPropertyValue(e.Row.DataItem, "GenerateMenuVOs");

			GridView grid = (GridView)e.Row.FindControl("MenuList4");
			grid.DataSource = list;
			grid.DataBind();
		}
	}

	protected void MenuList4_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			HtmlAnchor displayBtn = (HtmlAnchor)e.Row.FindControl("DisplayBtn");
			HtmlControl div = (HtmlControl)e.Row.FindControl("display4");
			displayBtn.Attributes.Add("onClick", "displayDitail('" + div.ClientID + "')");

			List<GenerateMenuVO> list = (List<GenerateMenuVO>)DataBinder.GetPropertyValue(e.Row.DataItem, "GenerateMenuVOs");

			GridView grid = (GridView)e.Row.FindControl("MenuList5");
			grid.DataSource = list;
			grid.DataBind();
		}
	}

	protected void MenuList5_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			CheckBox allow = (CheckBox)e.Row.FindControl("AllowCheckBox");
			string solutionId = ((Label)e.Row.FindControl("SolutionId")).Text;
			string functionId = ((Label)e.Row.FindControl("FunctionId")).Text;

			DataTable dt = (DataTable)SessionManager.GetObject("FunctionAuthorization", "Menu");
			DataRow[] rows = dt.Select("SOLUTION_ID = '" + solutionId + "' AND FUNCTION_ID = '" + functionId + "'");
			if (rows.Length > 0)
				allow.Checked = true;
		}
	}
	#endregion

	#region private

	private void SetMenuVO(GenerateMenuVO vo)
	{
		DataTable dt = FunctionViewMst.GetChilds(vo.SolutionId, vo.FunctionViewId);
		foreach (DataRow row in dt.Rows)
		{
			GenerateMenuVO childVO = new GenerateMenuVO(row);
			vo.GenerateMenuVOs.Add(childVO);
			SetMenuVO(childVO);
		}
		return;
	}

	private void SetAllowFunction(GridView grid, int level, DataTable dt)
	{
		foreach (GridViewRow row in grid.Rows)
		{
			//2,5階層の場合はチェックボックスをチェックする
			if (level == 2 | level == 5)
			{
				CheckBox checkBox = (CheckBox)row.FindControl("AllowCheckBox");
				if (checkBox != null && checkBox.Visible)
				{
					if (checkBox.Checked)
					{
						//レコードを詰める
						Label solutionIdLbl = (Label)row.FindControl("SolutionId");
						string solutionId = solutionIdLbl.Text;
						Label functionIdLbl = (Label)row.FindControl("FunctionId");
						string functionId = functionIdLbl.Text;

						DataRow authRow = dt.NewRow();
						authRow["SOLUTION_ID"] = solutionId;
						authRow["FUNCTION_ID"] = functionId;
						dt.Rows.Add(authRow);
					}
				}
			}

			if (level < 5)
			{
				int childLevel = level + 1;
				//子のGridを取得。再帰処理
				GridView childGrid = (GridView)row.FindControl("MenuList" + childLevel.ToString());
				SetAllowFunction(childGrid, childLevel, dt);
			}
		}
	}

	#endregion
}