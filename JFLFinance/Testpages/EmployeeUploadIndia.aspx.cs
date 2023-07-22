// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="EmployeeUploadIndia.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_EmployeeUploadIndia.
/// </summary>
public partial class Transactions_EmployeeUploadIndia : BasePage //System.Web.UI.Page
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
            { return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, 13)); }
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
            { return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, 13)); }
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
            { return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, 13)); }
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
            { return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, 13)); }
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
            Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");

            if (lblPageHdrTitle != null)
            {
                lblPageHdrTitle.Text = "Data Uploading";
            }

            btnLeaveUpload.Text = "Click here for uploading leave of Division " + BaseHrLocationCode;

            txtYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            txtYear.MaxLength = 4;
            txtYear.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";


        }
    }
    /// <summary>
    /// Handles the Click event of the BtnProcess control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void BtnProcess_Click(object sender, EventArgs e)
    {

        if (TxtEmpcode.Text != "")
        {
            BL.HRManagement objHrManagement = new BL.HRManagement();
            DataSet ds = new DataSet();
            // ds = objHrManagement.blEmployeeUpload(BaseCompanyCode, BaseHrLocationCode, TxtEmpcode.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string error = ds.Tables[0].Rows[0][0].ToString();

                if (error == "Not a Valid Employee")
                {
                    lblErrorMsg.Text = "Not a Valid Employee";
                }
                else
                {
                    lblErrorMsg.Text = "Uploaded sucessfully";
                }

            }
            else
            {
                lblErrorMsg.Text = "No Data to Upload";
            }
        }
        else
        {
            lblErrorMsg.Text = "Employee Code should not be blank";
        }

    }

    #region To Upload Sale Data

    /// <summary>
    /// Handles the Click event of the BtnProcess2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void BtnProcess2_Click(object sender, EventArgs e)
    {

        if (txtClientCode.Text != "")
        {
            BL.Sales objsales = new BL.Sales();
            DataSet ds = new DataSet();
            //ds = objsales.blClientDataUpload(BaseCompanyCode, BaseLocationCode, txtClientCode.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblErrorMsg2.Text = "Uploaded sucessfully";

            }
            else
            {
                lblErrorMsg2.Text = "Not Data to Upload For This Client";
            }
        }
        else
        {
            lblErrorMsg2.Text = "Client Code should not be blank";
        }

    }
    #endregion

    /// <summary>
    /// Handles the Click event of the btnLeaveUpload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnLeaveUpload_Click(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();

        if (txtYear.Text.Length < 4)
        {
            lblLeaveErrorMsg.Text = "invalid value!";
            txtYear.Focus();
        }

        //****************** blLeaveUpload  startDate & endDate "1/1/1900" is handaled in SP. *******************************************
        try
        {
            ds = DL.Report.DLLeaveUploadIndia(BaseCompanyCode, BaseHrLocationCode, "", int.Parse(ddlMonth.SelectedValue), int.Parse(txtYear.Text));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString() == "1")
            {
                lblLeaveErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
            }
            else
            {
                lblLeaveErrorMsg.Text = "Fail to upload";
            }
        }
        catch
        {
            lblLeaveErrorMsg.Text = "Fail to upload";
        }
    }
}
