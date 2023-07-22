// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="AttendanceVarification.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;
using System.Data;
using BL;

/// <summary>
/// Class Transactions_AttendanceVarification.
/// </summary>
public partial class Transactions_AttendanceVarification : BasePage//System.Web.UI.Page
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
            FillExistingRules();

        }
    }


    /// <summary>
    /// Fills the existing rules.
    /// </summary>
    protected void FillExistingRules()
    {
        var objBr = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBr.BusinessRuleGet("", int.Parse(BaseLocationAutoID));
        ddlBR.DataSource = ds.Tables[1];
        ddlBR.DataValueField = "PaysumCode";
        ddlBR.DataTextField = "PaysumCodeDesc";
        ddlBR.DataBind();

        var li = new ListItem { Text =  Resources.Resource.Select , Value = DateTime.Now.ToString() };
        ddlBR.Items.Insert(0, li);

    }



    /// <summary>
    /// Fills the pay period collection.
    /// </summary>
    protected void FillPayPeriodCollection()
    {
        btnAddPeriodCollection.Visible = false;
        var objBr = new BL.BusinessRule();
        var ds = new DataSet();
        ddlPeriodCollection.Items.Clear();
        ds = objBr.PayPeriodCollectionGet(ddlBR.SelectedValue.ToString());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var periodCollection = new DataTable();
            periodCollection = ds.Tables[0];
            ViewState.Add("MyPeriodCollection", periodCollection);

            ddlPeriodCollection.DataSource = ds.Tables[0];
            ddlPeriodCollection.DataValueField = "PeriodNumber";
            ddlPeriodCollection.DataTextField = "PeriodDesc";
            ddlPeriodCollection.DataBind();
            setDropDownColour();

            var result = periodCollection.Select("PaysumProcessStatus = 'False'");
            ddlPeriodCollection.SelectedValue = result[0]["PeriodNumber"].ToString();

            FromDate.Value = DateTime.Parse(result[0]["FromDate"].ToString()).ToString();
            ToDate.Value = DateTime.Parse(result[0]["ToDate"].ToString()).ToString();
            PaysumProcessStatus.Value = result[0]["PaysumProcessStatus"].ToString();
            RotaAuthorizeStatus.Value = result[0]["RotaAuthorizeStatus"].ToString();

        }
        else if (ddlBR.SelectedIndex > 0)
        {
            btnAddPeriodCollection.Visible = true;
        }
        else
        {
            ddlPeriodCollection.Items.Clear();
        }

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPeriodCollection control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPeriodCollection_SelectedIndexChanged(object sender, EventArgs e)
    {

        var dt = new DataTable();
        dt = (DataTable)ViewState["MyPeriodCollection"];
        if (dt != null && dt.Rows.Count > 0)
        {
            var result = dt.Select("PeriodNumber >= " + ddlPeriodCollection.SelectedValue);
            FromDate.Value = DateTime.Parse(result[0]["FromDate"].ToString()).ToString();
            ToDate.Value = DateTime.Parse(result[0]["ToDate"].ToString()).ToString();
            PaysumProcessStatus.Value = result[0]["PaysumProcessStatus"].ToString();
            RotaAuthorizeStatus.Value = result[0]["RotaAuthorizeStatus"].ToString();

        }
        setDropDownColour();

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBR control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBR_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPayPeriodCollection();
    }

    /// <summary>
    /// Handles the Click event of the btnVerifyAttendance control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnVerifyAttendance_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Handles the Click event of the btnAddPeriodCollection control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddPeriodCollection_Click(object sender, EventArgs e)
    {
        var objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.PayPeriodCollectionInsert(ddlBR.SelectedValue.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            FillPayPeriodCollection();
            btnAddPeriodCollection.Visible = false;
        }
        else
        {
            lblErrorMsg.Text = @"Error!";
        }
    }

    /// <summary>
    /// Sets the drop down colour.
    /// </summary>
    private void setDropDownColour()
    {
        var dt = new DataTable();
        dt = (DataTable)ViewState["MyPeriodCollection"];

        for (var i = 0; i < ddlPeriodCollection.Items.Count; i++)
        {
            if (bool.Parse(dt.Rows[i]["PaysumProcessStatus"].ToString()))
            {
                ddlPeriodCollection.Items[i].Attributes.Add("style", "background-color:Orange");
            }
            else if (bool.Parse(dt.Rows[i]["RotaAuthorizeStatus"].ToString()))
            {
                ddlPeriodCollection.Items[i].Attributes.Add("style", "background-color:LightGreen");
            }
        }
    }

    /// <summary>
    /// Handles the Click event of the btnRefreshPeriod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnRefreshPeriod_Click(object sender, EventArgs e)
    {
        var payPeriodIndex = ddlPeriodCollection.SelectedIndex;
        FillPayPeriodCollection();

        ddlPeriodCollection.SelectedIndex = payPeriodIndex;

        var dt = new DataTable();
        dt = (DataTable)ViewState["MyPeriodCollection"];
        if (dt != null && dt.Rows.Count > 0)
        {
            var result = dt.Select("PeriodNumber >= " + ddlPeriodCollection.SelectedValue);
            FromDate.Value = DateTime.Parse(result[0]["FromDate"].ToString()).ToString();
            ToDate.Value = DateTime.Parse(result[0]["ToDate"].ToString()).ToString();
            PaysumProcessStatus.Value = result[0]["PaysumProcessStatus"].ToString();
            RotaAuthorizeStatus.Value = result[0]["RotaAuthorizeStatus"].ToString();

        }

    }

    //Added for Testing Purpose ProcessRota Function

    /// <summary>
    /// Handles the Click event of the lbtnProcessRota control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnProcessRota_Click(object sender, EventArgs e)
    {
        if (RotaAuthorizeStatus.Value.ToUpper() == "TRUE")
        {
            lblErrorMsg.Text = @"locked";
        }
        else
        {
            var businessRuleCode = ddlBR.SelectedItem.Value;
            var fromDate = FromDate.Value;
            var toDate = ToDate.Value;
            var dsProcess = new DataSet();
            try
            {
                var objRost = new Roster();
                dsProcess = objRost.EmployeeAttendanceProcess(BaseCompanyCode, businessRuleCode, DateTime.Parse(fromDate).ToString("dd-MMM-yyyy"), DateTime.Parse(toDate).ToString("dd-MMM-yyyy"), BaseUserID);
                lblErrorMsg.Text = Resources.Resource.ProcessCompleted;
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
            return;
        }
    }
}