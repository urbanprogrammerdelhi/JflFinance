// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Company.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Company
/// </summary>
public partial class Masters_Company : BasePage //System.Web.UI.Page
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
        this.MasterPageFile = BaseLocationAutoID != null ? "~/MasterPage/MasterPage.master" : "~/MasterPage/MasterHeader.master";
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

            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Company + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (string.IsNullOrEmpty(BaseLocationAutoID) && BaseIsAdmin == "SA")
            { imgBack.Visible = true; }
            else
            { imgBack.Visible = false; }

            if (IsReadAccess)
            {
                FillgvCompany();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }
    #endregion

    #region GridView Binding
    /// <summary>
    /// Fillgvs the company.
    /// </summary>
    protected void FillgvCompany()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsCompany = new DataSet();
        DataTable dtCompany = new DataTable();
        int dtflag;
        dtflag = 1;
        dsCompany = objMastersManagement.CompanyGetAll(BaseUserID, BaseIsAdmin);
        dtCompany = dsCompany.Tables[0];

        //to fix empety gridview
        if (dtCompany.Rows.Count == 0)
        {
            dtflag = 0;
            dtCompany.Rows.Add(dtCompany.NewRow());
        }
        gvCompany.DataKeyNames = new string[] { "CompanyCode" };
        gvCompany.DataSource = dtCompany;
        gvCompany.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvCompany.Rows[0].Visible = false;
        }

    }
    #endregion

    #region GridView Commands Events

    /// <summary>
    /// Handles the RowDataBound event of the gvCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvCompany.PageIndex * gvCompany.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvCompany.Columns[3].Visible = false;
        }
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
                TextBox txtCompanyDesc = (TextBox)e.Row.FindControl("txtCompanyDesc");
                if (txtCompanyDesc != null)
                {
                    txtCompanyDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtCompanyDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtCompanyAddress = (TextBox)e.Row.FindControl("txtCompanyAddress");
                if (txtCompanyAddress != null)
                {
                    txtCompanyAddress.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtCompanyAddress.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
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
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvCompany.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtCompanyCode = (TextBox)e.Row.FindControl("txtCompanyCode");
                if (txtCompanyCode != null)
                {
                    txtCompanyCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtCompanyCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtCompanyDesc = (TextBox)e.Row.FindControl("txtCompanyDesc");
                if (txtCompanyDesc != null)
                {
                    txtCompanyDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtCompanyDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtCompanyAddress = (TextBox)e.Row.FindControl("txtCompanyAddress");
                if (txtCompanyAddress != null)
                {
                    txtCompanyAddress.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtCompanyAddress.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        // To Insert a New Row
        TextBox txtCompanyCode = (TextBox)gvCompany.FooterRow.FindControl("txtCompanyCode");
        TextBox txtCompanyDesc = (TextBox)gvCompany.FooterRow.FindControl("txtCompanyDesc");
        TextBox txtCompanyAddress = (TextBox)gvCompany.FooterRow.FindControl("txtCompanyAddress");
        if (e.CommandName == "Add")
        {
            string str = txtCompanyCode.Text.ToString().Substring(0, 1);
            if (txtCompanyCode.Text.ToString().Substring(0,1) != "-")
            {
                ds = objMastersManagement.CompanyAddNew(txtCompanyCode.Text, txtCompanyDesc.Text, txtCompanyAddress.Text, BaseUserID.ToString());
                gvCompany.EditIndex = -1;
                FillgvCompany();
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
            txtCompanyCode.Text = "";
            txtCompanyDesc.Text = "";
            txtCompanyAddress.Text = "";
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the gvCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvCompany_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCompany.EditIndex = e.NewEditIndex;
        FillgvCompany();
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvCompany_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCompany.EditIndex = -1;
        FillgvCompany();
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvCompany_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvCompanyCode = (Label)gvCompany.Rows[e.RowIndex].FindControl("lblgvCompanyCode");
        TextBox txtCompanyDesc = (TextBox)gvCompany.Rows[e.RowIndex].FindControl("txtCompanyDesc");
        TextBox txtCompanyAddress = (TextBox)gvCompany.Rows[e.RowIndex].FindControl("txtCompanyAddress");

        ds = objMastersManagement.CompanyDescriptionUpdate(lblgvCompanyCode.Text, txtCompanyDesc.Text, txtCompanyAddress.Text, BaseUserID.ToString());
        gvCompany.EditIndex = -1;
        FillgvCompany();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvCompanyCode = (Label)gvCompany.Rows[e.RowIndex].FindControl("lblgvCompanyCode");
        ds = objMastersManagement.CompanyDelete(lblgvCompanyCode.Text);
        FillgvCompany();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCompany.PageIndex = e.NewPageIndex;
        gvCompany.EditIndex = -1;
        FillgvCompany();
    }
    #endregion

    #region Controles Command Events
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
