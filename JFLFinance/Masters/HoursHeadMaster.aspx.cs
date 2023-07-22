// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="HoursHeadMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Class Masters_HoursHeadMaster
/// </summary>
public partial class Masters_HoursHeadMaster : BasePage//System.Web.UI.Page
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
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.HoursHeadMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            FillHoursHeadGroup();
        }
    }

    /// <summary>
    /// Fills the hours head group.
    /// </summary>
    protected void FillHoursHeadGroup()
    {
        BL.BusinessRule objMst = new BL.BusinessRule();
        DataSet ds = new DataSet();
        ds = objMst.HoursHeadGroupGet();
        gvHrsHeadGroup.DataSource = ds.Tables[0];
        gvHrsHeadGroup.DataBind();
    }

    /// <summary>
    /// Handles the RowCommand event of the gvHrsHeadGroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHeadGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.BusinessRule objMastersManagement = new BL.BusinessRule();
        DataSet ds = new DataSet();
        // To Insert a New Row
        TextBox txtHrsHeadGroupCode = (TextBox)gvHrsHeadGroup.FooterRow.FindControl("txtNewHrsHeadGroupCode");
        TextBox txtHrsHeadGroupDesc = (TextBox)gvHrsHeadGroup.FooterRow.FindControl("txtNewHrsHeadGroupDesc");
        if (e.CommandName == "Add")
        {
            string str = txtHrsHeadGroupCode.Text.ToString().Substring(0, 1);
            if (txtHrsHeadGroupCode.Text.ToString().Substring(0, 1) != "-")
            {
                ds = objMastersManagement.HoursHeadGroupInsert(txtHrsHeadGroupCode.Text, txtHrsHeadGroupDesc.Text, BaseUserID.ToString());
                gvHrsHeadGroup.EditIndex = -1;
                FillHoursHeadGroup();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
            else
            {
                lblErrorMsg.Text = "Invaild Code";
            }
        }
        if (e.CommandName == "Reset")
        {
            txtHrsHeadGroupCode.Text = "";
            txtHrsHeadGroupDesc.Text = "";

        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvHrsHeadGroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHeadGroup_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvHrsHeadGroup.EditIndex = e.NewEditIndex;
        FillHoursHeadGroup();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvHrsHeadGroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHeadGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        BL.BusinessRule objMastersManagement = new BL.BusinessRule();
        DataSet ds = new DataSet();
        LinkButton LinkgvHrsHrsHeadGroupCode = (LinkButton)gvHrsHeadGroup.Rows[e.RowIndex].FindControl("LinkgvHrsHrsHeadGroupCode");
        TextBox txtHrsHeadGroupDesc = (TextBox)gvHrsHeadGroup.Rows[e.RowIndex].FindControl("txtHrsHeadGroupDesc");
        ds = objMastersManagement.HoursHeadGroupUpdate(LinkgvHrsHrsHeadGroupCode.Text, txtHrsHeadGroupDesc.Text, BaseUserID.ToString());
        gvHrsHeadGroup.EditIndex = -1;
        FillHoursHeadGroup();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvHrsHeadGroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHeadGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.BusinessRule objMastersManagement = new BL.BusinessRule();
        DataSet ds = new DataSet();
        LinkButton LinkgvHrsHrsHeadGroupCode = (LinkButton)gvHrsHeadGroup.Rows[e.RowIndex].FindControl("LinkgvHrsHrsHeadGroupCode");
        ds = objMastersManagement.HoursHeadGroupDelete(LinkgvHrsHrsHeadGroupCode.Text);
        FillHoursHeadGroup();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvHrsHeadGroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHeadGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvHrsHeadGroup.EditIndex = -1;
        FillHoursHeadGroup();
    }
    /// <summary>
    /// Handles the RowUpdated event of the gvHrsHeadGroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdatedEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHeadGroup_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }

    /// <summary>
    /// Handles the Click event of the LinkgvHrsHrsHeadGroupCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void LinkgvHrsHrsHeadGroupCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton LinkgvHrsHrsHeadGroupCode = (LinkButton)gvHrsHeadGroup.Rows[row.RowIndex].FindControl("LinkgvHrsHrsHeadGroupCode");
        HdnHrsHeadGroupCode.Value = LinkgvHrsHrsHeadGroupCode.Text;
        FillHoursHead();
    }


    /// <summary>
    /// Fills the hours head.
    /// </summary>
    protected void FillHoursHead()
    {

        BL.BusinessRule objMst = new BL.BusinessRule();
        DataSet ds = new DataSet();
        ds = objMst.BusinessHoursHeadGet(HdnHrsHeadGroupCode.Value);
        gvHrsHead.DataSource = ds.Tables[0];
        gvHrsHead.DataBind();
    }

    /// <summary>
    /// Handles the RowCommand event of the gvHrsHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.BusinessRule objMastersManagement = new BL.BusinessRule();
        DataSet ds = new DataSet();
        // To Insert a New Row
        TextBox TxtNewHrsHeadCode = (TextBox)gvHrsHead.FooterRow.FindControl("TxtNewHrsHeadCode");
        TextBox TxtNewHrsHeadDesc = (TextBox)gvHrsHead.FooterRow.FindControl("TxtNewHrsHeadDesc");
        if (e.CommandName == "Add")
        {
            if (TxtNewHrsHeadCode.Text.ToString().Substring(0, 1) != "-")
            {
                //ds = objMastersManagement.blBusiness_HoursHead_Insert(TxtNewHrsHeadCode.Text, TxtNewHrsHeadDesc.Text, HdnHrsHeadGroupCode.Value.ToString(), BaseUserID.ToString());
                gvHrsHead.EditIndex = -1;
                FillHoursHead();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
            else
            {
                lblErrorMsg.Text = "Invaild Code";
            }
        }
        if (e.CommandName == "Reset")
        {
            TxtNewHrsHeadCode.Text = "";
            TxtNewHrsHeadDesc.Text = "";

        }

    }

    /// <summary>
    /// Handles the RowEditing event of the gvHrsHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvHrsHead.EditIndex = e.NewEditIndex;
        FillHoursHead();
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvHrsHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHead_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvHrsHeadCode = (Label)gvHrsHead.Rows[e.RowIndex].FindControl("lblgvHrsHeadCode");
        TextBox txtHrsHeadDesc = (TextBox)gvHrsHead.Rows[e.RowIndex].FindControl("txtHrsHeadDesc");
        //ds = objMastersManagement.blHoursHead_Update(lblgvHrsHeadCode.Text, txtHrsHeadDesc.Text, HdnHrsHeadGroupCode.Value.ToString(), BaseUserID.ToString());
        gvHrsHead.EditIndex = -1;
        FillHoursHead();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvHrsHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvHrsHeadCode = (Label)gvHrsHead.Rows[e.RowIndex].FindControl("lblgvHrsHeadCode");
       // ds = objMastersManagement.blHoursHead_Delete(lblgvHrsHeadCode.Text);
        FillHoursHead();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvHrsHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHead_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvHrsHead.EditIndex = -1;
        FillHoursHead();
    }
    /// <summary>
    /// Handles the RowUpdated event of the gvHrsHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdatedEventArgs"/> instance containing the event data.</param>
    protected void gvHrsHead_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }

}
