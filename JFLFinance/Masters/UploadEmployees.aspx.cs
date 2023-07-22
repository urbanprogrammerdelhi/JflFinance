// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="UploadEmployees.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Masters_UploadEmployees
/// </summary>
public partial class Masters_UploadEmployees : BasePage
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
            FillddlAreaID();
        }
    }
    /// <summary>
    /// Fills from location.
    /// </summary>
    protected void FillFromLocation()
    {
        DataSet ds = new DataSet();
        BL.Interface obj = new BL.Interface();
        //ds = obj.GetLocationfromAusServer(ddlEmployee.SelectedValue);
        ds = obj.GetLocationfromAusServer("0");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlFromLocation.DataSource = ds.Tables[0];
            ddlFromLocation.DataValueField = "LocationCode";
            ddlFromLocation.DataTextField = "LocationCode";
            ddlFromLocation.DataBind();
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
    /// Fillddls the area ID.
    /// </summary>
    private void FillddlAreaID()
    {
        ddlAreaID.Items.Clear();
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsArea = new DataSet();
        dsArea = objSale.AreaIdGetAllForLocation(BaseLocationAutoID);
        //dsArea = objSale.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID);
        ddlAreaID.DataTextField = "AreaDesc";
        ddlAreaID.DataValueField = "AreaID";
        ddlAreaID.DataSource = dsArea;
        ddlAreaID.DataBind();

        /*
        ListItem li = new ListItem();
        li.Text = "All";
        li.Value = "All";
        ddlAreaID.Items.Insert(0, li);
        */
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
        if (ddlFromLocation.SelectedValue == null || ddlAreaID.SelectedValue == null)
        {
            lblErrorMsg.Text = "Please Select From PayGlobal Branch And Area";
            return;
        }
        
        if (ddlFromLocation.SelectedValue.Trim() != ddlAreaID.SelectedItem.Text.Trim())
        {
            lblErrorMsg.Text = "Location And Area Must Be Same";
            return;
        }

        ds = obj.UpdateUploadEmployees(ddlFromLocation.SelectedValue, BaseLocationAutoID, BaseCompanyCode, BaseHrLocationCode, ddlAreaID.SelectedValue);

        int tblCount = ds.Tables.Count;
        dtDuplicateEmp = ds.Tables[tblCount - 2];
        dtUploadedEmp = ds.Tables[tblCount - 1];

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[tblCount - 1].Rows.Count > 0)
        {
            lblDuplicateEmployees.Text = ds.Tables[tblCount - 1].Rows[0]["Total"].ToString();
        }
        else
        {
            lblDuplicateEmployees.Text = "New Employee(s) Inserted : 0";
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[tblCount - 2].Rows.Count > 0)
        {
            lblUploadedEmployees.Text = ds.Tables[tblCount - 2].Rows[0]["Total"].ToString();
        }
        
    }
    /// <summary>
    /// Handles the SelectedIndexChange event of the Employee control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Employee_SelectedIndexChange(object sender, EventArgs e)
    {
        FillFromLocation();
    }
}
