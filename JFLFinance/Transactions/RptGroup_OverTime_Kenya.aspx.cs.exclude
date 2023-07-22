// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_OverTime_Kenya.aspx.cs" company="Magnon">
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
using System.Collections.Generic;
/// <summary>
/// Class Transactions_RptGroup_OverTime_Kenya.
/// </summary>
public partial class Transactions_RptGroup_OverTime_Kenya : BasePage
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
            //{ lblPageHdrTitle.Text = Resources.Resource.OTReport; }

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.OTReport + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID.ToString() + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID.ToString() + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");

                FillddlReportName();
                FillddlType();

                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }

                //// *******  modified by Manish on 16-mar-2010 added new common bl function SetDatesFromPayPeriod *********
                //// ******* due to getting dates according to pay period ***********************************************

                string[] strArray = new string[2];
                strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Year.ToString()));
                txtFromDate.Text = strArray[0];
                txtToDate.Text = strArray[1];


                //txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                //txtToDate.Text = LastDateOfCurrentMonth_Get();
                FillddlAreaID();//Added by Manoj(New Parameter for All Reports) on 19/01/2012
                ShowHideReportParameterControles();
                txtYear.Text = DateTime.Now.Year.ToString();

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

        lblErrorMsg.Text = "";
    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        //ListItem li = new ListItem();
        //li.Text = Resources.Resource.OTReport.ToString();
        //li.Value = "OTReport";
        //ddlReportName.Items.Add(li);
        ListItem li = new ListItem();
        li.Text = Resources.Resource.OTReport.ToString();

        if (BaseCompanyCode == "BARBDOS")
        {
            li.Value = "OverTimeReportBarbados.rpt";
        }
        else
        {
            li.Value = "OTReport";
        }
        ddlReportName.Items.Add(li);

        //if (Session["Country"] == "Kuwait-AlMulla")
        //{
        //    ListItem li = new ListItem();
        //    li.Text = Resources.Resource.ProjectedOT.ToString();
        //    li.Value = "ProjectedOTDetails.rpt";
        //    ddlReportName.Items.Add(li);
        //}

        // li = new ListItem();
        // li.Text = Resources.Resource.ProjectedOTSummary.ToString();
        //li.Value = "ProjectedOTSummary.rpt";
        //ddlReportName.Items.Add(li);
    }
    /// <summary>
    /// Fillddls the type.
    /// </summary>
    protected void FillddlType()
    {
        DataSet ds = new DataSet();

        ListItem li = new ListItem();
        li.Text = Resources.Resource.Details;
        li.Value = "Details";
        ddlType.Items.Insert(0, li);

        ListItem l1 = new ListItem();
        l1.Text = Resources.Resource.Summary;
        l1.Value = "Summary";
        ddlType.Items.Add(l1);

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
        ShowHideReportParameterControles();
    }
    //protected void txtFromDate_TextChanged(object sender, EventArgs e)
    //{
    //    DateFormat(txtFromDate.Text.ToString());
    //    txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text.ToString());
    //}
    //protected void txtToDate_TextChanged(object sender, EventArgs e)
    //{
    //    DateFormat(txtToDate.Text.ToString());
    //}

    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        HideAllControles();
        switch (strReportName)
        {
            case "OTReport":
                PanelDates.Visible = true;

                break;
            case "OverTimeReportBarbados.rpt":
                PanelDates.Visible = true;

                break;
            case "ProjectedOTDetails.rpt":
                PanelMonth.Visible = true;
                PanelType.Visible = true;
                PanelChkNegative.Visible = true;
                PanelddlSchAct.Visible = true;
                PanelChkWithOutZeroAttendance.Visible = true;
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
        PanelMonth.Visible = false;
        PanelType.Visible = false;
        PanelDates.Visible = false;
        PanelChkNegative.Visible = false;
        PanelddlSchAct.Visible = false;
        PanelChkWithOutZeroAttendance.Visible = false;

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
        if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
        {
            System.Collections.Generic.List<ReportParameter> hshRptParameters = new System.Collections.Generic.List<ReportParameter>();
            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());

            Context.Items.Remove("cxtReportName");
            Context.Items.Add("cxtReportName", ddlReportName.SelectedItem.Value.ToString());

            string strReportPagePath = "../Reports/Rostering/";
            Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value.ToString());

            //Hashtable hshRptParameters = new Hashtable();
            //hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_OverTime_Kenya.aspx?ReportName=" + ddlReportName.SelectedItem.Value.ToString();
            Server.Transfer("../Reports/ViewReport.aspx");
        }
    }
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    private void FillddlAreaID()
    {
        ddlAreaID.Items.Clear();
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsArea = new DataSet();
        //Added by Manoj on 03/09/12
        dsArea = objSale.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID);
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
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>System.Collections.Generic.List&lt;ReportParameter&gt;.</returns>
    private System.Collections.Generic.List<ReportParameter> ReportParameter_Get(string strReportName)
    {
        var HshRptParameters = new System.Collections.Hashtable();
        var Connectionstring = BaseCountryCode;
        var ObjCon = new DL.ConnectionString();
        var Dt = ObjCon.ConnectionStringGet(Connectionstring, "1");
        var aParamList = new List<ReportParameter>();
        if (txtYear.Text == "")
        {
            txtYear.Text = DateTime.Now.Year.ToString();
        }

        
        switch (strReportName)
        {
            case "OTReport":
                 aParamList = new List<ReportParameter>
                 {
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), BaseLocationCode),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text,new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text,new CultureInfo("en-US"))),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),Dt.Rows[0][4].ToString()),
                new ReportParameter("Password", Dt.Rows[0][5].ToString())
                };
                return aParamList;
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
        switch (strReportName)
        {

            case "OTReport":
                return validateFromToDate();
            case "OverTimeReportBarbados.rpt":
                return validateFromToDate();
            case "ProjectedOTDetails.rpt":
                return true;

            default:
                return false;
        }
    }
    #endregion
}
