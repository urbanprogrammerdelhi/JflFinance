// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="AllowanceMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_AllowanceMaster
/// </summary>
public partial class Masters_AllowanceMaster : BasePage
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
            javaScript.Append("PageTitle('" + Resources.Resource.AllowanceMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            if (IsReadAccess == true)
            {
                FillgvAllowanceMaster();
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
    /// Fillgvs the allowance master.
    /// </summary>
    protected void FillgvAllowanceMaster()
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = objMaster.AllowanceMasterGet(BaseLocationAutoID);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
            gvAllowanceMaster.DataSource = dt;
            gvAllowanceMaster.DataBind();
            gvAllowanceMaster.Rows[0].Visible = false;
        }
        else
        {
            gvAllowanceMaster.DataKeyNames = new string[] { "AllowanceAutoID" };
            gvAllowanceMaster.DataSource = dt;
            gvAllowanceMaster.DataBind();
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvAllowanceMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlElementType = (DropDownList)e.Row.FindControl("ddlElementType");
            HiddenField hfElementType = (HiddenField)e.Row.FindControl("hfElementType");

            if (ddlElementType != null)
            {
                ddlElementType.SelectedValue = hfElementType.Value;
            }
            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvAllowanceMaster.PageIndex * gvAllowanceMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvAllowanceMaster.Columns[5].Visible = false;
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
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            if (IsWriteAccess == false)
            {
                gvAllowanceMaster.ShowFooter = false;
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
    /// Handles the RowCommand event of the gvAllowanceMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        TextBox txtAllowanceDescription = (TextBox)gvAllowanceMaster.FooterRow.FindControl("txtAllowanceDescription");
        TextBox txtElement = (TextBox)gvAllowanceMaster.FooterRow.FindControl("txtElement");
        TextBox txtRateID = (TextBox)gvAllowanceMaster.FooterRow.FindControl("txtRateID");
        DropDownList ddlElementType = (DropDownList)gvAllowanceMaster.FooterRow.FindControl("ddlElementType");

        if (e.CommandName.Equals("AddNew"))
        {
            if (txtRateID.Text == "")
                txtRateID.Text = "0";

            ds = objMaster.AllowanceMasterAdd(BaseLocationAutoID, txtAllowanceDescription.Text, txtElement.Text, ddlElementType.SelectedValue, txtRateID.Text, BaseUserID);
            if (gvAllowanceMaster.Rows.Count.Equals(gvAllowanceMaster.PageSize))
            {
                gvAllowanceMaster.PageIndex = gvAllowanceMaster.PageCount + 1;
            }
            gvAllowanceMaster.EditIndex = -1;
            FillgvAllowanceMaster();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtElement.Text = "";
            txtAllowanceDescription.Text = "";
            txtRateID.Text = "";
        }
        else
        {

        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvAllowanceMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAllowanceMaster.EditIndex = e.NewEditIndex;
        FillgvAllowanceMaster();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvAllowanceMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        TextBox txtAllowanceDescription = (TextBox)gvAllowanceMaster.Rows[e.RowIndex].FindControl("txtAllowanceDescription");
        TextBox txtElement = (TextBox)gvAllowanceMaster.Rows[e.RowIndex].FindControl("txtElement");
        DropDownList ddlElementType = (DropDownList)gvAllowanceMaster.Rows[e.RowIndex].FindControl("ddlElementType");
        TextBox txtRateID = (TextBox)gvAllowanceMaster.Rows[e.RowIndex].FindControl("txtRateID");
        HiddenField hfAllowanceAutoID = (HiddenField)gvAllowanceMaster.Rows[e.RowIndex].FindControl("hfAllowanceAutoID");
        if (txtRateID.Text == "")
            txtRateID.Text = "0";
        DataSet ds = objMaster.AllowanceMasterUpdate(BaseLocationAutoID, hfAllowanceAutoID.Value, txtAllowanceDescription.Text, txtElement.Text, txtRateID.Text, ddlElementType.SelectedValue);

        gvAllowanceMaster.EditIndex = -1;
        FillgvAllowanceMaster();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvAllowanceMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAllowanceMaster.EditIndex = -1;
        FillgvAllowanceMaster();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvAllowanceMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        HiddenField hfAllowanceAutoID = (HiddenField)gvAllowanceMaster.Rows[e.RowIndex].FindControl("hfAllowanceAutoID");
        DataSet ds = objMaster.AllowanceMasterDelete(hfAllowanceAutoID.Value);
        FillgvAllowanceMaster();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvAllowanceMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAllowanceMaster.PageIndex = e.NewPageIndex;
        gvAllowanceMaster.EditIndex = -1;
        FillgvAllowanceMaster();
    }

    #endregion

   
}
