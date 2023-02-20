// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/03/16 WT)Banno OT1障害対応[QA-0664]

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Role;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using Com.Fujitsu.SmartBase.Base.Certification;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.Systems.Util;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.DataLog.VO;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Com.Fujitsu.SmartBase.Base.DataLog.Util;
using Com.Fujitsu.SmartBase.Base.Certification.Dac;
using Com.Fujitsu.SmartBase.Base.DataLog.Dac;
using Com.Fujitsu.SmartBase.Base.Certification.VO;
using System.Transactions;
using System.Data.Common;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.DataLog;
using Com.Fujitsu.SmartBase.Base.LoginUser.BC;
using System.Collections.Specialized;
using Com.Fujitsu.SmartBase.Library.Log;

public partial class Common_PageTransfer : System.Web.UI.Page
{
	protected string url;
	protected string method;
	protected string errOperate;
	// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add Start ---------------
	protected string errOperate2;
	// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add  END ---------------
	protected string errSession;
	string open_flg;
	string functionId;

	/// <summary>
	/// ログ出力
	/// </summary>
	private static ILogger logger = LogManager.GetLogger();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{

			string solutionId = Request.Params["solutionId"];
			functionId = Request.Params["functionId"];
			string eventParams = Request.Params["eventParams"];
			string debug = Request.Params["debug"];
			ViewState["solutionId"] = solutionId;
			ViewState["functionId"] = functionId;
			ViewState["eventParams"] = eventParams;
			NameValueCollection urlUserParams = Request.Params;


			//サーバURL取得
			string serverurl = string.Empty;
			string paramstr = string.Empty;
			string requestflg = string.Empty;
			string funcurl = string.Empty;
			string subSystemId = string.Empty;
			DataRow funcRow = null;
			if ("XO999P01".Equals(functionId))
			{
				funcRow = FunctionMst.GetFunction(solutionId, "XO010P01");
			}
			else
			{
				//FUNCTIONからデータ取得
				funcRow = FunctionMst.GetFunction(solutionId, functionId);
			}
			if (funcRow != null)
			{
				funcurl = Convert.ToString(funcRow["FUNCTION_URL"]);
				paramstr = Convert.ToString(funcRow["FUNCTION_PARAMS"]);
				requestflg = Convert.ToString(funcRow["REQUEST_FLAG"]);
				open_flg = Convert.ToString(funcRow["WINDOW_OPEN_FLAG"]);
				subSystemId = Convert.ToString(funcRow["SUBSYSTEM_ID"]);
				serverurl = SolutionMst.GetServerUrl(solutionId, subSystemId);
				if ("XO999P01".Equals(functionId))
				{
					funcurl = funcurl.Replace("xo010", "xo999");
				}
			}
			else
			{
				if (!"XO999P01".Equals(functionId))
				{
					//エラー
					throw new ApplicationException("この機能の使用権がありません。");
				}
			}

			#region ロール権限チェック
			if (string.IsNullOrEmpty(debug))
			{
				if (!LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
				{
					if (!CheckFunctionValid(solutionId, functionId))
					{
						//throw new ApplicationException("この機能の使用権がありません。");
					}
				}
			}
			#endregion

			#region セッションタイムアウトチェック
			this.errSession = "";
			if (LoginUserContext.LoginId == null)
			{
				this.errSession = "Session error";
			}
			#endregion

			#region 運用時間チェック
			if (!open_flg.Equals("2"))
			{
				// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add Start ---------------
				ExLoginUserInfoVO infoVo2 = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);
				this.errOperate = "";
				Boolean result = LoginMst.CheckLoginAvailableOnline(infoVo2);
				if (!LoginMst.CheckLoginAvailableOnline(infoVo2))
				{
					this.errOperate2 = "Operation error2";
				}
				// --------------- 2012/03/16 WT)Banno OT1障害対応[QA-0664] Add  End ---------------
				else
				{
					if (string.IsNullOrEmpty(debug))
					{
						if (Convert.ToBoolean(ConfigurationManager.AppSettings[WebConstantUtil.LOGIN_OPERATION_CHECK]))
						{
							ExLoginUserInfoVO infoVo = RequestInfoUtil.GetLoginuserInfoVo(Request.ServerVariables);
							infoVo.LoginId = LoginUserContext.LoginId;
							this.errOperate = "";
							if (!LoginMst.CheckLoginAvailableOperation(infoVo, LoginUserContext.LoginId, LoginUserContext.UserType))
							{
								this.errOperate = "Operation error";
							}
						}
					}
				}
			}
			#endregion

			//POSTかGETかを設定
			if (requestflg == "0")
			{
				method = WebConstantUtil.REQUEST_METHOD_GET;
			}
			else
			{
				method = WebConstantUtil.REQUEST_METHOD_POST;
			}

			url = HttpUtility.UrlDecode(serverurl + funcurl);

			this.DataBind();


			//inputタグ生成用のデータテーブル
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("name", typeof(string)));
			dt.Columns.Add(new DataColumn("value", typeof(string)));

