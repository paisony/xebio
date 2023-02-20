// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Com.Fujitsu.SmartBase.Base.Common.Config;
using System.Collections.Generic;
using Com.Fujitsu.SmartBase.Base.LoginUser.Util;
using Com.Fujitsu.SmartBase.Base.Common.Util;


namespace Com.Fujitsu.SmartBase.Base.Web.BizMenu
{

	/// <summary>
	/// 業務メニュー
	/// </summary>
	[Serializable]
	public class BizMenuManager
	{
		#region フィールド
		private string solutionId;
		private string functionViewId;
		private GenerateMenuVO bizMenuVO;

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public BizMenuManager(string solutionId, string functionViewId)
		{
			this.solutionId = solutionId;
			this.functionViewId = functionViewId;

			#region メニュー情報取得

			DataTable topDt = FunctionViewMst.GetFunctionView(solutionId, functionViewId);
			DataRow topRow = topDt.Rows[0];

			bizMenuVO = new GenerateMenuVO(topRow);

			SetMenuVO(bizMenuVO);

			if (!LoginUserContext.LoginId.Equals(WebConstantUtil.LOGIN_ID_WEBSERVE_SMART))
				SetMenuVisible(bizMenuVO);

			DeleteOfflineMenu(bizMenuVO);
			#endregion
		}

		#endregion

		#region メソッド

		/// <summary>
		/// カテゴリデータソースを取得
		/// </summary>
		/// <returns>ソートされたデータソース</returns>
		public DataTable GetCategoryDataSource()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("ID", typeof(string)));
			dt.Columns.Add(new DataColumn("DISPLAYNAME", typeof(string)));
			dt.Columns.Add(new DataColumn("SORT", typeof(decimal)));

			foreach (GenerateMenuVO cate in bizMenuVO.GenerateMenuVOs)
			{
				if (cate.Visible)
				{
					DataRow row = dt.NewRow();
					row["ID"] = cate.FunctionViewId;
					row["DISPLAYNAME"] = cate.Name;
					row["SORT"] = cate.SortNo;
					dt.Rows.Add(row);
				}
			}

