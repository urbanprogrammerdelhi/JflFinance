// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By :  Parashar
// Last Modified On : 14-Apr-2014, 21-May-2014
// ***********************************************************************
// <copyright file="AsmtTagReference.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_AsmtTagReference.
/// </summary>
public partial class Transactions_AsmtTagReference : BasePage//System.Web.UI.Page
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
                FillgvAsmtTagRef();
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
    /// Handles the RowCommand event of the gvAsmtTagRef control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAsmtTagRef_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objRost = new BL.Roster();
        var ds = new DataSet();
        try
        {
            var gvrow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            if (e.CommandName == "Add New")
            {
                var ddlAsmtCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlAsmtCode");
                var txtEffectiveFrom = (TextBox)gvAsmtTagRef.FooterRow.FindControl("txtEffectiveFrom");
                var txtNewEffectiveFromTime = (TextBox)gvAsmtTagRef.FooterRow.FindControl("txtNewEffectiveFromTime");
                var txtNewTagId = (TextBox)gvAsmtTagRef.FooterRow.FindControl("txtNewTagId");
                var ddlPostCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlPostCode");
                
                //Modify by  on 14-Apr-2014
                var ddlClientCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlClientCode");
                ds = objRost.AsmtTagReferenceInsert(ddlClientCode.SelectedItem.Value, ddlAsmtCode.SelectedValue, BaseLocationAutoID, txtNewTagId.Text, txtEffectiveFrom.Text, txtNewEffectiveFromTime.Text, ddlPostCode.SelectedItem.Value, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                }
                FillgvAsmtTagRef();
            }
            else if (e.CommandName == "Delete1")
            {
                var lblgvTagId = (Label)gvrow.FindControl("lblgvTagId");
                
                var txtgvEffectiveTo = (TextBox)gvrow.FindControl("txtgvEffectiveTo");
                var txtItemEffectiveToTime = (TextBox)gvrow.FindControl("txtItemEffectiveToTime");
                //Modify By  on 14-Mar-2014
                var hdClientCode = (HiddenField)gvrow.FindControl("hdClientCode");
                var hdAsmtId = (HiddenField)gvrow.FindControl("hdAsmtId");
                var hdPostAutoId = (HiddenField)gvrow.FindControl("hdPostAutoId");

                if (string.IsNullOrEmpty(txtgvEffectiveTo.Text))
                {
                    txtgvEffectiveTo.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }

                if (string.IsNullOrEmpty(txtItemEffectiveToTime.Text))
                {
                    txtItemEffectiveToTime.Text = DateTime.Now.ToString("HH:mm");
                }

                ds = objRost.AsmtTagReferenceClose(hdClientCode.Value, hdAsmtId.Value, BaseLocationAutoID, lblgvTagId.Text, txtgvEffectiveTo.Text, txtItemEffectiveToTime.Text, hdPostAutoId.Value, BaseUserID, "Delete");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                }
                FillgvAsmtTagRef();
            }
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvAsmtTagRef control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAsmtTagRef_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objRost = new BL.Roster();
        var ds = new DataSet();
        var lblgvTagId = (Label)gvAsmtTagRef.Rows[e.RowIndex].FindControl("lblgvTagId");
        var hdClientCode = (HiddenField)gvAsmtTagRef.Rows[e.RowIndex].FindControl("hdClientCode");
        var hdAsmtId = (HiddenField)gvAsmtTagRef.Rows[e.RowIndex].FindControl("hdAsmtId");
        var txtgvEffectiveTo = (TextBox)gvAsmtTagRef.Rows[e.RowIndex].FindControl("txtgvEffectiveTo");
        var hdPostAutoId = (HiddenField)gvAsmtTagRef.Rows[e.RowIndex].FindControl("hdPostAutoId");
        var txtItemEffectiveToTime = (TextBox)gvAsmtTagRef.Rows[e.RowIndex].FindControl("txtItemEffectiveToTime");

        if (string.IsNullOrEmpty(txtgvEffectiveTo.Text))
        {
            lblErrorMsg.Text = Resources.Resource.Required + " " + Resources.Resource.EffectiveTo;
            return;
        }
        if (string.IsNullOrEmpty(txtItemEffectiveToTime.Text))
        {
            lblErrorMsg.Text = Resources.Resource.Required + " " + Resources.Resource.EffectiveTo + Resources.Resource.Time;
            return;
        }
        ds = objRost.AsmtTagReferenceClose(hdClientCode.Value, hdAsmtId.Value, BaseLocationAutoID, lblgvTagId.Text, txtgvEffectiveTo.Text, txtItemEffectiveToTime.Text, hdPostAutoId.Value, BaseUserID, "");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
        }
        FillgvAsmtTagRef();
    }


    /// <summary>
    /// Handles the PageIndexChanging event of the gvAsmtTagRef control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAsmtTagRef_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAsmtTagRef.PageIndex = e.NewPageIndex;
        gvAsmtTagRef.EditIndex = -1;
        FillgvAsmtTagRef();
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvAsmtTagRef control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAsmtTagRef_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            if (IsDeleteAccess == false)
            {
                var ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var ddlAsmtCode = (DropDownList)e.Row.FindControl("ddlAsmtCode");
            var ddlClientCode = (DropDownList)e.Row.FindControl("ddlClientCode");
            var ddlPostCode = (DropDownList)e.Row.FindControl("ddlPostCode");
            if (IsWriteAccess == false)
            {
                gvAsmtTagRef.ShowFooter = false;
            }
            else
            {
                FillClientCode(ddlClientCode, ddlAsmtCode, ddlPostCode);
            }
        }
    }

    /// <summary>
    /// Fills the client code.
    /// </summary>
    /// <param name="ddlClientCode">The DDL client code.</param>
    /// <param name="ddlAsmtCode">The DDL asmt code.</param>
    /// <param name="ddlPostCode">The DDL post code.</param>
    private void FillClientCode(DropDownList ddlClientCode, DropDownList ddlAsmtCode, DropDownList ddlPostCode)
    {
        var intLocId = int.Parse(BaseLocationAutoID);
        var objSale = new BL.Sales();
        var dsClient = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);
        }

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = dsClient.Tables[0].DefaultView;
            ddlClientCode.DataTextField = "ClientName";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            FillddlAsmtCode(ddlAsmtCode, ddlClientCode, ddlPostCode);
        }
    }

    #endregion

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlAsmtCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlAsmtCode");
        var ddlClientCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlClientCode");
        var ddlPostCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlPostCode");
        FillddlAsmtCode(ddlAsmtCode, ddlClientCode, ddlPostCode);
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlAsmtCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlAsmtCode");
        var ddlPostCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlPostCode");
        //Modify by  on 14-Apr-2014
        var ddlClientCode = (DropDownList)gvAsmtTagRef.FooterRow.FindControl("ddlClientCode");
        FillddlPostCode(ddlPostCode, ddlClientCode, ddlAsmtCode);
    }
    /// <summary>
    /// Fillddls the asmt code.
    /// </summary>
    /// <param name="ddlAsmtCode">The DDL asmt code.</param>
    /// <param name="ddlClientCode">The DDL client code.</param>
    /// <param name="ddlPostCode">The DDL post code.</param>
    private void FillddlAsmtCode(DropDownList ddlAsmtCode, DropDownList ddlClientCode, DropDownList ddlPostCode)
    {
        var objOperationManagement = new BL.OperationManagement();
        var dsAsmt = new DataSet();
        var strFromDate = DateTime.Now.ToString("dd-MMM-yyyy");
        var strToDate = DateTime.Now.ToString("dd-MMM-yyyy");
        //Modify by  on 14-Apr-2014
        //dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), ddlClientCode.SelectedValue.ToString(), strFromDate, strToDate, BaseUserEmployeeNumber, BaseUserIsAreaIncharge,"");
        dsAsmt = objOperationManagement.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value);

        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = dsAsmt.Tables[0].DefaultView;
            //Modify by  on 14-Apr-2014
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();
            FillddlPostCode(ddlPostCode, ddlClientCode, ddlAsmtCode);
        }
        else
        {
            ddlAsmtCode.Items.Clear();
            ListItem Li = new ListItem();
            Li.Text = Resources.Resource.NoDataToShow;
            Li.Value = "";

            ddlAsmtCode.Items.Add(Li);
            Li = new ListItem();
            Li.Text = Resources.Resource.NoDataToShow;
            Li.Value = "";
            ddlPostCode.Items.Add(Li);
        }
    }

    /// <summary>
    /// Fillddls the post code.
    /// </summary>
    /// <param name="ddlPostCode"></param>
    /// <param name="ddlClientCode"></param>
    /// <param name="ddlAsmtCode"></param>
    private void FillddlPostCode(DropDownList ddlPostCode, DropDownList ddlClientCode, DropDownList ddlAsmtCode)
    {
        var ds = new DataSet();
        var objOperationManagement = new BL.OperationManagement();
        var strFromDate = DateTime.Now.ToString("dd-MMM-yyyy");
        var strToDate = DateTime.Now.ToString("dd-MMM-yyyy");
        //Modify by  on 14-Apr-2014
        ds = objOperationManagement.BLPOPGetAllPost(ddlAsmtCode.SelectedValue, BaseLocationAutoID, strFromDate, strToDate, ddlClientCode.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlPostCode.DataSource = ds.Tables[0];
            ddlPostCode.DataTextField = "Post";
            ddlPostCode.DataValueField = "PostAutoId";
            ddlPostCode.DataBind();
        }
        else
        {
            ddlPostCode.Items.Clear();
            ListItem Li = new ListItem();
            Li.Text = Resources.Resource.NoDataToShow;
            Li.Value = "";
            ddlPostCode.Items.Add(Li);
        }
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        var txtNewTagId = (TextBox)gvAsmtTagRef.FooterRow.FindControl("txtNewTagId");
        txtNewTagId.Text = "";
    }

    /// <summary>
    /// Fillgvs the asmt tag reference.
    /// </summary>
    protected void FillgvAsmtTagRef()
    {
        var objRost = new BL.Roster();
        var dsTagRef = new DataSet();
        var dtTagRef = new DataTable();
        //Modify by  on 14-Apr-2014
        dsTagRef = objRost.BlAsmtTagRefGet(BaseLocationAutoID, "");
        if (dsTagRef != null && dsTagRef.Tables.Count > 0 && dsTagRef.Tables[0].Rows.Count > 0)
        {
            gvAsmtTagRef.DataSource = dsTagRef;
            gvAsmtTagRef.DataBind();
        }
        else
        {
            dtTagRef = dsTagRef.Tables[0];
            dtTagRef.Rows.Add(dtTagRef.NewRow());
            gvAsmtTagRef.DataSource = dtTagRef;
            gvAsmtTagRef.DataBind();
            gvAsmtTagRef.Rows[0].Visible = false;
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
        //Modify by  on 14-Apr-2014
        dtSearche = objRost.BlAsmtTagRefGet(BaseLocationAutoID, "").Tables[0];
        
        //dtSearche.Columns["AsmtCode"].ColumnName = Resources.Resource.AsmtCode;
        dtSearche.Columns["TagId"].ColumnName = Resources.Resource.PhoneID;
        dtSearche.Columns["Client"].ColumnName = Resources.Resource.Client;

        var dt = new DataTable();
        var dv = new DataView(dtSearche);

        dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);

        dt = dv.ToTable();
        //dt.Columns[Resources.Resource.AsmtCode].ColumnName = "AsmtCode";
        dt.Columns[Resources.Resource.PhoneID].ColumnName = "TagId";
        dt.Columns[Resources.Resource.Client].ColumnName = "Client";

        gvAsmtTagRef.DataSource = dt;
        gvAsmtTagRef.DataBind();

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
        FillgvAsmtTagRef();
        btnViewAll.Visible = false;
    }

    /// <summary>
    /// Fillddls the search by.
    /// </summary>
    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        //arr.Add(gvAsmtTagRef.Columns[3]);
        arr.Add(gvAsmtTagRef.Columns[2]);
        arr.Add(gvAsmtTagRef.Columns[1]);

        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();
    }
    #endregion
}
