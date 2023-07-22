// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ToMerhavCSV.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
/// Class Transactions_ToMerhavCSV.
/// </summary>
public partial class Transactions_ToMerhavCSV : BasePage
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
            txtFromDate.Attributes.Add("readonly", "readonly");
            txtToDate.Attributes.Add("readonly", "readonly");

            FillDivision();
        }
        btnClick.Enabled = false;
        PanelAreaID.GroupingText = Resources.Resource.Output;
    }

    /// <summary>
    /// Handles the TextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtFromDate, lblErrorMsg))
        {
            txtToDate.Focus();
        }
        else
        {
            txtFromDate.Text = "";
            txtFromDate.Focus();
            //lblErrorMsg.Text = "";
        }

    }
    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtToDate, lblErrorMsg))
        {
            if (CompareDates(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text)) == 2)
            {
                btnClick.Enabled = true;
                lblErrorMsg.Text = "";
            }
            else
            {
                txtToDate.Text = "";
                txtToDate.Focus();
                lblErrorMsg.Text = Resources.Resource.InvalidDate;
            }
        }
        else
        {
            txtToDate.Text = "";
            txtToDate.Focus();
            //lblErrorMsg.Text = "";
        }

    }
    /// <summary>
    /// Handles the Click event of the btnClick control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClick_Click(object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        context.Response.ContentType = "csv";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=Hours.csv");


        BL.Roster objReport = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objReport.CreateFile(BaseCompanyCode, ddlHrLocation.SelectedItem.Value, ddlLocation.SelectedItem.Value, txtFromDate.Text.ToString(), txtToDate.Text.ToString());


        //Response.ContentEncoding = System.Text.Encoding.ASCII;



        StringBuilder str = new StringBuilder();
        DataTable objDt = (DataTable)ds.Tables[0];
        int NoOfColumn = objDt.Columns.Count;

        foreach (DataRow dr in objDt.Rows)
        {

            for (int i = 0; i < NoOfColumn; i++)
            {
                //if (i <= 1 )
                //{
                //    str.Append("=" + "\"" + dr[i].ToString() + "\"");
                //}
                //else
                //{
                str.Append(dr[i].ToString());
                // }
                if (i < NoOfColumn - 1)
                {
                    str.Append(",");
                }
            }
            str.AppendLine();
        }

        str.AppendLine();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=Hours.csv");
        Response.ContentType = "text/csv";


        //byte[] BOM = { 0xEF, 0xBB, 0xBF }; Code Commented By Ajay Datta On 06-May-2013
        //Response.BinaryWrite(BOM); Code Commented By Ajay Datta On 06-May-2013
        Response.Write(str);
        Response.End();

    }

    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlHrLocation.SelectedValue.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlLocation.DataSource = dsBranch.Tables[0];
            ddlLocation.DataValueField = "LocationCode";
            ddlLocation.DataTextField = "LocationDesc";
            ddlLocation.DataBind();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlLocation.Items.Insert(0, li);
        }
    }
    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision()
    {
        DataSet dsDivision = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlHrLocation.DataSource = dsDivision.Tables[0];
            ddlHrLocation.DataValueField = "HrLocationCode";
            ddlHrLocation.DataTextField = "HrLocationDesc";
            ddlHrLocation.DataBind();
            FillBranch();
        }
    }
}