			return dt;
		}

		/// <summary>
		/// サブカテゴリデータソースを取得します。
		/// </summary>
		/// <param name="solutionId">ソリューションID</param>
		/// <param name="functionViewId">カテゴリID</param>
		/// <returns>ソートされたデータソース</returns>
		public DataTable GetSubCategoryDataSource(string solutionId, string categoryId)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("ID", typeof(string)));
			dt.Columns.Add(new DataColumn("DISPLAYNAME", typeof(string)));
			dt.Columns.Add(new DataColumn("SORT", typeof(decimal)));

			GenerateMenuVOByIDPredicate pre = new GenerateMenuVOByIDPredicate();
			pre.SolutionId = solutionId;
			pre.FunctionViewId = categoryId;
			GenerateMenuVO categoryVO = this.bizMenuVO.GenerateMenuVOs.Find(pre.Match);

			foreach (GenerateMenuVO subcate in categoryVO.GenerateMenuVOs)
			{
				if (subcate.Visible)
				{
					DataRow row = dt.NewRow();
					row["ID"] = subcate.FunctionViewId;
					row["DISPLAYNAME"] = subcate.Name;
					row["SORT"] = subcate.SortNo;
					dt.Rows.Add(row);
				}
			}

			return dt;
		}

		/// <summary>
		/// プログラムデータソースを取得します。
		/// </summary>
		/// <param name="categoryId">カテゴリID</param>
		/// <param name="subCategoryId">サブカテゴリID</param>
		/// <returns>ソートされたデータソース</returns>
		public DataTable GetProgramDataSource(string solutionId, string categoryId, string subCategoryId, bool oprCheckFlg)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("ID", typeof(string)));
			dt.Columns.Add(new DataColumn("DISPLAYNAME", typeof(string)));
			dt.Columns.Add(new DataColumn("SORT", typeof(decimal)));
			dt.Columns.Add(new DataColumn("VISIBLE", typeof(bool)));

			GenerateMenuVOByIDPredicate catepre = new GenerateMenuVOByIDPredicate();
			catepre.SolutionId = solutionId;
			catepre.FunctionViewId = categoryId;

			GenerateMenuVOByIDPredicate subpre = new GenerateMenuVOByIDPredicate();
			subpre.SolutionId = solutionId;
			subpre.FunctionViewId = subCategoryId;

			GenerateMenuVO categoryVO = this.bizMenuVO.GenerateMenuVOs.Find(catepre.Match);
			GenerateMenuVO subVO = categoryVO.GenerateMenuVOs.Find(subpre.Match);
			foreach (GenerateMenuVO program in subVO.GenerateMenuVOs)
			{
				if (program.Visible)
				{
					bool CheckOut = true;
					DataRow row2 = FunctionMst.GetFunction(program.SolutionId, program.FunctionID);
					if (row2 != null && Convert.ToString(row2["FUNCTION_PARAMS"]).IndexOf("APPLICATION") >= 0)
					{
						if (!System.IO.File.Exists(Convert.ToString(row2["FUNCTION_URL"])))
						{
							CheckOut = false;
						}
					}
					if (CheckOut)
					{
						DataRow row = dt.NewRow();
						row["ID"] = program.FunctionViewId;
						row["DISPLAYNAME"] = program.Name;
						row["SORT"] = program.SortNo;
						row["VISIBLE"] = true;
						if (oprCheckFlg)
						{
							if (!((string)row2["WINDOW_OPEN_FLAG"]).Equals("2"))
							{
								row["VISIBLE"] = false;
							}
						}
						dt.Rows.Add(row);
					}
				}
			}
			return dt;
		}

        //2015/09/16 FSWeb)Y.Tamura メニュー表示対応 Start
        /// <summary>
        /// カテゴリIDに属するプログラムデータソースを全て取得します。
        /// </summary>
        /// <param name="solutionId">ソリューションID</param>
        /// <param name="categoryId">カテゴリID</param>
        /// <param name="subCategoryIds">サブカテゴリID</param>
        /// <param name="oprCheckFlg">運用時間内フラグ</param>
        /// <returns>ソートされたデータソース</returns>
        public DataTable GetProgramDataSource2(string solutionId, string categoryId, string[] subCategoryIds, bool oprCheckFlg)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("DISPLAYNAME", typeof(string)));
            dt.Columns.Add(new DataColumn("SORT", typeof(decimal)));
            dt.Columns.Add(new DataColumn("VISIBLE", typeof(bool)));

            GenerateMenuVOByIDPredicate catepre = new GenerateMenuVOByIDPredicate();
            catepre.SolutionId = solutionId;
            catepre.FunctionViewId = categoryId;

            GenerateMenuVOByIDPredicate subpre = new GenerateMenuVOByIDPredicate();
            subpre.SolutionId = solutionId;
            for (int i = 0; i < subCategoryIds.Length; i++)
            {
                subpre.FunctionViewId = subCategoryIds[i];
                GenerateMenuVO categoryVO = this.bizMenuVO.GenerateMenuVOs.Find(catepre.Match);
                GenerateMenuVO subVO = categoryVO.GenerateMenuVOs.Find(subpre.Match);
                foreach (GenerateMenuVO program in subVO.GenerateMenuVOs)
                {
                    if (program.Visible)
                    {
                        bool CheckOut = true;
                        DataRow row2 = FunctionMst.GetFunction(program.SolutionId, program.FunctionID);
                        if (row2 != null && Convert.ToString(row2["FUNCTION_PARAMS"]).IndexOf("APPLICATION") >= 0)
                        {
                            if (!System.IO.File.Exists(Convert.ToString(row2["FUNCTION_URL"])))
                            {
                                CheckOut = false;
                            }
                        }
                        if (CheckOut)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = program.FunctionViewId;
                            row["DISPLAYNAME"] = program.Name;
                            row["SORT"] = program.SortNo;
                            row["VISIBLE"] = true;
                            if (oprCheckFlg)
                            {
                                if (!((string)row2["WINDOW_OPEN_FLAG"]).Equals("2"))
                                {
                                    row["VISIBLE"] = false;
                                }
                            }
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            return dt;
        }
        //2015/09/16 FSWeb)Y.Tamura メニュー表示対応 End
		#endregion

		#region プライベートメソッド

		#region private

		private void SetMenuVO(GenerateMenuVO vo)
		{
			DataTable dt = FunctionViewMst.GetChilds(vo.SolutionId, vo.FunctionViewId);
			foreach (DataRow row in dt.Rows)
			{
				GenerateMenuVO childVO = new GenerateMenuVO(row);
				vo.GenerateMenuVOs.Add(childVO);
				SetMenuVO(childVO);
			}
			return;
		}

		private bool SetMenuVisible(GenerateMenuVO vo)
		{
			bool visible = false;
			if (!string.IsNullOrEmpty(vo.FunctionID))
			{
				if (LoginUserContext.RoleIds.Count == 0)
				{
					visible = false;
				}
				else
				{
					//機能使用許可をチェック
					foreach (string roleId in LoginUserContext.RoleIds)
					{
						visible = FunctionAuthorizationMst.CheckFunctionAuthorization(roleId, vo.SolutionId, vo.FunctionID);
						if (visible)
							break;
					}
				}
			}
			else
			{
				//子階層を表示設定
				foreach (GenerateMenuVO menuVO in vo.GenerateMenuVOs)
				{
					visible = SetMenuVisible(menuVO) || visible;
				}
			}
			vo.Visible = visible;
			return visible;
		}

		private bool DeleteOfflineMenu(GenerateMenuVO vo)
		{
			//元から無効な場合はなにもしない。
			if (vo.Visible == false)
				return false;

			bool visible = false;
			if (!string.IsNullOrEmpty(vo.FunctionID))
			{
				//機能種類をチェック
				visible = FunctionMst.GetFunctionSystemType(vo.SolutionId, vo.FunctionID) == ConstantUtil.SUBSYSTEM_TYPE_WEB;
			}
			else
			{
				//子階層を表示設定
				foreach (GenerateMenuVO menuVO in vo.GenerateMenuVOs)
				{
					visible = DeleteOfflineMenu(menuVO) || visible;
				}
			}
			vo.Visible = visible;
			return visible;
		}

		#endregion

		#endregion

	}
}
