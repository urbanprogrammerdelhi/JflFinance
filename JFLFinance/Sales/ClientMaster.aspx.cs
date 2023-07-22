// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ClientMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Transactions;
using BL;

/// <summary>
/// Client Master Screen Code behind
/// </summary>
public partial class Sales_ClientMaster : BasePage //System.Web.UI.Page
{
    #region Properties

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsReadAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    #region Page functions
    /// <summary>
    /// Page Lode Event
    /// </summary>
    /// <param name="sender">object of the page</param>
    /// <param name="e">Event Args</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EnableButtons();
            if (IsReadAccess)
            {
                ValidationOnControles();
                BL.MastersManagement objMastersManagement = new BL.MastersManagement();
                using (DataSet ds = objMastersManagement.IndustryTypeMasterGet(BaseCompanyCode))
                {
                    ddlIndustryType.DataSource = ds.Tables[0];
                    ddlIndustryType.DataValueField = "ItemDesc";
                    ddlIndustryType.DataTextField = "ItemDesc";
                    ddlIndustryType.DataBind();
                }

                ListItem li = new ListItem();
                li.Text = Resources.Resource.NotKnown;
                li.Value = Resources.Resource.NotKnown;
                ddlIndustryType.Items.Insert(0, li);

                FillddlGroupZip();

                using (DataSet ds = objMastersManagement.QuickCodeClassificationGet(BaseCompanyCode))
                {
                    ddlClassification.DataSource = ds.Tables[0];
                    ddlClassification.DataValueField = "ItemDesc";
                    ddlClassification.DataTextField = "ItemDesc";
                    ddlClassification.DataBind();
                }

                ////ListItem li = new ListItem();
                li = new ListItem();
                li.Text = Resources.Resource.NotKnown;
                li.Value = Resources.Resource.NotKnown;
                ddlClassification.Items.Insert(0, li);

                using (DataSet ds = objMastersManagement.CustomerTypeGet(BaseCompanyCode))
                {
                    ddlCustomerType.DataSource = ds.Tables[0];
                    ddlCustomerType.DataValueField = "ItemDesc";
                    ddlCustomerType.DataTextField = "ItemDesc";
                    ddlCustomerType.DataBind();
                }

                if (ddlCustomerType.Text == "")
                {
                    li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlCustomerType.Items.Add(li);
                    DisableButtons();
                }

                using (DataSet ds = objMastersManagement.CustomerSectorGet(BaseCompanyCode))
                {
                    ddlSector.DataSource = ds.Tables[0];
                    ddlSector.DataValueField = "ItemDesc";
                    ddlSector.DataTextField = "ItemDesc";
                    ddlSector.DataBind();
                }

                li = new ListItem();
                li.Text = Resources.Resource.NotKnown;
                li.Value = Resources.Resource.NotKnown;
                ddlSector.Items.Insert(0, li);

                using (DataSet ds = objMastersManagement.CustomerSubsegmentGet(BaseCompanyCode))
                {
                    ddlSubSegment.DataSource = ds.Tables[0];
                    ddlSubSegment.DataValueField = "ItemDesc";
                    ddlSubSegment.DataTextField = "ItemDesc";
                    ddlSubSegment.DataBind();
                }

                li = new ListItem();
                li.Text = Resources.Resource.NotKnown;
                li.Value = Resources.Resource.NotKnown;
                ddlSubSegment.Items.Insert(0, li);

                using (DataSet ds = objMastersManagement.CountryMasterGetAll(BaseCompanyCode))
                {
                    ddlCountryCode.DataSource = ds.Tables[0];
                    ddlCountryCode.DataValueField = "CountryCode";
                    ddlCountryCode.DataTextField = "Country";
                    ddlCountryCode.DataBind();

                    ddlCountryOrigin.DataSource = ds.Tables[0];
                    ddlCountryOrigin.DataValueField = "CountryCode";
                    ddlCountryOrigin.DataTextField = "Country";
                    ddlCountryOrigin.DataBind();
                }

                if (ddlCountryCode.Text == "")
                {
                    li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlCountryCode.Items.Add(li);
                    DisableButtons();
                }

                if (ddlCountryOrigin.Text == "")
                {
                    li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlCountryOrigin.Items.Add(li);
                    DisableButtons();
                }

                imgEmployeeNumberSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtOurContactPersonEmpNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");

                if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length != 0)
                {

                    //Manish 21-06-2012 if data flow from Interface and  some fileds are not editable
                    getAllRecordsNonEditable();
                    txtClientCode.Text = Request.QueryString["ClientCode"].ToString();
                    FillDetails();
                    txtManualClientCode.ReadOnly = false;
                    lbCheckAvailability.Visible = false;

                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                    btnClientDetails.Enabled = true;
                    btnCreateAsmtAddress.Enabled = true;

                    if (IsModifyAccess == true)
                    {
                        btnUpdate.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
                        btnCancel.Enabled = false;
                    }

                    if (txtClientCode.Text != "")
                    {
                        txtClientCodeConst.Text = txtClientCode.Text;
                        txtClientNameConst.Text = txtClientName.Text;
                        txtManualClientCodeConst.Text = txtManualClientCode.Text;
                        txtClientCodeAdd.Text = txtClientCode.Text;
                        txtClientNameAdd.Text = txtClientName.Text;
                        btnAddCancel.Enabled = true;
                        btnAddReset.Enabled = true;

                        if (txtAbvtClientName.Text == "" || txtPvtCompNo.Text == "" || txtSectorNo.Text == "")
                        {
                            btnAddSubmit.Enabled = true;
                            btnAddUpdate.Enabled = false;
                        }
                        else
                        {
                            btnAddSubmit.Enabled = false;
                            btnAddUpdate.Enabled = true;
                        }

                        FillConstraintTab();
                        
                    }
                }
                else
                {
                    //Manish 21-06-2012  control set to Enable.
                    getAllRecordsEditable();
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    btnClientDetails.Enabled = false;
                    btnCreateAsmtAddress.Enabled = false;

                    if (IsWriteAccess == true && ddlCountryCode.Items.Count > 0 && ddlCountryCode.SelectedItem.Value != "")
                    {
                        btnSubmit.Enabled = true;
                        btnReset.Enabled = true;
                    }
                    else
                    {
                        btnSubmit.Enabled = false;
                        btnReset.Enabled = false;
                    }
                }

                if (txtClientCode.Enabled == true)
                {
                    txtClientCode.Focus();
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    /// <summary>
    /// Fills the constraint tab.
    /// </summary>
    private void FillConstraintTab()
    {
        FillgvClientConstraint();
        FillgvLanguage();
        FillgvOSkill();
        FillgvQualification();
        FillgvTraining();
    }

    /// <summary>
    /// Validation on control
    /// </summary>
    private void ValidationOnControles()
    {
        txtTurnover.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
        txtTurnover.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
    }

    /// <summary>
    /// Disable Buttons
    /// </summary>
    private void DisableButtons()
    {
        btnCancel.Enabled = false;
        btnUpdate.Enabled = false;
        btnSubmit.Enabled = false;
        btnReset.Enabled = false;
        btnClientDetails.Enabled = false;
        btnCreateAsmtAddress.Enabled = false;

        /*V1.1*/
        btnAddCancel.Enabled = false;
        btnAddSubmit.Enabled = false;
        btnAddReset.Enabled = false;
        btnAddUpdate.Enabled = false;
        /*V1.1*/
    }

    /// <summary>
    /// Enable Buttons
    /// </summary>
    private void EnableButtons()
    {
        btnCancel.Enabled = true;
        btnUpdate.Enabled = true;
        btnSubmit.Enabled = true;
        btnReset.Enabled = true;
        btnClientDetails.Enabled = true;
        btnCreateAsmtAddress.Enabled = true;

        /************V1.0************/
        BL.Sales objSale = new BL.Sales();
        using (DataTable dtSale = objSale.SetAutoGenerateCodeForClient(BaseCompanyCode, "AutoGenerateClientCode".ToString()))
        {
            if (dtSale.Rows.Count > 0)
            {
                if (dtSale.Rows[0]["ParamValue1"].ToString() == "0")
                {
                    txtClientCode.Enabled = true;
                    txtClientCode.Focus();
                }
                else
                {
                    txtClientCode.Enabled = false;
                }
            }
            else
            {
                DisableButtons();
            }
        }
    }

    /// <summary>
    /// Fill Client Details
    /// </summary>
    private void FillDetails()
    {
        BL.Sales objSales = new BL.Sales();
        using (DataSet ds = objSales.ClientDetailGet(txtClientCode.Text))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtManualClientCode.Text = ds.Tables[0].Rows[0]["ManualClientCode"].ToString();
                txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtClientAddressLine1.Text = ds.Tables[0].Rows[0]["ClientAddressLine1"].ToString();
                txtClientAddressLine2.Text = ds.Tables[0].Rows[0]["ClientAddressLine2"].ToString();
                txtClientAddressLine3.Text = ds.Tables[0].Rows[0]["ClientAddressLine3"].ToString();
                txtWebSite.Text = ds.Tables[0].Rows[0]["WebSite"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                ddlGroupZip.SelectedValue = ds.Tables[0].Rows[0]["GroupZipCode"].ToString();
                FillddlZip();
                ddlZip.SelectedValue = ds.Tables[0].Rows[0]["Pin"].ToString();
                ////txtPin.Text = ds.Tables[0].Rows[0]["Pin"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtContactPersonEmail.Text = ds.Tables[0].Rows[0]["ContactPersonEmail"].ToString();
                txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                ddlCountryCode.SelectedValue = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                txtClientContactPerson.Text = ds.Tables[0].Rows[0]["ClientContactPerson"].ToString();
                txtOurContactPersonEmpNo.Text = ds.Tables[0].Rows[0]["OurContactPersonEmpNo"].ToString();
                ddlCountryOrigin.SelectedValue = ds.Tables[0].Rows[0]["CountryOrigin"].ToString();
                ddlCustomerType.SelectedValue = ds.Tables[0].Rows[0]["CustomerType"].ToString();
                cbIsInternational.Checked = bool.Parse(ds.Tables[0].Rows[0]["IsInternational"].ToString());
                txtClientContactPersonDesignation.Text = ds.Tables[0].Rows[0]["ClientContactPersonDesignation"].ToString();
                txtOurContactPerson.Text = ds.Tables[0].Rows[0]["OurContactPerson"].ToString();
                ddlIndustryType.SelectedValue = ds.Tables[0].Rows[0]["IndustryType"].ToString();
                ddlSector.SelectedValue = ds.Tables[0].Rows[0]["Sector"].ToString();
                txtTurnover.Text = ds.Tables[0].Rows[0]["Turnover"].ToString();
                txtClientContactPersonMobile.Text = ds.Tables[0].Rows[0]["ClientContactpersonMobile"].ToString();
                txtOurContactPersonMobile.Text = ds.Tables[0].Rows[0]["OurContactPersonMobile"].ToString();
                ddlClassification.SelectedValue = ds.Tables[0].Rows[0]["Classification"].ToString();
                ddlSubSegment.SelectedValue = ds.Tables[0].Rows[0]["SubSegment"].ToString();
                txtComments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
                txtOtherLanguageClientName.Text = ds.Tables[0].Rows[0]["MultiLingualClientName"].ToString();
                HFOtherLanguageClientName.Value = ds.Tables[0].Rows[0]["MultiLingualClientName"].ToString();
                txtOtherLanguageAdd1.Text = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine1"].ToString();
                HFOtherLanguageAdd1.Value = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine1"].ToString();
                txtOtherLanguageAdd2.Text = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine2"].ToString();
                HFOtherLanguageAdd2.Value = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine2"].ToString();
                txtOtherLanguageAdd3.Text = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine3"].ToString();
                HFOtherLanguageAdd3.Value = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine3"].ToString();
            }
        }

        FillAdditionalDetails();
    }

