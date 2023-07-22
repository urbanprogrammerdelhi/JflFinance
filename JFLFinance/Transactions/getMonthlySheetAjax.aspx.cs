// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getMonthlySheetAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getMonthlySheetAjax.
/// </summary>
public partial class Transactions_getMonthlySheetAjax : BasePage //System.Web.UI.Page
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
        if (IsReadAccess == true)
        {
            string strEmpNo = Request.QueryString["EmpNo"];
            string strASmtCode = Request.QueryString["Asmt"];
            string strFromDate = Request.QueryString["Date1"];
            string strToDate = Request.QueryString["Date2"];
            int intPdLineNo = int.Parse(Request.QueryString["Pd"].ToString());
            string strNewRow = Request.QueryString["NewRow"];
            string strShiftCode = Request.QueryString["ShiftCode"];
            
            string strNewRowDate = string.Empty;
            if (int.Parse(strNewRow) == 1)
            {
                strNewRowDate = Request.QueryString["NewRowDate"];
            }
            int intNewRow = 0;
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DataSet dsDutyType = new DataSet();
            dsDutyType = objMastersManagement.DutyTypeGetAll(BaseCompanyCode);
            string dt4 = "";
            // string dt8 = "";
            string strDutydate = "";
            BL.Roster objRost = new BL.Roster();
            DataSet ds = new DataSet();
            int count = 1;
            string strWO = "";
            string strTitle = "";
            string strWOTitle = "";

            if (strASmtCode != "")
            {
                ds = objRost.EmployeeMonthlyRotaGet(int.Parse(BaseLocationAutoID), strASmtCode, intPdLineNo, strFromDate, strToDate, strEmpNo, strShiftCode);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<table cellpadding=0 cellspacing=0 >");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["WO"].ToString() == "1")
                        {
                            strWO = "background:yellow";
                            strWOTitle = Resources.Resource.WeekOff;
                        }
                        else
                        {
                            strWO = "background:pink";
                            //strTitle = Resources.Resource.Absent;
                            strTitle = ResourceValueOfKey_Get(ds.Tables[0].Rows[i]["WO"].ToString()); //Ticket No:147926 Modified By Manish  Dated :17-Mar-2010
                        }
                        if (ds.Tables[0].Rows[i]["WO"].ToString() == "0")
                        {
                            strWO = "";
                            strTitle = "";
                        }
                        string dt2 = string.Empty;
                        strDutydate = DateTime.Parse(ds.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy");
                        //Ticket No:147926 Modified By Manish  Dated :17-Mar-2010
                        if (ds.Tables[0].Rows[i]["WO"].ToString() == "1")
                        {
                            Response.Write("<Tr><td><input type='text' title='" + strWOTitle + "' class='csstxtbox' disabled id='SNo" + i + "' value='" + (count) + "' style='width:20px;" + strWO + "'  />");
                        }
                        else
                        {
                            Response.Write("<Tr><td><input type='text' title='" + strTitle + "' class='csstxtbox' disabled id='SNo" + i + "' value='" + (count) + "' style='width:20px;" + strWO + "'  />");
                        }
                        //END OF Ticket No:147926 Modified By Manish  Dated :17-Mar-2010
                        Response.Write("<input type='text' disabled id='txtDutyDate" + i + "' style='width:90px;text-align: center' class='csstxtbox' value='" + strDutydate + "'  />");
                        if (IsWriteAccess == true)
                        {
                            Response.Write("<input type='text' id='txtShift" + i + "' style='width:40px;text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["ShiftCode"] + "' onchange=javascript:getStdShift('" + i + "')  onkeyup=javascript:if(event.keyCode==13){FunctionCallOnEnterKeyDown('ShiftCode','" + i + "')}   onKeyDown=javascript:FunctionCallOnKeyDown('ShiftCode','" + i + "')  />");
                            Response.Write("<input type='text' id='txtTimeFrom" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeFrom"] + "' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','F') />");
                            Response.Write("<input type='text' id='txtTimeTo" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeTo"] + "' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','T') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["DutyHrs"] + "' />");
                        }
                        else
                        {
                            Response.Write("<input type='text' disabled id='txtShift" + i + "' style='width:40px;text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["ShiftCode"] + "' onchange=javascript:getStdShift('" + i + "')  onkeyup=javascript:if(event.keyCode==13){FunctionCallOnEnterKeyDown('ShiftCode','" + i + "')}   onKeyDown=javascript:FunctionCallOnKeyDown('ShiftCode','" + i + "')  />");
                            Response.Write("<input type='text' disabled id='txtTimeFrom" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeFrom"] + "' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','F') />");
                            Response.Write("<input type='text' disabled id='txtTimeTo" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeTo"] + "' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','T') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["DutyHrs"] + "' />");
                        }
                        Response.Write("<input type='text' id='txtEmpRole" + i + "' style='width:125px' class='csstxtbox'  value='" + ds.Tables[0].Rows[i]["RoleDesc"] + "' onblur=javascript:searchRole('" + i + "')  onkeyup=javascript:searchRole('" + i + "') />");
                        Response.Write("<input type='hidden' id='hid_RoleId" + i + "' value='" + ds.Tables[0].Rows[i]["RoleCode"] + "' />");
                        Response.Write("<input type='hidden' id='hidRosterAutoID" + i + "' value='" + ds.Tables[0].Rows[i]["RosterAutoID"].ToString() + "' />");
                        Response.Write("<input type='hidden' id='hid_DutyType" + i + "' value='" + ds.Tables[0].Rows[i]["DutyTypeCode"] + "' />");
                        for (int z = 0; z < dsDutyType.Tables[0].Rows.Count; z++)
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[i]["DutyTypeCode"]).Trim() != Convert.ToString(dsDutyType.Tables[0].Rows[z]["DutyTypeCode"]).Trim() && ds.Tables[0].Rows[i]["DutyTypeDesc"] != " ")
                            {
                                dt2 = dt2 + "<option value='" + dsDutyType.Tables[0].Rows[z]["DutyTypeCode"] + "'>" + dsDutyType.Tables[0].Rows[z]["DutyTypeDesc"] + "</option>";
                            }
                        }
                        dt4 = dt4 + "<option value='" + ds.Tables[0].Rows[i]["DutyTypeCode"] + "' Selected>" + ds.Tables[0].Rows[i]["DutyTypeDesc"] + "</option>";
                        if (IsWriteAccess == true)
                        {
                            Response.Write("<select id='ddlDutyType" + i + "' style='width:90px;vertical-align:baseline' class='cssDropDown' onKeyDown=javascript:FunctionCallOnKeyDown('DutyType','" + i + "') >" + dt2 + dt4 + "</select>");
                        }
                        else
                        {
                            Response.Write("<select disabled id='ddlDutyType" + i + "' style='width:90px;vertical-align:baseline' class='cssDropDown' onKeyDown=javascript:FunctionCallOnKeyDown('DutyType','" + i + "') >" + dt2 + dt4 + "</select>");
                        }
                        dt4 = "";
                        dt2 = "";
                        if (strDutydate == DateFormat(strNewRowDate))
                        {
                            count++;
                            Response.Write("<Tr><td><input type='text' class='csstxtbox' disabled id='SNo" + (int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1) + "' value='" + (count) + "' style='width:20px' />");
                            Response.Write("<input type='text' disabled id='txtDutyDate" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:90px;text-align: center' class='csstxtbox' value='" + strDutydate + "'  />");
                            if (IsWriteAccess == true)
                            {
                                Response.Write("<input type='text' id='txtShift" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:40px;text-align: center' class='csstxtbox' value='" + ' ' + "' onchange=javascript:getStdShift('" + (int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1) + "')  onkeyup=javascript:if(event.keyCode==13){FunctionCallOnEnterKeyDown('ShiftCode','" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "')}   onKeyDown=javascript:FunctionCallOnKeyDown('ShiftCode','" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "')/>");
                                Response.Write("<input type='text' id='txtTimeFrom" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + "00:00" + "' onblur=javascript:IsValidTime1('txtTimeFrom" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','txtTimeTo" + i + "','txtDutyHrs" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','F') />");
                                Response.Write("<input type='text' id='txtTimeTo" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + "00:00" + "' onblur=javascript:IsValidTime1('txtTimeTo" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','txtTimeFrom" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','txtDutyHrs" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','T') />");
                            }
                            else
                            {
                                Response.Write("<input type='text' disabled id='txtShift" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:40px;text-align: center' class='csstxtbox' value='" + ' ' + "' onchange=javascript:getStdShift('" + (int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1) + "')  onkeyup=javascript:if(event.keyCode==13){FunctionCallOnEnterKeyDown('ShiftCode','" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "')}   onKeyDown=javascript:FunctionCallOnKeyDown('ShiftCode','" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "')/>");
                                Response.Write("<input type='text' disabled id='txtTimeFrom" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + "00:00" + "' onblur=javascript:IsValidTime1('txtTimeFrom" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','txtTimeTo" + i + "','txtDutyHrs" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','F') />");
                                Response.Write("<input type='text' disabled id='txtTimeTo" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + "00:00" + "' onblur=javascript:IsValidTime1('txtTimeTo" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','txtTimeFrom" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','txtDutyHrs" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "','T') />");
                            }
                            //Response.Write("<input type='text' id='txtTimeTo" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + "00:00" + "' onblur=javascript:IsValidTime1('txtTimeTo" + (i + 1) + "','txtTimeFrom" + (i + 1) + "','txtDutyHrs" + (i+1) + "','T') /> ");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + "00:00" + "' />");
                            Response.Write("<input type='text' id='txtEmpRole" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:125px' class='csstxtbox'  value='" + ds.Tables[0].Rows[i]["RoleDesc"] + "' onblur=javascript:searchRole('" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "')  onkeyup=javascript:searchRole('" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "')  />");
                            Response.Write("<input type='hidden' id='hid_RoleId" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' value='" + ds.Tables[0].Rows[i]["RoleCode"] + "' />");
                            Response.Write("<input type='hidden' id='hidRosterAutoID" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' value='" + 0 + "' />");
                            Response.Write("<input type='hidden' id='hid_DutyType" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' value='" + ds.Tables[0].Rows[0]["DutyTypeCode"] + "' />");
                            for (int z = 0; z < dsDutyType.Tables[0].Rows.Count; z++)
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["DutyTypeCode"]).Trim() != Convert.ToString(dsDutyType.Tables[0].Rows[z]["DutyTypeCode"]).Trim() && ds.Tables[0].Rows[i]["DutyTypeDesc"] != " ")
                                {
                                    dt2 = dt2 + "<option value='" + dsDutyType.Tables[0].Rows[z]["DutyTypeCode"] + "'>" + dsDutyType.Tables[0].Rows[z]["DutyTypeDesc"] + "</option>";
                                }
                            }
                            dt4 = dt4 + "<option value='" + ds.Tables[0].Rows[0]["DutyTypeCode"] + "' Selected>" + ds.Tables[0].Rows[0]["DutyTypeDesc"] + "</option>";
                            if (IsWriteAccess == true)
                            {
                                Response.Write("<select id='ddlDutyType" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:90px;vertical-align:baseline' class='cssDropDown' onKeyDown=javascript:FunctionCallOnKeyDown('DutyType','" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "') >" + dt2 + dt4 + "</select>");
                            }
                            else
                            {
                                Response.Write("<select disabled id='ddlDutyType" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "' style='width:90px;vertical-align:baseline' class='cssDropDown' onKeyDown=javascript:FunctionCallOnKeyDown('DutyType','" + int.Parse(ds.Tables[0].Rows.Count.ToString()) + 1 + "') >" + dt2 + dt4 + "</select>");
                            }
                            dt4 = "";
                            Response.Write("</td></tr>");

                        }
                        count++;
                    }
                    Response.Write("<tr><td><input type='hidden' id='hidTotalRow' value='" + (ds.Tables[0].Rows.Count + intNewRow) + "' /></td></tr>");
                    Response.Write("</table>");
                    Response.End();
                }
            }
        }
        else
        {
            Response.Write(Resources.Resource.NOAccessRights);
            Response.End();
        }
    }
}
