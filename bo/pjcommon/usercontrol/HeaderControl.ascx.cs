using System;

using Common.Advanced.Formvo;
using Common.Advanced.Web.Util;

using Common.Standard.Attribute;
using Common.Standard.Base;
using Common.Standard.Message;
using Common.Standard.Resource;
using Common.Standard.Session;
using Common.Standard.Util;
using Common.Standard.Constant;
using Common.Standard.Login;
using System.Web.UI.WebControls;
using Common.IntegrationMD.Service;
using Common.IntegrationMD.Constant;
using Common.Advanced.Model.Context;
using System.Text;
using Common.Standard.Model.Data;
using Common.Advanced.Web.Context;
using Common.IntegrationMD.Util;
using System.Collections.Generic;
using Common.Standard.Model.Context.DataSource;
using System.Configuration;
using Common.Advanced.Model.Data;
using System.Collections;
using System.Web;

namespace Common.Standard.Page
{
	/// <summary>
	/// ヘッダー部表示用のユーザコントロールのコードビハインドクラスです。
	/// </summary>
	public partial class HeaderControl : StandardBaseUserControl
	{
		#region フィールド
		protected string mess;
		/// <summary>
		/// プログラムID
		/// </summary>
		private string _pgId;
		/// <summary>
		/// プログラム名
		/// </summary>
		private string _pgName;
		/// <summary>
		/// フォームID
		/// </summary>
		private string _formId;
		/// <summary>
		/// フォーム名
		/// </summary>
		private string _formName;
		/// <summary>
		/// 閉じるボタン
		/// </summary>
		private string _clsBtn;
		#endregion

		#region プロパティ
		/// <summary>
		/// プログラムIDを設定します。
		/// </summary>
		public string PgId
		{
			set { _pgId = value; }
		}
		/// <summary>
		/// プログラム名を設定します。
		/// </summary>
		public string PgName
		{
			set
			{
				_pgName = value;
			}
		}
		/// <summary>
		/// フォームIDを設定します。
		/// </summary>
		public override string FormId
		{
			set { _formId = value; }
			get { return _formId; }
		}
		/// <summary>
		/// フォーム名を設定します。
		/// </summary>
		public string FormName
		{
			set
			{
				_formName = value;
				FormNameLiteral.Text = value;
			}
		}
		/// <summary>
		/// 閉じるボタンを設定します。
		/// </summary>
		public string ClsBtn
		{
			set { _clsBtn = value; }
		}
		#endregion

		#region メソッド
		/// <summary>
		/// ページロード
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (ConfigurationUtil.IsWebConfigValue(WebConfigKeyConstant.PROJECT_NAME_USE_RESOURCE_FLAG))
				{
					//リソースファイルから取得したプロジェクト名を設定する。
					string lang = WebSettingsUtil.GetLangSettingFromSession(this.Page.Session);
					ProgramNameResourceMgr pgNameResourceMgr = ProgramNameResourceMgr.GetInstance();
					//ヘッダーコントロールの情報を設定する。
					FormNameLiteral.Text = this._formName;
				}
				else
				{
					//ヘッダーコントロールの情報を設定する。
					FormNameLiteral.Text = this._formName;
				}
                LoginTanCd.Text = LoginInfoUtil.GetLoginInfo().TtsCd.ToString();
				LoginUserNameLiteral.Text = LoginInfoUtil.GetLoginInfo().TtsMei;
				if (!string.IsNullOrEmpty(LoginInfoUtil.GetLoginInfo().TtsMei))
				{
					if (LoginInfoUtil.GetLoginInfo().TtsMei.Length > 10)
					{
						LoginUserNameLiteral.Text = LoginInfoUtil.GetLoginInfo().TtsMei.Substring(0, 10);
					}
				}
                if (LoginInfoUtil.GetLoginInfo().Tenpokeitai_kb == 0)
                {
                    Tenpokeitai_kb.Text = "本部";
                }
                else
                {
                    Tenpokeitai_kb.Text = "店舗";
                }
                if (string.IsNullOrEmpty(ModeUtil.GetMode(_pgId, _formId, Session)))
                {
                    Mode.Style["display"] = "none";
                }
                else
                {
                    Mode.Style["display"] = "block";
                    ModeText.Text = HttpUtility.HtmlEncode(ModeUtil.GetMode(_pgId, _formId, Session));
                }
				string runningSysyemName = "";
				bool dbNmNonDspFlag = false;
				try
				{
					//DBコンテキストを取得します。
					IDBContext dbcontext2 = StandardDBContextFactory.CreateDbContext();
					int iFind1 = (dbcontext2.DataSource.ConnectionString.ToUpper().IndexOf("USER ID=", 0)) + 8;
					int iFind2 = dbcontext2.DataSource.ConnectionString.IndexOf(";", iFind1);
					string userId = dbcontext2.DataSource.ConnectionString.Substring(iFind1, iFind2 - iFind1);
					for (int i = 1; i < 10; i++)
					{
						runningSysyemName = MdConfigurationManager.AppSettings(MdSystemConstant.MD_RUNNING_SYSTEM_DB_NAME + Convert.ToString(i));
						if (runningSysyemName != null && runningSysyemName.ToUpper() != "NONE")
						{
							if (runningSysyemName == userId)
							{
								dbNmNonDspFlag = true;
							}
						}
					}
					if (dbNmNonDspFlag)
					{
						DBUser.Text = "";
					}
					else
					{
						DBUser.Text = userId;
					}
				}
				catch (System.Exception)
				{
				}

