// ***********************************************************************
// Assembly         : 
// Author           : Author Name
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
//   -----------   -----------                  --------    ------------------------------- 
//   V1.0          blContractMaster_Insert     13-Sep-2011 Passed a new parameter to Capture Alert Value 
//   V1.1          blContractMaster_GetDetailsBasedOnAmendNo Passed a new parameter as LocationAutoID     
//   V1.2          blContractMaster_Update     14-Sep-2011 Passed a new Parameter to Update Alert Value
//   V1.3          blContractMaster_Delete     14-Sep-2011  Updated the Proc being Used to delete the Contract Alert Days 
//   V1.4          blAutoGenerate_ClientCode   21-Sep-2011  Checks for Parameter if the AutoGenerate Contract Number is to System / Manually Created 
//   V1.5          blContractMaster_ManuallyInsert 21-Sep-2011  Inserts Manually created Contract Number
//                 Value from Parameter table as the Contract is Deleted
// ***********************************************************************
// <copyright file="ContractMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;

/// <summary>
/// Class Sales_ContractMaster.
/// </summary>
public partial class Sales_ContractMaster : BasePage
{

    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
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
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
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
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
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
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
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
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
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

    #region Page Load Function
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (IsReadAccess == true)
            {
                /************V1.4************/
                BL.Sales objSale = new BL.Sales();
                DataTable dtSale = new DataTable();
                dtSale = objSale.SetAutoGenerateCodeForClient(BaseCompanyCode, "AutoGenerateContractNumber".ToString());
                if (dtSale.Rows.Count > 0)
                {
                    if (dtSale.Rows[0]["ParamValue1"].ToString() == "0")
                    {
                        txtContractNumber.ReadOnly = false;
                        txtContractNumber.Focus();
                        RfvContractNumber.Enabled = true;
                        LabelStarContractNo.Visible = true;
                    }
                    else
                    {
                        txtContractNumber.ReadOnly = true;
                        RfvContractNumber.Enabled = false;
                        LabelStarContractNo.Visible = false;
                    }
                }
                /************V1.4************/
                //pop Calander changed with Ajax toolkit Calander
                lblDefaultCurrency.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
                txtWEF.Attributes.Add("readonly", "readonly");
                txtContractEndDate.Attributes.Add("readonly", "readonly");
                txtContractSignDate.Attributes.Add("readonly", "readonly");
                txtContractStartDate.Attributes.Add("readonly", "readonly");
                txtContractValue.Enabled = false;
                txtContractReviewDate.Attributes.Add("readonly", "readonly");
                //Umcomment By Manish 12:45 9/4/2013  
                txtLOIDate.Attributes.Add("readonly", "readonly");
                txtLOIEndDate.Attributes.Add("readonly", "readonly");
                txtLOIStartDate.Attributes.Add("readonly", "readonly");
                txtDeliveryDate.Attributes.Add("readonly", "readonly");
                txtExpectedSignDate.Attributes.Add("readonly", "readonly");
                //Umcomment By Manish 12:45 9/4/2013 above 3 lines

                txtIssuingAuthority.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtIssuingAuthority.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtDeliveryTo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtDeliveryTo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtClientSigningAuthority.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtClientSigningAuthority.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtDesignationAuthority.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtDesignationAuthority.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtManualContractNo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtManualContractNo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";

                txtNoticePeriodDaysToTerminate.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtNoticePeriodDaysToTerminate.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtTotalWarrantyAmount.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtTotalWarrantyAmount.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtRenewalInMonths.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtRenewalInMonths.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtClientNoticeToRenewalInDays.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtClientNoticeToRenewalInDays.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtInsurance.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtInsurance.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

                btnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgGrid.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                imgSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + txtClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                btnViewSO.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgGrid.ClientID.ToString() + "');";
                btnUpload.Attributes.Add("OnClick", "javascript:OpenContractUpload()");
                btnCreateSaleOrder.Attributes["onClick"] = "javascript:return confirm('" + Resources.Resource.MsgConfirmSoCreate + "');";
                txtContractAlert.Enabled = false;
                HideOtherInfo();
                FillddlAreaID();
                FillddlClient();
                if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length > 0)
                {
                    ddlClient.SelectedValue = Request.QueryString["ClientCode"].ToString();
                }
                txtClientCode.Text = ddlClient.SelectedItem.Value.ToString();
                ClientCode_ChangeEvent();
                if (Request.QueryString["ContractNumber"] != null && Request.QueryString["ClientCode"] != null && Request.QueryString["AmendNo"] != null)
                {
                    FillContractDetails(Request.QueryString["ContractNumber"].ToString(), Request.QueryString["AmendNo"].ToString());
                }
                FillgvViewSO();


            }
            else
            {

                Response.Redirect("../UserManagement/Home.aspx");
            }
        }




    }
    #endregion

    #region Function Related To ClientCode fill and TextChanged
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();
        ddlClient.Items.Clear();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString(), "".ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientCodeName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlClient.Items.Add(li);
            ClearFields();
            lblStatus.Text = "";

        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClientCode.Text = ddlClient.SelectedItem.Value.ToString();
        ClientCode_ChangeEvent();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtClientCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ddlClient.SelectedValue = txtClientCode.Text.Trim().ToUpper();
            ClientCode_ChangeEvent();
        }
        catch (Exception)
        {
            lblErrorMsgGrid1.Text = Resources.Resource.SelectProperClient;
            HideButtons();
        }
    }
    /// <summary>
    /// Clients the code_ change event.
    /// </summary>
    protected void ClientCode_ChangeEvent()
    {
        hfContractNumber.Value = "";
        FillgvLOIReceived();
        lblCustomerName.Visible = true;
        lblClientName.Visible = true;
        FillgvViewSO();

        txtSearchContract.Visible = true;

        HideButtonOnSearchClick();
        HideButtonBasedOnStatus();
        ChangeTextBoxBasedOnddlSearchBySelectedIndexChanged();
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.ClientNameGet(txtClientCode.Text, BaseLocationAutoID);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            lblCustomerName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
            if (IsWriteAccess == true)
            {
                btnAddNew.Visible = true;
            }
            else
            {
                btnAddNew.Visible = false;
            }
        }
        else
        {
            lblCustomerName.Text = "";
        }
        if (lblCustomerName.Text == "")
        {
            lblErrorMsgGrid.Text = Resources.Resource.NoRecordFound;
            txtAmendmentNo.Text = "";
            btnDelete.Visible = false;
            btnAmend.Visible = false;
            btnAddNew.Visible = false;
        }

        //btnViewCubicDetails.Visible = false;
    }
    #endregion

    #region Function Related to Search In Gridview LOI received
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlSearchBy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeTextBoxBasedOnddlSearchBySelectedIndexChanged();
        if (ddlSearchBy.SelectedValue.ToString() == "StartDate" || ddlSearchBy.SelectedValue.ToString() == "EndDate")
        {
            txtSearchDate.Visible = true;
            imgSearchGrid.Visible = true;
            txtSearchContract.Visible = false;
            txtSearchDate.Attributes.Add("readonly", "readonly");
            imgSearchGrid.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSearchDate.ClientID.ToString() + "');";
        }
        else
        {
            txtSearchContract.Visible = true;
            txtSearchDate.Visible = false;
            imgSearchGrid.Visible = false;
        }
        txtSearchContract.Text = "";
        txtSearchDate.Text = "";
    }
    /// <summary>
    /// Changes the text box based onddl search by selected index changed.
    /// </summary>
    private void ChangeTextBoxBasedOnddlSearchBySelectedIndexChanged()
    {
        if (ddlSearchBy.SelectedValue.ToString() == "StartDate" || ddlSearchBy.SelectedValue.ToString() == "EndDate")
        {
            txtSearchDate.Visible = true;
            imgSearchGrid.Visible = true;
            txtSearchContract.Visible = false;
            txtSearchDate.Attributes.Add("readonly", "readonly");
            imgSearchGrid.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSearchDate.ClientID.ToString() + "');";
        }
        else
        {
            txtSearchContract.Visible = true;
            txtSearchDate.Visible = false;
            imgSearchGrid.Visible = false;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (txtSearchContract.Text != "" || txtSearchDate.Text != "")
        {
            btnViewAll.Visible = true;
            HideOtherInfo();
            HideButtonOnSearchClick();
        }

        if (txtSearchDate.Text != "" || txtSearchContract.Text != "")
        {
            if (ddlSearchBy.SelectedValue.ToString() == "StartDate" || ddlSearchBy.SelectedValue.ToString() == "EndDate")
            {
                hfSearchText.Value = txtSearchDate.Text;
            }
            else
            {

                hfSearchText.Value = txtSearchContract.Text.Trim();
            }
            SearchAction();
        }
    }
    /// <summary>
    /// Function To Search In grid view LOI Received Based on ddlSearchBy and txtSearch Value
    /// </summary>
    private void SearchAction()
    {
        BL.Sales objSales = new BL.Sales();
        DataView dv = new DataView(objSales.ContractMasterGetAll(txtClientCode.Text, BaseLocationAutoID).Tables[0]);
        if (ddlSearchBy.SelectedValue.ToString() == "StartDate" || ddlSearchBy.SelectedValue.ToString() == "EndDate")
        {
            string value = DateFormat(hfSearchText.Value);
            dv.RowFilter = string.Format(CultureInfo.InvariantCulture.DateTimeFormat, "[{0}] = '{1}'", ddlSearchBy.SelectedValue.ToString(), value);
        }
        else
        {

            dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);
        }

        gvLOIReceived.DataSource = dv;
        gvLOIReceived.DataBind();
    }
    /// <summary>
    /// Handles the Click event of the btnViewAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        FillgvLOIReceived();
    }

    #endregion

    #region To GridView LOI received
    /// <summary>
    /// Fillgvs the loi received.
    /// </summary>
    private void FillgvLOIReceived()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet dsLOIReceived = new DataSet();
        DataTable dtLOIReceived = new DataTable();
        int dtflag;
        dtflag = 1;
        dsLOIReceived = objSales.ContractMasterGetAll(txtClientCode.Text, BaseLocationAutoID);//, ddlContractNumber.SelectedValue.ToString());
        dtLOIReceived = dsLOIReceived.Tables[0];
        if (dtLOIReceived.Rows.Count == 0)
        {
            dtflag = 0;
            dtLOIReceived.Rows.Add(dtLOIReceived.NewRow());
            HideOtherInfo();
            btnViewCubicDetails.Visible = false;
            HideButtons();
            lblStatus.Text = "";
            HideButtonBasedOnStatus();
            btnCreateSaleOrder.Visible = false;
            btnShortClose.Visible = false;
        }
        else
        {
            if (hfContractNumber.Value == "")
            {
                FillContractDetails(dtLOIReceived.Rows[0]["ContractNumber"].ToString(), dtLOIReceived.Rows[0]["AmendmentNo"].ToString());
            }
            else
            {
                string strAmendmentNo = "0";
                for (int i = 0; i < dtLOIReceived.Rows.Count; i++)
                {
                    if (hfContractNumber.Value == dtLOIReceived.Rows[i]["ContractNumber"].ToString())
                    {
                        strAmendmentNo = dtLOIReceived.Rows[i]["AmendmentNo"].ToString();
                    }
                }

                FillContractDetails(hfContractNumber.Value, strAmendmentNo);
            }
            btnViewCubicDetails.Visible = true;
            btnCreateSaleOrder.Visible = true;
        }
        gvLOIReceived.DataSource = dtLOIReceived;
        gvLOIReceived.DataBind();
        if (dtflag == 0)
        {
            gvLOIReceived.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvLOIReceived control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvLOIReceived_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
    }
    /// <summary>
    /// Handles the Sorting event of the gvLOIReceived control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewSortEventArgs" /> instance containing the event data.</param>
    protected void gvLOIReceived_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        BL.Sales objSales = new BL.Sales();
        DataView dv = new DataView(objSales.ContractMasterGetAll(txtClientCode.Text, BaseLocationAutoID).Tables[0]);
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESC", dv, gvLOIReceived);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASC", dv, gvLOIReceived);
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvLOIReceived control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvLOIReceived_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLOIReceived.PageIndex = e.NewPageIndex;
        FillgvLOIReceived();
    }
    /// <summary>
    /// Handles the Click event of the lbContractNumberGrid control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void lbContractNumberGrid_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbContractNumberGrid = (LinkButton)gvLOIReceived.Rows[row.RowIndex].FindControl("lbContractNumberGrid");
        Label lblAmendNoGrid = (Label)gvLOIReceived.Rows[row.RowIndex].FindControl("lblAmendNoGrid");
        FillContractDetails(lbContractNumberGrid.Text, lblAmendNoGrid.Text);

        FillgvViewSO();
        
        // row.BackColor = System.Drawing.Color.Red;
        if (lblStatus.Text != Resources.Resource.ShortClosed)
        {
            Label25.Visible = false;
            txtSCD.Visible = false;
            imgSCD.Visible = false;
        }
        else
        {
            Label25.Visible = true;
            txtSCD.Visible = true;
            imgSCD.Visible = true;
        }
        TabContract.ActiveTabIndex = 1;
    }
    /// <summary>
    /// Fills the contract details.
    /// </summary>
    /// <param name="strContractNumberGrid">The string contract number grid.</param>
    /// <param name="strAmendNoGrid">The string amend no grid.</param>
    protected void FillContractDetails(string strContractNumberGrid, string strAmendNoGrid)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        DisableFields();
        ds = objSales.ContractValueGet(strContractNumberGrid, strStatusAuthorized);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtContractValue.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["TotalValue"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            if (txtContractValue.Text == "")
            {
                txtContractValue.Text = GetValueAsPerSystemParameters("0.000000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }
        }
        else
        {
            txtContractValue.Text = GetValueAsPerSystemParameters("0.000000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
        }

        //txtContractValue.Text = GetValueAsPerSystemParameters("1234567", 3, 4); 
        hfContractNumber.Value = strContractNumberGrid;
        hfMaxAmendmentNumber.Value = strAmendNoGrid;
        FillDetails(int.Parse(strAmendNoGrid));
        FillddlAmendmentNumber(strContractNumberGrid);



        HideButtonBasedOnStatus();
        ShowOtherInfo();
        //DisableFields();
        if (lblStatus.Text != Resources.Resource.Authorized)
        {
            txtContractEndDate.Enabled = true;
            imgContractEndDate.Visible = true;

            txtContractReviewDate.Enabled = true;
            imgContractReviewDate.Visible = true;

            txtLOIDate.Enabled = true;
            ImgLOIDate.Visible = true;

            txtLOIStartDate.Enabled = true;
            imgLOIStartDate.Visible = true;

            imgWEF.Visible = true;
            txtWEF.Enabled = true;
        }

      
        //Hide LOI
        if (txtLOIDate.Text == "")
        {
            if (lblStatus.Text == Resources.Resource.Fresh)
            {
                DivPanelLOIReceived.Attributes.Add("style", "display:block");
            }
            else
            {
                DivPanelLOIReceived.Attributes.Add("style", "display:none");
            }
        }
        else
        {
            DivPanelLOIReceived.Attributes.Add("style", "display:block");
        }
    }
    #endregion

    #region To Fill Details in LOI Received And Contract Paper Signed
    /// <summary>
    /// Fills the details.
    /// </summary>
    /// <param name="AmendNo">The amend no.</param>
    private void FillDetails(int AmendNo)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();

        ds = objSales.ContractMasterDetailsGet(AmendNo, txtClientCode.Text, hfContractNumber.Value, BaseLocationAutoID);
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                btnCreateSaleOrder.Visible = true;
                if (ds.Tables[0].Rows[0]["Status"].ToString().Trim().ToLower() == strStatusAuthorized.ToString().Trim().ToLower())
                {
                    lblStatus.Text = Resources.Resource.Authorized;
                    cbContractPaperDelivered.Enabled = false;

                }
                else if (ds.Tables[0].Rows[0]["Status"].ToString().Trim().ToLower() == strStatusAmend.ToString().Trim().ToLower())
                {
                    lblStatus.Text = Resources.Resource.Amend;

                }
                else if (ds.Tables[0].Rows[0]["Status"].ToString().Trim().ToLower() == strStatusFresh.ToString().Trim().ToLower())
                {
                    lblStatus.Text = Resources.Resource.Fresh;
                }
                else if (ds.Tables[0].Rows[0]["Status"].ToString().Trim().ToLower() == strStatusShortClosed.ToString().Trim().ToLower())
                {
                    lblStatus.Text = Resources.Resource.ShortClosed;
                }

                txtContractNumber.Text = ds.Tables[0].Rows[0]["ContractNumber"].ToString();
                txtDeliveryDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["DeliveryDate"].ToString())));
                txtDeliveryTo.Text = ds.Tables[0].Rows[0]["DeliveryTo"].ToString();
                txtExpectedSignDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["ExptSignDate"].ToString())));
                txtIssuingAuthority.Text = ds.Tables[0].Rows[0]["IssuingAuth"].ToString();
                txtLOIDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["LOIDate"].ToString())));
                txtLOIEndDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["LOIEndDate"].ToString())));
                txtLOIStartDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["LOIStartDate"].ToString())));
                txtAmendmentNo.Text = AmendNo.ToString();
                txtManualContractNo.Text = ds.Tables[0].Rows[0]["MContractNumber"].ToString();
                txtClientSigningAuthority.Text = ds.Tables[0].Rows[0]["ClientSignAuth"].ToString();
                txtSCD.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["ShortCloseDate"].ToString())));
                txtDesignationAuthority.Text = ds.Tables[0].Rows[0]["DesignationAuth"].ToString();
                txtContractSignDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["ContractSignDate"].ToString())));
                txtContractStartDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["ContStartDate"].ToString())));
                txtContractEndDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["ContEndDate"].ToString())));
                txtWEF.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["WithEffectFrom"].ToString())));
                txtContractReviewDate.Text = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["ContReviewDate"].ToString())));
                HFOldContractEndDate.Value = (ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["ContEndDate"].ToString())));
                /*V1.1*/
                txtContractAlert.Text = ds.Tables[0].Rows[0]["ParamValue"].ToString();
                //txtContractValue.Text = ds.Tables[0].Rows[0]["ContractValue"].ToString();
                if (ds.Tables[0].Rows[0]["NoticePeriodDaysToTerminate"] != null)
                {
                    txtNoticePeriodDaysToTerminate.Text = ds.Tables[0].Rows[0]["NoticePeriodDaysToTerminate"].ToString();

                }
                else
                {
                    txtNoticePeriodDaysToTerminate.Text = "0";
                }
                if (ds.Tables[0].Rows[0]["TotalWarrentyAmount"] != null)
                {
                    txtTotalWarrantyAmount.Text = ds.Tables[0].Rows[0]["TotalWarrentyAmount"].ToString();
                }
                else
                {
                    txtTotalWarrantyAmount.Text = "0.0";
                }
                txtRenewalInMonths.Text = ds.Tables[0].Rows[0]["RenewalInMonths"].ToString();
                txtClientNoticeToRenewalInDays.Text = ds.Tables[0].Rows[0]["ClientNoticeToRenewalInDays"].ToString();
                txtInsurance.Text = ds.Tables[0].Rows[0]["Insurance"].ToString();
                cbIsAutoRenewal.Checked = bool.Parse(ds.Tables[0].Rows[0]["IsAutoRenewal"].ToString());
                cbIsLimitedWarranty.Checked = bool.Parse(ds.Tables[0].Rows[0]["IsLimitedWarrenty"].ToString());
                cbIsScanCopyExists.Checked = bool.Parse(ds.Tables[0].Rows[0]["IsScanCopyExists"].ToString());
                cbIfWeCanTerminate.Checked = bool.Parse(ds.Tables[0].Rows[0]["IfWeCanTerminate"].ToString());

                if (ds.Tables[0].Rows[0]["ContractPaperDelivered"] != null)
                {
                    if (bool.Parse(ds.Tables[0].Rows[0]["ContractPaperDelivered"].ToString()) == true)
                    {
                        cbContractPaperDelivered.Checked = true;
                    }
                    else
                    {
                        cbContractPaperDelivered.Checked = false;
                    }
                }
                else
                {
                    btnCreateSaleOrder.Visible = false;
                }
            }
        }
        catch (Exception)
        {
        }
    }
    #endregion

    #region Function Related to DropDown Amendment Number
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAmendementNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlAmendementNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDetails(int.Parse(ddlAmendementNumber.SelectedValue.ToString()));
        if (int.Parse(hfMaxAmendmentNumber.Value) != int.Parse(ddlAmendementNumber.SelectedValue.ToString()))
        {
            btnAmend.Visible = false;
            btnSave.Visible = false;
            btnAuthorize.Visible = false;
            btnEdit.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAddNew.Visible = false;
            btnDelete.Visible = false;
            btnShortClose.Visible = false;
        }
        else
        {
            HideButtonBasedOnStatus();
        }
        if (IsAuthorizationAccess != true)
        {
            btnAuthorize.Visible = false;
        }
        up1.Update();
    }
    /// <summary>
    /// Fillddls the amendment number.
    /// </summary>
    /// <param name="strContractNumber">The string contract number.</param>
    private void FillddlAmendmentNumber(string strContractNumber)
    {
        BL.Sales objSales = new BL.Sales();
        ddlAmendementNumber.DataSource = objSales.AmendmentNoBasedOnContractNoGetAll(strContractNumber);
        ddlAmendementNumber.DataTextField = "AmendmentNo";
        ddlAmendementNumber.DataValueField = "AmendmentNo";
        ddlAmendementNumber.DataBind();
    }
    #endregion

    #region Function Related to GridView ViewSO
    /// <summary>
    /// Fillgvs the view so.
    /// </summary>
    private void FillgvViewSO()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dtViewSO = new DataTable();
        ds = objSales.SaleOrderViewGet(txtContractNumber.Text, txtClientCode.Text);
        dtViewSO = ds.Tables[0];
        gvViewSO.DataSource = dtViewSO;
        gvViewSO.DataBind();
        upContractList.Update();
    }
    /// <summary>
    /// Handles the Sorting event of the gvViewSO control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewSortEventArgs" /> instance containing the event data.</param>
    protected void gvViewSO_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        BL.Sales objSales = new BL.Sales();
        DataView dv = new DataView(objSales.SaleOrderViewGet(txtContractNumber.Text, txtClientCode.Text).Tables[0]);
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESC", dv, gvViewSO);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASC", dv, gvViewSO);
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvViewSO control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvViewSO_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvViewSO.PageIndex = e.NewPageIndex;
        FillgvViewSO();
    }
    /// <summary>
    /// Handles the Click event of the lbSaleOrderNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void lbSaleOrderNo_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbSaleOrderNo = (LinkButton)gvViewSO.Rows[row.RowIndex].FindControl("lbSaleOrderNo");
        Response.Redirect("../Sales/SaleOrderMaster.aspx?SoNo=" + lbSaleOrderNo.Text + "&ClientCode=" + txtClientCode.Text);
    }
    #endregion

    #region Function To Hide and Show Controles and divs
    /// <summary>
    /// Hides the other information.
    /// </summary>
    private void HideOtherInfo()
    {
        DivPanelLOIReceived.Visible = false;
        DivPanelContractPaperReceived.Visible = false;
    }
    /// <summary>
    /// Shows the other information.
    /// </summary>
    private void ShowOtherInfo()
    {

        DivPanelLOIReceived.Visible = true;
        DivPanelContractPaperReceived.Visible = true;
    }
    /// <summary>
    /// Hides the button based on status.
    /// </summary>
    private void HideButtonBasedOnStatus()
    {
        HideButtons();
        if (IsReadAccess == true)
        {
            if (lblStatus.Text != "")
            {
                // btnViewSO.Visible = true;
            }
            else
            {
                //btnViewSO.Visible = false;
            }
        }
        if (lblStatus.Text == Resources.Resource.Authorized)
        {

            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnAmend.Visible = true;
                //   btnAuthorize.Visible = false;
                // btnEdit.Visible = false;
                //  btnUpdate.Visible = false;
                //  btnCancel.Visible = false;
                btnUpload.Visible = true;
                btnShortClose.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                    // btnEdit.Visible = false;
                    // btnDelete.Visible = false;
                    btnUpload.Visible = true;
                }
                else
                {
                    // btnUpload.Visible = false;
                    // btnAddNew.Visible = false;
                }
                if (IsModifyAccess == true)
                {
                    btnUpload.Visible = true;
                    btnAmend.Visible = true;
                    //btnDelete.Visible = false;
                    //btnUpdate.Visible = false;
                    //btnCancel.Visible = false;
                    //btnEdit.Visible = false;
                    btnShortClose.Visible = true;
                }
                else
                {
                    btnShortClose.Visible = false;
                }
                if (IsDeleteAccess == true)
                {
                    btnDelete.Visible = false;
                    btnAddNew.Visible = false;
                }
            }
            // btnAuthorize.Visible = false;
            DisableFields();
            txtWEF.Enabled = true;
            imgWEF.Visible = true;
            cbContractPaperDelivered.Enabled = false;
        }
        if (lblStatus.Text == Resources.Resource.Fresh || lblStatus.Text == Resources.Resource.Amend)
        {
            if (lblStatus.Text == Resources.Resource.Amend)
            {
                // EnableFields();
                DisableFields();
                txtContractEndDate.Enabled = true;
                imgContractEndDate.Visible = true;
                txtContractReviewDate.Enabled = true;
                imgContractReviewDate.Visible = true;
                txtManualContractNo.Enabled = true;
                txtClientSigningAuthority.Enabled = true;
                txtDesignationAuthority.Enabled = true;

                txtNoticePeriodDaysToTerminate.Enabled = true;
                txtTotalWarrantyAmount.Enabled = true;
                txtRenewalInMonths.Enabled = true;
                txtClientNoticeToRenewalInDays.Enabled = true;
                txtInsurance.Enabled = true;
                cbIsAutoRenewal.Enabled = true;
                cbIsLimitedWarranty.Enabled = true;
                cbIsScanCopyExists.Enabled = true;
                cbIfWeCanTerminate.Enabled = true;
                //Manish 9/4/2013 If Status is Amend then short closed should not be visible
                btnShortClose.Visible = false;
            }
            else
            {
            }
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                if (IsAuthorizationAccess != true)
                {
                    btnAuthorize.Visible = false;
                }
                else
                {
                    btnAuthorize.Visible = true;
                }
                btnUpdate.Visible = true;
                btnUpload.Visible = true;
                // btnShortClose.Visible = true;
                if (lblStatus.Text == Resources.Resource.Fresh)
                {
                    EnableFields();
                    btnCancel.Visible = false;
                    btnDelete.Visible = true;
                    //btnViewSO.Visible = false;
                    btnShortClose.Visible = false;
                }
                else
                {
                }
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                    btnUpload.Visible = true;
                }
                else
                {
                    btnUpload.Visible = false;
                    btnAddNew.Visible = false;
                }
                if (IsAuthorizationAccess == true)
                {
                    btnAuthorize.Visible = true;
                }
                else
                {
                    btnAuthorize.Visible = false;
                }
                if (IsModifyAccess == true)
                {
                    btnShortClose.Visible = true;
                    btnUpdate.Visible = true;
                    btnUpload.Visible = true;
                }
                else
                {
                    btnShortClose.Visible = false;
                }
                if (lblStatus.Text == Resources.Resource.Fresh)
                {
                    if (IsDeleteAccess == true)
                    {
                        btnDelete.Visible = true;
                    }
                }
                else
                {
                    btnDelete.Visible = false;
                }
            }
        }

        if (lblStatus.Text == Resources.Resource.ShortClosed)
        {
            btnAuthorize.Visible = false;
            btnAmend.Visible = false;
            btnShortClose.Visible = false;
            btnEdit.Visible = false;
            btnCreateSaleOrder.Visible = false;
            if (IsModifyAccess == true)
            {
                btnAddNew.Visible = true;
            }
            else
            {
                btnAddNew.Visible = false;
            }
            btnDelete.Visible = false;

        }

        //if (gvLOIReceived.Rows.Count == 0)
        //{
        //    btnShortClose.Visible = false;
        //}
        //else
        //{
        //    btnShortClose.Visible = true;
        //}

    }
    /// <summary>
    /// Hides the buttons.
    /// </summary>
    private void HideButtons()
    {
        btnAddNew.Visible = false;
        btnAmend.Visible = false;
        btnAuthorize.Visible = false;
        btnCancel.Visible = false;
        btnDelete.Visible = false;
        btnEdit.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        //btnViewSO.Visible = false;
    }
    /// <summary>
    /// Disables the fields.
    /// </summary>
    private void DisableFields()
    {
        txtAmendmentNo.Enabled = false;
        txtContractEndDate.Enabled = false;
        txtContractReviewDate.Enabled = false;
        txtContractSignDate.Enabled = false;
        txtContractStartDate.Enabled = false;

        txtDeliveryDate.Enabled = false;
        txtDeliveryTo.Enabled = false;
        txtDesignationAuthority.Enabled = false;
        txtExpectedSignDate.Enabled = false;
        txtIssuingAuthority.Enabled = false;
        txtLOIDate.Enabled = false;
        txtLOIEndDate.Enabled = false;
        txtLOIStartDate.Enabled = false;
        txtWEF.Enabled = false;
        imgWEF.Visible = false;

        txtManualContractNo.Enabled = false;
        txtClientSigningAuthority.Enabled = false;
        txtDesignationAuthority.Enabled = false;
        txtWEF.Enabled = false;
        imgContractEndDate.Visible = false;
        imgContractReviewDate.Visible = false;
        imgContractSignDate.Visible = false;
        imgContractStartDate.Visible = false;
        ImgDeliveryDate.Visible = false;
        imgExpectedSignDate.Visible = false;
        ImgLOIDate.Visible = false;
        ImgLOIEndDate.Visible = false;
        imgLOIStartDate.Visible = false;
        imgWEF.Visible = false;
        cbContractPaperDelivered.Enabled = true;
        txtContractValue.Enabled = false;

        txtNoticePeriodDaysToTerminate.Enabled = false;
        txtTotalWarrantyAmount.Enabled = false;
        txtRenewalInMonths.Enabled = false;
        txtClientNoticeToRenewalInDays.Enabled = false;
        txtInsurance.Enabled = false;
        cbIsAutoRenewal.Enabled = false;
        cbIsLimitedWarranty.Enabled = false;
        cbIsScanCopyExists.Enabled = false;
        cbIfWeCanTerminate.Enabled = false;

    }
    /// <summary>
    /// Enables the contract fields.
    /// </summary>
    private void EnableContractFields()
    {
        txtContractSignDate.Enabled = true;
        txtContractStartDate.Enabled = true;
        txtContractEndDate.Enabled = true;
        txtContractReviewDate.Enabled = true;
        txtManualContractNo.Enabled = true;
        txtClientSigningAuthority.Enabled = true;
        txtDesignationAuthority.Enabled = true;
        //txtContractValue.Enabled = true;
        ceContractStartDate.Enabled = true;
        ceContractSignDate.Enabled = true;
        ceContractEndDate.Enabled = true;
        ceContractReviewDate.Enabled = true;
        txtContractAlert.Enabled = true;

        txtNoticePeriodDaysToTerminate.Enabled = true;
        txtTotalWarrantyAmount.Enabled = true;
        txtRenewalInMonths.Enabled = true;
        txtClientNoticeToRenewalInDays.Enabled = true;
        txtInsurance.Enabled = true;
        cbIsAutoRenewal.Enabled = true;
        cbIsLimitedWarranty.Enabled = true;
        cbIsScanCopyExists.Enabled = true;
        cbIfWeCanTerminate.Enabled = true;


        //Manish 14-Mar-2013
        EnableMandatoryField();
    }

    /// <summary>
    /// To avoid mandatory Field
    /// </summary>
    private void EnableMandatoryField()
    {
        RfvContractSignDate.ValidationGroup = "Save";
        RfvContractStartDate.ValidationGroup = "Save";
        RfvContractEndDate.ValidationGroup = "Save";
        RfvContractReviewDate.ValidationGroup = "Save";
        RfvManualContractNo.ValidationGroup = "Save";
        RfvClientSigningAuthority.ValidationGroup = "Save";

    }
    /// <summary>
    /// Disables the contract fields.
    /// </summary>
    private void DisableContractFields()
    {
        txtContractSignDate.Enabled = false;
        txtContractStartDate.Enabled = false;
        txtContractEndDate.Enabled = false;
        txtContractReviewDate.Enabled = false;
        txtManualContractNo.Enabled = false;
        txtClientSigningAuthority.Enabled = false;
        txtDesignationAuthority.Enabled = false;
        txtContractValue.Enabled = false;
        ceContractStartDate.Enabled = false;
        ceContractSignDate.Enabled = false;
        ceContractEndDate.Enabled = false;
        ceContractReviewDate.Enabled = false;

        txtNoticePeriodDaysToTerminate.Enabled = false;
        txtTotalWarrantyAmount.Enabled = false;
        txtRenewalInMonths.Enabled = false;
        txtClientNoticeToRenewalInDays.Enabled = false;
        txtInsurance.Enabled = false;
        cbIsAutoRenewal.Enabled = false;
        cbIsLimitedWarranty.Enabled = false;
        cbIsScanCopyExists.Enabled = false;
        cbIfWeCanTerminate.Enabled = false;
        //Manish 14-Mar-2013
        //RfvContractSignDate.Enabled=false;
        //RfvContractStartDate.Enabled=false;
        //RfvContractEndDate.Enabled=false;
        //RfvManualContractNo.Enabled=false;
        //RfvClientSigningAuthority.Enabled = false;

        Label25.Visible = false;
        txtSCD.Visible = false;
        imgSCD.Visible = false;

        DisableMandatoryField();


    }

    /// <summary>
    /// Disables the mandatory field.
    /// </summary>
    private void DisableMandatoryField()
    {
        RfvContractSignDate.ValidationGroup = "";
        RfvContractStartDate.ValidationGroup = "";
        RfvContractEndDate.ValidationGroup = "";
        RfvContractReviewDate.ValidationGroup = "";
        RfvManualContractNo.ValidationGroup = "";
        RfvClientSigningAuthority.ValidationGroup = "";


    }

    /// <summary>
    /// Enables the fields.
    /// </summary>
    private void EnableFields()
    {
        ///************V1.4************/
        //BL.Sales objSale = new BL.Sales();
        //DataTable dtSale = new DataTable();
        //dtSale = objSale.blAutoGenerate_ClientCode(BaseCompanyCode, "AutoGenerateContractNumber".ToString());
        //if (dtSale.Rows.Count > 0)
        //{
        //    if (dtSale.Rows[0]["ParamValue1"].ToString() == "0")
        //    {
        //        txtContractNumber.ReadOnly = true;
        //        txtContractNumber.Focus();
        //    }
        //    else
        //    {
        //        txtContractNumber.ReadOnly = false;
        //    }
        //}
        /************V1.4************/
        txtWEF.Enabled = true;
        imgWEF.Visible = true;

        txtAmendmentNo.Enabled = true;
        txtContractEndDate.Enabled = true;
        txtContractReviewDate.Enabled = true;
        txtContractSignDate.Enabled = true;
        txtContractStartDate.Enabled = true;
        txtDeliveryDate.Enabled = true;
        txtDeliveryTo.Enabled = true;
        txtDesignationAuthority.Enabled = true;
        txtExpectedSignDate.Enabled = true;
        txtIssuingAuthority.Enabled = true;
        txtLOIDate.Enabled = true;
        txtLOIEndDate.Enabled = true;
        txtLOIStartDate.Enabled = true;
        txtManualContractNo.Enabled = true;
        txtClientSigningAuthority.Enabled = true;
        txtDesignationAuthority.Enabled = true;
        imgContractEndDate.Visible = true;
        imgContractReviewDate.Visible = true;
        imgContractSignDate.Visible = true;
        imgContractStartDate.Visible = true;
        ImgDeliveryDate.Visible = true;
        imgExpectedSignDate.Visible = true;
        ImgLOIDate.Visible = true;
        ImgLOIEndDate.Visible = true;
        imgLOIStartDate.Visible = true;
        cbContractPaperDelivered.Enabled = true;
        txtContractAlert.Enabled = true;
        //txtContractValue.Enabled = true;

        txtNoticePeriodDaysToTerminate.Enabled = true;
        txtTotalWarrantyAmount.Enabled = true;
        txtRenewalInMonths.Enabled = true;
        txtClientNoticeToRenewalInDays.Enabled = true;
        txtInsurance.Enabled = true;
        cbIsAutoRenewal.Enabled = true;
        cbIsLimitedWarranty.Enabled = true;
        cbIsScanCopyExists.Enabled = true;
        cbIfWeCanTerminate.Enabled = true;
        //btnLOISave.Visible = true;

    }
    /// <summary>
    /// Clears the fields.
    /// </summary>
    private void ClearFields()
    {
        txtContractNumber.Text = "";
        txtContractEndDate.Text = "";
        txtContractReviewDate.Text = "";
        txtContractSignDate.Text = "";
        txtContractStartDate.Text = "";
        txtDeliveryDate.Text = "";
        txtDeliveryTo.Text = "";
        txtDesignationAuthority.Text = "";
        txtExpectedSignDate.Text = "";
        txtIssuingAuthority.Text = "";
        txtLOIDate.Text = "";
        txtLOIEndDate.Text = "";
        txtLOIStartDate.Text = "";
        txtManualContractNo.Text = "";
        txtClientSigningAuthority.Text = "";
        txtWEF.Text = "";
        // txtContractValue.Text = "";
        cbContractPaperDelivered.Checked = false;

        txtNoticePeriodDaysToTerminate.Text = "";
        txtTotalWarrantyAmount.Text = "";
        txtRenewalInMonths.Text = "";
        txtClientNoticeToRenewalInDays.Text = "";
        txtInsurance.Text = "";
        cbIsAutoRenewal.Checked = false;
        cbIsLimitedWarranty.Checked = false;
        cbIsScanCopyExists.Checked = false;
        cbIfWeCanTerminate.Checked = false;
    }
    /// <summary>
    /// Hides the button on search click.
    /// </summary>
    private void HideButtonOnSearchClick()
    {
        btnAddNew.Visible = false;
        btnAmend.Visible = false;
        btnAuthorize.Visible = false;
        btnCancel.Visible = false;
        btnDelete.Visible = false;
        btnEdit.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        //btnViewSO.Visible = false;

    }
    #endregion

    #region Buttons event on Page
    /// <summary>
    /// Handles the Click event of the btnViewSO control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnViewSO_Click(object sender, EventArgs e)
    {
        //DIVViewSO.Visible = true;
        //FillgvViewSO();
    }
    /// <summary>
    /// Handles the Click event of the btnViewCubicDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnViewCubicDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ContractDetails.aspx?ContractNumber=" + txtContractNumber.Text + "&ClientCode=" + txtClientCode.Text + "&AmendNo=" + ddlAmendementNumber.SelectedItem.Text.ToString());
    }
    /// <summary>
    /// Handles the Click event of the btnCreateSaleOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnCreateSaleOrder_Click(object sender, EventArgs e)
    {
        //if (lblStatus.Text == Resources.Resource.Authorized)
        //{
        //    lblStatus.Text = strStatusAuthorized;
        //}
        //else if (lblStatus.Text == Resources.Resource.Amend)
        //{
        //    lblStatus.Text = strStatusAmend;
        //}
        //else if (lblStatus.Text == Resources.Resource.Fresh)
        //{
        //    lblStatus.Text = strStatusFresh;
        //}
        //else if (lblStatus.Text == Resources.Resource.ShortClosed)//Resources.Resource.Fresh)
        //{
        //    lblStatus.Text = strStatusShortClosed;
        //}

        if (lblStatus.Text == Resources.Resource.Authorized)
        {
            Response.Redirect("../Sales/SaleOrderMaster.aspx?SoNo=0&ClientCode=" + txtClientCode.Text + "&WEFDate=" + txtContractStartDate.Text);
        }
        else
        {
            DisplayMessageString(lblErrorMsgGrid, Resources.Resource.AuthorizeContractbeforecreatingSalesOrder);
        }
    }
    /// <summary>
    /// btnPostBack is a Hiiden Button (Used For TxtClientCode Blur Event )
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        //if (btnCancel.Text == Resources.Resource.Back)
        //{
        //    DivGridView.Visible = true;
        //    DivPanelGeneralInfo.Visible = false;
        //    DivPanelLOIReceived.Visible = false;
        //    DivPanelContractPaperReceived.Visible = false;
        //    HideButtonOnSearchClick();
        //    btnAddNew.Visible = true;
        //}
        //else
        //{
        //    DisableFields();
        //    btnCancel.Visible = false;
        //    btnAddNew.Visible = true;
        //    btnDelete.Visible = true;
        //    HideButtonBasedOnStatus();
        //    FillDetails(int.Parse(txtAmendmentNo.Text));
        //}
    }
    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        txtContractValue.Text = "";
        txtAmendmentNo.Text = "0";

        ddlAmendementNumber.Items.Clear();
        ListItem Li = new ListItem("0", "0");
        ddlAmendementNumber.Items.Add(Li);
        ddlAmendementNumber.SelectedValue = txtAmendmentNo.Text;
        ClearFields();
        lblStatus.Text = Resources.Resource.Fresh;
        HideButtonBasedOnStatus();
        EnableFields();
        btnSave.Visible = true;
        //DivGridView.Visible = false;
        DivPanelContractPaperReceived.Visible = false;
        DivPanelLOIReceived.Visible = true;
        btnAuthorize.Visible = false;
        btnDelete.Visible = false;
        btnAmend.Visible = false;
        btnEdit.Visible = false;
        btnAddNew.Visible = false;
        btnViewCubicDetails.Visible = false;
        btnCancel.Text = Resources.Resource.Back;
        btnShortClose.Visible = false;
        btnUpload.Visible = false;
        btnUpdate.Visible = false;
        txtContractAlert.Enabled = true;
        if (cbContractPaperDelivered.Checked)
        {
            EnableContractFields();
        }
        else
        {
            DisableContractFields();
        }


        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.ClientNameGet(txtClientCode.Text, BaseLocationAutoID);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            lblCustomerName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
            txtContractAlert.Text = ds.Tables[0].Rows[0]["ParamValue"].ToString();
        }
        else
        {
            lblCustomerName.Text = "";
        }
        DivPanelLOIReceived.Attributes.Add("style", "display:block");
    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        if (cbContractPaperDelivered.Checked)
        {
            //Modify for Bug #2493, #2490 & #2491
            //if (txtContractEndDate.Text == "" || txtContractReviewDate.Text == "" || txtContractSignDate.Text == "" || txtContractStartDate.Text == "" || txtClientSigningAuthority.Text == "" || txtDesignationAuthority.Text == "")
            if(string.IsNullOrEmpty(txtContractEndDate.Text) || string.IsNullOrEmpty(txtContractReviewDate.Text) || string.IsNullOrEmpty(txtContractSignDate.Text) || string.IsNullOrEmpty(txtContractStartDate.Text) || string.IsNullOrEmpty(txtClientSigningAuthority.Text.Trim()) || string.IsNullOrEmpty(txtDesignationAuthority.Text.Trim()) || string.IsNullOrEmpty(txtManualContractNo.Text))    
            {
                lblErrorMsgGrid.Text = Resources.Resource.MsgRequiredFieldLeftBlank; //@"Mandatory Fields can't be left blank";   // Modify for Bug #2491
                btnAuthorize.Visible = false;
                return;
            }
        }
        if (txtNoticePeriodDaysToTerminate.Text == "")
        {
            txtNoticePeriodDaysToTerminate.Text = @"0";
        }
        if (txtTotalWarrantyAmount.Text == "")
        {
            txtTotalWarrantyAmount.Text = @"0";
        }
        if (txtRenewalInMonths.Text == "")
        {
            txtRenewalInMonths.Text = @"0";
        }
        if (txtClientNoticeToRenewalInDays.Text == "")
        {
            txtClientNoticeToRenewalInDays.Text = @"0";
        }

        if ((txtDeliveryDate.Text != "" || txtExpectedSignDate.Text != "" || txtIssuingAuthority.Text != "" || txtLOIDate.Text != "" || txtLOIEndDate.Text != "" || txtLOIStartDate.Text != "" || txtDeliveryTo.Text != "" || txtContractEndDate.Text != "" || txtContractReviewDate.Text != "" || txtContractSignDate.Text != "" || txtContractStartDate.Text != "" || txtManualContractNo.Text != "" || txtClientSigningAuthority.Text != "" || txtDesignationAuthority.Text != ""))
        {
            if ((txtDeliveryDate.Text != "" && txtExpectedSignDate.Text != "" && txtIssuingAuthority.Text != "" && txtLOIDate.Text != "" && txtLOIEndDate.Text != "" && txtLOIStartDate.Text != "" && txtDeliveryTo.Text != "") || (txtDeliveryDate.Text == "" && txtExpectedSignDate.Text == "" && txtIssuingAuthority.Text == "" && txtLOIDate.Text == "" && txtLOIEndDate.Text == "" && txtLOIStartDate.Text == "" && txtDeliveryTo.Text == ""))
            {
                //if ((txtContractEndDate.Text != "" && txtContractSignDate.Text != "" && txtContractStartDate.Text != ""))// && txtManualContractNo.Text != "" && txtClientSigningAuthority.Text != "" && txtDesignationAuthority.Text != "") || (txtContractEndDate.Text == "" && txtContractSignDate.Text == "" && txtContractStartDate.Text == "" && txtManualContractNo.Text == "" && txtClientSigningAuthority.Text == "" && txtDesignationAuthority.Text == ""))
                //{
                if (CompareEqualTO(txtContractStartDate.Text, txtLOIStartDate.Text) == true)
                {
                    if (CompareGreaterThan(txtLOIEndDate.Text, txtLOIStartDate.Text) == true)
                    {
                        if (CompareGreaterThan(txtContractEndDate.Text, txtContractStartDate.Text) == true)
                        {
                            if (CompareGreaterThan(txtContractEndDate.Text, txtLOIStartDate.Text) == true)
                            {
                                //if (CompareGreaterThanOrEqualTO(txtContractSignDate.Text, txtLOIDate.Text) == true)
                                //if (CompareEqualTO(txtContractSignDate.Text, txtLOIStartDate.Text) == true)
                                //{
                                if (CompareGreaterThan(txtExpectedSignDate.Text, txtLOIDate.Text) == true)
                                {
                                    if (CompareGreaterThanOrEqualTO(txtContractEndDate.Text, txtContractSignDate.Text) == true)
                                    {
                                        if (CompareGreaterThanOrEqualTO(txtLOIStartDate.Text, txtLOIDate.Text) == true)
                                        {

                                            if (lblStatus.Text == Resources.Resource.Authorized)
                                            {
                                                lblStatus.Text = strStatusAuthorized;
                                            }
                                            else if (lblStatus.Text == Resources.Resource.Amend)
                                            {
                                                lblStatus.Text = strStatusAmend;
                                            }
                                            else if (lblStatus.Text == Resources.Resource.Fresh)
                                            {
                                                lblStatus.Text = strStatusFresh;
                                            }
                                            else if (lblStatus.Text == Resources.Resource.ShortClosed)//Resources.Resource.Fresh)
                                            {
                                                lblStatus.Text = strStatusShortClosed;
                                            }
                                            if (txtContractValue.Text == "")
                                            {
                                                txtContractValue.Text = GetValueAsPerSystemParameters("0.000000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                                            }

                                            //Manish 5/4/2013 if we enter the LOI part then txtWEF.Text should be eqaul to LOIsatrtDate.
                                            //Verify eiter we are enter value by LOI or Contract IF from contract then txtWEF.Text= txtContractStartDate.Text
                                            //Else txtWEF.Text=txtLOIStartDate.text

                                            if (cbContractPaperDelivered.Checked)
                                            {
                                                txtWEF.Text = DateFormat(txtContractStartDate.Text);
                                            }
                                            else
                                            {
                                                txtWEF.Text = DateFormat(txtLOIStartDate.Text);
                                            }

                                            /* V1.5****************************/
                                            if (txtContractNumber.ReadOnly == true)
                                            {   /*****  V1.0*****/

                                                ds = objSales.ContractMasterInsert(
                                                    int.Parse(txtAmendmentNo.Text), txtIssuingAuthority.Text,
                                                    (DateFormat(CheckDateNull(txtDeliveryDate.Text))),
                                                    txtDeliveryTo.Text,
                                                    (DateFormat(CheckDateNull(txtExpectedSignDate.Text))),
                                                    (DateFormat(CheckDateNull(txtLOIDate.Text))),
                                                    (DateFormat(CheckDateNull(txtLOIStartDate.Text))),
                                                    (DateFormat(CheckDateNull(txtLOIEndDate.Text))),
                                                    txtManualContractNo.Text, txtClientSigningAuthority.Text.TrimStart().TrimEnd(),
                                                    txtDesignationAuthority.Text.TrimStart().TrimEnd(),
                                                    (DateFormat(CheckDateNull(txtContractSignDate.Text))),
                                                    (DateFormat(CheckDateNull(txtContractStartDate.Text))),
                                                    (DateFormat(CheckDateNull(txtContractEndDate.Text))),
                                                    (DateFormat(CheckDateNull(txtContractReviewDate.Text))),
                                                    BaseUserID, txtClientCode.Text, BaseLocationAutoID,
                                                    (DateFormat(CheckDateNull(txtWEF.Text))), lblStatus.Text,
                                                    float.Parse(txtContractValue.Text),
                                                    cbContractPaperDelivered.Checked, txtContractAlert.Text,
                                                    txtNoticePeriodDaysToTerminate.Text,
                                                    txtTotalWarrantyAmount.Text,
                                                    txtRenewalInMonths.Text,
                                                    txtClientNoticeToRenewalInDays.Text,
                                                    txtInsurance.Text,
                                                    cbIsAutoRenewal.Checked,
                                                    cbIsLimitedWarranty.Checked,
                                                    cbIsScanCopyExists.Checked,
                                                    cbIfWeCanTerminate.Checked
                                                    );
                                                /*****  V1.0*****/
                                            }
                                            else
                                            {
                                                if (txtContractNumber.Text.Trim() == "" || txtContractNumber.Text == null)
                                                {
                                                    lblErrorMsgGrid.Text = Resources.Resource.BlankContractNumber;
                                                    txtContractNumber.Focus();
                                                    return;
                                                }
                                                else
                                                {
                                                    ds = objSales.ContractMasterManuallyInsert(int.Parse(txtAmendmentNo.Text), txtIssuingAuthority.Text, (DateFormat(CheckDateNull(txtDeliveryDate.Text))), txtDeliveryTo.Text, (DateFormat(CheckDateNull(txtExpectedSignDate.Text))), (DateFormat(CheckDateNull(txtLOIDate.Text))), (DateFormat(CheckDateNull(txtLOIStartDate.Text))), (DateFormat(CheckDateNull(txtLOIEndDate.Text))), txtManualContractNo.Text, txtClientSigningAuthority.Text.TrimStart().TrimEnd(), txtDesignationAuthority.Text.TrimStart().TrimEnd(), (DateFormat(CheckDateNull(txtContractSignDate.Text))), (DateFormat(CheckDateNull(txtContractStartDate.Text))), (DateFormat(CheckDateNull(txtContractEndDate.Text))), (DateFormat(CheckDateNull(txtContractReviewDate.Text))), BaseUserID, txtClientCode.Text, BaseLocationAutoID, (DateFormat(CheckDateNull(txtWEF.Text))), lblStatus.Text, float.Parse(txtContractValue.Text), cbContractPaperDelivered.Checked, txtContractAlert.Text, txtContractNumber.Text);
                                                    if (ds != null && ds.Tables[0].Rows[0]["MessageID"].ToString() == "11")
                                                    {
                                                        DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                                        return;
                                                    }
                                                }
                                            }
                                            /* V1.5****************************/

                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                txtContractNumber.Text = ds.Tables[0].Rows[0]["ContractNumber"].ToString();
                                                //up1.Update();
                                            }
                                            if (txtContractNumber.Text != "")
                                            {
                                                hfContractNumber.Value = txtContractNumber.Text;
                                                //HideOtherInfo();
                                                HideButtonOnSearchClick();
                                                FillgvLOIReceived();
                                                FillddlAmendmentNumber(txtContractNumber.Text);
                                                btnAddNew.Visible = true;
                                                FillDetails(int.Parse(ddlAmendementNumber.SelectedItem.Text));
                                                //DisableFields();
                                                HideButtonBasedOnStatus();
                                                lblErrorMsgGrid.Text = "Record Successfully Inserted";
                                                hfContractNumber.Value = "";
                                            }
                                        }
                                        else
                                        {
                                            lblErrorMsgGrid.Text = Resources.Resource.LOIStartdateshouldbegreaterthanOrEqualLOIDate;//"LOI Start date should be greater than or equal to  LOI Date ";
                                            btnAuthorize.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        lblErrorMsgGrid.Text = Resources.Resource.ContractSignDateShouldbelessthanorequaltoContractEndDate;
                                        //  lblErrorMsgGrid.Text = Resources.Resource.ContractStartDategreaterthanOrEqualTocontractsignDate;//"Contract Start Date Should be greater or equal to contract sign Date";
                                        btnAuthorize.Visible = false;
                                    }
                                }
                                else
                                {
                                    lblErrorMsgGrid.Text = Resources.Resource.ExpectSignDategreaterthanLOIDate;// "Expected Signing Date Should be greater than LOI Date";
                                    btnAuthorize.Visible = false;
                                }
                                //}
                                //else
                                //{
                                //    lblErrorMsgGrid.Text = Resources.Resource.ContractSignDateGreatethanorequaltoLOIDate;// "Contract Sign Date Dhould be Greater than or equal to LOI Date";
                                //    btnAuthorize.Visible = false;
                                //}
                            }
                            else
                            {
                                lblErrorMsgGrid.Text = Resources.Resource.ContractEndDategreaterthanLOIStartDate;// "Contract End Date Should be greater than LOI Start Date";
                                btnAuthorize.Visible = false;
                            }
                        }
                        else
                        {
                            lblErrorMsgGrid.Text = Resources.Resource.ContractEndDategreaterthanContractStartDate;// "Contract End Date Should be greater than Contract Start Date";
                            btnAuthorize.Visible = false;
                        }
                    }
                    else
                    {
                        lblErrorMsgGrid.Text = Resources.Resource.LOIEndDategreaterthanLOIStartDate;// "LOI End Date Should be greater than LOI Start Date";
                        btnAuthorize.Visible = false;
                    }
                }
                else
                {
                    lblErrorMsgGrid.Text = Resources.Resource.ContractStartDateEqualtoLOIStartDate;// "Contract Start Date Should be equal to LOI Start Date";
                    btnAuthorize.Visible = false;
                }
                //}
                //else
                //{
                //    lblErrorMsgGrid.Text = "Mandatory Fields can't be left blank"; // Resources.Resource.ContractPaperFieldCannotBeLeftBlank;//"Contracrt paper field cannot be left blank";
                //    btnAuthorize.Visible = false;
                //}
            }
            else
            {
                lblErrorMsgGrid.Text = Resources.Resource.LOIfieldscannotbeleftblank;//"LOI fields cannot be left blank";
                btnAuthorize.Visible = false;
            }

        }
        else
        {
            lblErrorMsgGrid.Text = Resources.Resource.Allfieldsareleftblank;//"All fields are left blank";
            btnAuthorize.Visible = false;
        }
        up1.Update();//   5/4/2013 Manish 
    }
    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        /*V1.3*/
        ds = objSales.ContractMasterDelete(txtContractNumber.Text);
        DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
        FillgvLOIReceived();
        HideButtonBasedOnStatus();
        HideButtonOnSearchClick();
        HideOtherInfo(); // Function to Hide All Div Other Than Gridview 
        btnAddNew.Visible = true;
        btnViewCubicDetails.Visible = false;
        up1.Update(); //Manish 05/04/2013
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        //To Avoid Validation Control 
        if (cbContractPaperDelivered.Checked)
        {
            EnableMandatoryField();

        }
        else
        {
            DisableMandatoryField();

        }

        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        int flag;
        int tmpflag;
        txtContractAlert.Enabled = true;
        if (HFOldContractEndDate.Value == "")
        {
            tmpflag = 1;

        }
        else
        {
            tmpflag = 0;

        }
        if (txtContractEndDate.Text == "")
        {
            tmpflag = 1;
        }
        else
        {
            tmpflag = 0;
        }
        if (tmpflag == 0)
        {
            if (HFOldContractEndDate.Value != "")
            {
                if (DateTime.Parse(HFOldContractEndDate.Value) <= DateTime.Parse(txtContractEndDate.Text))
                {
                    tmpflag = 0;
                }
                else
                {
                    tmpflag = 1;
                }
            }
            else
            {
                tmpflag = 0;
            }
        }
        if (txtNoticePeriodDaysToTerminate.Text == "")
        {
            txtNoticePeriodDaysToTerminate.Text = @"0";
        }
        if (txtTotalWarrantyAmount.Text == "")
        {
            txtTotalWarrantyAmount.Text = @"0";
        }
        if (txtRenewalInMonths.Text == "")
        {
            txtRenewalInMonths.Text = @"0";
        }
        if (txtClientNoticeToRenewalInDays.Text == "")
        {
            txtClientNoticeToRenewalInDays.Text = @"0";
        }
        if (cbContractPaperDelivered.Checked)
        {
            //Modify for Bug #2493, #2490 & #2491
            //if (txtContractEndDate.Text == "" || txtContractReviewDate.Text == "" || txtContractSignDate.Text == "" || txtContractStartDate.Text == "" || txtClientSigningAuthority.Text == "" || txtDesignationAuthority.Text == "")
            if(string.IsNullOrEmpty(txtContractEndDate.Text) || string.IsNullOrEmpty(txtContractReviewDate.Text) || string.IsNullOrEmpty(txtContractSignDate.Text) || string.IsNullOrEmpty(txtContractStartDate.Text) || string.IsNullOrEmpty(txtClientSigningAuthority.Text.Trim()) || string.IsNullOrEmpty(txtDesignationAuthority.Text.Trim()) || string.IsNullOrEmpty(txtManualContractNo.Text))    
            {
                lblErrorMsgGrid.Text = Resources.Resource.ContractPaperFieldCannotBeLeftBlank;//"Contracrt paper field cannot be left blank";
                btnAuthorize.Visible = false;
                return;

            }
            else
            {
                tmpflag = 0;
            }
        }
        else
        {
            tmpflag = 0;
        }
        if (txtContractValue.Text == "")
        {
            txtContractValue.Text = "0.0";
        }
        if (tmpflag == 0)
        {
            if (lblStatus.Text == Resources.Resource.Amend)
            {
                txtWEF.Enabled = true;
                imgWEF.Visible = true;
                if (txtWEF.Text != "")
                {
                    if ((txtDeliveryDate.Text != "" || txtExpectedSignDate.Text != "" || txtIssuingAuthority.Text != "" || txtLOIDate.Text != "" || txtLOIEndDate.Text != "" || txtLOIStartDate.Text != "" || txtDeliveryTo.Text != "" || txtContractEndDate.Text != "" || txtContractReviewDate.Text != "" || txtContractSignDate.Text != "" || txtContractStartDate.Text != "" || txtManualContractNo.Text != "" || txtClientSigningAuthority.Text != "" || txtDesignationAuthority.Text != ""))
                    {
                        if ((txtDeliveryDate.Text != "" && txtExpectedSignDate.Text != "" && txtIssuingAuthority.Text != "" && txtLOIDate.Text != "" && txtLOIEndDate.Text != "" && txtLOIStartDate.Text != "" && txtDeliveryTo.Text != "") || (txtDeliveryDate.Text == "" && txtExpectedSignDate.Text == "" && txtIssuingAuthority.Text == "" && txtLOIDate.Text == "" && txtLOIEndDate.Text == "" && txtLOIStartDate.Text == "" && txtDeliveryTo.Text == ""))
                        {
                            //if ((txtContractEndDate.Text != "" && txtContractSignDate.Text != "" && txtContractStartDate.Text != "" && txtClientSigningAuthority.Text != "" && txtDesignationAuthority.Text != ""))// && txtManualContractNo.Text != "" && txtClientSigningAuthority.Text != "" && txtDesignationAuthority.Text != "") || (txtContractEndDate.Text == "" && txtContractSignDate.Text == "" && txtContractStartDate.Text == "" && txtManualContractNo.Text == "" && txtClientSigningAuthority.Text == "" && txtDesignationAuthority.Text == ""))
                            //{
                            if (CompareEqualTO(txtContractStartDate.Text, txtLOIStartDate.Text) == true)
                            {
                                if (CompareGreaterThan(txtLOIEndDate.Text, txtLOIStartDate.Text) == true)
                                {
                                    if (CompareGreaterThan(txtContractEndDate.Text, txtContractStartDate.Text) == true)
                                    {
                                        if (CompareGreaterThan(txtContractEndDate.Text, txtLOIStartDate.Text) == true)
                                        {
                                            //if (CompareEqualTO(txtContractSignDate.Text, txtLOIStartDate.Text) == true)
                                            ////if (CompareEqualTO(txtContractSignDate.Text, txtLOIDate.Text) == true)
                                            //{
                                            if (CompareGreaterThan(txtExpectedSignDate.Text, txtLOIDate.Text) == true)
                                            {
                                                if (CompareGreaterThanOrEqualTO(txtContractEndDate.Text, txtContractSignDate.Text) == true)
                                                {
                                                    //if (CompareGreaterThanOrEqualTO(txtContractStartDate.Text, txtContractSignDate.Text) == true)
                                                    //{
                                                    if (CompareGreaterThanOrEqualTO(txtLOIStartDate.Text, txtLOIDate.Text) == true)
                                                    {
                                                        if (txtContractStartDate.Text != "" && txtContractEndDate.Text != "")
                                                        {
                                                            if (CompareGreaterThanOrEqualTO(txtWEF.Text, txtContractStartDate.Text) == true && CompareGreaterThan(txtContractEndDate.Text, txtWEF.Text) == true)
                                                            {
                                                                flag = 1;
                                                            }
                                                            else
                                                            {
                                                                flag = 0;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (CompareGreaterThanOrEqualTO(txtWEF.Text, txtLOIDate.Text) == true && CompareGreaterThan(txtLOIEndDate.Text, txtWEF.Text) == true)
                                                            {
                                                                flag = 1;
                                                            }
                                                            else
                                                            {
                                                                flag = 0;

                                                            }
                                                        }
                                                        if (flag == 1)
                                                        {
                                                            if (lblStatus.Text == Resources.Resource.Authorized)
                                                            {
                                                                lblStatus.Text = strStatusAuthorized;
                                                            }
                                                            else if (lblStatus.Text == Resources.Resource.Amend)
                                                            {
                                                                lblStatus.Text = strStatusAmend;
                                                            }
                                                            else if (lblStatus.Text == Resources.Resource.Fresh)
                                                            {
                                                                lblStatus.Text = strStatusFresh;
                                                            }
                                                            else if (lblStatus.Text == Resources.Resource.ShortClosed)//Resources.Resource.Fresh)
                                                            {
                                                                lblStatus.Text = strStatusShortClosed;
                                                            }
                                                            if (txtContractValue.Text == "")
                                                            {
                                                                txtContractValue.Text = GetValueAsPerSystemParameters("0.000000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                                                            }
                                                            //V1.2 
                                                            ds = objSales.ContractMasterUpdate(
                                                                txtClientCode.Text, txtContractNumber.Text,
                                                                int.Parse(txtAmendmentNo.Text),
                                                                txtClientSigningAuthority.Text.TrimStart().TrimEnd(),
                                                                (DateFormat(CheckDateNull(txtContractEndDate.Text))),
                                                                (DateFormat(CheckDateNull(txtContractReviewDate.Text))),
                                                                (DateFormat(CheckDateNull(txtContractSignDate.Text))),
                                                                (DateFormat(CheckDateNull(txtContractStartDate.Text))),
                                                                (DateFormat(CheckDateNull(txtDeliveryDate.Text))),
                                                                txtDeliveryTo.Text, txtDesignationAuthority.Text.TrimStart().TrimEnd(),
                                                                (DateFormat(CheckDateNull(txtExpectedSignDate.Text))),
                                                                txtIssuingAuthority.Text,
                                                                (DateFormat(CheckDateNull(txtLOIDate.Text))),
                                                                (DateFormat(CheckDateNull(txtLOIEndDate.Text))),
                                                                (DateFormat(CheckDateNull(txtLOIStartDate.Text))),
                                                                txtManualContractNo.Text, BaseUserID,
                                                                BaseLocationAutoID, lblStatus.Text,
                                                                (DateFormat(CheckDateNull(txtWEF.Text))),
                                                                float.Parse(txtContractValue.Text),
                                                                cbContractPaperDelivered.Checked,
                                                                txtContractAlert.Text,
                                                                txtNoticePeriodDaysToTerminate.Text,
                                                                txtTotalWarrantyAmount.Text,
                                                                txtRenewalInMonths.Text,
                                                                txtClientNoticeToRenewalInDays.Text,
                                                                txtInsurance.Text,
                                                                cbIsAutoRenewal.Checked,
                                                                cbIsLimitedWarranty.Checked,
                                                                cbIsScanCopyExists.Checked,
                                                                cbIfWeCanTerminate.Checked);
                                                            hfContractNumber.Value = txtContractNumber.Text;

                                                            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
                                                            {
                                                                FillgvLOIReceived();
                                                                FillDetails(int.Parse(txtAmendmentNo.Text));
                                                                DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                                            }
                                                            else
                                                            {
                                                                DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                                                FillgvLOIReceived();
                                                                FillDetails(int.Parse(txtAmendmentNo.Text));

                                                                HideButtonBasedOnStatus();
                                                                DisableFields();
                                                                txtManualContractNo.Enabled = true;
                                                                txtClientSigningAuthority.Enabled = true;
                                                                txtDesignationAuthority.Enabled = true;

                                                                txtNoticePeriodDaysToTerminate.Enabled = true;
                                                                txtTotalWarrantyAmount.Enabled = true;
                                                                txtRenewalInMonths.Enabled = true;
                                                                txtClientNoticeToRenewalInDays.Enabled = true;
                                                                txtInsurance.Enabled = true;
                                                                cbIsAutoRenewal.Enabled = true;
                                                                cbIsLimitedWarranty.Enabled = true;
                                                                cbIsScanCopyExists.Enabled = true;
                                                                cbIfWeCanTerminate.Enabled = true;

                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (((CompareGreaterThan(txtContractStartDate.Text, txtWEF.Text) == true) || (CompareGreaterThan(txtWEF.Text, txtContractEndDate.Text)) == true) && (txtContractStartDate.Text != "" && txtContractEndDate.Text != ""))
                                                            {
                                                                lblErrorMsgGrid.Text = Resources.Resource.WithEffectFromDatebebetweenContractSignandEndDate;// "With Effective From Date Should be between Contract Sign date and Contract End Date";
                                                            }
                                                            else if ((CompareGreaterThan(txtLOIDate.Text, txtWEF.Text) == true && CompareGreaterThan(txtLOIEndDate.Text, txtWEF.Text) == true) && (txtLOIEndDate.Text != "" && txtLOIDate.Text != ""))
                                                            {
                                                                lblErrorMsgGrid.Text = Resources.Resource.WithEffectFromDatebegreaterthanLOIdate;// "With Effective From Date Should be greater than LOI date";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lblErrorMsgGrid.Text = Resources.Resource.LOIStartdateshouldbegreaterthanOrEqualLOIDate;//"LOI Start date should be greater than or equal to LOI Date ";
                                                    }
                                                }
                                                else
                                                {
                                                    lblErrorMsgGrid.Text = Resources.Resource.ContractSignDateShouldbelessthanorequaltoContractEndDate; //"Contract Start Date Should be greater or equal to contract sign Date";
                                                }
                                            }
                                            else
                                            {
                                                lblErrorMsgGrid.Text = Resources.Resource.ExpectSignDategreaterthanLOIDate;// "Expected Signing Date Should be greater than LOI Date";
                                            }
                                            //}
                                            //else
                                            //{
                                            //    lblErrorMsgGrid.Text = Resources.Resource.ContractSignDateGreatethanorequaltoLOIDate;// "Contract Sign Date Dhould be Greater than or equal to LOI Date";
                                            //}
                                        }
                                        else
                                        {
                                            lblErrorMsgGrid.Text = Resources.Resource.ContractEndDategreaterthanLOIStartDate;// "Contract End Date Should be greater than LOI Start Date";
                                        }
                                    }
                                    else
                                    {
                                        lblErrorMsgGrid.Text = Resources.Resource.ContractEndDategreaterthanContractStartDate;// "Contract End Date Should be greater than Contract Start Date";
                                    }
                                }
                                else
                                {
                                    lblErrorMsgGrid.Text = Resources.Resource.LOIEndDategreaterthanLOIStartDate;// "LOI End Date Should be greater than LOI Start Date";
                                }
                            }
                            else
                            {
                                lblErrorMsgGrid.Text = Resources.Resource.ContractStartDateEqualtoLOIStartDate;// "Contract Start Date Should be equal to LOI Start Date";
                            }
                            //}
                            //else
                            //{
                            //    lblErrorMsgGrid.Text = Resources.Resource.ContractPaperFieldCannotBeLeftBlank;//"Contracrt paper field cannot be left blank";
                            //    btnAuthorize.Visible = false;

                            //}
                        }
                        else
                        {
                            lblErrorMsgGrid.Text = Resources.Resource.LOIfieldscannotbeleftblank;
                            btnAuthorize.Visible = false;
                        }
                    }
                    else
                    {
                        lblErrorMsgGrid.Text = Resources.Resource.Allfieldsareleftblank;
                        btnAuthorize.Visible = false;
                    }
                }
                else
                {
                    lblErrorMsgGrid.Text = Resources.Resource.PleaseinputWithEffectiveFromDate;
                }
            }
            else
            {
                if ((txtDeliveryDate.Text != "" || txtExpectedSignDate.Text != "" || txtIssuingAuthority.Text != "" || txtLOIDate.Text != "" || txtLOIEndDate.Text != "" || txtLOIStartDate.Text != "" || txtDeliveryTo.Text != "" || txtContractEndDate.Text != "" || txtContractReviewDate.Text != "" || txtContractSignDate.Text != "" || txtContractStartDate.Text != "" || txtManualContractNo.Text != "" || txtClientSigningAuthority.Text != "" || txtDesignationAuthority.Text != ""))
                {
                    if ((txtDeliveryDate.Text != "" && txtExpectedSignDate.Text != "" && txtIssuingAuthority.Text != "" && txtLOIDate.Text != "" && txtLOIEndDate.Text != "" && txtLOIStartDate.Text != "" && txtDeliveryTo.Text != "") || (txtDeliveryDate.Text == "" && txtExpectedSignDate.Text == "" && txtIssuingAuthority.Text == "" && txtLOIDate.Text == "" && txtLOIEndDate.Text == "" && txtLOIStartDate.Text == "" && txtDeliveryTo.Text == ""))
                    {
                        //if ((txtContractEndDate.Text != "" && txtContractSignDate.Text != "" && txtContractStartDate.Text != ""))// && txtManualContractNo.Text != "" && txtClientSigningAuthority.Text != "" && txtDesignationAuthority.Text != "") || (txtContractEndDate.Text == "" && txtContractSignDate.Text == "" && txtContractStartDate.Text == "" && txtManualContractNo.Text == "" && txtClientSigningAuthority.Text == "" && txtDesignationAuthority.Text == ""))
                        //{
                        if (CompareEqualTO(txtContractStartDate.Text, txtLOIStartDate.Text) == true)
                        {
                            if (CompareGreaterThan(txtLOIEndDate.Text, txtLOIStartDate.Text) == true)
                            {
                                if (CompareGreaterThan(txtContractEndDate.Text, txtContractStartDate.Text) == true)
                                {
                                    if (CompareGreaterThan(txtContractEndDate.Text, txtLOIStartDate.Text) == true)
                                    {
                                        //if (CompareGreaterThan(txtContractSignDate.Text, txtLOIDate.Text) == true)
                                        //if (CompareEqualTO(txtContractSignDate.Text, txtLOIStartDate.Text) == true)
                                        //{
                                        if (CompareGreaterThan(txtExpectedSignDate.Text, txtLOIDate.Text) == true)
                                        {

                                            if (CompareGreaterThanOrEqualTO(txtContractEndDate.Text, txtContractSignDate.Text) == true)
                                            {
                                                if (CompareGreaterThanOrEqualTO(txtLOIStartDate.Text, txtLOIDate.Text) == true)
                                                {
                                                    if (lblStatus.Text == Resources.Resource.Authorized)
                                                    {
                                                        lblStatus.Text = strStatusAuthorized;
                                                    }
                                                    else if (lblStatus.Text == Resources.Resource.Amend)
                                                    {
                                                        lblStatus.Text = strStatusAmend;
                                                    }
                                                    else if (lblStatus.Text == Resources.Resource.Fresh)
                                                    {
                                                        lblStatus.Text = strStatusFresh;
                                                    }
                                                    else if (lblStatus.Text == Resources.Resource.ShortClosed)//Resources.Resource.Fresh)
                                                    {
                                                        lblStatus.Text = strStatusShortClosed;
                                                    }
                                                    /*V1.3*/
                                                    ds = objSales.ContractMasterUpdate(txtClientCode.Text,
                                                                                          txtContractNumber.Text,
                                                                                          int.Parse(
                                                                                              txtAmendmentNo.Text),
                                                                                          txtClientSigningAuthority.Text.TrimStart().TrimEnd(),
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtContractEndDate
                                                                                                      .Text))),
                                                                                                      (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtContractReviewDate
                                                                                                      .Text))),
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtContractSignDate
                                                                                                      .Text))),
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtContractStartDate
                                                                                                      .Text))),
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtDeliveryDate.
                                                                                                      Text))),
                                                                                          txtDeliveryTo.Text,
                                                                                          txtDesignationAuthority.Text.TrimStart().TrimEnd(),
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtExpectedSignDate
                                                                                                      .Text))),
                                                                                          txtIssuingAuthority.Text,
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtLOIDate.Text))),
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtLOIEndDate.Text))),
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtLOIStartDate.
                                                                                                      Text))),
                                                                                          txtManualContractNo.Text,
                                                                                          BaseUserID,
                                                                                          BaseLocationAutoID,
                                                                                          lblStatus.Text,
                                                                                          (DateFormat(
                                                                                              CheckDateNull(
                                                                                                  txtWEF.Text))),
                                                                                          float.Parse(
                                                                                              txtContractValue.Text),
                                                                                          cbContractPaperDelivered.
                                                                                              Checked,
                                                                                          txtContractAlert.Text,
                                                                                          txtNoticePeriodDaysToTerminate.Text,
                                                                                        txtTotalWarrantyAmount.Text,
                                                                                        txtRenewalInMonths.Text,
                                                                                        txtClientNoticeToRenewalInDays.Text,
                                                                                        txtInsurance.Text,
                                                                                        cbIsAutoRenewal.Checked,
                                                                                        cbIsLimitedWarranty.Checked,
                                                                                        cbIsScanCopyExists.Checked,
                                                                                        cbIfWeCanTerminate.Checked);
                                                    hfContractNumber.Value = txtContractNumber.Text;

                                                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
                                                    {
                                                        FillgvLOIReceived();
                                                        FillDetails(int.Parse(txtAmendmentNo.Text));
                                                        DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                                    }
                                                    else
                                                    {
                                                        DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                                        FillgvLOIReceived();
                                                        FillDetails(int.Parse(txtAmendmentNo.Text));

                                                        HideButtonBasedOnStatus();
                                                        DisableFields();
                                                        txtManualContractNo.Enabled = true;
                                                        txtClientSigningAuthority.Enabled = true;
                                                        txtDesignationAuthority.Enabled = true;

                                                        txtNoticePeriodDaysToTerminate.Enabled = true;
                                                        txtTotalWarrantyAmount.Enabled = true;
                                                        txtRenewalInMonths.Enabled = true;
                                                        txtClientNoticeToRenewalInDays.Enabled = true;
                                                        txtInsurance.Enabled = true;
                                                        cbIsAutoRenewal.Enabled = true;
                                                        cbIsLimitedWarranty.Enabled = true;
                                                        cbIsScanCopyExists.Enabled = true;
                                                        cbIfWeCanTerminate.Enabled = true;


                                                    }

                                                }
                                                else
                                                {
                                                    lblErrorMsgGrid.Text = Resources.Resource.LOIStartdateshouldbegreaterthanOrEqualLOIDate;//"LOI Start date should be greater than or equal to LOI Date ";
                                                }
                                            }
                                            else
                                            {
                                                lblErrorMsgGrid.Text = Resources.Resource.ContractSignDateShouldbelessthanorequaltoContractEndDate;//"Contract Start Date Should be greater than or equal to contract sign Date";
                                            }
                                        }
                                        else
                                        {
                                            lblErrorMsgGrid.Text = Resources.Resource.ExpectSignDategreaterthanLOIDate;// "Expected Signing Date Should be greater than LOI Date";
                                        }
                                        //}
                                        //else
                                        //{
                                        //    lblErrorMsgGrid.Text = Resources.Resource.ContractSignDateGreatethanorequaltoLOIDate;// "Contract Sign Date Dhould be Greater than or equal to LOI Date";
                                        //}
                                    }
                                    else
                                    {
                                        lblErrorMsgGrid.Text = Resources.Resource.ContractEndDategreaterthanLOIStartDate;// "Contract End Date Should be greater than LOI Start Date";
                                    }
                                }
                                else
                                {
                                    lblErrorMsgGrid.Text = Resources.Resource.ContractEndDategreaterthanContractStartDate;// "Contract End Date Should be greater than Contract Start Date";
                                }
                            }
                            else
                            {
                                lblErrorMsgGrid.Text = Resources.Resource.LOIEndDategreaterthanLOIStartDate;// "LOI End Date Should be greater than LOI Start Date";
                            }
                        }
                        else
                        {
                            lblErrorMsgGrid.Text = Resources.Resource.ContractStartDateEqualtoLOIStartDate;// "Contract Start Date Should be equal to LOI Start Date";
                        }
                        //}
                        //else
                        //{
                        //    lblErrorMsgGrid.Text = Resources.Resource.ContractPaperFieldCannotBeLeftBlank;//"Contracrt paper field cannot be left blank";
                        //    btnAuthorize.Visible = false;

                        //}
                    }
                    else
                    {
                        lblErrorMsgGrid.Text = Resources.Resource.LOIfieldscannotbeleftblank;//"LOI fields cannot be left blank";
                        btnAuthorize.Visible = false;
                    }
                }
                else
                {
                    lblErrorMsgGrid.Text = Resources.Resource.Allfieldsareleftblank;//"All fields are left blank";
                    btnAuthorize.Visible = false;
                }
            }
        }
        else
        {
            lblErrorMsgGrid.Text = "Date Cannot be less Than " + HFOldContractEndDate.Value;
        }


        if (cbContractPaperDelivered.Checked)
        {
            EnableContractFields();
        }
        else
        {
            DisableContractFields();
        }
        up1.Update();
    }
    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        EnableFields();
        btnUpdate.Visible = true;
        btnEdit.Visible = false;
        btnAddNew.Visible = false;
        btnAuthorize.Visible = false;
        btnAmend.Visible = false;
        btnDelete.Visible = false;
       // btnCancel.Visible = true;
        btnShortClose.Visible = false;
    }
    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        //To Avoid Validation Control 
        if (cbContractPaperDelivered.Checked)
        {
            EnableMandatoryField();
        }
        else
        {
            DisableMandatoryField();
        }

        string s = hfContractNumber.Value;// = txtContractNumber.Text;   
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        int flag = 0;
        if (txtContractValue.Text == "")
        {
            txtContractValue.Text = GetValueAsPerSystemParameters("0.000000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
        }
        if (txtContractStartDate.Text != "" && txtContractEndDate.Text != "")
        {
            if (CompareGreaterThanOrEqualTO(txtWEF.Text, txtContractStartDate.Text) == true && CompareGreaterThan(txtContractEndDate.Text, txtWEF.Text) == true)
            {
                flag = 1;
            }
            else
            {
                flag = 0;
            }
        }
        else
        {
            if (CompareGreaterThanOrEqualTO(txtWEF.Text, txtLOIDate.Text) == true && CompareGreaterThan(txtLOIEndDate.Text, txtWEF.Text) == true)
            {
                flag = 1;
            }
            else
            {
                flag = 0;
            }
        }
        if (flag == 1)
        {
            // ds = objSales.blContractMaster_Update(txtClientCode.Text, txtContractNumber.Text, int.Parse(txtAmendmentNo.Text), txtClientSigningAuthority.Text, (DateFormat(CheckDateNull(txtContractEndDate.Text))), (DateFormat(CheckDateNull(txtContractSignDate.Text))), (DateFormat(CheckDateNull(txtContractStartDate.Text))), (DateFormat(CheckDateNull(txtDeliveryDate.Text))), txtDeliveryTo.Text, txtDesignationAuthority.Text, (DateFormat(CheckDateNull(txtExpectedSignDate.Text))), txtIssuingAuthority.Text, (DateFormat(CheckDateNull(txtLOIDate.Text))), (DateFormat(CheckDateNull(txtLOIEndDate.Text))), (DateFormat(CheckDateNull(txtLOIStartDate.Text))), txtManualContractNo.Text, BaseUserID, BaseLocationAutoID, "AUTHORIZED", (DateFormat(CheckDateNull(txtWEF.Text))), float.Parse(txtContractValue.Text), cbContractPaperDelivered.Checked);
            ds = objSales.ContractMasterAuthorized(txtClientCode.Text, txtContractNumber.Text, int.Parse(txtAmendmentNo.Text), BaseUserID, BaseLocationAutoID, "AUTHORIZED");
            if (txtContractNumber.Text != "")
            {
                hfContractNumber.Value = txtContractNumber.Text;
            }
            if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 57)
            {
                DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            // Bug # - ID 4213:Duplicate SO line can be made if contract Date is increased
            else if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 3)
            {
                DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                lblErrorMsgGrid.Text = lblErrorMsgGrid.Text+ " - " + Resources.Resource.SONo + ":" + ds.Tables[0].Rows[0]["Comment"].ToString();
            } //end    
            else
            {
                FillDetails(int.Parse(txtAmendmentNo.Text));
                DisableFields();

                btnDelete.Visible = false;
                HideButtonBasedOnStatus();
            }
        }
        else if (flag == 0)
        {
            if (((CompareGreaterThan(txtContractStartDate.Text, txtWEF.Text) == true) || (CompareGreaterThan(txtWEF.Text, txtContractEndDate.Text)) == true) && (txtContractStartDate.Text != "" && txtContractEndDate.Text != ""))
            {
                lblErrorMsgGrid.Text = Resources.Resource.WithEffectFromDatebebetweenContractSignandEndDate;// "With Effective From Date Should be between Contract Sign date and Contract End Date";
            }
            else if ((CompareGreaterThan(txtLOIDate.Text, txtWEF.Text) == true && CompareGreaterThan(txtLOIEndDate.Text, txtWEF.Text) == true) && (txtLOIEndDate.Text != "" && txtLOIDate.Text != ""))
            {
                lblErrorMsgGrid.Text = Resources.Resource.WithEffectFromDatebegreaterthanLOIdate;// "With Effective From Date Should be greater than LOI date";
            }
        }
        // up1.Update(); //Manish 05/04/2013 
    }
    /// <summary>
    /// Handles the Click event of the btnAmend control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnAmend_Click(object sender, EventArgs e)
    {



        if (txtWEF.Text != "")
        {
            int AmendmentNumber = int.Parse(txtAmendmentNo.Text) + 1;
            DataSet ds = new DataSet();
            BL.Sales objSales = new BL.Sales();
            EnableFields();


            int flag = 0;
            imgWEF.Visible = true;
            if (txtContractValue.Text == "")
            {
                txtContractValue.Text = GetValueAsPerSystemParameters("0.000000000", int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }
            if (txtContractStartDate.Text != "" && txtContractEndDate.Text != "")
            {
                if (CompareGreaterThanOrEqualTO(txtWEF.Text, txtContractStartDate.Text) == true && CompareGreaterThan(txtContractEndDate.Text, txtWEF.Text) == true)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }
            else
            {
                if (CompareGreaterThanOrEqualTO(txtWEF.Text, txtLOIDate.Text) == true && CompareGreaterThan(txtLOIEndDate.Text, txtWEF.Text) == true)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }
            if (txtNoticePeriodDaysToTerminate.Text == "")
            {
                txtNoticePeriodDaysToTerminate.Text = @"0";
            }
            if (txtTotalWarrantyAmount.Text == "")
            {
                txtTotalWarrantyAmount.Text = @"0";
            }
            if (txtRenewalInMonths.Text == "")
            {
                txtRenewalInMonths.Text = @"0";
            }
            if (txtClientNoticeToRenewalInDays.Text == "")
            {
                txtClientNoticeToRenewalInDays.Text = @"0";
            }
            if (flag == 1)
            {
                ds = objSales.ContractMasterInsertAmendRecord(AmendmentNumber, txtIssuingAuthority.Text,
                                                                 DateFormat(CheckDateNull(txtDeliveryDate.Text)),
                                                                 txtDeliveryTo.Text,
                                                                 DateFormat(CheckDateNull(txtExpectedSignDate.Text)),
                                                                 DateFormat(CheckDateNull(txtLOIDate.Text)),
                                                                 DateFormat(CheckDateNull(txtLOIStartDate.Text)),
                                                                 DateFormat(CheckDateNull(txtLOIEndDate.Text)),
                                                                 txtManualContractNo.Text,
                                                                 txtClientSigningAuthority.Text,
                                                                 txtDesignationAuthority.Text,
                                                                 DateFormat(CheckDateNull(txtContractSignDate.Text)),
                                                                 DateFormat(CheckDateNull(txtContractStartDate.Text)),
                                                                 DateFormat(CheckDateNull(txtContractEndDate.Text)),
                                                                 DateFormat(CheckDateNull(txtContractReviewDate.Text)),
                                                                 BaseUserID, txtClientCode.Text, BaseLocationAutoID,
                                                                 DateFormat(CheckDateNull(txtWEF.Text)), "AMEND",
                                                                 txtContractNumber.Text,
                                                                 float.Parse(txtContractValue.Text),
                                                                 cbContractPaperDelivered.Checked,
                                                                 txtNoticePeriodDaysToTerminate.Text,
                                                                    txtTotalWarrantyAmount.Text,
                                                                    txtRenewalInMonths.Text,
                                                                    txtClientNoticeToRenewalInDays.Text,
                                                                    txtInsurance.Text,
                                                                    cbIsAutoRenewal.Checked,
                                                                    cbIsLimitedWarranty.Checked,
                                                                    cbIsScanCopyExists.Checked,
                                                                    cbIfWeCanTerminate.Checked);
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    FillDetails(AmendmentNumber);
                    hfMaxAmendmentNumber.Value = AmendmentNumber.ToString();
                    //FillgvLOIReceived();
                    FillddlAmendmentNumber(txtContractNumber.Text);
                    HideButtonBasedOnStatus();
                    DisableFields();
                    txtManualContractNo.Enabled = true;
                    txtClientSigningAuthority.Enabled = true;
                    txtDesignationAuthority.Enabled = true;
                    txtContractEndDate.Enabled = true;
                    imgContractEndDate.Visible = true;

                    txtContractReviewDate.Enabled = true;
                    imgContractReviewDate.Visible = true;

                    txtNoticePeriodDaysToTerminate.Enabled = true;
                    txtTotalWarrantyAmount.Enabled = true;
                    txtRenewalInMonths.Enabled = true;
                    txtClientNoticeToRenewalInDays.Enabled = true;
                    txtInsurance.Enabled = true;
                    cbIsAutoRenewal.Enabled = true;
                    cbIsLimitedWarranty.Enabled = true;
                    cbIsScanCopyExists.Enabled = true;
                    cbIfWeCanTerminate.Enabled = true;


                    up1.Update();
                }
            }

            else if (flag == 0)
            {
                if (((CompareGreaterThan(txtContractStartDate.Text, txtWEF.Text) == true) || (CompareGreaterThan(txtWEF.Text, txtContractEndDate.Text)) == true) && (txtContractStartDate.Text != "" && txtContractEndDate.Text != ""))
                {
                    lblErrorMsgGrid.Text = Resources.Resource.WithEffectFromDatebebetweenContractSignandEndDate;// "With Effective From Date Should be between Contract Sign date and Contract End Date";
                }
                else if ((CompareGreaterThan(txtLOIDate.Text, txtWEF.Text) == true && CompareGreaterThan(txtLOIEndDate.Text, txtWEF.Text) == true) && (txtLOIEndDate.Text != "" && txtLOIDate.Text != ""))
                {
                    lblErrorMsgGrid.Text = Resources.Resource.WithEffectFromDatebegreaterthanLOIdate;// "With Effective From Date Should be greater than LOI date";
                }
            }




        }
        else
        {
            lblErrorMsgGrid.Text = Resources.Resource.PleaseinputWithEffectiveFromDate;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnShortClose control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnShortClose_Click(object sender, EventArgs e)
    {
        lblErrorMsgGrid.Text = string.Empty;        // Added For Bug #2496
        if (Label25.Visible == false && txtSCD.Visible == false && imgSCD.Visible == false)
        {
            Label25.Visible = true;
            txtSCD.Visible = true;
            imgSCD.Visible = true;
        }

        if (txtSCD.Text != "")
        {
            // Added for Bug #2496
            if (CompareGreaterThan(txtSCD.Text, txtContractEndDate.Text))     
            {
                lblErrorMsgGrid.Text =  Resources.Resource.ShortCloseDateValidation ;
                return;
            }
            //End
            if (CompareGreaterThan(txtContractStartDate.Text, txtSCD.Text) == true)
            {
                lblErrorMsgGrid.Text =Resources.Resource.ContractStartDateValidation;
                return;
            }
            int AmendmentNumber = int.Parse(txtAmendmentNo.Text) + 1;
            BL.Sales objSales = new BL.Sales();
            DataSet ds = new DataSet();
            txtWEF.Enabled = true;
            imgWEF.Visible = true;
            int flag;
            if (txtWEF.Text != "")
            {
                DataSet ds1 = new DataSet();
                BL.Sales objSales1 = new BL.Sales();
                ds1 = objSales1.IsSaleOrderExistsForContract(txtContractNumber.Text);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsgGrid.Text = "Sales Order Exist for this Contract Number";
                    return;
                }
                lblErrorMsgGrid.Text = "";
                if (txtContractStartDate.Text != "" && txtContractEndDate.Text != "")
                {
                    if (CompareGreaterThanOrEqualTO(txtWEF.Text, txtContractStartDate.Text) == true && CompareGreaterThan(txtContractEndDate.Text, txtWEF.Text) == true)
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
                else
                {
                    if (CompareGreaterThanOrEqualTO(txtWEF.Text, txtLOIDate.Text) == true && CompareGreaterThan(txtLOIEndDate.Text, txtWEF.Text) == true)
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;

                    }
                }
                if (flag == 1)
                {
                    if (lblStatus.Text == Resources.Resource.Authorized)
                    {

                        ds = objSales.ShortCloseContractMaster(AmendmentNumber, txtIssuingAuthority.Text, (DateFormat(CheckDateNull(txtDeliveryDate.Text))), txtDeliveryTo.Text, (DateFormat(CheckDateNull(txtExpectedSignDate.Text))), (DateFormat(CheckDateNull(txtLOIDate.Text))), (DateFormat(CheckDateNull(txtLOIStartDate.Text))), (DateFormat(CheckDateNull(txtLOIEndDate.Text))), txtManualContractNo.Text, txtClientSigningAuthority.Text, txtDesignationAuthority.Text, (DateFormat(CheckDateNull(txtContractStartDate.Text))), (DateFormat(CheckDateNull(txtContractStartDate.Text))), (DateFormat(CheckDateNull(txtContractEndDate.Text))), (DateFormat(CheckDateNull(txtContractReviewDate.Text))), BaseUserID, txtClientCode.Text, BaseLocationAutoID, (DateFormat(CheckDateNull(txtWEF.Text))), "SHORTCLOSED", txtContractNumber.Text, (DateFormat(CheckDateNull(txtSCD.Text))));
                        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                        {
                            FillDetails(int.Parse(txtAmendmentNo.Text));
                            DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            HideButtonBasedOnStatus();
                            lblStatus.Text = strStatusShortClosed;
                            FillgvLOIReceived();
                        }
                        else
                        {
                            DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                    }
                    else if (lblStatus.Text == Resources.Resource.Fresh || lblStatus.Text == Resources.Resource.Amend)
                    {
                        //V1.3
                        ds = objSales.ContractMasterUpdate(txtClientCode.Text, txtContractNumber.Text, int.Parse(txtAmendmentNo.Text), txtClientSigningAuthority.Text, (DateFormat(CheckDateNull(txtContractEndDate.Text))), (DateFormat(CheckDateNull(txtContractReviewDate.Text))), (DateFormat(CheckDateNull(txtContractSignDate.Text))), (DateFormat(CheckDateNull(txtContractStartDate.Text))), (DateFormat(CheckDateNull(txtDeliveryDate.Text))), txtDeliveryTo.Text, txtDesignationAuthority.Text, (DateFormat(CheckDateNull(txtExpectedSignDate.Text))), txtIssuingAuthority.Text, (DateFormat(CheckDateNull(txtLOIDate.Text))), (DateFormat(CheckDateNull(txtLOIEndDate.Text))), (DateFormat(CheckDateNull(txtLOIStartDate.Text))), txtManualContractNo.Text, BaseUserID, BaseLocationAutoID, "SHORTCLOSED", (DateFormat(CheckDateNull(txtWEF.Text))), float.Parse(txtContractValue.Text), cbContractPaperDelivered.Checked,
                            txtContractAlert.Text, txtNoticePeriodDaysToTerminate.Text,
                                                                    txtTotalWarrantyAmount.Text,
                                                                    txtRenewalInMonths.Text,
                                                                    txtClientNoticeToRenewalInDays.Text,
                                                                    txtInsurance.Text,
                                                                    cbIsAutoRenewal.Checked,
                                                                    cbIsLimitedWarranty.Checked,
                                                                    cbIsScanCopyExists.Checked,
                                                                    cbIfWeCanTerminate.Checked);
                        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                        {
                            FillDetails(int.Parse(txtAmendmentNo.Text));
                            DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            HideButtonBasedOnStatus();
                        }
                        else
                        {
                            DisplayMessage(lblErrorMsgGrid, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                    }
                }
                else
                {
                    if (((CompareGreaterThan(txtContractStartDate.Text, txtWEF.Text) == true) || (CompareGreaterThan(txtWEF.Text, txtContractEndDate.Text)) == true) && (txtContractStartDate.Text != "" && txtContractEndDate.Text != ""))
                    {
                        lblErrorMsgGrid.Text = Resources.Resource.WithEffectFromDatebebetweenContractSignandEndDate;// "With Effective From Date Should be between Contract Sign date and Contract End Date";
                    }
                    else if ((CompareGreaterThan(txtLOIDate.Text, txtWEF.Text) == true && CompareGreaterThan(txtLOIEndDate.Text, txtWEF.Text) == true) && (txtLOIEndDate.Text != "" && txtLOIDate.Text != ""))
                    {
                        lblErrorMsgGrid.Text = Resources.Resource.WithEffectFromDatebegreaterthanLOIdate;// "With Effective From Date Should be greater than LOI date";
                    }
                }
            }
            else
            {
                lblErrorMsgGrid.Text = Resources.Resource.PleaseinputWithEffectiveFromDate;//"Please input With Effective from Date";//Resources.Resource;
            }
        }
        else
        {
            lblErrorMsgGrid.Text = "Please Enter Short Close Date";
        }
    }


    #endregion

    #region Common Function for Dates
    /// <summary>
    /// Function to check whether date is null or not
    /// </summary>
    /// <param name="strDate">The string date.</param>
    /// <returns>System.String.</returns>
    private string CheckDateNull(string strDate)
    {
        if (strDate == "")
        {
            return @"01/01/1900";
        }
        else
        {
            return strDate;
        }
    }
    /// <summary>
    /// Function to find greater or equal date even if one date is null
    /// </summary>
    /// <param name="strDate1">The string date1.</param>
    /// <param name="strDate2">The string date2.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CompareGreaterThanOrEqualTO(string strDate1, string strDate2)
    {
        if (strDate1 == "" || strDate2 == "")
        {
            return true;
        }
        else if ((DateTime.Parse(DateFormat(strDate1)) >= (DateTime.Parse(DateFormat(strDate2)))))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Function to find equal date even if one date is null
    /// </summary>
    /// <param name="strDate1">The string date1.</param>
    /// <param name="strDate2">The string date2.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CompareEqualTO(string strDate1, string strDate2)
    {
        if (strDate1 == "" || strDate2 == "")
        {
            return true;
        }
        else if ((DateTime.Parse(DateFormat(strDate1)) == (DateTime.Parse(DateFormat(strDate2)))))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Function to find greater date even if one date is null
    /// </summary>
    /// <param name="strDate1">The string date1.</param>
    /// <param name="strDate2">The string date2.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CompareGreaterThan(string strDate1, string strDate2)
    {
        if (strDate1 == "" || strDate2 == "")
        {
            return true;
        }
        else if ((DateTime.Parse(DateFormat(strDate1)) > (DateTime.Parse(DateFormat(strDate2)))))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Function to Convert date to null if date=01/01/0001
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>System.String.</returns>
    private string ConvertDateToNull(string date)
    {
        string strDate = "01/01/1900";
        if (date == "")
        {
            date = strDate;
        }
        if ((DateTime.Parse(date)) == (DateTime.Parse(strDate)))
        {
            return null;
        }
        else
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(date);
            string formatedDate = dt.ToString("dd-MMM-yyyy");
            return formatedDate;
        }
    }
    #endregion

    #region [Common Function] Function Related To Sort GridView
    /// <summary>
    /// Gets or sets the grid view sort direction.
    /// </summary>
    /// <value>The grid view sort direction.</value>
    private SortDirection GridViewSortDirection
    {
        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }

    }
    /// <summary>
    /// Sorts the grid view.
    /// </summary>
    /// <param name="sortExpression">The sort expression.</param>
    /// <param name="direction">The direction.</param>
    /// <param name="dv">The dv.</param>
    /// <param name="strGridViewName">Name of the string grid view.</param>
    private void SortGridView(string sortExpression, string direction, DataView dv, GridView strGridViewName)
    {
        dv.Sort = sortExpression + ' ' + direction;
        strGridViewName.DataSource = dv;
        strGridViewName.DataBind();

    }
    #endregion

    /// <summary>
    /// Handles the CheckedChanged event of the cbContractPaperDelivered control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void cbContractPaperDelivered_CheckedChanged(object sender, EventArgs e)
    {
        if (cbContractPaperDelivered.Checked)
        {
            DivPanelContractPaperReceived.Visible = true;
            EnableContractFields();
        }
        else
        {
            DivPanelContractPaperReceived.Visible = false;
            txtContractSignDate.Text = "";
            txtContractStartDate.Text = "";
            txtContractEndDate.Text = "";
            txtContractReviewDate.Text = "";
            txtManualContractNo.Text = "";
            txtClientSigningAuthority.Text = "";
            txtDesignationAuthority.Text = "";
            txtContractValue.Text = "";
            txtContractAlert.Enabled = true;
            DisableContractFields();
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClient();
        txtClientCode.Text = ddlClient.SelectedItem.Value.ToString();
        ClientCode_ChangeEvent();
    }
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaID()
    {
        ListItem li = new ListItem();

        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();
        dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {

            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();
            li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlAreaID.Items.Insert(0, li);

        }
        if (ddlAreaID.Text == "")
        {
            li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlAreaID.Items.Add(li);
            ClearFields();
            lblStatus.Text = "";

        }

    }
    protected void txtContractStartDate_TextChanged(object sender, EventArgs e)
    {
        if (txtContractStartDate.Text != string.Empty)
        {
            txtContractReviewDate.Text = Convert.ToDateTime(txtContractStartDate.Text).AddMonths(12).ToString("dd-MMM-yyyy");
        }
        if (txtContractEndDate.Text != string.Empty && txtContractEndDate.Text != string.Empty && txtContractReviewDate.Text != string.Empty && Convert.ToDateTime(txtContractEndDate.Text) <= Convert.ToDateTime(txtContractReviewDate.Text))
        {
            txtContractReviewDate.Text = txtContractEndDate.Text;
        }
    }
    protected void txtContractEndDate_TextChanged(object sender, EventArgs e)
    {
        if (txtContractEndDate.Text != string.Empty && txtContractEndDate.Text != string.Empty && txtContractReviewDate.Text != string.Empty && Convert.ToDateTime(txtContractEndDate.Text) <= Convert.ToDateTime(txtContractReviewDate.Text))
        {
            txtContractReviewDate.Text = txtContractEndDate.Text;
        }
    }
    protected void txtContractReviewDate_TextChanged(object sender, EventArgs e)
    {
        if (txtContractEndDate.Text != string.Empty && txtContractEndDate.Text != string.Empty && txtContractReviewDate.Text != string.Empty && Convert.ToDateTime(txtContractEndDate.Text) <= Convert.ToDateTime(txtContractReviewDate.Text))
        {
            txtContractReviewDate.Text = txtContractEndDate.Text;
        }
    }
}
