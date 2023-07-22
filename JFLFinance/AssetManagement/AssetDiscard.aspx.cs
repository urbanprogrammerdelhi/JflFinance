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

public partial class AssetManagement_AssetDiscard : BasePage
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
        txtInitiate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtInitiate.Attributes.Add("readonly", "readonly");
        txtInitiateNew.Attributes.Add("readonly", "readonly");
        txtDate.Attributes.Add("readonly", "readonly");
        if (txtValue != null)
        {
            txtValue.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtValue.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (!IsPostBack)
        {
          
            hfFlag.Value = "0";
            if (IsReadAccess)
            {
                FillgvAssetMaster();            
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
            dsAssetMaster = objAssetMgmt.AssetMasterDetailGetDiscarded(BaseCompanyCode, hfFlag.Value,Convert.ToInt32(BaseLocationAutoID));
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
     
    protected void btnBack_Click(object sender, EventArgs e)
    {
        divTaging.Visible = false;
        divMaster.Visible = true;
        DivHeader.Visible = true;
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

   
    protected void lblAssetCode_Click1(object sender, EventArgs e)
    {
        divTaging.Visible = true;
        divMaster.Visible = false;
        lblMapping.Text = "";
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfAssetMaster = (HiddenField)gvAssetMaster.Rows[row.RowIndex].FindControl("hfAssetMaster");
        LinkButton lblAssetCode = (LinkButton)gvAssetMaster.Rows[row.RowIndex].FindControl("lblAssetCode");
        Label LbAssestName = (Label)gvAssetMaster.Rows[row.RowIndex].FindControl("LbAssestName");
        lblAssetCode1.Text = lblAssetCode.Text;
        lblAssetName1.Text = LbAssestName.Text;
        hfId.Value = hfAssetMaster.Value;
        divAllocate.Visible = false; 
        btnBack.Visible = true;
        txtValue.Text = "";    
        lblMapping.Text = "";
        DivHeader.Visible = false;
        var ds = new DataSet();
        var ds1 = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        if(hfFlag.Value == "0")
        {
            btnInitiateDiscard.Visible = true;
            btnAuthorizeDiscard.Visible = false;
            txtValue.Enabled = true;
            txtDate.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            txtInitiateNew.Visible = false;
            txtInitiate.Visible = true;
            if (IsWriteAccess)
            {
                btnInitiateDiscard.Visible = true;
            }
            else
            {
                btnInitiateDiscard.Visible = false;
            }

        }
        else if (hfFlag.Value == "1")
        {
            btnInitiateDiscard.Visible = false;
            btnAuthorizeDiscard.Visible = true;
            txtValue.Enabled = false;
            txtDate.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            txtInitiateNew.Visible = true;
            txtInitiate.Visible = false;
            ds = objAssetMgmt.GetAssetdiscardDetail(Convert.ToInt32(hfId.Value), Convert.ToInt32(BaseLocationAutoID),"Under Process");
            txtValue.Text = ds.Tables[0].Rows[0]["DiscardValue"].ToString();
            txtInitiateNew.Text = ds.Tables[0].Rows[0]["InitaiteDate"].ToString();
         
            if (IsWriteAccess)
            {
                btnAuthorizeDiscard.Visible = true;
            }
            else
            {
                btnAuthorizeDiscard.Visible = false;
            }
         
        }
        else
        {
            btnInitiateDiscard.Visible = false;
            btnAuthorizeDiscard.Visible = false;
            txtValue.Enabled = false;
            txtDate.Visible = true;
            Label12.Visible = true;
            Label13.Visible = true;
            txtInitiateNew.Visible = true;
            txtInitiate.Visible = false;
            ds1 = objAssetMgmt.GetAssetdiscardDetail(Convert.ToInt32(hfId.Value), Convert.ToInt32(BaseLocationAutoID), "Discarded");
            txtValue.Text = ds1.Tables[0].Rows[0]["DiscardValue"].ToString();
            txtInitiateNew.Text = ds1.Tables[0].Rows[0]["InitaiteDate"].ToString();
            txtDate.Text = ds1.Tables[0].Rows[0]["DiscardDate"].ToString();          
        }

       
    }
    protected void btnInitiateDiscard_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            ds = objAssetMgmt.AssetDiscardInitaite(Convert.ToInt32(hfId.Value), Convert.ToInt32(BaseLocationAutoID), txtValue.Text , BaseUserID, "Under Process");
            if (ds.Tables[0].Rows[0]["MessageId"].ToString() == "0")
            {
                lblMapping.Text="Asset discard request has been submitted successfully !!";
            }
            btnInitiateDiscard.Visible = false;
        }
        catch (Exception ex)
        { }
    }
    protected void btnAuthorizeDiscard_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            ds = objAssetMgmt.AssetDiscardAuthorized(Convert.ToInt32(hfId.Value), Convert.ToInt32(BaseLocationAutoID), txtValue.Text, BaseUserID, "Discarded",txtInitiateNew.Text);
            if (ds.Tables[0].Rows[0]["MessageId"].ToString() == "0")
            {
                lblMapping.Text = "Asset discarded successfully !!";
            }
            btnInitiateDiscard.Visible = false;
            btnAuthorizeDiscard.Visible = false;
         
        }
        catch (Exception ex)
        { }
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        hfFlag.Value = "0";
        FillgvAssetMaster();
    }
    protected void btnUnderProcess_Click(object sender, EventArgs e)
    {
        hfFlag.Value = "1";
        FillgvAssetMaster();
    }
    protected void btnDiscarded_Click(object sender, EventArgs e)
    {
        hfFlag.Value = "2";
        FillgvAssetMaster();
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