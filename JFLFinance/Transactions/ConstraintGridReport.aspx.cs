// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 03-21-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ConstraintGridReport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

//=====================================================================================

// Modified By      : Manish 
// Modifeid Date    : 17-Mar-2014
// Purpose          : Used to show the type of Constraint Details
// =====================================================================================================

using System;
using System.Collections;
using System.Web;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_ConstraintGridReport.
/// </summary>
public partial class Transactions_ConstraintGridReport : BasePage
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString());
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
            if (Context.Items["cxtReturnPage"] != null)
            {
                HfBack.Value = Context.Items["cxtReturnPage"].ToString();
            }

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
            var ObjR = new DL.Report();

            if (ReportParameters != null)
            {
                PnlReport.GroupingText = Resources.Resource.EmployeeConstraint + @" " + Resources.Resource.Report;

                if (ReportParameters[DL.Properties.Resources.EmployeeNumber] != null)
                {

                    var Ds =
                        ObjR.EmployeeConstraintIsrGet(ReportParameters[DL.Properties.Resources.CompanyCode].ToString(),
                            ReportParameters[DL.Properties.Resources.LocationAutoId].ToString(),
                            ReportParameters[DL.Properties.Resources.EmployeeNumber].ToString(),
                            ReportParameters[DL.Properties.Resources.AreaId].ToString(),
                            ReportParameters[DL.Properties.Resources.AreaIncharge].ToString(),
                            ReportParameters[DL.Properties.Resources.TrainingCode].ToString(),
                            ReportParameters[DL.Properties.Resources.QualificationCode].ToString(),
                            ReportParameters[DL.Properties.Resources.SkillCode].ToString(),
                            ReportParameters[DL.Properties.Resources.ConstraintCode].ToString(),
                            ReportParameters[DL.Properties.Resources.IDType].ToString(),
                            ReportParameters[DL.Properties.Resources.LanguageCode].ToString());
                    if (Ds.Tables.Count == 0)
                    {
                        RadGrid1.DataSource = null;
                        lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                    }
                    else
                    {
                        RadGrid1.DataSource = Ds.Tables[0];
                        RadGrid1.Columns.Clear();

                        var DivisionCode = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["HrLocationCode"].ToString(),
                            HeaderText = Resources.Resource.Division,
                            UniqueName = "DivisionId"
                        };

                        RadGrid1.MasterTableView.Columns.Add(DivisionCode);

                        var DivisionDesc = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["HrLocationdesc"].ToString(),
                            HeaderText = Resources.Resource.DivisionName,
                            UniqueName = "DivisionDesc"
                        };

                        RadGrid1.MasterTableView.Columns.Add(DivisionDesc);

                        var LocationCode = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["LocationCode"].ToString(),
                            HeaderText = Resources.Resource.BranchID,
                            UniqueName = "LocationCode"
                        };

                        RadGrid1.MasterTableView.Columns.Add(LocationCode);

                        var LocationDesc = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["LocationDesc"].ToString(),
                            HeaderText = Resources.Resource.Branch,
                            UniqueName = "LocationDesc"
                        };

                        RadGrid1.MasterTableView.Columns.Add(LocationDesc);
                        var AreaIncharge = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AreaIncharge"].ToString(),
                            HeaderText = Resources.Resource.AreaIncharge,
                            UniqueName = "AreaIncharge"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AreaIncharge);
                        var AreaInchargeName = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AreaInchargeName"].ToString(),
                            HeaderText = Resources.Resource.AreaInchargeName,
                            UniqueName = "AreaInchargeName"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AreaInchargeName);
                        var AreaID = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AreaID"].ToString(),
                            HeaderText = Resources.Resource.AreaID,
                            UniqueName = "AreaID"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AreaID);

                        var AreaDescription = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AreaDescription"].ToString(),
                            HeaderText = Resources.Resource.AreaDesc,
                            UniqueName = "AreaDescription"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AreaDescription);

                        var EmployeeNumber = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["EmployeeNumber"].ToString(),
                            HeaderText = Resources.Resource.EmployeeNumber,
                            UniqueName = "EmployeeNumber"
                        };
                        RadGrid1.MasterTableView.Columns.Add(EmployeeNumber);

                        var EmployeeName = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["EmployeeName"].ToString(),
                            HeaderText = Resources.Resource.EmployeeName,
                            UniqueName = "EmployeeName"
                        };

                        RadGrid1.MasterTableView.Columns.Add(EmployeeName);

                        var WageRate = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["WageRate"].ToString(),
                            HeaderText = Resources.Resource.PayRate,
                            UniqueName = "WageRate"
                        };
                        RadGrid1.MasterTableView.Columns.Add(WageRate);

                        var PreferedDays = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["PreferedDays"].ToString(),
                            HeaderText = Resources.Resource.PreferredDayOff,
                            UniqueName = "PrefferedDays"
                        };

                        RadGrid1.MasterTableView.Columns.Add(PreferedDays);
                        var ConstraintCode = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["TypeDesc"].ToString(),
                            HeaderText = Resources.Resource.ConstraintType,
                            UniqueName = "ConstraintCode"
                        };

                        RadGrid1.MasterTableView.Columns.Add(ConstraintCode);

                        var Detail = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["Detail"].ToString(),
                            HeaderText = Resources.Resource.ConstraintTypeDesc,
                            UniqueName = "Detail"
                        };

                        RadGrid1.MasterTableView.Columns.Add(Detail);

                        var Value = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["Value"].ToString(),
                            HeaderText = Resources.Resource.Details,
                            UniqueName = "Value"
                        };

                        RadGrid1.MasterTableView.Columns.Add(Value);
                        //   RadGrid1.CurrentPageIndex = RadGrid1.MasterTableView.CurrentPageIndex;
                    }

                }
                else
                {
                    PnlReport.GroupingText = Resources.Resource.Customer + @" " + Resources.Resource.Constraint + @" " + Resources.Resource.Report;
                    var Ds = ObjR.CustomerConstraintIsrGet(ReportParameters[DL.Properties.Resources.CompanyCode].ToString(),
                           ReportParameters[DL.Properties.Resources.LocationAutoId].ToString(),
                           ReportParameters[DL.Properties.Resources.ClientCode].ToString(),
                           ReportParameters[DL.Properties.Resources.AsmtId].ToString(),
                           ReportParameters[DL.Properties.Resources.PostCode].ToString(),
                           ReportParameters[DL.Properties.Resources.AreaId].ToString(),
                           ReportParameters[DL.Properties.Resources.AreaIncharge].ToString(),
                           ReportParameters[DL.Properties.Resources.ConstraintCode].ToString(),
                           ReportParameters[DL.Properties.Resources.TrainingCode].ToString());
                    if (Ds.Tables.Count == 0)
                    {
                        RadGrid1.DataSource = null;
                        lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                    }
                    else
                    {

                        RadGrid1.DataSource = Ds.Tables[0];
                        RadGrid1.Columns.Clear();
                        var DivisionCode = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["HrLocationCode"].ToString(),
                            HeaderText = Resources.Resource.Division,
                            UniqueName = "DivisionId"
                        };

                        RadGrid1.MasterTableView.Columns.Add(DivisionCode);

                        var DivisionDesc = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["HrLocationdesc"].ToString(),
                            HeaderText = Resources.Resource.DivisionName,
                            UniqueName = "DivisionDesc"
                        };

                        RadGrid1.MasterTableView.Columns.Add(DivisionDesc);

                        var LocationCode = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["LocationCode"].ToString(),
                            HeaderText = Resources.Resource.BranchID,
                            UniqueName = "LocationCode"
                        };

                        RadGrid1.MasterTableView.Columns.Add(LocationCode);

                        var LocationDesc = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["LocationDesc"].ToString(),
                            HeaderText = Resources.Resource.Branch,
                            UniqueName = "LocationDesc"
                        };

                        RadGrid1.MasterTableView.Columns.Add(LocationDesc);
                        var AreaIncharge = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AreaIncharge"].ToString(),
                            HeaderText = Resources.Resource.AreaIncharge,
                            UniqueName = "AreaIncharge"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AreaIncharge);
                        var AreaInchargeName = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AreaInchargeName"].ToString(),
                            HeaderText = Resources.Resource.AreaInchargeName,
                            UniqueName = "AreaInchargeName"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AreaInchargeName);
                        var AreaID = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AreaID"].ToString(),
                            HeaderText = Resources.Resource.AreaID,
                            UniqueName = "AreaID"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AreaID);

                        var AreaDescription = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AreaDescription"].ToString(),
                            HeaderText = Resources.Resource.AreaDesc,
                            UniqueName = "AreaDescription"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AreaDescription);

                        var CustomerCode = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["CustomerCode"].ToString(),
                            HeaderText = Resources.Resource.CustomerID,
                            UniqueName = "CustomerCode"
                        };
                        RadGrid1.MasterTableView.Columns.Add(CustomerCode);

                        var CustomerName = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["CustomerName"].ToString(),
                            HeaderText = Resources.Resource.CustomerName,
                            UniqueName = "CustomerName"
                        };

                        RadGrid1.MasterTableView.Columns.Add(CustomerName);

                        var ContractNumber = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["ContractNumber"].ToString(),
                            HeaderText = Resources.Resource.ContractNumber,
                            UniqueName = "ContractNumber"
                        };
                        RadGrid1.MasterTableView.Columns.Add(ContractNumber);

                        var AssignmentId = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["AsmtId"].ToString(),
                            HeaderText = Resources.Resource.AssignmentID,
                            UniqueName = "AssignmentId"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AssignmentId);

                        var AsmtName = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["Assignment"].ToString(),
                            HeaderText = Resources.Resource.AsmtName,
                            UniqueName = "AsmtName"
                        };

                        RadGrid1.MasterTableView.Columns.Add(AsmtName);

                        var ServiceCategory = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["ServiceCategory"].ToString(),
                            HeaderText = Resources.Resource.ServiceCategoryCode,
                            UniqueName = "ServiceCategory"
                        };

                        RadGrid1.MasterTableView.Columns.Add(ServiceCategory);


                        var PostCode = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["PostCode"].ToString(),
                            HeaderText = Resources.Resource.PostCode,
                            UniqueName = "PostCode"
                        };

                        RadGrid1.MasterTableView.Columns.Add(PostCode);


                        var PostDesc = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["PostDesc"].ToString(),
                            HeaderText = Resources.Resource.PostDesc,
                            UniqueName = "PostDesc"
                        };

                        RadGrid1.MasterTableView.Columns.Add(PostDesc);

                        var SoRank = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["SoRank"].ToString(),
                            HeaderText = Resources.Resource.SORank,
                            UniqueName = "SoRank"
                        };

                        RadGrid1.MasterTableView.Columns.Add(SoRank);

                        var ConstraintDesc = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["ContraintDesc"].ToString(),
                            HeaderText = Resources.Resource.ConstraintTypeDesc,
                            UniqueName = "ConstraintDesc"
                        };

                        RadGrid1.MasterTableView.Columns.Add(ConstraintDesc);

                        var Detail = new GridBoundColumn
                        {
                            DataField = Ds.Tables[0].Columns["IsMandatory"].ToString(),
                            HeaderText = Resources.Resource.ConstraintDetail,
                            UniqueName = "IsMandatory"
                        };

                        RadGrid1.MasterTableView.Columns.Add(Detail);

                        //RadGrid1.CurrentPageIndex = RadGrid1.MasterTableView.CurrentPageIndex;

                    }


                }
            }

        }

        catch (Exception Exception)
        { throw new Exception(Resources.Resource.ErrorMessage, Exception); }


    }

    /// <summary>
    /// Handles the NeedDataSource event of the RadGrid1 control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>

    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        FillRadGrid1();
        //RadGrid1.PagerStyle.AlwaysVisible = true;
        //RadGrid1.MasterTableView.PagerStyle.AlwaysVisible = true;
    }

    /// <summary>
    /// For export Functionality of Radgrid
    /// </summary>
    /// <param name="sender">Radgrid OBJECT</param>
    /// <param name="e">ItemCommand Event Args</param>

    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
        {
            ConfigureExport();
            RadGrid1.MasterTableView.ExportToExcel();
        }


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

    /// <summary>
    /// For Functionality of Radgrid
    /// </summary>
    /// <param name="sender">Radgrid OBJECT</param>
    /// <param name="e">GridPageChangedEventArgs Event Args</param>

    protected void RadGrid1_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        RadGrid1.AllowPaging = true;
        RadGrid1.CurrentPageIndex = e.NewPageIndex;
        //FillRadGrid1();
        RadGrid1.Rebind();
    }


    /// <summary>
    /// For Functionality of Radgrid
    /// </summary>
    /// <param name="sender">Radgrid OBJECT</param>
    /// <param name="e">GridPageSizeChangedEventArgs Event Args</param>

    protected void RadGrid1_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
    {
        RadGrid1.PageSize = e.NewPageSize;
        FillRadGrid1();
    }
    /// <summary>
    /// Go back to main page
    /// </summary>
    /// <param name="sender">Back button</param>
    /// <param name="e">On Click Event</param>
    protected void BtnBack_OnClick(object sender, EventArgs e)
    {
        Response.Redirect(HfBack.Value);
    }
}