// ***********************************************************************
// Assembly         : 
// Author           : 
// Created On         : 04-29-2014
//

// ***********************************************************************
// <copyright file="ScheduleControlReport.aspx.cs" company="Magnon">
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
/// Class Transactions_ScheduleControlReport.
/// </summary>
public partial class Transactions_ScheduleControlReport : BasePage
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
                //if (Request.QueryString["ReportName"] != null)
                //{
                //    //lblReportHeader.Text = Request.QueryString["ReportName"].ToString();
                //}
                //PnlReport.GroupingText = Resources.Resource.Detailed;
                RadGrid1.DataSource = null;
                RadGrid1.DataBind();
                FillRadGrid1("BIND", 0);
            }
        }
    }


    /// <summary>
    /// Back button implemented
    /// </summary>
    protected void btnBack_Click(object sender, EventArgs eventArgs)
    {
        Response.Redirect("../Transactions/RptGroup_Hours.aspx?ReportName=" + "ScheduleControl.rpt");
    }

    /// <summary>
    /// Fills the RAD grid1.
    /// </summary>
    protected void FillRadGrid1(string bindStatus, int pageIndex)
    {
        var objR = new BL.Roster();
        if (ReportParameters != null)
        {

            DataSet ds = objR.ScheduleControl(

              this.ReportParameters[DL.Properties.Resources.LocationAutoId].ToString(),
              this.ReportParameters[DL.Properties.Resources.AreaIncharge].ToString(),
              this.ReportParameters[DL.Properties.Resources.AreaId].ToString(),
              this.ReportParameters[DL.Properties.Resources.ClientCode].ToString(),
              this.ReportParameters[DL.Properties.Resources.AsmtCode].ToString(),
              this.ReportParameters[DL.Properties.Resources.SaleOrderTypeCode].ToString(),
              this.ReportParameters[DL.Properties.Resources.FromDate].ToString(),
              this.ReportParameters[DL.Properties.Resources.ToDate].ToString(),
              this.ReportParameters[DL.Properties.Resources.OutputFld].ToString());


            if (ds != null && ds.Tables.Count > 0)

                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    ds.Tables[0].Columns[i].ColumnName = ResourceValueOfKey_Get(ds.Tables[0].Columns[i].ColumnName.ToString());
                }

            RadGrid1.DataSource = ds.Tables[0];

            if (bindStatus == "BIND")
            {
                RadGrid1.DataBind();
                // MergeRows(pageIndex);
            }
        }
    }

    private void MergeRows(int pageIndex)
    {
        for (int rowIndex = (RadGrid1.Items.Count - 2); rowIndex >= 0; rowIndex--)
        {
            GridDataItem row = RadGrid1.Items[rowIndex];
            GridDataItem previousRow = RadGrid1.Items[rowIndex + 1];

            //if (row["Customer ID"].Text == previousRow["Customer ID"].Text && row["Assignment ID"].Text == previousRow["Assignment ID"].Text
            //    && row["Post Code"].Text == previousRow["Post Code"].Text && row["Date"].Text == previousRow["Date"].Text
            //    && row["SO Rank"].Text == previousRow["SO Rank"].Text
            //    )
            //{
            if (row[Resources.Resource.CustomerID].Text == previousRow[Resources.Resource.CustomerID].Text && row[Resources.Resource.AssignmentID].Text == previousRow[Resources.Resource.AssignmentID].Text
              && row[Resources.Resource.PostCode].Text == previousRow[Resources.Resource.PostCode].Text && row[Resources.Resource.Date].Text == previousRow[Resources.Resource.Date].Text
              && row[Resources.Resource.SORank].Text == previousRow[Resources.Resource.SORank].Text
              )
            {
                if (previousRow[Resources.Resource.ContractedHours].RowSpan < 2)
                {
                    row[Resources.Resource.ContractedHours].RowSpan = 2;
                }
                else
                {
                    row[Resources.Resource.ContractedHours].RowSpan = previousRow[Resources.Resource.ContractedHours].RowSpan + 1;
                }
                previousRow[Resources.Resource.ContractedHours].Visible = false;

                if (previousRow[Resources.Resource.Variance].RowSpan < 2)
                {
                    row[Resources.Resource.Variance].RowSpan = 2;
                }
                else
                {
                    row[Resources.Resource.Variance].RowSpan = previousRow[Resources.Resource.Variance].RowSpan + 1;
                }
                previousRow[Resources.Resource.Variance].Visible = false;
            }
        }
    }

    protected void RadGrid1_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        RadGrid1.CurrentPageIndex = e.NewPageIndex;
        FillRadGrid1("BIND", e.NewPageIndex);
    }


    /// <summary>
    /// Handles the NeedDataSource event of the RadGrid1 control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        FillRadGrid1("", 1);
        //MergeRows();
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


    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        //RadGrid1.DataBind();
        //if (this.ReportParameters[DL.Properties.Resources.OutputFld].ToString() == "Detailed")
        //{
        //    MergeRows(1);
        //}
        //for (int i = RadGrid1.Items.Count - 2; i > 0; i--)
        //{
        //    if (RadGrid1.Items[i][RadGrid1.Columns[0]].Text == RadGrid1.Items[i - 1][RadGrid1.Columns[0]].Text)
        //    {
        //        RadGrid1.Items[i - 1][RadGrid1.Columns[0]].RowSpan = RadGrid1.Items[i][RadGrid1.Columns[0]].RowSpan < 2 ? 2 : RadGrid1.Items[i][RadGrid1.Columns[0]].RowSpan + 1;
        //        RadGrid1.Items[i][RadGrid1.Columns[0]].Visible = false;
        //        RadGrid1.Items[i][RadGrid1.Columns[0]].Text = "&nbsp";
        //    }
        //}

        //foreach (GridDataItem dataItem in RadGrid1.Items)
        //{
        //    if ((dataItem.OwnerTableView.Name == "DomainLabel"))
        //    {
        //        //Merge rows 
        //        GridTableView tv = (GridTableView)dataItem.OwnerTableView;
        //        for (int rowIndex = tv.Items.Count - 2; rowIndex >= 0; rowIndex--)
        //        {
        //            GridDataItem row = tv.Items[rowIndex];
        //            GridDataItem previousRow = tv.Items[rowIndex + 1];
        //            if (row["CustomerID"].Text == previousRow["CustomerID"].Text)
        //            {
        //                row["CustomerID"].RowSpan = previousRow["CustomerID"].RowSpan < 2 ? 2 : previousRow["CustomerID"].RowSpan + 1;
        //                previousRow["CustomerID"].Visible = false;
        //                previousRow["CustomerID"].Text = "&nbsp;";
        //            }
        //        }
        //    }
        //} 

        //if (RadGrid1.Items.Count >= 0)
        //{
        //    GridTableView tv1 = RadGrid1.MasterTableView;

        //    for (int rowIndex = tv1.Items.Count - 2; rowIndex >= 0; rowIndex--)
        //        // foreach (GridColumn col in RadGrid1.MasterTableView.AutoGeneratedColumns)
        //        //{

        //    //Above Line - Getting Row Count of the Grid
        //    {
        //        var clientcode = RadGrid1.MasterTableView.GetColumn("Division");
        //        GridDataItem row = tv1.Items[rowIndex];
        //        //Above Line - Getting Current Row Value

        //        GridDataItem previousRow = tv1.Items[rowIndex + 1];
        //        //Above Line - Getting Previous Row Value

        //        Label ParentNametxtLbl = (Label)row.FindControl("Division");
        //        //Above Line - Label Which is in ItemTemplete

        //        Label ParentPreviousRow = (Label)previousRow.FindControl("Division");
        //        //Above Line - Label Which is in ItemTemplete
        //        if (ParentNametxtLbl != null)
        //        {
        //            if (ParentNametxtLbl.Text == ParentPreviousRow.Text)
        //            //Above Line - Comparing Current &amp; Previous Row Values
        //            {
        //                row["CustomerID"].RowSpan = previousRow["CustomerID"].RowSpan > 2 ? 2 : previousRow["CustomerID"].RowSpan + 1; //Above Line - Checking Each and Every Row

        //                previousRow["CustomerID"].Visible = false;
        //                //Above Line - Making Visible False if the Value is same as Current Row

        //                previousRow["CustomerID"].Text = " ";
        //                //Above Line - Assigning 'Space' for Same Value
        //            }
        //        }
        //    }


        //The Merged Cell Border will lose right border line so this foreach is used to draw that line.
        //foreach (GridDataItem dataItem in tv1.Items)
        //{
        //    foreach (GridColumn col in RadGrid1.MasterTableView.RenderColumns)
        //    {
        //        dataItem["ParentName"].Style.Add("border-left", "solid 1px #ededed");
        //        //Above Line - dataItem["ParentName"] - The "ParentName" is the UniqueName of Column
        //    }
        //}
        //}

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