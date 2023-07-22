using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Services;
using DL;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class PlumbingEngineerApp : WebService
{
    const string strStyle = @"<style>table {border-collapse: collapse;} table, th, td {border: 1px solid silver;} div{border: 1px solid silver;}</style>";
    const string strJson = @"<div><b>Return Type: Json</b></div>";
    protected DataSet EmployeeLoginDs(string connectionKey, string EmployeeId, string Password)
    {
        bool PasswordMatchStatus = false;
        string strkey = GetDecryptkey(connectionKey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetEmployeePassword", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = EmployeeId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }

        if (!String.IsNullOrEmpty(Password))
        {
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
            {

                BL.UserManagement objblUserManagement = new BL.UserManagement();
                PasswordMatchStatus = objblUserManagement.DoesPasswordMatch(ds.Tables[0].Rows[0]["password"].ToString(), EmployeeId + Password, true, strkey);
                var ds1 = new DataSet();
                var objCon1 = new ConnectionString();
                var connect1 = objCon1.ConnectionStringGet(connectionKey);

                using (var scn = new SqlConnection(connect1))
                {
                    SqlCommand command = new SqlCommand("udp_EmployeeLogin", scn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = EmployeeId;
                    command.Parameters.Add("@PasswordMatchStatus", SqlDbType.NVarChar).Value = PasswordMatchStatus;

                    scn.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds1);
                }
                return ds1;

            }
            else
            {
                return ds;
            }
        }
        else
        {
            return ds;
        }
    }
    #region EmployeeLogin Parameter Info
    const string EmployeeLoginDesc = strStyle + @"<div><b> EmployeeLogin:</b>  For Validating the Employee valid User Id and Password.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>Password:</td>
<td>Employee Password</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + EmployeeLoginDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void EmployeeLogin(string connectionKey, string EmployeeId, string Password)
    {
        var ds = new DataSet();
        ds = EmployeeLoginDs(connectionKey, EmployeeId, Password);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }
    #region InsertOTPforForgotPasswordEmployee Parameter Info
    const string InsertOTPforForgotPasswordEmployeeDesc = strStyle + @"<div><b> InsertOTPforForgotPasswordEmployee:</b>  For Generating,saving and sending OTP on Mobile when Employee click Forgot Password.<br/>
<b>Parameter Information :</b><br/> 1
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + InsertOTPforForgotPasswordEmployeeDesc)]
       [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertOTPforForgotPasswordEmployee(string connectionKey, string EmployeeId)
    {
        var OTP = GenerateOTP();
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_EmployeeOTPInsertForgotPassword", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@OTP", SqlDbType.NVarChar).Value = OTP;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        var ds1 = new DataSet();
        ds1 = GetEmployeeNumberDs(connectionKey,EmployeeId);
        if (ds1.Tables[0].Rows[0]["MessageId"].ToString() == "1")
        {
            if (ds1.Tables[0].Rows[0]["MobileNo"].ToString() != "")
            {
                SendOTPDs(connectionKey, ds1.Tables[0].Rows[0]["MobileNo"].ToString(), OTP, "SmsTemplateForgotPwd", string.Empty, string.Empty);
            }
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    public string GenerateOTP()
    {
        string characters = "1234567890";
        string otp = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        return otp;
    }
    #region VerifyOTPnResetEmployeePassword Parameter Info
    const string VerifyOTPnResetEmployeePasswordDesc = strStyle + @"<div><b> VerifyOTPnResetEmployeePassword:</b>  Verify Employee OTP for Forgot Password and if it is Correct then Reset the Password.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>OTP:</td>
<td>OTP Received by the Employee.</td>
</tr>
<tr>
<td>Password:</td>
<td>Employee New Password need to be reset.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + VerifyOTPnResetEmployeePasswordDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void VerifyOTPnResetEmployeePassword(string connectionKey, string EmployeeId, string OTP, string Password)
    {
        string strkey = GetDecryptkey(connectionKey);
        string strEncodedPassword;
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        strEncodedPassword = objblUserManagement.EncryptPassword(EmployeeId+Password, true, strkey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_VerifynResetPassword", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@OTP", SqlDbType.NVarChar).Value = OTP;
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = strEncodedPassword;
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
    #region GetEmployeeJobs Parameter Info
    const string GetEmployeeJobsDesc = strStyle + @"<div><b> GetEmployeeJobs:</b>  Return  WorkOrder Details assisgned to Particular Employee for a Particular Date.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>Date:</td>
<td>Date whose WorkOrder Details is to be return.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + GetEmployeeJobsDesc)]
   
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetEmployeeJobs(string connectionKey, string EmployeeId,string Date)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetEmployeeJobs", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@Date", SqlDbType.NVarChar).Value = DL.Common.DateFormat(Date);
           
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
    #region UpdateStatusONTHEWAY Parameter Info
    const string UpdateStatusONTHEWAYDesc = strStyle + @"<div><b> UpdateStatusONTHEWAY:</b> Update WorkOrder Status To ONTHEWAY.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo whose status is to be changed.</td>
