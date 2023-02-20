using System;
using System.Collections;
using System.Collections.Generic;
using Common.Business.C99999.DbUtil;
using Common.Advanced.Model.Context;
using Common.Business.C01000.C01021;

public partial class V02017 : AbstractAsynchronousServiceExtents
{
	/// <summary>
	/// /// 個別にDB情報を指定する場合、DBContextを設定
	/// </summary>
	/// <returns></returns>
	protected override IList<Hashtable> GetDataList(IDBContext dbcontext, Dictionary<string, object> condition)
	{

		SearchSiireYoteiVO searchConditionVO = new SearchSiireYoteiVO(
			(string)condition["SIIRESAKI_CD"],					// 仕入先コード
			(string)condition["DENPYO_BARCODE"],				// 伝票バーコード
			(string)condition["TENPO_CD"]						// 店舗コード
		);

		return SearchSiireYotei.SearchDenpyoBarcode(searchConditionVO, dbcontext);
	}
}
