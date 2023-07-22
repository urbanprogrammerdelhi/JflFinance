// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ClientList.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Masters_BusinessRulesGeneric : BasePage ///System.Web.UI.Page
{

    static int Index;
    static int intClientWeeklyOffID;
    static string strHolidayCode;
    static string strHolidayDate;

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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsReadAccess)
        {
            // return to home page on session expire 
        }

        if (!IsPostBack)
        {
            
            //Page Title from resource file
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.BusinessRulesGeneric + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            FillExistingRules();

            FillddlCompany();
            FillddlDivision();
            FillddlBranch();
            FillClient();
            FillCategory();
            FillJobClass();
            FillJobType();
            FillDesignation();
            ContractualDays();
            //FillShift();
            // FillDefaultWHTimings();
            FillgvHoliday();
            FillHrsHeads();
            FillHoursHeadGroup();
            // ------------------------------Manish New PaySum Format----------------
            FillPaySumCode();
            //----------------------------End New PaySum------------------------
            FillWeeklyHoursHead();


            txtStartDay_Monthly.MaxLength = 2;
            txtStartDay_Monthly.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            txtEndDay_Monthly.MaxLength = 2;
            txtEndDay_Monthly.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            txtStartDay_FirstFortnightly.MaxLength = 2;
            txtStartDay_FirstFortnightly.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            txtEndDay_FirstFortnightly.MaxLength = 2;
            txtEndDay_FirstFortnightly.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            txtStartDay_SecondFortnightly.MaxLength = 2;
            txtStartDay_SecondFortnightly.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            txtEndDay_SecondFortnightly.MaxLength = 2;
            txtEndDay_SecondFortnightly.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            Tab1.ActiveTabIndex = 0;
        }
    }
    protected void Tab1_TabChanged(object sender, EventArgs e)
    {

        if (Tab1.ActiveTabIndex == 9)
        {
            FillPaysumElements();
        }

    }
    #region Fill
    /// <summary>
    ///   Fill All existing Business Rules
    /// </summary>
    protected void FillExistingRules()
    {

        var objBR = new BL.BusinessRule();
        var ds = objBR.BusinessRuleGet("", int.Parse(BaseLocationAutoID));
        ddlBR.DataSource = ds.Tables[0];
        ddlBR.DataValueField = "BusinessRuleCode";
        ddlBR.DataTextField = "BusinessRuleDesc";
        ddlBR.DataBind();

        var li = new ListItem();
        li.Text =  Resources.Resource.SetupNewRule ;
        li.Value = DateTime.Now.ToString();
        ddlBR.Items.Insert(0, li);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["IsDefaultRuleExists"].ToString() == "1")
        {
            chkIsDefaultRule.Enabled = false;
        }
        //  Fill Paysum Code.Using same BL,DL and SP that we are used to FillExistingRules.
        //  Added new select statement in same SP


        ddlPaysumCode.DataSource = ds.Tables[1];
        ddlPaysumCode.DataValueField = "PaysumCode";
        ddlPaysumCode.DataTextField = "PaysumCodeDesc";
        ddlPaysumCode.DataBind();

        var paySum = new ListItem();
        paySum.Text =  Resources.Resource.SetupNewPaySumCode ;
        ddlPaysumCode.Items.Insert(0, paySum);

    }


    protected void FillddlCompany()
    {
        var objblUserManagement = new BL.UserManagement();
        var dsCompany = objblUserManagement.UserCompanyAccessGet(BaseUserID);
        if (dsCompany.Tables[0].Rows.Count > 0)
        {
            ddlCompany.DataSource = dsCompany.Tables[0];
            ddlCompany.DataValueField = "CompanyCode";
            ddlCompany.DataTextField = "CompanyDesc";
            ddlCompany.DataBind();

        }

    }

    protected void FillddlDivision()
    {
        var objblUserManagement = new BL.UserManagement();
        var dsHrLocation = objblUserManagement.UserHRLocationAccessGet(BaseUserID, ddlCompany.SelectedValue);
        if (dsHrLocation.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsHrLocation.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();
            //FillddlBranch();

        }
    }

    protected void FillddlBranch()
    {
        ddlBranch.Items.Clear();
        var objblMstManagement = new BL.MastersManagement();
        var arrHrLocationCode = ddlDivision.Text.Split(',');

        var ds = objblMstManagement.LocationDescriptionGetAll(ddlCompany.SelectedValue, arrHrLocationCode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = ds.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
        }


    }


    protected void FillClient()
    {
        var objSale = new BL.Sales();
        var ds = objSale.ClientHRLocationWiseGet(ddlCompany.SelectedValue, "", "");

        var dt = new DataTable();
        var arrClientCode = ddlBranch.Text.Split(',');

        if (arrClientCode.Length > 0)
        {
            dt.Columns.Add(new DataColumn("LocationCode", typeof(string)));
            foreach (var t in arrClientCode)
            {
                var dr = dt.NewRow();
                dr["LocationCode"] = t;
                dt.Rows.Add(dr);
            }
        }


        var client = ds.Tables[0].AsEnumerable();
        var location = dt.AsEnumerable();

        var query =
            from cl in client
            join loc in location
            on cl.Field<string>("LocationCode")
            equals loc.Field<string>("LocationCode")
            select new
            {
                ClientCode =
                    cl.Field<string>("ClientCode"),
                ClientName =
                    cl.Field<string>("ClientName")
            };

        var dtResult = new DataTable();
        dtResult.Columns.Add(new DataColumn("ClientCode", typeof(string)));
        dtResult.Columns.Add(new DataColumn("ClientName", typeof(string)));

        foreach (var result in query)
        {
            dtResult.Rows.Add(new object[] { result.ClientCode, result.ClientName });
        }



        ddlClient.DataSource = dtResult;
        ddlClient.DataValueField = "ClientCode";
        ddlClient.DataTextField = "ClientName";
        ddlClient.DataBind();
    }

    private void FillCategory()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlEmpCategory.DataSource = objMastersManagement.CategoryMasterGetAll(BaseCompanyCode);
        ddlEmpCategory.DataTextField = "CategoryDesc";
        ddlEmpCategory.DataValueField = "CategoryCode";
        ddlEmpCategory.DataBind();

    }

    private void FillJobClass()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlJobClass.DataSource = objMastersManagement.JobClassMasterGetAll(BaseCompanyCode);
        ddlJobClass.DataTextField = "JobClassDesc";
        ddlJobClass.DataValueField = "JobClassCode";
        ddlJobClass.DataBind();

    }

    private void FillJobType()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlJobType.DataSource = objMastersManagement.JobTypeMasterGetAll(BaseCompanyCode);
        ddlJobType.DataTextField = "JobTypeDesc";
        ddlJobType.DataValueField = "JobTypeCode";
        ddlJobType.DataBind();

    }

    /// <summary>
    /// Fill Employee Designation from Designation table.
    /// </summary>
    private void FillDesignation()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlDesignation.DataSource = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        ddlDesignation.DataTextField = "DesignationDesc";
        ddlDesignation.DataValueField = "DesignationCode";
        ddlDesignation.DataBind();

    }

    private void ContractualDays()
    {
        var objHrManagement = new BL.HRManagement();
        ddlContractDaysType.DataSource = objHrManagement.EmployeeContractualDaysGet(BaseCompanyCode);
        ddlContractDaysType.DataTextField = "ItemDesc";
        ddlContractDaysType.DataValueField = "ItemDesc";
        ddlContractDaysType.DataBind();

    }

    private void FillPaysumElements()
    {
        for (var j = 0; j < chkPaysumElements.Items.Count; j++)
        {
            chkPaysumElements.Items[j].Selected = false;
        }
        var objBR = new BL.BusinessRule();
        var ds = objBR.PaysumElementsGet(BaseCompanyCode, HdnBrCode.Value, ddlPaySumCodeFormat.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (var j = 0; j < chkPaysumElements.Items.Count; j++)
                {
                    if (chkPaysumElements.Items[j].Value == ds.Tables[0].Rows[i]["ElementName"].ToString())
                    {
                        chkPaysumElements.Items[j].Selected = true;
                    }
                    //else
                    //{
                    //    chkPaysumElements.Items[j].Selected = false;
                    //}
                }

            }
        }
    }
    #endregion
    #region Shift Tab
    private void FillShift()
    {

        FillShiftMode(HdnBrCode.Value);
        var objBr = new BL.BusinessRule();
        var ds = objBr.ShiftGet(HdnBrCode.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvShift.DataSource = ds.Tables[0];
            gvShift.DataBind();
            gvShift.Columns[6].Visible = false;
            gvShift.Columns[7].Visible = false;
            //Hide Grid Coloumn basis of Mode Value.
            if (ddlgvShiftMode.SelectedValue == "Range")
            {
                var lblgvHdrShiftStartTime = (Label)gvShift.HeaderRow.Cells[2].FindControl("lblgvHdrShiftStartTime");
                var lblgvHdrShiftEndTime = (Label)gvShift.HeaderRow.Cells[2].FindControl("lblgvHdrShiftEndTime");
                lblgvHdrShiftStartTime.Text = Resources.Resource.ShiftStartTimeStartRange;
                lblgvHdrShiftEndTime.Text = Resources.Resource.ShiftStartTimeEndRange;

                //gvShift.Columns[2].HeaderText = "StartTime StartRange";
                //gvShift.Columns[3].HeaderText = "StartTime EndRange";
                gvShift.Columns[6].Visible = true;
                gvShift.Columns[7].Visible = true;

            }


        }
        else
        {
            if (ds != null)
            {
                var dt = ds.Tables[0];
                dt.Rows.Add(dt.NewRow());

                gvShift.DataSource = dt;
            }
            gvShift.DataBind();
            gvShift.Rows[0].Visible = false;
            if (ddlgvShiftMode.SelectedValue == "Range")
            {
                gvShift.Columns[6].Visible = true;
                gvShift.Columns[7].Visible = true;
            }
            else
            {
                gvShift.Columns[6].Visible = false;
                gvShift.Columns[7].Visible = false;

            }

        }
    }
    protected void gvShift_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //-- ------------For Afternoon shift Added some new column Manish 8-jan2013----------------
        if (e.CommandName == "AddNew")
        {


            var objBr = new BL.BusinessRule();


            var ddlgvShiftName = (DropDownList)gvShift.FooterRow.FindControl("ddlgvShiftName");
            var txtgvShiftStartTime = (TextBox)gvShift.FooterRow.FindControl("txtgvShiftStartTime");
            var txtgvShiftEndTime = (TextBox)gvShift.FooterRow.FindControl("txtgvShiftEndTime");
            var txtgvShiftMinimumMin = (TextBox)gvShift.FooterRow.FindControl("txtgvShiftMinimumMin");
            var txtgvShiftStartRange = (TextBox)gvShift.FooterRow.FindControl("txtgvShiftStartRange");
            var txtgvShiftEndRange = (TextBox)gvShift.FooterRow.FindControl("txtgvShiftEndRange");
            var rdgvIsDefault = (CheckBox)gvShift.FooterRow.FindControl("rdgvIsDefault");

            if (HdnBrCode.Value != "")
            {


                var ds = objBr.ShiftInsert(ddlgvShiftName.SelectedItem.Value, txtgvShiftStartTime.Text, txtgvShiftEndTime.Text, int.Parse(string.IsNullOrEmpty(txtgvShiftMinimumMin.Text) ? "0" : txtgvShiftMinimumMin.Text), BaseUserID, HdnBrCode.Value, rdgvIsDefault.Checked, txtgvShiftStartRange.Text, txtgvShiftEndRange.Text, ddlgvShiftMode.SelectedItem.Value);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(LabelErrorMsgShift, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                FillShift();
                //Once We add immediately we can fill for Distribited Hours tab 
                FillShiftForDutyHours(HdnBrCode.Value);


            }
            else
            {
                LabelErrorMsgShift.Text = Resources.Resource.SelectBusinessRule;
                return;
            }
        }

    }
    protected void gvShift_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvShift.EditIndex = e.NewEditIndex;

    }
    protected void gvShift_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvShift.EditIndex = -1;

    }
    protected void gvShift_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        var objBr = new BL.BusinessRule();
        var lblgvShiftName = (Label)gvShift.Rows[e.RowIndex].FindControl("lblgvShiftName");
        var ds = objBr.ShiftDelete(lblgvShiftName.Text, HdnBrCode.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(LabelErrorMsgShift, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        FillShift();
    }
    void FillShiftMode(string brCode)
    {
        ddlgvShiftMode.Items.Clear();
        var objBr = new BL.BusinessRule();
        var ds = objBr.ShiftModeGet(HdnBrCode.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlgvShiftMode.Items.Add(new ListItem(ds.Tables[0].Rows[0]["Mode"].ToString(), ds.Tables[0].Rows[0]["Mode"].ToString()));
        }

        else
        {
            ddlgvShiftMode.Items.Add(new ListItem("Time", "Time"));
            ddlgvShiftMode.Items.Add(new ListItem("Range", "Range"));
        }

    }
    protected void ddlgvShiftMode_Changed(object sender, EventArgs e)
    {

        if (ddlgvShiftMode.SelectedValue == "Range")
        {
            gvShift.Columns[6].Visible = true;
            gvShift.Columns[7].Visible = true;
            var lblgvHdrShiftStartTime = (Label)gvShift.HeaderRow.Cells[2].FindControl("lblgvHdrShiftStartTime");
            var lblgvHdrShiftEndTime = (Label)gvShift.HeaderRow.Cells[2].FindControl("lblgvHdrShiftEndTime");
            lblgvHdrShiftStartTime.Text = Resources.Resource.ShiftStartTimeStartRange;
            lblgvHdrShiftEndTime.Text = Resources.Resource.ShiftStartTimeEndRange;
        }
        else
        {

            var lblgvHdrShiftStartTime = (Label)gvShift.HeaderRow.Cells[2].FindControl("lblgvHdrShiftStartTime");
            var lblgvHdrShiftEndTime = (Label)gvShift.HeaderRow.Cells[2].FindControl("lblgvHdrShiftEndTime");
            lblgvHdrShiftStartTime.Text = Resources.Resource.StartTime;
            lblgvHdrShiftEndTime.Text = Resources.Resource.EndTime;
            gvShift.Columns[6].Visible = false;
            gvShift.Columns[7].Visible = false;

        }
    }
    #endregion
    #region define Business Rule

    protected void ddlCompany_Changed(object sender, EventArgs e)
    {

        FillddlDivision();
    }
    protected void ddlDivision_Changed(object sender, EventArgs e)
    {
        FillddlBranch();
    }
    protected void ddlBranch_Changed(object sender, EventArgs e)
    {

        FillClient();
    }
    /// <summary>
    /// BusinessRuleAddNew 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        var objBR = new BL.BusinessRule();
        var objCommon = new BL.Common();

        if (txtBusinessRuleDesc.Text.Trim() == "" || txtBusinessRuleDesc.Text.Trim().Length == 0)
        {

            lblerror.Text = Resources.Resource.DescriptionnotBlank;
            return;
        }
        else if (txtBusinessRule.Text.Trim() == "" || txtBusinessRule.Text.Trim().Length == 0)
        {
            lblerror.Text = Resources.Resource.BusinessRuleCodenotBlank;
            return;
        }
        else if (txtPaySumCode.Text.Trim() == "" || txtPaySumCode.Text.Trim().Length == 0)
        {
            lblerror.Text = Resources.Resource.PaySumCodenotBlank;
            return;
        }
        else if (txtPaySumcodeDesc.Text.Trim() == "" || txtPaySumcodeDesc.Text.Trim().Length == 0)
        {
            lblerror.Text = Resources.Resource.PaySumDescriptionnotBlank;
            return;
        }

        else if (txtEffectiveFrom.Text.Trim() == "" || txtEffectiveFrom.Text.Trim().Length == 0)
        {
            lblerror.Text = Resources.Resource.EffectiveFromDatenotBlank;
            return;
        }
        else if (ddlCompany.SelectedValue.ToString() == "" || ddlCompany.SelectedValue.ToString().Length == 0)
        {
            lblerror.Text = Resources.Resource.CompanynotBlank;
            return;
        }
        else if (objCommon.IsValidDate(txtEffectiveFrom.Text) != true)
        {
            lblerror.Text = Resources.Resource.InvalidDate;
            txtEffectiveFrom.Focus();
            return;
        }



        var ds = btnSave.Text == Resources.Resource.Save ? objBR.BusinessRuleAddNew(txtBusinessRule.Text.Trim(), txtBusinessRuleDesc.Text.Trim(), ddlCompany.SelectedValue.ToString(), ddlDivision.Text, ddlBranch.Text, ddlClient.Text, ddlContractDaysType.Text, ddlEmpCategory.Text, txtEffectiveFrom.Text, "", chkIsDefaultRule.Checked, BaseUserID, int.Parse(BaseLocationAutoID), ddlJobClass.Text, ddlJobType.Text, ddlDesignation.Text, txtPaySumCode.Text, txtPaySumcodeDesc.Text, chkConsiderBreakHrs.Checked, chkConsiderUnconfirmedDuty.Checked) : objBR.BusinessRuleUpdate(txtBusinessRule.Text, txtBusinessRuleDesc.Text, ddlCompany.SelectedValue.ToString(), ddlDivision.Text, ddlBranch.Text, ddlClient.Text, ddlContractDaysType.Text, ddlEmpCategory.Text, txtEffectiveFrom.Text, "", chkIsDefaultRule.Checked, BaseUserID, ddlJobClass.Text, ddlJobType.Text, ddlDesignation.Text, chkConsiderBreakHrs.Checked, chkConsiderUnconfirmedDuty.Checked);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblerror.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
            FillExistingRules();
            ddlBR.SelectedValue = txtBusinessRule.Text;
            //Assign Value Once we add business Rule.
            hdnPaySumCode.Value = txtBusinessRule.Text;
            HdnBrCode.Value = txtPaySumCode.Text;
            lblBusinessRuleStep6.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblBusinessRuleStep7.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblBusinessRuleStep8.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblBusinessRuleStep2.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblBusinessRuleStepCW.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblpaySumcodePayperiod.Text = @"(" + txtPaySumCode.Text + @")";
            lblBusinessRuleStepDisAdj.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            //Fill all the tab once we added new Rule
            LoadPayPeriod(hdnPaySumCode.Value);
            FillWeeklyHoursHead();
            FillgvPaysumReadiness();
            FillShift();
            FillDefaultWHTimings();
            //Fill ddlShift dynamically we have written this code.
            FillShiftForDutyHours(HdnBrCode.Value);
            FillPaySumCode();
            FillHoursDistributionAdjusment();

        }

    }
    protected void ddlBR_SelectedIndexChanged(object sender, EventArgs e)
    {

        lblerror.Text = "";
        var objBR = new BL.BusinessRule();
        var ds = objBR.BusinessRuleGet(ddlBR.SelectedValue.ToString(), int.Parse(BaseLocationAutoID));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            txtBusinessRule.Text = ds.Tables[0].Rows[0]["BusinessRuleCode"].ToString();
            txtBusinessRuleDesc.Text = ds.Tables[0].Rows[0]["BusinessRuleDesc"].ToString();
            txtPaySumCode.Text = ds.Tables[0].Rows[0]["PaysumCode"].ToString();
            txtPaySumcodeDesc.Text = ds.Tables[0].Rows[0]["PaysumCodeDesc"].ToString();
            ddlPaysumCode.SelectedValue = ds.Tables[0].Rows[0]["PaysumCode"].ToString();
            txtEffectiveFrom.Text = ds.Tables[0].Rows[0]["EffectiveFrom"].ToString();
            ddlCompany.SelectedValue = ds.Tables[0].Rows[0]["CompanyCode"].ToString();
            FillddlDivision();
            ddlDivision.Text = ds.Tables[0].Rows[0]["HrLocationCode"].ToString();
            FillddlBranch();
            ddlBranch.Text = ds.Tables[0].Rows[0]["LocationCode"].ToString();
            FillClient();
            ddlClient.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
            ddlContractDaysType.Text = ds.Tables[0].Rows[0]["ContractDays"].ToString();
            ddlEmpCategory.Text = ds.Tables[0].Rows[0]["EmpCategory"].ToString();

            ddlJobClass.Text = ds.Tables[0].Rows[0]["EmpJobClass"].ToString();
            ddlJobType.Text = ds.Tables[0].Rows[0]["EmpJobType"].ToString();
            ddlDesignation.Text = ds.Tables[0].Rows[0]["DesignationCode"].ToString();
            chkConsiderBreakHrs.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ConsiderBreakHrs"]);
            chkConsiderUnconfirmedDuty.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ConsiderUnconfirmedDuty"]);
            // As per Discussion With Manish 24-03 2014.IF any rule is set IsDefaultRule then chkIsDefaultRule always disable.
            //We can update the IsDefaultRule existing default rule Only.
            chkIsDefaultRule.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsDefaultRule"]);
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsDefaultRule"])==true)
            {
                chkIsDefaultRule.Enabled = true;
               // chkIsDefaultRule.Checked = true;
            }
            //else
            //{
            //    chkIsDefaultRule.Enabled = false;
            //   // chkIsDefaultRule.Checked = false;
            //}


            lblBusinessRuleStep6.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblBusinessRuleStep7.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblBusinessRuleStep8.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblBusinessRuleStep2.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblBusinessRuleStepCW.Text = @"(" + txtBusinessRuleDesc.Text + @")";
            lblpaySumcodePayperiod.Text = @"(" + txtPaySumCode.Text + @")";
            lblBusinessRuleStepDisAdj.Text = @"(" + txtBusinessRuleDesc.Text + @")";

            ds = objBR.FormulaNameGet(HdnBrCode.Value);
            lbFormula.DataSource = ds.Tables[0];
            lbFormula.DataTextField = "FormulaName";
            lbFormula.DataValueField = "FormulaExpression";
            lbFormula.DataBind();

            ds.Dispose();

            txtBusinessRule.Enabled = false;
            btnSave.Text = Resources.Resource.Update;
            txtPaySumCode.Enabled = false;
            txtPaySumcodeDesc.Enabled = false;
            ddlPaysumCode.Enabled = false;

        }
        else
        {
            btnSave.Text = Resources.Resource.Save;
            txtBusinessRule.Enabled = true;
            txtBusinessRule.Text = "";
            txtBusinessRuleDesc.Text = "";
            txtEffectiveFrom.Text = "";
            ddlDivision.Text = "";
            ddlBranch.Text = "";
            ddlClient.Text = "";
            ddlContractDaysType.Text = "";
            ddlEmpCategory.Text = "";
            ddlJobClass.Text = "";
            ddlJobType.Text = "";
            ddlDesignation.Text = "";
            txtPaySumCode.Text = "";
            txtPaySumcodeDesc.Text = "";
            txtPaySumCode.Enabled = true;
            txtPaySumcodeDesc.Enabled = true;
            ddlPaysumCode.Enabled = true;
            ddlPaysumCode.SelectedIndex = -1;
            //ddlPaysumCode.Enabled = true;


        }
        // PaySumControlHideUndide();
        HdnBrCode.Value = ddlBR.SelectedValue;
        hdnPaySumCode.Value = ddlPaysumCode.SelectedValue;
        LoadPayPeriod(hdnPaySumCode.Value);
        FillWeeklyHoursHead();
        FillgvPaysumReadiness();
        FillShift();
        FillDefaultWHTimings();
        //Fill ddlShift dynamically we have written this code.
        FillShiftForDutyHours(HdnBrCode.Value);
        FillPaySumCode();
        FillHoursDistributionAdjusment();
        FillWeeklyOffDropDown(HdnBrCode.Value);


    }
    protected void ddlPaysumCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaysumCode.SelectedValue == "")
        {
            txtPaySumCode.Text = string.Empty;
            txtPaySumcodeDesc.Text = string.Empty;
        }
        else
        {
            txtPaySumCode.Text = ddlPaysumCode.SelectedItem.Value;
            txtPaySumcodeDesc.Text = ddlPaysumCode.SelectedItem.Text;
        }

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        var objBR = new BL.BusinessRule();
        var ds = objBR.BusinessRuleDelete(HdnBrCode.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblerror, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        FillExistingRules();
    }

    //protected void PaySumControlHideUndide()
    //{
    //    if (ddlPaysumCode.SelectedItem.Text != "Setup New Paysume Code")
    //    {
    //        txtPaySumCode.Visible = false;
    //        txtPaySumcodeDesc.Visible = false;
    //        lblpaySumCode.Visible = false;
    //        lblPaySumcodeDesc.Visible = false;
    //        ddlPaysumCode.Enabled = false;

    //    }
    //    else

    //        {
    //            txtPaySumCode.Visible = true;
    //            txtPaySumcodeDesc.Visible = true;
    //            lblpaySumCode.Visible = true;
    //            lblPaySumcodeDesc.Visible = true;
    //            ddlPaysumCode.Enabled = true;
    //         }
    //   }


    #endregion
    #region Weekly Off Tab

    protected void gvClientWeeklyOff_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        var ddlDayFrom = (DropDownList)gvClientWeeklyOff.FooterRow.FindControl("ddlDayFrom");
        var ddlDayTo = (DropDownList)gvClientWeeklyOff.FooterRow.FindControl("ddlDayTo");
        var txtClientWeeklyOffFromTime = (TextBox)gvClientWeeklyOff.FooterRow.FindControl("txtClientWeeklyOffFromTime");
        var txtClientWeeklyOffToTime = (TextBox)gvClientWeeklyOff.FooterRow.FindControl("txtClientWeeklyOffToTime");
        var ddlWeekOfBasedOn = (DropDownList)gvClientWeeklyOff.FooterRow.FindControl("ddlWeekOfBasedOn");
        string weekOffDependencyVal = ddlWeekOfBasedOn.SelectedItem.Value;

        if (e.CommandName == "Add")
        {
            var objBR = new BL.BusinessRule();

            if (HdnBrCode.Value != "")
            {
                if (ddlWeeklyOff.SelectedItem.Value == @"3")
                {
                    weekOffDependencyVal = ddlWeeklyOff.SelectedItem.Value;
                    var ds = objBR.ClientDefaultWeeklyHolidayTimeSave(ddlDayFrom.SelectedValue, txtClientWeeklyOffFromTime.Text, ddlDayTo.SelectedValue.ToString(), txtClientWeeklyOffToTime.Text, BaseUserID, HdnBrCode.Value);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                }
                //Update WeekOffDependency in mstBrBusinessRule table.

                objBR.WeekOffDependencyUpdate(HdnBrCode.Value, weekOffDependencyVal);
                FillDefaultWHTimings();
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.SelectBusinessRule;
                return;
            }
        }
    }

    protected void gvClientWeeklyOff_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvClientWeeklyOff.EditIndex = e.NewEditIndex;
        FillDefaultWHTimings();
    }

    protected void gvClientWeeklyOff_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvClientWeeklyOff.EditIndex = -1;
        FillDefaultWHTimings();
    }

    protected void gvClientWeeklyOff_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var gvClientWeeklyOffTxtDayFrom = (TextBox)gvClientWeeklyOff.Rows[e.RowIndex].FindControl("gvClientWeeklyOffTxtDayFrom");
        var gvClientWeeklyOffTxtDayTo = (TextBox)gvClientWeeklyOff.Rows[e.RowIndex].FindControl("gvClientWeeklyOffTxtDayTo");
        var gvClientWeeklyOffTxtTimeFrom = (TextBox)gvClientWeeklyOff.Rows[e.RowIndex].FindControl("gvClientWeeklyOffTxtTimeFrom");
        var gvClientWeeklyOffTxtTimeTo = (TextBox)gvClientWeeklyOff.Rows[e.RowIndex].FindControl("gvClientWeeklyOffTxtTimeTo");
        var gvClientWeeklyOffID = (LinkButton)gvClientWeeklyOff.Rows[e.RowIndex].FindControl("gvClientWeeklyOffID");

        var objBR = new BL.BusinessRule();
        var ds = objBR.ClientDefaultWeeklyHolidayTimeUpdate(int.Parse(gvClientWeeklyOffID.Text), gvClientWeeklyOffTxtDayFrom.Text, gvClientWeeklyOffTxtTimeFrom.Text, gvClientWeeklyOffTxtDayTo.Text, gvClientWeeklyOffTxtTimeTo.Text, BaseUserID, HdnBrCode.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        gvClientWeeklyOff.EditIndex = -1;
        FillDefaultWHTimings();

    }

    protected void gvClientWeeklyOff_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var gvClientWeeklyOffID = (LinkButton)gvClientWeeklyOff.Rows[e.RowIndex].FindControl("gvClientWeeklyOffID");

        var objBR = new BL.BusinessRule();
        var ds = objBR.ClientDefaultWeeklyHolidayTimeDelete(int.Parse(gvClientWeeklyOffID.Text), HdnBrCode.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

        FillDefaultWHTimings();


    }


    protected void FillDefaultWHTimings()
    {

        //Manish WeeklyOff default Changes
        FillWeeklyOffDropDown(HdnBrCode.Value);
        //We are hiding grid on the basis off  ddlWeeklyOff.SelectedValue 
        if (ddlWeeklyOff.SelectedValue == "1")
        {
            gvClientWeeklyOff.Visible = false;
        }

        if (ddlWeeklyOff.SelectedValue == "2")
        {
            gvClientWeeklyOff.Visible = false;
        }
        if (ddlWeeklyOff.SelectedValue == "3")
        {
            gvClientWeeklyOff.Visible = true;
            gvClientWeeklyOff.Columns[0].Visible = true;
            gvClientWeeklyOff.Columns[1].Visible = true;
            gvClientWeeklyOff.Columns[2].Visible = true;
            gvClientWeeklyOff.Columns[3].Visible = false;
        }
        if (ddlWeeklyOff.SelectedValue == "4")
        {
            gvClientWeeklyOff.Visible = false;
        }

        var objBR = new BL.BusinessRule();
        var ds = objBR.ClientWeeklyHolidayTimeGet(HdnBrCode.Value);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvClientWeeklyOff.DataSource = ds.Tables[0];
            gvClientWeeklyOff.DataBind();
        }
        else
        {
            if (ds != null)
            {
                var dt = ds.Tables[0];
                dt.Rows.Add(dt.NewRow());
                gvClientWeeklyOff.DataSource = dt;
            }
            gvClientWeeklyOff.DataBind();
            gvClientWeeklyOff.Rows[0].Visible = false;
        }

    }

    void FillWeeklyOffDropDown(string HdnBrCode)
    {
        ddlWeeklyOff.Items.Clear();
        var objBr = new BL.BusinessRule();
        var ds = objBr.WeeklyOffGet(HdnBrCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[0].Rows[0]["WeekOffDependency"].ToString() != string.Empty)
            {
                var weekOffDependencyVal = int.Parse(ds.Tables[0].Rows[0]["WeekOffDependency"].ToString());

                switch (weekOffDependencyVal)
                {
                    case 1:
                        ddlWeeklyOff.Items.Add(new ListItem(@"Flexible WeeklyOff based on Schedule", @"1"));
                        break;
                    case 2:
                        ddlWeeklyOff.Items.Add(new ListItem(@"Flexible WeeklyOff based on Actual", @"2"));
                        break;
                    case 3:
                        ddlWeeklyOff.Items.Add(new ListItem(@"Fixed day WeeklyOff based on Time", @"3"));
                        break;
                    default:
                        ddlWeeklyOff.Items.Add(new ListItem(@"Please select--------", @"4"));
                        ddlWeeklyOff.Items.Add(new ListItem(@"Flexible WeeklyOff based on Schedule/Actual", @"1"));
                        //ddlWeeklyOff.Items.Add(new ListItem("Flexible WeeklyOff based on Actual", "2"));
                        ddlWeeklyOff.Items.Add(new ListItem(@"Fixed day WeeklyOff  based on Time", @"3"));
                        break;
                }
            }
            else
            {
                ddlWeeklyOff.Items.Add(new ListItem(@"Please select--------", @"4"));
                ddlWeeklyOff.Items.Add(new ListItem(@"Flexible WeeklyOff based on Schedule", @"1"));
                // ddlWeeklyOff.Items.Add(new ListItem("Flexible WeeklyOff based on Actual", "2"));
                ddlWeeklyOff.Items.Add(new ListItem(@"Flexible WeeklyOff based on Time", @"3"));


            }
        }
    }
    protected void ddlWeeklyOff_Changed(object sender, EventArgs e)
    {

        if (ddlWeeklyOff.SelectedValue == @"1" || ddlWeeklyOff.SelectedValue == @"2")
        {

            gvClientWeeklyOff.Columns[0].Visible = false;
            gvClientWeeklyOff.Columns[1].Visible = false;
            gvClientWeeklyOff.Columns[2].Visible = false;
            gvClientWeeklyOff.Columns[3].Visible = true;
            gvClientWeeklyOff.Visible = true;

        }

        if (ddlWeeklyOff.SelectedValue == "3")
        {

            gvClientWeeklyOff.Columns[0].Visible = true;
            gvClientWeeklyOff.Columns[1].Visible = true;
            gvClientWeeklyOff.Columns[2].Visible = true;
            gvClientWeeklyOff.Columns[3].Visible = false;
            gvClientWeeklyOff.Visible = true;
        }
    }
    protected void linkBtnViewClient_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var gvClientWeeklyOffID = (LinkButton)gvClientWeeklyOff.Rows[row.RowIndex].FindControl("gvClientWeeklyOffID");

        intClientWeeklyOffID = int.Parse(gvClientWeeklyOffID.Text);
        var objBR = new BL.BusinessRule();
        var ds = objBR.ClientWeeklyHolidayTimeGetAll(intClientWeeklyOffID);

        gvClientWhTime.DataSource = ds.Tables[0];
        gvClientWhTime.DataBind();

        panSetWhTime.Visible = true;
    }

    protected void linkgvClientWhTimeClientCode_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var linkgvClientWhTimeClientCode = (LinkButton)gvClientWhTime.Rows[row.RowIndex].FindControl("linkgvClientWhTimeClientCode");
        var lblgvClientWhTimeFromDay = (Label)gvClientWhTime.Rows[row.RowIndex].FindControl("lblgvClientWhTimeFromDay");
        var lblgvClientWhTimeToDay = (Label)gvClientWhTime.Rows[row.RowIndex].FindControl("lblgvClientWhTimeToDay");
        var lblgvClientWhTimeFromTime = (Label)gvClientWhTime.Rows[row.RowIndex].FindControl("lblgvClientWhTimeFromTime");
        var lblgvClientWhTimeToTime = (Label)gvClientWhTime.Rows[row.RowIndex].FindControl("lblgvClientWhTimeToTime");


        lblClientCode.Text = linkgvClientWhTimeClientCode.Text;
        ddlEditDayFrom.SelectedValue = lblgvClientWhTimeFromDay.Text;
        ddlEditDayTo.SelectedValue = lblgvClientWhTimeToDay.Text;
        txtEditTimeFrom.Text = lblgvClientWhTimeFromTime.Text;
        txtEditTimeTo.Text = lblgvClientWhTimeToTime.Text;



    }


    protected void btnClientWHTimeSave_Click(object sender, EventArgs e)
    {
        var objBR = new BL.BusinessRule();
        var ds = objBR.ClientWeeklyHolidayTimeSave(intClientWeeklyOffID, lblClientCode.Text, ddlEditDayFrom.SelectedValue, txtEditTimeFrom.Text, ddlEditDayTo.SelectedValue, txtEditTimeTo.Text, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg1.Text = @"sucessfully saved";
        }

        ds = objBR.ClientWeeklyHolidayTimeGetAll(intClientWeeklyOffID);
        gvClientWhTime.DataSource = ds.Tables[0];
        gvClientWhTime.DataBind();


    }
    #endregion
    #region Holiday Tab

    protected void HolidayType_Click(object sender, EventArgs e)
    {
        if (TimeBasedHoliday.Checked)
        {
            if (txtHolidayFromTime.Text.Length == 0 || txtHolidayToTime.Text.Length == 0)
            {
                lblMsgHolidayError.Text = @"Start Time / End Time cannot be blank!";
                return;
            }
        }
        else
        {
            txtHolidayFromTime.Text = @"00:00";
            txtHolidayToTime.Text = @"00:00";
        }

        var objBusiness = new BL.BusinessRule();
        var ds = new DataSet();

        try
        {

            ds = objBusiness.HolidayDefaultTimesInsert(DateBasedHoliday.Checked, TimeBasedHoliday.Checked, txtHolidayFromTime.Text, txtHolidayToTime.Text, BaseUserID.ToString());
            HolidayTypePanel.Visible = false;
            FillgvHoliday();
        }
        catch (Exception er)
        {
            lblMsgHolidayError.Text = er.Message.ToString();
        }

    }

    private void FillgvHoliday()
    {
        var objMastersManagement = new BL.MastersManagement();
        var dtflag = 1;
        var ds = objMastersManagement.HolidayGetAll(BaseLocationAutoID);

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            HolidayTypePanel.Visible = false;
            lblHolidayHead.Visible = true;
            gvHoliday.Visible = true;
            gvClientHoliday.Visible = true;
        }
        else
        {
            HolidayTypePanel.Visible = true;
            lblHolidayHead.Visible = false;
            gvHoliday.Visible = false;
            gvClientHoliday.Visible = false;
            return;
        }

        var dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvHoliday.DataSource = dt;
        gvHoliday.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvHoliday.Rows[0].Visible = false;
        }
    }

    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        var row = gvHoliday.BottomPagerRow;
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvHoliday.PageIndex = ddlPages.SelectedIndex;
        FillgvHoliday();
    }

    protected void gvHoliday_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvHoliday.BottomPagerRow;
        var ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvHoliday.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvHoliday.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvHoliday.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvHoliday.PageIndex = e.NewPageIndex;
        }
        gvHoliday.EditIndex = -1;
        FillgvHoliday();
    }

    protected void gvHoliday_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvHoliday.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvHoliday.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvHoliday.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvHoliday.PageCount.ToString();
        }

    }

    protected void lnkHolidayCode_Click(object sender, EventArgs e)
    {

        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfHolidayCode = (HiddenField)gvHoliday.Rows[row.RowIndex].FindControl("hfHolidayCode");
        Label lblHolidayDate = (Label)gvHoliday.Rows[row.RowIndex].FindControl("lblHolidayDate");
        strHolidayCode = hfHolidayCode.Value;
        strHolidayDate = lblHolidayDate.Text;
        FillClientHoliday();

    }

    private void FillClientHoliday()
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.ClientHolidayGetAll(int.Parse(BaseLocationAutoID), strHolidayCode, strHolidayDate);

        gvClientHoliday.DataSource = ds.Tables[0];
        gvClientHoliday.DataBind();

    }

    protected void gvClientHoliday_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvClientHoliday.EditIndex = e.NewEditIndex;
        FillClientHoliday();

    }

    protected void gvClientHoliday_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var lblgvClientHolidayClientCode = (Label)gvClientHoliday.Rows[e.RowIndex].FindControl("lblgvClientHolidayClientCode");
        var hidgvClientHolidayDate = (HiddenField)gvClientHoliday.Rows[e.RowIndex].FindControl("hidgvClientHolidayDate");
        var hidgvClientHolidayCode = (HiddenField)gvClientHoliday.Rows[e.RowIndex].FindControl("hidgvClientHolidayCode");
        var hidgvClientHolidayAutoId = (HiddenField)gvClientHoliday.Rows[e.RowIndex].FindControl("hidgvClientHolidayAutoId");
        var txtgvClientHolidayFromTime = (TextBox)gvClientHoliday.Rows[e.RowIndex].FindControl("txtgvClientHolidayFromTime");
        var txtgvClientHolidayToTime = (TextBox)gvClientHoliday.Rows[e.RowIndex].FindControl("txtgvClientHolidayToTime");


        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.ClientHolidaySave(int.Parse(hidgvClientHolidayAutoId.Value), hidgvClientHolidayCode.Value, hidgvClientHolidayDate.Value, lblgvClientHolidayClientCode.Text, txtgvClientHolidayFromTime.Text, txtgvClientHolidayToTime.Text, BaseUserID);
        gvClientHoliday.EditIndex = -1;
        FillClientHoliday();
    }

    protected void gvClientHoliday_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvClientHoliday.EditIndex = -1;
        FillClientHoliday();
    }

    protected void gvClientHoliday_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClientHoliday.PageIndex = e.NewPageIndex;
        FillClientHoliday();
    }

    #endregion
    #region payperiod Tab
    //Business Rule Code Is Replaced By PaySumCode
    protected void LoadPayPeriod(string strPaySumCode)
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.PayPeriodGet(strPaySumCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[0].Rows[0]["PayperiodType"].ToString() == BL.EnumPayPeriod.M.ToString())
            {
                RadioMonthly.Checked = true;
                txtStartDay_Monthly.Text = ds.Tables[0].Rows[0]["MonthStartDay"].ToString();
                txtEndDay_Monthly.Text = ds.Tables[0].Rows[0]["MonthEndDay"].ToString();
            }
            else if (ds.Tables[0].Rows[0]["PayperiodType"].ToString() == BL.EnumPayPeriod.F.ToString())
            {
                RadioFortnightly.Checked = true;
                txtStartDay_FirstFortnightly.Text = ds.Tables[0].Rows[0]["FirstFortNightStartDay"].ToString();
                txtEndDay_FirstFortnightly.Text = ds.Tables[0].Rows[0]["FirstFortNightEndDay"].ToString();
                txtStartDay_SecondFortnightly.Text = ds.Tables[0].Rows[0]["SecondFortNightStartDay"].ToString();
                txtEndDay_SecondFortnightly.Text = ds.Tables[0].Rows[0]["SecondFortNightEndDay"].ToString();
            }
            else if (ds.Tables[0].Rows[0]["PayperiodType"].ToString() == BL.EnumPayPeriod.W.ToString())
            {
                RadioWeekly.Checked = true;
                txtStartDay_Weekly.Text = ds.Tables[0].Rows[0]["WeekFirstDay"].ToString();
                txtEndDay_Weekly.Text = ds.Tables[0].Rows[0]["WeekLastDay"].ToString();
            }
            else if (ds.Tables[0].Rows[0]["PayperiodType"].ToString() == BL.EnumPayPeriod.W2.ToString())
            {
                RadioTwoWeeks.Checked = true;
                txtStartDay_Weekly.Text = ds.Tables[0].Rows[0]["WeekFirstDay"].ToString();
                txtEndDay_Weekly.Text = ds.Tables[0].Rows[0]["WeekLastDay"].ToString();
            }
            else
            {

                lblErrorMsgPayperiod.Text = Resources.Resource.PayNotDefine;
            }


        }



    }

    protected void btnDeletePeriod_Click(object sender, EventArgs e)
    {

        var ds = new DataSet();
        BL.BusinessRule objBR = new BL.BusinessRule();
        ds = objBR.PayPeriodDelete(hdnPaySumCode.Value);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsgPayperiod, ds.Tables[0].Rows[0]["MessageID"].ToString());
            //lblerror.Text = Resources.Resource.MsgDeleteSuccessfully;
        }

    }

    protected void btnSavePeriod_Click(object sender, EventArgs e)
    {

        string strPayperiodType, strWeekFirstDay, strWeekLastDay;
        int intMonthStartDay, intMonthEndDay, intFirstFortNightStartDay, intFirstFortNightEndDay, intSecondFortNightStartDay, intSecondFortNightEndDay;
        strPayperiodType = string.Empty;
        strWeekFirstDay = string.Empty;
        strWeekLastDay = string.Empty;
        intMonthStartDay = 0;
        intMonthEndDay = 0;
        intFirstFortNightStartDay = 0;
        intFirstFortNightEndDay = 0;
        intSecondFortNightStartDay = 0;
        intSecondFortNightEndDay = 0;

        if (RadioMonthly.Checked)
        {
            strPayperiodType = BL.EnumPayPeriod.M.ToString();
            intMonthStartDay = int.Parse(txtStartDay_Monthly.Text);
            intMonthEndDay = int.Parse(txtEndDay_Monthly.Text);
        }
        else if (RadioFortnightly.Checked)
        {
            strPayperiodType = BL.EnumPayPeriod.F.ToString();
            intFirstFortNightStartDay = int.Parse(txtStartDay_FirstFortnightly.Text);
            intFirstFortNightEndDay = int.Parse(txtEndDay_FirstFortnightly.Text);
            intSecondFortNightStartDay = int.Parse(txtStartDay_SecondFortnightly.Text);
            intSecondFortNightEndDay = int.Parse(txtEndDay_SecondFortnightly.Text);

        }
        else if (RadioWeekly.Checked)
        {
            strPayperiodType = BL.EnumPayPeriod.W.ToString();
            strWeekFirstDay = txtStartDay_Weekly.Text;
            strWeekLastDay = txtEndDay_Weekly.Text;

            if (Enum.IsDefined(typeof(BL.EnumWeekday), strWeekFirstDay) == false || Enum.IsDefined(typeof(BL.EnumWeekday), strWeekLastDay) == false)
            {
                lblErrorMsgPayperiod.Text = Resources.Resource.PayperiodValuenotcorrect;
                return;
            }

        }
        else if (RadioTwoWeeks.Checked)
        {
            strPayperiodType = BL.EnumPayPeriod.W2.ToString();
            strWeekFirstDay = txtStartDay_Weekly.Text;
            strWeekLastDay = txtEndDay_Weekly.Text;
        }
        else
        {
            lblErrorMsgPayperiod.Text = Resources.Resource.PayNotDefine;
            return;
        }


        var ds = new DataSet();
        BL.BusinessRule objBR = new BL.BusinessRule();

        if (HdnBrCode.Value != "")
        {

            ds = objBR.PayPeriodInsert(hdnPaySumCode.Value, strPayperiodType, intMonthStartDay, intMonthEndDay, intFirstFortNightStartDay, intFirstFortNightEndDay, intSecondFortNightStartDay, intSecondFortNightEndDay, strWeekFirstDay, strWeekLastDay, BaseUserID);
        }
        else
        {
            lblErrorMsgPayperiod.Text = Resources.Resource.SelectBusinessRule;
            return;
        }

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsgPayperiod, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }


    }
    #endregion
    #region HoursHead Group Tab
    protected void FillHoursHeadGroup()
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.HoursHeadGroupGet();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvHrsHeadGroup.DataSource = ds.Tables[0];
            gvHrsHeadGroup.DataBind();
        }
        else
        {
            DataTable dt = ds.Tables[0];
            dt.Rows.Add(dt.NewRow());
            gvHrsHeadGroup.DataSource = dt;
            gvHrsHeadGroup.DataBind();
            gvHrsHeadGroup.Rows[0].Visible = false;

        }


        var TxtNewHrsHeadGroupCode = (TextBox)gvHrsHeadGroup.FooterRow.FindControl("TxtNewHrsHeadGroupCode");
        var txtNewHrsHeadGroupDesc = (TextBox)gvHrsHeadGroup.FooterRow.FindControl("txtNewHrsHeadGroupDesc");

        TxtNewHrsHeadGroupCode.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
        txtNewHrsHeadGroupDesc.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";


    }

    protected void gvHrsHeadGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        // To Insert a New Row
        var txtHrsHeadGroupCode = (TextBox)gvHrsHeadGroup.FooterRow.FindControl("txtNewHrsHeadGroupCode");
        var txtHrsHeadGroupDesc = (TextBox)gvHrsHeadGroup.FooterRow.FindControl("txtNewHrsHeadGroupDesc");
        if (e.CommandName == "Add")
        {
            string str = txtHrsHeadGroupCode.Text.ToString().Substring(0, 1);
            if (txtHrsHeadGroupCode.Text.ToString().Substring(0, 1) != "-")
            {
                ds = objBR.HoursHeadGroupInsert(txtHrsHeadGroupCode.Text, txtHrsHeadGroupDesc.Text, BaseUserID.ToString());
                gvHrsHeadGroup.EditIndex = -1;
                FillHoursHeadGroup();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblStep1Error, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.InvaildCode;
            }
        }
        if (e.CommandName == "Reset")
        {
            txtHrsHeadGroupCode.Text = "";
            txtHrsHeadGroupDesc.Text = "";

        }

    }
    protected void gvHrsHeadGroup_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvHrsHeadGroup.EditIndex = e.NewEditIndex;
        FillHoursHeadGroup();
    }
    protected void gvHrsHeadGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        var LinkgvHrsHrsHeadGroupCode = (LinkButton)gvHrsHeadGroup.Rows[e.RowIndex].FindControl("LinkgvHrsHrsHeadGroupCode");
        var txtHrsHeadGroupDesc = (TextBox)gvHrsHeadGroup.Rows[e.RowIndex].FindControl("txtHrsHeadGroupDesc");
        ds = objBR.HoursHeadGroupUpdate(LinkgvHrsHrsHeadGroupCode.Text, txtHrsHeadGroupDesc.Text, BaseUserID.ToString());
        gvHrsHeadGroup.EditIndex = -1;
        FillHoursHeadGroup();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblStep1Error, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    protected void gvHrsHeadGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        LinkButton LinkgvHrsHrsHeadGroupCode = (LinkButton)gvHrsHeadGroup.Rows[e.RowIndex].FindControl("LinkgvHrsHrsHeadGroupCode");
        ds = objBR.HoursHeadGroupDelete(LinkgvHrsHrsHeadGroupCode.Text);
        FillHoursHeadGroup();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblStep1Error, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    protected void gvHrsHeadGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvHrsHeadGroup.EditIndex = -1;
        FillHoursHeadGroup();
    }
    protected void gvHrsHeadGroup_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    protected void LinkgvHrsHrsHeadGroupCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton LinkgvHrsHrsHeadGroupCode = (LinkButton)gvHrsHeadGroup.Rows[row.RowIndex].FindControl("LinkgvHrsHrsHeadGroupCode");
        HdnHrsHeadGroupCode.Value = LinkgvHrsHrsHeadGroupCode.Text;
        FillHoursHead();
    }
    protected void FillHoursHead()
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.BusinessHoursHeadGet(HdnHrsHeadGroupCode.Value);
        panelHrsHead.GroupingText = HdnHrsHeadGroupCode.Value;
        gvHrsHead.DataSource = ds.Tables[0];
        gvHrsHead.DataBind();

        var txtNewHrsHeadCode = (TextBox)gvHrsHead.FooterRow.FindControl("txtNewHrsHeadCode");
        var txtNewHrsHeadDesc = (TextBox)gvHrsHead.FooterRow.FindControl("txtNewHrsHeadDesc");
        var txtEquivalentHrs = (TextBox)gvHrsHead.FooterRow.FindControl("txtEquivalentHrs");


        txtNewHrsHeadCode.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
        txtNewHrsHeadDesc.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
        txtEquivalentHrs.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

    }
    protected void gvHrsHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        // To Insert a New Row
        var txtNewHrsHeadCode = (TextBox)gvHrsHead.FooterRow.FindControl("txtNewHrsHeadCode");
        var TxtNewHrsHeadDesc = (TextBox)gvHrsHead.FooterRow.FindControl("TxtNewHrsHeadDesc");
        var txtEquivalentHrs = (TextBox)gvHrsHead.FooterRow.FindControl("txtEquivalentHrs");
        var chkgvFtrOtType = (CheckBox)gvHrsHead.FooterRow.FindControl("chkgvFtrOtType");
        var chkgvFtrreplacePostelement = (CheckBox)gvHrsHead.FooterRow.FindControl("chkgvFtrreplacePostelement");
        var chkgvFtIsPlannedOT = (CheckBox)gvHrsHead.FooterRow.FindControl("chkgvFtIsPlannedOT");
        var ddlInvHrsCategory = (DropDownList)gvHrsHead.FooterRow.FindControl("ddlInvHrsCategory");


        if (e.CommandName == "Add")
        {
            if (txtNewHrsHeadCode.Text.ToString().Substring(0, 1) != "-")
            {
                ds = objBR.HoursHeadInsert(txtNewHrsHeadCode.Text, TxtNewHrsHeadDesc.Text, HdnHrsHeadGroupCode.Value.ToString(), chkgvFtrOtType.Checked, int.Parse(txtEquivalentHrs.Text), BaseUserID.ToString(), chkgvFtrreplacePostelement.Checked, chkgvFtIsPlannedOT.Checked, ddlInvHrsCategory.SelectedValue);
                gvHrsHead.EditIndex = -1;
                FillHoursHead();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblStep1Error, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
            else
            {
                lblErrorMsg.Text = @"Invaild Code";
            }
        }
        if (e.CommandName == "Reset")
        {
            txtNewHrsHeadCode.Text = "";
            TxtNewHrsHeadDesc.Text = "";

        }

    }
    protected void gvHrsHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvHrsHead.EditIndex = e.NewEditIndex;
        FillHoursHead();
    }
    protected void gvHrsHead_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        var lblgvHrsHeadCode = (Label)gvHrsHead.Rows[e.RowIndex].FindControl("lblgvHrsHeadCode");
        var txtHrsHeadDesc = (TextBox)gvHrsHead.Rows[e.RowIndex].FindControl("txtHrsHeadDesc");
        var chkgvEditOtType = (CheckBox)gvHrsHead.Rows[e.RowIndex].FindControl("chkgvEditOtType");
        var chkgvEditreplacePostelement = (CheckBox)gvHrsHead.Rows[e.RowIndex].FindControl("chkgvEditreplacePostelement");
        var chkgvEditIsPlannedOT = (CheckBox)gvHrsHead.Rows[e.RowIndex].FindControl("chkgvEditIsPlannedOT");
        var ddlEditInvHrsCategory = (DropDownList)gvHrsHead.Rows[e.RowIndex].FindControl("ddlEditInvHrsCategory");

        ds = objBR.HoursHeadUpdate(lblgvHrsHeadCode.Text, txtHrsHeadDesc.Text, HdnHrsHeadGroupCode.Value.ToString(), chkgvEditOtType.Checked, BaseUserID.ToString(), chkgvEditreplacePostelement.Checked, chkgvEditIsPlannedOT.Checked, ddlEditInvHrsCategory.SelectedValue);
        gvHrsHead.EditIndex = -1;
        FillHoursHead();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblStep1Error, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    protected void gvHrsHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        Label lblgvHrsHeadCode = (Label)gvHrsHead.Rows[e.RowIndex].FindControl("lblgvHrsHeadCode");
        ds = objBR.HoursHeadDelete(lblgvHrsHeadCode.Text);
        FillHoursHead();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblStep1Error, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    protected void gvHrsHead_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvHrsHead.EditIndex = -1;
        FillHoursHead();
    }
    protected void gvHrsHead_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    #endregion
    #region Tab HoursDistribution

    protected void FillHrsHeads()
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.HoursHeadGroupGet();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDistributionRule.DataSource = ds.Tables[0];
            ddlDistributionRule.DataValueField = "HoursHeadGroupCode";
            ddlDistributionRule.DataTextField = "HoursHeadGroupDesc";
            ddlDistributionRule.DataBind();

            ListItem li = new ListItem();
            li.Text = Resources.Resource.Select;
            li.Value = @"0";
            ddlDistributionRule.Items.Insert(0, li);
        }


    }
    private void FillgvHoursDistribution()
    {
        lblerror.Text = "";
        BL.BusinessRule objRule = new BL.BusinessRule();

        var ds = new DataSet();
        ds = objRule.HoursHeadDistributionRuleGet("", ddlShift.SelectedValue.ToString(), ddlDistributionRule.SelectedValue.ToString(), HdnBrCode.Value.ToString(), ddlScheduleBasedOTPeriod.SelectedValue);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {

            gvHoursDistribution.DataSource = ds.Tables[1];
            gvHoursDistribution.DataBind();
        }
        else
        {
            DataTable dt = ds.Tables[1];
            dt.Rows.Add(dt.NewRow());
            gvHoursDistribution.DataSource = dt;
            gvHoursDistribution.DataBind();
            gvHoursDistribution.Rows[0].Visible = false;
        }

        Repeater reptHrsHeadFooter = (Repeater)gvHoursDistribution.FooterRow.FindControl("reptHrsHeadFooter");
        if (ds.Tables[0].Rows.Count > 0)
        {
            reptHrsHeadFooter.DataSource = ds.Tables[0];
            reptHrsHeadFooter.DataBind();

            for (int i = 0; i < reptHrsHeadFooter.Items.Count; i++)
            {
                if (ddlScheduleBasedOT.SelectedValue == "1")
                {
                    //Label lblHrsFromWithSchedule = (Label)reptHrsHeadFooter.Items[i].FindControl("lblHrsFromWithSchedule");
                    //Label lblHrsToWithSchedule = (Label)reptHrsHeadFooter.Items[i].FindControl("lblHrsToWithSchedule");
                    //Label is replaced by dropdown we used same ID of label for dropdown Manish 15-jan-2014
                    var lblHrsFromWithSchedule = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("lblHrsFromWithSchedule");
                    var lblHrsToWithSchedule = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("lblHrsToWithSchedule");

                    lblHrsToWithSchedule.Visible = true;
                    if (i.Equals(0))
                    {
                        lblHrsToWithSchedule.Visible = true;
                        lblHrsFromWithSchedule.Visible = true;
                    }

                    else if (i.Equals(reptHrsHeadFooter.Items.Count - 1))
                    {
                        lblHrsFromWithSchedule.Visible = true;
                        lblHrsToWithSchedule.Visible = true;
                    }
                    else
                    {

                        lblHrsFromWithSchedule.Visible = true;
                        lblHrsToWithSchedule.Visible = true;
                    }
                }

                if (ddlScheduleBasedOT.SelectedValue == "3")
                {
                    var ddlOverTimeFrom = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddlOverTimeFrom");
                    var ddlOverTimeTo = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddlOverTimeTo");
                    var txtHrsHeadFromFooter = (TextBox)reptHrsHeadFooter.Items[i].FindControl("txtHrsHeadFromFooter");
                    var txtHrsHeadToFooter = (TextBox)reptHrsHeadFooter.Items[i].FindControl("txtHrsHeadToFooter");


                    txtHrsHeadFromFooter.Visible = false;
                    txtHrsHeadToFooter.Visible = false;

                    ddlOverTimeFrom.Visible = true;
                    ddlOverTimeTo.Visible = true;

                }

                if (ddlScheduleBasedOT.SelectedValue == "4")
                {
                    //Label lblHrsFromWithSchedule = (Label)reptHrsHeadFooter.Items[i].FindControl("lblHrsFromWithSchedule");
                    //Label lblHrsToWithSchedule = (Label)reptHrsHeadFooter.Items[i].FindControl("lblHrsToWithSchedule");
                    //Label is replaced by dropdown we used same ID of label for dropdown Manish 15-jan-2014
                    var ddldutyOTFFrom = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddldutyOTFFrom");
                    var ddldutyOTFTo = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddldutyOTFTo");

                    ddldutyOTFFrom.Visible = true;
                    ddldutyOTFTo.Visible = true;
                    //if (i.Equals(0))
                    //{
                    //    ddldutyOTFFrom.Visible = true;
                    //    ddldutyOTFTo.Visible = true;
                    //}

                    //else if (i.Equals(reptHrsHeadFooter.Items.Count - 1))
                    //{
                    //    ddldutyOTFFrom.Visible = true;
                    //    ddldutyOTFTo.Visible = true;
                    //}
                    //else
                    //{

                    //    ddldutyOTFFrom.Visible = true;
                    //    ddldutyOTFTo.Visible = true;
                    //}
                }



            }

        }

    }
    private void FillgvNWHoursDistribution()
    {
        BL.BusinessRule objRule = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objRule.NotWorkingHoursHeadDistributionRuleGet(ddlDistributionRule.SelectedValue.ToString(), HdnBrCode.Value.ToString());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {

            gvNWHoursDistribution.DataSource = ds.Tables[1];
            gvNWHoursDistribution.DataBind();
        }
        else
        {
            DataTable dt = ds.Tables[1];
            dt.Rows.Add(dt.NewRow());
            gvNWHoursDistribution.DataSource = dt;
            gvNWHoursDistribution.DataBind();
            gvNWHoursDistribution.Rows[0].Visible = false;
        }

        Repeater reptNWHrsHeadFooter = (Repeater)gvNWHoursDistribution.FooterRow.FindControl("reptNWHrsHeadFooter");
        if (ds.Tables[0].Rows.Count > 0)
        {
            reptNWHrsHeadFooter.DataSource = ds.Tables[0];
            reptNWHrsHeadFooter.DataBind();

        }

    }
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvHoursDistribution();
    }
    protected void ddlDistributionRule_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLeaveType.Visible = false;
        if (HdnBrCode.Value != "")
        {
            lblErrorMsgHrsDistribution.Text = "";
            // TO show LEAVE Type dropdown if selected value is LEAVE           
            if (ddlDistributionRule.SelectedValue.ToUpper() == "LEAVE")
            {
                FillLeaveType();
                ddlLeaveType.Visible = true;

            }
            FillgvHoursDistribution();
            FillgvNWHoursDistribution();
        }
        else
        {
            lblErrorMsgHrsDistribution.Text = Resources.Resource.SelectBusinessRule;
            return;
        }
    }
    /// <summary>
    /// The RowCommand event is raised when a button is clicked in the GridView control.
    /// This enables you to provide an event-handling method that performs a custom routine whenever this event occurs.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHoursDistribution_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // string LeaveCode = ddlLeaveType.SelectedValue.Count() > 1 ? ddlLeaveType.SelectedValue : string.Empty;

        var chkSun = (CheckBox)gvHoursDistribution.FooterRow.FindControl("chkSun");
        var chkMon = (CheckBox)gvHoursDistribution.FooterRow.FindControl("chkMon");
        var chkTue = (CheckBox)gvHoursDistribution.FooterRow.FindControl("chkTue");
        var chkWed = (CheckBox)gvHoursDistribution.FooterRow.FindControl("chkWed");
        var chkThu = (CheckBox)gvHoursDistribution.FooterRow.FindControl("chkThu");
        var chkFri = (CheckBox)gvHoursDistribution.FooterRow.FindControl("chkFri");
        var chkSat = (CheckBox)gvHoursDistribution.FooterRow.FindControl("chkSat");
        var reptHrsHeadFooter = (Repeater)gvHoursDistribution.FooterRow.FindControl("reptHrsHeadFooter");



        string strWeekdays = string.Empty;

        if (chkSun.Checked)
        {
            strWeekdays = "1";
        }
        if (chkMon.Checked)
        {
            strWeekdays = strWeekdays + ",2";
        }
        if (chkTue.Checked)
        {
            strWeekdays = strWeekdays + ",3";
        }
        if (chkWed.Checked)
        {
            strWeekdays = strWeekdays + ",4";
        }
        if (chkThu.Checked)
        {
            strWeekdays = strWeekdays + ",5";
        } if (chkFri.Checked)
        {
            strWeekdays = strWeekdays + ",6";
        }
        if (chkSat.Checked)
        {
            strWeekdays = strWeekdays + ",7";
        }

        if (strWeekdays.StartsWith(","))
        { strWeekdays = strWeekdays.Remove(0, 1); }

        if (e.CommandName == "AddNew")
        {
            float intTotalHrs, intTmpTotalHrs, intErrorFlag;
            intTotalHrs = 0;
            intTmpTotalHrs = 0;
            intErrorFlag = 0;

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("HoursHeadCode", typeof(string)));
            dt.Columns.Add(new DataColumn("TimeFrom", typeof(float)));
            dt.Columns.Add(new DataColumn("TimeTo", typeof(float)));
            dt.Columns.Add(new DataColumn("ScheduleTimeFrom", typeof(bool)));
            dt.Columns.Add(new DataColumn("ScheduleTimeTo", typeof(bool)));
            //Added value of PerHoursFrom and PerHoursTo.This is done because we repalced label from dropdown
            //Now we have to show dropdown value also in Grid.So I have added to columns in data table Manish 15-Jan-2014

            dt.Columns.Add(new DataColumn("PreHoursFrom", typeof(string)));
            dt.Columns.Add(new DataColumn("PreHoursTo", typeof(string)));



            int ScheduleBasedOT = 0;
            if (ddlScheduleBasedOT.SelectedValue == "1")
                ScheduleBasedOT = 1;
            else if (ddlScheduleBasedOT.SelectedValue == "0")
                ScheduleBasedOT = 0;
            else if (ddlScheduleBasedOT.SelectedValue == "4")
                ScheduleBasedOT = 4;
            else
                ScheduleBasedOT = 3;

            for (int i = 0; i < reptHrsHeadFooter.Items.Count; i++)
            {
                var txtHrsHeadFromFooter = (TextBox)reptHrsHeadFooter.Items[i].FindControl("txtHrsHeadFromFooter");
                var txtHrsHeadToFooter = (TextBox)reptHrsHeadFooter.Items[i].FindControl("txtHrsHeadToFooter");
                var lblHrsHeadCodeFooter = (Label)reptHrsHeadFooter.Items[i].FindControl("lblHrsHeadCodeFooter");
                //Label lblHrsFromWithSchedule = (Label)reptHrsHeadFooter.Items[i].FindControl("lblHrsFromWithSchedule");
                //Label lblHrsToWithSchedule = (Label)reptHrsHeadFooter.Items[i].FindControl("lblHrsToWithSchedule");
                var lblHrsFromWithSchedule = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("lblHrsFromWithSchedule");
                var lblHrsToWithSchedule = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("lblHrsToWithSchedule");

                var ddlOverTimeFrom = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddlOverTimeFrom");
                var ddlOverTimeTo = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddlOverTimeTo");

                var ddldutyOTFFrom = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddldutyOTFFrom");
                var ddldutyOTFTo = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddldutyOTFTo");


                DataRow dr = dt.NewRow();
                dr["HoursHeadCode"] = lblHrsHeadCodeFooter.Text;


                if (ScheduleBasedOT == 3)
                {
                    dr["TimeFrom"] = ddlOverTimeFrom.SelectedValue;
                    dr["TimeTo"] = ddlOverTimeTo.SelectedValue;
                    dr["PreHoursFrom"] = ddlOverTimeFrom.SelectedItem.Text;
                    dr["PreHoursTo"] = ddlOverTimeTo.SelectedItem.Text;
                    dr["ScheduleTimeFrom"] = lblHrsFromWithSchedule.Visible;
                    dr["ScheduleTimeTo"] = lblHrsToWithSchedule.Visible;
                }
                else
                {
                    dr["TimeFrom"] = txtHrsHeadFromFooter.Text;
                    dr["TimeTo"] = txtHrsHeadToFooter.Text;
                    //if we select schedulebasedOT is Schedule Type then we are  inserting value of dropdown
                    //lblHrsFromWithSchedule and lblHrsToWithSchedule Into table in PreHoursFrom and PreHoursTo column when 
                    //If schedulebasedOT is Attendance then we inserting NULL value in table.Manish 16-Jan-2014
                    if (ScheduleBasedOT == 1)
                    {
                        dr["PreHoursFrom"] = lblHrsFromWithSchedule.SelectedItem.Text;
                        dr["PreHoursTo"] = lblHrsToWithSchedule.SelectedItem.Text;
                        dr["ScheduleTimeFrom"] = Convert.ToBoolean(Convert.ToInt32(lblHrsFromWithSchedule.SelectedItem.Value.ToString()));
                        dr["ScheduleTimeTo"] = Convert.ToBoolean(Convert.ToInt32(lblHrsToWithSchedule.SelectedItem.Value.ToString()));
                    }
                    //If schedulebasedOT is Postwise then we inserting PreHoursFrom and PreHoursTo value in table PreHoursFrom and PreHoursTo column  .
                    else if (ScheduleBasedOT == 4)
                    {
                        dr["PreHoursFrom"] = ddldutyOTFFrom.SelectedItem.Text;
                        dr["PreHoursTo"] = ddldutyOTFTo.SelectedItem.Text;
                        dr["ScheduleTimeFrom"] = Convert.ToBoolean(Convert.ToInt32(ddldutyOTFFrom.SelectedItem.Value.ToString()));
                        dr["ScheduleTimeTo"] = Convert.ToBoolean(Convert.ToInt32(ddldutyOTFTo.SelectedItem.Value.ToString()));
                    }
                    else
                    {
                        dr["PreHoursFrom"] = "";
                        dr["PreHoursTo"] = "";
                        dr["ScheduleTimeFrom"] = lblHrsFromWithSchedule.Visible;
                        dr["ScheduleTimeTo"] = lblHrsToWithSchedule.Visible;
                    }

                }





                dt.Rows.Add(dr);

                if (ScheduleBasedOT == 3)
                {
                    if (ddlOverTimeFrom.SelectedValue == ddlOverTimeTo.SelectedValue)
                    {
                        dt.Rows.Remove(dr);
                    }
                }

                if (txtHrsHeadToFooter.Text == "" || txtHrsHeadFromFooter.Text == "")
                {
                    intErrorFlag = 1;
                }
                else if (float.Parse(txtHrsHeadToFooter.Text) - float.Parse(txtHrsHeadFromFooter.Text) < 0)
                {
                    i = reptHrsHeadFooter.Items.Count;
                    intErrorFlag = 1;
                }
                else
                {
                    intTmpTotalHrs = intTmpTotalHrs + float.Parse(txtHrsHeadToFooter.Text) - float.Parse(txtHrsHeadFromFooter.Text);
                }
            }

            var txtHrsHeadFromFooter1 = (TextBox)reptHrsHeadFooter.Items[0].FindControl("txtHrsHeadFromFooter");
            var txtHrsHeadToFooter1 = (TextBox)reptHrsHeadFooter.Items[reptHrsHeadFooter.Items.Count - 1].FindControl("txtHrsHeadToFooter");


            intTotalHrs = int.Parse(txtHrsHeadToFooter1.Text) - int.Parse(txtHrsHeadFromFooter1.Text);

            if (intTotalHrs != intTmpTotalHrs || intErrorFlag == 1)
            {
                lblErrorMsgHrsDistribution.Text = Resources.Resource.DistributionContinuity;
            }

            BL.BusinessRule objRule = new BL.BusinessRule();
            var ds = new DataSet();


            DataTable DutyTypeDataTable = new DataTable();
            DutyTypeDataTable.Columns.Add(new DataColumn("DutyTypeCode", typeof(string)));
            CheckBoxList chkDutyType = (CheckBoxList)gvHoursDistribution.FooterRow.FindControl("chkDutyType");
            //We have to add these two dropdown value in data base Manish 15-jan-2014


            for (int i = 0; i < chkDutyType.Items.Count; i++)
            {
                if (chkDutyType.Items[i].Selected)
                {
                    DataRow dr = DutyTypeDataTable.NewRow();
                    dr["DutyTypeCode"] = chkDutyType.Items[i].Value.ToString();
                    DutyTypeDataTable.Rows.Add(dr);

                }
            }



            ds = objRule.HoursHeadDistributionRuleInsert(HdnBrCode.Value, strWeekdays, ddlShift.SelectedValue.ToString(), ddlDistributionRule.SelectedValue, dt, BaseUserID, DutyTypeDataTable, ScheduleBasedOT, chkZeroScheduleHrs.Checked, ddlScheduleBasedOTPeriod.SelectedValue, ddlLeaveType.SelectedValue);
            FillgvHoursDistribution();

        }
        if (e.CommandName == "Reset")
        {

        }

    }
    protected void gvHoursDistribution_DataBound(object sender, EventArgs e)
    {

        BL.BusinessRule objRule = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objRule.HoursHeadDistributionRuleGet("", ddlShift.SelectedValue.ToString(), ddlDistributionRule.SelectedValue.ToString(), HdnBrCode.Value.ToString(), ddlScheduleBasedOTPeriod.SelectedValue);


        for (int i = 0; i < gvHoursDistribution.Rows.Count; i++)
        {
            Repeater reptHrsHead = (Repeater)gvHoursDistribution.Rows[i].FindControl("reptHrsHead");
            Label lblDays = (Label)gvHoursDistribution.Rows[i].FindControl("lblDays");
            HiddenField HdnRowGuid = (HiddenField)gvHoursDistribution.Rows[i].FindControl("HdnRowGuid");

            DataView dv = new DataView();
            dv = ds.Tables[2].DefaultView;
            dv.RowFilter = "WeekDay = '" + lblDays.Text + "' And [Guid] ='" + HdnRowGuid.Value.ToString() + "'";

            reptHrsHead.DataSource = dv;
            reptHrsHead.DataBind();

            if (ds.Tables[2].Rows.Count > 0)
            {
                if (ds.Tables[2].Rows[0]["OverTimeBasedOn"].ToString() == "3")
                {
                    for (int j = 0; j < reptHrsHead.Items.Count; j++)
                    {
                        Label lblHrsHeadFrom = (Label)reptHrsHead.Items[j].FindControl("lblHrsHeadFrom");
                        Label lblHrsHeadTo = (Label)reptHrsHead.Items[j].FindControl("lblHrsHeadTo");
                        if (lblHrsHeadFrom.Text == @"1")
                            lblHrsHeadFrom.Text = @"Duty Start";
                        if (lblHrsHeadFrom.Text == @"2")
                            lblHrsHeadFrom.Text = @"Contract Start";
                        if (lblHrsHeadFrom.Text == @"3")
                            lblHrsHeadFrom.Text = @"Duty End";
                        if (lblHrsHeadFrom.Text == @"4")
                            lblHrsHeadFrom.Text = @"Contract End";

                        if (lblHrsHeadTo.Text == @"1")
                            lblHrsHeadTo.Text = @"Duty Start";
                        if (lblHrsHeadTo.Text == @"2")
                            lblHrsHeadTo.Text = @"Contract Start";
                        if (lblHrsHeadTo.Text == @"3")
                            lblHrsHeadTo.Text = @"Duty End";
                        if (lblHrsHeadTo.Text == @"4")
                            lblHrsHeadTo.Text = @"Contract End";
                    }
                }
            }
        }

        CheckBoxList chkDutyType = (CheckBoxList)gvHoursDistribution.FooterRow.FindControl("chkDutyType");

        BL.MastersManagement objMst = new BL.MastersManagement();
        ds = objMst.DutyTypeGetAll(BaseCompanyCode);
        chkDutyType.DataSource = ds.Tables[0];
        chkDutyType.DataTextField = "LongDutyTypeDesc";
        chkDutyType.DataValueField = "DutyTypeCode";
        chkDutyType.DataBind();

        for (int i = 0; i < chkDutyType.Items.Count; i++)
        {
            chkDutyType.Items[i].Selected = true;
        }

    }
    protected void gvHoursDistribution_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.BusinessRule objRule = new BL.BusinessRule();

        Label lblDays = (Label)gvHoursDistribution.Rows[e.RowIndex].FindControl("lblDays");
        HiddenField HdnRowGuid = (HiddenField)gvHoursDistribution.Rows[e.RowIndex].FindControl("HdnRowGuid");


        var ds = new DataSet();
        ds = objRule.HoursHeadDistributionRuleDelete(HdnBrCode.Value.ToString(), lblDays.Text, ddlShift.SelectedValue.ToString(), ddlDistributionRule.SelectedValue.ToString(), HdnRowGuid.Value);
        FillgvHoursDistribution();

    }
    protected void gvNWHoursDistribution_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.BusinessRule objRule = new BL.BusinessRule();

        HiddenField RowGUID = (HiddenField)gvNWHoursDistribution.Rows[e.RowIndex].FindControl("RowGUID");

        var ds = new DataSet();
        ds = objRule.NotWorkingHoursHeadDistributionRuleDelete(HdnBrCode.Value.ToString(), ddlDistributionRule.SelectedValue.ToString(), RowGUID.Value);
        FillgvNWHoursDistribution();

    }
    protected void gvNWHoursDistribution_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "AddNew")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("HoursHeadCode", typeof(string)));
            dt.Columns.Add(new DataColumn("NWHours", typeof(int)));
            Repeater reptNWHrsHeadFooter = (Repeater)gvNWHoursDistribution.FooterRow.FindControl("reptNWHrsHeadFooter");

            for (int i = 0; i < reptNWHrsHeadFooter.Items.Count; i++)
            {
                var txtNWHrsHeadFooter = (TextBox)reptNWHrsHeadFooter.Items[i].FindControl("txtNWHrsHeadFooter");
                var lblHrsHeadCodeFooter = (Label)reptNWHrsHeadFooter.Items[i].FindControl("lblHrsHeadCodeFooter");

                DataRow dr = dt.NewRow();
                dr["HoursHeadCode"] = lblHrsHeadCodeFooter.Text;
                dr["NWHours"] = txtNWHrsHeadFooter.Text;

                dt.Rows.Add(dr);

            }

            BL.BusinessRule objRule = new BL.BusinessRule();
            var ds = new DataSet();

            ds = objRule.NotWorkingHoursHeadDistributionRuleInsert(HdnBrCode.Value, ddlDistributionRule.SelectedValue, dt, BaseUserID);
            FillgvNWHoursDistribution();

        }
    }
    protected void gvNWHoursDistribution_DataBound(object sender, EventArgs e)
    {

        BL.BusinessRule objRule = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objRule.NotWorkingHoursHeadDistributionRuleGet(ddlDistributionRule.SelectedValue.ToString(), HdnBrCode.Value.ToString());


        for (int i = 0; i < gvNWHoursDistribution.Rows.Count; i++)
        {
            Repeater reptNWHrsHead = (Repeater)gvNWHoursDistribution.Rows[i].FindControl("reptNWHrsHead");
            HiddenField RowGUId = (HiddenField)gvNWHoursDistribution.Rows[i].FindControl("RowGUId");

            LinkButton lnkCondition = (LinkButton)gvNWHoursDistribution.Rows[i].FindControl("lnkCondition");
            lnkCondition.Attributes["onClick"] = "javascript:CallPopup('" + RowGUId.Value + "','" + ddlDistributionRule.SelectedValue + "');";

            DataView dv = new DataView();
            dv = ds.Tables[2].DefaultView;
            dv.RowFilter = " [Guid] ='" + RowGUId.Value.ToString() + "'";

            reptNWHrsHead.DataSource = dv;
            reptNWHrsHead.DataBind();

        }

    }
    /// <summary>
    ///  Fill grid on Page Index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNWHoursDistribution_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNWHoursDistribution.PageIndex = e.NewPageIndex;
        FillgvNWHoursDistribution();
    }


    protected void FillShiftForDutyHours(string hdnBrCode)
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.GetShiftForDutyHours(hdnBrCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlShift.DataSource = ds.Tables[0];
            ddlShift.DataValueField = "ShiftName";
            ddlShift.DataTextField = "ShiftName";
            ddlShift.DataBind();

        }


    }
    protected void FillLeaveType()
    {
        BL.Leave objLeave = new BL.Leave();
        var ds = new DataSet();
        ds = objLeave.LeaveAndSubLeaveTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlLeaveType.DataSource = ds;
            ddlLeaveType.DataTextField = "Leave_Desc";
            ddlLeaveType.DataValueField = "Leave_Code";
            ddlLeaveType.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlLeaveType.Items.Insert(0, li);

        }
    }
    #endregion
    #region weekly hours adjustment Tab
    protected void FillWeeklyHoursHead()
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        ds = objBR.BusinessHoursHeadGet("All");

        lbWeeklyHoursHead.DataSource = ds.Tables[0];
        lbWeeklyHoursHead.DataTextField = "HoursHeadCode";
        lbWeeklyHoursHead.DataValueField = "HoursHeadCode";
        lbWeeklyHoursHead.DataBind();

        lbWeeklydaysHead.DataSource = ds.Tables[0];
        lbWeeklydaysHead.DataTextField = "HoursHeadCode";
        lbWeeklydaysHead.DataValueField = "HoursHeadCode";
        lbWeeklydaysHead.DataBind();

        ds = null;
        ds = objBR.FormulaNameGet(HdnBrCode.Value);
        lbFormula.DataSource = ds.Tables[0];
        lbFormula.DataTextField = "FormulaName";
        lbFormula.DataValueField = "FormulaExpression";
        lbFormula.DataBind();



        //


    }

    protected void btnDeleteFormula_Click(object sender, EventArgs e)
    {
        if (HdnBrCode.Value != "")
        {
            BL.BusinessRule objBR = new BL.BusinessRule();
            var ds = new DataSet();
            ds = objBR.FormulaExpressionDelete(HdnBrCode.Value, lbFormula.Items[lbFormula.SelectedIndex].Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblErrorMsgFormulaBuilder.Text = ds.Tables[0].Rows[0][1].ToString();
                return;
            }

            ds = null;
            ds = objBR.FormulaNameGet(HdnBrCode.Value);
            lbFormula.DataSource = ds.Tables[0];
            lbFormula.DataTextField = "FormulaName";
            lbFormula.DataValueField = "FormulaExpression";
            lbFormula.DataBind();
        }

    }


    protected void btnSaveFormula_Click(object sender, EventArgs e)
    {

        if (HdnBrCode.Value != "")
        {

            BL.BusinessRule objBR = new BL.BusinessRule();
            var ds = new DataSet();

            string strIsPartOfPaysum;
            strIsPartOfPaysum = "0";
            if (chkIsPartOfPaysum.Checked)
            {
                strIsPartOfPaysum = "1";
            }

            ds = objBR.FormulaExpressionInsert(HdnBrCode.Value, txtFormulaName.Text, hid_FormulaExpType.Value, hid_FormulaExp.Value, strIsPartOfPaysum, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                lblErrorMsgFormulaBuilder.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                ds = null;
                ds = objBR.FormulaNameGet(ddlBR.SelectedValue.ToString());
                lbFormula.DataSource = ds.Tables[0];
                lbFormula.DataTextField = "FormulaName";
                lbFormula.DataValueField = "FormulaExpression";
                lbFormula.DataBind();
            }


        }
        else
        {
            lblErrorMsgFormulaBuilder.Text = Resources.Resource.SelectBusinessRule5;
        }

    }


    #endregion
    #region paysum format
    #region Paysum Heads
    //New PaySum Formt 
    void FillPaySumCode()
    {
        var objBr = new BL.BusinessRule();
        //var dt = new DataTable();
        var ds = objBr.BusinessRuleGet("", int.Parse(BaseLocationAutoID));
        //  Fill Paysum Code.Using same BL,DL and SP that we are used to FillExistingRules.
        //  Added new select statement in same SP
        ddlPaySumCodeFormat.DataSource = ds.Tables[1];
        ddlPaySumCodeFormat.DataValueField = "PaysumCode";
        ddlPaySumCodeFormat.DataTextField = "PaysumCodeDesc";
        ddlPaySumCodeFormat.DataBind();

        FillPaysumHeads(ddlPaySumCodeFormat.SelectedValue);
        FillPaysumHeadList(ddlPaySumCodeFormat.SelectedValue);
        FillPaysumHeadMappedList(ddlPaySumCodeFormat.SelectedValue);
        PaysumHeadMappedListHrsTotalGet(ddlPaySumCodeFormat.SelectedValue);

    }

    protected void ddlPaySumCodeFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPaysumElements();
        FillPaysumHeads(ddlPaySumCodeFormat.SelectedValue);
        FillPaysumHeadList(ddlPaySumCodeFormat.SelectedValue);
        FillPaysumHeadMappedList(ddlPaySumCodeFormat.SelectedValue);
        PaysumHeadMappedListHrsTotalGet(ddlPaySumCodeFormat.SelectedValue);

        // FillPaysumHeadMappedList();
    }
    //   End New paysum Format    

    private void FillPaysumHeads(string paySumCode)
    {

        var objBr = new BL.BusinessRule();
        var ds = objBr.PaysumHeadsGet(BaseCompanyCode, paySumCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvPaysumHead.DataSource = ds.Tables[0];
            gvPaysumHead.DataBind();
        }
        else
        {
            if (ds != null)
            {
                var dt = ds.Tables[0];
                dt.Rows.Add(dt.NewRow());

                gvPaysumHead.DataSource = dt;
            }
            gvPaysumHead.DataBind();
            gvPaysumHead.Rows[0].Visible = false;

        }


        if (ds != null) ddlPaysumHead.DataSource = ds.Tables[0];
        ddlPaysumHead.DataTextField = "paysumHead";
        ddlPaysumHead.DataValueField = "paysumHead";
        ddlPaysumHead.DataBind();



    }
    private void FillPaysumHeadList(string paySumCode)
    {
        var objBr = new BL.BusinessRule();
        var ds = objBr.PaysumUnmappedHoursHeadGet(BaseCompanyCode, paySumCode);


        lbHoursHead.DataSource = ds.Tables[0];
        lbHoursHead.DataTextField = "HoursHeadDesc";
        lbHoursHead.DataValueField = "HoursHeadCode";
        lbHoursHead.DataBind();

    }
    private void FillPaysumHeadMappedList(string paySumCode)
    {
        var objBr = new BL.BusinessRule();
        var ds = objBr.PaysumMappedHoursHeadGet(BaseCompanyCode, ddlPaysumHead.SelectedValue, paySumCode);


        lbMappedPaysumHead.DataSource = ds.Tables[0];
        lbMappedPaysumHead.DataTextField = "HoursHeadDesc";
        lbMappedPaysumHead.DataValueField = "HoursHeadCode";
        lbMappedPaysumHead.DataBind();

    }
    private void PaysumHeadMappedListHrsTotalGet(string paySumcode)
    {
        var objBr = new BL.BusinessRule();
        var ds = objBr.PaysumHeadMappedListHrsTotalGet(BaseCompanyCode, paySumcode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtTotalHrs.Text = ds.Tables[0].Rows[0]["paysumHead"].ToString();
            FillPaysumHeadMappedListHrsTotal(ds.Tables[0].Rows[0]["paysumHead"].ToString());
        }
    }
    private void FillPaysumHeadMappedListHrsTotal(string paysumHead)
    {
        var objBr = new BL.BusinessRule();
        var ds = objBr.PaysumMappedHoursHeadGet(BaseCompanyCode, paysumHead, ddlPaySumCodeFormat.SelectedValue);

        lbTotalHrs.DataSource = ds.Tables[0];
        lbTotalHrs.DataTextField = "HoursHeadDesc";
        lbTotalHrs.DataValueField = "HoursHeadCode";
        lbTotalHrs.DataBind();

    }

    protected void ddlPaysumHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPaysumHeadMappedList(ddlPaySumCodeFormat.SelectedValue);
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        var objBr = new BL.BusinessRule();

        var strAdd = string.Empty;
        var strRemove = string.Empty;

        for (var i = 0; i < lbMappedPaysumHead.Items.Count; i++)
        {
            strAdd = strAdd + "," + lbMappedPaysumHead.Items[i].Value;
        }

        var ds = objBr.PaysumHeadMappingAdd(BaseCompanyCode, ddlPaysumHead.SelectedValue, strAdd, BaseUserID, false, ddlPaySumCodeFormat.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }

        for (var i = 0; i < lbHoursHead.Items.Count; i++)
        {
            strRemove = strRemove + "," + lbHoursHead.Items[i].Value;
        }

        ds = objBr.PaysumHeadMappingRemove(BaseCompanyCode, ddlPaysumHead.SelectedValue, strRemove, BaseUserID, ddlPaySumCodeFormat.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }

        //***********************************************************************************
        FillPaysumHeadList(ddlPaySumCodeFormat.SelectedValue);
        FillPaysumHeadMappedList(ddlPaySumCodeFormat.SelectedValue);
    }
    /// <summary>
    /// btnApplyTotalHrs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnApplyTotalHrs_Click(object sender, EventArgs e)
    {
        if (lbTotalHrs.Items.Count > 0 && !string.IsNullOrEmpty(txtTotalHrs.Text))
        {
            var objBr = new BL.BusinessRule();

            var strAdd = string.Empty;

            for (var i = 0; i < lbTotalHrs.Items.Count; i++)
            {
                strAdd = strAdd + "," + lbTotalHrs.Items[i].Value;
            }

            var ds = objBr.PaysumHeadMappingAdd(BaseCompanyCode, txtTotalHrs.Text, strAdd, BaseUserID, true, ddlPaySumCodeFormat.SelectedValue);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
    }
    /// <summary>
    /// gvPaysumHead_RowCommand
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPaysumHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var txtPaysumHead = (TextBox)gvPaysumHead.FooterRow.FindControl("txtgvPaysumHead");

        var objBr = new BL.BusinessRule();


        if (e.CommandName == "AddNew")
        {
            objBr.PaysumHeadsInsert(BaseCompanyCode, txtPaysumHead.Text, BaseUserID, ddlPaySumCodeFormat.SelectedValue.ToString());
            FillPaysumHeads(ddlPaySumCodeFormat.SelectedValue);
        }
        if (e.CommandName == "Reset")
        {
            txtPaysumHead.Text = "";
        }

    }
    /// <summary>
    /// gvPaysumHead_RowUpdating
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPaysumHead_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var txtgvPaysumHead = (TextBox)gvPaysumHead.Rows[e.RowIndex].FindControl("txtgvPaysumHead");
        var objBr = new BL.BusinessRule();
        var ds = objBr.PaysumHeadsUpdate(BaseCompanyCode, txtgvPaysumHead.Text, BaseUserID, ddlPaySumCodeFormat.SelectedValue);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            lblErrPaysum.Text = ds.Tables[0].Rows[0][1].ToString();
        }

        gvPaysumHead.EditIndex = -1;
        FillPaysumHeads(ddlPaySumCodeFormat.SelectedValue);

    }
    /// <summary>
    /// gvPaysumHead_RowEditing(
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPaysumHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPaysumHead.EditIndex = e.NewEditIndex;

    }
    /// <summary>
    /// gvPaysumHead_RowCancelingEdit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPaysumHead_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPaysumHead.EditIndex = -1;
        FillPaysumHeads(ddlPaySumCodeFormat.SelectedValue);
    }
    /// <summary>
    /// gvPaysumHead_RowDeleting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPaysumHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var lblgvPaysumHead = (Label)gvPaysumHead.Rows[e.RowIndex].FindControl("lblgvPaysumHead");
        var objBR = new BL.BusinessRule();
        objBR.PaysumHeadsDelete(BaseCompanyCode, lblgvPaysumHead.Text, ddlPaySumCodeFormat.SelectedValue);
        FillPaysumHeads(ddlPaySumCodeFormat.SelectedValue);

    }
    /// <summary>
    ///  ImgBtnAdd
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        for (var i = 0; i < lbHoursHead.Items.Count; i++)
        {
            if (lbHoursHead.Items[i].Selected)
            {
                var li1 = new ListItem();
                li1.Text = lbHoursHead.Items[i].Text;
                li1.Value = lbHoursHead.Items[i].Value;
                lbMappedPaysumHead.Items.Add(li1);
            }
        }
        for (var i = lbHoursHead.Items.Count - 1; i >= 0; i--)
        {
            if (lbHoursHead.Items[i].Selected)
            {
                lbHoursHead.Items.RemoveAt(i);

            }
        }

    }
    /// <summary>
    /// ImgBtnAdd1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnAdd1_Click(object sender, ImageClickEventArgs e)
    {
        for (var i = 0; i < lbMappedPaysumHead.Items.Count; i++)
        {
            if (lbMappedPaysumHead.Items[i].Selected)
            {
                var item = lbTotalHrs.Items.FindByText(lbMappedPaysumHead.Items[i].Text);
                if (item == null)
                {
                    lbTotalHrs.Items.Add(lbMappedPaysumHead.SelectedItem);
                }
            }
        }
    }
    /// <summary>
    /// ImgBtnRemove1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnRemove1_Click(object sender, ImageClickEventArgs e)
    {
        var objBr = new BL.BusinessRule();

        for (var i = lbTotalHrs.Items.Count - 1; i >= 0; i--)
        {
            if (lbTotalHrs.Items[i].Selected)
            {
                if (!string.IsNullOrEmpty(txtTotalHrs.Text))
                {
                    objBr.PaysumHeadMappedListHrsTotalDelete(BaseCompanyCode, txtTotalHrs.Text, lbTotalHrs.SelectedValue);
                }

                var ds = objBr.PaysumHeadMappedListHrsTotalGet(BaseCompanyCode, ddlPaySumCodeFormat.SelectedValue);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtTotalHrs.Text = ds.Tables[0].Rows[0]["paysumHead"].ToString();
                }
                else
                {
                    objBr.PaysumHeadDelete(BaseCompanyCode, txtTotalHrs.Text);
                    txtTotalHrs.Text = string.Empty;
                }

                lbTotalHrs.Items.Remove(lbTotalHrs.SelectedItem);
                lbTotalHrs.Focus();
            }
        }
    }
    /// <summary>
    /// Delete on Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnRemove_Click(object sender, ImageClickEventArgs e)
    {
        for (var i = 0; i < lbMappedPaysumHead.Items.Count; i++)
        {
            if (lbMappedPaysumHead.Items[i].Selected)
            {
                var li1 = new ListItem();
                li1.Text = lbMappedPaysumHead.Items[i].Text;
                li1.Value = lbMappedPaysumHead.Items[i].Value;
                lbHoursHead.Items.Add(li1);
            }
        }
        for (int i = lbMappedPaysumHead.Items.Count - 1; i >= 0; i--)
        {
            if (lbMappedPaysumHead.Items[i].Selected)
            {
                lbMappedPaysumHead.Items.RemoveAt(i);
            }
        }
    }
    #endregion
    #region Paysum Elements
    /// <summary>
    /// ChkPaysumElements
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkPaysumElements_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (var i = 0; i < chkPaysumElements.Items.Count; i++)
        {
            if (chkPaysumElements.Items[i].Selected)
            {
                var elementName = chkPaysumElements.Items[i].Value;
                addPaysumElement(elementName, ddlPaySumCodeFormat.SelectedValue);
            }
        }

        for (var i = 0; i < chkPaysumElements.Items.Count; i++)
        {
            if (!chkPaysumElements.Items[i].Selected)
            {
                var elementName = chkPaysumElements.Items[i].Value;
                deletePaysumElement(elementName, ddlPaySumCodeFormat.SelectedValue);
            }
        }




    }
    /// <summary>
    ///  Add new 
    /// </summary>
    /// <param name="elementName"></param>
    /// <param name="paySumCode"></param>
    protected void addPaysumElement(string elementName, string paySumCode)
    {
        elementName = elementName.Replace(" ", "");
        var ds = new DataSet();
        var objBr = new BL.BusinessRule();
        //// business rule code value is passed because current structure does not support seprate paysum for each business rule. 
        ds = objBr.PaysumElementsAdd(BaseCompanyCode, "", elementName, BaseUserID, paySumCode);

    }

    /// <summary>
    /// Delete PaysumElement
    /// </summary>
    /// <param name="elementName"></param>
    /// <param name="paySumCode"></param>
    protected void deletePaysumElement(string elementName, string paySumCode)
    {
        elementName = elementName.Replace(" ", "");
        var ds = new DataSet();
        var objBr = new BL.BusinessRule();

        ds = objBr.PaysumElementsDelete(BaseCompanyCode, "", elementName, paySumCode);

    }

    #endregion
    #endregion
    #region paysum Readiness Tab (Step10)
    #region Function To Fill GridView Paysum Readyness
    /// <summary>
    /// Function To Fill GridView Paysum Readyness
    /// </summary>
    private void FillgvPaysumReadiness()
    {
        if (ddlBR.SelectedIndex > 0)
        {
            BL.BusinessRule objblBusinessRule = new BL.BusinessRule();

            var ds = new DataSet();
            DataTable dtgvPsrProcess = new DataTable();
            ds = objblBusinessRule.PaysumReadinessProcessGet(ddlBR.SelectedValue);
            dtgvPsrProcess = ds.Tables[0];
            if (ds != null && ds.Tables.Count > 0 && dtgvPsrProcess.Rows.Count > 0)
            {
                gvPsrProcess.DataSource = dtgvPsrProcess;
                gvPsrProcess.DataBind();
            }
        }
        else
        {
            //Clear Grid When Business Rule Got DeSelected
            gvPsrProcess.DataSource = null;
            gvPsrProcess.DataBind();
        }
    }
    #endregion
    #region PaysumReadiness Grid
    /// <summary>
    /// Row Editing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPsrProcess_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPsrProcess.EditIndex = e.NewEditIndex;
        FillgvPaysumReadiness();
        HiddenField hfPId2 = (HiddenField)gvPsrProcess.Rows[e.NewEditIndex].FindControl("hfPId2");

        if (hfPId2 != null)
        {
            FillgvPaysumReadinessParameters(hfPId2.Value);
            hfPId.Value = hfPId2.Value;
        }

        HiddenField hfImplementationStatus = (HiddenField)gvPsrProcess.Rows[e.NewEditIndex].FindControl("hfImplementationStatus");

        var ddlImplementationStatus = (DropDownList)gvPsrProcess.Rows[e.NewEditIndex].FindControl("ddlImplementationStatus");

        //if (hfImplementationStatus != null && ddlImplementationStatus !=null)
        {
            if (hfImplementationStatus.Value == "1")
                ddlImplementationStatus.SelectedValue = @"Mandatory";
            else
                ddlImplementationStatus.SelectedValue = @"Informative";
        }

    }
    /// <summary>
    /// Row Canel Edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPsrProcess_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPsrProcess.EditIndex = -1;
        FillgvPaysumReadiness();
        gvProcessParameters.DataSource = null;
        gvProcessParameters.DataBind();
    }
    /// <summary>
    ///  PaySum row updating
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPsrProcess_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (HdnBrCode.Value != "")
        {
            BL.BusinessRule objBR = new BL.BusinessRule();
            var ds = new DataSet();

            CheckBox cbIsSubscribed = (CheckBox)gvPsrProcess.Rows[e.RowIndex].FindControl("cbIsSubscribed");
            var ddlImplementationStatus = (DropDownList)gvPsrProcess.Rows[e.RowIndex].FindControl("ddlImplementationStatus");
            int ImplementationStatus = 1;
            if (ddlImplementationStatus.SelectedValue == @"Mandatory")
                ImplementationStatus = 1;
            else
                ImplementationStatus = 2;

            ds = objBR.PaysumReadinessInsert(HdnBrCode.Value, hfPId.Value, cbIsSubscribed.Checked, ImplementationStatus, BaseUserID);
            gvPsrProcess.EditIndex = -1;
            FillgvPaysumReadiness();
            gvProcessParameters.DataSource = null;
            gvProcessParameters.DataBind();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
        else
        {
            {
                lblErrorMsg.Text = Resources.Resource.SelectBusinessRule;
                return;
            }
        }
    }
    /// <summary>
    /// Paysum Process Readyness
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPsrProcess_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvPsrProcess.PageIndex * gvPsrProcess.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (!IsModifyAccess)
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

            Label lblImplementationStatus = (Label)e.Row.FindControl("lblImplementationStatus");

            // Show Implementation Status
            if (DataBinder.Eval(e.Row.DataItem, "ImplementationStatus") != DBNull.Value)
            {
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ImplementationStatus")) == 1)
                {
                    if (lblImplementationStatus != null)
                    {
                        lblImplementationStatus.Text = @"Mandatory";
                    }
                }
                else if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ImplementationStatus")) == 2)
                {
                    if (lblImplementationStatus != null)
                    {
                        lblImplementationStatus.Text = @"Informative";
                    }
                }
            }
            else
            {
                if (lblImplementationStatus != null)
                {
                    lblImplementationStatus.Text = "";
                }
            }

        }
    }
    #endregion
    #region Fill Paysum Readiness Parameter Grid
    /// <summary>
    /// Fill PaySumReadiness
    /// </summary>
    /// <param name="pid"></param>
    private void FillgvPaysumReadinessParameters(string pid)
    {
        //if (HdnBrCode.Value != "")
        {
            BL.BusinessRule objblBusinessRule = new BL.BusinessRule();

            var ds = new DataSet();
            DataTable dtgvPsrProcessParameters = new DataTable();
            ds = objblBusinessRule.PaysumReadinessProcessParameterGet(pid);
            dtgvPsrProcessParameters = ds.Tables[0];
            if (ds != null && ds.Tables.Count > 0 && dtgvPsrProcessParameters.Rows.Count > 0)
            {
                gvProcessParameters.DataSource = dtgvPsrProcessParameters;
                gvProcessParameters.DataBind();
            }
            //else
            //{
            //    lblErrorMsgPayperiod.Text = "Please select Business rule from step 5!";
            //    return;
            //}
        }
    }
    #endregion
    /// <summary>
    /// Drop down selected index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlScheduleBasedOT_SelectedIndexChanged(Object sender, EventArgs e)
    {
        if (HdnBrCode.Value != "")
        {
            if (ddlScheduleBasedOT.SelectedValue == @"3")
            {
                lblErrorMsgHrsDistribution.Text = "";
                Repeater reptHrsHeadFooter = (Repeater)gvHoursDistribution.FooterRow.FindControl("reptHrsHeadFooter");

                for (int i = 0; i < reptHrsHeadFooter.Items.Count; i++)
                {
                    var ddlOverTimeFrom = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddlOverTimeFrom");
                    var ddlOverTimeTo = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddlOverTimeTo");
                    var txtHrsHeadFromFooter = (TextBox)reptHrsHeadFooter.Items[i].FindControl("txtHrsHeadFromFooter");
                    var txtHrsHeadToFooter = (TextBox)reptHrsHeadFooter.Items[i].FindControl("txtHrsHeadToFooter");
                    //Hide dropdown ScheduleHrs+ Manish 15-jan-2014
                    var lblHrsFromWithSchedule = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("lblHrsFromWithSchedule");
                    var lblHrsToWithSchedule = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("lblHrsToWithSchedule");
                    //End Hide dropdown ScheduleHrs+ Manish 15-jan-2014
                    var ddldutyOTFFrom = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddldutyOTFFrom");
                    var ddldutyOTFTo = (DropDownList)reptHrsHeadFooter.Items[i].FindControl("ddldutyOTFTo");
                    //*********************************
                    ddldutyOTFFrom.Visible = false;
                    ddldutyOTFTo.Visible = false;
                    //***********************************
                    lblHrsFromWithSchedule.Visible = false;
                    lblHrsToWithSchedule.Visible = false;
                    txtHrsHeadFromFooter.Visible = false;
                    txtHrsHeadToFooter.Visible = false;

                    ddlOverTimeFrom.Visible = true;
                    ddlOverTimeTo.Visible = true;
                }
            }
            else
            {
                lblErrorMsgHrsDistribution.Text = "";
                FillgvHoursDistribution();
                FillgvNWHoursDistribution();
            }
        }
        else
        {
            lblErrorMsgHrsDistribution.Text = Resources.Resource.SelectBusinessRule;
            return;
        }
    }
    /// <summary>
    /// Row data bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProcessParameters_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNoPsr = (Label)objGridViewRow.FindControl("lblSerialNoPsr");
        if (lblSerialNoPsr != null)
        {
            int serialNo = gvProcessParameters.PageIndex * gvProcessParameters.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNoPsr.Text = Convert.ToString((serialNo + 1));
        }
    }
    /// <summary>
    /// Row editing 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProcessParameters_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvProcessParameters.EditIndex = e.NewEditIndex;
        FillgvPaysumReadinessParameters(hfPId.Value);

        var hfDataType = (HiddenField)gvProcessParameters.Rows[e.NewEditIndex].FindControl("hfDataType");
        var txtgvPaysumReadinessInputParameterValue = (TextBox)gvProcessParameters.Rows[e.NewEditIndex].FindControl("txtgvPaysumReadinessInputParameterValue");

        //Un Register the Event First
        txtgvPaysumReadinessInputParameterValue.Attributes.Remove("onKeyPress");

        if (hfDataType != null && hfDataType.Value == "Numeric")
        {
            txtgvPaysumReadinessInputParameterValue.Attributes.Add("onKeyPress", "javascript:return checkNum(event)");
        }
    }
    /// <summary>
    /// Row cancel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProcessParameters_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvProcessParameters.EditIndex = -1;
        FillgvPaysumReadinessParameters(hfPId.Value);
    }
    /// <summary>
    /// For update the records
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProcessParameters_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (HdnBrCode.Value != "")
        {
            BL.BusinessRule objBR = new BL.BusinessRule();
            var ds = new DataSet();

            var lblgvPaysumReadinessInputParameter = (Label)gvProcessParameters.Rows[e.RowIndex].FindControl("lblgvPaysumReadinessInputParameter");
            var txtgvPaysumReadinessInputParameterValue = (TextBox)gvProcessParameters.Rows[e.RowIndex].FindControl("txtgvPaysumReadinessInputParameterValue");

            ds = objBR.PaysumReadinessParameterValueUpdate(hfPId.Value, lblgvPaysumReadinessInputParameter.Text, txtgvPaysumReadinessInputParameterValue.Text, BaseUserID);

            gvProcessParameters.EditIndex = -1;
            FillgvPaysumReadinessParameters(hfPId.Value);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
        else
        {
            {
                lblErrorMsg.Text = Resources.Resource.SelectBusinessRule;
                return;
            }
        }
    }
    #endregion
    /// <summary>
    /// For Paging of HoursHeadGroup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHrsHeadGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHrsHeadGroup.PageIndex = e.NewPageIndex;
        FillHoursHeadGroup();
    }
    /// <summary>
    /// Paging For gvHrsHead grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHrsHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHrsHead.PageIndex = e.NewPageIndex;
        FillHoursHead();
    }
    #region New Hours Head Adjusment
    /// <summary>
    /// Fill Hours Distribution Adjustment
    /// </summary>
    protected void FillHoursDistributionAdjusment()
    {

        var objBr = new BL.BusinessRule();
        var ds = objBr.BusinessHoursDistributionAdjusmentGet(HdnBrCode.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            gvHrsheadDisAdj.DataSource = ds.Tables[0];
            gvHrsheadDisAdj.DataBind();
        }
        else
        {
            if (ds != null)
            {
                var dt = ds.Tables[0];
                dt.Rows.Add(dt.NewRow());
                gvHrsheadDisAdj.DataSource = dt;
            }
            gvHrsheadDisAdj.DataBind();
            gvHrsheadDisAdj.Rows[0].Visible = false;

        }
        FillddlHoursElements();
    }

    /// <summary>
    /// Fill All three Footer DropDown and Combo Box
    /// </summary>
    protected void FillddlHoursElements()
    {

        var ddlgvFtrHrsAdjElements = (RadComboBox)gvHrsheadDisAdj.FooterRow.FindControl("ddlgvFtrHrsAdjElements");
        var ddlgvFtrElementReplacedFrom = (DropDownList)gvHrsheadDisAdj.FooterRow.FindControl("ddlgvFtrElementReplacedFrom");
        var ddlgvFtrElementTobeReplaced = (DropDownList)gvHrsheadDisAdj.FooterRow.FindControl("ddlgvFtrElementTobeReplaced");
        var objBr = new BL.BusinessRule();
        var ds = objBr.BusinessHoursHeadGet(@"All");
        ddlgvFtrElementReplacedFrom.DataSource = ds.Tables[0];
        ddlgvFtrElementReplacedFrom.DataTextField = "HoursHeadCode";
        ddlgvFtrElementReplacedFrom.DataValueField = "HoursHeadCode";
        ddlgvFtrElementReplacedFrom.DataBind();

        ddlgvFtrElementTobeReplaced.DataSource = ds.Tables[0];
        ddlgvFtrElementTobeReplaced.DataTextField = "HoursHeadCode";
        ddlgvFtrElementTobeReplaced.DataValueField = "HoursHeadCode";
        ddlgvFtrElementTobeReplaced.DataBind();

        ddlgvFtrHrsAdjElements.DataSource = ds.Tables[0];
        ddlgvFtrHrsAdjElements.DataTextField = "HoursHeadCode";
        ddlgvFtrHrsAdjElements.DataValueField = "HoursHeadCode";
        ddlgvFtrHrsAdjElements.DataBind();


    }
    /// <summary>
    /// Added New Records 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHrsheadDisAdj_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.BusinessRule objBR = new BL.BusinessRule();
        var ds = new DataSet();
        // To Insert a New Row
        var txtgvFtrHrsAdj = (TextBox)gvHrsheadDisAdj.FooterRow.FindControl("txtgvFtrHrsAdj");
        var ddlgvFtrHrsAdjElements = (RadComboBox)gvHrsheadDisAdj.FooterRow.FindControl("ddlgvFtrHrsAdjElements");
        var ddlgvFtrElementTobeReplaced = (DropDownList)gvHrsheadDisAdj.FooterRow.FindControl("ddlgvFtrElementTobeReplaced");
        var ddlgvFtrElementReplacedFrom = (DropDownList)gvHrsheadDisAdj.FooterRow.FindControl("ddlgvFtrElementReplacedFrom");
        var coll = ddlgvFtrHrsAdjElements.CheckedItems;
        // For ddlgvFtrHrsAdjElements  
        string HrsAdjElements = string.Empty;
        if (coll.Count > 0)
        {
            foreach (var item in coll)
            {
                HrsAdjElements = HrsAdjElements + item.Value.ToString() + ",";
            }
        }
        else
        {
            lblErrorMsgDisAdj.Text = Resources.Resource.SelectRunningTotalElement;
            return;
        }

        if (e.CommandName == "Add")
        {

            ds = objBR.BusinessHoursDistributionAdjusmentInsert(HdnBrCode.Value, ddlDisAdjPeriod.SelectedValue, ddlDisAdjMode.SelectedValue, HrsAdjElements, int.Parse(txtgvFtrHrsAdj.Text), ddlgvFtrElementTobeReplaced.SelectedValue, ddlgvFtrElementReplacedFrom.SelectedValue, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsgDisAdj, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
        FillHoursDistributionAdjusment();

    }
    /// <summary>
    /// Record Delete form Distribution Adjustment Table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHrsheadDisAdj_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objBr = new BL.BusinessRule();
        var lblgvElementsDisAdj = (Label)gvHrsheadDisAdj.Rows[e.RowIndex].FindControl("lblgvElementsDisAdj");
        var lblgvElementTobeReplaced = (Label)gvHrsheadDisAdj.Rows[e.RowIndex].FindControl("lblgvElementTobeReplaced");

        var ds = objBr.BusinessHoursDistributionAdjusmentDelete(HdnBrCode.Value, lblgvElementsDisAdj.Text, lblgvElementTobeReplaced.Text);
        FillHoursDistributionAdjusment();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsgDisAdj, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    /// <summary>
    ///  Fill grid on Page Index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHrsheadDisAdj_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHrsheadDisAdj.PageIndex = e.NewPageIndex;
        FillHoursDistributionAdjusment();
    }
    #endregion

}
