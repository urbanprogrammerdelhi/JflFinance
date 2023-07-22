// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="HrLocation.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_HrLocation
/// </summary>
public partial class Masters_HrLocation : BasePage //System.Web.UI.Page
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
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Page_PreInit(object sender, EventArgs e)
    {
        this.MasterPageFile = ! string.IsNullOrEmpty(BaseLocationAutoID) ? "~/MasterPage/MasterPage.master" : "~/MasterPage/MasterHeader.master";
    }

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
            javaScript.Append("PageTitle('" + Resources.Resource.HrLocation + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (string.IsNullOrEmpty(BaseLocationAutoID) && BaseIsAdmin == "SA")
            { imgBack.Visible = true; }
            else
            { imgBack.Visible = false; }

            if (IsReadAccess == true)
            {
                FillgvHrLocation();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion
    #region Controles Binding
    /// <summary>
    /// Fillddls the company.
    /// </summary>
    protected void FillddlCompany()
    {
        DataSet dsCompany = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        if (BaseIsAdmin != "SA")
        { dsCompany = objMastersManagement.CompanyDescriptionGetAll(BaseCompanyCode, BaseIsAdmin); }
        else
        { dsCompany = objMastersManagement.CompanyDescriptionGetAll(); }
        
        DropDownList ddlCompany = (DropDownList)gvHrLocation.FooterRow.FindControl("ddlCompany");
        Label lblgvCompanyCode = (Label)gvHrLocation.FooterRow.FindControl("lblgvCompanyCode");

        ddlCompany.DataSource = dsCompany.Tables[0];
        ddlCompany.DataValueField = "CompanyCode";
        ddlCompany.DataTextField = "CompanyDesc";
        ddlCompany.DataBind();
        ddlCompany.AutoPostBack = true;
        
        lblgvCompanyCode.Text = ddlCompany.SelectedItem.Value.ToString();
    }
    /// <summary>
    /// Fillgvs the hr location.
    /// </summary>
    protected void FillgvHrLocation()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsHrLocation = new DataSet();
        DataTable dtHrLocation = new DataTable();
        int dtflag;
        dtflag = 1;
        if (BaseIsAdmin != "SA")
        { dsHrLocation = objMastersManagement.HRLocationGetAll(BaseCompanyCode, BaseIsAdmin,BaseUserID); }
        else
        { dsHrLocation = objMastersManagement.HRLocationGetAll(); }
        dtHrLocation = dsHrLocation.Tables[0];

        //to fix empety gridview
        if (dtHrLocation.Rows.Count == 0)
        {
            dtflag = 0;
            dtHrLocation.Rows.Add(dtHrLocation.NewRow());
        }
        gvHrLocation.DataKeyNames = new string[] { "HrLocationAutoId" };
        gvHrLocation.DataSource = dtHrLocation;
        gvHrLocation.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvHrLocation.Rows[0].Visible = false;
        }
        FillddlCompany();
    }
    #endregion
    #region GridView Commands Events
    /// <summary>
    /// Handles the RowDataBound event of the gvHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvHrLocation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvHrLocation.PageIndex * gvHrLocation.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        { gvHrLocation.Columns[6].Visible = false; }
        else
        { gvHrLocation.Columns[6].Visible = true; }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
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
                TextBox txtHrLocationDesc = (TextBox)e.Row.FindControl("txtHrLocationDesc");
                if (txtHrLocationDesc != null)
                {
                    txtHrLocationDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtHrLocationDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtHrLocationAddress = (TextBox)e.Row.FindControl("txtHrLocationAddress");
                if (txtHrLocationAddress != null)
                {
                    txtHrLocationAddress.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtHrLocationAddress.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');"; }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvHrLocation.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtHrLocationCode = (TextBox)e.Row.FindControl("txtHrLocationCode");
                if (txtHrLocationCode != null)
                {
                    txtHrLocationCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtHrLocationCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtHrLocationDesc = (TextBox)e.Row.FindControl("txtHrLocationDesc");
                if (txtHrLocationDesc != null)
                {
                    txtHrLocationDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtHrLocationDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtHrLocationAddress = (TextBox)e.Row.FindControl("txtHrLocationAddress");
                if (txtHrLocationAddress != null)
                {
                    txtHrLocationAddress.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtHrLocationAddress.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvHrLocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        // To Insert a New Row
        DropDownList ddlCompany = (DropDownList)gvHrLocation.FooterRow.FindControl("ddlCompany");
        TextBox txtHrLocationCode = (TextBox)gvHrLocation.FooterRow.FindControl("txtHrLocationCode");
        TextBox txtHrLocationDesc = (TextBox)gvHrLocation.FooterRow.FindControl("txtHrLocationDesc");
        TextBox txtHrLocationAddress = (TextBox)gvHrLocation.FooterRow.FindControl("txtHrLocationAddress");
        if (e.CommandName == "Add")
        {
            ds = objMastersManagement.HRLocationAddNew(ddlCompany.SelectedItem.Value.ToString(), txtHrLocationCode.Text, txtHrLocationDesc.Text, txtHrLocationAddress.Text, BaseUserID.ToString());
            gvHrLocation.EditIndex = -1;
            FillgvHrLocation();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
        if (e.CommandName == "Reset")
        {
            txtHrLocationCode.Text = "";
            txtHrLocationDesc.Text = "";
            txtHrLocationAddress.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvHrLocation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvHrLocation.EditIndex = e.NewEditIndex;
        FillddlCompany();
        FillgvHrLocation();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvHrLocation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvHrLocation.EditIndex = -1;
        FillddlCompany();
        FillgvHrLocation();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvHrLocation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvCompanyCode = (Label)gvHrLocation.Rows[e.RowIndex].FindControl("lblgvCompanyCode");
        Label lblgvHrLocationCode = (Label)gvHrLocation.Rows[e.RowIndex].FindControl("lblgvHrLocationCode");
        TextBox txtHrLocationDesc = (TextBox)gvHrLocation.Rows[e.RowIndex].FindControl("txtHrLocationDesc");
        TextBox txtHrLocationAddress = (TextBox)gvHrLocation.Rows[e.RowIndex].FindControl("txtHrLocationAddress");

        ds = objMastersManagement.HRLocationUpdate(lblgvCompanyCode.Text, lblgvHrLocationCode.Text, txtHrLocationDesc.Text, txtHrLocationAddress.Text, BaseUserID.ToString());
        gvHrLocation.EditIndex = -1;
        FillddlCompany();
        FillgvHrLocation();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvHrLocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvCompanyCode = (Label)gvHrLocation.Rows[e.RowIndex].FindControl("lblgvCompanyCode");
        Label lblgvHrLocationCode = (Label)gvHrLocation.Rows[e.RowIndex].FindControl("lblgvHrLocationCode");
        ds = objMastersManagement.HRLocationDelete(lblgvCompanyCode.Text, lblgvHrLocationCode.Text);
        FillddlCompany();
        FillgvHrLocation();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvHrLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHrLocation.PageIndex = e.NewPageIndex;
        gvHrLocation.EditIndex = -1;
        FillddlCompany();
        FillgvHrLocation();
    }
    #endregion
    #region Controles Command Events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label lblgvCompanyCode = (Label)gvHrLocation.FooterRow.FindControl("lblgvCompanyCode");
        DropDownList ddlCompany = (DropDownList)gvHrLocation.FooterRow.FindControl("ddlCompany");
        lblgvCompanyCode.Text = ddlCompany.SelectedItem.Value.ToString();
    }
    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MasterMenu.aspx");
    }
    #endregion
    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
}
