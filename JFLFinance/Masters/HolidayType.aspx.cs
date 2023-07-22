// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="HolidayType.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_HolidayType
/// </summary>
public partial class Masters_HolidayType : BasePage//System.Web.UI.Page
{
    /// <summary>
    /// The index
    /// </summary>
    static int Index;
    /// <summary>
    /// The index1
    /// </summary>
    static int Index1;

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
            javaScript.Append("PageTitle('" + Resources.Resource.HolidayType + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvHolidayType();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Gridview HolidayType events
    /// <summary>
    /// Fillgvs the type of the holiday.
    /// </summary>
    private void FillgvHolidayType()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt= new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objMastersManagement.HolidayTypeGetAll();
        dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvHolidayType.DataSource = dt;
        gvHolidayType.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvHolidayType.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvHolidayType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvHolidayType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // e.Row.Cells[0].CssClass = "FreezingCol" ;
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvHolidayType.PageIndex * gvHolidayType.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvHolidayType.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (IBEdit != null)
                {
                    IBEdit.Visible = false;
                }

            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtHolidayTypeDesc = (TextBox)e.Row.FindControl("txtHolidayTypeDesc");
                if (txtHolidayTypeDesc != null)
                {
                    txtHolidayTypeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtHolidayTypeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                }
            }
            else
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvHolidayType.ShowFooter = false;
            }
            else
            {
                ImageButton lbAdd = (ImageButton)e.Row.FindControl("lbAdd");
                if (lbAdd != null)
                {
                    lbAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewHolidayTypeCode = (TextBox)e.Row.FindControl("txtNewHolidayTypeCode");
                if (txtNewHolidayTypeCode != null)
                {
                    txtNewHolidayTypeCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewHolidayTypeCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewHolidayTypeDesc = (TextBox)e.Row.FindControl("txtNewHolidayTypeDesc");
                if (txtNewHolidayTypeDesc != null)
                {
                    txtNewHolidayTypeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewHolidayTypeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvHolidayType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvHolidayType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        TextBox txtNewHolidayTypeCode = (TextBox)gvHolidayType.FooterRow.FindControl("txtNewHolidayTypeCode");
        TextBox txtNewHolidayTypeDesc = (TextBox)gvHolidayType.FooterRow.FindControl("txtNewHolidayTypeDesc");
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objMasterManagement.HolidayTypeInsert(txtNewHolidayTypeCode.Text, txtNewHolidayTypeDesc.Text, BaseUserID);
            if (gvHolidayType.Rows.Count.Equals(gvHolidayType.PageSize))
            {
                gvHolidayType.PageIndex = gvHolidayType.PageCount + 1;
            }
            gvHolidayType.EditIndex = -1;
            FillgvHolidayType();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewHolidayTypeCode.Text = "";
            txtNewHolidayTypeDesc.Text = "";
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvHolidayType.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvHolidayType.PageIndex = gvHolidayType.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvHolidayType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvHolidayType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        LinkButton LinkHolidayTypeCode = (LinkButton)gvHolidayType.Rows[e.RowIndex].FindControl("LinkHolidayTypeCode");
        TextBox txtHolidayTypeDesc = (TextBox)gvHolidayType.Rows[e.RowIndex].FindControl("txtHolidayTypeDesc");
        ds = objMasterManagement.HolidayTypeUpdate(LinkHolidayTypeCode.Text, txtHolidayTypeDesc.Text, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        gvHolidayType.EditIndex = -1;
        FillgvHolidayType();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvHolidayType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvHolidayType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        LinkButton LinkHolidayTypeCode = (LinkButton)gvHolidayType.Rows[e.RowIndex].FindControl("LinkHolidayTypeCode");
        ds = objMasterManagement.HolidayTypeDelete(LinkHolidayTypeCode.Text);
        FillgvHolidayType();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvHolidayType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvHolidayType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvHolidayType.EditIndex = e.NewEditIndex;
        FillgvHolidayType();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvHolidayType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvHolidayType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvHolidayType.EditIndex = -1;
        FillgvHolidayType();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvHolidayType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvHolidayType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvHolidayType.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvHolidayType.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvHolidayType.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvHolidayType.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvHolidayType.PageIndex = e.NewPageIndex;
        }
        gvHolidayType.EditIndex = -1;
        FillgvHolidayType();
    }
    /// <summary>
    /// Handles the DataBound event of the gvHolidayType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvHolidayType_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvHolidayType.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvHolidayType.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvHolidayType.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvHolidayType.PageCount.ToString();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvHolidayType.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvHolidayType.PageIndex = ddlPages.SelectedIndex;
        FillgvHolidayType();
    }
    /// <summary>
    /// Handles the Click event of the LinkHolidayTypeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void LinkHolidayTypeCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton LinkHolidayTypeCode = (LinkButton)gvHolidayType.Rows[row.RowIndex].FindControl("LinkHolidayTypeCode");
        Label lblHolidayTypeDesc = (Label)gvHolidayType.Rows[row.RowIndex].FindControl("lblHolidayTypeDesc");
        hfHolidayTypeCode.Value = LinkHolidayTypeCode.Text;
        lblHolidayTypeCodeHeading.Text =Resources.Resource.Holiday.ToString() + " " + Resources.Resource.Of.ToString() + " " + Resources.Resource.HolidayType.ToString() + " " + lblHolidayTypeDesc.Text + " (" +LinkHolidayTypeCode.Text + ")";
        FillgvHoliday();
    }
    #endregion

    #region Gridview Holiday events
    /// <summary>
    /// Fillgvs the holiday.
    /// </summary>
    private void FillgvHoliday()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objMastersManagement.HolidayMasterGetAll(BaseLocationAutoID.ToString(), hfHolidayTypeCode.Value.ToString());
        dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvHoliday.DataSource = dt;
        gvHoliday.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvHoliday.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvHoliday control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvHoliday_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        TextBox txtHolidayCode = (TextBox)gvHoliday.FooterRow.FindControl("txtHolidayCode");
        TextBox txtHolidayDesc = (TextBox)gvHoliday.FooterRow.FindControl("txtHolidayDesc");
        if (e.CommandName.Equals("AddNew"))
        {
            if (hfHolidayTypeCode.Value.ToString() != "")
            {
                ds = objMasterManagement.HolidayMasterAddNew(BaseLocationAutoID, txtHolidayCode.Text, txtHolidayDesc.Text, hfHolidayTypeCode.Value.ToString(), BaseUserID);
                if (gvHoliday.Rows.Count.Equals(gvHoliday.PageSize))
                {
                    gvHoliday.PageIndex = gvHoliday.PageCount + 1;
                }
                gvHoliday.EditIndex = -1;
                FillgvHoliday();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtHolidayCode.Text = "";
            txtHolidayDesc.Text = "";
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvHoliday.PageIndex = 0;
                break;
            case "Prev":
                Index1 = 1;
                break;
            case "Next":
                Index1 = 0;
                break;
            case "Last":
                gvHoliday.PageIndex = gvHoliday.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvHoliday control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvHoliday_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblHolidayCode = (Label)gvHoliday.Rows[e.RowIndex].FindControl("lblHolidayCode");
        TextBox txtHolidayDesc = (TextBox)gvHoliday.Rows[e.RowIndex].FindControl("txtHolidayDesc");
        if (hfHolidayTypeCode.Value.ToString() != "")
        {
            ds = objMasterManagement.HolidayMasterUpdate(BaseLocationAutoID, lblHolidayCode.Text, txtHolidayDesc.Text, hfHolidayTypeCode.Value.ToString(), BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            gvHoliday.EditIndex = -1;
            FillgvHoliday();
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvHoliday control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvHoliday_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblHolidayCode = (Label)gvHoliday.Rows[e.RowIndex].FindControl("lblHolidayCode");
        if (hfHolidayTypeCode.Value.ToString() != "")
        {
            ds = objMasterManagement.HolidayMasterDelete(BaseLocationAutoID, lblHolidayCode.Text, hfHolidayTypeCode.Value.ToString());
            FillgvHoliday();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvHoliday control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvHoliday_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvHoliday.PageIndex * gvHoliday.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvHoliday.Columns[0].Visible = false;
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
                TextBox txtHolidayDesc = (TextBox)e.Row.FindControl("txtHolidayDesc");
                if (txtHolidayDesc != null)
                {
                    txtHolidayDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtHolidayDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
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
                gvHoliday.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtHolidayCode = (TextBox)e.Row.FindControl("txtHolidayCode");
                if (txtHolidayCode != null)
                {
                    txtHolidayCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtHolidayCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtHolidayDesc = (TextBox)e.Row.FindControl("txtHolidayDesc");
                if (txtHolidayDesc != null)
                {
                    txtHolidayDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtHolidayDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvHoliday control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvHoliday_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvHoliday.EditIndex = e.NewEditIndex;
        FillgvHoliday();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvHoliday control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvHoliday_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvHoliday.EditIndex = -1;
        FillgvHoliday();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvHoliday control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvHoliday_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvHoliday.BottomPagerRow;
        DropDownList ddlPages1 = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages1");
        int CurrentIndex = int.Parse(ddlPages1.SelectedItem.Text) - 1;
        if (Index1 == 1)
        {
            if (CurrentIndex > 0)
            {
                gvHoliday.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvHoliday.PageIndex = CurrentIndex;
            }
            Index1 = -1;
        }
        else if (Index1 == 0)
        {
            gvHoliday.PageIndex = CurrentIndex + 1;
            Index1 = -1;
        }
        else
        {
            gvHoliday.PageIndex = e.NewPageIndex;
        }
        gvHoliday.EditIndex = -1;
        FillgvHoliday();
    }
    /// <summary>
    /// Handles the DataBound event of the gvHoliday control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvHoliday_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvHoliday.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages1 = (DropDownList)row.Cells[0].FindControl("ddlPages1");
        Label lblPageCount1 = (Label)row.Cells[0].FindControl("lblPageCount1");
        if (ddlPages1 != null)
        {
            for (int i = 0; i < gvHoliday.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvHoliday.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages1.Items.Add(lstItem);
            }
        }
        if (lblPageCount1 != null)
        {
            lblPageCount1.Text = gvHoliday.PageCount.ToString();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvHoliday.BottomPagerRow;
        DropDownList ddlPages1 = (DropDownList)row.Cells[0].FindControl("ddlPages1");
        gvHoliday.PageIndex = ddlPages1.SelectedIndex;
        FillgvHoliday();
    }
    #endregion
    
}
