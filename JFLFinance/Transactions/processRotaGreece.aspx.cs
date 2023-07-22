// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="processRotaGreece.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_processRotaGreece.
/// </summary>
public partial class Transactions_processRotaGreece : BasePage //System.Web.UI.Page
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

        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.ProcessRota;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ProcessRota + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                //fillPayPeriod();
                txtYear.Text = DateTime.Now.Year.ToString();
                int intMonth = DateTime.Now.Month;
                ddlMonth.Items[intMonth - 1].Selected = true;

                //code modified by Manish on 5-feb 2010 
                //description set start date * End date according to company payperiod 
                string[] strArray = new string[2];
                strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, intMonth, int.Parse(txtYear.Text));
                txtFromDate.Text = strArray[0];
                txtToDate.Text = strArray[1];
                if (IsWriteAccess == true)
                {
                    btnProcess.Visible = true;
                    FillEmployeeList();
                }
                else
                {
                    btnProcess.Visible = false;
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }

    }

    ////protected void fillPayPeriod()
    ////{
    ////    BL.MastersManagement objMastersManagement = new BL.MastersManagement();
    ////    DataSet ds = new DataSet();
    ////    ds = objMastersManagement.blPayPeriodOfCompany_Get(BaseCompanyCode.ToString());
    ////    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    ////    {
    ////        ddlPayPeriod.DataSource = ds.Tables[0];
    ////        ddlPayPeriod.DataTextField = "PayPeriodDesc";
    ////        ddlPayPeriod.DataValueField = "PayPeriodDesc";
    ////        ddlPayPeriod.DataBind();
    ////    }
    ////}

    /// <summary>
    /// Handles the Click event of the btnProcess control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        //code commented by Manish on 4-feb 2010
        //description  passing from date & To Date according to payperiod 
        //ds = objRost.blTran_EmployeeAttendance_Process(BaseCompanyCode,0,int.Parse(BaseLocationAutoID.ToString()), int.Parse(ddlMonth.SelectedValue),int.Parse(txtYear.Text), BaseUserID.ToString());
        if (BaseCountryName != null && BaseCountryName.ToUpper() == "Morocco".ToUpper())
        {
            ds = objRost.EmployeeAttendanceProcess(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, txtFromDate.Text, txtToDate.Text, BaseUserID);
            lblErrorMsg.Text = Resources.Resource.ProcessCompleted;
        }
        else if (BaseCountryName != null && BaseCountryName.ToUpper() == "Greece".ToUpper())
        {
            if (ddlEmployees.Text.Contains("ALL"))
            {
                ddlEmployees.Text = "ALL";
            }
            ds = objRost.EmployeeAttendanceProcessGreece(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, ddlProcess.SelectedValue.ToString(), txtFromDate.Text, txtToDate.Text, ddlEmployees.Text, BaseUserID);
            lblErrorMsg.Text = Resources.Resource.ProcessCompleted;
        }
        else
        {
            ds = objRost.EmployeeAttendanceProcess(BaseCompanyCode, BaseHrLocationCode, int.Parse(BaseLocationAutoID.ToString()), txtFromDate.Text, txtToDate.Text, BaseUserID.ToString());
            lblErrorMsg.Text = Resources.Resource.ProcessCompleted;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //
            }
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPayPeriod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPayPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //code modified by Manish on 5-feb 2010 
        //description set start date * End date according to company payperiod 
        string[] strArray = new string[2];
        strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(ddlMonth.SelectedValue.ToString()), int.Parse(txtYear.Text));
        txtFromDate.Text = strArray[0];
        txtToDate.Text = strArray[1];
        FillEmployeeList();
    }
    /// <summary>
    /// Handles the OnTextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_OnTextChanged(object sender, EventArgs e)
    {
        txtFromDate.Text = DateFormat(DateTime.Parse("01" + "-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text).ToString("dd-MMM-yyyy"));
        txtToDate.Text = DateFormat(DateTime.Parse(LastDateOfMonth(txtFromDate.Text) + "-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text).ToString("dd-MMM-yyyy"));
    }
    /// <summary>
    /// Lasts the date of month.
    /// </summary>
    /// <param name="date1">The date1.</param>
    /// <returns>String.</returns>
    protected string LastDateOfMonth(string date1)
    {
        string totalDays = DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue.ToString())).ToString();
        return totalDays;
    }
    /// <summary>
    /// Gets the name of the month.
    /// </summary>
    /// <param name="month">The month.</param>
    /// <returns>System.String.</returns>
    private static string GetMonthName(int month)
    {
        DateTime date = new DateTime(1900, month, 1);
        return date.ToString("MMMM");
    }

    #region Fill Employees
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployees control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployees.Text.Contains("ALL"))
        {
            ddlEmployees.Text = "ALL";
        }
    }
    /// <summary>
    /// Fills the employee list.
    /// </summary>
    protected void FillEmployeeList()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objHRManagement.RosterOfHRLocationGetAll(BaseCompanyCode, BaseHrLocationCode, txtFromDate.Text, txtToDate.Text);
        // ds.Tables[0].DefaultView.Sort = "FullName";
        ddlEmployees.DataSource = ds.Tables[0];
        ddlEmployees.DataValueField = "EmployeeNumber";
        ddlEmployees.DataTextField = "EmployeeName";
        ddlEmployees.DataBind();
        ListItem li = new ListItem();
        li.Text = "ALL";
        li.Value = "ALL";
        ddlEmployees.Items.Insert(0, li);

        if (ddlEmployees.Items.Count > 0)
        {
            ddlEmployees.SelectedIndex = 0;
        }

    }
    #endregion


}
