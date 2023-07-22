// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="InvestigationRequestDetails.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Class OperationManagement_InvestigationRequestDetails.
/// </summary>
public partial class OperationManagement_InvestigationRequestDetails : BasePage//System.Web.UI.Page
{
    //Added Code for Upload Document by  on 25-Jun-2013
    /// <summary>
    /// The dt upload
    /// </summary>
    static DataTable dtUpload = new DataTable();
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

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {           
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.InvestigationRequestDetails + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            btnSave.Enabled = false;            //Added by  on 2-Jun-2013
            if (IsReadAccess == true)
            {
                hideshowButton("");
                enabledisableField("");
                try
                {
                    if (Request.QueryString["InvestigationNumber"].ToString() != "")
                    {
                        txtInvestigationNo.Text = Request.QueryString["InvestigationNumber"].ToString();
                        txtInvestigationNo_TextChanged(sender, e);
                    }
                }
                catch (Exception)
                {

                }
                IMGInvestigationNo.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=INVESTCCH&ControlId=" + txtInvestigationNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                // IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,help=no')");
                
                //Added Code for Upload Document by  on 25-Jun-2013
                CreateUploadTable();
                dvFileUploadGrid.Visible = false;
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                //End
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    /// <summary>
    /// Clears the fields.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    private void ClearFields(string strParam)
    {
        if (strParam == "")
        {
            lblStatus.Text = "";
            txtInvestigationNo.Text = "";
            txtInvDetDate.Text = "";
            txtInvestigationNoShow.Text = "";
            //txtAssignNo.Text = "";
            txtIncidentNo.Text = "";
            txtIncidentType.Text = "";
            //txtCustomerID.Text = "";
            //txtCustomerDesc.Text = "";
            //txtAddressID.Text = "";
            //txtAddressDesc.Text = "";
            txtAreaID.Text = "";
            txtAreaDesc.Text = "";
            txtReasonForInv.Text = "";
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtEmpDesignation.Text = "";
            txtFindings.Text = "";
            txtDetails.Text = "";
            ddlLegalAssistance.SelectedIndex = 0;
            ddlStaffInvolved.SelectedIndex = 0;
            ddlCustInvolved.SelectedIndex = 0;
            //Added by  on 31-May-2013
            ddlClientId.Items.Clear();
            ddlClientId.Enabled = false;
            ddlAsmtId.Items.Clear();
            ddlAsmtId.Enabled = false;
        }
    }
    /// <summary>
    /// Hideshows the button.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    private void hideshowButton(string strParam)
    {
        if (strParam == "")
        {
            if (lblStatus.Text == Resources.Resource.Fresh)
            {
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
                    btnUpdate.Visible = true;
                }
                btnEdit.Visible = false;
                btnReset.Visible = true;
                btnSave.Visible = false;
            }
            else if (lblStatus.Text == Resources.Resource.Amend)
            {
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
                    btnUpdate.Visible = true;
                }
                btnEdit.Visible = false;
                //btnAddNew.Visible = true;
                btnReset.Visible = true;
                btnSave.Visible = false;
            }
            else if (lblStatus.Text == Resources.Resource.Authorized)
            {
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
                    btnEdit.Visible = true;
                }
                btnAuthorize.Visible = false;
                
                btnUpdate.Visible = false;
                btnReset.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                if (IsWriteAccess == true)
                {
                    btnSave.Visible = true;
                }
                btnAuthorize.Visible = false;
                btnEdit.Visible = false;
                btnUpdate.Visible = false;
                //btnAddNew.Visible = true;
                btnReset.Visible = true;
                
            }
        }
    }
    /// <summary>
    /// Enabledisables the field.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    private void enabledisableField(string strParam)
    {
        if (strParam == "")
        {
            if (lblStatus.Text == Resources.Resource.Fresh)
            {
                txtInvestigationNo.Enabled = true;
                //txtInvDetDate.Enabled = true;
                txtInvestigationNoShow.Enabled = false;
                //txtAssignNo.Enabled = false;
                txtIncidentNo.Enabled = false;
                txtIncidentType.Enabled = false;
                txtReasonForInv.Enabled = false;
                txtEmployeeID.Enabled = true;
                txtEmployeeName.Enabled = false;
                txtEmpDesignation.Enabled = false;
                txtFindings.Enabled = true;
                ddlLegalAssistance.SelectedIndex = 0;
                ddlStaffInvolved.SelectedIndex = 0;
                ddlCustInvolved.SelectedIndex = 0;
                ddlLegalAssistance.Enabled = true;
                ddlStaffInvolved.Enabled = true;
                ddlCustInvolved.Enabled = true;
            }
            else if (lblStatus.Text == Resources.Resource.Amend)
            {
                txtInvestigationNo.Enabled = true;
                //txtInvDetDate.Enabled = true;
                txtInvestigationNoShow.Enabled = false;
                //txtAssignNo.Enabled = false;
                txtIncidentNo.Enabled = false;
                txtIncidentType.Enabled = false;
                txtReasonForInv.Enabled = false;
                txtEmployeeID.Enabled = true;
                txtEmployeeName.Enabled = false;
                txtEmpDesignation.Enabled = false;
                txtFindings.Enabled = true;
                ddlLegalAssistance.Enabled = true;
                ddlStaffInvolved.Enabled = true;
                ddlCustInvolved.Enabled = true;
            }
            else if (lblStatus.Text == Resources.Resource.Authorized)
            {
                txtInvestigationNo.Enabled = true;
                txtInvDetDate.Enabled = false;
                txtInvestigationNoShow.Enabled = false;
                //txtAssignNo.Enabled = false;
                txtIncidentNo.Enabled = false;
                txtIncidentType.Enabled = false;
                txtReasonForInv.Enabled = false;
                txtEmployeeID.Enabled = false;
                txtEmployeeName.Enabled = false;
                txtEmpDesignation.Enabled = false;
                txtFindings.Enabled = false;
                ddlLegalAssistance.Enabled = false;
                ddlStaffInvolved.Enabled = false;
                ddlCustInvolved.Enabled = false;
            }
            else
            {
                txtInvestigationNo.Enabled = true;
                //txtInvDetDate.Enabled = true;
                txtInvestigationNoShow.Enabled = false;
                //txtAssignNo.Enabled = false;
                txtIncidentNo.Enabled = false;
                txtIncidentType.Enabled = false;
                txtReasonForInv.Enabled = false;
                txtEmployeeID.Enabled = true;
                txtEmployeeName.Enabled = false;
                txtEmpDesignation.Enabled = false;
                txtFindings.Enabled = true;
                ddlLegalAssistance.SelectedIndex = 0;
                ddlStaffInvolved.SelectedIndex = 0;
                ddlCustInvolved.SelectedIndex = 0;
                ddlLegalAssistance.Enabled = true;
                ddlStaffInvolved.Enabled = true;
                ddlCustInvolved.Enabled = true;
            }
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtIncCompNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtIncCompNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.IncidentDetailGet(txtIncidentNo.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //txtAssignNo.Text = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
            txtIncidentType.Text = ds.Tables[0].Rows[0]["IncidentDesc"].ToString();
            //txtOccDate.Text = DateFormat(ds.Tables[0].Rows[0]["OccuranceDate"].ToString());
            //txtAssignNo_TextChanged(sender, e);
            ddlCustInvolved.Focus();
            //Added by  on 29-May-2013
            string clientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();
            SetClientId(clientCode);
            string asmtId = ds.Tables[0].Rows[0]["AsmtId"].ToString();
            SetAsmt(asmtId);
            ddlClientId.Enabled = false;
            ddlAsmtId.Enabled = false;
            ddlAsmtId_SelectedIndexChanged(sender, e);
            //End
        }
        else
        {
            lblError.Text = Resources.Resource.NoDataToShow;
            ClearFields("");
        }
        hideshowButton("");
        enabledisableField("");

    }

    /// <summary>
    /// Fills the asmt details.
    /// </summary>
    private void FillAsmtDetails()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AsmtIncidentDetailGet(ddlClientId.SelectedItem.Value,ddlAsmtId.SelectedItem.Value, BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                //EnableFields();
                //EnableButton();
                //txtCustomerID.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                //txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                //txtAddressID.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                //txtAddressDesc.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
                btnSave.Enabled = true;            //Added by  on 2-Jun-2013

                //Added Code for Upload Document by  on 25-Jun-2013
                btnUpload.Enabled = true;
            }
            else
            {
                // DisableFields();
                //ClearFields("");
                //DisableButtons();
                btnSave.Enabled = false;            //Added by  on 2-Jun-2013

                //Added Code for Upload Document by  on 25-Jun-2013
                btnUpload.Enabled = false;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            ClearFields("");
            hideshowButton("");
            enabledisableField("");
            btnSave.Enabled = false;            //Added by  on 2-Jun-2013

            //Added Code for Upload Document by  on 25-Jun-2013
            btnUpload.Enabled = false;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strStatus;
        DataSet ds = new DataSet();
        if (txtInvestigationNo.Text != "")
        {
            if (DateTime.Parse(txtInvDetDate.Text) >= DateTime.Parse(hfInvRequestDate.Value))
            {
                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                strStatus = getStatusFromResource(lblStatus.Text.ToString().Trim());
                //Modify Code for Upload Document by  on 25-Jun-2013
                ds = objOperationManagement.InvestigationRequestInsert(strStatus, DateTime.Parse(txtInvDetDate.Text), txtIncidentNo.Text.ToString(), int.Parse(ddlStaffInvolved.SelectedValue.ToString()), int.Parse(ddlCustInvolved.SelectedValue.ToString()), txtEmployeeID.Text.ToString(), txtDetails.Text.ToString(), BaseLocationAutoID, BaseUserID, dtUpload);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 0)
                {
                    txtInvestigationNo.Text = ds.Tables[0].Rows[0]["InvestigationNo"].ToString();
                    lblStatus.Text = Resources.Resource.Fresh.ToString();
                }
                ////btnAddNew.Visible = true;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
                lblErrorMsg.Text = " Investigation details date should always be greater than equal to the investigation request date";
            }
        }
        else
        {
            lblErrorMsg.Text = "Please Visit investigation Request screen first";
        }

    }
    /// <summary>
    /// Gets the status from resource.
    /// </summary>
    /// <param name="strStatus">The string status.</param>
    /// <returns>System.String.</returns>
    protected string getStatusFromResource(string strStatus)
    {
        if (strStatus == "" || strStatus == Resources.Resource.Fresh.ToString())
        {
            return "FRESH";
        }
        else if (lblStatus.Text.ToString().Trim() == Resources.Resource.Authorized.ToString())
        {
            return "AUTHORIZED";
        }
        else if (lblStatus.Text.ToString().Trim() == Resources.Resource.Amend.ToString())
        {
            return "AMEND";
        }
        return "0";
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        ClearFields("");
        hideshowButton("");
        enabledisableField("");
        //Added code for Upload Document by  on 25-Jun-2013
        FillgvEmployeeDocDownload();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtInvestigationNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtInvestigationNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.InvestigationDetailsGetAll(txtInvestigationNo.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtInvestigationNoShow.Text = ds.Tables[0].Rows[0]["InvRequestNo"].ToString();
            lblStatus.Text = ds.Tables[0].Rows[0]["DetStatus"].ToString();
            txtIncidentNo.Text = ds.Tables[0].Rows[0]["IncidentNo"].ToString();
            txtInvDetDate.Text = DateFormat(ds.Tables[0].Rows[0]["InvDetDate"].ToString());
            txtIncidentType.Text = ds.Tables[0].Rows[0]["IncidentDesc"].ToString();
            txtReasonForInv.Text = ds.Tables[0].Rows[0]["ReasonForInv"].ToString();
            txtDetails.Text = ds.Tables[0].Rows[0]["InvDetails"].ToString();
            if (ds.Tables[0].Rows[0]["InvPrepairedBy"].ToString() != "")
            {
                txtEmployeeID.Text = ds.Tables[0].Rows[0]["InvPrepairedBy"].ToString();
                txtEmployeeID_TextChanged1(sender, e);
            }
            ddlLegalAssistance.SelectedValue = ds.Tables[0].Rows[0]["LegalAssistance"].ToString();
            ddlCustInvolved.SelectedValue = ds.Tables[0].Rows[0]["CustInvolved"].ToString();
            ddlStaffInvolved.SelectedValue = ds.Tables[0].Rows[0]["G4SInvolved"].ToString();
            txtFindings.Text = ds.Tables[0].Rows[0]["InvFindings"].ToString();
            //txtAssignNo_TextChanged(sender, e);
            hideshowButton("");
            enabledisableField("");
            hfInvRequestDate.Value = ds.Tables[0].Rows[0]["InvRequestDate"].ToString();
            //Added by  on 29-May-2013
            string clientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();
            SetClientId(clientCode);
            string asmtId = ds.Tables[0].Rows[0]["AsmtId"].ToString();
            SetAsmt(asmtId);
            ddlClientId.Enabled = false;
            ddlAsmtId.Enabled = false;
            ddlAsmtId_SelectedIndexChanged(sender, e);
            //End

            //Added Code for Upload Document by  on 25-Jun-2013
            FillgvEmployeeDocDownload();
            //End
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            btnReset_Click(sender, e);
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
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (DateTime.Parse(txtInvDetDate.Text) >= DateTime.Parse(hfInvRequestDate.Value))
        {
            ds = objOperationManagement.InvestigationDetailUpdate(txtInvestigationNo.Text.ToString(), lblStatus.Text.ToString(), DateTime.Parse(txtInvDetDate.Text), int.Parse(ddlLegalAssistance.SelectedValue.ToString()), int.Parse(ddlStaffInvolved.SelectedValue.ToString()), int.Parse(ddlCustInvolved.SelectedValue.ToString()), txtEmployeeID.Text.ToString(), txtFindings.Text.ToString(), BaseLocationAutoID, BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else
        {
            lblErrorMsg.Text = " Investigation details date should always be greater than equal to the investigation request date";
        }
    }
    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (DateTime.Parse(txtInvDetDate.Text) >= DateTime.Parse(hfInvRequestDate.Value))
        {
            ds = objOperationManagement.InvestigationDetailsAuthorize(strStatusAuthorized, txtInvestigationNo.Text.ToString(), BaseLocationAutoID, BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "2")
            {
                lblStatus.Text = Resources.Resource.Authorized.ToString();
                hideshowButton("");
                enabledisableField("");
            }
            //Added for Upload Document by  on 25-Jun-2013
            if (lblStatus.Text == Resources.Resource.Authorized)
            {
                gvEmployeeDocument.Columns[4].Visible = false;
                btnUpload.Enabled = false;
            }
            //End
        }
        else
        {
            lblErrorMsg.Text = " Investigation details date should always be greater than equal to the investigation request date";
        }
    }
    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.InvestigationDetailAmend(strStatusAmend, txtInvestigationNo.Text.ToString(), BaseLocationAutoID, BaseUserID);
        //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "2")
        {
            lblStatus.Text = Resources.Resource.Amend.ToString();
            hideshowButton("");
            enabledisableField("");
        }
        //Added for Upload Document by  on 25-Jun-2013
        if (lblStatus.Text == Resources.Resource.Authorized)
        {
            gvEmployeeDocument.Columns[4].Visible = false;
            btnUpload.Enabled = false;
        }
        else
        {
            gvEmployeeDocument.Columns[4].Visible = true;
            btnUpload.Enabled = true;
        }
        //End
        //Added By  on 23-July-2013
        btnUpload.Enabled = true;
        //End
    }
    /// <summary>
    /// Handles the TextChanged1 event of the txtEmployeeID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeID_TextChanged1(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeID.Text, BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            txtEmpDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
            txtEmpDesignation.Text = "";
            //DisableButtons();
        }
        hideshowButton("");
        enabledisableField("");
    }

    #region Coded Added by 
    //Added by  on 31-May-2013
    /// <summary>
    /// Fills the client identifier.
    /// </summary>
    private void FillClientId()
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ClientDetail");
                dt.Columns.Add("ClientCode");
                dt.Rows.Add("Select", "Select");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["ClientDetail"], ds.Tables[0].Rows[cnt]["ClientCode"]);
                }
                ddlClientId.DataSource = dt;
                ddlClientId.DataTextField = "ClientDetail";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();

                ddlAsmtId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlClientId Item Selection get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtCustomerDesc.Text = ddlClientId.SelectedItem.Text;
        FillAsmt();
    }

    //Get Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Fills the asmt.
    /// </summary>
    private void FillAsmt()
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AsmtCode");
                dt.Columns.Add("AsmtDetail");
                dt.Rows.Add("Select", "Select");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["AsmtCode"], ds.Tables[0].Rows[cnt]["AsmtDetail"]);
                }
                ddlAsmtId.DataSource = dt;
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();

                ddlAsmtId.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlAsmtId Item Selection get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtDetails();
    }

    //Added by  on 29-May-2013
    //Set Client Code on based on txtIncidentNo
    /// <summary>
    /// Sets the client identifier.
    /// </summary>
    /// <param name="clientCode">The client code.</param>
    private void SetClientId(string clientCode)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientId.DataSource = ds;
                ddlClientId.DataTextField = "ClientDetail";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["ClientCode"].ToString() == clientCode)
                    {
                        ddlClientId.SelectedIndex = cnt;
                    }
                }
                ddlClientId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = Resources.Resource.NoDataToShow;
        }
    }

    //Set Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Sets the asmt.
    /// </summary>
    /// <param name="asmtId">The asmt identifier.</param>
    private void SetAsmt(string asmtId)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlAsmtId.DataSource = ds;
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["AsmtCode"].ToString() == asmtId)
                    {
                        ddlAsmtId.SelectedIndex = cnt;
                    }
                }
                ddlAsmtId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = Resources.Resource.NoDataToShow;
        }
    }
    #endregion

    #region Upload Document Code Added by  on 14-Jun-2013
    /// <summary>
    /// Creates the upload table.
    /// </summary>
    private void CreateUploadTable()
    {
        dtUpload.Clear();
        dtUpload.Columns.Clear();
        dtUpload.Columns.Add("RefNo");
        dtUpload.Columns.Add("EmployeeNumber");
        dtUpload.Columns.Add("FileName");
        dtUpload.Columns.Add("UploadDesc");
        dtUpload.Columns.Add("UploadDate");
        dtUpload.Columns.Add("ModifiedBy");
    }

    /// <summary>
    /// Fillgvs the employee document download.
    /// </summary>
    private void FillgvEmployeeDocDownload()
    {
        string strEmployeeNumber = txtEmployeeID.Text;

        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ds = objOPS.OPSDocumentDownload(txtInvestigationNo.Text, strEmployeeNumber);
        dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            gvEmployeeDocument.DataSource = dt;
            gvEmployeeDocument.DataBind();
            dvFileUploadGrid.Visible = true;
        }
        else
        {
            dvFileUploadGrid.Visible = false;
        }
        if (lblStatus.Text == Resources.Resource.Authorized)
        {
            gvEmployeeDocument.Columns[4].Visible = false;
            btnUpload.Enabled = false;
        }
        else
        {
            gvEmployeeDocument.Columns[4].Visible = true;
            btnUpload.Enabled = true;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEmployeeID.Text))
        {
            String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
            string strEmployeeNumber = txtEmployeeID.Text;
            string strRefNo = txtInvestigationNo.Text;
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet dsFileUpload = new DataSet();
            string DIRPath;
            string FileName;
            DIRPath = path;
            //Modify By  on 23-July-2013
            if (EmployeeDocUpload.HasFile && !string.IsNullOrEmpty(txtUploadDesc.Text))
            {
                FileName = strEmployeeNumber + '[' + '-' + ']' + EmployeeDocUpload.FileName;

                DIRPath = DIRPath + FileName;
                #region New Code for Check Duplicate by  on 26-July-2013
                //Added Code for check the duplicate record in Grid by  on 26-July-2013
                if (gvEmployeeDocument.Rows.Count > 0)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("FileName");
                    dtTemp.Columns.Add("Description");

                    foreach (GridViewRow row in gvEmployeeDocument.Rows)
                    {
                        DataRow drTemp = dtTemp.NewRow();

                        drTemp["FileName"] = ((LinkButton)(row.Cells[1].Controls[1])).Text;
                        drTemp["Description"] = ((Label)(row.Cells[2].Controls[1])).Text;
                        dtTemp.Rows.Add(drTemp);
                    }

                    for (int cnt = 0; cnt < dtTemp.Rows.Count; cnt++)
                    {
                        if (FileName.Trim() == dtTemp.Rows[cnt]["FileName"].ToString().Trim() && txtUploadDesc.Text.Trim() == dtTemp.Rows[cnt]["Description"].ToString().Trim())
                        {
                            lblError.Text = "Record already exists";
                            return;
                        }
                        else if (FileName.Trim() == dtTemp.Rows[cnt]["FileName"].ToString().Trim())
                        {
                            lblError.Text = "File Name already exists";
                            return;
                        }
                        if (txtUploadDesc.Text.Trim() == dtTemp.Rows[cnt]["Description"].ToString().Trim())
                        {
                            lblError.Text = "Upload File Description should not be same";
                            return;
                        }
                    }
                }
                //End
                #endregion
                DataRow dtUploadRow = dtUpload.NewRow();
                dtUploadRow[0] = strRefNo;
                dtUploadRow[1] = strEmployeeNumber;
                dtUploadRow[2] = FileName;
                dtUploadRow[3] = txtUploadDesc.Text;
                dtUploadRow[4] = DateTime.Now;
                dtUploadRow[5] = BaseUserID;
                dtUpload.Rows.Add(dtUploadRow);

                if (!string.IsNullOrEmpty(strRefNo))
                {
                    objOPS.OPSDocumentInsert(dtUpload, BaseUserID);
                    FillgvEmployeeDocDownload();
                    dtUpload.Clear();
                    txtUploadDesc.Text = "";
                    EmployeeDocUpload.PostedFile.SaveAs(DIRPath);
                }
                else
                {
                    if (dtUpload.Rows.Count > 0)
                    {
                        gvEmployeeDocument.DataSource = dtUpload;
                        gvEmployeeDocument.DataBind();
                        dvFileUploadGrid.Visible = true;
                        txtUploadDesc.Text = "";
                        EmployeeDocUpload.PostedFile.SaveAs(DIRPath);
                    }
                }
            }
            else
            {
                lblError.Text = "Please select a file and enter document description.";
            }
        }
        else
        {
            lblError.Text = "Employee Details should not be blank";
        }
    }
    /// <summary>
    /// Handles the Click event of the lbFileName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbFileName_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbFileName = (LinkButton)gvEmployeeDocument.Rows[row.RowIndex].FindControl("lbFileName");
        String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
        string FileName = path;
        FileName = FileName + lbFileName.Text;
        System.IO.FileInfo file = new System.IO.FileInfo(FileName);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvEmployeeDocument control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDocument_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow objGridViewRow = e.Row;
            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvEmployeeDocument.PageIndex * gvEmployeeDocument.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
            if (IsDeleteAccess == true)
            {
                if (IBDelete != null)
                {
                    IBDelete.Visible = true;
                    gvEmployeeDocument.Columns[3].Visible = true;
                }
            }
            else
            {
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                    gvEmployeeDocument.Columns[3].Visible = false;
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowDeleting event of the gvEmployeeDocument control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();

        string strEmployeeNumber = txtEmployeeID.Text;
        string strRefNo = txtInvestigationNo.Text;

        LinkButton lbFileName = (LinkButton)gvEmployeeDocument.Rows[e.RowIndex].FindControl("lbFileName");
        ImageButton IBDelete = (ImageButton)gvEmployeeDocument.Rows[e.RowIndex].FindControl("IBDelete");
        if (!string.IsNullOrEmpty(strRefNo))
        {
            ds = objOPS.OPSDocumentDelete(strRefNo, lbFileName.Text, strEmployeeNumber);

            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                DeleteFile(lbFileName.Text);
            }
            DisplayMessage(lblError, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else
        {
            if (dtUpload.Rows.Count > 0)
            {
                dtUpload.Rows.RemoveAt(e.RowIndex);
                gvEmployeeDocument.DataSource = dtUpload;
                gvEmployeeDocument.DataBind();
                if (dtUpload.Rows.Count < 1)
                {
                    dvFileUploadGrid.Visible = false;
                }
            }
        }
    }
    /// <summary>
    /// Deletes the file.
    /// </summary>
    /// <param name="strFileName">Name of the string file.</param>
    public void DeleteFile(string strFileName)
    {
        String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
        FileInfo TheFile = new FileInfo(path + strFileName);
        if (TheFile.Exists)
        {
            File.Delete(path + strFileName);
        }
        FillgvEmployeeDocDownload();
    }

    //Added Code for Resolve issue of Update Panel Exception on download file click by  on 2-Jun-2013
    /// <summary>
    /// Handles the PreRender event of the lbFileName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbFileName_PreRender(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            LinkButton MyButton = (LinkButton)sender;
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(MyButton);
        }
    }
    //End
    #endregion
}