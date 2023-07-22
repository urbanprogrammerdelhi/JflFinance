
// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Data;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

/// <summary>
/// Class Masters_EmployeeMaster
/// </summary>
public partial class Masters_EmployeeMaster : BasePage
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    //static DataTable dtOtherInfoDetails = new DataTable();
    /// <summary>
    /// The status
    /// </summary>
    static int Status;
    /// <summary>
    /// The dtflag
    /// </summary>
    static int dtflag;
    #region page load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            System.Web.UI.ScriptManager.GetCurrent(this).RegisterPostBackControl(this.gvOtherDetails);
            lblDefaultCurrency.Text = @" ( " + Resources.Resource.RptIn + @" " + BaseDefaultCurrency + @" ) ";
            dtflag = 1;
            btnSubmit.Attributes.Add("onclick", "javascript:Timerf('" + lblErrorMsg.ClientID + @"');");
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EmployeeMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            lblEmployeeNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
            lblEmployeeNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
            btnSubmit.Text = Resources.Resource.Save;
            btnNext.Visible = false;
            btnContactDetails.Visible = false;
            btnCompensationDetails.Visible = false;
            btnTrainingDetails.Visible = false;
            var objCommon = new BL.Common();
            FillddlReligion();
            FillddlNationality();
            var ds = objCommon.CheckAutoGenerateNumberStatus(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            HFEmployeeAutoGenerateStatus.Value = ds.Tables[0].Rows[0]["AutoGenerateNumberStatus"].ToString();
            if (Request.QueryString["strStatus"] == Resources.Resource.AddNew)
            {
                btnSubmit.Text = Resources.Resource.Save;
                Status = 0;
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (bool.Parse(ds.Tables[0].Rows[0]["AutoGenerateNumberStatus"].ToString()))
                    {
                        lblEmployee.Visible = false;
                        lblEmployeeNumber.Visible = false;
                    }
                    else
                    {
                        lblEmployee.Visible = true;
                        lblEmployeeNumber.Visible = true;
                        btnNext.Visible = false;
                        btnContactDetails.Visible = false;
                        btnCompensationDetails.Visible = false;
                        btnTrainingDetails.Visible = false;
                    }
                }

            }
            FillAreaId();
            if (Request.QueryString["strStatus"] == Resources.Resource.Update)
            {
                Status = 1;
                btnNext.Visible = true;
                btnContactDetails.Visible = true;
                btnCompensationDetails.Visible = true;
                btnTrainingDetails.Visible = true;
                btnClear.Visible = false;
         
                btnSubmit.Text = Resources.Resource.Update;
                lblEmployeeNumber.Text = (Request.QueryString["strEmployeeNumber"]);
                txtEmployeeNumberCon.Text = (Request.QueryString["strEmployeeNumber"]);
                txtEmployeeNumberEmployeePreferances.Text = (Request.QueryString["strEmployeeNumber"]);
                txtEmployeeNumberBarredAssignments.Text = (Request.QueryString["strEmployeeNumber"]);
                txtEmpAdd.Text = (Request.QueryString["strEmployeeNumber"]);
                FillDetailsForUpdate(lblEmployeeNumber.Text);
                lblEmployeeNumber.Enabled = false;
                if (Request.QueryString["strDOR"] == Resources.Resource.Resigned)
                {
                    btnSubmit.Text = Resources.Resource.Next;
                    DisableFields();
                }
                FillgvEmployeeConstraint();

                FillAdditionalEmployeeDetail();
            }

            if (Request.QueryString["strStatus"] == Resources.Resource.Update)
            {
                Status = 1;
                btnNext.Visible = true;
                btnContactDetails.Visible = true;
                btnCompensationDetails.Visible = true;
                btnTrainingDetails.Visible = true;
                btnClear.Visible = true;
                lblEmployeeNumber.Enabled = false;
                lblEmployeeNumber.Text = Request.QueryString["strEmployeeNumber"];
                txtEmployeeNumberCon.Text = (Request.QueryString["strEmployeeNumber"]);
                txtEmployeeNumberEmployeePreferances.Text = (Request.QueryString["strEmployeeNumber"]);
                txtEmployeeNumberBarredAssignments.Text = (Request.QueryString["strEmployeeNumber"]);
                txtEmpAdd.Text = (Request.QueryString["strEmployeeNumber"]);
                FillDetailsForUpdate(lblEmployeeNumber.Text);
                if (Request.QueryString["strStatus1"] == "NM")
                {
                    btnSubmit.Text = Resources.Resource.Next;
                    DisableFields();
                }
                FillgvEmployeeConstraint();
                FillAdditionalEmployeeDetail();
            }
            ValidateFields();
            FillDesignation();
            FillCategory();
            FillJobType();
            FillJobClass();
            FillDepartment();
            FillgvOtherDetails();
            FillCurrency();
            FillRateFrequency();
            FillRole();
            FillgvBankDetail();
            FillgvFamilyDetail();
            // Added for SAT#124
            var _objblUserManagement = new BL.UserManagement();
            var dsConfirmDuty = _objblUserManagement.SystemParameterValuesByCompany(Convert.ToInt32(BaseLocationAutoID), "ConfirmDuty");
            if (dsConfirmDuty != null && dsConfirmDuty.Tables[0].Rows.Count > 0 && Convert.ToString(dsConfirmDuty.Tables[0].Rows[0]["ParamValue1"]) == "1")
            {
                lblConfirmDuty.Visible = true;
                ddlConfirmDuty.Visible = true;
                ddlConfirmDuty.SelectedValue = Convert.ToString(dsConfirmDuty.Tables[0].Rows[0]["ParamValue1"]);
            }
            FillgvEmployeeWorkHistory();

            //End
            //if (BaseUserInformation.CountryName != null && BaseUserInformation.CountryName.ToLower().IndexOf("israel") >= 0)
            //{
            //    EmpDetails.Tabs[4].Visible = true;
            //}
            //else
            //{
            //    EmpDetails.Tabs[4].Visible = false;
            //}
        }
    }

    /// <summary>
    /// Get Other Details Like Passport,ID info etc
    /// </summary>
   
    #endregion

    #region Function to validate Fields on Key up and Blur
    /// <summary>
    /// For valdiate the control
    /// </summary>
    private void ValidateFields()
    {
        txtFirstName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtFirstName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtLastName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtLastName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
       
        //txtHeight.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        //txtHeight.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

        txtWeight.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        txtWeight.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

        txtState.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtState.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtPrevExp.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        txtPrevExp.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

        txtWageRate.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        txtWageRate.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        txtContractedHrs.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        txtContractedHrs.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

      
       

    }
    #endregion

    #region Function To disable Fields for resigned Employee
    /// <summary>
    /// Function used to Enabale and Disable the control
    /// </summary>
    private void DisableFields()
    {
        txtAddress.Enabled = false;
        txtContactNo.Enabled = false;
        txtFirstName.Enabled = false;
       // txtHeight.Enabled = false;
        txtLastName.Enabled = false;
        ddlNationality.Enabled = false;
        txtPrevExp.Enabled = false;
        ddlReligion.Enabled = false;
        txtState.Enabled = false;
        txtWeight.Enabled = false;
        ddlCategory.Enabled = false;
        ddlDesignation.Enabled = false;
        ddlGrade.Enabled = false;
        ddlSex.Enabled = false;
        ddlJobClass.Enabled = false;
        ddlDepartment.Enabled = false;
        ddlJobType.Enabled = false;
        ddlRole.Enabled = false;
        ddlMaritalStatus.Enabled = false;
        ddlheightfeet.Enabled = false;
        ddlheightinch.Enabled = false;

        ddlMilitary.Enabled = false;
        ddlSmoker.Enabled = false;
        ddlVegitarian.Enabled = false;
        imgDate.Visible = false;
        imgDOB.Visible = false;

        txtWageRate.Enabled = false;
        ddlCurrency.Enabled = false;
        ddlContractDays.Enabled = false;
        txtContractedHrs.Enabled = false;
        ddlContHrsFreqency.Enabled = false;

    }

    #endregion

    #region Function to fill Details Of the Selected Employee for update

    /// <summary>
    /// Fills Employeewise nationality
    /// </summary>
    private void FillddlNationality()
    {
        var objMastersManagement = new BL.MastersManagement();
        var ds = objMastersManagement.NationalityMasterGetAll();
        ddlNationality.DataSource = ds.Tables[0];
        ddlNationality.DataTextField = "NationalityDesc";
        ddlNationality.DataValueField = "NationalityID";
        ddlNationality.DataBind();
        if (ddlNationality.Text == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoDataToShow, Value = "" };
            ddlNationality.Items.Insert(0, li);
            btnSubmit.Enabled = false;
        }
        else
        {
            btnSubmit.Enabled = true;
        }
    }
    /// <summary>
    /// Fills Employeewise Religion details
    /// </summary>
    private void FillddlReligion()
    {
        var objHrManagement = new BL.HRManagement();
        var ds = objHrManagement.ReligionMasterGet(BaseCompanyCode);
        ddlReligion.DataSource = ds.Tables[0];
        ddlReligion.DataTextField = "ItemDesc";
        ddlReligion.DataValueField = "ItemCode";
        ddlReligion.DataBind();
        if (ddlReligion.Text == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoDataToShow, Value = "" };
            ddlReligion.Items.Insert(0, li);
            btnSubmit.Enabled = false;
        }
        else
        {
            btnSubmit.Enabled = true;
        }


    }
    private void getAllRecordsNonEditable()
    {
        var ds = new DataSet();
        var objInterface = new BL.Interface();
        ds = objInterface.GetAllRecordsOnScreenName("Employee Master");
        var objInterfacePage = new InterfacePage();
        objInterfacePage.ControlsNonEditable(ds, Page);
    }
    /// <summary>
    /// To get EmployeeDetail For update
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    private void FillDetailsForUpdate(string strEmployeeNumber)
    {
        var objHrManagement = new BL.HRManagement();

        var ds = objHrManagement.EmployeeDetailUpdate(strEmployeeNumber, BaseLocationAutoID);
        try
        {
            txtEmpNoOld.Text = ds.Tables[0].Rows[0]["EmployeeNumberOld"].ToString();
            txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();

            txtEmployeeNameCon.Text = ds.Tables[0].Rows[0]["FirstName"] + @" " + ds.Tables[0].Rows[0]["LastName"];
            txtEmployeeNameEmployeePreferances.Text = ds.Tables[0].Rows[0]["FirstName"] + @" " + ds.Tables[0].Rows[0]["LastName"];
            txtEmployeeNameBarredAssignments.Text = ds.Tables[0].Rows[0]["FirstName"] + @" " + ds.Tables[0].Rows[0]["LastName"];
            txtEmpName.Text = ds.Tables[0].Rows[0]["FirstName"] + @" " + ds.Tables[0].Rows[0]["LastName"];
            txtDateOfBirth.Text = DateFormat(ds.Tables[0].Rows[0]["DateOfBirth"].ToString());
            hfdob.Value = txtDateOfBirth.Text;
            ddlSex.SelectedValue = ds.Tables[0].Rows[0]["Sex"].ToString();
            ddlMaritalStatus.SelectedValue = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();
            if(ds.Tables[0].Rows[0]["Height"].ToString() != "")
            { 
            string height = ds.Tables[0].Rows[0]["Height"].ToString();

            int[] heightdetails = cmtoftinch(height);
            ddlheightfeet.SelectedValue = heightdetails[0].ToString();
            ddlheightinch.SelectedValue = heightdetails[1].ToString();
            }
            txtWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
            txtState.Text = ds.Tables[0].Rows[0]["HomeState"].ToString();
            ddlReligion.SelectedValue = ds.Tables[0].Rows[0]["Religion"].ToString();
            txtPrevExp.Text = ds.Tables[0].Rows[0]["PrevTotalExp"].ToString();
            ddlNationality.SelectedValue = ds.Tables[0].Rows[0]["Nationality"].ToString();
            txtDateOfJoining.Text = DateFormat(ds.Tables[0].Rows[0]["DateOfJoining"].ToString());
            txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
          
            ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryCode"].ToString();
            ddlDesignation.SelectedValue = ds.Tables[0].Rows[0]["DesignationCode"].ToString();
            ddlGrade.SelectedValue = ds.Tables[0].Rows[0]["GradeCode"].ToString();
            ddlJobClass.SelectedValue = ds.Tables[0].Rows[0]["JobClassCode"].ToString();
            txtidentificationmark.Text = ds.Tables[0].Rows[0]["IdentificationMark"].ToString();
            txtbloodgroup.Text = ds.Tables[0].Rows[0]["BloodGroup"].ToString();
            txtDisability.Text = ds.Tables[0].Rows[0]["Disability"].ToString();
          if(ds.Tables[0].Rows[0]["CategoryCode"].ToString() =="IND")
          {
              RFVtxtWageRate.Enabled = false;
              RequiredFieldValidator11.Enabled = false;
          }
          else
          {
              RFVtxtWageRate.Enabled = true;
              RequiredFieldValidator11.Enabled = true;
          }

            if (ds.Tables[0].Rows[0]["AreaID"] != DBNull.Value)
            {

                var boolflag = ddlAreaId.Enabled;
                ddlAreaId.Enabled = true;
                ddlAreaId.SelectedIndex = ddlAreaId.Items.IndexOf(ddlAreaId.Items.FindByValue(ds.Tables[0].Rows[0]["AreaID"].ToString()));
                ddlAreaId.Enabled = boolflag;
            }
            ddlRole.SelectedValue = ds.Tables[0].Rows[0]["RoleCode"].ToString();
            ddlDepartment.SelectedValue = ds.Tables[0].Rows[0]["DepartmentCode"].ToString();
            ddlJobType.SelectedValue = ds.Tables[0].Rows[0]["JobTypeCode"].ToString();
            ddlMilitary.SelectedValue = ds.Tables[0].Rows[0]["MilitaryStatus"].ToString();
            ddlSmoker.SelectedValue = ds.Tables[0].Rows[0]["Smoker"].ToString();
            ddlContractDays.SelectedValue = ds.Tables[0].Rows[0]["ContractDays"].ToString();
            ddlVegitarian.SelectedValue = ds.Tables[0].Rows[0]["Vegitarian"].ToString();
            txtOtherLanguageFirstName.Text = ds.Tables[0].Rows[0]["MultiLingualFirstName"].ToString();
            HFOtherLanguageFirstName.Value = ds.Tables[0].Rows[0]["MultiLingualFirstName"].ToString();
            txtOtherLanguageLastName.Text = ds.Tables[0].Rows[0]["MultiLingualLastName"].ToString();
            HFOtherLanguageLastName.Value = ds.Tables[0].Rows[0]["MultiLingualLastName"].ToString();
            chkOTEntitlement.Checked = bool.Parse(ds.Tables[0].Rows[0]["OTENTITLEMENT"].ToString());
            txtOtValidity.Text = DateFormat(ds.Tables[0].Rows[0]["OTDATE"].ToString());
            txtStatus.Text = ds.Tables[0].Rows[0]["STATUSCODE"].ToString();
            txtStatusDesc.Text = ds.Tables[0].Rows[0]["STATUSDESC"].ToString();
            txtWeFDate.Text = DateFormat(ds.Tables[0].Rows[0]["STATUSDATE"].ToString());
            txtScaleCode.Text = ds.Tables[0].Rows[0]["SCALECODE"].ToString();
            txtScaleDesc.Text = ds.Tables[0].Rows[0]["SCALEDESC"].ToString();
            txtAreaInchargeName.Text = ds.Tables[0].Rows[0]["AreaInchargeName"].ToString();
            ddlDesignation.Enabled = false;
            ddlGrade.Enabled = false;
            ddlCategory.Enabled = false;
            ddlJobClass.Enabled = false;
            ddlAreaId.Enabled = false;
            ddlJobType.Enabled = false;
            ddlDepartment.Enabled = false;
            ddlRole.Enabled = false;

            txtWageRate.Enabled = false;
            ddlCurrency.Enabled = false;
            ddlContractDays.Enabled = false;
            txtContractedHrs.Enabled = false;
            ddlContHrsFreqency.Enabled = false;
            getAllRecordsNonEditable();
            btnMultilingual.Visible = false;
            FillgvOtherDetails();

            var wagerate1 = ds.Tables[0].Rows[0]["WageRate"].ToString();
            if ((ds.Tables[0].Rows[0]["WageRate"].ToString() != "") && (ds.Tables[0].Rows[0]["WageRate"].ToString() != "0.00000000"))
            {
                
                txtWageRate.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["WageRate"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                ddlCurrency.SelectedValue = ds.Tables[0].Rows[0]["WageCurrencyCode"].ToString();
                txtContractedHrs.Text = ds.Tables[0].Rows[0]["ContractHours"].ToString();
                ddlContHrsFreqency.SelectedValue = ds.Tables[0].Rows[0]["CotractHrsFrequency"].ToString();
            }
            else
            {
                txtWageRate.Text = "";
                txtContractedHrs.Text = "";

            }
           
            var dsIncharge = objHrManagement.AreaInchargeGet(BaseCompanyCode, strEmployeeNumber);
            if (dsIncharge != null && dsIncharge.Tables[0].Rows.Count > 0)
            {
                txtDateOfJoining.Enabled = false;
                CalendarExtender1.Enabled = false;
            }
            else
            {
                txtDateOfJoining.Enabled = true;
                CalendarExtender1.Enabled = true;
            }


            if (!bool.Parse(ds.Tables[0].Rows[0]["IsDOJEditable"].ToString()))
            {
                txtDateOfJoining.Enabled = false;
                imgDate.Enabled = false;
            }

        }
        catch (Exception)
        {
            btnSubmit.Enabled = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
            DisableFields();

        }
    }
    #endregion

    #region User Defined Function related to Fill ComboBox Designation/Category/JobType/JobClass

    /// <summary>
    /// Fills Designation DropDown
    /// </summary>
    private void FillDesignation()
    {

        var objMastersManagement = new BL.MastersManagement();
        ddlDesignation.DataSource = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        ddlDesignation.DataTextField = "DesignationDesc";
        ddlDesignation.DataValueField = "DesignationCode";
        ddlDesignation.DataBind();
        if (ddlDesignation.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlDesignation.Items.Add(li);
            btnSubmit.Enabled = false;
        }
        FillGrade();
    }
    private void FillGrade()
    {

        var objMastersManagement = new BL.MastersManagement();
        ddlGrade.DataSource = objMastersManagement.GradeMasterGetAll(BaseCompanyCode, ddlDesignation.SelectedItem.Value);
        ddlGrade.DataTextField = "GradeDesc";
        ddlGrade.DataValueField = "GradeCode";
        ddlGrade.DataBind();
        if (ddlGrade.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlGrade.Items.Add(li);
            btnSubmit.Enabled = false;
        }
    }

    /// <summary>
    /// Fills Category Dropdown
    /// </summary>
    private void FillCategory()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlCategory.DataSource = objMastersManagement.CategoryMasterGetAll(BaseCompanyCode);
        ddlCategory.DataTextField = "CategoryDesc";
        ddlCategory.DataValueField = "CategoryCode";
        ddlCategory.DataBind();
        if (ddlCategory.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlCategory.Items.Add(li);
            btnSubmit.Enabled = false;
        }
        
       
    }

    /// <summary>
    /// Fills JobType DropDown
    /// </summary>
    private void FillJobType()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlJobType.DataSource = objMastersManagement.JobTypeMasterGetAll(BaseCompanyCode);
        ddlJobType.DataTextField = "JobTypeDesc";
        ddlJobType.DataValueField = "JobTypeCode";
        ddlJobType.DataBind();
        if (ddlJobType.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlJobType.Items.Add(li);

        }
    }

    /// <summary>
    /// Fills JobClass Dropdown
    /// </summary>
    private void FillJobClass()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlJobClass.DataSource = objMastersManagement.JobClassMasterGetAll(BaseCompanyCode);
        ddlJobClass.DataTextField = "JobClassDesc";
        ddlJobClass.DataValueField = "JobClassCode";
        ddlJobClass.DataBind();
        if (ddlJobClass.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlJobClass.Items.Add(li);

        }
    }

    /// <summary>
    /// Fills AreaID DropDown
    /// </summary>
    private void FillAreaId()
    {

        var objOperationManagement = new BL.OperationManagement();
        ddlAreaId.DataSource = objOperationManagement.AreaIdGetAll((BaseLocationAutoID), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        ddlAreaId.DataTextField = "AreaDesc";
        ddlAreaId.DataValueField = "AreaID";
        ddlAreaId.DataBind();

        if (ddlAreaId.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAreaId.Items.Add(li);
        }

        FetchAreaInchargeName();
    }

    /// <summary>
    /// Fetches the name of the area incharge.
    /// </summary>
    private void FetchAreaInchargeName()
    {
        var objHrManagement = new BL.HRManagement();
        var ds = objHrManagement.AreaInchargeNameGet(BaseLocationAutoID, ddlAreaId.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaInchargeName.Text = ds.Tables[0].Rows[0]["AreaInchargeName"].ToString();
        }
        else
        {
            txtAreaInchargeName.Text = "";
        }
    }


    /// <summary>
    /// Fills Department DropDown
    /// </summary>
    private void FillDepartment()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlDepartment.DataSource = objMastersManagement.DepartmentGetAll(BaseCompanyCode);
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataValueField = "DepartmentCode";
        ddlDepartment.DataBind();
        if (ddlDepartment.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlDepartment.Items.Add(li);

        }
    }

    /// <summary>
    /// Fills Currency DropDown
    /// </summary>
    private void FillCurrency()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlCurrency.DataSource = objMastersManagement.CurrencyMasterGetAll();
        ddlCurrency.DataTextField = "CurrencyDesc";
        ddlCurrency.DataValueField = "CurrencyCode";
        ddlCurrency.DataBind();
        if (ddlCurrency.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlCurrency.Items.Add(li);

        }
    }

    /// <summary>
    /// Gets the Rate on the basis of Frequency
    /// </summary>
    private void FillRateFrequency()
    {

        var objMastersManagement = new BL.MastersManagement();
        var ds = objMastersManagement.RateFrequencyGetAll(BaseCompanyCode);
        ddlContHrsFreqency.DataSource = ds;
        ddlContHrsFreqency.DataTextField = "WRfDesc";
        ddlContHrsFreqency.DataValueField = "WRfCode";
        ddlContHrsFreqency.DataBind();
        ds.Dispose();
    }

    /// <summary>
    /// Fills Role Drop Down
    /// </summary>
    private void FillRole()
    {
        var objMaster = new BL.MastersManagement();
        var dsRole = objMaster.RoleMasterGet(BaseCompanyCode);
        if (dsRole != null && dsRole.Tables.Count > 0 && dsRole.Tables[0].Rows.Count > 0)
        {
            ddlRole.DataSource = dsRole;
            ddlRole.DataValueField = "RoleCode";
            ddlRole.DataTextField = "RoleDesc";
            ddlRole.DataBind();
        }
        else
        {
            var Li = new ListItem { Text = Resources.Resource.NoData, Value = @"NoData" };
            ddlRole.Items.Add(Li);
        }
    }
    #endregion

    #region  Button Submit Click Event
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try { 
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();


        var dtOtherInfoDetails = new DataTable();
        if (ViewState["dtOtherInfoDetails"] != null)
        {
            dtOtherInfoDetails = (DataTable)ViewState["dtOtherInfoDetails"];
        }
        var objCommon = new BL.Common();
        lblErrorMsg.Text = "";
        if (!objCommon.IsValidDate(txtDateOfBirth.Text) || !objCommon.IsValidDate(txtDateOfJoining.Text))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            return;
        }

        if (DateTime.Compare(DateTime.Parse(txtDateOfJoining.Text), DateTime.Parse(txtDateOfBirth.Text).AddYears(18)) >= 0)
        {
            double wageRate = 0.00;
            if (DateTime.Parse(txtDateOfBirth.Text) < DateTime.Parse(txtDateOfJoining.Text) && DateTime.Parse(txtDateOfBirth.Text) < DateTime.Now)//DateTime.Parse(DL.Common.DateFormat(DateTime.Now)))
            {
                var PrevExp = txtPrevExp.Text == "" ? 0 : float.Parse(txtPrevExp.Text);
                var Weight = txtWeight.Text == "" ? 0 : float.Parse(txtWeight.Text);
             //   var strWageRate = txtWageRate.Text == "" ? 0 : double.Parse(txtWageRate.Text);
                if (txtWageRate.Text != "")
                    wageRate = double.Parse(txtWageRate.Text);
                else
                    wageRate = 0.00;
               
                var strWageRate = wageRate.ToString();

                var empContractedHrs = txtContractedHrs.Text == "" ? 0 : float.Parse(txtContractedHrs.Text);
                txtContractedHrs.Text = empContractedHrs.ToString();
                if (txtWeFDate.Text == "")
                {
                    txtWeFDate.Text = @"1900-01-01 00:00:00.000";
                }
                if (txtOtValidity.Text == "")
                {
                    txtOtValidity.Text = @"1900-01-01 00:00:00.000";
                }
                if (txtWeFDate.Text != @"1900-01-01 00:00:00.000")
                {
                    if (DateTime.Parse(txtDateOfJoining.Text) > DateTime.Parse(txtWeFDate.Text))
                    {
                        lblErrorMsg.Text = Resources.Resource.WEFDateShouldBeGreaterThanDOJ; // @"WEF Date should be greater than Date of Joining ";
                        txtWeFDate.Focus();
                        return;
                    }
                }
                if (txtOtValidity.Text != @"1900-01-01 00:00:00.000")
                {
                    if (DateTime.Parse(txtDateOfJoining.Text) > DateTime.Parse(txtOtValidity.Text))
                    {
                        lblErrorMsg.Text = Resources.Resource.OTValidityDateShouldBeGreaterThanDOJ;//@"OT Validity Date should be greater than Date of Joining ";
                        txtOtValidity.Focus();
                        return;
                    }
                }

                if (btnSubmit.Text == Resources.Resource.Save)
                {
                    string EmployeeNumber;
                    if (ddlContHrsFreqency.SelectedItem.Text.Trim() == "Daily")
                    {
                        if (double.Parse(txtContractedHrs.Text) <= 24)
                        {


                            if (bool.Parse(HFEmployeeAutoGenerateStatus.Value) == false)
                            {
                                if (lblEmployeeNumber.Text == "")
                                {
                                    lblErrorMsg.Text = Resources.Resource.EmployeecannotbeleftBlank;
                                    btnSubmit.Visible = true;
                                    var ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                                    ToolkitScriptManager2.SetFocus(lblEmployeeNumber);
                                    return;
                                }

                              
                                ds = objHrManagement.PersonalDetailsInsert(BaseCompanyCode, DateTime.Parse(txtDateOfBirth.Text), txtFirstName.Text, txtLastName.Text, ftinchtocm(ddlheightfeet.Text, ddlheightinch.Text).ToString(), float.Parse(Weight.ToString()), ddlSex.SelectedValue, ddlMaritalStatus.SelectedValue, ddlNationality.SelectedValue, txtState.Text, txtAddress.Text, txtContactNo.Text, ddlReligion.SelectedValue, ddlMilitary.SelectedValue, ddlSmoker.SelectedValue, ddlVegitarian.SelectedValue, float.Parse(PrevExp.ToString()), DateTime.Parse(txtDateOfJoining.Text), ddlDesignation.SelectedValue,ddlGrade.SelectedItem.Value, ddlCategory.SelectedValue, BaseUserID, ddlJobClass.SelectedValue, ddlAreaId.SelectedValue, ddlJobType.SelectedValue, ddlRole.SelectedValue, BaseLocationAutoID, "" /*txtIdentificationNumber.Text*/, /* ddlIdentificationType.SelectedValue.ToString()*/ "", lblEmployeeNumber.Text, txtEmpNoOld.Text, ddlDepartment.SelectedValue, dtOtherInfoDetails, strWageRate, ddlCurrency.SelectedValue, "H", "H", empContractedHrs, ddlContHrsFreqency.SelectedValue, BaseUserID, txtOtherLanguageFirstName.Text, txtOtherLanguageLastName.Text, ddlContractDays.SelectedValue, chkOTEntitlement.Checked.ToString(), txtOtValidity.Text, txtStatus.Text, txtStatusDesc.Text, txtWeFDate.Text, txtScaleCode.Text, txtScaleDesc.Text, txtbloodgroup.Text, txtidentificationmark.Text, txtDisability.Text);
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }
                            else
                            {

                                ds = objHrManagement.PersonalDetailsInsert(BaseCompanyCode, DateTime.Parse(txtDateOfBirth.Text), txtFirstName.Text, txtLastName.Text, ftinchtocm(ddlheightfeet.Text, ddlheightinch.Text).ToString(), float.Parse(Weight.ToString()), ddlSex.SelectedValue, ddlMaritalStatus.SelectedValue, ddlNationality.SelectedValue, txtState.Text, txtAddress.Text, txtContactNo.Text, ddlReligion.SelectedValue, ddlMilitary.SelectedValue, ddlSmoker.SelectedValue, ddlVegitarian.SelectedValue, float.Parse(PrevExp.ToString()), DateTime.Parse(txtDateOfJoining.Text), ddlDesignation.SelectedValue,ddlGrade.SelectedItem.Value, ddlCategory.SelectedValue, BaseUserID, ddlJobClass.SelectedValue, ddlAreaId.SelectedValue, ddlJobType.SelectedValue, ddlRole.SelectedValue, BaseLocationAutoID, "" /*txtIdentificationNumber.Text*/, /* ddlIdentificationType.SelectedValue.ToString()*/ "", lblEmployeeNumber.Text, txtEmpNoOld.Text, ddlDepartment.SelectedValue, dtOtherInfoDetails, strWageRate, ddlCurrency.SelectedValue, "H", "H", empContractedHrs, ddlContHrsFreqency.SelectedValue, BaseUserID, txtOtherLanguageFirstName.Text, txtOtherLanguageLastName.Text, ddlContractDays.SelectedValue, chkOTEntitlement.Checked.ToString(), txtOtValidity.Text, txtStatus.Text, txtStatusDesc.Text, txtWeFDate.Text, txtScaleCode.Text, txtScaleDesc.Text, txtbloodgroup.Text, txtidentificationmark.Text, txtDisability.Text);
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }


                            EmployeeNumber = ds.Tables[0].Rows[0]["GeneratedCode"].ToString();
                            if (EmployeeNumber != "")
                            {
                                dtOtherInfoDetails.Clear();
                                btnNext.Visible = true;
                                btnContactDetails.Visible = true;
                                btnCompensationDetails.Visible = true;
                                btnTrainingDetails.Visible = true;
                                lblEmployee.Visible = true;
                                lblEmployeeNumber.Visible = true;
                                lblEmployeeNumber.Text = EmployeeNumber;
                                lblEmployeeNumber.ReadOnly = true;
                                FillDetailsForUpdate(EmployeeNumber);
                                FillgvEmployeeConstraint();
                                btnClear.Visible = true;
                                Status = 1;
                            }

                        }


                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.ContractedCannotGreaterThan24HrsDaily;
                            btnSubmit.Visible = true;
                            return;
                        }

                    }


                    else
                    {

                        if (bool.Parse(HFEmployeeAutoGenerateStatus.Value) == false)
                        {
                            if (lblEmployeeNumber.Text == "")
                            {
                                lblErrorMsg.Text = Resources.Resource.EmployeecannotbeleftBlank;
                                btnSubmit.Visible = true;
                                var ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                                ToolkitScriptManager2.SetFocus(lblEmployeeNumber);
                                return;
                            }
                            ds = objHrManagement.PersonalDetailsInsert(BaseCompanyCode, DateTime.Parse(txtDateOfBirth.Text), txtFirstName.Text, txtLastName.Text, ftinchtocm(ddlheightfeet.Text, ddlheightinch.Text).ToString(), float.Parse(Weight.ToString()), ddlSex.SelectedValue, ddlMaritalStatus.SelectedValue, ddlNationality.SelectedValue, txtState.Text, txtAddress.Text, txtContactNo.Text, ddlReligion.SelectedValue, ddlMilitary.SelectedValue, ddlSmoker.SelectedValue, ddlVegitarian.SelectedValue, float.Parse(PrevExp.ToString()), DateTime.Parse(txtDateOfJoining.Text), ddlDesignation.SelectedValue,ddlGrade.SelectedItem.Value, ddlCategory.SelectedValue, BaseUserID, ddlJobClass.SelectedValue, ddlAreaId.SelectedValue, ddlJobType.SelectedValue, ddlRole.SelectedValue, BaseLocationAutoID, "" /*txtIdentificationNumber.Text*/, /* ddlIdentificationType.SelectedValue.ToString()*/ "", lblEmployeeNumber.Text, txtEmpNoOld.Text, ddlDepartment.SelectedValue, dtOtherInfoDetails, strWageRate, ddlCurrency.SelectedValue, "H", "H", empContractedHrs, ddlContHrsFreqency.SelectedValue, BaseUserID, txtOtherLanguageFirstName.Text, txtOtherLanguageLastName.Text, ddlContractDays.SelectedValue, chkOTEntitlement.Checked.ToString(), txtOtValidity.Text, txtStatus.Text, txtStatusDesc.Text, txtWeFDate.Text, txtScaleCode.Text, txtScaleDesc.Text, txtbloodgroup.Text, txtidentificationmark.Text, txtDisability.Text);
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                        else
                        {
                            ds = objHrManagement.PersonalDetailsInsert(BaseCompanyCode, DateTime.Parse(txtDateOfBirth.Text), txtFirstName.Text, txtLastName.Text, ftinchtocm(ddlheightfeet.Text, ddlheightinch.Text).ToString(), float.Parse(Weight.ToString()), ddlSex.SelectedValue, ddlMaritalStatus.SelectedValue, ddlNationality.SelectedValue, txtState.Text, txtAddress.Text, txtContactNo.Text, ddlReligion.SelectedValue, ddlMilitary.SelectedValue, ddlSmoker.SelectedValue, ddlVegitarian.SelectedValue, float.Parse(PrevExp.ToString()), DateTime.Parse(txtDateOfJoining.Text), ddlDesignation.SelectedValue, ddlGrade.SelectedItem.Value, ddlCategory.SelectedValue, BaseUserID, ddlJobClass.SelectedValue, ddlAreaId.SelectedValue, ddlJobType.SelectedValue, ddlRole.SelectedValue, BaseLocationAutoID, "" /*txtIdentificationNumber.Text*/, /* ddlIdentificationType.SelectedValue.ToString()*/ "", lblEmployeeNumber.Text, txtEmpNoOld.Text, ddlDepartment.SelectedValue, dtOtherInfoDetails, strWageRate, ddlCurrency.SelectedValue, "H", "H", empContractedHrs, ddlContHrsFreqency.SelectedValue, BaseUserID, txtOtherLanguageFirstName.Text, txtOtherLanguageLastName.Text, ddlContractDays.SelectedValue, chkOTEntitlement.Checked.ToString(), txtOtValidity.Text, txtStatus.Text, txtStatusDesc.Text, txtWeFDate.Text, txtScaleCode.Text, txtScaleDesc.Text, txtbloodgroup.Text, txtidentificationmark.Text, txtDisability.Text);
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }



                        EmployeeNumber = ds.Tables[0].Rows[0]["GeneratedCode"].ToString();
                        if (EmployeeNumber != "")
                        {
                            btnNext.Visible = true;
                            btnContactDetails.Visible = true;
                            btnCompensationDetails.Visible = true;
                            btnTrainingDetails.Visible = true;
                            lblEmployee.Visible = true;
                            lblEmployeeNumber.Visible = true;
                            lblEmployeeNumber.Text = EmployeeNumber;
                            lblEmployeeNumber.ReadOnly = true;
                            FillDetailsForUpdate(EmployeeNumber);
                            FillgvEmployeeConstraint();

                        }
                    }

                    btnSubmit.Text = Resources.Resource.Update;
                    return;
                }
                if (btnSubmit.Text == Resources.Resource.Update)
                {

                    if (ddlContHrsFreqency.SelectedItem.Text.Trim() == "Daily")
                    {
                        if (double.Parse(txtContractedHrs.Text) <= 24)
                        {

                            ds = objHrManagement.EmployeeDetailUpdate(BaseCompanyCode, DateTime.Parse(txtDateOfBirth.Text), txtFirstName.Text, txtLastName.Text, ftinchtocm(ddlheightfeet.Text, ddlheightinch.Text).ToString(), float.Parse(Weight.ToString()), ddlSex.SelectedValue, ddlMaritalStatus.SelectedValue, ddlNationality.SelectedValue, txtState.Text, txtAddress.Text, txtContactNo.Text, ddlReligion.SelectedValue, ddlMilitary.SelectedValue, ddlSmoker.SelectedValue, ddlVegitarian.SelectedValue, float.Parse(PrevExp.ToString()), DateTime.Parse(txtDateOfJoining.Text), BaseUserID,/* txtIdentificationNumber.Text, ddlIdentificationType.SelectedValue.ToString()*/"", "", lblEmployeeNumber.Text, txtEmpNoOld.Text, strWageRate, ddlCurrency.SelectedValue, "H", "H", empContractedHrs, ddlContHrsFreqency.SelectedValue, ddlContractDays.SelectedValue, chkOTEntitlement.Checked.ToString(), txtOtValidity.Text, txtStatus.Text, txtStatusDesc.Text, txtWeFDate.Text, txtScaleCode.Text, txtScaleDesc.Text, txtbloodgroup.Text, txtidentificationmark.Text, txtDisability.Text);
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                            if (txtWeFDate.Text == @"1900-01-01 00:00:00.000")
                            {
                                txtWeFDate.Text = "";
                            }
                            if (txtOtValidity.Text == @"1900-01-01 00:00:00.000")
                            {
                                txtOtValidity.Text = "";
                            }

                        }


                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.ContractedCannotGreaterThan24HrsDaily; //@" Contracted cannot Greater than 24 when Contracted Frequency  is daily ";

                        }


                    }


                    else
                    {
                        ds = objHrManagement.EmployeeDetailUpdate(BaseCompanyCode, DateTime.Parse(txtDateOfBirth.Text), txtFirstName.Text, txtLastName.Text, ftinchtocm(ddlheightfeet.Text, ddlheightinch.Text).ToString(), float.Parse(Weight.ToString()), ddlSex.SelectedValue, ddlMaritalStatus.SelectedValue, ddlNationality.SelectedValue, txtState.Text, txtAddress.Text, txtContactNo.Text, ddlReligion.SelectedValue, ddlMilitary.SelectedValue, ddlSmoker.SelectedValue, ddlVegitarian.SelectedValue, float.Parse(PrevExp.ToString()), DateTime.Parse(txtDateOfJoining.Text), BaseUserID,/* txtIdentificationNumber.Text, ddlIdentificationType.SelectedValue.ToString()*/"", "", lblEmployeeNumber.Text, txtEmpNoOld.Text, strWageRate, ddlCurrency.SelectedValue, "H", "H", empContractedHrs, ddlContHrsFreqency.SelectedValue, ddlContractDays.SelectedValue, chkOTEntitlement.Checked.ToString(), txtOtValidity.Text, txtStatus.Text, txtStatusDesc.Text, txtWeFDate.Text, txtScaleCode.Text, txtScaleDesc.Text, txtbloodgroup.Text, txtidentificationmark.Text, txtDisability.Text);

                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                    }

                }
                if (btnSubmit.Text == Resources.Resource.Next)
                {
                    var PageStatus = Resources.Resource.Next;
                    Response.Redirect("EmployeeMasterDetail.aspx?strStatus=" + PageStatus + "&strEmployeeNumber=" + lblEmployeeNumber.Text);
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.DOJCompareDOB;
                txtDateOfJoining.Text = "";
                txtDateOfJoining.BackColor = System.Drawing.Color.Gold;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MinimumDiffBetweenDOBDOJ18;
        }

        ViewState["dtOtherInfoDetails"] = null;
        ViewState["dtOtherInfoDetails"] = dtOtherInfoDetails;

            }
        catch(Exception ex)
        { }
    }

    private double ftinchtocm(string x,string y)
    {
        double cm;
        cm = (((Convert.ToDouble(x) * 12) + Convert.ToDouble(y)) * 2.54);
        return cm;
    }
    private int[] cmtoftinch(string a)
    {
        double ht;
            int ft, inch;
        ht=((Convert.ToDouble(a)*0.3937008));
        ft =(Int32)( ht / 12);
       inch =Convert.ToInt32( ht % 12);
        return new int[] {ft,inch};
        
        
    }
    #endregion
    /// <summary>
    /// AreaID dropdown selected Index Change Event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// 

    #region function related to Employee Detail Tab
    protected void ddlAreaId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchAreaInchargeName();
    }
    /// <summary>
    /// Clear the control on clieck Button
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClear_Click(object sender, EventArgs e)
    {

        getAllRecordsEditable();
        imgDOB.Visible = true;
        btnMultilingual.Visible = true;
        ClearFields();
        btnContactDetails.Visible = false;
        btnCompensationDetails.Visible = false;
        btnTrainingDetails.Visible = false;
        btnSubmit.Visible = true;
        btnSubmit.Text = Resources.Resource.Save;
        btnNext.Visible = false;
        btnClear.Visible = false;
        ddlCategory.Enabled = true;
        ddlDesignation.Enabled = true;
        ddlGrade.Enabled = true;
        ddlSex.Enabled = true;
        ddlDepartment.Enabled = true;
        ddlJobClass.Enabled = true;
        ddlJobType.Enabled = true;
        ddlRole.Enabled = true;
        ddlAreaId.Enabled = true;
        txtDateOfJoining.Enabled = true;
        imgDate.Enabled = true;
        txtWageRate.Enabled = true;
        ddlCurrency.Enabled = true;
        ddlContractDays.Enabled = true;
        txtContractedHrs.Enabled = true;
        ddlContHrsFreqency.Enabled = true;

        if (!bool.Parse(HFEmployeeAutoGenerateStatus.Value))
        {
            lblEmployee.Visible = true;
            lblEmployeeNumber.Visible = true;
            lblEmployeeNumber.Enabled = true;
            lblEmployeeNumber.ReadOnly = false;
        }

    }
    /// <summary>
    /// Add Employee Additional details on submit button click
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmitAdd_Click(object sender, EventArgs e)
    {


        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        if (lblEmployeeNumber.Text != "")
        {
            if (txtRate.Text == "")
            {
                txtRate.Text = @"0";
            }
            if (txtTotal.Text == "")
            {
                txtTotal.Text = @"0";
            }
            if (txtTime.Text == "")
            {
                txtTime.Text = @"0";
            }
            if (txtWorkHrs.Text == "")
            {
                txtWorkHrs.Text = @"0";
            }
            ds = objHrManagement.EmployeeAdditionalDetailInsert(BaseCompanyCode, txtEmpAdd.Text, txtRate.Text, txtJobCode.Text, txtAddType.Text, txtOTdayCode.Text, txtOtDayDesc.Text, txtOTNghtCode.Text, txtOTNghtDesc.Text, chkWthExtra.Checked.ToString(), txtMoneyExtra.Text, txtTotal.Text, ddlTotal.SelectedItem.Value, txtTime.Text, txtWorkHrs.Text, txtSymbol.Text, BaseUserID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorAddEmp, ds.Tables[0].Rows[0]["MessageId"].ToString());
            }
            FillAdditionalEmployeeDetail();
        }
    }

    /// <summary>
    /// Delete the record on btnDelete click
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        if (lblEmployeeNumber.Text != "")
        {
            ds = objHrManagement.EmployeeAdditionalDetailDelete(BaseCompanyCode, txtEmpAdd.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorAddEmp, ds.Tables[0].Rows[0]["MessageId"].ToString());
                txtRate.Text = @"0.00";
                txtJobCode.Text = "";
                txtAddType.Text = "";
                txtOTdayCode.Text = "";
                txtOtDayDesc.Text = "";
                txtOTNghtCode.Text = "";
                txtOTNghtDesc.Text = "";
                chkWthExtra.Checked = false;
                txtMoneyExtra.Text = "";
                txtTotal.Text = @"0.00";
                txtTime.Text = @"0.00";
                txtWorkHrs.Text = @"0.00";
                txtSymbol.Text = "";

            }

        }
    }
    protected void txtDateOfJoining_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtDateOfJoining);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtOtValidity control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtOtValidity_TextChanged(object sender, EventArgs e)
    {
        if (txtOtValidity.Text != "")
        {
            ConvertStringToDateFormat(txtOtValidity);
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtWeFDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtWeFDate_TextChanged(object sender, EventArgs e)
    {
        if (txtWeFDate.Text != "")
        { ConvertStringToDateFormat(txtWeFDate); }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDateOfBirth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtDateOfBirth_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtDateOfBirth);
    }
    /// <summary>
    /// Converts the string to date format.
    /// </summary>
    /// <param name="txtDate">The text date.</param>
    protected void lblEmployeeNumber_TextChanged(object sender, EventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        ds = objHrManagement.IsEmployeeNumberAlreadyExist(lblEmployeeNumber.Text, BaseCompanyCode);
        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())))
        {
            toolkitScriptManager1.SetFocus(txtEmpNoOld);

            btnSubmit.Enabled = true;
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.EmpNoAlreadyExists;
            lblEmployeeNumber.Text = "";
            toolkitScriptManager1.SetFocus(lblEmployeeNumber);
            btnSubmit.Enabled = false;
        }
    }
    /// <summary>
    /// Set Focus on firstname on Employee old Number text box changed event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmpNoOld_TextChanged(object sender, EventArgs e)
    {
        var toolkitScript3 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        toolkitScript3.SetFocus(txtFirstName);

    }
    private void ClearFields()
    {
        lblEmployeeNumber.Text = "";
        txtEmpNoOld.Text = "";
        lblEmployee.Visible = false;
        lblEmployeeNumber.Visible = false;
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtDateOfBirth.Text = "";
        txtWeight.Text = "";
        txtidentificationmark.Text = "";
        txtbloodgroup.Text = "";
        txtDisability.Text = "";
        txtContactNo.Text = "";
        txtAddress.Text = "";
        txtState.Text = "";
        txtPrevExp.Text = "";
        txtDateOfJoining.Text = "";
        txtDisability.Text = "";
        txtidentificationmark.Text = "";
        txtbloodgroup.Text = "";
        txtWageRate.Text = "";
        txtContractedHrs.Text = "";
        ddlCategory.SelectedValue = "DIR";
        RequiredFieldValidator11.Enabled = true;
        RFVtxtWageRate.Enabled = true;
        FillgvOtherDetails();
        ViewState["dtOtherInfoDetails"] = null;
    }
    private void getAllRecordsEditable()
    {
        var ds = new DataSet();
        var objInterface = new BL.Interface();
        ds = objInterface.GetAllRecordsOnScreenName("Employee Master");
        var obj = new InterfacePage();
        obj.ControlsEditable(ds, Page);
    }

    protected void ddlcategory_selectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCategory.SelectedValue=="IND")
        {
            RequiredFieldValidator11.Enabled = false;
            RFVtxtWageRate.Enabled = false;

        }
        else
        {
            RequiredFieldValidator11.Enabled = true;
            RFVtxtWageRate.Enabled = true;
        }
    }
    #endregion

    #region Button Back and next Event
    /// <summary>
    /// Back button to redirect EmployeeDetail.aspx
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeDetail.aspx");
    }
    /// <summary>
    /// Button to redirect page EmployeeMasterDetail.aspx with some query parameters
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        var PageStatus = Resources.Resource.Next;
        Response.Redirect("EmployeeMasterDetail.aspx?strStatus=" + PageStatus + "&strEmployeeNumber=" + lblEmployeeNumber.Text + "&DOB=" + txtDateOfBirth.Text);
    }
    /// <summary>
    /// Button to redirect page EmployeeAddress.aspx with some query parameters
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnContactDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeAddress.aspx?EmployeeNumber=" + lblEmployeeNumber.Text + "&FirstName=" + txtFirstName.Text + "&LastName=" + txtLastName.Text + "");
    }
    /// <summary>
    /// Button to redirect page EmployeeCompensationHistory.aspx with some query parameters
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCompensationDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeCompensationHistory.aspx?EmployeeNumber=" + lblEmployeeNumber.Text + "&FirstName=" + txtFirstName.Text + "&LastName=" + txtLastName.Text + "");
    }
    /// <summary>
    /// Button to redirect page EmployeeTrainingDetails.aspx with some query parameters
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnTrainingDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeTrainingDetails.aspx?EmployeeNumber=" + lblEmployeeNumber.Text + "&FirstName=" + txtFirstName.Text + "&LastName=" + txtLastName.Text + "");
    }

    #endregion
    /// <summary>
    /// Clear All fileds
    /// </summary>
   
    /// <summary>
    /// Employee Number text box event change to verify either number already Exist
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
   
    /// <summary>
    /// Whenever we want to manipulate the appearance on some cell based on the value of that cell.
    /// gvOtherDetails is asp:GridView to show ID details
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
 
    #region Function for Id Details
    private void FillgvOtherDetails()
    {
        try
        {
            var objHrManagement = new BL.HRManagement();
            var dsOtherDetails = new DataSet();
            var dtOtherDetails = new DataTable();
            dtflag = 1;
            dsOtherDetails = objHrManagement.EmployeeOtherDetailsGet(lblEmployeeNumber.Text);
            dtOtherDetails = dsOtherDetails.Tables[0];
            if (dtOtherDetails.Rows.Count == 0)
            {
                dtflag = 0;
                dtOtherDetails.Rows.Add(dtOtherDetails.NewRow());
            }
            gvOtherDetails.DataSource = dtOtherDetails;
            gvOtherDetails.DataBind();

            if (dtflag == 0)
            {
                gvOtherDetails.Rows[0].Visible = false;
                dtflag = 0;

            }
            else
            {
                dtflag = 1;
            }


        }
        catch (Exception ex)
        {
        }


    }
    protected void gvOtherDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            var PassportId = (HiddenField)e.Row.FindControl("PassportId");
            var Idnumber = (HiddenField)e.Row.FindControl("hfidno");
            var txtDateOfIssue = (TextBox)e.Row.FindControl("txtDateOfIssue");
            var txtDateOfExpiry = (TextBox)e.Row.FindControl("txtDateOfExpiry");
            if (txtDateOfIssue != null)
            {
                txtDateOfIssue.Attributes.Add("readonly", "readonly");
            }
            if (txtDateOfExpiry != null)
            {
                txtDateOfExpiry.Attributes.Add("readonly", "readonly");
            }
            var lnkbtnUpload = (ImageButton)e.Row.FindControl("lnkbtnUpload");
            if (lnkbtnUpload != null)
            {
                lnkbtnUpload.Attributes.Add("OnClick", "javascript:window.showModalDialog('../HRManagement/EmployeeDocumentMaster.aspx?Id=" + PassportId.Value + "&IdNo=" + Idnumber.Value + "', null, 'status:off;center:yes;scroll:no;dialogWidth:1000px;dialogheight:600px;help:no;');");
            }
            var txtIDNumber = (TextBox)e.Row.FindControl("txtIDNumber");
            var txtIssuingAuthority = (TextBox)e.Row.FindControl("txtIssuingAuthority");
            var txtPlaceofBirth = (TextBox)e.Row.FindControl("txtPlaceofBirth");
            var txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
            if (txtIDNumber != null)
            {
                txtIDNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtIDNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if(txtIssuingAuthority != null){
                  txtIssuingAuthority.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtIssuingAuthority.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if( txtPlaceofBirth != null)
            {
                txtPlaceofBirth.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtPlaceofBirth.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if(txtRemarks != null)
            { txtRemarks.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRemarks.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            var ddlIdType = (DropDownList)e.Row.FindControl("ddlIDType");
            var objHrManagement = new BL.HRManagement();
            var ds = objHrManagement.EmployeeIdTypeGet();
            if (ddlIdType != null)
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
                {
                    ddlIdType.DataSource = ds.Tables[0];
                    ddlIdType.DataTextField = "IDTypeDesc";
                    ddlIdType.DataValueField = "IDTypeCode";
                    ddlIdType.DataBind();
                    ds.Dispose();
                }
                else
                {
                    var li = new ListItem { Text = Resources.Resource.NoDataToShow, Value = "" };
                    ddlIdType.Items.Add(li);
                }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtNewDateOfIssue = (TextBox)e.Row.FindControl("txtNewDateOfIssue");
            var txtNewDateOfExpiry = (TextBox)e.Row.FindControl("txtNewDateOfExpiry");
            if (txtNewDateOfIssue != null)
            {
                txtNewDateOfIssue.Attributes.Add("readonly", "readonly");
            }
            if (txtNewDateOfExpiry != null)
            {
                txtNewDateOfExpiry.Attributes.Add("readonly", "readonly");
            }

            var txtNewIDNumber = (TextBox)e.Row.FindControl("txtNewIDNumber");
            var txtNewIssuingAuthority = (TextBox)e.Row.FindControl("txtNewIssuingAuthority");
            var txtNewPlaceofBirth = (TextBox)e.Row.FindControl("txtNewPlaceofBirth");
            var txtNewRemarks = (TextBox)e.Row.FindControl("txtNewRemarks");
            if (txtNewIDNumber != null)
            {
                txtNewIDNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewIDNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
          }
            if (txtNewRemarks != null)
            {
                txtNewRemarks.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewRemarks.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtNewPlaceofBirth != null)
            {
                txtNewPlaceofBirth.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewPlaceofBirth.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if(txtNewIssuingAuthority!=null)
            {
                 txtNewIssuingAuthority.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewIssuingAuthority.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            var ddlNewIdType = (DropDownList)e.Row.FindControl("ddlNewIDType");
            var objHrManagement = new BL.HRManagement();
            var ds = objHrManagement.EmployeeIdTypeGet();
            if (ddlNewIdType != null)
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
                {
                    ddlNewIdType.DataSource = ds.Tables[0];
                    ddlNewIdType.DataTextField = "IDTypeDesc";
                    ddlNewIdType.DataValueField = "IDTypeCode";
                    ddlNewIdType.DataBind();
                    ds.Dispose();
                }
                else
                {
                    var li = new ListItem { Text = Resources.Resource.NoDataToShow, Value = "" };
                    ddlNewIdType.Items.Add(li);
                }
            }

        }
    }
    /// <summary>
    /// When the control is in edit mode, the rowInEdit variable holds the index of the row being edited,
    /// and the customerInEdit variable holds a reference to a Customer object corresponding to that row.
    /// When the user cancels out of edit mode, this object can be discarded.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvOtherDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        //try
        //{
        //    var dtOtherInfoDetails = new DataTable();
        //    if (ViewState["dtOtherInfoDetails"] != null)
        //    {
        //        dtOtherInfoDetails = (DataTable)ViewState["dtOtherInfoDetails"];
        //    }
        //    if (Status == 0)
        //    {
        //        gvOtherDetails.EditIndex = e.NewEditIndex;
        //        gvOtherDetails.DataSource = dtOtherInfoDetails;
        //        gvOtherDetails.DataBind();
        //    }
        //    else if (Status == 1)
        //    {

        gvOtherDetails.EditIndex = e.NewEditIndex;
        FillgvOtherDetails();
        //    }
        //    ViewState["dtOtherInfoDetails"] = null;
        //    ViewState["dtOtherInfoDetails"] = dtOtherInfoDetails;
        //}
        //catch (Exception EX)
        //{
        //}
    }
    /// <summary>
    /// Handles the OnRowUpdating event of the gvOtherDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvOtherDetails_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var dtOtherInfoDetails = new DataTable();
        if (ViewState["dtOtherInfoDetails"] != null)
        {
            dtOtherInfoDetails = (DataTable)ViewState["dtOtherInfoDetails"];
        }
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var lblIdTypeDesc = (Label)gvOtherDetails.Rows[e.RowIndex].FindControl("lblIDTypeDesc");
        var txtIdNumber = (TextBox)gvOtherDetails.Rows[e.RowIndex].FindControl("txtIDNumber");
        var txtDateOfIssue = (TextBox)gvOtherDetails.Rows[e.RowIndex].FindControl("txtDateOfIssue");
        var txtDateOfExpiry = (TextBox)gvOtherDetails.Rows[e.RowIndex].FindControl("txtDateOfExpiry");
        var txtIssuingAuthority = (TextBox)gvOtherDetails.Rows[e.RowIndex].FindControl("txtIssuingAuthority");
        var txtPlaceofBirth = (TextBox)gvOtherDetails.Rows[e.RowIndex].FindControl("txtPlaceofBirth");
        var txtRemarks = (TextBox)gvOtherDetails.Rows[e.RowIndex].FindControl("txtRemarks");
        var hfIdType = (HiddenField)gvOtherDetails.Rows[e.RowIndex].FindControl("HFIDType");
        if (Status == 0)
        {
            if (txtDateOfIssue.Text != "" && txtDateOfExpiry.Text != "")
            {
                if (DateTime.Parse(txtDateOfIssue.Text) >= DateTime.Parse(txtDateOfExpiry.Text))
                {
                    lblErrorMsgID.Text = Resources.Resource.DateofIssueCannotEqualOrGreaterThanDateOfExpiry; //@"Date Of Issue cannot be Equal To or Greater than Date of Expiry";
                    toolkitScriptManager1.SetFocus(txtDateOfExpiry);
                    return;
                }
                if (txtDateOfBirth.Text != "")
                {
                    if (DateTime.Parse(txtDateOfBirth.Text) > DateTime.Parse(txtDateOfIssue.Text))
                    {
                        lblErrorMsgID.Text = Resources.Resource.DOBCompareDOIssue; //@"Date of Birth cannot be Greater than Date of Issue";
                        return;
                    }
                    if (DateTime.Parse(txtDateOfBirth.Text) > DateTime.Parse(txtDateOfExpiry.Text))
                    {
                        lblErrorMsgID.Text = Resources.Resource.DOBCompareDOIssue; //@"Date of Birth Cannot be greater than Date of Expiry";
                        toolkitScriptManager1.SetFocus(txtDateOfExpiry);
                        return;
                    }
                }
                else
                {
                    lblErrorMsgID.Text = Resources.Resource.DOBBlank; //@"Date of Birth Field is Blank";
                    toolkitScriptManager1.SetFocus(txtDateOfBirth);
                    return;
                }
            }

            dtOtherInfoDetails.Rows[e.RowIndex]["IDNumber"] = txtIdNumber.Text;
            dtOtherInfoDetails.Rows[e.RowIndex]["IDTypeDesc"] = lblIdTypeDesc.Text;
            dtOtherInfoDetails.Rows[e.RowIndex]["IDType"] = hfIdType.Value;
            dtOtherInfoDetails.Rows[e.RowIndex]["DateOfIssue"] = txtDateOfIssue.Text;
            dtOtherInfoDetails.Rows[e.RowIndex]["DateOfExpiry"] = txtDateOfExpiry.Text;
            dtOtherInfoDetails.Rows[e.RowIndex]["IssuingAuthority"] = txtIssuingAuthority.Text;
            dtOtherInfoDetails.Rows[e.RowIndex]["PlaceofBirth"] = txtPlaceofBirth.Text;
            dtOtherInfoDetails.Rows[e.RowIndex]["Remarks"] = txtRemarks.Text;
            gvOtherDetails.EditIndex = -1;
            gvOtherDetails.DataSource = dtOtherInfoDetails;
            gvOtherDetails.DataBind();
        }

        else if (Status == 1)
        {
            var ds = new DataSet();
            var objHrManagement = new BL.HRManagement();

            if (txtDateOfIssue.Text != "" && txtDateOfExpiry.Text != "")
            {
                if (DateTime.Parse(txtDateOfIssue.Text) >= DateTime.Parse(txtDateOfExpiry.Text))
                {
                    lblErrorMsgID.Text = Resources.Resource.DateofIssueCannotEqualOrGreaterThanDateOfExpiry;//@"Date Of Issue cannot be Equal To or Greater than Date of Expiry";
                    toolkitScriptManager1.SetFocus(txtDateOfExpiry);
                    return;
                }
                if (txtDateOfBirth.Text != "")
                {
                    if (DateTime.Parse(txtDateOfBirth.Text) > DateTime.Parse(txtDateOfIssue.Text))
                    {
                        lblErrorMsgID.Text = Resources.Resource.DOBCompareDOIssue;//@"Date of Birth cannot be Greater than Date of Issue";
                        return;
                    }
                    if (DateTime.Parse(txtDateOfBirth.Text) > DateTime.Parse(txtDateOfExpiry.Text))
                    {
                        lblErrorMsgID.Text = Resources.Resource.DOBCompareDOIssue;//@"Date of Birth Cannot be greater than Date of Expiry";
                        toolkitScriptManager1.SetFocus(txtDateOfExpiry);
                        return;
                    }
                }
                else
                {
                    lblErrorMsgID.Text = Resources.Resource.DOBBlank; //@"Date of Birth Field is Blank";
                    toolkitScriptManager1.SetFocus(txtDateOfBirth);
                    return;
                }
            }
            if (txtDateOfIssue.Text != "")
            {
                if (DateTime.Parse(txtDateOfIssue.Text) < DateTime.Today)
                {

                    ds = objHrManagement.EmployeePassportDetailsUpdate(lblEmployeeNumber.Text, txtIdNumber.Text, hfIdType.Value, txtDateOfIssue.Text, txtDateOfExpiry.Text, txtIssuingAuthority.Text, txtPlaceofBirth.Text, txtRemarks.Text, BaseUserID);
                    //Added By  on - 21-Nov-2014 (Bug #1854)
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
                    {
                        DisplayMessage(lblErrorMsgID, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        lblErrorMsgID.Text = lblErrorMsgID.Text + ". " + Resources.Resource.Details + "- " + Resources.Resource.EmployeeNumber + ": " + ds.Tables[0].Rows[0]["GeneratedCode"].ToString() + ", " + Resources.Resource.IDType + ": " + lblIdTypeDesc.Text + ", " + Resources.Resource.IDNumber + ": " + txtIdNumber.Text;
                    }

                }
                else
                { lblErrorMsgID.Text = "Date of Issue Cant be greater than Today's date."; }
            }
            else
            {
                ds = objHrManagement.EmployeePassportDetailsUpdate(lblEmployeeNumber.Text, txtIdNumber.Text, hfIdType.Value, txtDateOfIssue.Text, txtDateOfExpiry.Text, txtIssuingAuthority.Text, txtPlaceofBirth.Text, txtRemarks.Text, BaseUserID);
                //Added By  on - 21-Nov-2014 (Bug #1854)
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
                {
                    DisplayMessage(lblErrorMsgID, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    lblErrorMsgID.Text = lblErrorMsgID.Text + ". " + Resources.Resource.Details + "- " + Resources.Resource.EmployeeNumber + ": " + ds.Tables[0].Rows[0]["GeneratedCode"].ToString() + ", " + Resources.Resource.IDType + ": " + lblIdTypeDesc.Text + ", " + Resources.Resource.IDNumber + ": " + txtIdNumber.Text;
                }
            }
            gvOtherDetails.EditIndex = -1;
            FillgvOtherDetails();
        }
        ViewState["dtOtherInfoDetails"] = null;
        ViewState["dtOtherInfoDetails"] = dtOtherInfoDetails;

    }
    /// <summary>
    /// Handles the OnRowCancelingEdit event of the gvOtherDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvOtherDetails_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        var dtOtherInfoDetails = new DataTable();
        if (ViewState["dtOtherInfoDetails"] != null)
        {
            dtOtherInfoDetails = (DataTable)ViewState["dtOtherInfoDetails"];
        }

        if (Status == 0)
        {
            gvOtherDetails.EditIndex = -1;
            gvOtherDetails.DataSource = dtOtherInfoDetails;
            gvOtherDetails.DataBind();
        }
        else if (Status == 1)
        {
            gvOtherDetails.EditIndex = -1;
            FillgvOtherDetails();
        }

        ViewState["dtOtherInfoDetails"] = null;
        ViewState["dtOtherInfoDetails"] = dtOtherInfoDetails;
    }
    /// <summary>
    /// Handles the OnRowCommand event of the gvOtherDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    /// 

    protected void gvOtherDetails_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

        var objHrManagement = new BL.HRManagement();
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ddlNewIdType = (DropDownList)gvOtherDetails.FooterRow.FindControl("ddlNewIDType");
        var txtNewIdNumber = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewIDNumber");
        var txtNewDateOfIssue = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewDateOfIssue");
        var txtNewDateOfExpiry = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewDateOfExpiry");
        var txtNewIssuingAuthority = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewIssuingAuthority");
        var txtNewPlaceofBirth = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewPlaceofBirth");
        var txtNewRemarks = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewRemarks");
        if (e.CommandName == "AddNew")
        {
            var ds = new DataSet();
            var objHRManagement = new BL.HRManagement();
            if (Status == 0)
            {

                if (txtNewDateOfIssue.Text != "" && txtNewDateOfExpiry.Text != "")
                {
                    if (DateTime.Parse(txtNewDateOfIssue.Text) >= DateTime.Parse(txtNewDateOfExpiry.Text))
                    {
                        lblErrorMsgID.Text = Resources.Resource.DateofIssueCannotEqualOrGreaterThanDateOfExpiry; //@"Date Of Issue cannot be equal to or greater than Date of Expiry";
                        toolkitScriptManager1.SetFocus(txtNewDateOfExpiry);
                        return;
                    }
                    if (txtDateOfBirth.Text != "")
                    {
                        if (DateTime.Parse(txtDateOfBirth.Text) > DateTime.Parse(txtNewDateOfIssue.Text))
                        {
                            lblErrorMsgID.Text = Resources.Resource.DOBCompareDOIssue;//@"Date of Birth cannot be Greater than Date of Issue";
                            return;
                        }
                        if (DateTime.Parse(txtDateOfBirth.Text) > DateTime.Parse(txtNewDateOfExpiry.Text))
                        {
                            lblErrorMsgID.Text = Resources.Resource.DOBCompareDOIssue;//@"Date of Birth Cannot be greater than Date of Expiry";
                            toolkitScriptManager1.SetFocus(txtNewDateOfExpiry);
                            return;
                        }
                    }
                    else
                    {
                        lblErrorMsgID.Text = Resources.Resource.DOBBlank;//@"Date of Birth is Blank";
                        toolkitScriptManager1.SetFocus(txtDateOfBirth);
                        return;
                    }

                }
                if (txtNewDateOfIssue.Text != "")
                {
                    if (DateTime.Parse(txtNewDateOfIssue.Text) < DateTime.Today)
                    {
                        ds = objHRManagement.EmployeePassportDetailInsert(lblEmployeeNumber.Text, txtNewIdNumber.Text, ddlNewIdType.SelectedValue, txtNewDateOfIssue.Text, txtNewDateOfExpiry.Text, txtNewIssuingAuthority.Text, txtNewPlaceofBirth.Text, txtNewRemarks.Text, BaseUserID);

                        //Added By  on - 21-Nov-2014 (Bug #1854)
                        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
                        {
                            DisplayMessage(lblErrorMsgID, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            lblErrorMsgID.Text = lblErrorMsgID.Text + ". " + Resources.Resource.Details + "- " + Resources.Resource.EmployeeNumber + ": " + ds.Tables[0].Rows[0]["GeneratedCode"].ToString() + ", " + Resources.Resource.IDType + ": " + ddlNewIdType.SelectedItem.Text + ", " + Resources.Resource.IDNumber + ": " + txtNewIdNumber.Text;
                            return;
                        }
                    }
                    else
                    { lblErrorMsgID.Text = Resources.Resource.IssueDateCannotEqualOrGreaterThanTodaysDate; }
                }
                else
                {
                    ds = objHRManagement.EmployeePassportDetailInsert(lblEmployeeNumber.Text, txtNewIdNumber.Text, ddlNewIdType.SelectedValue, txtNewDateOfIssue.Text, txtNewDateOfExpiry.Text, txtNewIssuingAuthority.Text, txtNewPlaceofBirth.Text, txtNewRemarks.Text, BaseUserID);

                    //Added By  on - 21-Nov-2014 (Bug #1854)
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
                    {
                        DisplayMessage(lblErrorMsgID, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        lblErrorMsgID.Text = lblErrorMsg.Text + ". " + Resources.Resource.Details + "- " + Resources.Resource.EmployeeNumber + ": " + ds.Tables[0].Rows[0]["GeneratedCode"].ToString() + ", " + Resources.Resource.IDType + ": " + ddlNewIdType.SelectedItem.Text + ", " + Resources.Resource.IDNumber + ": " + txtNewIdNumber.Text;
                        return;
                    }
                }
                FillgvOtherDetails();
            }
            
            else
            {
               
                if (gvOtherDetails.Rows.Count > 0)
                {
                    for (var i = 0; i < gvOtherDetails.Rows.Count; i++)
                    {
                        var hfIdType = (HiddenField)gvOtherDetails.Rows[i].FindControl("HFIDType");
                        if (hfIdType.Value == ddlNewIdType.SelectedValue)
                        {
                            lblErrorMsgID.Text = Resources.Resource.IDTypeExists;
                            toolkitScriptManager1.SetFocus(ddlNewIdType);
                            return;
                        }
                    }

                    if (txtNewDateOfIssue.Text != "" && txtNewDateOfExpiry.Text != "")
                    {
                        if (DateTime.Parse(txtNewDateOfIssue.Text) >= DateTime.Parse(txtNewDateOfExpiry.Text))
                        {
                            lblErrorMsgID.Text = Resources.Resource.DateofIssueCannotEqualOrGreaterThanDateOfExpiry;//@"Date Of Issue cannot be equal to or greater than Date of Expiry";
                            toolkitScriptManager1.SetFocus(txtNewDateOfExpiry);
                            return;
                        }
                        if (txtDateOfBirth.Text != "")
                        {
                            if (DateTime.Parse(txtDateOfBirth.Text) > DateTime.Parse(txtNewDateOfIssue.Text))
                            {
                                lblErrorMsgID.Text = Resources.Resource.DOBCompareDOIssue;//@"Date of Birth cannot be Greater than Date of Issue";
                                return;
                            }
                            if (DateTime.Parse(txtDateOfBirth.Text) > DateTime.Parse(txtNewDateOfExpiry.Text))
                            {
                                lblErrorMsgID.Text = Resources.Resource.DOBCompareDOIssue; //@"Date of Birth Cannot be greater than Date of Expiry";
                                toolkitScriptManager1.SetFocus(txtNewDateOfExpiry);
                                return;
                            }
                        }
                        else
                        {
                            lblErrorMsgID.Text = Resources.Resource.DOBBlank;//@"Date of Birth is Blank";
                            toolkitScriptManager1.SetFocus(txtDateOfBirth);
                            return;
                        }
                    }
                    if (txtNewDateOfIssue.Text != "")
                    {
                        if (DateTime.Parse(txtNewDateOfIssue.Text) < DateTime.Today)
                        {
                            ds = objHRManagement.EmployeePassportDetailInsert(lblEmployeeNumber.Text, txtNewIdNumber.Text, ddlNewIdType.SelectedValue, txtNewDateOfIssue.Text, txtNewDateOfExpiry.Text, txtNewIssuingAuthority.Text, txtNewPlaceofBirth.Text, txtNewRemarks.Text, BaseUserID);

                            //Added By  on - 21-Nov-2014 (Bug #1854)
                            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
                            {
                                DisplayMessage(lblErrorMsgID, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                lblErrorMsgID.Text = lblErrorMsgID.Text + ". " + Resources.Resource.Details + "- " + Resources.Resource.EmployeeNumber + ": " + ds.Tables[0].Rows[0]["GeneratedCode"].ToString() + ", " + Resources.Resource.IDType + ": " + ddlNewIdType.SelectedItem.Text + ", " + Resources.Resource.IDNumber + ": " + txtNewIdNumber.Text;
                                return;
                            }
                        }
                        else
                        { lblErrorMsgID.Text = Resources.Resource.IssueDateCannotEqualOrGreaterThanTodaysDate; }
                    }
                    else
                    {
                        ds = objHRManagement.EmployeePassportDetailInsert(lblEmployeeNumber.Text, txtNewIdNumber.Text, ddlNewIdType.SelectedValue, txtNewDateOfIssue.Text, txtNewDateOfExpiry.Text, txtNewIssuingAuthority.Text, txtNewPlaceofBirth.Text, txtNewRemarks.Text, BaseUserID);

                        //Added By  on - 21-Nov-2014 (Bug #1854)
                        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
                        {
                            DisplayMessage(lblErrorMsgID, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            lblErrorMsgID.Text = lblErrorMsg.Text + ". " + Resources.Resource.Details + "- " + Resources.Resource.EmployeeNumber + ": " + ds.Tables[0].Rows[0]["GeneratedCode"].ToString() + ", " + Resources.Resource.IDType + ": " + ddlNewIdType.SelectedItem.Text + ", " + Resources.Resource.IDNumber + ": " + txtNewIdNumber.Text;
                            return;
                        }
                    }
                    FillgvOtherDetails();
                }
            }
        }

        if (e.CommandName == "Reset")
        {
            txtNewIdNumber.Text = "";
            txtNewDateOfIssue.Text = "";
            txtNewDateOfExpiry.Text = "";
            txtNewIssuingAuthority.Text = "";
            txtNewPlaceofBirth.Text = "";
            txtNewRemarks.Text = "";
        }
    }
    /// <summary>
    /// Handles the OnRowDeleting event of the gvOtherDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvOtherDetails_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var dtOtherInfoDetails = new DataTable();
        if (ViewState["dtOtherInfoDetails"] != null)
        {
            dtOtherInfoDetails = (DataTable)ViewState["dtOtherInfoDetails"];
        }

        var hfIdType = (HiddenField)gvOtherDetails.Rows[e.RowIndex].FindControl("HFIDType");
        var PassportId = (HiddenField)gvOtherDetails.Rows[e.RowIndex].FindControl("PassportId");
        if (Status == 0)
        {

            dtOtherInfoDetails.Rows[e.RowIndex].Delete();
            FillgvOtherDetails();

        }
        else if (Status == 1)
        {
            var ds = new DataSet();
            var objHRManagement = new BL.HRManagement();
            ds = objHRManagement.EmployeePassportDetailsDelete(lblEmployeeNumber.Text, hfIdType.Value,PassportId.Value);
            DisplayMessage(lblErrorMsgID, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvOtherDetails();
        }

        ViewState["dtOtherInfoDetails"] = null;
        ViewState["dtOtherInfoDetails"] = dtOtherInfoDetails;
    }
    protected void lnkbtnUpload_Click(object sender, EventArgs e)
    {
        //GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
        //HiddenField PassportId = (HiddenField)row.FindControl("PassportId");
        //HiddenField Idnumber = (HiddenField)row.FindControl("hfidno");
        //string url = "EmployeeDocumentMaster.aspx?Id=" + PassportId.Value + "&IdNo=" + Idnumber.Value;
        //string s = "window.open('" + url + "', 'ModalPopUp', 'width=1000,height=600,left=100,top=100,resizable=0,location=no,toolbar=no,menubar=no,status=yes');";
        //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
    }
    private void ConvertStringToDateFormat(TextBox txtDate)
    {
        txtDate.BackColor = System.Drawing.Color.Empty;
        var objCommon = new BL.Common();
        var ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (objCommon.IsValidDate(txtDate.Text))
        {
            txtDate.Text = DateTime.Parse(txtDate.Text).ToString("dd-MMM-yyyy");
        }
        else
        {
            var date = objCommon.ConvertToDate(txtDate.Text);
            if (date == "1")
            {
                lblErrorMsg.Text = Resources.Resource.Yearnotincorrectformat; //@"Year not in correct format ";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "2")
            {
                lblErrorMsg.Text = Resources.Resource.Monthnotincorrectformat;//@"Month not in correct format";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "3")
            {
                lblErrorMsg.Text = Resources.Resource.Daynotincorrectformat;//@"Day not in correct format";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "4")
            {
                lblErrorMsg.Text = Resources.Resource.Notaleapyear;//@"Not a leap year";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "5")
            {
                lblErrorMsg.Text = Resources.Resource.Numberofdaysnotcorrect;//@"Number of days not correct";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "6")
            {
                lblErrorMsg.Text = Resources.Resource.Datenotincorrectformat;//@"Date not in correct format";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                txtDate.Text = date;
                txtDate.BackColor = System.Drawing.Color.Empty;
            }
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewDateOfIssue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtNewDateOfIssue_TextChanged(object sender, EventArgs e)
    {
        var ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var txtNewDateOfIssue = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewDateOfIssue");
        var txtNewDateOfExpiry = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewDateOfExpiry");
        ConvertStringToDateFormat(txtNewDateOfIssue);
        ToolkitScriptManager1.SetFocus(txtNewDateOfExpiry);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDateOfIssue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtDateOfIssue_TextChanged(object sender, EventArgs e)
    {
        var ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var objTextBox = (TextBox)sender;
        var row = (GridViewRow)objTextBox.NamingContainer;
        var txtDateOfIssue = (TextBox)gvOtherDetails.Rows[row.RowIndex].FindControl("txtDateOfIssue");
        var txtDateOfExpiry = (TextBox)gvOtherDetails.Rows[row.RowIndex].FindControl("txtDateOfExpiry");
        ConvertStringToDateFormat(txtDateOfIssue);
     
        ToolkitScriptManager1.SetFocus(txtDateOfExpiry);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewDateOfExpiry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtNewDateOfExpiry_TextChanged(object sender, EventArgs e)
    {
        var ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var txtNewDateOfExpiry = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewDateOfExpiry");
        ConvertStringToDateFormat(txtNewDateOfExpiry);
        var txtNewIssuingAuthority = (TextBox)gvOtherDetails.FooterRow.FindControl("txtNewIssuingAuthority");
        ToolkitScriptManager1.SetFocus(txtNewIssuingAuthority);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDateOfExpiry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtDateOfExpiry_TextChanged(object sender, EventArgs e)
    {
        var ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var objTextBox = (TextBox)sender;
        var row = (GridViewRow)objTextBox.NamingContainer;
        var txtDateOfExpiry = (TextBox)gvOtherDetails.Rows[row.RowIndex].FindControl("txtDateOfExpiry");
        ConvertStringToDateFormat(txtDateOfExpiry);
        var txtIssuingAuthority = (TextBox)gvOtherDetails.Rows[row.RowIndex].FindControl("txtIssuingAuthority");
        ToolkitScriptManager1.SetFocus(txtIssuingAuthority);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewRemarks control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtNewRemarks_TextChanged(object sender, EventArgs e)
    {
        var lbADD = (ImageButton)gvOtherDetails.FooterRow.FindControl("lbADD");
        var ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager1.SetFocus(lbADD);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtRemarks control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        var objTextBox = (TextBox)sender;
        var row = (GridViewRow)objTextBox.NamingContainer;
        var ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ImgbtnUpdateTran = (ImageButton)gvOtherDetails.Rows[row.RowIndex].FindControl("ImgbtnUpdateTran");
        ToolkitScriptManager1.SetFocus(ImgbtnUpdateTran);


    }
    //Added By  on 1-Nov-2014 (Bug -#1855)
    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmployeeConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvOtherDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOtherDetails.PageIndex = e.NewPageIndex;
        gvOtherDetails.EditIndex = -1;
        FillgvOtherDetails();
    }
    //End
    #endregion

    #region Function Related to Multilingual Details
    /// <summary>
    /// Handles the Click event of the btnOk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (lblEmployeeNumber.Text != "")
        {
            if (txtOtherLanguageFirstName.Text != HFOtherLanguageFirstName.Value || txtOtherLanguageLastName.Text != HFOtherLanguageLastName.Value)
            {

                var objHRManagement = new BL.HRManagement();
                var ds = objHRManagement.EmployeeMultilingualDetailInsert(lblEmployeeNumber.Text, txtOtherLanguageFirstName.Text, txtOtherLanguageLastName.Text, BaseUserID, BaseCompanyCode);
                HFOtherLanguageFirstName.Value = txtOtherLanguageFirstName.Text;
                HFOtherLanguageLastName.Value = txtOtherLanguageLastName.Text;
            }
        }
        MPEmployeeDetail.Hide();
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        FillMultilingualEmployeeDetails();
    }
    /// <summary>
    /// Handles the Click event of the btnMultilingual control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnMultilingual_Click(object sender, EventArgs e)
    {
        MPEmployeeDetail.Show();
        FillMultilingualEmployeeDetails();
    }
    /// <summary>
    /// Fills the multilingual employee details.
    /// </summary>
    private void FillMultilingualEmployeeDetails()
    {
        var ds = new DataSet();
        var objHRManagement = new BL.HRManagement();
        if (lblEmployeeNumber.Text != "")
        {
            ds = objHRManagement.EmployeeMultilingualDetailGet(lblEmployeeNumber.Text, BaseCompanyCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtOtherLanguageFirstName.Text = ds.Tables[0].Rows[0]["MultiLingualFirstName"].ToString();
                txtOtherLanguageLastName.Text = ds.Tables[0].Rows[0]["MultiLingualLastName"].ToString();
            }
        }
    }
    #endregion

    #region function related to Barred Assignment grid
    /// <summary>
    /// Handles the RowDataBound event of the gvBarredAssignments control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvBarredAssignments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var objGridViewRow = e.Row;
        var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            var serialNo = int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvBarredAssignments.Columns[2].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsDeleteAccess == false)
            {
                var isDeleteAsmt = (ImageButton)e.Row.FindControl("IsDeleteAsmt");
                if (isDeleteAsmt != null)
                {
                    isDeleteAsmt.Visible = false;
                }
            }
            else
            {
                var isDeleteAsmt = (ImageButton)e.Row.FindControl("IsDeleteAsmt");
                if (isDeleteAsmt != null)
                {
                    isDeleteAsmt.Attributes["onclick"] = "javascript:Timerf('" + lblBarredAsmtErrMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
            if (IsWriteAccess)
            {
                var ddlClients = (DropDownList)e.Row.FindControl("ddlClients");
                var ddlAsmt = (DropDownList)e.Row.FindControl("ddlAsmt");
                var hfClientCode = (HiddenField)e.Row.FindControl("HFClientCode");
                var hfEditAsmtCode = (HiddenField)e.Row.FindControl("hfEditAsmtCode");
                var hfBarredBy = (HiddenField)e.Row.FindControl("HFBarredBy");
                var ddlBarredBy = (DropDownList)e.Row.FindControl("ddlBarredBy");
                var ddlReason = (DropDownList)e.Row.FindControl("ddlReason");
                var hfReason = (HiddenField)e.Row.FindControl("HFReason");
                var txtEffectiveTo = (Label)e.Row.FindControl("lblEffectiveTo");
                var txtEffectiveFrom = (Label)e.Row.FindControl("lblEffectiveFrom");
                var isDeleteAsmt = (ImageButton)e.Row.FindControl("IsDeleteAsmt");
                var imgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ddlClients != null)
                {
                    FillddlClient(ddlClients, ddlAsmt);
                    FillddlReason(ddlReason);
                    if (hfClientCode != null)
                    {
                        ddlClients.SelectedValue = hfClientCode.Value;
                        FillAssignment(ddlAsmt, ddlClients);

                        switch (hfEditAsmtCode.Value)
                        {
                            case "":
                                ddlAsmt.SelectedItem.Text = "";
                                break;
                            default:
                                ddlAsmt.SelectedValue = hfEditAsmtCode.Value;
                                break;
                        }

                    }
                }
                if (hfBarredBy != null)
                {
                    if (ddlBarredBy != null)
                    {
                        ddlBarredBy.SelectedValue = hfBarredBy.Value;
                    }
                }
                if (hfReason != null)
                {
                    if (ddlReason != null)
                    {
                        ddlReason.SelectedValue = hfReason.Value;
                    }
                }
                if (txtEffectiveTo != null)
                {
                    if (!String.IsNullOrEmpty(txtEffectiveTo.Text))
                    {
                        if (imgbtnEdit != null)
                        {
                            imgbtnEdit.Visible = false;
                        }
                    }
                    else
                    {
                        if (isDeleteAsmt != null)
                        {
                            isDeleteAsmt.Visible = true;
                        }
                        if (imgbtnEdit != null)
                        {
                            imgbtnEdit.Visible = true;
                        }

                    }
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvBarredAssignments.ShowFooter = false;
            }
            else
            {
                var ddlClients = (DropDownList)e.Row.FindControl("ddlClients");
                var ddlAsmt = (DropDownList)e.Row.FindControl("ddlAsmt");
                var ddlReason = (DropDownList)e.Row.FindControl("ddlReason");

                var imgbtnAddAsmt = (ImageButton)e.Row.FindControl("ImgbtnAddAsmt");
                if (ddlClients != null)
                {
                    FillddlClient(ddlClients, ddlAsmt);
                    FillddlReason(ddlReason);
                    FillAssignment(ddlAsmt, ddlClients);

                }

                if (imgbtnAddAsmt != null)
                {
                    imgbtnAddAsmt.Attributes["onclick"] = "javascript:Timerf('" + lblBarredAsmtErrMsg.ClientID + "');";
                }
            }
        }
    }

    /// <summary>
    /// Handles the OnRowEditing event of the gvBarredAssignments control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvBarredAssignments_OnRowEditing(object sender, GridViewEditEventArgs e)
    {

        gvBarredAssignments.EditIndex = e.NewEditIndex;
        FillgvBarredAssignments(lblEmployeeNumber.Text);

    }
    /// <summary>
    /// Handles the OnRowUpdating event of the gvBarredAssignments control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvBarredAssignments_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        var hfBarredAutoID = (HiddenField)gvBarredAssignments.Rows[e.RowIndex].FindControl("HFBarredAutoID");
        var ddlAsmt = (DropDownList)gvBarredAssignments.Rows[e.RowIndex].FindControl("ddlAsmt");
        var ddlClients = (DropDownList)gvBarredAssignments.Rows[e.RowIndex].FindControl("ddlClients");
        var ddlBarredBy = (DropDownList)gvBarredAssignments.Rows[e.RowIndex].FindControl("ddlBarredBy");
        var txtEffectiveFrom = (TextBox)gvBarredAssignments.Rows[e.RowIndex].FindControl("txtEffectiveFrom");
        var txtEffectiveTo = (TextBox)gvBarredAssignments.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        var ddlReason = (DropDownList)gvBarredAssignments.Rows[e.RowIndex].FindControl("ddlReason");
        var objHrManagement = new BL.HRManagement();

        var ds = new DataSet();
        if (lblEmployeeNumber.Text != "")
        {
            var strAsmtid = ddlAsmt.SelectedValue;
            if (strAsmtid == "")
            {

                lblBarredAsmtErrMsg.Text = Resources.Resource.MsgNothingToSave;
                return;
            }
            if (string.IsNullOrEmpty(ddlReason.SelectedValue))
            {
                lblBarredAsmtErrMsg.Text = Resources.Resource.Select + " " + Resources.Resource.Reason;
                return;
            }
            if (txtEffectiveFrom.Text != "" && txtEffectiveTo.Text != "")
            {
                if (Convert.ToDateTime(txtEffectiveFrom.Text) > Convert.ToDateTime(txtEffectiveTo.Text))
                {
                    Show(Resources.Resource.FromDateCannotGrtToDate);
                    txtEffectiveTo.Focus();
                    return;
                }
            }

            ds = objHrManagement.BarredAssignmentsUpdate(int.Parse(BaseLocationAutoID), lblEmployeeNumber.Text, ddlClients.SelectedValue, strAsmtid, txtEffectiveFrom.Text, txtEffectiveTo.Text, hfBarredAutoID.Value, BaseUserID, ddlBarredBy.SelectedValue, BaseCompanyCode, int.Parse(ddlReason.SelectedValue));

            DisplayMessage(lblBarredAsmtErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            gvBarredAssignments.EditIndex = -1;
            FillgvBarredAssignments(lblEmployeeNumber.Text);
        }



    }
    /// <summary>
    /// Handles the OnRowCancelingEdit event of the gvBarredAssignments control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvBarredAssignments_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvBarredAssignments.EditIndex = -1;
        FillgvBarredAssignments(lblEmployeeNumber.Text);

    }
    /// <summary>
    /// Handles the RowCommand event of the gvBarredAssignments control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvBarredAssignments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        var ddlAsmt = (DropDownList)gvBarredAssignments.FooterRow.FindControl("ddlAsmt");
        var ddlClients = (DropDownList)gvBarredAssignments.FooterRow.FindControl("ddlClients");
        var ddlBarredBy = (DropDownList)gvBarredAssignments.FooterRow.FindControl("ddlBarredBy");
        var txtFooterEffectiveFrom = (TextBox)gvBarredAssignments.FooterRow.FindControl("txtFooterEffectiveFrom");
        var txtFooterEffectiveTo = (TextBox)gvBarredAssignments.FooterRow.FindControl("txtFooterEffectiveTo");
        var ddlReason = (DropDownList)gvBarredAssignments.FooterRow.FindControl("ddlReason");

        if (e.CommandName.Equals("AddNewAsmt"))
        {
            if (lblEmployeeNumber.Text != "")
            {
                var strAsmtid = ddlAsmt.SelectedValue;
                if (strAsmtid == "0")
                {

                    lblBarredAsmtErrMsg.Text = Resources.Resource.MsgNothingToSave;
                    return;
                }
                if (txtFooterEffectiveFrom.Text == "")
                {
                    Show(Resources.Resource.PleaseinputWithEffectiveFromDate);
                    txtFooterEffectiveFrom.Focus();
                    return;
                }
                if (Convert.ToDateTime(Convert.ToDateTime(txtFooterEffectiveFrom.Text).ToString(Resources.Resource.ScheduleDefaultDateFormat)) < Convert.ToDateTime(DateTime.Now.Date.ToString(Resources.Resource.ScheduleDefaultDateFormat)))
                {
                    Show(Resources.Resource.FromDateCannotbelessthanSystemDate);
                    txtFooterEffectiveFrom.Focus();
                    return;
                }

                if (txtFooterEffectiveFrom.Text != "" && txtFooterEffectiveTo.Text != "")
                {
                    if (Convert.ToDateTime(txtFooterEffectiveFrom.Text) > Convert.ToDateTime(txtFooterEffectiveTo.Text))
                    {
                        Show(Resources.Resource.FromDateCannotGrtToDate);
                        txtFooterEffectiveTo.Focus();
                        return;
                    }
                }
                if (string.IsNullOrEmpty(ddlReason.SelectedValue))
                {
                    lblBarredAsmtErrMsg.Text = Resources.Resource.Select + " " + Resources.Resource.Reason;
                    return;
                }
                ds = objHrManagement.BarredAssignmentsInsert(int.Parse(BaseLocationAutoID), lblEmployeeNumber.Text, ddlClients.SelectedValue, strAsmtid, txtFooterEffectiveFrom.Text, txtFooterEffectiveTo.Text, BaseUserID, ddlBarredBy.SelectedValue, BaseCompanyCode, int.Parse(ddlReason.SelectedValue));
                if (gvBarredAssignments.Rows.Count.Equals(gvBarredAssignments.PageSize))
                {
                    gvBarredAssignments.PageIndex = gvBarredAssignments.PageCount + 1;
                }

                FillgvBarredAssignments(lblEmployeeNumber.Text);
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "62")
                {
                    Show(Resources.Resource.ScheduleExistsForTheEmp);
                    return;
                }
                DisplayMessage(lblBarredAsmtErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                Response.Redirect("../HRManagement/EmployeeDetail.aspx");
            }

        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtFooterEffectiveFrom.Text = "";
            txtFooterEffectiveTo.Text = "";
            lblBarredAsmtErrMsg.Text = "";
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvBarredAssignments control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvBarredAssignments_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        var hfBarredAutoID = (HiddenField)gvBarredAssignments.Rows[e.RowIndex].FindControl("HFBarredAutoID");

        ds = objHrManagement.BarredAssignmentsDelete(BaseCompanyCode, int.Parse(BaseLocationAutoID), lblEmployeeNumber.Text, hfBarredAutoID.Value);
        FillgvBarredAssignments(lblEmployeeNumber.Text);
        DisplayMessage(lblBarredAsmtErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    /// <param name="ddlClients">The DDL clients.</param>
    /// <param name="ddlAsmt">The DDL asmt.</param>
    private void FillddlClient(DropDownList ddlClients, DropDownList ddlAsmt)
    {

        var objSale = new BL.Sales();
        var ds = new DataSet();
        ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);
        ddlClients.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClients.DataSource = ds.Tables[0];

            ddlClients.DataTextField = "ClientCodeName";
            ddlClients.DataValueField = "ClientCode";
            ddlClients.DataBind();
        }
    }
    protected void txtFooterEffectiveFrom_TextChanged(object sender, EventArgs e)
    {
        var txtFooterEffectiveFrom = (TextBox)sender;
        ConvertStringToDateFormat(txtFooterEffectiveFrom);
        var txtFooterEffectiveTo = (TextBox)gvBarredAssignments.FooterRow.FindControl("txtFooterEffectiveTo");
        if (txtFooterEffectiveTo.Text != "")
        {
            if (DateTime.Parse(txtFooterEffectiveFrom.Text) > DateTime.Parse(txtFooterEffectiveTo.Text))
            {
                if (Master != null)
                {
                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("toolkitScriptManager1");
                    Show(Resources.Resource.FromDateCannotGrtToDate);
                    toolkitScriptManager1.SetFocus(txtFooterEffectiveFrom);
                }
                txtFooterEffectiveFrom.BackColor = System.Drawing.Color.Aqua;
                return;
            }
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtFooterEffectiveTo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtFooterEffectiveTo_TextChanged(object sender, EventArgs e)
    {
        var txtFooterEffectiveTo = (TextBox)sender;
        ConvertStringToDateFormat(txtFooterEffectiveTo);

        var txtFooterEffectiveFrom = (TextBox)gvBarredAssignments.FooterRow.FindControl("txtFooterEffectiveFrom");

        if (txtFooterEffectiveTo.Text != "" && txtFooterEffectiveFrom.Text != "")
        {
            if (DateTime.Parse(txtFooterEffectiveFrom.Text) > DateTime.Parse(txtFooterEffectiveTo.Text))
            {
                if (Master != null)
                {
                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("toolkitScriptManager1");
                    Show(Resources.Resource.FromDateCannotGrtToDate);
                    toolkitScriptManager1.SetFocus(txtFooterEffectiveFrom);
                }
                txtFooterEffectiveTo.BackColor = System.Drawing.Color.Aqua;
                return;
            }
        }

    }

    /// <summary>
    /// Handles the TextChanged event of the txtEffectiveFrom control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtEffectiveFrom_TextChanged(object sender, EventArgs e)
    {
        var txtEffectiveFrom = (TextBox)sender;
        ConvertStringToDateFormat(txtEffectiveFrom);
        var Row = (GridViewRow)txtEffectiveFrom.NamingContainer;
        var txtEffectiveTo = (TextBox)gvBarredAssignments.Rows[Row.RowIndex].FindControl("txtEffectiveTo");
        if (txtEffectiveTo.Text != "")
        {
            if (DateTime.Parse(txtEffectiveFrom.Text) > DateTime.Parse(txtEffectiveTo.Text))
            {
                if (Master != null)
                {
                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("toolkitScriptManager1");
                    Show(Resources.Resource.FromDateCannotGrtToDate);
                    toolkitScriptManager1.SetFocus(txtEffectiveFrom);
                }
                txtEffectiveFrom.BackColor = System.Drawing.Color.Aqua;
                return;
            }
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtEffectiveTo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtEffectiveTo_TextChanged(object sender, EventArgs e)
    {
        var txtEffectiveTo = (TextBox)sender;
        ConvertStringToDateFormat(txtEffectiveTo);
        var Row = (GridViewRow)txtEffectiveTo.NamingContainer;
        var txtEffectiveFrom = (TextBox)gvBarredAssignments.Rows[Row.RowIndex].FindControl("txtEffectiveFrom");

        if (txtEffectiveTo.Text != "" && txtEffectiveFrom.Text != "")
        {
            if (DateTime.Parse(txtEffectiveFrom.Text) > DateTime.Parse(txtEffectiveTo.Text))
            {
                if (Master != null)
                {
                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("toolkitScriptManager1");
                    Show(Resources.Resource.FromDateCannotGrtToDate);
                    toolkitScriptManager1.SetFocus(txtEffectiveTo);
                }
                txtEffectiveTo.BackColor = System.Drawing.Color.Aqua;
                return;
            }
        }
    }

    private void FillddlReason(DropDownList ddlReason)
    {
        var objMasters = new BL.MastersManagement();
        var ds = objMasters.BarredReasonMasterGetAll(BaseCompanyCode);
        ddlReason.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlReason.DataSource = ds.Tables[0];
            ddlReason.DataTextField = "ReasonDesc";
            ddlReason.DataValueField = "ReasonAutoID";
            ddlReason.DataBind();
        }

    }


    /// <summary>
    /// Fills the assignment.
    /// </summary>
    /// <param name="ddlAsmt">The DDL asmt.</param>
    /// <param name="ddlClients">The DDL clients.</param>
    private void FillAssignment(DropDownList ddlAsmt, DropDownList ddlClients)
    {
        var objOperationManagement = new BL.OperationManagement();
        var dsAsmt = new DataSet();
        ddlAsmt.Items.Clear();
        if (ddlClients.SelectedValue == "ALL")
        {
            var li = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmt.Items.Insert(0, li);
            return;
        }
        dsAsmt = objOperationManagement.PreferanceAssignmentsOfClientGet(int.Parse(BaseLocationAutoID), ddlClients.SelectedValue, "1/1/1900", "1/1/2099", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");

        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmt.DataSource = dsAsmt.Tables[0];
            ddlAsmt.DataTextField = "AsmtDetail";
            ddlAsmt.DataValueField = "AsmtID";
            ddlAsmt.DataBind();
            var li = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmt.Items.Insert(0, li);
        }
        else
        {
            var li = new ListItem
                              {
                                  Text = Resources.Resource.NoData,
                                  Value = @"0"
                              };
            ddlAsmt.Items.Add(li);
        }
    }


    /// <summary>
    /// Fillddls the client prefrences.
    /// </summary>
    /// <param name="ddlClients">The DDL clients.</param>
    /// <param name="ddlAsmt">The DDL asmt.</param>
    private void FillddlClientPrefrences(DropDownList ddlClients, DropDownList ddlAsmt)
    {

        var objSale = new BL.Sales();
        var ds = new DataSet();
        ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);
        ddlClients.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClients.DataSource = ds.Tables[0];
            ddlClients.DataTextField = "ClientCodeName";
            ddlClients.DataValueField = "ClientCode";
            ddlClients.DataBind();
        }
    }
    //Manish 14-08-2012 No all option 
    /// <summary>
    /// Fills the assignment prefrences.
    /// </summary>
    /// <param name="ddlAsmt">The DDL asmt.</param>
    /// <param name="ddlClients">The DDL clients.</param>
    private void FillAssignmentPrefrences(DropDownList ddlAsmt, DropDownList ddlClients)
    {
        var objOperationManagement = new BL.OperationManagement();
        var dsAsmt = new DataSet();
        ddlAsmt.Items.Clear();

        if (ddlClients.SelectedValue == @"ALL")
        {
            var li = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmt.Items.Insert(0, li);
            return;
        }
        dsAsmt = objOperationManagement.PreferanceAssignmentsOfClientGet(int.Parse(BaseLocationAutoID), ddlClients.SelectedValue, "1/1/1900", "1/1/2099", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");

        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmt.DataSource = dsAsmt.Tables[0];
            ddlAsmt.DataTextField = "AsmtDetail";
            ddlAsmt.DataValueField = "AsmtID";
            ddlAsmt.DataBind();
            var li1 = new ListItem { Text = Resources.Resource.Select, Value = @"0" };
            ddlAsmt.Items.Insert(0, li1);

            var li = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmt.Items.Insert(1, li);
        }
        else
        {
            var li = new ListItem
                         {
                             Text = Resources.Resource.NoData,
                             Value = @"0"
                         };
            ddlAsmt.Items.Add(li);
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlFooterClients control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlFooterClients_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlAsmt = (DropDownList)gvBarredAssignments.FooterRow.FindControl("ddlAsmt");
        var ddlClients = (DropDownList)gvBarredAssignments.FooterRow.FindControl("ddlClients");
        ddlAsmt.Items.Clear();
        if (ddlClients.SelectedItem.Value != @"ALL")
        {

            var objOperationManagement = new BL.OperationManagement();
            var dsAsmt = objOperationManagement.PreferanceAssignmentsOfClientGet(int.Parse(BaseLocationAutoID), ddlClients.SelectedValue, "1/1/1900", "1/1/2020", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
            if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
            {

                ddlAsmt.DataSource = dsAsmt;
                ddlAsmt.DataTextField = "AsmtDetail";
                ddlAsmt.DataValueField = "AsmtID";
                ddlAsmt.DataBind();
                var li1 = new ListItem { Text = Resources.Resource.Select, Value = @"0" };
                ddlAsmt.Items.Insert(0, li1);
                var li = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };
                ddlAsmt.Items.Insert(1, li);

            }
            else
            {
                var li1 = new ListItem { Text = Resources.Resource.NoDataToShow, Value = @"0" };
                ddlAsmt.Items.Insert(0, li1);

            }
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClients control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
    {
        var objDropDownList = (DropDownList)sender;
        var Row = (GridViewRow)objDropDownList.NamingContainer;
        var ddlAsmt = (DropDownList)gvBarredAssignments.Rows[Row.RowIndex].FindControl("ddlAsmt");
        var ddlClients = (DropDownList)gvBarredAssignments.Rows[Row.RowIndex].FindControl("ddlClients");
        ddlAsmt.Items.Clear();


        if (ddlClients.SelectedItem.Value != @"ALL")
        {
            var objOperationManagement = new BL.OperationManagement();
            var dsAsmt = objOperationManagement.PreferanceAssignmentsOfClientGet(int.Parse(BaseLocationAutoID), ddlClients.SelectedValue, "1/1/1900", "1/1/2020", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
            if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
            {
                ddlAsmt.DataSource = dsAsmt;
                ddlAsmt.DataTextField = "Address";
                ddlAsmt.DataValueField = "AsmtID";
                ddlAsmt.DataBind();
                var li = new ListItem { Text = Resources.Resource.Select, Value = @"0" };

                ddlAsmt.Items.Insert(0, li);

                var li1 = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };

                ddlAsmt.Items.Insert(1, li1);
            }
            else
            {
                var li1 = new ListItem { Text = Resources.Resource.NoDataToShow, Value = @"ALL" };

                ddlAsmt.Items.Insert(0, li1);

            }
        }

    }


    #endregion

    #region Function To Fill Barred Assignments Grid

    /// <summary>
    /// Fill Barred Assignment Gridon the basis of EMployee
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    private void FillgvBarredAssignments(string strEmployeeNumber)
    {

        var objHrManagement = new BL.HRManagement();
        var ds = new DataSet();
        var dtflag1 = 1;
        ds = objHrManagement.BarredAssignmentsGet(BaseCompanyCode, int.Parse(BaseLocationAutoID), strEmployeeNumber);

        if (ds.Tables[0].Rows.Count == 0)
        {
            dtflag1 = 0;
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        }

        gvBarredAssignments.DataSource = ds.Tables[0];
        gvBarredAssignments.DataBind();

        if (dtflag1 == 0)
        {
            gvBarredAssignments.Rows[0].Visible = false;
        }

    }

    #endregion

    

    #region Function related to Employee Preference
    protected void gvEmployeePreferances_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvEmployeePreferances.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsDeleteAccess == false)
            {
                var IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                }
            }
            else
            {
                var IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblEmployeePreferances.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
            if (IsWriteAccess)
            {
                var ddlEmpPrefClients = (DropDownList)e.Row.FindControl("ddlEmpPrefClients");
                var ddlEmpPrefAsmtCode = (DropDownList)e.Row.FindControl("ddlEmpPrefAsmtCode");
                var ddlShiftPref = (DropDownList)e.Row.FindControl("ddlShiftPref");
                var HFClientCode = (HiddenField)e.Row.FindControl("HFClientCode");
                var hfAsmtCode = (HiddenField)e.Row.FindControl("hfAsmtCode");
                var HFShiftPrefCode = (HiddenField)e.Row.FindControl("HFShiftPrefCode");
                if (ddlEmpPrefClients != null)
                {
                    FillddlClientPrefrences(ddlEmpPrefClients, ddlEmpPrefAsmtCode);
                    if (HFClientCode != null)
                    {
                        ddlEmpPrefClients.SelectedValue = HFClientCode.Value;
                        FillAssignmentPrefrences(ddlEmpPrefAsmtCode, ddlEmpPrefClients);//Manish
                        ddlEmpPrefAsmtCode.SelectedValue = hfAsmtCode.Value;
                        ddlShiftPref.SelectedValue = HFShiftPrefCode.Value;

                    }
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvEmployeePreferances.ShowFooter = false;
            }
            else
            {
                var ddlFooterEmpPrefClients = (DropDownList)e.Row.FindControl("ddlFooterEmpPrefClients");
                var ddlFooterEmpPrefAsmtCode = (DropDownList)e.Row.FindControl("ddlFooterEmpPrefAsmtCode");

                var ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ddlFooterEmpPrefClients != null)
                {
                    FillddlClientPrefrences(ddlFooterEmpPrefClients, ddlFooterEmpPrefAsmtCode);
                    FillAssignmentPrefrences(ddlFooterEmpPrefAsmtCode, ddlFooterEmpPrefClients);//Manish
                }

                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblEmployeePreferances.ClientID + "');";
                }

                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
            }
        }
    }

    /// <summary>
    /// Handles the OnRowEditing event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeePreferances_OnRowEditing(object sender, GridViewEditEventArgs e)
    {

        gvEmployeePreferances.EditIndex = e.NewEditIndex;
        FillgvEmployeePreferances(lblEmployeeNumber.Text);

    }
    /// <summary>
    /// Handles the RowUpdating event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeePreferances_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        var hfAsmtCode = (HiddenField)gvEmployeePreferances.Rows[e.RowIndex].FindControl("hfAsmtCode");
        var ddlShiftPref = (DropDownList)gvEmployeePreferances.Rows[e.RowIndex].FindControl("ddlShiftPref");

        var CBSun = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBSun");
        var CBMon = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBMon");
        var CBTue = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBTue");
        var CBWed = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBWed");
        var CBThu = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBThu");
        var CBFri = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBFri");
        var CBSat = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBSat");

        var CBDaysPref = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBDaysPref");
        var CBShiftTimePref = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBShiftTimePref");
        var CBSitePref = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBSitePref");

        var CBAlertSitePref = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBAlertSitePref");
        var CBAlertShiftTimePref = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBAlertShiftTimePref");
        var CBAlertDaysPref = (CheckBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("CBAlertDaysPref");
        var txtTimeFrom = (TextBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("txtTimeFrom");
        var txtTimeTo = (TextBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("txtTimeTo");

        var txtMaxShft = (TextBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("txtMaxShft");
        var txtMinShft = (TextBox)gvEmployeePreferances.Rows[e.RowIndex].FindControl("txtMinShft");

        var ddlEmpPrefClients = (DropDownList)gvEmployeePreferances.Rows[e.RowIndex].FindControl("ddlEmpPrefClients");

        var strTimeFrom = string.Empty;
        var strTimeTo = string.Empty;
        const bool DaysPref = true;
        const bool ShiftTimePref = true;
        const bool SitePref = true;
        const bool AlertSitePref = true;
        const bool AlertShiftTimePref = true;
        const bool AlertDaysPref = true;
        if (CBDaysPref == null || CBShiftTimePref == null || CBSitePref == null || CBAlertSitePref == null || CBAlertShiftTimePref == null || CBAlertDaysPref == null || txtTimeFrom == null || txtTimeTo == null || txtMaxShft == null || txtMinShft == null)
        {
            strTimeFrom = "01-01-1900" + " " + "12:00";
            strTimeTo = "01-01-1900" + " " + "12:00";
            if (txtMaxShft != null && string.IsNullOrEmpty(txtMaxShft.Text))
            { txtMaxShft.Text = @"1"; }
            if (txtMinShft != null && string.IsNullOrEmpty(txtMinShft.Text))
            {
                txtMinShft.Text = @"0";
            }
        }
        else
        {
            strTimeFrom = "01-01-1900" + " " + txtTimeFrom.Text;
            strTimeTo = "01-01-1900" + " " + txtTimeTo.Text;
        }
        if (txtMaxShft != null && string.IsNullOrEmpty(txtMaxShft.Text))
        { txtMaxShft.Text = @"1"; }
        if (txtMinShft != null && string.IsNullOrEmpty(txtMinShft.Text))
        {
            txtMinShft.Text = @"0";
        }
        if (txtMaxShft != null && (txtMinShft != null && int.Parse(txtMinShft.Text) >= int.Parse(txtMaxShft.Text)))
        {
            lblEmployeePreferances.Text = Resources.Resource.MsgShiftMinUnitShouldBeLessThanMaxUnit;
            return;
        }
        if (DateTime.Parse(strTimeFrom) <= DateTime.Parse(strTimeTo))
        {
            if (txtMinShft != null)
                if (txtMaxShft != null)
                    ds = objHrManagement.EmployeePreferencesUpdate(BaseLocationAutoID, lblEmployeeNumber.Text, hfAsmtCode.Value, ddlShiftPref.SelectedValue, CBSun.Checked, CBMon.Checked, CBTue.Checked, CBWed.Checked, CBThu.Checked, CBFri.Checked, CBSat.Checked, DateTime.Parse(strTimeFrom), DateTime.Parse(strTimeTo), DaysPref, ShiftTimePref, SitePref, AlertSitePref, AlertShiftTimePref, AlertDaysPref, BaseUserID, txtMinShft.Text, txtMaxShft.Text, ddlEmpPrefClients.SelectedValue);
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())))
            {
                gvEmployeePreferances.EditIndex = -1;
                FillgvEmployeePreferances(lblEmployeeNumber.Text);

            }
            DisplayMessage(lblEmployeePreferances, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else
        {
            lblEmployeePreferances.Text = Resources.Resource.FromTimeShouldBeLessThanToTime;
        }



    }
    /// <summary>
    /// Handles the OnRowCancelingEdit event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeePreferances_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvEmployeePreferances.EditIndex = -1;
        FillgvEmployeePreferances(lblEmployeeNumber.Text);

    }
    /// <summary>
    /// Handles the RowCommand event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeePreferances_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddNew")
        {
            var ds = new DataSet();
            var objHrManagement = new BL.HRManagement();
            var ddlFooterEmpPrefAsmtCode = (DropDownList)gvEmployeePreferances.FooterRow.FindControl("ddlFooterEmpPrefAsmtCode");
            var ddlFooterShiftPref = (DropDownList)gvEmployeePreferances.FooterRow.FindControl("ddlFooterShiftPref");
            var txtFooterTimeFrom = (TextBox)gvEmployeePreferances.FooterRow.FindControl("txtFooterTimeFrom");
            var txtFooterTimeTo = (TextBox)gvEmployeePreferances.FooterRow.FindControl("txtFooterTimeTo");
            var CBSun = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBSun");
            var CBMon = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBMon");
            var CBTue = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBTue");
            var CBWed = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBWed");
            var CBThu = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBThu");
            var CBFri = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBFri");
            var CBSat = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBSat");
            var CBDaysPref = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBDaysPref");
            var CBShiftTimePref = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBShiftTimePref");
            var CBSitePref = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBSitePref");
            var CBAlertSitePref = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBAlertSitePref");
            var CBAlertShiftTimePref = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBAlertShiftTimePref");
            var CBAlertDaysPref = (CheckBox)gvEmployeePreferances.FooterRow.FindControl("CBAlertDaysPref");

            var txtMaxShft = (TextBox)gvEmployeePreferances.FooterRow.FindControl("txtMaxShft");
            var txtMinShft = (TextBox)gvEmployeePreferances.FooterRow.FindControl("txtMinShft");

            var ddlFooterEmpPrefClients = (DropDownList)gvEmployeePreferances.FooterRow.FindControl("ddlFooterEmpPrefClients");

            var strTimeFrom = string.Empty;
            var strTimeTo = string.Empty;
            var DaysPref = true;
            var ShiftTimePref = true;
            var SitePref = true;
            var AlertSitePref = true;
            var AlertShiftTimePref = true;
            var AlertDaysPref = true;
            if (CBDaysPref == null || CBShiftTimePref == null || CBSitePref == null || CBAlertSitePref == null || CBAlertShiftTimePref == null || CBAlertDaysPref == null || txtFooterTimeFrom == null || txtFooterTimeTo == null || txtMinShft == null || txtMaxShft == null || ddlFooterEmpPrefClients == null)
            {

                strTimeFrom = "01-01-1900" + " " + "12:00";
                strTimeTo = "01-01-1900" + " " + "12:00";
                if (txtMaxShft != null && txtMaxShft.Text == "")
                { txtMaxShft.Text = @"1"; }
                if (txtMinShft != null && txtMinShft.Text == "")
                {
                    txtMinShft.Text = @"0";
                }
            }
            else
            {
                strTimeFrom = "01-01-1900" + " " + txtFooterTimeFrom.Text;
                strTimeTo = "01-01-1900" + " " + txtFooterTimeTo.Text;
            }
            if (txtMaxShft != null && txtMaxShft.Text == "")
            { txtMaxShft.Text = @"1"; }
            if (txtMinShft != null && txtMinShft.Text == "")
            {
                txtMinShft.Text = @"0";
            }
            if (txtMaxShft != null && (txtMinShft != null && int.Parse(txtMinShft.Text) >= int.Parse(txtMaxShft.Text)))
            {
                lblEmployeePreferances.Text = Resources.Resource.MsgShiftMinUnitShouldBeLessThanMaxUnit;
                return;
            }
            if (DateTime.Parse(strTimeFrom) <= DateTime.Parse(strTimeTo))
            {
                if (ddlFooterEmpPrefClients != null && ddlFooterEmpPrefClients.SelectedValue == "0")
                {
                    lblEmployeePreferances.Text = Resources.Resource.SelectClient;
                    return;
                }
                if (ddlFooterEmpPrefAsmtCode.SelectedValue != "0")
                {
                    if (txtMinShft != null)
                        if (txtMaxShft != null)
                            if (ddlFooterEmpPrefClients != null)
                                ds = objHrManagement.EmployeePreferencesInsert(BaseLocationAutoID, lblEmployeeNumber.Text, ddlFooterEmpPrefAsmtCode.SelectedValue, ddlFooterShiftPref.SelectedValue, CBSun.Checked, CBMon.Checked, CBTue.Checked, CBWed.Checked, CBThu.Checked, CBFri.Checked, CBSat.Checked, DateTime.Parse(strTimeFrom), DateTime.Parse(strTimeTo), DaysPref, ShiftTimePref, SitePref, AlertSitePref, AlertShiftTimePref, AlertDaysPref, BaseUserID, txtMinShft.Text, txtMaxShft.Text, ddlFooterEmpPrefClients.SelectedValue);
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())))
                    {

                        FillgvEmployeePreferances(lblEmployeeNumber.Text);
                    }
                    DisplayMessage(lblEmployeePreferances, ds.Tables[0].Rows[0]["MessageID"].ToString());

                }
                else
                {
                    lblEmployeePreferances.Text = Resources.Resource.SelectAssignment;
                }
            }
            else
            {
                lblEmployeePreferances.Text = Resources.Resource.FromTimeShouldBeLessThanToTime;
            }
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeePreferances_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();

        var hfAsmtCode = (HiddenField)gvEmployeePreferances.Rows[e.RowIndex].FindControl("hfAsmtCode");

        var HFClientCode = (HiddenField)gvEmployeePreferances.Rows[e.RowIndex].FindControl("HFClientCode");

        ds = objHrManagement.EmployeePreferencesDelete(hfAsmtCode.Value, lblEmployeeNumber.Text, BaseLocationAutoID, HFClientCode.Value);
        gvEmployeePreferances.EditIndex = -1;
        FillgvEmployeePreferances(lblEmployeeNumber.Text);
        DisplayMessage(lblBarredAsmtErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlFooterEmpPrefClients control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlFooterEmpPrefClients_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlFooterEmpPrefAsmtCode = (DropDownList)gvEmployeePreferances.FooterRow.FindControl("ddlFooterEmpPrefAsmtCode");
        var ddlFooterEmpPrefClients = (DropDownList)gvEmployeePreferances.FooterRow.FindControl("ddlFooterEmpPrefClients");
        FillAssignmentPrefrences(ddlFooterEmpPrefAsmtCode, ddlFooterEmpPrefClients);
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlFooterEmpPrefAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlFooterEmpPrefAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlFooterEmpPrefAsmtCode = (DropDownList)gvEmployeePreferances.FooterRow.FindControl("ddlFooterEmpPrefAsmtCode");
        var ddlFooterEmpPrefClients = (DropDownList)gvEmployeePreferances.FooterRow.FindControl("ddlFooterEmpPrefClients");
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlAsmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlAsmt = (DropDownList)gvBarredAssignments.FooterRow.FindControl("ddlAsmt");
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmpPrefClients control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlEmpPrefClients_SelectedIndexChanged(object sender, EventArgs e)
    {
        var objDropDownList = (DropDownList)sender;
        var Row = (GridViewRow)objDropDownList.NamingContainer;
        var ddlEmpPrefAsmtCode = (DropDownList)gvEmployeePreferances.Rows[Row.RowIndex].FindControl("ddlEmpPrefAsmtCode");
        var ddlEmpPrefClients = (DropDownList)gvEmployeePreferances.Rows[Row.RowIndex].FindControl("ddlEmpPrefClients");

        if (ddlEmpPrefClients.SelectedValue == "ALL")
        {
            var li = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };

            ddlEmpPrefAsmtCode.Items.Insert(0, li);
            return;
        }
        var objOperationManagement = new BL.OperationManagement();
        ddlEmpPrefAsmtCode.DataSource = objOperationManagement.PreferanceAssignmentsOfClientGet(int.Parse(BaseLocationAutoID), ddlEmpPrefClients.SelectedValue, "1/1/1900", "1/1/2020", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
        ddlEmpPrefAsmtCode.DataTextField = "AsmtAddress";
        ddlEmpPrefAsmtCode.DataValueField = "AsmtID";
        ddlEmpPrefAsmtCode.DataBind();
        var li1 = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };
        ddlEmpPrefAsmtCode.Items.Insert(0, li1);
        return;
    }
    /// <summary>
    /// Fillgvs the employee preferances.
    /// </summary>
    /// <param name="strEmployeeNumber">The string employee number.</param>
    /// 
  
    
    private void FillgvEmployeePreferances(string strEmployeeNumber)
    {

        var objHrManagement = new BL.HRManagement();
        var objMastersManagement = new BL.MastersManagement();
        var ds = new DataSet();
        int dtflag;
        dtflag = 1;
        ds = objHrManagement.EmployeePreferencesGetAll(int.Parse(BaseLocationAutoID), strEmployeeNumber, BaseCompanyCode);
        if (ds.Tables[0].Rows.Count == 0)
        {
            dtflag = 0;
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        }

        gvEmployeePreferances.DataSource = ds.Tables[0];
        gvEmployeePreferances.DataBind();
        try
        {
            var lblClientName = (Label)gvEmployeePreferances.Rows[0].FindControl("lblClientName");
            if (lblClientName.Text == "")
            {
                gvEmployeePreferances.Rows[0].Visible = false;
            }
        }
        catch (Exception)
        {
            lblEmployeeEmployeePreferances.Text = Resources.Resource.ErrorMessage;
        }
        if (dtflag == 0)
        {
            gvEmployeePreferances.Rows[0].Visible = false;
        }

    }
    #endregion

    #region Function Related Employee Constraint

    #region GridView Commands Events

    /// <summary>
    /// Handles the RowDataBound event of the gvEmployeeConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeConstraint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            var serialNo = gvEmployeeConstraint.PageIndex * gvEmployeeConstraint.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvEmployeeConstraint.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                var ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                var ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    if (lblEmployeeNumber.Text == "")
                    {
                        ImgbtnUpdate.Visible = false;
                    }
                }
                var txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";

                }
                var txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
                if (txtRemarks != null)
                {
                    txtRemarks.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtRemarks.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                var ddlConstraintType = (DropDownList)e.Row.FindControl("ddlConstraintType");
                if (ddlConstraintType != null)
                {
                    ddlConstraintType.Attributes["readonly"] = "readonly";
                    var ddlConstraintDesc = (DropDownList)e.Row.FindControl("ddlConstraintDesc");
                    if (ddlConstraintDesc != null)
                    {
                        var HFConstraintTypeAutoID = (HiddenField)e.Row.FindControl("HFConstraintTypeAutoID");
                        var HFConstraintCode = (HiddenField)e.Row.FindControl("HFConstraintCode");
                        var HFConstraintAutoID = (HiddenField)e.Row.FindControl("HFConstraintAutoID");
                        var ddlValue = (DropDownList)e.Row.FindControl("ddlValue");
                        FillddlConstraintType(ddlConstraintType, ddlConstraintDesc, HFConstraintTypeAutoID, HFConstraintCode, txtValue, ddlValue);
                        ddlValue.SelectedValue = HFConstraintAutoID.Value;
                    }


                }


            }
            if (IsDeleteAccess == false)
            {
                var ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Visible = false; }
            }
            else
            {
                var ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    if (lblEmployeeNumber.Text == "")
                    {
                        ImgbtnDelete.Visible = false;
                    }
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";

                }

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvEmployeeConstraint.ShowFooter = false;
            }
            else
            {
                var ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }


                var txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                var ddlConstraintType = (DropDownList)e.Row.FindControl("ddlConstraintType");
                if (ddlConstraintType != null)
                {
                    ddlConstraintType.Attributes["readonly"] = "readonly";
                    var ddlConstraintDesc = (DropDownList)e.Row.FindControl("ddlConstraintDesc");
                    if (ddlConstraintDesc != null)
                    {
                        var HFConstraintTypeAutoID = (HiddenField)e.Row.FindControl("HFConstraintTypeAutoID");
                        var HFConstraintCode = (HiddenField)e.Row.FindControl("HFConstraintCode");
                        var ddlValue = (DropDownList)e.Row.FindControl("ddlValue");
                        FillddlConstraintType(ddlConstraintType, ddlConstraintDesc, HFConstraintTypeAutoID, HFConstraintCode, txtValue, ddlValue);
                    }


                }

            }
        }

    }

    /// <summary>
    /// Handles the RowCommand event of the gvEmployeeConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeConstraint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objHRManagement = new BL.HRManagement();
        var ds = new DataSet();
        var ddlConstraintType = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlConstraintType");
        var ddlConstraintDesc = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlConstraintDesc");
        var txtValue = (TextBox)gvEmployeeConstraint.FooterRow.FindControl("txtValue");
        var ddlValue = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlValue");
        var txtRemarks = (TextBox)gvEmployeeConstraint.FooterRow.FindControl("txtRemarks");
        if (e.CommandName == "Add")
        {
            if (txtValue.Style["display"] == "block")
            {
                if (txtValue.Text != "")
                {
                    ds = objHRManagement.EmployeeConstraintInsert(BaseCompanyCode, lblEmployeeNumber.Text, ddlConstraintType.SelectedValue, ddlConstraintDesc.SelectedValue, txtValue.Text, txtRemarks.Text, BaseUserID);
                    gvEmployeeConstraint.EditIndex = -1;
                    FillgvEmployeeConstraint();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    { DisplayMessage(lblEmpConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                }
                else
                {
                    lblEmpConstraintErrorMsg.Text = Resources.Resource.ValueCannotbeBlank; //@"Value field cannot be left blank ! ";
                }
            }
            else
            {
                ds = objHRManagement.EmployeeConstraintInsert(BaseCompanyCode, lblEmployeeNumber.Text, ddlConstraintType.SelectedValue, ddlValue.SelectedValue, ddlValue.SelectedItem.Text, txtRemarks.Text, BaseUserID);
                gvEmployeeConstraint.EditIndex = -1;
                FillgvEmployeeConstraint();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblEmpConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }

        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvEmployeeConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeConstraint_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvEmployeeConstraint.EditIndex = e.NewEditIndex;
        FillgvEmployeeConstraint();
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvEmployeeConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeConstraint_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmployeeConstraint.EditIndex = -1;
        FillgvEmployeeConstraint();
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvEmployeeConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeConstraint_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objHRManagement = new BL.HRManagement();
        var ds = new DataSet();
        var ddlConstraintType = (DropDownList)gvEmployeeConstraint.Rows[e.RowIndex].FindControl("ddlConstraintType");
        var ddlConstraintDesc = (DropDownList)gvEmployeeConstraint.Rows[e.RowIndex].FindControl("ddlConstraintDesc");
        var ddlValue = (DropDownList)gvEmployeeConstraint.Rows[e.RowIndex].FindControl("ddlValue");
        var HFEmployeeConstraintAutoID = (HiddenField)gvEmployeeConstraint.Rows[e.RowIndex].FindControl("HFEmployeeConstraintAutoID");
        var txtValue = (TextBox)gvEmployeeConstraint.Rows[e.RowIndex].FindControl("txtValue");
        var txtRemarks = (TextBox)gvEmployeeConstraint.Rows[e.RowIndex].FindControl("txtRemarks");
        ds = txtValue.Style["display"] == "block" ? objHRManagement.EmployeeConstraintUpdate(BaseCompanyCode, lblEmployeeNumber.Text, HFEmployeeConstraintAutoID.Value, ddlConstraintType.SelectedValue, ddlConstraintDesc.SelectedValue, txtValue.Text, txtRemarks.Text, BaseUserID) : objHRManagement.EmployeeConstraintUpdate(BaseCompanyCode, lblEmployeeNumber.Text, HFEmployeeConstraintAutoID.Value, ddlConstraintType.SelectedValue, ddlValue.SelectedValue, ddlValue.SelectedItem.Text, txtRemarks.Text, BaseUserID);
        gvEmployeeConstraint.EditIndex = -1;
        FillgvEmployeeConstraint();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblEmpConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvEmployeeConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeConstraint_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objHRManagement = new BL.HRManagement();
        var ds = new DataSet();
        var HFEmployeeConstraintAutoID = (HiddenField)gvEmployeeConstraint.Rows[e.RowIndex].FindControl("HFEmployeeConstraintAutoID");
        ds = objHRManagement.EmployeeConstraintDelete(HFEmployeeConstraintAutoID.Value);
        FillgvEmployeeConstraint();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblEmpConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmployeeConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeConstraint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeConstraint.PageIndex = e.NewPageIndex;
        gvEmployeeConstraint.EditIndex = -1;
        FillgvEmployeeConstraint();
    }


    #endregion

    /// <summary>
    /// Fillddls the type of the constraint.
    /// </summary>
    /// <param name="ddlConstraintType">Type of the DDL constraint.</param>
    /// <param name="ddlConstraintDesc">The DDL constraint desc.</param>
    /// <param name="HFConstraintTypeAutoID">The hf constraint type automatic identifier.</param>
    /// <param name="HFConstraintCode">The hf constraint code.</param>
    /// <param name="txtValue">The text value.</param>
    /// <param name="ddlValue">The DDL value.</param>
    private void FillddlConstraintType(DropDownList ddlConstraintType, DropDownList ddlConstraintDesc, HiddenField HFConstraintTypeAutoID, HiddenField HFConstraintCode, TextBox txtValue, DropDownList ddlValue)
    {
        var objMastersManagement = new BL.MastersManagement();
        var ds = new DataSet();
        ds = objMastersManagement.ConstraintTypeGetAll(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlConstraintType.DataSource = ds.Tables[0];
            ddlConstraintType.DataTextField = "ConstraintTypeDesc";
            ddlConstraintType.DataValueField = "ConstraintTypeAutoID";
            ddlConstraintType.DataBind();
        }
        else
        {
            var L1 = new ListItem { Text = "", Value = @"0" };
            ddlConstraintType.Items.Add(L1);
        }
        try
        {
            ddlConstraintType.SelectedValue = HFConstraintTypeAutoID.Value;
        }
        catch (Exception ex)
        {

            lblEmpConstraintErrorMsg.Text = "";
        }
        FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, HFConstraintCode, txtValue, ddlValue);
    }
    /// <summary>
    /// Fillddls the constraint desc.
    /// </summary>
    /// <param name="ddlConstraintType">Type of the DDL constraint.</param>
    /// <param name="ddlConstraintDesc">The DDL constraint desc.</param>
    /// <param name="HFConstraintCode">The hf constraint code.</param>
    /// <param name="txtValue">The text value.</param>
    /// <param name="ddlValue">The DDL value.</param>
    private void FillddlConstraintDesc(DropDownList ddlConstraintType, DropDownList ddlConstraintDesc, HiddenField HFConstraintCode, TextBox txtValue, DropDownList ddlValue)
    {
        var objMastersManagement = new BL.MastersManagement();
        var ds = new DataSet();
        ds = objMastersManagement.ConstraintGetAll(BaseCompanyCode, ddlConstraintType.SelectedValue, "Client");
        ddlConstraintDesc.DataSource = ds.Tables[0];
        ddlConstraintDesc.DataTextField = "ConstraintDesc";
        ddlConstraintDesc.DataValueField = "ConstraintCode";
        ddlConstraintDesc.DataBind();
        try
        {
            ddlConstraintDesc.SelectedValue = HFConstraintCode.Value;
        }
        catch (Exception ex)
        {
            lblEmpConstraintErrorMsg.Text = "";

        }
        GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlConstraintType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlConstraintType_SelectedIndexChanged(object sender, EventArgs e)
    {
        var objDropDownList = (DropDownList)sender;
        var row = (GridViewRow)objDropDownList.NamingContainer;
        if (row.RowIndex < 0)
        {
            var ddlConstraintType = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlConstraintType");
            var ddlConstraintDesc = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlConstraintDesc");
            var txtValue = (TextBox)gvEmployeeConstraint.FooterRow.FindControl("txtValue");
            var ddlValue = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlValue");
            var HFConstraintCode = (HiddenField)gvEmployeeConstraint.FooterRow.FindControl("HFConstraintCode");
            FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, HFConstraintCode, txtValue, ddlValue);
        }
        else
        {
            var ddlConstraintType = (DropDownList)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("ddlConstraintType");
            var ddlConstraintDesc = (DropDownList)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("ddlConstraintDesc");
            var txtValue = (TextBox)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("txtValue");
            var ddlValue = (DropDownList)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("ddlValue");
            var HFConstraintCode = (HiddenField)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("HFConstraintCode");
            FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, HFConstraintCode, txtValue, ddlValue);
        }

        ddlConstraintDesc_SelectedIndexChanged(sender, e);
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlConstraintDesc control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlConstraintDesc_SelectedIndexChanged(object sender, EventArgs e)
    {

        var objDropDownList = (DropDownList)sender;
        var row = (GridViewRow)objDropDownList.NamingContainer;
        if (row.RowIndex < 0)
        {
            var ddlConstraintDesc = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlConstraintDesc");
            var ddlConstraintType = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlConstraintType");
            var ddlValue = (DropDownList)gvEmployeeConstraint.FooterRow.FindControl("ddlValue");
            var lblDefaultValue = (Label)gvEmployeeConstraint.FooterRow.FindControl("lblDefaultValue");
            var txtValue = (TextBox)gvEmployeeConstraint.FooterRow.FindControl("txtValue");

            GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);

        }
        else
        {
            var ddlConstraintDesc = (DropDownList)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("ddlConstraintDesc");
            var ddlConstraintType = (DropDownList)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("ddlConstraintType");
            var ddlValue = (DropDownList)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("ddlValue");
            var lblDefaultValue = (Label)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("lblDefaultValue");
            var txtValue = (TextBox)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("txtValue");
            var HFConstraintAutoID = (HiddenField)gvEmployeeConstraint.Rows[row.RowIndex].FindControl("HFConstraintAutoID");
            GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);
        }

    }

    /// <summary>
    /// Gets the value based on constraint automatic identifier.
    /// </summary>
    /// <param name="ddlConstraintDesc">The DDL constraint desc.</param>
    /// <param name="ddlConstraintType">Type of the DDL constraint.</param>
    /// <param name="ddlValue">The DDL value.</param>
    /// <param name="txtValue">The text value.</param>
    private void GetValueBasedOnConstraintAutoID(DropDownList ddlConstraintDesc, DropDownList ddlConstraintType, DropDownList ddlValue, TextBox txtValue)
    {
        var objMastersManagement = new BL.MastersManagement();
        var ds = new DataSet();
        ds = objMastersManagement.ConstraintValueGet(ddlConstraintDesc.SelectedValue, ddlConstraintType.SelectedValue);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 1)
            {
                ddlValue.Style["display"] = "block";
                txtValue.Style["display"] = "none";
                ddlValue.DataSource = ds.Tables[0];
                ddlValue.DataTextField = "Value";
                ddlValue.DataValueField = "ConstraintAutoID";
                ddlValue.DataBind();
            }
            else
            {
                txtValue.Style["display"] = "block";
                ddlValue.Style["display"] = "none";
            }
        }
    }


    /// <summary>
    /// Fillgvs the employee constraint.
    /// </summary>
    private void FillgvEmployeeConstraint()
    {
        if (lblEmployeeNumber.Text != "")
        {
            var objHRManagement = new BL.HRManagement();
            var ds = new DataSet();
            var dt = new DataTable();
            int dtflag;
            dtflag = 1;
            ds = objHRManagement.EmployeeConstraintGetAll(BaseCompanyCode, lblEmployeeNumber.Text);
            dt = ds.Tables[0];

            //to fix empety gridview
            if (dt.Rows.Count == 0)
            {
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
            }
            gvEmployeeConstraint.DataSource = dt;
            gvEmployeeConstraint.DataBind();

            if (dtflag == 0)//to fix empety gridview
            {
                gvEmployeeConstraint.Rows[0].Visible = false;
            }
        }
        else
        {
            lblEmpConstraintErrorMsg.Text = Resources.Resource.EmployeeNumberNotExists; //@"Employee Number doesnot Exists";
        }
    }

    /// <summary>
    /// Fills the additional employee detail.
    /// </summary>
    private void FillAdditionalEmployeeDetail()
    {
        if (lblEmployeeNumber.Text != "")
        {
            var ds = new DataSet();
            var objGet = new BL.HRManagement();
            ds = objGet.EmployeeAdditionalDetailGet(BaseCompanyCode, txtEmpAdd.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtRate.Text = ds.Tables[0].Rows[0]["rate"].ToString();
                txtJobCode.Text = ds.Tables[0].Rows[0]["JobCode"].ToString();
                txtAddType.Text = ds.Tables[0].Rows[0]["AdditionType"].ToString();
                txtOTdayCode.Text = ds.Tables[0].Rows[0]["OTDayCode"].ToString();
                txtOtDayDesc.Text = ds.Tables[0].Rows[0]["OTDayDesc"].ToString();
                txtOTNghtCode.Text = ds.Tables[0].Rows[0]["OTNightCode"].ToString();
                txtOTNghtDesc.Text = ds.Tables[0].Rows[0]["OTNightDesc"].ToString();
                chkWthExtra.Checked = bool.Parse(ds.Tables[0].Rows[0]["WithoutExtra"].ToString());
                txtMoneyExtra.Text = ds.Tables[0].Rows[0]["MoneyExtraType"].ToString();
                txtTotal.Text = ds.Tables[0].Rows[0]["Total"].ToString();
                ddlTotal.SelectedValue = ds.Tables[0].Rows[0]["TotalType"].ToString();
                txtTime.Text = ds.Tables[0].Rows[0]["Time"].ToString();
                txtWorkHrs.Text = ds.Tables[0].Rows[0]["WorkHrs"].ToString();
                txtSymbol.Text = ds.Tables[0].Rows[0]["Symbol"].ToString();
            }
            else
            {
                txtRate.Text = "";
                txtJobCode.Text = "";
                txtAddType.Text = "";
                txtOTdayCode.Text = "";
                txtOtDayDesc.Text = "";
                txtOTNghtCode.Text = "";
                txtOTNghtDesc.Text = "";
                chkWthExtra.Checked = false;
                txtMoneyExtra.Text = "";
                txtTotal.Text = "";
                //ddlTotal.SelectedValue = "";
                ddlTotal.SelectedIndex = -1;
                txtTime.Text = "";
                txtWorkHrs.Text = "";
                txtSymbol.Text = "";
            }
        }
    }
    #endregion

    // Manish For Screen ediatable or Not 
    /// <summary>
    /// Gets all records non editable.
    /// </summary>
       
    #region Function related to Employee Bank Detail

    private void FillgvBankDetail()
    {
        try
        {
            var objHrManagement = new BL.HRManagement();
            var dsBankDetail = new DataSet();
            var dtBankDetail = new DataTable();
            dtflag = 1;
            dsBankDetail = objHrManagement.EmployeeBankDetailGet(lblEmployeeNumber.Text);
            dtBankDetail = dsBankDetail.Tables[0];
            if (dtBankDetail.Rows.Count == 0)
            {
                dtflag = 0;
                dtBankDetail.Rows.Add(dtBankDetail.NewRow());
            }
            gvEmployeeBankDetail.DataSource = dtBankDetail;
            gvEmployeeBankDetail.DataBind();

            if (dtflag == 0)
            {
                gvEmployeeBankDetail.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }

        }
        catch (Exception ex)
        { 
        }


    }
    protected void gvEmployeeBankDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var txtEditBankName = (TextBox)e.Row.FindControl("txtEditBankName");
                var txtEditBranchName = (TextBox)e.Row.FindControl("txtEditBranchName");
                var txtEditIFSCCode = (TextBox)e.Row.FindControl("txtEditIFSCCode");
                var txtEditAccountNumber = (TextBox)e.Row.FindControl("txtNewRemarks");
                var txtEditAccountName = (TextBox)e.Row.FindControl("txtEditAccountName");
                if (txtEditBankName != null)
                {
                    txtEditBankName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtEditBankName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if(txtEditBranchName != null )
                {                    txtEditBranchName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtEditBranchName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if(txtEditIFSCCode != null)
                {  txtEditIFSCCode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtEditIFSCCode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                }
                if(txtEditAccountNumber != null)
                {
  txtEditAccountNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtEditAccountNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if(txtEditAccountName != null)
                {  txtEditAccountName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtEditAccountName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                }
                HiddenField StateId = (HiddenField)e.Row.FindControl("StateId");
                HiddenField DistrictId = (HiddenField)e.Row.FindControl("DistrictId");
                DropDownList ddlNewState = (DropDownList)e.Row.FindControl("ddlNewState");
                DropDownList ddlNewDistrict = (DropDownList)e.Row.FindControl("ddlNewDistrict");
                if (StateId != null && ddlNewState!=null && ddlNewDistrict!=null)
                { 
                FillddlNewState(ddlNewState, ddlNewDistrict, StateId.Value);
                ddlNewDistrict.SelectedValue = DistrictId.Value;
                }
         
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                var txtNewBankName = (TextBox)e.Row.FindControl("txtNewBankName");
                var txtNewBranchName = (TextBox)e.Row.FindControl("txtNewBranchName");
                var txtNewIFSCCode = (TextBox)e.Row.FindControl("txtNewIFSCCode");
                var txtNewAccountNumber = (TextBox)e.Row.FindControl("txtNewAccountNumber");
                var txtNewAccountName = (TextBox)e.Row.FindControl("txtNewAccountName");
                if (txtNewBankName != null)
                {
                    txtNewBankName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewBankName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if( txtNewBranchName != null)
                {
                      txtNewBranchName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewBranchName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if(txtNewIFSCCode != null )
                {
 txtNewIFSCCode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewIFSCCode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if( txtNewAccountNumber != null )
                {
    txtNewAccountNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewAccountNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if(txtNewAccountName!=null)
                {

                    txtNewAccountName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtNewAccountName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                DropDownList ddlNewState = (DropDownList)e.Row.FindControl("ddlNewState");
                DropDownList ddlNewDistrict = (DropDownList)e.Row.FindControl("ddlNewDistrict");
                FillddlNewState(ddlNewState, ddlNewDistrict,string.Empty);

            }
        
        
    }

    private void FillddlNewState(DropDownList ddlNewState, DropDownList ddlNewDistrict ,string StateId)
    {
            var objHrMGt = new BL.HRManagement();
            var ds = new DataSet();
            ds = objHrMGt.GetState();
            ddlNewState.Items.Clear();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlNewState.DataSource = ds.Tables[0];
                ddlNewState.DataTextField = "StateName";
                ddlNewState.DataValueField = "StateId";
                ddlNewState.DataBind();
                if (StateId != string.Empty)
                ddlNewState.SelectedValue = StateId;
            }
            else
            {
                ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                ddlNewState.Items.Add(li);
            }

            FillddlNewDistrict(ddlNewState, ddlNewDistrict);
    }

    private void FillddlNewDistrict(DropDownList ddlNewState, DropDownList ddlNewDistrict)
    {
        if (ddlNewState != null )
        {
            if (ddlNewState.SelectedValue != string.Empty)
            {
                var objHrMGt = new BL.HRManagement();
                var ds1 = new DataSet();
                ds1 = objHrMGt.GetDistrict(ddlNewState.SelectedValue);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    ddlNewDistrict.DataSource = ds1.Tables[0];
                    ddlNewDistrict.DataTextField = "DistrictName";
                    ddlNewDistrict.DataValueField = "DistrictId";
                    ddlNewDistrict.DataBind();
                }
                else
                {
                    ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                    ddlNewDistrict.Items.Add(li);
                }
            }
            else
            {
                ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                ddlNewDistrict.Items.Add(li);
            }
        }
        
    }

    protected void ddlEditState_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlstate = sender as DropDownList;
        foreach (GridViewRow row in gvEmployeeBankDetail.Rows)
        {

            DropDownList ddlNewState = row.FindControl("ddlNewState") as DropDownList;
            DropDownList ddlNewDistrict = row.FindControl("ddlNewDistrict") as DropDownList;
            FillddlNewDistrict(ddlNewState, ddlNewDistrict);
        }

    }
    protected void ddlNewState_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlNewState = (DropDownList)gvEmployeeBankDetail.FooterRow.FindControl("ddlNewState");
        DropDownList ddlNewDistrict = (DropDownList)gvEmployeeBankDetail.FooterRow.FindControl("ddlNewDistrict");
        FillddlNewDistrict(ddlNewState, ddlNewDistrict);
        
    }
   
    /// <summary>
    /// Handles the OnRowEditing event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeBankDetail_OnRowEditing(object sender, GridViewEditEventArgs e)
    {

        gvEmployeeBankDetail.EditIndex = e.NewEditIndex;
        FillgvBankDetail();

    }
    /// <summary>
    /// Handles the RowUpdating event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeBankDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        var ID = (HiddenField)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("BankDetailID");
        var txtEditAccountName = (TextBox)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("txtEditAccountName");
        var txtEditAccountNumber = (TextBox)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("txtEditAccountNumber");
        var txtEditIFSCCode = (TextBox)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("txtEditIFSCCode");
        var ddlNewDistrict = (DropDownList)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("ddlNewDistrict");
        var ddlNewState = (DropDownList)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("ddlNewState");
        var txtEditBankName = (TextBox)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("txtEditBankName");
        var txtEditBranchName = (TextBox)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("txtEditBranchName");
        var strTimeFrom = string.Empty;
        ds = objHrManagement.EmployeeBankdetailInsert(Convert.ToDecimal(ID.Value), txtEditBankName.Text.Trim(), Convert.ToDecimal(ddlNewState.SelectedValue), Convert.ToDecimal(ddlNewDistrict.SelectedValue), txtEditBranchName.Text.Trim(), txtEditIFSCCode.Text.Trim(), txtEditAccountNumber.Text.Trim(), txtEditAccountName.Text.Trim(), lblEmployeeNumber.Text, lblEmployeeNumber.Text, BaseCompanyCode);
        gvEmployeeBankDetail.EditIndex = -1;
        DisplayMessage(lblbankmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        FillgvBankDetail();

    }
    /// <summary>
    /// Handles the OnRowCancelingEdit event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeBankDetail_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvEmployeeBankDetail.EditIndex = -1;
        FillgvBankDetail();

    }
    /// <summary>
    /// Handles the RowCommand event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeBankDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        var hidBankDetail = (HiddenField)gvEmployeeBankDetail.FooterRow.FindControl("hidBankDetail");
        var ddlNewDistrict = (DropDownList)gvEmployeeBankDetail.FooterRow.FindControl("ddlNewDistrict");
        var ddlNewState = (DropDownList)gvEmployeeBankDetail.FooterRow.FindControl("ddlNewState");
        var txtNewAccountName = (TextBox)gvEmployeeBankDetail.FooterRow.FindControl("txtNewAccountName");
        var txtNewAccountNumber = (TextBox)gvEmployeeBankDetail.FooterRow.FindControl("txtNewAccountNumber");
        var txtNewIFSCCode = (TextBox)gvEmployeeBankDetail.FooterRow.FindControl("txtNewIFSCCode");
        var txtNewBankName = (TextBox)gvEmployeeBankDetail.FooterRow.FindControl("txtNewBankName");
        var txtNewBranchName = (TextBox)gvEmployeeBankDetail.FooterRow.FindControl("txtNewBranchName");
        var strTimeFrom = string.Empty;
        if (e.CommandName == "AddNew")
        {
            try { 
            ds = objHrManagement.EmployeeBankdetailInsert(Convert.ToInt32(hidBankDetail.Value), txtNewBankName.Text.Trim(), Convert.ToInt32(ddlNewState.SelectedValue), Convert.ToInt32(ddlNewDistrict.SelectedValue), txtNewBranchName.Text.Trim(), txtNewIFSCCode.Text.Trim(), txtNewAccountNumber.Text.Trim(), txtNewAccountName.Text.Trim(), lblEmployeeNumber.Text,lblEmployeeNumber.Text,BaseCompanyCode);
            DisplayMessage(lblbankmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
            txtNewBankName.Text = "";
            txtNewAccountName.Text = "";
            txtNewAccountNumber.Text = "";
            txtNewIFSCCode.Text = "";
            FillgvBankDetail();
                }
            catch(Exception ex)
            { }

        }
    }
   
    /// <summary>
    /// Handles the RowDeleting event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeBankDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField ID = (HiddenField)gvEmployeeBankDetail.Rows[e.RowIndex].FindControl("ID");
        ds = objHrManagement.EmployeeBankdetailDelete(Convert.ToInt32(ID.Value));
        DisplayMessage(lblbankmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvEmployeeBankDetail.EditIndex = -1;
        FillgvBankDetail();
       
    }
    protected void gvEmployeeBankDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeBankDetail.PageIndex = e.NewPageIndex;
        gvEmployeeBankDetail.EditIndex = -1;
        FillgvBankDetail();
    }
    #endregion

    #region Function related to Employee Family Detail
    private void FillgvFamilyDetail()
    {
        try
        {
            var objHrManagement = new BL.HRManagement();
            var dsBankDetail = new DataSet();
            var dtBankDetail = new DataTable();
            dtflag = 1;
            dsBankDetail = objHrManagement.EmployeeFamilyDetailGet(lblEmployeeNumber.Text);
            dtBankDetail = dsBankDetail.Tables[0];

            if (dtBankDetail.Rows.Count == 0)
            {
                dtflag = 0;
                dtBankDetail.Rows.Add(dtBankDetail.NewRow());
            }
            gvEmployeeFamilyDetail.DataSource = dtBankDetail;
            gvEmployeeFamilyDetail.DataBind();

            if (dtflag == 0)
            {
                gvEmployeeFamilyDetail.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void gvEmployeeFamilyDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
            var txtRelationName = (TextBox)e.Row.FindControl("txtRelationName");
            var txtEditDOB = (TextBox)e.Row.FindControl("txtEditDOB");
            if (txtEditDOB != null)
            {
                txtEditDOB.Attributes.Add("readonly", "readonly");
            }
        if (txtRelationName != null)
        {
            txtRelationName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            txtRelationName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        }
          //  HiddenField hfdob = (HiddenField)e.Row.FindControl("hfdob");
          
            HiddenField hfeditrelation = (HiddenField)e.Row.FindControl("hfeditrelation");
            HiddenField hfeditgender = (HiddenField)e.Row.FindControl("hfeditgender");
            var ddlgender = (DropDownList)e.Row.FindControl("ddlgender");
            var ddlNewRelation = (DropDownList)e.Row.FindControl("ddlNewRelation");
              if (ddlgender != null && hfeditgender != null  && hfeditrelation!=null && ddlNewRelation!=null)
              {
                  if (hfeditrelation.Value == "Mother" || hfeditrelation.Value == "Father")
                  { ddlgender.Enabled = false; }
                  else
                  { ddlgender.Enabled = true; }
                ddlgender.SelectedValue = hfeditgender.Value;
                ddlNewRelation.SelectedValue = hfeditrelation.Value;

              
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
            {
                var txtRelationName = (TextBox)e.Row.FindControl("txtRelationName");
                if (txtRelationName != null)
                {
                    txtRelationName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtRelationName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                var txtNewDOB = (TextBox)e.Row.FindControl("txtNewDOB");
                if (txtNewDOB != null)
                {
                    txtNewDOB.Attributes.Add("readonly", "readonly");
                }
            }

        
    }
    protected void ddlNewRelation_SelectedIndexChanged(object sender, EventArgs e)
    {
     
        DropDownList ddlNewRelation = gvEmployeeFamilyDetail.FooterRow.FindControl("ddlNewRelation") as DropDownList;
        CalendarExtender CalendarExtender5 = gvEmployeeFamilyDetail.FooterRow.FindControl("CalendarExtender5") as CalendarExtender;
        DropDownList ddlgender = gvEmployeeFamilyDetail.FooterRow.FindControl("ddlgender") as DropDownList;
        if (ddlNewRelation != null)
        {
            if (ddlNewRelation.SelectedValue == "Mother")
            {
               ddlgender.SelectedValue = "Female";
               ddlgender.Enabled = false;
            }
            if (ddlNewRelation.SelectedValue == "Father")
            {
                ddlgender.SelectedValue = "Male";
                ddlgender.Enabled = false;
               
            }
            if (ddlNewRelation.SelectedValue == "Spouse" || ddlNewRelation.SelectedValue == "Children" || ddlNewRelation.SelectedValue == "Nominee")
            {
                ddlgender.Enabled = true;
                ddlgender.SelectedValue = "Male";
            }
      }

    }
    protected void ddlEditRelation_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlEditRelation = sender as DropDownList;
        GridViewRow row = (GridViewRow)ddlEditRelation.NamingContainer;
        DropDownList ddlgender = (DropDownList)row.FindControl("ddlgender");
        if (ddlEditRelation.SelectedValue == "Mother")
        { ddlgender.SelectedValue = "Female";
        ddlgender.Enabled = false;
        }
        else if (ddlEditRelation.SelectedValue == "Father")
        {
            ddlgender.SelectedValue = "Male";
            ddlgender.Enabled = false;
        }
        else
        {
            ddlgender.SelectedValue = "Male";
            ddlgender.Enabled = true;
        }
    }
   
    /// <summary>
    /// Handles the OnRowEditing event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    /// 
    
    protected void gvEmployeeFamilyDetail_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        Label EditGender = gvEmployeeFamilyDetail.Rows[e.NewEditIndex].FindControl("lblGender") as Label;
      
        DropDownList ddlgender = gvEmployeeFamilyDetail.FooterRow.FindControl("ddlgender") as DropDownList;
         DropDownList ddlNewRelation = gvEmployeeFamilyDetail.FooterRow.FindControl("ddlNewRelation") as DropDownList;
    
      //  CalendarExtender CalendarExtender5 = gvEmployeeFamilyDetail.FooterRow.FindControl("CalendarExtender5") as CalendarExtender;
        Label lblRelation = gvEmployeeFamilyDetail.Rows[e.NewEditIndex].FindControl("lblRelation") as Label;
    
        
        if (lblRelation.Text == "Children")
        {
            ddlNewRelation.SelectedValue = "Children";
         //   CalendarExtender5.StartDate = Convert.ToDateTime(hfdob.Value).AddYears(20);
            //ddlgender.SelectedValue = "Male";
           
        }
        if (lblRelation.Text == "Spouse")
        {
            ddlNewRelation.SelectedValue = "Spouse";
           // CalendarExtender5.StartDate = Convert.ToDateTime(hfdob.Value).AddYears(20);
            //ddlgender.SelectedValue = "Male";
          
        }
        if (lblRelation.Text == "Father")
        {
            ddlNewRelation.SelectedValue = "Father";
           //CalendarExtender5.EndDate = Convert.ToDateTime(hfdob.Value);
            //ddlgender.SelectedValue = "Male";
        
        }
        if (lblRelation.Text == "Mother")
        {
            ddlNewRelation.SelectedValue = "Mother";
            //CalendarExtender5.EndDate = Convert.ToDateTime(hfdob.Value);
           // ddlgender.SelectedValue = "Female";
        
        }
        if (lblRelation.Text == "Nominee")
        {
            ddlNewRelation.SelectedValue = "Nominee";
            //CalendarExtender5.EndDate = Convert.ToDateTime(hfdob.Value);
            // ddlgender.SelectedValue = "Female";

        }
        

        gvEmployeeFamilyDetail.EditIndex = e.NewEditIndex;
        FillgvFamilyDetail();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeFamilyDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField ID = (HiddenField)gvEmployeeFamilyDetail.Rows[e.RowIndex].FindControl("FamilyDetailID");
        TextBox txtEditDOB = (TextBox)gvEmployeeFamilyDetail.Rows[e.RowIndex].FindControl("txtEditDOB");
        TextBox txtRelationName = (TextBox)gvEmployeeFamilyDetail.Rows[e.RowIndex].FindControl("txtRelationName");
        DropDownList ddlNewRelation = (DropDownList)gvEmployeeFamilyDetail.Rows[e.RowIndex].FindControl("ddlNewRelation");
        Label EditGender = (Label)gvEmployeeFamilyDetail.Rows[e.RowIndex].FindControl("EditGender");
        DropDownList ddlgender = (DropDownList)gvEmployeeFamilyDetail.Rows[e.RowIndex].FindControl("ddlgender");
        var strTimeFrom = string.Empty;
        string Gender = "";
        if (ddlgender.SelectedValue=="Male")
        {
           
            Gender = "Male";
        }
        else
        {
            Gender = "Female";
        }
        ds = objHrManagement.EmployeeFamilyDetailInsert(lblEmployeeNumber.Text, BaseCompanyCode, Convert.ToInt32(ID.Value), ddlNewRelation.SelectedItem.Text.Trim(), txtRelationName.Text, txtEditDOB.Text, Gender, lblEmployeeNumber.Text);
     //   txtEditDOB.Text = "";
        if (Convert.ToInt32(ds.Tables[0].Rows[0]["MessageId"].ToString()) >= 0)
        {
            DisplayMessage(lblFamily, ds.Tables[0].Rows[0]["MessageId"].ToString());
        }
        else
        {
            DisplayMessageForResourceKey(lblFamily, ds.Tables[0].Rows[0]["MessageStrID"].ToString());
        }
        gvEmployeeFamilyDetail.EditIndex = -1;
        FillgvFamilyDetail();
    }
    /// <summary>
    /// Handles the OnRowCancelingEdit event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeFamilyDetail_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvEmployeeFamilyDetail.EditIndex = -1;
        FillgvFamilyDetail();

    }
    /// <summary>
    /// Handles the RowCommand event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeFamilyDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField HidFamilyDetailID = (HiddenField)gvEmployeeFamilyDetail.FooterRow.FindControl("HidFamilyDetailID");
        DropDownList ddlNewRelation = (DropDownList)gvEmployeeFamilyDetail.FooterRow.FindControl("ddlNewRelation");
        TextBox txtNewDOB = (TextBox)gvEmployeeFamilyDetail.FooterRow.FindControl("txtNewDOB");
        TextBox txtRelationName = (TextBox)gvEmployeeFamilyDetail.FooterRow.FindControl("txtRelationName");
      //  RadioButton rbNewFemale = (RadioButton)gvEmployeeFamilyDetail.FooterRow.FindControl("rbNewFemale");
       // RadioButton rbNewMale = (RadioButton)gvEmployeeFamilyDetail.FooterRow.FindControl("rbNewMale"); 
        DropDownList ddlgender = (DropDownList)gvEmployeeFamilyDetail.FooterRow.FindControl("ddlgender");
        var strTimeFrom = string.Empty;
        if (e.CommandName == "AddNew")
        {
            string Gender = "";
            if (ddlgender.SelectedValue == "Male")
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }
            ds = objHrManagement.EmployeeFamilyDetailInsert(lblEmployeeNumber.Text, BaseCompanyCode, Convert.ToInt32(HidFamilyDetailID.Value), ddlNewRelation.SelectedItem.Text, txtRelationName.Text, txtNewDOB.Text, Gender, lblEmployeeNumber.Text);
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["MessageId"].ToString()) >= 0)
            {
                DisplayMessage(lblFamily, ds.Tables[0].Rows[0]["MessageId"].ToString());
            }
            else
            {
                DisplayMessageForResourceKey(lblFamily, ds.Tables[0].Rows[0]["MessageStrID"].ToString());
            }
             txtNewDOB.Text = "";
             FillgvFamilyDetail();
        }
        if(e.CommandName=="Reset")
        {
            txtNewDOB.Text = "";
            txtRelationName.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeFamilyDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField ID = (HiddenField)gvEmployeeFamilyDetail.Rows[e.RowIndex].FindControl("ID");
        ds = objHrManagement.EmployeeFamilydetailDelete(Convert.ToInt32(ID.Value));
        DisplayMessage(lblFamily, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvEmployeeFamilyDetail.EditIndex = -1;
        FillgvFamilyDetail();

    }
    protected void gvEmployeeFamilyDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeFamilyDetail.PageIndex = e.NewPageIndex;
        gvEmployeeFamilyDetail.EditIndex = -1;
        FillgvFamilyDetail();
    }
    #endregion

    #region SAT#124 Employee Work History
    /// <summary>
    /// Function used to fill Grid gvEmployeeWorkHistory
    /// </summary>
    private void FillgvEmployeeWorkHistory()
    {
        var objHrManagement = new BL.HRManagement();
        var dt = new DataTable();
        lblErrorEmpWorkHistory.Text = string.Empty;
        txtEmpHistoryEmployeeNumber.Text = (Request.QueryString["strEmployeeNumber"]);
        dt = objHrManagement.EmployeeWorkHistoryGet(lblEmployeeNumber.Text, ddlConfirmDuty.SelectedValue);
        if (dt != null && dt.Rows.Count > 0)
        {
            txtEmpHistoryEmployeeName.Text = Convert.ToString(dt.Rows[0]["EmployeeName"]);
            gvEmployeeWorkHistory.DataSource = dt;
            gvEmployeeWorkHistory.DataBind();
            gvEmployeeWorkHistory.Visible = true;
        }
        else
        {
            gvEmployeeWorkHistory.Visible = false;
            lblErrorEmpWorkHistory.Text = Resources.Resource.NoRecordFound;
        }
    }

    /// <summary>
    /// Function called on drop down Confirm Duty SelectedIndexChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlConfirmDuty_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvEmployeeWorkHistory();
    }
    #endregion

    protected void EmpDetails_ActiveTabChanged(object sender, EventArgs e)
    {
        if (EmpDetails.ActiveTabIndex == 1)
        {
            if (lblEmployeeNumber.Text != "")
            {
                txtEmployeeNumberCon.Text = lblEmployeeNumber.Text;
                FillgvEmployeeConstraint();
            }
            else
            {
                txtEmployeeNumberCon.Text = "";
                txtEmployeeNameCon.Text = "";
                gvEmployeeConstraint.DataSource = null;
                gvEmployeeConstraint.DataBind();
            }
        }
        if (EmpDetails.ActiveTabIndex == 2)
        {
            if (lblEmployeeNumber.Text != "")
            {
                txtEmployeeNumberEmployeePreferances.Text = lblEmployeeNumber.Text;
                FillgvEmployeePreferances(lblEmployeeNumber.Text);
            }
            else
            {
                txtEmployeeNumberEmployeePreferances.Text = "";
                txtEmployeeNameEmployeePreferances.Text = "";
                gvEmployeePreferances.DataSource = null;
                gvEmployeePreferances.DataBind();
            }
        }
        if (EmpDetails.ActiveTabIndex == 3)
        {
            if (lblEmployeeNumber.Text != "")
            {
                txtEmployeeNumberBarredAssignments.Text = lblEmployeeNumber.Text;
                FillgvBarredAssignments(lblEmployeeNumber.Text);
            }
            else
            {
                txtEmployeeNumberBarredAssignments.Text = "";
                txtEmployeeNameBarredAssignments.Text = "";
                gvBarredAssignments.DataSource = null;
                gvBarredAssignments.DataBind();
            }
        }
        if (EmpDetails.ActiveTabIndex == 4)
        {
            if (lblEmployeeNumber.Text != "")
            {
                txtEmpAdd.Text = lblEmployeeNumber.Text;
                FillAdditionalEmployeeDetail();
            }
            else
            {
                ClearAdditionalDetails();
            }
        }
    }
    private void ClearAdditionalDetails()
    {
        txtEmpAdd.Text = "";
        txtEmpName.Text = "";
        txtRate.Text = "";
        txtJobCode.Text = "";
        txtAddType.Text = "";
        txtOTdayCode.Text = "";
        txtOtDayDesc.Text = "";
        txtOTNghtCode.Text = "";
        txtOTNghtDesc.Text = "";
        chkWthExtra.Checked = false;
        txtMoneyExtra.Text = "";
        txtTotal.Text = "";
        txtWorkHrs.Text = "";
        txtSymbol.Text = "";
        txtTime.Text = "";
    }

    protected void ViewReportEmp_Click(object sender, EventArgs e)
    {
        Response.Redirect("../HRManagement/EmployeeApplicationForm.aspx?EmployeeNumber=" + lblEmployeeNumber.Text);
    }

    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillGrade();
    }
}


