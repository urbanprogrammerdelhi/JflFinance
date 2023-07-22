// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="SystemParameter.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Class UserManagement_SystemParameter
/// </summary>
public partial class UserManagement_SystemParameter : BasePage
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
        //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
        //if (lblPageHdrTitle != null)
        //{
        //    lblPageHdrTitle.Text = Resources.Resource.DefineSystemParameters.ToString();
        //}
        //Code added by  on 16 Jan 2012
        //Page Title from resource file
        System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
        javaScript.Append("<script type='text/javascript'>");
        javaScript.Append("window.document.body.onload = function ()");
        javaScript.Append("{\n");
        javaScript.Append("PageTitle('" + Resources.Resource.DefineSystemParameters + "');");
        javaScript.Append("};\n");
        javaScript.Append("// -->\n");
        javaScript.Append("</script>");
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillgvParamHead();
                lblErrMsg.Text = "";
            }
            else
            {
                lblErrMsg.Text = Resources.Resource.NOAccessRights;
            }
        }
    }

    #region GridView Binding
    /// <summary>
    /// Fillgvs the param head.
    /// </summary>
    protected void FillgvParamHead()
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objUserManagement.SystemParameterGetAll();
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        else
        {
            lblhdrParamCode.Text = dt.Rows[0]["ParamCode"].ToString();
            lblhdrParamDesc.Text = dt.Rows[0]["ParamDesc"].ToString();
            hfImplementationLevel.Value = dt.Rows[0]["ParamImplementationLevel"].ToString();
            FillgvParamValue(dt.Rows[0]["ParamCode"].ToString());

        }
        gvParamHead.DataKeyNames = new string[] {"ParamCode"};
        gvParamHead.DataSource = dt;
        gvParamHead.DataBind();

        if (dtflag == 0) //to fix empety gridview
        {
            gvParamHead.Rows[0].Visible = false;
        }
    }

    /// <summary>
    /// Fillgvs the param value.
    /// </summary>
    /// <param name="strParamCode">The STR param code.</param>
    protected void FillgvParamValue(string strParamCode)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objUserManagement.SystemParameterValuesGetAll(strParamCode);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvParamValue.DataKeyNames = new string[] { "ParamValuesAutoId" };
        gvParamValue.DataSource = dt;
        gvParamValue.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvParamValue.Rows[0].Visible = false;
        }
        TextBox txtParamCode = (TextBox)gvParamValue.FooterRow.FindControl("txtParamCode");
        txtParamCode.Text = lblhdrParamCode.Text;
    }
    #endregion

    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MainSelection.aspx");
    }

    #region Functions Related to ParamHead gridView

    /// <summary>
    /// Handles the OnClick event of the lbParamCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbParamCode_OnClick(object sender, EventArgs e)
    {
        LinkButton lbParamCode = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbParamCode.NamingContainer;

        Label lblParamCode = (Label)gvParamHead.Rows[gvRow.RowIndex].FindControl("lblParamCode");
        Label lblParamDesc = (Label)gvParamHead.Rows[gvRow.RowIndex].FindControl("lblParamDesc");
        Label lblParamDataType = (Label)gvParamHead.Rows[gvRow.RowIndex].FindControl("lblParamDateType");
        Label lblUserLevelToDefinedValues = (Label)gvParamHead.Rows[gvRow.RowIndex].FindControl("lblUserLevelToDefinedValues");
        Label lblIsEditable = (Label)gvParamHead.Rows[gvRow.RowIndex].FindControl("lblIsEditable");
        Label lblParamImplementationLevel = (Label)gvParamHead.Rows[gvRow.RowIndex].FindControl("lblParamImplementationLevel");
        
        lblhdrParamDesc.Text = lblParamDesc.Text;
        lblhdrParamCode.Text = lblParamCode.Text;
        hfImplementationLevel.Value = lblParamImplementationLevel.Text;
        hfDataType.Value = lblParamDataType.Text;
        hfIsEditable.Value = lblIsEditable.Text;
        hfUserLevel.Value = lblUserLevelToDefinedValues.Text;

        FillgvParamValue(lblParamCode.Text);
    }

    /// <summary>
    /// Fillddls the type of the param.
    /// </summary>
    /// <param name="ddlParamType">Type of the DDL param.</param>
    protected void FillddlParamType(RadComboBox ddlParamType)
    {
        ddlParamType.Items.Clear();

        RadComboBoxItem li = new RadComboBoxItem { Text = @"Informative", Value = @"Informative" };
        ddlParamType.Items.Add(li);

        li = new RadComboBoxItem { Text = @"Mandatory", Value = @"Mandatory" };
        ddlParamType.Items.Add(li);
    }
    /// <summary>
    /// Fillddls the user level to defined values.
    /// </summary>
    /// <param name="ddlUserLevelToDefinedValues">The DDL user level to defined values.</param>
    protected void FillddlUserLevelToDefinedValues(RadComboBox ddlUserLevelToDefinedValues)
    {
        ddlUserLevelToDefinedValues.Items.Clear();

        RadComboBoxItem li = new RadComboBoxItem {Text = @"SuperUser", Value = @"SU"};
        ddlUserLevelToDefinedValues.Items.Add(li);

        li = new RadComboBoxItem {Text = @"Administrator", Value = @"A"};
        ddlUserLevelToDefinedValues.Items.Add(li);

        li = new RadComboBoxItem {Text = @"User", Value = @"U"};
        ddlUserLevelToDefinedValues.Items.Add(li);

        //li = new RadComboBoxItem {Text = @"System", Value = @"S"};
        //ddlUserLevelToDefinedValues.Items.Add(li);
    }
    /// <summary>
    /// Fillddls the type of the param date.
    /// </summary>
    /// <param name="ddlParamDateType">Type of the DDL param date.</param>
    protected void FillddlParamDateType(RadComboBox ddlParamDateType)
    {
        ddlParamDateType.Items.Clear();
        RadComboBoxItem li = new RadComboBoxItem { Text = @"Value", Value = @"Value" };
        ddlParamDateType.Items.Add(li);

        li = new RadComboBoxItem { Text = @"Text", Value = @"Text" };
        ddlParamDateType.Items.Add(li);

        li = new RadComboBoxItem { Text = @"Date", Value = @"Date" };
        ddlParamDateType.Items.Add(li);

        li = new RadComboBoxItem { Text = @"Percentage", Value = @"Percentage" };
        ddlParamDateType.Items.Add(li);

        li = new RadComboBoxItem { Text = @"ValueRange", Value = @"ValueRange" };
        ddlParamDateType.Items.Add(li);

        li = new RadComboBoxItem { Text = @"DateRange", Value = @"DateRange" };
        ddlParamDateType.Items.Add(li);

        li = new RadComboBoxItem { Text = @"Boolean", Value = @"Boolean" };
        ddlParamDateType.Items.Add(li);

        li = new RadComboBoxItem { Text = @"WeekDay", Value = @"WeekDay" };
        ddlParamDateType.Items.Add(li);
    }
    /// <summary>
    /// Fillddls the param implementation level.
    /// </summary>
    /// <param name="ddlLevel">The DDL level.</param>
    protected void FillddlParamImplementationLevel(RadComboBox ddlLevel)
    {
        if (ddlLevel != null)
        {
            ddlLevel.Items.Clear();

            //RadComboBoxItem li = new RadComboBoxItem { Text = @"Not Selected", Value = @"" };
            //ddlLevel.Items.Add(li);

            RadComboBoxItem li = new RadComboBoxItem { Text = @"Company", Value = @"CompanyCode" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Location", Value = @"LocationAutoId" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"UserId", Value = @"UserId" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Division", Value = @"HrLocationCode" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Employee Number", Value = @"EmployeeNumber" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Designation", Value = @"DesignationCode" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Department", Value = @"DepartmentCode" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Category", Value = @"CategoryCode" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Asignment Address", Value = @"AsmtId" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Contract Number", Value = @"ContractNumber" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Sale Order Number", Value = @"SoNo" };
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem { Text = @"Post", Value = @"PostAutoId" };
            ddlLevel.Items.Add(li);
        }
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvParamHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvParamHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvParamHead, "Select$" + e.Row.RowIndex);
            Label lblParamCode = (Label) e.Row.FindControl("lblParamCode");
            TextBox txtParamDesc = (TextBox) e.Row.FindControl("txtParamDesc");
            if (txtParamDesc != null)
            {
                txtParamDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," +
                                                     Resources.Resource.ValidationExpressionString + ");";
                txtParamDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," +
                                                    Resources.Resource.ValidationExpressionString + ");";
            }

            RadComboBox ddlParamType = (RadComboBox) e.Row.FindControl("ddlParamType");
            RadComboBox ddlUserLevelToDefinedValues = (RadComboBox) e.Row.FindControl("ddlUserLevelToDefinedValues");
            RadComboBox ddlParamDateType = (RadComboBox) e.Row.FindControl("ddlParamDateType");
            RadComboBox ddlParamImplementationLevel = (RadComboBox) e.Row.FindControl("ddlParamImplementationLevel");
            HiddenField hfUserLevelToDefinedValues = (HiddenField) e.Row.FindControl("hfUserLevelToDefinedValues");
            HiddenField hfParamDataType = (HiddenField)e.Row.FindControl("hfParamDataType");
            HiddenField hfParamType = (HiddenField)e.Row.FindControl("hfParamType");
            HiddenField hfParamImplementationLevel = (HiddenField) e.Row.FindControl("hfParamImplementationLevel");

            if (ddlParamType != null)
            {
                FillddlParamType(ddlParamType);
            }
            if (ddlUserLevelToDefinedValues != null)
            {
                FillddlUserLevelToDefinedValues(ddlUserLevelToDefinedValues);
            }
            if (ddlParamDateType != null)
            {
                FillddlParamDateType(ddlParamDateType);
            }
            if (ddlParamImplementationLevel != null)
            {
                FillddlParamImplementationLevel(ddlParamImplementationLevel);
            }

            if (ddlParamType != null && hfParamType != null)
                ddlParamType.SelectedIndex = ddlParamType.Items.IndexOf(ddlParamType.Items.FindItemByValue(hfParamType.Value.ToString()));
            if (ddlParamDateType != null && hfParamDataType != null)
                ddlParamDateType.SelectedIndex = ddlParamDateType.Items.IndexOf(ddlParamDateType.Items.FindItemByValue(hfParamDataType.Value.ToString()));
            if (ddlUserLevelToDefinedValues != null && hfUserLevelToDefinedValues != null)
                ddlUserLevelToDefinedValues.SelectedIndex = ddlUserLevelToDefinedValues.Items.IndexOf(ddlUserLevelToDefinedValues.Items.FindItemByValue(hfUserLevelToDefinedValues.Value.ToString()));
            if (ddlParamImplementationLevel != null && hfParamImplementationLevel != null)
                ddlParamImplementationLevel.SelectedIndex = ddlParamImplementationLevel.Items.IndexOf(ddlParamImplementationLevel.Items.FindItemByValue(hfParamImplementationLevel.Value.ToString()));
            
        }
    
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //SuperAdminIdGet
            if(BaseIsAdmin != "SA")
            {
                gvParamHead.ShowFooter = false;
                //gvParamHead.FooterRow.Visible = false;
                gvParamHead.Columns[9].Visible = false;
            }
            TextBox txtParamCode = (TextBox)e.Row.FindControl("txtParamCode");
            if (txtParamCode != null)
            {
                txtParamCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtParamCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
            }
            TextBox txtParamDesc = (TextBox)e.Row.FindControl("txtParamDesc");
            if (txtParamDesc != null)
            {
                txtParamDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtParamDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }

            RadComboBox ddlParamType = (RadComboBox)e.Row.FindControl("ddlParamType");
            RadComboBox ddlUserLevelToDefinedValues = (RadComboBox)e.Row.FindControl("ddlUserLevelToDefinedValues");
            RadComboBox ddlParamDateType = (RadComboBox)e.Row.FindControl("ddlParamDateType");
            RadComboBox ddlParamImplementationLevel = (RadComboBox)e.Row.FindControl("ddlParamImplementationLevel");

            if (ddlParamType != null)
            {
                FillddlParamType(ddlParamType);
            }
            if (ddlUserLevelToDefinedValues != null)
            {
                FillddlUserLevelToDefinedValues(ddlUserLevelToDefinedValues);
            }
            if (ddlParamDateType != null)
            {
                FillddlParamDateType(ddlParamDateType);
            }
            if(ddlParamImplementationLevel != null)
            {
                FillddlParamImplementationLevel(ddlParamImplementationLevel);
            }
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvParamHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvParamHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label lblParamCode = (Label)gvParamHead.SelectedRow.FindControl("lblParamCode");
        Label lblParamDesc = (Label)gvParamHead.SelectedRow.FindControl("lblParamDesc");
        Label lblParamImplementationLevel = (Label)gvParamHead.SelectedRow.FindControl("lblParamImplementationLevel");
        lblhdrParamDesc.Text = lblParamDesc.Text;
        lblhdrParamCode.Text = lblParamCode.Text;
        hfImplementationLevel.Value = lblParamImplementationLevel.Text;
        FillgvParamValue(lblParamCode.Text);
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvParamHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvParamHead_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvParamHead.EditIndex = -1;
        FillgvParamHead();
    }
    /// <summary>
    /// Handles the RowCommand event of the gvParamHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvParamHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        // To Insert a New Row
        DataSet ds = new DataSet();
        TextBox txtParamCode = (TextBox)gvParamHead.FooterRow.FindControl("txtParamCode");
        TextBox txtParamDesc = (TextBox)gvParamHead.FooterRow.FindControl("txtParamDesc");
        RadComboBox ddlParamType = (RadComboBox)gvParamHead.FooterRow.FindControl("ddlParamType");
        RadComboBox ddlParamDateType = (RadComboBox)gvParamHead.FooterRow.FindControl("ddlParamDateType");
        CheckBox cbIsEditable = (CheckBox)gvParamHead.FooterRow.FindControl("cbIsEditable");
        CheckBox cbIsActive = (CheckBox)gvParamHead.FooterRow.FindControl("cbIsActive");
        RadComboBox ddlUserLevelToDefinedValues = (RadComboBox)gvParamHead.FooterRow.FindControl("ddlUserLevelToDefinedValues");
        RadComboBox ddlParamImplementationLevel =
            (RadComboBox) gvParamHead.FooterRow.FindControl("ddlParamImplementationLevel");

        if (e.CommandName == "Add")
        {
            ds = objUserManagement.SystemParameterAdd(txtParamCode.Text, txtParamDesc.Text, ddlParamImplementationLevel.SelectedItem.Value.ToString(), ddlParamType.SelectedItem.Value.ToString(), ddlParamDateType.SelectedItem.Value.ToString(), cbIsEditable.Checked.ToString(), cbIsActive.Checked.ToString(), ddlUserLevelToDefinedValues.SelectedItem.Value.ToString(), BaseUserID.ToString());
            gvParamHead.EditIndex = -1;
            FillgvParamHead();
            MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
        }
        if (e.CommandName == "Reset")
        {
            txtParamCode.Text = "";
            txtParamDesc.Text = "";
            cbIsEditable.Checked = false;
            cbIsActive.Checked = false;
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvParamHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvParamHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();
        Label lblParamCode = (Label)gvParamHead.Rows[e.RowIndex].FindControl("lblParamCode");
        ds = objUserManagement.SystemParameterDelete(lblParamCode.Text);
        FillgvParamHead();
        MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvParamHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvParamHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvParamHead.EditIndex = e.NewEditIndex;
        FillgvParamHead();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvParamHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvParamHead_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();
        Label lblParamCode = (Label)gvParamHead.Rows[e.RowIndex].FindControl("lblParamCode");
        TextBox txtParamDesc = (TextBox)gvParamHead.Rows[e.RowIndex].FindControl("txtParamDesc");
        RadComboBox ddlParamType = (RadComboBox)gvParamHead.Rows[e.RowIndex].FindControl("ddlParamType");
        RadComboBox ddlParamDateType = (RadComboBox) gvParamHead.Rows[e.RowIndex].FindControl("ddlParamDateType");
        CheckBox cbIsEditable = (CheckBox)gvParamHead.Rows[e.RowIndex].FindControl("cbIsEditable");
        CheckBox cbIsActive = (CheckBox)gvParamHead.Rows[e.RowIndex].FindControl("cbIsActive");
        RadComboBox ddlUserLevelToDefinedValues = (RadComboBox)gvParamHead.Rows[e.RowIndex].FindControl("ddlUserLevelToDefinedValues");
        RadComboBox ddlParamImplementationLevel =
            (RadComboBox) gvParamHead.Rows[e.RowIndex].FindControl("ddlParamImplementationLevel");

        ds = objUserManagement.SystemParameterUpdate(lblParamCode.Text, txtParamDesc.Text, ddlParamImplementationLevel.SelectedItem.Value.ToString(), ddlParamType.SelectedItem.Value.ToString(), ddlParamDateType.SelectedItem.Value.ToString(), cbIsEditable.Checked.ToString(), cbIsActive.Checked.ToString(), ddlUserLevelToDefinedValues.SelectedItem.Value.ToString(), BaseUserID.ToString());
        gvParamHead.EditIndex = -1;
        FillgvParamHead();

        MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvParamHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvParamHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvParamHead.PageIndex = e.NewPageIndex;
        FillgvParamHead();
    }

    #endregion

    #region Function related to Param Value Gridview
    /// <summary>
    /// Fillddls the level1.
    /// </summary>
    /// <param name="ddlLevel">The DDL level.</param>
    protected void FillddlLevel1(RadComboBox ddlLevel)
    {
        if (ddlLevel != null)
        {
            ddlLevel.Items.Clear();

            RadComboBoxItem li = new RadComboBoxItem {Text = @"Not Selected", Value = @""};
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem {Text = @"Company", Value = @"CompanyCode"};
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem {Text = @"Location", Value = @"LocationAutoId"};
            ddlLevel.Items.Add(li);

            li = new RadComboBoxItem {Text = @"UserId", Value = @"UserId"};
            ddlLevel.Items.Add(li);
        }
    }

    /// <summary>
    /// Fillddls the level2.
    /// </summary>
    /// <param name="ddlLevel1">The DDL level1.</param>
    /// <param name="ddlLevel">The DDL level.</param>
    protected void FillddlLevel2(RadComboBox ddlLevel1, RadComboBox ddlLevel)
    {
        if (ddlLevel != null && ddlLevel1 != null)
        {
            ddlLevel.Items.Clear();
            RadComboBoxItem li = new RadComboBoxItem {Text = @"Not Selected", Value = @""};
            ddlLevel.Items.Add(li);

            if (ddlLevel1.SelectedItem.Value.ToString() == @"CompanyCode")
            {
                li = new RadComboBoxItem {Text = @"Division", Value = @"HrLocationCode"};
                ddlLevel.Items.Add(li);

                li = new RadComboBoxItem {Text = @"Employee Number", Value = @"EmployeeNumber"};
                ddlLevel.Items.Add(li);

                li = new RadComboBoxItem {Text = @"Designation", Value = @"DesignationCode"};
                ddlLevel.Items.Add(li);

                li = new RadComboBoxItem {Text = @"Department", Value = @"DepartmentCode"};
                ddlLevel.Items.Add(li);

                li = new RadComboBoxItem {Text = @"Category", Value = @"CategoryCode"};
                ddlLevel.Items.Add(li);

                //li = new RadComboBoxItem { Text = @"Job Class", Value = @"JobClass" };
                //ddlLevel.Items.Add(li);

                //li = new RadComboBoxItem { Text = @"Job Type", Value = @"JobType" };
                //ddlLevel.Items.Add(li);
            }

            if (ddlLevel1.SelectedItem.Value.ToString() == @"LocationAutoId")
            {
                li = new RadComboBoxItem {Text = @"Employee Number", Value = @"EmployeeNumber"};
                ddlLevel.Items.Add(li);

                li = new RadComboBoxItem {Text = @"Client", Value = @"ClientCode"};
                ddlLevel.Items.Add(li);

                li = new RadComboBoxItem {Text = @"UserId", Value = @"UserId"};
                ddlLevel.Items.Add(li);
            }
        }
    }

    /// <summary>
    /// Fillddls the level3.
    /// </summary>
    /// <param name="ddlLevel2">The DDL level2.</param>
    /// <param name="ddlLevel">The DDL level.</param>
    protected void FillddlLevel3(RadComboBox ddlLevel2, RadComboBox ddlLevel)
    {
        if (ddlLevel != null && ddlLevel2 != null)
        {
            ddlLevel.Items.Clear();
            RadComboBoxItem li = new RadComboBoxItem {Text = @"Not Selected", Value = @""};
            ddlLevel.Items.Add(li);

            if (ddlLevel2.SelectedItem.Value.ToString() == @"ClientCode")
            {
                li = new RadComboBoxItem {Text = @"Asignment Address", Value = @"AsmtId"};
                ddlLevel.Items.Add(li);

                li = new RadComboBoxItem {Text = @"Contract Number", Value = @"ContractNumber"};
                ddlLevel.Items.Add(li);

                li = new RadComboBoxItem {Text = @"Sale Order Number", Value = @"SoNo"};
                ddlLevel.Items.Add(li);

                //li = new RadComboBoxItem { Text = @"Assignment Code", Value = @"AsmtCode" };
                //ddlLevel.Items.Add(li);
            }
        }
    }

    /// <summary>
    /// Fillddls the level4.
    /// </summary>
    /// <param name="ddlLevel3">The DDL level3.</param>
    /// <param name="ddlLevel">The DDL level.</param>
    protected void FillddlLevel4(RadComboBox ddlLevel3, RadComboBox ddlLevel)
    {
        if (ddlLevel != null && ddlLevel3 != null)
        {
            ddlLevel.Items.Clear();
            RadComboBoxItem li = new RadComboBoxItem {Text = @"Not Selected", Value = @""};
            ddlLevel.Items.Add(li);

            if (ddlLevel3.SelectedItem.Value.ToString() == @"AsmtId")
            {
                li = new RadComboBoxItem {Text = @"Post", Value = @"PostAutoId"};
                ddlLevel.Items.Add(li);
            }
        }
    }

    /// <summary>
    /// Binds the drop down only ALL.
    /// </summary>
    /// <param name="ddlLevelCode">The DDL level code.</param>
    protected void BindDropDownOnlyALL(RadComboBox ddlLevelCode)
    {
        if (ddlLevelCode != null)
        {
            ddlLevelCode.Items.Clear();
            RadComboBoxItem li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlLevelCode.Items.Insert(0, li);
        }
    }
    /// <summary>
    /// Binds the drop down.
    /// </summary>
    /// <param name="ddlLevelCode">The DDL level code.</param>
    /// <param name="strDataValueField">The STR data value field.</param>
    /// <param name="strDataTextField">The STR data text field.</param>
    /// <param name="ds">The ds.</param>
    protected void BindDropDown(RadComboBox ddlLevelCode, string strDataValueField, string strDataTextField, DataSet ds)
    {
        if (ddlLevelCode != null)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 &&
                strDataValueField != "" && strDataTextField != "")
            {
                ddlLevelCode.DataSource = ds.Tables[0];
                ddlLevelCode.DataValueField = strDataValueField;
                ddlLevelCode.DataTextField = strDataTextField;
                ddlLevelCode.DataBind();

                RadComboBoxItem li = new RadComboBoxItem { Text = Resources.Resource.All , Value = @"ALL" };
                ddlLevelCode.Items.Insert(0, li);
            }
            else
            {
                ddlLevelCode.Items.Clear();
                RadComboBoxItem li = new RadComboBoxItem {Text = Resources.Resource.NoDataToShow, Value = @""};
                ddlLevelCode.Items.Add(li);
            }
        }
    }
    /// <summary>
    /// Binds the drop down no data to show.
    /// </summary>
    /// <param name="ddlLevelCode">The DDL level code.</param>
    protected void BindDropDownNoDataToShow(RadComboBox ddlLevelCode)
    {
        if (ddlLevelCode != null)
        {
            ddlLevelCode.Items.Clear();
            RadComboBoxItem li = new RadComboBoxItem {Text = Resources.Resource.NoDataToShow, Value = @""};
            ddlLevelCode.Items.Add(li);
        }
    }

    /// <summary>
    /// Fillddls the level code1.
    /// </summary>
    /// <param name="ddlLevel">The DDL level.</param>
    /// <param name="ddlLevelCode">The DDL level code.</param>
    /// <param name="ddlLevel1">The DDL level1.</param>
    /// <param name="ddlLevelCode1">The DDL level code1.</param>
    /// <param name="ddlLevel2">The DDL level2.</param>
    /// <param name="ddlLevelCode2">The DDL level code2.</param>
    /// <param name="ddlLevel3">The DDL level3.</param>
    /// <param name="ddlLevelCode3">The DDL level code3.</param>
    /// <param name="ddlLevel4">The DDL level4.</param>
    /// <param name="ddlLevelCode4">The DDL level code4.</param>
    protected void FillddlLevelCode1(RadComboBox ddlLevel, RadComboBox ddlLevelCode,
        RadComboBox ddlLevel1, RadComboBox ddlLevelCode1,
        RadComboBox ddlLevel2, RadComboBox ddlLevelCode2,
        RadComboBox ddlLevel3, RadComboBox ddlLevelCode3,
        RadComboBox ddlLevel4, RadComboBox ddlLevelCode4)
    {
        if (ddlLevel != null && ddlLevelCode != null
            && ddlLevel1 != null && ddlLevelCode1 != null
            && ddlLevel2 != null && ddlLevelCode2 != null
            && ddlLevel3 != null && ddlLevelCode3 != null
            && ddlLevel4 != null && ddlLevelCode4 != null
            )
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            BL.HRManagement objHRManagement = new BL.HRManagement();
            BL.Sales objSales = new BL.Sales();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            BL.UserManagement objUserManagement = new BL.UserManagement();

            switch (ddlLevel.SelectedItem.Value.ToString())
            {
                case "CompanyCode":

                    ds = objMastersManagement.CompanyDescriptionGetAll();
                    BindDropDown(ddlLevelCode, "CompanyCode", "CompanyDesc", ds);
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "LocationAutoId":
                    ds = objMastersManagement.LocationDescriptionGetAll();
                    BindDropDown(ddlLevelCode, "LocationAutoId", "LocaationDescDetails", ds);
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "UserId":
                    if (ddlLevel1.ID.ToString() == @"ddlLevel1")
                    {
                        ds = objUserManagement.UserGetAll();
                        BindDropDown(ddlLevelCode, "UserID", "UserNameID", ds);
                    }
                    else if (ddlLevel1.ID.ToString() == @"ddlLevel2" && ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId")
                    {
                        if (ddlLevelCode1.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objUserManagement.UserGetAll();
                            BindDropDown(ddlLevelCode, "UserID", "UserNameID", ds);
                        }
                        else{ BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else if (ddlLevel1.ID.ToString() == @"ddlLevel3" && ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId" && ddlLevel2.SelectedItem.Value.ToString() == "ClientCode")
                    {
                        if (ddlLevelCode2.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objUserManagement.UserGetAll();
                            BindDropDown(ddlLevelCode, "UserID", "UserNameID", ds);
                        }
                        else{ BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "HrLocationCode":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "CompanyCode")
                    {
                        if (ddlLevelCode1.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objMastersManagement.HRLocationDescriptionGetAll(ddlLevelCode1.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "HrLocationCode", "HrLocationDescCode", ds);
                        }
                        else{ BindDropDownOnlyALL(ddlLevelCode); }

                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "EmployeeNumber":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "CompanyCode")
                    {
                        if (ddlLevelCode1.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objHRManagement.EmployeeNameAndNumberGetAll(ddlLevelCode1.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "EmployeeNumber", "Name", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else if (ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId")
                    {
                        if (ddlLevelCode1.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objHRManagement.EmployeeNameNumberGet4Location(ddlLevelCode1.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "EmployeeNumber", "Name", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "CategoryCode":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "CompanyCode")
                    {
                        if (ddlLevelCode1.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objMastersManagement.CategoryMasterGetAll(ddlLevelCode1.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "CategoryCode", "CategoryDesc", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "DepartmentCode":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "CompanyCode")
                    {
                        if (ddlLevelCode1.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objMastersManagement.DepartmentGetAll(ddlLevelCode1.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "DepartmentCode", "DepartmentName", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "DesignationCode":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "CompanyCode")
                    {
                        if (ddlLevelCode1.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objMastersManagement.DesignationMasterGetAll(ddlLevelCode1.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "DesignationCode", "DesignationDesc", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "ClientCode":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId")
                    {
                        if (ddlLevelCode1.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objSales.ClientsLocationWiseGet(ddlLevelCode1.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "ClientCode", "ClientNameCode", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "ContractNumber":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId" &&
                        ddlLevel2.SelectedItem.Value.ToString() == "ClientCode")
                    {
                        if (ddlLevelCode2.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objSales.ContractMasterGetAll(ddlLevelCode2.SelectedItem.Value.ToString(), ddlLevelCode1.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "ContractNumber", "CNoMCNo", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "SoNo":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId" &&
                        ddlLevel2.SelectedItem.Value.ToString() == "ClientCode")
                    {
                        if (ddlLevelCode2.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objSales.SaleOrderInfoGet(ddlLevelCode1.SelectedItem.Value.ToString(), ddlLevelCode2.SelectedItem.Value.ToString(), "ALL", Resources.Resource.Deleted.ToString());
                            BindDropDown(ddlLevelCode, "SONO", "SONO", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "AsmtId":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId" &&
                        ddlLevel2.SelectedItem.Value.ToString() == "ClientCode")
                    {
                        if (ddlLevelCode2.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objSales.ClientAsmtIdsGet(ddlLevelCode1.SelectedItem.Value.ToString(),
                                                              ddlLevelCode2.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "AsmtId", "AsmtIdAddress", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "AsmtCode":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId" &&
                        ddlLevel2.SelectedItem.Value.ToString() == "ClientCode")
                    {
                        if (ddlLevelCode2.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objOperationManagement.OpsAsmtCodeAddressGet(
                                ddlLevelCode1.SelectedItem.Value.ToString(), ddlLevelCode2.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "AsmtCode", "AsmtDesc", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                case "PostAutoId":
                    if (ddlLevel1.SelectedItem.Value.ToString() == "LocationAutoId" &&
                        ddlLevel2.SelectedItem.Value.ToString() == "ClientCode" &&
                        ddlLevel3.SelectedItem.Value.ToString() == "AsmtId")
                    {
                        if (ddlLevelCode3.SelectedItem.Value.ToString() != @"ALL")
                        {
                            ds = objSales.PostGetAll(int.Parse(ddlLevelCode1.SelectedItem.Value),
                                                        ddlLevelCode2.SelectedItem.Value.ToString(),
                                                        ddlLevelCode3.SelectedItem.Value.ToString());
                            BindDropDown(ddlLevelCode, "PostAutoId", "PostDesc", ds);
                        }
                        else { BindDropDownOnlyALL(ddlLevelCode); }
                    }
                    else
                    {
                        BindDropDownNoDataToShow(ddlLevelCode);
                    }
                    ddlLevelCode.SelectedIndex = 0;
                    break;
                default:

                    ddlLevelCode.Items.Clear();
                    RadComboBoxItem li = new RadComboBoxItem {Text = @"Not Selected", Value = @""};
                    ddlLevelCode.Items.Add(li);
                    ddlLevelCode.SelectedIndex = 0;
                    break;
            }
        }

    }

    /// <summary>
    /// Handles the RowDataBound event of the gvParamValue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvParamValue_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            RadComboBox ddlLevel1 = (RadComboBox)e.Row.FindControl("ddlLevel1");
            RadComboBox ddlLevel2 = (RadComboBox)e.Row.FindControl("ddlLevel2");
            RadComboBox ddlLevel3 = (RadComboBox)e.Row.FindControl("ddlLevel3");
            RadComboBox ddlLevel4 = (RadComboBox)e.Row.FindControl("ddlLevel4");

            HiddenField hfLevel1 = (HiddenField) e.Row.FindControl("hfLevel1");
            HiddenField hfLevel2 = (HiddenField)e.Row.FindControl("hfLevel2");
            HiddenField hfLevel3 = (HiddenField)e.Row.FindControl("hfLevel3");
            HiddenField hfLevel4 = (HiddenField)e.Row.FindControl("hfLevel4");

            RadComboBox ddlLevelCode1 = (RadComboBox)e.Row.FindControl("ddlLevelCode1");
            RadComboBox ddlLevelCode2 = (RadComboBox)e.Row.FindControl("ddlLevelCode2");
            RadComboBox ddlLevelCode3 = (RadComboBox)e.Row.FindControl("ddlLevelCode3");
            RadComboBox ddlLevelCode4 = (RadComboBox)e.Row.FindControl("ddlLevelCode4");

            HiddenField hfLevelCode1 = (HiddenField)e.Row.FindControl("hfLevelCode1");
            HiddenField hfLevelCode2 = (HiddenField)e.Row.FindControl("hfLevelCode2");
            HiddenField hfLevelCode3 = (HiddenField)e.Row.FindControl("hfLevelCode3");
            HiddenField hfLevelCode4 = (HiddenField)e.Row.FindControl("hfLevelCode4");

            TextBox txtParamValue1 = (TextBox)e.Row.FindControl("txtParamValue1");
            TextBox txtParamValue2 = (TextBox)e.Row.FindControl("txtParamValue2");
            TextBox txtParamValue3 = (TextBox)e.Row.FindControl("txtParamValue3");
            TextBox txtParamValue4 = (TextBox)e.Row.FindControl("txtParamValue4");

            CheckBox cbIsActive = (CheckBox)e.Row.FindControl("cbIsActive");
            Label lblParamCode = (Label)e.Row.FindControl("lblParamCode");

            FillddlLevel1(ddlLevel1);
            if (ddlLevel1 != null && hfLevel1 != null)
                ddlLevel1.SelectedIndex = ddlLevel1.Items.IndexOf(ddlLevel1.Items.FindItemByValue(hfLevel1.Value.ToString()));
            FillddlLevelCode1(ddlLevel1, ddlLevelCode1, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
            if (ddlLevelCode1 != null && hfLevelCode1 != null)
                ddlLevelCode1.SelectedIndex = ddlLevelCode1.Items.IndexOf(ddlLevelCode1.Items.FindItemByValue(hfLevelCode1.Value.ToString()));

            FillddlLevel2(ddlLevel1, ddlLevel2);
            if (ddlLevel2 != null && hfLevel2 != null)
                ddlLevel2.SelectedIndex = ddlLevel2.Items.IndexOf(ddlLevel2.Items.FindItemByValue(hfLevel2.Value.ToString()));
            FillddlLevelCode1(ddlLevel2, ddlLevelCode2, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
            if (ddlLevelCode2 != null && hfLevelCode2 != null)
                ddlLevelCode2.SelectedIndex = ddlLevelCode2.Items.IndexOf(ddlLevelCode2.Items.FindItemByValue(hfLevelCode2.Value.ToString()));

            FillddlLevel3(ddlLevel2, ddlLevel3);
            if (ddlLevel3 != null && hfLevel3 != null)
                ddlLevel3.SelectedIndex = ddlLevel3.Items.IndexOf(ddlLevel3.Items.FindItemByValue(hfLevel3.Value.ToString()));
            FillddlLevelCode1(ddlLevel3, ddlLevelCode3, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
            if (ddlLevelCode3 != null && hfLevelCode3 != null)
                ddlLevelCode3.SelectedIndex = ddlLevelCode3.Items.IndexOf(ddlLevelCode3.Items.FindItemByValue(hfLevelCode3.Value.ToString()));

            FillddlLevel4(ddlLevel3, ddlLevel4);
            if (ddlLevel4 != null && hfLevel4 != null)
                ddlLevel4.SelectedIndex = ddlLevel4.Items.IndexOf(ddlLevel4.Items.FindItemByValue(hfLevel4.Value.ToString()));
            FillddlLevelCode1(ddlLevel4, ddlLevelCode4, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
            if (ddlLevelCode4 != null && hfLevelCode4 != null)
                ddlLevelCode4.SelectedIndex = ddlLevelCode4.Items.IndexOf(ddlLevelCode4.Items.FindItemByValue(hfLevelCode4.Value.ToString()));

            string strValidationExpression = string.Empty;
            if (hfDataType.Value.ToString() == "Text")
            {
                strValidationExpression = Resources.Resource.ValidationExpressionString;
            }
            //if (hfDataType.Value.ToString() == "WeekDay") 
            //{
            //    strValidationExpression = "[Sun-Sat]";
            //}
            if (hfDataType.Value.ToString() == "Boolean")
            {
                strValidationExpression = "[0-1]";
            }
            if (hfDataType.Value.ToString() == "Date" || hfDataType.Value.ToString() == "DateRange")
            {
                strValidationExpression = @"^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$";
                //strValidationExpression =@"^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$";
                //@"/(?:0[1-9]|[12][0-9]|3[01])\/(?:0[1-9]|1[0-2])\/(?:19|20\d{2})/";
            }
            if (hfDataType.Value.ToString() == "Value"
                || hfDataType.Value.ToString() == "ValueRange"
                || hfDataType.Value.ToString() == "Percentage")
            {
                strValidationExpression = Resources.Resource.ValidationExpressionFloat;
            }

            SetValidationToTextBox(txtParamValue1, strValidationExpression);
            SetValidationToTextBox(txtParamValue2, strValidationExpression);
            SetValidationToTextBox(txtParamValue3, strValidationExpression);
            SetValidationToTextBox(txtParamValue4, strValidationExpression);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            
                if (hfIsEditable.Value.ToString() != "" && bool.Parse(hfIsEditable.Value.ToString()) != true)
                {
                    gvParamValue.ShowFooter= false;
                    gvParamValue.Columns[14].Visible = false;
                }
                else
                {
                    if (hfUserLevel.Value.ToString() == "U" &&
                        (BaseIsAdmin == "U" || BaseIsAdmin == "A" || BaseIsAdmin == "SU" || BaseIsAdmin == "SA"))
                    {
                        gvParamValue.ShowFooter= true;
                        gvParamValue.Columns[14].Visible = true;
                    }
                    else if (hfUserLevel.Value.ToString() == "A" &&
                             (BaseIsAdmin == "A" || BaseIsAdmin == "SU" || BaseIsAdmin == "SA"))
                    {
                        gvParamValue.ShowFooter= true;
                        gvParamValue.Columns[14].Visible = true;
                    }
                    else if (hfUserLevel.Value.ToString() == "SU" && (BaseIsAdmin == "SU" || BaseIsAdmin == "SA"))
                    {
                        gvParamValue.ShowFooter= true;
                        gvParamValue.Columns[14].Visible = true;
                    }
                    else if (hfUserLevel.Value.ToString() == "SA")
                    {
                        gvParamValue.ShowFooter= true;
                        gvParamValue.Columns[14].Visible = true;
                    }
                    else
                    {
                        gvParamValue.ShowFooter= false;
                        gvParamValue.Columns[14].Visible = false;
                    }
                }
                if (BaseIsAdmin == "SA")
                {
                    gvParamValue.ShowFooter = true;
                    gvParamValue.Columns[14].Visible = true;
                }
            

            RadComboBox ddlLevel1 = (RadComboBox)e.Row.FindControl("ddlLevel1");
            RadComboBox ddlLevel2 = (RadComboBox)e.Row.FindControl("ddlLevel2");
            RadComboBox ddlLevel3 = (RadComboBox)e.Row.FindControl("ddlLevel3");
            RadComboBox ddlLevel4 = (RadComboBox)e.Row.FindControl("ddlLevel4");

            RadComboBox ddlLevelCode1 = (RadComboBox)e.Row.FindControl("ddlLevelCode1");
            RadComboBox ddlLevelCode2 = (RadComboBox)e.Row.FindControl("ddlLevelCode2");
            RadComboBox ddlLevelCode3 = (RadComboBox)e.Row.FindControl("ddlLevelCode3");
            RadComboBox ddlLevelCode4 = (RadComboBox)e.Row.FindControl("ddlLevelCode4");

            TextBox txtParamValue1 = (TextBox)e.Row.FindControl("txtParamValue1");
            TextBox txtParamValue2 = (TextBox)e.Row.FindControl("txtParamValue2");
            TextBox txtParamValue3 = (TextBox)e.Row.FindControl("txtParamValue3");
            TextBox txtParamValue4 = (TextBox)e.Row.FindControl("txtParamValue4");

            CheckBox cbIsActive = (CheckBox)e.Row.FindControl("cbIsActive");
            Label lblParamCode = (Label)e.Row.FindControl("lblParamCode");

            FillddlLevel1(ddlLevel1);
            FillddlLevel2(ddlLevel1, ddlLevel2);
            FillddlLevel3(ddlLevel2, ddlLevel3);
            FillddlLevel4(ddlLevel3, ddlLevel4);

            FillddlLevelCode1(ddlLevel1, ddlLevelCode1, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
            FillddlLevelCode1(ddlLevel2, ddlLevelCode2, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
            FillddlLevelCode1(ddlLevel3, ddlLevelCode3, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
            FillddlLevelCode1(ddlLevel4, ddlLevelCode4, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);

            string strValidationExpression = string.Empty;
            if (hfDataType.Value.ToString() == "Text")
            {
                strValidationExpression = Resources.Resource.ValidationExpressionString;
            }
            //if(hfDataType.Value.ToString() == "WeekDay")
            //{
            //    strValidationExpression = "[Sun-Sat]";
            //}
            if (hfDataType.Value.ToString() == "Boolean")
            {
                strValidationExpression ="[0-1]";
            }
            if (hfDataType.Value.ToString() == "Date" || hfDataType.Value.ToString() == "DateRange")
            {
                strValidationExpression = @"^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$";
            }
            if (hfDataType.Value.ToString() == "Value"
                || hfDataType.Value.ToString() == "ValueRange"
                || hfDataType.Value.ToString() == "Percentage")
            {
                strValidationExpression = Resources.Resource.ValidationExpressionFloat;
            }
            
            SetValidationToTextBox(txtParamValue1, strValidationExpression);
            SetValidationToTextBox(txtParamValue2, strValidationExpression);
            SetValidationToTextBox(txtParamValue3, strValidationExpression);
            SetValidationToTextBox(txtParamValue4, strValidationExpression);
            
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvParamValue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvParamValue_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvParamValue.EditIndex = -1;
        FillgvParamValue(lblhdrParamCode.Text);
    }
    /// <summary>
    /// Handles the RowCommand event of the gvParamValue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvParamValue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        // To Insert a New Row
        DataSet ds = new DataSet();

        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel1");
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel4");

        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode4");

        TextBox txtParamValue1 = (TextBox)gvParamValue.FooterRow.FindControl("txtParamValue1");
        TextBox txtParamValue2 = (TextBox)gvParamValue.FooterRow.FindControl("txtParamValue2");
        TextBox txtParamValue3 = (TextBox)gvParamValue.FooterRow.FindControl("txtParamValue3");
        TextBox txtParamValue4 = (TextBox)gvParamValue.FooterRow.FindControl("txtParamValue4");

        CheckBox cbIsActive = (CheckBox)gvParamValue.FooterRow.FindControl("cbIsActive");
        

        if (e.CommandName == "Add")
        {
            if (hfImplementationLevel.Value == ddlLevel1.SelectedItem.Value.ToString() ||
                hfImplementationLevel.Value == ddlLevel2.SelectedItem.Value.ToString() ||
                hfImplementationLevel.Value == ddlLevel3.SelectedItem.Value.ToString() ||
                hfImplementationLevel.Value == ddlLevel4.SelectedItem.Value.ToString())
            {
                ds = objUserManagement.SystemParameterValuesAdd(ddlLevel1.SelectedItem.Value.ToString(), ddlLevelCode1.SelectedItem.Value.ToString(),
                    ddlLevel2.SelectedItem.Value.ToString(), ddlLevelCode2.SelectedItem.Value.ToString(),
                    ddlLevel3.SelectedItem.Value.ToString(), ddlLevelCode3.SelectedItem.Value.ToString(),
                    ddlLevel4.SelectedItem.Value.ToString(), ddlLevelCode4.SelectedItem.Value.ToString(),
                    lblhdrParamCode.Text, cbIsActive.Checked.ToString(),
                    txtParamValue1.Text, txtParamValue2.Text, txtParamValue3.Text, txtParamValue4.Text,
                    BaseUserID.ToString());

                gvParamHead.EditIndex = -1;
                FillgvParamValue(lblhdrParamCode.Text);
                MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
            }
            else
            {
                DisplayMessageString(lblErrMsg, "Please Select The Level Up To Implementation Level");
            }
        }
        if (e.CommandName == "Reset")
        {
            txtParamValue1.Text = "";
            txtParamValue2.Text = "";
            txtParamValue3.Text = "";
            txtParamValue4.Text = "";
            cbIsActive.Checked = false;
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvParamValue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvParamValue_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();
        HiddenField hfParamValuesAutoId = (HiddenField)gvParamValue.Rows[e.RowIndex].FindControl("hfParamValuesAutoId");

        ds = objUserManagement.SystemParameterValuesDelete(hfParamValuesAutoId.Value.ToString());
        FillgvParamValue(lblhdrParamCode.Text);
        MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvParamValue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvParamValue_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvParamValue.EditIndex = e.NewEditIndex;
        FillgvParamValue(lblhdrParamCode.Text);
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvParamValue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvParamValue_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();

        HiddenField hfParamValuesAutoId = (HiddenField)gvParamValue.Rows[e.RowIndex].FindControl("hfParamValuesAutoId");
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.Rows[e.RowIndex].FindControl("ddlLevel1");
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.Rows[e.RowIndex].FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.Rows[e.RowIndex].FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.Rows[e.RowIndex].FindControl("ddlLevel4");

        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.Rows[e.RowIndex].FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.Rows[e.RowIndex].FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.Rows[e.RowIndex].FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.Rows[e.RowIndex].FindControl("ddlLevelCode4");

        TextBox txtParamValue1 = (TextBox)gvParamValue.Rows[e.RowIndex].FindControl("txtParamValue1");
        TextBox txtParamValue2 = (TextBox)gvParamValue.Rows[e.RowIndex].FindControl("txtParamValue2");
        TextBox txtParamValue3 = (TextBox)gvParamValue.Rows[e.RowIndex].FindControl("txtParamValue3");
        TextBox txtParamValue4 = (TextBox)gvParamValue.Rows[e.RowIndex].FindControl("txtParamValue4");

        CheckBox cbIsActive = (CheckBox)gvParamValue.Rows[e.RowIndex].FindControl("cbIsActive");
        Label lblParamCode = (Label)gvParamValue.Rows[e.RowIndex].FindControl("lblParamCode");

        ds = objUserManagement.SystemParameterValuesUpdate(hfParamValuesAutoId.Value, 
            ddlLevel1.SelectedItem.Value.ToString(), ddlLevelCode1.SelectedItem.Value.ToString(),
            ddlLevel2.SelectedItem.Value.ToString(), ddlLevelCode2.SelectedItem.Value.ToString(),
            ddlLevel3.SelectedItem.Value.ToString(), ddlLevelCode3.SelectedItem.Value.ToString(),
            ddlLevel4.SelectedItem.Value.ToString(), ddlLevelCode4.SelectedItem.Value.ToString(),
            lblParamCode.Text, cbIsActive.Checked.ToString(), 
            txtParamValue1.Text, txtParamValue2.Text, txtParamValue3.Text, txtParamValue4.Text,
            BaseUserID.ToString());

        gvParamValue.EditIndex = -1;
        FillgvParamValue(lblhdrParamCode.Text);
        MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvParamValue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvParamValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvParamValue.PageIndex = e.NewPageIndex;
        FillgvParamValue(lblhdrParamCode.Text);
    }
    /// <summary>
    /// Sets the validation to text box.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    /// <param name="strValidationExpression">The STR validation expression.</param>
    protected void SetValidationToTextBox(TextBox textBox, string strValidationExpression)
    {
        if (textBox != null && strValidationExpression != "")
        {
            textBox.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + strValidationExpression + ");";
            textBox.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + strValidationExpression + ");";
        }
    }
    #endregion

    #region Dropdown Change Events

    /// <summary>
    /// Handles the ETSelectedIndexChanged event of the ddlLevel1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevel1_ETSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevel1 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevel1.NamingContainer;
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel4");
        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode4");

        FillddlLevelCode1(ddlLevel1, ddlLevelCode1, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel2(ddlLevel1, ddlLevel2);
    }
    /// <summary>
    /// Handles the FTSelectedIndexChanged event of the ddlLevel1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevel1_FTSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevel1 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevel1.NamingContainer;
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel4");

        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode4");

        FillddlLevelCode1(ddlLevel1, ddlLevelCode1, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel2(ddlLevel1, ddlLevel2);
    }
    /// <summary>
    /// Handles the ETSelectedIndexChanged event of the ddlLevelCode1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevelCode1_ETSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevelCode1 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevelCode1.NamingContainer;
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel1");
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel4");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode4");

        //FillddlLevelCode1(ddlLevel1, ddlLevelCode1, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel2(ddlLevel1, ddlLevel2);
    }
    /// <summary>
    /// Handles the FTSelectedIndexChanged event of the ddlLevelCode1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevelCode1_FTSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevelCode1 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevelCode1.NamingContainer;
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel1");
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel4");

        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode4");

        //FillddlLevelCode1(ddlLevel1, ddlLevelCode1, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel2(ddlLevel1, ddlLevel2);
    }


    /// <summary>
    /// Handles the ETSelectedIndexChanged event of the ddlLevel2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevel2_ETSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevel2 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevel2.NamingContainer;
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel1");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel4");
        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode4");

        FillddlLevelCode1(ddlLevel2, ddlLevelCode2, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel3(ddlLevel2, ddlLevel3);
    }
    /// <summary>
    /// Handles the FTSelectedIndexChanged event of the ddlLevel2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevel2_FTSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevel2 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevel2.NamingContainer;
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel1");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel4");

        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode4");

        FillddlLevelCode1(ddlLevel2, ddlLevelCode2, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel3(ddlLevel2, ddlLevel3);
    }
    /// <summary>
    /// Handles the ETSelectedIndexChanged event of the ddlLevelCode2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevelCode2_ETSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevelCode2 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevelCode2.NamingContainer;
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel1");
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel4");
        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode4");

        //FillddlLevelCode1(ddlLevel2, ddlLevelCode2, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel3(ddlLevel2, ddlLevel3);
    }
    /// <summary>
    /// Handles the FTSelectedIndexChanged event of the ddlLevelCode2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevelCode2_FTSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevelCode2 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevelCode2.NamingContainer;
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel1");
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel4");

        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode4");

        //FillddlLevelCode1(ddlLevel2, ddlLevelCode2, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel3(ddlLevel2, ddlLevel3);
    }


    /// <summary>
    /// Handles the ETSelectedIndexChanged event of the ddlLevel3 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevel3_ETSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevel3 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevel3.NamingContainer;
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel2");
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel1");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel4");
        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode4");

        FillddlLevelCode1(ddlLevel3, ddlLevelCode3, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel4(ddlLevel3, ddlLevel4);
    }
    /// <summary>
    /// Handles the FTSelectedIndexChanged event of the ddlLevel3 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevel3_FTSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevel3 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevel3.NamingContainer;
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel2");
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel1");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel4");

        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode4");

        FillddlLevelCode1(ddlLevel3, ddlLevelCode3, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel4(ddlLevel3, ddlLevel4);
    }
    /// <summary>
    /// Handles the ETSelectedIndexChanged event of the ddlLevelCode3 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevelCode3_ETSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevelCode3 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevelCode3.NamingContainer;
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel1");
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel4");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode4");

        //FillddlLevelCode1(ddlLevel3, ddlLevelCode3, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel4(ddlLevel3, ddlLevel4);
    }
    /// <summary>
    /// Handles the FTSelectedIndexChanged event of the ddlLevelCode3 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevelCode3_FTSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevelCode3 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevelCode3.NamingContainer;
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel1");
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel2");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel3");
        RadComboBox ddlLevel4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel4");

        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode4");

        //FillddlLevelCode1(ddlLevel1, ddlLevelCode1, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
        FillddlLevel4(ddlLevel3, ddlLevel4);
    }


    /// <summary>
    /// Handles the ETSelectedIndexChanged event of the ddlLevel4 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevel4_ETSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevel4 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevel4.NamingContainer;
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel2");
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel1");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevel3");
        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.Rows[gvRow.RowIndex].FindControl("ddlLevelCode4");

        FillddlLevelCode1(ddlLevel4, ddlLevelCode4, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
    }
    /// <summary>
    /// Handles the FTSelectedIndexChanged event of the ddlLevel4 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevel4_FTSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadComboBox ddlLevel4 = (RadComboBox)sender;
        GridViewRow gvRow = (GridViewRow)ddlLevel4.NamingContainer;
        RadComboBox ddlLevel2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel2");
        RadComboBox ddlLevel1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel1");
        RadComboBox ddlLevel3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevel3");

        RadComboBox ddlLevelCode1 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode1");
        RadComboBox ddlLevelCode2 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode2");
        RadComboBox ddlLevelCode3 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode3");
        RadComboBox ddlLevelCode4 = (RadComboBox)gvParamValue.FooterRow.FindControl("ddlLevelCode4");

        FillddlLevelCode1(ddlLevel4, ddlLevelCode4, ddlLevel1, ddlLevelCode1, ddlLevel2, ddlLevelCode2, ddlLevel3, ddlLevelCode3, ddlLevel4, ddlLevelCode4);
    }
    /// <summary>
    /// Handles the ETSelectedIndexChanged event of the ddlLevelCode4 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevelCode4_ETSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    /// <summary>
    /// Handles the FTSelectedIndexChanged event of the ddlLevelCode4 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLevelCode4_FTSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    #endregion
}