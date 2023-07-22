// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="NightCheckVisitAction.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class OperationManagement_NightCheckVisitAction.
/// </summary>
public partial class OperationManagement_NightCheckVisitAction : BasePage//System.Web.UI.Page
{
    /// <summary>
    /// The dt night check visit action
    /// </summary>
    static DataTable dtNightCheckVisitAction = new DataTable();
    /// <summary>
    /// The status
    /// </summary>
    static int Status;

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
    /// Returns User Authorization Rights.
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
            javaScript.Append("PageTitle('" + Resources.Resource.NightCheckVisitActio + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                Status = 1;
                if (IsWriteAccess == true)
                {
                    btnSave.Visible = true;
                    //gvNightCheckVisitAction.Columns[0].Visible = true;
                }
                else
                {
                    //gvNightCheckVisitAction.Columns[0].Visible = false;
                }
                dtNightCheckVisitAction.Clear();
                if (dtNightCheckVisitAction.Columns.Contains("Observation_type") == false)
                {
                    MakeTempNightCheckVisitAction();
                }
                else
                {
                    dtNightCheckVisitAction.Clear();
                }
                IMGCheckVisitNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCHNightCheck&ControlId=" + txtCheckVisitNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
                IMGCheckVisitActionNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=NIGHTACTIONCCH&ControlId=" + txtCheckVisitActionNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
            }
        }
    }

    /// <summary>
    /// Makes the temporary night check visit action.
    /// </summary>
    private void MakeTempNightCheckVisitAction()
    {
        DataColumn dcol1 = new DataColumn("ItemDesc", typeof(System.String));
        DataColumn dcol2 = new DataColumn("Observation_Type", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Observation", typeof(System.String));
        DataColumn dcol4 = new DataColumn("RowID", typeof(System.Int32));
        DataColumn dcol5 = new DataColumn("ActionPlanned", typeof(System.String));
        DataColumn dcol6 = new DataColumn("Responsible", typeof(System.String));
        DataColumn dcol7 = new DataColumn("ActionDate", typeof(System.String));
        DataColumn dcol8 = new DataColumn("Remarks", typeof(System.String));
        DataColumn dcol9 = new DataColumn("Designation", typeof(System.String));
        DataColumn dcol10 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol11 = new DataColumn("AutoID", typeof(System.Int32));
        DataColumn dcol12 = new DataColumn("ComplainAgainst", typeof(System.String));
        DataColumn dcol13 = new DataColumn("EmployeeName", typeof(System.String));
        DataColumn dcol14 = new DataColumn("EmployeeDesignation", typeof(System.String));
        dtNightCheckVisitAction.Columns.Add(dcol1);
        dtNightCheckVisitAction.Columns.Add(dcol2);
        dtNightCheckVisitAction.Columns.Add(dcol3);
        dtNightCheckVisitAction.Columns.Add(dcol4);
        dtNightCheckVisitAction.Columns.Add(dcol5);
        dtNightCheckVisitAction.Columns.Add(dcol6);
        dtNightCheckVisitAction.Columns.Add(dcol7);
        dtNightCheckVisitAction.Columns.Add(dcol8);
        dtNightCheckVisitAction.Columns.Add(dcol9);
        dtNightCheckVisitAction.Columns.Add(dcol10);
        dtNightCheckVisitAction.Columns.Add(dcol11);
        dtNightCheckVisitAction.Columns.Add(dcol12);
        dtNightCheckVisitAction.Columns.Add(dcol13);
        dtNightCheckVisitAction.Columns.Add(dcol14);
    }

    /// <summary>
    /// Fills the asmt detail.
    /// </summary>
    private void FillAsmtDetail()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AsmtIncidentDetailGet(ddlClientId.SelectedItem.Value,ddlAsmtId.SelectedValue.ToString(), BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                EnableFields();
                EnableButtons();
                txtBranchID.Text = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                txtBranchIDDesc.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
                //txtCustomerID.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                txtAddressID.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                txtAddressDesc.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
                btnSave.Enabled = true;            //Added by  on 2-Jun-2013
            }
            else
            {
                DisableFields();
                ClearFields();
                DisableButtons();
                btnSave.Enabled = false;            //Added by  on 2-Jun-2013
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            DisableButtons();
            btnSave.Enabled = false;            //Added by  on 2-Jun-2013
        }
    }
    /// <summary>
    /// Fills the check visit number detail.
    /// </summary>
    private void FillCheckVisitNumberDetail()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.NightCheckVisitGetAll(txtCheckVisitNumber.Text, BaseLocationAutoID,Resources.Resource.Authorized);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtCheckVisitType.Text = (ds.Tables[0].Rows[0]["ItemDesc"].ToString());
            txtEmployeeID.Text = ds.Tables[0].Rows[0]["Conducted_by"].ToString();
            txtTimeFrom.Text = DateTime.Parse(ds.Tables[0].Rows[0]["Time_from"].ToString()).ToString("HH:mm");
            txtTimeTo.Text = DateTime.Parse(ds.Tables[0].Rows[0]["Time_to"].ToString()).ToString("HH:mm");
            txtCheckVisitDate.Text = DateFormat(ds.Tables[0].Rows[0]["Check_Visit_Date"].ToString());
            //Added by  on 1-Jun-2013
            FillClientDetail();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.RecordNotAuthorized;
            ClearFields();
            ClearAsmtDetails();
        }
    }
    //Added by  on 31-May-2013
    /// <summary>
    /// Fills the client detail.
    /// </summary>
    private void FillClientDetail()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.AsmtCodeForNightCheckVisitGetAll(txtCheckVisitNumber.Text, BaseLocationAutoID);
        if (ds!= null &&  ds.Tables[0].Rows.Count > 0)
        {
            string clientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();     
            SetClientId(clientCode);
            string asmtId = ds.Tables[0].Rows[0]["AsmtId"].ToString();           
            SetAsmt(asmtId);
            ddlClientId.Enabled = false;
            ddlAsmtId.Enabled = false;
        }
    }
    /// <summary>
    /// Fills the details.
    /// </summary>
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.NightCheckVisitActionDetailGet(txtCheckVisitActionNumber.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtCheckVisitNumber.Text = ds.Tables[0].Rows[0]["Check_Visit_No"].ToString();
            txtCheckVisitDate.Text = ds.Tables[0].Rows[0]["CheckVisitActionDate"].ToString();
            //Added by  on 31-May-2013
            txtDate.Text = ds.Tables[0].Rows[0]["CheckVisitActionDate"].ToString();
            lblCheckVisitActionStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString(); 
            string clientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();     
            SetClientId(clientCode);
            string asmtId = ds.Tables[0].Rows[0]["AsmtId"].ToString();         
            SetAsmt(asmtId);
            ddlClientId.Enabled = false;
            ddlAsmtId.Enabled = false;
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtCheckVisitNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtCheckVisitNumber_TextChanged(object sender, EventArgs e)
    {
        FillCheckVisitNumberDetail();
        txtEmployeeID_TextChanged(sender, e);
        //Added by  on 31-May-2013
        string chVNo = txtCheckVisitNumber.Text;
        if (ddlAsmtId.SelectedItem != null)
        {
            ddlAsmtId_SelectedIndexChanged(sender, e);
            FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
        }
        //End
        if (txtCheckVisitActionNumber.Text != "")
        {
            gvNightCheckVisitAction.Columns[0].Visible = true;
        }
        else
        {
            gvNightCheckVisitAction.Columns[0].Visible = false;
        }

    }
    //protected void txtAssignNo_TextChanged(object sender, EventArgs e)
    //{

    //}
    /// <summary>
    /// Handles the TextChanged event of the txtResponsibility control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtResponsibility_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtResponsibility = (TextBox)gvNightCheckVisitAction.Rows[row.RowIndex].FindControl("txtResponsibility");
        Label lblName = (Label)gvNightCheckVisitAction.Rows[row.RowIndex].FindControl("lblName");
        Label lblDesignation = (Label)gvNightCheckVisitAction.Rows[row.RowIndex].FindControl("lblDesignation");
        ImageButton ImgbtnUpdate = (ImageButton)gvNightCheckVisitAction.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtResponsibility.Text, BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            ImgbtnUpdate.Visible = true;
            lblName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            lblDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
        }
        else
        {
            ImgbtnUpdate.Visible = false;
            lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
            lblName.Text = "";
            lblDesignation.Text = "";
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewResponsibility control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewResponsibility_TextChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the TextChanged event of the txtEmployeeID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeID_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeID.Text, BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            txtDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
        }
        else
        {
            ///lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
            txtEmployeeName.Text = "";
            txtDesignation.Text = "";
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtCheckVisitActionNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtCheckVisitActionNumber_TextChanged(object sender, EventArgs e)
    {
        if (txtCheckVisitActionNumber.Text != "")
        {
            Status = 0;
            FillgvNightCheckVisitActionAfterSave();
            FillDetails();
            ddlAsmtId_SelectedIndexChanged(sender, e);      //Added by  on 31-May-2013
            txtCheckVisitNumber_TextChanged(sender, e);
            //ddlAsmtCode_SelectedIndexChanged(sender, e);
            DisableFields();
            gvNightCheckVisitAction.Columns[0].Visible = true;
            HideButtons();
            HideButtonBasedOnStatus();
        }
        else
        {
            gvNightCheckVisitAction.Columns[0].Visible = false;
        }
    }

    //protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BL.OperationManagement objOperationManagement = new BL.OperationManagement();
    //    DataSet ds = new DataSet();
    //    if (txtCheckVisitNumber.Text == "")
    //    {
    //        ddlAsmtCode.Enabled = false;
    //    }
    //    else
    //    {
    //        ds = objOperationManagement.CheckAsmtForNightCheckAndVisit(txtCheckVisitNumber.Text, BaseLocationAutoID);
    //        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
    //        {
    //            FillAsmtDetail();
    //            if (ddlAsmtCode.Text!="")
    //            {
    //                ds = objOperationManagement.NightCheckVisitActionCheckForNightCheckVisitNumber(txtCheckVisitNumber.Text, ddlAsmtCode.SelectedItem.Text.ToString());
    //                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
    //                {
    //                    PanelGridView.Visible = true;
    //                    lblCheckVisitActionStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
    //                    txtCheckVisitActionNumber.Text = ds.Tables[0].Rows[0]["Check_Visit_Action_No"].ToString();
    //                    txtDate.Text = DateFormat(ds.Tables[0].Rows[0]["CheckVisitActionDate"].ToString());
    //                    FillgvNightCheckVisitActionAfterSave();
    //                    Status = 0;
    //                    gvNightCheckVisitAction.Columns[0].Visible = true;
    //                    HideButtons();
    //                    HideButtonBasedOnStatus();
    //                }
    //                else
    //                {
    //                    FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
    //                    PanelGridView.Visible = true;
    //                    HideButtons();
    //                    HideButtonBasedOnStatus();//was commented
    //                    btnSave.Visible = true;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
    //        }
    //    }
    //}

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        gvNightCheckVisitAction.EditIndex = -1;
       
        DataSet ds = new DataSet();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (txtCheckVisitDate.Text != "" && txtDate.Text!="")
        {
            if (DateTime.Parse(txtDate.Text) < DateTime.Parse(txtCheckVisitDate.Text))
            {
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Aqua;
                lblErrorMsg.Text = "Date Should always be greater than or equal to Check Visit Date";
                return;
            }
            else
            {
                txtDate.BackColor = System.Drawing.Color.Empty;
            }
        }
        if (txtCheckVisitNumber.Text != "")
        {
            ds = objOperationManagement.NightCheckVisitActionInsert(BaseCompanyCode,BaseHrLocationCode,BaseLocationCode, txtCheckVisitNumber.Text, dtNightCheckVisitAction, BaseUserID, Resources.Resource.Fresh, DateTime.Parse(txtDate.Text), ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value.ToString());
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                txtCheckVisitNumber.BackColor = System.Drawing.Color.Empty;
                txtCheckVisitActionNumber.Text = ds.Tables[0].Rows[0]["CheckVisitActionNumber"].ToString();
                lblCheckVisitActionStatus.Text = Resources.Resource.Fresh;
                HideButtonBasedOnStatus();
                DisableFields();
                gvNightCheckVisitAction.Columns[0].Visible = true;
            }

        }
        else
        {
            ToolkitScriptManager2.SetFocus(txtCheckVisitNumber);
            txtCheckVisitNumber.BackColor = System.Drawing.Color.Aqua;
            lblErrorMsg.Text = Resources.Resource.CheckVisitnumbercannotbeleftblank;
        }


    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        gvNightCheckVisitAction.EditIndex = -1;
        FillgvNightCheckVisitActionAfterSave();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (txtCheckVisitDate.Text != "" && txtDate.Text != "")
        {
            if (DateTime.Parse(txtDate.Text) < DateTime.Parse(txtCheckVisitDate.Text))
            {
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Aqua;
                lblErrorMsg.Text = "Date Should always be greater than or equal to Check Visit Date";
                return;
            }
            else
            {
                txtDate.BackColor = System.Drawing.Color.Empty;
            }
        }
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.NightCheckVisitActionUpdate(DateTime.Parse(txtCheckVisitDate.Text), BaseUserID, txtCheckVisitActionNumber.Text);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
        {
            DisableFields();
            HideButtons();
            HideButtonBasedOnStatus();
            gvNightCheckVisitAction.Columns[0].Visible = true;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        gvNightCheckVisitAction.EditIndex = -1;
        FillgvNightCheckVisitActionAfterSave();
        Status = 0;
        FillgvNightCheckVisitActionAfterSave();
        gvNightCheckVisitAction.Columns[0].Visible = true;
        HideButtons();
        EnableFields();
        btnUpdate.Visible = true;
        btnCancel.Visible = true;
        txtCheckVisitNumber.Enabled = false;
        txtCheckVisitDate.Enabled = false;
     //   ddlAsmtCode.Enabled = true;
        // HideButtonBasedOnStatus();

    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        FillDetails();
        gvNightCheckVisitAction.EditIndex = -1;
        FillgvNightCheckVisitActionAfterSave();
        HideButtons();
        HideButtonBasedOnStatus();
        //Added by  on 29-May-2013
        FillClientId();
        ddlClientId.Enabled = true;
        ddlAsmtId.Items.Clear();
        ddlAsmtId.Enabled = false;
    }
    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        ClearFields();
        txtCheckVisitActionNumber.Text = "";
        lblCheckVisitActionStatus.Text = "";
        PanelGridView.Visible = false;
        //Added by  on 29-May-2013
        FillClientId();
        //ddlClientId.Enabled = true;
        ddlAsmtId.Items.Clear();
        ddlAsmtId.Enabled = false;
        //Added by  on 13-Jun-2013
        btnAddNew.Visible = false;
        btnSave.Visible = true;
        btnSave.Enabled = false;
        //End
    }
    /// <summary>
    /// Handles the Click event of the btnPlanAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnPlanAuthorize_Click(object sender, EventArgs e)
    {
        gvNightCheckVisitAction.EditIndex = -1;
        //Modify by  on 1-Jun-2013
        //FillgvNightCheckVisitActionAfterSave();
        FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();      //Added by  on 1-Jun-2013
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (txtCheckVisitDate.Text != "" && txtDate.Text != "")
        {
            if (DateTime.Parse(txtDate.Text) < DateTime.Parse(txtCheckVisitDate.Text))
            {
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Aqua;
                lblErrorMsg.Text = "Date Should always be greater than or equal to Check Visit Date";
                return;
            }
            else
            {
                txtDate.BackColor = System.Drawing.Color.Empty;
            }
        }
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (CheckPlanAuthorize() == true)
        {
            HideButtons();
            ds = objOperationManagement.NightCheckVisitActionPlanAuthorize(Resources.Resource.PlanAuthorized, txtCheckVisitActionNumber.Text, BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                lblCheckVisitActionStatus.Text = Resources.Resource.PlanAuthorized;
                gvNightCheckVisitAction.Columns[13].Visible = true;
                gvNightCheckVisitAction.Columns[14].Visible = true;
                HideButtonBasedOnStatus();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.PlanInformationDetailisblank;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnActionAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnActionAuthorize_Click(object sender, EventArgs e)
    {
        gvNightCheckVisitAction.EditIndex = -1;
        //Modify by  on 3-Jun-2013
        // FillgvNightCheckVisitActionAfterSave();
        FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
        //End
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (txtCheckVisitDate.Text != "" && txtDate.Text != "")
        {
            if (DateTime.Parse(txtDate.Text) < DateTime.Parse(txtCheckVisitDate.Text))
            {
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Aqua;
                lblErrorMsg.Text = "Date Should always be greater than or equal to Check Visit Date";
                return;
            }
            else
            {
                txtDate.BackColor = System.Drawing.Color.Empty;
            }
        }
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (CheckActionAuthorize() == true)
        {
            for (int i = 0; i < gvNightCheckVisitAction.Rows.Count; i++)
            {
                Label lblRowID = (Label)gvNightCheckVisitAction.Rows[i].FindControl("lblRowID");
                ds = objOperationManagement.NightCheckVisitActionAuthorize(Resources.Resource.ActionAuthorized, txtCheckVisitActionNumber.Text, BaseUserID, int.Parse(lblRowID.Text), Resources.Resource.Completed);
            }
            HideButtons();
            lblCheckVisitActionStatus.Text = Resources.Resource.ActionAuthorized;
            HideButtonBasedOnStatus();
            gvNightCheckVisitAction.Columns[0].Visible = false;
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.ActionInformationDetailisblank;
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvNightCheckVisitAction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisitAction_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvNightCheckVisitAction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisitAction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvNightCheckVisitAction.Columns[0].Visible = false;
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
                TextBox txtActionPlanned = (TextBox)e.Row.FindControl("txtActionPlanned");
                TextBox txtResponsibility = (TextBox)e.Row.FindControl("txtResponsibility");
                TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
                ImageButton imgResponsibility = (ImageButton)e.Row.FindControl("imgResponsibility");
                if (txtResponsibility != null)
                {
                    if (imgResponsibility != null)
                    {
                        imgResponsibility.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtResponsibility.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                    }

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
                if (txtResponsibility != null)
                {
                    txtResponsibility.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtResponsibility.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvNightCheckVisitAction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisitAction_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (Status == 1)
        {
            gvNightCheckVisitAction.EditIndex = -1;
            gvNightCheckVisitAction.DataSource = dtNightCheckVisitAction;
            gvNightCheckVisitAction.DataBind();
            btnEdit.Enabled = true;
            btnPlanAuthorize.Enabled = true;
            btnUpdate.Enabled = true;
            btnActionAuthorize.Enabled = true;
        }
        else if (Status == 0)
        {
            gvNightCheckVisitAction.EditIndex = -1;
            //Modify by  on 3-Jun-2013
            // FillgvNightCheckVisitActionAfterSave();
            FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
            //End
            btnEdit.Enabled = true;
            btnPlanAuthorize.Enabled = true;
            btnUpdate.Enabled = true;
            btnActionAuthorize.Enabled = true;
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvNightCheckVisitAction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisitAction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Status == 1)
        {
            //dtNightCheckVisitAction.Rows.RemoveAt(e.RowIndex);
            //gvNightCheckVisitAction.DataSource = dtNightCheckVisitAction;
            //gvNightCheckVisitAction.DataBind();
            //if (dtNightCheckVisitAction.Rows.Count == 0)
            //{
            //    FillgvNightCheckVisitAction();
            //}
        }
        else if (Status == 0)
        {
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvNightCheckVisitAction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisitAction_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //if (Status == 1)
        //{
        //    gvNightCheckVisitAction.EditIndex = e.NewEditIndex;
        //    gvNightCheckVisitAction.DataSource = dtNightCheckVisitAction;
        //    gvNightCheckVisitAction.DataBind();
        //}
        //else if (Status == 0)
        //{
        if (txtCheckVisitActionNumber.Text != "")
        {
            gvNightCheckVisitAction.EditIndex = e.NewEditIndex;
            //Modify by  on 1-Jun-2013
            //FillgvNightCheckVisitActionAfterSave();
            FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
            //End
            btnEdit.Enabled = false;
            btnPlanAuthorize.Enabled = false;
            btnUpdate.Enabled = false;
            btnActionAuthorize.Enabled = false;
        }
        else
        {
            gvNightCheckVisitAction.EditIndex = e.NewEditIndex;
            FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
            btnEdit.Enabled = false;
            btnPlanAuthorize.Enabled = false;
            btnUpdate.Enabled = false;
            btnActionAuthorize.Enabled = false;
        }
        //}

    }
    /// <summary>
    /// Handles the RowUpdating event of the gvNightCheckVisitAction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisitAction_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int flag = 1;
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        Label lblObservationType = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblObservationType");
        Label lblItemDescEdit = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblItemDescEdit");
        Label lblObservation = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblObservation");
        Label lblRowIDEdit = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblRowIDEdit");
        TextBox txtActionPlanned = (TextBox)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("txtActionPlanned");
        TextBox txtResponsibility = (TextBox)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("txtResponsibility");
        Label lblName = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblName");
        Label lblDesignation = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblDesignation");
        TextBox txtActionDate = (TextBox)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("txtActionDate");
        TextBox txtRemarks = (TextBox)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("txtRemarks");
        Label lblAutoIDEdit = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblAutoIDEdit");
        Label lblComplainAgainst = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblComplainAgainst");
        Label lblEmployeeName = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblEmployeeName");
        Label lblEmployeeDesignation = (Label)gvNightCheckVisitAction.Rows[e.RowIndex].FindControl("lblEmployeeDesignation");
        if (txtActionDate.Text == "")
        {

        }
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (Status == 1)
        {   
            //Modify by  on 20-Jun-2013
            //dtNightCheckVisitAction.Rows[e.RowIndex][0] = lblItemDescEdit.Text;
            //dtNightCheckVisitAction.Rows[e.RowIndex][1] = lblObservationType.Text;
            //dtNightCheckVisitAction.Rows[e.RowIndex][2] = lblObservation.Text;
            //dtNightCheckVisitAction.Rows[e.RowIndex][3] = lblRowIDEdit.Text;
            dtNightCheckVisitAction.Rows[e.RowIndex][5] = txtActionPlanned.Text;
            dtNightCheckVisitAction.Rows[e.RowIndex][6] = txtResponsibility.Text;
            if (txtActionDate.Text == "")
            {
                dtNightCheckVisitAction.Rows[e.RowIndex][7] = ConvertDateToNull(CheckDateNull(txtActionDate.Text));
            }
            else
            {
                dtNightCheckVisitAction.Rows[e.RowIndex][7] = txtActionDate.Text;
            }
            dtNightCheckVisitAction.Rows[e.RowIndex][8] = txtRemarks.Text;
            dtNightCheckVisitAction.Rows[e.RowIndex][9] = lblDesignation.Text;
            dtNightCheckVisitAction.Rows[e.RowIndex][10] = lblName.Text;
            //dtNightCheckVisitAction.Rows[e.RowIndex][11] = 0;
            //dtNightCheckVisitAction.Rows[e.RowIndex][12] = lblComplainAgainst.Text;
            //dtNightCheckVisitAction.Rows[e.RowIndex][13] = lblEmployeeName.Text;
            //dtNightCheckVisitAction.Rows[e.RowIndex][14] = lblEmployeeDesignation.Text;
            gvNightCheckVisitAction.EditIndex = -1;
            gvNightCheckVisitAction.DataSource = dtNightCheckVisitAction;
            gvNightCheckVisitAction.DataBind();
            btnEdit.Enabled = true;
            btnPlanAuthorize.Enabled = true;
            btnUpdate.Enabled = true;
            btnActionAuthorize.Enabled = true;

            //Added by  on 20-Jun-2013
            if (flag == 1)
            {
                if (txtCheckVisitActionNumber.Text != "")
                {
                    ds = objOperationManagement.NightCheckActionDetailUpdate(lblAutoIDEdit.Text, txtActionPlanned.Text, txtResponsibility.Text, txtActionDate.Text, txtRemarks.Text, DateTime.Parse(txtCheckVisitDate.Text), BaseUserID);
                    gvNightCheckVisitAction.EditIndex = -1;
                    //Modify by  on 1-Jun-2013
                    //FillgvNightCheckVisitActionAfterSave();
                    FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
                    txtEmployeeID_TextChanged(sender, e);
                    //End
                    btnEdit.Enabled = true;
                    btnPlanAuthorize.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnActionAuthorize.Enabled = true;
                }
                else
                {
                    ds = objOperationManagement.NightCheckActionDetailUpdate(lblAutoIDEdit.Text, txtActionPlanned.Text, txtResponsibility.Text, txtActionDate.Text, txtRemarks.Text, DateTime.Parse(txtCheckVisitDate.Text), BaseUserID);
                    gvNightCheckVisitAction.EditIndex = -1;
                    FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
                    btnEdit.Enabled = true;
                    btnPlanAuthorize.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnActionAuthorize.Enabled = true;
                }
            }
        }
        else if (Status == 0)
        {
            if (lblCheckVisitActionStatus.Text == Resources.Resource.PlanAuthorized)
            {
                if (DateTime.Parse(txtActionDate.Text) >= DateTime.Parse(txtCheckVisitDate.Text))
                {
                    txtActionDate.BackColor = System.Drawing.Color.Empty;
                    flag = 1;
                }
                else
                {
                    lblErrorMsg.Text = "Action Date Should always be greater than or equal to Check visit Date";
                    ToolkitScriptManager2.SetFocus(txtActionDate);
                    txtActionDate.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
            }
            if (flag == 1)
            {
                if (txtCheckVisitActionNumber.Text != "")
                {
                    ds = objOperationManagement.NightCheckActionDetailUpdate(lblAutoIDEdit.Text, txtActionPlanned.Text, txtResponsibility.Text, txtActionDate.Text, txtRemarks.Text, DateTime.Parse(txtCheckVisitDate.Text), BaseUserID);
                    gvNightCheckVisitAction.EditIndex = -1;
                    //Modify by  on 1-Jun-2013
                    //FillgvNightCheckVisitActionAfterSave();
                    FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
                    txtEmployeeID_TextChanged(sender, e);
                    //End
                    btnEdit.Enabled = true;
                    btnPlanAuthorize.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnActionAuthorize.Enabled = true;
                }
                else
                {
                    ds = objOperationManagement.NightCheckActionDetailUpdate(lblAutoIDEdit.Text, txtActionPlanned.Text, txtResponsibility.Text, txtActionDate.Text, txtRemarks.Text, DateTime.Parse(txtCheckVisitDate.Text), BaseUserID);
                    gvNightCheckVisitAction.EditIndex = -1;
                    FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber();
                    btnEdit.Enabled = true;
                    btnPlanAuthorize.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnActionAuthorize.Enabled = true;
                }
            }
            //HideButtons();
            //HideButtonBasedOnStatus();
        }
    }

    /// <summary>
    /// Hides the button based on status.
    /// </summary>
    private void HideButtonBasedOnStatus()
    {
        if (lblCheckVisitActionStatus.Text == Resources.Resource.Fresh)
        {
            int flag = 0;
            btnSave.Visible = false;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                //btnEdit.Visible = true;
                if (IsAuthorizationAccess == true)
                {
                    btnPlanAuthorize.Visible = true;
                }
                else
                {
                    btnPlanAuthorize.Visible = false;
                }
                txtCheckVisitDate.Enabled = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                   // btnEdit.Visible = true;
                }
                if (IsAuthorizationAccess == true)
                {
                    btnPlanAuthorize.Visible = true;
                }
                else
                {
                    btnPlanAuthorize.Visible = false;
                }
            }
        }
        if (lblCheckVisitActionStatus.Text == Resources.Resource.PlanAuthorized)
        {
             int flag = 0;
             txtCheckVisitDate.Enabled = false;
             gvNightCheckVisitAction.Columns[13].Visible = true;
             gvNightCheckVisitAction.Columns[14].Visible = true;
             if (IsAuthorizationAccess == true)
             {
                 btnActionAuthorize.Visible = true;
             }
             else
             {
                 btnActionAuthorize.Visible = false;
             }
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
                 if (IsModifyAccess == true)
                 {
                     btnEdit.Visible = true;
                 }
                 if (IsAuthorizationAccess == true)
                 {
                     btnActionAuthorize.Visible = true;
                 }
                 else
                 {
                     btnActionAuthorize.Visible = false;
                 }
             }
           
        }
        if (lblCheckVisitActionStatus.Text == Resources.Resource.ActionAuthorized)
        {
            gvNightCheckVisitAction.Columns[14].Visible = true;
            gvNightCheckVisitAction.Columns[13].Visible = true;
            gvNightCheckVisitAction.Columns[0].Visible = false;
            txtCheckVisitDate.Enabled = false;
        }
    }
    /// <summary>
    /// Checks the plan authorize.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckPlanAuthorize()
    {
        int flag = 1;
        for (int i = 0; i < gvNightCheckVisitAction.Rows.Count; i++)
        {
            Label lblActionPlanned = (Label)gvNightCheckVisitAction.Rows[i].FindControl("lblActionPlanned");
            if (lblActionPlanned.Text == "")
            {
                gvNightCheckVisitAction.Rows[i].BackColor = System.Drawing.Color.Aqua;
                flag = 0;
                //return false;
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
    /// Clears the asmt details.
    /// </summary>
    private void ClearAsmtDetails()
    {

        //txtAssignNo.Text = "";
        txtAddressDesc.Text = "";
        txtAddressID.Text = "";
        txtAreaDesc.Text = "";
        txtAreaID.Text = "";
        txtBranchID.Text = "";
        txtBranchIDDesc.Text = "";
        txtCustomerDesc.Text = "";
        //txtCustomerID.Text = "";
    }
    /// <summary>
    /// Enables the fields.
    /// </summary>
    private void EnableFields()
    {

    }
    /// <summary>
    /// Disables the fields.
    /// </summary>
    private void DisableFields()
    {
    }
    /// <summary>
    /// Clears the fields.
    /// </summary>
    private void ClearFields()
    {
        ClearAsmtDetails();
        txtCheckVisitNumber.Text = "";
        txtCheckVisitType.Text = "";
        txtEmployeeID.Text = "";
        txtEmployeeName.Text = "";
        txtTimeFrom.Text = "";
        txtTimeTo.Text = "";
        txtCheckVisitDate.Text = "";
        txtDate.Text = "";
        txtDesignation.Text = "";       //Added by  on 3-Jun-2013
    }
    /// <summary>
    /// Hides the buttons.
    /// </summary>
    private void HideButtons()
    {
        btnActionAuthorize.Visible = false;
        btnAddNew.Visible = false;
        btnCancel.Visible = false;
        btnEdit.Visible = false;
        btnPlanAuthorize.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }
    /// <summary>
    /// Enables the buttons.
    /// </summary>
    private void EnableButtons()
    {
        if (IsAuthorizationAccess == true)
        {
            btnActionAuthorize.Visible = true;
        }
        else
        {
            btnActionAuthorize.Visible = false;
        }
        btnAddNew.Enabled = true;
        btnCancel.Enabled = true;
        btnEdit.Enabled = true;
        if (IsAuthorizationAccess == true)
        {
            btnPlanAuthorize.Visible = true;
        }
        else
        {
            btnPlanAuthorize.Visible = false;
        }
        btnSave.Enabled = true;
        btnUpdate.Enabled = true;
    }
    /// <summary>
    /// Disables the buttons.
    /// </summary>
    private void DisableButtons()
    {
        btnActionAuthorize.Visible = false;
        btnAddNew.Enabled = false;
        btnCancel.Enabled = false;
        btnEdit.Enabled = false;
        btnPlanAuthorize.Visible = false;
        btnSave.Enabled = false;
        btnUpdate.Enabled = false;
    }
    /// <summary>
    /// Checks the action authorize.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckActionAuthorize()
    {
        int flag = 1;
        for (int i = 0; i < gvNightCheckVisitAction.Rows.Count; i++)
        {
            Label lblActionDate = (Label)gvNightCheckVisitAction.Rows[i].FindControl("lblActionDate");
            if (lblActionDate.Text == "")
            {
                gvNightCheckVisitAction.Rows[i].BackColor = System.Drawing.Color.Aqua;
                flag = 0;
                //return false;
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

    #region Function to Convert date to null if date=01/01/0001
    /// <summary>
    /// Converts the date to null.
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

    #region Function to check whether date is null or not
    /// <summary>
    /// Checks the date null.
    /// </summary>
    /// <param name="strDate">The string date.</param>
    /// <returns>System.String.</returns>
    private string CheckDateNull(string strDate)
    {
        if (strDate == "")
        {
            DateTime dt = Convert.ToDateTime(null);
            return dt.ToString();
        }
        else
        {
            return strDate;
        }
    }
    #endregion

    //Modify by  on 31-May-2013
    /// <summary>
    /// Fillgvs the night check visit action based on night check visit number.
    /// </summary>
    private void FillgvNightCheckVisitActionBasedOnNightCheckVisitNumber()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        if (!string.IsNullOrEmpty(txtCheckVisitActionNumber.Text))
        {
            ds = objOperationManagement.NightCheckVisitActionDetailGetAll(txtCheckVisitActionNumber.Text, txtCheckVisitNumber.Text, Resources.Resource.Pending, ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value.ToString(), BaseLocationAutoID);
        }
        else
        {
            ds = objOperationManagement.NightCheckVisitActionGetAll(txtCheckVisitNumber.Text, Resources.Resource.Pending, ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value.ToString(), BaseLocationAutoID);
        }
        dt = ds.Tables[0];
        //Added by  on 30-May-2013
        PanelGridView.Visible = true;
        //to fix empty gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());

            //Added by  on 3-Jun-2013
            PanelGridView.Visible = false;
            ClearFields();
            lblErrorMsg.Text = Resources.Resource.RecordNotPending;
        }
        dtNightCheckVisitAction = dt;
        gvNightCheckVisitAction.DataSource = dt;
        gvNightCheckVisitAction.DataBind();
        
        if (dtflag == 0)//to fix empety gridview
        {
            gvNightCheckVisitAction.Rows[0].Visible = false;
            //Added by  on 3-Jun-2013
            ddlClientId.Items.Clear();
            ddlAsmtId.Items.Clear();
        }
    }

    /// <summary>
    /// Fillgvs the night check visit action after save.
    /// </summary>
    private void FillgvNightCheckVisitActionAfterSave()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objOperationManagement.NightCheckVisitActionDetailGet(txtCheckVisitActionNumber.Text, BaseLocationAutoID);
        dt = ds.Tables[0];

        //to fix empty gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        dtNightCheckVisitAction = dt.Copy();
        gvNightCheckVisitAction.DataSource = dt;
        gvNightCheckVisitAction.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvNightCheckVisitAction.Rows[0].Visible = false;
        }
    }


    /// <summary>
    /// Handles the TextChanged event of the txtDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtDate,lblErrorMsg);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtActionDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtActionDate_TextChanged(object sender, EventArgs e)
    {
        TextBox txtActionDt = (TextBox)sender;
        GridViewRow row = (GridViewRow)txtActionDt.NamingContainer;
        TextBox txtActionDate = (TextBox)gvNightCheckVisitAction.Rows[row.RowIndex].FindControl("txtActionDate");
        ConvertStringToDateFormat(txtActionDate,lblErrorMsg );
    }

    #region Coded Added by 
    //Added by  on 31-May-2013
    /// <summary>
    /// Fills the client identifier.
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
        //txtCustomerDesc.Text = ddlClientId.SelectedItem.Text;
        FillAsmt();
    }

    //Get Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Fills the asmt.
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
        try
        {
            FillAsmtDetail();
            //btnSave.Enabled = true;
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            btnSave.Enabled = false;
        }
    }

    //Added by  on 29-May-2013
    //Set Client Code on based on txtIncidentNo
    /// <summary>
    /// Sets the client identifier.
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

    //Set Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Sets the asmt.
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
    #endregion
}
