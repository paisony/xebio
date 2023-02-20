using Common.IntegrationMD.Service;


public partial class V02013 : AbstractAsynchronousService
{
    /// <summary>
    /// SQLIDを取得します。
    /// </summary>
    /// <returns>SQLID</returns>
    protected override string GetSqlId()
    {
		return "V01013-01";
    }
}