			if (!string.IsNullOrEmpty(paramstr))
			{
				string[] urlparams = paramstr.Split('&');

				#region パラメータセット

				foreach (string para in urlparams)
				{
					if (!string.IsNullOrEmpty(para))
					{
						string[] namevalue = para.Split('=');

						//パラメータの処理
						string reqParam = namevalue[0];
						string reqValue = GetParamValue(namevalue[1]);
						if (reqValue != null && reqValue.Trim().Length > 0)
						{
							DataRow row = dt.NewRow();
							row["name"] = reqParam;
							row["value"] = reqValue;
							dt.Rows.Add(row);
						}
					}
				}
				#endregion
			}

			//イベント情報のパラメータ
			if (!string.IsNullOrEmpty(eventParams))
			{
				string[] urlparams = HttpUtility.HtmlDecode(eventParams).Split('&');

				foreach (string para in urlparams)
				{
					if (!string.IsNullOrEmpty(para))
					{
						string[] namevalue = para.Split('=');

						//パラメータの処理
						string reqParam = namevalue[0];
						string reqValue = GetParamValue(namevalue[1]);
						if (reqValue != null && reqValue.Trim().Length > 0)
						{
							DataRow row = dt.NewRow();
							row["name"] = reqParam;
							row["value"] = reqValue;
							dt.Rows.Add(row);
						}
					}
				}
			}

			//ユーザＵＲＬのパラメータ編集
			for (int i = 0; i < urlUserParams.Count; i++)
			{
				string reqParam = urlUserParams.GetKey(i);
				if (reqParam.Length > 2)
				{
					if (reqParam.ToUpper().Substring(0, 3).Equals("MD_"))
					{
						string reqValue = urlUserParams[reqParam];
						if (reqValue != null && reqValue.Trim().Length > 0)
						{
							DataRow row = dt.NewRow();
							row["name"] = reqParam;
							row["value"] = reqValue;
							dt.Rows.Add(row);
						}
					}
				}
			}

			DataRow row2 = dt.NewRow();
			row2["name"] = "functionId";
			row2["value"] = functionId;
			dt.Rows.Add(row2);

