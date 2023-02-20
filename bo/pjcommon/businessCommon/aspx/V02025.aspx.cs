using Common.IntegrationMD.Service;


public partial class V02025 : AbstractAsynchronousService
{
    /// <summary>
    /// SQLIDを取得します。
    /// </summary>
    /// <returns>SQLID</returns>
    protected override string GetSqlId()
    {
		return "V01025-01";
    }
}
