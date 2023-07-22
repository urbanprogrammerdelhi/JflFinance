// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Location.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Location
/// </summary>
public partial class Masters_Location : BasePage //System.Web.UI.Page
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
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Page_PreInit(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(BaseLocationAutoID))
        {
            this.MasterPageFile = "~/MasterPage/MasterPage.master";
        }
        else
        {
            this.MasterPageFile = "~/MasterPage/MasterHeader.master";
        }
    }
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
            javaScript.Append("PageTitle('" + Resources.Resource.Location + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (string.IsNullOrEmpty(BaseLocationAutoID) && BaseIsAdmin == "SA")
            { imgBack.Visible = true; }
            else
            { imgBack.Visible = false; }

            if (IsReadAccess == true)
            {
                FillgvLocation();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Controles Binding
    /// <summary>
    /// Fillddls the company.
    /// </summary>
    protected void FillddlCompany()
    {
        DataSet dsCompany = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        if (BaseIsAdmin != "SA")
        { dsCompany = objMastersManagement.CompanyDescriptionGetAll(BaseCompanyCode, BaseIsAdmin); }
        else
        { dsCompany = objMastersManagement.CompanyDescriptionGetAll(); }

        DropDownList ddlCompany = (DropDownList)gvLocation.FooterRow.FindControl("ddlCompany");
        Label lblgvCompanyCode = (Label)gvLocation.FooterRow.FindControl("lblgvCompanyCode");

        ddlCompany.DataSource = dsCompany.Tables[0];
        ddlCompany.DataValueField = "CompanyCode";
        ddlCompany.DataTextField = "CompanyDesc";
        ddlCompany.DataBind();
        ddlCompany.AutoPostBack = true;
        lblgvCompanyCode.Text = ddlCompany.SelectedItem.Value.ToString();
        FillddlHrLocation();
    }

    /// <summary>
    /// Fillddls the hr location.
    /// </summary>
    protected void FillddlHrLocation()
    {
        DataSet dsHrLocation = new DataSet();
        string strCompanyCode;
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();

        DropDownList ddlCompanyCode = (DropDownList)gvLocation.FooterRow.FindControl("ddlCompany");
        strCompanyCode = ddlCompanyCode.SelectedItem.Value.ToString();
        dsHrLocation = objMastersManagement.HRLocationDescriptionGetAll(strCompanyCode);

        DropDownList ddlHrLocation = (DropDownList)gvLocation.FooterRow.FindControl("ddlHrLocation");
        Label lblgvHrLocationCode = (Label)gvLocation.FooterRow.FindControl("lblgvHrLocationCode");

        ddlHrLocation.Items.Clear();
        if (dsHrLocation.Tables[0].Rows.Count > 0)
        {
            ddlHrLocation.DataSource = dsHrLocation.Tables[0];
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = "No HrLocation";
            ddlHrLocation.Items.Add(li);
        }
        ddlHrLocation.DataValueField = "HrLocationCode";
        ddlHrLocation.DataTextField = "hrLocationDesc";
        ddlHrLocation.DataBind();
        ddlHrLocation.AutoPostBack = true;
        lblgvHrLocationCode.Text = ddlHrLocation.SelectedItem.Value.ToString();
    }

    /// <summary>
    /// Fillgvs the location.
    /// </summary>
    protected void FillgvLocation()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsLocation = new DataSet();
        DataTable dtLocation = new DataTable();
        int dtflag;
        dtflag = 1;
        if (BaseIsAdmin != "SA")
        { dsLocation = objMastersManagement.LocationGetAll(BaseCompanyCode, BaseHrLocationCode, BaseIsAdmin,BaseUserID); }
        else
        { dsLocation = objMastersManagement.LocationGetAll(); }

        dtLocation = dsLocation.Tables[0];

        //to fix empety gridview
        if (dtLocation.Rows.Count == 0)
        {
            dtflag = 0;
            dtLocation.Rows.Add(dtLocation.NewRow());
        }
        gvLocation.DataKeyNames = new string[] { "LocationAutoId" };
        gvLocation.DataSource = dtLocation;
        gvLocation.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvLocation.Rows[0].Visible = false;
        }
        FillddlCompany();
    }

    #endregion

    #region GridView Commands Events

    /// <summary>
    /// Handles the RowDataBound event of the gvLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvLocation.PageIndex * gvLocation.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvLocation.Columns[8].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtLocationDesc = (TextBox)e.Row.FindControl("txtLocationDesc");
                if (txtLocationDesc != null)
                {
                    txtLocationDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtLocationDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtLocationAddress = (TextBox)e.Row.FindControl("txtLocationAddress");
                if (txtLocationAddress != null)
                {
                    txtLocationAddress.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtLocationAddress.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');"; }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvLocation.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtLocationCode = (TextBox)e.Row.FindControl("txtLocationCode");
                if (txtLocationCode != null)
                {
                    txtLocationCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtLocationCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtLocationDesc = (TextBox)e.Row.FindControl("txtLocationDesc");
                if (txtLocationDesc != null)
                {
                    txtLocationDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtLocationDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtLocationAddress = (TextBox)e.Row.FindControl("txtLocationAddress");
                if (txtLocationAddress != null)
                {
                    txtLocationAddress.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtLocationAddress.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        // To Insert a New Row
        DropDownList ddlCompany = (DropDownList)gvLocation.FooterRow.FindControl("ddlCompany");
        DropDownList ddlHrLocation = (DropDownList)gvLocation.FooterRow.FindControl("ddlHrLocation");
        TextBox txtLocationCode = (TextBox)gvLocation.FooterRow.FindControl("txtLocationCode");
        TextBox txtLocationDesc = (TextBox)gvLocation.FooterRow.FindControl("txtLocationDesc");
        TextBox txtLocationAddress = (TextBox)gvLocation.FooterRow.FindControl("txtLocationAddress");
        if (e.CommandName == "Add")
        {
            if (ddlCompany.SelectedItem.Value.ToString() != "" && ddlHrLocation.SelectedItem.Value.ToString() != "")
            {
                ds = objMastersManagement.LocationAddNew(ddlCompany.SelectedItem.Value.ToString(), ddlHrLocation.SelectedItem.Value.ToString(), txtLocationCode.Text, txtLocationDesc.Text, txtLocationAddress.Text, BaseUserID.ToString());
                gvLocation.EditIndex = -1;
                FillgvLocation();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
        }
        if (e.CommandName == "Reset")
        {
            txtLocationCode.Text = "";
            txtLocationDesc.Text = "";
            txtLocationAddress.Text = "";
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the gvLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvLocation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvLocation.EditIndex = e.NewEditIndex;
        FillddlCompany();
        FillddlHrLocation();
        FillgvLocation();
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvLocation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvLocation.EditIndex = -1;
        FillddlCompany();
        FillddlHrLocation();
        FillgvLocation();
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvLocation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvCompanyCode = (Label)gvLocation.Rows[e.RowIndex].FindControl("lblgvCompanyCode");
        Label lblgvHrLocationCode = (Label)gvLocation.Rows[e.RowIndex].FindControl("lblgvHrLocationCode");
        Label lblgvLocationCode = (Label)gvLocation.Rows[e.RowIndex].FindControl("lblgvLocationCode");
        TextBox txtLocationDesc = (TextBox)gvLocation.Rows[e.RowIndex].FindControl("txtLocationDesc");
        TextBox txtLocationAddress = (TextBox)gvLocation.Rows[e.RowIndex].FindControl("txtLocationAddress");

        ds = objMastersManagement.LocationUpdate(lblgvCompanyCode.Text, lblgvHrLocationCode.Text, lblgvLocationCode.Text, txtLocationDesc.Text, txtLocationAddress.Text, BaseUserID.ToString());
        gvLocation.EditIndex = -1;
        FillddlCompany();
        FillddlHrLocation();
        FillgvLocation();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvLocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvCompanyCode = (Label)gvLocation.Rows[e.RowIndex].FindControl("lblgvCompanyCode");
        Label lblgvHrLocationCode = (Label)gvLocation.Rows[e.RowIndex].FindControl("lblgvHrLocationCode");
        Label lblgvLocationCode = (Label)gvLocation.Rows[e.RowIndex].FindControl("lblgvLocationCode");
        ds = objMastersManagement.LocationDelete(lblgvCompanyCode.Text, lblgvHrLocationCode.Text, lblgvLocationCode.Text);
        FillddlCompany();
        FillddlHrLocation();
        FillgvLocation();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLocation.PageIndex = e.NewPageIndex;
        gvLocation.EditIndex = -1;
        FillddlCompany();
        FillddlHrLocation();
        FillgvLocation();
    }

    #endregion

    #region Controles Command Events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlCompany = (DropDownList)gvLocation.FooterRow.FindControl("ddlCompany");
        Label lblgvCompanyCode = (Label)gvLocation.FooterRow.FindControl("lblgvCompanyCode");
        lblgvCompanyCode.Text = ddlCompany.SelectedItem.Value.ToString();
        FillddlHrLocation();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlHrLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlHrLocation = (DropDownList)gvLocation.FooterRow.FindControl("ddlHrLocation");
        Label lblgvHrLocationCode = (Label)gvLocation.FooterRow.FindControl("lblgvHrLocationCode");
        lblgvHrLocationCode.Text = ddlHrLocation.SelectedItem.Value.ToString();
    }
    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MasterMenu.aspx");
    }
    #endregion

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        
        base.OnInit(e);
    }

}
