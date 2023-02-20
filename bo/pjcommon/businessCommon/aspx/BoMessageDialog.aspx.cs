using Common.Standard.Constant;
using Common.Standard.Message;
using Common.Standard.Session;
using System;
using System.Collections.Generic;

namespace Common.Business.aspx
{
	/// <summary>
	/// エラーを全件表示します。
	/// </summary>
	public partial class BoMessageDialog : System.Web.UI.Page
	{
		#region フィールド
		/// <summary>
		/// リクエストキー
		/// </summary>
        private const String REQUEST_KEY = "pgId";
        private const String REQUEST_KEY_MSG = "message";
        private const String REQUEST_KEY_LEVEL = "level";
		#endregion

		#region メソッド
		/// <summary>
		/// ページロード
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
            Response.AddHeader("X-XSS-Protection", "0");
            String pgId = (String)Request[REQUEST_KEY];
            String msg = (String)Request[REQUEST_KEY_MSG];
            String level = (String)Request[REQUEST_KEY_LEVEL];

            List<MessageInfoVO> list = null;

			if (!string.IsNullOrEmpty(msg))
			{
				// javascriptで実行されている場合
                list = new List<MessageInfoVO>(); list = new List<MessageInfoVO>();
				Common.Standard.Message.MessageLevel MessegeLvel;
				if (!string.IsNullOrEmpty(level) && level.ToLower() == "info")
				{
					MessegeLvel = MessageLevel.INFO;
				}
				else if (!string.IsNullOrEmpty(level) && (level.ToLower() == "warn" || level.ToLower() == "warnmulti"))
				{
					MessegeLvel = MessageLevel.WARN;
				}
				else
				{
					MessegeLvel = MessageLevel.INFO;
				}
				MessageInfoVO vo = new MessageInfoVO(MessegeLvel);
                vo.Message = msg;
                list.Add(vo);

			}
			else
			{
				// サーバ側で実行されている場合
				list = (List<MessageInfoVO>)SessionInfoUtil.GetPgObject(pgId, SessionKeyConstant.MESSAGE_LIST, Session);
			}

            RepeaterInfo.DataSource = list;
			RepeaterInfo.DataBind();
			RepeaterWarn.DataSource = list;
			RepeaterWarn.DataBind();
			RepeaterWarnMulti.DataSource = list;
			RepeaterWarnMulti.DataBind();
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
				// 表示レベルの取得
				String level = (String)Request[REQUEST_KEY_LEVEL];

				// 表示するパネルの設定
                if (level.ToLower() == "warn")
				{
					// 警告の場合
					PanelInfo.Visible = false;
					PanelWarn.Visible = true;
					PanelWarnMulti.Visible = false;
                }
				else if (level.ToLower() == "warnmulti")
				{
					// 警告(複数)の場合
					PanelInfo.Visible = false;
					PanelWarn.Visible = false;
					PanelWarnMulti.Visible = true;
				}
				else
				{
					// 情報の場合
					PanelInfo.Visible = true;
					PanelWarn.Visible = false;
					PanelWarnMulti.Visible = false;
                }
			}
		}
		#endregion
		#endregion
	}
}