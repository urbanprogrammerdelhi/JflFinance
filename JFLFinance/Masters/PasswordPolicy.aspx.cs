// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="PasswordPolicy.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Masters_PasswordPolicy
/// </summary>
public partial class Masters_PasswordPolicy : BasePage //System.Web.UI.Page
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

    #region Page Load

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
            javaScript.Append("PageTitle('" + Resources.Resource.PasswordPolicy + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            //txtMinLen.ReadOnly = true;
            //txtMinUpperCase.ReadOnly = true;
            ddNumeric.Enabled = false;
            ddSpecialChar.Enabled = false;
            //txtExpDay.ReadOnly = false;
            //txtExpWarB4.ReadOnly = true;
            //txtPwdUniqness.ReadOnly = true;
            //txtDisableAcc.ReadOnly = true;
            //txtUnsuccessAtmp.ReadOnly = true;
            ddUnsuccessLogin.Enabled = false;
            chkIsActive.Enabled = false;
            btnApply.Visible = false;
            btnCancel.Visible = false;
            btnClear.Visible = false;
            btnReset.Visible = false;
            //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            //txtMinLen.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";
            //txtExpDay.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";
            //txtExpWarB4.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";
            //txtPwdUniqness.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";
            //txtDisableAcc.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";
            //txtUnsuccessAtmp.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";
            Passwordpolicy_Get(); 
        }
    }

    #endregion

    #region button event
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Passwordpolicy_Get();

    }
    /// <summary>
    /// Handles the Click event of the btnClear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtMinLen.Text = string.Empty;
        txtMinUpperCase.Text = string.Empty;
        txtExpDay.Text = string.Empty;
        txtExpWarB4.Text = string.Empty;
        txtPwdUniqness.Text = string.Empty;
        txtUnsuccessAtmp.Text = string.Empty;
        txtDisableAcc.Text = string.Empty;
        lblErrorMsg.Text = "";

    }

    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../usermanagement/home.aspx");
    }

    /// <summary>
    /// Handles the Click event of the btnApply control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnApply_Click(object sender, EventArgs e)
    {
        BL.MastersManagement objMasterMgt = new BL.MastersManagement();
        DataSet ds = new DataSet();
       // try
       // {
            int passwordLen = int.Parse(txtMinLen.Text);
            int MinUpperCase = int.Parse(txtMinUpperCase.Text);
            int passwordExpDays = int.Parse(txtExpDay.Text);
            int passwordWarnDays = int.Parse(txtExpWarB4.Text);
            int passwordUniqness = int.Parse(txtPwdUniqness.Text);
            int PasswordUnsuccessAtmp = int.Parse(txtUnsuccessAtmp.Text);
            int DisableAfter = int.Parse(txtDisableAcc.Text);
            int NumericCharLen = int.Parse(ddNumeric.SelectedValue.ToString());
            int SpecialCharLen = int.Parse(ddSpecialChar.SelectedValue.ToString());

            bool isDisableAcAfterUnSuccess = false;
            if (ddUnsuccessLogin.SelectedValue.ToString() == "1")
            {
                isDisableAcAfterUnSuccess = true;
            }

            ds = objMasterMgt.PasswordPolicyUpdate(passwordLen, MinUpperCase,NumericCharLen, SpecialCharLen, passwordExpDays, passwordWarnDays, passwordUniqness, DisableAfter, PasswordUnsuccessAtmp, isDisableAcAfterUnSuccess, BaseCompanyCode.ToString(), BaseUserID.ToString(), chkIsActive.Checked);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //DisplayMessageString(lblErrorMsg, ds.Tables[0].Rows[0]["MessageString"].ToString());
            lblErrorMsg.Text = Resources.Resource.SucessfullyApplied;
        }
        //}
        //catch (Exception error)
        //{
        //    lblErrorMsg.Text = Resources.Resource.InvalidInputOnlyNumericValueAllowed;           
        //}
    }

    #endregion

    #region Local functons
    /// <summary>
    /// Passwordpolicy_s the get.
    /// </summary>
    private void Passwordpolicy_Get()
    {
        lblErrorMsg.Text = "";
        BL.MastersManagement objMasterMgt = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterMgt.PasswordPolicyGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtMinLen.Text = ds.Tables[0].Rows[0]["Password_Min_Len"].ToString();
            txtExpDay.Text = ds.Tables[0].Rows[0]["Password_Exp_after_days"].ToString();
            txtExpWarB4.Text = ds.Tables[0].Rows[0]["Password_Exp_warn_before"].ToString();
            txtPwdUniqness.Text = ds.Tables[0].Rows[0]["Password_Reuse_after_Times"].ToString();
            txtUnsuccessAtmp.Text = ds.Tables[0].Rows[0]["UnSuccessful_Atempt_Allowed"].ToString();
            txtDisableAcc.Text = ds.Tables[0].Rows[0]["Disable_Ac_after_days"].ToString();
            txtMinUpperCase.Text = ds.Tables[0].Rows[0]["Min_Upper_Case"].ToString();
            if (ds.Tables[0].Rows[0]["Numeric_Char_len"].ToString() == "0")
            {
                ddNumeric.SelectedValue = "0";
            }
            else
            {
                ddNumeric.SelectedValue = "1";
            }

            if (ds.Tables[0].Rows[0]["Special_Char_len"].ToString() == "0")
            {
                ddSpecialChar.SelectedValue = "0";
            }
            else
            {
                ddSpecialChar.SelectedValue = "1";
            }

            if (bool.Parse(ds.Tables[0].Rows[0]["IsDisable_Ac_after_UnSuccess_Attempt"].ToString()) == false)
            {
                ddUnsuccessLogin.SelectedValue = "0";
            }
            else
            {
                ddUnsuccessLogin.SelectedValue = "1";
            }



        }

    }
    #endregion
}
