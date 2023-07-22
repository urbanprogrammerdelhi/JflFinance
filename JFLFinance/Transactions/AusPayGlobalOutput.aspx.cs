// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="AusPayGlobalOutput.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_AusPayGlobalOutput.
/// </summary>
public partial class Transactions_AusPayGlobalOutput : BasePage //System.Web.UI.Page
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
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Output + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            if (!IsReadAccess == true)
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            FillddlClient();
        }


        FillDataGrid();

    }


    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();

        ds = objSales.ClientsLocationWiseGet(BaseLocationAutoID);
        ddlClientCode.DataSource = ds;
        ddlClientCode.DataTextField = "ClientNameCode";
        ddlClientCode.DataValueField = "ClientCode";
        ddlClientCode.DataBind();
        ListItem li1 = new ListItem();
        li1.Text = "All";
        li1.Value = "All";
        ddlClientCode.Items.Insert(0, li1);

    }

    /// <summary>
    /// Handles the Click event of the bntProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void bntProceed_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "" || txtToDate.Text == "")
            return;

        try
        {
            DateTime.Parse(txtFromDate.Text);
            DateTime.Parse(txtToDate.Text);
        }
        catch
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            return;
        }

        FillDataGrid();
    }

    /// <summary>
    /// Fills the data grid.
    /// </summary>
    protected void FillDataGrid()
    {
        lblErrorMsg.Text = "";

        DataSet ds = new DataSet();
        DL.Report obj = new DL.Report();

        ds = obj.OutputHoursDistribution(BaseCompanyCode, BaseLocationAutoID, ddlClientCode.SelectedValue, txtFromDate.Text, txtToDate.Text);

        PayGlobalOutput.DataSource = ds.Tables[0];
        PayGlobalOutput.DataBind();
    }
    /// <summary>
    /// Handles the submit event of the btn control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btn_submit(object sender, EventArgs e)
    {
        PayGlobalOutput.Settings.ShowColumnHeaders = false;
        //Settings-ShowColumnHeaders="false"
        ASPxGridViewExporter1.GridViewID = "PayGlobalOutput";
        ASPxGridViewExporter1.WriteXlsToResponse();
        PayGlobalOutput.Settings.ShowColumnHeaders = true;

    }
}