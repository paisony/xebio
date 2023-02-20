// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// ログイン・メニュー画面変更


using System;
using System.Web;
using System.Text;
using System.Data;
namespace Com.Fujitsu.SmartBase.Base.Web.Menu.MenuGenerator
{
    /// <summary>
    /// メニュー情報をHTML形式で書き出します。
    /// </summary>
    public static class MenuSetGenerator
    {
        #region メニュー生成
        /// <summary>
        /// メニュー情報をHTML形式で書き出します。 
        /// </summary>
        /// <param name="detailVO">メニューグループ、メニュー情報を含むMenuDetailVO</param>
        /// <returns>HTML形式のstring</returns>
        public static string Render(GenerateMenuSetVO vo)
        {
            StringBuilder res = new StringBuilder();

            #region HTML生成
            //有効メニューグループ番号
            int i = 0;
            #region メニューグループ生成部分
            foreach (GenerateMenuVO menuGrpVO in vo.GenerateMenuVOs)
            {
                if (!menuGrpVO.Visible)
                    continue;

                string menuGrpNo = Convert.ToString(i);
                res.Append("<div id=\"" + menuGrpNo + "\" solutionId=\"" + HttpUtility.HtmlEncode(menuGrpVO.SolutionId) + "\" class=\"menudiv\"><div id=\"top-middle-header\">");

                #region メニュー生成部分
                foreach (GenerateMenuVO menuVO in menuGrpVO.GenerateMenuVOs)
                {
                    if (!menuVO.Visible)
                        continue;

                    //機能情報取得
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
                            //通常メニュー  
                            res.Append("<a class=\"menu\" href=\"javascript:openFunction('" + solutionId + "','" + functionId + "','" + winName + "','" + winStyle + "','" + moveflag + "','" + menuGrpNo + "')\">" + HttpUtility.HtmlEncode(menuVO.Name) + "</a>");
                        }
                        else
                        {
                            //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
                            //業務メニュー
                            res.Append("<h2>店舗BOシステム</h2>");
                            //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End
                        }

                        //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
                        //                        res.Append(@"       </acronym>
                        //                                    </td>
                        //                                    <td class=""splittd"">&nbsp;|&nbsp;</td>");
                        //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End

                    }
                }
                #endregion

                //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 Start
                //                res.Append(@"<td width=""99%"">
                //                                 <img src=""Images/spacer.gif"" width=""200"" height=""35"" align=""absMiddle"">
                //                             </td>
                //                        </tr>
                //                    </table>
                //                </div>");
                res.Append(@"
					</div>
				</div>");
                //2015/09/16 FSWeb)Y.Tamura ログイン・メニュー画面変更 End

                ++i;
            }
            #endregion

            #region メニュー背景生成部分


            #endregion

            //メニューグループ数
            res.Append(@"<input type=""hidden"" id=""groupNum"" value=""" + Convert.ToString(i) + @""" />");


            #region 初期起動の設定
            //一行目の別ウィンドウで起動しない機能を初期起動させる
            //一行目がすべて別ウィドウで起動する機能の場合は一行目のメニュー一覧を表示する。
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
                            //通常メニュー
                            res.Append(@"<script language=JavaScript>
									parent.loadFunction('" + solutionId + "','" + functionId + @"');
								</script>");

                            return;
                        }
                        else
                        {
                            //業務メニュー
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
                //1行目のメニューがすべて別ウィンドウで起動するものだった場合

                res.Append(@"<script language=JavaScript>
							parent.loadMenuLink('" + startSolutionId + "','" + startFuncViewId + @"');
						</script>");

                return;
            }
            else
            {
                //表示するメニューがない
                res.Append(@"<script language=JavaScript>
						parent.loadMenuNotiong();
					</script>");
            }
        }

    }
}
