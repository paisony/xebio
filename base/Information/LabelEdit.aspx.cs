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
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.Information.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information;
using Com.Fujitsu.SmartBase.Base.Common.Resource;

public partial class Information_LabelEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			//セッションからコンテンツを取得してテキストボックスにセット
			TopDisplayVO vo = (TopDisplayVO)SessionManager.GetObject(
				"SESSION_KEY_INFORMATION_TOP_DISPLAY_VO",
				"SESSION_KEY_INFORMATION_PGID");

			ContentBox.Text = vo.DisplayContent;
		}
	}


	#region ボタン押下

	/// <summary>
	/// 戻るボタン押下
	/// </summary>
	/// <remarks>お知らせ管理メニューに戻ります</remarks>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void BackBtn_Click(object sender, EventArgs e)
	{
		//セッションからコンテンツ情報を削除
		SessionManager.SessionRemove(
			"SESSION_KEY_INFORMATION_TOP_DISPLAY_VO",
			"SESSION_KEY_INFORMATION_PGID");

		Server.Transfer("LabelDisplay.aspx");
	}


	/// <summary>
	/// 更新ボタン押下
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ModifyBtn_Click(object sender, EventArgs e)
	{
		//検証結果のチェック
		if (!Page.IsValid) return;

		//セッションからコンテンツを取得してテキストボックスにセット
		TopDisplayVO vo = (TopDisplayVO)SessionManager.GetObject(
			"SESSION_KEY_INFORMATION_TOP_DISPLAY_VO",
			"SESSION_KEY_INFORMATION_PGID");
		vo.DisplayContent = Convert.ToString(ContentBox.Text);

		#region 更新

		LoginUserInfoVO loginInfo = new LoginUserInfoVO();
		loginInfo.LoginId = LoginUserContext.LoginId;
		InformationService service = new InformationService(loginInfo);
		Result res = service.UpdateTopDisplay(vo);
		if (!res.IsSuccess && res.HasError && res.Errors[0] is DBConcurrencyError)
		{
			// 排他エラー
			MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
			BusinessErrorMessage.Text = resource.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
			BusinessErrorMessage.Visible = true;
			return;
		}
		else if (!res.IsSuccess)
		{
			//排他チェックエラー以外のエラーの発生時
			throw new ApplicationException("Information_LabelEdit:表示画面情報の更新に失敗しました。" + res.ToString());
		}

		#endregion

		//セッションからコンテンツ情報を削除
		SessionManager.SessionRemove(
			"SESSION_KEY_INFORMATION_TOP_DISPLAY_VO",
			"SESSION_KEY_INFORMATION_PGID");

		Server.Transfer("LabelDisplay.aspx");
	}

	#endregion

	#region その他

	/// <summary>
	/// onPreRenderイベントで呼ばれるメソッド
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			#region 標題セット

			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("LabelEdit");

			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			ModifyBtn.Text = resource.GetString("ModifyBtn");
			BackBtn.Text = resource.GetString("BackBtn");
			//項目説明
			ContentCutline.Text = resource.GetString("ContentCutline");
			//エラーメッセージ
			ContentBoxRegValid.ErrorMessage = resource.GetString("ContentBoxRegValid");
			//ContentBoxInvalidCharValid.Text = resource.GetString("ContentBoxInvalidCharValid");

			#endregion
		}
	}

	#endregion
}
