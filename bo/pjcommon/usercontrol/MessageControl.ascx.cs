using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Common.Standard.Attribute;
using Common.Standard.Constant;
using Common.Standard.Message;
using Common.Standard.Session;
using Common.Standard.Util;

namespace Common.Standard.Page
{
	/// <summary>
	/// 共通メッセージコントロールのコードビハインドクラスです。
	/// </summary>
	public partial class MessageControl : System.Web.UI.UserControl
	{
		#region フィールド
		/// <summary>
		/// クライアントスクリプト
		/// </summary>
		protected String clientScript;

		#region 定数
		/// <summary>
		/// リストボックス表示最大サイズ
		/// </summary>
		private const int LIST_BOX_MAX_SIZE = 3;
		/// <summary>
		/// エラーメッセージスタイル
		/// </summary>
		private const String ERROR_MESSAGE_STYLE = "color:Red";
		/// <summary>
		/// 情報メッセージスタイル
		/// </summary>
		private const String INFO_MESSAGE_STYLE = "color:Blue";
		/// <summary>
		/// メッセージスタイル文字列
		/// </summary>
		private const String MESSAGE_STYLE = "Style";
		/// <summary>
		/// リストボックス用のCSSクラス
		/// </summary>
		private const String LIST_BOX_CSS_CLASS = "ERR_MSG";
		#endregion
		#endregion

		#region メソッド
		#region ページロード
		/// <summary>
		/// ページロード
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			MessageList.Items.Clear();
			MessageListBox.Items.Clear();
		}
		#endregion

		#region メッセージ初期化
		/// <summary>
		/// メッセージを初期化します。
		/// </summary>
		/// <param name="pgId">プログラムID</param>
		public void InitMessage(String pgId)
		{
			SessionInfoUtil.RemovePgObject(pgId, SessionKeyConstant.MESSAGE_LIST, Session);
		}
		#endregion

		#region メッセージ設定
		/// <summary>
		/// メッセージを設定します。
		/// <param name="pgId">プログラムID</param>
		/// </summary>
		public void SetMessage(String pgId)
		{
			List<MessageInfoVO> list = (List<MessageInfoVO>)SessionInfoUtil.GetPgObject(pgId, SessionKeyConstant.MESSAGE_LIST, Session);

			if (list == null)
			{
				return;
			}

			String st = ConfigurationUtil.GetWebConfigValue(WebConfigKeyConstant.MESSAGE_SHOW_TYPE);

			switch (st)
			{
				case "1":
					//リスト表示
					this.SetMessageList(list);
					break;
				case "2":
					//ポップアップ表示
					this.SetPopupMessage(list);
					break;
				case "3":
					//一行表示
					this.SetMessageLine(list);
					break;
				case "4":
					//リストボックス表示
					this.SetMessageListBox(list);
					break;
				case "5":
					//テーブル表示
					this.SetMessageTable(list);
					break;
			}
		}
		#endregion

		#region プライベートメソッド
		#region メッセージ表示形式１「リスト表示」設定
		/// <summary>
		/// メッセージ表示形式１「リスト表示」を設定します。
		/// </summary>
		/// <param name="list">メッセージリスト</param>
		private void SetMessageList(List<MessageInfoVO> list)
		{
			//メッセージリストを表示
			this.MessageList.Visible = true;

			for (int i = 0; i < list.Count; i++)
			{
				MessageInfoVO msgInfoVO = list[i];
				MessageList.Items.Add(msgInfoVO.Message);

				switch (msgInfoVO.MessageLevel)
				{
					case MessageLevel.ERROR:
					case MessageLevel.WARN:
						MessageList.Items[i].Attributes.Add(MESSAGE_STYLE, ERROR_MESSAGE_STYLE);
						break;
					case MessageLevel.INFO:
						MessageList.Items[i].Attributes.Add(MESSAGE_STYLE, INFO_MESSAGE_STYLE);
						break;
				}
			}
		}
		#endregion

		#region メッセージ表示形式２「ポップアップ表示」設定
		/// <summary>
		/// メッセージ表示形式２「ポップアップ表示」を設定します。
		/// </summary>
		/// <param name="list">メッセージリスト</param>
		private void SetPopupMessage(List<MessageInfoVO> list)
		{
            //JavaScripの「onload」イベントを設定
            this.clientScript = "$(window).load(function() {CaseOfRedisplayWarningField();});";
			this.DataBind();
		}
		#endregion

