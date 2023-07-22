// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Category.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;


/// <summary>
/// Class Masters_Category
/// </summary>
public partial class Masters_Category : BasePage //: System.Web.UI.Page
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
                int virtualDirectoryNameLength = 0;
                virtualDirectoryNameLength = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirectoryNameLength));
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
                int virtualDirectoryNameLength = 0;
                virtualDirectoryNameLength = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirectoryNameLength));
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
                int virtualDirectoryNameLength = 0;
                virtualDirectoryNameLength = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirectoryNameLength));
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
                int virtualDirectoryNameLength = 0;
                virtualDirectoryNameLength = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirectoryNameLength));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
    /// <summary>
    /// The index
    /// </summary>
    static int Index;
    #region Page Functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.CategoryMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (this.IsReadAccess == true)
            {
                this.FillgvCategory();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

    }
    #endregion

    #region Data Binding

    /// <summary>
    /// Fillgvs the category.
    /// </summary>
    protected void FillgvCategory()
    {

        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet dsCategory = new DataSet();
        DataTable dtCategory = new DataTable();

        dsCategory = objMasterManagement.CategoryMasterGetAll(BaseCompanyCode);
        if (dsCategory != null && dsCategory.Tables.Count > 0 && dsCategory.Tables[0].Rows.Count > 0)
        {
            gvCategory.DataSource = dsCategory;
            gvCategory.DataBind();
        }
        else
        {
            dtCategory = dsCategory.Tables[0];
            dtCategory.Rows.Add(dtCategory.NewRow());
            gvCategory.DataSource = dtCategory;
            gvCategory.DataBind();
            gvCategory.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }

    }
    #endregion

    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvCategory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the rowEditing event of the gvCategory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvCategory_rowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCategory.EditIndex = e.NewEditIndex;
        this.FillgvCategory();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvCategory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtCategoryDesc = (TextBox)gvCategory.Rows[e.RowIndex].FindControl("txtCategoryDesc");
        Label lblgvCategoryCode = (Label)gvCategory.Rows[e.RowIndex].FindControl("lblgvCategoryCode");

        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.CategoryMasterUpdate(lblgvCategoryCode.Text, txtCategoryDesc.Text, BaseCompanyCode, BaseUserID);
        gvCategory.EditIndex = -1;
        this.FillgvCategory();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvCategory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Add New")
        {
            string strCompanyCode, strUserId;
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();
            DataSet ds = new DataSet();
            TextBox txtCategoryCode = (TextBox)gvCategory.FooterRow.FindControl("txtCategoryCode");
            TextBox txtNewCategoryDesc = (TextBox)gvCategory.FooterRow.FindControl("txtNewCategoryDesc");
            strCompanyCode = BaseCompanyCode;
            strUserId = BaseUserID;
            if (txtNewCategoryDesc.Text.Length > 50)
            {

                lblErrorMsg.Text = Resources.Resource.MaximumLength;
            }

            else
            {
                ds = objMasterManagement.CategoryMasterAddNew(txtCategoryCode.Text, txtNewCategoryDesc.Text, strCompanyCode, strUserId);
                this.FillgvCategory();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            switch (e.CommandArgument.ToString())
            {
                case "First":
                    gvCategory.PageIndex = 0;
                    break;
                case "Prev":
                    Index = 1;
                    break;
                case "Next":
                    Index = 0;
                    break;
                case "Last":
                    gvCategory.PageIndex = gvCategory.PageCount;
                    break;
            }

        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvCategory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblCatCode = (Label)gvCategory.Rows[e.RowIndex].FindControl("lblgvCategoryCode");
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.CategoryMasterDelete(lblCatCode.Text, BaseCompanyCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            this.FillgvCategory();
        }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvCategory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvCategory.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvCategory.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvCategory.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvCategory.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvCategory.PageIndex = e.NewPageIndex;
        }
        gvCategory.EditIndex = -1;
        this.FillgvCategory();
    }
    /// <summary>
    /// Handles the DataBound event of the gvCategory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void gvCategory_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvCategory.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvCategory.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvCategory.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvCategory.PageCount.ToString();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvCategory.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvCategory.PageIndex = ddlPages.SelectedIndex;
        this.FillgvCategory();
    }


    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {

        TextBox txtCatCode = (TextBox)gvCategory.FooterRow.FindControl("txtCategoryCode");
        TextBox txtCatDesc = (TextBox)gvCategory.FooterRow.FindControl("txtNewCategoryDesc");

        txtCatCode.Text = "";
        txtCatDesc.Text = "";

    }
    /// <summary>
    /// Handles the Click event of the lnkBtnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void lnkBtnCancel_Click(object sender, EventArgs e)
    {
        gvCategory.EditIndex = -1;
        this.FillgvCategory();
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvCategory control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            if (this.IsWriteAccess == false && this.IsModifyAccess == false && this.IsDeleteAccess == false)
            {
                gvCategory.Columns[3].Visible = false;
            }

            if (this.IsModifyAccess == false)
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
                TextBox txtCategoryDesc = (TextBox)e.Row.FindControl("txtCategoryDesc");
                if (txtCategoryDesc != null)
                {
                    txtCategoryDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtCategoryDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (this.IsDeleteAccess == false)
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
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (this.IsWriteAccess == false)
            {
                gvCategory.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox TxtCategoryCode = (TextBox)e.Row.FindControl("TxtCategoryCode");
                if (TxtCategoryCode != null)
                {
                    TxtCategoryCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    TxtCategoryCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewCategoryDesc = (TextBox)e.Row.FindControl("txtNewCategoryDesc");
                if (txtNewCategoryDesc != null)
                {
                    txtNewCategoryDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewCategoryDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }


    }
}
