// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="CompanyClientList.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_CompanyClientList.
/// </summary>
public partial class Sales_CompanyClientList : BasePage //System.Web.UI.Page
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

    #region Page function
    /// <summary>
    /// The index
    /// </summary>
    static int Index;
    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
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
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.ClientCompanyMapping.ToString(); }

            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Client + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvClient();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            if (IsWriteAccess == true)
            {
                lbMapClient.Visible = true;
            }
            else
            {
                lbMapClient.Visible = false;
            }
        }

    }
    #endregion

    #region Data Binding
    /// <summary>
    /// Fillgvs the client.
    /// </summary>
    protected void FillgvClient()
    {

        BL.Sales objSale = new BL.Sales();
        DataSet dsClient = new DataSet();

        dsClient = objSale.ClientsCompanyWiseGet(BaseCompanyCode);
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
    
    #region link buttons 
    /// <summary>
    /// Handles the Click event of the lbMapClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbMapClient_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/CompanyClient.aspx?ClientCode=");
    }
    /// <summary>
    /// Handles the Click event of the lbgvClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbgvClientCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbgvClientCode = (LinkButton)gvClient.Rows[row.RowIndex].FindControl("lbgvClientCode");
        Response.Redirect("../Sales/CompanyClient.aspx?ClientCode=" + lbgvClientCode.Text);
    }
    /// <summary>
    /// Handles the Click event of the lbAddClientToLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbAddClientToLocation_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientMapping.aspx");
    }
    #endregion

    #region Grid View Events
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
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                    gvClient.Columns[0].Visible = false;
                }
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
        LinkButton lbgvClientCode = (LinkButton)gvClient.Rows[e.RowIndex].FindControl("lbgvClientCode");
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();

        ds = objSale.ClientCompanyMappingDelete(lbgvClientCode.Text, BaseCompanyCode, int.Parse(BaseLocationAutoID));
        //Display message retrun from database         
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        FillgvClient();
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
        FillgvClient();
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
        FillgvClient();
    }
    #endregion 

}
