using System;

using Common.Standard.Attribute;
using Common.Standard.Message;
using System.Web;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.Util;
using Common.Advanced.Model.Context;
using Common.Standard.Model.Data;
using Common.Advanced.Model.Data;
using System.Collections;
using Common.Standard.Constant;

namespace Common.Standard.Page
{
	/// <summary>
	/// 業務エラー画面のコードビハインドクラスです。
	/// </summary>
	public partial class ApplicationError : System.Web.UI.Page
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
			if (!IsPostBack)
			{
				if (Server.GetLastError() != null)
				{
					System.Exception ex;
					if (Server.GetLastError().InnerException != null)
					{
						ex = Server.GetLastError().InnerException;
					}
					else
					{
						ex = Server.GetLastError();
					}
					if (ex != null)
					{
						//ExceptionName.Text = ex.GetType().FullName;
						ExceptionMessage.Text = ex.Message;
					}
				}
			}
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
				StandardCaptionManager captionMgr = StandardCaptionManager.GetInstance();
				//ウィンドウタイトル(業務エラー)
				this.Windowtitle.Text = Server.HtmlEncode(captionMgr.GetString("C994"));
				//標題(メッセージ)
				this.Message.Text = Server.HtmlEncode(captionMgr.GetString("C997"));
				//ボタン標題(閉じる)
				this.CloseBtn.Value = captionMgr.GetString("C987");

				StandardMessageManager messageMgr = StandardMessageManager.GetInstance();
				//メッセージ(業務エラーが発生しました。)
				this.ErrorMessage.Text = Server.HtmlEncode(messageMgr.GetString("Y971"));
			}

			//排他機能ログ削除
			string programid = "";
			try
			{
				programid = (string)HttpContext.Current.Session[MdSystemConstant.MD_SYSTEM_ERROR_PGM_ID];
			}
			catch (System.Exception)
			{
			}
			if (!string.IsNullOrEmpty(programid))
			{
				Hashtable ht = (Hashtable)HttpContext.Current.Session[SessionKeyConstant.GetPgSessionKey(programid)];
				if (ht != null)
				{
					if (Convert.ToBoolean(ht[SessionKeyConstant.EXCLUSION_PROGRAM + programid.ToUpper()]))
					{
						//DBコンテキストを取得します。
						IDBContext dbcontext2 = StandardDBContextFactory.CreateDbContext();
						try
						{
							//コネクション開始
							dbcontext2.OpenConnection();
							//機能排他ログ出力
							if (HttpContext.Current.Session != null && HttpContext.Current.Session[MdSystemConstant.MD_SYSTEM_ERROR_PGM_ID] != null)
							{
								ExclusionUtil.DeleteExclusionLog(dbcontext2, programid, null);
							}
						}
						catch (DBException)
						{
						}
						finally
						{
							if (dbcontext2 != null)
							{
								//コネクションクローズ
								dbcontext2.CloseConnection();
							}
						}
					}
				}
			}
		}
		#endregion
		#endregion
	}
}