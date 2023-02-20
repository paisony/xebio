using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Globalization;
using System.Resources;
using System.Reflection;

using Common.Advanced.Codecondition.Code.Command;
using Common.Advanced.Codecondition.Code.Context;
using Common.Advanced.Codecondition.Code.Vo;
using Common.Advanced.Codecondition.Code.Util;
using Common.Advanced.Formvo;
using Common.Advanced.Session;
using Common.Advanced.Util;
using Common.Advanced.Web.Control;
using Common.Advanced.Web.Util;

using Common.Standard.Attribute;
using System.Text;

namespace Pjcommon.Code
{
	/// <summary>
	/// CodeCOD の概要の説明です。
	/// </summary>
	public partial class CodeCODPage : System.Web.UI.Page
	{
		protected CodeCodCommand cod = new CodeCodCommand();
		protected string WindowTitle;
		protected string AlertMessage;
		protected string Language;
		protected string MappingJS;
		protected string ResultJS;
		protected ICodeContext codeContext;
		protected IDataList list;
		protected string CheckJSInclude;

		#region イベントのバインディング処理
		override protected void OnInit(EventArgs e)
		{
			InitialAutoComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Componentの初期化.
		/// </summary>
		private void InitialAutoComponent()
		{
			this.SearchBtn.Click += new System.EventHandler(this.cod.DoSearch);
			this.PrevPage.Click += new System.EventHandler(this.cod.DoBRFPAGE);
			this.NextPage.Click += new System.EventHandler(this.cod.DoNXTPAGE);
			this.Load += new System.EventHandler(this.cod.DoCODLoad);
			this.KeyItemsList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.cod.KeyItemsList_ItemDataBound);
			this.CodeGridView.RowDataBound += new GridViewRowEventHandler(CodeGridView_RowDataBound);
		}
		#endregion

		#region コード検索結果表示
		/// <summary>
		/// コード検索結果の表示を実行する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void CodeCOD_PreRender(object sender, EventArgs e)
		{
			this.codeContext = CodeUtility.GetContext(Session);
			this.list = CodeUtility.GetDataList(Session);

			// 表示文字列を設定する
			this.SetPageMessages();

			// 検索フォームの表示を設定する
			this.bindSearchForm();

			if (!codeContext.Form.IsInputValid)
			{
				// 検索フォームの入力結果がfalseの場合、メッセージを表示
				this.InputRequiredMessage.Visible = true;

				// ウィンドウ表示を設定
				this.bindWindowData(false);
			}
			else
			{
				this.InputRequiredMessage.Visible = false;

				// ウィンドウ表示を設定
				this.bindWindowData(true);
			}

			// 検索フォームの生成
			this.createSearchForm();

			// マッピング情報を出力
			this.MappingJS = codeContext.ResultInfo.GetMappingJS();

			// 検索結果のJavaScriptを出力
			this.ResultJS = this.cod.GetResultJS(codeContext);

			// 表示データのロード
			this.bindFormData();

			// 言語設定の書き出し
			this.Language = this.codeContext.Language;

			// ボタンのSubmit処理
			this.SearchBtn.Attributes.Add("onclick", "return ExecSubmit('SearchBtn',true)");
			this.NextPage.Attributes.Add("onclick", "return ExecSubmit('NextPage',false)");
			this.PrevPage.Attributes.Add("onclick", "return ExecSubmit('PrevPage',false)");

			// 入力チェックのJavaScriptを出力する
			if (!Utility.IsEmpty(codeContext.Form.CheckJSPath))
			{
				this.CheckJSInclude = "<script language=\"JavaScript\" src=\"../../" + codeContext.Form.CheckJSPath + "\"></script>";
			}
			else
			{
				this.CheckJSInclude = "";
				//((HtmlForm)this.FindControl("CodeCOD")).Attributes.Remove("onsubmit");
			}
			this.DataBind();

			CodeGridViewDiv.Style["height"] = Convert.ToString(codeContext.Window.Height - 160) + "px";
			CodeGridViewDiv.Style["overflow-y"] = "auto";
            MainTable.Style["width"] = Convert.ToString(codeContext.Window.Width - 20) + "px";
            header.Style["width"] = Convert.ToString(codeContext.Window.Width - 20) + "px";

			//[ENTER]キー対応
			for (int i = 0; i < this.KeyItemsList.Controls.Count; i++)
			{
				Control control = this.KeyItemsList.Controls[i].FindControl("InputItem");
				if (control is TextBox)
				{
					if (i < this.KeyItemsList.Controls.Count - 1)
					{
						StringBuilder sb = new StringBuilder("javascript:NextItem('");
						sb.Append(this.KeyItemsList.Controls[i + 1].FindControl("InputItem").ClientID);
						sb.Append("')");
						((TextBox)control).Attributes.Add("onkeydown", sb.ToString());
					}
					else
					{
						StringBuilder sb = new StringBuilder("javascript:NextItem('SearchBtn')");
						((TextBox)control).Attributes.Add("onkeydown", sb.ToString());
					}
				}
			}

		}
		#endregion

