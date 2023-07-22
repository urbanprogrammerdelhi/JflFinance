// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeInterCompanyTransferCorrection.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/*-----------------------------------------------------------------------
// <copyright file="HRManagement_EmployeeInterCompanyTransferCorrection.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
*/

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using BL;

/// <summary>
/// Page for Employee Location, COmpany, Divison Transfer Correction
/// </summary>
public partial class HRManagement_EmployeeInterCompanyTransferCorrection : BasePage//System.Web.UI.Page
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
                var virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsWriteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsModifyAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsDeleteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    private readonly HRManagement _hrManagement;
    private readonly MastersManagement _mastersManagement;
    private readonly UserManagement _userManagement ;
    private readonly OperationManagement _operationManagement;

    protected HRManagement_EmployeeInterCompanyTransferCorrection()
    {
        _hrManagement = new HRManagement();
        _mastersManagement = new MastersManagement();
        _userManagement = new UserManagement();
        _operationManagement = new OperationManagement();
    }

    /// <summary>
    /// Loads the Page
    /// </summary>
    /// <param name="sender">this Page Load</param>
    /// <param name="e">Event Args Load</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(HRManagement_EmployeeInterCompanyTransferCorrection));
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                var locationAutoId = Request.QueryString["LocationAutoID"];
                var employeeName = Request.QueryString["EmployeeName"];
                var employeeNumber = Request.QueryString["EmployeeNumber"];
                var companyCode = Request.QueryString["CompanyCode"];
                var hrLocationCode = Request.QueryString["HrLocationCode"];
                var locationCode = Request.QueryString["LocationCode"];
                var departmentDesc = Request.QueryString["DepartmentDesc"];
                var companyDesc = Request.QueryString["CompanyDesc"];
                var hrLocationDesc = Request.QueryString["HrLocationDesc"];
                var locationDesc = Request.QueryString["LocationDesc"];
                var designationDesc = Request.QueryString["DesignationDesc"];
                var categoryDesc = Request.QueryString["CategoryDesc"];
                var operationType = Request.QueryString["OperationType"];
                var areaDesc = Request.QueryString["AreaDesc"];
                var gradeDesc = Request.QueryString["GradeDesc"];
                using (var ds = _hrManagement.ActiveDetailsOfEmployeeGetAll(BaseCompanyCode, int.Parse(BaseLocationAutoID), employeeNumber))
                {
                    HFOperationType.Value = operationType;
                    hfCompanyCode.Value = companyCode;
                    hfHrLocationCode.Value = hrLocationCode;
                    hfLocationCode.Value = locationCode;
                    hfLocationAutoID.Value = locationAutoId;        //Revert Changes on 19-Nov-2014

                    if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
                    {
                        hfDesignationCode.Value = ds.Tables[0].Rows[0]["DesignationCode"].ToString();
                        hfGradeCode.Value = ds.Tables[0].Rows[0]["GradeCode"].ToString();
                        hfCategoryCode.Value = ds.Tables[0].Rows[0]["CategoryCode"].ToString();
                        hfJobClassCode.Value = ds.Tables[0].Rows[0]["JobClassCode"].ToString();
                        hfJobTypeCode.Value = ds.Tables[0].Rows[0]["JobTypeCode"].ToString();
                        hfRoleCode.Value = ds.Tables[0].Rows[0]["RoleCode"].ToString();
                        hfDepartmentCode.Value = ds.Tables[0].Rows[0]["DepartmentCode"].ToString();
                        hfDeptEffectiveFrom.Value = ds.Tables[0].Rows[0]["DepartmentEffectiveFrom"].ToString();
                        hfAreaID.Value = ds.Tables[0].Rows[0]["AreaID"].ToString();
                        hfAreaEffectiveFrom.Value = ds.Tables[0].Rows[0]["AreaEffectiveFrom"].ToString();
                        hfDesiEffectiveFrom.Value = ds.Tables[0].Rows[0]["DesignationEffectiveFrom"].ToString();
                        hflocationEffectiveFrom.Value = ds.Tables[0].Rows[0]["LocationEffectievFrom"].ToString();
                        hfCatEffectiveFrom.Value = ds.Tables[0].Rows[0]["CategoryEffectiveFrom"].ToString();
                        hfCompEffectiveFrom.Value = ds.Tables[0].Rows[0]["CompanyEffectiveFrom"].ToString();
                        hfEmpJobTypeEffectiveFrom.Value = ds.Tables[0].Rows[0]["JobTypeEffectiveFrom"].ToString();
                        hfRoleEffectiveFrom.Value = ds.Tables[0].Rows[0]["RoleEffectiveFrom"].ToString();
                        hfEmpJobClassEffectiveFrom.Value = ds.Tables[0].Rows[0]["JobClassEffectiveFrom"].ToString();
                        lblEmpName.Text = employeeName;
                        lblEmpNumber.Text = employeeNumber;
                        lblCurrentHrLocation.Text = hrLocationDesc;
                        lblCurrentCompany.Text = companyDesc;
                        lblCurrentLocation.Text = locationDesc;
                        lblCurrentDesignation.Text = designationDesc;
                        lblCurrentGrade.Text = gradeDesc;
                        lblCurrentCategory.Text = categoryDesc;
                        lblCurrentAreaID.Text = areaDesc;
                        lblCurrentDepartment.Text = departmentDesc;

                        FillEmployeeDetails();

                        lblCurrentJobType.Text = ddlJobType.SelectedItem.Text;
                        lblCurrentJobClass.Text = ddlJobClass.SelectedItem.Text;
                        lblCurrentRole.Text = ddlRole.SelectedItem.Text;

                        HideButtonBasedOnOperationType();
                    }
                    else
                    {
                        Response.Redirect("EmployeeInterCompanyTransfer.aspx");
                    }
                }

                btnCorrection.Attributes.Add("onClick", "javascript:DoCorrection();");
                txtEffectiveTo.Attributes.Add("readonly", "readonly");
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }
    /// <summary>
    /// Sets Visibility to false
    /// </summary>
    private void HideButtonBasedOnOperationType()
    {
        switch (HFOperationType.Value)
        {
            case "Correction":
                if (CheckBoxStatus())
                {
                    btnUpdate.Visible = false;
                    btnRollback.Visible = false;
                    DisableDropDown();
                    txtEffectiveTo.Visible = false;
                    lblEffectiveTo.Visible = false;
                    imgDate.Visible = false;
                    ImgEffectiveFromRole.Visible = false;

                    imgEffectiveFromAreaID.Visible = false;
                    imgEffectiveFromDepartment.Visible = false;
                    imgEffectiveFromCategory.Visible = false;
                    imgEffectiveFromCompany.Visible = false;
                    imgEffectiveFromDesignation.Visible = false;
                    imgEffectiveFromGrade.Visible = false;
                    imgEffectiveFromHrLocation.Visible = false;
                    imgEffectiveFromJobClass.Visible = false;
                    imgEffectiveFromJobType.Visible = false;
                    imgEffectiveFromLocation.Visible = false;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnRollback.Visible = false;
                    DisableDropDown();
                    txtEffectiveTo.Visible = false;
                    lblEffectiveTo.Visible = false;
                    imgDate.Visible = false;
                    btnCorrection.Enabled = false;
                }
                break;
            case "RollBack":
                if (CheckBoxStatus())
                {
                    btnUpdate.Visible = false;
                    btnCorrection.Visible = false;
                    DisableDropDown();
                    txtEffectiveTo.Visible = false;
                    lblEffectiveTo.Visible = false;
                    imgDate.Visible = false;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnCorrection.Visible = false;
                    DisableDropDown();
                    txtEffectiveTo.Visible = false;
                    lblEffectiveTo.Visible = false;
                    imgDate.Visible = false;
                }
                break;
            default:
                btnRollback.Visible = false;
                btnCorrection.Visible = false;
                CBCategory.Visible = false;
                CBCompany.Visible = false;
                CBDesignation.Visible = false;
                CBGrade.Visible = false;
                CBHrLocation.Visible = false;
                CBJobClass.Visible = false;
                CBJobType.Visible = false;
                CBLocation.Visible = false;
                CBRole.Visible = false;
                CBDepartment.Visible = false;
                CBAreaID.Visible = false;
                txtEffectiveFromRole.Visible = false;
                txtEffectiveFromDepartment.Visible = false;
                txtEffectiveFromAreaID.Visible = false;
                txtEffectiveFromCategory.Visible = false;
                txtEffectiveFromCompany.Visible = false;
                txtEffectiveFromDesignation.Visible = false;
                txtEffectiveFromGrade.Visible = false;
                txtEffectiveFromHrLocation.Visible = false;
                txtEffectiveFromJobClass.Visible = false;
                txtEffectiveFromJobType.Visible = false;
                txtEffectiveFromLocation.Visible = false;
                ImgEffectiveFromRole.Visible = false;
                imgEffectiveFromAreaID.Visible = false;
                imgEffectiveFromDepartment.Visible = false;
                imgEffectiveFromCategory.Visible = false;
                imgEffectiveFromCompany.Visible = false;
                imgEffectiveFromDesignation.Visible = false;
                imgEffectiveFromGrade.Visible = false;
                imgEffectiveFromHrLocation.Visible = false;
                imgEffectiveFromJobClass.Visible = false;
                imgEffectiveFromJobType.Visible = false;
                imgEffectiveFromLocation.Visible = false;
                break;
        }
    }

    #region Function Related to DropDown SelectedIndexChanged

    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DdlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlHrLocation.DataSource = _userManagement.UserHRLocationAccessGet(BaseUserID, ddlCompany.SelectedValue).Tables[0];
        ddlHrLocation.DataTextField = "HrLocationDesc";
        ddlHrLocation.DataValueField = "HrLocationCode";
        ddlHrLocation.DataBind();

        if (ddlHrLocation.SelectedItem == null)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlHrLocation.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
        ddlDesignation.DataSource = _hrManagement.EmployeeInterCompanyTransferGetDesignation(ddlCompany.SelectedValue).Tables[0];
        ddlDesignation.DataTextField = "DesignationDesc";
        ddlDesignation.DataValueField = "DesignationCode";
        ddlDesignation.DataBind();
        if (ddlDesignation.SelectedItem == null)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlDesignation.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }

        var objMastersManagement = new BL.MastersManagement();
        ddlGrade.DataSource = objMastersManagement.GradeMasterGetAll(ddlCompany.SelectedValue, ddlDesignation.SelectedItem.Value);
        ddlGrade.DataTextField = "GradeDesc";
        ddlGrade.DataValueField = "GradeCode";
        ddlGrade.DataBind();
        if (ddlGrade.SelectedValue == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlGrade.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }


        ddlCategory.DataSource = _hrManagement.EmployeeInterCompanyTransferGetCategory(ddlCompany.SelectedValue).Tables[0];
        ddlCategory.DataTextField = "CategoryDesc";
        ddlCategory.DataValueField = "CategoryCode";
        ddlCategory.DataBind();
        if (ddlCategory.SelectedItem == null)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlCategory.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }

        ddlDepartment.DataSource = _hrManagement.DepartmentGet(ddlCompany.SelectedValue).Tables[0];
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataValueField = "DepartmentCode";
        ddlDepartment.DataBind();
        if (ddlDepartment.SelectedItem == null)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlDepartment.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }


        ddlJobType.DataSource = _mastersManagement.JobTypeMasterGetAll(ddlCompany.SelectedValue).Tables[0];
        ddlJobType.DataTextField = "JobTypeDesc";
        ddlJobType.DataValueField = "JobTypeCode";
        ddlJobType.DataBind();
        if (ddlJobType.SelectedItem == null)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlJobType.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
        ddlJobClass.DataSource = _mastersManagement.JobClassMasterGetAll(ddlCompany.SelectedValue).Tables[0];
        ddlJobClass.DataTextField = "JobClassDesc";
        ddlJobClass.DataValueField = "JobClassCode";
        ddlJobClass.DataBind();
        if (ddlJobClass.SelectedItem == null)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlJobClass.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }

        ddlRole.DataSource = _mastersManagement.RoleGet(ddlCompany.SelectedValue).Tables[0];
        ddlRole.DataTextField = "RoleDesc";
        ddlRole.DataValueField = "RoleCode";
        ddlRole.DataBind();
        if (ddlRole.SelectedItem == null)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlRole.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
        DdlHrLocation_SelectedIndexChanged(sender, e);

        ddlAreaID.DataSource = _operationManagement.AreaIdGet(ddlLocation.SelectedValue, "0").Tables[0];
        ddlAreaID.DataTextField = "AreaDesc";
        ddlAreaID.DataValueField = "AreaID";
        ddlAreaID.DataBind();
        if (ddlAreaID.SelectedItem == null)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlAreaID.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
        GetEffectiveFromDate();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DdlHrLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLocation.DataSource = _userManagement.UserLocationAccessGet(BaseUserID, ddlCompany.SelectedValue, ddlHrLocation.SelectedValue).Tables[0];
        ddlLocation.DataTextField = "LocationDesc";
        ddlLocation.DataValueField = "LocationAutoID";
        ddlLocation.DataBind();
        GetEffectiveFromDate();
        if (ddlLocation.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlLocation.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {

            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
            FillddlDesignation();
            FillddlGrade();
            FillddlDepartment();
            FillddlCategory();
            FillddlJobType();
            FillddlJobClass();
            FillddlRole();
            FillddlAreaId();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DdlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetEffectiveFromDate();
        FillddlDesignation();
        FillddlGrade();
        FillddlDepartment();
        FillddlCategory();
        FillddlJobType();
        FillddlJobClass();
        FillddlRole();
        FillddlAreaId();
    }
    #endregion
    /// <summary>
    /// Fills the DropDown Job Class
    /// </summary>
    private void FillddlJobClass()
    {
        ddlJobClass.DataSource = _mastersManagement.JobClassMasterGetAll(ddlCompany.SelectedValue).Tables[0];
        ddlJobClass.DataTextField = "JobClassDesc";
        ddlJobClass.DataValueField = "JobClassCode";
        ddlJobClass.SelectedValue = hfJobClassCode.Value;
        ddlJobClass.DataBind();
        if (ddlJobClass.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };

            ddlJobClass.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
    }
    /// <summary>
    /// Fills the Drop Down Job Tyoe
    /// </summary>
    private void FillddlJobType()
    {
        ddlJobType.DataSource = _mastersManagement.JobTypeMasterGetAll(ddlCompany.SelectedValue).Tables[0];
        ddlJobType.DataTextField = "JobTypeDesc";
        ddlJobType.DataValueField = "JobTypeCode";
        ddlJobType.SelectedValue = hfJobTypeCode.Value;
        ddlJobType.DataBind();
        if (ddlJobType.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlJobType.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
    }
    /// <summary>
    /// Fills the Drop Down Area ID
    /// </summary>
    private void FillddlAreaId()
    {
        ddlAreaID.Items.Clear();
        if (_operationManagement != null)
        {
            var ds = _operationManagement.AreaIdGet(ddlLocation.SelectedValue, "0");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAreaID.DataSource = ds;
                ddlAreaID.DataTextField = "AreaDesc";
                ddlAreaID.DataValueField = "AreaID";
                ddlAreaID.DataBind();
            }
            else
            {
                var li1 = new ListItem
                {
                    Text = Resources.Resource.NoData,
                    Value = @"0"
                };
                ddlAreaID.Items.Add(li1);
                btnUpdate.Enabled = false;
                btnCorrection.Enabled = false;
                btnRollback.Enabled = false;
            }
        }
        if (ddlLocation.SelectedValue == hfLocationAutoID.Value)
        {
            try
            {
                ddlAreaID.SelectedValue = hfAreaID.Value;
            }
            catch (Exception)
            {
                lblErrorMsg.Text = Resources.Resource.ErrorMessage;
            }
        }
        if (ddlAreaID.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlAreaID.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
    }
    /// <summary>
    /// Fills The dropdown for Department
    /// </summary>
    private void FillddlDepartment()
    {
        ddlDepartment.Items.Clear();
        using (var ds = _hrManagement.DepartmentGet(ddlCompany.SelectedValue))
        {
            ddlDepartment.DataSource = ds.Tables[0];
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentCode";
            ddlDepartment.DataBind();
        }
        ddlDepartment.SelectedValue = hfDepartmentCode.Value;

        if (ddlDepartment.Text == string.Empty)
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlDepartment.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
    }

    /// <summary>
    /// Fills The dropdown for Category
    /// </summary>
    private void FillddlCategory()
    {
        ddlCategory.DataSource = _hrManagement.EmployeeInterCompanyTransferGetCategory(ddlCompany.SelectedValue).Tables[0];
        ddlCategory.DataTextField = "CategoryDesc";
        ddlCategory.DataValueField = "CategoryCode";
        ddlCategory.SelectedValue = hfCategoryCode.Value;
        ddlCategory.DataBind();
        if (ddlCategory.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlCategory.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
    }
    /// <summary>
    /// Fills The dropdown for Designation
    /// </summary>
    private void FillddlDesignation()
    {
        ddlDesignation.DataSource = _hrManagement.EmployeeInterCompanyTransferGetDesignation(ddlCompany.SelectedValue).Tables[0];
        ddlDesignation.DataTextField = "DesignationDesc";
        ddlDesignation.DataValueField = "DesignationCode";
        ddlDesignation.SelectedValue = hfDesignationCode.Value;
        ddlDesignation.DataBind();
        if (ddlDesignation.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlDesignation.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
    }

    private void FillddlGrade()
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlGrade.DataSource = objMastersManagement.GradeMasterGetAll(ddlCompany.SelectedValue, ddlDesignation.SelectedItem.Value);
        ddlGrade.DataTextField = "GradeDesc";
        ddlGrade.DataValueField = "GradeCode";
       ddlGrade.SelectedValue = hfGradeCode.Value;
        ddlGrade.DataBind();
        if (ddlGrade.SelectedValue == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlGrade.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }


       
    }
    /// <summary>
    /// Fills The dropdown for Location
    /// </summary>
    private void FillddlLocation()
    {
        ddlLocation.DataSource = _userManagement.UserLocationAccessGet(BaseUserID, ddlCompany.SelectedValue, ddlHrLocation.SelectedValue).Tables[0];
        ddlLocation.DataTextField = "LocationDesc";
        ddlLocation.DataValueField = "LocationAutoID";
        ddlLocation.SelectedValue = hfLocationAutoID.Value;
        ddlLocation.DataBind();
        if (ddlLocation.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlLocation.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
    }

    /// <summary>
    /// Fills The dropdown for Division
    /// </summary>
    private void FillddlHrLocation()
    {
        ddlHrLocation.DataSource = _userManagement.UserHRLocationAccessGet(BaseUserID, ddlCompany.SelectedValue).Tables[0];
        ddlHrLocation.DataTextField = "HrLocationDesc";
        ddlHrLocation.DataValueField = "HrLocationCode";
        ddlHrLocation.SelectedValue = hfHrLocationCode.Value;
        ddlHrLocation.DataBind();
        if (ddlHrLocation.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlHrLocation.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }
    }

    /// <summary>
    /// Fills The dropdown for Company
    /// </summary>
    private void FillddlCompany()
    {
        ddlCompany.DataSource = _userManagement.UserCompanyAccessGet(BaseUserID).Tables[0];
        ddlCompany.DataTextField = "CompanyDesc";
        ddlCompany.DataValueField = "CompanyCode";
        ddlCompany.SelectedValue = hfCompanyCode.Value;
        ddlCompany.DataBind();
    }

    /// <summary>
    /// Redirects to the Inter Company Transfer Page
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Click</param>
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeInterCompanyTransfer.aspx");
    }

    /// <summary>
    /// Updates Data on Condition Basis
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Click</param>
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        CheckDutyDetails();

    }

    /// <summary>
    /// Updates the data
    /// </summary>
    private void UpdateData()
    {
        if (!string.IsNullOrEmpty(ddlCategory.SelectedItem.Value) && !string.IsNullOrEmpty(ddlDepartment.SelectedItem.Value) && !string.IsNullOrEmpty(ddlJobClass.SelectedItem.Value) && !string.IsNullOrEmpty(ddlJobType.SelectedItem.Value) && !string.IsNullOrEmpty(ddlDesignation.SelectedItem.Value) && !string.IsNullOrEmpty(ddlHrLocation.SelectedItem.Value) && !string.IsNullOrEmpty(ddlLocation.SelectedItem.Value) && !string.IsNullOrEmpty(ddlRole.SelectedItem.Value) && !string.IsNullOrEmpty(ddlAreaID.SelectedItem.Value) && !string.IsNullOrEmpty(ddlGrade.SelectedItem.Value))
        {
            btnUpdate.Enabled = true;
            var flag = 1;
            hfEmpJobTypeEffectiveFrom.Value = DateFormat(DateTime.Parse(hfEmpJobTypeEffectiveFrom.Value));
            hfEmpJobClassEffectiveFrom.Value = DateFormat(DateTime.Parse(hfEmpJobClassEffectiveFrom.Value));
            hflocationEffectiveFrom.Value = DateFormat(DateTime.Parse(hflocationEffectiveFrom.Value));
            hfDesiEffectiveFrom.Value = DateFormat(DateTime.Parse(hfDesiEffectiveFrom.Value));
            hfCatEffectiveFrom.Value = DateFormat(DateTime.Parse(hfCatEffectiveFrom.Value));
            hfRoleEffectiveFrom.Value = DateFormat(DateTime.Parse(hfRoleEffectiveFrom.Value));
            hfDeptEffectiveFrom.Value = DateFormat(DateTime.Parse(hfDeptEffectiveFrom.Value));
            hfAreaEffectiveFrom.Value = DateFormat(DateTime.Parse(hfAreaEffectiveFrom.Value));

            var maxDate = (GetMaxDateFromListDate(DateTime.Parse(hflocationEffectiveFrom.Value), DateTime.Parse(hfDesiEffectiveFrom.Value), DateTime.Parse(hfCatEffectiveFrom.Value), DateTime.Parse(hfEmpJobTypeEffectiveFrom.Value), DateTime.Parse(hfEmpJobClassEffectiveFrom.Value), DateTime.Parse(hfRoleEffectiveFrom.Value), DateTime.Parse(hfAreaEffectiveFrom.Value), DateTime.Parse(hfDeptEffectiveFrom.Value)));

            if (!string.IsNullOrEmpty(txtEffectiveTo.Text))
            {

                if (hfCompanyCode.Value.Equals(ddlCompany.SelectedValue))
                {
                    if (hfRoleCode.Value == ddlRole.SelectedValue && hfDesignationCode.Value == ddlDesignation.SelectedValue && hfGradeCode.Value==ddlGrade.SelectedValue && hfJobTypeCode.Value == ddlJobType.SelectedValue && hfJobClassCode.Value == ddlJobClass.SelectedValue && hfCategoryCode.Value == ddlCategory.SelectedValue && hfDepartmentCode.Value == ddlDepartment.SelectedValue && hfLocationAutoID.Value == ddlLocation.SelectedValue && hfHrLocationCode.Value == ddlHrLocation.SelectedValue && hfAreaID.Value == ddlAreaID.SelectedValue)
                    {
                        lblErrorMsg.Text = Resources.Resource.TransferNotPossible;
                    }
                    else
                    {
                        flag =
                            GetGreaterDate(DateTime.Parse(hflocationEffectiveFrom.Value),
                                           DateTime.Parse(txtEffectiveTo.Text)) ||
                            GetGreaterDate(DateTime.Parse(hfDesiEffectiveFrom.Value),
                                           DateTime.Parse(txtEffectiveTo.Text)) ||
                            GetGreaterDate(DateTime.Parse(hfCatEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) ||
                            GetGreaterDate(DateTime.Parse(hfDeptEffectiveFrom.Value),
                                           DateTime.Parse(txtEffectiveTo.Text)) ||
                            GetGreaterDate(DateTime.Parse(hfEmpJobTypeEffectiveFrom.Value),
                                           DateTime.Parse(txtEffectiveTo.Text)) ||
                            GetGreaterDate(DateTime.Parse(hfEmpJobClassEffectiveFrom.Value),
                                           DateTime.Parse(txtEffectiveTo.Text)) ||
                            GetGreaterDate(DateTime.Parse(hfRoleEffectiveFrom.Value),
                                           DateTime.Parse(txtEffectiveTo.Text)) ||
                            GetGreaterDate(DateTime.Parse(hfAreaEffectiveFrom.Value),
                                           DateTime.Parse(txtEffectiveTo.Text)) && flag == 1
                                ? 0
                                : 1;
                        lblErrorMsg.Text = string.Empty;
                        if (hfLocationAutoID.Value != ddlLocation.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hflocationEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    try
                                    {
                                        var dslocation = _hrManagement.EmployeeLocationUpdate(hfCompanyCode.Value, hfLocationAutoID.Value, lblEmpNumber.Text, lblEmpNumber.Text, ddlLocation.SelectedItem.Value, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value, "");
                                        if (dslocation != null)
                                        {
                                            if (!Equals(dslocation.Tables[0].Rows[0]["MessageID"], "2"))
                                            {
                                                lblErrorMsg.Text = dslocation.Tables[0].Rows[0]["MessageString"].ToString();
                                                //Code added for the Updation of Area when Employee has changed the location
                                                if (ddlAreaID.SelectedValue == hfAreaID.Value)
                                                {

                                                    _hrManagement.EmployeeAreaUpdate(hfCompanyCode.Value,
                                                        lblEmpNumber.Text, hfAreaID.Value, ddlAreaID.SelectedItem.Value,
                                                        txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value);
                                                }
                                            }
                                        }

                                        flag = 1;
                                    }
                                    catch (Exception ex)
                                    {
                                        var objEx = new ExceptionLogs();
                                        objEx.ExceptionLog(ex.ToString(), BaseUserID);
                                    }

                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                    flag = 0;
                                }
                            }
                            else
                            {

                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));//hflocationEffectiveFrom.Value;
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }

                        if (hfDesignationCode.Value != ddlDesignation.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hfDesiEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    _hrManagement.EmployeeDesignationUpdate(hfCompanyCode.Value, lblEmpNumber.Text, lblEmpNumber.Text, hfDesignationCode.Value, ddlDesignation.SelectedItem.Value, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value);
                                    flag = 1;
                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                }
                            }
                            else
                            {
                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));//hfDesiEffectiveFrom.Value;
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }
                        if (hfGradeCode.Value != ddlGrade.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hfDesiEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    _hrManagement.EmployeeGradeUpdate(hfCompanyCode.Value, lblEmpNumber.Text, lblEmpNumber.Text, hfDesignationCode.Value, ddlDesignation.SelectedItem.Value, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value, hfGradeCode.Value, ddlGrade.SelectedValue);
                                    flag = 1;
                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                }
                            }
                            else
                            {
                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));//hfDesiEffectiveFrom.Value;
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }
                        if (hfAreaID.Value != ddlAreaID.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hfAreaEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    _hrManagement.EmployeeAreaUpdate(hfCompanyCode.Value, lblEmpNumber.Text, hfAreaID.Value, ddlAreaID.SelectedItem.Value, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value);
                                    flag = 1;
                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                }
                            }
                            else
                            {

                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }
                        if (hfCategoryCode.Value != ddlCategory.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hfCatEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    _hrManagement.EmployeeCategoryUpdate(hfCompanyCode.Value, lblEmpNumber.Text, lblEmpNumber.Text, hfCategoryCode.Value, ddlCategory.SelectedItem.Value, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value);
                                    flag = 1;
                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                }
                            }
                            else
                            {
                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));// hfCatEffectiveFrom.Value;
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }

                        if (hfDepartmentCode.Value != ddlDepartment.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hfDeptEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    _hrManagement.EmployeeDepartmentUpdate(hfCompanyCode.Value, lblEmpNumber.Text, hfDepartmentCode.Value, ddlDepartment.SelectedItem.Value, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value);
                                    flag = 1;
                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                }
                            }
                            else
                            {

                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));// hfCatEffectiveFrom.Value;
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }


                        if (hfJobClassCode.Value != ddlJobClass.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hfEmpJobClassEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    _hrManagement.EmployeeJobClassUpdate(hfCompanyCode.Value, lblEmpNumber.Text, lblEmpNumber.Text, hfJobClassCode.Value, ddlJobClass.SelectedItem.Value, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value);
                                    flag = 1;
                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                }
                            }
                            else
                            {
                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));// hfEmpJobClassEffectiveFrom.Value;
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }
                        if (hfRoleCode.Value != ddlRole.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hfRoleEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    _hrManagement.EmployeeRoleUpdate(hfCompanyCode.Value, lblEmpNumber.Text, lblEmpNumber.Text, hfRoleCode.Value, ddlRole.SelectedValue, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value);
                                    flag = 1;
                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                }
                            }
                            else
                            {
                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }
                        if (hfJobTypeCode.Value != ddlJobType.SelectedValue)
                        {
                            if (GetGreaterDate(DateTime.Parse(hfEmpJobTypeEffectiveFrom.Value), DateTime.Parse(txtEffectiveTo.Text)) == false)
                            {
                                if (flag == 1)
                                {
                                    _hrManagement.EmployeeJobTypeUpdate(hfCompanyCode.Value, lblEmpNumber.Text, lblEmpNumber.Text, hfJobTypeCode.Value, ddlJobType.SelectedItem.Value, txtEffectiveTo.Text, BaseUserID, hfCompanyCode.Value);
                                    flag = 1;
                                }
                                else
                                {
                                    lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                    txtEffectiveTo.Focus();
                                }
                            }
                            else
                            {

                                lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + DateFormat(DateTime.Parse(maxDate));
                                txtEffectiveTo.Focus();
                                flag = 0;
                            }
                        }

                        if (flag == 1)
                        {

                            Response.Redirect("EmployeeInterCompanyTransfer.aspx");
                        }
                    }
                }
                else
                {
                    var ds = _hrManagement.EmployeeInterCompanyTransferGetMaxDate(hfCompanyCode.Value, lblEmpNumber.Text);
                    var maxFromDate = DateFormat(DateTime.Parse(ds.Tables[0].Rows[0][0].ToString()));
                    if (GetGreaterDate(DateTime.Parse(maxFromDate), DateTime.Parse(txtEffectiveTo.Text)) == false)
                    {


                        _hrManagement.EmployeeInterCompanyTransferUpdate(lblEmpNumber.Text, hfCompanyCode.Value, hfLocationAutoID.Value, hfDesignationCode.Value, hfCategoryCode.Value, hfJobClassCode.Value, hfJobTypeCode.Value, hfRoleCode.Value, hfAreaID.Value, hfDepartmentCode.Value, ddlCompany.SelectedValue, ddlLocation.SelectedItem.Value, ddlDesignation.SelectedItem.Value, ddlCategory.SelectedItem.Value, ddlJobClass.SelectedItem.Value, ddlJobType.SelectedItem.Value, ddlRole.SelectedValue, ddlAreaID.SelectedValue, ddlDepartment.SelectedValue, txtEffectiveTo.Text, BaseUserID, "",hfGradeCode.Value,ddlGrade.SelectedValue);
                        Response.Redirect("EmployeeInterCompanyTransfer.aspx");

                    }
                    else
                    {

                        lblErrorMsg.Text = Resources.Resource.EffectiveTo + @" " + txtEffectiveTo.Text + @" " + Resources.Resource.ShouldbeGreaterthan + @" " + maxFromDate;
                        txtEffectiveTo.Focus();
                    }
                }
            }
        }
        else
        {
            btnUpdate.Enabled = false;
        }
    }

    /// <summary>
    /// Gets Max Date on the basis of different parameters
    /// </summary>
    /// <param name="datelocationEffectiveFrom">Location Effective From</param>
    /// <param name="dateDesiEffectiveFrom">Effective From Date Designation</param>
    /// <param name="dateCatEffectiveFrom">Effective From Date Category</param>
    /// <param name="dateEmpJobTypeEffectiveFrom">Effective From Date Job Type</param>
    /// <param name="dateEmpJobClassEffectiveFrom">Effective From Date Job Class</param>
    /// <param name="dateRoleEffectiveFrom">Effective From Date Role</param>
    /// <param name="dateAreaEffectiveFrom">Effective From Date Area</param>
    /// <param name="dateDeptEffectiveFrom">Effective From Date Department</param>
    /// <returns>System.String.</returns>
    private string GetMaxDateFromListDate(DateTime datelocationEffectiveFrom, DateTime dateDesiEffectiveFrom, DateTime dateCatEffectiveFrom, DateTime dateEmpJobTypeEffectiveFrom, DateTime dateEmpJobClassEffectiveFrom, DateTime dateRoleEffectiveFrom, DateTime dateAreaEffectiveFrom, DateTime dateDeptEffectiveFrom)
    {
        var ds = _hrManagement.MaxDateGet(datelocationEffectiveFrom, dateDesiEffectiveFrom, dateCatEffectiveFrom, dateEmpJobTypeEffectiveFrom, dateEmpJobClassEffectiveFrom, dateRoleEffectiveFrom, dateAreaEffectiveFrom, dateDeptEffectiveFrom);
        var txtMaxDateFromList = DateFormat(ds.Tables[0].Rows[0]["maxDateValue"].ToString());
        return txtMaxDateFromList;
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveTo_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveTo);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromCompany_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromCompany);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromHrLocation_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromHrLocation);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromLocation_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromLocation);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromDesignation_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromDesignation);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromCategory_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromCategory);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromJobType_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromJobType);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromJobClass_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromJobClass);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromDepartment_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromDepartment);
    }

    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromRole_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromRole);
    }


    /// <summary>
    /// Checks if the Date is in correct date format
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Args Onclick</param>
    protected void TxtEffectiveFromAreaID_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromAreaID);
    }

    /// <summary>
    /// Returns Bool value of Date Format
    /// </summary>
    /// <param name="txtDate">TextBox Value</param>
    private void ConvertStringToDateFormat(TextBox txtDate)
    {
        txtDate.BackColor = System.Drawing.Color.Empty;
        var objCommon = new Common();
        if (objCommon.IsValidDate(txtDate.Text))
        {
            txtDate.Text = DateTime.Parse(txtDate.Text).ToString("dd-MMM-yyyy");
        }
        else
        {
            var date = objCommon.ConvertToDate(txtDate.Text);
            switch (date)
            {
                case "1":
                    lblErrorMsg.Text = Resources.Resource.Yearnotincorrectformat;
                    txtDate.Text = txtDate.Text;
                    txtDate.BackColor = System.Drawing.Color.Red;
                    break;
                case "2":
                    lblErrorMsg.Text = Resources.Resource.Monthnotincorrectformat;
                    txtDate.Text = txtDate.Text;
                    txtDate.BackColor = System.Drawing.Color.Red;
                    break;
                case "3":
                    lblErrorMsg.Text = Resources.Resource.Daynotincorrectformat;
                    txtDate.Text = txtDate.Text;
                    txtDate.BackColor = System.Drawing.Color.Red;
                    break;
                case "4":
                    lblErrorMsg.Text = Resources.Resource.Notaleapyear;
                    txtDate.Text = txtDate.Text;
                    txtDate.BackColor = System.Drawing.Color.Red;
                    break;
                case "5":
                    lblErrorMsg.Text = Resources.Resource.Numberofdaysnotcorrect;
                    txtDate.Text = txtDate.Text;
                    txtDate.BackColor = System.Drawing.Color.Red;
                    break;
                case "6":
                    lblErrorMsg.Text = Resources.Resource.Datenotincorrectformat;
                    txtDate.Text = txtDate.Text;
                    txtDate.BackColor = System.Drawing.Color.Red;
                    break;
                default:
                    txtDate.Text = date;
                    txtDate.BackColor = System.Drawing.Color.Empty;
                    break;
            }
        }
    }

    /// <summary>
    /// Enables the CheckBox on the CheckBox Company
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBCompany_CheckedChanged(object sender, EventArgs e)
    {
        if (CBCompany.Checked)
        {
            CBCategory.Checked = true;
            CBDesignation.Checked = true;
            CBGrade.Checked = true;
            CBHrLocation.Checked = true;
            CBJobClass.Checked = true;
            CBJobType.Checked = true;
            CBRole.Checked = true;
            CBAreaID.Checked = true;
            CBDepartment.Checked = true;
            CBLocation.Checked = true;

            CBCategory.Enabled = false;
            CBDesignation.Enabled = false;
            CBGrade.Enabled = false;
            CBHrLocation.Enabled = false;
            CBJobClass.Enabled = false;
            CBJobType.Enabled = false;
            CBRole.Enabled = false;
            CBAreaID.Enabled = false;
            CBDepartment.Enabled = false;
            CBLocation.Enabled = false;

            txtEffectiveFromCompany.Enabled = true;
            imgEffectiveFromCompany.Visible = false;
            txtEffectiveFromCategory.Enabled = false;
            txtEffectiveFromDesignation.Enabled = false;
            txtEffectiveFromGrade.Enabled = false;
            txtEffectiveFromHrLocation.Enabled = false;
            txtEffectiveFromJobClass.Enabled = false;
            txtEffectiveFromJobType.Enabled = false;
            txtEffectiveFromLocation.Enabled = false;
            txtEffectiveFromRole.Enabled = false;
            txtEffectiveFromAreaID.Enabled = false;
            txtEffectiveFromDepartment.Enabled = false;

            imgEffectiveFromCategory.Visible = false;
            imgEffectiveFromDesignation.Visible = false;
            imgEffectiveFromGrade.Visible = false;
            imgEffectiveFromHrLocation.Visible = false;
            imgEffectiveFromJobClass.Visible = false;
            imgEffectiveFromJobType.Visible = false;
            imgEffectiveFromLocation.Visible = false;
            ImgEffectiveFromRole.Visible = false;
            imgEffectiveFromAreaID.Visible = false;
            imgEffectiveFromDepartment.Visible = false;

            ddlCompany.Enabled = true;
            ddlCategory.Enabled = true;
            ddlDesignation.Enabled = true;
            ddlGrade.Enabled = true;
            ddlHrLocation.Enabled = true;
            ddlJobClass.Enabled = true;
            ddlJobType.Enabled = true;
            ddlLocation.Enabled = true;
            ddlRole.Enabled = true;
            ddlAreaID.Enabled = true;
            ddlDepartment.Enabled = true;
        }
        else
        {
            CBCategory.Checked = false;
            CBDepartment.Checked = false;
            CBDesignation.Checked = false;
            CBGrade.Checked = false;
            CBHrLocation.Checked = false;
            CBJobClass.Checked = false;
            CBJobType.Checked = false;
            CBLocation.Checked = false;
            CBRole.Checked = false;
            CBAreaID.Checked = false;

            CBCategory.Enabled = true;
            CBDepartment.Enabled = true;
            CBDesignation.Enabled = true;
            CBGrade.Enabled = true;
            CBHrLocation.Enabled = true;
            CBJobClass.Enabled = true;
            CBJobType.Enabled = true;
            CBLocation.Enabled = true;
            CBRole.Enabled = true;
            CBAreaID.Enabled = true;

            txtEffectiveFromCompany.Enabled = false;
            imgEffectiveFromCompany.Visible = false;
            txtEffectiveFromCategory.Enabled = false;
            txtEffectiveFromDesignation.Enabled = false;
            txtEffectiveFromGrade.Enabled = false;
            txtEffectiveFromHrLocation.Enabled = false;
            txtEffectiveFromJobClass.Enabled = false;
            txtEffectiveFromJobType.Enabled = false;
            txtEffectiveFromLocation.Enabled = false;
            txtEffectiveFromRole.Enabled = false;
            txtEffectiveFromAreaID.Enabled = false;
            txtEffectiveFromDepartment.Enabled = false;

            imgEffectiveFromCategory.Visible = false;
            imgEffectiveFromDesignation.Visible = false;
            imgEffectiveFromGrade.Visible = false;
            imgEffectiveFromHrLocation.Visible = false;
            imgEffectiveFromJobClass.Visible = false;
            imgEffectiveFromJobType.Visible = false;
            imgEffectiveFromLocation.Visible = false;
            ImgEffectiveFromRole.Visible = false;
            imgEffectiveFromAreaID.Visible = false;
            imgEffectiveFromDepartment.Visible = false;

            ddlCompany.Enabled = false;
            ddlCategory.Enabled = false;
            ddlDesignation.Enabled = false;
            ddlGrade.Enabled = false;
            ddlHrLocation.Enabled = false;
            ddlJobClass.Enabled = false;
            ddlJobType.Enabled = false;
            ddlLocation.Enabled = false;
            ddlRole.Enabled = false;
            ddlAreaID.Enabled = false;
            ddlDepartment.Enabled = false;

            FillddlCompany();
            DdlCompany_SelectedIndexChanged(sender, e);
            txtEffectiveFromCompany.Text = HFEffectiveFromCompany.Value;
        }
        btnCorrection.Enabled = CheckBoxStatus();
    }
    /// <summary>
    /// Enables the CheckBox on the CheckBox Divison
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBHrLocation_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBHrLocation.Checked)
        {
            txtEffectiveFromHrLocation.Enabled = true;
            imgEffectiveFromHrLocation.Visible = false;
            ddlHrLocation.Enabled = true;
            ddlLocation.Enabled = true;
            ddlDesignation.Enabled = true;
            ddlGrade.Enabled = true;
            ddlCategory.Enabled = true;
            ddlDepartment.Enabled = true;
            ddlJobClass.Enabled = true;
            ddlJobType.Enabled = true;
            ddlRole.Enabled = true;
            ddlAreaID.Enabled = true;

            CBRole.Checked = true;
            CBAreaID.Checked = true;

            CBRole.Enabled = false;
            CBAreaID.Enabled = false;
            CBDepartment.Checked = true;
            CBDepartment.Enabled = false;
            CBLocation.Checked = true;
            CBLocation.Enabled = false;
            CBDesignation.Checked = true;
            CBDesignation.Enabled = false;
            CBGrade.Checked = true;
            CBGrade.Enabled = false;
            CBCategory.Checked = true;
            CBCategory.Enabled = false;
            CBJobType.Checked = true;
            CBJobType.Enabled = false;
            CBJobClass.Checked = true;
            CBJobClass.Enabled = false;
        }
        else
        {
            txtEffectiveFromHrLocation.Enabled = false;
            imgEffectiveFromHrLocation.Visible = false;
            ddlHrLocation.Enabled = false;
            ddlLocation.Enabled = false;
            CBLocation.Checked = false;
            CBLocation.Enabled = true;

            ddlDesignation.Enabled = false;
            ddlGrade.Enabled = false;
            CBDesignation.Checked = false;
            CBDesignation.Enabled = true;
            CBGrade.Checked = false;
            CBGrade.Enabled = true;
            ddlCategory.Enabled = false;
            CBCategory.Checked = false;
            CBCategory.Enabled = true;

            ddlDepartment.Enabled = false;
            CBDepartment.Checked = false;
            CBDepartment.Enabled = true;

            ddlJobType.Enabled = false;
            CBJobType.Checked = false;
            CBJobType.Enabled = true;

            ddlRole.Enabled = false;
            CBRole.Checked = false;
            CBRole.Enabled = true;

            ddlAreaID.Enabled = false;
            CBAreaID.Checked = false;
            CBAreaID.Enabled = true;

            ddlJobClass.Enabled = false;
            CBJobClass.Checked = false;
            CBJobClass.Enabled = true;

            FillddlHrLocation();
            DdlHrLocation_SelectedIndexChanged(sender, e);
            txtEffectiveFromHrLocation.Text = HFEffectiveFromHrLocation.Value;
        }
    }

    /// <summary>
    /// Enables the CheckBox on the CheckBox Location
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBLocation_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBLocation.Checked)
        {
            txtEffectiveFromLocation.Enabled = true;
            imgEffectiveFromLocation.Visible = false;
            ddlLocation.Enabled = true;

            ddlDesignation.Enabled = true;
            ddlGrade.Enabled = true;
            ddlCategory.Enabled = true;
            ddlJobClass.Enabled = true;
            ddlRole.Enabled = true;
            ddlAreaID.Enabled = true;
            ddlDepartment.Enabled = true;

            ddlJobType.Enabled = true;
            CBDesignation.Checked = true;
            CBDesignation.Enabled = false;
            CBGrade.Checked = true;
            CBGrade.Enabled = false;
            CBCategory.Checked = true;
            CBCategory.Enabled = false;
            CBJobType.Checked = true;
            CBJobType.Enabled = false;

            CBDepartment.Checked = true;
            CBDepartment.Enabled = false;

            CBJobClass.Checked = true;
            CBJobClass.Enabled = false;
            CBRole.Checked = true;
            CBRole.Enabled = false;
            CBAreaID.Checked = true;
            CBAreaID.Enabled = false;
        }
        else
        {
            txtEffectiveFromLocation.Enabled = false;
            imgEffectiveFromLocation.Visible = false;

            ddlLocation.Enabled = false;
            CBLocation.Enabled = true;

            ddlDesignation.Enabled = false;
            ddlGrade.Enabled = false;
            CBDesignation.Checked = false;
            CBDesignation.Enabled = true;
            CBGrade.Checked = false;
            CBGrade.Enabled = true;
            ddlCategory.Enabled = false;
            CBCategory.Checked = false;
            CBCategory.Enabled = true;

            ddlJobType.Enabled = false;
            CBJobType.Checked = false;
            CBJobType.Enabled = true;

            ddlDepartment.Enabled = false;
            CBDepartment.Checked = false;
            CBDepartment.Enabled = true;

            ddlRole.Enabled = false;
            CBRole.Checked = false;
            CBRole.Enabled = true;

            CBAreaID.Checked = false;
            CBAreaID.Enabled = true;
            ddlAreaID.Enabled = false;



            ddlJobClass.Enabled = false;
            CBJobClass.Checked = false;
            CBJobClass.Enabled = true;


            FillddlCompany();
            FillddlCategory();
            FillddlDepartment();
            FillddlDesignation();
            FillddlGrade();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlRole();
            FillddlAreaId();
            FillddlLocation();
            txtEffectiveFromLocation.Text = HFEffectiveFromLocation.Value;
        }
    }

    /// <summary>
    /// Enables the CheckBox
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBDesignation_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBDesignation.Checked)
        {
            txtEffectiveFromDesignation.Enabled = true;
            imgEffectiveFromDesignation.Visible = false;
            ddlDesignation.Enabled = true;
        }
        else
        {
            txtEffectiveFromDesignation.Enabled = false;
            imgEffectiveFromDesignation.Visible = false;
            ddlDesignation.Enabled = false;
            FillddlCompany();
            FillddlCategory();
            FillddlDesignation();
          FillddlGrade();
            FillddlDepartment();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlRole();
            FillddlAreaId();
            FillddlLocation();
            txtEffectiveFromDesignation.Text = HFEffectiveFromDesignation.Value;
        }
    }

    /// <summary>
    /// Enables the CheckBox on the CheckBox Category
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBCategory_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBCategory.Checked)
        {
            txtEffectiveFromCategory.Enabled = true;
            imgEffectiveFromCategory.Visible = false;
            ddlCategory.Enabled = true;
        }
        else
        {
            txtEffectiveFromCategory.Enabled = false;
            ddlCategory.Enabled = false;
            FillddlCompany();
            FillddlCategory();
            FillddlDesignation();
            FillddlGrade();
            FillddlDepartment();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlRole();
            FillddlAreaId();
            FillddlLocation();
            imgEffectiveFromCategory.Visible = false;
            txtEffectiveFromCategory.Text = HFEffectiveFromCategory.Value;
        }
    }

    /// <summary>
    /// Enables the CheckBox on the CheckBox Department
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBDepartment_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBDepartment.Checked)
        {
            txtEffectiveFromDepartment.Enabled = true;
            imgEffectiveFromDepartment.Visible = false;
            ddlDepartment.Enabled = true;
        }
        else
        {
            txtEffectiveFromDepartment.Enabled = false;
            ddlDepartment.Enabled = false;
            FillddlCompany();
            FillddlCategory();
            FillddlDepartment();
            FillddlDesignation();
            FillddlGrade();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlRole();
            FillddlLocation();
            FillddlAreaId();
            imgEffectiveFromDepartment.Visible = false;
            txtEffectiveFromDepartment.Text = HFEffectiveFromDepartment.Value;
        }
    }

    /// <summary>
    /// Enables the CheckBox on the CheckBox Job Type
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBJobType_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBJobType.Checked)
        {
            txtEffectiveFromJobType.Enabled = true;
            imgEffectiveFromJobType.Visible = false;
            ddlJobType.Enabled = true;
        }
        else
        {
            txtEffectiveFromJobType.Enabled = false;
            imgEffectiveFromJobType.Visible = false;
            ddlJobType.Enabled = false;
            FillddlCompany();
            FillddlCategory();
            FillddlDesignation();
            FillddlGrade();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlDepartment();
            FillddlRole();
            FillddlAreaId();
            FillddlLocation();
            txtEffectiveFromJobType.Text = HFEffectiveFromJobType.Value;
        }
    }

    /// <summary>
    /// Enables the CheckBox on the CheckBox Job Class
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBJobClass_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBJobClass.Checked)
        {
            txtEffectiveFromJobClass.Enabled = true;
            imgEffectiveFromJobClass.Visible = false;
            ddlJobClass.Enabled = true;
        }
        else
        {
            txtEffectiveFromJobClass.Enabled = false;
            imgEffectiveFromJobClass.Visible = false;
            ddlJobClass.Enabled = false;
            FillddlCompany();
            FillddlCategory();
            FillddlDesignation();
            FillddlGrade();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlLocation();
            FillddlRole();
            FillddlDepartment();
            FillddlAreaId();
            txtEffectiveFromJobClass.Text = HFEffectiveFromJobClass.Value;
        }
    }

    /// <summary>
    /// Enables the CheckBox on the CheckBox Role
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBRole_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBRole.Checked)
        {
            txtEffectiveFromRole.Enabled = true;
            ImgEffectiveFromRole.Visible = false;
            ddlRole.Enabled = true;
        }
        else
        {
            txtEffectiveFromRole.Enabled = false;
            ImgEffectiveFromRole.Visible = false;
            ddlRole.Enabled = false;
            FillddlCompany();
            FillddlCategory();
            FillddlDesignation();
            FillddlGrade();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlLocation();
            FillddlRole();
            FillddlAreaId();
            FillddlDepartment();
            txtEffectiveFromRole.Text = HFEffectiveFromRole.Value;
        }
    }

    /// <summary>
    /// Enables the CheckBox on the CheckBox AreaID
    /// </summary>
    /// <param name="sender">Sender Object CheckBox</param>
    /// <param name="e">Event Args CheckBox</param>
    protected void CBAreaID_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBAreaID.Checked)
        {
            txtEffectiveFromAreaID.Enabled = true;
            imgEffectiveFromAreaID.Visible = false;
            ddlAreaID.Enabled = true;
        }
        else
        {
            txtEffectiveFromAreaID.Enabled = false;
            imgEffectiveFromAreaID.Visible = false;
            ddlAreaID.Enabled = false;
            FillddlCompany();
            FillddlCategory();
            FillddlDesignation();
            FillddlGrade();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlLocation();
            FillddlRole();
            FillddlAreaId();
            FillddlDepartment();
            txtEffectiveFromAreaID.Text = HFEffectiveFromArea.Value;
        }
    }

    /// <summary>
    /// Enables all Objects to True
    /// </summary>
    private void EnableDropDown()
    {
        ddlCompany.Enabled = true;
        ddlHrLocation.Enabled = true;
        ddlLocation.Enabled = true;
        ddlJobType.Enabled = true;
        ddlJobClass.Enabled = true;
        ddlCategory.Enabled = true;
        ddlDepartment.Enabled = true;
        ddlDesignation.Enabled = true;
        ddlGrade.Enabled = true;
        ddlRole.Enabled = true;

        ddlAreaID.Enabled = true;

        txtEffectiveFromRole.Enabled = true;
        ImgEffectiveFromRole.Visible = true;

        txtEffectiveFromAreaID.Enabled = true;
        imgEffectiveFromAreaID.Visible = true;
        txtEffectiveFromDepartment.Enabled = true;
        imgEffectiveFromDepartment.Visible = true;
        txtEffectiveFromCategory.Enabled = true;
        imgEffectiveFromCategory.Visible = true;
        txtEffectiveFromCompany.Enabled = true;
        imgEffectiveFromCompany.Visible = true;
        txtEffectiveFromDesignation.Enabled = true;
        imgEffectiveFromDesignation.Visible = true;
        txtEffectiveFromGrade.Enabled = true;
        imgEffectiveFromGrade.Visible = true;
        txtEffectiveFromHrLocation.Enabled = true;
        imgEffectiveFromHrLocation.Visible = true;
        txtEffectiveFromJobClass.Enabled = true;
        imgEffectiveFromJobClass.Visible = true;
        txtEffectiveFromJobType.Enabled = true;
        imgEffectiveFromJobType.Visible = true;
        txtEffectiveFromLocation.Enabled = true;
        imgEffectiveFromLocation.Visible = true;
    }

    /// <summary>
    /// Enables all Objects to False
    /// </summary>
    private void DisableDropDown()
    {
        ddlCompany.Enabled = false;
        ddlHrLocation.Enabled = false;
        ddlLocation.Enabled = false;
        ddlJobType.Enabled = false;
        ddlJobClass.Enabled = false;
        ddlCategory.Enabled = false;
        ddlDepartment.Enabled = false;
        ddlDesignation.Enabled = false;
        ddlGrade.Enabled = false;
        ddlRole.Enabled = false;

        ddlAreaID.Enabled = false;

        txtEffectiveFromCategory.Enabled = false;
        imgEffectiveFromCategory.Visible = false;
        txtEffectiveFromRole.Enabled = false;
        ImgEffectiveFromRole.Visible = false;

        txtEffectiveFromAreaID.Enabled = false;
        imgEffectiveFromAreaID.Visible = false;
        txtEffectiveFromDepartment.Enabled = false;
        imgEffectiveFromDepartment.Visible = false;
        txtEffectiveFromCompany.Enabled = false;
        imgEffectiveFromCompany.Visible = false;
        txtEffectiveFromDesignation.Enabled = false;
        imgEffectiveFromDesignation.Visible = false;
        txtEffectiveFromGrade.Enabled = false;
        imgEffectiveFromGrade.Visible = false;
        txtEffectiveFromHrLocation.Enabled = false;
        imgEffectiveFromHrLocation.Visible = false;
        txtEffectiveFromJobClass.Enabled = false;
        imgEffectiveFromJobClass.Visible = false;
        txtEffectiveFromJobType.Enabled = false;
        imgEffectiveFromJobType.Visible = false;
        txtEffectiveFromLocation.Enabled = false;
        imgEffectiveFromLocation.Visible = false;

    }
    /// <summary>
    /// Gets the Check box Status
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
    private bool CheckBoxStatus()
    {
        return CBAreaID.Checked || CBRole.Checked || CBCategory.Checked || CBDepartment.Checked || CBCompany.Checked || CBDesignation.Checked || CBHrLocation.Checked || CBJobClass.Checked || CBJobType.Checked || CBLocation.Checked || CBGrade.Checked;
    }
    /// <summary>
    /// Gets all Effective From Date for all Values
    /// </summary>
    private void GetEffectiveFromDate()
    {
        var locationAutoId = ddlLocation.SelectedValue == "" ? 0 : int.Parse(ddlLocation.SelectedValue);
        var ds = _hrManagement.EmployeeInterCompanyTransferGetAllEffectiveFromDate(lblEmpNumber.Text, ddlCompany.SelectedValue, locationAutoId);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            txtEffectiveFromCategory.Text = ds.Tables[0].Rows[0]["EffectiveFromCategory"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromCategory"].ToString()) : "";

            txtEffectiveFromDepartment.Text = ds.Tables[0].Rows[0]["EffectiveFromDepartment"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromDepartment"].ToString()) : "";

            txtEffectiveFromCompany.Text = ds.Tables[0].Rows[0]["EffectiveFromCompany"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromCompany"].ToString()) : "";
            txtEffectiveFromDesignation.Text = ds.Tables[0].Rows[0]["EffectiveFromDesignation"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromDesignation"].ToString()) : "";
            txtEffectiveFromHrLocation.Text = ds.Tables[0].Rows[0]["EffectiveFromLocation"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromLocation"].ToString()) : "";
            txtEffectiveFromJobClass.Text = ds.Tables[0].Rows[0]["EffectiveFromJobClass"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromJobClass"].ToString()) : "";
            txtEffectiveFromJobType.Text = ds.Tables[0].Rows[0]["EffectiveFromJobType"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromJobType"].ToString()) : "";
            txtEffectiveFromLocation.Text = ds.Tables[0].Rows[0]["EffectiveFromLocation"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromLocation"].ToString()) : "";
            txtEffectiveFromRole.Text = ds.Tables[0].Rows[0]["EffectiveFromRole"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromRole"].ToString()) : "";
            txtEffectiveFromAreaID.Text = ds.Tables[0].Rows[0]["EffectiveFromAreaID"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromAreaID"].ToString()) : "";
            txtEffectiveFromGrade.Text = ds.Tables[0].Rows[0]["EffectiveFromGrade"].ToString() != "" ? DateFormat(ds.Tables[0].Rows[0]["EffectiveFromGrade"].ToString()) : "";


        }
        else
        {
            txtEffectiveFromCategory.Text = "";
            txtEffectiveFromDepartment.Text = "";
            txtEffectiveFromCompany.Text = "";
            txtEffectiveFromDesignation.Text = "";
            txtEffectiveFromHrLocation.Text = "";
            txtEffectiveFromJobClass.Text = "";
            txtEffectiveFromJobType.Text = "";
            txtEffectiveFromLocation.Text = "";
            txtEffectiveFromRole.Text = "";
            txtEffectiveFromAreaID.Text = "";
            txtEffectiveFromGrade.Text = "";

        }

        HFEffectiveFromCategory.Value = txtEffectiveFromCategory.Text;
        HFEffectiveFromDepartment.Value = txtEffectiveFromDepartment.Text;
        HFEffectiveFromCompany.Value = txtEffectiveFromCompany.Text;
        HFEffectiveFromDesignation.Value = txtEffectiveFromDesignation.Text;
        HFEffectiveFromHrLocation.Value = txtEffectiveFromHrLocation.Text;
        HFEffectiveFromJobClass.Value = txtEffectiveFromJobClass.Text;
        HFEffectiveFromJobType.Value = txtEffectiveFromJobType.Text;
        HFEffectiveFromLocation.Value = txtEffectiveFromLocation.Text;
        HFEffectiveFromRole.Value = txtEffectiveFromRole.Text;
        HFEffectiveFromGrade.Value = txtEffectiveFromGrade.Text;
        HFEffectiveFromArea.Value = txtEffectiveFromAreaID.Text;

        GetEmployeeTransactionCount();
    }

    /// <summary>
    /// Gets Count Value for all
    /// </summary>
    private void GetEmployeeTransactionCount()
    {
        var locationAutoId = ddlLocation.SelectedValue == "" ? 0 : int.Parse(ddlLocation.SelectedValue);
        if (_hrManagement == null) return;
        var ds = _hrManagement.EmployeeTransactionCountGet(lblEmpNumber.Text, ddlCompany.SelectedValue, locationAutoId);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            HFCompanyCount.Value = ds.Tables[0].Rows[0]["EmployeeCompanyCount"].ToString();
            HFCategoryCount.Value = ds.Tables[0].Rows[0]["EmployeeCategoryCount"].ToString();
            HFDesignationCount.Value = ds.Tables[0].Rows[0]["EmployeeDesignationCount"].ToString();
            HFDepartmentCount.Value = ds.Tables[0].Rows[0]["EmployeeDepartmentCount"].ToString();
            HFLocationCount.Value = ds.Tables[0].Rows[0]["EmployeeLocationCount"].ToString();
            HFHrLocationCount.Value = ds.Tables[0].Rows[0]["EmployeeLocationCount"].ToString();
            HFJobClassCount.Value = ds.Tables[0].Rows[0]["EmployeeJobClassCount"].ToString();
            HFJobTypeCount.Value = ds.Tables[0].Rows[0]["EmployeeJobTypeCount"].ToString();
            HFRoleCount.Value = ds.Tables[0].Rows[0]["EmployeeRoleCount"].ToString();

            HFAreaCount.Value = ds.Tables[0].Rows[0]["EmployeeAreaCount"].ToString();
        }
        else
        {
            HFCompanyCount.Value = "0";
            HFCategoryCount.Value = "0";
            HFDesignationCount.Value = "0";
            HFDepartmentCount.Value = "0";
            HFLocationCount.Value = "0";
            HFHrLocationCount.Value = "0";
            HFJobClassCount.Value = "0";
            HFJobTypeCount.Value = "0";
            HFRoleCount.Value = "0";
            HFAreaCount.Value = "0";
        }
        ds = _hrManagement.EmployeeTransactionCountGet(lblEmpNumber.Text, BaseCompanyCode, int.Parse(hfLocationAutoID.Value));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            HFOldCompanyCount.Value = ds.Tables[0].Rows[0]["EmployeeCompanyCount"].ToString();
            HFOldCategoryCount.Value = ds.Tables[0].Rows[0]["EmployeeCategoryCount"].ToString();
            HFOldDesignationCount.Value = ds.Tables[0].Rows[0]["EmployeeDesignationCount"].ToString();
            HFOldDepartmentCount.Value = ds.Tables[0].Rows[0]["EmployeeDepartmentCount"].ToString();
            HFOldLocationCount.Value = ds.Tables[0].Rows[0]["EmployeeLocationCount"].ToString();
            HFOldHrLocationCount.Value = ds.Tables[0].Rows[0]["EmployeeLocationCount"].ToString();
            HFOldJobClassCount.Value = ds.Tables[0].Rows[0]["EmployeeJobClassCount"].ToString();
            HFOldJobTypeCount.Value = ds.Tables[0].Rows[0]["EmployeeJobTypeCount"].ToString();
            HFOldRoleCount.Value = ds.Tables[0].Rows[0]["EmployeeRoleCount"].ToString();
            HFOldAreaCount.Value = ds.Tables[0].Rows[0]["EmployeeAreaCount"].ToString();
        }
        else
        {
            HFOldCompanyCount.Value = "0";
            HFOldCategoryCount.Value = "0";
            HFOldDesignationCount.Value = "0";
            HFOldDepartmentCount.Value = "0";
            HFOldLocationCount.Value = "0";
            HFOldHrLocationCount.Value = "0";
            HFOldJobClassCount.Value = "0";
            HFOldJobTypeCount.Value = "0";
            HFOldRoleCount.Value = "0";
            HFOldAreaCount.Value = "0";
        }
    }
    /// <summary>
    /// Fills Employee Details bases for all Parameters
    /// </summary>
    private void FillEmployeeDetails()
    {

        FillddlCompany();
        FillddlHrLocation();
        FillddlLocation();
        FillddlDesignation();
        FillddlGrade();
        FillddlDepartment();
        FillddlCategory();
        FillddlJobType();
        FillddlJobClass();
        FillddlRole();
        FillddlAreaId();
        GetEffectiveFromDate();


    }

    /// <summary>
    /// Fills Role Drop Down
    /// </summary>
    private void FillddlRole()
    {
        if (_mastersManagement != null)
        {
            var ds = _mastersManagement.RoleGet(BaseCompanyCode);
            ddlRole.DataSource = ds.Tables[0];
        }
        ddlRole.DataTextField = "RoleDesc";
        ddlRole.DataValueField = "RoleCode";
        ddlRole.SelectedValue = hfRoleCode.Value;
        ddlRole.DataBind();

        if (ddlRole.Text == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };

            ddlRole.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }


    }

    /// <summary>
    /// Enables Grid View Row to Edit
    /// </summary>
    /// <param name="sender">Sender Object Grid</param>
    /// <param name="e">Image Click Event Args</param>
    protected void IBEditTran_Click(object sender, ImageClickEventArgs e)
    {
        btnRollback.Visible = false;
        btnCorrection.Visible = false;
        btnUpdate.Visible = true;
        txtEffectiveTo.Visible = true;
        imgDate.Visible = true;
        lblEffectiveTo.Visible = true;

        EnableDropDown();
        txtEffectiveTo.Text = "";
        imgDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtEffectiveTo.ClientID + "');";

        FillEmployeeDetails();
    }

    /// <summary>
    /// Nothing mentioned
    /// </summary>
    /// <param name="sender">Object Sender Button</param>
    /// <param name="e">Event Args Click</param>
    protected void BtnRollback_Click(object sender, EventArgs e)
    {
    }

    #region AJAX Methods
    /// <summary>
    /// Returns the Key Value for the Culture
    /// </summary>
    /// <param name="strKey">strKey</param>
    /// <param name="name">Name</param>
    /// <param name="locale">Locale</param>
    /// <returns>Returns the Key Value for the Culture</returns>
    [Ajax.AjaxMethod]

    public string Resourcevalue(string strKey, string name, string locale)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
        return ResourceValueOfKey_Get(strKey);
    }
    #endregion

    /// <summary>
    /// Gives the Error Details
    /// </summary>
    private void CheckDutyDetails()
    {
        DataSet ds;

        if (hfCompanyCode.Value.Equals(ddlCompany.SelectedValue) && hfHrLocationCode.Value.Equals(ddlHrLocation.SelectedValue) && hfLocationCode.Value.Equals(ddlLocation.SelectedValue))
        {
            ds = null;
        }
        else
        {
            ds = _hrManagement.GetErrorDetails(lblEmpNumber.Text, txtEffectiveTo.Text, BaseLocationAutoID);
        }
        if (ds != null && ds.Tables.Count > 0)
        {
            var dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {

                UpdateData();
                MPE.Hide();
                return;

            }
            gvErrorMessage.DataSource = dt;
            gvErrorMessage.DataBind();
            MPE.Show();
        }
        else
        {
            UpdateData();
            MPE.Hide();

        }


    }

    /// <summary>
    /// Delete the Rota Details for the Employee
    /// </summary>
    /// <param name="sender">Object Sender Button</param>
    /// <param name="e">Event Args Click</param>
    protected void BtnDeleteRota_Click(object sender, EventArgs e)
    {
        var objRoster = new Roster();
        var ds = objRoster.DeleteScheduleAndActual(BaseLocationAutoID, lblEmpNumber.Text, txtEffectiveTo.Text);
        ds.Dispose();
        UpdateData();
        MPE.Hide();
    }

    /// <summary>
    /// Closes the MPE
    /// </summary>
    /// <param name="sender">Object Sender Button</param>
    /// <param name="e">Event Args Click</param>
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        MPE.Hide();
    }

    /// <summary>
    /// Returns the Error Details in Grid View
    /// </summary>
    /// <param name="sender">Object Sender Grid</param>
    /// <param name="e">GridView Row Event Args</param>
    protected void GvErrorMessage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            var hfMessageId = (HiddenField)e.Row.FindControl("HFMessageID");
            if (hfMessageId != null)
            {
                btnDeleteRota.Visible = hfMessageId.Value != "101";

            }
        }
    }
    protected void CBGrade_CheckedChanged(object sender, EventArgs e)
    {
        btnCorrection.Enabled = CheckBoxStatus();
        if (CBGrade.Checked)
        {
            txtEffectiveFromGrade.Enabled = true;
            imgEffectiveFromGrade.Visible = false;
            ddlGrade.Enabled = true;
        }
        else
        {
            txtEffectiveFromGrade.Enabled = false;
            imgEffectiveFromGrade.Visible = false;
            ddlGrade.Enabled = false;
            FillddlCompany();
            FillddlCategory();
            FillddlDesignation();
            FillddlGrade();
            FillddlDepartment();
            FillddlHrLocation();
            FillddlJobClass();
            FillddlJobType();
            FillddlRole();
            FillddlAreaId();
            FillddlLocation();
            txtEffectiveFromGrade.Text = HFEffectiveFromGrade.Value;
        }

    }
    protected void txtEffectiveFromGrade_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtEffectiveFromGrade);
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        var objMastersManagement = new BL.MastersManagement();
        ddlGrade.DataSource = objMastersManagement.GradeMasterGetAll(ddlCompany.SelectedValue, ddlDesignation.SelectedItem.Value);
        ddlGrade.DataTextField = "GradeDesc";
        ddlGrade.DataValueField = "GradeCode";
        ddlGrade.DataBind();
        if (ddlGrade.SelectedValue == "")
        {
            var li = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlGrade.Items.Add(li);
            btnUpdate.Enabled = false;
            btnCorrection.Enabled = false;
            btnRollback.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
            btnCorrection.Enabled = true;
            btnRollback.Enabled = true;
        }

    }
}
