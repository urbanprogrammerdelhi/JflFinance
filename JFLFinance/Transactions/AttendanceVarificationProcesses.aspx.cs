// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="AttendanceVarificationProcesses.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved. 
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using eis = Telerik.Web.UI.ExportFormat;
using System.Web;

/// <summary>
/// Class Transactions_AttendanceVarificationProcesses.
/// </summary>
public partial class Transactions_AttendanceVarificationProcesses : BasePage//System.Web.UI.Page
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
        try
        {



            if (!IsPostBack)
            {
                Response.Write(new string(' ', 256));
                Response.Flush();

                DataTable dtInvalidRecords = MyDataTable();
                BL.BusinessRule objBr = new BL.BusinessRule();
                string businessRuleCode = Request.QueryString["BR"].ToString();
                string fromDate = Request.QueryString["fdate"].ToString();
                string toDate = Request.QueryString["tdate"].ToString();


                DataSet dsProcess = new DataSet();
                bool IsDataReadytoProceed = true;

                if (Request.QueryString["ptype"].ToString().ToUpper() == "PR")
                {
                    try
                    {
                        BL.Roster objRost = new BL.Roster();
                        UpdateProgress(0, "processing start...");
                        dsProcess = objRost.EmployeeAttendanceProcess(BaseCompanyCode, businessRuleCode, DateTime.Parse(fromDate).ToString("dd-MMM-yyyy"), DateTime.Parse(toDate).ToString("dd-MMM-yyyy"), BaseUserID.ToString());
                        UpdateProgress(10000, Resources.Resource.ProcessCompleted);
                    }
                    catch (Exception ex)
                    {
                        UpdateProgress(10000, Resources.Resource.MsgUnknownError + " " + ex.Message.ToString());
                    }

                    return;

                }
                else if (Request.QueryString["ptype"].ToString().ToUpper() == "SPP")
                {
                    try
                    {
                        BL.Roster objRost = new BL.Roster();
                        UpdateProgress(0, "processing start...");
                        dsProcess = objRost.GeneratePaysumIsrael(businessRuleCode, DateTime.Parse(fromDate).ToString("dd-MMM-yyyy"), DateTime.Parse(toDate).ToString("dd-MMM-yyyy"), "3",BaseCompanyCode);
                        UpdateProgress(10000, Resources.Resource.ProcessCompleted);
                    }
                    catch
                    {
                        UpdateProgress(10000, Resources.Resource.MsgUnknownError);
                    }

                    return;

                }




                dsProcess = objBr.PaysumReadynessProcessesGet(businessRuleCode);
                if (dsProcess != null && dsProcess.Tables.Count > 0 && dsProcess.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsProcess.Tables[0].Rows.Count; i++)
                    {
                        UpdateProgress(0, dsProcess.Tables[0].Rows[i]["ProcessDesc"].ToString() + " Start...");
                        System.Threading.Thread.Sleep(200);

                        DataSet ds = objBr.PaysumReadynessProcessesExecute(BaseCompanyCode, businessRuleCode, fromDate, toDate, dsProcess.Tables[0].Rows[i]["ProcessLogic"].ToString());

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (dsProcess.Tables[0].Rows[i]["ImplementationStatus"].ToString() == "2")
                            {
                                IsDataReadytoProceed = false;
                            }

                            foreach (DataRow sourcerow in ds.Tables[0].Rows)
                            {

                                DataRow destRow = dtInvalidRecords.NewRow();
                                destRow["ProcessName"] = dsProcess.Tables[0].Rows[i]["ProcessDesc"].ToString();
                                destRow["Comment"] = sourcerow["Comment"];

                                if (ds.Tables[0].Columns["EmployeeNumber"] != null)
                                {
                                    destRow["EmployeeNumber"] = sourcerow["EmployeeNumber"];
                                }
                                if (ds.Tables[0].Columns["AsmtCode"] != null)
                                {
                                    destRow["AsmtCode"] = sourcerow["AsmtCode"];
                                }
                                if (ds.Tables[0].Columns["LocationCode"] != null)
                                {
                                    destRow["LocationCode"] = sourcerow["LocationCode"];
                                }
                                if (ds.Tables[0].Columns["totalHours"] != null)
                                {
                                    destRow["TotalHours"] = sourcerow["totalHours"];
                                }

                                dtInvalidRecords.Rows.Add(destRow);
                                dtInvalidRecords.AcceptChanges();
                            }
                        }

                        UpdateProgress(0, dsProcess.Tables[0].Rows[i]["ProcessDesc"].ToString() + " Completed");
                        System.Threading.Thread.Sleep(200);

                    }
                }
                else
                {
                    UpdateProgress(0, "Paysum readyness processes are not set!");
                }

                UpdateProgress(0, "Verification Process complete");
                if (IsDataReadytoProceed)
                {
                    UpdateProgress(1, "Verification Process complete");
                }

                ViewState["dataSource"] = dtInvalidRecords;
                gvPaysumReadyness.DataSource = dtInvalidRecords;
                gvPaysumReadyness.DataBind();

                if (IsDataReadytoProceed)
                {

                }

            }
        }
        catch(HttpException ex)
        {
            if (ex.Message.Contains("The remote host closed the connection"))
             lblErrorMsg.Text  = "Dont close the file Intermittently before the write happens";}
        
            catch(Exception )
           {
               lblErrorMsg.Text = "Dont close the file Intermittently before the write happens";
            
            }
    }

    /// <summary>
    /// fill grid
    /// </summary>
    private void FillGrid()
    {
        DataTable dtInvalidRecords = MyDataTable();
        dtInvalidRecords = (DataTable)ViewState["dataSource"];
        gvPaysumReadyness.DataSource = dtInvalidRecords;
        //// gvPaysumReadyness.DataBind();
    }

    /// <summary>
    /// Handles the NeedDataSource event of the gvPaysumReadyness control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void gvPaysumReadyness_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        FillGrid();
    }

    /// <summary>
    /// update progress
    /// </summary>
    /// <param name="PercentComplete">The percent complete.</param>
    /// <param name="Message">The message.</param>
    protected void UpdateProgress(int PercentComplete, string Message)
    {
        // Write out the parent script callback.
        Response.Write(String.Format(
          "<script>parent.UpdateProgress({0}, '{1}');</script>",
          PercentComplete, Message));
        // To be sure the response isn't buffered on the server.
        //Response.Flush();
    }


    /// <summary>
    /// return table structure
    /// </summary>
    /// <returns>DataTable.</returns>
    private DataTable MyDataTable()
    {

        DataTable myTable = new DataTable();
        myTable.Columns.Add(new DataColumn("ProcessName", typeof(string)));
        myTable.Columns.Add(new DataColumn("Comment", typeof(string)));
        myTable.Columns.Add(new DataColumn("EmployeeNumber", typeof(string)));
        myTable.Columns.Add(new DataColumn("LocationCode", typeof(string)));
        myTable.Columns.Add(new DataColumn("AsmtCode", typeof(string)));
        myTable.Columns.Add(new DataColumn("TotalHours", typeof(decimal)));

        return myTable;

    }

}