// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By :  Virmani
// Last Modified On : 27-Feb-2014
// Purpose          : Used to show the type of breakddown structure of Leaves taken by Austraila Employees.
// ***********************************************************************
// <copyright file="LeaveBreakDownReport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Class HRManagement_LeaveBreakDownReport
/// </summary>
public partial class HRManagement_LeaveBreakDownReport : BasePage
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
                FillRadGrid1();
            }
        }
    }
    /// <summary>
    /// Filling the Grid and binding to the datasource
    /// </summary>
    /// <exception cref="System.Exception"></exception>
    protected void FillRadGrid1()
    {
        try
        {
            var objR = new BL.HRManagement();

            string company = Request.QueryString["Company"];
            string locationAutoID = Request.QueryString["LocationAutoID"];
            string leaveCode = Request.QueryString["LeaveCode"];
            string fromDate = Request.QueryString["FromDate"];
            string toDate = Request.QueryString["ToDate"];
            string empNo = Request.QueryString["EmpNo"];

            DataSet ds = objR.LeaveBreakDownReportGet(company, locationAutoID, leaveCode, fromDate, toDate, empNo);

            if (ds.Tables.Count == 0)
            {
                RadGrid1.DataSource = null;
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            }
            else
            {

                RadGrid1.DataSource = ds.Tables[0];

            }
        }

        catch (Exception ex)
        { throw new Exception(Resources.Resource.ErrorMessage, ex); }


    }
    /// <summary>
    /// For providing datasource to grid in case of different event changes
    /// </summary>
    /// <param name="source">RadGrid Object</param>
    /// <param name="e">DataSource Event</param>
    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        FillRadGrid1();
    }
    /// <summary>
    /// For Accessing particular Item in the Grid
    /// </summary>
    /// <param name="sender">RadGrid1 Object</param>
    /// <param name="e">ItemDataBound Event</param>
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            e.Item.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Item.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = RadGrid1.CurrentPageIndex * RadGrid1.PageSize + int.Parse(e.Item.ItemIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
        }
    }
    /// <summary>
    /// For export Functionality of Radgrid
    /// </summary>
    /// <param name="sender">Radgrid OBJECT</param>
    /// <param name="e">ItemCommand Event Args</param>
    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        ConfigureExport();
    }
    /// <summary>
    /// For export Functionality of Radgrid
    /// </summary>
    public void ConfigureExport()
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;

    }
}