// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="shiftPattern.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_shiftPattern
/// </summary>
public partial class Masters_shiftPattern : BasePage//System.Web.UI.Page
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
                javaScript.Append("PageTitle('" + Resources.Resource.ShiftPattern + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());



                if (IsReadAccess == true)
                {
                    FillgvShiftPat();
                }
                else
                {
                    Response.Redirect("../UserManagement/Home.aspx");
                }
            }
    }

    /// <summary>
    /// Fillgvs the shift pat.
    /// </summary>
    protected void FillgvShiftPat()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsShiftPat = new DataSet();
        DataTable dtShiftPat = new DataTable();
        string AsmtCode="";
        int PDLineNo = 0;

        dsShiftPat = objMastersManagement.ShiftPatternsGet(int.Parse(BaseLocationAutoID), AsmtCode, PDLineNo);
        if (dsShiftPat != null && dsShiftPat.Tables.Count > 0 && dsShiftPat.Tables[0].Rows.Count > 0)
        {
            gvShiftPat.DataSource = dsShiftPat.Tables[0];
            gvShiftPat.DataBind();
        }
        else
        {
            dtShiftPat = dsShiftPat.Tables[0];
            dtShiftPat.Rows.Add(dtShiftPat.NewRow());
            gvShiftPat.DataSource = dtShiftPat;
            gvShiftPat.DataBind();
            gvShiftPat.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }

    }

    /// <summary>
    /// Handles the RowUpdating event of the gvShiftPat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvShiftPat_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        Label lblgvShiftPatCode = (Label)gvShiftPat.Rows[e.RowIndex].FindControl("lblgvShiftPatCode");
        TextBox txtShiftPattern = (TextBox)gvShiftPat.Rows[e.RowIndex].FindControl("txtShiftPattern");
        ds = objMastersManagement.ShiftPatternUpdate(int.Parse(BaseLocationAutoID), lblgvShiftPatCode.Text.ToString(), txtShiftPattern.Text.ToString(), BaseUserID.ToString());
        gvShiftPat.EditIndex = -1;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                FillgvShiftPat();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvShiftPat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvShiftPat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvShiftPat.EditIndex = e.NewEditIndex;
        FillgvShiftPat();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvShiftPat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvShiftPat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        Label lblgvShiftPatCode = (Label)gvShiftPat.Rows[e.RowIndex].FindControl("lblgvShiftPatCode");        
        ds = objMastersManagement.ShiftPatternDelete(int.Parse(BaseLocationAutoID), lblgvShiftPatCode.Text.ToString());
        FillgvShiftPat();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvShiftPat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvShiftPat_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvShiftPat.EditIndex = -1;
        FillgvShiftPat();
    }
    /// <summary>
    /// Handles the RowCommand event of the gvShiftPat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvShiftPat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();
            DataSet ds = new DataSet();

            TextBox txtShiftPatCode = (TextBox)gvShiftPat.FooterRow.FindControl("txtShiftPatCode");
            TextBox txtNewShiftPattern = (TextBox)gvShiftPat.FooterRow.FindControl("txtNewShiftPattern");
            
                    ds = objMasterManagement.ShiftPatternInsert(int.Parse(BaseLocationAutoID), txtShiftPatCode.Text, txtNewShiftPattern.Text, BaseUserID.ToString());
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        FillgvShiftPat();
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    }

        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvShiftPat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvShiftPat_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvShiftPat.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Visible = false;
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

            TextBox txtShiftPattern = (TextBox)e.Row.FindControl("txtShiftPattern");
            if (txtShiftPattern != null)
            {
                txtShiftPattern.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtShiftPattern.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvShiftPat.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtShiftPatCode = (TextBox)e.Row.FindControl("txtShiftPatCode");
                TextBox txtNewShiftPattern = (TextBox)e.Row.FindControl("txtNewShiftPattern");


                if (txtShiftPatCode != null)
                {
                    txtShiftPatCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtShiftPatCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }

                if (txtNewShiftPattern != null)
                {
                    txtNewShiftPattern.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewShiftPattern.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvShiftPat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvShiftPat_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvShiftPat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvShiftPat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShiftPat.PageIndex = e.NewPageIndex;
        FillgvShiftPat();
    }
}
