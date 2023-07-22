// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="PaySumSaudi.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_PaySumSaudi.
/// </summary>
public partial class Transactions_PaySumSaudi : BasePage
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

            FillddlClient();

            //fillPayPeriod();
            txtYear.Text = DateTime.Now.Year.ToString();
            int intMonth = DateTime.Now.Month;
            ddlMonth.Items[intMonth - 1].Selected = true;

            //code modified by Manish on 5-feb 2010 
            //description set start date * End date according to company payperiod 
            string[] strArray = new string[2];
            strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, intMonth, int.Parse(txtYear.Text));
            txtStartDate.Text = strArray[0];
            txtEndDate.Text = strArray[1];
           
        }
    }
    /// <summary>
    /// Handles the Click event of the btnGenerate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        //Response.Redirect("MSXLPaySum.aspx");
        Response.Redirect("MSXLPaySumSaudi.aspx?strClientCode=" + ddlClientCode.SelectedValue.ToString() + "&strFromDate=" + DateTime.Parse(txtStartDate.Text) + "&strToDate=" + DateTime.Parse(txtEndDate.Text));
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //code modified by Manish on 5-feb 2010 
        //description set start date * End date according to company payperiod 
        string[] strArray = new string[2];
        strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(ddlMonth.SelectedValue.ToString()), int.Parse(txtYear.Text));
        txtStartDate.Text = strArray[0];
        txtEndDate.Text = strArray[1];
    }
    /// <summary>
    /// Handles the TextChanged event of the txtStartDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            BL.Common objCommon = new BL.Common();
            ConvertStringToDateFormat(txtStartDate,lblErrorMsg );
            //string strDate = txtStartDate.Text;
            //int intMonth = DateTime.Parse(strDate).Month;
            //int intYear = DateTime.Parse(strDate).Year;
            //int EndDay = objCommon.GetDaysInMonth(intMonth);
            //string Date = (EndDay + "-" + intMonth + "-" + intYear);
            //txtEndDate.Text = DateTime.Parse(Date).ToString("dd-MMM-yyyy");
        }
        catch (Exception)
        {

            lblErrorMsg.Text = Resources.Resource.Datenotincorrectformat;
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtEndDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEndDate,lblErrorMsg );
    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {

        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.ClientsLocationWiseGet(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlClientCode.Items.Insert(0, li);

        }

    }
    /// <summary>
    /// Handles the OnTextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_OnTextChanged(object sender, EventArgs e)
    {
        string[] strArray = new string[2];
        strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(ddlMonth.SelectedValue.ToString()), int.Parse(txtYear.Text));
        txtStartDate.Text = strArray[0];
        txtEndDate.Text = strArray[1];
    }

}
