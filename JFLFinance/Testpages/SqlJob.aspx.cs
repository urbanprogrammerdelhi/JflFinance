// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SqlJob.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Common;


/// <summary>
/// Class Testpages_SqlJob.
/// </summary>
public partial class Testpages_SqlJob : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

  
            try
            {
                //string strConnectionString = @"IsraelCon";
                
                string strJobName = "Test";

                 DL.ConnectionString con = new DL.ConnectionString();
                 string strConnectionString = con.GetConnectionString();
                 string connect = con.ConnectionStringGet(strConnectionString);
                 using (SqlConnection oConnection = new SqlConnection(connect))
                 {
                     // string oConnection = con.ConnectionStringGet(strConnectionString);



                     ServerConnection serverConnection = new ServerConnection(oConnection);
                     Server oSqlServer = new Server(serverConnection);
                     JobServer oAgent = oSqlServer.JobServer;
                     Job oJob = oAgent.Jobs[strJobName];
                     JobHistoryFilter oFilter = new JobHistoryFilter();
                     //oFilter.JobName = strJobName;
                     //DateTime oLastRunDate = oLastRunDate = oJob.LastRunDate;
                     oJob.Start();

                     //while (oLastRunDate == oJob.LastRunDate)
                     //{
                     //    oJob.Refresh();
                     //}
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    
    }



