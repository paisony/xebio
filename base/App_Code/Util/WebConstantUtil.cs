// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/11/19 WT)Banno OM障害対応[OM-813]

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Util;

/// <summary>
/// Web層で利用される固定コード等を扱うクラスです。
/// </summary>
public class WebConstantUtil
{
	/// <summary>
	/// ログイン者情報のセッション格納キー
	/// </summary>
	public const string LOGIN_INFO_SESSION_KEY = "SESSION_KEY_LOGIN_USER_INFO";

	/// <summary>
	/// 遷移先ページ情報のセッション格納キー
	/// </summary>
	public const string PAGE_URL_SESSION_KEY = "SESSION_KEY_PAGE_URL";

	/// <summary>
	/// ログイン者のユーザタイプ：一般
	/// </summary>
	public const string LOGIN_USER_TYPE_GENERAL = "0";

	/// <summary>
	/// 基盤管理者ログインＩＤ
	/// </summary>
	public const string LOGIN_ID_WEBSERVE_SMART = "smartmgr";

	/// <summary>
	/// ログイン者のユーザタイプ：システム管理者
	/// </summary>
	public const string LOGIN_USER_TYPE_SYSTEMMANAGER = "1";

	//reserved words
	/// <summary>
	/// ログイン者のユーザタイプ：予約語ログインID
	/// </summary>
	public const string LOGIN_USER_TYPE_RESERVED_LOGIN_ID = "2";

	/// <summary>
	/// ログ画面初期化オフ情報のセッション格納キー
	/// </summary>
	public const string LOGIN_INITIAL_OFF_SESSION_KEY = "LOGIN_INITIAL_OFF";
	/// <summary>
	/// ログイン　横サイズのセッション情報格納キー
	/// </summary>
	public const string LOGIN_WIDTH_SIZE = "LoginWidthSize";
	/// <summary>
	/// ログイン　縦サイズのセッション情報格納キー
	/// </summary>
	public const string LOGIN_HEIGHT_SIZE = "LoginHeightSize";
	/// <summary>
	/// ログイン　画面位置調整のセッション情報格納キー
	/// </summary>
	public const string LOGIN_POSITIONING = "LoginPositioning";
	/// <summary>
	/// ログイン　トップ位置調整サイズのセッション情報格納キー
	/// </summary>
	public const string LOGIN_TOP_POSITION_ASJUSTMENT = "LoginTopPositionAdjustment";
	/// <summary>
	/// ログイン　トップ位置のセッション情報格納キー
	/// </summary>
	public const string LOGIN_POSITION_TOP = "LoginPositionTop";
	/// <summary>
	/// ログイン　トップレフト位置のセッション情報格納キー
	/// </summary>
	public const string LOGIN_POSITION_LEFT = "LoginPositionLeft";
	/// <summary>
	/// ログインシステム名のセッション情報格納キー
	/// </summary>
	public const string LOGIN_SYSTEM_NAME = "LoginSystemName";
	/// <summary>
	/// ログイン時の運用時間チェックキー
	/// </summary>
	public const string LOGIN_OPERATION_CHECK = "LoginOperationCheck";
	/// <summary>
	/// ログイン起動ソリューソンＩＤのセッション情報格納キー
	/// </summary>
	public const string LOGIN_SOLUTION_ID = "LoginSolutionID";
	/// <summary>
	/// ログイン起動機能ＩＤのセッション情報格納キー
	/// </summary>
	public const string LOGIN_FUNCTION_ID = "LoginFunctionID";
	// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update START ---------------
	/// <summary>
	/// ログオフ起動機能ＩＤのセッション情報格納キー
	/// </summary>
	public const string LOGOFF_FUNCTION_ID = "LogoffFunctionID";
	// --------------- 2012/11/19 WT)Banno OM障害対応[OM-813] Update  END ---------------
	/// <summary>
	/// ログオッフ時のウインドウチェックのセッション情報格納キー
	/// </summary>
	public const string LOGOFF_WINDOW_CHECK = "LogoffWindowCheck";
	/// <summary>
	/// ログオッフ時の強制終了のセッション情報格納キー
	/// </summary>
	public const string LOGOFF_FORCE_QUIT = "LogoffForceQuit";
	/// <summary>
	/// メニューのアプリケーションスコープキャシュキー
	/// </summary>
	public const string MENU_CACHE_APPLICATION = "MenuCacheApp";
	/// <summary>
	/// メニューの形式
	/// </summary>
	public const string BASE_MENU_FORMAT = "BaseMenuFormat";
	// --------------- 2016/10/17 FE)Y.Kawabuchi Add START ---------------
	/// <summary>
	/// ログオフ時に強制クローズするファンクションID格納キー
	/// カンマ区切りで複数指定可能
	/// </summary>
	public const string LOGOFF_CLOSING_FUNCTION_IDS = "LogoffClosingFunctionIDs";
	// --------------- 2016/10/17 FE)Y.Kawabuchi Add END ---------------

	#region メニュー
	/// <summary>
	/// リクエストメソッド種別:POST
	/// </summary>
	public const string REQUEST_METHOD_POST = "POST";
	/// <summary>
	/// リクエストメソッド種別:GET
	/// </summary>
	public const string REQUEST_METHOD_GET = "GET";
	/// <summary>
	/// メニュータイプ：システム管理者
	/// </summary>
	public const string FUNCTION_VIEW_ADMIN = "1";
	/// <summary>
	/// メニュータイプ：一般
	/// </summary>
	public const string FUNCTION_VIEW_GENERAL = "0";
	#endregion

	#region 利用者情報
	/// <summary>
	/// 仮パスワードフラグ:オン
	/// </summary>
	public const string TEMP_PASSWORD_FLAG_ON = "1";
	/// <summary>
	/// 仮パスワードフラグ:オフ (本パスワード)
	/// </summary>
	public const string TEMP_PASSWORD_FLAG_OFF = "0";
	#endregion

	#region 運用時間初期化
	/// <summary>
	/// 運用時間初期化
	/// </summary>
	public const String OPERATION_TIME_INIT = "OPERATION_TIME_INIT";
	#endregion
	#region 運用開始時間
	/// <summary>
	/// 運用開始時間
	/// </summary>
	public const String OPERATION_START = "OPERATION_START_";
	#endregion
	#region 運用終了時間
	/// <summary>
	/// 運用終了時間
	/// </summary>
	public const String OPERATION_STOP = "OPERATION_STOP_";
	#endregion

	/// <summary>
	/// コンピュータ名が不明な場合にセットする値
	/// </summary>
	public const string PC_NAME_NOT_FOUND = "PC_NAME_NOT_FOUND";

	/// <summary>
	/// コンピュータ名を取得しないときにセットする値
	/// </summary>
	public const string PC_NAME_NOTHING = "PC_NAME_NOTHING";

	/// <summary>
	/// アプリケーションモードごとに設定されたディレクトリ名
	/// </summary>
	public static string APP_DIRNAME
	{
		get
		{
			return ConstantUtil.APP_DIRNAME;
		}
	}
}