    /// <summary>
    /// Fill Additional Details
    /// </summary>
    protected void FillAdditionalDetails()
    {
        BL.Sales objSales = new BL.Sales();
        using (SqlDataReader drGetDetails = objSales.ClientAdditionalDetailsGetAll(txtClientCode.Text))
        {
            drGetDetails.Read();

            if (drGetDetails.HasRows == true)
            {
                txtAbvtClientName.Text = drGetDetails["SHORT_CostomerName"].ToString();
                txtPvtCompNo.Text = drGetDetails["PVT_CompanyNo"].ToString();
                txtSectorNo.Text = drGetDetails["SectorNo"].ToString();

                if (bool.Parse(drGetDetails["MKT_FinanceRegulation"].ToString()) == true)
                {
                    rbtnMarketRegulationYes.Checked = true;
                    rbtnMarketRegulationNo.Checked = false;
                }
                else
                {
                    rbtnMarketRegulationYes.Checked = false;
                    rbtnMarketRegulationNo.Checked = true;
                }

                btnAddSubmit.Enabled = false;
                btnAddUpdate.Enabled = true;
            }
            else
            {
                btnAddSubmit.Enabled = true;
                btnAddUpdate.Enabled = false;
            }
        }
    }
    #endregion

    #region page controles events
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        DataSet ds = new DataSet();
        BL.Sales objSale = new BL.Sales();

        if (CheckAvailability() == true)
        {
            if (CheckClientNameAvailability() == true)
            {
                using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
                {


                    float turnOver = 0;
                    if (txtTurnover.Text == "")
                    {
                        turnOver = 0;
                    }
                    else
                    {
                        turnOver = float.Parse(txtTurnover.Text);
                    }
                    /*V1.0*/
                    if (txtClientCode.Enabled == false)
                    {
                        ds = objSale.ClientMasterInsert(BaseCompanyCode, BaseLocationAutoID, txtManualClientCode.Text, txtClientName.Text, txtClientAddressLine1.Text, txtClientAddressLine2.Text, txtClientAddressLine3.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value.ToString(), ddlCountryOrigin.SelectedItem.Value.ToString(), txtPhone.Text, txtFax.Text, txtWebSite.Text, txtEmail.Text, txtContactPersonEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, txtOurContactPerson.Text, txtOurContactPersonEmpNo.Text, txtOurContactPersonMobile.Text, turnOver, ddlIndustryType.SelectedItem.Value.ToString(), ddlClassification.SelectedItem.Value.ToString(), ddlCustomerType.SelectedItem.Value.ToString(), cbIsInternational.Checked.ToString(), ddlSector.SelectedItem.Value.ToString(), ddlSubSegment.SelectedItem.Value.ToString(), txtComments.Text, BaseUserID, txtOtherLanguageClientName.Text, txtOtherLanguageAdd1.Text, txtOtherLanguageAdd2.Text, txtOtherLanguageAdd3.Text);
                    }
                    else
                    {
                        if (txtClientCode.Text.Trim() == "" || txtClientCode.Text == null)
                        {
                            lblErrorMsg.Text = Resources.Resource.BlankClientCode;
                            txtClientCode.Focus();
                        }
                        else
                        {
                            ds = objSale.ClientMasterManualInsert(BaseCompanyCode, BaseLocationAutoID, txtClientCode.Text, txtManualClientCode.Text, txtClientName.Text, txtClientAddressLine1.Text, txtClientAddressLine2.Text, txtClientAddressLine3.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value.ToString(), ddlCountryOrigin.SelectedItem.Value.ToString(), txtPhone.Text, txtFax.Text, txtWebSite.Text, txtEmail.Text, txtContactPersonEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, txtOurContactPerson.Text, txtOurContactPersonEmpNo.Text, txtOurContactPersonMobile.Text, turnOver, ddlIndustryType.SelectedItem.Value.ToString(), ddlClassification.SelectedItem.Value.ToString(), ddlCustomerType.SelectedItem.Value.ToString(), cbIsInternational.Checked.ToString(), ddlSector.SelectedItem.Value.ToString(), ddlSubSegment.SelectedItem.Value.ToString(), txtComments.Text, BaseUserID, txtOtherLanguageClientName.Text, txtOtherLanguageAdd1.Text, txtOtherLanguageAdd2.Text, txtOtherLanguageAdd3.Text);
                        }
                    }
                    /*V1.0*/
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        if (ds.Tables[0].Rows[0]["MessageID"].ToString() != "3")
                        {
                            txtClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                            
                            FillConstraintTab();

                        }
                        else
                        {
                            return;
                        }

                        //to map the client to the current company by default
                        //DataSet ds1 = new DataSet();
                        if (txtClientCode.Text != "")
                        {
                            using (DataSet ds1 = objSale.ClientCompanyMappingInsert(BaseCompanyCode, txtClientCode.Text, txtClientAddressLine1.Text, txtClientAddressLine2.Text, txtClientAddressLine3.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value.ToString(), txtPhone.Text, txtFax.Text, txtWebSite.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, txtOurContactPerson.Text, txtOurContactPersonEmpNo.Text, txtOurContactPersonMobile.Text, txtComments.Text, BaseUserID))
                            {
                                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds1.Tables[0].Rows[0]["MessageID"].ToString());
                                }
                            }
                            //to map the client to the current Location by default
                            //DataSet ds2 = new DataSet();
                            using (DataSet ds2 = objSale.ClientMappingToLocationAdd(int.Parse(BaseLocationAutoID.ToString()), txtClientCode.Text, BaseUserID))
                            {
                                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds2.Tables[0].Rows[0]["MessageID"].ToString());
                                }

                            }
                            // to create a By default Billing ID
                            //Start*********************************************************************
                            //DataSet ds3 = new DataSet();
                            //if (txtClientCode.Enabled == false)
                            //{
                            //    using (DataSet ds3 = objSale.ClientDetailsInsert(BaseLocationAutoID, txtClientCode.Text, "B", "NotRequired", txtClientAddressLine1.Text, "",
                            //        txtClientAddressLine1.Text + ", " + txtClientAddressLine2.Text + ", " + txtClientAddressLine3.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value.ToString(), txtPhone.Text, txtFax.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, Resources.Resource.NotKnown.ToString(), txtComments.Text, BaseUserID, ""))
                            //    {

                            //        if (ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0 && int.Parse(ds3.Tables[0].Rows[0]["MessageID"].ToString()) == 0)
                            //        {
                            //            DisplayMessage(lblErrorMsg, ds3.Tables[0].Rows[0]["MessageID"].ToString());
                            //        }
                            //        else
                            //        {
                            //            if (ds3.Tables.Count > 0)
                            //            {
                            //                if (int.Parse(ds3.Tables[0].Rows[0]["MessageID"].ToString()) == 11)
                            //                {
                            //                    DisplayMessage(lblErrorMsg, ds3.Tables[0].Rows[0]["MessageID"].ToString());
                            //                }
                            //            }
                            //        }
                            //    }
                            //}
                            //End***********************************************************************
                            //Set page to Edit mode
                            txtManualClientCode.ReadOnly = false;
                            lbCheckAvailability.Visible = false;

