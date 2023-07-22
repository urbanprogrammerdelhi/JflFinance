// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By :  
// Last Modified On : 05-28-2014
// ***********************************************************************
// <copyright file="ClientController.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;


/// <summary>
/// Class MonitorScreen_ClientController.
/// </summary>
public partial class MonitorScreen_ClientController : BasePage
{
    #region Properties
    /// <summary>
    /// Returns User Read Rights.
    /// </summary>
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

    #region Page Load Event
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                if (Request.QueryString["ClientCode"] != null && Request.QueryString["TimeTo"] != null && Request.QueryString["TimeFrom"] != null && Request.QueryString["Date"] != null)
                {
                    txtTimeFrom.Text = DateTime.Parse(Request.QueryString["TimeFrom"].ToString()).ToString("HH:mm");
                    txtTimeTo.Text = DateTime.Parse(Request.QueryString["TimeTo"].ToString()).ToString("HH:mm");

                    txtWEF.Text = DateFormat(Request.QueryString["Date"]);
                    txtWET.Text = DateFormat(Request.QueryString["WETDate"]);
                    FillgvClientAttendanceDetails(DateTime.Parse(Request.QueryString["Date"]), DateTime.Parse(Request.QueryString["TimeFrom"]), DateTime.Parse(Request.QueryString["TimeTo"]));
                }
                else
                {
                    txtTimeFrom.Text = "00:00"; //DateTime.Now.ToString("HH:mm");
                    txtTimeTo.Text = DateTime.Now.ToString("HH:mm");
                    txtWEF.Text = DateFormat(DateTime.Today.ToString());
                    txtWET.Text = DateFormat(DateTime.Today.ToString());
                }
                //THIS CODE IS FOR INCIDENT TAB
                txtITimeFrom.Text = "00:00";//DateTime.Now.ToString("HH:mm");
                txtITimeTO.Text = DateTime.Now.ToString("HH:mm");
                txtIWEF.Text = DateFormat(DateTime.Today.ToString());
                txtIWET.Text = DateFormat(DateTime.Today.ToString());
                
                ////*********code for Panic Alert ************
                txtPFromTime.Text = "00:00";// DateTime.Now.ToString("HH:mm");
                txtPToTime.Text = DateTime.Now.ToString("HH:mm");
                txtPWEF.Text = DateFormat(DateTime.Today.ToString());
                txtPWET.Text = DateFormat(DateTime.Today.ToString());

                ////********************Code for Vacant ***************
                txtVFromTime.Text = "00:00";
                txtVToTime.Text = DateTime.Now.ToString("HH:mm");
                txtVWEF.Text = DateFormat(DateTime.Today.ToString());
                txtVWET.Text = DateFormat(DateTime.Today.ToString());
                
                ////********************Code for No Show***************
                txtNFromTime.Text = "00:00";// DateTime.Now.ToString("HH:mm");
                txtNToTime.Text = DateTime.Now.ToString("HH:mm");
                txtNWEF.Text = DateFormat(DateTime.Today.ToString());
                txtNWET.Text = DateFormat(DateTime.Today.ToString());

                ////********************Code for Guard Tour***************
                txtGFromTime.Text = "00:00";// DateTime.Now.ToString("HH:mm");
                txtGToTime.Text = DateTime.Now.ToString("HH:mm");
                txtGWef.Text = DateFormat(DateTime.Today.ToString());
                txtGWet.Text = DateFormat(DateTime.Today.ToString());
                FillddlClientCode(ddlClientCode, ddlAsmtCode, ddlPostCode);

