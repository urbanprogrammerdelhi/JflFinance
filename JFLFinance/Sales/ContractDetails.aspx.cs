// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ContractDetails.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;

/// <summary>
/// Class Sales_ContractDetails.
/// </summary>
public partial class Sales_ContractDetails : BasePage // System.Web.UI.Page
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

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Changes for Base currency in amount fields Starts
        lblGenClaimCurr.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblIncomeMonthCurr.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblIncomeMonthCurr1.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblIncomeMonthCurr2.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblanyoneincCurr1.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblanyoneincCurr2.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblInAggCurr1.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblInAggCurr2.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblInAggCurr3.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";

        //Changes for Base currency in amount fields Ends

        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.qubicDetail;
            //}
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.qubicDetail + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                if (Request.QueryString["ContractNumber"] != null && Request.QueryString["ClientCode"] != null)
                {
                    txtContractNumber.Text = Request.QueryString["ContractNumber"];
                    txtClientCode.Text = Request.QueryString["ClientCode"];

                    btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    btnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    btnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    FillContractDetails();
                }
                if (Request.QueryString["AmendNo"] != null)
                {
                    hfAmendNo.Value = Request.QueryString["AmendNo"].ToString();
                }
                txtTechnicalServicesIncomePerMonth.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtTechnicalServicesIncomePerMonth.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";

                txtSafetyServicesIncomePerMonth.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtSafetyServicesIncomePerMonth.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";

                txtOtherServicesIncomePerMonth.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtOtherServicesIncomePerMonth.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";

                txtNuclearIncident.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtNuclearIncident.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";

                txtNuclearAggregate.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtNuclearAggregate.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";

                txtConsquentialLossesIncident.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtConsquentialLossesIncident.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";

                txtConsquentialLossesAggregate.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtConsquentialLossesAggregate.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";

                txtGeneralClaimsAnyOne.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtGeneralClaimsAnyOne.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";

                txtGeneralClaimsAggregate.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtGeneralClaimsAggregate.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            SetUserRights();
        }
    }
    /// <summary>
    /// Fills the contract details.
    /// </summary>
    protected void FillContractDetails()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();

        ds = objSales.ClientNameDetailGet(txtClientCode.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        }

        ds = objSales.ContractDetailsGet(BaseLocationAutoID, txtContractNumber.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtClientRegNo.Text = ds.Tables[0].Rows[0]["ClientRegNo"].ToString();
            cbPerimInternalArea.Checked = bool.Parse(ds.Tables[0].Rows[0]["PrimInternalArea"].ToString());
            cbAccessExitControle.Checked = bool.Parse(ds.Tables[0].Rows[0]["AccessExitControle"].ToString());
            cbPassSystemadmin.Checked = bool.Parse(ds.Tables[0].Rows[0]["PassSystemadmin"].ToString());
            cbScreeningServices.Checked = bool.Parse(ds.Tables[0].Rows[0]["ScreeningServices"].ToString());
            cbResponseServices.Checked = bool.Parse(ds.Tables[0].Rows[0]["ResponseServices"].ToString());
            cbOtherGuardingServices.Checked = bool.Parse(ds.Tables[0].Rows[0]["OtherGuardingServices"].ToString());
            cbTechnicalServices.Checked = bool.Parse(ds.Tables[0].Rows[0]["TechnicalServices"].ToString());
            txtTechnicalServicesIncomePerMonth.Text =  GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["TechnicalServicesIncomePerMonth"].ToString(),int.Parse(BaseDigitsAfterDecimalPlaces),int.Parse(BaseRoundOffCheck));
            cbSafetyServices.Checked = bool.Parse(ds.Tables[0].Rows[0]["SafetyServices"].ToString());
            txtSafetyServicesIncomePerMonth.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["SafetyServicesIncomePerMonth"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            cbOtherServices.Checked = bool.Parse(ds.Tables[0].Rows[0]["OtherServices"].ToString());
            txtOtherServicesIncomePerMonth.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["OtherServicesIncomePerMonth"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            cbNuclearRiskCovered.Checked = bool.Parse(ds.Tables[0].Rows[0]["NuclearRiskCovered"].ToString());
            txtNuclearIncident.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["NuclearIncident"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            txtNuclearAggregate.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["NuclearAggregate"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            //cbConsquentialLosses.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["ConsquentialLosses"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            txtConsquentialLossesIncident.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["ConsquentialLossesIncident"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            txtConsquentialLossesAggregate.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["ConsquentialLossesAggregate"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            txtGeneralClaimsAnyOne.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["GeneralClaimsAnyOne"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            txtGeneralClaimsAggregate.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["GeneralClaimsAggregate"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));

            cbThirdPartyIndemnity.Checked = bool.Parse(ds.Tables[0].Rows[0]["ThirdPartyIndemnity"].ToString());
            cbForceMajeureClause.Checked = bool.Parse(ds.Tables[0].Rows[0]["ForceMajeureClause"].ToString());
            cbHighRiskContract.Checked = bool.Parse(ds.Tables[0].Rows[0]["HighRiskContract"].ToString());
            cbPersonsMoreThenFiveThousand.Checked = bool.Parse(ds.Tables[0].Rows[0]["PersonsMoreThenFiveThousand"].ToString());
            txtJurisdiction.Text = ds.Tables[0].Rows[0]["Jurisdiction"].ToString();
            txtApplicaleLaw.Text = ds.Tables[0].Rows[0]["ApplicaleLaw"].ToString();
            
            btnEdit.Visible = true;
            btnSave.Visible = false;
            ReadonlyMode();
        }
        else
        {
            btnSave.Visible = true;

            btnEdit.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;

            txtContractNumber.Attributes.Add("readonly", "readonly");
            txtClientCode.Attributes.Add("readonly", "readonly");
            txtClientName.Attributes.Add("readonly", "readonly");
        }

    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        if (txtContractNumber.Text.Length > 0)
        {
            ValidateNumericTextBox();
            ds = objSales.ContractDetailsInsert(BaseLocationAutoID, txtContractNumber.Text, txtClientRegNo.Text, cbPerimInternalArea.Checked.ToString(), cbAccessExitControle.Checked.ToString(), cbPassSystemadmin.Checked.ToString(), cbScreeningServices.Checked.ToString(), cbResponseServices.Checked.ToString(), cbOtherGuardingServices.Checked.ToString(), cbTechnicalServices.Checked.ToString(), txtTechnicalServicesIncomePerMonth.Text, cbSafetyServices.Checked.ToString(), txtSafetyServicesIncomePerMonth.Text, cbOtherServices.Checked.ToString(), txtOtherServicesIncomePerMonth.Text, cbNuclearRiskCovered.Checked.ToString(), txtNuclearIncident.Text, txtNuclearAggregate.Text, cbConsquentialLosses.Checked.ToString(), txtConsquentialLossesIncident.Text, txtConsquentialLossesAggregate.Text, txtGeneralClaimsAnyOne.Text, txtGeneralClaimsAggregate.Text, cbThirdPartyIndemnity.Checked.ToString(), cbForceMajeureClause.Checked.ToString(), cbHighRiskContract.Checked.ToString(), cbPersonsMoreThenFiveThousand.Checked.ToString(), txtJurisdiction.Text, txtApplicaleLaw.Text, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            FillContractDetails();
        }
    }
    /// <summary>
    /// Validates the numeric text box.
    /// </summary>
    protected void ValidateNumericTextBox()
    {
        if (txtTechnicalServicesIncomePerMonth.Text.Length == 0)
        {txtTechnicalServicesIncomePerMonth.Text = "0";}

        if (txtSafetyServicesIncomePerMonth.Text.Length == 0)
        { txtSafetyServicesIncomePerMonth.Text = "0"; }

        if (txtOtherServicesIncomePerMonth.Text.Length == 0)
        { txtOtherServicesIncomePerMonth.Text = "0"; }

        if (txtNuclearIncident.Text.Length == 0)
        { txtNuclearIncident.Text = "0"; }

        if (txtNuclearAggregate.Text.Length == 0)
        {txtNuclearAggregate.Text = "0"; }
        
        if (txtConsquentialLossesIncident.Text.Length == 0)
        { txtConsquentialLossesIncident.Text = "0"; }

        if (txtConsquentialLossesAggregate.Text.Length == 0)
        { txtConsquentialLossesAggregate.Text = "0"; }

        if (txtGeneralClaimsAnyOne.Text.Length == 0)
        {txtGeneralClaimsAnyOne.Text = "0"; }

        if (txtGeneralClaimsAggregate.Text.Length == 0)
        {txtGeneralClaimsAggregate.Text = "0"; }
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
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        if (txtContractNumber.Text.Length > 0)
        {
            ValidateNumericTextBox();
            ds = objSales.ContractDetailsUpdate(BaseLocationAutoID, txtContractNumber.Text, txtClientRegNo.Text, cbPerimInternalArea.Checked.ToString(), cbAccessExitControle.Checked.ToString(), cbPassSystemadmin.Checked.ToString(), cbScreeningServices.Checked.ToString(), cbResponseServices.Checked.ToString(), cbOtherGuardingServices.Checked.ToString(), cbTechnicalServices.Checked.ToString(), txtTechnicalServicesIncomePerMonth.Text, cbSafetyServices.Checked.ToString(), txtSafetyServicesIncomePerMonth.Text, cbOtherServices.Checked.ToString(), txtOtherServicesIncomePerMonth.Text, cbNuclearRiskCovered.Checked.ToString(), txtNuclearIncident.Text, txtNuclearAggregate.Text, cbConsquentialLosses.Checked.ToString(), txtConsquentialLossesIncident.Text, txtConsquentialLossesAggregate.Text, txtGeneralClaimsAnyOne.Text, txtGeneralClaimsAggregate.Text, cbThirdPartyIndemnity.Checked.ToString(), cbForceMajeureClause.Checked.ToString(), cbHighRiskContract.Checked.ToString(), cbPersonsMoreThenFiveThousand.Checked.ToString(), txtJurisdiction.Text, txtApplicaleLaw.Text, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            FillContractDetails();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        if (txtContractNumber.Text.Length > 0)
        {
            ds = objSales.ContractDetailsDelete(BaseLocationAutoID, txtContractNumber.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            FillContractDetails();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        FillContractDetails();
    }

    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Sales/ContractMaster.aspx?ClientCode=" + txtClientCode.Text + "&ContractNumber=" + txtContractNumber.Text + "&AmendNo=" + hfAmendNo.Value.ToString());
    }
    /// <summary>
    /// Readonlies the mode.
    /// </summary>
    protected void ReadonlyMode()
    {
        txtContractNumber.Attributes.Add("readonly", "readonly");
        txtClientCode.Attributes.Add("readonly", "readonly");
        txtClientName.Attributes.Add("readonly", "readonly");
        txtClientRegNo.Attributes.Add("readonly", "readonly");
        cbPerimInternalArea.Enabled = false;
        cbAccessExitControle.Enabled = false;
        cbPassSystemadmin.Enabled = false;
        cbScreeningServices.Enabled = false;
        cbResponseServices.Enabled = false;
        cbOtherGuardingServices.Enabled = false;
        cbTechnicalServices.Enabled = false;
        txtTechnicalServicesIncomePerMonth.Attributes.Add("readonly", "readonly");
        cbSafetyServices.Enabled = false;
        txtSafetyServicesIncomePerMonth.Attributes.Add("readonly", "readonly");
        cbOtherServices.Enabled = false;
        txtOtherServicesIncomePerMonth.Attributes.Add("readonly", "readonly");
        cbNuclearRiskCovered.Enabled = false;
        txtNuclearIncident.Attributes.Add("readonly", "readonly");
        txtNuclearAggregate.Attributes.Add("readonly", "readonly");
        cbConsquentialLosses.Enabled = false;
        txtConsquentialLossesIncident.Attributes.Add("readonly", "readonly");
        txtConsquentialLossesAggregate.Attributes.Add("readonly", "readonly");
        txtGeneralClaimsAnyOne.Attributes.Add("readonly", "readonly");
        txtGeneralClaimsAggregate.Attributes.Add("readonly", "readonly");
        cbThirdPartyIndemnity.Enabled = false;
        cbForceMajeureClause.Enabled = false;
        cbHighRiskContract.Enabled = false;
        cbPersonsMoreThenFiveThousand.Enabled = false;
        txtJurisdiction.Attributes.Add("readonly", "readonly");
        txtApplicaleLaw.Attributes.Add("readonly", "readonly");

        btnUpdate.Visible = false;
        btnCancel.Visible = false;
    }
    /// <summary>
    /// Edits the mode.
    /// </summary>
    protected void EditMode()
    {
        txtContractNumber.Attributes.Add("readonly", "readonly");
        txtClientCode.Attributes.Add("readonly", "readonly");
        txtClientName.Attributes.Add("readonly", "readonly");
        txtClientRegNo.Attributes.Remove("readonly");
        cbPerimInternalArea.Enabled = true;
        cbAccessExitControle.Enabled = true;
        cbPassSystemadmin.Enabled = true;
        cbScreeningServices.Enabled = true;
        cbResponseServices.Enabled = true;
        cbOtherGuardingServices.Enabled = true;
        cbTechnicalServices.Enabled = true;
        txtTechnicalServicesIncomePerMonth.Attributes.Remove("readonly");
        cbSafetyServices.Enabled = true;
        txtSafetyServicesIncomePerMonth.Attributes.Remove("readonly");
        cbOtherServices.Enabled = true;
        txtOtherServicesIncomePerMonth.Attributes.Remove("readonly");
        cbNuclearRiskCovered.Enabled = true;
        txtNuclearIncident.Attributes.Remove("readonly");
        txtNuclearAggregate.Attributes.Remove("readonly");
        cbConsquentialLosses.Enabled = true;
        txtConsquentialLossesIncident.Attributes.Remove("readonly");
        txtConsquentialLossesAggregate.Attributes.Remove("readonly");
        txtGeneralClaimsAnyOne.Attributes.Remove("readonly");
        txtGeneralClaimsAggregate.Attributes.Remove("readonly");
        cbThirdPartyIndemnity.Enabled = true;
        cbForceMajeureClause.Enabled = true;
        cbHighRiskContract.Enabled = true;
        cbPersonsMoreThenFiveThousand.Enabled = true;
        txtJurisdiction.Attributes.Remove("readonly");
        txtApplicaleLaw.Attributes.Remove("readonly");

        btnUpdate.Visible = true;
        btnCancel.Visible = true;

        btnSave.Visible = false;
        btnEdit.Visible = false;
        btnDelete.Visible = false;
    }
    /// <summary>
    /// Sets the user rights.
    /// </summary>
    protected void SetUserRights()
    {
        //Checking Delete rights
        if (IsDeleteAccess == true)
        { btnDelete.Enabled = true; }
        else
        { btnDelete.Enabled = false;}

        //Checking modify rights
        if(IsModifyAccess == true)
        {
            btnUpdate.Enabled = true;
            btnEdit.Enabled = true;
        }
        else
        {
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
        }
        if (IsWriteAccess == true)
        { btnSave.Enabled = true; }
        else
        { btnSave.Enabled = false; }


    }
}
