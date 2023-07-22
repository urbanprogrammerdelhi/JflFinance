using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Transactions;
using BL;


public partial class Invoice_BulkInvoiceAuthorisation : BasePage //System.Web.UI.Page
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

    /// <summary>
    /// Returns User Authorization Rights.
    /// </summary>
    private bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                BasePage bp = new BasePage();
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.BulkInvoiceAuthorise;
            //}

            //Code added by  on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.BulkInvoiceAuthorise + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            btnAuthorize.Visible = false;
            if (IsReadAccess == true)
            {
                txtPostFromDate.Text = FirstDateOfPreviousMonth_Get();
                txtPostToDate.Text = LastDateOfPreviousMonth_Get();

                // txtInvoiceFromDate.Attributes.Add("readonly", "readonly");
                HlimgInvoiceDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtPostFromDate.ClientID.ToString() + "');";
                //txtInvoiceToDate.Attributes.Add("readonly", "readonly");
                HlimgPeriodFrom.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtPostToDate.ClientID.ToString() + "');";
                btnProceed.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

                FillddlClientCode();
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
    }
    protected void FillddlInvoiceType()
    {
        var li1 = new ListItem {Text = Resources.Resource.All, Value = @"ALL"};
        ddlInvoiceType.Items.Insert(0, li1);

        var li2 = new ListItem {Text = Resources.Resource.InvoiceTypeActual, Value = @"ACTUAL"};
        ddlInvoiceType.Items.Insert(1, li2);

        var li3 = new ListItem {Text = Resources.Resource.InvoiceTypeFixed, Value = @"FIXED"};
        ddlInvoiceType.Items.Insert(2, li3);

    }
    private void FillgvBulkInvoiceDetails()
    {
        var objInvoice = new BL.Invoice();
        DataSet ds = objInvoice.Invoices2AuthorizedGet(BaseLocationAutoID, ddlClientCode.SelectedItem.Value, ddlInvoiceType.SelectedItem.Value, txtPostFromDate.Text, txtPostToDate.Text, strStatusFresh);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvBulkInvoiceDetails.DataSource = ds.Tables[0];
            gvBulkInvoiceDetails.DataBind();
            var lblInvoiceNet = (Label)gvBulkInvoiceDetails.Rows[0].Cells[7].FindControl("lblInvoiceNet");
            txtUnAuthorizedInvoiceNet.Text = lblInvoiceNet.Text;
        }
        else
        {
            gvBulkInvoiceDetails.DataSource = null;
            gvBulkInvoiceDetails.DataBind();
            txtUnAuthorizedInvoiceNet.Text = @"0";
            lblErrorMsg.Text = Resources.Resource.NoInvoicesExistsInTheDateRange;
        }
    }
    #endregion

    #region Page Buttons Events
    protected void btnProceed_Click(object sender, EventArgs e)
    {

        if (txtPostFromDate.Text != "" && txtPostToDate.Text != "")
        {
            if (!GetGreaterDate(Convert.ToDateTime(txtPostFromDate.Text), Convert.ToDateTime(txtPostToDate.Text)))
            {
                FillgvBulkInvoiceDetails();
            }

            else
            {
                lblErrorMsg.Visible = true;
                DisplayMessageString(lblErrorMsg, Resources.Resource.ToDateMustBeGreaterThanFromDate);
            }
        }

    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        BL.Invoice objInvoice = new BL.Invoice();
        int j = 0;
        using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
        {
            for (int i = 0; i < gvBulkInvoiceDetails.Rows.Count; i++)
            {
                CheckBox cbSelect = (CheckBox)gvBulkInvoiceDetails.Rows[i].FindControl("cbSelect");
                Label lblInvoiceNo = (Label)gvBulkInvoiceDetails.Rows[i].FindControl("lblInvoiceNo");
                if (cbSelect.Checked)
                {
                    ds = objInvoice.InvoiceAuthorized(BaseLocationAutoID, lblInvoiceNo.Text, strStatusAuthorized, BaseUserID);
                    j = j + 1;
                }
            }
            tx.Complete();
        }

        if (j > 0)
        {
            lblErrorMsg.Text = Resources.Resource.MsgSuccessfullyAuthorized;
            FillgvBulkInvoiceDetails();
            btnAuthorize.Visible = false;
        }
    }

    #endregion

    #region ChangeEvents

    protected void txtPostFromDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            BL.Common objCommon = new BL.Common();
            ConvertStringToDateFormat(txtPostFromDate, lblErrorMsg);
            string strDate = txtPostFromDate.Text;
            int intMonth = DateTime.Parse(strDate).Month;
            int intYear = DateTime.Parse(strDate).Year;
            int EndDay = objCommon.GetDaysInMonth(intMonth);
            string Date = (EndDay + "-" + intMonth + "-" + intYear);
            txtPostToDate.Text = DateTime.Parse(Date).ToString("dd-MMM-yyyy");
        }
        catch (Exception)
        {
        }
    }

    #endregion

    #region Checkbox CheckChanged Event
    protected void cbSelect_CheckedChanged(object sender, EventArgs e)
    {
        int flag = 0;
        for (int i = 0; i < gvBulkInvoiceDetails.Rows.Count; i++)
        {
            CheckBox cbSelect = (CheckBox)gvBulkInvoiceDetails.Rows[i].FindControl("cbSelect");
            Label lblSoNo = (Label)gvBulkInvoiceDetails.Rows[i].FindControl("lblSoNo");
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
            if (IsAuthorizationAccess == true)
            {
                btnAuthorize.Visible = true;
            }
            else
            {
                btnAuthorize.Visible = false;
            }
            up1.Update();
        }
        else
        {
            btnAuthorize.Visible = false;
            up1.Update();
        }

    }
    protected void cbAllSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbAllSelect = (CheckBox)gvBulkInvoiceDetails.HeaderRow.FindControl("cbAllSelect");
        if (cbAllSelect.Checked)
        {
            if (IsAuthorizationAccess == true)
            {
                btnAuthorize.Visible = true;
            }
            else
            {
                btnAuthorize.Visible = false;
            }
            up1.Update();
        }
        else
        {
            btnAuthorize.Visible = false;
            up1.Update();
        }
    }
    #endregion

}
