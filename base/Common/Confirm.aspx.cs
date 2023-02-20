using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Drawing;



public partial class Common_Confirm : System.Web.UI.Page
{
    #region フィールド
    protected string pgId;
    /// <summary>
    /// リクエストキー
    /// </summary>
    private const String REQUEST_KEY1 = "pgId";
    private const String REQUEST_KEY2 = "mess";
    #endregion

    #region メソッド
    /// <summary>
    /// ページロード
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    #region 標題を設定します。
    /// <summary>
    /// 標題を設定します。
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void RenderForm(object sender, System.EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.pgId = (String)Request[REQUEST_KEY1];
            this.message.Text = (String)Request[REQUEST_KEY2];
            this.markimage.ImageUrl = "Images/question.gif";
            //標題（処理の継続）
            this.button1.Value = "ＯＫ";
            //標題（処理の中断）
            this.button2.Value = "キャンセル";
            if ("LOGIN".Equals(pgId.ToUpper()))
            {
                this.message.Text = "終了します。よろしいですか？";
            }
            if ("MENU".Equals(pgId.ToUpper()))
            {
                this.message.Text = "ログアウトします。よろしいですか？";
            }
            if ("ERR1".Equals(pgId.ToUpper()))
            {
                //...................①......................................................②................
                this.message.Text = "業務画面が起動しています。強制終了して　　　　　　　　　よろしいですか？";

                this.markimage.ImageUrl = "Images/caution.gif";
            }
            if ("ERR2".Equals(pgId.ToUpper()))
            {
                //...................①......................................................②................
                this.message.Text = "他にウインドウが立ち上がっています。直ちに終了して　　　下さい。";
                this.button2.Visible = false;
                this.markimage.ImageUrl = "Images/caution.gif";
            }
            if ("ERR5".Equals(pgId.ToUpper()))
            {
                this.message.Text = "ＢＯシステムが既に起動されています。";
                this.button2.Visible = false;
                this.markimage.ImageUrl = "Images/caution.gif";
            }
            if ("ERR6".Equals(pgId.ToUpper()))
            {
                this.message.Text = "ＢＯシステムが起動されている可能性があります。";
                this.button2.Visible = false;
            }
            if ("DUP".Equals(pgId.ToUpper()))
            {
                this.message.Text = "既にログインされています。強制的にログインしますか？";
                this.markimage.ImageUrl = "Images/caution.gif";
            }
            if ("OPR2".Equals(pgId.ToUpper()))
            {
                this.message.Text = "オンライン停止中のため起動できません。ログオフして下さい。";
                this.button2.Visible = false;
                this.markimage.ImageUrl = "Images/caution.gif";
            }
            if ("OPR".Equals(pgId.ToUpper()))
            {
                this.message.Text = "運用時間外のため起動できません。ログオフして下さい。";
                this.button2.Visible = false;
                this.markimage.ImageUrl = "Images/caution.gif";
            }
            if ("SESS".Equals(pgId.ToUpper()))
            {
                this.message.Text = "セッションエラーが発生しました。ログオフして下さい。";
                this.button2.Visible = false;
                this.markimage.ImageUrl = "Images/caution.gif";
            }
            if ("PROC1".Equals(pgId.ToUpper()))
            {
                //...................①......................................................②................
                this.message.Text = "既に同一機能、または同時実行不可の機能が立上って　　　　います。確認して下さい（メニュー）。";
                this.button2.Visible = false;
                this.markimage.ImageUrl = "Images/caution.gif";
            }
            if ("EXEC".Equals(pgId.ToUpper()))
            {
                this.message.Text = "しばらくお待ち下さい。";
                this.button1.Visible = false;
                this.button2.Visible = false;
            }

            this.DataBind();
        }
    }
    #endregion
    #endregion
}
