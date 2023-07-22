// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="Rpt_HR.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;
using Resource = Resources.Resource;

/// <summary>
/// Class HRManagement_Rpt_HR
/// </summary>
public partial class HRManagement_Rpt_HR : BasePage //System.Web.UI.Page
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    /// <summary>
    /// The STR err MSG
    /// </summary>
    public string strErrMsg;

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

            if (IsReadAccess == true)
            {
                var javaScript = new StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resource.HR + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());


                FillddlReportName();
                FillddlDivision();
                FillddlBranch();

                FillddlAreaID();

                FillddlIDkam();
                FillDesignation();
                FillDDLCategory();
                FillNationality();
                FillDDLCalenderCode();
                FillLeaveType();
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");


                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();
                ImgbtnSearchFromEmp.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + TxtEmpCode.ClientID + "&Company=" + BaseCompanyCode + "&HrLocation=" + BaseHrLocationCode + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");

                if (Request.QueryString["In"] != null && IsInteger(Request.QueryString["In"]))
                {
                    ddlReportName.SelectedIndex = int.Parse(Request.QueryString["In"]);
                }

                HideControl();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }


        txtYear.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) ){return true;}else{return false;}");
        txtRtAge.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) ){return true;}else{return false;}");

    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        ddlReportName.Items.Insert(0, new ListItem(Resource.employeeDetails, "Employeedetail.rpt"));
        ddlReportName.Items.Insert(1, new ListItem(Resource.NewJoineeReport, "Newjoinee.rpt"));
        ddlReportName.Items.Insert(2, new ListItem(Resource.Rehire, "EmployeeRehire.rpt"));
        ddlReportName.Items.Insert(3, new ListItem(Resource.EmployeeResignationAndTerminationReport, "EmployeeResignation.rpt"));
        ddlReportName.Items.Insert(4, new ListItem(Resource.LeaveHoilidaysEntitledVsTaken, "EmployeeLeaveHoliday.rpt"));
        ddlReportName.Items.Insert(5, new ListItem(Resource.rptLeaveTaken, "LeaveTaken.rpt"));

        ddlReportName.Items.Insert(6, new ListItem(Resource.EmployeeConstraint, "EmployeeConstraint"));

    }
    /// <summary>
    /// Fillddls the division.
    /// </summary>
    private void FillddlDivision()
    {
        var objblUserManagement = new UserManagement();
        using (var dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode))
        {
            if (dsDivision.Tables[0].Rows.Count > 0)
            {
                ddlDivision.DataSource = dsDivision.Tables[0];
                ddlDivision.DataValueField = "HrLocationCode";
                ddlDivision.DataTextField = "HrLocationDesc";
                ddlDivision.DataBind();
                var li = new ListItem { Text = Resource.All, Value = @"ALL" };
                ddlDivision.Items.Insert(0, li);
            }
        }
    }
    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {

        if (ddlDivision.SelectedItem.Value == "ALL")
        {
            var li = new ListItem();
            li.Text = Resource.All;
            li.Value = "ALL";
            ddlBranch.Items.Insert(0, li);

        }
        else
        {

            var dsBranch = new DataSet();
            var objblUserManagement = new UserManagement();
            dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue);
            if (dsBranch.Tables[0].Rows.Count > 0)
            {
                ddlBranch.DataSource = dsBranch.Tables[0];
                ddlBranch.DataValueField = "LocationCode";
                ddlBranch.DataTextField = "LocationDesc";
                ddlBranch.DataBind();
                var li = new ListItem();
                li.Text = Resource.All;
                li.Value = "ALL";
                ddlBranch.Items.Insert(0, li);

            }
        }
    }

    /// <summary>
    /// Fills the DDL category.
    /// </summary>
    private void FillDDLCategory()
    {
        var objMastersManagement = new MastersManagement();
        DDLCategory.DataSource = objMastersManagement.CategoryMasterGetAll(BaseCompanyCode);
        DDLCategory.DataTextField = "CategoryDesc";
        DDLCategory.DataValueField = "CategoryCode";
        DDLCategory.DataBind();
        var li = new ListItem();
        li.Text = Resource.All;
        li.Value = "All";
        DDLCategory.Items.Insert(0, li);
    }

    /// <summary>
    /// Fills the nationality.
    /// </summary>
    private void FillNationality()
    {
        var objHrManagement = new HRManagement();
        ddlNationality.DataSource = objHrManagement.EmployeeNationalityGetAll(BaseCompanyCode);
        ddlNationality.DataTextField = "NationalityDesc";
        ddlNationality.DataValueField = "NationalityCode";
        ddlNationality.DataBind();

        var li = new ListItem();
        li.Text = Resource.All;
        li.Value = "All";
        ddlNationality.Items.Insert(0, li);
    }

    /// <summary>
    /// Fills the designation.
    /// </summary>
    private void FillDesignation()
    {

        var objMastersManagement = new MastersManagement();
        ddlDesignation.DataSource = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        ddlDesignation.DataTextField = "DesignationDesc";
        ddlDesignation.DataValueField = "DesignationCode";
        ddlDesignation.DataBind();

        var li = new ListItem();
        li.Text = "All";
        li.Value = "All";
        ddlDesignation.Items.Insert(0, li);


    }

    /// <summary>
    /// Fillddls the area ID.
    /// </summary>
    private void FillddlAreaID()
    {
        ddlAreaID.Items.Clear();
        var objSale = new OperationManagement();
        var dsArea = new DataSet();
        //dsArea = objSale.blAreaID_Get((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString());
        //dsArea = objSale.AreaIdGet(BaseLocationAutoID, "0");
        dsArea = objSale.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID);
        ddlAreaID.DataTextField = "AreaDesc";
        ddlAreaID.DataValueField = "AreaID";
        ddlAreaID.DataSource = dsArea;
        ddlAreaID.DataBind();

        var li = new ListItem();
        li.Text = "All";
        li.Value = "All";
        ddlAreaID.Items.Insert(0, li);

    }


    /// <summary>
    /// Fillddls the ID.
    /// </summary>
    private void FillddlID()
    {
        var objMastersManagement = new MastersManagement();
        var dsIdType = new DataSet();
        dsIdType = objMastersManagement.IdTypeGetAll();

        if (dsIdType.Tables[0].Rows.Count > 0)
        {
            ddlID.DataSource = dsIdType.Tables[0];
            ddlID.DataValueField = "IDTypeCode";
            ddlID.DataTextField = "IDTypeDesc";
            ddlID.DataBind();
            if (ddlReportName.SelectedValue == "IdIssue.rpt")
            {
                var li = new ListItem();
                li.Text = Resource.All;
                li.Value = "ALL";
                ddlID.Items.Insert(0, li);
            }
        }
    }
    /// <summary>
    /// Fills the DDL calender code.
    /// </summary>
    private void FillDDLCalenderCode()
    {
        var objHrManagement = new Leave();
        ddlCalcode.DataSource = objHrManagement.LeaveCalendarGet(BaseCompanyCode);
        ddlCalcode.DataTextField = "Leave_cal_desc";
        ddlCalcode.DataValueField = "Leave_cal_code";
        ddlCalcode.DataBind();
    }
    /// <summary>
    /// Fills the type of the leave.
    /// </summary>
    private void FillLeaveType()
    {
        var ds = new DataSet();
        var objLeave = new Leave();
        ds = objLeave.LeaveTypeGet(BaseCompanyCode);
        ddlleaveType.DataSource = ds.Tables[0];
        ddlleaveType.DataTextField = "Leave_Desc";
        ddlleaveType.DataValueField = "Leave_Code";
        ddlleaveType.DataBind();
        var li = new ListItem();
        li.Text = Resource.All;
        li.Value = "ALL";
        ddlleaveType.Items.Insert(0, li);
    }

    /// <summary>
    /// Fillddls the I dkam.
    /// </summary>
    private void FillddlIDkam()
    {
        var objMastersManagement = new MastersManagement();
        var dsIdTypekam = new DataSet();
        dsIdTypekam = objMastersManagement.IdTypeGetAll();

        if (dsIdTypekam.Tables[0].Rows.Count > 0)
        {
            ddlIDkam.DataSource = dsIdTypekam.Tables[0];
            ddlIDkam.DataValueField = "IDTypeCode";
            ddlIDkam.DataTextField = "IDTypeDesc";
            ddlIDkam.DataBind();
            var likam = new ListItem();
            likam.Text = Resource.All;
            //likam.Value = "ALL";
            //ddlIDkam.Items.Insert(0, likam);
        }
    }

    /// <summary>
    /// Hides the control.
    /// </summary>
    private void HideControl()
    {
        lblFromDate.Text = Resource.FromDate;
        lblYear.Text = Resource.Year;
        lblRetirementAge.Text = Resource.RetirementAge;

        lblHrLocation.Visible = true;
        ddlDivision.Visible = true;
        lblBranch.Visible = true;
        ddlBranch.Visible = true;
        lblCategory.Visible = true;
        DDLCategory.Visible = true;

        PanelDivision1.Visible = false;
        PanelBranch1.Visible = false;
        PanelAreaIncharge.Visible = false;
        PanelAreaID1.Visible = false;
        PanelEmployee1.Visible = false;
        PnlConstraint.Visible = false;
        PnlIdType.Visible = false;
        PnlLang.Visible = false;
        PnlQual.Visible = false;
        PnlSkill.Visible = false;
        pnlTraining.Visible = false;

        if (ddlReportName.SelectedValue == "Employeedetail.rpt")
        {
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            ImgFromDate.Visible = false;

            lblToDate.Visible = false;
            txtToDate.Visible = false;
            ImgToDate.Visible = false;

            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblIdType.Visible = false;
            DivEmpId.Visible = false;

            lblDesignation.Visible = true;
            ddlDesignation.Visible = true;

            lblNationality.Visible = true;
            ddlNationality.Visible = true;

            lblGender.Visible = true;
            ddlEmployeeGender.Visible = true;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblArea.Visible = true;
            ddlAreaID.Visible = true;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;

            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;

            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;

        }
        //else if (ddlReportName.SelectedValue == "EmployeedetailGreece.rpt")
        else if (ddlReportName.SelectedValue == "EmployeedetailNew.rpt")
        {
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            ImgFromDate.Visible = false;

            lblToDate.Visible = false;
            txtToDate.Visible = false;
            ImgToDate.Visible = false;

            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblIdType.Visible = false;
            DivEmpId.Visible = false;

            lblDesignation.Visible = true;
            ddlDesignation.Visible = true;

            lblNationality.Visible = true;
            ddlNationality.Visible = true;

            lblGender.Visible = true;
            ddlEmployeeGender.Visible = true;

            lblArea.Visible = false;
            ddlAreaID.Visible = false;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;

            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;
            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;

        }
        else if (ddlReportName.SelectedValue == "Newjoinee.rpt" || ddlReportName.SelectedValue == "EmployeeRehire.rpt" || ddlReportName.SelectedValue == "EmployeeResignation.rpt")
        {
            lblFromDate.Visible = true;
            txtFromDate.Visible = true;
            ImgFromDate.Visible = true;

            lblToDate.Visible = true;
            txtToDate.Visible = true;
            ImgToDate.Visible = true;

            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;

            lblIdType.Visible = false;
            DivEmpId.Visible = false;

            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblArea.Visible = true;
            ddlAreaID.Visible = true;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;


            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;
            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;

        }
        else if (ddlReportName.SelectedValue == "IdIssue.rpt")
        {
            lblFromDate.Visible = true;
            txtFromDate.Visible = true;
            ImgFromDate.Visible = true;

            lblToDate.Visible = true;
            txtToDate.Visible = true;
            ImgToDate.Visible = true;

            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblArea.Visible = true;
            ddlAreaID.Visible = true;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;


            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblIdType.Visible = true;
            DivEmpId.Visible = true;
            FillddlID();

            lblCategory.Visible = false;
            DDLCategory.Visible = false;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;


            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;

            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;


        }
        else if (ddlReportName.SelectedValue == "Overview.rpt")
        {

            lblFromDate.Visible = true;
            txtFromDate.Visible = true;
            ImgFromDate.Visible = true;

            lblFromDate.Text = Resource.AsOnDate;

            lblToDate.Visible = false;
            txtToDate.Visible = false;
            ImgToDate.Visible = false;

            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;

            lblArea.Visible = false;
            ddlAreaID.Visible = false;

            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblIdType.Visible = false;
            DivEmpId.Visible = false;

            lblCategory.Visible = true;
            DDLCategory.Visible = true;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;


            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;

            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;


        }
        else if (ddlReportName.SelectedValue == "empretirement.rpt" || ddlReportName.SelectedValue == "lengthofservice.rpt")
        {

            lblYear.Visible = true;
            txtYear.Visible = true;

            lblRetirementAge.Visible = true;
            txtRtAge.Visible = true;

            lblCategory.Visible = true;
            DDLCategory.Visible = true;


            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;

            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblIdType.Visible = true;
            DivEmpId.Visible = true;

            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            ImgFromDate.Visible = false;

            lblToDate.Visible = false;
            txtToDate.Visible = false;
            ImgToDate.Visible = false;

            lblIdType.Visible = false;
            DivEmpId.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;

            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;

            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;

            lblArea.Visible = true;
            ddlAreaID.Visible = true;




            if (ddlReportName.SelectedValue == "lengthofservice.rpt")
            {
                lblYear.Text = Resource.StartYear;
                lblRetirementAge.Text = Resource.EndYear;

                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                ImgFromDate.Visible = true;

                lblFromDate.Text = Resource.AsOnDate;
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                ImgFromDate.Visible = true;

                lblArea.Visible = true;
                ddlAreaID.Visible = true;

            }

        }
        else if (ddlReportName.SelectedValue == "EmployeeLeaveHoliday.rpt")
        {
            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;

            lblCategory.Visible = true;
            DDLCategory.Visible = true;


            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;


            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblArea.Visible = false;
            ddlAreaID.Visible = false;

            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            ImgFromDate.Visible = false;

            lblToDate.Visible = false;
            txtToDate.Visible = false;
            ImgToDate.Visible = false;

            ImgbtnSearchFromEmp.Visible = true;
            lblEmpCode.Visible = true;
            TxtEmpCode.Visible = true;
            LblCalCode.Visible = true;
            ddlCalcode.Visible = true;


            lblIdType.Visible = false;
            DivEmpId.Visible = false;

            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;

            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;

            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;


        }

        else if (ddlReportName.SelectedValue == "LeaveTaken.rpt")
        {
            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;

            lblCategory.Visible = true;
            DDLCategory.Visible = true;


            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;


            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblArea.Visible = true;
            ddlAreaID.Visible = true;


            lblFromDate.Visible = true;
            txtFromDate.Visible = true;
            ImgFromDate.Visible = true;

            lblToDate.Visible = true;
            txtToDate.Visible = true;
            ImgToDate.Visible = true;
            lblLeaveType.Visible = true;
            ddlleaveType.Visible = true;
            lblEmpCode.Visible = true;
            TxtEmpCode.Visible = true;
            ImgbtnSearchFromEmp.Visible = true;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblIdType.Visible = false;
            DivEmpId.Visible = false;

            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;

            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;

        }
        else if (ddlReportName.SelectedValue == "EmployeeID.rpt")
        {
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            ImgFromDate.Visible = false;

            lblToDate.Visible = false;
            txtToDate.Visible = false;
            ImgToDate.Visible = false;

            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;


            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblArea.Visible = true;
            ddlAreaID.Visible = true;


            lblIdType.Visible = false;
            DivEmpId.Visible = false;
            // Div1.Visible = false;


            lblIdTypekam.Visible = true;
            DivEmpIdkam.Visible = true;
            FillddlID();



            lblCategory.Visible = true;
            DDLCategory.Visible = true;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;

            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;

        }

        //For New Report Added By Manish 
        else if (ddlReportName.SelectedValue == "EmpHireResign.rpt")
        {
            lblFromDate.Visible = true;
            txtFromDate.Visible = true;
            ImgFromDate.Visible = true;

            lblToDate.Visible = true;
            txtToDate.Visible = true;
            ImgToDate.Visible = true;

            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblIdType.Visible = false;
            DivEmpId.Visible = false;

            lblDesignation.Visible = true;
            ddlDesignation.Visible = true;

            lblNationality.Visible = true;
            ddlNationality.Visible = true;

            lblGender.Visible = true;
            ddlEmployeeGender.Visible = true;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblArea.Visible = true;
            ddlAreaID.Visible = true;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;

            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;
            ddlEmploymentStatus.Visible = true;
            lblEmploymentStatus.Visible = true;

        }
        else if (ddlReportName.SelectedValue == @"EmployeeConstraint")
        {
            lblHrLocation.Visible = false;
            ddlDivision.Visible = false;
            lblBranch.Visible = false;
            ddlBranch.Visible = false;
            lblCategory.Visible = false;
            DDLCategory.Visible = false;
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            ImgFromDate.Visible = false;

            lblToDate.Visible = false;
            txtToDate.Visible = false;
            ImgToDate.Visible = false;

            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;

            lblIdType.Visible = false;
            DivEmpId.Visible = false;

            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblArea.Visible = false;
            ddlAreaID.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
            LblCalCode.Visible = false;
            ddlCalcode.Visible = false;
            lblEmpCode.Visible = false;
            TxtEmpCode.Visible = false;
            ImgbtnSearchFromEmp.Visible = false;

            lblIdTypekam.Visible = false;
            DivEmpIdkam.Visible = false;
            ddlEmploymentStatus.Visible = false;
            lblEmploymentStatus.Visible = false;


            PanelDivision1.Visible = true;
            PanelBranch1.Visible = true;
            PanelAreaIncharge.Visible = true;
            PanelAreaID1.Visible = true;
            PanelEmployee1.Visible = true;
            PnlConstraint.Visible = true;
            PnlIdType.Visible = true;
            PnlLang.Visible = true;
            PnlQual.Visible = true;
            PnlSkill.Visible = true;
            pnlTraining.Visible = true;
            FillDivision1();
            FillddlAreaInchargeDetails();
        }

    }

    #endregion

    #region Controles Events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        HideControl();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {


        FillddlBranch();

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
        var strRptName = ddlReportName.SelectedValue;
        //*********** Validation check added by Manish on 1-Feb-2010 ***************************************************
        var objCommon = new Common();
        if (txtFromDate.Visible == true && txtToDate.Visible == true)
        {
            if (GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                txtToDate.Focus();
                return;
            }
        }
        //// ******************************* End validation check code ***************************************************

        if (strRptName == @"EmployeeConstraint")
        {
            if (!ValidateControles(strRptName)) return;
        }

        strErrMsg = "";
        string strReportPagePath;
        strReportPagePath = strRptName == @"EmployeeConstraint" ? "../Reports/Rostering/" : "../Reports/HR/";

        Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value);

        var hshRptParameters = new Hashtable();
        hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value);

        if (strErrMsg == "")
        {

            if (strRptName == @"EmployeeConstraint")
            {

                if (ddlEmployeeNumber1.SelectedValue != string.Empty)
                {
                    Context.Items.Remove("cxtHashParameters");
                    Session["cxtHashParameters"] = hshRptParameters;
                    Context.Items.Add("cxtReportID", "ReportID");
                    Context.Items.Add("cxtReportPagePath", strReportPagePath);
                    Context.Items["cxtReturnPage"] = "../HRManagement/rpt_HR.aspx?In=" + ddlReportName.SelectedIndex;
                    Server.Transfer("../Transactions/ConstraintGridReport.aspx");
                }
            }
            else
            {

                Context.Items.Add("cxtHashParameters", hshRptParameters);
                Context.Items.Add("cxtReportID", "ReportID");
                Context.Items.Add("cxtReportPagePath", strReportPagePath);
                Context.Items["cxtReturnPage"] = "../HRManagement/rpt_HR.aspx?In=" + ddlReportName.SelectedIndex;
                Server.Transfer("../Reports/ViewReport1.aspx");
            }
        }
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the STR report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        var hshRptParameters = new Hashtable();

        switch (strReportName)
        {
            case "Employeedetail.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@DesignationCode", ddlDesignation.SelectedValue);
                    hshRptParameters.Add("@Gender", ddlEmployeeGender.SelectedValue);
                    hshRptParameters.Add("@Nationality", ddlNationality.SelectedValue);
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue);
                    hshRptParameters.Add("@UserId", BaseUserID);
                    break;
                }
            //case "EmployeedetailGreece.rpt":
            //    {

            //        hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //        hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
            //        hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
            //        hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
            //        hshRptParameters.Add("@DesignationCode", ddlDesignation.SelectedValue.ToString());
            //        hshRptParameters.Add("@Gender", ddlEmployeeGender.SelectedValue.ToString());
            //        hshRptParameters.Add("@Nationality", "ALL");
            //        break;
            //    }

            case "EmployeedetailNew.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@DesignationCode", ddlDesignation.SelectedValue);
                    hshRptParameters.Add("@Gender", ddlEmployeeGender.SelectedValue);
                    hshRptParameters.Add("@Nationality", ddlNationality.SelectedValue);
                    break;
                }

            case "Newjoinee.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@AearId", ddlAreaID.SelectedValue);
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                    hshRptParameters.Add("@UserId", BaseUserID);
                    break;
                }
            case "EmployeeRehire.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@AearId", ddlAreaID.SelectedValue);
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                    hshRptParameters.Add("@UserId", BaseUserID);
                    break;
                }

            case "EmployeeResignation.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue);
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                    hshRptParameters.Add("@UserId", BaseUserID);
                    break;
                }
            case "IdIssue.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@IDTypeCode", ddlID.SelectedValue);
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue);
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                    if (radExp.Checked)
                    {
                        Context.Items.Remove("cxtReportFileName");
                        Context.Items.Add("cxtReportFileName", "PassportExpiryReport.rpt");
                    }

                    break;
                }
            case "Overview.rpt":
                {
                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@AsOnDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    break;
                }
            case "empretirement.rpt":
                {
                    hshRptParameters.Add("@Year", int.Parse(txtYear.Text));
                    hshRptParameters.Add("@RetirementAge", int.Parse(txtRtAge.Text));
                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue);
                    break;
                }
            case "lengthofservice.rpt":
                {

                    if (txtYear.Text == "")
                    {
                        lblErrorMsg.Text = lblYear.Text + " " + Resource.CannotBeLeftBlank;
                        break;
                    }
                    if (txtRtAge.Text == "")
                    {
                        lblErrorMsg.Text = lblRetirementAge.Text + " " + Resource.CannotBeLeftBlank;
                        break;
                    }

                    hshRptParameters.Add("@AsOnDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@StartYear", int.Parse(txtYear.Text));
                    hshRptParameters.Add("@EndYear", int.Parse(txtRtAge.Text));
                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue);
                    break;
                }

            case "EmployeeLeaveHoliday.rpt":
                {


                    hshRptParameters.Add("@company", BaseCompanyCode);
                    hshRptParameters.Add("@HRLocation", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@EmpNumber", TxtEmpCode.Text);
                    hshRptParameters.Add("@LeaveCalCode", ddlCalcode.SelectedValue);
                    hshRptParameters.Add("@BranchCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);

                    break;
                }
            case "LeaveTaken.rpt":
                {

                    hshRptParameters.Add("@Company", BaseCompanyCode);
                    hshRptParameters.Add("@HRLocation", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@Empno", TxtEmpCode.Text);
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                    hshRptParameters.Add("@leavecode", ddlleaveType.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue);
                    hshRptParameters.Add("@UserId", BaseUserID);

                    break;
                }
            case "EmployeeID.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                    hshRptParameters.Add("@IdType", ddlIDkam.SelectedValue);
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue);
                    if (raddata1.Checked)
                    {
                        hshRptParameters.Add("@IdData", "Y");
                    }
                    else
                    {
                        hshRptParameters.Add("@IdData", "N");
                    }


                    break;
                }
            case "EmployeeConstraint":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.TrainingCode, ddlTraining.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.QualificationCode, DdlQual.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.SkillCode, DdlSkill.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ConstraintCode, DdlConstraint.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.IDType, DdlIdType.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.LanguageCode, DdlLanguage.SelectedValue);
                return hshRptParameters;


            case "EmpHireResign.rpt":
                hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue);
                hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue);
                hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue);
                hshRptParameters.Add("@DesignationCode", ddlDesignation.SelectedValue);
                hshRptParameters.Add("@Gender", ddlEmployeeGender.SelectedValue);
                hshRptParameters.Add("@Nationality", ddlNationality.SelectedValue);
                hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add("@rptType", ddlEmploymentStatus.SelectedValue);
                hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue);
                break;
            default:

                break;
        }

        return hshRptParameters;
    }
    #endregion


    ////public static bool IsInteger(string theValue)
    ////{
    ////    try
    ////    {
    ////        Convert.ToInt32(theValue);
    ////        return true;
    ////    }
    ////    catch
    ////    {
    ////        return false;
    ////    }
    ////}
    /// 
    /// 
    /// 



    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision1()
    {
        ddlDivision1.Items.Clear();
        ddlBranch1.Items.Clear();
        var objblUserManagement = new UserManagement();
        var dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision1.DataSource = dsDivision.Tables[0];
            ddlDivision1.DataValueField = "HrLocationCode";
            ddlDivision1.DataTextField = "HrLocationCode";
            ddlDivision1.DataBind();

            ddlDivisionName.DataSource = dsDivision.Tables[0];
            ddlDivisionName.DataValueField = "HrLocationCode";
            ddlDivisionName.DataTextField = "HrLocationDesc";
            ddlDivisionName.DataBind();

            ddlDivision1.SelectedValue = BaseHrLocationCode;
            ddlDivisionName.SelectedValue = ddlDivision1.SelectedValue;

            FillBranch1();
        }
    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch1()
    {
        var objblUserManagement = new UserManagement();
        //Added By  for Weekly Rest Report
        var dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision1.SelectedValue);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch1.DataSource = dsBranch.Tables[0];
            ddlBranch1.DataValueField = "LocationAutoId";
            ddlBranch1.DataTextField = "LocationCode";
            ddlBranch1.DataBind();

            ddlBranchName.DataSource = dsBranch.Tables[0];
            ddlBranchName.DataValueField = "LocationAutoId";
            ddlBranchName.DataTextField = "LocationDesc";
            ddlBranchName.DataBind();
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivision1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivisionName.SelectedValue = ddlDivision1.SelectedValue;
        FillBranch1();
        FillddlAreaInchargeDetails();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivisionName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivisionName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivision1.SelectedValue = ddlDivisionName.SelectedValue;
        FillBranch1();
        FillddlAreaInchargeDetails();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranch1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranchName.SelectedValue = ddlBranch1.SelectedValue;
        FillddlAreaInchargeDetails();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranchName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranchName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranch1.SelectedValue = ddlBranchName.SelectedValue;
        FillddlAreaInchargeDetails();
    }


    /// <summary>
    /// Fill AreaIncharge Dropdown on Location Basis
    /// </summary>
    private void FillddlAreaInchargeDetails()
    {
        string employeeNumber;

        if (BaseUserIsAreaIncharge == "0" && BaseUserID != "system")
        {
            employeeNumber = BaseUserEmployeeNumber;
        }
        else
        {
            employeeNumber = "0";

        }
        var objHrManagement = new HRManagement();

        ddlAreaInchargeCode.Items.Clear();
        ddlAreaInchargeName.Items.Clear();

        var ds = objHrManagement.AreaInchargeGetBasedonUserID(ddlBranch1.SelectedValue != string.Empty ? ddlBranch1.SelectedItem.Value : BaseLocationAutoID, employeeNumber, BaseUserID);


        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaInchargeCode.DataSource = ds.Tables[0];
            ddlAreaInchargeCode.DataTextField = "EmployeeCode";
            ddlAreaInchargeCode.DataValueField = "EmployeeCode";
            ddlAreaInchargeCode.DataBind();

            ddlAreaInchargeName.DataSource = ds.Tables[0];
            ddlAreaInchargeName.DataTextField = "Employee";
            ddlAreaInchargeName.DataValueField = "EmployeeCode";
            ddlAreaInchargeName.DataBind();

            var li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
            ddlAreaInchargeCode.Items.Insert(0, li2);

            li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
            ddlAreaInchargeName.Items.Insert(0, li2);

        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAreaInchargeCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAreaInchargeName.Items.Insert(0, li1);
        }

        FillddlAreaId1();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeName.SelectedValue = ddlAreaInchargeCode.SelectedValue;
        FillddlAreaId1();
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeCode.SelectedValue = ddlAreaInchargeName.SelectedValue;
        FillddlAreaId1();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLAreaID control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaName.SelectedValue = ddlAreaID1.SelectedValue;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaID1.SelectedValue = ddlAreaName.SelectedValue;
    }


    /// <summary>
    /// Fill AreaId Dropdown on AreaIncharge Basis
    /// </summary>
    private void FillddlAreaId1()
    {
        ddlAreaID1.Items.Clear();
        ddlAreaName.Items.Clear();

        var objOps = new OperationManagement();

        var ds = objOps.AreaIdGet(ddlBranch1.SelectedValue != string.Empty ? ddlBranch1.SelectedItem.Value : BaseLocationAutoID, ddlAreaInchargeCode.SelectedValue);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaID1.DataSource = ds;
            ddlAreaID1.DataTextField = "AreaID";
            ddlAreaID1.DataValueField = "AreaID";
            ddlAreaID1.DataBind();

            ddlAreaName.DataSource = ds;
            ddlAreaName.DataTextField = "AreaDesc";
            ddlAreaName.DataValueField = "AreaID";
            ddlAreaName.DataBind();

            var li = new RadComboBoxItem { Text = Resource.All, Value = @"All" };
            ddlAreaID1.Items.Insert(0, li);

            li = new RadComboBoxItem { Text = Resource.All, Value = @"All" };
            ddlAreaName.Items.Insert(0, li);
        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAreaID1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAreaName.Items.Insert(0, li1);
        }

        if (ddlReportName.SelectedValue == @"EmployeeConstraint")
        {
            FillddlEmployeeNumber();


        }

    }

    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    private void FillddlEmployeeNumber()
    {
        ddlEmployeeNumber1.Items.Clear();
        ddlEmployeeName.Items.Clear();
        var objHrManagement = new HRManagement();

        if (ddlDivision1.SelectedValue == @"ALL")
        {
            var liEmp = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlEmployeeNumber1.Items.Insert(0, liEmp);

            liEmp = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlEmployeeName.Items.Insert(0, liEmp);
        }
        else
        {
            DataSet ds;
            if (ddlReportName.SelectedValue == @"EmployeeConstraint" || ddlReportName.SelectedValue == @"CustomerConstraint")
            {

                ds = objHrManagement.EmployeesOfLocationAreaWiseGetForTraining(BaseCompanyCode,
                    ddlDivision1.SelectedValue, ddlBranch1.SelectedItem.Text, DateTime.Now.ToString("dd-MMM-yyyy"),
                    DateTime.Now.ToString("dd-MMM-yyyy"),
                    ddlAreaID1.SelectedValue, ddlAreaInchargeCode.SelectedValue, BaseUserIsAreaIncharge);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlEmployeeNumber1.DataSource = ds.Tables[0];
                    ddlEmployeeNumber1.DataTextField = "EmployeeNumber";
                    ddlEmployeeNumber1.DataValueField = "EmployeeNumber";
                    ddlEmployeeNumber1.DataBind();

                    ddlEmployeeName.DataSource = ds.Tables[0];
                    ddlEmployeeName.DataTextField = "EmployeeName";
                    ddlEmployeeName.DataValueField = "EmployeeNumber";
                    ddlEmployeeName.DataBind();

                    var li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
                    ddlEmployeeNumber1.Items.Insert(0, li2);

                    li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
                    ddlEmployeeName.Items.Insert(0, li2);

                    FillAllConstraint();
                    FillAllIdType();
                    FillAllLanguage();
                    FillAllQualification();
                    FillAllSkill();
                    FillAllTrainings();
                }
                else
                {
                    var li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    ddlEmployeeNumber1.Items.Insert(0, li2);


                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    ddlEmployeeName.Items.Insert(0, li2);

                    DdlConstraint.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlConstraint.Items.Insert(0, li2);

                    DdlIdType.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlIdType.Items.Insert(0, li2);

                    DdlLanguage.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlLanguage.Items.Insert(0, li2);

                    DdlQual.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlQual.Items.Insert(0, li2);

                    DdlSkill.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlSkill.Items.Insert(0, li2);

                    if (ddlReportName.SelectedValue == @"EmployeeConstraint")
                    {
                        ddlTraining.Items.Clear();
                        li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                        ddlTraining.Items.Insert(0, li2);
                    }
                }
            }
            else
            {

                try
                {
                    ds = objHrManagement.EmployeesOfLocationAreaWiseGetForTraining(BaseCompanyCode,
                        ddlDivision1.SelectedValue, ddlBranch1.SelectedItem.Text, txtFromDate.Text, txtToDate.Text,
                        ddlAreaID1.SelectedValue, ddlAreaInchargeCode.SelectedValue, BaseUserIsAreaIncharge);


                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ddlEmployeeNumber1.DataSource = ds.Tables[0];
                        ddlEmployeeNumber1.DataTextField = "EmployeeNumber";
                        ddlEmployeeNumber1.DataValueField = "EmployeeNumber";
                        ddlEmployeeNumber1.DataBind();

                        ddlEmployeeName.DataSource = ds.Tables[0];
                        ddlEmployeeName.DataTextField = "EmployeeName";
                        ddlEmployeeName.DataValueField = "EmployeeNumber";
                        ddlEmployeeName.DataBind();

                        var li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
                        ddlEmployeeNumber1.Items.Insert(0, li2);

                        li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
                        ddlEmployeeName.Items.Insert(0, li2);
                    }
                    else
                    {
                        var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                        ddlEmployeeNumber1.Items.Insert(0, li1);

                        li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                        ddlEmployeeName.Items.Insert(0, li1);
                    }
                }
                catch (Exception) { }
            }
        }
    }


    /// <summary>
    /// Function used to fill Training Drop Down List.
    /// </summary>
    private void FillAllTrainings()
    {
        ddlTraining.Items.Clear();

        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlTraining.DataSource = ds.Tables[0];
                ddlTraining.DataValueField = "TrainingCode";
                ddlTraining.DataTextField = "TrainingDesc";
                ddlTraining.DataBind();
            }
        }

        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        ddlTraining.Items.Insert(0, li);

    }


    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllQualification()
    {
        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.QualificationMasterGetAll())
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlQual.DataSource = ds.Tables[0];
                DdlQual.DataValueField = "QualificationCode";
                DdlQual.DataTextField = "QualificationDesc";
                DdlQual.DataBind();
            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        DdlQual.Items.Insert(0, li);

    }

    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllLanguage()
    {
        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.LanguageMasterGetAll())
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlLanguage.DataSource = ds.Tables[0];
                DdlLanguage.DataValueField = "LanguageCode";
                DdlLanguage.DataTextField = "LanguageDesc";
                DdlLanguage.DataBind();
            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        DdlLanguage.Items.Insert(0, li);

    }

    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllIdType()
    {
        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.IdTypeGetAll())
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlIdType.DataSource = ds.Tables[0];
                DdlIdType.DataValueField = "IDTypeCode";
                DdlIdType.DataTextField = "IDTypeDesc";
                DdlIdType.DataBind();
            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        DdlIdType.Items.Insert(0, li);

    }

    /// <summary>
    /// Function used to fill Skill Drop Down List.
    /// </summary>
    private void FillAllSkill()
    {
        var objMastersManagement = new HRManagement();
        using (var ds = objMastersManagement.SkillTypeMasterGet(BaseCompanyCode))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlSkill.DataSource = ds;
                DdlSkill.DataTextField = "ItemDesc";
                DdlSkill.DataValueField = "ItemCode";
                DdlSkill.DataBind();

            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        DdlSkill.Items.Insert(0, li);

    }

    /// <summary>
    /// Function used to fill Skill Drop Down List.
    /// </summary>
    private void FillAllConstraint()
    {
        DdlConstraint.Items.Clear();
        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.ConstraintGetAll(BaseCompanyCode, null, Page.ID))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlConstraint.DataSource = ds.Tables[0];
                DdlConstraint.DataTextField = "ConstraintDesc";
                DdlConstraint.DataValueField = "ConstraintCode";
                DdlConstraint.DataBind();
            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"All" };
        DdlConstraint.Items.Insert(0, li);
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployeeNumber control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeNumber1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeName.SelectedValue = ddlEmployeeNumber1.SelectedValue;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployeeName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeNumber1.SelectedValue = ddlEmployeeName.SelectedValue;
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
            case "EmployeeConstraint":
                return true;
            default:
                return false;
        }
    }


}
