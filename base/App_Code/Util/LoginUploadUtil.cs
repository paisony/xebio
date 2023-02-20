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
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.Role.VO;
using Com.Fujitsu.SmartBase.Base.LoginUser.VO;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using System.Text;
using System.Text.RegularExpressions;
using RoleUserMapVO = Com.Fujitsu.SmartBase.Base.LoginUser.VO.RoleUserMapVO;
using Com.Fujitsu.SmartBase.Base.Common.Util;
using Fsol.QuiQplus.Common.Check.Charcode;
using Com.Fujitsu.SmartBase.Base.LoginUser;

/// <summary>
/// 利用者アップロード機能に関するユーティリティクラスです。 
/// </summary>
public class LoginUploadUtil
{
	#region コンストラクタ
	/// <summary>
	/// コンストラクタ
	/// </summary>
	public LoginUploadUtil()
	{

	}
	#endregion


	#region 利用者テーブル⇒利用者系VOに変換

	/// <summary>
	///     <para>利用者情報の格納されたテーブルから、LoginUserVOとRoleUserMapVOのリストを作成します。</para>
	///     <para>テーブル内のデータにエラーがある場合は、エラーメッセージを生成します。</para>
	/// </summary>
	/// <param name="dt">
	///     <para>利用者情報の格納されたテーブル。</para>
	///     <para>テーブルは以下のカラムを含む「LOGIN_ID」「PASSWORD」「NAME」「NAME_KANA」「COMPANY_ID」「MAPPING_ID」</para>
	/// </param>
	/// <param name="msg">エラーメッセージがセットされます。</param>
	/// <param name="vos">生成されたLoginUserVOのリストがセットされます。</param>
	/// <param name="maps">生成されたRoleUserMapVOのリストがセットされます。</param>
	/// <returns>DataResultには、以下の終了コードを格納されます。0:エラーなし -1:入力チェックエラー -2:存在チェックエラー</returns>
	public static DataResult<int> ConvertLoginTableToVO(DataTable dt, ref StringBuilder msg, out List<LoginUserVO> vos, out List<RoleUserMapVO> maps)
	{
		// outパラメータの初期値設定
		vos = new List<LoginUserVO>();
		maps = new List<RoleUserMapVO>();

		// 戻り値の設定
		DataResult<int> resData = new DataResult<int>(true);
		msg = new StringBuilder();

		#region ４バイトコードチェック
		if (TableInhibitionCharacterCheck(dt))
		{
			msg.AppendLine("ファイルに無効な文字が含まれています。");
			resData.ResultData = -1;
			resData.IsSuccess = false;
			return resData;
		}
		#endregion

		#region テーブルのチェックとVO生成

		bool hasExistError = false;

		DataTable systemDt = LoginMst.GetAllSystemManagerList();

		int i = 1;
		bool roleValid = true; // ロールが入力チェックに1件でも反すればfalse

		foreach (DataRow row in dt.Rows)
		{
			LoginUserVO vo = new LoginUserVO();
			if (row.Table.Columns.Contains("LOGIN_ID"))
			{
				#region LOGIN_ID
				int loginIdMaxLength = Convert.ToInt32(SystemSettings.InputValidationSettings.Settings["LoginIdMaxLength"].Value);

				vo.LoginId = Convert.ToString(row["LOGIN_ID"]);
				if (string.IsNullOrEmpty(vo.LoginId))
				{
					msg.AppendLine(i + "行目：ログインIDは必須です。");
				}
				if (vo.LoginId.Length > loginIdMaxLength)
				{
					msg.AppendLine(string.Format("{0}行目：{1}桁以上のログインIDは登録できません。", i, loginIdMaxLength + 1));
				}
				if (!Regex.IsMatch(vo.LoginId, "^[a-zA-Z0-9]*$"))
				{
					msg.AppendLine(i + "行目：半角英数字以外のログインIDは登録できません。");
				}
				DataRow[] systemRows = systemDt.Select(string.Format("LOGIN_ID = '{0}'", vo.LoginId));
				if (systemRows.Length > 0)
				{
					msg.AppendLine(i + string.Format("行目：ログインID「{0}」は予約語のため使用できません。", vo.LoginId));
				}
				#endregion
			}
			if (row.Table.Columns.Contains("PASSWORD"))
			{
				#region PASSWORD
				int pwdMinLength = Convert.ToInt32(SystemSettings.SecuritySettings.Settings["PwdMinLength"].Value);
				int pwdMaxLength = Convert.ToInt32(SystemSettings.InputValidationSettings.Settings["PwdMaxLength"].Value);
				string pwdRegexp = SystemSettings.InputValidationSettings.Settings["PwdRegExp"].Value;

				vo.Password = Convert.ToString(row["PASSWORD"]);
				if (string.IsNullOrEmpty(vo.Password))
				{
					msg.AppendLine(i + "行目：パスワードは必須です。");
				}
				if (vo.Password.Length > pwdMaxLength || vo.Password.Length < pwdMinLength)
				{
					msg.AppendLine(string.Format("{0}行目：{1}桁以下または{2}桁以上のパスワードは登録できません。", i, pwdMinLength - 1, pwdMaxLength + 1));
				}
				if (!Regex.IsMatch(vo.Password, pwdRegexp))
				{
					msg.AppendLine(i + "行目：パスワードに使用できない文字が含まれています。");
				}
				#endregion
			}
			if (row.Table.Columns.Contains("NAME"))
			{
				#region NAME
				vo.Name = Convert.ToString(row["NAME"]);
				if (string.IsNullOrEmpty(vo.Name))
				{
					msg.AppendLine(i + "行目：利用者名は必須です。");
				}
				if (vo.Name.Length > 20)
				{
					msg.AppendLine(i + "行目：21文字以上の利用者名は登録できません。");
				}
				if (!Regex.IsMatch(vo.Name, "^[^';*%|’；＊％｜]*$"))
				{
					msg.AppendLine(i + "行目：利用者名は；＊％｜の使用ができません。");
				}
				#endregion
			}
			if (row.Table.Columns.Contains("NAME_KANA"))
			{
				#region NAME_KANA
				vo.Kana = Convert.ToString(row["NAME_KANA"]);
				if (!string.IsNullOrEmpty(vo.Kana))
				{
					if (vo.Kana.Length > 20)
					{
						msg.AppendLine(i + "行目：21文字以上の利用者名カナは登録できません。");
					}
					if (!Regex.IsMatch(vo.Kana, "^[ 　\u30A0-\u30FF]*$"))
					{
						msg.AppendLine(i + "行目：全角カタカナ以外の利用者名カナは登録できません。");
					}
				}
				#endregion
			}
			if (row.Table.Columns.Contains("COMPANY_ID"))
			{
				#region COMPANY_ID
				vo.CompanyID = Convert.ToString(row["COMPANY_ID"]);
				bool companyIdValid = true;

				if (string.IsNullOrEmpty(vo.CompanyID))
				{
					msg.AppendLine(i + "行目：会社IDは必須です。");
					companyIdValid = false;
				}
				if (!Regex.IsMatch(vo.CompanyID, "^[a-zA-Z0-9]*$"))
				{
					msg.AppendLine(i + "行目：半角英数字以外の会社IDは登録できません。");
					companyIdValid = false;
				}
				if (vo.CompanyID.Length > 20)
				{
					msg.AppendLine(i + "行目：21桁以上の会社IDは登録できません。");
					companyIdValid = false;
				}

				if (companyIdValid && CompanyMst.GetCompanyName(vo.CompanyID) == null)
				{
					msg.AppendLine(i + "行目：会社IDは存在しません。");
					hasExistError = true;
				}
				#endregion
			}
			if (row.Table.Columns.Contains("MAPPING_ID"))
			{
				#region MAPPING_ID
				vo.MappingID = Convert.ToString(row["MAPPING_ID"]);
				if (!string.IsNullOrEmpty(vo.MappingID))
				{
					if (vo.MappingID.Length > 20)
					{
						msg.AppendLine(i + "行目：21桁以上のマッピングIDは登録できません。");
					}
					if (!Regex.IsMatch(vo.MappingID, "^[a-zA-Z0-9]*$"))
					{
						msg.AppendLine(i + "行目：半角英数字以外のマッピングIDは登録できません。");
					}
				}
				#endregion
			}

			if (row.Table.Columns.Contains("ROLE_MAPPING"))
			{
				#region ROLE_MAPPING
				string roleMapStr = Convert.ToString(row["ROLE_MAPPING"]);
				if (!string.IsNullOrEmpty(roleMapStr))
				{
					string[] roles = CsvUtil.SplitCSVColumn(roleMapStr);

					int j = 1;
					foreach (string role in roles)
					{
						if (role.Length > 20)
						{
							msg.AppendLine(i + "," + j + "行目：21桁以上のロールIDは登録できません。");
							roleValid = false;
						}
						if (!Regex.IsMatch(role, "^[a-zA-Z0-9]*$"))
						{
							msg.AppendLine(i + "," + j + "行目：半角英数字以外のロールIDは登録できません。");
							roleValid = false;
						}

						RoleUserMapVO map = new RoleUserMapVO();
						map.LoginId = vo.LoginId;
						map.RoleId = role;
						maps.Add(map);

						j++;
					}
				}
				#endregion
			}

			vos.Add(vo);
			++i;
		}
		#endregion

		#region ロールの存在チェック
		LoginUserService ser = new LoginUserService(null);
		if (maps != null && maps.Count > 0 && roleValid == true && ser.IsExistRoleId(maps.ToArray()).IsSuccess)
		{
			msg.AppendLine(i + "行目：ロールIDは存在しません。");
			hasExistError = true;
		}
		#endregion

		#region 戻り値の設定
		if (msg.Length > 0)
		{
			if (hasExistError == false)
			{
				// 入力データが不正
				resData.ResultData = -1;
			}
			else
			{
				// 存在チェックエラー
				resData.ResultData = -2;
			}
		}
		else
		{
			// エラーなし
			resData.ResultData = 0;
		}
		#endregion

		return resData;
	}

	/// <summary>
	/// 指定されたテーブルに、４バイトコードが存在するかどうかをチェックします。
	/// </summary>
	/// <param name="dt">チェック対象のDataTable</param>
	/// <returns>true:４バイトコードを含む false:４バイトコードを含まない</returns>
	private static bool TableInhibitionCharacterCheck(DataTable dt)
	{
		foreach (DataRow row in dt.Rows)
		{
			foreach (DataColumn col in dt.Columns)
			{
				if (InhibitionCharacterCheck.Contains(Convert.ToString(row[col])))
				{
					return true;
				}
			}
		}

		return false;
	}
	#endregion

}
