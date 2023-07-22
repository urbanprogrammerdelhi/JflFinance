using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

public partial class AssetManagement_AssetMaster : BasePage
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
                if (!IsWriteAccess)
                {
                    btnAddNew.Visible = false;
                }
                FillgvAssetMaster();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }


        }
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
           // dsAssetMaster = objAssetMgmt.AssetMasterDetailGet(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
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
            lblNoofAsset.Text = dsAssetMaster.Tables[1].Rows[0]["totalAsset"].ToString();

        }
        catch (Exception ex)
        {
        }
    }
    protected void gvAssetMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetMaster.PageIndex * gvAssetMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
    }
    protected void gvAssetMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvAssetMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvAssetMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvAssetMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetMaster.PageIndex = e.NewPageIndex;
        gvAssetMaster.EditIndex = -1;
        FillgvAssetMaster();
    }
    protected void gvAssetMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void gvAssetMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void LbAssestName_Click(object sender, EventArgs e)
    {
        BL.AssetManagement objHRManagement = new BL.AssetManagement();

        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfAssetMaster = (HiddenField)gvAssetMaster.Rows[row.RowIndex].FindControl("hfAssetMaster");

        Response.Redirect("AssetMasterDetail.aspx?AssetId=" + hfAssetMaster.Value);
      
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetMasterDetail.aspx");
    }
    protected void btnCheckList_Click(object sender, EventArgs e)
    {
        BL.AssetManagement objHRManagement = new BL.AssetManagement();
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfAssetMaster = (HiddenField)gvAssetMaster.Rows[row.RowIndex].FindControl("hfAssetMaster");
        Response.Redirect("AssetCheckList.aspx?AssetId=" + hfAssetMaster.Value);
    }
}