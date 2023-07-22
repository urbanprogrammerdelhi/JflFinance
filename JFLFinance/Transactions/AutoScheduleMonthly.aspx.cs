// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="AutoScheduleMonthly.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

/// <summary>
/// Class Transactions_AutoScheduleMonthly.
/// </summary>
public partial class Transactions_AutoScheduleMonthly : BasePage
{
    private string baseLocationAutoID;
    private string baseCompanyCode;
    private string baseUserID;

    private string baseUserEmployeeNumber;
    private string baseUserIsAreaIncharge;
    private string baseConnection;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillddlClient();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();

            //var objCon = new DL.ConnectionString();
            //key.Value = objCon.ConnectionStringGet(BaseCountryCode);
            Session["complete"] = false;
        }
        baseLocationAutoID = BaseLocationAutoID;
        baseCompanyCode = BaseCompanyCode;
        baseUserID = BaseUserID;

        var objCon = new DL.ConnectionString();
        baseConnection = objCon.ConnectionStringGet(BaseCountryCode);

        baseUserEmployeeNumber = BaseUserEmployeeNumber;
        baseUserIsAreaIncharge = BaseUserIsAreaIncharge;
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    private void FillddlAsmt()
    {
        //ddlAsmt.ClearAllItems();

        var objOperationManagement = new BL.OperationManagement();


        DataSet dsAsmt = objOperationManagement.AssignmentsOfSelectedClientGet(int.Parse(BaseLocationAutoID), ddlClient.sValue);
        if (dsAsmt.Tables[0].Rows.Count > 0)
        {
            DataRow dr = dsAsmt.Tables[0].NewRow();
            dr["AsmtDetailWithClient"] = "All";
            dr["AsmtCodeWithClient"] = "All";
            dsAsmt.Tables[0].Rows.InsertAt(dr, 0);
            //Modify by  on 20-Jun-2013
            //ddlAsmt.CreateCheckBox(dsAsmt.Tables[0], "AsmtDetail", "AsmtCode");
            ddlAsmt.CreateCheckBox(dsAsmt.Tables[0], "AsmtDetailWithClient", "AsmtCodeWithClient");
        }
        //Added Else by Manish 12-Aug-2013
        else
        {
            ddlAsmt.CreateCheckBox(dsAsmt.Tables[0], "AsmtDetailWithClient", "AsmtCodeWithClient");
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.ClientGetBasedOnClientCode(BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr["ClientNameCode"] = "All";
            dr["ClientCode"] = "All";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            ddlClient.CreateCheckBox(ds.Tables[0], "ClientNameCode", "ClientCode");

        }

    }
    /// <summary>
    /// Fillddls the post.
    /// </summary>
    private void FillddlPost()
    {
        var objMasterManagement = new BL.MastersManagement();
        DataSet dspost = objMasterManagement.SelectedAsmtPostGet(BaseLocationAutoID, ddlClient.sValue, ddlAsmt.sValue);
        if (dspost.Tables[0].Rows.Count > 0)
        {
            DataRow dr = dspost.Tables[0].NewRow();
            dr["PostDesc"] = "All";
            dr["PostCode"] = "All";
            dspost.Tables[0].Rows.InsertAt(dr, 0);
            ddlPost.CreateCheckBox(dspost.Tables[0], "PostDesc", "PostCode");
        }
        else
        {
            ddlPost.CreateCheckBox(dspost.Tables[0], "PostDesc", "PostCode");
        }
    }
    /// <summary>
    /// Handles the Click event of the btnGoClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGoClient_Click(object sender, EventArgs e)
    {
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the Click event of the btnGoAsmt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGoAsmt_Click(object sender, EventArgs e)
    {
        FillddlPost();
    }
    /// <summary>
    /// Fillgvs the employee automatic schedule.
    /// </summary>
    private void FillgvEmployeeAutoSchedule(string status)
    {
        if (ddlAsmt.sValue.Length == 0 || ddlPost.sValue.Length == 0)
        {
            return;
        }
        int dtflag = 1;
        var objRoster = new BL.Roster();
        var objCon = new DL.ConnectionString();
        DataSet ds = objRoster.GetEmployeeScheduleFinished(baseConnection, baseLocationAutoID, ddlClient.sValue, ddlAsmt.sValue, ddlPost.sValue, ddlYear.SelectedValue, ddlMonth.SelectedValue, baseUserEmployeeNumber, baseUserIsAreaIncharge, status);

        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvEmployeeAutoSchedule.DataKeyNames = new[] { "EmployeeNumber" };
        gvEmployeeAutoSchedule.DataSource = dt;
        gvEmployeeAutoSchedule.DataBind();
        if (dtflag == 0)
        {
            gvEmployeeAutoSchedule.Rows[0].Visible = false;
        }

    }
    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        FillgvEmployeeAutoSchedule("P");

    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmployeeAutoSchedule control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeAutoSchedule_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvEmployeeAutoSchedule.PageIndex = e.NewPageIndex;
        gvEmployeeAutoSchedule.EditIndex = -1;
        FillgvEmployeeAutoSchedule("P");

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvEmployeeAutoSchedule control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeAutoSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvEmployeeAutoSchedule.PageIndex * gvEmployeeAutoSchedule.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        string[] arr = txt1.Text.Split('$');
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var hfSchRosterAutoId = (HiddenField)e.Row.FindControl("hfSchRosterAutoId");
            var lblMessage = (Label)e.Row.FindControl("lblMessage");

            if (lblMessage != null)
            {
                if (lblMessage.Text != "")
                {
                    string[] arr1 = lblMessage.Text.Split('$');
                    lblMessage.Text = ResourceValueOfKey_Get(arr1[1]) + @"(" + arr1[2] + @")";
                }
            }

            if (txt1.Text.Length > 0)
            {
                for (int i = 0; i < arr.Length - 1; i = i + 2)
                {
                    if (arr[i] == hfSchRosterAutoId.Value)
                    {
                        if (lblMessage != null && lblMessage.Text == "")
                        {
                            lblMessage.Text = arr[i + 1];
                        }
                    }
                }
            }
        }

    }

    ///// <summary>
    ///// Handles the Click event of the btnAutoSchedule control.
    ///// </summary>
    ///// <param name="sender">The source of the event.</param>
    ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAutoSchedule_Click(object sender, EventArgs e)
    {
        var lblEmployeeNumber = (Label)gvEmployeeAutoSchedule.Rows[0].FindControl("lblEmployeeNumber");
        if (lblEmployeeNumber != null)
        {
            if (lblEmployeeNumber.Text == string.Empty)
            {
                return;
            }
        }

        //Start the Process   
        lock (Session.SyncRoot)
        {
            Session["complete"] = false;
            Session["status"] = "";
            Session["Message"] = "";
            Session["culture"] = Thread.CurrentThread.CurrentCulture;
        }

        var t = new Thread(new ParameterizedThreadStart(ThreadProcess));
        t.Start(Session);

        //Switch the View   
        mvvProcess.SetActiveView(vProgress);
        timUpdate.Enabled = true;
    }


    ///// <summary>
    ///// Threads the process.
    ///// </summary>
    ///// <param name="data">The data.</param>
    private void ThreadProcess(object data)
    {
        var s = (System.Web.SessionState.HttpSessionState)data;
        for (int i = 0; i < gvEmployeeAutoSchedule.Rows.Count; i++)
        {
            var cbCheck = (CheckBox)gvEmployeeAutoSchedule.Rows[i].FindControl("cbCheck");
            if (cbCheck.Checked)
            {
                var lblEmployeeNumber = (Label)gvEmployeeAutoSchedule.Rows[i].FindControl("lblEmployeeNumber");
                var hfAsmtCode = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfAsmtCode");
                var lblDutyDate = (Label)gvEmployeeAutoSchedule.Rows[i].FindControl("lblDutyDate");
                var hfRowNumber = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfRowNumber");
                var lblSequence = (Label)gvEmployeeAutoSchedule.Rows[i].FindControl("lblSequence");
                //Label lblgvhdrSerialNo = (Label)gvEmployeeAutoSchedule.Rows[i].FindControl("lblgvhdrSerialNo");
                var hfSchRosterAutoId = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfSchRosterAutoId");
                var hfClientCode = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfClientCode");
                var hfSoNo = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfSoNo");
                var hfSoLineNo = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfSoLineNo");
                var hfSoRank = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfSoRank");
                var hfPostAutoId = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfPostAutoId");
                var hfPatternPosition = (HiddenField)gvEmployeeAutoSchedule.Rows[i].FindControl("hfPatternPosition");


                lock (s.SyncRoot)
                {
                    s["status"] = @"Running: " + (i + 1);
                }
                var objRoster = new BL.Roster();
                try
                {
                    Thread.CurrentThread.CurrentCulture = (CultureInfo)Session["culture"];
                    var objCon = new DL.ConnectionString();
                    DataSet ds = objRoster.AutoScheduleEmployee(baseConnection, baseLocationAutoID, baseCompanyCode, hfClientCode.Value, hfAsmtCode.Value, "", lblEmployeeNumber.Text, lblSequence.Text, lblDutyDate.Text, hfRowNumber.Value, baseUserID, hfSoNo.Value, hfSoLineNo.Value, hfSoRank.Value, int.Parse(hfPostAutoId.Value), int.Parse(hfPatternPosition.Value), baseUserEmployeeNumber, baseUserIsAreaIncharge);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)// && ds.Tables[0].Rows[0][0].ToString() != "1")
                    {

                        Session["Message"] = Session["Message"] + hfSchRosterAutoId.Value + "$" +
                                             ds.Tables[0].Rows[0][1] + "$";
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLog(ex);
                }
            }
        }
        //if (s.IsSynchronized)
        {
            Session["complete"] = true;
        }
    }



    ///// <summary>
    ///// Handles the Tick event of the timUpdate control.
    ///// </summary>
    ///// <param name="sender">The source of the event.</param>
    ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void timUpdate_Tick(object sender, EventArgs e)
    {
        Label1.Text = Session["status"].ToString();
        if (bool.Parse(Session["complete"].ToString()))
        {
            timUpdate.Enabled = false;
            txt1.Text = Session["Message"].ToString();
            Session["Message"] = "";
            FillgvEmployeeAutoSchedule("");
            txt1.Text = "";
            mvvProcess.SetActiveView(vLaunch);
        }
    }
}
