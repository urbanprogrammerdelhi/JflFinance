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
/// Summary description for QSRMgmt
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class QSRMgmt : System.Web.Services.WebService {

    const string strStyle = @"<style>table {border-collapse: collapse;} table, th, td {border: 1px solid silver;} div{border: 1px solid silver;}</style>";
    const string strJson = @"<div><b>Return Type: Json</b></div>";

    protected DataSet MgmtLoginDs(string connectionKey, string UserId, string Password)
    {
        bool PasswordMatchStatus = false;
        string strkey = GetDecryptkey(connectionKey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetMgmtPassword", scn);
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
                    SqlCommand command = new SqlCommand("udp_MgmtLogin", scn);
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
    #region MgmtLogin Parameter Info
    const string MgmtLoginDesc = strStyle + @"<div><b> MgmtLogin :</b>  For Validating the Management Approval valid User Id and Password.<br/>
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
    [WebMethod(Description = strJson + MgmtLoginDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void MgmtLogin(string connectionKey, string UserId, string Password)
    {
        var ds = new DataSet();
        ds = MgmtLoginDs(connectionKey, UserId, Password);
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
<td>UserID:</td><td>Loged in MgmtID</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion Help GetAllTicketsDetails
    [WebMethod(Description = strJson + strHelpGetAllTicketsDetails)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAllTicketsDetails(string connectionKey, string userId, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetAllTicketDetailsMgmt", scn);
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
<td>UserID:</td><td>Loged in MgmtID</td>
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
            command = new SqlCommand("udp_GetTicketDetailMgmt", scn);
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
                //var objConvertDatatableToJson = new ConvertDatatableToJson();
                //string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

                //Context.Response.Clear();
                //Context.Response.ContentType = "application/json";
                //Context.Response.Write(jsonString);
               if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
                {
                    string ImageBase64 = Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])));
                    Context.Response.Write("[{'Message':'Success','AssetWONo':'" + ds.Tables[0].Rows[0]["AssetWONo"].ToString() + "','WOstatus':'" + ds.Tables[0].Rows[0]["WOstatus"].ToString() + "','ClientCode':'" + ds.Tables[0].Rows[0]["ClientCode"].ToString() + "','ClientName':'" + ds.Tables[0].Rows[0]["ClientName"].ToString() + "','AsmtBillingId':'" + ds.Tables[0].Rows[0]["AsmtBillingId"].ToString() + "','AsmtName':'" + ds.Tables[0].Rows[0]["AsmtName"].ToString() + "','DateOfCreation':'" + ds.Tables[0].Rows[0]["DateOfCreation"].ToString() + "','SummaryOfIssues':'" + ds.Tables[0].Rows[0]["SummaryOfIssues"].ToString() + "','DescOfIssues':'" + ds.Tables[0].Rows[0]["DescOfIssues"].ToString() + "','Severity':'" + ds.Tables[0].Rows[0]["Severity"].ToString() + "','CommercialValue':'" + ds.Tables[0].Rows[0]["CommercialValue"].ToString() + "','WOImage':'" + ImageBase64 + "'}]");
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
<td>userId:</td><td>Loged in MgmtID</td>
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
            command = new SqlCommand("udp_UpdateTicketStatus", scn);
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

    #region GetPendingTaskLists
    const string strHelpGetPendingTaskLists = strStyle + @"<div><b> GetPendingTaskLists:</b> Return all the Pending Tasks n Tickets.<br/>
OR MessageString in case of error<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>ConnectionKey:</td><td>Database Connection Key</td>
</tr><tr>
<td>UserID:</td><td>Loged in MgmtID</td>
</tr>
<tr>
<td>LocationAutoId:</td><td>LocationAutoId (Integer)</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + strHelpGetPendingTaskLists)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPendingTaskLists(string connectionKey, string userId, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetPendingTaskLists", scn);
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

//    #region UpdateAllTicketStatus
//    const string strHelpUpdateAllTicketStatus = strStyle + @"<div><b> UpdateAllTicketStatus:</b> Return all the Pending Tasks n Tickets.<br/>
//OR MessageString in case of error<br/>
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
//    public void UpdateAllTicketStatus(string connectionKey, string userId,string TicketNo,string Status)
//    {
//        var objCon = new ConnectionString();
//        var connect = objCon.ConnectionStringGet(connectionKey);
//        using (var scn = new SqlConnection(connect))
//        {
//            SqlCommand command;
//            command = new SqlCommand("udp_UpdateAllTicketStatusMgmt", scn);
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
    #region InsertNFCAttendance
    const string strInsertNFCAttendance = strStyle + @"<div><b> InsertNFCAttendance:</b> Insert NFC Attendance on the basis of Card ID.<br/>
<b>Parameter Information :</b><br/> 
<table>
<tr>
<td>CardID:</td><td>NFC Card ID</td>
</tr>
</table></div>";
    #endregion
    [WebMethod(Description = strJson + strInsertNFCAttendance)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertNFCAttendance(string CardID)
    {
        string connectionKey = "QSR";
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("InsertNFCAttendance", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = CardID;
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
                Context.Response.Write("[{'Message':'Invalid CardId'}]");
            }
        }
    }
}
