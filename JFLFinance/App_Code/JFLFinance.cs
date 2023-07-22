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
/// Summary description for JFLFinance
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class JFLFinance : System.Web.Services.WebService {
    const string strStyle = @"<style>table {border-collapse: collapse;} table, th, td {border: 1px solid silver;} div{border: 1px solid silver;}</style>";
    const string strJson = @"<div><b>Return Type: Json</b></div>";

    protected DataSet AuditorLoginDs(string connectionKey, string UserId, string Password)
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
    #region AuditorLogin Parameter Info
    const string AuditorLoginDesc = strStyle + @"<div><b> AuditorLogin :</b>  For Validating the Auditor valid User Id and Password.<br/>
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
    [WebMethod(Description = strJson + AuditorLoginDesc)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AuditorLogin(string connectionKey, string UserId, string Password)
    {
        var ds = new DataSet();
        ds = AuditorLoginDs(connectionKey, UserId, Password);
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

    #region AssetAudit
    const string strHelpAssetAudit = strStyle + @"<div><b> AssetAudit:</b> Get Asset Mapping Details on the basis of QR Code.<br/>
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
    #endregion Help strHelpAssetAudit
    [WebMethod(Description = strJson + strHelpAssetAudit)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AssetAudit(string connectionKey, string AssetQRValue, int LocationAutoID)
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
    
    #region InsertAssetAudit
    const string strHelpInsertAssetAudit = strStyle + @"<div><b> InsertAssetAudit:</b> Return the MessageString and MessageId, in case of sucess MessageId value will be 1<br/>
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
    #endregion Help InsertAssetDiscovery
    public void InsertAssetAudit(string connectionKey, int AssetAutoId, string AssetCode, string AssetName, string ResturantCode, string ResturantName, string ResturantAddress, string ResturantPost, string UserId, int LocationAutoId, byte[] AssetImage ,int AssetCategoryAutoId, string AssetCategoryName, int AssetSubCategoryAutoId, string AssetSubCategoryName)
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

            command.Parameters.Add(DL.Properties.Resources.AssetCategoryAutoId, SqlDbType.Int).Value = AssetCategoryAutoId;
            command.Parameters.Add(DL.Properties.Resources.AssetCategoryName, SqlDbType.NVarChar).Value = AssetCategoryName;
            command.Parameters.Add(DL.Properties.Resources.AssetSubCategoryAutoId, SqlDbType.Int).Value = AssetSubCategoryAutoId;
            command.Parameters.Add(DL.Properties.Resources.AssetSubCategoryName, SqlDbType.NVarChar).Value = AssetSubCategoryName;
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
    [WebMethod(Description = strJson + strHelpInsertAssetAudit)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertAssetAuditBase64(string connectionKey, int AssetAutoId, string AssetCode, string AssetName, string ResturantCode, string ResturantName, string ResturantAddress, string ResturantPost, string UserId, int LocationAutoId, string AssetImageBase64, int AssetCategoryAutoId, string AssetCategoryName, int AssetSubCategoryAutoId, string AssetSubCategoryName)
    {
        byte[] AssetImage = System.Convert.FromBase64String(AssetImageBase64);
        InsertAssetAudit(connectionKey, AssetAutoId, AssetCode, AssetName, ResturantCode, ResturantName, ResturantAddress, ResturantPost, UserId, LocationAutoId, AssetImage, AssetCategoryAutoId, AssetCategoryName, AssetSubCategoryAutoId, AssetSubCategoryName);
    }

    #region AssetMapping
    const string strHelpAssetMapping = strStyle + @"<div><b> AssetMapping:</b> Get Asset Mapping Details on the basis of QR Code.<br/>
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
    #endregion Help strHelpAssetMapping
    [WebMethod(Description = strJson + strHelpAssetMapping)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AssetMapping(string connectionKey, string AssetQRValue, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("GetAssetTaggingDetailUnMapped", scn);
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

    #region InsertAssetMapping
    const string strHelpInsertAssetMapping = strStyle + @"<div><b> InsertAssetMapping:</b> Return the MessageString and MessageId, in case of sucess MessageId value will be 1<br/>
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
    #endregion Help InsertAssetDiscovery
    [WebMethod(Description = strJson + strHelpInsertAssetAudit)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertAssetMapping(string connectionKey, int AssetAutoId, string AssetCode, string AssetName, string ResturantCode, string ResturantName, string ResturantAddress, string ResturantPost, string UserId, int LocationAutoId,int AssetCategoryAutoId, string AssetCategoryName, int AssetSubCategoryAutoId, string AssetSubCategoryName)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("Udp_InsertAssetMapping", scn);
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

            command.Parameters.Add(DL.Properties.Resources.AssetCategoryAutoId, SqlDbType.Int).Value = AssetCategoryAutoId;
            command.Parameters.Add(DL.Properties.Resources.AssetCategoryName, SqlDbType.NVarChar).Value = AssetCategoryName;
            command.Parameters.Add(DL.Properties.Resources.AssetSubCategoryAutoId, SqlDbType.Int).Value = AssetSubCategoryAutoId;
            command.Parameters.Add(DL.Properties.Resources.AssetSubCategoryName, SqlDbType.NVarChar).Value = AssetSubCategoryName;
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