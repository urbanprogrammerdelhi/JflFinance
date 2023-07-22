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

/// <summary>
/// Summary description for FWCustomerPortal
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class FWCustomerPortal : System.Web.Services.WebService 
{
    [WebMethod]
  
    public DataSet CustomerLogin(string connectionKey, string UserID, string Password)
    {
        bool PasswordMatchStatus = false;
        string strkey = GetDecryptkey(connectionKey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetCustomerPwd", scn);
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
                PasswordMatchStatus = objblUserManagement.DoesPasswordMatch(ds.Tables[0].Rows[0]["password"].ToString(), UserID + Password, true, strkey);
                if (PasswordMatchStatus == true)
                {

                }

                var ds1 = new DataSet();
                var objCon1 = new ConnectionString();
                var connect1 = objCon1.ConnectionStringGet(connectionKey);

                using (var scn = new SqlConnection(connect1))
                {
                    SqlCommand command = new SqlCommand("udp_CustomerLogin", scn);
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
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }

    [WebMethod]
    public DataSet GetCustomerProfile(string connectionKey, string UserID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetCustomerProfile", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }

    [WebMethod]
    public DataSet GetContractDetail(string connectionKey, string UserID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetContractDetailsCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }

    [WebMethod]
    public DataSet GetSoDetail(string connectionKey, string UserID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetSoDetailsCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSiteDetail(string connectionKey, string UserID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetSiteDetailsCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    [WebMethod]
    public DataSet GetPostDetail(string connectionKey, string UserID,string AsmtId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetPostDetailsCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
            command.Parameters.Add("@AsmtId", SqlDbType.NVarChar).Value = AsmtId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

        }
        return ds;
    }
    [WebMethod]
    public DataSet GetAmendNo(string connectionKey, string ContractNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetContractAmendnoCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContractNumber", SqlDbType.NVarChar).Value = ContractNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetContractDetailByAmendNo(string connectionKey, string ContractNo, string AmendmentNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetContractDetailByAmendnoCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContractNumber", SqlDbType.NVarChar).Value = ContractNo;
            command.Parameters.Add("@AmendmentNo", SqlDbType.NVarChar).Value = AmendmentNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetDownloadFile(string connectionKey, string ContractNo, string AmendmentNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpDocumentDownload", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ContractNumber", SqlDbType.NVarChar).Value = ContractNo;
            command.Parameters.Add("@AmendmentNo", SqlDbType.NVarChar).Value = AmendmentNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoDetailByAmendNo(string connectionKey, string SoNo, string AmendmentNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetSoDetailByAmendnoCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@AmendmentNo", SqlDbType.NVarChar).Value = AmendmentNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoAmendNo(string connectionKey, string SoNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetSOAmendnoCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoServiceDetail(string connectionKey, string SoNo, string AmendmentNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetSoServiceDetailCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@AmendmentNo", SqlDbType.NVarChar).Value = AmendmentNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoEquipmentDetail(string connectionKey, string SoNo, string AmendmentNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetEquipmentDetailCP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@AmendmentNo", SqlDbType.NVarChar).Value = AmendmentNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoSkillLanguage(string connectionKey, string SoNo, string AmendmentNo,string SoLineNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpMstSale_SkillsLanguage_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@SOAmendNo", SqlDbType.NVarChar).Value = AmendmentNo;
            command.Parameters.Add("@SOLineNo", SqlDbType.NVarChar).Value = SoLineNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoSkillQualification(string connectionKey, string SoNo, string AmendmentNo, string SoLineNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpMstSale_SkillsQualification_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@SOAmendNo", SqlDbType.NVarChar).Value = AmendmentNo;
            command.Parameters.Add("@SOLineNo", SqlDbType.NVarChar).Value = SoLineNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoSkillTraining(string connectionKey, string SoNo, string AmendmentNo, string SoLineNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpMstSale_SkillsTraining_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@SOAmendNo", SqlDbType.NVarChar).Value = AmendmentNo;
            command.Parameters.Add("@SOLineNo", SqlDbType.NVarChar).Value = SoLineNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoSkillOther(string connectionKey, string SoNo, string AmendmentNo, string SoLineNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpMstSale_SkillsOther_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@SOAmendNo", SqlDbType.NVarChar).Value = AmendmentNo;
            command.Parameters.Add("@SOLineNo", SqlDbType.NVarChar).Value = SoLineNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet GetSoPattern(string connectionKey,string locationAutoId, string SoNo, string AmendmentNo, string SoLineNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpMstSales_SODeptShift_Get", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LocationAutoId", SqlDbType.NVarChar).Value = locationAutoId;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@SoAmendNo", SqlDbType.NVarChar).Value = AmendmentNo;
            command.Parameters.Add("@SoLineNo", SqlDbType.NVarChar).Value = SoLineNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet DaysInMonthSysParamGet(string connectionKey, string locationAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpSale_DaysInMonthSysParamGet", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Locationautoid", SqlDbType.NVarChar).Value = locationAutoId;
             scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
    [WebMethod]
    public DataSet SellingDaysInMonthGet(string connectionKey, string SoLineNo,string locationAutoId, string SoNo, string AmendmentNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udpSale_SOServiceDetails_GetSellingdaysInMonth", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SoLineNo", SqlDbType.NVarChar).Value = SoLineNo;
            command.Parameters.Add("@LocationAutoID", SqlDbType.NVarChar).Value = locationAutoId;
            command.Parameters.Add("@SoNo", SqlDbType.NVarChar).Value = SoNo;
            command.Parameters.Add("@SoAmendNo", SqlDbType.NVarChar).Value = AmendmentNo;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        return ds;
    }
}
