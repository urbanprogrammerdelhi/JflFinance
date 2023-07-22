// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SaleOrderList.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_SaleOrderList.
/// </summary>
public partial class Sales_SaleOrderList : BasePage //System.Web.UI.Page
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
            //{ lblPageHdrTitle.Text = Resources.Resource.SaleOrder.ToString(); }

            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.SaleOrder + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                if (IsWriteAccess == false)
                {
                    btnAddNew.Visible = false;
                }
                FillddlAreaID();
                FillddlClientCode();
                if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length != 0)
                {
                    ddlClientCode.SelectedValue = Request.QueryString["ClientCode"].ToString();
                }
                ImgbtnSearchSONO.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=1000px,Height=650,help=no')");
                FillAsmtId();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(ddlClientCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Controle Binding
    /// <summary>
    /// Fillddls the client code.
    /// </summary>
    protected void FillddlClientCode()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objsales.ClientGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            /*Code commented and Modified by Manish  on 16-Sep-2011*/
           // ds = objsales.blClient_Get(BaseLocationAutoID);
            ds = objsales.ClientsMappedToLocationGet(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString(), "".ToString(), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        }
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                //ddlClientCode.DataTextField = "ClientNameCode";
                ddlClientCode.DataTextField = "ClientCodeName";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();
                if (Request.QueryString["ClientCode"] != null)
                {
                    ddlClientCode.SelectedIndex = ddlClientCode.Items.IndexOf(ddlClientCode.Items.FindByValue(Request.QueryString["ClientCode"].ToString()));
                }
                FillgvSaleOrder();
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlClientCode.Items.Add(li);
            }
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlClientCode.Items.Add(li);
        }
            
    }
    /// <summary>
    /// Fillgvs the sale order.
    /// </summary>
    protected void FillgvSaleOrder()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.SaleOrderInfoGet(BaseLocationAutoID.ToString(), ddlClientCode.SelectedValue.ToString(), ddlAsmtId.SelectedValue.ToString(), strStatusDelete);
        //ds = objSales.blMstSaleOrderinfo_Get(BaseLocationAutoID.ToString(), ddlClientCode.SelectedItem.Value.ToString());
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvSaleOrder.DataKeyNames = new string[] { "SoNo", "SoAmendNo" };
        gvSaleOrder.DataSource = dt;
        gvSaleOrder.DataBind();
        if (dtflag == 0)//to fix empety gridview
        {
            gvSaleOrder.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Fills the asmt identifier.
    /// </summary>
    private void FillAsmtId()
    {
        //panelSOdetails.Visible = true;
        //Panel1.Visible = true;
        // lblerrSODetails.Visible = false;
        BL.Sales objSales = new BL.Sales();
        //if (BaseUserIsAreaIncharge == "1") 
        //{
            ddlAsmtId.DataSource = objSales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), BaseUserEmployeeNumber,"");
        //}
        //else
        //{
        //    ddlAsmtId.DataSource = objSales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString());
        //}
        ddlAsmtId.DataTextField = "AsmtIDAddress";
        ddlAsmtId.DataValueField = "AsmtID";
        ddlAsmtId.DataBind();
        ListItem li1 = new ListItem();
        li1.Text = Resources.Resource.All;
        li1.Value = "ALL";
        ddlAsmtId.Items.Insert(0, li1);
        if (ddlAsmtId.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlAsmtId.Items.Add(li);

        }
        FillgvSaleOrder();


    }


    #endregion

    #region GridView Events
    /// <summary>
    /// Handles the RowCommand event of the gvSaleOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvSaleOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvSaleOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSaleOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsModifyAccess == false)
        {
            gvSaleOrder.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvSaleOrder.PageIndex * gvSaleOrder.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }
    #endregion

    #region other controles events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtId();
        FillgvSaleOrder();
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager1.SetFocus(ddlClientCode);
    }
    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/SaleOrderMaster.aspx?SoNo=" + "0" + "&ClientCode=" + ddlClientCode.SelectedItem.Value.ToString());
    }
    /// <summary>
    /// Handles the Click event of the lblgvSaleOrder control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblgvSaleOrder_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblgvSaleOrder = (LinkButton)gvSaleOrder.Rows[row.RowIndex].FindControl("lblgvSaleOrder");
        Response.Redirect("../Sales/SaleOrderMaster.aspx?SoNo=" + lblgvSaleOrder.Text + "&ClientCode=" + ddlClientCode.SelectedItem.Value.ToString());
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvSaleOrder();
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

        FillddlClientCode();
    }

    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaID()
    {
        ListItem li = new ListItem();

        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();
        dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));

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
