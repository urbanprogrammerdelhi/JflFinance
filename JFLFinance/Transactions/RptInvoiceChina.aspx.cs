// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptInvoiceChina.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Collections;

/// <summary>
/// Class Transactions_RptInvoiceChina.
/// </summary>
public partial class Transactions_RptInvoiceChina : BasePage
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
            javaScript.Append("PageTitle('" + Resources.Resource.Invoice + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID.ToString() + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID.ToString() + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");

                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();

                FillddlClient();
                Fillddlsubcompany(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

        lblErrorMsg.Text = "";
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
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientNameCode";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();

            ddlClient.AutoPostBack = true;
            if (!IsPostBack)
            {
                var Client = ddlClient.CheckedItems;
                //For Sale Order No.
                string ddlSoNo = string.Empty;
             
                if (Client.Count > 0)
                {
                    foreach (var item in Client)
                    {
                        ddlSoNo = ddlSoNo + item.Value.ToString() + ",";
                    }
                }
                FillddlSO(ddlSoNo);

            }
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        var Client = ddlClient.CheckedItems;
        //For Sale Order No.
        string ddlSoNo = string.Empty;
      
        if (Client.Count > 0)
        {
            foreach (var item in Client)
            {
                ddlSoNo = ddlSoNo + item.Value.ToString() + ",";
            }
        }
        FillddlSO(ddlSoNo);
        //FillddlSO();
    }
    /// <summary>
    /// Fillddls the so.
    /// </summary>
    /// <param name="ddlClient">The DDL client.</param>
    protected void FillddlSO(string ddlClient)
    {
        msddlSo.Items.Clear();

        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.SOClientWiseGet(BaseLocationAutoID,ddlClient);
        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            msddlSo.DataSource = ds.Tables[0];
            msddlSo.DataTextField = "SoNo";
            msddlSo.DataValueField = "SoNo";
            msddlSo.DataBind();

            //ListItem Li1 = new ListItem();
            //Li1.Text = Resources.Resource.Select;
            //Li1.Value = Resources.Resource.Select;
            //msddlSo.Items.Insert(0, Li1);
            msddlSo.SelectedIndex = 0;

        }
        //else
        //{
        //    ListItem Li1 = new ListItem();
        //    Li1.Text = Resources.Resource.Select;
        //    Li1.Value = Resources.Resource.Select;
        //    msddlSo.Items.Insert(0, Li1);
        //    msddlSo.SelectedIndex = 0;
        //}
    }
    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (validateFromToDate())
        {
            string strReportPagePath = "../Reports/Invoice/";
            Context.Items.Add("cxtReportFileName", "PerformaInvoiceChina.rpt");
            //Comma seprated value for Client(multiple selection )
            var varClient = ddlClient.CheckedItems;

            string ddlClientstr = string.Empty;
            
            if (varClient.Count > 0)
            {
                foreach (var item in varClient)
                {
                    ddlClientstr = ddlClientstr + item.Value.ToString() + ",";
                }

            }

            var varSoNo = msddlSo.CheckedItems;

            string ddlSoNo = string.Empty;

            if (varSoNo.Count > 0)
            {
                foreach (var item in varSoNo)
                {
                    ddlSoNo = ddlSoNo + item.Value.ToString() + ",";
                }

            }

            Hashtable hshRptParameters = new Hashtable();
            hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
            hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
            hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientstr);
            hshRptParameters.Add(DL.Properties.Resources.SONO, ddlSoNo);
            hshRptParameters.Add(DL.Properties.Resources.CompanyName, txtCompanyName.Text.Trim());
            hshRptParameters.Add(DL.Properties.Resources.BankName, txtBankName.Text.Trim());
            hshRptParameters.Add(DL.Properties.Resources.BankAccountNumber, txtBankAccountNumber.Text.Trim());
            hshRptParameters.Add(DL.Properties.Resources.Remarks, txtRemarks.Text.Trim());


            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptInvoiceChina.aspx?ReportName=" + "PerformaInvoiceChina.rpt";
            Server.Transfer("../Reports/ViewReport1.aspx");
        }
        else
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
    }
    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool validateFromToDate()
    {
        if (txtToDate.Text != "" && txtFromDate.Text != "")
        {
            if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                return true;
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                return false;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
            return false;
        }
    }

    // created by smdoss 05-Feb-2015
    // Get Subcompany and bank name from database.    
    protected void Fillddlsubcompany(string prmCompanyCode, string prmDivisionCode, string prmBranchCode)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.SubCompanyGet(prmCompanyCode, prmDivisionCode, prmBranchCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlsubcompany.DataSource = ds.Tables[0];
            ddlsubcompany.DataTextField = "SubCompanyDesc";
            ddlsubcompany.DataValueField = "SubCompanyCode";
            ddlsubcompany.DataBind();
            ddlsubcompany.SelectedIndex = -1;
        }
    }

    // created by smdoss 05-Feb-2015
    // Get Subcompany and bank name from database.
    protected void ddlsubcompany_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (ddlsubcompany.SelectedValue != null)
        {
            Fillddlbankname(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, Convert.ToString(ddlsubcompany.SelectedValue));
            txtCompanyName.Text = ddlsubcompany.SelectedItem.Text;
            txtBankName.Text = ddlbankname.SelectedItem.Text;
        }
    }


    // created by smdoss 05-Feb-2015
    // Get Subcompany and bank name from database.
    protected void ddlbankname_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

        if (ddlsubcompany.SelectedValue != null && ddlbankname.SelectedValue != null)
        {
            filltxtbanknumber(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, Convert.ToString(ddlsubcompany.SelectedValue), Convert.ToString(ddlbankname.SelectedValue));
            txtCompanyName.Text = ddlsubcompany.SelectedItem.Text;
            txtBankName.Text = ddlbankname.SelectedItem.Text;
        }
    }

    // created by smdoss 05-Feb-2015
    // Get Subcompany and bank name from database.
    protected void Fillddlbankname(string prmCompanyCode, string prmDivisionCode, string prmBranchCode, string prmSubCompanyCode)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.banknameGet(prmCompanyCode, prmDivisionCode, prmBranchCode, prmSubCompanyCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlbankname.DataSource = ds.Tables[0];
            ddlbankname.DataTextField = "BankDesc";
            ddlbankname.DataValueField = "BankCode";
            ddlbankname.DataBind();
            ddlbankname.SelectedIndex = 0;
            string prmbankCode = Convert.ToString(ds.Tables[0].Rows[0]["BankCode"]);
            filltxtbanknumber(prmCompanyCode, prmDivisionCode, prmBranchCode, prmSubCompanyCode, prmbankCode);
        }
    }

    // created by smdoss 05-Feb-2015
    protected void filltxtbanknumber(string prmCompanyCode, string prmDivisionCode, string prmBranchCode, string prmSubCompanyCode, string prmbankCode)
    {
        BL.Sales objSales = new BL.Sales();
        DataTable ds = new DataTable();
        ds = objSales.BankNumberGet(prmCompanyCode, prmDivisionCode, prmBranchCode, prmSubCompanyCode, prmbankCode);
        if (ds.Rows.Count > 0)
        {
            txtBankAccountNumber.Text = Convert.ToString(ds.Rows[0][0]);
        }

    }
}