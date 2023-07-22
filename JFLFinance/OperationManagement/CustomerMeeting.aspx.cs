// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CustomerMeeting.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class OperationManagement_CustomerMeeting.
/// </summary>
public partial class OperationManagement_CustomerMeeting : BasePage//System.Web.UI.Page
{
    // Clear Commented Unused Code, 3Line Code Comment for Every Function & Format Code Intended by  on 2-Aug-2013
    #region Static Variable Declaration
    /// <summary>
    /// The dt g4 s representative
    /// </summary>
    static DataTable dtOurRepresentative = new DataTable();
    /// <summary>
    /// The dt client meeting
    /// </summary>
    static DataTable dtClientMeeting = new DataTable();
    /// <summary>
    /// The status
    /// </summary>
    static int Status;
    /// <summary>
    /// The flag edit
    /// </summary>
    bool flagEdit = false;
    /// <summary>
    /// The incident no
    /// </summary>
    public string incidentNo = null;
    #endregion

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

    #region Function Related to Page Load
    /// <summary>
    /// Function call on Page Load
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
            javaScript.Append("PageTitle('" + Resources.Resource.CustomerMeeting + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                Status = 1;
                FillClientId();             //Added by  on 29-May-2013
                dtOurRepresentative.Clear();
                dtClientMeeting.Clear();
                FillgvOurRepresentative();
                FillgvClientMeetingDetail();
                FillddlMeetingType();
                FillddlContext();
                if (IsWriteAccess == true)
                {
                    btnSave.Visible = true;
                    btnAddNew.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                    btnAddNew.Visible = false;
                }
                btnSave.Enabled = false;
                btnEdit.Visible = false;
                if (dtOurRepresentative.Columns.Contains("G4S_representative") == false)
                {
                    MakeTempOurRepresentativeDataTable();
                }
                else
                {
                    dtOurRepresentative.Clear();
                }
                if (dtClientMeeting.Columns.Contains("Observation_Type") == false)
                {
                    MakeTempClientMeetingDetail();
                }
                else
                {
                    dtClientMeeting.Clear();
                }
                IMGMeetingNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=MeetingCCh&ControlId=" + txtMeetingNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Create Temporary Client Meeting Datatable
    /// <summary>
    /// Function Call to create a temp table for ClientMeetingDetail grid
    /// </summary>
    private void MakeTempClientMeetingDetail()
    {
        DataColumn dCol1 = new DataColumn("Observation_Type", typeof(System.String));
        DataColumn dCol2 = new DataColumn("Observation", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Corrective_Measures", typeof(System.String));
        DataColumn dcol4 = new DataColumn("Promised_Date", typeof(System.DateTime));
        DataColumn dcol5 = new DataColumn("Action_Planned", typeof(System.String));
        DataColumn dcol6 = new DataColumn("Responsibility", typeof(System.String));
        DataColumn dcol7 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol8 = new DataColumn("Designation", typeof(System.String));
        DataColumn dcol9 = new DataColumn("Action_Date", typeof(System.String));
        DataColumn dcol10 = new DataColumn("Remarks", typeof(System.String));
        DataColumn dcol11 = new DataColumn("TempObservation_Type", typeof(System.String));
        DataColumn dcol12 = new DataColumn("RowID", typeof(System.Int32));
        dtClientMeeting.Columns.Add(dCol1);
        dtClientMeeting.Columns.Add(dCol2);
        dtClientMeeting.Columns.Add(dcol3);
        dtClientMeeting.Columns.Add(dcol4);
        dtClientMeeting.Columns.Add(dcol5);
        dtClientMeeting.Columns.Add(dcol6);
        dtClientMeeting.Columns.Add(dcol7);
        dtClientMeeting.Columns.Add(dcol8);
        dtClientMeeting.Columns.Add(dcol9);
        dtClientMeeting.Columns.Add(dcol10);
        dtClientMeeting.Columns.Add(dcol11);
        dtClientMeeting.Columns.Add(dcol12);
    }
    #endregion

    #region Create Temporary G4S Representative Datatable
    /// <summary>
    /// Function call to create a temp table OurRepresentative Grid
    /// </summary>
    private void MakeTempOurRepresentativeDataTable()
    {
        DataColumn dCol1 = new DataColumn("G4S_representative", typeof(System.String));
        DataColumn dCol2 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Designation", typeof(System.String));
        dtOurRepresentative.Columns.Add(dCol1);
        dtOurRepresentative.Columns.Add(dCol2);
        dtOurRepresentative.Columns.Add(dcol3);
    }
    #endregion

    #region To fill ddl context
    /// <summary>
    /// Function call to fill Dropdownlist ddlContext
    /// </summary>
    private void FillddlContext()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlContext.DataSource = objOperationManagement.MeetingContextGetAll(BaseCompanyCode);
        ddlContext.DataTextField = "ItemDesc";
        ddlContext.DataValueField = "ItemCode";
        ddlContext.DataBind();
        if (ddlContext.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData;
            li.Value = "0";
            ddlContext.Items.Add(li);
        }
    }
    #endregion

    #region To fill ddl Meeting Type
    /// <summary>
    /// Function Call to fill Dropdownlist ddlMeetingType
    /// </summary>
    private void FillddlMeetingType()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlMeetingType.DataSource = objOperationManagement.MeetingTypeGetAll(BaseCompanyCode);
        ddlMeetingType.DataTextField = "ItemDesc";
        ddlMeetingType.DataValueField = "ItemCode";
        ddlMeetingType.DataBind();
        EnableButton();
        if (ddlMeetingType.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData;
            li.Value = "0";
            ddlMeetingType.Items.Add(li);
            DisableButton();
        }
    }
    #endregion

