// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using System.Net;
using System.Collections.Specialized;
using System.Net.Sockets;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using System.Threading;
using Com.Fujitsu.SmartBase.Library.Log;


/// <summary>
///  RequestInfoUtil の概要の説明です 
/// </summary>
public static class RequestInfoUtil
{

	/// <summary>
	/// ログ出力
	/// </summary>
	private static ILogger logger = LogManager.GetLogger();

	#region メソッド

	/// <summary>
	/// IPアドレスとPC名が格納されたユーザ情報voを取得します。
	/// </summary>
	/// <remarks>
	/// 〔IPアドレスの取得方法〕
	/// 環境変数HTTP_X_FORWARDED_FORの値を取得し、存在しなければREMOTE_HOSTの値を取得。
	/// HTTP_X_FORWARDED_FORはプロキシサーバ越しのクライアントのIPアドレスが格納されているが、
	/// Webサーバの設定により出力されない可能性がある。この時はREMOTE_HOSTに格納されているプロキシサーバの
	/// をIPアドレスを出力する。
	/// </remarks>
	/// <param name="serverVariablesCol">HTTP環境変数のNameValueCollection</param>
	/// <exception cref="SocketException">名前解決に失敗</exception>
	/// <returns>クライアントのIPアドレスとPC名が格納されたExLoginUserInfoVO</returns>
	public static ExLoginUserInfoVO GetLoginuserInfoVo(NameValueCollection serverVariablesCol)
	{
		HttpRequest request = HttpContext.Current.Request;
		ExLoginUserInfoVO vo = new ExLoginUserInfoVO();

		if (string.IsNullOrEmpty(serverVariablesCol["HTTP_X_FORWARDED_FOR"]))
		{
			vo.IPAddress = serverVariablesCol["REMOTE_HOST"];
		}
		else
		{
			vo.IPAddress = serverVariablesCol["HTTP_X_FORWARDED_FOR"];
		}

		if (string.IsNullOrEmpty(vo.IPAddress)) throw new ApplicationException("IPAddress取得に失敗しました。");

		if (SystemSettings.EnableHostNameLog)
		{
			//PC名取得
			GetHostName(vo);
		}
		else
		{
			try
			{
				//取得に時間がかかるためコメント
				//vo.PCName = Dns.GetHostEntry(request.UserHostAddress).HostName;
				vo.PCName = vo.IPAddress;
			}
			catch (Exception)
			{
				vo.PCName = "untaken";
			}
		}
		
		//文字数の調整DBに登録できない値を取得した場合はDBに格納可能な文字数に調整する
		if (vo.IPAddress.Length > 15) vo.IPAddress = vo.IPAddress.Remove(15);
		if (vo.PCName.Length > 50) vo.PCName = vo.PCName.Remove(50);

		return vo;
	}

	/// <summary>
	/// IPからホスト名を取得する。
	/// </summary>
	/// <param name="vo">IPAddressのつめられたExLoginUserInfoVO</param>
	private static void GetHostName(ExLoginUserInfoVO vo)
	{
		try
		{
			vo.PCName = Dns.GetHostEntry(vo.IPAddress).HostName;
		}
		catch (SocketException)
		{
			logger.Warn(string.Format("IPアドレス：{0}　コンピュータ名取得に失敗しました。", vo.IPAddress));
			//名前解決に失敗した場合
			vo.PCName = WebConstantUtil.PC_NAME_NOT_FOUND;
		}
	}

	#endregion
}

