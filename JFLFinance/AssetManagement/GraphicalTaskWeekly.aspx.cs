using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.Drawing;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class AssetManagement_GraphicalTaskWeekly : BasePage
{
    public string wDate1, wDate2, wDate3, wDate4, wDate5, wDate6, wDate7;
    public string wPend1, wPend2, wPend3, wPend4, wPend5, wPend6, wPend7;
    public string wComp1, wComp2, wComp3, wComp4, wComp5, wComp6, wComp7;
    public string date, status, PostAutoId, tasks;
    public int flag = 0;
    #region Properties
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
    protected bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                var bp = new BasePage();
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                txtDate.Text = DateTime.Today.AddDays(-6).ToString("dd-MMM-yyyy");
                txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                FillddlClientCode();
                FillddlSiteId(ddlClientCode.SelectedItem.Value);
                FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
            }
        }
        txtDate.Attributes.Add("readonly", "readonly");
        txtToDate.Attributes.Add("readonly", "readonly");
        FillgvTaskMaster();
    }
    private void FillddlClientCode()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlClientCode.DataSource = objAssetManagement.GetClientCode(BaseLocationAutoID);
        ddlClientCode.DataTextField = "ClientCodenName";
        ddlClientCode.DataValueField = "ClientCode";
        ddlClientCode.DataBind();
        // ddlClientCode.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlClientCode.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlClientCode.Items.Add(li);
        }
    }
    private void FillddlSiteId(string ClientCode)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlSiteId.DataSource = objAssetManagement.GetAsmtId(ClientCode, BaseLocationAutoID);
        ddlSiteId.DataTextField = "SiteCodenName";
        ddlSiteId.DataValueField = "AsmtId";
        ddlSiteId.DataBind();
        // ddlSiteId.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlSiteId.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlSiteId.Items.Add(li);
        }
    }
    private void FillddlPostCode(string ClientCode, string AsmtId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlPostCode.DataSource = objAssetManagement.GetPostCode(ClientCode, AsmtId, BaseLocationAutoID);
        ddlPostCode.DataTextField = "PostCodenName";
        ddlPostCode.DataValueField = "PostAutoId";
        ddlPostCode.DataBind();
        ddlPostCode.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlPostCode.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlPostCode.Items.Add(li);
        }
    }
    private void FillgvTaskMaster()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsTaskMaster = new DataSet();
            var dtTaskMaster = new DataTable();
            var dtTaskMaster1 = new DataTable();
            dsTaskMaster = objAssetMgmt.GetGraphTasklist(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value, ddlPostCode.SelectedItem.Value, BaseLocationAutoID, txtDate.Text, txtToDate.Text, ddlStatus.SelectedItem.Value);
            dtTaskMaster1 = dsTaskMaster.Tables[1];
            dtTaskMaster = dsTaskMaster.Tables[0];
            if (dtTaskMaster1.Rows.Count > 0)
            {
                lblNodata.Visible = false;
                chart.Visible = true;
                wDate1 = dsTaskMaster.Tables[0].Rows[0]["DutyDate"].ToString();
                wDate2 = dsTaskMaster.Tables[0].Rows[1]["DutyDate"].ToString();
                wDate3 = dsTaskMaster.Tables[0].Rows[2]["DutyDate"].ToString();
                wDate4 = dsTaskMaster.Tables[0].Rows[3]["DutyDate"].ToString();
                wDate5 = dsTaskMaster.Tables[0].Rows[4]["DutyDate"].ToString();
                wDate6 = dsTaskMaster.Tables[0].Rows[5]["DutyDate"].ToString();
                wDate7 = dsTaskMaster.Tables[0].Rows[6]["DutyDate"].ToString();

                wPend1 = dsTaskMaster.Tables[0].Rows[0]["Pending"].ToString();
                wPend2 = dsTaskMaster.Tables[0].Rows[1]["Pending"].ToString();
                wPend3 = dsTaskMaster.Tables[0].Rows[2]["Pending"].ToString();
                wPend4 = dsTaskMaster.Tables[0].Rows[3]["Pending"].ToString();
                wPend5 = dsTaskMaster.Tables[0].Rows[4]["Pending"].ToString();
                wPend6 = dsTaskMaster.Tables[0].Rows[5]["Pending"].ToString();
                wPend7 = dsTaskMaster.Tables[0].Rows[6]["Pending"].ToString();

                wComp1 = dsTaskMaster.Tables[0].Rows[0]["Completed"].ToString();
                wComp2 = dsTaskMaster.Tables[0].Rows[1]["Completed"].ToString();
                wComp3 = dsTaskMaster.Tables[0].Rows[2]["Completed"].ToString();
                wComp4 = dsTaskMaster.Tables[0].Rows[3]["Completed"].ToString();
                wComp5 = dsTaskMaster.Tables[0].Rows[4]["Completed"].ToString();
                wComp6 = dsTaskMaster.Tables[0].Rows[5]["Completed"].ToString();
                wComp7 = dsTaskMaster.Tables[0].Rows[6]["Completed"].ToString();
            }
            else
            {
                chart.Visible = false;
                lblNodata.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlSiteId(ddlClientCode.SelectedItem.Value);
        FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
        FillgvTaskMaster();
    }
    protected void ddlSiteId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
        FillgvTaskMaster();
    }
    protected void ddlPostCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvTaskMaster();
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        DateTime d1 = Convert.ToDateTime(txtDate.Text);
        d1 = d1.AddDays(+6);
        txtToDate.Text = d1.ToString("dd-MMM-yyyy");
        FillgvTaskMaster();
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        //DateTime d1 = Convert.ToDateTime(txtToDate.Text);
        //d1 = d1.AddDays(-6);
        //txtDate.Text = d1.ToString("dd-MMM-yyyy");
        //FillgvTaskMaster();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvTaskMaster();
    }
    protected void btnGraph_Click(object sender, EventArgs e)
    {
        FillPostData();
    }
    public void FillPostData()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        string TaskStatus = hdnTaskDateStatus.Value;
        try
        {
            String[] substrings = TaskStatus.Split(',');
            date = substrings[0];
            status = substrings[1].Replace(" ", String.Empty);
            tasks = substrings[2];
            var objAssetMgmt = new BL.AssetManagement();
            var dsTaskMaster = new DataSet();
            var dtDeatils = new DataTable();
            var dtCount = new DataTable();
            dsTaskMaster = objAssetMgmt.GetGraphTasklistDetail(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value, ddlPostCode.SelectedItem.Value, BaseLocationAutoID, date, status);
            dtDeatils = dsTaskMaster.Tables[0];
            dtCount = dsTaskMaster.Tables[1];
            if (dtCount.Rows.Count > 0)
            {
                gvdata.DataSource = dtCount;
                gvdata.DataBind();
                data.DataSource = dtDeatils;
                data.DataBind();
                lblPopHeader.Text = "Details of " + status + " Task at " + date;
                lblTpost.Text = tasks;
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void Filldata()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        try
        {
            string TaskStatus = hdnTaskDateStatus.Value;
            String[] substrings = TaskStatus.Split(',');
            date = substrings[0];
            status = substrings[1].Replace(" ", String.Empty);
            tasks = substrings[2];
            var objAssetMgmt = new BL.AssetManagement();
            var dsTaskMaster = new DataSet();
            var dtDeatils = new DataTable();
            var dtCount = new DataTable();
            dsTaskMaster = objAssetMgmt.GetGraphTasklistDetail(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value, PostAutoId, BaseLocationAutoID, date, status);
            dtDeatils = dsTaskMaster.Tables[0];
            dtCount = dsTaskMaster.Tables[1];
            if (dtCount.Rows.Count > 0)
            {
                flag = 1;
                data.DataSource = dtDeatils;
                data.DataBind();
                lblPopHeader.Text = "Details of " + status + " Task at " + date;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvdata.PageIndex * gvdata.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
    }
    protected void data_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerial");
        if (lblSerialNo != null)
        {
            int serialNo = data.PageIndex * data.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        data.Columns[6].ItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FF99");
        data.Columns[9].ItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCCE5");
        if (flag == 1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                data.Columns[4].ItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#99FFFF");
            }
        }
        else
        {
            data.Columns[4].ItemStyle.BackColor = System.Drawing.Color.White;
        }
    }
    protected void data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        data.PageIndex = e.NewPageIndex;
        data.EditIndex = -1;
        Filldata();
    }
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
        gvdata.EditIndex = -1;
        FillPostData();
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfPostId = (HiddenField)gvdata.Rows[row.RowIndex].FindControl("hfPostId");
        PostAutoId = hfPostId.Value;
        Filldata();
    }
}