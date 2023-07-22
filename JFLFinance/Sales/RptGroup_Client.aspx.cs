// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_Client.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;
using Resource = Resources.Resource;

/// <summary>
/// Class Sales_RptGroup_Client.
/// </summary>
public partial class Sales_RptGroup_Client : BasePage
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
            //Button1.Attributes["onMouseDown"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ViewReport1.aspx';";
            //this.Form.Attributes["onMouseOver"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";
            //this.Button1.Attributes.Add("onclick","this.form.target='_blank'");

            /* code added by Manish to Open report in New Page*/
            //======================================================

            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.Client; }

            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Client + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientName.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
                ImgbtnSearchSoNo.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH004&ControlId=" + txtSoNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");

                FillddlReportName();
                FillddlClientName();
                FillddlBranch();
                FillAllTrainings();

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
            txtFromDate.Text = FirstDateOfCurrentMonth_Get();
            txtToDate.Text = LastDateOfCurrentMonth_Get();
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
        li.Text = Resources.Resource.ClientList.ToString();
        li.Value = "ClientList.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.ClientAsmtIDList.ToString();
        li.Value = "ClientAssignmentList.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resource.ClientConstraints, Value = @"CustomerConstraint" };
        ddlReportName.Items.Add(li);

        if (BaseCompanyCode == "AMSSKW")
        {
            li = new ListItem();
            li.Text = Resources.Resource.ClientSectorBreakDown.ToString();
            li.Value = "rptSale_MsxmlClientSectorBreakDown.aspx";
            ddlReportName.Items.Add(li);
        }

    }

    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, BaseHrLocationCode);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            DataRow dr = dsBranch.Tables[0].NewRow();
            dr["LocationCode"] = "All";
            dr["LocationDesc"] = "All";
            dsBranch.Tables[0].Rows.InsertAt(dr, 0);
            msddlBranch.CreateCheckBox(dsBranch.Tables[0], "LocationDesc", "LocationCode");

            int msddlBranchselectedIndex;
            msddlBranchselectedIndex = 0;
            for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
            {
                if (dsBranch.Tables[0].Rows[i]["LocationCode"].ToString() == BaseLocationCode.ToString())
                {
                    msddlBranch.selectedIndex = i.ToString();
                    i = dsBranch.Tables[0].Rows.Count;
                }
            }

            if (msddlBranchselectedIndex != 0)
            {
                msddlBranch.selectedIndex = "1";
            }
        }


    }
    /// <summary>
    /// Fillddls the name of the client.
    /// </summary>
    protected void FillddlClientName()
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
            ddlClientName.DataSource = ds.Tables[0];
            ddlClientName.DataTextField = "ClientNameCode";
            ddlClientName.DataValueField = "ClientCode";
            ddlClientName.DataBind();
        }

        ListItem li2 = new ListItem();
        li2.Text = Resources.Resource.SelectAll;
        li2.Value = "";
        ddlClientName.Items.Insert(0, li2);
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
    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        HideAllControles();
        switch (strReportName)
        {
            case "ClientList.rpt":
                PanelClientName.Visible = true;
                PanelCenterlize.Visible = true;
                break;
            case "ClientAssignmentList.rpt":
                break;
            case "Client Profile.rpt":
                PanelClientName.Visible = true;
                break;
            case "Client Profitablility Report.rpt":
                PanelClientName.Visible = true;
                PanelDates.Visible = true;
                break;
            case "SalesOrderHistory.rpt":
                PanelSoNo.Visible = true;
                break;
            case "SectorWiseInvoiceAmtSummary.rpt":
                PanelMonth.Visible = true;
                PanelYear.Visible = true;
                break;
            case "ClientListNoContractSign.rpt":
                PanelBranch.Visible = true;
                break;
            case "rptSale_MsxmlClientSectorBreakDown.aspx":
                PanelDates.Visible = true;
                break;
            case @"CustomerConstraint":
                PanelDivision1.Visible = true;
                PanelBranch1.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID1.Visible = true;
                PanelClientCode1.Visible = true;
                PanelAsmtID1.Visible = true;
                PanelPost1.Visible = true;
                PnlIsMandatory.Visible = true;
                pnlTraining.Visible = true;
                FillDivision1();
                FillddlAreaInchargeDetails();
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
        PanelClientName.Visible = false;
        PanelSoNo.Visible = false;
        PanelMonth.Visible = false;
        PanelYear.Visible = false;
        PanelDates.Visible = false;
        PanelBranch.Visible = false;
        PanelCenterlize.Visible = false;
        PanelDivision1.Visible = false;
        PanelBranch1.Visible = false;
        PanelAreaIncharge.Visible = false;
        PanelAreaID1.Visible = false;
        PanelClientCode1.Visible = false;
        PanelAsmtID1.Visible = false;
        PanelPost1.Visible = false;
        PnlIsMandatory.Visible = false;
        pnlTraining.Visible = false;
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

        string strReportPagePath;
        strReportPagePath = strRptName == @"CustomerConstraint" ? "../Reports/Rostering/" : "../Reports/Sales/";


        Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value.ToString());


        //***** For Excel Reports added by Manish 13-mar-2010 **********************************************************


        if (ddlReportName.SelectedItem.Value.ToString() == "rptSale_MsxmlClientSectorBreakDown.aspx")
        {
            return;
        }

        //***************************************************************************************************************

        if (strRptName == @"CustomerConstraint")
        {
            if (!ValidateControles(strRptName)) return;
        }

        Hashtable hshRptParameters = new Hashtable();
        hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());

        if (strRptName == @"CustomerConstraint")
        {

                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                Context.Items.Add("cxtReportID", "ReportID");
                Context.Items.Add("cxtReportPagePath", strReportPagePath);
                Context.Items["cxtReturnPage"] = "../Sales/RptGroup_Client.aspx?ReportName=" +
                                             ddlReportName.SelectedItem.Value.ToString();
                Server.Transfer("../Transactions/ConstraintGridReport.aspx");
        }
        else
        {
            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Sales/RptGroup_Client.aspx?ReportName=" +
                                             ddlReportName.SelectedItem.Value.ToString();
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
        Hashtable hshRptParameters = new Hashtable();
        switch (strReportName)
        {
            case "ClientList.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientName.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.Option, ddlCenterlize.SelectedItem.Value.ToString());
                return hshRptParameters;
            case "ClientAssignmentList.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.AssignmentAddress, Resources.Resource.AsmtAddress);
                hshRptParameters.Add(DL.Properties.Resources.BillingAddress, Resources.Resource.BillingAddress);
                //hshRptParameters.Add(DL.Properties.Resources.Pending, Resources.Resource.Pending);
                return hshRptParameters;
            case "Client Profile.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientName.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.StatusAuthorized, strStatusAuthorized);
                return hshRptParameters;
            case "Client Profitablility Report.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Locn, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromCustNo, ddlClientName.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.ToCustNo, ddlClientName.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;

            case "CustomerConstraint":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, ddlAsmtCode1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.PostCode, ddlPostCode1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ConstraintCode, DdlIsMandatory.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.TrainingCode, ddlTraining.SelectedValue);
                return hshRptParameters;


            case "SalesOrderHistory.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.FrOrder, txtSoNo.Text.ToString());
                hshRptParameters.Add(DL.Properties.Resources.ToOrder, txtSoNo.Text.ToString());
                return hshRptParameters;
            case "SectorWiseInvoiceAmtSummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Month, int.Parse(ddlMonth.SelectedItem.Value.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.Year, int.Parse(txtYear.Text));
                return hshRptParameters;
            case "ClientListNoContractSign.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                return hshRptParameters;


            default: return hshRptParameters;
        }
    }
    #endregion





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

        if (ddlReportName.SelectedValue == @"CustomerConstraint")
        {
            FillddlClient1();
        }

    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient1()
    {
        ddlClientCode1.Items.Clear();
        ddlClientName1.Items.Clear();
        var objSales = new BL.Sales();
        var ds = String.Equals(BaseIsAdmin.Trim(), "C".Trim(), StringComparison.CurrentCultureIgnoreCase) ? objSales.ClientGet(BaseLocationAutoID, BaseUserID) : objSales.ClientAreaWiseGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaID1.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode1.DataSource = ds.Tables[0];
            ddlClientCode1.DataTextField = "ClientCode";
            ddlClientCode1.DataValueField = "ClientCode";
            ddlClientCode1.DataBind();

            ddlClientName1.DataSource = ds.Tables[0];
            ddlClientName1.DataTextField = "ClientName";
            ddlClientName1.DataValueField = "ClientCode";
            ddlClientName1.DataBind();

            var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlClientCode1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlClientName1.Items.Insert(0, li1);

            FillddlAsmt1();
        }
        else
        {
            ddlAsmtCode1.Items.Clear();
            ddlAsmtName.Items.Clear();
            var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlClientCode1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlClientName1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAsmtName.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAsmtCode1.Items.Insert(0, li1);
        }

    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    private void FillddlAsmt1()
    {
        ddlAsmtCode1.Items.Clear();
        ddlAsmtName.Items.Clear();
        var objOperationManagement = new OperationManagement();

        if (ddlClientCode1.SelectedItem.Value == @"ALL")
        {
            var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlAsmtCode1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlAsmtName.Items.Insert(0, li1);

        }
        else
        {
            string strClientCode = ddlClientCode1.SelectedValue;

            var dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaID1.SelectedItem.Value);

            if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
            {
                ddlAsmtCode1.DataSource = dsAsmt.Tables[0];
                ddlAsmtCode1.DataTextField = "AsmtCode";
                ddlAsmtCode1.DataValueField = "AsmtCode";
                ddlAsmtCode1.DataBind();

                ddlAsmtName.DataSource = dsAsmt.Tables[0];
                ddlAsmtName.DataTextField = "AsmtAddress";
                ddlAsmtName.DataValueField = "AsmtCode";
                ddlAsmtName.DataBind();

                var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                ddlAsmtCode1.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                ddlAsmtName.Items.Insert(0, li1);
            }
            else
            {
                var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlAsmtCode1.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlAsmtName.Items.Insert(0, li1);
            }
        }

        if (ddlReportName.SelectedValue == @"CustomerConstraint")
        {
            FillDdlPost1();
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientName1.SelectedValue = ddlClientCode1.SelectedValue;
        FillddlAsmt1();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientName1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientCode1.SelectedValue = ddlClientName1.SelectedValue;
        FillddlAsmt1();
    }


    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode1_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtName.SelectedValue = ddlAsmtCode1.SelectedValue;
        if (ddlReportName.SelectedValue == @"CustomerConstraint")
        {
            FillDdlPost1();
        }
    }
    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtName_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtCode1.SelectedValue = ddlAsmtName.SelectedValue;
        if (ddlReportName.SelectedValue == @"CustomerConstraint")
        {
            FillDdlPost1();
        }

    }
    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the DdlPostCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlPostCode1_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlPost1.SelectedValue = ddlPostCode1.SelectedValue;
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the DDlPost control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlPost1_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlPostCode1.SelectedValue = ddlPost1.SelectedValue;
    }


    /// <summary>
    /// Fills the DDL post.
    /// </summary>
    private void FillDdlPost1()
    {
        ddlPostCode1.Items.Clear();
        ddlPost1.Items.Clear();
        var objMasterManagement = new MastersManagement();
        switch (ddlAsmtCode1.SelectedItem.Value)
        {
            case @"ALL":
                {
                    var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                    ddlPostCode1.Items.Insert(0, li1);

                    li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                    ddlPost1.Items.Insert(0, li1);

                }
                break;
            case @"-1":
                {
                    var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                    ddlPostCode1.Items.Insert(0, li1);

                    li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                    ddlPost1.Items.Insert(0, li1);
                }
                break;
            default:
                using (var ds = objMasterManagement.AsmtPostGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaID1.SelectedItem.Value, ddlClientCode1.SelectedItem.Value, ddlAsmtCode1.SelectedItem.Value))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ddlPostCode1.DataSource = ds.Tables[0];
                        ddlPostCode1.DataTextField = "Site";
                        ddlPostCode1.DataValueField = "Site";
                        ddlPostCode1.DataBind();
                        ddlPost1.DataSource = ds.Tables[0];
                        ddlPost1.DataTextField = "SiteDesc";
                        ddlPost1.DataValueField = "Site";
                        ddlPost1.DataBind();
                        var li2 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                        ddlPostCode1.Items.Insert(0, li2);
                        li2 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                        ddlPost1.Items.Insert(0, li2);
                    }
                    else
                    {
                        var li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                        ddlPostCode1.Items.Insert(0, li2);
                        li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                        ddlPost1.Items.Insert(0, li2);
                    }
                }
                break;
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
            case "CustomerConstraint":
                return true;
            default:
                return false;
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

}