		#region 検索フォーム表示設定
		private void bindSearchForm()
		{
			if (this.codeContext.Form.Visible)
			{
				MainTable.FindControl("SearchFormRow").Visible = true;
				//MainTable.FindControl("SeparatorRow1").Visible = true;
			}
			else
			{
				MainTable.FindControl("SearchFormRow").Visible = false;
				//MainTable.FindControl("SeparatorRow1").Visible = false;
			}
		}
		#endregion

		#region 画面表示設定
		/// <summary>
		/// 画面表示定義情報から、画面を構成する
		/// </summary>
		private void bindWindowData(bool control)
		{
			if (!this.codeContext.Form.DoInitSearch
				&& this.codeContext.Form.IsFirstTime)
			{
				// 検索項目必須の場合
				MainTable.FindControl("SearchDemandRow").Visible = true;
				MainTable.FindControl("PageChangeRow").Visible = false;
				MainTable.FindControl("DispDataRow").Visible = false;
				MainTable.FindControl("DispResultRow").Visible = false;
			}
			else
			{
				if (control)
				{
					// 初回起動時に検索結果を表示する場合
					MainTable.FindControl("SearchDemandRow").Visible = false;
					MainTable.FindControl("PageChangeRow").Visible = true;
					MainTable.FindControl("DispDataRow").Visible = true;
					MainTable.FindControl("DispResultRow").Visible = true;
				}
			}
		}
		#endregion

		#region 検索フォーム生成
		/// <summary>
		/// 検索フォームを構成する
		/// </summary>
		private void createSearchForm()
		{
			if (this.codeContext.Form.InputControls.Count > 0)
			{
				KeyItemsList.DataSource = this.codeContext.Form.InputControls;
			}
			else
			{
				// 入力コントロールがなければ、検索フォームを非表示
				MainTable.FindControl("SearchFormRow").Visible = false;
				//MainTable.FindControl("SeparatorRow1").Visible = false;
			}
		}
		#endregion

		#region メッセージ設定
		/// <summary>
		/// 固定のメッセージを設定する
		/// </summary>
		private void SetPageMessages()
		{
			ResourceSet rs = CodeUtility.GetPageResource(this);
			if (rs != null)
			{
				this.SearchBtn.Text = rs.GetString(this.SearchBtn.ID);
				this.ReqSearchItemMessage.Text = rs.GetString(this.ReqSearchItemMessage.ID);
				//this.CloseMessage.Value = rs.GetString(this.CloseMessage.ID);
				this.ResultInfo.Text = rs.GetString("ResultInfo");
				this.ResultInfo.NoRecord = rs.GetString("NoRecord");
				this.InputRequiredMessage.Text = rs.GetString("InputRequired");
			}
		}
		#endregion

		#region 検索メッセージの制御
		/// <summary>
		/// 検索ボタンを押下したとき、”検索文字列を入力してください。”のメッセージ
		/// を隠す。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void SearchBtn_Click(object sender, System.EventArgs e)
		//{
		//    MainTable.FindControl("SearchDemandRow").Visible = false;
		//    MainTable.FindControl("PageChangeRow").Visible = true;
		//    MainTable.FindControl("DispDataRow").Visible = true;
		//    MainTable.FindControl("DispResultRow").Visible = true;
		//}
		#endregion

