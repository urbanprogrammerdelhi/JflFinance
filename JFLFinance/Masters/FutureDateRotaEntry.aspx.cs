// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="FutureDateRotaEntry.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_FutureDateRotaEntry
/// </summary>
public partial class Masters_FutureDateRotaEntry : BasePage //System.Web.UI.Page
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

    #region Page Functions
    /// <summary>
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Page_PreInit(object sender, EventArgs e)
    {
        this.MasterPageFile = ! string.IsNullOrEmpty(BaseLocationAutoID) ? "~/MasterPage/MasterPage.master" : "~/MasterPage/MasterHeader.master";
    }

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
            javaScript.Append("PageTitle('" + Resources.Resource.FutureDateRotaEntry + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (string.IsNullOrEmpty(BaseLocationAutoID) && BaseIsAdmin == "SA")
            { imgBack.Visible = true; }
            else
            { imgBack.Visible = false; }

            if (IsReadAccess)
            {
                FillgvFutureDateRotaEntry();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Controles Binding

    /// <summary>
    /// Fillgvs the future date rota entry.
    /// </summary>
    protected void FillgvFutureDateRotaEntry()
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet dsFutureDateRotaEntry = new DataSet();
        DataTable dtFutureDateRotaEntry = new DataTable();

        dsFutureDateRotaEntry = objMasterManagement.FutureDateRotaEntryGetAll(BaseCompanyCode, BaseLocationAutoID);

        if (dsFutureDateRotaEntry != null && dsFutureDateRotaEntry.Tables.Count > 0 && dsFutureDateRotaEntry.Tables[0].Rows.Count > 0)
        {
            gvFutureDateRotaEntry.DataSource = dsFutureDateRotaEntry;
            gvFutureDateRotaEntry.DataBind();
        }
        else
        {
            dtFutureDateRotaEntry = dsFutureDateRotaEntry.Tables[0];
            dtFutureDateRotaEntry.Rows.Add(dtFutureDateRotaEntry.NewRow());
            gvFutureDateRotaEntry.DataSource = dtFutureDateRotaEntry;
            gvFutureDateRotaEntry.DataBind();
            gvFutureDateRotaEntry.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }

    #endregion

    #region GridView Commands Events

    /// <summary>
    /// Handles the RowDataBound event of the gvFutureDateRotaEntry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvFutureDateRotaEntry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvFutureDateRotaEntry.PageIndex * gvFutureDateRotaEntry.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvFutureDateRotaEntry.Columns[8].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');"; }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvFutureDateRotaEntry.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                DropDownList ddlClient = (DropDownList)e.Row.FindControl("ddlClient");
                DropDownList ddlAssignment = (DropDownList)e.Row.FindControl("ddlAssignment");
                DropDownList ddlAllowed = (DropDownList)e.Row.FindControl("ddlAllowed");

                if (IsWriteAccess == false)
                {
                    gvFutureDateRotaEntry.ShowFooter = false;
                }
                else
                {
                    FillClientCode(ddlClient, ddlAssignment);
                    
                    //Code To Fill The Allowed Combo//
                    ddlAllowed.Items.Clear();
                    ListItem li = new ListItem();
                    li = new ListItem();
                    li.Text = Resources.Resource.Yes.ToString();
                    li.Value = "Y";
                    ddlAllowed.Items.Add(li);


                    li = new ListItem();
                    li.Text = Resources.Resource.No.ToString();
                    li.Value = "N";
                    ddlAllowed.Items.Add(li);
                }
            }
        }
    }

    /// <summary>
    /// Fills the client code.
    /// </summary>
    /// <param name="ddlClientCode">The DDL client code.</param>
    /// <param name="ddlAsmtCode">The DDL asmt code.</param>
    private void FillClientCode(DropDownList ddlClientCode, DropDownList ddlAsmtCode)
    {
        int intLocId = int.Parse(BaseLocationAutoID);
        BL.Sales objSale = new BL.Sales();
        DataSet dsClient = new DataSet();
        dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = dsClient.Tables[0].DefaultView;
            ddlClientCode.DataTextField = "ClientName";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            FillddlAsmtCode(ddlAsmtCode, ddlClientCode);
        }
    }

    /// <summary>
    /// Fillddls the asmt code.
    /// </summary>
    /// <param name="ddlAsmtCode">The DDL asmt code.</param>
    /// <param name="ddlClientCode">The DDL client code.</param>
    private void FillddlAsmtCode(DropDownList ddlAsmtCode, DropDownList ddlClientCode)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet dsAsmt = new DataSet();
        string strFromDate = DateTime.Now.ToString("dd-MMM-yyyy");
        string strToDate = DateTime.Now.ToString("dd-MMM-yyyy");
        dsAsmt = objOperationManagement.AssignmentsOfClientForFutureDateRotaGet(int.Parse(BaseLocationAutoID), ddlClientCode.SelectedValue.ToString(), strFromDate, strToDate);
        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = dsAsmt.Tables[0].DefaultView;
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();
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
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvFutureDateRotaEntry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvFutureDateRotaEntry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        // To Insert a New Row

        DropDownList ddlClient = (DropDownList)gvFutureDateRotaEntry.FooterRow.FindControl("ddlClient");
        DropDownList ddlAssignment = (DropDownList)gvFutureDateRotaEntry.FooterRow.FindControl("ddlAssignment");
        DropDownList ddlAllowed = (DropDownList)gvFutureDateRotaEntry.FooterRow.FindControl("ddlAllowed");

        if (e.CommandName == "Add")
        {
            if (ddlClient.SelectedItem.Value.ToString() != "" && ddlAssignment.SelectedItem.Value.ToString() != "" && ddlAllowed.SelectedItem.Value.ToString() != "")
            {
                ds = objMastersManagement.FutureDateRotaEntryAddNew(BaseCompanyCode, BaseLocationAutoID, ddlClient.SelectedItem.Value.ToString(), ddlAssignment.SelectedItem.Value.ToString(), ddlAllowed.SelectedItem.Value.ToString(), BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
                gvFutureDateRotaEntry.EditIndex = -1;
                FillgvFutureDateRotaEntry();
                
            }
        }
        if (e.CommandName == "Reset")
        {
            //txtLocationCode.Text = "";
            //txtLocationDesc.Text = "";
            //txtLocationAddress.Text = "";
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvFutureDateRotaEntry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvFutureDateRotaEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        HiddenField HFItmClient = (HiddenField)gvFutureDateRotaEntry.Rows[e.RowIndex].FindControl("HFItmClient");
        HiddenField HFItmAssignment = (HiddenField)gvFutureDateRotaEntry.Rows[e.RowIndex].FindControl("HFItmAssignment");

        ds = objMastersManagement.FutureDateRotaEntryDelete(BaseCompanyCode, BaseLocationAutoID, HFItmClient.Value.ToString(), HFItmAssignment.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        FillgvFutureDateRotaEntry();
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvFutureDateRotaEntry control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvFutureDateRotaEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFutureDateRotaEntry.PageIndex = e.NewPageIndex;
        gvFutureDateRotaEntry.EditIndex = -1;
        FillgvFutureDateRotaEntry();
    }

    #endregion

    #region Controles Command Events

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlClient = (DropDownList)gvFutureDateRotaEntry.FooterRow.FindControl("ddlClient");
        DropDownList ddlAssignment = (DropDownList)gvFutureDateRotaEntry.FooterRow.FindControl("ddlAssignment");
        FillddlAsmtCode(ddlAssignment, ddlClient);
    }

    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MasterMenu.aspx");
    }
    #endregion

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

}
