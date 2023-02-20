// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

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
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Information;

using Com.Fujitsu.SmartBase.Base.Common.Model.Query;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using Com.Fujitsu.SmartBase.Base.Certification;
using Com.Fujitsu.SmartBase.Base.OperationTimeSettings.VO;

public partial class Access_OperationTimeSettings : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		BusinessMessage.Visible = false;

		//他のページから遷移する場合
		if (!Page.IsPostBack)
		{
			#region 検索
			LoginUserInfoVO infoVO = new LoginUserInfoVO();
			infoVO.LoginId = LoginUserContext.LoginId;
			CertificationService service = new CertificationService();

			QueryObject query = new QueryObject();

			//データ取得
			DataResult<DataTable> res = service.FindOperationTime(query);

			//GridViewにバインド
			OperationTimeList.DataSource = res.ResultData;
			OperationTimeList.DataBind();
			#endregion
		}
	}
	/// <summary>
	/// 画面編集
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		//他のページから遷移する場合
		if (!base.IsPostBack)
		{
			#region 標題セット

			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("OperationTimeSettings");

			//標題をセットする
			Programtitle.Text = resource.GetString("Programtitle");
			Formtitle.Text = resource.GetString("Formtitle");
			ConfirmBtn.Text = resource.GetString("ConfirmBtn");
			BackBtn.Text = resource.GetString("BackBtn");
			StartEndValid.ErrorMessage = resource.GetString("StartEndValid");
			BusinessMessage.Text = resource.GetString("BusinessMessage");

			//列ヘッダー名
			OperationTimeList.Columns[1].HeaderText = resource.GetString("OperationTime_DAYTYPE");
			OperationTimeList.Columns[2].HeaderText = resource.GetString("OperationTime_STARTTIME");
			OperationTimeList.Columns[3].HeaderText = resource.GetString("OperationTime_STOPTIME");

			foreach (GridViewRow row in OperationTimeList.Rows)
			{
				Label startHourLbl = (Label)row.FindControl("StartHour");
				startHourLbl.Text = resource.GetString("StartHour");

				Label startMinuteLbl = (Label)row.FindControl("StartMinute");
				startMinuteLbl.Text = resource.GetString("StartMinute");

				Label stopHourLbl = (Label)row.FindControl("StopHour");
				stopHourLbl.Text = resource.GetString("StopHour");

				Label stopMinuteLbl = (Label)row.FindControl("StopMinute");
				stopMinuteLbl.Text = resource.GetString("StopMinute");
			}

			#endregion
		}

	}

	#region 確定ボタン
	/// <summary>
	/// 確定処理
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ConfirmBtn_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid) return;

		CertificationService service1 = new CertificationService();

		//更新処理
		List<OperationTimeSettingsVO> vos = new List<OperationTimeSettingsVO>();
		foreach (GridViewRow row in OperationTimeList.Rows)
		{
			OperationTimeSettingsVO vo = new OperationTimeSettingsVO();

			vo.DayTYPE = ((Label)row.FindControl("DayTYPEID")).Text;

			string StartTH = ((DropDownList)row.FindControl("StartTimeHourDDL")).Text;
			string StartTM = ((DropDownList)row.FindControl("StartTimeMinuteDDL")).Text;
			vo.STARTTime = string.Concat(StartTH, StartTM);

			string StopTH = ((DropDownList)row.FindControl("StopTimeHourDDL")).Text;
			string StopTM = ((DropDownList)row.FindControl("StopTimeMinuteDDL")).Text;
			vo.STOPTime = string.Concat(StopTH, StopTM);

			vos.Add(vo);
		}

		//更新
		Result res1 = service1.UpdateOperationTime(vos.ToArray());

		//エラー処理
		if (!res1.IsSuccess)
		{
			throw new ApplicationException("システム運用時間の更新に失敗しました。");
		}
		else
		{
			BusinessMessage.Text = "システム運用時間の更新が成功しました。";
			BusinessMessage.Visible = true;
			HttpContext.Current.Application.Lock();
			HttpContext.Current.Application.Remove(WebConstantUtil.OPERATION_TIME_INIT);
			HttpContext.Current.Cache.Insert(WebConstantUtil.OPERATION_TIME_INIT, "init", null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
			HttpContext.Current.Application.UnLock();
		}

		CertificationService service2 = new CertificationService();
		QueryObject query = new QueryObject();
		//データ取得
		DataResult<DataTable> res2 = service2.FindOperationTime(query);
		//エラー処理
		if (!res2.IsSuccess)
		{
			throw new ApplicationException("情報検索に失敗しました。");
		}
		OperationTimeList.DataSource = res2.ResultData;
		OperationTimeList.DataBind();

	}
	#endregion

	#region 戻る
	/// <summary>
	/// 戻るボタン押下
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void BackBtn_Click(object sender, EventArgs e)
	{
		Server.Transfer("AccessMenu.aspx");
	}
	#endregion

	#region 表示
	protected void OperationTimeList_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			#region 曜日表示
			//リソース取得
			FormResource resource = ResourceManager.GetInstance().GetFormResource("OperationTimeSettings");

			string dayType = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "DAY_TYPE"));
			Label DayTypeLbl = (Label)e.Row.FindControl("DayTYPE");
			if (dayType == "0")
			{
				DayTypeLbl.Text = resource.GetString("Sunday");
			}
			else if (dayType == "1")
			{
				DayTypeLbl.Text = resource.GetString("Monday");
			}
			else if (dayType == "2")
			{
				DayTypeLbl.Text = resource.GetString("Tuesday");
			}
			else if (dayType == "3")
			{
				DayTypeLbl.Text = resource.GetString("Wednesday");
			}
			else if (dayType == "4")
			{
				DayTypeLbl.Text = resource.GetString("Thursday");
			}
			else if (dayType == "5")
			{
				DayTypeLbl.Text = resource.GetString("Friday");
			}
			else if (dayType == "6")
			{
				DayTypeLbl.Text = resource.GetString("Saturday");
			}
			else if (dayType == "7")
			{
				DayTypeLbl.Text = resource.GetString("Sunday");
			}
			#endregion

			#region 時間表示
			//開始時間表示
			string startTime = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "START_TIME"));

			if (!string.IsNullOrEmpty(startTime))
			{
				DropDownList StartTimeHourDdl = (DropDownList)(e.Row.FindControl("StartTimeHourDDL"));
				DropDownList StartTimeMinuteDdl = (DropDownList)(e.Row.FindControl("StartTimeMinuteDDL"));
				string StartTimeHour = startTime.Substring(0, 2);
				string StartTimeMinute = startTime.Substring(2, 2);
				StartTimeHourDdl.Text = StartTimeHour;
				StartTimeMinuteDdl.Text = StartTimeMinute;
			}

			//終了時間表示
			string stopTime = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "STOP_TIME"));
			if (!string.IsNullOrEmpty(stopTime))
			{
				DropDownList StopTimeHourDdl = (DropDownList)(e.Row.FindControl("StopTimeHourDDL"));
				DropDownList StopTimeMinuteDdl = (DropDownList)(e.Row.FindControl("StopTimeMinuteDDL"));
				string StopTimeHour = stopTime.Substring(0, 2);
				string StopTimeMinute = stopTime.Substring(2, 2);
				StopTimeHourDdl.Text = StopTimeHour;
				StopTimeMinuteDdl.Text = StopTimeMinute;
			}
			#endregion
		}
	}
	#endregion

	#region 開始時間、終了時間の整合性チェック
	/// <summary>
	/// 開始と終了の有効性チェック
	/// </summary>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void StartEndValid_ServerValidate(object source, ServerValidateEventArgs args)
	{
		#region 開始時間と終了時間の入力状況をstring型に変更

		string TIME = "";
		foreach (GridViewRow row in OperationTimeList.Rows)
		{
			string startTH = ((DropDownList)row.FindControl("StartTimeHourDDL")).Text;
			string startTM = ((DropDownList)row.FindControl("StartTimeMinuteDDL")).Text;
			string T1 = string.Concat(startTH, startTM);
			string stopTH = ((DropDownList)row.FindControl("StopTimeHourDDL")).Text;
			string stopTM = ((DropDownList)row.FindControl("StopTimeMinuteDDL")).Text;
			string T2 = string.Concat(stopTH, stopTM);

			if (T1.Length != 0 || T2.Length != 0)
			{
				//時、分の入力チェック
				if (T1.Length == 2 || T2.Length == 2 || T1 == T2)
				{
					//失敗
					args.IsValid = false;
					return;
				}

				//開始時間、終了時間の入力チェック
				if (T1.Length == 0)
				{
					TIME = TIME + "1";
				}
				else if (T2.Length == 0)
				{
					TIME = TIME + "0";
				}
				else if (System.Convert.ToInt32(T1) > System.Convert.ToInt32(T2))
				{
					TIME = TIME + "1" + "0";
				}
				else
				{
					TIME = TIME + "0" + "1";
				}
			}
		}
		#endregion

		#region string型をチェックする

		if (TIME.Length != 0)
		{
			if (TIME.Length % 2 == 1)
			{
				//失敗
				args.IsValid = false;
				return;
			}
			else
			{
				for (int i = 0; i < TIME.Length; i++)
				{
					if (i == TIME.Length - 1)
					{
						if (TIME.Substring(0, 1) == TIME.Substring(i, 1))
						{
							//失敗
							args.IsValid = false;
							return;
						}
						else
						{
							//成功
							args.IsValid = true;
						}
					}
					else if (TIME.Substring(i, 1) == TIME.Substring((i + 1), 1))
					{
						//失敗
						args.IsValid = false;
						return;
					}
					else
					{
						//成功
						args.IsValid = true;
					}
				}
			}
		}
		#endregion
	}
	#endregion
}