		#region GridViewの生成
		/// <summary>
		/// 画面表示定義情報からDataGridを構成する
		/// </summary>
		private void createDataGridForm()
		{
			// 必須チェックを外す（初期検索しない場合）
			this.codeContext.Form.InputRequired = false;

			this.CodeGridView.Columns.Clear();
			HyperLinkField columnInfo = null;

			// DataGridの各カラムを生成する
			ArrayList dispColumns = this.codeContext.ResultInfo.GetDisplayItems();
			string lang = WebSettingsUtil.GetLangSettingFromSession(Session);
			foreach (ICodeDisplayItem dispItem in dispColumns)
			{
				if ((dispItem.Visible) && (dispItem.DispNo >= 0))
				{
					columnInfo = new HyperLinkField();
					columnInfo.DataTextField = dispItem.ID;
					columnInfo.HeaderText = Convert.ToString(dispItem.GetCaption(lang));
					columnInfo.HeaderStyle.HorizontalAlign = dispItem.HeaderHAlign;
					columnInfo.HeaderStyle.VerticalAlign = dispItem.HeaderVAlign;
					columnInfo.ItemStyle.Width = Unit.Pixel(dispItem.Width);
					columnInfo.ItemStyle.CssClass = "nametablebodycol";
					columnInfo.ItemStyle.HorizontalAlign = dispItem.HAlign;
					columnInfo.ItemStyle.VerticalAlign = dispItem.VAlign;
					//columnInfo.DataNavigateUrlFields = new string[] { "_ADVNET_URL" };
					this.CodeGridView.Columns.Add(columnInfo);
				}
			}
		}
		#endregion

		#region 検索結果設定
		/// <summary>
		/// 検索結果を設定する
		/// </summary>
		private void bindFormData()
		{
			string lang = WebSettingsUtil.GetLangSettingFromSession(Session);
			ResourceSet rs = CodeUtility.GetPageResource(this);
			if (this.list.RecordCount > 0)
			{
				this.ResultInfo.PageNo = this.list.PageNo;
				this.ResultInfo.PageCount = this.list.PageCount;
				this.ResultInfo.RecordCount = this.list.RecordCount;
				this.ResultInfo.StartRow = this.list.StartRow;
				this.ResultInfo.EndRow = this.list.EndRow;
				this.StartRow.Text = this.list.StartRow.ToString();

				int dispRow = this.list.DispRow;
				if (rs != null)
				{
					this.NextPage.Text =
						rs.GetString(this.NextPage.ID + "Pre") + dispRow + rs.GetString(this.NextPage.ID + "Suf");
					this.PrevPage.Text =
						rs.GetString(this.PrevPage.ID + "Pre") + dispRow + rs.GetString(this.NextPage.ID + "Suf");
				}
				else
				{
					this.NextPage.Text = "次の" + dispRow + "件";
					this.PrevPage.Text = "前の" + dispRow + "件";
				}
				if (this.list.PageNo < this.list.PageCount) this.NextPage.Visible = true;
				else this.NextPage.Visible = false;
				if (this.list.PageNo > 1) this.PrevPage.Visible = true;
				else this.PrevPage.Visible = false;
			}
			else
			{
				this.ResultInfo.RecordCount = 0;
				this.NextPage.Visible = false;
				this.PrevPage.Visible = false;
			}

			this.createDataGridForm();
			this.CodeGridView.DataSource = this.list.GetPageViewList();
			this.CodeGridView.PageSize = this.list.DispRow;
			this.CodeGridView.DataBind();

			this.AlertMessage = rs.GetString("AlertSearchItem");
			this.WindowTitle = this.codeContext.Window.GetTitle(lang);

		}
		#endregion

		#region データのHtmlEncode
		/// <summary>
		/// データバインドするときに、HtmlEncodeを実行する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CodeGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			CodeResultBaseVO data = (CodeResultBaseVO)e.Row.DataItem;
			if (data == null)
			{
				return;
			}

            if (!data.IsHtmlEncoded)
            {
                // 各プロパティをHtmlEncodeする
                data.EncodeCodeResult();

                // 改行コードを<br/>に変更する
                data.ChangeCRLF();

                e.Row.DataItem = data;

                data.IsHtmlEncoded = true;
            }


			// データ項目のJavaScriptを生成する
			foreach (TableCell cell in e.Row.Cells)
			{
				HyperLink link = (HyperLink)cell.Controls[0];
				link.NavigateUrl = ((CodeResultBaseVO)e.Row.DataItem)._ADVNET_URL;
			}
		}
		#endregion
	}
}
