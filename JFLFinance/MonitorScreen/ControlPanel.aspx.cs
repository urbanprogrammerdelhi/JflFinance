// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 
//
// Last Modified By :  
// Last Modified On : 21-May-2014
// ***********************************************************************
// <copyright file="ControlPanel.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Control Panel namespace.
/// </summary>

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class MonitorScreen_ControlPanel : BasePage
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
    /// <summary>
    /// Control Panel Screen Page Load
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">Event Args</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.Form.Attributes["onload"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ControlPanel.aspx';";
            //this.Form.Attributes["onload"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";
            //this.Form.Attributes.Add("onload", "this.form.target='_blank'");
            ViewState["StopRefreshstatus"] = 1;
            //FillIncident();
            //FillPanicAlerts();
            FillNoShow();
            FillVacantPost();
            //FillPopNoResponse();
            //FillGuardTour();
            btnStartRefresh.Visible = false;
        }
        //lblRefreshTime.Text = DateTime.Now.ToString("ss");

    }
    /// <summary>
    /// Fills Incident Grid
    /// </summary>
    private void FillIncident()
    {

        var ds = new DataSet();
        var objNFC = new BL.NFC();
        string strClientCode = string.Empty;
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            strClientCode = BaseUserID;
        }
        else
        {
            strClientCode = "";
        }
        var dtIncident = new DataTable();
        string strTimeFrom = DateTime.Now.ToString("dd-MMM-yyyy") + " 00:00:00";
        string strTimeTo = DateTime.Now.ToString("dd-MMM-yyyy") + " 23:59:59";
        ds = objNFC.IncidentGetAll(BaseCompanyCode, BaseLocationAutoID, strClientCode, strTimeFrom, strTimeTo, DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID);
        dtIncident = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtIncident.Rows.Count > 0)
        {
            gvIncident.DataSource = dtIncident;
            gvIncident.DataBind();
        }
        else
        {
            dtIncident.Rows.Add(dtIncident.NewRow());
            dtIncident.Rows[0]["ReadStatus"] = "1";
            gvIncident.DataSource = dtIncident;
            gvIncident.DataBind();
            int TotalColumns = gvIncident.Rows[0].Cells.Count;
            gvIncident.Rows[0].Cells.Clear();
            gvIncident.Rows[0].Cells.Add(new TableCell());
            gvIncident.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvIncident.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }


    }

    /// <summary>
    /// DataBound for Incident Grid
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">Event Args</param>
    protected void gvIncident_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //var IMGReadStatusIncident = (ImageButton)e.Row.FindControl("IMGReadStatusIncident");
            //if (IMGReadStatusIncident != null)
            //{

            //}

            var lblPost = (Label)e.Row.FindControl("lblPost");
            var lblIncidentID = (HiddenField)e.Row.FindControl("lblIncidentID");
            var lblIncidentType = (Label)e.Row.FindControl("lblIncidentType");
            var lblReportedBy = (Label)e.Row.FindControl("lblReportedBy");
            var lblName = (Label)e.Row.FindControl("lblName");
            var lblTime = (Label)e.Row.FindControl("lblTime");
            var lblPhone = (Label)e.Row.FindControl("lblPhone");
            var lblStatusIncident = (Label)e.Row.FindControl("lblStatusIncident");
            var lblClientName=(Label)e.Row.FindControl("lblClientName");
            var lblAssignment=(Label)e.Row.FindControl("lblAssignment");

           
            if (lblIncidentID != null)
            {
                if (lblStatusIncident.Text.ToString() == "0")
                {
                    if (lblIncidentID.Value != "")
                    {
                    lblClientName.ToolTip = lblClientName.Text;
                    lblAssignment.ToolTip = lblAssignment.Text;
                    lblClientName.Text = lblClientName.Text.Trim().Length > 0 ? lblClientName.Text.Substring(0, lblClientName.Text.Length > 12 ? 12 : lblClientName.Text.Length) : string.Empty;
                    lblAssignment.Text = lblAssignment.Text.Trim().Length > 0 ? lblAssignment.Text.Substring(0, lblAssignment.Text.Length > 12 ? 12 : lblAssignment.Text.Length) : string.Empty;
                    
                        //e.Row.BackColor = System.Drawing.Color.Tomato;
                        lblPost.ForeColor = System.Drawing.Color.Red;
                        lblIncidentType.ForeColor = System.Drawing.Color.Red;
                        lblReportedBy.ForeColor = System.Drawing.Color.Red;
                        lblName.ForeColor = System.Drawing.Color.Red;
                        lblPhone.ForeColor = System.Drawing.Color.Red;
                        lblTime.ForeColor = System.Drawing.Color.Red;
                        lblClientName.ForeColor=System.Drawing.Color.Red;
                        lblAssignment.ForeColor=System.Drawing.Color.Red;
                    }   
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.White;

                    }
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;

                }
            }

            //Hide the Phone number coloumn when Client Is Login  
            if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
            {
                gvIncident.Columns[8].Visible = false;
            }
            else
            {
                gvIncident.Columns[8].Visible = true;
            }

        }


    }

    /// <summary>
    /// Fill Panic Alert Grid
    /// </summary>
    private void FillPanicAlerts()
    {
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        string strClientCode = string.Empty;

        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            strClientCode = BaseUserID;
        }
        else
        {
            strClientCode = "";
        }
        string strTimeFrom = DateTime.Now.ToString("dd-MMM-yyyy") + " 00:00:00";
        string strTimeTo = DateTime.Now.ToString("dd-MMM-yyyy") + " 23:59:59";
        DataTable dtPanic = new DataTable();
        ds = objNFC.PanicAlertsGetAll(BaseCompanyCode, BaseLocationAutoID, strClientCode, strTimeFrom, strTimeTo, DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID);
        dtPanic = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtPanic.Rows.Count > 0)
        {
            gvPanicAlert.DataSource = dtPanic;
            gvPanicAlert.DataBind();
        }
        else
        {
            dtPanic.Rows.Add(dtPanic.NewRow());
            dtPanic.Rows[0]["ReadStatus"] = "1";
            gvPanicAlert.DataSource = dtPanic;
            gvPanicAlert.DataBind();
            int TotalColumns = gvPanicAlert.Rows[0].Cells.Count;
            gvPanicAlert.Rows[0].Cells.Clear();
            gvPanicAlert.Rows[0].Cells.Add(new TableCell());
            gvPanicAlert.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvPanicAlert.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Databound Panic Alert
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">Event Args</param>
    protected void gvPanicAlert_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblPanicAlertId = (Label)e.Row.FindControl("lblPanicAlertId");
            var lblPost = (Label)e.Row.FindControl("lblPost");
            //var lblEmployeeNumber = (Label)e.Row.FindControl("lblEmployeeNumber");
            //var lblName = (Label)e.Row.FindControl("lblName");
            //var lblPhone = (Label)e.Row.FindControl("lblPhone");
            var lblTime = (Label)e.Row.FindControl("lblTime");
            var lblStatusPanic = (Label)e.Row.FindControl("lblStatusPanic");
            var lblClientName = (Label)e.Row.FindControl("lblClientName");
            var lblAssignment = (Label)e.Row.FindControl("lblAssignment");

            e.Row.BackColor = System.Drawing.Color.White;
            if (lblPanicAlertId != null)
            {
                lblClientName.ToolTip = lblClientName.Text;
                lblAssignment.ToolTip = lblAssignment.Text;
                lblClientName.Text = lblClientName.Text.Trim().Length > 0 ? lblClientName.Text.Substring(0, lblClientName.Text.Length > 12 ? 12 : lblClientName.Text.Length) : string.Empty;
                lblAssignment.Text = lblAssignment.Text.Trim().Length > 0 ? lblAssignment.Text.Substring(0, lblAssignment.Text.Length > 12 ? 12 : lblAssignment.Text.Length) : string.Empty;
                    
                if (lblStatusPanic.Text.ToString() == "0")
                {
                    if (lblPanicAlertId.Text != "")
                    {
                      
                        lblPanicAlertId.ForeColor = System.Drawing.Color.Red;
                        lblPost.ForeColor = System.Drawing.Color.Red;
                      
                        lblTime.ForeColor = System.Drawing.Color.Red;
                        lblClientName.ForeColor = System.Drawing.Color.Red;
                        lblAssignment.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                }

            }
        }
    }

    /// <summary>
    /// Fill No Show Grid
    /// </summary>
    private void FillNoShow()
    {
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        string strClientCode = string.Empty;

        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            strClientCode = BaseUserID;
        }
        else
        {
            strClientCode = "";
        }

        DataTable dtNoShow = new DataTable();
        ds = objNFC.NoShowGetAll(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(DateTime.Now), DateTimeFormat(DateTime.Now), DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID);
        dtNoShow = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtNoShow.Rows.Count > 0)
        {
            gvNoShow.DataSource = dtNoShow;
            gvNoShow.DataBind();
        }
        else
        {
            dtNoShow.Rows.Add(dtNoShow.NewRow());
            //dtNoShow.Rows[0]["ReadStatus"] = "1";
            gvNoShow.DataSource = dtNoShow;
            gvNoShow.DataBind();
            int TotalColumns = gvNoShow.Rows[0].Cells.Count;
            gvNoShow.Rows[0].Cells.Clear();
            gvNoShow.Rows[0].Cells.Add(new TableCell());
            gvNoShow.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvNoShow.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }

    /// <summary>
    /// Databound for No Show
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">Event Args</param>
    protected void gvNoShow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblStatus = (Label)e.Row.FindControl("lblStatus");
            var lblTimeDiff = (Label)e.Row.FindControl("lblTimeDiff");
            var lblPostCode = (Label)e.Row.FindControl("lblPostCode");
            var lblEmployeeNumber = (Label)e.Row.FindControl("lblEmployeeNumber");
            //var lblEmployeeName = (Label)e.Row.FindControl("lblEmployeeName");
            var lblPhoneNumber = (Label)e.Row.FindControl("lblPhoneNumber");
            var lblScheduledTimeFrom = (Label)e.Row.FindControl("lblScheduledTimeFrom");
            var lblReadStatusNoShow = (Label)e.Row.FindControl("lblReadStatusNoShow");
            var lblClientName = (Label)e.Row.FindControl("lblClientName");
            var lblAssignment = (Label)e.Row.FindControl("lblAssignment");

            //if (lblTimeDiff != null)
            //{
            //    if (lblTimeDiff.Text == "")
            //    {
            //        if (lblStatus != null)
            //        {
            //            lblStatus.Text = "Not Filled";
            //        }
            //    }
            //    else
            //    {
            //        lblStatus.Text = "Filled";
            //    }
            //}

            if (lblStatus != null)
            {
                if (lblStatus.Text != "")
                {
                    lblClientName.ToolTip = lblClientName.Text;
                    lblAssignment.ToolTip = lblAssignment.Text;
                    lblClientName.Text = lblClientName.Text.Trim().Length > 0 ? lblClientName.Text.Substring(0, lblClientName.Text.Length > 12 ? 12 : lblClientName.Text.Length) : string.Empty;
                    lblAssignment.Text = lblAssignment.Text.Trim().Length > 0 ? lblAssignment.Text.Substring(0, lblAssignment.Text.Length > 12 ? 12 : lblAssignment.Text.Length) : string.Empty;
                    //if (lblReadStatusNoShow.Text.ToString() == "0")
                    //{

                    //if (lblTimeDiff.Text != "")
                    //{
                    //    //e.Row.BackColor = System.Drawing.Color.LemonChiffon;
                    //    lblStatus.ForeColor = System.Drawing.Color.Gray;
                    //    lblTimeDiff.ForeColor = System.Drawing.Color.Gray;
                    //    lblPostCode.ForeColor = System.Drawing.Color.Gray;
                    //    lblEmployeeNumber.ForeColor = System.Drawing.Color.Gray;
                    //    //lblEmployeeName.ForeColor = System.Drawing.Color.Gray;
                    //    lblPhoneNumber.ForeColor = System.Drawing.Color.Gray;
                    //    lblScheduledTimeFrom.ForeColor = System.Drawing.Color.Gray;
                    //}
                    //else
                    //{
                    //    lblStatus.ForeColor = System.Drawing.Color.White;
                    //    lblTimeDiff.ForeColor = System.Drawing.Color.White;
                    //    lblPostCode.ForeColor = System.Drawing.Color.White;
                    //    lblEmployeeNumber.ForeColor = System.Drawing.Color.White;
                    //    //lblEmployeeName.ForeColor = System.Drawing.Color.White;
                    //    lblPhoneNumber.ForeColor = System.Drawing.Color.White;
                    //    lblScheduledTimeFrom.ForeColor = System.Drawing.Color.White;
                    //    e.Row.BackColor = System.Drawing.Color.Tomato;
                    //}

                    if (lblStatus.Text != "Filled")
                    {
                        //e.Row.BackColor = System.Drawing.Color.LemonChiffon;
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        lblTimeDiff.ForeColor = System.Drawing.Color.Red;
                        lblPostCode.ForeColor = System.Drawing.Color.Red;
                        lblEmployeeNumber.ForeColor = System.Drawing.Color.Red;
                        //lblEmployeeName.ForeColor = System.Drawing.Color.Red;
                        lblPhoneNumber.ForeColor = System.Drawing.Color.Red;
                        lblScheduledTimeFrom.ForeColor = System.Drawing.Color.Red;
                        lblAssignment.ForeColor = System.Drawing.Color.Red;
                        lblClientName.ForeColor = System.Drawing.Color.Red;
                        
                    }
                    else
                    {
                        lblStatus.ForeColor = System.Drawing.Color.White;
                        lblTimeDiff.ForeColor = System.Drawing.Color.White;
                        lblPostCode.ForeColor = System.Drawing.Color.White;
                        lblEmployeeNumber.ForeColor = System.Drawing.Color.White;
                        //lblEmployeeName.ForeColor = System.Drawing.Color.White;
                        lblPhoneNumber.ForeColor = System.Drawing.Color.White;
                        lblScheduledTimeFrom.ForeColor = System.Drawing.Color.White;
                        e.Row.BackColor = System.Drawing.Color.Tomato;
                        lblAssignment.ForeColor = System.Drawing.Color.White;
                        lblClientName.ForeColor = System.Drawing.Color.White;

                    }


                    // }
                    //else
                    //{
                    //    e.Row.BackColor = System.Drawing.Color.Empty;
                    //}
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Empty;
                }
            }



            //Hide the Phone number coloumn when Client Is Login  
            if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
            {
                gvNoShow.Columns[2].Visible = false;

            }
            else
            {
                gvNoShow.Columns[2].Visible = true;

            }


        }

    }

    /// <summary>
    /// Fill Vacant Post Grid
    /// </summary>
    private void FillVacantPost()
    {
        //Flag variable is used for handel the alerts off in control panel screen if employee is come late;
        //Ex: If employee is not there on post at 6:15 and he scheduled 6:00.Employee comes on 6:20
        //In control panel screen now there is no alerts for this employee but in client controller should be there
        //Flag=string.Empty; assume client controller calling that page
        //Flag=is not null assume control panel calling
        string flag = "CP";
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        string strClientCode = string.Empty;

        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            strClientCode = BaseUserID;
        }
        else
        {
            strClientCode = "";
        }
        string strTimeFrom = DateTime.Now.ToString("dd-MMM-yyyy") + " 00:00:00";
        DataTable dtVacantPost = new DataTable();
       // ds = objNFC.VacantPostGetAll(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(DateTime.Now), DateTimeFormat(DateTime.Now), DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID);
       // ds = objNFC.BlNfcGetAllvacantPostClientController(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(DateTime.Now), DateTimeFormat(DateTime.Now), DateFormat(DateTime.Now), DateFormat(DateTime.Now), BaseUserID, flag);

        ds = objNFC.BlNfcGetAllvacantPostClientController(BaseCompanyCode, BaseLocationAutoID, strClientCode, strTimeFrom, DateTimeFormat(DateTime.Now), DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID, flag);

        // ds = objNFC.blNfc_GetAllvacantPost(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTimeFormat(DateTime.Now), DateTimeFormat(DateTime.Now), DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID);
        dtVacantPost = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtVacantPost.Rows.Count > 0)
        {
            gvVacantPost.DataSource = dtVacantPost;
            gvVacantPost.DataBind();
        }
        else
        {
            dtVacantPost.Rows.Add(dtVacantPost.NewRow());
            //dtVacantPost.Rows[0]["ReadStatus"] = "1";
            gvVacantPost.DataSource = dtVacantPost;
            gvVacantPost.DataBind();
            int TotalColumns = gvVacantPost.Rows[0].Cells.Count;
            gvVacantPost.Rows[0].Cells.Clear();
            gvVacantPost.Rows[0].Cells.Add(new TableCell());
            gvVacantPost.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvVacantPost.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }

    /// <summary>
    /// Databound for Vacant Post
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">Event Args</param>
    protected void gvVacantPost_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblStatus = (Label)e.Row.FindControl("lblStatus");
            var lblINTime = (Label)e.Row.FindControl("lblINTime");
            var lblPostCode = (Label)e.Row.FindControl("lblPostCode");
            var lblPostVacantFor = (Label)e.Row.FindControl("lblPostVacantFor");
            var lblDutyCompletedEmployeeNumber = (Label)e.Row.FindControl("lblDutyCompletedEmployeeNumber");
            var lblOutTime = (Label)e.Row.FindControl("lblOutTime");
            var lblLateEmployeeNumber = (Label)e.Row.FindControl("lblLateEmployeeNumber");
            var lblDutyDate = (Label)e.Row.FindControl("lblDutyDate");
            var lblReadStatusVacantPost = (Label)e.Row.FindControl("lblReadStatusVacantPost");
            var lblClientName = (Label)e.Row.FindControl("lblClientName");
            var lblAssignment = (Label)e.Row.FindControl("lblAssignment");

            if (lblINTime != null)
            {
                if (lblStatus.Text != "Filled")
                {
                    lblINTime.Text = "";
                }
            }
            lblClientName.ToolTip = lblClientName.Text;
            lblAssignment.ToolTip = lblAssignment.Text;
            //lblClientName.Text = lblClientName.Text.Trim().Length > 0 ? lblClientName.Text.Substring(0, lblClientName.Text.Length > 12 ? 12 : lblClientName.Text.Length) : string.Empty;
            //lblAssignment.Text = lblAssignment.Text.Trim().Length > 0 ? lblAssignment.Text.Substring(0, lblAssignment.Text.Length > 12 ? 12 : lblAssignment.Text.Length) : string.Empty;
                
            if (lblStatus != null)
            {
                    
                if (lblStatus.Text != "")
                {
                    
                    if (lblReadStatusVacantPost.Text.ToString() == "0")
                    {
                        if (lblStatus.Text == "Filled")
                        {
                            // e.Row.BackColor = System.Drawing.Color.LemonChiffon;
                            lblStatus.ForeColor = System.Drawing.Color.Gray;
                            lblINTime.ForeColor = System.Drawing.Color.Gray;
                            lblPostCode.ForeColor = System.Drawing.Color.Gray;
                            lblPostVacantFor.ForeColor = System.Drawing.Color.Gray;
                            lblDutyCompletedEmployeeNumber.ForeColor = System.Drawing.Color.Gray;
                            lblOutTime.ForeColor = System.Drawing.Color.Gray;
                            lblLateEmployeeNumber.ForeColor = System.Drawing.Color.Gray;
                            lblDutyDate.ForeColor = System.Drawing.Color.Gray;
                            lblClientName.ForeColor = System.Drawing.Color.Gray;
                            lblAssignment.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            e.Row.BackColor = System.Drawing.Color.Tomato;
                            lblStatus.ForeColor = System.Drawing.Color.White;
                            lblINTime.ForeColor = System.Drawing.Color.White;
                            lblPostCode.ForeColor = System.Drawing.Color.White;
                            lblPostVacantFor.ForeColor = System.Drawing.Color.White;
                            lblDutyCompletedEmployeeNumber.ForeColor = System.Drawing.Color.White;
                            lblOutTime.ForeColor = System.Drawing.Color.White;
                            lblLateEmployeeNumber.ForeColor = System.Drawing.Color.White;
                            lblDutyDate.ForeColor = System.Drawing.Color.White;
                            lblClientName.ForeColor = System.Drawing.Color.White;
                            lblAssignment.ForeColor = System.Drawing.Color.White;
                            //lblPostCode.Font = new Font(lblPostCode.Font, FontStyle.Bold);
                        }
                    }
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.Empty;
                    }
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Empty;
                }
            }


            //Hide the Phone number coloumn when Client Is Login 
            if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
            {
                gvVacantPost.Columns[2].Visible = false;
                // gvVacantPost.Columns[6].Visible = false;
            }
            else
            {
                gvVacantPost.Columns[2].Visible = true;
                //gvVacantPost.Columns[6].Visible = true;
            }


        }
    }

    /// <summary>
    /// Fill POP grid
    /// </summary>
    private void FillPopNoResponse()
    {
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        string strClientCode = string.Empty;

        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            strClientCode = BaseUserID;
        }
        else
        {
            strClientCode = "";
        }
        DataTable dtPOPNoResponse = new DataTable();
        ds = objNFC.PopNoResponseGetAll(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID);
        dtPOPNoResponse = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtPOPNoResponse.Rows.Count > 0)
        {
            gvPOPResponse.DataSource = dtPOPNoResponse;
            gvPOPResponse.DataBind();
        }
        else
        {
            dtPOPNoResponse.Rows.Add(dtPOPNoResponse.NewRow());
            //dtPOPNoResponse.Rows[0]["ReadStatus"] = "1";
            gvPOPResponse.DataSource = dtPOPNoResponse;
            gvPOPResponse.DataBind();
            int TotalColumns = gvPOPResponse.Rows[0].Cells.Count;
            gvPOPResponse.Rows[0].Cells.Clear();
            gvPOPResponse.Rows[0].Cells.Add(new TableCell());
            gvPOPResponse.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvPOPResponse.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }

    /// <summary>
    /// Databound for POP
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">Event Args</param>
    protected void gvPOPResponse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var Post = (Label)e.Row.FindControl("Post");
            var lblEmployeeNumber = (Label)e.Row.FindControl("lblEmployeeNumber");
            var lblScheduledSwipe = (Label)e.Row.FindControl("lblScheduledSwipe");
            var lblLastSwipe = (Label)e.Row.FindControl("lblLastSwipe");
            var lblTimeSinceLastSwipe = (Label)e.Row.FindControl("lblTimeSinceLastSwipe");
            var lblClientName = (Label)e.Row.FindControl("lblClientName");
            var lblAssignment = (Label)e.Row.FindControl("lblAssignment");

            if (Post != null)
            {
                lblClientName.ToolTip = lblClientName.Text;
                lblAssignment.ToolTip = lblAssignment.Text;
                lblClientName.Text = lblClientName.Text.Trim().Length > 0 ? lblClientName.Text.Substring(0, lblClientName.Text.Length > 12 ? 12 : lblClientName.Text.Length) : string.Empty;
                lblAssignment.Text = lblAssignment.Text.Trim().Length > 0 ? lblAssignment.Text.Substring(0, lblAssignment.Text.Length > 12 ? 12 : lblAssignment.Text.Length) : string.Empty;
                    
                // e.Row.BackColor = System.Drawing.Color.Tomato;
                Post.ForeColor = System.Drawing.Color.Red;
                //lblEmployeeNumber.ForeColor = System.Drawing.Color.Red;
                lblScheduledSwipe.ForeColor = System.Drawing.Color.Red;
                lblLastSwipe.ForeColor = System.Drawing.Color.Red;
                lblTimeSinceLastSwipe.ForeColor = System.Drawing.Color.Red;
                lblClientName.ForeColor = System.Drawing.Color.Red;
                lblAssignment.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    /// <summary>
    /// Fill GuardTour Grid
    /// </summary>
    private void FillGuardTour()
    {
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        string strClientCode = string.Empty;

        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            strClientCode = BaseUserID;
        }
        else
        {
            strClientCode = "";
        }
        DataTable dtGuardTour = new DataTable();
        ds = objNFC.GuardTourGetAll(BaseCompanyCode, BaseLocationAutoID, strClientCode, DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"), DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"), DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID);
        dtGuardTour = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtGuardTour.Rows.Count > 0)
        {
            gvGuardTour.DataSource = dtGuardTour;
            gvGuardTour.DataBind();
        }
        else
        {
            dtGuardTour.Rows.Add(dtGuardTour.NewRow());
            //dtGuardTour.Rows[0]["ReadStatus"] = "1";
            gvGuardTour.DataSource = dtGuardTour;
            gvGuardTour.DataBind();
            int TotalColumns = gvGuardTour.Rows[0].Cells.Count;
            gvGuardTour.Rows[0].Cells.Clear();
            gvGuardTour.Rows[0].Cells.Add(new TableCell());
            gvGuardTour.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvGuardTour.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
        UPGuardTour.Update();

    }

    /// <summary>
    /// Databound for Guard Tour
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">Event Args</param>
    protected void gvGuardTour_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblEmployeeNumber = (Label)e.Row.FindControl("lblEmployeeNumber");
            var lblPostCode = (Label)e.Row.FindControl("lblPostCode");
            var lblMissingTagID = (Label)e.Row.FindControl("lblMissingTagID");
            var lblSwipeTime = (Label)e.Row.FindControl("lblSwipeTime");
            var lblActualSwipeTime = (Label)e.Row.FindControl("lblActualSwipeTime");
            var lblDutyDate = (Label)e.Row.FindControl("lblDutyDate");
            var lblPhone = (Label)e.Row.FindControl("lblPhone");
            var lblClientName = (Label)e.Row.FindControl("lblClientName");
            var lblAssignment = (Label)e.Row.FindControl("lblAssignment");




            if (lblEmployeeNumber != null)
            {
                //if (lblReadStatusGuardTour.Text.ToString() == "0")
                //{


                lblClientName.ToolTip = lblClientName.Text;
                lblAssignment.ToolTip = lblAssignment.Text;

                lblClientName.Text = lblClientName.Text.Trim().Length > 0 ? lblClientName.Text.Substring(0, lblClientName.Text.Length > 12 ? 12 : lblClientName.Text.Length) : string.Empty;
                lblAssignment.Text = lblAssignment.Text.Trim().Length > 0 ? lblAssignment.Text.Substring(0, lblAssignment.Text.Length > 12 ? 12 : lblAssignment.Text.Length) : string.Empty;
                    

                if (lblEmployeeNumber.Text == "")
                {
                    // e.Row.BackColor = System.Drawing.Color.Tomato;
                    lblPostCode.ForeColor = System.Drawing.Color.Red;
                    lblMissingTagID.ForeColor = System.Drawing.Color.Red;
                    lblSwipeTime.ForeColor = System.Drawing.Color.Red;
                    lblDutyDate.ForeColor = System.Drawing.Color.Red;
                    lblPhone.ForeColor = System.Drawing.Color.Red;
                    lblActualSwipeTime.ForeColor = System.Drawing.Color.Red;
                    lblEmployeeNumber.ForeColor = System.Drawing.Color.Red;
                    lblClientName.ForeColor = System.Drawing.Color.Red;
                    lblAssignment.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    // e.Row.BackColor = System.Drawing.Color.LemonChiffon;
                    lblPostCode.ForeColor = System.Drawing.Color.Gray;
                    lblMissingTagID.ForeColor = System.Drawing.Color.Gray;
                    lblSwipeTime.ForeColor = System.Drawing.Color.Gray;
                    lblDutyDate.ForeColor = System.Drawing.Color.Gray;
                    lblPhone.ForeColor = System.Drawing.Color.Gray;
                    lblActualSwipeTime.ForeColor = System.Drawing.Color.Gray;
                    lblEmployeeNumber.ForeColor = System.Drawing.Color.Gray;
                    lblClientName.ForeColor = System.Drawing.Color.Gray;
                    lblAssignment.ForeColor = System.Drawing.Color.Gray;
                }
                if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
                {
                    gvGuardTour.Columns[8].Visible = false;
                    //gvGuardTour.Columns[6].Visible = false;
                }
                else
                {
                    gvGuardTour.Columns[8].Visible = true;
                    // gvGuardTour.Columns[6].Visible = true;
                }


                //}
                //else
                //{
                //    e.Row.BackColor = System.Drawing.Color.Empty;
                //}
                //lblEmployeeNumber.Font.Bold;
            }
        }
    }

    //protected void IMGReadStatusGuardTour_Click(object sender, EventArgs e)
    //{
    //var ds = new DataSet();
    //var objNFC = new BL.NFC();
    //var objImageButton = (ImageButton)sender;
    //var row = (GridViewRow)objImageButton.NamingContainer;
    //var lblEmployeeNumber = (Label)gvGuardTour.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
    //var lblPostCode = (Label)gvGuardTour.Rows[row.RowIndex].FindControl("lblPostCode");
    ////var lblSwipeTime = (Label)gvGuardTour.Rows[row.RowIndex].FindControl("lblSwipeTime");
    //HiddenField HFSwipeTime = (HiddenField)gvGuardTour.Rows[row.RowIndex].FindControl("HFSwipeTime");
    //var lblDutyDate = (Label)gvGuardTour.Rows[row.RowIndex].FindControl("lblDutyDate");
    ////var lblReadStatusNoShow = (Label)gvGuardTour.Rows[row.RowIndex].FindControl("lblReadStatusNoShow");
    //var lblReadStatusGuardTour = (Label)gvGuardTour.Rows[row.RowIndex].FindControl("lblReadStatusGuardTour");
    //if (lblReadStatusGuardTour.Text.ToString() == "0")
    //{

    //    ds = objNFC.blNfc_GuardTour_UpdateReadStatus(lblEmployeeNumber.Text, lblPostCode.Text, HFSwipeTime.Value, lblDutyDate.Text, BaseUserID, BaseCompanyCode, BaseLocationAutoID);
    //    FillGuardTour();
    //}
    //}

    /// <summary>
    /// IMGReadStatusVacantPost CLick
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void IMGReadStatusVacantPost_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        var objImageButton = (ImageButton)sender;
        var row = (GridViewRow)objImageButton.NamingContainer;
        var lblDutyCompletedEmployeeNumber = (Label)gvVacantPost.Rows[row.RowIndex].FindControl("lblDutyCompletedEmployeeNumber");
        var lblPostCode = (Label)gvVacantPost.Rows[row.RowIndex].FindControl("lblPostCode");
        var lblLateEmployeeNumber = (Label)gvVacantPost.Rows[row.RowIndex].FindControl("lblLateEmployeeNumber");
        var lblDutyDate = (Label)gvVacantPost.Rows[row.RowIndex].FindControl("lblDutyDate");
        var lblReadStatusVacantPost = (Label)gvVacantPost.Rows[row.RowIndex].FindControl("lblReadStatusVacantPost");
        if (lblReadStatusVacantPost.Text.ToString() == "0")
        {
            ds = objNFC.VacantPostReadStatusUpdate(lblDutyCompletedEmployeeNumber.Text, lblPostCode.Text, lblLateEmployeeNumber.Text, lblDutyDate.Text, BaseUserID, BaseCompanyCode, BaseLocationAutoID);
            FillVacantPost();
        }
    }

    /// <summary>
    /// IMGReadStatusNoShow CLick
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void IMGReadStatusNoShow_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        var objImageButton = (ImageButton)sender;
        var row = (GridViewRow)objImageButton.NamingContainer;
        var lblEmployeeNumber = (Label)gvNoShow.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        var lblPostCode = (Label)gvNoShow.Rows[row.RowIndex].FindControl("lblPostCode");
        var lblScheduledTimeFrom = (Label)gvNoShow.Rows[row.RowIndex].FindControl("lblScheduledTimeFrom");
        var lblReadStatusNoShow = (Label)gvNoShow.Rows[row.RowIndex].FindControl("lblReadStatusNoShow");
        if (lblReadStatusNoShow.Text.ToString() == "0")
        {
            ds = objNFC.NoShowReadStatusUpdate(lblEmployeeNumber.Text, lblPostCode.Text, lblScheduledTimeFrom.Text, DateTime.Now.ToString("dd-MMM-yyyy"), BaseUserID, BaseCompanyCode, BaseLocationAutoID);

            FillNoShow();
        }
    }

    /// <summary>
    /// IMGReadStatus Incident CLick
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void IMGReadStatusIncident_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        ImageButton objImageButton = (ImageButton)sender;
        var row = (GridViewRow)objImageButton.NamingContainer;
        HiddenField lblIncidentID = (HiddenField)gvIncident.Rows[row.RowIndex].FindControl("lblIncidentID");
        var lblStatusIncident = (Label)gvIncident.Rows[row.RowIndex].FindControl("lblStatusIncident");
        if (lblStatusIncident.Text.ToString() == "0")
        {
            ds = objNFC.IncidentReadStatusUpdate(lblIncidentID.Value, BaseUserID);
            FillIncident();
        }
    }


    /// <summary>
    /// Stop Button
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void btnStopRefresh_Click(object sender, EventArgs e)
    {
        //btnStopRefresh.Text=""
        ViewState["StopRefreshstatus"] = 0;
        btnStartRefresh.Visible = true;
        btnStopRefresh.Visible = false;

    }


    /// <summary>
    /// Pop Up CLick
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void btnPopOut_Click(object sender, EventArgs e)
    {
        //btnStartRefresh_Click(sender, e);
        //btnPopOut.Attributes["onMouseDown"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ControlPanel.aspx';";
        //this.Form.Attributes["onMouseOver"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";
        //this.btnPopOut.Attributes.Add("onclick", "this.form.target='_blank'");

        //ViewState["StopRefreshstatus"] = 1;
        if (gvIncident.Rows.Count <= 1)
        {
            FillIncident();
        }
        //UPIncident.Update();
        if (gvPanicAlert.Rows.Count <= 1)
        {
            FillPanicAlerts();
        }
        //UPPanicAlert.Update();
        if (gvNoShow.Rows.Count <= 1)
        {
            FillNoShow();
        }
        //UPNoShow.Update();
        if (gvVacantPost.Rows.Count <= 1)
        {
            FillVacantPost();
        }
        //UPVacantPost.Update();
        if (gvPOPResponse.Rows.Count <= 1)
        {
            FillPopNoResponse();
        }
        //UPPOPResponse.Update();
        if (gvGuardTour.Rows.Count <= 1)
        {
            FillGuardTour();
        }
        //btnStartRefresh.Visible = false;
        //btnStopRefresh.Visible = true;
    }

    /// <summary>
    /// Start Refresh 
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void btnStartRefresh_Click(object sender, EventArgs e)
    {
        ViewState["StopRefreshstatus"] = 1;
        FillIncident();
        UPIncident.Update();
        FillPanicAlerts();
        UPPanicAlert.Update();
        FillNoShow();
        UPNoShow.Update();
        FillVacantPost();
        UPVacantPost.Update();
        FillPopNoResponse();
        UPPOPResponse.Update();
        FillGuardTour();
        btnStartRefresh.Visible = false;
        btnStopRefresh.Visible = true;
    }


    /// <summary>
    /// IMGReadStatus Panic CLick
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void IMGReadStatusPanic_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objNFC = new BL.NFC();
        var objImageButton = (ImageButton)sender;
        var row = (GridViewRow)objImageButton.NamingContainer;
        var lblPanicAlertId = (Label)gvPanicAlert.Rows[row.RowIndex].FindControl("lblPanicAlertId");
        var lblStatusPanic = (Label)gvPanicAlert.Rows[row.RowIndex].FindControl("lblStatusPanic");
        if (lblStatusPanic.Text.ToString() == "0")
        {
            ds = objNFC.PanicReadStatusUpdate(lblPanicAlertId.Text, BaseUserID);
            FillPanicAlerts();
        }
    }


    /// <summary>
    /// Guard Tour Time Tick
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void TimerGvGuardTour_Tick(object sender, EventArgs e)
    {
        if (ViewState["StopRefreshstatus"].ToString() == "1")
        {
            // lblRefreshTime.Text = DateTime.Now.ToString("ss");
            FillIncident();
            UPIncident.Update();
            FillPanicAlerts();
            UPPanicAlert.Update();
            FillNoShow();
            UPNoShow.Update();
            FillVacantPost();
            UPVacantPost.Update();
            FillPopNoResponse();
            UPPOPResponse.Update();
            FillGuardTour();
        }
    }
    //protected void TimerVacantPost_Tick(object sender, EventArgs e)
    //{
    //    FillVacantPost();
    //}
    //protected void TimerNoShow_Tick(object sender, EventArgs e)
    //{
    //    FillNoShow();
    //}

    //protected void TimerPanicAlert_Tick(object sender, EventArgs e)
    //{
    //    FillPanicAlerts();
    //}
    //protected void TimerIncident_Tick(object sender, EventArgs e)
    //{
    //    FillIncident();
    //}


    /// <summary>
    /// Refresh Button CLick
    /// </summary>
    /// <param name="sender">Object Sender</param>
    /// <param name="e">Event Args</param>
    protected void imgrefresh_Click(object sender, ImageClickEventArgs e)
    {
        FillIncident();
        UPIncident.Update();
        FillPanicAlerts();
        UPPanicAlert.Update();
        FillNoShow();
        UPNoShow.Update();
        FillVacantPost();
        UPVacantPost.Update();
        FillPopNoResponse();
        UPPOPResponse.Update();
        FillGuardTour();
    }
}
