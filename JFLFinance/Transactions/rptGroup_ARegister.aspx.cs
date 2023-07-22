// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 01-03-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="rptGroup_ARegister.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Telerik.Web.UI;
using System.Data;

/// <summary>
/// Class Transactions_rptGroup_ARegister.
/// </summary>
public partial class Transactions_rptGroup_ARegister : BasePage
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
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack && !IsCallback)
        {

            if (IsReadAccess == true)
            {

                System.Globalization.DateTimeFormatInfo d = new System.Globalization.DateTimeFormatInfo();
                string monthval = d.MonthNames[DateTime.Now.Month - 1].Substring(0, 3);

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

            FillddlDivision();
            FillddlYear();
        }
    }

    /// <summary>
    /// Fillddls the year.
    /// </summary>
    protected void FillddlYear()
    {
        int year = System.DateTime.Today.Date.Year;
        ddlYear.Items.Clear();
        RadComboBoxItem l1 = new RadComboBoxItem();
        RadComboBoxItem l2 = new RadComboBoxItem();
        RadComboBoxItem l3 = new RadComboBoxItem();
        l1.Text = (year - 1).ToString();
        l1.Value = (year - 1).ToString();
        ddlYear.Items.Add(l1);
        l2.Text = (year).ToString();
        l2.Value = (year).ToString();
        ddlYear.Items.Add(l2);
        l3.Text = (year + 1).ToString();
        l3.Value = (year + 1).ToString();
        ddlYear.Items.Add(l3);
        ddlYear.SelectedIndex = 1;

    }
    /// <summary>
    /// Handles the Click event of the btnGenerateData control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGenerateData_Click(object sender, EventArgs e)
    {
        RadGrid1.DataSource = null;
        RadGrid1.DataBind();
        FillRadGrid1("");

    }

    /// <summary>
    /// Fills the RAD grid1.
    /// </summary>
    /// <param name="bindStatus">The bind status.</param>
    protected void FillRadGrid1(string bindStatus)
    {
        DL.Report objRpt = new DL.Report();
        var division = ddlDivision.CheckedItems;
        var location = ddlBranch.CheckedItems;
        var customer = ddlCustomer.CheckedItems;

        string divisionCode = string.Empty;
        string locationCode = string.Empty;
        string customerCode = string.Empty;
        // For Division
        if (division.Count > 0)
        {
            foreach (var item in division)
            {
                divisionCode = divisionCode + item.Value.ToString() + ",";
            }
        }

        //For Branchif (location.Count > 0)
        {
            foreach (var itemloc in location)
            {
                locationCode = locationCode + itemloc.Value.ToString() + ",";
            }
        }

        //For Customer
        if (customer.Count > 0)
        {
            foreach (var itemCust in customer)
            {
                customerCode = customerCode + itemCust.Value.ToString() + ",";
            }
        }
        if (ddlYear.SelectedIndex >= 0 && ddlMonth.SelectedIndex >= 0)
        {
            DataSet ds = objRpt.ARegister(divisionCode, locationCode, customerCode, ddlYear.SelectedValue, ddlMonth.SelectedValue, cbIncludeCentralizedBilling.Checked);
            ds.Tables[0].TableName = "Copy";
            for (var i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                var columnName = ds.Tables[0].Columns[i].ColumnName.Replace(" ", "");
                ds.Tables[0].Columns[i].ColumnName = ResourceValueOfKey_Get(columnName.ToString());
                try
                {
                    if (columnName.Contains("Date"))
                    {
                        for (var j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            var z = ds.Tables[0].Rows[j][i];
                            if (ds.Tables[0].Rows[j][i] != null)
                            {
                                ds.Tables[0].Rows[j][i] = Convert.ToDateTime(ds.Tables[0].Rows[j][i]).ToString(Resources.Resource.ScheduleDefaultDateFormat);
                            }

                        }
                    }
                }
                catch (Exception ex) { }

            }

            //ds1.Load(ds.CreateDataReader(), LoadOption.PreserveChanges, "Copy");

            RadGrid1.DataSource = ds.Tables[0];

            if (bindStatus == "")
            {
                RadGrid1.DataBind();
            }
        }
    }


    /// <summary>
    /// DDLs the division selected index changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlDivisionSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        var Hrloc = ddlDivision.CheckedItems;
        //For Branch
        string ddlHrLoc = string.Empty;
        //string locationCode = string.Empty;
        if (Hrloc.Count > 0)
        {
            foreach (var item in Hrloc)
            {
                ddlHrLoc = ddlHrLoc + item.Value.ToString() + ",";
            }
        }

        // lblErrorMsg.Text = ddlHrLoc;
        FillddlBranch(ddlHrLoc);

        //FillddlBranch();
    }


    /// <summary>
    /// DDLs the branch selected index changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlBranchSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlCustomer();
    }

    //////////protected void btnProcess_Click(object sender, EventArgs e)
    //////////{
    //////////    var location = ddlBranch.CheckedItems;
    //////////    var customer = ddlCustomer.CheckedItems;

    //////////    string locationid = string.Empty;
    //////////    //For Branchif (location.Count > 0)
    //////////    {
    //////////        foreach (var itemloc in location)
    //////////        {
    //////////            locationid = locationid + itemloc.Value.ToString() + ",";
    //////////        }
    //////////    }


    //////////    DL.Report objRpt = new DL.Report();
    //////////    DataSet ds = new DataSet();
    //////////    ds = objRpt.ARegisterProcess(locationid, ddlMonth.SelectedValue, ddlYear.SelectedValue);
    //////////    lblErrorMsg.Text = MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
    //////////}

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
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataBind();

            ddlDivision.AutoPostBack = true;
            if (!IsPostBack)
            {
                foreach (RadComboBoxItem item in ddlDivision.Items)
                {
                    if (item.Value == BaseHrLocationCode)
                    {
                        item.Checked = true;
                    }
                }

                var Hrloc = ddlDivision.CheckedItems;
                //For Branch
                string ddlHrLoc = string.Empty;
                if (Hrloc.Count > 0)
                {
                    foreach (var item in Hrloc)
                    {
                        ddlHrLoc = ddlHrLoc + item.Value.ToString() + ",";
                    }
                }
                FillddlBranch(ddlHrLoc);
            }
        }
    }

    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    /// <param name="ddlHrLoc">The DDL hr loc.</param>
    private void FillddlBranch(string ddlHrLoc)
    {

        DataSet dsBranch = new DataSet();
        BL.KPI objblUserManagement = new BL.KPI();
        //dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue.ToString());
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlHrLoc);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationAutoID";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
        }
        foreach (RadComboBoxItem item in ddlBranch.Items)
        {
            if (item.Value == BaseLocationAutoID)
            {
                item.Checked = true;
            }
        }
        FillddlCustomer();

    }

    /// <summary>
    /// Fillddls the customer.
    /// </summary>
    private void FillddlCustomer()
    {
        DataSet dsCustomer = new DataSet();
        BL.Sales objblSales = new BL.Sales();
        var location = ddlBranch.CheckedItems;

        string locationCode = string.Empty;
        //For Branchif (location.Count > 0)
        {
            foreach (var itemloc in location)
            {
                locationCode = locationCode + itemloc.Value.ToString() + ",";
            }
        }
        dsCustomer = objblSales.ClientListARegisterGet(locationCode, cbIncludeCentralizedBilling.Checked);
        if (dsCustomer.Tables[0].Rows.Count > 0)
        {
            ddlCustomer.DataSource = dsCustomer.Tables[0];
            ddlCustomer.DataValueField = "ClientCode";
            ddlCustomer.DataTextField = "ClientName";
            ddlCustomer.DataBind();

            RadComboBoxItem li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlCustomer.Items.Insert(0, li);
        }
    }

    protected void cbIncludeCentralizedBilling_CheckedChanged(object sender, EventArgs e)
    {
        FillddlCustomer();
    }
    /// <summary>
    /// Handles the NeedDataSource event of the RadGrid1 control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        if (ddlYear.SelectedIndex >= 0 && ddlMonth.SelectedIndex >= 0)
        {
            FillRadGrid1("DataSource");
        }
    }

    /// <summary>
    /// Handles the ItemDataBound event of the RadGrid1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridItemEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {

        }
    }


    /// <summary>
    /// Handles the ItemCommand event of the RadGrid1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
        {
            ConfigureExport();
            RadGrid1.MasterTableView.ExportToExcel();
        }
        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName)
        {
            ConfigureExport();
            RadGrid1.MasterTableView.ExportToPdf();
        }
        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
        {
            ConfigureExport();
            RadGrid1.MasterTableView.ExportToCSV();
        }
    }
    /// <summary>
    /// Configures the export.
    /// </summary>
    public void ConfigureExport()
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;

        RadGrid1.ExportSettings.OpenInNewWindow = true;
    }
}