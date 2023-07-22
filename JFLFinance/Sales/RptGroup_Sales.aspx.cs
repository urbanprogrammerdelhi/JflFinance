// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_Sales.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Class Sales_RptGroup_Sales.
/// </summary>
public partial class Sales_RptGroup_Sales : BasePage
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
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.Sales; }

            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Sales + "');");
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

                ImgBtnSearchFromClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlFromClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
                ImgBtnSearchToClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlToClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
                ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientName.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");

                //Modify For Defect #1732
                FillddlReportName();
                FillddlBillNonBill();
                FillInvoiceType();
                FillddlSoType();
                FillddlDivision();
                FillStatus();
                //FillddlSoNo();
                //FillddlFromToClient();
                //End
                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }

                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();
                txtAsOnDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

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
        ddlReportName.Items.Clear();
        ListItem li = new ListItem();
        li.Text = Resources.Resource.SaleOrderDetailReport.ToString();
        if (ddlDetSumm.SelectedValue.ToString().Equals("S"))
        {
            li.Value = "SaleOrderSummary.rpt";
        }
        else
        {
            li.Value = "SaleOrderDetailNew.rpt";
        }
        ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.ServiceIncreaseDecrease.ToString();
        //li.Value = "ServiceIncDecReport.rpt";
        //ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.NewSaleTerminationReport.ToString();
        li.Value = "NewSale_Termination.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resources.Resource.SaleOrder, Value = @"SaleOrderDetail_Isreal.rpt" };
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resources.Resource.SalesOrderValue, Value = @"SaleOrderDetailNew" };
        ddlReportName.Items.Add(li);

        ////As per UAT feed back it should be hide  
        //li = new ListItem();
        //li.Text = Resources.Resource.rptContractExpiry.ToString();
        //li.Value = "salesContractExpiryReportSummary.rpt";
        //ddlReportName.Items.Add(li);
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
            ddlDivision.DataTextField = "HrLocationDescCode";
            ddlDivision.DataBind();
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
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDescCode";
            ddlBranch.DataBind();
            ddlBranch.SelectedValue = BaseLocationCode;
        }
        else
        {
            ddlBranch.Items.Clear();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlBranch.Items.Insert(0, li);
        }
        FillddlFromToClient();
    }
    /// <summary>
    /// Fillddls the bill non bill.
    /// </summary>
    private void FillddlBillNonBill()
    {
        ListItem Li = new ListItem();

        Li.Text = Resources.Resource.All;
        Li.Value = "ALL";
        ddlBillNonBill.Items.Insert(0, Li);
        ddlBillNonBill.SelectedIndex = 0;

        ListItem L1 = new ListItem();

        L1.Text = Resources.Resource.Billable;
        L1.Value = "1";
        ddlBillNonBill.Items.Insert(1, L1);


        ListItem L2 = new ListItem();
        L2.Text = Resources.Resource.NonBillable;
        L2.Value = "0";
        ddlBillNonBill.Items.Insert(2, L2);


    }
    /// <summary>
    /// Fills the type of the invoice.
    /// </summary>
    private void FillInvoiceType()
    {
        ListItem Li = new ListItem();

        Li.Text = Resources.Resource.All;
        Li.Value = "ALL";
        ddlInvoiceType.Items.Insert(0, Li);
        ddlInvoiceType.SelectedIndex = 0;

        ListItem L1 = new ListItem();

        L1.Text = Resources.Resource.InvTypFixed;
        L1.Value = "FIXED";
        ddlInvoiceType.Items.Insert(1, L1);


        ListItem L2 = new ListItem();
        L2.Text = Resources.Resource.InvTypActual;
        L2.Value = "ACTUAL";
        ddlInvoiceType.Items.Insert(2, L2);

        ListItem L3 = new ListItem();
        L3.Text = Resources.Resource.InvTypActualDaysInMonth;
        L3.Value = "ACTUAL DAYS IN MONTH";
        ddlInvoiceType.Items.Insert(3, L3);

        ListItem L4 = new ListItem();
        L4.Text = Resources.Resource.InvTypAsPerSchedule;
        L4.Value = "AS PER SCHEDULE";
        ddlInvoiceType.Items.Insert(4, L4);

    }
    /// <summary>
    /// Fillddls from to client.    //Modify for Bug #1732
    /// </summary>
    protected void FillddlFromToClient()
    {
        var objSales = new BL.Sales();
        var ds = new DataSet();

        ddlToClientCode.Items.Clear();
        ddlFromClientCode.Items.Clear();
        ddlClientName.Items.Clear();

        ds = objSales.ClientHRLocationWiseGet(BaseCompanyCode, ddlDivision.SelectedItem.Value, ddlBranch.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlToClientCode.DataSource = ds.Tables[0];
            ddlToClientCode.DataTextField = "ClientNameCode";
            ddlToClientCode.DataValueField = "ClientCode";
            ddlToClientCode.DataBind();

            ddlFromClientCode.DataSource = ds.Tables[0];
            ddlFromClientCode.DataTextField = "ClientNameCode";
            ddlFromClientCode.DataValueField = "ClientCode";
            ddlFromClientCode.DataBind();

            ddlClientName.DataSource = ds.Tables[0];
            ddlClientName.DataTextField = "ClientNameCode";
            ddlClientName.DataValueField = "ClientCode";
            ddlClientName.DataBind();

                //Modify for Bug #1732
            if (ddlReportName.SelectedValue != "SaleOrderDetailNew.rpt")
            {
                var li2 = new ListItem();
                li2.Text = Resources.Resource.SelectAll;
                li2.Value = @"ALL";
                ddlToClientCode.Items.Insert(0, li2);
                ddlFromClientCode.Items.Insert(0, li2);
                ddlClientName.Items.Insert(0, li2);
            }
        }
        else
        {
            var li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = @"-1";
            ddlToClientCode.Items.Insert(0, li);
            ddlFromClientCode.Items.Insert(0, li);
            ddlClientName.Items.Insert(0, li);
        }
        FillddlSoNo();
    }
    /// <summary>
    /// Handles the IndexChange event of the ddlInvoiceType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlInvoiceType_IndexChange(object sender, EventArgs e)
    {
        FillddlSoNo();
    }
    /// <summary>
    /// Handles the IndexChange event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_IndexChange(object sender, EventArgs e)
    {
        FillddlSoNo();
    }

    /// <summary>
    /// Fillddls the so no.     //Modify for Defect #1732
    /// </summary>
    protected void FillddlSoNo()
    {
        ddlSoNo.Items.Clear();
        var objLocationAutoId = new BL.MastersManagement();
        var dsLoc = objLocationAutoId.LocationAutoIdGet(BaseCompanyCode, ddlDivision.SelectedValue,
                                                        ddlBranch.SelectedValue);
        if (dsLoc != null && dsLoc.Tables[0].Rows.Count > 0)
        {
            var objSales = new BL.Sales();
            var ds = new DataSet();
            ds = objSales.ClientSaleOrderGet(dsLoc.Tables[0].Rows[0]["LocationAutoID"].ToString(),
                                             ddlClientName.SelectedValue, ddlSoStatus.SelectedValue,
                                             ddlBillNonBill.SelectedValue, ddlInvoiceType.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSoNo.DataSource = ds.Tables[0];
            ddlSoNo.DataTextField = "SoNo";
            ddlSoNo.DataValueField = "SoNo";
            ddlSoNo.DataBind();

            if (ddlDetSumm.SelectedValue.ToString().Equals("S"))
            {
                    var li = new ListItem();
                li.Text = Resources.Resource.All;
                li.Value = "ALL";
                ddlSoNo.Items.Insert(0, li);
            }
            btnViewReport.Enabled = true;
        }
        else
        {
                var li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlSoNo.Items.Insert(0, li);
            // btnViewReport.Enabled = false;
        }
        }
        else
        {
            var li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlSoNo.Items.Insert(0, li);
        }
}

    /// <summary>
    /// Fillddls the type of the so.
    /// </summary>
    protected void FillddlSoType()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.SaleOrderTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSoType.DataSource = ds.Tables[0];
            ddlSoType.DataValueField = "SaleOrderTypeCode";
            ddlSoType.DataTextField = "SaleOrderTypeDesc";
            ddlSoType.DataBind();


            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlSoType.Items.Insert(0, li);
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlSoType.Items.Add(li);
        }
    }
    /// <summary>
    /// Fills the status.
    /// </summary>
    protected void FillStatus()
    {
        ListItem li5 = new ListItem();
        li5.Text = Resources.Resource.NewSale;
        li5.Value = "New Sale";
        DdlStatus.Items.Insert(0, li5);
        ListItem li6 = new ListItem();
        li6.Text = Resources.Resource.Termination;
        li6.Value = "Termination";
        DdlStatus.Items.Insert(0, li6);

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
        FillddlFromToClient();          //Added for Bug 1732
    }
    /// <summary>
    /// Handles the TextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        DateFormat(txtFromDate.Text.ToString());
        txtToDate.Text = txtToDate.Text.ToString();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        DateFormat(txtToDate.Text.ToString());
    }
    /// <summary>
    /// Handles the TextChanged event of the txtAsOnDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAsOnDate_TextChanged(object sender, EventArgs e)
    {
        DateFormat(txtAsOnDate.Text.ToString());
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
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlFromToClient();
    }
    /// <summary>
    /// Handles the IndexChange event of the ddlDetSumm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDetSumm_IndexChange(object sender, EventArgs e)
    {
        FillddlReportName();
        ShowHideReportParameterControles();
        FillddlFromToClient(); //Added for Bug 1732
        //FillddlSoNo();
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
            case "SaleOrderDetailNew.rpt":
                PanelLocation.Visible = true;
                PanelStatus.Visible = true;
                PanelClientName.Visible = true;
                PanelAsOnDate.Visible = false;
                PanelBillNoBill.Visible = true;
                PanelInvoiceType.Visible = true;
                PanelSoNo.Visible = true;
                PanelDetSumm.Visible = true;
                break;
            case "SaleOrderSummary.rpt":
                PanelDetSumm.Visible = true;
                PanelLocation.Visible = true;
                PanelStatus.Visible = true;
                PanelClientName.Visible = true;
                PanelAsOnDate.Visible = false;
                PanelBillNoBill.Visible = true;
                PanelInvoiceType.Visible = true;
                PanelSoNo.Visible = true;
                PanelDetSumm.Visible = true;
                break;
            case "ServiceIncDecReport.rpt":
                PanelDetSumm.Visible = false;
                PanelLocation.Visible = true;
                PanelStatus.Visible = true;
                PanelSoType.Visible = true;
                PanelDates.Visible = true;
                PanelClientName.Visible = true;
                PanelIncreaseDecrease.Visible = true;
                PanelInvoiceType.Visible = false;
                PanelSoNo.Visible = false;
                break;
            case "NewSale_Termination.rpt":
                PanelLocation.Visible = true;
                PanelTermination.Visible = true;
                PanelDates.Visible = true;
                PanelInvoiceType.Visible = false;
                PanelSoNo.Visible = false;
                PanelDetSumm.Visible = false;
                break;
            case "salesContractExpiryReportSummary.rpt":
                PanelLocation.Visible = true;
                PanelDates.Visible = true;
                PanelSoType.Visible = true;
                PanelClientName.Visible = true;
                PanelSummary.Visible = true;
                PanelInvoiceType.Visible = false;
                PanelSoNo.Visible = false;
                PanelDetSumm.Visible = false;
                break;
            case "SaleOrderDetail_Isreal.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PnlCentralized.Visible = true;

                if (BaseUserIsAreaIncharge.ToString() == "1")
                {
                    chkCentralize.Enabled = false;
                    chkCentralize.Checked = false;
                }
                FillDivision();
                //PanelShift.Visible = true;
                //PanelReportGrid.Visible = true;
                break;

            case "SaleOrderDetailNew":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PnlCentralized.Visible = true;

                if (BaseUserIsAreaIncharge.ToString() == "1")
                {
                    chkCentralize.Enabled = false;
                    chkCentralize.Checked = false;
                }
                FillDivision();
                //PanelShift.Visible = true;
                //PanelReportGrid.Visible = true;
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
        PanelLocation.Visible = false;
        PanelStatus.Visible = false;
        PanelSoType.Visible = false;
        PanelDates.Visible = false;
        PanelFromToClient.Visible = false;
        PanelClientName.Visible = false;
        PanelAsOnDate.Visible = false;
        PanelIncreaseDecrease.Visible = false;
        PanelBillNoBill.Visible = false;
        PanelSummary.Visible = false;
        PanelTermination.Visible = false;
        PanelInvoiceType.Visible = false;
        PanelSoNo.Visible = false;
        PanelDetSumm.Visible = false;


        PanelDivision.Visible = false;
        PanelBranch.Visible = false;
        PanelAreaIncharge.Visible = false;
        PanelAreaID.Visible = false;
        PanelClientCode.Visible = false;
        PanelAsmt.Visible = false;
        PnlCentralized.Visible = false;


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
        if (ValidateControles(ddlReportName.SelectedItem.Value))
         {
            string strReportPagePath;
            string strReportName = ddlReportName.SelectedItem.Value;

            if (strReportName == "SaleOrderDetail_Isreal.rpt" || strReportName == "SaleOrderDetailNew")
            {

                strReportPagePath = "../Reports/Rostering/";
            }
            else
            {

                strReportPagePath = "../Reports/Sales/";
            }

            if (strReportName == "SaleOrderDetailNew")
            {
                Context.Items.Add("cxtReportFileName", "SaleOrderDetail_Isreal.rpt");
            }
            else
            {
               Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value.ToString());
            }

            Hashtable hshRptParameters = new Hashtable();
            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());
            Session["cxtHashParameters"] = string.Empty;
            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Sales/RptGroup_Sales.aspx?ReportName=" +
                                             ddlReportName.SelectedItem.Value.ToString();
            if(ddlReportName.SelectedItem.Value == @"SaleOrderDetail_Isreal.rpt")
            {
                 Context.Items.Remove("cxtHashParameters");
                 Session["cxtHashParameters"] = hshRptParameters;

                 Server.Transfer("../Transactions/SaleOrderDetailISR.aspx");
            }
            else if (ddlReportName.SelectedItem.Value == @"SaleOrderDetailNew")
            {
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                Server.Transfer("../Transactions/SaleOrderDetailISR2.aspx");
            }
            else
            {
                Server.Transfer("../Reports/ViewReport1.aspx");
            }
        }
    }
    private bool ValidateFromToDate()
    {
        var objCommon = new BL.Common();
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
    private bool ValidateControles(string strReportName)
    {
        if (ddlBranch.SelectedValue == "")
        {
            lblErrorMsg.Text = Resources.Resource.Location + " " + Resources.Resource.CannotBeLeftBlank;
            return false;
        }


        switch (strReportName)
        {
            case "NewSale_Termination.rpt":
                return ValidateFromToDate();
            case "SaleOrderDetail_Isreal.rpt":
                return true;
                default:
                return true;
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
            case "SaleOrderDetailNew.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                //hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());

                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientName.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.SONO, ddlSoNo.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.SOStatus, ddlSoStatus.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.StatusAuthorized, ddlSoStatus.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.IsBillable, ddlBillNonBill.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.BillingPattern, ddlInvoiceType.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Value.ToString());
                return hshRptParameters;
            case "SaleOrderSummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientName.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.SONO, ddlSoNo.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.SOStatus, ddlSoStatus.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.StatusAuthorized, ddlSoStatus.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.IsBillable, ddlBillNonBill.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.BillingPattern, ddlInvoiceType.SelectedValue.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Value.ToString());
                return hshRptParameters;
            case "ServiceIncDecReport.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.Status, ddlSoStatus.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.TypeOfOrder, ddlSoType.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
                hshRptParameters.Add(DL.Properties.Resources.FromClientCode, ddlClientName.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.ToClientCode, ddlClientName.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.IncDecService, ddlIncDecService.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.NewRow, Resources.Resource.NewRow.ToString());
                return hshRptParameters;

            case "SaleOrderDetail_Isreal.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(ddlBranch1.SelectedItem.Value));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeName.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.CenterlizeBilling, chkCentralize.Checked);
                return hshRptParameters;

            case "SaleOrderDetailNew":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(ddlBranch1.SelectedItem.Value));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeName.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.CenterlizeBilling, chkCentralize.Checked);
                return hshRptParameters;

            case "NewSale_Termination.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.NewSaleTerm, DdlStatus.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.TerminationReason, Resources.Resource.TerminationReason.ToString());
                hshRptParameters.Add(DL.Properties.Resources.TerminatedBy, Resources.Resource.TerminatedBy.ToString());
                return hshRptParameters;
            case "salesContractExpiryReportSummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.SOType, ddlSoType.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientName.SelectedItem.Value);

                if (radDetail.Checked == true)
                {
                    Context.Items.Remove("cxtReportFileName");
                    Context.Items.Add("cxtReportFileName", "salesContractExpiryReportDetail.rpt");
                }

                return hshRptParameters;

            default: return hshRptParameters;
        }
    }
    #endregion


    

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivision1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivisionName.SelectedValue = ddlDivision1.SelectedValue;
        FillBranch();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivisionName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivisionName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivision1.SelectedValue = ddlDivisionName.SelectedValue;
        FillBranch();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranch1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranchName.SelectedValue = ddlBranch1.SelectedValue;

        // Added By Kamal 15-Nov-2012 
        FillddlAreaInchargeDetails();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeName.SelectedValue = ddlAreaInchargeCode.SelectedValue;
        FillDDlAreaID();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeCode.SelectedValue = ddlAreaInchargeName.SelectedValue;
        FillDDlAreaID();
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLAreaID control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DDLAreaID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaName.SelectedValue = DDLAreaID.SelectedValue;
        FillddlClient();

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        DDLAreaID.SelectedValue = ddlAreaName.SelectedValue;
        FillddlClient();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientName1.SelectedValue = ddlClientCode.SelectedValue;
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientName1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientCode.SelectedValue = ddlClientName1.SelectedValue;
        FillddlAsmt();
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtName.SelectedValue = ddlAsmtCode.SelectedValue;

    }
    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtName_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtCode.SelectedValue = ddlAsmtName.SelectedValue;

    }

    /// <summary>
    /// To Disable the AreaIncharge, Area Name, Assignment Dropdown on Centralize Checked
    /// </summary>
    /// <param name="sender">CheckBox IsCentralized</param>
    /// <param name="e">Checked / Unchecked </param>
    protected void chkCentralize_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCentralize.Checked)
        {
            ddlAreaInchargeCode.SelectedValue = "@All";
            ddlAreaInchargeName.SelectedValue = @"All";
            DDLAreaID.SelectedValue = @"All";
            ddlAreaName.SelectedValue = @"All";
            ddlAsmtCode.SelectedValue = @"All";
            ddlAsmtName.SelectedValue = @"All";

            PanelAreaID.Enabled = false;
            PanelAreaIncharge.Enabled = false;
            PanelAsmt.Enabled = false;
            FillddlClient();
        }
        else
        {
            PanelAreaID.Enabled = true;
            PanelAreaIncharge.Enabled = true;
            PanelAsmt.Enabled = true;
        }
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
    /// Fills the division.
    /// </summary>
    private void FillDivision()
    {
        ddlDivision1.Items.Clear();
        ddlBranch1.Items.Clear();
        ddlAreaInchargeCode.Items.Clear();
        DDLAreaID.Items.Clear();
        ddlClientCode.Items.Clear();
        ddlClientName1.Items.Clear();
        var ObjblUserManagement = new BL.UserManagement();
        var DsDivision = ObjblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (DsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision1.DataSource = DsDivision.Tables[0];
            ddlDivision1.DataValueField = "HrLocationCode";
            ddlDivision1.DataTextField = "HrLocationCode";
            ddlDivision1.DataBind();

            ddlDivisionName.DataSource = DsDivision.Tables[0];
            ddlDivisionName.DataValueField = "HrLocationCode";
            ddlDivisionName.DataTextField = "HrLocationDesc";
            ddlDivisionName.DataBind();

            ddlDivision1.SelectedValue = BaseHrLocationCode;
            ddlDivisionName.SelectedValue = ddlDivision1.SelectedValue;
            FillBranch();
        }
    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        var ObjblUserManagement = new BL.UserManagement();
        //Added By  for Weekly Rest Report


        var DsBranch = ObjblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision1.SelectedValue);

        if (DsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch1.DataSource = DsBranch.Tables[0];
            ddlBranch1.DataValueField = "LocationAutoId";
            ddlBranch1.DataTextField = "LocationCode";
            ddlBranch1.DataBind();

            ddlBranchName.DataSource = DsBranch.Tables[0];
            ddlBranchName.DataValueField = "LocationAutoId";
            ddlBranchName.DataTextField = "LocationDesc";
            ddlBranchName.DataBind();

            ddlBranch1.SelectedValue = BaseLocationAutoID;
            ddlBranchName.SelectedValue = BaseLocationAutoID;

            FillddlAreaInchargeDetails();


        }
    }

    /// <summary>
    /// Fill AreaIncharge Dropdown on Location Basis
    /// </summary>
    private void FillddlAreaInchargeDetails()
    {
        var employeeNumber = String.Empty;

        if (BaseUserIsAreaIncharge == "0" && BaseUserID != "system")
        {
            employeeNumber = BaseUserEmployeeNumber;
        }
        var objHRManagement = new BL.HRManagement();


        // ds = objHRManagement.AreaInchargeGet(BaseCompanyCode, EmployeeNumber);
        // Added By Kamal 15-Nov-2012 
        //if (ddlReportTypeMain.SelectedValue == "YLMAttendance")
        //{

        ddlAreaInchargeCode.Items.Clear();
        ddlAreaInchargeName.Items.Clear();

        var Ds = objHRManagement.AreaInchargeGetBasedonUserID(ddlBranch1.SelectedValue != string.Empty ? ddlBranch1.SelectedItem.Value : BaseLocationAutoID, employeeNumber, BaseUserID);


        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaInchargeCode.DataSource = Ds.Tables[0];
            ddlAreaInchargeCode.DataTextField = "EmployeeCode";
            ddlAreaInchargeCode.DataValueField = "EmployeeCode";
            ddlAreaInchargeCode.DataBind();

            ddlAreaInchargeName.DataSource = Ds.Tables[0];
            ddlAreaInchargeName.DataTextField = "Employee";
            ddlAreaInchargeName.DataValueField = "EmployeeCode";
            ddlAreaInchargeName.DataBind();

            var LI2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
            ddlAreaInchargeCode.Items.Insert(0, LI2);

            LI2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
            ddlAreaInchargeName.Items.Insert(0, LI2);

        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAreaInchargeCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAreaInchargeName.Items.Insert(0, li1);
        }

        FillDDlAreaID();
    }




    /// <summary>
    /// Fill AreaId Dropdown on AreaIncharge Basis
    /// </summary>
    private void FillDDlAreaID()
    {
        DDLAreaID.Items.Clear();
        ddlAreaName.Items.Clear();

        var ObjOPS = new BL.OperationManagement();

        var Ds = ObjOPS.AreaIdGet(ddlBranch1.SelectedValue != string.Empty ? ddlBranch1.SelectedItem.Value : BaseLocationAutoID, ddlAreaInchargeCode.SelectedValue);

        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DDLAreaID.DataSource = Ds;
            DDLAreaID.DataTextField = "AreaID";
            DDLAreaID.DataValueField = "AreaID";
            DDLAreaID.DataBind();

            ddlAreaName.DataSource = Ds;
            ddlAreaName.DataTextField = "AreaDesc";
            ddlAreaName.DataValueField = "AreaID";
            ddlAreaName.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            DDLAreaID.Items.Insert(0, li);

            li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            ddlAreaName.Items.Insert(0, li);
        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            DDLAreaID.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAreaName.Items.Insert(0, li1);
        }

        FillddlClient();  // Added For Bug #4380 
    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        ddlClientCode.Items.Clear();
        ddlClientName1.Items.Clear();
        var objSales = new BL.Sales();
        DataSet ds;
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSales.ClientGet(BaseLocationAutoID, BaseUserID);

        }
        else
        {

            ddlClientCode.Items.Clear();
            ddlClientName1.Items.Clear();
            ds = objSales.ClientListARegisterGet(ddlBranch1.SelectedValue, chkCentralize.Checked == true ? false : true);

        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();

            ddlClientName1.DataSource = ds.Tables[0];
            ddlClientName1.DataTextField = "ClientName";
            ddlClientName1.DataValueField = "ClientCode";
            ddlClientName1.DataBind();

            var li1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlClientCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlClientName1.Items.Insert(0, li1);

            FillddlAsmt();
        }
        else
        {
            ddlAsmtCode.Items.Clear();
            ddlAsmtName.Items.Clear();
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlClientCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlClientName1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAsmtName.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAsmtCode.Items.Insert(0, li1);
        }

    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();
        ddlAsmtName.Items.Clear();

        if (chkCentralize.Checked)
        {
            var LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmtCode.Items.Insert(0, LI1);

            LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmtName.Items.Insert(0, LI1);

            return;

        }

        if (ddlClientCode.SelectedItem.Value == @"ALL")
        {
            var LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmtCode.Items.Insert(0, LI1);

            LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmtName.Items.Insert(0, LI1);
        }
        else
        {
            string strClientCode = ddlClientCode.SelectedValue;
            var dsAsmt = new DataSet();
            var objOperationManagement = new BL.OperationManagement();



            dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value, DDLAreaID.SelectedItem.Value);

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
                li1.Value = @"ALL";
                ddlAsmtCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = "ALL" };
                ddlAsmtName.Items.Insert(0, li1);
            }
            else
            {
                var LI1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = "-1" };
                ddlAsmtCode.Items.Insert(0, LI1);

                LI1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = "-1" };
                ddlAsmtName.Items.Insert(0, LI1);
            }
        }
    }
}
