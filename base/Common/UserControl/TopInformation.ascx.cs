// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information;

using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using System.Text;


public partial class TopInformation : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LoginUserInfoVO loginInfo = new LoginUserInfoVO();
			loginInfo.LoginId = LoginUserContext.LoginId;
			InformationService service = new InformationService(loginInfo);
			//見出しのDISPLAY_FLAGが1（表示する）のデータを全件取得
			DataResult<DataTable> topicResult = service.GetAllTopTopic(true);

			InfoList.DataSource = this.SetHtmlEncode(topicResult.ResultData);
			InfoList.DataBind();
		}
	}



	protected void InfoList_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
	{

		if (e.Item.ItemType == ListItemType.Item
			|| e.Item.ItemType == ListItemType.AlternatingItem)
		{

			//見出し情報を取得
			string topicID = e.Item.Cells[0].Text;
            //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
			//string dateFormat = e.Item.Cells[1].Text;
            string dateFormat = "yyyy.MM.dd";
            //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
			//DateFormatが空なら仮にdに置き換える。

			if (string.IsNullOrEmpty(dateFormat.Replace("&nbsp;", "")))
			{
				dateFormat = "d";
			}
			int newdisplaypriod = Convert.ToInt32(e.Item.Cells[2].Text);
			int displayNumber = Convert.ToInt32(e.Item.Cells[3].Text);
			string datedisplayFlg = e.Item.Cells[4].Text;
			string topic = e.Item.Cells[5].Text;
			int displayPriod = Convert.ToInt32(e.Item.Cells[6].Text);
			//表示期間が0ならメッセージ検索せずにメソッドを終了する
			#region 検索条件をセット

			QueryObject query = new QueryObject();

			//見出しID
			query.AddFinder(Criteria.Equal("TOPIC_ID", null, null, topicID));
			//表示フラグ:1(表示)
			query.AddFinder(Criteria.Equal("DISPLAY_FLAG", null, null, "1"));
			//メッセージ表示限界日付（(本日+1日)から見出しの表示期間を引いた日付）
			DateTime dispLimitDate = DateTime.Today.AddDays(1d);
			TimeSpan displaySpan = new TimeSpan((int)displayPriod, 0, 0, 0);
			dispLimitDate = dispLimitDate - displaySpan;
			//メッセージ表示限界日付
			query.AddFinder(Criteria.GraterOrEqual("CREATE_DATETIME", null, null, dispLimitDate.ToString()));
			//検索結果の最大取得件数
			query.MaxRowCount = displayNumber;

			//作成日の降順でソートするソートキー
			SortKey sortKey = new SortKey();
			sortKey.ColumnName = "CREATE_DATETIME";
			sortKey.IsDesc = true;
			sortKey.TableName = "BS_TOP_MESSAGE";

			query.AddSortKey(sortKey);

			#endregion

			#region メッセージを検索

			LoginUserInfoVO loginInfo = new LoginUserInfoVO();
			loginInfo.LoginId = LoginUserContext.LoginId;
			InformationService service = new InformationService(loginInfo);
			DataResult<DataTable> messageResult = service.FindTopMessage(query);

			DataTable newMessageTable = messageResult.ResultData;

            //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
            DataResult<DataTable> topicResult = service.GetAllTopTopic(true);
            DataTable newTopicTable = topicResult.ResultData;
            //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End

			#endregion

			#region メッセージのフォーマット変換

			newMessageTable.Columns.Add(new DataColumn("MESSAGEDATE", typeof(string)));

			//作成日時をFormatを変換。　column["MESSAGE"]中に表示メッセージ(日付、Newマーク、メッセージ)を追加
			for (int i = 0; i < newMessageTable.Rows.Count; i++)
			{
				//作成日時をFormatを変換
				DateTime createTime = Convert.ToDateTime(newMessageTable.Rows[i]["CREATE_DATETIME"]);

				//日付の表示
				if (datedisplayFlg.Equals("1"))
				{
					//日付フォーマット変換
					newMessageTable.Rows[i]["MESSAGEDATE"] = createTime.ToString(dateFormat) + "&nbsp;";
				}

				StringBuilder message = new StringBuilder();

				//"New"表示期間チェック
				if (this.CeckNewLabelVisible(newdisplaypriod, createTime))
				{
					message.Append("<img src=\"Images\\new.gif\" border=\"0\">");
				}
				//URLのリンク表示
				if (!newMessageTable.Rows[i].IsNull("URL") && !newMessageTable.Rows[i]["URL"].ToString().Trim().Equals(""))
				{
					string URL = (string)newMessageTable.Rows[i]["URL"];
					message.Append("<A href=\"" + URL + "\" target=\"_blank\">");
				}
                //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
                if (!newTopicTable.Rows[0].IsNull("TOPIC") && !newTopicTable.Rows[0]["TOPIC"].ToString().Trim().Equals(""))
                {
                    string topic2 = (string)newTopicTable.Rows[0]["TOPIC"];
                    message.Append("<span class=\"txt-bold\">" + topic + "</span><br>");
                }
                //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
				//メッセージの追加
				message.Append(newMessageTable.Rows[i]["MESSAGE"].ToString());

				//</A>タグの表示
				if (!newMessageTable.Rows[i].IsNull("URL") && !newMessageTable.Rows[i]["URL"].ToString().Trim().Equals(""))
				{
					message.Append("</A>");
				}

				//表示メッセージをRowに詰める
				newMessageTable.Rows[i]["MESSAGE"] = message.ToString();

			}

			DataGrid dg = (DataGrid)e.Item.FindControl("MessageGrid");

			//日付の表示
			if (datedisplayFlg.Equals("1"))
			{
				dg.Columns[1].Visible = true;
			}

			#endregion

			dg.ItemDataBound +=
				new DataGridItemEventHandler(this.MessageGrid_ItemDataBound);


			SessionManager.SetObject(topic, "topic", "SESSION_KEY_INFORMATION_PGID");
			dg.DataSource = newMessageTable;
			dg.DataBind();
		}
	}

	#region privateメソッド

	/// <summary>
	/// 見出し名をHTMLエンコーディングする
	/// </summary>
	/// <param name="topicDT">見出しの検索結果が格納されたDataTable</param>
	/// <returns>見出し名がHTMLエンコードされたDataTable</returns>
	private DataTable SetHtmlEncode(DataTable topicDT)
	{
		for (int i = 0; i < topicDT.Rows.Count; i++)
		{
			topicDT.Rows[i]["TOPIC"] = HttpUtility.HtmlEncode(Convert.ToString(topicDT.Rows[i]["TOPIC"]));
		}

		return topicDT;
	}

	/// <summary>
	/// DridGridのHeadTextの表示形式設定
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void MessageGrid_ItemDataBound(Object sender, DataGridItemEventArgs e)
	{
		//ヘッダーに見出しをセット
		if (e.Item.ItemType == ListItemType.Header)
		{
			string topic = (string)SessionManager.GetObject("topic", "SESSION_KEY_INFORMATION_PGID");
			e.Item.Cells[1].ColumnSpan = 2;
			e.Item.Cells[1].Width = Unit.Percentage(100d);
            //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
			//e.Item.Cells[1].Text = "<table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\"><tr><td width=\"20\" height=\"20\"><IMG height=\"20\" src=\"Images/sima_top2.gif\" width=\"20\"></td><td background=\"Images/sima_bk.gif\" width=\"100%\"><B><FONT color=\"#333366\" size=\"2\">&nbsp;&nbsp;" + topic + "</FONT></B></td></tr></table>";
            e.Item.Cells[1].Text = "<div class=\"h2-box\"><h2 class=\"login-h2\">" + topic + "</h2></div>";
            //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
		}
	}

	/// <summary>
	/// 「NEW」表示期間の表示チェック
	/// </summary>
	/// <remarks>
	/// 「NEW」表示有効日と本日日付を比較して「NEW」表示有効日が
	/// 未来か同日の場合はtrueを返します。
	/// </remarks>
	/// <param name="newDisplayPriod">「NEW」表示期間</param>
	/// <param name="createDateTime">メッセージの作成日付</param>
	/// <returns>true:「NEW」ラベルを表示する。 false:表示しない</returns>
	private bool CeckNewLabelVisible(int newDisplayPriod, DateTime createDateTime)
	{
		//NEW表示有効日を算出
		//作成日時の日付のみを使用する
		DateTime tmpDate = createDateTime.Date;
		DateTime validityDate = tmpDate.AddDays((double)newDisplayPriod);
		//NEW表示有効日と本日を比較して、NEW表示有効日が未来の場合はtrueを返す。
		int compResult = validityDate.CompareTo(DateTime.Today);
		if (compResult > 0)
		{
			//NEW表示有効日が本日日付よりも未来の場合
			return true;
		}
		else
		{
			//NEW表示有効日が本日かそれよりも過去の場合
			return false;
		}
	}

	/// <summary>
	/// stringオブジェクトから以下のフォーマットのDateTime型に変換する
	/// yyyyMMddHHmmss
	/// 上記のフォーマット以外であれば、DateTimeの初期値を返す
	/// </summary>
	/// <param name="param">変換対象のstringオブジェクト</param>
	/// <returns></returns>
	private DateTime StringToDateTime(string param)
	{
		if (param.Length != 14)
		{
			return new DateTime();
		}
		try
		{
			int year = Int32.Parse(param.Substring(0, 4));
			int month = Int32.Parse(param.Substring(4, 2));
			int day = Int32.Parse(param.Substring(6, 2));
			int hour = Int32.Parse(param.Substring(8, 2));
			int minutes = Int32.Parse(param.Substring(10, 2));
			int second = Int32.Parse(param.Substring(12, 2));
			DateTime t = new DateTime(year, month, day, hour, minutes, second);
			return t;
		}
		catch (ArgumentOutOfRangeException)
		{
			return new DateTime();
		}
	}





	#endregion


}
