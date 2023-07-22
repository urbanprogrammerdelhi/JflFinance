// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="CarryOver.Aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class HRManagement_CarryOver
/// </summary>
public partial class HRManagement_CarryOver : BasePage
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                
                throw new Exception("Have not Rights", ex); }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                
                throw new Exception("Have not Rights", ex); 
            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex); 
            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex); 
            }
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
            javaScript.Append("PageTitle('" + Resources.Resource.CarryOver + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
        }
        ImgLCCode.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=LCCCH&ControlId=" + txtLeaveCalendarCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=750,Height=350,help=no')");
    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtLeaveCalendarCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtLeaveCalendarCode_OnTextChanged(object sender, EventArgs e)
    {
        try
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
            }
        }

        catch (Exception ex)
        {
            DataSet ds = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex.ToString(), BaseUserID);
            ds.Dispose();
        }
    }


}
