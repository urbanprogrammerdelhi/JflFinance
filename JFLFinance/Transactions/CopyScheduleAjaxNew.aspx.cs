// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="CopyScheduleAjaxNew.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_CopyScheduleAjaxNew.
/// </summary>
public partial class Transactions_CopyScheduleAjaxNew : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string strSchRosterAutoID = Request.QueryString["SchRosterAutoID"];
        string strEmployeeNumber = Request.QueryString["strEmployeeNumber"];
        string strCopyToDate = Request.QueryString["CopyToDate"];
        string strAsmtCode = Request.QueryString["AsmtCode"];
        string strMaxDate = Request.QueryString["MaxDate"];

        if (strMaxDate != "")
        {
            if (DateTime.Parse(strCopyToDate) > DateTime.Parse(strMaxDate))
            {
                Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + -1 + "'    />");
                Response.Write("Copy Date is Greater than " + strMaxDate); Response.End();
            }
        }
        int d = 0;
        BL.Roster objRost = new BL.Roster();
        DataTable dsSubmit = new DataTable();
        dsSubmit = objRost.ScheduleRosterEmployeeWiseCopy(strSchRosterAutoID, BaseLocationAutoID, strCopyToDate, strAsmtCode, BaseUserID);
        // Response.Write("");
        //Response.End();

        if (dsSubmit != null && dsSubmit.Rows.Count > 0)
        {
            if (dsSubmit.Rows[0]["MessageString"].ToString() == "Authorized")
            {
                Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + -1 + "'    />");
                Response.Write("Authorized"); Response.End();
            }
            Response.Write("<table width=650 border=1 style='font-size:11px' >");
            for (int i = 0; i < dsSubmit.Rows.Count; i++)
            {
                if (dsSubmit.Rows[i]["MessageString"].ToString().Trim().ToLower() == "Insert".Trim().ToLower())
                {

                    Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                    Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + "Insert" + "</div>");
                    Response.Write("</td><td>");
                }
                else
                {
                    //if (dsSubmit.Rows[i]["MessageString"].ToString() == "Duplicate" || dsSubmit.Rows[i]["MessageString"].ToString() == "Converted")
                    //{
                    Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                    Response.Write("<div style='width:110px' id='lblMsgShiftDuplicate" + d + "' >" + ResourceValueOfKey_Get(dsSubmit.Rows[i]["MessageString"].ToString()) + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:110px' id='lblDupAsmtCode" + d + "' >" + dsSubmit.Rows[i]["AsmtCode"] + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:14px' id='lblDupShiftCode" + d + "' >" + dsSubmit.Rows[i]["ShiftCode"] + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:80px' id='lblDupDutyDate" + d + "' >" + DateTime.Parse(dsSubmit.Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:60px' id='lblDupEmpNo" + d + "' >" + strEmployeeNumber + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:50px' id='lblDupTimeFrom" + d + "' >" + dsSubmit.Rows[i]["TimeFrom"].ToString() + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:50px' id='lblDupTimeTo" + d + "' >" + dsSubmit.Rows[i]["TimeTo"].ToString() + "</div>");
                    Response.Write("</td><td>");
                    if (dsSubmit.Rows[i]["MessageString"].ToString() == "Duplicate")
                    {
                        Response.Write("<input type='checkbox' id='chk" + d + "' />");

                    }
                    //else
                    //{
                    //    Response.Write(Resources.Resource.Converted);
                    //}
                    Response.Write("<input type='hidden' id='HFMessageID" + d + "' value='" + dsSubmit.Rows[i]["MessageID"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='HFTimeFromToOverwrite" + d + "' value='" + dsSubmit.Rows[i]["TimeFromToOverwrite"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='HFToTimeToOverwrite" + d + "' value='" + dsSubmit.Rows[i]["ToTimeToOverwrite"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='HFAsmtCodeToOverwrite" + d + "' value='" + dsSubmit.Rows[i]["AsmtCodeToOverwrite"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='HFRoleCodeToOverWrite" + d + "' value='" + dsSubmit.Rows[i]["RoleCodeToOverWrite"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='HFDutyTypeCodeToOverWrite" + d + "' value='" + dsSubmit.Rows[i]["DutyTypeCodeToOverWrite"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='HFPDlineNoToOverwrite" + d + "' value='" + dsSubmit.Rows[i]["PDlineNoToOverwrite"].ToString() + "'    />");


                    Response.Write("<input type='hidden' id='HFDupSchRosterAutoID" + d + "' value='" + dsSubmit.Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='lblColIndex_dup" + d + "' value='" + (i + 1) + "'    />");
                    d = d + 1;
                    // }
                }

            }
            Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + dsSubmit.Rows.Count + "'    />");
            Response.Write("</td></tr>");
            Response.Write("</table >");
            Response.End();
        }
        else
        {
            Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + 0 + "'    />"); // Value is 0 so that it doest give error on return
            Response.Write("error!");
            Response.End();
        }

    }

}
