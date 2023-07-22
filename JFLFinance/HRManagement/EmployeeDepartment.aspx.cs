// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeDepartment.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;


/// <summary>
/// Class HRManagement_EmployeeDepartment
/// </summary>
public partial class HRManagement_EmployeeDepartment : BasePage 
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

    #region Page Buttons events
    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        gvEmployeeDepartment.PageIndex = 0;
        FillgvEmployeeDepartment();
    }
    /// <summary>
    /// Handles the Click event of the btnSearchEmp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearchEmp_Click(object sender, EventArgs e)
    {
        gvEmployeeDepartment.PageIndex = 0;
        FillgvEmployeeDepartment();
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtEmpNumber.Text = "";
        txtEmpFirstName.Text = "";
        txtEmpLastName.Text = "";
    }
    #endregion

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
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ChangeEmployeeDepartment + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvEmployeeDepartment();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }
    #endregion

    #region GridView Binding
    /// <summary>
    /// Fill Employee Department grid
    /// </summary>
    protected void FillgvEmployeeDepartment()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet dsEmployeeDepartment = new DataSet();
        DataTable dtEmployeeDepartment = new DataTable();
        int dtflag;
        dtflag = 1;
        dsEmployeeDepartment = objHRManagement.EmployeeDepartmentGetAll(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
        dtEmployeeDepartment = dsEmployeeDepartment.Tables[0];
        if (dtEmployeeDepartment.Rows.Count == 0)
        {
            dtflag = 0;
            dtEmployeeDepartment.Rows.Add(dtEmployeeDepartment.NewRow());
        }
        gvEmployeeDepartment.DataKeyNames = new string[] { "DepartmentName" };
        gvEmployeeDepartment.DataSource = dtEmployeeDepartment;
        DataView dvNew = new DataView(dtEmployeeDepartment);
        dvNew.RowFilter = "";
        string strFilterStatement = "";

        if (txtEmpNumber.Text.Length > 0)
        {
            strFilterStatement = strFilterStatement + " [EmployeeNumber] " + ddlSearchEmpNumberCON.SelectedItem.Value.ToString() + "'" + txtEmpNumber.Text + "'";
        }
        if (txtEmpFirstName.Text.Length > 0)
        {
            if (strFilterStatement.Length > 0)
            {
                strFilterStatement = strFilterStatement + " " + ddlSearchFirstNameOPR.SelectedItem.Value.ToString();
            }
            strFilterStatement = strFilterStatement + " [Name] " + ddlSearchFirstNameCON.SelectedItem.Value.ToString() + "'" + txtEmpFirstName.Text + "'";
        }
        if (txtEmpLastName.Text.Length > 0)
        {
            if (strFilterStatement.Length > 0)
            {
                strFilterStatement = strFilterStatement + " " + ddlSearchLastNameOPR.SelectedItem.Value.ToString();
            }
            strFilterStatement = strFilterStatement + " [Name] " + ddlSearchLastNameCON.SelectedItem.Value.ToString() + "'" + txtEmpLastName.Text + "'";
        }

        dvNew.RowFilter = strFilterStatement;
        gvEmployeeDepartment.DataSource = dvNew;
        gvEmployeeDepartment.DataBind();

        if (dtflag == 0)
        {
            gvEmployeeDepartment.Rows[0].Visible = false;
        }
        FillSearchDropDownList();
    }
    /// <summary>
    /// Fill Search drop down
    /// </summary>
    private void FillSearchDropDownList()
    {
        SortedList sl = new SortedList();
        BL.Common objCommon = new BL.Common();
        sl = objCommon.OperatorNameGet("String");

        foreach (DictionaryEntry item in sl)
        {
            ListItem LI = new ListItem();
            if (sl[item.Key] == item.Value)
            {
                LI.Text = item.Value.ToString();
                LI.Value = item.Key.ToString();
                ddlSearchEmpNumberCON.Items.Add(LI);
                ddlSearchFirstNameCON.Items.Add(LI);
                ddlSearchLastNameCON.Items.Add(LI);
            }
        }

        sl = objCommon.OperatorNameGet("AndOrOperator");

        foreach (DictionaryEntry item in sl)
        {
            ListItem LI = new ListItem();
            if (sl[item.Key] == item.Value)
            {
                LI.Text = item.Value.ToString();
                LI.Value = item.Key.ToString();
                ddlSearchEmpNumberOPR.Items.Add(LI);
                ddlSearchFirstNameOPR.Items.Add(LI);
                ddlSearchLastNameOPR.Items.Add(LI);
            }
        }
    }
    #endregion

    #region GridView Commands Events
    /// <summary>
    /// Handles the RowDataBound event of the gvEmployeeDepartment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerial");
            if (lblSerialNo != null)
            {
                int serialNo = gvEmployeeDepartment.PageIndex * gvEmployeeDepartment.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
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
                BL.MastersManagement objMastersManagement = new BL.MastersManagement();
                DropDownList cmbType = (DropDownList)e.Row.FindControl("cmbFutureDepartment");

                TextBox txtEffectiveTo = (TextBox)e.Row.FindControl("txtEffectiveTo");
                Label lblEffectiveFrom = (Label)e.Row.FindControl("lblEffectiveFrom");
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");

                if (lblEffectiveFrom != null && txtEffectiveTo != null && ImgbtnUpdate != null)
                {
                  
                }
                if (cmbType != null)
                {
                    cmbType.DataSource = objMastersManagement.DepartmentGetAll(BaseCompanyCode.ToString());
                    cmbType.DataValueField = "DepartmentCode";
                    cmbType.DataTextField = "DepartmentName";
                    cmbType.DataBind();
                }
            }
        }

    }
    /// <summary>
    /// The RowEditing event is raised when a row's Edit button is clicked, but before the GridView control enters edit mode
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDepartment_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strFutureDepartment;
        BL.HRManagement objMasterManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        Label lblEmployeeNumber = (Label)gvEmployeeDepartment.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        Label lblDepartmentCode = (Label)gvEmployeeDepartment.Rows[e.RowIndex].FindControl("lblDepartmentCode");
        Label lblDepartmentDesc = (Label)gvEmployeeDepartment.Rows[e.RowIndex].FindControl("lblDepartmentDesc");
        TextBox txtEffectiveTo = (TextBox)gvEmployeeDepartment.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        Label lblEffectiveFrom = (Label)gvEmployeeDepartment.Rows[e.RowIndex].FindControl("lblEffectiveFrom");  
        DropDownList cmbFutureDepartment = (DropDownList)gvEmployeeDepartment.Rows[e.RowIndex].FindControl("cmbFutureDepartment");

        strFutureDepartment = cmbFutureDepartment.SelectedValue.ToString();
        if (lblDepartmentCode.Text != strFutureDepartment)
        {
            if (CompareDates(DateTime.Parse(txtEffectiveTo.Text), DateTime.Parse(lblEffectiveFrom.Text)) == 1)
            {
                ds = objMasterManagement.EmployeeDepartmentUpdate(BaseCompanyCode, lblEmployeeNumber.Text, lblDepartmentCode.Text, strFutureDepartment, txtEffectiveTo.Text, BaseUserID, BaseCompanyCode);

                gvEmployeeDepartment.EditIndex = -1;
                FillgvEmployeeDepartment();

                gvEmployeeDepartment.Columns[7].Visible = false;
                gvEmployeeDepartment.Columns[8].Visible = false;

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.ToDateMustBeGreaterThanFromDate);
            }
        }
    }
    /// <summary>
    /// The RowUpdating event is raised when a row's Update button is clicked, but before the GridView control updates the row.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDepartment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployeeDepartment.Columns[7].Visible = true;
        gvEmployeeDepartment.Columns[8].Visible = true;

        gvEmployeeDepartment.EditIndex = e.NewEditIndex;
        FillgvEmployeeDepartment();
    }
    /// <summary>
    /// Occurs when the Cancel button of a row in edit mode is clicked, but before the row exits edit mode
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmployeeDepartment.Columns[7].Visible = false;
        gvEmployeeDepartment.Columns[8].Visible = false;
        gvEmployeeDepartment.EditIndex = -1;
        FillgvEmployeeDepartment();
    }
    /// <summary>
    /// The PageIndexChanged event is raised when one of the pager buttons is clicked,
    /// but after the GridView control handles the paging operation
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeDepartment.PageIndex = e.NewPageIndex;
        gvEmployeeDepartment.EditIndex = -1;
        FillgvEmployeeDepartment();
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
