using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;

public partial class Sales_AssetWorkOrderMaster : BasePage
{
    #region Properties

    /// <summary>
    /// This is the format used to hold the Assignment and Location ID Details
    /// </summary>
    private String AssignmentLocationComboFormatString = "{0}:{1},";

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsReadAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsWriteAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsModifyAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsDeleteAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                var bp = new BasePage();
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets or sets a value to Grid View Sort Direction
    /// </summary>
    /// <value>The grid view sort direction.</value>
    protected SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }

            return (SortDirection)ViewState["sortDirection"];
        }

        set
        {
            ViewState["sortDirection"] = value;
        }
    }
    #endregion

    #region Page Functions

    /// <summary>
    /// Used for Paging in grid view
    /// </summary>
    static int _index;

    /// <summary>
    /// Page Load event
    /// </summary>
    /// <param name="sender">object of control</param>
    /// <param name="e">Event Args</param>

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                //hfspDecimalPlace.Value = "{0:F" + BaseDigitsAfterDecimalPlaces + "}";

                var objSales = new BL.Sales();
                var ds = objSales.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);

                txtAssetWoNo.Attributes.Add("onKeyDown", "javascript:TextBox_onkeyDown('" + txtAssetWoNo.ClientID + "')");
                txtClientCode.Attributes.Add("onKeyDown", "javascript:TextBox_onkeyDown('" + txtClientCode.ClientID + "')");
                txtClientCode.Attributes.Add("onKeyDown", "if(event.keyCode==13){event.keyCode=9;return event.keyCode;}");
                ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH007&ControlId=" + txtClientCode.ClientID + "&Company=" + BaseCompanyCode + "&HrLocation=&Location=" + BaseLocationCode + "', null,'status=off, center=yes, scrollbars=1, resizeable=1, Width=700px, Height=350, help=no')");
                txtAssetWoNo.Attributes.Add("readonly", "readonly");
                txtAssetWOAmendDate.Attributes.Add("readonly", "readonly");
                txtClientName.Attributes.Add("readonly", "readonly");
                txtWefdt.Attributes.Add("readonly", "readonly");
                txtTerminationDate.Attributes.Add("readonly", "readonly");
                if (Request.QueryString["AssetWoNo"] != null && Request.QueryString["AssetWoNo"] != "0")
                {
                    txtAssetWoNo.Text = Request.QueryString["AssetWoNo"];
                    if (txtAssetWoNo.Text != string.Empty)
                    {
                        FillddlAssetWOAmendNO(txtAssetWoNo.Text);
                        ViewMode();
                    }
                }
                else
                {
                    AddNewMode();
                    btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].Length > 0)
                    {
                        txtClientCode.Text = Request.QueryString["ClientCode"];
                        FillClientName();
                        FillddlClientBillingId();
                    }
                }

                if (IsWriteAccess && Request.QueryString["WefDate"] != null && Request.QueryString["WefDate"].Length > 0)
                {
                    txtWefdt.Text = Request.QueryString["WefDate"];
                    if (txtWefdt.Text != string.Empty && txtClientCode.Text != string.Empty)
                    {
                        SaleOrderHeaderSave();
                        Response.Redirect("AssetWorkOrderMaster.aspx?AssetWoNo=" + txtAssetWoNo.Text);
                    }
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
        btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
    }
    #endregion

    #region GridView SaleOrderServicedetails Controles Events

    /// <summary>
    /// Function to Fill the Sale Order Service Details Grid View.
    /// </summary>
    /// <param name="strFilterAsmtId">Assignment Id to Filter</param>
    protected void FillgvWorkOrderDetails()
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        var ds = BaseUserIsAreaIncharge == "1"
            ? objAssetWorkOrder.AssetWorkOrderDetailGet(BaseLocationAutoID, txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedItem.Value, BaseUserEmployeeNumber)
            : objAssetWorkOrder.AssetWorkOrderDetailGet(BaseLocationAutoID, txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedItem.Value);

        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    dt.Rows[0]["Billable"] = true;
                    dt.Rows[0]["Active"] = true;
                    gvWorkOrderDetails.DataSource = dt;
                    gvWorkOrderDetails.DataBind();
                    gvWorkOrderDetails.Rows[0].Visible = false;
                }
                else if (dt.Rows.Count > 0)
                {
                    hfTotalRowCount.Value = dt.Rows.Count.ToString();
                    gvWorkOrderDetails.DataSource = dt;
                    gvWorkOrderDetails.DataBind();
                }
            }

            gvWorkOrderDetails.PagerStyle.HorizontalAlign = HorizontalAlign.Left;
            gvWorkOrderDetails.BottomPagerRow.Visible = true;
        }

    }
    #endregion

    #region Controles Binding

    /// <summary>
    /// To Fill the Screen Controls with current SaleOrder Values
    /// </summary>
    protected void GetSelectedAssetWorkOrder()
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        var strAssetWoAmendNo = ddlAssetWOAmendNO.Items.Count == 0 ? "-1" : ddlAssetWOAmendNO.SelectedItem.Value;

        var ds = objAssetWorkOrder.AssetWorkOrderGet(BaseLocationAutoID, txtAssetWoNo.Text, strAssetWoAmendNo);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            FillControles(ds);
            FillgvWorkOrderDetails();
        }
        else
        {
            ClearControles();
        }
    }

    /// <summary>
    /// To clear the Data From The Sale Order Header Screen
    /// </summary>
    protected void ClearControles()
    {
        lblWOStatus.Text = string.Empty;
        hiddenFieldWoStatus.Value = string.Empty;
        txtAssetWOAmendDate.Text = string.Empty;
        txtClientCode.Text = string.Empty;
        txtClientName.Text = string.Empty;
        txtTerminationDate.Text = string.Empty;
        txtTerminationReason.Text = string.Empty;
        txtTerminatedBy.Text = string.Empty;
    }

    /// <summary>
    /// To Fill the Controls with values Related to the Selected Sale Order.
    /// </summary>
    /// <param name="ds">Data Set</param>
    protected void FillControles(DataSet ds)
    {

        lblWOStatus.Text = ResourceValueOfKeyOnlyforStatus_Get(ds.Tables[0].Rows[0]["WOStatus"].ToString());

        hiddenFieldWoStatus.Value = ds.Tables[0].Rows[0]["WOStatus"].ToString();
        txtAssetWOAmendDate.Text = DateFormat(ds.Tables[0].Rows[0]["AssetWOAmendDate"].ToString());
        txtWefdt.Text = DateFormat(ds.Tables[0].Rows[0]["WefDate"].ToString());
        txtClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
        txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        FillddlClientBillingId();
        ddlAsmtBillingId.SelectedValue = ds.Tables[0].Rows[0]["AsmtBillingId"].ToString() == "" ? "" : ds.Tables[0].Rows[0]["AsmtBillingId"].ToString();
        txtTerminationDate.Text = DateFormat(ds.Tables[0].Rows[0]["WOTerminationDate"].ToString());
        txtTerminationReason.Text = ds.Tables[0].Rows[0]["WOTerminationReason"].ToString();
        txtTerminatedBy.Text = ds.Tables[0].Rows[0]["WOTerminatedBy"].ToString();
        ddlInvoiceType.SelectedValue = ds.Tables[0].Rows[0]["BillingPattern"].ToString().ToUpper().Trim();
        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
    }

    /// <summary>
    /// Function to Fill the Client Billing Addresses
    /// </summary>
    protected void FillddlClientBillingId()
    {
        var objSales = new BL.Sales();
        ddlAsmtBillingId.Items.Clear();
        using (var ds = objSales.AsmtBillingIdGet(BaseLocationAutoID, txtClientCode.Text))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    ddlAsmtBillingId.DataSource = ds.Tables[0];
                    ddlAsmtBillingId.DataValueField = "AsmtId";
                    ddlAsmtBillingId.DataTextField = "AsmtIdAddress";
                    ddlAsmtBillingId.DataBind();
                }
                catch (Exception ex) { }
            }
        }
        var li = new ListItem(Resources.Resource.NotRequired, string.Empty);
        ddlAsmtBillingId.Items.Add(li);

    }

    /// <summary>
    /// To fill the Sale Order Amendment Numbers for the Given Sale Order
    /// </summary>
    /// <param name="strAssetWoNo">so no</param>
    protected void FillddlAssetWOAmendNO(string strAssetWoNo)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        var ds = objAssetWorkOrder.AssetWorkOrderAmendNoGet(BaseLocationAutoID, txtAssetWoNo.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAssetWOAmendNO.DataSource = ds.Tables[0];
            ddlAssetWOAmendNO.DataTextField = "AssetWOAmendNo";
            ddlAssetWOAmendNO.DataValueField = "AssetWOAmendNo";
            ddlAssetWOAmendNO.DataBind();
            ddlAssetWOAmendNO.SelectedIndex = 0;
            hfIsMAXAssetWOAmendNo.Value = "MAX";
            GetSelectedAssetWorkOrder();
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlAssetWOAmendNO.Items.Add(li);
        }
    }

    /// <summary>
    /// Function to Fill the Client Names in Drop Down List
    /// </summary>
    protected void FillClientName()
    {
        if (txtClientCode.Text != string.Empty)
        {
            var objSales = new BL.Sales();
            var ds = objSales.ClientNameDetailGet(txtClientCode.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                FillddlClientBillingId();
            }
            else
            {
                txtClientCode.Text = string.Empty;
                DisplayMessage(lblErrorMsg, "4");
            }
        }
    }

    /// <summary>
    /// Function to fill the Dropdown with The Invoice Type of a SaleOrder.
    /// </summary>
    protected void FillddlInvoiceType()
    {
        var li = new ListItem(Resources.Resource.InvoiceTypeFixed, @"FIXED");
        ddlInvoiceType.Items.Add(li);
        li = new ListItem(Resources.Resource.InvoiceTypeActual, @"ACTUAL");
        ddlInvoiceType.Items.Add(li);
        li = new ListItem(Resources.Resource.ActualDaysInMonth, @"ACTUAL DAYS IN MONTH");
        ddlInvoiceType.Items.Add(li);
        li = new ListItem(Resources.Resource.AsPerSchedule, @"AS PER SCHEDULE");
        ddlInvoiceType.Items.Add(li);
    }
    #endregion

    #region Controles Events

    protected void txtAssetWoNo_TextChanged(object sender, EventArgs e)
    {
        if (txtAssetWoNo.Text != string.Empty)
        {
            GetSelectedAssetWorkOrder();
        }
    }

    /// <summary>
    /// To set the validation on TextBox for decimal values
    /// </summary>
    /// <param name="textBox">object of the control</param>
    protected void SetFloatValidationToTextBox(object textBox)
    {
        if (textBox != null)
        {
            var floatTextBox = (TextBox)textBox;
            floatTextBox.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
            floatTextBox.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
        }
    }

    /// <summary>
    /// on change of Amendment No
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void ddlAssetWOAmendNO_SelectedIndexChanged(object sender, EventArgs e)
    {
        hfIsMAXAssetWOAmendNo.Value = ddlAssetWOAmendNO.SelectedIndex == 0 ? "MAX" : "NOTMAX";
        GetSelectedAssetWorkOrder();
        ViewMode();
    }

    /// <summary>
    /// on change of client code in header of sale order
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void TxtClientCode_TextChanged(object sender, EventArgs e)
    {
        FillClientName();
    }

    #endregion

    #region Page Modes

    /// <summary>
    /// To Open the Sale order in View only mode
    /// </summary>
    protected void ViewMode()
    {
        txtAssetWoNo.Enabled = true;
        ddlAssetWOAmendNO.Enabled = true;
        txtClientCode.Enabled = false;
        ImgBtnSearchClient.Enabled = false;
        ddlAsmtBillingId.Enabled = false;

        txtTerminationDate.Enabled = false;
        HlimgTerminationDate.Enabled = false;
        txtTerminationReason.Enabled = false;
        txtTerminatedBy.Enabled = false;

        hlWefdt.Enabled = false;
        ddlInvoiceType.Enabled = false;
        txtRemarks.Enabled = false;
        btnDelete.Visible = false;
        btnDelete.Attributes["onclick"] = "javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');javascript:Timerf('" + lblErrorMsg.ClientID + "');";
        if (hiddenFieldWoStatus.Value == string.Empty)
        {
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAmend.Visible = false;
            btnAuthorize.Visible = false;
            btnAsmtCreation.Visible = false;
            btnDelete.Visible = false;
        }
        else if (hiddenFieldWoStatus.Value == strStatusFresh && hfIsMAXAssetWOAmendNo.Value == "MAX")
        {
            btnEdit.Visible = IsModifyAccess;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAmend.Visible = false;
            btnAuthorize.Visible = IsAuthorizationAccess;
            btnDelete.Visible = IsDeleteAccess;
            btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
            btnAsmtCreation.Visible = false;
        }
        else if (hiddenFieldWoStatus.Value == strStatusAmend && hfIsMAXAssetWOAmendNo.Value == "MAX")
        {
            btnEdit.Visible = IsModifyAccess;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAmend.Visible = false;
            btnAuthorize.Visible = IsAuthorizationAccess;
            btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
        }
        else if (hiddenFieldWoStatus.Value == strStatusAuthorized && hfIsMAXAssetWOAmendNo.Value == "MAX")
        {
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;

            if (!IsDeleteAccess)
            {
                btnDelete.Visible = false;
                txtTerminationDate.Enabled = false;
                HlimgTerminationDate.Enabled = false;
                txtTerminationReason.Enabled = false;
                txtTerminatedBy.Enabled = false;
            }
            btnAmend.Visible = IsModifyAccess;
            btnAuthorize.Visible = false;
        }
        else if (hiddenFieldWoStatus.Value == strStatusShortClosed || hiddenFieldWoStatus.Value == strStatusDelete)
        {
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAmend.Visible = false;
            btnAuthorize.Visible = false;
            btnAsmtCreation.Visible = false;
            btnDelete.Visible = false;
        }
        else
        {
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAmend.Visible = false;
            btnAuthorize.Visible = false;
        }
    }

    /// <summary>
    /// To open the Sale order screen in Insert new Sale Order Mode
    /// </summary>
    protected void AddNewMode()
    {
        txtAssetWoNo.Enabled = false;
        ddlAssetWOAmendNO.Enabled = false;
        txtClientCode.Enabled = true;
        ImgBtnSearchClient.Enabled = true;
        ddlAsmtBillingId.Enabled = true;
        txtTerminationDate.Enabled = true;
        HlimgTerminationDate.Enabled = true;
        txtTerminationReason.Enabled = true;
        txtTerminatedBy.Enabled = true;
        ddlInvoiceType.Enabled = true;
        txtRemarks.Enabled = true;
        txtAssetWoNo.Text = string.Empty;
        ddlAssetWOAmendNO.DataSource = string.Empty;
        ddlAssetWOAmendNO.DataBind();
        hfIsMAXAssetWOAmendNo.Value = string.Empty;
        txtAssetWOAmendDate.Text = string.Empty;
        txtWefdt.Text = string.Empty;
        lblWOStatus.Text = Resources.Resource.Fresh;
        hiddenFieldWoStatus.Value = strStatusFresh;
        txtClientCode.Text = string.Empty;
        txtClientName.Text = string.Empty;
        ddlAsmtBillingId.DataSource = string.Empty;
        ddlAsmtBillingId.DataBind();
        txtTerminationDate.Text = string.Empty;
        txtTerminationReason.Text = string.Empty;
        txtTerminatedBy.Text = string.Empty;
        if (hiddenFieldWoStatus.Value == strStatusFresh)
        {
            HlimgTerminationDate.Enabled = false;
        }
        gvWorkOrderDetails.DataSource = null;
        gvWorkOrderDetails.DataBind();
        btnEdit.Visible = false;
        btnSave.Visible = IsWriteAccess;
        btnUpdate.Visible = false;
        btnCancel.Visible = true;
        btnAmend.Visible = false;
        btnAuthorize.Visible = false;
        btnAsmtCreation.Visible = false;
        btnDelete.Visible = false;
    }

    #endregion

    #region Buttons Events

    /// <summary>
    /// Validate the SO Information while updating the so
    /// </summary>
    /// <returns>true or false</returns>
    protected bool SoMasterUpdateValidate()
    {
        bool returnvalue;

        if (txtAssetWoNo.Text == string.Empty || ddlAssetWOAmendNO.SelectedItem.Value == string.Empty ||
            hiddenFieldWoStatus.Value == string.Empty || txtClientCode.Text == string.Empty || txtWefdt.Text == string.Empty
            )
        {
            returnvalue = false;
        }
        else
        {
            returnvalue = true;

        }

        return returnvalue;
    }

    /// <summary>
    /// To edit the So Header information
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        if (hiddenFieldWoStatus.Value == strStatusFresh)
        {
            txtClientCode.Enabled = true;
            ImgBtnSearchClient.Enabled = true;
            ddlAsmtBillingId.Enabled = true;
            txtTerminationDate.Enabled = true;
            HlimgTerminationDate.Enabled = true;
            txtTerminationReason.Enabled = true;
            txtTerminatedBy.Enabled = true;
            hlWefdt.Enabled = true;
            ddlInvoiceType.Enabled = true;
            txtRemarks.Enabled = true;
            btnEdit.Visible = false;
            btnAuthorize.Visible = false;
            btnUpdate.Visible = true;
            btnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
            btnCancel.Visible = true;
        }
        else if (hiddenFieldWoStatus.Value == strStatusAmend && hfIsMAXAssetWOAmendNo.Value == "MAX")
        {
            ddlAsmtBillingId.Enabled = true;
            txtTerminationDate.Enabled = true;
            HlimgTerminationDate.Enabled = true;
            txtTerminationReason.Enabled = true;
            txtTerminatedBy.Enabled = true;
            hlWefdt.Enabled = true;

            txtRemarks.Enabled = true;
            btnEdit.Visible = false;
            btnAuthorize.Visible = false;
            btnUpdate.Visible = true;
            btnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
            btnCancel.Visible = true;
        }
    }

    /// <summary>
    /// To update the So Header Information
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        gvWorkOrderDetails.EditIndex = -1;
        string strMyStatus;
        if (hiddenFieldWoStatus.Value == strStatusFresh)
        {
            strMyStatus = strStatusFresh;
        }
        else if (hiddenFieldWoStatus.Value == strStatusAmend)
        {
            strMyStatus = strStatusAmend;
        }
        else
        {
            strMyStatus = string.Empty;
        }

        if (hiddenFieldWoStatus.Value == strStatusFresh || hiddenFieldWoStatus.Value == strStatusAmend)
        {
            if (SoMasterUpdateValidate())
            {
                var ds = objAssetWorkOrder.AssetWOMasterUpdate(BaseLocationAutoID, txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedItem.Value, txtWefdt.Text, txtClientCode.Text, hiddenFieldWoStatus.Value, txtTerminationDate.Text, txtTerminationReason.Text, txtTerminatedBy.Text, ddlAsmtBillingId.SelectedItem.Value, BaseUserID, strMyStatus, ddlInvoiceType.SelectedItem.Value.ToUpper().Trim(), txtRemarks.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtAssetWoNo.Text = ds.Tables[1].Rows[0]["AssetWONO"].ToString();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())))
                    {
                        if (txtAssetWoNo.Text != string.Empty)
                        {
                            btnSave.Visible = false;
                            btnCancel.Visible = false;
                            FillddlAssetWOAmendNO(txtAssetWoNo.Text);
                            ViewMode();
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// To delete a Fresh Sale Order or to Terminate a Sale Order
    /// </summary>
    /// <param name="sender">object of control</param>
    /// <param name="e">Event Args</param>
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        var objSales = new BL.Sales();
        HlimgTerminationDate.Enabled = true;

        if (hiddenFieldWoStatus.Value == strStatusAmend || hiddenFieldWoStatus.Value == strStatusShortClosed)
        {
            lblErrorMsg.Text = Resources.Resource.DeletionIsNotPossible + @" : " + txtAssetWoNo.Text;
        }
        else if (hiddenFieldWoStatus.Value == strStatusFresh)
        {
            var ds = objSales.SaleOrderDelete(BaseLocationAutoID, txtAssetWoNo.Text, hiddenFieldWoStatus.Value, strStatusFresh, strStatusDelete, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if ((ds.Tables[0].Rows[0]["MessageID"].ToString() == "1") || (ds.Tables[0].Rows[0]["MessageID"].ToString() == "2"))
                {
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    FillddlAssetWOAmendNO(txtAssetWoNo.Text);
                    ViewMode();
                    upWOStatus.Update();
                }
            }
        }

    }

    /// <summary>
    /// to save Sale Order Header
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        SaleOrderHeaderSave();
    }

    /// <summary>
    /// To save Sale Order header Info
    /// </summary>
    protected void SaleOrderHeaderSave()
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        if (hiddenFieldWoStatus.Value == strStatusFresh)
        {
            if (ddlAsmtBillingId.Items.Count > 0)
            {
                if (hiddenFieldWoStatus.Value != string.Empty && txtClientCode.Text != string.Empty && txtWefdt.Text != string.Empty)
                {
                    if (ValidateSaveSaleOrder())
                    {
                        var ds = objAssetWorkOrder.AssetWOMasterSave(BaseLocationAutoID, txtWefdt.Text, txtClientCode.Text, hiddenFieldWoStatus.Value, txtTerminationDate.Text, txtTerminationReason.Text, txtTerminatedBy.Text, ddlAsmtBillingId.SelectedItem.Value, BaseUserID, ddlInvoiceType.SelectedItem.Value.ToUpper().Trim(), txtRemarks.Text);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            txtAssetWoNo.Text = ds.Tables[1].Rows[0]["AssetWONO"].ToString();
                            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                            {
                                DisplayMessageString(lblErrorMsg, "Asset Work Order is ready to Add Service Line's");
                            }
                            else
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }

                            if (txtAssetWoNo.Text != string.Empty)
                            {
                                btnSave.Visible = false;
                                btnCancel.Visible = false;
                                FillddlAssetWOAmendNO(txtAssetWoNo.Text);
                                ViewMode();
                            }
                        }
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.WEFDate + " " + Resources.Resource.AND + " " + Resources.Resource.ClientCode + " " + Resources.Resource.Required);
                }
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.AsmtBillingID + " " + Resources.Resource.Required);
            }
        }
    }

    /// <summary>
    /// To Validate Sale Order Header Information
    /// </summary>
    /// <returns>true if ok, false if fail in validation</returns>
    protected bool ValidateSaveSaleOrder()
    {
        var objSales = new BL.Sales();
        var ds = objSales.ContractNumberGetAll(txtClientCode.Text, strStatusAuthorized);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return true;
        }
        DisplayMessage(lblErrorMsg, "53");
        return false;
    }

    /// <summary>
    /// Sale order header information cancelation after editing
    /// </summary>
    /// <param name="sender">object of control</param>
    /// <param name="e">Event Args</param>
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (txtAssetWoNo.Text == string.Empty)
        {
            AddNewMode();
        }
        else
        {
            FillddlAssetWOAmendNO(txtAssetWoNo.Text);
            ViewMode();
        }
    }

    /// <summary>
    /// To go back to previous screen
    /// </summary>
    /// <param name="sender">object of control</param>
    /// <param name="e">Event Args</param>
    protected void BtnBackClick(object sender, EventArgs e)
    {
        if (txtClientCode.Text.Length != 0)
        {
            Response.Redirect("../Sales/AssetWorkOrderList.aspx?ClientCode=" + txtClientCode.Text);
        }
        else
        {
            Response.Redirect("../Sales/AssetWorkOrderList.aspx");
        }
    }

    /// <summary>
    /// To back to Contract master of the Sale Order
    /// </summary>
    /// <param name="sender">object of control</param>
    /// <param name="e">Event Args</param>
    protected void BtnContract_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ContractMaster.aspx?ClientCode=" + txtClientCode.Text);
    }

    /// <summary>
    /// To authorized the Sale Order
    /// </summary>
    /// <param name="sender">object of control</param>
    /// <param name="e">Event Args</param>
    protected void BtnAuthorize_Click(object sender, EventArgs e)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        gvWorkOrderDetails.EditIndex = -1;
        string strMyStatus;
        if (hiddenFieldWoStatus.Value == strStatusFresh)
        {
            strMyStatus = strStatusFresh;
        }
        else if (hiddenFieldWoStatus.Value == strStatusAmend)
        {
            strMyStatus = strStatusAmend;
        }
        else
        {
            strMyStatus = string.Empty;
        }

        if (hiddenFieldWoStatus.Value == strStatusFresh || hiddenFieldWoStatus.Value == strStatusAmend)
        {
            var ds = objAssetWorkOrder.AssetWorkOrderAuthorized(BaseLocationAutoID, txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedItem.Value, strStatusAuthorized, BaseUserID, strMyStatus);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                btnSave.Visible = false;
                btnCancel.Visible = false;
                FillddlAssetWOAmendNO(txtAssetWoNo.Text);
                ViewMode();
            }
        }
    }

    /// <summary>
    /// To amend a Sale Order
    /// </summary>
    /// <param name="sender">object of control</param>
    /// <param name="e">Event Args</param>
    protected void BtnAmendClick(object sender, EventArgs e)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        gvWorkOrderDetails.EditIndex = -1;

        if (hfIsMAXAssetWOAmendNo.Value == "MAX" && hiddenFieldWoStatus.Value == strStatusAuthorized)
        {
            var strMyStatus = hiddenFieldWoStatus.Value == strStatusAuthorized ? strStatusAuthorized : string.Empty;
            var ds = objAssetWorkOrder.AssetWorkOrderAmend(BaseLocationAutoID, txtAssetWoNo.Text, strStatusAmend, BaseUserID, strMyStatus, DateFormat(txtWefdt.Text));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }

            FillddlAssetWOAmendNO(txtAssetWoNo.Text);
            ViewMode();
        }
    }

    /// <summary>
    /// Handles the Click event of the imgbtnPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void BtnLoadParentPageClick(object sender, EventArgs e)
    {
        FillgvWorkOrderDetails();
    }

    #endregion

    #region GridView gvWorkOrderDetails

    #region GridView SaleOrderServicedetails Controles Events

    /// <summary>
    /// Function to Fill the Sale Order Service Details Grid View.
    /// </summary>
    /// <param name="strFilterAsmtId">Assignment Id to Filter</param>
    protected void FillgvWorkOrderDetails(string strFilterAsmtId = @"")
    {
        strFilterAsmtId = string.Empty;
        var objsales = new BL.Sales();
        var ds = BaseUserIsAreaIncharge == "1"
            ? objsales.SaleOrderDetailGet(BaseLocationAutoID, txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedItem.Value, strFilterAsmtId, BaseUserEmployeeNumber)
            : objsales.SaleOrderDetailGet(BaseLocationAutoID, txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedItem.Value, strFilterAsmtId);

        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    dt.Rows[0]["Billable"] = true;
                    dt.Rows[0]["Active"] = true;
                    dt.Rows[0]["IsAllowanceBillable"] = true;
                    gvWorkOrderDetails.DataSource = dt;
                    gvWorkOrderDetails.DataBind();
                    gvWorkOrderDetails.Rows[0].Visible = false;
                }
                else if (dt.Rows.Count > 0)
                {
                    hfTotalRowCount.Value = dt.Rows.Count.ToString();
                    gvWorkOrderDetails.DataSource = dt;
                    gvWorkOrderDetails.DataBind();

                    decimal saleOrderLineTotalValue = 0;
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {

                        if ((bool.Parse(dt.Rows[i]["Active"].ToString())) || CompareDates(DateTime.Parse(dt.Rows[i]["WOLineEndDate"].ToString()), DateTime.Now.Date) != 2)
                        {
                            saleOrderLineTotalValue = saleOrderLineTotalValue + decimal.Parse(dt.Rows[i]["monthlyBilling"].ToString());
                        }
                    }
                }
            }

            gvWorkOrderDetails.PagerStyle.HorizontalAlign = HorizontalAlign.Left;
            gvWorkOrderDetails.BottomPagerRow.Visible = true;
        }
    }


    /// <summary>
    /// Function to Fill the Assignment ID Id Drop Down of Sale Order Details Grid View exists in the Footer.
    /// </summary>
    /// <param name="strLocationAutoId">Location Auto Id</param>
    /// <param name="ddlgvAsmtId">ddl Assignment ID</param>
    /// <param name="ddlgvPostCode">ddl Post Code</param>
    /// <param name="wefDate">With effective date</param>
    protected void FillddlAsmtId(string strLocationAutoId, DropDownList ddlgvAsmtId, DropDownList ddlgvPostCode, DropDownList ddlAssetName, DropDownList ddlAssetServiceTypeName, string wefDate)
    {
        var objSales = new BL.Sales();
        strLocationAutoId = string.Empty;

        using (var ds = objSales.ClientAsmtIdsGetAll(strLocationAutoId, txtClientCode.Text, BaseUserEmployeeNumber, wefDate))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlgvAsmtId.DataSource = ds.Tables[0];
                ddlgvAsmtId.DataValueField = "AsmtId";
                ddlgvAsmtId.DataTextField = "AsmtIdAddress";
                ddlgvAsmtId.DataBind();
                StringBuilder builder = new StringBuilder();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    builder.Append(String.Format(AssignmentLocationComboFormatString, dr["AsmtID"], dr["LocationAutoID"]));
                }
                if (builder.Length > 0)
                {
                    hiddenFieldAsmtLocId.Value = builder.Remove(builder.Length - 1, 1).ToString();
                }
            }
            else
            {
                var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                ddlgvAsmtId.Items.Add(li);
            }
            FillddlgvPostCode(ddlgvAsmtId.SelectedItem.Value, ddlgvPostCode, ddlAssetName, ddlAssetServiceTypeName);
        }
    }

    /// <summary>
    /// Function to fill the Post of selected Assignment ID in the Footer of the Sale order Service Details Grid View
    /// </summary>
    /// <param name="strAsmtId">str Assignment ID Id</param>
    /// <param name="ddlgvPostCode">ddl gv Post Code</param>
    protected void FillddlgvPostCode(string strAsmtId, DropDownList ddlgvPostCode, DropDownList ddlAssetName, DropDownList ddlAssetServiceTypeName)
    {
        var objSales = new BL.Sales();
        var ds = objSales.PostGetAll(txtClientCode.Text, strAsmtId);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlgvPostCode.DataSource = ds.Tables[0];
            ddlgvPostCode.DataValueField = "PostAutoId";
            ddlgvPostCode.DataTextField = "PostDesc";
            ddlgvPostCode.DataBind();
        }
        else
        {
            ddlgvPostCode.Items.Clear();
            var li = new ListItem(Resources.Resource.NoDataToShow, "0");
            ddlgvPostCode.Items.Add(li);
        }
        FillddlAssetName(ddlgvPostCode.SelectedItem.Value, ddlAssetName, ddlAssetServiceTypeName);
    }

    /// <summary>
    /// Function to fill the Contract Number Dropdown of the Sale order Service details Footer Grid View.
    /// </summary>
    /// <param name="ddlContractNumber">ddl Contract Number</param>
    protected void FillddlContractNumber(DropDownList ddlContractNumber)
    {
        var objSales = new BL.Sales();
        var ds = objSales.ContractNumberGetAll(txtClientCode.Text, strStatusAuthorized);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlContractNumber.DataSource = ds.Tables[0];
            ddlContractNumber.DataValueField = "ContractNumber";
            ddlContractNumber.DataTextField = "CNoMCNoBranch";
            ddlContractNumber.DataBind();
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlContractNumber.Items.Add(li);
        }
    }

    /// <summary>
    /// Function to Fill the Type Of Service of Footer of Sale Order Service Details.
    /// </summary>
    /// <param name="ddlAssetName">ddl Type Of Service</param>
    protected void FillddlAssetName(string strPostAutoId, DropDownList ddlAssetName, DropDownList ddlAssetServiceTypeName)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        DataSet ds = objAssetWorkOrder.PostAssetsGet(strPostAutoId);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAssetName.DataSource = ds.Tables[0];
            ddlAssetName.DataValueField = "AssetAutoId";
            ddlAssetName.DataTextField = "AssetName";
            ddlAssetName.DataBind();
        }
        else
        {
            ddlAssetName.Items.Clear();
            var li = new ListItem(Resources.Resource.NoDataToShow, "0");
            ddlAssetName.Items.Add(li);
        }
        FillddlAssetServiceTypeName(ddlAssetName.SelectedItem.Value, ddlAssetServiceTypeName);
    }

    protected void FillddlAssetServiceTypeName(string strAssetAutoId, DropDownList ddlAssetServiceTypeName)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        DataSet ds = objAssetWorkOrder.AssetsServiceTypeGet(strAssetAutoId,BaseLocationAutoID);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAssetServiceTypeName.DataSource = ds.Tables[0];
            ddlAssetServiceTypeName.DataValueField = "AssetServiceTypeAutoId";
            ddlAssetServiceTypeName.DataTextField = "AssetServiceTypeName";
            ddlAssetServiceTypeName.DataBind();
        }
        else
        {
            ddlAssetServiceTypeName.Items.Clear();
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlAssetServiceTypeName.Items.Add(li);
        }
    }

    /// <summary>
    /// On Selection Change of Assignment ID of Edit Template Control of SaleOrder Service Details Grid View.
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlgvAsmtIdET_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlgvAsmtId = (DropDownList)sender;
        var gridViewRow = (GridViewRow)ddlgvAsmtId.NamingContainer;
        var ddlgvPostCode = (DropDownList)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("ddlgvPostCode");
        var ddlAssetName = (DropDownList)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("ddlAssetName");
        var ddlAssetServiceTypeName = (DropDownList)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("ddlAssetServiceTypeName");

        FillddlgvPostCode(ddlgvAsmtId.SelectedItem.Value, ddlgvPostCode, ddlAssetName, ddlAssetServiceTypeName);

        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(ddlgvPostCode);
        }
    }

    /// <summary>
    /// On Selection Change of Assignment ID of Footer Template Control of SaleOrder Service Details Grid View.
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlgvAsmtIdFT_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlgvAsmtId = (DropDownList)sender;
        var ddlgvPostCode = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlgvPostCode");
        var ddlAssetName = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlAssetName");
        var ddlAssetServiceTypeName = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlAssetServiceTypeName");
        FillddlgvPostCode(ddlgvAsmtId.SelectedItem.Value, ddlgvPostCode, ddlAssetName, ddlAssetServiceTypeName);
        var imgbtnPost = (ImageButton)gvWorkOrderDetails.FooterRow.FindControl("imgbtnPost");

        if (imgbtnPost != null)
        {
            imgbtnPost.Attributes.Add("OnClick", "javascript:OpenPostCreation('" + BaseLocationAutoID + "','" + txtClientCode.Text + "','" + ddlgvAsmtId.SelectedItem.Value + "')");
            DisableThePostAddButton(ddlgvAsmtId.SelectedItem.Value, imgbtnPost);
        }

        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(ddlgvPostCode);
        }
    }

    protected void ddlgvPostCodeET_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlgvPostCode = (DropDownList)sender;
        var gridViewRow = (GridViewRow)ddlgvPostCode.NamingContainer;
        var ddlAssetName = (DropDownList)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("ddlAssetName");
        var ddlAssetServiceTypeName = (DropDownList)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("ddlAssetServiceTypeName");

        FillddlAssetName(ddlgvPostCode.SelectedItem.Value, ddlAssetName, ddlAssetServiceTypeName);

        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(ddlAssetName);
        }
    }

    protected void ddlgvPostCodeFT_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlgvPostCode = (DropDownList)sender;
        var ddlAssetName = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlAssetName");
        var ddlAssetServiceTypeName = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlAssetServiceTypeName");

        FillddlAssetName(ddlgvPostCode.SelectedItem.Value, ddlAssetName, ddlAssetServiceTypeName);

        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(ddlAssetName);
        }
    }

    protected void ddlAssetNameET_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlAssetName = (DropDownList)sender;
        var gridViewRow = (GridViewRow)ddlAssetName.NamingContainer;
        var ddlAssetServiceTypeName = (DropDownList)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("ddlAssetServiceTypeName");
        FillddlAssetServiceTypeName(ddlAssetName.SelectedItem.Value, ddlAssetServiceTypeName);

        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(ddlAssetServiceTypeName);
        }
    }

    protected void ddlAssetNameFT_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlAssetName = (DropDownList)sender;
        var ddlAssetServiceTypeName = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlAssetServiceTypeName");
        FillddlAssetServiceTypeName(ddlAssetName.SelectedItem.Value, ddlAssetServiceTypeName);

        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(ddlAssetServiceTypeName);
        }
    }

    /// <summary>
    /// Based on the changes made on the Assignment Drop Down if the selected assignment belongs to
    /// different branch then we need to hide the Post Add Button
    /// </summary>
    /// <param name="selectedAssignmentId">The selected Assignment Id</param>
    /// <param name="btn">The Image add button to be disabled</param>
    private void DisableThePostAddButton(String selectedAssignmentId, ImageButton btn)
    {
        if (!String.IsNullOrEmpty(hiddenFieldAsmtLocId.Value))
        {
            String[] asmtLocArray = hiddenFieldAsmtLocId.Value.Split(',');
            if (asmtLocArray.Length > 0)
            {
                foreach (String asmtLocCombo in asmtLocArray)
                {
                    String[] asmtLocComboArray = asmtLocCombo.Split(':');
                    if (asmtLocComboArray.Length == 2)
                    {
                        if (asmtLocComboArray[0].Trim().ToUpper().Equals(selectedAssignmentId.Trim().ToUpper()))
                        {
                            if (!asmtLocComboArray[1].Trim().ToUpper().Equals(BaseLocationAutoID.Trim().ToUpper()))
                            {
                                btn.Visible = false;
                            }
                            else
                            {
                                btn.Visible = true;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// On Selection Change of Contract Number of Footer Template Control of SaleOrder Service Details Grid View.
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlContractNumber_SelectedIndexChangedFooter(object sender, EventArgs e)
    {
        var ddlContractNumber = (DropDownList)sender;
        var txtWOLineStartDate = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtWOLineStartDate");
        var txtWOLineEndDate = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtWOLineEndDate");
        var txtWOLineWefDate = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtWOLineWefDate");
        var hiddenfieldWOLineStartDate = (HiddenField)gvWorkOrderDetails.FooterRow.FindControl("hiddenfieldWOLineStartDate");
        var hiddenfieldWOLineEndDate = (HiddenField)gvWorkOrderDetails.FooterRow.FindControl("hiddenfieldWOLineEndDate");
        FillContractDetails(ddlContractNumber, txtWOLineStartDate, txtWOLineEndDate, txtWOLineWefDate, hiddenfieldWOLineStartDate, hiddenfieldWOLineEndDate, "Footer");
    }

    /// <summary>
    /// Fill Contract dropdown
    /// </summary>
    /// <param name="ddlContractNumber">Contract Number</param>
    /// <param name="txtWOLineStartDate">Soline Start Date</param>
    /// <param name="txtWOLineEndDate">Soline End Date</param>
    /// <param name="txtWefDate">With effective Date</param>
    /// <param name="hiddenfieldWOLineStartDate">hidden field Soline Start Date</param>
    /// <param name="hiddenfieldWOLineEndDate">hidden field Soline End Date</param>
    /// <param name="status">Status field</param>
    protected void FillContractDetails(DropDownList ddlContractNumber, TextBox txtWOLineStartDate, TextBox txtWOLineEndDate, TextBox txtWefDate, HiddenField hiddenfieldWOLineStartDate, HiddenField hiddenfieldWOLineEndDate, string status)
    {
        var objSales = new BL.Sales();
        using (DataSet ds = objSales.ContractDetailGet(BaseLocationAutoID, txtClientCode.Text, ddlContractNumber.SelectedValue))
        {

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (status.Trim().ToLower() == "footer")
                {
                    txtWOLineStartDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    hiddenfieldWOLineStartDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    txtWOLineEndDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                    hiddenfieldWOLineEndDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                    txtWefDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                }
                else if (status.Trim().ToLower() == "row")
                {
                    hiddenfieldWOLineStartDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    hiddenfieldWOLineEndDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                }
                else
                {
                    txtWOLineStartDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    hiddenfieldWOLineStartDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    txtWOLineEndDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                    hiddenfieldWOLineEndDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                }
            }
        }
    }

    /// <summary>
    /// On Selection Change of Contract Number of Edit Template Control of SaleOrder Service Details Grid View.
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlContractNumber_SelectedIndexChangedEdit(object sender, EventArgs e)
    {
        var ddlContractNumber = (DropDownList)sender;
        var gridViewRow = (GridViewRow)ddlContractNumber.NamingContainer;
        var txtWOLineStartDate = (TextBox)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("txtWOLineStartDate");
        var txtWOLineEndDate = (TextBox)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("txtWOLineEndDate");
        var txtWOLineWefDate = (TextBox)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("txtWOLineWefDate");
        var hiddenfieldWOLineStartDate = (HiddenField)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("hiddenfieldWOLineStartDate");
        var hiddenfieldWOLineEndDate = (HiddenField)gvWorkOrderDetails.Rows[gridViewRow.RowIndex].FindControl("hiddenfieldWOLineEndDate");
        FillContractDetails(ddlContractNumber, txtWOLineStartDate, txtWOLineEndDate, txtWOLineWefDate, hiddenfieldWOLineStartDate, hiddenfieldWOLineEndDate, string.Empty);
    }

    /// <summary>
    /// Function to Validate the Start, End and Wef Date of Sale order Service Details Dates.
    /// </summary>
    /// <param name="strSoWefDate">str So Wef Date</param>
    /// <param name="strWOLineStartDate">str So Line Start Date</param>
    /// <param name="strWOLineEndDate">str So Line End Date</param>
    /// <param name="strWOLineWefDate">str So Line Wef Date</param>
    /// <param name="strContractStartDate">str Contract Start Date</param>
    /// <param name="strContractEndDate">str Contract End Date</param>
    /// <param name="strContractEndDateStatus">str Contract End Date Status</param>
    /// <returns>true or false</returns>
    protected bool ValidateSoDetailsDates(string strSoWefDate, string strWOLineStartDate, string strWOLineEndDate, string strWOLineWefDate, string strContractStartDate, string strContractEndDate, string strContractEndDateStatus)
    {
        if (strSoWefDate == string.Empty || strWOLineStartDate == string.Empty || strWOLineEndDate == string.Empty || strWOLineWefDate == string.Empty)
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.DateCannotbeleftBlank);
            return false;
        }

        DateTime dateTimeWOLineStartDate = DateTime.Parse(strWOLineStartDate);
        DateTime dateTimeWOLineEndDate = DateTime.Parse(strWOLineEndDate);
        DateTime dateTimeWOLineWefDate = DateTime.Parse(strWOLineWefDate);
        DateTime dateTimeContractStartDate = DateTime.Parse(strContractStartDate);
        DateTime dateTimeContractEndDate = DateTime.Parse(strContractEndDate);

        if (strContractEndDateStatus != "-1")
        {
            var hiddenFieldPreviousWOLineEndDate = (HiddenField)gvWorkOrderDetails.Rows[int.Parse(strContractEndDateStatus)].FindControl("hiddenFieldPreviousWOLineEndDate");
            if (hiddenFieldWoStatus.Value == strStatusAmend && dateTimeWOLineEndDate < DateTime.Parse(hiddenFieldPreviousWOLineEndDate.Value))
            {
                lblErrorMsg.Text = Resources.Resource.WOLineEndDateCannotBeModified;
                return false;
            }
        }

        if (dateTimeWOLineWefDate >= dateTimeWOLineStartDate && dateTimeWOLineWefDate <= dateTimeWOLineEndDate && dateTimeWOLineStartDate >= dateTimeContractStartDate && dateTimeWOLineStartDate <= dateTimeContractEndDate && dateTimeWOLineEndDate <= dateTimeContractEndDate)
        {
            return true;
        }

        if (dateTimeWOLineWefDate <= dateTimeWOLineStartDate && dateTimeWOLineWefDate > dateTimeWOLineEndDate)
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.WOLineWefDateShouldBeBetweenStartAndEndDate);
        }
        else if (dateTimeWOLineStartDate < dateTimeContractStartDate)
        {
            lblErrorMsg.Text = Resources.Resource.WOLineStartDateShouldbeGreaterthanorEqualtoContarctStartDate;
        }
        else if (dateTimeWOLineWefDate < dateTimeWOLineStartDate)
        {
            lblErrorMsg.Text = Resources.Resource.WOLineWefDateCannotBeLessThanWOLineStartDate;
        }
        else if (dateTimeWOLineWefDate > dateTimeWOLineEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.WOLineWefDateCannotBeGreaterThanWOLineEndDate;
        }
        else if (dateTimeWOLineStartDate > dateTimeContractEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.WOLineStartDateCannotBeGreaterThanContractEndDate;
        }
        else if (dateTimeWOLineEndDate > dateTimeContractEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.WOLineEndDateCannotBeGreaterThanContractEndDate;
        }

        return false;
    }

    #endregion

    #region GridView SaleOrderServiceDetails Commands Events
    /// <summary>
    /// gv Sale Order Details Row Data Bound
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Row Event Args</param>
    protected void gvWorkOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //var lblgvhdrChargeRatePerHrs = (Label)e.Row.FindControl("lblgvhdrChargeRatePerHrs");
            //lblgvhdrChargeRatePerHrs.Text = Resources.Resource.SellingPrice + @" (" + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @") ";
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            var imgBtnSkills = (ImageButton)e.Row.FindControl("imgBtnSkills");
            var imgBtnDeployment = (ImageButton)e.Row.FindControl("ImgBtnDeployment");
            var lblgvAssetWoLineNo = (Label)e.Row.FindControl("lblgvAssetWoLineNo");
            var checkBoxActive = (CheckBox)e.Row.FindControl("checkBoxActive");
            var checkBoxBillable = (CheckBox)e.Row.FindControl("checkBoxBillable");
            var hlimgWoLineStartDate = (HyperLink)e.Row.FindControl("hlimgWoLineStartDate");
            var imgbtnDelete1 = (ImageButton)e.Row.FindControl("imgbtnDelete");
            var hfAssetWolineNo = (HiddenField)e.Row.FindControl("hfAssetWolineNo");

            if (hiddenFieldWoStatus.Value == strStatusFresh && IsDeleteAccess)
            {
                if (imgbtnDelete1 != null)
                {
                    imgbtnDelete1.Visible = true;
                }
            }
            else
            {
                if (imgbtnDelete1 != null)
                {
                    imgbtnDelete1.Visible = false;
                }
            }

            if (checkBoxActive != null && checkBoxActive.Checked == false)
            {
                e.Row.BackColor = System.Drawing.Color.Gainsboro;
            }

            if (hiddenFieldWoStatus.Value == strStatusAmend && IsDeleteAccess)
            {
                if (imgbtnDelete1 != null)
                {

                    if (hfAssetWolineNo != null)
                    {
                        imgbtnDelete1.Visible = hfAssetWolineNo.Value == "0";
                    }
                }


                if (hlimgWoLineStartDate != null)
                {
                    hlimgWoLineStartDate.Visible = false;
                }
            }

            if (hiddenFieldWoStatus.Value == strStatusFresh || hiddenFieldWoStatus.Value == strStatusAmend)
            {
                if (checkBoxActive != null)
                {
                    checkBoxActive.Enabled = false;
                }

            }
            else
            {
                if (checkBoxActive != null)
                {
                    checkBoxActive.Enabled = false;
                }
            }

            if (imgBtnDeployment != null && lblgvAssetWoLineNo != null && checkBoxActive != null)
            {
                imgBtnDeployment.Attributes.Add("OnClick", "javascript:OpenWOServiceLineDept('" + BaseLocationAutoID + "','" + txtAssetWoNo.Text + "','" + ddlAssetWOAmendNO.SelectedItem.Value + "','" + lblgvAssetWoLineNo.Text + "','" + hiddenFieldWoStatus.Value + "','" + hfIsMAXAssetWOAmendNo.Value + "','" + checkBoxActive.Checked + "')");
            }

            if (imgBtnSkills != null && checkBoxActive != null && lblgvAssetWoLineNo != null)
            {
                imgBtnSkills.Attributes.Add("OnClick", "javascript:OpenSOSkills('" + BaseLocationAutoID + "','" + txtAssetWoNo.Text + "','" + ddlAssetWOAmendNO.SelectedItem.Value + "','" + lblgvAssetWoLineNo.Text + "','" + hiddenFieldWoStatus.Value + "','" + hfIsMAXAssetWOAmendNo.Value + "','" + checkBoxActive.Checked + "')");
            }

            if (IsModifyAccess == false)
            {
                var imgbtnEdit = (ImageButton)e.Row.FindControl("imgbtnEdit");
                if (imgbtnEdit != null)
                {
                    imgbtnEdit.Visible = false;
                }
            }
            else
            {
                var imgbtnEdit = (ImageButton)e.Row.FindControl("imgbtnEdit");
                var imgbtnDelete = (ImageButton)e.Row.FindControl("imgbtnDelete");
                if (hiddenFieldWoStatus.Value != strStatusAmend && hiddenFieldWoStatus.Value != strStatusFresh)
                {
                    if (imgbtnEdit != null)
                    {
                        imgbtnEdit.Visible = false;
                    }

                    if (imgbtnDelete != null)
                    {
                        imgbtnDelete.Visible = false;
                    }
                }
                else
                {
                    var imgbtnUpdate = (ImageButton)e.Row.FindControl("imgbtnUpdate");
                    if (imgbtnUpdate != null)
                    {
                        imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }
                    var txtWOLineStartDate = (TextBox)e.Row.FindControl("txtWOLineStartDate");
                    var txtWOLineEndDate = (TextBox)e.Row.FindControl("txtWOLineEndDate");
                    var txtWOLineWefDate = (TextBox)e.Row.FindControl("txtWOLineWefDate");
                    if (checkBoxActive != null)
                    {
                        if (checkBoxActive.Checked)
                        {
                            if (imgbtnEdit != null)
                            {
                                imgbtnEdit.Visible = true;
                            }
                        }
                        else
                        {
                            if (imgbtnEdit != null)
                            {
                                imgbtnEdit.Visible = false;
                            }
                        }
                    }
                    if (txtWOLineStartDate != null)
                    {
                        txtWOLineStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtWOLineEndDate != null)
                    {
                        txtWOLineEndDate.Attributes.Add("readonly", "readonly");
                    }

                    if (txtWOLineWefDate != null)
                    {
                        txtWOLineWefDate.Attributes.Add("readonly", "readonly");
                    }

                    var ddlgvAsmtId = (DropDownList)e.Row.FindControl("ddlgvAsmtId");
                    var ddlgvPostCode = (DropDownList)e.Row.FindControl("ddlgvPostCode");
                    var ddlContractNumber = (DropDownList)e.Row.FindControl("ddlContractNumber");
                    var ddlAssetName = (DropDownList)e.Row.FindControl("ddlAssetName");
                    var ddlAssetServiceTypeName = (DropDownList)e.Row.FindControl("ddlAssetServiceTypeName");

                    var hiddenFieldAsmtId = (HiddenField)e.Row.FindControl("hiddenFieldAsmtId");
                    var hiddenFieldPostAutoId = (HiddenField)e.Row.FindControl("hiddenFieldPostAutoID");
                    var hiddenFieldContractNumber = (HiddenField)e.Row.FindControl("hiddenFieldContractNumber");
                    var hiddenFieldAssetName = (HiddenField)e.Row.FindControl("hiddenFieldAssetName");
                    var hiddenFieldAssetServiceTypeName = (HiddenField)e.Row.FindControl("hiddenFieldAssetServiceTypeName");

                    if (ddlgvAsmtId != null && ddlgvPostCode != null && ddlAssetName != null && ddlAssetServiceTypeName != null && hiddenFieldAsmtId != null && hiddenFieldPostAutoId != null && hiddenFieldAssetName != null && hiddenFieldAssetServiceTypeName != null)
                    {

                        FillddlAsmtId(BaseLocationAutoID, ddlgvAsmtId, ddlgvPostCode, ddlAssetName, ddlAssetServiceTypeName, string.Empty);
                        ddlgvAsmtId.SelectedIndex = ddlgvAsmtId.Items.IndexOf(ddlgvAsmtId.Items.FindByValue(hiddenFieldAsmtId.Value));
                        
                        FillddlgvPostCode(ddlgvAsmtId.SelectedItem.Value, ddlgvPostCode, ddlAssetName, ddlAssetServiceTypeName);
                        ddlgvPostCode.SelectedIndex = ddlgvPostCode.Items.IndexOf(ddlgvPostCode.Items.FindByValue(hiddenFieldPostAutoId.Value));

                        FillddlAssetName(ddlgvPostCode.SelectedItem.Value, ddlAssetName, ddlAssetServiceTypeName);
                        ddlAssetName.SelectedIndex = ddlAssetName.Items.IndexOf(ddlAssetName.Items.FindByValue(hiddenFieldAssetName.Value));

                        FillddlAssetServiceTypeName(ddlAssetName.SelectedItem.Value, ddlAssetServiceTypeName);
                        ddlAssetServiceTypeName.SelectedIndex = ddlAssetServiceTypeName.Items.IndexOf(ddlAssetServiceTypeName.Items.FindByValue(hiddenFieldAssetServiceTypeName.Value));
                    }
                    if (ddlContractNumber != null && hiddenFieldContractNumber != null)
                    {
                        FillddlContractNumber(ddlContractNumber);
                        ddlContractNumber.SelectedIndex = ddlContractNumber.Items.IndexOf(ddlContractNumber.Items.FindByValue(hiddenFieldContractNumber.Value));
                    }

                    if (ddlgvAsmtId != null && ddlgvPostCode != null && ddlContractNumber != null && ddlAssetName != null && ddlAssetServiceTypeName != null)
                    {
                        ddlgvAsmtId.Enabled = false;
                        ddlgvPostCode.Enabled = false;
                        ddlContractNumber.Enabled = false;
                        ddlAssetName.Enabled = false;
                        ddlAssetServiceTypeName.Enabled = false;
                    }

                    var txtRate = (TextBox)e.Row.FindControl("txtRate");
                    SetFloatValidationToTextBox(txtRate);
                    var txtMonthlyBilling = (TextBox)e.Row.FindControl("txtMonthlyBilling");
                    SetFloatValidationToTextBox(txtMonthlyBilling);
                    var hiddenfieldWoLineStartDate = (HiddenField)e.Row.FindControl("hiddenfieldWoLineStartDate");
                    var hiddenfieldWoLineEndDate = (HiddenField)e.Row.FindControl("hiddenfieldWoLineEndDate");
                    var workOrderLineExistsInOps = (HiddenField)e.Row.FindControl("workOrderLineExistsInOps");

                    if (ddlContractNumber != null && hiddenfieldWoLineStartDate != null && hiddenfieldWoLineEndDate != null)
                    {
                        FillContractDetails(ddlContractNumber, txtWOLineStartDate, txtWOLineEndDate, txtWOLineWefDate, hiddenfieldWoLineStartDate, hiddenfieldWoLineEndDate, "Row");
                    }

                    var hiddenFieldSoDeptShift = (HiddenField)e.Row.FindControl("hiddenFieldSoDeptShift");
                    if (hiddenFieldSoDeptShift != null && imgBtnDeployment != null)
                    {
                        imgBtnDeployment.ImageUrl = hiddenFieldSoDeptShift.Value == @"0" ? "~/Images/employee-scheduling-disabled.png" : "~/Images/employee-scheduling-enable.png";
                    }
                    if (hiddenFieldWoStatus.Value != strStatusFresh)
                    {
                        if (ddlgvAsmtId != null && workOrderLineExistsInOps != null && workOrderLineExistsInOps.Value != "0")
                        {
                            ddlgvAsmtId.Enabled = false;
                        }

                        if (ddlContractNumber != null && workOrderLineExistsInOps != null && workOrderLineExistsInOps.Value != "0")
                        {
                            ddlContractNumber.Enabled = false;
                        }

                        if (ddlgvPostCode != null && workOrderLineExistsInOps != null && workOrderLineExistsInOps.Value != "0")
                        {
                            ddlgvPostCode.Enabled = false;
                        }
                        if (ddlAssetName != null && workOrderLineExistsInOps != null && workOrderLineExistsInOps.Value != "0")
                        {
                            ddlAssetName.Enabled = false;
                        }
                        if (ddlAssetServiceTypeName != null && workOrderLineExistsInOps != null && workOrderLineExistsInOps.Value != "0")
                        {
                            ddlAssetServiceTypeName.Enabled = false;
                        }
                    }
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvWorkOrderDetails.ShowFooter = false;
            }
            else
            {
                if (hiddenFieldWoStatus.Value != strStatusFresh && hiddenFieldWoStatus.Value != strStatusAmend)
                {
                    gvWorkOrderDetails.ShowFooter = false;
                }
                else
                {
                    gvWorkOrderDetails.ShowFooter = true;
                    var imgbtnAdd = (ImageButton)e.Row.FindControl("imgbtnAdd");
                    if (imgbtnAdd != null)
                    {
                        imgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }

                    var imgbtnAdd1 = (ImageButton)e.Row.FindControl("imgbtnAdd1");
                    if (imgbtnAdd1 != null)
                    {
                        imgbtnAdd1.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }
                    var txtRate = (TextBox)e.Row.FindControl("txtRate");
                    SetFloatValidationToTextBox(txtRate);
                    var txtMonthlyBilling = (TextBox)e.Row.FindControl("txtMonthlyBilling");
                    SetFloatValidationToTextBox(txtMonthlyBilling);

                    var txtWOLineStartDate = (TextBox)e.Row.FindControl("txtWOLineStartDate");
                    var txtWOLineEndDate = (TextBox)e.Row.FindControl("txtWOLineEndDate");
                    var txtWOLineWefDate = (TextBox)e.Row.FindControl("txtWOLineWefDate");
                    if (txtWOLineStartDate != null)
                    {
                        txtWOLineStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtWOLineEndDate != null)
                    {
                        txtWOLineEndDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtWOLineWefDate != null)
                    {
                        txtWOLineWefDate.Attributes.Add("readonly", "readonly");
                    }
                    var ddlgvAsmtId = (DropDownList)e.Row.FindControl("ddlgvAsmtId");
                    var ddlgvPostCode = (DropDownList)e.Row.FindControl("ddlgvPostCode");
                    var ddlContractNumber = (DropDownList)e.Row.FindControl("ddlContractNumber");
                    var ddlAssetName = (DropDownList)e.Row.FindControl("ddlAssetName");
                    var ddlAssetServiceTypeName = (DropDownList)e.Row.FindControl("ddlAssetServiceTypeName");
                    
                    var imgbtnPost = (ImageButton)e.Row.FindControl("imgbtnPost");
                    if (imgbtnPost != null && ddlgvAsmtId != null)
                    {
                        FillddlAsmtId(BaseLocationAutoID, ddlgvAsmtId, ddlgvPostCode, ddlAssetName, ddlAssetServiceTypeName, txtWOLineWefDate.Text);
                        imgbtnPost.Attributes.Add("OnClick", "javascript:OpenPostCreation('" + BaseLocationAutoID + "','" + txtClientCode.Text + "','" + ddlgvAsmtId.SelectedItem.Value + "')");
                        DisableThePostAddButton(ddlgvAsmtId.SelectedItem.Value, imgbtnPost);
                    }
                    if (ddlContractNumber != null)
                    {
                        FillddlContractNumber(ddlContractNumber);
                        if (ddlContractNumber.SelectedValue == string.Empty)
                        {
                            imgbtnAdd.Enabled = false;
                            imgbtnAdd1.Enabled = false;
                        }
                        else
                        {
                            imgbtnAdd.Enabled = true;
                            imgbtnAdd1.Enabled = true;
                        }
                    }
                    
                    var hiddenfieldWoLineStartDate = (HiddenField)e.Row.FindControl("hiddenfieldWoLineStartDate");
                    var hiddenfieldWoLineEndDate = (HiddenField)e.Row.FindControl("hiddenfieldWoLineEndDate");
                    if (ddlContractNumber != null && hiddenfieldWoLineStartDate != null && hiddenfieldWoLineEndDate != null && txtWOLineStartDate != null && txtWOLineEndDate != null && txtWOLineWefDate != null)
                    {
                        FillContractDetails(ddlContractNumber, txtWOLineStartDate, txtWOLineEndDate, txtWOLineWefDate, hiddenfieldWoLineStartDate, hiddenfieldWoLineEndDate, "Footer");

                    }
                }
            }
        }
        //gvWorkOrderDetails.Columns[8].Visible = false;
        //gvWorkOrderDetails.Columns[9].Visible = false;
        //gvWorkOrderDetails.Columns[10].Visible = false;
        //gvWorkOrderDetails.Columns[13].Visible = false;
        //gvWorkOrderDetails.Columns[26].Visible = false;
        //gvWorkOrderDetails.Columns[27].Visible = false;
    }

    /// <summary>
    /// gv Sale Order Details Row Command
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Command Event Args</param>
    protected void gvWorkOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvWorkOrderDetails.PageIndex = 0;
                break;
            case "Prev":
                _index = 1;
                break;
            case "Next":
                _index = 0;
                break;
            case "Last":
                gvWorkOrderDetails.PageIndex = gvWorkOrderDetails.PageCount;
                break;
        }
        
        
        var ddlgvAsmtId = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlgvAsmtId");
        var ddlgvPostCode = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlgvPostCode");
        var ddlAssetName = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlAssetName");
        var ddlAssetServiceTypeName = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlAssetServiceTypeName");
        var ddlContractNumber = (DropDownList)gvWorkOrderDetails.FooterRow.FindControl("ddlContractNumber");
        var txtWOLineStartDate = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtWOLineStartDate");
        var txtWOLineEndDate = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtWOLineEndDate");
        var txtWOLineWefDate = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtWOLineWefDate");
        var checkBoxActive = (CheckBox)gvWorkOrderDetails.FooterRow.FindControl("checkBoxActive");
        var checkBoxBillable = (CheckBox)gvWorkOrderDetails.FooterRow.FindControl("checkBoxBillable");
        var txtRate = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtRate");
        var txtMonthlyBilling = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtMonthlyBilling");
        var txtSoLineRemarks = (TextBox)gvWorkOrderDetails.FooterRow.FindControl("txtSoLineRemarks");
        var hiddenfieldWoLineStartDate = (HiddenField)gvWorkOrderDetails.FooterRow.FindControl("hiddenfieldWoLineStartDate");
        var hiddenfieldWoLineEndDate = (HiddenField)gvWorkOrderDetails.FooterRow.FindControl("hiddenfieldWoLineEndDate");

        var objAssetWorkOrder = new BL.AssetWorkOrder();
        if (e.CommandName == "Add")
        {
            string strContractEndDateStatus = "-1";
            double dblRate = 0.0;
            double dblMonthlyBilling = 0.0;
            if (txtRate != null && txtRate.Text == string.Empty)
            {
                txtRate.Text = "0.0";
            }
            if (txtRate != null && txtRate.Text != string.Empty)
            {
                dblRate = double.Parse(txtRate.Text);
            }
            if (txtMonthlyBilling != null && txtMonthlyBilling.Text == string.Empty) 
            {
                txtMonthlyBilling.Text = "0.0";
            }
            if (txtMonthlyBilling != null && txtMonthlyBilling.Text != string.Empty)
            {
                dblMonthlyBilling = double.Parse(txtMonthlyBilling.Text);
            }

            if (ValidateSoDetailsDates(txtWefdt.Text, txtWOLineStartDate.Text, txtWOLineEndDate.Text, txtWOLineWefDate.Text, hiddenfieldWoLineStartDate.Value, hiddenfieldWoLineEndDate.Value, strContractEndDateStatus))
            {
                if (ddlgvAsmtId.SelectedItem.Value != string.Empty && ddlgvPostCode.SelectedItem.Value != string.Empty && ddlContractNumber.SelectedItem.Value != string.Empty && ddlAssetName.SelectedValue != "0" && ddlAssetServiceTypeName.SelectedItem.Value != string.Empty)
                {
                    DataSet ds = objAssetWorkOrder.WorkOrderDetailAddNew(BaseLocationAutoID, txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedValue, ddlContractNumber.SelectedValue,
                            ddlgvAsmtId.SelectedValue, ddlgvPostCode.SelectedValue, ddlAssetName.SelectedValue, ddlAssetServiceTypeName.SelectedValue,
                            txtWOLineStartDate.Text, txtWOLineEndDate.Text, txtWOLineWefDate.Text, bool.Parse(checkBoxBillable.Checked.ToString()),
                            bool.Parse(checkBoxActive.Checked.ToString()), dblRate, dblMonthlyBilling, txtSoLineRemarks.Text, BaseUserID);
                        gvWorkOrderDetails.EditIndex = -1;
                        FillgvWorkOrderDetails();
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.ContractNo + ", " + Resources.Resource.AsmtId + ", " + Resources.Resource.AssetName + " " + Resources.Resource.AND + " " + Resources.Resource.AssetServiceTypeName + " " + Resources.Resource.Required);
                }
            }
        }
        else if (e.CommandName == "Reset")
        {
            txtWOLineWefDate.Text = string.Empty;
            checkBoxBillable.Checked = false;
            checkBoxActive.Checked = false;
        }
    }

    /// <summary>
    /// gv Sale Order Details Row Canceling Edit
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Cancel Edit Event Args</param>
    protected void gvWorkOrderDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvWorkOrderDetails.EditIndex = -1;
        FillgvWorkOrderDetails();
    }

    /// <summary>
    /// gv Sale Order Details Row Editing
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Edit Event Args</param>
    protected void gvWorkOrderDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvWorkOrderDetails.EditIndex = e.NewEditIndex;
        FillgvWorkOrderDetails();
    }

    /// <summary>
    /// gv Sale Order Details Page Index Changing
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Page Event Args</param>
    protected void gvWorkOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var gvrPager = gvWorkOrderDetails.BottomPagerRow;
        var ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        var currentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (_index == 1)
        {
            if (currentIndex > 0)
            {
                gvWorkOrderDetails.PageIndex = currentIndex - 1;
            }
            else
            {
                gvWorkOrderDetails.PageIndex = currentIndex;
            }
            _index = -1;
        }
        else if (_index == 0)
        {
            gvWorkOrderDetails.PageIndex = currentIndex + 1;
            _index = -1;
        }
        else
        {
            gvWorkOrderDetails.PageIndex = e.NewPageIndex;
        }
        gvWorkOrderDetails.EditIndex = -1;
        FillgvWorkOrderDetails();
    }
    /// <summary>
    /// grid view data bound event
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">event objects</param>
    protected void gvWorkOrderDetails_DataBound(object sender, EventArgs e)
    {
        var row = gvWorkOrderDetails.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        var lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (var i = 0; i < gvWorkOrderDetails.PageCount; i++)
            {
                var intPageNumber = i + 1;
                var lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvWorkOrderDetails.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvWorkOrderDetails.PageCount.ToString();
        }
    }

    /// <summary>
    /// Page change event
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">object event</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvWorkOrderDetails.BottomPagerRow;
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvWorkOrderDetails.PageIndex = ddlPages.SelectedIndex;
        FillgvWorkOrderDetails();
    }

    /// <summary>
    /// grid Clear paging
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">event object</param>
    protected void ImgbtnClearPaging_Click(object sender, EventArgs e)
    {
        if (int.Parse(hfTotalRowCount.Value) > 0)
        {
            gvWorkOrderDetails.PageSize = int.Parse(hfTotalRowCount.Value);
            FillgvWorkOrderDetails();
        }
    }

    /// <summary>
    /// Apply paging in Grid
    /// </summary>
    /// <param name="sender">object Sender</param>
    /// <param name="e">event object</param>
    protected void ImgbtnApplyPaging_Click(object sender, EventArgs e)
    {
        if (int.Parse(hfTotalRowCount.Value) > 0)
        {
            gvWorkOrderDetails.PageSize = int.Parse(hfDefaultPageSize.Value);
            FillgvWorkOrderDetails();
        }
    }

    /// <summary>
    /// gv Sale Order Details Row Updating
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Update Event Args</param>
    protected void gvWorkOrderDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var lblgvAssetWoLineNo = (Label)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("lblgvAssetWoLineNo");
        var ddlContractNumber = (DropDownList)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("ddlContractNumber");
        var ddlgvAsmtId = (DropDownList)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("ddlgvAsmtId");
        var ddlgvPostCode = (DropDownList)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("ddlgvPostCode");
        var ddlAssetName = (DropDownList)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("ddlAssetName");
        var ddlAssetServiceTypeName = (DropDownList)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("ddlAssetServiceTypeName");
        var txtWOLineStartDate = (TextBox)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("txtWOLineStartDate");
        var txtWOLineEndDate = (TextBox)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("txtWOLineEndDate");
        var txtWOLineWefDate = (TextBox)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("txtWOLineWefDate");
        var checkBoxBillable = (CheckBox)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("checkBoxBillable");
        var checkBoxActive = (CheckBox)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("checkBoxActive");
        var txtMonthlyBilling = (TextBox)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("txtMonthlyBilling");
        var txtRate = (TextBox)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("txtRate");
        var txtSoLineRemarks = (TextBox)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("txtSoLineRemarks");
        var hiddenfieldWoLineStartDate = (HiddenField)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("hiddenfieldWoLineStartDate");
        var hiddenfieldWoLineEndDate = (HiddenField)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("hiddenfieldWoLineEndDate");
        
        var strLocationAutoId = BaseLocationAutoID;
        var strAssetWoNo = txtAssetWoNo.Text;
        var strAssetWoAmendNo = ddlAssetWOAmendNO.SelectedItem.Value;
        var struserId = BaseUserID;

        if (lblgvAssetWoLineNo != null && ddlContractNumber != null && ddlgvAsmtId != null && ddlgvPostCode != null && ddlAssetName != null 
            && ddlAssetServiceTypeName != null && txtWOLineStartDate != null && txtWOLineEndDate != null && txtWOLineWefDate != null
            && checkBoxBillable != null && checkBoxActive != null && txtMonthlyBilling != null && txtRate != null && txtSoLineRemarks != null)
        {
            var strSoLineNo = lblgvAssetWoLineNo.Text;
            var strContractNumber = ddlContractNumber.SelectedValue;
            var strAsmtId = ddlgvAsmtId.SelectedValue;
            var strPostAutoId = ddlgvPostCode.SelectedValue;
            var strAssetAutoId = ddlAssetName.SelectedValue;
            var strAssetServiceTypeAutoId = ddlAssetServiceTypeName.SelectedValue;
            var strWoLineStartDate = txtWOLineStartDate.Text;
            var strWoLineEndDate = txtWOLineEndDate.Text;
            var strWoLineWefDate = txtWOLineWefDate.Text;
            bool boolBillable = checkBoxBillable.Checked;
            bool boolActive = checkBoxActive.Checked;

            var objAssetWorkOrder = new BL.AssetWorkOrder();
            if (hiddenFieldWoStatus.Value != strStatusFresh)
            {
                DataSet dataMaxWef = objAssetWorkOrder.AssetWODetailsMaximumAuthorizedWEFDateGet(txtAssetWoNo.Text, int.Parse(lblgvAssetWoLineNo.Text), int.Parse(BaseLocationAutoID));

                if (DateTime.Parse(txtWOLineWefDate.Text) < DateTime.Parse(dataMaxWef.Tables[0].Rows[0]["WOLineWefDate"].ToString()))
                {
                    lblErrorMsg.Text = Resources.Resource.SoLineWEFDatecannotbedecreasedPleaseuseSalesOPSTermination;
                    return;
                }
            }

            if (txtMonthlyBilling.Text == string.Empty)
            {
                txtMonthlyBilling.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }
            if (txtRate.Text == string.Empty)
            {
                txtRate.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }

            if (ddlgvAsmtId.SelectedItem.Value != string.Empty && ddlgvPostCode.SelectedItem.Value != string.Empty && ddlContractNumber.SelectedItem.Value != string.Empty && ddlAssetName.SelectedItem.Value != "0" && ddlAssetServiceTypeName.SelectedItem.Value != string.Empty)
            {
                var strContractEndDateStatus = e.RowIndex.ToString();
                if (ValidateSoDetailsDates(txtWefdt.Text, txtWOLineStartDate.Text, txtWOLineEndDate.Text, txtWOLineWefDate.Text, hiddenfieldWoLineStartDate.Value, hiddenfieldWoLineEndDate.Value, strContractEndDateStatus))
                {
                    DataSet ds = objAssetWorkOrder.WorkOrderDetailUpdate(strLocationAutoId, strAssetWoNo, strAssetWoAmendNo, strSoLineNo, strContractNumber, strAsmtId, strPostAutoId,
                                                                    strAssetAutoId, strAssetServiceTypeAutoId, strWoLineStartDate, strWoLineEndDate, strWoLineWefDate, boolBillable, 
                                                                    boolActive, double.Parse(txtRate.Text), double.Parse(txtMonthlyBilling.Text), txtRemarks.Text , struserId, strStatusFresh
                                                                    );
                        gvWorkOrderDetails.EditIndex = -1;
                        FillgvWorkOrderDetails();
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                }
            }
        }
    }

    /// <summary>
    /// gv Sale Order Details Row Deleting
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Delete Event Args</param>
    protected void gvWorkOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        var lblgvAssetWoLineNo = (Label)gvWorkOrderDetails.Rows[e.RowIndex].FindControl("lblgvAssetWoLineNo");

        DataSet ds = objAssetWorkOrder.AssetWorkOrderDetailsDelete(txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedItem.Value, lblgvAssetWoLineNo.Text);
        FillgvWorkOrderDetails();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    #endregion

    #region [Common Function] Function Related To Sort GridView
    /// <summary>
    /// Sort Grid View
    /// </summary>
    /// <param name="sortExpression">sort Expression</param>
    /// <param name="direction">direction of sorting</param>
    /// <param name="dv">data view</param>
    /// <param name="strGridViewName">Grid view name</param>
    protected void SortGridView(string sortExpression, string direction, DataView dv, GridView strGridViewName)
    {
        dv.Sort = sortExpression + ' ' + direction;
        strGridViewName.DataSource = dv;
        strGridViewName.DataBind();
    }

    /// <summary>
    /// Sale Order Details Sorting
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Sort Event Args</param>
    protected void gvWorkOrderDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        var objSales = new BL.Sales();
        var dv = new DataView(objSales.SaleOrderDetailGet(BaseLocationAutoID, txtAssetWoNo.Text, ddlAssetWOAmendNO.SelectedItem.Value).Tables[0]);

        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESC", dv, gvWorkOrderDetails);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASC", dv, gvWorkOrderDetails);
        }
    }

    #endregion
    #endregion

    protected void BtnAsmtCreationClick(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/AssignmentCreation.aspx?ClientCode=" + txtClientCode.Text);
    }

    
}