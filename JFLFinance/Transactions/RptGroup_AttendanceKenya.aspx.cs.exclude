// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_AttendanceKenya.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using DevExpress.Web;
/// <summary>
/// Class Transactions_RptGroup_AttendanceKenya.
/// </summary>
public partial class Transactions_RptGroup_AttendanceKenya : BasePage
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

        if (!IsPostBack && !IsCallback)
        {

            if (IsReadAccess == true)
            {

                System.Globalization.DateTimeFormatInfo d = new System.Globalization.DateTimeFormatInfo();
                string monthval = d.MonthNames[DateTime.Now.Month - 1].Substring(0, 3);

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

            FillDDLCategory();
            txtFromDate.Text = System.DateTime.Today.Date.ToString("dd-MMM-yyyy");
            txtToDate.Text = System.DateTime.Today.Date.ToString("dd-MMM-yyyy");
            //Added for Bug #2148
            txtFromDate.Attributes.Add("readonly", "readonly");
            txtToDate.Attributes.Add("readonly", "readonly");
            //End
            FillddlDivision();
        }
        FillDataGrid();
    }


    /// <summary>
    /// Fills the DDL category.
    /// </summary>
    private void FillDDLCategory()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DDLCategory.DataSource = objMastersManagement.CategoryMasterGetAll(BaseCompanyCode);
        DDLCategory.DataTextField = "CategoryDesc";
        DDLCategory.DataValueField = "CategoryCode";
        DDLCategory.DataBind();
        //ListItem li = new ListItem();
        //li.Text = Resources.Resource.All;
        //li.Value = "All";
        //DDLCategory.Items.Insert(0, li);
    }


    /// <summary>
    /// Handles the Click event of the btnGenerateData control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGenerateData_Click(object sender, EventArgs e)
    {
        if (ValidateFromToDate())       //Added for bug #2148
        {
            FillDataGrid();
        }
    }

    /// <summary>
    /// Fills the data grid.
    /// </summary>
    protected void FillDataGrid()
    {
        string strFromDate, strToDate;
        strFromDate = txtFromDate.Text.ToString();
        strToDate = txtToDate.Text.ToString();

        DataTable dt = new DataTable();
        DL.Report objRpt = new DL.Report();
        var coll = DDLCategory.CheckedItems;
        var loc = ddlBranch.CheckedItems;
        //For Category
        string ddlCat=string.Empty;
        string locationCode = string.Empty;
        if (coll.Count > 0)
        {
            foreach (var item in coll)
            {
                ddlCat = ddlCat + item.Value.ToString() + ",";
            }
        }

        //For Location Branch

        if (loc.Count > 0)
        {
            foreach (var itemloc in loc)
            {
                locationCode = locationCode + itemloc.Value.ToString() + ",";
            }
        }


        dt = objRpt.MusterRoll(BaseCompanyCode, BaseHrLocationCode, locationCode, ddlCat, strFromDate, strToDate, BaseUserID.ToString());

        musterRoll.DataSource = dt;
        musterRoll.DataBind();

    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlBranch();
    }


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

            ddlDivision.SelectedValue = BaseHrLocationCode.ToString();

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
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDescCode";
            ddlBranch.DataBind();
            //ListItem li = new ListItem();
            //li.Text = Resources.Resource.All.ToString();
            //li.Value = "ALL";
            //ddlBranch.Items.Insert(0, li);
           
        }
    }


    /// <summary>
    /// Code Added for Export to Excel
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (musterRoll.Selection.Count == 0)
        {
            exportGrid.ExportedRowType = GridViewExportedRowType.All;
        }
        exportGrid.WriteXlsToResponse();
    }

    /// <summary>
    /// Validates from to date. //Added for bug #2148
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool ValidateFromToDate()
    {
        var objCommon = new BL.Common();
        if (objCommon.IsValidDate(txtFromDate.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtFromDate.Focus();
            return false;
        }
        if (objCommon.IsValidDate(txtToDate.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtToDate.Focus();
            return false;
        }

        if (txtToDate.Text != "" && txtFromDate.Text != "")
        {
            if (GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                lblErrorMsg.Text = Resources.Resource.ToDateMustBeGreaterThanFromDate;
                return false;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
            return false;
        }
        return true;
    }
}

