// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="ProcessBranchWiseEffectiveness.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Reports_DashBoard_ProcessBranchWiseEffectiveness.
/// </summary>
public partial class Reports_DashBoard_ProcessBranchWiseEffectiveness : BasePage
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
        if (!IsPostBack)
        {
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Process + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillddlToDivision();

                FillddlToYear();
                if (IsWriteAccess == true)
                {
                    btnProcess.Visible = true;
                }
                else
                {
                    btnProcess.Visible = false;
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

    }


    // <summary>
    /// <summary>
    /// Fillddls to division.
    /// </summary>
    private void FillddlToDivision()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        ds = objblMasterManagement.HRLocationDescriptionGetAll(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = ds.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDescCode";
            ddlDivision.DataBind();
            ds.Dispose();
        }
        else
        {
            var li1 = new ListItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlDivision.Items.Add(li1);

        }

    }

    /// <summary>
    /// Fills Year with Current Year
    /// </summary>
    private void FillddlToYear()
    {
        var li1 = new ListItem();
        li1.Text = DateTime.Today.Year.ToString();
        li1.Value = DateTime.Today.Year.ToString();
        ddlDivision.Items.Add(li1);
    }


    /// <summary>
    /// Handles the Click event of the btnProcess control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        DL.Report objReport = new DL.Report();

        using (DataTable ProcessGet = objReport.GuardingManagementBranchWiseSuccess(BaseCompanyCode, ddlDivision.SelectedItem.Value.ToString(), ddlYear.SelectedItem.Value.ToString(), ddlBranch.SelectedItem.Value.ToString(),BaseUserID))
        {
            if (ProcessGet != null && ProcessGet.Rows.Count > 0)
            {
                lblErrorMsg.Text = ProcessGet.Rows[0][0].ToString();
            }
        }
    }

    /// <summary>
    /// Gets or sets the process get.
    /// </summary>
    /// <value>The process get.</value>
    public object ProcessGet { get; set; }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBranch();
    }

    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {

            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";

            ddlBranch.DataBind();

        }
    }
}