	// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/03/24 WT)Banno OT1障害対応[QA-0667]
// 2012/11/19 WT)Banno OM障害対応[OM-813]
// 2015/10/05 FSWeb)Y.Tamura パスワード変更障害対応

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
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.Common.Web;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Base.Common.Resource;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Text.RegularExpressions;
using Com.Fujitsu.SmartBase.Base.DataLog;

public partial class Master_PasswordChange : System.Web.UI.Page
{
	#region private変数

	/// <summary>
	/// 画面初期化タイプ
	/// </summary>
	private enum InitType
	{
		/// <summary>
		/// メニュー押下時の遷移(通常のパスワード変更画面)
		/// </summary>
		Normal,
		/// <summary>
		/// ログイン者のパスワードが仮パスワード状態
		/// </summary>
		TempPwd,
		/// <summary>
		/// 本パスワードの有効期限切れ直前
		/// </summary>
		PwdChangePromote,
		/// <summary>
		/// 本パスワード有効期限切れ
		/// </summary>
		PwdExpired
	}

	#endregion

	#region ページロード

	/// <summary>
	/// ページロード
	/// </summary>
	/// <remarks>
	/// ログインIDを基に利用者情報を取得、LoginUserVOに利用者情報をセットして
	/// セッションに格納します。
	/// </remarks>
	/// <exception cref="ApplicationException">利用者情報の取得に失敗</exception>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		BusinessErrorMessage.Visible = false;
		BusinessMessage.Visible = false;

