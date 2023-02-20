using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Standard.Model.Data;
using Common.Advanced.Log;
using Common.Advanced.Model.Context;
using Common.IntegrationMD.Exception;
using System.Collections;
using System.Xml;
using Common.Advanced.Web.Util;
using System.Web.UI.HtmlControls;
using Common.Standard.Message;

public partial class pjcommon_ws3Aspx_PrintSettingDialog : System.Web.UI.Page
{
	/// <summary>
	/// ログ出力クラスです。
	/// </summary>
	protected static ILogger logger = LogManager.GetLogger();

	/// <summary>
	/// 実行するsql ID
	/// </summary>
	private const String sqlId = "AB-004-01";

	/// <summary>
	/// バインドする引数(帳票ＩＤ)
	/// プログラムＩＤを指定します。
	/// </summary>
	private const String bindName = "FORM_ID";

	/// <summary>
	/// デフォルト選択されている値
	/// </summary>
	private const String defaultValue = "PRINTER_ID";

	protected void Page_Load(object sender, EventArgs e)
	{
		String FORM_ID = Request[bindName];
		String PRINT_ID = Request[defaultValue];

		Common.Advanced.Model.Context.IDBContext context = null;

		try
		{
			//コンテキストを取得
			context = StandardDBContextFactory.CreateDbContext();

			//SQLオブジェクトを生成
			FindSqlResultTable table = CreateFindSqlResultTable(sqlId, context);
			table.BindValue(bindName, FORM_ID);

			//SQL実行
			IList<Hashtable> sqlResult = table.Execute();

			//SQL結果を取得
			foreach (Hashtable rm in sqlResult)
			{
				ListItem item = new ListItem(
						rm["PRINTER_NAME"].ToString(),
						rm["PRINTER_ID"].ToString()
				);
				item.Selected = (item.Value == PRINT_ID);
				PrinterList.Items.Add(item);
			}//rm

		}
		catch (MdCommonException ex)
		{
			logger.Error("SQLID=" + sqlId, ex);
		}
		finally
		{
			// コネクションクローズ
			if (context != null) context.CloseConnection();
		}

		// 言語情報の取得
		string lang = WebSettingsUtil.GetLangSettingFromSession(this.Page.Session);
		// ボタンの文字列の設定
		((HtmlInputButton)Page.FindControl("OkButton")).Value = MessageResourceUtil.GetString("I014", lang);
		HtmlInputButton closeBtn = ((HtmlInputButton)Page.FindControl("closeButton"));
		closeBtn.Value = MessageResourceUtil.GetString("I028", lang);
		closeBtn.Focus();
		initialValue.Value = PRINT_ID;
	}

	/// <summary>
	/// FindSqlResultTableオブジェクトを生成
	/// </summary>
	/// <param name="sqlId"></param>
	/// <returns></returns>
	protected virtual FindSqlResultTable CreateFindSqlResultTable(string sqlId, IDBContext context)
	{
		context.OpenConnection();

		return FindSqlUtil.CreateFindSqlResultTable(sqlId, context);
	}

	/// <summary>
	/// SQLバインド処理
	/// </summary>
	/// <param name="table"></param>
	/// <param name="condition"></param>
	protected virtual void SqlBind(FindSqlResultTable table, Dictionary<string, object> condition)
	{
		ICollection columnNames = condition.Keys;

		foreach (string columnName in columnNames)
		{
			table.BindValue(columnName, condition[columnName]);
		}
	}

}
