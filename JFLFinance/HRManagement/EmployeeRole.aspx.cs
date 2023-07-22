// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
// Description      : Is used to handle the event actions and communicate to and UI Screen.
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="EmployeeRole.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


/// <summary>
/// HR Management Employee Role Code Behind
/// </summary>
public partial class HRManagement_EmployeeRole : BasePage
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
    /// Button proceed click event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        gvEmployeeRole.PageIndex = 0;
        FillgvEmployeeRole();
    }
    /// <summary>
    /// Button search weekoff click event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void btnSearchWeekOff_Click(object sender, EventArgs e)
    {
        SearchAction();
    }

    /// <summary>
    /// Button Reset click event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
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
            javaScript.Append("PageTitle('" + Resources.Resource.ChangeEmployeeRole + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());



            if (IsReadAccess == true)
            {
                FillgvEmployeeRole();
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
    /// This is used for filling Grid of Employees role
    /// </summary>
    protected void FillgvEmployeeRole()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet dsEmployeeRole = new DataSet();
        DataTable dtEmployeeRole = new DataTable();
        int dtflag;
        dtflag = 1;
        dsEmployeeRole = objHRManagement.EmployeeRoleGetAll (BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
        dtEmployeeRole = dsEmployeeRole.Tables[0];

        if (dtEmployeeRole.Rows.Count == 0)
        {
            dtflag = 0;
            dtEmployeeRole.Rows.Add(dtEmployeeRole.NewRow());
        }
        gvEmployeeRole.DataKeyNames = new string[] { "RoleDesc" };
        gvEmployeeRole.DataSource = dtEmployeeRole;
        gvEmployeeRole.DataBind();

        if (dtflag == 0)
        {
            gvEmployeeRole.Rows[0].Visible = false;
        }
        FillSearchDropDownList();
    }
    /// <summary>
    /// This method is used for search action
    /// </summary>
    protected void SearchAction()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet dsEmployeeRole = new DataSet();
        DataTable dtEmployeeRole = new DataTable();
        int dtflag;
        dtflag = 1;
        dsEmployeeRole = objHRManagement.EmployeeRoleGetAll(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
        dtEmployeeRole = dsEmployeeRole.Tables[0];

        if (dtEmployeeRole.Rows.Count == 0)
        {
            dtflag = 0;
            dtEmployeeRole.Rows.Add(dtEmployeeRole.NewRow());
        }
        gvEmployeeRole.DataKeyNames = new string[] { "RoleDesc" };
        gvEmployeeRole.DataSource = dtEmployeeRole;


        //To Filter or Search the Employees in DataTable *********************
        DataView dvNew = new DataView(dtEmployeeRole);
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
        gvEmployeeRole.DataSource = dvNew;
        gvEmployeeRole.DataBind();


    }
    /// <summary>
    /// This is used for filling search drop down list
    /// </summary>
    private void FillSearchDropDownList()
    {
        SortedList sl = new SortedList();
        BL.Common objCommon = new BL.Common();
        sl = objCommon.OperatorNameGet("String");
        ddlSearchEmpNumberCON.Items.Clear();
        foreach (DictionaryEntry item in sl)
        {
            ListItem LI = new ListItem();
            if (sl[item.Key] == item.Value)
            {
                if (item.Value == "Not Equal To")
                {
                    LI.Text = Resources.Resource.NotEqualTo;
                }
                else if (item.Value == "Equal To")
                {
                    LI.Text = Resources.Resource.EqualTo;
                }
                else if (item.Value == "Like")
                {
                    LI.Text = Resources.Resource.Like;
                }
                else if (item.Value == "Not Like")
                {
                    LI.Text = Resources.Resource.NotLike;
                }
                LI.Value = item.Key.ToString();
                ddlSearchEmpNumberCON.Items.Add(LI);
                ddlSearchFirstNameCON.Items.Add(LI);
                ddlSearchLastNameCON.Items.Add(LI);
            }
        }

        sl = objCommon.OperatorNameGet("AndOrOperator");
        ddlSearchEmpNumberOPR.Items.Clear();
        foreach (DictionaryEntry item in sl)
        {
            ListItem LI = new ListItem();
            if (sl[item.Key] == item.Value)
            {
                if (item.Value.ToString() == "AND")
                {
                    LI.Text = Resources.Resource.AND;
                }
                else if (item.Value.ToString() == "OR")
                {
                    LI.Text = Resources.Resource.OR;
                }
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
    /// The RowDataBound event is raised when a data row is bound to data in the GridView control.
    /// </summary>
    /// <param name="sender">GridView  object</param>
    /// <param name="e">GridView Event</param>
    protected void gvEmployeeRole_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerial");
            if (lblSerialNo != null)
            {
                int serialNo = gvEmployeeRole.PageIndex * gvEmployeeRole.PageSize + int.Parse(e.Row.RowIndex.ToString());
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
                DropDownList cmbType = (DropDownList)e.Row.FindControl("cmbFutureRole");
                HyperLink imgEffectiveToDate = (HyperLink)e.Row.FindControl("imgEffectiveToDate");

                TextBox txtEffectiveTo = (TextBox)e.Row.FindControl("txtEffectiveTo");
                Label lblEffectiveFrom = (Label)e.Row.FindControl("lblEffectiveFrom");
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");

                if (txtEffectiveTo != null && imgEffectiveToDate != null)
                {
                    txtEffectiveTo.Attributes.Add("readonly", "readonly");
                    imgEffectiveToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtEffectiveTo.ClientID.ToString() + "');";
                }
                if (cmbType != null)
                {
                    cmbType.DataSource = objMastersManagement.RoleMasterGet(BaseCompanyCode.ToString());
                    cmbType.DataValueField = "RoleCode";
                    cmbType.DataTextField = "RoleDesc";
                    cmbType.DataBind();
                }
            }

        }

    }
    /// <summary>
    /// The RowUpdating event is raised when a data row is updated.
    /// </summary>
    /// <param name="sender">GridView object</param>
    /// <param name="e">GridView Event</param>
    protected void gvEmployeeRole_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strFutureRole;
        BL.HRManagement objMasterManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        Label lblEmployeeNumber = (Label)gvEmployeeRole.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        Label lblRoleCode = (Label)gvEmployeeRole.Rows[e.RowIndex].FindControl("lblRoleCode");
        Label lblRoleDesc = (Label)gvEmployeeRole.Rows[e.RowIndex].FindControl("lblRoleDesc");
        TextBox txtEffectiveTo = (TextBox)gvEmployeeRole.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        Label lblEffectiveFrom = (Label)gvEmployeeRole.Rows[e.RowIndex].FindControl("lblEffectiveFrom");
        DropDownList cmbFutureRole = (DropDownList)gvEmployeeRole.Rows[e.RowIndex].FindControl("cmbFutureRole");
        strFutureRole = cmbFutureRole.SelectedValue.ToString();

        if (lblRoleCode.Text != strFutureRole)
        {
            if (CompareDates(DateTime.Parse(txtEffectiveTo.Text), DateTime.Parse(lblEffectiveFrom.Text)) == 1)
            {
                ds = objMasterManagement.EmployeeRoleUpdate(BaseCompanyCode, lblEmployeeNumber.Text,lblEmployeeNumber.Text, lblRoleCode.Text, strFutureRole, txtEffectiveTo.Text, BaseUserID, BaseCompanyCode);

                gvEmployeeRole.EditIndex = -1;
                FillgvEmployeeRole();

                gvEmployeeRole.Columns[7].Visible = false;
                gvEmployeeRole.Columns[8].Visible = false;

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
    /// The RowEditing event
    /// </summary>
    /// <param name="sender">GridView object</param>
    /// <param name="e">GridView Event</param>
    protected void gvEmployeeRole_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployeeRole.Columns[6].Visible = true;
        gvEmployeeRole.Columns[7].Visible = true;
        gvEmployeeRole.EditIndex = e.NewEditIndex;
        SearchAction();
    }

    /// <summary>
    /// The RowCancelingEdit event
    /// </summary>
    /// <param name="sender">GridView object</param>
    /// <param name="e">GridView  Event</param>
    protected void gvEmployeeRole_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmployeeRole.Columns[7].Visible = false;
        gvEmployeeRole.Columns[8].Visible = false;
        gvEmployeeRole.EditIndex = -1;
        FillgvEmployeeRole();
    }

    /// <summary>
    /// The Page Index Changing event
    /// </summary>
    /// <param name="sender">GridView object</param>
    /// <param name="e">GridView Event</param>
    protected void gvEmployeeRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeRole.PageIndex = e.NewPageIndex;
        gvEmployeeRole.EditIndex = -1;
        FillgvEmployeeRole();
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
