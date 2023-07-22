// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="OTReaasonTransaction.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Class Transactions_OTReaasonTransaction.
/// </summary>
public partial class Transactions_OTReaasonTransaction : BasePage
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
            if (Request.QueryString["ScheduleRosterAutoID"] != null)
            {
                GetEmployeeDetailBasedOnRosterAutoID(Request.QueryString["ScheduleRosterAutoID"].ToString());
                FillgvDetails();
            }
        }
    }
    /// <summary>
    /// Gets the employee detail based on roster automatic identifier.
    /// </summary>
    /// <param name="strRosterAutoID">The string roster automatic identifier.</param>
    private void GetEmployeeDetailBasedOnRosterAutoID(string strRosterAutoID)
    {
        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        ds = objRoster.TranRosterEmployeeWiseGetAllBasedOnRosterAutoId(strRosterAutoID, BaseLocationAutoID);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            txtEmployeeNumber.Text = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
            txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
            txtDutyDate.Text = ds.Tables[0].Rows[0]["DutyDate"].ToString();
            txtShift.Text = ds.Tables[0].Rows[0]["ShiftCode"].ToString();
            txtTimeFrom.Text = ds.Tables[0].Rows[0]["TimeFrom"].ToString();
            txtTimeTo.Text = ds.Tables[0].Rows[0]["TimeTo"].ToString();
        }

    }
    /// <summary>
    /// Fillgvs the details.
    /// </summary>
    private void FillgvDetails()
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objRoster.OtReasonTransactionGet(Request.QueryString["ScheduleRosterAutoID"].ToString(), BaseLocationAutoID);
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
            gvOTReasonTran.DataSource = dt;
            gvOTReasonTran.DataBind();
            gvOTReasonTran.Rows[0].Visible = false;
        }
        else
        {
            gvOTReasonTran.DataKeyNames = new string[] { "RosterAutoId" };
            gvOTReasonTran.DataSource = dt;
            gvOTReasonTran.DataBind();
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvOTReasonTran control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonTran_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("AddNew"))
        {
            DropDownList ddlOTReasonDesc = (DropDownList)gvOTReasonTran.FooterRow.FindControl("ddlOTReasonDesc");
            TextBox txtFooterTimeFrom = (TextBox)gvOTReasonTran.FooterRow.FindControl("txtFooterTimeFrom");
            TextBox txtFooterTimeTo = (TextBox)gvOTReasonTran.FooterRow.FindControl("txtFooterTimeTo");

            HiddenField hfOTReasonTranAutoID = (HiddenField)gvOTReasonTran.FooterRow.FindControl("hfOTReasonTranAutoID");

            if (ddlOTReasonDesc.SelectedValue == "")
            {
                return;
            }

            TimeSpan ts;
            DateTime FrTime;
            DateTime ToTime;
           
            String DutyMin = "0";
            DataSet ds = new DataSet();
            BL.Roster objRoster = new BL.Roster();
            if (txtFooterTimeFrom.Text != null && txtFooterTimeFrom.Text != "")
            {
                FrTime = DateTime.Parse("1901-01-01 " + txtFooterTimeFrom.Text + ":00");
                ToTime = DateTime.Parse("1901-01-01 " + txtFooterTimeTo.Text + ":00");
                if (FrTime > ToTime)
                {
                    ToTime = DateTime.Parse("1901-01-02 " + txtFooterTimeTo.Text + ":00");
                }

                ts = ToTime.Subtract(FrTime);
                DutyMin = ((ts.Hours * 60) + ((ts.Minutes))).ToString();


                if (this.CheckTimeValidity(txtFooterTimeFrom, txtFooterTimeTo))
                {
                    ds = objRoster.OtReasonTranInsert(BaseLocationAutoID, ddlOTReasonDesc.SelectedValue, Request.QueryString["ScheduleRosterAutoID"].ToString(), txtEmployeeNumber.Text, HFOTFromTime.Value, HFOTToTime.Value, txtDutyDate.Text, DutyMin, BaseUserID);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        this.FillgvDetails();
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Invalid Time";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvOTReasonTran control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonTran_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();

        DropDownList ddlOTReasonDesc = (DropDownList)gvOTReasonTran.Rows[e.RowIndex].FindControl("ddlOTReasonDesc");
        TextBox txtTimeFromG = (TextBox)gvOTReasonTran.Rows[e.RowIndex].FindControl("txtTimeFrom");
        TextBox txtTimeToG = (TextBox)gvOTReasonTran.Rows[e.RowIndex].FindControl("txtTimeTo");
        HiddenField hfOTReasonTranAutoID = (HiddenField)gvOTReasonTran.Rows[e.RowIndex].FindControl("hfOTReasonTranAutoID");

        TimeSpan ts;
        DateTime FrTime;
        DateTime ToTime;
        String DutyMin = "0";

       // DateTime HFrTime;
      //  DateTime HToTime;

        if (txtTimeFromG.Text != null && txtTimeFromG.Text != "")
        {
            FrTime = DateTime.Parse("1901-01-01 " + txtTimeFromG.Text + ":00");
            ToTime = DateTime.Parse("1901-01-01 " + txtTimeToG.Text + ":00");
            if (FrTime > ToTime)
            {
                ToTime = DateTime.Parse("1901-01-02 " + txtTimeToG.Text + ":00");
            }

            ts = ToTime.Subtract(FrTime);
            DutyMin = ((ts.Hours * 60) + ((ts.Minutes))).ToString();

            if (this.CheckTimeValidity(txtTimeFromG, txtTimeToG))
            {
                ds = objRoster.OtReasonTranUpdate(BaseLocationAutoID, hfOTReasonTranAutoID.Value, HFOTFromTime.Value, HFOTToTime.Value, DutyMin);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    gvOTReasonTran.EditIndex = -1;
                    this.FillgvDetails();
                }
            }
            else
            {

                lblErrorMsg.Text = "Invalid Time";
            }

        }
        

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvOTReasonTran control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonTran_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOTReasonTran.EditIndex = -1;
        FillgvDetails();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvOTReasonTran control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonTran_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOTReasonTran.PageIndex = e.NewPageIndex;
        FillgvDetails();
    }
    /// <summary>
    /// Handles the RowEditing event of the gvOTReasonTran control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonTran_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOTReasonTran.EditIndex = e.NewEditIndex;
        FillgvDetails();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvOTReasonTran control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonTran_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        HiddenField hfOTReasonTranAutoID = (HiddenField)gvOTReasonTran.Rows[e.RowIndex].FindControl("hfOTReasonTranAutoID");
        ds = objRoster.OtReasonTranDelete(hfOTReasonTranAutoID.Value, BaseLocationAutoID);
        FillgvDetails();
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvOTReasonTran control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvOTReasonTran_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlOTReasonDesc = (DropDownList)e.Row.FindControl("ddlOTReasonDesc");
            HiddenField hfResonAutoID = (HiddenField)e.Row.FindControl("hfResonAutoID");

            if (ddlOTReasonDesc != null)
            {
                FillOTReason(ddlOTReasonDesc, BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtCode"].ToString(), Request.QueryString["strPost"].ToString());
                ddlOTReasonDesc.SelectedValue = hfResonAutoID.Value;
            }
            ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
            if (ImgbtnUpdate != null)
            {

            }

            ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
            if (IBDelete != null)
            {

            }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList ddlOTReasonDesc = (DropDownList)e.Row.FindControl("ddlOTReasonDesc");
            TextBox txtFooterTimeFrom = (TextBox)e.Row.FindControl("txtFooterTimeFrom");
            TextBox txtFooterTimeTo = (TextBox)e.Row.FindControl("txtFooterTimeTo");

            // Added by Kamal on 07 May 2012
            txtFooterTimeFrom.Text = txtTimeFrom.Text;
            txtFooterTimeTo.Text = txtTimeTo.Text;

            if (ddlOTReasonDesc != null)
            {
                FillOTReason(ddlOTReasonDesc, BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtCode"].ToString(), Request.QueryString["strPost"].ToString());
            }
        }

    }
    
    //private bool CheckTimeValidity(TextBox txtFromTime, TextBox txtToTime)
    //{
    //    string strDutyFromTime = "1901-01-02 " + txtTimeFrom.Text;
    //    string strDutyToTime = "1901-01-02 " + txtTimeTo.Text;

    //    string strTimeFrom = "1901-01-02 " + txtFromTime.Text;
    //    string strTimeTo = "1901-01-02 " + txtToTime.Text;
    //    if (Convert.ToDateTime(DateTime.Parse(strDutyFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")))
    //    {
    //        if (Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")) >= Convert.ToDateTime("00:00"))
    //        {
    //            strDutyToTime = DateTime.Parse(txtDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + txtTimeTo.Text;
    //        }
    //    }

    //    if (Convert.ToDateTime(DateTime.Parse(strTimeFrom).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strTimeTo).ToString("HH:mm")))
    //    {
    //        if (Convert.ToDateTime(DateTime.Parse(strTimeTo).ToString("HH:mm")) >= Convert.ToDateTime("00:00"))
    //        {
    //            strTimeTo = DateTime.Parse(txtDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + txtToTime.Text;

    //        }
    //    }
    //    if (DateTime.Parse(strTimeFrom) >= DateTime.Parse(strDutyFromTime) && DateTime.Parse(strTimeFrom) <= DateTime.Parse(strDutyToTime) && DateTime.Parse(strTimeTo) <= DateTime.Parse(strDutyToTime) && DateTime.Parse(strTimeTo) >= DateTime.Parse(strDutyFromTime))
    //    {

    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}


    /// <summary>
    /// Checks the time validity.
    /// </summary>
    /// <param name="txtFromTime">The text from time.</param>
    /// <param name="txtToTime">The text to time.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckTimeValidity(TextBox txtFromTime, TextBox txtToTime)
    {
        string strDutyFromTime = txtDutyDate.Text + " " + txtTimeFrom.Text;
        string strDutyToTime = txtDutyDate.Text + " " + txtTimeTo.Text;

        string strRoleTimeFrom = txtDutyDate.Text + " " + txtFromTime.Text;
        string strRoleTimeTo = txtDutyDate.Text + " " + txtToTime.Text;

        if (Convert.ToDateTime(DateTime.Parse(strDutyFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")))
        {
            if (Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")) >= Convert.ToDateTime("00:00"))
            {
                strDutyToTime = DateTime.Parse(txtDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + txtTimeTo.Text;
            }
        }

        if (Convert.ToDateTime(DateTime.Parse(strDutyFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strRoleTimeFrom).ToString("HH:mm")))
        {
            strRoleTimeFrom = DateTime.Parse(txtDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtFromTime.Text).ToString("HH:mm");
        }

        HFOTFromTime.Value = strRoleTimeFrom;

        if (Convert.ToDateTime(DateTime.Parse(strRoleTimeFrom).ToString("dd-MMMM-yyyy")) > Convert.ToDateTime(DateTime.Parse(strRoleTimeTo).ToString("dd-MMMM-yyyy")))
        {
            strRoleTimeTo = DateTime.Parse(txtDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtToTime.Text).ToString("HH:mm");
        }
        else if (Convert.ToDateTime(DateTime.Parse(strRoleTimeFrom).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strRoleTimeTo).ToString("HH:mm")))
        {
            if (Convert.ToDateTime(DateTime.Parse(strRoleTimeTo).ToString("HH:mm")) >= Convert.ToDateTime("00:00"))
            {
                strRoleTimeTo = DateTime.Parse(txtDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + txtToTime.Text;

            }
        }
        HFOTToTime.Value = strRoleTimeTo;
        if (DateTime.Parse(strRoleTimeFrom) >= DateTime.Parse(strDutyFromTime)
                && DateTime.Parse(strRoleTimeFrom) <= DateTime.Parse(strDutyToTime)
                && DateTime.Parse(strRoleTimeTo) <= DateTime.Parse(strDutyToTime)
                && DateTime.Parse(strRoleTimeTo) >= DateTime.Parse(strDutyFromTime)
                && DateTime.Parse(strRoleTimeFrom) < DateTime.Parse(strRoleTimeTo)
            )
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Fills the ot reason.
    /// </summary>
    /// <param name="ddlOTReasonDesc">The DDL ot reason desc.</param>
    /// <param name="locationAutoID">The location automatic identifier.</param>
    /// <param name="clientCode">The client code.</param>
    /// <param name="asmtCode">The asmt code.</param>
    /// <param name="strPost">The string post.</param>
    protected void FillOTReason(DropDownList ddlOTReasonDesc, String locationAutoID, String clientCode, String asmtCode, String strPost)
    {
        DataSet dsAllowance = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        String RosterAutoID=Request.QueryString["ScheduleRosterAutoID"].ToString();
        dsAllowance = objRoster.OtReasonForComboGet(locationAutoID, RosterAutoID, clientCode, asmtCode, strPost);
        if (dsAllowance != null && dsAllowance.Tables.Count > 0 && dsAllowance.Tables[0].Rows.Count > 0)
        {
            ddlOTReasonDesc.DataSource = dsAllowance.Tables[0];
            ddlOTReasonDesc.DataTextField = "ReasonDesc";
            ddlOTReasonDesc.DataValueField = "ResonAutoID";
            ddlOTReasonDesc.DataBind();
        }
    }
}
