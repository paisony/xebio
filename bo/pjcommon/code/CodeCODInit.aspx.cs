using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Resources;
using System.Reflection;
using System.Globalization;

using Common.Advanced.Codecondition.Code.Command;
using Common.Advanced.Codecondition.Code.Context;
using Common.Advanced.Codecondition.Code.Vo;
using Common.Advanced.Codecondition.Code.Util;
using Common.Advanced.Session;
using Common.Advanced.Info;
using Common.Advanced.Util;
using Common.Advanced.Upgraded.Session;

using Common.Standard.Attribute;

namespace Pjcommon.Code
{
	/// <summary>
	/// CodeCODInit の概要の説明です。
	/// </summary>
	public partial class CodeCODInitPage : System.Web.UI.Page
	{
		protected string formID;
		protected string extItemID;
		protected string meisaiNumber;
        protected string mStartIndex;
		protected string levelid;
		protected string url;
		protected string queryString;
		protected string codeId;
		protected CodeCodCommand cod;
		protected string WindowTitle;

		#region Web フォーム デザイナで生成されたコード 
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: この呼び出しは、ASP.NET Web フォーム デザイナで必要です。
			//
			this.cod = new CodeCodCommand();
			InitializeComponent();
			InitialAutoComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{    

		}

		/// <summary>
		/// Componentの初期化.
		/// </summary>
		private void InitialAutoComponent()
		{
			this.Load += new System.EventHandler(this.cod.DoCODInit);
		}
		#endregion

		protected void CodeCODInit_PreRender(object sender, EventArgs e)
		{
			// CodeContextを取得する
			CodeContext codeContext = CodeUtility.GetContext(Context);
			ICodeCommandInfo command = codeContext.Command;

			// 拡張定義情報を作成する
			extItemID = string.Join(",",(string[])codeContext.Condition.ExtItemIDs.ToArray(typeof(string)));

			// 画面情報の設定
			url = Request.ApplicationPath;
			if (url == "/") { url = string.Empty; }
			formID = command.FormID;
			meisaiNumber = command.MNo;
            mStartIndex = command.MStartIndex;
			levelid = command.MID;

			// 表示項目を設定する
			this.SetPageMessages();

			this.DataBind();
		}

		/// <summary>
		/// メッセージの表示
		/// </summary>
		private void SetPageMessages() 
		{
            ResourceSet rs = CodeUtility.GetPageResource(this);
            if (rs != null)
            {
                this.WaitMessage.Text = rs.GetString(this.WaitMessage.ID);
                this.DataAccessMessage.Text = rs.GetString(this.DataAccessMessage.ID);
                this.WindowTitle = rs.GetString("WindowTitle");
            }
		}
	}
}
