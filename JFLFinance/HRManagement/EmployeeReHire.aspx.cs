// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By :  Akhtar
// Last Modified On : 04-Mar-2014
// Purpose          :Comments added for method,class
// ***********************************************************************
// <copyright file="EmployeeReHire.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


/// <summary>
/// HRManagement_EmployeeReHire Code Behind
/// </summary>
public partial class HRManagement_EmployeeReHire : BasePage
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
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                FillgvEmployeeReHire(BaseCompanyCode);
                btnUpdate.Attributes.Add("onclick", "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');");
                txtDateOfJoining.Attributes.Add("ontextChanged", "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');");
                FillddlSearchBy();
            }
        }
    }

    /// <summary>
    /// Will fill the grid of rehired Employee.
    /// </summary>
    /// <param name="CompanyCode">Company Code of an Employee</param>
    private void FillgvEmployeeReHire(string CompanyCode)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        DataTable dtEmployeeReHire = new DataTable();
        ds = objHRManagement.RehiredEmployeeGetAll(CompanyCode);
        dtEmployeeReHire = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtEmployeeReHire.Rows.Count > 0)
        {
            gvEmployeeReHire.DataSource = dtEmployeeReHire;
            gvEmployeeReHire.DataBind();
        }
        else
        {
            dtEmployeeReHire.Rows.Add(dtEmployeeReHire.NewRow());
            gvEmployeeReHire.DataSource = dtEmployeeReHire;
            gvEmployeeReHire.DataBind();
            int TotalColumns = gvEmployeeReHire.Rows[0].Cells.Count;
            gvEmployeeReHire.Rows[0].Cells.Clear();
            gvEmployeeReHire.Rows[0].Cells.Add(new TableCell());
            gvEmployeeReHire.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvEmployeeReHire.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
            
        }

    }

    /// <summary>
    /// Will select the particular Employee.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ddlSearchBy.Visible = false;
        txtSearch.Visible = false;
        btnViewAll.Visible = false;
        Button1.Visible = false;

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        txtDateOfJoining.Text = "";
        ImageButton objImageButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objImageButton.NamingContainer;
        MultiViewShowDetail.Visible = false;
        imgDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtDateOfJoining.ClientID.ToString() + "');";
        Label lblEmployeeNumber = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        Label lblFirstName = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblFirstName");
        Label lblLastName = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblLastName");
        Label lblDesignationDesc = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblDesignationDesc");
        Label lblCategoryDesc = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblCategoryDesc");
        Label lblDepartmentDesc = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblDepartmentDesc");
        Label lblDateOfJoining = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblDateOfJoining");
        Label lblDateOfResignation = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblDateOfResignation");
        Label lblResignationTerminationStatus = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblResignationTerminationStatus");
        Label lblSuitableForRehire = (Label)gvEmployeeReHire.Rows[row.RowIndex].FindControl("lblSuitableForRehire");
        MultiView1.SetActiveView(View1);
        MultiView1.Visible = true;
       
        lblEmpNumber.Text = lblEmployeeNumber.Text;
        lblEmpFirstName.Text = lblFirstName.Text;
        lblEmpLastName.Text = lblLastName.Text;
        lblDesignation.Text = lblDesignationDesc.Text;
        lblCategory.Text = lblCategoryDesc.Text;
        lblDepartment.Text = lblDepartmentDesc.Text;
        lblEmpDateOfJoining.Text = lblDateOfJoining.Text;
        lblEmpDateOfResignation.Text = lblDateOfResignation.Text;
        lblEmpSuitableForRehire.Text = lblSuitableForRehire.Text;

        BL.UserManagement objblUserManagement = new BL.UserManagement();
        ddlCompany.DataSource = objblUserManagement.UserCompanyAccessGet(BaseUserID).Tables[0];
        ddlCompany.DataTextField = "CompanyDesc";
        ddlCompany.DataValueField = "CompanyCode";
      
        ddlCompany.DataBind();
        ddlCompany.SelectedValue = BaseCompanyCode;

        ddlHrLocation.DataSource = objblUserManagement.UserHRLocationAccessGet(BaseUserID, ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlHrLocation.DataTextField = "HrLocationDesc";
        ddlHrLocation.DataValueField = "HrLocationCode";
        ddlHrLocation.DataBind();
        if (ddlHrLocation.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlHrLocation.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }

        ddlLocation.DataSource = objblUserManagement.UserLocationAccessGet(BaseUserID, ddlCompany.SelectedValue.ToString(), ddlHrLocation.SelectedValue.ToString()).Tables[0];
        ddlLocation.DataTextField = "LocationDesc";
        ddlLocation.DataValueField = "LocationAutoID";
        ddlLocation.DataBind();
        if (ddlLocation.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlLocation.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }

        ddlDesignation.DataSource = objHRManagement.EmployeeInterCompanyTransferGetDesignation(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlDesignation.DataTextField = "DesignationDesc";
        ddlDesignation.DataValueField = "DesignationCode";
        ddlDesignation.DataBind();
        if (ddlDesignation.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlDesignation.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }

        ddlCategory.DataSource = objHRManagement.EmployeeInterCompanyTransferGetCategory(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlCategory.DataTextField = "CategoryDesc";
        ddlCategory.DataValueField = "CategoryCode";
        ddlCategory.DataBind();
        if (ddlCategory.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlCategory.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }
        ddlDepartment.DataSource = objHRManagement.DepartmentGet(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataValueField = "DepartmentCode";
        ddlDepartment.DataBind();
        if (ddlDepartment.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlDepartment.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }
        ddlJobType.DataSource = objMastersManagement.JobTypeMasterGetAll(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlJobType.DataTextField = "JobTypeDesc";
        ddlJobType.DataValueField = "JobTypeCode";
        ddlJobType.DataBind();
        if (ddlJobType.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlJobType.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }
        ddlJobClass.DataSource = objMastersManagement.JobClassMasterGetAll(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlJobClass.DataTextField = "JobClassDesc";
        ddlJobClass.DataValueField = "JobClassCode";
        ddlJobClass.DataBind();
        if (ddlJobClass.Text == "")
        {
            ListItem li = new ListItem();

            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlJobClass.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }
        ddlRole.DataSource = objMastersManagement.RoleGet(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlRole.DataTextField = "RoleDesc";
        ddlRole.DataValueField = "RoleCode";
        ddlRole.DataBind();
        if (ddlRole.SelectedValue == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlRole.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }

        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlAreaID.Items.Clear();
        DataSet ds = new DataSet();

        ds = objOperationManagement.AreaIdGet(ddlLocation.SelectedValue.ToString(), "0");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataSource = ds;
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataBind();
            btnUpdate.Enabled = true;
        }
        else
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlAreaID.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        if (!string.IsNullOrEmpty(lblSuitableForRehire.Text) && lblSuitableForRehire.Text == "False")
        {
            btnUpdate.Enabled = false;
            imgDate.Visible = false;
            txtDateOfJoining.Enabled = false;
            ddlCompany.Enabled = false;
            ddlLocation.Enabled = false;
            ddlHrLocation.Enabled = false;
            ddlCategory.Enabled = false;
            ddlDepartment.Enabled = false;
            ddlDesignation.Enabled = false;
            ddlJobClass.Enabled = false;
            ddlJobType.Enabled = false;
            ddlRole.Enabled = false;
        }
    }

    /// <summary>
    /// Will update the particular Employee.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        if (ddlRole.SelectedItem.Value.ToString() != "" && ddlCategory.SelectedItem.Value.ToString() != "" && ddlJobClass.SelectedItem.Value.ToString() != "" && ddlJobType.SelectedItem.Value.ToString() != "" && ddlDesignation.SelectedItem.Value.ToString() != "" && ddlHrLocation.SelectedItem.Value.ToString() != "" && ddlLocation.SelectedItem.Value.ToString() != "")
        {
            btnUpdate.Enabled = true;
            if (txtDateOfJoining.Text != "")
            {
                if ((DateTime.Parse(lblEmpDateOfResignation.Text) != DateTime.Parse(txtDateOfJoining.Text)))
                {
                    if (GetGreaterDate(DateTime.Parse(lblEmpDateOfResignation.Text), DateTime.Parse(txtDateOfJoining.Text)) == true)
                    {
                        lblErrorMsg.Text = Resources.Resource.DateOfJoiningShouldbeGreaterthanDateOfTermination;//"Date Of Joining Should be Greater than Date Of Termination";

                    }
                    else
                    {
                        if (lblEmpSuitableForRehire.Text == "True")
                        {
                            DataSet ds = new DataSet();
                            ds = objHRManagement.EmployeeRehire(ddlLocation.SelectedItem.Value.ToString(), lblEmpNumber.Text, DateTime.Parse(DateFormat(txtDateOfJoining.Text)), ddlCompany.SelectedItem.Value.ToString(), ddlHrLocation.SelectedItem.Value.ToString(), ddlDesignation.SelectedItem.Value.ToString(), ddlCategory.SelectedItem.Value.ToString(), ddlJobClass.SelectedItem.Value.ToString(), ddlJobType.SelectedItem.Value.ToString(), txtRemark.Text, BaseUserID,ddlDepartment.SelectedItem.Value.ToString(),ddlRole.SelectedValue.ToString(),ddlAreaID.SelectedValue.ToString()); //department parameter added by lalit on 07/04/2010 as per ticket
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                                {
                                    Response.Redirect("EmployeeDetail.aspx");
                                }
                            }
                            
                        }
                        else
                        {
                            btnUpdate.Enabled = false;
                        }

                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateOfJoiningShouldbeGreaterthanDateOfTermination; ;
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.PleaseinputjoiningDate;
            }

        }
        else
        {
            btnUpdate.Enabled = false;
        }
    }

    /// <summary>
    /// Will cancel the update of a particular Employee.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlSearchBy.Visible = true;
        txtSearch.Visible = true;
        btnViewAll.Visible = true;
        Button1.Visible = true;


        MultiView1.Visible = false;
        MultiViewShowDetail.Visible = true;
    }

    /// <summary>
    /// Will change the value of other fields on change of company code.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        ddlHrLocation.DataSource = objblUserManagement.UserHRLocationAccessGet(BaseUserID, ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlHrLocation.DataTextField = "HrLocationDesc";
        ddlHrLocation.DataValueField = "HrLocationCode";
        ddlHrLocation.DataBind();
        if (ddlHrLocation.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlHrLocation.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }

        ddlDesignation.DataSource = objHRManagement.EmployeeInterCompanyTransferGetDesignation(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlDesignation.DataTextField = "DesignationDesc";
        ddlDesignation.DataValueField = "DesignationCode";
        ddlDesignation.DataBind();
        if (ddlDesignation.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlDesignation.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }

        ddlCategory.DataSource = objHRManagement.EmployeeInterCompanyTransferGetCategory(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlCategory.DataTextField = "CategoryDesc";
        ddlCategory.DataValueField = "CategoryCode";
        ddlCategory.DataBind();
        if (ddlCategory.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlCategory.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }

        ddlJobType.DataSource = objMastersManagement.JobTypeMasterGetAll(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlJobType.DataTextField = "JobTypeDesc";
        ddlJobType.DataValueField = "JobTypeCode";
        ddlJobType.DataBind();
        if (ddlJobType.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlJobType.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }
        ddlJobClass.DataSource = objMastersManagement.JobClassMasterGetAll(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlJobClass.DataTextField = "JobClassDesc";
        ddlJobClass.DataValueField = "JobClassCode";
        ddlJobClass.DataBind();
        if (ddlJobClass.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlJobClass.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        }
        ddlRole.DataSource = objMastersManagement.RoleGet(ddlCompany.SelectedValue.ToString()).Tables[0];
        ddlRole.DataTextField = "RoleDesc";
        ddlRole.DataValueField = "RoleCode";
        ddlRole.DataBind();
        if (ddlRole.SelectedItem.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlRole.Items.Add(li);
            btnUpdate.Enabled = false;
        }
        else
        {
            btnUpdate.Enabled = true;
        } 
        
        
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlAreaID.Items.Clear();
        DataSet ds = new DataSet();

        ds = objOperationManagement.AreaIdGet(ddlLocation.SelectedValue.ToString(), "0");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataSource = ds;
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataBind();
            btnUpdate.Enabled = true;
        }
        else
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlAreaID.Items.Add(li);
            btnUpdate.Enabled = false;
        }


        ddlHrLocation_SelectedIndexChanged(sender, e);

    }

    /// <summary>
    /// Will change the value of other fields on change of Location code.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void ddlHrLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        ddlLocation.DataSource = objblUserManagement.UserLocationAccessGet(BaseUserID, ddlCompany.SelectedValue.ToString(), ddlHrLocation.SelectedValue.ToString()).Tables[0];
        ddlLocation.DataTextField = "LocationDesc";
        ddlLocation.DataValueField = "LocationAutoID";
        ddlLocation.DataBind();
        if (ddlLocation.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlLocation.Items.Add(li);
            btnUpdate.Enabled = false;
        }

    }

    /// <summary>
    /// Will redirect the page to different page
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EmployeeDetail.aspx");
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvEmployeeReHire control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeReHire_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvEmployeeReHire.Columns[9].Visible = false;
        }
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false || IsWriteAccess==false || IsDeleteAccess==false)
            {
                gvEmployeeReHire.Columns[9].Visible = false;
            }
            if (IsWriteAccess == true)
            {
                gvEmployeeReHire.Columns[9].Visible = true;
            }
            else
            {
                gvEmployeeReHire.Columns[9].Visible = false;
            }

        }
    }

    /// <summary>
    /// Will Convert string to date format.
    /// </summary>
    /// <param name="txtDate">Contains Date of Joining.</param>
    private void ConvertStringToDateFormat(TextBox txtDate)
    {
        string date;
        txtDate.BackColor = System.Drawing.Color.Empty;
        BL.Common objCommon = new BL.Common();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (objCommon.IsValidDate(txtDate.Text))
        {
            txtDate.Text = DateTime.Parse(txtDate.Text).ToString("dd-MMM-yyyy");
        }
        else
        {
            date = objCommon.ConvertToDate(txtDate.Text);
            if (date == "1")
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.Yearnotincorrectformat);
                txtDate.Text = "";
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "2")
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.Monthnotincorrectformat);  
                txtDate.Text = "";
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "3")
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.Daynotincorrectformat);
                txtDate.Text ="";
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "4")
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.Notaleapyear);  
                txtDate.Text = "";
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "5")
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.Numberofdaysnotcorrect);  
                txtDate.Text = "";
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "6")
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.Datenotincorrectformat);  
                txtDate.Text ="";
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
    /// Will effect on changing  txtDateOfJoining i.e. date of joining
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void txtDateOfJoining_OnTextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtDateOfJoining);
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmployeeReHire control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeReHire_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeReHire.PageIndex = e.NewPageIndex;
        FillgvEmployeeReHire(BaseCompanyCode);
    }
    /// <summary>
    /// Will effect  on click of button btnSearch.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchAction();
    }

    /// <summary>
    /// Get all Rehired Employee  on click of button btnSearch.
    /// </summary>
    private void SearchAction()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataTable dtEmployeeReHire = new DataTable();
        dtEmployeeReHire = objHRManagement.RehiredEmployeeGetAll(BaseCompanyCode).Tables[0];
        
        dtEmployeeReHire.Columns["EmployeeNumber"].ColumnName = Resources.Resource.EmployeeNumber;
        dtEmployeeReHire.Columns["FirstName"].ColumnName = Resources.Resource.FirstName;
        dtEmployeeReHire.Columns["LastName"].ColumnName = Resources.Resource.LastName;
        dtEmployeeReHire.Columns["DesignationDesc"].ColumnName = Resources.Resource.Designation;
        dtEmployeeReHire.Columns["CategoryDesc"].ColumnName = Resources.Resource.CategoryDescription;

        DataTable dt = new DataTable();
        DataView dv = new DataView(dtEmployeeReHire);

        dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), txtSearch.Text);

        dt = dv.ToTable();
        dt.Columns[Resources.Resource.EmployeeNumber].ColumnName = "EmployeeNumber";
        dt.Columns[Resources.Resource.FirstName].ColumnName = "FirstName";
        dt.Columns[Resources.Resource.LastName].ColumnName = "LastName";
        dt.Columns[Resources.Resource.Designation].ColumnName = "DesignationDesc";
        dt.Columns[Resources.Resource.CategoryDescription].ColumnName = "CategoryDesc";
        gvEmployeeReHire.DataSource = dt;
        gvEmployeeReHire.DataBind();
    }

    /// <summary>
    /// Will effect  on click of button btnViewAll.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        FillgvEmployeeReHire(BaseCompanyCode);
    }

    /// <summary>
    /// fill dropdown ddlSearchBy.
    /// </summary>
    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        arr.Add(gvEmployeeReHire.Columns[0]);
        arr.Add(gvEmployeeReHire.Columns[1]);
        arr.Add(gvEmployeeReHire.Columns[2]);
        arr.Add(gvEmployeeReHire.Columns[3]);
        arr.Add(gvEmployeeReHire.Columns[4]);
        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();

    }

    /// <summary>
    /// Will effect  on change of ddlLocation code.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The instance containing the event data.</param>
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlAreaID.Items.Clear();
        DataSet ds = new DataSet();

        ds = objOperationManagement.AreaIdGet(ddlLocation.SelectedValue.ToString(), "0");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataSource = ds;
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataBind();
            btnUpdate.Enabled = true;
        }
        else
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlAreaID.Items.Add(li);
            btnUpdate.Enabled = false;
        }
    }
}


