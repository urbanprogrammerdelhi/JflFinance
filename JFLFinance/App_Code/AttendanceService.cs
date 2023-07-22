using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.ComponentModel;
using DL;
using System.Globalization;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AttendanceService : WebService
{
    #region Posts
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAllPostOfAssignment(string IMEI, string connectionKey, string userId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpDeviceAllPostGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            var objConvertDatatableToJson = new ConvertDatatableToJson();
            string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(jsonString);
            //return jsonString;
            //var strRota = ds.GetXml();
            //return strRota;
        }
    }
    #endregion

    #region Employees
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAllEmployees(string IMEI, string connectionKey, string userId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpDeviceAllEmployees", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            
            adapter.Fill(ds);
        }
            var objConvertDatatableToJson = new ConvertDatatableToJson();
            string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
            //return jsonString;
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(jsonString);
    }
    #endregion Employees

    #region Login
    /// <summary>
    /// 
    /// </summary>
    /// <param name="IMEI">Device IMEI Number</param>
    /// <param name="clientCode">Client Code</param>
    /// <param name="asmtId">Assignment or Site Id</param>
    /// <param name="password">the password</param>
    /// <returns>Login sucess true/false</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Login(string IMEI, string connectionKey, string userId, string password)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        string strPwdkey = GetDecryptkey(connectionKey);
        ds = BLUserDetailGet(userId, password, strPwdkey, connect);

        //var objConvertDatatableToJson = new ConvertDatatableToJson();
        //string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        //Context.Response.Clear();
        //Context.Response.ContentType = "application/json";
        //Context.Response.Write(jsonString);
        if(ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count> 0)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write("[{'Success':'true'}]");
        }
        else
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write("[{'Success':'true'}]");
        }

        //DataSet ds = objblUserManagement.UserDetailGet(txtUserID.Text, txtPassword.Text, strPwdkey);
        //Context.Response.Clear();
        //Context.Response.ContentType = "application/json";
        //Context.Response.Write("[{'Success':'true'}]");

        var ds1 = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpDeviceUserBranchRightsGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds1);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds1.Tables[0]);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    protected string GetDecryptkey(string strCountry)
    {
        var objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);
    }
    protected bool DoesPasswordMatch(string hashedPwdFromDatabase, string userEnteredPassword, bool useGivenSalt, string Key)
    {
        if (useGivenSalt)
        {
            return BCrypt.CheckPassword(userEnteredPassword + Key, hashedPwdFromDatabase);
        }
        else
        {
            return BCrypt.CheckPassword(userEnteredPassword + BL.Properties.Resources.DefaultSalt, hashedPwdFromDatabase);
        }
    }
    protected DataSet BLUserDetailGet(string userId, string password, string key, string connectionString)
    {
        //DL.Algorithm objAlgo = new Algorithm();
        //DL.UserManagement objdlUserManagement = new DL.UserManagement();

        string strEncodedPassword = string.Empty;
        bool PasswordMatchStatus = false;
        DataSet ds = new DataSet();
        ds.Locale = CultureInfo.InvariantCulture;
        //Decrypting the Encrypted  password and check the condition.
        ds = DLUserDetailGet(userId, strEncodedPassword, connectionString);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 &&
                !ds.Tables[0].TableName.Trim().ToUpper().Equals("LOGINFAIL"))
        {
            PasswordMatchStatus = DoesPasswordMatch(ds.Tables[0].Rows[0]["Password"].ToString(), userId + password, true, key);
            if (PasswordMatchStatus == false)
            {
                ds.Tables[0].Rows.Clear();
            }
            //After Login update the login attempt status in DB
            DLUserLoginDetailsUpdate(userId, PasswordMatchStatus, connectionString);
            var ds1 = new DataSet();
            ds1 = DLCheckPasswordUnsuccessfulAttempt(userId, connectionString);
            if (ds1.Tables[0].Rows[0]["UnSuccessful_Attempt"].ToString() == "3")
            {
                ds1.Tables[0].Rows.Clear();
                ds1.Tables[0].Clear();
                ds1.Tables.Remove("Table");
                var errorTable = new DataTable { Locale = CultureInfo.InvariantCulture, TableName = "LoginFail" };
                errorTable.Columns.Add(new DataColumn(BL.Properties.Resources.fldMessageId, typeof(int)));
                errorTable.Columns.Add(new DataColumn(BL.Properties.Resources.fldMessageString, typeof(string)));
                DataRow myDataRow = errorTable.NewRow();
                myDataRow[BL.Properties.Resources.fldMessageId] = 2;
                myDataRow[BL.Properties.Resources.fldMessageString] = BL.Properties.Resources.AccountLock;
                errorTable.Rows.Add(myDataRow);
                ds1.Tables.Add(errorTable);
                return ds1;
            }
        }
        return ds;
    }
    protected DataSet DLUserDetailGet(string userId, string password, string connectionString)
    {
        //SqlParameter[] objParam = new SqlParameter[2];
        //objParam[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);
        //objParam[1] = new SqlParameter(DL.Properties.Resources.PassWord, password);
        //DataSet ds = SqlHelper.ExecuteDataset(connectionString, "udp_UserInfo_Get", objParam);

        //Get the User Detail which will include
        //User Information including Password, Password Policy,Unsuccessful Login attempt Details so far,
        //Password Changed Details and also whether user is active incharge
        //This information is seggregated across multiple Tables.
        var ds = new DataSet();
        using (var scn = new SqlConnection(connectionString))
        {
            SqlCommand command;
            command = new SqlCommand("udp_UserInfo_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.PassWord, SqlDbType.NVarChar).Value = password;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        

        if (ds != null && ds.Tables.Count > 0 &&
                ds.Tables[1].Rows.Count > 0 &&
                    ds.Tables[2].Rows.Count > 0)
        {
            ds.Tables[0].Locale = CultureInfo.InvariantCulture;
            ds.Tables[1].Locale = CultureInfo.InvariantCulture;
            ds.Tables[2].Locale = CultureInfo.InvariantCulture;

            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                Guard.ArgumentConvertibleTo<int>(ds.Tables[2].Rows[0][DL.Properties.Resources.fldUnSuccessfulAttempt].ToString(), "myIntArgument");
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                Guard.ArgumentConvertibleTo<int>(ds.Tables[1].Rows[0][DL.Properties.Resources.fldUnSuccessfulAtemptAllowed].ToString(), "myIntArgument");
            }
            int unsuccessfulPasswordAttempt = int.Parse(ds.Tables[2].Rows[0][DL.Properties.Resources.fldUnSuccessfulAttempt].ToString());
            int unsuccessfulPasswordAttemptAllowed = int.Parse(ds.Tables[1].Rows[0][DL.Properties.Resources.fldUnSuccessfulAtemptAllowed].ToString());
            bool disableOnUnsuccessfulAttempt = bool.Parse(ds.Tables[1].Rows[0][DL.Properties.Resources.fldIsDisableAcAfterUnSuccessAttempt].ToString());
            //In case user has crossed the maximum number of attempts allowed for unsuccessful logins.
            if (unsuccessfulPasswordAttempt >= unsuccessfulPasswordAttemptAllowed)
            {
                ds.Dispose();
                var ds1 = new DataSet { Locale = CultureInfo.InvariantCulture };
                var errorTable = new DataTable { Locale = CultureInfo.InvariantCulture, TableName = "LoginFail" };
                errorTable.Columns.Add(new DataColumn(DL.Properties.Resources.fldMessageId, typeof(int)));
                errorTable.Columns.Add(new DataColumn(DL.Properties.Resources.fldMessageString, typeof(string)));

                DataRow myDataRow = errorTable.NewRow();
                myDataRow[DL.Properties.Resources.fldMessageId] = 2;

                Guard.ArgumentConvertibleTo<bool>(ds.Tables[1].Rows[0][DL.Properties.Resources.fldIsDisableAcAfterUnSuccessAttempt].ToString(), "myBoolArgument");
                if (disableOnUnsuccessfulAttempt)
                {
                    //SqlParameter[] objParam1 = new SqlParameter[1];
                    //objParam1[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);
                    //SqlHelper.ExecuteDataset("udpUser_Inactive", objParam1);
                    var dsInactive = new DataSet();
                    using (var scn = new SqlConnection(connectionString))
                    {
                        SqlCommand command;
                        command = new SqlCommand("udpUser_Inactive", scn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

                        scn.Open();
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dsInactive);
                    }
                    myDataRow[DL.Properties.Resources.fldMessageString] = "YourAccountHasBeenDisabledPleaseContactAdmin";
                }
                else
                {
                    myDataRow[DL.Properties.Resources.fldMessageId] = 3;
                    myDataRow[DL.Properties.Resources.fldMessageString] = "YouHaveCrossedMaximumAttemptPleaseContactAdmin";
                }

                errorTable.Rows.Add(myDataRow);
                ds1.Tables.Add(errorTable);
                return ds1;
            }
        }
        return ds;
    }
    protected void DLUserLoginDetailsUpdate(string userId, bool isSuccessful, string connectionString)
    {
        int Flag = 1;
        if (isSuccessful)
        {
            Flag = 2;
        }
        else
        {
            Flag = 1;
        }

        var ds = new DataSet();
        using (var scn = new SqlConnection(connectionString))
        {
            SqlCommand command;
            command = new SqlCommand("udpUser_NoofAttempts_Update", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.Flag, SqlDbType.Int).Value = Flag;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
    }
    protected DataSet DLCheckPasswordUnsuccessfulAttempt(string userId, string connectionString)
    {
        var ds = new DataSet();
        using (var scn = new SqlConnection(connectionString))
        {
            SqlCommand command;
            command = new SqlCommand("udpUser_Getunsuccessfullattempts", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    #endregion Login

    #region User Rights
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceUserBranchRightsGet(string IMEI, string connectionKey, string userId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpDeviceUserBranchRightsGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
            var objConvertDatatableToJson = new ConvertDatatableToJson();
            string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(jsonString);
    }
    #endregion User Rights

    #region Actuals
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceAttendanceInsert(string IMEI, string connectionKey, string siteCardNo, string employeeCardNo, string InOutStatus, string DutyDateTime, string postValue)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpDeviceAttendanceInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.SiteCardNo, SqlDbType.NVarChar).Value = siteCardNo;
            command.Parameters.Add(DL.Properties.Resources.EmployeeCardNo, SqlDbType.NVarChar).Value = employeeCardNo;
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = InOutStatus;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Post, SqlDbType.NVarChar).Value = postValue;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
            var objConvertDatatableToJson = new ConvertDatatableToJson();
            string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
            //return jsonString;
            //Context.Response.Write(jsonString);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(jsonString);
            //Context.Response.Write("[{'Success':'true'}]");
    }
    #endregion Employees

    #region DutyGet
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAttendance(string connectionKey, string locationAutoId, string clientCode, string asmtId, string dutyDate)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udpDeviceAttendanceGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = locationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = clientCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = asmtId;
            command.Parameters.Add(DL.Properties.Resources.FromDate, SqlDbType.DateTime).Value = DL.Common.DateFormat(dutyDate);
            command.Parameters.Add(DL.Properties.Resources.ToDate, SqlDbType.DateTime).Value = DL.Common.DateFormat(dutyDate);

            scn.Open();
            var adapter = new SqlDataAdapter(command);

            adapter.Fill(ds);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        //return jsonString;
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    #endregion Employees
    public string errmsg(Exception ex)
    {
        return "[['ERROR','" + ex.Message + "']]";
    }


    #region Attendance by Photo

    #region Help DeviceEmpLogin
    const string strHelpStyle = @"<style>table {border-collapse: collapse;} table, th, td {border: 1px solid silver;} div{border: 1px solid silver;}</style>";
    const string strHelpJson = @"<div>Return Type: Json</div>";
    const string strHelpDs = @"<div>Return Type: Data Set</div>";
    const string strHelpLogin = strHelpStyle + @"<div><b> DeviceEmpLogin:</b> Return the User Details (UserID, UserName, EmployeeNumber, FirstName, LastName, EmailID, MobileNo)<br/>
OR MessageString in case of error<br/>
NOTE: UserName is from Login Details and First Name and Last Name is From HR Informations. <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>UserID</td>
</tr><tr>
<td>Password:</td><td>Password</td>
</tr>
</table></div>";
    #endregion Help DeviceEmpLogin
    [WebMethod(Description = strHelpJson + strHelpLogin)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceEmpLogin(string connectionKey, string userId, string password)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        string strPwdkey = GetDecryptkey(connectionKey);
        ds = BLUserDetailGet(userId, password, strPwdkey, connect);

        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            var dsUser = GetDeviceEmpUserDetails(connectionKey, userId);
            var objConvertDatatableToJson = new ConvertDatatableToJson();
            //string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
            string jsonString = objConvertDatatableToJson.DataTableToJson(dsUser.Tables[0]);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(jsonString);
        }
        else
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write("[{'MessageString':'Invalid User Id or Password'}]");
        }

        //DataSet ds = objblUserManagement.UserDetailGet(userId, password, strPwdkey);
        //Context.Response.Clear();
        //Context.Response.ContentType = "application/json";
        //Context.Response.Write("[{'Success':'true'}]");
    }

    protected DataSet GetDeviceEmpUserDetails(string connectionKey, string userId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceUserDetails", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }

    #region Help GetPostDetails
    const string strHelpGetPostDetails = strHelpStyle + @"<div><b> GetPostDetails:</b> Return the Post Details (LocationAutoID, PostAutoId, ClientCode, ClientName, AsmtId, AsmtName, PostCode, PostDesc, SoRank, PostText, PostValue, ShiftCode, WeekNo, MonNoOfPersons, TueNoOfPersons, WedNoOfPersons, ThuNoOfPersons, FriNoOfPersons, SatNoOfPersons, SunNoOfPersons, MonTimeFrom, MonTimeTo, TueTimeFrom, TueTimeTo, WedTimeFrom, WedTimeTo, ThuTimeFrom, ThuTimeTo, FriTimeFrom, FriTimeTo, SatTimeFrom, SatTimeTo, SunTimeFrom, SunTimeTo)<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>UserID</td>
</tr><tr>
<td>postAutoId:</td><td>Fetch postAutoId from PostQRCode</td>
</tr>
</table></div>";
    #endregion Help GetPostDetails
    [WebMethod(Description = strHelpJson + strHelpGetPostDetails)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPostDetails(string connectionKey, string userId, string postAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDevicePostDetailsGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.PostAutoId, SqlDbType.NVarChar).Value = postAutoId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                var objConvertDatatableToJson = new ConvertDatatableToJson();
                string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonString);
            }
            else
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write("[{'Message':'Invalid Post'}]");
            }
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceEmpAttendanceInsertBase64(string connectionKey, string IMEI, string userId, string postValue, string employeeNumber,
        string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        DeviceEmpAttendanceInsert(connectionKey, IMEI, userId, postValue, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage);

    }

    #region Help DeviceEmpAttendanceInsert
    const string strHelpDeviceEmpAttendanceInsert = strHelpStyle + @"<div><b> DeviceEmpAttendanceInsert:</b> Return the MessageString and MessageId, in case of sucess MessageId value will be 1<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>IMEI:</td><td>Mobile IMEI No. (Non Mandatory)</td>
