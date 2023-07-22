// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="EventMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_EventMaster
/// </summary>
public partial class Masters_EventMaster : BasePage
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

    #region Page Functions
    /// <summary>
    /// The index
    /// </summary>
    static int Index;
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EventMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillddlModule();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Binding
    /// <summary>
    /// Fillddls the module.
    /// </summary>
    private void FillddlModule()
    {
        if (!IsPostBack)
        {
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();
            DataSet ds = new DataSet();
            ds = objMasterManagement.ModuleNameGet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlModule.DataSource = ds.Tables[0];
                ddlModule.DataValueField = "MenuHeadName";
                ddlModule.DataTextField = "MenuHeadName";
                ddlModule.DataBind();
            }
            else
            {
                ListItem li = new ListItem(Resources.Resource.NoDataToShow,"");
                ddlModule.Items.Add(li);
            }
            FillgvEventMaster();
        }
    }
    /// <summary>
    /// Fillgvs the event master.
    /// </summary>
    private void FillgvEventMaster()
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        ds = objMasterManagement.EventMasterGet(ddlModule.SelectedValue.ToString());
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvEventMaster.DataSource = ds.Tables[0];
                gvEventMaster.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                ds.Tables[0].Rows[0]["IsActive"] = false;
                gvEventMaster.DataSource = ds.Tables[0];
                gvEventMaster.DataBind();

                gvEventMaster.Rows[0].Visible = false;
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    #endregion

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlModule control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvEventMaster();
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvEventMaster.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

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
            TextBox txtEventDesc = (TextBox)e.Row.FindControl("txtEventDesc");
            if (txtEventDesc != null)
            {
                txtEventDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtEventDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
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
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvEventMaster.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtEventCode = (TextBox)e.Row.FindControl("txtEventCode");
                if (txtEventCode != null)
                {
                    txtEventCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtEventCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewEventDesc = (TextBox)e.Row.FindControl("txtNewEventDesc");
                if (txtNewEventDesc != null)
                {
                    txtNewEventDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewEventDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtEventCode = (TextBox)gvEventMaster.FooterRow.FindControl("txtEventCode");
        TextBox txtNewEventDesc = (TextBox)gvEventMaster.FooterRow.FindControl("txtNewEventDesc");
        CheckBox chkActive = (CheckBox)gvEventMaster.FooterRow.FindControl("chkIsActive");
        if (e.CommandName == "Add New")
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();

            if (ddlModule.SelectedItem.Value.ToString() != "" && txtEventCode.Text != "")
            {
                ds = objMasterManagement.EventMasterAdd(ddlModule.SelectedItem.Value.ToString(), txtEventCode.Text,
                                                           txtNewEventDesc.Text,
                                                           bool.Parse(chkActive.Checked.ToString()), BaseUserID);
                FillgvEventMaster();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
        }
        if (e.CommandName == "Reset")
        {
            txtEventCode.Text = "";
            txtNewEventDesc.Text = "";
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvEventMaster.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvEventMaster.PageIndex = gvEventMaster.PageCount;
                break;
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEventMaster.EditIndex = e.NewEditIndex;
        FillgvEventMaster();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEventMaster.EditIndex = -1;
        FillgvEventMaster();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtEventDescription = (TextBox)gvEventMaster.Rows[e.RowIndex].FindControl("txtEventDesc");
        CheckBox chkActive = (CheckBox)gvEventMaster.Rows[e.RowIndex].FindControl("chkIsActive");
        Label lblgvEventCode = (Label)gvEventMaster.Rows[e.RowIndex].FindControl("lblgvEventCode");

        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        if (ddlModule.SelectedItem.ToString() != "" && lblgvEventCode.Text != "")
        {
            ds = objMasterManagement.EventMasterUpdate(ddlModule.SelectedItem.ToString(), lblgvEventCode.Text,
                                                          txtEventDescription.Text, chkActive.Checked, BaseUserID);
            gvEventMaster.EditIndex = -1;
            FillgvEventMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label lblgvEventCode = (Label)gvEventMaster.Rows[e.RowIndex].FindControl("lblgvEventCode");
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        if (ddlModule.SelectedValue.ToString() != "" && lblgvEventCode.Text != "")
        {
            ds = objMasterManagement.EventDelete(ddlModule.SelectedValue.ToString(), lblgvEventCode.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                FillgvEventMaster();
            }
            FillgvEventMaster();
        }
    }

    /// <summary>
    /// Handles the DataBound event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvEventMaster.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvEventMaster.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvEventMaster.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvEventMaster.PageCount.ToString();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvEventMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEventMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvEventMaster.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvEventMaster.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvEventMaster.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvEventMaster.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvEventMaster.PageIndex = e.NewPageIndex;
        }
        gvEventMaster.EditIndex = -1;
        FillgvEventMaster();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvEventMaster.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvEventMaster.PageIndex = ddlPages.SelectedIndex;
        FillgvEventMaster();
    }    
    
}