                            btnSubmit.Visible = false;
                            btnReset.Visible = false;
                            btnUpdate.Visible = true;
                            btnCancel.Visible = true;
                            btnClientDetails.Enabled = true;
                            btnCreateAsmtAddress.Enabled = true;
                            if (IsModifyAccess == true)
                            {
                                btnUpdate.Enabled = true;
                                btnCancel.Enabled = true;
                            }
                            else
                            {
                                btnUpdate.Enabled = false;
                                btnCancel.Enabled = false;
                            }
                        }
                    }

                    tx.Complete();
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.ClientName.ToString() + " " + Resources.Resource.MsgAlreadyExists.ToString();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(txtClientName);
            }

        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.ManualClientCode.ToString() + " " + Resources.Resource.MsgAlreadyExists.ToString();
            System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            ToolkitScriptManager1.SetFocus(txtManualClientCode);
        }

        txtClientCodeConst.Text = txtClientCode.Text;
        txtClientNameConst.Text = txtClientName.Text;
        txtManualClientCodeConst.Text = txtManualClientCode.Text;
        txtClientCodeAdd.Text = txtClientCode.Text;
        txtClientNameAdd.Text = txtClientName.Text;
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtManualClientCode.Text = "";
        txtClientName.Text = "";
        txtClientAddressLine1.Text = "";
        txtClientAddressLine2.Text = "";
        txtClientAddressLine3.Text = "";
        txtCity.Text = "";
        //txtPin.Text = "";
        txtPhone.Text = "";
        txtState.Text = "";
        txtFax.Text = "";
        txtWebSite.Text = "";
        txtEmail.Text = "";
        txtContactPersonEmail.Text = string.Empty;
        txtClientContactPerson.Text = "";
        txtClientContactPersonDesignation.Text = "";
        txtClientContactPersonMobile.Text = "";
        txtOurContactPerson.Text = "";
        txtOurContactPersonEmpNo.Text = "";
        txtOurContactPersonMobile.Text = "";
        txtTurnover.Text = "";
        txtComments.Text = "";
        cbIsInternational.Checked = false;

    }
    /// <summary>
    /// Handles the Click event of the btnList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnList_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClientMasterList.aspx");
    }

    /// <summary>
    /// Handles the Click event of the btnUpdateSaleOrders control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdateSaleOrders_Click(object sender, EventArgs e)
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = objSale.ClientConstraintsUpdateToSaleOrders(BaseCompanyCode, BaseLocationAutoID, txtClientCode.Text, strStatusAmend, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdateSaleOrdersWithoutHistory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdateSaleOrdersWithoutHistory_Click(object sender, EventArgs e)
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = objSale.ClientConstraintsUpdateToSaleOrders(BaseCompanyCode, BaseLocationAutoID, txtClientCode.Text, strStatusCorrection, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }

    /// <summary>
    /// Handles the Click event of the lbCheckAvailability control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbCheckAvailability_Click(object sender, EventArgs e)
    {
        if (CheckAvailability() == false)
        {
            if (txtManualClientCode.Text.Length > 0)
            {
                lblErrorMsg.Text = Resources.Resource.ManualClientCode.ToString() + " " + Resources.Resource.MsgAlreadyExists.ToString();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(txtManualClientCode);
            }
        }

        else
        {
            if (txtManualClientCode.Text.Length > 0)
            {
                lblErrorMsg.Text = Resources.Resource.ManualClientCode.ToString() + " " + Resources.Resource.AvailabletoCreate;
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(txtClientName);
            }
        }


        if (CheckClientNameAvailability() == false)
        {
            if (txtClientName.Text.Length > 0)
            {
                lblErrorMsg.Text = Resources.Resource.ClientName.ToString() + " " + Resources.Resource.MsgAlreadyExists.ToString();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(txtClientName);
            }
        }
        else
        {
            if (txtClientName.Text.Length > 0)
            {
                lblErrorMsg.Text = Resources.Resource.ClientName.ToString() + " " + Resources.Resource.AvailabletoCreate.ToString();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(txtClientName);
            }
        }
        
    }
    /// <summary>
    /// Checks the availability.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckAvailability()
    {
        if (txtManualClientCode.Text.Length > 0)
        {
            //DataSet ds = new DataSet();
            BL.Sales objSale = new BL.Sales();
            using (DataSet ds = objSale.CheckClientCodeAvailability(txtManualClientCode.Text))
            {
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// Checks the client name availability.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckClientNameAvailability()
    {
        //DataSet ds = new DataSet();
        BL.Sales objSale = new BL.Sales();
        if (txtClientName.Text.Length > 0)
        {
            using (DataSet ds = objSale.CheckClientNameAvailability(txtClientName.Text.ToString().Trim()))
            {
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {


       
        //DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        float turnOver = 0;
        if (txtTurnover.Text == "")
        {
            turnOver = 0;
        }
        else
        {
            turnOver = float.Parse(txtTurnover.Text);
        }
        using (DataSet ds = objSales.ClientMasterUpdate(txtManualClientCode.Text, txtClientName.Text, txtClientAddressLine1.Text, txtClientAddressLine2.Text, txtClientAddressLine3.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value.ToString(), ddlCountryOrigin.SelectedItem.Value.ToString(), txtPhone.Text, txtFax.Text, txtWebSite.Text, txtEmail.Text, txtContactPersonEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, txtOurContactPerson.Text, txtOurContactPersonEmpNo.Text, txtOurContactPersonMobile.Text, turnOver, ddlIndustryType.SelectedItem.Value.ToString(), ddlClassification.SelectedItem.Value.ToString(), ddlCustomerType.SelectedItem.Value.ToString(), cbIsInternational.Checked.ToString(), ddlSector.SelectedItem.Value.ToString(), ddlSubSegment.SelectedItem.Value.ToString(), txtComments.Text, txtClientCode.Text, BaseUserID))
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientMasterList.aspx");
    }
    /// <summary>
    /// Handles the Click event of the btnClientDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClientDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientDetailsList.aspx?ClientCode=" + txtClientCode.Text);
    }
    /// <summary>
    /// Handles the Click event of the btnCreateAsmtAddress control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCreateAsmtAddress_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/CreateAsmtId.aspx?ClientCode=" + txtClientCode.Text);
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlCountryCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlCountryCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCountryOrigin.SelectedValue = ddlCountryCode.SelectedItem.Value.ToString();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtOurContactPersonEmpNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtOurContactPersonEmpNo_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        //DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();

        using (DataSet ds = objHrManagement.EmployeeNameAndDesignationGet(txtOurContactPersonEmpNo.Text.ToString(), BaseCompanyCode))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                txtOurContactPerson.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.InvalidEmpCode);
                txtOurContactPersonEmpNo.Text = "";
                txtOurContactPerson.Text = "";
                ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
            }
        }
    }

    /// <summary>
    /// Handles the Click event of the btnAddSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddSubmit_Click(object sender, EventArgs e)
    {
        if (txtClientCodeAdd.Text.Trim() == "")
        {
            DisplayMessageString(lblErrorAddMsg, "Client Code cannot be Blank");
            txtClientCodeAdd.Focus();

        }
        else if (txtPvtCompNo.Text.Trim() == "")
        {
            DisplayMessageString(lblErrorAddMsg, "Private Company No. cannot be Blank");
            txtPvtCompNo.Focus();
            return;

        }
        else if (txtAbvtClientName.Text.Trim() == "")
        {
            DisplayMessageString(lblErrorAddMsg, "Abbreviated Client Code cannot be Blank");
            txtAbvtClientName.Focus();
            return;
        }
        else if (txtSectorNo.Text.Trim() == "")
        {
            DisplayMessageString(lblErrorAddMsg, "Sector No. cannot be Blank");
            txtSectorNo.Focus();
            return;
        }

        if (txtClientCodeAdd.Text.Trim() != "" && (txtPvtCompNo.Text != "" || txtAbvtClientName.Text != "" || txtSectorNo.Text != ""))
        {
            BL.Sales objAddDetail = new BL.Sales();
            //SqlDataReader drAddDetail = null;
            using (SqlDataReader drAddDetail = objAddDetail.ClientAdditionalDetailsAdd(BaseLocationAutoID, txtClientCodeAdd.Text,
                                                                        txtAbvtClientName.Text, txtPvtCompNo.Text,
                                                                        txtSectorNo.Text,
                                                                        rbtnMarketRegulationYes.Checked))
            {
                //Code modified by Dharamvir Singh on 18-Nov-2011 to handle the improper handling of SqlDataReader

                /*drAddDetail = objAddDetail.blClientAdditionalDetails_AddNew(BaseLocationAutoID, txtClientCodeAdd.Text,
                                                                txtAbvtClientName.Text, txtPvtCompNo.Text,
                                                                txtSectorNo.Text,
                                                                rbtnMarketRegulationYes.Checked);*/
                drAddDetail.Read();
                if (drAddDetail.RecordsAffected >= 1)
                {
                    drAddDetail.Close();
                    lblErrorAddMsg.Text = Resources.Resource.MsgInsertSuccessfully;
                    btnAddSubmit.Enabled = false;
                    btnAddUpdate.Enabled = true;
                    FillAdditionalDetails();
                }
                else
                {
                    // ToDo
                }
            }
        }
        else
        {
            btnAddSubmit.Enabled = true;
            btnAddUpdate.Enabled = false;
            if (txtClientCodeAdd.Text.Trim() == "")
            {
                DisplayMessageString(lblErrorAddMsg, "Client Code cannot be Blank");
                txtClientCodeAdd.Focus();

            }
            else if (txtPvtCompNo.Text.Trim() == "")
            {
                DisplayMessageString(lblErrorAddMsg, "Private Company No. cannot be Blank");
                txtPvtCompNo.Focus();
                return;

            }
            else if (txtAbvtClientName.Text.Trim() == "")
            {
                DisplayMessageString(lblErrorAddMsg, "Abbreviated Client Code cannot be Blank");
                txtAbvtClientName.Focus();
                return;
            }
            else if (txtSectorNo.Text.Trim() == "")
            {
                DisplayMessageString(lblErrorAddMsg, "Sector No. cannot be Blank");
                txtSectorNo.Focus();
                return;
            }
        }
    }

    /// <summary>
    /// Handles the Click event of the btnAddReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddReset_Click(object sender, EventArgs e)
    {
        txtAbvtClientName.Text = "";
        txtPvtCompNo.Text = "";
        txtSectorNo.Text = "";
        rbtnMarketRegulationNo.Checked = true;
        rbtnMarketRegulationYes.Checked = false;
    }
    /// <summary>
    /// Handles the Click event of the btnAddUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddUpdate_Click(object sender, EventArgs e)
    {
        if (txtClientCodeAdd.Text.Trim() != "" && (txtPvtCompNo.Text != "" || txtAbvtClientName.Text != "" || txtSectorNo.Text != ""))
        {
            BL.Sales objAddDetail = new BL.Sales();
            using (SqlDataReader drAddDetail = objAddDetail.ClientAdditionalDetailsAdd(BaseLocationAutoID, txtClientCodeAdd.Text,
                                                                        txtAbvtClientName.Text, txtPvtCompNo.Text,
                                                                        txtSectorNo.Text,
                                                                        rbtnMarketRegulationYes.Checked))
            {
                //Code modified by Dharamvir Singh on 18-Nov-2011 to handle the improper handling of SqlDataReader
                /*SqlDataReader drAddDetail = objAddDetail.blClientAdditionalDetails_AddNew(BaseLocationAutoID, txtClientCodeAdd.Text,
                                                                        txtAbvtClientName.Text, txtPvtCompNo.Text,
                                                                        txtSectorNo.Text,
                                                                        rbtnMarketRegulationYes.Checked)*/
                drAddDetail.Read();
                if (drAddDetail.RecordsAffected >= 1)
                {
                    DisplayMessageString(lblErrorAddMsg, Resources.Resource.MsgUpdateSuccessfully);
                    drAddDetail.Close();
                    FillAdditionalDetails();
                }
                else
                {
                    // ToDo
                }
            }
        }
        else
        {
            btnAddSubmit.Enabled = false;
            btnAddUpdate.Enabled = true;
        }


    }
    /// <summary>
    /// Handles the Click event of the btnAddCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddCancel_Click(object sender, EventArgs e)
    {
        if (txtClientCodeAdd.Text.Trim() != "")
        {
            BL.Sales objAddDetail = new BL.Sales();

            //SqlDataReader drAddDetail = null;
            using (SqlDataReader drAddDetail = objAddDetail.ClientAdditionalDetailsDelete(txtClientCodeAdd.Text))
            {
                //Code modified by Dharamvir Singh on 18-Nov-2011 to handle the improper handling of SqlDataReader
                /*SqlDataReader drAddDetail = objAddDetail.blClientAdditionalDetails_Delete(txtClientCodeAdd.Text)*/
                drAddDetail.Read();
                if (drAddDetail.RecordsAffected >= 1)
                {
                    lblErrorAddMsg.Text = Resources.Resource.MsgDeleteSuccessfully;
                    drAddDetail.Close();
                    FillAdditionalDetails();
                    btnAddSubmit.Enabled = true;
                    btnAddUpdate.Enabled = false;
                }
                else
                {
                    // ToDo
                }
            }
        }
        else
        {
            //  ToDo
        }

    }
    #endregion

    #region Function Related to Multilingual Details

    /// <summary>
    /// Handles the Click event of the btnOk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtClientCode.Text != "")
        {
            if (txtOtherLanguageClientName.Text != HFOtherLanguageClientName.Value || txtOtherLanguageAdd1.Text != HFOtherLanguageAdd1.Value || txtOtherLanguageAdd2.Text != HFOtherLanguageAdd2.Value || txtOtherLanguageAdd3.Text != HFOtherLanguageAdd3.Value)
            {
                //DataSet ds = new DataSet();
                BL.Sales objSales = new BL.Sales();
                //Code modified by Dharamvir Singh on 18-Nov-2011 to handle the improper handling of Dataset
                /*ds = objSales.blMultiLingualClientDetail_Insert(txtClientCode.Text, txtOtherLanguageClientName.Text, txtOtherLanguageAdd1.Text, txtOtherLanguageAdd2.Text, txtOtherLanguageAdd3.Text, BaseUserID)*/
                using (DataSet ds = objSales.MultilingualClientDetailInsert(txtClientCode.Text, txtOtherLanguageClientName.Text, txtOtherLanguageAdd1.Text, txtOtherLanguageAdd2.Text, txtOtherLanguageAdd3.Text, BaseUserID)) ;
                HFOtherLanguageClientName.Value = txtOtherLanguageClientName.Text;
                HFOtherLanguageAdd1.Value = txtOtherLanguageAdd1.Text;
                HFOtherLanguageAdd2.Value = txtOtherLanguageAdd2.Text;
                HFOtherLanguageAdd3.Value = txtOtherLanguageAdd3.Text;
            }
        }
        MPClientDetail.Hide();
    }

    /// <summary>
    /// Handles the Click event of the btnMultiLingualCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnMultiLingualCancel_Click(object sender, EventArgs e)
    {
        FillMultilingualClientDetails();
    }


    /// <summary>
    /// Handles the Click event of the btnMultilingual control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnMultilingual_Click(object sender, EventArgs e)
    {

        MPClientDetail.Show();
        FillMultilingualClientDetails();
    }

    /// <summary>
    /// Fills the multilingual client details.
    /// </summary>
    private void FillMultilingualClientDetails()
    {
        //DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        if (txtClientCode.Text != "")
        {
            using (DataSet ds = objSales.MultilingualClientDetailGetAll(txtClientCode.Text))
            {
                txtOtherLanguageClientName.Text = ds.Tables[0].Rows[0]["MultiLingualClientName"].ToString();
                txtOtherLanguageAdd1.Text = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine1"].ToString();
                txtOtherLanguageAdd2.Text = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine2"].ToString();
                txtOtherLanguageAdd3.Text = ds.Tables[0].Rows[0]["MultiLingualClientAddressLine3"].ToString();
            }
        }
    }

    #endregion


    #region GridView Constraint Events

    /// <summary>
    /// Handles the RowDataBound event of the gvClientConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvClientConstraint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvClientConstraint.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton imgBtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (imgBtnEdit != null)
                { imgBtnEdit.Visible = false; }
            }
            else
            {
                ImageButton imgBtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (imgBtnUpdate != null)
                {
                    imgBtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtConstraintDesc = (TextBox)e.Row.FindControl("txtConstraintDesc");
                if (txtConstraintDesc != null)
                {
                    txtConstraintDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtConstraintDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                TextBox txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                HiddenField hfOperator = (HiddenField)e.Row.FindControl("HFOperator");
                if (hfOperator != null)
                {
                    DropDownList ddlOperator = (DropDownList)e.Row.FindControl("ddlOperator");
                    ddlOperator.SelectedValue = hfOperator.Value;
                }
                DropDownList ddlConstraintType = (DropDownList)e.Row.FindControl("ddlConstraintType");
                if (ddlConstraintType != null)
                {
                    ddlConstraintType.Attributes["readonly"] = "readonly";
                    DropDownList ddlConstraintDesc = (DropDownList)e.Row.FindControl("ddlConstraintDesc");
                    if (ddlConstraintDesc != null)
                    {
                        HiddenField hfConstraintTypeAutoId = (HiddenField)e.Row.FindControl("hfConstraintTypeAutoID");
                        HiddenField hfConstraintCode = (HiddenField)e.Row.FindControl("hfConstraintCode");
                        HiddenField hfConstraintAutoId = (HiddenField)e.Row.FindControl("hfConstraintAutoID");
                        DropDownList ddlValue = (DropDownList)e.Row.FindControl("ddlValue");
                        FillddlConstraintType(ddlConstraintType, ddlConstraintDesc, hfConstraintTypeAutoId, hfConstraintCode, txtValue, ddlValue);
                        ddlValue.SelectedValue = hfConstraintAutoId.Value;
                    }
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton imgBtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (imgBtnDelete != null)
                { imgBtnDelete.Visible = false; }
            }
            else
            {
                ImageButton imgBtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (imgBtnDelete != null)
                {
                    imgBtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }

            }
            HiddenField hfRigidityLevel = (HiddenField)e.Row.FindControl("HFRigidityLevel");
            DropDownList ddlRigidityLevel = (DropDownList)e.Row.FindControl("ddlRigidityLevel");
            if (hfRigidityLevel != null && ddlRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlRigidityLevel);
                ddlRigidityLevel.SelectedValue = hfRigidityLevel.Value;
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvClientConstraint.ShowFooter = false;
            }
            else
            {
                ImageButton imgBtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (imgBtnAdd != null)
                {
                    imgBtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtConstraintCode = (TextBox)e.Row.FindControl("txtConstraintCode");
                if (txtConstraintCode != null)
                {
                    txtConstraintCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtConstraintCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtConstraintDesc = (TextBox)e.Row.FindControl("txtConstraintDesc");
                if (txtConstraintDesc != null)
                {
                    txtConstraintDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtConstraintDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                DropDownList ddlConstraintType = (DropDownList)e.Row.FindControl("ddlConstraintType");
                if (ddlConstraintType != null)
                {
                    ddlConstraintType.Attributes["readonly"] = "readonly";
                    DropDownList ddlConstraintDesc = (DropDownList)e.Row.FindControl("ddlConstraintDesc");
                    if (ddlConstraintDesc != null)
                    {
                        HiddenField hfConstraintTypeAutoId = (HiddenField)e.Row.FindControl("HFConstraintTypeAutoID");
                        HiddenField hfConstraintCode = (HiddenField)e.Row.FindControl("HFConstraintCode");
                        // ddlConstraintType.SelectedValue = HFConstraintTypeAutoID.Value;
                        DropDownList ddlValue = (DropDownList)e.Row.FindControl("ddlValue");
                        FillddlConstraintType(ddlConstraintType, ddlConstraintDesc, hfConstraintTypeAutoId, hfConstraintCode, txtValue, ddlValue);
                    }
                }

                DropDownList ddlRigidityLevel = (DropDownList)e.Row.FindControl("ddlRigidityLevel");
                if (ddlRigidityLevel != null)
                {
                    FillddlRigidityLevel(ddlRigidityLevel);
                }
            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvClientConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvClientConstraint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        //DataSet ds = new DataSet();
        // To Insert a New Row
        DropDownList ddlConstraintType = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlConstraintType");
        DropDownList ddlConstraintDesc = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlConstraintDesc");
        DropDownList ddlValue = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlValue");
        TextBox txtValue = (TextBox)gvClientConstraint.FooterRow.FindControl("txtValue");
        DropDownList ddlOperator = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlOperator");
        DropDownList ddlRigidityLevel = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlRigidityLevel");
        if (e.CommandName == "Add")
        {
            if (txtValue.Style["display"] == "block")
            {
                if (txtValue.Text != "")
                {
                    double intCheck = 0.0;
                    if (ddlOperator.SelectedValue == ">" || ddlOperator.SelectedValue == "<")
                    {
                        try
                        {
                            intCheck = double.Parse(txtValue.Text);
                        }
                        catch (Exception ex)
                        {
                            Show("Only Numeric Values Allowed");
                            txtValue.Text = "";
                            return;
                        }
                    }
                    using (DataSet ds = objSales.ClientConstraintInsert(BaseCompanyCode, ddlConstraintType.SelectedValue.ToString(), ddlConstraintDesc.SelectedValue.ToString(), txtValue.Text, ddlOperator.SelectedValue.ToString(), ddlRigidityLevel.SelectedItem.Value, BaseUserID.ToString(), txtClientCode.Text))
                    {
                        gvClientConstraint.EditIndex = -1;
                        FillgvClientConstraint();
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        { DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                    }
                }
                else
                {
                    lblConstraintErrorMsg.Text = "Value field cannot be left blank ! ";
                }
            }
            else
            {
                using (DataSet ds = objSales.ClientConstraintInsert(BaseCompanyCode, ddlConstraintType.SelectedValue.ToString(), ddlValue.SelectedValue.ToString(), ddlValue.SelectedItem.Text, ddlOperator.SelectedValue.ToString(), ddlRigidityLevel.SelectedItem.Value, BaseUserID.ToString(), txtClientCode.Text))
                    {
                        gvClientConstraint.EditIndex = -1;
                        FillgvClientConstraint();
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        { DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                    }
            }

        }
        if (e.CommandName == "Reset")
        {
            txtValue.Text = "";
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the gvClientConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvClientConstraint_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvClientConstraint.EditIndex = e.NewEditIndex;
        FillgvClientConstraint();
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvClientConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvClientConstraint_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvClientConstraint.EditIndex = -1;
        FillgvClientConstraint();
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvClientConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvClientConstraint_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();

        DropDownList ddlConstraintType = (DropDownList)gvClientConstraint.Rows[e.RowIndex].FindControl("ddlConstraintType");
        DropDownList ddlConstraintDesc = (DropDownList)gvClientConstraint.Rows[e.RowIndex].FindControl("ddlConstraintDesc");
        TextBox txtValue = (TextBox)gvClientConstraint.Rows[e.RowIndex].FindControl("txtValue");
        DropDownList ddlOperator = (DropDownList)gvClientConstraint.Rows[e.RowIndex].FindControl("ddlOperator");
        DropDownList ddlValue = (DropDownList)gvClientConstraint.Rows[e.RowIndex].FindControl("ddlValue");
        DropDownList ddlRigidityLevel = (DropDownList)gvClientConstraint.Rows[e.RowIndex].FindControl("ddlRigidityLevel");


        HiddenField hfClientConstraintAutoId = (HiddenField)gvClientConstraint.Rows[e.RowIndex].FindControl("HFClientConstraintAutoID");
        if (txtValue.Style["display"] == "block")
        {
            double intCheck = 0.0;
            if (ddlOperator.SelectedValue == ">" || ddlOperator.SelectedValue == "<")
            {
                try
                {
                    intCheck = double.Parse(txtValue.Text);
                }
                catch (Exception ex)
                {
                    Show("Only Numeric Values Allowed");
                    txtValue.Text = "";
                    return;
                }
            }
            ds = objSales.ClientConstraintUpdate(hfClientConstraintAutoId.Value, ddlConstraintType.SelectedValue.ToString(), ddlConstraintDesc.SelectedValue.ToString(), txtValue.Text, ddlOperator.SelectedValue.ToString(), ddlRigidityLevel.SelectedItem.Value, BaseUserID.ToString());
        }
        else
        {
            ds = objSales.ClientConstraintUpdate(hfClientConstraintAutoId.Value, ddlConstraintType.SelectedValue.ToString(), ddlValue.SelectedValue.ToString(), ddlValue.SelectedItem.Text, ddlOperator.SelectedValue.ToString(), ddlRigidityLevel.SelectedItem.Value, BaseUserID.ToString());
        }
        gvClientConstraint.EditIndex = -1;
        FillgvClientConstraint();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvClientConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvClientConstraint_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        //DataSet ds = new DataSet();
        HiddenField hfClientConstraintAutoId = (HiddenField)gvClientConstraint.Rows[e.RowIndex].FindControl("HFClientConstraintAutoID");
        using (DataSet ds = objSales.ClientConstraintDelete(hfClientConstraintAutoId.Value))
        {
            FillgvClientConstraint();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvClientConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvClientConstraint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClientConstraint.PageIndex = e.NewPageIndex;
        gvClientConstraint.EditIndex = -1;
        FillgvClientConstraint();
    }
    #endregion

    /// <summary>
    /// Fill Client Constraint Grid
    /// </summary>
    private void FillgvClientConstraint()
    {
        BL.Sales objSales = new BL.Sales();
        int dtflag = 1;

        using (DataSet ds = objSales.ClientConstraintGet(BaseCompanyCode, txtClientCode.Text))
        {
            using (DataTable dt = ds.Tables[0])
            {
                if (dt.Rows.Count == 0)
                {
                    dtflag = 0;
                    dt.Rows.Add(dt.NewRow());
                }

                gvClientConstraint.DataSource = dt;
                gvClientConstraint.DataBind();

                if (dtflag == 0)
                {
                    gvClientConstraint.Rows[0].Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// Fill Drop Down Constraint Type
    /// </summary>
    /// <param name="ddlConstraintType">drop down list Constraint Type</param>
    /// <param name="ddlConstraintDesc">drop down list Constraint Desc</param>
    /// <param name="hfConstraintTypeAutoId">hidden field Constraint Type Auto Id</param>
    /// <param name="hfConstraintCode">hidden field Constraint Code</param>
    /// <param name="txtValue">Text Value</param>
    /// <param name="ddlValue">Drop Down Value</param>
    private void FillddlConstraintType(DropDownList ddlConstraintType, DropDownList ddlConstraintDesc, HiddenField hfConstraintTypeAutoId, HiddenField hfConstraintCode, TextBox txtValue, DropDownList ddlValue)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();

        using (DataSet ds = objMastersManagement.ConstraintTypeGetAll(BaseCompanyCode))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlConstraintType.DataSource = ds.Tables[0];
                ddlConstraintType.DataTextField = "ConstraintTypeDesc";
                ddlConstraintType.DataValueField = "ConstraintTypeAutoID";
                ddlConstraintType.DataBind();
            }
            else
            {
                ListItem l1 = new ListItem();
                l1.Text = Resources.Resource.NoDataToShow;
                l1.Value = "0";
                ddlConstraintType.Items.Add(l1);
            }
        }
        try
        {
            ddlConstraintType.SelectedValue = hfConstraintTypeAutoId.Value;
        }

        catch (Exception ex)
        {

        }

        FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, hfConstraintCode, txtValue, ddlValue);
    }

    /// <summary>
    /// Fillddls the constraint desc.
    /// </summary>
    /// <param name="ddlConstraintType">Type of the DDL constraint.</param>
    /// <param name="ddlConstraintDesc">The DDL constraint desc.</param>
    /// <param name="hfConstraintCode">The hf constraint code.</param>
    /// <param name="txtValue">The text value.</param>
    /// <param name="ddlValue">The DDL value.</param>
    private void FillddlConstraintDesc(DropDownList ddlConstraintType, DropDownList ddlConstraintDesc, HiddenField hfConstraintCode, TextBox txtValue, DropDownList ddlValue)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        //DataSet ds = new DataSet();
        using (DataSet ds = objMastersManagement.ConstraintGetAll(BaseCompanyCode, ddlConstraintType.SelectedValue.ToString(), "Client"))
        {
            ddlConstraintDesc.DataSource = ds.Tables[0];
            ddlConstraintDesc.DataTextField = "ConstraintDesc";
            ddlConstraintDesc.DataValueField = "ConstraintCode";
            ddlConstraintDesc.DataBind();
        }
        try
        {
            ddlConstraintDesc.SelectedValue = hfConstraintCode.Value;
        }
        catch (Exception ex) { }
        GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);

        // EventArgs e = new EventArgs();
        //ddlConstraintDesc_SelectedIndexChanged(ddlConstraintDesc, e);

    }
    /// <summary>
    /// Fillddls the group zip.
    /// </summary>
    protected void FillddlGroupZip()
    {
        var objMastersManagement = new BL.MastersManagement();
        using (DataSet ds = objMastersManagement.ZipCodeGroupGet(BaseLocationAutoID))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlGroupZip.DataSource = ds.Tables[0];
                ddlGroupZip.DataTextField = "GroupZipCodeDesc";
                ddlGroupZip.DataValueField = "GroupZipCode";
                ddlGroupZip.DataBind();
            }
            ListItem l1 = new ListItem(Resources.Resource.NotKnown, string.Empty);
            ddlGroupZip.Items.Insert(0, l1);
        }

        FillddlZip();
    }

    /// <summary>
    /// To fill the Zip codes Drop down
    /// </summary>
    protected void FillddlZip()
    {
        ddlZip.Items.Clear();
        var objMastersManagement = new BL.MastersManagement();
        using (DataSet ds = objMastersManagement.ZipCodeGet(BaseLocationAutoID, ddlGroupZip.SelectedItem.Value))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlZip.DataSource = ds.Tables[0];
                ddlZip.DataTextField = "ZipCodeDesc";
                ddlZip.DataValueField = "ZipCode";
                ddlZip.DataBind();
            }

            var l1 = new ListItem(Resources.Resource.NotKnown, string.Empty);
            ddlZip.Items.Insert(0, l1);
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlGroupZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlGroupZip_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlZip();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlConstraintType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlConstraintType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList objDropDownList = (DropDownList)sender;
        GridViewRow row = (GridViewRow)objDropDownList.NamingContainer;
        if (row.RowIndex < 0)
        {
            DropDownList ddlConstraintType = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlConstraintType");
            DropDownList ddlConstraintDesc = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlConstraintDesc");
            TextBox txtValue = (TextBox)gvClientConstraint.FooterRow.FindControl("txtValue");
            DropDownList ddlValue = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlValue");
            HiddenField hfConstraintCode = (HiddenField)gvClientConstraint.FooterRow.FindControl("HFConstraintCode");
            FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, hfConstraintCode, txtValue, ddlValue);
        }
        else
        {
            DropDownList ddlConstraintType = (DropDownList)gvClientConstraint.Rows[row.RowIndex].FindControl("ddlConstraintType");
            DropDownList ddlConstraintDesc = (DropDownList)gvClientConstraint.Rows[row.RowIndex].FindControl("ddlConstraintDesc");
            TextBox txtValue = (TextBox)gvClientConstraint.Rows[row.RowIndex].FindControl("txtValue");
            DropDownList ddlValue = (DropDownList)gvClientConstraint.Rows[row.RowIndex].FindControl("ddlValue");
            HiddenField hfConstraintCode = (HiddenField)gvClientConstraint.Rows[row.RowIndex].FindControl("HFConstraintCode");
            FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, hfConstraintCode, txtValue, ddlValue);
        }

        ddlConstraintDesc_SelectedIndexChanged(sender, e);
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlConstraintDesc control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlConstraintDesc_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList objDropDownList = (DropDownList)sender;
        GridViewRow row = (GridViewRow)objDropDownList.NamingContainer;
        if (row.RowIndex < 0)
        {
            DropDownList ddlConstraintDesc = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlConstraintDesc");
            DropDownList ddlConstraintType = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlConstraintType");
            DropDownList ddlValue = (DropDownList)gvClientConstraint.FooterRow.FindControl("ddlValue");
            Label lblDefaultValue = (Label)gvClientConstraint.FooterRow.FindControl("lblDefaultValue");
            TextBox txtValue = (TextBox)gvClientConstraint.FooterRow.FindControl("txtValue");

            GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);

        }
        else
        {
            DropDownList ddlConstraintDesc = (DropDownList)gvClientConstraint.Rows[row.RowIndex].FindControl("ddlConstraintDesc");
            DropDownList ddlConstraintType = (DropDownList)gvClientConstraint.Rows[row.RowIndex].FindControl("ddlConstraintType");
            DropDownList ddlValue = (DropDownList)gvClientConstraint.Rows[row.RowIndex].FindControl("ddlValue");
            Label lblDefaultValue = (Label)gvClientConstraint.Rows[row.RowIndex].FindControl("lblDefaultValue");
            TextBox txtValue = (TextBox)gvClientConstraint.Rows[row.RowIndex].FindControl("txtValue");
            HiddenField hfConstraintAutoId = (HiddenField)gvClientConstraint.Rows[row.RowIndex].FindControl("HFConstraintAutoID");
            GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);
            // ddlValue.SelectedValue = HFConstraintAutoID.Value;
        }

    }

    /// <summary>
    /// Gets the value based on constraint automatic identifier.
    /// </summary>
    /// <param name="ddlConstraintDesc">The DDL constraint desc.</param>
    /// <param name="ddlConstraintType">Type of the DDL constraint.</param>
    /// <param name="ddlValue">The DDL value.</param>
    /// <param name="txtValue">The text value.</param>
    private void GetValueBasedOnConstraintAutoID(DropDownList ddlConstraintDesc, DropDownList ddlConstraintType, DropDownList ddlValue, TextBox txtValue)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        //DataSet ds = new DataSet();
        using (DataSet ds = objMastersManagement.ConstraintValueGet(ddlConstraintDesc.SelectedValue.ToString(), ddlConstraintType.SelectedValue.ToString()))
        {

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //lblDefaultValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                // txtValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();

                if (ds.Tables[0].Rows.Count > 1)
                {
                    ddlValue.Style["display"] = "block";
                    txtValue.Style["display"] = "none";
                    ddlValue.DataSource = ds.Tables[0];
                    ddlValue.DataTextField = "Value";
                    ddlValue.DataValueField = "ConstraintAutoID";
                    ddlValue.DataBind();
                }
                else
                {
                    txtValue.Style["display"] = "block";
                    ddlValue.Style["display"] = "none";
                }
            }
        }
    }

    private void FillddlRigidityLevel(DropDownList ddl)
    {
        ListItem li = new ListItem(Resources.Resource.Select, string.Empty);
        ddl.Items.Add(li);
        li = new ListItem(Resources.Resource.Mandatory, "M");
        ddl.Items.Add(li);
        li = new ListItem(Resources.Resource.Recommended, "R");
        ddl.Items.Add(li);
        li = new ListItem(Resources.Resource.Informative, "I");
        ddl.Items.Add(li);

    }

    #region GridView Events for Language
    /// <summary>
    /// Fillgvs the language.
    /// </summary>
    protected void FillgvLanguage()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.ClientLanguageSkillsGet(BaseCompanyCode, txtClientCodeConst.Text);
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
            //  dt.Rows[0]["IsMandatory"] = false;
        }
        //gvLanguage.DataKeyNames = new string[] { "LanguageCode" };
        gvLanguage.DataSource = dt;
        gvLanguage.DataBind();

        if (dtflag == 0)
        {
            gvLanguage.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Changed the Existing Functionality and added RBLLanguageRigidityLevel in it
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlLanguageCode = (DropDownList)gvLanguage.FooterRow.FindControl("ddlLanguageCode");
        //RadioButtonList RBLLanguageRigidityLevel = (RadioButtonList)gvLanguage.FooterRow.FindControl("RBLLanguageRigidityLevel");
        DropDownList ddlLanguageRigidityLevel = (DropDownList)gvLanguage.FooterRow.FindControl("ddlLanguageRigidityLevel");
        if (e.CommandName.Equals("Add"))
        {
            if (ddlLanguageCode.SelectedValue.ToString() != "")
            {
                ds = objSales.ClientLanguageSkillsAdd(BaseCompanyCode, txtClientCodeConst.Text, ddlLanguageCode.SelectedItem.Value.ToString(), ddlLanguageRigidityLevel.SelectedItem.Value, BaseUserID);
                if (gvLanguage.Rows.Count.Equals(gvLanguage.PageSize))
                {
                    gvLanguage.PageIndex = gvLanguage.PageCount + 1;
                }
                gvLanguage.EditIndex = -1;
                FillgvLanguage();
                DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            lblConstraintErrorMsg.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvLanguage.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false))
        {
            gvLanguage.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            Label lblLanguageRigiditylevel = (Label)e.Row.FindControl("lblLanguageRigiditylevel");
            if (lblLanguageRigiditylevel != null)
            {
                if (lblLanguageRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblLanguageRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblLanguageRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblLanguageRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblLanguageRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblLanguageRigiditylevel.Text = Resources.Resource.Informative;
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
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
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
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlLanguageCode = (DropDownList)e.Row.FindControl("ddlLanguageCode");
            if (ddlLanguageCode != null)
            {
                ds = objMastersManagement.LanguageMasterGetAll();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlLanguageCode.DataSource = ds.Tables[0];
                    ddlLanguageCode.DataValueField = "LanguageCode";
                    ddlLanguageCode.DataTextField = "LanguageDesc";
                    ddlLanguageCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlLanguageCode.Items.Add(li);
                }
            }
            HiddenField hfLanguageCode = (HiddenField)e.Row.FindControl("hfLanguageCode");
            if (hfLanguageCode != null && ddlLanguageCode != null)
            {
                ddlLanguageCode.SelectedValue = hfLanguageCode.Value;
                ddlLanguageCode.Enabled = false;
            }

            HiddenField HFLanguageRigidityLevel = (HiddenField)e.Row.FindControl("HFLanguageRigidityLevel");
            DropDownList ddlLanguageRigidityLevel = (DropDownList)e.Row.FindControl("ddlLanguageRigidityLevel");
            if (HFLanguageRigidityLevel != null && ddlLanguageRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlLanguageRigidityLevel);
                ddlLanguageRigidityLevel.SelectedValue = HFLanguageRigidityLevel.Value;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlLanguageCode = (DropDownList)e.Row.FindControl("ddlLanguageCode");
            if (ddlLanguageCode != null)
            {
                ds = objMastersManagement.LanguageMasterGetAll();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlLanguageCode.DataSource = ds.Tables[0];
                    ddlLanguageCode.DataValueField = "LanguageCode";
                    ddlLanguageCode.DataTextField = "LanguageDesc";
                    ddlLanguageCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlLanguageCode.Items.Add(li);
                }
            }
            DropDownList ddlLanguageRigidityLevel = (DropDownList)e.Row.FindControl("ddlLanguageRigidityLevel");
            if (ddlLanguageRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlLanguageRigidityLevel);
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Changed the Existing Functionality and added RBLLanguageRigidityLevel in it
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlLanguageCode = (DropDownList)gvLanguage.Rows[e.RowIndex].FindControl("ddlLanguageCode");
        //CheckBox cbIsMandatoryLanguage = (CheckBox)gvLanguage.Rows[e.RowIndex].FindControl("cbIsMandatoryLanguage");
        DropDownList ddlLanguageRigidityLevel = (DropDownList)gvLanguage.Rows[e.RowIndex].FindControl("ddlLanguageRigidityLevel");
        if (ddlLanguageCode.SelectedValue.ToString() != "")
        {
            ds = objSales.ClientLanguageSkillsUpdate(BaseCompanyCode, txtClientCodeConst.Text, ddlLanguageCode.SelectedValue.ToString(), ddlLanguageRigidityLevel.SelectedItem.Value, BaseUserID);

            gvLanguage.EditIndex = -1;
            FillgvLanguage();
            DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblgvLanguageCode = (Label)gvLanguage.Rows[e.RowIndex].FindControl("lblgvLanguageCode");
        HiddenField HFLanguageCode = (HiddenField)gvLanguage.Rows[e.RowIndex].FindControl("HFLanguageCode");
        ds = objSales.ClientLanguageSkillsDelete(BaseCompanyCode, txtClientCodeConst.Text, HFLanguageCode.Value);
        FillgvLanguage();
        DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvLanguage.EditIndex = e.NewEditIndex;
        FillgvLanguage();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvLanguage.EditIndex = -1;
        FillgvLanguage();
    }
    #endregion

    #region GridView Events for Qualification
    /// <summary>
    /// Fillgvs the qualification.
    /// </summary>
    protected void FillgvQualification()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.ClientQualificationSkillsGet(BaseCompanyCode, txtClientCodeConst.Text);
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
            // dt.Rows[0]["IsMandatory"] = false;
        }
        //gvQualification.DataKeyNames = new string[] { "QualificationCode" };
        gvQualification.DataSource = dt;
        gvQualification.DataBind();

        if (dtflag == 0)
        {
            gvQualification.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlQualificationCode = (DropDownList)gvQualification.FooterRow.FindControl("ddlQualificationCode");
        //RadioButtonList RBLQualificationRigidityLevel = (RadioButtonList)gvQualification.FooterRow.FindControl("RBLQualificationRigidityLevel");
        //CheckBox cbIsMandatoryQualification = (CheckBox)gvQualification.FooterRow.FindControl("cbIsMandatoryQualification");
        DropDownList ddlQualificationRigidityLevel = (DropDownList)gvQualification.FooterRow.FindControl("ddlQualificationRigidityLevel");
        if (e.CommandName.Equals("Add"))
        {
            //if (RBLQualificationRigidityLevel.SelectedValue != "")
            //{
                if (ddlQualificationCode.SelectedValue.ToString() != "")
                {
                    ds = objSales.ClientQualificationSkillsAdd(BaseCompanyCode, txtClientCodeConst.Text, ddlQualificationCode.SelectedItem.Value.ToString(), ddlQualificationRigidityLevel.SelectedItem.Value, BaseUserID);
                    //ds = objSales.ClientQualificationSkillsAdd(BaseCompanyCode, txtClientCodeConst.Text, ddlQualificationCode.SelectedItem.Value.ToString(), RBLQualificationRigidityLevel.SelectedValue.ToString(), BaseUserID);
                    if (gvQualification.Rows.Count.Equals(gvQualification.PageSize))
                    {
                        gvQualification.PageIndex = gvQualification.PageCount + 1;
                    }
                    gvQualification.EditIndex = -1;
                    FillgvQualification();
                    DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            //}
            //else
            //{
            //}
        }
        if (e.CommandName.Equals("Reset"))
        {
            lblConstraintErrorMsg.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsModifyAccess == false && IsDeleteAccess == false))
        {
            gvQualification.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false))
        {
            gvQualification.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            // e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            Label lblQualificationRigiditylevel = (Label)e.Row.FindControl("lblQualificationRigiditylevel");
            if (lblQualificationRigiditylevel != null)
            {
                if (lblQualificationRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblQualificationRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblQualificationRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblQualificationRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblQualificationRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblQualificationRigiditylevel.Text = Resources.Resource.Informative;
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
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
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
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlQualificationCode = (DropDownList)e.Row.FindControl("ddlQualificationCode");
            if (ddlQualificationCode != null)
            {
                ds = objMastersManagement.QualificationMasterGetAll();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlQualificationCode.DataSource = ds.Tables[0];
                    ddlQualificationCode.DataValueField = "QualificationCode";
                    ddlQualificationCode.DataTextField = "QualificationDesc";
                    ddlQualificationCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlQualificationCode.Items.Add(li);
                }
            }
            HiddenField hfQualificationCode = (HiddenField)e.Row.FindControl("hfQualificationCode");
            if (hfQualificationCode != null && ddlQualificationCode != null)
            {
                ddlQualificationCode.SelectedValue = hfQualificationCode.Value;
                ddlQualificationCode.Enabled = false;
            }

            HiddenField HFQualificationRigidityLevel = (HiddenField)e.Row.FindControl("HFQualificationRigidityLevel");
            DropDownList ddlQualificationRigidityLevel = (DropDownList)e.Row.FindControl("ddlQualificationRigidityLevel");

            //RadioButtonList RBLQualificationRigidityLevel = (RadioButtonList)e.Row.FindControl("RBLQualificationRigidityLevel");
            if (HFQualificationRigidityLevel != null && ddlQualificationRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlQualificationRigidityLevel);
                ddlQualificationRigidityLevel.SelectedValue = HFQualificationRigidityLevel.Value;
            //    if (HFQualificationRigidityLevel.Value != "")
            //    {
            //        if (RBLQualificationRigidityLevel != null)
            //        {
            //            RBLQualificationRigidityLevel.SelectedValue = HFQualificationRigidityLevel.Value;
            //        }
            //    }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlQualificationCode = (DropDownList)e.Row.FindControl("ddlQualificationCode");
            if (ddlQualificationCode != null)
            {
                ds = objMastersManagement.QualificationMasterGetAll();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlQualificationCode.DataSource = ds.Tables[0];
                    ddlQualificationCode.DataValueField = "QualificationCode";
                    ddlQualificationCode.DataTextField = "QualificationDesc";
                    ddlQualificationCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlQualificationCode.Items.Add(li);
                }
            }
            DropDownList ddlQualificationRigidityLevel = (DropDownList)e.Row.FindControl("ddlQualificationRigidityLevel");
            if (ddlQualificationRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlQualificationRigidityLevel);
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlQualificationCode = (DropDownList)gvQualification.Rows[e.RowIndex].FindControl("ddlQualificationCode");
        //RadioButtonList RBLQualificationRigidityLevel = (RadioButtonList)gvQualification.Rows[e.RowIndex].FindControl("RBLQualificationRigidityLevel");
        DropDownList ddlQualificationRigidityLevel = (DropDownList)gvQualification.Rows[e.RowIndex].FindControl("ddlQualificationRigidityLevel");
        if (ddlQualificationCode.SelectedValue.ToString() != "")
        {
            ds = objSales.ClientQualificationSkillsUpdate(BaseCompanyCode, txtClientCodeConst.Text, ddlQualificationCode.SelectedItem.Value.ToString(), ddlQualificationRigidityLevel.SelectedItem.Value, BaseUserID);
            //ds = objSales.ClientQualificationSkillsUpdate(BaseCompanyCode, txtClientCodeConst.Text, ddlQualificationCode.SelectedItem.Value.ToString(), RBLQualificationRigidityLevel.SelectedValue.ToString(), BaseUserID);

            gvQualification.EditIndex = -1;
            FillgvQualification();
            DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblgvQualificationCode = (Label)gvQualification.Rows[e.RowIndex].FindControl("lblgvQualificationCode");
        HiddenField HFQualificationCode = (HiddenField)gvQualification.Rows[e.RowIndex].FindControl("HFQualificationCode");
        ds = objSales.ClientQualificationSkillsDelete(BaseCompanyCode, txtClientCodeConst.Text, HFQualificationCode.Value);
        FillgvQualification();
        DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvQualification.EditIndex = e.NewEditIndex;
        FillgvQualification();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQualification.EditIndex = -1;
        FillgvQualification();
    }
    #endregion

    #region GridView Events for Training
    /// <summary>
    /// Fillgvs the training.
    /// </summary>
    protected void FillgvTraining()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.ClientTrainingSkillsGet(BaseCompanyCode, txtClientCodeConst.Text);
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
            //dt.Rows[0]["IsMandatory"] = false;
        }
        // gvTraining.DataKeyNames = new string[] { "TrainingCode" };
        gvTraining.DataSource = dt;
        gvTraining.DataBind();

        if (dtflag == 0)
        {
            gvTraining.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Changed the Existing Functionality and added RBLRigidityLevel in it
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlTrainingCode = (DropDownList)gvTraining.FooterRow.FindControl("ddlTrainingCode");
        DropDownList ddlTrainingRigidityLevel = (DropDownList)gvTraining.FooterRow.FindControl("ddlTrainingRigidityLevel");
        if (e.CommandName.Equals("Add"))
        {
            if (ddlTrainingRigidityLevel != null && ddlTrainingCode != null)
            {
                if (ddlTrainingCode.SelectedValue.ToString() != "")
                {
                    ds = objSales.ClientTrainingSkillsAdd(BaseCompanyCode, txtClientCodeConst.Text, ddlTrainingCode.SelectedItem.Value.ToString(), ddlTrainingRigidityLevel.SelectedItem.Value, BaseUserID);
                    if (gvTraining.Rows.Count.Equals(gvTraining.PageSize))
                    {
                        gvTraining.PageIndex = gvTraining.PageCount + 1;
                    }
                    gvTraining.EditIndex = -1;
                    FillgvTraining();
                    DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
        }

        if (e.CommandName.Equals("Reset"))
        {
            lblConstraintErrorMsg.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsModifyAccess == false && IsDeleteAccess == false))
        {
            gvTraining.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false))
        {
            gvTraining.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            Label lblRigiditylevel = (Label)e.Row.FindControl("lblRigiditylevel");
            if (lblRigiditylevel != null)
            {
                if (lblRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Informative;
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
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
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
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlTrainingCode = (DropDownList)e.Row.FindControl("ddlTrainingCode");
            if (ddlTrainingCode != null)
            {
                ds = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlTrainingCode.DataSource = ds.Tables[0];
                    ddlTrainingCode.DataValueField = "TrainingCode";
                    ddlTrainingCode.DataTextField = "TrainingDesc";
                    ddlTrainingCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlTrainingCode.Items.Add(li);
                }
            }
            HiddenField hfTrainingCode = (HiddenField)e.Row.FindControl("hfTrainingCode");
            if (hfTrainingCode != null && ddlTrainingCode != null)
            {
                ddlTrainingCode.SelectedValue = hfTrainingCode.Value;
                ddlTrainingCode.Enabled = false;
            }

            HiddenField HFTrainingRigidityLevel = (HiddenField)e.Row.FindControl("HFTrainingRigidityLevel");
            DropDownList ddlTrainingRigidityLevel = (DropDownList)e.Row.FindControl("ddlTrainingRigidityLevel");
            if (HFTrainingRigidityLevel != null && ddlTrainingRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlTrainingRigidityLevel);
                ddlTrainingRigidityLevel.SelectedValue = HFTrainingRigidityLevel.Value;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlTrainingCode = (DropDownList)e.Row.FindControl("ddlTrainingCode");
            if (ddlTrainingCode != null)
            {
                ds = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlTrainingCode.DataSource = ds.Tables[0];
                    ddlTrainingCode.DataValueField = "TrainingCode";
                    ddlTrainingCode.DataTextField = "TrainingDesc";
                    ddlTrainingCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlTrainingCode.Items.Add(li);
                }
            }
            DropDownList ddlTrainingRigidityLevel = (DropDownList)e.Row.FindControl("ddlTrainingRigidityLevel");
            if (ddlTrainingRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlTrainingRigidityLevel);
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Changed the Existing Functionality and added RBLRigidityLevel in it
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlTrainingCode = (DropDownList)gvTraining.Rows[e.RowIndex].FindControl("ddlTrainingCode");
        DropDownList ddlTrainingRigidityLevel = (DropDownList)gvTraining.Rows[e.RowIndex].FindControl("ddlTrainingRigidityLevel");
        if (ddlTrainingCode.SelectedValue.ToString() != "")
        {
            ds = objSales.ClientTrainingSkillsUpdate(BaseCompanyCode, txtClientCodeConst.Text, ddlTrainingCode.SelectedItem.Value.ToString(), ddlTrainingRigidityLevel.SelectedItem.Value, BaseUserID);
            gvTraining.EditIndex = -1;
            FillgvTraining();
            DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblgvTrainingCode = (Label)gvTraining.Rows[e.RowIndex].FindControl("lblgvTrainingCode");
        HiddenField HFTrainingCode = (HiddenField)gvTraining.Rows[e.RowIndex].FindControl("HFTrainingCode");
        ds = objSales.ClientTrainingSkillsDelete(BaseCompanyCode, txtClientCodeConst.Text, HFTrainingCode.Value);
        FillgvTraining();
        DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTraining.EditIndex = e.NewEditIndex;
        FillgvTraining();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTraining.EditIndex = -1;
        FillgvTraining();
    }
    #endregion

    #region GridView Events for OSkill
    /// <summary>
    /// Fillgvs the o skill.
    /// </summary>
    protected void FillgvOSkill()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.ClientOtherSkillsGet(BaseCompanyCode, txtClientCodeConst.Text);
        if (ds != null && ds.Tables.Count > 0)
        {
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
                //dt.Rows[0]["IsMandatory"] = false;
            }
            //gvOSkill.DataKeyNames = new string[] { "OtherSkillCode" };
            gvOSkill.DataSource = dt;
            gvOSkill.DataBind();

            if (dtflag == 0)
            {
                gvOSkill.Rows[0].Visible = false;
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Changed the Existing Functionality and added RBLRigidityLevel in it
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlOSkillCode = (DropDownList)gvOSkill.FooterRow.FindControl("ddlOSkillCode");
        DropDownList ddlSkillRigidityLevel = (DropDownList)gvOSkill.FooterRow.FindControl("ddlSkillRigidityLevel");
        if (e.CommandName.Equals("Add"))
        {
            if (ddlSkillRigidityLevel != null && ddlOSkillCode != null)
            {
                if (ddlOSkillCode.SelectedValue.ToString() != "")
                {
                    ds = objSales.ClientOtherSkillsAdd(BaseCompanyCode, txtClientCodeConst.Text, ddlOSkillCode.SelectedItem.Value.ToString(), ddlSkillRigidityLevel.SelectedItem.Value, BaseUserID);
                    if (gvOSkill.Rows.Count.Equals(gvOSkill.PageSize))
                    {
                        gvOSkill.PageIndex = gvOSkill.PageCount + 1;
                    }
                    gvOSkill.EditIndex = -1;
                    FillgvOSkill();
                    DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            lblConstraintErrorMsg.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsModifyAccess == false && IsDeleteAccess == false))
        {
            gvOSkill.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false))
        {
            gvOSkill.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            Label lblRigiditylevel = (Label)e.Row.FindControl("lblRigiditylevel");
            if (lblRigiditylevel != null)
            {
                if (lblRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Informative;
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
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
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
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

            DataSet ds = new DataSet();
            BL.HRManagement objHrManagement = new BL.HRManagement();
            DropDownList ddlOSkillCode = (DropDownList)e.Row.FindControl("ddlOSkillCode");
            if (ddlOSkillCode != null)
            {
                // ds = objHrManagement.blQuickCodeEmployeeSkillTypes_Get(BaseCompanyCode);
                ds = objHrManagement.EmployeeIdTypeGet();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlOSkillCode.DataSource = ds.Tables[0];
                    ddlOSkillCode.DataValueField = "IDTypeCode";
                    ddlOSkillCode.DataTextField = "IDTypeDesc";
                    ddlOSkillCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlOSkillCode.Items.Add(li);
                }
            }
            HiddenField hfOSkillCode = (HiddenField)e.Row.FindControl("hfOSkillCode");
            if (hfOSkillCode != null && ddlOSkillCode != null)
            {
                ddlOSkillCode.SelectedValue = hfOSkillCode.Value;
                ddlOSkillCode.Enabled = false;
            }
            // Added this to assign seleted value of RBLRigidityLevel when in Edit Mode
            HiddenField HFSkillRigidityLevel = (HiddenField)e.Row.FindControl("HFSkillRigidityLevel");
            DropDownList ddlSkillRigidityLevel = (DropDownList)e.Row.FindControl("ddlSkillRigidityLevel");
            if (HFSkillRigidityLevel != null && ddlSkillRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlSkillRigidityLevel);
                ddlSkillRigidityLevel.SelectedValue = HFSkillRigidityLevel.Value;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.HRManagement objHrManagement = new BL.HRManagement();
            DropDownList ddlOSkillCode = (DropDownList)e.Row.FindControl("ddlOSkillCode");
            if (ddlOSkillCode != null)
            {
                // ds = objHrManagement.blQuickCodeEmployeeSkillTypes_Get(BaseCompanyCode);
                ds = objHrManagement.EmployeeIdTypeGet();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlOSkillCode.DataSource = ds.Tables[0];
                    ddlOSkillCode.DataValueField = "IDTypeCode";
                    ddlOSkillCode.DataTextField = "IDTypeDesc";
                    ddlOSkillCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlOSkillCode.Items.Add(li);
                }
            }
            DropDownList ddlSkillRigidityLevel = (DropDownList)e.Row.FindControl("ddlSkillRigidityLevel");
            if (ddlSkillRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlSkillRigidityLevel);
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Changed the Existing Functionality and added RBLRigidityLevel in it
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlOSkillCode = (DropDownList)gvOSkill.Rows[e.RowIndex].FindControl("ddlOSkillCode");
        DropDownList ddlSkillRigidityLevel = (DropDownList)gvOSkill.Rows[e.RowIndex].FindControl("ddlSkillRigidityLevel");
        if (ddlOSkillCode != null && ddlSkillRigidityLevel != null && ddlOSkillCode.SelectedValue.ToString() != "")
        {
            ds = objSales.ClientOtherSkillsUpdate(BaseCompanyCode, txtClientCodeConst.Text, ddlOSkillCode.SelectedItem.Value.ToString(), ddlSkillRigidityLevel.SelectedItem.Value, BaseUserID);
            gvOSkill.EditIndex = -1;
            FillgvOSkill();
            DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblgvOSkillCode = (Label)gvOSkill.Rows[e.RowIndex].FindControl("lblgvOSkillCode");
        HiddenField HFSkillCode = (HiddenField)gvOSkill.Rows[e.RowIndex].FindControl("HFSkillCode");

        ds = objSales.ClientOtherSkillsDelete(BaseCompanyCode, txtClientCodeConst.Text, HFSkillCode.Value);
        FillgvOSkill();
        DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOSkill.EditIndex = e.NewEditIndex;
        FillgvOSkill();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOSkill.EditIndex = -1;
        FillgvOSkill();
    }
    #endregion

    /// <summary>
    /// Handles the PageIndexChanging event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOSkill.PageIndex = e.NewPageIndex;
        gvOSkill.EditIndex = -1;
        FillgvOSkill();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTraining.PageIndex = e.NewPageIndex;
        gvTraining.EditIndex = -1;
        FillgvTraining();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLanguage.PageIndex = e.NewPageIndex;
        gvLanguage.EditIndex = -1;
        FillgvLanguage();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQualification.PageIndex = e.NewPageIndex;
        gvQualification.EditIndex = -1;
        FillgvQualification();
    }

    /// <summary>
    /// Gets all records non editable.
    /// </summary>
    private void getAllRecordsNonEditable()
    {

        DataSet ds = new DataSet();
        BL.Interface objInterface = new BL.Interface();
        ds = objInterface.GetAllRecordsOnScreenName("Client Creation");

        InterfacePage objInterfacePage = new InterfacePage();

        objInterfacePage.ControlsNonEditable(ds, this.Page);

    }

    /// <summary>
    /// Gets all records editable.
    /// </summary>
    private void getAllRecordsEditable()
    {


        DataSet ds = new DataSet();
        BL.Interface objInterface = new BL.Interface();
        ds = objInterface.GetAllRecordsOnScreenName("Client Creation");
        InterfacePage obj = new InterfacePage();
        obj.ControlsEditable(ds, this.Page);


    }
    protected void lbtnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientMaster.aspx");
    }


}
