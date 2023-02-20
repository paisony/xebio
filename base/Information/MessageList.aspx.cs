// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

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
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;



/// <summary>
/// Information_MessageListのコードビハインドです。
/// </summary>
public partial class Information_MessageList : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			//ラジオボタンの初期化

			this.InitRadioList();

			//見出しDDLの初期化
			this.InitTopicDDL();

			//遷移元画面からEditModeを取得
			string editMode = Convert.ToString(HttpContext.Current.Items["EditMode"]);
			ViewState["EditMode"] = editMode;
			switch (editMode)
			{
				case "SCH":
					//入力，入力確認，削除確認画面からの遷移

					#region 再検索して検索結果をセット

					//セッションから検索条件取得

					QueryObject query = (QueryObject)SessionManager.GetObject(
						"SESSION_KEY_INFORMATION_TOP_MESSAGE_QUERY",
						"SESSION_KEY_INFORMATION_PGID");

					if (query == null)
					{
						//QueryObjectが存在しない場合は検索ボタンを押さずに
						//新規作成ボタンを押したとみなして「メニューからの遷移」と
						//同じ初期化を行う。

						//表示状態ラジオボタンの値をセット：全て
						RadioListDisplay.SelectedValue = "2";

						break;
					}

					//セッションからページャーの現在番号を取得

					int currentPageIndex = (int)SessionManager.GetObject(
						"SESSION_KEY_INFORMATION_TOP_MESSAGE_PAGE_INDEX",
						"SESSION_KEY_INFORMATION_PGID");

					LoginUserInfoVO infoVO = new LoginUserInfoVO();
					infoVO.LoginId = LoginUserContext.LoginId;

					InformationService service = new InformationService(infoVO);
					//検索結果件数取得

					DataResult<int> res = service.FindCountTopMessage(query);
					//検索結果件数取得
					int a = 0;
					if (res.ResultData % Pager.PageSize != 0)
					{
						a = 1;
					}
					int b = res.ResultData / Pager.PageSize + a - 1;
					if (b < 0)
						b = 0;
					if (currentPageIndex > b)
					{
						currentPageIndex = b;
					}

					query.StartRow = Pager.PageSize * currentPageIndex;
					query.MaxRowCount = Pager.PageSize;


					DataResult<DataTable> res1 = service.FindTopMessage(query);

					//GridViewにバインド

					MessageList.DataSource = res1.ResultData;

					//リソース取得

					FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageList");

					//DISPLAY_FLAGを表示・非表示に変換
					for (int i = 0; i < res1.ResultData.Rows.Count; i++)
					{
						#region 表示／非表示列


						string flg = (string)res1.ResultData.Rows[i]["DISPLAY_FLAG"].ToString();

						if (flg.Equals("1"))
						{
							res1.ResultData.Rows[i]["DISPLAY_FLAG"] = resource.GetString("CAPTION_VISIBLE");
						}
						else
						{
							res1.ResultData.Rows[i]["DISPLAY_FLAG"] = resource.GetString("CAPTION_HIDDEN");
						}
						#endregion
					}
					MessageList.DataBind();

					//検索結果全件数
					Pager.VirtualItemCount = res.ResultData;
					//現在のページ設定

					Pager.CurrentPageIndex = currentPageIndex;

					#endregion

					break;
				default:
					//メニューからの遷移（EditModeが存在しない場合）

					break;
			}

		}
	}

	/// <summary>
	/// ページャー押下時
	/// </summary>
	/// <param name="source"></param>
	/// <param name="e"></param>
	protected void Pager_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
	{
		//セッションから検索条件取得

		QueryObject query = (QueryObject)SessionManager.GetObject(
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_QUERY",
			"SESSION_KEY_INFORMATION_PGID");

		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;

		InformationService service = new InformationService(infoVO);
		//検索結果件数取得

		DataResult<int> res = service.FindCountTopMessage(query);

		//ページデータ取得

		query.StartRow = Pager.PageSize * e.NewPageIndex;
		query.MaxRowCount = Pager.PageSize;

		DataResult<DataTable> res1 = service.FindTopMessage(query);

		//GridViewにバインド

		MessageList.DataSource = res1.ResultData;

		//リソース取得

		FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageList");

		//DISPLAY_FLAGを表示・非表示に変換
		for (int i = 0; i < res1.ResultData.Rows.Count; i++)
		{
			#region 表示／非表示列


			string flg = (string)res1.ResultData.Rows[i]["DISPLAY_FLAG"].ToString();

			if (flg.Equals("1"))
			{
				res1.ResultData.Rows[i]["DISPLAY_FLAG"] = resource.GetString("CAPTION_VISIBLE");
			}
			else
			{
				res1.ResultData.Rows[i]["DISPLAY_FLAG"] = resource.GetString("CAPTION_HIDDEN");
			}

			#endregion

		}
		MessageList.DataBind();

		//検索結果全件数
		Pager.VirtualItemCount = res.ResultData;
		//現在のページ設定

		Pager.CurrentPageIndex = e.NewPageIndex;

		//現在のページ番号をセッションに保存

		SessionManager.SetObject(e.NewPageIndex,
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_PAGE_INDEX",
			"SESSION_KEY_INFORMATION_PGID");

		//検索条件をセッションに保存

		SessionManager.SetObject(query,
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_QUERY",
			"SESSION_KEY_INFORMATION_PGID");

	}

	#region privateメソッド

	/// <summary>
	/// 表示状態ラジオボタンリストのItemをセット
	/// </summary>
	private void InitRadioList()
	{
		//リソース取得

		FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageList");
		//全て
		RadioListDisplay.Items.Add(new ListItem(resource.GetString("CAPTION_RADIO_DISPLAY1"), "2"));
		//表示
		RadioListDisplay.Items.Add(new ListItem(resource.GetString("CAPTION_RADIO_DISPLAY2"), "1"));
		//非表示
		RadioListDisplay.Items.Add(new ListItem(resource.GetString("CAPTION_RADIO_DISPLAY3"), "0"));

		//表示状態ラジオボタンの値をセット：全て
		RadioListDisplay.SelectedValue = "2";
	}

	/// <summary>
	/// 見出しドロップダウンリストの初期化
	/// </summary>
	/// <exception cref="ApplicationException">見出しの取得に失敗した時</exception>
	private void InitTopicDDL()
	{
		LoginUserInfoVO loginInfo = new LoginUserInfoVO();
		loginInfo.LoginId = LoginUserContext.LoginId;
		InformationService service = new InformationService(loginInfo);
		DataResult<DataTable> topicResult = service.GetAllTopTopic(false);

		if (topicResult.IsSuccess)
		{
			DataTable dt = topicResult.ResultData;
			TopicDDL.DataSource = dt;
			TopicDDL.DataTextField = "TOPIC";
			TopicDDL.DataValueField = "TOPIC_ID";
			TopicDDL.DataBind();
		}
		else
		{
			throw new ApplicationException("Information_MessageList:見出しリストの取得に失敗しました。" + topicResult.ToString());
		}

		TopicDDL.SelectedIndex = 0;
	}


	/// <summary>
	/// 日付フォーマットをチェック。
	/// </summary>
	/// <remarks>
	/// 引数の文字列が日時として認識可能かをチェックします。
	/// 以下の検証を行います。
	/// 1.桁数チェック
	/// 　フォーマット「YYYY/MM/DD」以外の日付が入力された場合はエラー。
	/// 2.日時としての整合性チェック
	/// 　存在しない日付（2月30日，26:50等）のチェック
	/// 3.SQLServerのDateTime型で表現可能かチェック
	/// </remarks>
	/// <param name="dateTimeString">日付フォーマットチェックを行いたい年月日または日付が格納されている文字列</param>
	/// <returns>日付として認識された場合はtrue、日付として認識できなかった場合はfalseを返します。</returns>
	private bool DateTimeFormatCheck(string dateTimeString)
	{
		// 1
		Regex dateRegex = new System.Text.RegularExpressions.Regex(@"\d{4}/\d{2}/\d{2}");
		if (!dateRegex.IsMatch(dateTimeString)) return false;


		// 2
		System.Globalization.DateTimeFormatInfo dateFormat = new System.Globalization.CultureInfo("ja-JP").DateTimeFormat;
		DateTime dt;
		try
		{
			dt = Convert.ToDateTime(dateTimeString, dateFormat);
		}
		catch (Exception)
		{
			return false;
		}


		#region 3.テキストボックスに入力された日付がSQLServerのDateTime型で表現可能かチェックする

		DateTime sqlDateTimeMin = SqlDateTime.MinValue.Value;

		//日付の取得

		DateTime targetDT = Convert.ToDateTime(dateTimeString, dateFormat);
		int compResult = targetDT.CompareTo(sqlDateTimeMin);
		if (compResult < 0) return false;

		#endregion

		return true;

	}


	#endregion

	/// <summary>
	/// 検索ボタン押下
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void SearchButton_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid) return;

		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		InformationService service = new InformationService(infoVO);
		QueryObject query = new QueryObject();

		#region 検索条件をセット

		//見出し

		query.AddFinder(Criteria.Equal("TOPIC_ID", null, null, TopicDDL.SelectedValue));


		#region 作成日

		/* 作成日の検索条件下記の条件別にセットする。
         * 1.開始日，終了日に日付が入力されている場合
         * 2.開始日が未入力，終了日が入力されている場合
         * 3.開始日が入力されていて終了日が未入力の場合
         * （開始日，終了日共に未入力の場合はクエリに検索条件をセットしない）
         */



		if (!string.IsNullOrEmpty(FromDateBox.Text) && !string.IsNullOrEmpty(ToDateBox.Text))
		{
			//1.開始日，終了日に日付が入力されている場合
			System.Globalization.DateTimeFormatInfo dateFormat = new System.Globalization.CultureInfo("ja-JP").DateTimeFormat;
			DateTime fromDT = Convert.ToDateTime(FromDateBox.Text, dateFormat);
			DateTime toDT = Convert.ToDateTime(ToDateBox.Text + " 23:59:59", dateFormat);
			query.AddFinder(Criteria.Between("CREATE_DATETIME", null, fromDT, toDT));
		}
		else if (string.IsNullOrEmpty(FromDateBox.Text) && !string.IsNullOrEmpty(ToDateBox.Text))
		{
			//2.開始日が未入力，終了日が入力されている場合            
			System.Globalization.DateTimeFormatInfo dateFormat = new System.Globalization.CultureInfo("ja-JP").DateTimeFormat;
			DateTime toDT = Convert.ToDateTime(ToDateBox.Text + " 23:59:59", dateFormat);
			//開始日にSqlDateTime.MinValue.Valueをセット
			query.AddFinder(Criteria.Between("CREATE_DATETIME", null, SqlDateTime.MinValue.Value, toDT));
		}
		else if (!string.IsNullOrEmpty(FromDateBox.Text) && string.IsNullOrEmpty(ToDateBox.Text))
		{
			//3.開始日が入力されていて終了日が未入力の場合
			System.Globalization.DateTimeFormatInfo dateFormat = new System.Globalization.CultureInfo("ja-JP").DateTimeFormat;
			DateTime fromDT = Convert.ToDateTime(FromDateBox.Text, dateFormat);
			//終了日にSqlDateTime.MaxValue.Valueをセット
			query.AddFinder(Criteria.Between("CREATE_DATETIME", null, fromDT, SqlDateTime.MaxValue.Value));
		}

		#endregion

		//表示状態が全て("2")なら検索条件に加えない。

		if (RadioListDisplay.SelectedValue != "2")
		{
			query.AddFinder(Criteria.Equal("DISPLAY_FLAG", null, null, RadioListDisplay.SelectedValue));
		}

		//ソート条件（作成日の降順）を追加
		SortKey sortKey = new SortKey();
		sortKey.ColumnName = "CREATE_DATETIME";
		sortKey.IsDesc = true;
		query.AddSortKey(sortKey);

		#endregion

		//ページャの初期化

		query.StartRow = 0;
		query.MaxRowCount = Pager.PageSize;


		//検索結果件数取得

		DataResult<int> res = service.FindCountTopMessage(query);
		//データ取得

		DataResult<DataTable> res2 = service.FindTopMessage(query);
		//エラー処理

		if (!res2.IsSuccess)
		{
			throw new ApplicationException("Information_MessageList:メッセージ検索に失敗しました。");
		}


		//DISPLAY_FLAGを表示・非表示に変換
		for (int i = 0; i < res2.ResultData.Rows.Count; i++)
		{
			#region 表示／非表示列


			//リソース取得

			FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageList");

			string flg = (string)res2.ResultData.Rows[i]["DISPLAY_FLAG"].ToString();

			if (flg.Equals("1"))
			{
				res2.ResultData.Rows[i]["DISPLAY_FLAG"] = resource.GetString("CAPTION_VISIBLE");
			}
			else
			{
				res2.ResultData.Rows[i]["DISPLAY_FLAG"] = resource.GetString("CAPTION_HIDDEN");
			}

			#endregion
		}

		MessageList.DataSource = res2.ResultData;
		MessageList.DataBind();

		//検索結果全件数
		Pager.VirtualItemCount = res.ResultData;

		//現在のページ番号をセッションに保存

		Pager.CurrentPageIndex = 0;
		SessionManager.SetObject(0,
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_PAGE_INDEX",
			"SESSION_KEY_INFORMATION_PGID");

		//検索条件セッション保存

		SessionManager.SetObject(query,
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_QUERY",
			"SESSION_KEY_INFORMATION_PGID");

	}

	/// <summary>
	/// 新規作成ボタン押下
	/// </summary>
	/// <remarks>メッセージ入力画面に遷移</remarks>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void CreateBtn_Click(object sender, EventArgs e)
	{
		//現在のページ番号をセッションに保存

		SessionManager.SetObject(Pager.CurrentPageIndex,
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_PAGE_INDEX",
			"SESSION_KEY_INFORMATION_PGID");

		HttpContext.Current.Items.Add("EditMode", "NEW");
		Server.Transfer("MessageEdit.aspx");
	}

	/// <summary>
	/// 表題、JavaScriptイベントをセット
	/// </summary>
	/// <remarks>
	/// 注）GridViewの表題設定は未実装
	/// </remarks>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			#region 1.標題セット

			//リソース取得

			FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageList");

			//標題をセットする
			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			CreateBtn.Text = resource.GetString("CreateBtn");
			PreviewBtn.Value = resource.GetString("PreviewBtn");
			TopicLbl.Text = resource.GetString("TopicLbl");
			CreateDateLbl.Text = resource.GetString("CreateDateLbl");
			DisplayLbl.Text = resource.GetString("DisplayLbl");
			FromLbl.Text = resource.GetString("FromLbl");
			ToLbl.Text = resource.GetString("ToLbl");
			SearchButton.Text = resource.GetString("SearchButton");
			BackBtn.Text = resource.GetString("BackBtn");
			NoExistTopicLbl.Text = resource.GetString("NoExistTopicLbl");
			DateCutline.Text = resource.GetString("DateCutline");
			//列ヘッダー名

			//MessageList.Columns[0].HeaderText = resource.GetString("CAPTION_LIST_MESSAGE");
			//MessageList.Columns[1].HeaderText = resource.GetString("CAPTION_LIST_DISPLAY");
			//MessageList.Columns[2].HeaderText = resource.GetString("CAPTION_LIST_CREATE_DATE");
			//MessageList.Columns[3].HeaderText = resource.GetString("CAPTION_LIST_EDIT_BTN");
			//MessageList.Columns[4].HeaderText = resource.GetString("CAPTION_LIST_DEL_BTN");

			//ボタンフィールド中のボタンのテキスト表示
			//((ButtonField)MessageList.Columns[3]).Text = resource.GetString("CAPTION_LIST_EDIT_BTN");
			//((ButtonField)MessageList.Columns[4]).Text = resource.GetString("CAPTION_LIST_DEL_BTN");

			#endregion

			//2.JavaScriptイベントのセット
			//日付テキストボックスの値にがフォーカスされたらテキストの内容を選択状態にする
			FromDateBox.Attributes.Add("onfocus", "this.select()");
			ToDateBox.Attributes.Add("onfocus", "this.select()");

			#region 見出しDDLの見出し件数が0件の場合

			if (TopicDDL.Items.Count == 0)
			{
				//見出しの作成を促すメッセージを表示
				//ボタン類を押下不能にする
				NoExistTopicLbl.Visible = true;
				PreviewBtn.Disabled = true;
				SearchButton.Enabled = false;
				CreateBtn.Enabled = false;
			}
			else
			{
				//見出しの作成を促すメッセージを不表示
				NoExistTopicLbl.Visible = false;
			}

			#endregion

		}

	}

	/// <summary>
	/// DataViewのボタン押下時
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void MessageList_RowCommand(object sender, GridViewCommandEventArgs e)
	{

		//現在のページ番号をセッションに保存

		SessionManager.SetObject(Pager.CurrentPageIndex,
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_PAGE_INDEX",
			"SESSION_KEY_INFORMATION_PGID");


		//押された行の行番号を取得

		int index = Convert.ToInt32(e.CommandArgument);

		string messageId = ((Label)MessageList.Rows[index].FindControl("MessageID")).Text;
		HttpContext.Current.Items.Add("MessageId", messageId);

		if (e.CommandName == "EditRow")
		{
			//編集時
			HttpContext.Current.Items.Add("EditMode", "UPD");
			Server.Transfer("MessageEdit.aspx");

		}
		else if (e.CommandName == "DeleteRow")
		{
			//削除時

			Server.Transfer("MessageDelConfirm.aspx");
		}

	}
	protected void TopicDDL_SelectedIndexChanged(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// 日付のフォーマットチェック
	/// </summary>
	/// <remarks>
	/// 下記の日付のチェックを行います。

	/// 1.日付の入力フォーマットチェック
	/// 2.開始日と終了日の日付前後チェック
	/// </remarks>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void DateValid_ServerValidate(object source, ServerValidateEventArgs args)
	{
		#region 1.日付の入力フォーマットチェック

		//リソース取得

		FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageList");

		//メッセージ「日付のフォーマットが不正です。YYYY/MM/DD形式で入力してください。」をセット
		DateValid.ErrorMessage = resource.GetString("CAPTION_ERROR_DATE_FORMAT");

		if (!string.IsNullOrEmpty(FromDateBox.Text))
		{
			if (!this.DateTimeFormatCheck(FromDateBox.Text))
			{
				args.IsValid = false;
				return;
			}
		}
		if (!string.IsNullOrEmpty(ToDateBox.Text))
		{
			if (!this.DateTimeFormatCheck(ToDateBox.Text))
			{
				args.IsValid = false;
				return;
			}
		}

		#endregion

		#region 開始日と終了日の日付前後チェック

		//メッセージ「開始日は終了日よりも過去の日付を入力してください。」をセット
		DateValid.ErrorMessage = resource.GetString("CAPTION_ERROR_DATE_CONSISTENCY");

		if (!string.IsNullOrEmpty(FromDateBox.Text) && !string.IsNullOrEmpty(ToDateBox.Text))
		{
			System.Globalization.DateTimeFormatInfo dateFormat = new System.Globalization.CultureInfo("ja-JP").DateTimeFormat;
			DateTime fromDT = Convert.ToDateTime(FromDateBox.Text, dateFormat);
			DateTime toDT = Convert.ToDateTime(ToDateBox.Text, dateFormat);
			int result = toDT.CompareTo(fromDT);
			if (result < 0)
			{
				args.IsValid = false;
				return;
			}
		}

		#endregion

		//検証成功
		args.IsValid = true;
	}

	/// <summary>
	/// 戻るボタン押下
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void BackBtn_Click(object sender, EventArgs e)
	{
		#region セッションから機能固有の情報を削除

		//現在のページ番号をセッションに保存

		SessionManager.SessionRemove(
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_PAGE_INDEX",
			"SESSION_KEY_INFORMATION_PGID");

		//検索条件をセッションに保存

		SessionManager.SessionRemove(
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_QUERY",
			"SESSION_KEY_INFORMATION_PGID");

		#endregion

		Server.Transfer("InformationMenu.aspx");
	}
	protected void PreviewBtn_ServerClick(object sender, EventArgs e)
	{

	}
}
