// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RotaLocking.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;


/// <summary>
/// Class Transactions_RotaLocking.
/// </summary>
public partial class Transactions_RotaLocking : BasePage//System.Web.UI.Page
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
    /// The ht automatic identifier
    /// </summary>
    static Hashtable htAutoId;

    #region page Load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            htAutoId = new Hashtable();
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.RotaLock;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.RotaLock + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                btnProceed.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                if (IsAuthorizationAccess == true)
                {
                    btnProceed.Visible = true;
                }
                else
                {
                    btnProceed.Visible = false;
                }

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            FillddlDivision();
            FillddlBranch();
            FillddlClient();

        }

        
    }

    #endregion

    #region fill controls

    /// <summary>
    /// Fillddls the division.
    /// </summary>
    private void FillddlDivision()
    {
        DataSet dsDivision = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();
            FillddlBranch();
        }
    }
    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationAutoId";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();

        }
    }


    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        BL.Sales objSales = new BL.Sales();
        ddlClientCode.Items.Clear();
        ddlClientCode.DataSource = objSales.ClientsLocationWiseGet(ddlBranch.SelectedValue);
        ddlClientCode.DataTextField = "ClientNameCode";
        ddlClientCode.DataValueField = "ClientCode";
        ddlClientCode.DataBind();

        ListItem li1 = new ListItem();

        li1.Text = Resources.Resource.All;
        li1.Value = "All";
        ddlClientCode.Items.Insert(0, li1);


    }

    #endregion

    #region Control events


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlBranch();
        FillddlClient();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClient();
    }

    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {

        fillGrid();
    }


    #endregion

    #region function related to grid

    /// <summary>
    /// Handles the PageIndexChanging event of the gvRotaLocking control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvRotaLocking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRotaLocking.PageIndex = e.NewPageIndex;
        gvRotaLocking.EditIndex = -1;
        fillGrid();
    }


    /// <summary>
    /// Handles the CheckedChanged event of the chkSelect control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.NamingContainer;
        CheckBox chkSelect = (CheckBox)gvRotaLocking.Rows[row.RowIndex].FindControl("chkSelect");
        HiddenField LockingAutoId = (HiddenField)gvRotaLocking.Rows[row.RowIndex].FindControl("LockingAutoId");
        if (chkSelect.Checked == true)
        {
            htAutoId.Add(LockingAutoId.Value, LockingAutoId.Value);
        }
        else
        {
            htAutoId.Remove(LockingAutoId.Value);
        }
    }
    /// <summary>
    /// Handles the CheckedChanged event of the chkSelectAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (htAutoId != null)
        {
            htAutoId.Clear();
        }

        for (int i = 0; i < gvRotaLocking.Rows.Count; i++)
        {
            CheckBox chkSelect = (CheckBox)gvRotaLocking.Rows[i].FindControl("chkSelect");
            HiddenField LockingAutoId = (HiddenField)gvRotaLocking.Rows[i].FindControl("LockingAutoId");
            CheckBox chkSelectAll = (CheckBox)sender;
            if (chkSelectAll.Checked == true)
            {
                chkSelect.Checked = true;
                htAutoId.Add(LockingAutoId.Value, LockingAutoId.Value);
            }
            else
            {
                chkSelect.Checked = false;
            }

        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvRotaLocking control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvRotaLocking_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (htAutoId != null && htAutoId.Count > 0)
        {

            if (e.CommandName == "LockRota")
            {
                BL.Roster objRost = new BL.Roster();
                DataSet ds = new DataSet();
                TextBox txtToDate = (TextBox)gvRotaLocking.FooterRow.FindControl("txtToDate");
                TextBox txtFromDate = (TextBox)gvRotaLocking.FooterRow.FindControl("txtFromDate");


                if (txtFromDate.Text != "")
                {
                    BL.Common obj = new BL.Common();
                    if (obj.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    txtFromDate.Focus();
                    return;

                }

                if (txtToDate.Text != "")
                {
                    BL.Common obj = new BL.Common();
                    if (obj.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    txtToDate.Focus();
                    return;

                }

                ds = objRost.RotaLockingUpdate(htAutoId, txtFromDate.Text, txtToDate.Text, BaseUserID.ToString(), IsAuthorizationAccess);
                fillGrid();
            }
            else if (e.CommandName == "UnLockRota")
            {
                BL.Roster objRost = new BL.Roster();
                DataSet ds = new DataSet();
                TextBox txtToDate = (TextBox)gvRotaLocking.FooterRow.FindControl("txtToDate");
                TextBox txtFromDate = (TextBox)gvRotaLocking.FooterRow.FindControl("txtFromDate");

                ds = objRost.RotaLockingUpdate(htAutoId, txtFromDate.Text, txtToDate.Text, BaseUserID.ToString(), IsAuthorizationAccess);
                fillGrid();

            }
        }

    }

    /// <summary>
    /// Fills the grid.
    /// </summary>
    protected void fillGrid()
    {
        if (htAutoId != null)
        {
            htAutoId.Clear();
        }

        BL.Roster objtran = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objtran.RotaLockingGet(BaseHrLocationCode, int.Parse(ddlBranch.SelectedValue.ToString()), ddlClientCode.SelectedValue.ToString(), "All", BaseUserID);

        gvRotaLocking.DataSource = ds.Tables[0];
        gvRotaLocking.DataBind();

        if (IsWriteAccess != true)
        {
            Button btnLock = (Button)gvRotaLocking.FooterRow.FindControl("btnLock");
            btnLock.Visible = false;

        }
        if (IsAuthorizationAccess != true)
        {

            Button btnUnLock = (Button)gvRotaLocking.FooterRow.FindControl("btnUnLock");
            btnUnLock.Visible = false;
        }


    }

    #endregion


}
