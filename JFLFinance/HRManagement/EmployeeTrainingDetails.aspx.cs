// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
// DESCRIPTION      : EmployeeTrainingDetails is used to handle EmployeeTraining event/actions and communicate to and UI Screen.
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeTrainingDetails.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using BL;
using System.Web.UI;

/// <summary>
/// Class HRManagement_EmployeeTrainingDetails
/// </summary>
public partial class HRManagement_EmployeeTrainingDetails : BasePage
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //AddLinkButton();
    }
    /// <summary>
    /// Function called on Page Load event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMsg.Text = string.Empty;
        if (!IsPostBack)
        {
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.TrainingDetail + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            Page.GetPostBackEventReference(btnOKValidTillDate);
            if (IsReadAccess == true)
            {
                var employeeNumber = Request.QueryString["EmployeeNumber"];
                var firstName = Request.QueryString["FirstName"];
                var lastName = Request.QueryString["LastName"];

                txtEmployeeNumber.Text = employeeNumber;
                txtEmployeeName.Text = firstName + @" " + lastName;

                FillAllTrainings();
                FetchTrainingDetailsBasedOnSelectedTraining();
                FillgvTraining(txtEmployeeNumber.Text);


            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }



    }

    /// <summary>
    /// Function used to fill Training Drop Down List.
    /// </summary>
    public void FillAllTrainings()
    {
        var objMastersManagement = new MastersManagement();
        var ds = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTraining.DataSource = ds.Tables[0];
            ddlTraining.DataValueField = "TrainingCode";
            ddlTraining.DataTextField = "TrainingDesc";
            ddlTraining.DataBind();
        }
        if (ddlTraining.Text == "")
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow , Value = "" };
            ddlTraining.Items.Add(li);
        }
    }

    /// <summary>
    /// Function used to get training details based on Selected Training from Drop Down List.
    /// </summary>
    public void FetchTrainingDetailsBasedOnSelectedTraining()
    {
        var objMastersManagement = new MastersManagement();
        var ds = objMastersManagement.TrainingDetailsGet(BaseCompanyCode, ddlTraining.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtTrainingCategory.Text = ds.Tables[0].Rows[0]["TrainingCategory"].ToString();
            txtTrainingLevel.Text = ds.Tables[0].Rows[0]["TrainingLevel"].ToString();
        }
    }

    /// <summary>
    /// Function called on Training Drop Down List SelectedIndexChanged event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchTrainingDetailsBasedOnSelectedTraining();
    }

    /// <summary>
    /// Function called on Active Drop Down List SelectedIndexChanged event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlActive_SelectedIndexChanged(object sender, EventArgs eventArgs)
    {

        gvEmpRefresherTrainingDetails.EditIndex = -1;
        var ddlActivate = (DropDownList)sender;
        var row = (GridViewRow)ddlActivate.NamingContainer;
        var lblItmTrainingCode = (LinkButton)gvTraining.Rows[row.RowIndex].FindControl("lblItmTrainingCode");
        var labelItemTrainingDate = (Label)gvTraining.Rows[row.RowIndex].FindControl("LabelItemTrainingDate");
        var labelItemValidTillDate = (Label)gvTraining.Rows[row.RowIndex].FindControl("LabelItemValidTillDate");

        if (ddlActivate.SelectedValue == "0")
        {
           
            
            hfTrainingCode.Value = lblItmTrainingCode.Text;
            hfTrainingDate.Value = labelItemTrainingDate.Text;
            hfValidTillDate.Value = labelItemValidTillDate.Text;
        }
        else if (ddlActivate.SelectedValue == "1")
        {
            
            ReactivateTraining(lblItmTrainingCode.Text, Convert.ToDateTime(labelItemTrainingDate.Text), Convert.ToDateTime(labelItemValidTillDate.Text));
            hfTrainingCode.Value = lblItmTrainingCode.Text;
            hfTrainingDate.Value = labelItemTrainingDate.Text;
            hfValidTillDate.Value = labelItemValidTillDate.Text;
        }
    }

    private void ReactivateTraining(string trainingCode,DateTime trainingDate,DateTime validTillDate)
    {

        var objTrainingValid = new HRManagement();
        var ds = objTrainingValid.TrainingReActivation(BaseCompanyCode, trainingCode, txtEmployeeNumber.Text, trainingDate, validTillDate,BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0][0].ToString());
            FillgvEmpRefresherTrainingDetails(trainingCode, Convert.ToString(trainingDate), txtEmployeeNumber.Text);
            FillgvTraining(txtEmployeeNumber.Text);
          
        }
        
    }
    
    protected void btnOKValidTillDate_Click(object sender, EventArgs eventArgs)
    {
        var objCommon = new Common();
        if (objCommon.IsValidDate(txtValidTillDate.Text))
        {
            PanelEmpRefresherTrainingDetails.Visible = true;

            if (CompareDates(DateTime.Parse(hfValidTillDate.Value), DateTime.Parse(txtValidTillDate.Text)) == 1 && CompareDates(DateTime.Parse(hfTrainingDate.Value), DateTime.Parse(txtValidTillDate.Text)) == 2)
            {
                var objMasterManagment = new HRManagement();
                var ds1 = objMasterManagment.GetScheduleListEmpWise(txtEmployeeNumber.Text, hfTrainingCode.Value,
                    txtValidTillDate.Text);
                if (ds1 != null && ds1.Tables.Count > 0)
                {
                    divPopInactive.Style.Add("display", "none");
                    divWarning.Style.Add("display", "block");

                }
                else
                {
                    var ds = objMasterManagment.DeactivateEmployee(BaseCompanyCode, txtEmployeeNumber.Text, Convert.ToDateTime(hfTrainingDate.Value),
                        hfTrainingCode.Value, txtValidTillDate.Text, hfValidTillDate.Value);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (GridViewRow gvRow in gvTraining.Rows)
                        {
                            var lblItmTrainingCode = (LinkButton) gvRow.FindControl("lblItmTrainingCode");
                            var labelItemTrainingDate = (Label) gvRow.FindControl("LabelItemTrainingDate");
                            var labelItemTrainingDesc = (Label) gvRow.FindControl("LabelItemTrainingDesc");
                            
                            var ddlActivate = (DropDownList) gvRow.FindControl("ddlActive");

                            if (lblItmTrainingCode.Text == hfTrainingCode.Value &&
                                labelItemTrainingDate.Text == hfTrainingDate.Value)
                            {
                                ddlActivate.Enabled = false;
                                lblTrainingGridInfo.Text = lblItmTrainingCode.Text + @" (" + labelItemTrainingDesc.Text +
                                                           @") ------- Training Start Date : " +
                                                           labelItemTrainingDate.Text +
                                                           @" ------- Valid Till Date : " + txtValidTillDate.Text;
                            }
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0][0].ToString());

                        }
                        FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value,
                            txtEmployeeNumber.Text);
                        FillgvTraining(txtEmployeeNumber.Text);

                        divPopInactive.Style.Add("display", "none");
                    }
                }

            }
            else
            {
                if (CompareDates(DateTime.Parse(hfTrainingDate.Value), DateTime.Parse(txtValidTillDate.Text)) == 0)
                {
                    lblErrorMsg.Text = Resources.Resource.InvalidToDate;
                    txtValidTillDate.Text = "";
                    divPopInactive.Style.Add("display", "none");

                }
                lblErrorMsg.Text = Resources.Resource.InvalidToDate;
                txtValidTillDate.Text = "";
                FillgvTraining(txtEmployeeNumber.Text);


            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.InvalidateFromDate;
            txtValidTillDate.Text = "";
            txtValidTillDate.Focus();
            FillgvTraining(txtEmployeeNumber.Text);
        }

    }

    protected void btnCancelValidTillDate_Click(object sender, EventArgs eventArgs)
    {
        FillgvTraining(txtEmployeeNumber.Text);

        divPopInactive.Style.Add("display", "none");
    }

    /// <summary>
    /// This is used for popup to Deactivate the training on OK validation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    protected void btnPopOK_Click(object sender, EventArgs eventArgs)
    {

        var objMasterManagment = new HRManagement();

        var ds = objMasterManagment.DeactivateEmployee(BaseCompanyCode, txtEmployeeNumber.Text,Convert.ToDateTime(hfTrainingDate.Value), hfTrainingCode.Value, txtValidTillDate.Text, hfValidTillDate.Value);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (GridViewRow gvRow in gvTraining.Rows)
            {
                var lblItmTrainingCode = (LinkButton)gvRow.FindControl("lblItmTrainingCode");
                var labelItemTrainingDate = (Label)gvRow.FindControl("LabelItemTrainingDate");
                var labelItemTrainingDesc = (Label)gvRow.FindControl("LabelItemTrainingDesc");

                var ddlActivate = (DropDownList)gvRow.FindControl("ddlActive");

                if (lblItmTrainingCode.Text == hfTrainingCode.Value && labelItemTrainingDate.Text == hfTrainingDate.Value)
                {
                    ddlActivate.Enabled = false;
                    lblTrainingGridInfo.Text = lblItmTrainingCode.Text + @" (" + labelItemTrainingDesc.Text +
                                  @") ------- Training Start Date : " + labelItemTrainingDate.Text +
                                  @" ------- Valid Till Date : " + txtValidTillDate.Text;
                }
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0][0].ToString());

            }
            FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value, txtEmployeeNumber.Text);
            FillgvTraining(txtEmployeeNumber.Text);

            //pup.HidePopupWindow();
            divWarning.Style.Add("display", "none");

        }


    }

    protected void btnPopCancel_Click(object sender, EventArgs eventArgs)
    {
        divWarning.Style.Add("display", "none");
        
    }



    /// <summary>
    /// Function called on TrainingDate Textbox TextChanged event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtTrainingDate_TextChanged(object sender, EventArgs e)
    {
        if (Master != null)
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            ConvertStringToDateFormat(txtTrainingDate);

            var objTrainingValidDate = new HRManagement();
            var objCommon = new Common();

            if (txtTrainingDate.Text == "")
            {
                lblTxtTrainingValidTillDate.Text = "";
            }
            else
            {
                if (objCommon.IsValidDate(txtTrainingDate.Text))
                {
                    var ds = objTrainingValidDate.TrainingValidToDateGet(BaseCompanyCode, ddlTraining.SelectedValue, DateTime.Parse(txtTrainingDate.Text));
                    if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
                    {
                        lblTxtTrainingValidTillDate.Text = DateFormat(ds.Tables[0].Rows[0]["TrainingToDate"].ToString());
                    }
                    else
                    {
                        lblTxtTrainingValidTillDate.Text = "";

                        toolkitScriptManager1.SetFocus(txtTrainingDate);
                        lblErrorMsg.Text = Resources.Resource.InvalidateFromDate;
                    }
                }
                else
                {
                    lblTxtTrainingValidTillDate.Text = "";
                }
            }


            toolkitScriptManager1.SetFocus(txtTrainingDate);
        }
    }

    /// <summary>
    /// Function used to convert string in Date format.
    /// </summary>
    /// <param name="txtDate">The TXT date.</param>
    private void ConvertStringToDateFormat(TextBox txtDate)
    {
        txtDate.BackColor = System.Drawing.Color.Empty;
        var objCommon = new Common();
        if (Master != null)
        {
            var toolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            if (objCommon.IsValidDate(txtDate.Text))
                txtDate.Text = DateTime.Parse(txtDate.Text).ToString("dd-MMM-yyyy");
            else
            {
                var date = objCommon.ConvertToDate(txtDate.Text);
                if (date == "1")
                {
                    lblErrorMsg.Text = @"Year not in correct format ";
                    txtDate.Text = txtDate.Text;
                    toolkitScriptManager2.SetFocus(txtDate);
                    txtDate.BackColor = System.Drawing.Color.Red;
                }
                else if (date == "2")
                {
                    lblErrorMsg.Text = @"Month not in correct format";
                    txtDate.Text = txtDate.Text;
                    toolkitScriptManager2.SetFocus(txtDate);
                    txtDate.BackColor = System.Drawing.Color.Red;
                }
                else if (date == "3")
                {
                    lblErrorMsg.Text = @"Day not in correct format";
                    txtDate.Text = txtDate.Text;
                    toolkitScriptManager2.SetFocus(txtDate);
                    txtDate.BackColor = System.Drawing.Color.Red;
                }
                else if (date == "4")
                {
                    lblErrorMsg.Text = @"Not a leap year";
                    txtDate.Text = txtDate.Text;
                    toolkitScriptManager2.SetFocus(txtDate);
                    txtDate.BackColor = System.Drawing.Color.Red;
                }
                else if (date == "5")
                {
                    lblErrorMsg.Text = @"Number of days not correct";
                    txtDate.Text = txtDate.Text;
                    toolkitScriptManager2.SetFocus(txtDate);
                    txtDate.BackColor = System.Drawing.Color.Red;
                }
                else if (date == "6")
                {
                    lblErrorMsg.Text = @"Date not in correct format";
                    txtDate.Text = txtDate.Text;
                    toolkitScriptManager2.SetFocus(txtDate);
                    txtDate.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtDate.Text = date;
                    txtDate.BackColor = System.Drawing.Color.Empty;
                }
            }
        }
    }

    /// <summary>
    /// Function called on Button Submit Click event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var objHrManagement = new HRManagement();

        if ((txtTrainingDate.Text == "") || (lblTxtTrainingValidTillDate.Text == ""))
        {
            lblErrorMsg.Text = @"Training Date Or Valid Till Date Cannot Be Blank";
        }
        else
        {
            DataSet dsTraining;
            using (var tx = TransactionUtility.CreateTransactionScope())
            {
                var dsEmpJoinCheck = objHrManagement.EmployeeDetailUpdate(txtEmployeeNumber.Text, BaseLocationAutoID);
                if (dsEmpJoinCheck != null && dsEmpJoinCheck.Tables.Count > 0 && dsEmpJoinCheck.Tables[0].Rows.Count > 0)
                {
                    if (DateTime.Parse(txtTrainingDate.Text) < DateTime.Parse(dsEmpJoinCheck.Tables[0].Rows[0]["FourTeenYears"].ToString()))
                    {
                        lblErrorMsg.Text = @"Training Date Cannot Be Less Than A Date Less Than 14 Years Since Date of Birth";
                        return;
                    }
                }

                dsTraining = objHrManagement.EmployeeTrainingDetailsInsert(txtEmployeeNumber.Text, BaseCompanyCode, ddlTraining.SelectedItem.Value, "0", BaseUserID, DateTime.Parse(txtTrainingDate.Text), DateTime.Parse(lblTxtTrainingValidTillDate.Text));
                tx.Complete();
            }
            if (dsTraining != null && dsTraining.Tables.Count > 0 && dsTraining.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, dsTraining.Tables[0].Rows[0]["MessageID"].ToString());

            }
            FillgvTraining(txtEmployeeNumber.Text);
            txtTrainingDate.Text = "";
            lblTxtTrainingValidTillDate.Text = "";
        }
    }

    /// <summary>
    /// Function called on Button Cancel Click Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        var status = Resources.Resource.Update;
        Response.Redirect("EmployeeMaster.aspx?strStatus=" + status + "&strEmployeeNumber=" + txtEmployeeNumber.Text);
    }

    /// <summary>
    /// Function used to fill Grid View Training.
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    public void FillgvTraining(string strEmployeeNumber)
    {

        var objHrManagement = new HRManagement();
        var dtflag = 1;
        var dsTraining = objHrManagement.EmployeeTrainingGet(BaseCompanyCode, strEmployeeNumber);
        var dtTraining = dsTraining.Tables[0];
        if (dtTraining.Rows.Count == 0)
        {
            dtflag = 0;
            dtTraining.Rows.Add(dtTraining.NewRow());
        }
        gvTraining.DataSource = dtTraining;
        gvTraining.DataBind();

        if (dtflag == 0)
        {
            gvTraining.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Function called on Grid View Training RowDataBound Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="T:System.Web.UI.WebControls.GridViewRowEventArgs">GridViewRowEventArgs</see> that contains the event data.</param>
    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var objGridViewRow = e.Row;
        var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");

        var ds = new DataSet();

        if (lblSerialNo != null)
        {
            var serialNo = gvTraining.PageIndex * gvTraining.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvTraining.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // AddLinkButton();
            var hfIsActive = (HiddenField)e.Row.FindControl("hfIsActive");
            var ibDeactivateTran = (ImageButton)e.Row.FindControl("IBDeactivateTran");
            var lblItmTrainingCode = (LinkButton)e.Row.FindControl("lblItmTrainingCode");

            var labelItemTrainingDesc = (Label)e.Row.FindControl("LabelItemTrainingDesc");
            var labelItemTrainingDate = (Label)e.Row.FindControl("LabelItemTrainingDate");
            var labelItemValidTillDate = (Label)e.Row.FindControl("LabelItemValidTillDate");
            var ibDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
            var ddlActive = (DropDownList)e.Row.FindControl("ddlActive");
            hfTrainingCode.Value = lblItmTrainingCode.Text;
            hfTrainingDate.Value = labelItemTrainingDate.Text;
            hfValidTillDate.Value = labelItemValidTillDate.Text;
            if (hfIsActive.Value == "False")
            {
                ibDeactivateTran.Enabled = false;
                ddlActive.SelectedValue = @"0";
                //ddlActive.Enabled = false;
                ddlActive.ForeColor = System.Drawing.Color.Red;
                lblItmTrainingCode.ForeColor = System.Drawing.Color.Red;
                labelItemTrainingDesc.ForeColor = System.Drawing.Color.Red;
                ibDeactivateTran.ImageUrl = "~/Images/deactivateBtn.gif";
                labelItemTrainingDate.ForeColor = System.Drawing.Color.Red;
                labelItemValidTillDate.ForeColor = System.Drawing.Color.Red;
                if (lblSerialNo != null) lblSerialNo.ForeColor = System.Drawing.Color.Red;
                ibDeleteTran.Visible = false;

            }
            else
            {
                ibDeactivateTran.Enabled = true;
                lblItmTrainingCode.ForeColor = System.Drawing.Color.Black;
                labelItemTrainingDesc.ForeColor = System.Drawing.Color.Black;
                ibDeactivateTran.ToolTip = Resources.Resource.Active;
                labelItemTrainingDate.ForeColor = System.Drawing.Color.Black;
                labelItemValidTillDate.ForeColor = System.Drawing.Color.Black;
                if (lblSerialNo != null) lblSerialNo.ForeColor = System.Drawing.Color.Black;
                ibDeleteTran.Visible = true;
            }

            if (IsModifyAccess == false)
            {
                var ibEditTran = (ImageButton)e.Row.FindControl("IBEditTran");
                if (ibEditTran != null)
                {
                    ibEditTran.Visible = false;
                }

            }
            if (IsDeleteAccess == false)
            {
                ibDeleteTran.Visible = false;
            }
            else
            {
                ibDeleteTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
            }

            ibDeactivateTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.DoYouwanttodeactivatetheSelectedTraining + "');";
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

        }
    }



    /// <summary>
    /// Function called on Grid View Training RowCommand Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //var lblTrainingCode = (LinkButton)e.CommandSource;
            //string lnk = lblTrainingCode.CommandArgument;
            //lblTrainingCode.Attributes.Add("","OnClick")

            var gvTraining = (GridView)sender;
            int RowIndex = Convert.ToInt32(e.CommandArgument.ToString());

            var lblItmTrainingCode = (LinkButton)gvTraining.Rows[RowIndex].FindControl("lblItmTrainingCode");
            var labelItemTrainingDate = (Label)gvTraining.Rows[RowIndex].FindControl("LabelItemTrainingDate");
            var labelItemTrainingDesc = (Label)gvTraining.Rows[RowIndex].FindControl("LabelItemTrainingDesc");
            var labelItemValidTillDate = (Label)gvTraining.Rows[RowIndex].FindControl("LabelItemValidTillDate");
            PanelEmpRefresherTrainingDetails.Visible = true;
            hfTrainingCode.Value = lblItmTrainingCode.Text;
            hfTrainingDate.Value = labelItemTrainingDate.Text;
            gvEmpRefresherTrainingDetails.EditIndex = -1;
            FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value, txtEmployeeNumber.Text);
            lblTrainingGridInfo.Text = lblItmTrainingCode.Text + @" (" + labelItemTrainingDesc.Text + @") ------- Training Start Date : " + labelItemTrainingDate.Text + @" ------- Valid Till Date : " + labelItemValidTillDate.Text;
           
        }
    }

    /// <summary>
    /// Function called on Grid View Training RowEditing Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTraining.EditIndex = e.NewEditIndex;
        FillgvTraining(txtEmployeeNumber.Text);
    }

    /// <summary>
    /// Function called on Link Button Training Code Click Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblTrainingCode_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lblItmTrainingCode = (LinkButton)gvTraining.Rows[row.RowIndex].FindControl("lblItmTrainingCode");
        var labelItemTrainingDate = (Label)gvTraining.Rows[row.RowIndex].FindControl("LabelItemTrainingDate");
        var labelItemTrainingDesc = (Label)gvTraining.Rows[row.RowIndex].FindControl("LabelItemTrainingDesc");
        var labelItemValidTillDate = (Label)gvTraining.Rows[row.RowIndex].FindControl("LabelItemValidTillDate");
        PanelEmpRefresherTrainingDetails.Visible = true;
        hfTrainingCode.Value = lblItmTrainingCode.Text;
        hfTrainingDate.Value = labelItemTrainingDate.Text;
        FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value, txtEmployeeNumber.Text);
        lblTrainingGridInfo.Text = lblItmTrainingCode.Text + @" (" + labelItemTrainingDesc.Text + @") ------- Training Start Date : " + labelItemTrainingDate.Text + @" ------- Valid Till Date : " + labelItemValidTillDate.Text;
    }

    /// <summary>
    /// Function used to filled Grid View EmpRefresherTrainingDetails.
    /// </summary>
    /// <param name="strTrainingCode">The STR training code.</param>
    /// <param name="strTrainingDate">The STR training date.</param>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    private void FillgvEmpRefresherTrainingDetails(string strTrainingCode, string strTrainingDate, string strEmployeeNumber)
    {
        var objblHrManagement = new HRManagement();
        var dtflag = 1;
        var ds = objblHrManagement.RefresherTrainingDetailsGet(BaseCompanyCode, strTrainingCode, strEmployeeNumber, DateTime.Parse(strTrainingDate));
        var dt = ds.Tables[0];
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvEmpRefresherTrainingDetails.DataSource = dt;
        gvEmpRefresherTrainingDetails.DataBind();

        if (dtflag == 0)
        {
            gvEmpRefresherTrainingDetails.Rows[0].Visible = false;
        }
    }

    /// <summary>
    /// Function called on Grid View EmpRefresherTrainingDetails PageIndexChanging Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmpRefresherTrainingDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmpRefresherTrainingDetails.PageIndex = e.NewPageIndex;
        gvEmpRefresherTrainingDetails.EditIndex = -1;
        FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value, txtEmployeeNumber.Text);
    }


    /// <summary>
    /// Function called on Grid View EmpRefresherTrainingDetails RowDataBound Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmpRefresherTrainingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var objGridViewRow = e.Row;
        var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");

        if (lblSerialNo != null)
        {
            var serialNo = gvEmpRefresherTrainingDetails.PageIndex * gvEmpRefresherTrainingDetails.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvEmpRefresherTrainingDetails.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var hfDeactivate = (HiddenField)e.Row.FindControl("hfDeactivate");
            var ibEditEmpRefresherTrainingDetailsDeactivate = (ImageButton)e.Row.FindControl("IBEditEmpRefresherTrainingDetails");
            if (hfDeactivate != null && ibEditEmpRefresherTrainingDetailsDeactivate != null)
            {
                ibEditEmpRefresherTrainingDetailsDeactivate.Enabled = hfDeactivate.Value != "False";
            }
            if (IsModifyAccess == false)
            {
                var ibEditEmpRefresherTrainingDetails = (ImageButton)e.Row.FindControl("IBEditEmpRefresherTrainingDetails");
                if (ibEditEmpRefresherTrainingDetails != null)
                {
                    ibEditEmpRefresherTrainingDetails.Visible = false;
                }

            }
            else
            {
                var imgbtnUpdateEmpRefresherTrainingDetails = (ImageButton)e.Row.FindControl("ImgbtnUpdateEmpRefresherTrainingDetails");
                if (imgbtnUpdateEmpRefresherTrainingDetails != null)
                {
                    imgbtnUpdateEmpRefresherTrainingDetails.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }

            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

        }
    }

    /// <summary>
    /// Function called on Grid View EmpRefresherTrainingDetails RowEditing Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvEmpRefresherTrainingDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmpRefresherTrainingDetails.EditIndex = e.NewEditIndex;
        FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value, txtEmployeeNumber.Text);
    }

    /// <summary>
    /// Function called on Grid View EmpRefresherTrainingDetails RowCancelingEdit Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvEmpRefresherTrainingDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmpRefresherTrainingDetails.EditIndex = -1;
        FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value, txtEmployeeNumber.Text);
    }

    /// <summary>
    /// Function called on Grid View EmpRefresherTrainingDetails RowDeleting Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvEmpRefresherTrainingDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    /// <summary>
    /// Function called on Grid View EmpRefresherTrainingDetails RowUpdating Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvEmpRefresherTrainingDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var lblEditItemTrainingAutoID = (Label)gvEmpRefresherTrainingDetails.Rows[e.RowIndex].FindControl("lblEditItemTrainingAutoID");
        var lblEditItemTrainingCode = (Label)gvEmpRefresherTrainingDetails.Rows[e.RowIndex].FindControl("lblEditItemTrainingCode");
        var lblEditItemEmployeeNumber = (Label)gvEmpRefresherTrainingDetails.Rows[e.RowIndex].FindControl("lblEditItemEmployeeNumber");
        var lblEditItemTrainingDate = (Label)gvEmpRefresherTrainingDetails.Rows[e.RowIndex].FindControl("lblEditItemTrainingDate");
        var lblEditItemRefTrainingDate = (Label)gvEmpRefresherTrainingDetails.Rows[e.RowIndex].FindControl("lblEditItemRefTrainingDate");
        var txtEditItemActualTrainingDate = (TextBox)gvEmpRefresherTrainingDetails.Rows[e.RowIndex].FindControl("txtEditItemActualTrainingDate");

        if (txtEditItemActualTrainingDate.Text == "" || txtEditItemActualTrainingDate.Text.Length.ToString() == "0")
        {
            lblErrorMsg.Text = @"Actual Training Date Cannot Be Blank";
            return;
        }


        var objblHrManagement = new HRManagement();

        var objCommon = new Common();
        lblErrorMsg.Text = "";
        if (!objCommon.IsValidDate(txtEditItemActualTrainingDate.Text))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            return;
        }

        var ds = objblHrManagement.EmployeeRefresherTrainingDetailsUpdate(BaseCompanyCode, lblEditItemTrainingAutoID.Text, lblEditItemTrainingCode.Text, lblEditItemEmployeeNumber.Text, DateTime.Parse(lblEditItemTrainingDate.Text), DateTime.Parse(lblEditItemRefTrainingDate.Text), DateTime.Parse(txtEditItemActualTrainingDate.Text), BaseUserID);

        lblErrorMsg.Text = ds.Tables[0].Rows[0]["Comment"].ToString();

        gvEmpRefresherTrainingDetails.EditIndex = -1;
        FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value, txtEmployeeNumber.Text);
        gvEmpRefresherTrainingDetails.DataBind();

    }

    /// <summary>
    /// Function called on Grid View Training RowUpdating Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    /// <summary>
    /// Function called on Grid View Training RowCancelingEdit Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTraining.EditIndex = -1;
        FillgvTraining(txtEmployeeNumber.Text);
    }

    /// <summary>
    /// Function called on Grid View Training RowDeleting Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objblMasterManagement = new BL.MastersManagement();
        var labelItemTrainingDate = (Label)gvTraining.Rows[e.RowIndex].FindControl("LabelItemTrainingDate");
        var dataKey = gvTraining.DataKeys[e.RowIndex];
        if (dataKey != null)
        {
            if (dataKey.Values != null)
            {
                var ds = objblMasterManagement.EmployeeTrainingDelete(BaseCompanyCode, dataKey.Values["TrainingCode"].ToString(), txtEmployeeNumber.Text, labelItemTrainingDate.Text);
                FillgvTraining(txtEmployeeNumber.Text);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        FillgvEmpRefresherTrainingDetails("UKN", "01-01-1900", txtEmployeeNumber.Text);
    }

    /// <summary>
    /// Function called on Grid View Training PageIndexChanging Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTraining.PageIndex = e.NewPageIndex;
        gvTraining.EditIndex = -1;
        FillgvTraining(txtEmployeeNumber.Text);
    }

    /// <summary>
    /// Function called on ImageButton Deactivate click Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void OnClick_Deactivate(object sender, EventArgs e)
    {
        var imgBtnDeactivate = (ImageButton)sender;
        var row = (GridViewRow)imgBtnDeactivate.NamingContainer;


        var lblItmTrainingCode = (LinkButton)gvTraining.Rows[row.RowIndex].FindControl("lblItmTrainingCode");
        var labelItemTrainingDate = (Label)gvTraining.Rows[row.RowIndex].FindControl("LabelItemTrainingDate");
        var labelItemTrainingDesc = (Label)gvTraining.Rows[row.RowIndex].FindControl("LabelItemTrainingDesc");
        var labelItemValidTillDate = (Label)gvTraining.Rows[row.RowIndex].FindControl("LabelItemValidTillDate");
        PanelEmpRefresherTrainingDetails.Visible = true;
        hfTrainingCode.Value = lblItmTrainingCode.Text;
        hfTrainingDate.Value = labelItemTrainingDate.Text;

        var objMasterManagment = new HRManagement();
        var ds = objMasterManagment.DeactivateEmployee(BaseCompanyCode, txtEmployeeNumber.Text,Convert.ToDateTime(labelItemTrainingDate.Text), lblItmTrainingCode.Text, labelItemValidTillDate.Text, labelItemValidTillDate.Text);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            imgBtnDeactivate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgDeactiveTraining + "');";

            imgBtnDeactivate.Enabled = false;
            FillgvEmpRefresherTrainingDetails(hfTrainingCode.Value, hfTrainingDate.Value, txtEmployeeNumber.Text);
            FillgvTraining(txtEmployeeNumber.Text);
            lblTrainingGridInfo.Text = lblItmTrainingCode.Text + @" (" + labelItemTrainingDesc.Text + @") ------- Training Start Date : " + labelItemTrainingDate.Text.ToString() + @" ------- Valid Till Date : " + labelItemValidTillDate.Text;
        }
    }

    protected void AddLinkButton()
    {
        foreach (GridViewRow row in gvTraining.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                var lblItmTrainingCode = (LinkButton)gvTraining.Rows[0].FindControl("lblItmTrainingCode");
                lblItmTrainingCode.Click += new EventHandler(lblTrainingCode_Click);
            }
        }
    }
}







