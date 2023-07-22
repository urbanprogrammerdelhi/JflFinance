// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="Rpt_HR_Aus.aspx.cs" company="Magnon">
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
/// Class HRManagement_Rpt_HR_Aus
/// </summary>
public partial class HRManagement_Rpt_HR_Aus : BasePage //System.Web.UI.Page
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
                //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
                //if (lblPageHdrTitle != null)
                //{ lblPageHdrTitle.Text = Resources.Resource.HR; }

                //Code added by Manoj on 16 Jan 2012
                //Page Title from resource file
                System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resources.Resource.HR + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


                fillddlReportName();
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
                ImgbtnSearchFromEmp.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + TxtEmpCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");

                if (Request.QueryString["In"] != null && IsInteger(Request.QueryString["In"]))
                {
                    ddlReportName.SelectedIndex = int.Parse(Request.QueryString["In"]);
                }


            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

        HideControl();
        txtYear.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) ){return true;}else{return false;}");
        txtRtAge.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) ){return true;}else{return false;}");

    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void fillddlReportName()
    {

        ddlReportName.Items.Insert(0, new ListItem(Resources.Resource.rptLeaveTaken, "LeaveTaken_Aus.rpt"));
        ddlReportName.Items.Insert(1, new ListItem(Resources.Resource.rptEmpLeaveDetail, "EmployeeLeave.rpt"));
        ddlReportName.Items.Insert(2, new ListItem(Resources.Resource.SickLeaveBreakdown, "LeaveBreakdown"));



    }
    /// <summary>
    /// Fillddls the division.
    /// </summary>
    private void FillddlDivision()
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
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All.ToString();
            li.Value = "ALL";
            ddlDivision.Items.Insert(0, li);
            //FillddlBranch();
        }
    }
    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {

        if (ddlDivision.SelectedItem.Value.ToString() == "ALL")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All.ToString();
            li.Value = "ALL";
            ddlBranch.Items.Insert(0, li);

        }
        else
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
                li.Text = Resources.Resource.All.ToString();
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
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DDLCategory.DataSource = objMastersManagement.CategoryMasterGetAll(BaseCompanyCode);
        DDLCategory.DataTextField = "CategoryDesc";
        DDLCategory.DataValueField = "CategoryCode";
        DDLCategory.DataBind();
        ListItem li = new ListItem();
        li.Text = Resources.Resource.All;
        li.Value = "All";
        DDLCategory.Items.Insert(0, li);
    }

    /// <summary>
    /// Fills the nationality.
    /// </summary>
    private void FillNationality()
    {
        BL.HRManagement objHrManagement = new BL.HRManagement();
        ddlNationality.DataSource = objHrManagement.EmployeeNationalityGetAll(BaseCompanyCode);
        ddlNationality.DataTextField = "NationalityDesc";
        ddlNationality.DataValueField = "NationalityCode";
        ddlNationality.DataBind();

        ListItem li = new ListItem();
        li.Text = Resources.Resource.All;
        li.Value = "All";
        ddlNationality.Items.Insert(0, li);
    }

    /// <summary>
    /// Fills the designation.
    /// </summary>
    private void FillDesignation()
    {

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ddlDesignation.DataSource = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        ddlDesignation.DataTextField = "DesignationDesc";
        ddlDesignation.DataValueField = "DesignationCode";
        ddlDesignation.DataBind();

        ListItem li = new ListItem();
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
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsArea = new DataSet();
        //dsArea = objSale.blAreaID_Get((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString());
        dsArea = objSale.AreaIdGet(BaseLocationAutoID, "0");
        ddlAreaID.DataTextField = "AreaDesc";
        ddlAreaID.DataValueField = "AreaID";
        ddlAreaID.DataSource = dsArea;
        ddlAreaID.DataBind();

        ListItem li = new ListItem();
        li.Text = "All";
        li.Value = "All";
        ddlAreaID.Items.Insert(0, li);

    }


    /// <summary>
    /// Fillddls the ID.
    /// </summary>
    private void FillddlID()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsIdType = new DataSet();
        dsIdType = objMastersManagement.IdTypeGetAll();

        if (dsIdType.Tables[0].Rows.Count > 0)
        {
            ddlID.DataSource = dsIdType.Tables[0];
            ddlID.DataValueField = "IDTypeCode";
            ddlID.DataTextField = "IDTypeDesc";
            ddlID.DataBind();
            if (ddlReportName.SelectedValue.ToString() == "IdIssue.rpt")
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.All;
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
        BL.Leave objHrManagement = new BL.Leave();
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
        DataSet ds = new DataSet();
        BL.Leave objLeave = new BL.Leave();
        ds = objLeave.LeaveTypeGet(BaseCompanyCode);
        ddlleaveType.DataSource = ds.Tables[0];
        ddlleaveType.DataTextField = "Leave_Desc";
        ddlleaveType.DataValueField = "Leave_Code";
        ddlleaveType.DataBind();
        ListItem li = new ListItem();
        li.Text = Resources.Resource.All;
        li.Value = "ALL";
        ddlleaveType.Items.Insert(0, li);
    }

    /// <summary>
    /// Fillddls the I dkam.
    /// </summary>
    private void FillddlIDkam()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsIdTypekam = new DataSet();
        dsIdTypekam = objMastersManagement.IdTypeGetAll();

        if (dsIdTypekam.Tables[0].Rows.Count > 0)
        {
            ddlIDkam.DataSource = dsIdTypekam.Tables[0];
            ddlIDkam.DataValueField = "IDTypeCode";
            ddlIDkam.DataTextField = "IDTypeDesc";
            ddlIDkam.DataBind();
            ListItem likam = new ListItem();
            likam.Text = Resources.Resource.All;
            //likam.Value = "ALL";
            //ddlIDkam.Items.Insert(0, likam);
        }
    }

    /// <summary>
    /// Hides the control.
    /// </summary>
    private void HideControl()
    {

        lblFromDate.Text = Resources.Resource.FromDate;
        lblYear.Text = Resources.Resource.Year;
        lblRetirementAge.Text = Resources.Resource.RetirementAge;

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

            lblFromDate.Text = Resources.Resource.AsOnDate;

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
                lblYear.Text = Resources.Resource.StartYear;
                lblRetirementAge.Text = Resources.Resource.EndYear;

                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                ImgFromDate.Visible = true;

                lblFromDate.Text = Resources.Resource.AsOnDate;
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

        else if (ddlReportName.SelectedValue == "LeaveTaken_Aus.rpt")
        {
            lblHrLocation.Visible = false;
            ddlDivision.Visible = false;

            lblBranch.Visible = false;
            ddlBranch.Visible = false;
            
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
        else if (ddlReportName.SelectedValue == "EmployeeLeave.rpt")
        {

            lblHrLocation.Visible = false;
            ddlDivision.Visible = false;

            lblBranch.Visible = false;
            ddlBranch.Visible = false;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;

            lblCategory.Visible = false;
            DDLCategory.Visible = false;


            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;


            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;


            lblFromDate.Visible = true;
            txtFromDate.Visible = true;
            ImgFromDate.Visible = true;

            lblToDate.Visible = true;
            txtToDate.Visible = true;
            ImgToDate.Visible = true;
            lblLeaveType.Visible = false;
            ddlleaveType.Visible = false;
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

            lblArea.Visible = false;
            ddlAreaID.Visible = false;

        }
        else if (ddlReportName.SelectedValue == "LeaveBreakdown")
        {

            lblHrLocation.Visible = false;
            ddlDivision.Visible = false;

            lblBranch.Visible = false;
            ddlBranch.Visible = false;

            lblYear.Visible = false;
            txtYear.Visible = false;

            lblRetirementAge.Visible = false;
            txtRtAge.Visible = false;

            lblCategory.Visible = false;
            DDLCategory.Visible = false;


            lblDesignation.Visible = false;
            ddlDesignation.Visible = false;

            lblNationality.Visible = false;
            ddlNationality.Visible = false;

            lblGender.Visible = false;
            ddlEmployeeGender.Visible = false;


            lblEmpStatus.Visible = false;
            ddlEmployeeStatus.Visible = false;


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

            lblArea.Visible = false;
            ddlAreaID.Visible = false;

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

        string strReportName = ddlReportName.SelectedItem.Value.ToString();

        //*********** Validation check added by Manish on 1-Feb-2010 ***************************************************
        BL.Common objCommon = new BL.Common();
        if (txtFromDate.Visible == true && txtToDate.Visible == true)
        {
            if (GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                txtToDate.Focus();
                return;
            }
        }

        Hashtable hshRptParameters = new Hashtable();


        hshRptParameters = ReportParameter_Get(strReportName);

        if (ddlReportName.SelectedItem.Value.ToString() == "LeaveBreakdown")
        {
            Response.Redirect("LeaveBreakDownReport.aspx?Company=" + BaseCompanyCode + "&LocationAutoID=" + BaseLocationAutoID + "&LeaveCode=" + ddlleaveType.SelectedValue.ToString() + "&FromDate=" + DL.Common.DateFormat(txtFromDate.Text.ToString(), "") + "&ToDate=" + DL.Common.DateFormat(txtToDate.Text.ToString(), "") + "&EmpNo=" + TxtEmpCode.Text);
            return;
        }

        //// ******************************* End validation check code ***************************************************



        strErrMsg = "";
        string strReportPagePath = "../Reports/HR/";
        Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value.ToString());

        //Hashtable hshRptParameters = new Hashtable();
        hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());

        if (strErrMsg == "")
        {
            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../HRManagement/Rpt_HR_Aus.aspx?In=" + ddlReportName.SelectedIndex;
            Server.Transfer("../Reports/ViewReport1.aspx");
        }
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the STR report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        Hashtable hshRptParameters = new Hashtable();

        switch (strReportName)
        {
            case "Employeedetail.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@DesignationCode", ddlDesignation.SelectedValue.ToString());
                    hshRptParameters.Add("@Gender", ddlEmployeeGender.SelectedValue.ToString());
                    hshRptParameters.Add("@Nationality", ddlNationality.SelectedValue.ToString());
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue.ToString());
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
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@DesignationCode", ddlDesignation.SelectedValue.ToString());
                    hshRptParameters.Add("@Gender", ddlEmployeeGender.SelectedValue.ToString());
                    hshRptParameters.Add("@Nationality", ddlNationality.SelectedValue.ToString());
                    break;
                }

            case "Newjoinee.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@AearId", ddlAreaID.SelectedValue.ToString());
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                    break;
                }
            case "EmployeeRehire.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@AearId", ddlAreaID.SelectedValue.ToString());
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));

                    break;
                }

            case "EmployeeResignation.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue.ToString());
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                    break;
                }
            case "IdIssue.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@IDTypeCode", ddlID.SelectedValue.ToString());
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue.ToString());
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
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@AsOnDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    break;
                }
            case "empretirement.rpt":
                {
                    hshRptParameters.Add("@Year", int.Parse(txtYear.Text));
                    hshRptParameters.Add("@RetirementAge", int.Parse(txtRtAge.Text));
                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue.ToString());
                    break;
                }
            case "lengthofservice.rpt":
                {

                    if (txtYear.Text == "")
                    {
                        lblErrorMsg.Text = lblYear.Text + " " + Resources.Resource.CannotBeLeftBlank;
                        break;
                    }
                    if (txtRtAge.Text == "")
                    {
                        lblErrorMsg.Text = lblRetirementAge.Text + " " + Resources.Resource.CannotBeLeftBlank;
                        break;
                    }

                    hshRptParameters.Add("@AsOnDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add("@StartYear", int.Parse(txtYear.Text));
                    hshRptParameters.Add("@EndYear", int.Parse(txtRtAge.Text));
                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue.ToString());
                    break;
                }

            case "EmployeeLeaveHoliday.rpt":
                {


                    hshRptParameters.Add("@company", BaseCompanyCode);
                    hshRptParameters.Add("@HRLocation", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@EmpNumber", TxtEmpCode.Text);
                    hshRptParameters.Add("@LeaveCalCode", ddlCalcode.SelectedValue.ToString());
                    hshRptParameters.Add("@BranchCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());

                    break;
                }
            case "LeaveTaken_Aus.rpt":
                {

                    hshRptParameters.Add("@Company", BaseCompanyCode);
                    hshRptParameters.Add("@HRLocation", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@Empno", TxtEmpCode.Text);
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
                    hshRptParameters.Add("@leavecode", ddlleaveType.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue.ToString());

                    break;
                }

            case "EmployeeLeave.rpt":
                {

                    hshRptParameters.Add("@Company", BaseCompanyCode);
                    hshRptParameters.Add("@LocationAutoId", BaseLocationAutoID);
                    hshRptParameters.Add("@Empno", TxtEmpCode.Text);
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
                    break;
                }

            case "LeaveBreakdown":
                {
                    hshRptParameters.Add("@Company", BaseCompanyCode);
                    hshRptParameters.Add("@LocationAutoId", BaseLocationAutoID);
                    hshRptParameters.Add("@leavecode", ddlleaveType.SelectedValue.ToString());
                    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
                    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
                    hshRptParameters.Add("@Empno", TxtEmpCode.Text);
                    break;
                }

            case "EmployeeID.rpt":
                {

                    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                    hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                    hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                    hshRptParameters.Add("@IdType", ddlIDkam.SelectedValue.ToString());
                    hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue.ToString());
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


            case "EmpHireResign.rpt":
                hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
                hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
                hshRptParameters.Add("@LocationCode", ddlBranch.SelectedValue.ToString());
                hshRptParameters.Add("@CategoryCode", DDLCategory.SelectedValue.ToString());
                hshRptParameters.Add("@DesignationCode", ddlDesignation.SelectedValue.ToString());
                hshRptParameters.Add("@Gender", ddlEmployeeGender.SelectedValue.ToString());
                hshRptParameters.Add("@Nationality", ddlNationality.SelectedValue.ToString());
                hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add("@rptType", ddlEmploymentStatus.SelectedValue.ToString());
                hshRptParameters.Add("@AreaId", ddlAreaID.SelectedValue.ToString());
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

}
