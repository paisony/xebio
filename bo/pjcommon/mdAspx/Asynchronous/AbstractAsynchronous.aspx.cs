using System.Collections;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using Common.Standard.Model.Data;
using Common.Advanced.Log;
using System;
using Common.Advanced.Model.Context;
using Common.IntegrationMD.Exception;
using Common.Standard.Login;
using Common.IntegrationMD.Util;
using Common.IntegrationMD.Constant;
using System.Text;
using Common.IntegrationMD.Service;

public partial class AbstractAsynchronous : AbstractAsynchronousService
{
	/// <summary>
	/// SQLIDÇéÊìæÇµÇ‹Ç∑ÅB
	/// </summary>
	/// <returns>SQLID</returns>
	protected override string GetSqlId()
	{
		return "";
	}
}