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
/// MenuSetVO の概要の説明です
/// </summary>
[Serializable]
public class GenerateMenuSetVO
{
    #region フィールド変数
    /// <summary>
    /// メニューグループ情報
    /// </summary>
    private List<GenerateMenuVO> menuVOs;

    #endregion

    #region コンストラクタ
    /// <summary>
    /// デフォルトコンストラクタ
    /// </summary>
    public GenerateMenuSetVO()
    {
        this.menuVOs = new List<GenerateMenuVO>();
    }

    #endregion

    #region プロパティ

    /// <summary>
    /// メニューグループ情報
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
    /// メニューグループを追加します。
    /// </summary>
    /// <param name="menuGrpVO">メニューグループVO</param>
    public void Add(GenerateMenuVO menuGrpVO)
    {
        menuVOs.Add(menuGrpVO);
    }

    /// <summary>
    /// メニューグループを削除します。
    /// </summary>
    /// <param name="index">削除対象Index</param>
    public void RemoveAt(int index)
    {
        menuVOs.RemoveAt(index);
    }

    #endregion

}
