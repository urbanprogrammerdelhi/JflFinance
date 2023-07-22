// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SwapDuty.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_SwapDuty.
/// </summary>
public partial class Transactions_SwapDuty : BasePage
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
            if (Request.QueryString["ScheduleRosterAutoID"] != null)
            {
                GetEmployeeDetailBasedOnRosterAutoID(Request.QueryString["ScheduleRosterAutoID"].ToString());
                ///txtNewDutyDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                lblClientName.Text = Request.QueryString["ClientName"].ToString();
                lblAsmtName.Text = Request.QueryString["AsmtName"].ToString();
                lblPostDesc.Text = Request.QueryString["PostDesc"].ToString();

                FillClients();

                //
            }
        }
    }

    /// <summary>
    /// Fills the clients.
    /// </summary>
    private void FillClients()
    {
        var objRoster = new BL.Roster();

        using (DataSet ds = objRoster.GetClientForSwapDuty(BaseLocationAutoID, Request.QueryString["Area"].ToString(), "", BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), txtNewDutyDate.Text, txtNewDutyDate.Text))
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                ddlClient.DataSource = ds;
                ddlClient.DataTextField = "ClientCodeName";
                ddlClient.DataValueField = "ClientCode";
                ddlClient.DataBind();
                ddlClient.SelectedIndex = 0;
                FillddlAsmtCode();
            }
        }
    }

    /// <summary>
    /// Fillddls the asmt code.
    /// </summary>
    private void FillddlAsmtCode()
    {
        var objOperationManagement = new BL.OperationManagement();
        var FromDate = txtNewDutyDate.Text;
        var ToDate = txtNewDutyDate.Text;
        using (DataSet ds = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), ddlClient.SelectedValue, txtNewDutyDate.Text, txtNewDutyDate.Text, BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), Request.QueryString["Area"]))
        {
            ddlAsmtCode.DataSource = ds.Tables[0];
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();
            ddlAsmtCode.SelectedIndex = 0;
            FillPost();
            //FillEmployeeDetail();
        }

    }

    /// <summary>
    /// Fills the post.
    /// </summary>
    private void FillPost()
    {
        var objRoster = new BL.Roster();
        using (DataSet ds = objRoster.PostGetAll(ddlClient.SelectedValue, ddlAsmtCode.SelectedValue, BaseLocationAutoID, txtNewDutyDate.Text, txtNewDutyDate.Text))
        {
            ddlPost.DataSource = ds.Tables[0];
            ddlPost.DataTextField = "Post";
            ddlPost.DataValueField = "PostAutoID";
            ddlPost.DataBind();
            ddlPost.SelectedIndex = 0;
            FillEmployeeDetail();
        }

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPost();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmtCode();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPost_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillEmployeeDetail();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployee control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillShiftCode();
    }


    /// <summary>
    /// Handles the TextChanged event of the txtNewDutyDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewDutyDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FillClients();
            // FillddlAsmtCode();
            //EmptyTextBox();
        }
        catch (Exception ex)
        {
            Show(Resources.Resource.InvalidDate);
        }
    }


    /// <summary>
    /// Gets the employee detail based on roster auto ID.
    /// </summary>
    /// <param name="strRosterAutoID">The STR roster auto ID.</param>
    private void GetEmployeeDetailBasedOnRosterAutoID(string strRosterAutoID)
    {
        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        ds = objRoster.TranRosterEmployeeWiseGetAllBasedOnRosterAutoId(strRosterAutoID, BaseLocationAutoID);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            txtSwapEmployee.Text = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
            txtSwapEmployeeName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
            txtCurrentDutyDate.Text = ds.Tables[0].Rows[0]["DutyDate"].ToString();
            txtNewDutyDate.Text = txtCurrentDutyDate.Text;
            txtCurrentShift.Text = ds.Tables[0].Rows[0]["ShiftCode"].ToString();
            txtSwapTimeFrom.Text = ds.Tables[0].Rows[0]["TimeFrom"].ToString();
            txtSwapTimeTo.Text = ds.Tables[0].Rows[0]["TimeTo"].ToString();
        }

    }
    /// <summary>
    /// Handles the TextChanged event of the txtEmpNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmpNumber_TextChanged(object sender, EventArgs e)
    {



    }
    /// <summary>
    /// Gets the shift code.
    /// </summary>
    protected void getShiftCode()
    {
        //DataSet ds = new DataSet();
        //BL.Roster obj = new BL.Roster();
        //ds = obj.blShiftCode_get(BaseLocationAutoID, AsmtCode, txtSwapEmployee.Text, txtCurrentDutyDate.Text);
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    txtCurrentShift.Text = ds.Tables[0].Rows[0]["ShiftCode"].ToString();
        //}
        //else
        //{
        //    txtCurrentShift.Text = "";
        //}
    }

    /// <summary>
    /// Empties the text box.
    /// </summary>
    private void EmptyTextBox()
    {
        //txtNewEmployeeNumber.Text = "";
        //txtNewEmployeeName.Text = "";
    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewEmployeeNumber_TextChanged(object sender, EventArgs e)
    {
        //lblErrorMsg.Text = "";
        //DataSet ds = new DataSet();
        //BL.HRManagement obj = new BL.HRManagement();
        //ds = obj.MstHrEmployeeDetailGetSelected(BaseLocationAutoID, txtNewDutyDate.Text, ddlClient.SelectedValue.ToString(), ddlAsmtCode.SelectedValue.ToString(), ddlPost.SelectedValue.ToString());
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    txtNewEmployeeName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
        //    FillShiftCode();
        //    btnSave.Enabled = true;
        //}
        //else
        //{
        //    txtNewEmployeeNumber.Text = "";
        //    txtNewEmployeeName.Text = "";
        //    ddlNewShift.Items.Clear();
        //    lblErrorMsg.Text = "Wrong Employee Number !!!";
        //}
    }
    /// <summary>
    /// Fills the employee detail.
    /// </summary>
    private void FillEmployeeDetail()
    {
        var obj = new BL.HRManagement();
        ddlEmployee.Items.Clear();
        ddlEmployee.Text = "";
        ddlNewShift.Items.Clear();
        using (DataSet ds = obj.MstHrEmployeeDetailGetSelected(BaseLocationAutoID, txtNewDutyDate.Text, ddlClient.SelectedValue.ToString(), ddlAsmtCode.SelectedValue.ToString(), ddlPost.SelectedValue.ToString()))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlEmployee.DataSource = ds.Tables[0];
                ddlEmployee.DataTextField = "EmployeeName";
                ddlEmployee.DataValueField = "EmployeeNumber";
                ddlEmployee.DataBind();
            }
        }
    }
    /// <summary>
    /// Fills the shift code.
    /// </summary>
    private void FillShiftCode()
    {

        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        ddlNewShift.Items.Clear();
        ds = objRoster.NewShiftCodeGet(BaseLocationAutoID, ddlClient.SelectedValue, ddlAsmtCode.SelectedValue.ToString(),ddlPost.SelectedValue, ddlEmployee.SelectedValue, txtNewDutyDate.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlNewShift.DataSource = ds.Tables[0];
            ddlNewShift.DataValueField = "RosterAutoID";
            ddlNewShift.DataTextField = "ShiftCode";
            ddlNewShift.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = "Blank";
            li.Value = "=";
            ddlNewShift.Items.Insert(0, li);
        }
    }

    //protected void ddlEmployeeNumber_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    FillShiftCode();
    //}


    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string SwappedBy;
        if (ddlEmployee.SelectedValue == "")
        {
            return;
        }
        if (rbManager.Checked == true)
        {
            SwappedBy = "M";
        }
        else
        {
            SwappedBy = "S";
        }

        BL.Roster obj = new BL.Roster();
        DataSet ds = new DataSet();
        string strCurrentRosterAutoID = Request.QueryString["ScheduleRosterAutoID"].ToString();
        ds = obj.SwapDutyInsert(BaseLocationAutoID, strCurrentRosterAutoID, ddlNewShift.SelectedValue.ToString(), BaseUserID, ddlEmployee.SelectedValue,ddlClient.SelectedValue, ddlAsmtCode.SelectedValue.ToString(),ddlPost.SelectedValue, txtNewDutyDate.Text, SwappedBy);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Status"].ToString().Trim().ToLower() != "DUPLICATE".Trim().ToLower())
            {
                lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["Status"].ToString());
                //this.Page.RegisterStartupScript("ABC", "<script language='javascript' type='text/javascript'> window.close();</script>");
            }
            else
            {
                //this.Page.RegisterStartupScript("ABC", "<script language='javascript' type='text/javascript'> window.focus();</script>");
                lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["Status"].ToString());
            }
        }
        else
        {
            //lblErrorMsg.Text = ds.Tables[0].Rows[0]["Status"].ToString(); 
            //btnSave.Enabled = true;
        }

    }



}
