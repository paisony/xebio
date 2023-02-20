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
	/// �Ɩ����j���[
	/// </summary>
	[Serializable]
	public class BizMenuManager
	{
		#region �t�B�[���h
		private string solutionId;
		private string functionViewId;
		private GenerateMenuVO bizMenuVO;

		#endregion

		#region �R���X�g���N�^

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public BizMenuManager(string solutionId, string functionViewId)
		{
			this.solutionId = solutionId;
			this.functionViewId = functionViewId;

			#region ���j���[���擾

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

		#region ���\�b�h

		/// <summary>
		/// �J�e�S���f�[�^�\�[�X���擾
		/// </summary>
		/// <returns>�\�[�g���ꂽ�f�[�^�\�[�X</returns>
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
		/// �T�u�J�e�S���f�[�^�\�[�X���擾���܂��B
		/// </summary>
		/// <param name="solutionId">�\�����[�V����ID</param>
		/// <param name="functionViewId">�J�e�S��ID</param>
		/// <returns>�\�[�g���ꂽ�f�[�^�\�[�X</returns>
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
		/// �v���O�����f�[�^�\�[�X���擾���܂��B
		/// </summary>
		/// <param name="categoryId">�J�e�S��ID</param>
		/// <param name="subCategoryId">�T�u�J�e�S��ID</param>
		/// <returns>�\�[�g���ꂽ�f�[�^�\�[�X</returns>
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

        //2015/09/16 FSWeb)Y.Tamura ���j���[�\���Ή� Start
        /// <summary>
        /// �J�e�S��ID�ɑ�����v���O�����f�[�^�\�[�X��S�Ď擾���܂��B
        /// </summary>
        /// <param name="solutionId">�\�����[�V����ID</param>
        /// <param name="categoryId">�J�e�S��ID</param>
        /// <param name="subCategoryIds">�T�u�J�e�S��ID</param>
        /// <param name="oprCheckFlg">�^�p���ԓ��t���O</param>
        /// <returns>�\�[�g���ꂽ�f�[�^�\�[�X</returns>
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
        //2015/09/16 FSWeb)Y.Tamura ���j���[�\���Ή� End
		#endregion

		#region �v���C�x�[�g���\�b�h

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
					//�@�\�g�p�����`�F�b�N
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
				//�q�K�w��\���ݒ�
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
			//�����疳���ȏꍇ�͂Ȃɂ����Ȃ��B
			if (vo.Visible == false)
				return false;

			bool visible = false;
			if (!string.IsNullOrEmpty(vo.FunctionID))
			{
				//�@�\��ނ��`�F�b�N
				visible = FunctionMst.GetFunctionSystemType(vo.SolutionId, vo.FunctionID) == ConstantUtil.SUBSYSTEM_TYPE_WEB;
			}
			else
			{
				//�q�K�w��\���ݒ�
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
