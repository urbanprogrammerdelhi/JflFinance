// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="PaysumSubPNG.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_PaysumSubPNG.
/// </summary>
public partial class Transactions_PaysumSubPNG : BasePage
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
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.PaySum; }

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
            if (!IsReadAccess == true)
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }

        string BusinessRuleCode = Request.QueryString["BusinessRuleCode"];
        string PeriodNumber = Request.QueryString["PeriodNumber"];
        string BusinessRuleDesc = Request.QueryString["BusinessRuleDesc"];
        string PeriodDesc = Request.QueryString["PeriodDesc"];

        FillDataGrid(BusinessRuleCode, PeriodNumber);

        LabelBusinessDesc.Text = BusinessRuleDesc;
        LabelPeriodDesc.Text = PeriodDesc;
    }

    //protected void TxtFDate_TextChanged(object sender, EventArgs e)
    //{
    //    ConvertStringToDateFormat(TxtFDate, lblErrorMsg);
    //}
    //protected void TxtTDate_TextChanged(object sender, EventArgs e)
    //{
    //    ConvertStringToDateFormat(TxtTDate, lblErrorMsg);
    //}


    /// <summary>
    /// Handles the submit event of the btn control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btn_submit(object sender, EventArgs e)
    {

        ASPxGridViewExporter1.GridViewID = "PaysumPNG";
        ASPxGridViewExporter1.WriteCsvToResponse();

    }

    /// <summary>
    /// Fills the data grid.
    /// </summary>
    /// <param name="BusinessRuleCode">The business rule code.</param>
    /// <param name="PayPeriodNumber">The pay period number.</param>
    protected void FillDataGrid(string BusinessRuleCode, string PayPeriodNumber)
    {
        Panel2.Visible = true;
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();

        BL.Common objCommon = new BL.Common();
        //if (!objCommon.IsValidDate(TxtFDate.Text) || !objCommon.IsValidDate(TxtTDate.Text))
        //{
        //    lblErrorMsg.Text = Resources.Resource.InvalidDate;
        //    return;
        //}
        lblErrorMsg.Text = "";

        ds = objRoster.GeneratePaysumBSPng(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, BusinessRuleCode, PayPeriodNumber);

        PaysumPNG.DataSource = ds;
        PaysumPNG.DataBind();

    }

    /// <summary>
    /// Handles the Back event of the btn control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btn_Back(object sender, EventArgs e)
    {
        Response.Redirect("PaysumMainPNG.aspx");
    }

    /// <summary>
    /// Handles the OnClick event of the btnGenerateData control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGenerateData_OnClick(object sender, EventArgs e)
    {
        //FillDataGrid();
    }
}