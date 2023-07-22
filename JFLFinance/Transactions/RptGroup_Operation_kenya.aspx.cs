// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 03-27-2014
//
// Last Modified By : manish
// Last Modified On : 03-27-2014
// ***********************************************************************
// <copyright file="RptGroup_Operation_kenya.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using System.Threading;

/// <summary>
/// Class Transactions_RptGroup_Operation_kenya.
/// </summary>
public partial class Transactions_RptGroup_Operation_kenya : BasePage
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
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                FillddlReportName();
                FillddlDivision();
                
                var StrArray = new string[2];
                StrArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Year.ToString()));
                txtFromDate.Text = StrArray[0];
                txtToDate.Text = StrArray[1];
                FillddlClient();
                FillStatus();
                FillOption();
                ShowHideReportParameterControles();
            }
        }
    }
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        var Li = new ListItem();

       /* li = new ListItem();
        li.Text = Resources.Resource.ClientMeetingDetail.ToString();
        li.Value = "Cltmeeting.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.AssignmentInstructionDetail.ToString();
        li.Value = "Instructiondetail.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.AssignmentInstructionReview.ToString();
        li.Value = "Instreview.rpt";
        ddlReportName.Items.Add(li);*/
        Li = new ListItem
        {
            Text = Resources.Resource.rptMonthlyOperationsSummary,
            Value = @"MonthlyOpsSummary"
        };
        ddlReportName.Items.Add(Li);

        Li = new ListItem {Text = Resources.Resource.rptIncidentDetail, Value = @"IncidentDetails"};
        ddlReportName.Items.Add(Li);

        Li = new ListItem {Text = Resources.Resource.rptNightCheckVisitDetail, Value = @"NightCheckVisitDetail"};
        ddlReportName.Items.Add(Li);

        #region Reports Not in Use Hide Reports Name By  on 30-Apr-2013
        /*  Reports Not in Use Hide By 
        li = new ListItem();
        li.Text = Resources.Resource.AssignmentTrainingReport.ToString();
        li.Value = "asmttraining.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.rptClientnotMet.ToString();
        li.Value = "cltnotmet.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.rptInvestigationDetail.ToString();
        li.Value = "InvetigationDetail.rpt";
        ddlReportName.Items.Add(li);

       

        li = new ListItem();
        li.Text = Resources.Resource.rptActualNightChecksAndMeetings.ToString();
        li.Value = "EmployeeWiseAnalysis.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.AssignmentStatus.ToString();
        li.Value = "OperationStatusReport.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.rptAllotedVsDeployedHrsReport.ToString();
        li.Value = "allotedvsdeployed.rpt";
        ddlReportName.Items.Add(li);
        */
        #endregion
    }
    /// <summary>
    /// Fillddls the division.
    /// </summary>
    private void FillddlDivision()
    {
        var dsDivision = new DataSet();
        var objblUserManagement = new BL.UserManagement();
        //Modified by  on 9-Apr-2013
        //dsDivision = objblUserManagement.GetUserHrLocationAccess(BaseUserID, BaseCompanyCode);
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();

            ddlDivision.SelectedValue = BaseHrLocationCode;

            FillddlBranch();
        }
    }
    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {
        var dsBranch = new DataSet();
        var objblUserManagement = new BL.UserManagement();
        //Modified by  on 9-Apr-2013
        //dsBranch = objblUserManagement.blGetUserLocationAccess(BaseUserID, BaseCompanyCode, ddlDivision.SelectedItem.Value.ToString());
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedItem.Value.ToString());
        if (dsBranch.Tables.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
            ddlBranch.Text = BaseLocationCode;

            //ListItem li = new ListItem();
            //li.Text = Resources.Resource.All;
            //li.Value = "ALL";
            //ddlBranch.Items.Insert(0, li);
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideReportParameterControles();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt(ddlClientCode.SelectedItem.Value.ToString());
    }
    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    private void FillddlEmployeeNumber()
    {
        var objHRManagement = new BL.HRManagement();
        var ds = new DataSet();
        //Modified by  on 9-Apr-2013
        //ds = objHRManagement.blEmployeesOfLocation_GetAll(ddlBranch.Text, BaseHrLocationCode, txtFromDate.Text, txtToDate.Text);
        ds = objHRManagement.EmployeesOfLocationGetAll(ddlBranch.Text, BaseHrLocationCode, txtFromDate.Text, txtToDate.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlEmployeeNumber.DataSource = ds.Tables[0];
            ddlEmployeeNumber.DataTextField = "Name";
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataBind();
            var Li = new ListItem {Text = @Resources.Resource.All, Value = @"ALL"};
            ddlEmployeeNumber.Items.Insert(0, Li);
        }
        else
        {
            ddlEmployeeNumber.Items.Clear();
            var Li = new ListItem {Text = @Resources.Resource.NoDataToShow, Value = @"-1"};
            ddlEmployeeNumber.Items.Insert(0, Li);
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    /// <param name="strClientCode">The string client code.</param>
    private void FillddlAsmt(string strClientCode)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        //Modified by  on 9-Apr-2013
        //ds = objOperationManagement.blAssignmentsOfClient_Get(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text);
        ds = objOperationManagement.AssignmentsOfClientScheduleLockUnlockGet(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text);
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlAsmtCode.DataSource = ds.Tables[0];
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtId";
            ddlAsmtCode.DataBind();
            var Li = new ListItem {Text = Resources.Resource.All, Value = @"All"};
            ddlAsmtCode.Items.Insert(0, Li);
        }
        else
        {
            ddlAsmtCode.Items.Clear();
            var Li = new ListItem {Text = Resources.Resource.NoDataToShow, Value = @"-1"};
            ddlAsmtCode.Items.Insert(0, Li);
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        //Modified by  on 9-Apr-2013
        //ds = objSales.blClient_Get(BaseLocationAutoID);
        ds = objSales.ClientsLocationWiseGet(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlClientCode.DataSource = ds;

            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            ListItem li1 = new ListItem();
            li1.Text = "All";
            li1.Value = "All";
            ddlClientCode.Items.Insert(0, li1);

            if (ddlClientCode.SelectedItem.Value.ToString() != null)
            {
                FillddlAsmt(ddlClientCode.SelectedItem.Value.ToString());
            }
        }
        else
        {
            ddlClientCode.Items.Clear();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlClientCode.Items.Insert(0, li);
            FillddlAsmt("");
        }
    }
    /// <summary>
    /// Handles the Click event of the RefreshEmpList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void RefreshEmpList_Click(object sender, EventArgs e)
    {
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        HideAllControles();
        switch (strReportName)
        {
            case "MonthlyOpsSummary":
                PanelDates.Visible=true;
                PanelLocation.Visible = false;
                
                break;
            case "Cltmeeting.rpt":
                FillMetStatus();
                PanelMetStatus.Visible = true;
                PanelDates.Visible = true;
                break;
            case "asmttraining.rpt":
                FillddlClient();
                FillTraStatus();
                PanelClientCode.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelTraStatus.Visible = true;
                PanelDates.Visible = true;
                break;
            case "cltnotmet.rpt":
                PanelNoOfMonth.Visible = true;
                break;
            case "Instructiondetail.rpt":
               // FillddlClient();
                PanelClientCode.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelTraStatus.Visible = true;
                FillTraStatus();
                break;
            case "Instreview.rpt":
                FillddlClient();
                PanelClientCode.Visible = true;
                break;
            case "allotedvsdeployed.rpt":
                break;
            case "InvetigationDetail.rpt":
                FillddlClient();
                FillStatus();
                FillOption();
                PanelStatus.Visible = true;
                PanelIncidentOption.Visible = true;
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                break;

            case "NightCheckVisitDetail":
                
                PanelDates.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                PanelStatus.Visible = true;
                break;
            case "EmployeeWiseAnalysis.rpt":
                FillddlEmployeeNumber();
                PanelDates.Visible = true;
                PanelEmployee.Visible = true;
                break;

            case "IncidentDetails":
                //FillddlClient();
                //FillStatus();
                
                PanelStatus.Visible = true;
                PanelIncidentOption.Visible = true;
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                break;
            case "OperationStatusReport.rpt":
                FillStatus();
                PanelStatus.Visible = true;
                PanelDates.Visible = true;
                break;

            default:
                break;
        }
    }
    /// <summary>
    /// Fills the option.
    /// </summary>
    protected void FillOption()
    {
        ddlOption.Items.Clear();
        BL.OperationManagement objoperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        //Modified by  on 9-Apr-2013
        //ds = objoperationManagement.blIncident_GetItemDesc(BaseCompanyCode);
        ds = objoperationManagement.IncidentItemDescGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["ItemDesc"] = ResourceValueOfKey_Get(ds.Tables[0].Rows[i]["ItemDesc"].ToString());
            }
            ddlOption.DataSource = ds;
            ddlOption.DataTextField = "ItemDesc";
            ddlOption.DataValueField = "ItemCode";
            ddlOption.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData;
            li.Value = "0";
            ddlOption.Items.Add(li);
        }
    }

    /// <summary>
    /// Fills the status.
    /// </summary>
    protected void FillStatus()
    {
        ddlStatus.Items.Clear();
        ListItem LI = new ListItem();
        LI.Text = Resources.Resource.All;
        LI.Value = "ALL";
        ddlStatus.Items.Add(LI);

        ListItem LI2 = new ListItem();
        LI2.Text = Resources.Resource.Authorized;
        LI2.Value = strStatusAuthorized;
        ddlStatus.Items.Add(LI2);

        ListItem LI1 = new ListItem();
        LI1.Text = Resources.Resource.Fresh;
        LI1.Value = strStatusFresh;
        ddlStatus.Items.Add(LI1);

        ListItem LI3 = new ListItem();
        LI3.Text = Resources.Resource.Amend;
        LI3.Value = strStatusAmend;
        ddlStatus.Items.Add(LI3);

        LI3 = new ListItem();
        LI3.Text = Resources.Resource.Terminated;
        LI3.Value = strStatusTerminated;
        ddlStatus.Items.Add(LI3);
    }
    /// <summary>
    /// Fills the met status.
    /// </summary>
    protected void FillMetStatus()
    {
        ddlMetStatus.Items.Clear();
        ListItem LI = new ListItem();
        LI.Text = Resources.Resource.All;
        LI.Value = "ALL";
        ddlMetStatus.Items.Add(LI);

        ListItem LI2 = new ListItem();
        LI2.Text = Resources.Resource.ObservationAuthorized;
        LI2.Value = "Observation Authorized";
        ddlMetStatus.Items.Add(LI2);

        ListItem LI1 = new ListItem();
        LI1.Text = Resources.Resource.Fresh;
        LI1.Value = strStatusFresh;
        ddlMetStatus.Items.Add(LI1);

        ListItem LI3 = new ListItem();
        LI3.Text = Resources.Resource.PlanAuthorized;
        LI3.Value = "Plan Authorized";
        ddlMetStatus.Items.Add(LI3);

        LI3 = new ListItem();
        LI3.Text = Resources.Resource.ActionAuthorized;
        LI3.Value = "Action Authorized";
        ddlMetStatus.Items.Add(LI3);
    }
    /// <summary>
    /// Fills the tra status.
    /// </summary>
    protected void FillTraStatus()
    {
        ddlTraStatus.Items.Clear();
        ListItem LI = new ListItem();
        LI.Text = Resources.Resource.All;
        LI.Value = "ALL";
        ddlTraStatus.Items.Add(LI);

        ListItem LI2 = new ListItem();
        LI2.Text = Resources.Resource.Authorized;
        LI2.Value = strStatusAuthorized;
        ddlTraStatus.Items.Add(LI2);

        ListItem LI1 = new ListItem();
        LI1.Text = Resources.Resource.Fresh;
        LI1.Value = strStatusFresh;
        ddlTraStatus.Items.Add(LI1);

        ListItem LI3 = new ListItem();
        LI3.Text = Resources.Resource.Amend;
        LI3.Value = strStatusAmend;
        ddlTraStatus.Items.Add(LI3);
    }
    /// <summary>
    /// Hides all controles.
    /// </summary>
    private void HideAllControles()
    {
        PanelClientCode.Visible = false;
        PanelAsmtCode.Visible = false;
        PanelMetStatus.Visible = false;
        PanelTraStatus.Visible = false;
        PanelDates.Visible = false;
        PanelDates.Visible = false;
        PanelNoOfMonth.Visible = false;
        PanelStatus.Visible = false;
        PanelIncidentOption.Visible = false;
        PanelEmployee.Visible = false;
        //PanelAsmtCode.Visible = false;
        //PanelClientCode.Visible = false;
        //PanelInvoiceType.Visible = false;
        //PanelShift.Visible = false;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlBranch();
    }

    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
        {
            string strReportPagePath = "../Reports/OPS/";
            Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value);

            System.Collections.Generic.List<ReportParameter> hshRptParameters = new System.Collections.Generic.List<ReportParameter>();
            
            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value);
            Context.Items.Remove("cxtReportName");
            Context.Items.Add("cxtReportName", ddlReportName.SelectedItem.Value);

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Operation_kenya.aspx?ReportName=" + ddlReportName.SelectedItem.Value.ToString();
            Server.Transfer("~/Transactions/ViewReport.aspx");
        }
    }

    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>System.Collections.Generic.List&lt;ReportParameter&gt;.</returns>
    private System.Collections.Generic.List<ReportParameter> ReportParameter_Get(string strReportName)
    {
        System.Collections.Generic.List<ReportParameter> aParamList = new System.Collections.Generic.List<ReportParameter>();
        string connectionstring = BaseCountryCode;

        var objCon = new DL.ConnectionString();
        var Dt = objCon.ConnectionStringGet(connectionstring, "1");

        switch (strReportName)
        {
            //case "Cltmeeting.rpt":
            //    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //    hshRptParameters.Add("@LocationCode", ddlBranch.Text.ToString());
            //    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
            //    //Modified by 
            //    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text));
            //    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text));
            //    //hshRptParameters.Add("@FromDate", DateFormat(txtFromDate.Text));
            //    //hshRptParameters.Add("@ToDate", DateFormat(txtToDate.Text));
            //    hshRptParameters.Add("@Status", ddlMetStatus.SelectedValue.ToString());
            //    return hshRptParameters;

            //case "asmttraining.rpt":
            //    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text));
            //    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text));
            //    hshRptParameters.Add("@LocationCode", ddlBranch.Text.ToString());
            //    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedItem.Value.ToString());
            //    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //    hshRptParameters.Add("@ClientCode", ddlClientCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add("@AsmtCode", ddlAsmtCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add("@Status", ddlTraStatus.SelectedValue.ToString());
            //    return hshRptParameters;

            //case "cltnotmet.rpt":
            //    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //    hshRptParameters.Add("@LocationCode", ddlBranch.Text.ToString());
            //    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
            //    hshRptParameters.Add("@month", TxtMonth.Text);

            //    return hshRptParameters;
            //case "Instructiondetail.rpt":
            //    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //    hshRptParameters.Add("@LocationCode", ddlBranch.Text.ToString());
            //    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
            //    hshRptParameters.Add("@ClientCode", ddlClientCode.SelectedValue.ToString());
            //    hshRptParameters.Add("@AsmtCode", ddlAsmtCode.SelectedValue.ToString());
            //    hshRptParameters.Add("@Status", ddlTraStatus.SelectedValue.ToString());

            //    return hshRptParameters;
            //case "Instreview.rpt":
            //    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //    hshRptParameters.Add("@LocationCode", ddlBranch.Text.ToString());
            //    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
            //    hshRptParameters.Add("@ClientCode", ddlClientCode.SelectedValue.ToString());
            //    return hshRptParameters;
            //case "allotedvsdeployed.rpt":
            //    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //    hshRptParameters.Add("@LocationCode", ddlBranch.Text.ToString());
            //    hshRptParameters.Add("@HRLocationCode", ddlDivision.SelectedValue.ToString());
            //    return hshRptParameters;
            //case "InvetigationDetail.rpt":
            //    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //    hshRptParameters.Add("@LocationCode", ddlBranch.Text.ToString());
            //    hshRptParameters.Add("@HRLocationCode", ddlDivision.SelectedValue.ToString());
            //    hshRptParameters.Add("@ClientCode", ddlClientCode.SelectedValue.ToString());
            //    hshRptParameters.Add("@Option", ddlOption.SelectedValue.ToString());
            //    hshRptParameters.Add("@Status", ddlStatus.SelectedValue.ToString());
            //    hshRptParameters.Add("@FromDate", DL.Common.DateFormat(txtFromDate.Text));
            //    hshRptParameters.Add("@ToDate", DL.Common.DateFormat(txtToDate.Text));
            //    return hshRptParameters;

            case "MonthlyOpsSummary":


                aParamList.Add(new ReportParameter("LocationAutoID", BaseLocationAutoID));
                aParamList.Add(new ReportParameter(DL.Properties.Resources.FromDate.Remove(0,1), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))));
                aParamList.Add(new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))));
                aParamList.Add(new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name));
                aParamList.Add(new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()));
                aParamList.Add(new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()));
                aParamList.Add(new ReportParameter("UserName", Dt.Rows[0][4].ToString()));
                aParamList.Add(new ReportParameter("Password", Dt.Rows[0][5].ToString()));

                return aParamList;

            case "NightCheckVisitDetail":


                aParamList.Add(new ReportParameter("CompanyCode", BaseCompanyCode));
                aParamList.Add(new ReportParameter("HrLocationCode", ddlDivision.SelectedValue.ToString()));
                aParamList.Add(new ReportParameter("LocationCode", ddlBranch.Text.ToString()));
                
                aParamList.Add(new ReportParameter("ClientCode", ddlClientCode.SelectedValue.ToString()));
                aParamList.Add(new ReportParameter("AsmtID", ddlAsmtCode.SelectedValue.ToString()));
                aParamList.Add(new ReportParameter("Status", ddlStatus.SelectedValue.ToString()));
                aParamList.Add(new ReportParameter("FromDate", DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))));
                aParamList.Add(new ReportParameter("ToDate", DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))));
                aParamList.Add(new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name));
                aParamList.Add(new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()));
                aParamList.Add(new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()));
                aParamList.Add(new ReportParameter("UserName", Dt.Rows[0][4].ToString()));
                aParamList.Add(new ReportParameter("Password", Dt.Rows[0][5].ToString()));



                return aParamList;

            //case "EmployeeWiseAnalysis.rpt":
            //    aParamList.Add(new ReportParameter("@CompanyCode", BaseCompanyCode);
            //    aParamList.Add(new ReportParameter("@LocationCode", ddlBranch.Text.ToString());
            //    aParamList.Add(new ReportParameter("@HRLocationCode", ddlDivision.SelectedValue.ToString());
            //    aParamList.Add(new ReportParameter("@FromDate", DL.Common.DateFormat(txtFromDate.Text));
            //    aParamList.Add(new ReportParameter("@ToDate", DL.Common.DateFormat(txtToDate.Text));
            //    aParamList.Add(new ReportParameter("@EmployeeNumber", ddlEmployeeNumber.SelectedItem.Value.ToString());
            //    return hshRptParameters;

            case "IncidentDetails":
                aParamList.Add(new ReportParameter("CompanyCode", BaseCompanyCode));
                aParamList.Add(new ReportParameter("HRLocationCode", ddlDivision.SelectedValue.ToString()));
                aParamList.Add(new ReportParameter("LocationCode", ddlBranch.Text.ToString()));
                
                aParamList.Add(new ReportParameter("ClientCode", ddlClientCode.SelectedValue.ToString()));
                aParamList.Add(new ReportParameter("Option", ddlOption.SelectedValue.ToString()));
                aParamList.Add(new ReportParameter("Status", ddlStatus.SelectedValue.ToString()));
                //Modified By  
                aParamList.Add(new ReportParameter("FromDate", DL.Common.DateFormat(txtFromDate.Text,new CultureInfo("en-US"))));
                aParamList.Add(new ReportParameter("ToDate", DL.Common.DateFormat(txtToDate.Text,new CultureInfo("en-US"))));
                aParamList.Add(new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name));
                aParamList.Add(new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()));
                aParamList.Add(new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()));
                aParamList.Add(new ReportParameter("UserName", Dt.Rows[0][4].ToString()));
                aParamList.Add(new ReportParameter("Password", Dt.Rows[0][5].ToString()));

            //hshRptParameters.Add("@FromDate", DateFormat(txtFromDate.Text));
                //hshRptParameters.Add("@ToDate", DateFormat(txtToDate.Text));

                return aParamList;

            //case "OperationStatusReport.rpt":
            //    hshRptParameters.Add("@CompanyCode", BaseCompanyCode);
            //    hshRptParameters.Add("@LocationCode", ddlBranch.Text.ToString());
            //    hshRptParameters.Add("@HrLocationCode", ddlDivision.SelectedValue.ToString());
            //    hshRptParameters.Add("@status", ddlStatus.SelectedItem.Value.ToString());
            //    hshRptParameters.Add("@fromdate", DL.Common.DateFormat(txtFromDate.Text));
            //    hshRptParameters.Add("@todate", DL.Common.DateFormat(txtToDate.Text));
            //    return hshRptParameters;

            default: return aParamList;
        }
    }

    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool validateFromToDate()
    {
        BL.Common objCommon = new BL.Common();
        if (objCommon.IsValidDate(txtFromDate.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtFromDate.Focus();
            return false;
        }
        if (objCommon.IsValidDate(txtToDate.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtToDate.Focus();
            return false;
        }

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
        bool returnStatus = false;
        bool returnValFromToDate = false;
        bool returnValClientCode = false;
        bool returnValAsmtCode = false;
        bool NoOfMonths = false;
        bool allotedVsDeployed = false;
        bool returnValEmployee = false;
        if (ddlBranch.Text.ToString() == "")
        {
            lblErrorMsg.Text = Resources.Resource.Location + " " + Resources.Resource.CannotBeLeftBlank;
            return false;
        }


        switch (strReportName)
        {
            case "Cltmeeting.rpt":
                returnValFromToDate = validateFromToDate();
                if (returnValFromToDate == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "asmttraining.rpt":
                returnValFromToDate = validateFromToDate();
                returnValClientCode = validateClientCode();
                returnValAsmtCode = validateAsmtCode();
                if (returnValFromToDate == true && returnValClientCode == true && returnValAsmtCode == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;


            case "cltnotmet.rpt":
                NoOfMonths = ValidateNoOfMonths();
                if (NoOfMonths == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "Instructiondetail.rpt":
                returnValClientCode = validateClientCode();
                returnValAsmtCode = validateAsmtCode();
                if (returnValClientCode == true && returnValAsmtCode == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "Instreview.rpt":
                returnValClientCode = validateClientCode();
                if (returnValClientCode == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "allotedvsdeployed.rpt":
                allotedVsDeployed = true;
                if (allotedVsDeployed == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "InvetigationDetail.rpt":
                returnValClientCode = validateClientCode();
                returnValFromToDate = validateFromToDate();
                if (returnValClientCode == true && returnValFromToDate == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "NightCheckVisitDetail":
                returnValFromToDate = validateFromToDate();
                returnValClientCode = validateClientCode();
                returnValAsmtCode = validateAsmtCode();
                if (returnValFromToDate == true && returnValClientCode == true && returnValAsmtCode == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "EmployeeWiseAnalysis.rpt":
                returnValFromToDate = validateFromToDate();
                returnValEmployee = validateEmployee();
                if (returnValFromToDate == true && returnValEmployee == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "IncidentDetails":
                returnValClientCode = validateClientCode();
                returnValFromToDate = validateFromToDate();
                if (returnValClientCode == true && returnValFromToDate == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "OperationStatusReport.rpt":
                returnValFromToDate = validateFromToDate();
                if (returnValFromToDate == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            case "MonthlyOpsSummary":
                returnValFromToDate = validateFromToDate();
                if (returnValFromToDate == true)
                {
                    returnStatus = true;
                }
                else
                {
                    returnStatus = false;
                }
                return returnStatus;
            default:
                return false;
        }
    }

    /// <summary>
    /// Validates the employee.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool validateEmployee()
    {
        if (ddlEmployeeNumber.SelectedValue.ToString() == "-1")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Validates the no of months.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateNoOfMonths()
    {
        if (TxtMonth.Text != "")
        {
            return true;
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.CannotBeLeftBlank;
            return false;
        }
    }

    /// <summary>
    /// Validates the asmt code.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool validateAsmtCode()
    {
        if (ddlAsmtCode.SelectedValue.ToString() == "-1")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Validates the client code.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool validateClientCode()
    {
        if (ddlClientCode.SelectedValue.ToString() == "-1")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
