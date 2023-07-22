// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="dashBoard.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using Resource = Resources.Resource;

/// <summary>
/// Class Testpages_dashBoard.
/// </summary>
public partial class Testpages_dashBoard : BasePage//System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            scheduleAnalysis.Visible=false;
            lblSchAct.Visible = false;
            ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
            txtYear.Text = Convert.ToString(DateTime.Now.Year);
            txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resource.ValidationExpressionNum + ");";
            txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resource.ValidationExpressionNum + ");";
        }
    }

    

    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        FillScheduleAnalisys();
        scheduleAnalysis.Visible = true;
        lblSchAct.Visible = true;
        
    }

    /// <summary>
    /// Fills the schedule analisys.
    /// </summary>
    protected void FillScheduleAnalisys()
    {
        var startDate = new DateTime(Convert.ToInt32(txtYear.Text), Convert.ToInt32(ddlMonth.SelectedValue), 1);
        var endDate = new DateTime(Convert.ToInt32(txtYear.Text), Convert.ToInt32(ddlMonth.SelectedValue),  DateTime.DaysInMonth(Convert.ToInt32(txtYear.Text), Convert.ToInt32(ddlMonth.SelectedValue)));
        hfstartdate.Value = startDate.ToShortDateString();
        hfenddate.Value = endDate.ToShortDateString();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ds = DL.Report.DLEmployeesOfBranch(BaseCompanyCode, int.Parse(BaseLocationAutoID.ToString()), startDate, endDate);
        
        var Employees = ds.Tables[0].AsEnumerable();
        var Requirment = ds.Tables[1].AsEnumerable();


        DataTable dtResult = new DataTable();
        dtResult.Columns.Add(new DataColumn("CompanyCode", typeof(string)));
        dtResult.Columns.Add(new DataColumn("EmployeeCount", typeof(int)));
        dtResult.Columns.Add(new DataColumn("ScheduledEmployeeCount", typeof(int)));
        dtResult.Columns.Add(new DataColumn("NotScheduledEmployeeCount", typeof(int)));
        dtResult.Columns.Add(new DataColumn("RequiredEmployeeCount", typeof(int)));


        var query =
            from EL in Employees
            group EL by EL.Field<string>("CompanyCode")
                into g
                select new
                {
                    CompanyCode = g.Key,
                    EmployeeCount = g.Sum(EL => EL.Field<int>("EmployeeCount")),
                    ScheduledEmployeeCount = g.Sum(EL => EL.Field<int>("ScheduledEmployeeCount")),
                    ActualEmployeeCount = g.Sum(EL => EL.Field<int>("ActualEmployeeCount"))

                };

        foreach (var result in query)
        {

            var query1 =
            from EL in Requirment
                select new
                {
                    RequiredEmployeeCount = EL.Field<int>("ContractedHrs")
                };

            //int RequiredEmployeeCount = 0;
            //foreach (var result1 in query1)
            //{
            //    RequiredEmployeeCount = result1.RequiredEmployeeCount;
            //}
            var requiredEmployeeCount=query1.Count() > 0?query1.ElementAt(0).RequiredEmployeeCount:0;
            
            dtResult.Rows.Add(new object[] { result.CompanyCode, result.EmployeeCount, result.ScheduledEmployeeCount, result.EmployeeCount - result.ScheduledEmployeeCount, requiredEmployeeCount });
        }



        gvEmployees.DataSource = dtResult;
        gvEmployees.DataBind();

        DataTable dtResult1 = new DataTable();
        dtResult1.Columns.Add(new DataColumn("Parameter", typeof(string)));
        dtResult1.Columns.Add(new DataColumn("ScheduledEmployeeCount", typeof(int)));
        dtResult1.Columns.Add(new DataColumn("ActualEmployeeCount", typeof(int)));


        var ScheduledEmpCount2 =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") < 100
            && EL.Field<decimal>("ScheduledHours") > 0
            select new
            {
                ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
            };

        var ActualEmpCount2 =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") < 100
            && EL.Field<decimal>("ActualHours") > 0
            select new
            {
                ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
            };


        var ScheduledEmpCount3 =
           from EL in Employees
           where EL.Field<decimal>("ScheduledHours") >= 100
           && EL.Field<decimal>("ScheduledHours") <= 300
           select new
           {
               ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
           };

        var ActualEmpCount3 =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") >= 100
            && EL.Field<decimal>("ActualHours") <= 300
            select new
            {
                ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
            };

        var ScheduledEmpCount4 =
           from EL in Employees
           where EL.Field<decimal>("ScheduledHours") >= 301
           && EL.Field<decimal>("ScheduledHours") <= 372
           select new
           {
               ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
           };

        var ActualEmpCount4 =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") >= 301
            && EL.Field<decimal>("ActualHours") <= 372
            select new
            {
                ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
            };


        var ScheduledEmpCount5 =
          from EL in Employees
          where EL.Field<decimal>("ScheduledHours") >= 373
          && EL.Field<decimal>("ScheduledHours") <= 450
          select new
          {
              ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
          };

        var ActualEmpCount5 =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") >= 373
            && EL.Field<decimal>("ActualHours") <= 450
            select new
            {
                ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
            };


        var ScheduledEmpCount6 =
          from EL in Employees
          where EL.Field<decimal>("ScheduledHours") > 450
          select new
          {
              ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
          };

        var ActualEmpCount6 =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") > 450
            select new
            {
                ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
            };


        var ScheduledEmpCount7 =
              from EL in Employees
              where EL.Field<decimal>("ScheduledHours") > 0
              select new
              {
                  ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
              };

        var ActualEmpCount7 =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") > 0
            select new
            {
                ScheduledEmployeeCount = EL.Field<string>("EmployeeNumber")
            };



        dtResult1.Rows.Add(new object[] { "Hours < 100", ScheduledEmpCount2.Count(), ActualEmpCount2.Count() });
        dtResult1.Rows.Add(new object[] { "Hours between 100 to 300", ScheduledEmpCount3.Count(), ActualEmpCount3.Count() });
        dtResult1.Rows.Add(new object[] { "Hours between 301 to 372", ScheduledEmpCount4.Count(), ActualEmpCount4.Count() });
        dtResult1.Rows.Add(new object[] { "Hours between 373 to 450", ScheduledEmpCount5.Count(), ActualEmpCount5.Count() });
        dtResult1.Rows.Add(new object[] { "Hours more than 450", ScheduledEmpCount6.Count(), ActualEmpCount6.Count() });
        dtResult1.Rows.Add(new object[] { "Total Count", ScheduledEmpCount7.Count(), ActualEmpCount7.Count() });


        gvScheduleVsActual.DataSource = dtResult1;
        gvScheduleVsActual.DataBind();


    }


    /// <summary>
    /// Handles the RowDataBound event of the gvScheduleVsActual control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleVsActual_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            LinkButton gvScheduledEmpCount = (LinkButton)e.Row.FindControl("gvScheduledEmpCount");
            LinkButton gvActualEmpCount = (LinkButton)e.Row.FindControl("gvActualEmpCount");
            
            gvScheduledEmpCount.Attributes["onClick"] = "javascript:openpage('1'," + (e.Row.RowIndex + 1) + ");";
            gvActualEmpCount.Attributes["onClick"] = "javascript:openpage('2'," + (e.Row.RowIndex + 1) + ");";
                   
        }


    }


}