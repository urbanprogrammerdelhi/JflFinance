// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 03-13-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="BarredEmployees.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Collections;

/// <summary>
/// Class Transactions_BarredEmployees.
/// </summary>
public partial class Transactions_BarredEmployees : BasePage
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

    /// <summary>
    /// Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                BasePage bp = new BasePage();
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Gets the report parameters.
    /// </summary>
    /// <value>The report parameters.</value>
    public Hashtable ReportParameters
    {
        get
        {
            if (Session["cxtHashParameters"] != null)
            {
                return (Hashtable)Session["cxtHashParameters"];
            }
            else
            {
                return null;
            }
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
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {

                FillRadGridBarredEmployees();
            }
        }
    }



    /// <summary>
    /// Fills the RAD grid barred employees.
    /// </summary>
    protected void FillRadGridBarredEmployees()
    {
        var objR = new BL.Roster();

        if (ReportParameters != null)
        {
            DataSet ds = objR.BarredEmployees(Convert.ToDateTime(this.ReportParameters[DL.Properties.Resources.FromDate].ToString()),
               Convert.ToDateTime(this.ReportParameters[DL.Properties.Resources.ToDate].ToString()),
                this.ReportParameters[DL.Properties.Resources.DivisionCode].ToString(),
                this.ReportParameters[DL.Properties.Resources.Division].ToString(),
                this.ReportParameters[DL.Properties.Resources.BranchCode].ToString(),
                this.ReportParameters[DL.Properties.Resources.Branch].ToString(),
                this.ReportParameters[DL.Properties.Resources.EmployeeNumber].ToString(),
                this.ReportParameters[DL.Properties.Resources.EmployeeNameCondition].ToString(),
                this.ReportParameters[DL.Properties.Resources.AreaId].ToString(),
                this.ReportParameters[DL.Properties.Resources.AreaDesc].ToString(),
                this.ReportParameters[DL.Properties.Resources.AreaIncharge].ToString()
               );
            if (ds != null && ds.Tables.Count > 0)
            {

                ds.Tables[0].Columns[0].ColumnName = Resources.Resource.Division;
                ds.Tables[0].Columns[1].ColumnName = Resources.Resource.DivisionName;
                ds.Tables[0].Columns[2].ColumnName = Resources.Resource.BranchID;
                ds.Tables[0].Columns[3].ColumnName = Resources.Resource.Branch;
                ds.Tables[0].Columns[4].ColumnName = Resources.Resource.AreaIncharge;
                ds.Tables[0].Columns[5].ColumnName = Resources.Resource.AreaInchargeName;
                ds.Tables[0].Columns[6].ColumnName = Resources.Resource.AreaID;
                ds.Tables[0].Columns[7].ColumnName = Resources.Resource.AreaDesc;
                ds.Tables[0].Columns[8].ColumnName = Resources.Resource.EmployeeNumber;
                ds.Tables[0].Columns[9].ColumnName = Resources.Resource.EmployeeName;
                ds.Tables[0].Columns[10].ColumnName = Resources.Resource.CustomerID;
                ds.Tables[0].Columns[11].ColumnName = Resources.Resource.CustomerName;
                ds.Tables[0].Columns[12].ColumnName = Resources.Resource.AssignmentID;
                ds.Tables[0].Columns[13].ColumnName = Resources.Resource.AsmtName;
               

                RadGridBarredEmployees.DataSource = ds.Tables[0];
                
                
                //RadGridBarredEmployees.DataBind();
            }
        }





    }

    /// <summary>
    /// Handles the NeedDataSource event of the RadGridBarredEmployees control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void RadGridBarredEmployees_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        FillRadGridBarredEmployees();
    }

    /// <summary>
    /// Handles the ItemDataBound event of the RadGridBarredEmployees control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridItemEventArgs"/> instance containing the event data.</param>
    protected void RadGridBarredEmployees_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            e.Item.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Item.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = RadGridBarredEmployees.CurrentPageIndex * RadGridBarredEmployees.PageSize + int.Parse(e.Item.ItemIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
        }
    }

    /// <summary>
    /// Handles the ItemCommand event of the RadGridBarredEmployees control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs"/> instance containing the event data.</param>
    protected void RadGridBarredEmployees_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
        {
            ConfigureExport();
            RadGridBarredEmployees.MasterTableView.ExportToExcel();
        }
        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName)
        {
            ConfigureExport();
            RadGridBarredEmployees.MasterTableView.ExportToPdf();
        }
        else if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
        {
            ConfigureExport();
            RadGridBarredEmployees.MasterTableView.ExportToCSV();
        }
    }
    /// <summary>
    /// Configures the export.
    /// </summary>
    public void ConfigureExport()
    {
        RadGridBarredEmployees.ExportSettings.ExportOnlyData = true;
        RadGridBarredEmployees.ExportSettings.IgnorePaging = true;
        RadGridBarredEmployees.ExportSettings.OpenInNewWindow = true;
    }

    /// <summary>
    /// Handles the Click event of the btnBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/RptGroup_Israel.aspx?ReportName=" + "BarredEmployees");

    }
}