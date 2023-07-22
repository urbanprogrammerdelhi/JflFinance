using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Transactions_InstaOrderGeneration : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {if(!IsPostBack)
    {
        Readonly();
        FillCategory();
        FillTimeSlot();
        TimeZoneInfo timeZoneInfo1;
        DateTime dateTime1;
        timeZoneInfo1 = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        dateTime1 = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo1);
        txtDate.Text= dateTime1.ToString("dd-MMM-yyyy");
        EnableDisableTimeSlots();
        NetPrice();

    }
    }
    protected void ddlservice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlservice.SelectedItem.Value == "1")
        {
            FillSubCategory();
        }
        else
        {
            FillService(ddlservice);
            PlumbingSubservice.Visible = false;
            ddlUnit.SelectedValue = "1";
        }

    }
    protected void ddlPlumbingSubService_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillService(ddlPlumbingSubService);
    }
    protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        NetPrice();
    }
    private void FillTimeSlot()
    {
      rblTimeSlot.Items.Clear();   
        var objSale = new BL.Sales();
        DataSet ds = objSale.GetTimeSlotDetail();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            rblTimeSlot.DataSource = ds.Tables[0];
            rblTimeSlot.DataTextField = "TimeSlot";
            rblTimeSlot.DataValueField = "TimeSlot";
            rblTimeSlot.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            rblTimeSlot.Items.Add(li);
            rblTimeSlot.Items.Add(li);
        }
    }
    private void FillCategory()
    {
        ddlservice.Items.Clear();
        var objSale = new BL.Sales();
        DataSet ds = objSale.GetCategory();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlservice.DataSource = ds.Tables[0];
            ddlservice.DataTextField = "ServiceCategoryDesc";
            ddlservice.DataValueField = "ServiceCategoryAutoId";
            ddlservice.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlservice.Items.Add(li);
            ddlservice.Items.Add(li);
        }
        if(ddlservice.SelectedItem.Value=="1")
        {
            FillSubCategory();
        }
        else
        {
            FillService(ddlservice);
            PlumbingSubservice.Visible = false;
        }
    }
    private void FillSubCategory()
    {
        PlumbingSubservice.Visible = true;
        ddlPlumbingSubService.Items.Clear();
        var objSale = new BL.Sales();
        DataSet ds = objSale.GetSubCategory();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlPlumbingSubService.DataSource = ds.Tables[0];
            ddlPlumbingSubService.DataTextField = "ServiceCategoryDesc";
            ddlPlumbingSubService.DataValueField = "ServiceCategoryAutoId";
            ddlPlumbingSubService.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlPlumbingSubService.Items.Add(li);
            ddlPlumbingSubService.Items.Add(li);
        }
        FillService(ddlPlumbingSubService);
    }
    private void FillService(DropDownList ddlPlumbingSubService)
    {
        ddlSubService.Items.Clear();
        var objSale = new BL.Sales();
        DataSet ds = objSale.GetService(ddlPlumbingSubService.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSubService.DataSource = ds.Tables[0];
            ddlSubService.DataTextField = "ServiceCategoryDesc";
            ddlSubService.DataValueField = "ServiceAutoId";
            ddlSubService.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlSubService.Items.Add(li);
            ddlSubService.Items.Add(li);
        }
        ddlUnit.SelectedValue = "1";
        FillRate(ddlSubService);
    }

    private void FillRate(DropDownList ddlSubService)
    {
      
        var objSale = new BL.Sales();
        DataSet ds = objSale.GetRate(ddlSubService.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
           txtRate.Text=ds.Tables[0].Rows[0]["RateCard"].ToString();
        }
        NetPrice();
    }
    public void NetPrice()
    {
        if ((txtRate.Text != "On Inspection") && (txtRate.Text != "As per the selected product"))
        {
            int Price = 0;
            Price = Convert.ToInt32(ddlUnit.SelectedValue) * Convert.ToInt32(txtRate.Text);
            lblPrice.Text = Convert.ToString(Price) + ".00";
            //   Price = Convert.ToDouble(ddlUnit.SelectedValue) * Convert.ToDouble(txtRate);
        }
        else
        {
            lblPrice.Text = txtRate.Text;
        }
    }
    public void EnableDisableTimeSlots()
    {
        TimeZoneInfo timeZoneInfo1;
        DateTime dateTime1;
        timeZoneInfo1 = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        dateTime1 = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo1);
        var date = dateTime1.ToString("dd-MMM-yyyy");
        if (Convert.ToDateTime( date) > Convert.ToDateTime( txtDate.Text))
        {
            rblTimeSlot.Items[0].Enabled = false;
            rblTimeSlot.Items[1].Enabled = false;
            rblTimeSlot.Items[2].Enabled = false;
            rblTimeSlot.Items[3].Enabled = false;
            rblTimeSlot.ClearSelection();
        }
        else if (date == txtDate.Text)
        {
            var ServerTime = dateTime1.AddMinutes(120).ToString("hh:mm tt");
            string[] CurrentTime1 = ServerTime.Split(':');
            string CurrentTime = CurrentTime1[0];
            string[] timeformat1 = CurrentTime1[1].Split(' ');
            string Timeformat = timeformat1[1];
            rblTimeSlot.Items[0].Enabled = true;
            rblTimeSlot.Items[1].Enabled = true;
            rblTimeSlot.Items[2].Enabled = true;
            rblTimeSlot.Items[3].Enabled = true;

            if (Timeformat == "AM")
            {
                if ((Convert.ToInt32(CurrentTime) >= 9) && (Convert.ToInt32(CurrentTime) < 12))
                {
                    rblTimeSlot.Items[0].Enabled = false;
                }
                else
                {
                    rblTimeSlot.Items[0].Enabled = true;
                    rblTimeSlot.Items[1].Enabled = true;
                    rblTimeSlot.Items[2].Enabled = true;
                    rblTimeSlot.Items[3].Enabled = true;
                }
            }
            else
            {
                if ((Convert.ToInt32(CurrentTime) == 1))
                {
                    rblTimeSlot.Items[0].Enabled = false;
                    rblTimeSlot.Items[1].Enabled = false;
                }
                else if ((Convert.ToInt32(CurrentTime) >= 2) && (Convert.ToInt32(CurrentTime) < 4))
                {
                    rblTimeSlot.Items[0].Enabled = false;
                    rblTimeSlot.Items[1].Enabled = false;
                    rblTimeSlot.Items[2].Enabled = false;
                }
                else if ((Convert.ToInt32(CurrentTime) >= 4) && (Convert.ToInt32(CurrentTime) < 12))
                {
                    rblTimeSlot.Items[0].Enabled = false;
                    rblTimeSlot.Items[1].Enabled = false;
                    rblTimeSlot.Items[2].Enabled = false;
                    rblTimeSlot.Items[3].Enabled = false;
                    rblTimeSlot.ClearSelection();
                }
                else
                {
                    rblTimeSlot.Items[0].Enabled = false;
                    rblTimeSlot.Items[1].Enabled = false;
                }
            }
        }
        else
        {
            rblTimeSlot.Items[0].Enabled = true;
            rblTimeSlot.Items[1].Enabled = true;
            rblTimeSlot.Items[2].Enabled = true;
            rblTimeSlot.Items[3].Enabled = true;
        }
    }

    protected void ddlSubService_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRate(ddlSubService);
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        EnableDisableTimeSlots();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        var objSale = new BL.Sales();
        try
        {
            TimeZoneInfo timeZoneInfo1;
            DateTime dateTime1;
            timeZoneInfo1 = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            dateTime1 = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo1);
            var date = dateTime1.ToString("dd-MMM-yyyy");
            if ((rblTimeSlot.Items[0].Selected != true) && (rblTimeSlot.Items[1].Selected != true) && (rblTimeSlot.Items[2].Selected != true) && (rblTimeSlot.Items[3].Selected != true))
            {
                lblMsg.Text = "Please Select Time Slot";
            }
            else
            {
                if (hfMobile.Value == "0")
                {
                    string strkey = GetDecryptkey("InstaService");
                    string strEncodedPassword;
                    BL.UserManagement objblUserManagement = new BL.UserManagement();
                    strEncodedPassword = objblUserManagement.EncryptPassword("INSTA123", true, strkey);
                    DataSet ds1 = objSale.InsertCustomer(txtMobile.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, strEncodedPassword.ToString());
                    DataSet ds2 = objSale.InsertAddress(txtMobile.Text, txtHouseNo.Text, txtISLocation.Text, txtLandmark.Text, ddlCity.SelectedItem.Value,txtPincode.Text);
                }
                DataSet ds = objSale.InsertOrder(txtMobile.Text, "24", Convert.ToInt32(ddlSubService.SelectedItem.Value), txtDate.Text, txtDate.Text, rblTimeSlot.SelectedItem.Value, rblTimeSlot.SelectedItem.Value, txtMobile.Text, txtHouseNo.Text, "", txtISLocation.Text, txtLandmark.Text, ddlCity.SelectedItem.Value, "", "", txtPincode.Text, BaseUserID, date, Convert.ToDecimal(0), Convert.ToDecimal(0), txtFirstName.Text + " " + txtLastName.Text, txtEmail.Text, "NEW", ddlUnit.SelectedItem.Value, lblPrice.Text, 0);
                if (ds.Tables[0].Rows[0]["WorkOrderNo"].ToString() != "")
                {
                    lblMsg.Text = "Order Generated Successfully !!";
                    hfMobile.Value = "0";
                }
                Reset();
                txtSearchMobile.Text = "";
                lblCustMsg.Text = "";
                txtDate.Text = date;
                EnableDisableTimeSlots();
            }
        }
        catch (Exception ex)
        { }
    }
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        EnableDisableTimeSlots();
        lblMsg.Text = "";
        var objSale = new BL.Sales();
        if(txtSearchMobile.Text != "")
        { 
           
        DataSet ds = objSale.SearchCustomer(txtSearchMobile.Text);
        if (ds.Tables[0].Rows[0]["MessgaeId"].ToString() == "1")
        {
            Readonly();
            txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
            txtHouseNo.Text = ds.Tables[0].Rows[0]["HouseNo"].ToString();
            txtISLocation.Text = ds.Tables[0].Rows[0]["Location"].ToString();
            txtLandmark.Text = ds.Tables[0].Rows[0]["Landmark"].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
            ddlCity.SelectedItem.Value = ds.Tables[0].Rows[0]["City"].ToString();
            lblCustMsg.Text = "Customer Exists";
            hfMobile.Value = "1";
        }
        else
        {
            hfMobile.Value = "0";
            Readonlytrue();
            Reset();
            EnableDisableTimeSlots();
            txtMobile.Text = txtSearchMobile.Text;
            lblCustMsg.Text = "Customer Not Exists";

        }
        }
        else
        {
            lblCustMsg.Text = "Please Enter Customer Mobile No.";
        }

    }
    public void Readonly()
    {
        txtFirstName.Enabled = false;
        txtLastName.Enabled = false;
        txtMobile.Enabled = false;
        txtEmail.Enabled = false;
        //txtHouseNo.Enabled = false;
        //txtISLocation.Enabled = false;
        //txtLandmark.Enabled = false;
        //txtPincode.Enabled = false;
        //ddlCity.Enabled = false;
    }
    public void Readonlytrue()
    {
        txtFirstName.Enabled = true;
        txtLastName.Enabled = true;
        txtMobile.Enabled = true;
        txtEmail.Enabled = true;
        //txtHouseNo.Enabled = true;
        //txtISLocation.Enabled = true;
        //txtLandmark.Enabled = true;
        //txtPincode.Enabled = true;
        //ddlCity.Enabled = true;
    }
    public void Reset()
    {
        txtFirstName.Text = "" ;
        txtLastName.Text = "";
        txtMobile.Text = "";
        txtEmail.Text = "";
        txtHouseNo.Text = "";
        txtISLocation.Text = "";
        txtLandmark.Text = "";
        txtPincode.Text = "";
        rblTimeSlot.ClearSelection();
      //  ddlCity.Text = "";
    }
}