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

public partial class AssetManagement_GraphicalTaskMonthly : BasePage
{
    public string Date1, Date2, Date3, Date4, Date5, Date6, Date7, Date8, Date9, Date10, Date11, Date12, Date13, Date14, Date15, Date16, Date17, Date18, Date19, Date20, Date21, Date22, Date23, Date24, Date25, Date26, Date27, Date28, Date29, Date30;
    public string Pend1, Pend2, Pend3, Pend4, Pend5, Pend6, Pend7, Pend8, Pend9, Pend10, Pend11, Pend12, Pend13, Pend14, Pend15, Pend16, Pend17, Pend18, Pend19, Pend20, Pend21, Pend22, Pend23, Pend24, Pend25, Pend26, Pend27, Pend28, Pend29, Pend30;
    public string Comp1, Comp2, Comp3, Comp4, Comp5, Comp6, Comp7, Comp8, Comp9, Comp10, Comp11, Comp12, Comp13, Comp14, Comp15, Comp16, Comp17, Comp18, Comp19, Comp20, Comp21, Comp22, Comp23, Comp24, Comp25, Comp26, Comp27, Comp28, Comp29, Comp30;
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
                txtDate.Text = DateTime.Today.AddDays(-29).ToString("dd-MMM-yyyy");
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
                Date1 = dsTaskMaster.Tables[0].Rows[0]["DutyDate"].ToString();
                Date2 = dsTaskMaster.Tables[0].Rows[1]["DutyDate"].ToString();
                Date3 = dsTaskMaster.Tables[0].Rows[2]["DutyDate"].ToString();
                Date4 = dsTaskMaster.Tables[0].Rows[3]["DutyDate"].ToString();
                Date5 = dsTaskMaster.Tables[0].Rows[4]["DutyDate"].ToString();
                Date6 = dsTaskMaster.Tables[0].Rows[5]["DutyDate"].ToString();
                Date7 = dsTaskMaster.Tables[0].Rows[6]["DutyDate"].ToString();
                Date8 = dsTaskMaster.Tables[0].Rows[7]["DutyDate"].ToString();
                Date9 = dsTaskMaster.Tables[0].Rows[8]["DutyDate"].ToString();
                Date10 = dsTaskMaster.Tables[0].Rows[9]["DutyDate"].ToString();
                Date11 = dsTaskMaster.Tables[0].Rows[10]["DutyDate"].ToString();
                Date12 = dsTaskMaster.Tables[0].Rows[11]["DutyDate"].ToString();
                Date13 = dsTaskMaster.Tables[0].Rows[12]["DutyDate"].ToString();
                Date14 = dsTaskMaster.Tables[0].Rows[13]["DutyDate"].ToString();
                Date15 = dsTaskMaster.Tables[0].Rows[14]["DutyDate"].ToString();
                Date16 = dsTaskMaster.Tables[0].Rows[15]["DutyDate"].ToString();
                Date17 = dsTaskMaster.Tables[0].Rows[16]["DutyDate"].ToString();
                Date18 = dsTaskMaster.Tables[0].Rows[17]["DutyDate"].ToString();
                Date19 = dsTaskMaster.Tables[0].Rows[18]["DutyDate"].ToString();
                Date20 = dsTaskMaster.Tables[0].Rows[19]["DutyDate"].ToString();
                Date21 = dsTaskMaster.Tables[0].Rows[20]["DutyDate"].ToString();
                Date22 = dsTaskMaster.Tables[0].Rows[21]["DutyDate"].ToString();
                Date23 = dsTaskMaster.Tables[0].Rows[22]["DutyDate"].ToString();
                Date24 = dsTaskMaster.Tables[0].Rows[23]["DutyDate"].ToString();
                Date25 = dsTaskMaster.Tables[0].Rows[24]["DutyDate"].ToString();
                Date26 = dsTaskMaster.Tables[0].Rows[25]["DutyDate"].ToString();
                Date27 = dsTaskMaster.Tables[0].Rows[26]["DutyDate"].ToString();
                Date28 = dsTaskMaster.Tables[0].Rows[27]["DutyDate"].ToString();
                Date29 = dsTaskMaster.Tables[0].Rows[28]["DutyDate"].ToString();
                Date30 = dsTaskMaster.Tables[0].Rows[29]["DutyDate"].ToString();

