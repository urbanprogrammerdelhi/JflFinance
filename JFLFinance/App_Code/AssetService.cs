// ***********************************************************************
// <copyright file="AssetService.cs" company="Corefield Technologies Pvt. Ltd.">
//     Copyright (c) 2015 Corefield Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Services;
using DL;

/// <summary>
/// Class AssetService.
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[ScriptService]
public class AssetService : WebService
{
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
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceWorkOrderInsert(string connectionKey, string UserId, string Location, int ServiceAutoId, string PreferredFromDate, string PreferredToDate, string PreferredFromTime, string PreferredToTime, string MobileNo,
            string BuildingNo, string FloorNo, string Locality, string Landmark, string City, string District, string State, string PIN, string ModifiedBy, string ModifiedDate, string Lat, string Long)
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
            command.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = MobileNo;
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
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeviceUserRegistration(string connectionKey, string UserId, string FirstName, string LastName, string Password, string EmailId, string MobileNo)
    {
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
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
            command.Parameters.Add("@EmailId", SqlDbType.NVarChar).Value = EmailId;
            command.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = MobileNo;
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

    /// <summary>
    /// Gets the state detail.
    /// </summary>
    /// <param name="connectionKey">The connection key.</param>
    /// <param name="userId">The user identifier.</param>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetStateDetail(string connectionKey, string userId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udpmst_StateDetail_get", scn)
            {
                CommandType = CommandType.StoredProcedure
            };
            //command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            var objConvertDatatableToJson = new ConvertDatatableToJson();
            string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(jsonString);
        }
    }

    /// <summary>
    /// Gets the state district.
    /// </summary>
    /// <param name="connectionKey">The connection key.</param>
    /// <param name="userId">The user identifier.</param>
    /// <param name="stateId">The state identifier.</param>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetStateDistrict(string connectionKey, string userId, string stateId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("Udpmst_districtdetail_get", scn)
            {
                CommandType = CommandType.StoredProcedure
            };
            //command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.StateId, SqlDbType.NVarChar).Value = stateId;
            
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            var objConvertDatatableToJson = new ConvertDatatableToJson();
            string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(jsonString);
        }
    }

    /// <summary>
    /// Gets all state and district.
    /// </summary>
    /// <param name="connectionKey">The connection key.</param>
    /// <param name="userId">The user identifier.</param>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAllStateAndDistrict(string connectionKey, string userId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("UdpMstStateDistrictGet", scn)
            {
                CommandType = CommandType.StoredProcedure
            };
            //command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            var objConvertDatatableToJson = new ConvertDatatableToJson();
            string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(jsonString);
        }
    }
}