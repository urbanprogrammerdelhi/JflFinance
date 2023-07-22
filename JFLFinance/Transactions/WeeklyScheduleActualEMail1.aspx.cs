// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By :  Virmani
// Last Modified On : 04-09-2014
// ***********************************************************************
// <copyright file="WeeklyScheduleActualEMail1.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using Telerik.Web.UI;
using System.IO;
using System.Web.UI;



/// <summary>
/// Class Transactions_WeeklyScheduleActualEMail1.
/// </summary>
public partial class Transactions_WeeklyScheduleActualEMail1 : BasePage//System.Web.UI.Page
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

    #region page Load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ViewState["MonthChangeStatus"] = 0;
            Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            if (lblPageHdrTitle != null)
            {
                lblPageHdrTitle.Text = "Schedule Lock UnLock"; //Resources.Resource.RotaLock;
            }

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ScheduleByEmail + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                if (IsAuthorizationAccess == true)
                {
                    //btnProceed.Visible = true;
                }
                else
                {
                    //btnProceed.Visible = false;
                }

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            txtYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            //            FillddlWeek();
            SetFromAndToDate(GetDatebasedOnSystemParameters());
            GetDatebasedOnSystemParameters();
            txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            txtFromDate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy"); // strArray[0];
            txtToDate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy"); //strArray[1];
            weekStartDate.Value = txtFromDate.Text;
            weekEndDate.Value = txtToDate.Text;

            //FillddlDivision();
            //FillddlBranch();
            //FillddlClient();

            FillddlAreaInchargeDetails();
            FillDDlAreaID();

            MakeTempTable();
            string[] strArray = new string[2];
            strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Year.ToString()));
            txtFromDate.Text = strArray[0];
            txtToDate.Text = strArray[1];
            txtYear.Text = DateTime.Now.Year.ToString();
            DefaultTheWeekDates();
            FillddlEmployeeNumber();

            if (ViewState["dt"] != null)
            {
                ViewState["dt"] = null;
            }

            //if (!IsAuthorizationAccess)
            //{
            //    rbUnlock.Visible = false;
            //    rbLock.Checked = true;
            //}

        }

        //panel1.GroupingText = "";
    }

    #endregion

    #region fill controls

    /// <summary>
    /// Fillddls the area incharge details.
    /// </summary>
    private void FillddlAreaInchargeDetails()
    {
        String EmployeeNumber = String.Empty;

        if (BaseUserIsAreaIncharge == "0" && BaseUserID != "system")
        {
            EmployeeNumber = BaseUserEmployeeNumber;
        }
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        // ds = objHRManagement.AreaInchargeGet(BaseCompanyCode, EmployeeNumber);
        ds = objHRManagement.AreaInchargeGetBasedonUserID(BaseLocationAutoID, EmployeeNumber, BaseUserID);

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
        }
        if (BaseUserID == "system" || BaseUserIsAreaIncharge == "0")
        {
            var li2 = new RadComboBoxItem();
            li2.Text = Resources.Resource.SelectAll;
            
            li2.Value = "ALL";
            ddlAreaInchargeCode.Items.Insert(0, li2);

            li2 = new RadComboBoxItem();
            li2.Text = Resources.Resource.SelectAll;
            li2.Value = "ALL";
            ddlAreaInchargeCode.Items.Insert(0, li2);
            ddlAreaInchargeName.Items.Insert(0, li2);
        }
        FillDDlAreaID();
    }

    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    protected void FillddlEmployeeNumber()
    {

        ddlEmployeeNumber.Items.Clear();
        ddlEmployeeName.Items.Clear();

        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        ds = objHRManagement.EmployeeNameGetAllBasedOnClientAsmtInchargeAreaIdForSelectedWeek(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString(), txtFromDate.Text, txtToDate.Text, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlEmployeeNumber.DataSource = ds.Tables[0];
            ddlEmployeeNumber.DataTextField = "EmployeeNumber";
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataBind();

            ddlEmployeeName.DataSource = ds.Tables[0];
            ddlEmployeeName.DataTextField = "Name";
            ddlEmployeeName.DataValueField = "EmployeeNumber";
            ddlEmployeeName.DataBind();
        }

        var li2 = new RadComboBoxItem();


        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            li2.Text = Resources.Resource.SelectAll;
            li2.Value = "ALL";
            ddlEmployeeNumber.Items.Insert(0, li2);

            li2 = new RadComboBoxItem();
            li2.Text = Resources.Resource.SelectAll;
            li2.Value = "ALL";
            ddlEmployeeName.Items.Insert(0, li2);
        }
        else
        {
            li2.Text = Resources.Resource.NotScheduled;
            li2.Value = "NotScheduled";
            ddlEmployeeNumber.Items.Insert(0, li2);

            li2 = new RadComboBoxItem();
            li2.Text = Resources.Resource.NotScheduled;
            li2.Value = "NotScheduled";
            ddlEmployeeName.Items.Insert(0, li2);
        }
    }

    /// <summary>
    /// Handles the Click event of the btnSend control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        ds = objHRManagement.SendScheduleForEmployeeBasedOnClientAsmtInchargeAreaIdForSelectedWeek(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString(), txtFromDate.Text, txtToDate.Text, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), ddlEmployeeNumber.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            DataTable dtEmp = ds.Tables[1];
            foreach (DataRow empRow in dtEmp.Rows)
            {
                StringWriter sw = new StringWriter();
                HtmlTextWriter w = new HtmlTextWriter(sw);

                string strEmployeeNumber = empRow[0].ToString();

                DataView dv = new DataView(ds.Tables[0]);
                dv.RowFilter = "EmployeeNumber='" + strEmployeeNumber + "'";
            //foreach (DataTable dt in ds.Tables)
            //{
                //Create a table
                Table tbl = new Table();

                //Create column header row
                TableHeaderRow thr = new TableHeaderRow();
                //foreach (DataColumn col in dt.Columns)
                {

                    TableHeaderCell thc = new TableHeaderCell();
                    thc.Text = Resources.Resource.ClientName;
                    thc.HorizontalAlign = HorizontalAlign.Left;
                    thr.Cells.Add(thc);
                    TableHeaderCell thc1 = new TableHeaderCell();
                    thc1.Text = Resources.Resource.AsmtAddress;
                    thc1.HorizontalAlign = HorizontalAlign.Left;
                    thr.Cells.Add(thc1);
                    TableHeaderCell thc2 = new TableHeaderCell();
                    thc2.Text = Resources.Resource.PostDesc;
                    thc2.HorizontalAlign = HorizontalAlign.Left;
                    thr.Cells.Add(thc2);
                    TableHeaderCell thc3 = new TableHeaderCell();
                    thc3.Text = Resources.Resource.DutyDate;
                    thc3.HorizontalAlign = HorizontalAlign.Left;
                    thr.Cells.Add(thc3);
                    TableHeaderCell thc4 = new TableHeaderCell();
                    thc4.Text = Resources.Resource.DutyDays;
                    thc4.HorizontalAlign = HorizontalAlign.Left;
                    thr.Cells.Add(thc4);
                    TableHeaderCell thc5 = new TableHeaderCell();
                    thc5.Text = Resources.Resource.Time;
                    thc5.HorizontalAlign = HorizontalAlign.Left;
                    thr.Cells.Add(thc5);
                    TableHeaderCell thc6 = new TableHeaderCell();
                    thc6.Text = Resources.Resource.DutyHours;
                    thc6.HorizontalAlign = HorizontalAlign.Left;
                    thr.Cells.Add(thc6);
                    TableHeaderCell thc7 = new TableHeaderCell();
                    thc7.Text = Resources.Resource.YLMUID;
                    thc7.HorizontalAlign = HorizontalAlign.Left;
                    thr.Cells.Add(thc7);

                    thr.Controls.Add(thc);
                    thr.Controls.Add(thc1);
                    thr.Controls.Add(thc2);
                    thr.Controls.Add(thc3);
                    thr.Controls.Add(thc4);
                    thr.Controls.Add(thc5);
                    thr.Controls.Add(thc6);
                    thr.Controls.Add(thc7);
                }
                tbl.CellSpacing = 10;
                tbl.Controls.Add(thr);

                
                    //DataTable dt = dv.Table;
                    //Create table rows
                var i = 0;
                    foreach (DataRowView row in dv)
                    {
                        i = 0;
                        TableRow tr = new TableRow();
                        foreach (var value in row.Row.ItemArray)
                        {
                           
                            if (value.ToString() != row.Row.ItemArray[8].ToString())
                            {
                                TableCell td = new TableCell();
                                var columnValue = string.Empty;
                                if (i == 3)
                                {

                                    columnValue = DateTime.Parse(value.ToString()).ToString("dd/MM/yyyy");

                                }

                                else if (i == 4)
                                {

                                    columnValue = ResourceValueOfKey_Get(value.ToString());

                                }
                                else
                                {
                                    columnValue = value.ToString();    
                                }
                                
                                td.Text = columnValue;
                                tr.Controls.Add(td);
                            }
                            i = i + 1;
                        }
                        tbl.Controls.Add(tr);
                        //int index = dv.Table.Rows.IndexOf(empRow);
                        
                       //dv.Delete(index);
                        
                    }
                    
                    tbl.CellSpacing = 20;
                    tbl.RenderControl(w);
                
                    //Response.Write(sw.ToString());
                    //Response.Clear();
                    string html = sw.ToString();
                    string schof = Resources.Resource.Scheduleof;
                    string emailopening = Resources.Resource.EmailOpeningLine;
                    string emailgreeting = Resources.Resource.Emailgreeting;
                    string emailclosing = Resources.Resource.EmailClosingLine;
                    //strEmployeeNumber = strEmployeeNumber + '$' + Session["MyUICulture"];
                    callemailsp(html, BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString(), txtFromDate.Text, txtToDate.Text, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), strEmployeeNumber,schof,emailopening,emailgreeting,emailclosing);
                    //callemailsp(html, BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString(), txtFromDate.Text, txtToDate.Text, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), ddlEmployeeNumber.SelectedItem.Value.ToString());
                }
            //}
            
        
        }
    }
    
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSales.ClientGet(BaseLocationAutoID, BaseUserID);

        }
        else
        {
            //ds = objSales.ClientsLocationWiseGet(BaseLocationAutoID);
            ds = objSales.ClientAreaWiseGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString());
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();

            ddlClientName.DataSource = ds.Tables[0];
            ddlClientName.DataTextField = "ClientName";
            ddlClientName.DataValueField = "ClientCode";
            ddlClientName.DataBind();

            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlClientCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlClientName.Items.Insert(0, li1);

            FillddlAsmt();
        }

    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();
        ddlAsmtName.Items.Clear();

        string strClientCode;
        if (ddlClientCode.SelectedItem.Value.ToString() == "ALL")
        {
            strClientCode = "";
        }
        else
        {
            strClientCode = ddlClientCode.SelectedItem.Value.ToString();
        }


        DataSet dsAsmt = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();


        //dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
        dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString());

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
            li1.Value = "ALL";
            ddlAsmtCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlAsmtName.Items.Insert(0, li1);
        }
        else
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlAsmtCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlAsmtName.Items.Insert(0, li1);
        }
    }

    #endregion

    #region Control events
    /// <summary>
    /// Makes the temporary table.
    /// </summary>
    private void MakeTempTable()
    {
        DataTable dtDates = new DataTable();
        DataColumn dCol1 = new DataColumn("Date", typeof(System.String));
        DataColumn dCol2 = new DataColumn("WeekNo", typeof(System.Int32));
        dtDates.Columns.Add(dCol1);
        dtDates.Columns.Add(dCol2);
        ViewState["Dates"] = dtDates;
    }

    /// <summary>
    /// Fillddls the week.
    /// </summary>
    protected void FillddlWeek()
    {
        ddlWeek.Items.Clear();
        ListItem li = new ListItem();
        int intMonth = int.Parse(ddlMonth.SelectedItem.Value.ToString());
        int intYear = int.Parse(txtYear.Text);
        decimal intDays = decimal.Parse(System.DateTime.DaysInMonth(intYear, intMonth).ToString());
        decimal decNoOfWeeks = (intDays - GetDatebasedOnSystemParameters().Day) / 7;
        int intNoOfWeek = 0;
        if (decNoOfWeeks < 1) { intNoOfWeek = 1; }
        if (decNoOfWeeks > 1 && decNoOfWeeks < 2) { intNoOfWeek = 2; }
        if (decNoOfWeeks > 2 && decNoOfWeeks < 3) { intNoOfWeek = 3; }
        if (decNoOfWeeks > 3 && decNoOfWeeks < 4) { intNoOfWeek = 4; }
        else if (decNoOfWeeks > 4 && decNoOfWeeks < 5) { intNoOfWeek = 5; }
        else { intNoOfWeek = 6; }
        int i = 1;
        while (intNoOfWeek >= i)
        {
            li = new ListItem();
            li.Text = i.ToString();
            li.Value = i.ToString();
            ddlWeek.Items.Add(li);
            i++;
        }

        SetFromAndToDate(GetDatebasedOnSystemParameters());
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;
        ddlWeek.Focus();
    }
    /// <summary>
    /// Defaults the week dates.
    /// </summary>
    private void DefaultTheWeekDates()
    {
        ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
        txtYear.Text = DateTime.Now.Year.ToString();

        ViewState["MonthChangeStatus"] = 0;
        GetWeekStartDay();
        GetStartEndDate();
        txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate.Value;
        //txtFromDate.Enabled = false;
        //txtToDate.Enabled = false;
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;
    }
    /// <summary>
    /// Gets the week start day.
    /// </summary>
    private void GetWeekStartDay()
    {
        if (int.Parse(ViewState["MonthChangeStatus"].ToString()) == 0)
        {
            DataTable dtDates = new DataTable();
            dtDates = (DataTable)ViewState["Dates"];
            dtDates.Clear();
            // dtDates.Clear();
            ddlWeek.Items.Clear();
            DateTime dtSelectedMonthFirstDay = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue.ToString()), 1);
            int NextMonth;
            string strYear = txtYear.Text;
            if (int.Parse(ddlMonth.SelectedValue.ToString()) == 12)
            {
                strYear = Convert.ToString(int.Parse(txtYear.Text) + 1);
                NextMonth = 1;
            }
            else
            {
                NextMonth = int.Parse(ddlMonth.SelectedValue.ToString()) + 1;
            }

            CultureInfo CultureInfo = new CultureInfo("en-us");
            // string dtnm= strYear
            DateTime dtNextMonthFirstDay = new DateTime(int.Parse(strYear), int.Parse(NextMonth.ToString()), 1);
            DateTime dtCurrentMonthLastDay = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue.ToString()), 1).AddMonths(1).AddDays(-1);
            // string 
            // while (dtSelectedMonthFirstDay.DayOfWeek != DayOfWeek.Sunday)
            string strScheduleWeeklyStartDay = string.Empty;
            string strScheduleWeeklyEndDay = string.Empty;
            if (ViewState["ScheduleWeeklyStartDay"] != null && ViewState["ScheduleWeeklyStartDay"].ToString() != "")
            {
                strScheduleWeeklyStartDay = ViewState["ScheduleWeeklyStartDay"].ToString();
                strScheduleWeeklyEndDay = ViewState["ScheduleWeeklyEndDay"].ToString();
            }
            else
            {
                if (ViewState["ScheduleWeeklyFromDay"] != null && ViewState["ScheduleWeeklyFromDay"].ToString() != "")
                {
                    string strCurrentMonthStartDate = ViewState["ScheduleWeeklyFromDay"].ToString();
                    CultureInfo CultureInfo1 = new CultureInfo("en-us");
                    strScheduleWeeklyStartDay = DateTime.Parse(strCurrentMonthStartDate).ToString("dddd", CultureInfo);
                    strScheduleWeeklyEndDay = DateTime.Parse(DateTime.Parse(strCurrentMonthStartDate).AddDays(double.Parse("-1")).ToString()).ToString("dddd", CultureInfo);
                }
            }

            while (dtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyStartDay.ToString().Trim().ToLower())
            {
                dtSelectedMonthFirstDay = dtSelectedMonthFirstDay.AddDays(1);
            }
            if (dtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyEndDay.ToString().Trim().ToLower())
            {
                while (dtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyEndDay.ToString().Trim().ToLower())
                {
                    dtNextMonthFirstDay = dtNextMonthFirstDay.AddDays(1);
                }
            }
            else
            {
                dtNextMonthFirstDay = dtCurrentMonthLastDay;
            }

            string dtSelectedMonthFirstDate = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
            string dtNextMonthFirstDate = dtNextMonthFirstDay.ToString("dd-MMM-yyyy");
            int Count = 1;
            int RowIndex = 1;

            DateTime nextDate;
            nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
            while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
            {
                DataRow dr = dtDates.NewRow();
                dr["Date"] = nextDate.ToString("dd-MMM-yyyy");
                dr["WeekNo"] = Count;
                nextDate = nextDate.AddDays(1);
                if (nextDate.DayOfWeek.ToString().Trim().ToLower() == strScheduleWeeklyStartDay.ToString().Trim().ToLower())
                {
                    Count = Count + 1;
                }
                RowIndex = RowIndex + 1;
                dtDates.Rows.Add(dr);
            }

            int Status = 1;
            ListItem li;

            var weekNumberAndRange = "";
            while (Status < Count)
            {
                weekNumberAndRange = "";
                DataTable tableDates = new DataTable();
                DataView dvDates = new DataView(dtDates);
                dvDates.RowFilter = "[WeekNo]='" + Status.ToString() + "'";
                tableDates = dvDates.ToTable();
                try
                {
                    weekNumberAndRange = DateTime.Parse(tableDates.Rows[0]["Date"].ToString()).ToString("dd-MMM-yyyy") + " - " + DateTime.Parse(tableDates.Rows[6]["Date"].ToString()).ToString("dd-MMM-yyyy");
                }
                catch (Exception ex)
                {
                }
                li = new ListItem();
                li.Text = Status.ToString() + "   [" + weekNumberAndRange + "]";
                li.Value = Status.ToString();
                ddlWeek.Items.Add(li);
                Status = Status + 1;
                tableDates.Dispose();
            }
            ViewState["Dates"] = dtDates;
        }

    }
    /// <summary>
    /// Gets the start end date.
    /// </summary>
    private void GetStartEndDate()
    {
        DataTable dtDates = (DataTable)ViewState["Dates"];
        DataView dv = new DataView(dtDates);

        dv.RowFilter = "[WeekNo]='" + (ddlWeek.SelectedValue.ToString()) + "'";
        DataTable dtStartEndDate = new DataTable();
        dtStartEndDate = dv.ToTable();
        HFFromDate.Value = DateTime.Parse(dtStartEndDate.Rows[0]["Date"].ToString()).ToString("dd-MMM-yyyy");
        HFToDate.Value = DateTime.Parse(dtStartEndDate.Rows[6]["Date"].ToString()).ToString("dd-MMM-yyyy");
        HFMaxDate.Value = DateTime.Parse(dtDates.Rows[dtDates.Rows.Count - 1]["Date"].ToString()).ToString("dd-MMM-yyyy");
    }

    /// <summary>
    /// Gets the datebased on system parameters.
    /// </summary>
    /// <returns>DateTime.</returns>
    private DateTime GetDatebasedOnSystemParameters()
    {
        try
        {
            DataTable dt = new DataTable();
            BL.Roster objRoster = new BL.Roster();
            string strSelectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text);
            dt = objRoster.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strSelectedMonthStartDate, "Weekly".Trim().ToLower());
            DateTime dtSelectedMonthFirstDate = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue.ToString()), 1);

            if (dt != null && dt.Rows.Count > 0)
            {
                //ViewState["ScheduleWeeklyFromDay"] = dt.Rows[0]["ScheduleWeeklyFromDay"].ToString();
                string strScheduleWeeklyStartDay = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                string strScheduleWeeklyEndDay = dt.Rows[0]["ScheduleWeeklyEndDay"].ToString();
                ViewState["ScheduleWeeklyStartDay"] = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                // ViewState["ScheduleWeeklyEndDay"] = dt.Rows[0]["ScheduleWeeklyEndDay"].ToString();
                ViewState["ScheduleWeeklyEndDay"] = strScheduleWeeklyEndDay;
                while (dtSelectedMonthFirstDate.ToString("dddd").ToUpper() != strScheduleWeeklyStartDay.ToUpper())
                {
                    dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(1);
                }
                //dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays((int.Parse(ddlWeek.SelectedItem.Value.ToString()) - 1) * 7);
                //txtFromDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
                //dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
                //txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");

                if (int.Parse(ViewState["MonthChangeStatus"].ToString()) == 0)
                {
                    MakeTempTable();
                    ViewState["ScheduleWeeklyFromDay"] = dt.Rows[0]["ScheduleWeeklyFromDay"].ToString();
                    ViewState["ScheduleWeeklyStartDay"] = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                    ViewState["ScheduleWeeklyEndDay"] = dt.Rows[0]["ScheduleWeeklyEndDay"].ToString();
                    GetWeekStartDay();
                }
            }
            return dtSelectedMonthFirstDate;
        }
        catch
        {
            //lblErrorMsg.Text = "Invalid Year Selected";
            return DateTime.Now;
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        // FillddlWeek();
        //  SetFromAndToDate(GetDatebasedOnSystemParameters());
        // ddlMonth.Focus();
        ViewState["MonthChangeStatus"] = 0;
        GetWeekStartDay();
        GetStartEndDate();

        txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate.Value;
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlWeek control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SetFromAndToDate(GetDatebasedOnSystemParameters());
        //ddlWeek.Focus();

        ViewState["MonthChangeStatus"] = 1;
        if (ViewState["MonthChangeStatus"] == "0")
        {
            GetWeekStartDay();
        }
        GetStartEndDate();

        txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate.Value;
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;

        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        if (txtYear.Text == "")
        {
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        if (txtYear.Text.Length < 4)
        {
            Show("Invalid Year");
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        try
        {
            FillddlWeek();
            SetFromAndToDate(GetDatebasedOnSystemParameters());
            txtYear.Focus();
        }
        catch (Exception ex)
        {
            Show("Invalid Year");
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        GetWeekStartDay();
        GetStartEndDate();
        FillddlEmployeeNumber();
    }

    /// <summary>
    /// Sets from and to date.
    /// </summary>
    /// <param name="dtSelectedMonthFirstDate">The dt selected month first date.</param>
    private void SetFromAndToDate(DateTime dtSelectedMonthFirstDate)
    {
        if (ddlWeek.SelectedItem != null)
        {
            dtSelectedMonthFirstDate =
                dtSelectedMonthFirstDate.AddDays((int.Parse(ddlWeek.SelectedItem.Value.ToString()) - 1) * 7);
            txtFromDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
            dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
            txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
            weekStartDate.Value = txtFromDate.Text;
            weekEndDate.Value = txtToDate.Text;
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FillddlBranch();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClient();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlClientName.SelectedValue = ddlClientCode.SelectedValue;
        FillddlAsmt();
        FillddlEmployeeNumber();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientCode.SelectedValue = ddlClientName.SelectedValue;
        FillddlAsmt();
        FillddlEmployeeNumber();
    }


    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtName.SelectedValue = ddlAsmtCode.SelectedValue;
        //FillDDLPost();
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtName_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtCode.SelectedValue = ddlAsmtName.SelectedValue;
        //FillDDLPost();
        FillddlEmployeeNumber();
    }



    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FillPost();
    }

    #endregion

    #region function related to grid



    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeName.SelectedValue = ddlAreaInchargeCode.SelectedValue;
        FillDDlAreaID();
        FillddlEmployeeNumber();
    }

    /// <summary>
    /// Fills the d dl area identifier.
    /// </summary>
    private void FillDDlAreaID()
    {
        DDLAreaID.Items.Clear();
        ddlAreaName.Items.Clear();


        DataSet ds = new DataSet();
        BL.OperationManagement objOPS = new BL.OperationManagement();
        ds = objOPS.AreaIdGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedValue);
        //BL.OperationManagement objSale = new BL.OperationManagement();
        //ds = objSale.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLAreaID.DataSource = ds;
            DDLAreaID.DataTextField = "AreaID";
            DDLAreaID.DataValueField = "AreaID";
            DDLAreaID.DataBind();

            ddlAreaName.DataSource = ds;
            ddlAreaName.DataTextField = "AreaDesc";
            ddlAreaName.DataValueField = "AreaID";
            ddlAreaName.DataBind();
        }
        //if (ddlAreaInchargeCode.SelectedItem.Value.ToString() == "ALL")
        //{
        var li = new RadComboBoxItem();
        li.Text = Resources.Resource.All;
        li.Value = "All";
        DDLAreaID.Items.Insert(0, li);

        li = new RadComboBoxItem();
        li.Text = Resources.Resource.All;
        li.Value = "All";
        ddlAreaName.Items.Insert(0, li);
        //}
        FillddlClient(); //Code Added By Ajay Datta On 01-Nov-2012 To refill Client for Training Report
        //FillDDLClientPost();
        //FillddlAsmtPost();
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
        FillddlEmployeeNumber();
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
        FillddlEmployeeNumber();
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
        FillddlEmployeeNumber();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployeeNumber control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeNumber_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeName.SelectedValue = ddlEmployeeNumber.SelectedValue;
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployeeName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeNumber.SelectedValue = ddlEmployeeName.SelectedValue;
    }
    #endregion
    /// <summary>
    /// Calls Email Sending SP
    /// </summary>
    /// <param name="html"></param>
    /// <param name="locationAutoId"></param>
    /// <param name="areaIncharge"></param>
    /// <param name="areaId"></param>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <param name="clientCode"></param>
    /// <param name="asmtCode"></param>
    /// <param name="employeeNumber"></param>
    private void callemailsp(string html,string locationAutoId, string areaIncharge, string areaId, string fromDate, string toDate, string clientCode, string asmtCode, string employeeNumber ,string schof,string emailopening, string emailgreeting,string emailclosing)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objHRManagement.CallEmailSP(html, locationAutoId, areaIncharge, areaId, fromDate, toDate, clientCode, asmtCode, employeeNumber, schof, emailopening, emailgreeting, emailclosing);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageStr"].ToString();
        
        }
    
    }
}