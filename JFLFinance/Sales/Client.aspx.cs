// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="Client.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Client.
/// </summary>
public partial class Masters_Client : BasePage //System.Web.UI.Page
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
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    #region Page function
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
            javaScript.Append("PageTitle('" + Resources.Resource.Client + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvClient();
                PageAccessPermission();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
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
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            dsClient = objSale.ClientGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            dsClient = objSale.ClientsLocationWiseGet(BaseLocationAutoID);
        }
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
    /// Handles the Click event of the ImgbtnHyperLink control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnHyperLink_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton Imgbtn = (ImageButton)sender;
        GridViewRow gvRow = (GridViewRow)Imgbtn.NamingContainer;
        Label lblgvClientCode = (Label)gvClient.Rows[gvRow.RowIndex].FindControl("lblgvClientCode");
        Response.Redirect("clientDetails.aspx?ClId=" + lblgvClientCode.Text);

    }

    /// <summary>
    /// Handles the Click event of the AddNewClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void AddNewClient_Click(object sender, EventArgs e)
    {
        Response.Redirect("addClient.aspx");
    }
    #endregion

    #region Edit button
    /// <summary>
    /// Handles the Click event of the ImgbtnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        //ImageButton Imgbtn = (ImageButton)sender;
        //GridViewRow gvRow = (GridViewRow)Imgbtn.NamingContainer;
        //Label lblClCode = (Label)gvClient.Rows[gvRow.RowIndex].FindControl("lblgvClientCode");
        //Response.Redirect("addClient.aspx?ClId=" + lblClCode.Text);
        
    }
    #endregion

    #region Delete Button
    /// <summary>
    /// Handles the Click event of the ImgbtnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        //ImageButton Imgbtn = (ImageButton)sender;
        //GridViewRow gvRow = (GridViewRow)Imgbtn.NamingContainer;
        //Label lblClCode = (Label)gvClient.Rows[gvRow.RowIndex].FindControl("lblgvClientCode");

        //DataSet ds = new DataSet();
        
        //BL.Sales objSale = new BL.Sales();
        //ds = objSale.blClient_Delete(lblClCode.Text.ToString());

        //FillgvClient();

    }
    #endregion

    #region Access Permission
    /// <summary>
    /// Pages the access permission.
    /// </summary>
    private void PageAccessPermission()
    {
        if (!IsDeleteAccess && !IsModifyAccess)
        {
            gvClient.Columns[12].Visible = false; 
            
        }
        if (!IsDeleteAccess)
        {            
            for (int i = 0; i < gvClient.Rows.Count; i++)
            {
                ImageButton ImgDelete = (ImageButton)gvClient.Rows[i].FindControl("ImgbtnDelete");
                ImgDelete.Visible = false;
            }

         }
        if (!IsModifyAccess)
        {
            for (int i = 0; i < gvClient.Rows.Count; i++)
            {
                ImageButton ImgEdit = (ImageButton)gvClient.Rows[i].FindControl("ImgbtnEdit");
                ImgEdit.Visible = false;
            }
        }

        if (!IsWriteAccess)
        {
            AddNewClient.Visible = false;
        }
                 
        
    }
    #endregion

    #region Attributes
    /// <summary>
    /// Handles the RowDataBound event of the gvClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvClient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
    }
    #endregion 

    
}
