// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 05-21-2014
// ***********************************************************************
// <copyright file="LocationTagReference.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Transactions_LocationTagReference : BasePage
{
    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>

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

    #region Page Load Event
    /// <summary>
    /// Function called on Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        var lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
        if (lblPageHdrTitle != null)
        {
            lblPageHdrTitle.Text = Resources.Resource.TagId;
        }
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                FillgvLocTagRef();
                FillddlSearchBy();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Functions related to Grid View Events
    /// <summary>
    /// Function called on Grid View Location Tag RowCommand Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLocTagRef_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objRost = new BL.Roster();
        var ds = new DataSet();
        try
        {
            var gvrow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

            if (e.CommandName == "Add New")
            {
                var ddlTagType = (DropDownList)gvLocTagRef.FooterRow.FindControl("ddlTagType");
                var txtNewTagId = (TextBox)gvLocTagRef.FooterRow.FindControl("txtNewTagId");
                var txtTagDesc = (TextBox)gvLocTagRef.FooterRow.FindControl("txtTagDesc");
                var txtEffectiveFrom = (TextBox)gvLocTagRef.FooterRow.FindControl("txtEffectiveFrom");
                var ddlPostID = (DropDownList)gvLocTagRef.FooterRow.FindControl("ddlPostID");
                try
                {
                    txtEffectiveFrom.Text = (DateTime.Parse(txtEffectiveFrom.Text)).ToString();
                }
                catch
                {
                    lblErrorMsg.Text = "Invalid From Date!";
                    txtEffectiveFrom.Text = string.Empty;
                    txtEffectiveFrom.Focus();
                    return;
                }
                //Modify by  on 04-May-2014
                ds = objRost.LocationTagReferenceInsert(BaseLocationAutoID, ddlTagType.SelectedItem.Value, txtNewTagId.Text, txtTagDesc.Text, ddlPostID.SelectedValue, txtEffectiveFrom.Text, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                }
                FillgvLocTagRef();
            }

            else if (e.CommandName == "Delete1")
            {
                var lblgvTagId = (Label)gvrow.FindControl("lblgvTagId");
                var lblgvTagType = (Label)gvrow.FindControl("lblgvTagType");
                var lblgvTagDesc = (Label)gvrow.FindControl("lblgvTagDesc");
                var lblgvPost = (Label)gvrow.FindControl("lblgvPost");
                var txtgvEffectiveTo = (TextBox)gvrow.FindControl("txtgvEffectiveTo");
                //Added by  on 04-May-2014
                if (string.IsNullOrEmpty(txtgvEffectiveTo.Text))
                {
                    txtgvEffectiveTo.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }

                //Modify by  on 04-May-2014
                ds = objRost.LocationTagReferenceClose(lblgvTagId.Text, txtgvEffectiveTo.Text, BaseUserID, "Delete");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                }
                FillgvLocTagRef();
            }
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// Function called on Grid View Location Tag RowDeleting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLocTagRef_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objRost = new BL.Roster();
        var ds = new DataSet();
        var lblgvTagId = (Label)gvLocTagRef.Rows[e.RowIndex].FindControl("lblgvTagId");
        var lblgvEmployeeNumber = (Label)gvLocTagRef.Rows[e.RowIndex].FindControl("lblgvEmployeeNumber");
        var txtgvEffectiveTo = (TextBox)gvLocTagRef.Rows[e.RowIndex].FindControl("txtgvEffectiveTo");

        //Modify by  on 04-May-2014
        ds = objRost.LocationTagReferenceClose(lblgvTagId.Text, txtgvEffectiveTo.Text, BaseUserID, "");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
        }
        FillgvLocTagRef();
    }

    /// <summary>
    /// Function called on Grid View Location Tag PageIndexChanging Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLocTagRef_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLocTagRef.PageIndex = e.NewPageIndex;
        gvLocTagRef.EditIndex = -1;
        FillgvLocTagRef();
        if (!string.IsNullOrEmpty(txtSearch.Text))
        {
            btnViewAll.Visible = true;
            hfSearchText.Value = txtSearch.Text.Trim();
            //SearchAction();               //Commented By  on 10-May-2014
        }
    }

    /// <summary>
    /// Function called on Grid View Location Tag RowDataBound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLocTagRef_RowDataBound(object sender, GridViewRowEventArgs e)
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
            //Modified By  on 22-May-2014
            var ddlAsmtCode = (DropDownList)e.Row.FindControl("ddlAsmtCode");
            var ddlClientCode = (DropDownList)e.Row.FindControl("ddlClientCode");
            var ddlPostId = (DropDownList)e.Row.FindControl("ddlPostID");
            if (IsWriteAccess == false)
            {
                gvLocTagRef.ShowFooter = false;
            }
            else
            {
                FillClientCode(ddlClientCode, ddlAsmtCode, ddlPostId);
            }
        }
    }
    #endregion

    #region Member Functions for Fill Drop Down List
    /// <summary>
    /// Function used to fill Drop Down SearchBy.
    /// </summary>
    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        arr.Add(gvLocTagRef.Columns[2]);
        arr.Add(gvLocTagRef.Columns[3]);
        //arr.Add(gvLocTagRef.Columns[1]);

        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();
    }

    /// <summary>
    /// Function used to fill Grid View Location Tag Reference.
    /// </summary>
    protected void FillgvLocTagRef()
    {
        var objRost = new BL.Roster();
        var dsTagRef = new DataSet();
        var dtTagRef = new DataTable();
        //Modify by  on 04-May-2014
        dsTagRef = objRost.BlLocationTagRefGet("");
        if (dsTagRef != null && dsTagRef.Tables.Count > 0 && dsTagRef.Tables[0].Rows.Count > 0)
        {
            gvLocTagRef.DataSource = dsTagRef;
            gvLocTagRef.DataBind();
        }
        else
        {
            dtTagRef = dsTagRef.Tables[0];
            dtTagRef.Rows.Add(dtTagRef.NewRow());
            gvLocTagRef.DataSource = dtTagRef;
            gvLocTagRef.DataBind();
            gvLocTagRef.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
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
            ddlClientCode.DataTextField = "ClientCodeName";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            FillddlAsmtCode(ddlClientCode, ddlAsmtCode, ddlPostCode);
        }
    }

    /// <summary>
    /// Fillddls the asmt code.
    /// </summary>
    /// <param name="ddlAsmtCode">The DDL asmt code.</param>
    /// <param name="ddlClientCode">The DDL client code.</param>
    /// <param name="ddlPostCode">The DDL post code.</param>
    private void FillddlAsmtCode(DropDownList ddlClientCode, DropDownList ddlAsmtCode, DropDownList ddlPostCode)
    {
        var objOperationManagement = new BL.OperationManagement();
        var dsAsmt = new DataSet();
        dsAsmt = objOperationManagement.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value);
        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = dsAsmt.Tables[0].DefaultView;
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();
            FillddlPostCode(ddlClientCode, ddlAsmtCode, ddlPostCode);
        }
        else
        {
            ddlAsmtCode.Items.Clear();
            var Li = new ListItem();
            Li.Text = Resources.Resource.NoDataToShow;
            Li.Value = string.Empty;
            ddlAsmtCode.Items.Add(Li);

            ddlPostCode.Items.Clear();
            Li = new ListItem();
            Li.Text = Resources.Resource.NoDataToShow;
            Li.Value = string.Empty;
            ddlPostCode.Items.Add(Li);
        }
    }

    /// <summary>
    /// Fillddls the post code.
    /// </summary>
    /// <param name="ddlPostCode">The DDL post code.</param>
    /// <param name="ddlAsmtCode">The DDL asmt code.</param>
    private void FillddlPostCode(DropDownList ddlClientCode, DropDownList ddlAsmtCode, DropDownList ddlPostCode)
    {
        var ds = new DataSet();
        var objOperationManagement = new BL.OperationManagement();
        var strFromDate = DateTime.Now.ToString("dd-MMM-yyyy");
        var strToDate = DateTime.Now.ToString("dd-MMM-yyyy");
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
            var Li = new ListItem();
            Li.Text = Resources.Resource.NoDataToShow;
            Li.Value = string.Empty;
            ddlPostCode.Items.Add(Li);
        }
    }
    #endregion

    #region Functions related to Drop Down Events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlClientCode = (DropDownList)gvLocTagRef.FooterRow.FindControl("ddlClientCode");
        var ddlAsmtCode = (DropDownList)gvLocTagRef.FooterRow.FindControl("ddlAsmtCode");
        var ddlPostCode = (DropDownList)gvLocTagRef.FooterRow.FindControl("ddlPostID");
        FillddlAsmtCode(ddlClientCode, ddlAsmtCode, ddlPostCode);
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlClientCode = (DropDownList)gvLocTagRef.FooterRow.FindControl("ddlClientCode");
        var ddlAsmtCode = (DropDownList)gvLocTagRef.FooterRow.FindControl("ddlAsmtCode");
        var ddlPostCode = (DropDownList)gvLocTagRef.FooterRow.FindControl("ddlPostID");
        FillddlPostCode(ddlClientCode, ddlAsmtCode, ddlPostCode);
    }
    #endregion

    #region Functions Related to Button Controls
    /// <summary>
    /// Function called on button Reset Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        var txtNewTagId = (TextBox)gvLocTagRef.FooterRow.FindControl("txtNewTagId");
        var txtTagDesc = (TextBox)gvLocTagRef.FooterRow.FindControl("txtTagDesc");
        txtNewTagId.Text = "";
        txtTagDesc.Text = "";
    }
    
    /// <summary>
    /// Function called on button Search Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSearch.Text))
        {
            btnViewAll.Visible = true;
            hfSearchText.Value = txtSearch.Text.Trim();
            SearchAction();
        }
    }

    /// <summary>
    /// /// Function used for Search
    /// </summary>
    private void SearchAction()
    {
        lblErrorMsg.Text = string.Empty;

        var objRost = new BL.Roster();
        var dtSearche = new DataTable();
        //Modify by  on 04-May-2014
        dtSearche = objRost.BlLocationTagRefGet("").Tables[0];
        dtSearche.Columns["TagId"].ColumnName = Resources.Resource.TagId;
        dtSearche.Columns["TagDescription"].ColumnName = Resources.Resource.TagDescription;
        
        var dt = new DataTable();
        var dv = new DataView(dtSearche);
        dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);

        dt = dv.ToTable();
        dt.Columns[Resources.Resource.TagId].ColumnName = "TagId";
        dt.Columns[Resources.Resource.TagDescription].ColumnName = "TagDescription";
        dt.Columns[Resources.Resource.TagId].ColumnName = "TagId";
        gvLocTagRef.DataSource = dt;
        gvLocTagRef.DataBind();

        if (dt.Rows.Count < 1)
        {
            lblErrorMsg.Text = "no record found!";
        }
    }

    /// <summary>
    /// Function used to show all records.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        FillgvLocTagRef();
        btnViewAll.Visible = false;
    }

    /// <summary>
    /// Function used to Export records.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string url = "../MonitorScreen/Export.aspx?type=MASTERPOP&EType=LOCATION";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }
    #endregion
}
