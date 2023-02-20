using Common.IntegrationMD.Service;


public partial class V02011 : AbstractAsynchronousService
{
    /// <summary>
    /// SQLIDを取得します。
    /// </summary>
    /// <returns>SQLID</returns>
    protected override string GetSqlId()
    {
		return "V01011-01";
    }
}
