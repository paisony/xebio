using System;
using System.Collections;
using System.Collections.Generic;
using Common.Business.C01000.C01012;
using Common.Business.C99999.DbUtil;
using Common.Advanced.Model.Context;

public partial class V02003 : AbstractAsynchronousServiceExtents
{
	/// <summary>
	/// 個別にDB情報を指定する場合、DBContextを設定
	/// </summary>
	/// <returns></returns>
	protected override IList<Hashtable> GetDataList(IDBContext dbcontext, Dictionary<string, object> condition)
	{

		SearchHachuVO searchConditionVO = new SearchHachuVO(
			(string) condition["SCAN_CD"],						// スキャンコード
			(string) condition["TENPO_CD"],						// 店舗コード
			Convert.ToInt32((string) condition["PLUFLG"]),		// 店別単価マスタ 検索フラグ 0:検索しない 1:検索する
			Convert.ToInt32((string) condition["PRICEFLG"]),	// 売変 検索フラグ 0:検索しない 1:検索する
			Convert.ToInt32((string) condition["ZAIKOFLG"]),	// 店在庫 検索フラグ 0:検索しない 1:検索する
			Convert.ToInt32((string) condition["NYUKAFLG"]),	// 入荷予定数 検索フラグ 0:検索しない 1:検索する
			Convert.ToInt32((string) condition["URIFLG"]),		// 売上実績数 検索フラグ 0:検索しない 1:検索する
			Convert.ToInt32((string) condition["HOJUFLG"]),		// 依頼集計数(補充) 検索フラグ 0:検索しない 1:検索する
			Convert.ToInt32((string) condition["TANPINFLG"]),	// 依頼集計数(単品) 検索フラグ 0:検索しない 1:検索する
			Convert.ToInt32((string) condition["SIJIFLG"]),		// 指示検索 検索フラグ 0:検索しない 1:出荷指示、2:返品指示
			(string) condition["SIJI_NO"],						// 指示NO（移動出荷マニュアル、返品マニュアル用）
			(string) condition["SYUKAKAISYA_CD"],				// 出荷会社コード（移動出荷マニュアル)
			(string) condition["NYUKAKAISYA_CD"],				// 入荷会社コード（移動出荷マニュアル)
			(string) condition["SYUKATENPO_CD"]					// 指示店舗コード（移動出荷マニュアル、返品マニュアル用）
		);

		return SearchHachu.SearchXebioCd(searchConditionVO, dbcontext);
	}
}
