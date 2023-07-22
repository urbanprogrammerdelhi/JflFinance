// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="YLMDutyConfirm.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_YLMDutyConfirm.
/// </summary>
public partial class Transactions_YLMDutyConfirm : BasePage
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
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.YLMDutyConfirm + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            txtFromDate.Attributes.Add("readonly", "readonly");
            txtToDate.Attributes.Add("readonly", "readonly");
            txtFromDate.Text = DateFormat(DateTime.Now.ToString());
            txtToDate.Text = DateFormat(DateTime.Now.ToString());
            FillddlAreaId();
            btnConfirm.Visible = false;
        }
    }
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    private void FillddlAreaId()
    {
        var objOm = new BL.OperationManagement();
        DataSet ds = objOm.AreaIdGet(BaseLocationAutoID, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaId.DataSource = ds.Tables[0];
            ddlAreaId.DataValueField = "AreaId";
            ddlAreaId.DataTextField = "AreaIdDesc";
            ddlAreaId.DataBind();

            //ddlAreaName.DataSource = ds;
            //ddlAreaName.DataTextField = "AreaDesc";
            //ddlAreaName.DataValueField = "AreaId";
            //ddlAreaName.DataBind();

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = @"ALL";
            ddlAreaId.Items.Insert(0, li);

            //li = new RadComboBoxItem();
            //li.Text = Resources.Resource.All;
            //li.Value = @"All";
            //ddlAreaName.Items.Insert(0, li);

            ddlAreaId.SelectedIndex = 0;
          //  ddlAreaName.SelectedIndex = 0;
        }
        else
        {
            ddlAreaId.Items.Clear();
           // ddlAreaName.Items.Clear();

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.NoDataToShow.ToString();
            li.Value = "";
            ddlAreaId.Items.Add(li);

            //li = new RadComboBoxItem();
            //li.Text = Resources.Resource.NoDataToShow.ToString();
            //li.Value = "";
            //ddlAreaName.Items.Add(li);
        }
        FillddlClientCode();
    }
    /// <summary>
    /// Fillddls the client code.
    /// </summary>
    private void FillddlClientCode()
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.ClientAreaWiseGet(BaseLocationAutoID, ddlAreaId.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataBind();

            //ddlClientName.DataSource = ds.Tables[0];
            //ddlClientName.DataValueField = "ClientCode";
            //ddlClientName.DataTextField = "ClientName";
            //ddlClientName.DataBind();

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.All.ToString();
            li.Value = @"ALL";
            ddlClientCode.Items.Insert(0, li);

            //li = new RadComboBoxItem();
            //li.Text = Resources.Resource.All.ToString();
            //li.Value = @"ALL";
            //ddlClientName.Items.Insert(0, li);

            ddlClientCode.SelectedIndex = 0;
            //ddlClientName.SelectedIndex = 0;
        }
        else
        {
            ddlClientCode.Items.Clear();
            //ddlClientName.Items.Clear();

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.NoDataToShow.ToString();
            li.Value = "";
            ddlClientCode.Items.Insert(0, li);

            //li = new RadComboBoxItem();
            //li.Text = Resources.Resource.NoDataToShow.ToString();
            //li.Value = "";
            //ddlClientName.Items.Insert(0, li);
        }
        FillddlAsmtCode();
    }
    /// <summary>
    /// Fillddls the asmt code.
    /// </summary>
    private void FillddlAsmtCode()
    {
        var objOpsm = new BL.OperationManagement();
        ddlAsmtCode.Items.Clear();
        if (ddlClientCode.SelectedValue == "ALL")
        {

            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All.ToString();
            li1.Value = @"ALL";
            ddlAsmtCode.Items.Insert(0, li1);
            return;

        }

        DataSet ds = objOpsm.OpsAsmtCodeAddressGet(BaseLocationAutoID, ddlClientCode.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = ds.Tables[0];
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataTextField = "AsmtDesc";
            ddlAsmtCode.DataBind();

            //ddlAsmtName.DataSource = ds.Tables[0];
            //ddlAsmtName.DataValueField = "AsmtCode";
            //ddlAsmtName.DataTextField = "AsmtDesc";
            //ddlAsmtName.DataBind();

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.All.ToString();
            li.Value = @"ALL";
            ddlAsmtCode.Items.Insert(0, li);

            //li = new RadComboBoxItem();
            //li.Text = Resources.Resource.All.ToString();
            //li.Value = @"ALL";
            //ddlAsmtName.Items.Insert(0, li);

            ddlAsmtCode.SelectedIndex = 0;
           // ddlAsmtName.SelectedIndex = 0;
        }
        else
        {
            ddlAsmtCode.Items.Clear();
          //  ddlAsmtName.Items.Clear();

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.NoDataToShow.ToString();
            li.Value = "";
            ddlAsmtCode.Items.Add(li);

            //li = new RadComboBoxItem();
            //li.Text = Resources.Resource.NoDataToShow.ToString();
            //li.Value = "";
            //ddlAsmtName.Items.Add(li);
        }
        //FillddlDutyDate();
    }
    /// <summary>
    /// Fillddls the duty date.
    /// </summary>
    private void FillddlDutyDate()
    {
        //var objOpsm = new BL.Roster();
        //DataSet ds = objOpsm.YlmDutyDateGet(BaseLocationAutoID, ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString());
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    ddlDutyDate.DataSource = ds.Tables[0];
        //    ddlDutyDate.DataValueField = "DutyDate";
        //    ddlDutyDate.DataTextField = "DutyDate";
        //    ddlDutyDate.DataBind();
        //}
        //else
        //{
        //    ddlDutyDate.Items.Clear();
        //    ListItem li = new ListItem();
        //    li.Text = Resources.Resource.NoDataToShow.ToString();
        //    li.Value = "";
        //    ddlDutyDate.Items.Add(li);
        //}
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaId_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
      //  ddlAreaName.SelectedValue = ddlAreaId.SelectedValue;
        FillddlClientCode();
    }
    //protected void ddlAreaName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    ddlAreaId.SelectedValue = ddlAreaName.SelectedValue;
    //    FillddlClientCode();
    //}
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
       // ddlClientName.SelectedValue = ddlClientCode.SelectedValue;
        FillddlAsmtCode();
    }
    //protected void ddlClientName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    ddlClientCode.SelectedValue = ddlClientName.SelectedValue;
    //    FillddlAsmtCode();
    //}
    //protected void ddlAsmtCode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
       // ddlAsmtName.SelectedValue = ddlAsmtCode.SelectedValue;
    //}
    //protected void ddlAsmtName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    ddlAsmtCode.SelectedValue = ddlAsmtName.SelectedValue;
    //}

    /// <summary>
    /// Sets the time validation to text box.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    private void SetTimeValidationToTextBox(object textBox)
    {
        if (textBox != null)
        {
            TextBox TimeTextBox = (TextBox)textBox;
            TimeTextBox.Attributes["onKeyUp"] = "javascript:Timevalnum('" + TimeTextBox.ClientID.ToString() +
                                                       "');";
            TimeTextBox.Attributes["onblur"] = "javascript:IsValidTime('" + TimeTextBox.ClientID.ToString() +
                                                  "');";
        }
    }
    /// <summary>
    /// Fillgvs the emp.
    /// </summary>
    private void FillgvEmp()
    {
        BL.Roster objMM = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objMM.YlmRosterScheduleDutyGet(DateFormat(txtFromDate.Text), DateFormat(txtToDate.Text), BaseLocationAutoID, ddlAreaId.SelectedItem.Value.ToString(), ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), ddlAttendanceType.SelectedItem.Value, cbWithConfirmedDuty.Checked);
       // ds = objMM.YlmRosterScheduleDutyGet(DateFormat(txtFromDate.Text),BaseLocationAutoID, ddlAreaId.SelectedItem.Value.ToString(), ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString(), ddlAttendanceType.SelectedItem.Value);
        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvEmp.DataSource = ds.Tables[0];
            gvEmp.DataBind();

            btnConfirm.Visible = true;
        }
        else
        {
            gvEmp.DataSource = "";
            gvEmp.DataBind();
            btnConfirm.Visible = false;
        }
        
    }
    /// <summary>
    /// Handles the Click event of the btnConfirm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in gvEmp.Rows)
        {
            //ImageButton Imgbtn = (ImageButton)sender;
            //GridViewRow gvRow = (GridViewRow)Imgbtn.NamingContainer;

            ImageButton Imgbtn = (ImageButton)gvEmp.Rows[gvRow.RowIndex].FindControl("Imgbtn");
            DataSet ds = new DataSet();

            Label lblClientCode = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblClientCode");
            HiddenField hfAsmtCode = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfAsmtCode");
            Label lblAsmtId = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblAsmtId");
            Label lblPostCode = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblPostCode");

            Label lblEmployeeNumber = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblEmployeeNumber");
            //Manish 17-09-2012
            HiddenField hfSchRosterAutoID = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfSchRosterAutoID");
            //End Manish
            HiddenField hfRosterAutoID = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfRosterAutoID");
            HiddenField hfPDlineNo = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfPDlineNo");

            Label lblDutyDate = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblDutyDate");
            //  Label lblSchTimeFrom = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblSchTimeFrom");
            // Label lblSchTimeTo = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblSchTimeTo");
            TextBox lblActTimeFrom = (TextBox)gvEmp.Rows[gvRow.RowIndex].FindControl("lblActTimeFrom");
            TextBox lblActTimeTo = (TextBox)gvEmp.Rows[gvRow.RowIndex].FindControl("lblActTimeTo");

            Label lblYLMRawTimeFrom = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblYLMRawTimeFrom");
            Label lblYLMRawTimeTo = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblYLMRawTimeTo");
            Label lblYLMProcessedTimeFrom = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblYLMProcessedTimeFrom");
            Label lblYLMProcessedTimeTo = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblYLMProcessedTimeTo");

            //CheckBox cbSchInTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbSchInTime");
            // CheckBox cbSchOutTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbSchOutTime");
            CheckBox cbActInTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbActInTime");
            CheckBox cbActOutTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbActOutTime");

            CheckBox cbYLMRawInTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbYLMRawInTime");
            CheckBox cbYLMRawOutTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbYLMRawOutTime");
            CheckBox cbYLMProcessedInTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbYLMProcessedInTime");
            CheckBox cbYLMProcessedOutTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbYLMProcessedOutTime");
            HiddenField hfActualRosterProcessedYLMAutoID = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfActualRosterProcessedYLMAutoID");
            HiddenField HFLocationAutoID = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("HFLocationAutoID");
            

            string strDutyDate = string.Empty;
            string strInTime = string.Empty;
            string strOutTime = string.Empty;
            string strRosterAutoID = string.Empty;
            string strSchRosterAutoID = string.Empty;
            string strConfirmStatus = "0";

            if (lblDutyDate != null)
            {
                strDutyDate = lblDutyDate.Text;
            }
            #region Checkbox valid times
            if (strDutyDate != string.Empty)
            {
                if (cbActInTime != null && cbActOutTime != null && cbYLMRawInTime != null && cbYLMRawOutTime != null && cbYLMProcessedInTime != null && cbYLMProcessedOutTime != null)
                {
                    //------------------ In Time
                    if (cbActInTime.Checked == true)
                    {
                        if (lblActTimeFrom.Text != "")
                        {
                            strInTime = strDutyDate + " " + lblActTimeFrom.Text;
                        }
                        else
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.TimeFrom + " " + Resources.Resource.Required);
                        }
                    }
                    else if (cbYLMRawInTime.Checked == true)
                    {
                        if (lblYLMRawTimeFrom.Text != "")
                        {
                            strConfirmStatus = "1";
                            strInTime = strDutyDate + " " + lblYLMRawTimeFrom.Text;
                        }
                        else
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.TimeFrom + " " + Resources.Resource.Required);
                        }
                    }
                    else if (cbYLMProcessedInTime.Checked == true)
                    {
                        if (lblYLMProcessedTimeFrom.Text != "")
                        {
                            strConfirmStatus = "1";
                            strInTime = strDutyDate + " " + lblYLMProcessedTimeFrom.Text;
                        }
                        else
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.TimeFrom + " " + Resources.Resource.Required);
                        }
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, "Please Select any TimeIn");
                    }
                    //------------------ Out Time
                    if (cbActOutTime.Checked == true)
                    {
                        if (lblActTimeTo.Text != "")
                        {
                            strOutTime = strDutyDate + " " + lblActTimeTo.Text;
                        }
                        else
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.TimeTo + " " + Resources.Resource.Required);
                        }

                    }
                    else if (cbYLMRawOutTime.Checked == true)
                    {
                        if (lblYLMRawTimeTo.Text != "")
                        {
                            strConfirmStatus = "1";
                            strOutTime = strDutyDate + " " + lblYLMRawTimeTo.Text;
                        }
                        else
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.TimeTo + " " + Resources.Resource.Required);
                        }

                    }
                    else if (cbYLMProcessedOutTime.Checked == true)
                    {
                        if (lblYLMProcessedTimeTo.Text != "")
                        {
                            strConfirmStatus = "1";
                            strOutTime = strDutyDate + " " + lblYLMProcessedTimeTo.Text;
                        }
                        else
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.TimeTo + " " + Resources.Resource.Required);
                        }

                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, "Please Select any TimeOut");
                    }
                }
            }
            #endregion
            if (lblEmployeeNumber != null && lblClientCode != null && hfAsmtCode != null && lblAsmtId != null && lblPostCode != null && hfRosterAutoID != null && strDutyDate != string.Empty && strOutTime != string.Empty && strInTime != string.Empty)
            {
                if (hfRosterAutoID.Value.ToString() != "")
                {
                    strRosterAutoID = hfRosterAutoID.Value.ToString();
                }
                else
                {
                    strRosterAutoID = "0";
                }


                if (hfSchRosterAutoID.Value.ToString() != "")
                {
                    strSchRosterAutoID = hfSchRosterAutoID.Value.ToString();
                }
                else
                {
                    strSchRosterAutoID = "0";
                }

                BL.Roster objRoster = new BL.Roster();
                ds = objRoster.YlmConfirmDutySave(HFLocationAutoID.Value, lblEmployeeNumber.Text, lblClientCode.Text, hfAsmtCode.Value.ToString(), hfPDlineNo.Value, strSchRosterAutoID, strRosterAutoID, DateFormat(strDutyDate), strInTime, strOutTime, BaseUserID, strConfirmStatus, hfActualRosterProcessedYLMAutoID.Value);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                    {
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        //FillgvEmp();
                    }
                    else
                    {
                        lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                        //FillgvEmp();
                    }
                }
            }
        }
        FillgvEmp();
    }
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        FillgvEmp();
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
            gvEmp.Columns[7].Visible = false;
            gvEmp.Columns[8].Visible = false;
            HiddenField HFConfirmStatus = (HiddenField)e.Row.FindControl("HFConfirmStatus");
            ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
            if (HFConfirmStatus != null)
            {
                if (HFConfirmStatus.Value != "" && bool.Parse(HFConfirmStatus.Value) == true)
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.BurlyWood;
                }
            }
            //if (hfConfirmFlag != null)
            //{
            //    if (hfConfirmFlag.Value == "0")
            //    {
            //        if (lbADD != null)
            //        {
            //            lbADD.Visible = false;
            //            e.Row.BackColor = System.Drawing.Color.LightGreen;
            //        }

            //    }
            //    else
            //    {
            //        if (lbADD != null)
            //        {
            //            lbADD.Visible = true;
            //            e.Row.BackColor = System.Drawing.Color.Empty;
            //        }
            //    }

            //}
            TextBox lblActTimeFrom = (TextBox)e.Row.FindControl("lblActTimeFrom");
            TextBox lblActTimeTo = (TextBox)e.Row.FindControl("lblActTimeTo");
            SetTimeValidationToTextBox(lblActTimeFrom);
            SetTimeValidationToTextBox(lblActTimeTo);
            //Manish to Show - instead OF  00:00 18/07-2012----
            Label lblYLMRawTimeFrom = (Label)e.Row.FindControl("lblYLMRawTimeFrom");
            Label lblYLMRawTimeTo = (Label)e.Row.FindControl("lblYLMRawTimeTo");
            Label lblYLMProcessedTimeFrom = (Label)e.Row.FindControl("lblYLMProcessedTimeFrom");
            Label lblYLMProcessedTimeTo = (Label)e.Row.FindControl("lblYLMProcessedTimeTo");

            CheckBox cbYLMProcessedOutTime = (CheckBox)e.Row.FindControl("cbYLMProcessedOutTime");
            CheckBox cbYLMProcessedInTime = (CheckBox)e.Row.FindControl("cbYLMProcessedInTime");

            CheckBox cbYLMRawInTime = (CheckBox)e.Row.FindControl("cbYLMRawInTime");
            CheckBox cbYLMRawOutTime = (CheckBox)e.Row.FindControl("cbYLMRawOutTime");

            //Fields Added By Ajay Datta To Handle Bug ID 361
            HiddenField hfYLMProcessedTimeTo = (HiddenField)e.Row.FindControl("hfYLMProcessedTimeTo");
            HiddenField hfYLMProcessedTimeFrom = (HiddenField)e.Row.FindControl("hfYLMProcessedTimeFrom");
            HiddenField hfYLMRawTimeTo = (HiddenField)e.Row.FindControl("hfYLMRawTimeTo");
            HiddenField hfYLMRawTimeFrom = (HiddenField)e.Row.FindControl("hfYLMRawTimeFrom");

            //if (lblYLMRawTimeFrom != null)
            if ((lblYLMRawTimeFrom != null) && (hfYLMRawTimeFrom.Value.ToString() == "01-Jan-1900"))
            {
                if (lblYLMRawTimeFrom.Text == "00:00")
                {
                    lblYLMRawTimeFrom.Text = "-";
                    cbYLMRawInTime.Visible = false;
                }
            }

            //if (lblYLMRawTimeTo != null)
            if ((lblYLMRawTimeTo != null) && (hfYLMRawTimeTo.Value.ToString() == "01-Jan-1900"))
            {
                if (lblYLMRawTimeTo.Text == "00:00")
                {
                    lblYLMRawTimeTo.Text = "-";
                    cbYLMRawOutTime.Visible = false;
                }
            }


            //if (lblYLMProcessedTimeFrom != null)
            if ((lblYLMProcessedTimeFrom != null) && (hfYLMProcessedTimeFrom.Value.ToString() == "01-Jan-1900"))
            {
                if (lblYLMProcessedTimeFrom.Text == "00:00")
                {
                    lblYLMProcessedTimeFrom.Text = "-";
                    cbYLMProcessedInTime.Visible = false;
                }
            }

            if ((lblYLMProcessedTimeTo != null) && (hfYLMProcessedTimeTo.Value.ToString() == "01-Jan-1900"))
            {
                if (lblYLMProcessedTimeTo.Text == "00:00")
                {
                    lblYLMProcessedTimeTo.Text = "-";
                    cbYLMProcessedOutTime.Visible = false;

                }
            }
        }
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

        Label lblClientCode = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblClientCode");
        HiddenField hfAsmtCode = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfAsmtCode");
        Label lblAsmtId = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblAsmtId");
        Label lblPostCode = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblPostCode");

        Label lblEmployeeNumber = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblEmployeeNumber");
        //Manish 17-09-2012
        HiddenField hfSchRosterAutoID = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfSchRosterAutoID");
        //End Manish 
        HiddenField hfRosterAutoID = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfRosterAutoID");
        HiddenField hfPDlineNo = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfPDlineNo");

        Label lblDutyDate = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblDutyDate");
        //  Label lblSchTimeFrom = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblSchTimeFrom");
        // Label lblSchTimeTo = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblSchTimeTo");
        TextBox lblActTimeFrom = (TextBox)gvEmp.Rows[gvRow.RowIndex].FindControl("lblActTimeFrom");
        TextBox lblActTimeTo = (TextBox)gvEmp.Rows[gvRow.RowIndex].FindControl("lblActTimeTo");

        Label lblYLMRawTimeFrom = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblYLMRawTimeFrom");
        Label lblYLMRawTimeTo = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblYLMRawTimeTo");
        Label lblYLMProcessedTimeFrom = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblYLMProcessedTimeFrom");
        Label lblYLMProcessedTimeTo = (Label)gvEmp.Rows[gvRow.RowIndex].FindControl("lblYLMProcessedTimeTo");

        //CheckBox cbSchInTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbSchInTime");
        // CheckBox cbSchOutTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbSchOutTime");
        CheckBox cbActInTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbActInTime");
        CheckBox cbActOutTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbActOutTime");

        CheckBox cbYLMRawInTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbYLMRawInTime");
        CheckBox cbYLMRawOutTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbYLMRawOutTime");
        CheckBox cbYLMProcessedInTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbYLMProcessedInTime");
        CheckBox cbYLMProcessedOutTime = (CheckBox)gvEmp.Rows[gvRow.RowIndex].FindControl("cbYLMProcessedOutTime");
        HiddenField hfActualRosterProcessedYLMAutoID = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("hfActualRosterProcessedYLMAutoID");
        HiddenField HFLocationAutoID = (HiddenField)gvEmp.Rows[gvRow.RowIndex].FindControl("HFLocationAutoID");

        string strDutyDate = string.Empty;
        string strInTime = string.Empty;
        string strOutTime = string.Empty;
        string strRosterAutoID = string.Empty;
        string strSchRosterAutoID = string.Empty;
        string strConfirmStatus = "0";

        if (lblDutyDate != null)
        {
            strDutyDate = lblDutyDate.Text;
        }
        #region Checkbox valid times
        if (strDutyDate != string.Empty)
        {
            if (cbActInTime != null && cbActOutTime != null && cbYLMRawInTime != null && cbYLMRawOutTime != null && cbYLMProcessedInTime != null && cbYLMProcessedOutTime != null)
            {
                //------------------ In Time
                if (cbActInTime.Checked == true)
                {
                    if (lblActTimeFrom.Text != "")
                    {
                        strInTime = strDutyDate + " " + lblActTimeFrom.Text;
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.TimeFrom + " " + Resources.Resource.Required);
                    }
                }
                else if (cbYLMRawInTime.Checked == true)
                {
                    if (lblYLMRawTimeFrom.Text != "")
                    {
                        strConfirmStatus = "1";
                        strInTime = strDutyDate + " " + lblYLMRawTimeFrom.Text;
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.TimeFrom + " " + Resources.Resource.Required);
                    }
                }
                else if (cbYLMProcessedInTime.Checked == true)
                {
                    if (lblYLMProcessedTimeFrom.Text != "")
                    {
                        strConfirmStatus = "1";
                        strInTime = strDutyDate + " " + lblYLMProcessedTimeFrom.Text;
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.TimeFrom + " " + Resources.Resource.Required);
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, "Please Select any TimeIn");
                }
                //------------------ Out Time
                if (cbActOutTime.Checked == true)
                {
                    if (lblActTimeTo.Text != "")
                    {
                        strOutTime = strDutyDate + " " + lblActTimeTo.Text;
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.TimeTo + " " + Resources.Resource.Required);
                    }

                }
                else if (cbYLMRawOutTime.Checked == true)
                {
                    if (lblYLMRawTimeTo.Text != "")
                    {
                        strConfirmStatus = "1";
                        strOutTime = strDutyDate + " " + lblYLMRawTimeTo.Text;
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.TimeTo + " " + Resources.Resource.Required);
                    }

                }
                else if (cbYLMProcessedOutTime.Checked == true)
                {
                    if (lblYLMProcessedTimeTo.Text != "")
                    {
                        strConfirmStatus = "1";
                        strOutTime = strDutyDate + " " + lblYLMProcessedTimeTo.Text;
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.TimeTo + " " + Resources.Resource.Required);
                    }

                }
                else
                {
                    DisplayMessageString(lblErrorMsg, "Please Select any TimeOut");
                }
            }
        }
        #endregion
        if (lblEmployeeNumber != null && lblClientCode != null && hfAsmtCode!= null && lblAsmtId != null && lblPostCode != null && hfRosterAutoID != null && strDutyDate != string.Empty && strOutTime != string.Empty && strInTime != string.Empty)
        {
            if (hfRosterAutoID.Value.ToString() != "")
            {
                strRosterAutoID = hfRosterAutoID.Value.ToString();
            }
            else
            {
                strRosterAutoID = "0";
            }
           //Manish 17-09-2012 to pass SchrosterAutoID 
            if (hfSchRosterAutoID.Value.ToString() != "")
            {
                strSchRosterAutoID = hfSchRosterAutoID.Value.ToString();
            }
            else
            {
                strSchRosterAutoID = "0";
            }
            //End Manish 
            BL.Roster objRoster = new BL.Roster();
            ds = objRoster.YlmConfirmDutySave(HFLocationAutoID.Value, lblEmployeeNumber.Text, lblClientCode.Text, hfAsmtCode.Value.ToString(), hfPDlineNo.Value, strSchRosterAutoID, strRosterAutoID, DateFormat(strDutyDate), strInTime, strOutTime, BaseUserID, strConfirmStatus, hfActualRosterProcessedYLMAutoID.Value);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    FillgvEmp();
                }
                else
                {
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                    FillgvEmp();
                }
            }
        }

    }
}
