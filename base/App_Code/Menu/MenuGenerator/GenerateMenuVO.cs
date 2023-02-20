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
using System.Collections.Generic;

/// <summary>
/// MenuGroupVO の概要の説明です
/// </summary>
[Serializable]
public class GenerateMenuVO
{
    #region フィールド変数
    /// <summary>
    /// ソリューションID
    /// </summary>
    private string solutionId;
    /// <summary>
    /// 機能表示ID
    /// </summary>
    private string functionViewId;
    /// <summary>
    /// 名称
    /// </summary>
    private string name;
    /// <summary>
    /// 注釈
    /// </summary>
    private string note;
    /// <summary>
    /// 表示順
    /// </summary>
    private int sortNo;
    /// <summary>
    /// 親ID
    /// </summary>
    private string parentId;
    /// <summary>
    /// 階層レベル
    /// </summary>
    private int level;
    /// <summary>
    /// 機能ID
    /// </summary>
    private string functionId;
    /// <summary>
    /// 表示状態
    /// </summary>
    private bool visible;


    /// <summary>
    /// メニュー情報
    /// </summary>
    private List<GenerateMenuVO> menuVOs;

    #endregion

    #region コンストラクタ
    /// <summary>
    /// デフォルトコンストラクタ
    /// </summary>
    public GenerateMenuVO()
    {
        this.menuVOs = new List<GenerateMenuVO>();
    }

    //データセットから値をつめる
    /// <summary>
    /// データセットかVOを生成
    /// </summary>
    public GenerateMenuVO(DataRow row)
        : this()
    {
        //値をセットする。
        solutionId = Convert.ToString(row["SOLUTION_ID"]);
        functionViewId = Convert.ToString(row["FUNCTION_VIEW_ID"]);
        name = Convert.ToString(row["FUNCTION_VIEW_NAME"]);
        note = Convert.ToString(row["FUNCTION_VIEW_NOTE"]);
        sortNo = Convert.ToInt32(row["SORT_NO"]);
        parentId = Convert.ToString(row["PARENT_VIEW_ID"]);
        level = Convert.ToInt32(row["LEVEL_NO"]);
        functionId = Convert.ToString(row["FUNCTION_ID"]);
        visible = true;
    }
    #endregion

    #region プロパティ
    /// <summary>
    /// ソリューションID
    /// </summary>
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

    /// <summary>
    /// 機能表示ID
    /// </summary>
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

    /// <summary>
    /// 名称
    /// </summary>
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    /// <summary>
    /// 注釈
    /// </summary>
    public string Note
    {
        get
        {
            return note;
        }
        set
        {
            note = value;
        }
    }

    /// <summary>
    /// 表示順
    /// </summary>
    public int SortNo
    {
        get
        {
            return sortNo;
        }
        set
        {
            sortNo = value;
        }
    }

    /// <summary>
    /// 親ID
    /// </summary>
    public string ParentId
    {
        get
        {
            return parentId;
        }
        set
        {
            parentId = value;
        }
    }

    /// <summary>
    /// 階層レベル
    /// </summary>
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    /// <summary>
    /// 機能ID
    /// </summary>
    public string FunctionID
    {
        get
        {
            return functionId;
        }
        set
        {
            functionId = value;
        }
    }
    /// <summary>
    /// 表示状態
    /// </summary>
    public bool Visible
    {
        get
        {
            return visible;
        }
        set
        {
            visible = value;
        }
    }

    /// <summary>
    /// メニュー情報
    /// </summary>
    public List<GenerateMenuVO> GenerateMenuVOs
    {
        get
        {
            return menuVOs;
        }
    }

    #endregion

    #region 追加・削除

    /// <summary>
    /// メニューを追加します。
    /// </summary>
    /// <param name="menuVO">メニューVO</param>
    public void Add(GenerateMenuVO menuVO)
    {
        menuVOs.Add(menuVO);
    }

    /// <summary>
    /// メニューを削除します。
    /// </summary>
    /// <param name="index">削除対象Index</param>
    public void RemoveAt(int index)
    {
        menuVOs.RemoveAt(index);
    }

    #endregion
}

