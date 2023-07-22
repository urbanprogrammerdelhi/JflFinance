// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CountryMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_CountryMaster
/// </summary>
public partial class Masters_CountryMaster : BasePage // System.Web.UI.Page
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
    /// The index
    /// </summary>
    static int Index;

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
            javaScript.Append("PageTitle('" + Resources.Resource.Country + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvCountry();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region GridView Functions 
    /// <summary>
    /// Fillgvs the country.
    /// </summary>
    private void FillgvCountry()
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet dsCountry = new DataSet();
        DataTable dtCountry = new DataTable();

        dsCountry = objMasterManagement.CountryMasterGetAll(BaseCompanyCode) ;
        if (dsCountry != null && dsCountry.Tables.Count > 0 && dsCountry.Tables[0].Rows.Count > 0)
        {
            gvCountry.DataSource = dsCountry;
            gvCountry.DataBind();
        }
        else
        {
            dtCountry = dsCountry.Tables[0];
            dtCountry.Rows.Add(dtCountry.NewRow());
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
            gvCountry.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the rowEditing event of the gvCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvCountry_rowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCountry.EditIndex = e.NewEditIndex;
        FillgvCountry();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvCountry_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtCountryDesc = (TextBox)gvCountry.Rows[e.RowIndex].FindControl("txtCountryDesc");
        Label lblgvCountryCode = (Label)gvCountry.Rows[e.RowIndex].FindControl("lblgvCountryCode");

        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.CountryMasterUpdate(lblgvCountryCode.Text, txtCountryDesc.Text,BaseCompanyCode, BaseUserID);
        gvCountry.EditIndex = -1;
        FillgvCountry();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Add New")
        {
            string strCompanyCode, strUserId;
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();
            DataSet ds = new DataSet();
            TextBox txtCountryCode = (TextBox)gvCountry.FooterRow.FindControl("txtCountryCode");
            TextBox txtNewCountryDesc = (TextBox)gvCountry.FooterRow.FindControl("txtNewCountryDesc");
            strUserId = BaseUserID;
            ds = objMasterManagement.CountryMasterAddNew(txtCountryCode.Text, txtNewCountryDesc.Text,BaseCompanyCode,BaseUserID);
            FillgvCountry();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvCountry.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvCountry.PageIndex = gvCountry.PageCount;
                break;
        }


    }
    /// <summary>
    /// Handles the RowDeleting event of the gvCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvCountry_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblgvCountryCode = (Label)gvCountry.Rows[e.RowIndex].FindControl("lblgvCountryCode");
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.CountryMasterDelete(lblgvCountryCode.Text,BaseCompanyCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvCountry();
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvCountry.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvCountry.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvCountry.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvCountry.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvCountry.PageIndex = e.NewPageIndex;
        }
        gvCountry.EditIndex = -1;
        FillgvCountry();
    }
    /// <summary>
    /// Handles the DataBound event of the gvCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvCountry_DataBound(object sender, EventArgs e)
    {
        //GridViewRow row = gvCountry.BottomPagerRow;
        //if (row == null)
        //{
        //    return;
        //}
        //DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        //Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        //if (ddlPages != null)
        //{
        //    for (int i = 0; i < gvCountry.PageCount; i++)
        //    {
        //        int intPageNumber = i + 1;
        //        ListItem lstItem = new ListItem(intPageNumber.ToString());
        //        if (i == gvCountry.PageIndex)
        //        {
        //            lstItem.Selected = true;
        //        }
        //        ddlPages.Items.Add(lstItem);
        //    }
        //}
        //if (lblPageCount != null)
        //{
        //    lblPageCount.Text = gvCountry.PageCount.ToString();
        //}

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvCountry.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvCountry.PageIndex = ddlPages.SelectedIndex;
        FillgvCountry();
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {

        TextBox txtCountryCode = (TextBox)gvCountry.FooterRow.FindControl("txtCountryCode");
        TextBox txtNewCountryDesc = (TextBox)gvCountry.FooterRow.FindControl("txtNewCountryDesc");

        txtCountryCode.Text = "";
        txtNewCountryDesc.Text = "";

    }
    /// <summary>
    /// Handles the Click event of the lnkBtnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkBtnCancel_Click(object sender, EventArgs e)
    {
        gvCountry.EditIndex = -1;
        FillgvCountry();
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvCountry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCountry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvCountry.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

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
            TextBox txtCountryDesc = (TextBox)e.Row.FindControl("txtCountryDesc");
            if (txtCountryDesc != null)
            {
                txtCountryDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtCountryDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
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
                gvCountry.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox TxtCountryCode = (TextBox)e.Row.FindControl("TxtCountryCode");
                if (TxtCountryCode != null)
                {
                    TxtCountryCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    TxtCountryCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewCountryDesc = (TextBox)e.Row.FindControl("txtNewCountryDesc");
                if (txtNewCountryDesc != null)
                {
                    txtNewCountryDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewCountryDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }


    }

    #endregion
}
