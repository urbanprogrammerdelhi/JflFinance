// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_Qubic.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_RptGroup_Qubic.
/// </summary>
public partial class Sales_RptGroup_Qubic : BasePage
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

    #region Page Functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //======================================================
            /* code added by Manish to Open report in New Page*/
            //Button1.Attributes["onMouseDown"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ViewReport1.aspx';";
            //this.Form.Attributes["onMouseOver"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";
            //this.Button1.Attributes.Add("onclick","this.form.target='_blank'");

            /* code added by Manish to Open report in New Page*/
            //======================================================
         
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.QubicReport.ToString();
            //}
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.QubicReport + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillddlReportName();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        ListItem li = new ListItem();
        li.Text = Resources.Resource.ClientDetails.ToString() + " Excel";
        li.Value = "MSXLClientDetailsQubic.aspx";
        ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.ContractDetail.ToString() + " Excel";
        //li.Value = "MSXLContractDetailsQubic.aspx";
        //ddlReportName.Items.Add(li);

    }
    //protected void FillddlClientName()
    //{
    //    BL.Sales objSales = new BL.Sales();
    //    DataSet ds = new DataSet();

    //    ds = objSales.blClient_Get(BaseLocationAutoID);
    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlClientName.DataSource = ds.Tables[0];
    //        ddlClientName.DataTextField = "ClientNameCode";
    //        ddlClientName.DataValueField = "ClientCode";
    //        ddlClientName.DataBind();
    //    }

    //    ListItem li2 = new ListItem();
    //    li2.Text = Resources.Resource.SelectAll;
    //    li2.Value = "";
    //    ddlClientName.Items.Insert(0, li2);
    //}
    #endregion

    #region Controles Events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideReportParameterControles();
    }
    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        HideAllControles();
        switch (strReportName)
        {
            case "MSXLClientDetailsQubic.aspx":
                break;
            case "MSXLContractDetailsQubic.aspx":
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Hides all controles.
    /// </summary>
    private void HideAllControles()
    {
    }
    #endregion

    #region Function Button event
    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        string strReportPagePath = "../Reports/Sales/";
        Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value.ToString());

        Hashtable hshRptParameters = new Hashtable();
        hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());

        Context.Items.Add("cxtHashParameters", hshRptParameters);
        Context.Items.Add("cxtReportID", "ReportID");
        Context.Items.Add("cxtReportPagePath", strReportPagePath);
        Context.Items["cxtReturnPage"] = "../Sales/RptGroup_Qubic.aspx?ReportName=" + ddlReportName.SelectedItem.Value.ToString();
        Server.Transfer("../Reports/ViewReport1.aspx");
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        Hashtable hshRptParameters = new Hashtable();
        switch (strReportName)
        {
            case "MSXLClientDetailsQubic.aspx":
                Response.Redirect("MSXLClientDetailsQubic.aspx");
                return hshRptParameters;
            case "MSXLContractDetailsQubic.aspx":
                Response.Redirect("MSXLContractDetailsQubic.aspx");
                return hshRptParameters;
            default: return hshRptParameters;
        }
    }
    #endregion
}