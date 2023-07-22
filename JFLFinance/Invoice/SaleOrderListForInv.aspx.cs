using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Sales_SaleOrderListForInv : BasePage //System.Web.UI.Page
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

    #region Page Functions
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.SaleOrder.ToString(); }

            //Code added by  on 16 Jan 2012
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
                btnAddNew.Visible = false; // no need for this button
                FillddlClientCode();
                if (Request.QueryString["ClientCode"] != null && Request.QueryString["ClientCode"].ToString().Length != 0)
                {
                    ddlClientCode.SelectedValue = Request.QueryString["ClientCode"].ToString();
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Control Binding
    protected void FillddlClientCode()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        if (BaseIsAdmin.ToString().Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objsales.ClientGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objsales.ClientsLocationWiseGet(BaseLocationAutoID);
        }
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientNameCode";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();
                if (Request.QueryString["ClientCode"] != null)
                {
                    ddlClientCode.SelectedIndex = ddlClientCode.Items.IndexOf(ddlClientCode.Items.FindByValue(Request.QueryString["ClientCode"].ToString()));
                }
                FillgvSaleOrder();
            }
        }
    }
    protected void FillgvSaleOrder()
    {
        BL.Invoice objInvoice = new BL.Invoice();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objInvoice.OrderInformationGet(BaseLocationAutoID.ToString(), ddlClientCode.SelectedItem.Value.ToString());
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
    #endregion

    #region GridView Events
    protected void gvSaleOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void gvSaleOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowIndex == 1)
        //{
        //    foreach (TableCell cell in e.Row.Cells)
        //        cell.Attributes.Add("Style", "border-top: blue 4px solid");
        //}


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }
    #endregion

    #region other controles events
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvSaleOrder();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Sales/SaleOrderMaster.aspx?SoNo=" + "0" + "&ClientCode=" + ddlClientCode.SelectedItem.Value.ToString());
    }
    protected void ImgbtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ImgbtnSelect = (ImageButton)sender;
        GridViewRow gvRow = (GridViewRow)ImgbtnSelect.NamingContainer;
        Label lblgvSaleOrder = (Label)gvSaleOrder.Rows[gvRow.RowIndex].FindControl("lblgvSaleOrder");
        Label lblgvAsmtBillingID = (Label)gvSaleOrder.Rows[gvRow.RowIndex].FindControl("lblgvAsmtBillingID");
        if (BaseCompanyCode == "GRECMSS" || BaseCompanyCode == "GRECAVT")
        {
            Response.Redirect("../Invoice/InvoiceMaster.aspx?SoNo=" + lblgvSaleOrder.Text + "&ClientCode=" + ddlClientCode.SelectedItem.Value.ToString() + "&BillingID=" + lblgvAsmtBillingID.Text);
        }
        else
        {
            Response.Redirect("../Invoice/InvoiceMasterBarbados.aspx?SoNo=" + lblgvSaleOrder.Text + "&ClientCode=" + ddlClientCode.SelectedItem.Value.ToString() + "&BillingID=" + lblgvAsmtBillingID.Text);
        }
    }
    #endregion

   
}
