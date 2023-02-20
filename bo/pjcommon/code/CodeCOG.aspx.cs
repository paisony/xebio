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

using System.Globalization;
using System.Reflection;
using System.Resources;

using Common.Advanced.Codecondition.Code.Command;
using Common.Advanced.Codecondition.Code.Context;
using Common.Advanced.Codecondition.Code.Vo;
using Common.Advanced.Codecondition.Code.Util;
using Common.Advanced.Session;
using Common.Advanced.Util;
using Common.Advanced.Info;

using Common.Standard.Attribute;

namespace Pjcommon.Code
{
	/// <summary>
	/// CodeCOG の概要の説明です。
	/// </summary>
	public partial class CodeCOGPage : System.Web.UI.Page
	{
		protected string ExtItemID;
		protected string queryString;
		protected string checkNeedFlag;
		protected string KeyItemName;
		protected string MappingJS;
		protected string ResultJS;
		protected string Url;
		protected CodeCogCommand cog;
		protected string WindowTitle;
		protected string IcogMsg001;
		protected ICodeContext codeContext;

		#region Web フォーム デザイナで生成されたコード 
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: この呼び出しは、ASP.NET Web フォーム デザイナで必要です。
			//
			this.cog = new CodeCogCommand();
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
			this.Load += new System.EventHandler(this.cog.DoCOGInit);
		}
		#endregion

		protected void CodeCOG_PreRender(object sender, EventArgs e)
		{
			this.codeContext = CodeUtility.GetContext(Context);

			// 拡張定義情報を作成する
			ExtItemID = string.Join(",",(string[])codeContext.Condition.ExtItemIDs.ToArray(typeof(string)));

			// 画面情報の設定
			ICodeCommandInfo command = this.codeContext.Command;
			Url = Request.ApplicationPath;
			if (Url == "/") { Url = string.Empty; }
			KeyItemName = string.Join(",",codeContext.ResultInfo.GetMappedKeyIDs());

			if (!this.codeContext.Form.IsFirstTime) 
			{
				MappingJS = codeContext.GetMappingJS();
				ResultJS = cog.GetResultJS(this.codeContext);
			}

			// コードのコンテキスト情報をJavaScriptに出力する
			this.ClientScript.RegisterClientScriptBlock(this.GetType(), "context",
				"var codes = " + CodeUtility.CreateCodeContextJson(codeContext) + ";", true);

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
				this.IcogMsg001 = rs.GetString("IcogMsg001");
			}
		}
	}
}
