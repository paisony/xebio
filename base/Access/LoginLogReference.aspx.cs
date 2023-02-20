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
using Com.Fujitsu.SmartBase.Base.Certification;

public partial class Access_LoginLogReference : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//他のページから遷移する場合
		if (!Page.IsPostBack)
		{
			//検索条件をクリアする
			SessionManager.SessionRemoveByPgID("ResearchCondition");
			if (!string.IsNullOrEmpty(Request.Params.Get("IsInit")))
			{
				SessionManager.SessionRemoveByPgID("LoginLog");
			}
		}
	}

	protected void RenderForm(object sender, System.EventArgs e)
	{
		//他のページから遷移する場合
		if (!base.IsPostBack)
		{
			#region 標題セット
			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginLogReference");
			//標題をセットする
			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			LoginIdLbl.Text = resource.GetString("LoginIdLbl");
			LoginStatusLbl.Text = resource.GetString("LoginStatusLbl");
			LoginDateLbl.Text = resource.GetString("LoginDateLbl");
			FromLbl.Text = resource.GetString("FromLbl");
			ToLbl.Text = resource.GetString("ToLbl");
			SearchButton.Text = resource.GetString("SearchButton");
			BackBtn.Text = resource.GetString("BackBtn");
			DateCutline.Text = resource.GetString("DateCutline");

			//列ヘッダー名
			LoginLogList.Columns[0].HeaderText = resource.GetString("LoginLogList_COMPANY");
			LoginLogList.Columns[1].HeaderText = resource.GetString("LoginLogList_LOGINID");
			LoginLogList.Columns[2].HeaderText = resource.GetString("LoginLogList_NAME");
			LoginLogList.Columns[3].HeaderText = resource.GetString("LoginLogList_TYPE");
			LoginLogList.Columns[4].HeaderText = resource.GetString("LoginLogList_TIME");

			//JavaScriptイベントのセット
			//日付テキストボックスの値にがフォーカスされたらテキストの内容を選択状態にする
			FromDateBox.Attributes.Add("onfocus", "this.select()");
			ToDateBox.Attributes.Add("onfocus", "this.select()");

			//ログ種類のチェックボックス初期値のセット
			LogStatus0.Checked = true;
			LogStatus1.Checked = true;
			LogStatus2.Checked = true;
			LogStatus3.Checked = true;
			LogStatus4.Checked = true;
			LogStatus5.Checked = true;
			LogStatus6.Checked = true;
			LogStatus7.Checked = true;
			LogStatus8.Checked = true;
			LogStatus9.Checked = true;
			#endregion
		}

	}

	#region 日付の検索条件チェック
	protected void DateValid_ServerValidate(object source, ServerValidateEventArgs args)
	{
		#region 1.日付の入力フォーマットチェック
		//リソース取得
		FormResource resource = ResourceManager.GetInstance().GetFormResource("LoginLogReference");
		//メッセージ「日付のフォーマットが不正です。YYYY/MM/DD形式で入力してください。」をセット
		DateValid.ErrorMessage = resource.GetString("CAPTION_ERROR_DATE_FORMAT");
		if (!string.IsNullOrEmpty(FromDateBox.Text))
		{
			if (!this.DateTimeFormatCheck(FromDateBox.Text))
			{
				// エラーメッセージ
				DateValid.ErrorMessage = resource.GetString("FromDateInvalidCharValid");
				args.IsValid = false;
				return;
			}
		}
		if (!string.IsNullOrEmpty(ToDateBox.Text))
		{
			if (!this.DateTimeFormatCheck(ToDateBox.Text))
			{
				// エラーメッセージ
				DateValid.ErrorMessage = resource.GetString("ToDateInvalidCharValid");
				args.IsValid = false;
				return;
			}
		}
		#endregion

		#region 2.開始日と終了日の日付前後チェック
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
	#endregion

	#region 検索
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
		CertificationService service = new CertificationService();
		QueryObject query = new QueryObject();

		#region 検索条件をセット
		//ログインID
		if (!string.IsNullOrEmpty(LoginIdBox.Text))
		{
			query.AddFinder(Criteria.Equal("LOGIN_ID", null, "BS_LOGIN_LOG", LoginIdBox.Text));
		}
		//ログ種別
		int cnt = 0;
		string[] type = new string[0];
		if (LogStatus0.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "0";
			cnt++;
		}
		if (LogStatus1.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "1";
			cnt++;
		}
		if (LogStatus2.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "2";
			cnt++;
		}
		if (LogStatus3.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "3";
			cnt++;
		}
		if (LogStatus4.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "4";
			cnt++;
		}
		if (LogStatus5.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "5";
			cnt++;
		}
		if (LogStatus6.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "6";
			cnt++;
		}
		if (LogStatus7.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "7";
			cnt++;
		}
		if (LogStatus8.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "8";
			cnt++;
		}
		if (LogStatus9.Checked == true)
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "9";
			cnt++;
		}
		if (cnt > 0)
		{
			query.AddFinder(Criteria.Contain("LOG_TYPE", null, "BS_LOGIN_LOG", type));
		}
		else
		{
			type.CopyTo(type = new string[cnt + 1], 0);
			type[cnt] = "X";
			query.AddFinder(Criteria.Contain("LOG_TYPE", null, "BS_LOGIN_LOG", type));
		}
		#region アクセス日
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
			query.AddFinder(Criteria.Between("LOG_DATETIME", null, fromDT, toDT));
		}
		else if (string.IsNullOrEmpty(FromDateBox.Text) && !string.IsNullOrEmpty(ToDateBox.Text))
		{
			//2.開始日が未入力，終了日が入力されている場合            
			System.Globalization.DateTimeFormatInfo dateFormat = new System.Globalization.CultureInfo("ja-JP").DateTimeFormat;
			DateTime toDT = Convert.ToDateTime(ToDateBox.Text + " 23:59:59", dateFormat);
			//開始日にSqlDateTime.MinValue.Valueをセット
			query.AddFinder(Criteria.Between("LOG_DATETIME", null, SqlDateTime.MinValue.Value, toDT));
		}
		else if (!string.IsNullOrEmpty(FromDateBox.Text) && string.IsNullOrEmpty(ToDateBox.Text))
		{
			//3.開始日が入力されていて終了日が未入力の場合
			System.Globalization.DateTimeFormatInfo dateFormat = new System.Globalization.CultureInfo("ja-JP").DateTimeFormat;
			DateTime fromDT = Convert.ToDateTime(FromDateBox.Text, dateFormat);
			//終了日にSqlDateTime.MaxValue.Valueをセット
			query.AddFinder(Criteria.Between("LOG_DATETIME", null, fromDT, SqlDateTime.MaxValue.Value));
		}
		#endregion

		//ソート条件（作成日の降順）を追加
		SortKey sortKey = new SortKey();
		sortKey.ColumnName = "LOG_DATETIME";
		sortKey.IsDesc = true;
		query.AddSortKey(sortKey);
		#endregion

		//ページャの初期化
		query.StartRow = 0;
		query.MaxRowCount = Pager.PageSize;


		//検索結果件数取得
		DataResult<int> res = service.FindCountLoginLog(query);
		//データ取得
		DataResult<DataTable> res2 = service.FindLoginLog(query);
		//エラー処理
		if (!res2.IsSuccess)
		{
			throw new ApplicationException("ログイン履歴検索に失敗しました。");
		}
		LoginLogList.DataSource = res2.ResultData;
		LoginLogList.DataBind();
		//検索結果全件数
		Pager.VirtualItemCount = res.ResultData;
		//現在のページ番号をセッションに保存
		Pager.CurrentPageIndex = 0;
		SessionManager.SetObject(0, "PageIndex", "LoginLog");
		//検索条件セッション保存
		SessionManager.SetObject(query, "ResearchCondition", "LoginLog");

	}
	#endregion

	#region 戻る
	/// <summary>
	/// 戻るボタン押下
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void BackBtn_Click(object sender, EventArgs e)
	{
		Server.Transfer("AccessMenu.aspx");
	}
	#endregion

	#region ページ遷移
	/// <summary>
	/// ページングイベント
	/// </summary>
	/// <param name="source"></param>
	/// <param name="e"></param>
	protected void Pager_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
	{

		//セッションから検索条件取得
		QueryObject query = (QueryObject)SessionManager.GetObject("ResearchCondition", "LoginLog");
		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		CertificationService service = new CertificationService();
		//検索結果件数取得
		DataResult<int> res = service.FindCountLoginLog(query);
		//ページデータ取得
		query.StartRow = Pager.PageSize * e.NewPageIndex;
		query.MaxRowCount = Pager.PageSize;

		DataResult<DataTable> res1 = service.FindLoginLog(query);

		//GridViewにバインド
		LoginLogList.DataSource = res1.ResultData;
		LoginLogList.DataBind();
		//検索結果全件数
		Pager.VirtualItemCount = res.ResultData;
		//現在のページ設定
		Pager.CurrentPageIndex = e.NewPageIndex;
		SessionManager.SetObject(e.NewPageIndex, "PageIndex", "LoginLog");
		//検索条件セッション保存
		SessionManager.SetObject(query, "ResearchCondition", "LoginLog");
	}
	#endregion

	#region 日付フォーマットをチェック部品
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

	#region 会社名、アクセス種別表示
	protected void LoginLogList_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string companyId = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "COMPANY_ID"));
			Label companyLbl = (Label)e.Row.FindControl("CompanyNAME");
			companyLbl.Text = CompanyMst.GetCompanyName(companyId);

			string logType = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "LOG_TYPE"));
			Label AccessTypeLbl = (Label)e.Row.FindControl("AccessTYPE");
			if (logType == "0")
			{
				AccessTypeLbl.Text = "ログイン";
			}
			else if (logType == "1")
			{
				AccessTypeLbl.Text = "ログアウト";
			}
			else if (logType == "2")
			{
				AccessTypeLbl.Text = "強制ログイン";
			}
			else if (logType == "3")
			{
				AccessTypeLbl.Text = "強制ログアウト";
			}
			else if (logType == "4")
			{
				AccessTypeLbl.Text = "セッションタイムアウト";
			}
			else if (logType == "8")
			{
				AccessTypeLbl.Text = "機能の実行";
			}
			else if (logType == "9")
			{
				AccessTypeLbl.Text = "機能の終了";
			}
			Label FunctionID = (Label)e.Row.FindControl("FunctionID");
			Label FunctionName = (Label)e.Row.FindControl("FunctionName");
		}
	}
	#endregion

}