</tr><tr>
<td>userId:</td><td>loged in userId</td>
</tr><tr>
<td>PostValue:</td><td>postValue</td>
</tr><tr>
<td>EmployeeNumber:</td><td>loged Employee Number</td>
</tr><tr>
<td>InOutStatus:</td><td>(IN or OUT) string based on Checkin or checkout Attendance selected</td>
</tr><tr>
<td>DutyDateTime</td><td>Attendance Date with Time</td>
</tr><tr>
<td>Latitude:</td><td>GPS Latitude (Non Mandatory)</td>
</tr><tr>
<td>Longitude:</td><td>GPS Longitude (Non Mandatory)</td>
</tr><tr>
<td>Altitude:</td><td>GPS Altitude (Non Mandatory)</td>
</tr><tr>
<td>EmployeeImage:</td><td>employeeImage (Non Mandatory)</td>
</tr>
</table></div>";
    #endregion Help DeviceEmpAttendanceInsert
    [WebMethod(Description = strHelpJson + strHelpDeviceEmpAttendanceInsert)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceEmpAttendanceInsert(string connectionKey, string IMEI, string userId, string postValue, string employeeNumber,
        string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.Post, SqlDbType.NVarChar).Value = postValue;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = InOutStatus;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            if (employeeImage != null && employeeImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.EmployeeImage, SqlDbType.Image).Value = (object)employeeImage;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.EmployeeImage, SqlDbType.Image).Value = DBNull.Value;
            }
            
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceEmpIncidentInsertBase64(string connectionKey, string IMEI, string userId, string postAutoId, string employeeNumber, string latitude, string longitude, string altitude, string incidentDate,
        string incidentNotes, string incidentImageBase64)
    {
        byte[] incidentImage = System.Convert.FromBase64String(incidentImageBase64);
        DeviceEmpIncidentInsert(connectionKey, IMEI, userId, postAutoId, employeeNumber,
        latitude, longitude, altitude, incidentDate, incidentNotes, incidentImage);
    }

    #region Help DeviceEmpIncidentInsert
    const string strHelpDeviceEmpIncidentInsert = strHelpStyle + @"<div><b> DeviceEmpIncidentInsert:</b> Return the MessageString and MessageId, in case of sucess MessageId value will be 1<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>IMEI:</td><td>Mobile IMEI No. (Non Mandatory)</td>
