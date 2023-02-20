using com.xebio.bo.Tm810p01.Formvo;
using Common.Advanced.Formvo;
using Common.Advanced.Model.Context;
using Common.Business.C99999.ConfigUtil;
using Common.Business.C99999.Constant;
using Common.Standard.Base;
using System.Collections.Generic;

namespace com.xebio.bo.Tm810p01.Facade
{
  /// <summary>
  /// Tm810f01のFacadeクラスです
  /// 画面データのロード業務ロジックを実装します。
  /// </summary>
  public partial class Tm810f01Facade : StandardBaseFacade
	{
		#region 定数を設定します
		/// <summary>;
		/// プログラムID。
		/// </summary>
		private const string PGID = "Tm810p01";
		/// <summary>
		/// フォームID。
		/// </summary>
		private const string FORMID = "Tm810f01";
		#endregion
		
		#region コンストラクタ
		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		public Tm810f01Facade()
			: base()
		{
		}
		#endregion

		#region Tm810f01画面データを作成する。
		/// <summary>
		/// Tm810f01画面データを作成する。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoLoad(IFacadeContext facadeContext)
		{
			//使用時にコメントアウトをはずす。
            //メソッドの開始処理を実行する。
            StartMethod(facadeContext, this.GetType().Name + ".DoLoad");
            try
            {
                //DBコンテキストを設定する。
                //SetDBContext(facadeContext);
                //コネクションを開きます。
                //OpenConnection(facadeContext);

                //以下に業務ロジックを記述する。
                List<string> dlFileList = new List<string>();
                dlFileList = (List<string>)facadeContext.GetUserObject("dlList");
                var dlFolderPath = BoSystemConfig.GetConfgiVal(BoSystemConstant.DOWNLOAD_FOLDER_PATH);
                //カード部を取得します。
                Tm810f01Form tm810f01Form = (Tm810f01Form)facadeContext.FormVO;
                IDataList m1List = tm810f01Form.GetList("M1");
                m1List.Clear();
                for (int i = 0; i < dlFileList.Count; i++)
                {
                    Tm810f01M1Form m1Form = new Tm810f01M1Form();
                    var filePath = dlFolderPath + @"\\" + dlFileList[i];
                    if (!System.IO.File.Exists(filePath))
                    {
                        //指定されたファイルが存在しない
                        continue;
                    }
                    m1Form.M1download_file_name = dlFileList[i];
                    m1List.Add(m1Form, true);
                }

                //モデル層処理ロジックを記述してください。
                //カード部 データを取得(要実装)........

                //M1明細部のデータを作成します。
                DoM1ListLoad(facadeContext);

            }
            catch (System.Exception ex)
            {
                //例外処理を実行する。
                ThrowException(ex, facadeContext);
            }
            finally
            {
                //コネクションを開放する。
                //CloseConnection(facadeContext);
            }
            //メソッドの終了処理を実行する。
            EndMethod(facadeContext, this.GetType().Name + ".DoLoad");
		}
		#endregion

		
		#region M1明細部データの作成をする。
		/// <summary>
		/// M1明細部データの作成をする。
		/// 明細ID(M1)の処理メソッド。
		/// </summary>
		/// <param name="facadeContext">ファサードコンテキスト</param>
		public void DoM1ListLoad(IFacadeContext facadeContext)
		{
			//このメソッドは、M1の明細のデータを生成するために、
			//画面のLoad処理と改ページ処理で呼ばれます。
			//コネクションの開始・終了は呼び出しもとのメソッドで管理されます。
			//必要な処理を実装してください。
			
		}
		#endregion
	}
}
