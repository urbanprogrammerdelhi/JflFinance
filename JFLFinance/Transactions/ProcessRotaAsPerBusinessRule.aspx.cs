// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ProcessRotaAsPerBusinessRule.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Class Transactions_ProcessRotaAsPerBusinessRule.
/// </summary>
public partial class Transactions_ProcessRotaAsPerBusinessRule : BasePage//System.Web.UI.Page
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
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ProcessRotaAsPerBusinessRule + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            FillExistingRules();
            if (ddlPeriodCollection.Items.Count <= 0)
            {
                btnProceed.Visible = false;
                btnFinalPaysum.Visible = false;
                btnGeneratePaysum.Visible = false;
            }

        }
    }

    /// <summary>
    /// Fills the existing rules.
    /// </summary>
    protected void FillExistingRules()
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        DataSet ds = new DataSet();
        ds = objBR.BusinessRuleGet("", int.Parse(BaseLocationAutoID));
        ddlBR.DataSource = ds.Tables[1];
        ddlBR.DataValueField = "PaysumCode";
        ddlBR.DataTextField = "PaysumCodeDesc";
        ddlBR.DataBind();

        ListItem li = new ListItem();
        li.Text = "Select Rule";
        li.Value = DateTime.Now.ToString();
        ddlBR.Items.Insert(0, li);

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBR control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBR_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPayPeriodCollection();
        HideShowButtons();
    }

    /// <summary>
    /// Hides the show buttons.
    /// </summary>
    private void HideShowButtons()
    {

        if (ddlPeriodCollection.Items.Count <= 0)
        {
            btnProceed.Visible = false;
            btnFinalPaysum.Visible = false;
            btnGeneratePaysum.Visible = false;
        }
        else
        {
            btnProceed.Visible = true;
            btnFinalPaysum.Visible = true;
            btnGeneratePaysum.Visible = true;
        }
    }

    /// <summary>
    /// Handles the Click event of the btnAddPeriodCollection control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddPeriodCollection_Click(object sender, EventArgs e)
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        DataSet ds = new DataSet();
        ds = objBR.PayPeriodCollectionInsert(ddlBR.SelectedValue.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            FillPayPeriodCollection();
            btnAddPeriodCollection.Visible = false;
        }
        else
        {
            lblErrorMsg.Text = "Error!";
        }
        HideShowButtons();
    }

    /// <summary>
    /// Fills the pay period collection.
    /// </summary>
    protected void FillPayPeriodCollection()
    {
        btnAddPeriodCollection.Visible = false;
        BL.BusinessRule objBR = new BL.BusinessRule();
        DataSet ds = new DataSet();
        ds = objBR.PayPeriodCollectionGet(ddlBR.SelectedValue.ToString());
        ddlPeriodCollection.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataTable periodCollection = new DataTable();
            periodCollection = ds.Tables[0];
            ViewState.Add("MyPeriodCollection", periodCollection);

            ddlPeriodCollection.DataSource = ds.Tables[0];
            ddlPeriodCollection.DataValueField = "PeriodNumber";
            ddlPeriodCollection.DataTextField = "PeriodDesc";
            ddlPeriodCollection.DataBind();
            setDropDownColour();

            DataRow[] result = periodCollection.Select("ToDate >= '" + DateTime.Now + "'");
            ddlPeriodCollection.SelectedValue = result[0]["PeriodNumber"].ToString();

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
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {

        System.Web.UI.ScriptManager ajax = (System.Web.UI.ScriptManager)this.Page.Master.FindControl("ToolkitScriptManager1");

        if (ajax != null)
        {
            ajax.AsyncPostBackTimeout = 1200;
        }


        lblErrorMsg.Text = "";
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["MyPeriodCollection"];
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow[] result = dt.Select("PeriodNumber >= " + ddlPeriodCollection.SelectedValue);

            if (bool.Parse(result[0]["RotaAuthorizeStatus"].ToString()))
            {
                lblErrorMsg.Text = "Locked";
                setDropDownColour();
                return;
            }

            BL.Roster objRost = new BL.Roster();
            DataSet ds = new DataSet();
            try
            {

                ds = objRost.EmployeeAttendanceProcess(BaseCompanyCode, ddlBR.SelectedValue.ToString(), DateTime.Parse(result[0]["FromDate"].ToString()).ToString("dd-MMM-yyyy"), DateTime.Parse(result[0]["ToDate"].ToString()).ToString("dd-MMM-yyyy"), BaseUserID.ToString());
                lblErrorMsg.Text = Resources.Resource.ProcessCompleted;
                int ind = ddlPeriodCollection.SelectedIndex;
                FillPayPeriodCollection();
                ddlPeriodCollection.SelectedIndex = ind;

            }
            catch
            {
                lblErrorMsg.Text = Resources.Resource.MsgUnknownError;
            }
        }
        setDropDownColour();
    }

    /// <summary>
    /// Handles the Click event of the btnGeneratePaysum control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGeneratePaysum_Click(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["MyPeriodCollection"];
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow[] result = dt.Select("PeriodNumber >= " + ddlPeriodCollection.SelectedValue);

            //if (bool.Parse(result[0]["RotaAuthorizeStatus"].ToString()))
            //{
            //    lblErrorMsg.Text = "Locked";
            //    setDropDownColour();
            //    return;
            //}

            try
            {
                Response.Redirect("Paysum_ISR.aspx?fromDate=" + DateTime.Parse(result[0]["FromDate"].ToString()).ToString("dd-MMM-yyyy") + "&toDate=" + DateTime.Parse(result[0]["ToDate"].ToString()).ToString("dd-MMM-yyyy") + "&rule=" + ddlBR.SelectedValue.ToString());
            }
            catch
            {
                lblErrorMsg.Text = Resources.Resource.MsgUnknownError;
            }
        }
        setDropDownColour();
    }

    /// <summary>
    /// Handles the Click event of the btnFinalPaysum control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnFinalPaysum_Click(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["MyPeriodCollection"];
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow[] result = dt.Select("PeriodNumber >= " + ddlPeriodCollection.SelectedValue);

            if (bool.Parse(result[0]["RotaAuthorizeStatus"].ToString()) && bool.Parse(result[0]["PaysumProcessStatus"].ToString()))
            {
                lblErrorMsg.Text = "Locked";
                setDropDownColour();
                return;
            }
            else if (!bool.Parse(result[0]["RotaAuthorizeStatus"].ToString()))
            {
                lblErrorMsg.Text = "Paysum is not Ready!";
                setDropDownColour();
                return;
            }
            else
            {
                BL.Roster objRoster = new BL.Roster();
                DataSet ds = new DataSet();
                objRoster.GeneratePaysumIsrael(ddlBR.SelectedValue, DateTime.Parse(result[0]["FromDate"].ToString()).ToString("dd-MMM-yyyy"), DateTime.Parse(result[0]["ToDate"].ToString()).ToString("dd-MMM-yyyy"), "3", BaseCompanyCode);

                int ind = ddlPeriodCollection.SelectedIndex;
                FillPayPeriodCollection();
                ddlPeriodCollection.SelectedIndex = ind;
            }
        }
        setDropDownColour();
    }

    /// <summary>
    /// Sets the drop down colour.
    /// </summary>
    private void setDropDownColour()
    {
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["MyPeriodCollection"];
        DataRow[] result = dt.Select("RotaAuthorizeStatus = " + true);



        for (int i = 0; i < result.Length; i++)
        {
            if (bool.Parse(result[i]["PaysumProcessStatus"].ToString()))
            {
                ddlPeriodCollection.Items[i].Attributes.Add("style", "background-color:Orange");
            }
            else
            {
                ddlPeriodCollection.Items[i].Attributes.Add("style", "background-color:LightGreen");
            }
        }
    }

}
