// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 06-26-2014
//
// ***********************************************************************
// <copyright file="Rpt_EmployeeWorkHistoryDetail.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using BL;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using Telerik.Web.UI;


/// <summary>
/// Class Rpt_EmployeeWorkHistoryDetail.
/// </summary>
public partial class Rpt_EmployeeWorkHistoryDetail : BasePage
{
    #region Member Declaration
    private const string none = @"0";
    private const string all = @"All";
    private const string negative = @"-1";
    private const string systemUser = @"system";
    private const string strReportName = @"EmployeeWorkHistory";
    private const string strReportPagePath = @"../Reports/Rostering/";
    private const string targetUrl = @"../HRManagement/EmployeeWorkHistoryDetail.aspx";
    private const string returnPage = @"../HRManagement/Rpt_EmployeeWorkHistoryDetail.aspx?ReportName=";
    private UserManagement _objblUserManagement = null;
    private HRManagement _objHrManagement = null;
    private OperationManagement _operationManagement = null;
    private Sales _objSales = null;
    #endregion

    #region Class Constractor
    public Rpt_EmployeeWorkHistoryDetail()
    {
        _objblUserManagement = new BL.UserManagement();
        _objHrManagement = new HRManagement();
        _operationManagement = new OperationManagement();
        _objSales = new Sales();
    }
    #endregion

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
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, System.StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
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
            var JavaScript = new System.Text.StringBuilder();
            JavaScript.Append("<script type='text/javascript'>");
            JavaScript.Append("window.document.body.onload = function ()");
            JavaScript.Append("{\n");
            JavaScript.Append("PageTitle('" + Resources.Resource.Schedules + "');");
            JavaScript.Append("};\n");
            JavaScript.Append("// -->\n");
            JavaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", JavaScript.ToString());

            if (IsReadAccess)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();

                FillDivision();
                btnViewReport.Enabled = true;

                var ds = _objblUserManagement.SystemParameterValuesByCompany(Convert.ToInt32(BaseLocationAutoID), "ConfirmDuty");
                if (ds != null && ds.Tables[0].Rows.Count > 0 && Convert.ToString(ds.Tables[0].Rows[0]["ParamValue1"]) == "1")
                {
                    PanelConfirmDuty.Visible = true;
                    ddlConfirmDuty.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ParamValue1"]);
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Fill Drop Down Controls
    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision()
    {
        ddlDivision.Items.Clear();
        ddlBranch.Items.Clear();
        var dsDivision = _objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDescCode";
            ddlDivision.DataBind();

            if (PanelDivision.Visible && ddlDivision.Items.Count > 0)
            {
                ddlDivision.SelectedValue = BaseHrLocationCode;
            }
            FillBranch();
        }
    }

    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        var dsBranch = _objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationAutoId";
            ddlBranch.DataTextField = "LocationDescCode";
            ddlBranch.DataBind();

