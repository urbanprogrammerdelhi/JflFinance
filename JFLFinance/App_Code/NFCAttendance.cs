// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-14-2014
// ***********************************************************************
// <copyright file="NFCAttendance.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

/// <summary>
///     Summary description for NFCAttendance
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class NFCAttendance : WebService
{
    //// [WebMethod]
    // public string HelloWorld()
    // {
    //     return "Hello World";
    // }

    /// <summary>
    ///     Capture attendance directly through  cell phone.
    /// </summary>
    /// <param name="IMEI">Cell phone Unique Number</param>
    /// <param name="EmpTag">Employee NFC enabled identification Number</param>
    /// <param name="SwipeType">To verify either its IN or out attendance</param>
    /// <param name="swipeDate">Attendance date and time</param>
    /// <returns>String.</returns>
    [WebMethod]
    public String AttendanceNFC(string IMEI, string EmpTag, string SwipeType, string swipeDate)
    {
        var Msg = string.Empty;
        var connect = ConfigurationManager.AppSettings["GreeceCon"];

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            if (string.IsNullOrEmpty(IMEI) || string.IsNullOrEmpty(EmpTag) || string.IsNullOrEmpty(SwipeType) ||
                string.IsNullOrEmpty(swipeDate))
                return Msg = "Error:Missing Some Field ";
            try
            {
                command = new SqlCommand("NFC_Direct_Attendance", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@IMEI", SqlDbType.NVarChar).Value = IMEI;
                command.Parameters.Add("@EmpTag", SqlDbType.NVarChar).Value = EmpTag;
                command.Parameters.Add("@DutyDate", SqlDbType.DateTime).Value = DateTime.Parse(swipeDate);
                command.Parameters.Add("@AttendanceTime", SqlDbType.DateTime).Value = DateTime.Parse(swipeDate);
                command.Parameters.Add("@AttendanceType", SqlDbType.NVarChar).Value = SwipeType;
                scn.Open();

                command.ExecuteNonQuery();
                return Msg = "Success:";
            }


            catch
            {
                return Msg = "Error";
            }

            finally
            {
                scn.Close();
            }
        }
    }

    /// <summary>
    ///     Capture POP(proof of presence directly through  cell phone.
    /// </summary>
    /// <param name="SpID">SupervisiorID optional</param>
    /// <param name="LocID">LocationID optional</param>
    /// <param name="EmpTag">Employee NFC enabled identification Number</param>
    /// <param name="IMEI">Cell phone Unique Number</param>
    /// <param name="SwipeType">Type Is pop</param>
    /// <param name="swipeDate">The swipe date.</param>
    /// <returns>System.String.</returns>
    [WebMethod]
    public string POPNFC(string SpID, string LocID, string EmpTag, string IMEI, string SwipeType, string swipeDate)
    {
        var Msg = string.Empty;
        var connect = ConfigurationManager.AppSettings["GreeceCon"];
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;


            if (string.IsNullOrEmpty(IMEI) || string.IsNullOrEmpty(EmpTag) || string.IsNullOrEmpty(SwipeType) ||
                string.IsNullOrEmpty(SwipeType))
                return Msg = "Error:Missing Some Field ";

            try
            {
                command = new SqlCommand("NFC_Direct_POP", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SpID", SqlDbType.NVarChar).Value = SpID;
                command.Parameters.Add("@LocID", SqlDbType.NVarChar).Value = LocID;
                command.Parameters.Add("@EmpTag", SqlDbType.NVarChar).Value = EmpTag;
                command.Parameters.Add("@IMEI", SqlDbType.NVarChar).Value = IMEI;
                command.Parameters.Add("@DutyDate", SqlDbType.DateTime).Value = swipeDate;
                command.Parameters.Add("@AttendanceTime", SqlDbType.DateTime).Value = swipeDate;
                command.Parameters.Add("@AttendanceType", SqlDbType.NVarChar).Value = SwipeType;
                scn.Open();
                command.ExecuteNonQuery();
                return Msg = "Success:";
            }

            catch
            {
                return Msg = "Error:";
            }

            finally
            {
                scn.Close();
            }
        }
    }
}