// ***********************************************************************
// Assembly         : 
// Author           :  Virmani
// Created          : 05-07-2014
//
// Last Modified By :
// Last Modified On :
// ***********************************************************************
// <copyright file="SecurityServiceConfirmationReport.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

public partial class Transactions_SecurityServiceConfirmationReport : BasePage
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

            if (IsReadAccess)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                DateTime startDate = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtEndDate = startDate.AddMonths(1).AddDays(-1);
                string strLastDate = Convert.ToString(DateTime.DaysInMonth(dtEndDate.Year, dtEndDate.Month)) + "-" +
                              dtEndDate.ToString("MMM") + "-" + Convert.ToString(dtEndDate.Year);
                txtToDate.Text = strLastDate;
                FillCustomer();
            }


            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion
    /// <summary>
    /// Handles the Text Change Event of fromdate
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
         
        Regex regexDt = new Regex("(^(((([1-9])|([0][1-9])|([1-2][0-9])|(30))\\-([A,a][P,p][R,r]|[J,j][U,u][N,n]|[S,s][E,e][P,p]|[N,n][O,o][V,v]))|((([1-9])|([0][1-9])|([1-2][0-9])|([3][0-1]))\\-([J,j][A,a][N,n]|[M,m][A,a][R,r]|[M,m][A,a][Y,y]|[J,j][U,u][L,l]|[A,a][U,u][G,g]|[O,o][C,c][T,t]|[D,d][E,e][C,c])))\\-[0-9]{4}$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-8]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][1235679])|([13579][01345789]))$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-9]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][048])|([13579][26]))$)");

        Match mtStartDt = Regex.Match(txtFromDate.Text.ToString(), regexDt.ToString());
        Match mtEndDt = Regex.Match(txtToDate.Text.ToString(), regexDt.ToString());
        if (mtStartDt.Success && mtEndDt.Success)
        {
            var startDate = Convert.ToDateTime(txtFromDate.Text);
            var dtEndDate = startDate.AddMonths(1).AddDays(-1);
            string strLastDate = Convert.ToString(DateTime.DaysInMonth(dtEndDate.Year, dtEndDate.Month)) + "-" +
                          dtEndDate.ToString("MMM") + "-" + Convert.ToString(dtEndDate.Year);
            txtToDate.Text = strLastDate;
        }
        else {
            DisplayMessageString(lblErrorMsg, Resources.Resource.InvalidDate);
        }
    }

    /// <summary>
    /// Fills the dllcustomer dropdown
    /// </summary>
    private void FillCustomer()
    {
        string LocationAutoID = BaseLocationAutoID;
        var objSales = new BL.Sales();
        DataSet dsCustomer = objSales.ClientAreaWiseGet(LocationAutoID, "ALL");
        if (dsCustomer != null && dsCustomer.Tables[0].Rows.Count > 0)
        {
            ddlCustomer.DataSource = dsCustomer.Tables[0];
            ddlCustomer.DataValueField = "ClientCode";
            ddlCustomer.DataTextField = "ClientName";
            ddlCustomer.DataBind();
            ddlCustomer.SelectedIndex = 0;
            ddlCustomer.Enabled = true;
        }
        else
        {
            var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlCustomer.Items.Insert(0, li);
        }
    }


    /// <summary>
    ///Fills the Sale Order DropDown Acc to CustomerCode 
    /// </summary>
    protected void FillSaleOrder()
    {
        var objSales = new BL.Sales();
        ddlSoNo.Items.Clear();
        var chkCust = ddlCustomer.SelectedItem.Value;

        DataSet ds = objSales.SOClientWiseGet(BaseLocationAutoID, chkCust);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSoNo.DataSource = ds.Tables[0];
            ddlSoNo.DataTextField = "SoNo";
            ddlSoNo.DataValueField = "SoNo";
            ddlSoNo.DataBind();
        }
        else
        {
            var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlSoNo.Items.Insert(0, li);

        }
    }


    /// <summary>
    ///Handles the click event of View Report Button.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        
        Regex regexDt = new Regex("(^(((([1-9])|([0][1-9])|([1-2][0-9])|(30))\\-([A,a][P,p][R,r]|[J,j][U,u][N,n]|[S,s][E,e][P,p]|[N,n][O,o][V,v]))|((([1-9])|([0][1-9])|([1-2][0-9])|([3][0-1]))\\-([J,j][A,a][N,n]|[M,m][A,a][R,r]|[M,m][A,a][Y,y]|[J,j][U,u][L,l]|[A,a][U,u][G,g]|[O,o][C,c][T,t]|[D,d][E,e][C,c])))\\-[0-9]{4}$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-8]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][1235679])|([13579][01345789]))$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-9]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][048])|([13579][26]))$)");

        Match mtStartDt = Regex.Match(txtFromDate.Text.ToString(), regexDt.ToString());
        Match mtEndDt = Regex.Match(txtToDate.Text.ToString(), regexDt.ToString());
        if (mtStartDt.Success && mtEndDt.Success)
        {
            if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                var hshRptParameters = new Hashtable();
                hshRptParameters = ReportParameter_Get();
                Context.Items.Remove("cxtReportFileName");
                Context.Items.Add("cxtReportFileName", "SecurityServiceConfirmation.rpt");


                string strReportPagePath = "../Reports/Invoice/";
                Context.Items.Add("cxtHashParameters", hshRptParameters);
                Context.Items.Add("cxtReportID", "ReportID");
                Context.Items.Add("cxtReportPagePath", strReportPagePath);
                Context.Items["cxtReturnPage"] = "../Transactions/SecurityServiceConfirmationReport.aspx?lblErrorMsg=" + "";
                Server.Transfer("../Reports/ViewReport1.aspx");
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate);
            }
        }
        else
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.InvalidDate);
     
        }
    }

    /// <summary>
    /// Handles the Parameters used .
    /// </summary>
    /// <returns></returns>
    private Hashtable ReportParameter_Get()
    {
        string strReportName = "SecurityServiceConfirmation.rpt";
        var hshRptParameters = new Hashtable();
        switch (strReportName)
        {
            case "SecurityServiceConfirmation.rpt":
                var SoNo = ddlSoNo.CheckedItems;

                string strSoNo = string.Empty;
                if (SoNo.Count > 0)
                {
                    foreach (var item in SoNo)
                    {
                        strSoNo = strSoNo + item.Value.ToString() + ",";
                    }
                }

                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.SONO, strSoNo);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                hshRptParameters.Add(DL.Properties.Resources.ContactNumber, txtContactNumber.Text);
                hshRptParameters.Add(DL.Properties.Resources.ContactName, txtContact.Text);
                hshRptParameters.Add(DL.Properties.Resources.Remarks, txtRemark.Text);
                return hshRptParameters;

            default: return hshRptParameters;
        }
    }

    /// <summary>
    /// Handles the IndexChange event of Customer DropDown
    /// </summary>
    /// <param name="sender">ddl Customer </param>
    /// <param name="e">Index Change</param>
    protected void ddlCustomer_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillSaleOrder();
    }

    /// <summary>
    /// CallsCallSaudiInvoiceSP
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInvoiceprocess_Click(object sender, EventArgs e)
    {
        Regex regexDt = new Regex("(^(((([1-9])|([0][1-9])|([1-2][0-9])|(30))\\-([A,a][P,p][R,r]|[J,j][U,u][N,n]|[S,s][E,e][P,p]|[N,n][O,o][V,v]))|((([1-9])|([0][1-9])|([1-2][0-9])|([3][0-1]))\\-([J,j][A,a][N,n]|[M,m][A,a][R,r]|[M,m][A,a][Y,y]|[J,j][U,u][L,l]|[A,a][U,u][G,g]|[O,o][C,c][T,t]|[D,d][E,e][C,c])))\\-[0-9]{4}$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-8]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][1235679])|([13579][01345789]))$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-9]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][048])|([13579][26]))$)");

        Match mtStartDt = Regex.Match(txtFromDate.Text.ToString(), regexDt.ToString());
        Match mtEndDt = Regex.Match(txtToDate.Text.ToString(), regexDt.ToString());
        if (mtStartDt.Success && mtEndDt.Success)
        {
            CallSaudiInvoiceSP(BaseLocationAutoID, txtFromDate.Text, txtToDate.Text);
        }
        else 
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.InvalidDate);
        }
    }

    /// <summary>
    /// Used in btnInvoiceprocess_Click
    /// </summary>
    /// <param name="locationAutoID"></param>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    protected void CallSaudiInvoiceSP(string locationAutoID, string fromDate, string toDate)
    {
        BL.Invoice objSaudiInvoice = new BL.Invoice();
        DataSet ds = new DataSet();
        ds = objSaudiInvoice.CallSaudiInvoiceSP(locationAutoID, fromDate, toDate);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NotConfirmed;
        }
    }
}

