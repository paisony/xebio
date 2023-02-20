// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
 
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// GenerateMenuVOByIDPredicate の概要の説明です
/// </summary>
public class GenerateMenuVOByIDPredicate
{
    private string solutionId;
    private string functionViewId;

    public string SolutionId
    {
        get
        {
            return solutionId;
        }
        set
        {
            solutionId = value;
        }
    }

    public string FunctionViewId
    {
        get
        {
            return functionViewId;
        }
        set
        {
            functionViewId = value;
        }
    }

    // Predicate<T>デリゲートの処理を実装
    public bool Match(GenerateMenuVO vo)
    {
        return vo.SolutionId == solutionId && vo.FunctionViewId == functionViewId;
    }

}
