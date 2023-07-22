// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="RoleMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_RoleMaster
/// </summary>
public partial class Masters_RoleMaster :  BasePage //System.Web.UI.Page
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
            javaScript.Append("PageTitle('" + Resources.Resource.RoleMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                hfspDecimalPlace.Value = "{0:n" + BaseDigitsAfterDecimalPlaces.ToString() + "}";
                FillgvRoleMaster();
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
    /// Fillgvs the role master.
    /// </summary>
    protected void FillgvRoleMaster()
    {
        BL.MastersManagement  objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objMaster.RoleMasterGet(BaseCompanyCode);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvRoleMaster.DataKeyNames = new string[] { "RoleCode" };
        gvRoleMaster.DataSource = dt;
        gvRoleMaster.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvRoleMaster.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvRoleMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvRoleMaster_RowDataBound(object sender, GridViewRowEventArgs e)
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
                int serialNo = gvRoleMaster.PageIndex * gvRoleMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvRoleMaster.Columns[4].Visible = false;
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
                { ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');"; }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            if (IsWriteAccess == false)
            {
                gvRoleMaster.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtRoleCode = (TextBox)e.Row.FindControl("txtRoleCode");
                if (txtRoleCode != null)
                {
                    txtRoleCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtRoleCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvRoleMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvRoleMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        TextBox txtRoleCode = (TextBox)gvRoleMaster.FooterRow.FindControl("txtRoleCode");
        TextBox txtRoleDesc = (TextBox)gvRoleMaster.FooterRow.FindControl("txtRoleDesc");
        
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objMaster.RoleMasterAddNew(BaseCompanyCode,txtRoleCode.Text,txtRoleDesc.Text,BaseUserID);
            if (gvRoleMaster.Rows.Count.Equals(gvRoleMaster.PageSize))
            {
                gvRoleMaster.PageIndex = gvRoleMaster.PageCount + 1;
            }
            gvRoleMaster.EditIndex = -1;
            FillgvRoleMaster();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtRoleCode.Text = "";
            txtRoleDesc.Text = "";  
            lblErrorMsg.Text = "";
        }
        else
        {

        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvRoleMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvRoleMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRoleMaster.EditIndex = e.NewEditIndex;
        FillgvRoleMaster();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvRoleMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvRoleMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();

        LinkButton lblRoleCode = (LinkButton)gvRoleMaster.Rows[e.RowIndex].FindControl("lblRoleCode");
        TextBox txtRoleDesc = (TextBox)gvRoleMaster.Rows[e.RowIndex].FindControl("txtRoleDesc");

        ds = objMaster.RoleMasterUpdate(BaseCompanyCode, lblRoleCode.Text,txtRoleDesc.Text, BaseUserID);

        gvRoleMaster.EditIndex = -1;
        FillgvRoleMaster();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvRoleMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvRoleMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRoleMaster.EditIndex = -1;
        FillgvRoleMaster();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvRoleMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvRoleMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        LinkButton lblRoleCode = (LinkButton)gvRoleMaster.Rows[e.RowIndex].FindControl("lblRoleCode");

        ds = objMaster.RoleMasterDelete(BaseCompanyCode, lblRoleCode.Text);
        FillgvRoleMaster();
        gvRoleDetail.Visible = false;
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvRoleMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvRoleMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoleMaster.PageIndex = e.NewPageIndex;
        gvRoleMaster.EditIndex = -1;
        FillgvRoleMaster();
    }

    /// <summary>
    /// Handles the Click event of the lblRoleCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblRoleCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblRoleCode = (LinkButton)gvRoleMaster.Rows[row.RowIndex].FindControl("lblRoleCode");
        hfglobalRole.Value = lblRoleCode.Text;
        gvRoleDetail.EditIndex = -1;
        FillgvRoleDetail();
        gvRoleDetail.Visible = true;
    }
    #endregion

    #region GridView ProductDetail Events
    /// <summary>
    /// Fillgvs the role detail.
    /// </summary>
    protected void FillgvRoleDetail()
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objMaster.RoleDetailGet(BaseLocationAutoID, hfglobalRole.Value.ToString());
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvRoleDetail.DataKeyNames = new string[] { "RoleCode" };
        gvRoleDetail.DataSource = dt;
        gvRoleDetail.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvRoleDetail.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvRoleDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvRoleDetail_RowDataBound(object sender, GridViewRowEventArgs e)
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
                int serialNo = gvRoleMaster.PageIndex * gvRoleMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
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
                            //gvRoleDetail.EditIndex = e.Row.RowIndex;
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
    /// Handles the RowUpdating event of the gvRoleDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvRoleDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();

        Label lblRoleCode = (Label)gvRoleDetail.Rows[e.RowIndex].FindControl("lblRoleCode");
        TextBox txtEffectiveFrom = (TextBox)gvRoleDetail.Rows[e.RowIndex].FindControl("txtEffectiveFrom");
        TextBox txtEffectiveTo = (TextBox)gvRoleDetail.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        TextBox txtRate = (TextBox)gvRoleDetail.Rows[e.RowIndex].FindControl("txtRate");
        if (txtEffectiveTo.Text != "")
        {
            if (CompareDates(DateTime.Parse(txtEffectiveTo.Text), DateTime.Parse(txtEffectiveFrom.Text)) == 1 || CompareDates(DateTime.Parse(txtEffectiveTo.Text), DateTime.Parse(txtEffectiveFrom.Text)) == 0)
            {
                ds = objMaster.RoleDetailUpdate (BaseLocationAutoID,lblRoleCode.Text, txtEffectiveFrom.Text, txtEffectiveTo.Text, txtRate.Text, BaseUserID);

                gvRoleDetail.EditIndex = -1;
                FillgvRoleDetail();
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
            ds = objMaster.RoleDetailUpdate(BaseLocationAutoID, lblRoleCode.Text, txtEffectiveFrom.Text, txtEffectiveTo.Text, decimal.Parse(txtRate.Text).ToString("0.00"), BaseUserID);

            gvRoleDetail.EditIndex = -1;
            FillgvRoleDetail();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvRoleDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvRoleDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowCommand event of the gvRoleDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvRoleDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowEditing event of the gvRoleDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvRoleDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRoleDetail.EditIndex = e.NewEditIndex;
        FillgvRoleDetail();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvRoleDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvRoleDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRoleDetail.EditIndex = -1;
        FillgvRoleDetail();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvRoleDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvRoleDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoleDetail.PageIndex = e.NewPageIndex;
        gvRoleDetail.EditIndex = -1;
        FillgvRoleDetail();
    }

    #endregion
}
