// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="Home.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;


/// <summary>
/// Class UserManagement_Home
/// </summary>
public partial class UserManagement_Home : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// The selected date
    /// </summary>
    protected DateTime SelectedDate;
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["ClientIP"] == null || Session["ClientIP"].ToString() != GetClientIpAddress(HttpContext.Current.Request).ToString())
        if (BaseUserIP == null || BaseUserIP != GetClientIpAddress(HttpContext.Current.Request))
        {
            RedirectToDefaultPage();
        }

        if (!IsPostBack)
        {

            bool salesRights = IsReadAllowed("~/Sales/SaleOrderMaster.aspx");
            bool contractRights = IsReadAllowed("~/Sales/ContractMaster.aspx");
            bool employeeRights = IsReadAllowed("~/HRManagement/EmployeeMaster.aspx");

            if (salesRights || contractRights || employeeRights)
            {
                TabFlowDiag.Visible = true;
                pnlToDoList.Visible = true;
            }
            else
            {
                TabFlowDiag.Visible = false;
                pnlToDoList.Visible = false;
            }
            if (!salesRights)
            {
                lbPendingSaleOrder.Visible = false;
            }
            if (!contractRights)
            {
                lbPendingContract.Visible = false;
                lbContractReview.Visible = false;
                lbrptContractExpiry.Visible = false;
            }
            if (!employeeRights)
            {
                lbPendingBorrowEmployeeRequest.Visible = false;
            }

            Response.Write(salesRights.ToString());

            try
            {
                if (BaseUserIP == null || BaseUserIP != GetClientIpAddress(HttpContext.Current.Request))
                {
                    HttpContext.Current.Response.Redirect("../default.aspx");
                }
            }
            catch (Exception ex)
            {
                ExceptionLog(ex);
                HttpContext.Current.Response.Redirect("../default.aspx", true);
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the lbtnToDoList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnToDoList_Click(object sender, EventArgs e)
    {
        pnlToDoList.Visible = true;
        FillrepTodoList();
    }

    private void HideAllDiv()
    {
        divSaleOrder.Visible = false;
        divContract.Visible = false;
        divContractReview.Visible = false;
        divrptContractExpiry.Visible = false;
        divRequest.Visible = false;
        divContractDashboard.Visible = false;
    }
    protected void lbPendingSaleOrder_Click(object sender, EventArgs e)
    {
        HideAllDiv();
        divSaleOrder.Visible = true;
        var objsales = new BL.Sales();
        string strUserID = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? BaseUserID : string.Empty;
        DataSet ds = objsales.PendingSaleOrdersGet(BaseLocationAutoID, strStatusFresh, strStatusAmend, strUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvSaleOrder.DataSource = ds.Tables[0];
            gvSaleOrder.DataBind();
        }
    }
    protected void lbPendingContract_Click(object sender, EventArgs e)
    {
        HideAllDiv();
        divContract.Visible = true;
        var objsales = new BL.Sales();
        string strUserID = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? BaseUserID : string.Empty;
        DataSet ds = objsales.PendingContractGet(BaseLocationAutoID, strStatusFresh, strStatusAmend, strUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvContract.DataSource = ds.Tables[0];
            gvContract.DataBind();
        }
    }
    protected void lbContractReview_Click(object sender, EventArgs e)
    {
        HideAllDiv();
        divContractReview.Visible = true;
        var objsales = new BL.Sales();
        string strUserID = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? BaseUserID : string.Empty;
        DataSet ds = objsales.ContractReviewGet(BaseLocationAutoID, strUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvContractReview.DataSource = ds.Tables[0];
            gvContractReview.DataBind();
        }
    }
    protected void lbrptContractExpiry_Click(object sender, EventArgs e)
    {
        HideAllDiv();
        divrptContractExpiry.Visible = true;
        var objsales = new BL.Sales();
        string strUserID = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? BaseUserID : string.Empty;
        DataSet ds = objsales.ExpiringContractGet(BaseLocationAutoID, strUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvContractExp.DataSource = ds.Tables[0];
            gvContractExp.DataBind();
        }
    }
    protected void lbPendingBorrowEmployeeRequest_Click(object sender, EventArgs e)
    {
        HideAllDiv();
        divRequest.Visible = true;
        var objReqNo = new BL.Roster();
        DataSet dsRequestNo = objReqNo.BorrowEmployeeRequestPendingGet(BaseLocationAutoID, BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
        if (dsRequestNo != null && dsRequestNo.Tables.Count > 0 && dsRequestNo.Tables[0].Rows.Count > 0)
        {
            gvRequestNo.DataSource = dsRequestNo.Tables[0];
            gvRequestNo.DataBind();
        }
    }


    #region Function Related To ToDo List

    /// <summary>
    /// Fillreps the todo list.
    /// </summary>
    protected void FillrepTodoList()
    {
        var objsales = new BL.Sales();
        string strUserID = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? BaseUserID : string.Empty;
        DataSet ds = objsales.PendingSaleOrdersGet(BaseLocationAutoID, strStatusFresh, strStatusAmend, strUserID);
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvSaleOrder.DataSource = ds.Tables[0];
                gvSaleOrder.DataBind();
            }
        }
        ds = objsales.PendingContractGet(BaseLocationAutoID, strStatusFresh, strStatusAmend, strUserID);
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvContract.DataSource = ds.Tables[0];
                gvContract.DataBind();
            }
        }

        ds = objsales.ContractReviewGet(BaseLocationAutoID, strUserID);
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvContractReview.DataSource = ds.Tables[0];
                gvContractReview.DataBind();
            }
        }

        ds = objsales.ExpiringContractGet(BaseLocationAutoID, strUserID);
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvContractExp.DataSource = ds.Tables[0];
                gvContractExp.DataBind();
            }
        }
        //var objOperationManagement = new BL.OperationManagement();
        //ds = objOperationManagement.OpsPendingAsmtGet(BaseLocationAutoID, strStatusFresh, strStatusAmend, strUserID.ToString());
        //if (ds != null)
        //{
        //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        gvAsmt.DataSource = ds.Tables[0];
        //        gvAsmt.DataBind();
        //    }
        //}
        //ds = objsales.ScheduleRosterHoursGet(BaseLocationAutoID, strUserID);
        //if (ds != null)
        //{
        //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        gvSchHrsVsCont.DataSource = ds.Tables[0];
        //        gvSchHrsVsCont.DataBind();

        //    }
        //}
        var objReqNo = new BL.Roster();
        DataSet dsRequestNo = objReqNo.BorrowEmployeeRequestPendingGet(BaseLocationAutoID, BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
        if (ds != null)
        {
            if (dsRequestNo.Tables.Count > 0 && dsRequestNo.Tables[0].Rows.Count > 0)
            {
                gvRequestNo.DataSource = dsRequestNo.Tables[0];
                gvRequestNo.DataBind();
            }
        }


    }


    /*Code added by   on 27-jul-2011*/
    /// <summary>
    /// Handles the RowDataBound event of the gvRequestNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvRequestNo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }

    /*End of Code added on 27-jul-2011*/

    /// <summary>
    /// Handles the RowDataBound event of the gvSaleOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSaleOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvContract control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvContract_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvContractReview control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvContractReview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvContractExp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvContractExp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }

    /*Code added by  */
    /// <summary>
    /// Handles the RowDataBound event of the gvSchHrsVsCont control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSchHrsVsCont_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }


    /// <summary>
    /// Handles the RowDataBound event of the gvAsmt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAsmt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }

    /// <summary>
    /// Handles the Click event of the lbtnSONO control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnSONO_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbtnSONO = (LinkButton)gvSaleOrder.Rows[row.RowIndex].FindControl("lbtnSONO");
        Label lblClientCode = (Label)gvSaleOrder.Rows[row.RowIndex].FindControl("lblClientCode");
        if (lbtnSONO != null && lblClientCode != null)
        {
            string[] strClientCode = lblClientCode.Text.Split('[');
            string ClientCode = strClientCode[1].Replace("]", "");

            Response.Redirect("../Sales/SaleOrderMaster.aspx?ClientCode=" + ClientCode + "&SoNo=" + lbtnSONO.Text);
        }
    }
    /// <summary>
    /// Handles the Click event of the lbtnContractNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnContractNo_Click(object sender, EventArgs e)
    {

        var objSales = new BL.Sales();

        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lbtnContractNo = (LinkButton)gvContract.Rows[row.RowIndex].FindControl("lbtnContractNo");
        var lblClientCode = (Label)gvContract.Rows[row.RowIndex].FindControl("lblClientCode");

        if (lbtnContractNo != null && lblClientCode != null)
        {
            string[] strClientCode = lblClientCode.Text.Split('[');
            string clientCode = strClientCode[1].Replace("]", "");
            DataSet ds = objSales.ContractMasterAmendNoGet(clientCode, lbtnContractNo.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("../Sales/ContractMaster.aspx?ClientCode=" + clientCode + "&ContractNumber=" + lbtnContractNo.Text + "&AmendNo=" + ds.Tables[0].Rows[0]["AmendNo"]);
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the lbtnContractExpNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnContractExpNo_Click(object sender, EventArgs e)
    {
        var objSales = new BL.Sales();

        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lbtnContractNo = (LinkButton)gvContractExp.Rows[row.RowIndex].FindControl("lbtnContractNo");
        var lblClientCode = (Label)gvContractExp.Rows[row.RowIndex].FindControl("lblClientCode");
        if (lbtnContractNo != null && lblClientCode != null)
        {
            string[] strClientCode = lblClientCode.Text.Split('[');
            string clientCode = strClientCode[1].Replace("]", "");
            DataSet ds = objSales.ContractMasterAmendNoGet(clientCode, lbtnContractNo.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("../Sales/ContractMaster.aspx?ClientCode=" + clientCode + "&ContractNumber=" + lbtnContractNo.Text + "&AmendNo=" + ds.Tables[0].Rows[0]["AmendNo"]);
            }
        }
    }

    /// <summary>
    /// Handles the Click event of the lbtnContractReview control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnContractReview_Click(object sender, EventArgs e)
    {
        var objSales = new BL.Sales();

        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lbtnContractNo = (LinkButton)gvContractReview.Rows[row.RowIndex].FindControl("lbtnContractNo");
        var lblClientCode = (Label)gvContractReview.Rows[row.RowIndex].FindControl("lblClientCode");
        if (lbtnContractNo != null && lblClientCode != null)
        {
            string[] strClientCode = lblClientCode.Text.Split('[');
            string clientCode = strClientCode[1].Replace("]", "");
            DataSet ds = objSales.ContractMasterAmendNoGet(clientCode, lbtnContractNo.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("../Sales/ContractMaster.aspx?ClientCode=" + clientCode + "&ContractNumber=" + lbtnContractNo.Text + "&AmendNo=" + ds.Tables[0].Rows[0]["AmendNo"]);
            }
        }
    }


    /// <summary>
    /// Handles the Click event of the lbtnAsmtNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnAsmtNo_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lbtnAsmtNo = (LinkButton)gvAsmt.Rows[row.RowIndex].FindControl("lbtnAsmtNo");
        var lblClientCode = (Label)gvAsmt.Rows[row.RowIndex].FindControl("lblClientCode");
        if (lbtnAsmtNo != null && lblClientCode != null)
        {
            string[] strClientCode = lblClientCode.Text.Split('[');
            string clientCode = strClientCode[1].Replace("]", "");
            Response.Redirect("../Transactions/AssignmentCreation.aspx?ClientCode=" + clientCode + "&AsmtCode=" + lbtnAsmtNo.Text);
        }
    }

    /*Code added by  */
    /// <summary>
    /// Handles the Click event of the lblAsmtNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblAsmtNo_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lblAsmtNo = (LinkButton)gvSchHrsVsCont.Rows[row.RowIndex].FindControl("lblAsmtNo");
        var lblSClientCode = (Label)gvSchHrsVsCont.Rows[row.RowIndex].FindControl("lblSClientCode");
        if (lblAsmtNo != null && lblSClientCode != null)
        {
            string[] strClientCode = lblSClientCode.Text.Split('[');
            string clientCode = strClientCode[1].Replace("]", "");
            Response.Redirect("../Transactions/AssignmentCreation.aspx?ClientCode=" + clientCode + "&AsmtCode=" + lblAsmtNo.Text);
        }
    }

    /*Code added by  */

    /*Code added by   27-Jul-2011*/
    /// <summary>
    /// Handles the Click event of the lblRequestNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblRequestNo_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var gvlblRequestNo = (LinkButton)gvRequestNo.Rows[row.RowIndex].FindControl("lblRequestNo");
        var lblSstatus = (Label)gvRequestNo.Rows[row.RowIndex].FindControl("lblSstatus");
        if (gvlblRequestNo != null && lblSstatus != null)
        {
            string strRequestNo = gvlblRequestNo.Text;
            if (lblSstatus.Text == strStatusNew || lblSstatus.Text == strStatusSent || lblSstatus.Text == strStatusApproved)
            {
                Response.Redirect("../Transactions/RequestFormApproval.aspx?RequestNo=" + strRequestNo);
            }
            else if (lblSstatus.Text == strStatusFresh)
            {
                Response.Redirect("../Transactions/BorrowEmployee.aspx?RequestNo=" + strRequestNo);
            }
        }
    }
    /*Code added by  */
    #endregion

    /// <summary>
    /// Handles the Click event of the lbtnClientMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnClientMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientMaster.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnContract control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnContract_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ContractMaster.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnAssignment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnAssignment_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/AssignmentCreation.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnSchedule control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnSchedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/ScheduleRoster1.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnEmployee control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnEmployee_Click(object sender, EventArgs e)
    {
        Response.Redirect("../HRManagement/EmployeeMaster.aspx?strStatus=" + Resources.Resource.AddNew);
    }
    /// <summary>
    /// Handles the Click event of the lbtnSaleOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnSaleOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/SaleOrderMaster.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnPostNshiftdetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnPostNshiftdetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/AssignmentCreation.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnActualAttendance control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnActualAttendance_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/ConvertSchedule.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnProductMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnProductMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/SaleProductMaster.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnDailyRota control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnDailyRota_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/DailyRota.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnMonthlyRota control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnMonthlyRota_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Transactions/MonthlyRota1.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnHolidayMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnHolidayMaster_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../Masters/HolidayType.aspx");
        Response.Redirect("../Transactions/HolidayTransaction.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnShiftPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnShiftPattren_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Masters/shiftPattern.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnLeaveMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnLeaveMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("../HRManagement/LeaveApplicationAndPosting.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnCreateShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnCreateShift_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Masters/StandardShift.aspx");
    }
    /// <summary>
    /// Handles the ActiveTabChanged event of the TabFlowDiag control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TabFlowDiag_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabFlowDiag.ActiveTabIndex == 1 && pnlToDoList.Visible == false)
        {
            pnlToDoList.Visible = true;
            FillrepTodoList();
        }
    }



    protected void lblContactDashBoard_Click(object sender, EventArgs e)
    {
       FillgvContractDashboard();
       
    }
    protected void gvContractDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
        }
      
          
    }
    protected void gvContractDashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContractDashboard.PageIndex = e.NewPageIndex;
        gvContractDashboard.EditIndex = -1;
        FillgvContractDashboard();
    }
    private void FillgvContractDashboard()
    {
        int noOfCustomer = 0;
        int noOfContracts = 0;
        int noOfSaleOrder = 0;
        decimal noOfHours = 0;
        int noOfPerson = 0;
        HideAllDiv();
        gvContractDashboard.Visible = true;
        divContractDashboard.Visible = true;
        var objsales = new BL.Sales();
        string strUserID = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? BaseUserID : string.Empty;
        DataSet ds = objsales.ContractDashboardGet(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            noOfCustomer = noOfCustomer + 1;
            gvContractDashboard.DataSource = ds.Tables[0];
            gvContractDashboard.DataBind();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            noOfContracts = noOfContracts + (Convert.ToInt32(ds.Tables[0].Rows[i]["NoOfContracts"].ToString()));
            noOfSaleOrder = noOfSaleOrder + (Convert.ToInt32(ds.Tables[0].Rows[i]["NoOfSaleOrders"].ToString()));
            noOfHours = noOfHours + (Convert.ToDecimal(ds.Tables[0].Rows[i]["ContractedHrs"].ToString()));
            noOfPerson = noOfPerson + (Convert.ToInt32(ds.Tables[0].Rows[i]["NoOfPersonsRequired"].ToString()));
        }
        lblCustomerNo.Text = noOfCustomer.ToString();
        lblContractNo.Text = noOfContracts.ToString();
        lblSaleOrderNo.Text = noOfSaleOrder.ToString();
        lblTotalHours.Text = noOfHours.ToString();
        lblTotalPerson.Text = noOfPerson.ToString();
        }
        else
        {
            gvContractDashboard.Visible = false;
            lblCustomerNo.Text = "0";
            lblContractNo.Text = "0";
            lblSaleOrderNo.Text = "0";
            lblTotalHours.Text = "0";
            lblTotalPerson.Text = "0";

        }
    }
}
