// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By :  
// Last Modified On : 14-Apr-2014
// ***********************************************************************
// <copyright file="PopInterval.aspx.cs" company="Magnon">
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

public partial class TestPages_PopInterval : BasePage //System.Web.UI.Page
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

    #region page Load
    /// <summary>
    /// Function called on page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
        lblErrorMsg.Text = string.Empty;
        if (lblPageHdrTitle != null)
        {
            lblPageHdrTitle.Text = Resources.Resource.TagId;
        }
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                Fillgv();
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
    /// Function called on Grid View RowCommand event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objMics = new BL.Misc();
        var ds = new DataSet();
        try
        {
            var gvrow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            if (e.CommandName == "Add New")
            {
                var ddlAsmtCode = (DropDownList)gv.FooterRow.FindControl("ddlAsmtCode");
                var txtEffectiveFrom = (TextBox)gv.FooterRow.FindControl("txtEffectiveFrom");
                var txtNewTagId = (TextBox)gv.FooterRow.FindControl("txtNewTagId");
                var ddlPostCode = (DropDownList)gv.FooterRow.FindControl("ddlPostCode");
                var ddlClientCode = (DropDownList)gv.FooterRow.FindControl("ddlClientCode");
                var ddlNewInterval = (DropDownList)gv.FooterRow.FindControl("ddlNewInterval");

                if (string.IsNullOrEmpty(txtEffectiveFrom.Text))
                {
                    lblErrorMsg.Text = Resources.Resource.Required + " " + Resources.Resource.StartTime;
                    return;
                }
                ds = objMics.blPopInterval_Insert(ddlAsmtCode.SelectedValue, ddlClientCode.SelectedValue, txtEffectiveFrom.Text, ddlPostCode.SelectedItem.Value, ddlNewInterval.SelectedItem.Value, BaseUserID,BaseLocationAutoID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                }
                Fillgv();
            }
            else if (e.CommandName == "Delete1")
            {
                var lblgvAsmtCode = (Label)gvrow.FindControl("lblgvAsmtCode");
                var lblgvPostCode = (Label)gvrow.FindControl("lblgvPostCode");
                var lblgvClientCode = (Label)gvrow.FindControl("lblgvClientCode");

                ds = objMics.blPopInterval_Close(lblgvAsmtCode.Text, lblgvClientCode.Text,lblgvPostCode.Text, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                }
                Fillgv();
            }
        }
        catch (Exception ex)
        { }
    }

    /// <summary>
    /// Function called on Grid View RowDeleting event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objMis = new BL.Misc();
        var ds = new DataSet();
        var lblgvAsmtCode = (Label)gv.Rows[e.RowIndex].FindControl("lblgvAsmtCode");
        var lblgvPostCode = (HiddenField)gv.Rows[e.RowIndex].FindControl("hdgvPostCode");
        var lblgvClientCode = (Label)gv.Rows[e.RowIndex].FindControl("lblgvClientCode");
        ds = objMis.blPopInterval_Close(lblgvAsmtCode.Text,lblgvClientCode.Text,lblgvPostCode.Value, BaseUserID.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
        }
        Fillgv();
    }

    /// <summary>
    /// Function called on Grid View PageIndexChanging event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        gv.EditIndex = -1;
        Fillgv();
    }

    /// <summary>
    /// Function called on Grid View RowDataBound event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
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
                gv.ShowFooter = false;
            }
            else
            {
                FillClientCode(ddlClientCode, ddlAsmtCode, ddlPostCode);

            }
        }
    }

    /// <summary>
    /// Function called on Grid View RowCancelingEditing event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        Fillgv();
    }
    
    /// <summary>
    /// Funtion used to fill Client
    /// </summary>
    /// <param name="ddlClientCode"></param>
    /// <param name="ddlAsmtCode"></param>
    /// <param name="ddlPostCode"></param>
    private void FillClientCode(DropDownList ddlClientCode, DropDownList ddlAsmtCode, DropDownList ddlPostCode)
    {
        int intLocId = int.Parse(BaseLocationAutoID);
        var objSale = new BL.Sales();
        var dsClient = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "c")
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
            FillddlAsmtCode(ddlAsmtCode, ddlClientCode, ddlPostCode);
        }
    }
    #endregion

    /// <summary>
    /// Function  called on Drop Down ClientCode SelectedIndexChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlAsmtCode = (DropDownList)gv.FooterRow.FindControl("ddlAsmtCode");
        var ddlClientCode = (DropDownList)gv.FooterRow.FindControl("ddlClientCode");
        var ddlPostCode = (DropDownList)gv.FooterRow.FindControl("ddlPostCode");
        FillddlAsmtCode(ddlAsmtCode, ddlClientCode, ddlPostCode);
    }

    /// <summary>
    /// Function  called on Drop Down AsmtCode SelectedIndexChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlClientCode = (DropDownList)gv.FooterRow.FindControl("ddlClientCode");
        var ddlAsmtCode = (DropDownList)gv.FooterRow.FindControl("ddlAsmtCode");
        var ddlPostCode = (DropDownList)gv.FooterRow.FindControl("ddlPostCode");
        FillddlPostCode(ddlPostCode, ddlAsmtCode, ddlClientCode);
    }

    /// <summary>
    /// Funtion used to fill Assignment
    /// </summary>
    /// <param name="ddlAsmtCode"></param>
    /// <param name="ddlClientCode"></param>
    /// <param name="ddlPostCode"></param>
    private void FillddlAsmtCode(DropDownList ddlAsmtCode, DropDownList ddlClientCode, DropDownList ddlPostCode)
    {
        var objOperationManagement = new BL.OperationManagement();
        var dsAsmt = new DataSet();
        var strFromDate = DateTime.Now.ToString("dd-MMM-yyyy");
        var strToDate = DateTime.Now.ToString("dd-MMM-yyyy");
        dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), ddlClientCode.SelectedValue.ToString(), strFromDate, strToDate);
        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = dsAsmt.Tables[0].DefaultView;
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();
            FillddlPostCode(ddlPostCode, ddlAsmtCode, ddlClientCode);
        }
        else
        {
            ddlAsmtCode.Items.Clear();
            var Li = new ListItem();
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
    /// Funtion used to fill Post
    /// </summary>
    /// <param name="ddlPostCode"></param>
    /// <param name="ddlAsmtCode"></param>
    /// <param name="ddlClientCode"></param>
    private void FillddlPostCode(DropDownList ddlPostCode, DropDownList ddlAsmtCode,DropDownList ddlClientCode)
    {
        var ds = new DataSet();
        var objOperationManagement = new BL.OperationManagement();
        var strFromDate = DateTime.Now.ToString("dd-MMM-yyyy");
        var strToDate = DateTime.Now.ToString("dd-MMM-yyyy");
        ds = objOperationManagement.BLPOPGetAllPost(ddlAsmtCode.SelectedValue, BaseLocationAutoID, strFromDate, strToDate, ddlClientCode.SelectedValue);
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
            Li.Value = "";
            ddlPostCode.Items.Add(Li);
        }
    }

    /// <summary>
    /// Function called on button Reset click event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        TextBox txtNewTagId = (TextBox)gv.FooterRow.FindControl("txtNewTagId");
        txtNewTagId.Text = string.Empty;
    }

    /// <summary>
    /// Function used to fill grid view.
    /// </summary>
    protected void Fillgv()
    {
        var objMics = new BL.Misc();
        var dsTagRef = new DataSet();
        var dtTagRef = new DataTable();
        dsTagRef = objMics.blPopInterval_Get(BaseLocationAutoID,"");
        if (dsTagRef != null && dsTagRef.Tables.Count > 0 && dsTagRef.Tables[0].Rows.Count > 0)
        {
            gv.DataSource = dsTagRef;
            gv.DataBind();
        }
        else
        {
            dtTagRef = dsTagRef.Tables[0];
            dtTagRef.Rows.Add(dtTagRef.NewRow());
            gv.DataSource = dtTagRef;
            gv.DataBind();
            gv.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }

    /// <summary>
    /// Function called on grid view RowEditing event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;
        Fillgv();
    }

    /// <summary>
    ///  Function called on grid view RowUpdating event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var txtPopStartTime = (TextBox)gv.Rows[e.RowIndex].FindControl("txtPopStartTime");
        var ddlInterval = (DropDownList)gv.Rows[e.RowIndex].FindControl("ddlInterval");
        var lblgvClientCode = (Label)gv.Rows[e.RowIndex].FindControl("lblgvClientCode");
        var lblgvAsmtCode = (Label)gv.Rows[e.RowIndex].FindControl("lblgvAsmtCode");
        
        var objMics = new BL.Misc();
        var ds = new DataSet();
        var txtStartTime = "01-01-1900" + " " + txtPopStartTime.Text;

        ds = objMics.BlPopInterval_Update(lblgvClientCode.Text, lblgvAsmtCode.Text, ddlInterval.SelectedItem.Value, txtStartTime);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        gv.EditIndex = -1;
        Fillgv();
       }
       
    #region Function Related to Search In Gridview // Commented for future use

    protected void btnSearch_Click(object sender, EventArgs e)
   {
    //    if (txtSearch.Text != "")
    //    {
    //        btnViewAll.Visible = true;
    //        hfSearchText.Value = txtSearch.Text.Trim();
    //        SearchAction();
       }

    //}

  // private void SearchAction()
    //{
    //    lblErrorMsg.Text = "";

    //    BL.Roster objRost = new BL.Roster();
    //    DataTable dtSearche = new DataTable();

    //    dtSearche = objRost.blAsmtTagRef_Get("", "Active").Tables[0];
    //    dtSearche.Columns["AsmtCode"].ColumnName = Resources.Resource.AsmtCode;
    //    dtSearche.Columns["TagId"].ColumnName = Resources.Resource.TagId;
    //    dtSearche.Columns["ClientName"].ColumnName = Resources.Resource.ClientName;

    //    DataTable dt = new DataTable();
    //    DataView dv = new DataView(dtSearche);

    //    dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);

    //    dt = dv.ToTable();
    //    dt.Columns[Resources.Resource.AsmtCode].ColumnName = "AsmtCode";
    //    dt.Columns[Resources.Resource.TagId].ColumnName = "TagId";
    //    dt.Columns[Resources.Resource.ClientName].ColumnName = "ClientName";

    //    gv.DataSource = dt;
    //    gv.DataBind();

    //    if (dt.Rows.Count < 1)
    //    {
    //        lblErrorMsg.Text = "no record found!";
    //    }


 // }

   protected void btnViewAll_Click(object sender, EventArgs e)
   {

    //    Fillgv();
        //btnViewAll.Visible = false;
  }

   private void FillddlSearchBy()
  {
    //    ArrayList arr = new ArrayList();
    //    arr.Add(gv.Columns[3]);
    //    arr.Add(gv.Columns[2]);
    //    arr.Add(gv.Columns[1]);

    //    ddlSearchBy.DataSource = arr;
    //    ddlSearchBy.DataTextField = "HeaderText";
    //    ddlSearchBy.DataValueField = "HeaderText";
    //    ddlSearchBy.DataBind();

  }
    #endregion
}
