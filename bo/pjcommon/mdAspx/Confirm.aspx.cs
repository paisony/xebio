using System.Web.UI.WebControls;
using Common.Standard.Session;
using System.Collections.Generic;
using Common.Standard.Message;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.Util;
using Common.IntegrationMD.Import;
using Common.Advanced.Web.Context;
using Common.Standard.Constant;
using System.Collections;
using System;

public partial class pjcommon_mdAspx_Confirm : System.Web.UI.Page
{
	#region フィールド
	protected string pgId;
	protected string proc;
	/// <summary>
	/// リクエストキー
	/// </summary>
	private const String REQUEST_KEY1 = "pgId";
	private const String REQUEST_KEY2 = "mess";
	private const String REQUEST_KEY3 = "proc";
	#endregion

	#region メソッド
	/// <summary>
	/// ページロード
	/// </summary>
	/// <param name="sender">sender</param>
	/// <param name="e">e</param>
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	#region 標題を設定します。
	/// <summary>
	/// 標題を設定します。
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		if (!base.IsPostBack)
		{
			this.pgId = (String)Request[REQUEST_KEY1];
			this.message.Text = (String)Request[REQUEST_KEY2];
			this.proc = (String)Request[REQUEST_KEY3];

			////ウィンドウタイトル(メッセージ一覧)
			//標題（処理の継続）
			this.button1.Value = "ＯＫ";
			//標題（処理の中断）
			this.button2.Value = "キャンセル";

			if (string.IsNullOrEmpty(this.message.Text))
			{
				this.message.Text = "終了します。よろしいですか？";
			}
			if (!string.IsNullOrEmpty(proc))
			{
				if ("OPR".Equals(proc.ToUpper()))
				{
					//this.message.Text = "運用時間外のため起動できません。ログオフして下さい。";
					this.button2.Visible = false;
				}
				if ("SESS".Equals(proc.ToUpper()))
				{
					//this.message.Text = "セッションエラーが発生しました。ログオフして下さい。";
					this.button2.Visible = false;
				}
				if ("PROC1".Equals(proc.ToUpper()))
				{
					this.message.Text = "既に同一機能、または同時実行不可の機能が立上っています。確認して下さい。";
					this.button2.Visible = false;
				}
			}
			// 標題
			StandardCaptionManager captionMgr = StandardCaptionManager.GetInstance();

			this.DataBind();
		}
	}
	#endregion
	#endregion
}
