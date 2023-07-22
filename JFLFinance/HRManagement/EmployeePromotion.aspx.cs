// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// Purpose          : Used to gather the details of the employees who have been promoted.
// ***********************************************************************
// <copyright file="EmployeePromotion.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Partial class for HRManagement_EmployeePromotion
/// </summary>
public partial class HRManagement_EmployeePromotion : BasePage // System.Web.UI.Page
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
            javaScript.Append("PageTitle('" + Resources.Resource.EmployeePromotion + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            imgEmployeeNumberSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + TxtEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");

            txtEffectiveFrom.Attributes.Add("readonly", "readonly");
        }
    }

    /// <summary>
    /// Text change event of EmployeeNumbe text box
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtEmployeeNumber_OnTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");

        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objHRManagement.EmployeeCompensationDetailGet(TxtEmployeeNumber.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            FillReasonType();
            FillCurrency();
            FillRateFrequency();
            FillDesignation();

            txtEmpNo.Text = TxtEmployeeNumber.Text;
            txtWageRate.Text = ds.Tables[0].Rows[0]["WageRate"].ToString();
            txtContractedHrs.Text = ds.Tables[0].Rows[0]["ContractHours"].ToString();
            lblwageRateFrequencyValue.Text = ds.Tables[0].Rows[0]["WageRateFrequency"].ToString();
            lblCurrencyValue.Text = ds.Tables[0].Rows[0]["CurrencyName"].ToString();
            lblPaymentFrequencyValue.Text = ds.Tables[0].Rows[0]["Paymentfrequency"].ToString();
            lblcontractRateFrequencyValue.Text = ds.Tables[0].Rows[0]["contractHrsFrequency"].ToString();
            Panel2.Visible = true;

            ddlDedignation.SelectedValue = ds.Tables[0].Rows[0]["DesignationCode"].ToString();
            ddlPaymntFrequency.SelectedValue = ds.Tables[0].Rows[0]["paymentFrequencyCode"].ToString();
            ddlWageRateFrequency.SelectedValue = ds.Tables[0].Rows[0]["WageRateFrequencyCode"].ToString();
            ddlContHrsFreqency.SelectedValue = ds.Tables[0].Rows[0]["contractHrsFrequencyCode"].ToString();
            txtNewContractHrs.Text = ds.Tables[0].Rows[0]["contractHours"].ToString();
            ddlCurrency.SelectedValue = ds.Tables[0].Rows[0]["CurrencyName"].ToString();

        }
        else
        {
            TxtEmployeeNumber.Text = "Invalid.";
        }



    }

    /// <summary>
    /// Fills CUrrency Drop Down List.
    /// </summary>
    private void FillCurrency()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ddlCurrency.DataSource = objMastersManagement.CurrencyMasterGetAll(BaseCompanyCode);
        ddlCurrency.DataTextField = "CurrencyName";
        ddlCurrency.DataValueField = "CurrencyCode";
        ddlCurrency.DataBind();       

    }

    /// <summary>
    /// Fills Designation Drop Down List
    /// </summary>
    private void FillDesignation()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();

        ddlDedignation.DataSource = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        ddlDedignation.DataTextField = "DesignationDesc";
        ddlDedignation.DataValueField = "DesignationCode";
        ddlDedignation.DataBind();

    }

    /// <summary>
    /// Fills Reasontype Drop Down List
    /// </summary>
    private void FillReasonType()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();

        ddlReasonType.DataSource = objMastersManagement.IncrementReasonTypesGetAll();
        ddlReasonType.DataTextField = "ReasonTypeDesc";
        ddlReasonType.DataValueField = "ReasonTypeCode";
        ddlReasonType.DataBind();

    }

    /// <summary>
    /// Fills RateFrequency Drop Down List
    /// </summary>
    private void FillRateFrequency()
    {

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMastersManagement.RateFrequencyGetAll(BaseCompanyCode);
        ddlContHrsFreqency.DataSource = ds;
        ddlContHrsFreqency.DataTextField = "WRfDesc";
        ddlContHrsFreqency.DataValueField = "WRfCode";
        ddlContHrsFreqency.DataBind();

        ddlWageRateFrequency.DataSource = ds;
        ddlWageRateFrequency.DataTextField = "WRfDesc";
        ddlWageRateFrequency.DataValueField = "WRfCode";
        ddlWageRateFrequency.DataBind();

        ddlPaymntFrequency.DataSource = ds;
        ddlPaymntFrequency.DataTextField = "WRfDesc";
        ddlPaymntFrequency.DataValueField = "WRfCode";
        ddlPaymntFrequency.DataBind();
    }
    /// <summary>
    /// Click Event of Save Button
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        float fltWagerate, fltIncrent, fltcontractHrs;

        fltWagerate = float.Parse(txtWageRate.Text);
        fltIncrent = float.Parse(txtIncrement.Text);
        if(txtContractedHrs.Text != "" )
        {
            fltcontractHrs=float.Parse(txtContractedHrs.Text);
        }
        else
        {
            fltcontractHrs=0;
        }


        ds = objHRManagement.EmployeeCompensationDetailInsert(txtEmpNo.Text, fltWagerate, ddlCurrency.SelectedValue.ToString(), ddlWageRateFrequency.SelectedValue.ToString(), ddlPaymntFrequency.SelectedValue.ToString(), fltcontractHrs, ddlContHrsFreqency.SelectedValue.ToString(), fltIncrent, ddlReasonType.SelectedValue.ToString(), txtEffectiveFrom.Text, BaseUserID.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); 
        }
    }
}
