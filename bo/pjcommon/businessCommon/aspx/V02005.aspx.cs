using System;
using System.Collections;
using System.Collections.Generic;

using Common.IntegrationMD.Service;
using Common.Advanced.Model.Context;

using Common.Business.C01000.C01012;
using Common.Business.C99999.DbUtil;

public partial class V02005 : AbstractAsynchronousService
{
    /// <summary>
    /// SQLIDを取得します。
    /// </summary>
    /// <returns>SQLID</returns>
    protected override string GetSqlId()
    {
		return "V01005-01";
    }
}
