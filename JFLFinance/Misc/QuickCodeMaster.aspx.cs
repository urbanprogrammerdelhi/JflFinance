// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="QuickCodeMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Linq;
/// <summary>
/// Class Misc_QuickCodeMaster
/// </summary>
public partial class Misc_QuickCodeMaster : BasePage//System.Web.UI.Page
{

    /// <summary>
    /// The index
    /// </summary>
    static int Index;


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
            //Code added by  on 14 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.QuickCodeMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            FillddlSearch();

            if (IsReadAccess == true)
            {
                FillgvQuickCodeType();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    private void FillddlSearch()
    {
        ListItem li = new ListItem(Resources.Resource.QuickCode, "QuickCode");
        ddlSearch.Items.Add(li);
        li = new ListItem(Resources.Resource.QuickCodeDescription, "QuickCodeDesc");
        ddlSearch.Items.Add(li);
        AutoCompleteExtender1.UseContextKey = true;
        AutoCompleteExtender1.ContextKey = ddlSearch.SelectedItem.Value;
    }
    protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        AutoCompleteExtender1.UseContextKey = true;
        AutoCompleteExtender1.ContextKey = ddlSearch.SelectedItem.Value;
    }

    [WebMethod]
    public static List<string> Search(string prefixText, int count, string contextKey)
    {


        string FieldName = contextKey; // "QuickCode";
        BL.Misc objMisc = new BL.Misc();
        DataSet ds = new DataSet();
        DataTable dtSearch = new DataTable();
        ds = objMisc.QuickCodeTypeGetAll();
        dtSearch = ds.Tables[0];
        List<string> item = new List<string>();
        if (ds != null && ds.Tables.Count > 0 && dtSearch.Rows.Count > 0)
        {
            if ((from s in dtSearch.AsEnumerable() where s.Field<string>(FieldName).ToLower().Contains(prefixText.ToLower()) select s).Count() > 0)
            {
                DataTable dtfilter = (from s in dtSearch.AsEnumerable() where s.Field<string>(FieldName).ToLower().Contains(prefixText.ToLower()) select s).CopyToDataTable();
                //item = dtfilter.AsEnumerable().Select(a => a.Field<string>(FieldName)).ToList();
            }
        }
        return item;
    }
    #endregion


    #region Grid View Quick Code Type Events
    #region function to fill Quick Code Type Master
    /// <summary>
    /// Fillgvs the type of the quick code.
    /// </summary>
    private void FillgvQuickCodeType()
    {
        rdbAll.Checked = true;
        BL.Misc objMisc = new BL.Misc();
        DataSet ds = new DataSet();
        DataTable dtQuickCodeType = new DataTable();
        ds = objMisc.QuickCodeTypeGetAll();
        dtQuickCodeType = ds.Tables[0];

        if (ds != null && ds.Tables.Count > 0 && dtQuickCodeType.Rows.Count > 0)
        {
            DataView dv = new DataView(dtQuickCodeType);
            if (txtSearch.Text != string.Empty)
            {
                dv.RowFilter = ddlSearch.SelectedItem.Value + "='" + txtSearch.Text + "'";
                txtSearch.Text = string.Empty;
            }
            gvQuickCodeType.DataSource = dv;
            gvQuickCodeType.DataBind();

            hfQuickCode.Value = ds.Tables[0].Rows[0]["QuickCode"].ToString();
            if (hfQuickCode.Value != string.Empty)
            {
                FillgvQuickCodeMaster(hfQuickCode.Value);
                PanelQuickCodeMaster.Visible = true;
            }
        }
        else
        {
            dtQuickCodeType.Rows.Add(dtQuickCodeType.NewRow());
            gvQuickCodeType.DataSource = dtQuickCodeType;
            gvQuickCodeType.DataBind();
            gvQuickCodeType.Rows[0].Visible = false;
            rdbAll.Visible = false;
            rdbMapped.Visible = false;
            rdbUnMapped.Visible = false;
        }

    }

