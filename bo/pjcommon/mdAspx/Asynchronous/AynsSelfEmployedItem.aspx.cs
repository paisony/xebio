using Common.IntegrationMD.Service;
public partial class AynsSelfEmployedItem : AbstractAsynchronousService
{
    protected override string GetSqlId()
    {
		return "sql_id";
    }
}
