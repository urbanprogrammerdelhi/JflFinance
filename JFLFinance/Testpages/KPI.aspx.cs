// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="KPI.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using Microsoft.Reporting.WebForms;

/// <summary>
/// Class Testpages_KPI.
/// </summary>
public partial class Testpages_KPI : BasePage
{
    /// <summary>
    /// The report parameters
    /// </summary>
    public ReportParameterInfoCollection ReportParameters;
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string strReportPagePath = "../Reports/Rostering/";
        Context.Items.Add("cxtReportFileName", "KPI1");

        //System.Collections.Generic.List<ReportParameter> hshRptParameters = new System.Collections.Generic.List<ReportParameter>();
        //hshRptParameters = ReportParameter_Get("KPI1");
        //Context.Items.Add("cxtHashParameters", hshRptParameters);
        //Context.Items.Add("cxtReportID", "ReportID");
        //Context.Items.Add("cxtReportPagePath", strReportPagePath);
        //Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_ScheduleKenya.aspx";
        //Server.Transfer("~/Reports/ViewReport.aspx");

        ReportViewer1.ShowExportControls = true;
        ReportViewer1.ShowParameterPrompts = false;
        ReportViewer1.ServerReport.ReportPath = "/" + "MagnonReportsVersion5" + "/" + "KPI1";
        ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://192.168.0.205:80/reportserver");
       // ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(".", "Password@0165", "indel09");
        ReportParameters = (ReportParameterInfoCollection)this.ReportViewer1.ServerReport.GetParameters();
        ReportViewer1.ServerReport.Refresh();

    }

    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>System.Collections.Generic.List&lt;ReportParameter&gt;.</returns>
    private System.Collections.Generic.List<ReportParameter> ReportParameter_Get(string strReportName)
    {

        Hashtable hshRptParameters = new Hashtable();
        System.Collections.Generic.List<ReportParameter> aParamList = new System.Collections.Generic.List<ReportParameter>();

        switch (strReportName)
        {
            case "KPI1":
               // aParamList.Add(new ReportParameter());
                aParamList.Add(new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), ""));
                //aParamList.Add(new ReportParameter(DL.Properties.Resources.AreaIncharge.Remove(0, 1), ddlAreaIncharge.SelectedItem.Value.ToString()));
                //aParamList.Add(new ReportParameter(DL.Properties.Resources.ShiftCode.Remove(0, 1), DDLShiftCode.SelectedValue));
                //aParamList.Add(new ReportParameter("BlankRows", txtBlankRows.Text));
                //aParamList.Add(new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text.ToString(), new System.Globalization.CultureInfo("en-US"))));
                //aParamList.Add(new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text.ToString(), new System.Globalization.CultureInfo("en-US"))));
                //aParamList.Add(new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name));

                return aParamList;
            default: return aParamList;
        }
    }
}