// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SaleProductMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_SaleProductMaster.
/// </summary>
public partial class Sales_SaleProductMaster : BasePage //System.Web.UI.Page
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
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.ProductMaster;
            //}
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ProductMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                hfspDecimalPlace.Value = "{0:n" + BaseDigitsAfterDecimalPlaces.ToString() + "}";
                FillgvProductMaster();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region GridView ProductMaster Events
    /// <summary>
    /// Fillgvs the product master.
    /// </summary>
    protected void FillgvProductMaster()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.SaleOrderRankGet(BaseCompanyCode);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvProductMaster.DataKeyNames = new string[] { "SORank" };
        gvProductMaster.DataSource = dt;
        gvProductMaster.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvProductMaster.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvProductMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvProductMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvProductMaster.PageIndex * gvProductMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvProductMaster.Columns[4].Visible = false;
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
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
            HiddenField HfDesignationCode = (HiddenField)e.Row.FindControl("HfDesignationCode");
            DropDownList ddlDesignationCode = (DropDownList)e.Row.FindControl("ddlDesignationCode");
            if (ddlDesignationCode != null)
            {
                DataSet dsDesignation = new DataSet();
                BL.MastersManagement objMasterManagement = new BL.MastersManagement();
                dsDesignation = objMasterManagement.DesignationMasterGet(BaseCompanyCode);
                ddlDesignationCode.DataSource = dsDesignation.Tables[0];
                ddlDesignationCode.DataValueField = "DesignationCode";
                ddlDesignationCode.DataTextField = "DesignationDesc";
                ddlDesignationCode.DataBind();
            }
            if (HfDesignationCode != null && ddlDesignationCode != null)
            {
                ddlDesignationCode.SelectedIndex = ddlDesignationCode.Items.IndexOf(ddlDesignationCode.Items.FindByValue(HfDesignationCode.Value.ToString()));
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
                gvProductMaster.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtSORank = (TextBox)e.Row.FindControl("txtSORank");
                if (txtSORank != null)
                {
                    txtSORank.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtSORank.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                DropDownList ddlDesignationCode = (DropDownList)e.Row.FindControl("ddlDesignationCode");
                if(ddlDesignationCode != null)
                {
                    DataSet dsDesignation = new DataSet();
                    BL.MastersManagement objMasterManagement = new BL.MastersManagement();
                    dsDesignation = objMasterManagement.DesignationMasterGet(BaseCompanyCode);
                    ddlDesignationCode.DataSource = dsDesignation.Tables[0];
                    ddlDesignationCode.DataValueField = "DesignationCode";
                    ddlDesignationCode.DataTextField = "DesignationDesc";
                    ddlDesignationCode.DataBind();
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvProductMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvProductMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        TextBox txtSORank = (TextBox)gvProductMaster.FooterRow.FindControl("txtSORank");
        DropDownList ddlDesignationCode = (DropDownList)gvProductMaster.FooterRow.FindControl("ddlDesignationCode");
        if (e.CommandName.Equals("AddNew"))
        {
            if (ddlDesignationCode.Items.Count > 0 && ddlDesignationCode.SelectedItem.Value != "")
            {
                ds = objSales.ProductMasterAdd(BaseCompanyCode, txtSORank.Text, ddlDesignationCode.SelectedItem.Value.ToString(), BaseUserID);
                if (gvProductMaster.Rows.Count.Equals(gvProductMaster.PageSize))
                {
                    gvProductMaster.PageIndex = gvProductMaster.PageCount + 1;
                }
                gvProductMaster.EditIndex = -1;
                FillgvProductMaster();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtSORank.Text = "";
            lblErrorMsg.Text = "";
        }
        else
        {

        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvProductMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvProductMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvProductMaster.EditIndex = e.NewEditIndex;
        FillgvProductMaster();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvProductMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvProductMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();

        LinkButton lblSORank = (LinkButton)gvProductMaster.Rows[e.RowIndex].FindControl("lblSORank");
        DropDownList ddlDesignationCode = (DropDownList)gvProductMaster.Rows[e.RowIndex].FindControl("ddlDesignationCode");
        if (ddlDesignationCode.Items.Count > 0 && ddlDesignationCode.SelectedItem.Value != "")
        {
            ds = objSales.ProductMasterUpdate(BaseCompanyCode, lblSORank.Text, ddlDesignationCode.SelectedItem.Value.ToString(), BaseUserID);

            gvProductMaster.EditIndex = -1;
            FillgvProductMaster();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvProductMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvProductMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvProductMaster.EditIndex = -1;
        FillgvProductMaster();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvProductMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvProductMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        LinkButton lblSORank = (LinkButton)gvProductMaster.Rows[e.RowIndex].FindControl("lblSORank");

        ds = objSales.ProductMasterDelete(BaseCompanyCode, lblSORank.Text);
        FillgvProductMaster();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvProductMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvProductMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProductMaster.PageIndex = e.NewPageIndex;
        gvProductMaster.EditIndex = -1;
        FillgvProductMaster();
    }

    /// <summary>
    /// Handles the Click event of the lblSORank control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblSORank_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblSORank = (LinkButton)gvProductMaster.Rows[row.RowIndex].FindControl("lblSORank");
        hfglobalSORank.Value = lblSORank.Text;
        gvProductDetail.EditIndex = -1;
        FillgvProductDetail();
    }
    #endregion

    #region GridView ProductDetail Events
    /// <summary>
    /// Fillgvs the product detail.
    /// </summary>
    protected void FillgvProductDetail()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.ProductDetailGet(BaseLocationAutoID, hfglobalSORank.Value.ToString());
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvProductDetail.DataKeyNames = new string[] { "SORank" };
        gvProductDetail.DataSource = dt;
        gvProductDetail.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvProductDetail.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvProductDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvProductDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblChargeRatePerHrsCurr = (Label)e.Row.FindControl("lblChargeRatePerHrsCurr");

            lblChargeRatePerHrsCurr.Text = Resources.Resource.RatePerHour + " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvProductMaster.PageIndex * gvProductMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsModifyAccess == false && IsWriteAccess == false)
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
            }
            TextBox txtRate = (TextBox)e.Row.FindControl("txtRate");
            if (txtRate != null)
            {
                txtRate.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                txtRate.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
            }
            TextBox txtEffectiveFrom = (TextBox)e.Row.FindControl("txtEffectiveFrom");
            if (txtEffectiveFrom != null)
            {
                txtEffectiveFrom.Attributes.Add("readonly", "readonly");
            }
            TextBox txtEffectiveTo = (TextBox)e.Row.FindControl("txtEffectiveTo");
            if (txtEffectiveTo != null)
            {
                txtEffectiveTo.Attributes.Add("readonly", "readonly");
            }

            if (txtEffectiveFrom != null && txtEffectiveFrom.Text != "")
            {
                ImageButton ImgBtnEffectiveFrom = (ImageButton)e.Row.FindControl("ImgBtnEffectiveFrom");
                if (ImgBtnEffectiveFrom != null)
                {
                    ImgBtnEffectiveFrom.Enabled = false;
                    ImgBtnEffectiveFrom.Visible = false;
                }
                AjaxControlToolkit.CalendarExtender CalendarExtender1 = (AjaxControlToolkit.CalendarExtender)e.Row.FindControl("CalendarExtender1");
                if (CalendarExtender1 != null)
                {
                    CalendarExtender1.Enabled = false;
                }
            }

            Label lblEffectiveTo = (Label)e.Row.FindControl("lblEffectiveTo");
            if (lblEffectiveTo != null)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (lblEffectiveTo.Text.Length > 0 && ImgbtnEdit != null)
                {
                        ImgbtnEdit.Visible = false;
                }
                else
                {
                    if (IsModifyAccess == true && IsWriteAccess == true)
                    {
                        if (ImgbtnEdit != null)
                        {
                            ImgbtnEdit.Visible = true;
                            //gvProductDetail.EditIndex = e.Row.RowIndex;
                        }
                    }
                    else
                    {
                        if (ImgbtnEdit != null)
                        {
                            ImgbtnEdit.Visible = false;
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvProductDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvProductDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();

        Label lblSORank = (Label)gvProductDetail.Rows[e.RowIndex].FindControl("lblSORank");
        TextBox txtEffectiveFrom = (TextBox)gvProductDetail.Rows[e.RowIndex].FindControl("txtEffectiveFrom");
        TextBox txtEffectiveTo = (TextBox)gvProductDetail.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        TextBox txtRate = (TextBox)gvProductDetail.Rows[e.RowIndex].FindControl("txtRate");
        if (txtEffectiveTo.Text != "")
        {
            if (CompareDates(DateTime.Parse(txtEffectiveTo.Text), DateTime.Parse(txtEffectiveFrom.Text)) == 1 || CompareDates(DateTime.Parse(txtEffectiveTo.Text), DateTime.Parse(txtEffectiveFrom.Text)) == 0)
            {
                ds = objSales.ProductDetailUpdate(BaseLocationAutoID, lblSORank.Text, txtEffectiveFrom.Text, txtEffectiveTo.Text, decimal.Parse(txtRate.Text).ToString("0.00"), BaseUserID);

                gvProductDetail.EditIndex = -1;
                FillgvProductDetail();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                txtEffectiveTo.Text = "";
                txtEffectiveTo.Focus();
            }
        }
        else
        {
            ds = objSales.ProductDetailUpdate(BaseLocationAutoID, lblSORank.Text, txtEffectiveFrom.Text, txtEffectiveTo.Text,decimal.Parse(txtRate.Text).ToString("0.00"), BaseUserID);

            gvProductDetail.EditIndex = -1;
            FillgvProductDetail();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvProductDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvProductDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowCommand event of the gvProductDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvProductDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowEditing event of the gvProductDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvProductDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvProductDetail.EditIndex = e.NewEditIndex;
        FillgvProductDetail();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvProductDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvProductDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvProductDetail.EditIndex = -1;
        FillgvProductDetail();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvProductDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvProductDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProductDetail.PageIndex = e.NewPageIndex;
        gvProductDetail.EditIndex = -1;
        FillgvProductDetail();
    }

    #endregion
}
