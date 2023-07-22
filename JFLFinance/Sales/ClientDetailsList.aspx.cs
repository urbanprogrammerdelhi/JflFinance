// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ClientDetailsList.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_ClientDetailsList.
/// </summary>
public partial class Sales_ClientDetailsList : BasePage //System.Web.UI.Page
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
            //    lblPageHdrTitle.Text = Resources.Resource.ClientDetails;
            //}
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ClientDetails + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillddlAreaID();
                FillddlClient();
                if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length != 0)
                {
                   // ddlClient.Items.FindByValue(Request.QueryString["ClientCode"].ToString()).Selected.ToString();
                    ddlClient.SelectedValue = Request.QueryString["ClientCode"].ToString();
                }
                FillgvClientDetails();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            //if (!IsWriteAccess)
            //{
            //    lbtnCreateAsmtId.Visible = false;
            //}

            // Add CCH for ClientCode              
            ImgClientCode_CCH.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + txtClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=360,help=no')");

        }
    }
    #endregion

    #region Bind GridView
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString(), txtClientCode.Text.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientCodeName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlClient.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillgvs the client details.
    /// </summary>
    protected void FillgvClientDetails()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        BL.Sales objSale = new BL.Sales();
        int dtflag;
        dtflag = 1;
        ds = objSale.ClientDetailsGet(BaseLocationAutoID, ddlClient.SelectedItem.Value.ToString(), ddlAreaID.SelectedItem.Value.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        
        
        gvClientDetails.DataSource = dt;
        gvClientDetails.DataBind();
        
    

        if (dtflag == 0)//to fix empety gridview
        {
            gvClientDetails.Rows[0].Visible = false;
        }
    }
    #endregion

    #region Controles Events
    /// <summary>
    /// Handles the Click event of the lbtnCreateAsmtId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnCreateAsmtId_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/CreateAsmtId.aspx?ClientCode=" + ddlClient.SelectedItem.Value.ToString());
    }
    /// <summary>
    /// Handles the Click event of the ImgbtnPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnPost_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton objImageButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objImageButton.NamingContainer;
        LinkButton lblgvAsmtId = (LinkButton)gvClientDetails.Rows[row.RowIndex].FindControl("lblgvAsmtId");
        Response.Redirect("ClientAsmtPost.aspx?ClientCode=" + ddlClient.SelectedItem.Value.ToString() + "&AsmtId=" + lblgvAsmtId.Text);
    }
    /// <summary>
    /// Handles the Click event of the lbtnClientList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnClientList_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientMasterList.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbtnClientMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnClientMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientMaster.aspx?ClientCode=" + ddlClient.SelectedItem.Value.ToString());
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClientCode.Text = ddlClient.SelectedItem.Value;
        FillgvClientDetails();
    }
    /// <summary>
    /// Handles the Click event of the lblgvAsmtId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblgvAsmtId_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblgvAsmtId = (LinkButton)gvClientDetails.Rows[row.RowIndex].FindControl("lblgvAsmtId");
        Response.Redirect("CreateAsmtId.aspx?ClientCode=" + ddlClient.SelectedItem.Value.ToString() + "&AsmtId=" + lblgvAsmtId.Text);
    }
    #endregion

    #region GridView Events
    /// <summary>
    /// Handles the RowDataBound event of the gvClientDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvClientDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            HiddenField hfIsBillable = (HiddenField) e.Row.FindControl("hfIsBillable");
            ImageButton ImgbtnPost = (ImageButton) e.Row.FindControl("ImgbtnPost");
            if (hfIsBillable != null && ImgbtnPost != null)
            {
                if ((hfIsBillable.Value.ToString()) == "True")
                {
                    ImgbtnPost.Visible = false;
                }
            }
            Label lblgvAsmtAddressType = (Label)e.Row.FindControl("lblgvAsmtAddressType");
            if (lblgvAsmtAddressType != null && hfIsBillable != null && (hfIsBillable.Value.ToString()) == "True")
            {
                lblgvAsmtAddressType.Text = Resources.Resource.BillingAddress;
            }
            else
            {
                lblgvAsmtAddressType.Text = Resources.Resource.AsmtAddress;
            }
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
                }
            }
        }
        
       
    }
    /// <summary>
    /// Handles the DataBound event of the gvClientDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvClientDetails_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvClientDetails.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvClientDetails.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvClientDetails.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvClientDetails.PageCount.ToString();
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvClientDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvClientDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvClientDetails.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvClientDetails.PageIndex = gvClientDetails.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvClientDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvClientDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvClientDetails.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvClientDetails.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvClientDetails.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvClientDetails.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvClientDetails.PageIndex = e.NewPageIndex;
        }
        gvClientDetails.EditIndex = -1;
        FillgvClientDetails();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvClientDetails.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvClientDetails.PageIndex = ddlPages.SelectedIndex;
        FillgvClientDetails();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvClientDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvClientDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LinkButton lblgvAsmtId = (LinkButton)gvClientDetails.Rows[e.RowIndex].FindControl("lblgvAsmtId");
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();

        ds = objSale.ClientDetailsDelete(BaseLocationAutoID, ddlClient.SelectedItem.Value.ToString(), lblgvAsmtId.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        FillgvClientDetails();
    }
    #endregion


    /// <summary>
    /// Handles the TextChanged event of the txtClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtClientCode_TextChanged(object sender, EventArgs e)
    {

        for (int i = 0; i < ddlClient.Items.Count; i++)
        {
            if (ddlClient.Items[i].Value.ToString() == txtClientCode.Text)
            {
                ddlClient.SelectedIndex = i;
                FillgvClientDetails();
            }

        }
    }

    /*Code modified by Manish  on 31-Aug-2011*/
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClient();
        FillgvClientDetails();
    }

    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaID()
    {
        ListItem li = new ListItem();

        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();
        dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {

            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();
            li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlAreaID.Items.Insert(0, li);

        }
        if (ddlAreaID.Text == "")
        {
            li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlAreaID.Items.Add(li);

        }
    }
    /*End of Code modified by Manish  on 31-Aug-2011*/
}
