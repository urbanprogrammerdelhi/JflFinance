using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjaxControlToolkit;
using QRCoder;
using System.Drawing;
using System.Configuration;
public partial class AssetManagement_AssetTransfer : BasePage
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
                FillgvAssetMaster();
                FillddlClient();
                FillAsmtId();
                FillddlPost();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    protected void gvAssetMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetMaster.PageIndex = e.NewPageIndex;
        gvAssetMaster.EditIndex = -1;
        FillgvAssetMaster();
    }
 
    private void FillgvAssetMaster()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetMaster = new DataSet();
            var dtAssetMaster = new DataTable();
            dtflag = 1;
            if (BaseIsAdmin == "R")
            {
                dsAssetMaster = objAssetMgmt.AssetMasterDetailGet(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID), BaseUserID);
            }
            else
            {
                dsAssetMaster = objAssetMgmt.AssetMasterDetailGet(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID), "0");
            }
         //   dsAssetMaster = objAssetMgmt.AssetMasterDetailGet(BaseCompanyCode,Convert.ToInt32(BaseLocationAutoID));
            dtAssetMaster = dsAssetMaster.Tables[0];
            if (dtAssetMaster.Rows.Count == 0)
            {
                dtflag = 0;
                dtAssetMaster.Rows.Add(dtAssetMaster.NewRow());
            }
            gvAssetMaster.DataSource = dtAssetMaster;
            gvAssetMaster.DataBind();

            if (dtflag == 0)
            {
                gvAssetMaster.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
        }
        catch (Exception ex)
        {
        }
    }
  
    protected void btnUpdateMapping_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            string code = "";
            ds = objAssetMgmt.AssetTransferUpdate(Convert.ToInt32(hfId.Value), Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, Convert.ToInt32(ddlPost.SelectedItem.Value), "", "", BaseUserID, code.ToString());
            DisplayMessage(lblMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
            btnupdate.Visible = false;
            btnUpdateMapping.Visible = false;
           
        }
        catch (Exception ex)
        { }
    }
    private void FillAssetClientMapping(string AssetId)
    {
        var objAssetMgmt = new BL.AssetManagement();
        var ds = objAssetMgmt.AssetClientMappingGetRecords(AssetId);
        try
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlClientCode.SelectedValue = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                    FillAsmtId();
                    ddlAsmtId.SelectedValue = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                    FillddlPost();
                    ddlPost.SelectedValue = ds.Tables[0].Rows[0]["PostAutoId"].ToString();
                    lblClientName1.Text = ddlClientCode.SelectedItem.Text;
                    lblAsmt1.Text = ddlAsmtId.SelectedItem.Text;
                    lblSubSite1.Text = ddlPost.SelectedItem.Text;
                    btnupdate.Visible = true;
                    if (ds.Tables[0].Rows[0]["ClientCode"].ToString() == "")
                    { 
                        lblClientName1.Text = "Please Mapped the Asset with Customer";
                        lblAsmt1.Text = "Please Mapped the Asset with Site";
                        lblSubSite1.Text = "Please Mapped the Asset with Sub Site";
                        btnupdate.Visible = false;
                    }
                    else
                    {
                        btnupdate.Visible = true;
                    }
                }
                else
                {
                    lblClientName1.Text = "Please Mapped the Asset with Customer";
                    lblAsmt1.Text = "Please Mapped the Asset with Site";
                    lblSubSite1.Text = "Please Mapped the Asset with Sub Site";
                    btnupdate.Visible = false;
                }
            }
            else
            {
                lblClientName1.Text = "Please Mapped the Asset with Customer";
                lblAsmt1.Text = "Please Mapped the Asset with Site";
                lblSubSite1.Text = "Please Mapped the Asset with Sub Site";
                btnupdate.Visible = false;
           }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtId();
    }
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPost();
    }
    protected void FillddlClient()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objsales.ClientGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objsales.ClientsMappedToLocationGet(BaseLocationAutoID, "ALL", "".ToString(), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        }
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientCodeName";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();
                if (Request.QueryString["ClientCode"] != null)
                {
                    ddlClientCode.SelectedIndex = ddlClientCode.Items.IndexOf(ddlClientCode.Items.FindByValue(Request.QueryString["ClientCode"].ToString()));
                }
                FillAsmtId();
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
    protected void FillAsmtId()
    {
        BL.Sales objSales = new BL.Sales();
        ddlAsmtId.DataSource = objSales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), BaseUserEmployeeNumber, "");
        ddlAsmtId.DataTextField = "AsmtIDAddress";
        ddlAsmtId.DataValueField = "AsmtID";
        ddlAsmtId.DataBind();
        if (ddlAsmtId.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlAsmtId.Items.Add(li);
        }
        FillddlPost();
    }
    protected void FillddlPost()
    {
        if (ddlClientCode.Items.Count > 0 && ddlAsmtId.Items.Count > 0)
        {
            var objSales = new BL.Sales();
            DataSet ds = objSales.PostGetAll(ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value);
            ddlPost.DataSource = ds;

            ddlPost.DataTextField = "Post";
            ddlPost.DataValueField = "PostAutoId";
            ddlPost.DataBind();
            if (ddlPost.Text == "")
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlPost.Items.Add(li);
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        divTaging.Visible = false;
        divMaster.Visible = true;
        FillgvAssetMaster();
    }  
    private bool CheckDate(DateTime dateValue, string id, string areaIncharge)
    {
        bool result = false;
        DataTable dt = (DataTable)ViewState["AreaDates"];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["AssetOwnerMappingAutoId"].ToString() == id)
            {
                dt.Rows[i].Delete();
                dt.AcceptChanges();
                break;
            }
        }

        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["EffectiveTo"].ToString()))
                {
                    if (dateValue <= DateTime.Parse(dr["EffectiveTo"].ToString()) && dr["EmployeeNumber"].ToString() == areaIncharge)
                    {
                        result = true;
                        break;
                    }
                }
            }
        }
        return result;
    } 
   
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            if(( lblAsmt1.Text != ddlAsmtId.SelectedItem.Text) && (lblSubSite1.Text != ddlPost.SelectedItem.Text))
            { 
            ds = objAssetMgmt.AssetTransferInitiated(Convert.ToInt32(hfId.Value), Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, Convert.ToInt32(ddlPost.SelectedItem.Value), "Initiated", BaseUserID);
          
            if(ds.Tables[0].Rows[0]["MessageId"].ToString() == "0")
            {
                btnupdate.Visible = false;
                btnUpdateMapping.Visible = true;
                ddlAsmtId.Enabled = false;
                ddlPost.Enabled = false;
                lblMapping.Text = "Email is sent for the approval";
            }
            else
            {
                btnupdate.Visible = true;
                btnUpdateMapping.Visible = false;
                ddlAsmtId.Enabled = true;
                ddlPost.Enabled = true;
                lblMapping.Text = "Request already send ,still waiting for the approval.";
            }
            }
            else
            {
                lblMapping.Text = "You cann't Transfer to the same site to which asset is already mapped.";
            }
          
        }
        catch (Exception ex)
        {
        }
    }
  
    protected void lblAssetCode_Click1(object sender, EventArgs e)
    {
        divTaging.Visible = true;
        divMaster.Visible = false;
        lblMapping.Text = "";
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfAssetMaster = (HiddenField)gvAssetMaster.Rows[row.RowIndex].FindControl("hfAssetMaster");
        LinkButton lblAssetCode = (LinkButton)gvAssetMaster.Rows[row.RowIndex].FindControl("lblAssetCode");
        //  LinkButton btnAction = (LinkButton)gvAssetMaster.Rows[row.RowIndex].FindControl("btnAction");
        Label LbAssestName = (Label)gvAssetMaster.Rows[row.RowIndex].FindControl("LbAssestName");
        lblAssetCode1.Text = lblAssetCode.Text;
        lblAssetName1.Text = LbAssestName.Text;
        hfId.Value = hfAssetMaster.Value;
        divAllocate.Visible = false;
        ddlAsmtId.Enabled = true;
        ddlPost.Enabled = true;
        FillAssetClientMapping(hfId.Value);
        ddlClientCode.Enabled = false;
        btnBack.Visible = true;     
        btnupdate.Visible = true;
        btnUpdateMapping.Visible = false;
        if (IsWriteAccess)
        {
            btnupdate.Visible = true;
        }
        else
        {
            btnupdate.Visible = false;
        }
    }
    protected void gvAssetMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetMaster.PageIndex * gvAssetMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
    }
}