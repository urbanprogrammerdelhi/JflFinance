// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="UploadLeaves.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Masters_UploadLeaves
/// </summary>
public partial class Masters_UploadLeaves : BasePage
{
    /// <summary>
    /// The dt duplicate emp
    /// </summary>
    static DataTable dtDuplicateEmp = new DataTable();
    /// <summary>
    /// The dt uploaded emp
    /// </summary>
    static DataTable dtUploadedEmp = new DataTable();

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillFromLocation();
            FillToLocation();
            FillLeaveCal();
        }
    }
    /// <summary>
    /// Fills from location.
    /// </summary>
    protected void FillFromLocation()
    {
        DataSet ds = new DataSet();
        BL.Interface obj = new BL.Interface();
        ds = obj.GetLocationfromAusServer("0");// (ddlEmployee.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlFromLocation.DataSource = ds.Tables[0];
            ddlFromLocation.DataValueField = "LocationCode";
            ddlFromLocation.DataTextField = "LocationCode";
            ddlFromLocation.DataBind();
        }
    }
    /// <summary>
    /// Fills the leave cal.
    /// </summary>
    protected void FillLeaveCal()
    {
        ddlLeaveCal.Items.Clear();
        DataSet ds = new DataSet();
        BL.Interface obj = new BL.Interface();
        ds = obj.GetLeaveCal(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlLeaveCal.DataSource = ds.Tables[0];
            ddlLeaveCal.DataValueField = "Leave_Cal_Code";
            ddlLeaveCal.DataTextField = "Leave_Cal_Desc";
            ddlLeaveCal.DataBind();
        }
    }
    /// <summary>
    /// Fills to location.
    /// </summary>
    protected void FillToLocation()
    {
        DataSet ds = new DataSet();
        BL.Interface obj = new BL.Interface();
        ds = obj.GetAllLoction(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtToLocation.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Interface obj = new BL.Interface();

        ds = obj.UploadLeaves(ddlFromLocation.SelectedValue, BaseLocationAutoID, "0", ddlLeaveCal.SelectedValue, "", BaseUserID);

        dtDuplicateEmp = ds.Tables[0];
        dtUploadedEmp = ds.Tables[1];
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblDuplicateEmployees.Text = ds.Tables[0].Rows[0]["Total"].ToString();
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            lblUploadedEmployees.Text = ds.Tables[1].Rows[0]["Total"].ToString();
        }
    }

    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {        
        DataSet ds = new DataSet();
        BL.Interface obj = new BL.Interface();

        if (ddlFromLocation.SelectedValue == null)
        {
            lblErrorMsg.Text = "Please Select PayGlobal Branch";
            return;
        }


        ds = obj.UpdateUploadLeaves(ddlFromLocation.SelectedValue, BaseLocationAutoID, "0", ddlLeaveCal.SelectedValue, "", BaseUserID);

        dtDuplicateEmp = ds.Tables[0];
        dtUploadedEmp = ds.Tables[1];
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblDuplicateEmployees.Text = ds.Tables[0].Rows[0]["Total"].ToString();
        }
        else
        {
            lblDuplicateEmployees.Text = "New Employee(s) Leave Inserted : 0";
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            lblUploadedEmployees.Text = ds.Tables[1].Rows[0]["Total"].ToString();
        }
        else
        {
            lblUploadedEmployees.Text = "Updated Employees : 0";
        }

    }    
}
