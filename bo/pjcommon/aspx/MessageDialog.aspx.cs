using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

using Common.Standard.Attribute;
using Common.Standard.Constant;
using Common.Standard.Message;
using Common.Standard.Session;

namespace Common.Standard.Page
{
	/// <summary>
	/// エラーを全件表示します。
	/// </summary>
	public partial class MessageDialog : System.Web.UI.Page
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

            //javascriptエラーの場合
            if (msg != null)
            {
                list = new List<MessageInfoVO>(); list = new List<MessageInfoVO>();
                MessageInfoVO vo = new MessageInfoVO(!string.IsNullOrEmpty(level) && level.ToLower() == "info" ? MessageLevel.INFO : MessageLevel.ERROR);
                vo.Message = msg;
                list.Add(vo);

                //INFOの場合はセッションに格納しない。
                if (string.IsNullOrEmpty(level) || level.ToLower() != "info")
                {
                    SessionInfoUtil.SetPgObject(pgId, SessionKeyConstant.MESSAGE_LIST, list, Session);
                }
            }

            //INFOの場合はセッションから取得しない。
            if (string.IsNullOrEmpty(level) || level.ToLower() != "info")
            {
                list = (List<MessageInfoVO>)SessionInfoUtil.GetPgObject(pgId, SessionKeyConstant.MESSAGE_LIST, Session);
            }

			foreach (MessageInfoVO msgInfoVO in list)
			{
				if (msgInfoVO.MessageLevel == MessageLevel.ERROR)
				{
                    //エラーが存在する場合はリクエストにキーを設定。
                    HttpContext.Current.Items["MESSAGELEVEL"] = "ERROR";
					break;
				}
			}

            RepeaterError.DataSource = list;
            RepeaterError.DataBind();
            RepeaterInfo.DataSource = list;
            RepeaterInfo.DataBind();
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
				// メッセージ

				StandardMessageManager messageMgr = StandardMessageManager.GetInstance();
                //リクエストからエラーのキーを取得。
                string messageLevel = "";
                if (HttpContext.Current.Items["MESSAGELEVEL"] != null)
                {
                    messageLevel = HttpContext.Current.Items["MESSAGELEVEL"].ToString();
                }

				//標題(業務メッセージ)

				bool errorFlag = true;
				if (SessionInfoUtil.GetPgObject((String)Request[REQUEST_KEY], SessionKeyConstant.MESSAGE_LIST, this.Context.Session) != null)
				{
					errorFlag = false;
					List<MessageInfoVO> list = (List<MessageInfoVO>)SessionInfoUtil.GetPgObject((String)Request[REQUEST_KEY], SessionKeyConstant.MESSAGE_LIST, Session);
					foreach (MessageInfoVO msgInfoVO in list)
					{
						if (msgInfoVO.MessageLevel == MessageLevel.ERROR)
						{
							errorFlag = true;
                            break;
						}
					}
				}
                //リクエストから取得したキーがERRORだった場合はエラーの画面レイアウトで表示。
                if (errorFlag && messageLevel == "ERROR")
                {
                    //エラー件数の取得
                    string[] parameter = { RepeaterError.Items.Count.ToString() };
                    this.PgNameLiteral.Text = Server.HtmlEncode(messageMgr.GetString("WS001", parameter));

                    PanelError.Visible = true;
                    PanelInfo.Visible = false;
                }
                else
                {
                    PanelError.Visible = false;
                    PanelInfo.Visible = true;
                }
			}
		}
		#endregion
		#endregion
	}
}