</tr>
<tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates from where status is Updated. (optional)</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates from where status is Updated. (optional)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateStatusONTHEWAYDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateStatusONTHEWAY(string connectionKey, string EmployeeId, string WorkOrderNo, string Lat, string Long)
    {
     Lat=   SetLatLongValue(Lat);
     Long = SetLatLongValue(Long);
      
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateStatusOntheway", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal( Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        if(ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
        { 
        SendOTP(connectionKey, "SmsTemplateONTHEWAY", WorkOrderNo);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);

    }
    public string SetLatLongValue(string Value)
    {
        if (!String.IsNullOrEmpty(Value))
        {
            Value = Value.ToString();
        }
        else
        {
            Value = "0";
        }
        return Value;
    }
    #region UpdateStatusBREAKDOWN Parameter Info
    const string UpdateStatusBREAKDOWNDesc = strStyle + @"<div><b> UpdateStatusBREAKDOWN:</b> Update WorkOrder Status To BREAKDOWN.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo whose status is to be changed.</td>
</tr>
<tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates from where status is Updated. (optional)</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates from where status is Updated. (optional)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateStatusBREAKDOWNDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateStatusBREAKDOWN(string connectionKey, string EmployeeId, string WorkOrderNo, string Lat, string Long)
    {
        Lat = SetLatLongValue(Lat);
        Long = SetLatLongValue(Long);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateStatusBREAKDOWN", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal(Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);

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
    #region UpdateStatusREJECT Parameter Info
    const string UpdateStatusREJECTDesc = strStyle + @"<div><b> UpdateStatusREJECT:</b> Update WorkOrder Status To REJECT.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo whose status is to be changed.</td>
</tr>
<tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates from where status is Updated. (optional)</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates from where status is Updated. (optional)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateStatusREJECTDesc)]
    
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateStatusREJECT(string connectionKey, string EmployeeId, string WorkOrderNo, string Lat, string Long)
    {
        Lat = SetLatLongValue(Lat);
        Long = SetLatLongValue(Long);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateStatusREJECT", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal(Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
        {
            SendOTP(connectionKey, "SmsTemplateREJECT", WorkOrderNo);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    #region UpdateStatusINPROGRESS Parameter Info
    const string UpdateStatusINPROGRESSDesc = strStyle + @"<div><b> UpdateStatusINPROGRESS:</b> Update WorkOrder Status To INPROGRESS.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo whose status is to be changed.</td>
</tr>
<tr>
<td>CheckInTime:</td>
<td>Check In Time given by the Employee when he starts the service and Update the status to INPROGRESS.</td>
</tr>
<tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates from where status is Updated. (optional)</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates from where status is Updated. (optional)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateStatusINPROGRESSDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateStatusINPROGRESS(string connectionKey, string EmployeeId, string WorkOrderNo,string CheckInTime, string Lat, string Long)
    {
        Lat = SetLatLongValue(Lat);
        Long = SetLatLongValue(Long);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateStatusINPROGRESS", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal(Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);
            command.Parameters.Add("@CheckInTime", SqlDbType.NVarChar).Value = CheckInTime;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
        {
            SendOTP(connectionKey, "SmsTemplateINPROGRESS", WorkOrderNo);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    #region UpdateStatusONHOLD Parameter Info
    const string UpdateStatusONHOLDDesc = strStyle + @"<div><b> UpdateStatusONHOLD:</b> Update WorkOrder Status To ONHOLD.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo whose status is to be changed.</td>
</tr>
<tr>
<td>ReasonToHold:</td>
<td>Reason given by the Employee for putting the Service ONHOLD.</td>
</tr>
<tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates from where status is Updated. (optional)</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates from where status is Updated. (optional)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateStatusONHOLDDesc)]
    
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateStatusONHOLD(string connectionKey, string EmployeeId, string WorkOrderNo, string ReasonToHold, string Lat, string Long)
    {
        Lat = SetLatLongValue(Lat);
        Long = SetLatLongValue(Long);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateStatusONHOLD", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal(Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);
            command.Parameters.Add("@ReasonToHold", SqlDbType.NVarChar).Value = ReasonToHold;

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
    #region UpdateStatusDONE Parameter Info
    const string UpdateStatusDONEDesc = strStyle + @"<div><b> UpdateStatusDONE:</b> Update WorkOrder Status To DONE.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo whose status is to be changed.</td>
</tr>
<td>Amount:</td>
<td>Service total Amount to be paid by the customer.</td>
</tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates from where status is Updated. (optional)</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates from where status is Updated. (optional)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateStatusDONEDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateStatusDONE(string connectionKey, string EmployeeId, string WorkOrderNo, string Amount, string Lat, string Long)
    {
        Lat = SetLatLongValue(Lat);
        Long = SetLatLongValue(Long);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateStatusDONE", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal(Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);
            command.Parameters.Add("@Amount", SqlDbType.NVarChar).Value = Amount;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
        {
            SendOTP(connectionKey, "SmsTemplateDONE", WorkOrderNo);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    #region UpdateStatusCLOSE Parameter Info
    const string UpdateStatusCLOSEDesc = strStyle + @"<div><b> UpdateStatusCLOSE:</b> Update WorkOrder Status To CLOSE.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo whose status is to be changed.</td>
</tr>
<tr>
<td>PaymentMethod:</td>
<td>Payment Method (ONLINE / CASH)</td>
</tr>
<td>TransactionId:</td>
<td>Online Payment Transaction Id.(optional when PaymentMethod is CASH)</td>
</tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates from where status is Updated. (optional)</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates from where status is Updated. (optional)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateStatusCLOSEDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateStatusCLOSE(string connectionKey, string EmployeeId, string WorkOrderNo,string PaymentMethod,string TransactionId,string Lat, string Long)
    {
        Lat = SetLatLongValue(Lat);
        Long = SetLatLongValue(Long);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateStatusCLOSE", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal(Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);
            command.Parameters.Add("@TransactionID", SqlDbType.NVarChar).Value = TransactionId;
            command.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = PaymentMethod;
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

    #region InsertCustomerSignature Parameter Info
    const string InsertCustomerSignatureDesc = strStyle + @"<div><b> InsertCustomerSignature:</b> Insert customer signature after Order Status is CLOSE.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo.</td>
</tr>
<td>Signature:</td>
<td>Customer Signature Image in Base 64 Format String Format.</td>
</tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates from where Signature is captured. (optional)</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates from where Signature is captured. (optional)</td>
</tr>
</table></div>";
    #endregion
   
    public void InsertCustomerSignatureByte(string connectionKey, string EmployeeId, string WorkOrderNo, byte[] Signature, string Lat, string Long)
    {
        Lat = SetLatLongValue(Lat);
        Long = SetLatLongValue(Long);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_InsertCustomerSignature", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal(Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);
            command.Parameters.Add("@Signature", SqlDbType.Image).Value = (object)Signature;
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
    [WebMethod(Description = strJson + InsertCustomerSignatureDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
      public void InsertCustomerSignature(string connectionKey, string EmployeeId, string WorkOrderNo, string Signature, string Lat, string Long)
    {
        byte[] signature = System.Convert.FromBase64String(Signature);
        InsertCustomerSignatureByte(connectionKey, EmployeeId, WorkOrderNo, signature, Lat, Long);
    }
    #region InsertEmployeeLatLong Parameter Info
    const string InsertEmployeeLatLongDesc = strStyle + @"<div><b> InsertEmployeeLatLong:</b> Inserts employee lat n long co-ordinates time to time for tracking the employee.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>EmployeeId:</td>
<td>Employee Id</td>
</tr>
<tr>
<td>Lat:</td>
<td>Employee Latitude co-ordinates.</td>
</tr>
<tr>
<td>Long:</td>
<td>Employee Longitude co-ordinates.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + InsertEmployeeLatLongDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertEmployeeLatLong(string connectionKey, string EmployeeId,  string Lat, string Long)
    {
        Lat = SetLatLongValue(Lat);
        Long = SetLatLongValue(Long);

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_InsertEmployeeLatLong", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = EmployeeId;
            command.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = Convert.ToDecimal(Lat);
            command.Parameters.Add("@Long", SqlDbType.NVarChar).Value = Convert.ToDecimal(Long);
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

    public List<string> SearchPlumbingWorkOrder(string connectionKey, string prefixText)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpSearchWorkOrderNoListGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = prefixText;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            var dt = new DataTable();
            dt = ds.Tables[0];
            List<string> WorkOrderNoList = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WorkOrderNoList.Add(dt.Rows[i]["WorkOrderNo"].ToString());
            }
            return WorkOrderNoList;
        }
    }

    public List<string> SearchClientUserId(string connectionKey, string prefixText)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpSearchConsumerUserIdListGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = prefixText;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            var dt = new DataTable();
            dt = ds.Tables[0];
            List<string> ClientUserIdList = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ClientUserIdList.Add(dt.Rows[i]["UserId"].ToString());
            }
            return ClientUserIdList;
        }
    }

    public List<string> SearchEmployeeNumber(string connectionKey, string prefixText)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpSearchEmployeeNumberListGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeNumber", SqlDbType.NVarChar).Value = prefixText;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            var dt = new DataTable();
            dt = ds.Tables[0];
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dt.Rows[i]["EmployeeNumber"].ToString(), dt.Rows[i]["EmployeeName"].ToString());
                list.Add(item);
            }
            return list;
        }
    }

    public List<string> SearchEmployeeName(string connectionKey, string prefixText)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpSearchEmployeeNameListGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = prefixText;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            var dt = new DataTable();
            dt = ds.Tables[0];
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dt.Rows[i]["EmployeeName"].ToString(), dt.Rows[i]["EmployeeNumber"].ToString());
                list.Add(item);
            }
            return list;
        }
    }
  

  protected string SendOTPDs(string connectionKey, string mobileNumber, string strOTP, string TemplateType,string UserName,string WorkOrderNo)
    {
         string ActiveSMS = ConfigurationManager.AppSettings["ActivateSms"];
         if(ActiveSMS.ToString() == "1")
         { 
            var objCon = new ConnectionString();
            var connect = objCon.ConnectionStringGet(connectionKey);
            var ds = new DataSet();
            using (var scn = new SqlConnection(connect))
            {
                string MsgBody = string.Empty;
               
                if (TemplateType == "SmsTemplateForgotPwd")
                {
                    MsgBody = Resources.Resource.SmsTemplateForgotPwd1 + strOTP + Resources.Resource.SmsTemplateForgotPwd2;
                }
                string strUrl = Resources.Resource.SmsConfigURLAuthKey + MsgBody + Resources.Resource.SmsConfigURLSenderId + Resources.Resource.SmsConfigURLRouteID + Resources.Resource.SmsConfigURLMobileNo + mobileNumber + Resources.Resource.SmsConfigURLContentType;
                try
                {
                    WebRequest request = HttpWebRequest.Create(strUrl);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();
                }
                catch (Exception ex)
                { }

                return "Success";
              
                }

            }
         else
         {
             return "SMS not send";
         }
    }
  protected DataSet GetEmployeeNumberDs(string connectionKey, string EmployeeId)
  {
      var objCon = new ConnectionString();
      var connect = objCon.ConnectionStringGet(connectionKey);
      var ds = new DataSet();
      using (var scn = new SqlConnection(connect))
      {
          SqlCommand command = new SqlCommand("udp_GetEmployeeMobile", scn);
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = EmployeeId;
          scn.Open();
          var adapter = new SqlDataAdapter(command);
          adapter.Fill(ds);

      }
      return ds;    
  }
  #region GetPossibleStatus Parameter Info
  const string GetPossibleStatusDesc = strStyle + @"<div><b> GetPossibleStatus:</b>  Return possible status to be changed on the basis of current status.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>status:</td>
