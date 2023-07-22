// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="SiteInstructionForIndustry.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_SiteInstructionForIndustry
/// </summary>
public partial class Masters_SiteInstructionForIndustry : BasePage
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

    #region Page Load Event
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
            javaScript.Append("PageTitle('" + Resources.Resource.SiteInstructionForIndustry + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillIndustryType();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            if (ddlIndustryType.Text != "")
            {
                FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
            }
            else
            {
                ListItem LI = new ListItem();
                LI.Text = Resources.Resource.NoDataToShow;
                LI.Value = "-1";
                ddlIndustryType.Items.Add(LI);
            }
        }
    }
    #endregion

    #region function to fill Industry Type Master
    /// <summary>
    /// Fills the type of the industry.
    /// </summary>
    private void FillIndustryType()
    {

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ddlIndustryType.DataSource = objMastersManagement.IndustryTypeMasterGet(BaseCompanyCode);
        ddlIndustryType.DataTextField = "ItemDesc";
        ddlIndustryType.DataValueField = "ItemDesc";
        ddlIndustryType.DataBind();
        if (ddlIndustryType == null)
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlIndustryType.Items.Add(li);
        }
        else
        {
            //EnableButton();
        }
    }
    #endregion

    #region Function To fill Site Instruction for Industry
    /// <summary>
    /// Fillgvs the site instruction for industry.
    /// </summary>
    /// <param name="strIndustryTypeID">The STR industry type ID.</param>
    private void FillgvSiteInstructionForIndustry(string strIndustryTypeID)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtSiteInstruction = new DataTable();
        ds = objMaster.SiteInstructionGetAll(strIndustryTypeID, BaseCompanyCode);

        //Cache.Insert("myCache", ds);
        //gvQuickCodeType.DataSource =(DataSet)Cache["myCache"];
        //gvQuickCodeType.DataBind();

        dtSiteInstruction = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtSiteInstruction.Rows.Count > 0)
        {
            gvSiteInstruction.DataSource = dtSiteInstruction;
            gvSiteInstruction.DataBind();
        }
        else
        {
            dtSiteInstruction.Rows.Add(dtSiteInstruction.NewRow());
            gvSiteInstruction.DataSource = dtSiteInstruction;
            gvSiteInstruction.DataBind();
            int TotalColumns = gvSiteInstruction.Rows[0].Cells.Count;
            gvSiteInstruction.Rows[0].Cells.Clear();
            gvSiteInstruction.Rows[0].Cells.Add(new TableCell());
            gvSiteInstruction.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvSiteInstruction.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    #endregion

    #region Grid View Site Instruction Type Events
    /// <summary>
    /// Handles the RowDataBound event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        BL.Misc objMisc = new BL.Misc();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DropDownList ddlInstructionType = (DropDownList)e.Row.FindControl("ddlInstructionType");
        HiddenField hfInstructionType = (HiddenField)e.Row.FindControl("hfInstructionType");
        DataSet ds = new DataSet();
        DataSet dsEnableDisable = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvSiteInstruction.PageIndex * gvSiteInstruction.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvSiteInstruction.Columns[0].Visible = false;
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
                TextBox txtSiteInstruction = (TextBox)e.Row.FindControl("txtSiteInstruction");
                if (txtSiteInstruction != null)
                {
                    txtSiteInstruction.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtSiteInstruction.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (ddlInstructionType != null)
                {
                    ddlInstructionType.DataSource = objMastersManagement.InstructionTypeGetAll(BaseCompanyCode);
                    //Modified by  on 26-July-2013
                    //ddlInstructionType.DataValueField = "ItemDesc";
                    ddlInstructionType.DataValueField = "ItemCode";
                    ddlInstructionType.DataTextField = "ItemDesc";
                    ddlInstructionType.SelectedValue = hfInstructionType.Value;
                    ddlInstructionType.DataBind();
                }
            }

            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteSiteInstruction = (ImageButton)e.Row.FindControl("IBDeleteSiteInstruction");
                if (IBDeleteSiteInstruction != null)
                {
                    IBDeleteSiteInstruction.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteSiteInstruction = (ImageButton)e.Row.FindControl("IBDeleteSiteInstruction");
                if (IBDeleteSiteInstruction != null)
                {
                    IBDeleteSiteInstruction.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvSiteInstruction.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewSiteInstruction = (TextBox)e.Row.FindControl("txtNewSiteInstruction");
                if (txtNewSiteInstruction != null)
                {
                    txtNewSiteInstruction.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewSiteInstruction.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (ddlInstructionType != null)
            {
                ddlInstructionType.DataSource = objMastersManagement.InstructionTypeGetAll(BaseCompanyCode);
                ddlInstructionType.DataValueField = "ItemCode";
                ddlInstructionType.DataTextField = "ItemDesc";
                ddlInstructionType.DataBind();
            }

        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DropDownList ddlInstructionType = (DropDownList)gvSiteInstruction.FooterRow.FindControl("ddlInstructionType");

        string IndustryTypeID;
        string InstructionTypeID;
        TextBox txtNewSiteInstruction = (TextBox)gvSiteInstruction.FooterRow.FindControl("txtNewSiteInstruction");

        if (e.CommandName.Equals("AddNew"))
        {
            if (ddlIndustryType.SelectedItem.Value.ToString() != "" && ddlInstructionType.SelectedItem.Value.ToString() != "")
            {
                IndustryTypeID = ddlIndustryType.SelectedItem.Value.ToString();
                InstructionTypeID = ddlInstructionType.SelectedValue.ToString();
                ds = objMastersManagement.SiteInstructionForIndustryInsert(InstructionTypeID, IndustryTypeID, txtNewSiteInstruction.Text.ToString(), BaseCompanyCode, BaseUserID); // True Value is for Status ,Status=true means QuickCode is active status=false means QuickCode is not active
                FillgvSiteInstructionForIndustry(IndustryTypeID);
                if (gvSiteInstruction.Rows.Count.Equals(gvSiteInstruction.PageSize))
                {
                    gvSiteInstruction.PageIndex = gvSiteInstruction.PageCount + 1;
                }
                gvSiteInstruction.EditIndex = -1;
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewSiteInstruction.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvSiteInstruction.EditIndex = e.NewEditIndex;
        FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string InstructionTypeID;
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DropDownList ddlInstructionType = (DropDownList)gvSiteInstruction.Rows[e.RowIndex].FindControl("ddlInstructionType");

        Label lblRowID  = (Label)gvSiteInstruction.Rows[e.RowIndex].FindControl("lblRowID");
        TextBox txtSiteInstruction = (TextBox)gvSiteInstruction.Rows[e.RowIndex].FindControl("txtSiteInstruction");
        if (ddlInstructionType.SelectedValue.ToString() == "")
        {

            InstructionTypeID = "0";
        }
        else
        {
            InstructionTypeID = ddlInstructionType.SelectedValue.ToString();

        }
        ds = objMastersManagement.SiteInstructionForIndustryUpdate(int.Parse(lblRowID.Text.ToString()), InstructionTypeID, ddlIndustryType.SelectedValue.ToString(), txtSiteInstruction.Text, BaseCompanyCode, BaseUserID);
        gvSiteInstruction.EditIndex = -1;
        FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        Label lblRowID = (Label)gvSiteInstruction.Rows[e.RowIndex].FindControl("lblRowID");
        ds = objMastersManagement.SiteInstructionForIndustryDelete(int.Parse(lblRowID.Text.ToString()), BaseUserID);
        FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSiteInstruction.EditIndex = -1;
        FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSiteInstruction.PageIndex = e.NewPageIndex;
        gvSiteInstruction.EditIndex = -1;
        FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
    }

    /// <summary>
    /// Gets or sets the grid view sort direction.
    /// </summary>
    /// <value>The grid view sort direction.</value>
    public SortDirection GridViewSortDirection
    {
        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }

    }
    /// <summary>
    /// Sorts the grid view.
    /// </summary>
    /// <param name="sortExpression">The sort expression.</param>
    /// <param name="direction">The direction.</param>
    /// <param name="dv">The dv.</param>
    /// <param name="strGridViewName">Name of the STR grid view.</param>
    private void SortGridView(string sortExpression, string direction, DataView dv, GridView strGridViewName)
    {
        dv.Sort = sortExpression + ' ' + direction;
        strGridViewName.DataSource = dv;
        strGridViewName.DataBind();

    }

    /// <summary>
    /// Handles the Sorting event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataView dv = new DataView(objMastersManagement.SiteInstructionGetAll(ddlIndustryType.SelectedValue.ToString(), BaseCompanyCode).Tables[0]);
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESC", dv, gvSiteInstruction);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASC", dv, gvSiteInstruction);
        }
    }

    #endregion
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlIndustryType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlIndustryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIndustryType.Text != "")
        {
            FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
        }
        else
        {
            ListItem LI = new ListItem();
            LI.Text = Resources.Resource.NoDataToShow;
            LI.Value = "-1";
            ddlIndustryType.Items.Add(LI);
        }
    }


}
