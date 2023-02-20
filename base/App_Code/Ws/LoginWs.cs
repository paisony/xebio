// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using System.Data;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using System.Text;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Common.Model;
using Com.Fujitsu.SmartBase.Base.LoginUser;
using Com.Fujitsu.SmartBase.Library.Log;


/// <summary>
/// LoginWs の概要の説明です
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class LoginWs : System.Web.Services.WebService
{
    /// <summary>
    /// ログ出力
    /// </summary>
    private static ILogger logger = LogManager.GetLogger();

    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public LoginWs()
    {
    }
    #endregion

    #region 利用者の追加更新
    /// <summary>
    /// <para>共通機能の1～n件の利用者情報を追加登録します（削除は行いません）。</para>
    /// <para>利用者IDが存在しない場合は新規登録を、すでに存在する場合は「社員コード」「ログイン名」「ログイン名カナ」のみ更新します（その他のデータは何が入力されていても無視する）。複数行アップロードする場合、エラー行があると全ての行は登録されません。</para>
    /// <para> APIが実行された時刻は、共通機能のログに出力されます。</para>
    /// </summary>
    /// <param name="loginUserUploadVoList">更新対象の利用者情報を格納したVOの配列</param>
    /// <remarks>
    /// <para>このAPIは非公開APIです。バージョンアップにより仕様が変わった際に、可能性があり、下位互換が保たれない場合があります。</para>
    /// <para>このAPI（または利用者アップロード機能）が同時に実行された場合、排他制御は行われません。後に実行したAPIの情報で上書きされ、上書きされたことも検知されません（後勝ちルール）。</para>
    /// <para>このAPIを使用するソリューションは、内部統制対応のため、誰が利用者を登録したのかをトレースできるようになっている必要があります。トレースすることができないソリューションでは、このAPIを使用しないで下さい。</para>
    /// </remarks>
    /// <returns>
    ///     <para>終了コードを返します。</para>
    ///     <para>ただし、終了コードは、数値が大きいものが優先して返されます。</para>
    ///     <para>例えば、「入力データが不正(-1)」かつ「存在チェック違反(-2)」が発生した場合は、「-1」を返します。/para>
    ///     <para>   0：追加・更新成功</para>
    ///     <para>  -1：入力データが不正（桁数、データ型の不整合。ただしログインIDおよびパスワードの桁数は、設定ファイルで指定した条件でチェックを行うものとする）</para>
    ///     <para>  -2：存在チェック違反（会社ID、ロールIDが存在しない）</para>
    ///     <para>  -3：その他システムエラー</para>
    /// </returns>
    [WebMethod]
    public int InsertUpdateLoginUser(LoginUserUploadVO[] loginUserUploadVoList)
    {
        int retCode = 0;
        StringBuilder msg = new StringBuilder();

        try
        {
            // 入力チェック＆VO生成
            List<LoginUserVO> vos;
            List<RoleUserMapVO> maps;
            
            // 利用者VOを、利用者DataTableに変換
            DataTable dt = GetNewLoginUserUploadTable(loginUserUploadVoList);

            // 利用者DataTableを、LoginUserVO、RoleUserMapVOのリストに変換
            DataResult<int> res = LoginUploadUtil.ConvertLoginTableToVO(dt, ref msg, out vos, out maps);
            retCode = res.ResultData;

            if (retCode == 0)
            {
                LoginUserInfoVO loginInfo = new LoginUserInfoVO();
                loginInfo.LoginId = ConstantUtil.API_EXECUTE_LOGIN_ID;
                LoginUserService ser = new LoginUserService(loginInfo);
                Result upRes = ser.InsertUpdateLoginUser(vos.ToArray(), maps.ToArray());

                if (!upRes.IsSuccess)
                {
                    retCode = -3;
                }

            }
        }
        catch (Exception ex)
        {
            retCode = -3;
            logger.Error("利用者情報更新APIの実行に失敗しました。　終了コード：" + retCode, ex);
        }

        if (retCode != 0 && retCode != 3)
        {
            logger.Error("利用者情報更新APIの実行に失敗しました。　終了コード：" + retCode + " " + msg.ToString());
        }

        return retCode;
    }

    #region GetNewLoginUserUploadTable
    /// <summary>
    /// 利用者情報を格納するためのテーブルを生成して返します。
    /// </summary>
    /// <param name="loginUserUploadVoList">更新対象の利用者情報を格納したVOの配列</param>
    /// <returns></returns>
    private static DataTable GetNewLoginUserUploadTable(LoginUserUploadVO[] loginUserUploadVoList)
    {
        // TataTableを作成
        DataTable tbl = new DataTable();

        tbl.Columns.Add("LOGIN_ID");
        tbl.Columns.Add("PASSWORD");
        tbl.Columns.Add("NAME");
        tbl.Columns.Add("NAME_KANA");
        tbl.Columns.Add("COMPANY_ID");
        tbl.Columns.Add("MAPPING_ID");
        tbl.Columns.Add("ROLE_MAPPING");

        foreach (LoginUserUploadVO vo in loginUserUploadVoList)
        {
            DataRow row = tbl.NewRow();

            row["LOGIN_ID"] = vo.LoginId;
            row["PASSWORD"] = vo.Password;
            row["NAME"] = vo.Name;
            row["NAME_KANA"] = vo.NameKana;
            row["COMPANY_ID"] = vo.CompanyID;
            row["MAPPING_ID"] = vo.MappingID;
            row["ROLE_MAPPING"] = CsvUtil.ConvertCSV(vo.RoleMapping);

            tbl.Rows.Add(row);
        }

        return tbl;
    }
    #endregion

    #endregion

}

