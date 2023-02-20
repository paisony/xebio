using System;
using System.Text;

using Common.Standard.Attribute;
using Common.Standard.Message;

namespace Common.Standard.Page
{
    /// <summary>
    /// システムエラー画面のコードビハインドクラスです。
    /// </summary>
    public partial class MultiWindow : System.Web.UI.Page
    {
        #region メソッド
        /// <summary>
        /// 例外を取得し、エラー表示をします。
        /// この画面はGlobal.asaxからServer.Transferでアクセスされます。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// ページエラー処理を行います。
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Page_Error(object sender, EventArgs e)
        {
            Server.ClearError();
            StandardMessageManager messageMgr = StandardMessageManager.GetInstance();
            Response.Write(Server.HtmlEncode(messageMgr.GetString("Y970")));
            Response.End();
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
                //StandardMessageManager messageMgr = StandardMessageManager.GetInstance();
                //メッセージ(エラーが発生しました。)
                //this.Message.Text = Server.HtmlEncode(messageMgr.GetString("Y969"));
            }
        }
        #endregion
        #endregion
    }
}