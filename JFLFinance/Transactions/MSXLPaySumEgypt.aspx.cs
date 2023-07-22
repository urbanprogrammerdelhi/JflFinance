// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="MSXLPaySumEgypt.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_MSXLPaySumEgypt.
/// </summary>
public partial class Transactions_MSXLPaySumEgypt : BasePage//System.Web.UI.Page
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
        string strDivision = Request.QueryString["DivisionCode"].ToString();
        string strBranch = Request.QueryString["BranchCode"].ToString();
        string FromDate = Request.QueryString["FromDate"].ToString();
        string ToDate = Request.QueryString["ToDate"].ToString();

        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        ds = objRoster.GeneratePaysumEgypt(BaseCompanyCode, strDivision, strBranch, FromDate, ToDate, BaseUserID);

        #region To Export to Excel From Dataset
        /******************* Export to Excel Format ******************************************/

        
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=PaySum.xls");
        Response.ContentType = "application/octet-stream";
        Response.Write("<html>");
        Response.Write("<head>");
        Response.Write("<style type='text/css'>");
        Response.Write("</style>");
        Response.Write("</head>");
        Response.Write("<body>");
        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
        Response.Write("<tr>");
        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            Response.Write("<td>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
        }
        //*******************************
        Response.Write("</tr>");
        Response.Write("</table>");
        Response.Write("<table width=200 border=1  cellspacing=0 cellpadding=2>");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Response.Write("<tr width='100%'>");
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                Response.Write("<td>" + ds.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
            }
            Response.Write("</tr>");
        }
        //********************************************
        Response.Write("</table>");
        Response.Write("</body>");
        Response.Write("</html>");
        /*******************End OF Export to Excel Format ******************************************/

        #endregion
    }

}
