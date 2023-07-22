// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Language.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Language
/// </summary>
public partial class Masters_Language : BasePage//System.Web.UI.Page
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

    #region Page Load
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
            javaScript.Append("PageTitle('" + Resources.Resource.LanguageMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvLanguage();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Function to Fill GridView
    /// <summary>
    /// Fillgvs the language.
    /// </summary>
    private void FillgvLanguage()
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtLanquage = new DataTable();
        ds = objblMasterManagement.LanguageMasterGetAll();
        dtLanquage = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtLanquage.Rows.Count > 0)
        {
            gvLanguage.DataSource = dtLanquage;
            gvLanguage.DataBind();
        }
        else
        {
            dtLanquage.Rows.Add(dtLanquage.NewRow());
            gvLanguage.DataSource = dtLanquage;
            gvLanguage.DataBind();
            int TotalColumns = gvLanguage.Rows[0].Cells.Count;
            gvLanguage.Rows[0].Cells.Clear();
            gvLanguage.Rows[0].Cells.Add(new TableCell());
            gvLanguage.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvLanguage.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        TextBox txtNewLanguageCode = (TextBox)gvLanguage.FooterRow.FindControl("txtNewLanguageCode");
        TextBox txtNewLanguageDesc = (TextBox)gvLanguage.FooterRow.FindControl("txtNewLanguageDesc");
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        if (e.CommandName.Equals("AddNew"))
        {

            ds = objblMasterManagement.LanguageMasterAddNew(txtNewLanguageCode.Text, txtNewLanguageDesc.Text, BaseUserID);
            if (gvLanguage.Rows.Count.Equals(gvLanguage.PageSize))
            {
                gvLanguage.PageIndex = gvLanguage.PageCount + 1;
            }
            gvLanguage.EditIndex = -1;
            FillgvLanguage();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewLanguageCode.Text = "";
            txtNewLanguageDesc.Text = "";
            lblErrorMsg.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvLanguage.PageIndex * gvLanguage.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            { gvLanguage.Columns[3].Visible = false; }
            else
            { gvLanguage.Columns[3].Visible = true; }

            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEditLang = (ImageButton)e.Row.FindControl("IBEditLang");
                if (IBEditLang != null)
                {
                    IBEditLang.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdateLang = (ImageButton)e.Row.FindControl("ImgbtnUpdateLang");
                if (ImgbtnUpdateLang != null)
                {
                    ImgbtnUpdateLang.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtLanguageDesc = (TextBox)e.Row.FindControl("txtLanguageDesc");
                if (txtLanguageDesc != null)
                {
                    txtLanguageDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtLanguageDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteLang = (ImageButton)e.Row.FindControl("IBDeleteLang");
                if (IBDeleteLang != null)
                {
                    IBDeleteLang.Visible = false;
                }
                ///////
            }
            else
            {
                ImageButton IBDeleteLang = (ImageButton)e.Row.FindControl("IBDeleteLang");
                if (IBDeleteLang != null)
                {
                    IBDeleteLang.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvLanguage.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {

                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewLanguageCode = (TextBox)e.Row.FindControl("txtNewLanguageCode");
                if (txtNewLanguageCode != null)
                {
                    txtNewLanguageCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewLanguageCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewLanguageDesc = (TextBox)e.Row.FindControl("txtNewLanguageDesc");
                if (txtNewLanguageDesc != null)
                {
                    txtNewLanguageDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewLanguageDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvLanguage.EditIndex = e.NewEditIndex;
        FillgvLanguage();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objblMastermanagement = new BL.MastersManagement();
        Label lblLanguageCode = (Label)gvLanguage.Rows[e.RowIndex].FindControl("lblLanguageCode");
        TextBox txtlanguageDesc = (TextBox)gvLanguage.Rows[e.RowIndex].FindControl("txtLanguageDesc");
        ds = objblMastermanagement.LanguageMasterUpdate(lblLanguageCode.Text, txtlanguageDesc.Text, BaseUserID);
        gvLanguage.EditIndex = -1;
        FillgvLanguage();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvLanguage.EditIndex = -1;
        FillgvLanguage();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objblMasterManagement.LanguageMasterDelete(gvLanguage.DataKeys[e.RowIndex].Value.ToString());
        FillgvLanguage();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLanguage.PageIndex = e.NewPageIndex;
        gvLanguage.EditIndex = -1;
        FillgvLanguage();
    }
    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string url = "../Masters/MasterExport.aspx?type=MASTER&eType=mstLanguage";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    #endregion

}
