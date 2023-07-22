// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="ZipMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_ZipMaster
/// </summary>
public partial class Masters_ZipMaster : BasePage
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

    #region PageLoad
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ZipMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillgvGroupZip();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion PageLoad

    #region Data Binding
    /// <summary>
    /// Fillgvs the group zip.
    /// </summary>
    protected void FillgvGroupZip()
    {
        var objMm = new BL.MastersManagement();
        int dtflag;
        dtflag = 1;
        DataSet ds = objMm.ZipCodeGroupGet(BaseLocationAutoID);
        DataTable dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvGroupZip.DataKeyNames = new string[] { "LocationAutoId", "GroupZipCode" };
        gvGroupZip.DataSource = dt;
        gvGroupZip.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvGroupZip.Rows[0].Visible = false;
        }

        FillgvZip();
    }
    /// <summary>
    /// Fillgvs the zip.
    /// </summary>
    protected void FillgvZip()
    {
        var objMm = new BL.MastersManagement();
        int dtflag;
        dtflag = 1;
        DataSet ds = objMm.ZipCodeGet(BaseLocationAutoID, hfglobalGroupZipCode.Value.ToString());
        DataTable dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvZip.DataKeyNames = new string[] { "LocationAutoId", "GroupZipCode", "ZipCode" };
        gvZip.DataSource = dt;
        gvZip.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvZip.Rows[0].Visible = false;
        }
        if(hfglobalGroupZipCode.Value == "")
        {
            gvZip.FooterRow.Visible = false;
        }
        else
        {
            gvZip.FooterRow.Visible = true;
        }
    }
    #endregion

    #region GridView GroupZip Master Events
    /// <summary>
    /// Handles the RowDataBound event of the gvGroupZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvGroupZip_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvGroupZip.PageIndex * gvGroupZip.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvGroupZip.Columns[3].Visible = false;
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
            var txtGroupZipDesc = (TextBox)e.Row.FindControl("txtGroupZipDesc");
            if (txtGroupZipDesc != null)
            {
                txtGroupZipDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtGroupZipDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }
            
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            if (IsWriteAccess == false)
            {
                gvGroupZip.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                var txtGroupZipCode = (TextBox)e.Row.FindControl("txtGroupZipCode");
                if (txtGroupZipCode != null)
                {
                    txtGroupZipCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtGroupZipCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                var txtGroupZipDesc = (TextBox)e.Row.FindControl("txtGroupZipDesc");
                if (txtGroupZipDesc != null)
                {
                    txtGroupZipDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtGroupZipDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvGroupZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvGroupZip_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objMm = new BL.MastersManagement();

        var txtGroupZipCode = (TextBox)gvGroupZip.FooterRow.FindControl("txtGroupZipCode");
        var txtGroupZipDesc = (TextBox)gvGroupZip.FooterRow.FindControl("txtGroupZipDesc");
        if (e.CommandName.Equals("AddNew"))
        {
            DataSet ds = objMm.ZipCodeGroupAdd(BaseLocationAutoID, txtGroupZipCode.Text, txtGroupZipDesc.Text, BaseUserID);
            if (gvGroupZip.Rows.Count.Equals(gvGroupZip.PageSize))
            {
                gvGroupZip.PageIndex = gvGroupZip.PageCount + 1;
            }
            gvGroupZip.EditIndex = -1;
            FillgvGroupZip();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtGroupZipCode.Text = "";
            txtGroupZipDesc.Text = "";
            lblErrorMsg.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvGroupZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvGroupZip_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGroupZip.EditIndex = e.NewEditIndex;
        FillgvGroupZip();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvGroupZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvGroupZip_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objMm = new BL.MastersManagement();

        var lblGroupZipCode = (LinkButton)gvGroupZip.Rows[e.RowIndex].FindControl("lblGroupZipCode");
        var txtGroupZipDesc = (TextBox)gvGroupZip.Rows[e.RowIndex].FindControl("txtGroupZipDesc");

        DataSet ds = objMm.ZipCodeGroupUpdate(BaseLocationAutoID, lblGroupZipCode.Text, txtGroupZipDesc.Text, BaseUserID);

        gvGroupZip.EditIndex = -1;
        FillgvGroupZip();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvGroupZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvGroupZip_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGroupZip.EditIndex = -1;
        FillgvGroupZip();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvGroupZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvGroupZip_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objMm = new BL.MastersManagement();
        var lblGroupZipCode = (LinkButton)gvGroupZip.Rows[e.RowIndex].FindControl("lblGroupZipCode");

        DataSet ds = objMm.ZipCodeGroupDelete(BaseLocationAutoID, lblGroupZipCode.Text);
        FillgvGroupZip();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvGroupZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvGroupZip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGroupZip.PageIndex = e.NewPageIndex;
        gvGroupZip.EditIndex = -1;
        FillgvGroupZip();
    }

    /// <summary>
    /// Handles the Click event of the lblGroupZipCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblGroupZipCode_Click(object sender, EventArgs e)
    {
        LinkButton lblGroupZipCode = (LinkButton)sender;
        hfglobalGroupZipCode.Value = lblGroupZipCode.Text;
        gvGroupZip.EditIndex = -1;
        FillgvZip();
    }
    #endregion

    #region GridView Zip Master Events
    /// <summary>
    /// Handles the RowDataBound event of the gvZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvZip_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvZip.PageIndex * gvZip.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvZip.Columns[4].Visible = false;
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
            var txtZipDesc = (TextBox)e.Row.FindControl("txtZipDesc");
            if (txtZipDesc != null)
            {
                txtZipDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtZipDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            if (IsWriteAccess == false)
            {
                gvZip.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                var txtZipCode = (TextBox)e.Row.FindControl("txtZipCode");
                if (txtZipCode != null)
                {
                    txtZipCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtZipCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                var txtZipDesc = (TextBox)e.Row.FindControl("txtZipDesc");
                if (txtZipDesc != null)
                {
                    txtZipDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtZipDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvZip_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objMm = new BL.MastersManagement();

        
        var txtZipCode = (TextBox)gvZip.FooterRow.FindControl("txtZipCode");
        var txtZipDesc = (TextBox)gvZip.FooterRow.FindControl("txtZipDesc");
        if (e.CommandName.Equals("AddNew"))
        {
            if (hfglobalGroupZipCode.Value.ToString() != "")
            {
                DataSet ds = objMm.ZipCodeAdd(BaseLocationAutoID, hfglobalGroupZipCode.Value.ToString(),
                                                              txtZipCode.Text, txtZipDesc.Text, BaseUserID);
                if (gvZip.Rows.Count.Equals(gvZip.PageSize))
                {
                    gvZip.PageIndex = gvZip.PageCount + 1;
                }
                gvZip.EditIndex = -1;
                FillgvZip();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtZipCode.Text = "";
            txtZipDesc.Text = "";
            lblErrorMsg.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvZip_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvZip.EditIndex = e.NewEditIndex;
        FillgvZip();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvZip_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objMm = new BL.MastersManagement();

        var lblGroupZipCode = (Label)gvZip.Rows[e.RowIndex].FindControl("lblGroupZipCode");
        var lblZipCode = (Label)gvZip.Rows[e.RowIndex].FindControl("lblZipCode");
        var txtZipDesc = (TextBox)gvZip.Rows[e.RowIndex].FindControl("txtZipDesc");

        DataSet ds = objMm.ZipCodeUpdate(BaseLocationAutoID, lblGroupZipCode.Text, lblZipCode.Text, txtZipDesc.Text, BaseUserID);

        gvZip.EditIndex = -1;
        FillgvZip();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvZip_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvZip.EditIndex = -1;
        FillgvZip();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvZip_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objMm = new BL.MastersManagement();
        var lblGroupZipCode = (Label)gvZip.Rows[e.RowIndex].FindControl("lblGroupZipCode");
        var lblZipCode = (Label)gvZip.Rows[e.RowIndex].FindControl("lblZipCode");

        DataSet ds = objMm.ZipCodeDelete(BaseLocationAutoID, lblGroupZipCode.Text, lblZipCode.Text);
        FillgvZip();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvZip control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvZip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvZip.PageIndex = e.NewPageIndex;
        gvZip.EditIndex = -1;
        FillgvZip();
    }
    #endregion
}