    #endregion

    /// <summary>
    /// Handles the RowDataBound event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        BL.Misc objMisc = new BL.Misc();
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvQuickCodeType.PageIndex * gvQuickCodeType.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            DropDownList ddlParentQuickCode = (DropDownList)e.Row.FindControl("ddlParentQuickCode");
            HiddenField hiddenFieldParentQuickCode = (HiddenField)e.Row.FindControl("hiddenFieldParentQuickCode");
            Label lblQuickCode = (Label)e.Row.FindControl("lblQuickCode");

            TextBox txtQuickCodeDesc = (TextBox)e.Row.FindControl("txtQuickCodeDesc");
            if (txtQuickCodeDesc != null)
            {
                txtQuickCodeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtQuickCodeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }
            ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
            if (ImgbtnUpdate != null)
            {
                ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
            }
            ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
            if (ImgbtnDelete != null)
            {
                ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
            }

            if (ddlParentQuickCode != null)
            {
                ds = objMisc.QuickCodeTypeParentIdGet(lblQuickCode.Text);
                ddlParentQuickCode.DataSource = ds.Tables[0];
                ddlParentQuickCode.DataTextField = "QuickCodeDesc";
                ddlParentQuickCode.DataValueField = "QuickCode";
                ddlParentQuickCode.DataBind();

                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoParent;
                li.Value = "";
                ddlParentQuickCode.Items.Insert(0, li);

                ddlParentQuickCode.SelectedValue = hiddenFieldParentQuickCode.Value.ToString();
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtQuickCode = (TextBox)e.Row.FindControl("txtQuickCode");
            TextBox txtQuickCodeDesc = (TextBox)e.Row.FindControl("txtQuickCodeDesc");
            DropDownList ddlParentQuickCode = (DropDownList)e.Row.FindControl("ddlParentQuickCode");
            ImageButton Imgbtnadd = (ImageButton)e.Row.FindControl("Imgbtnadd");
            if (Imgbtnadd != null)
            {
                Imgbtnadd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
            }

            if (ddlParentQuickCode != null)
            {
                ds = objMisc.QuickCodeTypeParentIdGet();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlParentQuickCode.DataSource = ds.Tables[0];
                    ddlParentQuickCode.DataTextField = "QuickCodeDesc";
                    ddlParentQuickCode.DataValueField = "QuickCode";
                    ddlParentQuickCode.DataBind();

                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoParent;
                    li.Value = "";
                    ddlParentQuickCode.Items.Insert(0, li);
                    ddlParentQuickCode.SelectedIndex = 0;
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoData;
                    li.Value = "";
                    ddlParentQuickCode.Items.Add(li);
                }
            }
            if (txtQuickCode != null)
            {
                txtQuickCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtQuickCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
            }
            if (txtQuickCodeDesc != null)
            {
                txtQuickCodeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtQuickCodeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtQuickCode = (TextBox)gvQuickCodeType.FooterRow.FindControl("txtQuickCode");
        TextBox txtQuickCodeDesc = (TextBox)gvQuickCodeType.FooterRow.FindControl("txtQuickCodeDesc");
        DropDownList ddlParentQuickCode = (DropDownList)gvQuickCodeType.FooterRow.FindControl("ddlParentQuickCode");
        CheckBox checkBoxStatus = (CheckBox)gvQuickCodeType.FooterRow.FindControl("checkBoxStatus");

        if (e.CommandName.Equals("AddNew"))
        {

            DataSet ds = new DataSet();
            BL.Misc objMisc = new BL.Misc();
            ds = objMisc.QuickCodeTypeInsert(txtQuickCode.Text, txtQuickCodeDesc.Text, checkBoxStatus.Checked, ddlParentQuickCode.SelectedValue.ToString(), BaseUserID);
            if (gvQuickCodeType.Rows.Count.Equals(gvQuickCodeType.PageSize))
            {
                gvQuickCodeType.PageIndex = gvQuickCodeType.PageCount + 1;
            }
            gvQuickCodeType.EditIndex = -1;
            if (rdbMapped.Checked == true)
            {

                FillgvQuickCodeType();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }

            else if (rdbUnMapped.Checked == true)
            {

                FillgvQuickCodeType();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {

                FillgvQuickCodeType();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtQuickCodeDesc.Text = "";
            txtQuickCode.Text = "";
        }

        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvQuickCodeType.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvQuickCodeType.PageIndex = gvQuickCodeType.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvQuickCodeType.EditIndex = e.NewEditIndex;
        FillgvQuickCodeType();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        PanelQuickCodeMaster.Visible = false;
        DataSet ds = new DataSet();
        BL.Misc objMisc = new BL.Misc();
        TextBox txtQuickCodeDesc = (TextBox)gvQuickCodeType.Rows[e.RowIndex].FindControl("txtQuickCodeDesc");
        DropDownList ddlParentQuickCode = (DropDownList)gvQuickCodeType.Rows[e.RowIndex].FindControl("ddlParentQuickCode");
        CheckBox checkBoxStatus = (CheckBox)gvQuickCodeType.Rows[e.RowIndex].FindControl("checkBoxStatus");

        var dataKey = gvQuickCodeType.DataKeys[e.RowIndex];
        if (dataKey != null)
        {
            ds = objMisc.QuickCodeTypeUpdate(dataKey.Value.ToString(), txtQuickCodeDesc.Text, checkBoxStatus.Checked,
                ddlParentQuickCode.SelectedValue, BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            gvQuickCodeType.EditIndex = -1;
            FillgvQuickCodeType();
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQuickCodeType.EditIndex = -1;
        FillgvQuickCodeType();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvQuickCodeType.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvQuickCodeType.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvQuickCodeType.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvQuickCodeType.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvQuickCodeType.PageIndex = e.NewPageIndex;
        }
        gvQuickCodeType.EditIndex = -1;
        FillgvQuickCodeType();
    }
    /// <summary>
    /// Handles the Sorting event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        Image sortImage = new Image();
        if (GridViewSortDirection == SortDirection.Ascending)
        {

            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESC");
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASC");
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Misc objMisc = new BL.Misc();
        DataSet ds = new DataSet();
        LinkButton lbQuickCode = (LinkButton)gvQuickCodeType.Rows[e.RowIndex].FindControl("lbQuickCode");
        ds = objMisc.QuickCodeTypeDelete(lbQuickCode.Text);
        FillgvQuickCodeType();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
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
    private void SortGridView(string sortExpression, string direction)
    {
        BL.Misc objMisc = new BL.Misc();
        DataView dv = new DataView(objMisc.QuickCodeTypeGetAll().Tables[0]);
        dv.Sort = sortExpression + ' ' + direction;
        gvQuickCodeType.DataSource = dv;
        gvQuickCodeType.DataBind();
    }
    /// <summary>
    /// Handles the Click event of the lbQuickCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbQuickCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        BL.Misc objMisc = new BL.Misc();
        PanelQuickCodeMaster.Visible = true;
        DataSet ds = new DataSet();
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbQuickCode = (LinkButton)gvQuickCodeType.Rows[row.RowIndex].FindControl("lbQuickCode");
        //Label lblParentIDQuickCodeType = (Label)gvQuickCodeType.Rows[row.RowIndex].FindControl("lblParentIDQuickCodeType");
        hfQuickCode.Value = lbQuickCode.Text;
        FillgvQuickCodeMaster(lbQuickCode.Text);
    }
    #endregion

    #region Function To fill Quick Code master
    /// <summary>
    /// Fillgvs the quick code master.
    /// </summary>
    /// <param name="strQuickCode">The STR quick code.</param>
    private void FillgvQuickCodeMaster(string strQuickCode)
    {
        BL.Misc objMisc = new BL.Misc();
        DataSet ds = new DataSet();
        DataTable dtQuickCodeMaster = new DataTable();
        string strCompanyCode = BaseCompanyCode;
        if (rdbAll.Checked == true)
        {
            ds = objMisc.QuickCodeMasterGetAll(strQuickCode);
        }
        else if (rdbMapped.Checked == true)//Mapped
        {
            ds = objMisc.MappedQuickCodeMasterGet(strQuickCode, strCompanyCode);
        }
        else//Unmapped
        {
            ds = objMisc.UnMappedQuickCodeMasterGet(strQuickCode, strCompanyCode);
        }
        dtQuickCodeMaster = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtQuickCodeMaster.Rows.Count > 0)
        {
            gvQuickCodeMaster.DataSource = dtQuickCodeMaster;
            gvQuickCodeMaster.DataBind();
        }
        else
        {
            dtQuickCodeMaster.Rows.Add(dtQuickCodeMaster.NewRow());
            dtQuickCodeMaster.Rows[0]["Status"] = 0;
            gvQuickCodeMaster.DataSource = dtQuickCodeMaster;
            gvQuickCodeMaster.DataBind();
            gvQuickCodeMaster.Rows[0].Cells.Clear();
            gvQuickCodeMaster.Rows[0].Cells.Add(new TableCell());
            gvQuickCodeMaster.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }

    #endregion

    #region Grid View Quick Code Master Events
    /// <summary>
    /// Handles the RowDataBound event of the gvQuickCodeMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        BL.Misc objMisc = new BL.Misc();
        if (lblSerialNo != null)
        {
            int serialNo = gvQuickCodeMaster.PageIndex * gvQuickCodeMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtItemDesc = (TextBox)e.Row.FindControl("txtItemDesc");

            if (txtItemDesc != null)
            {
                txtItemDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtItemDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }
            ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
            if (ImgbtnUpdate != null)
            {
                ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
            }
            ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
            if (ImgbtnDelete != null)
            {
                ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
            }

            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblQuickCode = (Label)e.Row.FindControl("lblQuickCode");
            Label lblItemCode = (Label)e.Row.FindControl("lblItemCode");


            DropDownList ddlParentItemCode = (DropDownList)e.Row.FindControl("ddlParentItemCode");
            HiddenField hiddenFieldParentItemCode = (HiddenField)e.Row.FindControl("hiddenFieldParentItemCode");
            if (ddlParentItemCode != null)
            {
                ddlParentItemCode.DataSource = objMisc.QuickCodeMasterGetParentId(lblItemCode.Text, BaseCompanyCode, lblQuickCode.Text).Tables[0];
                ddlParentItemCode.DataTextField = "ItemDesc";
                ddlParentItemCode.DataValueField = "ItemCode";
                ddlParentItemCode.DataBind();
                if (ddlParentItemCode.Text == "")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoData;
                    li.Value = "0";
                    ddlParentItemCode.Items.Add(li);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoParent;
                    li.Value = "";
                    ddlParentItemCode.Items.Insert(0, li);
                }

                ddlParentItemCode.SelectedValue = hiddenFieldParentItemCode.Value.ToString();
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtItemCode = (TextBox)e.Row.FindControl("txtItemCode");
            if (txtItemCode != null)
            {
                txtItemCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtItemCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
            }
            TextBox txtItemDesc = (TextBox)e.Row.FindControl("txtItemDesc");
            if (txtItemDesc != null)
            {
                txtItemDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtItemDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }

            Label lblQuickCode = (Label)e.Row.FindControl("lblQuickCode");
            if (lblQuickCode != null)
            {
                lblQuickCode.Text = hfQuickCode.Value;
            }

            ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
            if (ImgbtnAdd != null)
            {
                ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
            }

            DropDownList ddlParentItemCode = (DropDownList)e.Row.FindControl("ddlParentItemCode");
            if (ddlParentItemCode != null && txtItemCode != null && lblQuickCode != null)
            {
                ddlParentItemCode.DataSource = objMisc.QuickCodeMasterGetParentId(txtItemCode.Text, BaseCompanyCode, lblQuickCode.Text).Tables[0];
                ddlParentItemCode.DataTextField = "ItemDesc";
                ddlParentItemCode.DataValueField = "ItemCode";
                ddlParentItemCode.DataBind();
                if (ddlParentItemCode.Text == "")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoData;
                    li.Value = "0";
                    ddlParentItemCode.Items.Add(li);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoParent;
                    li.Value = "";
                    ddlParentItemCode.Items.Insert(0, li);
                    ddlParentItemCode.SelectedIndex = 0;
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvQuickCodeMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Misc objMisc = new BL.Misc();

        Label lblQuickCode = (Label)gvQuickCodeMaster.FooterRow.FindControl("lblQuickCode");
        TextBox txtItemCode = (TextBox)gvQuickCodeMaster.FooterRow.FindControl("txtItemCode");
        TextBox txtItemDesc = (TextBox)gvQuickCodeMaster.FooterRow.FindControl("txtItemDesc");
        CheckBox checkBoxStatus = (CheckBox)gvQuickCodeMaster.FooterRow.FindControl("checkBoxStatus");
        DropDownList ddlParentItemCode = (DropDownList)gvQuickCodeMaster.FooterRow.FindControl("ddlParentItemCode");

        if (e.CommandName.Equals("AddNew"))
        {
            ds = objMisc.QuickCodeMasterInsert(lblQuickCode.Text, txtItemCode.Text, txtItemDesc.Text, checkBoxStatus.Checked, ddlParentItemCode.SelectedItem.Value.ToString(), BaseUserID, BaseCompanyCode);
            if (gvQuickCodeMaster.Rows.Count.Equals(gvQuickCodeMaster.PageSize))
            {
                gvQuickCodeMaster.PageIndex = gvQuickCodeMaster.PageCount + 1;
            }
            gvQuickCodeMaster.EditIndex = -1;
            FillgvQuickCodeMaster(lblQuickCode.Text);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtItemCode.Text = "";
            txtItemDesc.Text = "";
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvQuickCodeMaster.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvQuickCodeMaster.PageIndex = gvQuickCodeMaster.PageCount;
                break;
        }


    }
    /// <summary>
    /// Handles the RowEditing event of the gvQuickCodeMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvQuickCodeMaster.EditIndex = e.NewEditIndex;
        Label lblQuickCode = (Label)gvQuickCodeMaster.FooterRow.FindControl("lblQuickCode");
        FillgvQuickCodeMaster(lblQuickCode.Text);
    }
    /// <summary>
    /// Grid view Update Event for Quick Code Items
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">Grid View Update Event Args</param>
    protected void gvQuickCodeMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objMisc = new BL.Misc();
        var lblQuickCode = (Label)gvQuickCodeMaster.Rows[e.RowIndex].FindControl("lblQuickCode");
        var lblItemCode = (Label)gvQuickCodeMaster.Rows[e.RowIndex].FindControl("lblItemCode");
        var txtItemDesc = (TextBox)gvQuickCodeMaster.Rows[e.RowIndex].FindControl("txtItemDesc");
        var checkBoxStatus = (CheckBox)gvQuickCodeMaster.Rows[e.RowIndex].FindControl("checkBoxStatus");
        var ddlParentItemCode = (DropDownList)gvQuickCodeMaster.Rows[e.RowIndex].FindControl("ddlParentItemCode");
        var ds = objMisc.QuickCodeMasterUpdate(lblQuickCode.Text, lblItemCode.Text, txtItemDesc.Text, checkBoxStatus.Checked, ddlParentItemCode.SelectedItem.Value, BaseUserID, BaseCompanyCode);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        gvQuickCodeMaster.EditIndex = -1;
        FillgvQuickCodeMaster(lblQuickCode.Text);

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvQuickCodeMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQuickCodeMaster.EditIndex = -1;
        Label lblQuickCode = (Label)gvQuickCodeMaster.FooterRow.FindControl("lblQuickCode");
        FillgvQuickCodeMaster(lblQuickCode.Text);
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvQuickCodeMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow row = gvQuickCodeMaster.BottomPagerRow;
        DropDownList ddlPagesQuickCodeMaster = (DropDownList)row.Cells[0].FindControl("ddlPagesQuickCodeMaster");
        int CurrentIndex = int.Parse(ddlPagesQuickCodeMaster.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvQuickCodeMaster.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvQuickCodeMaster.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvQuickCodeMaster.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvQuickCodeMaster.PageIndex = e.NewPageIndex;
        }
        gvQuickCodeMaster.EditIndex = -1;
        Label lblQuickCode = (Label)gvQuickCodeMaster.FooterRow.FindControl("lblQuickCode");
        FillgvQuickCodeMaster(lblQuickCode.Text);
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvQuickCodeMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Misc objMisc = new BL.Misc();
        DataSet ds = new DataSet();
        Label lblQuickCode = (Label)gvQuickCodeMaster.Rows[e.RowIndex].FindControl("lblQuickCode");
        Label lblItemCode = (Label)gvQuickCodeMaster.Rows[e.RowIndex].FindControl("lblItemCode");
        ds = objMisc.QuickCodeMasterDelete(lblQuickCode.Text, lblItemCode.Text);
        FillgvQuickCodeMaster(lblQuickCode.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    #endregion

    #region Function Related to Paging in Quick code type
    /// <summary>
    /// Handles the DataBound event of the gvQuickCodeType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeType_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvQuickCodeType.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvQuickCodeType.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvQuickCodeType.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvQuickCodeType.PageCount.ToString();
        }

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvQuickCodeType.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvQuickCodeType.PageIndex = ddlPages.SelectedIndex;
        FillgvQuickCodeType();
    }
    #endregion

    #region Function related to paging in QuickCode Master
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPagesQuickCodeMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPagesQuickCodeMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvQuickCodeMaster.BottomPagerRow;
        DropDownList ddlPagesQuickCodeMaster = (DropDownList)row.Cells[0].FindControl("ddlPagesQuickCodeMaster");
        Label lblQuickCode = (Label)gvQuickCodeMaster.FooterRow.FindControl("lblQuickCode");
        gvQuickCodeMaster.PageIndex = ddlPagesQuickCodeMaster.SelectedIndex;
        FillgvQuickCodeMaster(lblQuickCode.Text);
    }
    /// <summary>
    /// Handles the DataBound event of the gvQuickCodeMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvQuickCodeMaster_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvQuickCodeMaster.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPagesQuickCodeMaster = (DropDownList)row.Cells[0].FindControl("ddlPagesQuickCodeMaster");
        Label lblPageCountQuickCodeMaster = (Label)row.Cells[0].FindControl("lblPageCountQuickCodeMaster");
        if (ddlPagesQuickCodeMaster != null)
        {
            for (int i = 0; i < gvQuickCodeMaster.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvQuickCodeMaster.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPagesQuickCodeMaster.Items.Add(lstItem);
            }
        }
        if (lblPageCountQuickCodeMaster != null)
        {
            lblPageCountQuickCodeMaster.Text = gvQuickCodeMaster.PageCount.ToString();
        }

    }
    #endregion
    protected void rdbAll_CheckedChanged(object sender, EventArgs e)
    {
        if (hfQuickCode.Value != string.Empty)
        {
            FillgvQuickCodeMaster(hfQuickCode.Value);
        }

    }
    protected void rdbMapped_CheckedChanged(object sender, EventArgs e)
    {
        if (hfQuickCode.Value != string.Empty)
        {
            FillgvQuickCodeMaster(hfQuickCode.Value);
        }
    }

    protected void rdbUnMapped_CheckedChanged(object sender, EventArgs e)
    {
        if (hfQuickCode.Value != string.Empty)
        {
            FillgvQuickCodeMaster(hfQuickCode.Value);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillgvQuickCodeType();
    }
}



