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

using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Common.Resource;


public partial class Information_MessageEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			//ラジオボタンの初期化

			this.InitRadioList();

			//見出しDDLの初期化

			this.InitTopicDDL();

			//遷移前元画面から渡されたEditModeを取得。

			//NEW:新規作成
			//UPD:更新（UPD時は“MessageId”が渡される）

			//CFM:確認(確認画面からの遷移)
			string editMode = Convert.ToString(HttpContext.Current.Items["EditMode"]);
			ViewState["EditMode"] = editMode;

			switch (editMode)
			{
				case "NEW":
					//ラジオボタンリストコントロールの初期値をセット
					RadioListDisplay.SelectedValue = "1";

					break;
				case "UPD":

					#region 更新時のデータを画面にセット

					string messageId = Convert.ToString(HttpContext.Current.Items["MessageId"]);

					LoginUserInfoVO loginInfo = new LoginUserInfoVO();
					loginInfo.LoginId = LoginUserContext.LoginId;
					InformationService service = new InformationService(loginInfo);

					TopMessageKey pKey = new TopMessageKey(messageId);
					DataResult<DataTable> topicResult = service.GetTopMessage(pKey);

					if (topicResult.IsSuccess)
					{
						if (topicResult.ResultData.Rows.Count > 0)
						{
							DataTable res = topicResult.ResultData;

							#region VOにセットしてセッションに格納


							TopMessageVO vo = new TopMessageVO();

							vo.MessageId = Convert.ToString(res.Rows[0]["MESSAGE_ID"]);
							vo.TopicId = Convert.ToString(res.Rows[0]["TOPIC_ID"]);
							vo.Message = Convert.ToString(res.Rows[0]["MESSAGE"]);
							vo.Url = Convert.ToString(res.Rows[0]["URL"]);
							vo.DisplayFlag = (Convert.ToString(res.Rows[0]["DISPLAY_FLAG"]) == "1") ? true : false;
							vo.CreateDateTime = Convert.ToDateTime(res.Rows[0]["CREATE_DATETIME"]);
							vo.CreateUserId = Convert.ToString(res.Rows[0]["CREATE_USER_ID"]);
							vo.UpdateDateTime = Convert.ToDateTime(res.Rows[0]["UPDATE_DATETIME"]);
							vo.UpdateUserId = Convert.ToString(res.Rows[0]["UPDATE_USER_ID"]);
							vo.RowUpdateId = Convert.ToString(res.Rows[0]["ROW_UPDATE_ID"]);

							//セッションにセット
							SessionManager.SetObject(vo, "SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
								"SESSION_KEY_INFORMATION_PGID");

							#endregion

							#region  画面にセット

							//見出し属性
							TopicDDL.SelectedValue = Convert.ToString(res.Rows[0]["TOPIC_ID"]);
							//メッセージ
							MessageBox.Text = Convert.ToString(res.Rows[0]["MESSAGE"]);
							//URL
							UrlBox.Text = Convert.ToString(res.Rows[0]["URL"]);
							//表示ラジオボタン
							RadioListDisplay.SelectedValue = Convert.ToString(res.Rows[0]["DISPLAY_FLAG"]);

							#endregion
						}
						else
						{
							//排他エラー
							MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
							BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
							BusinessErrorMessage.Visible = true;

							UpdateBtn.Enabled = false;
							return;
						}

					}

					#endregion

					break;
				case "CFM":

					//セッションからVOを取得

					TopMessageVO cfmVo = (TopMessageVO)SessionManager.GetObject(
						"SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
						"SESSION_KEY_INFORMATION_PGID");
					if (cfmVo == null)
					{
						throw new ApplicationException("Information_MessageEdit:メッセージ情報の取得に失敗しました。");
					}

					#region  画面にセット

					//見出し属性
					TopicDDL.SelectedValue = cfmVo.TopicId;
					//メッセージ
					MessageBox.Text = cfmVo.Message;
					//URL
					UrlBox.Text = cfmVo.Url;
					//表示ラジオボタン
					RadioListDisplay.SelectedValue = (cfmVo.DisplayFlag == true) ? "1" : "0";

					#endregion


					break;
			}

		}
	}




	#region privateメソッド

	/// <summary>
	/// 表示状態ラジオボタンリストのItemをセット
	/// </summary>
	private void InitRadioList()
	{
		//リソース取得

		FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageEdit");

		RadioListDisplay.Items.Add(new ListItem(resource.GetString("CAPTION_VISIBLE"), "1"));
		RadioListDisplay.Items.Add(new ListItem(resource.GetString("CAPTION_HIDDEN"), "0"));
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
	}


	#endregion

	/// <summary>
	/// 作成ボタン押下

	/// </summary>
	/// <remarks>
	/// 画面の項目値をVOにセットし、このVOをセッションにセットして確認画面に遷移。

	/// </remarks>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void CreateBtn_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid) return;

		TopMessageVO vo = new TopMessageVO();

		#region  VOに画面の値をセット

		//見出し属性
		vo.TopicId = TopicDDL.SelectedValue;
		//メッセージ
		//許可したタグ文字以外は削除
		string[] admitTags = new string[] { "h1", "h2", "h3", "h4", "h5", "h6", "font", "br", "b", "i", "u", "s" };
		vo.Message = HtmlUtility.RemoveHtmlTag(MessageBox.Text, admitTags);
		//URL
		vo.Url = UrlBox.Text;
		//表示ラジオボタン
		vo.DisplayFlag = (RadioListDisplay.SelectedValue == "1") ? true : false;

		#endregion

		//セッションにセット
		SessionManager.SetObject(vo, "SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
			"SESSION_KEY_INFORMATION_PGID");

		//確認画面に遷移
		Server.Transfer("MessageConfirm.aspx");
	}


	/// <summary>
	/// 更新ボタン押下

	/// </summary>
	/// <remarks>
	/// 1.セッションにセットしたVOを取り出す。

	/// 2.VOの各項目を画面の項目値で上書する。

	/// 3.このVOをセッションにセットして確認画面に遷移。

	/// </remarks>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void UpdateBtn_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid) return;

		//セッションからVOを取得

		TopMessageVO vo = (TopMessageVO)SessionManager.GetObject("SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
			"SESSION_KEY_INFORMATION_PGID");

		#region  VOに画面の値をセット

		//見出し属性
		vo.TopicId = TopicDDL.SelectedValue;
		//メッセージ
		//許可したタグ文字以外は削除
		string[] admitTags = new string[] { "h1", "h2", "h3", "h4", "h5", "h6", "font", "br", "b", "i", "u", "s" };
		vo.Message = HtmlUtility.RemoveHtmlTag(MessageBox.Text, admitTags);
		//URL
		vo.Url = UrlBox.Text;
		//表示ラジオボタン
		vo.DisplayFlag = (RadioListDisplay.SelectedValue == "1") ? true : false;

		#endregion

		//セッションにセット
		SessionManager.SetObject(vo, "SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
			"SESSION_KEY_INFORMATION_PGID");

		//確認画面に遷移
		Server.Transfer("MessageConfirm.aspx");

	}

	/// <summary>
	/// 戻るボタン押下

	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void BackBtn_Click(object sender, EventArgs e)
	{
		//セッションからVOを削除
		SessionManager.SessionRemove(
			"SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
			"SESSION_KEY_INFORMATION_PGID");

		//遷移先で検索を行うためにEditModeを渡す。

		HttpContext.Current.Items.Add("EditMode", "SCH");
		Server.Transfer("MessageList.aspx");
	}

	/// <summary>
	/// 表題セット、コントロールの表示制御
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			#region 標題セット

			//リソース取得

			FormResource resource = ResourceManager.GetInstance().GetFormResource("MessageEdit");

			//表題
			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			TopicLbl.Text = resource.GetString("TopicLbl");
			MessageLbl.Text = resource.GetString("MessageLbl");
			UrlLbl.Text = resource.GetString("UrlLbl");
			DisplayLbl.Text = resource.GetString("DisplayLbl");
			CreateBtn.Text = resource.GetString("CreateBtn");
			UpdateBtn.Text = resource.GetString("UpdateBtn");
			BackBtn.Text = resource.GetString("BackBtn");
			//エラーメッセージ
			MessageBoxReqValid.ErrorMessage = resource.GetString("MessageBoxReqValid");
			URLValid.ErrorMessage = resource.GetString("URLValid");
			MessageBoxRegValid.ErrorMessage = resource.GetString("MessageBoxRegValid");
			//MessageBoxInvalidCharValid.Text = resource.GetString("MessageBoxInvalidCharValid");
			//URLInvalidCharValid.ErrorMessage = resource.GetString("URLInvalidCharValid");
			//項目説明
			MessageCutline.Text = resource.GetString("MessageCutline");
			UrlCutline.Text = resource.GetString("UrlCutline");
			#endregion

			#region コントロールの表示制御
			switch (Convert.ToString(ViewState["EditMode"]))
			{
				case "NEW":
					UpdateBtn.Visible = false;
					break;
				case "UPD":
					CreateBtn.Visible = false;

					break;
				case "CFM":
					/* CFM時は確認画面からの遷移。

					 * セッションからVOを取得、MessageIdが空なら

					 * 新規登録として画面を初期化。

					 * MessageIdが入力されていたら更新画面として初期化。

					 */

					//セッションからVOを取得

					TopMessageVO cfmVo = (TopMessageVO)SessionManager.GetObject(
						"SESSION_KEY_INFORMATION_TOP_MESSAGE_VO",
						"SESSION_KEY_INFORMATION_PGID");
					if (string.IsNullOrEmpty(cfmVo.MessageId))
					{
						//新規作成
						UpdateBtn.Visible = false;

					}
					else
					{
						//更新時

						CreateBtn.Visible = false;
					}

					break;
				default:
					break;
			}

			#endregion
		}
	}

}
