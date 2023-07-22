// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="OverTimeReasonMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_OverTimeReasonMaster
/// </summary>
public partial class Masters_OverTimeReasonMaster : BasePage
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
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            if (lblPageHdrTitle != null)
            {
                lblPageHdrTitle.Text = Resources.Resource.ReasonMaster;
            }
            if (IsReadAccess == true)
            {
                FillgvOTReasonMaster();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region GridView RoleMaster Events
    /// <summary>
    /// Fillgvs the OT reason master.
    /// </summary>
    protected void FillgvOTReasonMaster()
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = objMaster.OvertimeReasonGet(BaseCompanyCode,BaseLocationAutoID);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
            gvOTReasonMaster.DataSource = dt;
            gvOTReasonMaster.DataBind();
            gvOTReasonMaster.Rows[0].Visible = false;
        }
        else
        {
            gvOTReasonMaster.DataKeyNames = new string[] { "ReasonCode" };
            gvOTReasonMaster.DataSource = dt;
            gvOTReasonMaster.DataBind();
        }
       
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvOTReasonMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow objGridViewRow = e.Row;
            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvOTReasonMaster.PageIndex * gvOTReasonMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvOTReasonMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        TextBox txtOTReasonCode = (TextBox)gvOTReasonMaster.FooterRow.FindControl("txtOTReasonCode");
        TextBox txtOTReasonDesc = (TextBox)gvOTReasonMaster.FooterRow.FindControl("txtOTReasonDesc");
        CheckBox cbIsActive = (CheckBox)gvOTReasonMaster.FooterRow.FindControl("cbIsActive");

        if (e.CommandName.Equals("AddNew"))
        {
            lblErrorMsg.Text = "";
            DataSet ds = objMaster.OvertimeReasonSave(BaseCompanyCode, txtOTReasonCode.Text.Trim(), txtOTReasonDesc.Text.Trim(), cbIsActive.Checked,BaseLocationAutoID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblErrorMsg.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            }
            if (gvOTReasonMaster.Rows.Count.Equals(gvOTReasonMaster.PageSize))
            {
                gvOTReasonMaster.PageIndex = gvOTReasonMaster.PageCount + 1;
            }
            gvOTReasonMaster.EditIndex = -1;
            FillgvOTReasonMaster();
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtOTReasonCode.Text = "";
            txtOTReasonDesc.Text = "";
            cbIsActive.Checked = false;
        }
        else
        {

        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvOTReasonMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOTReasonMaster.EditIndex = e.NewEditIndex;
        FillgvOTReasonMaster();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvOTReasonMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();

        TextBox txtOTReasonCode = (TextBox)gvOTReasonMaster.Rows[e.RowIndex].FindControl("txtOTReasonCode");
        TextBox txtOTReasonDesc = (TextBox)gvOTReasonMaster.Rows[e.RowIndex].FindControl("txtOTReasonDesc");
        CheckBox cbIsActive = (CheckBox)gvOTReasonMaster.Rows[e.RowIndex].FindControl("cbIsActive");

        DataSet ds = objMaster.OvertimeReasonUpdate(txtOTReasonCode.Text.Trim(), txtOTReasonDesc.Text.Trim(), cbIsActive.Checked, BaseLocationAutoID);

        gvOTReasonMaster.EditIndex = -1;
        FillgvOTReasonMaster();

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvOTReasonMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOTReasonMaster.EditIndex = -1;
        FillgvOTReasonMaster();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvOTReasonMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lblErrorMsg.Text = "";
        BL.MastersManagement objMaster = new BL.MastersManagement();
        Label lblOTReasonCode = (Label)gvOTReasonMaster.Rows[e.RowIndex].FindControl("lblOTReasonCode");

        DataSet ds = objMaster.OvertimeReasonDelete(lblOTReasonCode.Text, BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = "Cannot Delete !!! Reason Code is in Use";
        }
        FillgvOTReasonMaster();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvOTReasonMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOTReasonMaster.PageIndex = e.NewPageIndex;
        gvOTReasonMaster.EditIndex = -1;
        FillgvOTReasonMaster();
    }
    #endregion
}
