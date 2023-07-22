// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="EmployeeTagReference.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_EmployeeTagReference.
/// </summary>
public partial class Transactions_EmployeeTagReference : BasePage//System.Web.UI.Page
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

    #region page Load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
        //if (lblPageHdrTitle != null)
        //{
        //    lblPageHdrTitle.Text = Resources.Resource.TagId;
        //}
        //Code added by Manoj on 16 Jan 2012
        //Page Title from resource file
        System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
        javaScript.Append("<script type='text/javascript'>");
        javaScript.Append("window.document.body.onload = function ()");
        javaScript.Append("{\n");
        javaScript.Append("PageTitle('" + Resources.Resource.TagId + "');");
        javaScript.Append("};\n");
        javaScript.Append("// -->\n");
        javaScript.Append("</script>");
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                FillgvEmpTagRef();
                FillddlSearchBy();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    #endregion

    #region grid events
    /// <summary>
    /// Handles the RowCommand event of the gvEmpTagRef control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvEmpTagRef_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objRost = new BL.Roster();
        var ds = new DataSet();
        try
        {
            var gvrow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            if (e.CommandName == "Add New")
            {
                var TxtEmployeeNumber = (TextBox)gvEmpTagRef.FooterRow.FindControl("TxtEmployeeNumber");
                var txtEffectiveFrom = (TextBox)gvEmpTagRef.FooterRow.FindControl("txtEffectiveFrom");
                var txtNewTagId = (TextBox)gvEmpTagRef.FooterRow.FindControl("txtNewTagId");
                ds = objRost.EmployeeTagReferenceInsert(TxtEmployeeNumber.Text, txtNewTagId.Text, txtEffectiveFrom.Text, BaseUserID.ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                }
                FillgvEmpTagRef();
            }
            else if (e.CommandName == "Delete1")
            {
                var lblgvTagId = (Label)gvrow.FindControl("lblgvTagId");
                var lblgvEmployeeNumber = (Label)gvrow.FindControl("lblgvEmployeeNumber");
                var txtgvEffectiveTo = (TextBox)gvrow.FindControl("txtgvEffectiveTo");
                //Added By  on 7-May-2014
                if (string.IsNullOrEmpty(txtgvEffectiveTo.Text))
                {
                    txtgvEffectiveTo.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
                ds = objRost.EmployeeTagReferenceClose(lblgvEmployeeNumber.Text, lblgvTagId.Text, txtgvEffectiveTo.Text, "Delete");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                }
                FillgvEmpTagRef();
            }
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvEmpTagRef control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvEmpTagRef_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        Label lblgvTagId = (Label)gvEmpTagRef.Rows[e.RowIndex].FindControl("lblgvTagId");
        Label lblgvEmployeeNumber = (Label)gvEmpTagRef.Rows[e.RowIndex].FindControl("lblgvEmployeeNumber");
        TextBox txtgvEffectiveTo = (TextBox)gvEmpTagRef.Rows[e.RowIndex].FindControl("txtgvEffectiveTo");
        ds = objRost.EmployeeTagReferenceClose(lblgvEmployeeNumber.Text, lblgvTagId.Text, txtgvEffectiveTo.Text, BaseUserID.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
        }

        FillgvEmpTagRef();

    }


    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmpTagRef control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmpTagRef_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmpTagRef.PageIndex = e.NewPageIndex;
        gvEmpTagRef.EditIndex = -1;
        FillgvEmpTagRef();
    }


    /// <summary>
    /// Handles the RowDataBound event of the gvEmpTagRef control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmpTagRef_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvEmpTagRef.ShowFooter = false;
            }
        }


    }

    #endregion


    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {

        TextBox TxtEmployeeNumber = (TextBox)gvEmpTagRef.FooterRow.FindControl("TxtEmployeeNumber");
        TextBox txtNewTagId = (TextBox)gvEmpTagRef.FooterRow.FindControl("txtNewTagId");



        TxtEmployeeNumber.Text = "";
        txtNewTagId.Text = "";

    }

    /// <summary>
    /// Fillgvs the emp tag reference.
    /// </summary>
    protected void FillgvEmpTagRef()
    {
        BL.Roster objRost = new BL.Roster();
        DataSet dsTagRef = new DataSet();
        DataTable dtTagRef = new DataTable();
        dsTagRef = objRost.EmployeeTagReferenceGet("", "Active");

        if (dsTagRef != null && dsTagRef.Tables.Count > 0 && dsTagRef.Tables[0].Rows.Count > 0)
        {
            gvEmpTagRef.DataSource = dsTagRef;
            gvEmpTagRef.DataBind();
        }
        else
        {
            dtTagRef = dsTagRef.Tables[0];
            dtTagRef.Rows.Add(dtTagRef.NewRow());
            gvEmpTagRef.DataSource = dtTagRef;
            gvEmpTagRef.DataBind();
            gvEmpTagRef.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }

    }

    #region Function Related to Search In Gridview

    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text != "")
        {
            btnViewAll.Visible = true;
            hfSearchText.Value = txtSearch.Text.Trim();
            SearchAction();
        }



    }

    /// <summary>
    /// Searches the action.
    /// </summary>
    private void SearchAction()
    {
        lblErrorMsg.Text = "";

        var objRost = new BL.Roster();
        var dtSearche = new DataTable();

        dtSearche = objRost.EmployeeTagReferenceGet("", "Active").Tables[0];
        dtSearche.Columns["EmployeeNumber"].ColumnName = Resources.Resource.EmployeeNumber;
        dtSearche.Columns["EmployeeName"].ColumnName = Resources.Resource.EmployeeName;
        //Modify By  on 7-May-2014
        dtSearche.Columns["EmployeeTagID"].ColumnName = Resources.Resource.TagId;
        var dt = new DataTable();
        var dv = new DataView(dtSearche);

        dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);

        dt = dv.ToTable();
        dt.Columns[Resources.Resource.EmployeeNumber].ColumnName = "EmployeeNumber";
        dt.Columns[Resources.Resource.EmployeeName].ColumnName = "EmployeeName";
        dt.Columns[Resources.Resource.TagId].ColumnName = "EmployeeTagID";
        gvEmpTagRef.DataSource = dt;
        gvEmpTagRef.DataBind();

        if (dt.Rows.Count < 1)
        {
            lblErrorMsg.Text = "no record found!";
        }

    }

    /// <summary>
    /// Handles the Click event of the btnViewAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        FillgvEmpTagRef();
        btnViewAll.Visible = false;
    }

    /// <summary>
    /// Fillddls the search by.
    /// </summary>
    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        arr.Add(gvEmpTagRef.Columns[2]);
        arr.Add(gvEmpTagRef.Columns[3]);
        arr.Add(gvEmpTagRef.Columns[1]);

        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();

    }

    #endregion

}
