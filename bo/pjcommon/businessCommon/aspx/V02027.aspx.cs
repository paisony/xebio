using System;
using System.Collections;
using System.Collections.Generic;
using Common.Business.C99999.DbUtil;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01029;

public partial class V02027 : AbstractAsynchronousServiceExtents
{
	/// <summary>
	/// 個別にDB情報を指定する場合、DBContextを設定
	/// </summary>
	/// <returns></returns>
	protected override IList<Hashtable> GetDataList(IDBContext dbcontext, Dictionary<string, object> condition)
	{

		SearchTantoTenpoVO searchConditionVO = new SearchTantoTenpoVO(
			(string)condition["HANBAIIN_CD"]					// 担当者コード
		);

		return SearchTantoTenpo.SearchTanTen(searchConditionVO, dbcontext);
	}
}