            if (PanelBranch.Visible && ddlBranch.Items.Count > 0)
            {
                ddlBranch.SelectedValue = BaseLocationAutoID;
            }
            FillddlAreaInchargeDetails();
        }
    }

    /// <summary>
    /// Fill AreaIncharge Dropdown on Location Basis
    /// </summary>
    private void FillddlAreaInchargeDetails()
    {
        var employeeNumber = String.Empty;
        if (BaseUserIsAreaIncharge == none && BaseUserID != systemUser)
        {
            employeeNumber = BaseUserEmployeeNumber;
        }
        ddlAreaInchargeCode.Items.Clear();

        var ds = _objHrManagement.AreaInchargeGetBasedonUserID(ddlBranch.SelectedValue != string.Empty ? ddlBranch.SelectedItem.Value : BaseLocationAutoID, employeeNumber, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaInchargeCode.DataSource = ds.Tables[0];
            ddlAreaInchargeCode.DataValueField = "EmployeeCode";
            ddlAreaInchargeCode.DataTextField = "InchargeDetail";
            ddlAreaInchargeCode.DataBind();

            var LI2 = new RadComboBoxItem { Text = Resources.Resource.All, Value = all };
            ddlAreaInchargeCode.Items.Insert(0, LI2);
        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = negative };
            ddlAreaInchargeCode.Items.Insert(0, li1);
        }
        FillddlAreaId();
    }

    /// <summary>
    /// Fill AreaId Dropdown on AreaIncharge Basis
    /// </summary>
    private void FillddlAreaId()
    {
        ddlAreaId.Items.Clear();
        var ds = _operationManagement.AreaIdGet(ddlBranch.SelectedValue != string.Empty ? ddlBranch.SelectedItem.Value : BaseLocationAutoID, ddlAreaInchargeCode.SelectedValue);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaId.DataSource = ds;
            ddlAreaId.DataValueField = "AreaID";
            ddlAreaId.DataTextField = "AreaDetail";
            ddlAreaId.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = all };
            ddlAreaId.Items.Insert(0, li);
        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = negative };
            ddlAreaId.Items.Insert(0, li1);
        }
        FillddlClient();
        FillddlEmployeeNumber();
    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        var ds = new DataSet();
        ddlClientCode.Items.Clear();
        if (ddlAreaId.SelectedValue == all)
        {
            var liClient = new RadComboBoxItem { Text = Resources.Resource.All, Value = all };
            ddlClientCode.Items.Insert(0, liClient);
        }
        
        ds = _objSales.ClientAreaWiseGet(ddlBranch.SelectedValue, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaId.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = all;
            ddlClientCode.Items.Insert(0, li);
        }
        else
        {
            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = negative;
            ddlClientCode.Items.Insert(0, li);
        }
        FillddlAsmt();
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        var dsAsmt = new DataSet();
        ddlAsmtId.Items.Clear();
        if (ddlClientCode.SelectedValue == all)
        {
            var liAsmt = new RadComboBoxItem { Text = Resources.Resource.All, Value = all };
            ddlAsmtId.Items.Insert(0, liAsmt);
        }
        else
        {
            dsAsmt = _operationManagement.AssignmentsOfClientGet(int.Parse(ddlBranch.SelectedValue), ddlClientCode.SelectedValue, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedValue, ddlAreaId.SelectedValue);
            if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
            {
                ddlAsmtId.DataSource = dsAsmt.Tables[0];
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();

                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.All;
                li1.Value = all;
                ddlAsmtId.Items.Insert(0, li1);
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = negative;
                ddlAsmtId.Items.Insert(0, li1);
            }
        }
    }

    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    protected void FillddlEmployeeNumber()
    {
        ddlEmployeeNumber.Items.Clear();
        if (ddlAreaId.SelectedValue == all)
        {
            var liEmp = new RadComboBoxItem { Text = Resources.Resource.All, Value = all };
            ddlEmployeeNumber.Items.Insert(0, liEmp);
        }
        string[] arLocationCode = (ddlBranch.SelectedItem.Text).Split('(');
        var strLocationCode = arLocationCode[1];
        arLocationCode = strLocationCode.Split(')');
        DataSet ds = _objHrManagement.EmployeesOfLocationAreaWiseGetForTraining(BaseCompanyCode, ddlDivision.SelectedValue, arLocationCode[0], txtFromDate.Text, txtToDate.Text, ddlAreaId.SelectedValue, ddlAreaInchargeCode.SelectedValue, BaseUserIsAreaIncharge);
        //DataSet ds = _objHrManagement.EmployeeNameGetAllBasedOnClientAsmtInchargeAreaIdForSelectedWeek(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaId.SelectedItem.Value, txtFromDate.Text, txtToDate.Text, ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlEmployeeNumber.DataSource = ds.Tables[0];
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataTextField = "EmployeeDetail";
            ddlEmployeeNumber.DataBind();

            var li2 = new RadComboBoxItem { Text = Resources.Resource.All, Value = all };
            ddlEmployeeNumber.Items.Insert(0, li2);
        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = negative };
            ddlEmployeeNumber.Items.Insert(0, li1);
        }
    }
    #endregion

    #region Controles Events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaId control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaId_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlClient();
        FillddlEmployeeNumber();
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
            //txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
        }
        else
        {
            btnViewReport.Enabled = false;
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
        }
        else
        {
            btnViewReport.Enabled = false;
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillBranch();
        FillddlAreaInchargeDetails();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlAreaInchargeDetails();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAreaId();
        FillddlEmployeeNumber();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt();
        FillddlEmployeeNumber();
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtId control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtId_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlEmployeeNumber();
    }
    #endregion

    #region Function Button event
    /// <summary>
    /// Function used to handle button View Report Click event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        if(validateFromToDate())
        {
            Context.Items.Add("cxtReportFileName", strReportName);

            var hshRptParameters = new Hashtable();
            hshRptParameters = ReportParameter_Get(strReportName);

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = returnPage + strReportName;

            try
            {
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                Server.Transfer(targetUrl);
            }
            catch (Exception)
            {
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            }
        }
    }

    /// <summary>
    /// function used to set parameter list for reports based on report name.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        var hshRptParameters = new Hashtable();
        switch (strReportName)
        {
            case "EmployeeWorkHistory":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(ddlBranch.SelectedItem.Value));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaId.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, ddlAsmtId.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ConfirmDuty, ddlConfirmDuty.SelectedValue);
                return hshRptParameters;

            default: return hshRptParameters;
        }
    }

    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns>bool</returns>
    protected bool validateFromToDate()
    {
        if (!string.IsNullOrEmpty(txtToDate.Text) && !string.IsNullOrEmpty(txtFromDate.Text))
        {
            if (GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                return false;
            }
            return true;
        }
        lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
        return false;
    }
    #endregion
}
