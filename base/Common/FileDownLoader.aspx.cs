using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Com.Fujitsu.SmartBase.Base.Certification.BC;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using Com.Fujitsu.SmartBase.Base.Certification;
using Com.Fujitsu.SmartBase.Base.Common.Model;

public partial class Common_FileDownLoader : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

		//クエリパラメータを取得する。
		string solutionId = Request.Params["solutionId"];
		string functionId = Request.Params["functionId"];
		string funcName = string.Empty;
		string funcUrl = string.Empty;
		string funcParams = string.Empty;
		string windowStyle = string.Empty;
		//FUNCTIONからデータ取得
		DataRow funcRow = FunctionMst.GetFunction(solutionId, functionId);
		if (funcRow != null)
		{
			funcName = Convert.ToString(funcRow["FUNCTION_NAME"]);
			funcUrl = Convert.ToString(funcRow["FUNCTION_URL"]);
			funcParams = Convert.ToString(funcRow["FUNCTION_PARAMS"]);
			windowStyle = Convert.ToString(funcRow["WINDOW_STYLE"]);
		}
		else
		{
			//エラー
			throw new ApplicationException("ダウンロード情報取得に失敗しました。");
		}

		//BS_LOGIN_LOG出力
		CertificationService certBC = new CertificationService();
		LoginLogVO vo = new LoginLogVO();
		vo.LoginID = LoginUserContext.LoginId; ;
		vo.LogType = LoginLogType.FunctionExcute;
		vo.FunctionUrl = funcUrl;
		vo.LogDatetime = DateTime.Now;
		vo.IPAddress = RequestInfoUtil.GetLoginuserInfoVo(HttpContext.Current.Request.ServerVariables).IPAddress;
		vo.PCName = RequestInfoUtil.GetLoginuserInfoVo(HttpContext.Current.Request.ServerVariables).PCName;
		certBC.InsertLoginLog2(vo);

		try
		{
			string downLoadName = System.IO.Path.GetFileNameWithoutExtension(funcUrl) + System.IO.Path.GetExtension(funcUrl).ToLower();
			HttpResponse response = HttpContext.Current.Response;
			response.Clear();
			response.Buffer = true;
			response.ContentEncoding = System.Text.Encoding.GetEncoding("SHIFT_JIS");
			System.IO.FileInfo fileToDownload = new System.IO.FileInfo(funcUrl);
			response.AddHeader("Content-Disposition", "'" + windowStyle + ";filename=" + HttpUtility.UrlEncode(downLoadName) + ";charset=SHIFT_JIS");
			response.ContentType = funcParams;
			response.Flush();
			response.WriteFile(fileToDownload.FullName, true);
			response.End();
		}
		catch (Exception)
		{
		}
	}
}
