using System;
using Common.Advanced.Log;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Common.IntegrationMD.Exception;
using System.Runtime.InteropServices;

public partial class ImageLoader : System.Web.UI.Page
{
    /// <summary>
    /// ログ出力クラスです。
    /// </summary>
    protected static ILogger logger = LogManager.GetLogger();

    protected const string EXTENSION_POINT = ".";

    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Request["path"];
        string filename = Request["filename"];

        if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(filename))
        {
            return;
        }

        Bitmap image = null;
        MemoryStream ms = null;

        try
        {   
            ms = new MemoryStream();
            image = new Bitmap(@path + filename, true);

            string stExtension = Path.GetExtension(filename).ToLower();
            switch (stExtension)
            {
                case EXTENSION_POINT + "bmp":
                    image.Save(ms, ImageFormat.Bmp);
                    break;
                case EXTENSION_POINT + "gif":
                    image.Save(ms, ImageFormat.Gif);
                    break;
                case EXTENSION_POINT + "jpg":
                    image.Save(ms, ImageFormat.Jpeg);
                    break;
                case EXTENSION_POINT + "jpeg":
                    image.Save(ms, ImageFormat.Jpeg);
                    break;
                case EXTENSION_POINT + "png":
                    image.Save(ms, ImageFormat.Png);
                    break;
                case EXTENSION_POINT + "tif":
                    image.Save(ms, ImageFormat.Tiff);
                    break;
                case EXTENSION_POINT + "tiff":
                    image.Save(ms, ImageFormat.Tiff);
                    break;
                default:
                    throw new ExternalException("未サポートの画像拡張子です。");
            }
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(ms.GetBuffer());
            Response.End();
        }
        catch (ArgumentNullException ex)
        {
            logger.Error("イメージファイルパスを確認してください。", ex);
            throw ex;
        }
        catch (ExternalException ex)
        {
            logger.Error(string.Format("{0}イメージファイルは、誤ったイメージ形式で保存されています。", path + filename), ex);
            throw ex;
        }
        catch (ArgumentException ex)
        {
            logger.Error("イメージファイルパスを確認してください。", ex);
            throw ex;
        }
        catch (MdCommonException ex)
        {
            logger.Error("", ex);
            throw ex;
        }
        finally
        {
            if (image != null) image.Dispose();
            if (ms != null) ms.Close();
        }
    }
}
