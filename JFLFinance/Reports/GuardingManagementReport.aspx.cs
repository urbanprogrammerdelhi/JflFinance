// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="GuardingManagementReport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Reports_GuardingManagementReport.
/// </summary>
public partial class Reports_GuardingManagementReport : BasePage
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
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Process + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillddlToDivision();
                txtYear.Text = DateTime.Now.Year.ToString();
                int intMonth = DateTime.Now.Month;
                ddlMonth.Items[intMonth - 1].Selected = true;

              
                int monthval = DateTime.Now.Month;
                ddlMonth.SelectedValue = monthval.ToString();

                txtYear.Text = DateTime.Now.Year.ToString();

                txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

                GetWeekStartDay();

                txtFromDate.Text = HDFromDate.Value;
                txtToDate.Text = HDToDate.Value;

                if (IsWriteAccess == true)
                {
                    btnProcess.Visible = true;
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

    /// <summary>
    /// fills first and last date of the month
    /// </summary>
    private void GetWeekStartDay()
    {
        //DateTime now = DateTime.Now;

        var month = new DateTime(Convert.ToInt32(txtYear.Text),Convert.ToInt32(ddlMonth.SelectedValue), 1);
        var first = month.AddMonths(0);
        
        var last = first.AddMonths(1).AddDays(-1);
        HDFromDate.Value = first.ToString("dd-MMM-yyyy");
        HDToDate.Value = last.ToString("dd-MMM-yyyy");

      
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        GetWeekStartDay();

        txtFromDate.Text = HDFromDate.Value;
        txtToDate.Text = HDToDate.Value;

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
        return date.ToString("");
    }

    /// <summary>
    /// Handles the Click event of the btnProcess control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        BL.Roster objRost = new BL.Roster();
        
        using (DataTable ProcessGet = objRost.GuardingManagementProcessGet(BaseCompanyCode,BaseHrLocationCode,DateFormat(txtFromDate.Text.ToString()),DateFormat(txtToDate.Text.ToString()),BaseUserID))
        {
            if (ProcessGet != null && ProcessGet.Rows.Count > 0)
            {
                lblErrorMsg.Text = ProcessGet.Rows[0][0].ToString();
            }
        }
    }

    /// <summary>
    /// Fills Division DropDown
    /// </summary>
    private void FillddlToDivision()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        ds = objblMasterManagement.HRLocationDescriptionGetAll(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = ds.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDescCode";
            ddlDivision.DataBind();
            ds.Dispose();
        }
        else
        {
            var li1 = new ListItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlDivision.Items.Add(li1);
            
        }
        
    }

}