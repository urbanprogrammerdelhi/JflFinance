// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="PaySumKuwait_ALZ.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_PaySumKuwait_ALZ.
/// </summary>
public partial class Transactions_PaySumKuwait_ALZ : BasePage
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
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.PaySum;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.PaySum + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            FillddlDivision();
        }
    }
    /// <summary>
    /// Fillddls the division.
    /// </summary>
    protected void FillddlDivision()
    {
        DataSet dsDivision = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();
            FillddlBranch();
        }
    }

    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, BaseHrLocationCode);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
        }  
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlBranch();
    }
    /// <summary>
    /// Handles the Click event of the btnGeneratePaySum control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGeneratePaySum_Click(object sender, EventArgs e)
    {
        Response.Redirect("MSXLPaySum_ALZ.aspx?DivisionCode=" + ddlDivision.SelectedValue.ToString() + "&BranchCode=" + ddlBranch.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedValue.ToString() + "&year=" + txtYear.Text);
    }
}
