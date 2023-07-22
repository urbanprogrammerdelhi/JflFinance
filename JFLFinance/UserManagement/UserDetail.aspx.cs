// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="UserDetail.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_UserDetail
/// </summary>
public partial class Masters_UserDetail : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// The STR search user
    /// </summary>
    string strSearchUser; //this variable withh keep the value of the searched user text
 
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


    #region Function Related to Page Load
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
            //    lblPageHdrTitle.Text = Resources.Resource.UserDetail.ToString();
            //}
            //Code added by  on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.UserDetail + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillgvUserDetail();
                gvUserDetail.Columns[3].Visible = false;
                FillddlSearchBy();


            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
        btnSaveAll.Visible = false;
        btnBack.Visible = false;
    }
    #endregion

    #region Function To Fill GRidView
    /// <summary>
    /// Fillgvs the user detail.
    /// </summary>
    private void FillgvUserDetail()
    {

        BL.UserManagement objblUserManagement = new BL.UserManagement();
        DataSet ds = new DataSet();
        DataTable dtUserDetail = new DataTable();
        ds = objblUserManagement.ChildUserGetAll(BaseUserID, BaseIsAdmin, Resources.Resource.User, Resources.Resource.SuperUser, Resources.Resource.Administrator,BaseCompanyCode);
        dtUserDetail = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtUserDetail.Rows.Count > 0)
        {
            gvUserDetail.DataSource = dtUserDetail;
            gvUserDetail.DataBind();
        }
        else
        {
            dtUserDetail.Rows.Add(dtUserDetail.NewRow());
            dtUserDetail.Rows[0]["IsActive"] = "False";
            gvUserDetail.DataSource = dtUserDetail;
            gvUserDetail.DataBind();
            int TotalColumns = gvUserDetail.Rows[0].Cells.Count;
            gvUserDetail.Rows[0].Cells.Clear();
            gvUserDetail.Rows[0].Cells.Add(new TableCell());
            gvUserDetail.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvUserDetail.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }

    #endregion

    #region Fill GvDeleteUserDetail Grid view
    /// <summary>
    /// Fillgvs the delete user detail.
    /// </summary>
    /// <param name="strUserID">The STR user ID.</param>
    /// <returns>System.Int32.</returns>
    private int FillgvDeleteUserDetail(string strUserID)
    {
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        DataSet ds = new DataSet();
        DataTable dtUserDeleteDetail = new DataTable();
        ds = objblUserManagement.ChildUserGetAll(strUserID, "", Resources.Resource.User, Resources.Resource.SuperUser, Resources.Resource.Administrator,BaseCompanyCode);
        dtUserDeleteDetail = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtUserDeleteDetail.Rows.Count > 0)
        {
            gvDeleteUserDetail.DataSource = dtUserDeleteDetail;
            gvDeleteUserDetail.DataBind();
            return 1;
        }
        else
        {
            return 0;
        }


    }

    #endregion

    #region GridView UserDetail Events
    /// <summary>
    /// Handles the RowEditing event of the gvUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvUserDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvUserDetail.Columns[3].Visible = true;
        gvUserDetail.EditIndex = e.NewEditIndex;
        
        if (hfSearchText.Value.ToString() != "")
        {
            Show(Resources.Resource.AllowSearchedText);
        }
        if (hfSearchText.Value.ToString() == "")
        {
            FillgvUserDetail();
        }
        else
        {

            SearchAction();
        }
        
        btnBack.Visible = false;
        btnSaveAll.Visible = false;
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvUserDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        bool status = true;
        DataSet ds = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        gvUserDetail.Columns[3].Visible = false;
        //Label lblShowPassword = ((Label)gvUserDetail.Rows[e.RowIndex].FindControl("lblShowPassword")).Text;
        //lblShowPassword.Visible=false;
        TextBox txtUserID = (TextBox)gvUserDetail.Rows[e.RowIndex].FindControl("txtUserID");
        TextBox txtUserName = (TextBox)gvUserDetail.Rows[e.RowIndex].FindControl("txtUserName");
        DropDownList ddlUserType = (DropDownList)gvUserDetail.Rows[e.RowIndex].FindControl("ddlUserType");
        DropDownList ddlUserGroupName = (DropDownList)gvUserDetail.Rows[e.RowIndex].FindControl("ddlUserGroupName");
        DropDownList ddlIsActive = (DropDownList)gvUserDetail.Rows[e.RowIndex].FindControl("ddlIsActive");
        Label lblUserTypeDesc = (Label)gvUserDetail.Rows[e.RowIndex].FindControl("lblUserTypeDesc");
        DropDownList ddlTransferUserID = (DropDownList)gvUserDetail.Rows[e.RowIndex].FindControl("ddlTransferUserID");
        if (ddlUserType.SelectedValue != lblUserTypeDesc.Text)
        {
            ddlTransferUserID.Visible = true;
            if (lblUserTypeDesc.Text == "SU")
            {
                if (ddlUserType.SelectedValue == "A")
                {
                    status = false;
                    ds = objblUserManagement.UserProfileUpdate(txtUserID.Text, txtUserName.Text, ddlUserType.SelectedItem.Value.ToString(), ddlUserGroupName.SelectedValue.ToString(), Boolean.Parse(ddlIsActive.SelectedItem.Value.ToString()), ddlTransferUserID.SelectedItem.Value.ToString(), status);
                    gvUserDetail.EditIndex = -1;
                    FillgvUserDetail();
                    hfSearchText.Value = "";
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    btnBack.Visible = false;
                    btnSaveAll.Visible = false;

                }
                if (ddlUserType.SelectedValue == "U")
                {
                    status = false;
                    ds = objblUserManagement.UserProfileUpdate(txtUserID.Text, txtUserName.Text, ddlUserType.SelectedItem.Value.ToString(), ddlUserGroupName.SelectedValue.ToString(), Boolean.Parse(ddlIsActive.SelectedItem.Value.ToString()), ddlTransferUserID.SelectedItem.Value.ToString(), status);
                    gvUserDetail.EditIndex = -1;
                    FillgvUserDetail();
                    hfSearchText.Value = "";
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    btnBack.Visible = false;
                    btnSaveAll.Visible = false;
                }
            }
            if (lblUserTypeDesc.Text == "A")
            {
                if (ddlUserType.SelectedValue == "SU")
                {
                    status = true;
                    ds = objblUserManagement.UserProfileUpdate(txtUserID.Text, txtUserName.Text, ddlUserType.SelectedItem.Value.ToString(), ddlUserGroupName.SelectedValue.ToString(), Boolean.Parse(ddlIsActive.SelectedItem.Value.ToString()), BaseUserID, status);
                    gvUserDetail.EditIndex = -1;
                    FillgvUserDetail();
                    hfSearchText.Value = "";
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    btnBack.Visible = false;
                    btnSaveAll.Visible = false;
                }
                if (ddlUserType.SelectedValue == "U")
                {
                    status = false;
                    ds = objblUserManagement.UserProfileUpdate(txtUserID.Text, txtUserName.Text, ddlUserType.SelectedItem.Value.ToString(), ddlUserGroupName.SelectedValue.ToString(), Boolean.Parse(ddlIsActive.SelectedItem.Value.ToString()), ddlTransferUserID.SelectedItem.Value.ToString(), status);
                    gvUserDetail.EditIndex = -1;
                    FillgvUserDetail();
                    hfSearchText.Value = "";
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    btnBack.Visible = false;
                    btnSaveAll.Visible = false;
                }
            }
            if (lblUserTypeDesc.Text == "U")
            {
                if (ddlUserType.SelectedValue == "A" || ddlUserType.SelectedValue == "SU")
                {
                    status = true;
                    ddlTransferUserID.Visible = false;
                    ds = objblUserManagement.UserProfileUpdate(txtUserID.Text, txtUserName.Text, ddlUserType.SelectedItem.Value.ToString(), ddlUserGroupName.SelectedValue.ToString(), Boolean.Parse(ddlIsActive.SelectedItem.Value.ToString()), BaseUserID, status);
                    gvUserDetail.EditIndex = -1;
                    FillgvUserDetail();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    btnBack.Visible = false;
                    btnSaveAll.Visible = false;
                }
            }
        }
        else
        {
            status = true;
            ddlTransferUserID.Visible = false;
            ds = objblUserManagement.UserProfileUpdate(txtUserID.Text, txtUserName.Text, ddlUserType.SelectedItem.Value.ToString(), ddlUserGroupName.SelectedValue.ToString(), Boolean.Parse(ddlIsActive.SelectedItem.Value.ToString()), BaseUserID, status);
            gvUserDetail.EditIndex = -1;
            FillgvUserDetail();
            hfSearchText.Value = "";
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            btnBack.Visible = false;
            btnSaveAll.Visible = false;
        }

        txtSearch.Text = "";
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvUserDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvUserDetail.Columns[3].Visible = false;
        gvUserDetail.EditIndex = -1;
        if (hfSearchText.Value.ToString() == "")
        {
            FillgvUserDetail();
        }
        else
        {

            SearchAction();
        }
        btnBack.Visible = false;
        btnSaveAll.Visible = false;
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvUserDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DataSet ds = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        LinkButton lbUserID = (LinkButton)gvUserDetail.Rows[e.RowIndex].FindControl("lbUserID");
        Label lblUserType = (Label)gvUserDetail.Rows[e.RowIndex].FindControl("lblUserType");
        if (lbUserID != null)
        {
            hfUserID.Value = lbUserID.Text;
            hfUserType.Value = lblUserType.Text;
        }
        int rowCount = FillgvDeleteUserDetail(gvUserDetail.DataKeys[e.RowIndex].Value.ToString());
        if (rowCount == 0)
        {
            ds = objblUserManagement.UserDelete(gvUserDetail.DataKeys[e.RowIndex].Value.ToString());
            FillgvUserDetail();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            MultiViewUserDetail.Visible = true;
            btnBack.Visible = false;
            btnSaveAll.Visible = false;

        }
        else
        {
            MultiViewUserDetail.Visible = false;
            MultiViewDeleteUser.SetActiveView(ViewDeleteUser);
            MultiViewDeleteUser.Visible = true;
            btnBack.Visible = true;
            btnSaveAll.Visible = true;
        }

    }
    /// <summary>
    /// Handles the RowUpdated event of the gvUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdatedEventArgs"/> instance containing the event data.</param>
    protected void gvUserDetail_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvUserDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvUserDetail.PageIndex * gvUserDetail.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            DropDownList ddlUserType = (DropDownList)e.Row.FindControl("ddlUserType");
            DropDownList ddlUserGroupName = (DropDownList)e.Row.FindControl("ddlUserGroupName");
            Label lblUserTypeDesc = (Label)e.Row.FindControl("lblUserTypeDesc");
            Label lblUserGroupDesc = (Label)e.Row.FindControl("lblUserGroupDesc");
            if (ddlUserType != null && lblUserTypeDesc != null)
            {
                ddlUserType.DataSource = objUserManagement.ChildUserTypeGet(BaseUserID, Resources.Resource.User, Resources.Resource.SuperUser, Resources.Resource.Administrator);
                ddlUserType.DataTextField = "IsAdminDesc";
                ddlUserType.DataValueField = "IsAdmin";
                ddlUserType.SelectedValue = lblUserTypeDesc.Text;
                ddlUserType.DataBind();
            }
            if (ddlUserGroupName != null && lblUserGroupDesc != null)
            {
                BL.MastersManagement objMastersManagement = new BL.MastersManagement();
                DataSet dsUG = new DataSet();
                DataTable dtUG = new DataTable();
                dsUG = objMastersManagement.UserGroupGetAll(BaseUserID);
                ddlUserGroupName.DataSource = dsUG;
                ddlUserGroupName.DataTextField = "UserGroupName";
                ddlUserGroupName.DataValueField = "UserGroupCode";
                ddlUserGroupName.SelectedValue = lblUserGroupDesc.Text;
                ddlUserGroupName.DataBind();

                if (ddlUserType != null)
                {
                    if (ddlUserType.SelectedItem.Value != "A" && ddlUserType.SelectedItem.Value != "SU")
                    {
                        ListItem li = ddlUserGroupName.Items.FindByValue("A");
                        ddlUserGroupName.Items.Remove(li);
                        li = ddlUserGroupName.Items.FindByValue("SU");
                        ddlUserGroupName.Items.Remove(li);
                    }
                    else
                    {
                        ListItem li = new ListItem("Administrator","A");
                        ddlUserGroupName.Items.Add(li);
                        li = new ListItem("SuperUser", "SU");
                        ddlUserGroupName.Items.Add(li);
                    }

                    EnableddlUserGroup(ddlUserType, ddlUserGroupName);
                }
            }


            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvUserDetail.Columns[6].Visible = false;
            }
            if (IsModifyAccess == false)
            {
                ImageButton IBEditUserDetail = (ImageButton)e.Row.FindControl("IBEditUserDetail");
                if (IBEditUserDetail != null)
                {
                    IBEditUserDetail.Visible = false;
                }
            }
            else
            {

                ImageButton ImgbtnUpdateUserDetail = (ImageButton)e.Row.FindControl("ImgbtnUpdateUserDetail");
                if (ImgbtnUpdateUserDetail != null)
                {
                    ImgbtnUpdateUserDetail.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtUserName = (TextBox)e.Row.FindControl("txtUserName");
                if (txtUserName != null)
                {
                    txtUserName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtUserName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteUserDetail = (ImageButton)e.Row.FindControl("IBDeleteUserDetail");
                if (IBDeleteUserDetail != null)
                {
                    IBDeleteUserDetail.Visible = false;
                }

            }
            else
            {
                ImageButton IBDeleteUserDetail = (ImageButton)e.Row.FindControl("IBDeleteUserDetail");
                if (IBDeleteUserDetail != null)
                {
                    IBDeleteUserDetail.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

        }
        //btnBack.Visible = false;
        //btnSaveAll.Visible = false;

    }
    /// <summary>
    /// Handles the RowCommand event of the gvUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvUserDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gridViewRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        LinkButton lbUserID = (LinkButton)gridViewRow.FindControl("lbUserID");
        Label lblUserGroupCode = (Label)gridViewRow.FindControl("lblUserGroupCode");
        if (lbUserID != null && lblUserGroupCode != null)
        {
            if (e.CommandName == "LocationRight")
            {
                Response.Redirect("../UserManagement/UserLocationRights.aspx?UserID=" + lbUserID.Text + "&UGCode=" + lblUserGroupCode.Text);
            }
            if (e.CommandName == "SiteRight")
            {
                Response.Redirect("../UserManagement/DeviceUserSiteRights.aspx?UserID=" + lbUserID.Text + "&UGCode=" + lblUserGroupCode.Text);
            }
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvUserDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUserDetail.PageIndex = e.NewPageIndex;
        FillgvUserDetail();
        //btnBack.Visible = false;
        //btnSaveAll.Visible = false;

    }
    #endregion

    #region These Functions are Commented
    #region Show/Hide/ChangePassword Related Functions

    /// <summary>
    /// Handles the Click1 event of the lbShowPassword control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbShowPassword_Click1(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbShowPassword = (LinkButton)gvUserDetail.Rows[row.RowIndex].FindControl("lbShowPassword");
        Label lblShowPassword = (Label)gvUserDetail.Rows[row.RowIndex].FindControl("lblShowPassword");
        LinkButton lbHidePassword = (LinkButton)gvUserDetail.Rows[row.RowIndex].FindControl("lbHidePassword");
        string strkey = GetDecryptkey(BaseCountryCode);
        lblShowPassword.Text = objblUserManagement.DecryptPassword(lblShowPassword.Text, true, strkey);
        lblShowPassword.Visible = true;
        lbShowPassword.Visible = false;
        lbHidePassword.Visible = true;
    }
    /// <summary>
    /// Handles the Click event of the lbChangePassword control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbChangePassword_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        hfUserID.Value = gvUserDetail.DataKeys[row.RowIndex].Value.ToString();
        Response.Redirect("../UserManagement/ChangePasswordAdmin.aspx?strUserID=" + hfUserID.Value);
    }

    /// <summary>
    /// Handles the Click event of the lbChangeEmployee control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbChangeEmployee_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        hfUserID.Value = gvUserDetail.DataKeys[row.RowIndex].Value.ToString();
        Response.Redirect("../UserManagement/ChangeUserAreaIncharge.aspx?strUserID=" + hfUserID.Value);
    }

    /// <summary>
    /// Handles the Click event of the lbHidePassword control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbHidePassword_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbShowPassword = (LinkButton)gvUserDetail.Rows[row.RowIndex].FindControl("lbShowPassword");
        Label lblShowPassword = (Label)gvUserDetail.Rows[row.RowIndex].FindControl("lblShowPassword");
        LinkButton lbHidePassword = (LinkButton)gvUserDetail.Rows[row.RowIndex].FindControl("lbHidePassword");
        string strkey = GetDecryptkey(BaseCountryCode);
       
        // Label lblShowPassword = (Label)gvUserDetail.Rows[row.RowIndex].FindControl("lblShowPassword");
        lblShowPassword.Text = objblUserManagement.EncryptPassword(lblShowPassword.Text, true, strkey);
        lblShowPassword.Visible = false;
        lbShowPassword.Visible = true;
        lbHidePassword.Visible = false;
    }
    #endregion

    #region Method Related to MultiLanguage
    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    #endregion
    #endregion

    #region Function Related to userId Click in gridView
    /// <summary>
    /// Handles the Click event of the lbUserID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbUserID_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbUserID = (LinkButton)gvUserDetail.Rows[row.RowIndex].FindControl("lbUserID");
        Label lblUserGroupCode = (Label)gvUserDetail.Rows[row.RowIndex].FindControl("lblUserGroupCode");
        Response.Redirect("../UserManagement/UserLocationRights.aspx?UserID=" + lbUserID.Text + "&UGCode=" + lblUserGroupCode.Text);
    }
    #endregion

    #region Function In  MultiViewDeleteUser

    #region Gridview gvDeleteUserDetail
    /// <summary>
    /// Handles the RowDataBound event of the gvDeleteUserDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvDeleteUserDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvDeleteUserDetail.PageIndex * gvDeleteUserDetail.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            BL.UserManagement objBLUserManagement = new BL.UserManagement();
            DropDownList ddlUserID = (DropDownList)e.Row.FindControl("ddlUserID");
            if (ddlUserID != null)
            {
                ddlUserID.DataSource = objBLUserManagement.ChildUsersGet(BaseUserID, hfUserID.Value, hfUserType.Value);
                ddlUserID.DataTextField = "UserID";
                ddlUserID.DataValueField = "UserID";
                ddlUserID.DataBind();
            }
        }
    }
    #endregion

    #region Function related to Back Button Click
    /// <summary>
    /// Handles the Click event of the btnBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        MultiViewUserDetail.Visible = true;
        MultiViewDeleteUser.Visible = false;
    }
    #endregion

    #region Function related to Save button Click
    /// <summary>
    /// Handles the Click1 event of the btnSaveAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSaveAll_Click1(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUsermanagement = new BL.UserManagement();
        Hashtable objHashTable = new Hashtable();
        foreach (GridViewRow row in gvDeleteUserDetail.Rows)
        {
            DropDownList ddlUserID = (DropDownList)gvDeleteUserDetail.Rows[row.RowIndex].FindControl("ddlUserID");
            objHashTable[gvDeleteUserDetail.DataKeys[row.RowIndex].Value.ToString()] = ddlUserID.SelectedValue.ToString();
        }
        ds = objUsermanagement.ChildUserUpdate(objHashTable);
        bool value = GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
        if (value)
        {
            ds = objUsermanagement.UserDelete(hfUserID.Value);
        }
        FillgvUserDetail();
        MultiViewUserDetail.Visible = true;
        MultiViewDeleteUser.Visible = false;
    }
    #endregion
    #endregion

    #region Function Related to ddlUserType_SelectedIndexChanged
    /// <summary>
    /// Enableddls the user group.
    /// </summary>
    /// <param name="ddlUserType">Type of the DDL user.</param>
    /// <param name="ddlUserGroupName">Name of the DDL user group.</param>
    private void EnableddlUserGroup(DropDownList ddlUserType, DropDownList ddlUserGroupName)
    {
        if (ddlUserType.SelectedItem.Value.ToString() == "A")
        {
            ddlUserGroupName.SelectedValue = "A";
            ddlUserGroupName.Enabled = false;

        }
        else if (ddlUserType.SelectedItem.Value.ToString() == "SU")
        {
            ddlUserGroupName.SelectedValue = "SU";
            ddlUserGroupName.Enabled = false;
        }
        else
        {
            ddlUserGroupName.Enabled = true;
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlUserType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        BL.UserManagement objUserManagement = new BL.UserManagement();
        GridViewRow row = (GridViewRow)((sender) as Control).NamingContainer;
        DropDownList ddlUserType = ((sender) as DropDownList);
        string ddlUserTypeSelectedValue = ddlUserType.SelectedValue.ToString();
        Label lblUserTypeDesc = row.FindControl("lblUserTypeDesc") as Label;
        TextBox txtUserID = row.FindControl("txtUserID") as TextBox;
        DropDownList ddlTransferUserID = row.FindControl("ddlTransferUserID") as DropDownList;
        DropDownList ddlUserGroupName = row.FindControl("ddlUserGroupName") as DropDownList;

        //  lblErrorMsg.Text = txtUserID.Text;
        if (ddlUserTypeSelectedValue != lblUserTypeDesc.Text)
        {
            ddlTransferUserID.Visible = true;
            if (lblUserTypeDesc.Text == "SU")
            {
                if (ddlUserTypeSelectedValue == "A")
                {
                    ddlTransferUserID.DataSource = objUserManagement.ChildUserGetAll(txtUserID.Text, lblUserTypeDesc.Text);
                    ddlTransferUserID.DataTextField = "UserID";
                    ddlTransferUserID.DataValueField = "UserID";
                    ddlTransferUserID.DataBind();
                }
                if (ddlUserTypeSelectedValue == "U")
                {
                    ddlTransferUserID.DataSource = objUserManagement.ChildUserGetAll(txtUserID.Text, lblUserTypeDesc.Text);
                    ddlTransferUserID.DataTextField = "UserID";
                    ddlTransferUserID.DataValueField = "UserID";
                    ddlTransferUserID.DataBind();
                }
            }
            if (lblUserTypeDesc.Text == "A")
            {
                if (ddlUserTypeSelectedValue == "SU")
                {
                    ddlTransferUserID.Visible = false;
                }
                if (ddlUserTypeSelectedValue == "U")
                {
                    ddlTransferUserID.DataSource = objUserManagement.ChildUserGetAll(txtUserID.Text, lblUserTypeDesc.Text);
                    ddlTransferUserID.DataTextField = "UserID";
                    ddlTransferUserID.DataValueField = "UserID";
                    ddlTransferUserID.DataBind();
                }
            }
            if (lblUserTypeDesc.Text == "U")
            {
                if (ddlUserType.SelectedValue == "A" || ddlUserType.SelectedValue == "SU")
                {
                    ddlTransferUserID.Visible = false;
                }
            }
        }
        else
        {
            ddlTransferUserID.Visible = false;
        }

        //-----------------
        if (ddlUserGroupName != null)
        {
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DataSet dsUG = new DataSet();
            DataTable dtUG = new DataTable();
            dsUG = objMastersManagement.UserGroupGetAll(BaseUserID);
            ddlUserGroupName.DataSource = dsUG;
            ddlUserGroupName.DataTextField = "UserGroupName";
            ddlUserGroupName.DataValueField = "UserGroupCode";
            ddlUserGroupName.DataBind();

            if (ddlUserType != null)
            {
                if (ddlUserType.SelectedItem.Value != "A" && ddlUserType.SelectedItem.Value != "SU")
                {
                    ListItem li = ddlUserGroupName.Items.FindByValue("A");
                    ddlUserGroupName.Items.Remove(li);
                    li = ddlUserGroupName.Items.FindByValue("SU");
                    ddlUserGroupName.Items.Remove(li);
                }
                else
                {
                    ListItem li = new ListItem("Administrator", "A");
                    ddlUserGroupName.Items.Add(li);
                    li = new ListItem("SuperUser", "SU");
                    ddlUserGroupName.Items.Add(li);
                }

                EnableddlUserGroup(ddlUserType, ddlUserGroupName);
            }
        }
        //-----------------

        btnBack.Visible = false;
        btnSaveAll.Visible = false;
    }
    #endregion

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlUserGroupName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlUserGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Fills the user group.
    /// </summary>
    private void FillUserGroup()
    {


    }

    /// <summary>
    /// Get the  key vlaue from Encrypted file.
    /// </summary>
    /// <param name="strCountry">The STR country.</param>
    /// <returns>Key that we are using to Decrypt the string</returns>
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }

    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (txtSearch.Text != "")
        {
            btnViewAll.Visible = true;
        }

        if (txtSearch.Text != "")
        {

            hfSearchText.Value = txtSearch.Text.Trim();
            SearchAction();
        }
    }

    /// <summary>
    /// Function To Search In grid view LOI Received Based on ddlSearchBy and txtSearch Value
    /// </summary>
    private void SearchAction()
    {
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        DataSet ds = new DataSet();
        DataTable dtUserDetail = new DataTable();
        ds = objblUserManagement.ChildUserGetAll(BaseUserID, BaseIsAdmin, Resources.Resource.User, Resources.Resource.SuperUser, Resources.Resource.Administrator,BaseCompanyCode);
        dtUserDetail = ds.Tables[0];


        dtUserDetail.Columns["UserID"].ColumnName = Resources.Resource.UserID;
        dtUserDetail.Columns["UserName"].ColumnName = Resources.Resource.UserName;
       
        DataTable dt = new DataTable();
        DataView dv = new DataView(dtUserDetail);
       
        dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);
        
        dt = dv.ToTable();
        dt.Columns[Resources.Resource.UserID].ColumnName = "UserID";
        dt.Columns[Resources.Resource.UserName].ColumnName = "UserName";
      
        gvUserDetail.DataSource = dt;
        gvUserDetail.DataBind();
    }
    /// <summary>
    /// Handles the Click event of the btnViewAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        gvUserDetail.PageIndex = 0;
        FillgvUserDetail();

    }
    /// <summary>
    /// Fillddls the search by.
    /// </summary>
    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        arr.Add(gvUserDetail.Columns[1]);
        arr.Add(gvUserDetail.Columns[2]);

        //arr.Add(gvUserDetail.Columns[4]);
        //arr.Add(gvUserDetail.Columns[5]);

        //arr.Add(gvUserDetail.Columns[6]);
        //arr.Add(gvUserDetail.Columns[7]);


        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();

    }

}
