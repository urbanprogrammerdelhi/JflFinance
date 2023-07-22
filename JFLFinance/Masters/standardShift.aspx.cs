// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="standardShift.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_standardShift
/// </summary>
public partial class Masters_standardShift : BasePage //System.Web.UI.Page
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
            javaScript.Append("PageTitle('" + Resources.Resource.StandardShift + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillBranch();
                FillgvStandardShift();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    /// <summary>
    /// Handles the Click event of the btnShiftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnShiftPattern_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Masters/shiftPattern.aspx");
    }
    

    #region Function to Fill GridView
    /// <summary>
    /// Fillgvs the standard shift.
    /// </summary>
    private void FillgvStandardShift()
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objblMasterManagement.StandardSiftsGet(BaseLocationAutoID.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvStandardShift.DataSource = ds.Tables[0];
            gvStandardShift.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gvStandardShift.DataSource = ds.Tables[0];
            gvStandardShift.DataBind();
            int TotalColumns = gvStandardShift.Rows[0].Cells.Count;
            gvStandardShift.Rows[0].Cells.Clear();
            gvStandardShift.Rows[0].Cells.Add(new TableCell());
            gvStandardShift.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvStandardShift.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    #endregion

    #region Function for GridView
    /// <summary>
    /// Handles the RowCommand event of the gvStandardShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvStandardShift_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        TextBox txtShiftCode = (TextBox)gvStandardShift.FooterRow.FindControl("txtShiftCode");
        TextBox txtStartTime = (TextBox)gvStandardShift.FooterRow.FindControl("txtStartTime");
        TextBox txtEndTime = (TextBox)gvStandardShift.FooterRow.FindControl("txtEndTime");
        TextBox txtShiftMinutes = (TextBox)gvStandardShift.FooterRow.FindControl("txtShiftMinutes");
        TextBox txtDescription = (TextBox)gvStandardShift.FooterRow.FindControl("txtDescription");

        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        if (e.CommandName.Equals("AddNew"))
        {
            if (txtShiftCode.Text != "0")
            {
                ds = objblMasterManagement.StandardSiftInsert(BaseLocationAutoID.ToString(), txtShiftCode.Text, txtStartTime.Text, txtEndTime.Text, txtShiftMinutes.Text, BaseUserID, txtDescription.Text);
                if (gvStandardShift.Rows.Count.Equals(gvStandardShift.PageSize))
                {
                    gvStandardShift.PageIndex = gvStandardShift.PageCount + 1;
                }
                gvStandardShift.EditIndex = -1;
                FillgvStandardShift();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                lblErrorMsg.Text = "Shift not Allowed";
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtShiftCode.Text = "";
            txtStartTime.Text = "";
            txtEndTime.Text = "";
            txtShiftMinutes.Text = "0";
            txtDescription.Text = "";
            lblErrorMsg.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvStandardShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvStandardShift_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvStandardShift.PageIndex * gvStandardShift.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            { gvStandardShift.Columns[5].Visible = false; }
            else
            { gvStandardShift.Columns[5].Visible = true; }

            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton ImgBtnEdit = (ImageButton)e.Row.FindControl("ImgBtnEdit");
                if (ImgBtnEdit != null)
                {
                    ImgBtnEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgBtnUpdate = (ImageButton)e.Row.FindControl("ImgBtnUpdate");
                if (ImgBtnUpdate != null)
                {
                    ImgBtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtStartTime = (TextBox)e.Row.FindControl("txtStartTime");
                if (txtStartTime != null)
                {
                    txtStartTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtStartTime.ClientID.ToString() + "');";
                    txtStartTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtStartTime.ClientID.ToString() + "');";
                }
                TextBox txtEndTime = (TextBox)e.Row.FindControl("txtEndTime");
                if (txtEndTime != null)
                {
                    txtEndTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtEndTime.ClientID.ToString() + "');";
                    //txtEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtEndTime.ClientID.ToString() + "');";
                }
                
                TextBox txtShiftMinutes = (TextBox)e.Row.FindControl("txtShiftMinutes");
                if (txtStartTime != null && txtEndTime != null && txtShiftMinutes != null)
                {
                    txtShiftMinutes.Attributes.Add("readonly", "readonly");
                    txtEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtEndTime.ClientID.ToString() + "');javascript:GetTimeDiffInMin('" + txtStartTime.ClientID.ToString() + "','" + txtEndTime.ClientID.ToString() + "','" + txtShiftMinutes.ClientID.ToString() + "');";
                }

            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgBtnDelete = (ImageButton)e.Row.FindControl("ImgBtnDelete");
                if (ImgBtnDelete != null)
                {
                    ImgBtnDelete.Visible = false;
                }
            }
            else
            {
                ImageButton ImgBtnDelete = (ImageButton)e.Row.FindControl("ImgBtnDelete");
                if (ImgBtnDelete != null)
                {
                    ImgBtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvStandardShift.ShowFooter = false;
            }
            else
            {
                ImageButton ImgBtnAddNew = (ImageButton)e.Row.FindControl("ImgBtnAddNew");
                if (ImgBtnAddNew != null)
                {
                    ImgBtnAddNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtShiftCode = (TextBox)e.Row.FindControl("txtShiftCode");
                if (txtShiftCode != null)
                {
                    //txtShiftCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    //txtShiftCode.Attributes["onKeyUp"] = "javascript:" + txtShiftCode.ClientID.ToString() + ".value = " + txtShiftCode.ClientID.ToString() + ".value.toUpperCase();";
                    txtShiftCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");javascript:" + txtShiftCode.ClientID.ToString() + ".value = " + txtShiftCode.ClientID.ToString() + ".value.toUpperCase();";
                    txtShiftCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtStartTime = (TextBox)e.Row.FindControl("txtStartTime");
                if (txtStartTime != null)
                {
                    txtStartTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtStartTime.ClientID.ToString() + "');";
                    txtStartTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtStartTime.ClientID.ToString() + "');";
                }
                TextBox txtEndTime = (TextBox)e.Row.FindControl("txtEndTime");
                if (txtEndTime != null)
                {
                    txtEndTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtEndTime.ClientID.ToString() + "');";
                    //txtEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtEndTime.ClientID.ToString() + "');";
                }
                TextBox txtShiftMinutes = (TextBox)e.Row.FindControl("txtShiftMinutes");
                if (txtStartTime != null && txtEndTime != null && txtShiftMinutes != null)
                {
                    txtShiftMinutes.Attributes.Add("readonly", "readonly");
                    txtEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtEndTime.ClientID.ToString() + "');javascript:GetTimeDiffInMin('" + txtStartTime.ClientID.ToString() + "','" + txtEndTime.ClientID.ToString() + "','" + txtShiftMinutes.ClientID.ToString() + "');";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvStandardShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvStandardShift_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvStandardShift.EditIndex = e.NewEditIndex;
        FillgvStandardShift();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvStandardShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvStandardShift_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objblMastermanagement = new BL.MastersManagement();
        Label lblShiftCode = (Label)gvStandardShift.Rows[e.RowIndex].FindControl("lblShiftCode");
        TextBox txtStartTime = (TextBox)gvStandardShift.Rows[e.RowIndex].FindControl("txtStartTime");
        TextBox txtEndTime = (TextBox)gvStandardShift.Rows[e.RowIndex].FindControl("txtEndTime");
        TextBox txtShiftMinutes = (TextBox)gvStandardShift.Rows[e.RowIndex].FindControl("txtShiftMinutes");
        TextBox txtDescription = (TextBox)gvStandardShift.Rows[e.RowIndex].FindControl("txtDescription");
        

        if (lblShiftCode.Text != "0")
        {
            ds = objblMastermanagement.StandardSiftUpdate(BaseLocationAutoID, lblShiftCode.Text, txtStartTime.Text, txtEndTime.Text, txtShiftMinutes.Text, BaseUserID, txtDescription.Text);
            gvStandardShift.EditIndex = -1;
            FillgvStandardShift();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else
        {
            lblErrorMsg.Text = "Shift not Allowed";
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvStandardShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvStandardShift_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvStandardShift.EditIndex = -1;
        FillgvStandardShift();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvStandardShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvStandardShift_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objblMasterManagement.StandardSiftDelete(BaseLocationAutoID.ToString(), gvStandardShift.DataKeys[e.RowIndex].Value.ToString());
        FillgvStandardShift();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvStandardShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvStandardShift_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStandardShift.PageIndex = e.NewPageIndex;
        gvStandardShift.EditIndex = -1;
        FillgvStandardShift();
    }

    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, BaseHrLocationCode);

        for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
        {
            if (dsBranch.Tables[0].Rows[i]["LocationCode"].ToString() == BaseLocationCode)
            {
                dsBranch.Tables[0].Rows[i].Delete();
            }
        }

        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
        }
        else
        {
            ListItem Li = new ListItem();
            Li.Text = Resources.Resource.NoData;
            Li.Value = "NoData";
            ddlBranch.Items.Add(Li);
        }
    }

    /// <summary>
    /// Handles the Click event of the btnShiftPatternCopyToBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnShiftPatternCopyToBranch_Click(object sender, EventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        if (ddlBranch.SelectedItem.Value.ToString() != "NoData")
        {
            ds = objblMasterManagement.StandardSiftCopyToBranch(BaseCompanyCode, BaseLocationAutoID.ToString(), ddlBranch.SelectedItem.Value.ToString(), BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        FillgvStandardShift();
    }
    #endregion
}