<td>Order current status.</td>
</tr>

</table></div>";
  #endregion
  [WebMethod(Description = strJson + GetPossibleStatusDesc)]

  [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
  public void GetPossibleStatus(string connectionKey, string status)
  {
      var objCon = new ConnectionString();
      var connect = objCon.ConnectionStringGet(connectionKey);
      var ds = new DataSet();
      using (var scn = new SqlConnection(connect))
      {
          SqlCommand command = new SqlCommand("udp_GetPossibleStatus", scn);
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
       

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
  #region GetOrderDetail Parameter Info
  const string GetOrderDetailDesc = strStyle + @"<div><b> GetOrderDetail:</b>  Return complete detail for an specific WorkOrderNo.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNo..</td>
</tr>

</table></div>";
  #endregion
  [WebMethod(Description = strJson + GetOrderDetailDesc)]

  [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
  public void GetOrderDetail(string connectionKey, string WorkOrderNo)
  {
      var objCon = new ConnectionString();
      var connect = objCon.ConnectionStringGet(connectionKey);
      var ds = new DataSet();
      using (var scn = new SqlConnection(connect))
      {
          SqlCommand command = new SqlCommand("Udp_getorderdetail", scn);
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;


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

  protected void SendOTP(string connectionKey, string TemplateType, string WorkOrderNo)
  {
      string ActiveSMS = ConfigurationManager.AppSettings["ActivateSms"];
      if (ActiveSMS.ToString() == "1")
      {
          var objCon = new ConnectionString();
          var connect = objCon.ConnectionStringGet(connectionKey);
          var ds = new DataSet();
          using (var scn = new SqlConnection(connect))
          {
              SqlCommand command = new SqlCommand("udp_GetOrderDetail", scn);
              command.CommandType = CommandType.StoredProcedure;
              command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
              scn.Open();
              var adapter = new SqlDataAdapter(command);
              adapter.Fill(ds);
          }
          var serviceName = ds.Tables[0].Rows[0]["servicecategoryname"].ToString();
          var date = ds.Tables[0].Rows[0]["preferredfromdate"].ToString();
          var time = ds.Tables[0].Rows[0]["preferredfromtime"].ToString();
          var engineerName = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
          var engineerMobile = ds.Tables[0].Rows[0]["EmployeeMobileNo"].ToString();
          var userMobile = ds.Tables[0].Rows[0]["mobileno"].ToString();
          var Price = ds.Tables[0].Rows[0]["price"].ToString();
     
              string MsgBody = string.Empty;
              if (TemplateType == "SmsTemplateONTHEWAY")
              {
                  MsgBody = Resources.Resource.SmsTemplateONTHEWAY1 + serviceName + Resources.Resource.SmsTemplateONTHEWAY2 + DateTime.Parse(date).ToString("dddd, MMM dd") + Resources.Resource.SmsTemplateONTHEWAY3 +time + Resources.Resource.SmsTemplateONTHEWAY4 + engineerName + Resources.Resource.SmsTemplateONTHEWAY5 + engineerMobile + Resources.Resource.SmsTemplateONTHEWAY6;
              }
              if (TemplateType == "SmsTemplateINPROGRESS")
              {
                  MsgBody = Resources.Resource.SmsTemplateINPROGRESS1 + serviceName + Resources.Resource.SmsTemplateINPROGRESS2;
              }
              if (TemplateType == "SmsTemplateREJECT")
              {
                  MsgBody = Resources.Resource.SmsTemplateREJECT ;
              }
              if (TemplateType == "SmsTemplateDONE")
              {
                  MsgBody = Resources.Resource.SmsTemplateCLOSE1 + Price + Resources.Resource.SmsTemplateCLOSE2 + Price + Resources.Resource.SmsTemplateCLOSE3;
              }


              string strUrl = Resources.Resource.SmsConfigURLAuthKey + MsgBody + Resources.Resource.SmsConfigURLSenderId + Resources.Resource.SmsConfigURLRouteID + Resources.Resource.SmsConfigURLMobileNo + userMobile + Resources.Resource.SmsConfigURLContentType;
              try
              {
                  WebRequest request = HttpWebRequest.Create(strUrl);

                  HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                  Stream s = (Stream)response.GetResponseStream();
                  StreamReader readStream = new StreamReader(s);
                  string dataString = readStream.ReadToEnd();
                  response.Close();
                  s.Close();
                  readStream.Close();
              }
              catch (Exception ex)
              { }
      }
      else
      {
          
      }
  }

}
