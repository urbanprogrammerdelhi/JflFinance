// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
//   Revision History:   
//   Revision        Name:              Date:           Description of Change: 
//   -----------   -----------          --------        ------------------------------- 
//   V1.0          AddAttributes()      22-Sep-2011     Added Code to check if the Address ID is to be generated Manually or Not
//   V1.0          blAutoGenerate_ClientCode            M
//   V1.0          blClientDetails_AddNewManually       Allows us to create new Address ID Manually
//   V1.0          FillAsmtIdDetail()                   Checks if the Asmt ID Type is Billable / Asmt ID and Shows the ID as Same      
//   V1.1          btnSaveAttend_Click                  To add Attendance Type with Address ID
// ***********************************************************************
// <copyright file="createAsmtId.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;



/// <summary>
/// Class Sales_CreateAssignmentId.
/// </summary>
public partial class Sales_CreateAssignmentId : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// The strbtnstatus ylm
    /// </summary>
    string strbtnstatusYlm;//keeps the status if Correct / Save button is called to use the insert procedure
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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

                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    #region Page function

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        GoogleMapForASPNet1.PushpinDrag += new UserControls_GoogleMapForASPNet.PushpinDragHandler(OnPushpinDrag);
        if (!IsPostBack)
        {
            //GoogleMapForASPNet1.GoogleMapObject.APIKey = System.Configuration.ConfigurationManager.AppSettings["GoogleAPIKey"];
            GoogleMapForASPNet1.GoogleMapObject.Width = "1050px";
            GoogleMapForASPNet1.GoogleMapObject.Height = "500px";
            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;

            if (IsReadAccess)
            {
                AddAttributes();
                var objMastersManagement = new BL.MastersManagement();

                using (DataSet ds = objMastersManagement.CountryMasterGetAll(BaseCompanyCode))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ddlCountryCode.DataSource = ds.Tables[0];
                        ddlCountryCode.DataValueField = "CountryCode";
                        ddlCountryCode.DataTextField = "Country";
                        ddlCountryCode.DataBind();
                    }

                    if (ddlCountryCode.Text == "")
                    {
                        var li = new ListItem(string.Format("{0}", Resources.Resource.NoDataToShow), "");
                        ddlCountryCode.Items.Add(li);
                        DisableButtons();
                    }
                }

                using (DataSet ds = objMastersManagement.PremisesTypeGet(BaseCompanyCode))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ddlPremisesType.DataSource = ds.Tables[0];
                        ddlPremisesType.DataValueField = "ItemDesc";
                        ddlPremisesType.DataTextField = "ItemDesc";
                        ddlPremisesType.DataBind();
                    }
                    //ListItem li = new ListItem();
                    var li = new ListItem(Resources.Resource.NotKnown, Resources.Resource.NotKnown);
                    ddlPremisesType.Items.Insert(0, li);
                }

                FillddlGroupZip();

                var objOperationManagement = new BL.OperationManagement();
                using (DataSet ds = objOperationManagement.AreaIdGet(BaseLocationAutoID, "0"))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {

                        ddlAreaId.DataSource = ds.Tables[0];
                        ddlAreaId.DataValueField = "AreaID";
                        ddlAreaId.DataTextField = "AreaDesc";
                        ddlAreaId.DataBind();

                        var objSales = new BL.Sales();
                        using (DataSet ds1 = objSales.AreaInchargeGet(BaseLocationAutoID, ddlAreaId.SelectedValue))
                        {
                            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                            {
                                txtAreaIncharge.Text = ds1.Tables[0].Rows[0][0].ToString();
                            }
                        }
                    }
                    if (ddlAreaId.Text == "")
                    {
                        var li = new ListItem(string.Format("{0}", Resources.Resource.NoDataToShow), "");
                        ddlAreaId.Items.Add(li);
                        DisableButtons();
                    }
                }
                txtFromDate.Attributes.Add("readonly", "readonly");

                if (Request.QueryString["ClientCode"] != null)
                //if (ClientCode != null)
                {
                    var objSales = new BL.Sales();
                    //DataSet ds = new DataSet();
                    using (DataSet ds = objSales.ClientNameGet(Request.QueryString["ClientCode"]))
                    {
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            lblClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                            lblManualClientCode.Text = ds.Tables[0].Rows[0]["ManualClientCode"].ToString();
                            lblClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                        }
                    }
                }
                // Fill Detail of selected assignment Id if page is called for editing
                if (Request.QueryString["AsmtId"] != null && Request.QueryString["AsmtId"].Length != 0)
                {
                    ddlIdType.Enabled = false;
                    IMGFromDate.Enabled = false;
                    //if (Request.QueryString["AsmtId"].Substring(0, 1) == "A")
                    //{
                    //    ddlIdType.SelectedValue = "A";
                    //}
                    //else
                    //{
                    //    ddlIdType.SelectedValue = "B";
                    //}
                    ddlIdType.SelectedValue = Request.QueryString["AsmtId"].Substring(0, 1) == @"A" ? @"A" : @"B";
                    FillAsmtIdDetail();

                    PanelContactInformation.Visible = true;
                    if (ddlIdType.SelectedItem.Value != @"BillingId")
                    {
                        PanelClientAttendanceDetails.Visible = true;

                        if (BaseCountryName != null && BaseCountryName.ToLower().IndexOf("israel") >= 0)
                        {
                            PanelClientYLMDetails.Visible = true;
                        }
                        else
                        {
                            PanelClientYLMDetails.Visible = false;
                        }
                    }
                    FillAsmtIdAttendTypeAmendNo();
                    FillAsmtIdAttendDetails();
                    txtAsmtIDYlm.Text = txtAsmtId.Text;
                    txtClientCodeYlm.Text = lblClientCode.Text;
                    txtClientNameYLM.Text = lblClientName.Text;
                    FillAsmtContactDetails();
                    FillYlmdetailsAmendDdl();
                    FillAsmtIdYlmDetails();
                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                    //btnResetAll.Visible = false;
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                    if (!IsModifyAccess)
                    {
                        btnSubmit.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                }
                else
                {
                    //////txtFromDate.Text = DateTime.Now.ToString(Resources.Resource.ScheduleDefaultDateFormat);
                    IMGFromDate.Enabled = true;
                    PanelContactInformation.Visible = false;
                    PanelClientAttendanceDetails.Visible = false;
                    PanelClientYLMDetails.Visible = false;
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                    btnResetAll.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    if (!IsWriteAccess)
                    {
                        btnSubmit.Enabled = false;
                        btnReset.Enabled = false;
                        btnResetAll.Visible = false;
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
    /// Handles the CheckedChanged event of the chkBreak control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void chkBreak_CheckedChanged(object sender, EventArgs e)
    {
        //if (chkBreak.Checked.ToString() == "True")
        //{
        //    txtBreak.Style.Add("display", "block");
        //}
        //else
        //{ txtBreak.Style.Add("display", "none"); }

        txtBreak.Style.Add("display", chkBreak.Checked ? "block" : "none");
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
            var l1 = new ListItem(Resources.Resource.NotKnown, string.Empty);
            ddlGroupZip.Items.Insert(0, l1);
        }
        FillddlZip();
    }
    /// <summary>
    /// Fillddls the zip.
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
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void ddlGroupZip_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlZip();
    }
    /// <summary>
    /// Fills the asmt contact details.
    /// </summary>
    protected void FillAsmtContactDetails()
    {
        var objSales = new BL.Sales();
        //DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        int dtflag = 1;
        DataSet ds = objSales.ClientContactInformationGetAll(BaseCompanyCode, lblClientCode.Text, txtAsmtId.Text);
        DataTable dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        GvContactInformation.DataKeyNames = new[] { "ContactUniqueNo" };
        GvContactInformation.DataSource = dt;
        GvContactInformation.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            GvContactInformation.Rows[0].Visible = false;
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the GvContactInformation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void GvContactInformation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objSales = new BL.Sales();
        //DataSet ds = new DataSet();
        // To Insert a New Row
        var txtNewContactName = (TextBox)GvContactInformation.FooterRow.FindControl("txtNewContactName");
        var txtNewContactDesignation = (TextBox)GvContactInformation.FooterRow.FindControl("txtNewContactDesignation");
        var txtNewContactDepartment = (TextBox)GvContactInformation.FooterRow.FindControl("txtNewContactDepartment");
        var txtNewContactNumber = (TextBox)GvContactInformation.FooterRow.FindControl("txtNewContactNumber");
        var txtNewEMailAddress = (TextBox)GvContactInformation.FooterRow.FindControl("txtNewEMailAddress");

        if (e.CommandName == "Add")
        {
            if (txtNewContactName.Text != @"")
            {
                DataSet ds = objSales.ClientContactInformationAdd(BaseCompanyCode, lblClientCode.Text, txtAsmtId.Text, txtNewContactName.Text, txtNewContactDesignation.Text, txtNewContactDepartment.Text, txtNewContactNumber.Text, txtNewEMailAddress.Text, BaseUserID);
                FillAsmtContactDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.ContactPerson + @" " + Resources.Resource.CannotBeLeftBlank;// "Cannot Save Blank Contact Name";
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewContactName.Text = "";
            txtNewContactDesignation.Text = "";
            txtNewContactDepartment.Text = "";
            txtNewContactNumber.Text = "";
            txtNewEMailAddress.Text = "";
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the GvContactInformation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void GvContactInformation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objSales = new BL.Sales();
        //DataSet ds = new DataSet();
        //DataSet ds = objSales.ClientContactInformationDelete(BaseCompanyCode, lblClientCode.Text.ToString(), txtAsmtId.Text.ToString(), GvContactInformation.DataKeys[e.RowIndex].Value.ToString());

        var dataKey = GvContactInformation.DataKeys[e.RowIndex];
        if (dataKey != null)
        {
            DataSet ds = objSales.ClientContactInformationDelete(BaseCompanyCode, lblClientCode.Text, txtAsmtId.Text, dataKey.Value.ToString());
            FillAsmtContactDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
        else
        {
            FillAsmtContactDetails();
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the GvContactInformation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void GvContactInformation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GvContactInformation.EditIndex = e.NewEditIndex;
        FillAsmtContactDetails();
    }

    /// <summary>
    /// Handles the RowUpdating event of the GvContactInformation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void GvContactInformation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objSales = new BL.Sales();
        // DataSet ds = new DataSet();

        var txtEditContactName = (TextBox)GvContactInformation.Rows[e.RowIndex].FindControl("txtEditContactName");
        var txtEditContactDesignation = (TextBox)GvContactInformation.Rows[e.RowIndex].FindControl("txtEditContactDesignation");
        var txtEditContactDepartment = (TextBox)GvContactInformation.Rows[e.RowIndex].FindControl("txtEditContactDepartment");
        var txtEditContactNumber = (TextBox)GvContactInformation.Rows[e.RowIndex].FindControl("txtEditContactNumber");
        var txtEditEMailAddress = (TextBox)GvContactInformation.Rows[e.RowIndex].FindControl("txtEditEMailAddress");
        var dataKey = GvContactInformation.DataKeys[e.RowIndex];

        if (dataKey != null)
        {

            DataSet ds = objSales.ClientContactInformationUpdate(BaseCompanyCode, lblClientCode.Text, txtAsmtId.Text, dataKey.Value.ToString(), txtEditContactName.Text, txtEditContactDesignation.Text, txtEditContactDepartment.Text, txtEditContactNumber.Text, txtEditEMailAddress.Text, BaseUserID);
            GvContactInformation.EditIndex = -1;
            FillAsmtContactDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
        else
        {
            FillAsmtContactDetails();
        }
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the GvContactInformation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void GvContactInformation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GvContactInformation.EditIndex = -1;
        FillAsmtContactDetails();
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the GvContactInformation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void GvContactInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvContactInformation.PageIndex = e.NewPageIndex;
        GvContactInformation.EditIndex = -1;
        FillAsmtContactDetails();
    }

    /// <summary>
    /// Handles the RowDataBound event of the GvContactInformation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void GvContactInformation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            GvContactInformation.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblSerialNo = (Label)e.Row.FindControl("lblSerial");
            if (lblSerialNo != null)
            {
                int serialNo = GvContactInformation.PageIndex * GvContactInformation.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                var imgBtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (imgBtnEdit != null)
                { imgBtnEdit.Visible = false; }
            }
            else
            {
                var imgBtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (imgBtnUpdate != null)
                {
                    imgBtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }

                var txtEditContactName = (TextBox)e.Row.FindControl("txtEditContactName");
                if (txtEditContactName != null)
                {
                    txtEditContactName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtEditContactName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                var txtEditContactDesignation = (TextBox)e.Row.FindControl("txtEditContactDesignation");
                if (txtEditContactDesignation != null)
                {
                    txtEditContactDesignation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtEditContactDesignation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                var txtEditContactDepartment = (TextBox)e.Row.FindControl("txtEditContactDepartment");
                if (txtEditContactDepartment != null)
                {
                    txtEditContactDepartment.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtEditContactDepartment.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                var txtEditContactNumber = (TextBox)e.Row.FindControl("txtEditContactNumber");
                if (txtEditContactNumber != null)
                {
                    txtEditContactNumber.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtEditContactNumber.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                //var txtEditEMailAddress = (TextBox)e.Row.FindControl("txtEditEMailAddress");
                //if (txtEditEMailAddress != null)
                //{
                //    txtEditEMailAddress.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //    txtEditEMailAddress.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //}


            }
            if (IsDeleteAccess == false)
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (imgbtnDelete != null)
                { imgbtnDelete.Visible = false; }
            }
            else
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (imgbtnDelete != null)
                { imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');"; }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                GvContactInformation.ShowFooter = false;
            }
            else
            {
                var imgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (imgbtnAdd != null)
                {

                    imgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }

                var txtNewContactName = (TextBox)e.Row.FindControl("txtNewContactName");
                if (txtNewContactName != null)
                {
                    txtNewContactName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewContactName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                var txtNewContactDesignation = (TextBox)e.Row.FindControl("txtNewContactDesignation");
                if (txtNewContactDesignation != null)
                {
                    txtNewContactDesignation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewContactDesignation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                var txtNewContactDepartment = (TextBox)e.Row.FindControl("txtNewContactDepartment");
                if (txtNewContactDepartment != null)
                {
                    txtNewContactDepartment.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewContactDepartment.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                var txtNewContactNumber = (TextBox)e.Row.FindControl("txtNewContactNumber");
                if (txtNewContactNumber != null)
                {
                    txtNewContactNumber.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewContactNumber.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                //var txtNewEMailAddress = (TextBox)e.Row.FindControl("txtNewEMailAddress");
                //if (txtNewEMailAddress != null)
                //{
                //    txtNewEMailAddress.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //    txtNewEMailAddress.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //}


            }
        }
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
        btnResetAll.Enabled = false;
    }
    /// <summary>
    /// Enables the buttons.
    /// </summary>
    private void AddAttributes()
    {
        /************V1.0************/
        var objSale = new BL.Sales();
        //DataTable dtSale = new DataTable();
        DataTable dtSale = objSale.SetAutoGenerateCodeForClient(BaseCompanyCode, @"AutoGenerateAddressID");
        if (dtSale.Rows.Count > 0)
        {
            if (dtSale.Rows[0]["ParamValue1"].ToString() == "0")
            {
                txtAsmtId.ReadOnly = false;
                txtAsmtId.Focus();
            }
            else
            {
                txtAsmtId.ReadOnly = true;
            }
        }
        /************V1.0************/

        btnSubmit.Attributes.Add("onclick", "javascript:Timerf('" + lblErrorMsg.ClientID + "')");
        btnUpdate.Attributes.Add("onclick", "javascript:Timerf('" + lblErrorMsg.ClientID + "')");

        txtAsmtId.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
        txtAsmtId.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");

        txtAsmtName.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtAsmtName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtJobNo.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtJobNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtAddress.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtCity.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtCity.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtState.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtState.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        //txtPin.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        //txtPin.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtPhone.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        txtPhone.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");

        txtFax.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        txtFax.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");

        //txtEmail.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionEmail + ");");
        //txtEmail.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionEmail + ");");

        txtClientContactPerson.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtClientContactPerson.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtClientContactPersonDesignation.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtClientContactPersonDesignation.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtClientContactPersonMobile.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        txtClientContactPersonMobile.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");

        txtComments.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtComments.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

    }
    #endregion

    #region Controles binding
    /// <summary>
    /// Fills the asmt unique identifier detail.
    /// </summary>
    protected void FillAsmtIdDetail()
    {
        GetAllRecordsNonEditable();//Manish 28-06-2012

        // DataSet ds = new DataSet();
        var objSale = new BL.Sales();
        DataSet ds = objSale.ClientDetailsGet(BaseLocationAutoID, Request.QueryString["ClientCode"], Request.QueryString["AsmtId"]);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //ds = objSale.blClientDetails_GetByCode(BaseLocationAutoID, ClientCode.ToString(), AsmtId.ToString());
            txtAsmtId.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
            txtAsmtName.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["AsmtName"].ToString();
            txtJobNo.Text = ds.Tables[0].Rows[0]["JobNo"].ToString();
            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
            txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            ddlGroupZip.SelectedValue = ds.Tables[0].Rows[0]["GroupZipCode"].ToString();
            FillddlZip();
            ddlZip.SelectedValue = ds.Tables[0].Rows[0]["Pin"].ToString();
            //txtPin.Text = ds.Tables[0].Rows[0]["Pin"].ToString();
            ddlCountryCode.SelectedValue = ds.Tables[0].Rows[0]["CountryCode"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtClientContactPerson.Text = ds.Tables[0].Rows[0]["ClientContactPerson"].ToString();
            txtClientContactPersonDesignation.Text = ds.Tables[0].Rows[0]["ClientContactPersonDesignation"].ToString();
            txtClientContactPersonMobile.Text = ds.Tables[0].Rows[0]["ClientContactPersonMobile"].ToString();
            txtComments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
            ddlPremisesType.SelectedValue = ds.Tables[0].Rows[0]["PremisesType"].ToString();
            ddlAreaId.SelectedValue = ds.Tables[0].Rows[0]["AreaID"].ToString();
            txtAreaIncharge.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtOtherLanguageADD1.Text = ds.Tables[0].Rows[0]["MultiLingualAsmtAddress"].ToString();
            HFOtherLanguageADD1.Value = ds.Tables[0].Rows[0]["MultiLingualAsmtAddress"].ToString();
            txtFromDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["FromDate"].ToString()).ToString(Resources.Resource.ScheduleDefaultDateFormat);
            if (ds.Tables[0].Rows[0]["ToDate"].ToString() != "")
            {
                txtToDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["ToDate"].ToString()).ToString(Resources.Resource.ScheduleDefaultDateFormat);
            }
            /**********V1.0**********/
            //if (bool.Parse(ds.Tables[0].Rows[0]["IsBillable"].ToString()) == bool.Parse("True"))
            //{
            //    ddlIdType.SelectedValue = @"B"; //ddlIdType.Items.FindByValue("B").Value;
            //}
            //else
            //{
            //    ddlIdType.SelectedValue = @"A"; //ddlIdType.Items.FindByValue("A").Value;
            //}

            ddlIdType.SelectedValue = bool.Parse(ds.Tables[0].Rows[0]["IsBillable"].ToString()) == bool.Parse("True")
                                          ? @"B"
                                          : @"A";

            // ------------------------Manish --------------------------------------------------
            //Commented for ClientMeeting By Manish on 22-Aug-2013
            //txtSchClntMeeting.Text = ds.Tables[0].Rows[0]["CUSTMEETINGNO"].ToString();
            txtSchSiteSupervision.Text = ds.Tables[0].Rows[0]["SITESUPERVISIONNO"].ToString();
            ddlFrequencySite.SelectedValue = ds.Tables[0].Rows[0]["SITESUPERVISIONUNIT"].ToString();
            //ddlFrequencySch.SelectedValue = ds.Tables[0].Rows[0]["CUSTMEETINGUNIT"].ToString();
            //  ------------------------------End------------------------------------------------------
        }
        /**********V1.0**********/
        //txtAsmtId.Enabled = false;
        //btnReset.Visible = false;
        //btnSubmit.Text = Resources.Resource.Apply;

    }
    #endregion

    #region Controles Events
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientDetailsList.aspx?ClientCode=" + lblClientCode.Text);
    }
    /// <summary>
    /// Handles the Click event of the btnList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnList_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientDetailsList.aspx?ClientCode=" + lblClientCode.Text);
    }
    /// <summary>
    /// Handles the Click event of the btnClientMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnClientMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientMaster.aspx?ClientCode=" + lblClientCode.Text);
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtAsmtId.Text = "";
        PanelContactInformation.Visible = false;
        //////txtFromDate.Text = DateTime.Now.ToString(Resources.Resource.ScheduleDefaultDateFormat);
        IMGFromDate.Enabled = true;
        //GvContactInformation.Visible = false;
    }
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        GetAllRecordsEditable();// Manish 28/06/2012
        if (btnSubmit.Text == Resources.Resource.Apply)
        {
            //DataSet ds = new DataSet();
            var objSale = new BL.Sales();
            if (ddlAreaId.SelectedItem.Value != "")
            {
                if ((ddlIdType.SelectedValue == @"A" && ddlAreaId.SelectedItem.Value != @"NotRequired") || (ddlIdType.SelectedValue == @"B"))
                {
                    if (txtAsmtId.ReadOnly)//Check if code is autogenerated or manual
                    {
                        DataSet ds = objSale.ClientDetailsInsert(BaseLocationAutoID, lblClientCode.Text, ddlIdType.SelectedItem.Value, ddlAreaId.SelectedItem.Value, txtAsmtName.Text, txtJobNo.Text, txtAddress.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value, txtPhone.Text, txtFax.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, ddlPremisesType.SelectedItem.Value, txtComments.Text, BaseUserID, txtOtherLanguageADD1.Text, txtFromDate.Text);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 0)
                            {
                                txtAsmtId.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                                Response.Redirect("CreateAsmtId.aspx?ClientCode=" + lblClientCode.Text + "&AsmtId=" + txtAsmtId.Text);
                            }
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                    }
                    else
                    {
                        if (txtAsmtId.Text.Trim() != string.Empty)
                        {
                            DataSet ds = objSale.ClientDetailsManuallyInsert(BaseLocationAutoID, lblClientCode.Text, ddlIdType.SelectedItem.Value, txtAsmtId.Text, ddlAreaId.SelectedItem.Value, txtAsmtName.Text, txtJobNo.Text, txtAddress.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value, txtPhone.Text, txtFax.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, ddlPremisesType.SelectedItem.Value, txtComments.Text, BaseUserID, txtOtherLanguageADD1.Text, txtFromDate.Text);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 0)
                                {
                                    txtAsmtId.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                                    Response.Redirect("CreateAsmtId.aspx?ClientCode=" + lblClientCode.Text + "&AsmtId=" + txtAsmtId.Text);
                                }
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                //if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 11)
                                //{
                                //    UpdateAssignmentAddress();
                                //    FillAsmtIdAttendDetails();
                                //    return;
                                //}
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.BlankAddressID;
                            txtAsmtId.Focus();
                        }
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.AreaID + " " + Resources.Resource.Required);
                }
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.AreaID + " " + Resources.Resource.Required);
            }
        }
        else
        {
            UpdateAssignmentAddress();
            Response.Redirect("CreateAsmtId.aspx?ClientCode=" + lblClientCode.Text + "&AsmtId=" + txtAsmtId.Text);
        }

        PanelContactInformation.Visible = true;
        if (ddlIdType.SelectedItem.Value != @"BillingId")
        {
            PanelClientAttendanceDetails.Visible = true;
        }
        txtAsmtIDYlm.Text = txtAsmtId.Text;
        txtClientCodeYlm.Text = lblClientCode.Text;
        txtClientNameYLM.Text = lblClientName.Text;
        txtSchSiteSupervision.Text = @"1";
        FillAsmtContactDetails();
        FillAsmtIdYlmDetails();

    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Manish 28-06-2012 Make filed Editable and non editable.



        UpdateAssignmentAddress();
    }
    /// <summary>
    /// Updates the assignment address.
    /// </summary>
    protected void UpdateAssignmentAddress()
    {

        //DataSet ds = new DataSet();
        var objSale = new BL.Sales();
        DataSet ds = objSale.ClientDetailsUpdate(BaseLocationAutoID, lblClientCode.Text, txtAsmtId.Text, ddlAreaId.SelectedItem.Value, txtAsmtName.Text, txtJobNo.Text, txtAddress.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value, txtPhone.Text, txtFax.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, ddlPremisesType.SelectedItem.Value, txtComments.Text, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

        }
    }
    /// <summary>
    /// Handles the Click event of the btnResetAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnResetAll_Click(object sender, EventArgs e)
    {
        txtAsmtId.Text = @"";
        txtAsmtName.Text = @"";
        txtJobNo.Text = @"";
        txtAddress.Text = @"";
        txtCity.Text = @"";
        txtState.Text = @"";
        //txtPin.Text = "";
        txtPhone.Text = @"";
        txtFax.Text = @"";
        txtEmail.Text = @"";
        txtClientContactPerson.Text = @"";
        txtClientContactPersonDesignation.Text = @"";
        txtClientContactPersonMobile.Text = @"";
        txtComments.Text = @"";
        //////txtFromDate.Text = DateTime.Now.ToString(Resources.Resource.ScheduleDefaultDateFormat);
        IMGFromDate.Enabled = true;

        //if (ddlIdType.SelectedItem.Value.ToString() == "A")
        //{
        //    ddlIdType.SelectedValue = "B";
        //}
        //else
        //{
        //    ddlIdType.SelectedValue = "A";    
        //}

        ddlIdType.Enabled = true;
        txtAsmtIDYlm.Text = "";
        //GvContactInformation.Visible = false;
        PanelContactInformation.Visible = false;
        PanelClientAttendanceDetails.Visible = false;
        PanelClientYLMDetails.Visible = false;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
        btnSubmit.Visible = true;
        btnReset.Visible = true;
    }
    /// <summary>
    /// Handles the Click event of the lbGetHOClientAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void lbGetHOClientAdd_Click(object sender, EventArgs e)
    {
        //    DataSet ds = new DataSet();
        var objSales = new BL.Sales();
        DataSet ds = objSales.ClientDetailGet(lblClientCode.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAsmtName.Text = ds.Tables[0].Rows[0]["ClientAddressLine1"] + @" " + ds.Tables[0].Rows[0]["ClientAddressLine2"] + @" " + ds.Tables[0].Rows[0]["ClientAddressLine3"];
            txtAddress.Text = ds.Tables[0].Rows[0]["ClientAddressLine1"] + @" " + ds.Tables[0].Rows[0]["ClientAddressLine2"] + @" " + ds.Tables[0].Rows[0]["ClientAddressLine3"];
            txtJobNo.Text = "";
            // txt.Text = ds.Tables[0].Rows[0]["ClientAddressLine2"].ToString();
            // txtAddressLine3.Text = ds.Tables[0].Rows[0]["ClientAddressLine3"].ToString();
            // txtWebSite.Text = ds.Tables[0].Rows[0]["WebSite"].ToString();
            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
            //Commented by  on 6-Jun-2013 for ddlGroupZip Issue
            //ddlGroupZip.SelectedValue = ds.Tables[0].Rows[0]["GroupZipCode"].ToString();

            FillddlZip();
            //Commented by  on 6-Jun-2013 for ddlZip Issue
            //ddlZip.SelectedValue = ds.Tables[0].Rows[0]["Pin"].ToString();

            //txtPin.Text = ds.Tables[0].Rows[0]["Pin"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            ddlCountryCode.SelectedValue = ds.Tables[0].Rows[0]["CountryCode"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
            txtClientContactPerson.Text = ds.Tables[0].Rows[0]["ClientContactPerson"].ToString();
            //   txtOurContactPersonEmpNo.Text = ds.Tables[0].Rows[0]["OurContactPersonEmpNo"].ToString();
            txtClientContactPersonDesignation.Text = ds.Tables[0].Rows[0]["ClientContactPersonDesignation"].ToString();
            // txtOurContactPerson.Text = ds.Tables[0].Rows[0]["OurContactPerson"].ToString();
            txtClientContactPersonMobile.Text = ds.Tables[0].Rows[0]["ClientContactpersonMobile"].ToString();
            //  txtOurContactPersonMobile.Text = ds.Tables[0].Rows[0]["OurContactPersonMobile"].ToString();
            txtComments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlIdType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAsmtId.Text = @"";
    }

    /// <summary>
    /// Handles the Click event of the btnSaveAttend control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnSaveAttend_Click(object sender, EventArgs e)
    {
        if (lblClientCode.Text != "")
        {
            var objSale = new BL.Sales();
            // DataTable dt = new DataTable();
            if (txtBreak.Text == "")
            {
                txtBreak.Text = @"0";
            }
            if (txtWEFAttendDate.Text == "")
            {
                txtWEFAttendDate.Text = DateFormat(DateTime.Now);
            }

            if (txtSchSiteSupervision.Text == "")
            {

                txtSchSiteSupervision.Text = @"1";
            }

            //Added 4 new filed in last update mstsaleclientDetail Tabale Manish 22-Jul-2013
            //Commented for ClientMeeting By Manish on 22-Aug-2013
            DataTable dt = objSale.AttendanceTypeInsert(BaseLocationAutoID, lblClientCode.Text, txtAsmtId.Text, ddlAttendanceType.SelectedItem.Value, BaseUserID, chkBreak.Checked.ToString(), txtBreak.Text, int.Parse(txtSchSiteSupervision.Text), ddlFrequencySite.SelectedItem.Value); //, int.Parse(txtSchClntMeeting.Text), ddlFrequencySch.SelectedItem.Value

            DisplayMessage(lblConstraintErrorMsg, dt.Rows.Count > 0 ? dt.Rows[0]["MessageID"].ToString() : @"5");

            //if (dt.Rows.Count > 0)
            //{
            //    DisplayMessage(lblConstraintErrorMsg, dt.Rows[0]["MessageID"].ToString());
            //}
            //else
            //{
            //    DisplayMessage(lblConstraintErrorMsg, @"5");
            //}
        }

        FillAsmtIdAttendDetails();
    }
    /// <summary>
    /// To Correct the YLM values
    /// </summary>
    /// <param name="sender">CorrectYlm</param>
    /// <param name="e">Click</param>
    protected void btnCorrectYlm_Click(object sender, EventArgs e)
    {
        strbtnstatusYlm = "Correct";
        btnSaveYlm_Click(null, null);
    }
    /// <summary>
    /// Inserts YLM Details against ASMTID
    /// </summary>
    /// <param name="sender">ButtonSaveYlm</param>
    /// <param name="e">Click</param>
    protected void btnSaveYlm_Click(object sender, EventArgs e)
    {
        if (strbtnstatusYlm == null || strbtnstatusYlm != "Correct")
        {
            strbtnstatusYlm = "Save";
        }

        var objInsert = new BL.Sales();
        
        if (txtWorkTime.Text == "")
        {
            txtWorkTime.Text = @"0.00";
        }
        if (txtSundayHrs.Text == "")
        {
            txtSundayHrs.Text = @"0.00";
        }
        if (txtMonHrs.Text == "")
        {
            txtMonHrs.Text = @"0.00";
        }
        if (txtTueHrs.Text == "")
        {
            txtTueHrs.Text = @"0.00";
        }
        if (txtWedHrs.Text == "")
        {
            txtWedHrs.Text = @"0.00";
        }
        if (txtThurHrs.Text == "")
        {
            txtThurHrs.Text = @"0.00";
        }
        if (txtFriHrs.Text == "")
        {
            txtFriHrs.Text = @"0.00";
        }
        if (txtSatHrs.Text == "")
        {
            txtSatHrs.Text = @"0.00";
        }
        if (txtSuperAlertType.Text == "")
        {
            txtSuperAlertType.Text = @"0";
        }
        if (txtSuperAlertTimeGap.Text == "")
        {
            txtSuperAlertTimeGap.Text = @"0";
        }
        if (txtOfficerAlertType.Text == "")
        {
            txtOfficerAlertType.Text = @"0";
        }
        if (txtOff2AlertGap.Text == "")
        {
            txtOff2AlertGap.Text = @"0";
        }
        if (txtRoundEnterCut.Text == "")
        {
            txtRoundEnterCut.Text = @"0";
        }
        if (txtRoundExitCut.Text == "")
        {
            txtRoundExitCut.Text = @"0";
        }
        if (txtNoOfInspection.Text == "")
        {
            txtNoOfInspection.Text = @"0";
        }

        bool status;
        string wefDate;
        if(txtEffectiveFromYlm.Text=="")
        {

            lblErrorYlm.Text = Resources.Resource.PleaseinputWithEffectiveFromDate;
            txtEffectiveFromYlm.Focus();
            return;
        }

        if (txtEffectiveToYlm.Text == "")
        {
            status = ConvertStringToDateFormat(txtEffectiveFromYlm, lblErrorYlm);
            wefDate = txtEffectiveFromYlm.Text;
            //DisplayMessage(lblErrorYlm, wefDate.ToString());
        }
        else
        {
            status = ConvertStringToDateFormat(txtEffectiveToYlm, lblErrorYlm);
            wefDate = txtEffectiveToYlm.Text;
            //DisplayMessage(lblErrorYlm, wefDate);
        }

        if (status.ToString() == "false")
        {
            lblErrorYlm.Text = Resources.Resource.Datenotincorrectformat;
            return;
        }
        if (txtEffectiveToYlm.Text != "")
        {
            if (DateTime.Parse(txtEffectiveFromYlm.Text) >= DateTime.Parse(txtEffectiveToYlm.Text))
            {
                lblErrorYlm.Text = Resources.Resource.PleaseinputWithEffectiveFromDate;
                return;
            }
        }

        if (strbtnstatusYlm == @"Save" && txtEffectiveToYlm.Text == "")
        {
            if (hdfEffectiveFromYlm.Value != "")
            {
                if (txtEffectiveFromYlm.Text == hdfEffectiveFromYlm.Value ||
                    DateTime.Parse(txtEffectiveFromYlm.Text) <= DateTime.Parse(hdfEffectiveFromYlm.Value))
                {
                    lblErrorYlm.Text = Resources.Resource.PleaseinputWithEffectiveFromDate;
                    txtEffectiveFromYlm.Focus();
                    return;
                }
            }

            if(DateTime.Parse(txtEffectiveFromYlm.Text) < DateTime.Parse(txtFromDate.Text))
            {

                lblErrorYlm.Text = Resources.Resource.PleaseinputWithEffectiveFromDate;
                txtEffectiveFromYlm.Focus();
                return;
            }
        }

        if (IsEmail(txtSuperEmail.Text).Equals(false) && txtSuperEmail.Text != "")
        {
            lblErrorYlm.Text = Resources.Resource.SuperEmail + @" " + Resources.Resource.NotInCorrectFormat;
            txtSuperEmail.Focus();
            return;
        }

        if (IsEmail(txtOfficer2Email.Text).Equals(false) && txtOfficer2Email.Text != "")
        {

            lblErrorYlm.Text = Resources.Resource.Off2Email + @" " + Resources.Resource.NotInCorrectFormat;
            txtOfficer2Email.Focus();
            return;
        }

        if (txtSuperSMS.Text.Length < 10 && txtSuperSMS.Text != "")
        {

            lblErrorYlm.Text = Resources.Resource.ValidPhoneNumber;
            txtSuperSMS.Focus();
            return;
        }

        if (txtOfficer2SMS.Text.Length < 10 && txtOfficer2SMS.Text != "")
        {

            lblErrorYlm.Text = Resources.Resource.ValidPhoneNumber;
            txtOfficer2SMS.Focus();
            return;
        }

        DataTable dt = objInsert.YlmDetailsInsert(txtAsmtIDYlm.Text, BaseLocationAutoID,
                                                  txtClientCodeYlm.Text,
                                                  int.Parse(ddlSuperAlertPriority.SelectedValue),
                                                  int.Parse(txtSuperAlertType.Text),
                                                  txtSuperSMS.Text, txtSuperEmail.Text,
                                                  int.Parse(txtSuperAlertTimeGap.Text),
                                                  int.Parse(ddlOfficerAlertPriority.SelectedValue),
                                                  int.Parse(txtOfficerAlertType.Text),
                                                  txtOfficer2SMS.Text, txtOfficer2Email.Text,
                                                  int.Parse(txtOff2AlertGap.Text),
                                                  float.Parse(txtWorkTime.Text),
                                                  bool.Parse(chkCrossSite.Checked.ToString()),
                                                  bool.Parse(chkBlockOverQty.Checked.ToString()),
                                                  bool.Parse(chkCutToTekenEnter.Checked.ToString()),
                                                  bool.Parse(chkCutToTekenExit.Checked.ToString()),
                                                  int.Parse(txtRoundEnterCut.Text),
                                                  int.Parse(txtRoundExitCut.Text),
                                                  bool.Parse(chkRoundEnter.Checked.ToString()),
                                                  bool.Parse(chkRoundExit.Checked.ToString()),
                                                  (txtSunday.Text == "" ? @"00:00" : txtSunday.Text),
                                                  (txtSunOut.Text == "" ? @"00:00" : txtSunOut.Text),
                                                  (txtMonday.Text == "" ? @"00:00" : txtMonday.Text),
                                                  (txtMonOut.Text == "" ? @"00:00" : txtMonOut.Text),
                                                  (txtTuesday.Text == "" ? @"00:00" : txtTuesday.Text),
                                                  (txtTueOut.Text == "" ? @"00:00" : txtTueOut.Text),
                                                  (txtWed.Text == "" ? @"00:00" : txtWed.Text),
                                                  (txtWedOut.Text == "" ? @"00:00" : txtWedOut.Text),
                                                  (txtThur.Text == "" ? @"00:00" : txtThur.Text),
                                                  (txtThuOut.Text == "" ? @"00:00" : txtThuOut.Text),
                                                  (txtFri.Text == "" ? @"00:00" : txtFri.Text),
                                                  (txtFriOut.Text == "" ? @"00:00" : txtFriOut.Text),
                                                  (txtSat.Text == "" ? @"00:00" : txtSat.Text),
                                                  (txtSatOut.Text == "" ? @"00:00" : txtSatOut.Text),
                                                  float.Parse(txtSundayHrs.Text),
                                                  float.Parse(txtMonHrs.Text),
                                                  float.Parse(txtTueHrs.Text),
                                                  float.Parse(txtWedHrs.Text),
                                                  float.Parse(txtThurHrs.Text),
                                                  float.Parse(txtFriHrs.Text),
                                                  float.Parse(txtSatHrs.Text),
                                                  bool.Parse(cbYoMan.Checked.ToString()),
                                                  bool.Parse(cbIsInspectorCode.Checked.ToString()),
                                                  bool.Parse(cbIsOneTimeContract.Checked.ToString()),
                                                  bool.Parse(cbIsReinforcementContract.Checked.ToString()),
                                                  txtNoOfInspection.Text,
                                                  wefDate,
                                                  ddlAmendYlm.SelectedValue,
                                                  strbtnstatusYlm
                                                  );
        if (dt.Rows.Count > 0)
        {
            DisplayMessage(lblErrorYlm, dt.Rows[0]["MessageID"].ToString());
        }
        FillYlmdetailsAmendDdl();
        FillAsmtIdYlmDetails();
    }
    /// <summary>
    /// Deletes YLM Details against ASMTID
    /// </summary>
    /// <param name="sender">YlmDelete</param>
    /// <param name="e">Click</param>
    protected void btnDeleteYlm_Click(object sender, EventArgs e)
    {
        var objInsert = new BL.Sales();
        // DataTable dt = new DataTable();
        DataTable dt = objInsert.YlmDetailsDelete(txtAsmtIDYlm.Text, BaseLocationAutoID, txtClientCodeYlm.Text);
        if (dt.Rows.Count > 0)
        {
            DisplayMessage(lblErrorYlm, dt.Rows[0]["MessageID"].ToString());
            FillAsmtIdYlmDetails();
            FillYlmdetailsAmendDdl();
            hdfEffectiveFromYlm.Value = "";
        }
        else
        {
            FillAsmtIdYlmDetails();
            FillYlmdetailsAmendDdl();
        }
    }
    #endregion


    #region Function Related to Multilingual Details
    /// <summary>
    /// Handles the Click event of the btnOk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtAsmtId.Text != "")
        {
            if (txtOtherLanguageADD1.Text != HFOtherLanguageADD1.Value)
            {
                //DataSet ds = new DataSet();
                var objSales = new BL.Sales();
                objSales.MultilingualAsmtDetailInsert(lblClientCode.Text, txtAsmtId.Text, txtOtherLanguageADD1.Text, BaseLocationAutoID, BaseUserID);
                HFOtherLanguageADD1.Value = txtOtherLanguageADD1.Text;
            }
        }
        MPAsmtDetail.Hide();
    }

    /// <summary>
    /// Handles the Click event of the btnMultilingualCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnMultilingualCancel_Click(object sender, EventArgs e)
    {
        FillMultilingualAssignmentDetails();
    }


    /// <summary>
    /// Handles the Click event of the btnMultilingual control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnMultilingual_Click(object sender, EventArgs e)
    {
        MPAsmtDetail.Show();
        FillMultilingualAssignmentDetails();
    }

    /// <summary>
    /// Fills the multilingual assignment details.
    /// </summary>
    private void FillMultilingualAssignmentDetails()
    {
        // DataSet ds = new DataSet();
        var objSales = new BL.Sales();
        if (txtAsmtId.Text != "")
        {
            DataSet ds = objSales.ClientDetailsGet(BaseLocationAutoID, lblClientCode.Text, txtAsmtId.Text);
            //if(ds.Tables[0].Rows.Count >0 )
            //{
            txtOtherLanguageADD1.Text = ds.Tables[0].Rows.Count > 0
                                            ? ds.Tables[0].Rows[0]["MultiLingualAsmtAddress"].ToString()
                                            : "";
            //}
            //else
            //{
            //    txtOtherLanguageADD1.Text="";
            //}


        }
    }
    #endregion

    /// <summary>
    /// Handles the index change event of ddlAreaId
    /// </summary>
    /// <param name="sender">ddlAreaId</param>
    /// <param name="e">Index Chnage</param>
    protected void ddlAreaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet ds = new DataSet();
        var objSales = new BL.Sales();
        DataSet ds = objSales.AreaInchargeGet(BaseLocationAutoID, ddlAreaId.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAreaIncharge.Text = ds.Tables[0].Rows[0][0].ToString();
        }
    }
    /// <summary>
    /// Handles the index change event of ddlAmendNo
    /// </summary>
    /// <param name="sender">ddlAmendNo</param>
    /// <param name="e">Index Change</param>
    protected void ddlAmendNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblErrorYlm.Text = "";
        FillAsmtIdAttendDetailsByAmendNo();
    }

    /// <summary>
    /// Handles the index change event for Amendment YLM details
    /// </summary>
    /// <param name="sender">ddlAmendYlm</param>
    /// <param name="e">IndexChange</param>
    protected void ddlAmendYlm_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillAsmtIdYlmDetails();
        btnDeleteYlm.Visible = ddlAmendYlm.Items.Count == 1;
        if (txtEffectiveToYlm.Text != "")
        {
            btnSaveYlm.Visible = false;
            btnCorrectYlm.Visible = false;
            imgBtnCalEfrom.Visible = true;
          //  imgBtnCal.Visible = false;
            btnDeleteYlm.Visible = false;
        }
        else
        {
            btnSaveYlm.Visible = true;
            btnCorrectYlm.Visible = true;
            

            if (txtEffectiveFromYlm.Text != "" && txtEffectiveToYlm.Text == "")
            {
                imgBtnCalEfrom.Visible = true;
               // imgBtnCal.Visible = true;
            }
            else
            {
                imgBtnCalEfrom.Visible = true;
                //imgBtnCal.Visible = false;
            }
        }
    }

    /// <summary>
    /// Fills Values on Frequency Change for Site
    /// </summary>
    /// <param name="sender">ddlFrequency</param>
    /// <param name="e">IndexChange</param>
    protected void ddlFrequencySite_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilltxtSchSiteSupervision();
    }


    /// <summary>
    /// Checks for YLM Emails to be in correct Mail format
    /// </summary>
    /// <param name="strEmail">The string email.</param>
    /// <returns>true/false</returns>
    public static bool IsEmail(string strEmail)
    {
        var rgxEmail = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        return rgxEmail.IsMatch(strEmail);
    }

    //control fileds are Editable or non editable.
    /// <summary>
    /// Gets all records non editable.
    /// </summary>
    private void GetAllRecordsNonEditable()
    {

        // DataSet ds = new DataSet();
        var objInterface = new BL.Interface();
        DataSet ds = objInterface.GetAllRecordsOnScreenNameAndTableName("Client Creation", "mstSaleClientDetails");

        var objInterfacePage = new InterfacePage();

        objInterfacePage.ControlsNonEditable(ds, Page);

    }

    /// <summary>
    /// Gets all records editable.
    /// </summary>
    private void GetAllRecordsEditable()
    {


        // DataSet ds = new DataSet();
        var objInterface = new BL.Interface();
        DataSet ds = objInterface.GetAllRecordsOnScreenNameAndTableName("Client Creation", "mstSaleClientDetails");
        var obj = new InterfacePage();
        obj.ControlsEditable(ds, Page);


    }

    /// <summary>
    /// Fills Site Schedule Text Value
    /// </summary>
    private void FilltxtSchSiteSupervision()
    {
        txtSchSiteSupervision.Enabled = false;
        if (ddlFrequencySite.SelectedItem.Value == @"PerDay")
        {

            txtSchSiteSupervision.Text = @"1";
        }
        else if (ddlFrequencySite.SelectedItem.Value == @"2PerDay")
        {
            txtSchSiteSupervision.Text = @"2";

        }
        else if (ddlFrequencySite.SelectedItem.Value == @"PerWeek")
        {
            txtSchSiteSupervision.Text = @"1";
        }
        else if (ddlFrequencySite.SelectedItem.Value == @"PerMonth")
        {
            txtSchSiteSupervision.Text = @"1";
        }
        else if (ddlFrequencySite.SelectedItem.Value == @"XPerMonth")
        {
            txtSchSiteSupervision.Text = @"1";
            txtSchSiteSupervision.Enabled = true;

            txtSchSiteSupervision.Focus();
        }
        else
        {
            txtSchSiteSupervision.Text = @"1";
        }
    }
    /// <summary>
    /// To Fill Attendance Type for Asmt ID With Amendments
    /// </summary>
    private void FillAsmtIdAttendTypeAmendNo()
    {

        var objSale = new BL.Sales();
        string clientCode = Request.QueryString["ClientCode"] == null && Request.QueryString["ClientCode"] == ""
            ? lblClientCode.Text
            : Request.QueryString["ClientCode"];

        string asmtIdAttendance = Request.QueryString["AsmtId"] == null && Request.QueryString["AsmtId"] == ""
            ? txtAsmtId.Text
            : Request.QueryString["AsmtId"];

        using (SqlDataReader drAttendenceTypeForAsmtId = objSale.AsmtIdAmendNoGet(BaseLocationAutoID, clientCode, asmtIdAttendance))
        {

            ddlAmendNo.DataSource = drAttendenceTypeForAsmtId;
            ddlAmendNo.DataTextField = "AmendNo";
            ddlAmendNo.DataValueField = "AmendNo";
            ddlAmendNo.DataBind();
        }
    }

    /// <summary>
    /// Fills the Attendance Type Details ASMT ID
    /// </summary>
    private void FillAsmtIdAttendDetails()
    {

        var objSale = new BL.Sales();

        string clientCode = Request.QueryString["ClientCode"] == null && Request.QueryString["ClientCode"] == ""
            ? lblClientCode.Text
            : Request.QueryString["ClientCode"];

        string asmtIdAttendance = Request.QueryString["AsmtId"] == null && Request.QueryString["AsmtId"] == ""
            ? txtAsmtId.Text
            : Request.QueryString["AsmtId"];

        using (SqlDataReader drAsmtIdAttendenceTypeDetails = objSale.AsmtAttendanceDetailsGet(BaseLocationAutoID, clientCode, asmtIdAttendance))
        {
            if (drAsmtIdAttendenceTypeDetails.HasRows)
            {
                FillAsmtIdAttendTypeAmendNo();
                drAsmtIdAttendenceTypeDetails.Read();
                ddlAttendanceType.SelectedValue = drAsmtIdAttendenceTypeDetails["AttendanceType"].ToString();
                ddlAmendNo.SelectedValue = drAsmtIdAttendenceTypeDetails["AmendNo"].ToString();
                txtWEFAttendDate.Text = DateFormat(drAsmtIdAttendenceTypeDetails["WEFDATE"].ToString());
                chkBreak.Checked = bool.Parse(drAsmtIdAttendenceTypeDetails["BreakHrsApp"].ToString());
                txtBreak.Text = drAsmtIdAttendenceTypeDetails["BreakHrs"].ToString();

                txtBreak.Style.Add("display", chkBreak.Checked ? "block" : "none");
                //if (chkBreak.Checked.ToString() == "True")
                //{
                //    txtBreak.Style.Add("display", "block");
                //}
                //else
                //{
                //    txtBreak.Style.Add("display", "none");
                //}
            }

        }

    }

    /// <summary>
    /// Fills the Details of Attendance Type AmendNo Wise for ASMTID
    /// </summary>
    private void FillAsmtIdAttendDetailsByAmendNo()
    {

        var objSale = new BL.Sales();

        using (SqlDataReader drAttendenceTypeDetails = objSale.AsmtAttendDetailsByAmendNoGet(BaseLocationAutoID, lblClientCode.Text, txtAsmtId.Text, int.Parse(ddlAmendNo.SelectedItem.Value)))
        {
            if (drAttendenceTypeDetails.FieldCount > 0)
            {
                drAttendenceTypeDetails.Read();
                ddlAttendanceType.SelectedValue = drAttendenceTypeDetails["AttendanceType"].ToString();
                txtWEFAttendDate.Text = DateFormat(drAttendenceTypeDetails["WEFDATE"].ToString());
                chkBreak.Checked = bool.Parse(drAttendenceTypeDetails["BreakHrsApp"].ToString());
                txtBreak.Text = drAttendenceTypeDetails["BreakHrs"].ToString();

                txtBreak.Style.Add("display", chkBreak.Checked ? "block" : "none");

                //if (chkBreak.Checked.ToString() == "True")
                //{
                //    txtBreak.Style.Add("display", "block");
                //}
                //else
                //{
                //    txtBreak.Style.Add("display", "none");
                //}

            }
        }

    }

    /// <summary>
    /// Fills the asmt idylm details.
    /// </summary>
    private void FillAsmtIdYlmDetails()
    {
        var objInsert = new BL.Sales();
        //The DataTaable Object needs to be created explicity for the reason dt is filled in if & else so (dt.Row.Count >0) shows error
        //var dt = new DataTable();

        //if (ddlAmendYlm.SelectedValue == "")
        //{

        var dt = ddlAmendYlm.SelectedValue == ""
                   ? (objInsert.YlmDetailsGetAll(txtAsmtIDYlm.Text, BaseLocationAutoID, txtClientCodeYlm.Text, @"0"))
                   : (objInsert.YlmDetailsGetAll(txtAsmtIDYlm.Text, BaseLocationAutoID, txtClientCodeYlm.Text,
                                                 ddlAmendYlm.SelectedValue));

        //else
        //{
        //    dt = objInsert.YlmDetailsGetAll(txtAsmtIDYlm.Text, BaseLocationAutoID, txtClientCodeYlm.Text, ddlAmendYlm.SelectedValue);
        //}

        if (dt.Rows.Count > 0)
        {
            ddlSuperAlertPriority.SelectedValue = dt.Rows[0]["SuperAlertPriority"].ToString();
            txtSuperAlertType.Text = dt.Rows[0]["SuperAlertType"].ToString();
            txtSuperAlertTimeGap.Text = dt.Rows[0]["SuperAlertTimeGap"].ToString();
            txtSuperSMS.Text = dt.Rows[0]["SuperSMS"].ToString();
            txtSuperEmail.Text = dt.Rows[0]["SuperEmail"].ToString();
            ddlOfficerAlertPriority.SelectedValue = dt.Rows[0]["OfficerAlertPriority"].ToString();
            txtOff2AlertGap.Text = dt.Rows[0]["Officer2AlertTimeGap"].ToString();
            txtOfficer2Email.Text = dt.Rows[0]["Officer2Email"].ToString();
            txtOfficer2SMS.Text = dt.Rows[0]["Officer2SMS"].ToString();
            txtOfficerAlertType.Text = dt.Rows[0]["OfficerAlertType"].ToString();
            txtWorkTime.Text = dt.Rows[0]["MinWorkTime"].ToString();
            chkCrossSite.Checked = bool.Parse(dt.Rows[0]["CrossSiteFixEnable"].ToString());
            chkBlockOverQty.Checked = bool.Parse(dt.Rows[0]["BlockOverQtyShifts"].ToString());
            chkCutToTekenEnter.Checked = bool.Parse(dt.Rows[0]["CutToTekenEnter"].ToString());
            chkCutToTekenExit.Checked = bool.Parse(dt.Rows[0]["CutToTekenExit"].ToString());
            txtRoundEnterCut.Text = dt.Rows[0]["RoundEnterCut"].ToString();
            txtRoundExitCut.Text = dt.Rows[0]["RoundExitCut"].ToString();
            chkRoundEnter.Checked = bool.Parse(dt.Rows[0]["RoundEnter"].ToString());
            chkRoundExit.Checked = bool.Parse(dt.Rows[0]["RoundExit"].ToString());
            txtSunday.Text = dt.Rows[0]["EnterSunday"].ToString();
            txtSunOut.Text = dt.Rows[0]["ExitSunday"].ToString();
            txtMonday.Text = dt.Rows[0]["EnterMonday"].ToString();
            txtMonOut.Text = dt.Rows[0]["ExitMonday"].ToString();
            txtTuesday.Text = dt.Rows[0]["EnterTuesday"].ToString();
            txtTueOut.Text = dt.Rows[0]["ExitTuesday"].ToString();
            txtWed.Text = dt.Rows[0]["EnterWed"].ToString();
            txtWedOut.Text = dt.Rows[0]["ExitWed"].ToString();
            txtThur.Text = dt.Rows[0]["EnterThru"].ToString();
            txtThuOut.Text = dt.Rows[0]["ExitThru"].ToString();
            txtFri.Text = dt.Rows[0]["EnterFri"].ToString();
            txtFriOut.Text = dt.Rows[0]["ExitFri"].ToString();
            txtSat.Text = dt.Rows[0]["EnterSat"].ToString();
            txtSatOut.Text = dt.Rows[0]["ExitSat"].ToString();
            txtSundayHrs.Text = dt.Rows[0]["DayHrSun"].ToString();
            txtMonHrs.Text = dt.Rows[0]["DayHrMon"].ToString();
            txtTueHrs.Text = dt.Rows[0]["DayHrTue"].ToString();
            txtWedHrs.Text = dt.Rows[0]["DayHrWed"].ToString();
            txtThurHrs.Text = dt.Rows[0]["DayHrThu"].ToString();
            txtFriHrs.Text = dt.Rows[0]["DayHrFri"].ToString();
            txtSatHrs.Text = dt.Rows[0]["DayHrSat"].ToString();
            cbYoMan.Checked = bool.Parse(dt.Rows[0]["YoMan"].ToString());
            cbIsInspectorCode.Checked = bool.Parse(dt.Rows[0]["IsInspectorCode"].ToString());
            cbIsOneTimeContract.Checked = bool.Parse(dt.Rows[0]["IsOneTimeContract"].ToString());
            cbIsReinforcementContract.Checked = bool.Parse(dt.Rows[0]["IsReinforcementContract"].ToString());
            txtNoOfInspection.Text = dt.Rows[0]["NoOfInspection"].ToString();
            txtEffectiveFromYlm.Text = DateTime.Parse(dt.Rows[0]["EffectiveFrom"].ToString()).ToString(Resources.Resource.ScheduleDefaultDateFormat);
            hdfEffectiveFromYlm.Value = txtEffectiveFromYlm.Text;
            txtEffectiveToYlm.Text = dt.Rows[0]["EffectiveTo"].ToString() != "" ?
                    DateTime.Parse(dt.Rows[0]["EffectiveTo"].ToString()).ToString(Resources.Resource.ScheduleDefaultDateFormat) :
                        "";

            btnCorrectYlm.Visible = true;
            btnSaveYlm.Text = Resources.Resource.Update;
        }
        else
        {

            ddlSuperAlertPriority.SelectedValue = "0";
            txtSuperAlertType.Text = "";
            txtSuperAlertTimeGap.Text = "";
            txtSuperSMS.Text = "";
            txtSuperEmail.Text = "";
            ddlOfficerAlertPriority.SelectedValue = @"0";
            txtOff2AlertGap.Text = "";
            txtOfficer2Email.Text = "";
            txtOfficer2SMS.Text = "";
            txtOfficerAlertType.Text = "";
            txtWorkTime.Text = "";
            chkCrossSite.Checked = false;
            chkBlockOverQty.Checked = false;
            chkCutToTekenEnter.Checked = false;
            chkCutToTekenExit.Checked = false;
            txtRoundEnterCut.Text = "";
            txtRoundExitCut.Text = "";
            chkRoundEnter.Checked = false;
            chkRoundExit.Checked = false;
            txtSunday.Text = "";
            txtSunOut.Text = "";
            txtMonday.Text = "";
            txtMonOut.Text = "";
            txtTuesday.Text = "";
            txtTueOut.Text = "";
            txtWed.Text = "";
            txtWedOut.Text = "";
            txtThur.Text = "";
            txtThuOut.Text = "";
            txtFri.Text = "";
            txtFriOut.Text = "";
            txtSat.Text = "";
            txtSatOut.Text = "";
            txtSundayHrs.Text = "";
            txtMonHrs.Text = "";
            txtTueHrs.Text = "";
            txtWedHrs.Text = "";
            txtThurHrs.Text = "";
            txtFriHrs.Text = "";
            txtSatHrs.Text = "";
            cbYoMan.Checked = false;
            cbIsInspectorCode.Checked = false;
            cbIsOneTimeContract.Checked = false;
            cbIsReinforcementContract.Checked = false;
            txtNoOfInspection.Text = @"0";
            btnCorrectYlm.Visible = false;
            btnSaveYlm.Text = Resources.Resource.Save;
         
        }
    }

    /// <summary>
    /// Fills the Dropdown for the amendment no for Isarel Details
    /// </summary>
    private void FillYlmdetailsAmendDdl()
    {
        var objInsert = new BL.Sales();
        // DataTable dt = new DataTable();
        DataTable dt = objInsert.YlmAmendNo(txtAsmtIDYlm.Text, BaseLocationAutoID, txtClientCodeYlm.Text);
        if (dt.Rows.Count > 0)
        {
            ddlAmendYlm.DataSource = dt;
            ddlAmendYlm.DataTextField = "AmendNo";
            ddlAmendYlm.DataValueField = "AmendNo";
            ddlAmendYlm.DataBind();
            imgBtnCal.Visible = false;
            imgBtnCalEfrom.Visible = true;
         
        }
        else
        {
            var li = new ListItem { Text = @"0", Value = @"0" };
            ddlAmendYlm.Items.Insert(0, li);
            imgBtnCalEfrom.Visible = true;
            imgBtnCal.Visible = false;
         
        }
        btnDeleteYlm.Visible = ddlAmendYlm.Items.Count == 1;
        lblErrorYlm.Text = "";
    }
    protected void btnGeocode_Click(object sender, EventArgs e)
    {
        txtAddressShow.Text = txtAddress.Text;
        SearchGeocode();
    }

    private void SearchGeocode()
    {
        GooglePoint GP = new GooglePoint();
        GP.Address = txtAddress.Text;
        //GeocodeAddress() function will geocode address and set Latitude and Longitude of GP(GooglePoint) to it's respected value.
        if (GP.GeocodeAddress())
        {
            //Once GP is geocoded, you can add it to google map.
            GP.InfoHTML = GP.Address;
            txtFormattedAddress.Text = GP.Address;
            txtLocation.Text = "lat=" + GP.Latitude.ToString() + ", lng=" + GP.Longitude.ToString();
            lblError.Text = "";


            GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14; //manish
            GP.Draggable = true;//manish
            //Set GP as center point.
            GoogleMapForASPNet1.GoogleMapObject.CenterPoint = GP;

            //Clear any existing
            GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
            //Add geocoded GP to GoogleMapObject
            GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
            GoogleMapForASPNet1.GoogleMapObject.RecenterMap = true;
            //Recenter map to GP.
        }
        else
        {
            txtFormattedAddress.Text = "Unable to geocode this address";
            txtLocation.Text = "";
            lblError.Text = "Unable to geocode this address.";
        }
    }
    void OnPushpinDrag(string pID)
    {
        txtFormattedAddress.Text = GoogleMapForASPNet1.GoogleMapObject.Points[pID].Address.ToString();
        txtLocation.Text = "lat=" + GoogleMapForASPNet1.GoogleMapObject.Points[pID].Latitude.ToString() + ", lng=" + GoogleMapForASPNet1.GoogleMapObject.Points[pID].Longitude.ToString();
    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        GetAllRecordsEditable();// Manish 28/06/2012
        if (btnSubmit.Text == Resources.Resource.Apply)
        {
            //DataSet ds = new DataSet();
            var objSale = new BL.Sales();
            if (ddlAreaId.SelectedItem.Value != "")
            {
                if ((ddlIdType.SelectedValue == @"A" && ddlAreaId.SelectedItem.Value != @"NotRequired") || (ddlIdType.SelectedValue == @"B"))
                {
                    if (txtAsmtId.ReadOnly)//Check if code is autogenerated or manual
                    {
                        DataSet ds = objSale.ClientDetailsInsert(BaseLocationAutoID, lblClientCode.Text, ddlIdType.SelectedItem.Value, ddlAreaId.SelectedItem.Value, txtAsmtName.Text, txtJobNo.Text, txtAddress.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value, txtPhone.Text, txtFax.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, ddlPremisesType.SelectedItem.Value, txtComments.Text, BaseUserID, txtOtherLanguageADD1.Text, txtFromDate.Text);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 0)
                            {
                                txtAsmtId.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                                Response.Redirect("CreateAsmtId.aspx?ClientCode=" + lblClientCode.Text + "&AsmtId=" + txtAsmtId.Text);
                            }
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                    }
                    else
                    {
                        if (txtAsmtId.Text.Trim() != string.Empty)
                        {
                            DataSet ds = objSale.ClientDetailsManuallyInsert(BaseLocationAutoID, lblClientCode.Text, ddlIdType.SelectedItem.Value, txtAsmtId.Text, ddlAreaId.SelectedItem.Value, txtAsmtName.Text, txtJobNo.Text, txtAddress.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value, txtPhone.Text, txtFax.Text, txtEmail.Text, txtClientContactPerson.Text, txtClientContactPersonDesignation.Text, txtClientContactPersonMobile.Text, ddlPremisesType.SelectedItem.Value, txtComments.Text, BaseUserID, txtOtherLanguageADD1.Text, txtFromDate.Text);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 0)
                                {
                                    txtAsmtId.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                                    Response.Redirect("CreateAsmtId.aspx?ClientCode=" + lblClientCode.Text + "&AsmtId=" + txtAsmtId.Text);
                                }
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                //if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 11)
                                //{
                                //    UpdateAssignmentAddress();
                                //    FillAsmtIdAttendDetails();
                                //    return;
                                //}
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.BlankAddressID;
                            txtAsmtId.Focus();
                        }
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.AreaID + " " + Resources.Resource.Required);
                }
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.AreaID + " " + Resources.Resource.Required);
            }
        }
        else
        {
            UpdateAssignmentAddress();
            Response.Redirect("CreateAsmtId.aspx?ClientCode=" + lblClientCode.Text + "&AsmtId=" + txtAsmtId.Text);
        }

        PanelContactInformation.Visible = true;
        if (ddlIdType.SelectedItem.Value != @"BillingId")
        {
            PanelClientAttendanceDetails.Visible = true;
        }
        txtAsmtIDYlm.Text = txtAsmtId.Text;
        txtClientCodeYlm.Text = lblClientCode.Text;
        txtClientNameYLM.Text = lblClientName.Text;
        txtSchSiteSupervision.Text = @"1";
        FillAsmtContactDetails();
        FillAsmtIdYlmDetails();
    }
}
