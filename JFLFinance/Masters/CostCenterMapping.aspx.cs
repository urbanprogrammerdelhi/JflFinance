// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CostCenterMapping.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

/// <summary>
/// Class Masters_CostCenterMapping
/// </summary>
public partial class Masters_CostCenterMapping : BasePage
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
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.CostCenterMapping + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            FillgvCostCenterMapping();
        }
    }
    #endregion
    
    #region Controles Binding
    /// <summary>
    /// Fillgvs the cost center mapping.
    /// </summary>
    protected void FillgvCostCenterMapping()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objMastersManagement.CostCenterMapping(BaseLocationAutoID);
        //to fix empety gridview
        dt = ds.Tables[0];
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvCostCenterMapping.DataKeyNames = new string[] { "LocationAutoID" };
        gvCostCenterMapping.DataSource = dt;
        gvCostCenterMapping.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvCostCenterMapping.Rows[0].Visible = false;
        }
    }
    #endregion
    
    #region GridView Commands Events
    /// <summary>
    /// Handles the RowDataBound event of the gvCostCenterMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCostCenterMapping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvCostCenterMapping.PageIndex * gvCostCenterMapping.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        { gvCostCenterMapping.Columns[2].Visible = false; }
        else
        { gvCostCenterMapping.Columns[2].Visible = true; }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            DropDownList ddlAssignment = (DropDownList) e.Row.FindControl("ddlAssignment");
            DropDownList ddlSite = (DropDownList) e.Row.FindControl("ddlSite");
            HiddenField hfAsignmentField = (HiddenField) e.Row.FindControl("hfAssignment");
            HiddenField hfSite = (HiddenField) e.Row.FindControl("hfSite");
            if (ddlAssignment != null)
            {
                FillAssignment(ddlAssignment);
                FillSiteAssignmentWise(ddlAssignment, ddlSite);
                ddlAssignment.SelectedValue = hfAsignmentField.Value;
                ddlSite.SelectedValue = hfSite.Value;
            }
        if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtCostCenter = (TextBox)e.Row.FindControl("txtCostCenter");
                if (txtCostCenter != null)
                {
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Visible = false; }
            }
         
        }
        else if(e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList ddlAssignment = (DropDownList) e.Row.FindControl("ddlAssignment");
            DropDownList ddlSite = (DropDownList) e.Row.FindControl("ddlSite");
            if (ddlAssignment != null)
            {
                FillAssignment(ddlAssignment);
                FillSiteAssignmentWise(ddlAssignment, ddlSite);
            }
        }
    
    }
    /// <summary>
    /// DDLs the assignment selected index change.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DdlAssignmentSelectedIndexChange(object sender, EventArgs e)
    {
        DropDownList ddlAssignment = (DropDownList)gvCostCenterMapping.FooterRow.FindControl("ddlAssignment");
        DropDownList ddlSite = (DropDownList)gvCostCenterMapping.FooterRow.FindControl("ddlSite");
        if (ddlAssignment != null)
        {
            FillSiteAssignmentWise(ddlAssignment, ddlSite);
        }
           
    }
    /// <summary>
    /// Handles the RowCommand event of the gvCostCenterMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCostCenterMapping_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            DropDownList ddlAssignment = (DropDownList) gvCostCenterMapping.FooterRow.FindControl("ddlAssignment");
            DropDownList ddlSite = (DropDownList) gvCostCenterMapping.FooterRow.FindControl("ddlSite");
            TextBox txtCostCenter = (TextBox) gvCostCenterMapping.FooterRow.FindControl("txtCostCenter");
            BL.MastersManagement obj = new MastersManagement();
            DataSet ds = obj.InsertCostCenter(BaseCompanyCode, BaseLocationAutoID, "", ddlAssignment.SelectedItem.Text,
                                                ddlSite.SelectedValue, txtCostCenter.Text, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    lblErrorMsg.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                }
            }
            FillgvCostCenterMapping();
        }
    }
    /// <summary>
    /// DDLs the assignment data row selected index change.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAssignmentDataRowSelectedIndexChange(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Handles the RowEditing event of the gvCostCenterMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvCostCenterMapping_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCostCenterMapping.EditIndex = e.NewEditIndex;
        FillgvCostCenterMapping();

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvCostCenterMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvCostCenterMapping_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCostCenterMapping.EditIndex = -1;
        FillgvCostCenterMapping();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvCostCenterMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvCostCenterMapping_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        TextBox txtCostCenter = (TextBox)gvCostCenterMapping.Rows[e.RowIndex].FindControl("txtCostCenter");
        Label lblAssignment = (Label)gvCostCenterMapping.Rows[e.RowIndex].FindControl("lblAssignment");
        Label lblSiteName = (Label)gvCostCenterMapping.Rows[e.RowIndex].FindControl("lblSiteName");
        HiddenField hfClientCode = (HiddenField)gvCostCenterMapping.Rows[e.RowIndex].FindControl("hfClientCode");

        ds = objMastersManagement.CostCenterMappingUpdate(BaseCompanyCode, BaseLocationAutoID, hfClientCode.Value, txtCostCenter.Text, lblAssignment.Text, lblSiteName.Text, BaseUserID);
        gvCostCenterMapping.EditIndex = -1;
        FillgvCostCenterMapping();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvCostCenterMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvCostCenterMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement obj = new BL.MastersManagement();
        Label lblCostCenter = (Label)gvCostCenterMapping.Rows[e.RowIndex].FindControl("lblCostCenter");
        Label lblAssignment = (Label)gvCostCenterMapping.Rows[e.RowIndex].FindControl("lblAssignment");
        Label lblSiteName = (Label)gvCostCenterMapping.Rows[e.RowIndex].FindControl("lblSiteName");

        DataSet ds = obj.CostCenterMappingDelete(BaseLocationAutoID, lblAssignment.Text, lblSiteName.Text,
                                                   lblCostCenter.Text);

        FillgvCostCenterMapping();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvCostCenterMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvCostCenterMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCostCenterMapping.PageIndex = e.NewPageIndex;
        gvCostCenterMapping.EditIndex = -1;
        FillgvCostCenterMapping();
    }
    #endregion
    
    #region Controles Command Events
    /// <summary>
    /// Fills the assignment.
    /// </summary>
    /// <param name="ddlAssignment">The DDL assignment.</param>
    protected void FillAssignment(DropDownList ddlAssignment)
    {
        BL.MastersManagement obj = new BL.MastersManagement();
        DataSet ds = obj.GetAssignment(BaseLocationAutoID);
        ddlAssignment.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAssignment.DataSource = ds.Tables[0];
            ddlAssignment.DataValueField = "AsmtMasterAutoID";
            ddlAssignment.DataTextField = "AsmtAddress";
            ddlAssignment.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlAssignment.Items.Add(li);
        }

    }
    /// <summary>
    /// Fills the site assignment wise.
    /// </summary>
    /// <param name="ddlAssignment">The DDL assignment.</param>
    /// <param name="ddlSite">The DDL site.</param>
    protected void FillSiteAssignmentWise(DropDownList ddlAssignment, DropDownList ddlSite)
    {
        BL.MastersManagement obj = new BL.MastersManagement();
        DataSet ds = obj.GetSiteAssignmentWise(ddlAssignment.SelectedValue);
        ddlSite.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSite.DataSource = ds.Tables[0];
            ddlSite.DataValueField = "Site";
            ddlSite.DataTextField = "Description";
            ddlSite.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlSite.Items.Add(li);
        }

    }

    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
    }
    #endregion
    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
    }
}
