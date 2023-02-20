using Common.IntegrationMD.Constant;
using Common.Standard.Constant;
using Common.Standard.Login;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.SessionState;

public partial class advoutput_Default : System.Web.UI.Page
{
    private const string KEY_PGLIST = "KEY_PGLIST";

    protected void Page_Load(object sender, EventArgs e)
    {
        // PT用ログイン情報
        HttpSessionState httpSession = HttpContext.Current.Session;
		// TODO:ソリューションIDを仮設定
		HttpContext.Current.Application[MdSessionKeyConstant.SOLUTION_ID] = "BO";
        LoginInfoVO loginInfo = new LoginInfoVO
        {
            LoginId = "0000001",
            LoginInfoId = "0",
            User_Type = "0",
			TtsCd = "2999991",						// 担当者コード
			TtsMei = "富士通担当者（Ｘシステム",	// 担当者名
            CertId = "@",
            SolutionId = (String)HttpContext.Current.Application[MdSessionKeyConstant.SOLUTION_ID]
			,CopCd = "1"						// 会社コード(1:X 2:V)
			,TnpCd = "0260"					// 店舗コード
			,Skm = 0						// 職制
			,Kengenkbn = 1					// 権限(1:本部、2:店長、3:一般、4:アルバイト)
			,Hanyohanbaiin_flg = 0			// 汎用販売員フラグ
			,Tnprksmes = "ＳＳ仙台長町"					// 所属店舗名
			,Tenpokana_nm = "ｾﾝﾀﾞｲﾅｶﾞﾏﾁ"				// 所属店舗カナ名
			,Tenposeisiki_nm = "ＳＳ仙台長町" // 所属店舗正式名
      ,Tenpokeitai_kb = 1				// 店舗形態区分(0:本部　1:DC　2:LC　3:店舗 4:積送店)
			,Tenpogyotai_kb = "0001"		// 店舗業態コード
			,Area_cd = "0001"				// エリアコード
			,Area_seisiki_nm = "関東"		// エリア正式名称
			// TODO:設定追加
			,ClientIp = "123.456.789.012"				// クライアントIPアドレス
			,PcName = Environment.MachineName			// コンピュータ名
        };
        httpSession[SessionKeyConstant.LOGIN_USER_INFO] = loginInfo;
		
        var list = new List<MenuVo>();
        var targetDirectory = Server.MapPath("./");
        var directories = Directory.GetDirectories(targetDirectory, "*p01", SearchOption.TopDirectoryOnly);
        foreach (var direcotry in directories)
        {
            var pgId = direcotry.Remove(0, targetDirectory.Length);
            var pgName = DummyMenu.ProgramDictionary.ContainsKey(pgId) ? DummyMenu.ProgramDictionary[pgId] : string.Empty;
            list.Add(new MenuVo { PgId = pgId, PgName = pgName });
        }

        RepeaterInfo.DataSource = list;
        RepeaterInfo.DataBind();
    }
	protected void BtnSet_Click ( object sender, EventArgs e )
	{
        HttpSessionState httpSession = HttpContext.Current.Session;
		LoginInfoVO loginInfo = (LoginInfoVO)httpSession[SessionKeyConstant.LOGIN_USER_INFO];
		loginInfo.Kengenkbn = Convert.ToDecimal(kengen.Value); // 権限(1:本部、2:店長、3:一般、4:アルバイト)
		httpSession[SessionKeyConstant.LOGIN_USER_INFO] = loginInfo;
	}

    protected class MenuVo
    {
        public string PgId { get; set; }
        public string PgName { get; set; }
    }
}