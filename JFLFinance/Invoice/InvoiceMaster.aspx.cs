using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Sales_InvoiceMaster : BasePage //System.Web.UI.Page
{
    static DataTable dtSoDetails = new DataTable();
    static DataTable dtSoItemDetails = new DataTable();

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
            //    lblPageHdrTitle.Text = Resources.Resource.Invoice;
            //}

            //Code added by  on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Invoice + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                txtInvoiceDate.Text = DateFormat(DateTime.Now);
                txtPeriodFrom.Text = FirstDateOfPreviousMonth_Get();
                txtPeriodTo.Text = LastDateOfPreviousMonth_Get();

                //txtInvNo.Attributes.Add("readonly", "readonly");
                txtInvoiceDate.Attributes.Add("readonly", "readonly");
                HlimgInvoiceDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtInvoiceDate.ClientID.ToString() + "');";
                txtPeriodFrom.Attributes.Add("readonly", "readonly");
                HlimgPeriodFrom.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtPeriodFrom.ClientID.ToString() + "');";
                txtPeriodTo.Attributes.Add("readonly", "readonly");
                HlimgPeriodTo.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtPeriodTo.ClientID.ToString() + "');";
                IMGPostingDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtPostingDate.ClientID.ToString() + "');";
                IMGReversalDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtReversalDate.ClientID.ToString() + "');";

                txtSoNo.Attributes.Add("readonly", "readonly");
                txtClientCode.Attributes.Add("readonly", "readonly");
                txtClientName.Attributes.Add("readonly", "readonly");
                txtSubTotal.Attributes.Add("readonly", "readonly");
                txtGrandTotal.Attributes.Add("readonly", "readonly");

                btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnReversal.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnAuthorize.Attributes["onclick"] = "javascript:Timerf('divErrorMsg');";
                btnReversal.Attributes["onclick"] = "javascript:Timerf('divErrorMsg');";
                btnRevSave.Attributes["onclick"] = "javascript:Timerf('" + lblRevErrormsg.ClientID.ToString() + "');";
                ImgBtnSearchInv.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=INVOICECCH&ControlId=" + txtInvNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");

                //FillddlInvoiceType();

                if (Request.QueryString["InvoiceNo"] != null && Request.QueryString["InvoiceNo"] != "")
                {
                    string strInvoiceNo = Request.QueryString["InvoiceNo"].ToString();
                    txtInvNo.Text = strInvoiceNo;
                    GetSelectedInvoice();
                    ViewMode();
                }
                if (Request.QueryString["SoNo"] != null && Request.QueryString["SoNo"].ToString() != "0" && txtInvNo.Text == "")
                {
                    txtSoNo.Text = Request.QueryString["SoNo"].ToString();
                    GetSelectedSaleOrder();
                    btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    txtClientCode.Text = Request.QueryString["ClientCode"].ToString();
                    AddNewMode();
                }
                else if (Request.QueryString["SoNo"] != null && Request.QueryString["SoNo"].ToString() != "0" && txtInvNo.Text != "")
                {
                    txtSoNo.Text = Request.QueryString["SoNo"].ToString();
                    GetSelectedSaleOrder();
                    btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    txtClientCode.Text = Request.QueryString["ClientCode"].ToString();
                    ViewMode();
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
        if (txtInvNo.Text != "")
        {
            HlimgInvoiceDate.Enabled = false;
            HlimgPeriodFrom.Enabled = false;
            HlimgPeriodTo.Enabled = false;
            ddlInvoiceType.Enabled = false;
        }
    }
    #endregion

    #region Controles Binding
    protected void GetSelectedSaleOrder()
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = new DataSet();

        string strSOAmendNO;
        strSOAmendNO = "-1";

        ds = objsales.SaleOrderGet(BaseLocationAutoID, txtSoNo.Text, strSOAmendNO);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            FillControles(ds);
        }
        else
        {
            ClearControles();
        }
    }
    protected void GetSelectedInvoice()
    {
        if (FillInvoiceHeader() == true)
        {
            FillgvSaleOrderDetails();
            FillgvSaleOrderItemDetails();
            ViewMode();
        }
        else
        {
            ClearControles();
            AddNewMode();
        }
    }
    protected bool FillInvoiceHeader()
    {
        DataSet ds = new DataSet();
        BL.Invoice objInvoiceHeader = new BL.Invoice();
        ds = objInvoiceHeader.InvoiceHeaderGet(BaseLocationAutoID, txtInvNo.Text.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtInvoiceDate.Text = DateFormat(ds.Tables[0].Rows[0]["InvoiceDate"].ToString());
            lblInvStatus.Text = ResourceValueOfKeyOnlyforStatus_Get(ds.Tables[0].Rows[0]["Status"].ToString());
            hfInvStatus.Value = ds.Tables[0].Rows[0]["Status"].ToString();
            txtClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
            txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
            txtSoNo.Text = ds.Tables[0].Rows[0]["SoNo"].ToString();
            txtBillingID.Text = ds.Tables[0].Rows[0]["BillingID"].ToString();
            txtBillingAddress.Text = ds.Tables[0].Rows[0]["BillingAddress"].ToString();
            txtPeriodFrom.Text = DateFormat(ds.Tables[0].Rows[0]["InvFromDate"].ToString());
            txtPeriodTo.Text = DateFormat(ds.Tables[0].Rows[0]["InvToDate"].ToString());
            txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            ddlInvoiceType.SelectedValue = ds.Tables[0].Rows[0]["InvoiceType"].ToString();
            txtSubTotal.Text = string.Format("{0:f3}", ds.Tables[0].Rows[0]["SubTotal"]);
            txtTax.Text = string.Format("{0:f3}", ds.Tables[0].Rows[0]["Tax"]);
            txtGrandTotal.Text = string.Format("{0:f3}", ds.Tables[0].Rows[0]["GrandTotal"]);
            txtPostingDate.Text = DateFormat(ds.Tables[0].Rows[0]["PostingDate"].ToString());
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void ClearControles()
    {
        lblInvStatus.Text = "";
        hfInvStatus.Value = "";
    }
    protected void FillControles(DataSet ds)
    {
        txtClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
        txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        txtBillingID.Text = ds.Tables[0].Rows[0]["AsmtBillingId"].ToString();
        txtBillingAddress.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
        HFTerminationDate.Value = ds.Tables[0].Rows[0]["SoTerminationDate"].ToString();
    }
    protected void FillClientName()
    {
        if (txtClientCode.Text != "")
        {
            DataSet ds = new DataSet();
            BL.Sales objSales = new BL.Sales();
            ds = objSales.ClientNameDetailGet(txtClientCode.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                //FillddlClientBillingID();
            }
            else
            {
                txtClientCode.Text = "";
                DisplayMessage(lblErrorMsg, "4");
            }
        }
    }
    protected void FillddlInvoiceType()
    {

        ListItem li = new ListItem();
        li.Text = Resources.Resource.InvoiceTypeFixed.ToString();
        li.Value = "FIXED";
        ddlInvoiceType.Items.Add(li);
        //li = new ListItem();
        //li.Text = "MISC";
        //li.Value = "MISC";
        //ddlInvoiceType.Items.Add(li);
        li = new ListItem();
        li.Text = Resources.Resource.InvoiceTypeActual.ToString();
        li.Value = "ACTUAL";
        ddlInvoiceType.Items.Add(li);
        li = new ListItem();
        li.Text = Resources.Resource.ActualDaysInMonth.ToString();
        li.Value = "ACTUAL DAYS IN MONTH";
        ddlInvoiceType.Items.Add(li);
        li = new ListItem();
        li.Text = Resources.Resource.AsPerSchedule.ToString();
        li.Value = "AS PER SCHEDULE";
        ddlInvoiceType.Items.Add(li);
    }
    #endregion

    #region GridView gvSaleOrderDetails
    protected void FillgvSaleOrderDetails()
    {

        DataSet ds = new DataSet();
        int dtflag;
        dtflag = 1;
        lblSOLineTotalValue.Text = decimal.Parse("0").ToString();
        BL.Invoice objInvoice = new BL.Invoice();
        if (txtInvNo.Text == "")
        {
            //ds = objInvoice.blSOMstDetails_Get(BaseLocationAutoID, txtSoNo.Text, txtPeriodFrom.Text, txtPeriodTo.Text, strStatusAuthorized);
            ds = objInvoice.SaleOrderDetailsGet(BaseLocationAutoID, txtSoNo.Text, txtPeriodFrom.Text, txtPeriodTo.Text, ddlInvoiceType.SelectedItem.Value.ToString(), strStatusAuthorized);
        }
        else
        {
            ds = objInvoice.InvoiceDetailsGet(BaseLocationAutoID, txtInvNo.Text);
        }
        if (ds != null && ds.Tables.Count > 0)
        {
            dtSoDetails = ds.Tables[0];
            //to fix empety gridview
            if (dtSoDetails.Rows.Count == 0)
            {
                dtflag = 0;
                dtSoDetails.Rows.Add(dtSoDetails.NewRow());
                gvSaleOrderDetails.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "SoLineNo" };
                gvSaleOrderDetails.DataSource = dtSoDetails;
                gvSaleOrderDetails.DataBind();

                if (dtflag == 0)//to fix empety gridview
                {
                    gvSaleOrderDetails.Rows[0].Visible = false;
                }
            }
            else if (dtSoDetails.Rows.Count > 0)
            {
                decimal SOLineTotalValue = 0;
                for (int i = 0; i < dtSoDetails.Rows.Count; i++)
                {
                    if ((ddlInvoiceType.SelectedItem.Value.ToString() == "FIXED" || txtInvNo.Text != "") || (ddlInvoiceType.SelectedItem.Value.ToString() == "ACTUAL DAYS IN MONTH" || txtInvNo.Text != ""))
                    {
                        SOLineTotalValue = SOLineTotalValue + decimal.Parse(dtSoDetails.Rows[i]["MonthlyBilling"].ToString());
                    }
                    else
                    {
                        SOLineTotalValue = SOLineTotalValue + decimal.Parse(dtSoDetails.Rows[i]["ActualMonthlyBilling"].ToString());
                    }
                }
                lblSOLineTotalValue.Text = string.Format("{0:f3}", SOLineTotalValue);

                gvSaleOrderDetails.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "SoLineNo" };
                gvSaleOrderDetails.DataSource = dtSoDetails;
                gvSaleOrderDetails.DataBind();
            }
        }
    }
    protected void txtDaysInMonth_TextChangedET(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtDaysInMonth = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txtDaysInMonth.NamingContainer;
        TextBox txtHoursInMonth = (TextBox)gvSaleOrderDetails.Rows[gvRow.RowIndex].FindControl("txtHoursInMonth");
        TextBox txtHours = (TextBox)gvSaleOrderDetails.Rows[gvRow.RowIndex].FindControl("txtHours");

        TextBox txtOtherAllowances = (TextBox)gvSaleOrderDetails.Rows[gvRow.RowIndex].FindControl("txtOtherAllowances");
        txtHoursInMonth.Text = Convert.ToString(decimal.Parse(txtDaysInMonth.Text) * decimal.Parse(txtHours.Text));
        ToolkitScriptManager1.SetFocus(txtOtherAllowances);
    }
    protected void txtDaysInMonth_TextChangedFT(object sender, EventArgs e)
    {
        TextBox txtDaysInMonth = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txtDaysInMonth.NamingContainer;
        TextBox txtHoursInMonth = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtHoursInMonth");
        TextBox txtHours = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtHours");
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtOtherAllowances = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtOtherAllowances");
        txtHoursInMonth.Text = Convert.ToString(decimal.Parse(txtDaysInMonth.Text) * decimal.Parse(txtHours.Text));
        ToolkitScriptManager1.SetFocus(txtOtherAllowances);
    }
    #region GridView Commands SaleOrderServiceDetails Events
    protected void gvSaleOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if ((IsWriteAccess == false && IsModifyAccess == false) || txtInvNo.Text == "" || hfInvStatus.Value.ToString() == strStatusAuthorized || hfInvStatus.Value.ToString() == strStatusReversal)
        {
            gvSaleOrderDetails.Columns[0].Visible = false;
        }
        else
        { gvSaleOrderDetails.Columns[0].Visible = true; }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblgvSOLineNO = (Label)e.Row.FindControl("lblgvSOLineNO");

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                //Edit button will not show when the sale order not in Fresh or amend mode
                if (hfInvStatus.Value.ToString() != strStatusFresh || hfInvStatus.Value.ToString() == "")
                {
                    ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                    if (ImgbtnEdit != null)
                    {
                        ImgbtnEdit.Visible = false;
                    }
                    gvSaleOrderDetails.Columns[0].Visible = false;
                }
                else //Edit button will enable when the sale order in Fresh or amend mode
                {
                    gvSaleOrderDetails.Columns[0].Visible = true;
                    ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                    if (ImgbtnUpdate != null)
                    {
                        ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }

                    TextBox txtSOLineStartDate = (TextBox)e.Row.FindControl("txtSOLineStartDate");
                    TextBox txtSOLineEndDate = (TextBox)e.Row.FindControl("txtSOLineEndDate");
                    HyperLink HlimgSOLineStartDate = (HyperLink)e.Row.FindControl("HlimgSOLineStartDate");
                    HyperLink HlimgSOLineEndDate = (HyperLink)e.Row.FindControl("HlimgSOLineEndDate");
                    TextBox txtHoursInMonth = (TextBox)e.Row.FindControl("txtHoursInMonth");
                    TextBox txtBillingDesignation = (TextBox)e.Row.FindControl("txtBillingDesignation");
                    TextBox txtMonthlyBilling = (TextBox)e.Row.FindControl("txtMonthlyBilling");
                    HiddenField hfRatePerHour = (HiddenField)e.Row.FindControl("hfRatePerHour");

                    if (txtBillingDesignation != null)
                    {
                        txtBillingDesignation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                        txtBillingDesignation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    }
                    if (txtHoursInMonth != null)
                    {
                        txtHoursInMonth.Attributes.Add("readonly", "readonly");
                    }
                    if (txtSOLineStartDate != null)
                    {
                        txtSOLineStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtSOLineEndDate != null)
                    {
                        txtSOLineEndDate.Attributes.Add("readonly", "readonly");
                    }
                    if (HlimgSOLineStartDate != null)
                    {
                        HlimgSOLineStartDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSOLineStartDate.ClientID.ToString() + "');";
                    }
                    if (HlimgSOLineEndDate != null)
                    {
                        HlimgSOLineEndDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSOLineEndDate.ClientID.ToString() + "');";
                    }
                    if (txtMonthlyBilling != null)
                    {
                        txtMonthlyBilling.Attributes.Add("readonly", "readonly");
                    }
                    TextBox txtSellingPrice = (TextBox)e.Row.FindControl("txtSellingPrice");
                    TextBox txtNoOfPost = (TextBox)e.Row.FindControl("txtNoOfPost");
                    TextBox txtHours = (TextBox)e.Row.FindControl("txtHours");
                    TextBox txtDaysInMonth = (TextBox)e.Row.FindControl("txtDaysInMonth");
                    TextBox txtOtherAllowances = (TextBox)e.Row.FindControl("txtOtherAllowances");

                    if (txtNoOfPost != null)
                    {
                        txtNoOfPost.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                        txtNoOfPost.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    }
                    if (txtHours != null)
                    {
                        txtHours.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtHours.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                    if (txtDaysInMonth != null)
                    {
                        txtDaysInMonth.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtDaysInMonth.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                    if (txtOtherAllowances != null)
                    {
                        txtOtherAllowances.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtOtherAllowances.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                    if (txtSellingPrice != null)
                    {
                        txtSellingPrice.Attributes.Add("readonly", "readonly");
                        txtSellingPrice.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtSellingPrice.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                    if (txtNoOfPost != null && txtHours != null && txtDaysInMonth != null && txtHoursInMonth != null && txtOtherAllowances != null && txtMonthlyBilling != null && txtSellingPrice != null && hfRatePerHour != null)
                    {
                        txtNoOfPost.Attributes["onblur"] = "javascript:CalculateHoursInMonthNMonthlyBilling('" + txtNoOfPost.ClientID.ToString() + "', '" + txtHours.ClientID.ToString() + "', '" + txtDaysInMonth.ClientID.ToString() + "', '" + txtHoursInMonth.ClientID.ToString() + "', '" + txtOtherAllowances.ClientID.ToString() + "', '" + txtMonthlyBilling.ClientID.ToString() + "', '" + txtSellingPrice.ClientID.ToString() + "', '" + hfRatePerHour.ClientID.ToString() + "')";
                        txtHours.Attributes["onblur"] = "javascript:CalculateHoursInMonthNMonthlyBilling('" + txtNoOfPost.ClientID.ToString() + "', '" + txtHours.ClientID.ToString() + "', '" + txtDaysInMonth.ClientID.ToString() + "', '" + txtHoursInMonth.ClientID.ToString() + "', '" + txtOtherAllowances.ClientID.ToString() + "', '" + txtMonthlyBilling.ClientID.ToString() + "', '" + txtSellingPrice.ClientID.ToString() + "', '" + hfRatePerHour.ClientID.ToString() + "')";
                        txtDaysInMonth.Attributes["onblur"] = "javascript:CalculateHoursInMonthNMonthlyBilling('" + txtNoOfPost.ClientID.ToString() + "', '" + txtHours.ClientID.ToString() + "', '" + txtDaysInMonth.ClientID.ToString() + "', '" + txtHoursInMonth.ClientID.ToString() + "', '" + txtOtherAllowances.ClientID.ToString() + "', '" + txtMonthlyBilling.ClientID.ToString() + "', '" + txtSellingPrice.ClientID.ToString() + "', '" + hfRatePerHour.ClientID.ToString() + "')";
                        txtOtherAllowances.Attributes["onblur"] = "javascript:CalculateHoursInMonthNMonthlyBilling('" + txtNoOfPost.ClientID.ToString() + "', '" + txtHours.ClientID.ToString() + "', '" + txtDaysInMonth.ClientID.ToString() + "', '" + txtHoursInMonth.ClientID.ToString() + "', '" + txtOtherAllowances.ClientID.ToString() + "', '" + txtMonthlyBilling.ClientID.ToString() + "', '" + txtSellingPrice.ClientID.ToString() + "', '" + hfRatePerHour.ClientID.ToString() + "')";
                        txtSellingPrice.Attributes["onblur"] = "javascript:CalculateHoursInMonthNMonthlyBilling('" + txtNoOfPost.ClientID.ToString() + "', '" + txtHours.ClientID.ToString() + "', '" + txtDaysInMonth.ClientID.ToString() + "', '" + txtHoursInMonth.ClientID.ToString() + "', '" + txtOtherAllowances.ClientID.ToString() + "', '" + txtMonthlyBilling.ClientID.ToString() + "', '" + txtSellingPrice.ClientID.ToString() + "', '" + hfRatePerHour.ClientID.ToString() + "')";
                    }
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvSaleOrderDetails.ShowFooter = false;
            }
            else
            {
                if (hfInvStatus.Value.ToString() != strStatusFresh || txtInvNo.Text == "")
                {
                    gvSaleOrderDetails.ShowFooter = false;
                }
                else
                {
                    //gvSaleOrderDetails.ShowFooter = true;
                    gvSaleOrderDetails.ShowFooter = false;
                    ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                    if (ImgbtnAdd != null)
                    {
                        ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }

                    TextBox txtSellingPrice = (TextBox)e.Row.FindControl("txtSellingPrice");
                    TextBox txtNoOfPost = (TextBox)e.Row.FindControl("txtNoOfPost");
                    TextBox txtHours = (TextBox)e.Row.FindControl("txtHours");
                    TextBox txtDaysInMonth = (TextBox)e.Row.FindControl("txtDaysInMonth");
                    TextBox txtOtherAllowances = (TextBox)e.Row.FindControl("txtOtherAllowances");
                    TextBox txtBillingDesignation = (TextBox)e.Row.FindControl("txtBillingDesignation");
                    TextBox txtHoursInMonth = (TextBox)e.Row.FindControl("txtHoursInMonth");
                    TextBox txtMonthlyBilling = (TextBox)e.Row.FindControl("txtMonthlyBilling");

                    if (txtBillingDesignation != null)
                    {
                        txtBillingDesignation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                        txtBillingDesignation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    }
                    if (txtNoOfPost != null)
                    {
                        txtNoOfPost.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                        txtNoOfPost.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    }
                    if (txtHours != null)
                    {
                        txtHours.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtHours.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                    if (txtDaysInMonth != null)
                    {
                        txtDaysInMonth.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtDaysInMonth.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                    if (txtOtherAllowances != null)
                    {
                        txtOtherAllowances.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtOtherAllowances.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                    if (txtSellingPrice != null)
                    {
                        txtSellingPrice.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtSellingPrice.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }

                    TextBox txtSOLineStartDate = (TextBox)e.Row.FindControl("txtSOLineStartDate");
                    TextBox txtSOLineEndDate = (TextBox)e.Row.FindControl("txtSOLineEndDate");
                    HyperLink HlimgSOLineStartDate = (HyperLink)e.Row.FindControl("HlimgSOLineStartDate");
                    HyperLink HlimgSOLineEndDate = (HyperLink)e.Row.FindControl("HlimgSOLineEndDate");

                    if (txtHoursInMonth != null)
                    {
                        txtHoursInMonth.Attributes.Add("readonly", "readonly");
                    }
                    if (txtSOLineStartDate != null)
                    {
                        txtSOLineStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtSOLineEndDate != null)
                    {
                        txtSOLineEndDate.Attributes.Add("readonly", "readonly");
                    }
                    if (HlimgSOLineStartDate != null)
                    {
                        HlimgSOLineStartDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSOLineStartDate.ClientID.ToString() + "');";
                    }
                    if (HlimgSOLineEndDate != null)
                    {
                        HlimgSOLineEndDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSOLineEndDate.ClientID.ToString() + "');";
                    }
                    if (txtMonthlyBilling != null)
                    {
                        txtMonthlyBilling.Attributes.Add("readonly", "readonly");
                        txtMonthlyBilling.Visible = false;
                    }
                }
            }
        }


        //Hide the column MinWages
        gvSaleOrderDetails.Columns[1].Visible = false; //
        gvSaleOrderDetails.Columns[2].Visible = false; //
        gvSaleOrderDetails.Columns[17].Visible = false; // SOLineStartDate
        gvSaleOrderDetails.Columns[18].Visible = false; // SOLineEndDate


        if (txtInvNo.Text != "")
        {
            if (ddlInvoiceType.SelectedItem.Value.ToString() == "FIXED" || ddlInvoiceType.SelectedItem.Value.ToString() == "ACTUAL DAYS IN MONTH")
            {
                gvSaleOrderDetails.Columns[12].Visible = false;
                gvSaleOrderDetails.Columns[7].Visible = true;
            }
            else
            {
                gvSaleOrderDetails.Columns[7].Visible = false;
                gvSaleOrderDetails.Columns[12].Visible = true;
            }
            gvSaleOrderDetails.Columns[13].Visible = false;
            gvSaleOrderDetails.Columns[14].Visible = false;
            gvSaleOrderDetails.Columns[15].Visible = false;

        }
        else
        {
            //Invoicing services line based on Contract
            gvSaleOrderDetails.Columns[7].ItemStyle.BackColor = System.Drawing.Color.Silver;
            gvSaleOrderDetails.Columns[8].ItemStyle.BackColor = System.Drawing.Color.Silver;
            gvSaleOrderDetails.Columns[9].ItemStyle.BackColor = System.Drawing.Color.Silver;
            gvSaleOrderDetails.Columns[10].ItemStyle.BackColor = System.Drawing.Color.Silver;
            //Invoicing services line based on actual
            gvSaleOrderDetails.Columns[12].ItemStyle.BackColor = System.Drawing.Color.Gray;
            gvSaleOrderDetails.Columns[13].ItemStyle.BackColor = System.Drawing.Color.Gray;
            gvSaleOrderDetails.Columns[14].ItemStyle.BackColor = System.Drawing.Color.Gray;
            gvSaleOrderDetails.Columns[15].ItemStyle.BackColor = System.Drawing.Color.Gray;
        }
    }
    protected void gvSaleOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvSaleOrderDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSaleOrderDetails.EditIndex = -1;
        FillgvSaleOrderDetails();
    }
    protected void gvSaleOrderDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSaleOrderDetails.EditIndex = e.NewEditIndex;
        FillgvSaleOrderDetails();
    }
    protected void gvSaleOrderDetails_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        BL.Invoice objInvoice = new BL.Invoice();
        DataSet ds = new DataSet();
        Label lblgvSOLineNO = (Label)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("lblgvSOLineNO");
        Label lblgvSOAmendNO = (Label)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("lblgvSOAmendNO");

        TextBox txtBillingDesignation = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtBillingDesignation");
        TextBox txtNoOfPost = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtNoOfPost");
        TextBox txtHours = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtHours");
        TextBox txtDaysInMonth = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtDaysInMonth");
        TextBox txtHoursInMonth = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtHoursInMonth");
        HiddenField hfieldSOLineStartDate = (HiddenField)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("hfieldSOLineStartDate");
        HiddenField hfieldSOLineEndDate = (HiddenField)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("hfieldSOLineEndDate");
        HiddenField HFRowNumber = (HiddenField)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("HFRowNumber");
        TextBox txtOtherAllowances = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtOtherAllowances");
        TextBox txtSellingPrice = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtSellingPrice");
        TextBox txtMonthlyBilling = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtMonthlyBilling");
        TextBox txtSOLineRemarks = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtSOLineRemarks");

        string strLocationAutoId = BaseLocationAutoID.ToString();
        string strInvoiceNo = txtInvNo.Text;
        string strSONO = txtSoNo.Text;
        string strSOAmendNo = "";
        string strSOLineNo = "";
        string strBillingDesignation = "";
        string strNoOfPost = "";
        string strHours = "";
        string strDaysInMonth = "";
        string strHoursInMonth = "";
        string strSOLineStartDate = "";
        string strSOLineEndDate = "";
        string strOtherAllowances = "";
        string strSellingPrice = "";
        string strMonthlyBilling = "";
        string strSOLineRemarks = "";
        string struserID = BaseUserID.ToString();
        if (lblgvSOAmendNO != null && lblgvSOLineNO != null && txtBillingDesignation != null && txtNoOfPost != null && txtHours != null && txtDaysInMonth != null && txtHoursInMonth != null && hfieldSOLineStartDate != null && hfieldSOLineEndDate != null && txtOtherAllowances != null && txtSellingPrice != null && txtMonthlyBilling != null && txtSOLineRemarks != null && HFRowNumber != null)
        {
            if (lblgvSOAmendNO.Text != "" && lblgvSOLineNO.Text != "" && txtBillingDesignation.Text != "" && txtNoOfPost.Text != "" && txtHours.Text != "" && txtDaysInMonth.Text != "" && txtHoursInMonth.Text != "" && hfieldSOLineStartDate.Value.ToString() != "" && hfieldSOLineEndDate.Value.ToString() != "" && txtOtherAllowances.Text != "" && txtSellingPrice.Text != "" && txtMonthlyBilling.Text != "" && HFRowNumber.Value != "")
            {
                strSOAmendNo = lblgvSOAmendNO.Text;
                strSOLineNo = lblgvSOLineNO.Text;
                strBillingDesignation = txtBillingDesignation.Text;
                strNoOfPost = txtNoOfPost.Text;
                strHours = txtHours.Text;
                strDaysInMonth = txtDaysInMonth.Text;
                strHoursInMonth = txtHoursInMonth.Text;
                strSOLineStartDate = hfieldSOLineStartDate.Value.ToString();
                strSOLineEndDate = hfieldSOLineEndDate.Value.ToString();
                strOtherAllowances = txtOtherAllowances.Text;
                strSellingPrice = txtSellingPrice.Text;
                strMonthlyBilling = txtMonthlyBilling.Text;
                strSOLineRemarks = txtSOLineRemarks.Text;
                System.TimeSpan TSDateDiff = DateTime.Parse(txtPeriodTo.Text).Subtract(DateTime.Parse(txtPeriodFrom.Text));
                if (decimal.Parse(txtDaysInMonth.Text) <= TSDateDiff.Days + 1)
                {
                    ds = objInvoice.InvoiceDetailsUpdate(strLocationAutoId, strInvoiceNo, strSONO, strSOAmendNo, strSOLineNo, strBillingDesignation, strNoOfPost, strHours, strDaysInMonth, strHoursInMonth, strSOLineStartDate, strSOLineEndDate, strOtherAllowances, strSellingPrice, strMonthlyBilling, strSOLineRemarks, struserID, int.Parse(HFRowNumber.Value));
                    gvSaleOrderDetails.EditIndex = -1;
                    FillInvoiceHeader();
                    FillgvSaleOrderDetails();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.MsgDaysinMonthShouldnotGraterThenInvoicePeriodDays);
                }
            }
        }
    }
    #endregion
    #endregion

    #region GridView gvSaleOrderItemDetails
    protected void FillgvSaleOrderItemDetails()
    {
        DataSet ds = new DataSet();
        //DataTable dt = new DataTable();

        int dtflag;
        decimal SOItemTotalValue = 0;
        lblSOItemTotalValue.Text = decimal.Parse("0").ToString();
        
        if (lblfixInvStatus.Text != "FRESH")
        {
            gvSOItemDetails.Columns[gvSOItemDetails.Columns.Count - 1].Visible = false;
        }
        dtflag = 1;
        BL.Invoice objInvoice = new BL.Invoice();
        if (txtInvNo.Text == "")
        {
            ds = objInvoice.SaleOrderItemDetailsGet(BaseLocationAutoID, txtSoNo.Text, txtPeriodFrom.Text, txtPeriodTo.Text, strStatusAuthorized);
        }
        else
        {
            ds = objInvoice.InvoiceItemDetailsGet(BaseLocationAutoID, txtInvNo.Text.ToString());
        }
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                dtSoItemDetails = ds.Tables[0];
                //to fix empety gridview
                if (dtSoItemDetails.Rows.Count == 0)
                {
                    dtflag = 0;
                    dtSoItemDetails.Rows.Add(dtSoItemDetails.NewRow());
                    gvSOItemDetails.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "ItemTypeCode" };
                    gvSOItemDetails.DataSource = dtSoItemDetails;
                    gvSOItemDetails.DataBind();
                    if (dtflag == 0)//to fix empety gridview
                    {
                        gvSOItemDetails.Rows[0].Visible = false;
                    }
                }
                else if (dtSoItemDetails.Rows.Count > 0)
                {
                    gvSOItemDetails.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "ItemTypeCode" };
                    gvSOItemDetails.DataSource = dtSoItemDetails;
                    gvSOItemDetails.DataBind();

                    //decimal SOItemTotalValue = 0;
                    for (int i = 0; i < dtSoItemDetails.Rows.Count; i++)
                    {
                        SOItemTotalValue = SOItemTotalValue + decimal.Parse(dtSoItemDetails.Rows[i]["MonthlyBilling"].ToString());
                    }
                    lblSOItemTotalValue.Text = string.Format("{0:f3}", SOItemTotalValue); //SOItemTotalValue.ToString();
                }
            }
        }
    }
    protected void FillSubTotalBillingAmount()
    {
        decimal doubleTotalSale = 0;
        if (lblSOLineTotalValue.Text == "")
        {
            lblSOLineTotalValue.Text = "0";
        }
        if (lblSOItemTotalValue.Text == "")
        {
            lblSOItemTotalValue.Text = "0";
        }

        doubleTotalSale = decimal.Parse(lblSOLineTotalValue.Text.ToString()) + decimal.Parse(lblSOItemTotalValue.Text.ToString());
        txtSubTotal.Text = string.Format("{0:f3}", doubleTotalSale);
    }
    protected void FillddlItemTypeCode(DropDownList ddlItemTypeCode)
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objsales.SaleItemTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlItemTypeCode.DataSource = ds.Tables[0];
            ddlItemTypeCode.DataTextField = "ItemDesc";
            ddlItemTypeCode.DataValueField = "ItemTypeCode";
            ddlItemTypeCode.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlItemTypeCode.Items.Add(li);
        }
    }
    #region GridView  SaleOrderItemDetails Commands Events
    protected void gvSOItemDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvSOItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsWriteAccess == false && IsModifyAccess == false) || txtInvNo.Text == "" || hfInvStatus.Value.ToString() == strStatusAuthorized || hfInvStatus.Value.ToString() == strStatusReversal)
        {
            gvSOItemDetails.Columns[0].Visible = false;
        }
        else
        {
            gvSOItemDetails.Columns[0].Visible = true;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvSOItemDetails.PageIndex * gvSOItemDetails.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            else
            {
                if (hfInvStatus.Value.ToString() != strStatusFresh && hfInvStatus.Value.ToString() != strStatusAmend)
                {
                    ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                    if (ImgbtnDelete != null)
                    {
                        ImgbtnDelete.Visible = false;
                    }
                }
                else
                {
                    ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                    if (ImgbtnDelete != null)
                    {
                        ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }
                }
            }
            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                if (hfInvStatus.Value.ToString() != strStatusFresh && hfInvStatus.Value.ToString() != strStatusAmend && hfInvStatus.Value.ToString() != "")
                {
                    ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                    if (ImgbtnEdit != null)
                    {
                        ImgbtnEdit.Visible = false;
                    }
                }
                else
                {
                    ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                    if (ImgbtnUpdate != null)
                    {
                        ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }
                    TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
                    if (txtQty != null)
                    {
                        txtQty.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                        txtQty.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    }
                    TextBox txtRate = (TextBox)e.Row.FindControl("txtRate");
                    if (txtRate != null)
                    {
                        txtRate.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                        txtRate.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    }
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvSOItemDetails.ShowFooter = false;
            }
            else
            {
                if (hfInvStatus.Value.ToString() != strStatusFresh && hfInvStatus.Value.ToString() != strStatusAmend)
                {
                    gvSOItemDetails.ShowFooter = false;
                }
                else
                {
                    //gvSOItemDetails.ShowFooter = true;
                    gvSOItemDetails.ShowFooter = false;
                    DropDownList ddlItemTypeCode = (DropDownList)e.Row.FindControl("ddlItemTypeCode");
                    FillddlItemTypeCode(ddlItemTypeCode);
                    ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                    if (ImgbtnAdd != null)
                    {
                        ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }
                    TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
                    if (txtQty != null)
                    {
                        txtQty.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                        txtQty.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    }
                    TextBox txtRate = (TextBox)e.Row.FindControl("txtRate");
                    if (txtRate != null)
                    {
                        txtRate.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                        txtRate.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    }
                    TextBox txtItemStartDate = (TextBox)e.Row.FindControl("txtItemStartDate");
                    TextBox txtItemEndDate = (TextBox)e.Row.FindControl("txtItemEndDate");
                    HyperLink HlimgItemStartDate = (HyperLink)e.Row.FindControl("HlimgItemStartDate");
                    HyperLink HlimgItemEndDate = (HyperLink)e.Row.FindControl("HlimgItemEndDate");
                    if (txtItemStartDate != null)
                    {
                        txtItemStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtItemEndDate != null)
                    {
                        txtItemEndDate.Attributes.Add("readonly", "readonly");
                    }
                    if (HlimgItemStartDate != null)
                    {
                        HlimgItemStartDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtItemStartDate.ClientID.ToString() + "');";
                    }
                    if (HlimgItemEndDate != null)
                    {
                        HlimgItemEndDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtItemEndDate.ClientID.ToString() + "');";
                    }
                }
            }
        }
        gvSOItemDetails.Columns[2].Visible = false;
        gvSOItemDetails.Columns[8].Visible = false;
        gvSOItemDetails.Columns[9].Visible = false;
    }
    protected void gvSOItemDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvSOItemDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Invoice objInvoice = new BL.Invoice();
        DataSet ds = new DataSet();

        HiddenField hfgvItemTypeCode = (HiddenField)gvSOItemDetails.Rows[e.RowIndex].FindControl("hfgvItemTypeCode");
        Label lblgvQty = (Label)gvSOItemDetails.Rows[e.RowIndex].FindControl("lblgvQty");
        Label lblgvRate = (Label)gvSOItemDetails.Rows[e.RowIndex].FindControl("lblgvRate");
        HiddenField hfieldSOLineItemStartDate = (HiddenField)gvSOItemDetails.Rows[e.RowIndex].FindControl("hfieldSOLineItemStartDate");
        HiddenField hfieldSOLineItemEndDate = (HiddenField)gvSOItemDetails.Rows[e.RowIndex].FindControl("hfieldSOLineItemEndDate");
        Label lblgvAmendNo = (Label)gvSOItemDetails.Rows[e.RowIndex].FindControl("lblgvAmendNo");
        TextBox txtSOLineItemRemarks = (TextBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("txtSOLineItemRemarks");
        TextBox txtItemMonthlyBilling = (TextBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("txtItemMonthlyBilling");



        string strLocationAutoId = BaseLocationAutoID.ToString();
        string strSONO = txtSoNo.Text;
        string strInvoiceNo = txtInvNo.Text;
        string strSOAmendNO = "";
        string strItemTypeCode = "";
        string strQty = "";
        string strRate = "";
        string strItemStartDate = "";
        string strItemEndDate = "";
        string struserID = BaseUserID.ToString();
        string strSOItemRemarks = "";

        if (hfgvItemTypeCode != null && lblgvQty != null && lblgvRate != null && lblgvAmendNo != null && hfieldSOLineItemStartDate != null && hfieldSOLineItemEndDate != null && txtSOLineItemRemarks != null)
        {
            strSOAmendNO = lblgvAmendNo.Text;
            strItemTypeCode = hfgvItemTypeCode.Value.ToString();
            strQty = lblgvQty.Text;
            strRate = lblgvRate.Text;
            strItemStartDate = hfieldSOLineItemStartDate.Value.ToString();
            strItemEndDate = hfieldSOLineItemEndDate.Value.ToString();
            strSOItemRemarks = txtSOLineItemRemarks.Text;
            if (strSOAmendNO != "" && strItemTypeCode != "" && strQty != "" && strRate != "" && strItemStartDate != "" && strItemEndDate != "" && txtItemMonthlyBilling.Text != "")
            {
                ds = objInvoice.InvoiceItemDetailsUpdate(strLocationAutoId, strInvoiceNo, strSONO, strSOAmendNO, strItemTypeCode, strQty, strRate, strItemStartDate, strItemEndDate, strSOItemRemarks, txtItemMonthlyBilling.Text, struserID);

                gvSOItemDetails.EditIndex = -1;
                FillInvoiceHeader();
                FillgvSaleOrderItemDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
        }
    }
    protected void gvSOItemDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSOItemDetails.EditIndex = e.NewEditIndex;
        FillgvSaleOrderItemDetails();
    }
    protected void gvSOItemDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSOItemDetails.EditIndex = -1;
        FillgvSaleOrderItemDetails();
    }
    #endregion
    #endregion

    #region Controles Events
    protected void txtTax_TextChanged(object sender, EventArgs e)
    {
        CalculateGrandTotal();
    }
    protected void CalculateGrandTotal()
    {
        decimal doubleTotalAmount = 0;
        decimal doubleSubTotal = 0;
        decimal doubleTax = 0;
        decimal doubleGrandTotal = 0;

        if (txtSubTotal.Text == "")
        {
            doubleSubTotal = 0;
        }
        else
        {
            doubleSubTotal = decimal.Parse(txtSubTotal.Text);
        }
        if (txtTax.Text == "")
        {
            doubleTax = 0;
        }
        else
        {
            doubleTax = decimal.Parse(txtTax.Text);
        }
        if (txtGrandTotal.Text == "")
        {
            doubleGrandTotal = 0;
        }
        else
        {
            doubleGrandTotal = decimal.Parse(txtGrandTotal.Text);
        }
        doubleTotalAmount = doubleSubTotal + (doubleSubTotal * doubleTax) / 100;
        txtGrandTotal.Text = string.Format("{0:f3}", doubleTotalAmount);
    }
    protected void txtInvNo_TextChanged(object sender, EventArgs e)
    {
        GetSelectedInvoice();
    }
    protected void txtSoNo_TextChanged(object sender, EventArgs e)
    {
        if (txtSoNo.Text != "")
        {
            GetSelectedSaleOrder();
        }
    }
    protected void txtClientCode_TextChanged(object sender, EventArgs e)
    {
        FillClientName();
    }
    #endregion

    #region Buttons Events
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (ValidateProceed() == true)
        {
            btnSave.Visible = true;
            FillgvSaleOrderDetails();
            FillgvSaleOrderItemDetails();
            FillSubTotalBillingAmount();
            CalculateGrandTotal();
        }
    }
    protected bool ValidateProceed()
    {
        if (HFTerminationDate.Value != "" && txtPeriodFrom.Text != "")
        {
            if (DateTime.Parse(HFTerminationDate.Value) < DateTime.Parse(txtPeriodFrom.Text))
            {
                lblErrorMsg.Text = Resources.Resource.InvoicecannotbeGeneratedassaleOrderisTerminated;
                return false;
            }
        }
        if (txtInvNo.Text != "" || txtInvoiceDate.Text == "" || txtClientCode.Text == "" || txtSoNo.Text == "" || txtBillingID.Text == "" || txtPeriodFrom.Text == "" || txtPeriodTo.Text == "")
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataSet dsCheckInvoice = new DataSet();
        BL.Invoice objInvoiceDetails = new BL.Invoice();
        if (hfInvStatus.Value.ToString() == strStatusFresh || hfInvStatus.Value.ToString() == "")
        {
            if (ValidateInvoiceToSave() == true)
            {
                dsCheckInvoice = objInvoiceDetails.CheckInvoicePeriod(BaseLocationAutoID, txtClientCode.Text, txtSoNo.Text, txtPeriodFrom.Text, txtPeriodTo.Text, strStatusReversal, strStatusDelete);
                if (dsCheckInvoice != null && dsCheckInvoice.Tables.Count > 0 && dsCheckInvoice.Tables[0].Rows.Count > 0)
                {
                    if (dsCheckInvoice.Tables[0].Rows[0]["MessageID"].ToString() == "5")
                    {
                        if (txtTax.Text.Length == 0 || txtGrandTotal.Text.Length == 0)
                        {
                            CalculateGrandTotal();
                        }
                        ds = objInvoiceDetails.InvoiceHeaderInsert(BaseLocationAutoID, "0", DateTime.Parse(txtInvoiceDate.Text), strStatusFresh, ddlInvoiceType.SelectedItem.Value.ToString(), txtClientCode.Text, txtClientName.Text, txtSoNo.Text, txtBillingID.Text, txtBillingAddress.Text, DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text), txtRemarks.Text, decimal.Parse(txtSubTotal.Text), decimal.Parse(txtTax.Text), decimal.Parse(txtGrandTotal.Text), dtSoDetails, dtSoItemDetails, BaseUserID, "I", DateTime.Parse(txtPostingDate.Text));
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                        {
                            txtInvNo.Text = ds.Tables[1].Rows[0]["InvoiceNo"].ToString();
                            lblInvStatus.Text = Resources.Resource.Fresh.ToString();
                            hfInvStatus.Value = strStatusFresh;
                            GetSelectedInvoice();
                            ViewMode();
                        }
                        else
                        {
                            lblErrorMsg.Text = "";
                        }
                    }
                    else
                    {
                        DisplayMessage(lblErrorMsg, dsCheckInvoice.Tables[0].Rows[0]["MessageID"].ToString());
                    }
                }
            }
        }
    }
    protected bool ValidateInvoiceToSave()
    {
        if (txtInvoiceDate.Text == "" || txtPeriodFrom.Text == "" || txtPeriodTo.Text == "" || txtClientCode.Text == "" || txtSoNo.Text == "" || txtBillingID.Text == "" || txtBillingAddress.Text == "" || ddlInvoiceType.SelectedItem.Value.ToString() == "")
        { return false; }
        if (GetGreaterDate(DateTime.Parse(txtPeriodTo.Text), DateTime.Parse(txtPeriodFrom.Text)) == false)
        { return false; }
        //if (DateTime.Parse(txtPostingDate.Text)< DateTime.Parse(txtInvoiceDate.Text))
        //{ return false; }
        else
        { return true; }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (txtClientCode.Text.Length != 0)
        {
            Response.Redirect("../Invoice/SaleOrderListForInv.aspx?ClientCode=" + txtClientCode.Text);
        }
        else
        {
            Response.Redirect("../Invoice/SaleOrderListForInv.aspx");
        }
    }
    protected void btnRefetch_Click(object sender, EventArgs e)
    {
        RefetchSoDetails();
        RefetchSoItemDetails();
        FillSubTotalBillingAmount();
        CalculateGrandTotal();
        DataSet ds = new DataSet();
        BL.Invoice objInvoiceDetails = new BL.Invoice();
        ds = objInvoiceDetails.InvoiceHeaderInsert(BaseLocationAutoID, txtInvNo.Text, DateTime.Parse(txtInvoiceDate.Text), strStatusFresh, ddlInvoiceType.SelectedItem.Value.ToString(), txtClientCode.Text, txtClientName.Text, txtSoNo.Text, txtBillingID.Text, txtBillingAddress.Text, DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text), txtRemarks.Text, decimal.Parse(txtSubTotal.Text), decimal.Parse(txtTax.Text), decimal.Parse(txtGrandTotal.Text), dtSoDetails, dtSoItemDetails, BaseUserID, "R", DateTime.Parse(txtPostingDate.Text));
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
        {
            txtInvNo.Text = ds.Tables[1].Rows[0]["InvoiceNo"].ToString();
            lblInvStatus.Text = Resources.Resource.Fresh.ToString();
            hfInvStatus.Value = strStatusFresh;
            GetSelectedInvoice();
            ViewMode();
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Invoice objInvoiceDetails = new BL.Invoice();
        if (hfInvStatus.Value.ToString() == strStatusFresh || hfInvStatus.Value.ToString() == "")
        {
            if (txtInvNo.Text != "" && txtInvoiceDate.Text != "" && txtClientCode.Text != "" && txtSoNo.Text != "" && txtBillingID.Text != "" && ddlInvoiceType.SelectedItem.Value.ToString() != "")
            {
                ds = objInvoiceDetails.InvoiceHeaderUpdate(BaseLocationAutoID, txtInvNo.Text, txtInvoiceDate.Text, txtRemarks.Text, decimal.Parse(txtSubTotal.Text), decimal.Parse(txtTax.Text), decimal.Parse(txtGrandTotal.Text), BaseUserID, DateTime.Parse(txtPostingDate.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    GetSelectedInvoice();
                    ViewMode();
                }
                else
                {
                    lblErrorMsg.Text = "";
                }
            }
        }
    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Invoice/RptInvInvoice.aspx?InvoiceNo=" + txtInvNo.Text + "&InvoiceDate=" + txtInvoiceDate.Text + "&InvoiceStatus=" + hfInvStatus.Value.ToString());
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Invoice objInvoice = new BL.Invoice();

        if (hfInvStatus.Value.ToString() == strStatusFresh)
        {
            ds = objInvoice.InvoiceAuthorized(BaseLocationAutoID, txtInvNo.Text, strStatusAuthorized, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                btnSave.Visible = false;
                ViewMode();
                GetSelectedInvoice();

            }
        }
        else
        {
            //cant update
        }
    }
    protected void btnReversal_Click(object sender, EventArgs e)
    {
        txtRevInvoiceDate.Text = txtInvoiceDate.Text;
        txtrevInvoiceNumber.Text = txtInvNo.Text;
        upReversal.Update();
        ModalPopupExtender1.Show();

        //DataSet ds = new DataSet();
        //BL.Invoice objInvoice = new BL.Invoice();

        //if (hfInvStatus.Value.ToString() == strStatusAuthorized)
        //{
        //    ds = objInvoice.blInvoiceReversal(BaseLocationAutoID, txtInvNo.Text, strStatusReversal, BaseUserID);
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        //        ViewMode();
        //        GetSelectedInvoice();
        //    }
        //}
        //else
        //{
        //    //cant update
        //}
    }
    protected void btnReversalCancel_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
    }
    protected void btnRevSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Invoice objInvoice = new BL.Invoice();
        if (hfInvStatus.Value.ToString() == strStatusAuthorized)
        {
            if (DateTime.Parse(txtPostingDate.Text) <= DateTime.Parse(txtReversalDate.Text))
            {
                ds = objInvoice.InvoiceReversal(BaseLocationAutoID, txtInvNo.Text, strStatusReversal, BaseUserID, txtrevReason.Text, DateTime.Parse(txtReversalDate.Text), txtClientCode.Text, txtSoNo.Text, DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text), DateTime.Parse(txtInvoiceDate.Text));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MessageID"].ToString() != "8")
                    {
                        ModalPopupExtender1.Hide();
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        ViewMode();
                        GetSelectedInvoice();
                        up1.Update();
                    }
                    else
                    {
                        DisplayMessageString(lblRevErrormsg, Resources.Resource.MsgInvoiceDateShouldbegreaterthanorequaltoReversalDate);
                    }
                }
            }
            else
            {
                DisplayMessageString(lblRevErrormsg, Resources.Resource.MsgPostingDateShouldBeLessthanOrEqualtoReversalDate);
            }
        }
        else
        {
            //cant update
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Invoice objInvoice = new BL.Invoice();
        if (hfInvStatus.Value.ToString() == strStatusFresh)
        {
            ds = objInvoice.InvoiceDeletion(BaseLocationAutoID, txtInvNo.Text, strStatusDelete, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                btnSave.Visible = false;
                ViewMode();
                GetSelectedInvoice();

            }
        }
        else
        {
            //cant update
        }

    }
    #endregion

    # region Other Funcitons
    protected void RefetchSoDetails()
    {
        DataSet ds = new DataSet();
        int dtflag;
        dtflag = 1;
        BL.Invoice objInvoice = new BL.Invoice();
        ds = objInvoice.SaleOrderDetailsGet(BaseLocationAutoID, txtSoNo.Text, txtPeriodFrom.Text, txtPeriodTo.Text, ddlInvoiceType.SelectedItem.Value.ToString(), strStatusAuthorized);

        if (ds != null && ds.Tables.Count > 0)
        {
            dtSoDetails = ds.Tables[0];
            //to fix empety gridview
            if (dtSoDetails.Rows.Count == 0)
            {
                dtflag = 0;
                dtSoDetails.Rows.Add(dtSoDetails.NewRow());
                gvSaleOrderDetails.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "SoLineNo" };
                gvSaleOrderDetails.DataSource = dtSoDetails;
                gvSaleOrderDetails.DataBind();

                if (dtflag == 0)//to fix empety gridview
                {
                    gvSaleOrderDetails.Rows[0].Visible = false;
                }
            }
            else if (dtSoDetails.Rows.Count > 0)
            {
                decimal SOLineTotalValue = 0;
                for (int i = 0; i < dtSoDetails.Rows.Count; i++)
                {
                    if (ddlInvoiceType.SelectedItem.Value.ToString() == "FIXED" && txtInvNo.Text != "")
                    {
                        SOLineTotalValue = SOLineTotalValue + decimal.Parse(dtSoDetails.Rows[i]["MonthlyBilling"].ToString());
                    }
                    else if (ddlInvoiceType.SelectedItem.Value.ToString() == "ACTUAL DAYS IN MONTH" && txtInvNo.Text != "")
                    {
                        SOLineTotalValue = SOLineTotalValue + decimal.Parse(dtSoDetails.Rows[i]["MonthlyBilling"].ToString());

                    }
                    else
                    {
                        SOLineTotalValue = SOLineTotalValue + decimal.Parse(dtSoDetails.Rows[i]["ActualMonthlyBilling"].ToString());
                    }
                }
                lblSOLineTotalValue.Text = string.Format("{0:f3}", SOLineTotalValue);

                gvSaleOrderDetails.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "SoLineNo" };
                gvSaleOrderDetails.DataSource = dtSoDetails;
                gvSaleOrderDetails.DataBind();
            }
        }

    }
    protected void RefetchSoItemDetails()
    {
        DataSet ds = new DataSet();
        int dtflag;
        dtflag = 1;
        BL.Invoice objInvoice = new BL.Invoice();
        ds = objInvoice.SaleOrderItemDetailsGet(BaseLocationAutoID, txtSoNo.Text, txtPeriodFrom.Text, txtPeriodTo.Text, strStatusAuthorized);

        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                dtSoItemDetails = ds.Tables[0];
                //to fix empety gridview
                if (dtSoItemDetails.Rows.Count == 0)
                {
                    dtflag = 0;
                    dtSoItemDetails.Rows.Add(dtSoItemDetails.NewRow());
                    gvSOItemDetails.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "ItemTypeCode" };
                    gvSOItemDetails.DataSource = dtSoItemDetails;
                    gvSOItemDetails.DataBind();
                    if (dtflag == 0)//to fix empety gridview
                    {
                        gvSOItemDetails.Rows[0].Visible = false;
                    }
                }
                else if (dtSoItemDetails.Rows.Count > 0)
                {
                    gvSOItemDetails.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "ItemTypeCode" };
                    gvSOItemDetails.DataSource = dtSoItemDetails;
                    gvSOItemDetails.DataBind();

                    decimal SOItemTotalValue = 0;
                    for (int i = 0; i < dtSoItemDetails.Rows.Count; i++)
                    {
                        SOItemTotalValue = SOItemTotalValue + decimal.Parse(dtSoItemDetails.Rows[i]["MonthlyBilling"].ToString());
                    }
                    lblSOItemTotalValue.Text = string.Format("{0:f3}", SOItemTotalValue); //SOItemTotalValue.ToString();
                }
            }
        }

    }
    #endregion

    #region Page Modes
    protected void ViewMode()
    {
        HlimgInvoiceDate.Enabled = false;
        HlimgPeriodFrom.Enabled = false;
        HlimgPeriodTo.Enabled = false;
        ddlInvoiceType.Enabled = false;
        txtRemarks.Enabled = false;
        txtTax.Enabled = false;
        txtPostingDate.Enabled = false;
        IMGPostingDate.Enabled = false;

        btnProceed.Visible = false;
        btnRefetch.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnViewReport.Visible = false;
        btnReversal.Visible = false;
        btnAuthorize.Visible = false;

        btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
        btnReversal.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
        btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
        btnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
        if (hfInvStatus.Value.ToString() == strStatusFresh && txtInvNo.Text != "" && IsDeleteAccess == true)
        {
            btnDelete.Visible = true;
        }

        if (hfInvStatus.Value.ToString() == strStatusFresh && txtInvNo.Text != "" && IsModifyAccess == true)
        {
            HlimgInvoiceDate.Enabled = true;
            btnUpdate.Visible = true;
            if (IsAuthorizationAccess == true)
            {
                btnAuthorize.Visible = true;
            }
            else
            {
                btnAuthorize.Visible = false;
            }
            txtRemarks.Enabled = true;
            txtTax.Enabled = true;
            //btnDelete.Visible = true;
            btnRefetch.Visible = true;
            btnViewReport.Visible = true;
        }
        else if (hfInvStatus.Value.ToString() == strStatusFresh && txtInvNo.Text == "" && IsWriteAccess == true)
        {
            btnSave.Visible = true;
            btnProceed.Visible = true;

            HlimgInvoiceDate.Enabled = true;
            HlimgPeriodFrom.Enabled = true;
            HlimgPeriodTo.Enabled = true;
            ddlInvoiceType.Enabled = true;
            txtRemarks.Enabled = true;
            txtTax.Enabled = true;
        }
        else if (hfInvStatus.Value.ToString() == strStatusAuthorized && IsModifyAccess == true)
        {
            btnReversal.Visible = true;
            btnViewReport.Visible = true;
        }
        else if (hfInvStatus.Value.ToString() == strStatusAuthorized)
        {
            btnViewReport.Visible = true;
        }
    }
    protected void AddNewMode()
    {
        if (IsWriteAccess == true)
        {
            txtInvNo.Text = "";
            lblInvStatus.Text = "";
            hfInvStatus.Value = "";
            txtRemarks.Text = "GUARDING SERVICES AS PER ATTACHED SCHEDULE";

            HlimgInvoiceDate.Enabled = true;
            HlimgPeriodFrom.Enabled = true;
            HlimgPeriodTo.Enabled = true;
            txtPostingDate.Enabled = true;
            IMGPostingDate.Enabled = true;

            gvSaleOrderDetails.DataSource = null;
            gvSaleOrderDetails.DataBind();

            gvSOItemDetails.DataSource = null;
            gvSOItemDetails.DataBind();

            lblSOLineTotalValue.Text = "0";
            lblSOItemTotalValue.Text = "0";

            btnProceed.Visible = true;
            btnRefetch.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnReversal.Visible = false;
            btnAuthorize.Visible = false;
        }
        else
        {
            txtInvNo.Text = "";
            lblInvStatus.Text = "";
            hfInvStatus.Value = "";
            txtRemarks.Text = "";

            HlimgInvoiceDate.Enabled = false;
            HlimgPeriodFrom.Enabled = false;
            HlimgPeriodTo.Enabled = false;
            txtPostingDate.Enabled = false;
            IMGPostingDate.Enabled = false;

            gvSaleOrderDetails.DataSource = null;
            gvSaleOrderDetails.DataBind();

            gvSOItemDetails.DataSource = null;
            gvSOItemDetails.DataBind();

            lblSOLineTotalValue.Text = "0";
            lblSOItemTotalValue.Text = "0";

            btnProceed.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnRefetch.Visible = false;
            btnDelete.Visible = false;
            btnReversal.Visible = false;
            btnAuthorize.Visible = false;
            btnViewReport.Visible = false;
        }
    }
    #endregion

}