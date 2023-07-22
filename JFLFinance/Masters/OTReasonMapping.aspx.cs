// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="OTReasonMapping.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_OTReasonMapping
/// </summary>
public partial class Masters_OTReasonMapping : BasePage
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
            FillOTReason();
            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            ds = objMastersManagement.LocationDescGet(BaseLocationAutoID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtLocation.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
            }
            FillClient();
            FillgvOTReasonMapping();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnGoAssignment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGoAssignment_Click(object sender, EventArgs e)
    {
        FillPost();
    }
    /// <summary>
    /// Handles the Click event of the btnGoClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGoClient_Click(object sender, EventArgs e)
    {
        FillAssignemnt();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvOTReasonMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        HiddenField hfReasonAutoID = (HiddenField)gvOTReasonMapping.Rows[e.RowIndex].FindControl("hfReasonAutoID");

        ds = objMaster.OtReasonMappingDelete(hfReasonAutoID.Value);
        FillgvOTReasonMapping();
    }
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objMastersManagement.OtReasonMappingInsert(msddlOTReason.sValue.ToString(), BaseLocationAutoID, msddlClient.sValue.ToString(), msddlAssignment.sValue.ToString(), msddlPost.sValue.ToString(), BaseUserID);
        FillgvOTReasonMapping();
    }
    /// <summary>
    /// Fills the OT reason.
    /// </summary>
    protected void FillOTReason()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objMastersManagement.OvertimeReasonGetAll(BaseCompanyCode, BaseLocationAutoID);
        DataRow dr = ds.Tables[0].NewRow();
        dr["ReasonCode"] = "All";
        dr["ReasonDesc"] = "All";
        ds.Tables[0].Rows.InsertAt(dr, 0);
        msddlOTReason.CreateCheckBox(ds.Tables[0], "ReasonDesc", "ReasonCode");
    }
    /// <summary>
    /// Fills the client.
    /// </summary>
    protected void FillClient()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objMastersManagement.OtReasonClientGet(BaseLocationAutoID);
        DataRow dr = ds.Tables[0].NewRow();
        dr["ClientCode"] = "All";
        dr["ClientName"] = "All";
        ds.Tables[0].Rows.InsertAt(dr, 0);
        msddlClient.CreateCheckBox(ds.Tables[0], "ClientName", "ClientCode");
    }
    /// <summary>
    /// Fills the assignemnt.
    /// </summary>
    protected void FillAssignemnt()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objMastersManagement.OtReasonAssignmentGet(BaseLocationAutoID, msddlClient.sValue.ToString());
        DataRow dr = ds.Tables[0].NewRow();
        dr["AsmtCode"] = "All";
        dr["AsmtAddress"] = "All";
        ds.Tables[0].Rows.InsertAt(dr, 0);
        msddlAssignment.CreateCheckBox(ds.Tables[0], "AsmtAddress", "AsmtCode");
    }
    /// <summary>
    /// Fills the post.
    /// </summary>
    protected void FillPost()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objMastersManagement.OtReasonPostGet(BaseLocationAutoID, msddlClient.sValue.ToString(), msddlAssignment.sValue.ToString());
        DataRow dr = ds.Tables[0].NewRow();
        dr["PostCode"] = "All";
        dr["PostDesc"] = "All";
        ds.Tables[0].Rows.InsertAt(dr, 0);
        msddlPost.CreateCheckBox(ds.Tables[0], "PostDesc", "PostCode");
    }
    #region GridView OTReasonMapping Events
    /// <summary>
    /// Fillgvs the OT reason mapping.
    /// </summary>
    protected void FillgvOTReasonMapping()
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = objMaster.OtReasonMappingLocationWiseGet(BaseCompanyCode, BaseLocationAutoID, msddlClient.sValue.ToString(), msddlAssignment.sValue.ToString(), msddlPost.sValue.ToString());
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
            gvOTReasonMapping.DataSource = dt;
            gvOTReasonMapping.DataBind();
            gvOTReasonMapping.Rows[0].Visible = false;
        }
        else
        {
            gvOTReasonMapping.DataKeyNames = new string[] { "ResonAutoID" };
            gvOTReasonMapping.DataSource = dt;
            gvOTReasonMapping.DataBind();
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvOTReasonMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOTReasonMapping.PageIndex = e.NewPageIndex;
        gvOTReasonMapping.EditIndex = -1;
        FillgvOTReasonMapping();
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvOTReasonMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonMapping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow objGridViewRow = e.Row;
            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvOTReasonMapping.PageIndex * gvOTReasonMapping.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
        }
    }
    #endregion

}
