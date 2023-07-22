// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="LeaveTypeList.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Class HRManagement_LeaveTypeList
/// </summary>
public partial class HRManagement_LeaveTypeList : BasePage //System.Web.UI.Page
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
        if (!IsPostBack)
        {

            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.LeaveType + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                // btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

            }
            FillLeaveType();

        }
    }


    /// <summary>
    /// Handles the Click event of the btnLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnLeaveType_Click(object sender, EventArgs e)
    {
        Response.Redirect("LeaveType.aspx");
    }

    /// <summary>
    /// Fills the type of the leave.
    /// </summary>
    protected void FillLeaveType()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet dsLeaveType = objLeave.LeaveTypeGet(BaseCompanyCode);
        if (dsLeaveType != null && dsLeaveType.Tables.Count > 0 && dsLeaveType.Tables[0].Rows.Count > 0)
        {
            gvLeaveType.DataSource = dsLeaveType.Tables[0];
            gvLeaveType.DataBind();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow.ToString();
        }
    }


    /// <summary>
    /// Handles the RowCommand event of the gvLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("UpdateAssociatedLeave"))
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            BL.Leave objLeave = new BL.Leave();

            LinkButton LinkLeaveTypeCode = (LinkButton)gvLeaveType.Rows[row.RowIndex].FindControl("LinkLeaveTypeCode");
            DropDownList ddlAssiciatedLeavecode = (DropDownList)gvLeaveType.Rows[row.RowIndex].FindControl("ddlAssiciatedLeavecode");

            DataSet ds = objLeave.AssiciatedLeaveUpdate(ddlAssiciatedLeavecode.SelectedValue.ToString(), LinkLeaveTypeCode.Text, BaseCompanyCode.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        else if (e.CommandName.Equals("MoreDetail"))
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            LinkButton LinkLeaveTypeCode = (LinkButton)gvLeaveType.Rows[row.RowIndex].FindControl("LinkLeaveTypeCode");
            Response.Redirect("LeaveType.aspx?LeaveType=" + LinkLeaveTypeCode.Text);
        }

    }


    /// <summary>
    /// Handles the Click event of the LinkLeaveTypeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void LinkLeaveTypeCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton LinkLeaveTypeCode = (LinkButton)gvLeaveType.Rows[row.RowIndex].FindControl("LinkLeaveTypeCode");
        HdnLeaveTypeCode.Value = LinkLeaveTypeCode.Text;
        gridHeaderSubLeaveType.Text = LinkLeaveTypeCode.Text;
        FillSubLeaveType();
    }


    /// <summary>
    /// Handles the RowDataBound event of the gvLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            BL.Leave objLeave = new BL.Leave();
            DataSet dsLeaveType = objLeave.LeaveTypeGet(BaseCompanyCode);

            dsLeaveType.Tables[0].DefaultView.RowFilter = "Without_Entitlement_flag=1";
            HiddenField HdnAssociatedLeave = (HiddenField)e.Row.FindControl("HdnAssociatedLeave");
            DropDownList ddlAssiciatedLeavecode = (DropDownList)e.Row.FindControl("ddlAssiciatedLeavecode");
            ddlAssiciatedLeavecode.DataSource = dsLeaveType.Tables[0];
            ddlAssiciatedLeavecode.DataTextField = "Leave_Desc";
            ddlAssiciatedLeavecode.DataValueField = "Leave_Code";
            ddlAssiciatedLeavecode.DataBind();

            ListItem Li = new ListItem();
            Li.Text = "None";
            Li.Value = "";
            ddlAssiciatedLeavecode.Items.Insert(0, Li);

            ddlAssiciatedLeavecode.SelectedValue = HdnAssociatedLeave.Value;

        }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLeaveType.PageIndex = e.NewPageIndex;
        FillLeaveType();
    }

    /// <summary>
    /// Fills the type of the sub leave.
    /// </summary>
    protected void FillSubLeaveType()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = objLeave.SubLeaveTypeGet(HdnLeaveTypeCode.Value.ToString(), BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvSubLeaveType.DataSource = ds.Tables[0];
            gvSubLeaveType.DataBind();

        }
        else
        {
            DataTable dt = ds.Tables[0];
            dt.Rows.Add(dt.NewRow());
            gvSubLeaveType.DataSource = dt;
            gvSubLeaveType.DataBind();
            gvSubLeaveType.Rows[0].Visible = false;
        }


    }


    /// <summary>
    /// Handles the RowCommand event of the gvSubLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvSubLeaveType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        TextBox txtSubLeaveTypeCode = (TextBox)gvSubLeaveType.FooterRow.FindControl("txtSubLeaveTypeCode");
        TextBox txtSubLeaveTypeDesc = (TextBox)gvSubLeaveType.FooterRow.FindControl("txtSubLeaveTypeDesc");

        if (e.CommandName == "AddNew")
        {
            DataSet ds = objLeave.SubLeaveTypeInsert(BaseCompanyCode, HdnLeaveTypeCode.Value.ToString(), txtSubLeaveTypeCode.Text, txtSubLeaveTypeDesc.Text, BaseUserID);
            FillSubLeaveType();
        }

    }

    /// <summary>
    /// Handles the RowDeleting event of the gvSubLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvSubLeaveType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        Label lblSubLeaveTypeCode = (Label)gvSubLeaveType.Rows[e.RowIndex].FindControl("lblSubLeaveTypeCode");
        DataSet ds = objLeave.SubLeaveTypeDelete(lblSubLeaveTypeCode.Text);
        FillSubLeaveType();

    }

    /// <summary>
    /// Handles the RowEditing event of the gvSubLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvSubLeaveType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSubLeaveType.EditIndex = e.NewEditIndex;
        FillSubLeaveType();
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvSubLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvSubLeaveType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        Label lblSubLeaveTypeCode = (Label)gvSubLeaveType.Rows[e.RowIndex].FindControl("lblSubLeaveTypeCode");
        TextBox txtEditSubLeaveTypeDesc = (TextBox)gvSubLeaveType.Rows[e.RowIndex].FindControl("txtEditSubLeaveTypeDesc");

        DataSet ds = objLeave.SubLeaveTypeUpdate(BaseCompanyCode, HdnLeaveTypeCode.Value.ToString(), lblSubLeaveTypeCode.Text, txtEditSubLeaveTypeDesc.Text, BaseUserID);
        gvSubLeaveType.EditIndex = -1;
        FillSubLeaveType();

    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvSubLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvSubLeaveType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvSubLeaveType.EditIndex = -1;
        FillSubLeaveType();
    }


}