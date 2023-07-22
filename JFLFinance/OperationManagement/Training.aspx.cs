// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Training.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class OperationManagement_Training.
/// </summary>
public partial class OperationManagement_Training : BasePage  //System.Web.UI.Page
{
    /// <summary>
    /// The dt temporary TRN details
    /// </summary>
    static DataTable dtTempTrnDetails = new DataTable();
    /// <summary>
    /// The status
    /// </summary>
    static int status;


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
    /// <summary>
    /// Gets a value indicating whether this instance is authorization access.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                BasePage bp = new BasePage();
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {           
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.TrainingDetail + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                status = 1;
                dtTempTrnDetails.Clear();
                txtTrnDate.Text = DateFormat(DateTime.Now).ToString();
                if (dtTempTrnDetails.Columns.Contains("EmployeeNumber") == false)
                {
                    MakeTempTrnDetail();
                }
                else
                {
                    dtTempTrnDetails.Clear();
                }
                FillTrainingType();
                FillgvTrnDetails();
                HideButtonBasedOnStatus();
                IMGTrainingSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=TRAININGCCH&ControlId=" + txtTrnNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                imgAssignSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtAssignNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                imgDefaultConductedBySearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtDefaultConductedBy.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=500,help=no')");
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            //  IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
        }
    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtTrnNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtTrnNo_OnTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        status = 0;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AsmtTrainingDetailGet(BaseLocationAutoID, txtTrnNo.Text.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAssignNo.Text = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
            lblTrnStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            ddlTrainingType.SelectedValue = ds.Tables[0].Rows[0]["Training_type"].ToString();
            txtTrnDate.Text = DateFormat(ds.Tables[0].Rows[0]["Training_date"].ToString());
            txtDefaultConductedBy.Text = ds.Tables[0].Rows[0]["Conducted_by"].ToString();
            lblDefaultConductedByName.Text = ds.Tables[0].Rows[0]["Conducted_by_Name"].ToString();
            lblDefaultConductedByDesg.Text = ds.Tables[0].Rows[0]["Conducted_by_Desg"].ToString();
            txtAreaToBeCovered.Text = ds.Tables[0].Rows[0]["Areas_to_be_covered"].ToString();
            txtActualTrainingDate.Text = DateFormat(ds.Tables[0].Rows[0]["Actual_training_date"].ToString());
            txtDefaultTimeFrom.Text = DateTime.Parse(ds.Tables[0].Rows[0]["time_from"].ToString()).ToString("HH:mm");
            txtDefaultTimeTo.Text = DateTime.Parse(ds.Tables[0].Rows[0]["time_to"].ToString()).ToString("HH:mm");
            txtDefaultTargetHrs.Text = DateTime.Parse(ds.Tables[0].Rows[0]["Hours"].ToString()).ToString("HH:mm");
            txtDefaultRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            FillAsmtDetails();
            FillgvTrnDetailsAfterSave(txtTrnNo.Text);
            HideButtonBasedOnStatus();
            
        }
        else
        {
            DisplayMessageString(lblErrorMsg, "Invalid Training No.");
            txtTrnNo.Text = "";
            ToolkitScriptManager1.SetFocus("txtTrnNo");
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtAssignNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtAssignNo_TextChanged(object sender, EventArgs e)
    {
        FillAsmtDetails();
    }

    /// <summary>
    /// Fills the type of the training.
    /// </summary>
    protected void FillTrainingType()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();

        ddlTrainingType.DataSource = objOperationManagement.AssignmentTrainingTypeGet(BaseCompanyCode);
        ddlTrainingType.DataTextField = "ItemDesc";
        ddlTrainingType.DataValueField = "ItemCode";
        ddlTrainingType.DataBind();
        if (ddlTrainingType.SelectedValue.ToString() == "")
        {
            ListItem LiN = new ListItem();
            LiN.Text =  Resources.Resource.NoData;
            LiN.Value = "0";
            ddlTrainingType.Items.Add(LiN);
        }
    }

    /// <summary>
    /// Handles the onTextChanged event of the txtEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtEmployeeNumber_onTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        Label lblFtrEmpName = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrEmpName");
        Label lblFtrEmpDesg = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrEmpDesg");
        TextBox txtEmployeeNumber = (TextBox)gvTrnDetails.FooterRow.FindControl("txtEmployeeNumber");
        TextBox txtConductedBy = (TextBox)gvTrnDetails.FooterRow.FindControl("txtConductedBy");
        Label lblFtrCondByName = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByName");
        Label lblFtrCondByDesg = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByDesg");
        TextBox txtTimeFrom = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeFrom");
        TextBox txtTimeTo = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeTo");
        TextBox txtHrs = (TextBox)gvTrnDetails.FooterRow.FindControl("txtHrs");
        TextBox txtftrRemarks = (TextBox)gvTrnDetails.FooterRow.FindControl("txtftrRemarks");
        TextBox txtAreasCovered = (TextBox)gvTrnDetails.FooterRow.FindControl("txtAreasCovered");
        TextBox txtTraingDate = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTraingDate");

        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeNumber.Text.ToString(), BaseCompanyCode);

        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            lblFtrEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            lblFtrEmpDesg.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();


            txtConductedBy.Text = txtDefaultConductedBy.Text;
            lblFtrCondByName.Text = lblDefaultConductedByName.Text;
            lblFtrCondByDesg.Text = lblDefaultConductedByDesg.Text;
            txtTimeFrom.Text = txtDefaultTimeFrom.Text;
            txtTimeTo.Text = txtDefaultTimeTo.Text;
            txtHrs.Text = txtDefaultTargetHrs.Text;
            txtftrRemarks.Text = txtDefaultRemarks.Text;
            txtAreasCovered.Text = txtAreaToBeCovered.Text;
            txtTraingDate.Text = txtActualTrainingDate.Text;
            ToolkitScriptManager1.SetFocus("txtConductedBy");
        }
        else
        {
            DisplayMessageString(lblGridError, Resources.Resource.InvalidEmpCode);
            txtEmployeeNumber.Text = "";
            ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
        }

    }

    /// <summary>
    /// Makes the temp TRN detail.
    /// </summary>
    protected void MakeTempTrnDetail()
    {
        DataColumn dCol1 = new DataColumn("EmployeeNumber", typeof(System.String));
        DataColumn dCol2 = new DataColumn("EmployeeName", typeof(System.String));
        DataColumn dCol3 = new DataColumn("EmployeeDesg", typeof(System.String));
        DataColumn dcol4 = new DataColumn("Conducted_by", typeof(System.String));
        DataColumn dcol5 = new DataColumn("Conducted_by_Name", typeof(System.String));
        DataColumn dcol6 = new DataColumn("Conducted_by_Desg", typeof(System.String));
        DataColumn dcol7 = new DataColumn("Areas_to_be_covered", typeof(System.String));
        DataColumn dcol8 = new DataColumn("Actual_training_date", typeof(System.DateTime));
        DataColumn dcol9 = new DataColumn("time_from", typeof(System.DateTime));
        DataColumn dcol10 = new DataColumn("time_to", typeof(System.DateTime));
        DataColumn dcol11 = new DataColumn("Hours", typeof(System.String));
        DataColumn dcol12 = new DataColumn("Remarks", typeof(System.String));
        dtTempTrnDetails.Columns.Add(dCol1);
        dtTempTrnDetails.Columns.Add(dCol2);
        dtTempTrnDetails.Columns.Add(dCol3);
        dtTempTrnDetails.Columns.Add(dcol4);
        dtTempTrnDetails.Columns.Add(dcol5);
        dtTempTrnDetails.Columns.Add(dcol6);
        dtTempTrnDetails.Columns.Add(dcol7);
        dtTempTrnDetails.Columns.Add(dcol8);
        dtTempTrnDetails.Columns.Add(dcol9);
        dtTempTrnDetails.Columns.Add(dcol10);
        dtTempTrnDetails.Columns.Add(dcol11);
        dtTempTrnDetails.Columns.Add(dcol12);
    }

    /// <summary>
    /// Handles the onTextChanged event of the txtConductedBy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtConductedBy_onTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        Label lblFtrCondByName = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByName");
        Label lblFtrCondByDesg = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByDesg");
        TextBox txtConductedBy = (TextBox)gvTrnDetails.FooterRow.FindControl("txtConductedBy");
        TextBox txtEmployeeNumber = (TextBox)gvTrnDetails.FooterRow.FindControl("txtEmployeeNumber");
        if (txtEmployeeNumber.Text != txtConductedBy.Text)
        {
            ds = objHRManagement.EmployeeNameAndDesignationGet(txtConductedBy.Text.ToString(), BaseCompanyCode);
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                lblFtrCondByName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                lblFtrCondByDesg.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            }
            else
            {
                DisplayMessageString(lblGridError, Resources.Resource.InvalidEmpCode);
                txtConductedBy.Text = "";
                ToolkitScriptManager1.SetFocus("txtConductedBy");
            }
        }
        else
        {
            lblErrorMsg.Text = "Employee Number and Conducted By cannot be same employee";
            txtConductedBy.Text = "";
        }
    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtTimeTo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtTimeTo_OnTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtTimeFrom = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeFrom");
        TextBox txtTimeTo = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeTo");
        TextBox txtHrs = (TextBox)gvTrnDetails.FooterRow.FindControl("txtHrs");
        TextBox txtftrRemarks = (TextBox)gvTrnDetails.FooterRow.FindControl("txtftrRemarks");
        if (txtTimeFrom.Text != "__:__" && txtTimeTo.Text != "__:__")
        {
            if (!ValidateTime(txtTimeFrom, txtTimeTo, txtHrs, txtftrRemarks))
            {
                txtHrs.Text = "";
                txtTimeTo.Text = "";
                ToolkitScriptManager1.SetFocus("txtTimeTo");
                lblErrorMsg.Text = "To Time should be greater than From Time";

            }
            else
            {
                ToolkitScriptManager1.SetFocus("txtftrRemarks");

            }
        }

    }

    /// <summary>
    /// Handles the OnTextChnaged event of the txtTimeFrom control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtTimeFrom_OnTextChnaged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtTimeFrom = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeFrom");
        TextBox txtTimeTo = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeTo");
        TextBox txtHrs = (TextBox)gvTrnDetails.FooterRow.FindControl("txtHrs");
        TextBox txtftrRemarks = (TextBox)gvTrnDetails.FooterRow.FindControl("txtftrRemarks");
        if (txtTimeFrom.Text != "__:__" && txtTimeTo.Text != "__:__")
        {
            if (!ValidateTime(txtTimeFrom, txtTimeTo, txtHrs, txtftrRemarks))
            {
                txtHrs.Text = "";
                txtTimeFrom.Text = "";

                lblErrorMsg.Text = "To Time should be greater than From Time";
                ToolkitScriptManager1.SetFocus("txtTimeFrom");
            }
            else
            {
                ToolkitScriptManager1.SetFocus("txtTimeTo");
            }
        }
    }

    /// <summary>
    /// Validates the time.
    /// </summary>
    /// <param name="FromTime">From time.</param>
    /// <param name="ToTime">To time.</param>
    /// <param name="TotalHours">The total hours.</param>
    /// <param name="Remarks">The remarks.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateTime(TextBox FromTime, TextBox ToTime, TextBox TotalHours, TextBox Remarks)
    {

        if ((FromTime.Text != "__:__" && ToTime.Text != "__:__") && (FromTime.Text != "" && ToTime.Text != ""))
        {
            DateTime dtFromTime;
            DateTime dtToTime;
            DateTime dtDifferance;
            dtFromTime = DateTime.Parse(FromTime.Text.ToString());
            dtToTime = DateTime.Parse(ToTime.Text.ToString());
            TimeSpan Ts = DateTime.Parse(ToTime.Text.ToString()).Subtract(DateTime.Parse(FromTime.Text.ToString()));
            if (Ts.Hours > -1)
            {
                TotalHours.Text = DateTime.Parse(Ts.ToString()).ToString("HH:mm");
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtTraingDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtTraingDate_OnTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtTraingDate = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTraingDate");
        if (DateTime.Parse(txtTraingDate.Text) < DateTime.Parse(txtTrnDate.Text))
        {
            lblErrorMsg.Text = "Actual Training Date Should be greater than or equal to Training Date";
            ToolkitScriptManager1.SetFocus("txtTraingDate");
        }
    }

    /// <summary>
    /// Handles the OnTextChnaged event of the txtEditTimeTo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtEditTimeTo_OnTextChnaged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtEdit = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txtEdit.NamingContainer;
        TextBox txtEditTimeFrom = (TextBox)gvTrnDetails.Rows[gvRow.RowIndex].FindControl("txtEditTimeFrom");
        TextBox txtEditTimeTo = (TextBox)gvTrnDetails.Rows[gvRow.RowIndex].FindControl("txtEditTimeTo");
        TextBox txtEditHrs = (TextBox)gvTrnDetails.Rows[gvRow.RowIndex].FindControl("txtEditHrs");
        TextBox txtEditRemarks = (TextBox)gvTrnDetails.Rows[gvRow.RowIndex].FindControl("txtEditRemarks");

        if (txtEditTimeFrom.Text != "__:__" && txtEditTimeTo.Text != "__:__")
        {
            if (!ValidateTime(txtEditTimeFrom, txtEditTimeTo, txtEditHrs, txtEditRemarks))
            {
                txtEditHrs.Text = "";
                txtEditTimeFrom.Text = "";

                lblErrorMsg.Text = "To Time should be greater than From Time";
                ToolkitScriptManager1.SetFocus("txtEditTimeFrom");
            }
            else
            {
                ToolkitScriptManager1.SetFocus("txtEditTimeTo");
            }
        }
        //if (txtEditTimeFrom.Text != "")
        //{
        //    if (txtEditTimeTo.Text != "")
        //    {
        //        TimeSpan Ts = DateTime.Parse(txtEditTimeTo.Text).Subtract(DateTime.Parse(txtEditTimeFrom.Text));
        //        txtEditHrs.Text = DateTime.Parse(Ts.ToString()).ToString("HH:mm");
        //    }
        //    else
        //    {
        //        DisplayMessageString(lblErrorMsg, "Time To can't be left blank");
        //        ToolkitScriptManager1.SetFocus("txtEditTimeTo");
        //    }
        //}
        //else
        //{
        //    DisplayMessageString(lblErrorMsg, "Time From can't be left blank");
        //    ToolkitScriptManager1.SetFocus("txtEditTimeFrom");
        //}

    }

    /// <summary>
    /// Fills the asmt details.
    /// </summary>
    private void FillAsmtDetails()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AsmtIncidentDetailGet(txtCustomerID.Text,txtAssignNo.Text.ToString(), BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                if (DateTime.Parse(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString()) <= DateTime.Parse(txtTrnDate.Text))
                {
                    txtBranchID.Text = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                    txtBranchIDDesc.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
                    txtCustomerID.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                    //txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                    //txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                    //txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                    //txtAddressID.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                    //txtAddressDesc.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();

                    txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString() + " (" + ds.Tables[0].Rows[0]["AsmtId"].ToString() + " - " + ds.Tables[0].Rows[0]["AsmtAddress"].ToString()+" )";
                    
                    hfAsmtStartDate.Value = DateFormat(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString());
                }
                else
                {
                    lblErrorMsg.Text = "Training Date Should always be greater than assignment start Date";
                }

            }
            else
            {
                DisplayMessageString(lblGridError, Resources.Resource.NoDataToShow);
                ClearFields();
            }

        }
        else
        {
            DisplayMessageString(lblGridError, Resources.Resource.NoDataToShow);
            ClearFields();
        }

    }

    /// <summary>
    /// Fillgvs the TRN details.
    /// </summary>
    protected void FillgvTrnDetails()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("EmployeeNumber", typeof(System.String));
        DataColumn dCol2 = new DataColumn("EmployeeName", typeof(System.String));
        DataColumn dCol3 = new DataColumn("EmployeeDesg", typeof(System.String));
        DataColumn dcol4 = new DataColumn("Conducted_by", typeof(System.String));
        DataColumn dcol5 = new DataColumn("Conducted_by_Name", typeof(System.String));
        DataColumn dcol6 = new DataColumn("Conducted_by_Desg", typeof(System.String));
        DataColumn dcol7 = new DataColumn("Areas_to_be_covered", typeof(System.String));
        DataColumn dcol8 = new DataColumn("Actual_training_date", typeof(System.DateTime));
        DataColumn dcol9 = new DataColumn("time_from", typeof(System.DateTime));
        DataColumn dcol10 = new DataColumn("time_to", typeof(System.DateTime));
        DataColumn dcol11 = new DataColumn("Hours", typeof(System.String));
        DataColumn dcol12 = new DataColumn("Remarks", typeof(System.String));
        dt.Columns.Add(dCol1);
        dt.Columns.Add(dCol2);
        dt.Columns.Add(dCol3);
        dt.Columns.Add(dcol4);
        dt.Columns.Add(dcol5);
        dt.Columns.Add(dcol6);
        dt.Columns.Add(dcol7);
        dt.Columns.Add(dcol8);
        dt.Columns.Add(dcol9);
        dt.Columns.Add(dcol10);
        dt.Columns.Add(dcol11);
        dt.Columns.Add(dcol12);
        int dtflag;
        dtflag = 1;
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        //just for temprarily assining the DataKey
        // gvTrnDetails.DataKeyNames = new string[] { "EmployeeNumber" };
        gvTrnDetails.DataSource = dt;
        gvTrnDetails.DataBind();
        if (dtflag == 0)//to fix empety gridview
        {
            gvTrnDetails.Rows[0].Visible = false;
            if (IsWriteAccess == true)
            {
                gvTrnDetails.FooterRow.Visible = true;
            }
        }
    }

    /// <summary>
    /// Fillgvs the TRN details after save.
    /// </summary>
    /// <param name="strTrainingNo">The STR training no.</param>
    protected void FillgvTrnDetailsAfterSave(string strTrainingNo)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dtTrainingDetails = new DataTable();
        ds = objOperationManagement.AsmtTrainingDetailGet(BaseLocationAutoID, strTrainingNo);
        dtTrainingDetails = ds.Tables[0];
 

        int dtflag;
        dtflag = 1;
        if (dtTrainingDetails.Rows.Count == 0)
        {
            dtflag = 0;
            dtTrainingDetails.Rows.Add(dtTrainingDetails.NewRow());
        }

        gvTrnDetails.DataKeyNames = new string[] { "EmployeeNumber" };
        gvTrnDetails.DataSource = dtTrainingDetails;
        gvTrnDetails.DataBind();

        if (IsWriteAccess == true)
        {
            gvTrnDetails.FooterRow.Visible = true;
        }

        if (dtflag == 0)//to fix empety gridview
        {
            gvTrnDetails.Rows[0].Visible = false;
        }

        if (lblTrnStatus.Text == Resources.Resource.Fresh || lblTrnStatus.Text == Resources.Resource.Amend)
        {
            if (IsModifyAccess == true)
            {
                gvTrnDetails.Columns[0].Visible = true;
            }
            if (IsWriteAccess == true)
            {
                gvTrnDetails.FooterRow.Visible = true;
            }
        }
        else
        {
            gvTrnDetails.Columns[0].Visible = false;
            gvTrnDetails.FooterRow.Visible = false;
        }
    }


    #region Function Related to Grid Training Details
    /// <summary>
    /// Handles the RowDataBound event of the gvTrnDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvTrnDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtConductedBy = (TextBox)e.Row.FindControl("txtConductedBy");
            ImageButton imgConductedBySearch = (ImageButton)e.Row.FindControl("imgConductedBySearch");
            if (imgConductedBySearch != null)
            {
                imgConductedBySearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtConductedBy.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=500,help=no')");
            }
            if (txtConductedBy != null)
            {
                txtConductedBy.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtConductedBy.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
            }

            TextBox txtEmployeeNumber = (TextBox)e.Row.FindControl("txtEmployeeNumber");
            ImageButton imgEmployeeNumberSearch = (ImageButton)e.Row.FindControl("imgEmployeeNumberSearch");
            if (imgEmployeeNumberSearch != null)
            {
                imgEmployeeNumberSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=500,help=no')");
            }
            if (txtEmployeeNumber != null)
            {
                txtEmployeeNumber.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtEmployeeNumber.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
            }
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvTrnDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvTrnDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblEmployeeNumber = (Label)gvTrnDetails.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        Label lblConductedBy = (Label)gvTrnDetails.Rows[e.RowIndex].FindControl("lblConductedBy");

        if (status == 1)
        {

            dtTempTrnDetails.Rows.RemoveAt(e.RowIndex);
            gvTrnDetails.DataSource = dtTempTrnDetails;
            gvTrnDetails.DataBind();
            if (dtTempTrnDetails.Rows.Count == 0)
            {
                FillgvTrnDetails();
                if (IsModifyAccess == true)
                {
                    gvTrnDetails.Columns[0].Visible = true;
                }
                if (IsWriteAccess == true)
                {
                    gvTrnDetails.FooterRow.Visible = true;
                }
            }
        }
        else if (status == 0)
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOperationManagement.TrainingDetailsDelete(txtTrnNo.Text, lblEmployeeNumber.Text, lblConductedBy.Text);
            FillgvTrnDetailsAfterSave(txtTrnNo.Text.ToString());
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvTrnDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvTrnDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (status == 1)
        {
            gvTrnDetails.EditIndex = e.NewEditIndex;
            gvTrnDetails.DataSource = dtTempTrnDetails;
            gvTrnDetails.DataBind();
            btnUpdate.Enabled = false;
            btnAuthorize.Enabled = false;
            if (IsModifyAccess == true)
            {
                gvTrnDetails.Columns[0].Visible = true;
            }
            if (IsWriteAccess == true)
            {
                gvTrnDetails.FooterRow.Visible = true;
            }
        }
        else if (status == 0)
        {
            gvTrnDetails.EditIndex = e.NewEditIndex;
            FillgvTrnDetailsAfterSave(txtTrnNo.Text.ToString());
            btnUpdate.Enabled = false;
            btnAuthorize.Enabled = false;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvTrnDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvTrnDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        Label lblEditEmployeeNumber = (Label)gvTrnDetails.Rows[e.RowIndex].FindControl("lblEditEmployeeNumber");
        Label lblEditConductedBy = (Label)gvTrnDetails.Rows[e.RowIndex].FindControl("lblEditConductedBy");
        TextBox txtEditAreasCovered = (TextBox)gvTrnDetails.Rows[e.RowIndex].FindControl("txtEditAreasCovered");
        TextBox txtEditTrainingDate = (TextBox)gvTrnDetails.Rows[e.RowIndex].FindControl("txtEditTrainingDate");
        TextBox txtEditTimeFrom = (TextBox)gvTrnDetails.Rows[e.RowIndex].FindControl("txtEditTimeFrom");
        TextBox txtEditTimeTo = (TextBox)gvTrnDetails.Rows[e.RowIndex].FindControl("txtEditTimeTo");
        TextBox txtEditHrs = (TextBox)gvTrnDetails.Rows[e.RowIndex].FindControl("txtEditHrs");
        TextBox txtEditRemarks = (TextBox)gvTrnDetails.Rows[e.RowIndex].FindControl("txtEditRemarks");
        if (status == 1)
        {
            if (txtTrnDate.Text != "")
            {
                if (DateTime.Parse(txtEditTrainingDate.Text) < DateTime.Parse(txtTrnDate.Text))
                {
                    lblErrorMsg.Text = "Actual Training Date Should be greter than or equal to Training Date";
                    ToolkitScriptManager1.SetFocus("txtEditTrainingDate");
                    return;
                }
                else
                {
                    dtTempTrnDetails.Rows[e.RowIndex][7] = txtEditAreasCovered.Text.ToString();
                    dtTempTrnDetails.Rows[e.RowIndex][8] = DateTime.Parse(txtEditTrainingDate.Text.ToString());
                    dtTempTrnDetails.Rows[e.RowIndex][9] = DateTime.Parse(txtEditTimeFrom.Text.ToString());
                    dtTempTrnDetails.Rows[e.RowIndex][10] = DateTime.Parse(txtEditTimeTo.Text.ToString());
                    dtTempTrnDetails.Rows[e.RowIndex][11] = txtEditHrs.Text.ToString();
                    dtTempTrnDetails.Rows[e.RowIndex][12] = txtEditTrainingDate.Text.ToString();

                    gvTrnDetails.EditIndex = -1;
                    gvTrnDetails.DataSource = dtTempTrnDetails;
                    gvTrnDetails.DataBind();
                    btnUpdate.Enabled = true;
                    btnAuthorize.Enabled = true;
                    if (IsModifyAccess == true)
                    {
                        gvTrnDetails.Columns[0].Visible = true;
                    }
                    if (IsWriteAccess == true)
                    {
                        gvTrnDetails.FooterRow.Visible = true;
                    }
                }
            }
        }
        else if (status == 0)
        {
            if (DateTime.Parse(txtEditTrainingDate.Text) < DateTime.Parse(txtTrnDate.Text))
            {
                lblErrorMsg.Text = "Actual Training Date Should be greter than or equal to Training Date";
                ToolkitScriptManager1.SetFocus("txtEditTrainingDate");
                return;
            }
            else
            {
                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                DataSet ds = new DataSet();
                ds = objOperationManagement.TrainingDetailsUpdate(txtTrnNo.Text.ToString(), lblEditEmployeeNumber.Text.ToString(), lblEditConductedBy.Text.ToString(), txtEditAreasCovered.Text.ToString(), DateTime.Parse(txtEditTrainingDate.Text.ToString()), DateTime.Parse(txtEditTimeFrom.Text.ToString()), DateTime.Parse(txtEditTimeTo.Text.ToString()), txtEditHrs.Text.ToString(), txtEditRemarks.Text.ToString(), BaseUserID);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    gvTrnDetails.EditIndex = -1;
                    FillgvTrnDetailsAfterSave(txtTrnNo.Text.ToString());
                    btnUpdate.Enabled = true;
                    btnAuthorize.Enabled = true;
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvTrnDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvTrnDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (status == 1)
        {
            gvTrnDetails.EditIndex = -1;
            gvTrnDetails.DataSource = dtTempTrnDetails;
            gvTrnDetails.DataBind();
            btnUpdate.Enabled = true;
            btnAuthorize.Enabled = true;
        }
        else if (status == 0)
        {
            gvTrnDetails.EditIndex = -1;
            FillgvTrnDetailsAfterSave(txtTrnNo.Text.ToString());
            btnUpdate.Enabled = true;
            btnAuthorize.Enabled = true;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvTrnDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvTrnDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtEmployeeNumber = (TextBox)gvTrnDetails.FooterRow.FindControl("txtEmployeeNumber");
        Label lblFtrEmpName = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrEmpName");
        Label lblFtrEmpDesg = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrEmpDesg");
        TextBox txtConductedBy = (TextBox)gvTrnDetails.FooterRow.FindControl("txtConductedBy");
        Label lblFtrCondByName = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByName");
        Label lblFtrCondByDesg = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByDesg");
        TextBox txtAreasCovered = (TextBox)gvTrnDetails.FooterRow.FindControl("txtAreasCovered");
        TextBox txtTraingDate = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTraingDate");
        TextBox txtTimeFrom = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeFrom");
        TextBox txtTimeTo = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeTo");
        TextBox txtHrs = (TextBox)gvTrnDetails.FooterRow.FindControl("txtHrs");
        TextBox txtftrRemarks = (TextBox)gvTrnDetails.FooterRow.FindControl("txtftrRemarks");
        if (status == 1)
        {
            int flag = 1;

            if (e.CommandName.Equals("AddNew"))
            {

                if (txtTraingDate.Text != "")
                {
                    if (txtTimeFrom.Text != "" && txtTimeTo.Text != "")
                    {
                        if (txtHrs.Text != "")
                        {
                            if (dtTempTrnDetails.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtTempTrnDetails.Rows.Count; i++)
                                {
                                    if (txtEmployeeNumber.Text.Trim() == dtTempTrnDetails.Rows[i][0].ToString())
                                    {
                                        DisplayMessageString(lblErrorMsg, "Record already exists");
                                        flag = 0;
                                        break;

                                    }
                                    else
                                    {
                                        flag = 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            DisplayMessageString(lblErrorMsg, "Please Fill Training Timings");
                            ToolkitScriptManager1.SetFocus("txtTimeFrom");
                            flag = 0;
                            return;
                        }
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, "Please Fill Training Timings");
                        ToolkitScriptManager1.SetFocus("txtTimeFrom");
                        flag = 0;
                        return;
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, "Please Fill Training Date");
                    ToolkitScriptManager1.SetFocus("txtTraingDate");
                    flag = 0;
                    return;
                }
                if (flag == 1)
                {
                    if (txtTrnDate.Text != "")
                    {
                        if (DateTime.Parse(txtTraingDate.Text) < DateTime.Parse(txtTrnDate.Text))
                        {
                            lblErrorMsg.Text = "Actual Training Date Should be greter than or equal to Training Date";
                            ToolkitScriptManager1.SetFocus("txtTraingDate");
                            return;
                        }
                        else
                        {
                            DataRow dr = dtTempTrnDetails.NewRow();
                            dr[0] = txtEmployeeNumber.Text;
                            dr[1] = lblFtrEmpName.Text;
                            dr[2] = lblFtrEmpDesg.Text;
                            dr[3] = txtConductedBy.Text;
                            dr[4] = lblFtrCondByName.Text;
                            dr[5] = lblFtrCondByDesg.Text;
                            dr[6] = txtAreasCovered.Text;
                            dr[7] = DateTime.Parse(txtTraingDate.Text);
                            dr[8] = DateTime.Parse(txtTimeFrom.Text).ToShortTimeString();
                            dr[9] = DateTime.Parse(txtTimeTo.Text).ToShortTimeString();
                            dr[10] = txtHrs.Text.ToString();
                            dr[11] = txtftrRemarks.Text;
                            gvTrnDetails.DataKeyNames = new string[] { "EmployeeNumber" };
                            dtTempTrnDetails.Rows.Add(dr);
                            gvTrnDetails.DataSource = dtTempTrnDetails;
                            gvTrnDetails.DataBind();




                            if (IsWriteAccess == true)
                            {
                                gvTrnDetails.FooterRow.Visible = true;
                            }

                        }
                    }
                }
            }
        }
        else if (status == 0)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                if (txtTraingDate.Text != "")
                {
                    if (txtTimeFrom.Text != "" && txtTimeTo.Text != "")
                    {
                        if (txtHrs.Text != "")
                        {
                            if (DateTime.Parse(txtTraingDate.Text) < DateTime.Parse(txtTrnDate.Text))
                            {
                                lblErrorMsg.Text = "Actual Training Date Should be greter than or equal to Training Date";
                                ToolkitScriptManager1.SetFocus("txtTraingDate");
                                return;
                            }
                            else
                            {
                                DataSet ds = new DataSet();
                                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                                ds = objOperationManagement.TrainingDetailsInsert(txtTrnNo.Text, txtEmployeeNumber.Text, txtConductedBy.Text, txtAreasCovered.Text, DateTime.Parse(txtTraingDate.Text), DateTime.Parse(txtTimeFrom.Text), DateTime.Parse(txtTimeTo.Text), txtHrs.Text, txtftrRemarks.Text, BaseUserID);
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                FillgvTrnDetailsAfterSave(txtTrnNo.Text.ToString());
                                ToolkitScriptManager1.SetFocus("txtEmployeeNumber");

                            }
                        }
                        else
                        {
                            DisplayMessageString(lblErrorMsg, "Training Hrs can't be left blank");
                            ToolkitScriptManager1.SetFocus("txtTimeFrom");
                            return;
                        }
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, "Please Fill Training Timings");
                        ToolkitScriptManager1.SetFocus("txtTimeFrom");
                        return;
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, "Please Fill Training Date");
                    ToolkitScriptManager1.SetFocus("txtTraingDate");
                    return;
                }
            }
        }

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvTrnDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvTrnDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrnDetails.PageIndex = e.NewPageIndex;
        gvTrnDetails.EditIndex = -1;
        FillgvTrnDetailsAfterSave(txtTrnNo.Text);
    }
    #endregion

    #region Function Related to Button's

    /// <summary>
    /// Hides the button based on status.
    /// </summary>
    protected void HideButtonBasedOnStatus()
    {
        if (lblTrnStatus.Text == Resources.Resource.Fresh)
        {
            if (IsWriteAccess == true)
            {
                btnAddNew.Visible = true;
            }
            if (IsAuthorizationAccess == true)
            {
                btnAuthorize.Visible = true;
            }
            else
            {
                btnAuthorize.Visible = false;
            }
            btnEdit.Visible = false;
            if (IsModifyAccess == true)
            {
                btnUpdate.Visible = true;
            }
            btnSave.Visible = false;
            EnableFields();
            if (IsModifyAccess == true)
            {
                gvTrnDetails.Columns[0].Visible = true;
            }
            if (IsWriteAccess == true)
            {
                gvTrnDetails.FooterRow.Visible = true;
            }
        }
        if (lblTrnStatus.Text == Resources.Resource.Amend)
        {
            if (IsModifyAccess == true)
            {
                gvTrnDetails.Columns[0].Visible = true;
                btnUpdate.Visible = true;
            }
            if (IsWriteAccess == true)
            {
                gvTrnDetails.FooterRow.Visible = true;
                btnAddNew.Visible = true;
            }
            if (IsAuthorizationAccess == true)
            {
                btnAuthorize.Visible = true;
            }
            else
            {
                btnAuthorize.Visible = false;
            }
            btnEdit.Visible = false;
            btnSave.Visible = false;
            EnableFields();
        }
        if (lblTrnStatus.Text == Resources.Resource.Authorized)
        {
            if (IsModifyAccess == true)
            {
                btnEdit.Visible = true;
            }
            if (IsWriteAccess == true)
            {
                btnAddNew.Visible = true;
            }
            btnUpdate.Visible = false;
            btnAuthorize.Visible = false;
            btnSave.Visible = false;
            DisableFields();
        }
        if (lblTrnStatus.Text == "")
        {
            if (IsWriteAccess == true)
            {
                btnSave.Visible = true;
            }
            btnAddNew.Visible = false;
            btnUpdate.Visible = false;
            btnAuthorize.Visible = false;
            btnEdit.Visible = false;
            EnableFields();
        }
    }

    /// <summary>
    /// Enables the fields.
    /// </summary>
    protected void EnableFields()
    {
        ddlTrainingType.Enabled = true;
        txtTrnDate.Enabled = true;
        txtAssignNo.Enabled = true;
        //IMGDate.Enabled = true; 
    }

    /// <summary>
    /// Disables the fields.
    /// </summary>
    protected void DisableFields()
    {
        ddlTrainingType.Enabled = false;
        txtTrnDate.Enabled = false;
        txtAssignNo.Enabled = false;
        //IMGDate.Enabled = false; 
    }

    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        TextBox txtEmployeeNumber = (TextBox)gvTrnDetails.FooterRow.FindControl("txtEmployeeNumber");
        Label lblFtrEmpName = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrEmpName");
        Label lblFtrEmpDesg = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrEmpDesg");
        TextBox txtConductedBy = (TextBox)gvTrnDetails.FooterRow.FindControl("txtConductedBy");
        Label lblFtrCondByName = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByName");
        Label lblFtrCondByDesg = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByDesg");
        TextBox txtAreasCovered = (TextBox)gvTrnDetails.FooterRow.FindControl("txtAreasCovered");
        TextBox txtTraingDate = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTraingDate");
        TextBox txtTimeFrom = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeFrom");
        TextBox txtTimeTo = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeTo");
        TextBox txtHrs = (TextBox)gvTrnDetails.FooterRow.FindControl("txtHrs");
        TextBox txtftrRemarks = (TextBox)gvTrnDetails.FooterRow.FindControl("txtftrRemarks");
        txtEmployeeNumber.Text = "";
        lblFtrEmpDesg.Text = "";
        lblFtrEmpName.Text = "";
        txtConductedBy.Text = "";
        lblFtrCondByDesg.Text = "";
        lblFtrCondByName.Text = "";
        txtAreasCovered.Text = "";
        txtTraingDate.Text = "";
        txtTimeFrom.Text = "";
        txtTimeTo.Text = "";
        txtHrs.Text = "";
        txtftrRemarks.Text = "";
        hfAsmtStartDate.Value = "";
    }

    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        hfAsmtStartDate.Value = "";
        status = 1;
        ClearFields();
        btnSave.Visible = true;
        dtTempTrnDetails.Clear();
        lblTrnStatus.Text = "";
        ddlTrainingType.SelectedIndex = 0;
        txtAssignNo.Text = "";
        //FillAsmtDetails();
        FillgvTrnDetails();
        gvTrnDetails.Columns[0].Visible = true;
        gvTrnDetails.FooterRow.Visible = true;
        EnableFields();
        HideButtonBasedOnStatus();
        txtTrnDate.Text = DateFormat(DateTime.Now).ToString();
        if (dtTempTrnDetails.Columns.Contains("EmployeeNumber") == false)
        {
            MakeTempTrnDetail();
        }
        else
        {
            dtTempTrnDetails.Clear();
        }
    }

    /// <summary>
    /// Clears the fields.
    /// </summary>
    protected void ClearFields()
    {
        txtTrnNo.Text = "";
        txtAssignNo.Text = "";
        txtTrnDate.Text = "";
        lblTrnStatus.Text = "";
        //txtAreaID.Text = "";
        //txtAreaDesc.Text = "";
        txtBranchID.Text = "";
        txtBranchIDDesc.Text = "";
        txtCustomerID.Text = "";
        txtCustomerDesc.Text = "";
        //txtAddressID.Text = "";
        //txtAddressDesc.Text = "";
        //txtAsgnStartDate.Text = ""; 
        txtDefaultConductedBy.Text = "";
        txtDefaultRemarks.Text = "";
        txtDefaultTargetHrs.Text = "";
        txtDefaultTimeFrom.Text = "";
        txtDefaultTimeTo.Text = "";
        txtAreaToBeCovered.Text = "";
        txtActualTrainingDate.Text = "";
        lblDefaultConductedByDesg.Text = "";
        lblDefaultConductedByName.Text = "";
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        int flag = 1;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (dtTempTrnDetails.Rows.Count == 0)
        {
            lblErrorMsg.Text = "Training Details Cannot be left blank";
            flag = 0;
        }

        //if (txtTrnDate.Text != "")
        //{
        //    if (DateTime.Parse(txtTrnDate.Text) <= DateTime.Now && DateTime.Parse(txtTrnDate.Text) >= DateTime.Parse(txtAsgnStartDate.Text ))
        //    {
        //        flag = 0;
        //        txtTrnDate.BackColor = System.Drawing.Color.Empty;
        //    }
        //    else
        //    {
        //        lblErrorMsg.Text = "Training Date should be between Assignment start date and current Date";
        //        ToolkitScriptManager1.SetFocus("txtTrnDate");
        //        txtTrnDate.BackColor = System.Drawing.Color.Aqua;
        //        return;
        //    }
        //}
        if (flag == 1)
        {
            if (CheckActualTrainingDate())
            {
                if (DateTime.Parse(hfAsmtStartDate.Value) <= DateTime.Parse(txtTrnDate.Text))
                {
                    ds = objOperationManagement.TrainingDetailInsert(BaseLocationAutoID, ddlTrainingType.SelectedValue.ToString(), DateTime.Parse(txtTrnDate.Text), txtAssignNo.Text.ToString(), dtTempTrnDetails, Resources.Resource.Fresh, BaseUserID);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                    {
                        txtTrnNo.Text = ds.Tables[0].Rows[0]["Training_no"].ToString();
                        lblTrnStatus.Text = Resources.Resource.Fresh;
                        gvTrnDetails.Columns[0].Visible = false;
                        gvTrnDetails.FooterRow.Visible = false;
                        HideButtonBasedOnStatus();
                        status = 0;
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Training Date Should always be greater than assignment start Date";
                }
            }

        }
    }
    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (gvTrnDetails.Rows.Count > 0)
        {
            ds = objOperationManagement.TrainingAuthorize(strStatusAuthorized, txtTrnNo.Text.ToString(), BaseLocationAutoID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                txtTrnNo_OnTextChanged(sender, e);
                FillgvTrnDetailsAfterSave(txtTrnNo.Text);
                HideButtonBasedOnStatus();
                DisableFields();
                gvTrnDetails.Columns[0].Visible = false;
                gvTrnDetails.FooterRow.Visible = false;
            }
        }
        else
        {
            lblErrorMsg.Text = "Award Deatils Can't be blank";
        }

    }

    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.TrainingAuthorize(strStatusAmend, txtTrnNo.Text.ToString(), BaseLocationAutoID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
        {

            txtTrnNo_OnTextChanged(sender, e);
            HideButtonBasedOnStatus();
            EnableFields();
            if (IsModifyAccess == true)
            {
                gvTrnDetails.Columns[0].Visible = true;
            }
            if (IsWriteAccess == true)
            {
                gvTrnDetails.FooterRow.Visible = true;
            }
        }

    }

    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        if (CheckActualTrainingDate())
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            ds = objOperationManagement.TrainingUpdate(BaseLocationAutoID, txtTrnNo.Text, ddlTrainingType.SelectedValue.ToString(), DateTime.Parse(txtTrnDate.Text), txtAssignNo.Text, BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                FillgvTrnDetailsAfterSave(txtTrnNo.Text);
                HideButtonBasedOnStatus();
                EnableFields();
                if (IsModifyAccess == true)
                {
                    gvTrnDetails.Columns[0].Visible = true;
                }
                if (IsWriteAccess == true)
                {
                    gvTrnDetails.FooterRow.Visible = true;
                }
            }
        }
    }

    /// <summary>
    /// Checks the actual training date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckActualTrainingDate()
    {
        int flag = 0;
        for (int i = 0; i < gvTrnDetails.Rows.Count; i++)
        {
            Label lblTrainingDate = (Label)gvTrnDetails.Rows[i].FindControl("lblTrainingDate");
            if (DateTime.Parse(lblTrainingDate.Text) < DateTime.Parse(txtTrnDate.Text))
            {
                lblErrorMsg.Text = "Actual Training Date Should be greter than or equal to Training Date";
                gvTrnDetails.Rows[i].BackColor = System.Drawing.Color.Aqua;
                flag = 0;
                break;
            }
            else
            {
                gvTrnDetails.Rows[i].BackColor = System.Drawing.Color.Empty;
                flag = 1;
            }
        }
        if (flag == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    /// <summary>
    /// Handles the TextChanged event of the txtActualTrainingDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtActualTrainingDate_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");

        ToolkitScriptManager1.SetFocus(txtDefaultTimeFrom);
        TextBox txtTraingDate = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTraingDate");
        txtTraingDate.Text = txtActualTrainingDate.Text;
        ConvertStringToDateFormat(txtActualTrainingDate,lblErrorMsg );
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDefaultTimeFrom control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDefaultTimeFrom_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtTimeFrom = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeFrom");
        TextBox txtTimeTo = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeTo");
        TextBox txtHrs = (TextBox)gvTrnDetails.FooterRow.FindControl("txtHrs");
        TextBox txtftrRemarks = (TextBox)gvTrnDetails.FooterRow.FindControl("txtftrRemarks");
        TextBox txtAreasCovered = (TextBox)gvTrnDetails.FooterRow.FindControl("txtAreasCovered");
        TextBox txtTraingDate = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTraingDate");
        if (txtDefaultTimeFrom.Text != "__:__" && txtDefaultTimeTo.Text != "__:__")
        {
            if (!ValidateTime(txtDefaultTimeFrom, txtDefaultTimeTo, txtDefaultTargetHrs, txtDefaultRemarks))
            {
                txtDefaultTargetHrs.Text = "";
                txtDefaultTimeFrom.Text = "";

                lblErrorMsg.Text = "To Time should be greater than From Time";
                ToolkitScriptManager1.SetFocus("txtDefaultTimeFrom");
            }
            else
            {

                txtTimeFrom.Text = txtDefaultTimeFrom.Text;
                txtTimeTo.Text = txtDefaultTimeTo.Text;
                txtHrs.Text = txtDefaultTargetHrs.Text;
                txtftrRemarks.Text = txtDefaultRemarks.Text;
                txtAreasCovered.Text = txtAreaToBeCovered.Text;
                txtTraingDate.Text = txtActualTrainingDate.Text;
                ToolkitScriptManager1.SetFocus("txtDefaultTimeTo");
            }
        }
        else
        {
            ToolkitScriptManager1.SetFocus("txtDefaultTimeTo");
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDefaultTimeTo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDefaultTimeTo_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtTimeFrom = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeFrom");
        TextBox txtTimeTo = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeTo");
        TextBox txtHrs = (TextBox)gvTrnDetails.FooterRow.FindControl("txtHrs");
        TextBox txtftrRemarks = (TextBox)gvTrnDetails.FooterRow.FindControl("txtftrRemarks");
        TextBox txtAreasCovered = (TextBox)gvTrnDetails.FooterRow.FindControl("txtAreasCovered");
        TextBox txtTraingDate = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTraingDate");

        if (txtDefaultTimeFrom.Text != "__:__" && txtDefaultTimeTo.Text != "__:__")
        {
            if (!ValidateTime(txtDefaultTimeFrom, txtDefaultTimeTo, txtDefaultTargetHrs, txtDefaultRemarks))
            {
                txtDefaultTargetHrs.Text = "";
                txtDefaultTimeFrom.Text = "";

                lblErrorMsg.Text = "To Time should be greater than From Time";
                ToolkitScriptManager1.SetFocus("txtDefaultTimeFrom");
            }
            else
            {

                txtTimeFrom.Text = txtDefaultTimeFrom.Text;
                txtTimeTo.Text = txtDefaultTimeTo.Text;
                txtHrs.Text = txtDefaultTargetHrs.Text;
                txtftrRemarks.Text = txtDefaultRemarks.Text;
                txtAreasCovered.Text = txtAreaToBeCovered.Text;
                txtTraingDate.Text = txtActualTrainingDate.Text;
                ToolkitScriptManager1.SetFocus("txtDefaultRemarks");
            }
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDefaultRemarks control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDefaultRemarks_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtTimeFrom = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeFrom");
        TextBox txtTimeTo = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTimeTo");
        TextBox txtHrs = (TextBox)gvTrnDetails.FooterRow.FindControl("txtHrs");
        TextBox txtftrRemarks = (TextBox)gvTrnDetails.FooterRow.FindControl("txtftrRemarks");
        TextBox txtAreasCovered = (TextBox)gvTrnDetails.FooterRow.FindControl("txtAreasCovered");
        TextBox txtTraingDate = (TextBox)gvTrnDetails.FooterRow.FindControl("txtTraingDate");


        if (txtDefaultTimeFrom.Text != "__:__" && txtDefaultTimeTo.Text != "__:__")
        {
            if (!ValidateTime(txtDefaultTimeFrom, txtDefaultTimeTo, txtDefaultTargetHrs, txtDefaultRemarks))
            {
                txtDefaultTargetHrs.Text = "";
                txtDefaultTimeFrom.Text = "";

                lblErrorMsg.Text = "To Time should be greater than From Time";
                ToolkitScriptManager1.SetFocus("txtDefaultTimeFrom");
            }
            else
            {
                ToolkitScriptManager1.SetFocus("txtDefaultTimeTo");
                txtTimeFrom.Text = txtDefaultTimeFrom.Text;
                txtTimeTo.Text = txtDefaultTimeTo.Text;
                txtHrs.Text = txtDefaultTargetHrs.Text;
                txtftrRemarks.Text = txtDefaultRemarks.Text;
                txtAreasCovered.Text = txtAreaToBeCovered.Text;
                txtTraingDate.Text = txtActualTrainingDate.Text;
            }
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtAreaToBeCovered control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAreaToBeCovered_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtAreasCovered = (TextBox)gvTrnDetails.FooterRow.FindControl("txtAreasCovered");
        txtAreasCovered.Text = txtAreaToBeCovered.Text;
        ToolkitScriptManager1.SetFocus(txtActualTrainingDate);
    }

    /// <summary>
    /// Handles the onTextChanged event of the txtDefaultConductedBy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDefaultConductedBy_onTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        Label lblFtrCondByName = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByName");
        Label lblFtrCondByDesg = (Label)gvTrnDetails.FooterRow.FindControl("lblFtrCondByDesg");
        TextBox txtConductedBy = (TextBox)gvTrnDetails.FooterRow.FindControl("txtConductedBy");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtDefaultConductedBy.Text.ToString(), BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            lblDefaultConductedByName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            lblDefaultConductedByDesg.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            txtConductedBy.Text = txtDefaultConductedBy.Text;
            lblFtrCondByName.Text = lblDefaultConductedByName.Text;
            lblFtrCondByDesg.Text = lblDefaultConductedByDesg.Text;
            ToolkitScriptManager1.SetFocus(txtAreaToBeCovered);
        }
        else
        {
            DisplayMessageString(lblGridError, Resources.Resource.InvalidEmpCode);
            txtDefaultConductedBy.Text = "";
            ToolkitScriptManager1.SetFocus("txtDefaultConductedBy");
        }
    }
}
