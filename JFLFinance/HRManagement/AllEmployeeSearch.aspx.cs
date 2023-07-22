// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="AllEmployeeSearch.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class HRManagement_AllEmployeeSearch
/// </summary>
public partial class HRManagement_AllEmployeeSearch : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// The ds emp list
    /// </summary>
    static DataSet dsEmpList = new DataSet();


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
            {

                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex);
            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex);

            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex);


            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex);

            }
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
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.SearchEmployee;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.SearchEmployee + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillIdType();
                FillgvEmployeeList();
                FillDivision();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

    }
    #endregion
    /// <summary>
    /// Fill Id type Dropdown
    /// </summary>
    private void FillIdType()
    {


        try
        {
            BL.HRManagement objHRManagement = new BL.HRManagement();
            DataSet ds = new DataSet();
            ds = objHRManagement.EmployeeIdTypeGet();
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                ddlIDType.DataSource = ds.Tables[0];
                ddlIDType.DataTextField = "IDTypeDesc";
                ddlIDType.DataValueField = "IDTypeCode";
                ddlIDType.DataBind();
            }
        }//End of Try 
        catch (Exception ex)
        {
            DataSet ds = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex.ToString(), BaseUserID);
            ds.Dispose();
        }

    }
    /// <summary>
    /// Fill Division Dropdown
    /// </summary>
    private void FillDivision()
    {

        try
        {
            DataSet dsDivision = new DataSet();
            BL.UserManagement objblUserManagement = new BL.UserManagement();
            dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
            ListItem li = new ListItem();

            if (dsDivision.Tables[0].Rows.Count > 0)
            {
                ddlDivision.DataSource = dsDivision.Tables[0];
                ddlDivision.DataValueField = "HrLocationCode";
                ddlDivision.DataTextField = "HrLocationDesc";
                ddlDivision.DataBind();
                li.Text = Resources.Resource.All;
                li.Value = "ALL";
                ddlDivision.Items.Insert(0, li);

            }
        }//End Try
        catch (Exception ex)
        {
            DataSet ds = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex.ToString(), BaseUserID);
            ds.Dispose();
        }
    }


    #region control events
    /// <summary>
    /// Filter data on search click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            BL.Search objSearch = new BL.Search();

            string strQuery = "";
            string strParaMeters = "";

            string strEmpNo = txtEmpNo.Text;
            string strEmpNoOpr = ddlEmpNoOP.SelectedValue;
            string strEmpName = txtEmployeeName.Text;
            string strEmpNameOpr = ddlEmployeeNameOP.SelectedValue;
            string strEmpDesg = txtEmpDesignation.Text;
            string strEmpDesgOpr = ddlDesignationOP.SelectedValue;
            string strDateOfJoin = txtDateOfJoining.Text;
            string strIdType = txtIDType.Text;
            string strIdTypeOpr = ddlIDTypeOP.SelectedValue;



            if (strEmpNo != "" && strEmpNoOpr == "Like")
            {
                strParaMeters = " EmployeeNumber = '" + strEmpNo + "' And ";
            }
            else if (strEmpNo != "" && strEmpNoOpr == "%Like%")
            {

                strParaMeters = " EmployeeNumber Like '%" + strEmpNo + "%' And ";
            }
            else if (strEmpNo != "" && strEmpNoOpr == "%Like")
            {

                strParaMeters = " EmployeeNumber Like '%" + strEmpNo + "' And ";
            }
            else if (strEmpNo != "" && strEmpNoOpr == "Like%")
            {

                strParaMeters = " EmployeeNumber Like '" + strEmpNo + "%' And ";
            }


            if (ddlDivision.SelectedValue != "ALL")
            {

                strParaMeters = " HrLocationCode = '" + ddlDivision.SelectedValue.ToString() + "' And ";
            }


            if (strEmpName != "" && strEmpNameOpr == "Like")
            {
                strParaMeters = strParaMeters + " EmployeeName = '" + strEmpName + "' And ";
            }
            else if (strEmpName != "" && strEmpNameOpr == "%Like%")
            {

                strParaMeters = strParaMeters + " EmployeeName Like '%" + strEmpName + "%' And ";
            }
            else if (strEmpName != "" && strEmpNameOpr == "%Like")
            {

                strParaMeters = strParaMeters + " EmployeeName Like '%" + strEmpName + "' And ";
            }
            else if (strEmpName != "" && strEmpNameOpr == "Like%")
            {

                strParaMeters = strParaMeters + " EmployeeName Like '" + strEmpName + "%' And ";
            }


            if (strEmpDesg != "" && strEmpDesgOpr == "Like")
            {
                strParaMeters = strParaMeters + " DesignationDesc = '" + strEmpDesg + "' And ";
            }
            else if (strEmpDesg != "" && strEmpDesgOpr == "%Like%")
            {

                strParaMeters = strParaMeters + " DesignationDesc Like '%" + strEmpDesg + "%' And ";
            }
            else if (strEmpDesg != "" && strEmpDesgOpr == "%Like")
            {

                strParaMeters = strParaMeters + " DesignationDesc Like '%" + strEmpDesg + "' And ";
            }
            else if (strEmpDesg != "" && strEmpDesgOpr == "Like%")
            {

                strParaMeters = strParaMeters + " DesignationDesc Like '" + strEmpDesg + "%' And ";
            }

            if (strDateOfJoin != "")
            {

                strParaMeters = strParaMeters + " DateOfJoining = '" + strDateOfJoin + "' And ";
            }


            if (strIdType != "" && strIdTypeOpr == "Like")
            {
                strParaMeters = strParaMeters + " IdType= '" + ddlIDType.SelectedValue.ToString() + "' And IdNumber = '" + strIdType + "' And ";
            }
            else if (strIdType != "" && strIdTypeOpr == "%Like%")
            {

                strParaMeters = strParaMeters + " IdType='" + ddlIDType.SelectedValue.ToString() + "' And IdNumber Like '%" + strIdType + "%' And ";
            }
            else if (strIdType != "" && strIdTypeOpr == "%Like")
            {

                strParaMeters = strParaMeters + " IdType='" + ddlIDType.SelectedValue.ToString() + "' And IdNumber Like '%" + strIdType + "' And ";
            }
            else if (strIdType != "" && strIdTypeOpr == "Like%")
            {

                strParaMeters = strParaMeters + " IdType='" + ddlIDType.SelectedValue.ToString() + "' And IdNumber Like '" + strIdType + "%' And ";
            }
            else if (txtStartDate.Text != "" && txtEndDate.Text != "" && strIdTypeOpr == "IssueDateBetween")
            {

                strParaMeters = strParaMeters + " IdType='" + ddlIDType.SelectedValue.ToString() + "' And DateOfIssue >= '" + txtStartDate.Text + "' And DateOfIssue  <='" + txtEndDate.Text + "' And ";
            }
            else if (txtStartDate.Text != "" && txtEndDate.Text != "" && strIdTypeOpr == "ExpiryDateBetween")
            {

                strParaMeters = strParaMeters + " IdType='" + ddlIDType.SelectedValue.ToString() + "' And DateOfExpiry >= '" + txtStartDate.Text + "' And DateOfExpiry  <='" + txtEndDate.Text + "' And ";
            }
            else if (txtStartDate.Text != "" && strIdTypeOpr == "IssueDate")
            {

                strParaMeters = strParaMeters + " IdType='" + ddlIDType.SelectedValue.ToString() + "' And DateOfIssue = '" + txtStartDate.Text + "' And ";
            }
            else if (txtStartDate.Text != "" && strIdTypeOpr == "ExpiryDate")
            {

                strParaMeters = strParaMeters + " IdType='" + ddlIDType.SelectedValue.ToString() + "' And DateOfExpiry = '" + txtStartDate.Text + "' And ";
            }


            if (strParaMeters.Length >= 5 && strParaMeters.Substring(strParaMeters.Length - 5, 5) == " And ")
            {
                strParaMeters = strParaMeters.Substring(0, strParaMeters.Length - 5);
            }


            if (strParaMeters != "")
            {
                strQuery = strQuery + " where " + strParaMeters;
                strQuery = strQuery + " order by a.EmployeeNumber ";

            }
            else
            {
                FillgvEmployeeList();
                return;
            }

            dsEmpList.Tables[0].DefaultView.RowFilter = strParaMeters;

            //dsEmpList = objSearch.blSearch_QueryBasedEmployeeList_Get(strQuery);

            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dsEmpList.Tables[0];
                gvEmployeeList.DataBind();
                lblErrorMsg.Text = "";
            }
            else
            {
                gvEmployeeList.DataSource = null;
                gvEmployeeList.DataBind();
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
            }
        }//End Try 

        catch (Exception ex)
        {
            DataSet ds = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex.ToString(), BaseUserID);
            ds.Dispose();

        }
    }
    /// <summary>
    /// Show all record without any filter data
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        txtEmpNo.Text = "";
        txtEmployeeName.Text = "";
        txtDateOfJoining.Text = "";
        txtEmpDesignation.Text = "";
        txtIDType.Text = "";
        txtStartDate.Text = "";
        txtEndDate.Text = "";

        dsEmpList.Tables[0].DefaultView.RowFilter = "";

        if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
        {
            gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
            gvEmployeeList.DataBind();
            lblErrorMsg.Text = "";
        }
        else
        {
            FillgvEmployeeList();
        }
    }
    /// <summary>
    /// Show hide some control on ddlIDTypeOP_SelectedIndexChange event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlIDTypeOP_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIDTypeOP.SelectedValue == "IssueDate" || ddlIDTypeOP.SelectedValue == "ExpiryDate")
        {
            txtIDType.Visible = false;
            txtEndDate.Visible = false;
            txtStartDate.Visible = true;
            ImgStartDate.Visible = true;
            ImgEndDate.Visible = false;
        }
        else if (ddlIDTypeOP.SelectedValue == "IssueDateBetween" || ddlIDTypeOP.SelectedValue == "ExpiryDateBetween")
        {
            txtIDType.Visible = false;
            txtStartDate.Visible = true;
            txtEndDate.Visible = true;
            ImgStartDate.Visible = true;
            ImgEndDate.Visible = true;
        }
        else
        {
            txtStartDate.Visible = false;
            txtEndDate.Visible = false;
            ImgStartDate.Visible = false;
            ImgEndDate.Visible = false;
            txtIDType.Visible = true;
        }
    }
    #endregion

    #region grid view events

    #region data binding
    /// <summary>
    /// Before the GridView control can be rendered, each row in the control must be bound to a record in the data source.
    /// The RowDataBound event is raised when a data row (represented by a GridViewRow object) is bound to data in the GridView control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);


        }
    }
    #endregion

    #region Fill Grid
    /// <summary>
    /// Fillgvs the employee list.
    /// </summary>
    private void FillgvEmployeeList()
    {

        try
        {

            BL.Search objSearch = new BL.Search();

            dsEmpList = objSearch.QueryBasedEmployeeListGet();

            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
                lblErrorMsg.Text = "";
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
            }

        }//End Try 

        catch (Exception ex)
        {

            DataSet ds = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex.ToString(), BaseUserID);
            ds.Dispose();
        }
    }

    #endregion
    /// <summary>
    /// The RowCommand event is raised when a button is clicked in the GridView control.
    /// This enables you to provide an event-handling method that performs a custom routine whenever this event occurs
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ASC")
        {
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                dsEmpList.Tables[0].DefaultView.Sort = "EmployeeName";
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
            }
            ImageButton ImgSortEmpNameA = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpNameA");
            ImageButton ImgSortEmpNameD = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpNameD");
            ImgSortEmpNameA.Visible = false;
            ImgSortEmpNameD.Visible = true;
        }
        else if (e.CommandName == "DESC")
        {
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                dsEmpList.Tables[0].DefaultView.Sort = "EmployeeName DESC";
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
            }
            ImageButton ImgSortEmpNameA = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpNameA");
            ImageButton ImgSortEmpNameD = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpNameD");
            ImgSortEmpNameA.Visible = true;
            ImgSortEmpNameD.Visible = false;
        }
        else if (e.CommandName == "EmpNoASC")
        {
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                dsEmpList.Tables[0].DefaultView.Sort = "EmployeeNumber";
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
            }
            ImageButton ImgSortEmpNoA = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpNoA");
            ImageButton ImgSortEmpNoD = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpNoD");
            ImgSortEmpNoA.Visible = false;
            ImgSortEmpNoD.Visible = true;
        }
        else if (e.CommandName == "EmpNoDESC")
        {
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                dsEmpList.Tables[0].DefaultView.Sort = "EmployeeNumber DESC";
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
            }
            ImageButton ImgSortEmpNoA = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpNoA");
            ImageButton ImgSortEmpNoD = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpNoD");
            ImgSortEmpNoA.Visible = true;
            ImgSortEmpNoD.Visible = false;
        }
        else if (e.CommandName == "EmpDesgASC")
        {
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                dsEmpList.Tables[0].DefaultView.Sort = "DesignationDesc";
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
            }
            ImageButton ImgSortEmpDesgA = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpDesgA");
            ImageButton ImgSortEmpDesgD = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpDesgD");
            ImgSortEmpDesgA.Visible = false;
            ImgSortEmpDesgD.Visible = true;
        }
        else if (e.CommandName == "EmpDesgDESC")
        {
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                dsEmpList.Tables[0].DefaultView.Sort = "DesignationDesc DESC";
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
            }
            ImageButton ImgSortEmpDesgA = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpDesgA");
            ImageButton ImgSortEmpDesgD = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpDesgD");
            ImgSortEmpDesgA.Visible = true;
            ImgSortEmpDesgD.Visible = false;
        }
        else if (e.CommandName == "EmpStatusASC")
        {
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                dsEmpList.Tables[0].DefaultView.Sort = "EmpStatus";
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
            }
            ImageButton ImgSortEmpStatusA = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpStatusA");
            ImageButton ImgSortEmpStatusD = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpStatusD");
            ImgSortEmpStatusA.Visible = false;
            ImgSortEmpStatusD.Visible = true;
        }
        else if (e.CommandName == "EmpStatusDESC")
        {
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                dsEmpList.Tables[0].DefaultView.Sort = "EmpStatus DESC";
                gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
                gvEmployeeList.DataBind();
            }
            ImageButton ImgSortEmpStatusA = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpStatusA");
            ImageButton ImgSortEmpStatusD = (ImageButton)gvEmployeeList.HeaderRow.FindControl("ImgSortEmpStatusD");
            ImgSortEmpStatusA.Visible = true;
            ImgSortEmpStatusD.Visible = false;
        }
    }
    /// <summary>
    /// when one of the pager buttons is clicked, but before the GridView control handles the paging operation
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeList.PageIndex = e.NewPageIndex;
        if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
        {
            gvEmployeeList.DataSource = dsEmpList.Tables[0].DefaultView;
            gvEmployeeList.DataBind();
            lblErrorMsg.Text = "";
        }
        else
        {
            FillgvEmployeeList();
        }
    }

    #endregion

    /// <summary>
    /// EmployeeLastAssignmentGet on  gvEmployeeList_SelectedIndexChanged event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeList_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            Label lblEmpNo = (Label)gvEmployeeList.Rows[gvEmployeeList.SelectedIndex].FindControl("lblEmpNo");
            DataSet ds = new DataSet();
            BL.Roster objRoster = new BL.Roster();

            ds = objRoster.EmployeeLastAssignmentGet(lblEmpNo.Text);
            FillgvEmpInfo(ds);
        }//End Try 

        catch (Exception ex)
        {
            DataSet ds = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex.ToString(), BaseUserID);
            ds.Dispose();

        }
    }
    /// <summary>
    /// Fill Employee Information in grid
    /// </summary>
    /// <param name="ds">The ds.</param>
    private void FillgvEmpInfo(DataSet ds)
    {
        gvEmpInfo.DataSource = ds.Tables[0];
        gvEmpInfo.DataBind();
    }
}
