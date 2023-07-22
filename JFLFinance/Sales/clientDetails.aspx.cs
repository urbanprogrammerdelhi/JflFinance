// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="clientDetails.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_clientDetails.
/// </summary>
public partial class Sales_clientDetails : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// The URL cl code
    /// </summary>
    private string urlClCode;


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
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        urlClCode = Request.QueryString["ClId"];
        
        if (!IsPostBack)
        {
           
            
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

            this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "GetParentHiddenField",
                  "window.onload=function(){" +
                  "     if(window.parent!=null){" +
                  "        window.parent.document.getElementById('ctl00_lblPageHdrTitle').value = 'Hello';" +
                  "     }" +
                  "}",
                  true);



            if (IsReadAccess == true)
            {
                FillddlAreaID();
                FillgvClientDetails();
                PageAccessPermission();
            }
            else
            { 
                Response.Redirect("../UserManagement/Home.aspx"); 
            }
        }


    }
    #endregion
    
    #region Bind GridView
    /// <summary>
    /// Fillgvs the client details.
    /// </summary>
    protected void FillgvClientDetails()
    {
        string strClientCode;
        strClientCode = Request.QueryString["ClId"];

        DataSet ds = new DataSet();
        BL.Sales objSale = new BL.Sales();
        ds = objSale.ClientDetailsGet(BaseLocationAutoID, strClientCode, ddlAreaID.SelectedItem.Value, BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString());

        gvClientDetails.DataSource = ds;
        gvClientDetails.DataBind();
        
    }
    #endregion
    
    #region Add New Button
    /// <summary>
    /// Handles the Click event of the createAsmtId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void createAsmtId_Click(object sender, EventArgs e)
    {

        Response.Redirect("createAsmtId.aspx?ClId=" + urlClCode);
    }
    #endregion

    #region back Button
    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CompanyClientList.aspx");
    }
    #endregion

    #region Edit Button
    /// <summary>
    /// Handles the Click event of the ImgbtnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnEdit_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton Imgbtn = (ImageButton)sender;
        GridViewRow gvRow = (GridViewRow)Imgbtn.NamingContainer;
        Label lblAsmtId = (Label)gvClientDetails.Rows[gvRow.RowIndex].FindControl("lblgvAsmtId");
        Response.Redirect("createAsmtId.aspx?ClId=" + urlClCode + "&AId=" + lblAsmtId.Text);


    }
    #endregion

    #region Add Attributes 
    /// <summary>
    /// Handles the RowDataBound event of the gvClientDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvClientDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

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
            gvClientDetails.Columns[12].Visible = false;

        }
        else if (!IsDeleteAccess)
        {
            for (int i = 0; i < gvClientDetails.Rows.Count; i++)
            {
                ImageButton ImgDelete = (ImageButton)gvClientDetails.Rows[i].FindControl("ImgbtnDelete");
                ImgDelete.Visible = false;
            }

        }
        else if (!IsModifyAccess)
        {
            for (int i = 0; i < gvClientDetails.Rows.Count; i++)
            {
                ImageButton ImgEdit = (ImageButton)gvClientDetails.Rows[i].FindControl("ImgbtnEdit");
                ImgEdit.Visible = false;
            }
        }

        if (!IsWriteAccess)
        {
            createAsmtId.Visible = false;
        }


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

        FillgvClientDetails();
        PageAccessPermission();
    }

    /// <summary>
    /// Fillddls the area ID.
    /// </summary>
    protected void FillddlAreaID()
    {
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();
        dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString());
        ddlAreaID.DataTextField = "AreaDesc";
        ddlAreaID.DataValueField = "AreaID";
        ddlAreaID.DataSource = dsClient;
        ddlAreaID.DataBind();

    }
    /*End of Code modified by Manish  on 31-Aug-2011*/

}
