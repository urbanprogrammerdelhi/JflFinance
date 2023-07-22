// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SOLineDeptPattren.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_SOLineDeptPattren.
/// </summary>
public partial class Sales_SOLineDeptPattren : BasePage //System.Web.UI.Page
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
    #region Page functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblavgdays.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";
        lblmonthbilling.Text = " ( " + Resources.Resource.RptIn + " " + BaseDefaultCurrency + " ) ";

        if (!IsPostBack)
        {
            string strGlbLocationAutoID = "";
            string strGlbSoNo = "";
            string strGlbSOAmendNO = "";
            string strGlbSOLineNo = "";
            string strGlbSOStatus = "";
            string strGlbIsMAXSOAmendNo = "";
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.DeploymentDays;
            //}
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.DeploymentDays + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"] != null && Request.QueryString["SOAmendNO"] != null && Request.QueryString["SOLineNo"] != null && Request.QueryString["Hours"] != null && Request.QueryString["NoOfPost"] != null)
                {
                    if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"].ToString() != "" && Request.QueryString["SOAmendNO"].ToString() != "" && Request.QueryString["SOLineNo"].ToString() != "" && Request.QueryString["Hours"].ToString() != "" && Request.QueryString["NoOfPost"].ToString() != "")
                    {
                        strGlbLocationAutoID = Request.QueryString["LocationAutoID"].ToString();
                        strGlbSoNo = Request.QueryString["SoNo"].ToString();
                        strGlbSOAmendNO = Request.QueryString["SOAmendNO"].ToString();
                        strGlbSOLineNo = Request.QueryString["SOLineNo"].ToString();
                        strGlbSOStatus = Request.QueryString["SOStatus"].ToString(); ;
                        strGlbIsMAXSOAmendNo = Request.QueryString["IsMAXSOAmendNo"].ToString();
                        hfHours.Value = Request.QueryString["Hours"].ToString();
                        hfNoOfPost.Value = Request.QueryString["NoOfPost"].ToString();
                        hfChargeRatePerHrs.Value = Request.QueryString["ChargeRatePerHrs"].ToString();
                        hfIsAllowanceBillable.Value = Request.QueryString["IsAllowanceBillable"].ToString();
                        hfRemainingDays.Value = Request.QueryString["RemainingDays"].ToString();
                        hfOtherAllowance.Value = Request.QueryString["OtherAllowances"].ToString();

                        //HFSoLineActiveStatus.Value = Request.QueryString["Checked"].ToString();
                        string strSoLineActiveStatus = Request.QueryString["Checked"].ToString();

                        hfBillingPattern.Value = Request.QueryString["BillingPattern"].ToString();
                        txtAverageDaysInMonth.Attributes.Add("readonly", "readonly");
                        txtComputedMonthlyValue.Attributes.Add("readonly", "readonly");
                        if (hfBillingPattern.Value.Trim().ToLower() != "Fixed".ToLower())
                        {
                            txtFixedMonthlyBilling.Attributes.Add("readonly", "readonly");
                        }
                        hfLocationAutoId.Value = strGlbLocationAutoID;
                        lblSoNo.Text = strGlbSoNo;
                        lblSOAmendNo.Text = strGlbSOAmendNO;
                        lblSOLineNo.Text = strGlbSOLineNo;
                        lblSoStatus.Text = strGlbSOStatus;
                        hfIsMAXSOAmendNo.Value = strGlbIsMAXSOAmendNo;
                        if (!strGlbIsMAXSOAmendNo.Equals("MAX") || (strGlbIsMAXSOAmendNo.Equals("MAX") && (strGlbSOStatus.Equals(Resources.Resource.Authorized.ToString()) || strGlbSOStatus.Equals(Resources.Resource.ShortClosed.ToString()))))
                        {
                            btnSave.Enabled = false;
                            txtFixedMonthlyBilling.Enabled = false;
                        }
                        ShowDetails(strGlbLocationAutoID, strGlbSoNo, strGlbSOAmendNO, strGlbSOLineNo);
                        ////Code Added by Manish  Ticket No : 146362 Modified Date 19-feb-2010 Point N0:2

                        if (bool.Parse(strSoLineActiveStatus) == false)
                        {
                            btnSave.Visible = false;
                            gvPattren.Enabled = false;
                        }

                    }
                    if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
                    {
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    Response.Redirect("../UserManagement/Home.aspx");
                }
            }
           
        }
     
    }
    /// <summary>
    /// Shows the details.
    /// </summary>
    /// <param name="strLocationAutoID">The string location automatic identifier.</param>
    /// <param name="strSoNo">The string so no.</param>
    /// <param name="strSOAmendNO">The string so amend no.</param>
    /// <param name="strSOLineNo">The string so line no.</param>
    protected void ShowDetails(string strLocationAutoID, string strSoNo, string strSOAmendNO, string strSOLineNo)
    {
        FillgvPattren(strLocationAutoID, strSoNo, strSOAmendNO, strSOLineNo);
        CalculateNoOFDays();
    }
    /// <summary>
    /// Calculates the no of days.
    /// </summary>
    private void CalculateNoOFDays()
    {
        decimal averageDaysInMonth = decimal.Parse("0");
        for (int i = 0; i < gvPattren.Rows.Count; i++)
        {
            HiddenField lblExcludedDays = (HiddenField)gvPattren.Rows[i].FindControl("lblExcludedDays");
            averageDaysInMonth = averageDaysInMonth + decimal.Parse(lblExcludedDays.Value);
        }
        txtAverageDaysInMonth.Text = averageDaysInMonth.ToString();
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.SellingDaysInMonthGet(lblSOLineNo.Text, BaseLocationAutoID, lblSoNo.Text, lblSOAmendNo.Text);
        if (ds.Tables[0].Rows[0]["SellingPrice"].ToString() != "")
        {
            // Commented By lokesh To Add System Parameter Changes    
            //txtFixedMonthlyBilling.Text = Math.Round((decimal.Parse(ds.Tables[0].Rows[0]["SellingPrice"].ToString()) * decimal.Parse(hfNoOfPost.Value)),3).ToString();
            //// txtFixedMonthlyBilling.Text = Math.Round((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)), 3).ToString();
            //txtComputedMonthlyValue.Text = Math.Round((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)), 3).ToString();
            if (hfBillingPattern.Value.Trim().ToLower() != "Fixed".ToLower())
            {
                txtFixedMonthlyBilling.Text = GetValueAsPerSystemParameters((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                txtComputedMonthlyValue.Text = GetValueAsPerSystemParameters((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }
            else
            {
                txtFixedMonthlyBilling.Text = GetValueAsPerSystemParameters((decimal.Parse(ds.Tables[0].Rows[0]["SellingPrice"].ToString()) * decimal.Parse(hfNoOfPost.Value)).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                txtComputedMonthlyValue.Text = GetValueAsPerSystemParameters((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }
        }
        else
        {
            // Commented By lokesh To Add System Parameter Changes  
            //txtComputedMonthlyValue.Text = Math.Round((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)), 3).ToString();
            //txtFixedMonthlyBilling.Text = Math.Round((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)), 3).ToString();
            txtComputedMonthlyValue.Text = GetValueAsPerSystemParameters((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            txtFixedMonthlyBilling.Text = GetValueAsPerSystemParameters((decimal.Parse(hfHours.Value) * decimal.Parse(hfChargeRatePerHrs.Value) * decimal.Parse(hfNoOfPost.Value) * decimal.Parse(txtAverageDaysInMonth.Text)).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
        }
    }
    /// <summary>
    /// Fillgvs the pattren.
    /// </summary>
    /// <param name="strLocationAutoID">The string location automatic identifier.</param>
    /// <param name="strSoNo">The string so no.</param>
    /// <param name="strSOAmendNO">The string so amend no.</param>
    /// <param name="strSOLineNo">The string so line no.</param>
    protected void FillgvPattren(string strLocationAutoID, string strSoNo, string strSOAmendNO, string strSOLineNo)
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objsales.SaleOrderDeploymentPatternGet(strLocationAutoID, strSoNo, strSOAmendNO, strSOLineNo);
        gvPattren.DataSource = ds.Tables[0];
        gvPattren.DataKeyNames = new string[] { "LocationAutoId", "SoNo", "SoAmendNo", "SoLineNo", "WeekNo" };
        gvPattren.DataBind();
        // CalculateNoOFDays();
    }
    #endregion
    #region Buttons Event
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable table = new DataTable("SODeptPattern");
        DataColumn column;
        DataRow row;
        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Int16");
        column.ColumnName = "WeekNo";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "SUN";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "MON";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "TUE";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "WED";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "THU";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "FRI";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "SAT";
        table.Columns.Add(column);

        BL.Sales objSales = new BL.Sales();
        foreach (GridViewRow gvRow in gvPattren.Rows)
        {
            Label lblgvWeekNo = (Label)gvRow.FindControl("lblgvWeekNo");
            CheckBox cbSun = (CheckBox)gvRow.FindControl("cbSun");
            CheckBox cbMon = (CheckBox)gvRow.FindControl("cbMon");
            CheckBox cbTue = (CheckBox)gvRow.FindControl("cbTue");
            CheckBox cbWed = (CheckBox)gvRow.FindControl("cbWed");
            CheckBox cbThu = (CheckBox)gvRow.FindControl("cbThu");
            CheckBox cbFri = (CheckBox)gvRow.FindControl("cbFri");
            CheckBox cbSat = (CheckBox)gvRow.FindControl("cbSat");

            row = table.NewRow();
            row["WeekNo"] = Int16.Parse(lblgvWeekNo.Text.ToString());
            row["SUN"] = Boolean.Parse(cbSun.Checked.ToString());
            row["MON"] = Boolean.Parse(cbMon.Checked.ToString());
            row["TUE"] = Boolean.Parse(cbTue.Checked.ToString());
            row["WED"] = Boolean.Parse(cbWed.Checked.ToString());
            row["THU"] = Boolean.Parse(cbThu.Checked.ToString());
            row["FRI"] = Boolean.Parse(cbFri.Checked.ToString());
            row["SAT"] = Boolean.Parse(cbSat.Checked.ToString());
            table.Rows.Add(row);
        }
        DataSet ds = new DataSet();
        ds = objSales.SaleOrderDeploymentPatternUpdate(hfLocationAutoId.Value.ToString(), lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, table, BaseUserID.ToString());
        DataSet dsSaleDetail = new DataSet();

        FillgvPattren(hfLocationAutoId.Value.ToString(), lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text);
        if (hfBillingPattern.Value.Trim().ToLower() == "Actual".ToLower())
        {
            CalculateNoOFDays();
        }
        double SellingPrice = 0;
        if (hfBillingPattern.Value.Trim().ToLower() != "Fixed".ToLower())
        {
            SellingPrice = double.Parse(txtComputedMonthlyValue.Text) / double.Parse(hfNoOfPost.Value);
            dsSaleDetail = objSales.SellingPriceUpdate(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, BaseLocationAutoID, SellingPrice.ToString(), txtAverageDaysInMonth.Text, BaseUserID);
        }
        else
        {
            SellingPrice = double.Parse(txtFixedMonthlyBilling.Text) / double.Parse(hfNoOfPost.Value);
            dsSaleDetail = objSales.SellingPriceUpdate(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, BaseLocationAutoID, SellingPrice.ToString(), txtAverageDaysInMonth.Text, BaseUserID);
        }
        CalculateNoOFDays();
        // dsSaleDetail = objSales.blSaleOrderDetail_UpdateSellingPrice(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, BaseLocationAutoID, SellingPrice.ToString(), txtAverageDaysInMonth.Text, BaseUserID);
        // CalculateNoOFDays();

    }
    #endregion
    #region GridView Events
    /// <summary>
    /// Handles the RowCommand event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox cbAllSun = (CheckBox)e.Row.FindControl("cbAllSun");
            CheckBox cbAllMon = (CheckBox)e.Row.FindControl("cbAllMon");
            CheckBox cbAllTue = (CheckBox)e.Row.FindControl("cbAllTue");
            CheckBox cbAllWed = (CheckBox)e.Row.FindControl("cbAllWed");
            CheckBox cbAllThu = (CheckBox)e.Row.FindControl("cbAllThu");
            CheckBox cbAllFri = (CheckBox)e.Row.FindControl("cbAllFri");
            CheckBox cbAllSat = (CheckBox)e.Row.FindControl("cbAllSat");
            if (IsModifyAccess == false)
            {
                cbAllSun.Enabled = false;
                cbAllMon.Enabled = false;
                cbAllTue.Enabled = false;
                cbAllWed.Enabled = false;
                cbAllThu.Enabled = false;
                cbAllFri.Enabled = false;
                cbAllSat.Enabled = false;
            }
            if (!hfIsMAXSOAmendNo.Value.ToString().Equals("MAX") || (hfIsMAXSOAmendNo.Value.ToString().Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString()))))
            {
                cbAllSun.Enabled = false;
                cbAllMon.Enabled = false;
                cbAllTue.Enabled = false;
                cbAllWed.Enabled = false;
                cbAllThu.Enabled = false;
                cbAllFri.Enabled = false;
                cbAllSat.Enabled = false;
            }

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            CheckBox cbSun = (CheckBox)e.Row.FindControl("cbSun");
            CheckBox cbMon = (CheckBox)e.Row.FindControl("cbMon");
            CheckBox cbTue = (CheckBox)e.Row.FindControl("cbTue");
            CheckBox cbWed = (CheckBox)e.Row.FindControl("cbWed");
            CheckBox cbThu = (CheckBox)e.Row.FindControl("cbThu");
            CheckBox cbFri = (CheckBox)e.Row.FindControl("cbFri");
            CheckBox cbSat = (CheckBox)e.Row.FindControl("cbSat");
            if (IsModifyAccess == false)
            {
                cbSun.Enabled = false;
                cbMon.Enabled = false;
                cbTue.Enabled = false;
                cbWed.Enabled = false;
                cbThu.Enabled = false;
                cbFri.Enabled = false;
                cbSat.Enabled = false;
            }
            if (!hfIsMAXSOAmendNo.Value.ToString().Equals("MAX") || (hfIsMAXSOAmendNo.Value.ToString().Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString()))))
            {
                cbSun.Enabled = false;
                cbMon.Enabled = false;
                cbTue.Enabled = false;
                cbWed.Enabled = false;
                cbThu.Enabled = false;
                cbFri.Enabled = false;
                cbSat.Enabled = false;
            }
            Label lblHoursInWeek = (Label)e.Row.FindControl("lblHoursInWeek");
            Label lblgvWeekNo = (Label)e.Row.FindControl("lblgvWeekNo");
            HiddenField lblExcludedDays = (HiddenField)e.Row.FindControl("lblExcludedDays");
            decimal decNoofDaysinWeek = decimal.Parse("0");
            decimal daysPerWeek = decimal.Parse("0");
            decimal daysInMonth;
            decimal excludedDays = decimal.Parse("0");
            int monthsInYear = 12;
            decimal averageWeekInMonth = decimal.Parse("4.333");
            decimal averageDaysInYear = decimal.Parse("365.25");
            decimal averageDaysInWeek = decimal.Parse("0");
            if (cbSun.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbMon.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbTue.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbWed.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbThu.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbFri.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbSat.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }

            decimal decWeeklyHours = 0;
            if (int.Parse(lblgvWeekNo.Text) < 5)
            {
                // 7 Days in week
                decWeeklyHours = decNoofDaysinWeek * decimal.Parse(hfHours.Value) * decimal.Parse(hfNoOfPost.Value);

                //excludedDays = decimal.Parse((52 * (7 - daysPerWeek)).ToString());
                //averageDaysInWeek = decimal.Parse((((averageDaysInYear - excludedDays) / monthsInYear) / averageWeekInMonth).ToString());
                //averageDaysInWeek = Math.Round(averageDaysInWeek, 2);

                averageDaysInWeek = decNoofDaysinWeek;
            }
            else
            {
                //2.45 Days in Week
                //decWeeklyHours = (decimal.Parse("2.45") / 7) * decNoofDaysinWeek * decimal.Parse(hfHours.Value) * decimal.Parse(hfNoOfPost.Value);
                decWeeklyHours = (decimal.Parse(hfRemainingDays.Value) / 7) * decNoofDaysinWeek * decimal.Parse(hfHours.Value) * decimal.Parse(hfNoOfPost.Value);

                ////daysPerWeek = (decimal.Parse("2.35") / 7) * daysPerWeek;
                //double tmp = double.Parse(hfRemainingDays.Value) - double.Parse("00.10");
                //daysPerWeek = (decimal.Parse(tmp.ToString()) / 7) * daysPerWeek;
                //excludedDays = decimal.Parse((52 * (7 - daysPerWeek)).ToString());
                //averageDaysInWeek = decimal.Parse((((averageDaysInYear - excludedDays) / monthsInYear) / averageWeekInMonth).ToString());
                //averageDaysInWeek = Math.Round(averageDaysInWeek, 2);

                averageDaysInWeek = (decimal.Parse(hfRemainingDays.Value) / 7) * decNoofDaysinWeek;
            }
            lblExcludedDays.Value = averageDaysInWeek.ToString();
            lblHoursInWeek.Text = decWeeklyHours.ToString("#.000#");
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    #endregion
}
