// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getScheduleRosterSheetAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getScheduleRosterSheetAjax.
/// </summary>
public partial class Transactions_getScheduleRosterSheetAjax : BasePage //System.Web.UI.Page
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
            int intAsmtAutoId = 0;
            int intPdlineNo = 0;
            int intLocationId, soline;
            string strFDate = string.Empty;
            string strTDate = string.Empty;
            string strAsmtCode = string.Empty;
            string strPdline = string.Empty;
            string strNewPDLine = string.Empty;
            intLocationId = int.Parse(BaseLocationAutoID);
            strFDate = Request.QueryString["Date1"];
            strTDate = Request.QueryString["Date2"];
            intAsmtAutoId = int.Parse(Request.QueryString["AsmtId"]);
            strNewPDLine = Request.QueryString["NewPDLine"];
            int Count = 0;
            if (DateTime.Parse(strFDate) <= DateTime.Parse(strTDate))
            {
                if (intAsmtAutoId == 0)
                {
                    Response.Write("Invalid AsmtCode");
                    Response.End();
                }
                strAsmtCode = Request.QueryString["AsmtCode"];
                strPdline = Request.QueryString["pdline"];
                int intArow = 0;
                string strARow = Request.QueryString["Arow"];
                if (strARow != "")
                {
                    intArow = int.Parse(strARow);
                }
                if (strPdline != "")
                {
                    intPdlineNo = int.Parse(strPdline);
                }
                int intCol = 0;
                BL.Roster objRost = new BL.Roster();
                DataSet ds = new DataSet();
                ds = objRost.AsmtItemDetailGet(intAsmtAutoId, strAsmtCode, int.Parse(BaseLocationAutoID), 1, intPdlineNo, strFDate, strTDate);
                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                DataSet dsAsmtSitePost = new DataSet();
                dsAsmtSitePost = objOperationManagement.AsmtSitePostGet(intAsmtAutoId, int.Parse(BaseLocationAutoID), strFDate);
                string dt2 = "";
                string strddlSitepost = "";

                DataTable dtPDLineStartDate = new DataTable();
                DataTable dtEmpDate = new DataTable();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //change cellspacing and padding on 14-jan-2010 by manish
                    Response.Write("<table border='0' cellpadding='0' cellspacing='0'>");
                    //Response.Write("<table border='0' cellpadding='1' cellspacing='1'>");
                    Response.Write("<Tr>");
                    if (ds.Tables[0].Rows.Count > 13)   
                    { Response.Write("<td width='16px' >&nbsp;</td>"); }
                    Response.Write("<td width='17px' ><input type='text' style='width: 17px' class='csstxtbox' disabled id='SNo' value='" + Resources.Resource.SerialNumber + "' style='width:20px' /></td>");
                    Response.Write("<td width='140px'><input type='text' style='width: 140px' class='csstxtbox' disabled id='ShiftSite' value='" + Resources.Resource.Shift + "-" + Resources.Resource.Site + "-" + Resources.Resource.SORank + "' style='width:20px' /></td>");
                    Response.Write("<td width='65px'><input type='text' style='width: 65px' class='csstxtbox' disabled id='ShiftTimes' value='" + Resources.Resource.Time + "'/></td>");
                    Response.Write("<td width='60px'><input type='text' style='width: 60px' class='csstxtbox' disabled id='EmpNo' value='" + Resources.Resource.EmployeeNumber + "'/></td>");
                    Response.Write("<td width='17px'></td>");
                    Response.Write("<td width='150px'><input type='text' style='width: 150px' class='csstxtbox' disabled id='Name' value='" + Resources.Resource.Name + "' /></td>");
                    Response.Write("<td width='100px'><input type='text' style='width: 100px' class='csstxtbox' disabled id='Desig' value='" + Resources.Resource.Designation + "' /></td>");
                    Response.Write("<td width='18px'><input type='text' style='width: 18px' class='csstxtbox' disabled id='Shift' value='" + Resources.Resource.Position + "'  /></td>");
                    Response.Write("<td width='60px'><input type='text' style='width: 60px' class='csstxtbox' disabled id='TFrom' value='" + Resources.Resource.ShiftPattern + "'/></td>");
                    for (int j = 12; j < ds.Tables[0].Columns.Count; j++)
                    {
                        intCol = int.Parse(DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()).ToString("dd"));

                        if (intCol > 9)
                        {
                            Response.Write("<td width='18px'><input type='text' align='center' style='width: 18px' class='csstxtbox' disabled id='TFrom' value='" + intCol + "'/></td>");
                            //Response.Write(intCol + "<img width=13px height=1px src='../Images/spacer.gif'>");
                        }
                        else
                        {
                            Response.Write("<td width='18px'><input type='text' style='width: 18px' class='csstxtbox' disabled id='TFrom' value='" + "0" + intCol + "'/></td>");
                            //Response.Write("0" + intCol + "<img width=13px height=1px src='../Images/spacer.gif'>");
                        }
                    }
                    Response.Write("</Tr>");
                    Response.Write("</table >");
                    //                Response.Write("<table >");
                    ////Code Commented By Lokesh on 21-DEc-2009

                    ////////Response.Write("<table >");
                    ////////Response.Write("<table ><Tr><Td>");
                    ////////Response.Write("&nbsp;&nbsp;" + Resources.Resource.SerialNumber + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + Resources.Resource.Shift + "-" + Resources.Resource.Site + "-" + Resources.Resource.SORank1 + "<img width=40px height=1px src='../Images/spacer.gif'>" + Resources.Resource.EmployeeNumber + " </img><img width=60px height=1px src='../Images/spacer.gif'>" + Resources.Resource.Name + "</img>");
                    ////////Response.Write("<img width=105px height=1px src='../Images/spacer.gif'>" + Resources.Resource.Designation +" </img>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Resources.Resource.Position  + "&nbsp;" + Resources.Resource.ShiftPattern + " &nbsp;&nbsp;");
                    ////////for (int j = 10; j < ds.Tables[0].Columns.Count; j++)
                    ////////{
                    ////////    intCol = int.Parse(DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()).ToString("dd"));

                    ////////    if (intCol > 9)
                    ////////    {
                    ////////        Response.Write(intCol + "<img width=13px height=1px src='../Images/spacer.gif'>");
                    ////////    }
                    ////////    else
                    ////////    {
                    ////////        Response.Write("0" + intCol + "<img width=13px height=1px src='../Images/spacer.gif'>");
                    ////////    }
                    ////////}
                    ////Code Commented By Lokesh on 21-DEc-2009
                    Response.Write("<div  dir='rtl' id='div_RosterSheet' style='width: 1498px; height: 280px; overflow: Auto'>");
                    Response.Write("<table border='0' cellpadding='0' cellspacing='0' dir='ltr' >");
                    //Response.Write("<table ></Td></Tr>");
                    string strWageRateColour = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Response.Write("<Tr><td><input type='text' class='csstxtbox' disabled id='SNo" + i + "' value='" + (i + 1) + "' style='width:16px' />");
                        if (ds.Tables[0].Rows[i]["EmployeeNumber"].ToString() != "")
                        {
                            Response.Write("<input type='text' disabled id='txtSORank" + i + "' style='width:140px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["SORank"] + "' />");
                        }
                        else
                        {
                            Response.Write("<input type='text' disabled id='txtSORank" + i + "' style='width:140px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["Shift"] + "-" + ds.Tables[0].Rows[i]["SORank"] + "' />");
                        }
                        Response.Write("<input type='text' disabled id='txtShiftTimes" + i + "' style='width:65px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["ShiftTimes"] + "' />");

                        for (int j = 12; j < ds.Tables[0].Columns.Count; j++)
                        {
                            if (ds.Tables[0].Rows[i][j].ToString() != "")
                            {
                                DataView dv = new DataView(ds.Tables[1]);
                                dv.RowFilter = "[PDLineNo]='" + (ds.Tables[0].Rows[i][9].ToString()) + "'";
                                dtPDLineStartDate = dv.ToTable();

                                DataView dvEmpDates = new DataView(ds.Tables[3]);
                                dvEmpDates.RowFilter = "[PDLineNo]='" + (ds.Tables[0].Rows[i][9].ToString()) + "' AND [EmployeeNumber]='" + (ds.Tables[0].Rows[i][1].ToString()) + "'";
                                dtEmpDate = dvEmpDates.ToTable();

                                DataView dvLeave = new DataView(ds.Tables[2]);
                                dvLeave.RowFilter = "[PDLineNo]='" + (ds.Tables[0].Rows[i][9].ToString()) + "' AND [EmployeeNumber]='" + (ds.Tables[0].Rows[i][1].ToString()) + "' AND [LeaveDate]='" + ds.Tables[0].Columns[j].ColumnName.ToString() + "'";
                                DataTable dtLeave = new DataTable();
                                dtLeave = dvLeave.ToTable();
                                if (dtEmpDate.Rows.Count > 0)
                                {
                                    if (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) > DateTime.Parse(dtEmpDate.Rows[0]["DateofResignation"].ToString()) && dtEmpDate.Rows[0]["DateofResignation"].ToString() != "01-01-1900")
                                    {
                                        if (dtEmpDate.Rows.Count > 1)
                                        {
                                            dtEmpDate.Rows[0].Delete();
                                        }
                                    }
                                }
                                string Isconverted = Convert.ToString(ds.Tables[0].Rows[i][j]).Substring(Convert.ToString(ds.Tables[0].Rows[i][j]).LastIndexOf(":") + 1);
                                string shift = Convert.ToString(ds.Tables[0].Rows[i][j]).Substring(0, Convert.ToString(ds.Tables[0].Rows[i][j]).LastIndexOf(":"));
                                if (i == Count)
                                {
                                    strWageRateColour = "";
                                    if (ds.Tables[0].Rows[i]["EmployeeNumber"].ToString() != "")
                                    {
                                        if (decimal.Parse(dtEmpDate.Rows[0]["HrWageRate"].ToString()) > decimal.Parse(dtPDLineStartDate.Rows[0]["MinWages"].ToString()))
                                        {
                                            strWageRateColour = "Red";
                                        }
                                    }

                                    if (Isconverted == "1" || IsWriteAccess != true)
                                    {
                                        Response.Write("<input type='text' id='txtEmpNo" + i + "' style='width:60px;color:" + strWageRateColour + "'  maxlength='6' class='csstxtbox' readonly  value='" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "' onkeyDown=javascript:callEmpName('txtEmpNo" + i + "','" + i + "')   />");
                                        Response.Write("<img id='empsearch" + i + "' disabled alt=" + Resources.Resource.SearchEmployee + " src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + i + "') />");
                                    }
                                    else
                                    {
                                        Response.Write("<input type='text' id='txtEmpNo" + i + "' style='width:60px;color:" + strWageRateColour + "' maxlength='6' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "' onkeyDown=javascript:callEmpName('txtEmpNo" + i + "','" + i + "')   />");
                                        Response.Write("<img id='empsearch" + i + "' alt=" + Resources.Resource.SearchEmployee + "  src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + i + "') />");
                                    }
                                    Response.Write("<input type='text'  id='txtEmpName" + i + "' style='width:150px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeName"] + "' onblur=javascript:func_EmpNameSearch('" + i + "') onkeyup=javascript:func_EmpNameSearch('" + i + "')  />");
                                    Response.Write("<input type='text' disabled id='txtEmpDesignation" + i + "' style='width:100px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["DesignationDesc"] + "' />");
                                    Response.Write("<input type='hidden' id='hidDesignationCode" + i + "' value='" + ds.Tables[0].Rows[i]["DesignationCode"].ToString() + "' />");
                                    if (Isconverted == "1" || IsWriteAccess != true)
                                    {
                                        Response.Write("<input type='text' disabled id='txtPPosition" + i + "' style='width:18px' maxlength='2' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["PatternPosition"] + "' />");
                                        Response.Write("<input type='text' disabled id='txtShiftPattern" + i + "' style='width:60px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["ShiftPatternCode"] + "' ondblclick=javascript:CallShiftPattern('" + i + "'); onkeyDown=javascript:if(event.keyCode==13){ApplyPattern('txtShiftPattern" + i + "','" + i + "');} />");
                                    }
                                    else
                                    {
                                        Response.Write("<input type='text' id='txtPPosition" + i + "' style='width:18px' maxlength='2' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["PatternPosition"] + "' />");
                                        Response.Write("<input type='text' id='txtShiftPattern" + i + "' style='width:60px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["ShiftPatternCode"] + "' ondblclick=javascript:CallShiftPattern('" + i + "'); onkeyDown=javascript:if(event.keyCode==13){ApplyPattern('txtShiftPattern" + i + "','" + i + "');} />");
                                        //Response.End();
                                    }
                                    Response.Write("<input type='text' id='txtDefaultSite" + i + "' style='width:14px;display: none' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["IsDefaultSite"] + "' />");
                                    Response.Write("<input type='hidden' id='hidPdLineNo" + i + "' value='" + ds.Tables[0].Rows[i]["PDLineNo"].ToString() + "' />");
                                    Response.Write("<input type='hidden' id='hidPdLineShift" + i + "' value='" + ds.Tables[0].Rows[i]["Shift"].ToString() + "' />");
                                    Response.Write("<input type='hidden' id='HFRowCount" + i + "' value='" + ds.Tables[0].Rows.Count + "' />");
                                    Response.Write("<input type='hidden' id='hfEmpNo" + i + "' value='" + ds.Tables[0].Rows[i]["EmployeeNumber"].ToString() + "' />");
                                    Response.Write("<input type='hidden' id='MinWages" + i + "' value='" + dtPDLineStartDate.Rows[0]["MinWages"].ToString() + "' />");
                                }
                                Count++;
                                if (Isconverted == "1" && shift != "" || IsWriteAccess != true)
                                {
                                    Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: khaki; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    Response.Write("<input type='hidden' id='IsConverted" + i + "' value='" + Isconverted + "' />");
                                }
                                else
                                {
                                    Response.Write("<input type='hidden' id='IsConverted" + i + "' value='" + 0 + "' />");
                                    if (dtEmpDate.Rows.Count > 0)
                                    {
                                        if (DateTime.Parse(dtPDLineStartDate.Rows[0]["TerminationDate"].ToString()) < DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtPDLineStartDate.Rows[0]["TerminationDate"].ToString() != "01-01-1900")
                                        {
                                            Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                        }
                                        //else if (((dtPDLineStartDate.Rows.Count > 0 && dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString() != "01-01-1900") || dtPDLineStartDate.Rows.Count > 0 && dtEmpDate.Rows[0]["DateOfJoining"].ToString() != "01-01-1900") && (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtEmpDate.Rows[0]["DateOfJoining"].ToString())) || (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString())))
                                        else if (((dtPDLineStartDate.Rows.Count > 0 && dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString() != "01-01-1900") || dtPDLineStartDate.Rows.Count > 0 && dtEmpDate.Rows[0]["DateOfJoining"].ToString() != "01-01-1900") && (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtEmpDate.Rows[0]["DateOfJoining"].ToString()).AddDays(double.Parse("-1"))) || (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString()).AddDays(double.Parse("-1"))))
                                        {
                                            Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                        }
                                        else if ((DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString()) < DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString() != "01-01-1900") || (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) > DateTime.Parse(dtEmpDate.Rows[0]["DateofResignation"].ToString()) && dtEmpDate.Rows[0]["DateofResignation"].ToString() != "01-01-1900"))
                                        {
                                            Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                        }
                                        else if (dtLeave.Rows.Count > 0)
                                        {
                                            if (DateTime.Parse(dtLeave.Rows[0]["LeaveDate"].ToString()) == DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtLeave.Rows.Count > 0 && dtLeave != null)
                                            {
                                                Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: orange; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                            }
                                            else
                                            {
                                                Response.Write("<input type='text' id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<input type='text' id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                        }
                                    }
                                    else
                                    {
                                        if (DateTime.Parse(dtPDLineStartDate.Rows[0]["TerminationDate"].ToString()) < DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtPDLineStartDate.Rows[0]["TerminationDate"].ToString() != "01-01-1900")
                                        {
                                            Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                        }
                                        //else if ((dtPDLineStartDate.Rows.Count > 0 && dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString() != "01-01-1900") && (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString())))
                                        else if ((dtPDLineStartDate.Rows.Count > 0 && dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString() != "01-01-1900") && (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString()).AddDays(double.Parse("-1"))))
                                        {
                                            Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                        }
                                        else if ((DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString()) < DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString() != "01-01-1900"))
                                        {
                                            Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                        }
                                        else if (dtLeave.Rows.Count > 0)
                                        {
                                            if (DateTime.Parse(dtLeave.Rows[0]["LeaveDate"].ToString()) == DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtLeave.Rows.Count > 0 && dtLeave != null)
                                            {
                                                Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: orange; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                            }
                                            else
                                            {
                                                Response.Write("<input type='text' id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<input type='text' id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + shift + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                        }
                                    }
                                }
                                if (dtPDLineStartDate.Rows.Count > 0)
                                {
                                    //Response.Write("<input type='hidden' id='hidPDLineStartDate" + i + "' value='" + DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString()).ToString("dd-MM-yyyy") + "' />");
                                    //Response.Write("<input type='hidden' id='hidPDLineEndDate" + i + "' value='" + DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString()).ToString("dd-MM-yyyy") + "' />");
                                    Response.Write("<input type='hidden' id='hidPDLineStartDate" + i + "' value='" + DateFormat(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString()) + "' />");
                                    Response.Write("<input type='hidden' id='hidPDLineEndDate" + i + "' value='" + DateFormat(dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString()) + "' />");

                                }
                                else
                                {
                                    Response.Write("<input type='hidden' id='hidPDLineStartDate" + i + "' value='" + "" + "' />");
                                    Response.Write("<input type='hidden' id='hidPDLineEndDate" + i + "' value='" + "" + "' />");
                                    //Response.Write("<input type='hidden' id='MinWages" + i + "' value='" + "" + "' />");
                                }
                            }
                            else
                            {
                                DataView dvTerminate = new DataView(ds.Tables[1]);
                                dvTerminate.RowFilter = "[PDLineNo]='" + (ds.Tables[0].Rows[i][9].ToString()) + "'";
                                dtPDLineStartDate = dvTerminate.ToTable();
                                DataView dvEmpDates = new DataView(ds.Tables[3]);
                                dvEmpDates.RowFilter = "[PDLineNo]='" + (ds.Tables[0].Rows[i][9].ToString()) + "' AND [EmployeeNumber]='" + (ds.Tables[0].Rows[i][1].ToString()) + "'";
                                dtEmpDate = dvEmpDates.ToTable();
                                if (dtEmpDate.Rows.Count > 0)
                                {
                                    if (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) > DateTime.Parse(dtEmpDate.Rows[0]["DateofResignation"].ToString()) && dtEmpDate.Rows[0]["DateofResignation"].ToString() != "01-01-1900")
                                    {
                                        if (dtEmpDate.Rows.Count > 1)
                                        {
                                            dtEmpDate.Rows[0].Delete();
                                        }
                                    }
                                }
                                if (i == Count)
                                {
                                    strWageRateColour = "";
                                    if (ds.Tables[0].Rows[i]["EmployeeNumber"].ToString() != "")
                                    {
                                        if (decimal.Parse(dtEmpDate.Rows[0]["HrWageRate"].ToString()) > decimal.Parse(dtPDLineStartDate.Rows[0]["MinWages"].ToString()))
                                        {
                                            strWageRateColour = "Red";
                                        }
                                    }
                                    if (IsWriteAccess != true)
                                    {
                                        Response.Write("<input type='text' disabled id='txtEmpNo" + i + "' style='width:60px;color:" + strWageRateColour + "' maxlength='6' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "' onkeyDown=javascript:callEmpName('txtEmpNo" + i + "','" + i + "')   />");
                                        Response.Write("<img disabled id='empsearch" + i + "' alt=" + Resources.Resource.SearchEmployee + " src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + i + "') />");
                                        Response.Write("<input type='text' id='txtEmpName" + i + "' style='width:150px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeName"] + "' onblur=javascript:func_EmpNameSearch('" + i + "') onkeyup=javascript:func_EmpNameSearch('" + i + "')  />");
                                        Response.Write("<input type='text' disabled id='txtEmpDesignation" + i + "' style='width:100px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["DesignationDesc"] + "' />");
                                        Response.Write("<input type='hidden' id='hidDesignationCode" + i + "' value='" + ds.Tables[0].Rows[i]["DesignationCode"].ToString() + "' />");
                                        Response.Write("<input type='text' disabled id='txtPPosition" + i + "' style='width:18px' maxlength='2' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["PatternPosition"] + "' />");
                                        Response.Write("<input type='text' disabled id='txtShiftPattern" + i + "' style='width:60px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["ShiftPatternCode"] + "' ondblclick=javascript:CallShiftPattern('" + i + "'); onkeyDown=javascript:if(event.keyCode==13){ApplyPattern('txtShiftPattern" + i + "','" + i + "');} />");
                                    }
                                    else
                                    {
                                        Response.Write("<input type='text' id='txtEmpNo" + i + "' style='width:60px;color:" + strWageRateColour + "' maxlength='6' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "' onkeyDown=javascript:callEmpName('txtEmpNo" + i + "','" + i + "')   />");
                                        Response.Write("<img id='empsearch" + i + "' alt=" + Resources.Resource.SearchEmployee + " src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + i + "') />");
                                        Response.Write("<input type='text' id='txtEmpName" + i + "' style='width:150px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeName"] + "' onblur=javascript:func_EmpNameSearch('" + i + "') onkeyup=javascript:func_EmpNameSearch('" + i + "')   />");
                                        Response.Write("<input type='text' disabled id='txtEmpDesignation" + i + "' style='width:100px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["DesignationDesc"] + "' />");
                                        Response.Write("<input type='text' id='txtPPosition" + i + "' style='width:18px' maxlength='2' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["PatternPosition"] + "' />");
                                        Response.Write("<input type='text' id='txtShiftPattern" + i + "' style='width:60px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["ShiftPatternCode"] + "' ondblclick=javascript:CallShiftPattern('" + i + "'); onkeyDown=javascript:if(event.keyCode==13){ApplyPattern('txtShiftPattern" + i + "','" + i + "');} />");
                                    }
                                    Response.Write("<input type='text' id='txtDefaultSite" + i + "' style='width:14px;display: none' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["IsDefaultSite"] + "' />");
                                    Response.Write("<input type='hidden' id='hidPdLineNo" + i + "' value='" + ds.Tables[0].Rows[i]["PDLineNo"].ToString() + "' />");
                                    Response.Write("<input type='hidden' id='hidPdLineShift" + i + "' value='" + ds.Tables[0].Rows[i]["Shift"].ToString() + "' />");
                                    Response.Write("<input type='hidden' id='HFRowCount" + i + "' value='" + ds.Tables[0].Rows.Count + "' />");
                                    Response.Write("<input type='hidden' id='hfEmpNo" + i + "' value='" + ds.Tables[0].Rows[i]["EmployeeNumber"].ToString() + "' />");
                                    Response.Write("<input type='hidden' id='MinWages" + i + "' value='" + dtPDLineStartDate.Rows[0]["MinWages"].ToString() + "' />");
                                }
                                Count++;
                                if (dtEmpDate.Rows.Count > 0)
                                {
                                    if (DateTime.Parse(dtPDLineStartDate.Rows[0]["TerminationDate"].ToString()) < DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtPDLineStartDate.Rows[0]["TerminationDate"].ToString() != "01-01-1900")
                                    {
                                        Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    // else if (((dtPDLineStartDate.Rows.Count > 0 && dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString() != "01-01-1900") || dtPDLineStartDate.Rows.Count > 0 && dtEmpDate.Rows[0]["DateOfJoining"].ToString() != "01-01-1900") && (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtEmpDate.Rows[0]["DateOfJoining"].ToString())) || (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString())))
                                    else if (((dtPDLineStartDate.Rows.Count > 0 && dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString() != "01-01-1900") || dtPDLineStartDate.Rows.Count > 0 && dtEmpDate.Rows[0]["DateOfJoining"].ToString() != "01-01-1900") && (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtEmpDate.Rows[0]["DateOfJoining"].ToString()).AddDays(double.Parse("-1"))) || (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString()).AddDays(double.Parse("-1"))))
                                    {
                                        Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    else if ((DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString()) < DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString() != "01-01-1900") || (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) > DateTime.Parse(dtEmpDate.Rows[0]["DateofResignation"].ToString())) && dtEmpDate.Rows[0]["DateofResignation"].ToString() != "01-01-1900")
                                    {
                                        Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    else if (IsWriteAccess != true)
                                    {
                                        Response.Write("<input type='text' disabled id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    else
                                    {
                                        Response.Write("<input type='text' id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    //Response.Write("<input type='hidden' id='hidPDLineStartDate" + i + "' value='" + DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString()).ToString("dd-MM-yyyy") + "' />");
                                    //Response.Write("<input type='hidden' id='hidPDLineEndDate" + i + "' value='" + DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString()).ToString("dd-MM-yyyy") + "' />");
                                    Response.Write("<input type='hidden' id='hidPDLineStartDate" + i + "' value='" + DateFormat(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString()) + "' />");
                                    Response.Write("<input type='hidden' id='hidPDLineEndDate" + i + "' value='" + DateFormat(dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString()) + "' />");
                                    // Response.Write("<input type='hidden' id='MinWages" + i + "' value='" + dtPDLineStartDate.Rows[0]["MinWages"].ToString() + "' />");
                                }
                                else if (dtEmpDate.Rows.Count == 0)
                                {
                                    if (DateTime.Parse(dtPDLineStartDate.Rows[0]["TerminationDate"].ToString()) < DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtPDLineStartDate.Rows[0]["TerminationDate"].ToString() != "01-01-1900")
                                    {
                                        Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    // else if ((dtPDLineStartDate.Rows.Count > 0 && dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString() != "01-01-1900") && (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString())))
                                    else if ((dtPDLineStartDate.Rows.Count > 0 && dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString() != "01-01-1900") && (DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) <= DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineStartDate"].ToString()).AddDays(double.Parse("-1"))))
                                    {
                                        Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    else if ((DateTime.Parse(dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString()) < DateTime.Parse(ds.Tables[0].Columns[j].ColumnName.ToString()) && dtPDLineStartDate.Rows[0]["PDLineEndDate"].ToString() != "01-01-1900"))
                                    {
                                        Response.Write("<input type='text' readonly id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; background-color: gray; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    else if (IsWriteAccess != true)
                                    {
                                        Response.Write("<input type='text' disabled id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                    else
                                    {
                                        Response.Write("<input type='text' id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    }
                                }
                                else
                                {
                                    Response.Write("<input type='text' id='txtShift" + i + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i][j] + "' onkeyDown=javascript:DeleteAjax('" + i + "','" + (j - 11) + "')  />");
                                    Response.Write("<input type='hidden' id='hidPDLineStartDate" + i + "' value='" + "" + "' />");
                                    Response.Write("<input type='hidden' id='hidPDLineEndDate" + i + "' value='" + "" + "' />");
                                    // Response.Write("<input type='hidden' id='MinWages" + i + "' value='" + "" + "' />");
                                }
                            }
                        }
                        Response.Write("</td></tr>");
                        Count = i + 1;
                    }
                    for (int k = ds.Tables[0].Rows.Count; k < intArow + ds.Tables[0].Rows.Count; k++)
                    {
                        Response.Write("<Tr><td><input type='text' class='csstxtbox' disabled id='SNo" + k + "' value='" + (k + 1) + "' style='width:16px' />");
                        for (int z = 0; z < dsAsmtSitePost.Tables[0].Rows.Count; z++)
                        {

                            dt2 = dt2 + "<option value='" + dsAsmtSitePost.Tables[0].Rows[z]["PDLineNo"] + "'>" + dsAsmtSitePost.Tables[0].Rows[z]["SitePost"] + "</option>";
                            strddlSitepost = strddlSitepost + "<option value='" + dsAsmtSitePost.Tables[0].Rows[z]["ShiftTimes"] + "'>" + dsAsmtSitePost.Tables[0].Rows[z]["SitePost"] + "</option>";
                            
                            //if (intPdlineNo != 0 && intPdlineNo == int.Parse(dsAsmtSitePost.Tables[0].Rows[z]["PDLineNo"].ToString()))
                            //{
                            //dt2 = dt2 + "<option value='" + dsAsmtSitePost.Tables[0].Rows[z]["PDLineNo"] + "'>" + dsAsmtSitePost.Tables[0].Rows[z]["SitePost"] + "</option>";
                            //}
                            //else if (intPdlineNo == 0)
                            //{
                            //    dt2 = dt2 + "<option value='" + dsAsmtSitePost.Tables[0].Rows[z]["PDLineNo"] + "'>" + dsAsmtSitePost.Tables[0].Rows[z]["SitePost"] + "</option>";
                            //}
                        }
                        if (IsWriteAccess != true)
                        {
                            Response.Write("<select onchange=javascript:alert('san')  disabled id='ddlSitePost" + k + "' style='width:144px;vertical-align:baseline' class='cssDropDown'>" + dt2 + "</select>");
                            Response.Write("<input type='text' disabled id='txtShiftTimes" + k + "' style='width:65px' class='csstxtbox' value='" + dsAsmtSitePost.Tables[0].Rows[0]["ShiftTimes"] + "'  />");
                            Response.Write("<input type='text' disabled id='txtEmpNo" + k + "' style='width:60px' maxlength='6' class='csstxtbox' value='' onkeyDown=javascript:callEmpName('txtEmpNo" + k + "','" + k + "')   />");
                            Response.Write("<img disabled id='empsearch" + k + "' alt='search Emp' src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + k + "') />");
                            Response.Write("<input type='text' id='txtEmpName" + k + "' style='width:150px' class='csstxtbox' value='' onblur=javascript:func_EmpNameSearch('" + k + "') onkeyup=javascript:func_EmpNameSearch('" + k + "')   />");
                            Response.Write("<input type='text' disabled id='txtEmpDesignation" + k + "' style='width:100px' class='csstxtbox' value='' />");
                            Response.Write("<input type='hidden' id='hidDesignationCode" + k + "' value='' />");
                            Response.Write("<input type='text' disabled id='txtPPosition" + k + "' style='width:18px' maxlength='2' class='csstxtbox' value='1'/>");
                            Response.Write("<input type='text' disabled id='txtShiftPattern" + k + "' style='width:60px' class='csstxtbox' value='' ondblclick=javascript:CallShiftPattern('" + k + "'); onkeyDown=javascript:if(event.keyCode==13){ApplyPattern('txtShiftPattern" + k + "','" + k + "');} />");
                        }
                        else
                        {
                            Response.Write("<select onchange=javascript:Func_GetShiftTimes(this,'"+ k +"') id='ddlSitePost" + k + "' style='width:144px;vertical-align:baseline' class='cssDropDown'>" + dt2 + "</select>");
                            Response.Write("<input type='text' disabled id='txtShiftTimes" + k + "' style='width:65px' class='csstxtbox' value='" + dsAsmtSitePost.Tables[0].Rows[0]["ShiftTimes"] + "'  />");
                            Response.Write("<input type='text' id='txtEmpNo" + k + "' style='width:60px' maxlength='6' class='csstxtbox' value='' onkeyDown=javascript:callEmpName('txtEmpNo" + k + "','" + k + "')   />");
                            Response.Write("<img id='empsearch" + k + "' alt='search Emp' src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + k + "') />");
                            Response.Write("<input type='text'  id='txtEmpName" + k + "' style='width:150px' class='csstxtbox' value='' onblur=javascript:func_EmpNameSearch('" + k + "') onkeyup=javascript:func_EmpNameSearch('" + k + "')  />");
                            Response.Write("<input type='text' disabled id='txtEmpDesignation" + k + "' style='width:100px' class='csstxtbox' value='' />");
                            Response.Write("<input type='hidden' id='hidDesignationCode" + k + "' value='' />");
                            Response.Write("<input type='text' id='txtPPosition" + k + "' style='width:18px' maxlength='2' class='csstxtbox' value='1'/>");
                            Response.Write("<input type='text' id='txtShiftPattern" + k + "' style='width:60px' class='csstxtbox' value='' ondblclick=javascript:CallShiftPattern('" + k + "'); onkeyDown=javascript:if(event.keyCode==13){ApplyPattern('txtShiftPattern" + k + "','" + k + "');}  />");
                        }
                        Response.Write("<input onchange=javascript:Func_GetShiftTimes(this,'" + k + "') type='text' id='txtDefaultSite" + k + "' style='width:14px;display: none' class='csstxtbox' value='1' />");
                        Response.Write("<input type='hidden' id='hidPdLineNo" + k + "' value='" + strNewPDLine + "' />");
                        Response.Write("<input type='hidden' id='HFRowCount" + k + "' value='" + ds.Tables[0].Rows.Count + "' />");
                        //Response.Write("<input type='hidden' id='hfEmpNo" + k + "' value='" + ds.Tables[0].Rows[k]["EmployeeNumber"].ToString() + "' />");
                        Response.Write("<input type='hidden' id='hidPdLineShift" + k + "' value='A' />");
                        Response.Write("<input type='hidden' id='MinWages" + k + "' value='" + dtPDLineStartDate.Rows[0]["MinWages"].ToString() + "' />");
                        for (int j = 12; j < ds.Tables[0].Columns.Count; j++)
                        {
                            if (IsWriteAccess != true)
                            {
                                Response.Write("<input type='text' disabled id='txtShift" + k + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='' onkeyDown=javascript:DeleteAjax('" + k + "','" + (j - 11) + "')  />");
                            }
                            else
                            {
                                Response.Write("<input type='text' id='txtShift" + k + "_" + (j - 11) + "' style='width:18px; text-align: center' class='csstxtbox' value='' onkeyDown=javascript:DeleteAjax('" + k + "','" + (j - 11) + "')  />");
                            }
                        }
                        Response.Write("</td></tr>");
                    }
                    Response.Write("</table>");
                    Response.Write("</div>");
                                    
                    Response.Write("<select id='ddlHiddenSitepost' style='display:none' >" + strddlSitepost + "</select>");
                    Response.Write("<input type='hidden' id='HidDtCount' value='" + (ds.Tables[0].Columns.Count - 10) + "' />");
                    Response.End();
                    dt2 = "";
                }
                else
                {
                    Response.Write(Resources.Resource.AssignmentHasExpired);
                    Response.End();
                }
            }
            else
            {
                //Response.Write("javaScript:Alert('InvalidDate')");
                //Response.End();
            }
        }
        else
        {
            Response.Write(Resources.Resource.NOAccessRights);
            Response.End();
        }
    }
}
