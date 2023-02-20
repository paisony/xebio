using Common.Standard.Attribute;
using Common.Standard.Base;
using Common.Standard.Login;
using System;

namespace Common.Standard.Page
{
	/// <summary>
	/// BOシステム共通のユーザコントロールのコードビハインドクラスです。
	/// </summary>
	public partial class boCommonControl : StandardBaseUserControl
	{
		#region メソッド
		/// <summary>
		/// ページロード
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{

			#region ログイン情報を画面隠し項目に設定

			// ログイン情報取得
			LoginInfoVO loginInfo = LoginInfoUtil.GetLoginInfo();

			// ログイン情報 会社コード
			logininfo_copcd.Value = loginInfo.CopCd;
			// ログイン情報 担当者コード
			logininfo_ttscd.Value = loginInfo.TtsCd;
			// ログイン情報 担当者名
			logininfo_ttsmei.Value = loginInfo.TtsMei;
			// ログイン情報 所属店舗コード
			logininfo_tnpcd.Value = loginInfo.TnpCd;
			// ログイン情報 職制
			logininfo_skm.Value = loginInfo.Skm.ToString();
			// ログイン情報 権限
			logininfo_kengenkbn.Value = loginInfo.Kengenkbn.ToString();
			// ログイン情報 汎用販売員フラグ
			logininfo_hanyohanbaiin_flg.Value = loginInfo.Hanyohanbaiin_flg.ToString();
			// ログイン情報 所属店舗名
			logininfo_tnprksmes.Value = loginInfo.Tnprksmes;
			// ログイン情報 所属店舗カナ名
			logininfo_tenpokana_nm.Value = loginInfo.Tenpokana_nm;
			// ログイン情報 所属店舗正式名
			logininfo_tenposeisiki_nm.Value = loginInfo.Tenposeisiki_nm;
			// ログイン情報 店舗形態区分
			logininfo_tenpokeitai_kb.Value = loginInfo.Tenpokeitai_kb.ToString();
			// ログイン情報 店舗業態コード
			logininfo_tenpogyotai_kb.Value = loginInfo.Tenpogyotai_kb;
			// ログイン情報 エリアコード
			logininfo_area_cd.Value = loginInfo.Area_cd;
			// ログイン情報 エリア正式名称
			logininfo_area_seisiki_nm.Value = loginInfo.Area_seisiki_nm;

			#endregion

		}
		#endregion
	}
}