// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="SOLineDeptShifts.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Sale Order Deployment and Shift Details Screen Code behind
/// </summary>
public partial class Sales_SOLineDeptShifts : BasePage
{
    #region Properties
    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsReadAccess
    {
        get
        {
            try
            {
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsWriteAccess
    {
        get
        {
            try
            {
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsModifyAccess
    {
        get
        {
            try
            {
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsDeleteAccess
    {
        get
        {
            try
            {
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }


    /// <summary>
    /// Gets a value indicating whether the Pay Rate and Charge Rate is Visible or not
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                var bp = new BasePage();
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }
    #endregion

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender">Object of the page</param>
    /// <param name="e">Event Args</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblavgdays.Text = @" ( " + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @" ) ";
        lblmonthbilling.Text = @" ( " + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @" ) ";

        if (!IsPostBack)
        {
            if (IsReadAccess)
            {


                if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"] != null &&
                    Request.QueryString["SOAmendNO"] != null && Request.QueryString["SOLineNo"] != null &&
                    Request.QueryString["Hours"] != null && Request.QueryString["NoOfPost"] != null &&
                    Request.QueryString["IsBillable"] != null)
                {
                    if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"] != string.Empty &&
                        Request.QueryString["SOAmendNO"] != string.Empty &&
                        Request.QueryString["SOLineNo"] != string.Empty && Request.QueryString["Hours"] != string.Empty &&
                        Request.QueryString["NoOfPost"] != string.Empty &&
                        Request.QueryString["IsBillable"] != string.Empty)
                    {
                        var strGlbLocationAutoId = Request.QueryString["LocationAutoID"];
                        string strGlbSoNo = Request.QueryString["SoNo"];
                        string strGlbSoAmendNo = Request.QueryString["SOAmendNO"];
                        string strGlbSoLineNo = Request.QueryString["SOLineNo"];
                        string strGlbSoStatus = Request.QueryString["SOStatus"];
                        string strGlbIsMaxSoAmendNo = Request.QueryString["IsMAXSOAmendNo"];
                        hfHours.Value = Request.QueryString["Hours"];
                        hfNoOfPost.Value = Request.QueryString["NoOfPost"];
                        hfChargeRatePerHrs.Value = Request.QueryString["ChargeRatePerHrs"];
                        if (!string.IsNullOrEmpty(Request.QueryString["PayRatePerHrs"]))
                        {
                            hfPayRatePerHrs.Value = Request.QueryString["PayRatePerHrs"];
                        }
                        hfIsAllowanceBillable.Value = Request.QueryString["IsAllowanceBillable"];
                        hfRemainingDays.Value = Request.QueryString["RemainingDays"];
                        hfOtherAllowance.Value = Request.QueryString["OtherAllowances"];
                        hiddenFieldBillable.Value = Request.QueryString["IsBillable"];
                        var strSoLineActiveStatus = Request.QueryString["Checked"];
                        hfBillingPattern.Value = Request.QueryString["BillingPattern"];
                        txtAverageHoursInMonth.Attributes.Add("readonly", "readonly");
                        txtAverageDaysInMonth.Attributes.Add("readonly", "readonly");
                        txtComputedMonthlyValue.Attributes.Add("readonly", "readonly");
                        txtFixedMonthlyBilling.Attributes.Add("readonly", "readonly");
                        if (hfBillingPattern.Value.Trim().ToLower() != "fixed")
                        {
                            txtFixedMonthlyBilling.Attributes.Add("readonly", "readonly");
                        }
                        hfLocationAutoId.Value = strGlbLocationAutoId;
                        lblSoNo.Text = strGlbSoNo;
                        lblSOAmendNo.Text = strGlbSoAmendNo;
                        lblSOLineNo.Text = strGlbSoLineNo;
                        lblSoStatus.Text = ResourceValueOfKeyOnlyforStatus_Get(strGlbSoStatus);
                        hfIsMAXSOAmendNo.Value = strGlbIsMaxSoAmendNo;
                        var objSales = new BL.Sales();
                        var ds = objSales.SaleOrderRatesSystemParameterGet("OTChargeRateActive", "LocationAutoId",
                                                                               strGlbLocationAutoId);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            hiddenFieldOTChargeRateActive.Value = ds.Tables[0].Rows[0][0].ToString();
                        }
                        ds = objSales.SaleOrderRatesSystemParameterGet("HChargeRateActive", "LocationAutoId",
                                                                       strGlbLocationAutoId);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            hiddenFieldHChargeRateActive.Value = ds.Tables[0].Rows[0][0].ToString();
                        }
                        ds = objSales.SaleOrderRatesSystemParameterGet("OChargeRateActive", "LocationAutoId",
                                                                       strGlbLocationAutoId);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            hiddenFieldOChargeRateActive.Value = ds.Tables[0].Rows[0][0].ToString();
                        }
                        ds = objSales.SaleOrderRatesSystemParameterGet("HolidayDeptShift", "LocationAutoId",
                                                                       strGlbLocationAutoId);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            hiddenFieldHolidayDept.Value = ds.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            hiddenFieldHolidayDept.Value = @"0";
                        }

                        ShowDetails(strGlbLocationAutoId, strGlbSoNo, strGlbSoAmendNo, strGlbSoLineNo);
                        if (!strGlbIsMaxSoAmendNo.Equals("MAX") ||
                            (strGlbIsMaxSoAmendNo.Equals("MAX") &&
                             (lblSoStatus.Text.Equals(Resources.Resource.Authorized) ||
                              lblSoStatus.Text.Equals(Resources.Resource.ShortClosed))))
                        {
                            gvPattren.Columns[0].Visible = false;
                            gvPattren.FooterRow.Visible = false;
                            txtFixedMonthlyBilling.Enabled = false;
                        }
                        if (bool.Parse(strSoLineActiveStatus) == false)
                        {
                            gvPattren.Columns[0].Visible = false;
                            gvPattren.FooterRow.Visible = false;
                            gvPattren.Enabled = false;
                        }
                        HeaderInfo(strGlbLocationAutoId, strGlbSoNo, strGlbSoAmendNo, strGlbSoLineNo);
                    }
                    if (BaseIsAdmin.Trim().ToLower() == "c")
                    {
                        gvPattren.Columns[0].Visible = false;
                        gvPattren.FooterRow.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("../UserManagement/Home.aspx");
                }
            }
        }

        CalculateNoOFDays();
    }

    /// <summary>
    /// Headers the information.
    /// </summary>
    /// <param name="strLocationAutoId">The string location automatic identifier.</param>
    /// <param name="strSoNo">The string so no.</param>
    /// <param name="strSoAmendNo">The string so amend no.</param>
    /// <param name="strSoLineNo">The string so line no.</param>
    void HeaderInfo(string strLocationAutoId, string strSoNo, string strSoAmendNo, string strSoLineNo)
    {
        var objsales = new BL.Sales();
        var ds = objsales.DeploymentHeaderInfoGet(strSoNo, strSoAmendNo, strSoLineNo);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblClientCodeValue.Text = ds.Tables[0].Rows[0][0].ToString();
            lblClientNameValue.Text = ds.Tables[0].Rows[0][1].ToString();
            lblAsmtIDValue.Text = ds.Tables[0].Rows[0][2].ToString();
            lblAsmtNameValue.Text = ds.Tables[0].Rows[0][3].ToString();
            lblSORankValue.Text = ds.Tables[0].Rows[0][4].ToString();
            lblPostIDValue.Text = ds.Tables[0].Rows[0][5].ToString();

        }

    }
    /// <summary>
    /// To Show the Details of Deployment Pattern
    /// </summary>
    /// <param name="strLocationAutoId">Location Auto Id</param>
    /// <param name="strSoNo">So No.</param>
    /// <param name="strSoAmendNo">So Amend No.</param>
    /// <param name="strSoLineNo">So Line No.</param>
    protected void ShowDetails(string strLocationAutoId, string strSoNo, string strSoAmendNo, string strSoLineNo)
    {
        FillgvPattren();
    }

    /// <summary>
    /// to create a temp hours
    /// </summary>
    /// <returns>Data Table</returns>
    private DataTable TempDataTable()
    {
        var dt = new DataTable();
        var dc = new DataColumn {ColumnName = "WeekNo", DataType = Type.GetType("System.Int32")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "MonNop", DataType = Type.GetType("System.Int32")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "TueNop", DataType = Type.GetType("System.Int32")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "WedNop", DataType = Type.GetType("System.Int32")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "ThuNop", DataType = Type.GetType("System.Int32")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "FriNop", DataType = Type.GetType("System.Int32")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "SatNop", DataType = Type.GetType("System.Int32")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "SunNop", DataType = Type.GetType("System.Int32")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "MonHrs", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "TueHrs", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "WedHrs", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "ThuHrs", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "FriHrs", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);
        dc = new DataColumn {ColumnName = "SatHrs", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "SunHrs", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);
        
        dc = new DataColumn {ColumnName = "MonSellingPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "TueSellingPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "WedSellingPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "ThuSellingPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "FriSellingPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "SatSellingPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "SunSellingPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        
        dc = new DataColumn {ColumnName = "MonPayPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "TuePayPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "WedPayPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "ThuPayPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "FriPayPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "SatPayPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        dc = new DataColumn {ColumnName = "SunPayPrice", DataType = Type.GetType("System.Decimal")};
        dt.Columns.Add(dc);

        for (var i = 1; i <= 5; i++)
        {
            var dr = dt.NewRow();
            dr["WeekNo"] = i;

            dr["MonNop"] = 0;
            dr["TueNop"] = 0;
            dr["WedNop"] = 0;
            dr["ThuNop"] = 0;
            dr["FriNop"] = 0;
            dr["SatNop"] = 0;
            dr["SunNop"] = 0;

            dr["MonHrs"] = 0;
            dr["TueHrs"] = 0;
            dr["WedHrs"] = 0;
            dr["ThuHrs"] = 0;
            dr["FriHrs"] = 0;
            dr["SatHrs"] = 0;
            dr["SunHrs"] = 0;

            dr["MonSellingPrice"] = 0;
            dr["TueSellingPrice"] = 0;
            dr["WedSellingPrice"] = 0;
            dr["ThuSellingPrice"] = 0;
            dr["FriSellingPrice"] = 0;
            dr["SatSellingPrice"] = 0;
            dr["SunSellingPrice"] = 0;

            dr["MonPayPrice"] = 0;
            dr["TuePayPrice"] = 0;
            dr["WedPayPrice"] = 0;
            dr["ThuPayPrice"] = 0;
            dr["FriPayPrice"] = 0;
            dr["SatPayPrice"] = 0;
            dr["SunPayPrice"] = 0;

            dt.Rows.Add(dr);
        }
        return dt;
    }

    /// <summary>
    /// calculate the Minutes from the given Hours : Minutes String.
    /// </summary>
    /// <param name="strHrsMin">The string HRS minimum.</param>
    /// <returns>Minutes</returns>
    private decimal CalculateMin(string strHrsMin)
    {
        var decHrs = decimal.Parse(strHrsMin.Substring(0, strHrsMin.IndexOf(":")));
        var decMin = decimal.Parse(strHrsMin.Substring(strHrsMin.IndexOf(":") + 1, strHrsMin.Length - strHrsMin.IndexOf(":") - 1));
        var decTotalMin = (decHrs * 60) + decMin;
        return decTotalMin;
    }

    /// <summary>
    /// Calcuklate Hours from the given Hours : Minutes String.
    /// </summary>
    /// <param name="strHrsMin">The string HRS minimum.</param>
    /// <returns>Hours</returns>
    private decimal CalculateHrs(string strHrsMin)
    {
        var decHrs = decimal.Parse(strHrsMin.Substring(0, strHrsMin.IndexOf(":")));
        var decMin = decimal.Parse(strHrsMin.Substring(strHrsMin.IndexOf(":") + 1, strHrsMin.Length - strHrsMin.IndexOf(":") - 1));
        var decTotalMin = (decHrs * 60) + decMin;
        return (decTotalMin / 60);
    }
    /// <summary>
    /// Calculates the HRS on new.
    /// </summary>
    /// <returns>System.Decimal.</returns>
    private decimal CalculateHrsOnNew()
    {
        var dt = TempDataTable();
        var averageHoursInMonth = decimal.Parse("0");
        for (var i = 0; i < 1; i++)
        {
            var TxtWeekNo = (TextBox)gvPattren.FooterRow.FindControl("TxtWeekNo");

            var TxtMonTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeFrom");
            var TxtMonTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeTo");
            var TxtTueTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeFrom");
            var TxtTueTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeTo");
            var TxtWedTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeFrom");
            var TxtWedTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeTo");
            var TxtThuTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeFrom");
            var TxtThuTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeTo");
            var TxtFriTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeFrom");
            var TxtFriTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeTo");
            var TxtSatTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeFrom");
            var TxtSatTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeTo");
            var TxtSunTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeFrom");
            var TxtSunTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeTo");
            var TxtMonNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtMonNoOfPersons");
            var TxtTueNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtTueNoOfPersons");
            var TxtWedNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtWedNoOfPersons");
            var TxtThuNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtThuNoOfPersons");
            var TxtFriNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtFriNoOfPersons");
            var TxtSatNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtSatNoOfPersons");
            var TxtSunNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtSunNoOfPersons");

            if (TxtWeekNo != null)
            {
                var cWeekNo = TxtWeekNo.Text.ToCharArray();
                for (var j = 0; j < TxtWeekNo.Text.Length; j++)
                {
                    var valWeekNo = int.Parse(cWeekNo[j].ToString()) - 1;
                    
                    string hrs;
                    if (TxtMonNoOfPersons.Text != string.Empty && Int32.Parse(TxtMonNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtMonTimeFrom, TxtMonTimeTo);

                        dt.Rows[valWeekNo]["MonNop"] = Int32.Parse(dt.Rows[valWeekNo]["MonNop"].ToString()) +
                            Int32.Parse(TxtMonNoOfPersons.Text);
                        dt.Rows[valWeekNo]["MonHrs"] = decimal.Parse(dt.Rows[valWeekNo]["MonHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtMonNoOfPersons.Text));
                    }
                    
                    if (TxtTueNoOfPersons.Text != string.Empty && Int32.Parse(TxtTueNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtTueTimeFrom, TxtTueTimeTo);

                        dt.Rows[valWeekNo]["TueNop"] = Int32.Parse(dt.Rows[valWeekNo]["TueNop"].ToString()) +
                            Int32.Parse(TxtTueNoOfPersons.Text);
                        dt.Rows[valWeekNo]["TueHrs"] = decimal.Parse(dt.Rows[valWeekNo]["TueHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtTueNoOfPersons.Text));
                    }
                    
                    if (TxtWedNoOfPersons.Text != string.Empty && Int32.Parse(TxtWedNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtWedTimeFrom, TxtWedTimeTo);

                        dt.Rows[valWeekNo]["WedNop"] = Int32.Parse(dt.Rows[valWeekNo]["WedNop"].ToString()) +
                            Int32.Parse(TxtWedNoOfPersons.Text);
                        dt.Rows[valWeekNo]["WedHrs"] = decimal.Parse(dt.Rows[valWeekNo]["WedHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtWedNoOfPersons.Text));
                    }
                    
                    if (TxtThuNoOfPersons.Text != string.Empty && Int32.Parse(TxtThuNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtThuTimeFrom, TxtThuTimeTo);

                        dt.Rows[valWeekNo]["ThuNop"] = Int32.Parse(dt.Rows[valWeekNo]["ThuNop"].ToString()) +
                            Int32.Parse(TxtThuNoOfPersons.Text);
                        dt.Rows[valWeekNo]["ThuHrs"] = decimal.Parse(dt.Rows[valWeekNo]["ThuHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtThuNoOfPersons.Text));
                    }
                    
                    if (TxtFriNoOfPersons.Text != string.Empty && Int32.Parse(TxtFriNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtFriTimeFrom, TxtFriTimeTo);

                        dt.Rows[valWeekNo]["FriNop"] = Int32.Parse(dt.Rows[valWeekNo]["FriNop"].ToString()) +
                            Int32.Parse(TxtFriNoOfPersons.Text);
                        dt.Rows[valWeekNo]["FriHrs"] = decimal.Parse(dt.Rows[valWeekNo]["FriHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtFriNoOfPersons.Text));
                    }
                    if (TxtSatNoOfPersons.Text != string.Empty && Int32.Parse(TxtSatNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtSatTimeFrom, TxtSatTimeTo);

                        dt.Rows[valWeekNo]["SatNop"] = Int32.Parse(dt.Rows[valWeekNo]["SatNop"].ToString()) +
                            Int32.Parse(TxtSatNoOfPersons.Text);
                        dt.Rows[valWeekNo]["SatHrs"] = decimal.Parse(dt.Rows[valWeekNo]["SatHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtSatNoOfPersons.Text));
                    }
                    
                    if (TxtSunNoOfPersons.Text != string.Empty && Int32.Parse(TxtSunNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtSunTimeFrom, TxtSunTimeTo);

                        dt.Rows[valWeekNo]["SunNop"] = Int32.Parse(dt.Rows[valWeekNo]["SunNop"].ToString()) +
                            Int32.Parse(TxtSunNoOfPersons.Text);
                        dt.Rows[valWeekNo]["SunHrs"] = decimal.Parse(dt.Rows[valWeekNo]["SunHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtSunNoOfPersons.Text));
                    }
                }
            }
        }
        var objsales = new BL.Sales();
        var ds2 = objsales.DaysInMonthSysParamGet(BaseLocationAutoID);
        var DaysInMonthSysParam = decimal.Parse("30.45");
        if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
        {
            DaysInMonthSysParam = decimal.Parse(ds2.Tables[0].Rows[0][0].ToString());
        }


        var FifthWeekOndDay = (DaysInMonthSysParam - 28) / 7;

        for (var i = 0; i < dt.Rows.Count; i++)
        {
            for (var j = 0; j < 7; j++)
            {
                if (i < 4 && decimal.Parse(dt.Rows[i][j + 1].ToString()) > 0)
                {
                    averageHoursInMonth = averageHoursInMonth + decimal.Parse(dt.Rows[i][j + 8].ToString());
                }
                if (i == 4 && decimal.Parse(dt.Rows[i][j + 1].ToString()) > 0)
                {
                    averageHoursInMonth = averageHoursInMonth + (decimal.Parse(dt.Rows[i][j + 8].ToString()) / (decimal.Parse("1") / FifthWeekOndDay));
                }
            }
        }
        averageHoursInMonth = averageHoursInMonth / 60;
        return averageHoursInMonth;
    }
    /// <summary>
    /// Calculates the HRS on edit.
    /// </summary>
    /// <param name="rowIndex">Index of the row.</param>
    /// <returns>System.Decimal.</returns>
    private decimal CalculateHrsOnEdit(int rowIndex)
    {
        var dt = TempDataTable();
        var averageHoursInMonth = decimal.Parse("0");
        for (var i = 0; i < 1; i++)
        {
            var TxtEditWeekNo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditWeekNo");
            var TxtMonNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtMonNoOfPersons");
            var TxtTueNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtTueNoOfPersons");
            var TxtWedNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtWedNoOfPersons");
            var TxtThuNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtThuNoOfPersons");
            var TxtFriNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtFriNoOfPersons");
            var TxtSatNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtSatNoOfPersons");
            var TxtSunNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtSunNoOfPersons");
            var TxtEditMonTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditMonTimeFrom");
            var TxtEditMonTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditMonTimeTo");
            var TxtEditTueTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditTueTimeFrom");
            var TxtEditTueTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditTueTimeTo");
            var TxtEditWedTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditWedTimeFrom");
            var TxtEditWedTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditWedTimeTo");
            var TxtEditThuTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditThuTimeFrom");
            var TxtEditThuTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditThuTimeTo");
            var TxtEditFriTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditFriTimeFrom");
            var TxtEditFriTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditFriTimeTo");
            var TxtEditSatTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditSatTimeFrom");
            var TxtEditSatTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditSatTimeTo");
            var TxtEditSunTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditSunTimeFrom");
            var TxtEditSunTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditSunTimeTo");
            
            if (TxtEditWeekNo != null)
            {
                var cWeekNo = TxtEditWeekNo.Text.ToCharArray();
                for (var j = 0; j < TxtEditWeekNo.Text.Length; j++)
                {
                    var valWeekNo = int.Parse(cWeekNo[j].ToString()) - 1;

                    string hrs;
                    if (TxtMonNoOfPersons.Text != string.Empty && Int32.Parse(TxtMonNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtEditMonTimeFrom, TxtEditMonTimeTo);

                        dt.Rows[valWeekNo]["MonNop"] = Int32.Parse(dt.Rows[valWeekNo]["MonNop"].ToString()) +
                            Int32.Parse(TxtMonNoOfPersons.Text);
                        dt.Rows[valWeekNo]["MonHrs"] = decimal.Parse(dt.Rows[valWeekNo]["MonHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtMonNoOfPersons.Text));
                    }
                    
                    if (TxtTueNoOfPersons.Text != string.Empty && Int32.Parse(TxtTueNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtEditTueTimeFrom, TxtEditTueTimeTo);

                        dt.Rows[valWeekNo]["TueNop"] = Int32.Parse(dt.Rows[valWeekNo]["TueNop"].ToString()) +
                            Int32.Parse(TxtTueNoOfPersons.Text);
                        dt.Rows[valWeekNo]["TueHrs"] = decimal.Parse(dt.Rows[valWeekNo]["TueHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtTueNoOfPersons.Text));
                    }
                    
                    if (TxtWedNoOfPersons.Text != string.Empty && Int32.Parse(TxtWedNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtEditWedTimeFrom, TxtEditWedTimeTo);

                        dt.Rows[valWeekNo]["WedNop"] = Int32.Parse(dt.Rows[valWeekNo]["WedNop"].ToString()) +
                            Int32.Parse(TxtWedNoOfPersons.Text);
                        dt.Rows[valWeekNo]["WedHrs"] = decimal.Parse(dt.Rows[valWeekNo]["WedHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtWedNoOfPersons.Text));
                    }
                    
                    if (TxtThuNoOfPersons.Text != string.Empty && Int32.Parse(TxtThuNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtEditThuTimeFrom, TxtEditThuTimeTo);

                        dt.Rows[valWeekNo]["ThuNop"] = Int32.Parse(dt.Rows[valWeekNo]["ThuNop"].ToString()) +
                            Int32.Parse(TxtThuNoOfPersons.Text);
                        dt.Rows[valWeekNo]["ThuHrs"] = decimal.Parse(dt.Rows[valWeekNo]["ThuHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtThuNoOfPersons.Text));
                    }
                    
                    if (TxtFriNoOfPersons.Text != string.Empty && Int32.Parse(TxtFriNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtEditFriTimeFrom, TxtEditFriTimeTo);

                        dt.Rows[valWeekNo]["FriNop"] = Int32.Parse(dt.Rows[valWeekNo]["FriNop"].ToString()) +
                            Int32.Parse(TxtFriNoOfPersons.Text);
                        dt.Rows[valWeekNo]["FriHrs"] = decimal.Parse(dt.Rows[valWeekNo]["FriHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtFriNoOfPersons.Text));
                    }
                    
                    if (TxtSatNoOfPersons.Text != string.Empty && Int32.Parse(TxtSatNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtEditSatTimeFrom, TxtEditSatTimeTo);

                        dt.Rows[valWeekNo]["SatNop"] = Int32.Parse(dt.Rows[valWeekNo]["SatNop"].ToString()) +
                            Int32.Parse(TxtSatNoOfPersons.Text);
                        dt.Rows[valWeekNo]["SatHrs"] = decimal.Parse(dt.Rows[valWeekNo]["SatHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtSatNoOfPersons.Text));
                    }
                    if (TxtSunNoOfPersons.Text != string.Empty && Int32.Parse(TxtSunNoOfPersons.Text) > 0)
                    {
                        hrs = GetHoursDifferance(TxtEditSunTimeFrom, TxtEditSunTimeTo);

                        dt.Rows[valWeekNo]["SunNop"] = Int32.Parse(dt.Rows[valWeekNo]["SunNop"].ToString()) +
                            Int32.Parse(TxtSunNoOfPersons.Text);
                        dt.Rows[valWeekNo]["SunHrs"] = decimal.Parse(dt.Rows[valWeekNo]["SunHrs"].ToString()) +
                                                       (CalculateMin(hrs) * Int32.Parse(TxtSunNoOfPersons.Text));
                    }
                }
            }
        }
        var objsales = new BL.Sales();
        var ds2 = objsales.DaysInMonthSysParamGet(BaseLocationAutoID);
        var DaysInMonthSysParam = decimal.Parse("30.45");
        if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
        {
            DaysInMonthSysParam = decimal.Parse(ds2.Tables[0].Rows[0][0].ToString());
        }


        var FifthWeekOndDay = (DaysInMonthSysParam - 28) / 7;

        for (var i = 0; i < dt.Rows.Count; i++)
        {
            for (var j = 0; j < 7; j++)
            {
                if (i < 4 && decimal.Parse(dt.Rows[i][j + 1].ToString()) > 0)
                {
                    averageHoursInMonth = averageHoursInMonth + decimal.Parse(dt.Rows[i][j + 8].ToString());
                }
                if (i == 4 && decimal.Parse(dt.Rows[i][j + 1].ToString()) > 0)
                {
                    averageHoursInMonth = averageHoursInMonth + (decimal.Parse(dt.Rows[i][j + 8].ToString()) / (decimal.Parse("1") / FifthWeekOndDay));
                }
            }
        }
        averageHoursInMonth = averageHoursInMonth / 60;
        return averageHoursInMonth;
    }
    /// <summary>
    /// Calculates the HRS labels.
    /// </summary>
    /// <returns>System.Decimal.</returns>
    private decimal CalculateHrsLabels()
    {
        var dt = TempDataTable();
        var averageHoursInMonth = decimal.Parse("0");

        for (var i = 0; i < gvPattren.Rows.Count; i++)
        {
            var lblgvWeekNo = (Label)gvPattren.Rows[i].FindControl("lblgvWeekNo");
            var lblMonNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblMonNoOfPersons");
            var lblTueNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblTueNoOfPersons");
            var lblWedNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblWedNoOfPersons");
            var lblThuNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblThuNoOfPersons");
            var lblFriNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblFriNoOfPersons");
            var lblSatNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblSatNoOfPersons");
            var lblSunNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblSunNoOfPersons");
            var lblMonTimeFrom = (Label)gvPattren.Rows[i].FindControl("lblMonTimeFrom");
            var lblMonTimeTo = (Label)gvPattren.Rows[i].FindControl("lblMonTimeTo");
            var lblTueTimeFrom = (Label)gvPattren.Rows[i].FindControl("lblTueTimeFrom");
            var lblTueTimeTo = (Label)gvPattren.Rows[i].FindControl("lblTueTimeTo");
            var lblWedTimeFrom = (Label)gvPattren.Rows[i].FindControl("lblWedTimeFrom");
            var lblWedTimeTo = (Label)gvPattren.Rows[i].FindControl("lblWedTimeTo");
            var lblThuTimeFrom = (Label)gvPattren.Rows[i].FindControl("lblThuTimeFrom");
            var lblThuTimeTo = (Label)gvPattren.Rows[i].FindControl("lblThuTimeTo");
            var lblFriTimeFrom = (Label)gvPattren.Rows[i].FindControl("lblFriTimeFrom");
            var lblFriTimeTo = (Label)gvPattren.Rows[i].FindControl("lblFriTimeTo");
            var lblSatTimeFrom = (Label)gvPattren.Rows[i].FindControl("lblSatTimeFrom");
            var lblSatTimeTo = (Label)gvPattren.Rows[i].FindControl("lblSatTimeTo");
            var lblSunTimeFrom = (Label)gvPattren.Rows[i].FindControl("lblSunTimeFrom");
            var lblSunTimeTo = (Label)gvPattren.Rows[i].FindControl("lblSunTimeTo");
            if (lblgvWeekNo != null && lblMonNoOfPersons != null)
            {
                var cWeekNo = lblgvWeekNo.Text.ToCharArray();
                for (var j = 0; j < lblgvWeekNo.Text.Length; j++)
                {
                    var valWeekNo = int.Parse(cWeekNo[j].ToString()) - 1;
                    
                    string Hrs;
                    if (lblMonNoOfPersons.Text != string.Empty && Int32.Parse(lblMonNoOfPersons.Text) > 0)
                    {
                        Hrs = GetHoursDifferanceLabels(lblMonTimeFrom, lblMonTimeTo);

                        dt.Rows[valWeekNo]["MonNop"] = Int32.Parse(dt.Rows[valWeekNo]["MonNop"].ToString()) +
                            Int32.Parse(lblMonNoOfPersons.Text);
                        dt.Rows[valWeekNo]["MonHrs"] = decimal.Parse(dt.Rows[valWeekNo]["MonHrs"].ToString()) +
                                                       (CalculateMin(Hrs) * Int32.Parse(lblMonNoOfPersons.Text));
                    }
                    if (lblTueNoOfPersons.Text != string.Empty && Int32.Parse(lblTueNoOfPersons.Text) > 0)
                    {
                        Hrs = GetHoursDifferanceLabels(lblTueTimeFrom, lblTueTimeTo);

                        dt.Rows[valWeekNo]["TueNop"] = Int32.Parse(dt.Rows[valWeekNo]["TueNop"].ToString()) +
                            Int32.Parse(lblTueNoOfPersons.Text);
                        dt.Rows[valWeekNo]["TueHrs"] = decimal.Parse(dt.Rows[valWeekNo]["TueHrs"].ToString()) +
                                                       (CalculateMin(Hrs) * Int32.Parse(lblTueNoOfPersons.Text));
                    }
                    if (lblWedNoOfPersons.Text != string.Empty && Int32.Parse(lblWedNoOfPersons.Text) > 0)
                    {
                        Hrs = GetHoursDifferanceLabels(lblWedTimeFrom, lblWedTimeTo);

                        dt.Rows[valWeekNo]["WedNop"] = Int32.Parse(dt.Rows[valWeekNo]["WedNop"].ToString()) +
                            Int32.Parse(lblWedNoOfPersons.Text);
                        dt.Rows[valWeekNo]["WedHrs"] = decimal.Parse(dt.Rows[valWeekNo]["WedHrs"].ToString()) +
                                                       (CalculateMin(Hrs) * Int32.Parse(lblWedNoOfPersons.Text));
                    }
                    if (lblThuNoOfPersons.Text != string.Empty && Int32.Parse(lblThuNoOfPersons.Text) > 0)
                    {
                        Hrs = GetHoursDifferanceLabels(lblThuTimeFrom, lblThuTimeTo);

                        dt.Rows[valWeekNo]["ThuNop"] = Int32.Parse(dt.Rows[valWeekNo]["ThuNop"].ToString()) +
                            Int32.Parse(lblThuNoOfPersons.Text);
                        dt.Rows[valWeekNo]["ThuHrs"] = decimal.Parse(dt.Rows[valWeekNo]["ThuHrs"].ToString()) +
                                                       (CalculateMin(Hrs) * Int32.Parse(lblThuNoOfPersons.Text));
                    }
                    if (lblFriNoOfPersons.Text != string.Empty && Int32.Parse(lblFriNoOfPersons.Text) > 0)
                    {
                        Hrs = GetHoursDifferanceLabels(lblFriTimeFrom, lblFriTimeTo);

                        dt.Rows[valWeekNo]["FriNop"] = Int32.Parse(dt.Rows[valWeekNo]["FriNop"].ToString()) +
                            Int32.Parse(lblFriNoOfPersons.Text);
                        dt.Rows[valWeekNo]["FriHrs"] = decimal.Parse(dt.Rows[valWeekNo]["FriHrs"].ToString()) +
                                                       (CalculateMin(Hrs) * Int32.Parse(lblFriNoOfPersons.Text));
                    }
                    if (lblSatNoOfPersons.Text != string.Empty && Int32.Parse(lblSatNoOfPersons.Text) > 0)
                    {
                        Hrs = GetHoursDifferanceLabels(lblSatTimeFrom, lblSatTimeTo);

                        dt.Rows[valWeekNo]["SatNop"] = Int32.Parse(dt.Rows[valWeekNo]["SatNop"].ToString()) +
                            Int32.Parse(lblSatNoOfPersons.Text);
                        dt.Rows[valWeekNo]["SatHrs"] = decimal.Parse(dt.Rows[valWeekNo]["SatHrs"].ToString()) +
                                                       (CalculateMin(Hrs) * Int32.Parse(lblSatNoOfPersons.Text));
                    }
                    if (lblSunNoOfPersons.Text != string.Empty && Int32.Parse(lblSunNoOfPersons.Text) > 0)
                    {
                        Hrs = GetHoursDifferanceLabels(lblSunTimeFrom, lblSunTimeTo);

                        dt.Rows[valWeekNo]["SunNop"] = Int32.Parse(dt.Rows[valWeekNo]["SunNop"].ToString()) +
                            Int32.Parse(lblSunNoOfPersons.Text);
                        dt.Rows[valWeekNo]["SunHrs"] = decimal.Parse(dt.Rows[valWeekNo]["SunHrs"].ToString()) +
                                                       (CalculateMin(Hrs) * Int32.Parse(lblSunNoOfPersons.Text));
                    }
                }
            }
        }
        var objsales = new BL.Sales();
        var ds2 = objsales.DaysInMonthSysParamGet(BaseLocationAutoID);
        var DaysInMonthSysParam = decimal.Parse("30.45");
        if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
        {
            DaysInMonthSysParam = decimal.Parse(ds2.Tables[0].Rows[0][0].ToString());
        }
        var FifthWeekOndDay = (DaysInMonthSysParam - 28) / 7;
        for (var i = 0; i < dt.Rows.Count; i++)
        {
            for (var j = 0; j < 7; j++)
            {
                if (i < 4 && decimal.Parse(dt.Rows[i][j + 1].ToString()) > 0)
                {
                    averageHoursInMonth = averageHoursInMonth + decimal.Parse(dt.Rows[i][j + 8].ToString());
                }
                if (i == 4 && decimal.Parse(dt.Rows[i][j + 1].ToString()) > 0)
                {
                    averageHoursInMonth = averageHoursInMonth + (decimal.Parse(dt.Rows[i][j + 8].ToString()) / (decimal.Parse("1") / FifthWeekOndDay));
                }
            }
        }
        averageHoursInMonth = averageHoursInMonth / 60;
        return averageHoursInMonth;
    }
    /// <summary>
    /// Gets the hours differance.
    /// </summary>
    /// <param name="TxtMonTimeFrom">The text mon time from.</param>
    /// <param name="TxtMonTimeTo">The text mon time to.</param>
    /// <returns>System.String.</returns>
    private string GetHoursDifferance(TextBox TxtMonTimeFrom, TextBox TxtMonTimeTo)
    {
        var strDutyFromTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + TxtMonTimeFrom.Text;
        var strDutyToTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + TxtMonTimeTo.Text;

        if (Convert.ToDateTime(DateTime.Parse(strDutyFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")))
        {
            if (Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")) >= Convert.ToDateTime("00:00"))
            {
                strDutyToTime = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + TxtMonTimeTo.Text;
            }
        }
        var ts = DateTime.Parse(strDutyFromTime) > DateTime.Parse(strDutyToTime) ? DateTime.Parse(strDutyFromTime).Subtract(DateTime.Parse(strDutyToTime)) : DateTime.Parse(strDutyToTime).Subtract(DateTime.Parse(strDutyFromTime));
        return ts.ToString().Substring(0, 5);
    }
    /// <summary>
    /// Gets the hours differance labels.
    /// </summary>
    /// <param name="lblMonTimeFrom">The label mon time from.</param>
    /// <param name="lblMonTimeTo">The label mon time to.</param>
    /// <returns>System.String.</returns>
    private string GetHoursDifferanceLabels(Label lblMonTimeFrom, Label lblMonTimeTo)
    {
        var strDutyFromTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + lblMonTimeFrom.Text;
        var strDutyToTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + lblMonTimeTo.Text;
        if (Convert.ToDateTime(DateTime.Parse(strDutyFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")))
        {
            if (Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")) >= Convert.ToDateTime("00:00"))
            {
                strDutyToTime = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + lblMonTimeTo.Text;
            }
        }
        var ts = DateTime.Parse(strDutyFromTime) > DateTime.Parse(strDutyToTime) ? DateTime.Parse(strDutyFromTime).Subtract(DateTime.Parse(strDutyToTime)) : DateTime.Parse(strDutyToTime).Subtract(DateTime.Parse(strDutyFromTime));
        return ts.ToString().Substring(0, 5);
    }
    /// <summary>
    /// Calculate No. Of Days
    /// </summary>
    private void CalculateNoOFDays()
    {
        var dt = TempDataTable();
        var averageDaysInMonth = decimal.Parse("0");
        var averageHoursInMonth = decimal.Parse("0");
        var averagePayPrice = decimal.Parse("0");
        var averageSellingPrice = decimal.Parse("0");
        for (var i = 0; i < gvPattren.Rows.Count; i++)
        {
            var lblgvWeekNo = (Label)gvPattren.Rows[i].FindControl("lblgvWeekNo");
            var lblMonNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblMonNoOfPersons");
            var lblTueNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblTueNoOfPersons");
            var lblWedNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblWedNoOfPersons");
            var lblThuNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblThuNoOfPersons");
            var lblFriNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblFriNoOfPersons");
            var lblSatNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblSatNoOfPersons");
            var lblSunNoOfPersons = (Label)gvPattren.Rows[i].FindControl("lblSunNoOfPersons");
            var lblMonSellingRate = (Label)gvPattren.Rows[i].FindControl("lblMonSellingRate");
            var lblTueSellingRate = (Label)gvPattren.Rows[i].FindControl("lblTueSellingRate");
            var lblWedSellingRate = (Label)gvPattren.Rows[i].FindControl("lblWedSellingRate");
            var lblThuSellingRate = (Label)gvPattren.Rows[i].FindControl("lblThuSellingRate");
            var lblFriSellingRate = (Label)gvPattren.Rows[i].FindControl("lblFriSellingRate");
            var lblSatSellingRate = (Label)gvPattren.Rows[i].FindControl("lblSatSellingRate");
            var lblSunSellingRate = (Label)gvPattren.Rows[i].FindControl("lblSunSellingRate");
            var lblMonPayRate = (Label)gvPattren.Rows[i].FindControl("lblMonPayRate");
            var lblTuePayRate = (Label)gvPattren.Rows[i].FindControl("lblTuePayRate");
            var lblWedPayRate = (Label)gvPattren.Rows[i].FindControl("lblWedPayRate");
            var lblThuPayRate = (Label)gvPattren.Rows[i].FindControl("lblThuPayRate");
            var lblFriPayRate = (Label)gvPattren.Rows[i].FindControl("lblFriPayRate");
            var lblSatPayRate = (Label)gvPattren.Rows[i].FindControl("lblSatPayRate");
            var lblSunPayRate = (Label)gvPattren.Rows[i].FindControl("lblSunPayRate");
            var hfMonHrs = (HiddenField)gvPattren.Rows[i].FindControl("hfMonHrs");
            var hfTueHrs = (HiddenField)gvPattren.Rows[i].FindControl("hfTueHrs");
            var hfWedHrs = (HiddenField)gvPattren.Rows[i].FindControl("hfWedHrs");
            var hfThuHrs = (HiddenField)gvPattren.Rows[i].FindControl("hfThuHrs");
            var hfFriHrs = (HiddenField)gvPattren.Rows[i].FindControl("hfFriHrs");
            var hfSatHrs = (HiddenField)gvPattren.Rows[i].FindControl("hfSatHrs");
            var hfSunHrs = (HiddenField)gvPattren.Rows[i].FindControl("hfSunHrs");
            if (lblgvWeekNo != null)
            {
                char[] cWeekNo = lblgvWeekNo.Text.ToCharArray();
                for (var j = 0; j < lblgvWeekNo.Text.Length; j++)
                {
                    var valWeekNo = int.Parse(cWeekNo[j].ToString()) - 1;
                    
                    if (lblMonNoOfPersons.Text != string.Empty && Int32.Parse(lblMonNoOfPersons.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["MonNop"] = Int32.Parse(dt.Rows[valWeekNo]["MonNop"].ToString()) +
                                                    Int32.Parse(lblMonNoOfPersons.Text);
                        dt.Rows[valWeekNo]["MonHrs"] = decimal.Parse(dt.Rows[valWeekNo]["MonHrs"].ToString()) +
                                                       (CalculateMin(hfMonHrs.Value) * Int32.Parse(lblMonNoOfPersons.Text));
                    }
                    if (lblMonSellingRate != null && lblMonSellingRate.Text != string.Empty && decimal.Parse(lblMonSellingRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["MonSellingPrice"] = decimal.Parse(dt.Rows[valWeekNo]["MonSellingPrice"].ToString()) +
                            (decimal.Parse(lblMonSellingRate.Text) * CalculateHrs(hfMonHrs.Value) * Int32.Parse(lblMonNoOfPersons.Text));
                    }
                    if (lblMonPayRate != null && lblMonPayRate.Text != string.Empty && decimal.Parse(lblMonPayRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["MonPayPrice"] =
                            decimal.Parse(dt.Rows[valWeekNo]["MonPayPrice"].ToString()) +
                            (decimal.Parse(lblMonPayRate.Text) * CalculateHrs(hfMonHrs.Value) * Int32.Parse(lblMonNoOfPersons.Text));
                    }
                    if (lblTueNoOfPersons.Text != string.Empty && Int32.Parse(lblTueNoOfPersons.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["TueNop"] = Int32.Parse(dt.Rows[valWeekNo]["TueNop"].ToString()) +
                                                    Int32.Parse(lblTueNoOfPersons.Text);
                        dt.Rows[valWeekNo]["TueHrs"] = decimal.Parse(dt.Rows[valWeekNo]["TueHrs"].ToString()) +
                                                       (CalculateMin(hfTueHrs.Value) * Int32.Parse(lblTueNoOfPersons.Text));
                    }
                    if (lblTueSellingRate != null && lblTueSellingRate.Text != string.Empty && decimal.Parse(lblTueSellingRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["TueSellingPrice"] = decimal.Parse(dt.Rows[valWeekNo]["TueSellingPrice"].ToString()) +
                            (decimal.Parse(lblTueSellingRate.Text) * CalculateHrs(hfTueHrs.Value) * Int32.Parse(lblTueNoOfPersons.Text));
                    }
                    if (lblTuePayRate != null && lblTuePayRate.Text != string.Empty && decimal.Parse(lblTuePayRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["TuePayPrice"] =
                            decimal.Parse(dt.Rows[valWeekNo]["TuePayPrice"].ToString()) +
                            (decimal.Parse(lblTuePayRate.Text) * CalculateHrs(hfTueHrs.Value) * Int32.Parse(lblTueNoOfPersons.Text));
                    }
                    if (lblWedNoOfPersons.Text != string.Empty && Int32.Parse(lblWedNoOfPersons.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["WedNop"] = Int32.Parse(dt.Rows[valWeekNo]["WedNop"].ToString()) +
                                                    Int32.Parse(lblWedNoOfPersons.Text);
                        dt.Rows[valWeekNo]["WedHrs"] = decimal.Parse(dt.Rows[valWeekNo]["WedHrs"].ToString()) +
                                                       (CalculateMin(hfWedHrs.Value) * Int32.Parse(lblWedNoOfPersons.Text));
                    }
                    if (lblWedSellingRate != null && lblWedSellingRate.Text != string.Empty && decimal.Parse(lblWedSellingRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["WedSellingPrice"] = decimal.Parse(dt.Rows[valWeekNo]["WedSellingPrice"].ToString()) +
                            (decimal.Parse(lblWedSellingRate.Text) * CalculateHrs(hfWedHrs.Value) * Int32.Parse(lblWedNoOfPersons.Text));
                    }
                    if (lblWedPayRate != null && lblWedPayRate.Text != string.Empty && decimal.Parse(lblWedPayRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["WedPayPrice"] =
                            decimal.Parse(dt.Rows[valWeekNo]["WedPayPrice"].ToString()) +
                            (decimal.Parse(lblWedPayRate.Text) * CalculateHrs(hfWedHrs.Value) * Int32.Parse(lblWedNoOfPersons.Text));
                    }
                    if (lblThuNoOfPersons.Text != string.Empty && Int32.Parse(lblThuNoOfPersons.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["ThuNop"] = Int32.Parse(dt.Rows[valWeekNo]["ThuNop"].ToString()) +
                                                    Int32.Parse(lblThuNoOfPersons.Text);
                        dt.Rows[valWeekNo]["ThuHrs"] = decimal.Parse(dt.Rows[valWeekNo]["ThuHrs"].ToString()) +
                                                       (CalculateMin(hfThuHrs.Value) * Int32.Parse(lblThuNoOfPersons.Text));
                    }
                    if (lblThuSellingRate != null && lblThuSellingRate.Text != string.Empty && decimal.Parse(lblThuSellingRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["ThuSellingPrice"] = decimal.Parse(dt.Rows[valWeekNo]["ThuSellingPrice"].ToString()) +
                            (decimal.Parse(lblThuSellingRate.Text) * CalculateHrs(hfThuHrs.Value) * Int32.Parse(lblThuNoOfPersons.Text));
                    }
                    if (lblThuPayRate != null && lblThuPayRate.Text != string.Empty && decimal.Parse(lblThuPayRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["ThuPayPrice"] =
                            decimal.Parse(dt.Rows[valWeekNo]["ThuPayPrice"].ToString()) +
                            (decimal.Parse(lblThuPayRate.Text) * CalculateHrs(hfThuHrs.Value) * Int32.Parse(lblThuNoOfPersons.Text));
                    }
                    if (lblFriNoOfPersons.Text != string.Empty && Int32.Parse(lblFriNoOfPersons.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["FriNop"] = Int32.Parse(dt.Rows[valWeekNo]["FriNop"].ToString()) +
                                                    Int32.Parse(lblFriNoOfPersons.Text);
                        dt.Rows[valWeekNo]["FriHrs"] = decimal.Parse(dt.Rows[valWeekNo]["FriHrs"].ToString()) +
                                                       (CalculateMin(hfFriHrs.Value) * Int32.Parse(lblFriNoOfPersons.Text));
                    }
                    if (lblFriSellingRate != null && lblFriSellingRate.Text != string.Empty && decimal.Parse(lblFriSellingRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["FriSellingPrice"] = decimal.Parse(dt.Rows[valWeekNo]["FriSellingPrice"].ToString()) +
                            (decimal.Parse(lblFriSellingRate.Text) * CalculateHrs(hfFriHrs.Value) * Int32.Parse(lblFriNoOfPersons.Text));
                    }
                    if (lblFriPayRate != null && lblFriPayRate.Text != string.Empty && decimal.Parse(lblFriPayRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["FriPayPrice"] =
                            decimal.Parse(dt.Rows[valWeekNo]["FriPayPrice"].ToString()) +
                            (decimal.Parse(lblFriPayRate.Text) * CalculateHrs(hfFriHrs.Value) * Int32.Parse(lblFriNoOfPersons.Text));
                    }
                    if (lblSatNoOfPersons.Text != string.Empty && Int32.Parse(lblSatNoOfPersons.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["SatNop"] = Int32.Parse(dt.Rows[valWeekNo]["SatNop"].ToString()) +
                                                    Int32.Parse(lblSatNoOfPersons.Text);
                        dt.Rows[valWeekNo]["SatHrs"] = decimal.Parse(dt.Rows[valWeekNo]["SatHrs"].ToString()) +
                                                       (CalculateMin(hfSatHrs.Value) * Int32.Parse(lblSatNoOfPersons.Text));
                    }
                    if (lblSatSellingRate != null && lblSatSellingRate.Text != string.Empty && decimal.Parse(lblSatSellingRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["SatSellingPrice"] = decimal.Parse(dt.Rows[valWeekNo]["SatSellingPrice"].ToString()) +
                            (decimal.Parse(lblSatSellingRate.Text) * CalculateHrs(hfSatHrs.Value) * Int32.Parse(lblSatNoOfPersons.Text));
                    }
                    if (lblSatPayRate != null && lblSatPayRate.Text != string.Empty && decimal.Parse(lblSatPayRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["SatPayPrice"] =
                            decimal.Parse(dt.Rows[valWeekNo]["SatPayPrice"].ToString()) +
                            (decimal.Parse(lblSatPayRate.Text) * CalculateHrs(hfSatHrs.Value) * Int32.Parse(lblSatNoOfPersons.Text));
                    }
                    if (lblSunNoOfPersons.Text != string.Empty && Int32.Parse(lblSunNoOfPersons.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["SunNop"] = Int32.Parse(dt.Rows[valWeekNo]["SunNop"].ToString()) +
                                                    Int32.Parse(lblSunNoOfPersons.Text);
                        dt.Rows[valWeekNo]["SunHrs"] = decimal.Parse(dt.Rows[valWeekNo]["SunHrs"].ToString()) +
                                                       (CalculateMin(hfSunHrs.Value) * Int32.Parse(lblSunNoOfPersons.Text));
                    }
                    if (lblSunSellingRate != null && lblSunSellingRate.Text != string.Empty && decimal.Parse(lblSunSellingRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["SunSellingPrice"] = decimal.Parse(dt.Rows[valWeekNo]["SunSellingPrice"].ToString()) +
                            (decimal.Parse(lblSunSellingRate.Text) * CalculateHrs(hfSunHrs.Value) * Int32.Parse(lblSunNoOfPersons.Text));
                    }
                    if (lblSunPayRate != null && lblSunPayRate.Text != string.Empty && decimal.Parse(lblSunPayRate.Text) > 0)
                    {
                        dt.Rows[valWeekNo]["SunPayPrice"] =
                            decimal.Parse(dt.Rows[valWeekNo]["SunPayPrice"].ToString()) +
                            (decimal.Parse(lblSunPayRate.Text) * CalculateHrs(hfSunHrs.Value) * Int32.Parse(lblSunNoOfPersons.Text));
                    }
                }
            }
        }

        var objsales = new BL.Sales();
        var ds2 = objsales.DaysInMonthSysParamGet(BaseLocationAutoID);
        var DaysInMonthSysParam = decimal.Parse("30.45");
        if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
        {
            DaysInMonthSysParam = decimal.Parse(ds2.Tables[0].Rows[0][0].ToString());
        }


        var FifthWeekOndDay = (DaysInMonthSysParam - 28) / 7;

        for (var i = 0; i < dt.Rows.Count; i++)
        {
            for (var j = 0; j < 7; j++)
            {
                if (i < 4 && decimal.Parse(dt.Rows[i][j + 1].ToString()) > 0)
                {
                    averageDaysInMonth = averageDaysInMonth + decimal.Parse("1");
                    averageHoursInMonth = averageHoursInMonth + decimal.Parse(dt.Rows[i][j + 8].ToString());
                    averagePayPrice = averagePayPrice + decimal.Parse(dt.Rows[i][j + 22].ToString());
                    averageSellingPrice = averageSellingPrice + decimal.Parse(dt.Rows[i][j + 15].ToString());
                }
                if (i == 4 && decimal.Parse(dt.Rows[i][j + 1].ToString()) > 0)
                {
                    averageDaysInMonth = averageDaysInMonth + FifthWeekOndDay;
                    averageHoursInMonth = averageHoursInMonth + (decimal.Parse(dt.Rows[i][j + 8].ToString()) / (decimal.Parse("1") / FifthWeekOndDay));
                    averagePayPrice = averagePayPrice + (decimal.Parse(dt.Rows[i][j + 22].ToString()) / (decimal.Parse("1") / FifthWeekOndDay));
                    averageSellingPrice = averageSellingPrice + (decimal.Parse(dt.Rows[i][j + 15].ToString()) / (decimal.Parse("1") / FifthWeekOndDay));
                }
            }
        }
        averageDaysInMonth = Math.Round(averageDaysInMonth, 4, MidpointRounding.ToEven);
        txtAverageDaysInMonth.Text = averageDaysInMonth.ToString();
        if (Math.Round(averageHoursInMonth % 60) == 60)
        {
            txtAverageHoursInMonth.Text = (((averageHoursInMonth - (averageHoursInMonth % 60)) / 60) + 1).ToString("00") + @":" + @"00";
        }
        else
        {
            txtAverageHoursInMonth.Text = (((averageHoursInMonth - (averageHoursInMonth % 60)) / 60)).ToString("00") + @":" + (averageHoursInMonth % 60).ToString("00");
        }
        averageHoursInMonth = averageHoursInMonth / 60;
        HfAverageHoursInMonth.Value = averageHoursInMonth.ToString();
        txtComputedMonthlyValue.Text = GetValueAsPerSystemParameters(averageSellingPrice.ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
        var objSales = new BL.Sales();
        var ds = objSales.SellingDaysInMonthGet(lblSOLineNo.Text, BaseLocationAutoID, lblSoNo.Text, lblSOAmendNo.Text);
        if (ds.Tables[0].Rows[0]["SellingPrice"].ToString() != string.Empty && hfBillingPattern.Value.Trim().ToLower() == "Fixed".ToLower())
        {
            txtFixedMonthlyBilling.Text = GetValueAsPerSystemParameters((decimal.Parse(ds.Tables[0].Rows[0]["SellingPrice"].ToString())).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
        }
        else
        {
            txtComputedMonthlyValue.Text = txtComputedMonthlyValue.Text;
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            hfHoursInMonthERP.Value = GetValueAsPerSystemParameters((decimal.Parse(ds.Tables[0].Rows[0]["HoursInMonth_ERP"].ToString())).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
        else
            hfHoursInMonthERP.Value = "0";

        var ds1 = objSales.ServiceDetailsShiftUpdate(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text,
                                                              hfLocationAutoId.Value,
                                                              averageSellingPrice.ToString(), txtAverageDaysInMonth.Text,
                                                              HfAverageHoursInMonth.Value, averagePayPrice.ToString(), BaseUserID);
    }

    /// <summary>
    /// To fill grid view Pattern
    /// </summary>
    /// <param name="strLocationAutoId">Location Auto Id</param>
    /// <param name="strSoNo">So No.</param>
    /// <param name="strSoAmendNo">So Amend No.</param>
    /// <param name="strSoLineNo">So Line No.</param>
    protected void FillgvPattren(string strLocationAutoId, string strSoNo, string strSoAmendNo, string strSoLineNo)
    {
    
    }

    #region Fill
    /// <summary>
    /// Fillgvs the pattren.
    /// </summary>
    protected void FillgvPattren()
    {
        var objsales = new BL.Sales();
        var ds = objsales.SaleOrderDeploymentShiftsGet(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    gvPattren.DataKeyNames = new[] { "SaleOrderDeptShiftAutoId" };
                    gvPattren.DataSource = dt;
                    gvPattren.DataBind();
                    gvPattren.Rows[0].Visible = false;
                }
                else if (dt.Rows.Count > 0)
                {
                    gvPattren.DataKeyNames = new[] { "SaleOrderDeptShiftAutoId" };
                    gvPattren.DataSource = dt;
                    gvPattren.DataBind();
                }
            }
        }
        CalculateNoOFDays();  
    }
    /// <summary>
    /// Fills the shift details.
    /// </summary>
    protected void FillShiftDetails()
    {
        var objOperationManagement = new BL.OperationManagement();
        var ddlShift = (DropDownList)gvPattren.FooterRow.FindControl("ddlShift");
        if (ddlShift != null && ddlShift.SelectedItem.Value.Length > 0)
        {
            DataSet ds = objOperationManagement.StandardShiftGet(BaseLocationAutoID, ddlShift.SelectedItem.Value);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var TxtMonTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeFrom");
                var TxtMonTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeTo");
                var TxtTueTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeFrom");
                var TxtTueTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeTo");
                var TxtWedTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeFrom");
                var TxtWedTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeTo");
                var TxtThuTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeFrom");
                var TxtThuTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeTo");
                var TxtFriTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeFrom");
                var TxtFriTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeTo");
                var TxtSatTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeFrom");
                var TxtSatTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeTo");
                var TxtSunTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeFrom");
                var TxtSunTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeTo");
                var TxtHolidayTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayTimeFrom");
                var TxtHolidayTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayTimeTo");

                TxtMonTimeFrom.Text = string.Empty;
                TxtMonTimeTo.Text = string.Empty;
                TxtTueTimeFrom.Text = string.Empty;
                TxtTueTimeTo.Text = string.Empty;
                TxtWedTimeFrom.Text = string.Empty;
                TxtWedTimeTo.Text = string.Empty;
                TxtThuTimeFrom.Text = string.Empty;
                TxtThuTimeTo.Text = string.Empty;
                TxtFriTimeFrom.Text = string.Empty;
                TxtFriTimeTo.Text = string.Empty;
                TxtSatTimeFrom.Text = string.Empty;
                TxtSatTimeTo.Text = string.Empty;
                TxtSunTimeFrom.Text = string.Empty;
                TxtSunTimeTo.Text = string.Empty;
                TxtHolidayTimeFrom.Text = string.Empty;
                TxtHolidayTimeTo.Text = string.Empty;

                TxtMonTimeFrom.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["StartTime"]);
                TxtMonTimeTo.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["EndTime"]);
                TxtTueTimeFrom.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["StartTime"]);
                TxtTueTimeTo.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["EndTime"]);
                TxtWedTimeFrom.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["StartTime"]);
                TxtWedTimeTo.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["EndTime"]);
                TxtThuTimeFrom.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["StartTime"]);
                TxtThuTimeTo.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["EndTime"]);
                TxtFriTimeFrom.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["StartTime"]);
                TxtFriTimeTo.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["EndTime"]);
                TxtSatTimeFrom.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["StartTime"]);
                TxtSatTimeTo.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["EndTime"]);
                TxtSunTimeFrom.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["StartTime"]);
                TxtSunTimeTo.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["EndTime"]);
                TxtHolidayTimeFrom.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["StartTime"]);
                TxtHolidayTimeTo.Text = string.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["EndTime"]);
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.msgInvalidShift;
            }
        }
    }
    /// <summary>
    /// Fillddls the shift.
    /// </summary>
    /// <param name="ddlShift">The DDL shift.</param>
    protected void FillddlShift(DropDownList ddlShift)
    {
        var objMastersManagement = new BL.MastersManagement();
        DataSet ds = objMastersManagement.StandardSiftsGet(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlShift.DataSource = ds.Tables[0];
            ddlShift.DataValueField = "ShiftCode";
            ddlShift.DataTextField = "ShiftDesc";
            ddlShift.DataBind();
        }
        else
        {
            var li = new ListItem {Text = @Resources.Resource.NoDataToShow , Value = string.Empty};
            ddlShift.Items.Add(li);
        }
    }
    #endregion Fill

    #region Grid View Events
    /// <summary>
    /// Handles the RowCommand event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CopyTime")
        {
            var TxtMonTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeFrom");
            var TxtMonTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeTo");
            var TxtTueTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeFrom");
            var TxtTueTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeTo");
            var TxtWedTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeFrom");
            var TxtWedTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeTo");
            var TxtThuTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeFrom");
            var TxtThuTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeTo");
            var TxtFriTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeFrom");
            var TxtFriTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeTo");
            var TxtSatTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeFrom");
            var TxtSatTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeTo");
            var TxtSunTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeFrom");
            var TxtSunTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeTo");
            var TxtHolidayTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayTimeFrom");
            var TxtHolidayTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayTimeTo");

            var TxtMonNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtMonNoOfPersons");
            var TxtTueNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtTueNoOfPersons");
            var TxtWedNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtWedNoOfPersons");
            var TxtThuNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtThuNoOfPersons");
            var TxtFriNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtFriNoOfPersons");
            var TxtSatNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtSatNoOfPersons");
            var TxtSunNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtSunNoOfPersons");
            var TxtHolidayNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayNoOfPersons");

            var txtMonSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonSellingRate");
            var txtMonPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonPayRate");
            var txtTueSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtTueSellingRate");
            var txtTuePayRate = (TextBox)gvPattren.FooterRow.FindControl("txtTuePayRate");
            var txtWedSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedSellingRate");
            var txtWedPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedPayRate");
            var txtThuSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuSellingRate");
            var txtThuPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuPayRate");
            var txtFriSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriSellingRate");
            var txtFriPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriPayRate");
            var txtSatSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatSellingRate");
            var txtSatPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatPayRate");
            var txtSunSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunSellingRate");
            var txtSunPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunPayRate");
            var txtHolidaySellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtHolidaySellingRate");
            var txtHolidayPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtHolidayPayRate");

            var txtMonOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonOTSellingRate");
            var txtMonHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonHSellingRate");
            var txtMonOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonOSellingRate");
            var txtTueOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtTueOTSellingRate");
            var txtTueHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtTueHSellingRate");
            var txtTueOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtTueOSellingRate");
            var txtWedOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedOTSellingRate");
            var txtWedHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedHSellingRate");
            var txtWedOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedOSellingRate");
            var txtThuOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuOTSellingRate");
            var txtThuHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuHSellingRate");
            var txtThuOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuOSellingRate");
            var txtFriOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriOTSellingRate");
            var txtFriHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriHSellingRate");
            var txtFriOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriOSellingRate");
            var txtSatOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatOTSellingRate");
            var txtSatHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatHSellingRate");
            var txtSatOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatOSellingRate");
            var txtSunOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunOTSellingRate");
            var txtSunHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunHSellingRate");
            var txtSunOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunOSellingRate");
            var txtHolidayOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtHolidayOTSellingRate");
            var txtHolidayOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtHolidayOSellingRate");

            TxtMonNoOfPersons.Text = TxtSunNoOfPersons.Text;
            TxtMonTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtMonTimeTo.Text = TxtSunTimeTo.Text;

            TxtTueNoOfPersons.Text = TxtSunNoOfPersons.Text;
            TxtTueTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtTueTimeTo.Text = TxtSunTimeTo.Text;

            TxtWedNoOfPersons.Text = TxtSunNoOfPersons.Text;
            TxtWedTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtWedTimeTo.Text = TxtSunTimeTo.Text;

            TxtThuNoOfPersons.Text = TxtSunNoOfPersons.Text;
            TxtThuTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtThuTimeTo.Text = TxtSunTimeTo.Text;

            TxtFriNoOfPersons.Text = TxtSunNoOfPersons.Text;
            TxtFriTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtFriTimeTo.Text = TxtSunTimeTo.Text;

            TxtSatNoOfPersons.Text = TxtSunNoOfPersons.Text;
            TxtSatTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtSatTimeTo.Text = TxtSunTimeTo.Text;

            TxtHolidayNoOfPersons.Text = TxtSunNoOfPersons.Text;
            TxtHolidayTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtHolidayTimeTo.Text = TxtSunTimeTo.Text;

            txtMonSellingRate.Text = txtSunSellingRate.Text;
            txtMonPayRate.Text = txtSunPayRate.Text;
            txtTueSellingRate.Text = txtSunSellingRate.Text;
            txtTuePayRate.Text = txtSunPayRate.Text;
            txtWedSellingRate.Text = txtSunSellingRate.Text;
            txtWedPayRate.Text = txtSunPayRate.Text;
            txtThuSellingRate.Text = txtSunSellingRate.Text;
            txtThuPayRate.Text = txtSunPayRate.Text;
            txtFriSellingRate.Text = txtSunSellingRate.Text;
            txtFriPayRate.Text = txtSunPayRate.Text;
            txtSatSellingRate.Text = txtSunSellingRate.Text;
            txtSatPayRate.Text = txtSunPayRate.Text;
            txtHolidaySellingRate.Text = txtSunSellingRate.Text;
            txtHolidayPayRate.Text = txtSunPayRate.Text;

            txtMonOTSellingRate.Text = txtSunOTSellingRate.Text;
            txtMonHSellingRate.Text = txtSunHSellingRate.Text;
            txtMonOSellingRate.Text = txtSunOSellingRate.Text;
            txtTueOTSellingRate.Text = txtSunOTSellingRate.Text;
            txtTueHSellingRate.Text = txtSunHSellingRate.Text;
            txtTueOSellingRate.Text = txtSunOSellingRate.Text;
            txtWedOTSellingRate.Text = txtSunOTSellingRate.Text;
            txtWedHSellingRate.Text = txtSunHSellingRate.Text;
            txtWedOSellingRate.Text = txtSunOSellingRate.Text;
            txtThuOTSellingRate.Text = txtSunOTSellingRate.Text;
            txtThuHSellingRate.Text = txtSunHSellingRate.Text;
            txtThuOSellingRate.Text = txtSunOSellingRate.Text;
            txtFriOTSellingRate.Text = txtSunOTSellingRate.Text;
            txtFriHSellingRate.Text = txtSunHSellingRate.Text;
            txtFriOSellingRate.Text = txtSunOSellingRate.Text;
            txtSatOTSellingRate.Text = txtSunOTSellingRate.Text;
            txtSatHSellingRate.Text = txtSunHSellingRate.Text;
            txtSatOSellingRate.Text = txtSunOSellingRate.Text;
            txtHolidayOTSellingRate.Text = txtSunOTSellingRate.Text;
            txtHolidayOSellingRate.Text = txtSunOSellingRate.Text;
        }
        if (e.CommandName == "AddNew")
        {

            var confirmValue = Request.Form["confirm_value"];
            var values = confirmValue.Split(',');
            confirmValue = values[values.Length - 1];
            if (confirmValue == "Yes")
            {
                var avgHrs =
                    decimal.Parse(GetValueAsPerSystemParameters(CalculateHrsLabels().ToString(),
                                                                int.Parse(BaseDigitsAfterDecimalPlaces),
                                                                int.Parse(BaseRoundOffCheck)));
                var cHrs =
                    decimal.Parse(GetValueAsPerSystemParameters(CalculateHrsOnNew().ToString(),
                                                                int.Parse(BaseDigitsAfterDecimalPlaces),
                                                                int.Parse(BaseRoundOffCheck)));
                var erpHrs = decimal.Parse(hfHoursInMonthERP.Value);

                if (erpHrs > 0)
                {
                    if ((avgHrs + cHrs) > erpHrs)
                    {
                        lblErrorMsg.Text = Resources.Resource.DeploymentHrscantbegreaterthanHrsdefinedinERP;
                        return;
                    }
                }

                var objSales = new BL.Sales();

                var TxtWeekNo = (TextBox)gvPattren.FooterRow.FindControl("TxtWeekNo");
                var ddlShift = (DropDownList)gvPattren.FooterRow.FindControl("ddlShift");
                var TxtMonTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeFrom");
                var TxtMonTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeTo");
                var TxtTueTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeFrom");
                var TxtTueTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeTo");
                var TxtWedTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeFrom");
                var TxtWedTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeTo");
                var TxtThuTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeFrom");
                var TxtThuTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeTo");
                var TxtFriTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeFrom");
                var TxtFriTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeTo");
                var TxtSatTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeFrom");
                var TxtSatTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeTo");
                var TxtSunTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeFrom");
                var TxtSunTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeTo");
                var TxtHolidayTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayTimeFrom");
                var TxtHolidayTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayTimeTo");

                var TxtMonNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtMonNoOfPersons");
                var TxtTueNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtTueNoOfPersons");
                var TxtWedNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtWedNoOfPersons");
                var TxtThuNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtThuNoOfPersons");
                var TxtFriNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtFriNoOfPersons");
                var TxtSatNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtSatNoOfPersons");
                var TxtSunNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtSunNoOfPersons");
                var TxtHolidayNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayNoOfPersons");

                var txtMonSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonSellingRate");
                var txtMonPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonPayRate");
                var txtTueSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtTueSellingRate");
                var txtTuePayRate = (TextBox)gvPattren.FooterRow.FindControl("txtTuePayRate");
                var txtWedSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedSellingRate");
                var txtWedPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedPayRate");
                var txtThuSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuSellingRate");
                var txtThuPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuPayRate");
                var txtFriSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriSellingRate");
                var txtFriPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriPayRate");
                var txtSatSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatSellingRate");
                var txtSatPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatPayRate");
                var txtSunSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunSellingRate");
                var txtSunPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunPayRate");
                var txtHolidaySellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtHolidaySellingRate");
                var txtHolidayPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtHolidayPayRate");

                var txtMonOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonOTSellingRate");
                var txtMonHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonHSellingRate");
                var txtMonOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonOSellingRate");
                var txtTueOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtTueOTSellingRate");
                var txtTueHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtTueHSellingRate");
                var txtTueOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtTueOSellingRate");
                var txtWedOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedOTSellingRate");
                var txtWedHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedHSellingRate");
                var txtWedOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedOSellingRate");
                var txtThuOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuOTSellingRate");
                var txtThuHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuHSellingRate");
                var txtThuOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuOSellingRate");
                var txtFriOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriOTSellingRate");
                var txtFriHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriHSellingRate");
                var txtFriOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriOSellingRate");
                var txtSatOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatOTSellingRate");
                var txtSatHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatHSellingRate");
                var txtSatOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatOSellingRate");
                var txtSunOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunOTSellingRate");
                var txtSunHSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunHSellingRate");
                var txtSunOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunOSellingRate");
                var txtHolidayOTSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtHolidayOTSellingRate");
                var txtHolidayOSellingRate = (TextBox)gvPattren.FooterRow.FindControl("txtHolidayOSellingRate");

                var ddlHolidayTypeCode = (DropDownList)gvPattren.FooterRow.FindControl("ddlHolidayTypeCode");

                SetBlankSellingAndPayRates(txtMonSellingRate);
                SetBlankSellingAndPayRates(txtTueSellingRate);
                SetBlankSellingAndPayRates(txtWedSellingRate);
                SetBlankSellingAndPayRates(txtThuSellingRate);
                SetBlankSellingAndPayRates(txtFriSellingRate);
                SetBlankSellingAndPayRates(txtSatSellingRate);
                SetBlankSellingAndPayRates(txtSunSellingRate);
                SetBlankSellingAndPayRates(txtHolidaySellingRate);

                SetBlankSellingAndPayRates(txtMonPayRate);
                SetBlankSellingAndPayRates(txtTuePayRate);
                SetBlankSellingAndPayRates(txtWedPayRate);
                SetBlankSellingAndPayRates(txtThuPayRate);
                SetBlankSellingAndPayRates(txtFriPayRate);
                SetBlankSellingAndPayRates(txtSatPayRate);
                SetBlankSellingAndPayRates(txtSunPayRate);
                SetBlankSellingAndPayRates(txtHolidayPayRate);

                SetBlankSellingAndPayRates(txtMonOTSellingRate);
                SetBlankSellingAndPayRates(txtMonHSellingRate);
                SetBlankSellingAndPayRates(txtMonOSellingRate);
                SetBlankSellingAndPayRates(txtTueOTSellingRate);
                SetBlankSellingAndPayRates(txtTueHSellingRate);
                SetBlankSellingAndPayRates(txtTueOSellingRate);
                SetBlankSellingAndPayRates(txtWedOTSellingRate);
                SetBlankSellingAndPayRates(txtWedHSellingRate);
                SetBlankSellingAndPayRates(txtWedOSellingRate);
                SetBlankSellingAndPayRates(txtThuOTSellingRate);
                SetBlankSellingAndPayRates(txtThuHSellingRate);
                SetBlankSellingAndPayRates(txtThuOSellingRate);
                SetBlankSellingAndPayRates(txtFriOTSellingRate);
                SetBlankSellingAndPayRates(txtFriHSellingRate);
                SetBlankSellingAndPayRates(txtFriOSellingRate);
                SetBlankSellingAndPayRates(txtSatOTSellingRate);
                SetBlankSellingAndPayRates(txtSatHSellingRate);
                SetBlankSellingAndPayRates(txtSatOSellingRate);
                SetBlankSellingAndPayRates(txtSunOTSellingRate);
                SetBlankSellingAndPayRates(txtSunHSellingRate);
                SetBlankSellingAndPayRates(txtSunOSellingRate);
                SetBlankSellingAndPayRates(txtHolidayOTSellingRate);
                SetBlankSellingAndPayRates(txtHolidayOSellingRate);

                var strWeekNo = TxtWeekNo.Text;

                if ((
                        TxtMonTimeFrom.Text == string.Empty && TxtMonTimeTo.Text == string.Empty &&
                        TxtTueTimeFrom.Text == string.Empty && TxtTueTimeTo.Text == string.Empty &&
                        TxtWedTimeFrom.Text == string.Empty && TxtWedTimeTo.Text == string.Empty &&
                        TxtThuTimeFrom.Text == string.Empty && TxtThuTimeTo.Text == string.Empty &&
                        TxtFriTimeFrom.Text == string.Empty && TxtFriTimeTo.Text == string.Empty &&
                        TxtSatTimeFrom.Text == string.Empty && TxtSatTimeTo.Text == string.Empty &&
                        TxtSunTimeFrom.Text == string.Empty && TxtSunTimeTo.Text == string.Empty
                    )
                    ||
                    (TxtMonNoOfPersons.Text == @"0" && TxtTueNoOfPersons.Text == @"0" && TxtWedNoOfPersons.Text == @"0" &&
                     TxtThuNoOfPersons.Text == @"0" && TxtFriNoOfPersons.Text == @"0" && TxtSatNoOfPersons.Text == @"0" &&
                     TxtSunNoOfPersons.Text == @"0")
                    ||
                    (TxtMonNoOfPersons.Text == string.Empty && TxtTueNoOfPersons.Text == string.Empty &&
                     TxtWedNoOfPersons.Text == string.Empty && TxtThuNoOfPersons.Text == string.Empty &&
                     TxtFriNoOfPersons.Text == string.Empty && TxtSatNoOfPersons.Text == string.Empty &&
                     TxtSunNoOfPersons.Text == string.Empty)
                    ||
                    (txtMonSellingRate.Text == string.Empty && txtTueSellingRate.Text == string.Empty &&
                     txtWedSellingRate.Text == string.Empty && txtThuSellingRate.Text == string.Empty &&
                     txtFriSellingRate.Text == string.Empty && txtSatSellingRate.Text == string.Empty &&
                     txtSunSellingRate.Text == string.Empty)
                    || (strWeekNo == string.Empty)
                    )
                {
                    lblErrorMsg.Text = Resources.Resource.MsgNothingToSave;
                    return;
                }

                if (bool.Parse(hiddenFieldBillable.Value) && decimal.Parse(txtMonSellingRate.Text) == 0 &&
                    decimal.Parse(txtTueSellingRate.Text) == 0 && decimal.Parse(txtWedSellingRate.Text) == 0 &&
                    decimal.Parse(txtThuSellingRate.Text) == 0 && decimal.Parse(txtFriSellingRate.Text) == 0 &&
                    decimal.Parse(txtSatSellingRate.Text) == 0 && decimal.Parse(txtSunSellingRate.Text) == 0)
                {
                    lblErrorMsg.Text = Resources.Resource.MsgNothingToSave;
                    return;
                }

                if (ddlShift.SelectedItem.Value == string.Empty)
                {
                    lblErrorMsg.Text = Resources.Resource.MsgShiftNotdefined;
                    return;
                }
                if (!ValidateHolidayPattern(ddlHolidayTypeCode.SelectedItem.Value, TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text, TxtHolidayNoOfPersons.Text, txtHolidaySellingRate.Text, txtHolidayPayRate.Text, txtHolidayOTSellingRate.Text, txtHolidayOSellingRate.Text))
                {
                    lblErrorMsg.Text = @"Please correct the Holiday Pattern"; //Resources.Resource.MsgHolidayPatternNotCorrect;
                    return;
                }
                if (CheckDuplicateShift(TxtWeekNo.Text, ddlShift.SelectedValue, "ADD"))
                {
                    DataSet ds = objSales.SaleOrderDeploymentShiftsInsert(hfLocationAutoId.Value, lblSoNo.Text,
                        lblSOAmendNo.Text, lblSOLineNo.Text,
                        TxtWeekNo.Text,
                        ddlShift.SelectedItem.Value,
                        TxtMonNoOfPersons.Text, txtMonSellingRate.Text,
                        txtMonPayRate.Text, TxtMonTimeFrom.Text,
                        TxtMonTimeTo.Text,
                        TxtTueNoOfPersons.Text, txtTueSellingRate.Text,
                        txtTuePayRate.Text, TxtTueTimeFrom.Text,
                        TxtTueTimeTo.Text,
                        TxtWedNoOfPersons.Text, txtWedSellingRate.Text,
                        txtWedPayRate.Text, TxtWedTimeFrom.Text,
                        TxtWedTimeTo.Text,
                        TxtThuNoOfPersons.Text, txtThuSellingRate.Text,
                        txtThuPayRate.Text, TxtThuTimeFrom.Text,
                        TxtThuTimeTo.Text,
                        TxtFriNoOfPersons.Text, txtFriSellingRate.Text,
                        txtFriPayRate.Text, TxtFriTimeFrom.Text,
                        TxtFriTimeTo.Text,
                        TxtSatNoOfPersons.Text, txtSatSellingRate.Text,
                        txtSatPayRate.Text, TxtSatTimeFrom.Text,
                        TxtSatTimeTo.Text,
                        TxtSunNoOfPersons.Text, txtSunSellingRate.Text,
                        txtSunPayRate.Text, TxtSunTimeFrom.Text,
                        TxtSunTimeTo.Text,
                        BaseUserID, txtMonOTSellingRate.Text,
                        txtMonHSellingRate.Text, txtMonOSellingRate.Text,
                        txtTueOTSellingRate.Text, txtTueHSellingRate.Text,
                        txtTueOSellingRate.Text,
                        txtWedOTSellingRate.Text, txtWedHSellingRate.Text,
                        txtWedOSellingRate.Text,
                        txtThuOTSellingRate.Text, txtThuHSellingRate.Text,
                        txtThuOSellingRate.Text,
                        txtFriOTSellingRate.Text, txtFriHSellingRate.Text,
                        txtFriOSellingRate.Text,
                        txtSatOTSellingRate.Text, txtSatHSellingRate.Text,
                        txtSatOSellingRate.Text,
                        txtSunOTSellingRate.Text, txtSunHSellingRate.Text,
                        txtSunOSellingRate.Text,
                        ddlHolidayTypeCode.SelectedItem.Value, TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text, 
                        TxtHolidayNoOfPersons.Text, txtHolidaySellingRate.Text, txtHolidayPayRate.Text, 
                        txtHolidayOTSellingRate.Text, txtHolidayOSellingRate.Text);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    FillgvPattren();
                }
                else
                {

                    lblErrorMsg.Text = Resources.Resource.MsgErrorShiftNameAlreadyExists;

                }
            }
            else
            {
                var txtMonPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtMonPayRate");
                var txtTuePayRate = (TextBox)gvPattren.FooterRow.FindControl("txtTuePayRate");
                var txtWedPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtWedPayRate");
                var txtThuPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtThuPayRate");
                var txtFriPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtFriPayRate");
                var txtSatPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtSatPayRate");
                var txtSunPayRate = (TextBox)gvPattren.FooterRow.FindControl("txtSunPayRate");
                 //txtMonPayRate.Text="";
                 //txtTuePayRate.Text="";
                 //txtWedPayRate.Text="";
                 //txtThuPayRate.Text="";
                 //txtFriPayRate.Text="";
                 //txtSatPayRate.Text="";
                 //txtSunPayRate.Text ="";
                return;
            }
        }
    }

    /// <summary>
    /// validate the holiday pattern data
    /// </summary>
    /// <param name="holidayTypeCode">holiday type code</param>
    /// <param name="holidayTimeFrom">holiday time from</param>
    /// <param name="holidayTimeTo">holiday time to</param>
    /// <param name="holidayNoOfPersons">holiday no of persons</param>
    /// <param name="holidaySellingRate">holiday selling rate</param>
    /// <param name="holidayPayRate">holiday pay rate</param>
    /// <param name="holidayOTSellingRate">holiday Ot selling rate</param>
    /// <param name="holidayOSellingRate">holiday other selling rate</param>
    /// <returns>return true if validation pass else false</returns>
    private bool ValidateHolidayPattern(string holidayTypeCode, string holidayTimeFrom, string holidayTimeTo, string holidayNoOfPersons,
            string holidaySellingRate, string holidayPayRate, string holidayOTSellingRate, string holidayOSellingRate)
    {
        return true;
    }
    /// <summary>
    /// Checks the duplicate shift.
    /// </summary>
    /// <param name="weekNo">The week no.</param>
    /// <param name="shiftCode">The shift code.</param>
    /// <param name="status">The status.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckDuplicateShift(string weekNo, string shiftCode, string status)
    {
        for (var i = 0; i < gvPattren.Rows.Count; i++)
        {

            var existingWeekNo = (Label)gvPattren.Rows[i].FindControl("lblgvWeekNo");
            var existingShiftCode = (LinkButton)gvPattren.Rows[i].FindControl("lbShift");
            if (shiftCode == existingShiftCode.Text)
            {
                for (var j = 0; j < existingWeekNo.Text.Length; j++)
                {
                    var spiltedWeekNo = existingWeekNo.Text.Substring(j, 1);
                    if (weekNo.Contains(spiltedWeekNo))
                    {
                        return false;
                    }
                  
                }
            }
            else
            {
                return true;
            }


        }
        return true;

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
            var ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
            if (ImgbtnEdit != null)
            {
                ImgbtnEdit.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                if (!IsModifyAccess)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            if (ImgbtnDelete != null)
            {
                ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                if (!IsDeleteAccess)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            if (IsDeleteAccess == false && IsModifyAccess == false)
            {
                gvPattren.Columns[0].Visible = false;
            }

            var TxtWeekNo = (TextBox)e.Row.FindControl("TxtEditWeekNo");
            var TxtMonNoOfPersons = (TextBox)e.Row.FindControl("TxtMonNoOfPersons");
            var TxtTueNoOfPersons = (TextBox)e.Row.FindControl("TxtTueNoOfPersons");
            var TxtWedNoOfPersons = (TextBox)e.Row.FindControl("TxtWedNoOfPersons");
            var TxtThuNoOfPersons = (TextBox)e.Row.FindControl("TxtThuNoOfPersons");
            var TxtFriNoOfPersons = (TextBox)e.Row.FindControl("TxtFriNoOfPersons");
            var TxtSatNoOfPersons = (TextBox)e.Row.FindControl("TxtSatNoOfPersons");
            var TxtSunNoOfPersons = (TextBox)e.Row.FindControl("TxtSunNoOfPersons");
            var TxtHolidayNoOfPersons = (TextBox)e.Row.FindControl("TxtHolidayNoOfPersons");
            var TxtMonTimeFrom = (TextBox)e.Row.FindControl("TxtEditMonTimeFrom");
            var TxtMonTimeTo = (TextBox)e.Row.FindControl("TxtEditMonTimeTo");
            var TxtTueTimeFrom = (TextBox)e.Row.FindControl("TxtEditTueTimeFrom");
            var TxtTueTimeTo = (TextBox)e.Row.FindControl("TxtEditTueTimeTo");
            var TxtWedTimeFrom = (TextBox)e.Row.FindControl("TxtEditWedTimeFrom");
            var TxtWedTimeTo = (TextBox)e.Row.FindControl("TxtEditWedTimeTo");
            var TxtThuTimeFrom = (TextBox)e.Row.FindControl("TxtEditThuTimeFrom");
            var TxtThuTimeTo = (TextBox)e.Row.FindControl("TxtEditThuTimeTo");
            var TxtFriTimeFrom = (TextBox)e.Row.FindControl("TxtEditFriTimeFrom");
            var TxtFriTimeTo = (TextBox)e.Row.FindControl("TxtEditFriTimeTo");
            var TxtSatTimeFrom = (TextBox)e.Row.FindControl("TxtEditSatTimeFrom");
            var TxtSatTimeTo = (TextBox)e.Row.FindControl("TxtEditSatTimeTo");
            var TxtSunTimeFrom = (TextBox)e.Row.FindControl("TxtEditSunTimeFrom");
            var TxtSunTimeTo = (TextBox)e.Row.FindControl("TxtEditSunTimeTo");
            var TxtHolidayTimeFrom = (TextBox)e.Row.FindControl("TxtEditHolidayTimeFrom");
            var TxtHolidayTimeTo = (TextBox)e.Row.FindControl("TxtEditHolidayTimeTo");

            var ddlShift = (DropDownList)e.Row.FindControl("ddlShift");
            var hfShift = (HiddenField)e.Row.FindControl("hfShift");

            var ddlHolidayTypeCode = (DropDownList)e.Row.FindControl("ddlHolidayTypeCode");
            var hfHolidayTypeCode = (HiddenField)e.Row.FindControl("hfHolidayTypeCode");
            if (ddlHolidayTypeCode != null)
            {
                FillddlHolidayTypeCode(ddlHolidayTypeCode);
                ddlHolidayTypeCode.SelectedValue = hfHolidayTypeCode.Value;
            }

            if (ddlShift != null)
            {
                FillddlShift(ddlShift);
            }
            if (hfShift != null && ddlShift != null)
            {
                ddlShift.SelectedValue = hfShift.Value;
            }

            if (TxtMonNoOfPersons != null)
            {
                TxtMonNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtMonNoOfPersons.ClientID + "');";
            }
            if (TxtTueNoOfPersons != null)
            {
                TxtTueNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtTueNoOfPersons.ClientID + "');";
            }
            if (TxtWedNoOfPersons != null)
            {
                TxtWedNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtWedNoOfPersons.ClientID + "');";
            }
            if (TxtThuNoOfPersons != null)
            {
                TxtThuNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtThuNoOfPersons.ClientID + "');";
            }
            if (TxtFriNoOfPersons != null)
            {
                TxtFriNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtFriNoOfPersons.ClientID + "');";
            }
            if (TxtSatNoOfPersons != null)
            {
                TxtSatNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtSatNoOfPersons.ClientID + "');";
            }
            if (TxtSunNoOfPersons != null)
            {
                TxtSunNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtSunNoOfPersons.ClientID + "');";
            }

            if (TxtHolidayNoOfPersons != null)
            {
                TxtHolidayNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtHolidayNoOfPersons.ClientID + "');";
            }

            if (TxtWeekNo != null)
            {
                TxtWeekNo.Attributes["onKeyUp"] = "javascript:validateWeek('" + TxtWeekNo.ClientID + "');";
            }

            SetTimeValidationToTextBox(TxtMonTimeFrom);
            SetTimeValidationToTextBox(TxtMonTimeTo);

            SetTimeValidationToTextBox(TxtTueTimeFrom);
            SetTimeValidationToTextBox(TxtTueTimeTo);

            SetTimeValidationToTextBox(TxtWedTimeFrom);
            SetTimeValidationToTextBox(TxtWedTimeTo);

            SetTimeValidationToTextBox(TxtThuTimeFrom);
            SetTimeValidationToTextBox(TxtThuTimeTo);

            SetTimeValidationToTextBox(TxtFriTimeFrom);
            SetTimeValidationToTextBox(TxtFriTimeTo);

            SetTimeValidationToTextBox(TxtSatTimeFrom);
            SetTimeValidationToTextBox(TxtSatTimeTo);

            SetTimeValidationToTextBox(TxtSunTimeFrom);
            SetTimeValidationToTextBox(TxtSunTimeTo);

            SetTimeValidationToTextBox(TxtHolidayTimeFrom);
            SetTimeValidationToTextBox(TxtHolidayTimeTo);

            var txtMonSellingRate = (TextBox)e.Row.FindControl("txtMonSellingRate");
            var txtMonPayRate = (TextBox)e.Row.FindControl("txtMonPayRate");
            var txtTueSellingRate = (TextBox)e.Row.FindControl("txtTueSellingRate");
            var txtTuePayRate = (TextBox)e.Row.FindControl("txtTuePayRate");
            var txtWedSellingRate = (TextBox)e.Row.FindControl("txtWedSellingRate");
            var txtWedPayRate = (TextBox)e.Row.FindControl("txtWedPayRate");
            var txtThuSellingRate = (TextBox)e.Row.FindControl("txtThuSellingRate");
            var txtThuPayRate = (TextBox)e.Row.FindControl("txtThuPayRate");
            var txtFriSellingRate = (TextBox)e.Row.FindControl("txtFriSellingRate");
            var txtFriPayRate = (TextBox)e.Row.FindControl("txtFriPayRate");
            var txtSatSellingRate = (TextBox)e.Row.FindControl("txtSatSellingRate");
            var txtSatPayRate = (TextBox)e.Row.FindControl("txtSatPayRate");
            var txtSunSellingRate = (TextBox)e.Row.FindControl("txtSunSellingRate");
            var txtSunPayRate = (TextBox)e.Row.FindControl("txtSunPayRate");
            var txtHolidaySellingRate = (TextBox)e.Row.FindControl("txtHolidaySellingRate");
            var txtHolidayPayRate = (TextBox)e.Row.FindControl("txtHolidayPayRate");

            var txtMonOTSellingRate = (TextBox)e.Row.FindControl("txtMonOTSellingRate");
            var txtMonHSellingRate = (TextBox)e.Row.FindControl("txtMonHSellingRate");
            var txtMonOSellingRate = (TextBox)e.Row.FindControl("txtMonOSellingRate");
            var txtTueOTSellingRate = (TextBox)e.Row.FindControl("txtTueOTSellingRate");
            var txtTueHSellingRate = (TextBox)e.Row.FindControl("txtTueHSellingRate");
            var txtTueOSellingRate = (TextBox)e.Row.FindControl("txtTueOSellingRate");
            var txtWedOTSellingRate = (TextBox)e.Row.FindControl("txtWedOTSellingRate");
            var txtWedHSellingRate = (TextBox)e.Row.FindControl("txtWedHSellingRate");
            var txtWedOSellingRate = (TextBox)e.Row.FindControl("txtWedOSellingRate");
            var txtThuOTSellingRate = (TextBox)e.Row.FindControl("txtThuOTSellingRate");
            var txtThuHSellingRate = (TextBox)e.Row.FindControl("txtThuHSellingRate");
            var txtThuOSellingRate = (TextBox)e.Row.FindControl("txtThuOSellingRate");
            var txtFriOTSellingRate = (TextBox)e.Row.FindControl("txtFriOTSellingRate");
            var txtFriHSellingRate = (TextBox)e.Row.FindControl("txtFriHSellingRate");
            var txtFriOSellingRate = (TextBox)e.Row.FindControl("txtFriOSellingRate");
            var txtSatOTSellingRate = (TextBox)e.Row.FindControl("txtSatOTSellingRate");
            var txtSatHSellingRate = (TextBox)e.Row.FindControl("txtSatHSellingRate");
            var txtSatOSellingRate = (TextBox)e.Row.FindControl("txtSatOSellingRate");
            var txtSunOTSellingRate = (TextBox)e.Row.FindControl("txtSunOTSellingRate");
            var txtSunHSellingRate = (TextBox)e.Row.FindControl("txtSunHSellingRate");
            var txtSunOSellingRate = (TextBox)e.Row.FindControl("txtSunOSellingRate");
            var txtHolidayOTSellingRate = (TextBox)e.Row.FindControl("txtHolidayOTSellingRate");
            var txtHolidayOSellingRate = (TextBox)e.Row.FindControl("txtHolidayOSellingRate");

            var lblMonSellingRate = (Label)e.Row.FindControl("lblMonSellingRate");
            var lblMonPayRate = (Label)e.Row.FindControl("lblMonPayRate");
            var lblTueSellingRate = (Label)e.Row.FindControl("lblTueSellingRate");
            var lblTuePayRate = (Label)e.Row.FindControl("lblTuePayRate");
            var lblWedSellingRate = (Label)e.Row.FindControl("lblWedSellingRate");
            var lblWedPayRate = (Label)e.Row.FindControl("lblWedPayRate");
            var lblThuSellingRate = (Label)e.Row.FindControl("lblThuSellingRate");
            var lblThuPayRate = (Label)e.Row.FindControl("lblThuPayRate");
            var lblFriSellingRate = (Label)e.Row.FindControl("lblFriSellingRate");
            var lblFriPayRate = (Label)e.Row.FindControl("lblFriPayRate");
            var lblSatSellingRate = (Label)e.Row.FindControl("lblSatSellingRate");
            var lblSatPayRate = (Label)e.Row.FindControl("lblSatPayRate");
            var lblSunSellingRate = (Label)e.Row.FindControl("lblSunSellingRate");
            var lblSunPayRate = (Label)e.Row.FindControl("lblSunPayRate");
            var lblHolidaySellingRate = (Label)e.Row.FindControl("lblHolidaySellingRate");
            var lblHolidayPayRate = (Label)e.Row.FindControl("lblHolidayPayRate");

            var lblMonOTSellingRate = (Label)e.Row.FindControl("lblMonOTSellingRate");
            var lblMonHSellingRate = (Label)e.Row.FindControl("lblMonHSellingRate");
            var lblMonOSellingRate = (Label)e.Row.FindControl("lblMonOSellingRate");
            var lblTueOTSellingRate = (Label)e.Row.FindControl("lblTueOTSellingRate");
            var lblTueHSellingRate = (Label)e.Row.FindControl("lblTueHSellingRate");
            var lblTueOSellingRate = (Label)e.Row.FindControl("lblTueOSellingRate");
            var lblWedOTSellingRate = (Label)e.Row.FindControl("lblWedOTSellingRate");
            var lblWedHSellingRate = (Label)e.Row.FindControl("lblWedHSellingRate");
            var lblWedOSellingRate = (Label)e.Row.FindControl("lblWedOSellingRate");
            var lblThuOTSellingRate = (Label)e.Row.FindControl("lblThuOTSellingRate");
            var lblThuHSellingRate = (Label)e.Row.FindControl("lblThuHSellingRate");
            var lblThuOSellingRate = (Label)e.Row.FindControl("lblThuOSellingRate");
            var lblFriOTSellingRate = (Label)e.Row.FindControl("lblFriOTSellingRate");
            var lblFriHSellingRate = (Label)e.Row.FindControl("lblFriHSellingRate");
            var lblFriOSellingRate = (Label)e.Row.FindControl("lblFriOSellingRate");
            var lblSatOTSellingRate = (Label)e.Row.FindControl("lblSatOTSellingRate");
            var lblSatHSellingRate = (Label)e.Row.FindControl("lblSatHSellingRate");
            var lblSatOSellingRate = (Label)e.Row.FindControl("lblSatOSellingRate");
            var lblSunOTSellingRate = (Label)e.Row.FindControl("lblSunOTSellingRate");
            var lblSunHSellingRate = (Label)e.Row.FindControl("lblSunHSellingRate");
            var lblSunOSellingRate = (Label)e.Row.FindControl("lblSunOSellingRate");
            var lblHolidayOTSellingRate = (Label)e.Row.FindControl("lblHolidayOTSellingRate");
            var lblHolidayOSellingRate = (Label)e.Row.FindControl("lblHolidayOSellingRate");

            var lblgvSellingRate = (Label)e.Row.FindControl("lblgvSellingRate");
            var lblgvPayRate = (Label)e.Row.FindControl("lblgvPayRate");

            var tbl1 = (Table)e.Row.FindControl("tbl1");

            if (IsAuthorizationAccess || IsWriteAccess  || IsModifyAccess )
            {
                SetVisibilitytxtBoxLable(lblgvSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblgvPayRate, "lbl", true);
                if (tbl1 != null)
                {
                    tbl1.Rows[1].Visible = true;
                    tbl1.Rows[2].Visible = true;
                }

                SetVisibilitytxtBoxLable(txtMonSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTueSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtHolidaySellingRate, "txt", true);

                SetVisibilitytxtBoxLable(txtMonPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTuePayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtHolidayPayRate, "txt", true);

                SetVisibilitytxtBoxLable(txtMonOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtMonHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtMonOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTueOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTueHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTueOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtHolidayOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtHolidayOSellingRate, "txt", true);

                SetVisibilitytxtBoxLable(lblMonSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblTueSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblWedSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblThuSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblFriSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSatSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSunSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblHolidaySellingRate, "lbl", true);

                SetVisibilitytxtBoxLable(lblMonPayRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblTuePayRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblWedPayRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblThuPayRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblFriPayRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSatPayRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSunPayRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblHolidayPayRate, "lbl", true);

                SetVisibilitytxtBoxLable(lblMonOTSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblMonHSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblMonOSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblTueOTSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblTueHSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblTueOSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblWedOTSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblWedHSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblWedOSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblThuOTSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblThuHSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblThuOSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblFriOTSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblFriHSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblFriOSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSatOTSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSatHSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSatOSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSunOTSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSunHSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblSunOSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblHolidayOTSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblHolidayOSellingRate, "lbl", true);
            }
            else if (IsAuthorizationAccess == false && IsWriteAccess == false && IsModifyAccess == false)
            {
                if (tbl1 != null)
                {
                    tbl1.Rows[1].Visible = false;
                }
                SetVisibilitytxtBoxLable(lblgvSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(txtMonSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtMonOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtMonHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtMonOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidayOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidayOSellingRate, "txt", false);

                SetVisibilitytxtBoxLable(lblMonSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblTueSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblWedSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblThuSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblFriSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSatSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSunSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblMonOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblMonHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblMonOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblTueOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblTueHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblTueOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblWedOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblWedHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblWedOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblThuOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblThuHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblThuOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblFriOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblFriHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblFriOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSatOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSatHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSatOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSunOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSunHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSunOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblHolidayOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblHolidayOSellingRate, "lbl", false);
            }

            SetFloatValidationToTextBox(txtMonSellingRate);
            SetFloatValidationToTextBox(txtTueSellingRate);
            SetFloatValidationToTextBox(txtWedSellingRate);
            SetFloatValidationToTextBox(txtThuSellingRate);
            SetFloatValidationToTextBox(txtFriSellingRate);
            SetFloatValidationToTextBox(txtSatSellingRate);
            SetFloatValidationToTextBox(txtSunSellingRate);
            SetFloatValidationToTextBox(txtHolidaySellingRate);

            SetFloatValidationToTextBox(txtMonPayRate);
            SetFloatValidationToTextBox(txtTuePayRate);
            SetFloatValidationToTextBox(txtWedPayRate);
            SetFloatValidationToTextBox(txtThuPayRate);
            SetFloatValidationToTextBox(txtFriPayRate);
            SetFloatValidationToTextBox(txtSatPayRate);
            SetFloatValidationToTextBox(txtSunPayRate);
            SetFloatValidationToTextBox(txtHolidayPayRate);

            SetFloatValidationToTextBox(txtMonOTSellingRate);
            SetFloatValidationToTextBox(txtMonHSellingRate);
            SetFloatValidationToTextBox(txtMonOSellingRate);
            SetFloatValidationToTextBox(txtTueOTSellingRate);
            SetFloatValidationToTextBox(txtTueHSellingRate);
            SetFloatValidationToTextBox(txtTueOSellingRate);
            SetFloatValidationToTextBox(txtWedOTSellingRate);
            SetFloatValidationToTextBox(txtWedHSellingRate);
            SetFloatValidationToTextBox(txtWedOSellingRate);
            SetFloatValidationToTextBox(txtThuOTSellingRate);
            SetFloatValidationToTextBox(txtThuHSellingRate);
            SetFloatValidationToTextBox(txtThuOSellingRate);
            SetFloatValidationToTextBox(txtFriOTSellingRate);
            SetFloatValidationToTextBox(txtFriHSellingRate);
            SetFloatValidationToTextBox(txtFriOSellingRate);
            SetFloatValidationToTextBox(txtSatOTSellingRate);
            SetFloatValidationToTextBox(txtSatHSellingRate);
            SetFloatValidationToTextBox(txtSatOSellingRate);
            SetFloatValidationToTextBox(txtSunOTSellingRate);
            SetFloatValidationToTextBox(txtSunHSellingRate);
            SetFloatValidationToTextBox(txtSunOSellingRate);
            SetFloatValidationToTextBox(txtHolidayOTSellingRate);
            SetFloatValidationToTextBox(txtHolidayOSellingRate);

            if (hiddenFieldOTChargeRateActive.Value != "1")
            {
                SetVisibilitytxtBoxLable(txtMonOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidayOTSellingRate, "txt", false);

                SetVisibilitytxtBoxLable(lblMonOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblTueOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblWedOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblThuOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblFriOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSatOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSunOTSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblHolidayOTSellingRate, "lbl", false);
            }
            if (hiddenFieldHChargeRateActive.Value != "1")
            {
                SetVisibilitytxtBoxLable(txtMonHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunHSellingRate, "txt", false);

                SetVisibilitytxtBoxLable(lblMonHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblTueHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblWedHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblThuHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblFriHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSatHSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSunHSellingRate, "lbl", false);
            }
            if (hiddenFieldOChargeRateActive.Value != "1")
            {
                SetVisibilitytxtBoxLable(txtMonOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidayOSellingRate, "txt", false);

                SetVisibilitytxtBoxLable(lblMonOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblTueOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblWedOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblThuOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblFriOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSatOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblSunOSellingRate, "lbl", false);
                SetVisibilitytxtBoxLable(lblHolidayOSellingRate, "lbl", false);
            }
            if (hiddenFieldHolidayDept.Value != "1")
            {
                gvPattren.Columns[11].Visible = false;
                gvPattren.Columns[12].Visible = false;
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            var ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
            if (ImgbtnAdd != null)
            {
                ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
            }
            if (IsWriteAccess == false)
            {
                gvPattren.ShowFooter = false;
            }

            var TxtWeekNo = (TextBox)e.Row.FindControl("TxtWeekNo");
            var ddlShift = (DropDownList)e.Row.FindControl("ddlShift");

            var TxtMonNoOfPersons = (TextBox)e.Row.FindControl("TxtMonNoOfPersons");
            var TxtTueNoOfPersons = (TextBox)e.Row.FindControl("TxtTueNoOfPersons");
            var TxtWedNoOfPersons = (TextBox)e.Row.FindControl("TxtWedNoOfPersons");
            var TxtThuNoOfPersons = (TextBox)e.Row.FindControl("TxtThuNoOfPersons");
            var TxtFriNoOfPersons = (TextBox)e.Row.FindControl("TxtFriNoOfPersons");
            var TxtSatNoOfPersons = (TextBox)e.Row.FindControl("TxtSatNoOfPersons");
            var TxtSunNoOfPersons = (TextBox)e.Row.FindControl("TxtSunNoOfPersons");
            var TxtHolidayNoOfPersons = (TextBox)e.Row.FindControl("TxtHolidayNoOfPersons");

            var TxtMonTimeFrom = (TextBox)e.Row.FindControl("TxtMonTimeFrom");
            var TxtMonTimeTo = (TextBox)e.Row.FindControl("TxtMonTimeTo");
            var TxtTueTimeFrom = (TextBox)e.Row.FindControl("TxtTueTimeFrom");
            var TxtTueTimeTo = (TextBox)e.Row.FindControl("TxtTueTimeTo");
            var TxtWedTimeFrom = (TextBox)e.Row.FindControl("TxtWedTimeFrom");
            var TxtWedTimeTo = (TextBox)e.Row.FindControl("TxtWedTimeTo");
            var TxtThuTimeFrom = (TextBox)e.Row.FindControl("TxtThuTimeFrom");
            var TxtThuTimeTo = (TextBox)e.Row.FindControl("TxtThuTimeTo");
            var TxtFriTimeFrom = (TextBox)e.Row.FindControl("TxtFriTimeFrom");
            var TxtFriTimeTo = (TextBox)e.Row.FindControl("TxtFriTimeTo");
            var TxtSatTimeFrom = (TextBox)e.Row.FindControl("TxtSatTimeFrom");
            var TxtSatTimeTo = (TextBox)e.Row.FindControl("TxtSatTimeTo");
            var TxtSunTimeFrom = (TextBox)e.Row.FindControl("TxtSunTimeFrom");
            var TxtSunTimeTo = (TextBox)e.Row.FindControl("TxtSunTimeTo");
            var TxtHolidayTimeFrom = (TextBox)e.Row.FindControl("TxtHolidayTimeFrom");
            var TxtHolidayTimeTo = (TextBox)e.Row.FindControl("TxtHolidayTimeTo");

            var txtMonSellingRate = (TextBox)e.Row.FindControl("txtMonSellingRate");
            var txtMonPayRate = (TextBox)e.Row.FindControl("txtMonPayRate");
            var txtTueSellingRate = (TextBox)e.Row.FindControl("txtTueSellingRate");
            var txtTuePayRate = (TextBox)e.Row.FindControl("txtTuePayRate");
            var txtWedSellingRate = (TextBox)e.Row.FindControl("txtWedSellingRate");
            var txtWedPayRate = (TextBox)e.Row.FindControl("txtWedPayRate");
            var txtThuSellingRate = (TextBox)e.Row.FindControl("txtThuSellingRate");
            var txtThuPayRate = (TextBox)e.Row.FindControl("txtThuPayRate");
            var txtFriSellingRate = (TextBox)e.Row.FindControl("txtFriSellingRate");
            var txtFriPayRate = (TextBox)e.Row.FindControl("txtFriPayRate");
            var txtSatSellingRate = (TextBox)e.Row.FindControl("txtSatSellingRate");
            var txtSatPayRate = (TextBox)e.Row.FindControl("txtSatPayRate");
            var txtSunSellingRate = (TextBox)e.Row.FindControl("txtSunSellingRate");
            var txtSunPayRate = (TextBox)e.Row.FindControl("txtSunPayRate");
            var txtHolidaySellingRate = (TextBox)e.Row.FindControl("txtHolidaySellingRate");
            var txtHolidayPayRate = (TextBox)e.Row.FindControl("txtHolidayPayRate");

            var txtMonOTSellingRate = (TextBox)e.Row.FindControl("txtMonOTSellingRate");
            var txtMonHSellingRate = (TextBox)e.Row.FindControl("txtMonHSellingRate");
            var txtMonOSellingRate = (TextBox)e.Row.FindControl("txtMonOSellingRate");
            var txtTueOTSellingRate = (TextBox)e.Row.FindControl("txtTueOTSellingRate");
            var txtTueHSellingRate = (TextBox)e.Row.FindControl("txtTueHSellingRate");
            var txtTueOSellingRate = (TextBox)e.Row.FindControl("txtTueOSellingRate");
            var txtWedOTSellingRate = (TextBox)e.Row.FindControl("txtWedOTSellingRate");
            var txtWedHSellingRate = (TextBox)e.Row.FindControl("txtWedHSellingRate");
            var txtWedOSellingRate = (TextBox)e.Row.FindControl("txtWedOSellingRate");
            var txtThuOTSellingRate = (TextBox)e.Row.FindControl("txtThuOTSellingRate");
            var txtThuHSellingRate = (TextBox)e.Row.FindControl("txtThuHSellingRate");
            var txtThuOSellingRate = (TextBox)e.Row.FindControl("txtThuOSellingRate");
            var txtFriOTSellingRate = (TextBox)e.Row.FindControl("txtFriOTSellingRate");
            var txtFriHSellingRate = (TextBox)e.Row.FindControl("txtFriHSellingRate");
            var txtFriOSellingRate = (TextBox)e.Row.FindControl("txtFriOSellingRate");
            var txtSatOTSellingRate = (TextBox)e.Row.FindControl("txtSatOTSellingRate");
            var txtSatHSellingRate = (TextBox)e.Row.FindControl("txtSatHSellingRate");
            var txtSatOSellingRate = (TextBox)e.Row.FindControl("txtSatOSellingRate");
            var txtSunOTSellingRate = (TextBox)e.Row.FindControl("txtSunOTSellingRate");
            var txtSunHSellingRate = (TextBox)e.Row.FindControl("txtSunHSellingRate");
            var txtSunOSellingRate = (TextBox)e.Row.FindControl("txtSunOSellingRate");
            var txtHolidayOTSellingRate = (TextBox)e.Row.FindControl("txtHolidayOTSellingRate");
            var txtHolidayOSellingRate = (TextBox)e.Row.FindControl("txtHolidayOSellingRate");

            var ddlHolidayTypeCode = (DropDownList)e.Row.FindControl("ddlHolidayTypeCode");
            if (ddlHolidayTypeCode != null)
            {
                FillddlHolidayTypeCode(ddlHolidayTypeCode);
            }

            if (ddlShift != null)
            {
                FillddlShift(ddlShift);

                var objOperationManagement = new BL.OperationManagement();
                if (ddlShift != null && ddlShift.SelectedItem.Value.Length > 0)
                {
                    DataSet dsShiftDetails = objOperationManagement.StandardShiftGet(BaseLocationAutoID,
                        ddlShift.SelectedItem.Value);
                    if (dsShiftDetails != null && dsShiftDetails.Tables.Count > 0 &&
                        dsShiftDetails.Tables[0].Rows.Count > 0)
                    {
                        TxtMonTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                        TxtMonTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                        TxtTueTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                        TxtTueTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                        TxtWedTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                        TxtWedTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                        TxtThuTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                        TxtThuTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                        TxtFriTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                        TxtFriTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                        TxtSatTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                        TxtSatTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                        TxtSunTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                        TxtSunTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                        TxtHolidayTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                        TxtHolidayTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidShift;
                        return;
                    }
                }
            }

            if (TxtMonNoOfPersons != null)
            {
                TxtMonNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtMonNoOfPersons.ClientID + "');";
            }
            if (TxtTueNoOfPersons != null)
            {
                TxtTueNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtTueNoOfPersons.ClientID + "');";
            }
            if (TxtWedNoOfPersons != null)
            {
                TxtWedNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtWedNoOfPersons.ClientID + "');";
            }
            if (TxtThuNoOfPersons != null)
            {
                TxtThuNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtThuNoOfPersons.ClientID + "');";
            }
            if (TxtFriNoOfPersons != null)
            {
                TxtFriNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtFriNoOfPersons.ClientID + "');";
            }
            if (TxtSatNoOfPersons != null)
            {
                TxtSatNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtSatNoOfPersons.ClientID + "');";
            }
            if (TxtSunNoOfPersons != null)
            {
                TxtSunNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtSunNoOfPersons.ClientID + "');";
            }
            if (TxtHolidayNoOfPersons != null)
            {
                TxtHolidayNoOfPersons.Attributes["onKeyUp"] = "javascript:validateNumeric('" +
                                                          TxtHolidayNoOfPersons.ClientID + "');";
            }

            if (TxtWeekNo != null)
            {
                TxtWeekNo.Attributes["onKeyUp"] = "javascript:validateWeek('" + TxtWeekNo.ClientID + "');";
            }
            SetTimeValidationToTextBox(TxtMonTimeFrom);
            SetTimeValidationToTextBox(TxtMonTimeTo);

            SetTimeValidationToTextBox(TxtTueTimeFrom);
            SetTimeValidationToTextBox(TxtTueTimeTo);

            SetTimeValidationToTextBox(TxtWedTimeFrom);
            SetTimeValidationToTextBox(TxtWedTimeTo);

            SetTimeValidationToTextBox(TxtThuTimeFrom);
            SetTimeValidationToTextBox(TxtThuTimeTo);

            SetTimeValidationToTextBox(TxtFriTimeFrom);
            SetTimeValidationToTextBox(TxtFriTimeTo);

            SetTimeValidationToTextBox(TxtSatTimeFrom);
            SetTimeValidationToTextBox(TxtSatTimeTo);

            SetTimeValidationToTextBox(TxtSunTimeFrom);
            SetTimeValidationToTextBox(TxtSunTimeTo);

            SetTimeValidationToTextBox(TxtHolidayTimeFrom);
            SetTimeValidationToTextBox(TxtHolidayTimeTo);

            SetFloatValidationToTextBox(txtMonSellingRate);
            SetFloatValidationToTextBox(txtTueSellingRate);
            SetFloatValidationToTextBox(txtWedSellingRate);
            SetFloatValidationToTextBox(txtThuSellingRate);
            SetFloatValidationToTextBox(txtFriSellingRate);
            SetFloatValidationToTextBox(txtSatSellingRate);
            SetFloatValidationToTextBox(txtSunSellingRate);
            SetFloatValidationToTextBox(txtHolidaySellingRate);

            SetFloatValidationToTextBox(txtMonPayRate);
            SetFloatValidationToTextBox(txtTuePayRate);
            SetFloatValidationToTextBox(txtWedPayRate);
            SetFloatValidationToTextBox(txtThuPayRate);
            SetFloatValidationToTextBox(txtFriPayRate);
            SetFloatValidationToTextBox(txtSatPayRate);
            SetFloatValidationToTextBox(txtSunPayRate);
            SetFloatValidationToTextBox(txtHolidayPayRate);

            SetFloatValidationToTextBox(txtMonOTSellingRate);
            SetFloatValidationToTextBox(txtMonHSellingRate);
            SetFloatValidationToTextBox(txtMonOSellingRate);
            SetFloatValidationToTextBox(txtTueOTSellingRate);
            SetFloatValidationToTextBox(txtTueHSellingRate);
            SetFloatValidationToTextBox(txtTueOSellingRate);
            SetFloatValidationToTextBox(txtWedOTSellingRate);
            SetFloatValidationToTextBox(txtWedHSellingRate);
            SetFloatValidationToTextBox(txtWedOSellingRate);
            SetFloatValidationToTextBox(txtThuOTSellingRate);
            SetFloatValidationToTextBox(txtThuHSellingRate);
            SetFloatValidationToTextBox(txtThuOSellingRate);
            SetFloatValidationToTextBox(txtFriOTSellingRate);
            SetFloatValidationToTextBox(txtFriHSellingRate);
            SetFloatValidationToTextBox(txtFriOSellingRate);
            SetFloatValidationToTextBox(txtSatOTSellingRate);
            SetFloatValidationToTextBox(txtSatHSellingRate);
            SetFloatValidationToTextBox(txtSatOSellingRate);
            SetFloatValidationToTextBox(txtSunOTSellingRate);
            SetFloatValidationToTextBox(txtSunHSellingRate);
            SetFloatValidationToTextBox(txtSunOSellingRate);
            SetFloatValidationToTextBox(txtHolidayOTSellingRate);
            SetFloatValidationToTextBox(txtHolidayOSellingRate);

            SetDefaultChargeRate(txtMonSellingRate);
            SetDefaultChargeRate(txtTueSellingRate);
            SetDefaultChargeRate(txtWedSellingRate);
            SetDefaultChargeRate(txtThuSellingRate);
            SetDefaultChargeRate(txtFriSellingRate);
            SetDefaultChargeRate(txtSatSellingRate);
            SetDefaultChargeRate(txtSunSellingRate);
            SetDefaultChargeRate(txtHolidaySellingRate);

            SetDefaultPayRate(txtMonPayRate);
            SetDefaultPayRate(txtTuePayRate);
            SetDefaultPayRate(txtWedPayRate);
            SetDefaultPayRate(txtThuPayRate);
            SetDefaultPayRate(txtFriPayRate);
            SetDefaultPayRate(txtSatPayRate);
            SetDefaultPayRate(txtSunPayRate);
            SetDefaultPayRate(txtHolidayPayRate);

            SetDefaultNoOfPerson(TxtMonNoOfPersons);
            SetDefaultNoOfPerson(TxtTueNoOfPersons);
            SetDefaultNoOfPerson(TxtWedNoOfPersons);
            SetDefaultNoOfPerson(TxtThuNoOfPersons);
            SetDefaultNoOfPerson(TxtFriNoOfPersons);
            SetDefaultNoOfPerson(TxtSatNoOfPersons);
            SetDefaultNoOfPerson(TxtSunNoOfPersons);
            SetDefaultNoOfPerson(TxtHolidayNoOfPersons);

            SetDefaultZeroChargeRate(txtMonOTSellingRate);
            SetDefaultZeroChargeRate(txtMonHSellingRate);
            SetDefaultZeroChargeRate(txtMonOSellingRate);
            SetDefaultZeroChargeRate(txtTueOTSellingRate);
            SetDefaultZeroChargeRate(txtTueHSellingRate);
            SetDefaultZeroChargeRate(txtTueOSellingRate);
            SetDefaultZeroChargeRate(txtWedOTSellingRate);
            SetDefaultZeroChargeRate(txtWedHSellingRate);
            SetDefaultZeroChargeRate(txtWedOSellingRate);
            SetDefaultZeroChargeRate(txtThuOTSellingRate);
            SetDefaultZeroChargeRate(txtThuHSellingRate);
            SetDefaultZeroChargeRate(txtThuOSellingRate);
            SetDefaultZeroChargeRate(txtFriOTSellingRate);
            SetDefaultZeroChargeRate(txtFriHSellingRate);
            SetDefaultZeroChargeRate(txtFriOSellingRate);
            SetDefaultZeroChargeRate(txtSatOTSellingRate);
            SetDefaultZeroChargeRate(txtSatHSellingRate);
            SetDefaultZeroChargeRate(txtSatOSellingRate);
            SetDefaultZeroChargeRate(txtSunOTSellingRate);
            SetDefaultZeroChargeRate(txtSunHSellingRate);
            SetDefaultZeroChargeRate(txtSunOSellingRate);
            SetDefaultZeroChargeRate(txtHolidayOTSellingRate);
            SetDefaultZeroChargeRate(txtHolidayOSellingRate);


            var lblgvSellingRate = (Label)e.Row.FindControl("lblgvSellingRate");
            var lblgvPayRate = (Label)e.Row.FindControl("lblgvPayRate");
            var tbl1 = (Table)e.Row.FindControl("tbl1");

            if (IsAuthorizationAccess|| IsWriteAccess || IsModifyAccess)
            {
                SetVisibilitytxtBoxLable(lblgvSellingRate, "lbl", true);
                SetVisibilitytxtBoxLable(lblgvPayRate, "lbl", true);
                if (tbl1 != null)
                {
                    tbl1.Rows[1].Visible = true;
                    tbl1.Rows[2].Visible = true;
                }

                SetVisibilitytxtBoxLable(txtMonSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTueSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtHolidaySellingRate, "txt", true);

                SetVisibilitytxtBoxLable(txtMonPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTuePayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunPayRate, "txt", true);
                SetVisibilitytxtBoxLable(txtHolidayPayRate, "txt", true);

                SetVisibilitytxtBoxLable(txtMonOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtMonHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtMonOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTueOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTueHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtTueOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtWedOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtThuOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtFriOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSatOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunHSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtSunOSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtHolidayOTSellingRate, "txt", true);
                SetVisibilitytxtBoxLable(txtHolidayOSellingRate, "txt", true);
            }
            else if (IsAuthorizationAccess == false && IsWriteAccess == false && IsModifyAccess == false)
            {
                SetVisibilitytxtBoxLable(lblgvSellingRate, "lbl", false);
                if (tbl1 != null)
                {
                    tbl1.Rows[1].Visible = false;
                }

                SetVisibilitytxtBoxLable(txtMonSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidaySellingRate, "txt", false);

                SetVisibilitytxtBoxLable(txtMonOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtMonHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtMonOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidayOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidayOSellingRate, "txt", false);
            }

            if (hiddenFieldOTChargeRateActive.Value != "1")
            {
                SetVisibilitytxtBoxLable(txtMonOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunOTSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidayOTSellingRate, "txt", false);
            }
            if (hiddenFieldHChargeRateActive.Value != "1")
            {
                SetVisibilitytxtBoxLable(txtMonHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatHSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunHSellingRate, "txt", false);
            }
            if (hiddenFieldOChargeRateActive.Value != "1")
            {
                SetVisibilitytxtBoxLable(txtMonOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtTueOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtWedOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtThuOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtFriOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSatOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtSunOSellingRate, "txt", false);
                SetVisibilitytxtBoxLable(txtHolidayOSellingRate, "txt", false);
            }
        }
    }
    /// <summary>
    /// Sets the visibilitytxt box lable.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <param name="txtLbl">The text label.</param>
    /// <param name="TrueFalse">if set to <c>true</c> [true false].</param>
    private void SetVisibilitytxtBoxLable(object obj, string txtLbl, bool TrueFalse)
    {
        if (obj != null)
        {
            if (txtLbl == "txt")
            {
                var textBox1 = (TextBox)obj;
                textBox1.Visible = TrueFalse;
            }
            else if (txtLbl == "lbl")
            {
                var Lable1 = (Label)obj;
                Lable1.Visible = TrueFalse;
            }
        }
    }
    /// <summary>
    /// Sets the default no of person.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    private void SetDefaultNoOfPerson(object textBox)
    {
        if (textBox != null)
        {
            var textBox1 = (TextBox)textBox;
            textBox1.Text = hfNoOfPost.Value;
        }
    }
    /// <summary>
    /// Sets the default charge rate.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    private void SetDefaultChargeRate(object textBox)
    {
        if (textBox != null)
        {
            var textBox1 = (TextBox)textBox;
            textBox1.Text = hfChargeRatePerHrs.Value;
        }
    }
    /// <summary>
    /// Sets the default pay rate.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    private void SetDefaultPayRate(object textBox)
    {
        if (textBox != null)
        {
            var textBox1 = (TextBox)textBox;
            textBox1.Text = hfPayRatePerHrs.Value;
        }
    }
    /// <summary>
    /// Sets the default zero charge rate.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    private void SetDefaultZeroChargeRate(object textBox)
    {
        if (textBox != null)
        {
            var textBox1 = (TextBox)textBox;
            textBox1.Text = @"0";
        }
    }

    /// <summary>
    /// Sets the float validation to text box.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    private void SetFloatValidationToTextBox(object textBox)
    {
        if (textBox != null)
        {
            var FloatTextBox = (TextBox)textBox;

            FloatTextBox.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
            FloatTextBox.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
        }
    }
    /// <summary>
    /// Sets the time validation to text box.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    private void SetTimeValidationToTextBox(object textBox)
    {
        if (textBox != null)
        {
            var TimeTextBox = (TextBox)textBox;
            TimeTextBox.Attributes["onKeyUp"] = "javascript:Timevalnum('" + TimeTextBox.ClientID + "');";
            TimeTextBox.Attributes["onblur"] = "javascript:IsValidTime('" + TimeTextBox.ClientID + "');";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPattren.EditIndex = e.NewEditIndex;
        FillgvPattren();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPattren.EditIndex = -1;

        FillgvPattren();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        hfSaleOrderDeptShiftUpdateOrDelete.Value = "DELETE";
        var hfSaleOrderDeptShiftAutoId = (HiddenField)gvPattren.Rows[e.RowIndex].FindControl("hfSaleOrderDeptShiftAutoId");

        if (hfSaleOrderDeptShiftAutoId != null)
        {
            hfSaleOrderDeptShiftAutoIdForDelete.Value = hfSaleOrderDeptShiftAutoId.Value;
            var objPreTermination = new BL.PreTermination();
            var dsRotaSchRota = objPreTermination.RotaGet(hfSaleOrderDeptShiftAutoId.Value);
            if (dsRotaSchRota != null && dsRotaSchRota.Tables.Count > 1 && (dsRotaSchRota.Tables[0].Rows.Count > 0 || dsRotaSchRota.Tables[1].Rows.Count > 0))
            {
                mdlPopup.Show();
                FillgvDeleteRota();
                FillgvScheduleRoster();
            }
            else
            {
                var objSales = new BL.Sales();
                var ds = objSales.SaleOrderDeploymentShiftsDelete(hfSaleOrderDeptShiftAutoId.Value);
                FillgvPattren();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPattren.PageIndex = e.NewPageIndex;
        gvPattren.EditIndex = -1;
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void gvPattren_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var confirmValue = Request.Form["confirm_value"];
        var values = confirmValue.Split(',');
        confirmValue = values[values.Length - 1];
        if (confirmValue == "Yes")
        {
            hfSaleOrderDeptShiftUpdateOrDelete.Value = "UPDATE";
            hfSaleOrderDeptShiftUpdateStatus.Value = "CHECK";
            hfSaleOrderDeptShiftRowIndex.Value = e.RowIndex.ToString();
            RowUpdating();
        }
        else
        {
            return;
        }

    }
    /// <summary>
    /// Rows the updating.
    /// </summary>
    protected void RowUpdating()
    {
        var rowIndex = int.Parse(hfSaleOrderDeptShiftRowIndex.Value);
        var avgHrs = decimal.Parse(GetValueAsPerSystemParameters(CalculateHrsLabels().ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck)));
        var cHrs = decimal.Parse(GetValueAsPerSystemParameters(CalculateHrsOnEdit(rowIndex).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck)));
        var erpHrs = decimal.Parse(hfHoursInMonthERP.Value);
        if (erpHrs > 0)
        {
            if ((avgHrs + cHrs) > erpHrs)
            {
                lblErrorMsg.Text = Resources.Resource.DeploymentHrscantbegreaterthanHrsdefinedinERP;
                return;
            }
        }
        
        var TxtEditWeekNo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditWeekNo");
        var ddlShift = (DropDownList)gvPattren.Rows[rowIndex].FindControl("ddlShift");

        var TxtMonNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtMonNoOfPersons");
        var TxtTueNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtTueNoOfPersons");
        var TxtWedNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtWedNoOfPersons");
        var TxtThuNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtThuNoOfPersons");
        var TxtFriNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtFriNoOfPersons");
        var TxtSatNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtSatNoOfPersons");
        var TxtSunNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtSunNoOfPersons");
        var TxtHolidayNoOfPersons = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtHolidayNoOfPersons");

        var TxtEditMonTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditMonTimeFrom");
        var TxtEditMonTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditMonTimeTo");
        var TxtEditTueTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditTueTimeFrom");
        var TxtEditTueTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditTueTimeTo");
        var TxtEditWedTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditWedTimeFrom");
        var TxtEditWedTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditWedTimeTo");
        var TxtEditThuTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditThuTimeFrom");
        var TxtEditThuTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditThuTimeTo");
        var TxtEditFriTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditFriTimeFrom");
        var TxtEditFriTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditFriTimeTo");
        var TxtEditSatTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditSatTimeFrom");
        var TxtEditSatTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditSatTimeTo");
        var TxtEditSunTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditSunTimeFrom");
        var TxtEditSunTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditSunTimeTo");
        var TxtEditHolidayTimeFrom = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditHolidayTimeFrom");
        var TxtEditHolidayTimeTo = (TextBox)gvPattren.Rows[rowIndex].FindControl("TxtEditHolidayTimeTo");

        var txtMonSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtMonSellingRate");
        var txtMonPayRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtMonPayRate");
        var txtTueSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtTueSellingRate");
        var txtTuePayRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtTuePayRate");
        var txtWedSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtWedSellingRate");
        var txtWedPayRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtWedPayRate");
        var txtThuSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtThuSellingRate");
        var txtThuPayRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtThuPayRate");
        var txtFriSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtFriSellingRate");
        var txtFriPayRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtFriPayRate");
        var txtSatSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSatSellingRate");
        var txtSatPayRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSatPayRate");
        var txtSunSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSunSellingRate");
        var txtSunPayRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSunPayRate");
        var txtHolidaySellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtHolidaySellingRate");
        var txtHolidayPayRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtHolidayPayRate");

        var txtMonOTSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtMonOTSellingRate");
        var txtMonHSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtMonHSellingRate");
        var txtMonOSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtMonOSellingRate");
        var txtTueOTSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtTueOTSellingRate");
        var txtTueHSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtTueHSellingRate");
        var txtTueOSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtTueOSellingRate");
        var txtWedOTSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtWedOTSellingRate");
        var txtWedHSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtWedHSellingRate");
        var txtWedOSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtWedOSellingRate");
        var txtThuOTSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtThuOTSellingRate");
        var txtThuHSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtThuHSellingRate");
        var txtThuOSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtThuOSellingRate");
        var txtFriOTSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtFriOTSellingRate");
        var txtFriHSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtFriHSellingRate");
        var txtFriOSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtFriOSellingRate");
        var txtSatOTSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSatOTSellingRate");
        var txtSatHSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSatHSellingRate");
        var txtSatOSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSatOSellingRate");
        var txtSunOTSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSunOTSellingRate");
        var txtSunHSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSunHSellingRate");
        var txtSunOSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtSunOSellingRate");
        var txtHolidayOTSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtHolidayOTSellingRate");
        var txtHolidayOSellingRate = (TextBox)gvPattren.Rows[rowIndex].FindControl("txtHolidayOSellingRate");

        var ddlHolidayTypeCode = (DropDownList)gvPattren.Rows[rowIndex].FindControl("ddlHolidayTypeCode");

        SetBlankSellingAndPayRates(txtMonSellingRate);
        SetBlankSellingAndPayRates(txtTueSellingRate);
        SetBlankSellingAndPayRates(txtWedSellingRate);
        SetBlankSellingAndPayRates(txtThuSellingRate);
        SetBlankSellingAndPayRates(txtFriSellingRate);
        SetBlankSellingAndPayRates(txtSatSellingRate);
        SetBlankSellingAndPayRates(txtSunSellingRate);
        SetBlankSellingAndPayRates(txtHolidaySellingRate);

        SetBlankSellingAndPayRates(txtMonPayRate);
        SetBlankSellingAndPayRates(txtTuePayRate);
        SetBlankSellingAndPayRates(txtWedPayRate);
        SetBlankSellingAndPayRates(txtThuPayRate);
        SetBlankSellingAndPayRates(txtFriPayRate);
        SetBlankSellingAndPayRates(txtSatPayRate);
        SetBlankSellingAndPayRates(txtSunPayRate);
        SetBlankSellingAndPayRates(txtHolidayPayRate);

        SetBlankSellingAndPayRates(txtMonOTSellingRate);
        SetBlankSellingAndPayRates(txtMonHSellingRate);
        SetBlankSellingAndPayRates(txtMonOSellingRate);
        SetBlankSellingAndPayRates(txtTueOTSellingRate);
        SetBlankSellingAndPayRates(txtTueHSellingRate);
        SetBlankSellingAndPayRates(txtTueOSellingRate);
        SetBlankSellingAndPayRates(txtWedOTSellingRate);
        SetBlankSellingAndPayRates(txtWedHSellingRate);
        SetBlankSellingAndPayRates(txtWedOSellingRate);
        SetBlankSellingAndPayRates(txtThuOTSellingRate);
        SetBlankSellingAndPayRates(txtThuHSellingRate);
        SetBlankSellingAndPayRates(txtThuOSellingRate);
        SetBlankSellingAndPayRates(txtFriOTSellingRate);
        SetBlankSellingAndPayRates(txtFriHSellingRate);
        SetBlankSellingAndPayRates(txtFriOSellingRate);
        SetBlankSellingAndPayRates(txtSatOTSellingRate);
        SetBlankSellingAndPayRates(txtSatHSellingRate);
        SetBlankSellingAndPayRates(txtSatOSellingRate);
        SetBlankSellingAndPayRates(txtSunOTSellingRate);
        SetBlankSellingAndPayRates(txtSunHSellingRate);
        SetBlankSellingAndPayRates(txtSunOSellingRate);
        SetBlankSellingAndPayRates(txtHolidayOTSellingRate);
        SetBlankSellingAndPayRates(txtHolidayOSellingRate);

        var objSale = new BL.Sales();
        var strWeekNo = TxtEditWeekNo.Text;
        if (bool.Parse(hiddenFieldBillable.Value)  && decimal.Parse(txtMonSellingRate.Text) == 0 && decimal.Parse(txtTueSellingRate.Text) == 0 && decimal.Parse(txtWedSellingRate.Text) == 0 && decimal.Parse(txtThuSellingRate.Text) == 0 && decimal.Parse(txtFriSellingRate.Text) == 0 && decimal.Parse(txtSatSellingRate.Text) == 0 && decimal.Parse(txtSunSellingRate.Text) == 0)
        {
            lblErrorMsg.Text = Resources.Resource.MsgNothingToSave;
            return;
        }
        if ((TxtEditMonTimeFrom.Text == string.Empty && TxtEditMonTimeTo.Text == string.Empty && TxtEditTueTimeFrom.Text == string.Empty && TxtEditTueTimeTo.Text == string.Empty && TxtEditWedTimeFrom.Text == string.Empty && TxtEditWedTimeTo.Text == string.Empty && TxtEditThuTimeFrom.Text == string.Empty && TxtEditThuTimeTo.Text == string.Empty && TxtEditFriTimeFrom.Text == string.Empty && TxtEditFriTimeTo.Text == string.Empty && TxtEditSatTimeFrom.Text == string.Empty && TxtEditSatTimeTo.Text == string.Empty && TxtEditSunTimeFrom.Text == string.Empty && TxtEditSunTimeTo.Text == string.Empty)
            || (TxtMonNoOfPersons.Text == @"0" && TxtTueNoOfPersons.Text == @"0" && TxtWedNoOfPersons.Text == @"0" && TxtThuNoOfPersons.Text == @"0" && TxtFriNoOfPersons.Text == @"0" && TxtSatNoOfPersons.Text == @"0" && TxtSunNoOfPersons.Text == @"0")
            || (TxtMonNoOfPersons.Text == string.Empty && TxtTueNoOfPersons.Text == string.Empty && TxtWedNoOfPersons.Text == string.Empty && TxtThuNoOfPersons.Text == string.Empty && TxtFriNoOfPersons.Text == string.Empty && TxtSatNoOfPersons.Text == string.Empty && TxtSunNoOfPersons.Text == string.Empty)
            ////|| (decimal.Parse(txtMonSellingRate.Text) == 0 && decimal.Parse(txtTueSellingRate.Text) == 0 && decimal.Parse(txtWedSellingRate.Text) == 0 && decimal.Parse(txtThuSellingRate.Text) == 0 && decimal.Parse(txtFriSellingRate.Text) == 0 && decimal.Parse(txtSatSellingRate.Text) == 0 && decimal.Parse(txtSunSellingRate.Text) == 0)
            || (txtMonSellingRate.Text == string.Empty && txtTueSellingRate.Text == string.Empty && txtWedSellingRate.Text == string.Empty && txtThuSellingRate.Text == string.Empty && txtFriSellingRate.Text == string.Empty && txtSatSellingRate.Text == string.Empty && txtSunSellingRate.Text == string.Empty)
            || (strWeekNo == string.Empty)
            )
        {
            lblErrorMsg.Text = Resources.Resource.MsgNothingToSave;
            return;
        }

        var obj = new BL.Sales();

        using (var dsBreakDetails = obj.SaleOrderDeploymentShiftsBreakGet(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlShift.SelectedItem.Value, TxtEditWeekNo.Text))
        {
            if (dsBreakDetails != null && dsBreakDetails.Tables.Count > 0 && dsBreakDetails.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsBreakDetails.Tables[0].Rows.Count; i++)
                {
                    if (TxtEditSunTimeFrom.Text != string.Empty)
                    {

                        
                            var DeptSunTimeFrom = dsBreakDetails.Tables[0].Rows[i]["DeptSunTimeFrom"].ToString();
                            var DeptSunTimeTo = dsBreakDetails.Tables[0].Rows[i]["DeptSunTimeTo"].ToString();
                            var SunTimeFrom = dsBreakDetails.Tables[0].Rows[i]["SunTimeFrom"].ToString();
                            var SunTimeTo = dsBreakDetails.Tables[0].Rows[i]["SunTimeTo"].ToString();
                            if (Convert.ToDateTime(DateTime.Parse(DeptSunTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptSunTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(DeptSunTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptSunTimeTo = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(SunTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                SunTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(SunTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                SunTimeTo = string.Empty;
                            }
                            if (SunTimeFrom != string.Empty)
                            {
                                if (!CheckValidBreak(TxtEditSunTimeFrom.Text, TxtEditSunTimeTo.Text, DeptSunTimeFrom, DeptSunTimeTo, "ShiftBreak", SunTimeFrom, SunTimeTo))
                                {
                                    lblErrorMsg.Text = Resources.Resource.BreakBetweenShift;
                                    return;
                                }
                            }
                        

                    }
                    if (TxtEditMonTimeFrom.Text != string.Empty)
                    {

                        
                            var DeptMonTimeFrom = dsBreakDetails.Tables[0].Rows[i]["DeptMonTimeFrom"].ToString();
                            var DeptMonTimeTo = dsBreakDetails.Tables[0].Rows[i]["DeptMonTimeTo"].ToString();
                            var MonTimeFrom = dsBreakDetails.Tables[0].Rows[i]["MonTimeFrom"].ToString();
                            var MonTimeTo = dsBreakDetails.Tables[0].Rows[i]["MonTimeTo"].ToString();
                            if (Convert.ToDateTime(DateTime.Parse(DeptMonTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptMonTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(DeptMonTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptMonTimeTo = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(MonTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                MonTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(MonTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                MonTimeTo = string.Empty;
                            }
                            if (MonTimeFrom != string.Empty)
                            {
                                if (!CheckValidBreak(TxtEditMonTimeFrom.Text, TxtEditMonTimeTo.Text, DeptMonTimeFrom, DeptMonTimeTo, "ShiftBreak", MonTimeFrom, MonTimeTo))
                                {
                                    lblErrorMsg.Text = Resources.Resource.BreakBetweenShift;
                                    return;
                                }
                            }
                        


                    }
                    if (TxtEditTueTimeFrom.Text != string.Empty)
                    {

                        
                            var DeptTueTimeFrom = dsBreakDetails.Tables[0].Rows[i]["DeptTueTimeFrom"].ToString();
                            var DeptTueTimeTo = dsBreakDetails.Tables[0].Rows[i]["DeptTueTimeTo"].ToString();
                            var TueTimeFrom = dsBreakDetails.Tables[0].Rows[i]["TueTimeFrom"].ToString();
                            var TueTimeTo = dsBreakDetails.Tables[0].Rows[i]["TueTimeTo"].ToString();
                            if (Convert.ToDateTime(DateTime.Parse(DeptTueTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptTueTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(DeptTueTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptTueTimeTo = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(TueTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                TueTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(TueTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                TueTimeTo = string.Empty;
                            }
                            if (TueTimeTo != string.Empty)
                            {
                                if (!CheckValidBreak(TxtEditTueTimeFrom.Text, TxtEditTueTimeTo.Text, DeptTueTimeFrom, DeptTueTimeTo, "ShiftBreak", TueTimeFrom, TueTimeTo))
                                {
                                    lblErrorMsg.Text = Resources.Resource.BreakBetweenShift;
                                    return;
                                }
                        
                        }
                    } if (TxtEditWedTimeFrom.Text != string.Empty)
                    {
                        
                            var DeptWedTimeFrom = dsBreakDetails.Tables[0].Rows[i]["DeptWedTimeFrom"].ToString();
                            var DeptWedTimeTo = dsBreakDetails.Tables[0].Rows[i]["DeptWedTimeTo"].ToString();
                            var WedTimeFrom = dsBreakDetails.Tables[0].Rows[i]["WedTimeFrom"].ToString();
                            var WedTimeTo = dsBreakDetails.Tables[0].Rows[i]["WedTimeTo"].ToString();
                            if (Convert.ToDateTime(DateTime.Parse(DeptWedTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptWedTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(DeptWedTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptWedTimeTo = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(WedTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                WedTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(WedTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                WedTimeTo = string.Empty;
                            }

                            if (WedTimeTo != string.Empty)
                            {
                                if (!CheckValidBreak(TxtEditWedTimeFrom.Text, TxtEditWedTimeTo.Text, DeptWedTimeFrom, DeptWedTimeTo, "ShiftBreak", WedTimeFrom, WedTimeTo))
                                {
                                    lblErrorMsg.Text = Resources.Resource.BreakBetweenShift;
                                    return;
                                }
                        
                        }
                    } if (TxtEditThuTimeFrom.Text != string.Empty)
                    {

                        
                            var DeptThuTimeFrom = dsBreakDetails.Tables[0].Rows[i]["DeptThuTimeFrom"].ToString();
                            var DeptThuTimeTo = dsBreakDetails.Tables[0].Rows[i]["DeptThuTimeTo"].ToString();
                            var ThuTimeFrom = dsBreakDetails.Tables[0].Rows[i]["ThuTimeFrom"].ToString();
                            var ThuTimeTo = dsBreakDetails.Tables[0].Rows[i]["ThuTimeTo"].ToString();
                            if (Convert.ToDateTime(DateTime.Parse(DeptThuTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptThuTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(DeptThuTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptThuTimeTo = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(ThuTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                ThuTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(ThuTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                ThuTimeTo = string.Empty;
                            }
                            if (ThuTimeTo != string.Empty)
                            {
                                if (!CheckValidBreak(TxtEditThuTimeFrom.Text, TxtEditThuTimeTo.Text, DeptThuTimeFrom, DeptThuTimeTo, "ShiftBreak", ThuTimeFrom, ThuTimeTo))
                                {
                                    lblErrorMsg.Text = Resources.Resource.BreakBetweenShift;
                                    return;
                                }
                        }
                    }
                    if (TxtEditFriTimeFrom.Text != string.Empty)
                    {

                            var DeptFriTimeFrom = dsBreakDetails.Tables[0].Rows[i]["DeptFriTimeFrom"].ToString();
                            var DeptFriTimeTo = dsBreakDetails.Tables[0].Rows[i]["DeptFriTimeTo"].ToString();
                            var FriTimeFrom = dsBreakDetails.Tables[0].Rows[i]["FriTimeFrom"].ToString();
                            var FriTimeTo = dsBreakDetails.Tables[0].Rows[i]["FriTimeTo"].ToString();
                            if (Convert.ToDateTime(DateTime.Parse(DeptFriTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptFriTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(DeptFriTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptFriTimeTo = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(FriTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                FriTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(FriTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                FriTimeTo = string.Empty;
                            }
                            if (FriTimeTo != string.Empty)
                            {
                                if (!CheckValidBreak(TxtEditFriTimeFrom.Text, TxtEditFriTimeTo.Text, DeptFriTimeFrom, DeptFriTimeTo, "ShiftBreak", FriTimeFrom, FriTimeTo))
                                {
                                    lblErrorMsg.Text = Resources.Resource.BreakBetweenShift;
                                    return;
                                }
                        }
                    }
                    if (TxtEditSatTimeFrom.Text != string.Empty)
                    {

                            var DeptSatTimeFrom = dsBreakDetails.Tables[0].Rows[i]["DeptSatTimeFrom"].ToString();
                            var DeptSatTimeTo = dsBreakDetails.Tables[0].Rows[i]["DeptSatTimeTo"].ToString();
                            var SatTimeFrom = dsBreakDetails.Tables[0].Rows[i]["SatTimeFrom"].ToString();
                            var SatTimeTo = dsBreakDetails.Tables[0].Rows[i]["SatTimeTo"].ToString();
                            if (Convert.ToDateTime(DateTime.Parse(DeptSatTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptSatTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(DeptSatTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                DeptSatTimeTo = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(SatTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                SatTimeFrom = string.Empty;
                            }
                            if (Convert.ToDateTime(DateTime.Parse(SatTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                            {
                                SatTimeTo = string.Empty;
                            }
                            if (SatTimeTo != string.Empty)
                            {

                                if (!CheckValidBreak(TxtEditSatTimeFrom.Text, TxtEditSatTimeTo.Text, DeptSatTimeFrom, DeptSatTimeTo, "ShiftBreak", SatTimeFrom, SatTimeTo))
                                {
                                    lblErrorMsg.Text = Resources.Resource.BreakBetweenShift;
                                    return;
                                }
                            }
                        }
                    if (TxtEditHolidayTimeFrom.Text != string.Empty)
                    {
                        var DeptHolidayTimeFrom = dsBreakDetails.Tables[0].Rows[i]["DeptHolidayTimeFrom"].ToString();
                        var DeptHolidayTimeTo = dsBreakDetails.Tables[0].Rows[i]["DeptHolidayTimeTo"].ToString();
                        var HolidayTimeFrom = dsBreakDetails.Tables[0].Rows[i]["HolidayTimeFrom"].ToString();
                        var HolidayTimeTo = dsBreakDetails.Tables[0].Rows[i]["HolidayTimeTo"].ToString();
                        if (Convert.ToDateTime(DateTime.Parse(DeptHolidayTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                        {
                            DeptHolidayTimeFrom = string.Empty;
                        }
                        if (Convert.ToDateTime(DateTime.Parse(DeptHolidayTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                        {
                            DeptHolidayTimeTo = string.Empty;
                        }
                        if (Convert.ToDateTime(DateTime.Parse(HolidayTimeFrom).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                        {
                            HolidayTimeFrom = string.Empty;
                        }
                        if (Convert.ToDateTime(DateTime.Parse(HolidayTimeTo).ToString("HH:mm")) == Convert.ToDateTime("00:00"))
                        {
                            HolidayTimeTo = string.Empty;
                        }
                        if (HolidayTimeTo != string.Empty)
                        {

                            if (!CheckValidBreak(TxtEditHolidayTimeFrom.Text, TxtEditHolidayTimeTo.Text, DeptHolidayTimeFrom, DeptHolidayTimeTo, "ShiftBreak", HolidayTimeFrom, HolidayTimeTo))
                            {
                                lblErrorMsg.Text = Resources.Resource.BreakBetweenShift;
                                return;
                            }
                        }
                    }
                }
            }
        }

        DataSet ds = objSale.SaleOrderDeploymentShiftsUpdate(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, TxtEditWeekNo.Text, ddlShift.SelectedItem.Value,
            TxtMonNoOfPersons.Text, txtMonSellingRate.Text, txtMonPayRate.Text, TxtEditMonTimeFrom.Text, TxtEditMonTimeTo.Text,
            TxtTueNoOfPersons.Text, txtTueSellingRate.Text, txtTuePayRate.Text, TxtEditTueTimeFrom.Text, TxtEditTueTimeTo.Text,
            TxtWedNoOfPersons.Text, txtWedSellingRate.Text, txtWedPayRate.Text, TxtEditWedTimeFrom.Text, TxtEditWedTimeTo.Text,
            TxtThuNoOfPersons.Text, txtThuSellingRate.Text, txtThuPayRate.Text, TxtEditThuTimeFrom.Text, TxtEditThuTimeTo.Text,
            TxtFriNoOfPersons.Text, txtFriSellingRate.Text, txtFriPayRate.Text, TxtEditFriTimeFrom.Text, TxtEditFriTimeTo.Text,
            TxtSatNoOfPersons.Text, txtSatSellingRate.Text, txtSatPayRate.Text, TxtEditSatTimeFrom.Text, TxtEditSatTimeTo.Text,
            TxtSunNoOfPersons.Text, txtSunSellingRate.Text, txtSunPayRate.Text, TxtEditSunTimeFrom.Text, TxtEditSunTimeTo.Text,
            BaseUserID, hfSaleOrderDeptShiftUpdateStatus.Value,
            txtMonOTSellingRate.Text, txtMonHSellingRate.Text, txtMonOSellingRate.Text,
            txtTueOTSellingRate.Text, txtTueHSellingRate.Text, txtTueOSellingRate.Text,
            txtWedOTSellingRate.Text, txtWedHSellingRate.Text, txtWedOSellingRate.Text,
            txtThuOTSellingRate.Text, txtThuHSellingRate.Text, txtThuOSellingRate.Text,
            txtFriOTSellingRate.Text, txtFriHSellingRate.Text, txtFriOSellingRate.Text,
            txtSatOTSellingRate.Text, txtSatHSellingRate.Text, txtSatOSellingRate.Text,
            txtSunOTSellingRate.Text, txtSunHSellingRate.Text, txtSunOSellingRate.Text,
            ddlHolidayTypeCode.SelectedItem.Value, TxtEditHolidayTimeFrom.Text, TxtEditHolidayTimeTo.Text,
                        TxtHolidayNoOfPersons.Text, txtHolidaySellingRate.Text, txtHolidayPayRate.Text,
                        txtHolidayOTSellingRate.Text, txtHolidayOSellingRate.Text);
        if (ds != null && ds.Tables.Count > 1 && hfSaleOrderDeptShiftUpdateStatus.Value == "CHECK" && (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0))
        {
            mdlPopup.Show();

            gvScheduleRoster.DataSource = ds.Tables[0];
            gvScheduleRoster.DataBind();

            gvDeleteRota.DataSource = ds.Tables[1];
            gvDeleteRota.DataBind();

        }
        else if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            gvPattren.EditIndex = -1;
            FillgvPattren();
        }
    }
    #endregion Grid View Events

    /// <summary>
    /// Set the values 0 to the Text box are left blank
    /// </summary>
    /// <param name="txtBox">The text box.</param>
    private void SetBlankSellingAndPayRates(Object txtBox)
    {
        if (txtBox != null)
        {
            var txtBox1 = (TextBox)txtBox;
            if (txtBox1.Text == string.Empty)
                txtBox1.Text = @"0";
        }
    }

    /// <summary>
    /// Reset Button Click Event
    /// </summary>
    /// <param name="sender">Object of the Reset Button</param>
    /// <param name="e">Event Args</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        var TxtWeekNo = (TextBox)gvPattren.FooterRow.FindControl("TxtWeekNo");
        var TxtMonTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeFrom");
        var TxtMonTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtMonTimeTo");
        var TxtTueTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeFrom");
        var TxtTueTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtTueTimeTo");
        var TxtWedTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeFrom");
        var TxtWedTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtWedTimeTo");
        var TxtThuTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeFrom");
        var TxtThuTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtThuTimeTo");
        var TxtFriTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeFrom");
        var TxtFriTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtFriTimeTo");
        var TxtSatTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeFrom");
        var TxtSatTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSatTimeTo");
        var TxtSunTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeFrom");
        var TxtSunTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtSunTimeTo");
        var TxtHolidayTimeFrom = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayTimeFrom");
        var TxtHolidayTimeTo = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayTimeTo");

        var TxtMonNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtMonNoOfPersons");
        var TxtTueNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtTueNoOfPersons");
        var TxtWedNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtWedNoOfPersons");
        var TxtThuNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtThuNoOfPersons");
        var TxtFriNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtFriNoOfPersons");
        var TxtSatNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtSatNoOfPersons");
        var TxtSunNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtSunNoOfPersons");
        var TxtHolidayNoOfPersons = (TextBox)gvPattren.FooterRow.FindControl("TxtHolidayNoOfPersons");

        TxtMonNoOfPersons.Text = @"0";
        TxtTueNoOfPersons.Text = @"0";
        TxtWedNoOfPersons.Text = @"0";
        TxtThuNoOfPersons.Text = @"0";
        TxtFriNoOfPersons.Text = @"0";
        TxtSatNoOfPersons.Text = @"0";
        TxtSunNoOfPersons.Text = @"0";
        TxtHolidayNoOfPersons.Text = @"0";

        TxtWeekNo.Text = string.Empty;
        TxtMonTimeFrom.Text = string.Empty;
        TxtMonTimeTo.Text = string.Empty;
        TxtTueTimeFrom.Text = string.Empty;
        TxtTueTimeTo.Text = string.Empty;
        TxtWedTimeFrom.Text = string.Empty;
        TxtWedTimeTo.Text = string.Empty;
        TxtThuTimeFrom.Text = string.Empty;
        TxtThuTimeTo.Text = string.Empty;
        TxtFriTimeFrom.Text = string.Empty;
        TxtFriTimeTo.Text = string.Empty;
        TxtSatTimeFrom.Text = string.Empty;
        TxtSatTimeTo.Text = string.Empty;
        TxtSunTimeFrom.Text = string.Empty;
        TxtSunTimeTo.Text = string.Empty;
        TxtHolidayTimeFrom.Text = string.Empty;
        TxtHolidayTimeTo.Text = string.Empty;
    }
    /// <summary>
    /// Checks the filled values.
    /// </summary>
    /// <param name="intRow">The int row.</param>
    /// <param name="strWeek">The string week.</param>
    /// <returns>Boolean.</returns>
    protected Boolean CheckFilledValues(int intRow, string strWeek)
    {
        return true;
    }

    #region Shift TextChanged
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlShiftEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlShiftEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        var objTextBox = (DropDownList)sender;
        var row = (GridViewRow)objTextBox.NamingContainer;
        var ddlShift = (DropDownList)gvPattren.Rows[row.RowIndex].FindControl("ddlShift");
        var TxtEditMonTimeFrom = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditMonTimeFrom");
        var TxtEditMonTimeTo = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditMonTimeTo");
        var TxtEditTueTimeFrom = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditTueTimeFrom");
        var TxtEditTueTimeTo = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditTueTimeTo");
        var TxtEditWedTimeFrom = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditWedTimeFrom");
        var TxtEditWedTimeTo = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditWedTimeTo");
        var TxtEditThuTimeFrom = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditThuTimeFrom");
        var TxtEditThuTimeTo = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditThuTimeTo");
        var TxtEditFriTimeFrom = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditFriTimeFrom");
        var TxtEditFriTimeTo = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditFriTimeTo");
        var TxtEditSatTimeFrom = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditSatTimeFrom");
        var TxtEditSatTimeTo = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditSatTimeTo");
        var TxtEditSunTimeFrom = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditSunTimeFrom");
        var TxtEditSunTimeTo = (TextBox)gvPattren.Rows[row.RowIndex].FindControl("TxtEditSunTimeTo");
        var objOperationManagement = new BL.OperationManagement();
        if (ddlShift != null && ddlShift.SelectedItem.Value.Length > 0)
        {
            DataSet dsShiftDetails = objOperationManagement.StandardShiftGet(BaseLocationAutoID, ddlShift.SelectedItem.Value);
            if (dsShiftDetails != null && dsShiftDetails.Tables.Count > 0 && dsShiftDetails.Tables[0].Rows.Count > 0)
            {
                TxtEditMonTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                TxtEditMonTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                TxtEditTueTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                TxtEditTueTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                TxtEditWedTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                TxtEditWedTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                TxtEditThuTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                TxtEditThuTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                TxtEditFriTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                TxtEditFriTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                TxtEditSatTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                TxtEditSatTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);
                TxtEditSunTimeFrom.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["StartTime"]);
                TxtEditSunTimeTo.Text = string.Format("{0:HH:mm}", dsShiftDetails.Tables[0].Rows[0]["EndTime"]);

            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.InvalidShift;
            }
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlShift = (DropDownList)gvPattren.FooterRow.FindControl("ddlShift");
        if (ddlShift.SelectedItem.Value.Length > 0)
        {
            FillShiftDetails();
        }
    }
    #endregion

    /// <summary>
    /// The index
    /// </summary>
    static int Index;
    /// <summary>
    /// Handles the RowCommand event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvScheduleRoster.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvScheduleRoster.PageIndex = gvScheduleRoster.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the DataBound event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_DataBound(object sender, EventArgs e)
    {
        var row = gvScheduleRoster.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        var lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvScheduleRoster.PageCount; i++)
            {
                int intPageNumber = i + 1;
                var lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvScheduleRoster.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvScheduleRoster.PageCount.ToString();
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var gvrPager = gvScheduleRoster.BottomPagerRow;
        var ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        var CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        switch (Index)
        {
            case 1:
                if (CurrentIndex > 0)
                {
                    gvScheduleRoster.PageIndex = CurrentIndex - 1;
                }
                else
                {
                    gvScheduleRoster.PageIndex = CurrentIndex;
                }
                Index = -1;
                break;
            case 0:
                gvScheduleRoster.PageIndex = CurrentIndex + 1;
                Index = -1;
                break;
            default:
                gvScheduleRoster.PageIndex = e.NewPageIndex;
                break;
        }
        FillgvScheduleRoster();
    }
    /// <summary>
    /// Function for the delete rota operation in Sales Ops Grid.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPagesDeleteRota_SelectedIndexChanged(object sender, EventArgs e)
    {
        var row = gvDeleteRota.BottomPagerRow;
        var ddlPagesDeleteRota = (DropDownList)row.Cells[0].FindControl("ddlPagesDeleteRota");
        gvDeleteRota.PageIndex = ddlPagesDeleteRota.SelectedIndex;
        FillgvDeleteRota();
    }

    /// <summary>
    /// Handles the RowCommand event of the gvDeleteRota control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvDeleteRota_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvDeleteRota.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvDeleteRota.PageIndex = gvDeleteRota.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the DataBound event of the gvDeleteRota control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvDeleteRota_DataBound(object sender, EventArgs e)
    {
        var row = gvDeleteRota.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        var ddlPagesDeleteRota = (DropDownList)row.Cells[0].FindControl("ddlPagesDeleteRota");
        var lblPageCountDeleteRota = (Label)row.Cells[0].FindControl("lblPageCountDeleteRota");
        if (ddlPagesDeleteRota != null)
        {
            for (var i = 0; i < gvDeleteRota.PageCount; i++)
            {
                var intPageNumber = i + 1;
                var lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvDeleteRota.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPagesDeleteRota.Items.Add(lstItem);
            }
        }
        if (lblPageCountDeleteRota != null)
        {
            lblPageCountDeleteRota.Text = gvDeleteRota.PageCount.ToString();
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvDeleteRota control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvDeleteRota_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var gvrPager = gvDeleteRota.BottomPagerRow;
        var ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPagesDeleteRota");
        var CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        switch (Index)
        {
            case 1:
                if (CurrentIndex > 0)
                {
                    gvDeleteRota.PageIndex = CurrentIndex - 1;
                }
                else
                {
                    gvDeleteRota.PageIndex = CurrentIndex;
                }
                Index = -1;
                break;
            case 0:
                gvDeleteRota.PageIndex = CurrentIndex + 1;
                Index = -1;
                break;
            default:
                gvDeleteRota.PageIndex = e.NewPageIndex;
                break;
        }
        gvDeleteRota.EditIndex = -1;
        FillgvDeleteRota();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        var row = gvScheduleRoster.BottomPagerRow;
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvScheduleRoster.PageIndex = ddlPages.SelectedIndex;
        FillgvScheduleRoster();
    }
    /// <summary>
    /// Fillgvs the schedule roster.
    /// </summary>
    private void FillgvScheduleRoster()
    {
        if (hfSaleOrderDeptShiftUpdateOrDelete.Value == "DELETE")
        {
            var objPreTermination = new BL.PreTermination();
            var dsRotaSchRota = objPreTermination.RotaGet(hfSaleOrderDeptShiftAutoIdForDelete.Value);
            if (dsRotaSchRota != null && dsRotaSchRota.Tables.Count > 0 && dsRotaSchRota.Tables[0].Rows.Count > 0)
            {
                gvScheduleRoster.DataSource = dsRotaSchRota.Tables[0];
                gvScheduleRoster.DataBind();
            }
        }
        else if (hfSaleOrderDeptShiftUpdateOrDelete.Value == "UPDATE")
        {
            RowUpdating();
        }
    }
    /// <summary>
    /// Fillgvs the delete rota.
    /// </summary>
    private void FillgvDeleteRota()
    {
        switch (hfSaleOrderDeptShiftUpdateOrDelete.Value)
        {
            case "DELETE":
                {
                    var objPreTermination = new BL.PreTermination();
                    var dsRotaSchRota = objPreTermination.RotaGet(hfSaleOrderDeptShiftAutoIdForDelete.Value);
                    if (dsRotaSchRota != null && dsRotaSchRota.Tables.Count > 1 && dsRotaSchRota.Tables[1].Rows.Count > 0)
                    {
                        gvDeleteRota.DataSource = dsRotaSchRota.Tables[1];
                        gvDeleteRota.DataBind();
                    }
                }
                break;
            case "UPDATE":
                RowUpdating();
                break;
        }
    }

    /// <summary>
    /// Handles the onClick event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_onClick(object sender, EventArgs e)
    {
        hfSaleOrderDeptShiftUpdateStatus.Value = "CHECKED";

        switch (hfSaleOrderDeptShiftUpdateOrDelete.Value)
        {
            case "DELETE":
                {
                    var objSales = new BL.Sales();
                    var ds = objSales.SaleOrderDeploymentShiftsDelete(hfSaleOrderDeptShiftAutoIdForDelete.Value);
                    FillgvPattren();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    }
                }
                break;
            case "UPDATE":
                RowUpdating();
                gvPattren.EditIndex = -1;
                FillgvPattren();
                break;
        }

        mdlPopup.Hide();
    }
    /// <summary>
    /// Handles the onClick event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_onClick(object sender, EventArgs e)
    {
        if (hfSaleOrderDeptShiftUpdateOrDelete.Value == "UPDATE")
        {
            gvPattren.EditIndex = -1;
            FillgvPattren();
        }

        mdlPopup.Hide();
    }


    #region Grid View Events

    /// <summary>
    /// Changes the color of the text box.
    /// </summary>
    /// <param name="txtFrom">The text from.</param>
    /// <param name="txtTo">The text to.</param>
    private void ChangeTextBoxColor(TextBox txtFrom, TextBox txtTo)
    {
        if (Master != null)
        {
            var toolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            toolkitScriptManager2.SetFocus(txtFrom);
        }
        txtFrom.BackColor = System.Drawing.Color.Aqua;
        txtTo.BackColor = System.Drawing.Color.Aqua;
    }
    /// <summary>
    /// Handles the RowCommand event of the gvShiftBreak control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvShiftBreak_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CopyTime")
        {
            var TxtMonTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtMonTimeFrom");
            var TxtMonTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtMonTimeTo");
            var TxtTueTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtTueTimeFrom");
            var TxtTueTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtTueTimeTo");
            var TxtWedTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtWedTimeFrom");
            var TxtWedTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtWedTimeTo");
            var TxtThuTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtThuTimeFrom");
            var TxtThuTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtThuTimeTo");
            var TxtFriTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtFriTimeFrom");
            var TxtFriTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtFriTimeTo");
            var TxtSatTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtSatTimeFrom");
            var TxtSatTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtSatTimeTo");
            var TxtSunTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtSunTimeFrom");
            var TxtSunTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtSunTimeTo");
            var TxtHolidayTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtHolidayTimeFrom");
            var TxtHolidayTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtHolidayTimeTo");
         
            TxtMonTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtMonTimeTo.Text = TxtSunTimeTo.Text;

            TxtTueTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtTueTimeTo.Text = TxtSunTimeTo.Text;

            TxtWedTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtWedTimeTo.Text = TxtSunTimeTo.Text;

            TxtThuTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtThuTimeTo.Text = TxtSunTimeTo.Text;

            TxtFriTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtFriTimeTo.Text = TxtSunTimeTo.Text;

            TxtSatTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtSatTimeTo.Text = TxtSunTimeTo.Text;

            TxtHolidayTimeFrom.Text = TxtSunTimeFrom.Text;
            TxtHolidayTimeTo.Text = TxtSunTimeTo.Text;
        }
        if (e.CommandName == "AddNew")
        {
            var objSales = new BL.Sales();

            var TxtMonTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtMonTimeFrom");
            var TxtMonTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtMonTimeTo");
            var TxtTueTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtTueTimeFrom");
            var TxtTueTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtTueTimeTo");
            var TxtWedTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtWedTimeFrom");
            var TxtWedTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtWedTimeTo");
            var TxtThuTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtThuTimeFrom");
            var TxtThuTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtThuTimeTo");
            var TxtFriTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtFriTimeFrom");
            var TxtFriTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtFriTimeTo");
            var TxtSatTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtSatTimeFrom");
            var TxtSatTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtSatTimeTo");
            var TxtSunTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtSunTimeFrom");
            var TxtSunTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtSunTimeTo");
            var TxtHolidayTimeFrom = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtHolidayTimeFrom");
            var TxtHolidayTimeTo = (TextBox)gvShiftBreak.FooterRow.FindControl("TxtHolidayTimeTo");

            var cbBillable = (CheckBox)gvShiftBreak.FooterRow.FindControl("cbBillable");
            var cbPayable = (CheckBox)gvShiftBreak.FooterRow.FindControl("cbPayable");

            var ltrBreakSunday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakSunday");
            var ltrBreakMonday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakMonday");
            var ltrBreakTuesday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakTuesday");
            var ltrBreakWednesday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakWednesday");
            var ltrBreakThursday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakThursday");
            var ltrBreakFriday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakFriday");
            var ltrBreakSaturday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakSaturday");
            var ltrBreakHoliday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakHoliday");


            var breakSundayMin = ltrBreakSunday.Text.Replace("(", string.Empty);
            breakSundayMin = breakSundayMin.Replace(")", string.Empty);
           
            var breakMondayMin = ltrBreakMonday.Text.Replace("(", string.Empty);
            breakMondayMin = breakMondayMin.Replace(")", string.Empty);
            var breakTuesdayMin = ltrBreakTuesday.Text.Replace("(", string.Empty);
            breakTuesdayMin = breakTuesdayMin.Replace(")", string.Empty);
            var breakWednesdayMin = ltrBreakWednesday.Text.Replace("(", string.Empty);
            breakWednesdayMin = breakWednesdayMin.Replace(")", string.Empty);
            var breakThursdayMin = ltrBreakThursday.Text.Replace("(", string.Empty);
            breakThursdayMin = breakThursdayMin.Replace(")", string.Empty);
            var breakFridayMin = ltrBreakFriday.Text.Replace("(", string.Empty);
            breakFridayMin = breakFridayMin.Replace(")", string.Empty);
            var breakSaturdayMin = ltrBreakSaturday.Text.Replace("(", string.Empty);
            breakSaturdayMin = breakSaturdayMin.Replace(")", string.Empty);
            var breakHolidayMin = ltrBreakHoliday.Text.Replace("(", string.Empty);
            breakHolidayMin = breakHolidayMin.Replace(")", string.Empty);

            if (breakSundayMin == string.Empty)
            {
                breakSundayMin = "0";
            }

            if (breakMondayMin == string.Empty)
            {
                breakMondayMin = "0";
            }

            if (breakTuesdayMin == string.Empty)
            {
                breakTuesdayMin = "0";
            }

            if (breakWednesdayMin == string.Empty)
            {
                breakWednesdayMin = "0";
            }

            if (breakThursdayMin == string.Empty)
            {
                breakThursdayMin = "0";
            }

            if (breakFridayMin == string.Empty)
            {
                breakFridayMin = "0";
            }

            if (breakSaturdayMin == string.Empty)
            {
                breakSaturdayMin = "0";
            }
            if (breakHolidayMin == string.Empty)
            {
                breakHolidayMin = "0";
            }

            ChangeTextBoxColorToEmpty(TxtSunTimeFrom, TxtSunTimeTo);
            ChangeTextBoxColorToEmpty(TxtMonTimeFrom, TxtMonTimeTo);
            ChangeTextBoxColorToEmpty(TxtTueTimeFrom, TxtTueTimeTo);
            ChangeTextBoxColorToEmpty(TxtWedTimeFrom, TxtWedTimeTo);
            ChangeTextBoxColorToEmpty(TxtThuTimeFrom, TxtThuTimeTo);
            ChangeTextBoxColorToEmpty(TxtFriTimeFrom, TxtFriTimeTo);
            ChangeTextBoxColorToEmpty(TxtSatTimeFrom, TxtSatTimeTo);
            ChangeTextBoxColorToEmpty(TxtHolidayTimeFrom, TxtHolidayTimeTo);


            if (TxtSunTimeFrom.Text == string.Empty && TxtSunTimeTo.Text == string.Empty &&
                TxtMonTimeFrom.Text == string.Empty && TxtMonTimeTo.Text == string.Empty &&
                TxtTueTimeFrom.Text == string.Empty && TxtTueTimeTo.Text == string.Empty &&
                TxtWedTimeFrom.Text == string.Empty && TxtWedTimeTo.Text == string.Empty &&
                TxtThuTimeFrom.Text == string.Empty && TxtThuTimeTo.Text == string.Empty &&
                TxtFriTimeFrom.Text == string.Empty && TxtFriTimeTo.Text == string.Empty &&
                TxtSatTimeFrom.Text == string.Empty && TxtSatTimeTo.Text == string.Empty &&
                TxtHolidayTimeFrom.Text == string.Empty && TxtHolidayTimeTo.Text == string.Empty
                )
            {
                return;
            }



            var invalidTimeFlag = 0;

            if (TxtSunTimeFrom.Text != string.Empty)
            {
                if (!CheckValidBreak(TxtSunTimeFrom.Text, TxtSunTimeTo.Text, HFDeptSunTimeFrom.Value, HFDeptSunTimeTo.Value, "ADD", string.Empty, string.Empty))
                {
                    ChangeTextBoxColor(TxtSunTimeFrom, TxtSunTimeTo);
                    invalidTimeFlag = 1;
                }
                else
                {
                    for (int i = 0; i < gvShiftBreak.Rows.Count; i++)
                    {
                        var sunTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblSunTimeFrom");
                        var sunTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblSunTimeTo");
                        var HFSunTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptSunTimeFrom");
                        var HFSunTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptSunTimeTo");

                        if (sunTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtSunTimeFrom.Text, TxtSunTimeTo.Text, HFSunTimeFrom.Value, HFSunTimeTo.Value, "LoopAdd", sunTimeFrom.Text, sunTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtSunTimeFrom, TxtSunTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (TxtSunTimeTo.Text != string.Empty)
                {
                    ChangeTextBoxColor(TxtSunTimeFrom, TxtSunTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (TxtMonTimeFrom.Text != string.Empty)
            {
                if (!CheckValidBreak(TxtMonTimeFrom.Text, TxtMonTimeTo.Text, HFDeptMonTimeFrom.Value, HFDeptMonTimeTo.Value, "ADD", string.Empty, string.Empty))
                {
                    ChangeTextBoxColor(TxtMonTimeFrom, TxtMonTimeTo);
                    invalidTimeFlag = 1;
                }
                else
                {
                    for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                    {
                        var monTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblMonTimeFrom");
                        var monTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblMonTimeTo");
                        var HFMonTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptMonTimeFrom");
                        var HFMonTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptMonTimeTo");
                        if (monTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtMonTimeFrom.Text, TxtMonTimeTo.Text, HFMonTimeFrom.Value, HFMonTimeTo.Value, "LoopAdd", monTimeFrom.Text, monTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtMonTimeFrom, TxtMonTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }

                    }
                }
            }
            else
            {
                if (TxtMonTimeTo.Text != string.Empty)
                {
                    ChangeTextBoxColor(TxtMonTimeFrom, TxtMonTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (TxtTueTimeFrom.Text != string.Empty)
            {
                if (!CheckValidBreak(TxtTueTimeFrom.Text, TxtTueTimeTo.Text, HFDeptTueTimeFrom.Value, HFDeptTueTimeTo.Value, "ADD", string.Empty, string.Empty))
                {
                    ChangeTextBoxColor(TxtTueTimeFrom, TxtTueTimeTo);
                    invalidTimeFlag = 1;
                }
                else
                {
                    for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                    {
                        var tueTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblTueTimeFrom");
                        var tueTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblTueTimeTo");
                        var HFTueTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptTueTimeFrom");
                        var HFTueTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptTueTimeTo");
                        if (tueTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtTueTimeFrom.Text, TxtTueTimeTo.Text, HFTueTimeFrom.Value, HFTueTimeTo.Value, "LoopAdd", tueTimeFrom.Text, tueTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtTueTimeFrom, TxtTueTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (TxtTueTimeTo.Text != string.Empty)
                {
                    ChangeTextBoxColor(TxtTueTimeFrom, TxtTueTimeTo);
                    invalidTimeFlag = 1;
                }
            }

            if (TxtWedTimeFrom.Text != string.Empty)
            {
                if (!CheckValidBreak(TxtWedTimeFrom.Text, TxtWedTimeTo.Text, HFDeptWedTimeFrom.Value, HFDeptWedTimeTo.Value, "ADD", string.Empty, string.Empty))
                {
                    ChangeTextBoxColor(TxtWedTimeFrom, TxtWedTimeTo);
                    invalidTimeFlag = 1;
                }
                else
                {
                    for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                    {
                        var wedTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblWedTimeFrom");
                        var wedTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblWedTimeTo");
                        var HFWedTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptWedTimeFrom");
                        var HFWedTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptWedTimeTo");
                        if (wedTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtWedTimeFrom.Text, TxtWedTimeTo.Text, HFWedTimeFrom.Value, HFWedTimeTo.Value, "LoopAdd", wedTimeFrom.Text, wedTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtWedTimeFrom, TxtWedTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (TxtWedTimeTo.Text != string.Empty)
                {
                    ChangeTextBoxColor(TxtWedTimeFrom, TxtWedTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (TxtThuTimeFrom.Text != string.Empty)
            {
                if (!CheckValidBreak(TxtThuTimeFrom.Text, TxtThuTimeTo.Text, HFDeptThuTimeFrom.Value, HFDeptThuTimeTo.Value, "ADD", string.Empty, string.Empty))
                {
                    ChangeTextBoxColor(TxtThuTimeFrom, TxtThuTimeTo);
                    invalidTimeFlag = 1;
                }
                else
                {
                    for (int i = 0; i < gvShiftBreak.Rows.Count; i++)
                    {
                        var thuTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblThuTimeFrom");
                        var thuTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblThuTimeTo");
                        var HFThuTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptThuTimeFrom");
                        var HFThuTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptThuTimeTo");
                        if (thuTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtThuTimeFrom.Text, TxtThuTimeTo.Text, HFThuTimeFrom.Value, HFThuTimeTo.Value, "LoopAdd", thuTimeFrom.Text, thuTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtThuTimeFrom, TxtThuTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (TxtThuTimeTo.Text != string.Empty)
                {
                    ChangeTextBoxColor(TxtThuTimeFrom, TxtThuTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (TxtFriTimeFrom.Text != string.Empty)
            {
                if (!CheckValidBreak(TxtFriTimeFrom.Text, TxtFriTimeTo.Text, HFDeptFriTimeFrom.Value, HFDeptFriTimeTo.Value, "ADD", string.Empty, string.Empty))
                {
                    ChangeTextBoxColor(TxtFriTimeFrom, TxtFriTimeTo);
                    invalidTimeFlag = 1;
                }
                else
                {
                    for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                    {
                        var friTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblFriTimeFrom");
                        var friTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblFriTimeTo");
                        var HFFriTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptFriTimeFrom");
                        var HFFriTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptFriTimeTo");
                        if (friTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtFriTimeFrom.Text, TxtFriTimeTo.Text, HFFriTimeFrom.Value, HFFriTimeTo.Value, "LoopAdd", friTimeFrom.Text, friTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtFriTimeFrom, TxtFriTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (TxtFriTimeTo.Text != string.Empty)
                {
                    ChangeTextBoxColor(TxtFriTimeFrom, TxtFriTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (TxtSatTimeFrom.Text != string.Empty)
            {
                if (!CheckValidBreak(TxtSatTimeFrom.Text, TxtSatTimeTo.Text, HFDeptSatTimeFrom.Value, HFDeptSatTimeTo.Value, "ADD", string.Empty, string.Empty))
                {
                    ChangeTextBoxColor(TxtSatTimeFrom, TxtSatTimeTo);
                    invalidTimeFlag = 1;
                }
                else
                {
                    for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                    {
                        var satTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblSatTimeFrom");
                        var satTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblSatTimeTo");
                        var HFSatTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptSatTimeFrom");
                        var HFSatTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptSatTimeTo");
                        if (satTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtSatTimeFrom.Text, TxtSatTimeTo.Text, HFSatTimeFrom.Value, HFSatTimeTo.Value, "LoopAdd", satTimeFrom.Text, satTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtSatTimeFrom, TxtSatTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (TxtSatTimeTo.Text != string.Empty)
                {
                    ChangeTextBoxColor(TxtSatTimeFrom, TxtSatTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (TxtHolidayTimeFrom.Text != string.Empty)
            {
                if (!CheckValidBreak(TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text, HFDeptHolidayTimeFrom.Value, HFDeptHolidayTimeTo.Value, "ADD", string.Empty, string.Empty))
                {
                    ChangeTextBoxColor(TxtHolidayTimeFrom, TxtHolidayTimeTo);
                    invalidTimeFlag = 1;
                }
                else
                {
                    for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                    {
                        var HolidayTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblHolidayTimeFrom");
                        var HolidayTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblHolidayTimeTo");
                        var HFHolidayTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptHolidayTimeFrom");
                        var HFHolidayTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptHolidayTimeTo");
                        if (HolidayTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text, HFHolidayTimeFrom.Value, HFHolidayTimeTo.Value, "LoopAdd", HolidayTimeFrom.Text, HolidayTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtHolidayTimeFrom, TxtHolidayTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (TxtHolidayTimeTo.Text != string.Empty)
                {
                    ChangeTextBoxColor(TxtHolidayTimeFrom, TxtHolidayTimeTo);
                    invalidTimeFlag = 1;
                }
            }

            if (invalidTimeFlag == 0)
            {
                DataSet dsBreak;
                if (TxtSunTimeTo.Text != string.Empty && TxtSunTimeFrom.Text != string.Empty)
                {
                    dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtSunTimeFrom.Text, TxtSunTimeTo.Text,
                    breakSundayMin, "SUN", "0"
                    );

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {
                        ChangeTextBoxColor(TxtSunTimeFrom, TxtSunTimeTo);
                        invalidTimeFlag = 1;
                    }
                }

                if (TxtMonTimeTo.Text != string.Empty && TxtMonTimeFrom.Text != string.Empty)
                {
                    dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtMonTimeFrom.Text, TxtMonTimeTo.Text,
                    breakMondayMin, "MON", "0"
                    );

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {
                        ChangeTextBoxColor(TxtMonTimeFrom, TxtMonTimeTo);
                        invalidTimeFlag = 1;
                    }
                }

                if (TxtTueTimeTo.Text != string.Empty && TxtTueTimeFrom.Text != string.Empty)
                {
                    dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtTueTimeFrom.Text, TxtTueTimeTo.Text,
                    breakTuesdayMin, "TUE", "0"
                    );

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {

                        ChangeTextBoxColor(TxtTueTimeFrom, TxtTueTimeTo);
                        invalidTimeFlag = 1;
                    }
                }

                if (TxtWedTimeTo.Text != string.Empty && TxtWedTimeFrom.Text != string.Empty)
                {
                    dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtWedTimeFrom.Text, TxtWedTimeTo.Text,
                    breakWednesdayMin, "WED", "0"
                    );

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {
                        ChangeTextBoxColor(TxtWedTimeFrom, TxtWedTimeTo);
                        invalidTimeFlag = 1;
                    }
                }

                if (TxtThuTimeTo.Text != string.Empty && TxtThuTimeFrom.Text != string.Empty)
                {
                    dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtThuTimeFrom.Text, TxtThuTimeTo.Text,
                    breakThursdayMin, "THU", "0"
                    );

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {
                        ChangeTextBoxColor(TxtThuTimeFrom, TxtThuTimeTo);
                        invalidTimeFlag = 1;
                    }
                }

                if (TxtFriTimeTo.Text != string.Empty && TxtFriTimeFrom.Text != string.Empty)
                {
                    dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtFriTimeFrom.Text, TxtFriTimeTo.Text,
                   breakFridayMin, "FRI", "0"
                    );

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {
                        ChangeTextBoxColor(TxtFriTimeFrom, TxtFriTimeTo);
                        invalidTimeFlag = 1;
                    }
                   
                }

                if (TxtSatTimeTo.Text != string.Empty && TxtSatTimeFrom.Text != string.Empty)
                {
                    dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtSatTimeFrom.Text, TxtSatTimeTo.Text,
                    breakSaturdayMin, "SAT", "0"
                    );

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {
                        ChangeTextBoxColor(TxtSatTimeFrom, TxtSatTimeTo);
                        invalidTimeFlag = 1;
                    }
                }

                if (TxtHolidayTimeTo.Text != string.Empty && TxtHolidayTimeFrom.Text != string.Empty)
                {
                    dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text,
                    breakHolidayMin, "Holiday", "0"
                    );

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {
                        ChangeTextBoxColor(TxtHolidayTimeFrom, TxtHolidayTimeTo);
                        invalidTimeFlag = 1;
                    }
                }

                if (invalidTimeFlag == 0)
                {
                    DataSet ds = objSales.SaleOrderDeploymentShiftsBreakInsert(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                        HFShiftCode.Value,
                        TxtMonTimeFrom.Text, TxtMonTimeTo.Text,
                        TxtTueTimeFrom.Text, TxtTueTimeTo.Text,
                        TxtWedTimeFrom.Text, TxtWedTimeTo.Text,
                        TxtThuTimeFrom.Text, TxtThuTimeTo.Text,
                        TxtFriTimeFrom.Text, TxtFriTimeTo.Text,
                        TxtSatTimeFrom.Text, TxtSatTimeTo.Text,
                        TxtSunTimeFrom.Text, TxtSunTimeTo.Text,
                        TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text,
                        BaseUserID, cbBillable.Checked.ToString(), cbPayable.Checked.ToString()
                        );
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    FillgvShiftBreak();
                }
            }
        }
    }

    /// <summary>
    /// Checks the valid break.
    /// </summary>
    /// <param name="txtFromTime">The text from time.</param>
    /// <param name="txtToTime">The text to time.</param>
    /// <param name="hfDeptTimeFrom">The hf dept time from.</param>
    /// <param name="hfDeptToTime">The hf dept to time.</param>
    /// <param name="status">The status.</param>
    /// <param name="lblTimeFrom">The label time from.</param>
    /// <param name="lblToTime">The label to time.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckValidBreak(string txtFromTime, string txtToTime, string hfDeptTimeFrom, string hfDeptToTime, string status, string lblTimeFrom, string lblToTime)
    {
        string strFromTime;
        string strToTime;
        string strDeptTimeFrom;
        string strDeptTimeTo;
        if (txtFromTime != string.Empty)
        {
            strFromTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtFromTime).ToString("HH:mm");
        }
        else
        {
            return false;
        }
        if (txtToTime != string.Empty)
        {
            strToTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtToTime).ToString("HH:mm");
        }
        else
        {
            return false;
        }

        if (hfDeptTimeFrom != string.Empty)
        {
            strDeptTimeFrom = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(hfDeptTimeFrom).ToString("HH:mm");
        }
        else
        {
            return false;
        }
        if (hfDeptToTime != string.Empty)
        {
            strDeptTimeTo = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(hfDeptToTime).ToString("HH:mm");
        }
        else
        {
            return false;
        }

        if (strToTime == strFromTime)
        {
            return false;
        }

        string strlblFromTime;
        string strlblToTime;
        if (lblTimeFrom == string.Empty && lblToTime == string.Empty)
        {
            strlblFromTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + "00:00";
            strlblToTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + "00:00";
        }
        else
        {
            strlblFromTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(lblTimeFrom).ToString("HH:mm");
            strlblToTime = DateTime.Now.ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(lblToTime).ToString("HH:mm");
        }

        if (status.ToLower() == "ShiftBreak".ToLower())
        {
            if (Convert.ToDateTime(DateTime.Parse(strFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strToTime).ToString("HH:mm")))
            {
                {
                    strToTime = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtToTime).ToString("HH:mm");
                }
            }
        }

        if (status.ToLower() != "ShiftBreak".ToLower())
        {
            if (Convert.ToDateTime(DateTime.Parse(strDeptTimeFrom).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strFromTime).ToString("HH:mm")))
            {
                {
                    strFromTime = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtFromTime).ToString("HH:mm");
                }
            }
            if (Convert.ToDateTime(DateTime.Parse(strFromTime).ToString("dd-MMMM-yyyy")) > Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy")))
            {
                strToTime = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtToTime).ToString("HH:mm");
            }
            else
            {
                if (Convert.ToDateTime(DateTime.Parse(strFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strToTime).ToString("HH:mm")))
                {
                    {
                        strToTime = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtToTime).ToString("HH:mm");
                    }
                }
            }
        }

        if (status.ToLower() == "ADD".ToLower())
        {
            if (Convert.ToDateTime(DateTime.Parse(strDeptTimeFrom).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strDeptTimeTo).ToString("HH:mm")))
            {
                strDeptTimeTo = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + DateTime.Parse(hfDeptToTime).ToString("HH:mm");

            }
        }
        else 
        {
            if (Convert.ToDateTime(DateTime.Parse(strDeptTimeFrom).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strlblFromTime).ToString("HH:mm")))
            {
                
                    strDeptTimeFrom = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(lblTimeFrom).ToString("HH:mm");
                
            }
            else
            {
                strDeptTimeFrom = strlblFromTime;
            }
            if (Convert.ToDateTime(DateTime.Parse(strDeptTimeFrom).ToString("dd-MMMM-yyyy")) > Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy")))
            {
                strDeptTimeTo = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(lblToTime).ToString("HH:mm");
            }
            else
            {
                if (Convert.ToDateTime(DateTime.Parse(strlblFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strlblToTime).ToString("HH:mm")))
                {
                    {
                        strDeptTimeTo = DateTime.Parse(DateTime.Now.ToString("dd-MMMM-yyyy")).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(lblToTime).ToString("HH:mm");
                    }
                }
                else
                {
                    strDeptTimeTo = strlblToTime;
                }
            }
        }
       
        if (status.ToLower() == "ADD".ToLower())
        {
            return DateTime.Parse(strFromTime) >= DateTime.Parse(strDeptTimeFrom) &&
                   DateTime.Parse(strToTime) <= DateTime.Parse(strDeptTimeTo) &&
                   DateTime.Parse(strFromTime) <= DateTime.Parse(strDeptTimeTo) &&
                   DateTime.Parse(strToTime) >= DateTime.Parse(strDeptTimeFrom);
        }
        if (status.ToLower() == "loopadd")
        {
            if (DateTime.Parse(strFromTime) >= DateTime.Parse(strDeptTimeFrom) &&
                DateTime.Parse(strFromTime) <= DateTime.Parse(strDeptTimeTo)
                )
            {
                return true;
            }

            if (DateTime.Parse(strToTime) >= DateTime.Parse(strDeptTimeFrom) &&
                DateTime.Parse(strToTime) <= DateTime.Parse(strDeptTimeTo)
                )
            {
                return true;
            }

            return DateTime.Parse(strDeptTimeFrom) >= DateTime.Parse(strFromTime) &&
                   DateTime.Parse(strDeptTimeTo) <= DateTime.Parse(strToTime);
        }
        return DateTime.Parse(strDeptTimeFrom) >= DateTime.Parse(strFromTime) &&
               DateTime.Parse(strDeptTimeTo) <= DateTime.Parse(strToTime) &&
               DateTime.Parse(strDeptTimeTo) >= DateTime.Parse(strFromTime) &&
               DateTime.Parse(strDeptTimeFrom) <= DateTime.Parse(strToTime);
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvShiftBreak control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvShiftBreak_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
            var ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
            if (ImgbtnEdit != null)
            {
                ImgbtnEdit.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                if (!IsModifyAccess)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            if (ImgbtnDelete != null)
            {
                ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                if (!IsDeleteAccess)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            if (IsDeleteAccess == false && IsModifyAccess == false)
            {
                gvShiftBreak.Columns[0].Visible = false;
            }


            var TxtMonTimeFrom = (TextBox)e.Row.FindControl("TxtEditMonTimeFrom");
            var TxtMonTimeTo = (TextBox)e.Row.FindControl("TxtEditMonTimeTo");
            var TxtTueTimeFrom = (TextBox)e.Row.FindControl("TxtEditTueTimeFrom");
            var TxtTueTimeTo = (TextBox)e.Row.FindControl("TxtEditTueTimeTo");
            var TxtWedTimeFrom = (TextBox)e.Row.FindControl("TxtEditWedTimeFrom");
            var TxtWedTimeTo = (TextBox)e.Row.FindControl("TxtEditWedTimeTo");
            var TxtThuTimeFrom = (TextBox)e.Row.FindControl("TxtEditThuTimeFrom");
            var TxtThuTimeTo = (TextBox)e.Row.FindControl("TxtEditThuTimeTo");
            var TxtFriTimeFrom = (TextBox)e.Row.FindControl("TxtEditFriTimeFrom");
            var TxtFriTimeTo = (TextBox)e.Row.FindControl("TxtEditFriTimeTo");
            var TxtSatTimeFrom = (TextBox)e.Row.FindControl("TxtEditSatTimeFrom");
            var TxtSatTimeTo = (TextBox)e.Row.FindControl("TxtEditSatTimeTo");
            var TxtSunTimeFrom = (TextBox)e.Row.FindControl("TxtEditSunTimeFrom");
            var TxtSunTimeTo = (TextBox)e.Row.FindControl("TxtEditSunTimeTo");
            var TxtHolidayTimeFrom = (TextBox)e.Row.FindControl("TxtEditHolidayTimeFrom");
            var TxtHolidayTimeTo = (TextBox)e.Row.FindControl("TxtEditHolidayTimeTo");

            var lblMonTimeFrom = (Label)e.Row.FindControl("lblMonTimeFrom");
            var lblMonTimeTo = (Label)e.Row.FindControl("lblMonTimeTo");
            var lblTueTimeFrom = (Label)e.Row.FindControl("lblTueTimeFrom");
            var lblTueTimeTo = (Label)e.Row.FindControl("lblTueTimeTo");
            var lblWedTimeFrom = (Label)e.Row.FindControl("lblWedTimeFrom");
            var lblWedTimeTo = (Label)e.Row.FindControl("lblWedTimeTo");
            var lblThuTimeFrom = (Label)e.Row.FindControl("lblThuTimeFrom");
            var lblThuTimeTo = (Label)e.Row.FindControl("lblThuTimeTo");
            var lblFriTimeFrom = (Label)e.Row.FindControl("lblFriTimeFrom");
            var lblFriTimeTo = (Label)e.Row.FindControl("lblFriTimeTo");
            var lblSatTimeFrom = (Label)e.Row.FindControl("lblSatTimeFrom");
            var lblSatTimeTo = (Label)e.Row.FindControl("lblSatTimeTo");
            var lblSunTimeFrom = (Label)e.Row.FindControl("lblSunTimeFrom");
            var lblSunTimeTo = (Label)e.Row.FindControl("lblSunTimeTo");
            var lblHolidayTimeFrom = (Label)e.Row.FindControl("lblHolidayTimeFrom");
            var lblHolidayTimeTo = (Label)e.Row.FindControl("lblHolidayTimeTo");
            var lblSunTo = (Label)e.Row.FindControl("lblSunTo");
            var lblMonTo = (Label)e.Row.FindControl("lblMonTo");
            var lblTueTo = (Label)e.Row.FindControl("lblTueTo");
            var lblWedTo = (Label)e.Row.FindControl("lblWedTo");
            var lblThuTo = (Label)e.Row.FindControl("lblThuTo");
            var lblFriTo = (Label)e.Row.FindControl("lblFriTo");
            var lblSatTo = (Label)e.Row.FindControl("lblSatTo");
            var lblHolidayTo = (Label)e.Row.FindControl("lblHolidayTo");
            
            if (TxtMonTimeFrom != null)
            {
                if (TxtMonTimeFrom.Text == @"00:00" && TxtMonTimeTo.Text == @"00:00")
                {
                    TxtMonTimeFrom.Text = string.Empty;
                    TxtMonTimeTo.Text = string.Empty;
                }
            }
            if (TxtTueTimeFrom != null)
            {
                if (TxtTueTimeFrom.Text == @"00:00" && TxtTueTimeTo.Text == @"00:00")
                {
                    TxtTueTimeFrom.Text = string.Empty;
                    TxtTueTimeTo.Text = string.Empty;
                }
            }
            if (TxtWedTimeFrom != null)
            {
                if (TxtWedTimeFrom.Text == @"00:00" && TxtWedTimeTo.Text == @"00:00")
                {
                    TxtWedTimeFrom.Text = string.Empty;
                    TxtWedTimeTo.Text = string.Empty;
                }
            }
            if (TxtThuTimeFrom != null)
            {
                if (TxtThuTimeFrom.Text == @"00:00" && TxtThuTimeTo.Text == @"00:00")
                {
                    TxtThuTimeFrom.Text = string.Empty;
                    TxtThuTimeTo.Text = string.Empty;
                }
            }
            if (TxtFriTimeFrom != null)
            {
                if (TxtFriTimeFrom.Text == @"00:00" && TxtFriTimeTo.Text == @"00:00")
                {
                    TxtFriTimeFrom.Text = string.Empty;
                    TxtFriTimeTo.Text = string.Empty;
                }
            }
            if (TxtSatTimeFrom != null)
            {
                if (TxtSatTimeFrom.Text == @"00:00" && TxtSatTimeTo.Text == @"00:00")
                {
                    TxtSatTimeFrom.Text = string.Empty;
                    TxtSatTimeTo.Text = string.Empty;
                }
            }
            if (TxtSunTimeFrom != null)
            {
                if (TxtSunTimeFrom.Text == @"00:00" && TxtSunTimeTo.Text == @"00:00")
                {
                    TxtSunTimeFrom.Text = string.Empty;
                    TxtSunTimeTo.Text = string.Empty;
                }
            }
            if (TxtHolidayTimeFrom != null && TxtHolidayTimeTo != null)
            {
                if (TxtHolidayTimeFrom.Text == @"00:00" && TxtHolidayTimeTo.Text == @"00:00")
                {
                    TxtHolidayTimeFrom.Text = string.Empty;
                    TxtHolidayTimeTo.Text = string.Empty;
                }
            }

            if (lblMonTimeFrom != null)
            {
                MakeTimeNull(lblMonTimeFrom, lblMonTimeTo, lblMonTo);
            }
            if (lblTueTimeFrom != null)
            {
                MakeTimeNull(lblTueTimeFrom, lblTueTimeTo, lblTueTo);
            }
            if (lblWedTimeFrom != null)
            {
                MakeTimeNull(lblWedTimeFrom, lblWedTimeTo, lblWedTo);
            }
            if (lblThuTimeFrom != null)
            {
                MakeTimeNull(lblThuTimeFrom, lblThuTimeTo, lblThuTo);
            }
            if (lblFriTimeFrom != null)
            {
                MakeTimeNull(lblFriTimeFrom, lblFriTimeTo, lblFriTo);
            }
            if (lblSatTimeFrom != null)
            {
                MakeTimeNull(lblSatTimeFrom, lblSatTimeTo, lblSatTo);
            }
            if (lblSunTimeFrom != null)
            {
                MakeTimeNull(lblSunTimeFrom, lblSunTimeTo, lblSunTo);
            }
            if (lblHolidayTimeFrom != null && lblHolidayTimeTo != null && lblHolidayTo != null)
            {
                MakeTimeNull(lblHolidayTimeFrom, lblHolidayTimeTo, lblHolidayTo);
            }
            var lblShift = (Label)e.Row.FindControl("lblShift");
            if (lblShift != null)
            {
                lblShift.Text = HFShiftCode.Value;
            }

            SetTimeValidationToTextBox(TxtMonTimeFrom);
            SetTimeValidationToTextBox(TxtMonTimeTo);

            SetTimeValidationToTextBox(TxtTueTimeFrom);
            SetTimeValidationToTextBox(TxtTueTimeTo);

            SetTimeValidationToTextBox(TxtWedTimeFrom);
            SetTimeValidationToTextBox(TxtWedTimeTo);

            SetTimeValidationToTextBox(TxtThuTimeFrom);
            SetTimeValidationToTextBox(TxtThuTimeTo);

            SetTimeValidationToTextBox(TxtFriTimeFrom);
            SetTimeValidationToTextBox(TxtFriTimeTo);

            SetTimeValidationToTextBox(TxtSatTimeFrom);
            SetTimeValidationToTextBox(TxtSatTimeTo);

            SetTimeValidationToTextBox(TxtSunTimeFrom);
            SetTimeValidationToTextBox(TxtSunTimeTo);

            SetTimeValidationToTextBox(TxtHolidayTimeFrom);
            SetTimeValidationToTextBox(TxtHolidayTimeTo);

            if (hiddenFieldHolidayDept.Value != "1")
            {
                gvShiftBreak.Columns[10].Visible = false;
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            var ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
            if (ImgbtnAdd != null)
            {
                ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
            }
            if (IsWriteAccess == false)
            {
                gvShiftBreak.ShowFooter = false;
            }

            var lblShift = (Label)e.Row.FindControl("lblShift");
            if (lblShift != null)
            {
                lblShift.Text = HFShiftCode.Value;
            }
            var TxtMonTimeFrom = (TextBox)e.Row.FindControl("TxtMonTimeFrom");
            var TxtMonTimeTo = (TextBox)e.Row.FindControl("TxtMonTimeTo");
            var TxtTueTimeFrom = (TextBox)e.Row.FindControl("TxtTueTimeFrom");
            var TxtTueTimeTo = (TextBox)e.Row.FindControl("TxtTueTimeTo");
            var TxtWedTimeFrom = (TextBox)e.Row.FindControl("TxtWedTimeFrom");
            var TxtWedTimeTo = (TextBox)e.Row.FindControl("TxtWedTimeTo");
            var TxtThuTimeFrom = (TextBox)e.Row.FindControl("TxtThuTimeFrom");
            var TxtThuTimeTo = (TextBox)e.Row.FindControl("TxtThuTimeTo");
            var TxtFriTimeFrom = (TextBox)e.Row.FindControl("TxtFriTimeFrom");
            var TxtFriTimeTo = (TextBox)e.Row.FindControl("TxtFriTimeTo");
            var TxtSatTimeFrom = (TextBox)e.Row.FindControl("TxtSatTimeFrom");
            var TxtSatTimeTo = (TextBox)e.Row.FindControl("TxtSatTimeTo");
            var TxtSunTimeFrom = (TextBox)e.Row.FindControl("TxtSunTimeFrom");
            var TxtSunTimeTo = (TextBox)e.Row.FindControl("TxtSunTimeTo");
            var TxtHolidayTimeFrom = (TextBox)e.Row.FindControl("TxtHolidayTimeFrom");
            var TxtHolidayTimeTo = (TextBox)e.Row.FindControl("TxtHolidayTimeTo");
            
            SetTimeValidationToTextBox(TxtMonTimeFrom);
            SetTimeValidationToTextBox(TxtMonTimeTo);

            SetTimeValidationToTextBox(TxtTueTimeFrom);
            SetTimeValidationToTextBox(TxtTueTimeTo);

            SetTimeValidationToTextBox(TxtWedTimeFrom);
            SetTimeValidationToTextBox(TxtWedTimeTo);

            SetTimeValidationToTextBox(TxtThuTimeFrom);
            SetTimeValidationToTextBox(TxtThuTimeTo);

            SetTimeValidationToTextBox(TxtFriTimeFrom);
            SetTimeValidationToTextBox(TxtFriTimeTo);

            SetTimeValidationToTextBox(TxtSatTimeFrom);
            SetTimeValidationToTextBox(TxtSatTimeTo);

            SetTimeValidationToTextBox(TxtSunTimeFrom);
            SetTimeValidationToTextBox(TxtSunTimeTo);

            SetTimeValidationToTextBox(TxtHolidayTimeFrom);
            SetTimeValidationToTextBox(TxtHolidayTimeTo);
        }
    }

    /// <summary>
    /// Makes the time null.
    /// </summary>
    /// <param name="fromTime">From time.</param>
    /// <param name="toTime">To time.</param>
    /// <param name="lblTo">The label to.</param>
    private void MakeTimeNull(Label fromTime, Label toTime, Label lblTo)
    {
        if (toTime.Text == @"00:00" && fromTime.Text == @"00:00")
        {
            fromTime.Text = string.Empty;
            toTime.Text = string.Empty;
            lblTo.Text = string.Empty;
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the gvShiftBreak control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvShiftBreak_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvShiftBreak.EditIndex = e.NewEditIndex;
        FillgvShiftBreak();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvShiftBreak control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvShiftBreak_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvShiftBreak.EditIndex = -1;
        FillgvShiftBreak();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvShiftBreak control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvShiftBreak_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var HFBreakLineNo = (HiddenField)gvShiftBreak.Rows[e.RowIndex].FindControl("HFBreakLineNo");
        var objSales = new BL.Sales();
        DataSet ds = objSales.SaleOrderDeploymentShiftsBreakDelete(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value, HFShiftCode.Value, HFBreakLineNo.Value);
        FillgvShiftBreak();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvShiftBreak control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvShiftBreak_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShiftBreak.PageIndex = e.NewPageIndex;
        gvShiftBreak.EditIndex = -1;
    }

    /// <summary>
    /// Changes the text box color to empty.
    /// </summary>
    /// <param name="txtFrom">The text from.</param>
    /// <param name="txtTo">The text to.</param>
    private void ChangeTextBoxColorToEmpty(TextBox txtFrom, TextBox txtTo)
    {
        txtFrom.BackColor = System.Drawing.Color.Empty;
        txtTo.BackColor = System.Drawing.Color.Empty;
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvShiftBreak control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvShiftBreak_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var ds = new DataSet();
        var objSales = new BL.Sales();

        var TxtMonTimeFrom = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditMonTimeFrom");
        var TxtMonTimeTo = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditMonTimeTo");
        var TxtTueTimeFrom = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditTueTimeFrom");
        var TxtTueTimeTo = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditTueTimeTo");
        var TxtWedTimeFrom = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditWedTimeFrom");
        var TxtWedTimeTo = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditWedTimeTo");
        var TxtThuTimeFrom = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditThuTimeFrom");
        var TxtThuTimeTo = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditThuTimeTo");
        var TxtFriTimeFrom = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditFriTimeFrom");
        var TxtFriTimeTo = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditFriTimeTo");
        var TxtSatTimeFrom = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditSatTimeFrom");
        var TxtSatTimeTo = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditSatTimeTo");
        var TxtSunTimeFrom = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditSunTimeFrom");
        var TxtSunTimeTo = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditSunTimeTo");
        var TxtHolidayTimeFrom = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditHolidayTimeFrom");
        var TxtHolidayTimeTo = (TextBox)gvShiftBreak.Rows[e.RowIndex].FindControl("TxtEditHolidayTimeTo");
        var cbBillable = (CheckBox)gvShiftBreak.Rows[e.RowIndex].FindControl("cbBillable");
        var cbPayable = (CheckBox)gvShiftBreak.Rows[e.RowIndex].FindControl("cbPayable");
        var HFBreakLineNo = (HiddenField)gvShiftBreak.Rows[e.RowIndex].FindControl("HFBreakLineNo");

        var ltrBreakSunday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakSunday");
        var ltrBreakMonday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakMonday");
        var ltrBreakTuesday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakTuesday");
        var ltrBreakWednesday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakWednesday");
        var ltrBreakThursday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakThursday");
        var ltrBreakFriday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakFriday");
        var ltrBreakSaturday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakSaturday");
        var ltrBreakHoliday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakHoliday");

        var breakSundayMin = ltrBreakSunday.Text.Replace("(", string.Empty);
        breakSundayMin = breakSundayMin.Replace(")", string.Empty);
        var breakMondayMin = ltrBreakMonday.Text.Replace("(", string.Empty);
        breakMondayMin = breakMondayMin.Replace(")", string.Empty);
        var breakTuesdayMin = ltrBreakTuesday.Text.Replace("(", string.Empty);
        breakTuesdayMin = breakTuesdayMin.Replace(")", string.Empty);
        var breakWednesdayMin = ltrBreakWednesday.Text.Replace("(", string.Empty);
        breakWednesdayMin = breakWednesdayMin.Replace(")", string.Empty);
        var breakThursdayMin = ltrBreakThursday.Text.Replace("(", string.Empty);
        breakThursdayMin = breakThursdayMin.Replace(")", string.Empty);
        var breakFridayMin = ltrBreakFriday.Text.Replace("(", string.Empty);
        breakFridayMin = breakFridayMin.Replace(")", string.Empty);
        var breakSaturdayMin = ltrBreakSaturday.Text.Replace("(", string.Empty);
        breakSaturdayMin = breakSaturdayMin.Replace(")", string.Empty);
        var breakHolidayMin = ltrBreakHoliday.Text.Replace("(", string.Empty);
        breakHolidayMin = breakHolidayMin.Replace(")", string.Empty);

        if (breakSundayMin == string.Empty)
        {
            breakSundayMin = "0";
        }

        if (breakMondayMin == string.Empty)
        {
            breakMondayMin = "0";
        }

        if (breakTuesdayMin == string.Empty)
        {
            breakTuesdayMin = "0";
        }

        if (breakWednesdayMin == string.Empty)
        {
            breakWednesdayMin = "0";
        }

        if (breakThursdayMin == string.Empty)
        {
            breakThursdayMin = "0";
        }

        if (breakFridayMin == string.Empty)
        {
            breakFridayMin = "0";
        }

        if (breakSaturdayMin == string.Empty)
        {
            breakSaturdayMin = "0";
        }
        if (breakHolidayMin == string.Empty)
        {
            breakHolidayMin = "0";
        }
        ChangeTextBoxColorToEmpty(TxtSunTimeFrom, TxtSunTimeTo);
        ChangeTextBoxColorToEmpty(TxtMonTimeFrom, TxtMonTimeTo);
        ChangeTextBoxColorToEmpty(TxtTueTimeFrom, TxtTueTimeTo);
        ChangeTextBoxColorToEmpty(TxtWedTimeFrom, TxtWedTimeTo);
        ChangeTextBoxColorToEmpty(TxtThuTimeFrom, TxtThuTimeTo);
        ChangeTextBoxColorToEmpty(TxtFriTimeFrom, TxtFriTimeTo);
        ChangeTextBoxColorToEmpty(TxtSatTimeFrom, TxtSatTimeTo);
        ChangeTextBoxColorToEmpty(TxtHolidayTimeFrom, TxtHolidayTimeTo);

        var invalidTimeFlag = 0;

        if (TxtSunTimeFrom.Text != string.Empty)
        {
            if (!CheckValidBreak(TxtSunTimeFrom.Text, TxtSunTimeTo.Text, HFDeptSunTimeFrom.Value, HFDeptSunTimeTo.Value, "ADD", string.Empty, string.Empty))
            {
                ChangeTextBoxColor(TxtSunTimeFrom, TxtSunTimeTo);
                invalidTimeFlag = 1;
            }
            else
            {
                for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        var sunTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblSunTimeFrom");
                        var sunTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblSunTimeTo");
                        var HFSunTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptSunTimeFrom");
                        var HFSunTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptSunTimeTo");

                        if (sunTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtSunTimeFrom.Text, TxtSunTimeTo.Text, HFSunTimeFrom.Value, HFSunTimeTo.Value, "LoopAdd", sunTimeFrom.Text, sunTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtSunTimeFrom, TxtSunTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
        }
        if (TxtMonTimeFrom.Text != string.Empty)
        {
            if (!CheckValidBreak(TxtMonTimeFrom.Text, TxtMonTimeTo.Text, HFDeptMonTimeFrom.Value, HFDeptMonTimeTo.Value, "ADD", string.Empty, string.Empty))
            {
                ChangeTextBoxColor(TxtMonTimeFrom, TxtMonTimeTo);
                invalidTimeFlag = 1;
            }
            else
            {
                for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        var monTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblMonTimeFrom");
                        var monTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblMonTimeTo");
                        var HFMonTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptMonTimeFrom");
                        var HFMonTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptMonTimeTo");
                        if (monTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtMonTimeFrom.Text, TxtMonTimeTo.Text, HFMonTimeFrom.Value, HFMonTimeTo.Value, "LoopAdd", monTimeFrom.Text, monTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtMonTimeFrom, TxtMonTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }

                    }
                }
            }
        }
        if (TxtTueTimeFrom.Text != string.Empty)
        {
            if (!CheckValidBreak(TxtTueTimeFrom.Text, TxtTueTimeTo.Text, HFDeptTueTimeFrom.Value, HFDeptTueTimeTo.Value, "ADD", string.Empty, string.Empty))
            {
                ChangeTextBoxColor(TxtTueTimeFrom, TxtTueTimeTo);
                invalidTimeFlag = 1;
            }
            else
            {
                for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        var tueTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblTueTimeFrom");
                        var tueTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblTueTimeTo");
                        var HFTueTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptTueTimeFrom");
                        var HFTueTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptTueTimeTo");
                        if (tueTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtTueTimeFrom.Text, TxtTueTimeTo.Text, HFTueTimeFrom.Value, HFTueTimeTo.Value, "LoopAdd", tueTimeFrom.Text, tueTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtTueTimeFrom, TxtTueTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
        }
        if (TxtWedTimeFrom.Text != string.Empty)
        {
            if (!CheckValidBreak(TxtWedTimeFrom.Text, TxtWedTimeTo.Text, HFDeptWedTimeFrom.Value, HFDeptWedTimeTo.Value, "ADD", string.Empty, string.Empty))
            {
                ChangeTextBoxColor(TxtWedTimeFrom, TxtWedTimeTo);
                invalidTimeFlag = 1;
            }
            else
            {
                for (int i = 0; i < gvShiftBreak.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        var wedTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblWedTimeFrom");
                        var wedTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblWedTimeTo");
                        var HFWedTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptWedTimeFrom");
                        var HFWedTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptWedTimeTo");
                        if (wedTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtWedTimeFrom.Text, TxtWedTimeTo.Text, HFWedTimeFrom.Value, HFWedTimeTo.Value, "LoopAdd", wedTimeFrom.Text, wedTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtWedTimeFrom, TxtWedTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
        }
        if (TxtThuTimeFrom.Text != string.Empty)
        {
            if (!CheckValidBreak(TxtThuTimeFrom.Text, TxtThuTimeTo.Text, HFDeptThuTimeFrom.Value, HFDeptThuTimeTo.Value, "ADD", string.Empty, string.Empty))
            {
                ChangeTextBoxColor(TxtThuTimeFrom, TxtThuTimeTo);
                invalidTimeFlag = 1;
            }
            else
            {
                for (var i = 0; i < gvShiftBreak.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        var thuTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblThuTimeFrom");
                        var thuTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblThuTimeTo");
                        var HFThuTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptThuTimeFrom");
                        var HFThuTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptThuTimeTo");
                        if (thuTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtThuTimeFrom.Text, TxtThuTimeTo.Text, HFThuTimeFrom.Value, HFThuTimeTo.Value, "LoopAdd", thuTimeFrom.Text, thuTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtThuTimeFrom, TxtThuTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
        }
        if (TxtFriTimeFrom.Text != string.Empty)
        {
            if (!CheckValidBreak(TxtFriTimeFrom.Text, TxtFriTimeTo.Text, HFDeptFriTimeFrom.Value, HFDeptFriTimeTo.Value, "ADD", string.Empty, string.Empty))
            {
                ChangeTextBoxColor(TxtFriTimeFrom, TxtFriTimeTo);
                invalidTimeFlag = 1;
            }
            else
            {
                for (int i = 0; i < gvShiftBreak.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        var friTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblFriTimeFrom");
                        var friTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblFriTimeTo");
                        var HFFriTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptFriTimeFrom");
                        var HFFriTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptFriTimeTo");
                        if (friTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtFriTimeFrom.Text, TxtFriTimeTo.Text, HFFriTimeFrom.Value, HFFriTimeTo.Value, "LoopAdd", friTimeFrom.Text, friTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtFriTimeFrom, TxtFriTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
        }
        if (TxtSatTimeFrom.Text != string.Empty)
        {
            if (!CheckValidBreak(TxtSatTimeFrom.Text, TxtSatTimeTo.Text, HFDeptSatTimeFrom.Value, HFDeptSatTimeTo.Value, "ADD", string.Empty, string.Empty))
            {
                ChangeTextBoxColor(TxtSatTimeFrom, TxtSatTimeTo);
                invalidTimeFlag = 1;
            }
            else
            {
                for (int i = 0; i < gvShiftBreak.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        var satTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblSatTimeFrom");
                        var satTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblSatTimeTo");
                        var HFSatTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptSatTimeFrom");
                        var HFSatTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptSatTimeTo");
                        if (satTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtSatTimeFrom.Text, TxtSatTimeTo.Text, HFSatTimeFrom.Value, HFSatTimeTo.Value, "LoopAdd", satTimeFrom.Text, satTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtSatTimeFrom, TxtSatTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
        }
        if (TxtHolidayTimeFrom.Text != string.Empty)
        {
            if (!CheckValidBreak(TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text, HFDeptHolidayTimeFrom.Value, HFDeptHolidayTimeTo.Value, "ADD", string.Empty, string.Empty))
            {
                ChangeTextBoxColor(TxtHolidayTimeFrom, TxtHolidayTimeTo);
                invalidTimeFlag = 1;
            }
            else
            {
                for (int i = 0; i < gvShiftBreak.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        var HolidayTimeFrom = (Label)gvShiftBreak.Rows[i].FindControl("lblHolidayTimeFrom");
                        var HolidayTimeTo = (Label)gvShiftBreak.Rows[i].FindControl("lblHolidayTimeTo");
                        var HFHolidayTimeFrom = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptHolidayTimeFrom");
                        var HFHolidayTimeTo = (HiddenField)gvShiftBreak.Rows[i].FindControl("HFDeptHolidayTimeTo");
                        if (HolidayTimeFrom.Text != string.Empty)
                        {
                            if (CheckValidBreak(TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text, HFHolidayTimeFrom.Value, HFHolidayTimeTo.Value, "LoopAdd", HolidayTimeFrom.Text, HolidayTimeTo.Text))
                            {
                                ChangeTextBoxColor(TxtHolidayTimeFrom, TxtHolidayTimeTo);
                                invalidTimeFlag = 1;
                            }
                        }
                    }
                }
            }
        }

        if (invalidTimeFlag == 0)
        {
            DataSet dsBreak;
            if (TxtSunTimeTo.Text != string.Empty && TxtSunTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtSunTimeFrom.Text, TxtSunTimeTo.Text,
                breakSundayMin, "SUN", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {
                    ChangeTextBoxColor(TxtSunTimeFrom, TxtSunTimeTo);
                    invalidTimeFlag = 1;
                }
            }

            if (TxtMonTimeTo.Text != string.Empty && TxtMonTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtMonTimeFrom.Text, TxtMonTimeTo.Text,
                breakMondayMin, "MON", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {
                    ChangeTextBoxColor(TxtMonTimeFrom, TxtMonTimeTo);
                    invalidTimeFlag = 1;
                }
            }

            if (TxtTueTimeTo.Text != string.Empty && TxtTueTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtTueTimeFrom.Text, TxtTueTimeTo.Text,
                breakTuesdayMin, "TUE", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {

                    ChangeTextBoxColor(TxtTueTimeFrom, TxtTueTimeTo);
                    invalidTimeFlag = 1;
                }

            }

            if (TxtWedTimeTo.Text != string.Empty && TxtWedTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtWedTimeFrom.Text, TxtWedTimeTo.Text,
                breakWednesdayMin, "WED", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {
                    ChangeTextBoxColor(TxtWedTimeFrom, TxtWedTimeTo);
                    invalidTimeFlag = 1;
                }
            }

            if (TxtThuTimeTo.Text != string.Empty && TxtThuTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtThuTimeFrom.Text, TxtThuTimeTo.Text,
                breakThursdayMin, "THU", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {
                    ChangeTextBoxColor(TxtThuTimeFrom, TxtThuTimeTo);
                    invalidTimeFlag = 1;
                }
            }

            if (TxtFriTimeTo.Text != string.Empty && TxtFriTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtFriTimeFrom.Text, TxtFriTimeTo.Text,
               breakFridayMin, "FRI", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {
                    ChangeTextBoxColor(TxtFriTimeFrom, TxtFriTimeTo);
                    invalidTimeFlag = 1;
                }
            }

            if (TxtSatTimeTo.Text != string.Empty && TxtSatTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtSatTimeFrom.Text, TxtSatTimeTo.Text,
                breakSaturdayMin, "SAT", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {
                    ChangeTextBoxColor(TxtSatTimeFrom, TxtSatTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (TxtSatTimeTo.Text != string.Empty && TxtSatTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtSatTimeFrom.Text, TxtSatTimeTo.Text,
                breakSaturdayMin, "SAT", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {
                    ChangeTextBoxColor(TxtSatTimeFrom, TxtSatTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (TxtHolidayTimeTo.Text != string.Empty && TxtHolidayTimeFrom.Text != string.Empty)
            {
                dsBreak = objSales.SaleOrderDeploymentCheckBreakRule(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                HFShiftCode.Value,
                TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text,
                breakHolidayMin, "Holiday", HFBreakLineNo.Value
                );

                if (dsBreak != null && dsBreak.Tables.Count > 0)
                {
                    ChangeTextBoxColor(TxtHolidayTimeFrom, TxtHolidayTimeTo);
                    invalidTimeFlag = 1;
                }
            }
            if (invalidTimeFlag == 0)
            {
                ds = objSales.SaleOrderDeploymentShiftsBreakUpdate(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFWeekNo.Value,
                    HFShiftCode.Value,
                    TxtMonTimeFrom.Text, TxtMonTimeTo.Text,
                    TxtTueTimeFrom.Text, TxtTueTimeTo.Text,
                    TxtWedTimeFrom.Text, TxtWedTimeTo.Text,
                    TxtThuTimeFrom.Text, TxtThuTimeTo.Text,
                    TxtFriTimeFrom.Text, TxtFriTimeTo.Text,
                    TxtSatTimeFrom.Text, TxtSatTimeTo.Text,
                    TxtSunTimeFrom.Text, TxtSunTimeTo.Text,
                    TxtHolidayTimeFrom.Text, TxtHolidayTimeTo.Text,
                    BaseUserID, HFBreakLineNo.Value, cbBillable.Checked.ToString(), cbPayable.Checked.ToString());

                gvShiftBreak.EditIndex = -1;
                FillgvShiftBreak();
            }
        }
    }

    /// <summary>
    /// Fillgvs the shift break.
    /// </summary>
    protected void FillgvShiftBreak()
    {
        var objsales = new BL.Sales();

        DataSet ds = objsales.SaleOrderDeploymentShiftsBreakGet(hfLocationAutoId.Value, lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFShiftCode.Value, HFWeekNo.Value);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    gvShiftBreak.DataSource = dt;
                    dt.Rows[0]["IsBillable"] = false;
                    dt.Rows[0]["IsPayable"] = false;
                    gvShiftBreak.DataBind();
                    gvShiftBreak.Columns[0].Visible = !lblSoStatus.Text.Equals(Resources.Resource.Authorized);
                    UpdatePanel2.Update();
                    gvShiftBreak.Rows[0].Visible = false;
                }
                else if (dt.Rows.Count > 0)
                {
                    gvShiftBreak.DataSource = dt;
                    gvShiftBreak.DataBind();
                    if (lblSoStatus.Text.Equals(Resources.Resource.Authorized))
                    {
                        gvShiftBreak.FooterRow.Visible = false;
                        gvShiftBreak.Columns[0].Visible = false;
                    }
                    else
                    {
                        gvShiftBreak.FooterRow.Visible = true;
                        gvShiftBreak.Columns[0].Visible = true;
                    }
                    UpdatePanel2.Update();
                }

                var ltrBreakSunday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakSunday");
                var ltrBreakMonday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakMonday");
                var ltrBreakTuesday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakTuesday");
                var ltrBreakWednesday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakWednesday");
                var ltrBreakThursday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakThursday");
                var ltrBreakFriday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakFriday");
                var ltrBreakSaturday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakSaturday");
                var ltrBreakHoliday = (Label)gvShiftBreak.HeaderRow.FindControl("ltrBreakHoliday");
                for (var i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                   

                    if (ds.Tables[1].Rows[i]["SunBreakMinutes"].ToString() != "0")
                    {
                        if (ds.Tables[1].Rows[i]["SunBreakMinutes"].ToString() == "-1")
                        {
                            ltrBreakSunday.Text = @"*";
                        }
                        else
                        {

                            ltrBreakSunday.Text = @"(" + ds.Tables[1].Rows[i]["SunBreakMinutes"] + @")";
                        }
                    }
                    if (ds.Tables[1].Rows[i]["MonBreakMinutes"].ToString() != "0")
                    {
                        if (ds.Tables[1].Rows[i]["MonBreakMinutes"].ToString() == "-1")
                        {
                            ltrBreakMonday.Text = @"*";
                        }
                        else
                        {
                            ltrBreakMonday.Text = @"(" + ds.Tables[1].Rows[i]["MonBreakMinutes"] + @")";
                        }
                    }
                    if (ds.Tables[1].Rows[i]["TueBreakMinutes"].ToString() != "0")
                    {
                        if (ds.Tables[1].Rows[i]["TueBreakMinutes"].ToString() == "-1")
                        {
                            ltrBreakTuesday.Text = @"*";
                        }
                        else
                        {
                            ltrBreakTuesday.Text = @"(" + ds.Tables[1].Rows[i]["TueBreakMinutes"] + @")";
                        }
                    }
                    if (ds.Tables[1].Rows[i]["WedBreakMinutes"].ToString() != "0")
                    {
                        if (ds.Tables[1].Rows[i]["WedBreakMinutes"].ToString() == "-1")
                        {
                            ltrBreakWednesday.Text = @"*";
                        }
                        else
                        {
                            ltrBreakWednesday.Text = @"(" + ds.Tables[1].Rows[i]["WedBreakMinutes"] + @")";
                        }
                    }
                    if (ds.Tables[1].Rows[i]["ThuBreakMinutes"].ToString() != "0")
                    {
                        if (ds.Tables[1].Rows[i]["ThuBreakMinutes"].ToString() == "-1")
                        {
                            ltrBreakThursday.Text = @"*";
                        }
                        else
                        {
                            ltrBreakThursday.Text = @"(" + ds.Tables[1].Rows[i]["ThuBreakMinutes"] + @")";
                        }
                    }
                    if (ds.Tables[1].Rows[i]["FriBreakMinutes"].ToString() != "0")
                    {
                        if (ds.Tables[1].Rows[i]["FriBreakMinutes"].ToString() == "-1")
                        {
                            ltrBreakFriday.Text = @"*";
                        }
                        else
                        {
                            ltrBreakFriday.Text = @"(" + ds.Tables[1].Rows[i]["FriBreakMinutes"] + @")";
                        }
                    }
                    if (ds.Tables[1].Rows[i]["SatBreakMinutes"].ToString() != "0")
                    {
                        if (ds.Tables[1].Rows[i]["SatBreakMinutes"].ToString() == "-1")
                        {
                            ltrBreakSaturday.Text = @"*";
                        }
                        else
                        {
                            ltrBreakSaturday.Text = @"(" + ds.Tables[1].Rows[i]["SatBreakMinutes"] + @")";
                        }
                    }
                    if (ds.Tables[1].Rows[i]["HolidayBreakMinutes"].ToString() != "0")
                    {
                        if (ds.Tables[1].Rows[i]["HolidayBreakMinutes"].ToString() == "-1")
                        {
                            ltrBreakHoliday.Text = @"*";
                        }
                        else
                        {
                            ltrBreakHoliday.Text = @"(" + ds.Tables[1].Rows[i]["HolidayBreakMinutes"] + @")";
                        }
                    }

                }

            }
        }
    }

    /// <summary>
    /// Handles the Click event of the lbShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbShift_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;

        var lbShift = (LinkButton)gvPattren.Rows[row.RowIndex].FindControl("lbShift");
        var lblgvWeekNo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblgvWeekNo");

        var lblSunTimeFrom = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblSunTimeFrom");
        var lblSunTimeTo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblSunTimeTo");

        var lblMonTimeFrom = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblMonTimeFrom");
        var lblMonTimeTo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblMonTimeTo");
        var lblTueTimeFrom = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblTueTimeFrom");
        var lblTueTimeTo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblTueTimeTo");
        var lblWedTimeFrom = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblWedTimeFrom");
        var lblWedTimeTo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblWedTimeTo");
        var lblThuTimeFrom = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblThuTimeFrom");
        var lblThuTimeTo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblThuTimeTo");
        var lblFriTimeFrom = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblFriTimeFrom");
        var lblFriTimeTo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblFriTimeTo");
        var lblSatTimeFrom = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblSatTimeFrom");
        var lblSatTimeTo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblSatTimeTo");
        var lblHolidayTimeFrom = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblHolidayTimeFrom");
        var lblHolidayTimeTo = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblHolidayTimeTo");

        var lblSunNoOfPersons = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblSunNoOfPersons");
        var lblMonNoOfPersons = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblMonNoOfPersons");
        var lblTueNoOfPersons = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblTueNoOfPersons");
        var lblWedNoOfPersons = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblWedNoOfPersons");
        var lblThuNoOfPersons = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblThuNoOfPersons");
        var lblFriNoOfPersons = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblFriNoOfPersons");
        var lblSatNoOfPersons = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblSatNoOfPersons");
        var lblHolidayNoOfPersons = (Label)gvPattren.Rows[row.RowIndex].FindControl("lblHolidayNoOfPersons");

        if (lblSunNoOfPersons.Text != @"0")
        {
            HFDeptSunTimeFrom.Value = lblSunTimeFrom.Text;
            HFDeptSunTimeTo.Value = lblSunTimeTo.Text;
        }
        else
        {
            HFDeptSunTimeFrom.Value = string.Empty;
            HFDeptSunTimeTo.Value = string.Empty;
        }
        if (lblMonNoOfPersons.Text != @"0")
        {
            HFDeptMonTimeFrom.Value = lblMonTimeFrom.Text;
            HFDeptMonTimeTo.Value = lblMonTimeTo.Text;
        }
        else
        {
            HFDeptMonTimeFrom.Value = string.Empty;
            HFDeptMonTimeTo.Value = string.Empty;
        }
        if (lblTueNoOfPersons.Text != @"0")
        {
            HFDeptTueTimeFrom.Value = lblTueTimeFrom.Text;
            HFDeptTueTimeTo.Value = lblTueTimeTo.Text;
        }
        else
        {
            HFDeptTueTimeFrom.Value = string.Empty;
            HFDeptTueTimeTo.Value = string.Empty;
        }
        if (lblWedNoOfPersons.Text != @"0")
        {
            HFDeptWedTimeFrom.Value = lblWedTimeFrom.Text;
            HFDeptWedTimeTo.Value = lblWedTimeTo.Text;
        }
        else
        {
            HFDeptWedTimeFrom.Value = string.Empty;
            HFDeptWedTimeTo.Value = string.Empty;
        }
        if (lblThuNoOfPersons.Text != @"0")
        {
            HFDeptThuTimeFrom.Value = lblThuTimeFrom.Text;
            HFDeptThuTimeTo.Value = lblThuTimeTo.Text;
        }
        else
        {
            HFDeptThuTimeFrom.Value = string.Empty;
            HFDeptThuTimeTo.Value = string.Empty;
        }
        if (lblFriNoOfPersons.Text != @"0")
        {
            HFDeptFriTimeFrom.Value = lblFriTimeFrom.Text;
            HFDeptFriTimeTo.Value = lblFriTimeTo.Text;
        }
        else
        {
            HFDeptFriTimeFrom.Value = string.Empty;
            HFDeptFriTimeTo.Value = string.Empty;
        }
        if (lblSatNoOfPersons.Text != @"0")
        {
            HFDeptSatTimeFrom.Value = lblSatTimeFrom.Text;
            HFDeptSatTimeTo.Value = lblSatTimeTo.Text;
        }
        else
        {
            HFDeptSatTimeFrom.Value = string.Empty;
            HFDeptSatTimeTo.Value = string.Empty;
        }
        if (lblHolidayNoOfPersons.Text != @"0")
        {
            HFDeptHolidayTimeFrom.Value = lblHolidayTimeFrom.Text;
            HFDeptHolidayTimeTo.Value = lblHolidayTimeTo.Text;
        }
        else
        {
            HFDeptHolidayTimeFrom.Value = string.Empty;
            HFDeptHolidayTimeTo.Value = string.Empty;
        }

        HFShiftCode.Value = lbShift.Text;
        HFWeekNo.Value = lblgvWeekNo.Text;
        up1.Update();
        FillgvShiftBreak();
    }

    #endregion Grid View Events

    protected void DeploymentPattern_TabChanged(object sender, EventArgs e)
    {
    }

    protected void FillddlHolidayTypeCode(DropDownList ddlHolidayTypeCode)
    {
        var objMastersManagement = new BL.MastersManagement();
        DataSet ds = objMastersManagement.HolidayTypeGetAll();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlHolidayTypeCode.DataSource = ds.Tables[0];
            ddlHolidayTypeCode.DataValueField = "HolidayTypeCode";
            ddlHolidayTypeCode.DataTextField = "HolidayTypedesc";
            ddlHolidayTypeCode.DataBind();

            var li = new ListItem { Text = Resources.Resource.Select, Value = string.Empty };
            ddlHolidayTypeCode.Items.Insert(0,li);
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow , Value = string.Empty };
            ddlHolidayTypeCode.Items.Add(li);
        }
    }
}
