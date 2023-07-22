// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CurrencyMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_CurrencyMaster
/// </summary>
public partial class Masters_CurrencyMaster : BasePage//System.Web.UI.Page
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
            javaScript.Append("PageTitle('" + Resources.Resource.CurrencyMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillgvCurrency();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }

    /// <summary>
    /// Fillgvs the currency.
    /// </summary>
    private void FillgvCurrency()
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtCurrency = new DataTable();
        ds = objblMasterManagement.CurrencyMasterGetAll();
        dtCurrency = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtCurrency.Rows.Count > 0)
        {
            gvCurrency.DataSource = dtCurrency;
            gvCurrency.DataBind();
        }
        else
        {
            dtCurrency.Rows.Add(dtCurrency.NewRow());
            gvCurrency.DataSource = dtCurrency;
            gvCurrency.DataBind();
            int TotalColumns = gvCurrency.Rows[0].Cells.Count;
            gvCurrency.Rows[0].Cells.Clear();
            gvCurrency.Rows[0].Cells.Add(new TableCell());
            gvCurrency.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvCurrency.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvCurrency control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCurrency_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");

        if (lblSerialNo != null)
        {
            int serialNo = gvCurrency.PageIndex * gvCurrency.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvCurrency.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            // e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (IBEdit != null)
                {
                    IBEdit.Visible = false;
                }

            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtCurrencyDesc = (TextBox)e.Row.FindControl("txtCurrencyDesc");
                if (txtCurrencyDesc != null)
                {
                    txtCurrencyDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtCurrencyDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                }
            }
            else
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDelete != null)
                {
                    IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvCurrency.ShowFooter = false;
            }
            else
            {
                
                ImageButton lbAdd = (ImageButton)e.Row.FindControl("lbAdd");
                if (lbAdd != null)
                {
                    lbAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewCurrencyCode = (TextBox)e.Row.FindControl("txtNewCurrencyCode");
                if (txtNewCurrencyCode != null)
                {
                    txtNewCurrencyCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewCurrencyCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewCurrencyDesc = (TextBox)e.Row.FindControl("txtNewCurrencyDesc");
                if (txtNewCurrencyDesc != null)
                {
                    txtNewCurrencyDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewCurrencyDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvCurrency control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCurrency_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        TextBox txtNewCurrencyCode = (TextBox)gvCurrency.FooterRow.FindControl("txtNewCurrencyCode");
        TextBox txtNewCurrencyDesc = (TextBox)gvCurrency.FooterRow.FindControl("txtNewCurrencyDesc");
        TextBox txtNewCurrencySymbol = (TextBox)gvCurrency.FooterRow.FindControl("txtNewCurrencySymbol");
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objblMasterManagement.CurrencyMasterAddNew(txtNewCurrencyCode.Text, txtNewCurrencyDesc.Text,txtNewCurrencySymbol.Text ,BaseUserID);
            if (gvCurrency.Rows.Count.Equals(gvCurrency.PageSize))
            {
                gvCurrency.PageIndex = gvCurrency.PageCount + 1;
            }
            gvCurrency.EditIndex = -1;
            FillgvCurrency();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewCurrencyCode.Text = "";
            txtNewCurrencyDesc.Text = "";
            txtNewCurrencySymbol.Text = "";

        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvCurrency control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvCurrency_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCurrency.EditIndex = e.NewEditIndex;
        FillgvCurrency();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvCurrency control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvCurrency_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblCurrencyCode = (Label)gvCurrency.Rows[e.RowIndex].FindControl("lblCurrencyCode");
        TextBox txtCurrencyDesc = (TextBox)gvCurrency.Rows[e.RowIndex].FindControl("txtCurrencyDesc");
        TextBox txtCurrencySymbol = (TextBox)gvCurrency.Rows[e.RowIndex].FindControl("txtCurrencySymbol");
        ds = objblMasterManagement.CurrencyMasterUpdate(lblCurrencyCode.Text, txtCurrencyDesc.Text, txtCurrencySymbol.Text, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        gvCurrency.EditIndex = -1;
        FillgvCurrency();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvCurrency control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvCurrency_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCurrency.EditIndex = -1;
        FillgvCurrency();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvCurrency control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvCurrency_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblCurrencyCode = (Label)gvCurrency.Rows[e.RowIndex].FindControl("lblCurrencyCode");
        ds = objblMasterManagement.CurrencyMasterDelete(lblCurrencyCode.Text);
        FillgvCurrency();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvCurrency control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvCurrency_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCurrency.PageIndex = e.NewPageIndex;
        gvCurrency.EditIndex = -1;
        FillgvCurrency();
    }
}
