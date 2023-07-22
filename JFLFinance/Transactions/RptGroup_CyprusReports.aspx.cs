// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 02-21-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_CyprusReports.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_RptGroup_CyprusReports.
/// </summary>
public partial class Transactions_RptGroup_CyprusReports : BasePage
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
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //======================================================
            /* code added by Manish to Open report in New Page*/
            // Button1.Attributes["onMouseDown"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ViewReport1.aspx';";
            // this.Form.Attributes["onMouseOver"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";
            //this.Button1.Attributes.Add("onclick","this.form.target='_blank'");

            /* code added by Manish to Open report in New Page*/
            //======================================================

            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.Schedules; }

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Schedules + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID.ToString() + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID.ToString() + "');";
                ImgAsOnDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtAsOnDate.ClientID.ToString() + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                txtAsOnDate.Attributes.Add("readonly", "readonly");
                //ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientName.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
                txtDayStartTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtDayStartTime.ClientID.ToString() + "');";
                txtDayStartTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtDayStartTime.ClientID.ToString() + "');";

                txtDayEndTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtDayEndTime.ClientID.ToString() + "');";
                txtDayEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtDayEndTime.ClientID.ToString() + "');";

                txtNightStartTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtNightStartTime.ClientID.ToString() + "');";
                txtNightStartTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtNightStartTime.ClientID.ToString() + "');";

                txtNightEndTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtNightEndTime.ClientID.ToString() + "');";
                txtNightEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtNightEndTime.ClientID.ToString() + "');";

                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();
                txtAsOnDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                FillddlReportName();
                FillDivision();
                FillBranch();
                //FillddlEmployeeName();
                FillddlClient();
                FillDDlAreaID();
                FillDDlShift();
                //  FillDDLShiftCode();
                FillShiftTimeFromTo();
                btnViewReport.Enabled = true;
                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }
                ShowHideReportParameterControles();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        ListItem li = new ListItem();
       
        li = new ListItem();
        li.Text = Resources.Resource.rptWeeklyPosting;
        li.Value = "PostingSheetIsrael.rpt";
        ddlReportName.Items.Add(li);


    }
    /// <summary>
    /// Fillddls the name of the employee.
    /// </summary>
    protected void FillddlEmployeeName()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        ds = objHRManagement.EmployeesOfLocationAreaWiseGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, txtFromDate.Text, txtToDate.Text, "ALL", BaseUserEmployeeNumber.ToString(), "0");

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].DefaultView.Sort = "EmployeeNumber ASC";
            ddlEmployeeNumber.DataSource = ds.Tables[0].DefaultView;

            ddlEmployeeNumber.DataTextField = "EmployeeName";
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataBind();

            ListItem li2 = new ListItem();
            li2.Text = Resources.Resource.SelectAll;
            li2.Value = "ALL";
            ddlEmployeeNumber.Items.Insert(0, li2);

        }

    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {

        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSales.ClientGet(BaseLocationAutoID, BaseUserID);

        }
        else
        {
            ds = objSales.ClientsLocationWiseGet(BaseLocationAutoID);
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";

            ddlClientCode.Items.Insert(0, li1);
            FillddlAsmt();
        }

    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlBranch.Items.Insert(0, li);
        }
    }
    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision()
    {
        DataSet dsDivision = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();
            FillBranch();
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();

        string strClientCode;
        if (ddlClientCode.SelectedItem.Value.ToString() == "ALL")
        {
            strClientCode = "";
        }
        else
        {
            strClientCode = ddlClientCode.SelectedItem.Value.ToString();
        }

        if (ddlReportName.SelectedValue.ToString() == "DailyPostingSheet.rpt" || ddlReportName.SelectedValue.ToString() == "DailyDispositionSheet.rpt")
        {
            strClientCode = "ALL";
            txtFromDate.Text = txtAsOnDate.Text;
            txtToDate.Text = txtAsOnDate.Text;
        }

        DataSet dsAsmt = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();



        if (ddlClientCode.SelectedValue == "All")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "All";
            ddlAsmtCode.Items.Insert(0, li);
        }
        else
        {
            dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");

            if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
            {
                ddlAsmtCode.DataSource = dsAsmt.Tables[0];
                ddlAsmtCode.DataTextField = "AsmtDetail";
                ddlAsmtCode.DataValueField = "AsmtCode";
                ddlAsmtCode.DataBind();

                ListItem li1 = new ListItem();
                li1.Text = Resources.Resource.All;
                li1.Value = "ALL";
                ddlAsmtCode.Items.Insert(0, li1);
            }
            else
            {
                ListItem li1 = new ListItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlAsmtCode.Items.Insert(0, li1);
            }
        }
        FillDDLPost();
    }

    /// <summary>
    /// Fills the DDL client post.
    /// </summary>
    private void FillDDLClientPost()
    {
        string strAreaId;
        if (DDLAreaID.SelectedValue.ToString() == "ALL")
        {
            strAreaId = "";
        }
        else
        {
            strAreaId = DDLAreaID.SelectedValue.ToString();
        }
        DDLClientDetail.Items.Clear();

        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        //ds = objSales.ClientAreaWiseGet(BaseLocationAutoID, strAreaId);
        ds = objSales.ClientAreaInchargeWiseGet(BaseLocationAutoID, DDLAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, BaseLocationCode, txtFromDate.Text, txtToDate.Text);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLClientDetail.DataSource = ds;
            DDLClientDetail.DataTextField = "ClientNameCode";
            DDLClientDetail.DataValueField = "ClientCode";
            DDLClientDetail.DataBind();

            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            DDLClientDetail.Items.Insert(0, li1);
            DDLClientDetail.SelectedIndex = 0;
        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            DDLClientDetail.Items.Insert(0, li1);
        }
        FillddlAsmtPost();
    }
    /// <summary>
    /// Fillddls the asmt post.
    /// </summary>
    private void FillddlAsmtPost()
    {

        string strClientCode;
        if (DDLClientDetail.SelectedValue.ToString() == "ALL")
        {
            strClientCode = "";
        }
        else
        {
            strClientCode = DDLClientDetail.SelectedValue.ToString();
        }
        string strAreaId;
        if (DDLAreaID.SelectedValue.ToString() == "ALL")
        {
            strAreaId = "";
        }
        else
        {
            strAreaId = DDLAreaID.SelectedValue.ToString();
        }
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DDLAsmtID.Items.Clear();

        if (DDLClientDetail.SelectedValue == "ALL")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "All";
            DDLAsmtID.Items.Insert(0, li);
        }
        else
        {
            DDLAsmtID.DataSource = objOperationManagement.AssignmentGet(BaseLocationAutoID, strClientCode, strAreaId);
            DDLAsmtID.DataTextField = "AsmtNameCode";
            DDLAsmtID.DataValueField = "AsmtCode";
            DDLAsmtID.DataBind();

            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            DDLAsmtID.Items.Insert(0, li);
            DDLAsmtID.SelectedIndex = 0;
        }

        FillDDlShift();
    }
    /// <summary>
    /// Fills the d dl area identifier.
    /// </summary>
    private void FillDDlAreaID()
    {
        DDLAreaID.Items.Clear();
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();
        //Added by Manoj on 03/09/12
        ds = objOPS.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLAreaID.DataSource = ds;
            DDLAreaID.DataTextField = "AreaDesc";
            DDLAreaID.DataValueField = "AreaID";
            DDLAreaID.DataBind();
        }

        ListItem li = new ListItem();
        li.Text = "All";
        li.Value = "All";
        DDLAreaID.Items.Insert(0, li);

        FillDDLClientPost();
        FillddlAsmtPost();
        FillddlEmployeeName();
    }
    /// <summary>
    /// Fills the d dl shift.
    /// </summary>
    private void FillDDlShift()
    {
        ddlShift.Items.Clear();

        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();

        //ds = objOPS.blShift_Get(DDLAsmtID.SelectedValue, BaseLocationAutoID);
        ds = objOPS.ShiftOnAsmtOfClientGet(BaseLocationAutoID.ToString(), DDLClientDetail.SelectedItem.Value.ToString(), DDLAsmtID.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlShift.DataSource = ds;
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Shift";
            ddlShift.DataBind();
        }
        ListItem li2 = new ListItem();
        li2.Text = Resources.Resource.All;
        li2.Value = "ALL";
        ddlShift.Items.Insert(0, li2);

        ListItem li3 = new ListItem();
        li3.Text = "0";
        li3.Value = "0";
        ddlShift.Items.Insert(1, li3);
        ddlShift.SelectedIndex = 0;


    }
    /// <summary>
    /// Fills the DDL shift code.
    /// </summary>
    private void FillDDLShiftCode()
    {
        DDLShiftCode.Items.Clear();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.StandardSiftsGetAll(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLShiftCode.DataSource = ds.Tables[0];
            DDLShiftCode.DataTextField = "ShiftCode";
            DDLShiftCode.DataValueField = "ShiftCode";

            DDLShiftCode.DataBind();
        }
        ListItem li2 = new ListItem();
        li2.Text = Resources.Resource.All;
        li2.Value = "ALL";
        ddlShift.Items.Insert(0, li2);

        ListItem li3 = new ListItem();
        li3.Text = "0";
        li3.Value = "0";
        ddlShift.Items.Insert(1, li3);
    }

    /// <summary>
    /// Fills the DDL post.
    /// </summary>
    private void FillDDLPost()
    {
        DDLPost.Items.Clear();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.AsmtPostGet(BaseLocationAutoID.ToString(), BaseUserEmployeeNumber, DDLAreaID.SelectedValue, ddlClientCode.SelectedValue, ddlAsmtCode.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLPost.DataSource = ds.Tables[0];
            DDLPost.DataTextField = "Site";
            DDLPost.DataValueField = "Site";
            DDLPost.DataBind();
        }
        ListItem li2 = new ListItem();
        li2.Text = Resources.Resource.All;
        li2.Value = "ALL";
        DDLPost.Items.Insert(0, li2);

    }
    /// <summary>
    /// Fills the shift time from to.
    /// </summary>
    private void FillShiftTimeFromTo()
    {

        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = objMasterManagement.StandardSiftsGet(BaseLocationAutoID, DDLShiftCode.SelectedValue.ToString());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            dt = ds.Tables[0];
            TxtTimeFrom.Text = dt.Rows[0]["TimeFrom"].ToString();
            TxtTimeTo.Text = dt.Rows[0]["TimeTo"].ToString();
        }

    }


    #endregion

    #region Controles Events

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDLPost();

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLClientDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLClientDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmtPost();
        FillDDlShift();
    }
    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the DDLAsmtID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLAsmtID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDlShift();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDLClientPost();
        FillDDlShift();
        FillddlEmployeeName();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtFromDate, lblErrorMsg))
        {
            btnViewReport.Enabled = true;
            // DateFormat(txtFromDate.Text);
            if (ddlReportName.SelectedItem.Value.ToString() == "WeeklyPostingSheet.rpt" || ddlReportName.SelectedItem.Value.ToString() == "Weeklyscheduleroster.rpt" || ddlReportName.SelectedItem.Value.ToString() == "WeeklyPostingSheetISRN.rpt")
            {
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
            }
            else
            {
                txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
            }
            // FillddlAsmt();
        }
        else
        {
            btnViewReport.Enabled = false;
            return;
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtToDate, lblErrorMsg))
        {
            btnViewReport.Enabled = true;
            //DateFormat(txtToDate.Text);
            // FillddlAsmt();
        }
        else
        {
            btnViewReport.Enabled = false;
            return;
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideReportParameterControles();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBranch();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt();
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLShiftCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLShiftCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillShiftTimeFromTo();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtAsOnDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAsOnDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtAsOnDate, lblErrorMsg);
        //DateFormat(txtAsOnDate.Text.ToString());
    }
    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        //if((Session["Country"].ToString().Trim().ToLower() == "Israel".Trim().ToLower()) &&  ddlReportName.SelectedItem.Value.ToString()=="WeeklyPostingSheet.rpt")
        //{
        //    strReportName = "WeeklyPostingSheetISRN.rpt";
        //}
        HideAllControles();
        switch (strReportName)
        {


            //Manish Added new report for Israel.    
            case "WeeklyPostingSheetISRN.rpt":
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelShift.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                //Manish 18-12-2012
                PanelGropOnShift.Visible = true;
                break;

            case "Actualvsschedule.rpt":
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                PanelAsmt.Visible = true;
                PanelScheduleType.Visible = true;
                break;

            case "leaveconfliction.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelDates.Visible = true;
                break;

            case "deploymentexception.rpt":
                PanelHours.Visible = true;
                PanelOption.Visible = true;
                PanelDates.Visible = true;
                break;
            case "mismatch.rpt":
                PanelDates.Visible = true;
                break;

            case "siteroster.rpt":
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                PanelAsmt.Visible = true;
                break;

            case "Personnelroster.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                break;

            case "availpersonnel_Greece.rpt":
                //PanelAsOnDate.Visible = true;
                //PanelLAType.Visible = true;
                //PanelShiftCode.Visible = true;
                PanelDates.Visible = true;
                break;

            case "availpersonnel_Barbados.rpt":
                PanelAsOnDate.Visible = true;
                PanelLAType.Visible = true;
                PanelShiftCode.Visible = true;
                PanelOptAvailPersonnel.Visible = true;
                PanelShiftTimeFromTo.Visible = true;
                break;

            case "ManpowerDetails.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelDayShift.Visible = true;
                PanelNightShift.Visible = true;
                break;

            case "Weeklyscheduleroster.rpt":
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                PanelAsmt.Visible = true;
                PanelDates.Visible = true;
                break;

            case "DailyPostingSheet.rpt":
                PanelAsmt.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelPost.Visible = true;
                break;
            case "DailyDispositionSheet.rpt":
                PanelAsmt.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelPost.Visible = true;
                PanelDayShift.Visible = false;
                PanelNightShift.Visible = false;
                pnlShiftType.Visible = true;
                PanelShiftTimeFromTo.Visible = false;
                break;

            case "PostingSheetIsrael.rpt":
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelDates.Visible = true;
                PanelShift.Visible = true;
                PanelAreaID.Visible = true;
                PanelGroupOnPost.Visible = true;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Hides all controles.
    /// </summary>
    private void HideAllControles()
    {
        PanelShift.Visible = false;
        //PanelAreaID.Visible = false;
        PanelDates.Visible = false;
        PanelClientCode.Visible = false;
        PanelAsOnDate.Visible = false;
        PanelEmployee.Visible = false;
        PanelAsmt.Visible = false;
        PanelClientDetail.Visible = false;
        PanelAsmtId.Visible = false;
        PanelSource.Visible = false;
        PanelScheduleType.Visible = false;
        PanelDivision.Visible = false;
        PanelBranch.Visible = false;
        PanelHours.Visible = false;
        PanelOption.Visible = false;
        PanelLAType.Visible = false;
        PanelShiftCode.Visible = false;
        PanelDayShift.Visible = false;
        PanelNightShift.Visible = false;
        PanelOptAvailPersonnel.Visible = false;
        PanelShiftTimeFromTo.Visible = false;
        PanelPost.Visible = false;
        pnlShiftType.Visible = false;
        //Manish 18-12-2012
        PanelGropOnShift.Visible = false;
        PanelAreaID.Visible = false;
        PanelGroupOnPost.Visible = false;
    }
    #endregion

    #region Function Button event
    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        string strRptName = ddlReportName.SelectedValue.ToString();


        if (chkShiftGroping.Checked == true && ddlReportName.SelectedItem.Value.ToString() == "WeeklyPostingSheetISRN.rpt")
        {

            strRptName = "WeeklyPostingSheetISRNShiftwise.rpt";
        }


        //if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
        if (ValidateControles(strRptName))
        {
            string strReportPagePath = "../Reports/Rostering/";
            // Context.Items.Add("cxtReportFileName", ddlReportName.SelectedValue.ToString());
            Context.Items.Add("cxtReportFileName", strRptName);

            Hashtable hshRptParameters = new Hashtable();
            // hshRptParameters = ReportParameter_Get(ddlReportName.SelectedValue.ToString());

            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedValue.ToString());

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            // Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Schedule.aspx?ReportName=" + ddlReportName.SelectedValue.ToString();
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Schedule.aspx?ReportName=" + ddlReportName.SelectedValue.ToString();
            Server.Transfer("../Reports/ViewReport1.aspx");
        }
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        int PostGroup = 0;
        Hashtable hshRptParameters = new Hashtable();
        if (chkShiftGroping.Checked == true && ddlReportName.SelectedItem.Value.ToString() == "WeeklyPostingSheetISRN.rpt")
        {

            strReportName = "WeeklyPostingSheetISRNShiftwise.rpt";
        }

        switch (strReportName)
        {

            case "PostingSheetIsrael.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, DDLAsmtID.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.PostCode, DDLPost.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ShiftCode, ddlShift.SelectedValue);
                if (chkPostGroping.Checked == true)
                {
                    PostGroup = 1;
                    Context.Items["cxtReportFileName"] = "PostingSheetIsraelPostWise.rpt";
                }
                hshRptParameters.Add(DL.Properties.Resources.PostGroup, PostGroup);
                return hshRptParameters;

            default: return hshRptParameters;
        }
    }
    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool validateFromToDate()
    {
        if (txtToDate.Text != "" && txtFromDate.Text != "")
        {
            if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                return true;
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                return false;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
            return false;
        }
    }
    /// <summary>
    /// Validates the controles.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateControles(string strReportName)
    {
        switch (strReportName)
        {
            case "PostingSheetIsrael.rpt":
                return validateFromToDate();
            default:
                return false;
        }
    }


    #endregion
}
