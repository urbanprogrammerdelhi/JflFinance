using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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

public partial class AssetManagement_MeghaOrderBooking : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearchMobile.Text != "")
        {
            var objSale = new BL.AssetManagement();
            DataSet ds = objSale.SearchCustomer(txtSearchMobile.Text, BaseLocationAutoID);
            if (ds.Tables[0].Rows[0]["MessgaeId"].ToString() == "1")
            {
                //       Readonly();
                txtName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["ClientAddress"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                //   ddlQuerytype.SelectedItem.Value = ds.Tables[0].Rows[0]["City"].ToString();
                lblCustMsg.Text = "Customer Exists";
                // hfMobile.Value = "1";
            }
            else
            {
                //hfMobile.Value = "0";
                //Readonlytrue();
                //Reset();
                //EnableDisableTimeSlots();
                //txtMobile.Text = txtSearchMobile.Text;
                lblCustMsg.Text = "Customer Not Exists";
                txtAddress.Text = "";
                txtName.Text = "";
                txtMobile.Text = "";

            }
        }
        else
        {
            lblCustMsg.Text = "Please Enter Customer Id";
        }


    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        var objSale = new BL.AssetManagement();
        DataSet ds = objSale.InsertOrderOnCall(txtSearchMobile.Text,txtName.Text,txtAddress.Text,txtMobile.Text,ddlQuerytype.SelectedItem.Value, BaseLocationAutoID,BaseUserID);
        lblMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();

        SendMail("mayank@v19tech.in");
        txtAddress.Text = "";
        txtName.Text = "";
        txtMobile.Text = "";
        txtSearchMobile.Text = "";
        lblCustMsg.Text = "";
    }
    public void SendMail(string txtMailTo)
    {
        string ActivateMail = "1";
        if (ActivateMail.ToString() == "1")
        {
            //string Address = string.Empty;
            //string addressline1 = string.Empty;
            //string addressline2 = string.Empty;
            //string serviceName = string.Empty;
            //string orderDate = string.Empty;
            //string orderTime = string.Empty;
            //string bookingDate = string.Empty;
            //string Price = string.Empty;
            //SqlParameter[] objParm = new SqlParameter[1];
            //objParm[0] = new SqlParameter(DL.Properties.Resources.WorkOrderNo, orderNo);
            //DataSet ds1 = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetOrderDetail", objParm);
            //Address = ds1.Tables[0].Rows[0]["OrderAddress"].ToString();
            //string[] lbladdress = Address.Split(',');
            //addressline1 = lbladdress[0] + "," + lbladdress[1] + "," + lbladdress[2];
            //addressline2 = lbladdress[3] + "," + lbladdress[4];
            //serviceName = ds1.Tables[0].Rows[0]["ServiceCategoryName"].ToString();
            //orderDate = ds1.Tables[0].Rows[0]["PreferredFromDate"].ToString();
            //orderTime = ds1.Tables[0].Rows[0]["PreferredFromTime"].ToString();
            //bookingDate = ds1.Tables[0].Rows[0]["ModifiedDate"].ToString();
            //Price = ds1.Tables[0].Rows[0]["Price"].ToString();
           string Body = string.Empty;
           string Subject = string.Empty;
                string Body1 = "Hello Sir,<br/><br/>We have  received a new request. Here are the details - <br/><br/> Customer Id -  "+txtSearchMobile.Text+"" ;
                string Body2 = "<br/><br/> Customer Name  -   " + txtName.Text + "<br/><br/> Customer Address -    " + txtAddress.Text + "<br/><br/> Customer Mobile -  " + txtMobile.Text + "<br/><br/> Query Type  -  " + ddlQuerytype.SelectedItem.Value + "";
                   string Body3 = "<br/><br/> Thank You !!";
               Body = Body1 + Body2 + Body3;
              //  Body = Body1;
               Subject = "MACES - " + ddlQuerytype.SelectedItem.Value + " "+ System.DateTime.Now.ToLocalTime();
            
            try
            {
                using (MailMessage mm = new MailMessage("maces.in102@gmail.com", txtMailTo))
                {
                    mm.Subject = Subject;
                    mm.Body = Body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("maecscustomercare@gmail.com", "Admin@123");
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
}