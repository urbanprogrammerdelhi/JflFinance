// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getRotaSheetAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Globalization;


/// <summary>
/// Class Transactions_getRotaSheetAjax.
/// </summary>
public partial class Transactions_getRotaSheetAjax : BasePage //System.Web.UI.Page
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
            string strASmtCode = Request.QueryString["Asmt"];
            string strDate = Request.QueryString["Date1"];
            string strPageRef = Request.QueryString["iPageRef"];
            string strNewRow = Request.QueryString["NewRow"];
            string strStatus = Request.QueryString["btnStatus"];
            string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
            string strNewRowPd = Request.QueryString["NewRowPd"];
            string strNewRowSite = Request.QueryString["NewRowSite"];

            int intNewRowPd = 0;

            if (strNewRowPd != "")
            {
                intNewRowPd = int.Parse(strNewRowPd);

            }
            /* code added by dharamvir */

            int intPageNo = int.Parse(strPageRef);
            int intPageSize = 10;
            int intPageCount = 0;
            int intCurRow = (intPageNo * intPageSize) - intPageSize;
            /* code added by dharamvir */

            int intNewRow = 0;
            if (strNewRow != "")
            { intNewRow = int.Parse(strNewRow); }
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DataSet dsDutyType = new DataSet();
            dsDutyType = objMastersManagement.DutyTypeGetAll(BaseCompanyCode);
            //string dt2 = "<option value='DT0002'>Normal</option><option value='DT0004'>OJT</option><option value='DT0008'>TSOAdditional</option>";
            //string dt4 = "";
            string dt8 = "";

            BL.Roster objRost = new BL.Roster();
            DataSet ds = new DataSet();
            if (strStatus == "1")
            {
                ds = objRost.AsmtRotaGet(int.Parse(BaseLocationAutoID), strASmtCode, strDate, intPageNo, intPageSize, int.Parse(strStatus), strEmployeeNumber);
            }
            else
            {
                ds = objRost.AsmtRotaGet(int.Parse(BaseLocationAutoID), strASmtCode, strDate, intPageNo, intPageSize, int.Parse(strStatus), strEmployeeNumber);
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int intRecCount = 0;
                intRecCount = int.Parse(ds.Tables[0].Rows[0]["TotalRec"].ToString());//ds.Tables[0].Rows.Count;
                if (intRecCount <= intPageSize)
                {
                    intPageSize = intRecCount;
                }
                intPageCount = int.Parse(ds.Tables[0].Rows[0]["PageCount"].ToString());
                if (BaseRotaTimeShow.ToLower().Trim() == "TRUE".ToLower().Trim().ToString())
                {

                    Response.Write("<table border='0' cellpadding='0' cellspacing='0'>");
                    Response.Write("<Tr>");
                    Response.Write("<td width='25px'><input type='text' style='width: 25px' class='csstxtbox' disabled id='SNo' value='" + Resources.Resource.SerialNumber + "' style='width:20px'/></td>");
                    Response.Write("<td width='110px'><input type='text' style='width: 110px' class='csstxtbox' disabled id='ShiftSite' value='" + Resources.Resource.SitePost + "' style='width:20px'/></td>");
                    Response.Write("<td width='70px'><input type='text' style='width: 70px' class='csstxtbox' disabled id='Rank' value='" + Resources.Resource.SORank + "' style='width:20px'/></td>");
                    Response.Write("<td width='60px'><input type='text' style='width: 60px' class='csstxtbox' disabled id='EmpNo' value='" + Resources.Resource.EmployeeNumber + "' style='width:20px'/></td>");
                    Response.Write("<td width='18px'></td>");
                    Response.Write("<td width='150px'><input type='text' style='width: 150px' class='csstxtbox' disabled id='Name' value='" + Resources.Resource.Name + "' style='width:20px'/></td>");
                    Response.Write("<td width='98px'><input type='text' style='width: 100px' class='csstxtbox' disabled id='Desig' value='" + Resources.Resource.Designation + "' style='width:20px'/></td>");
                    Response.Write("<td width='130px'><input type='text' style='width: 130px' class='csstxtbox' disabled id='Roll' value='Role' /></td>");
                    Response.Write("<td width='40px'><input type='text' style='width: 40px' class='csstxtbox' disabled id='Shift' value='" + Resources.Resource.Shift + "' style='width:20px'/></td>");
                    Response.Write("<td width='55px'><input type='text' style='width: 55px' class='csstxtbox' disabled id='TFrom' value='" + Resources.Resource.FromTime + "'/></td>");
                    Response.Write("<td width='19px'></td>");
                    Response.Write("<td width='55px'><input type='text' style='width: 55px' class='csstxtbox' disabled id='TTo' value='" + Resources.Resource.ToTime + "'/></td>");
                    Response.Write("<td width='18px'></td>");
                    Response.Write("<td width='60px'><input type='text' style='width: 60px' class='csstxtbox' disabled id='BreakHrs' value='" + Resources.Resource.BreakHours + "' style='width:50px'/></td>");
                    Response.Write("<td width='40px'><input type='text' style='width: 38px' class='csstxtbox' disabled id='HRs' value='" + Resources.Resource.Hours + "' style='width:20px'/></td>");
                    Response.Write("<td width='86px'><input type='text' style='width: 86px' class='csstxtbox' disabled id='DutyType' value='" + Resources.Resource.DutyType + "' style='width:20px'/></td>");
                    Response.Write("</Tr>");
                    Response.Write("</table >");
                }
                else
                {
                    Response.Write("<table border='0' cellpadding='0' cellspacing='0'>");
                    Response.Write("<Tr>");
                    Response.Write("<td width='25px'><input type='text' style='width: 25px' class='csstxtbox' disabled id='SNo' value='" + Resources.Resource.SerialNumber + "' style='width:20px'/></td>");
                    Response.Write("<td width='110px'><input type='text' style='width: 110px' class='csstxtbox' disabled id='ShiftSite' value='" + Resources.Resource.SitePost + "' style='width:20px'/></td>");
                    Response.Write("<td width='70px'><input type='text' style='width: 70px' class='csstxtbox' disabled id='Rank' value='" + Resources.Resource.SORank + "' style='width:20px'/></td>");
                    Response.Write("<td width='60px'><input type='text' style='width: 60px' class='csstxtbox' disabled id='EmpNo' value='" + Resources.Resource.EmployeeNumber + "' style='width:20px'/></td>");
                    Response.Write("<td width='18px'></td>");
                    Response.Write("<td width='150px'><input type='text' style='width: 150px' class='csstxtbox' disabled id='Name' value='" + Resources.Resource.Name + "' style='width:20px'/></td>");
                    Response.Write("<td width='98px'><input type='text' style='width: 100px' class='csstxtbox' disabled id='Desig' value='" + Resources.Resource.Designation + "' style='width:20px'/></td>");
                    Response.Write("<td width='130px'><input type='text' style='width: 130px' class='csstxtbox' disabled id='Roll' value='Role' /></td>");
                    Response.Write("<td width='40px'><input type='text' style='width: 40px' class='csstxtbox' disabled id='Shift' value='" + Resources.Resource.Shift + "' style='width:20px'/></td>");
                    Response.Write("<td width='55px'><input type='text' style='width: 55px' class='csstxtbox' disabled id='TFrom' value='" + Resources.Resource.FromTime + "'/></td>");
                    Response.Write("<td width='55px'><input type='text' style='width: 55px' class='csstxtbox' disabled id='TTo' value='" + Resources.Resource.ToTime + "'/></td>");
                    Response.Write("<td width='40px'><input type='text' style='width: 38px' class='csstxtbox' disabled id='HRs' value='" + Resources.Resource.Hours + "' style='width:20px'/></td>");
                    Response.Write("<td width='86px'><input type='text' style='width: 86px' class='csstxtbox' disabled id='DutyType' value='" + Resources.Resource.DutyType + "' style='width:20px'/></td>");
                    Response.Write("</Tr>");
                    Response.Write("</table >");
                }
                Response.Write("<table border='0' cellpadding='0' cellspacing='0'>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string dt2 = string.Empty;
                    string dt4 = string.Empty;
                    Response.Write("<Tr><td><input type='text' class='csstxtbox' disabled id='SNo" + intCurRow + "' value='" + (intCurRow + 1) + "' style='width:25px'/><input type='text' disabled id='txtSitePost" + i + "' style='width:110px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["SitePost"] + "'/>");
                    Response.Write("<input type='text' disabled id='txtDesignation" + i + "' style='width:70px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["designationCode"] + "'/>");
                    if (IsWriteAccess != true)
                    {
                        Response.Write("<input type='text' disabled id='txtEmpNo" + i + "' style='width:60px' maxlength='6' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "' title='" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "' onkeyup=javascript:if(event.keyCode==13){FunctionCallOnEnterKeyDown('EmployeeNumber','" + i + "')} onkeydown=javascript:FunctionCallOnKeyDown('EmployeeNumber','" + i + "')  />");
                        Response.Write("<img disabled id='empsearch" + i + "' alt=" + Resources.Resource.SearchEmployee + "  src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + i + "') />");
                        Response.Write("<input type='text' disabled id='txtEmpName" + i + "' style='width:150px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeName"] + "' onblur=javascript:func_EmpNameSearch('" + i + "') onkeyup=javascript:func_EmpNameSearch('" + i + "')  />");
                        Response.Write("<input type='text' disabled id='txtEmpDesignation" + i + "' style='width:100px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmpDesignation"] + "' />");
                        Response.Write("<input type='text' disabled id='txtEmpRole" + i + "' style='width:130px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["RoleDesc"] + "' onblur=javascript:searchRole('" + i + "')  onkeyup=javascript:searchRole('" + i + "') />");
                        Response.Write("<input type='text' disabled id='txtShift" + i + "' style='width:40px;text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["Shift"] + "' onchange=javascript:getStdShift('" + i + "')  onkeyup=javascript:if(event.keyCode==13){getStdShift('" + i + "')}   onKeyDown=javascript:FunctionCallOnKeyDown('ShiftCode','" + i + "')  />");
                        string strTimeFromCheckStatus = string.Empty; ;
                        string strTimeToCheckStatus = string.Empty;
                        string strTimeFromColor = string.Empty;
                        string strTimeToColor = string.Empty;
                        string TotalDutyHrs = "00:00";
                        string TotalBreakHrs = "00:00";
                        if (BaseRotaTimeShow.ToLower().Trim() == "TRUE".ToLower().Trim().ToString())
                        {

                            if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "1")
                            {
                                strTimeFromCheckStatus = "";
                                strTimeToCheckStatus = "";
                                strTimeFromColor = "";
                                strTimeToColor = "";
                            }
                            else if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "2")
                            {
                                strTimeFromCheckStatus = "checked";
                                strTimeToCheckStatus = "";
                                strTimeFromColor = "Green";
                                strTimeToColor = "Red";
                            }
                            else if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "3")
                            {
                                strTimeFromCheckStatus = "checked";
                                strTimeToCheckStatus = "checked";
                                strTimeFromColor = "Green";
                                strTimeToColor = "Green";
                            }
                            if (ds.Tables[0].Rows[i]["BreakHours"].ToString() == "")
                            {
                                ds.Tables[0].Rows[i]["BreakHours"] = "0";
                            }
                            string[] splitedValue = ds.Tables[0].Rows[i]["BreakHours"].ToString().Split('.');
                            if (ds.Tables[0].Rows[i]["BreakHours"].ToString().Substring(0, 0) != ".")
                            {
                                if (ds.Tables[0].Rows[i]["BreakHours"].ToString().Length == 1)
                                {
                                   // TotalBreakHrs = "0" + TotalBreakHrs + ":00";

                                }
                                else if (ds.Tables[0].Rows[i]["BreakHours"].ToString().Length == 2)
                                {
                                    if (ds.Tables[0].Rows[i]["BreakHours"].ToString().Substring(1, 1) != ".")
                                    {
                                        TotalBreakHrs = TotalBreakHrs + ":00";

                                    }
                                    else
                                    {
                                        string[] arr = ds.Tables[0].Rows[i]["BreakHours"].ToString().Split('.');

                                        TotalBreakHrs = "0" + arr[0] + ":00";

                                    }
                                }
                                else
                                {
                                    int Index = ds.Tables[0].Rows[i]["BreakHours"].ToString().IndexOf('.');
                                    if (Index < 3)
                                    {
                                        string[] arr = ds.Tables[0].Rows[i]["BreakHours"].ToString().Split('.');
                                        if (arr[0].Length == 2)
                                        {
                                            TotalBreakHrs = arr[0] + ":" + (int.Parse(arr[1]) * 60).ToString();
                                        }


                                        else
                                        {
                                            TotalBreakHrs = "0" + arr[0] + ":" + (int.Parse(arr[1]) * 60).ToString();
                                        }

                                    }
                                }
                            }
                            else
                            {
                                TotalBreakHrs = (int.Parse(TotalBreakHrs) * 60).ToString();
                                TotalBreakHrs = "00" + ":" + TotalBreakHrs;

                            }
                            TotalBreakHrs = (TotalBreakHrs + "0").ToString().Substring(0, 5);

                            DateTime dtDutyHrs = new DateTime();
                            DateTime dtBreakHrs = new DateTime();
                            if (ds.Tables[0].Rows[i]["TimeFrom"].ToString() != "" && ds.Tables[0].Rows[i]["TimeTo"].ToString() != "")
                            {
                                dtDutyHrs = DateTime.ParseExact(ds.Tables[0].Rows[i]["DutyHrs"].ToString(), "HH:mm", new DateTimeFormatInfo());
                                dtBreakHrs = DateTime.ParseExact(TotalBreakHrs, "HH:mm", new DateTimeFormatInfo());
                                TotalDutyHrs = DateTime.Parse(dtDutyHrs.Subtract(dtBreakHrs).ToString()).ToString("HH:mm");
                            }
                            //string TotalDutyHrs = "00:00";
                            //DateTime dtBreakHrs = new DateTime();
                            //DateTime dtDutyHrs = new DateTime();
                            //if (ds.Tables[0].Rows[i]["TimeFrom"].ToString() != "" && ds.Tables[0].Rows[i]["TimeTo"].ToString() != "")
                            //{
                            //    dtDutyHrs = DateTime.ParseExact(ds.Tables[0].Rows[i]["DutyHrs"].ToString(), "HH:mm", new DateTimeFormatInfo());
                            //    dtBreakHrs = DateTime.ParseExact(ds.Tables[0].Rows[i]["BreakHours"].ToString(), "HH:mm", new DateTimeFormatInfo());
                            //    TotalDutyHrs = DateTime.Parse(dtDutyHrs.Subtract(dtBreakHrs).ToString()).ToString("HH:mm");
                            //}
                            //if (ds.Tables[0].Rows[i]["BreakHours"].ToString() == "00:00")
                            //{
                            //    ds.Tables[0].Rows[i]["BreakHours"] = "0";
                            //}
                            //string time = ds.Tables[0].Rows[i]["BreakHours"].ToString();


                            Response.Write("<input type='text' disabled id='txtTimeFrom" + i + "' style='width:55px;text-align: center;background-color:" + strTimeFromColor + "' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeFrom"] + "' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','F') />");
                            Response.Write("<img border='0' disabled src='../Images/Clock.ico'  width='18px' onclick=javascript:javascript:ImgClicked('txtTimeFrom" + i + "') />");
                            Response.Write("<input type='checkbox'  disabled onclick=javascript:CheckChanged('" + i + "') id='CBTimeFrom" + i + "' " + strTimeFromCheckStatus + " />");
                            Response.Write("<input type='text' disabled id='txtTimeTo" + i + "' style='width:55px;text-align: center;background-color:" + strTimeToColor + "' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeTo"] + "' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','T') />");
                            Response.Write("<img border='0' disabled src='../Images/Clock.ico' width='18px' onclick=javascript:javascript:ImgClicked('txtTimeTo" + i + "') />");
                            Response.Write("<input type='checkbox' disabled onclick=javascript:CheckChanged('" + i + "') id='CBTimeTo" + i + "' " + strTimeToCheckStatus + "/>");
                            Response.Write("<input type='text'  maxlength='5' id='txtBreakHrs" + i + "' style='width:60px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["BreakHours"] + "' onblur=javascript:convertHoursToMin('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','B') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + TotalDutyHrs + "' />");


                        }
                        else
                        {
                            Response.Write("<input type='text' disabled id='txtTimeFrom" + i + "' style='width:55px;text-align: center;background-color:" + strTimeFromColor + "' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeFrom"] + "' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','F') />");
                            Response.Write("<input type='text' disabled id='txtTimeTo" + i + "' style='width:55px;text-align: center;background-color:" + strTimeToColor + "' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeTo"] + "' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','T') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["DutyHrs"] + "' />");
                        }
                    }
                    else
                    {
                        Response.Write("<input type='text' id='txtEmpNo" + i + "' style='width:60px' maxlength='6' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "' title='" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "' onkeyup=javascript:if(event.keyCode==13){FunctionCallOnEnterKeyDown('EmployeeNumber','" + i + "')}  onkeydown=javascript:FunctionCallOnKeyDown('EmployeeNumber','" + i + "')  />");
                        Response.Write("<img id='empsearch" + i + "' alt=" + Resources.Resource.SearchEmployee + "  src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + i + "') />");
                        Response.Write("<input type='text' id='txtEmpName" + i + "' style='width:150px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmployeeName"] + "' onblur=javascript:func_EmpNameSearch('" + i + "') onkeyup=javascript:func_EmpNameSearch('" + i + "') />");
                        Response.Write("<input type='text' disabled id='txtEmpDesignation" + i + "' style='width:100px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["EmpDesignation"] + "' />");
                        Response.Write("<input type='text' id='txtEmpRole" + i + "' style='width:130px' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["RoleDesc"] + "' onblur=javascript:searchRole('" + i + "')  onkeyup=javascript:searchRole('" + i + "') />");
                        Response.Write("<input type='text' id='txtShift" + i + "' style='width:40px;text-align: center' class='csstxtbox' value='" + ds.Tables[0].Rows[i]["Shift"] + "' onchange=javascript:getStdShift('" + i + "')  onkeyup=javascript:if(event.keyCode==13){getStdShift('" + i + "')}   onKeyDown=javascript:FunctionCallOnKeyDown('ShiftCode','" + i + "')  />");
                        string strTimeFromCheckStatus = string.Empty; ;
                        string strTimeToCheckStatus = string.Empty;
                        string strTimeFromColor = string.Empty;
                        string strTimeToColor = string.Empty;
                        if (BaseRotaTimeShow.ToLower().Trim() == "TRUE".ToLower().Trim().ToString())
                        {

                            if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "1")
                            {
                                strTimeFromCheckStatus = "";
                                strTimeToCheckStatus = "";
                                strTimeFromColor = "";
                                strTimeToColor = "";
                            }
                            else if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "2")
                            {
                                strTimeFromCheckStatus = "checked";
                                strTimeToCheckStatus = "";
                                strTimeFromColor = "Green";
                                strTimeToColor = "Red";
                            }
                            else if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "3")
                            {
                                strTimeFromCheckStatus = "checked";
                                strTimeToCheckStatus = "checked";
                                strTimeFromColor = "Green";
                                strTimeToColor = "Green";
                            }
                            string TotalDutyHrs = "00:00";
                            //string TotalBreakHrs = "00:00";
                            //if (ds.Tables[0].Rows[i]["BreakHours"].ToString() == "")
                            //{
                            //    ds.Tables[0].Rows[i]["BreakHours"] = "0";
                            //}
                            //string[] splitedValue = ds.Tables[0].Rows[i]["BreakHours"].ToString().Split('.');
                            //if (ds.Tables[0].Rows[i]["BreakHours"].ToString().Substring(0, 0) != ".")
                            //{
                            //    if (ds.Tables[0].Rows[i]["BreakHours"].ToString().Length == 1)
                            //    {
                            //        TotalBreakHrs = "0" + TotalBreakHrs + ":00";

                            //    }
                            //    else if (ds.Tables[0].Rows[i]["BreakHours"].ToString().Length == 2)
                            //    {
                            //        if (ds.Tables[0].Rows[i]["BreakHours"].ToString().Substring(1, 1) != ".")
                            //        {
                            //            TotalBreakHrs = TotalBreakHrs + ":00";

                            //        }
                            //        else
                            //        {
                            //            string[] arr = ds.Tables[0].Rows[i]["BreakHours"].ToString().Split('.');

                            //            TotalBreakHrs = "0" + arr[0] + ":00";

                            //        }
                            //    }
                            //    else
                            //    {
                            //        int Index = ds.Tables[0].Rows[i]["BreakHours"].ToString().IndexOf('.');
                            //        if (Index < 3)
                            //        {
                            //            string[] arr = ds.Tables[0].Rows[i]["BreakHours"].ToString().Split('.');
                            //            if (arr[0].Length == 2)
                            //            {
                            //                TotalBreakHrs = arr[0] + ":" + (int.Parse(arr[1]) * 60).ToString();
                            //            }


                            //            else
                            //            {
                            //                TotalBreakHrs = "0" + arr[0] + ":" + (int.Parse(arr[1]) * 60).ToString();
                            //            }

                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    TotalBreakHrs = (int.Parse(TotalBreakHrs) * 60).ToString();
                            //    TotalBreakHrs = "00" + ":" + TotalBreakHrs;

                            //}
                            //TotalBreakHrs =(TotalBreakHrs+"0").ToString().Substring(0,5);
                            //if (ds.Tables[0].Rows[i]["BreakHours"].ToString() == "0")
                            //{
                            //    TotalBreakHrs = "00:00";
                            //}
                            //DateTime dtDutyHrs = new DateTime();
                            //DateTime dtBreakHrs = new DateTime();
                            //if (ds.Tables[0].Rows[i]["TimeFrom"].ToString() != "" && ds.Tables[0].Rows[i]["TimeTo"].ToString() != "")
                            //{
                            //    dtDutyHrs = DateTime.ParseExact(ds.Tables[0].Rows[i]["DutyHrs"].ToString(), "HH:mm", new DateTimeFormatInfo());
                            //    dtBreakHrs = DateTime.ParseExact(TotalBreakHrs, "HH:mm", new DateTimeFormatInfo());
                            //    TotalDutyHrs = DateTime.Parse(dtDutyHrs.Subtract(dtBreakHrs).ToString()).ToString("HH:mm");
                            //}
                            if (ds.Tables[0].Rows[i]["DutyHrs"].ToString() == "00:00")
                            {

                                TotalDutyHrs = "24:00";
                            }
                            else
                            {
                                TotalDutyHrs = ds.Tables[0].Rows[i]["DutyHrs"].ToString();
                            }

                            Response.Write("<input type='text' id='txtTimeFrom" + i + "' style='width:55px;text-align: center;background-color:" + strTimeFromColor + "' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeFrom"] + "' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','F') />");
                            Response.Write("<img border='0' src='../Images/Clock.ico'  width='18px' onclick=javascript:javascript:ImgClicked('txtTimeFrom" + i + "') />");
                            Response.Write("<input type='checkbox' style='display:none' onclick=javascript:CheckChanged('" + i + "') id='CBTimeFrom" + i + "' " + strTimeFromCheckStatus + " />");
                            Response.Write("<input type='text' id='txtTimeTo" + i + "' style='width:55px;text-align: center;background-color:" + strTimeToColor + "' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeTo"] + "' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','T') />");
                            Response.Write("<img border='0' src='../Images/Clock.ico' width='18px' onclick=javascript:javascript:ImgClicked('txtTimeTo" + i + "') />");
                            Response.Write("<input type='checkbox'  style='display:none' onclick=javascript:CheckChanged('" + i + "') id='CBTimeTo" + i + "' " + strTimeToCheckStatus + "/>");
                            Response.Write("<input type='text'  maxlength='5' id='txtBreakHrs" + i + "' style='width:60px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["BreakHours"] + "' onblur=javascript:convertHoursToMin('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','B') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + TotalDutyHrs + "' />");

                        }
                        else
                        {
                            Response.Write("<input type='text' id='txtTimeFrom" + i + "' style='width:55px;text-align: center;background-color:" + strTimeFromColor + "' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeFrom"] + "' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','F') />");
                            Response.Write("<input type='text' id='txtTimeTo" + i + "' style='width:55px;text-align: center;background-color:" + strTimeToColor + "' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["TimeTo"] + "' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','T') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='" + ds.Tables[0].Rows[i]["DutyHrs"] + "' />");
                        }
                    }

                    Response.Write("<input type='hidden' id='hidPdLineNo" + i + "' value='" + ds.Tables[0].Rows[i]["PDLineNo"].ToString() + "' />");
                    Response.Write("<input type='hidden' id='hidRosterAutoID" + i + "' value='" + ds.Tables[0].Rows[i]["RosterAutoID"].ToString() + "' />");
                    Response.Write("<input type='hidden' id='hid_DutyType" + i + "' value='" + ds.Tables[0].Rows[i]["DutyType"] + "' />");
                    Response.Write("<input type='hidden' id='hid_RoleId" + i + "' value='" + ds.Tables[0].Rows[i]["RoleCode"] + "' />");
                    Response.Write("<input type='hidden' id='hidShiftCode" + i + "' value='" + ds.Tables[0].Rows[i]["Shift"].ToString() + "' />");
                    Response.Write("<input type='hidden' id='hidDutyHrs" + i + "' value='" + ds.Tables[0].Rows[i]["DutyHrs"].ToString() + "' />");
                    //if (ds.Tables[0].Rows[i]["DutyType"].ToString() == "DT0002" || ds.Tables[0].Rows[i]["DutyType"].ToString() == "")
                    //{
                    //    dt2 = "<option value='DT0002'>Normal</option><option value='DT0004'>OJT</option><option value='DT0008'>TSOAdditional</option>";
                    //}
                    //else if (ds.Tables[0].Rows[i]["DutyType"].ToString() == "DT0004")
                    //{
                    //    dt2 = "<option value='DT0004'>OJT</option><option value='DT0002'>Normal</option><option value='DT0008'>TSOAdditional</option>";

                    //}
                    //else if (ds.Tables[0].Rows[i]["DutyType"].ToString() == "DT0008")
                    //{
                    //    dt2 = "<option value='DT0008'>TSOAdditional</option><option value='DT0002'>Normal</option><option value='DT0004'>OJT</option>";

                    //}
                    for (int z = 0; z < dsDutyType.Tables[0].Rows.Count; z++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["DutyType"]).Trim() != Convert.ToString(dsDutyType.Tables[0].Rows[z]["DutyTypeCode"]).Trim() && ds.Tables[0].Rows[i]["DutyTypeDesc"] != " ")
                        {
                            dt2 = dt2 + "<option value='" + dsDutyType.Tables[0].Rows[z]["DutyTypeCode"] + "'>" + dsDutyType.Tables[0].Rows[z]["DutyTypeDesc"] + "</option>";
                        }
                    }
                    dt4 = dt4 + "<option value='" + ds.Tables[0].Rows[i]["DutyType"] + "' Selected>" + ds.Tables[0].Rows[i]["DutyTypeDesc"] + "</option>";
                    if (IsWriteAccess != true)
                    {
                        Response.Write("<select disabled id='ddlDutyType" + i + "' style='width:90px' class='cssDropDown' onKeyDown=javascript:FunctionCallOnKeyDown('DutyType','" + i + "') >" + dt2 + dt4 + "</select>");
                    }
                    else
                    {
                        Response.Write("<select id='ddlDutyType" + i + "' style='width:90px' class='cssDropDown' onKeyDown=javascript:FunctionCallOnKeyDown('DutyType','" + i + "') >" + dt2 + dt4 + "</select>");
                    }
                    Response.Write("</td></tr>");
                    intCurRow = intCurRow + 1;
                }

                for (int i = ds.Tables[0].Rows.Count; i < (ds.Tables[0].Rows.Count + intNewRow); i++)
                {

                    Response.Write("<Tr><td><input type='text' class='csstxtbox' disabled id='SNo" + i + "' value='" + (i + 1) + "' style='width:25px' /><input type='text' disabled id='txtSitePost" + i + "' style='width:110px' class='csstxtbox' value='" + strNewRowSite + "' />");
                    Response.Write("<input type='text' disabled id='txtDesignation" + i + "' style='width:70px' class='csstxtbox' value='' />");
                    if (IsWriteAccess != true)
                    {
                        Response.Write("<input disabled type='text' id='txtEmpNo" + i + "' style='width:60px' maxlength='6' class='csstxtbox' value='' onkeyup=javascript:if(event.keyCode==13){FunctionCallOnEnterKeyDown('EmployeeNumber','" + i + "')} onkeydown=javascript:FunctionCallOnKeyDown('EmployeeNumber','" + i + "')  />");
                        Response.Write("<img id='empsearch" + i + "' alt=" + Resources.Resource.SearchEmployee + " src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + i + "') />");
                        Response.Write("<input type='text' disabled id='txtEmpName" + i + "' style='width:150px' class='csstxtbox' value='' onblur=javascript:func_EmpNameSearch('" + i + "') onkeyup=javascript:func_EmpNameSearch('" + i + "') />");
                        Response.Write("<input type='text' disabled id='txtEmpDesignation" + i + "' style='width:100px' class='csstxtbox' value='' />");
                        Response.Write("<input type='text' disabled id='txtEmpRole" + i + "' style='width:130px' class='csstxtbox' value='' onblur=javascript:searchRole('" + i + "')  onkeyup=javascript:searchRole('" + i + "') />");
                        Response.Write("<input type='text' disabled id='txtShift" + i + "' style='width:40px;text-align: center' class='csstxtbox' value=''  onchange=javascript:getStdShift('" + i + "')  onkeyup=javascript:if(event.keyCode==13){getStdShift('" + i + "')} onKeyDown=javascript:FunctionCallOnKeyDown('ShiftCode','" + i + "')  />");
                        //Response.Write("<input type='text' disabled id='txtTimeFrom" + i + "' style='width:55px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','F') />");
                        //Response.Write("<input type='text' disabled id='txtTimeTo" + i + "' style='width:55px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','T') />");
                        string strTimeFromCheckStatus = string.Empty; ;
                        string strTimeToCheckStatus = string.Empty;
                        string strTimeFromColor = string.Empty;
                        string strTimeToColor = string.Empty;
                        if (BaseRotaTimeShow.ToLower().Trim() == "TRUE".ToLower().Trim().ToString())
                        {

                            if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "1")
                            {
                                strTimeFromCheckStatus = "";
                                strTimeToCheckStatus = "";
                                strTimeFromColor = "";
                                strTimeToColor = "";
                            }
                            else if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "2")
                            {
                                strTimeFromCheckStatus = "checked";
                                strTimeToCheckStatus = "";
                                strTimeFromColor = "Green";
                                strTimeToColor = "Red";
                            }
                            else if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "3")
                            {
                                strTimeFromCheckStatus = "checked";
                                strTimeToCheckStatus = "checked";
                                strTimeFromColor = "Green";
                                strTimeToColor = "Green";
                            }

                            Response.Write("<input type='text' disabled id='txtTimeFrom" + i + "' style='width:55px;text-align: center;background-color:" + strTimeFromColor + "' class='csstxtbox' maxlength='5' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','F') />");
                            Response.Write("<img border='0' disabled src='../Images/Clock.ico'  width='18px' onclick=javascript:javascript:ImgClicked('txtTimeFrom" + i + "') />");
                            Response.Write("<input type='checkbox'  style='display:none' disabled onclick=javascript:CheckChanged('" + i + "') id='CBTimeFrom" + i + "' " + strTimeFromCheckStatus + " />");
                            Response.Write("<input type='text' disabled id='txtTimeTo" + i + "' style='width:55px;text-align: center;background-color:" + strTimeToColor + "' class='csstxtbox' maxlength='5' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','T') />");
                            Response.Write("<img border='0' disabled src='../Images/Clock.ico' width='18px' onclick=javascript:javascript:ImgClicked('txtTimeTo" + i + "') />");
                            Response.Write("<input type='checkbox'  style='display:none' disabled onclick=javascript:CheckChanged('" + i + "') id='CBTimeTo" + i + "' " + strTimeToCheckStatus + "/>");
                            Response.Write("<input type='text'  maxlength='5' disabled id='txtBreakHrs" + i + "' style='width:60px;text-align: center' class='csstxtbox' maxlength='5'  value='00:00'  />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' />");

                        }
                        else
                        {
                            Response.Write("<input type='text' disabled id='txtTimeFrom" + i + "' style='width:55px;text-align: center;background-color:" + strTimeFromColor + "' class='csstxtbox' maxlength='5' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','F') />");
                            Response.Write("<input type='text' disabled id='txtTimeTo" + i + "' style='width:55px;text-align: center;background-color:" + strTimeToColor + "' class='csstxtbox' maxlength='5'  onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','T') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' />");
                        }

                        Response.Write("<input type='hidden' id='hidPdLineNo" + i + "' value='" + intNewRowPd + "' />");
                        Response.Write("<input type='hidden' id='hidRosterAutoID" + i + "' value='0' />");
                        Response.Write("<input type='hidden' id='hid_DutyType" + i + "' value='' />");
                        Response.Write("<input type='hidden' id='hid_RoleId" + i + "' value='' />");
                        Response.Write("<select disabled id='ddlDutyType" + i + "' style='width:90px' class='cssDropDown' onKeyDown=javascript:FunctionCallOnKeyDown('DutyType','" + i + "') ><option value='DT0002'>NORMAL</option><option value='DT0004'>OJT</option><option value='DT0008'>TSOAdditional</option></select>");
                    }
                    else
                    {
                        Response.Write("<input type='text' id='txtEmpNo" + i + "' style='width:60px' maxlength='6' class='csstxtbox' value='' onkeyup=javascript:if(event.keyCode==13){FunctionCallOnEnterKeyDown('EmployeeNumber','" + i + "')} onkeydown=javascript:FunctionCallOnKeyDown('EmployeeNumber','" + i + "')  />");
                        Response.Write("<img id='empsearch" + i + "' alt=" + Resources.Resource.SearchEmployee + " src='../Images/icosearch.gif' onclick=javascript:searchEmp('" + i + "') />");
                        Response.Write("<input type='text'  id='txtEmpName" + i + "' style='width:150px' class='csstxtbox' value='' onblur=javascript:func_EmpNameSearch('" + i + "') onkeyup=javascript:func_EmpNameSearch('" + i + "') />");
                        Response.Write("<input type='text' disabled id='txtEmpDesignation" + i + "' style='width:100px' class='csstxtbox' value='' />");
                        Response.Write("<input type='text' id='txtEmpRole" + i + "' style='width:130px' class='csstxtbox' value='' onblur=javascript:searchRole('" + i + "')  onkeyup=javascript:searchRole('" + i + "') />");
                        Response.Write("<input type='text' id='txtShift" + i + "' style='width:40px;text-align: center' class='csstxtbox' value=''  onchange=javascript:getStdShift('" + i + "')  onkeyup=javascript:if(event.keyCode==13){getStdShift('" + i + "')} onKeyDown=javascript:FunctionCallOnKeyDown('ShiftCode','" + i + "')  />");
                        //Response.Write("<input type='text' id='txtTimeFrom" + i + "' style='width:55px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','F') />");
                        //Response.Write("<input type='text' id='txtTimeTo" + i + "' style='width:55px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','T') />");
                        //Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' />");
                        string strTimeFromCheckStatus = string.Empty; ;
                        string strTimeToCheckStatus = string.Empty;
                        string strTimeFromColor = string.Empty;
                        string strTimeToColor = string.Empty;

                        strTimeFromCheckStatus = "";
                        strTimeToCheckStatus = "";
                        strTimeFromColor = "";
                        strTimeToColor = "";

                        if (BaseRotaTimeShow.ToLower().Trim() == "TRUE".ToLower().Trim().ToString())
                        {

                            //if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "1")
                            //{
                            //    strTimeFromCheckStatus = "";
                            //    strTimeToCheckStatus = "";
                            //    strTimeFromColor = "";
                            //    strTimeToColor = "";
                            //}
                            //else if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "2")
                            //{
                            //    strTimeFromCheckStatus = "checked";
                            //    strTimeToCheckStatus = "";
                            //    strTimeFromColor = "Green";
                            //    strTimeToColor = "Red";
                            //}
                            //else if (ds.Tables[0].Rows[i]["TimeStatus"].ToString() == "3")
                            //{
                            //    strTimeFromCheckStatus = "checked";
                            //    strTimeToCheckStatus = "checked";
                            //    strTimeFromColor = "Green";
                            //    strTimeToColor = "Green";
                            //}

                            Response.Write("<input type='text' value='00:00'  id='txtTimeFrom" + i + "' style='width:55px;text-align: center;background-color:" + strTimeFromColor + "' class='csstxtbox' maxlength='5' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','F') />");
                            Response.Write("<img border='0'  src='../Images/Clock.ico'  width='18px' onclick=javascript:javascript:ImgClicked('txtTimeFrom" + i + "') />");
                            Response.Write("<input type='checkbox'  style='display:none' disabled onclick=javascript:CheckChanged('" + i + "') id='CBTimeFrom" + i + "' " + strTimeFromCheckStatus + " />");
                            Response.Write("<input type='text' value='00:00' id='txtTimeTo" + i + "' style='width:55px;text-align: center;background-color:" + strTimeToColor + "' class='csstxtbox' maxlength='5' onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','T') />");
                            Response.Write("<img border='0'  src='../Images/Clock.ico' width='18px' onclick=javascript:javascript:ImgClicked('txtTimeTo" + i + "') />");
                            Response.Write("<input type='checkbox'  style='display:none' disabled onclick=javascript:CheckChanged('" + i + "') id='CBTimeTo" + i + "' " + strTimeToCheckStatus + "/>");
                            Response.Write("<input type='text'  maxlength='5' id='txtBreakHrs" + i + "' style='width:60px;text-align: center' class='csstxtbox' maxlength='5'  value='0'  onblur=javascript:convertHoursToMin('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','B') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' />");

                        }
                        else
                        {
                            Response.Write("<input type='text' disabled id='txtTimeFrom" + i + "' style='width:55px;text-align: center;background-color:" + strTimeFromColor + "' class='csstxtbox' maxlength='5' onblur=javascript:IsValidTime1('txtTimeFrom" + i + "','txtTimeTo" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','F') />");
                            Response.Write("<input type='text' disabled id='txtTimeTo" + i + "' style='width:55px;text-align: center;background-color:" + strTimeToColor + "' class='csstxtbox' maxlength='5'  onblur=javascript:IsValidTime1('txtTimeTo" + i + "','txtTimeFrom" + i + "','txtDutyHrs" + i + "','txtBreakHrs" + i + "','T') />");
                            Response.Write("<input type='text' disabled id='txtDutyHrs" + i + "' style='width:40px;text-align: center' class='csstxtbox' maxlength='5' value='00:00' />");
                        }
                        Response.Write("<input type='hidden' id='hidPdLineNo" + i + "' value='" + intNewRowPd + "' />");
                        Response.Write("<input type='hidden' id='hidRosterAutoID" + i + "' value='0' />");
                        Response.Write("<input type='hidden' id='hid_DutyType" + i + "' value='' />");
                        Response.Write("<input type='hidden' id='hid_RoleId" + i + "' value='' />");
                        Response.Write("<select id='ddlDutyType" + i + "' style='width:90px' class='cssDropDown' onKeyDown=javascript:FunctionCallOnKeyDown('DutyType','" + i + "') ><option value='DT0002'>NORMAL</option><option value='DT0004'>OJT</option><option value='DT0008'>TSOAdditional</option></select>");
                    }

                    Response.Write("</td></tr>");
                }



                Response.Write("<tr><td><input type='hidden' id='hidTotalRow' value='" + (ds.Tables[0].Rows.Count + intNewRow) + "' /></td></tr>");
                Response.Write("</table>||");
                Response.Write("<table ><Tr>");
                if (strStatus == "1")
                {
                    Response.Write("<td><a href=# onclick=LoadRotaSheet(0,1,1) class=gb1>" + " << " + "</a></td>");
                    for (int intStartPage = 1; intStartPage <= intPageCount; intStartPage++)
                    {
                        Response.Write("<td><a href=# onclick=LoadRotaSheet(0," + intStartPage + ",1) class=gb1>" + intStartPage + "</a></td>");
                    }
                    Response.Write("<td><a href=# onclick=LoadRotaSheet(0," + intPageCount + ",1) class=gb1>" + " >> " + "</a></td>");
                    Response.Write("<td>Page " + intPageNo + " of " + intPageCount + "</td>");
                    Response.Write("</Tr>");
                    Response.Write("<input type='hidden' id='HFtest' value='1' />");
                }
                else if (strStatus == "0")
                {
                    Response.Write("<td><a href=# onclick=LoadRotaSheet(0,1,1) class=gb1>" + " << " + "</a></td>");

                    for (int intStartPage = 1; intStartPage <= intPageCount; intStartPage++)
                    {
                        Response.Write("<td><a href=# onclick=LoadRotaSheet(0," + intStartPage + ",1) class=gb1>" + intStartPage + "</a></td>");
                    }
                    Response.Write("<td><a href=# onclick=LoadRotaSheet(0," + intPageCount + ",1) class=gb1>" + " >> " + "</a></td>");
                    Response.Write("<td>Page " + ds.Tables[0].Rows[0]["PageRef"].ToString() + " of " + intPageCount + "</td>");
                    Response.Write("</Tr>");
                    //HFCurrentPageNoStatus.Value = ds.Tables[0].Rows[0]["PageRef"].ToString();
                    Response.Write("<input type='hidden' id='HFtest' value='" + ds.Tables[0].Rows[0]["PageRef"].ToString() + "' />");
                }

                Response.Write("</table >");
                Response.Write("<table >");

                //Response.Write("<Tr><Td>");
                //Response.Write("<td>Page " + intPageNo + " of " + intPageCount + "</td>");
                //Response.Write("</Td></Tr>");
                //Response.Write("</table>");


                Response.End();
            }
            else
            {
                Response.Write(Resources.Resource.AssignmentHasExpired);
                Response.Write("|| ");
                Response.End();
            }
        }
        else
        {
            Response.Write(Resources.Resource.NOAccessRights);
            Response.End();
        }
    }
}
