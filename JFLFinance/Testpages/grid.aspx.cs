// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="grid.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Testpages_grid.
/// </summary>
public partial class Testpages_grid : BasePage//System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        var startdate = Convert.ToDateTime(Request.QueryString["startdate"].ToString());
        var enddate = Convert.ToDateTime(Request.QueryString["enddate"].ToString());
        ds = DL.Report.DLEmployeesOfBranch(BaseCompanyCode, int.Parse(BaseLocationAutoID.ToString()), startdate, enddate);

        var Employees = ds.Tables[0].AsEnumerable();

        string Id = Request.QueryString["id"].ToString();
        string Id1 = Request.QueryString["id1"].ToString();


        DataTable dtResult = new DataTable();
        dtResult.Columns.Add(new DataColumn("LocationDesc", typeof(string)));
        dtResult.Columns.Add(new DataColumn("EmployeeNumber", typeof(string)));
        dtResult.Columns.Add(new DataColumn("EmployeeName", typeof(string)));

        if (Id == "1" && Id1 == "0")
        {
            dtResult.Columns.Add(new DataColumn("Designationdesc", typeof(string)));
            var query =
            from EL in Employees
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                DesignationDesc = EL.Field<string>("Designationdesc")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.DesignationDesc });

            }
        }
        else if (Id == "2" && Id1 == "0")
        {
            dtResult.Columns.Add(new DataColumn("ScheduledHours", typeof(decimal)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") > 0
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ScheduledHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "3" && Id1 == "0")
        {
            dtResult.Columns.Add(new DataColumn("Designationdesc", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") <= 0
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                DesignationDesc = EL.Field<string>("Designationdesc")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.DesignationDesc });

            }

        }
        else if (Id == "1" && Id1 == "1")
        {
            dtResult.Columns.Add(new DataColumn("ScheduledHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") < 100
            && EL.Field<decimal>("ScheduledHours") > 0
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ScheduledHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "2" && Id1 == "1")
        {
            dtResult.Columns.Add(new DataColumn("ScheduledHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") >= 100
            && EL.Field<decimal>("ScheduledHours") <= 300
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ScheduledHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "3" && Id1 == "1")
        {
            dtResult.Columns.Add(new DataColumn("ScheduledHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") >= 301
            && EL.Field<decimal>("ScheduledHours") <= 372
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ScheduledHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "4" && Id1 == "1")
        {
            dtResult.Columns.Add(new DataColumn("ScheduledHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") >= 373
            && EL.Field<decimal>("ScheduledHours") <= 450
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ScheduledHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "5" && Id1 == "1")
        {
            dtResult.Columns.Add(new DataColumn("ScheduledHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") > 450
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ScheduledHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "6" && Id1 == "1")
        {
            dtResult.Columns.Add(new DataColumn("ScheduledHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ScheduledHours") > 0
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ScheduledHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        } //
        else if (Id == "1" && Id1 == "2")
        {
            dtResult.Columns.Add(new DataColumn("ActualHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") < 100
            && EL.Field<decimal>("ActualHours") > 0
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ActualHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "2" && Id1 == "2")
        {
            dtResult.Columns.Add(new DataColumn("ActualHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") >= 100
            && EL.Field<decimal>("ActualHours") <= 300
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ActualHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "3" && Id1 == "2")
        {
            dtResult.Columns.Add(new DataColumn("ActualHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") >= 301
            && EL.Field<decimal>("ActualHours") <= 372
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ActualHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "4" && Id1 == "2")
        {
            dtResult.Columns.Add(new DataColumn("ActualHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") >= 373
            && EL.Field<decimal>("ActualHours") <= 450
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ActualHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "5" && Id1 == "2")
        {
            dtResult.Columns.Add(new DataColumn("ActualHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") > 450
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ActualHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }
        else if (Id == "6" && Id1 == "2")
        {
            dtResult.Columns.Add(new DataColumn("ActualHours", typeof(string)));
            var query =
            from EL in Employees
            where EL.Field<decimal>("ActualHours") > 0
            select new
            {
                LocationDesc = EL.Field<string>("LocationDesc"),
                EmployeeNumber = EL.Field<string>("EmployeeNumber"),
                EmployeeName = EL.Field<string>("EmployeeName"),
                ScheduledHours = EL.Field<decimal>("ActualHours")

            };

            foreach (var result in query)
            {
                dtResult.Rows.Add(new object[] { result.LocationDesc, result.EmployeeNumber, result.EmployeeName, result.ScheduledHours });

            }

        }

        grid.DataSource = dtResult;
        grid.DataBind();


    }

    /// <summary>
    /// Handles the submit event of the btn control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btn_submit(object sender, EventArgs e)
    {

        ASPxGridViewExporter1.GridViewID = "grid";
        ASPxGridViewExporter1.WriteCsvToResponse();

    }
}