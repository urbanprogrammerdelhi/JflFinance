// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="SchEmpWiseLeaveEntitlement.Aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Class HRManagement_SchEmpWiseLeaveEntitlement
/// </summary>
public partial class HRManagement_SchEmpWiseLeaveEntitlement : BasePage //System.Web.UI.Page
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

            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.LeaveEntitlement;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.LeaveEntitlement + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillLeaveType();
                FillLeaveCalendarDefault();
                if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
                {
                    if (Request.QueryString["BackOption"] != null && Request.QueryString["BackOption"] == "Back" && Request.QueryString["EmployeeNumber"] != null && Request.QueryString["EmployeeNumber"] != "" && Request.QueryString["FromDate"] != null && Request.QueryString["FromDate"] != "" )
                    {

                        btnBack.Visible = true;
                    }
                    else
                    {
                        btnBack.Visible = false;
                    }
                    txtEmployeeNumber.Text = Request.QueryString["EmployeeNumber"];
                    txtEmployeeNumber_OnTextChanged(sender, e);

                }
                else
                {
                    if (Request.QueryString["BackOption"] != null && Request.QueryString["BackOption"] == "Back" && Request.QueryString["EmployeeNumber"] != null && Request.QueryString["EmployeeNumber"] != "" && Request.QueryString["FromDate"] != null && Request.QueryString["FromDate"] != "")
                    {
                        btnBack.Visible = true;
                    }
                    else
                    {
                        btnBack.Visible = false;
                    }
                    txtEmployeeNumber.Text = Request.QueryString["EmployeeNumber"];
                    txtEmployeeNumber_OnTextChanged(sender, e);
                    btnSave.Visible = true;
                    btnReset.Visible = false;
                }
                txtEmployeeNumber.Attributes.Add("readonly", "readonly");
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");

            }

        }

        ImgLCCode.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=LCCCH&ControlId=" + txtLeaveCalendarCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
        imgEmployeeNumberSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");

    }

    /// <summary>
    /// Fills the leave calendar default.
    /// </summary>
    protected void FillLeaveCalendarDefault()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();

        ds = objLeave.LeaveCalendarGet(BaseCompanyCode);

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            txtLeaveCalendarCode.Text = ds.Tables[1].Rows[0]["Leave_cal_code"].ToString();
            lblLeaveCalendarDesc.Text = ds.Tables[1].Rows[0]["Leave_cal_desc"].ToString();
            lblEffectiveFrom.Text = DateFormat(ds.Tables[1].Rows[0]["EffectiveFromDate"].ToString());
            lblEffectiveTo.Text = DateFormat(ds.Tables[1].Rows[0]["EffectiveTodate"].ToString());
        }
        else
        {
            lblErrMsg.Text = Resources.Resource.NoDataToShow;
            txtLeaveCalendarCode.Text = "";
        }

    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtLeaveCalendarCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtLeaveCalendarCode_OnTextChanged(object sender, EventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeaveCalendarGet(BaseCompanyCode, txtLeaveCalendarCode.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            lblLeaveCalendarDesc.Text = ds.Tables[0].Rows[0]["Leave_cal_desc"].ToString();
            lblEffectiveFrom.Text = DateFormat(ds.Tables[0].Rows[0]["EffectiveFromDate"].ToString());
            lblEffectiveTo.Text = DateFormat(ds.Tables[0].Rows[0]["EffectiveTodate"].ToString());
        }
        else
        {
            lblErrMsg.Text = Resources.Resource.NoDataToShow;
            txtLeaveCalendarCode.Text = "";
        }

    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeNumber_OnTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeNumber.Text.ToString(), BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            lblEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();

        }
        else
        {
            DisplayMessage(lblErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            lblEmployeeName.Text = "";
            txtEmployeeNumber.Text = "";
            ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
        }
        ddlLeaveType.SelectedIndex = 0;
        txtLeaveBalanceUnits.Text = "";
        lblUnits.Text = "";
        txtEntitledUnits.Text = "00.00";
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlLeaveType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        txtLeaveBalanceUnits.Text = "";
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeaveTypeGet(BaseCompanyCode);
        if (ddlLeaveType.SelectedIndex != 0)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "Leave_Code='" + ddlLeaveType.SelectedValue.ToString() + "'";
            lblUnits.Text = dv.Table.Rows[0]["Leave_Unit"].ToString();

            if (txtEmployeeNumber.Text != "")
            {
                //FillApplicationNo();
                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);
            }
            else
            {
                lblErrMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber;
            }
        }
        else
        {
            txtEntitledUnits.Text = "00.00";
            txtLeaveBalanceUnits.Text = "";
            lblUnits.Text = "";
        }
    }

    /// <summary>
    /// Fills the type of the leave.
    /// </summary>
    protected void FillLeaveType()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeaveTypeGet(BaseCompanyCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "Without_Entitlement_flag <> true";
            ddlLeaveType.DataSource = dv;
            ddlLeaveType.DataTextField = "Leave_Desc";
            ddlLeaveType.DataValueField = "Leave_Code";
            ddlLeaveType.DataBind();
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.Select ;
            li.Value = "0";
            ddlLeaveType.Items.Insert(0, li);
            ddlLeaveType.SelectedIndex = 0;

        }
        else
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlLeaveType.Items.Insert(0, li);

        }
    }

    /// <summary>
    /// Gets the leave balances.
    /// </summary>
    /// <param name="txtLeaveCalendarCode">The TXT leave calendar code.</param>
    /// <param name="ddlLeaveCode">The DDL leave code.</param>
    /// <param name="txtEmployeeNumber">The TXT employee number.</param>
    /// <param name="txtLeaveBalance">The TXT leave balance.</param>
    protected void GetLeaveBalances(TextBox txtLeaveCalendarCode, DropDownList ddlLeaveCode, TextBox txtEmployeeNumber, TextBox txtLeaveBalance)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.EmployeeLeaveBalanceGet(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveCode.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtLeaveBalance.Text = double.Parse(ds.Tables[0].Rows[0]["Leave_Balance_Days"].ToString()).ToString("00.00");

        }
        else
        {

            lblErrMsg.Text = Resources.Resource.MsgLeaveBalanceIsNotDefinedForEmployee;
            //txtEmployeeNumber.Text = "";
            ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
        }

    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();

        if (txtLeaveCalendarCode.Text != "")
        {
            if (txtEmployeeNumber.Text != "")
            {

                if (ddlLeaveType.SelectedValue != "0")
                {

                    if (double.Parse(txtEntitledUnits.Text) > 0)
                    {

                        // if (double.Parse(txtEntitledUnits.Text) % 0.25 == 0 && double.Parse(txtEntitledUnits.Text) > 0.0) 
                        // {

                        ds = objLeave.LeaveEntitlementInsert(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue, txtEntitledUnits.Text, lblEffectiveFrom.Text, "S", BaseUserID);



                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            //lblErrMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                            DisplayMessage(lblErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                        }
                        //else
                        //{
                        //}
                        // }
                        //else
                        //{
                        //    lblErrMsg.Text = Resources.Resource.MsgLeaveEntitledUnitsShouldBeMultipleOf;
                        //    //txtEmployeeNumber.Text = "";
                        //    ToolkitScriptManager1.SetFocus("txtEntitledUnits");
                        //}


                    }
                    else
                    {
                        lblErrMsg.Text = Resources.Resource.LeaveUnitsShouldMoreThanZero;
                        //txtEmployeeNumber.Text = "";
                        ToolkitScriptManager1.SetFocus("txtEntitledUnits");
                    }

                }
                else
                {
                    lblErrMsg.Text = Resources.Resource.MsgRequiredLeaveType;
                    //txtEmployeeNumber.Text = "";
                    ToolkitScriptManager1.SetFocus("ddlLeaveType");
                }

            }
            else
            {
                lblErrMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber;
                //txtEmployeeNumber.Text = "";
                ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
            }




        }
        else
        {
            lblErrMsg.Text = Resources.Resource.MsgRequiredLeaveCalender;
            //txtEmployeeNumber.Text = "";
            ToolkitScriptManager1.SetFocus("txtLeaveCalendarCode");
        }





    }

    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //BL.Leave objLeave = new BL.Leave();
        //DataSet ds = new DataSet();
        //ds = objLeave.blLeaveAdjustment_Insert(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString(), ddlApplicationNo.SelectedValue, txtAdjustedUnits.Text, txtReason.Text, ddlAdjustmentType.SelectedValue, "D", BaseUserID);

        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    DisplayMessage(lblErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

        //}
        //else
        //{

        //}


    }

    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtEmployeeNumber.Text = "";
        ddlLeaveType.SelectedIndex = 0;
        lblEmployeeName.Text = "";
        lblUnits.Text = "";
        txtLeaveBalanceUnits.Text = "";
        txtEntitledUnits.Text = "00.00";

    }

    /// <summary>
    /// Handles the Click event of the btnBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../HRManagement/SchEmpWiseLeaveApplicationAndPosting.aspx?EmployeeNumber=" + Request.QueryString["EmployeeNumber"] + "&DutyDate=" + Request.QueryString["FromDate"]);
    }

    //protected void ddlApplicationNo_OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BL.Leave objLeave = new BL.Leave();
    //    DataSet ds = new DataSet();
    //    if (ddlApplicationNo.SelectedItem.Text != Resources.Resource.Select)
    //    {
    //        ds = objLeave.blLeaveAdjustment_ApplicationDetail_Get(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue, ddlApplicationNo.SelectedValue);
    //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //        {
    //            txtAdjustedUnits.Text = double.Parse(ds.Tables[0].Rows[0]["Adjusted_Units"].ToString()).ToString("00.00");
    //        }
    //        else
    //        {
    //            txtAdjustedUnits.Text = "00.00";
    //        }
    //    }
    //}


}
