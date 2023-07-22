// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="GuardTourCreation.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class MonitorScreen_GuardTourCreation
/// </summary>
public partial class MonitorScreen_GuardTourCreation : BasePage//System.Web.UI.Page
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

    static int Index;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
            FillFromDay();
            FillddlClientCode();
            btnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

        }

    }

    private void FillFromDay()
    {
        ddlFromDay.Items.Clear();
        ListItem li = new ListItem();
        li.Text = "Sunday";
        li.Value = "Sunday";
        ddlFromDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Monday";
        li.Value = "Monday";
        ddlFromDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Tuesday";
        li.Value = "Tuesday";
        ddlFromDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Wednesday";
        li.Value = "Wednesday";
        ddlFromDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Thursday";
        li.Value = "Thursday";
        ddlFromDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Friday";
        li.Value = "Friday";
        ddlFromDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Saturday";
        li.Value = "Saturday";
        ddlFromDay.Items.Add(li);

        FillToDay();

    }
    private void FillToDay()
    {

        ddlToDay.Items.Clear();
        ListItem li = new ListItem();
        li.Text = "Sunday";
        li.Value = "Sunday";
        ddlToDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Monday";
        li.Value = "Monday";
        ddlToDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Tuesday";
        li.Value = "Tuesday";
        ddlToDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Wednesday";
        li.Value = "Wednesday";
        ddlToDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Thursday";
        li.Value = "Thursday";
        ddlToDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Friday";
        li.Value = "Friday";
        ddlToDay.Items.Add(li);

        li = new ListItem();
        li.Text = "Saturday";
        li.Value = "Saturday";
        ddlToDay.Items.Add(li);

        ddlToDay.Items.Remove(ddlFromDay.SelectedValue);

        if (ddlFromDay.SelectedValue == "Sunday")
        {
            ddlToDay.SelectedValue = "Saturday";
        }
    }

    /// <summary>
    /// Function used to fill Clients.
    /// </summary>
    private void FillddlClientCode()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();


        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            //Modify By  on 10-Jun-2014
            //ds = objSales.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
            ds = objSales.BlGuardTourClientsLocationMappedGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            //Modify By  on 21-Apr-2014
            //ds = objSales.ClientsMappedToLocationGet(BaseLocationAutoID);
            ds = objSales.BlGuardTourClientGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientCodeName";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();

            FillddlAsmtCode();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlClientCode.Items.Insert(0, li);
            FillddlAsmtCode();
        }
    }

    private void FillddlAsmtCode()
    {
        // BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        BL.Sales objSales = new BL.Sales();
        DataSet dsAsmt = new DataSet();
        ddlAsmtCode.Items.Clear();
        if (ddlClientCode.SelectedValue.ToString() == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlAsmtCode.Items.Insert(0, li);
            FillddlPost();
        }
        else
        {
            //Modify By  on 21-Apr-2014
            string strDutyDate = DateTime.Now.ToString("dd-MMM-yyyy");
            //dsAsmt = objOperationManagement.blAssignmentsOfClient_Get(int.Parse(BaseLocationAutoID), ddlClientCode.SelectedValue.ToString(), strDutyDate, strDutyDate);
            //dsAsmt = objSales.blAsmtID_BasedOnClient(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), strDutyDate, strDutyDate);
            dsAsmt = objSales.BlAsmtIDBasedOnClient(BaseLocationAutoID, ddlClientCode.SelectedValue, strDutyDate, strDutyDate);
            if (dsAsmt != null && dsAsmt.Tables[0].Rows.Count > 0 && dsAsmt.Tables.Count > 0)
            {
                ddlAsmtCode.DataSource = dsAsmt.Tables[0];
                ddlAsmtCode.DataTextField = "AsmtDetail";
                ddlAsmtCode.DataValueField = "AsmtCode";
                ddlAsmtCode.DataBind();
                FillddlPost();
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoDataToShow;
                li.Value = "";
                ddlAsmtCode.Items.Insert(0, li);
                FillddlPost();
            }
        }
    }
    private void FillddlPost()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlPostCode.Items.Clear();
        if (ddlAsmtCode.SelectedValue.ToString() == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlPostCode.Items.Insert(0, li);
        }
        else
        {
            //Modify By  on 21-Apr-2014
            string strDutyDate = DateTime.Now.ToString("dd-MMM-yyyy");
            //ds = objOperationManagement.blAsmtPostCode_GetAll(ddlAsmtCode.SelectedValue.ToString(), BaseLocationAutoID, strDutyDate, strDutyDate);
            ds = objOperationManagement.BLPOPGetAllPost(ddlAsmtCode.SelectedValue, BaseLocationAutoID, strDutyDate, strDutyDate, ddlClientCode.SelectedValue);
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                ddlPostCode.DataSource = ds.Tables[0];
                ddlPostCode.DataTextField = "Post";
                ddlPostCode.DataValueField = "PostAutoId";
                ddlPostCode.DataBind();
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoDataToShow;
                li.Value = "";
                ddlPostCode.Items.Insert(0, li);
            }
        }

        if (HideShowControls())
        {
            FillGuardTourID();
        }
        else
        {
            HideButtons();
        }
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  FillToDay();
        txtEndTime.Text = string.Empty;
        txtGuardTourDesc.Text = string.Empty;
        txtStartTime.Text = string.Empty;
        FillddlAsmtCode();
    }

    protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FillToDay();
        FillddlPost();
    }

    protected void ddlPostCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGuardTourID();
        GetGuardTourHeaderDetail();
    }

    protected void ddlGuardTourID_SelectedIndexChanged(object sender, EventArgs e)
    {
        // FillToDay();
        GetGuardTourHeaderDetail();

        FillgvTagMaster();
    }
    private void GetGuardTourHeaderDetail()
    {
        DataSet ds = new DataSet();
        BL.NFC objNFC = new BL.NFC();
        //Modify By  on 21-Apr-2014
        //ds = objNFC.blNfc_GuardTour_GetAll(ddlGuardTourID.SelectedValue.ToString(), BaseLocationAutoID);
        ds = objNFC.BlNfcGuardTourGetAll(ddlGuardTourID.SelectedValue, BaseLocationAutoID);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            FillGuardTourHeaderDetail(ds);
        }
    }

    protected void ddlFromDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillToDay();
    }

    private void HideButtons()
    {
        btnSave.Visible = false;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
    }


    private void FillGuardTourID()
    {
        BL.Sales objTour = new BL.Sales();
        DataSet ds = new DataSet();
        ListItem li = new ListItem();
        ddlGuardTourID.Items.Clear();
        //Modify By  on 21-Apr-2014
        //ds = objTour.bl_TagTourID(ddlClientCode.SelectedItem.Value, ddlAsmtCode.SelectedItem.Value, ddlPostCode.SelectedItem.Value);
        ds = objTour.BlTagTourID(ddlClientCode.SelectedItem.Value, ddlAsmtCode.SelectedItem.Value, ddlPostCode.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlGuardTourID.DataSource = ds.Tables[0].DefaultView;
            ddlGuardTourID.DataTextField = "GTourId";
            ddlGuardTourID.DataValueField = "GTourId";
            ddlGuardTourID.DataBind();

            FillGuardTourHeaderDetail(ds);

        }
        else
        {
            li.Text = "No Guard Tour Exists";
            li.Value = "";
            ddlGuardTourID.Items.Insert(0, li);
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNewGuardTour.Visible = false;
            FillFromDay();
            gvGuardTour.DataSource = null;
            gvGuardTour.DataBind();

        }
    }

    private void FillGuardTourHeaderDetail(DataSet ds)
    {
        ddlGuardTourID.SelectedValue = ds.Tables[0].Rows[0]["GTourId"].ToString();
        txtStartTime.Text = ds.Tables[0].Rows[0]["StartTime"].ToString();
        txtEndTime.Text = ds.Tables[0].Rows[0]["EndTime"].ToString();
        HFStartTime.Value = txtStartTime.Text;
        HFEndTime.Value = txtEndTime.Text;
        txtGuardTourDesc.Text = ds.Tables[0].Rows[0]["GuardTourDesc"].ToString();
        //FillFromDay();
        ddlFromDay.SelectedValue = ds.Tables[0].Rows[0]["StartDay"].ToString();
        FillToDay();
        ddlToDay.SelectedValue = ds.Tables[0].Rows[0]["EndDay"].ToString();
        //Code Added By  
        chkSuperv1.Checked = Boolean.Parse(ds.Tables[0].Rows[0]["Supervision"].ToString());
        btnSave.Visible = false;
        btnDelete.Visible = true;
        btnNewGuardTour.Visible = true;
        btnUpdate.Visible = true;
        FillgvTagMaster();
    }
    private bool HideShowControls()
    {
        if (ddlClientCode.SelectedValue.ToString() == "" || ddlAsmtCode.SelectedValue.ToString() == "" || ddlPostCode.SelectedValue.ToString() == "")
        {
            lblGuardTourID.Visible = false;
            ddlGuardTourID.Visible = false;
            lblStartTime.Visible = false;
            lblEndTime.Visible = false;
            txtStartTime.Visible = false;
            txtEndTime.Visible = false;
            lblFromDay.Visible = false;
            ddlFromDay.Visible = false;
            lblToDay.Visible = false;
            ddlToDay.Visible = false;
            return false;
        }
        else if (ddlClientCode.SelectedValue.ToString() != "" && ddlAsmtCode.SelectedValue.ToString() != "" && ddlPostCode.SelectedValue.ToString() != "")
        {
            lblGuardTourID.Visible = true;
            ddlGuardTourID.Visible = true;
            lblStartTime.Visible = true;
            lblEndTime.Visible = true;
            txtStartTime.Visible = true;
            txtEndTime.Visible = true;
            lblFromDay.Visible = true;
            ddlFromDay.Visible = true;
            lblToDay.Visible = true;
            ddlToDay.Visible = true;
            return true;
        }
        else
        {
            return false;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.NFC objNFC = new BL.NFC();

        string strStartTime = "01-01-1900" + " " + txtStartTime.Text;
        string strEndTime = "01-01-1900" + " " + txtEndTime.Text;
        if (txtStartTime.Text == txtEndTime.Text)
        {
            lblErrorMsg.Text = "Invalid Time";
            return;
        }
        //Modify By  on 21-Apr-2014
        //Code Added By  
        //ds = objNFC.blNfc_GuardTour_InsertAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), ddlAsmtCode.SelectedValue.ToString(), ddlPostCode.SelectedValue.ToString(), txtGuardTourDesc.Text, strStartTime, strEndTime, ddlFromDay.SelectedValue.ToString(), ddlToDay.SelectedValue.ToString(), BaseUserID, chkSuperv1.Checked.ToString());
        ds = objNFC.BlNfcGuardTourInsertAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), ddlAsmtCode.SelectedValue.ToString(), ddlPostCode.SelectedValue.ToString(), txtGuardTourDesc.Text, strStartTime, strEndTime, ddlFromDay.SelectedValue.ToString(), ddlToDay.SelectedValue.ToString(), BaseUserID, chkSuperv1.Checked.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillGuardTourID();
            FillGuardTourHeaderDetail(ds);

        }
        //  }
        //else
        //{
        //    lblErrorMsg.Text = "Start time Should not be less then Endtime";

        //}
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.NFC objNFC = new BL.NFC();

        ds = objNFC.BlNfcGuardTourDeleteAll(ddlGuardTourID.SelectedValue.ToString(), BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillGuardTourID();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.NFC objNFC = new BL.NFC();

        string strStartTime = "01-01-1900" + " " + txtStartTime.Text;
        string strEndTime = "01-01-1900" + " " + txtEndTime.Text;
        if (txtStartTime.Text == txtEndTime.Text)
        {
            lblErrorMsg.Text = "Invalid Time";
            return;
        }
        //Modify By  on 21-Apr-2014
        //Code Added By  
        //ds = objNFC.blNfc_GuardTour_Update(ddlGuardTourID.SelectedValue.ToString(), txtGuardTourDesc.Text, strStartTime, strEndTime, ddlFromDay.SelectedValue.ToString(), ddlToDay.SelectedValue.ToString(), BaseUserID, chkSuperv1.Checked.ToString());
        ds = objNFC.BlNfcGuardTourUpdate(ddlGuardTourID.SelectedValue.ToString(), txtGuardTourDesc.Text, strStartTime, strEndTime, ddlFromDay.SelectedValue.ToString(), ddlToDay.SelectedValue.ToString(), BaseUserID, chkSuperv1.Checked.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        GetGuardTourHeaderDetail();

    }
    protected void btnNewGuardTour_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.NFC objNFC = new BL.NFC();

        int i = DateTime.Compare(Convert.ToDateTime(txtStartTime.Text), Convert.ToDateTime(txtEndTime.Text));
        //if (i < 0)
        //{
        string strStartTime = "01-01-1900" + " " + txtStartTime.Text;
        string strEndTime = "01-01-1900" + " " + txtEndTime.Text;
        //Modify By  on 21-Apr-2014
        //Code Added By  
        //ds = objNFC.blNfc_GuardTour_InsertAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), ddlAsmtCode.SelectedValue.ToString(), ddlPostCode.SelectedValue.ToString(), txtGuardTourDesc.Text, strStartTime, strEndTime, ddlFromDay.SelectedValue.ToString(), ddlToDay.SelectedValue.ToString(), BaseUserID, chkSuperv1.Checked.ToString());
        ds = objNFC.BlNfcGuardTourInsertAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), ddlAsmtCode.SelectedValue.ToString(), ddlPostCode.SelectedValue.ToString(), txtGuardTourDesc.Text, strStartTime, strEndTime, ddlFromDay.SelectedValue.ToString(), ddlToDay.SelectedValue.ToString(), BaseUserID, chkSuperv1.Checked.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillGuardTourID();
            FillGuardTourHeaderDetail(ds);

        }
        //}
        // else
        //{
        //    lblErrorMsg.Text = "Start time Should not be less then Endtime";

        //} 



    }

    protected void gvGuardTour_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvGuardTour_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGuardTour.EditIndex = e.NewEditIndex;
        FillgvTagMaster();
    }
    protected void gvGuardTour_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Code Modified By  
        //TextBox txtTagDesc = (TextBox)gvGuardTour.Rows[e.RowIndex].FindControl("txtTagDesc");
        DropDownList ddlgvTagID = (DropDownList)gvGuardTour.Rows[e.RowIndex].FindControl("ddlgvTagID");
        //Label txtTagDesc = (TextBox)gvGuardTour.Rows[e.RowIndex].FindControl("txtTagDesc");
        TextBox txtScheduledTime = (TextBox)gvGuardTour.Rows[e.RowIndex].FindControl("txtScheduledTime");
        TextBox txtInterval = (TextBox)gvGuardTour.Rows[e.RowIndex].FindControl("txtInterval");
        DropDownList ddlDuration = (DropDownList)gvGuardTour.Rows[e.RowIndex].FindControl("ddlDuration");
        Label lblgvTagID = (Label)gvGuardTour.Rows[e.RowIndex].FindControl("lblgvTagID");
        //TextBox txtGraceTime = (TextBox)gvGuardTour.Rows[e.RowIndex].FindControl("txtGraceTime");
        BL.Sales objMasterManagement = new BL.Sales();
        DataSet ds = new DataSet();
        string txtGraceTime = "0";
        string strStartTime = "01-01-1900" + " " + txtStartTime.Text;
        string strEndTime = "01-01-1900" + " " + txtEndTime.Text;
        string strScheduleTime = "01-01-1900" + " " + txtScheduledTime.Text;
        //Code Added By 
        if (int.Parse(txtInterval.Text.ToString()) > 24 && ddlDuration.SelectedItem.Value.ToString() == "Hrs")
        {
            lblErrorMsg.Text = "Hours cannot be Greater than 24";
            txtInterval.Text = "";
            txtInterval.Focus();
            return;
        }
        if (int.Parse(txtInterval.Text.ToString()) > 999 && ddlDuration.SelectedItem.Value.ToString() == "Min")
        {
            lblErrorMsg.Text = "Minutes cannot be Greater than 999";
            txtInterval.Text = "";
            txtInterval.Focus();
            return;
        }


        //To verify EndTime either next day time or Not. 
        //If EndTime its next day time then we  initialize strEndTime is next day time
        //txtStartTime.Text="19:00" and txtEndTime.Text="07:00"
        // 19:00>07:00 and 07:00>00:00 if condition is true.Then given EndTime is next day time 
        DateTime dtStartDateTime = Convert.ToDateTime(txtStartTime.Text);
        DateTime dtScheduledTime = Convert.ToDateTime(txtScheduledTime.Text);
        DateTime dtEndDateTime = Convert.ToDateTime(txtEndTime.Text).AddDays(double.Parse("1"));

        if (Convert.ToDateTime(dtScheduledTime) >= Convert.ToDateTime(dtStartDateTime.ToString()))
        {
            strScheduleTime = dtStartDateTime.ToString("dd-MMM-yyyy") + " " + Convert.ToDateTime(strScheduleTime).ToString("HH:mm");
        }
        else
        {
            strScheduleTime = dtStartDateTime.AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + Convert.ToDateTime(strScheduleTime).ToString("HH:mm");
        }

        TimeSpan tsDateTimeDiff = dtEndDateTime.Subtract(dtStartDateTime);

        if (tsDateTimeDiff.Days >= 1)
        {
            //Code Modified By  
            if (ddlgvTagID.SelectedItem.Value.ToString() != "")
            {
                //Modify by  on 21-Apr-2014
                //ds = objMasterManagement.blTagMaster_Update(ddlGuardTourID.SelectedItem.Value, lblgvTagID.Text.ToString(), ddlgvTagID.SelectedItem.Text.ToString(), txtScheduledTime.Text, Convert.ToInt32(txtInterval.Text), txtGraceTime, ddlDuration.SelectedItem.Value, BaseUserID);
                ds = objMasterManagement.BlTagMasterUpdate(ddlGuardTourID.SelectedItem.Value, lblgvTagID.Text.ToString(), ddlgvTagID.SelectedItem.Text.ToString(), txtScheduledTime.Text, Convert.ToInt32(txtInterval.Text), txtGraceTime, ddlDuration.SelectedItem.Value, BaseUserID);
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
            }
        }
        else if (Convert.ToDateTime(strScheduleTime) >= dtStartDateTime && Convert.ToDateTime(strScheduleTime) <= dtEndDateTime)
        {
            //Code Modified By  
            if (ddlgvTagID.SelectedItem.Value.ToString() != "")
            {
                //Modify by  on 21-Apr-2014
                //ds = objMasterManagement.blTagMaster_Update(ddlGuardTourID.SelectedItem.Value, lblgvTagID.Text, ddlgvTagID.SelectedItem.Value.ToString(), txtScheduledTime.Text, Convert.ToInt32(txtInterval.Text), txtGraceTime, ddlDuration.SelectedItem.Value, BaseUserID);
                ds = objMasterManagement.BlTagMasterUpdate(ddlGuardTourID.SelectedItem.Value, lblgvTagID.Text, ddlgvTagID.SelectedItem.Value.ToString(), txtScheduledTime.Text, Convert.ToInt32(txtInterval.Text), txtGraceTime, ddlDuration.SelectedItem.Value, BaseUserID);
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
            }
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        gvGuardTour.EditIndex = -1;
        FillgvTagMaster();
        //if (Convert.ToDateTime(txtStartTime.Text) > Convert.ToDateTime(txtEndTime.Text) && Convert.ToDateTime(txtEndTime.Text) > Convert.ToDateTime("00:00"))
        //{
        //    strStartTime = DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtStartTime.Text;
        //    strEndTime = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy") + " " + txtEndTime.Text;
        //    //Verify Either NewScheduledTime is in between StartTime and EndTime also verify 
        //    //NewScheduledTime is same date or next date.
        //    //IF NewScheduledTime is from next date then we initilize NewScheduledTime+1 day else same day  
        //    if (Convert.ToDateTime(txtScheduledTime.Text) > Convert.ToDateTime(txtStartTime.Text) && Convert.ToDateTime(txtScheduledTime.Text) > Convert.ToDateTime("00:00"))
        //    {
        //        strScheduleTime = DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtScheduledTime.Text;

        //    }
        //    else if (Convert.ToDateTime(txtScheduledTime.Text) < Convert.ToDateTime(txtStartTime.Text) && Convert.ToDateTime(txtScheduledTime.Text) > Convert.ToDateTime("00:00") && Convert.ToDateTime(txtScheduledTime.Text) < Convert.ToDateTime(txtEndTime.Text))
        //    {
        //        strScheduleTime = DateTime.Now.AddDays(1).ToShortDateString() + " " + txtScheduledTime.Text;
        //    }
        //}
        //else
        //{
        //    strStartTime = DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtStartTime.Text;
        //    strEndTime = DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtEndTime.Text;
        //    strScheduleTime = DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtScheduledTime.Text;
        //}

        //if (DateTime.Parse(strScheduleTime) >= DateTime.Parse(strStartTime) && DateTime.Parse(strScheduleTime) <= DateTime.Parse(strEndTime))
        //{


        //    strStartTime = "01-01-1900" + " " + txtStartTime.Text;
        //   strEndTime = "01-01-1900" + " " + txtEndTime.Text;
        //  strScheduleTime = "01-01-1900" + " " + txtScheduledTime.Text;

        //    ds = objMasterManagement.blTagMaster_Update(ddlGuardTourID.SelectedItem.Value, lblgvTagID.Text, txtTagDesc.Text, txtScheduledTime.Text, Convert.ToInt32(txtInterval.Text), txtGraceTime, ddlDuration.SelectedItem.Value, BaseUserID);
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        //    }
        //    gvGuardTour.EditIndex = -1;
        //    FillgvTagMaster();
        //}
        //else
        //{
        //    lblErrorMsg.Text = "Invalid Schedule Time!";
        //}

    }
    protected void gvGuardTour_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvGuardTour.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvGuardTour.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvGuardTour.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvGuardTour.PageCount.ToString();
        }

    }

    protected void gvGuardTour_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Add New")
        {

            BL.Sales objGuard = new BL.Sales();
            DataSet ds = new DataSet();

            //Code Modified By  
            //TextBox txtTagID = (TextBox)gvGuardTour.FooterRow.FindControl("txtTagID");
            //TextBox txtNewTagDesc = (TextBox)gvGuardTour.FooterRow.FindControl("txtNewTagDesc");
            DropDownList ddlTagID = (DropDownList)gvGuardTour.FooterRow.FindControl("ddlTagID");

            TextBox txtNewScheduledTime = (TextBox)gvGuardTour.FooterRow.FindControl("txtNewScheduledTime");
            TextBox txtNewInterval = (TextBox)gvGuardTour.FooterRow.FindControl("txtNewInterval");
            // TextBox txtNewGraceTime = (TextBox)gvGuardTour.FooterRow.FindControl("txtNewGraceTime");
            DropDownList ddlNewDuration = (DropDownList)gvGuardTour.FooterRow.FindControl("ddlNewDuration");
            string strStartTime = "01-01-1900" + " " + txtStartTime.Text;
            string strEndTime = "01-01-1900" + " " + txtEndTime.Text;
            string strScheduleTime = "01-01-1900" + " " + txtNewScheduledTime.Text;
            string txtNewGraceTime = "0";

            //Code Added By 
            if (int.Parse(txtNewInterval.Text.ToString()) > 24 && ddlNewDuration.SelectedItem.Value.ToString() == "Hrs")
            {
                lblErrorMsg.Text = "Hours cannot be Greater than 24";
                txtNewInterval.Text = "";
                txtNewInterval.Focus();
                return;
            }
            if (int.Parse(txtNewInterval.Text.ToString()) > 999 && ddlNewDuration.SelectedItem.Value.ToString() == "Min")
            {
                lblErrorMsg.Text = "Minutes cannot be Greater than 999";
                txtNewInterval.Text = "";
                txtNewInterval.Focus();
                return;
            }

            //To verify EndTime either next day time or Not. 
            //If EndTime its next day time then we  initialize strEndTime is next day time
            //txtStartTime.Text="19:00" and txtEndTime.Text="07:00"
            // 19:00>07:00 and 07:00>00:00 if condition is true.Then given EndTime is next day time 
            DateTime dtScheduledTime = Convert.ToDateTime(txtNewScheduledTime.Text);
            DateTime dtStartDateTime = Convert.ToDateTime(txtStartTime.Text);
            DateTime dtEndDateTime = Convert.ToDateTime(txtEndTime.Text).AddDays(double.Parse("1"));

            if (Convert.ToDateTime(dtScheduledTime) >= Convert.ToDateTime(dtStartDateTime.ToString()))
            {
                strScheduleTime = dtStartDateTime.ToString("dd-MMM-yyyy") + " " + Convert.ToDateTime(strScheduleTime).ToString("HH:mm");
            }
            else
            {
                strScheduleTime = dtStartDateTime.AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + Convert.ToDateTime(strScheduleTime).ToString("HH:mm");
            }

            TimeSpan tsDateTimeDiff = dtEndDateTime.Subtract(dtStartDateTime);

            if (tsDateTimeDiff.Days >= 1)
            {
                //Code Modified By  
                if (ddlTagID.SelectedItem.Value != "")
                {
                    //Modify By  on 21-Apr-2014
                    //ds = objGuard.blTagInsert(ddlGuardTourID.SelectedItem.Value, ddlTagID.SelectedItem.Value.ToString(), ddlTagID.SelectedItem.Text.ToString(), strScheduleTime, Convert.ToInt32(txtNewInterval.Text), txtNewGraceTime, ddlNewDuration.SelectedItem.Value, BaseUserID);
                    ds = objGuard.BlTagInsert(ddlGuardTourID.SelectedItem.Value, ddlTagID.SelectedItem.Value.ToString(), ddlTagID.SelectedItem.Text.ToString(), strScheduleTime, Convert.ToInt32(txtNewInterval.Text), txtNewGraceTime, ddlNewDuration.SelectedItem.Value, BaseUserID);
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.NoRecordFound;
                }
            }
            else if (Convert.ToDateTime(strScheduleTime) >= dtStartDateTime && Convert.ToDateTime(strScheduleTime) <= dtEndDateTime)
            {
                //Code Modified By  
                if (ddlTagID.SelectedItem.Value != "")
                {
                    //Modify By  on 21-Apr-2014
                    //ds = objGuard.blTagInsert(ddlGuardTourID.SelectedItem.Value, ddlTagID.SelectedItem.Value.ToString(), ddlTagID.SelectedItem.Text.ToString(), strScheduleTime, Convert.ToInt32(txtNewInterval.Text), txtNewGraceTime, ddlNewDuration.SelectedItem.Value, BaseUserID);
                    ds = objGuard.BlTagInsert(ddlGuardTourID.SelectedItem.Value, ddlTagID.SelectedItem.Value.ToString(), ddlTagID.SelectedItem.Text.ToString(), strScheduleTime, Convert.ToInt32(txtNewInterval.Text), txtNewGraceTime, ddlNewDuration.SelectedItem.Value, BaseUserID);
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.NoRecordFound;
                }

            }
            FillgvTagMaster();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            //  if(Convert.ToDateTime(txtStartTime.Text)>Convert.ToDateTime(txtEndTime.Text)&& Convert.ToDateTime(txtEndTime.Text) >Convert.ToDateTime("00:00"))
            //  {
            //       strStartTime=DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtStartTime.Text;
            //       strEndTime = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy") + " " + txtEndTime.Text;


            //      //Verify Either NewScheduledTime is in between StartTime and EndTime also verify 
            //      //NewScheduledTime is same date or next date.
            //      //IF NewScheduledTime is from next date then we initilize NewScheduledTime+1 day else same day  

            //       if (Convert.ToDateTime(txtNewScheduledTime.Text) > Convert.ToDateTime(txtStartTime.Text) && Convert.ToDateTime(txtNewScheduledTime.Text) > Convert.ToDateTime("00:00") )
            //      {

            //              strScheduleTime = DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtNewScheduledTime.Text;

            //      }
            //      else if (Convert.ToDateTime(txtNewScheduledTime.Text)<Convert.ToDateTime(txtStartTime.Text) && Convert.ToDateTime(txtNewScheduledTime.Text) > Convert.ToDateTime("00:00") &&Convert.ToDateTime(txtNewScheduledTime.Text)< Convert.ToDateTime(txtEndTime.Text))
            //      {
            //          strScheduleTime = DateTime.Now.AddDays(1).ToShortDateString() + " " + txtNewScheduledTime.Text; 

            //      }

            //  }
            //  else
            //  {
            //     strStartTime=DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtStartTime.Text;
            //       strEndTime = DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtEndTime.Text;
            //      strScheduleTime = DateTime.Now.ToString("dd-MMM-yyyy") + " " + txtNewScheduledTime.Text;

            //  }


            //if (DateTime.Parse(strScheduleTime) >= DateTime.Parse(strStartTime) && DateTime.Parse(strScheduleTime) <= DateTime.Parse(strEndTime))
            //{

            //      //After Evaluating the checks again we initialize the value in  data base formate  
            //       strStartTime = "01-01-1900" + " " + txtStartTime.Text;
            //        strEndTime = "01-01-1900" + " " + txtEndTime.Text;
            //        strScheduleTime = "01-01-1900" + " " + txtNewScheduledTime.Text;


            //    ds = objGuard.blTagInsert(ddlGuardTourID.SelectedItem.Value, txtTagID.Text, txtNewTagDesc.Text, strScheduleTime, txtNewInterval.Text,txtNewGraceTime ,ddlNewDuration.SelectedItem.Value, BaseUserID);
            //    FillgvTagMaster();

            //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            //    }
            //}
            //else
            //{
            //    lblErrorMsg.Text = "Invalid Schedule Time!";
            //}
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvGuardTour.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvGuardTour.PageIndex = gvGuardTour.PageCount;
                break;
        }

    }
    protected void gvGuardTour_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblgvTagID = (Label)gvGuardTour.Rows[e.RowIndex].FindControl("lblgvTagID");
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();
        //Modify By  on 21-Apr-2014
        //ds = objSale.blTagID_Delete(ddlGuardTourID.SelectedItem.Value, lblgvTagID.Text);
        ds = objSale.BlTagIDDelete(ddlGuardTourID.SelectedItem.Value, lblgvTagID.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvTagMaster();
        }
        FillgvTagMaster();
    }
    protected void gvGuardTour_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvGuardTour.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvGuardTour.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvGuardTour.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvGuardTour.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvGuardTour.PageIndex = e.NewPageIndex;
        }
        gvGuardTour.EditIndex = -1;
        FillgvTagMaster();
    }
    protected void gvGuardTour_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvGuardTour.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

            }
            HiddenField HFDuration = (HiddenField)e.Row.FindControl("HFDuration");
            DropDownList ddlDuration = (DropDownList)e.Row.FindControl("ddlDuration");
            if (HFDuration != null)
            {
                ddlDuration.SelectedValue = HFDuration.Value;
            }


            //Code Modified By  
            //TextBox txtTagDesc = (TextBox)e.Row.FindControl("txtTagDesc");
            DropDownList ddlgvTagID = (DropDownList)e.Row.FindControl("ddlgvTagID");
            Label lblgvTagID = (Label)e.Row.FindControl("lblgvTagID");
            BL.Sales objTagID = new BL.Sales();
            DataSet dsTagID = new DataSet();
            if (ddlgvTagID != null)
            {
                //Modify By  on 21-Apr-2014
                //dsTagID = objTagID.blTagID_Get(BaseLocationAutoID, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), ddlPostCode.SelectedItem.Value.ToString(), chkSuperv1.Checked.ToString());
                dsTagID = objTagID.BlTagIDGet(BaseLocationAutoID, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), ddlPostCode.SelectedItem.Value.ToString(), chkSuperv1.Checked.ToString());
                if (dsTagID != null && dsTagID.Tables[0].Rows.Count > 0 && dsTagID.Tables.Count > 0)
                {
                    ddlgvTagID.DataSource = dsTagID.Tables[0];
                    ddlgvTagID.DataTextField = "TagDescription";
                    ddlgvTagID.DataValueField = "TagID";


                    ddlgvTagID.DataBind();
                    ddlgvTagID.SelectedValue = lblgvTagID.Text;
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Value = "";
                    li.Text = Resources.Resource.NoDataToShow;
                    ddlgvTagID.Items.Insert(0, li);


                }
            }

            //Comment this code because is not allow enter greek 
            //if (txtTagDesc != null)
            //{
            //    txtTagDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            //    txtTagDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            //}
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvGuardTour.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                //Code Added By  
                //Comment this row to allow TagID to be incorporated form LocationTagID screen
                //TextBox txtTagID = (TextBox)e.Row.FindControl("txtTagID");
                DropDownList ddlTagID = (DropDownList)e.Row.FindControl("ddlTagID");
                BL.Sales objTagID = new BL.Sales();
                DataSet dsTagID = new DataSet();

                //Modify By  on 21-Apr-2014
                //dsTagID = objTagID.blTagID_Get(BaseLocationAutoID, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), ddlPostCode.SelectedItem.Value.ToString(), chkSuperv1.Checked.ToString());
                dsTagID = objTagID.BlTagIDGet(BaseLocationAutoID, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), ddlPostCode.SelectedItem.Value.ToString(), chkSuperv1.Checked.ToString());
                if (dsTagID != null && dsTagID.Tables[0].Rows.Count > 0 && dsTagID.Tables.Count > 0)
                {
                    ddlTagID.DataSource = dsTagID.Tables[0];
                    ddlTagID.DataTextField = "TagDescription";
                    ddlTagID.DataValueField = "TagID";
                    ddlTagID.DataBind();

                }
                else
                {
                    ListItem li = new ListItem();
                    li.Value = "";
                    li.Text = Resources.Resource.NoDataToShow;
                    ddlTagID.Items.Insert(0, li);


                }


                //Comment this code because is not allow enter greek 
                //if (txtTagID != null)
                //{
                //    txtTagID.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                //    txtTagID.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                //}
                TextBox txtNewTagDesc = (TextBox)e.Row.FindControl("txtNewTagDesc");
                //if (txtNewTagDesc != null)
                //{
                //    txtNewTagDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //    txtNewTagDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //}
                TextBox txtNewScheduledTime = (TextBox)e.Row.FindControl("txtNewScheduledTime");

                TextBox txtNewInterval = (TextBox)e.Row.FindControl("txtNewInterval");
                if (txtNewInterval != null)
                {
                    txtNewInterval.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewInterval.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                Label lblgvGTourID = (Label)e.Row.FindControl("lblgvGTourID");
                if (lblgvGTourID != null)
                {
                    lblgvGTourID.Text = ddlGuardTourID.SelectedValue.ToString();
                }
            }
        }
    }

    protected void gvGuardTour_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGuardTour.EditIndex = -1;
        FillgvTagMaster();
    }

    #region GridView Functions

    private void FillgvTagMaster()
    {
        gvGuardTour.Visible = true;
        BL.Sales objSale = new BL.Sales();
        DataSet dsTagMaster = new DataSet();
        DataTable dtTagMaster = new DataTable();
        if (ddlGuardTourID.SelectedValue.ToString() != "Not Exits")
        {
            //Modify By  on 21-Apr-2014
            //dsTagMaster = objSale.bl_TagMaster_Get(ddlGuardTourID.SelectedValue.ToString());
            dsTagMaster = objSale.BlTagMasterGet(ddlGuardTourID.SelectedValue.ToString());
            if (dsTagMaster != null && dsTagMaster.Tables.Count > 0 && dsTagMaster.Tables[0].Rows.Count > 0)
            {
                // txtStartTime.Text = dsTagMaster.Tables[0].Rows[0]["Start"].ToString();
                // txtEndTime.Text = dsTagMaster.Tables[0].Rows[0][5].ToString();
                gvGuardTour.DataSource = dsTagMaster;
                gvGuardTour.DataBind();
            }
            else
            {
                if (ddlGuardTourID.SelectedValue != "")
                {
                    dtTagMaster = dsTagMaster.Tables[0];
                    dtTagMaster.Rows.Add(dtTagMaster.NewRow());
                    gvGuardTour.DataSource = dtTagMaster;
                    gvGuardTour.DataBind();
                    gvGuardTour.Rows[0].Visible = false;
                    // lblErrorMsg.Text = Resources.Resource.NoRecordFound;
                }
                else
                {
                    // lblErrorMsg.Text = Resources.Resource.NoRecordFound;
                }
                //  gvGuardTour.Visible = false;
                //txtStartTime.Text = "";
                // txtEndTime.Text = "";
            }
        }
        else
        {
            gvGuardTour.Visible = false;
            //txtEndTime.Text = "";
            //txtStartTime.Text = "";
        }
    }
    #endregion

    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvGuardTour.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvGuardTour.PageIndex = ddlPages.SelectedIndex;
        FillgvTagMaster();
    }




}
