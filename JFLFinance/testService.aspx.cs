using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;


public partial class testService : System.Web.UI.Page
{
    const string uploadfolder = @"~\\DocumentUpload\\";

    static string filepath = "";
    static string DBfilepath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }
    protected void btnUploaddocument_Click(object sender, EventArgs e)
    {
        try
        {
            string resultFilePath = "";
            string fileName = Path.GetFileName(afuDocumentDetailPurchase.FileName);
            if (afuDocumentDetailPurchase.HasFile)
            {
                string extension = Path.GetExtension(afuDocumentDetailPurchase.FileName);
                string uniqueid = Guid.NewGuid().ToString();
                filepath = uploadfolder + uniqueid + extension;
                DBfilepath = uniqueid + extension;
                resultFilePath = MapPath(filepath);
                afuDocumentDetailPurchase.SaveAs(resultFilePath);
               byte[] imgdata = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(filepath));
                AttendanceService AS = new AttendanceService();
                AS.DeviceEmpAttendanceInsert("Demo", "", "", "173", "E000048", "IN", DateTime.Today.ToString("dd-MMM-yyyy HH:mm"), "", "", "", imgdata);
                //SaveData(imgdata);

            }
            else
            {
                Response.Write("<script>alert(" + Resources.Resource.SelectDocument + ")</script>");
            }


        }
        catch (Exception ex)
        { }
  
    }


    protected void SaveData(byte[] employeeImage)
    {
        var objCon = new DL.ConnectionString();
        string connectionKey = "Demo";
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();


        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsert", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = "";
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = "connectionKey";
            command.Parameters.Add(DL.Properties.Resources.Post, SqlDbType.NVarChar).Value = "173";
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = "E000048";
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = "IN";
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DateTime.Today.ToString("dd-MMM-yyyy"));
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = "";
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = "";
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = "";
            command.Parameters.Add(DL.Properties.Resources.EmployeeImage, SqlDbType.Image).Value = (object)employeeImage;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Response.Write(jsonString);
    }
   
    

}

  
       