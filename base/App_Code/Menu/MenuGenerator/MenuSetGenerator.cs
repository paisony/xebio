// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// ���ŗ���
// ���O�C���E���j���[��ʕύX


using System;
using System.Web;
using System.Text;
using System.Data;
namespace Com.Fujitsu.SmartBase.Base.Web.Menu.MenuGenerator
{
    /// <summary>
    /// ���j���[����HTML�`���ŏ����o���܂��B
    /// </summary>
    public static class MenuSetGenerator
    {
        #region ���j���[����
        /// <summary>
        /// ���j���[����HTML�`���ŏ����o���܂��B 
        /// </summary>
        /// <param name="detailVO">���j���[�O���[�v�A���j���[�����܂�MenuDetailVO</param>
        /// <returns>HTML�`����string</returns>
        public static string Render(GenerateMenuSetVO vo)
        {
            StringBuilder res = new StringBuilder();

            #region HTML����
            //�L�����j���[�O���[�v�ԍ�
            int i = 0;
            #region ���j���[�O���[�v��������
            foreach (GenerateMenuVO menuGrpVO in vo.GenerateMenuVOs)
            {
                if (!menuGrpVO.Visible)
                    continue;

                string menuGrpNo = Convert.ToString(i);
                res.Append("<div id=\"" + menuGrpNo + "\" solutionId=\"" + HttpUtility.HtmlEncode(menuGrpVO.SolutionId) + "\" class=\"menudiv\"><div id=\"top-middle-header\">");

                #region ���j���[��������
                foreach (GenerateMenuVO menuVO in menuGrpVO.GenerateMenuVOs)
                {
                    if (!menuVO.Visible)
                        continue;

                    //�@�\���擾
                    string solutionId = menuVO.SolutionId;
                    string functionId = menuVO.FunctionID;

                    string moveflag = "0";
                    string openflag = "0";
                    string winName = "main";
                    string winStyle = string.Empty;
                    string funcurl = string.Empty;

                    if (menuVO.Name.Trim().Length > 0)
                    {
                        if (!string.IsNullOrEmpty(functionId))
                        {
                            DataRow funcRow = FunctionMst.GetFunction(solutionId, functionId);
                            moveflag = Convert.ToString(funcRow["MENUBAR_MOVE_FLAG"]);
                            openflag = Convert.ToString(funcRow["WINDOW_OPEN_FLAG"]);
                            winName = Convert.ToString(funcRow["WINDOW_NAME"]);
                            winStyle = Convert.ToString(funcRow["WINDOW_STYLE"]);
                            funcurl = Convert.ToString(funcRow["FUNCTION_URL"]);
                            if (openflag == "1")
                            {
                                if (winName != "_blank" && winName != "_self" && winName != "_top")
                                    winName = solutionId + winName;
                            }
                            //�ʏ탁�j���[  
                            res.Append("<a class=\"menu\" href=\"javascript:openFunction('" + solutionId + "','" + functionId + "','" + winName + "','" + winStyle + "','" + moveflag + "','" + menuGrpNo + "')\">" + HttpUtility.HtmlEncode(menuVO.Name) + "</a>");
                        }
                        else
                        {
                            //2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX Start
                            //�Ɩ����j���[
                            res.Append("<h2>�X��BO�V�X�e��</h2>");
                            //2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX End
                        }

                        //2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX Start
                        //                        res.Append(@"       </acronym>
                        //                                    </td>
                        //                                    <td class=""splittd"">&nbsp;|&nbsp;</td>");
                        //2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX End

                    }
                }
                #endregion

                //2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX Start
                //                res.Append(@"<td width=""99%"">
                //                                 <img src=""Images/spacer.gif"" width=""200"" height=""35"" align=""absMiddle"">
                //                             </td>
                //                        </tr>
                //                    </table>
                //                </div>");
                res.Append(@"
					</div>
				</div>");
                //2015/09/16 FSWeb)Y.Tamura ���O�C���E���j���[��ʕύX End

                ++i;
            }
            #endregion

            #region ���j���[�w�i��������


            #endregion

            //���j���[�O���[�v��
            res.Append(@"<input type=""hidden"" id=""groupNum"" value=""" + Convert.ToString(i) + @""" />");


            #region �����N���̐ݒ�
            //��s�ڂ̕ʃE�B���h�E�ŋN�����Ȃ��@�\�������N��������
            //��s�ڂ����ׂĕʃE�B�h�E�ŋN������@�\�̏ꍇ�͈�s�ڂ̃��j���[�ꗗ��\������B
            AddStartUpFunctionScript(vo, res);
            #endregion

            #endregion

            return res.ToString();
        }
        #endregion

        private static void AddStartUpFunctionScript(GenerateMenuSetVO vo, StringBuilder res)
        {
            bool menulink = true;
            string startSolutionId = null;
            string startFuncViewId = null;
            foreach (GenerateMenuVO menuGrpVO in vo.GenerateMenuVOs)
            {
                if (!menuGrpVO.Visible)
                    continue;
                startSolutionId = menuGrpVO.SolutionId;
                startFuncViewId = menuGrpVO.FunctionViewId;
                foreach (GenerateMenuVO menuVO in menuGrpVO.GenerateMenuVOs)
                {
                    if (!menuVO.Visible)
                        continue;
                    string solutionId = menuVO.SolutionId;
                    string functionId = menuVO.FunctionID;
                    string openflag = "0";
                    if (!string.IsNullOrEmpty(functionId))
                    {
                        DataRow funcRow = FunctionMst.GetFunction(solutionId, functionId);
                        openflag = Convert.ToString(funcRow["WINDOW_OPEN_FLAG"]);
                    }

                    if (string.IsNullOrEmpty(functionId) || openflag == "0")
                    {
                        menulink = false;
                        if (!string.IsNullOrEmpty(functionId))
                        {
                            //�ʏ탁�j���[
                            res.Append(@"<script language=JavaScript>
									parent.loadFunction('" + solutionId + "','" + functionId + @"');
								</script>");

                            return;
                        }
                        else
                        {
                            //�Ɩ����j���[
                            res.Append(@"<script language=JavaScript>
									parent.loadBizMenu('" + solutionId + "','" + menuVO.FunctionViewId + @"');
								</script>");
                            HttpContext.Current.Response.Cookies["MenuFunctionViewId"].Value = menuVO.FunctionViewId;
                            return;
                        }
                    }
                }
                break;
            }

            if (!string.IsNullOrEmpty(startSolutionId) && !string.IsNullOrEmpty(startFuncViewId) && menulink)
            {
                //1�s�ڂ̃��j���[�����ׂĕʃE�B���h�E�ŋN��������̂������ꍇ

                res.Append(@"<script language=JavaScript>
							parent.loadMenuLink('" + startSolutionId + "','" + startFuncViewId + @"');
						</script>");

                return;
            }
            else
            {
                //�\�����郁�j���[���Ȃ�
                res.Append(@"<script language=JavaScript>
						parent.loadMenuNotiong();
					</script>");
            }
        }

    }
}
