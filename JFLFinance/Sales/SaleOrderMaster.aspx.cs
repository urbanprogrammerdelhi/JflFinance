// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="SaleOrderMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>

// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
/// Sale Order Screen Code behind
/// </summary>
public partial class Sales_SaleOrderMaster : BasePage
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
        lblDefaultCurrency.Text = @" (" + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @") ";
        lblDefaultCurrency2.Text = @" (" + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @") ";

        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                hfspDecimalPlace.Value = "{0:F" + BaseDigitsAfterDecimalPlaces + "}";

                var objSales = new BL.Sales();
                var ds = objSales.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
                hfDaysInMonth.Value = ds.Tables[0].Rows[0]["SaleOrderDefaultNumberOfDays"].ToString();
                hfRemainingDays.Value = ds.Tables[0].Rows[0]["SaleOrderRemainingDays"].ToString();
                hfPayRateType.Value = ds.Tables[1].Rows[0]["PayRateType"].ToString();
                hfFixedBillingCheck.Value = ds.Tables[2].Rows[0]["FixedBillingCheck"].ToString();

                txtSoNo.Attributes.Add("onKeyDown", "javascript:TextBox_onkeyDown('" + txtSoNo.ClientID + "')");
                txtClientCode.Attributes.Add("onKeyDown", "javascript:TextBox_onkeyDown('" + txtClientCode.ClientID + "')");
                txtClientCode.Attributes.Add("onKeyDown", "if(event.keyCode==13){event.keyCode=9;return event.keyCode;}");
                ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + txtClientCode.ClientID + "&Company=" + BaseCompanyCode + "&HrLocation=&Location=" + BaseLocationCode + "', null,'status=off, center=yes, scrollbars=1, resizeable=1, Width=700px, Height=350, help=no')");
                txtSoNo.Attributes.Add("readonly", "readonly");
                txtSOAmendDate.Attributes.Add("readonly", "readonly");
                txtClientName.Attributes.Add("readonly", "readonly");
                txtWefdt.Attributes.Add("readonly", "readonly");
                var txtmon = Request.QueryString["txtMonSellingRate"];
                txtTerminationDate.Attributes.Add("readonly", "readonly");
                ImgBtnSearchLocation.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH005&ControlId=" + txtBillingLocation.ClientID + "&ControlId1=" + hfBillingLocationAutoID.ClientID + "&Company=" + BaseCompanyCode + "&HrLocation=&Location=', null,'status=off, center=yes, scrollbars=1, resizeable=1, Width=700px, Height=350, help=no')");
                if (Request.QueryString["SoNo"] != null && Request.QueryString["SoNo"] != "0")
                {
                    txtSoNo.Text = Request.QueryString["SoNo"];
                    if (txtSoNo.Text != string.Empty)
                    {
                        FillddlSoType();
                        FillddlSoAmendNo(txtSoNo.Text);
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
                        if (ddlSoType.SelectedValue != "-1")
                        {
                            SaleOrderHeaderSave();
                            Response.Redirect("SaleOrderMaster.aspx?SoNo=" + txtSoNo.Text);
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
        FillddlQuotationNo();
        btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";

    }
    #endregion

    #region Controles Binding

    /// <summary>
    /// To Fill the Screen Controls with current SaleOrder Values
    /// </summary>
    protected void GetSelectedSaleOrder()
    {
        var objsales = new BL.Sales();
        var strSoAmendNo = ddlSOAmendNO.Items.Count == 0 ? "-1" : ddlSOAmendNO.SelectedItem.Value;

        var ds = objsales.SaleOrderGet(BaseLocationAutoID, txtSoNo.Text, strSoAmendNo);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            FillControles(ds);
            FillgvSaleOrderDetails();
            FillgvSaleOrderItemDetails();
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
        lblSOStatus.Text = string.Empty;
        hiddenFieldSoStatus.Value = string.Empty;
        txtSOAmendDate.Text = string.Empty;
        txtClientCode.Text = string.Empty;
        txtClientName.Text = string.Empty;
        txtBillingLocation.Text = string.Empty;
        hfBillingLocationAutoID.Value = string.Empty;
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
        lblSOStatus.Text = ResourceValueOfKeyOnlyforStatus_Get(ds.Tables[0].Rows[0]["SOStatus"].ToString());

        hiddenFieldSoStatus.Value = ds.Tables[0].Rows[0]["SOStatus"].ToString();
        txtSOAmendDate.Text = DateFormat(ds.Tables[0].Rows[0]["SOAmendDate"].ToString());
        ddlSoType.SelectedIndex = ddlSoType.Items.IndexOf(ddlSoType.Items.FindByValue(ds.Tables[0].Rows[0]["SOType"].ToString()));
        txtWefdt.Text = DateFormat(ds.Tables[0].Rows[0]["WefDate"].ToString());
        txtClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
        txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        cbCenterlizeBilling.Checked = bool.Parse(ds.Tables[0].Rows[0]["CenterlizeBilling"].ToString());
        txtBillingLocation.Text = ds.Tables[0].Rows[0]["CenterlizeBillingLocationCode"].ToString();
        hfBillingLocationAutoID.Value = ds.Tables[0].Rows[0]["CenterlizeBillingLocationAutoID"].ToString();
        FillddlClientBillingId();
        ddlAsmtBillingId.SelectedValue = ds.Tables[0].Rows[0]["AsmtBillingId"].ToString() == "" ? "" : ds.Tables[0].Rows[0]["AsmtBillingId"].ToString();
        txtTerminationDate.Text = DateFormat(ds.Tables[0].Rows[0]["SOTerminationDate"].ToString());
        txtTerminationReason.Text = ds.Tables[0].Rows[0]["SOTerminationReason"].ToString();
        txtTerminatedBy.Text = ds.Tables[0].Rows[0]["SOTerminatedBy"].ToString();
        ddlInvoiceType.SelectedValue = ds.Tables[0].Rows[0]["BillingPattern"].ToString().ToUpper().Trim();
   //  FillddlQuotationNo();
    // ddlGrade.SelectedValue = ds.Tables[0].Rows[0]["QuotationNo"].ToString();
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
    /// Function to Fill Sale Order Types in a DropDown.
    /// </summary>
    protected void FillddlSoType()
    {
        var objSales = new BL.Sales();
        var ds = objSales.SaleOrderTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSoType.DataSource = ds.Tables[0];
            ddlSoType.DataValueField = "SaleOrderTypeCode";
            ddlSoType.DataTextField = "SaleOrderTypeDesc";
            ddlSoType.DataBind();
            if (hfFixedBillingCheck.Value == "1")
            {
                var li1 = new ListItem(Resources.Resource.Select, @"-1");
                ddlSoType.Items.Insert(0, li1);
            }

        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlSoType.Items.Add(li);
        }
    }

    protected void FillddlQuotationNo()
    {
        
        var objSales = new BL.Sales();
        var ds = objSales.GetQuotationNo(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
           
            ddlGrade.DataSource = ds.Tables[0];
            ddlGrade.DataValueField = "QuotationNo";
            ddlGrade.DataTextField = "QuotationNo";
            ddlGrade.DataBind();
          //  ddlGrade.Items.Insert(0, new ListItem("--Select--", "Select"));
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlGrade.Items.Add(li);
        }
       
      
    }

    /// <summary>
    /// To fill the Sale Order Amendment Numbers for the Given Sale Order
    /// </summary>
    /// <param name="strSoNo">so no</param>
    protected void FillddlSoAmendNo(string strSoNo)
    {
        var objsales = new BL.Sales();
        var ds = objsales.SaleOrderAmendNoGet(BaseLocationAutoID, txtSoNo.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSOAmendNO.DataSource = ds.Tables[0];
            ddlSOAmendNO.DataTextField = "SOAmendNo";
            ddlSOAmendNO.DataValueField = "SOAmendNo";
            ddlSOAmendNO.DataBind();
            ddlSOAmendNO.SelectedIndex = 0;
            hfIsMAXSOAmendNo.Value = "MAX";
            GetSelectedSaleOrder();
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlSOAmendNO.Items.Add(li);
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

    #region GridView gvSaleOrderDetails

    #region GridView SaleOrderServicedetails Controles Events

    /// <summary>
    /// Function to Fill the Sale Order Service Details Grid View.
    /// </summary>
    /// <param name="strFilterAsmtId">Assignment Id to Filter</param>
    protected void FillgvSaleOrderDetails(string strFilterAsmtId = @"")
    {
        if (strFilterAsmtId == string.Empty)
        {
            strFilterAsmtId = hiddenFieldAsmtIdFilter.Value;
        }
        var objsales = new BL.Sales();
        var ds = BaseUserIsAreaIncharge == "1"
            ? objsales.SaleOrderDetailGet(BaseLocationAutoID, txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value, strFilterAsmtId, BaseUserEmployeeNumber)
            : objsales.SaleOrderDetailGet(BaseLocationAutoID, txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value, strFilterAsmtId);

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
                    gvSaleOrderDetails.DataSource = dt;
                    gvSaleOrderDetails.DataBind();
                    gvSaleOrderDetails.Rows[0].Visible = false;
                    lblSOLineTotalValue.Text = GetValueAsPerSystemParameters("0.0000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }
                else if (dt.Rows.Count > 0)
                {
                    hfTotalRowCount.Value = dt.Rows.Count.ToString();
                    gvSaleOrderDetails.DataSource = dt;
                    gvSaleOrderDetails.DataBind();

                    hfIsMultipleLocation.Value = ds.Tables[3].Rows[0]["LocationCount"].ToString();
                    decimal saleOrderLineTotalValue = 0;
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {

                        if ((bool.Parse(dt.Rows[i]["Active"].ToString())) || CompareDates(DateTime.Parse(dt.Rows[i]["SOLineEndDate"].ToString()), DateTime.Now.Date) != 2)
                        {
                            saleOrderLineTotalValue = saleOrderLineTotalValue + decimal.Parse(dt.Rows[i]["monthlyBilling"].ToString());
                        }

                    }

                    lblSOLineTotalValue.Text = GetValueAsPerSystemParameters(saleOrderLineTotalValue.ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }
            }

            gvSaleOrderDetails.PagerStyle.HorizontalAlign = HorizontalAlign.Left;
            gvSaleOrderDetails.BottomPagerRow.Visible = true;
        }


        if (gvSaleOrderDetails.HeaderRow != null)
        {
            var txtFilterAsmtId = (TextBox)gvSaleOrderDetails.HeaderRow.FindControl("txtFilterAsmtId");
            if (txtFilterAsmtId != null)
            {
                txtFilterAsmtId.Text = hiddenFieldAsmtIdFilter.Value;
            }
        }
        if (gvSaleOrderDetails.FooterRow != null)
        {
            var ddlPayRateType = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlPayRateType");
            if (ddlPayRateType != null)
            {
                ddlPayRateType.SelectedValue = hfPayRateType.Value != "" ? hfPayRateType.Value : @"Normal";
            }
        }

    }


    /// <summary>
    /// Function to Fill the Assignment ID Id Drop Down of Sale Order Details Grid View exists in the Footer.
    /// </summary>
    /// <param name="strLocationAutoId">Location Auto Id</param>
    /// <param name="ddlgvAsmtId">ddl Assignment ID</param>
    /// <param name="ddlgvPostCode">ddl Post Code</param>
    /// <param name="wefDate">With effective date</param>
    protected void FillddlAsmtId(string strLocationAutoId, DropDownList ddlgvAsmtId, DropDownList ddlgvPostCode, string wefDate)
    {
        var objSales = new BL.Sales();
        if (cbCenterlizeBilling.Checked)
        {
            strLocationAutoId = string.Empty;
        }

        using (var ds = objSales.ClientAsmtIdsGetAll(strLocationAutoId, txtClientCode.Text, BaseUserEmployeeNumber, wefDate))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlgvAsmtId.DataSource = ds.Tables[0];
                ddlgvAsmtId.DataValueField = "AsmtId";
                ddlgvAsmtId.DataTextField = "AsmtIdAddress";
                ddlgvAsmtId.DataBind();
                FillddlgvPostCode(ddlgvAsmtId.SelectedItem.Value, ddlgvPostCode);
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
        }
    }

    /// <summary>
    /// Function to fill the Post of selected Assignment ID in the Footer of the Sale order Service Details Grid View
    /// </summary>
    /// <param name="strAsmtId">str Assignment ID Id</param>
    /// <param name="ddlgvPostCode">ddl gv Post Code</param>
    protected void FillddlgvPostCode(string strAsmtId, DropDownList ddlgvPostCode)
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
            var li = new ListItem( Resources.Resource.NoDataToShow, string.Empty);
            ddlgvPostCode.Items.Add(li);
        }
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
    /// <param name="ddlTypeOfService">ddl Type Of Service</param>
    protected void FillddlTypeOfService(DropDownList ddlTypeOfService)
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.QuickCode2ItemsGet(BaseCompanyCode, "TypeOfService");

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTypeOfService.DataSource = ds.Tables[0];
            ddlTypeOfService.DataValueField = "ItemCode";
            ddlTypeOfService.DataTextField = "ItemDesc";
            ddlTypeOfService.DataBind();
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlTypeOfService.Items.Add(li);
        }
    }

    /// <summary>
    /// Function to Fill the So Rank Drop Down of Sale Order Service Details Grid View.
    /// </summary>
    /// <param name="ddlgvSoRank">ddl gv So Rank</param>
    protected void FillddlgvSoRank(DropDownList ddlgvSoRank)
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.SaleOrderRankGet(BaseCompanyCode);
       if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlgvSoRank.DataSource = ds.Tables[0];
            ddlgvSoRank.DataValueField = "SORank";
            ddlgvSoRank.DataTextField = "SORank";
            ddlgvSoRank.DataBind();
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlgvSoRank.Items.Add(li);
        }
    }
   protected void  FillChargeRateOnTheBasisOfQuotation(TextBox txtSoNo,DropDownList ddlSoRank,TextBox txtChargeRate)
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.GetChargeRate(txtSoNo.Text, ddlSoRank.SelectedItem.Value, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtChargeRate.Text = ds.Tables[0].Rows[0]["ChargeRateperhour"].ToString();
        }
        else
        {
            txtChargeRate.Text = "1";
        }
      
    }
    /// <summary>
    /// Function to fill the Deployment Pattern Drop down of sale order service details grid view
    /// </summary>
    /// <param name="ddlDeploymentPattern">ddl Deployment Pattern</param>
    protected void FillddlDeploymentPattern(DropDownList ddlDeploymentPattern)
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.QuickCodeDeploymentPatternGet(BaseCompanyCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDeploymentPattern.DataSource = ds.Tables[0];
            ddlDeploymentPattern.DataValueField = "ItemCode";
            ddlDeploymentPattern.DataTextField = "ItemDesc";
            ddlDeploymentPattern.DataBind();
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, "1"); //string.Empty);
            ddlDeploymentPattern.Items.Add(li);
        }
    }

    /// <summary>
    /// Function to fill the Allowance Mode Drop Down of Sale order Service details Grid View.
    /// </summary>
    /// <param name="ddlAllowancesMode">ddl Allowances Mode</param>
    protected void FillddlAllowancesMode(DropDownList ddlAllowancesMode)
    {
        var objHrManagement = new BL.HRManagement();
        DataSet ds = objHrManagement.AllowancesModeMasterGet(BaseCompanyCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAllowancesMode.DataSource = ds.Tables[0];
            ddlAllowancesMode.DataValueField = "ItemCode";
            ddlAllowancesMode.DataTextField = "ItemDesc";
            ddlAllowancesMode.DataBind();

            var li1 = new ListItem(Resources.Resource.Select, string.Empty);
            ddlAllowancesMode.Items.Insert(0, li1);
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlAllowancesMode.Items.Add(li);
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
        var ddlgvPostCode = (DropDownList)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("ddlgvPostCode");
        FillddlgvPostCode(ddlgvAsmtId.SelectedItem.Value, ddlgvPostCode);

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
        var ddlgvPostCode = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlgvPostCode");
        FillddlgvPostCode(ddlgvAsmtId.SelectedItem.Value, ddlgvPostCode);
        var imgbtnPost = (ImageButton)gvSaleOrderDetails.FooterRow.FindControl("imgbtnPost");

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
    /// On Selection Change of So Rank of Footer Template Control of SaleOrder Service Details Grid View.
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlgvSoRank_SelectedIndexChangedFooter(object sender, EventArgs e)
    {
        var ddlgvSoRank = (DropDownList)sender;
        var txtBillingDesignation = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtBillingDesignation");
        txtBillingDesignation.Text = ddlgvSoRank.SelectedItem.Text;
        var txtTypeOfItem = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtTypeOfItem");
        txtTypeOfItem.Text = ddlgvSoRank.SelectedItem.Text;

        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(txtBillingDesignation);
        }

        var txtChargeRatePerHrs = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtChargeRatePerHrs");
       FillChargeRateOnTheBasisOfQuotation(txtSoNo, ddlgvSoRank, txtChargeRatePerHrs);
    }

    /// <summary>
    /// On Selection Change of So Rank of Edit Template Control of SaleOrder Service Details Grid View.
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlgvSoRank_SelectedIndexChangedEdit(object sender, EventArgs e)
    {
        var ddlgvSoRank = (DropDownList)sender;
        var gridViewRow = (GridViewRow)ddlgvSoRank.NamingContainer;
        var txtBillingDesignation = (TextBox)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("txtBillingDesignation");
        txtBillingDesignation.Text = ddlgvSoRank.SelectedItem.Text;
        var txtTypeOfItem = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtTypeOfItem");
        txtTypeOfItem.Text = ddlgvSoRank.SelectedItem.Text;
        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(txtBillingDesignation);
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
        var txtSoLineStartDate = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtSoLineStartDate");
        var txtSoLineEndDate = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtSoLineEndDate");
        var txtSoLineWefDate = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtSoLineWefDate");
        var hiddenfieldSoLineStartDate = (HiddenField)gvSaleOrderDetails.FooterRow.FindControl("hiddenfieldSoLineStartDate");
        var hiddenfieldSoLineEndDate = (HiddenField)gvSaleOrderDetails.FooterRow.FindControl("hiddenfieldSoLineEndDate");
        FillContractDetails(ddlContractNumber, txtSoLineStartDate, txtSoLineEndDate, txtSoLineWefDate, hiddenfieldSoLineStartDate, hiddenfieldSoLineEndDate, "Footer");
    }

    /// <summary>
    /// Fill Contract dropdown
    /// </summary>
    /// <param name="ddlContractNumber">Contract Number</param>
    /// <param name="txtSoLineStartDate">Soline Start Date</param>
    /// <param name="txtSoLineEndDate">Soline End Date</param>
    /// <param name="txtWefDate">With effective Date</param>
    /// <param name="hiddenfieldSoLineStartDate">hidden field Soline Start Date</param>
    /// <param name="hiddenfieldSoLineEndDate">hidden field Soline End Date</param>
    /// <param name="status">Status field</param>
    protected void FillContractDetails(DropDownList ddlContractNumber, TextBox txtSoLineStartDate, TextBox txtSoLineEndDate, TextBox txtWefDate, HiddenField hiddenfieldSoLineStartDate, HiddenField hiddenfieldSoLineEndDate, string status)
    {
        var objSales = new BL.Sales();
        using (DataSet ds = objSales.ContractDetailGet(BaseLocationAutoID, txtClientCode.Text, ddlContractNumber.SelectedValue))
        {

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (status.Trim().ToLower() == "footer")
                {
                    txtSoLineStartDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    hiddenfieldSoLineStartDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    txtSoLineEndDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                    hiddenfieldSoLineEndDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                    txtWefDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                }
                else if (status.Trim().ToLower() == "row")
                {
                    hiddenfieldSoLineStartDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    hiddenfieldSoLineEndDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                }
                else
                {
                    txtSoLineStartDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    hiddenfieldSoLineStartDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                    txtSoLineEndDate.Text = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
                    hiddenfieldSoLineEndDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtEndDate"].ToString());
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
        var txtSoLineStartDate = (TextBox)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("txtSoLineStartDate");
        var txtSoLineEndDate = (TextBox)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("txtSoLineEndDate");
        var txtSoLineWefDate = (TextBox)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("txtSoLineWefDate");
        var hiddenfieldSoLineStartDate = (HiddenField)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("hiddenfieldSoLineStartDate");
        var hiddenfieldSoLineEndDate = (HiddenField)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("hiddenfieldSoLineEndDate");
        FillContractDetails(ddlContractNumber, txtSoLineStartDate, txtSoLineEndDate, txtSoLineWefDate, hiddenfieldSoLineStartDate, hiddenfieldSoLineEndDate, string.Empty);
    }

    /// <summary>
    /// On Selection Change of drop down pay rate of Edit Template Control .
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void ddlPayRateType_SelectedIndexChangedEdit(object sender, EventArgs e)
    {

        var ddlPayRateType = (DropDownList)sender;
        var gridViewRow = (GridViewRow)ddlPayRateType.NamingContainer;
        if (ddlPayRateType.SelectedValue == "Post")
        {
            var wages = (HiddenField)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("hfDailyMinWages");
            if (Convert.ToDouble(wages.Value) <= 0.00)
            {
                Show(Resources.Resource.PostPayRateCannotBeZero);
                ddlPayRateType.SelectedValue = "Normal";
                return;
            }

        }
    }
    protected void checkBoxBillable_OnCheckedChanged(object sender, EventArgs e)
    {
        var checkPayratetype = (CheckBox)sender;
        var gridViewRow = (GridViewRow)checkPayratetype.NamingContainer;
        {
            var wages = (HiddenField)gvSaleOrderDetails.Rows[gridViewRow.RowIndex].FindControl("hfDailySellingRate");
            if (Convert.ToDouble(wages.Value) <= 0.00)
            {
                Show(Resources.Resource.CannotBeBillable);
                checkPayratetype.Checked = false;
                return;
            }

        }
    }
    /// <summary>
    /// Function to Validate the Start, End and Wef Date of Sale order Service Details Dates.
    /// </summary>
    /// <param name="strSoWefDate">str So Wef Date</param>
    /// <param name="strSoLineStartDate">str So Line Start Date</param>
    /// <param name="strSoLineEndDate">str So Line End Date</param>
    /// <param name="strSoLineWefDate">str So Line Wef Date</param>
    /// <param name="strContractStartDate">str Contract Start Date</param>
    /// <param name="strContractEndDate">str Contract End Date</param>
    /// <param name="strContractEndDateStatus">str Contract End Date Status</param>
    /// <returns>true or false</returns>
    protected bool ValidateSoDetailsDates(string strSoWefDate, string strSoLineStartDate, string strSoLineEndDate, string strSoLineWefDate, string strContractStartDate, string strContractEndDate, string strContractEndDateStatus)
    {
        if (strSoWefDate == string.Empty || strSoLineStartDate == string.Empty || strSoLineEndDate == string.Empty || strSoLineWefDate == string.Empty)
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.DateCannotbeleftBlank);
            return false;
        }

        DateTime dateTimeSoLineStartDate = DateTime.Parse(strSoLineStartDate);
        DateTime dateTimeSoLineEndDate = DateTime.Parse(strSoLineEndDate);
        DateTime dateTimeSoLineWefDate = DateTime.Parse(strSoLineWefDate);
        DateTime dateTimeContractStartDate = DateTime.Parse(strContractStartDate);
        DateTime dateTimeContractEndDate = DateTime.Parse(strContractEndDate);

        if (strContractEndDateStatus != "-1")
        {
            var hiddenFieldPreviousSoLineEndDate = (HiddenField)gvSaleOrderDetails.Rows[int.Parse(strContractEndDateStatus)].FindControl("hiddenFieldPreviousSoLineEndDate");
            if (hiddenFieldSoStatus.Value == strStatusAmend && dateTimeSoLineEndDate < DateTime.Parse(hiddenFieldPreviousSoLineEndDate.Value))
            {
                lblErrorMsg.Text = Resources.Resource.SoLineEndDateCannotBeModified;
                return false;
            }
        }

        if (dateTimeSoLineWefDate >= dateTimeSoLineStartDate && dateTimeSoLineWefDate <= dateTimeSoLineEndDate && dateTimeSoLineStartDate >= dateTimeContractStartDate && dateTimeSoLineStartDate <= dateTimeContractEndDate && dateTimeSoLineEndDate <= dateTimeContractEndDate)
        {
            return true;
        }

        if (dateTimeSoLineWefDate <= dateTimeSoLineStartDate && dateTimeSoLineWefDate > dateTimeSoLineEndDate)
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.SoLineWefDateShouldBeBetweenStartAndEndDate);
        }
        else if (dateTimeSoLineStartDate < dateTimeContractStartDate)
        {
            lblErrorMsg.Text = Resources.Resource.SoLineStartDateShouldbeGreaterthanorEqualtoContarctStartDate;
        }
        else if (dateTimeSoLineWefDate < dateTimeSoLineStartDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOLineWEFDateCannotBeLessThanSOLineStartDate;
        }
        else if (dateTimeSoLineWefDate > dateTimeSoLineEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOLineWEFDateCannotBeGreaterThanSOLineEndDate;
        }
        else if (dateTimeSoLineStartDate > dateTimeContractEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOLineStartDateCannotBeGreaterThanContractEndDate;
        }
        else if (dateTimeSoLineEndDate > dateTimeContractEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOLineEndDateCannotBeGreaterThanContractEndDate;
        }

        return false;
    }

    /// <summary>
    /// Function to Validate So Item Dates
    /// </summary>
    /// <param name="strSoWefDate">str So Wef Date</param>
    /// <param name="strSoLineStartDate">str So Line Start Date</param>
    /// <param name="strSoLineEndDate">str So Line End Date</param>
    /// <param name="strSoLineWefDate">str So Line Wef Date</param>
    /// <param name="strContractStartDate">str Contract Start Date</param>
    /// <param name="strContractEndDate">str Contract End Date</param>
    /// <param name="strContractEndDateStatus">str Contract End Date Status</param>
    /// <returns>true or false</returns>
    protected bool ValidateSoItemDetailsDates(string strSoWefDate, string strSoLineStartDate, string strSoLineEndDate, string strSoLineWefDate, string strContractStartDate, string strContractEndDate, string strContractEndDateStatus)
    {
        if (strSoWefDate == string.Empty || strSoLineStartDate == string.Empty || strSoLineEndDate == string.Empty || strSoLineWefDate == string.Empty)
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.DateCannotbeleftBlank);
            return false;
        }
        DateTime dateTimeSoLineStartDate = DateTime.Parse(strSoLineStartDate);
        DateTime dateTimeSoLineEndDate = DateTime.Parse(strSoLineEndDate);
        DateTime dateTimeSoLineWefDate = DateTime.Parse(strSoLineWefDate);
        DateTime dateTimeContractStartDate = DateTime.Parse(strContractStartDate);
        DateTime dateTimeContractEndDate = DateTime.Parse(strContractEndDate);

        if (dateTimeSoLineWefDate >= dateTimeSoLineStartDate && dateTimeSoLineWefDate <= dateTimeSoLineEndDate && dateTimeSoLineStartDate >= dateTimeContractStartDate && dateTimeSoLineStartDate <= dateTimeContractEndDate && dateTimeSoLineEndDate <= dateTimeContractEndDate)
        {
            return true;
        }

        if (dateTimeSoLineWefDate <= dateTimeSoLineStartDate && dateTimeSoLineWefDate > dateTimeSoLineEndDate)
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.SoLineWefDateShouldBeBetweenStartAndEndDate);
        }
        else if (dateTimeSoLineStartDate < dateTimeContractStartDate)
        {
            lblErrorMsg.Text = Resources.Resource.SoLineStartDateShouldbeGreaterthanorEqualtoContarctStartDate;
        }
        else if (dateTimeSoLineWefDate < dateTimeSoLineStartDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOLineWEFDateCannotBeLessThanSOLineStartDate;
        }
        else if (dateTimeSoLineWefDate > dateTimeSoLineEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOLineWEFDateCannotBeGreaterThanSOLineEndDate;
        }
        else if (dateTimeSoLineStartDate > dateTimeContractEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOLineStartDateCannotBeGreaterThanContractEndDate;
        }
        else if (dateTimeSoLineEndDate > dateTimeContractEndDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOLineEndDateCannotBeGreaterThanContractEndDate;
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
    protected void GvSaleOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var lblgvhdrChargeRatePerHrs = (Label)e.Row.FindControl("lblgvhdrChargeRatePerHrs");
            lblgvhdrChargeRatePerHrs.Text = Resources.Resource.SellingPrice + @" (" + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @") ";

            var lblgvhdrMinWages = (Label)e.Row.FindControl("lblgvhdrMinWages");
            lblgvhdrMinWages.Text = Resources.Resource.PayRatePerHour + @" (" + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @") ";

            var lblgvhdrOtherAllowances = (Label)e.Row.FindControl("lblgvhdrOtherAllowances");
            lblgvhdrOtherAllowances.Text = Resources.Resource.Allowance + @" (" + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @") ";
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            var imgBtnSkills = (ImageButton)e.Row.FindControl("imgBtnSkills");
            var imgBtnDeployment = (ImageButton)e.Row.FindControl("ImgBtnDeployment");
            var lblgvSoLineNo = (Label)e.Row.FindControl("lblgvSoLineNo");
            var lblgvHours = (Label)e.Row.FindControl("lblgvHours");
            var lblgvNoOfPost = (Label)e.Row.FindControl("lblgvNoOfPost");
            var lblgvChargeRatePerHrs = (Label)e.Row.FindControl("lblgvChargeRatePerHrs");
            var lblgvOtherAllowances = (Label)e.Row.FindControl("lblgvOtherAllowances");
            var hiddenFieldHours = (HiddenField)e.Row.FindControl("hiddenFieldHours");
            var ddlHours = (DropDownList)e.Row.FindControl("ddlHours");
            var hfMinWages = (HiddenField)e.Row.FindControl("hfMinWages");
            var txtNoOfPost = (TextBox)e.Row.FindControl("txtNoOfPost");
            var txtChargeRatePerHrs = (TextBox)e.Row.FindControl("txtChargeRatePerHrs");
            var txtOtherAllowances = (TextBox)e.Row.FindControl("txtOtherAllowances");
            var checkBoxIsAllowanceBillable = (CheckBox)e.Row.FindControl("checkBoxIsAllowanceBillable");
            var checkBoxActive = (CheckBox)e.Row.FindControl("checkBoxActive");
            var checkBoxBillable = (CheckBox)e.Row.FindControl("checkBoxBillable");
            var hlimgSoLineStartDate = (HyperLink)e.Row.FindControl("hlimgSoLineStartDate");
            var imgbtnDelete1 = (ImageButton)e.Row.FindControl("imgbtnDelete");
            var txtPostPosition = (TextBox)e.Row.FindControl("txtPostPosition");
            var hfSolineNo = (HiddenField)e.Row.FindControl("hfSolineNo");
            var lblgvPayRateType = (Label)e.Row.FindControl("lblgvPayRateType");
            var hfPayRateType = (HiddenField)e.Row.FindControl("HFPayRateType");
            var ddlPayRateType = (DropDownList)e.Row.FindControl("ddlPayRateType");
            if (hfPayRateType != null)
            {
                if (lblgvPayRateType != null)
                {
                    lblgvPayRateType.Text = hfPayRateType.Value == @"Normal"
                        ? Resources.Resource.Normal
                        : Resources.Resource.Post;
                }
                if (ddlPayRateType != null)
                {
                    ddlPayRateType.SelectedValue = hfPayRateType.Value;
                }

            }

            if (hiddenFieldSoStatus.Value == strStatusFresh && IsDeleteAccess)
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

            if (hiddenFieldSoStatus.Value == strStatusAmend && IsDeleteAccess)
            {
                if (imgbtnDelete1 != null)
                {

                    if (hfSolineNo != null)
                    {
                        imgbtnDelete1.Visible = hfSolineNo.Value == "0";
                    }
                }


                if (hlimgSoLineStartDate != null)
                {
                    hlimgSoLineStartDate.Visible = false;
                }
            }

            if (hiddenFieldSoStatus.Value == strStatusFresh || hiddenFieldSoStatus.Value == strStatusAmend)
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

            if (imgBtnDeployment != null && lblgvSoLineNo != null && lblgvHours != null && lblgvNoOfPost != null && lblgvChargeRatePerHrs != null && hfMinWages != null && lblgvOtherAllowances != null && checkBoxIsAllowanceBillable != null && ddlInvoiceType != null && checkBoxActive != null && checkBoxBillable != null)
            {
                if (hfPayRateType != null)
                    imgBtnDeployment.Attributes.Add("OnClick", "javascript:OpenSODeploymentPattern('" + BaseLocationAutoID + "','" + txtSoNo.Text + "','" + ddlSOAmendNO.SelectedItem.Value + "','" + lblgvSoLineNo.Text + "','" + hiddenFieldSoStatus.Value + "','" + hfIsMAXSOAmendNo.Value + "','" + lblgvHours.Text + "','" + lblgvNoOfPost.Text + "','" + lblgvChargeRatePerHrs.Text + "','" + hfMinWages.Value + "','" + lblgvOtherAllowances.Text + "','" + checkBoxIsAllowanceBillable.Checked + "','" + hfRemainingDays.Value + "','" + ddlInvoiceType.SelectedItem.Text + "','" + checkBoxActive.Checked + "','" + checkBoxBillable.Checked + "','" + hfPayRateType.Value + "')");
            }

            if (imgBtnDeployment != null && lblgvSoLineNo != null && hiddenFieldHours != null && txtNoOfPost != null && txtChargeRatePerHrs != null && hfMinWages != null && txtOtherAllowances != null && checkBoxIsAllowanceBillable != null && ddlInvoiceType != null && checkBoxActive != null && checkBoxBillable != null)
            {
                imgBtnDeployment.Attributes.Add("OnClick", "javascript:OpenSODeploymentPattern('" + BaseLocationAutoID + "','" + txtSoNo.Text + "','" + ddlSOAmendNO.SelectedItem.Value + "','" + lblgvSoLineNo.Text + "','" + hiddenFieldSoStatus.Value + "','" + hfIsMAXSOAmendNo.Value + "','" + hiddenFieldHours.Value + "','" + txtNoOfPost.Text + "','" + txtChargeRatePerHrs.Text + "','" + hfMinWages.Value + "','" + txtOtherAllowances.Text + "','" + checkBoxIsAllowanceBillable.Checked + "','" + hfRemainingDays.Value + "','" + ddlInvoiceType.SelectedItem.Text + "','" + checkBoxActive.Checked + "','" + checkBoxBillable.Checked + "')");
            }

            if (imgBtnSkills != null && checkBoxActive != null && lblgvSoLineNo != null)
            {
                imgBtnSkills.Attributes.Add("OnClick", "javascript:OpenSOSkills('" + BaseLocationAutoID + "','" + txtSoNo.Text + "','" + ddlSOAmendNO.SelectedItem.Value + "','" + lblgvSoLineNo.Text + "','" + hiddenFieldSoStatus.Value + "','" + hfIsMAXSOAmendNo.Value + "','" + checkBoxActive.Checked + "')");
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
                if (hiddenFieldSoStatus.Value != strStatusAmend && hiddenFieldSoStatus.Value != strStatusFresh)
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
                    var txtSoLineStartDate = (TextBox)e.Row.FindControl("txtSoLineStartDate");
                    var txtSoLineEndDate = (TextBox)e.Row.FindControl("txtSoLineEndDate");
                    var txtSoLineWefDate = (TextBox)e.Row.FindControl("txtSoLineWefDate");
                    var txtHoursInMonth = (TextBox)e.Row.FindControl("txtHoursInMonth");
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
                    if (txtHoursInMonth != null)
                    {
                        txtHoursInMonth.Attributes.Add("readonly", "readonly");
                    }
                    if (txtSoLineStartDate != null)
                    {
                        txtSoLineStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtSoLineEndDate != null)
                    {
                        txtSoLineEndDate.Attributes.Add("readonly", "readonly");
                    }

                    if (txtSoLineWefDate != null)
                    {
                        txtSoLineWefDate.Attributes.Add("readonly", "readonly");
                    }

                    if (txtPostPosition != null)
                    {
                        txtPostPosition.Attributes.Add("readonly", "readonly");
                    }
                    var ddlgvAsmtId = (DropDownList)e.Row.FindControl("ddlgvAsmtId");
                    var ddlgvPostCode = (DropDownList)e.Row.FindControl("ddlgvPostCode");
                    var ddlContractNumber = (DropDownList)e.Row.FindControl("ddlContractNumber");
                    var ddlTypeOfService = (DropDownList)e.Row.FindControl("ddlTypeOfService");
                    var ddlgvSoRank = (DropDownList)e.Row.FindControl("ddlgvSoRank");
                    var ddlDeploymentPattern = (DropDownList)e.Row.FindControl("ddlDeploymentPattern");
                    var ddlAllowancesMode = (DropDownList)e.Row.FindControl("ddlAllowancesMode");
                    var hiddenFieldAsmtId = (HiddenField)e.Row.FindControl("hiddenFieldAsmtId");
                    var hiddenFieldPostAutoId = (HiddenField)e.Row.FindControl("hiddenFieldPostAutoID");
                    var hiddenFieldContractNumber = (HiddenField)e.Row.FindControl("hiddenFieldContractNumber");
                    var hiddenFieldDeploymentPattern = (HiddenField)e.Row.FindControl("hiddenFieldDeploymentPattern");
                    var hiddenFieldTypeOfService = (HiddenField)e.Row.FindControl("hiddenFieldTypeOfService");
                    var hiddenFieldSoRank = (HiddenField)e.Row.FindControl("hiddenFieldSoRank");
                    var hiddenFieldAllowancesMode = (HiddenField)e.Row.FindControl("hiddenFieldAllowancesMode");

                    if (ddlgvAsmtId != null && ddlgvPostCode != null && hiddenFieldAsmtId != null && hiddenFieldPostAutoId != null)
                    {

                        FillddlAsmtId(BaseLocationAutoID, ddlgvAsmtId, ddlgvPostCode, string.Empty);
                        ddlgvAsmtId.SelectedIndex = ddlgvAsmtId.Items.IndexOf(ddlgvAsmtId.Items.FindByValue(hiddenFieldAsmtId.Value));
                        FillddlgvPostCode(ddlgvAsmtId.SelectedItem.Value, ddlgvPostCode);
                        ddlgvPostCode.SelectedIndex = ddlgvPostCode.Items.IndexOf(ddlgvPostCode.Items.FindByValue(hiddenFieldPostAutoId.Value));
                    }
                    if (ddlContractNumber != null && hiddenFieldContractNumber != null)
                    {
                        FillddlContractNumber(ddlContractNumber);
                        ddlContractNumber.SelectedIndex = ddlContractNumber.Items.IndexOf(ddlContractNumber.Items.FindByValue(hiddenFieldContractNumber.Value));
                    }
                    //if (lblSOStatus.Text != Resources.Resource.Fresh)
                    //{
                    if (ddlgvAsmtId != null && ddlgvPostCode != null && ddlContractNumber != null)
                    {
                        ddlgvAsmtId.Enabled = false;
                        ddlgvPostCode.Enabled = false;
                        ddlContractNumber.Enabled = false;
                        ddlgvSoRank.Enabled = false;
                    }
                    //}
                    //else
                    //{
                    //    if (ddlgvAsmtId != null)
                    //    {
                    //        ddlgvAsmtId.Enabled = true;
                    //        ddlgvPostCode.Enabled = true;
                    //        ddlContractNumber.Enabled = true;
                    //    }
                    //}

                    if (ddlTypeOfService != null && hiddenFieldTypeOfService != null)
                    {
                        FillddlTypeOfService(ddlTypeOfService);
                        ddlTypeOfService.SelectedIndex = ddlTypeOfService.Items.IndexOf(ddlTypeOfService.Items.FindByValue(hiddenFieldTypeOfService.Value));
                    }

                    if (ddlgvSoRank != null && hiddenFieldSoRank != null)
                    {
                        FillddlgvSoRank(ddlgvSoRank);
                        ddlgvSoRank.SelectedIndex = ddlgvSoRank.Items.IndexOf(ddlgvSoRank.Items.FindByValue(hiddenFieldSoRank.Value));
                    }

                    if (ddlDeploymentPattern != null && hiddenFieldDeploymentPattern != null)
                    {
                        FillddlDeploymentPattern(ddlDeploymentPattern);
                        ddlDeploymentPattern.SelectedIndex = ddlDeploymentPattern.Items.IndexOf(ddlDeploymentPattern.Items.FindByValue(hiddenFieldDeploymentPattern.Value));
                    }

                    if (ddlAllowancesMode != null && hiddenFieldAllowancesMode != null)
                    {
                        FillddlAllowancesMode(ddlAllowancesMode);
                        ddlAllowancesMode.SelectedIndex = ddlAllowancesMode.Items.IndexOf(ddlAllowancesMode.Items.FindByValue(hiddenFieldAllowancesMode.Value));
                    }

                    var txtMonthlyBilling = (TextBox)e.Row.FindControl("txtMonthlyBilling");
                    var txtMinProfitability = (TextBox)e.Row.FindControl("txtMinProfitability");
                    var txtOptimumProfitability = (TextBox)e.Row.FindControl("txtOptimumProfitability");
                    SetFloatValidationToTextBox(txtMonthlyBilling);
                    SetFloatValidationToTextBox(txtMinProfitability);
                    SetFloatValidationToTextBox(txtOptimumProfitability);

                    var txtDaysInMonth = (TextBox)e.Row.FindControl("txtDaysInMonth");

                    if (txtNoOfPost != null)
                    {
                        txtNoOfPost.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                        txtNoOfPost.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    }

                    if (ddlHours != null)
                    {
                        FillddlDeploymentPattern(ddlHours);
                        ddlHours.SelectedValue = hiddenFieldHours.Value;
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

                    if (txtChargeRatePerHrs != null)
                    {
                        txtChargeRatePerHrs.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtChargeRatePerHrs.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                    var hiddenfieldSoLineStartDate = (HiddenField)e.Row.FindControl("hiddenfieldSoLineStartDate");
                    var hiddenfieldSoLineEndDate = (HiddenField)e.Row.FindControl("hiddenfieldSoLineEndDate");
                    var saleOrderLineExistsInOps = (HiddenField)e.Row.FindControl("saleOrderLineExistsInOps");

                    if (ddlContractNumber != null && hiddenfieldSoLineStartDate != null && hiddenfieldSoLineEndDate != null)
                    {
                        FillContractDetails(ddlContractNumber, txtSoLineStartDate, txtSoLineEndDate, txtSoLineWefDate, hiddenfieldSoLineStartDate, hiddenfieldSoLineEndDate, "Row");

                    }

                    var hiddenFieldSoDeptShift = (HiddenField)e.Row.FindControl("hiddenFieldSoDeptShift");
                    if (hiddenFieldSoDeptShift != null && imgBtnDeployment != null)
                    {
                        imgBtnDeployment.ImageUrl = hiddenFieldSoDeptShift.Value == @"0" ? "~/Images/employee-scheduling-disabled.png" : "~/Images/employee-scheduling-enable.png";
                    }
                    if (hiddenFieldSoStatus.Value != strStatusFresh)
                    {
                        if (ddlgvAsmtId != null && saleOrderLineExistsInOps != null && saleOrderLineExistsInOps.Value != "0")
                        {
                            ddlgvAsmtId.Enabled = false;
                        }

                        if (ddlContractNumber != null && saleOrderLineExistsInOps != null && saleOrderLineExistsInOps.Value != "0")
                        {
                            ddlContractNumber.Enabled = false;
                        }

                        if (ddlgvPostCode != null && saleOrderLineExistsInOps != null && saleOrderLineExistsInOps.Value != "0")
                        {
                            ddlgvPostCode.Enabled = false;
                        }

                        if (ddlgvSoRank != null)
                        {
                            ddlgvSoRank.Enabled = false;
                        }
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
                if (hiddenFieldSoStatus.Value != strStatusFresh && hiddenFieldSoStatus.Value != strStatusAmend)
                {
                    gvSaleOrderDetails.ShowFooter = false;
                }
                else
                {
                    gvSaleOrderDetails.ShowFooter = true;
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

                    var txtChargeRatePerHrs = (TextBox)e.Row.FindControl("txtChargeRatePerHrs");
                    var txtNoOfPost = (TextBox)e.Row.FindControl("txtNoOfPost");
                    var ddlHours = (DropDownList)e.Row.FindControl("ddlHours");
                    var txtDaysInMonth = (TextBox)e.Row.FindControl("txtDaysInMonth");
                    var txtOtherAllowances = (TextBox)e.Row.FindControl("txtOtherAllowances");

                    var txtPostPosition = (TextBox)e.Row.FindControl("txtPostPosition");
                    var txtMonthlyBilling = (TextBox)e.Row.FindControl("txtMonthlyBilling");
                    var txtMinProfitability = (TextBox)e.Row.FindControl("txtMinProfitability");
                    var txtOptimumProfitability = (TextBox)e.Row.FindControl("txtOptimumProfitability");
                    SetFloatValidationToTextBox(txtMonthlyBilling);
                    SetFloatValidationToTextBox(txtMinProfitability);
                    SetFloatValidationToTextBox(txtOptimumProfitability);

                    if (txtNoOfPost != null)
                    {
                        txtNoOfPost.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                        txtNoOfPost.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    }
                    if (ddlHours != null)
                    {
                        FillddlDeploymentPattern(ddlHours);
                    }

                    if (txtDaysInMonth != null)
                    {
                        txtDaysInMonth.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtDaysInMonth.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtDaysInMonth.Text = hfDaysInMonth.Value;
                    }

                    if (txtOtherAllowances != null)
                    {
                        txtOtherAllowances.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtOtherAllowances.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtOtherAllowances.Text = GetValueAsPerSystemParameters("0.00000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                    }

                    if (txtChargeRatePerHrs != null)
                    {
                        txtChargeRatePerHrs.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtChargeRatePerHrs.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }

                    if (txtPostPosition != null)
                    {
                        txtPostPosition.Attributes.Add("readonly", "readonly");
                    }

                    var txtSoLineStartDate = (TextBox)e.Row.FindControl("txtSoLineStartDate");
                    var txtSoLineEndDate = (TextBox)e.Row.FindControl("txtSoLineEndDate");
                    var txtSoLineWefDate = (TextBox)e.Row.FindControl("txtSoLineWefDate");
                    var txtHoursInMonth = (TextBox)e.Row.FindControl("txtHoursInMonth");
                    if (txtHoursInMonth != null)
                    {
                        txtHoursInMonth.Attributes.Add("readonly", "readonly");
                    }
                    if (txtSoLineStartDate != null)
                    {
                        txtSoLineStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtSoLineEndDate != null)
                    {
                        txtSoLineEndDate.Attributes.Add("readonly", "readonly");
                    }

                    if (txtSoLineWefDate != null)
                    {
                        txtSoLineWefDate.Attributes.Add("readonly", "readonly");
                    }
                    var ddlgvAsmtId = (DropDownList)e.Row.FindControl("ddlgvAsmtId");
                    var ddlgvPostCode = (DropDownList)e.Row.FindControl("ddlgvPostCode");
                    var ddlContractNumber = (DropDownList)e.Row.FindControl("ddlContractNumber");
                    var ddlTypeOfService = (DropDownList)e.Row.FindControl("ddlTypeOfService");
                    var ddlgvSoRank = (DropDownList)e.Row.FindControl("ddlgvSoRank");
                    var ddlDeploymentPattern = (DropDownList)e.Row.FindControl("ddlDeploymentPattern");
                    var ddlAllowancesMode = (DropDownList)e.Row.FindControl("ddlAllowancesMode");
                    var imgbtnPost = (ImageButton)e.Row.FindControl("imgbtnPost");
                    if (imgbtnPost != null && ddlgvAsmtId != null)
                    {
                        FillddlAsmtId(BaseLocationAutoID, ddlgvAsmtId, ddlgvPostCode, txtSoLineWefDate.Text);
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
                    if (ddlTypeOfService != null)
                    {
                        FillddlTypeOfService(ddlTypeOfService);
                    }
                    if (ddlgvSoRank != null)
                    {
                        FillddlgvSoRank(ddlgvSoRank);
                                FillChargeRateOnTheBasisOfQuotation(txtSoNo, ddlgvSoRank, txtChargeRatePerHrs);
                        if (ddlgvSoRank.SelectedValue == string.Empty)
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
                    if (ddlDeploymentPattern != null)
                    {
                        FillddlDeploymentPattern(ddlDeploymentPattern);

                        if (ddlHours != null)
                        {
                            FillddlDeploymentPattern(ddlHours);
                            ddlHours.SelectedValue = ddlDeploymentPattern.SelectedItem.Text;
                        }

                        if (ddlDeploymentPattern.SelectedValue == string.Empty)
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
                    if (ddlAllowancesMode != null)
                    {
                        FillddlAllowancesMode(ddlAllowancesMode);
                    }
                    var hiddenfieldSoLineStartDate = (HiddenField)e.Row.FindControl("hiddenfieldSoLineStartDate");
                    var hiddenfieldSoLineEndDate = (HiddenField)e.Row.FindControl("hiddenfieldSoLineEndDate");
                    if (ddlContractNumber != null && hiddenfieldSoLineStartDate != null && hiddenfieldSoLineEndDate != null && txtSoLineStartDate != null && txtSoLineEndDate != null && txtSoLineWefDate != null)
                    {
                        FillContractDetails(ddlContractNumber, txtSoLineStartDate, txtSoLineEndDate, txtSoLineWefDate, hiddenfieldSoLineStartDate, hiddenfieldSoLineEndDate, "Footer");

                    }
                    var txtBillingDesignation = (TextBox)e.Row.FindControl("txtBillingDesignation");
                    var txtTypeOfItem = (TextBox)e.Row.FindControl("txtTypeOfItem");
                    var txtMinWages = (TextBox)e.Row.FindControl("txtMinWages");
                    if (txtBillingDesignation != null && txtTypeOfItem != null && ddlgvSoRank != null && txtMinWages != null)
                    {
                        txtBillingDesignation.Text = ddlgvSoRank.SelectedItem.Text;
                        txtTypeOfItem.Text = ddlgvSoRank.SelectedItem.Text;
                    }
                }
            }
        }
        gvSaleOrderDetails.Columns[8].Visible = false;
        gvSaleOrderDetails.Columns[9].Visible = false;
        gvSaleOrderDetails.Columns[10].Visible = false;
        gvSaleOrderDetails.Columns[13].Visible = false;
        gvSaleOrderDetails.Columns[26].Visible = false;
        gvSaleOrderDetails.Columns[27].Visible = false;
    }

    /// <summary>
    /// gv Sale Order Details Row Command
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Command Event Args</param>
    protected void GvSaleOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvSaleOrderDetails.PageIndex = 0;
                break;
            case "Prev":
                _index = 1;
                break;
            case "Next":
                _index = 0;
                break;
            case "Last":
                gvSaleOrderDetails.PageIndex = gvSaleOrderDetails.PageCount;
                break;
        }
        var objSales = new BL.Sales();
        var ddlContractNumber = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlContractNumber");
        var ddlgvAsmtId = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlgvAsmtId");
        var ddlgvPostCode = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlgvPostCode");
        var ddlgvSoRank = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlgvSoRank");
        var txtBillingDesignation = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtBillingDesignation");
        var txtNoOfPost = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtNoOfPost");
        var ddlHours = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlHours");
        var ddlDeploymentPattern = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlDeploymentPattern");
        var txtDaysInMonth = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtDaysInMonth");
        var txtSoLineStartDate = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtSoLineStartDate");
        var txtSoLineEndDate = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtSoLineEndDate");
        var txtSoLineWefDate = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtSoLineWefDate");
        var txtChargeRatePerHrs = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtChargeRatePerHrs");
        var ddlTypeOfService = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlTypeOfService");
        var txtTypeOfItem = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtTypeOfItem");
        var checkBoxBillable = (CheckBox)gvSaleOrderDetails.FooterRow.FindControl("checkBoxBillable");
        var checkBoxActive = (CheckBox)gvSaleOrderDetails.FooterRow.FindControl("checkBoxActive");
        var txtMinWages = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtMinWages");
        var txtOtherAllowances = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtOtherAllowances");
        var ddlAllowancesMode = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlAllowancesMode");
        var checkBoxIsAllowanceBillable = (CheckBox)gvSaleOrderDetails.FooterRow.FindControl("checkBoxIsAllowanceBillable");
        var hiddenfieldSoLineStartDate = (HiddenField)gvSaleOrderDetails.FooterRow.FindControl("hiddenfieldSoLineStartDate");
        var hiddenfieldSoLineEndDate = (HiddenField)gvSaleOrderDetails.FooterRow.FindControl("hiddenfieldSoLineEndDate");
        var txtMonthlyBilling = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtMonthlyBilling");
        var txtMinProfitability = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtMinProfitability");
        var txtOptimumProfitability = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtOptimumProfitability");
        var txtServiceCategoryCode = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtServiceCategoryCode");
        var txtPostPosition = (TextBox)gvSaleOrderDetails.FooterRow.FindControl("txtPostPosition");
        var ddlPayRateType = (DropDownList)gvSaleOrderDetails.FooterRow.FindControl("ddlPayRateType");
        string strMinManPower;
        string strMaxManPower;
        if (ddlHours.SelectedValue != string.Empty)
        {
            if (decimal.Parse(ddlHours.SelectedValue) > 0)
            {
                strMinManPower = /*"1";*/ Convert.ToString(decimal.Parse(ddlHours.SelectedValue) / decimal.Parse(ddlDeploymentPattern.SelectedItem.Value));
                strMaxManPower = /*"1";*/ Convert.ToString(decimal.Parse(ddlHours.SelectedValue) / decimal.Parse(ddlDeploymentPattern.SelectedItem.Value));
            }
            else
            {
                strMinManPower = "0";
                strMaxManPower = "0";
            }
        }
        else
        {
            strMinManPower = "0";
            strMaxManPower = "0";
        }

        if (e.CommandName == "Add")
        {
            string strContractEndDateStatus = "-1";
            if (ValidateSoDetailsDates(txtWefdt.Text, txtSoLineStartDate.Text, txtSoLineEndDate.Text, txtSoLineWefDate.Text, hiddenfieldSoLineStartDate.Value, hiddenfieldSoLineEndDate.Value, strContractEndDateStatus))
            {
                if (txtMinWages.Text == string.Empty)
                {
                    Show(Resources.Resource.PostPayRateCannotBeZero);
                    txtMinWages.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }

                if (txtMinProfitability.Text == string.Empty)
                {
                    txtMinProfitability.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }

                if (txtOptimumProfitability.Text == string.Empty)
                {
                    txtOptimumProfitability.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }

                if (txtMonthlyBilling.Text == string.Empty)
                {
                    txtMonthlyBilling.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }

                if (ddlgvAsmtId.SelectedItem.Value != string.Empty && ddlgvPostCode.SelectedItem.Value != string.Empty && ddlgvSoRank.SelectedItem.Value != string.Empty && ddlContractNumber.SelectedItem.Value != string.Empty)
                {
                    if (ddlSoType.SelectedItem.Value != @"FIXED" || (ddlSoType.SelectedItem.Value == @"FIXED" && decimal.Parse(txtMonthlyBilling.Text) >= 0))
                    {
                        double sellingPrice = double.Parse(txtMonthlyBilling.Text);
                        DataSet ds = objSales.SaleOrderDetailAddNew(BaseLocationAutoID, txtSoNo.Text, ddlSOAmendNO.SelectedValue, ddlContractNumber.SelectedValue,
                                                                    ddlgvAsmtId.SelectedValue, ddlgvPostCode.SelectedValue, ddlgvSoRank.SelectedValue, txtBillingDesignation.Text,
                                                                    txtNoOfPost.Text, ddlHours.SelectedValue, /*txtHours.Text*/ ddlDeploymentPattern.SelectedValue,
                                                                    strMinManPower, strMaxManPower, txtDaysInMonth.Text, hiddenFieldHoursInMonth.Value,
                                                                    txtSoLineWefDate.Text, txtSoLineEndDate.Text, txtSoLineWefDate.Text,
                                                                    ddlTypeOfService.SelectedValue, txtTypeOfItem.Text, bool.Parse(checkBoxBillable.Checked.ToString()),
                                                                    bool.Parse(checkBoxActive.Checked.ToString()), txtMinWages.Text,
                                                                    txtOtherAllowances.Text, ddlAllowancesMode.SelectedValue, bool.Parse(checkBoxIsAllowanceBillable.Checked.ToString()),
                                                                    txtChargeRatePerHrs.Text, sellingPrice, txtMinProfitability.Text, txtOptimumProfitability.Text,
                                                                    txtServiceCategoryCode.Text, txtPostPosition.Text, BaseUserID, ddlPayRateType.SelectedValue
                                                                    );
                        gvSaleOrderDetails.EditIndex = -1;
                        FillgvSaleOrderDetails();
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.DeploymentPatternshouldbeexactmultipleofHours;
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.SORank + ", " + Resources.Resource.ContractNo + " " + Resources.Resource.AND + " " + Resources.Resource.AsmtId + " " + Resources.Resource.Required);
                }
            }
        }
        else if (e.CommandName == "Reset")
        {
            txtSoLineWefDate.Text = string.Empty;
            checkBoxBillable.Checked = false;
            checkBoxActive.Checked = false;
            txtOtherAllowances.Text = string.Empty;
        }
        else if (e.CommandName == "FilterAsmtId")
        {
            var txtFilterAsmtId = (TextBox)gvSaleOrderDetails.HeaderRow.FindControl("txtFilterAsmtId");
            if (txtFilterAsmtId != null)
            {
                hiddenFieldAsmtIdFilter.Value = txtFilterAsmtId.Text;
                FillgvSaleOrderDetails(txtFilterAsmtId.Text);
            }
        }
    }

    /// <summary>
    /// gv Sale Order Details Row Canceling Edit
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Cancel Edit Event Args</param>
    protected void GvSaleOrderDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSaleOrderDetails.EditIndex = -1;
        FillgvSaleOrderDetails();
    }

    /// <summary>
    /// gv Sale Order Details Row Editing
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Edit Event Args</param>
    protected void GvSaleOrderDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSaleOrderDetails.EditIndex = e.NewEditIndex;
        FillgvSaleOrderDetails();
        var hiddenFieldHours = (HiddenField)gvSaleOrderDetails.Rows[e.NewEditIndex].FindControl("hiddenFieldHours");
        var ddlHours = (DropDownList)gvSaleOrderDetails.Rows[e.NewEditIndex].FindControl("ddlHours");
        ddlHours.SelectedValue = hiddenFieldHours.Value.Trim();
    }

    /// <summary>
    /// gv Sale Order Details Page Index Changing
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Page Event Args</param>
    protected void GvSaleOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var gvrPager = gvSaleOrderDetails.BottomPagerRow;
        var ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        var currentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (_index == 1)
        {
            if (currentIndex > 0)
            {
                gvSaleOrderDetails.PageIndex = currentIndex - 1;
            }
            else
            {
                gvSaleOrderDetails.PageIndex = currentIndex;
            }
            _index = -1;
        }
        else if (_index == 0)
        {
            gvSaleOrderDetails.PageIndex = currentIndex + 1;
            _index = -1;
        }
        else
        {
            gvSaleOrderDetails.PageIndex = e.NewPageIndex;
        }
        gvSaleOrderDetails.EditIndex = -1;
        FillgvSaleOrderDetails();
    }
    /// <summary>
    /// grid view data bound event
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">event objects</param>
    protected void GvSaleOrderDetails_DataBound(object sender, EventArgs e)
    {
        var row = gvSaleOrderDetails.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        var lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (var i = 0; i < gvSaleOrderDetails.PageCount; i++)
            {
                var intPageNumber = i + 1;
                var lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvSaleOrderDetails.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvSaleOrderDetails.PageCount.ToString();
        }
    }

    /// <summary>
    /// Page change event
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">object event</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvSaleOrderDetails.BottomPagerRow;
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvSaleOrderDetails.PageIndex = ddlPages.SelectedIndex;
        FillgvSaleOrderDetails();
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
            gvSaleOrderDetails.PageSize = int.Parse(hfTotalRowCount.Value);
            FillgvSaleOrderDetails();
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
            gvSaleOrderDetails.PageSize = int.Parse(hfDefaultPageSize.Value);
            FillgvSaleOrderDetails();
        }
    }

    /// <summary>
    /// gv Sale Order Details Row Updating
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Grid View Update Event Args</param>
    protected void GvSaleOrderDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var lblgvSoLineNo = (Label)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("lblgvSoLineNo");
        var ddlContractNumber = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlContractNumber");
        var ddlgvAsmtId = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlgvAsmtId");
        var ddlgvPostCode = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlgvPostCode");
        var ddlgvSoRank = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlgvSoRank");
        var txtBillingDesignation = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtBillingDesignation");
        var txtNoOfPost = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtNoOfPost");
        var ddlHours = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlHours");
        var ddlDeploymentPattern = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlDeploymentPattern");
        var txtDaysInMonth = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtDaysInMonth");
        var txtHoursInMonth = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtHoursInMonth");
        var txtSoLineStartDate = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtSoLineStartDate");
        var txtSoLineEndDate = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtSoLineEndDate");
        var txtSoLineWefDate = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtSoLineWefDate");
        var ddlTypeOfService = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlTypeOfService");
        var txtTypeOfItem = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtTypeOfItem");
        var checkBoxBillable = (CheckBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("checkBoxBillable");
        var checkBoxActive = (CheckBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("checkBoxActive");
        var txtMinWages = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtMinWages");
        var txtOtherAllowances = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtOtherAllowances");
        var txtChargeRatePerHrs = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtChargeRatePerHrs");
        var txtMonthlyBilling = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtMonthlyBilling");
        var txtMinProfitability = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtMinProfitability");
        var txtOptimumProfitability = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtOptimumProfitability");
        var txtServiceCategoryCode = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtServiceCategoryCode");
        var txtPostPosition = (TextBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("txtPostPosition");
        var ddlAllowancesMode = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlAllowancesMode");
        var checkBoxIsAllowanceBillable = (CheckBox)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("checkBoxIsAllowanceBillable");
        var hiddenfieldSoLineStartDate = (HiddenField)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("hiddenfieldSoLineStartDate");
        var hiddenfieldSoLineEndDate = (HiddenField)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("hiddenfieldSoLineEndDate");
        var ddlPayRateType = (DropDownList)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("ddlPayRateType");
        var strLocationAutoId = BaseLocationAutoID;
        var strSoNo = txtSoNo.Text;
        var strSoAmendNo = ddlSOAmendNO.SelectedItem.Value;
        var struserId = BaseUserID;
        var strServiceCategoryCode = string.Empty;
        var strPostPosition = string.Empty;

        if (txtServiceCategoryCode != null && txtPostPosition != null)
        {
            strServiceCategoryCode = txtServiceCategoryCode.Text;
            strPostPosition = txtPostPosition.Text;
        }

        if (lblgvSoLineNo != null && ddlContractNumber != null && ddlgvAsmtId != null && ddlgvPostCode != null && ddlgvSoRank != null && txtBillingDesignation != null && txtNoOfPost != null && ddlHours != null && ddlDeploymentPattern != null && txtDaysInMonth != null && txtHoursInMonth != null && txtSoLineStartDate != null && txtSoLineEndDate != null && txtSoLineWefDate != null && ddlTypeOfService != null && txtTypeOfItem != null && checkBoxBillable != null && checkBoxActive != null && txtMinWages != null && txtOtherAllowances != null && txtChargeRatePerHrs != null)
        {
            var strSoLineNo = lblgvSoLineNo.Text;
            var strContractNumber = ddlContractNumber.SelectedValue;
            var strAsmtId = ddlgvAsmtId.SelectedValue;
            var strPostAutoId = ddlgvPostCode.SelectedValue;
            var strSoRank = ddlgvSoRank.SelectedValue;
            var strBillingDesignation = txtBillingDesignation.Text;
            var strNoOfPost = txtNoOfPost.Text;
            var strHours = ddlHours.SelectedValue;
            var strDeploymentPattern = ddlDeploymentPattern.SelectedValue;
            var strMinManPower = @"1";
            var strMaxManPower = @"1";
            var strDaysInMonth = txtDaysInMonth.Text.Length > 0 ? txtDaysInMonth.Text : "0";
            var strHoursInMonth = txtHoursInMonth.Text.Length > 0 ? txtHoursInMonth.Text : "0";
            var strSoLineStartDate = txtSoLineStartDate.Text;
            var strSoLineEndDate = txtSoLineEndDate.Text;
            var strSoLineWefDate = txtSoLineWefDate.Text;
            var strTypeOfService = ddlTypeOfService.SelectedValue;
            var strTypeOfItem = txtTypeOfItem.Text;
            bool boolBillable = checkBoxBillable.Checked;
            bool boolActive = checkBoxActive.Checked;
            var strMinWages = txtMinWages.Text;
            var strOtherAllowances = txtOtherAllowances.Text;
            var strChargeRatePerHrs = txtChargeRatePerHrs.Text;
            var objSales = new BL.Sales();
            if (hiddenFieldSoStatus.Value != strStatusFresh)
            {
                DataSet dataSetNoOfPost = objSales.SaleOrderDetailMaximumAuthorizedNoOfPostGet(txtSoNo.Text, int.Parse(lblgvSoLineNo.Text), int.Parse(BaseLocationAutoID));

                if (DateTime.Parse(txtSoLineWefDate.Text) < DateTime.Parse(dataSetNoOfPost.Tables[0].Rows[0]["SOLineWefDate"].ToString()))
                {
                    lblErrorMsg.Text = Resources.Resource.SoLineWEFDatecannotbedecreasedPleaseuseSalesOPSTermination;
                    return;
                }
            }

            if (strMinWages == string.Empty)
            {
                strMinWages = @"0";
            }

            if (txtMinProfitability.Text == string.Empty)
            {
                txtMinProfitability.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }

            if (txtOptimumProfitability.Text == string.Empty)
            {
                txtOptimumProfitability.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }

            if (txtMonthlyBilling.Text == string.Empty)
            {
                txtMonthlyBilling.Text = GetValueAsPerSystemParameters("0.00000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }

            if (ddlgvAsmtId.SelectedItem.Value != string.Empty && ddlgvPostCode.SelectedItem.Value != string.Empty && ddlgvSoRank.SelectedItem.Value != string.Empty && ddlContractNumber.SelectedItem.Value != string.Empty)
            {
                var strContractEndDateStatus = e.RowIndex.ToString();
                if (ValidateSoDetailsDates(txtWefdt.Text, txtSoLineStartDate.Text, txtSoLineEndDate.Text, txtSoLineWefDate.Text, hiddenfieldSoLineStartDate.Value, hiddenfieldSoLineEndDate.Value, strContractEndDateStatus))
                {
                    if (decimal.Parse(strHours) >= decimal.Parse(strDeploymentPattern) &&
                        decimal.Parse(strHours) % decimal.Parse(strDeploymentPattern) == 0)
                    {
                        DataSet ds = objSales.SaleOrderDetailUpdate(strLocationAutoId, strSoNo, strSoAmendNo, strSoLineNo, strContractNumber, strAsmtId, strPostAutoId,
                                                                    strSoRank, strBillingDesignation, strNoOfPost, strHours, strDeploymentPattern, strMinManPower,
                                                                    strMaxManPower, strDaysInMonth, strHoursInMonth, strSoLineStartDate, strSoLineEndDate, strSoLineWefDate,
                                                                    strTypeOfService, strTypeOfItem, boolBillable, boolActive, strMinWages, strOtherAllowances,
                                                                    ddlAllowancesMode.SelectedValue, bool.Parse(checkBoxIsAllowanceBillable.Checked.ToString()),
                                                                    double.Parse(strChargeRatePerHrs), txtMonthlyBilling.Text, txtMinProfitability.Text,
                                                                    txtOptimumProfitability.Text, strServiceCategoryCode, strPostPosition, struserId, strStatusFresh, ddlPayRateType.SelectedValue
                                                                    );
                        gvSaleOrderDetails.EditIndex = -1;
                        FillgvSaleOrderDetails();
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.DeploymentPatternshouldbeexactmultipleofHours;
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
    protected void GvSaleOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objSales = new BL.Sales();
        var lblgvSoLineNo = (Label)gvSaleOrderDetails.Rows[e.RowIndex].FindControl("lblgvSoLineNo");

        DataSet ds = objSales.SaleOrderDetailsDelete(txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value, lblgvSoLineNo.Text);
        FillgvSaleOrderDetails();
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
    protected void GvSaleOrderDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        var objSales = new BL.Sales();
        var dv = new DataView(objSales.SaleOrderDetailGet(BaseLocationAutoID, txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value).Tables[0]);

        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESC", dv, gvSaleOrderDetails);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASC", dv, gvSaleOrderDetails);
        }
    }

    #endregion
    #endregion

    #region GridView gvSaleOrderItemDetails
    #region GridView  SaleOrderItemDetails Controles Events

    /// <summary>
    /// Fill gv Sale Order Item Details
    /// </summary>
    protected void FillgvSaleOrderItemDetails()
    {
        var objsales = new BL.Sales();
        DataSet ds = objsales.SaleOrderItemDetailsGet(BaseLocationAutoID, txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value);
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
                    gvSOItemDetails.DataSource = dt;
                    gvSOItemDetails.DataBind();
                    gvSOItemDetails.Rows[0].Visible = false;
                    lblSOItemTotalValue.Text = GetValueAsPerSystemParameters("0.000000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }
                else if (dt.Rows.Count > 0)
                {
                    gvSOItemDetails.DataSource = dt;
                    gvSOItemDetails.DataBind();

                    decimal saleOrderItemTotalValue = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (bool.Parse(dt.Rows[i]["Billable"].ToString()) && bool.Parse(dt.Rows[i]["Active"].ToString()))
                        {
                            saleOrderItemTotalValue = saleOrderItemTotalValue + (decimal.Parse(dt.Rows[i]["Qty"].ToString()) * decimal.Parse(dt.Rows[i]["Rate"].ToString()));
                        }
                    }

                    lblSOItemTotalValue.Text = GetValueAsPerSystemParameters(saleOrderItemTotalValue.ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }
            }
        }
    }

    /// <summary>
    /// Fill drop down list Item Type Code
    /// </summary>
    /// <param name="ddlItemTypeCode">drop down list Item Type Code</param>
    protected void FillddlItemTypeCode(DropDownList ddlItemTypeCode)
    {
        var objsales = new BL.Sales();
        DataSet ds = objsales.SaleItemTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlItemTypeCode.DataSource = ds.Tables[0];
            ddlItemTypeCode.DataTextField = "ItemDesc";
            ddlItemTypeCode.DataValueField = "ItemTypeCode";
            ddlItemTypeCode.DataBind();
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlItemTypeCode.Items.Add(li);
        }
    }

    /// <summary>
    /// Contract Number Selected Index Changed
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlContractNumber_SelectedIndexChangedIDFT(object sender, EventArgs e)
    {
        var ddlContractNumber = (DropDownList)sender;
        var txtItemStartDate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtItemStartDate");
        var txtItemEndDate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtItemEndDate");
        var txtItemWefDate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtItemWefDate");
        var txtQty = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtQty");
        var hiddenFieldItemStartDate = (HiddenField)gvSOItemDetails.FooterRow.FindControl("hiddenFieldItemStartDate");
        var hiddenFieldItemEndDate = (HiddenField)gvSOItemDetails.FooterRow.FindControl("hiddenFieldItemEndDate");

        FillContractDetails(ddlContractNumber, txtItemStartDate, txtItemEndDate, txtItemWefDate, hiddenFieldItemStartDate, hiddenFieldItemEndDate, "Footer");


        if (txtQty != null && Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(txtQty);
        }
    }

    /// <summary>
    /// Contract Number Selected Index Changed
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlContractNumber_SelectedIndexChangedIDET(object sender, EventArgs e)
    {
        var ddlContractNumber = (DropDownList)sender;
        var gridViewRow = (GridViewRow)ddlContractNumber.NamingContainer;

        var txtItemStartDate = (TextBox)gvSOItemDetails.Rows[gridViewRow.RowIndex].FindControl("txtItemStartDate");
        var txtItemEndDate = (TextBox)gvSOItemDetails.Rows[gridViewRow.RowIndex].FindControl("txtItemEndDate");
        var txtQty = (TextBox)gvSOItemDetails.Rows[gridViewRow.RowIndex].FindControl("txtQty");
        var txtItemWefDate = (TextBox)gvSOItemDetails.Rows[gridViewRow.RowIndex].FindControl("txtItemWefDate");
        var hiddenFieldItemStartDate = (HiddenField)gvSOItemDetails.Rows[gridViewRow.RowIndex].FindControl("hiddenFieldItemStartDate");
        var hiddenFieldItemEndDate = (HiddenField)gvSOItemDetails.Rows[gridViewRow.RowIndex].FindControl("hiddenFieldItemEndDate");

        FillContractDetails(ddlContractNumber, txtItemStartDate, txtItemEndDate, txtItemWefDate, hiddenFieldItemStartDate, hiddenFieldItemEndDate, string.Empty);

        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager1.SetFocus(txtQty);
        }
    }

    /// <summary>
    /// txt Qty Text Changed
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void TxtQty_TextChanged(object sender, EventArgs e)
    {
        var txtQty = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtQty");
        var txtRate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtRate");
        var ddlItemTypeCode = (DropDownList)gvSOItemDetails.FooterRow.FindControl("ddlItemTypeCode");
        var objSales = new BL.Sales();

        if (txtQty.Text != string.Empty)
        {
            var ds = objSales.SaleOrderItemRateGet(BaseCompanyCode, ddlItemTypeCode.SelectedValue, txtQty.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtRate.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
            }
            else
            {
                txtRate.Text = @"0.00";
            }

            if (Master != null)
            {
                var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                toolkitScriptManager1.SetFocus(txtRate);
            }
        }
    }

    /// <summary>
    /// txt Qty Text Changed Edit
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void TxtQty_TextChangedEdit(object sender, EventArgs e)
    {
        var objTextBox = (TextBox)sender;
        var row = (GridViewRow)objTextBox.NamingContainer;
        var txtQty = (TextBox)gvSOItemDetails.Rows[row.RowIndex].FindControl("txtQty");
        var txtRate = (TextBox)gvSOItemDetails.Rows[row.RowIndex].FindControl("txtRate");
        var hfgvItemTypeCode = (HiddenField)gvSOItemDetails.Rows[row.RowIndex].FindControl("hfgvItemTypeCode");
        var objSales = new BL.Sales();

        if (txtQty.Text != string.Empty)
        {
            var ds = objSales.SaleOrderItemRateGet(BaseCompanyCode, hfgvItemTypeCode.Value, txtQty.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtRate.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
            }
            else
            {
                txtRate.Text = @"0.00";
            }

            if (Master != null)
            {
                var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                toolkitScriptManager1.SetFocus(txtRate);
            }
        }
    }

    /// <summary>
    /// drop down list Item Type Code Selected Index Changed
    /// </summary>
    /// <param name="sender">object of thwe control</param>
    /// <param name="e">Event Args</param>
    protected void DdlItemTypeCode_SelectedIndexChangedIDET(object sender, EventArgs e)
    {
        var txtQty = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtQty");
        var txtRate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtRate");
        txtQty.Text = string.Empty;
        txtRate.Text = string.Empty;
    }

    /// <summary>
    /// Validate So Item Details Dates
    /// </summary>
    /// <param name="strSoWefDate">SO WEF Date</param>
    /// <param name="strSoItemLineStartDate">So Item Line Start Date</param>
    /// <param name="strItemSoLineEndDate">Item So Line End Date</param>
    /// <param name="strContractStartDate">Contract Start Date</param>
    /// <param name="strContractEndDate">Contract End Date</param>
    /// <returns>true or false</returns>
    protected bool ValidateSoItemDetailsDates(string strSoWefDate, string strSoItemLineStartDate, string strItemSoLineEndDate, string strContractStartDate, string strContractEndDate)
    {
        if (strSoWefDate == string.Empty || strSoItemLineStartDate == string.Empty || strItemSoLineEndDate == string.Empty)
        {
            DisplayMessageString(lblErrorMsg, "Date left blank");
            return false;
        }
        var dateTimeSoItemLineStartDate = DateTime.Parse(strSoItemLineStartDate);
        var dateTimeSoItemLineEndDate = DateTime.Parse(strItemSoLineEndDate);
        var dateTimeContractStartDate = DateTime.Parse(strContractStartDate);
        if (dateTimeSoItemLineStartDate < dateTimeSoItemLineEndDate && dateTimeSoItemLineStartDate >= dateTimeContractStartDate)
        {
            return true;
        }
        if (dateTimeSoItemLineStartDate > dateTimeSoItemLineEndDate)
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.SOLineStartdateShouldbeLessThenSOLineEndDate);
        }
        else if (dateTimeSoItemLineStartDate < dateTimeContractStartDate)
        {
            lblErrorMsg.Text = Resources.Resource.SOItemLineStartDateShouldbeGreaterthanorEqualtoContarctStartDate;
        }

        return false;
    }
    #endregion
    #region GridView  SaleOrderItemDetails Commands Events
    /// <summary>
    /// Sale Order Item Grid Rowcommand Event
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">GridViewCommandEvent Args</param>
    protected void GvSOItemDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objSales = new BL.Sales();
        var ddlItemTypeCode = (DropDownList)gvSOItemDetails.FooterRow.FindControl("ddlItemTypeCode");
        var ddlContractNumber = (DropDownList)gvSOItemDetails.FooterRow.FindControl("ddlContractNumber");
        var txtQty = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtQty");
        var txtRate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtRate");
        var checkBoxBillable = (CheckBox)gvSOItemDetails.FooterRow.FindControl("checkBoxBillable");
        var checkBoxActive = (CheckBox)gvSOItemDetails.FooterRow.FindControl("checkBoxActive");
        var txtItemStartDate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtItemStartDate");
        var txtItemEndDate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtItemEndDate");
        var hiddenFieldItemStartDate = (HiddenField)gvSOItemDetails.FooterRow.FindControl("hiddenFieldItemStartDate");
        var hiddenFieldItemEndDate = (HiddenField)gvSOItemDetails.FooterRow.FindControl("hiddenFieldItemEndDate");
        var txtItemWefDate = (TextBox)gvSOItemDetails.FooterRow.FindControl("txtItemWefDate");
        if (e.CommandName == "Add")
        {
            string strContractEndDateStatus = "-1";

            if (ValidateSoItemDetailsDates(txtWefdt.Text, txtItemStartDate.Text, txtItemEndDate.Text, txtItemWefDate.Text, hiddenFieldItemStartDate.Value, hiddenFieldItemEndDate.Value, strContractEndDateStatus))
            {
                if (ddlItemTypeCode.SelectedItem.Value != string.Empty)
                {
                    var ds = objSales.SaleOrderItemDetailAddNew(txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value, ddlItemTypeCode.SelectedItem.Value, ddlContractNumber.SelectedItem.Value, txtQty.Text, txtRate.Text, bool.Parse(checkBoxBillable.Checked.ToString()), bool.Parse(checkBoxActive.Checked.ToString()), txtItemStartDate.Text, txtItemEndDate.Text, txtItemWefDate.Text, BaseUserID);
                    gvSOItemDetails.EditIndex = -1;
                    FillgvSaleOrderItemDetails();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.ItemType + @" " + Resources.Resource.Mandatory);
                }
            }
        }
        else if (e.CommandName == "Reset")
        {
            txtQty.Text = string.Empty;
            txtRate.Text = string.Empty;
            checkBoxBillable.Checked = false;
            checkBoxActive.Checked = false;
            txtItemStartDate.Text = string.Empty;
            txtItemEndDate.Text = string.Empty;
        }
    }

    /// <summary>
    /// Sale Order Item Grid RowDataBound Event
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">GridViewRowEvent Args</param>
    protected void GvSOItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var lblgvhdrRate = (Label)e.Row.FindControl("lblgvhdrRate");
            lblgvhdrRate.Text = Resources.Resource.Rate + @" ( " + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @" ) ";
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            var lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");

            if (lblSerialNo != null)
            {
                int serialNo = (gvSOItemDetails.PageIndex * gvSOItemDetails.PageSize) + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            var imgbtnDelete = (ImageButton)e.Row.FindControl("imgbtnDelete");
            if (IsDeleteAccess == false)
            {
                if (imgbtnDelete != null)
                {
                    imgbtnDelete.Visible = false;
                }
            }
            else
            {
                if (hiddenFieldSoStatus.Value != strStatusFresh && hiddenFieldSoStatus.Value != strStatusAmend && imgbtnDelete != null)
                {
                    imgbtnDelete.Visible = false;
                }
                else if (imgbtnDelete != null)
                {
                    imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }
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
                if (hiddenFieldSoStatus.Value != strStatusFresh && hiddenFieldSoStatus.Value != strStatusAmend)
                {
                    var imgbtnEdit = (ImageButton)e.Row.FindControl("imgbtnEdit");

                    if (imgbtnEdit != null)
                    {
                        imgbtnEdit.Visible = false;
                    }
                }
                else
                {
                    var imgbtnUpdate = (ImageButton)e.Row.FindControl("imgbtnUpdate");

                    if (imgbtnUpdate != null)
                    {
                        imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }

                    var txtQty = (TextBox)e.Row.FindControl("txtQty");

                    if (txtQty != null)
                    {
                        txtQty.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                        txtQty.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    }

                    var txtRate = (TextBox)e.Row.FindControl("txtRate");

                    if (txtRate != null)
                    {
                        txtRate.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                        txtRate.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    }

                    var ddlContractNumber = (DropDownList)e.Row.FindControl("ddlContractNumber");
                    var hiddenFieldContractNumber = (HiddenField)e.Row.FindControl("hiddenFieldContractNumber");

                    if (ddlContractNumber != null && hiddenFieldContractNumber != null)
                    {
                        FillddlContractNumber(ddlContractNumber);
                        ddlContractNumber.Enabled = false;
                        ddlContractNumber.SelectedIndex = ddlContractNumber.Items.IndexOf(ddlContractNumber.Items.FindByValue(hiddenFieldContractNumber.Value));
                    }

                    if (hiddenFieldSoStatus.Value != strStatusFresh)
                    {
                        if (ddlContractNumber != null)
                        {
                            ddlContractNumber.Enabled = false;
                        }
                    }

                    var txtItemStartDate = (TextBox)e.Row.FindControl("txtItemStartDate");
                    var txtItemEndDate = (TextBox)e.Row.FindControl("txtItemEndDate");
                    var txtItemWefDate = (TextBox)e.Row.FindControl("txtItemWefDate");
                    if (txtItemStartDate != null)
                    {
                        txtItemStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtItemEndDate != null)
                    {
                        txtItemEndDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtItemWefDate != null)
                    {
                        txtItemWefDate.Attributes.Add("readonly", "readonly");
                    }
                    var hiddenFieldItemStartDate = (HiddenField)e.Row.FindControl("hiddenFieldItemStartDate");
                    var hiddenFieldItemEndDate = (HiddenField)e.Row.FindControl("hiddenFieldItemEndDate");
                    if (ddlContractNumber != null && hiddenFieldItemStartDate != null && hiddenFieldItemEndDate != null)
                    {
                        FillContractDetails(ddlContractNumber, txtItemStartDate, txtItemEndDate, txtItemWefDate, hiddenFieldItemStartDate, hiddenFieldItemEndDate, "Row");
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
                if (hiddenFieldSoStatus.Value != strStatusFresh && hiddenFieldSoStatus.Value != strStatusAmend)
                {
                    gvSOItemDetails.ShowFooter = false;
                }
                else
                {
                    gvSOItemDetails.ShowFooter = true;
                    var imgbtnAdd = (ImageButton)e.Row.FindControl("imgbtnAdd");
                    var ddlItemTypeCode = (DropDownList)e.Row.FindControl("ddlItemTypeCode");
                    FillddlItemTypeCode(ddlItemTypeCode);
                    imgbtnAdd.Enabled = ddlItemTypeCode.SelectedValue != string.Empty;
                    imgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    var txtQty = (TextBox)e.Row.FindControl("txtQty");
                    if (txtQty != null)
                    {
                        txtQty.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                        txtQty.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    }
                    var txtRate = (TextBox)e.Row.FindControl("txtRate");
                    if (txtRate != null)
                    {
                        txtRate.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                        txtRate.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    }
                    var txtItemStartDate = (TextBox)e.Row.FindControl("txtItemStartDate");
                    var txtItemEndDate = (TextBox)e.Row.FindControl("txtItemEndDate");
                    var txtItemWefDate = (TextBox)e.Row.FindControl("txtItemWefDate");
                    if (txtItemStartDate != null)
                    {
                        txtItemStartDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtItemEndDate != null)
                    {
                        txtItemEndDate.Attributes.Add("readonly", "readonly");
                    }
                    if (txtItemWefDate != null)
                    {
                        txtItemWefDate.Attributes.Add("readonly", "readonly");
                    }
                    var ddlContractNumber = (DropDownList)e.Row.FindControl("ddlContractNumber");
                    if (ddlContractNumber != null)
                    {
                        FillddlContractNumber(ddlContractNumber);
                        imgbtnAdd.Enabled = ddlContractNumber.SelectedValue != string.Empty;
                    }
                    var hiddenFieldItemStartDate = (HiddenField)e.Row.FindControl("hiddenFieldItemStartDate");
                    var hiddenFieldItemEndDate = (HiddenField)e.Row.FindControl("hiddenFieldItemEndDate");
                    if (ddlContractNumber != null && hiddenFieldItemStartDate != null && hiddenFieldItemEndDate != null && txtItemStartDate != null && txtItemEndDate != null && txtItemWefDate != null)
                    {
                        FillContractDetails(ddlContractNumber, txtItemStartDate, txtItemEndDate, txtItemWefDate, hiddenFieldItemStartDate, hiddenFieldItemEndDate, "Footer");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Sale Order Item Grid Delete Event
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">GridViewDeleteEvent Args</param>
    protected void GvSOItemDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objSales = new BL.Sales();
        var hiddenFieldContractNumber = (HiddenField)gvSOItemDetails.Rows[e.RowIndex].FindControl("hiddenFieldContractNumber");
        var hfgvItemTypeCode = (HiddenField)gvSOItemDetails.Rows[e.RowIndex].FindControl("hfgvItemTypeCode");
        var itemStartDate = (Label)gvSOItemDetails.Rows[e.RowIndex].FindControl("lblgvItemStartDate");
        var ds = objSales.SaleOrderItemDetailsDelete(txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value, hfgvItemTypeCode.Value, hiddenFieldContractNumber.Value, itemStartDate.Text);

        FillgvSaleOrderItemDetails();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }

    /// <summary>
    /// Sale Order Item Grid Update Event
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">GridViewUpdateEvent Args</param>
    protected void GvSOItemDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objSales = new BL.Sales();

        var hfgvItemTypeCode = (HiddenField)gvSOItemDetails.Rows[e.RowIndex].FindControl("hfgvItemTypeCode");
        var ddlContractNumber = (DropDownList)gvSOItemDetails.Rows[e.RowIndex].FindControl("ddlContractNumber");
        var txtQty = (TextBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("txtQty");
        var txtRate = (TextBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("txtRate");
        var checkBoxBillable = (CheckBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("checkBoxBillable");
        var checkBoxActive = (CheckBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("checkBoxActive");
        var txtItemStartDate = (TextBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("txtItemStartDate");
        var txtItemEndDate = (TextBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("txtItemEndDate");
        var hiddenFieldItemStartDate = (HiddenField)gvSOItemDetails.Rows[e.RowIndex].FindControl("hiddenFieldItemStartDate");
        var hiddenFieldItemEndDate = (HiddenField)gvSOItemDetails.Rows[e.RowIndex].FindControl("hiddenFieldItemEndDate");
        var txtItemWefDate = (TextBox)gvSOItemDetails.Rows[e.RowIndex].FindControl("txtItemWefDate");
        var strSoNo = txtSoNo.Text;
        var strSoAmendNo = ddlSOAmendNO.SelectedItem.Value;
        var struserId = BaseUserID;

        if (hfgvItemTypeCode != null && ddlContractNumber != null && txtQty != null && txtRate != null && checkBoxBillable != null && checkBoxActive != null && txtItemStartDate != null && txtItemEndDate != null && txtItemWefDate != null)
        {
            var strItemTypeCode = hfgvItemTypeCode.Value;
            var strContractNumber = ddlContractNumber.SelectedItem.Value;
            bool boolBillabele = bool.Parse(checkBoxBillable.Checked.ToString());
            bool boolActive = bool.Parse(checkBoxActive.Checked.ToString());
            var strItemStartDate = txtItemStartDate.Text;
            var strItemEndDate = txtItemEndDate.Text;
            var strItemWefDate = txtItemWefDate.Text;
            var strContractEndDateStatus = e.RowIndex.ToString();
            if (ValidateSoItemDetailsDates(txtWefdt.Text, strItemStartDate, strItemEndDate, strItemWefDate, hiddenFieldItemStartDate.Value, hiddenFieldItemEndDate.Value, strContractEndDateStatus))
            {
                var ds = objSales.SaleOrderItemDetailUpdate(strSoNo, strSoAmendNo, strItemTypeCode, strContractNumber, txtQty.Text, txtRate.Text, boolBillabele, boolActive, strItemStartDate, strItemEndDate, strItemWefDate, struserId);
                gvSOItemDetails.EditIndex = -1;
                FillgvSaleOrderItemDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
        }
    }

    /// <summary>
    /// SO Item Grid Editing Event
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">GridViewEditEvent Args</param>
    protected void GvSOItemDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSOItemDetails.EditIndex = e.NewEditIndex;
        FillgvSaleOrderItemDetails();
    }

    /// <summary>
    /// SO Item Grid Cancel Editing Event
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">GridViewCancelEditEvent Args</param>
    protected void GvSOItemDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSOItemDetails.EditIndex = -1;
        FillgvSaleOrderItemDetails();
    }

    /// <summary>
    /// SO Item Grid Pag e Index Changing Event
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">GridViewPageEvent Args</param>
    protected void GvSOItemDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSOItemDetails.PageIndex = e.NewPageIndex;
        FillgvSaleOrderItemDetails();
    }
    #endregion
    #endregion

    #region Controles Events

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
    /// On change of So No to get the new sono records
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void TxtSoNo_TextChanged(object sender, EventArgs e)
    {
        if (txtSoNo.Text != string.Empty)
        {
            GetSelectedSaleOrder();
        }
    }

    /// <summary>
    /// on change of Amendment No
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void DdlSOAmendNO_SelectedIndexChanged(object sender, EventArgs e)
    {
        hfIsMAXSOAmendNo.Value = ddlSOAmendNO.SelectedIndex == 0 ? "MAX" : "NOTMAX";
        GetSelectedSaleOrder();
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

    /// <summary>
    /// on change of Centerlize Billing checked or unchecked
    /// </summary>
    /// <param name="sender">object of the control</param>
    /// <param name="e">Event Args</param>
    protected void CbCenterlizeBilling_CheckedChanged(object sender, EventArgs e)
    {
        if (int.Parse(hfIsMultipleLocation.Value) > 1)
        {
            cbCenterlizeBilling.Enabled = false;
            ImgBtnSearchLocation.Enabled = false;

        }
        else
        {
            cbCenterlizeBilling.Enabled = true;

            ImgBtnSearchLocation.Enabled = true;
        }
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

        if (txtSoNo.Text == string.Empty || ddlSOAmendNO.SelectedItem.Value == string.Empty ||
            hiddenFieldSoStatus.Value == string.Empty || ddlSoType.SelectedItem.Value == string.Empty ||
            txtClientCode.Text == string.Empty || txtWefdt.Text == string.Empty
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
        if (hiddenFieldSoStatus.Value == strStatusFresh)
        {
            ddlSoType.Enabled = hfFixedBillingCheck.Value != "1";

            txtClientCode.Enabled = true;
            ImgBtnSearchClient.Enabled = true;
            cbCenterlizeBilling.Enabled = true;
            txtBillingLocation.Enabled = true;
            ddlAsmtBillingId.Enabled = true;
            txtTerminationDate.Enabled = true;
            HlimgTerminationDate.Enabled = true;
            txtTerminationReason.Enabled = true;
            txtTerminatedBy.Enabled = true;
            hlWefdt.Enabled = true;
            ddlInvoiceType.Enabled = true;
            ddlGrade.Enabled = true;
            txtRemarks.Enabled = true;
            btnEdit.Visible = false;
            btnAuthorize.Visible = false;
            btnUpdate.Visible = true;
            btnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
            btnCancel.Visible = true;
        }
        else if (hiddenFieldSoStatus.Value == strStatusAmend && hfIsMAXSOAmendNo.Value == "MAX")
        {
            if (int.Parse(hfIsMultipleLocation.Value) > 1)
            {
                cbCenterlizeBilling.Enabled = false;
                ImgBtnSearchLocation.Enabled = false;
            }
            else
            {
                cbCenterlizeBilling.Enabled = true;
                ImgBtnSearchLocation.Enabled = true;
            }
            ddlInvoiceType.Enabled = hfFixedBillingCheck.Value != "1";
            ddlGrade.Enabled = true;
            txtBillingLocation.Enabled = true;
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
        var objsales = new BL.Sales();
        gvSaleOrderDetails.EditIndex = -1;
        string strMyStatus;
        if (hiddenFieldSoStatus.Value == strStatusFresh)
        {
            strMyStatus = strStatusFresh;
        }
        else if (hiddenFieldSoStatus.Value == strStatusAmend)
        {
            strMyStatus = strStatusAmend;
        }
        else
        {
            strMyStatus = string.Empty;
        }

        if (hiddenFieldSoStatus.Value == strStatusFresh || hiddenFieldSoStatus.Value == strStatusAmend)
        {
            if (SoMasterUpdateValidate())
            {
                var ds = objsales.SaleOrderMasterUpdate(BaseLocationAutoID, txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value, txtWefdt.Text, txtClientCode.Text, hiddenFieldSoStatus.Value, txtTerminationDate.Text, txtTerminationReason.Text, txtTerminatedBy.Text, ddlSoType.SelectedItem.Value, cbCenterlizeBilling.Checked, hfBillingLocationAutoID.Value, ddlAsmtBillingId.SelectedItem.Value, BaseUserID, strMyStatus, ddlInvoiceType.SelectedItem.Value.ToUpper().Trim(), txtRemarks.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtSoNo.Text = ds.Tables[1].Rows[0]["SONO"].ToString();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())))
                    {
                        if (txtSoNo.Text != string.Empty)
                        {
                            btnSave.Visible = false;
                            btnCancel.Visible = false;
                            FillddlSoType();
                            FillddlSoAmendNo(txtSoNo.Text);
                            ViewMode();
                            //GetSelectedSaleOrder();

                            if (ddlInvoiceType.SelectedValue.Trim().ToLower() != "Fixed".Trim().ToLower())
                            {
                                UpdateBillingAmountOfAllSoLines();
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// To upate the Billing Amount of So Line
    /// </summary>
    protected void UpdateBillingAmountOfAllSoLines()
    {
        var objSales = new BL.Sales();
        var ds = objSales.SaleOrderDeploymentPatternGet(BaseLocationAutoID, txtSoNo.Text, ddlSOAmendNO.SelectedItem.Text);

        CalculateAverageDaysInMonth(ds);
    }

    /// <summary>
    /// To calculate the Average Days in Month of So Line Service
    /// </summary>
    /// <param name="ds">Data Set</param>
    protected void CalculateAverageDaysInMonth(DataSet ds)
    {
        var dv = new DataView(ds.Tables[0]);
        var objSales = new BL.Sales();
        for (var k = 0; k < ds.Tables[1].Rows.Count; k++)
        {
            var averageDaysInMonth = decimal.Parse("0");
            dv.RowFilter = "[SONO]='" + ds.Tables[1].Rows[k]["SONO"] + "' AND" + "[SOLineNO]=" + int.Parse(ds.Tables[1].Rows[k]["SOLineNO"].ToString()).ToString();

            var dt = dv.ToTable();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var decNoofDaysinWeek = decimal.Parse("0");
                if (bool.Parse(dt.Rows[i]["SUN"].ToString()))
                {
                    decNoofDaysinWeek = decNoofDaysinWeek + 1;
                }
                if (bool.Parse(dt.Rows[i]["MON"].ToString()))
                {
                    decNoofDaysinWeek = decNoofDaysinWeek + 1;
                }
                if (bool.Parse(dt.Rows[i]["TUE"].ToString()))
                {
                    decNoofDaysinWeek = decNoofDaysinWeek + 1;
                }

                if (bool.Parse(dt.Rows[i]["WED"].ToString()))
                {
                    decNoofDaysinWeek = decNoofDaysinWeek + 1;
                }

                if (bool.Parse(dt.Rows[i]["THU"].ToString()))
                {
                    decNoofDaysinWeek = decNoofDaysinWeek + 1;
                }

                if (bool.Parse(dt.Rows[i]["FRI"].ToString()))
                {
                    decNoofDaysinWeek = decNoofDaysinWeek + 1;
                }

                if (bool.Parse(dt.Rows[i]["SAT"].ToString()))
                {
                    decNoofDaysinWeek = decNoofDaysinWeek + 1;
                }
                decimal averageDaysInWeek;
                if (int.Parse(dt.Rows[i]["WeekNo"].ToString()) < 5)
                {
                    averageDaysInWeek = decNoofDaysinWeek;
                }
                else
                {
                    averageDaysInWeek = (decimal.Parse(hfRemainingDays.Value) / 7) * decNoofDaysinWeek;
                }
                var excludedDays = averageDaysInWeek;
                averageDaysInMonth = averageDaysInMonth + excludedDays;
            }

            var hours = decimal.Parse(dt.Rows[0]["hours"].ToString());
            var chargeRatePerHrs = decimal.Parse(dt.Rows[0]["ChargeRatePerHour"].ToString());
            var noOfPost = decimal.Parse(dt.Rows[0]["noOfPost"].ToString());

            var monthlyBilling = decimal.Parse(GetValueAsPerSystemParameters(Convert.ToString(hours * chargeRatePerHrs * noOfPost * averageDaysInMonth), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck)));
            var sellingPrice = monthlyBilling / noOfPost;
            objSales.SellingPriceUpdate(txtSoNo.Text, ddlSOAmendNO.SelectedItem.Text, dt.Rows[0]["SOLineNO"].ToString(), BaseLocationAutoID, sellingPrice.ToString(), averageDaysInMonth.ToString(), BaseUserID);
        }

        FillgvSaleOrderDetails();
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

        if (hiddenFieldSoStatus.Value == strStatusAmend || hiddenFieldSoStatus.Value == strStatusShortClosed)
        {
            lblErrorMsg.Text = Resources.Resource.DeletionIsNotPossible + @" : " + txtSoNo.Text;
        }
        else if (hiddenFieldSoStatus.Value == strStatusFresh)
        {
            var ds = objSales.SaleOrderDelete(BaseLocationAutoID, txtSoNo.Text, hiddenFieldSoStatus.Value, strStatusFresh, strStatusDelete, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if ((ds.Tables[0].Rows[0]["MessageID"].ToString() == "1") || (ds.Tables[0].Rows[0]["MessageID"].ToString() == "2"))
                {
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    FillddlSoType();
                    FillddlSoAmendNo(txtSoNo.Text);
                    ViewMode();
                    upSOStatus.Update();
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
        if (ddlSoType.SelectedValue != "-1")
        {
            SaleOrderHeaderSave();
        }
        else
        {
            Show("Please first select So Type.");
            return;
        }
    }

    /// <summary>
    /// To save Sale Order header Info
    /// </summary>
    protected void SaleOrderHeaderSave()
    {
        var objsales = new BL.Sales();
        if (hiddenFieldSoStatus.Value == strStatusFresh)
        {
            if (ddlAsmtBillingId.Items.Count > 0)
            {
                if (hiddenFieldSoStatus.Value != string.Empty && ddlSoType.SelectedItem.Value != string.Empty && txtClientCode.Text != string.Empty && txtWefdt.Text != string.Empty)
                {
                    if (ValidateSaveSaleOrder())
                    {
                        var ds = objsales.SaleOrderMasterSave(BaseLocationAutoID, txtWefdt.Text, txtClientCode.Text, hiddenFieldSoStatus.Value, txtTerminationDate.Text, txtTerminationReason.Text, txtTerminatedBy.Text, ddlSoType.SelectedItem.Value, cbCenterlizeBilling.Checked, hfBillingLocationAutoID.Value, ddlAsmtBillingId.SelectedItem.Value, BaseUserID, ddlInvoiceType.SelectedItem.Value.ToUpper().Trim(), txtRemarks.Text, ddlGrade.SelectedItem.Value);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            txtSoNo.Text = ds.Tables[1].Rows[0]["SONO"].ToString();
                            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                            {
                                DisplayMessageString(lblErrorMsg, "Sale Order is ready to Add SO Line/Service Line and Items ");
                            }
                            else
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }

                            if (txtSoNo.Text != string.Empty)
                            {
                                btnSave.Visible = false;
                                btnCancel.Visible = false;
                                FillddlSoType();
                                FillddlSoAmendNo(txtSoNo.Text);
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
        if (txtSoNo.Text == string.Empty)
        {
            AddNewMode();
        }
        else
        {
            FillddlSoType();
            FillddlSoAmendNo(txtSoNo.Text);
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
            Response.Redirect("../Sales/SaleOrderList.aspx?ClientCode=" + txtClientCode.Text);
        }
        else
        {
            Response.Redirect("../Sales/SaleOrderList.aspx");
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
        var objsales = new BL.Sales();
        gvSaleOrderDetails.EditIndex = -1;
        string strMyStatus;
        if (hiddenFieldSoStatus.Value == strStatusFresh)
        {
            strMyStatus = strStatusFresh;
        }
        else if (hiddenFieldSoStatus.Value == strStatusAmend)
        {
            strMyStatus = strStatusAmend;
        }
        else
        {
            strMyStatus = string.Empty;
        }

        if (hiddenFieldSoStatus.Value == strStatusFresh || hiddenFieldSoStatus.Value == strStatusAmend)
        {
            var ds = objsales.SaleOrderMasterAuthorized(BaseLocationAutoID, txtSoNo.Text, ddlSOAmendNO.SelectedItem.Value, strStatusAuthorized, BaseUserID, strMyStatus);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                btnSave.Visible = false;
                btnCancel.Visible = false;
                FillddlSoType();
                FillddlSoAmendNo(txtSoNo.Text);
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
        var objsales = new BL.Sales();
        gvSaleOrderDetails.EditIndex = -1;

        if (hfIsMAXSOAmendNo.Value == "MAX" && hiddenFieldSoStatus.Value == strStatusAuthorized)
        {
            var strMyStatus = hiddenFieldSoStatus.Value == strStatusAuthorized ? strStatusAuthorized : string.Empty;
            var ds = objsales.SaleOrderMasterAmend(BaseLocationAutoID, txtSoNo.Text, strStatusAmend, BaseUserID, strMyStatus, DateFormat(txtWefdt.Text));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }

            FillddlSoType();
            FillddlSoAmendNo(txtSoNo.Text);
            ViewMode();
            //GetSelectedSaleOrder();
        }
    }

    /// <summary>
    /// To go to Assignment ID Creation Sceen
    /// </summary>
    /// <param name="sender">object of control</param>
    /// <param name="e">Event Args</param>
    protected void BtnAsmtCreationClick(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/AssignmentCreation.aspx?ClientCode=" + txtClientCode.Text);
    }

    /// <summary>
    /// Handles the Click event of the imgbtnPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void BtnLoadParentPageClick(object sender, EventArgs e)
    {
        FillgvSaleOrderDetails();
    }

    #endregion

    #region Page Modes

    /// <summary>
    /// To Open the Sale order in View only mode
    /// </summary>
    protected void ViewMode()
    {
        txtSoNo.Enabled = true;
        ddlSOAmendNO.Enabled = true;
        ddlSoType.Enabled = false;
        txtClientCode.Enabled = false;
        ImgBtnSearchClient.Enabled = false;
        cbCenterlizeBilling.Enabled = false;
        ImgBtnSearchLocation.Enabled = false;
        ddlAsmtBillingId.Enabled = false;
        ddlGrade.Enabled = false;
        txtTerminationDate.Enabled = false;
        HlimgTerminationDate.Enabled = false;
        txtTerminationReason.Enabled = false;
        txtTerminatedBy.Enabled = false;

        hlWefdt.Enabled = false;
        ddlInvoiceType.Enabled = false;
        txtRemarks.Enabled = false;
        btnDelete.Visible = false;
        btnDelete.Attributes["onclick"] = "javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');javascript:Timerf('" + lblErrorMsg.ClientID + "');";
        if (hiddenFieldSoStatus.Value == string.Empty)
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
        else if (hiddenFieldSoStatus.Value == strStatusFresh && hfIsMAXSOAmendNo.Value == "MAX")
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
        else if (hiddenFieldSoStatus.Value == strStatusAmend && hfIsMAXSOAmendNo.Value == "MAX")
        {
            btnEdit.Visible = IsModifyAccess;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAmend.Visible = false;
            btnAuthorize.Visible = IsAuthorizationAccess;
            btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
        }
        else if (hiddenFieldSoStatus.Value == strStatusAuthorized && hfIsMAXSOAmendNo.Value == "MAX")
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
        else if (hiddenFieldSoStatus.Value == strStatusShortClosed || hiddenFieldSoStatus.Value == strStatusDelete)
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
        txtSoNo.Enabled = false;
        ddlSOAmendNO.Enabled = false;
        ddlSoType.Enabled = true;
        txtClientCode.Enabled = true;
        ImgBtnSearchClient.Enabled = true;
        cbCenterlizeBilling.Enabled = BaseUserIsAreaIncharge != "1";
        ddlAsmtBillingId.Enabled = true;
        txtTerminationDate.Enabled = true;
        HlimgTerminationDate.Enabled = true;
        txtTerminationReason.Enabled = true;
        txtTerminatedBy.Enabled = true;
        ddlInvoiceType.Enabled = true;
        ddlGrade.Enabled = true;
        txtRemarks.Enabled = true;
        txtSoNo.Text = string.Empty;
        ddlSOAmendNO.DataSource = string.Empty;
        ddlSOAmendNO.DataBind();
        hfIsMAXSOAmendNo.Value = string.Empty;
        txtSOAmendDate.Text = string.Empty;
        txtWefdt.Text = string.Empty;
        lblSOStatus.Text = Resources.Resource.Fresh;
        hiddenFieldSoStatus.Value = strStatusFresh;
        FillddlSoType();
        txtClientCode.Text = string.Empty;
        txtClientName.Text = string.Empty;
        txtBillingLocation.Text = string.Empty;
        ddlAsmtBillingId.DataSource = string.Empty;
        ddlAsmtBillingId.DataBind();
        txtTerminationDate.Text = string.Empty;
        txtTerminationReason.Text = string.Empty;
        txtTerminatedBy.Text = string.Empty;
        if (hiddenFieldSoStatus.Value == strStatusFresh)
        {
            HlimgTerminationDate.Enabled = false;
        }
        gvSaleOrderDetails.DataSource = null;
        gvSaleOrderDetails.DataBind();
        gvSOItemDetails.DataSource = null;
        gvSOItemDetails.DataBind();
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
}
