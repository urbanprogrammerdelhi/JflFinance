using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Invoice_BulkInvoiceMaster : BasePage // System.Web.UI.Page
{
    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>

    private bool IsReadAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Write Rights.
    /// </summary>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Modify Rights.
    /// </summary>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Delete Rights.
    /// </summary>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    #region Page Functions
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //btnGenerateInvoices.Enabled = false;
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.BulkInvoicing;
            //}
            //Code added by  on 16 Jan 2012
            //Page Title from resource file
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.BulkInvoicing + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess)
            {
                txtInvoiceDate.Text = DateFormat(DateTime.Now);
                txtPeriodFrom.Text = FirstDateOfCurrentMonth_Get();//FirstDateOfPreviousMonth_Get();
                txtPeriodTo.Text = LastDateOfCurrentMonth_Get();//LastDateOfPreviousMonth_Get();
                txtpostingDate.Text = LastDateOfCurrentMonth_Get();//LastDateOfPreviousMonth_Get();
                txtTax.Text = @"0";

                txtInvoiceDate.Attributes.Add("readonly", "readonly");
                HlimgInvoiceDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtInvoiceDate.ClientID + "');";
                txtPeriodFrom.Attributes.Add("readonly", "readonly");
                HlimgPeriodFrom.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtPeriodFrom.ClientID + "');";
                txtPeriodTo.Attributes.Add("readonly", "readonly");
                HlimgPeriodTo.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtPeriodTo.ClientID + "');";
                txtpostingDate.Attributes.Add("readonly", "readonly");
                HlimgPostDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtpostingDate.ClientID + "');";
                //btnProceed.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                // btnGenerateInvoices.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

                FillddlClientCode();
                FillddlSoType();
                FillddlInvoiceType();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Controles Binding
    protected void FillddlClientCode()
    {
        var objsales = new BL.Sales();
        DataSet ds = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? objsales.ClientGet(BaseLocationAutoID, BaseUserID) : objsales.ClientsLocationWiseGet(BaseLocationAutoID);
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientNameCode";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();

                var li = new ListItem {Text = Resources.Resource.All, Value = @"ALL"};
                ddlClientCode.Items.Insert(0, li);
            }
        }
        else
        {
            var li = new ListItem {Text = @Resources.Resource.NoDataToShow , Value = string.Empty};
            ddlSoType.Items.Add(li);
        }
    }
    protected void FillddlSoType()
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.SaleOrderTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSoType.DataSource = ds.Tables[0];
            ddlSoType.DataValueField = "SaleOrderTypeCode";
            ddlSoType.DataTextField = "SaleOrderTypeDesc";
            ddlSoType.DataBind();

            var li = new ListItem {Text = Resources.Resource.All, Value = @"ALL"};
            ddlSoType.Items.Insert(0, li);
        }
        else
        {
            var li = new ListItem {Text = @Resources.Resource.NoDataToShow , Value = ""};
            ddlSoType.Items.Add(li);
        }
    }
    protected void FillddlInvoiceType()
    {
        var li = new ListItem {Text = Resources.Resource.InvoiceTypeFixed, Value = @"FIXED"};
        ddlInvoiceType.Items.Add(li);

        li = new ListItem {Text = Resources.Resource.InvoiceTypeActual, Value = @"ACTUAL"};
        ddlInvoiceType.Items.Add(li);

        li = new ListItem {Text = Resources.Resource.ActualDaysInMonth, Value = @"ACTUAL DAYS IN MONTH"};
        ddlInvoiceType.Items.Add(li);

        li = new ListItem {Text = Resources.Resource.All, Value = @"ALL"};
        ddlInvoiceType.Items.Insert(0, li);

        li = new ListItem {Text = Resources.Resource.AsPerSchedule, Value = @"AS PER SCHEDULE"};
        ddlInvoiceType.Items.Add(li);
    }
    #endregion

    #region Buttons Events
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        DisplayMessageString(lblErrorMsg, Resources.Resource.FetchingSalesOrder);

        if (ValidateProceed() == true)
        {
            // ds = GenerateInvoices();
            gvSoDetails.Visible = true;
            gvBulkInvoiceDetails.Visible = false;
            gvBulkInvoiceDetails.DataSource = null;
            gvBulkInvoiceDetails.DataBind();
            FillgvSoDetails();
            //FillgvInvoiceDetails(ds);
        }
    }
    protected bool ValidateProceed()
    {
        if (txtInvoiceDate.Text == "" || txtPeriodFrom.Text == "" || txtPeriodTo.Text == "" || txtTax.Text == "")
        {
            // Check if any one of these field is left blank then return false
            DisplayMessageString(lblErrorMsg, Resources.Resource.MsgRequiredFieldLeftBlank);
            return false;
        }
        else if (CompareDates(DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text)) != 2)
        {
            //Check if PeriodFrom Date is Greater then PeriodTo Date or if both are equal then return false
            DisplayMessageString(lblErrorMsg, Resources.Resource.MsgPeriodFromorPeriodToDateisnotValid);
            return false;
        }
        //else if (CompareDates(DateTime.Parse(txtPeriodTo.Text), DateTime.Parse(txtInvoiceDate.Text)) != 2)
        //{
        //    // check if invoiceDate is less then selected Period then return false
        //    lblErrorMsg.Text = "Invoice Date or PeriodFrom and PeriodTo date is not Valid";
        //    return false;
        //}
        else
        {
            return true;
        }
    }
    protected void btnGenerateInvoices_Click(object sender, EventArgs e)
    {
        var dtSo = new DataTable();
        var dCol1 = new DataColumn("SoNo", typeof(System.String));
        dtSo.Columns.Add(dCol1);
        var objInvoice = new BL.Invoice();
        for (int i = 0; i < gvSoDetails.Rows.Count; i++)
        {
            var cbSelect = (CheckBox)gvSoDetails.Rows[i].FindControl("cbSelect");
            var lblSoNo = (Label)gvSoDetails.Rows[i].FindControl("lblSoNo");
            if (cbSelect.Checked)
            {
                DataRow dr = dtSo.NewRow();
                dr["SoNo"] = lblSoNo.Text;
                dtSo.Rows.Add(dr);
            }
        }
        DataSet ds = objInvoice.BulkInvOutputGeneration(BaseLocationAutoID, dtSo, txtPeriodFrom.Text, txtPeriodTo.Text);
        //ds = objInvoice.BulkInvoiceGenerate(BaseLocationAutoID.ToString(), txtInvoiceDate.Text, txtPeriodFrom.Text, txtPeriodTo.Text, ddlInvoiceType.SelectedItem.Value.ToString(), txtTax.Text, txtRemarks.Text, strStatusAuthorized, strStatusFresh, strStatusReversal, txtpostingDate.Text, BaseUserID.ToString(), dtSo, strStatusDelete);
        gvSoDetails.Visible = false;
        gvBulkInvoiceDetails.Visible = true;
        gvBulkInvoiceDetails.DataSource = ds;
        gvBulkInvoiceDetails.DataBind();
        btnGenerateInvoices.Enabled = false;
        //lblErrorMsg.Text = "";
    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Invoice/RptInvoiceSummary.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UserManagement/Home.aspx");
    }
    #endregion

    #region Client and saleOrder Gridview
    protected DataSet FetchSalesOrder()
    {
        var objInvoice = new BL.Invoice();
        DataSet ds = objInvoice.SoNoGet(BaseLocationAutoID, ddlClientCode.SelectedItem.Value, ddlSoType.SelectedItem.Value, ddlInvoiceType.SelectedItem.Value, txtPeriodFrom.Text, txtPeriodTo.Text, strStatusFresh, strStatusReversal, strStatusDelete);
        return ds;
    }
    protected void FillgvSoDetails()
    {
        DataSet ds = FetchSalesOrder();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvSoDetails.DataSource = ds.Tables[0];
            gvSoDetails.DataBind();
        }
    }

    protected void gvSoDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            var cbSelect = (CheckBox)e.Row.FindControl("cbSelect");
            var lblRemarks = (Label)e.Row.FindControl("lblRemarks");
            if (lblRemarks != null && cbSelect != null)
            {
                if (lblRemarks.Text.Trim() != "" || IsWriteAccess == false)
                {
                    cbSelect.Enabled = false;
                }
                else
                {
                    cbSelect.Enabled = true;
                }
            }
        }
    }
    protected void gvSoDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSoDetails.PageIndex = e.NewPageIndex;
        gvSoDetails.EditIndex = -1;
        FillgvSoDetails();
    }
    protected void cbSelect_CheckedChanged(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
        int flag = 0;
        for (int i = 0; i < gvSoDetails.Rows.Count; i++)
        {
            var cbSelect = (CheckBox)gvSoDetails.Rows[i].FindControl("cbSelect");
            var lblSoNo = (Label)gvSoDetails.Rows[i].FindControl("lblSoNo");
            if (cbSelect.Checked)
            {
                flag = 1;
                break;
            }
            else
            {
                flag = 0;
            }
        }
        if (flag == 1)
        {
            btnGenerateInvoices.Enabled = true;
            up1.Update();
        }
        else
        {
            btnGenerateInvoices.Enabled = false;
            up1.Update();
        }

    }
    protected void cbAllSelect_CheckedChanged(object sender, EventArgs e)
    {
        var cbAllSelect = (CheckBox)gvSoDetails.HeaderRow.FindControl("cbAllSelect");
        if (cbAllSelect.Checked)
        {
            btnGenerateInvoices.Enabled = true;
            up1.Update();
        }
        else
        {
            btnGenerateInvoices.Enabled = false;
            up1.Update();
        }
    }
    #endregion

    #region Invoice Gridview
    protected void FillgvInvoiceDetails(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvBulkInvoiceDetails.DataSource = ds.Tables[0];
            gvBulkInvoiceDetails.DataBind();
        }
        btnGenerateInvoices.Enabled = false;
    }
    protected void lbtnInvoiceNo_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lbtnInvoiceNo = (LinkButton)gvBulkInvoiceDetails.Rows[row.RowIndex].FindControl("lbtnInvoiceNo");
        var lblSono = (Label)gvBulkInvoiceDetails.Rows[row.RowIndex].FindControl("lblSoNo");
        var lblCustno = (Label)gvBulkInvoiceDetails.Rows[row.RowIndex].FindControl("lblClientCode");
        if (lbtnInvoiceNo != null)
        {
            Response.Redirect("../Invoice/InvoiceMasterBarbados.aspx?SoNo=" + lblSono.Text + "&ClientCode=" + lblCustno.Text + "&InvoiceNo=" + lbtnInvoiceNo.Text);
        }
    }
    protected void lbtnInvoiceNo1_Click1(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lbtnInvoiceNo = (LinkButton)gvSoDetails.Rows[row.RowIndex].FindControl("lbtnInvoiceNo");
        var lblSono = (Label)gvSoDetails.Rows[row.RowIndex].FindControl("lblSoNo");
        var lblCustno = (Label)gvSoDetails.Rows[row.RowIndex].FindControl("lblClientCode");
        if (lbtnInvoiceNo != null)
        {
            Response.Redirect("../Invoice/InvoiceMasterBarbados.aspx?SoNo=" + lblSono.Text + "&ClientCode=" + lblCustno.Text + "&InvoiceNo=" + lbtnInvoiceNo.Text);
        }
    }

    #endregion
}