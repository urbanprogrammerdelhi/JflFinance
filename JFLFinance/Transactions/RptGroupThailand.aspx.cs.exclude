// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroupThailand.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_RptGroupThailand.
/// </summary>
public partial class Transactions_RptGroupThailand : BasePage
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
            btnViewReport.Enabled = false;
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Schedules + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            lblErrorMsg.Text = "";
            if (IsReadAccess == true)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID.ToString() + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID.ToString() + "');";
         

                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();
                FillddlReportTypeMain();
                FillddlReportName();
                btnViewReport.Enabled = true;
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }
                ShowHideReportParameterControles();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
        
    }

    #region Fill Controls

    /// <summary>
    /// Fills the Control "Report Type"
    /// </summary>
     
    private void FillddlReportTypeMain()
    {
        var li = new RadComboBoxItem();
        li.Text = Resources.Resource.Rostering.ToString();
        li.Value = "Rostering";
        ddlReportTypeMain.Items.Add(li);

        //li = new RadComboBoxItem();
        //li.Text = Resources.Resource.Training.ToString();
        //li.Value = "Training";
        //ddlReportTypeMain.Items.Add(li);

    }

    /// <summary>
    /// Hides all controls
    /// </summary>
    private void HideAllControles()
    {
     
        PanelDates.Visible = false;
     
    }

    /// <summary>
    /// Fills all Report Name
    /// </summary>
    private void FillddlReportName()
    {
        ddlReportName.Items.Clear();
        var li = new RadComboBoxItem();
        if (ddlReportTypeMain.SelectedValue.ToString() == "Rostering")
        {
            //li = new ListItem();
            li.Text = Resources.Resource.LocationCategoryWOHrs.ToString();
            li.Value = "LocationwiseWOReport.rpt";
            ddlReportName.Items.Add(li);


        }


    }

    /// <summary>
    /// Controls the Panels Visibilty
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        HideAllControles();
        switch (strReportName)
        {
            case "LocationwiseWOReport.rpt":
                PanelDates.Visible = true;
                break;
            default:
                break;
        }


    }

    #endregion

    #region Bind Controls

    /// <summary>
    /// Handles the TextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtFromDate, lblErrorMsg))
        {
            txtToDate.Text = "";
            lblErrorMsg.Text = "";
            btnViewReport.Enabled = false;
            txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtFromDate, lblErrorMsg))
        {
            btnViewReport.Enabled = true;
            lblErrorMsg.Text = "";
            
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlReportName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ShowHideReportParameterControles();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportTypeMain control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlReportTypeMain_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlReportName();
        ShowHideReportParameterControles();
    }
    
    #endregion

    #region Function Button event
    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();

        if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
        {
            string strReportPagePath = "../Reports/Rostering/";
            Context.Items.Add("cxtReportFileName", strReportName);

            Hashtable hshRptParameters = new Hashtable();
            hshRptParameters = ReportParameter_Get(strReportName);

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroupThailand.aspx?ReportName=" + ddlReportName.SelectedValue.ToString();

            Server.Transfer("../Reports/ViewReport1.aspx");
        }
    }

    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool validateFromToDate()
    {
        if (txtToDate.Text != "" && txtFromDate.Text != "")
        {
            if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                return true;
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                return false;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
            return false;
        }
    }

    /// <summary>
    /// Validates the controles.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateControles(string strReportName)
    {
        switch (strReportName)
        {
            case "LocationwiseWOReport.rpt":
                return validateFromToDate();
            default:
                return false;
        }
    }

    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
           Hashtable hshRptParameters = new Hashtable();
           switch (strReportName)
           {
               case "LocationwiseWOReport.rpt":
                   
                   hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                   hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                   
                   return hshRptParameters;

               default: return hshRptParameters;
           }
    }
    #endregion
}