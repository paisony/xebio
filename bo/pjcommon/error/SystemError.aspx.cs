using System;
using System.Text;

using Common.Standard.Attribute;
using Common.Standard.Message;
using System.Web;
using Common.IntegrationMD.Constant;
using Common.IntegrationMD.Util;
using Common.Advanced.Model.Context;
using Common.Standard.Model.Data;
using Common.Advanced.Model.Data;
using Common.Standard.Constant;
using System.Collections;

namespace Common.Standard.Page
{
	/// <summary>
	/// システムエラー画面のコードビハインドクラスです。
	/// </summary>
	public partial class SystemError : System.Web.UI.Page
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
						ExceptionName.Text = ex.GetType().FullName;

						string[] str = ex.Message.Split(new Char[] { '_' });

						//メッセージＩＤが取得できる場合
						if (str.Length == 2)
						{
							ErrCode.Text = str[0];
							ExceptionMessage.Text = str[1];
						}
						else
						{
							//メッセージＩＤが取得できない場合
							ErrCode.Text = "Y000";
							//ExceptionMessage.Text = str[0];
                            ExceptionMessage.Text = "想定外のエラーです。";
                        }
                        ExceptionMessage.Text = HttpUtility.HtmlEncode(ExceptionMessage.Text);
					}

					//日付は無条件に出力
					DateTime now = DateTime.Now;
					this.OccuredTime.Text = now.ToLongDateString() + now.ToLongTimeString();
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
				//ウィンドウタイトル(システムエラー)
				this.Windowtitle.Text = Server.HtmlEncode(captionMgr.GetString("C999"));

				//標題(例外)
				//				this.Exception.Text = Server.HtmlEncode(captionMgr.GetString("C986"));
				//標題(メッセージ)
				//				this.Message.Text = Server.HtmlEncode(captionMgr.GetString("C997"));
				//ボタン標題(詳細表示)
				//				this.DetailBtn.Value = captionMgr.GetString("C989");
				//ボタン標題(閉じる)
				//				this.CloseBtn.Value = captionMgr.GetString("C987");
				//標題(詳細)
				//				this.DetailCaption.Text = Server.HtmlEncode(captionMgr.GetString("C990"));

				StandardMessageManager messageMgr = StandardMessageManager.GetInstance();
				//メッセージ(エラーが発生しました。)
				this.ErrorMessage.Text = Server.HtmlEncode(messageMgr.GetString("Y969"));
			}

		}
		#endregion
		#endregion
	}
}