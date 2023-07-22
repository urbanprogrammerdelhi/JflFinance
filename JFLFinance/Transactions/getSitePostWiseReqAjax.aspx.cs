// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getSitePostWiseReqAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getSitePostWiseReqAjax.
/// </summary>
public partial class Transactions_getSitePostWiseReqAjax : BasePage //System.Web.UI.Page
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

        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();

        int intAsmtAutoId = 0;
        string strFDate, strTDate, strAsmtCode,bgcolour;
        strFDate = Request.QueryString["Date1"];
        strTDate = Request.QueryString["Date2"];
        intAsmtAutoId = int.Parse(Request.QueryString["AsmtId"]);

        if (intAsmtAutoId == 0)
        {
            Response.Write("Invalid AsmtCode");
            Response.End();
        }
        strAsmtCode = Request.QueryString["AsmtCode"];

        ds = objRost.AsmtItemsGet(strFDate, strTDate, intAsmtAutoId, int.Parse(BaseLocationAutoID),strAsmtCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<table border=0 style='font-family:Verdana; font-size:10px; cellpadding:0; cellspacing:0;width:920px' >");
            int a = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Response.Write("<Tr onClick=javascript:SitePost_Click('" + i + "','" + ds.Tables[0].Rows[i]["PdLine"].ToString() + "','0') >");
                Response.Write("<Td style='width:120px' id='Pd" + i + "'>" + ds.Tables[0].Rows[i]["PdLine"].ToString() + "</td>");
                Response.Write("<Td style='width:126px' id='Site" + i + "'>" + ds.Tables[0].Rows[i]["Site"].ToString() + "</td>");
                Response.Write("<Td style='width:146px' id='Post" + i + "'>" + ds.Tables[0].Rows[i]["Post"].ToString() + "<input type=hidden id='MinWages" + i + "' value='" + ds.Tables[0].Rows[i]["MinWages"].ToString() + "' ><input type=hidden id='SoNo" + i + "' value='" + ds.Tables[0].Rows[i]["SoNo"].ToString() + "' ><input type=hidden id='SoAmendNo" + i + "' value='" + ds.Tables[0].Rows[i]["SoAmendNo"].ToString() + "' ><input type=hidden id='SoLineNo" + i + "' value='" + ds.Tables[0].Rows[i]["SoLineNo"].ToString() + "' ></td>");
                ////Response.Write("<Td style='width:120px' id='Designation" + i + "'><input type=hidden id='MinWages" + i + "' value='" + ds.Tables[0].Rows[i]["MinWages"].ToString() + "' >" + ds.Tables[0].Rows[i]["Designation"].ToString() + "</td>");
                ////Response.Write("<Td style='width:20px' id='Designation" + i + "'> &nbsp; </td>");
                Response.Write("<Td style='width:620px'><table border=0 style='width:620px;cellpadding:0; cellspacing:0'><tr>");
                for (int j = 11; j < ds.Tables[0].Columns.Count; j++)
                {
                    a = a + 1;
                    Response.Write("<Td align='center' style='font-size:9px;width:25px'>" + ds.Tables[0].Rows[i][j].ToString() + "</td>");
                }
                a = (31-a)*20+1;

                Response.Write("<td width='" + a + "'><img style='width: " + a + "px; height: 5px;' src='../Images/spacer.gif'></img></td></tr></table></Td>");
                a = 0;
                Response.Write("</Tr>");
            }
            Response.Write("</Table>");
            Response.Write("<input type='hidden' id='firstSitePost' value='" + ds.Tables[0].Rows[0]["PdLine"].ToString() + "' >");
            Response.Write("<input type='hidden' id='hid_countPdLines' value='" + ds.Tables[0].Rows.Count.ToString() + "' >");
        }
        else
        {
            Response.Write("No Site Post!");
        }
        Response.End();

    }
}
