using System;

using Common.Advanced.Resource;

using Common.Standard.Attribute;
using Common.Standard.Constant;
using Common.Standard.FileLoad;
using Common.Standard.Session;
using Common.Standard.Exception;

namespace Common.Standard.Page
{
	/// <summary>
	/// ファイルダウンロード部品です。
	/// </summary>
	public partial class FileDownLoader : System.Web.UI.Page
	{
		#region フィールド
		/// <summary>
		/// リクエストプログラムIDキー値
		/// </summary>
		private const String PGID_KEY = "pgid";
		/// <summary>
		/// リクエストフォームIDキー値
		/// </summary>
		private const String FORMID_KEY = "formid";
		/// <summary>
		/// リソースタイトルバーキー値
		/// </summary>
		private const String TITLEBAR_KEY = "_Titlebar";
		#endregion

		#region メソッド
		/// <summary>
		/// ページロード
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			//クエリパラメータを取得する。
			String pgid = Request.QueryString[PGID_KEY];
			String formid = Request.QueryString[FORMID_KEY];

			if (SessionInfoUtil.GetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FILE, Session) != null)
			{
				try
				{
					FormResource resource = ResourceFactory.GetFormResource(formid);
					String caption = resource.GetString(formid + TITLEBAR_KEY);

					//セッションからファイル名を取得
					String downLoadFile = (String)SessionInfoUtil.GetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FILE, Session);
					//SessionInfoUtil.RemovePgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FILE, Session);

					//セッションからファイルパスを取得
					String downLoadFolder = (String)SessionInfoUtil.GetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FOLDER, Session);
					String dialog = (String)SessionInfoUtil.GetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_DIALOG, Session);
					//セッションの値を初期化
					SessionInfoUtil.SetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_FOLDER, null, Session);
					SessionInfoUtil.SetPgObject(pgid, SessionKeyConstant.FILE_DOWNLOAD_DIALOG, null, Session);

					//ダウンロード処理を実行する。
					if (string.IsNullOrEmpty(downLoadFolder))
					{
						FileManager.Download(downLoadFile, caption);
					}
					else if (string.IsNullOrEmpty(dialog))
					{
						FileManager.Download(downLoadFile, downLoadFolder, caption);
					}
					else
					{
						FileManager.Download(downLoadFile, downLoadFolder, caption, dialog);
					}

				}
				catch (ApplicationErrorException ex)
				{
					//継続可能なエラーだが元の画面へは戻れないため継続不可エラーとする。
					throw new SystemErrorException(ex.Message, ex);
				}
			}
			else
			{
				//ファイルが存在しない場合、ダウンロード画面を終了します。
				Server.Transfer("../html/windowClose.html");
			}
		}
		#endregion
	}
}