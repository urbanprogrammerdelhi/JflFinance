// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="AutoCompleteTextBox.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using DL;
using CommonLibrary.Session;
using OperationManagement = BL.OperationManagement;
using Sales = BL.Sales;

/// <summary>
///     Summary description for AutoCompleteTextBox
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AutoCompleteTextBox : WebService
{
    /// <summary>
    ///     Autoes the complete text box client code.
    /// </summary>
    /// <param name="prefixText">The prefix text.</param>
    /// <param name="count">The count.</param>
    /// <returns>String[][].</returns>
    [WebMethod]
    public String[] AutoCompleteTextBoxClientCode(String prefixText, int count)
    {
        var titleArList = new List<string>();
        var objsales = new Sales();
        using (var drAutoCompleteType = objsales.ClientListGet(prefixText, "ClientCode"))
        {
            while (drAutoCompleteType.Read())
            {
                var strTemp = Convert.ToString(drAutoCompleteType["ClientCode"]);
                titleArList.Add(strTemp);
            }
        }
        return titleArList.ToArray();
    }

    /// <summary>
    ///     Autoes the name of the complete text box client.
    /// </summary>
    /// <param name="prefixText">The prefix text.</param>
    /// <param name="count">The count.</param>
    /// <returns>String[][].</returns>
    [WebMethod]
    public String[] AutoCompleteTextBoxClientName(String prefixText, int count)
    {
        var titleArList = new List<string>();
        var objsales = new Sales();
        using (var drAutoCompleteType = objsales.ClientListGet(prefixText, "ClientName"))
        {
            while (drAutoCompleteType.Read())
            {
                var strTemp = Convert.ToString(drAutoCompleteType["ClientName"]);
                titleArList.Add(strTemp);
            }
        }
        return titleArList.ToArray();
    }

    /// <summary>
    ///     Webs the get allowance.
    /// </summary>
    /// <param name="comnnectionString">The comnnection string.</param>
    /// <param name="companyCode">The company code.</param>
    /// <param name="hrLocationCode">The hr location code.</param>
    /// <param name="locationCode">The location code.</param>
    /// <param name="schRosterAutoID">The SCH roster auto ID.</param>
    /// <param name="attendanceType">Type of the attendance.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string WebGetAllowance(String comnnectionString, String companyCode, String hrLocationCode,
        String locationCode, String schRosterAutoID, String attendanceType)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(comnnectionString);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udpTransaction_ScheduleEmpWise_AllowanceGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.ScheduleRosterAutoID, SqlDbType.NVarChar).Value =
                schRosterAutoID;
            command.Parameters.Add(DL.Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = companyCode;
            command.Parameters.Add(DL.Properties.Resources.HrLocationCode, SqlDbType.NVarChar).Value = hrLocationCode;
            command.Parameters.Add(DL.Properties.Resources.LocationCode, SqlDbType.NVarChar).Value = locationCode;
            command.Parameters.Add(DL.Properties.Resources.AttendanceType, SqlDbType.NVarChar).Value = attendanceType;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            return strRota;
        }
    }

    //[WebMethod]
    //public String[] AutoCompleteTextBoxLocationCode(String prefixText, int count)
    //{
    //    List<String> titleArList = new List<string>();
    //    BL.MastersManagement objMastersManagement = new BL.MastersManagement();
    //    SqlDataReader dr = objMastersManagement.blLocationCode_Get(prefixText, "LocationCode");
    //    while (dr.Read())
    //    {
    //        String strTemp = Convert.ToString(dr["LocationCode"]);
    //        titleArList.Add(strTemp);
    //    }
    //    dr.Close();
    //    dr.Dispose(); 
    //    return titleArList.ToArray();
    //}

    /// <summary>
    ///     Gets the un scheduled employees.
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strCompanyCode">The STR company code.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetUnScheduledEmployees(string strComnnectionString, string strLocationAutoID, string strCompanyCode,
        string strFromDate, string strToDate)
    {
        //string connect = System.Configuration.ConfigurationManager.AppSettings[strComnnectionString];
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strComnnectionString);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udp_EmpNotScheduleBwDates_get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = strCompanyCode;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Searches the post ID.
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strPostID">The STR post ID.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strClientCode">The STR client code.</param>
    /// <param name="strAreaID">The STR area ID.</param>
    /// <param name="strAreaIncharge">The STR area incharge.</param>
    /// <param name="strIsAreaIncharge">The STR is area incharge.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string SearchPostID(string strComnnectionString, string strLocationAutoID, string strPostID,
        string strFromDate, string strToDate, string strClientCode, string strAreaID, string strAreaIncharge,
        string strIsAreaIncharge)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strComnnectionString);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpTransaction_ScheduleEmpWise_GetPost", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.Post, SqlDbType.NVarChar).Value = strPostID;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = strClientCode;
            // Area ID Added to get only those post which belongs to that Area. Added on 17-Sep-2011
            command.Parameters.Add(DL.Properties.Resources.AreaId, SqlDbType.NVarChar).Value = strAreaID;
            command.Parameters.Add(DL.Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = strAreaIncharge;
            command.Parameters.Add(DL.Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = strIsAreaIncharge;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Gets all shifts of day.
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strDutyDate">The STR duty date.</param>
    /// <param name="strWeekNumber">The STR week number.</param>
    /// <param name="strPost">The STR post.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAllShiftsOfDay(string strComnnectionString, string strAsmtCode, string strLocationAutoID,
        string strDutyDate, string strWeekNumber, string strPost)
    {
        // ds=ObjRoster.blScheduleRosterEmpWise_GetShift(strAsmtCode, strLocationAutoID, strDutyDate, strWeekNumber);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strComnnectionString);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpTransaction_ScheduleEmpWise_GetShift", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = strDutyDate;
            command.Parameters.Add(DL.Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = strWeekNumber;
            command.Parameters.Add(DL.Properties.Resources.Post, SqlDbType.NVarChar).Value = strPost;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Gets all post of assignment.
    /// </summary>
    /// <param name="strComnnectionString">The STR comnnection string.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAllPostOfAssignment(string strComnnectionString, string strAsmtCode, string strLocationAutoID,
        string strFromDate, string strToDate)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strComnnectionString);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpTransaction_ScheduleEmpWise_GetAllPost", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Autoes the complete text box incident number.
    /// </summary>
    /// <param name="prefixText">The prefix text.</param>
    /// <param name="count">The count.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <returns>String[][].</returns>
    [WebMethod]
    public String[] AutoCompleteTextBoxIncidentNumber(String prefixText, int count, string strLocationAutoID)
    {
        var titleArList = new List<string>();
        var objOperationManagement = new OperationManagement();
        using (
            var drAutoCompleteType = objOperationManagement.IncidentNumberGet(prefixText, "IncidentNo",
                strLocationAutoID))
        {
            while (drAutoCompleteType.Read())
            {
                var strTemp = Convert.ToString(drAutoCompleteType["IncidentNo"]);
                titleArList.Add(strTemp);
            }
        }
        return titleArList.ToArray();
    }

    /// <summary>
    ///     Employees the weekly rota.
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strDutyDate">The STR duty date.</param>
    /// <param name="intLocationAutoId">The int location auto id.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string EmployeeWeeklyRota(string strEmployeeNumber, string strDutyDate, int intLocationAutoId)
    {
        var objCon = new ConnectionString();

        var uInfo = new UserInformation();
        var connect = objCon.ConnectionStringGet(uInfo.CountryCode);

        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpTran_EmployeeWeeklyRota_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = strDutyDate;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = intLocationAutoId;

            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
        //System.IO.StringWriter sw = new System.IO.StringWriter();
        //dt1.WriteXml(sw);
        //XmlDataDocument xml = new XmlDataDocument();
        //xml.LoadXml(sw.ToString());
        //return xml;
    }

    /// <summary>
    ///     Copy the Schedules.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="nWeek">The n week.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strSchAutoIds">The STR SCH auto ids.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strPatCode">The STR pat code.</param>
    /// <param name="strPos">The STR pos.</param>
    /// <param name="strDefalt">The STR defalt.</param>
    /// <param name="strRowNumber">The STR row number.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string ScheduleCopy(string strCon, int nWeek, string strEmployeeNumber, string strSchAutoIds,
        string strFromDate, string strToDate, string strPatCode, string strPos, string strDefalt, string strRowNumber,
        string strAttendanceType, string strModifiedBy)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
            {
                command = new SqlCommand("udpTran_ScheduleRosterEmpWise_Copy", scn);
            }
            else
            {
                command = new SqlCommand("udpTran_RosterEmpWise_Copy", scn);
            }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
            command.Parameters.Add(DL.Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value = strSchAutoIds;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            command.Parameters.Add(DL.Properties.Resources.ShiftPatternCode, SqlDbType.NVarChar).Value = strPatCode;
            command.Parameters.Add(DL.Properties.Resources.PatternPosition, SqlDbType.NVarChar).Value = strPos;
            command.Parameters.Add(DL.Properties.Resources.IsDefault, SqlDbType.NVarChar).Value = strDefalt;
            command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
            command.Parameters.Add(DL.Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = nWeek;
            command.Parameters.Add(DL.Properties.Resources.RowNumber, SqlDbType.Int).Value = int.Parse(strRowNumber);
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Asmts the schedule copy.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="nWeek">The n week.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <param name="pdLineNo">The pd line no.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AsmtScheduleCopy(string strCon, int nWeek, string strAsmtCode, string strFromDate, string strToDate,
        string strAttendanceType, string strModifiedBy, string pdLineNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
            {
                command = new SqlCommand("UdpTrans_CopyScheduleNextWeek", scn);
            }
            else
            {
                command = new SqlCommand("UdpTrans_CopyRotaNextWeek", scn);
            }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
            command.Parameters.Add(DL.Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = nWeek;
            command.Parameters.Add(DL.Properties.Resources.PDLineNo, SqlDbType.NVarChar).Value = pdLineNo;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Applies the week off.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="LocationAutoId">The location auto id.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strDutyDate">The STR duty date.</param>
    /// <param name="strWeek">The STR week.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="strShiftPat">The STR shift pat.</param>
    /// <param name="shiftPos">The shift pos.</param>
    /// <param name="strDefault">The STR default.</param>
    /// <param name="strSoRank">The STR so rank.</param>
    /// <param name="strRowNumber">The STR row number.</param>
    /// <param name="strPost">The STR post.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string ApplyWeekOff(string strCon, int LocationAutoId, string strEmployeeNumber, string strDutyDate,
        string strWeek, string strModifiedBy, string strAsmtCode, string strShiftPat, int shiftPos, string strDefault,
        string strSoRank, string strRowNumber, string strPost, string strAttendanceType)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
            {
                command = new SqlCommand("udpTrn_SchEmpWiseWeeklyOff_Save", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value =
                    LocationAutoId;
                command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value =
                    strEmployeeNumber;
                // command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = strDutyDate;
                command.Parameters.Add(DL.Properties.Resources.DutyDate, strDutyDate);
                command.Parameters.Add(DL.Properties.Resources.IsWeekOff, SqlDbType.NVarChar).Value = strWeek;
                command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
                command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
                command.Parameters.Add(DL.Properties.Resources.ShiftPatternCode, SqlDbType.NVarChar).Value = strShiftPat;
                command.Parameters.Add(DL.Properties.Resources.PatternPosition, SqlDbType.NVarChar).Value = shiftPos;
                command.Parameters.Add(DL.Properties.Resources.DefaultSite, SqlDbType.NVarChar).Value = strDefault;
                command.Parameters.Add(DL.Properties.Resources.SORank, SqlDbType.NVarChar).Value = strSoRank;
                command.Parameters.Add(DL.Properties.Resources.RowNumber, SqlDbType.Int).Value = int.Parse(strRowNumber);
                command.Parameters.Add(DL.Properties.Resources.Post, SqlDbType.NVarChar).Value = strPost;
            }
            else
            {
                command = new SqlCommand("udpTrn_RosterEmpWiseWeeklyOff_Save", scn);
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(DL.Properties.Resources.LocationAutoID, SqlDbType.NVarChar).Value = LocationAutoId;
                //command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
                //command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = strDutyDate;
                //command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
                command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value =
                    LocationAutoId;
                command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value =
                    strEmployeeNumber;
                command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = strDutyDate;
                command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
                command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
                command.Parameters.Add(DL.Properties.Resources.RowNumber, SqlDbType.Int).Value = int.Parse(strRowNumber);
                command.Parameters.Add(DL.Properties.Resources.Post, SqlDbType.NVarChar).Value = strPost;
            }


            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Changes the type of the duty.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="strSchAutoId">The STR SCH auto id.</param>
    /// <param name="strDutyType">Type of the STR duty.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string ChangeDutyType(string strCon, string strSchAutoId, string strDutyType, string strAttendanceType,
        string strModifiedBy)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (strAttendanceType.Trim().ToLower() == "Sch".Trim().ToLower())
            {
                command = new SqlCommand("udpTran_ScheduleRoster_ChangeDutyType", scn);
            }
            else
            {
                command = new SqlCommand("udpTran_Roster_ChangeDutyType", scn);
            }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value = strSchAutoId;
            command.Parameters.Add(DL.Properties.Resources.DutyTypeDesc, SqlDbType.NVarChar).Value = strDutyType;
            command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;

            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Alls the shifts of asmt.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="LocationAutoId">The location auto id.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="intWeekNo">The int week no.</param>
    /// <param name="postCode">The post code.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AllShiftsOfAsmt(string strCon, int LocationAutoId, string strAsmtCode, int intWeekNo, string postCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpOPS_AllAsmtShift_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.WeekNo, SqlDbType.NVarChar).Value = intWeekNo;
            command.Parameters.Add(DL.Properties.Resources.PostCode, SqlDbType.NVarChar).Value = postCode;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strShift = ds.GetXml();
            ds.Dispose();
            return strShift;
        }
    }

    /// <summary>
    ///     Checks the alert.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string CheckAlert(string strCon, string strLocationAutoID, string strAttendanceType, string strFromDate,
        string strToDate, string strEmployeeNumber)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
            {
                command = new SqlCommand("udpTrans_ScheduleEmpWise_CheckAlert", scn);
            }
            else
            {
                command = new SqlCommand("udpTrans_RosterEmpWise_CheckAlert", scn);
            }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strCheckAlert = ds.GetXml();
            ds.Dispose();
            return strCheckAlert;
        }
    }

    /// <summary>
    ///     Gets the employee schedule.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="intLocationAutoId">The int location auto id.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strAreaID">The STR area ID.</param>
    /// <param name="strAreaIncharge">The STR area incharge.</param>
    /// <param name="strIsAreaIncharge">The STR is area incharge.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetEmployeeSchedule(string strCon, int intLocationAutoId, string strEmployeeNumber, string strFromDate,
        string strToDate, string strAttendanceType, string strAreaID, string strAreaIncharge, string strIsAreaIncharge)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (strAttendanceType.Trim().ToLower() == "sch".Trim().ToLower())
            {
                command = new SqlCommand("udpTrans_ScheduleOfEmployee_Get", scn);
            }
            else
            {
                command = new SqlCommand("udpTrans_RosterOfEmployee_Get", scn);
            }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = intLocationAutoId;
            //Added Area ID option to search only those employee that belongs to that Area
            command.Parameters.Add(DL.Properties.Resources.AreaId, SqlDbType.NVarChar).Value = strAreaID;
            command.Parameters.Add(DL.Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = strAreaIncharge;
            command.Parameters.Add(DL.Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = strIsAreaIncharge;

            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);


            var strSchedule = ds.GetXml();
            ds.Dispose();
            return strSchedule;
        }
    }

    /// <summary>
    ///     Gets Job Break Down And Role Detail in Scheduling Screen
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="strCompanyCode">The STR company code.</param>
    /// <param name="strHrLocationCode">The STR hr location code.</param>
    /// <param name="strLocationCode">The STR location code.</param>
    /// <param name="strSchRosterAutoId">The STR SCH roster auto id.</param>
    /// <param name="strAttendanceType">Type of the STR attendance.</param>
    /// <param name="strAreaID">The STR area ID.</param>
    /// <param name="strAreaIncharge">The STR area incharge.</param>
    /// <param name="strIsAreaIncharge">The STR is area incharge.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetJobBreakDownSummary(string strCon, string strCompanyCode, string strHrLocationCode,
        string strLocationCode, string strSchRosterAutoId, string strAttendanceType, string strAreaID,
        string strAreaIncharge, string strIsAreaIncharge, string strFromDate, string strToDate)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpTransaction_ScheduleEmpWise_JobBreakDownSummary", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.SchRosterAutoId, SqlDbType.NVarChar).Value =
                strSchRosterAutoId;
            command.Parameters.Add(DL.Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = strCompanyCode;
            command.Parameters.Add(DL.Properties.Resources.HrLocationCode, SqlDbType.NVarChar).Value = strHrLocationCode;
            command.Parameters.Add(DL.Properties.Resources.LocationCode, SqlDbType.NVarChar).Value = strLocationCode;
            command.Parameters.Add(DL.Properties.Resources.AttendanceType, SqlDbType.NVarChar).Value = strAttendanceType;
            //Added Area ID option to search only those employee that belongs to that Area
            command.Parameters.Add(DL.Properties.Resources.AreaId, SqlDbType.NVarChar).Value = strAreaID;
            command.Parameters.Add(DL.Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = strAreaIncharge;
            command.Parameters.Add(DL.Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = strIsAreaIncharge;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;

            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     Webs the asmts of client.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="intLocationAutoId">The int location auto id.</param>
    /// <param name="strClientCode">The STR client code.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AsmtsOfClient(string strCon, int intLocationAutoId, string strClientCode, string strFromDate,
        string strToDate)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpOPS_AsmtsOfClient_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = intLocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = strClientCode;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;

            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strRota = ds.GetXml();
            ds.Dispose();
            return strRota;
        }
    }

    /// <summary>
    ///     get Sites and post of asmt.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="intLocationAutoId">The int location auto id.</param>
    /// <param name="intAsmtAutoId">The int asmt auto id.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string SitePostOfAsmt(string strCon, int intLocationAutoId, int intAsmtAutoId, string strFromDate)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpOPS_AsmtSitePost_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AsmtMasterAutoId, SqlDbType.NVarChar).Value = intAsmtAutoId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = intLocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = strFromDate;

            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strSite = ds.GetXml();
            ds.Dispose();
            return strSite;
        }
    }

    /// <summary>
    ///     Alls the shifts of asmt daily rota.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="LocationAutoId">The location auto id.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="strDate">The STR date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AllShiftsOfAsmtDailyRota(string strCon, int LocationAutoId, string strAsmtCode, string strDate)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpOPS_AllAsmtShiftDailyRota_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.Date, SqlDbType.NVarChar).Value = strDate;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);


            var strShift = ds.GetXml();
            ds.Dispose();
            return strShift;
        }
    }

    /// <summary>
    ///     Alls the shifts of asmt monthly rota.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="LocationAutoId">The location auto id.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AllShiftsOfAsmtMonthlyRota(string strCon, int LocationAutoId, string strAsmtCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpOPS_AllAsmtShiftMonthlyRota_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = LocationAutoId;

            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);


            var strShift = ds.GetXml();
            ds.Dispose();
            return strShift;
        }
    }

    /// <summary>
    ///     Webs the insert exception records.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="strCurrentSessionID">The STR current session ID.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strScreenType">Type of the STR screen.</param>
    /// <param name="strExceptionEmployeeNumber">The STR exception employee number.</param>
    /// <param name="strExceptionClickStatus">The STR exception click status.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string InsertExceptionRecords(string strCon, string strFromDate, string strToDate, string strAsmtCode,
        string strCurrentSessionID, string strLocationAutoID, string strScreenType, string strExceptionEmployeeNumber,
        string strExceptionClickStatus, string strModifiedBy)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (strScreenType.Trim().ToLower() == "sch".Trim().ToLower())
            {
                command = new SqlCommand("udpTran_ScheduleRosterEmpWise_ExceptionInsert", scn);
            }
            else
            {
                command = new SqlCommand("udpTran_RosterEmpWise_ExceptionInsert", scn);
            }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
            command.Parameters.Add(DL.Properties.Resources.CurrentSessionID, SqlDbType.NVarChar).Value =
                strCurrentSessionID;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value =
                strExceptionEmployeeNumber;
            command.Parameters.Add(DL.Properties.Resources.ExceptionClickStatus, SqlDbType.NVarChar).Value =
                strExceptionClickStatus;
            command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strGetOutPut = ds.GetXml();
            ds.Dispose();
            return strGetOutPut;
        }
    }

    /// <summary>
    ///     To  lock unlock status
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="asmtMasterAutoID">The asmt master auto ID.</param>
    /// <param name="locationAutoID">The location auto ID.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetAllLockUnLockStatus(string strCon, string asmtMasterAutoID, string locationAutoID, string fromDate,
        string toDate)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udpTran_ScheduleRosterEmpWise_GetLockUnLockStatus", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AsmtMasterAutoId, SqlDbType.NVarChar).Value =
                asmtMasterAutoID;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoID;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strGetOutPut = ds.GetXml();
            return strGetOutPut;
        }
    }

    /// <summary>
    ///     To get exception records in Scheduling screen.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="strFromDate">The STR from date.</param>
    /// <param name="strToDate">The STR to date.</param>
    /// <param name="strMaxDate">The STR max date.</param>
    /// <param name="strAsmtCode">The STR asmt code.</param>
    /// <param name="strCurrentSessionID">The STR current session ID.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strScreenType">Type of the STR screen.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string GetExceptionRecords(string strCon, string strFromDate, string strToDate, string strMaxDate,
        string strAsmtCode, string strCurrentSessionID, string strLocationAutoID, string strScreenType,
        string strEmployeeNumber, string strModifiedBy)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (strScreenType.Trim().ToLower() == "sch".Trim().ToLower())
            {
                command = new SqlCommand("udpTran_ScheduleRosterEmpWise_ExceptionGet", scn);
            }
            else
            {
                command = new SqlCommand("udpTran_RosterEmpWise_ExceptionGet", scn);
            }
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = strFromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = strToDate;
            command.Parameters.Add(DL.Properties.Resources.MaxDate, SqlDbType.NVarChar).Value = strMaxDate;
            command.Parameters.Add(DL.Properties.Resources.AsmtCode, SqlDbType.NVarChar).Value = strAsmtCode;
            command.Parameters.Add(DL.Properties.Resources.CurrentSessionID, SqlDbType.NVarChar).Value =
                strCurrentSessionID;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = strLocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
            command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strGetOutPut = ds.GetXml();
            return strGetOutPut;
        }
    }

    /// <summary>
    ///     Gets all clients.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="areaId">The area id.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="isAreaIncharge">The is area incharge.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <returns>Xml Data</returns>
    [WebMethod]
    public string GetAllClients(string strCon, string locationAutoId, string areaId, string clientCode,
        string employeeNumber, string isAreaIncharge, string fromDate, string toDate)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udpMst_ClientLocationMappedAreaWise_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
            command.Parameters.Add(DL.Properties.Resources.AreaId, SqlDbType.NVarChar).Value = areaId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
            command.Parameters.Add(DL.Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = isAreaIncharge;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strGetOutPut = ds.GetXml();
            return strGetOutPut;
        }
    }

    /// <summary>
    ///     Gets all assignments.
    /// </summary>
    /// <param name="strCon">The STR con.</param>
    /// <param name="locationAutoId">The location auto id.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="fromDate">From date.</param>
    /// <param name="toDate">To date.</param>
    /// <param name="employeeNumber">The employee number.</param>
    /// <param name="isAreaIncharge">The is area incharge.</param>
    /// <param name="areaId">The area id.</param>
    /// <returns>Xml Data</returns>
    [WebMethod]
    public string GetAllAssignments(string strCon, string locationAutoId, string clientCode, string fromDate,
        string toDate, string employeeNumber, string isAreaIncharge, string areaId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strCon);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udpOPS_AsmtsOfClient_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
            command.Parameters.Add(DL.Properties.Resources.AreaId, SqlDbType.NVarChar).Value = areaId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
            command.Parameters.Add(DL.Properties.Resources.AreaIncharge, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.IsAreaIncharge, SqlDbType.NVarChar).Value = isAreaIncharge;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.NVarChar).Value = fromDate;
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.NVarChar).Value = toDate;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strGetOutPut = ds.GetXml();
            return strGetOutPut;
        }
    }

    #region Function related to Constraints

    /// <summary>
    ///     Checks the skills.
    /// </summary>
    /// <param name="strConnectionString">The STR connection string.</param>
    /// <param name="strCompanyCode">The STR company code.</param>
    /// <param name="strSoNo">The STR so no.</param>
    /// <param name="strSoLineNo">The STR so line no.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string CheckSkills(string strConnectionString, string strCompanyCode, string strSoNo, string strSoLineNo,
        string strEmployeeNumber)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strConnectionString);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpOPS_Constraint_CheckSkills", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = strCompanyCode;
            command.Parameters.Add(DL.Properties.Resources.SONO, SqlDbType.NVarChar).Value = strSoNo;
            command.Parameters.Add(DL.Properties.Resources.SoLineNo, SqlDbType.NVarChar).Value = strSoLineNo;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strCheckSkills = ds.GetXml();

            return strCheckSkills;
        }
    }

    /// <summary>
    ///     employee preferances insert.
    /// </summary>
    /// <param name="strConnectionKey">The STR connection key.</param>
    /// <param name="strCompanyCode">The STR company code.</param>
    /// <param name="strAsmtMasterAutoID">The STR asmt master auto ID.</param>
    /// <param name="strSoNo">The STR so no.</param>
    /// <param name="strSoLineNo">The STR so line no.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strEmployeeType">Type of the STR employee.</param>
    /// <param name="strPdLineNo">The STR pd line no.</param>
    /// <param name="strModifiedBy">The STR modified by.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string AsmtEmployeePreferancesInsert(string strConnectionKey, string strCompanyCode,
        string strAsmtMasterAutoID, string strSoNo, string strSoLineNo, string strEmployeeNumber, string strEmployeeType,
        string strPdLineNo, string strModifiedBy)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(strConnectionKey);
        using (var scn = new SqlConnection(connect))
        {
            var command = new SqlCommand("udpOPS_AsmtEmployeePreferances_Insert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.CompanyCode, SqlDbType.NVarChar).Value = strCompanyCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtMasterAutoId, SqlDbType.NVarChar).Value =
                strAsmtMasterAutoID;
            command.Parameters.Add(DL.Properties.Resources.SONO, SqlDbType.NVarChar).Value = strSoNo;
            command.Parameters.Add(DL.Properties.Resources.SoLineNo, SqlDbType.NVarChar).Value = strSoLineNo;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = strEmployeeNumber;
            command.Parameters.Add(DL.Properties.Resources.EmployeeType, SqlDbType.NVarChar).Value = strEmployeeType;
            command.Parameters.Add(DL.Properties.Resources.PDLineNo, SqlDbType.NVarChar).Value = strPdLineNo;
            command.Parameters.Add(DL.Properties.Resources.ModifiedBy, SqlDbType.NVarChar).Value = strModifiedBy;

            scn.Open();

            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            var strInsertSkills = ds.GetXml();

            return strInsertSkills;
        }
    }

    #endregion
}