		if (!Page.IsPostBack)
		{
			string loginId = LoginUserContext.LoginId;

			LoginUserInfoVO infoVO = new LoginUserInfoVO();
			infoVO.LoginId = LoginUserContext.LoginId;
			LoginUserService service = new LoginUserService(infoVO);

			LoginUserKey key = new LoginUserKey(LoginUserContext.LoginId);
			DataResult<DataTable> res = service.GetLoginUserData(key);
			//エラー処理
			if (!res.IsSuccess)
			{
				if (res.HasError && res.Errors[0] is DBConcurrencyError)
				{
					// 排他エラー
					MessageResource resource1 = ResourceManager.GetInstance().GetMessageResource();
					BusinessErrorMessage.Text = resource1.GetString(CommonErrorCode.DB_CONCURRENCY_ERROR);
					BusinessErrorMessage.Visible = true;
					return;
				}
				else
				{

					throw new ApplicationException("利用者情報の取得に失敗しました。");
				}
			}

			//利用者情報をセッションに格納
			if (res.ResultData.Rows.Count > 0)
			{
				LoginUserVO vo1 = new LoginUserVO();
				vo1.LoginId = Convert.ToString(res.ResultData.Rows[0]["LOGIN_ID"]);
				vo1.Password = Convert.ToString(res.ResultData.Rows[0]["PASSWORD"]);
				vo1.CompanyID = Convert.ToString(res.ResultData.Rows[0]["COMPANY_ID"]);
				vo1.RowUpdateId = Convert.ToString(res.ResultData.Rows[0]["ROW_UPDATE_ID"]);
				//パスワード更新日時
				vo1.PasswordUpdateDateTime = Convert.ToDateTime(res.ResultData.Rows[0]["PASSWORD_UPDATE_DATETIME"]);
				//仮パスワードフラグ
				vo1.TempPasswordFlag = Convert.ToString(res.ResultData.Rows[0]["TEMP_PASSWORD_FLAG"]);

				SessionManager.SetObject(vo1, "LoginUserVO", "LoginUserEdit");
			}

			SetPasswordValidator();
		}
	}

	#endregion

	/// <summary>
	/// フォームのデータを表示する。
	/// </summary>
	/// <param name="sender">object</param>
	/// <param name="e">System.EventArgs</param>
	protected void RenderForm(object sender, System.EventArgs e)
	{
		//パスワード最小桁数
		string pwdMinLength = Convert.ToString(SystemSettings.SecuritySettings.Settings["PwdMinLength"].Value);
		//パスワード最大桁数セット
		string pwdMaxLength = Convert.ToString(SystemSettings.InputValidationSettings.Settings["PwdMaxLength"].Value);
		//パスワード最小文字種数
		string pwdMinCharType = Convert.ToString(SystemSettings.SecuritySettings.Settings["PwdMinCharType"].Value);

		#region 標題セット
		//リソース取得
		FormResource resource = ResourceManager.GetInstance().GetFormResource("PasswordChange");

		//標題をセットする
		Programtitle.Text = resource.GetString("Programtitle");
		Formtitle.Text = resource.GetString("Formtitle");
		PasswordLbl1.Text = resource.GetString("PasswordLbl1");
		OldPasswordCutline.Text = resource.GetString("OldPasswordCutline");
		PasswordLbl2.Text = resource.GetString("PasswordLbl2");
		PasswordCutline.Text = resource.GetString("PasswordCutline", pwdMinLength, pwdMaxLength);
		PasswordLbl3.Text = resource.GetString("PasswordLbl3");
		PwdStrengthLbl.Text = resource.GetString("PwdStrengthLbl");
		PasswordMatchCutline.Text = resource.GetString("PasswordMatchCutline");
		ConfirmBtn.Text = resource.GetString("ConfirmBtn");
		SuspendBtn.Text = resource.GetString("SuspendBtn");
		MenuBtn.Text = resource.GetString("MenuBtn");
		//エラーメッセージ
		//PasswordBoxInvalidCharValid.Text = resource.GetString("PasswordBoxInvalidCharValid");
		PwdLimitDurationCusVal.ErrorMessage = resource.GetString("PwdLimitDurationCusVal");
		NewPwdReqVal.ErrorMessage = resource.GetString("NewPwdReqVal");
		PwdRegValid.ErrorMessage = resource.GetString("PwdRegValid");
		PwdStrengthCusVal.ErrorMessage = resource.GetString("PwdStrengthCusVal", pwdMinLength, pwdMaxLength, pwdMinCharType);
		//NewPwdInvalidCharValid.Text = resource.GetString("NewPwdInvalidCharValid");
		NewPwdCompVal.ErrorMessage = resource.GetString("NewPwdCompVal");

        // 2015/10/05 FSWeb)Y.Tamura パスワード変更障害対応　Start
        OldPwdReqVal.ErrorMessage = resource.GetString("OldPwdReqVal");
        // 2015/10/05 FSWeb)Y.Tamura パスワード変更障害対応　End

		//起動情報のログ出力
		string solutionId = Request.Params["solutionId"];
		string functionId = Request.Params["functionId"];
		LoginUserInfoVO loginUserInfo = new LoginUserInfoVO();
		DataLogService dataLogService = new DataLogService(loginUserInfo);
		dataLogService.InsertExecDataLog(LoginUserContext.LoginId, solutionId, functionId);

		#endregion

		#region ボタンの表示

		if (SystemSettings.LoginUserSynchroBent == LoginUserConstantUtil.LOGIN_USER_SYNCHRO_IN
				&& !LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
		{
			//ボタンを無効にする
			ConfirmBtn.Enabled = false;
			SuspendBtn.Visible = false;
			MenuBtn.Visible = false;

		}

		//画面遷移時のみ実行
		if (!Page.IsPostBack)
		{
			//パスワードの有効期間チェック
			InitType decidedInitType = this.CheckInitMode();
			//ViewStateに画面初期化モードを格納(確定ボタン押下後に使用)
			ViewState["DecidedInitType"] = decidedInitType;

			if (decidedInitType == InitType.Normal)
			{
				//メニュー押下時の遷移
				SuspendBtn.Visible = false;
				MenuBtn.Visible = false;
			}
			else if (decidedInitType == InitType.TempPwd)
			{
				//仮パスワード時
				string message = "現在ご利用のパスワードは仮パスワードです。本画面で更新したパスワードが正式なパスワードになります。";
				this.InitBusinessMessage(true, message);

				SuspendBtn.Visible = false;
				MenuBtn.Visible = false;
			}
			else if (decidedInitType == InitType.PwdChangePromote)
			{
				//本パスワードの有効期限切れ直前

				//パスワード有効期限をViewStateから取得
				LoginUserVO vo = GetLoginUserVOFromSession();
				DateTime dt = PasswordCheckUtil.GetPasswordExpires(vo.PasswordUpdateDateTime);
				string message = "パスワード有効期限が近づいています。パスワード有効期限：" + dt.ToString("yyyy年MM月dd日");
				this.InitBusinessMessage(true, message);

				SuspendBtn.Visible = true;
				MenuBtn.Visible = false;
			}
			else if (decidedInitType == InitType.PwdExpired)
			{
				//本パスワード有効期限切れ
				string message = "パスワードの有効期間が過ぎました。パスワードを更新してください。";
				this.InitBusinessMessage(true, message);

				SuspendBtn.Visible = false;
				MenuBtn.Visible = false;
				//MenuBtn.Enabled = false;
			}

		}

		#endregion
	}

	#region ボタン押下イベント

	/// <summary>
	/// 確定ボタン押下
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ConfirmBtn_Click(object sender, EventArgs e)
	{
		#region 前処理
		/* セッションから利用者情報を取得する。
         * 取得でき名場合は排他エラーとする。
         */
		if (!Page.IsValid) return;
		//セッションから利用者情報を取得
		LoginUserVO vo = this.GetLoginUserVOFromSession();
		#endregion

		//パスワードを大文字化
		bool pwdUpperType = false;
		try
		{
			pwdUpperType = Convert.ToBoolean(SystemSettings.SecuritySettings.Settings["PwdUpperType"].Value);
		}
		catch (Exception)
		{
			pwdUpperType = false;
		}

		//パスワード履歴の保存数の取得
		vo.Password = NewPassword1Box.Text;
		string oldpassword = PasswordBox.Text;
		if (pwdUpperType && !LoginUserContext.LoginId.Equals("smartmgr"))
		{
			// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update START ---------------
			vo.Password = NewPassword1Box.Text;
			oldpassword = PasswordBox.Text;
			// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update  END ---------------
		}

		LoginUserInfoVO infoVO = new LoginUserInfoVO();
		infoVO.LoginId = LoginUserContext.LoginId;
		LoginUserService service = new LoginUserService(infoVO);
		Result res = service.UpdatePasswordLoginUser(vo, oldpassword);


		//エラー処理
		if (!res.IsSuccess)
		{
			if (res.HasError)
			{
				try
				{
					// 排他エラー.ビジネスロジックエラー
					MessageResource resource = ResourceManager.GetInstance().GetMessageResource();
					BusinessErrorMessage.Text = resource.GetString(res.Errors[0].ErrorCode);
					BusinessErrorMessage.Visible = true;
					if (res.Errors[0].Exception.Message != null)
					{
						BusinessErrorMessage.Text = res.Errors[0].Exception.Message;
					}
				}
				catch (Exception)
				{
				}
				return;
			}
			else
			{
				throw new ApplicationException("パスワード変更に失敗しました。");
			}

		}
		else
		{
			BusinessMessage.Text = "パスワードを更新しました。";
			BusinessMessage.Visible = true;
			ConfirmBtn.Enabled = false;
			//ボタン表示の制御
			this.ChangeBtnVisiblyAfterPwdUpdated();
			return;
		}

	}

	/// <summary>
	/// 変更しないボタン押下
	/// </summary>
	/// <remarks>
	/// パスワード有効期限切れ直前に表示されます。
	/// </remarks>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void SuspendBtn_Click(object sender, EventArgs e)
	{
		if (SessionManager.GetObject("SSOParams", "SSO") == null)
			Response.Redirect("../Common/Main.aspx");
		else
			//機能遷移ページへ遷移
			Response.Redirect("../Common/Main.aspx");
	}

	/// <summary>
	/// メニューへボタン押下
	/// </summary>
	/// <remarks>
	/// パスワード更新後に表示されます。
	/// </remarks>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void MenuBtn_Click(object sender, EventArgs e)
	{
		if (SessionManager.GetObject("SSOParams", "SSO") == null)
			Response.Redirect("../Common/Main.aspx");
		else
			//機能遷移ページへ遷移
			Response.Redirect("../Common/Main.aspx");
	}

	#endregion


	#region バリデータ

	/// <summary>
	/// パスワード更新不可期間を検証します。
	/// </summary>
	/// <remarks>
	/// 検証内容：
	/// ・利用者のパスワードが仮パスワードの時は常に検証成功とする。
	/// ・本パスワード時は設定ファイルから「パスワード変更禁止期間」を取得、
	/// 　パスワード変更禁止期間が0の時は常に検証成功とする。
	/// ・パスワード更新禁止時刻(パスワード変更禁止期間 + パスワード更新日時)と現在時刻の比較
	/// 　・現在時刻がパスワード更新禁止時刻よりも未来の場合（同時刻を含む）は検証成功。
	/// 　・現在時刻がパスワード更新禁止時刻よりもの過去場合は検証失敗。
	/// 注）パスワード変更禁止期間はパスワードの即時変更を防止する仕組み。
	/// </remarks>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void PwdLimitDurationCusVal_ServerValidate(object source, ServerValidateEventArgs args)
	{
		if (!Page.IsValid) return;

		// 仮パスワードは常に検証成功
		LoginUserVO vo = (LoginUserVO)SessionManager.GetObject("LoginUserVO", "LoginUserEdit");
		if (vo.TempPasswordFlag == ConstantUtil.TEMP_PASSWORD_FLAG_ON)
		{
			args.IsValid = true;
			return;
		}

		// 有効期限切れパスワードは常に検証成功
		InitType decidedInitType = (InitType)ViewState["DecidedInitType"];
		if (decidedInitType == InitType.PwdExpired)
		{
			args.IsValid = true;
			return;
		}

		//パスワード変更不可期間の取得
		int limitHour = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdChangeLimitDuration"].Value);
		if (limitHour == 0)
		{
			//パスワード変更不可期間が0の場合(変更不可期間無し)は検証成功。
			args.IsValid = true;
			return;
		}
		TimeSpan limitDuration = new TimeSpan(limitHour, 0, 0);

		//パスワード更新日時
		DateTime pwdUpdateDT = vo.PasswordUpdateDateTime;
		//検証する時間(パスワード更新日時+パスワード変更不可期間)
		DateTime validateDT = pwdUpdateDT.Add(limitDuration);
		//現在時刻
		DateTime dateTimeNow = DateTime.Now;

		//検証する時間と現在時刻との比較し、現在時刻の方が未来、
		//または両者が同じ時刻の場合は検証成功
		if (dateTimeNow >= validateDT)
		{
			args.IsValid = true;
		}
		else
		{
			args.IsValid = false;
		}

		return;
	}


	/// <summary>
	/// パスワード強度検証
	/// </summary>
	/// <remarks>
	/// パスワード強度チェックを行います。
	/// </remarks>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void PwdStrengthCusVal_ServerValidate(object source, ServerValidateEventArgs args)
	{
		string pwdStr = NewPassword1Box.Text;

		//最小パスワード桁数
		int pwdMinLength = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdMinLength"].Value);
		if (pwdStr.Length >= pwdMinLength)
			args.IsValid = true;
		else
		{
			args.IsValid = false;
			return;
		}

		//パスワード最小文字種数
		int pwdMinCharType = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdMinCharType"].Value);

		int charCount = 0;
		if (Regex.IsMatch(pwdStr, "[0-9]"))
			++charCount;
		// --------------- 2012/03/24 WT)Banno OT障害対応[QA-667] Update Start ---------------
		if (Regex.IsMatch(pwdStr, "[A-Z]"))
		{
			++charCount;
		}
		else
		{
			if (Regex.IsMatch(pwdStr, "[a-z]"))
			{
				++charCount;
			}
		}
		//if (Regex.IsMatch(pwdStr, "[^0-9a-zA-Z]"))
		//	++charCount;
		// --------------- 2012/03/24 WT)Banno OT障害対応[QA-667] Update  END ---------------

		if (charCount >= pwdMinCharType)
			args.IsValid = args.IsValid && true;
		else
			args.IsValid = false;
	}

	#endregion

	#region privateメソッド

	/// <summary>
	/// パスワードボックスの制限を設定値からセットする。
	/// </summary>
	private void SetPasswordValidator()
	{
		//パスワード最大桁数セット
		int pwdMaxLength = Convert.ToInt32(SystemSettings.InputValidationSettings.Settings["PwdMaxLength"].Value);
		NewPassword1Box.MaxLength = pwdMaxLength;

		//パスワード有効文字種（正規表現）
		PwdRegValid.ValidationExpression = SystemSettings.InputValidationSettings.Settings["PwdRegExp"].Value;

		//パスワード最小桁数
		int pwdMinLength = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdMinLength"].Value);
		if (pwdMinLength == 0)
			NewPwdReqVal.Enabled = false;
	}

	/// <summary>
	/// BusinessMessageコントロールを初期化します。
	/// </summary>
	/// <param name="visible">コントロールの表示制御 true:表示 false:非表示</param>
	/// <param name="message">BusinessMessageに表示するメッセージ</param>
	/// <returns></returns>
	private void InitBusinessMessage(bool visible, string message)
	{
		BusinessMessage.Text = message;
		BusinessMessage.Visible = visible;
	}

	/// <summary>
	/// 画面初期化のための遷移元とログイン者の状態チェック
	/// </summary>
	/// <remarks>
	/// ボタンコントロールの表示／非表示制御のためのチェックをします。
	/// </remarks>
	/// <exception cref="ApplicationException">
	/// ・遷移元のフォームIDの取得に失敗
	/// ・セッションから利用者の取得に失敗
	/// </exception>
	/// <returns>
	/// 戻り値
	/// 1:メニュー押下時の遷移(InitType.Normal)
	/// 2:ログイン者のパスワードが仮パスワード状態(InitType.TempPwd)
	/// 3:本パスワードの有効期限切れ直前(InitType.PwdChangePromote)
	/// 4:本パスワード有効期限切れ(InitType.PwdExpired)
	/// </returns>
	private InitType CheckInitMode()
	{
		//遷移元ファイル名の取得
		string formid = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1].ToLower();

		if (formid == "pagetransfer.aspx")
		{
			//メニューからの遷移
			return InitType.Normal;
		}
		else if (formid == "pwdcompulsorychange.html" || formid == "login.aspx")
		{
			//ログイン画面からの遷移

			//セッションから利用者VOの取得
			LoginUserVO vo = this.GetLoginUserVOFromSession();
			if (vo.TempPasswordFlag == WebConstantUtil.TEMP_PASSWORD_FLAG_ON)
			{
				return InitType.TempPwd;
			}

			//パスワードの有効期間チェック
			switch (PasswordCheckUtil.CheckPwdValid(vo.PasswordUpdateDateTime))
			{
				case 1:
					//パスワード有効期間内(パスワード変更警告期間を除く)
					return InitType.Normal;
				case 2:
					//パスワード警告期間
					return InitType.PwdChangePromote;
				case 3:
					//パスワード無効期間
					return InitType.PwdExpired;
				default:
					throw new ApplicationException("パスワード変更画面:パスワード更新日時の取得に失敗しました。");
			}

		}
		else
		{
			throw new ApplicationException("パスワード変更画面:遷移元フォームID取得に失敗しました。");
		}
	}

	/// <summary>
	/// 利用者情報をセッションから取得します。
	/// </summary>
	/// <exception cref="ApplicationException">
	/// セッションに利用者情報のVOが保存されていない場合
	/// </exception>
	/// <returns>利用者情報のLoginUserVO</returns>
	private LoginUserVO GetLoginUserVOFromSession()
	{
		LoginUserVO vo = (LoginUserVO)SessionManager.GetObject("LoginUserVO", "LoginUserEdit");
		if (vo == null) throw new ApplicationException("パスワード変更画面:利用者情報の取得に失敗しました。");
		return vo;
	}

	///// <summary>
	///// パスワードの有効期限をチェックします。
	///// </summary>
	///// <param name="pwdUpdateDT">パスワード更新日時</param>
	///// <exception cref="ApplicationException">
	///// ・設定ファイルから取得したパスワード有効期間がパスワード変更事前通知日と同値か小さい時
	///// ・利用者のパスワード更新日時が不正(更新日時が現在時刻よりも未来の場合等)
	///// </exception>
	///// <returns>
	///// 戻り値
	///// 1:パスワード有効期間内(パスワード変更警告期間を除く)
	///// 2:パスワード変更警告期間
	///// 3:パスワード無効期間
	///// </returns>
	//private string CheckPwdValid(DateTime pwdUpdateDT)
	//{
	//    //パスワード有効期間（日）の取得
	//    int validDays = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdValidDuration"].Value);
	//    //パスワード変更事前通知日（日）の取得
	//    int promoteDays = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdChangePromoteDuration"].Value);
	//    if (promoteDays >= validDays) throw new ApplicationException("設定ファイルの設定値が不正です。“パスワード有効期間”は“パスワード有効期限通知日”よりも大きい値を設定してください。");

	//    //有効期間
	//    TimeSpan validSpan = new TimeSpan(validDays, 0, 0, 0);
	//    //警告期間（有効期限日から逆算するため、マイナス期間）
	//    TimeSpan promoteSpan = new TimeSpan(-promoteDays, 0, 0, 0);

	//    //有効期限日
	//    DateTime expiresDT = pwdUpdateDT.Add(validSpan);
	//    ViewState["ExpiresDataTime"] = expiresDT;
	//    //警告開始日
	//    DateTime promoteStartDT = expiresDT.Add(promoteSpan);
	//    //現在時刻を取得
	//    DateTime nowDT = DateTime.Now;

	//    if (nowDT.CompareTo(pwdUpdateDT) >= 0 && nowDT.CompareTo(promoteStartDT) == -1)
	//    {
	//        //パスワード有効期間内(パスワード変更警告期間を除く)
	//        return "1";
	//    }
	//    else if (nowDT.CompareTo(promoteStartDT) >= 0 && nowDT.CompareTo(expiresDT) <= 0)
	//    {
	//        //パスワード警告期間内
	//        return "2";
	//    }else if (nowDT.CompareTo(expiresDT) == 1) 
	//    {
	//        //3:パスワード無効期間
	//        return "3";
	//    }else {
	//        //どの期間にも属さない
	//        throw new ApplicationException("ログイン者のパスワード更新日時が不正です。");
	//    }

	//}

	/// <summary>
	/// 画面遷移が発生するボタンの表示を制御します。
	/// </summary>
	/// <remarks>
	/// 変更しないボタン，メニューボタンの表示制御
	/// </remarks>
	private void ChangeBtnVisiblyAfterPwdUpdated()
	{
		//画面初期化タイプをViewStateから取得
		InitType decidedInitType = (InitType)ViewState["DecidedInitType"];
		switch (decidedInitType)
		{
			case (InitType.Normal):
				break;
			case (InitType.TempPwd):
				MenuBtn.Visible = true;
				break;
			case (InitType.PwdChangePromote):
				SuspendBtn.Visible = false;
				MenuBtn.Visible = true;
				break;
			case (InitType.PwdExpired):
				MenuBtn.Visible = true;
				break;
			default:
				break;
		}



	}

	#endregion


}
