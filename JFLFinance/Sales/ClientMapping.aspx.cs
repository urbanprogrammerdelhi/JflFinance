// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ClientMapping.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
 using System;
using System.Data;
 using System.Web.UI;
using System.Web.UI.WebControls;
 using System.Transactions;
using BL;

/// <summary>
/// Class Masters_ClientMapping.
/// </summary>
public partial class Masters_ClientMapping : BasePage //System.Web.UI.Page
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

    #region Page functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ClientMapping + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillddlLocation();
                Fill_lbAllClients();
                Fill_lbMappedClients();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            if (IsWriteAccess == false)
            {
                ImgBtnAdd.Visible = false;
                ImgBtnRemove.Visible = false;
                btnApply.Visible = false;
            }
        }
    }
    #endregion

    #region Bind Controles
    /// <summary>
    /// Fill_lbs all clients.
    /// </summary>
    protected void Fill_lbAllClients()
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSale.ClientNotMappedToLocationGet(ddlLocation.SelectedItem.Value.ToString());

        lbAllClient.DataSource = ds.Tables[0];
        lbAllClient.DataTextField = "ClientNameCode";
        lbAllClient.DataValueField = "ClientCode";
        lbAllClient.DataBind();
    }
    /// <summary>
    /// Fill_lbs the mapped clients.
    /// </summary>
    protected void Fill_lbMappedClients()
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSale.ClientsMappedToLocationGet(ddlLocation.SelectedItem.Value.ToString(), BaseUserID);
        }
        else
        {
            ds = objSale.ClientsMappedToLocationGet(ddlLocation.SelectedItem.Value.ToString());
        }

        lbMappedClient.DataSource = ds.Tables[0];
        lbMappedClient.DataTextField = "ClientCodeName";
        lbMappedClient.DataValueField = "ClientCode";
        lbMappedClient.DataBind();

        //Code added By Manish
        //Purpose: To Add details for Customer Meeting
        ListItem li = new ListItem();
        li.Text = Resources.Resource.SelectClient;
        li.Value = "-1";
             

        ddlClient.DataSource = ds.Tables[0];
        ddlClient.DataTextField = "ClientCodeName";
        ddlClient.DataValueField = "ClientCode";
       
        ddlClient.DataBind();
        ddlClient.Items.Insert(0, li);


    }
    /// <summary>
    /// Fillddls the location.
    /// </summary>
    protected void FillddlLocation()
    {
        DataSet ds = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        ds = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, BaseHrLocationCode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlLocation.DataSource = ds.Tables[0];
            ddlLocation.DataValueField = "LocationAutoId";
            ddlLocation.DataTextField = "LocationDesc";
            ddlLocation.SelectedValue = BaseLocationAutoID;
            ddlLocation.DataBind();
            ddlLocation.AutoPostBack = true;
        }

    }
    /// <summary>
    /// For fetching the Meeting details for Client
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClient.SelectedItem.Value == "-1")
        {
            btnApplyMeeting.Enabled = false;
            
        }
        else
        {
            btnApplyMeeting.Enabled = true;
            FillCustomerMeetingDetails();
        }
        
    }
    /// <summary>
    /// For fetching the Meeting details for Client
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
                FillCustomerMeetingDetails();
            }
        }
    }

    /// <summary>
    /// Fills the customer meeting details.
    /// </summary>
    protected void FillCustomerMeetingDetails()
    { 
        //Updated for DDLFrequencySch not fetching appropriate value
        DataTable dt = new DataTable();
        BL.Sales obj = new BL.Sales();
        dt = obj.GetCustomerMeetingDetail(ddlLocation.SelectedItem.Value, ddlClient.SelectedItem.Value);
     //   if (dt.Rows.Count > 0)
      //  {
        //ddlFrequencySch.Items.FindByValue(dt.Rows[0]["CUSTMEETINGUNIT"]);
        ddlFrequencySch.SelectedValue = dt.Rows[0]["CUSTMEETINGUNIT"].ToString();
        txtClientCode.Text = "";   
        //}
    }
    #endregion

    #region Controle Events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_lbAllClients();
        Fill_lbMappedClients();
    }
    /// <summary>
    /// Handles the Click event of the ImgBtnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs" /> instance containing the event data.</param>
    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < lbAllClient.Items.Count; i++)
        {
            if (lbAllClient.Items[i].Selected)
            {
                ListItem LIClient = new ListItem();
                LIClient.Text = lbAllClient.Items[i].Text;
                LIClient.Value = lbAllClient.Items[i].Value;
                lbMappedClient.Items.Add(LIClient);
            }
        }
        for (int i = lbAllClient.Items.Count - 1; i >= 0; i--)
        {
            if (lbAllClient.Items[i].Selected)
            {
                lbAllClient.Items.RemoveAt(i);

            }
        }

    }
    /// <summary>
    /// Handles the Click event of the ImgBtnRemove control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs" /> instance containing the event data.</param>
    protected void ImgBtnRemove_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < lbMappedClient.Items.Count; i++)
        {
            if (lbMappedClient.Items[i].Selected)
            {
                ListItem LIClient = new ListItem();
                LIClient.Text = lbMappedClient.Items[i].Text;
                LIClient.Value = lbMappedClient.Items[i].Value;
                lbAllClient.Items.Add(LIClient);
            }
        }
        for (int i = lbMappedClient.Items.Count - 1; i >= 0; i--)
        {
            if (lbMappedClient.Items[i].Selected)
            {
                lbMappedClient.Items.RemoveAt(i);
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnApply control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnApply_Click(object sender, EventArgs e)
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();
        int LocId = int.Parse(ddlLocation.SelectedItem.Value.ToString());

        //*******************Use Static Table to avoid loop***************************
        using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
        {
            for (int i = 0; i < lbAllClient.Items.Count; i++)
            {
                ds = objSale.ClientMappingToLocationRemove(LocId, lbAllClient.Items[i].Value);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }

            tx.Complete();
        }
        using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
        {
            for (int i = 0; i < lbMappedClient.Items.Count; i++)
            {
                ds = objSale.ClientMappingToLocationAdd(LocId, lbMappedClient.Items[i].Value, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            tx.Complete();
        }
        //***********************************************************************************
        Fill_lbAllClients();
        Fill_lbMappedClients();
    }
    /// <summary>
    /// Handles the Click event of the lbClientDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void lbClientDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/ClientDetailsList.aspx");
    }

    /// <summary>
    /// Handles the Click event of the btnApplyMeeting control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnApplyMeeting_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        BL.Sales obj = new BL.Sales();
        dt = obj.UpdateCustomerMeetingDetail(ddlLocation.SelectedItem.Value, ddlClient.SelectedItem.Value,ddlFrequencySch.SelectedItem.Value);
        lblerror.Text = MessageString_Get(int.Parse(dt.Rows[0][0].ToString()));
        FillCustomerMeetingDetails();
    }



    #endregion

}
