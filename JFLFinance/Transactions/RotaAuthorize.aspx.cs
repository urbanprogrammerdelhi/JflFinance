// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RotaAuthorize.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Text;
using DevExpress.XtraEditors.Controls;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_RotaAuthorize.
/// </summary>
public partial class Transactions_RotaAuthorize : BasePage //System.Web.UI.Page
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

    /// <summary>
    /// Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                BasePage bp = new BasePage();
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
            //    lblPageHdrTitle.Text = Resources.Resource.RotaAuthorize;
            //}
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.RotaAuthorize + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillHrLocation();
                //FillLocation();
                
                
                ddlLocation.SelectedValue = BaseLocationAutoID;
                //RadComboBoxItem cboStObject = ddlLocation.FindItemByValue(BaseLocationAutoID);
                //cboStObject.Checked = true;
                //cboStObject.Dispose();
                FillPayPeriod();               
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    /// <summary>
    /// Fills the Hrlocation.
    /// </summary>
    protected void FillHrLocation()
    {
        var objblUserManagement = new BL.UserManagement();
        ddlHrLocation.Items.Clear();
        DataSet dsHrLocation = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsHrLocation != null && dsHrLocation.Tables.Count > 0 && dsHrLocation.Tables[0].Rows.Count > 0)
        {
            ddlHrLocation.DataSource = dsHrLocation.Tables[0];
            ddlHrLocation.DataValueField = "HrLocationCode";
            ddlHrLocation.DataTextField = "HrLocationDesc";
            ddlHrLocation.DataBind();
            ddlHrLocation.AutoPostBack = true;

            //RadComboBoxItem cboStObject = ddlHrLocation.FindItemByValue(BaseHrLocationCode);
            //cboStObject.Checked = true;
            //cboStObject.Dispose();

            ddlHrLocation.SelectedValue = BaseHrLocationCode;
            FillLocation();
        }
    }

    /// <summary>
    /// Fills the location.
    /// </summary>
    protected void FillLocation()
    {
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        DataSet dsBranch = new DataSet();
        ddlLocation.Items.Clear();

        //var collection = ddlHrLocation.CheckedItems;
        //if (collection.Count != 0)
        //{
            String strHrLocationCode = String.Empty;
            //foreach (var item in collection)
            //    strHrLocationCode = strHrLocationCode + item.Value + ",";

            strHrLocationCode = ddlHrLocation.SelectedItem.Value;
            dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, strHrLocationCode);
            if (dsBranch != null && dsBranch.Tables.Count > 0 && dsBranch.Tables[0].Rows.Count > 0)
            {
        ddlLocation.DataSource = dsBranch;
        ddlLocation.DataTextField = "LocationDesc";
        ddlLocation.DataValueField = "LocationAutoId";
        ddlLocation.DataBind();

                ddlLocation.Text = "";
                ddlLocation.Items[0].Selected = true; 
                //FillddlPaysumCode();
                FillPayPeriod();
    }
        //}
    }

    /// <summary>
    /// Fills the Paysum Code.
    /// </summary>
    protected void FillddlPaysumCode()
    {
        //DataSet ds = new DataSet();
        //ddlPaysumCode.Items.Clear();
        //BL.BusinessRule objblBusinessRule = new BL.BusinessRule();
        //ds = objblBusinessRule.BusinessRuleGet(int.Parse(ddlLocation.SelectedItem.Value));
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    ddlPaysumCode.DataSource = ds;
        //    ddlPaysumCode.DataTextField = "PaysumCodeDesc";
        //    ddlPaysumCode.DataValueField = "BusinessRuleCode";
        //    ddlPaysumCode.DataBind();

        //    FillPayPeriod();
        //}
    }

    /// <summary>
    /// Fills the pay period.
    /// </summary>
    protected void FillPayPeriod()
    {
        var objBR = new BL.BusinessRule();
        ddlPayPeriod.Items.Clear();
        //DataSet ds = objBR.BusinessRuleGet("All", int.Parse(BaseLocationAutoID));
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
            //var strBusinessRuleCode = ds.Tables[0].Rows[0]["BusinessRuleCode"].ToString();
            //var strBusinessRuleCode = ddlPaysumCode.SelectedItem.Value;
        //var collection = ddlLocation.CheckedItems;
        //if (collection.Count != 0)
        //{
        //    string strLocationAutoIds  = String.Empty;
        //    foreach (var item in collection)
        //        strLocationAutoIds = strLocationAutoIds + item.Value + ",";

            string strLocationAutoIds = ddlLocation.SelectedItem.Value;
                var ds = new DataSet();
                ds = objBR.RotaAuthorizationGet(@"ALL", strLocationAutoIds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlPayPeriod.DataSource = ds.Tables[0];
                    ddlPayPeriod.DataTextField = "PeriodDesc";
                    ddlPayPeriod.DataValueField = "PeriodNumber";
                    ddlPayPeriod.DataBind();

                    ViewState["Rota"] = ds.Tables[0];
                    if (ds.Tables[0].Rows[0]["ModifiedBy"].ToString().Length > 0)
                    {
                        lblModifiedBy.Text = ds.Tables[0].Rows[0]["ModifiedBy"].ToString();
                        //// check whether Date format is correct
                        if (DateFormat(ds.Tables[0].Rows[0]["ModifiedDate"].ToString()).Length > 0)
                        {
                            lblModifiedDate.Text =
                                DateTime.Parse(ds.Tables[0].Rows[0]["ModifiedDate"].ToString())
                                        .ToString("dd-MMM-yyyy HH:mm");
                        }
                        else
                        {
                            lblModifiedDate.Text = "";
                        }

                    }
                    else
                    {
                        lblModifiedBy.Text = "";
                        lblModifiedDate.Text = "";
                    }

                    for (int i = 0; i < ddlPayPeriod.Items.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["AuthorizedStatus"].ToString() == "1")
                        {
                            ddlPayPeriod.Items[i].Attributes.Add("style", "background-color:Orange");
                        }

                    }
                    lblErrorMsg.Text = string.Empty;
                }
                else
                {
                    if (ddlPayPeriod.Items.Count < 1)
                    {
                        lblErrorMsg.Text = Resources.Resource.NoRecordFound;
                    }
                }
            //}
        //}
            //ds.Dispose();
        //}
            }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    //protected void ddlHrLocation_SelectedIndexChanged(object sender, EventArgs e)
    protected void ddlHrLocation_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillLocation();
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    //protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    protected void ddlLocation_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //FillddlPaysumCode();
        FillPayPeriod();
        //FillPayPeriod();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPaysumCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPaysumCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //FillPayPeriod();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPayPeriod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPayPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowLastModifiedBy();
    }

    /// <summary>
    /// To Show the User Id and Date of authorized Rota
    /// </summary>
    protected void ShowLastModifiedBy()
    {
        DataTable dt = (DataTable)ViewState["Rota"];
        DataRow[] myResultSet = dt.Select("[PeriodNumber] = " + Convert.ToInt16(ddlPayPeriod.SelectedValue.ToString()));
        if (myResultSet != null && myResultSet.Length > 0 && myResultSet[0]["ModifiedBy"].ToString().Length > 0)
        {
            lblModifiedBy.Text = myResultSet[0]["ModifiedBy"].ToString();
            //// check whether Date format is correct  
            if (DateFormat(myResultSet[0]["ModifiedDate"].ToString()).Length > 0)
            {
                lblModifiedDate.Text = DateTime.Parse(myResultSet[0]["ModifiedDate"].ToString()).ToString("dd-MMM-yyyy HH:mm");
            }
            else
            {
                lblModifiedDate.Text = "";
            }
        }
        else
        {
            lblModifiedBy.Text = "";
            lblModifiedDate.Text = "";
        }

        for (int i = 0; i < ddlPayPeriod.Items.Count; i++)
        {
            if (dt.Rows[i]["AuthorizedStatus"].ToString() == "1")
            {
                ddlPayPeriod.Items[i].Attributes.Add("style", "background-color:Orange");
            }
        }
    }


    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        //var selectedIndex = ddlPayPeriod.SelectedIndex;
        //if (ddlPayPeriod.Items[selectedIndex-1].Attributes.)
        //{ 


        //}
        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        string[] Arr = ddlPayPeriod.Items[ddlPayPeriod.SelectedIndex].Text.Split('-');
        int ddlPayPeriodIndex = ddlPayPeriod.SelectedIndex;
        if (Arr.Length > 0)
        {
            ds = objRost.RotaAuthorize(Arr[0].ToString(), Arr[1].ToString(), int.Parse(ddlLocation.SelectedValue.ToString()), BaseUserID.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "18")
                {
                    lblErrorMsg.Text = Resources.Resource.PreviousPeriodnotAuthorized;
                }
                else
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
                FillPayPeriod();
                ddlPayPeriod.SelectedIndex = ddlPayPeriodIndex;
                ShowLastModifiedBy();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgUnknownError;
        }

    }

}