</tr><tr>
<td>userId:</td><td>loged in userId</td>
</tr><tr>
<td>PostAutoId:</td><td>PostAutoId From Scaned Post QRCode</td>
</tr><tr>
<td>EmployeeNumber:</td><td>loged Employee Number</td>
</tr><tr>
<td>Latitude:</td><td>GPS Latitude (Non Mandatory)</td>
</tr><tr>
<td>Longitude:</td><td>GPS Longitude (Non Mandatory)</td>
</tr><tr>
<td>Altitude:</td><td>GPS Altitude (Non Mandatory)</td>
</tr><tr>
<td>IncidentDate</td><td>Incident Date with Time</td>
</tr><tr>
<td>IncidentNotes:</td><td>Details about the Incident (Non Mandatory send either Notes or Image)</td>
</tr><tr>
<td>IncidentImage:</td><td>IncidentImage (Non Mandatory send either Notes or Image)</td>
</tr>
</table></div>";
    #endregion Help DeviceEmpIncidentInsert
    [WebMethod(Description = strHelpJson + strHelpDeviceEmpIncidentInsert)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceEmpIncidentInsert(string connectionKey, string IMEI, string userId, string postAutoId, string employeeNumber, string latitude, string longitude, string altitude, string incidentDate, string incidentNotes, byte[] incidentImage)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceIncidentInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.PostAutoId, SqlDbType.NVarChar).Value = postAutoId;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.IncidentDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(incidentDate);
            command.Parameters.Add(DL.Properties.Resources.IncidentNotes, SqlDbType.NVarChar).Value = incidentNotes;
            //command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)incidentImage;
            if (incidentImage != null && incidentImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)incidentImage;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = DBNull.Value;
            }

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }


    #endregion

    #region Employee Biometric

    #region Help GetEmployeeDetails
    const string GetEmployeeDetailsDesc = strHelpStyle + @"<div><b> GetEmployeeDetails:</b> Return the list of Employee on the basis of Employee Number and Employee Name.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>employeeNo:</td><td>Employee Number</td>
