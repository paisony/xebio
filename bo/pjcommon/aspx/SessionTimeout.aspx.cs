using System;

using Common.Standard.Attribute;
using Common.Standard.Message;
using Common.IntegrationMD.Util;
using System.Web;
using Common.Advanced.Model.Context;
using Common.Standard.Model.Data;

namespace Common.Standard.Page
{
	/// <summary>
	/// セッションタイムアウト画面のコードビハインドクラスです。
	/// </summary>
	public partial class SessionTimeout : System.Web.UI.Page
	{
		#region フィールド
		/// <summary>
		/// クライアントメッセージ
		/// </summary>
		protected String clientMessage;
		#endregion

		#region メソッド
		/// <summary>
		/// 画面表示処理を行います。
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			StandardMessageManager messageMgr = StandardMessageManager.GetInstance();
			//メッセージ(認証に失敗しました。業務画面を終了します。)
			//this.clientMessage = Server.HtmlEncode(messageMgr.GetString("Y965"));
			this.clientMessage = Server.HtmlEncode(MessageResourceUtil.GetString("I431"));

			//機能排他ログ削除
			//DBコンテキストを取得します。
			IDBContext dbcontext = StandardDBContextFactory.CreateDbContext();
			try
			{
				//コネクション開始
				if (dbcontext != null)
				{
					dbcontext.OpenConnection();
				}
				ExclusionUtil.DeleteExclusionLog(dbcontext, null, HttpContext.Current.Request.UserHostAddress);
			}
			catch (System.Exception)
			{
			}
			finally
			{
				if (dbcontext != null)
				{
					//コネクションクローズ
					dbcontext.CloseConnection();
				}
			}

			this.DataBind();
		}
		#endregion
	}
}