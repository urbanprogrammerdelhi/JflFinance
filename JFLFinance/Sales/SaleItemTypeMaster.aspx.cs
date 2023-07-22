// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SaleItemTypeMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_SaleItemTypeMaster.
/// </summary>
public partial class Sales_SaleItemTypeMaster : BasePage//System.Web.UI.Page
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
            
            if (IsReadAccess == true)
            {
                hfspDecimalPlace.Value = "{0:n" + BaseDigitsAfterDecimalPlaces.ToString() + "}";
                FillgvItemType();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region GridView Item Type Events
    /// <summary>
    /// Fillgvs the type of the item.
    /// </summary>
    protected void FillgvItemType()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.SaleItemTypeGet(BaseCompanyCode);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvItemType.DataKeyNames = new string[] { "ItemTypeCode" };
        gvItemType.DataSource = dt;
        gvItemType.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvItemType.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvItemType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvItemType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;

        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblValueCurr = (Label)e.Row.FindControl("lblValueCurr");

            lblValueCurr.Text = Resources.Resource.Value + " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";

        }

        

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvItemType.PageIndex * gvItemType.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvItemType.Columns[4].Visible = false;
            }

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

                TextBox txtItemDesc = (TextBox)e.Row.FindControl("txtItemDesc");
                if (txtItemDesc != null)
                {
                    txtItemDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtItemDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat+ ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                }
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
                gvItemType.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtItemTypeCode = (TextBox)e.Row.FindControl("txtItemTypeCode");
                if (txtItemTypeCode != null)
                {
                    txtItemTypeCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtItemTypeCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtItemDesc = (TextBox)e.Row.FindControl("txtItemDesc");
                if (txtItemDesc != null)
                {
                    txtItemDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtItemDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvItemType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvItemType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        TextBox txtItemTypeCode = (TextBox)gvItemType.FooterRow.FindControl("txtItemTypeCode");
        TextBox txtItemDesc = (TextBox)gvItemType.FooterRow.FindControl("txtItemDesc");
        TextBox txtValue = (TextBox)gvItemType.FooterRow.FindControl("txtValue");
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objSales.SaleOrderItemTypeAdd(BaseCompanyCode, txtItemTypeCode.Text, txtItemDesc.Text, txtValue.Text, BaseUserID);
            if (gvItemType.Rows.Count.Equals(gvItemType.PageSize))
            {
                gvItemType.PageIndex = gvItemType.PageCount + 1;
            }
            gvItemType.EditIndex = -1;
            FillgvItemType();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtItemTypeCode.Text = "";
            txtItemDesc.Text = "";
            txtValue.Text = "";
            lblErrorMsg.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvItemType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvItemType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvItemType.EditIndex = e.NewEditIndex;
        FillgvItemType();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvItemType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvItemType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();

        Label lblItemTypeCode = (Label)gvItemType.Rows[e.RowIndex].FindControl("lblItemTypeCode");
        TextBox txtItemDesc = (TextBox)gvItemType.Rows[e.RowIndex].FindControl("txtItemDesc");
        TextBox txtValue = (TextBox)gvItemType.Rows[e.RowIndex].FindControl("txtValue");

        var value = txtValue.Text.Replace(",", "");

        ds = objSales.SaleOrderItemTypeUpdate(BaseCompanyCode, lblItemTypeCode.Text, txtItemDesc.Text, value, BaseUserID);
        
        gvItemType.EditIndex = -1;
        FillgvItemType();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvItemType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvItemType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvItemType.EditIndex = -1;
        FillgvItemType();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvItemType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvItemType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblItemTypeCode = (Label)gvItemType.Rows[e.RowIndex].FindControl("lblItemTypeCode");

        ds = objSales.SaleOrderItemTypeDelete(BaseCompanyCode, lblItemTypeCode.Text);
        FillgvItemType();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvItemType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvItemType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemType.PageIndex = e.NewPageIndex;
        gvItemType.EditIndex = -1;
        FillgvItemType();
    }
    #endregion

}