</tr>
<tr>
<td>employeeName:</td><td>Employee Name</td>
</tr>
</table></div>";
    #endregion Help GetEmployeeDetails
    [WebMethod(Description = strHelpStyle + GetEmployeeDetailsDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetEmployeeDetails(string connectionKey, string employeeNo, string employeeName)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetEmployeeDetailsBasisOfNamenNo", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNo;
            command.Parameters.Add(DL.Properties.Resources.FirstName, SqlDbType.NVarChar).Value = employeeName;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                var objConvertDatatableToJson = new ConvertDatatableToJson();
                string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonString);
            }
            else
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write("[{'Message':'Invalid Post'}]");
            }
        }
    }

    public void InsertFingerPrint(string connectionKey, string employeeNo,string Branch, string fingerPrintId, byte[] Image)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_InsertEmployeeFingerPrint", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNo;
            command.Parameters.Add(DL.Properties.Resources.IDNumber, SqlDbType.NVarChar).Value = fingerPrintId;
            command.Parameters.Add(DL.Properties.Resources.Branch, SqlDbType.NVarChar).Value = Branch;
            if (Image != null && Image.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)Image;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = DBNull.Value;
            }

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                var objConvertDatatableToJson = new ConvertDatatableToJson();
                string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonString);
            }
            else
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write("[{'Message':'Invalid Post'}]");
            }
        }
    }

    #region Help InsertFingerPrintBase64
    const string InsertFingerPrintBase64Desc = strHelpStyle + @"<div><b> InsertFingerPrintBase64:</b> Insert Employee fingerPrint.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>employeeNo:</td><td>Employee Number</td>
</tr>
<tr>
<tr>
<td>Branch:</td><td>Employee Branch</td>
</tr>
<tr>
<td>fingerPrintId:</td><td>FingerPrint Id</td>
</tr>
<tr>
<td>fingerPrintImageBase64:</td><td>Finger Print image in base 64 Format.</td>
</tr>
</table></div>";
    #endregion Help InsertFingerPrintBase64
    [WebMethod(Description = strHelpStyle + InsertFingerPrintBase64Desc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertFingerPrintBase64(string connectionKey, string employeeNo,string Branch, string fingerPrintId, string fingerPrintImageBase64)
    {
        byte[] Image = System.Convert.FromBase64String(fingerPrintImageBase64);
        InsertFingerPrint(connectionKey, employeeNo,Branch, fingerPrintId, Image);

    }

    #endregion
}
