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
/// Summary description for QSRQualityChecker
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class QSRQualityChecker : System.Web.Services.WebService {

    const string strStyle = @"<style>table {border-collapse: collapse;} table, th, td {border: 1px solid silver;} div{border: 1px solid silver;}</style>";
    const string strJson = @"<div><b>Return Type: Json</b></div>";

    protected DataSet QualityLoginDs(string connectionKey, string UserId, string Password)
    {
        bool PasswordMatchStatus = false;
        string strkey = GetDecryptkey(connectionKey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetQualityPassword", scn);
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
                    SqlCommand command = new SqlCommand("udp_QualityLogin", scn);
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
    #region QualityLogin Parameter Info
    const string QualityLoginDesc = strStyle + @"<div><b> QualityLogin :</b>  For Validating the Quality Checker Approval valid User Id and Password.<br/>
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
    [WebMethod(Description = strJson + QualityLoginDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void QualityLogin(string connectionKey, string UserId, string Password)
    {
        var ds = new DataSet();
        ds = QualityLoginDs(connectionKey, UserId, Password);
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

    #region GetAllTicketsDetails
    const string strHelpGetAllTicketsDetails = strStyle + @"<div><b> GetAllTicketsDetails:</b> Return all the tickets details.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in QualityID</td>
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
            command = new SqlCommand("udp_GetAllTicketDetailsQuality", scn);
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
    const string strHelpGetTicketsDetail = strStyle + @"<div><b> GetTicketsDetail:</b> Return particular ticket detail on the basis of TicketNo<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in QualityID</td>
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
    public void GetTicketDetail(string connectionKey, string userId, string TicketNo, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetTicketDetailQuality", scn);
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
                //var objConvertDatatableToJson = new ConvertDatatableToJson();
                //string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
                //Context.Response.Clear();
                //Context.Response.ContentType = "application/json";
                //Context.Response.Write(jsonString);
                  if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
                {
                    //string ImageBase64 = Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])));
                    if (ds.Tables[0].Rows[0]["WOImage"] != DBNull.Value)
                    {
                        ImageBase64 = Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])));
                    }
                    else
                    {
                        ImageBase64 = null;
                    }
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

    #region UpdateTicketStatus
    const string strHelpUpdateTicketStatus = strStyle + @"<div><b> UpdateTicketStatus:</b> Update ticket status to closed on the basis of Ticket No.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<td>userId:</td><td>Loged in QualityID</td>
</tr>
<tr>
<td>TicketNo:</td><td>Ticket No. whose status needs to be changed.</td>

</tr>
<tr>
<td>Status:</td><td>Ticket Status.</td>

</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>

</table></div>";
    #endregion
    [WebMethod(Description = strJson + strHelpUpdateTicketStatus)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateTicketStatus(string connectionKey, string userId, string TicketNo, string Status, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_UpdateTicketStatusQuality", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.TicketNo, SqlDbType.NVarChar).Value = TicketNo;
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = Status;
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

//    #region GetDailyTaskDetail
//    const string strHelpGetDailyTaskDetail = strStyle + @"<div><b> GetDailyTaskDetail:</b> Return all the tasks on the basis of LocationAutoId,ClientCode,AsmtId,PostAutoId.<br/>
//OR MessageString in case of error<br/>
//<b>Parameter Information :</b><br/> 
//<table>
//<tr>
//<td>ConnectionKey:</td><td>Database Connection Key</td>
//</tr><tr>
//<td>LocationAutoId:</td><td>LocationAutoId (int)</td>
//</tr>
//<tr>
//<td>ClientCode:</td><td>Client Code</td>
//</tr>
//<tr>
//<td>AsmtId:</td><td>AsmtId</td>
//
//</tr>
//<tr>
//<td>PostAutoID:</td><td>PostAutoId (int)</td>
//</tr>
//<tr>
//<td>EmployeeNumber:</td><td>Loged in User Employee Number</td>
//</tr>
//</table></div>";
//    #endregion
//    [WebMethod(Description = strJson + strHelpGetDailyTaskDetail)]
//    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
//    public void GetDailyTaskDetail(string connectionKey, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoID, string EmployeeNumber)
//    {
//        var objCon = new ConnectionString();
//        var connect = objCon.ConnectionStringGet(connectionKey);
//        using (var scn = new SqlConnection(connect))
//        {
//            SqlCommand command;
//            command = new SqlCommand("udp_GetDailyTaskDetail", scn);
//            command.CommandType = CommandType.StoredProcedure;
//            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = LocationAutoId;
//            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
//            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtId;
//            command.Parameters.Add(DL.Properties.Resources.PostAutoId, SqlDbType.NVarChar).Value = PostAutoID;
//            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = EmployeeNumber;
//            scn.Open();
//            var adapter = new SqlDataAdapter(command);
//            var ds = new DataSet();
//            adapter.Fill(ds);

//            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
//            {
//                var objConvertDatatableToJson = new ConvertDatatableToJson();
//                string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

//                Context.Response.Clear();
//                Context.Response.ContentType = "application/json";
//                Context.Response.Write(jsonString);
//            }
//            else
//            {
//                Context.Response.Clear();
//                Context.Response.ContentType = "application/json";
//                Context.Response.Write("[{'Message':'Invalid Post'}]");
//            }
//        }
//    }
    #region GetClientCode
    const string strHelpGetClientCode = strStyle + @"<div><b> GetClientCode:</b> Get All the client Code.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<td>userId:</td><td>Loged in QualityID</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + strHelpGetClientCode)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetClientCode(string connectionKey, string userId,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetClientCode", scn);
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

    #region GetSiteId
    const string strHelpGetSiteId = strStyle + @"<div><b> GetSiteId:</b> Get all the Site ID on the basis of ClientCode.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>userId:</td><td>Loged in QualityID</td>
</tr>
<tr>
<td>ClientCode:</td><td>ALL for showing all Client Code else ClientCode.</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + strHelpGetSiteId)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetSiteId(string connectionKey, string userId, string ClientCode, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetSiteId", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
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

    #region GetPostId
    const string strHelpGetPostId = strStyle + @"<div><b> GetPostId:</b> Get all the Post ID on the basis of ClientCode and Site Id.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>userId:</td><td>Loged in QualityID</td>
</tr>
<tr>
<td>ClientCode:</td><td>ALL for showing all Client Code else  ClientCode.</td>
</tr>
<tr>
<td>Site Id:</td><td>ALL for showing all Site Id else Site ID.</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + strHelpGetPostId)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPostId(string connectionKey, string userId, string ClientCode, string SiteId, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetPostId", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = SiteId;
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

    #region GetPerformerSiteDetails
    const string strHelpGetPerformerSiteDetails = strStyle + @"<div><b> GetPerformerSiteDetails:</b> Get performer site details on the basis of clientcode,site id and post id.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>userId:</td><td>Loged in QualityID</td>
</tr>
<tr>
<td>ClientCode:</td><td>ClientCode.</td>
</tr>
<tr>
<td>SiteId:</td><td>Site ID.</td>
</tr>
<tr>
<td>PostId:</td><td>Post ID.</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + strHelpGetPerformerSiteDetails)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPerformerSiteDetails(string connectionKey, string userId, string ClientCode, string SiteId, string PostId, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetPerformerSiteDetails", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = SiteId;
            command.Parameters.Add(DL.Properties.Resources.PostAutoId, SqlDbType.NVarChar).Value = PostId;
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


    #region GetDailyTaskUpdate
    const string strHelpGetDailyTaskUpdate = strStyle + @"<div><b> GetDailyTaskUpdate:</b> Get all the tasks detail on the basis of TaskListID .<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr>
<tr>
<td>userId:</td><td>Loged in QualityID</td>
</tr>
<tr>
<td>TaskListID:</td><td>TaskListID whose tasks is to show.</td>
</tr>
<tr>
<td>SiteId:</td><td>Site ID.</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>

</table></div>";
    #endregion
    [WebMethod(Description = strJson + strHelpGetDailyTaskUpdate)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetDailyTaskUpdate(string connectionKey, string userId, string TaskListID, string SiteId,int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetDailyTaskUpdate", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.AssetServiceTypeAutoId, SqlDbType.NVarChar).Value = TaskListID;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = SiteId;
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
    public void UpdateDailyTaskStatus(string connectionKey, string userId, string TaskName, string Status, int LocationAutoID, string ChecklistText)
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
            command = new SqlCommand("udp_UpdateDailyTaskStatusQuality", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
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

//    #region UpdateAllTicketStatus
//    const string strHelpUpdateAllTicketStatus = strStyle + @"<div><b> UpdateAllTicketStatus:</b> Return all the Pending Tasks n Tickets.<br/>
//OR MessageString in case of error<br/>
//
//<b>Parameter Information :</b><br/> 
//<table>
//<tr>
//<td>ConnectionKey:</td><td>Database Connection Key</td>
//</tr><tr>
//<td>UserID:</td><td>Loged in MgmtID</td>
//</tr>
//<tr>
//<td>TicketNo:</td><td>Ticket No.</td>
//</tr>
//<tr>
//<td>Status:</td><td>Ticket Status.</td>
//</tr>
//</table></div>";
//    #endregion
//    [WebMethod(Description = strJson + strHelpUpdateAllTicketStatus)]
//    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
//    public void UpdateAllTicketStatus(string connectionKey, string userId, string TicketNo, string Status)
//    {
//        var objCon = new ConnectionString();
//        var connect = objCon.ConnectionStringGet(connectionKey);
//        using (var scn = new SqlConnection(connect))
//        {
//            SqlCommand command;
//            command = new SqlCommand("udp_UpdateAllTicketStatusQuality", scn);
//            command.CommandType = CommandType.StoredProcedure;
//            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
//            command.Parameters.Add(DL.Properties.Resources.TicketNo, SqlDbType.NVarChar).Value = TicketNo;
//            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = Status;
//            scn.Open();
//            var adapter = new SqlDataAdapter(command);
//            var ds = new DataSet();
//            adapter.Fill(ds);

//            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
//            {
//                var objConvertDatatableToJson = new ConvertDatatableToJson();
//                string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

//                Context.Response.Clear();
//                Context.Response.ContentType = "application/json";
//                Context.Response.Write(jsonString);
//            }
//            else
//            {
//                Context.Response.Clear();
//                Context.Response.ContentType = "application/json";
//                Context.Response.Write("[{'Message':'Invalid Post'}]");
//            }
//        }
//    }
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

    public void UploadTaskImage(string connectionKey, string taskName, byte[] taskImage, string UserId, int LocationAutoID)
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
         //   command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = UserId;
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
    public void UploadTaskImageBase64(string connectionKey, string taskName, string taskImageBase64, string UserId,int LocationAutoID)
    {
        byte[] taskImage = System.Convert.FromBase64String(taskImageBase64);
        UploadTaskImage(connectionKey, taskName, taskImage, UserId, LocationAutoID);

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
    public void GetTaskImage(string connectionKey, string userId, string CheckListItem, int LocationAutoID)
    {
        //var objCon = new ConnectionString();
        //var connect = objCon.ConnectionStringGet(connectionKey);
        //using (var scn = new SqlConnection(connect))
        //{
        //    SqlCommand command;
        //    command = new SqlCommand("udp_GetTaskImageQuality", scn);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
        //    command.Parameters.Add(DL.Properties.Resources.ChecklistItem, SqlDbType.NVarChar).Value = CheckListItem;
        //    command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;
        //    scn.Open();
        //    var adapter = new SqlDataAdapter(command);
        //    var ds = new DataSet();
        //    adapter.Fill(ds);
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

    #region GetUnSchedulledTicketsDetails
    const string strHelpUnschedulledAllTicketsDetails = strStyle + @"<div><b> GetUnSchedulledTicketsDetails:</b> Return all the tickets details which are unschedulled.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in QualityID</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help GetAllTicketsDetails
    [WebMethod(Description = strJson + strHelpUnschedulledAllTicketsDetails)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetUnSchedulledTicketsDetails(string connectionKey, string userId, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetAllTicketDetailsQuality", scn);
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
    public void TicketGeneration(string connectionKey, string userId, string ClientCode, string ClientName,
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
      string SiteId, string SiteName, string DateOfCreation, string SummaryOfIssue, string DescriptionOfIssue, string Severity, string CommercialValue, string TicketImageBase64, int LocationAutoID, int AssetCategoryAutoId, int AssetSubCategoryAutoId, int AssetAutoId)
    {
        byte[] TicketImage = System.Convert.FromBase64String(TicketImageBase64);
        TicketGeneration(connectionKey, userId, ClientCode, ClientName, SiteId, SiteName,
         DateOfCreation, SummaryOfIssue, DescriptionOfIssue, Severity, CommercialValue, TicketImage, LocationAutoID, AssetCategoryAutoId, AssetSubCategoryAutoId, AssetAutoId);

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

}