                txtUnTimeFrom.Text = "00:00";//DateTime.Now.ToString("HH:mm");
                txtUnTimeTo.Text = DateTime.Now.ToString("HH:mm");
                txtUnWEF.Text = DateFormat(DateTime.Today.ToString());
                txtUnWET.Text = DateFormat(DateTime.Today.ToString());
                FillddlClientCode(ddlUnClientCode, ddlUnAsmtCode, ddlUnPostCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            txtTimeFrom.Attributes["onblur"] = "javascript:IsValidTime('" + txtTimeFrom.ClientID.ToString() + "');";
            txtTimeTo.Attributes["onblur"] = "javascript:IsValidTime('" + txtTimeTo.ClientID.ToString() + "');";
            txtITimeFrom.Attributes["onblur"] = "javascript:IsValidTime('" + txtITimeFrom.ClientID.ToString() + "');";
            txtITimeTO.Attributes["onblur"] = "javascript:IsValidTime('" + txtITimeTO.ClientID.ToString() + "');";
            txtPFromTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtPFromTime.ClientID.ToString() + "');";
            txtPToTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtPToTime.ClientID.ToString() + "');";
            txtVFromTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtVFromTime.ClientID.ToString() + "');";
            txtVToTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtVToTime.ClientID.ToString() + "');";
            txtNFromTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtNFromTime.ClientID.ToString() + "');";
            txtNToTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtNToTime.ClientID.ToString() + "');";
            txtGFromTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtGFromTime.ClientID.ToString() + "');";
            txtGToTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtGToTime.ClientID.ToString() + "');";
            txtUnTimeFrom.Attributes["onblur"] = "javascript:IsValidTime('" + txtUnTimeFrom.ClientID.ToString() + "');";
            txtUnTimeTo.Attributes["onblur"] = "javascript:IsValidTime('" + txtUnTimeTo.ClientID.ToString() + "');";
        }
    }
    #endregion

    #region Member Controls Event
    /// <summary>
    /// Handles the PageIndexChanging event of the gvDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDetail.PageIndex = e.NewPageIndex;
        gvDetail.EditIndex = -1;
        FillgvClientAttendanceDetails(DateTime.Parse(txtWEF.Text), DateTime.Parse(txtTimeFrom.Text), DateTime.Parse(txtTimeTo.Text));
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvPOP control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvPOP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPOP.PageIndex = e.NewPageIndex;
        FillgvPOP();
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmpDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmpDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gvEmpDetail = (GridView)sender;
        gvEmpDetail.PageIndex = e.NewPageIndex;
        FillgvEmpDetail(gvEmpDetail, HFAsmtCode.Value,HFPostAutoID.Value,HFPLocationTagID.Value);
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvGuardTourID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvGuardTourID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGuardTourID.EditIndex = -1;
        gvGuardTourID.PageIndex = e.NewPageIndex;
        FillGuardTourID();
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvGuardTour control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvGuardTour_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var PostTagID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PostTagID"));
            var TagIDDesc = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TagIDDesc"));
            var ScheduleTime = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ScheduleTime"));
            var SwipeTime = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SwipeTime"));
            var DutyDate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DutyDate"));
            var EmployeeNumber = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmployeeNumber"));
            var PhoneNumber = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PhoneNumber"));
            if (string.IsNullOrEmpty(EmployeeNumber))
            {
                e.Row.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                e.Row.BackColor = System.Drawing.Color.Green;
            }
        }
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var IMGRed = (Image)e.Row.FindControl("IMGRed");
            var lblActualScheduleMatchCount = (Label)e.Row.FindControl("lblActualScheduleMatchCount");
            var lblSchedule = (Label)e.Row.FindControl("lblSchedule");
            var lblUnScheduledEmployee = (Label)e.Row.FindControl("lblUnScheduledEmployee");
            var lblActualCount = (Label)e.Row.FindControl("lblActualCount");
            var lblIncompleteDuty = (Label)e.Row.FindControl("lblIncompleteDuty");

            if (lblSchedule != null)
            {
                if (int.Parse(lblSchedule.Text) == int.Parse(lblActualCount.Text) && lblSchedule.Text == lblActualScheduleMatchCount.Text)
                {
                    IMGRed.ImageUrl = "~/Images/Green1.jpg";
                }
                else if (int.Parse(lblSchedule.Text) > int.Parse(lblActualCount.Text))
                {
                    IMGRed.ImageUrl = "~/Images/red.jpg";
                }
                else if (int.Parse(lblSchedule.Text) == int.Parse(lblActualCount.Text) && int.Parse(lblUnScheduledEmployee.Text) > 0 && int.Parse(lblIncompleteDuty.Text) == 0)
                {
                    IMGRed.ImageUrl = "~/Images/blue.jpg";
                }
                else
                {
                    IMGRed.ImageUrl = "~/Images/Orange.jpg";
                }
            }
        }
    }

    /// <summary>
    /// Function is called on grid view gvGuardTour PageIndexChanging Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvGuardTour_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gvGuardTour = (GridView)sender;
        gvGuardTour.PageIndex = e.NewPageIndex;
        FillgvGuardTour(gvGuardTour, HFTourID.Value);
    }

    /// <summary>
    /// Function is called on grid view gvIncident PageIndexChanging Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncident_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvIncident.PageIndex = e.NewPageIndex;
        FillgvIncident(DateTime.Parse(txtIWEF.Text), DateTime.Parse(txtIWET.Text), DateTime.Parse(txtITimeFrom.Text), DateTime.Parse(txtITimeTO.Text));
    }

    /// <summary>
    /// Function is called on grid view gvPanic PageIndexChanging Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPanic_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPanic.PageIndex = e.NewPageIndex;
        UPPanic.Update();
        FillgvPanic(DateTime.Parse(txtPWEF.Text), DateTime.Parse(txtPWET.Text), DateTime.Parse(txtPFromTime.Text), DateTime.Parse(txtPToTime.Text));
    }

    /// <summary>
    /// Function is called on grid view gvVacant PageIndexChanging Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvVacant_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UPVacant.Update();
        gvVacant.PageIndex = e.NewPageIndex;
        FillgvVacant(DateTime.Parse(txtVWEF.Text), DateTime.Parse(txtVWET.Text), DateTime.Parse(txtVFromTime.Text), DateTime.Parse(txtVToTime.Text));
    }

    /// <summary>
    /// Function is called on grid view gvNoShow PageIndexChanging Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNoShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNoShow.PageIndex = e.NewPageIndex;
        FillgvNoShow(DateTime.Parse(txtNWEF.Text), DateTime.Parse(txtNWET.Text), DateTime.Parse(txtNFromTime.Text), DateTime.Parse(txtNToTime.Text));
    }

    /// <summary>
    /// Function is called on ImgbtnHyperLink Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgbtnHyperLink_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton Imgbtn = (ImageButton)sender;
        GridViewRow gvRow = (GridViewRow)Imgbtn.NamingContainer;
        Label lblgvAsmtCode = (Label)gvDetail.Rows[gvRow.RowIndex].FindControl("lblgvAsmtCode");
        Response.Redirect("AssignmentController.aspx?CId=" + lblgvAsmtCode.Text + "&date=" + DateTime.Parse(txtWEF.Text) + "&tf=" + DateTime.Parse(txtTimeFrom.Text) + "&tt=" + DateTime.Parse(txtTimeTo.Text) + "&WETDate=" + txtWET.Text);
    }

    /// <summary>
    /// Function is called on btnSubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        FillgvClientAttendanceDetails(DateTime.Parse(txtWEF.Text), DateTime.Parse(txtTimeFrom.Text), DateTime.Parse(txtTimeTo.Text));
    }

    /// <summary>
    /// Function is called on btnISubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnISubmit_Click(object sender, EventArgs e)
    {
        FillgvIncident(DateTime.Parse(txtIWEF.Text), DateTime.Parse(txtIWET.Text), DateTime.Parse(txtITimeFrom.Text), DateTime.Parse(txtITimeTO.Text));
    }

    /// <summary>
    /// Function is called on btnPSubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPSubmit_Click(object sender, EventArgs e)
    {
        FillgvPanic(DateTime.Parse(txtPWEF.Text), DateTime.Parse(txtPWET.Text), DateTime.Parse(txtPFromTime.Text), DateTime.Parse(txtPToTime.Text));
    }

    /// <summary>
    /// Function is called on btnVSubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnVSubmit_Click(object sender, EventArgs e)
    {
        FillgvVacant(DateTime.Parse(txtVWEF.Text), DateTime.Parse(txtVWET.Text), DateTime.Parse(txtVFromTime.Text), DateTime.Parse(txtVToTime.Text));
    }

    /// <summary>
    /// Function is called on btnNSubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNSubmit_Click(object sender, EventArgs e)
    {
        FillgvNoShow(DateTime.Parse(txtNWEF.Text), DateTime.Parse(txtNWET.Text), DateTime.Parse(txtNFromTime.Text), DateTime.Parse(txtNToTime.Text));
    }

    /// <summary>
    /// Function is called on btnGSubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGSubmit_Click(object sender, EventArgs e)
    {
        txtExportString.Text = "";
        FillGuardTourID();
    }

    /// <summary>
    /// Function is called on btnPOPSubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPOPSubmit_Click(object sender, EventArgs e)
    {
        FillgvPOP();
    }

    /// <summary>
    /// Function is called on lbAsmtCode Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblPostCode_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var gvEmpDetail = (GridView)gvPOP.Rows[row.RowIndex].FindControl("gvEmpDetail");
        var lblAsmtCode = (Label)gvPOP.Rows[row.RowIndex].FindControl("lblAsmtCode");
        var lblPostAutoID = (Label)gvPOP.Rows[row.RowIndex].FindControl("lblpostAutoID");
         var lblLocationTagID= (Label)gvPOP.Rows[row.RowIndex].FindControl("lblLocationTagID") ;
        HFAsmtCode.Value = lblAsmtCode.Text;
        HFPostAutoID.Value=lblPostAutoID.Text;
        HFPLocationTagID.Value=lblLocationTagID.Text;
        FillgvEmpDetail(gvEmpDetail, lblAsmtCode.Text,lblPostAutoID.Text,lblLocationTagID.Text);
    }

    /// <summary>
    /// Function is called on lblTourID Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblTourID_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var gvGuardTour = (GridView)gvGuardTourID.Rows[row.RowIndex].FindControl("gvGuardTour");
        var HFGuardTourID = (HiddenField)gvGuardTourID.Rows[row.RowIndex].FindControl("HFGuardTourID");
        var lblTourID = (LinkButton)gvGuardTourID.Rows[row.RowIndex].FindControl("lblTourID");
        HFTourID.Value = HFGuardTourID.Value;
        FillgvGuardTour(gvGuardTour, HFGuardTourID.Value);
    }

    /// <summary>
    /// Function is called on txtPOPWEF Text Change Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtPOPWEF_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtPOPWEF);
    }

    /// <summary>
    /// Function is called on ddlClientCode SelectedIndexChanged Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmtCode(ddlClientCode, ddlAsmtCode, ddlPostCode);
    }

    /// <summary>
    /// Function is called on ddlAsmtCode SelectedIndexChanged Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPost(ddlClientCode, ddlAsmtCode, ddlPostCode);
    }

    /////////////////Unscheduled Emploee ---------------------
    /// <summary>
    /// Function is called on ddlUnClientCode SelectedIndexChanged Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlUnClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmtCode(ddlUnClientCode, ddlUnAsmtCode, ddlUnPostCode);
    }

    /// <summary>
    /// Function is called on ddlUnAsmtCode SelectedIndexChanged Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlUnAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPost(ddlUnClientCode, ddlUnAsmtCode, ddlUnPostCode);
    }

    /// <summary>
    /// Function is called on txtUnWEF TextChanged Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtUnWEF_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtUnWEF);
    }
    
    /// <summary>
    /// Function is called on btnUnSubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUnSubmit_Click(object sender, EventArgs e)
    {
        FillgvUnscheduledEmployee(ddlUnClientCode.SelectedItem.Value, ddlUnAsmtCode.SelectedItem.Value, ddlUnPostCode.SelectedItem.Value, txtUnWEF.Text, txtUnWET.Text, DateTimeFormat(DateTime.Parse(txtUnTimeFrom.Text)), DateTimeFormat(DateTime.Parse(txtUnTimeTo.Text)));
    }

    /// <summary>
    /// Function is called on gvUnscheduledEmployee PageIndexChanging Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUnscheduledEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUnscheduledEmployee.PageIndex = e.NewPageIndex;
        gvUnscheduledEmployee.EditIndex = -1;
        FillgvUnscheduledEmployee(ddlUnClientCode.SelectedItem.Value, ddlUnAsmtCode.SelectedItem.Value, ddlUnPostCode.SelectedItem.Value, txtUnWEF.Text, txtUnWET.Text, DateTimeFormat(DateTime.Parse(txtUnTimeFrom.Text)), DateTimeFormat(DateTime.Parse(txtUnTimeTo.Text)));
    }
    ///-------------------------------Unscheduled Employee  End
    #endregion

    #region Member Functions

    /// <summary>
    /// Function is used to fill Clients in Client Drop Down list.
    /// </summary>
    /// <param name="ddlClientCode"></param>
    /// <param name="ddlAsmtCode"></param>
    /// <param name="ddlPostCode"></param>
    protected void FillddlClientCode(DropDownList ddlClientCode, DropDownList ddlAsmtCode, DropDownList ddlPostCode)
    {
        var objSales = new BL.Sales();
        var ds = new DataSet();
        ddlClientCode.Items.Clear();

        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            ds = objSales.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objSales.ClientsMappedToLocationGet(BaseLocationAutoID);
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientCodeName";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();

            if (BaseIsAdmin.Trim().ToLower() != "c")
            {
                var li = new ListItem();
                li.Text = Resources.Resource.All;
                li.Value = "ALL";
                ddlClientCode.Items.Insert(0, li);
            }
            FillddlAsmtCode(ddlClientCode, ddlAsmtCode, ddlPostCode);
        }
        else
        {
            var li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = string.Empty;
            ddlClientCode.Items.Insert(0, li);
        }
        ds.Dispose();
    }

    /// <summary>
    /// Function is used to fill Assignment in drop down list.
    /// </summary>
    /// <param name="ddlClientCode"></param>
    /// <param name="ddlAsmtCode"></param>
    /// <param name="ddlPostCode"></param>
    private void FillddlAsmtCode(DropDownList ddlClientCode, DropDownList ddlAsmtCode, DropDownList ddlPostCode)
    {
        var objOperationManagement = new BL.OperationManagement();
        var objSales = new BL.Sales();
        var dsAsmt = new DataSet();
        ddlAsmtCode.Items.Clear();
        ddlPostCode.Items.Clear();
        if (string.IsNullOrEmpty(ddlClientCode.SelectedValue))
        {
            var li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = string.Empty;
            ddlAsmtCode.Items.Insert(0, li);
            ddlPostCode.Items.Insert(0, li);
            return;
        }
        if (ddlClientCode.SelectedValue.ToString().Trim().ToLower() == "all")
        {
            var li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlPostCode.Items.Insert(0, li);
            ddlAsmtCode.Items.Insert(0, li);
        }
        else
        {
            //Modify by  on 14-May-2014 as Discussed with Manesh Srivastava
            dsAsmt = objOperationManagement.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value);
            if (dsAsmt != null && dsAsmt.Tables[0].Rows.Count > 0 && dsAsmt.Tables.Count > 0)
            {
                ddlAsmtCode.DataSource = dsAsmt.Tables[0];
                ddlAsmtCode.DataTextField = "AsmtDetail";
                ddlAsmtCode.DataValueField = "AsmtCode";
                ddlAsmtCode.DataBind();

                var li = new ListItem();
                li.Text = Resources.Resource.All;
                li.Value = "ALL";
                ddlAsmtCode.Items.Insert(0, li);
                FillddlPost(ddlClientCode, ddlAsmtCode, ddlPostCode);
            }
            else
            {
                var li = new ListItem();
                li.Text = Resources.Resource.NoDataToShow;
                li.Value = string.Empty;
                ddlAsmtCode.Items.Insert(0, li);
                ddlPostCode.Items.Insert(0, li);
            }
        }
        dsAsmt.Dispose();
    }

    /// <summary>
    /// Function used to fill post in drop down list.
    /// </summary>
    /// <param name="ddlClientCode"></param>
    /// <param name="ddlAsmtCode"></param>
    /// <param name="ddlPostCode"></param>
    private void FillddlPost(DropDownList ddlClientCode, DropDownList ddlAsmtCode, DropDownList ddlPostCode)
    {
        var ds = new DataSet();
        var objOperationManagement = new BL.OperationManagement();
        ddlPostCode.Items.Clear();
        if (string.IsNullOrEmpty(ddlAsmtCode.SelectedValue))
        {
            var li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = string.Empty;
            ddlPostCode.Items.Insert(0, li);
            return;
        }
        if (ddlAsmtCode.SelectedValue.Trim().ToLower() == "all")
        {
            var li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlPostCode.Items.Insert(0, li);
        }
        else
        {
            ds = objOperationManagement.BLPOPGetAllPost(ddlAsmtCode.SelectedValue, BaseLocationAutoID, txtGWef.Text, txtGWet.Text, ddlClientCode.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                ddlPostCode.DataSource = ds.Tables[0];
                ddlPostCode.DataTextField = "Post";
                ddlPostCode.DataValueField = "PostAutoId";
                ddlPostCode.DataBind();

                if (BaseIsAdmin.Trim().ToLower() != "c")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.All;
                    li.Value = "ALL";
                    ddlPostCode.Items.Insert(0, li);
                }
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoDataToShow;
                li.Value = string.Empty;
                ddlPostCode.Items.Insert(0, li);
            }
        }
        ds.Dispose();
    }

    /// <summary>
    /// Fillgvs the pop.
    /// </summary>
    private void FillgvPOP()
    {
        string strClientCode = string.Empty;
        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            strClientCode = BaseUserID;
        }
        var ds = new DataSet();
        var objUploadSwipe = new BL.UploadSwipe();
        ds = objUploadSwipe.BlPOPGetClientData(txtPOPWEF.Text, strClientCode, txtPOPWET.Text, BaseLocationAutoID);
        gvPOP.DataSource = ds;
        gvPOP.DataBind();
        if (gvPOP.Rows.Count > 0)
        {
            btnPOPExport.Visible = true;
        }
        else
        {
            btnPOPExport.Visible = false;
        }
    }

    /// <summary>
    /// Fillgvs the emp detail.
    /// </summary>
    /// <param name="gvEmpDetail">The gv emp detail.</param>
    /// <param name="lbAsmtCode">The lb asmt code.</param>
    private void FillgvEmpDetail(GridView gvEmpDetail, string lbAsmtCode,string lblPostAutoID,string locationTagID )
    {
        var ds = new DataSet();
        var objUploadSwipe = new BL.UploadSwipe();
        ds = objUploadSwipe.BlPOPGetEmployeeDetail(txtPOPWEF.Text, BaseLocationAutoID, lbAsmtCode, txtPOPWET.Text, lblPostAutoID, locationTagID);
        gvEmpDetail.DataSource = ds;
        gvEmpDetail.DataBind();
    }

    /// <summary>
    ///   Showing the details of client scheduled employee, onduty employee, Actual Count , unscheduled employee Etc.
    /// </summary>
    /// <param name="date"></param>
    /// <param name="tf"></param>
    /// <param name="tt"></param>
    private void FillgvClientAttendanceDetails(DateTime date, DateTime tf, DateTime tt)
    {
        gvDetail.Visible = false;
        var objMics = new BL.Misc();
        var ds = new DataSet();
        var dt = new DataTable();
        var strClientCode = string.Empty;

        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            strClientCode = BaseUserID;
        }
        ds = objMics.BlClientController(date, tf, tt, strClientCode, txtWET.Text, BaseLocationAutoID, "CLIENT", null, null);
        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnASubmit.Style.Value = "display:block";
        }
        else
        {
            btnASubmit.Style.Value = "display:none";
        }
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
        gvDetail.Visible = true;
        dt.Dispose();
        ds.Dispose();
    }

    /// <summary>
    /// Showing the incident occured on the basis of vlaue passed 
    /// </summary>
    /// <param name="IncidentfromDate">Incident From date </param>
    /// <param name="IncidenttoDate"> Incident To date </param>
    /// <param name="IncidentfromTime"> Incident Time From </param>
    /// <param name="IncidenttoTime"> Incident Time From</param>
    private void FillgvIncident(DateTime IncidentfromDate, DateTime IncidenttoDate, DateTime IncidentfromTime, DateTime IncidenttoTime)
    {
        var strClientCode = string.Empty;
        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            strClientCode = BaseUserID;
        }
        var objMisc = new BL.NFC();
        var ds = new DataSet();
        var dt = new DataTable();
        ds = objMisc.BlNfcGetAllIncidentClientController(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(IncidentfromTime), DateTimeFormat(IncidenttoTime), DateFormat(IncidentfromDate), DateFormat(IncidenttoDate), BaseUserID);
        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnIExport.Style.Value = "display:block";
        }
        else
        {
            btnIExport.Style.Value = "display:none";
        }
        gvIncident.Dispose();
        gvIncident.DataSource = dt;
        gvIncident.DataBind();
        dt.Dispose();
        ds.Dispose();
    }

    /// <summary>
    ///  Showing the panic alerts occured on the basis of vlaue passed  
    /// </summary>
    /// <param name="PanicfromDate"> From date</param>
    /// <param name="PanictoDate">To date</param>
    /// <param name="PanictimeFrom">From time </param>
    /// <param name="PanictimeTo">To time </param>
    private void FillgvPanic(DateTime PanicfromDate, DateTime PanictoDate, DateTime PanictimeFrom, DateTime PanictimeTo)
    {
        var strClientCode = string.Empty;
        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            strClientCode = BaseUserID;
        }
        var objMisc = new BL.NFC();
        var ds = new DataSet();
        var dt = new DataTable();
        ds = objMisc.BlNfcGetAllPanicAlertsClientController(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(PanictimeFrom), DateTimeFormat(PanictimeTo), DateFormat(PanicfromDate), DateFormat(PanictoDate), BaseUserID);
        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnPExport.Style.Value = "display: block";
            btnPExport.Visible = true;
        }
        else
        {
            btnPExport.Style.Value = "dispaly: none";
            btnPExport.Visible = false;
        }
        gvPanic.Dispose();
        gvPanic.DataSource = dt;
        gvPanic.DataBind();
        dt.Dispose();
        ds.Dispose();
    }

    /// <summary>
    ///   Showing the Vacant Post alerts occured on the basis of vlaue passed 
    /// </summary>
    /// <param name="VacantfromDate">From date </param>
    /// <param name="VacanttoDate">To date </param>
    /// <param name="VacanttimeFrom">From time </param>
    /// <param name="VacanttimeTo">To time </param>
    private void FillgvVacant(DateTime VacantfromDate, DateTime VacanttoDate, DateTime VacanttimeFrom, DateTime VacanttimeTo)
    {
        //Flag variable is used for handel the alerts off in control panel screen if employee is come late;
        //Ex: If employee is not there on post at 6:15 and he scheduled 6:00.Employee comes on 6:20
        //In control panel screen now there is no alerts for this employee but in client controller should be there
        //Flag=string.Empty; assume client controller calling that page
        //Flag=is not null assume control panel calling
        var flag = string.Empty;
        var strClientCode = string.Empty;

        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            strClientCode = BaseUserID;
        }

        var objMisc = new BL.NFC();
        var ds = new DataSet();
        var dt = new DataTable();
        VacantfromDate = DateTime.Parse(txtVWEF.Text);
        VacanttoDate = DateTime.Parse(txtVWET.Text);
        VacanttimeFrom = DateTime.Parse(txtVFromTime.Text);
        VacanttimeTo = DateTime.Parse(txtVToTime.Text);
        ds = objMisc.BlNfcGetAllvacantPostClientController(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(VacanttimeFrom), DateTimeFormat(VacanttimeTo), DateFormat(VacantfromDate), DateFormat(VacanttoDate), BaseUserID, flag);
        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnVExport.Style.Value = "display:none";  //"display:block";
        }
        else
        {
            btnVExport.Style.Value = "display:none";
        }
        gvVacant.Dispose();
        gvVacant.DataSource = dt;
        gvVacant.DataBind();

        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            gvVacant.Columns[3].Visible = false;
        }
        else
        {
            gvVacant.Columns[3].Visible = true;
        }
        dt.Dispose();
        ds.Dispose();
    }

    /// <summary>
    /// Showing the Noshow alerts occured on the basis of vlaue passed 
    /// </summary>
    /// <param name="NoshowfromDate"> From date </param>
    /// <param name="NoshowtoDate"> To date </param>
    /// <param name="NoshowtimeFrom"> From time </param>
    /// <param name="NoshowtimeTo"> To time </param>
    private void FillgvNoShow(DateTime NoshowfromDate, DateTime NoshowtoDate, DateTime NoshowtimeFrom, DateTime NoshowtimeTo)
    {
        var strClientCode = string.Empty;
        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            strClientCode = BaseUserID;
            gvNoShow.Columns[2].Visible = false;
        }
        else
        {
            gvNoShow.Columns[2].Visible = true;
        }
        var objMisc = new BL.NFC();
        var ds = new DataSet();
        var dt = new DataTable();
        ds = objMisc.BlNfcGetAllNoShowClientController(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(NoshowtimeFrom), DateTimeFormat(NoshowtimeTo), DateFormat(NoshowfromDate), DateFormat(NoshowtoDate), BaseUserID);
        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnNExport.Style.Value = "display:none"; //"display:block";
        }
        else
        {
            btnNExport.Style.Value = "display:none";
        }
        gvNoShow.Dispose();
        gvNoShow.DataSource = dt;
        gvNoShow.DataBind();

        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            gvNoShow.Columns[2].Visible = false;
        }
        else
        {
            gvNoShow.Columns[2].Visible = true;
        }
        dt.Dispose();
        ds.Dispose();
    }

    /// <summary>
    /// Fills the guard tour identifier.
    /// </summary>
    private void FillGuardTourID()
    {
        var objMisc = new BL.Misc();
        var ds = new DataSet();
        var dt = new DataTable();
        ds = objMisc.BlMiscGetAllGuardTourID(BaseCompanyCode, BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), ddlAsmtCode.SelectedValue.ToString(), ddlPostCode.SelectedValue.ToString());
        dt = ds.Tables[0];
        gvGuardTourID.Dispose();
        gvGuardTourID.DataSource = dt;
        gvGuardTourID.DataBind();
        if (gvGuardTourID.Rows.Count > 0)
        {
            btnGExport.Visible = true;
            btnGExportDevX.Visible = false;
        }
        else
        {
            btnGExport.Visible = false;
            btnGExportDevX.Visible = false;
        }
        dt.Dispose();
        ds.Dispose();
    }

    /// <summary>
    /// Function is used to fill gvUnscheduledEmployee grid view.
    /// </summary>
    /// <param name="ClientCode"></param>
    /// <param name="AsmtCode"></param>
    /// <param name="PostCode"></param>
    /// <param name="Fromdate"></param>
    /// <param name="Todate"></param>
    /// <param name="TimeFrom"></param>
    /// <param name="TimeTo"></param>
    private void FillgvUnscheduledEmployee(string ClientCode, string AsmtCode, string PostCode, string Fromdate, string Todate, string TimeFrom, string TimeTo)
    {
        var objMisc = new BL.NFC();
        var ds = new DataSet();
        var dt = new DataTable();
        ds = objMisc.BlNfcUnscheduledEmployee(ClientCode, AsmtCode, PostCode, Fromdate, Todate, DateTimeFormat(DateTime.Parse(TimeFrom)), DateTimeFormat(DateTime.Parse(TimeTo)), BaseLocationAutoID);
        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnUnExport.Style.Value = "display:block";
        }
        else
        {
            btnUnExport.Style.Value = "display:none";

        }
        gvUnscheduledEmployee.Dispose();
        gvUnscheduledEmployee.DataSource = dt;
        gvUnscheduledEmployee.DataBind();
    }


    /// <summary>
    /// Function is used to fill guard tour details.
    /// </summary>
    /// <param name="gvGuardTour"></param>
    /// <param name="lblTourID"></param>
    private void FillgvGuardTour(GridView gvGuardTour, string lblTourID)
    {
        var ds = new DataSet();
        var dt = new DataTable();
        if (txtExportString.Text.Length == 0)
        {
            txtExportString.Text = lblTourID;
        }
        else
        {
            txtExportString.Text = txtExportString.Text + ";" + lblTourID;
        }
        var objMisc = new BL.Misc();
        ds = objMisc.BlMiscGetAllGuardTour(BaseCompanyCode, BaseLocationAutoID, ddlClientCode.SelectedValue, DateTimeFormat(DateTime.Parse(txtGFromTime.Text)), DateTimeFormat(DateTime.Parse(txtGToTime.Text)), DateFormat(DateTime.Parse(txtGWef.Text)), DateFormat(DateTime.Parse(txtGWet.Text)), BaseUserID, lblTourID, ddlAsmtCode.SelectedValue, ddlPostCode.SelectedValue, ddlScanType.SelectedValue);
        dt = ds.Tables[0];
        gvGuardTour.Dispose();
        gvGuardTour.DataSource = dt;
        gvGuardTour.DataBind();

        if (BaseIsAdmin.Trim().ToLower() == "c")
        {
            gvGuardTour.Columns[6].Visible = false;
        }
        else
        {
            gvGuardTour.Columns[6].Visible = true;
        }
        dt.Dispose();
        ds.Dispose();
    }

    /// <summary>
    /// Function is used to convert string to datetime format.
    /// </summary>
    /// <param name="txtDate"></param>
    private void ConvertStringToDateFormat(TextBox txtDate)
    {
        var date = string.Empty;
        txtDate.BackColor = System.Drawing.Color.Empty;
        var objCommon = new BL.Common();
        if (objCommon.IsValidDate(txtDate.Text))
        {
            txtDate.Text = DateTime.Parse(txtDate.Text).ToString("dd-MMM-yyyy");
        }
        else
        {
            date = objCommon.ConvertToDate(txtDate.Text);
            if (date == "1")
            {
                lblErrorMsg.Text = Resources.Resource.Yearnotincorrectformat;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "2")
            {
                lblErrorMsg.Text = Resources.Resource.Monthnotincorrectformat;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "3")
            {
                lblErrorMsg.Text = Resources.Resource.Daynotincorrectformat;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "4")
            {
                lblErrorMsg.Text = Resources.Resource.Notaleapyear;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "5")
            {
                lblErrorMsg.Text = Resources.Resource.Numberofdaysnotcorrect; ;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "6")
            {
                lblErrorMsg.Text = Resources.Resource.Datenotincorrectformat;
                txtDate.Text = txtDate.Text;
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                txtDate.Text = date;
                txtDate.BackColor = System.Drawing.Color.Empty;
            }
        }
    }
    #endregion

    #region Export into Excel
    /// <summary>
    /// Comman Function to Export grid into Excel
    /// </summary>
    /// <param name="gdv"></param>
    /// <param name="strFieName"></param>
    protected void exportToExcel(DataTable dt, GridView gdv, string strFieName)
    {
        var tab = string.Empty;
        var attachment = string.Empty;
        var sw = new System.IO.StringWriter();
        var htw = new HtmlTextWriter(sw);

        attachment = "attachment; filename=" + strFieName;
        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";

        gdv.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
        
        for (int k = 0; k < gdv.Columns.Count; k++)
        {
            Response.Write(tab + gdv.Columns[k].HeaderText);
            tab = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            tab = string.Empty;
            for (int k = 0; k < gdv.Columns.Count; k++)
            {
                Response.Write(tab + dr[gdv.Columns[k].AccessibleHeaderText].ToString());
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }
    
    //Export Incident
    /// <summary>
    /// Function is called on btnIExport Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIExport_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        var strClientCode = string.Empty;
        url = "Export.aspx?type=INCIDENT&clnt=" + strClientCode + "&tf=" + DateTime.Parse(txtITimeFrom.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&tt=" + DateTime.Parse(txtITimeTO.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&dtf=" + DateTime.Parse(txtIWEF.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&dtt=" + DateFormat(DateTime.Parse(txtIWET.Text));
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    //Export GuardTour
    /// <summary>
    /// Function is called on btnGExport Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGExport_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        Session["GuardTourPostCode"] = ddlPostCode.SelectedValue.ToString();
        url = "Export.aspx?type=GUARDTOUR&clnt=" + ddlClientCode.SelectedValue.ToString() + "&tf=" + DateTimeFormat(DateTime.Parse(txtGFromTime.Text)) + "&tt=" + DateTimeFormat(DateTime.Parse(txtGToTime.Text)) + "&dtf=" + DateFormat(DateTime.Parse(txtGWef.Text)) + "&dtt=" + DateFormat(DateTime.Parse(txtGWet.Text)) + "&asmt=" + ddlAsmtCode.SelectedValue.ToString() + "&post=" + ddlPostCode.SelectedValue.ToString() + "&scantype=" + ddlScanType.SelectedValue.ToString() + "&selectedGT=" + txtExportString.Text.ToString() + "&tourId=0";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    /// <summary>
    /// Function is called on btnGExportDevX Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGExportDevX_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        Session["GuardTourPostCode"] = ddlPostCode.SelectedValue.ToString();
        url = "Export_DevX.aspx?type=GUARDTOUR&clnt=" + ddlClientCode.SelectedValue.ToString() + "&tf=" + DateTimeFormat(DateTime.Parse(txtGFromTime.Text)) + "&tt=" + DateTimeFormat(DateTime.Parse(txtGToTime.Text)) + "&dtf=" + DateFormat(DateTime.Parse(txtGWef.Text)) + "&dtt=" + DateFormat(DateTime.Parse(txtGWet.Text)) + "&asmt=" + ddlAsmtCode.SelectedValue.ToString() + "&post=" + ddlPostCode.SelectedValue.ToString() + "&scantype=" + ddlScanType.SelectedValue.ToString() + "&selectedGT=" + txtExportString.Text.ToString() + "&tourId=0";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    // Export No Show 
    /// <summary>
    /// Function is called on btnNExport Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNExport_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        var strClientCode = string.Empty;
        url = "Export.aspx?type=NOSHOW&clnt=" + strClientCode + "&tf=" + DateTime.Parse(txtNFromTime.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&tt=" + DateTime.Parse(txtNToTime.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&dtf=" + DateTime.Parse(txtNWEF.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&dtt=" + DateFormat(DateTime.Parse(txtNWET.Text));
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    //Export Vacant 
    /// <summary>
    /// Function is called on btnVExport Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnVExport_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        var strClientCode = string.Empty;
        url = "Export.aspx?type=VACANT&clnt=" + strClientCode + "&tf=" + DateTime.Parse(txtVFromTime.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&tt=" + DateTime.Parse(txtVToTime.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&dtf=" + DateTime.Parse(txtVWEF.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&dtt=" + DateFormat(DateTime.Parse(txtVWET.Text));
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    //Export panic
    /// <summary>
    /// Function is called on btnPExport Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPExport_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        var strClientCode = string.Empty;
        url = "Export.aspx?type=PANIC&clnt=" + strClientCode + "&dtf=" + DateFormat(DateTime.Parse(txtPWEF.Text)) + "&tf=" + DateTime.Parse(txtPFromTime.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&tt=" + DateTime.Parse(txtPToTime.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&dtt=" + DateFormat(DateTime.Parse(txtPWET.Text));
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    //Export POP
    /// <summary>
    /// Function is called on btnPOPExport Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPOPExport_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        url = "Export.aspx?type=POP&asmt=&dtf=" + txtPOPWEF.Text + "&dtt=" + txtPOPWET.Text;
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    //Export Attendance
    /// <summary>
    /// Function is called on btnASubmit Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnASubmit_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        var strClientCode = string.Empty;
        url = "Export.aspx?type=ATTENDANCE&asmt=All&dt=" + DateTime.Parse(txtWEF.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&tf=" + DateTime.Parse(txtTimeFrom.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&tt=" + DateTime.Parse(txtTimeTo.Text).ToString("dd-MMM-yyyy hh:mm tt") + "&wet=" + txtWET.Text;
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    /// <summary>
    /// Function is called on btnUnExport Click Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUnExport_Click(object sender, EventArgs e)
    {
        var url = string.Empty;
        var strClientCode = string.Empty;
        Session["UncheduledEmployeepost"] = ddlUnPostCode.SelectedItem.Value;
        
        url = "Export.aspx?type=Unscheduled&clnt=" + ddlUnClientCode.SelectedItem.Value + "&tf=" + DateTimeFormat(DateTime.Parse(txtUnTimeFrom.Text)) + "&tt=" + DateTimeFormat(DateTime.Parse(txtUnTimeTo.Text)) + "&dtf=" + DateFormat(DateTime.Parse(txtUnWEF.Text)) + "&dtt=" + DateFormat(DateTime.Parse(txtUnWET.Text)) + "&asmt=" + ddlUnAsmtCode.SelectedItem.Value + "&post=" + ddlUnPostCode.SelectedItem.Value;
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }
    #endregion

    #region Attachment Download
    /// <summary>
    /// Function is called on gvIncident RowCommand Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncident_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var path = string.Empty;
        if (e.CommandName == "cmd")
        {
           // path = MapPath(e.CommandArgument.ToString());
            byte[] imageAsByteArray;
            using (var webClient = new WebClient())
            {
                imageAsByteArray = webClient.DownloadData(e.CommandArgument.ToString());
            }

            WebRequest req = WebRequest.Create(e.CommandArgument.ToString());
            WebResponse response = req.GetResponse();
            Stream stream = response.GetResponseStream();
            Response.Clear();
            Response.ContentType = "image/png";
            Response.AddHeader("Content-Type", "Application/octet-stream");
            Response.AddHeader("Content-Length", imageAsByteArray.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument.ToString());
            Response.BinaryWrite(imageAsByteArray);
            Response.Flush();
            Response.End();

        }
    }

    /// <summary>
    /// Function is called on gvIncident RowDataBound Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvIncident_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var imgView = (Image)e.Row.FindControl("imgView");
            var URL = imgView.ImageUrl;
            if (URL.Contains(".jpg"))
            {
                imgView.ImageUrl = "~/Images/red.jpg";
            }
        }
    }
    #endregion
}