		#region メッセージ表示形式３「一行表示」設定
		/// <summary>
		/// メッセージ表示形式３「一行表示」を設定します。
		/// </summary>
		/// <param name="list">メッセージリスト</param>
		private void SetMessageLine(List<MessageInfoVO> list)
		{
			if (list.Count > 1)
			{
				//エラーメッセージが複数の場合ビックリマーク表示
				ImageButton1.Visible = true;
			}
			else
			{
				ImageButton1.Visible = false;
			}
			Image1.Visible = true;
			MessageLbl.Visible = true;
			MessageLbl.Text = Server.HtmlEncode(((MessageInfoVO)list[0]).Message);

			switch (((MessageInfoVO)list[0]).MessageLevel)
			{
				case MessageLevel.ERROR:
				case MessageLevel.WARN:
					MessageLbl.Attributes.Add(MESSAGE_STYLE, ERROR_MESSAGE_STYLE);
					break;
				case MessageLevel.INFO:
					MessageLbl.Attributes.Add(MESSAGE_STYLE, INFO_MESSAGE_STYLE);
					break;
			}

		}
		#endregion

		#region メッセージ表示形式４「リストボックス表示」設定
		/// <summary>
		/// メッセージ表示形式４「リストボックス表示」を設定します。
		/// </summary>
		/// <param name="list">メッセージリスト</param>
		private void SetMessageListBox(List<MessageInfoVO> list)
		{
			this.MessageListDiv.Visible = true;

			#region 最大桁数取得
			//最大桁数初期値
			int maxLength = 38;

			foreach (MessageInfoVO mInfoVO in list)
			{
				if (maxLength < mInfoVO.Message.Length)
				{
					maxLength = mInfoVO.Message.Length;
				}
			}

			maxLength = maxLength * 14;
			#endregion

			if (list.Count == 1)
			{
				//メッセージが一件の場合テキストボックス表示
				this.MessageListBox.Visible = false;
				this.MessageTextBox.Visible = true;
				//this.MessageTextBox.CssClass = LIST_BOX_CSS_CLASS;
				//this.MessageTextBox.Style.Add("width", maxLength.ToString() + "px");
				//this.MessageTextBox.Style.Add("width", "100%");
				this.MessageTextBox.Width = new Unit(maxLength);
				this.MessageListDiv.Style.Add("height", "35px");
				this.MessageTextBox.ReadOnly = true;
			}
			else if (list.Count > 1)
			{
				//メッセージが複数の場合リストボックス表示
				if (list.Count == 2)
				{
					this.MessageListBox.Rows = list.Count;
					this.MessageListDiv.Style.Add("height", "50px");
				}
				else
				{
					this.MessageListBox.Rows = LIST_BOX_MAX_SIZE;
					this.MessageListDiv.Style.Add("height", "65px");
				}

				this.MessageListBox.Visible = true;
				this.MessageTextBox.Visible = false;
				//this.MessageListBox.CssClass = LIST_BOX_CSS_CLASS;
				//this.MessageTextBox.Style.Add("width", maxLength.ToString() + "px");
				this.MessageListBox.Width = new Unit(maxLength);
			}

			for (int i = 0; i < list.Count; i++)
			{
				MessageInfoVO msgInfoVO = list[i];
				MessageListBox.Items.Add(msgInfoVO.Message);
				MessageTextBox.Text = msgInfoVO.Message;

				switch (msgInfoVO.MessageLevel)
				{
					case MessageLevel.ERROR:
					case MessageLevel.WARN:
						MessageListBox.Items[i].Attributes.Add(MESSAGE_STYLE, ERROR_MESSAGE_STYLE);
						MessageTextBox.Attributes.Add(MESSAGE_STYLE, ERROR_MESSAGE_STYLE);
						break;
					case MessageLevel.INFO:
						MessageListBox.Items[i].Attributes.Add(MESSAGE_STYLE, INFO_MESSAGE_STYLE);
						MessageTextBox.Attributes.Add(MESSAGE_STYLE, INFO_MESSAGE_STYLE);
						break;
				}
			}
		}
		#endregion

		#region メッセージ表示形式５「テーブル表示」設定
		/// <summary>
		/// メッセージ表示形式５「テーブル表示」を設定します。
		/// </summary>
		/// <param name="list">メッセージリスト</param>
		private void SetMessageTable(List<MessageInfoVO> list)
		{
			this.MessageTable.Visible = true;

			Repeater1.DataSource = list;
			Repeater1.DataBind();
		}
		#endregion

		#endregion
		#endregion

		/// <summary>
		/// リピータコントロールイベントハンドラ
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
		{
			MessageInfoVO msgInfoVO = (MessageInfoVO)e.Item.DataItem;

			if (msgInfoVO != null)
			{
				switch (msgInfoVO.MessageLevel)
				{
					case MessageLevel.ERROR:
					case MessageLevel.WARN:
						((Label)e.Item.FindControl("Message")).ForeColor = System.Drawing.Color.Red;
						break;
					case MessageLevel.INFO:
						((Label)e.Item.FindControl("Message")).ForeColor = System.Drawing.Color.Blue;

						break;
				}
			}
		}
	}
}