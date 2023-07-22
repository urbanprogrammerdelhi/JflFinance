// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="overWriteShiftAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_overWriteShiftAjax.
/// </summary>
public partial class Transactions_overWriteShiftAjax : BasePage//System.Web.UI.Page
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
        string strAsmtCode = Request.QueryString["AsmtCode"];
        string strEmpNo = Request.QueryString["EmpNo"];
        string DutyDate = Request.QueryString["DutyDate"];
         int strAsmtMasterAutoID =int.Parse(Request.QueryString["AsmtMasterAutoID"].ToString());
         int strPDLineNo = int.Parse(Request.QueryString["PDLineNo"].ToString());
         string strShiftCode = Request.QueryString["ShiftCode"];
         int strRosterId = int.Parse(Request.QueryString["RosterId"].ToString());
        //
         string strRoleCode = Request.QueryString["RoleCode"];
         string strDesgCode = Request.QueryString["EmpDesg"];
         string strDutyTypeCode = Request.QueryString["DTCode"];
         string strShiftPatternCode = Request.QueryString["ShiftPatCode"];
         string Position = Request.QueryString["Pos"];
         string strIsDefaultSite = "1";//Request.QueryString["DefaultSite"];
         string OpsShift = Request.QueryString["Shift"];
         string strSORank = Request.QueryString["SORank"];
         string strShiftID = Request.QueryString["strShiftID"];
        //
        DateTime dt1;
        dt1 = DateTime.Parse(DutyDate);
        int intWeekNo = weekNumByDate(dt1);
        string strWeekNo = intWeekNo.ToString();



        DataSet ds = new DataSet();
        BL.Roster objRost = new BL.Roster();
        ds = objRost.ScheduleRosterShiftOverwrite(strAsmtCode, strEmpNo, DateTime.Parse(DutyDate), strShiftCode, strPDLineNo, strAsmtMasterAutoID, strRosterId, BaseLocationAutoID, strWeekNo, strRoleCode, strDesgCode, strDutyTypeCode, strShiftPatternCode, Position, strIsDefaultSite, OpsShift, strSORank,BaseUserID);

        if (Convert.ToString(ds.Tables[0].Rows[0]["MessageID"]) == "56")
        {
            Response.Write("<table width=450 border=1 >");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Response.Write("<tr id='tr" + i + "' style='display: block'><td>");
                Response.Write("<div style='width:120px;display:none' id='lblMsgShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["MessageString"] + "</div>");
                Response.Write("<div style='width:120px' id='lbl_MsgShiftDuplicate" + i + "' >" +   ResourceValueOfKey_Get(ds.Tables[0].Rows[i]["MessageString"].ToString().Trim())   + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:120px' id='lblAsmtCodeShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["AsmtCode"] + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:14px' id='lblShiftCodeShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["ShiftCode"] + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:90px' id='lblDutyDateShiftDuplicate" + i + "' >" + DateTime.Parse(ds.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:70px' id='lblEmpNoShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["EmployeeNumber"].ToString() + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:60px' id='lblTimeFromShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["TimeFrom"].ToString() + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:60px' id='lblTimeToShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["TimeTo"].ToString() + "</div>");
                Response.Write("</td><td>");
               // Response.Write("<input type='checkbox' id='chk" + i + "' />");
                Response.Write("<input type='hidden' id='lblRostIdDuplicate" + i + "' value='" + ds.Tables[0].Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                Response.Write("<input type='hidden' id='lblColIndexDuplicate" + i + "' value='" + (i + 1) + "'    />");
                Response.Write("<input type='hidden' id='hidShiftID" + i + "' value='" + strShiftID + "'    />");
                Response.Write("</td></tr>");
            }
            Response.Write("</table >");
            Response.End();
        }
        else
        {
            Response.Write("<table width=450 border=1 >");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Response.Write("<tr id='tr" + i + "' style='display: none'><td>");
                Response.Write("<div style='width:120px;display:none' id='lblMsgShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["MessageString"] + "</div>");
                Response.Write("<div style='width:120px' id='lbl_MsgShiftDuplicate" + i + "' >" + ResourceValueOfKey_Get(ds.Tables[0].Rows[i]["MessageString"].ToString().Trim()) + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:120px' id='lblAsmtCodeShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["AsmtCode"] + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:14px' id='lblShiftCodeShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["ShiftCode"] + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:90px' id='lblDutyDateShiftDuplicate" + i + "' >" +ds.Tables[0].Rows[i]["DutyDate"].ToString() + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:70px' id='lblEmpNoShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["EmployeeNumber"].ToString() + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:60px' id='lblTimeFromShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["TimeFrom"].ToString() + "</div>");
                Response.Write("</td><td>");
                Response.Write("<div style='width:60px' id='lblTimeToShiftDuplicate" + i + "' >" + ds.Tables[0].Rows[i]["TimeTo"].ToString() + "</div>");
                Response.Write("</td><td>");
              //  Response.Write("<input type='checkbox' id='chk" + i + "' />");
              //  Response.Write("<input type='hidden' id='lblRostIdDuplicate" + i + "' value='" + ds.Tables[0].Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                Response.Write("<input type='hidden' id='hidShiftID" + i + "' value='" + strShiftID + "'    />");
                Response.Write("</td></tr>");
            }
            Response.Write("</table >");
            Response.End();

        }
    }
    /// <summary>
    /// Weeks the number by date.
    /// </summary>
    /// <param name="dtDate">The dt date.</param>
    /// <returns>System.Int32.</returns>
    private int weekNumByDate(DateTime dtDate)
    {
        int weeknum = 1;
        weeknum = dtDate.Day / 7;
        if ((dtDate.Day % 7) > 0)
        {
            weeknum = weeknum + 1;
        }

        return weeknum;
    }
}
