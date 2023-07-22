// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="IDIssuingReceiving.aspx.cs" company="Magnon">
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
/// Class HRManagement_IDIssuingReceiving
/// </summary>
public partial class HRManagement_IDIssuingReceiving: BasePage //System.Web.UI.Page
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
            javaScript.Append("PageTitle('" + Resources.Resource.IDIssuingAndReceivingMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            imgEmployeeNumberSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + TxtEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
            
            FillIdType();
            FillPurposeOfIssue();

        
        }
    }
    /// <summary>
    /// Handles the OnTextChanged event of the TxtEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtEmployeeNumber_OnTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");

        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objHRManagement.EmployeeNameAndDesignationGet(TxtEmployeeNumber.Text.ToString(), BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            TxtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
        }
        else
        {
            lblErrMsg.Text = Resources.Resource.NoDataToShow;
            TxtEmployeeNumber.Text = "";
        }
    }
    /// <summary>
    /// Handles the OnTextChanged event of the ddlIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlIdType_OnTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");

        BL.HRManagement ObjHrIssue = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = ObjHrIssue.EmployeeIssueDetailGet(TxtEmployeeNumber.Text.ToString(), ddlIdType.SelectedValue.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            TxtDateOfIssue.Text     = ds.Tables[0].Rows[0]["DateOfIssue"].ToString();
            ddlPurOfIssue.Text      = ds.Tables[0].Rows[0]["PurposeOfIssue"].ToString();
            TxtExDateOFReturn.Text  = ds.Tables[0].Rows[0]["ExpectedDateOfReturn"].ToString();
            TxtIssueRemarks.Text    = ds.Tables[0].Rows[0]["IssuingRemarks"].ToString();
            TxtIssueStatus.Text     = ds.Tables[0].Rows[0]["IssuingStatus"].ToString();      
        }
        else
        {
            BL.HRManagement objHRManagement = new BL.HRManagement();
            DataSet ds1 = new DataSet();

            ds1 = objHRManagement.EmployeeIdGet(TxtEmployeeNumber.Text.ToString(), BaseHrLocationCode, ddlIdType.SelectedValue.ToString());
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {

                TxtIdNo.Text = ds1.Tables[0].Rows[0]["IDNumber"].ToString();
            }
            else
            {
                lblErrMsg.Text = Resources.Resource.NoDataToShow;
                TxtIdNo.Text = "";

            }

        }
    }
    #region comboFill

    /// <summary>
    /// Fills the type of the id.
    /// </summary>
    protected void FillIdType()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
       
        ds = objMastersManagement.IdTypeGetAll();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlIdType.DataSource = ds;
            ddlIdType.DataTextField = "IdTypeDesc";
            ddlIdType.DataValueField = "IdTypeCode";
            ddlIdType.DataBind();

            ListItem Lst = new  ListItem() ;
            Lst.Text  =  Resources.Resource.Select ;
            Lst.Value = "0";

            ddlIdType.Items.Insert(0,Lst);
            ddlIdType.SelectedIndex = 0;

        }
        else
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlIdType.Items.Insert(0, li);
        }
      }


    /// <summary>
    /// Fills the purpose of issue.
    /// </summary>
    protected void FillPurposeOfIssue()
    {
        ListItem Lst = new ListItem ();
        Lst.Text = "Personnel";
        Lst.Value = "P";


        ddlPurOfIssue.Items.Insert(0, Lst);

        ListItem Lst1 = new ListItem();
        Lst1.Text = "Offical";
        Lst1.Value = "O";
        ddlPurOfIssue.Items.Insert(1, Lst1);
        ddlPurOfIssue.SelectedIndex = 0;
    }

    #endregion
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.HRManagement objIssue = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objIssue.IssuedIdReceiptInsert(TxtEmployeeNumber.Text.ToString(), ddlIdType.SelectedValue.ToString(), ddlPurOfIssue.SelectedValue.ToString(), TxtDateOfIssue.Text, TxtExDateOFReturn.Text, TxtIssueRemarks.Text.ToString(),Resources.Resource.Fresh,BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.HRManagement objIssue = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objIssue.IssuedIdReceiptUpdate(TxtEmployeeNumber.Text.ToString(), ddlIdType.SelectedValue.ToString(), ddlPurOfIssue.SelectedValue.ToString(), TxtDateOfIssue.Text, TxtExDateOFReturn.Text, TxtIssueRemarks.Text.ToString(),Resources.Resource.Fresh ,BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");

        BL.HRManagement objIssue = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objIssue.IssuedIdReceiptAuthorize(TxtEmployeeNumber.Text.ToString(), ddlIdType.SelectedValue.ToString(),Resources.Resource.Authorized, BaseUserID);


        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
        }
    }
}