			//Now Loading ...
			if ("XO999P01".Equals(functionId))
			{
				NowLoading.Text = "しばらくお待ちください。";
				WaitImg.ImageUrl = "../Common/images/busy.gif";
			}
			else
			{
				NowLoading.Text = "Now Loading ...";
				WaitImg.ImageUrl = "../Common/images/login/headerline.gif";
			}
			hiddenRepeater.DataSource = dt;
			hiddenRepeater.DataBind();
		}
	}

	/// <summary>
	/// メニュー選択時にURLの引数にユーザー情報を置換する
	/// </summary>
	/// <param name="inStr">変数</param>
	/// <return>ユーザ情報に置換された文字列</return>
	private string GetParamValue(string inStr)
	{
		string res;
		if (!string.IsNullOrEmpty(inStr))
		{
			#region パラメータに情報を詰める

			if (inStr == "%COMPANY_ID%")
			{
				res = LoginUserContext.CompanyId;
			}
			else if (inStr == "%LOGIN_ID%")
			{
				if (!LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
				{
					res = LoginUserContext.LoginId;
				}
				else
				{
					if (SystemSettings.SynchroMode == SystemsConstantUtil.SYNCHRO_ON)
					{
						//システム管理者ID
						string solutionId = Convert.ToString(ViewState["solutionId"]);
						res = LoginMst.GetSystemManagerLoginId(solutionId);
					}
					else
						res = LoginUserContext.LoginId;
				}
			}
			else if (inStr == "%PASSWORD%")
			{
				if (!LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
				{
					res = LoginUserContext.Password;
				}
				else
				{
					if (SystemSettings.SynchroMode == SystemsConstantUtil.SYNCHRO_ON)
					{
						//システム管理者PW
						string solutionId = Convert.ToString(ViewState["solutionId"]);
						res = LoginMst.GetSystemManagerPassword(solutionId);
					}
					else
						res = LoginUserContext.Password;

				}
			}
			else if (inStr == "%CERT_ID%")
			{
				string loginCertId = null;
				CertificationService service = new CertificationService();
				DataResult<DataTable> infoRes = service.GetCertIdByLoginInfo(LoginUserContext.LoginId);
				if (infoRes.IsSuccess && infoRes.ResultData.Rows.Count > 0)
				{
					loginCertId = Convert.ToString(infoRes.ResultData.Rows[0]["LOGIN_CERT_ID"]);
				}
				if (loginCertId == null)
				{
					DataResult<string> cert = service.NewCertID(LoginUserContext.LoginInfoId, Convert.ToString(ViewState["solutionId"]));
					if (cert.IsSuccess)
					{
						res = cert.ResultData;
					}
					else
					{
						//認証ID発行エラー
						throw new ApplicationException("認証ID発行に失敗しました。");
					}
				}
				else
				{
					int count = service.UpdateCertIDSolutionId(LoginUserContext.LoginInfoId, loginCertId, Convert.ToString(ViewState["solutionId"]));
					res = loginCertId;
				}
			}
			else if (inStr == "%EMPLOYEE_CODE%")
			{
				if (!LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
				{
					res = LoginUserContext.MappingId;
				}
				else
				{
					res = string.Empty;
				}
			}
			else if (inStr == "%SOLUTION_ID%")
			{
				res = Convert.ToString(ViewState["solutionId"]);
			}
			else if (inStr == "%LANGUAGE%")
			{
				res = LoginUserContext.Language;
			}
			else if (inStr == "%OPR_MODE%")
			{
				if (open_flg.Equals("2"))
				{
					res = open_flg;
				}
				else
				{
					res = string.Empty;
				}
			}
			else if (inStr == "%PROGRAM_ID%")
			{
				if (open_flg.Equals("2"))
				{
					res = functionId;
				}
				else
				{
					res = string.Empty;
				}
			}
			else
			{
				res = inStr;
			}

			#endregion
		}
		else
		{
			//引数が空文字のときは空文字を返す
			res = string.Empty;
		}
		return res;
	}

	/// <summary>
	/// ログイン者のロールで有効かチェック
	/// </summary>
	/// <param name="solutionId"></param>
	/// <param name="functionId"></param>
	/// <returns></returns>
	private bool CheckFunctionValid(string solutionId, string functionId)
	{
		bool valid = false;
		foreach (string roleId in LoginUserContext.RoleIds)
		{
			valid = FunctionAuthorizationMst.CheckFunctionAuthorization(roleId, solutionId, functionId);
			if (valid)
				return true;
		}
		return false;
	}

}
