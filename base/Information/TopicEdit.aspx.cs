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

using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Text.RegularExpressions;

/// <summary>
/// Information_TopicEditのコードビハインドです。
/// </summary>
public partial class Information_TopicEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			#region ラジオボタンの初期化

			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("TopicEdit");


			//日付フォーマットラジオボタンリストのItemをセット
			RadioListDateFormat.Items.Add(new ListItem("YYYY.MM.DD", "yyyy.MM.dd"));
			RadioListDateFormat.Items.Add(new ListItem("YYYY/MM/DD", "yyyy/MM/dd"));
			RadioListDateFormat.Items.Add(new ListItem("YYYY年MM月DD日", "yyyy年MM月dd日"));
			RadioListDateFormat.Items.Add(new ListItem("MM.DD", "MM.dd"));
			RadioListDateFormat.Items.Add(new ListItem("MM/DD", "MM/dd"));
			RadioListDateFormat.Items.Add(new ListItem("MM月DD日", "MM月dd日"));

			//「見出表示」項目のラジオボタンの初期化
			RadioListDisplayTopic.Items.Add(new ListItem(resource.GetString("CAPTION_VISIBLE"), "1"));
			RadioListDisplayTopic.Items.Add(new ListItem(resource.GetString("CAPTION_HIDDEN"), "0"));

			//「日付表示」項目の「表示，非表示」ラジオボタンの初期化
			RadioListDisplayDate.Items.Add(new ListItem(resource.GetString("CAPTION_VISIBLE"), "1"));
			RadioListDisplayDate.Items.Add(new ListItem(resource.GetString("CAPTION_HIDDEN"), "0"));

			#endregion

			//遷移前元画面から渡されたEditModeを取得。
			//NEW:新規作成
			//UPD:更新（UPD時は“TopicId”が渡される）
			//CFM:確認(確認画面からの遷移)
			string editMode = Convert.ToString(HttpContext.Current.Items["EditMode"]);
			ViewState["EditMode"] = editMode;

			switch (editMode)
			{
				case "NEW":
					//ラジオボタンリストコントロールの初期値をセット
					RadioListDisplayTopic.SelectedValue = "1";
					RadioListDisplayDate.SelectedValue = "1";
					RadioListDateFormat.SelectedValue = "yyyy.MM.dd";

					break;
				case "UPD":

					#region 更新時のデータを画面にセット

					string topicId = Convert.ToString(HttpContext.Current.Items["TopicId"]);

					LoginUserInfoVO loginInfo = new LoginUserInfoVO();
					loginInfo.LoginId = LoginUserContext.LoginId;
					InformationService service = new InformationService(loginInfo);

					TopTopicKey pKey = new TopTopicKey(topicId);
					DataResult<DataTable> topicResult = service.GetTopTopic(pKey);

					if (topicResult.IsSuccess)
					{
						if (topicResult.ResultData.Rows.Count > 0)
						{
							DataTable res = topicResult.ResultData;

							#region VOにセットしてセッションに格納


							TopTopicVO vo = new TopTopicVO();

							vo.TopicId = Convert.ToString(res.Rows[0]["TOPIC_ID"]);
							vo.Topic = Convert.ToString(res.Rows[0]["TOPIC"]);
							vo.NewDisplayPriod = Convert.ToString(res.Rows[0]["NEW_DISPLAY_PERIOD"]);
							vo.DateDisplayFlag = Convert.ToString(res.Rows[0]["DATE_DISPLAY_FLAG"]);
							vo.DateFormat = Convert.ToString(res.Rows[0]["DATE_FORMAT"]);
							vo.DisplayNumber = Convert.ToString(res.Rows[0]["DISPLAY_NUMBER"]);
							vo.DisplayPeriod = Convert.ToString(res.Rows[0]["DISPLAY_PERIOD"]);
							vo.DisplayFlag = Convert.ToString(res.Rows[0]["DISPLAY_FLAG"]);
							vo.SortNo = Convert.ToString(res.Rows[0]["SORT_NO"]);
							vo.CreateDateTime = Convert.ToDateTime(res.Rows[0]["CREATE_DATETIME"]);
							vo.CreateUserId = Convert.ToString(res.Rows[0]["CREATE_USER_ID"]);
							vo.UpdateDateTime = Convert.ToDateTime(res.Rows[0]["UPDATE_DATETIME"]);
							vo.UpdateUserId = Convert.ToString(res.Rows[0]["UPDATE_USER_ID"]);
							vo.RowUpdateId = Convert.ToString(res.Rows[0]["ROW_UPDATE_ID"]);

							//セッションにセット
							SessionManager.SetObject(vo, "SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
								"SESSION_KEY_INFORMATION_PGID");

							#endregion

							#region  画面にセット

							//見出し名
							TopicNameBox.Text = Convert.ToString(res.Rows[0]["TOPIC"]);
							//「見出表示」

							switch (Convert.ToString(res.Rows[0]["DISPLAY_FLAG"]))
							{
								case "0":
									//非表示
									RadioListDisplayTopic.SelectedValue = "0";
									break;
								case "1":
									//表示
									RadioListDisplayTopic.SelectedValue = "1";
									break;
								default:
									break;
							}
							//New表示期間
							NewDisplayPeriodBox.Text = Convert.ToString(res.Rows[0]["NEW_DISPLAY_PERIOD"]);
							//日付表示(表示・非表示のラジオボタン)
							switch (Convert.ToString(res.Rows[0]["DATE_DISPLAY_FLAG"]))
							{
								case "0":
									//非表示
									RadioListDisplayDate.SelectedValue = "0";
									break;
								case "1":
									//表示
									RadioListDisplayDate.SelectedValue = "1";
									break;
								default:
									break;
							}
							//日付フォーマット

							RadioListDateFormat.SelectedValue = Convert.ToString(res.Rows[0]["DATE_FORMAT"]);
							//表示件数
							DisplayNumberBox.Text = Convert.ToString(res.Rows[0]["DISPLAY_NUMBER"]);
							//表示期間
							DisplayPeriodBox.Text = Convert.ToString(res.Rows[0]["DISPLAY_PERIOD"]);
							//表示順

							SortNoBox.Text = Convert.ToString(res.Rows[0]["SORT_NO"]);

							#endregion
						}
						else
						{
							//排他エラー
							MessageResource messageresource = ResourceManager.GetInstance().GetMessageResource();
							BusinessErrorMessage.Text = messageresource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
							BusinessErrorMessage.Visible = true;

							UpdateBtn.Enabled = false;
							return;
						}
					}

					#endregion

					break;
				case "CFM":

					//セッションからVOを取得

					TopTopicVO cfmVo = (TopTopicVO)SessionManager.GetObject(
						"SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
						"SESSION_KEY_INFORMATION_PGID");
					if (cfmVo == null)
					{
						throw new ApplicationException("Information_TopicEdit:見出し情報の取得に失敗しました。");
					}

					#region  画面にセット

					//見出し名
					TopicNameBox.Text = cfmVo.Topic;
					//「見出表示」

					switch (cfmVo.DisplayFlag)
					{
						case "0":
							//非表示
							RadioListDisplayTopic.SelectedValue = "0";
							break;
						case "1":
							//表示
							RadioListDisplayTopic.SelectedValue = "1";
							break;
						default:
							break;
					}
					//New表示期間
					NewDisplayPeriodBox.Text = cfmVo.NewDisplayPriod;
					//日付表示(表示・非表示のラジオボタン)
					switch (cfmVo.DateDisplayFlag)
					{
						case "0":
							//非表示
							RadioListDisplayDate.SelectedValue = "0";
							break;
						case "1":
							//表示
							RadioListDisplayDate.SelectedValue = "1";
							break;
						default:
							break;
					}
					//日付フォーマット

					RadioListDateFormat.SelectedValue = cfmVo.DateFormat;
					//表示件数
					DisplayNumberBox.Text = cfmVo.DisplayNumber;
					//表示期間
					DisplayPeriodBox.Text = cfmVo.DisplayPeriod;
					//表示順

					SortNoBox.Text = cfmVo.SortNo;

					#endregion


					break;
			}
		}

	}


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

		TopTopicVO vo = new TopTopicVO();

		#region  VOに画面の値をセット

		//見出し名
		vo.Topic = TopicNameBox.Text;
		//「見出表示」
		vo.DisplayFlag = RadioListDisplayTopic.SelectedValue;
		//New表示期間
		vo.NewDisplayPriod = Convert.ToInt32(NewDisplayPeriodBox.Text).ToString();
		//日付表示(表示・非表示のラジオボタン)
		vo.DateDisplayFlag = RadioListDisplayDate.SelectedValue;
		//日付フォーマット
		vo.DateFormat = RadioListDateFormat.SelectedValue.ToString();
		//表示件数
		vo.DisplayNumber = Convert.ToInt32(DisplayNumberBox.Text).ToString();
		//表示期間
		vo.DisplayPeriod = Convert.ToInt32(DisplayPeriodBox.Text).ToString();
		//表示順
		vo.SortNo = Convert.ToInt32(SortNoBox.Text).ToString();

		#endregion

		//セッションにセット
		SessionManager.SetObject(vo, "SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
			"SESSION_KEY_INFORMATION_PGID");

		//確認画面に遷移
		Server.Transfer("TopicConfirm.aspx");
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

		TopTopicVO vo = (TopTopicVO)SessionManager.GetObject("SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
			"SESSION_KEY_INFORMATION_PGID");


		#region  VOに画面の値をセット

		//見出し名
		vo.Topic = TopicNameBox.Text;
		//「見出表示」
		vo.DisplayFlag = RadioListDisplayTopic.SelectedValue;
		//New表示期間
		vo.NewDisplayPriod = Convert.ToInt32(NewDisplayPeriodBox.Text).ToString();
		//日付表示(表示・非表示のラジオボタン)
		vo.DateDisplayFlag = RadioListDisplayDate.SelectedValue;
		//日付フォーマット
		vo.DateFormat = RadioListDateFormat.SelectedValue;
		//表示件数
		vo.DisplayNumber = Convert.ToInt32(DisplayNumberBox.Text).ToString();
		//表示期間
		vo.DisplayPeriod = Convert.ToInt32(DisplayPeriodBox.Text).ToString();
		//表示順
		vo.SortNo = Convert.ToInt32(SortNoBox.Text).ToString();

		#endregion

		//セッションにセット
		SessionManager.SetObject(vo, "SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
			"SESSION_KEY_INFORMATION_PGID");

		//確認画面に遷移
		Server.Transfer("TopicConfirm.aspx");

	}

	/// <summary>
	/// 戻るボタン押下
	/// </summary>
	/// <remarks>一覧画面に遷移</remarks>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void BackBtn_Click(object sender, EventArgs e)
	{
		//セッションからVOを削除
		SessionManager.SessionRemove(
			"SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
			"SESSION_KEY_INFORMATION_PGID");

		Server.Transfer("TopicList.aspx");
	}

	#region フォームのデータを表示


	/// <summary>
	/// 表題セット，コントロールの表示制御
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			#region 標題セット

			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("TopicEdit");

			//標題をセットする
			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			TopicNameLbl.Text = resource.GetString("TopicNameLbl");
			DisplayLbl.Text = resource.GetString("DisplayLbl");
			NewDisplayPeriodLbl.Text = resource.GetString("NewDisplayPeriodLbl");
			DateDisplayFlagLbl.Text = resource.GetString("DateDisplayFlagLbl");
			DisplayNumberLbl.Text = resource.GetString("DisplayNumberLbl");
			DisplayPeriodLbl.Text = resource.GetString("DisplayPeriodLbl");
			SortNo.Text = resource.GetString("SortNo");
			CreateBtn.Text = resource.GetString("CreateBtn");
			UpdateBtn.Text = resource.GetString("UpdateBtn");
			BackBtn.Text = resource.GetString("BackBtn");
			UnitDayLbl2.Text = resource.GetString("UnitDayLbl2");
			UnitAffarLbl.Text = resource.GetString("UnitAffarLbl");
			UnitDayLbl1.Text = resource.GetString("UnitDayLbl1");
			TopicNameReqValid.ErrorMessage = resource.GetString("TopicNameReqValid");
			NewDisplayPeriodReqValid.ErrorMessage = resource.GetString("NewDisplayPeriodReqValid");
			NewDisplayPeriodValidator.ErrorMessage = resource.GetString("NewDisplayPeriodValidator");
			DisplayNumberReqValid.ErrorMessage = resource.GetString("DisplayNumberReqValid");
			DisplayNumbervalidator.ErrorMessage = resource.GetString("DisplayNumbervalidator");
			DisplayPeriodReqValid.ErrorMessage = resource.GetString("DisplayPeriodReqValid");
			DisplayPeriodvalidator.ErrorMessage = resource.GetString("DisplayPeriodvalidator");
			SortNoReqValid.ErrorMessage = resource.GetString("SortNoReqValid");
			SortNoValid.ErrorMessage = resource.GetString("SortNoValid");
			NoZeroDisplayNumberValid.ErrorMessage = resource.GetString("NoZeroDisplayNumberValid");
			//TopicNameInvalidCharValid.Text = resource.GetString("TopicNameInvalidCharValid");

			#region 項目説明

			TopicNameCutline.Text = resource.GetString("TopicNameCutline");
			NewDisplayPeriodCutline.Text = resource.GetString("NewDisplayPeriodCutline");
			DisplayNumberCutline.Text = resource.GetString("DisplayNumberCutline");
			DisplayPeriodCutline.Text = resource.GetString("DisplayPeriodCutline");
			SortNoCutline.Text = resource.GetString("SortNoCutline");

			#endregion

			#endregion

			#region ボタン表示の制御

			switch (Convert.ToString(ViewState["EditMode"]))
			{
				case "NEW":
					UpdateBtn.Visible = false;
					break;
				case "UPD":
					CreateBtn.Visible = false;
					//日付表示ラジオボタン（RadioListDisplayDate）が無効だったら
					//日付フォーマットラジオボタン（RadioListDateFormat）を押下不能にする。

					if (RadioListDisplayDate.SelectedValue == "0")
					{
						RadioListDateFormat.Enabled = false;
					}

					break;
				case "CFM":
					/* CFM時は確認画面からの遷移。

					 * セッションからVOを取得、TopicIdが空なら

					 * 新規登録として画面を初期化。

					 * TopicIdが入力されていたら更新画面として初期化。

					 */

					//セッションからVOを取得

					TopTopicVO cfmVo = (TopTopicVO)SessionManager.GetObject(
						"SESSION_KEY_INFORMATION_TOP_TOPIC_VO",
						"SESSION_KEY_INFORMATION_PGID");
					if (string.IsNullOrEmpty(cfmVo.TopicId))
					{
						//新規作成
						UpdateBtn.Visible = false;

						//日付表示ラジオボタン（RadioListDisplayDate）が無効だったら
						//日付フォーマットラジオボタン（RadioListDateFormat）を押下不能にする。

						if (RadioListDisplayDate.SelectedValue == "0")
						{
							RadioListDateFormat.Enabled = false;
						}
					}
					else
					{
						//更新時

						CreateBtn.Visible = false;

						//日付表示ラジオボタン（RadioListDisplayDate）が無効だったら
						//日付フォーマットラジオボタン（RadioListDateFormat）を押下不能にする。

						if (RadioListDisplayDate.SelectedValue == "0")
						{
							RadioListDateFormat.Enabled = false;
						}
					}
					break;
				default:
					break;
			}

			#endregion

		}

	}

	#endregion


	/// <summary>
	/// 日付表示欄の「表示，非表示」ラジオボタンの値が変化した時
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void RadioListDisplayDate_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (RadioListDisplayDate.SelectedValue == "0")
		{
			RadioListDateFormat.Enabled = false;
		}
		else
		{
			RadioListDateFormat.Enabled = true;
		}
	}

	/// <summary>
	/// 表示件数の検証
	/// </summary>
	/// <remarks>0の時は不正な入力とします</remarks>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void NoZeroDisplayNumberValid_ServerValidate(object source, ServerValidateEventArgs args)
	{
		Regex zeroRegEx = new System.Text.RegularExpressions.Regex(@"^[0]{1,4}$");
		if (zeroRegEx.IsMatch(DisplayNumberBox.Text))
		{
			args.IsValid = false;
		}
		else
		{
			args.IsValid = true;
		}
	}
}