    #region Fill GridView[gvClientMeetingDetail,FillgvOurRepresentative] Functions
    /// <summary>
    /// Function call to fill grid gvClientMeetingDetail
    /// </summary>
    private void FillgvClientMeetingDetail()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("Observation_Type", typeof(System.String));
        DataColumn dCol2 = new DataColumn("Observation", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Corrective_Measures", typeof(System.String));
        DataColumn dcol4 = new DataColumn("Promised_Date", typeof(System.DateTime));
        DataColumn dcol5 = new DataColumn("Action_Planned", typeof(System.String));
        DataColumn dcol6 = new DataColumn("Responsibility", typeof(System.String));
        DataColumn dcol7 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol8 = new DataColumn("Designation", typeof(System.String));
        DataColumn dcol9 = new DataColumn("Action_Date", typeof(System.String));
        DataColumn dcol10 = new DataColumn("Remarks", typeof(System.String));
        DataColumn dcol11 = new DataColumn("TempObservation_Type", typeof(System.String));
        DataColumn dcol12 = new DataColumn("RowID", typeof(System.Int32));
        dt.Columns.Add(dCol1);
        dt.Columns.Add(dCol2);
        dt.Columns.Add(dcol3);
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
        gvClientMeetingDetail.DataSource = dt;
        gvClientMeetingDetail.DataBind();

        if (dtflag == 0)//to fix empty gridview
        {
            gvClientMeetingDetail.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Function call to fill grid gvOurRepresentative
    /// </summary>
    private void FillgvOurRepresentative()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("G4S_representative", typeof(System.String));
        DataColumn dCol2 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Designation", typeof(System.String));
        dt.Columns.Add(dCol1);
        dt.Columns.Add(dCol2);
        dt.Columns.Add(dcol3);
        int dtflag;
        dtflag = 1;
        //to fix empty gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvOurRepresentative.DataSource = dt;
        gvOurRepresentative.DataBind();

        if (dtflag == 0)//to fix empty gridview
        {
            gvOurRepresentative.Rows[0].Visible = false;
        }

    }
    #endregion

    #region TO Fill gvClientMeetingDetail Grid view after save button is clicked
    /// <summary>
    /// Function call to fill Grid gvClientMeetingDetail after Save records
    /// </summary>
    /// <param name="strMeetingNumber">The string meeting number.</param>
    private void FillgvClientMeetingDetailAfterSave(string strMeetingNumber)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dtClient = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objOperationManagement.ClientMeetingDetailGetAll(strMeetingNumber, BaseCompanyCode);
        try
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                dtClient = ds.Tables[0];

                //to fix empety gridview
                if (dtClient.Rows.Count == 0)
                {
                    dtflag = 0;
                    dtClient.Rows.Add(dtClient.NewRow());
                }
                gvClientMeetingDetail.DataSource = dtClient;
                gvClientMeetingDetail.DataBind();

                if (dtflag == 0)//to fix empety gridview
                {
                    gvClientMeetingDetail.Rows[0].Visible = false;
                    gvClientMeetingDetail.Enabled = false;
                }
            }
        }
        catch (Exception)
        {
            CreateEmptyDataTable();
        }

    }
    #endregion

    #region TO Fill gvOurRepresentative Grid view after save button is clicked
    /// <summary>
    /// Function call to fill Grid OurRepresentative after save record
    /// </summary>
    /// <param name="strMeetingNumber">The string meeting number.</param>
    private void FillgvOurRepresentativeAfterSave(string strMeetingNumber)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objOperationManagement.CompanyRepresentativeGetAll(strMeetingNumber, BaseCompanyCode);
        try
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

                //to fix empety gridview
                if (dt.Rows.Count == 0)
                {
                    dtflag = 0;
                    dt.Rows.Add(dt.NewRow());
                }
                gvOurRepresentative.DataSource = dt;
                gvOurRepresentative.DataBind();

                if (dtflag == 0)//to fix empety gridview
                {
                    gvOurRepresentative.Rows[0].Visible = false;
                    gvOurRepresentative.Enabled = false;
                }
            }
            else
            {
                if (dtOurRepresentative.Rows.Count == 0)
                {
                    dtOurRepresentative.Rows.Add(dtOurRepresentative.NewRow());
                }
                gvOurRepresentative.DataSource = dtOurRepresentative;
                gvOurRepresentative.DataBind();
                gvOurRepresentative.Rows[0].Visible = false;

            }
        }
        catch (Exception)
        {

        }
    }
    #endregion

    #region to fill Assignment Details
    /// <summary>
    /// Function call to Fill Assignment Details
    /// </summary>
    private void FillAsmtDetails()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        //Modify AsmtIncidentDetailGet Function by  on 20-May-2013
        ds = objOperationManagement.AsmtIncidentDetailGet(ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                HideButtons();
                EnableFields();
                EnableButton();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                hfAsmtStartDate.Value = ds.Tables[0].Rows[0]["AsmtStartDate"].ToString();
                btnEdit.Visible = false;
                btnSave.Visible = true;
                ToolkitScriptManager2.SetFocus(txtCustomerRepresentative);
                btnSave.Enabled = true;            //Added by  on 2-Jun-2013
                ddlContext.Enabled = true;          //Added Code by  on 1-Aug-2013
            }
            else
            {
                DisableFields();
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                DisableButton();
                btnSave.Enabled = false;            //Added by  on 2-Jun-2013
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            dtClientMeeting.Clear();
            dtOurRepresentative.Clear();
            DisableButton();
            btnSave.Enabled = false;            //Added by  on 2-Jun-2013
        }
    }
    #endregion

    #region functiion to fill other details
    /// <summary>
    /////Modify By  on 21-May-2013 Function call to fill Meeting Details
    /// </summary>
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.MeetingDetailGet(txtMeetingNo.Text, BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtMeetingDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["MeetingDate"].ToString()).ToString("d-MMM-yyyy");
            txtCustomerRepresentative.Text = ds.Tables[0].Rows[0]["CustomerRepersentative"].ToString();

            txtInfoDetail.Text = ds.Tables[0].Rows[0]["InformationDetails"].ToString();
            txtOnDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["InformationDate"].ToString()).ToString("d-MMM-yyyy");
            ddlContext.SelectedValue = ds.Tables[0].Rows[0]["ContextOfMeeting"].ToString();
            ddlMeetingType.SelectedValue = ds.Tables[0].Rows[0]["MeetingType"].ToString();
            lblMeetingStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();

            //Added by  on 29-May-2013
            string clientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();
            SetClientId(clientCode);
            string asmtId = ds.Tables[0].Rows[0]["AsmtId"].ToString();
            SetAsmt(asmtId);
            ddlClientId.Enabled = false;
            ddlAsmtId.Enabled = false;
            //Modify Code for DropDown IncidentNo by  on 31-July-2013
            incidentNo = ds.Tables[0].Rows[0]["IncidentNo"].ToString();
            //End
            //Added Code for New Changes NextMeeting Details by  on 28-Jun-2013
            txtMOM.Text = ds.Tables[0].Rows[0]["MinutesOfMeeting"].ToString();
            txtNextActionPlan.Text = ds.Tables[0].Rows[0]["NextActionPlan"].ToString();
            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["NextMeetingDate"].ToString()))
            {
                txtNextMeetingDate.Text = "";
            }
            else
            {
                txtNextMeetingDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["NextMeetingDate"].ToString()).ToString("d-MMM-yyyy");
            }
        }
    }
    #endregion

    #region Function to fill Employee Details
    /// <summary>
    /// Function call to fill Employee Details
    /// </summary>
    /// <param name="row">The row.</param>
    /// <param name="lblName">Name of the label.</param>
    /// <param name="lblDesignation">The label designation.</param>
    /// <param name="txtEmployeeID">The text employee identifier.</param>
    /// <param name="IMGButton">The img button.</param>
    private void FilltxtEmployeeDetail(GridViewRow row, Label lblName, Label lblDesignation, TextBox txtEmployeeID, ImageButton IMGButton)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeID.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                IMGButton.Visible = true;
                lblName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                lblDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
                txtEmployeeID.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                ToolkitScriptManager2.SetFocus(txtEmployeeID);
                txtEmployeeID.BackColor = System.Drawing.Color.Aqua;
                IMGButton.Visible = false;
                lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
                lblName.Text = "";
                lblDesignation.Text = "";
            }
        }
        else
        {
            ToolkitScriptManager2.SetFocus(txtEmployeeID);
            txtEmployeeID.BackColor = System.Drawing.Color.Aqua;
            IMGButton.Visible = false;
            lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
            lblName.Text = "";
            lblDesignation.Text = "";
        }
    }
    #endregion

    #region function related to Text Change Events
    /// <summary>
    /// Function call on Text NewOurRepresentative get Change
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewOurRepresentative_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        Label lblName = (Label)gvOurRepresentative.FooterRow.FindControl("lblNewName");
        Label lblDesignation = (Label)gvOurRepresentative.FooterRow.FindControl("lblNewDesignation");
        TextBox txtEmployeeID = (TextBox)gvOurRepresentative.FooterRow.FindControl("txtNewOurRepresentative");
        ImageButton IMGButton = (ImageButton)gvOurRepresentative.FooterRow.FindControl("lbADD");
        FilltxtEmployeeDetail(row, lblName, lblDesignation, txtEmployeeID, IMGButton);
    }

    /// <summary>
    /// Function call on text AssignNo change
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAssignNo_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        FillAsmtDetails();
        if (txtMeetingDate.Text != "")
        {
            if (hfAsmtStartDate.Value != "")
            {
                if (DateTime.Parse(txtMeetingDate.Text) <= DateTime.Now && DateTime.Parse(txtMeetingDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
                {
                    txtMeetingDate.BackColor = System.Drawing.Color.Empty;

                }
                else
                {
                    lblErrorMsg.Text = "Meeting Date should be between Assignment start date and current Date";
                    ToolkitScriptManager2.SetFocus(txtMeetingDate);
                    txtMeetingDate.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
            }
        }

    }
    /// <summary>
    /// Function call on text OurRepresentative change
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtOurRepresentative_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        Label lblName = (Label)gvOurRepresentative.Rows[row.RowIndex].FindControl("lblName");
        Label lblDesignation = (Label)gvOurRepresentative.Rows[row.RowIndex].FindControl("lblDesignation");
        TextBox txtEmployeeID = (TextBox)gvOurRepresentative.Rows[row.RowIndex].FindControl("txtOurRepresentative");
        ImageButton IMGButton = (ImageButton)gvOurRepresentative.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        FilltxtEmployeeDetail(row, lblName, lblDesignation, txtEmployeeID, IMGButton);
    }
    /// <summary>
    /// Function Call on text Resposibility Change
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtResponsibility_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        Label lblName = (Label)gvClientMeetingDetail.Rows[row.RowIndex].FindControl("lblName");
        Label lblDesignation = (Label)gvClientMeetingDetail.Rows[row.RowIndex].FindControl("lblDesignation");
        TextBox txtEmployeeID = (TextBox)gvClientMeetingDetail.Rows[row.RowIndex].FindControl("txtResponsibility");
        ImageButton IMGButton = (ImageButton)gvClientMeetingDetail.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        FilltxtEmployeeDetail(row, lblName, lblDesignation, txtEmployeeID, IMGButton);
    }
    /// <summary>
    /// Function Call on text NewResposibility Change
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewResponsibility_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        Label lblName = (Label)gvClientMeetingDetail.FooterRow.FindControl("lblNewName");
        Label lblDesignation = (Label)gvClientMeetingDetail.FooterRow.FindControl("lblNewDesignation");
        TextBox txtEmployeeID = (TextBox)gvClientMeetingDetail.FooterRow.FindControl("txtNewResponsibility");
        ImageButton IMGButton = (ImageButton)gvClientMeetingDetail.FooterRow.FindControl("lbADD");
        FilltxtEmployeeDetail(row, lblName, lblDesignation, txtEmployeeID, IMGButton);
    }
    /// <summary>
    /// Function Call on text MeetingNo Change
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtMeetingNo_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (txtMeetingNo.Text != "")
        {
            if (hfAsmtStartDate.Value != "")
            {
                if (DateTime.Parse(txtMeetingDate.Text) <= DateTime.Now && DateTime.Parse(txtMeetingDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
                {
                    txtMeetingDate.BackColor = System.Drawing.Color.Empty;

                }
                else
                {
                    lblErrorMsg.Text = "Meeting Date should be between Assignment start date and current Date";
                    ToolkitScriptManager2.SetFocus(txtMeetingDate);
                    txtMeetingDate.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
            }
            Status = 0;
            BL.OperationManagement obj = new BL.OperationManagement();
            FillDetails();
            FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
            FillgvOurRepresentativeAfterSave(txtMeetingNo.Text);
            //Modify by  on 29-May-2013
            ddlAsmtId_SelectedIndexChanged(sender, e);
            //Added Code By  on 1-Aug-2013
            SetIncidentNo(incidentNo);
            txtInfoDetail.Enabled = false;
            //End
            HideButtons();
            HideButtonBasedOnStatus();
            txtMeetingNo.Enabled = true;
            if (lblMeetingStatus.Text == Resources.Resource.ObservationAuthorized)
            {
                gvClientMeetingDetail.Columns[6].Visible = false;
                gvClientMeetingDetail.Columns[7].Visible = false;
                gvClientMeetingDetail.Columns[8].Visible = false;
                gvClientMeetingDetail.Columns[9].Visible = false;
                gvClientMeetingDetail.Columns[10].Visible = false;
                gvClientMeetingDetail.Columns[11].Visible = false;
                gvClientMeetingDetail.Columns[0].Visible = true;
                gvClientMeetingDetail.FooterRow.Visible = true;
                gvOurRepresentative.Columns[0].Visible = true;
                gvOurRepresentative.FooterRow.Visible = true;

            }
            if (lblMeetingStatus.Text == Resources.Resource.ObservationAuthorized)
            {
                gvClientMeetingDetail.Columns[6].Visible = true;
                gvClientMeetingDetail.Columns[7].Visible = true;
                gvClientMeetingDetail.Columns[8].Visible = true;
                gvClientMeetingDetail.Columns[9].Visible = true;
                DisableFields();
                gvClientMeetingDetail.Columns[0].Visible = false;
                gvClientMeetingDetail.FooterRow.Visible = false;
                gvOurRepresentative.Columns[0].Visible = false;
                gvOurRepresentative.FooterRow.Visible = false;
            }
            else if (lblMeetingStatus.Text == Resources.Resource.PlanAuthorized)
            {
                gvClientMeetingDetail.Columns[6].Visible = true;
                gvClientMeetingDetail.Columns[7].Visible = true;
                gvClientMeetingDetail.Columns[8].Visible = true;
                gvClientMeetingDetail.Columns[9].Visible = true;
                gvClientMeetingDetail.Columns[10].Visible = true;
                gvClientMeetingDetail.Columns[11].Visible = true;
                DisableFields();
                gvClientMeetingDetail.Columns[0].Visible = false;
                gvClientMeetingDetail.FooterRow.Visible = false;
                gvOurRepresentative.Columns[0].Visible = false;
                gvOurRepresentative.FooterRow.Visible = false;
            }
            else if (lblMeetingStatus.Text == Resources.Resource.ActionAuthorized)
            {
                gvClientMeetingDetail.Columns[6].Visible = true;
                gvClientMeetingDetail.Columns[7].Visible = true;
                gvClientMeetingDetail.Columns[8].Visible = true;
                gvClientMeetingDetail.Columns[9].Visible = true;
                gvClientMeetingDetail.Columns[10].Visible = true;
                gvClientMeetingDetail.Columns[11].Visible = true;
                DisableFields();
                gvClientMeetingDetail.Columns[0].Visible = false;
                gvClientMeetingDetail.FooterRow.Visible = false;
                gvOurRepresentative.Columns[0].Visible = false;
                gvOurRepresentative.FooterRow.Visible = false;
                //Added Code For Next Meeting by  on 31-July-2013
                txtMOM.Enabled = false;
                txtMeetingNo.Enabled = false;
            }
        }
    }
    #endregion

    #region GridView[gvOurRepresentative] Events
    /// <summary>
    /// Function Call on Grid gvOurRepresentative Databind
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvOurRepresentative_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvOurRepresentative.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (IBEdit != null)
                {
                    IBEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtOurRepresentative = (TextBox)e.Row.FindControl("txtOurRepresentative");
                ImageButton imgOurRepresentative = (ImageButton)e.Row.FindControl("imgOurRepresentative");
                if (imgOurRepresentative != null)
                {
                    imgOurRepresentative.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtOurRepresentative.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
                }
                if (txtOurRepresentative != null)
                {
                    txtOurRepresentative.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtOurRepresentative.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
            }

            if (IsDeleteAccess == false)
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                }
            }
            else
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvOurRepresentative.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewOurRepresentative = (TextBox)e.Row.FindControl("txtNewOurRepresentative");
                ImageButton imgNewOurRepresentative = (ImageButton)e.Row.FindControl("imgNewOurRepresentative");
                if (imgNewOurRepresentative != null)
                {
                    imgNewOurRepresentative.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtNewOurRepresentative.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                }
                if (txtNewOurRepresentative != null)
                {
                    txtNewOurRepresentative.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewOurRepresentative.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
            }
        }
    }

    /// <summary>
    /// Function Call on Grid gvOurRepresentative RowCommand
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvOurRepresentative_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Label lblNewName = (Label)gvOurRepresentative.FooterRow.FindControl("lblNewName");
        Label lblNewDesignation = (Label)gvOurRepresentative.FooterRow.FindControl("lblNewDesignation");
        TextBox txtNewOurRepresentative = (TextBox)gvOurRepresentative.FooterRow.FindControl("txtNewOurRepresentative");
        if (Status == 1)
        {
            int flag = 1;
            if (e.CommandName.Equals("AddNew"))
            {
                DataRow dr = dtOurRepresentative.NewRow();
                if (txtNewOurRepresentative.Text != "")
                {
                    dr[0] = txtNewOurRepresentative.Text;
                    dr[1] = lblNewName.Text;
                    dr[2] = lblNewDesignation.Text;
                }
                if (dtOurRepresentative.Rows.Count > 0)
                {
                    for (int i = 0; i < dtOurRepresentative.Rows.Count; i++)
                    {
                        if (txtNewOurRepresentative.Text.Trim() == dtOurRepresentative.Rows[i][0].ToString())
                        {
                            lblErrorMsg.Text = "Record already exists";
                            flag = 0;
                            break;
                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                }
                if (flag == 1)
                {
                    dtOurRepresentative.Rows.Add(dr);
                    gvOurRepresentative.DataSource = dtOurRepresentative;
                    gvOurRepresentative.DataBind();
                }
            }
            if (e.CommandName.Equals("Reset"))
            {
                lblNewName.Text = "";
                lblNewDesignation.Text = "";
                txtNewOurRepresentative.Text = "";
            }
        }
        else if (Status == 0)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                DataSet ds = new DataSet();
                ds = objOperationManagement.CompanyRepresentativeInsert(txtMeetingNo.Text, txtNewOurRepresentative.Text, BaseUserID);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                FillgvOurRepresentativeAfterSave(txtMeetingNo.Text);
            }
            if (e.CommandName.Equals("Reset"))
            {
                lblNewName.Text = "";
                lblNewDesignation.Text = "";
                txtNewOurRepresentative.Text = "";
            }
        }
    }

    /// <summary>
    /// Function Call on Grid gvOurRepresentative Row Editing
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvOurRepresentative_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (Status == 1)
        {
            gvOurRepresentative.EditIndex = e.NewEditIndex;
            gvOurRepresentative.DataSource = dtOurRepresentative;
            gvOurRepresentative.DataBind();
        }
        else if (Status == 0)
        {
            gvOurRepresentative.EditIndex = e.NewEditIndex;
            FillgvOurRepresentativeAfterSave(txtMeetingNo.Text);
        }
    }

    /// <summary>
    /// Function Call on Grid gvOurRepresentative Row Cancel Editing
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvOurRepresentative_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (Status == 1)
        {
            gvOurRepresentative.EditIndex = -1;
            gvOurRepresentative.DataSource = dtOurRepresentative;
            gvOurRepresentative.DataBind();
        }
        else if (Status == 0)
        {
            gvOurRepresentative.EditIndex = -1;
            FillgvOurRepresentativeAfterSave(txtMeetingNo.Text);
        }
    }

    /// <summary>
    /// Function Call on Grid gvOurRepresentative Row Deleting
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvOurRepresentative_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblName = (Label)gvOurRepresentative.Rows[e.RowIndex].FindControl("lblName");
        Label lblDesignation = (Label)gvOurRepresentative.Rows[e.RowIndex].FindControl("lblDesignation");
        Label lblOurRepresentative = (Label)gvOurRepresentative.Rows[e.RowIndex].FindControl("lblOurRepresentative");
        if (Status == 1)
        {
            dtOurRepresentative.Rows.RemoveAt(e.RowIndex);
            gvOurRepresentative.DataSource = dtOurRepresentative;
            gvOurRepresentative.DataBind();
            if (dtOurRepresentative.Rows.Count == 0)
            {
                FillgvOurRepresentative();
            }
        }
        else if (Status == 0)
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOperationManagement.CompanyRepresentativeDelete(txtMeetingNo.Text, lblOurRepresentative.Text);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvOurRepresentativeAfterSave(txtMeetingNo.Text);
        }
    }

    /// <summary>
    /// Function Call on Grid gvOurRepresentative Row Updating
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvOurRepresentative_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblName = (Label)gvOurRepresentative.Rows[e.RowIndex].FindControl("lblName");
        Label lblDesignation = (Label)gvOurRepresentative.Rows[e.RowIndex].FindControl("lblDesignation");
        TextBox txtOurRepresentative = (TextBox)gvOurRepresentative.Rows[e.RowIndex].FindControl("txtOurRepresentative");
        Label lblOurRepresentative = (Label)gvOurRepresentative.Rows[e.RowIndex].FindControl("lblOurRepresentative");
        if (Status == 1)
        {
            dtOurRepresentative.Rows[e.RowIndex][0] = txtOurRepresentative.Text;
            dtOurRepresentative.Rows[e.RowIndex][1] = lblName.Text;
            dtOurRepresentative.Rows[e.RowIndex][2] = lblDesignation.Text;
            gvOurRepresentative.EditIndex = -1;
            gvOurRepresentative.DataSource = dtOurRepresentative;
            gvOurRepresentative.DataBind();
        }
        else if (Status == 0)
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOperationManagement.CompanyRepresentativeUpdate(txtMeetingNo.Text, txtOurRepresentative.Text, BaseUserID, lblOurRepresentative.Text);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                gvOurRepresentative.EditIndex = -1;
                FillgvOurRepresentativeAfterSave(txtMeetingNo.Text);
            }
        }
    }
    #endregion

    #region Button Click Events
    /// <summary>
    /// Function call on Add Button
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        dtClientMeeting.Clear();
        dtOurRepresentative.Clear();
        gvClientMeetingDetail.Columns[6].Visible = false;
        gvClientMeetingDetail.Columns[7].Visible = false;
        gvClientMeetingDetail.Columns[8].Visible = false;
        gvClientMeetingDetail.Columns[9].Visible = false;
        gvClientMeetingDetail.Columns[10].Visible = false;
        gvClientMeetingDetail.Columns[11].Visible = false;
        Status = 1;
        ClearFields();
        HideButtons();
        btnSave.Visible = true;
        PanelActionInfoToClient.Visible = true;        //Modify by  on 21-May-2013
        FillgvClientMeetingDetail();
        FillgvOurRepresentative();
        gvClientMeetingDetail.Columns[0].Visible = true;
        gvOurRepresentative.Columns[0].Visible = true;
        EnableFields();
        hfAsmtStartDate.Value = "";
        ddlClientId.Enabled = true;             //Added by  on 29-May-2013
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        int flag = 1;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        
        if (dtOurRepresentative.Rows.Count == 0)
        {
            lblErrorMsg.Text = "Our Representative Details Cannot be left blank";
            flag = 0;
            return;
        }
        if (dtClientMeeting.Rows.Count == 0)
        {
            lblErrorMsg.Text = "Customer Meeting Details Cannot be left blank";
            flag = 0;
            return;
        }
        if (txtMeetingDate.Text != "")
        {
            if (DateTime.Parse(txtMeetingDate.Text) <= DateTime.Now && DateTime.Parse(txtMeetingDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
            {
                flag = 1;
                txtMeetingDate.BackColor = System.Drawing.Color.Empty;

            }
            else
            {
                lblErrorMsg.Text = "Meeting Date should be between Assignment start date and current Date";
                ToolkitScriptManager2.SetFocus(txtMeetingDate);
                txtMeetingDate.BackColor = System.Drawing.Color.Aqua;
                return;
            }
        }
        /*    Added by  on 21-May-2013 */
        if (txtInfoDetail.Text == "")
        {
            lblErrorMsg.Text = "Information Details Cannot be left blank";
            flag = 0;
            return;
        }
        else if (txtOnDate.Text == "")
        {
            lblErrorMsg.Text = "Information Date Cannot be left blank";
            flag = 0;
            return;
        }
        //End

        //  Added new Code for Next Meeting Details by  on 26-Jun-2013
        if (!string.IsNullOrEmpty(txtNextMeetingDate.Text))
        {
            if (DateTime.Parse(txtNextMeetingDate.Text) < DateTime.Parse(txtMeetingDate.Text))
            {
                lblErrorMsg.Text = "Next Meeting Date should be greater than Meeting Date";
                flag = 0;
                return;
            }
        }
        //End
        if (flag == 1)
        {
            Status = 0;
            // Modify Code for New Columns minutesOfMeeting, nextActionPlan & nextMeetingDate by  on 26-Jun-2013 & 31-July-2013 (ddlIncidentNo)
            ds = objOperationManagement.MeetingDetailInsert(ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, ddlIncidentNo.SelectedItem.Value, DateTime.Parse(txtMeetingDate.Text), txtInfoDetail.Text, DateTime.Parse(txtOnDate.Text), txtCustomerRepresentative.Text, ddlContext.SelectedValue.ToString(), ddlMeetingType.SelectedValue.ToString(), txtMOM.Text, txtNextActionPlan.Text, txtNextMeetingDate.Text, dtClientMeeting, dtOurRepresentative, BaseUserID, BaseLocationAutoID, Resources.Resource.Fresh);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                txtMeetingNo.Text = ds.Tables[0].Rows[0]["MeetingNumber"].ToString();
                lblMeetingStatus.Text = Resources.Resource.Fresh;
                HideButtonBasedOnStatus();
            }
        }

    }

    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int flag = 1;
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        
        //  Added new Code for Next Meeting Details by  on 26-Jun-2013
        if (!string.IsNullOrEmpty(txtNextMeetingDate.Text))
        {
            if (DateTime.Parse(txtNextMeetingDate.Text) < DateTime.Parse(txtMeetingDate.Text))
            {
                lblErrorMsg.Text = "Next Meeting Date should be greater than Meeting Date";
                flag = 0;
                return;
            }
        }
        //End
        if (lblMeetingStatus.Text == Resources.Resource.ObservationAuthorized)
        {
            if (flag == 1)
            {
                gvClientMeetingDetail.EditIndex = -1;
                FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
                if (CheckPlanAuthorize() == true)
                {
                    HideButtons();
                    // Modify Code for New Columns minutesOfMeeting, nextActionPlan & nextMeetingDate by  on 26-Jun-2013
                    ds = objOperationManagement.MeetingDetailUpdate(txtMeetingNo.Text, txtCustomerRepresentative.Text, ddlContext.SelectedValue.ToString(), txtMOM.Text, txtNextActionPlan.Text, txtNextMeetingDate.Text, BaseLocationAutoID, BaseUserID);
                    HideButtonBasedOnStatus();
                    DisableFields();
                    gvClientMeetingDetail.Columns[0].Visible = false;
                    gvClientMeetingDetail.FooterRow.Visible = false;
                    gvOurRepresentative.Columns[0].Visible = false;
                    gvOurRepresentative.FooterRow.Visible = false;
                }
                else
                {
                    lblErrorMsg.Text = "Plan Information Detail is blank";
                }
            }
        }
        else if (lblMeetingStatus.Text == Resources.Resource.PlanAuthorized)
        {
            if (flag == 1)
            {
                gvClientMeetingDetail.EditIndex = -1;
                FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
                if (CheckActionAuthorize() == true)
                {
                    HideButtons();
                    // Modify Code for New Columns minutesOfMeeting, nextActionPlan & nextMeetingDate by  on 26-Jun-2013
                    ds = objOperationManagement.MeetingDetailUpdate(txtMeetingNo.Text, txtCustomerRepresentative.Text, ddlContext.SelectedValue.ToString(), txtMOM.Text, txtNextActionPlan.Text, txtNextMeetingDate.Text, BaseLocationAutoID, BaseUserID);
                    HideButtonBasedOnStatus();
                    DisableFields();
                    gvClientMeetingDetail.Columns[0].Visible = false;
                    gvClientMeetingDetail.FooterRow.Visible = false;
                    gvOurRepresentative.Columns[0].Visible = false;
                    gvOurRepresentative.FooterRow.Visible = false;
                }
                else
                {
                    lblErrorMsg.Text = "Action Information Detail is blank";
                }
            }
        }
        else if (lblMeetingStatus.Text == Resources.Resource.Fresh)
        {
            if (flag == 1)
            {
                gvClientMeetingDetail.EditIndex = -1;
                FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
                // Modify Code for New Columns minutesOfMeeting, nextActionPlan & nextMeetingDate by  on 26-Jun-2013
                ds = objOperationManagement.MeetingDetailUpdate(txtMeetingNo.Text, txtCustomerRepresentative.Text, ddlContext.SelectedValue.ToString(), txtMOM.Text, txtNextActionPlan.Text, txtNextMeetingDate.Text, BaseLocationAutoID, BaseUserID);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    HideButtons();
                    HideButtonBasedOnStatus();
                    DisableFields();
                    gvClientMeetingDetail.Columns[0].Visible = false;
                    gvClientMeetingDetail.FooterRow.Visible = false;
                    gvOurRepresentative.Columns[0].Visible = false;
                    gvOurRepresentative.FooterRow.Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// Function call on Authorize Button for Authorize record
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnObservationAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.MeetingObservationAuthorize(Resources.Resource.ObservationAuthorized, txtMeetingNo.Text, BaseLocationAutoID);
        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
        {
            gvClientMeetingDetail.Columns[6].Visible = true;
            gvClientMeetingDetail.Columns[7].Visible = true;
            gvClientMeetingDetail.Columns[8].Visible = true;
            gvClientMeetingDetail.Columns[9].Visible = true;
            lblMeetingStatus.Text = Resources.Resource.ObservationAuthorized;
            DisableFields();
            HideButtonBasedOnStatus();
        }
    }

    /// <summary>
    /// Function call on Plan Authorize Button for Plan Authorize record
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnPlanAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (CheckPlanAuthorize() == true)
        {
            HideButtons();
            ds = objOperationManagement.MeetingPlanAuthorize(Resources.Resource.PlanAuthorized, txtMeetingNo.Text, BaseLocationAutoID);
            lblMeetingStatus.Text = Resources.Resource.PlanAuthorized;
            gvClientMeetingDetail.Columns[10].Visible = true;
            gvClientMeetingDetail.Columns[11].Visible = true;
            HideButtonBasedOnStatus();
            //Modified By  on 4-Apr-2013
            PanelActionInfoToClient.Visible = false;
            DisableFields();
        }
        else
        {
            lblErrorMsg.Text = "Plan Information Detail is blank";
        }
    }

    /// <summary>
    /// Function call on Action Authorize Button for Action Authorize record
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnActionAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (CheckActionAuthorize() == true)
        {
            if (DateTime.Parse(txtOnDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
            {
                txtOnDate.BackColor = System.Drawing.Color.Empty;
                HideButtons();
                ds = objOperationManagement.MeetingActionAuthorize(Resources.Resource.ActionAuthorized, txtMeetingNo.Text, BaseLocationAutoID);
                lblMeetingStatus.Text = Resources.Resource.ActionAuthorized;
                HideButtonBasedOnStatus();
                DisableFields();
            }
            else
            {
                lblErrorMsg.Text = "Date should be greater than or equal to Meeting Date";
                ToolkitScriptManager2.SetFocus(txtOnDate);
                txtOnDate.BackColor = System.Drawing.Color.Aqua;
                return;
            }
        }
        else
        {
            lblErrorMsg.Text = "Action Information Detail is blank";
        }
    }

    /// <summary>
    /// Function call on Edit Button for Edit record
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        HideButtons();
        Status = 0;
        btnCancel.Visible = true;
        btnUpdate.Visible = true;
        btnAddNew.Visible = true;
        ddlContext.Enabled = true;
        txtCustomerRepresentative.Enabled = true;
        gvOurRepresentative.Columns[0].Visible = true;
        gvClientMeetingDetail.Columns[0].Visible = true;
        FillDetails();
        FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
        FillgvOurRepresentativeAfterSave(txtMeetingNo.Text);
        DisableFields();
    }
    /// <summary>
    /// Function call on Cancel Button for Cancel record
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        HideButtons();
        HideButtonBasedOnStatus();
        DisableFields();
        gvClientMeetingDetail.Columns[0].Visible = false;
        gvClientMeetingDetail.FooterRow.Visible = false;
        gvOurRepresentative.Columns[0].Visible = false;
        gvOurRepresentative.FooterRow.Visible = false;
    }
    #endregion

    #region GridView[gvClientMeetingDetail] Events
    /// <summary>
    /// Function call on gvClientMeetingDetail Row Deleting
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvClientMeetingDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblRowID = (Label)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("lblRowID");
        if (Status == 1)
        {
            dtClientMeeting.Rows.RemoveAt(e.RowIndex);
            //Modified by  on 26-July-2013
            gvClientMeetingDetail.DataSource = dtClientMeeting;
            gvClientMeetingDetail.DataBind();
            if (dtClientMeeting.Rows.Count == 0)
            {
                FillgvClientMeetingDetail();
            }
        }
        else if (Status == 0)
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            ds = objOperationManagement.ClientMeetingDetailDelete(lblRowID.Text);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
        }
    }

    /// <summary>
    /// Function call on gvClientMeetingDetail Row Command
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvClientMeetingDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int flag = 1;
        DropDownList ddlNewObservationType = (DropDownList)gvClientMeetingDetail.FooterRow.FindControl("ddlNewObservationType");
        TextBox txtNewObservation = (TextBox)gvClientMeetingDetail.FooterRow.FindControl("txtNewObservation");
        TextBox txtNewCorrectiveMeasures = (TextBox)gvClientMeetingDetail.FooterRow.FindControl("txtNewCorrectiveMeasures");
        TextBox txtNewPromisedDate = (TextBox)gvClientMeetingDetail.FooterRow.FindControl("txtNewPromisedDate");
        TextBox txtNewActionPlanned = (TextBox)gvClientMeetingDetail.FooterRow.FindControl("txtNewActionPlanned");
        TextBox txtNewResponsibility = (TextBox)gvClientMeetingDetail.FooterRow.FindControl("txtNewResponsibility");
        Label lblNewName = (Label)gvClientMeetingDetail.FooterRow.FindControl("lblNewName");
        Label lblNewDesignation = (Label)gvClientMeetingDetail.FooterRow.FindControl("lblNewDesignation");
        TextBox txtNewActionDate = (TextBox)gvClientMeetingDetail.FooterRow.FindControl("txtNewActionDate");
        TextBox txtNewRemarks = (TextBox)gvClientMeetingDetail.FooterRow.FindControl("txtNewRemarks");
        ImageButton lbADD = (ImageButton)gvClientMeetingDetail.FooterRow.FindControl("lbADD");
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (Status == 1)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                if (ddlNewObservationType.Text == "")
                {
                    lbADD.Visible = false;
                }
                else
                {
                    lbADD.Visible = true;
                }
                if (txtMeetingDate.Text != "")
                {
                    if (txtNewPromisedDate.Text != "")
                    {
                        if (DateTime.Parse(txtNewPromisedDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
                        {
                            flag = 1;
                            txtNewPromisedDate.BackColor = System.Drawing.Color.Empty;
                        }
                        else
                        {
                            lblErrorMsg.Text = "Promised date should be greater than or equal to meeting Date";
                            ToolkitScriptManager2.SetFocus(txtNewPromisedDate);
                            txtNewPromisedDate.BackColor = System.Drawing.Color.Aqua;
                            return;
                        }
                    }
                    if (txtNewActionDate.Text != "")
                    {
                        if (DateTime.Parse(txtNewActionDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
                        {
                            flag = 1;
                            txtNewActionDate.BackColor = System.Drawing.Color.Empty;
                        }
                        else
                        {
                            lblErrorMsg.Text = "Action Date should be greater than or equal to meeting Date";
                            ToolkitScriptManager2.SetFocus(txtNewActionDate);
                            txtNewActionDate.BackColor = System.Drawing.Color.Aqua;
                            return;
                        }
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Meeting date should not be blank";
                    ToolkitScriptManager2.SetFocus(txtMeetingDate);
                    txtMeetingDate.BackColor = System.Drawing.Color.Aqua;
                }
                if (flag == 1)
                {
                    DataRow dr = dtClientMeeting.NewRow();
                    dr[0] = ddlNewObservationType.SelectedItem.Text.ToString();
                    dr[1] = txtNewObservation.Text;
                    dr[2] = txtNewCorrectiveMeasures.Text;
                    dr[3] = txtNewPromisedDate.Text;
                    dr[4] = txtNewActionPlanned.Text;
                    dr[5] = txtNewResponsibility.Text;
                    dr[6] = lblNewName.Text;
                    dr[7] = lblNewDesignation.Text;
                    dr[8] = txtNewActionDate.Text;
                    dr[9] = txtNewRemarks.Text;
                    dr[10] = ddlNewObservationType.SelectedValue.ToString();
                    dr[11] = 0;
                    dtClientMeeting.Rows.Add(dr);
                    gvClientMeetingDetail.DataSource = dtClientMeeting;
                    gvClientMeetingDetail.DataBind();
                }
            }
        }
        else if (Status == 0)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                DataSet ds = new DataSet();
                if (txtNewPromisedDate.Text != "")
                {
                    if (DateTime.Parse(txtNewPromisedDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
                    {
                        flag = 1;
                        txtNewPromisedDate.BackColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblErrorMsg.Text = "Promised date should be greater than or equal to Meeting Date";
                        ToolkitScriptManager2.SetFocus(txtNewPromisedDate);
                        txtNewPromisedDate.BackColor = System.Drawing.Color.Aqua;
                        return;
                    }
                }
                if (txtNewActionDate.Text != "")
                {
                    if (DateTime.Parse(txtNewActionDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
                    {
                        flag = 1;
                        txtNewActionDate.BackColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblErrorMsg.Text = "Action Date should be greater than or equal to Meeting Date";
                        ToolkitScriptManager2.SetFocus(txtNewActionDate);
                        txtNewActionDate.BackColor = System.Drawing.Color.Aqua;
                        return;
                    }
                }
                if (flag == 1)
                {
                    ds = objOperationManagement.ClientDetailInsert(ddlNewObservationType.SelectedValue.ToString(), txtNewObservation.Text, txtNewCorrectiveMeasures.Text, DateTime.Parse(txtNewPromisedDate.Text), txtNewActionPlanned.Text, txtNewResponsibility.Text, CheckDateNull(txtNewActionDate.Text), txtNewRemarks.Text, BaseUserID, txtMeetingNo.Text);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                    {
                        FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
                    }
                }
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewObservation.Text = "";
            txtNewCorrectiveMeasures.Text = "";
            txtNewPromisedDate.Text = "";
            txtNewActionPlanned.Text = "";
            txtNewResponsibility.Text = "";
            lblNewName.Text = "";
            lblNewDesignation.Text = "";
            txtNewActionDate.Text = "";
            txtNewRemarks.Text = "";
        }
    }

    /// <summary>
    /// Function call on gvClientMeetingDetail Row Updating
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvClientMeetingDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int flag = 1;
        DropDownList ddlObservationType = (DropDownList)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("ddlObservationType");
        TextBox txtObservation = (TextBox)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("txtObservation");
        TextBox txtCorrectiveMeasures = (TextBox)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("txtCorrectiveMeasures");
        TextBox txtPromisedDate = (TextBox)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("txtPromisedDate");
        TextBox txtActionPlanned = (TextBox)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("txtActionPlanned");
        TextBox txtResponsibility = (TextBox)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("txtResponsibility");
        Label lblName = (Label)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("lblName");
        Label lblDesignation = (Label)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("lblDesignation");
        TextBox txtActionDate = (TextBox)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("txtActionDate");
        TextBox txtRemarks = (TextBox)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("txtRemarks");
        Label lblRowIDEdit = (Label)gvClientMeetingDetail.Rows[e.RowIndex].FindControl("lblRowIDEdit");
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (Status == 1)
        {
            if (txtPromisedDate.Text != "")
            {
                if (txtMeetingDate.Text != "")
                {
                    txtMeetingDate.BackColor = System.Drawing.Color.Empty;
                    if (DateTime.Parse(txtPromisedDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
                    {
                        flag = 1;
                        txtPromisedDate.BackColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblErrorMsg.Text = "Promised date should be greater than or equal to Meeting Date";
                        ToolkitScriptManager2.SetFocus(txtPromisedDate);
                        txtPromisedDate.BackColor = System.Drawing.Color.Aqua;
                        return;
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Meeting Date cannot be left blank";
                    ToolkitScriptManager2.SetFocus(txtMeetingDate);
                    txtMeetingDate.BackColor = System.Drawing.Color.Aqua;
                }
            }
            if (txtActionDate.Text != "")
            {

                if (DateTime.Parse(txtActionDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
                {
                    flag = 1;
                    txtActionDate.BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    lblErrorMsg.Text = "Action Date should be greater than or equal to Meeting Date";
                    ToolkitScriptManager2.SetFocus(txtActionDate);
                    txtActionDate.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
            }
            if (flag == 1)
            {
                dtClientMeeting.Rows[e.RowIndex][0] = ddlObservationType.SelectedItem.Text.ToString();
                dtClientMeeting.Rows[e.RowIndex][1] = txtObservation.Text;
                dtClientMeeting.Rows[e.RowIndex][2] = txtCorrectiveMeasures.Text;
                dtClientMeeting.Rows[e.RowIndex][3] = txtPromisedDate.Text;
                dtClientMeeting.Rows[e.RowIndex][4] = txtActionPlanned.Text;
                dtClientMeeting.Rows[e.RowIndex][5] = txtResponsibility.Text;
                dtClientMeeting.Rows[e.RowIndex][6] = lblName.Text;
                dtClientMeeting.Rows[e.RowIndex][7] = lblDesignation.Text;
                dtClientMeeting.Rows[e.RowIndex][8] = txtActionDate.Text;
                dtClientMeeting.Rows[e.RowIndex][9] = txtRemarks.Text;
                dtClientMeeting.Rows[e.RowIndex][10] = ddlObservationType.SelectedValue.ToString();
                dtClientMeeting.Rows[e.RowIndex][11] = 0;
                gvClientMeetingDetail.EditIndex = -1;
                gvClientMeetingDetail.DataSource = dtClientMeeting;
                gvClientMeetingDetail.DataBind();
            }
        }
        else if (Status == 0)
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            if (txtPromisedDate.Text != "")
            {
                if (DateTime.Parse(txtPromisedDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
                {
                    flag = 1;
                    txtPromisedDate.BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    lblErrorMsg.Text = "Promised date should be greater than or equal to Meeting Date";
                    ToolkitScriptManager2.SetFocus(txtPromisedDate);
                    txtPromisedDate.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
            }
            if (txtActionDate.Text != "")
            {
                if (DateTime.Parse(txtActionDate.Text) >= DateTime.Parse(txtMeetingDate.Text))
                {
                    flag = 1;
                    txtActionDate.BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    lblErrorMsg.Text = "Action Date should be greater than or equal to Meeting Date";
                    ToolkitScriptManager2.SetFocus(txtActionDate);
                    txtActionDate.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
            }
            if (flag == 1)
            {
                ds = objOperationManagement.ClientMeetingDetailUpdate(ddlObservationType.SelectedValue.ToString(), txtObservation.Text, txtCorrectiveMeasures.Text, DateTime.Parse(txtPromisedDate.Text), txtActionPlanned.Text, txtResponsibility.Text, CheckDateNull(txtActionDate.Text), txtRemarks.Text, BaseUserID, txtMeetingNo.Text, int.Parse(lblRowIDEdit.Text));
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                gvClientMeetingDetail.EditIndex = -1;
                FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
            }
        }
    }

    /// <summary>
    /// Function call on gvClientMeetingDetail Row Editing
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvClientMeetingDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        flagEdit = true;    // Added By  on 21-Mar-2013
        if (Status == 1)
        {
            gvClientMeetingDetail.EditIndex = e.NewEditIndex;
            gvClientMeetingDetail.DataSource = dtClientMeeting;
            gvClientMeetingDetail.DataBind();
        }
        else if (Status == 0)
        {
            gvClientMeetingDetail.EditIndex = e.NewEditIndex;
            FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
            DropDownList ddlObservationType = (DropDownList)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("ddlObservationType");
            TextBox txtObservation = (TextBox)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("txtObservation");
            TextBox txtCorrectiveMeasures = (TextBox)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("txtCorrectiveMeasures");
            TextBox txtPromisedDate = (TextBox)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("txtPromisedDate");
            TextBox txtActionPlanned = (TextBox)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("txtActionPlanned");
            TextBox txtResponsibility = (TextBox)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("txtResponsibility");
            TextBox txtActionDate = (TextBox)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("txtActionDate");
            TextBox txtRemarks = (TextBox)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("txtRemarks");
            ImageButton ImgbtnUpdate = (ImageButton)gvClientMeetingDetail.Rows[e.NewEditIndex].FindControl("ImgbtnUpdate");
            if (lblMeetingStatus.Text == Resources.Resource.ObservationAuthorized)
            {
                ddlObservationType.Enabled = false;
                txtObservation.Enabled = false;
                txtCorrectiveMeasures.Enabled = false;
                txtPromisedDate.Enabled = false;
            }
            if (lblMeetingStatus.Text == Resources.Resource.PlanAuthorized)
            {
                ddlObservationType.Enabled = false;
                txtObservation.Enabled = false;
                txtCorrectiveMeasures.Enabled = false;
                txtPromisedDate.Enabled = false;
                txtActionPlanned.Enabled = false;
                txtResponsibility.Enabled = false;
            }
            //Added by  on 4-Apr-2013
            if (lblMeetingStatus.Text == Resources.Resource.Fresh)
            {
                ddlObservationType.Enabled = false;
            }
        }
    }

    /// <summary>
    /// Function call on gvClientMeetingDetail Row Cancel Editing
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvClientMeetingDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (Status == 1)
        {
            gvClientMeetingDetail.EditIndex = -1;
            gvClientMeetingDetail.DataSource = dtClientMeeting;
            gvClientMeetingDetail.DataBind();
        }
        else if (Status == 0)
        {
            gvClientMeetingDetail.EditIndex = -1;
            FillgvClientMeetingDetailAfterSave(txtMeetingNo.Text);
        }
    }

    /// <summary>
    /// Function call on gvClientMeetingDetail Row Data Bind
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvClientMeetingDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvClientMeetingDetail.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (IBEdit != null)
                {
                    IBEdit.Visible = false;
                }

            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

                }
                DropDownList ddlObservationType = (DropDownList)e.Row.FindControl("ddlObservationType");
                TextBox txtResponsibility = (TextBox)e.Row.FindControl("txtResponsibility");
                TextBox txtObservation = (TextBox)e.Row.FindControl("txtObservation");
                TextBox txtCorrectiveMeasures = (TextBox)e.Row.FindControl("txtCorrectiveMeasures");
                TextBox txtActionPlanned = (TextBox)e.Row.FindControl("txtActionPlanned");
                TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
                ImageButton imgResponsibility = (ImageButton)e.Row.FindControl("imgResponsibility");

                if (ddlObservationType != null)
                {
                    DataSet dsObserveType = new DataSet();
                    dsObserveType = objOperationManagement.ObservationTypeGetAll(BaseCompanyCode);
                    ddlObservationType.DataSource = dsObserveType;
                    ddlObservationType.DataTextField = "ItemDesc";
                    ddlObservationType.DataValueField = "ItemCode";
                    ddlObservationType.DataBind();
                    if (ddlObservationType.Text == "")
                    {
                        ListItem li = new ListItem();
                        li.Text =  Resources.Resource.NoData;
                        li.Value = "0";
                        ddlObservationType.Items.Add(li);
                    }
                    // Code Added by  on 21-Mar-2013 Start***
                    if (!string.IsNullOrEmpty(txtMeetingNo.Text) && e.Row.RowIndex >= 0)
                    {
                        DataSet ds = new DataSet();
                        ds = objOperationManagement.ClientMeetingDetailGetAll(txtMeetingNo.Text, BaseCompanyCode);
                        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
                        {
                            ddlObservationType.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[e.Row.RowIndex]["Observation_Type"]);
                            if (dsObserveType.Tables[0].Rows.Count > 0)
                            {
                                for (int cnt = 0; cnt < dsObserveType.Tables[0].Rows.Count; cnt++)
                                {
                                    if (ddlObservationType.SelectedItem.Text == dsObserveType.Tables[0].Rows[cnt]["ItemDesc"].ToString())
                                    {
                                        ddlObservationType.SelectedValue = Convert.ToString(dsObserveType.Tables[0].Rows[cnt]["ItemCode"]);
                                    }
                                }
                            }
                        }
                    }

                    //End***
                }
                if (imgResponsibility != null)
                {
                    //imgResponsibility.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtResponsibility.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                    imgResponsibility.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtResponsibility.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                }
                if (txtResponsibility != null)
                {
                    txtResponsibility.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtResponsibility.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                if (txtObservation != null)
                {
                    txtObservation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtObservation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (txtCorrectiveMeasures != null)
                {
                    txtCorrectiveMeasures.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtCorrectiveMeasures.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (txtActionPlanned != null)
                {
                    txtActionPlanned.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtActionPlanned.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (txtRemarks != null)
                {
                    txtRemarks.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtRemarks.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                }
            }
            else
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvClientMeetingDetail.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                DropDownList ddlNewObservationType = (DropDownList)e.Row.FindControl("ddlNewObservationType");
                TextBox txtNewResponsibility = (TextBox)e.Row.FindControl("txtNewResponsibility");
                TextBox txtNewObservation = (TextBox)e.Row.FindControl("txtNewObservation");
                TextBox txtNewCorrectiveMeasures = (TextBox)e.Row.FindControl("txtNewCorrectiveMeasures");
                TextBox txtNewActionPlanned = (TextBox)e.Row.FindControl("txtNewActionPlanned");
                TextBox txtNewRemarks = (TextBox)e.Row.FindControl("txtNewRemarks");
                ImageButton imgNewResponsibility = (ImageButton)e.Row.FindControl("imgNewResponsibility");

                if (ddlNewObservationType != null)
                {
                    ddlNewObservationType.DataSource = objOperationManagement.ObservationTypeGetAll(BaseCompanyCode);
                    ddlNewObservationType.DataTextField = "ItemDesc";
                    ddlNewObservationType.DataValueField = "ItemCode";
                    ddlNewObservationType.DataBind();
                    if (ddlNewObservationType.Text == "")
                    {
                        ListItem li = new ListItem();
                        li.Text =  Resources.Resource.NoData;
                        li.Value = "0";
                        ddlNewObservationType.Items.Add(li);

                    }
                    //Added by  on 4-Apr-2013
                    if (!string.IsNullOrEmpty(txtMeetingNo.Text) && e.Row.RowIndex >= 0)
                    {
                        DataSet ds = new DataSet();
                        ds = objOperationManagement.ClientMeetingDetailGetAll(txtMeetingNo.Text, BaseCompanyCode);
                        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
                        {
                            ddlNewObservationType.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[e.Row.RowIndex]["Observation_Type"]);
                        }
                    }
                }

                if (imgNewResponsibility != null)
                {
                    // imgNewResponsibility.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtNewResponsibility.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                    imgNewResponsibility.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtNewResponsibility.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                }
                if (txtNewResponsibility != null)
                {
                    txtNewResponsibility.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewResponsibility.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                if (txtNewObservation != null)
                {
                    txtNewObservation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewObservation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (txtNewCorrectiveMeasures != null)
                {
                    txtNewCorrectiveMeasures.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewCorrectiveMeasures.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (txtNewActionPlanned != null)
                {
                    txtNewActionPlanned.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewActionPlanned.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (txtNewRemarks != null)
                {
                    txtNewRemarks.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewRemarks.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    #endregion

    #region Function to Convert date to null if date=01/01/0001
    /// <summary>
    /// Function call to Convert date to null if date=01/01/0001
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>System.String.</returns>
    private string ConvertDateToNull(string date)
    {
        string strDate = "01/01/0001";
        if ((DateTime.Parse(date)) == (DateTime.Parse(strDate)))
        {
            return null;
        }
        else
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(date);
            string formatedDate = dt.ToString("d-MMM-yyyy");
            return formatedDate;
        }
    }
    #endregion

    #region Function to create datatable with blank row
    /// <summary>
    /// Function call to Create Empty Table
    /// </summary>
    private void CreateEmptyDataTable()
    {
        if (dtClientMeeting.Rows.Count == 0)
        {
            dtClientMeeting.Rows.Add(dtClientMeeting.NewRow());
        }
        gvClientMeetingDetail.DataSource = dtClientMeeting;
        gvClientMeetingDetail.DataBind();
        gvClientMeetingDetail.Rows[0].Visible = false;
    }
    #endregion

    #region Function to check whether date is null or not
    /// <summary>
    /// Function call to check Date null Value
    /// </summary>
    /// <param name="strDate">The string date.</param>
    /// <returns>System.String.</returns>
    private string CheckDateNull(string strDate)
    {
        if (strDate == "")
        {
            return "01-01-1900";
        }
        else
        {
            return strDate;
        }
    }
    #endregion

    #region Hide Button Based On Status
    /// <summary>
    /// Function call to Hide Button based on Meeting Status
    /// </summary>
    private void HideButtonBasedOnStatus()
    {
        if (lblMeetingStatus.Text == Resources.Resource.Fresh)
        {
            int flag = 0;
            btnSave.Visible = false;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnObservationAuthorize.Visible = true;
                btnAddNew.Visible = true;
                btnEdit.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnObservationAuthorize.Visible = true;
                }
            }
        }
        if (lblMeetingStatus.Text == Resources.Resource.ObservationAuthorized)
        {
            btnObservationAuthorize.Visible = false;
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnPlanAuthorize.Visible = true;
                btnAddNew.Visible = true;
                btnEdit.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnPlanAuthorize.Visible = true;
                    btnEdit.Visible = true;
                }
            }
        }
        if (lblMeetingStatus.Text == Resources.Resource.PlanAuthorized)
        {
            btnPlanAuthorize.Visible = false;
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnActionAuthorize.Visible = true;
                btnAddNew.Visible = true;
                btnEdit.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnActionAuthorize.Visible = true;
                    btnEdit.Visible = true;
                }
            }
        }
        if (lblMeetingStatus.Text == Resources.Resource.ActionAuthorized)
        {
            btnActionAuthorize.Visible = false;
            btnEdit.Visible = false;
            gvClientMeetingDetail.Columns[0].Visible = false;
            gvOurRepresentative.Columns[0].Visible = false;
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
            }
        }
    }
    #endregion

    #region Check Plan and Action Authorize Functions
    /// <summary>
    /// Function call to check plan Authorized
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckPlanAuthorize()
    {
        int flag = 1;
        for (int i = 0; i < gvClientMeetingDetail.Rows.Count; i++)
        {
            Label lblActionPlanned = (Label)gvClientMeetingDetail.Rows[i].FindControl("lblActionPlanned");
            if (lblActionPlanned.Text == "")
            {
                gvClientMeetingDetail.Rows[i].BackColor = System.Drawing.Color.Aqua;
                flag = 0;
                return false;
            }
            else
            {
                if (flag != 0)
                {
                    flag = 1;
                }
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

    /// <summary>
    /// Function call to Check Action Authorized
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckActionAuthorize()
    {
        int flag = 1;
        for (int i = 0; i < gvClientMeetingDetail.Rows.Count; i++)
        {
            Label lblActionDate = (Label)gvClientMeetingDetail.Rows[i].FindControl("lblActionDate");
            if (lblActionDate.Text == "")
            {
                gvClientMeetingDetail.Rows[i].BackColor = System.Drawing.Color.Aqua;
                flag = 0;
                return false;
            }
            else
            {
                if (flag != 0)
                {
                    flag = 1;
                }
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
        // return false; //Commeted just to check if error found uncomment
    }
    #endregion

    #region ClearField, DisableButton,EnableButton,Enable,Disable Fields,Show And Hide Button Functions
    /// <summary>
    /// Function call to Clear Fields value
    /// </summary>
    private void ClearFields()
    {
        txtAreaDesc.Text = "";
        txtAreaID.Text = "";
        txtCustomerRepresentative.Text = "";
        txtInfoDetail.Text = "";
        txtMeetingDate.Text = "";
        txtMeetingNo.Text = "";
        txtOnDate.Text = "";
        lblMeetingStatus.Text = "";
        //Added by  on 29-May-2013
        ddlAsmtId.Items.Clear();
        FillClientId();
        //Added by  on 28-Jun-2013
        txtMOM.Text = "";
        txtNextActionPlan.Text = "";
        txtNextMeetingDate.Text = "";
        //Modify By  on 31-July-2013
        ddlIncidentNo.Items.Clear();
    }

    /// <summary>
    /// Function call to Disable Buttons
    /// </summary>
    private void DisableButton()
    {
        btnActionAuthorize.Enabled = false;
        btnAddNew.Enabled = false;
        btnCancel.Enabled = false;
        btnEdit.Visible = false;
        btnObservationAuthorize.Enabled = false;
        btnPlanAuthorize.Enabled = false;
        btnSave.Enabled = false;
        btnUpdate.Enabled = false;
    }

    /// <summary>
    /// Function call to Enable Buttons
    /// </summary>
    private void EnableButton()
    {
        btnActionAuthorize.Enabled = true;
        btnAddNew.Enabled = true;
        btnCancel.Enabled = true;
        btnEdit.Visible = true;
        btnObservationAuthorize.Enabled = true;
        btnPlanAuthorize.Enabled = true;
        btnUpdate.Enabled = true;
    }

    /// <summary>
    /// Function call to Disable Fields.
    /// </summary>
    private void DisableFields()
    {
        IMGDate.Visible = false;
        txtCustomerRepresentative.Enabled = false;
        txtInfoDetail.Enabled = false;          //Added by  on 31-July-2013
        ddlContext.Enabled = false;
        ddlMeetingType.Enabled = false;
        txtMeetingDate.Enabled = false;
        // Modify by  on 31-July-2013
        ddlIncidentNo.Enabled = false;
    }

    /// <summary>
    /// Function call to Enable Fields
    /// </summary>
    private void EnableFields()
    {
        txtMeetingNo.Enabled = true;
        IMGDate.Visible = true;
        txtCustomerRepresentative.Enabled = true;
        ddlContext.Enabled = true;
        ddlMeetingType.Enabled = true;
        gvClientMeetingDetail.Enabled = true;
        gvOurRepresentative.Enabled = true;
        txtInfoDetail.Enabled = true;               //Added by  on 1-Aug-2013
    }

    /// <summary>
    /// Function call to Hide Button
    /// </summary>
    private void HideButtons()
    {
        btnActionAuthorize.Visible = false;
        btnAddNew.Visible = false;
        btnCancel.Visible = false;
        btnEdit.Visible = false;
        btnObservationAuthorize.Visible = false;
        btnPlanAuthorize.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    /// <summary>
    /// Function call to Show Button
    /// </summary>
    private void ShowButtons()
    {
        btnActionAuthorize.Visible = true;
        btnAddNew.Visible = true;
        btnCancel.Visible = true;
        btnEdit.Visible = true;
        btnObservationAuthorize.Visible = true;
        btnPlanAuthorize.Visible = true;
        btnSave.Visible = true;
        btnUpdate.Visible = true;
    }
    #endregion

    #region Coded Added by 
    /// <summary>
    /// Funciton call to fill dropdownlist ClientCode //Added by  on 29-May-2013
    /// </summary>
    private void FillClientId()
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ClientDetail");
                dt.Columns.Add("ClientCode");
                dt.Rows.Add("Select", "Select");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["ClientDetail"], ds.Tables[0].Rows[cnt]["ClientCode"]);
                }
                ddlClientId.DataSource = dt;
                ddlClientId.DataTextField = "ClientDetail";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();

                ddlAsmtId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlClientId Item Selection get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmt();
    }

    /// <summary>
    /// Get Assignment Based on LocationAutoId and ClientCode.
    /// </summary>
    private void FillAsmt()
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AsmtCode");
                dt.Columns.Add("AsmtDetail");
                dt.Rows.Add("Select", "Select");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["AsmtCode"], ds.Tables[0].Rows[cnt]["AsmtDetail"]);
                }
                ddlAsmtId.DataSource = dt;
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();

                ddlAsmtId.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlAsmtId Item Selection get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtDetails();
        fillIncidentNo();
    }

    /// <summary>
    /// Set Client Code on based on txtIncidentNo Added by  on 29-May-2013
    /// </summary>
    /// <param name="clientCode">The client code.</param>
    private void SetClientId(string clientCode)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientId.DataSource = ds;
                ddlClientId.DataTextField = "ClientDetail";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["ClientCode"].ToString() == clientCode)
                    {
                        ddlClientId.SelectedIndex = cnt;
                    }
                }
                ddlClientId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }

    /// <summary>
    /// Set Assignment Based on LocationAutoId and ClientCode.
    /// </summary>
    /// <param name="asmtId">The asmt identifier.</param>
    private void SetAsmt(string asmtId)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlAsmtId.DataSource = ds;
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["AsmtCode"].ToString() == asmtId)
                    {
                        ddlAsmtId.SelectedIndex = cnt;
                    }
                }
                ddlAsmtId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }

    /// <summary>
    /// Added Code for Get IncidentNo Based on ClientCode, IncidentType on 1-Aug-2013
    /// </summary>
    private void fillIncidentNo()
    {
        try
        {
            ddlIncidentNo.Items.Clear();
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.IncidentNoSelectedClientGet(ddlClientId.SelectedItem.Value, Convert.ToInt32(BaseLocationAutoID));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IncidentText");
                dt.Columns.Add("IncidentValue");
                dt.Rows.Add("Select", "");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["IncidentNo"], ds.Tables[0].Rows[cnt]["IncidentNo"]);
                }
                ddlIncidentNo.DataSource = dt;
                ddlIncidentNo.DataTextField = "IncidentText";
                ddlIncidentNo.DataValueField = "IncidentValue";
                ddlIncidentNo.DataBind();

                ddlIncidentNo.Enabled = true;
            }
            else
            {

                ListItem li = new ListItem();
                li.Text =  Resources.Resource.NoData;
                li.Value = "";
                ddlIncidentNo.Items.Add(li);
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }

    /// <summary>
    /// Set IncidentNo based on MeetingNo Coded by  on 1-Aug-2013
    /// </summary>
    /// <param name="incidentNo">The incident no.</param>
    private void SetIncidentNo(string incidentNo)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.IncidentNoSelectedClientGet(ddlClientId.SelectedItem.Value, Convert.ToInt32(BaseLocationAutoID));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlIncidentNo.DataSource = ds;
                ddlIncidentNo.DataTextField = "IncidentNo";
                ddlIncidentNo.DataValueField = "IncidentNo";
                ddlIncidentNo.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["IncidentNo"].ToString() == incidentNo)
                    {
                        ddlIncidentNo.SelectedIndex = cnt;
                    }
                }
                ddlIncidentNo.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    #endregion
}
