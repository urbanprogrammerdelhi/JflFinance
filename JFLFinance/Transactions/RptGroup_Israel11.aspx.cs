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
using Telerik.Web.UI;

public partial class RptGroup_Israel : BasePage
{
    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>

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

                FillddlAreaInchargeDetails();
                FillddlReportTypeMain();
                FillddlReportName();
                FillDivision();
                FillBranch();

                FillddlEmployeeNumber();
                FillddlClient();
                FillDDlAreaID();
                FillDDlShift();
                FillDDLShiftCode();
                FillShiftTimeFromTo();
                txtYear.Text = DateTime.Now.Year.ToString();
                txtForNextNDays.Text = "10";
                txtForNextNDays.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) ){return true;}else{return false;}");
                btnViewReport.Enabled = true;

                if (ddlReportName.SelectedItem.Value.ToString() == "WeeklyPostingSheet.rpt"
                || ddlReportName.SelectedItem.Value.ToString() == "Weeklyscheduleroster.rpt"
                || ddlReportName.SelectedItem.Value.ToString() == "rpt_WeeklyActual_AsmtWise.rpt"
                || ddlReportName.SelectedItem.Value.ToString() == "rpt_WeeklySchedule_AsmtWise.rpt")
                {
                    txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                }
                else
                {
                    txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
                }

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

    private void FillddlReportTypeMain()
    {
        var li = new RadComboBoxItem();
        li.Text = Resources.Resource.Rostering.ToString();
        li.Value = "Rostering";
        ddlReportTypeMain.Items.Add(li);

        li = new RadComboBoxItem();
        li.Text = Resources.Resource.Training.ToString();
        li.Value = "Training";
        ddlReportTypeMain.Items.Add(li);

        //li = new RadComboBoxItem();
        //li.Text = Resources.Resource.PostingSheet.ToString();
        //li.Value = "Postingsheet.rpt";
        //ddlReportName.Items.Add(li);

    }
    private void FillddlAreaInchargeDetails()
    {
        String EmployeeNumber = String.Empty;

        if (BaseUserIsAreaIncharge == "0" && BaseUserID != "system")
        {
            EmployeeNumber = BaseUserEmployeeNumber;
        }
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        ds = objHRManagement.AreaInchargeGet(BaseCompanyCode, EmployeeNumber);
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
        }
        if (EmployeeNumber == "" || BaseUserID == "system")
        {
            var li2 = new RadComboBoxItem();
            li2.Text = Resources.Resource.SelectAll;
            li2.Value = "ALL";
            ddlAreaInchargeCode.Items.Insert(0, li2);

            li2 = new RadComboBoxItem();
            li2.Text = Resources.Resource.SelectAll;
            li2.Value = "ALL";
            ddlAreaInchargeCode.Items.Insert(0, li2);
            ddlAreaInchargeName.Items.Insert(0, li2);
        }
        FillDDlAreaID();
    }
    private void FillddlReportName()
    {
        ddlReportName.Items.Clear();
        var li = new RadComboBoxItem();
        if (ddlReportTypeMain.SelectedValue.ToString() == "Rostering")
        {
            //li = new ListItem();
            li.Text = Resources.Resource.WeeklyScheduleReport.ToString();
            li.Value = "rpt_WeeklySchedule_AsmtWise.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.MonthlyScheduleReport.ToString();
            li.Value = "rpt_MonthlySchedule_AsmtWise.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.WeeklyActualReport.ToString();
            li.Value = "rpt_WeeklyActual_AsmtWise.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.MonthlyActualReport.ToString();
            li.Value = "rpt_MonthlyActual_AsmtWise.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.EmployeeWiseScheduleandActuals;
            li.Value = "rpt_WeeklySchedule_EmpWise.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.ExceptionScheduleVsActual;
            li.Value = "ExceptionsActualVsTeken.rpt";
            ddlReportName.Items.Add(li);
        }

        if (ddlReportTypeMain.SelectedValue.ToString() == "Training")
        {
            //li = new ListItem();
            li.Text = Resources.Resource.dailyRefresherTrainingDue.ToString();
            li.Value = "dailyRefresherTrainingDue.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.RefresherTrainingDue.ToString();
            li.Value = "dateRangeRefresherTrainingDue.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.RefresherTrainingSchedule.ToString();
            li.Value = "dateRangeRefresherTrainingSchedule.rpt";
            ddlReportName.Items.Add(li);
        }
    }

    protected void FillddlEmployeeNumber()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        ds = objHRManagement.EmployeeNameGetAll(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlEmployeeNumber.DataSource = ds.Tables[0];
            ddlEmployeeNumber.DataTextField = "EmployeeNumber";
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataBind();

            ddlEmployeeName.DataSource = ds.Tables[0];
            ddlEmployeeName.DataTextField = "Name";
            ddlEmployeeName.DataValueField = "EmployeeNumber";
            ddlEmployeeName.DataBind();
        }

        var li2 = new RadComboBoxItem();
        li2.Text = Resources.Resource.SelectAll;
        li2.Value = "ALL";
        ddlEmployeeNumber.Items.Insert(0, li2);

        li2 = new RadComboBoxItem();
        li2.Text = Resources.Resource.SelectAll;
        li2.Value = "ALL";
        ddlEmployeeName.Items.Insert(0, li2);
    }
    private void FillDDlAreaID()
    {
        DDLAreaID.Items.Clear();
        ddlAreaName.Items.Clear();
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOPS.AreaIdGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLAreaID.DataSource = ds;
            DDLAreaID.DataTextField = "AreaID";
            DDLAreaID.DataValueField = "AreaID";
            DDLAreaID.DataBind();

            ddlAreaName.DataSource = ds;
            ddlAreaName.DataTextField = "AreaDesc";
            ddlAreaName.DataValueField = "AreaID";
            ddlAreaName.DataBind();
        }

        var li = new RadComboBoxItem();
        li.Text = Resources.Resource.All;
        li.Value = "All";
        DDLAreaID.Items.Insert(0, li);

        li = new RadComboBoxItem();
        li.Text = Resources.Resource.All;
        li.Value = "All";
        ddlAreaName.Items.Insert(0, li);

        FillDDLClientPost();
        FillddlAsmtPost();
    }
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
            ddlClientCode.DataTextField = "ClientCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();

            ddlClientName.DataSource = ds.Tables[0];
            ddlClientName.DataTextField = "ClientName";
            ddlClientName.DataValueField = "ClientCode";
            ddlClientName.DataBind();

            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlClientCode.Items.Insert(0, li1);
            
            li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlClientName.Items.Insert(0, li1);
            
            FillddlAsmt();
        }

    }
    private void FillBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationCode";
            ddlBranch.DataBind();

            ddlBranchName.DataSource = dsBranch.Tables[0];
            ddlBranchName.DataValueField = "LocationCode";
            ddlBranchName.DataTextField = "LocationDesc";
            ddlBranchName.DataBind();

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlBranch.Items.Insert(0, li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlBranchName.Items.Insert(0, li);
        }
    }
    private void FillDivision()
    {
        DataSet dsDivision = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationCode";
            ddlDivision.DataBind();

            ddlDivisionName.DataSource = dsDivision.Tables[0];
            ddlDivisionName.DataValueField = "HrLocationCode";
            ddlDivisionName.DataTextField = "HrLocationDesc";
            ddlDivisionName.DataBind();

            FillBranch();
        }
    }
    
    protected void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();
        ddlAsmtName.Items.Clear();

        string strClientCode;
        if (ddlClientCode.SelectedItem.Value.ToString() == "ALL")
        {
            strClientCode = "";
        }
        else
        {
            strClientCode = ddlClientCode.SelectedItem.Value.ToString();
        }

        if (ddlReportName.SelectedValue.ToString() == "DailyPostingSheet.rpt")
        {
            strClientCode = "ALL";
            txtFromDate.Text = txtAsOnDate.Text;
            txtToDate.Text = txtAsOnDate.Text;
        }

        DataSet dsAsmt = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();


        dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");

        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = dsAsmt.Tables[0];
            ddlAsmtCode.DataTextField = "AsmtCode";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();

            ddlAsmtName.DataSource = dsAsmt.Tables[0];
            ddlAsmtName.DataTextField = "AsmtAddress";
            ddlAsmtName.DataValueField = "AsmtCode";
            ddlAsmtName.DataBind();

            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlAsmtCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlAsmtName.Items.Insert(0, li1);
        }
        else
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlAsmtCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlAsmtName.Items.Insert(0, li1);
        }
        FillDDLPost();
    }

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
        ds = objSales.ClientAreaWiseGet(BaseLocationAutoID, strAreaId);

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

        DDLAsmtID.DataSource = objOperationManagement.AssignmentGet(BaseLocationAutoID, strClientCode, strAreaId);
        DDLAsmtID.DataTextField = "AsmtNameCode";
        DDLAsmtID.DataValueField = "AsmtCode";
        DDLAsmtID.DataBind();

        ListItem li = new ListItem();
        li.Text = Resources.Resource.All;
        li.Value = "ALL";
        DDLAsmtID.Items.Insert(0, li);
        DDLAsmtID.SelectedIndex = 0;

        FillDDlShift();
    }

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
        var li2 = new RadComboBoxItem();
        li2.Text = Resources.Resource.All;
        li2.Value = "ALL";
        ddlShift.Items.Insert(0, li2);

        var li3 = new RadComboBoxItem();
        li3.Text = "0";
        li3.Value = "0";
        ddlShift.Items.Insert(1, li3);
        ddlShift.SelectedIndex = 0;


    }
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
        var li2 = new RadComboBoxItem();
        li2.Text = Resources.Resource.All;
        li2.Value = "ALL";
        DDLShiftCode.Items.Insert(0, li2);

        var li3 = new RadComboBoxItem();
        li3.Text = "0";
        li3.Value = "0";
        DDLShiftCode.Items.Insert(1, li3);
    }

    private void FillDDLPost()
    {
        DDLPost.Items.Clear();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.AsmtPostGet(BaseLocationAutoID.ToString(), ddlAsmtCode.SelectedItem.Value.ToString());
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
    private void FillShiftTimeFromTo()
    {

        //BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        //DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        //ds = objMasterManagement.StandardSiftsGet(BaseLocationAutoID, DDLShiftCode.SelectedValue.ToString());

        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    dt = ds.Tables[0];
        //    TxtTimeFrom.Text = dt.Rows[0]["TimeFrom"].ToString();
        //    TxtTimeTo.Text = dt.Rows[0]["TimeTo"].ToString();
        //}

    }


    #endregion

    #region Controles Events

    protected void ddlAsmtCode_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtName.SelectedValue = ddlAsmtCode.SelectedValue;
        FillDDLPost();

    }
    protected void ddlAsmtName_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtCode.SelectedValue = ddlAsmtName.SelectedValue;
        FillDDLPost();

    }
    protected void ddlClientCode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientName.SelectedValue = ddlClientCode.SelectedValue;
        FillddlAsmt();
    }
    protected void ddlClientName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientCode.SelectedValue = ddlClientName.SelectedValue;
        FillddlAsmt();
    }
    protected void DDLClientDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmtPost();
        FillDDlShift();
    }
    protected void DDLAsmtID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDlShift();
    }
    protected void DDLAreaID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaName.SelectedValue = DDLAreaID.SelectedValue;
        FillDDLClientPost();
        FillDDlShift();
    }
    protected void ddlAreaName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        DDLAreaID.SelectedValue = ddlAreaName.SelectedValue;
        FillDDLClientPost();
        FillDDlShift();
    }
    protected void ddlEmployeeNumber_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeName.SelectedValue = ddlEmployeeNumber.SelectedValue;
    }
    protected void ddlEmployeeName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeNumber.SelectedValue = ddlEmployeeName.SelectedValue;
    }
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtFromDate, lblErrorMsg))
        {
            btnViewReport.Enabled = true;
            // DateFormat(txtFromDate.Text);
            if (ddlReportName.SelectedItem.Value.ToString() == "WeeklyPostingSheet.rpt" 
                || ddlReportName.SelectedItem.Value.ToString() == "Weeklyscheduleroster.rpt"
                || ddlReportName.SelectedItem.Value.ToString() == "rpt_WeeklyActual_AsmtWise.rpt"
                || ddlReportName.SelectedItem.Value.ToString() == "rpt_WeeklySchedule_AsmtWise.rpt")
            {
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
            }
            else
            {
                txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
            }
            FillddlAsmt();
        }
        else
        {
            btnViewReport.Enabled = false;
            return;
        }
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtToDate, lblErrorMsg))
        {
            btnViewReport.Enabled = true;
            //DateFormat(txtToDate.Text);
            FillddlAsmt();
        }
        else
        {
            btnViewReport.Enabled = false;
            return;
        }
    }
    protected void ddlReportName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ShowHideReportParameterControles();
    }
    protected void ddlReportTypeMain_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlReportName();
        ShowHideReportParameterControles();
    }
    protected void ddlDivision_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivisionName.SelectedValue = ddlDivision.SelectedValue;
        FillBranch();
    }
    protected void ddlDivisionName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivision.SelectedValue = ddlDivisionName.SelectedValue;
        FillBranch();
    }
    protected void ddlBranch_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranchName.SelectedValue = ddlBranch.SelectedValue;
        FillddlAsmt();
    }
    protected void ddlAreaInchargeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeName.SelectedValue = ddlAreaInchargeCode.SelectedValue;
        FillDDlAreaID();
    }
    protected void ddlAreaInchargeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeCode.SelectedValue = ddlAreaInchargeName.SelectedValue;
        FillDDlAreaID();
    }
    protected void ddlBranchName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranch.SelectedValue = ddlBranchName.SelectedValue;
        FillddlAsmt();
    }
    protected void DDLShiftCode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillShiftTimeFromTo();
    }
    protected void txtAsOnDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtAsOnDate, lblErrorMsg);
        //DateFormat(txtAsOnDate.Text.ToString());
    }
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        HideAllControles();
        switch (strReportName)
        {
            case "schempwise.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                break;

            case "schasmtwise.rpt":
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                PanelAsmt.Visible = true;
                break;

            case "Postingsheet.rpt":
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelShift.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelSource.Visible = true;
                break;

            case "WeeklyPostingSheet.rpt":
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelShift.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
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

            case "rpt_WeeklySchedule_AsmtWise.rpt":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelReportGrid.Visible = true;
                break;

            case "rpt_MonthlySchedule_AsmtWise.rpt":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelReportGrid.Visible = true;
                break;

            case "rpt_WeeklyActual_AsmtWise.rpt":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelReportGrid.Visible = true;
                break;

            case "rpt_MonthlyActual_AsmtWise.rpt":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelReportGrid.Visible = true;
                break;

            case "dailyRefresherTrainingDue.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                ForNextNDays.Visible = true;
                break;

            case "dateRangeRefresherTrainingDue.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                break;

            case "dateRangeRefresherTrainingSchedule.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                break;
            case "ExceptionsActualVsTeken.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelDates.Visible = true;
                break;
            case "rpt_WeeklySchedule_EmpWise.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelRosterOrSchedule.Visible = true;
                break;
            default:
                break;
        }
    }
    private void HideAllControles()
    {
        PanelShift.Visible = false;
        PanelAreaID.Visible = false;
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
        PanelMonth.Visible = false;
        ForNextNDays.Visible = false;
        PanelRosterOrSchedule.Visible = false;
        PanelReportGrid.Visible = false;
    }
    #endregion

    #region Function Button event
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
        {
            string strReportPagePath = "../Reports/Rostering/";
            Context.Items.Add("cxtReportFileName", ddlReportName.SelectedValue.ToString());

            Hashtable hshRptParameters = new Hashtable();
            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedValue.ToString());

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Israel.aspx?ReportName=" + ddlReportName.SelectedValue.ToString();

            //For Grid View Reports
            if (
                    (ddlReportName.SelectedItem.Value.ToString() == "rpt_WeeklySchedule_AsmtWise.rpt" 
                    || ddlReportName.SelectedItem.Value.ToString() == "rpt_MonthlySchedule_AsmtWise.rpt"
                    ) 
                && ddlReportGrid.SelectedItem.Value.ToString() == "Grid"
                )
            {
                Context.Items.Remove("cxtHashParameters");
                hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "SCH");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/AsmtWiseSchAct.aspx");
            }
            else if (
                        (ddlReportName.SelectedItem.Value.ToString() == "rpt_WeeklyActual_AsmtWise.rpt"
                        || ddlReportName.SelectedItem.Value.ToString() == "rpt_MonthlyActual_AsmtWise.rpt"
                        )
                    && ddlReportGrid.SelectedItem.Value.ToString() == "Grid"
                    )
            {
                Context.Items.Remove("cxtHashParameters");
                hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/AsmtWiseSchAct.aspx");
            }
            else
            {
                Server.Transfer("../Reports/ViewReport1.aspx");
            }
        }
    }
    private Hashtable ReportParameter_Get(string strReportName)
    {
        Hashtable hshRptParameters = new Hashtable();
        switch (strReportName)
        {
            //case "schempwise.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.StartDate, DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
            //    hshRptParameters.Add(DL.Properties.Resources.EndDate, DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
            //    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
            //    return hshRptParameters;
            //case "schasmtwise.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Assigncode, ddlAsmtCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.StartDate, DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
            //    hshRptParameters.Add(DL.Properties.Resources.EndDate, DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
            //    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
            //    return hshRptParameters;
            //case "Postingsheet.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.Client, DDLClientDetail.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.Assign, DDLAsmtID.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.Source, ddlRptType.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.Shift, ddlShift.SelectedValue);
            //    return hshRptParameters;
            //case "WeeklyPostingSheet.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.AsmtCode, DDLAsmtID.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.Shift, ddlShift.SelectedValue);

            //    //if (Session["Country"].ToString().Trim().ToLower() == "Kuwait-AlMulla".Trim().ToLower() || Session["Country"].ToString().Trim().ToLower() == "Saudi".Trim().ToLower())
            //    if (Session["Country"].ToString().Trim().ToLower() == "Kuwait-AlMulla".Trim().ToLower())
            //    {
            //        hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
            //        Context.Items["cxtReportFileName"] = Session["Country"].ToString() + "_" + ddlReportName.SelectedItem.Value.ToString();
            //    }
            //    else
            //    {
            //        hshRptParameters.Add(DL.Properties.Resources.Country, Session["Country"].ToString());
            //    }
            //    return hshRptParameters;

            //case "Actualvsschedule.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.Assign, ddlAsmtCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ReportType, ddlReporttype.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    return hshRptParameters;
            //case "leaveconfliction.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Branch, ddlBranch.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.Division, ddlDivision.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    return hshRptParameters;
            //case "deploymentexception.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.nHrs, txtHours.Text);
            //    hshRptParameters.Add(DL.Properties.Resources.Option, ddlOption.SelectedValue.ToString());
            //    return hshRptParameters;
            //case "mismatch.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    return hshRptParameters;
            //case "siteroster.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            //    hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
            //    return hshRptParameters;
            //case "Personnelroster.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    return hshRptParameters;
            //case "availpersonnel_Greece.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

            //    //hshRptParameters.Add(DL.Properties.Resources.ShiftCode, DDLShiftCode.SelectedValue);
            //    //hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtAsOnDate.Text));
            //    //hshRptParameters.Add(DL.Properties.Resources.Option, DDLAType.SelectedValue);
            //    return hshRptParameters;
            //case "availpersonnel_Barbados.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.ShiftCode, DDLShiftCode.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.StartTime, TxtTimeFrom.Text);
            //    hshRptParameters.Add(DL.Properties.Resources.ToTime, TxtTimeTo.Text);
            //    hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.Option, DDLAType.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.Condition, ddlOptionAvailPersonnel.SelectedItem.ToString());
            //    return hshRptParameters;
            //case "ManpowerDetails.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.DayStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayStartTime.Text)));
            //    hshRptParameters.Add(DL.Properties.Resources.DayEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayEndTime.Text)));
            //    hshRptParameters.Add(DL.Properties.Resources.NightStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightStartTime.Text)));
            //    hshRptParameters.Add(DL.Properties.Resources.NightEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightEndTime.Text)));
            //    return hshRptParameters;

            case "Weeklyscheduleroster.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.Source, ddlRptType.SelectedValue.ToString());
                return hshRptParameters;

            case "DailyPostingSheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value.ToString());
                return hshRptParameters;

            case "rpt_WeeklySchedule_AsmtWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;

            case "rpt_MonthlySchedule_AsmtWise.rpt":

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;

            case "rpt_WeeklyActual_AsmtWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;

            case "rpt_MonthlyActual_AsmtWise.rpt":

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;

            case "dailyRefresherTrainingDue.rpt":

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.nDays, int.Parse(txtForNextNDays.Text.ToString()));

                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());

                return hshRptParameters;

            case "dateRangeRefresherTrainingDue.rpt":

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;

            case "dateRangeRefresherTrainingSchedule.rpt":

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;

            case "rpt_WeeklySchedule_EmpWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.RosterOrSchedule, ddlRosterOrSchedule.SelectedItem.Value.ToString());
                return hshRptParameters;

            case "ExceptionsActualVsTeken.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;

            default: return hshRptParameters;
        }
    }

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
    private bool ValidateControles(string strReportName)
    {
        switch (strReportName)
        {
            case "schempwise.rpt":
                return validateFromToDate();
            case "schasmtwise.rpt":
                return validateFromToDate();
            case "Postingsheet.rpt":
                return true;
            case "WeeklyPostingSheet.rpt":
                return validateFromToDate();
            case "Actualvsschedule.rpt":
                return validateFromToDate();
            case "leaveconfliction.rpt":
                return validateFromToDate();
            case "mismatch.rpt":
                return validateFromToDate();
            case "deploymentexception.rpt":
                return validateFromToDate();
            case "siteroster.rpt":
                return validateFromToDate();
            case "Personnelroster.rpt":
                return validateFromToDate();
            case "availpersonnel_Barbados.rpt":
                return true;
            case "availpersonnel_Greece.rpt":
                return validateFromToDate();
            case "DailyPostingSheet.rpt":
                return validateFromToDate();
            case "Weeklyscheduleroster.rpt":
                return validateFromToDate();

            case "rpt_MonthlySchedule_AsmtWise.rpt":
                return validateFromToDate();

            case "dateRangeRefresherTrainingDue.rpt":
                return validateFromToDate();

            case "dateRangeRefresherTrainingSchedule.rpt":
                return validateFromToDate();

            case "rpt_WeeklySchedule_AsmtWise.rpt":
                return validateFromToDate();

            case "rpt_MonthlyActual_AsmtWise.rpt":
                return validateFromToDate();

            case "rpt_WeeklyActual_AsmtWise.rpt":
                return validateFromToDate();


            case "dailyRefresherTrainingDue.rpt":
                if (txtFromDate.Text != "")
                {
                    if (txtForNextNDays.Text != "")
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.CannotBeLeftBlank;
                        return false;
                    }
                    
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }


            case "ManpowerDetails.rpt":
                if (txtAsOnDate.Text != "" && txtDayStartTime.Text != "" && txtDayEndTime.Text != "" && txtNightStartTime.Text != "" && txtNightEndTime.Text != "")
                {
                    return true;
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ExceptionsActualVsTeken.rpt":
                return validateFromToDate();
            case "rpt_WeeklySchedule_EmpWise.rpt":
                return validateFromToDate();

            default:
                return false;
        }
    }


    #endregion
}
