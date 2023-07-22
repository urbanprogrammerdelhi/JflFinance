// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="EmpsLeaveDetail.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_EmpsLeaveDetail.
/// </summary>
public partial class Transactions_EmpsLeaveDetail : BasePage //System.Web.UI.Page
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
            //    lblPageHdrTitle.Text = Resources.Resource.EmpLeaveDetails;
            //}
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EmpLeaveDetails + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            txtYear.Text = DateTime.Now.Year.ToString();
            int intMonth = DateTime.Now.Month;
            ddlMonth.Items[intMonth - 1].Selected = true;
            txtYear.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) ){return true;}else{return false;}");
            txtYear.Attributes.Add("onblur", " if(document.getElementById('" + txtYear.ClientID.ToString() + "').value=='' ) {alert('Invalid Year value!');document.getElementById('" + txtYear.ClientID.ToString() + "').focus();return false;}  ");
            //Hid_FromDate.Value = DateFormat("1-" + ddlMonth.SelectedValue.ToString() + "-" + txtYear.Text);
            //Hid_ToDate.Value = DateFormat(LastDateOfMonth(Hid_FromDate.Value) + "-" + ddlMonth.SelectedValue.ToString() + "-" + txtYear.Text);

            Hid_FromDate.Value = "1-" + ddlMonth.SelectedValue.ToString() + "-" + txtYear.Text;
            Hid_ToDate.Value = LastDateOfMonth(Hid_FromDate.Value) + "-" + ddlMonth.SelectedValue.ToString() + "-" + txtYear.Text;

            getDetails();
        }
    }


    /// <summary>
    /// Gets the details.
    /// </summary>
    protected void getDetails()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.EmployeesLeaveGet(BaseHrLocationCode.ToString(), int.Parse(BaseLocationAutoID), "", Hid_FromDate.Value, Hid_ToDate.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvEmployeeLeave.DataSource = ds.Tables[0];
            gvEmployeeLeave.DataBind();
            lblErrorMsg.Text = "";
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoRecordFound ;
        }
    }

    /// <summary>
    /// Lasts the date of month.
    /// </summary>
    /// <param name="date1">The date1.</param>
    /// <returns>String.</returns>
    protected String LastDateOfMonth(string date1)
    {

        TimeSpan Ts = DateTime.Parse(date1).AddMonths(1) - DateTime.Parse(date1);
        String days = Ts.Days.ToString();
        return days;
    }

    /// <summary>
    /// Handles the Click event of the btnChangeMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnChangeMonth_Click(object sender, EventArgs e)
    {
        Hid_FromDate.Value = "1-" + ddlMonth.SelectedValue.ToString() + "-" + txtYear.Text;
        Hid_ToDate.Value = LastDateOfMonth(Hid_FromDate.Value) + "-" + ddlMonth.SelectedValue.ToString() + "-" + txtYear.Text;
        getDetails();
    }
}
