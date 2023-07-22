using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Generic;
/// <summary>
/// Class Sales_SOLineSkillSet.
/// </summary>
public partial class Sales_WorkOrderList : BasePage
{
    static int dtflag;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                txtFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                txtToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                FillgvWorkOrderMaster();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    protected void gvWorkOrderMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWorkOrderMaster.PageIndex = e.NewPageIndex;
        gvWorkOrderMaster.EditIndex = -1;
        FillgvWorkOrderMaster();
    }
    private void FillgvWorkOrderMaster()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        if (DateTime.Parse(txtToDate.Text) < DateTime.Parse(txtFromDate.Text))
        {
            lblError.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
        }
        else
        {
            lblError.Text = "";
            ds = objSales.GetWorkOrderDetailBySearch(ddlstatus.SelectedItem.Value, txtFromDate.Text, txtToDate.Text, txtWorkOrderNo.Text, txtClientUserId.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvWorkOrderMaster.Visible = true;
                gvWorkOrderMaster.DataSource = ds;
                gvWorkOrderMaster.DataBind();
            }
            else
            {
                lblError.Text = Resources.Resource.NoRecordFound;
                gvWorkOrderMaster.Visible = false;
                // gvWorkOrderMaster.Rows[0].Visible = false;
            }
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkOrderMaster.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillgvWorkOrderMaster();
    }

    #region Ajax AutoCompleteExtender
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchPlumbingWorkOrder(string prefixText)
    {
        Sales_WorkOrderList WoListobj = new Sales_WorkOrderList();
        List<string> WorkOrderNoList = WoListobj.SearchPlumbingWorkOrderGet(prefixText);
        return WorkOrderNoList;
    }

    public List<string> SearchPlumbingWorkOrderGet(string prefixText)
    {
        PlumbingEngineerApp PeAppobj = new PlumbingEngineerApp();
        List<string> WorkOrderNoList = PeAppobj.SearchPlumbingWorkOrder(BaseCountryCode, prefixText);
        return WorkOrderNoList;
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchClientUserId(string prefixText)
    {
        Sales_WorkOrderList WoListobj = new Sales_WorkOrderList();
        List<string> ClientUserList = WoListobj.SearchClientUserIdGet(prefixText);
        return ClientUserList;
    }

    public List<string> SearchClientUserIdGet(string prefixText)
    {
        PlumbingEngineerApp PeAppobj = new PlumbingEngineerApp();
        List<string> ClientUserList = PeAppobj.SearchClientUserId(BaseCountryCode, prefixText);
        return ClientUserList;
    }
    #endregion Ajax AutoCompleteExtender
    protected void gvWorkOrderMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            //var imgbtnEdit = (ImageButton)e.Row.FindControl("imgbtnEdit");
            //var imgBtnDeployment = (ImageButton)e.Row.FindControl("ImgBtnDeployment");
            //var hfWorkOrderAutoId = (HiddenField)e.Row.FindControl("hfWorkOrderAutoId");
            //var lblOrderNo = (Label)e.Row.FindControl("lblOrderNo");
            //var lblOrderStatus = (Label)e.Row.FindControl("lblOrderStatus");
        }
    }
    protected void ImgBtnDeployment_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton objLinkButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        var hfWorkOrderAutoId = (HiddenField)gvWorkOrderMaster.Rows[row.RowIndex].FindControl("hfWorkOrderAutoId");
        var lblOrderNo = (Label)gvWorkOrderMaster.Rows[row.RowIndex].FindControl("lblOrderNo");
        var lblOrderStatus = (Label)gvWorkOrderMaster.Rows[row.RowIndex].FindControl("lblOrderStatus");

        if (hfWorkOrderAutoId != null && lblOrderNo != null && lblOrderStatus != null)
        {
            Response.Redirect("../Transactions/PlumbingWorkOrderSch.aspx?WorkOrderAutoId=" + hfWorkOrderAutoId.Value + "&WorkOrderNo=" + lblOrderNo.Text + "&OrderStatus=" + lblOrderStatus.Text);
        }
    }
    protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton objLinkButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        var hfWorkOrderAutoId = (HiddenField)gvWorkOrderMaster.Rows[row.RowIndex].FindControl("hfWorkOrderAutoId");
        var lblOrderNo = (Label)gvWorkOrderMaster.Rows[row.RowIndex].FindControl("lblOrderNo");
        var lblOrderStatus = (Label)gvWorkOrderMaster.Rows[row.RowIndex].FindControl("lblOrderStatus");

        if (hfWorkOrderAutoId != null && lblOrderNo != null && lblOrderStatus != null)
        {
            Response.Redirect("../Sales/WorkOrderDetail.aspx?WorkOrderAutoId=" + hfWorkOrderAutoId.Value + "&WorkOrderNo=" + lblOrderNo.Text + "&OrderStatus=" + lblOrderStatus.Text);
        }
    }
}