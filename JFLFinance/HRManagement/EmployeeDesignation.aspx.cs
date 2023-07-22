// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="EmployeeDesignation.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_EmployeeDesignation
/// </summary>
public partial class Masters_EmployeeDesignation : BasePage //System.Web.UI.Page
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
        gvEmployeeDesignation.PageIndex = 0;
        FillgvEmployeeDesignation();
    }
    /// <summary>
    /// Handles the Click event of the btnSearchWeekOff control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearchWeekOff_Click(object sender, EventArgs e)
    {
        gvEmployeeDesignation.PageIndex = 0;
        FillgvEmployeeDesignation();
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
            javaScript.Append("PageTitle('" + Resources.Resource.ChangeEmployeeDesignation + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillgvEmployeeDesignation();
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
    /// Fillgvs the employee designation.
    /// </summary>
    protected void FillgvEmployeeDesignation()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet dsEmployeeDesignation = new DataSet();
        DataTable dtEmployeeDesignation = new DataTable();
        int dtflag;
        dtflag = 1;
        dsEmployeeDesignation = objHRManagement.EmployeeDesignationGetAll(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
        dtEmployeeDesignation = dsEmployeeDesignation.Tables[0];

        if (dtEmployeeDesignation.Rows.Count == 0)
        {
            dtflag = 0;
            dtEmployeeDesignation.Rows.Add(dtEmployeeDesignation.NewRow());
        }
        gvEmployeeDesignation.DataKeyNames = new string[] { "DesignationDesc" };
        gvEmployeeDesignation.DataSource = dtEmployeeDesignation;

        //To Filter or Search the Employees in DataTable *********************
        DataView dvNew = new DataView(dtEmployeeDesignation);
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
        gvEmployeeDesignation.DataSource = dvNew;
        gvEmployeeDesignation.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvEmployeeDesignation.Rows[0].Visible = false;
        }
        FillSearchDropDownList();
    }
    /// <summary>
    /// Fills the search drop down list.
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
    /// Handles the RowDataBound event of the gvEmployeeDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDesignation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerial");
            if (lblSerialNo != null)
            {
                int serialNo = gvEmployeeDesignation.PageIndex * gvEmployeeDesignation.PageSize + int.Parse(e.Row.RowIndex.ToString());
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
                DropDownList cmbType = (DropDownList)e.Row.FindControl("cmbFutureDesignation");

                HyperLink imgEffectiveToDate = (HyperLink)e.Row.FindControl("imgEffectiveToDate");
                TextBox txtEffectiveTo = (TextBox)e.Row.FindControl("txtEffectiveTo");
                Label lblEffectiveFrom = (Label)e.Row.FindControl("lblEffectiveFrom");
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");

                if (txtEffectiveTo != null && imgEffectiveToDate != null)
                {
                    txtEffectiveTo.Attributes.Add("readonly", "readonly");
                    imgEffectiveToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtEffectiveTo.ClientID.ToString() + "');";
                }
                if (lblEffectiveFrom != null && txtEffectiveTo != null && ImgbtnUpdate != null)
                {
                             
                }

                if (cmbType != null)
                {
                    cmbType.DataSource = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode.ToString());
                    cmbType.DataValueField = "DesignationCode";
                    cmbType.DataTextField = "DesignationDesc";
                    cmbType.DataBind();
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowUpdating event of the gvEmployeeDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDesignation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strFutureDesignation;
        BL.HRManagement objMasterManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        Label lblEmployeeNumber = (Label)gvEmployeeDesignation.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        Label lblDesignationCode = (Label)gvEmployeeDesignation.Rows[e.RowIndex].FindControl("lblDesignationCode");
        Label lblDesignationDesc = (Label)gvEmployeeDesignation.Rows[e.RowIndex].FindControl("lblDesignationDesc");
        Label lblEffectiveFrom = (Label)gvEmployeeDesignation.Rows[e.RowIndex].FindControl("lblEffectiveFrom");  
        TextBox txtEffectiveTo = (TextBox)gvEmployeeDesignation.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        DropDownList cmbFutureDesignation = (DropDownList)gvEmployeeDesignation.Rows[e.RowIndex].FindControl("cmbFutureDesignation");

        strFutureDesignation = cmbFutureDesignation.SelectedValue.ToString();

        if (lblDesignationCode.Text != strFutureDesignation)
        {
            if (CompareDates(DateTime.Parse(txtEffectiveTo.Text), DateTime.Parse(lblEffectiveFrom.Text)) == 1)
            {
                ds = objMasterManagement.EmployeeDesignationUpdate(BaseCompanyCode, lblEmployeeNumber.Text, lblEmployeeNumber.Text, lblDesignationCode.Text, strFutureDesignation, txtEffectiveTo.Text, BaseUserID, BaseCompanyCode);

            gvEmployeeDesignation.EditIndex = -1;
            FillgvEmployeeDesignation();

            gvEmployeeDesignation.Columns[7].Visible = false;
            gvEmployeeDesignation.Columns[8].Visible = false;

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
    /// Handles the RowEditing event of the gvEmployeeDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDesignation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployeeDesignation.Columns[7].Visible = true;
        gvEmployeeDesignation.Columns[8].Visible = true;

        gvEmployeeDesignation.EditIndex = e.NewEditIndex;
        FillgvEmployeeDesignation();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvEmployeeDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDesignation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmployeeDesignation.Columns[7].Visible = false;
        gvEmployeeDesignation.Columns[8].Visible = false;
        gvEmployeeDesignation.EditIndex = -1;
        FillgvEmployeeDesignation();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmployeeDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeDesignation.PageIndex = e.NewPageIndex;
        gvEmployeeDesignation.EditIndex = -1;
        FillgvEmployeeDesignation();
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
    /// <summary>
    /// Handles the PageIndexChanging1 event of the gvEmployeeDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDesignation_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeDesignation.EditIndex = -1;
        gvEmployeeDesignation.PageIndex = e.NewPageIndex;
        FillgvEmployeeDesignation();
    }
}
