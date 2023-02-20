// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Com.Fujitsu.SmartBase.Base.Common.Config;


/// <summary>
/// パスワードチェッククラス
/// </summary>
/// <remarks>
/// パスワード強度やパスワード有効期間をチェックするクラスです。
/// </remarks>
public class PasswordCheckUtil
{
    #region コンストラクタ

    private PasswordCheckUtil()
    {
    }

    #endregion

    #region メソッド

    ///// <summary>
    ///// パスワードの強度チェックを行います。
    ///// </summary>
    ///// <param name="pwd">パスワード強度チェックを行うパスワード</param>
    ///// <returns>
    ///// 0 パスワードの文字長が0の時 
    ///// 1 パスワードにパスワード用文字種以外の文字が使用されている
    ///// 2 (強度 弱)パスワードの桁数が8～10桁以外の時または、桁数に関係なく1種類の文字種が使用されている時
    ///// 3 (強度 中)パスワード桁数が8～10桁、かつ2種類の文字種が使用されている
    ///// 4 (強度 強)パスワード桁数が8～10桁、かつ3種類の文字種が使用されている
    ///// </returns>
    //public static int PwdStrengthCheck(string pwd)
    //{
    //    //文字が入力されているか
    //    if (pwd.Length == 0) return 0;

    //    //不正な文字のチェック
    //    Regex invalidCharRegEx = new Regex("[^0-9a-zA-Z]");
    //    if (invalidCharRegEx.IsMatch(pwd)) return 1;

    //    //パスワード文字長のチェック(8桁～10桁以外は不正とする)
    //    //弱(パスワード文字長不足)
    //    if (pwd.Length <= 7 || pwd.Length >= 11) return 2;

    //    //パスワードに含まれる文字種のカウント
    //    int charMatchCount = 0;

    //    Regex numberRegEx = new Regex("[0-9]");
    //    if (numberRegEx.IsMatch(pwd)) ++charMatchCount;

    //    Regex smallLetterRegEx = new Regex("[a-z]");
    //    if (smallLetterRegEx.IsMatch(pwd)) ++charMatchCount;

    //    Regex bigLetterRegEx = new Regex("[A-Z]");
    //    if (bigLetterRegEx.IsMatch(pwd)) ++charMatchCount;

    //    //パスワード強度「弱」の返り値が2から始まるので文字種カウントに1を加算する
    //    return ++charMatchCount;
    //}

    /// <summary>
    /// パスワードの有効期限をチェックします。
    /// </summary>
    /// <remarks>
    /// 設定ファイルからパスワード有効期間とパスワード変更事前通知日を取得、
    /// パスワード更新日時と比較して現在のパスワードが有効であるかをチェックします。
    /// </remarks>
    /// <param name="pwdUpdateDT">パスワード更新日時</param>
    /// <exception cref="ApplicationException">
    /// ・設定ファイルから取得したパスワード有効期間がパスワード変更事前通知日と同値か小さい時
    /// ・利用者のパスワード更新日時が不正(更新日時が現在時刻よりも未来の場合など時間の不整合)
    /// </exception>
    /// <returns>
    /// 戻り値
    /// 1:パスワード有効期間内(パスワード変更警告期間を除く)
    /// 2:パスワード変更警告期間
    /// 3:パスワード無効期間
    /// </returns>
    public static int CheckPwdValid(DateTime pwdUpdateDT)
    {
        //パスワード有効期間（日）の取得
        int validDays = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdValidDuration"].Value);
        //パスワード変更事前通知日（日）の取得
        int promoteDays = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdChangePromoteDuration"].Value);
        //if (promoteDays >= validDays) throw new ApplicationException("設定ファイルの設定値が不正です。“パスワード有効期間”は“パスワード有効期限通知日”よりも大きい値を設定してください。");

        //有効期間
        TimeSpan validSpan = new TimeSpan(validDays, 0, 0, 0);
        //警告期間（有効期限日から逆算するため、マイナス期間）
        TimeSpan promoteSpan = new TimeSpan(-promoteDays, 0, 0, 0);

        //有効期限日
        DateTime expiresDT = pwdUpdateDT.Add(validSpan);
        //警告開始日
        DateTime promoteStartDT = expiresDT.Add(promoteSpan);
        //現在時刻を取得
        DateTime nowDT = DateTime.Now;

        if (nowDT >= expiresDT)
        {
            //パスワード無効期間
            return 3;
        }
        else if (nowDT >= promoteStartDT)
        {
            //パスワード警告期間内
            return 2;
        }
        else
        {
            //パスワード有効期間内(パスワード変更警告期間を除く)
            return 1;
        }
    }

    /// <summary>
    /// パスワードの有効期限日時を取得します。
    /// </summary>
    /// <param name="pwdUpdateDT">パスワード更新日時</param>
    /// <returns>パスワードの有効期限日時</returns>
    public static DateTime GetPasswordExpires(DateTime pwdUpdateDT)
    {
        //パスワード有効期間（日）の取得
        int validDays = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdValidDuration"].Value);
        //有効期間
        TimeSpan validSpan = new TimeSpan(validDays, 0, 0, 0);
        //有効期限日
        return pwdUpdateDT.Add(validSpan);
    }


    #endregion
}
