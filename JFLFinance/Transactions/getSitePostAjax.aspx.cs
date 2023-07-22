// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getSitePostAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getSitePostAjax.
/// </summary>
public partial class Transactions_getSitePostAjax : BasePage //System.Web.UI.Page
{

    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>

    private bool IsReadAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        string strAsmtCode = Request.QueryString["Asmt"];
        string strAsmtId = Request.QueryString["AsmtId"];
        string strDate = Request.QueryString["Date"];
        int intAsmtId = 0;
        if (strAsmtId != "")
        {
            intAsmtId = int.Parse(strAsmtId);
        }
        

        BL.OperationManagement objOperationManagement = new BL.OperationManagement();        
        DataSet dsAsmtSitePost = new DataSet();
        dsAsmtSitePost = objOperationManagement.AsmtSitePostGet(intAsmtId, int.Parse(BaseLocationAutoID), strDate);
        if (dsAsmtSitePost.Tables[0].Rows.Count > 0)
        {
            Response.Write("<AsmtSitePost>");
            for (int i = 0; i < dsAsmtSitePost.Tables[0].Rows.Count; i++)
            {
                Response.Write("<SitePost>" + dsAsmtSitePost.Tables[0].Rows[i]["SitePost"].ToString() + "</SitePost>");
                Response.Write("<PDLineNO>" + dsAsmtSitePost.Tables[0].Rows[i]["PDLineNO"].ToString() + "</PDLineNO>");
                Response.Write("<ShiftTimes>" + dsAsmtSitePost.Tables[0].Rows[i]["ShiftTimes"].ToString() + "</ShiftTimes>");
                Response.Write("<RoleCode>" + dsAsmtSitePost.Tables[0].Rows[i]["RoleCode"].ToString() + "</RoleCode>");

            }
            Response.Write("</AsmtSitePost>");
            Response.End();
        }
        else
        {
            Response.Write("0");
            Response.End();
        }


    }
}
