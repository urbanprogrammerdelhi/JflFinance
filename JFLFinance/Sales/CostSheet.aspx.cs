// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="CostSheet.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_CostSheet.
/// </summary>
public partial class Sales_CostSheet : BasePage //System.Web.UI.Page
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

    #endregion

    #region Page Load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.CostSheet;
            //}
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.CostSheet + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                SetReadonlyProperty();
                SetValidationsTofloatFields();
                if (Request.QueryString["CostSheetNo"] != null && Request.QueryString["CostSheetNo"].ToString() != "0" && Request.QueryString["CostSheetNo"].ToString().Length > 0)
                {
                    txtCostSheetNo.Text = Request.QueryString["CostSheetNo"].ToString();
                    FillddlClient();
                    if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length > 0)
                    {
                        ddlClient.SelectedValue = Request.QueryString["ClientCode"].ToString();
                    }
                    FillddlCostSheetAmendNo();
                    ViewMode();
                }
                else
                {
                    txtCostSheetNo.Text = "";
                    FillddlClient();
                    if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length > 0)
                    {
                        ddlClient.SelectedValue = Request.QueryString["ClientCode"].ToString();
                    }
                    FillddlCostSheetAmendNo();
                    AddNewMode();
                }
                btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnGenerateCostSheetNo.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnAmend.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnAuthorize.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

    }
    /// <summary>
    /// Sets the readonly property.
    /// </summary>
    protected void SetReadonlyProperty()
    {
        txtCostSheetStatus.Attributes.Add("readonly", "readonly");
        txtCostSheetNo.Attributes.Add("readonly", "readonly");

        txtCostSheetDate.Attributes.Add("readonly", "readonly");
        hlCostSheetDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtCostSheetDate.ClientID.ToString() + "');";
        txtPreparedDate.Attributes.Add("readonly", "readonly");
        hlPreparedDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtPreparedDate.ClientID.ToString() + "');";
        txtVerifiedDate.Attributes.Add("readonly", "readonly");
        hlVerifiedDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtVerifiedDate.ClientID.ToString() + "');";
        txtApprovedDate.Attributes.Add("readonly", "readonly");
        hlApprovedDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtApprovedDate.ClientID.ToString() + "');";

        txtTotalequipmentCostyearly.Enabled = false;
        txtTotalAmount.Enabled = false;
        txtTotalAmountWithMargin.Enabled = false;

        txtTotalSellingPrice.Enabled = false;
        txtMinusCost.Enabled = false;
        txtGrossProfit.Enabled = false;
        txtGrossMargin.Enabled = false;
        txtContributionHead.Enabled = false;

        txtTotalSellingPriceTotal.Enabled = false;
        txtMinusCostTotal.Enabled = false;
        txtGrossProfitTotal.Enabled = false;
        txtGrossMarginTotal.Enabled = false;
        txtContributionHeadTotal.Enabled = false;
    }
    /// <summary>
    /// Sets the validations tofloat fields.
    /// </summary>
    protected void SetValidationsTofloatFields()
    {
        TextBoxFloadValidation(txtBankGuaranteeAmount);
        TextBoxFloadValidation(txtContractStampAmount);
        TextBoxFloadValidation(txtAirportFeeAmount);
        TextBoxFloadValidation(txtTotalequipmentCostyearly);
        TextBoxFloadValidation(txtOtherAdditionalCharges);
        TextBoxFloadValidation(txtTotalAmount);
        TextBoxFloadValidation(txtTotalAmountWithMargin);

        TextBoxFloadValidation(txtMarginPercentage);
        TextBoxFloadValidation(txtEquipmentRental);
        TextBoxFloadValidation(txtTotalSellingPrice);
        TextBoxFloadValidation(txtMinusCost);
        TextBoxFloadValidation(txtGrossProfit);
        TextBoxFloadValidation(txtGrossMargin);
        TextBoxFloadValidation(txtContributionHead);

        TextBoxFloadValidation(txtEquipmentRentalTotal);
        TextBoxFloadValidation(txtTotalSellingPriceTotal);
        TextBoxFloadValidation(txtMinusCostTotal);
        TextBoxFloadValidation(txtGrossProfitTotal);
        TextBoxFloadValidation(txtGrossMarginTotal);
        TextBoxFloadValidation(txtContributionHeadTotal);
    }
    #endregion

    #region Controles Binding
    /// <summary>
    /// Gets the selected cost sheet.
    /// </summary>
    protected void GetSelectedCostSheet()
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = new DataSet();

        string strCostSheetAmendNO;
        if (ddlCostSheetAmendNo.Items.Count == 0)
        {
            strCostSheetAmendNO = "-1";
        }
        else
        {
            strCostSheetAmendNO = ddlCostSheetAmendNo.SelectedItem.Value.ToString();
        }
        ds = objsales.CostSheetHeaderGet(BaseLocationAutoID, txtCostSheetNo.Text, strCostSheetAmendNO);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            FillControles(ds);
            FillgvCostSheetService();
            FillgvCostSheetItem();
        }
        else
        {
            ClearControles();
        }
    }
    /// <summary>
    /// Fills the controles.
    /// </summary>
    /// <param name="ds">The ds.</param>
    protected void FillControles(DataSet ds)
    {
        txtCostSheetDate.Text = DateFormat(ds.Tables[0].Rows[0]["CostSheetDate"].ToString()).ToString();
        txtCostSheetStatus.Text = ds.Tables[0].Rows[0]["CostSheetStatus"].ToString();
        txtPreparedBy.Text = ds.Tables[0].Rows[0]["PreparedBy"].ToString();
        txtPreparedDate.Text = DateFormat(ds.Tables[0].Rows[0]["PreparedDate"].ToString()).ToString();
        txtApprovedBy.Text = ds.Tables[0].Rows[0]["ApprovedBy"].ToString();
        txtApprovedDate.Text = DateFormat(ds.Tables[0].Rows[0]["ApprovedDate"].ToString()).ToString();
        txtVerifiedBy.Text = ds.Tables[0].Rows[0]["VarifedBy"].ToString();
        txtVerifiedDate.Text = DateFormat(ds.Tables[0].Rows[0]["VerifiedDate"].ToString()).ToString();

        txtMarginPercentage.Text = ds.Tables[0].Rows[0]["Margin"].ToString();
        txtBankGuaranteeAmount.Text = ds.Tables[0].Rows[0]["BankGuaranteeAmount"].ToString();
        txtContractStampAmount.Text = ds.Tables[0].Rows[0]["ContractStampAmount"].ToString();
        txtAirportFeeAmount.Text = ds.Tables[0].Rows[0]["AirportFeeAmt"].ToString();
        txtTotalequipmentCostyearly.Text = ds.Tables[0].Rows[0]["TotalEquipmentCostYearly"].ToString();
        txtOtherAdditionalCharges.Text = ds.Tables[0].Rows[0]["OtherAddChargesMonthly"].ToString();
        txtTotalAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
        txtTotalAmountWithMargin.Text = ds.Tables[0].Rows[0]["TotalAmountWithMargin"].ToString();

        txtEquipmentRental.Text = ds.Tables[0].Rows[0]["EquipmentRentalActual"].ToString();
        txtEquipmentRentalTotal.Text = ds.Tables[0].Rows[0]["EquipmentRentalAPM"].ToString();
        txtTotalSellingPrice.Text = ds.Tables[0].Rows[0]["TotalSellingPriceActual"].ToString();
        txtTotalSellingPriceTotal.Text = ds.Tables[0].Rows[0]["TotalSellingPriceAPM"].ToString();
        txtMinusCost.Text = ds.Tables[0].Rows[0]["MinusCostActual"].ToString();
        txtMinusCostTotal.Text = ds.Tables[0].Rows[0]["MinusCostAPM"].ToString();
        txtGrossProfit.Text = ds.Tables[0].Rows[0]["GrossProfitActual"].ToString();
        txtGrossProfitTotal.Text = ds.Tables[0].Rows[0]["GROSSProfitAPM"].ToString();
        txtGrossMargin.Text = ds.Tables[0].Rows[0]["GrossMarginActual"].ToString();
        txtGrossMarginTotal.Text = ds.Tables[0].Rows[0]["GrossMarginAPM"].ToString();
        txtContributionHead.Text = ds.Tables[0].Rows[0]["ContributionPerHeadActual"].ToString();
        txtContributionHeadTotal.Text = ds.Tables[0].Rows[0]["ContributionPerHeadAPM"].ToString();
    }
    /// <summary>
    /// Clears the controles.
    /// </summary>
    protected void ClearControles()
    {
        txtCostSheetDate.Text = "";
        txtCostSheetStatus.Text = "";
        txtPreparedBy.Text = "";
        txtPreparedDate.Text = "";
        txtApprovedBy.Text = "";
        txtApprovedDate.Text = "";
        txtVerifiedBy.Text = "";
        txtVerifiedDate.Text = "";

        txtMarginPercentage.Text = "";
        txtBankGuaranteeAmount.Text = "";
        txtContractStampAmount.Text = "";
        txtAirportFeeAmount.Text = "";
        txtTotalequipmentCostyearly.Text = "";
        txtOtherAdditionalCharges.Text = "";
        txtTotalAmount.Text = "";
        txtTotalAmountWithMargin.Text = "";

        txtEquipmentRental.Text = "";
        txtEquipmentRentalTotal.Text = "";
        txtTotalSellingPrice.Text = "";
        txtTotalSellingPriceTotal.Text = "";
        txtMinusCost.Text = "";
        txtMinusCostTotal.Text = "";
        txtGrossProfit.Text = "";
        txtGrossProfitTotal.Text = "";
        txtGrossMargin.Text = "";
        txtGrossMarginTotal.Text = "";
        txtContributionHead.Text = "";
        txtContributionHeadTotal.Text = "";
    }
    /// <summary>
    /// Fillddls the cost sheet amend no.
    /// </summary>
    protected void FillddlCostSheetAmendNo()
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objsales.CostSheetAmendNoGet(BaseLocationAutoID, txtCostSheetNo.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlCostSheetAmendNo.DataSource = ds.Tables[0];
            ddlCostSheetAmendNo.DataTextField = "CostSheetAmendmentNo";
            ddlCostSheetAmendNo.DataValueField = "CostSheetAmendmentNo";
            ddlCostSheetAmendNo.DataBind();
            ddlCostSheetAmendNo.SelectedIndex = 0;
            hfIsMAXCostSheetAmendNo.Value = "MAX";
            GetSelectedCostSheet();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlCostSheetAmendNo.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);
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
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    #endregion

    #region Grid View Services
    #region GridView Controles events
    /// <summary>
    /// Fillgvs the cost sheet service.
    /// </summary>
    protected void FillgvCostSheetService()
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objsales.CostSheetServicesGet(BaseLocationAutoID, txtCostSheetNo.Text, ddlCostSheetAmendNo.SelectedItem.Value.ToString());
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                //to fix empety gridview

                if (dt.Rows.Count == 0)
                {
                    dtflag = 0;
                    dt.Rows.Add(dt.NewRow());
                    gvCostSheetService.DataKeyNames = new string[] { "LocationAutoId", "CostSheetNo", "CostSheetAmendmentNo", "CostSheetLineNo" };
                    gvCostSheetService.DataSource = dt;
                    gvCostSheetService.DataBind();
                    if (dtflag == 0)//to fix empety gridview
                    {
                        gvCostSheetService.Rows[0].Visible = false;
                    }
                }
                else if (dt.Rows.Count > 0)
                {
                    gvCostSheetService.DataKeyNames = new string[] { "LocationAutoId", "CostSheetNo", "CostSheetAmendmentNo", "CostSheetLineNo" };
                    gvCostSheetService.DataSource = dt;
                    gvCostSheetService.DataBind();
                }
            }
        }
    }
    /// <summary>
    /// Fillddlgvs the so rank.
    /// </summary>
    /// <param name="ddlgvSORank">The DDLGV so rank.</param>
    protected void FillddlgvSORank(DropDownList ddlgvSORank)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.SaleOrderRankGet(BaseCompanyCode.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlgvSORank.DataSource = ds.Tables[0];
            ddlgvSORank.DataValueField = "SORank";
            ddlgvSORank.DataTextField = "SORank";
            ddlgvSORank.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlgvSORank.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillddlgvs the uom.
    /// </summary>
    /// <param name="ddlgvUOM">The DDLGV uom.</param>
    protected void FillddlgvUOM(DropDownList ddlgvUOM)
    {
        DataSet ds = new DataSet();
        BL.Misc objMisc = new BL.Misc();
        ds = objMisc.QuickCodeUomGet(BaseCompanyCode.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlgvUOM.DataSource = ds.Tables[0];
            ddlgvUOM.DataValueField = "ItemDesc";
            ddlgvUOM.DataTextField = "ItemDesc";
            ddlgvUOM.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlgvUOM.Items.Add(li);
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChangedFooter event of the ddlgvSORank control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvSORank_SelectedIndexChangedFooter(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DropDownList ddlgvSORank = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)ddlgvSORank.NamingContainer;
        TextBox txtDesignationDesc = (TextBox)gvCostSheetService.FooterRow.FindControl("txtDesignationDesc");
        txtDesignationDesc.Text = ddlgvSORank.SelectedItem.Text;

        ToolkitScriptManager1.SetFocus(txtDesignationDesc);
    }
    /// <summary>
    /// Handles the SelectedIndexChangedEdit event of the ddlgvSORank control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvSORank_SelectedIndexChangedEdit(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DropDownList ddlgvSORank = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)ddlgvSORank.NamingContainer;
        TextBox txtDesignationDesc = (TextBox)gvCostSheetService.Rows[gvRow.RowIndex].FindControl("txtDesignationDesc");
        txtDesignationDesc.Text = ddlgvSORank.SelectedItem.Text;

        ToolkitScriptManager1.SetFocus(txtDesignationDesc);
    }
    /// <summary>
    /// Handles the SelectedIndexChangedFooter event of the ddlgvUOM control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvUOM_SelectedIndexChangedFooter(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the SelectedIndexChangedEdit event of the ddlgvUOM control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvUOM_SelectedIndexChangedEdit(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Texts the box fload validation.
    /// </summary>
    /// <param name="ObjTextBox">The object text box.</param>
    protected void TextBoxFloadValidation(TextBox ObjTextBox)
    {
        ObjTextBox.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
        ObjTextBox.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
    }
    #endregion
    #region Grid View services Events
    /// <summary>
    /// Handles the RowDataBound event of the gvCostSheetService control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetService_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false)
        {
            gvCostSheetService.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            //Check Delete Access AND //Delete button will not show when the Cost Sheet not in Fresh or amend mode
            if (IsDeleteAccess == false || (txtCostSheetStatus.Text != Resources.Resource.Amend && txtCostSheetStatus.Text != Resources.Resource.Fresh))
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
                    ImgbtnDelete.Visible = true;
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }

            //Check Modify Access AND //Edit button will not show when the Cost Sheet not in Fresh or amend mode
            if (IsModifyAccess == false || (txtCostSheetStatus.Text != Resources.Resource.Amend && txtCostSheetStatus.Text != Resources.Resource.Fresh))
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
                DropDownList ddlgvSORank = (DropDownList)e.Row.FindControl("ddlgvSORank");
                HiddenField hfSORank = (HiddenField)e.Row.FindControl("hfSORank");
                if (ddlgvSORank != null && hfSORank != null)
                {
                    FillddlgvSORank(ddlgvSORank);
                    ddlgvSORank.SelectedIndex = ddlgvSORank.Items.IndexOf(ddlgvSORank.Items.FindByValue(hfSORank.Value.ToString()));
                }
                DropDownList ddlgvUOM = (DropDownList)e.Row.FindControl("ddlgvUOM");
                HiddenField hfUOM = (HiddenField)e.Row.FindControl("hfUOM");
                if (ddlgvUOM != null && hfUOM != null)
                {
                    FillddlgvUOM(ddlgvUOM);
                    ddlgvUOM.SelectedIndex = ddlgvUOM.Items.IndexOf(ddlgvUOM.Items.FindByValue(hfUOM.Value.ToString()));
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            //Check Write Access AND //Footer will not show when the Cost Sheet not in Fresh or amend mode
            if (IsWriteAccess == false || (txtCostSheetStatus.Text != Resources.Resource.Amend && txtCostSheetStatus.Text != Resources.Resource.Fresh))
            {
                gvCostSheetService.ShowFooter = false;
            }
            else
            {
                gvCostSheetService.ShowFooter = true;
                
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";}

                DropDownList ddlgvSORank = (DropDownList)e.Row.FindControl("ddlgvSORank");
                if (ddlgvSORank != null)
                {FillddlgvSORank(ddlgvSORank);}

                DropDownList ddlgvUOM = (DropDownList)e.Row.FindControl("ddlgvUOM");
                if (ddlgvUOM != null)
                {FillddlgvUOM(ddlgvUOM);}

                TextBox txtDesignationDesc = (TextBox)e.Row.FindControl("txtDesignationDesc");
                if (txtDesignationDesc != null)
                { txtDesignationDesc.Attributes.Add("readonly", "readonly"); }

                if (ddlgvSORank != null && txtDesignationDesc != null)
                { txtDesignationDesc.Text = ddlgvSORank.SelectedItem.Text;}
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtDesignationDesc = (TextBox)e.Row.FindControl("txtDesignationDesc");
            if (txtDesignationDesc != null){ txtDesignationDesc.Attributes.Add("readonly", "readonly"); }

            TextBox txtNumberOfPerson = (TextBox)e.Row.FindControl("txtNumberOfPerson");
            if (txtNumberOfPerson != null){ TextBoxFloadValidation(txtNumberOfPerson); }

            TextBox txtWorkingDay = (TextBox)e.Row.FindControl("txtWorkingDay");
            if (txtWorkingDay != null) { TextBoxFloadValidation(txtWorkingDay); }

            TextBox txtNormalHours = (TextBox)e.Row.FindControl("txtNormalHours"); 
            if (txtNormalHours != null) { TextBoxFloadValidation(txtNormalHours); }

            TextBox txtOTHours = (TextBox)e.Row.FindControl("txtOTHours"); 
            if (txtOTHours != null) { TextBoxFloadValidation(txtOTHours); }

            TextBox txtHourlyWageRate = (TextBox)e.Row.FindControl("txtHourlyWageRate"); 
            if (txtHourlyWageRate != null) { TextBoxFloadValidation(txtHourlyWageRate); }

            TextBox txtIncentiveAllowanceYearly = (TextBox)e.Row.FindControl("txtIncentiveAllowanceYearly"); 
            if (txtIncentiveAllowanceYearly != null) { TextBoxFloadValidation(txtIncentiveAllowanceYearly); }

            TextBox txtQuotedRate = (TextBox)e.Row.FindControl("txtQuotedRate"); if (txtQuotedRate != null) { TextBoxFloadValidation(txtQuotedRate); }
            TextBox txtTotal = (TextBox)e.Row.FindControl("txtTotal"); if (txtTotal != null) { TextBoxFloadValidation(txtTotal); }
            TextBox txtActual = (TextBox)e.Row.FindControl("txtActual"); if (txtActual != null) { TextBoxFloadValidation(txtActual); }
            TextBox txtAsPerMargin = (TextBox)e.Row.FindControl("txtAsPerMargin"); if (txtAsPerMargin != null) { TextBoxFloadValidation(txtAsPerMargin); }
            TextBox txtTotalHrsVoccationSickTraining = (TextBox)e.Row.FindControl("txtTotalHrsVoccationSickTraining"); if (txtTotalHrsVoccationSickTraining != null) { TextBoxFloadValidation(txtTotalHrsVoccationSickTraining); }
            TextBox txtDaysPerWeek = (TextBox)e.Row.FindControl("txtDaysPerWeek"); if (txtDaysPerWeek != null) { TextBoxFloadValidation(txtDaysPerWeek); }
            TextBox txtHoursPerDay = (TextBox)e.Row.FindControl("txtHoursPerDay"); if (txtHoursPerDay != null) { TextBoxFloadValidation(txtHoursPerDay); }
            TextBox txtPostsRequired = (TextBox)e.Row.FindControl("txtPostsRequired"); if (txtPostsRequired != null) { TextBoxFloadValidation(txtPostsRequired); }
            TextBox txtRecommendedMenByCategory = (TextBox)e.Row.FindControl("txtRecommendedMenByCategory"); if (txtRecommendedMenByCategory != null) { TextBoxFloadValidation(txtRecommendedMenByCategory); }
            TextBox txtTotalHrsPerWeek = (TextBox)e.Row.FindControl("txtTotalHrsPerWeek"); if (txtTotalHrsPerWeek != null) { TextBoxFloadValidation(txtTotalHrsPerWeek); }
            TextBox txtTotalHrsPerYearActual = (TextBox)e.Row.FindControl("txtTotalHrsPerYearActual"); if (txtTotalHrsPerYearActual != null) { TextBoxFloadValidation(txtTotalHrsPerYearActual); }
            TextBox txtTotalRegularHrsPerYear = (TextBox)e.Row.FindControl("txtTotalRegularHrsPerYear"); if (txtTotalRegularHrsPerYear != null) { TextBoxFloadValidation(txtTotalRegularHrsPerYear); }
            TextBox txtTotalOTHrsPerYear = (TextBox)e.Row.FindControl("txtTotalOTHrsPerYear"); if (txtTotalOTHrsPerYear != null) { TextBoxFloadValidation(txtTotalOTHrsPerYear); }
            TextBox txtTotalRegularHrsPayPerDay = (TextBox)e.Row.FindControl("txtTotalRegularHrsPayPerDay"); if (txtTotalRegularHrsPayPerDay != null) { TextBoxFloadValidation(txtTotalRegularHrsPayPerDay); }
            TextBox txtTotalOTHrsPayPerDay = (TextBox)e.Row.FindControl("txtTotalOTHrsPayPerDay"); if (txtTotalOTHrsPayPerDay != null) { TextBoxFloadValidation(txtTotalOTHrsPayPerDay); }
            TextBox txtTotalHrsPayPerDay = (TextBox)e.Row.FindControl("txtTotalHrsPayPerDay"); if (txtTotalHrsPayPerDay != null) { TextBoxFloadValidation(txtTotalHrsPayPerDay); }
            TextBox txtTotalHrsPerWeekAllPost = (TextBox)e.Row.FindControl("txtTotalHrsPerWeekAllPost"); if (txtTotalHrsPerWeekAllPost != null) { TextBoxFloadValidation(txtTotalHrsPerWeekAllPost); }
            TextBox txtTotalHrsPerYearAllPost = (TextBox)e.Row.FindControl("txtTotalHrsPerYearAllPost"); if (txtTotalHrsPerYearAllPost != null) { TextBoxFloadValidation(txtTotalHrsPerYearAllPost); }
            TextBox txtTotalRegularHrsPerYearAllPost = (TextBox)e.Row.FindControl("txtTotalRegularHrsPerYearAllPost"); if (txtTotalRegularHrsPerYearAllPost != null) { TextBoxFloadValidation(txtTotalRegularHrsPerYearAllPost); }
            TextBox txtTotalOTHrsPerYearAllPost = (TextBox)e.Row.FindControl("txtTotalOTHrsPerYearAllPost"); if (txtTotalOTHrsPerYearAllPost != null) { TextBoxFloadValidation(txtTotalOTHrsPerYearAllPost); }
            TextBox txtBasicWage12HrsPerDay = (TextBox)e.Row.FindControl("txtBasicWage12HrsPerDay"); if (txtBasicWage12HrsPerDay != null) { TextBoxFloadValidation(txtBasicWage12HrsPerDay); }
            TextBox txtOTFor9th12thHrsOTRate = (TextBox)e.Row.FindControl("txtOTFor9th12thHrsOTRate"); if (txtOTFor9th12thHrsOTRate != null) { TextBoxFloadValidation(txtOTFor9th12thHrsOTRate); }
            TextBox txtOT7thDay12Hrs = (TextBox)e.Row.FindControl("txtOT7thDay12Hrs"); if (txtOT7thDay12Hrs != null) { TextBoxFloadValidation(txtOT7thDay12Hrs); }
            TextBox txtIncentiveAllowance = (TextBox)e.Row.FindControl("txtIncentiveAllowance"); if (txtIncentiveAllowance != null) { TextBoxFloadValidation(txtIncentiveAllowance); }
            TextBox txtHolidayPay13Days8Hrs = (TextBox)e.Row.FindControl("txtHolidayPay13Days8Hrs"); if (txtHolidayPay13Days8Hrs != null) { TextBoxFloadValidation(txtHolidayPay13Days8Hrs); }
            TextBox txtSickPayCompensation = (TextBox)e.Row.FindControl("txtSickPayCompensation"); if (txtSickPayCompensation != null) { TextBoxFloadValidation(txtSickPayCompensation); }
            TextBox txtVacationPay = (TextBox)e.Row.FindControl("txtVacationPay"); if (txtVacationPay != null) { TextBoxFloadValidation(txtVacationPay); }
            TextBox txtProvidentFund = (TextBox)e.Row.FindControl("txtProvidentFund"); if (txtProvidentFund != null) { TextBoxFloadValidation(txtProvidentFund); }
            TextBox txtSocialWelfareFund = (TextBox)e.Row.FindControl("txtSocialWelfareFund"); if (txtSocialWelfareFund != null) { TextBoxFloadValidation(txtSocialWelfareFund); }
            TextBox txtWorkmanCompensationFund = (TextBox)e.Row.FindControl("txtWorkmanCompensationFund"); if (txtWorkmanCompensationFund != null) { TextBoxFloadValidation(txtWorkmanCompensationFund); }
            TextBox txtMonthlyBonusPayment = (TextBox)e.Row.FindControl("txtMonthlyBonusPayment"); if (txtMonthlyBonusPayment != null) { TextBoxFloadValidation(txtMonthlyBonusPayment); }
            TextBox txtTotalDirectLaborCost = (TextBox)e.Row.FindControl("txtTotalDirectLaborCost"); if (txtTotalDirectLaborCost != null) { TextBoxFloadValidation(txtTotalDirectLaborCost); }
            TextBox txtEquipmentsCost = (TextBox)e.Row.FindControl("txtEquipmentsCost"); if (txtEquipmentsCost != null) { TextBoxFloadValidation(txtEquipmentsCost); }
            TextBox txtTotalOperationCosts = (TextBox)e.Row.FindControl("txtTotalOperationCosts"); if (txtTotalOperationCosts != null) { TextBoxFloadValidation(txtTotalOperationCosts); }
            TextBox txtTotalDirectCost = (TextBox)e.Row.FindControl("txtTotalDirectCost"); if (txtTotalDirectCost != null) { TextBoxFloadValidation(txtTotalDirectCost); }
            TextBox txtOverHeadAllocation = (TextBox)e.Row.FindControl("txtOverHeadAllocation"); if (txtOverHeadAllocation != null) { TextBoxFloadValidation(txtOverHeadAllocation); }
            TextBox txtTotalLocaladministrativeCost = (TextBox)e.Row.FindControl("txtTotalLocaladministrativeCost"); if (txtTotalLocaladministrativeCost != null) { TextBoxFloadValidation(txtTotalLocaladministrativeCost); }
            TextBox txtPhoneAndFax = (TextBox)e.Row.FindControl("txtPhoneAndFax"); if (txtPhoneAndFax != null) { TextBoxFloadValidation(txtPhoneAndFax); }
            TextBox txtGeneralLibilityInsurance = (TextBox)e.Row.FindControl("txtGeneralLibilityInsurance"); if (txtGeneralLibilityInsurance != null) { TextBoxFloadValidation(txtGeneralLibilityInsurance); }
            TextBox txtTotalLocalOverheadCost = (TextBox)e.Row.FindControl("txtTotalLocalOverheadCost"); if (txtTotalLocalOverheadCost != null) { TextBoxFloadValidation(txtTotalLocalOverheadCost); }
            TextBox txtOverAllTotalCost = (TextBox)e.Row.FindControl("txtOverAllTotalCost"); if (txtOverAllTotalCost != null) { TextBoxFloadValidation(txtOverAllTotalCost); }
            TextBox txtRatePerPostAsPerMargin = (TextBox)e.Row.FindControl("txtRatePerPostAsPerMargin"); if (txtRatePerPostAsPerMargin != null) { TextBoxFloadValidation(txtRatePerPostAsPerMargin); }
            TextBox txtSumOfTotalPost = (TextBox)e.Row.FindControl("txtSumOfTotalPost"); if (txtSumOfTotalPost != null) { TextBoxFloadValidation(txtSumOfTotalPost); }
            TextBox txtSumOfTotalHrs = (TextBox)e.Row.FindControl("txtSumOfTotalHrs"); if (txtSumOfTotalHrs != null) { TextBoxFloadValidation(txtSumOfTotalHrs); }
            TextBox txtVoccationHrs = (TextBox)e.Row.FindControl("txtVoccationHrs"); if (txtVoccationHrs != null) { TextBoxFloadValidation(txtVoccationHrs); }
            TextBox txtSickProvision = (TextBox)e.Row.FindControl("txtSickProvision"); if (txtSickProvision != null) { TextBoxFloadValidation(txtSickProvision); }
            TextBox txtTrainingHrs = (TextBox)e.Row.FindControl("txtTrainingHrs"); if (txtTrainingHrs != null) { TextBoxFloadValidation(txtTrainingHrs); }
            TextBox txtOTRate = (TextBox)e.Row.FindControl("txtOTRate"); if (txtOTRate != null) { TextBoxFloadValidation(txtOTRate); }
            TextBox txtHolidayRate = (TextBox)e.Row.FindControl("txtHolidayRate"); if (txtHolidayRate != null) { TextBoxFloadValidation(txtHolidayRate); }
            TextBox txtOT7thDayRate = (TextBox)e.Row.FindControl("txtOT7thDayRate"); if (txtOT7thDayRate != null) { TextBoxFloadValidation(txtOT7thDayRate); }
            TextBox txtSickLeaveValue = (TextBox)e.Row.FindControl("txtSickLeaveValue"); if (txtSickLeaveValue != null) { TextBoxFloadValidation(txtSickLeaveValue); }
            TextBox txtVoccationDayValue = (TextBox)e.Row.FindControl("txtVoccationDayValue"); if (txtVoccationDayValue != null) { TextBoxFloadValidation(txtVoccationDayValue); }
            TextBox txtBonusPerMonthPerGuardRate = (TextBox)e.Row.FindControl("txtBonusPerMonthPerGuardRate"); if (txtBonusPerMonthPerGuardRate != null) { TextBoxFloadValidation(txtBonusPerMonthPerGuardRate); }
            TextBox txtPfRate = (TextBox)e.Row.FindControl("txtPfRate"); if (txtPfRate != null) { TextBoxFloadValidation(txtPfRate); }
            TextBox txtSocialWelfareRate = (TextBox)e.Row.FindControl("txtSocialWelfareRate"); if (txtSocialWelfareRate != null) { TextBoxFloadValidation(txtSocialWelfareRate); }
            TextBox txtWorkmenCommensationRate = (TextBox)e.Row.FindControl("txtWorkmenCommensationRate"); if (txtWorkmenCommensationRate != null) { TextBoxFloadValidation(txtWorkmenCommensationRate); }
            TextBox txtTotalEquipmentCost = (TextBox)e.Row.FindControl("txtTotalEquipmentCost"); if (txtTotalEquipmentCost != null) { TextBoxFloadValidation(txtTotalEquipmentCost); }
            TextBox txtOverheadAllocationRate = (TextBox)e.Row.FindControl("txtOverheadAllocationRate"); if (txtOverheadAllocationRate != null) { TextBoxFloadValidation(txtOverheadAllocationRate); }
            TextBox txtPhoneFaxRate = (TextBox)e.Row.FindControl("txtPhoneFaxRate"); if (txtPhoneFaxRate != null) { TextBoxFloadValidation(txtPhoneFaxRate); }
            TextBox txtGeneralLiabilityInsuranceRate = (TextBox)e.Row.FindControl("txtGeneralLiabilityInsuranceRate"); if (txtGeneralLiabilityInsuranceRate != null) { TextBoxFloadValidation(txtGeneralLiabilityInsuranceRate); }
            TextBox txtIncentiveMonthlyOrYearly = (TextBox)e.Row.FindControl("txtIncentiveMonthlyOrYearly"); if (txtIncentiveMonthlyOrYearly != null) { TextBoxFloadValidation(txtIncentiveMonthlyOrYearly); }
        }
        //for (int i = 17; i <= 70; i++)
        //{
        //    gvCostSheetService.Columns[i].Visible = false;
        //}
        for(int icell = 16; icell <= e.Row.Cells.Count-1; icell++)
        {
            e.Row.Cells[icell].Attributes.Add("style", "display:none;");
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvCostSheetService control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetService_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DropDownList ddlgvSORank = (DropDownList)gvCostSheetService.FooterRow.FindControl("ddlgvSORank");
        TextBox txtDesignationDesc = (TextBox)gvCostSheetService.FooterRow.FindControl("txtDesignationDesc");
        DropDownList ddlgvUOM = (DropDownList)gvCostSheetService.FooterRow.FindControl("ddlgvUOM");
        TextBox txtNumberOfPerson = (TextBox)gvCostSheetService.FooterRow.FindControl("txtNumberOfPerson");
        TextBox txtWorkingDay = (TextBox)gvCostSheetService.FooterRow.FindControl("txtWorkingDay");
        TextBox txtNormalHours = (TextBox)gvCostSheetService.FooterRow.FindControl("txtNormalHours");
        TextBox txtOTHours = (TextBox)gvCostSheetService.FooterRow.FindControl("txtOTHours");
        TextBox txtHourlyWageRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtHourlyWageRate");
        TextBox txtIncentiveAllowanceYearly = (TextBox)gvCostSheetService.FooterRow.FindControl("txtIncentiveAllowanceYearly");
        TextBox txtQuotedRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtQuotedRate");
        TextBox txtTotal = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotal");
        TextBox txtActual = (TextBox)gvCostSheetService.FooterRow.FindControl("txtActual");
        TextBox txtAsPerMargin = (TextBox)gvCostSheetService.FooterRow.FindControl("txtAsPerMargin");
        TextBox txtTotalHrsVoccationSickTraining = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalHrsVoccationSickTraining");
        TextBox txtDaysPerWeek = (TextBox)gvCostSheetService.FooterRow.FindControl("txtDaysPerWeek");
        TextBox txtHoursPerDay = (TextBox)gvCostSheetService.FooterRow.FindControl("txtHoursPerDay");
        TextBox txtPostsRequired = (TextBox)gvCostSheetService.FooterRow.FindControl("txtPostsRequired");
        TextBox txtRecommendedMenByCategory = (TextBox)gvCostSheetService.FooterRow.FindControl("txtRecommendedMenByCategory");
        TextBox txtTotalHrsPerWeek = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalHrsPerWeek");
        TextBox txtTotalHrsPerYearActual = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalHrsPerYearActual");
        TextBox txtTotalRegularHrsPerYear = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalRegularHrsPerYear");
        TextBox txtTotalOTHrsPerYear = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalOTHrsPerYear");
        TextBox txtTotalRegularHrsPayPerDay = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalRegularHrsPayPerDay");
        TextBox txtTotalOTHrsPayPerDay = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalOTHrsPayPerDay");
        TextBox txtTotalHrsPayPerDay = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalHrsPayPerDay");
        TextBox txtTotalHrsPerWeekAllPost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalHrsPerWeekAllPost");
        TextBox txtTotalHrsPerYearAllPost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalHrsPerYearAllPost");
        TextBox txtTotalRegularHrsPerYearAllPost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalRegularHrsPerYearAllPost");
        TextBox txtTotalOTHrsPerYearAllPost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalOTHrsPerYearAllPost");
        TextBox txtBasicWage12HrsPerDay = (TextBox)gvCostSheetService.FooterRow.FindControl("txtBasicWage12HrsPerDay");
        TextBox txtOTFor9th12thHrsOTRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtOTFor9th12thHrsOTRate");
        TextBox txtOT7thDay12Hrs = (TextBox)gvCostSheetService.FooterRow.FindControl("txtOT7thDay12Hrs");
        TextBox txtIncentiveAllowance = (TextBox)gvCostSheetService.FooterRow.FindControl("txtIncentiveAllowance");
        TextBox txtHolidayPay13Days8Hrs = (TextBox)gvCostSheetService.FooterRow.FindControl("txtHolidayPay13Days8Hrs");
        TextBox txtSickPayCompensation = (TextBox)gvCostSheetService.FooterRow.FindControl("txtSickPayCompensation");
        TextBox txtVacationPay = (TextBox)gvCostSheetService.FooterRow.FindControl("txtVacationPay");
        TextBox txtProvidentFund = (TextBox)gvCostSheetService.FooterRow.FindControl("txtProvidentFund");
        TextBox txtSocialWelfareFund = (TextBox)gvCostSheetService.FooterRow.FindControl("txtSocialWelfareFund");
        TextBox txtWorkmanCompensationFund = (TextBox)gvCostSheetService.FooterRow.FindControl("txtWorkmanCompensationFund");
        TextBox txtMonthlyBonusPayment = (TextBox)gvCostSheetService.FooterRow.FindControl("txtMonthlyBonusPayment");
        TextBox txtTotalDirectLaborCost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalDirectLaborCost");
        TextBox txtEquipmentsCost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtEquipmentsCost");
        TextBox txtTotalOperationCosts = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalOperationCosts");
        TextBox txtTotalDirectCost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalDirectCost");
        TextBox txtOverHeadAllocation = (TextBox)gvCostSheetService.FooterRow.FindControl("txtOverHeadAllocation");
        TextBox txtTotalLocaladministrativeCost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalLocaladministrativeCost");
        TextBox txtPhoneAndFax = (TextBox)gvCostSheetService.FooterRow.FindControl("txtPhoneAndFax");
        TextBox txtGeneralLibilityInsurance = (TextBox)gvCostSheetService.FooterRow.FindControl("txtGeneralLibilityInsurance");
        TextBox txtTotalLocalOverheadCost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalLocalOverheadCost");
        TextBox txtOverAllTotalCost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtOverAllTotalCost");
        TextBox txtRatePerPostAsPerMargin = (TextBox)gvCostSheetService.FooterRow.FindControl("txtRatePerPostAsPerMargin");
        TextBox txtSumOfTotalPost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtSumOfTotalPost");
        TextBox txtSumOfTotalHrs = (TextBox)gvCostSheetService.FooterRow.FindControl("txtSumOfTotalHrs");
        TextBox txtVoccationHrs = (TextBox)gvCostSheetService.FooterRow.FindControl("txtVoccationHrs");
        TextBox txtSickProvision = (TextBox)gvCostSheetService.FooterRow.FindControl("txtSickProvision");
        TextBox txtTrainingHrs = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTrainingHrs");
        TextBox txtOTRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtOTRate");
        TextBox txtHolidayRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtHolidayRate");
        TextBox txtOT7thDayRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtOT7thDayRate");
        TextBox txtSickLeaveValue = (TextBox)gvCostSheetService.FooterRow.FindControl("txtSickLeaveValue");
        TextBox txtVoccationDayValue = (TextBox)gvCostSheetService.FooterRow.FindControl("txtVoccationDayValue");
        TextBox txtBonusPerMonthPerGuardRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtBonusPerMonthPerGuardRate");
        TextBox txtPfRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtPfRate");
        TextBox txtSocialWelfareRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtSocialWelfareRate");
        TextBox txtWorkmenCommensationRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtWorkmenCommensationRate");
        TextBox txtTotalEquipmentCost = (TextBox)gvCostSheetService.FooterRow.FindControl("txtTotalEquipmentCost");
        TextBox txtOverheadAllocationRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtOverheadAllocationRate");
        TextBox txtPhoneFaxRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtPhoneFaxRate");
        TextBox txtGeneralLiabilityInsuranceRate = (TextBox)gvCostSheetService.FooterRow.FindControl("txtGeneralLiabilityInsuranceRate");
        TextBox txtIncentiveMonthlyOrYearly = (TextBox)gvCostSheetService.FooterRow.FindControl("txtIncentiveMonthlyOrYearly");

        if (e.CommandName == "Add")
        {
            if (txtCostSheetNo.Text.Length > 0 && ddlCostSheetAmendNo.SelectedItem.Value.ToString().Length > 0 && hfIsMAXCostSheetAmendNo.Value == "MAX")
            {
                if (txtNumberOfPerson != null) { IfBlankSetValueToZero(txtNumberOfPerson); }
                if (txtWorkingDay != null) { IfBlankSetValueToZero(txtWorkingDay); }
                if (txtNormalHours != null) { IfBlankSetValueToZero(txtNormalHours); }
                if (txtOTHours != null) { IfBlankSetValueToZero(txtOTHours); }
                if (txtHourlyWageRate != null) { IfBlankSetValueToZero(txtHourlyWageRate); }
                if (txtIncentiveAllowanceYearly != null) { IfBlankSetValueToZero(txtIncentiveAllowanceYearly); }
                if (txtQuotedRate != null) { IfBlankSetValueToZero(txtQuotedRate); }
                if (txtTotal != null) { IfBlankSetValueToZero(txtTotal); }
                if (txtActual != null) { IfBlankSetValueToZero(txtActual); }
                if (txtAsPerMargin != null) { IfBlankSetValueToZero(txtAsPerMargin); }
                if (txtTotalHrsVoccationSickTraining != null) { IfBlankSetValueToZero(txtTotalHrsVoccationSickTraining); }
                if (txtDaysPerWeek != null) { IfBlankSetValueToZero(txtDaysPerWeek); }
                if (txtHoursPerDay != null) { IfBlankSetValueToZero(txtHoursPerDay); }
                if (txtPostsRequired != null) { IfBlankSetValueToZero(txtPostsRequired); }
                if (txtRecommendedMenByCategory != null) { IfBlankSetValueToZero(txtRecommendedMenByCategory); }
                if (txtTotalHrsPerWeek != null) { IfBlankSetValueToZero(txtTotalHrsPerWeek); }
                if (txtTotalHrsPerYearActual != null) { IfBlankSetValueToZero(txtTotalHrsPerYearActual); }
                if (txtTotalRegularHrsPerYear != null) { IfBlankSetValueToZero(txtTotalRegularHrsPerYear); }
                if (txtTotalOTHrsPerYear != null) { IfBlankSetValueToZero(txtTotalOTHrsPerYear); }
                if (txtTotalRegularHrsPayPerDay != null) { IfBlankSetValueToZero(txtTotalRegularHrsPayPerDay); }
                if (txtTotalOTHrsPayPerDay != null) { IfBlankSetValueToZero(txtTotalOTHrsPayPerDay); }
                if (txtTotalHrsPayPerDay != null) { IfBlankSetValueToZero(txtTotalHrsPayPerDay); }
                if (txtTotalHrsPerWeekAllPost != null) { IfBlankSetValueToZero(txtTotalHrsPerWeekAllPost); }
                if (txtTotalHrsPerYearAllPost != null) { IfBlankSetValueToZero(txtTotalHrsPerYearAllPost); }
                if (txtTotalRegularHrsPerYearAllPost != null) { IfBlankSetValueToZero(txtTotalRegularHrsPerYearAllPost); }
                if (txtTotalOTHrsPerYearAllPost != null) { IfBlankSetValueToZero(txtTotalOTHrsPerYearAllPost); }
                if (txtBasicWage12HrsPerDay != null) { IfBlankSetValueToZero(txtBasicWage12HrsPerDay); }
                if (txtOTFor9th12thHrsOTRate != null) { IfBlankSetValueToZero(txtOTFor9th12thHrsOTRate); }
                if (txtOT7thDay12Hrs != null) { IfBlankSetValueToZero(txtOT7thDay12Hrs); }
                if (txtIncentiveAllowance != null) { IfBlankSetValueToZero(txtIncentiveAllowance); }
                if (txtHolidayPay13Days8Hrs != null) { IfBlankSetValueToZero(txtHolidayPay13Days8Hrs); }
                if (txtSickPayCompensation != null) { IfBlankSetValueToZero(txtSickPayCompensation); }
                if (txtVacationPay != null) { IfBlankSetValueToZero(txtVacationPay); }
                if (txtProvidentFund != null) { IfBlankSetValueToZero(txtProvidentFund); }
                if (txtSocialWelfareFund != null) { IfBlankSetValueToZero(txtSocialWelfareFund); }
                if (txtWorkmanCompensationFund != null) { IfBlankSetValueToZero(txtWorkmanCompensationFund); }
                if (txtMonthlyBonusPayment != null) { IfBlankSetValueToZero(txtMonthlyBonusPayment); }
                if (txtTotalDirectLaborCost != null) { IfBlankSetValueToZero(txtTotalDirectLaborCost); }
                if (txtEquipmentsCost != null) { IfBlankSetValueToZero(txtEquipmentsCost); }
                if (txtTotalOperationCosts != null) { IfBlankSetValueToZero(txtTotalOperationCosts); }
                if (txtTotalDirectCost != null) { IfBlankSetValueToZero(txtTotalDirectCost); }
                if (txtOverHeadAllocation != null) { IfBlankSetValueToZero(txtOverHeadAllocation); }
                if (txtTotalLocaladministrativeCost != null) { IfBlankSetValueToZero(txtTotalLocaladministrativeCost); }
                if (txtPhoneAndFax != null) { IfBlankSetValueToZero(txtPhoneAndFax); }
                if (txtGeneralLibilityInsurance != null) { IfBlankSetValueToZero(txtGeneralLibilityInsurance); }
                if (txtTotalLocalOverheadCost != null) { IfBlankSetValueToZero(txtTotalLocalOverheadCost); }
                if (txtOverAllTotalCost != null) { IfBlankSetValueToZero(txtOverAllTotalCost); }
                if (txtRatePerPostAsPerMargin != null) { IfBlankSetValueToZero(txtRatePerPostAsPerMargin); }
                if (txtSumOfTotalPost != null) { IfBlankSetValueToZero(txtSumOfTotalPost); }
                if (txtSumOfTotalHrs != null) { IfBlankSetValueToZero(txtSumOfTotalHrs); }
                if (txtVoccationHrs != null) { IfBlankSetValueToZero(txtVoccationHrs); }
                if (txtSickProvision != null) { IfBlankSetValueToZero(txtSickProvision); }
                if (txtTrainingHrs != null) { IfBlankSetValueToZero(txtTrainingHrs); }
                if (txtOTRate != null) { IfBlankSetValueToZero(txtOTRate); }
                if (txtHolidayRate != null) { IfBlankSetValueToZero(txtHolidayRate); }
                if (txtOT7thDayRate != null) { IfBlankSetValueToZero(txtOT7thDayRate); }
                if (txtSickLeaveValue != null) { IfBlankSetValueToZero(txtSickLeaveValue); }
                if (txtVoccationDayValue != null) { IfBlankSetValueToZero(txtVoccationDayValue); }
                if (txtBonusPerMonthPerGuardRate != null) { IfBlankSetValueToZero(txtBonusPerMonthPerGuardRate); }
                if (txtPfRate != null) { IfBlankSetValueToZero(txtPfRate); }
                if (txtSocialWelfareRate != null) { IfBlankSetValueToZero(txtSocialWelfareRate); }
                if (txtWorkmenCommensationRate != null) { IfBlankSetValueToZero(txtWorkmenCommensationRate); }
                if (txtTotalEquipmentCost != null) { IfBlankSetValueToZero(txtTotalEquipmentCost); }
                if (txtOverheadAllocationRate != null) { IfBlankSetValueToZero(txtOverheadAllocationRate); }
                if (txtPhoneFaxRate != null) { IfBlankSetValueToZero(txtPhoneFaxRate); }
                if (txtGeneralLiabilityInsuranceRate != null) { IfBlankSetValueToZero(txtGeneralLiabilityInsuranceRate); }

                // To Insert a New Row
                BL.Sales objSales = new BL.Sales();
                DataSet ds = new DataSet();
                ds = objSales.CostSheetServiceInsert(BaseLocationAutoID.ToString(), txtCostSheetNo.Text, ddlCostSheetAmendNo.SelectedItem.Value.ToString(), ddlgvSORank.SelectedItem.Value.ToString(), txtDesignationDesc.Text, ddlgvUOM.SelectedItem.Value.ToString(), txtNumberOfPerson.Text, txtWorkingDay.Text, txtNormalHours.Text, txtOTHours.Text, txtHourlyWageRate.Text, txtIncentiveAllowanceYearly.Text, txtQuotedRate.Text, txtTotal.Text, txtActual.Text, txtAsPerMargin.Text, txtTotalHrsVoccationSickTraining.Text, txtDaysPerWeek.Text, txtHoursPerDay.Text, txtPostsRequired.Text, txtRecommendedMenByCategory.Text, txtTotalHrsPerWeek.Text, txtTotalHrsPerYearActual.Text, txtTotalRegularHrsPerYear.Text, txtTotalOTHrsPerYear.Text, txtTotalRegularHrsPayPerDay.Text, txtTotalOTHrsPayPerDay.Text, txtTotalHrsPayPerDay.Text, txtTotalHrsPerWeekAllPost.Text, txtTotalHrsPerYearAllPost.Text, txtTotalRegularHrsPerYearAllPost.Text, txtTotalOTHrsPerYearAllPost.Text, txtBasicWage12HrsPerDay.Text, txtOTFor9th12thHrsOTRate.Text, txtOT7thDay12Hrs.Text, txtIncentiveAllowance.Text, txtHolidayPay13Days8Hrs.Text, txtSickPayCompensation.Text, txtVacationPay.Text, txtProvidentFund.Text, txtSocialWelfareFund.Text, txtWorkmanCompensationFund.Text, txtMonthlyBonusPayment.Text, txtTotalDirectLaborCost.Text, txtEquipmentsCost.Text, txtTotalOperationCosts.Text, txtTotalDirectCost.Text, txtOverHeadAllocation.Text, txtTotalLocaladministrativeCost.Text, txtPhoneAndFax.Text, txtGeneralLibilityInsurance.Text, txtTotalLocalOverheadCost.Text, txtOverAllTotalCost.Text, txtRatePerPostAsPerMargin.Text, txtSumOfTotalPost.Text, txtSumOfTotalHrs.Text, txtVoccationHrs.Text, txtSickProvision.Text, txtTrainingHrs.Text, txtOTRate.Text, txtHolidayRate.Text, txtOT7thDayRate.Text, txtSickLeaveValue.Text, txtVoccationDayValue.Text, txtBonusPerMonthPerGuardRate.Text, txtPfRate.Text, txtSocialWelfareRate.Text, txtWorkmenCommensationRate.Text, txtTotalEquipmentCost.Text, txtOverheadAllocationRate.Text, txtPhoneFaxRate.Text, txtGeneralLiabilityInsuranceRate.Text, txtIncentiveMonthlyOrYearly.Text, BaseUserID.ToString());
                gvCostSheetService.EditIndex = -1;
                FillgvCostSheetService();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
        }
        else if (e.CommandName == "Reset")
        {
            txtNumberOfPerson.Text = "";
            txtWorkingDay.Text = "";
            txtNormalHours.Text = "";
            txtOTHours.Text = "";
            txtHourlyWageRate.Text = "";
            txtIncentiveAllowanceYearly.Text = "";
            txtQuotedRate.Text = "";
            txtTotal.Text = "";
            txtActual.Text = "";
            txtAsPerMargin.Text = "";
            txtTotalHrsVoccationSickTraining.Text = "";
            txtDaysPerWeek.Text = "";
            txtHoursPerDay.Text = "";
            txtPostsRequired.Text = "";
            txtRecommendedMenByCategory.Text = "";
            txtTotalHrsPerWeek.Text = "";
            txtTotalHrsPerYearActual.Text = "";
            txtTotalRegularHrsPerYear.Text = "";
            txtTotalOTHrsPerYear.Text = "";
            txtTotalRegularHrsPayPerDay.Text = "";
            txtTotalOTHrsPayPerDay.Text = "";
            txtTotalHrsPayPerDay.Text = "";
            txtTotalHrsPerWeekAllPost.Text = "";
            txtTotalHrsPerYearAllPost.Text = "";
            txtTotalRegularHrsPerYearAllPost.Text = "";
            txtTotalOTHrsPerYearAllPost.Text = "";
            txtBasicWage12HrsPerDay.Text = "";
            txtOTFor9th12thHrsOTRate.Text = "";
            txtOT7thDay12Hrs.Text = "";
            txtIncentiveAllowance.Text = "";
            txtHolidayPay13Days8Hrs.Text = "";
            txtSickPayCompensation.Text = "";
            txtVacationPay.Text = "";
            txtProvidentFund.Text = "";
            txtSocialWelfareFund.Text = "";
            txtWorkmanCompensationFund.Text = "";
            txtMonthlyBonusPayment.Text = "";
            txtTotalDirectLaborCost.Text = "";
            txtEquipmentsCost.Text = "";
            txtTotalOperationCosts.Text = "";
            txtTotalDirectCost.Text = "";
            txtOverHeadAllocation.Text = "";
            txtTotalLocaladministrativeCost.Text = "";
            txtPhoneAndFax.Text = "";
            txtGeneralLibilityInsurance.Text = "";
            txtTotalLocalOverheadCost.Text = "";
            txtOverAllTotalCost.Text = "";
            txtRatePerPostAsPerMargin.Text = "";
            txtSumOfTotalPost.Text = "";
            txtSumOfTotalHrs.Text = "";
            txtVoccationHrs.Text = "";
            txtSickProvision.Text = "";
            txtTrainingHrs.Text = "";
            txtOTRate.Text = "";
            txtHolidayRate.Text = "";
            txtOT7thDayRate.Text = "";
            txtSickLeaveValue.Text = "";
            txtVoccationDayValue.Text = "";
            txtBonusPerMonthPerGuardRate.Text = "";
            txtPfRate.Text = "";
            txtSocialWelfareRate.Text = "";
            txtWorkmenCommensationRate.Text = "";
            txtTotalEquipmentCost.Text = "";
            txtOverheadAllocationRate.Text = "";
            txtPhoneFaxRate.Text = "";
            txtGeneralLiabilityInsuranceRate.Text = "";
            txtIncentiveMonthlyOrYearly.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvCostSheetService control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetService_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCostSheetService.EditIndex = -1;
        FillgvCostSheetService();
    }
    /// <summary>
    /// Handles the RowEditing event of the gvCostSheetService control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetService_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCostSheetService.EditIndex = e.NewEditIndex;
        FillgvCostSheetService();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvCostSheetService control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetService_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblCostSheetLineNO = (Label)gvCostSheetService.Rows[e.RowIndex].FindControl("lblCostSheetLineNO");
        DropDownList ddlgvSORank = (DropDownList)gvCostSheetService.Rows[e.RowIndex].FindControl("ddlgvSORank");
        TextBox txtDesignationDesc = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtDesignationDesc");
        DropDownList ddlgvUOM = (DropDownList)gvCostSheetService.Rows[e.RowIndex].FindControl("ddlgvUOM");
        TextBox txtNumberOfPerson = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtNumberOfPerson");
        TextBox txtWorkingDay = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtWorkingDay");
        TextBox txtNormalHours = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtNormalHours");
        TextBox txtOTHours = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtOTHours");
        TextBox txtHourlyWageRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtHourlyWageRate");
        TextBox txtIncentiveAllowanceYearly = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtIncentiveAllowanceYearly");
        TextBox txtQuotedRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtQuotedRate");
        TextBox txtTotal = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotal");
        TextBox txtActual = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtActual");
        TextBox txtAsPerMargin = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtAsPerMargin");
        TextBox txtTotalHrsVoccationSickTraining = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalHrsVoccationSickTraining");
        TextBox txtDaysPerWeek = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtDaysPerWeek");
        TextBox txtHoursPerDay = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtHoursPerDay");
        TextBox txtPostsRequired = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtPostsRequired");
        TextBox txtRecommendedMenByCategory = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtRecommendedMenByCategory");
        TextBox txtTotalHrsPerWeek = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalHrsPerWeek");
        TextBox txtTotalHrsPerYearActual = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalHrsPerYearActual");
        TextBox txtTotalRegularHrsPerYear = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalRegularHrsPerYear");
        TextBox txtTotalOTHrsPerYear = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalOTHrsPerYear");
        TextBox txtTotalRegularHrsPayPerDay = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalRegularHrsPayPerDay");
        TextBox txtTotalOTHrsPayPerDay = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalOTHrsPayPerDay");
        TextBox txtTotalHrsPayPerDay = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalHrsPayPerDay");
        TextBox txtTotalHrsPerWeekAllPost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalHrsPerWeekAllPost");
        TextBox txtTotalHrsPerYearAllPost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalHrsPerYearAllPost");
        TextBox txtTotalRegularHrsPerYearAllPost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalRegularHrsPerYearAllPost");
        TextBox txtTotalOTHrsPerYearAllPost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalOTHrsPerYearAllPost");
        TextBox txtBasicWage12HrsPerDay = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtBasicWage12HrsPerDay");
        TextBox txtOTFor9th12thHrsOTRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtOTFor9th12thHrsOTRate");
        TextBox txtOT7thDay12Hrs = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtOT7thDay12Hrs");
        TextBox txtIncentiveAllowance = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtIncentiveAllowance");
        TextBox txtHolidayPay13Days8Hrs = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtHolidayPay13Days8Hrs");
        TextBox txtSickPayCompensation = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtSickPayCompensation");
        TextBox txtVacationPay = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtVacationPay");
        TextBox txtProvidentFund = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtProvidentFund");
        TextBox txtSocialWelfareFund = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtSocialWelfareFund");
        TextBox txtWorkmanCompensationFund = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtWorkmanCompensationFund");
        TextBox txtMonthlyBonusPayment = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtMonthlyBonusPayment");
        TextBox txtTotalDirectLaborCost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalDirectLaborCost");
        TextBox txtEquipmentsCost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtEquipmentsCost");
        TextBox txtTotalOperationCosts = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalOperationCosts");
        TextBox txtTotalDirectCost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalDirectCost");
        TextBox txtOverHeadAllocation = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtOverHeadAllocation");
        TextBox txtTotalLocaladministrativeCost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalLocaladministrativeCost");
        TextBox txtPhoneAndFax = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtPhoneAndFax");
        TextBox txtGeneralLibilityInsurance = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtGeneralLibilityInsurance");
        TextBox txtTotalLocalOverheadCost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalLocalOverheadCost");
        TextBox txtOverAllTotalCost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtOverAllTotalCost");
        TextBox txtRatePerPostAsPerMargin = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtRatePerPostAsPerMargin");
        TextBox txtSumOfTotalPost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtSumOfTotalPost");
        TextBox txtSumOfTotalHrs = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtSumOfTotalHrs");
        TextBox txtVoccationHrs = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtVoccationHrs");
        TextBox txtSickProvision = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtSickProvision");
        TextBox txtTrainingHrs = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTrainingHrs");
        TextBox txtOTRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtOTRate");
        TextBox txtHolidayRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtHolidayRate");
        TextBox txtOT7thDayRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtOT7thDayRate");
        TextBox txtSickLeaveValue = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtSickLeaveValue");
        TextBox txtVoccationDayValue = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtVoccationDayValue");
        TextBox txtBonusPerMonthPerGuardRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtBonusPerMonthPerGuardRate");
        TextBox txtPfRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtPfRate");
        TextBox txtSocialWelfareRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtSocialWelfareRate");
        TextBox txtWorkmenCommensationRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtWorkmenCommensationRate");
        TextBox txtTotalEquipmentCost = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtTotalEquipmentCost");
        TextBox txtOverheadAllocationRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtOverheadAllocationRate");
        TextBox txtPhoneFaxRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtPhoneFaxRate");
        TextBox txtGeneralLiabilityInsuranceRate = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtGeneralLiabilityInsuranceRate");
        TextBox txtIncentiveMonthlyOrYearly = (TextBox)gvCostSheetService.Rows[e.RowIndex].FindControl("txtIncentiveMonthlyOrYearly");

        if (txtNumberOfPerson != null) { IfBlankSetValueToZero(txtNumberOfPerson); }
        if (txtWorkingDay != null) { IfBlankSetValueToZero(txtWorkingDay); }
        if (txtNormalHours != null) { IfBlankSetValueToZero(txtNormalHours); }
        if (txtOTHours != null) { IfBlankSetValueToZero(txtOTHours); }
        if (txtHourlyWageRate != null) { IfBlankSetValueToZero(txtHourlyWageRate); }
        if (txtIncentiveAllowanceYearly != null) { IfBlankSetValueToZero(txtIncentiveAllowanceYearly); }
        if (txtQuotedRate != null) { IfBlankSetValueToZero(txtQuotedRate); }
        if (txtTotal != null) { IfBlankSetValueToZero(txtTotal); }
        if (txtActual != null) { IfBlankSetValueToZero(txtActual); }
        if (txtAsPerMargin != null) { IfBlankSetValueToZero(txtAsPerMargin); }
        if (txtTotalHrsVoccationSickTraining != null) { IfBlankSetValueToZero(txtTotalHrsVoccationSickTraining); }
        if (txtDaysPerWeek != null) { IfBlankSetValueToZero(txtDaysPerWeek); }
        if (txtHoursPerDay != null) { IfBlankSetValueToZero(txtHoursPerDay); }
        if (txtPostsRequired != null) { IfBlankSetValueToZero(txtPostsRequired); }
        if (txtRecommendedMenByCategory != null) { IfBlankSetValueToZero(txtRecommendedMenByCategory); }
        if (txtTotalHrsPerWeek != null) { IfBlankSetValueToZero(txtTotalHrsPerWeek); }
        if (txtTotalHrsPerYearActual != null) { IfBlankSetValueToZero(txtTotalHrsPerYearActual); }
        if (txtTotalRegularHrsPerYear != null) { IfBlankSetValueToZero(txtTotalRegularHrsPerYear); }
        if (txtTotalOTHrsPerYear != null) { IfBlankSetValueToZero(txtTotalOTHrsPerYear); }
        if (txtTotalRegularHrsPayPerDay != null) { IfBlankSetValueToZero(txtTotalRegularHrsPayPerDay); }
        if (txtTotalOTHrsPayPerDay != null) { IfBlankSetValueToZero(txtTotalOTHrsPayPerDay); }
        if (txtTotalHrsPayPerDay != null) { IfBlankSetValueToZero(txtTotalHrsPayPerDay); }
        if (txtTotalHrsPerWeekAllPost != null) { IfBlankSetValueToZero(txtTotalHrsPerWeekAllPost); }
        if (txtTotalHrsPerYearAllPost != null) { IfBlankSetValueToZero(txtTotalHrsPerYearAllPost); }
        if (txtTotalRegularHrsPerYearAllPost != null) { IfBlankSetValueToZero(txtTotalRegularHrsPerYearAllPost); }
        if (txtTotalOTHrsPerYearAllPost != null) { IfBlankSetValueToZero(txtTotalOTHrsPerYearAllPost); }
        if (txtBasicWage12HrsPerDay != null) { IfBlankSetValueToZero(txtBasicWage12HrsPerDay); }
        if (txtOTFor9th12thHrsOTRate != null) { IfBlankSetValueToZero(txtOTFor9th12thHrsOTRate); }
        if (txtOT7thDay12Hrs != null) { IfBlankSetValueToZero(txtOT7thDay12Hrs); }
        if (txtIncentiveAllowance != null) { IfBlankSetValueToZero(txtIncentiveAllowance); }
        if (txtHolidayPay13Days8Hrs != null) { IfBlankSetValueToZero(txtHolidayPay13Days8Hrs); }
        if (txtSickPayCompensation != null) { IfBlankSetValueToZero(txtSickPayCompensation); }
        if (txtVacationPay != null) { IfBlankSetValueToZero(txtVacationPay); }
        if (txtProvidentFund != null) { IfBlankSetValueToZero(txtProvidentFund); }
        if (txtSocialWelfareFund != null) { IfBlankSetValueToZero(txtSocialWelfareFund); }
        if (txtWorkmanCompensationFund != null) { IfBlankSetValueToZero(txtWorkmanCompensationFund); }
        if (txtMonthlyBonusPayment != null) { IfBlankSetValueToZero(txtMonthlyBonusPayment); }
        if (txtTotalDirectLaborCost != null) { IfBlankSetValueToZero(txtTotalDirectLaborCost); }
        if (txtEquipmentsCost != null) { IfBlankSetValueToZero(txtEquipmentsCost); }
        if (txtTotalOperationCosts != null) { IfBlankSetValueToZero(txtTotalOperationCosts); }
        if (txtTotalDirectCost != null) { IfBlankSetValueToZero(txtTotalDirectCost); }
        if (txtOverHeadAllocation != null) { IfBlankSetValueToZero(txtOverHeadAllocation); }
        if (txtTotalLocaladministrativeCost != null) { IfBlankSetValueToZero(txtTotalLocaladministrativeCost); }
        if (txtPhoneAndFax != null) { IfBlankSetValueToZero(txtPhoneAndFax); }
        if (txtGeneralLibilityInsurance != null) { IfBlankSetValueToZero(txtGeneralLibilityInsurance); }
        if (txtTotalLocalOverheadCost != null) { IfBlankSetValueToZero(txtTotalLocalOverheadCost); }
        if (txtOverAllTotalCost != null) { IfBlankSetValueToZero(txtOverAllTotalCost); }
        if (txtRatePerPostAsPerMargin != null) { IfBlankSetValueToZero(txtRatePerPostAsPerMargin); }
        if (txtSumOfTotalPost != null) { IfBlankSetValueToZero(txtSumOfTotalPost); }
        if (txtSumOfTotalHrs != null) { IfBlankSetValueToZero(txtSumOfTotalHrs); }
        if (txtVoccationHrs != null) { IfBlankSetValueToZero(txtVoccationHrs); }
        if (txtSickProvision != null) { IfBlankSetValueToZero(txtSickProvision); }
        if (txtTrainingHrs != null) { IfBlankSetValueToZero(txtTrainingHrs); }
        if (txtOTRate != null) { IfBlankSetValueToZero(txtOTRate); }
        if (txtHolidayRate != null) { IfBlankSetValueToZero(txtHolidayRate); }
        if (txtOT7thDayRate != null) { IfBlankSetValueToZero(txtOT7thDayRate); }
        if (txtSickLeaveValue != null) { IfBlankSetValueToZero(txtSickLeaveValue); }
        if (txtVoccationDayValue != null) { IfBlankSetValueToZero(txtVoccationDayValue); }
        if (txtBonusPerMonthPerGuardRate != null) { IfBlankSetValueToZero(txtBonusPerMonthPerGuardRate); }
        if (txtPfRate != null) { IfBlankSetValueToZero(txtPfRate); }
        if (txtSocialWelfareRate != null) { IfBlankSetValueToZero(txtSocialWelfareRate); }
        if (txtWorkmenCommensationRate != null) { IfBlankSetValueToZero(txtWorkmenCommensationRate); }
        if (txtTotalEquipmentCost != null) { IfBlankSetValueToZero(txtTotalEquipmentCost); }
        if (txtOverheadAllocationRate != null) { IfBlankSetValueToZero(txtOverheadAllocationRate); }
        if (txtPhoneFaxRate != null) { IfBlankSetValueToZero(txtPhoneFaxRate); }
        if (txtGeneralLiabilityInsuranceRate != null) { IfBlankSetValueToZero(txtGeneralLiabilityInsuranceRate); }

        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.CostSheetServiceUpdate(BaseLocationAutoID.ToString(), txtCostSheetNo.Text, ddlCostSheetAmendNo.SelectedItem.Value.ToString(), lblCostSheetLineNO.Text, ddlgvSORank.SelectedItem.Value.ToString(), txtDesignationDesc.Text, ddlgvUOM.SelectedItem.Value.ToString(), txtNumberOfPerson.Text, txtWorkingDay.Text, txtNormalHours.Text, txtOTHours.Text, txtHourlyWageRate.Text, txtIncentiveAllowanceYearly.Text, txtQuotedRate.Text, txtTotal.Text, txtActual.Text, txtAsPerMargin.Text, txtTotalHrsVoccationSickTraining.Text, txtDaysPerWeek.Text, txtHoursPerDay.Text, txtPostsRequired.Text, txtRecommendedMenByCategory.Text, txtTotalHrsPerWeek.Text, txtTotalHrsPerYearActual.Text, txtTotalRegularHrsPerYear.Text, txtTotalOTHrsPerYear.Text, txtTotalRegularHrsPayPerDay.Text, txtTotalOTHrsPayPerDay.Text, txtTotalHrsPayPerDay.Text, txtTotalHrsPerWeekAllPost.Text, txtTotalHrsPerYearAllPost.Text, txtTotalRegularHrsPerYearAllPost.Text, txtTotalOTHrsPerYearAllPost.Text, txtBasicWage12HrsPerDay.Text, txtOTFor9th12thHrsOTRate.Text, txtOT7thDay12Hrs.Text, txtIncentiveAllowance.Text, txtHolidayPay13Days8Hrs.Text, txtSickPayCompensation.Text, txtVacationPay.Text, txtProvidentFund.Text, txtSocialWelfareFund.Text, txtWorkmanCompensationFund.Text, txtMonthlyBonusPayment.Text, txtTotalDirectLaborCost.Text, txtEquipmentsCost.Text, txtTotalOperationCosts.Text, txtTotalDirectCost.Text, txtOverHeadAllocation.Text, txtTotalLocaladministrativeCost.Text, txtPhoneAndFax.Text, txtGeneralLibilityInsurance.Text, txtTotalLocalOverheadCost.Text, txtOverAllTotalCost.Text, txtRatePerPostAsPerMargin.Text, txtSumOfTotalPost.Text, txtSumOfTotalHrs.Text, txtVoccationHrs.Text, txtSickProvision.Text, txtTrainingHrs.Text, txtOTRate.Text, txtHolidayRate.Text, txtOT7thDayRate.Text, txtSickLeaveValue.Text, txtVoccationDayValue.Text, txtBonusPerMonthPerGuardRate.Text, txtPfRate.Text, txtSocialWelfareRate.Text, txtWorkmenCommensationRate.Text, txtTotalEquipmentCost.Text, txtOverheadAllocationRate.Text, txtPhoneFaxRate.Text, txtGeneralLiabilityInsuranceRate.Text, txtIncentiveMonthlyOrYearly.Text, BaseUserID.ToString());
        gvCostSheetService.EditIndex = -1;
        FillgvCostSheetService();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvCostSheetService control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetService_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion
    #endregion

    #region Grid View Items
    #region GridView Controles events
    /// <summary>
    /// Fillgvs the cost sheet item.
    /// </summary>
    protected void FillgvCostSheetItem()
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objsales.CostSheetItemGet(BaseLocationAutoID, txtCostSheetNo.Text, ddlCostSheetAmendNo.SelectedItem.Value.ToString());
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                //to fix empety gridview

                if (dt.Rows.Count == 0)
                {
                    dtflag = 0;
                    dt.Rows.Add(dt.NewRow());
                    gvCostSheetItem.DataKeyNames = new string[] { "LocationAutoId", "CostSheetNo", "CostSheetAmendmentNo", "CostSheetLineNo" };
                    gvCostSheetItem.DataSource = dt;
                    gvCostSheetItem.DataBind();
                    if (dtflag == 0)//to fix empety gridview
                    {
                        gvCostSheetItem.Rows[0].Visible = false;
                    }
                }
                else if (dt.Rows.Count > 0)
                {
                    gvCostSheetItem.DataKeyNames = new string[] { "LocationAutoId", "CostSheetNo", "CostSheetAmendmentNo", "CostSheetLineNo" };
                    gvCostSheetItem.DataSource = dt;
                    gvCostSheetItem.DataBind();
                }
            }
        }
    }
    /// <summary>
    /// Fillddlgvs the type of item.
    /// </summary>
    /// <param name="ddlgvTypeOfItem">The DDLGV type of item.</param>
    /// <param name="ddlgvItemTypeCode">The DDLGV item type code.</param>
    protected void FillddlgvTypeOfItem(DropDownList ddlgvTypeOfItem, DropDownList ddlgvItemTypeCode)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.SaleItemTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlgvTypeOfItem.DataSource = ds.Tables[0];
            ddlgvTypeOfItem.DataValueField = "ItemTypeCode";
            ddlgvTypeOfItem.DataTextField = "ItemDesc";
            ddlgvTypeOfItem.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlgvTypeOfItem.Items.Add(li);
        }
        FillddlgvItemTypeCode(ddlgvTypeOfItem, ddlgvItemTypeCode);
    }
    /// <summary>
    /// Fillddlgvs the item type code.
    /// </summary>
    /// <param name="ddlgvTypeOfItem">The DDLGV type of item.</param>
    /// <param name="ddlgvItemTypeCode">The DDLGV item type code.</param>
    protected void FillddlgvItemTypeCode(DropDownList ddlgvTypeOfItem, DropDownList ddlgvItemTypeCode)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.SaleItemTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlgvItemTypeCode.DataSource = ds.Tables[0];
            ddlgvItemTypeCode.DataValueField = "ItemTypeCode";
            ddlgvItemTypeCode.DataTextField = "ItemDesc";
            ddlgvItemTypeCode.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlgvItemTypeCode.Items.Add(li);
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChangedFooter event of the ddlgvTypeOfItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvTypeOfItem_SelectedIndexChangedFooter(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the SelectedIndexChangedEdit event of the ddlgvTypeOfItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvTypeOfItem_SelectedIndexChangedEdit(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the SelectedIndexChangedFooter event of the ddlgvItemTypeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvItemTypeCode_SelectedIndexChangedFooter(object sender, EventArgs e)
    {
        DropDownList ddlgvItemTypeCode = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)ddlgvItemTypeCode.NamingContainer;
        TextBox txtItemDesc = (TextBox)gvCostSheetItem.FooterRow.FindControl("txtItemDesc");
        txtItemDesc.Text = ddlgvItemTypeCode.SelectedItem.Text;
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager1.SetFocus(txtItemDesc);
    }
    /// <summary>
    /// Handles the SelectedIndexChangedEdit event of the ddlgvItemTypeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvItemTypeCode_SelectedIndexChangedEdit(object sender, EventArgs e)
    {
        DropDownList ddlgvItemTypeCode = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)ddlgvItemTypeCode.NamingContainer;
        TextBox txtItemDesc = (TextBox)gvCostSheetItem.Rows[gvRow.RowIndex].FindControl("txtItemDesc");
        txtItemDesc.Text = ddlgvItemTypeCode.SelectedItem.Text;
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager1.SetFocus(txtItemDesc);
    }
    /// <summary>
    /// Handles the SelectedIndexChangedItemFooter event of the ddlgvUOM control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvUOM_SelectedIndexChangedItemFooter(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the SelectedIndexChangedItemEdit event of the ddlgvUOM control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvUOM_SelectedIndexChangedItemEdit(object sender, EventArgs e)
    {
    }
    #endregion
    #region Grid View Items Events
    /// <summary>
    /// Handles the RowDataBound event of the gvCostSheetItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false)
        {
            gvCostSheetItem.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            //Check Delete Access AND //Delete button will not show when the Cost Sheet not in Fresh or amend mode
            if (IsDeleteAccess == false || (txtCostSheetStatus.Text != Resources.Resource.Amend && txtCostSheetStatus.Text != Resources.Resource.Fresh))
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
                    ImgbtnDelete.Visible = true;
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }

            //Check Modify Access AND //Edit button will not show when the Cost Sheet not in Fresh or amend mode
            if (IsModifyAccess == false || (txtCostSheetStatus.Text != Resources.Resource.Amend && txtCostSheetStatus.Text != Resources.Resource.Fresh))
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

                DropDownList ddlgvTypeOfItem = (DropDownList)e.Row.FindControl("ddlgvTypeOfItem");
                HiddenField hfTypeOfItem = (HiddenField)e.Row.FindControl("hfTypeOfItem");

                DropDownList ddlgvItemTypeCode = (DropDownList)e.Row.FindControl("ddlgvItemTypeCode");
                HiddenField hfItemTypeCode = (HiddenField)e.Row.FindControl("hfItemTypeCode");

                if (ddlgvTypeOfItem != null && hfTypeOfItem != null && ddlgvItemTypeCode != null && hfItemTypeCode != null)
                {
                    FillddlgvTypeOfItem(ddlgvTypeOfItem, ddlgvItemTypeCode);
                    ddlgvTypeOfItem.SelectedIndex = ddlgvTypeOfItem.Items.IndexOf(ddlgvTypeOfItem.Items.FindByValue(hfTypeOfItem.Value.ToString()));
                    FillddlgvItemTypeCode(ddlgvTypeOfItem, ddlgvItemTypeCode);
                    ddlgvItemTypeCode.SelectedIndex = ddlgvItemTypeCode.Items.IndexOf(ddlgvItemTypeCode.Items.FindByValue(hfItemTypeCode.Value.ToString()));
                }

                DropDownList ddlgvUOM = (DropDownList)e.Row.FindControl("ddlgvUOM");
                HiddenField hfUOM = (HiddenField)e.Row.FindControl("hfUOM");
                if (ddlgvUOM != null && hfUOM != null)
                {
                    FillddlgvUOM(ddlgvUOM);
                    ddlgvUOM.SelectedIndex = ddlgvUOM.Items.IndexOf(ddlgvUOM.Items.FindByValue(hfUOM.Value.ToString()));
                }
                TextBox txtItemDesc = (TextBox)e.Row.FindControl("txtItemDesc");
                if (txtItemDesc != null)
                { txtItemDesc.Attributes.Add("readonly", "readonly"); }

                TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
                if (txtQty != null) { TextBoxFloadValidation(txtQty); }

                TextBox txtQuotedRate = (TextBox)e.Row.FindControl("txtQuotedRate");
                if (txtQuotedRate != null) { TextBoxFloadValidation(txtQuotedRate); }

                TextBox txtTotal = (TextBox)e.Row.FindControl("txtTotal");
                if (txtTotal != null) { TextBoxFloadValidation(txtTotal); }

                TextBox txtDepreciationMonthsForEquipment = (TextBox)e.Row.FindControl("txtDepreciationMonthsForEquipment");
                if (txtDepreciationMonthsForEquipment != null) { TextBoxFloadValidation(txtDepreciationMonthsForEquipment); }

                TextBox txtEquipmentValuePerYear = (TextBox)e.Row.FindControl("txtEquipmentValuePerYear");
                if (txtEquipmentValuePerYear != null) { TextBoxFloadValidation(txtEquipmentValuePerYear); }

            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            //Check Write Access AND //Footer will not show when the Cost Sheet not in Fresh or amend mode
            if (IsWriteAccess == false || (txtCostSheetStatus.Text != Resources.Resource.Amend && txtCostSheetStatus.Text != Resources.Resource.Fresh))
            {
                gvCostSheetItem.ShowFooter = false;
            }
            else
            {
                gvCostSheetItem.ShowFooter = true;

                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                { ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');"; }

                DropDownList ddlgvTypeOfItem = (DropDownList)e.Row.FindControl("ddlgvTypeOfItem");
                DropDownList ddlgvItemTypeCode = (DropDownList)e.Row.FindControl("ddlgvItemTypeCode");

                if (ddlgvTypeOfItem != null && ddlgvItemTypeCode != null)
                {
                    FillddlgvTypeOfItem(ddlgvTypeOfItem, ddlgvItemTypeCode);
                }

                DropDownList ddlgvUOM = (DropDownList)e.Row.FindControl("ddlgvUOM");
                if (ddlgvUOM != null)
                { FillddlgvUOM(ddlgvUOM); }

                TextBox txtItemDesc = (TextBox)e.Row.FindControl("txtItemDesc");
                if (txtItemDesc != null)
                { txtItemDesc.Attributes.Add("readonly", "readonly"); }

                if (ddlgvItemTypeCode != null && txtItemDesc != null)
                { txtItemDesc.Text = ddlgvItemTypeCode.SelectedItem.Text; }

                TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
                if (txtQty != null) { TextBoxFloadValidation(txtQty); }

                TextBox txtQuotedRate = (TextBox)e.Row.FindControl("txtQuotedRate");
                if (txtQuotedRate != null) { TextBoxFloadValidation(txtQuotedRate); }

                TextBox txtTotal = (TextBox)e.Row.FindControl("txtTotal");
                if (txtTotal != null) { TextBoxFloadValidation(txtTotal); }

                TextBox txtDepreciationMonthsForEquipment = (TextBox)e.Row.FindControl("txtDepreciationMonthsForEquipment");
                if (txtDepreciationMonthsForEquipment != null) { TextBoxFloadValidation(txtDepreciationMonthsForEquipment); }

                TextBox txtEquipmentValuePerYear = (TextBox)e.Row.FindControl("txtEquipmentValuePerYear");
                if (txtEquipmentValuePerYear != null) { TextBoxFloadValidation(txtEquipmentValuePerYear); }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvCostSheetItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DropDownList ddlgvTypeOfItem = (DropDownList)gvCostSheetItem.FooterRow.FindControl("ddlgvTypeOfItem");
        DropDownList ddlgvItemTypeCode = (DropDownList)gvCostSheetItem.FooterRow.FindControl("ddlgvItemTypeCode");
        TextBox txtItemDesc = (TextBox)gvCostSheetItem.FooterRow.FindControl("txtItemDesc");
        DropDownList ddlgvUOM = (DropDownList)gvCostSheetItem.FooterRow.FindControl("ddlgvUOM");
        TextBox txtQty = (TextBox)gvCostSheetItem.FooterRow.FindControl("txtQty");
        TextBox txtQuotedRate = (TextBox)gvCostSheetItem.FooterRow.FindControl("txtQuotedRate");
        TextBox txtTotal = (TextBox)gvCostSheetItem.FooterRow.FindControl("txtTotal");
        TextBox txtDepreciationMonthsForEquipment = (TextBox)gvCostSheetItem.FooterRow.FindControl("txtDepreciationMonthsForEquipment");
        TextBox txtEquipmentValuePerYear = (TextBox)gvCostSheetItem.FooterRow.FindControl("txtEquipmentValuePerYear");

        if (e.CommandName == "Add")
        {
            if (txtCostSheetNo.Text.Length > 0 && ddlCostSheetAmendNo.SelectedItem.Value.ToString().Length > 0 && hfIsMAXCostSheetAmendNo.Value == "MAX")
            {
                if (txtQty != null) { IfBlankSetValueToZero(txtQty); }
                if (txtQuotedRate != null) { IfBlankSetValueToZero(txtQuotedRate); }
                if (txtTotal != null) { IfBlankSetValueToZero(txtTotal); }
                if (txtDepreciationMonthsForEquipment != null) { IfBlankSetValueToZero(txtDepreciationMonthsForEquipment); }
                if (txtEquipmentValuePerYear != null) { IfBlankSetValueToZero(txtEquipmentValuePerYear); }

                // To Insert a New Row
                BL.Sales objSales = new BL.Sales();
                DataSet ds = new DataSet();
                ds = objSales.CostSheetItemInsert(BaseLocationAutoID.ToString(), txtCostSheetNo.Text, ddlCostSheetAmendNo.SelectedItem.Value.ToString(), ddlgvTypeOfItem.SelectedItem.Value.ToString(), ddlgvItemTypeCode.SelectedItem.Value.ToString(), txtItemDesc.Text, ddlgvUOM.SelectedItem.Value.ToString(), txtQty.Text, txtQuotedRate.Text, txtTotal.Text, txtDepreciationMonthsForEquipment.Text, txtEquipmentValuePerYear.Text, BaseUserID.ToString());
                gvCostSheetItem.EditIndex = -1;
                FillgvCostSheetItem();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
        }
        else if (e.CommandName == "Reset")
        {
            txtQty.Text = "";
            txtQuotedRate.Text = "";
            txtTotal.Text = "";
            txtDepreciationMonthsForEquipment.Text = "";
            txtEquipmentValuePerYear.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvCostSheetItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetItem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCostSheetItem.EditIndex = -1;
        FillgvCostSheetItem();
    }
    /// <summary>
    /// Handles the RowEditing event of the gvCostSheetItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetItem_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCostSheetItem.EditIndex = e.NewEditIndex;
        FillgvCostSheetItem();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvCostSheetItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblCostSheetLineNo = (Label)gvCostSheetItem.Rows[e.RowIndex].FindControl("lblCostSheetLineNo");
        DropDownList ddlgvTypeOfItem = (DropDownList)gvCostSheetItem.Rows[e.RowIndex].FindControl("ddlgvTypeOfItem");
        DropDownList ddlgvItemTypeCode = (DropDownList)gvCostSheetItem.Rows[e.RowIndex].FindControl("ddlgvItemTypeCode");
        TextBox txtItemDesc = (TextBox)gvCostSheetItem.Rows[e.RowIndex].FindControl("txtItemDesc");
        DropDownList ddlgvUOM = (DropDownList)gvCostSheetItem.Rows[e.RowIndex].FindControl("ddlgvUOM");
        TextBox txtQty = (TextBox)gvCostSheetItem.Rows[e.RowIndex].FindControl("txtQty");
        TextBox txtQuotedRate = (TextBox)gvCostSheetItem.Rows[e.RowIndex].FindControl("txtQuotedRate");
        TextBox txtTotal = (TextBox)gvCostSheetItem.Rows[e.RowIndex].FindControl("txtTotal");
        TextBox txtDepreciationMonthsForEquipment = (TextBox)gvCostSheetItem.Rows[e.RowIndex].FindControl("txtDepreciationMonthsForEquipment");
        TextBox txtEquipmentValuePerYear = (TextBox)gvCostSheetItem.Rows[e.RowIndex].FindControl("txtEquipmentValuePerYear");

        if (txtQty != null) { IfBlankSetValueToZero(txtQty); }
        if (txtQuotedRate != null) { IfBlankSetValueToZero(txtQuotedRate); }
        if (txtTotal != null) { IfBlankSetValueToZero(txtTotal); }
        if (txtDepreciationMonthsForEquipment != null) { IfBlankSetValueToZero(txtDepreciationMonthsForEquipment); }
        if (txtEquipmentValuePerYear != null) { IfBlankSetValueToZero(txtEquipmentValuePerYear); }

        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.CostSheetItemUpdate(BaseLocationAutoID.ToString(), txtCostSheetNo.Text, ddlCostSheetAmendNo.SelectedItem.Value.ToString(), lblCostSheetLineNo.Text, ddlgvTypeOfItem.SelectedItem.Value.ToString(),ddlgvItemTypeCode.SelectedItem.Value.ToString(), txtItemDesc.Text, ddlgvUOM.SelectedItem.Value.ToString(), txtQty.Text, txtQuotedRate.Text, txtTotal.Text, txtDepreciationMonthsForEquipment.Text, txtEquipmentValuePerYear.Text, BaseUserID.ToString());
        gvCostSheetItem.EditIndex = -1;
        FillgvCostSheetItem();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }


    }
    /// <summary>
    /// Handles the RowDeleting event of the gvCostSheetItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvCostSheetItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion
    #endregion

    #region Buttons Events
    /// <summary>
    /// Ifs the blank set value to zero.
    /// </summary>
    /// <param name="ObjTextBox">The object text box.</param>
    protected void IfBlankSetValueToZero(TextBox ObjTextBox)
    {
        if (ObjTextBox.Text.Length == 0)
        {
            ObjTextBox.Text = "0";
        }
    }
    /// <summary>
    /// Validates the numeric fields to save.
    /// </summary>
    protected void ValidateNumericFieldsToSave()
    {
        IfBlankSetValueToZero(txtBankGuaranteeAmount);
        IfBlankSetValueToZero(txtBankGuaranteeAmount);
        IfBlankSetValueToZero(txtContractStampAmount);
        IfBlankSetValueToZero(txtAirportFeeAmount);
        IfBlankSetValueToZero(txtTotalequipmentCostyearly);
        IfBlankSetValueToZero(txtOtherAdditionalCharges);
        IfBlankSetValueToZero(txtTotalAmount);
        IfBlankSetValueToZero(txtTotalAmountWithMargin);

        IfBlankSetValueToZero(txtMarginPercentage);
        IfBlankSetValueToZero(txtEquipmentRental);
        IfBlankSetValueToZero(txtTotalSellingPrice);
        IfBlankSetValueToZero(txtMinusCost);
        IfBlankSetValueToZero(txtGrossProfit);
        IfBlankSetValueToZero(txtGrossMargin);
        IfBlankSetValueToZero(txtContributionHead);

        IfBlankSetValueToZero(txtEquipmentRentalTotal);
        IfBlankSetValueToZero(txtTotalSellingPriceTotal);
        IfBlankSetValueToZero(txtMinusCostTotal);
        IfBlankSetValueToZero(txtGrossProfitTotal);
        IfBlankSetValueToZero(txtGrossMarginTotal);
        IfBlankSetValueToZero(txtContributionHeadTotal);
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtCostSheetNo.Text.Length == 0 && txtCostSheetStatus.Text.Length > 0 && txtCostSheetStatus.Text == Resources.Resource.Fresh.ToString())
        {
            ValidateNumericFieldsToSave();
            BL.Sales objSales = new BL.Sales();
            DataSet ds = new DataSet();

            ds = objSales.CostSheetInsert(BaseLocationAutoID, txtCostSheetDate.Text, txtCostSheetStatus.Text, ddlClient.SelectedItem.Value.ToString(), txtPreparedBy.Text, txtPreparedDate.Text, txtVerifiedBy.Text, txtVerifiedDate.Text, txtApprovedBy.Text, txtApprovedDate.Text, txtMarginPercentage.Text, txtBankGuaranteeAmount.Text, txtContractStampAmount.Text, txtAirportFeeAmount.Text, txtTotalequipmentCostyearly.Text, txtOtherAdditionalCharges.Text, txtTotalAmount.Text, txtTotalAmountWithMargin.Text, txtEquipmentRental.Text, txtTotalSellingPrice.Text, txtMinusCost.Text, txtGrossProfit.Text, txtGrossMargin.Text, txtContributionHead.Text, txtEquipmentRentalTotal.Text, txtTotalSellingPriceTotal.Text, txtMinusCostTotal.Text, txtGrossProfitTotal.Text, txtGrossMarginTotal.Text, txtContributionHeadTotal.Text, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtCostSheetNo.Text = ds.Tables[1].Rows[0]["CostSheetNo"].ToString();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (txtCostSheetNo.Text != "")
                {
                    FillddlCostSheetAmendNo();
                    ViewMode();
                }
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        EditMode();
    }
    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtCostSheetNo.Text.Length > 0 && txtCostSheetStatus.Text.Length > 0 && ddlCostSheetAmendNo.SelectedItem.Value.ToString() != "" && (txtCostSheetStatus.Text == Resources.Resource.Fresh.ToString() || txtCostSheetStatus.Text == Resources.Resource.Amend.ToString()))
        {
            ValidateNumericFieldsToSave();
            BL.Sales objSales = new BL.Sales();
            DataSet ds = new DataSet();

            ds = objSales.CostSheetUpdate(BaseLocationAutoID, txtCostSheetNo.Text, ddlCostSheetAmendNo.SelectedItem.Value.ToString(), txtCostSheetDate.Text, txtCostSheetStatus.Text, ddlClient.SelectedItem.Value.ToString(), txtPreparedBy.Text, txtPreparedDate.Text, txtVerifiedBy.Text, txtVerifiedDate.Text, txtApprovedBy.Text, txtApprovedDate.Text, txtMarginPercentage.Text, txtBankGuaranteeAmount.Text, txtContractStampAmount.Text, txtAirportFeeAmount.Text, txtTotalequipmentCostyearly.Text, txtOtherAdditionalCharges.Text, txtTotalAmount.Text, txtTotalAmountWithMargin.Text, txtEquipmentRental.Text, txtTotalSellingPrice.Text, txtMinusCost.Text, txtGrossProfit.Text, txtGrossMargin.Text, txtContributionHead.Text, txtEquipmentRentalTotal.Text, txtTotalSellingPriceTotal.Text, txtMinusCostTotal.Text, txtGrossProfitTotal.Text, txtGrossMarginTotal.Text, txtContributionHeadTotal.Text, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                FillddlCostSheetAmendNo();
                ViewMode();
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length > 0)
        {
            ddlClient.SelectedValue = Request.QueryString["ClientCode"].ToString();
        }
        FillddlCostSheetAmendNo();
        ViewMode();
    }
    /// <summary>
    /// Handles the Click event of the btnAmend control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAmend_Click(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
       Response.Redirect("../Sales/CostSheetList.aspx");
    }
    
    #endregion

    #region Page Mode
    /// <summary>
    /// Adds the new mode.
    /// </summary>
    protected void AddNewMode()
    {
        txtCostSheetStatus.Text = Resources.Resource.Fresh.ToString();

        btnSave.Visible = false;
        btnEdit.Visible = false;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnCancel.Visible = false;
        btnGenerateCostSheetNo.Visible = true;

        CostSheetGrid1.Visible = false;
        CostSheetGrid2.Visible = false;

        btnAmend.Visible = false;
        btnAuthorize.Visible = false;
    }
    /// <summary>
    /// Views the mode.
    /// </summary>
    protected void ViewMode()
    {
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
        btnGenerateCostSheetNo.Visible = false;
        ddlClient.Enabled = false;

        CostSheetGrid1.Visible = true;
        CostSheetGrid2.Visible = true;

        HdrControlesReadOnly();

        if (txtCostSheetStatus.Text == Resources.Resource.Fresh.ToString() || txtCostSheetStatus.Text == Resources.Resource.Amend.ToString())
        {
            btnEdit.Visible = true;
            btnDelete.Visible = true;

            btnAmend.Visible = false;
            btnAuthorize.Visible = true;
        }
        else if (txtCostSheetStatus.Text == Resources.Resource.Authorized.ToString())
        {
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            btnAmend.Visible = true;
            btnAuthorize.Visible = false;
        }
    }

    /// <summary>
    /// Edits the mode.
    /// </summary>
    protected void EditMode()
    {
        btnSave.Visible = false;
        btnEdit.Visible = false;
        btnUpdate.Visible = true;
        btnDelete.Visible = false;
        btnCancel.Visible = true;
        btnGenerateCostSheetNo.Visible = false;
        ddlClient.Enabled = false;

        CostSheetGrid1.Visible = true;
        CostSheetGrid2.Visible = true;

        btnAmend.Visible = false;
        btnAuthorize.Visible = false;

        HdrControlesEditable();
    }
    /// <summary>
    /// HDRs the controles read only.
    /// </summary>
    protected void HdrControlesReadOnly()
    {
        txtPreparedBy.Attributes.Add("readonly", "readonly");
        txtApprovedBy.Attributes.Add("readonly", "readonly");
        txtVerifiedBy.Attributes.Add("readonly", "readonly");

        txtBankGuaranteeAmount.Attributes.Add("readonly", "readonly");
        txtContractStampAmount.Attributes.Add("readonly", "readonly");
        txtAirportFeeAmount.Attributes.Add("readonly", "readonly");
        txtTotalequipmentCostyearly.Attributes.Add("readonly", "readonly");
        txtOtherAdditionalCharges.Attributes.Add("readonly", "readonly");
        txtTotalAmount.Attributes.Add("readonly", "readonly");
        txtTotalAmountWithMargin.Attributes.Add("readonly", "readonly");

        txtMarginPercentage.Attributes.Add("readonly", "readonly");
        txtEquipmentRental.Attributes.Add("readonly", "readonly");
        txtTotalSellingPrice.Attributes.Add("readonly", "readonly");
        txtMinusCost.Attributes.Add("readonly", "readonly");
        txtGrossProfit.Attributes.Add("readonly", "readonly");
        txtGrossMargin.Attributes.Add("readonly", "readonly");
        txtContributionHead.Attributes.Add("readonly", "readonly");

        txtEquipmentRentalTotal.Attributes.Add("readonly", "readonly");
        txtTotalSellingPriceTotal.Attributes.Add("readonly", "readonly");
        txtMinusCostTotal.Attributes.Add("readonly", "readonly");
        txtGrossProfitTotal.Attributes.Add("readonly", "readonly");
        txtGrossMarginTotal.Attributes.Add("readonly", "readonly");
        txtContributionHeadTotal.Attributes.Add("readonly", "readonly");
    }
    /// <summary>
    /// HDRs the controles editable.
    /// </summary>
    protected void HdrControlesEditable()
    {
        txtPreparedBy.Attributes.Remove("readonly");
        txtApprovedBy.Attributes.Remove("readonly");
        txtVerifiedBy.Attributes.Remove("readonly");

        txtBankGuaranteeAmount.Attributes.Remove("readonly");
        txtContractStampAmount.Attributes.Remove("readonly");
        txtAirportFeeAmount.Attributes.Remove("readonly");
        txtTotalequipmentCostyearly.Attributes.Remove("readonly");
        txtOtherAdditionalCharges.Attributes.Remove("readonly");
        txtTotalAmount.Attributes.Remove("readonly");
        txtTotalAmountWithMargin.Attributes.Remove("readonly");

        txtMarginPercentage.Attributes.Remove("readonly");
        txtEquipmentRental.Attributes.Remove("readonly");
        txtTotalSellingPrice.Attributes.Remove("readonly");
        txtMinusCost.Attributes.Remove("readonly");
        txtGrossProfit.Attributes.Remove("readonly");
        txtGrossMargin.Attributes.Remove("readonly");
        txtContributionHead.Attributes.Remove("readonly");

        txtEquipmentRentalTotal.Attributes.Remove("readonly");
        txtTotalSellingPriceTotal.Attributes.Remove("readonly");
        txtMinusCostTotal.Attributes.Remove("readonly");
        txtGrossProfitTotal.Attributes.Remove("readonly");
        txtGrossMarginTotal.Attributes.Remove("readonly");
        txtContributionHeadTotal.Attributes.Remove("readonly");

    }
    #endregion
    
}
