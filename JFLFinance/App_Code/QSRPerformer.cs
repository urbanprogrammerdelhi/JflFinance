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
using System.Text;
/// <summary>
/// Summary description for QSRPerformer
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class QSRPerformer : System.Web.Services.WebService {
    const string strStyle = @"<style>table {border-collapse: collapse;} table, th, td {border: 1px solid silver;} div{border: 1px solid silver;}</style>";
    const string strJson = @"<div><b>Return Type: Json</b></div>";
    protected DataSet PerformerLoginDs(string connectionKey, string UserId, string Password)
    {
        bool PasswordMatchStatus = false;
        string strkey = GetDecryptkey(connectionKey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetPerformerPassword", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }

        if (!String.IsNullOrEmpty(Password))
        {
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
            {

                BL.UserManagement objblUserManagement = new BL.UserManagement();
                PasswordMatchStatus = objblUserManagement.DoesPasswordMatch(ds.Tables[0].Rows[0]["password"].ToString(), UserId + Password, true, strkey);
                var ds1 = new DataSet();
                var objCon1 = new ConnectionString();
                var connect1 = objCon1.ConnectionStringGet(connectionKey);

                using (var scn = new SqlConnection(connect1))
                {
                    SqlCommand command = new SqlCommand("udp_PerformerLogin", scn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
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
    #region PerformerLogin Parameter Info
    const string PerformerLoginDesc = strStyle + @"<div><b> PerformerLogin :</b>  For Validating the Performer valid User Id and Password.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>connectionKey:</td>
<td>Database Connection Key</td>
</tr>
<tr>
<td>UserId:</td>
<td>User Id</td>
</tr>
<tr>
<td>Password:</td>
<td>User Password</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + PerformerLoginDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void PerformerLogin(string connectionKey, string UserId, string Password)
    {
        var ds = new DataSet();
        ds = PerformerLoginDs(connectionKey, UserId, Password);
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
    #region GetPostDetails
    const string strHelpGetPostDetails = strStyle + @"<div><b> GetPostDetails:</b> Return the Post Details (LocationAutoID, PostAutoId, ClientCode, ClientName, AsmtId, AsmtName, PostCode, PostDesc, SoRank, PostText, PostValue, ShiftCode, WeekNo, MonNoOfPersons, TueNoOfPersons, WedNoOfPersons, ThuNoOfPersons, FriNoOfPersons, SatNoOfPersons, SunNoOfPersons, MonTimeFrom, MonTimeTo, TueTimeFrom, TueTimeTo, WedTimeFrom, WedTimeTo, ThuTimeFrom, ThuTimeTo, FriTimeFrom, FriTimeTo, SatTimeFrom, SatTimeTo, SunTimeFrom, SunTimeTo)<br/>
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
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help GetPostDetails
    [WebMethod(Description = strJson + strHelpGetPostDetails)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPostDetails(string connectionKey, string userId, string postAutoId,int LocationAutoID)
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
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;

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
    #region  DevicePerformerInOutInsert
    const string strHelpDevicePerformerInOutInsertBase64 = strStyle + @"<div><b> DevicePerformerInOutInsertBase64:</b> Return the MessageString and MessageId, in case of sucess MessageId value will be 1<br/>
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
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help DevicePerformerInOutInsert
   
    public void DevicePerformerInOutInsert(string connectionKey, string IMEI, string userId, string postValue, string employeeNumber,
        string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage, int LocationAutoId)
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
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
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
    [WebMethod(Description = strJson + strHelpDevicePerformerInOutInsertBase64)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DevicePerformerInOutInsertBase64(string connectionKey, string IMEI, string userId, string postValue, string employeeNumber,
        string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64,int LocationAutoId)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        DevicePerformerInOutInsert(connectionKey, IMEI, userId, postValue, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage, LocationAutoId);

    }
    #region Help TicketGenerationBase64
    const string strHelpTicketGenerationBase64 = strStyle + @"<div><b> TicketGenerationBase64:</b> Return the MessageString and MessageId, in case of sucess MessageId value will be 1<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>userId:</td><td>loged in userId</td>
</tr><tr>
<td>ClientCode:</td><td>Client Code</td>
</tr><tr>
<td>ClientName:</td><td>Client Name</td>
</tr><tr>
<td>SiteId:</td><td>Site Id</td>
</tr><tr>
<td>SiteName</td><td>Site Name</td>
</tr><tr>
<td>DateOfCreation:</td><td>Ticket Date of Creation</td>
</tr><tr>
<td>SummaryOfIssue:</td><td>Ticket Summary of Issues</td>
</tr><tr>
<td>DescriptionOfIssue:</td><td>Ticket Description Of Issue</td>
</tr><tr>
<td>Severity:</td><td>Ticket Severity</td>
</tr>
<tr>
<td>CommercialValue:</td><td>Ticket CommercialValue (Non Mandatory)</td>
<tr>
<tr>
<td>LocationAutoID:</td><td>LocationAutoID</td>
<tr>
<tr>
<td>AssetCategoryAutoID:</td><td>AssetCategoryAutoID</td>
<tr>
<tr>
<td>AssetSubCategoryAutoID:</td><td>AssetSubCategoryAutoID</td>
<tr>
<tr>
<td>AssetAutoId:</td><td>AssetAutoId</td>
<tr>
<td>TicketImage:</td><td>Ticket Image (Non Mandatory) </td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help TicketGenerationBase64
    public void TicketGeneration(string connectionKey, string userId, string ClientCode,string ClientName,
      string SiteId, string SiteName, string DateOfCreation, string SummaryOfIssue, string DescriptionOfIssue, string Severity, string CommercialValue, byte[] TicketImage, int LocationAutoID, int AssetCategoryAutoId, int AssetSubCategoryAutoId, int AssetAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpTicketInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.ClientName, SqlDbType.NVarChar).Value = ClientName;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = SiteId;
            command.Parameters.Add(DL.Properties.Resources.AsmtName, SqlDbType.NVarChar).Value = SiteName;
            command.Parameters.Add(DL.Properties.Resources.DateOfCreation, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DateOfCreation);
            command.Parameters.Add(DL.Properties.Resources.SummaryOfIssues, SqlDbType.NVarChar).Value = SummaryOfIssue;
            command.Parameters.Add(DL.Properties.Resources.Description, SqlDbType.NVarChar).Value = DescriptionOfIssue;
            command.Parameters.Add(DL.Properties.Resources.Severity, SqlDbType.NVarChar).Value = Severity;
            command.Parameters.Add(DL.Properties.Resources.CommercialValue, SqlDbType.NVarChar).Value = CommercialValue;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.AssetCategoryAutoId, SqlDbType.Int).Value = AssetCategoryAutoId;
            command.Parameters.Add(DL.Properties.Resources.AssetSubCategoryAutoId, SqlDbType.Int).Value = AssetSubCategoryAutoId;
            command.Parameters.Add(DL.Properties.Resources.AssetAutoId, SqlDbType.Int).Value = AssetAutoId;
          
            if (TicketImage != null && TicketImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)TicketImage;
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
    [WebMethod(Description = strJson + strHelpTicketGenerationBase64)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void TicketGenerationBase64(string connectionKey, string userId, string ClientCode, string ClientName,
      string SiteId, string SiteName, string DateOfCreation, string SummaryOfIssue, string DescriptionOfIssue, string Severity, string CommercialValue, string TicketImageBase64,int LocationAutoID,int AssetCategoryAutoId, int AssetSubCategoryAutoId, int AssetAutoId)
    {
        byte[] TicketImage = System.Convert.FromBase64String(TicketImageBase64);
        TicketGeneration(connectionKey, userId, ClientCode,ClientName, SiteId,SiteName,
         DateOfCreation, SummaryOfIssue, DescriptionOfIssue, Severity, CommercialValue, TicketImage, LocationAutoID,AssetCategoryAutoId, AssetSubCategoryAutoId, AssetAutoId);

    }

    #region GetAllTicketsDetails
    const string strHelpGetAllTicketsDetails = strStyle + @"<div><b> GetAllTicketsDetails:</b> Return all the tickets on the basis of UserID<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in UserID</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help GetAllTicketsDetails
    [WebMethod(Description = strJson + strHelpGetAllTicketsDetails)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAllTicketsDetails(string connectionKey, string userId,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetAllTicketDetails", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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

    #region GetTicketsDetail
    const string strHelpGetTicketsDetail = strStyle + @"<div><b> GetTicketsDetail:</b> Return particular ticket detail on the basis of UserID and TicketNo<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in UserID</td>
</tr>
<tr>
<td>TicketNo.:</td><td>Ticket No.</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion 
    [WebMethod(Description = strJson + strHelpGetTicketsDetail)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetTicketDetail(string connectionKey, string userId,string TicketNo,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetTicketDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.TicketNo, SqlDbType.NVarChar).Value = TicketNo;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            string ImageBase64;
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {

                //string Img = (ds.Tables[0].Rows[0]["WOImage"].ToString());
                //byte[] Image = Encoding.ASCII.GetBytes(Img);
                //string ImageBase64 = Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])).Length);
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
                {
                    if (ds.Tables[0].Rows[0]["WOImage"] != DBNull.Value)
                    {
                         ImageBase64 = Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])));
                    }
                    else
                    {
                         ImageBase64 = null;
                    }
                    //string ImageBase64 = Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])));
                    Context.Response.Write("[{'Message':'Success','AssetWONo':'" + ds.Tables[0].Rows[0]["AssetWONo"].ToString() + "','WOstatus':'" + ds.Tables[0].Rows[0]["WOstatus"].ToString() + "','ResturantCode':'" + ds.Tables[0].Rows[0]["ClientCode"].ToString() + "','ResturantName':'" + ds.Tables[0].Rows[0]["ClientName"].ToString() + "','AsmtBillingId':'" + ds.Tables[0].Rows[0]["AsmtBillingId"].ToString() + "','ResturantAddress':'" + ds.Tables[0].Rows[0]["AsmtName"].ToString() + "','DateOfCreation':'" + ds.Tables[0].Rows[0]["DateOfCreation"].ToString() + "','SummaryOfIssues':'" + ds.Tables[0].Rows[0]["SummaryOfIssues"].ToString() + "','DescOfIssues':'" + ds.Tables[0].Rows[0]["DescOfIssues"].ToString() + "','Severity':'" + ds.Tables[0].Rows[0]["Severity"].ToString() + "','CommercialValue':'" + ds.Tables[0].Rows[0]["CommercialValue"].ToString() + "','WOImage':'" + ImageBase64 + "','CompanyName':'" + ds.Tables[0].Rows[0]["CompanyName"].ToString() + "','AssetCategoryName':'" + ds.Tables[0].Rows[0]["AssetCategoryName"].ToString() + "','AssetSubCategoryName':'" + ds.Tables[0].Rows[0]["AssetSubCategoryName"].ToString() + "','AssetName':'" + ds.Tables[0].Rows[0]["AssetName"].ToString() + "'}]");
                }
                else if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "-1")
                {
                    Context.Response.Write("[{'Message':'Invalid UserId'}]");
                }
                else
                {
                    Context.Response.Write("[{'Message':'Invalid Ticket No.'}]");
                }
            
            }
            else
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write("[{'Message':'Invalid Post'}]");
            }
        }
    }
    #region GetDailyTaskDetail
    const string strHelpGetDailyTaskDetail = strStyle + @"<div><b> GetDailyTaskDetail:</b> Return all the tasks on the basis of LocationAutoId,ClientCode,AsmtId,PostAutoId.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<td>ClientCode:</td><td>Client Code</td>
</tr>
<tr>
<td>AsmtId:</td><td>AsmtId</td>

</tr>
<tr>
<td>PostAutoID:</td><td>PostAutoId (int)</td>
</tr>
<tr>
<td>EmployeeNumber:</td><td>Loged in User Employee Number</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion 
    [WebMethod(Description = strJson + strHelpGetDailyTaskDetail)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetDailyTaskDetail(string connectionKey, string ClientCode,string AsmtId,int PostAutoID,string EmployeeNumber,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetDailyTaskDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtId;
            command.Parameters.Add(DL.Properties.Resources.PostAutoId, SqlDbType.NVarChar).Value = PostAutoID;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = EmployeeNumber;
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
    #region UpdateTicketStatusToClosed
    const string strHelpUpdateTicketStatusToClosed = strStyle + @"<div><b> UpdateTicketStatusToClosed:</b> Update ticket status to closed on the basis of Ticket No..<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>userId:</td><td>Loged in UserID</td>
</tr>
<tr>
<td>TicketNo:</td><td>Ticket No. whose status needs to be changed.</td>

</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion 
    [WebMethod(Description = strJson + strHelpUpdateTicketStatusToClosed)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateTicketStatusToClosed(string connectionKey,string userId, string TicketNo,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_UpdateTicketStatusToClosed", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.TicketNo, SqlDbType.NVarChar).Value = TicketNo;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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
    #region UploadTaskImageBase64
    const string strHelpUploadTaskImageBase64 = strStyle + @"<div><b> UploadTaskImageBase64:</b> Insert Task Image into the database.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>taskName:</td><td>Task Name</td>
</tr>
<tr>
<td>taskImage:</td><td>Task Image</td>
</tr>
<tr>
<td>UserId:</td><td>Logged in User ID.</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help UploadTaskImageBase64

    public void UploadTaskImage(string connectionKey, string taskName, byte[] taskImage, string UserId,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        string[] TaskNAmeSplit = taskName.Split('(');
        string Time = TaskNAmeSplit[1].ToString();
        string[] FromTime = Time.Split('-');
        string ToTime1 = FromTime[1].ToString();
        string[] ToTime = ToTime1.Split(')');
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("Udp_InsertTaskImage", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.ChecklistItem, SqlDbType.NVarChar).Value = TaskNAmeSplit[0].ToString(); 
            
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.FromTime, SqlDbType.NVarChar).Value = FromTime[0].ToString();
            command.Parameters.Add(DL.Properties.Resources.ToTime, SqlDbType.NVarChar).Value = ToTime[0].ToString();
            if (taskImage != null && taskImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)taskImage;
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
    [WebMethod(Description = strJson + strHelpUploadTaskImageBase64)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UploadTaskImageBase64(string connectionKey, string taskName, string taskImageBase64,string UserId,int LocationAutoID)
    {
      
        byte[] taskImage = System.Convert.FromBase64String(taskImageBase64);
        UploadTaskImage(connectionKey, taskName, taskImage, UserId, LocationAutoID);

    }
    #region UpdateDailyTaskStatus
    const string strHelpUpdateDailyTaskStatus = strStyle + @"<div><b> UpdateDailyTaskStatus:</b> Update Task Status.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>UserID:</td><td>Logged in User ID.</td>
</tr>
<tr>
<td>ClientCode:</td><td>Client Code.</td>
</tr>
<tr>
<td>AsmtId:</td><td>Asmt ID.</td>
</tr>
<tr>
<td>PostAutoID:</td><td>Post ID.</td>
</tr>
<tr>
<td>TaskName:</td><td>Task Name.</td>
</tr>
<tr>
<td>Status:</td><td>Status.</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help UpdateDailyTaskStatus
    [WebMethod(Description = strJson + strHelpUpdateDailyTaskStatus)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateDailyTaskStatus(string connectionKey,string UserID, string ClientCode,string AsmtId,string PostAutoID,string TaskName, string Status,int LocationAutoID,string ChecklistText)
    {
        string[] TaskNAmeSplit = TaskName.Split('(');
        string Time = TaskNAmeSplit[1].ToString();
        string[] FromTime = Time.Split('-');
        string ToTime1 = FromTime[1].ToString();
        string[] ToTime = ToTime1.Split(')');
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_UpdateDailyTaskStatus", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = UserID;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtId;
            command.Parameters.Add(DL.Properties.Resources.PostAutoId, SqlDbType.NVarChar).Value = PostAutoID;
            command.Parameters.Add(DL.Properties.Resources.ChecklistItem, SqlDbType.NVarChar).Value = TaskNAmeSplit[0].ToString();
            command.Parameters.Add(DL.Properties.Resources.FromTime, SqlDbType.NVarChar).Value = FromTime[0].ToString();
            command.Parameters.Add(DL.Properties.Resources.ToTime, SqlDbType.NVarChar).Value = ToTime[0].ToString();
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = Status;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.ChecklistName, SqlDbType.NVarChar).Value = ChecklistText;
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

    #region GetTodaysTaskList
    const string strHelpGetTodaysTaskList = strStyle + @"<div><b> GetTodaysTaskList:</b> Get all the Today’s Scheduled Tasks. <br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in UserID</td>
</tr>
<tr>
<td>EmployeeNumber:</td><td>Employee Number</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help GetTodaysTaskList
    [WebMethod(Description = strJson + strHelpGetTodaysTaskList)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetTodaysTaskList(string connectionKey, string userId,string EmployeeNumber,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetTodaysTaskList", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = EmployeeNumber;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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

    #region GetTodaysTicketList
    const string strHelpGetTodaysTicketList = strStyle + @"<div><b> GetTodaysTicketList:</b> Get all the Today’s Scheduled Tickets.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in UserID</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help GetTodaysTicketList
    [WebMethod(Description = strJson + strHelpGetTodaysTicketList)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetTodaysTicketList(string connectionKey, string userId,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetTodaysTicketsList", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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
   
    #region GetTaskImage
    const string strHelpGetTaskImage = strStyle + @"<div><b> GetTaskImage:</b> Get Task Image.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in UserID</td>
</tr>
<tr>
<td>CheckListItem:</td><td>Check List item Name whose image is to fetch.</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help GetTaskImage
    [WebMethod(Description = strJson + strHelpGetTaskImage)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetTaskImage(string connectionKey, string userId,string CheckListItem,int LocationAutoID)
    {
        string[] TaskNAmeSplit = CheckListItem.Split('(');
        string Time = TaskNAmeSplit[1].ToString();
        string[] FromTime = Time.Split('-');
        string ToTime1 = FromTime[1].ToString();
        string[] ToTime = ToTime1.Split(')');
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetTaskImage", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.ChecklistItem, SqlDbType.NVarChar).Value = TaskNAmeSplit[0].ToString();
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.FromTime, SqlDbType.NVarChar).Value = FromTime[0].ToString();
            command.Parameters.Add(DL.Properties.Resources.ToTime, SqlDbType.NVarChar).Value = ToTime[0].ToString();
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
                ds.Tables[0].Columns.Add(dc);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ItemImage"].ToString() != "")
                    {
                        ds.Tables[0].Rows[i]["ImageBase64String"] = Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["ItemImage"])));
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["ImageBase64String"] = string.Empty;
                    }
                }
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

    #region GetCompanyDetails
    const string strHelpGetCompanyDetails = strStyle + @"<div><b> GetCompanyDetails:</b> Get Company Details on the basis of LocationAutoID.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help strHelpGetCompanyDetails
    [WebMethod(Description = strJson + strHelpGetCompanyDetails)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetCompanyDetails(string connectionKey, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetCompany", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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
    #region GetAssetCategory
    const string strHelpGetAssetCategory = strStyle + @"<div><b> GetAssetCategory:</b> Get Asset Category Details on the basis of LocationAutoID.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help strHelpGetAssetCategory
    [WebMethod(Description = strJson + strHelpGetAssetCategory)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAssetCategory(string connectionKey, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetCategory", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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

    #region GetAssetSubCategory
    const string strHelpGetSubAssetCategory = strStyle + @"<div><b> GetAssetSubCategory:</b> Get Asset Sub Category Details on the basis of Category ID.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>AssetCategoryId:</td><td>AssetCategoryId (Integer)</td>
</tr>
</table></div>";
    #endregion Help strHelpGetSubAssetCategory
    [WebMethod(Description = strJson + strHelpGetSubAssetCategory)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAssetSubCategory(string connectionKey, int LocationAutoID, int AssetCategoryId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetSubCategory", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AssetCategoryId, SqlDbType.Int).Value = AssetCategoryId;
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

    #region GetAssetDetail
    const string strHelpGetAssetDetail = strStyle + @"<div><b> GetAssetDetail:</b> Get Asset Details on the basis of Asset Sub Category ID and LocationAutoID.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
<tr>
<td>AssetSubCategoryId:</td><td>AssetSubCategoryId (Integer)</td>
</tr>
</table></div>";
    #endregion Help strHelpGetAssetDetail
    [WebMethod(Description = strJson + strHelpGetAssetDetail)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAssetDetail(string connectionKey, int LocationAutoID, int AssetSubCategoryId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetAsset", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AssetSubCategoryAutoId, SqlDbType.Int).Value = AssetSubCategoryId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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

    #region GetResturantDetail
    const string strHelpGetResturantDetail = strStyle + @"<div><b> GetResturantDetail:</b> Get Resturant Name on the basis of LocationAutoID.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help strHelpGetResturantDetail
    [WebMethod(Description = strJson + strHelpGetResturantDetail)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetResturantDetail(string connectionKey, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("Udp_GetResturantCode", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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

    #region GetAssetdetailByScanQRCode
    const string strHelpGetAssetdetailByScanQRCode = strStyle + @"<div><b> GetAssetdetailByScanQRCode:</b> Get Asset Detail on the basis of QR Code.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>AssetQRValue:</td><td>Scanned Asset QR Value</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help strHelpGetResturantDetail
    [WebMethod(Description = strJson + strHelpGetAssetdetailByScanQRCode)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAssetdetailByScanQRCode(string connectionKey, string AssetQRValue, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("GetAssetdetailByScanQRCode", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AssetName, SqlDbType.NVarChar).Value = AssetQRValue;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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

    #region AssetTagging
    const string strHelpAssetTagging = strStyle + @"<div><b> AssetTagging:</b> Get Asset Mapping Details on the basis of QR Code.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>AssetQRValue:</td><td>Scanned Asset QR Value</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help strHelpAssetTagging
    [WebMethod(Description = strJson + strHelpAssetTagging)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AssetTagging(string connectionKey, string AssetQRValue, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("GetAssetTaggingDetail", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AssetName, SqlDbType.NVarChar).Value = AssetQRValue;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
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

    #region GetResturantSiteDetail
    const string strHelpGetResturantSiteDetail = strStyle + @"<div><b> GetResturantSiteDetail:</b> Get Resturant Site Address on the basis of Resturant Code.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>

<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
<tr>
<td>Resturant Code:</td><td>Resturant Code</td>
</tr>
</table></div>";
    #endregion Help strHelpGetResturantSiteDetail
    [WebMethod(Description = strJson + strHelpGetResturantSiteDetail)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetResturantSiteDetail(string connectionKey,  int LocationAutoID, string ResturantCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("Udp_GetResturantAddress", scn);
            command.CommandType = CommandType.StoredProcedure;        
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ResturantCode;
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

    #region GetResturantPostDetail
    const string strHelpGetResturantPostDetail = strStyle + @"<div><b> GetResturantPostDetail:</b> Get Resturant Post Address on the basis of Resturant Code n site Id.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>

<tr>
<td>Resturant Code:</td><td>Resturant Code</td>
</tr>

<tr>
<td>AsmtId:</td><td>Resturant Site ID</td>
</tr>
</table></div>";
    #endregion Help strHelpGetResturantPostDetail
    [WebMethod(Description = strJson + strHelpGetResturantPostDetail)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetResturantPostDetail(string connectionKey, string ResturantCode, string AsmtId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("Udp_GetResturantPost", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ResturantCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtId;
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

    #region InsertAssetTagging
    const string strHelpInsertAssetTagging = strStyle + @"<div><b> InsertAssetTagging:</b> Insert Asset Tagging mapping.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>AssetAutoId:</td><td>AssetAutoId</td>
</tr>
<tr>
<td>LocationAutoID:</td><td>LocationAutoID</td>
</tr>

<tr>
<td>Resturant Code:</td><td>Resturant Code</td>
</tr>

<tr>
<td>AsmtId:</td><td>Resturant Site ID</td>
</tr>
<tr>
<td>PostAutoId:</td><td>PostAutoId</td>
</tr>
<tr>
<td>userId:</td><td>Logged in userid</td>
</tr>
</table></div>";
    #endregion Help strHelpInsertAssetTagging
    [WebMethod(Description = strJson + strHelpInsertAssetTagging)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertAssetTagging(string connectionKey, int AssetAutoId, int LocationAutoID, string ResturantCode, string AsmtId, int PostAutoId, string userId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("Udp_InsertAssetTagging", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AssetAutoId, SqlDbType.Int).Value = AssetAutoId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ResturantCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtId;
            command.Parameters.Add(DL.Properties.Resources.PostAutoId, SqlDbType.Int).Value = PostAutoId;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
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

    #region Help InsertAssetDiscovery
    const string strHelpInsertAssetDiscovery = strStyle + @"<div><b> InsertAssetDiscovery:</b> Return the MessageString and MessageId, in case of sucess MessageId value will be 1<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>AssetAutoId:</td><td>AssetAutoId</td>
<tr>
<tr>
<td>AssetCode:</td><td>AssetCode</td>
</tr><tr>
<td>AssetName:</td><td>AssetName</td>
</tr><tr>
<td>ResturantCode:</td><td>ResturantCode</td>
</tr><tr>
<td>ResturantName:</td><td>ResturantName</td>
</tr><tr>
<td>ResturantAddress</td><td>ResturantAddress</td>
</tr><tr>
<td>ResturantPost:</td><td>ResturantPost</td>
</tr><tr>
<td>UserId:</td><td>UserId</td>
</tr><tr>
<td>LocationAutoId:</td><td>LocationAutoId</td>
</tr><tr>
<td>AssetImage:</td><td>AssetImage</td>
</tr>
</table></div>";
    #endregion Help TicketGenerationBase64
    public void InsertAssetDiscovery(string connectionKey, int AssetAutoId, string AssetCode, string AssetName, string ResturantCode, string ResturantName, string ResturantAddress, string ResturantPost, string UserId, int LocationAutoId, byte[] AssetImage)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("Udp_InsertAssetDiscovery", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AssetAutoId, SqlDbType.Int).Value = AssetAutoId;
            command.Parameters.Add(DL.Properties.Resources.AssetCode, SqlDbType.NVarChar).Value = AssetCode;
            command.Parameters.Add(DL.Properties.Resources.AssetName, SqlDbType.NVarChar).Value = AssetName;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ResturantCode;
            command.Parameters.Add(DL.Properties.Resources.ClientName, SqlDbType.NVarChar).Value = ResturantName;
            command.Parameters.Add(DL.Properties.Resources.AsmtAddress, SqlDbType.NVarChar).Value = ResturantAddress;
            command.Parameters.Add(DL.Properties.Resources.Post, SqlDbType.NVarChar).Value = ResturantPost;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = UserId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            if (AssetImage != null && AssetImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)AssetImage;
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
    [WebMethod(Description = strJson + strHelpInsertAssetDiscovery)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertAssetDiscoveryBase64(string connectionKey, int AssetAutoId, string AssetCode, string AssetName, string ResturantCode, string ResturantName, string ResturantAddress, string ResturantPost, string UserId, int LocationAutoId, string AssetImageBase64)
    {
        byte[] AssetImage = System.Convert.FromBase64String(AssetImageBase64);
        InsertAssetDiscovery(connectionKey, AssetAutoId, AssetCode, AssetName, ResturantCode, ResturantName, ResturantAddress, ResturantPost, UserId, LocationAutoId, AssetImage);

    }

    #region Help InitiateAssetChangeRequest
    const string strHelpInitiateAssetChangeRequest = strStyle + @"<div><b> InitiateAssetChangeRequest :</b> Return the MessageString and MessageId, in case of sucess MessageId value will be 1<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>AssetAutoId:</td><td>AssetAutoId</td>
</tr>
<tr>
<td>ResturantCode:</td><td>ResturantCode</td>
</tr><tr>
<td>AsmtId:</td><td>AsmtId</td>
</tr><tr>
<td>PostAutoId</td><td>PostAutoId</td>
</tr><tr>
<td>UserId:</td><td>UserId</td>
</tr>
</table></div>";
    #endregion Help strHelpInitiateAssetChangeRequest
    [WebMethod(Description = strJson + strHelpInitiateAssetChangeRequest)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InitiateAssetChangeRequest(string connectionKey, int AssetAutoID, string ResturantCode, string AsmtId, int PostAutoId, string UserId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_InsertAssetTransferRequest", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.AssetAutoId, SqlDbType.Int).Value = AssetAutoID;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ResturantCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtId;
            command.Parameters.Add(DL.Properties.Resources.PostAutoId, SqlDbType.Int).Value = PostAutoId;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = UserId;
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