                Pend1 = dsTaskMaster.Tables[0].Rows[0]["Pending"].ToString();
                Pend2 = dsTaskMaster.Tables[0].Rows[1]["Pending"].ToString();
                Pend3 = dsTaskMaster.Tables[0].Rows[2]["Pending"].ToString();
                Pend4 = dsTaskMaster.Tables[0].Rows[3]["Pending"].ToString();
                Pend5 = dsTaskMaster.Tables[0].Rows[4]["Pending"].ToString();
                Pend6 = dsTaskMaster.Tables[0].Rows[5]["Pending"].ToString();
                Pend7 = dsTaskMaster.Tables[0].Rows[6]["Pending"].ToString();
                Pend8 = dsTaskMaster.Tables[0].Rows[7]["Pending"].ToString();
                Pend9 = dsTaskMaster.Tables[0].Rows[8]["Pending"].ToString();
                Pend10 = dsTaskMaster.Tables[0].Rows[9]["Pending"].ToString();
                Pend11 = dsTaskMaster.Tables[0].Rows[10]["Pending"].ToString();
                Pend12 = dsTaskMaster.Tables[0].Rows[11]["Pending"].ToString();
                Pend13 = dsTaskMaster.Tables[0].Rows[12]["Pending"].ToString();
                Pend14 = dsTaskMaster.Tables[0].Rows[13]["Pending"].ToString();
                Pend15 = dsTaskMaster.Tables[0].Rows[14]["Pending"].ToString();
                Pend16 = dsTaskMaster.Tables[0].Rows[15]["Pending"].ToString();
                Pend17 = dsTaskMaster.Tables[0].Rows[16]["Pending"].ToString();
                Pend18 = dsTaskMaster.Tables[0].Rows[17]["Pending"].ToString();
                Pend19 = dsTaskMaster.Tables[0].Rows[18]["Pending"].ToString();
                Pend20 = dsTaskMaster.Tables[0].Rows[19]["Pending"].ToString();
                Pend21 = dsTaskMaster.Tables[0].Rows[20]["Pending"].ToString();
                Pend22 = dsTaskMaster.Tables[0].Rows[21]["Pending"].ToString();
                Pend23 = dsTaskMaster.Tables[0].Rows[22]["Pending"].ToString();
                Pend24 = dsTaskMaster.Tables[0].Rows[23]["Pending"].ToString();
                Pend25 = dsTaskMaster.Tables[0].Rows[24]["Pending"].ToString();
                Pend26 = dsTaskMaster.Tables[0].Rows[25]["Pending"].ToString();
                Pend27 = dsTaskMaster.Tables[0].Rows[26]["Pending"].ToString();
                Pend28 = dsTaskMaster.Tables[0].Rows[27]["Pending"].ToString();
                Pend29 = dsTaskMaster.Tables[0].Rows[28]["Pending"].ToString();
                Pend30 = dsTaskMaster.Tables[0].Rows[29]["Pending"].ToString();

                Comp1 = dsTaskMaster.Tables[0].Rows[0]["Completed"].ToString();
                Comp2 = dsTaskMaster.Tables[0].Rows[1]["Completed"].ToString();
                Comp3 = dsTaskMaster.Tables[0].Rows[2]["Completed"].ToString();
                Comp4 = dsTaskMaster.Tables[0].Rows[3]["Completed"].ToString();
                Comp5 = dsTaskMaster.Tables[0].Rows[4]["Completed"].ToString();
                Comp6 = dsTaskMaster.Tables[0].Rows[5]["Completed"].ToString();
                Comp7 = dsTaskMaster.Tables[0].Rows[6]["Completed"].ToString();
                Comp8 = dsTaskMaster.Tables[0].Rows[7]["Completed"].ToString();
                Comp9 = dsTaskMaster.Tables[0].Rows[8]["Completed"].ToString();
                Comp10 = dsTaskMaster.Tables[0].Rows[9]["Completed"].ToString();
                Comp11 = dsTaskMaster.Tables[0].Rows[10]["Completed"].ToString();
                Comp12 = dsTaskMaster.Tables[0].Rows[11]["Completed"].ToString();
                Comp13 = dsTaskMaster.Tables[0].Rows[12]["Completed"].ToString();
                Comp14 = dsTaskMaster.Tables[0].Rows[13]["Completed"].ToString();
                Comp15 = dsTaskMaster.Tables[0].Rows[14]["Completed"].ToString();
                Comp16 = dsTaskMaster.Tables[0].Rows[15]["Completed"].ToString();
                Comp17 = dsTaskMaster.Tables[0].Rows[16]["Completed"].ToString();
                Comp18 = dsTaskMaster.Tables[0].Rows[17]["Completed"].ToString();
                Comp19 = dsTaskMaster.Tables[0].Rows[18]["Completed"].ToString();
                Comp20 = dsTaskMaster.Tables[0].Rows[19]["Completed"].ToString();
                Comp21 = dsTaskMaster.Tables[0].Rows[20]["Completed"].ToString();
                Comp22 = dsTaskMaster.Tables[0].Rows[21]["Completed"].ToString();
                Comp23 = dsTaskMaster.Tables[0].Rows[22]["Completed"].ToString();
                Comp24 = dsTaskMaster.Tables[0].Rows[23]["Completed"].ToString();
                Comp25 = dsTaskMaster.Tables[0].Rows[24]["Completed"].ToString();
                Comp26 = dsTaskMaster.Tables[0].Rows[25]["Completed"].ToString();
                Comp27 = dsTaskMaster.Tables[0].Rows[26]["Completed"].ToString();
                Comp28 = dsTaskMaster.Tables[0].Rows[27]["Completed"].ToString();
                Comp29 = dsTaskMaster.Tables[0].Rows[28]["Completed"].ToString();
                Comp30 = dsTaskMaster.Tables[0].Rows[29]["Completed"].ToString();
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
        d1 = d1.AddDays(+30);
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