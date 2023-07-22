// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="EmployeeTermination.aspx.cs" company="Magnon">
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
/// Class HRManagement_EmployeeTermination
/// </summary>
public partial class HRManagement_EmployeeTermination : BasePage//System.Web.UI.Page
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
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EmployeeTermination + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            
            if (IsReadAccess == true)
            {
                imgResignationDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtResignationDate.ClientID.ToString() + "');";
                txtResignationDate.Attributes.Add("readonly", "readonly");
                FillEmployeeDetail(Request.QueryString["strEmployeeNumber"],BaseLocationAutoID);
                FillTerminationReason();
             
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                btnTerminateEmployee.Visible = false;
            }
            if (IsModifyAccess == false || IsWriteAccess == false || IsDeleteAccess == false)
            {
                btnTerminateEmployee.Visible = false;
            }
            if (IsModifyAccess == true)
            {
                btnTerminateEmployee.Visible = true;
            }
            else
            {
                btnTerminateEmployee.Visible = false;
            }
            
        }
    }
    /// <summary>
    /// Fills the termination reason.
    /// </summary>
    private void FillTerminationReason()
    {
        if (ddlReason.SelectedValue.ToString().Equals(Resources.Resource.Employer))
        {

            ArrayList li = new ArrayList();
            li.Add(Resources.Resource.Resigned);
            li.Add(Resources.Resource.Retired);
            li.Add(Resources.Resource.Terminated);
            ddlTerminationReason.DataSource = li;
            ddlTerminationReason.DataBind();
            
        }
        else
        {
            ArrayList li = new ArrayList();
            li.Add(Resources.Resource.BetterOpportunities);
            li.Add(Resources.Resource.HealthReason);
            li.Add(Resources.Resource.PersonalReason);
            ddlTerminationReason.DataSource = li;
            ddlTerminationReason.DataBind();
        }
    }
    /// <summary>
    /// Fills the employee detail.
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    private void FillEmployeeDetail(string strEmployeeNumber, string strLocationAutoID)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        DataTable dtEmployeeTermination = new DataTable();
        ds = objHRManagement.EmployeeDetailUpdate(strEmployeeNumber, strLocationAutoID);
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblEmployeeNumber.Text = strEmployeeNumber;
                lblFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                lblLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                lblJoiningDate.Text = DateFormat(ds.Tables[0].Rows[0]["DateOfJoining"].ToString());
                lblDesignationDescription.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
                lblCategoryDescription.Text = ds.Tables[0].Rows[0]["CategoryDesc"].ToString();
                lblDateOfBirth.Text = DateFormat(ds.Tables[0].Rows[0]["DateOfBirth"].ToString());
                hfTotalExpTillDate.Value = ds.Tables[0].Rows[0]["PrevTotalExp"].ToString();
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
                btnTerminateEmployee.Enabled = false;
            }
        }
        catch (Exception)
        {
           
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReason control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTerminationReason();
    }
    /// <summary>
    /// Handles the Click event of the btnTerminateEmployee control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnTerminateEmployee_Click(object sender, EventArgs e)
    {
        BL.HRManagement objHrManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds=objHrManagement.EmployeeTerminationGetMaxDate(lblEmployeeNumber.Text, BaseCompanyCode);
        string MaxDate = ds.Tables[0].Rows[0][0].ToString();
        if (GetGreaterDate(DateTime.Parse(MaxDate), DateTime.Parse(txtResignationDate.Text)) == false)
        {
            ds = objHrManagement.TerminateEmployee(lblEmployeeNumber.Text.ToString(), ddlReason.SelectedItem.Text.ToString(), ddlTerminationReason.SelectedItem.Text.ToString(),DateTime.Parse(DateFormat(txtResignationDate.Text)), txtRemarks.Text, bool.Parse(ddlSuitable4ReHire.SelectedValue.ToString()), BaseUserID, BaseLocationAutoID, BaseCompanyCode,DateTime.Parse(DateFormat(lblJoiningDate.Text)), float.Parse(hfTotalExpTillDate.Value));
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                Response.Redirect("../HrManagement/EmployeeDetail.aspx");
            }
        }
        else
        {
            
            lblErrorMsg.Text = Resources.Resource.InvalidActionResignationDateCannotBeLessThan +" "+ DateFormat(MaxDate);
            txtResignationDate.Text = "";
        }
    }

    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../HrManagement/EmployeeDetail.aspx");
    }
}