				//FormIdLiteral.Text = this._formId.ToUpper();
				StandardCaptionManager captionMgr = StandardCaptionManager.GetInstance();

				//標題(閉じる)
                //this.Button1.Value = captionMgr.GetString("C987");
				if (!Convert.ToBoolean(MdConfigurationManager.AppSettings(MdSystemConstant.MD_HEADER_CONTROL_CLOSE_BTN)))
				{
					this.Button1.Visible = false;
				}
				this.CLSMSGFLAG.Value = "0";
				try
				{
					//ClsBtn="false" ：　閉じるボタンのクリック時メッセージ非表示
					if (this._clsBtn != null && !Convert.ToBoolean(this._clsBtn))
					{
						this.CLSMSGFLAG.Value = "1";
					}
				}
				catch (System.Exception)
				{
				}

				//ヘッダー共通情報設定
				COPCD.Value = Convert.ToString(LoginInfoUtil.GetLoginInfo().CopCd);
                LOGINID.Value = Convert.ToString(LoginInfoUtil.GetLoginInfo().TtsCd);
				TTSCD.Value = Convert.ToString(LoginInfoUtil.GetLoginInfo().TtsCd);
				if ("99999999".Equals(LOGINID.Value))
				{
					TTSCD.Value = "99999999";
				}
				TNPCD.Value = Convert.ToString(LoginInfoUtil.GetLoginInfo().TnpCd);
				PGMID.Value = this._pgId.ToUpper();
				EXECERROR.Value = "0";
				EXECERRORID.Value = "";
				BASEWEBNAME.Value = "Base";
				if (ConfigurationManager.AppSettings[MdSystemConstant.WEB_CONFIG_BASEWEBNAME] != null)
				{
					BASEWEBNAME.Value = Convert.ToString(ConfigurationManager.AppSettings[MdSystemConstant.WEB_CONFIG_BASEWEBNAME]);
				}


				//DBコンテキストを取得します。
				IDBContext dbcontext = StandardDBContextFactory.CreateDbContext();
				try
				{
					//コネクション開始
					if (dbcontext != null)
					{
						dbcontext.OpenConnection();
					}
					
					// オンライン中かチェック
					if (!OperationUtil.CheckOperationOnline(dbcontext))
					{
						EXECERRORID.Value = "オンライン停止中";
						EXECERROR.Value = "1";
					}
					else
					{
						//排他機能チェック
						Hashtable ht = (Hashtable)HttpContext.Current.Session[SessionKeyConstant.GetPgSessionKey(this._pgId)];
						if (ht != null)
						{
							if (Convert.ToBoolean(ht[SessionKeyConstant.EXCLUSION_PROGRAM + this._pgId.ToUpper()]))
							{
								string loginid = ExclusionUtil.ExclusionCheck(dbcontext, this._pgId.ToUpper(), this._formId.ToUpper());
								if (!string.IsNullOrEmpty(loginid))
								{
									if (!loginid.ToUpper().Equals("SYSTEM"))
									{
										string resultName = ExclusionUtil.ExclusionCheckGetLoginName(dbcontext, loginid);
										EXECERRORID.Value = "ログインＩＤ：" + loginid + "（" + resultName + "）が使用中";
										EXECERROR.Value = "1";
									}
									else
									{
										EXECERRORID.Value = "バッチ処理中";
										EXECERROR.Value = "1";
									}
								}
								else
								{
									ExclusionUtil.ExclusionUpdateData(dbcontext, this._pgId.ToUpper());
								}
							}
						}
					}
				}
				catch (System.Exception)
				{
				}
				finally
				{
					if (dbcontext != null)
					{
						//コネクションクローズ
						dbcontext.CloseConnection();
					}
				}

                if (AccordionUtil.ResetSearchConditionForHeader(_pgId, _formId, Session) != "1")
                {
                    string html = AccordionUtil.GetSearchCondition(_pgId, _formId, Session);
                    searchContent.Value = html;
                    searchContentResetFlg.Value = "";
                }
                else
                {
                    searchContentResetFlg.Value = "1";
                }

				mess = HttpUtility.UrlEncode(MessageResourceUtil.GetString("I423"));
				this.DataBind();

			}
		}

		/// <summary>
		/// メッセージを初期化します。
		/// </summary>
		/// <param name="pgId">プログラムID</param>
		public override void InitMessage(string pgId)
		{
			base.InitMessage(pgId);
		}

		/// <summary>
		/// メッセージを設定します。
		/// </summary>
		/// <param name="pgId">プログラムID</param>
		public override void SetMessage(string pgId)
		{
            this.message1.SetMessage(pgId);
		}

		/// <summary>
		/// ヘッダー情報を設定します。
		/// </summary>
		public void SetHeader()
		{
			FormNameLiteral.Text = this._formName;
		}
		#endregion
	}
}