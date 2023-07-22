// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ClientMasterList.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Class Sales_ClientMasterList.
/// </summary>
public partial class Sales_ClientMasterList : BasePage //System.Web.UI.Page
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
    /// The index
    /// </summary>
    static int Index;
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Master != null)
            {
                //var lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
                //if (lblPageHdrTitle != null)
                //{
                //    lblPageHdrTitle.Text = Resources.Resource.ClientMaster;
                //}

                
                //Page Title from resource file
                System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resources.Resource.ClientMaster + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            }

            if (IsReadAccess == true)
            {
                /*Code modified by Manish  on 31-Aug-2011*/
                FillddlAreaID();
                /*End of Code modified by Manish  on 31-Aug-2011*/
                FillgvClientMaster();
                FillddlSearchBy();

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

            
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchClientByName(string prefixText, int count)
    {
        BL.Sales objSale = new BL.Sales();
        DataSet dsClient = new DataSet();

        dsClient = objSale.ClientMasterGetAll(2, "ALL", "", "0", DateTime.Now.ToString(), DateTime.Now.ToString());
        DataTable dt = (from a in dsClient.Tables[0].AsEnumerable() where a.Field<string>("ClientName").Contains(prefixText) select a).CopyToDataTable();
        List<string> item = new List<string>();
  //      item = dt.AsEnumerable().Select(a => a.Field<string>("ClientName")).ToList();
      
        return item;
    }
    #endregion

    #region GridView Binding
    /// <summary>
    /// Fillgvs the client master.
    /// </summary>
    protected void FillgvClientMaster()
    {
        BL.Sales objSale = new BL.Sales();
        DataSet dsClient = new DataSet();
        
        /*Code modified by Manish  on 31-Aug-2011*/
        dsClient = objSale.ClientMasterGetAll(int.Parse(BaseLocationAutoID), ddlAreaID.SelectedValue.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString());
        /*End of Code modified by Manish  on 31-Aug-2011*/
        gvClient.DataSource = dsClient;
        gvClient.DataBind();

        if (gvClient.Rows.Count == 0 && gvClient.DataSource != null)
        {
            DataTable dt = null;
            dt = ((DataSet)gvClient.DataSource).Tables[0].Clone();
            dt.Rows.Add(dt.NewRow());
            gvClient.DataSource = dt;
            gvClient.DataBind();

            // hide row
            gvClient.Rows[0].Visible = false;
            gvClient.Rows[0].Controls.Clear();

        }
    }
    #endregion

    #region Controles Events
    /// <summary>
    /// Handles the Click event of the lbtnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientMaster.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lblgvClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblgvClientCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblgvClientCode = (LinkButton)gvClient.Rows[row.RowIndex].FindControl("lblgvClientCode");
        Response.Redirect("ClientMaster.aspx?ClientCode=" + lblgvClientCode.Text);
    }
    /// <summary>
    /// Handles the Click event of the lbtnClientCompanyMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnClientCompanyMapping_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/CompanyClientList.aspx");
    }
    #endregion

    #region GridView events
    /// <summary>
    /// Handles the RowDataBound event of the gvClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvClient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
            if (IsDeleteAccess == true)
            {
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
            else
            {
                ImgbtnDelete.Visible = false;
            }
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvClient_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LinkButton lblgvClientCode = (LinkButton)gvClient.Rows[e.RowIndex].FindControl("lblgvClientCode");
        BL.Sales objSale = new BL.Sales();
        DataSet dsClient = new DataSet();
        dsClient = objSale.ClientMasterDelete(lblgvClientCode.Text);
        //Display message retrun from database         
        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, dsClient.Tables[0].Rows[0]["MessageID"].ToString());
        }
        FillgvClientMaster();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvClient.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvClient.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvClient.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvClient.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvClient.PageIndex = e.NewPageIndex;
        }
        gvClient.EditIndex = -1;
        FillgvClientMaster();
    }
    /// <summary>
    /// Handles the RowCommand event of the gvClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvClient_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvClient.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvClient.PageIndex = gvClient.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvClient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    /// <summary>
    /// Handles the DataBound event of the gvClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvClient_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvClient.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvClient.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvClient.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvClient.PageCount.ToString();
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvClient.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvClient.PageIndex = ddlPages.SelectedIndex;
        FillgvClientMaster();
    }
    #endregion

    #region Function Related to Search In Gridview LOI received
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlSearchBy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = "";
    }

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
        }

        if (txtSearch.Text != "")
        {

            hfSearchText.Value = txtSearch.Text.Trim();
            SearchAction();
        }
    }
    /// <summary>
    /// Function To Search In grid view LOI Received Based on ddlSearchBy and txtSearch Value
    /// </summary>
    private void SearchAction()
    {
        BL.Sales objSale = new BL.Sales();
        DataTable dtClient = new DataTable();
        //dtClient = objSale.blClientMaster_GetAll().Tables[0];
        /*Code modified by Manish  on 31-Aug-2011*/
        dtClient = objSale.ClientMasterGetAll(int.Parse(BaseLocationAutoID), ddlAreaID.SelectedValue.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString()).Tables[0];
        /*End of Code modified by Manish  on 31-Aug-2011*/
        dtClient.Columns["ClientCode"].ColumnName = Resources.Resource.ClientCode;
        dtClient.Columns["ManualClientCode"].ColumnName = Resources.Resource.ManualClientCode;
        dtClient.Columns["ClientName"].ColumnName = Resources.Resource.ClientName;
        DataTable dt = new DataTable();
        DataView dv = new DataView(dtClient);
        //Line Added By Ajay Datta On 19-Jun-2013 - Bug ID 351 - Problem in Hebrew Employee/Client Search
        hfSearchText.Value = BL.Common.ValidateSpecialCharacter(hfSearchText.Value);
        dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);

        dt = dv.ToTable();
        dt.Columns[Resources.Resource.ClientCode].ColumnName = "ClientCode";
        dt.Columns[Resources.Resource.ManualClientCode].ColumnName = "ManualClientCode";
        dt.Columns[Resources.Resource.ClientName].ColumnName = "ClientName";
        gvClient.DataSource = dt;
        gvClient.DataBind();
    }
    /// <summary>
    /// Handles the Click event of the btnViewAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        FillgvClientMaster();
    }
    /// <summary>
    /// Fillddls the search by.
    /// </summary>
    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        arr.Add(gvClient.Columns[2]);
        arr.Add(gvClient.Columns[3]);
        arr.Add(gvClient.Columns[4]);
        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();

    }
    #endregion

    /*Code modified by Manish  on 31-Aug-2011*/
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillgvClientMaster();
    }

    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaID()
    {

        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();
        dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(),BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString());
        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataSource = dsClient;
            ddlAreaID.DataBind();

            ListItem li = new ListItem(Resources.Resource.All.ToString(), "ALL");
            ddlAreaID.Items.Insert(0, li);
        }
        else
        {
            ddlAreaID.Items.Clear();
            ListItem li = new ListItem(Resources.Resource.NoDataToShow.ToString(), "");
            ddlAreaID.Items.Add(li);
        }

    }
    /*End of Code modified by Manish  on 31-Aug-2011*/
}
