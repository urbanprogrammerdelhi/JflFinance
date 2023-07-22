// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="KPI.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using System.Data;
using Telerik.Web.UI;
/// <summary>
/// Class Transactions_KPI.
/// </summary>
public partial class Transactions_KPI : BasePage
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

            ImgFromDate.Visible = false;
            ImgToDate.Visible = false;
            DateTime from = new DateTime((DateTime.Now.Year) - 1, DateTime.Now.Month, 1);
            DateTime todate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            txtFromDate.Text = DateFormat(from);
            txtToDate.Text = DateFormat(todate);
            txtYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            FillddlCompany();
            btnViewReport.Visible = true;
            //System.Web.HttpContext.Current.Request.Url.AbsolutePath
            
        }
    }

    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        try
        {
            if(ddlLocation.CheckedItems.Count<=0)
            {
                Show("Nothing Selected");
                return;
            }
        }
        catch (Exception ex)
        {
            Show("Nothing Selected"); 
            return;
        }
        if (DateTime.Parse(txtFromDate.Text.ToString()) > DateTime.Parse(txtToDate.Text.ToString()))
        {
            lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
            return;
        }

        btnViewReport.Visible = false;

        if (ValidateControles("KPI1"))
        {
            string strReportPagePath = "../Transactions/";
            Context.Items.Add("cxtReportFileName", "KPI");

            System.Collections.Generic.List<ReportParameter> hshRptParameters = new System.Collections.Generic.List<ReportParameter>();

            hshRptParameters = ReportParameter_Get();
            Context.Items.Remove("cxtReportName");
            Context.Items.Add("cxtReportName", "KPI1");

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/KPI.aspx";
            //?ReportName=" + ddlReportName.SelectedItem.Value.ToString();
            if (chkNewScreen.Checked == true)
            {
                Context.Items.Add("cxtReportScreenType", "NewScreen");

                Server.Transfer("~/Transactions/ViewReport.aspx", true);
            }
            else
            {
                Context.Items.Add("cxtReportScreenType", "Default");
                Server.Transfer("~/Transactions/ViewReport.aspx");
            }
        }
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <returns>System.Collections.Generic.List{ReportParameter}.</returns>
    private System.Collections.Generic.List<ReportParameter> ReportParameter_Get()
    {

        BL.KPI objKPI = new BL.KPI();
        var xml = string.Empty;
        var xmlRegion = string.Empty;
        var xmlBranch = string.Empty;

        //Comma seprated value for Branch(multiple selection )
        var loc = ddlLocation.CheckedItems;

        string ddlLoc = string.Empty;
        string locationCode = string.Empty;
        if (loc.Count > 0)
        {
            foreach (var item in loc)
            {
                ddlLoc = ddlLoc + item.Value.ToString() + ",";
            }

        }

        DataSet dsxml = objKPI.GetAllKPIColorCode(DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US")), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US")));
        xml = dsxml.Tables[0].Rows[0]["xmlKPICountry"].ToString();
        xmlRegion = dsxml.Tables[0].Rows[0]["XMlKPIRegion"].ToString();
        xmlBranch = dsxml.Tables[0].Rows[0]["XMlKPIBranch"].ToString();

        //Replacing All Blank Spaces
        xml = xml.Replace(" ", "");
        xmlRegion = xmlRegion.Replace(" ", "");
        xmlBranch = xmlBranch.Replace(" ", "");

        //Task ID 736
        // modified by Manish 
        //Purpose: To Select which Level of Report to be Opened.
        string visibiltyLevel = "0";

        DataTable dsVisible = objKPI.LocationSelectionParamGet(ddlLoc, BaseCompanyCode);
        visibiltyLevel=dsVisible.Rows[0]["VisibiltyLevel"].ToString();
        /*End of Code for Task ID 736*/
       // string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string str1 = url.Substring(url.LastIndexOf('/') + 1);
        string virtualDirName = url.Replace(str1, "KpiSubReport.aspx");

        string connectionstring = BaseCountryCode;

        DL.ConnectionString objCon = new DL.ConnectionString();
        DataTable dt = objCon.ConnectionStringGet(connectionstring, "1");

        System.Collections.Generic.List<ReportParameter> aParamList = new System.Collections.Generic.List<ReportParameter>();
        aParamList.Add(new ReportParameter("CompanyCode", BaseCompanyCode));
        aParamList.Add(new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))));
        aParamList.Add(new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))));
        aParamList.Add(new ReportParameter("VirtualDirectoryName", virtualDirName));
        aParamList.Add(new ReportParameter("ColorXml", xml));
        aParamList.Add(new ReportParameter("SessionKeyValue", BaseCountryCode));
        aParamList.Add(new ReportParameter("RptServerName", dt.Rows[0][2].ToString()));
        aParamList.Add(new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()));
        aParamList.Add(new ReportParameter("UserName", dt.Rows[0][4].ToString()));
        aParamList.Add(new ReportParameter("Password", dt.Rows[0][5].ToString()));
        aParamList.Add(new ReportParameter("ColorXmlRegion", xmlRegion));
        aParamList.Add(new ReportParameter("ColorXmlBranch", xmlBranch));
        //Added New Parameter LocationAutoID 
        aParamList.Add(new ReportParameter("LocationAutoID", ddlLoc));
        //Task ID 736
        // modified by Manish 
        //Purpose: To Select which Level of Report to be Opened.
        aParamList.Add(new ReportParameter("VisiblityLevel",visibiltyLevel));
        return aParamList;
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

        switch (strReportName)
        {
            case "KPI1":
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
    /// Validates from automatic date.
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

    #region Functions Related to DropDown Company
    /// <summary>
    /// Fillddls the company.
    /// </summary>
    protected void FillddlCompany()
    {
        DataSet dsCompany = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsCompany = objblUserManagement.UserCompanyAccessGet(BaseUserID);
        if (dsCompany.Tables[0].Rows.Count > 0)
        {
            ddlCompany.DataSource = dsCompany.Tables[0];
            ddlCompany.DataValueField = "CompanyCode";
            ddlCompany.DataTextField = "CompanyDesc";
            ddlCompany.DataBind();
            ddlCompany.SelectedIndex = 0;
            FillddlHrLocation();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlCompany_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlHrLocation();
    }
    #endregion
    #region Functions Related to DropDown HrLocation
    /// <summary>
    /// Fillddls the character location.
    /// </summary>
    protected void FillddlHrLocation()
    {
        DataSet dsHrLocation = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsHrLocation = objblUserManagement.UserHRLocationAccessGet(BaseUserID, ddlCompany.SelectedValue);
        if (dsHrLocation.Tables[0].Rows.Count > 0)
        {
            ddlHrLocation.DataSource = dsHrLocation.Tables[0];
            ddlHrLocation.DataValueField = "HrLocationCode";
            ddlHrLocation.DataTextField = "HrLocationDesc";
            ddlHrLocation.DataBind();
            ddlHrLocation.AutoPostBack = true;
            if (!IsPostBack)
            {
                foreach (RadComboBoxItem item in ddlHrLocation.Items)
                {
                    if (item.Value == BaseHrLocationCode)
                    {
                        item.Checked = true;
                    }
                }

                var Hrloc = ddlHrLocation.CheckedItems;
                //For Branch
                string ddlHrLoc = string.Empty;
                string locationCode = string.Empty;
                if (Hrloc.Count > 0)
                {
                    foreach (var item in Hrloc)
                    {
                        ddlHrLoc = ddlHrLoc + item.Value.ToString() + ",";
                    }
                }
                FillddlLocation(ddlHrLoc);
            }
        }

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlHrLocation_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {


        var Hrloc = ddlHrLocation.CheckedItems;
        //For Branch
        string ddlHrLoc = string.Empty;
        string locationCode = string.Empty;
        if (Hrloc.Count > 0)
        {
            foreach (var item in Hrloc)
            {
                ddlHrLoc = ddlHrLoc + item.Value.ToString() + ",";
            }
        }

        // lblErrorMsg.Text = ddlHrLoc;
        FillddlLocation(ddlHrLoc);
    }

    #endregion
    #region Functions Related to DropDown Location

    /// <summary>
    /// Fillddls the location.
    /// </summary>
    /// <param name="ddlHrLoc">The DDL character loc.</param>
    protected void FillddlLocation(string ddlHrLoc)
    {
        ddlLocation.Items.Clear();

        DataSet dsLocation = new DataSet();

        BL.KPI objKpi = new BL.KPI();
        dsLocation = objKpi.UserLocationAccessGet(BaseUserID, ddlCompany.SelectedValue, ddlHrLoc);
        if (dsLocation.Tables[0].Rows.Count > 0)
        {
            ddlLocation.DataSource = dsLocation.Tables[0];
            ddlLocation.DataValueField = "LocationAutoID";
            ddlLocation.DataTextField = "LocationDesc";
            ddlLocation.DataBind();
        }
        foreach (RadComboBoxItem item in ddlLocation.Items)
        {
            if (item.Value == BaseLocationAutoID)
            {
                item.Checked = true;
            }
        }
    }
    #endregion
    /// <summary>
    /// Here we are setting the value from date and to date text box value on the basis of radio option they choose
    /// RY Rolling year YD Year Date MW Month wise
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void rblYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeDates();
    }

    /// <summary>
    /// Changes the dates.
    /// </summary>
    private void ChangeDates()
    {
        //Rolling Year= Current year -1 and 1 day of same month    
        if (rblYear.SelectedItem.Value == "RY")
        {
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
            ImgFromDate.Visible = false;
            ImgToDate.Visible = false;
            DateTime from = new DateTime(int.Parse(txtYear.Text) - 1, int.Parse(ddlMonth.SelectedValue), 1);
            var t = DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue));
            DateTime todate = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue)));
            txtFromDate.Text = DateFormat(from);
            txtToDate.Text = DateFormat(todate);
        }
        // YearDate=Current year from Jan to till date 
        else if (rblYear.SelectedItem.Value == "YD")
        {
            txtFromDate.Enabled = false;
            txtToDate.Enabled = false;
            ImgFromDate.Visible = false;
            ImgToDate.Visible = false;
            //From Jan to till date
            DateTime from = new DateTime(int.Parse(txtYear.Text), 1, 1);
            DateTime todate = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue)));
            txtFromDate.Text = DateFormat(from);
            txtToDate.Text = DateFormat(todate);

        }

        else if (rblYear.SelectedItem.Value == "MW")
        {
            //Code commented & Added by Manish 
            //Purpose: Tsk ID:731

            /*
            ImgFromDate.Visible = true;
            ImgToDate.Visible = true;
            txtFromDate.Enabled = true;
            txtToDate.Enabled = true;
             */
            ImgFromDate.Visible = false;
            ImgToDate.Visible = false;
            txtFromDate.Visible = false;
            txtToDate.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            ddlMonth.Focus();
            DateTime from = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), 1);
            DateTime todate = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue)));
            txtFromDate.Text = DateFormat(from);
            txtToDate.Text = DateFormat(todate);

        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ChangeDates();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        ChangeDates();
    }
    /// <summary>
    /// Handles the TextChanged event of the ddlHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlHrLocation_TextChanged(object sender, EventArgs e)
    {
        var Hrloc = ddlHrLocation.CheckedItems;
        //For Branch
        string ddlHrLoc = string.Empty;
        string locationCode = string.Empty;
        if (Hrloc.Count > 0)
        {
            foreach (var item in Hrloc)
            {
                ddlHrLoc = ddlHrLoc + item.Value.ToString() + ",";
            }
        }

        // lblErrorMsg.Text = ddlHrLoc;
        FillddlLocation(ddlHrLoc);
    }
    /// <summary>
    /// Handles the ItemChecked event of the ddlHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxItemEventArgs"/> instance containing the event data.</param>
    protected void ddlHrLocation_ItemChecked(object sender, RadComboBoxItemEventArgs e)
    {
        //string ddlHrLoc = string.Empty;

        //foreach (var item in e.Item.Checked)
        //{
        //    ddlHrLoc = ddlHrLoc + item.Value.ToString() + ",";
        //}
        //FillddlLocation(ddlHrLoc);
    }
}