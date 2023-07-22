// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="CompanyClient.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_CompanyClient.
/// </summary>
public partial class Sales_CompanyClient : BasePage //System.Web.UI.Page
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

    #region Page functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EnableButtons();
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.ClientCompanyMapping;
            //}

            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ClientCompanyMapping + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {

                btnSubmit.Attributes.Add("onclick", "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "')");
                btnUpdate.Attributes.Add("onclick", "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "')");
                DataSet ds = new DataSet();
                BL.MastersManagement objMastersManagement = new BL.MastersManagement();

                ds = objMastersManagement.CountryMasterGetAll(BaseCompanyCode);
                ddlCountryCode.DataSource = ds.Tables[0];
                ddlCountryCode.DataValueField = "CountryCode";
                ddlCountryCode.DataTextField = "Country";
                ddlCountryCode.DataBind();
                if (ddlCountryCode.Text == "")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlCountryCode.Items.Add(li);
                    DisableButtons();
                }

                if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length > 0)
                {
                    lblClientCode.Text = Request.QueryString["ClientCode"].ToString();
                    FillDetails();
                    txtManualClientCode.ReadOnly = true;
                    txtClientName.ReadOnly = true;
                    lblClientddlhdr.Visible = false;
                    ddlClientCompanyNotMapped.Visible = false;
                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                    if (IsModifyAccess == true)
                    {
                        btnUpdate.Enabled = true;
                        btnCancel.Enabled = true;
                        lbGetHOClientAdd.Enabled = true;
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
                        btnCancel.Enabled = false;
                        lbGetHOClientAdd.Enabled = false;
                    }
                }
                else
                {
                    FillddlClientCompanyNotMapped();
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    if (IsWriteAccess == true)
                    {
                        btnSubmit.Enabled = true;
                        btnReset.Enabled = true;
                        lbGetHOClientAdd.Enabled = true;
                    }
                    else
                    {
                        btnSubmit.Enabled = false;
                        btnReset.Enabled = false;
                        lbGetHOClientAdd.Enabled = false;
                    }
                }

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    /// <summary>
    /// Validations the on controles.
    /// </summary>
    private void ValidationOnControles()
    {
        txtAddressLine1.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtAddressLine1.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

        txtAddressLine2.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtAddressLine2.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

        txtAddressLine3.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtAddressLine3.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

        txtCity.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtCity.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

        txtState.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtState.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

        txtPin.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
        txtPin.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

        txtPhone.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
        txtPhone.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

        txtFax.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
        txtFax.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

        txtClientContactPersonDesignation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtClientContactPersonDesignation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

        txtOurContactPerson.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtOurContactPerson.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

        txtClientContactPersonMobile.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
        txtClientContactPersonMobile.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

        txtOurContactPersonMobile.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
        txtOurContactPersonMobile.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

        txtComments.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtComments.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

    }
    /// <summary>
    /// Disables the buttons.
    /// </summary>
    private void DisableButtons()
    {
        btnCancel.Enabled = false;
        btnUpdate.Enabled = false;
        btnSubmit.Enabled = false;
        btnReset.Enabled = false;
    }
    /// <summary>
    /// Enables the buttons.
    /// </summary>
    private void EnableButtons()
    {
        btnCancel.Enabled = true;
        btnUpdate.Enabled = true;
        btnSubmit.Enabled = true;
        btnReset.Enabled = true;
    }
    /// <summary>
    /// Fills the details.
    /// </summary>
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.ClientDetailGet(BaseCompanyCode, lblClientCode.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtManualClientCode.Text = ds.Tables[0].Rows[0]["ManualClientCode"].ToString();
            txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
            txtAddressLine1.Text = ds.Tables[0].Rows[0]["ClientAddressLine1"].ToString();
            txtAddressLine2.Text = ds.Tables[0].Rows[0]["ClientAddressLine2"].ToString();
            txtAddressLine3.Text = ds.Tables[0].Rows[0]["ClientAddressLine3"].ToString();
            txtWebSite.Text = ds.Tables[0].Rows[0]["WebSite"].ToString();
            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
            txtPin.Text = ds.Tables[0].Rows[0]["Pin"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            ddlCountryCode.SelectedValue = ds.Tables[0].Rows[0]["CountryCode"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            txtClientContactPerson.Text = ds.Tables[0].Rows[0]["ClientContactPerson"].ToString();
            txtOurContactPersonEmpNo.Text = ds.Tables[0].Rows[0]["OurContactPersonEmpNo"].ToString();
            txtClientContactPersonDesignation.Text = ds.Tables[0].Rows[0]["ClientContactPersonDesignation"].ToString();
            txtOurContactPerson.Text = ds.Tables[0].Rows[0]["OurContactPerson"].ToString();
            txtClientContactPersonMobile.Text = ds.Tables[0].Rows[0]["ClientContactpersonMobile"].ToString();
            txtOurContactPersonMobile.Text = ds.Tables[0].Rows[0]["OurContactPersonMobile"].ToString();
            txtComments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
        }

    }
    /// <summary>
    /// Fillddls the client company not mapped.
    /// </summary>
    private void FillddlClientCompanyNotMapped()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.ClientsNotMappedWithCompanyGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCompanyNotMapped.DataSource = ds.Tables[0];
            ddlClientCompanyNotMapped.DataTextField = "ClientCodeName";
            ddlClientCompanyNotMapped.DataValueField = "ClientCode";
            ddlClientCompanyNotMapped.DataBind();
        }
        else
        {
            if (ddlClientCompanyNotMapped.Items.Count == 0)
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoDataToShow;
                li.Value = "";
                ddlClientCompanyNotMapped.Items.Add(li);
                DisableButtons();
            }
            else
            {
                ds = objSales.ClientNameGet(ddlClientCompanyNotMapped.SelectedItem.Value.ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                    txtManualClientCode.Text = ds.Tables[0].Rows[0]["ManualClientCode"].ToString();
                    txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                }
            }
        }
    }
    #endregion

    #region page controles events
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //txtManualClientCode.Text = "";
        //txtClientName.Text = "";
        txtAddressLine1.Text = "";
        txtAddressLine2.Text = "";
        txtAddressLine3.Text = "";
        txtCity.Text = "";
        txtPin.Text = "";
        txtPhone.Text = "";
        txtState.Text = "";
        txtFax.Text = "";
        txtWebSite.Text = "";
        txtEmail.Text = "";
        txtClientContactPerson.Text = "";
        txtClientContactPersonDesignation.Text = "";
        txtClientContactPersonMobile.Text = "";
        txtOurContactPerson.Text = "";
        txtOurContactPersonEmpNo.Text = "";
        txtOurContactPersonMobile.Text = "";
        txtComments.Text = "";

    }
    /// <summary>
    /// Handles the Click event of the btnList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnList_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/CompanyClientList.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbGetHOClientAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbGetHOClientAdd_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        //ds = objSales.blClientMaster_GetDetailBasedOnClientCode(lblClientCode.Text);
        ds = objSales.ClientDetailGet(ddlClientCompanyNotMapped.SelectedValue.ToString().Trim());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblClientCode.Text = ddlClientCompanyNotMapped.SelectedValue.ToString();
            txtManualClientCode.Text = ds.Tables[0].Rows[0]["ManualClientCode"].ToString();
            txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();

            txtAddressLine1.Text = ds.Tables[0].Rows[0]["ClientAddressLine1"].ToString();
            txtAddressLine2.Text = ds.Tables[0].Rows[0]["ClientAddressLine2"].ToString();
            txtAddressLine3.Text = ds.Tables[0].Rows[0]["ClientAddressLine3"].ToString();
            txtWebSite.Text = ds.Tables[0].Rows[0]["WebSite"].ToString();
            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
            txtPin.Text = ds.Tables[0].Rows[0]["Pin"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            ddlCountryCode.SelectedValue = ds.Tables[0].Rows[0]["CountryCode"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            txtClientContactPerson.Text = ds.Tables[0].Rows[0]["ClientContactPerson"].ToString();
            txtOurContactPersonEmpNo.Text = ds.Tables[0].Rows[0]["OurContactPersonEmpNo"].ToString();
            txtClientContactPersonDesignation.Text = ds.Tables[0].Rows[0]["ClientContactPersonDesignation"].ToString();
            txtOurContactPerson.Text = ds.Tables[0].Rows[0]["OurContactPerson"].ToString();
            txtClientContactPersonMobile.Text = ds.Tables[0].Rows[0]["ClientContactpersonMobile"].ToString();
            txtOurContactPersonMobile.Text = ds.Tables[0].Rows[0]["OurContactPersonMobile"].ToString();
            txtComments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
        }
    }

    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/CompanyClientList.aspx");
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCompanyNotMapped control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCompanyNotMapped_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.ClientNameGet(ddlClientCompanyNotMapped.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
            txtManualClientCode.Text = ds.Tables[0].Rows[0]["ManualClientCode"].ToString();
            txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.ClientCompanyMappingUpdate(BaseCompanyCode, lblClientCode.Text, txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtCity.Text, txtState.Text, txtPin.Text, ddlCountryCode.SelectedItem.Value.ToString(), txtPhone.Text, txtFax.Text, txtWebSite.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, txtOurContactPerson.Text, txtOurContactPersonEmpNo.Text, txtOurContactPersonMobile.Text, txtComments.Text, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objSale = new BL.Sales();
        ds = objSale.ClientCompanyMappingInsert(BaseCompanyCode, lblClientCode.Text, txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtCity.Text, txtState.Text, txtPin.Text, ddlCountryCode.SelectedItem.Value.ToString(), txtPhone.Text, txtFax.Text, txtWebSite.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, txtOurContactPerson.Text, txtOurContactPersonEmpNo.Text, txtOurContactPersonMobile.Text, txtComments.Text, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    #endregion

}
