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
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Script.Serialization;


/// <summary>
/// Summary description for Plumbing
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Plumbing : WebService
{
    const string strStyle = @"<style>table {border-collapse: collapse;} table, th, td {border: 1px solid silver;} div{border: 1px solid silver;}</style>";
    const string strJson = @"<div><b>Return Type: Json</b></div>";
    const string strDs = @"<div>Return Type: Data Set</div>";
    /// <summary>
    /// Devices the work order insert.
    /// </summary>
    /// <param name="connectionKey">The connection key.</param>
    /// <param name="userId">The user identifier.</param>
    /// <param name="location">The location.</param>
    /// <param name="serviceAutoId">The service automatic identifier.</param>
    /// <param name="preferredFromDate">The preferred from date.</param>
    /// <param name="preferredToDate">The preferred to date.</param>
    /// <param name="preferredFromTime">The preferred from time.</param>
    /// <param name="preferredToTime">The preferred to time.</param>
    /// <param name="mobileNo">The mobile no.</param>
    /// <param name="buildingNo">The building no.</param>
    /// <param name="floorNo">The floor no.</param>
    /// <param name="locality">The locality.</param>
    /// <param name="landmark">The landmark.</param>
    /// <param name="city">The city.</param>
    /// <param name="district">The district.</param>
    /// <param name="state">The state.</param>
    /// <param name="pin">The pin.</param>
    /// <param name="modifiedBy">The modified by.</param>
    /// <param name="modifiedDate">The modified date.</param>
    #region DeviceWorkOrderInsert Parameter Info
    const string DeviceWorkOrderInsertDesc = strStyle + @"<div><b> DeviceWorkOrderInsert:</b> For inserting the workorder and sending SMS and Email regarding Order Confirmation  <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>Location:</td>
<td>User Bsse Location (Send 1 as value)</td>
</tr>
<tr>
<td>ServiceAutoId:</td>
<td>User Selected Service Auto Id</td>
</tr>
<tr>
<td>PreferredFromDate:</td>
<td>User Selected Service Date</td>
</tr>
<tr>
<td>PreferredToDate:</td>
<td>User Selected Service Date (Same as PreferredFromDate)</td>
</tr>
<tr>
<td>PreferredFromTime:</td>
<td>User Selected Service Time</td>
</tr>
<tr>
<td>PreferredToTime:</td>
<td>User Selected Service Time (Same as PreferredFromTime)</td>
</tr>
<tr>
<td>MobileNo:</td>
<td>User Mobile No.</td>
</tr>
<tr>
<td>BuildingNo:</td>
<td>User Address Building No. (If you are sending AddressAutoId then left this Field as blank otherwise fill detail and Send AddressAutoId as 0 )</td>
</tr>
<tr>
<td>FloorNo:</td>
<td>Left this field as Blank</td>
</tr>
<tr>
<td>Locality:</td>
<td>User Address Locality (If you are sending AddressAutoId then left this Field as blank otherwise fill detail and Send AddressAutoId as 0 )</td>
</tr>
<tr>
<td>Landmark:</td>
<td>User Address Landmark (If you are sending AddressAutoId then left this Field as blank otherwise fill detail and Send AddressAutoId as 0 )</td>
</tr>
<tr>
<td>City:</td>
<td>User Address CityAutoId (If you are sending AddressAutoId then left this Field as blank otherwise fill detail and Send AddressAutoId as 0 )</td>
</tr>
<tr>
<td>District:</td>
<td>Left this field as Blank</td>
</tr>
<tr>
<td>State:</td>
<td>Left this field as Blank</td>
</tr>
<tr>
<td>PIN:</td>
<td>User Address PinCode (If you are sending AddressAutoId then left this Field as blank otherwise fill detail and Send AddressAutoId as 0 )</td>
</tr>
<tr>
<tr>
<td>ModifiedBy:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>ModifiedDate:</td>
<td>Current Date</td>
</tr>
<tr>
<td>Lat:</td>
<td>Latitude Co-ordinates of User Location from where WorkOrder is booked (if Value exists then send that co-ordinates otherwise send 0.00000000 as co-ordinates)</td>
</tr>
<tr>
<td>Long:</td>
<td>Longitude Co-ordinates of User Location from where WorkOrder is booked (if Value exists then send that co-ordinates otherwise send 0.00000000 as co-ordinates)</td>
</tr>
<tr>
<td>ClientName:</td>
<td>User Name</td>
</tr>
<tr>
<td>ClientEmail:</td>
<td>User Email ID</td>
</tr>
<tr>
<td>status:</td>
<td>WorkOrder Status i.e. NEW</td>
</tr>
<tr>
<td>Unit:</td>
<td>Number of Service Unit/Units Ordered by the User</td>
</tr>
<tr>
<td>Price:</td>
<td>Price of Service Unit/Units Ordered by the User</td>
</tr>
<tr>
<td>AddressAutoId:</td>
<td>User AddressAutoId(If you are sending Values of Building No,Locality,Landmark,City,Pin then send AddressAutoId as 0 otherwise Address AddressAutoId)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + DeviceWorkOrderInsertDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceWorkOrderInsert(string connectionKey, string UserId, string Location, int ServiceAutoId, string PreferredFromDate, string PreferredToDate, string PreferredFromTime, string PreferredToTime, string MobileNo,
            string BuildingNo, string FloorNo, string Locality, string Landmark, string City, string District, string State, string PIN, string ModifiedBy, string ModifiedDate, Decimal Lat, Decimal Long, string ClientName, string ClientEmail, string status, string Unit, string Price, int AddressAutoId)
    {

        var ds = new DataSet();
        ds = DeviceWorkOrderInsertDs(connectionKey, UserId, Location, ServiceAutoId, PreferredFromDate, PreferredToDate, PreferredFromTime, PreferredToTime, MobileNo, BuildingNo, FloorNo, Locality, Landmark, City, District, State, PIN, ModifiedBy, ModifiedDate, Lat, Long, ClientName, ClientEmail, status,  Unit,  Price,  AddressAutoId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as DeviceWorkOrderInsert</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet DeviceWorkOrderInsertDs(string connectionKey, string UserId, string Location, int ServiceAutoId, string PreferredFromDate, string PreferredToDate, string PreferredFromTime, string PreferredToTime, string MobileNo,
            string BuildingNo, string FloorNo, string Locality, string Landmark, string City, string District, string State, string PIN, string ModifiedBy, string ModifiedDate, Decimal Lat, Decimal Long, string ClientName, string ClientEmail, string status,string Unit,string Price,int AddressAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udpWorkOrderInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
            command.Parameters.Add("@ServiceAutoId", SqlDbType.Int).Value = ServiceAutoId;
            command.Parameters.Add("@PreferredFromDate", SqlDbType.NVarChar).Value = DL.Common.DateFormat(PreferredFromDate);
            command.Parameters.Add("@PreferredToDate", SqlDbType.NVarChar).Value = DL.Common.DateFormat(PreferredToDate);
            command.Parameters.Add("@PreferredFromTime", SqlDbType.NVarChar).Value = PreferredFromTime;
            command.Parameters.Add("@PreferredToTime", SqlDbType.NVarChar).Value = PreferredToTime;
            command.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = MobileNo;
            command.Parameters.Add("@BuildingNo", SqlDbType.NVarChar).Value = BuildingNo;
            command.Parameters.Add("@FloorNo", SqlDbType.NVarChar).Value = FloorNo;
            command.Parameters.Add("@Locality", SqlDbType.NVarChar).Value = Locality;
            command.Parameters.Add("@Landmark", SqlDbType.NVarChar).Value = Landmark;
            command.Parameters.Add("@City", SqlDbType.NVarChar).Value = City;
            command.Parameters.Add("@District", SqlDbType.NVarChar).Value = District;
            command.Parameters.Add("@State", SqlDbType.NVarChar).Value = State;
            command.Parameters.Add("@PIN", SqlDbType.NVarChar).Value = PIN;
            command.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = ModifiedBy;
            command.Parameters.Add("@ModifiedDate", SqlDbType.NVarChar).Value = DL.Common.DateFormat(ModifiedDate);
            command.Parameters.Add("@Lat", SqlDbType.Decimal).Value = Lat;
            command.Parameters.Add("@Long", SqlDbType.Decimal).Value = Long;
            command.Parameters.Add("@ClientName", SqlDbType.NVarChar).Value = ClientName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ClientEmail;
            command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = status;
            command.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = Unit;
            command.Parameters.Add("@Price", SqlDbType.NVarChar).Value = Price;
            command.Parameters.Add("@AddressAutoId", SqlDbType.Int).Value = AddressAutoId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
      
        var WorkOrderNo=ds.Tables[0].Rows[0]["WorkOrderNo"].ToString();
        ConsumerOTPDs(connectionKey, UserId, "SmsTemplateOrderBooking", ClientName, WorkOrderNo);
        if ((ClientEmail.ToString() != string.Empty)||(ClientEmail.ToString() != ""))
        {
            SendMail(connectionKey, ClientEmail, ClientName, WorkOrderNo, "MailTemplateOrderBooking");
        }
       return ds;
    }

    /// <summary>
    /// Devices the user registration.
    /// </summary>
    /// <param name="connectionKey">The connection key.</param>
    /// <param name="userId">The user identifier.</param>
    /// <param name="password">The password.</param>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <param name="emailId">The email identifier.</param>
    /// <param name="mobileNo">The mobile no.</param>
    /// <param name="modifirdBy">The modifird by.</param>
    /// <param name="modifiedDate">The modified date.</param>

    #region DeviceUserRegistration Parameter Info
    const string DeviceUserRegistrationDesc = strStyle + @"<div><b> DeviceUserRegistration:</b> For Registering the User and Send Verification OTP on Registerd Mobile No. <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>FirstName:</td>
<td>User First Name</td>
</tr>
<tr>
<td>LastName:</td>
<td>User Last Name (optional)</td>
</tr>
<tr>
<td>Password:</td>
<td>User Password</td>
</tr>
<tr>
<td>EmailId:</td>
<td>User Email ID (optional)</td>
</tr>
<tr>
<td>MobileNo:</td>
<td>User Mobile No.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + DeviceUserRegistrationDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceUserRegistration(string connectionKey, string UserId, string FirstName, string LastName, string Password, string EmailId, string MobileNo)
    {
        //var objCon = new ConnectionString();
        //var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        //using (var scn = new SqlConnection(connect))
        //{
        //    SqlCommand command = new SqlCommand("udp_ConsumerLoginDetailInsert", scn);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
        //    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
        //    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
        //    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
        //    command.Parameters.Add("@EmailId", SqlDbType.NVarChar).Value = EmailId;
        //    command.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = MobileNo;
        //    scn.Open();
        //    var adapter = new SqlDataAdapter(command);
        //    adapter.Fill(ds);
        //}
        ds = DeviceUserRegistrationDs(connectionKey, UserId, FirstName, LastName, Password, EmailId, MobileNo);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        //return jsonString;
        //Context.Response.Write(jsonString);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
        //Context.Response.Write("[{'Success':'true'}]");
    }
   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as DeviceUserRegistration</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet DeviceUserRegistrationDs(string connectionKey, string UserId, string FirstName, string LastName, string Password, string EmailId, string MobileNo)
    {   
 
        string strkey = GetDecryptkey(connectionKey);
        string strEncodedPassword;
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        strEncodedPassword = objblUserManagement.EncryptPassword(Password, true, strkey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_ConsumerLoginDetailInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = strEncodedPassword;
            command.Parameters.Add("@EmailId", SqlDbType.NVarChar).Value = EmailId;
            command.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = MobileNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
      if (ds.Tables[0].Rows[0]["MessageID"].ToString()== "0")
      { 
        ConsumerOTPDs(connectionKey, UserId, "SmsTemplateUserRegistration",string.Empty, string.Empty);
      }
        return ds;

    }
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }
    /// <summary>
    /// SMS Templates : SmsTemplateUserRegistration, 
    /// </summary>
    /// <param name="connectionKey"></param>
    /// <param name="mobileNumber"></param>
    /// <param name="strOTP"></param>
    /// <param name="TemplateType">SmsTemplateUserRegistration,SmsTemplateForgotPwd,SmsTemplateOrderBooking,SmsTemplateCancelOrder</param>
    /// <returns></returns>
    ///     
    #region ConsumerOTP Parameter Info
    const string ConsumerOTPDesc = strStyle + @"<div><b> ConsumerOTP:</b> For saving and sending OTP on User registration when user changes its Mobile Number.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>TemplateType:</td>
<td>SmsTemplateUserRegistration</td>
</tr>
<tr>
<td>Username:</td>
<td>Left Blank</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Left Blank</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + ConsumerOTPDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void ConsumerOTP(string connectionKey, string UserId, string TemplateType, string Username, string WorkOrderNo)
    {
        var ds = new DataSet();

        ds = ConsumerOTPDs(connectionKey, UserId, TemplateType, Username, WorkOrderNo);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as ConsumerOTP</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet ConsumerOTPDs(string connectionKey, string UserId, string TemplateType, string Username, string WorkOrderNo)
    {
        var OTP = GenerateOTP();
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_ConsumerOTPInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@OTP", SqlDbType.NVarChar).Value = OTP;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        SendOTPDs(connectionKey, UserId, OTP, TemplateType, Username, WorkOrderNo);
        return ds;
    }
   #region GenerateOTPforForgotPassword Parameter Info
   const string GenerateOTPforForgotPasswordDesc = strStyle + @"<div><b> GenerateOTPforForgotPassword:</b> For saving and sending OTP on Mobile when User click Forgot Password.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
</table></div>";
   #endregion
       [WebMethod(Description = strJson + GenerateOTPforForgotPasswordDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GenerateOTPforForgotPassword(string connectionKey, string UserId)
    {
        var ds = new DataSet();

        ds = GenerateOTPforForgotPasswordDs(connectionKey, UserId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GenerateOTPforForgotPassword</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GenerateOTPforForgotPasswordDs(string connectionKey, string UserId)
    {
        var OTP = GenerateOTP();
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_ConsumerOTPInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@OTP", SqlDbType.NVarChar).Value = OTP;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        SendOTPDs(connectionKey, UserId, OTP, "SmsTemplateForgotPwd", string.Empty, string.Empty);
        return ds;
    }



    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as VerifyOTP</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet VerifyOTPDs(string connectionKey, string UserId,string OTP)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_VerifyOtp", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@OTP", SqlDbType.NVarChar).Value = OTP;
              scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    #region VerifyOTP Parameter Info
    const string VerifyOTPDesc = strStyle + @"<div><b> VerifyOTP:</b> For verification of User OTP whether valid or not.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>OTP:</td>
<td>OTP received by the user</td>
</tr>
</table></div>";
    #endregion
      [WebMethod(Description = strJson + VerifyOTPDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void VerifyOTP(string connectionKey, string UserId, string OTP)
    {
        var ds = new DataSet();
        ds = VerifyOTPDs(connectionKey, UserId,OTP);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public DataSet VerifyUserIdDs(string connectionKey, string UserId, string UserIdType)
    //{
    //    var objCon = new ConnectionString();
    //    var connect = objCon.ConnectionStringGet(connectionKey);
    //    var ds = new DataSet();
    //    using (var scn = new SqlConnection(connect))
    //    {
    //        SqlCommand command = new SqlCommand("udp_CheckUserID", scn);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
    //        command.Parameters.Add("@UserIdType", SqlDbType.NVarChar).Value = UserIdType;
    //        scn.Open();
    //        var adapter = new SqlDataAdapter(command);
    //        adapter.Fill(ds);
    //    }
    //    return ds;
    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void VerifyUserId(string connectionKey, string UserId, string UserIdType)
    //{
    //    var ds = new DataSet();
    //    ds = VerifyUserIdDs(connectionKey, UserId, UserIdType);
    //    var objConvertDatatableToJson = new ConvertDatatableToJson();
    //    string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
    //    Context.Response.Clear();
    //    Context.Response.ContentType = "application/json";
    //    Context.Response.Write(jsonString);
    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public DataSet DeletenUpdateRecordDs(string connectionKey, string UserId,  string OtpType)
    //{
    //    var objCon = new ConnectionString();
    //    var connect = objCon.ConnectionStringGet(connectionKey);
    //    var ds = new DataSet();
    //    using (var scn = new SqlConnection(connect))
    //    {
    //        SqlCommand command = new SqlCommand("udp_UpdateNDeleteRecord", scn);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
        
    //        command.Parameters.Add("@OtpType", SqlDbType.NVarChar).Value = OtpType;
    //        scn.Open();
    //        var adapter = new SqlDataAdapter(command);
    //        adapter.Fill(ds);
    //    }
    //    return ds;
    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void DeletenUpdateRecord(string connectionKey, string UserId,  string OtpType)
    //{
    //    var ds = new DataSet();
    //    ds = DeletenUpdateRecordDs(connectionKey, UserId, OtpType);
    //    var objConvertDatatableToJson = new ConvertDatatableToJson();
    //    string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
    //    Context.Response.Clear();
    //    Context.Response.ContentType = "application/json";
    //    Context.Response.Write(jsonString);
    //}
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as ResetPassword</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet ResetPasswordDs(string connectionKey, string UserId, string Password)
    {
        string strkey = GetDecryptkey(connectionKey);
        string strEncodedPassword;
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        strEncodedPassword = objblUserManagement.EncryptPassword(Password, true, strkey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_ResetPassword", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;

            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = strEncodedPassword;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    #region ResetPassword Parameter Info
    const string ResetPasswordDesc = strStyle + @"<div><b> ResetPassword:</b> For Resetting the user Password from Forgot Password Screen.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>Password:</td>
<td>User New Password</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + ResetPasswordDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void ResetPassword(string connectionKey, string UserId,  string Password)
    {
        var ds = new DataSet();
        ds = ResetPasswordDs(connectionKey, UserId, Password);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as UserLogin</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet UserLoginDs(string connectionKey, string UserID, string Password)
    {
        bool PasswordMatchStatus = false;
        string strkey = GetDecryptkey(connectionKey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetPassword", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }

        if (!String.IsNullOrEmpty(Password))
        { 
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
        {
            
                BL.UserManagement objblUserManagement = new BL.UserManagement();
                PasswordMatchStatus = objblUserManagement.DoesPasswordMatch(ds.Tables[1].Rows[0]["password"].ToString(), Password, true, strkey);
                var ds1 = new DataSet();
                var objCon1 = new ConnectionString();
                var connect1 = objCon1.ConnectionStringGet(connectionKey);

                using (var scn = new SqlConnection(connect1))
                {
                    SqlCommand command = new SqlCommand("udp_UserLogin", scn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
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
    #region UserLogin Parameter Info
    const string UserLoginDesc = strStyle + @"<div><b> UserLogin:</b> For checking the user valid User Id and Password.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>Password:</td>
<td>User Password</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UserLoginDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UserLogin(string connectionKey, string UserID,string Password)
    {
        var ds = new DataSet();
        ds = UserLoginDs(connectionKey, UserID,Password);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetUserDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetUserDetailDs(string connectionKey, string UserID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetUserDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    #region GetUserDetail Parameter Info
    const string GetUserDetailDesc = strStyle + @"<div><b> GetUserDetail:</b> Return User Details such as First Name,Last Name,Email Id,Mobile Number.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + GetUserDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetUserDetail(string connectionKey, string UserID)
    {
        var ds = new DataSet();
        ds = GetUserDetailDs(connectionKey, UserID);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as UpdatePassword</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet UpdatePasswordDs(string connectionKey,string UserId, string oldPwd,string NewPwd)
    {
         
            bool PasswordMatchStatus = false;
            string strkey = GetDecryptkey(connectionKey);
            var objCon = new ConnectionString();
            var connect = objCon.ConnectionStringGet(connectionKey);
            var ds = new DataSet();
            using (var scn = new SqlConnection(connect))
            {
                SqlCommand command = new SqlCommand("udp_GetPassword", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
                scn.Open();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
            }

            if (!String.IsNullOrEmpty(oldPwd))
            {
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
                {

                    BL.UserManagement objblUserManagement = new BL.UserManagement();
                    PasswordMatchStatus = objblUserManagement.DoesPasswordMatch(ds.Tables[1].Rows[0]["password"].ToString(), oldPwd, true, strkey);
                    var ds1 = new DataSet();
                    var objCon1 = new ConnectionString();
                    var connect1 = objCon1.ConnectionStringGet(connectionKey);
                    string strkey1 = GetDecryptkey(connectionKey);
                    string strEncodedPassword;
                    BL.UserManagement objblUserManagement1 = new BL.UserManagement();
                    strEncodedPassword = objblUserManagement1.EncryptPassword(NewPwd, true, strkey1);
                    using (var scn = new SqlConnection(connect))
                    {
                        SqlCommand command = new SqlCommand("udp_UpdatePassword", scn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
                         command.Parameters.Add("@NewPwd", SqlDbType.NVarChar).Value = strEncodedPassword;
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
    #region UpdatePassword Parameter Info
    const string UpdatePasswordDesc = strStyle + @"<div><b> UpdatePassword:</b> For Updating the user Password.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<td>oldPwd:</td>
<td>User Old Password</td>
</tr>
<tr>
<td>NewPwd:</td>
<td>User New Password</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdatePasswordDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdatePassword(string connectionKey, string UserId, string oldPwd, string NewPwd)
    {
        var ds = new DataSet();
        ds = UpdatePasswordDs(connectionKey, UserId,  oldPwd, NewPwd);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as UpdateProfile</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet UpdateProfileDs(string connectionKey, string UserId, string FirstName, string LastName, string Email)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateProfile", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                      scn.Open();
                      var adapter = new SqlDataAdapter(command);
                      adapter.Fill(ds);
        }
        return ds;
    }

    #region UpdateProfile Parameter Info
    const string UpdateProfileDesc = strStyle + @"<div><b> UpdateProfile:</b> For Updating the User Profile.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<td>FirstName:</td>
<td>User First Name</td>
</tr>
<tr>
<td>LastName:</td>
<td>User Last Name (optional)</td>
</tr>
<tr>
<td>Email:</td>
<td>User Email ID (optional)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateProfileDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateProfile(string connectionKey,string UserId, string FirstName,string LastName,string Email)
    {
        var ds = new DataSet();
        ds = UpdateProfileDs(connectionKey, UserId, FirstName, LastName, Email);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void GetStateDetail(string connectionKey)
    //{
    //    var ds = new DataSet();
    //    ds = GetStateDetailDs(connectionKey);
    //    var objConvertDatatableToJson = new ConvertDatatableToJson();
    //    string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
    //    Context.Response.Clear();
    //    Context.Response.ContentType = "application/json";
    //    Context.Response.Write(jsonString);
    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public DataSet GetStateDetailDs(string connectionKey)
    //{
    //    var objCon = new ConnectionString();
    //    var connect = objCon.ConnectionStringGet(connectionKey);
    //    var ds = new DataSet();
    //    using (var scn = new SqlConnection(connect))
    //    {
    //        SqlCommand command = new SqlCommand("Udpmst_StateDetail_get", scn);
    //        command.CommandType = CommandType.StoredProcedure;
    //        scn.Open();
    //        var adapter = new SqlDataAdapter(command);
    //        adapter.Fill(ds);
    //    }
    //    return ds;
    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void GetStateDistrict(string connectionKey, string stateId)
    //{
    //    var ds = new DataSet();
    //    ds =GetStateDistrictDs(connectionKey,stateId);
    //    var objConvertDatatableToJson = new ConvertDatatableToJson();
    //    string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
    //    Context.Response.Clear();
    //    Context.Response.ContentType = "application/json";
    //    Context.Response.Write(jsonString);
    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public DataSet GetStateDistrictDs(string connectionKey, string stateId)
    //{
    //    var objCon = new ConnectionString();
    //    var connect = objCon.ConnectionStringGet(connectionKey);
    //      var ds = new DataSet();
    //    using (var scn = new SqlConnection(connect))
    //    {
    //        SqlCommand command = new SqlCommand("Udpmst_districtdetail_get", scn);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@stateId", SqlDbType.NVarChar).Value = stateId;
    //        scn.Open();
    //        var adapter = new SqlDataAdapter(command);
    //        adapter.Fill(ds);
                      
    //    }
    //    return ds;
    //}


    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void GetServiceCategoryDetail(string connectionKey)
    //{
    //    var ds = new DataSet();
    //    ds = GetServiceCategoryDetailDs(connectionKey);
    //    var objConvertDatatableToJson = new ConvertDatatableToJson();
    //    string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
    //    Context.Response.Clear();
    //    Context.Response.ContentType = "application/json";
    //    Context.Response.Write(jsonString);
    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public DataSet GetServiceCategoryDetailDs(string connectionKey)
    //{
    //    var objCon = new ConnectionString();
    //    var connect = objCon.ConnectionStringGet(connectionKey);
    //    var ds = new DataSet();
    //    using (var scn = new SqlConnection(connect))
    //    {
    //        SqlCommand command = new SqlCommand("Udp_ServiceCategoryDetail", scn);
    //        command.CommandType = CommandType.StoredProcedure;
    //        scn.Open();
    //        var adapter = new SqlDataAdapter(command);
    //        adapter.Fill(ds);

    //    }
    //    return ds;
    //}
    #region GetOrderHistory Parameter Info
    const string GetOrderHistoryDesc = strStyle + @"<div><b> GetOrderHistory:</b> Return all the orders Detail placed by the User.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>

</table></div>";
    #endregion
    [WebMethod(Description = strJson + GetOrderHistoryDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetOrderHistory(string connectionKey, string UserID)
    {
        var ds = new DataSet();
        ds = GetOrderHistoryDs(connectionKey, UserID);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetOrderHistory</b></div>")]

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetOrderHistoryDs(string connectionKey, string UserID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_GetOrderHistory", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
   #region GetFeedBackDetail Parameter Info
   const string GetFeedBackDetailDesc = strStyle + @"<div><b> GetFeedBackDetail:</b> Returns feedback given by the user for an Particular WorkOrderNo. <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>OrderNo:</td>
<td>Service WorkOrderNo.</td>
</tr>

</table></div>";
   #endregion
   [WebMethod(Description = strJson + GetFeedBackDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetFeedBackDetail(string connectionKey, string UserID,string OrderNo)
    {
        var ds = new DataSet();
        ds = GetFeedBackDetailDs(connectionKey, UserID, OrderNo);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetFeedBackDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetFeedBackDetailDs(string connectionKey, string UserID, string OrderNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_GetFeedbackDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            command.Parameters.Add("@OrderNo", SqlDbType.NVarChar).Value = OrderNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void FeedBackInsertnUpdate(string connectionKey, string UserID, string OrderNo,string EmployeeName,string Feedback,string Flag)
    //{
    //    var ds = new DataSet();
    //    ds = FeedBackInsertnUpdateDs(connectionKey, UserID, OrderNo, EmployeeName, Feedback, Flag);
    //    var objConvertDatatableToJson = new ConvertDatatableToJson();
    //    string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
    //    Context.Response.Clear();
    //    Context.Response.ContentType = "application/json";
    //    Context.Response.Write(jsonString);
    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public DataSet FeedBackInsertnUpdateDs(string connectionKey, string UserID, string OrderNo, string EmployeeName, string Feedback, string Flag)
    //{
    //    var objCon = new ConnectionString();
    //    var connect = objCon.ConnectionStringGet(connectionKey);
    //    var ds = new DataSet();
    //    using (var scn = new SqlConnection(connect))
    //    {
    //        SqlCommand command = new SqlCommand("Udp_FeedbackInsertnUpdate", scn);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
    //        command.Parameters.Add("@OrderNo", SqlDbType.NVarChar).Value = OrderNo;
    //        command.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = EmployeeName;
    //        command.Parameters.Add("@Feedback", SqlDbType.NVarChar).Value = Feedback;
    //        command.Parameters.Add("@Flag", SqlDbType.NVarChar).Value = Flag;
            
    //        scn.Open();
    //        var adapter = new SqlDataAdapter(command);
    //        adapter.Fill(ds);

    //    }
    //    return ds;
    //}
    #region OrderCancellation Parameter Info
    const string OrderCancellationDesc = strStyle + @"<div><b> OrderCancellation:</b> Cancel the Order selected by User and send OTP and Email regarding Order Cancellation.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>OrderNo:</td>
<td>Service WorkOrderNo.</td>
</tr>
<tr>
<td>Reason:</td>
<td>Reason for Order Cancellation(optional)</td>
</tr>
<tr>
<td>ClientName:</td>
<td>Left Blank</td>
</tr>

</table></div>";
    #endregion
    [WebMethod(Description = strJson + OrderCancellationDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void OrderCancellation(string connectionKey, string UserID, string OrderNo, string Reason, string ClientName)
    {
        var ds = new DataSet();
        ds = OrderCancellationDs(connectionKey, UserID, OrderNo, Reason, ClientName);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as OrderCancellation</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet OrderCancellationDs(string connectionKey, string UserID, string OrderNo, string Reason, string ClientName)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_CancelOrder", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            command.Parameters.Add("@OrderNo", SqlDbType.NVarChar).Value = OrderNo;
            command.Parameters.Add("@reason", SqlDbType.NVarChar).Value = Reason;
          
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        if(ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
        { 
        var objCon1 = new ConnectionString();
        var connect1 = objCon1.ConnectionStringGet(connectionKey);
        var ds1 = new DataSet();
        using (var scn = new SqlConnection(connect1))
        {
            SqlCommand command = new SqlCommand("udp_GetUserDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
             scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds1);

        }
        var FirstName = ds1.Tables[0].Rows[0]["FirstName"].ToString();
        var LastName = ds1.Tables[0].Rows[0]["LastName"].ToString();
        var Email = ds1.Tables[0].Rows[0]["EmailID"].ToString();
        var Name = FirstName + " " + LastName;
        ConsumerOTPDs(connectionKey, UserID, "SmsTemplateCancelOrder", Name, OrderNo);
        if ((Email.ToString() != string.Empty) || (Email.ToString() != ""))
        {
            SendMail(connectionKey, Email, Name, OrderNo, "MailTemplateCancelOrder");
        }
        }
    
        return ds;
    }
   #region GetProductDetail Parameter Info
   const string GetProductDetailDesc = strStyle + @"<div><b> GetProductDetail:</b> Return all the Products Detail of Product Catalogue.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
</table></div>";
   #endregion
   [WebMethod(Description = strJson + GetProductDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProductDetail(string connectionKey)
    {
        var ds = new DataSet();
        ds = GetProductDetailDs(connectionKey);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetProductDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetProductDetailDs(string connectionKey)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_GetProductDetails", scn);
            command.CommandType = CommandType.StoredProcedure;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    #region InsertAddress Parameter Info
    const string InsertAddressDesc = strStyle + @"<div><b> InsertAddress:</b> For inserting the user New Address.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>HouseNo:</td>
<td>User Address House No.</td>
</tr>
<tr>
<td>Location:</td>
<td>User Address location</td>
</tr>
<tr>
<td>Landmark:</td>
<td>User Address Landmark</td>
</tr>
<tr>
<td>city:</td>
<tdUser Address cityAutoId(currently 1 for Ghaziabad and 2 for Noida)</td>
</tr>
<tr>
<td>Pincode:</td>
<td>>User Address Pincode</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + InsertAddressDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertAddress(string connectionKey, string UserId, string HouseNo, string Location, string Landmark, string city, string Pincode)
    {
        var ds = new DataSet();
        ds = InsertAddressDs(connectionKey, UserId, HouseNo, Location, Landmark, city, Pincode);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as InsertAddress</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet InsertAddressDs(string connectionKey, string UserId,string HouseNo, string Location, string Landmark, string city, string Pincode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_InsertAddress", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@HouseNo", SqlDbType.NVarChar).Value = HouseNo;
            command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
            command.Parameters.Add("@Landmark", SqlDbType.NVarChar).Value = Landmark;
            command.Parameters.Add("@City", SqlDbType.NVarChar).Value = city;
            command.Parameters.Add("@PinCode", SqlDbType.NVarChar).Value = Pincode;
           
                   scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
   #region GetAddressDetail Parameter Info
   const string GetAddressDetailDesc = strStyle + @"<div><b> GetAddressDetail:</b> Return all the saved Address of an particular User.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
</table></div>";
   #endregion
   [WebMethod(Description = strJson + GetAddressDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAddressDetail(string connectionKey,string userId)
    {
        var ds = new DataSet();
        ds = GetAddressDetailDs(connectionKey,userId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetAddressDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetAddressDetailDs(string connectionKey,string userId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_GetAddressDetails", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    #region DeleteNeditAddress Parameter Info
    const string DeleteNeditAddressDesc = strStyle + @"<div><b> DeleteNeditAddress:</b> Delete and Get Address on the basis of Flag for an particular user.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>AutoId:</td>
<td>Address Auto ID</td>
</tr>
<tr>
<td>Flag:</td>
<td>Delete (for deleting the record) and Edit (for geting the address detail)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + DeleteNeditAddressDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeleteNeditAddress(string connectionKey, string userId, string AutoId, string Flag)
    {
        var ds = new DataSet();
        ds = DeleteNeditAddressDs(connectionKey, userId, AutoId, Flag);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as DeleteNeditAddress</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet DeleteNeditAddressDs(string connectionKey, string userId, string AutoId, string Flag)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_DeletenGetAddressDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add("@AutoId", SqlDbType.NVarChar).Value = AutoId;
            command.Parameters.Add("@Flag", SqlDbType.NVarChar).Value = Flag;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }

    #region UpdateAddress Parameter Info
    const string UpdateAddressDesc = strStyle + @"<div><b> UpdateAddress:</b> For updating the user address.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>HouseNo:</td>
<td>User Address House No.</td>
</tr>
<tr>
<td>Location:</td>
<td>User Address location</td>
</tr>
<tr>
<td>Landmark:</td>
<td>User Address Landmark</td>
</tr>
<tr>
<td>city:</td>
<tdUser Address cityAutoId(currently 1 for Ghaziabad and 2 for Noida)</td>
</tr>
<tr>
<td>Pincode:</td>
<td>>User Address Pincode</td>
</tr>
<tr>
<td>AutoId:</td>
<td>Address AutoId</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateAddressDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateAddress(string connectionKey, string UserId, string HouseNo, string Location, string Landmark, string city, string Pincode, string AutoId)
    {
        var ds = new DataSet();
        ds = UpdateAddressDs(connectionKey, UserId, HouseNo, Location, Landmark, city, Pincode, AutoId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as UpdateAddress</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet UpdateAddressDs(string connectionKey, string UserId, string HouseNo, string Location, string Landmark, string city, string Pincode, string AutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateAddress", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@HouseNo", SqlDbType.NVarChar).Value = HouseNo;
            command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
            command.Parameters.Add("@Landmark", SqlDbType.NVarChar).Value = Landmark;
            command.Parameters.Add("@City", SqlDbType.NVarChar).Value = city;
            command.Parameters.Add("@PinCode", SqlDbType.NVarChar).Value = Pincode;
            command.Parameters.Add("@AddressAutoId", SqlDbType.NVarChar).Value = AutoId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    #region GetServicePrice Parameter Info
    const string GetServicePriceDesc = strStyle + @"<div><b> GetServicePrice:</b> Return Price for an Particular service.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>ServiceCategoryAutoId:</td>
<td>Service Category Auto ID</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + GetServicePriceDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetServicePrice(string connectionKey, string ServiceCategoryAutoId)
    {
        var ds = new DataSet();
        ds = GetServicePriceDs(connectionKey, ServiceCategoryAutoId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetServicePrice</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetServicePriceDs(string connectionKey, string ServiceCategoryAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_GetServicePrice", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ServiceCategoryAutoId", SqlDbType.NVarChar).Value = ServiceCategoryAutoId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
   #region GetServiceDetail Parameter Info
   const string GetServiceDetailDesc = strStyle + @"<div><b> GetServiceDetail:</b> Return all Service list on the basis of Service Category.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>ServiceCategory:</td>
<td>Service Category Auto ID</td>
</tr>
</table></div>";
   #endregion
   [WebMethod(Description = strJson + GetServiceDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetServiceDetail(string connectionKey, string ServiceCategory)
    {
        var ds = new DataSet();
        ds = GetServiceDetailDs(connectionKey, ServiceCategory);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetServiceDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetServiceDetailDs(string connectionKey, string ServiceCategory)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_ServiceDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ServiceCategory", SqlDbType.NVarChar).Value = ServiceCategory;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    #region GetTimeSlotDetail Parameter Info
    const string GetTimeSlotDetailDesc = strStyle + @"<div><b> GetTimeSlotDetail:</b> Return all the possible Time Slots for the Services.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + GetTimeSlotDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetTimeSlotDetail(string connectionKey)
    {
        var ds = new DataSet();
        ds = GetTimeSlotDetailDs(connectionKey);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetTimeSlotDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetTimeSlotDetailDs(string connectionKey)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_TimeSlotDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
             scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    #region UpdateUserId Parameter Info
    const string UpdateUserIdDesc = strStyle + @"<div><b> UpdateUserId:</b> Update New UserID when user changes its Mobile Number on the basis of Old UserId <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>NewUserId:</td>
<td>New User Id (i.e. Mobile Number)</td>
</tr>
<tr>
<td>OldUserId:</td>
<td>Old User Id (i.e. Mobile Number)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + UpdateUserIdDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateUserId(string connectionKey,string NewUserId,string OldUserId)
    {
        var ds = new DataSet();
        ds = UpdateUserIdDs(connectionKey, NewUserId,OldUserId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as UpdateUserId</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet UpdateUserIdDs(string connectionKey, string NewUserId, string OldUserId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_UpdateUserId", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@NewUserId", SqlDbType.NVarChar).Value = NewUserId;
            command.Parameters.Add("@OldUserId", SqlDbType.NVarChar).Value = OldUserId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    #region GetOrderDetail Parameter Info
    const string GetOrderDetailDesc = strStyle + @"<div><b> GetOrderDetail:</b> Return an Complete Detail of an Particular Order.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>WorkOrderNo:</td>
<td>Service WorkOrderNO.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + GetOrderDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetOrderDetail(string connectionKey, string WorkOrderNo)
    {
        var ds = new DataSet();
        ds = GetOrderDetailDs(connectionKey, WorkOrderNo);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetOrderDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetOrderDetailDs(string connectionKey, string WorkOrderNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetOrderDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserID;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = WorkOrderNo;
         
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    #region FeedBackInsert Parameter Info
    const string FeedBackInsertDesc = strStyle + @"<div><b> FeedBackInsert:</b> For inserting the Feedback for an particular WorkOrderNo.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserID:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>OrderNo:</td>
<td>Service WorkOrderNO.</td>
</tr>
<tr>
<td>Feedback:</td>
<td>Service Feedback given by the User.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + FeedBackInsertDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void FeedBackInsert(string connectionKey, string UserID, string OrderNo, string Feedback)
    {
        var ds = new DataSet();
        ds = FeedBackInsertDs(connectionKey, UserID, OrderNo,  Feedback);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as FeedBackInsert</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet FeedBackInsertDs(string connectionKey, string UserID, string OrderNo, string Feedback)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udp_FeedbackInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = OrderNo;
            command.Parameters.Add("@Feedback", SqlDbType.NVarChar).Value = Feedback;
         

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }

   #region GetCityName Parameter Info
   const string GetCityNameDesc = strStyle + @"<div><b> GetCityName:</b> Return the Name of the cities where plumbing services providing.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
</table></div>";
   #endregion
    [WebMethod(Description = strJson + GetCityNameDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetCityName(string connectionKey)
    {
        var ds = new DataSet();
        ds = GetCityNameDs(connectionKey);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }



   [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetCityName</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetCityNameDs(string connectionKey)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetCityNames", scn);
            command.CommandType = CommandType.StoredProcedure;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
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
                if (TemplateType == "SmsTemplateUserRegistration")
                {
                    MsgBody = Resources.Resource.SmsTemplateUserRegistration1 + strOTP + Resources.Resource.SmsTemplateUserRegistration2;
                }
                if (TemplateType == "SmsTemplateForgotPwd")
                {
                    MsgBody = Resources.Resource.SmsTemplateForgotPwd1 + strOTP + Resources.Resource.SmsTemplateForgotPwd2;
                }
                if (TemplateType == "SmsTemplateOrderBooking")
                {
                    MsgBody = Resources.Resource.SmsTemplateOrderBooking1 + UserName + Resources.Resource.SmsTemplateOrderBooking2 + WorkOrderNo + Resources.Resource.SmsTemplateOrderBooking3;
                }
                if (TemplateType == "SmsTemplateCancelOrder")
                {
                    MsgBody = Resources.Resource.SmsTemplateCancelOrder1 + UserName + Resources.Resource.SmsTemplateCancelOrder2 + WorkOrderNo + Resources.Resource.SmsTemplateCancelOrder3;
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


    protected void SendOTP(string connectionKey, string mobileNumber, string strOTP, string TemplateType, string UserName, string WorkOrderNo)
    {
        var result = SendOTPDs(connectionKey, mobileNumber, strOTP, TemplateType,UserName,WorkOrderNo);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        if (result == "Success")
        { 
        Context.Response.Write("[{'Success':'true'}]");
        }
        else
        {
            Context.Response.Write("[{'Success':'false'}]");
        }
    }
    public void SendMail(string connectionKey, string txtMailTo, string clientName, string orderNo, string MailTemplate)
    {
        string ActivateMail = ConfigurationManager.AppSettings["ActivateMail"];
        if (ActivateMail.ToString() == "1")
        {
        string Address = string.Empty;
        string addressline1 = string.Empty;
        string addressline2 = string.Empty;
        string serviceName = string.Empty;
        string orderDate = string.Empty;
        string orderTime = string.Empty;
        string bookingDate = string.Empty;
        string Price = string.Empty;
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds1 = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetOrderDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserID;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = orderNo;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds1);
        }
   
        Address = ds1.Tables[0].Rows[0]["OrderAddress"].ToString();
        string[] lbladdress = Address.Split(',');
        addressline1 = lbladdress[0] + "," + lbladdress[1] + "," + lbladdress[2];
        addressline2 = lbladdress[3] + "," + lbladdress[4];
        serviceName = ds1.Tables[0].Rows[0]["ServiceCategoryName"].ToString();
        orderDate = ds1.Tables[0].Rows[0]["PreferredFromDate"].ToString();
        orderTime = ds1.Tables[0].Rows[0]["PreferredFromTime"].ToString();
        bookingDate = ds1.Tables[0].Rows[0]["ModifiedDate"].ToString();
        Price = ds1.Tables[0].Rows[0]["Price"].ToString();


        string Body = string.Empty;
        string Subject = string.Empty;
        if (MailTemplate == "MailTemplateCancelOrder")
        {
            string Body1 = Resources.Resource.MailTemplateCancelOrder1 + clientName + Resources.Resource.MailTemplateCancelOrder2 + orderNo + Resources.Resource.MailTemplateCancelOrder3 + Resources.Resource.MailTemplateCancelOrder4 + DateTime.Parse(bookingDate).ToString("dd MMM yyyy") + Resources.Resource.MailTemplateCancelOrder5 + serviceName;
            string Body2 = Resources.Resource.MailTemplateCancelOrder6 + DateTime.Parse(orderDate).ToString("dddd, MMM dd") + Resources.Resource.MailTemplateCancelOrder7 + orderTime + Resources.Resource.MailTemplateCancelOrder8 + clientName + Resources.Resource.MailTemplateCancelOrder9 + addressline1 + Resources.Resource.MailTemplateCancelOrder9 + addressline2 + Resources.Resource.MailTemplateCancelOrder9 + Resources.Resource.MailTemplateCancelOrder9;
            string Body3 = Resources.Resource.MailTemplateCancelOrder10 + Resources.Resource.MailTemplateCancelOrder11 + Resources.Resource.MailTemplateCancelOrder12 + Resources.Resource.MailTemplateCancelOrder13 + Resources.Resource.MailTemplateCancelOrder14  +Resources.Resource.MailTemplateCancelOrder9 + Resources.Resource.MailTemplateCancelOrder9 + Resources.Resource.MailTemplateCancelOrder15;
            Body = Body1 + Body2 + Body3;
            Subject = Resources.Resource.MailTemplateCancelOrder16;
        }
        if (MailTemplate == "MailTemplateOrderBooking")
        {
            string Body1 = Resources.Resource.MailTemplateOrderBooking1 + clientName + Resources.Resource.MailTemplateOrderBooking2 + orderNo + Resources.Resource.MailTemplateOrderBooking3 + Resources.Resource.MailTemplateOrderBooking4 + DateTime.Now.ToString("dd MMM yyyy") + Resources.Resource.MailTemplateOrderBooking5 + DateTime.Now.ToShortTimeString();
            string Body2 = Resources.Resource.MailTemplateOrderBooking6 + serviceName + Resources.Resource.MailTemplateOrderBooking7 + DateTime.Parse(orderDate).ToString("dddd, MMM dd") + Resources.Resource.MailTemplateOrderBooking5 + orderTime + Resources.Resource.MailTemplateOrderBooking8 + Price + Resources.Resource.MailTemplateOrderBooking9 + clientName + Resources.Resource.MailTemplateOrderBooking10 + addressline1 + Resources.Resource.MailTemplateOrderBooking10 + addressline2 + Resources.Resource.MailTemplateOrderBooking10 + Resources.Resource.MailTemplateOrderBooking10;
            string Body3 = Resources.Resource.MailTemplateOrderBooking11 + Resources.Resource.MailTemplateOrderBooking12 + Resources.Resource.MailTemplateOrderBooking13;
            Body = Body1 + Body2 + Body3;
            Subject = Resources.Resource.MailTemplateOrderBooking14;

        }
      
             try
             {
                 using (MailMessage mm = new MailMessage(Resources.Resource.MailTemplateEmailID, txtMailTo))
                 {
                     mm.Subject = Subject;
                     mm.Body = Body;
                     mm.IsBodyHtml = true;
                     SmtpClient smtp = new SmtpClient();
                     smtp.Host = Resources.Resource.MailTemplateHostName;
                     smtp.EnableSsl = true;
                     NetworkCredential NetworkCred = new NetworkCredential(Resources.Resource.MailTemplateEmailID, Resources.Resource.MailTemplateEmailPassword);
                     smtp.UseDefaultCredentials = true;
                     smtp.Credentials = NetworkCred;
                     smtp.Port = 587;
                     smtp.Send(mm);

                 }

             }
             catch (Exception ex)
             {

             }
         }
    }

    #region InsertPaymentDetail Parameter Info
    const string InsertPaymentDetailDesc = strStyle + @"<div><b> InsertPaymentDetail:</b> Insert the payment getway response detail into the database .<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>workOrderNo:</td>
<td>Service WorkOrderNO.</td>
</tr>
<tr>
<td>paymentStatus:</td>
<td>Payment Status received by Payment Getway (It may Be SUCCESS / FAILED)</td>
</tr>
<tr>
<td>responseMessage:</td>
<td>Response Message received by Payment Getway (Left Blank if paymentStatus is FAILED)</td>
</tr>
<tr>
<td>paymentDate:</td>
<td>Transaction Date received by Payment Getway (Left Blank if paymentStatus is FAILED)</td>
</tr>
<tr>
<td>paymentId:</td>
<td>Payment ID received by Payment Getway (Left Blank if paymentStatus is FAILED)</td>
</tr>
<tr>
<td>Amount:</td>
<td>Transaction Amount received by Payment Getway (Left Blank if paymentStatus is FAILED)</td>
</tr>
<tr>
<td>Mode:</td>
<td>Transaction Mode received by Payment Getway (Left Blank if paymentStatus is FAILED)</td>
</tr>
<tr>
<td>TransactionId:</td>
<td>Transaction ID received by Payment Getway (Left Blank if paymentStatus is FAILED)</td>
</tr>
<tr>
<td>Error:</td>
<td>Error Description received by Payment Getway when any Error Occurs (Left Blank if paymentStatus is SUCCESS)</td>
</tr>
<tr>
<td>UserID:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + InsertPaymentDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertPaymentDetail(string connectionKey, string workOrderNo, string paymentStatus, string responseMessage, string paymentDate, string paymentId, string Amount, string Mode, string TransactionId, string Error, string UserID)
    {
        var ds = new DataSet();
        ds = InsertPaymentDetailDs(connectionKey, workOrderNo, paymentStatus, responseMessage, paymentDate, paymentId, Amount, Mode, TransactionId, Error,UserID);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }



    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as InsertPaymentDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet InsertPaymentDetailDs(string connectionKey, string workOrderNo, string paymentStatus, string responseMessage, string paymentDate, string paymentId, string Amount, string Mode, string TransactionId, string Error, string UserID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_PlumbingPaymentDetailInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@WorkOrderNo", SqlDbType.NVarChar).Value = workOrderNo;
            command.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar).Value = paymentStatus;
            command.Parameters.Add("@ResponseMessage", SqlDbType.NVarChar).Value = responseMessage;
            command.Parameters.Add("@PaymentDate", SqlDbType.NVarChar).Value = paymentDate;
            command.Parameters.Add("@PaymentId", SqlDbType.NVarChar).Value = paymentId;
            command.Parameters.Add("@Amount", SqlDbType.NVarChar).Value = Amount;
            command.Parameters.Add("@Mode", SqlDbType.NVarChar).Value = Mode;
            command.Parameters.Add("@TransactionID", SqlDbType.NVarChar).Value = TransactionId;
            command.Parameters.Add("@Error", SqlDbType.NVarChar).Value = Error;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }

    #region InsertIntoCart Parameter Info
    const string InsertIntoCartDesc = strStyle + @"<div><b> InsertIntoCart:</b> For inserting the workorder and sending SMS and Email regarding Order Confirmation  <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
<tr>
<td>Location:</td>
<td>User Bsse Location (Send 1 as value)</td>
</tr>
<tr>
<td>ServiceAutoId:</td>
<td>User Selected Service Auto Id</td>
</tr>
<tr>
<td>PreferredFromDate:</td>
<td>User Selected Service Date</td>
</tr>
<td>PreferredFromTime:</td>
<td>User Selected Service Time</td>
</tr>
<td>MobileNo:</td>
<td>User Mobile No.</td>
</tr>
<tr>
<td>Lat:</td>
<td>Latitude Co-ordinates of User Location from where WorkOrder is booked (if Value exists then send that co-ordinates otherwise send 0.00000000 as co-ordinates)</td>
</tr>
<tr>
<td>Long:</td>
<td>Longitude Co-ordinates of User Location from where WorkOrder is booked (if Value exists then send that co-ordinates otherwise send 0.00000000 as co-ordinates)</td>
</tr>
<tr>
<td>ClientName:</td>
<td>User Name</td>
</tr>
<tr>
<td>ClientEmail:</td>
<td>User Email ID</td>
</tr>
<tr>
<td>Unit:</td>
<td>Number of Service Unit/Units Ordered by the User</td>
</tr>
<tr>
<td>Price:</td>
<td>Price of Service Unit/Units Ordered by the User</td>
</tr>
<tr>
<td>AddressAutoId:</td>
<td>User AddressAutoId(If you are sending Values of Building No,Locality,Landmark,City,Pin then send AddressAutoId as 0 otherwise Address AddressAutoId)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + InsertIntoCartDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public void InsertIntoCart(string connectionKey, string UserId, string Location, int ServiceAutoId, string PreferredFromDate, string PreferredFromTime, string MobileNo, Decimal Lat, Decimal Long, string ClientName, string ClientEmail, string Unit, string Price, int AddressAutoId)
    {
        var ds = new DataSet();
        ds = InsertIntoCartDs(connectionKey, UserId, Location, ServiceAutoId, PreferredFromDate, PreferredFromTime, MobileNo, Lat, Long, ClientName, ClientEmail, Unit, Price, AddressAutoId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }



    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as InsertIntoCart</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet InsertIntoCartDs(string connectionKey, string UserId, string Location, int ServiceAutoId, string PreferredFromDate, string PreferredFromTime, string MobileNo, Decimal Lat, Decimal Long, string ClientName, string ClientEmail, string Unit, string Price, int AddressAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpInsertDetailsIntoCart", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location;
            command.Parameters.Add("@ServiceAutoId", SqlDbType.Int).Value = ServiceAutoId;
            command.Parameters.Add("@PreferredFromDate", SqlDbType.NVarChar).Value = DL.Common.DateFormat(PreferredFromDate);
            command.Parameters.Add("@PreferredFromTime", SqlDbType.NVarChar).Value = PreferredFromTime;
            command.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = MobileNo;
            command.Parameters.Add("@Lat", SqlDbType.Decimal).Value = Lat;
            command.Parameters.Add("@Long", SqlDbType.Decimal).Value = Long;
            command.Parameters.Add("@ClientName", SqlDbType.NVarChar).Value = ClientName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ClientEmail;
            command.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = Unit;
            command.Parameters.Add("@Price", SqlDbType.NVarChar).Value = Price;
            command.Parameters.Add("@AddressAutoId", SqlDbType.Int).Value = AddressAutoId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }

    #region GetCardDetail Parameter Info
    const string GetCardDetailDesc = strStyle + @"<div><b> GetCardDetail:</b> Returns Add to Cart Items for a particular user.  <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User ID (i.e. Mobile Number)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + GetCardDetailDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public void GetCardDetail(string connectionKey, string UserId)
    {
        var ds = new DataSet();
        ds = GetCardDetailDs(connectionKey, UserId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as GetCardDetail</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet GetCardDetailDs(string connectionKey, string UserId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetCartDetails", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }

    #region DeleteCartOrder Parameter Info
    const string DeleteCartOrderDesc = strStyle + @"<div><b> DeleteCartOrder:</b> Delete the Order from the cart on the basis of CartAutoId.  <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>CartAutoId:</td>
<td>CartAutoId for the Particular order.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + DeleteCartOrderDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public void DeleteCartOrder(string connectionKey, int CartAutoId)
    {
        var ds = new DataSet();
        ds = DeleteCartOrderDs(connectionKey, CartAutoId);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    [WebMethod(Description = "<div><b>Return Type: Data Set and Parameter Information same as DeleteCartOrder</b></div>")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataSet DeleteCartOrderDs(string connectionKey, int CartAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_DeleteFromCart", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CartAutoId", SqlDbType.Int).Value = CartAutoId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    #region PayZapMsgHash Parameter Info
    const string PayZapMsgHashDesc = strStyle + @"<div><b> PayZapMsgHash:</b> Return the Payzapp Hash on the basis of OrderId and Price. <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>OrderId:</td>
<td>OrderId whose Hash to be generated.</td>
</tr>
<tr>
<td>Price:</td>
<td>Price of the Order.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + PayZapMsgHashDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void PayZapMsgHash(string connectionKey, string OrderId,string Price)
    {
        var MerchantId=  System.Configuration.ConfigurationManager.AppSettings["MerchantId"];
        var AppId=  System.Configuration.ConfigurationManager.AppSettings["AppId"];
        var SecretKey=  System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
        string MsgString = "wpay|" + MerchantId + "|" + AppId + "|" + OrderId + "|instaservicelabs|" + Price + "|356|*|true|true|" + SecretKey + "|";
        string SHA256 = Base64SHA256(MsgString.ToString());
        string v2SHA256 = "v2:" + SHA256.ToString();
        Context.Response.Write("[{'OrderId':'" + OrderId.ToString() + "','MsgHash':'" + v2SHA256.ToString() + "'}]");
    }
    static string Base64SHA256(string s)
    {
        var hasher = SHA256.Create();      
        byte[] bs = Encoding.ASCII.GetBytes(s);
        byte[] hashValue = hasher.ComputeHash(bs);
        return Convert.ToBase64String(hashValue);
    }
   
  
    #region PayZapChargeAPI Parameter Info
    const string PayZapChargeAPIDesc = strStyle + @"<div><b> PayZapChargeAPI:</b> It validates the msgHash and if is valid then call the charge API. <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>OrderId:</td>
<td>OrderId of the Order.</td>
</tr>
<tr>
<td>Price:</td>
<td>Price of the Order.</td>
</tr>
<tr>
<td>wPayTxnId:</td>
<td>wPayTxnId generated from PayZap.</td>
</tr>
<tr>
<td>resCode:</td>
<td>resCode generated from PayZap.</td>
</tr>
<tr>
<td>msgHash:</td>
<td>msgHash generated from PayZap.</td>
</tr>
<tr>
<td>dataPickUpCode:</td>
<td>dataPickUpCode generated from PayZap.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + PayZapChargeAPIDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void PayZapChargeAPI(string connectionKey, string OrderId, string Price, string wPayTxnId, string resCode, string msgHash, string dataPickUpCode)
    {
        var MerchantId = System.Configuration.ConfigurationManager.AppSettings["MerchantId"];
        var AppId = System.Configuration.ConfigurationManager.AppSettings["AppId"];
        var SecretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
        string MsgString = "wpay|" + MerchantId + "|" + AppId + "|" + OrderId + "|instaservicelabs|" + Price + "|356|" + wPayTxnId + "|" + resCode + "|" + dataPickUpCode + "|" + SecretKey + "|";
        string SHA256 = Base64SHA256(MsgString.ToString());
        string v2SHA256 = "v2:" + SHA256.ToString();
        TimeZoneInfo timeZoneInfo1;
        DateTime dateTime1;
        timeZoneInfo1 = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        dateTime1 = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo1);
        if (resCode == "000")
        {
            if (v2SHA256.Equals(msgHash))
            {
                string chargeApiResult = ChargeAPI(wPayTxnId, Price, OrderId);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic item = serializer.Deserialize<object>(chargeApiResult);
                bool chargeSuccessful = item["chargeSuccessful"];
                if ((item["resCode"] != null) || (item["resCode"] != ""))
                {
                    if ((item["resCode"] == "000") && (item["data"]["pgStatusCode"] == "50020") && (chargeSuccessful))
                    {
                        string amount = Convert.ToString(((decimal)item["data"]["txnAmt"] / 100));
                        var formattedamount = decimal.Parse(amount).ToString("N2");
                        var ds = new DataSet();
                        ds = InsertPaymentDetailDs(connectionKey, Convert.ToString(item["data"]["merTxnId"]), "SUCCESS", "Transaction Successful", dateTime1.ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToString(item["data"]["pgTxnId"]), formattedamount, "PAYZAPP", Convert.ToString(item["data"]["wibmoTxnId"]), "", "");
                        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                        {
                            Context.Response.Write("[{'Message':'Transaction Successful','OrderId':'" + item["merTxnId"] + "','Amount':'" + (Convert.ToInt32(Price) / 100).ToString() + "','TxnID':'" + item["data"]["wibmoTxnId"] + "'}]");
                        }
                        else
                        {
                            Context.Response.Write("[{'Message':'" + ds.Tables[0].Rows[0]["MessageString"].ToString() + "','OrderId':'" + item["merTxnId"] + "','Amount':'" + (Convert.ToInt32(Price)/100).ToString() + "','TxnID':''}]");
                        }
                    }
                    else
                    {
                        Context.Response.Write("[{'Message':'Transaction Declined','OrderId':'" + item["merTxnId"] + "','Amount':'" + (Convert.ToInt32(Price) / 100).ToString() + "','TxnID':''}]");
                    }
                }
                else
                {
                    string EnquiryApiResult = EnquiryAPI(wPayTxnId, Price, OrderId);
                    JavaScriptSerializer serializerEnquiry = new JavaScriptSerializer();
                    dynamic itemEnquiry = serializerEnquiry.Deserialize<object>(EnquiryApiResult);
                    bool chargeSuccessfulEnquiry = itemEnquiry["chargeSuccessful"];
                    if ((itemEnquiry["resCode"] == "000") && (itemEnquiry["data"]["pgStatusCode"] == "50020") && (chargeSuccessfulEnquiry))
                    {
                        string amountEnquiry = Convert.ToString(((decimal)itemEnquiry["data"]["txnAmt"] / 100));
                        var formattedamountEnquiry = decimal.Parse(amountEnquiry).ToString("N2");
                        var ds = new DataSet();
                        ds = InsertPaymentDetailDs(connectionKey, Convert.ToString(itemEnquiry["data"]["merTxnId"]), "SUCCESS", "Transaction Successful", dateTime1.ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToString(itemEnquiry["data"]["pgTxnId"]), formattedamountEnquiry, "PAYZAPP", Convert.ToString(itemEnquiry["data"]["wibmoTxnId"]), "", "");
                        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                        {
                            Context.Response.Write("[{'Message':'Transaction Successful','OrderId':'" + itemEnquiry["merTxnId"] + "','Amount':'" + (Convert.ToInt32(Price) / 100).ToString() + "','TxnID':'" + itemEnquiry["data"]["wibmoTxnId"] + "'}]");
                        }
                        else
                        {
                            Context.Response.Write("[{'Message':'" + ds.Tables[0].Rows[0]["MessageString"].ToString() + "','OrderId':'" + itemEnquiry["merTxnId"] + "','Amount':'" + (Convert.ToInt32(Price) / 100).ToString() + "','TxnID':''}]");
                        }
                    }
                    else
                    {
                        Context.Response.Write("[{'Message':'Transaction Declined','OrderId':'" + itemEnquiry["merTxnId"] + "','Amount':'" + (Convert.ToInt32(Price) / 100).ToString() + "','TxnID':''}]");
                    }
                }
            }
            else
            {
                Context.Response.Write("[{'Message':'Invalid Msg Hash','OrderId':'" + OrderId.ToString() + "','Amount':'" + (Convert.ToInt32(Price) / 100).ToString() + "','TxnID':''}]");
            }
        }
        else
        {
            Context.Response.Write("[{'Message':'Invalid Response Code','OrderId':'" + OrderId.ToString() + "','Amount':'" + (Convert.ToInt32(Price) / 100).ToString() + "','TxnID':''}]");
        }
    }
    private string ChargeAPI(string wPayTxnId, string price, string OrderId)
    {
        TimeZoneInfo timeZoneInfo1;
        DateTime dateTime1;
        timeZoneInfo1 = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        dateTime1 = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo1);
        var date = dateTime1.ToString("dd-MMM-yyyy");
        var MerchantId = System.Configuration.ConfigurationManager.AppSettings["MerchantId"];
        var AppId = System.Configuration.ConfigurationManager.AppSettings["AppId"];
        var SecretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
        var result = "";
        string MsgHash = "v2:" + Base64SHA256("wpay|" + MerchantId + "|" + OrderId + "|" + AppId + "|" + price + "|356|true|" + SecretKey + "|");
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.wibmo.com/v2/in/txn/iap/wpay/charge");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"merchantInfo\":{\"merName\":\"Insta Service labs\", \"merId\":\"" + MerchantId + "\", \"merCountryCode\":\"IN\", \"merAppId\":\"" + AppId + "\" }," +
                            "\"transactionInfo\":{  \"txnAmount\":\"" + price + "\", \"txnCurrency\":\"356\",\"txnDesc\":\"\",\"txnDate\":\"" + date + "\",\"txnAmtKnown\":\"true  \",\"chargeLater\":\"true\", \"merTxnId\":\"" + OrderId + "\" }," +
                            "\"msgHash\":\"" + MsgHash + "\",  \"chargeCard\":\"true\", \"txnType\":\"WPay\", \"wibmoTxnId\":\"" + wPayTxnId + "\" }";

            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
        return result;
    }
    private string EnquiryAPI(string wPayTxnId, string price, string OrderId)
    {
        TimeZoneInfo timeZoneInfo1;
        DateTime dateTime1;
        timeZoneInfo1 = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        dateTime1 = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo1);
        var date = dateTime1.ToString("dd-MMM-yyyy");
        var MerchantId = System.Configuration.ConfigurationManager.AppSettings["MerchantId"];
        var AppId = System.Configuration.ConfigurationManager.AppSettings["AppId"];
        var SecretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
        var result = "";
        string MsgHash = "v2:" + Base64SHA256("wpay|" + MerchantId + "|" + OrderId + "|" + AppId + "|" + price + "|356|true|" + SecretKey + "|");
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.wibmo.com/v2/in/txn/iap/wpay/enquiry");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"merchantInfo\":{\"merName\":\"Insta Service labs\", \"merId\":\"" + MerchantId + "\", \"merCountryCode\":\"IN\", \"merAppId\":\"" + AppId + "\" }," +
                            "\"transactionInfo\":{  \"txnAmount\":\"" + price + "\", \"txnCurrency\":\"356\",\"txnDesc\":\"\",\"txnDate\":\"" + date + "\",\"txnAmtKnown\":\"true  \",\"chargeLater\":\"true\", \"merTxnId\":\"" + OrderId + "\" }," +
                            "\"msgHash\":\"" + MsgHash + "\",  \"chargeCard\":\"true\", \"txnType\":\"WPay\", \"wibmoTxnId\":\"" + wPayTxnId + "\" }";

            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
        return result;
    }


    #region InsertAppError Parameter Info
    const string InsertAppErrorDesc = strStyle + @"<div><b> InsertAppError:</b> Insert the Error occured in the APK.  <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>mobile:</td>
<td>Mobile No in which error occured.</td>
</tr>
<tr>
<td>errorcode:</td>
<td>Error code of the error.</td>
</tr>
<tr>
<td>description:</td>
<td>Decription of the Error.</td>
</tr>
<tr>
<td>softwareversion:</td>
<td>Software Version of the Mobile.</td>
</tr>
<tr>
<td>voicemail:</td>
<td>Voice mail of the mobile.</td>
</tr>
<tr>
<td>networkCountryISO:</td>
<td>networkCountryISO of the provider.</td>
</tr>
<tr>
<td>IMEINumber:</td>
<td>IMEI Number of the Mobile.</td>
</tr>
<tr>
<td>SIMCountryISO:</td>
<td>SIMCountryISO of the provider.</td>
</tr>
<tr>
<td>brandname:</td>
<td>Mobile Brand Name.</td>
</tr>
<tr>
<td>errordate:</td>
<td>Error date of the error occured.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + InsertAppErrorDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public void InsertAppError(string connectionKey,string mobile, string errorcode, string description, string softwareversion, string voicemail, string networkCountryISO, string IMEINumber, string SIMCountryISO, string brandname, string errordate)
    {
     
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpInsertAppError", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = mobile;
            command.Parameters.Add("@errorcode", SqlDbType.NVarChar).Value = errorcode;
            command.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
            command.Parameters.Add("@softwareversion", SqlDbType.NVarChar).Value = softwareversion;
            command.Parameters.Add("@voicemail", SqlDbType.NVarChar).Value = voicemail;
            command.Parameters.Add("@networkCountryISO", SqlDbType.NVarChar).Value = networkCountryISO;
            command.Parameters.Add("@IMEINumber", SqlDbType.NVarChar).Value = IMEINumber;
            command.Parameters.Add("@SIMCountryISO", SqlDbType.NVarChar).Value = SIMCountryISO;
            command.Parameters.Add("@brandname", SqlDbType.NVarChar).Value = brandname;
            command.Parameters.Add("@errordate", SqlDbType.NVarChar).Value = errordate;
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

    #region GetAppError Parameter Info
    const string GetAppErrorDesc = strStyle + @"<div><b> GetAppError:</b> Returns all the Error reported in the APK.  <br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td>
<td>Database Connection Key.</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + GetAppErrorDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public void GetAppError(string connectionKey)
    {

        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpGetAppError", scn);
            command.CommandType = CommandType.StoredProcedure;
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

}
