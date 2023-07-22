using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

public partial class AssetManagement_AssetCategory : BasePage
{
    static int dtflag;
    static int dtflag1;
    static string AssetId;
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
                FillgvAssetCategory();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }

    }

    # region Function related to Assest Category
    private void FillgvAssetCategory()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetCategory = new DataSet();
            var dtAssetCategory = new DataTable();
            dtflag = 1;
            dsAssetCategory = objAssetMgmt.AssetCategoryDetailGet(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            dtAssetCategory = dsAssetCategory.Tables[0];
            if (dtAssetCategory.Rows.Count == 0)
            {
                dtflag = 0;
                dtAssetCategory.Rows.Add(dtAssetCategory.NewRow());
            }
            gvAssetCategory.DataSource = dtAssetCategory;
            gvAssetCategory.DataBind();

            if (dtflag == 0)
            {
                gvAssetCategory.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
            if (dsAssetCategory.Tables[0].Rows[0]["AssetCategoryAutoId"].ToString() != string.Empty)
            {
                if (AssetId != string.Empty)
                {
                    AssetId = dsAssetCategory.Tables[0].Rows[0]["AssetCategoryAutoId"].ToString();
                }
                FillgvAssetSubCategory(AssetId);
                PanelAssetSubCategory.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void LbAssestCategory_Click(object sender, EventArgs e)
    {
        GridViewRow gvAssetCategory = ((LinkButton)sender).NamingContainer as GridViewRow;
        HiddenField hfid = (HiddenField)gvAssetCategory.FindControl("hfAssetCategoryAutoId");
        AssetId = hfid.Value;
        FillgvAssetSubCategory(AssetId);
        PanelAssetSubCategory.Visible = true;
    }
    protected void gvAssetCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetCategory.PageIndex * gvAssetCategory.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!IsDeleteAccess)
            {
                var IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Visible = false;
                }

            }
            if (!IsModifyAccess)
            {
                var IBEditTran = (ImageButton)e.Row.FindControl("IBEditTran");
                if (IBEditTran != null)
                    IBEditTran.Visible = false;

            }
            var txtAssetCategory = (TextBox)e.Row.FindControl("txtAssetCategory");
            if (txtAssetCategory != null)
            {
                txtAssetCategory.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAssetCategory.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {
                var txtAssetCategory = (TextBox)e.Row.FindControl("txtAssetCategory");
                if (txtAssetCategory != null)
                {
                    txtAssetCategory.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtAssetCategory.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
            }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Visible = false;
                    gvAssetCategory.ShowFooter = false;
                }
            }
        }

    }
    protected void gvAssetCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetCategoryAutoIdnew = (HiddenField)gvAssetCategory.FooterRow.FindControl("hfAssetCategoryAutoIdnew");

        var txtAssetCategory = (TextBox)gvAssetCategory.FooterRow.FindControl("txtAssetCategory");

        if (e.CommandName == "AddNew")
        {
            try
            {
                ds = objAssetMgmt.AssetCategoryInsert(Convert.ToInt32(hfAssetCategoryAutoIdnew.Value), txtAssetCategory.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
                DisplayMessage(lblAssetCategory, ds.Tables[0].Rows[0]["MessageId"].ToString());
                txtAssetCategory.Text = "";

                FillgvAssetCategory();
            }
            catch (Exception ex)
            { }

        }
        if (e.CommandName == "Reset")
        {
            txtAssetCategory.Text = "";
        }

    }
    protected void gvAssetCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        HiddenField ID = (HiddenField)gvAssetCategory.Rows[e.RowIndex].FindControl("hfAssetCategoryAutoId");
        ds = objAssetMgmt.AssetCategoryDelete(Convert.ToInt32(ID.Value), BaseCompanyCode,Convert.ToInt32(BaseLocationAutoID));
        DisplayMessage(lblAssetCategory, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvAssetCategory.EditIndex = -1;
        FillgvAssetCategory();
    }
    protected void gvAssetCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetCategory.EditIndex = e.NewEditIndex;
        FillgvAssetCategory();

    }
    protected void gvAssetCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetCategory.PageIndex = e.NewPageIndex;
        gvAssetCategory.EditIndex = -1;
        FillgvAssetCategory();
    }
    protected void gvAssetCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetCategory.EditIndex = -1;
        FillgvAssetCategory();
    }
    protected void gvAssetCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        HiddenField hfAssetCategoryAutoId = (HiddenField)gvAssetCategory.Rows[e.RowIndex].FindControl("hfAssetCategoryAutoId");
        TextBox txtAssetCategory = (TextBox)gvAssetCategory.Rows[e.RowIndex].FindControl("txtAssetCategory");
        try
        {
            ds = objAssetMgmt.AssetCategoryInsert(Convert.ToInt32(hfAssetCategoryAutoId.Value), txtAssetCategory.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            txtAssetCategory.Text = "";

            DisplayMessage(lblAssetCategory, ds.Tables[0].Rows[0]["MessageId"].ToString());
        }
        catch (Exception ex)
        { }
        gvAssetCategory.EditIndex = -1;
        FillgvAssetCategory();

    }
    #endregion

    # region function related to Asset Sub Category
    private void FillgvAssetSubCategory(string id)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetSubCategory = new DataSet();
            var dtAssetSubCategory = new DataTable();
            dtflag1 = 1;
            dsAssetSubCategory = objAssetMgmt.AssetSubCategoryDetailGet(Convert.ToInt32(id), BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            dtAssetSubCategory = dsAssetSubCategory.Tables[0];
            if (dtAssetSubCategory.Rows.Count == 0)
            {
                dtflag1 = 0;
                dtAssetSubCategory.Rows.Add(dtAssetSubCategory.NewRow());
            }
            gvAssetSubCategory.DataSource = dtAssetSubCategory;
            gvAssetSubCategory.DataBind();

            if (dtflag1 == 0)
            {
                gvAssetSubCategory.Rows[0].Visible = false;
                dtflag1 = 0;
            }
            else
            {
                dtflag1 = 1;
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void gvAssetSubCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetSubCategory.PageIndex * gvAssetSubCategory.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!IsDeleteAccess)
            {
                var IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Visible = false;
                }

            }
            if (!IsModifyAccess)
            {
                var IBEditTran = (ImageButton)e.Row.FindControl("IBEditTran");
                if (IBEditTran != null)
                    IBEditTran.Visible = false;

            }
            var txtAssetSubCategory = (TextBox)e.Row.FindControl("txtAssetSubCategory");
            if (txtAssetSubCategory != null)
            {
                txtAssetSubCategory.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAssetSubCategory.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {
                var txtAssetSubCategory = (TextBox)e.Row.FindControl("txtAssetSubCategory");
                if (txtAssetSubCategory != null)
                {
                    txtAssetSubCategory.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtAssetSubCategory.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
            }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Visible = false;
                    gvAssetSubCategory.ShowFooter = false;
                }
            }
        }

    }
    protected void gvAssetSubCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetSubCategoryAutoIdnew = (HiddenField)gvAssetSubCategory.FooterRow.FindControl("hfAssetSubCategoryAutoIdnew");

        var txtAssetSubCategory = (TextBox)gvAssetSubCategory.FooterRow.FindControl("txtAssetSubCategory");

        if (e.CommandName == "AddNew")
        {
            try
            {
                ds = objAssetMgmt.AssetSubCategoryInsert(Convert.ToInt32(hfAssetSubCategoryAutoIdnew.Value), Convert.ToInt32(AssetId.ToString()), txtAssetSubCategory.Text, BaseUserID,BaseCompanyCode,Convert.ToInt32(BaseLocationAutoID));
                DisplayMessage(lblAssestSubCategoryMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                txtAssetSubCategory.Text = "";

                FillgvAssetSubCategory(AssetId.ToString());
            }
            catch (Exception ex)
            { }

        }
        if (e.CommandName == "Reset")
        {
            txtAssetSubCategory.Text = "";
        }

    }
    protected void gvAssetSubCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        HiddenField ID = (HiddenField)gvAssetSubCategory.Rows[e.RowIndex].FindControl("hfAssetSubCategoryAutoId");
        ds = objAssetMgmt.AssetSubCategoryDelete(Convert.ToInt32(ID.Value), BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        DisplayMessage(lblAssestSubCategoryMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvAssetSubCategory.EditIndex = -1;
        FillgvAssetSubCategory(AssetId.ToString());
    }
    protected void gvAssetSubCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetSubCategory.EditIndex = e.NewEditIndex;
        FillgvAssetSubCategory(AssetId.ToString());
    }
    protected void gvAssetSubCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetSubCategory.PageIndex = e.NewPageIndex;
        gvAssetSubCategory.EditIndex = -1;
        FillgvAssetSubCategory(AssetId.ToString());

    }
    protected void gvAssetSubCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        HiddenField hfAssetSubCategoryAutoId = (HiddenField)gvAssetSubCategory.Rows[e.RowIndex].FindControl("hfAssetSubCategoryAutoId");
        TextBox txtAssetSubCategory = (TextBox)gvAssetSubCategory.Rows[e.RowIndex].FindControl("txtAssetSubCategory");
        try
        {
            ds = objAssetMgmt.AssetSubCategoryInsert(Convert.ToInt32(hfAssetSubCategoryAutoId.Value), Convert.ToInt32(AssetId.ToString()), txtAssetSubCategory.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            txtAssetSubCategory.Text = "";

            DisplayMessage(lblAssestSubCategoryMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        }
        catch (Exception ex)
        { }
        gvAssetSubCategory.EditIndex = -1;
        FillgvAssetSubCategory(AssetId.ToString());
    }
    protected void gvAssetSubCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetSubCategory.EditIndex = -1;
        FillgvAssetSubCategory(AssetId.ToString());
    }
    #endregion
}