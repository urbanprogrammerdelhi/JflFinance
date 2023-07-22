// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="AssignmentController.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class MonitorScreen_AssignmentController
/// </summary>
public partial class MonitorScreen_AssignmentController : BasePage
{
    // public static string urlClCode;
    // public static DateTime dutydate;
    //public static DateTime tfrm;
    //public static DateTime tto;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            // pnlImg.Visible = false;
            pnlEmpGrd.Visible = false;
            //urlClCode = Request.QueryString["CId"];
            //string date1 = Request.QueryString["date"];
            //string timefrom = Request.QueryString["tf"];
            //string timeto = Request.QueryString["tt"];
            //string WETDate = Request.QueryString["WETDate"];
            //tfrm = DateTime.Parse(timefrom.ToString());
            //tto = DateTime.Parse(timeto.ToString());
            //dutydate = DateTime.Parse(date1.ToString());

            if (ViewState["dt"] != null)
            {
                ViewState["dt"] = null;
            }
            FillgvAssignment();
        }
    }


    /// <summary>
    /// Handles the Click event of the ImgbtnHyperLink control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnHyperLink_Click(object sender, ImageClickEventArgs e)
    {
        pnlAsmtGrid.Visible = false;
        pnlEmpGrd.Visible = true;
        // pnlImg.Visible = true;
        ImageButton Imgbtn = (ImageButton)sender;
        GridViewRow gvRow = (GridViewRow)Imgbtn.NamingContainer;
        Label lblgvClientCode = (Label)gvDetail.Rows[gvRow.RowIndex].FindControl("lblgvClientCode");        //Added by  on 23-Apr-2014
        Label lblgvAsmtCode = (Label)gvDetail.Rows[gvRow.RowIndex].FindControl("lblgvAsmtCode");
        Label lblgvPostCode = (Label)gvDetail.Rows[gvRow.RowIndex].FindControl("lblgvPostCode");
        HFPostCode.Value = lblgvPostCode.Text;
        HFAsmtCode.Value = lblgvAsmtCode.Text;
        HFClientCode.Value = lblgvClientCode.Text;   //Added by  on 23-Apr-2014
        //Response.Redirect("EmployeeController.aspx?CId=" + lblgvAsmtCode.Text + "&date=" + dutydate + "&tf=" + tfrm + "&tt=" + tto);
        gvEmp.PageIndex = 0;

        FillgvEmployee(lblgvClientCode.Text);
        ImgbtnPnl.Visible = true;
        
    }
    /// <summary>
    /// Handles the Click event of the lbADD control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void lbADD_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton Imgbtn = (ImageButton)sender;
        GridViewRow gvRow = (GridViewRow)Imgbtn.NamingContainer;
        DataSet ds = new DataSet();
        BL.Misc objMisc = new BL.Misc();
        Label lblEmployeeNumber = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblEmployeeNumber");
        Label lblDutyDate = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblDutyDate");

        ds = objMisc.BlAssignmentControllerConfirm(BaseLocationAutoID, lblEmployeeNumber.Text, HFClientCode.Value, HFAsmtCode.Value, lblDutyDate.Text, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
            {
                lblErrorMsg.Text = "Successfully Inserted";
               // FillgvEmployee(HFAsmtCode.Value);
                FillgvEmployee(HFClientCode.Value);
                MPErrorDetail.Hide();
            }
            else
            {
                MPErrorDetail.Show();
                gvErrorDetails.DataSource = ds.Tables[0];
                gvErrorDetails.DataBind();
                lblErrorMsg.Text = "Error Confirming";
            }
        }

    }
    /// <summary>
    /// Handles the OnRowDataBound event of the gvEmp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmp_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField HFConfirmStatus = (HiddenField)e.Row.FindControl("HFConfirmStatus");
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            if (lblStatus != null)
            {
                if (lblStatus.Text == "")
                {
                    lblStatus.Text = "UnScheduled";
                }
                else
                {
                    lblStatus.Text = "Scheduled";
                }
            }
            ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
            if (HFConfirmStatus != null)
            {
                if (HFConfirmStatus.Value == "1")
                {
                    if (lbADD != null)
                    {
                        lbADD.Visible = false;
                        e.Row.BackColor = System.Drawing.Color.LightGreen;
                    }

                }
                else
                {
                    if (lbADD != null)
                    {
                        lbADD.Visible = true;
                        e.Row.BackColor = System.Drawing.Color.Empty;
                    }
                }

            }
        }

    }
    /// <summary>
    /// Handles the Click event of the IBBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void IBBack_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("ClientController.aspx?ClientCode=" + Request.QueryString["CId"] + "&Date=" + Request.QueryString["date"] + "&TimeFrom=" + Request.QueryString["tf"] + "&TimeTo=" + Request.QueryString["tt"] + "&WETDate=" + Request.QueryString["WETDate"]);
    }
    /// <summary>
    /// Handles the onClick event of the btnOk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnOk_onClick(object sender, EventArgs e)
    {

        MPErrorDetail.Hide();
    }
    /// <summary>
    /// Handles the Click event of the btnConfirm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Misc objMisc = new BL.Misc();
        string strEmployeeNumber = "";
        ds = objMisc.BlAssignmentControllerConfirm(BaseLocationAutoID, strEmployeeNumber, HFClientCode.Value, HFAsmtCode.Value, Request.QueryString["date"], BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
            {
                lblErrorMsg.Text = "Successfully Inserted";
                FillgvEmployee(HFAsmtCode.Value);
                MPErrorDetail.Hide();
            }
            else
            {
                MPErrorDetail.Show();
                gvErrorDetails.DataSource = ds.Tables[0];
                gvErrorDetails.DataBind();
                lblErrorMsg.Text = "Error Confirming";
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the ImgbtnPnl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnPnl_Click(object sender, ImageClickEventArgs e)
    {
        pnlAsmtGrid.Visible = true;
        FillgvAssignment();
        pnlEmpGrd.Visible = false;
        ImgbtnPnl.Visible = false;

        if (gvDetail.Rows.Count > 0)
        {
            btnClientDataExport.Style.Value = "display:block";
        }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDetail.PageIndex = e.NewPageIndex;
        FillgvAssignment();

        if (gvDetail.Rows.Count > 0)
        {
            btnClientDataExport.Style.Value = "display:block";
        }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmp.PageIndex = e.NewPageIndex;
        FillgvEmployee(HFClientCode.Value);
    
    }

    # region Grid Filling
    /// <summary>
    /// Assignment Related date of particular client
    /// </summary>
    void FillgvAssignment()
    {
        //dutydate = DateTime.Parse("date");
        //tfrm = DateTime.Parse("timefrom");
        //tto = DateTime.Parse("timeto");

        BL.Misc objMics = new BL.Misc();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        if (ViewState["dt"] == null)
        {
            // ds = objMics.blAssignmentController(urlClCode, dutydate, tfrm, tto, Request.QueryString["WETDate"].ToString());
            //ds = objMics.blAssignmentController(Request.QueryString["CId"].ToString(), DateTime.Parse(Request.QueryString["date"].ToString()), DateTime.Parse(Request.QueryString["tf"].ToString()), DateTime.Parse(Request.QueryString["tt"].ToString()), Request.QueryString["WETDate"].ToString(),BaseLocationAutoID);
            ds = objMics.BlClientController(DateTime.Parse(Request.QueryString["date"].ToString()), DateTime.Parse(Request.QueryString["tf"].ToString()), DateTime.Parse(Request.QueryString["tt"].ToString()), Request.QueryString["CId"].ToString(), Request.QueryString["WETDate"].ToString(), BaseLocationAutoID, "POST", null, null);
            dt = ds.Tables[0];
            ViewState["dt"] = dt;
        }

        if (dt.Rows.Count > 0)
        {
            btnClientDataExport.Style.Value = "display:block";
        }
        else
        {
            btnClientDataExport.Style.Value = "display:none";
        }

        //gvDetail.DataSource = dt;
        gvDetail.DataSource = (DataTable)ViewState["dt"];
        gvDetail.DataBind();
    }
    /// <summary>
    /// Empployee related data  for particular Assignment.
    /// </summary>
    /// <param name="AsmtCode">The asmt code.</param>
    private void FillgvEmployee(string clientCode)
    {
        BL.Misc objMics = new BL.Misc();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ////ds = objMics.blEmpAssignmentWise(AsmtCode, DateTime.Parse(Request.QueryString["date"].ToString()), DateTime.Parse(Request.QueryString["tf"].ToString()), DateTime.Parse(Request.QueryString["tt"].ToString()), Request.QueryString["WETDate"].ToString(),BaseLocationAutoID);
        ds = objMics.BlClientController(DateTime.Parse(Request.QueryString["date"].ToString()), DateTime.Parse(Request.QueryString["tf"].ToString()), DateTime.Parse(Request.QueryString["tt"].ToString()), clientCode, Request.QueryString["WETDate"].ToString(), BaseLocationAutoID, HFPostCode.Value.ToString(), null, null);

        dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            btnAsmtDateExport.Style.Value = "display:block";
        }
        else
        {
            btnAsmtDateExport.Style.Value = "display:none";
        }

        gvEmp.DataSource = dt;
        gvEmp.DataBind();

    }
    #endregion

    /// <summary>
    /// Handles the Click event of the btnClientDataExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClientDataExport_Click(object sender, EventArgs e)
    {
        //int selPosts = 0;
        //if (chkScans.Checked == true)
        //{

        //    for (int i = 0; i < gvDetail.Rows.Count; i++)
        //    {
        //        CheckBox chkSelect = (CheckBox)gvDetail.Rows[i].FindControl("chkSelect");
        //        if (chkSelect.Checked == true)
        //        {
        //            selPosts = selPosts + 1;
        //        }
        //    }
        //}

        string strClientcode = Request.QueryString["CId"].ToString();
        string strDutyDate = DateTime.Parse(Request.QueryString["date"].ToString()).ToString("dd--yyy hh:mm tt");
        string strTimeFrom = DateTime.Parse(Request.QueryString["tf"].ToString()).ToString("dd--yyy hh:mm tt");
        string strTimeTo = DateTime.Parse(Request.QueryString["tt"].ToString()).ToString("dd--yyy hh:mm tt");

        string Scan = "";

        if (chkScans.Checked == true)
        {
            Scan = "Y";
        }
        else
        {
            Scan = "N";
        }

        //string url = "Export.aspx?type=ATTENDANCE&EType=POST&asmt=" + strClientcode + "&dt=" + strDutyDate + "&tf=" + strTimeFrom + "&tt=" + strTimeTo + "&wet=" + Request.QueryString["WETDate"].ToString();

        string url = "Export.aspx?type=ATTENDANCE&EType=POST&asmt=" + strClientcode + "&dt=" + strDutyDate + "&tf=" + strTimeFrom + "&tt=" + strTimeTo + "&PostString=" + lblScans1.Text + "&Scan=" + Scan + "&wet=" + Request.QueryString["WETDate"].ToString();

        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
        ////ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "Popup('" + url + "');", true);
        lblScans1.Text = "";
        chkScans.Checked = false;

        if (ViewState["dt"] != null)
        {
            ViewState["dt"] = null;
        }
        FillgvAssignment();
    }

    /// <summary>
    /// Handles the Click event of the btnAsmtDateExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAsmtDateExport_Click(object sender, EventArgs e)
    {
        string strDutyDate = DateTime.Parse(Request.QueryString["date"].ToString()).ToString("dd--yyy hh:mm tt");
        string strTimeFrom = DateTime.Parse(Request.QueryString["tf"].ToString()).ToString("dd--yyy hh:mm tt");
        string strTimeTo = DateTime.Parse(Request.QueryString["tt"].ToString()).ToString("dd--yyy hh:mm tt");
        string url = "Export.aspx?type=ATTENDANCE&EType=" + HttpUtility.UrlEncode(HFPostCode.Value) + "&asmt=" + HFClientCode.Value + "&dt=" + strDutyDate + "&tf=" + strTimeFrom + "&tt=" + strTimeTo + "&wet=" + Request.QueryString["WETDate"].ToString();

        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
        ////ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "Popup('" + url + "');", true);
    }





    //# region Initialized Global Variable
    //void dateTimeParse(string date, string timefrom, string timeto)
    //{
    //    dutydate = DateTime.Parse(date);
    //    tfrm = DateTime.Parse(timefrom);
    //    tto = DateTime.Parse(timeto);
    //# endregion


    //}


    /// <summary>
    /// Handles the CheckedChanged event of the chkSelectAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = (CheckBox)sender;

        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["dt"];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (chkSelectAll.Checked == true)
            {
                dt.Rows[i]["fldChk"] = true;
                hid_SelectAll.Value = "1";
            }
            else
            {
                dt.Rows[i]["fldChk"] = false;
                hid_SelectAll.Value = "";
            }
        }
        dt.AcceptChanges();
        ViewState["dt"] = dt;
        if (ViewState["dt"] != null)
        {
            ViewState["dt"] = null;
        }
        FillgvAssignment();



    }

    /// <summary>
    /// Handles the CheckedChanged event of the chkSelect control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.NamingContainer;
        CheckBox chkSelect = (CheckBox)gvDetail.Rows[row.RowIndex].FindControl("chkSelect");

        Label lblScheduleLockUnLockSno = (Label)gvDetail.Rows[row.RowIndex].FindControl("lblScheduleLockUnLockSno");
        Label lblgvPostCode = (Label)gvDetail.Rows[row.RowIndex].FindControl("lblgvPostCode");

        int Ind = int.Parse(lblScheduleLockUnLockSno.Text);

        DataTable dt = new DataTable();

        dt = (DataTable)ViewState["dt"];

        if (chkSelect.Checked == true)
        {
            dt.Rows[Ind - 1]["fldChk"] = true;

            if ((lblScans1.Text != ""))
            {
                lblScans1.Text = lblScans1.Text + ";" + lblgvPostCode.Text.ToString();
            }
            else
            {
                lblScans1.Text = lblgvPostCode.Text.ToString();
            }
        }
        else
        {
            dt.Rows[Ind - 1]["fldChk"] = false;

            lblScans1.Text = lblScans1.Text.Replace(lblgvPostCode.Text.ToString(), "");

        }
        dt.AcceptChanges();

        ViewState["dt"] = dt;

        FillgvAssignment();

        if (gvDetail.Rows.Count > 0)
        {
            btnClientDataExport.Style.Value = "display:block";
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

            Image IMGRed = (Image)e.Row.FindControl("IMGRed");

            Label lblSchedule = (Label)e.Row.FindControl("lblSchedule");
            Label lblUnScheuled = (Label)e.Row.FindControl("lblUnScheuled");
            Label lblCheckedIn = (Label)e.Row.FindControl("lblCheckedIn");
            ///Label lblVariance = (Label)e.Row.FindControl("lblVariance");
            Label lblMatchCount = (Label)e.Row.FindControl("lblMatchCount");
            Label lblIncompDuty = (Label)e.Row.FindControl("lblIncompDuty");


            if (lblSchedule != null)
            {


                if (int.Parse(lblSchedule.Text) == int.Parse(lblCheckedIn.Text) && lblSchedule.Text == lblMatchCount.Text)
                {
                    IMGRed.ImageUrl = "~/Images/Green1.jpg";
                }
                else if (int.Parse(lblSchedule.Text) > int.Parse(lblCheckedIn.Text))
                {
                    IMGRed.ImageUrl = "~/Images/red.jpg";
                }
                else if (int.Parse(lblSchedule.Text) == int.Parse(lblCheckedIn.Text) && int.Parse(lblUnScheuled.Text) > 0 && int.Parse(lblIncompDuty.Text) == 0)
                {
                    IMGRed.ImageUrl = "~/Images/blue.jpg";
                }
                else
                {
                    IMGRed.ImageUrl = "~/Images/Orange.jpg";

                }


                //if (int.Parse(lblSchedule.Text) == int.Parse(lblCheckedIn.Text) )
                //{
                //    IMGRed.ImageUrl = "~/Images/Green1.jpg";
                //}
                //else if (int.Parse(lblVariance.Text) != 0)
                //{
                //    IMGRed.ImageUrl = "~/Images/red.jpg";
                //}
                //else if (int.Parse(lblUnScheduled.Text) > 0)
                //{
                //    IMGRed.ImageUrl = "~/Images/blue.jpg";
                //}
                //else
                //{
                //    IMGRed.ImageUrl = "~/Images/red.jpg";

                //}
            }
        }
    }


}
