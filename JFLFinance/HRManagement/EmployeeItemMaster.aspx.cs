
// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Data;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Web;

/// <summary>
/// Class Masters_EmployeeMaster
/// </summary>
public partial class Masters_EmployeeItemMaster : BasePage
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
   
    /// <summary>
    /// The status
    /// </summary>
    static int Status;
    /// <summary>
    /// The dtflag
    /// </summary>
    static int dtflag1;
    #region page load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        dtflag1 = 0;
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                FillgvEmpItemMst();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }  
        }
    }
    #endregion
    protected void FillgvEmpItemMst()
    {
        try
        {
            var objmstmgmt = new BL.MastersManagement();
            DataSet ds = objmstmgmt.EmployeeItemsGetAll();
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    dtflag1 = 2;
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                }
                gvEmpItemMst.DataSource = ds.Tables[0];
                gvEmpItemMst.DataBind();
                gvEmpItemMst.Rows[0].Visible = true;
                if (dtflag1 == 2)
                {
                    gvEmpItemMst.Rows[0].Visible = false;
                    dtflag1 = 2;
                }
                else
                {
                    dtflag1 = 1;
                }
            }
            else
            {
                DisplayMessageString(lblErrorMsg, @"Nothing to Show");
            }
        }
        catch(Exception ex)
        { }

    }
    protected void gvEmpItemMst_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                { IBDeleteTran.Visible = false; }
            }
            if (IsModifyAccess == false)
            {
                ImageButton IBEditTran = (ImageButton)e.Row.FindControl("IBEditTran");
                if (IBEditTran != null)
                { IBEditTran.Visible = false; }
            }
            else
            {
                TextBox txtItemCode = (TextBox)e.Row.FindControl("txtItemCode");
                TextBox txtItemName = (TextBox)e.Row.FindControl("txtItemName");
                TextBox txtNewGroup = (TextBox)e.Row.FindControl("txtNewGroup");
                TextBox txtNewSubGroup = (TextBox)e.Row.FindControl("txtNewSubGroup");

                if (txtItemCode != null)
                {
                    txtItemCode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
                    txtItemCode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
                }
                if (txtItemName != null)
                {
                    txtItemName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtItemName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtNewGroup != null)
                {
                    txtNewGroup.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewGroup.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtNewSubGroup != null)
                {
                    txtNewSubGroup.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewSubGroup.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                { lbADD.Visible = false; }
                gvEmpItemMst.ShowFooter = false;
            }
            else
            {
                var ddlGroup = (DropDownList)e.Row.FindControl("ddlGroup");
                var ddlSubGroup = (DropDownList)e.Row.FindControl("ddlSubGroup");
                if (ddlGroup != null && ddlSubGroup != null)
                {
                    FillddlGroupAll(ddlGroup, ddlSubGroup);
                }

                TextBox txtItemCode = (TextBox)e.Row.FindControl("txtItemCode");
                TextBox txtItemName = (TextBox)e.Row.FindControl("txtItemName");
                TextBox txtNewGroup = (TextBox)e.Row.FindControl("txtNewGroup");
                TextBox txtNewSubGroup = (TextBox)e.Row.FindControl("txtNewSubGroup");

                if (txtItemCode != null)
                {
                    txtItemCode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
                    txtItemCode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
                }
                if (txtItemName != null)
                {
                    txtItemName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtItemName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtNewGroup != null)
                {
                    txtNewGroup.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewGroup.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtNewSubGroup != null)
                {
                    txtNewSubGroup.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewSubGroup.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
            }
        }
    }
    protected void gvEmpItemMst_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objmstmgmt = new BL.MastersManagement();
       
        var txtItemName = (TextBox)gvEmpItemMst.FooterRow.FindControl("txtItemName");
        var txtItemCode = (TextBox)gvEmpItemMst.FooterRow.FindControl("txtItemCode");
        var txtNewGroup = (TextBox)gvEmpItemMst.FooterRow.FindControl("txtNewGroup");
        var txtNewSubGroup = (TextBox)gvEmpItemMst.FooterRow.FindControl("txtNewSubGroup");
        if (e.CommandName == "AddNew")
        {
            DataSet ds = objmstmgmt.EmployeeItemInsertNUpdate(txtItemCode.Text, txtItemName.Text, txtNewGroup.Text, txtNewSubGroup.Text, BaseUserID, "0");
            gvEmpItemMst.EditIndex = -1;
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvEmpItemMst();
        }
        if (e.CommandName == "Reset")
        {
            txtItemName.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtNewGroup.Text = string.Empty;
            txtNewSubGroup.Text = string.Empty;
        }
    }
    protected void gvEmpItemMst_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objmstmgmt = new BL.MastersManagement();

        var lblItemCode = (Label)gvEmpItemMst.Rows[e.RowIndex].FindControl("lblItemCode");
        DataSet ds = objmstmgmt.EmployeeItemDelete(lblItemCode.Text);
        FillgvEmpItemMst();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        
     

    }
    protected void gvEmpItemMst_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmpItemMst.EditIndex = e.NewEditIndex;
        FillgvEmpItemMst();
    }
    protected void gvEmpItemMst_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmpItemMst.PageIndex = e.NewPageIndex;
        gvEmpItemMst.EditIndex = -1;
        FillgvEmpItemMst();
    }
    protected void gvEmpItemMst_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmpItemMst.EditIndex = -1;
        FillgvEmpItemMst();
    }
    protected void gvEmpItemMst_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objmstmgmt = new BL.MastersManagement();
     
        var txtItemName = (TextBox)gvEmpItemMst.Rows[e.RowIndex].FindControl("txtItemName");
        var txtItemCode = (TextBox)gvEmpItemMst.Rows[e.RowIndex].FindControl("txtItemCode");
        var txtNewGroup = (TextBox)gvEmpItemMst.Rows[e.RowIndex].FindControl("txtNewGroup");
        var txtNewSubGroup = (TextBox)gvEmpItemMst.Rows[e.RowIndex].FindControl("txtNewSubGroup");

        DataSet ds = objmstmgmt.EmployeeItemInsertNUpdate(txtItemCode.Text, txtItemName.Text, txtNewGroup.Text, txtNewSubGroup.Text, BaseUserID, "1");
        gvEmpItemMst.EditIndex = -1;
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        FillgvEmpItemMst();
    }

    protected void FillddlGroup(DropDownList ddlGroup)
    {
        if (gvEmpItemMst != null && gvEmpItemMst.FooterRow != null)
        {
            var txtNewGroup = (TextBox)gvEmpItemMst.FooterRow.FindControl("txtNewGroup");
            if (txtNewGroup != null)
            {
                if (ddlGroup.SelectedItem.Value == string.Empty)
                {
                    txtNewGroup.Enabled = true;
                    txtNewGroup.Text = "";
                }
                else
                {
                    txtNewGroup.Text = ddlGroup.SelectedItem.Value;
                    txtNewGroup.Enabled = false;
                }
            }
        }

    }
    protected void FillddlSubGroup(DropDownList ddlSubGroup)
    {
        if (gvEmpItemMst != null && gvEmpItemMst.FooterRow != null)
        {
            var txtNewSubGroup = (TextBox)gvEmpItemMst.FooterRow.FindControl("txtNewSubGroup");
            if (txtNewSubGroup != null)
            {
                if (ddlSubGroup.SelectedItem.Value == string.Empty)
                {
                    txtNewSubGroup.Enabled = true;
                    txtNewSubGroup.Text = "";
                }
                else
                {

                    txtNewSubGroup.Text = ddlSubGroup.SelectedItem.Value;
                    txtNewSubGroup.Enabled = false;

                }

            }

        }

    }
    protected void FillddlGroupAll(DropDownList ddlGroup,DropDownList ddlSubGroup)
    {
        var objMastersManagement = new BL.MastersManagement();
        DataSet ds = objMastersManagement.EmployeeItemsGroupGetAll();


        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlGroup.DataSource = ds.Tables[0];
            ddlGroup.DataTextField = "ItemGroupName";
            ddlGroup.DataValueField = "ItemGroupName";
            ddlGroup.DataBind();
            ddlSubGroup.DataSource = ds.Tables[0];
            ddlSubGroup.DataTextField = "ItemSubGroupName";
            ddlSubGroup.DataValueField = "ItemSubGroupName";
            ddlSubGroup.DataBind();

            var li = new ListItem { Text = Resources.Resource.AddNew, Value = string.Empty };
            ddlGroup.Items.Insert(0, li);
            var li1 = new ListItem { Text = Resources.Resource.AddNew, Value = string.Empty };
            ddlSubGroup.Items.Insert(0, li);
        }
        else
        {
            var li = new ListItem { Text = Resources.Resource.AddNew, Value = string.Empty };
            ddlGroup.Items.Add(li);
            var li1 = new ListItem { Text = Resources.Resource.AddNew, Value = string.Empty };
            ddlSubGroup.Items.Insert(0, li);
        }
     
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlGroup = (DropDownList)sender;
        FillddlGroup(ddlGroup);

    }
    protected void ddlSubGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlSubGroup = (DropDownList)sender;
        FillddlSubGroup(ddlSubGroup);
    }
}



