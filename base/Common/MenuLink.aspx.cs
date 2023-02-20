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
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Common.Model;

public partial class Common_MenuLink : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			string solutionId = Request.Params.Get("solutionId");
			string functionViewId = Request.Params.Get("functionViewId");

			////メニューを取得する。

			DataTable viewDt = FunctionViewMst.GetFunctionView(solutionId, functionViewId);
			if (viewDt.Rows.Count == 0)
			{
				throw new ApplicationException("機能表示情報取得に失敗しました。");
			}

			GenerateMenuVO menuVO = new GenerateMenuVO(viewDt.Rows[0]);
			SetMenuVO(menuVO);

			//表示設定
			SetMenuVisible(menuVO);

			//メニューグループ名をセット
			MenuGroupNameLbl.Text = menuVO.Name;

			//メニュー情報からメニューリンク作成。
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("Url"));
			dt.Columns.Add(new DataColumn("MenuName"));
			dt.Columns.Add(new DataColumn("MenuNote"));

			foreach (GenerateMenuVO vo in menuVO.GenerateMenuVOs)
			{
				if (!vo.Visible)
					continue;

				DataRow row = dt.NewRow();
				string solId = vo.SolutionId;
				string funcId = vo.FunctionID;

				DataRow funcRow = FunctionMst.GetFunction(solutionId, funcId);

				string winName = Convert.ToString(funcRow["WINDOW_NAME"]);
				if (winName != "_blank" && winName != "_self" && winName != "_top")
					winName = solutionId + "_" + winName;
				string winStyle = Convert.ToString(funcRow["WINDOW_STYLE"]);
				string url = "javascript:openFunction('" + solId + "','" + funcId + "','" + winName + "','" + winStyle + "','0','0')";

				row["Url"] = url;
				row["MenuName"] = vo.Name;
				row["MenuNote"] = vo.Note;
				dt.Rows.Add(row);
			}
			MenuRepeater.DataSource = dt;
			MenuRepeater.DataBind();
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
			#region リソースをセットする。
			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("MenuLink");

			//標題をセットする
			Programtitle.Text = resource.GetString("Programtitle");
			#endregion
		}
	}

	private static void SetMenuVO(GenerateMenuVO vo)
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

	private static bool SetMenuVisible(GenerateMenuVO vo)
	{
		bool visible = false;
		if (!string.IsNullOrEmpty(vo.FunctionID))
		{
			if (LoginUserContext.RoleIds.Count == 0)
			{
				visible = false;
			}
			else
			{
				//機能使用許可をチェック
				foreach (string roleId in LoginUserContext.RoleIds)
				{
					visible = FunctionAuthorizationMst.CheckFunctionAuthorization(roleId, vo.SolutionId, vo.FunctionID);
					if (visible)
						break;
				}
			}
		}
		else
		{
			//子階層を表示設定
			foreach (GenerateMenuVO menuVO in vo.GenerateMenuVOs)
			{
				visible = SetMenuVisible(menuVO) || visible;
			}
		}
		vo.Visible = visible;
		return visible;
	}

}
