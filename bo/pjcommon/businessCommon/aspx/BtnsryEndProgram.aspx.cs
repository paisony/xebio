using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Common.Advanced.Model.Context;
using Common.Standard.Model.Data;
using Common.Standard.Exception;
using Common.Advanced.Web.Context;
using Common.IntegrationMD.Util;
using Common.Advanced.Model.Data;
using Common.IntegrationMD.Constant;
using Common.Standard.Session;


public partial class BtnsryEndProgram : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string programId = Request["programId"] as string;
		//DBコンテキストを取得します。
		IDBContext dbcontext = StandardDBContextFactory.CreateDbContext();
		try
		{
			//コネクション開始
			if (dbcontext != null)
			{
				dbcontext.OpenConnection();
			}
			//オペレーションログ（終了情報ログ）
			if (HttpContext.Current.Session[MdSystemConstant.MD_FUNCTION_ID + programId] != null)
			{
				programId = (string)HttpContext.Current.Session[MdSystemConstant.MD_FUNCTION_ID + programId];
			}
			LoginLogUtil.InsertLoginLogExec(dbcontext, programId, false);
			//機能排他ログ削除
			if (!string.IsNullOrEmpty(programId))
			{
				ExclusionUtil.DeleteExclusionLog(dbcontext, programId, null);
			}
			else
			{
				ExclusionUtil.DeleteExclusionLog(dbcontext, null, HttpContext.Current.Request.UserHostAddress);
			}
		}
		catch (DBException)
		{
		}
		catch (System.Exception)
		{
		}
		finally
		{
			try
			{
				if (dbcontext != null)
				{
					//コネクションクローズ
					dbcontext.CloseConnection();
				}
			}
			catch (System.Exception)
			{
			}
		}
	}
}
