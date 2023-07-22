// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getShiftPatternAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getShiftPatternAjax.
/// </summary>
public partial class Transactions_getShiftPatternAjax : BasePage //System.Web.UI.Page
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
        string strLocAutoID = Request.QueryString["LocAutoID"];
        string strAsmtCode = Request.QueryString["AsmtCode"];
        string strPDLineNo = Request.QueryString["PDLineNo"];

        BL.Roster objRoster = new BL.Roster();
        DataTable dt1 = new DataTable();
        dt1 = objRoster.ShiftPatternGet(int.Parse(BaseLocationAutoID), strAsmtCode, int.Parse(strPDLineNo)).Tables[0];
        int j = 0;
        string dt2 = "";

        if (dt1.Rows.Count > 0)
        {
            Response.Write("<div style='width: 400px; height: 120px; overflow: scroll ' align='left' >");
            Response.Write("<Table>");
            //Response.Write("<tr>");
            //Response.Write("<td>S.No</td>");
            //Response.Write("<td>PatternID</td>");
            //Response.Write("<td>Pattern</td>");
            //Response.Write("</tr>");

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                j = i + 1;
                Response.Write("<tr>");
                //Response.Write("<td>"+j+"</td>");
                Response.Write("<td><a href='#' onclick=javascript:clickShiftPatCode('" + dt1.Rows[i]["ShiftPatternCode"].ToString() + "') >" + dt1.Rows[i]["ShiftPatternCode"].ToString() + "</a></td>");
                Response.Write("<td>" + dt1.Rows[i]["ShiftPattern"].ToString() + "</td>");
                Response.Write("</tr>");

                dt2 = dt2 + "<option value='" + dt1.Rows[i]["ShiftPatternCode"].ToString() + "'>" + dt1.Rows[i]["ShiftPattern"].ToString() + "</option>";

            }

            Response.Write("</table>");
            Response.Write("<select id='ddlShiftPat' style='display:none' >" + dt2 + "</select>");
            Response.Write("</div>");
            Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='#' onclick=javascript:closeShiftpat('divShiftPattern')>"+Resources.Resource.Close +"</a>");

            Response.End();
        }
        else
        {
            Response.Write(Resources.Resource.NoShiftPatterndefined);
            Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='#' onclick=javascript:closeShiftpat('divShiftPattern')>" + Resources.Resource.Close + "</a>");
            Response.End();
        }
    }
}
