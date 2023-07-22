using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
public partial class AssetManagement_AssetPart : BasePage
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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

    #region Page Load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillgvAssetPart();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Function to Fill GridView
    private void FillgvAssetPart()
    {
        BL.AssetManagement objdlAssetManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        DataTable dtAsset = new DataTable();
        ds = objdlAssetManagement.AssetPartGetRecords(BaseCompanyCode,Convert.ToInt32(BaseLocationAutoID));
        dtAsset = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtAsset.Rows.Count > 0)
        {
            gvAssetPart.DataSource = dtAsset;
            gvAssetPart.DataBind();
        }
        else
        {
            dtAsset = ds.Tables[0];
            dtAsset.Rows.Add(dtAsset.NewRow());
            gvAssetPart.DataSource = dtAsset;
            gvAssetPart.DataBind();
            gvAssetPart.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    private void FillddlAssetCategory(DropDownList ddlAssetCategory, DropDownList ddlAssetSubCategory)
    {
        if (ddlAssetCategory != null && ddlAssetSubCategory != null)
        {
            var objAssetManagement = new BL.AssetManagement();
            var ds = new DataSet();
            ds = objAssetManagement.AssetCategoryDetailGet(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAssetCategory.DataSource = ds.Tables[0];
                ddlAssetCategory.DataTextField = "AssetCategoryName";
                ddlAssetCategory.DataValueField = "AssetCategoryAutoId";
                ddlAssetCategory.DataBind();
            }
            if (ddlAssetCategory.SelectedValue == "")
            {
                var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
                ddlAssetCategory.Items.Add(li);
            }
            FillddlAssetSubCategory(ddlAssetSubCategory, Convert.ToInt32(ddlAssetCategory.SelectedValue));
          
        }
    }
    private void FillddlAssetSubCategory(DropDownList ddlAssetSubCategory, int AssetCategoryAutoId)
    {
        if (ddlAssetSubCategory != null)
        {
            var objAssetManagement = new BL.AssetManagement();
            var ds = new DataSet();
            ds = objAssetManagement.AssetSubCategoryDetailGet(AssetCategoryAutoId, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAssetSubCategory.DataSource = ds.Tables[0];
                ddlAssetSubCategory.DataTextField = "AssetSubCategoryName";
                ddlAssetSubCategory.DataValueField = "AssetSubCategoryAutoId";
                ddlAssetSubCategory.DataBind();
            }
            if (ddlAssetSubCategory.SelectedValue == "")
            {
                var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
                ddlAssetSubCategory.Items.Add(li);
            }
        }
    }
    private void FillddlManufacturerName(DropDownList ddlManufacturerName)
    {
        if (ddlManufacturerName != null)
        {
            var objAssetManagement = new BL.AssetManagement();
            var ds = new DataSet();
            ds = objAssetManagement.AssetManufacturerNameDetailGet(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlManufacturerName.DataSource = ds.Tables[0];
                ddlManufacturerName.DataTextField = "ManufacturerName";
                ddlManufacturerName.DataValueField = "ManufacturerAutoID";
                ddlManufacturerName.DataBind();
            }
            if (ddlManufacturerName.SelectedValue == "")
            {
                var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
                ddlManufacturerName.Items.Add(li);
            }
        }
    }
    private void FillddlAssetName(DropDownList ddlAssetName, int SubCategoryAutoId, int ManufacturerAutoId )
    {
            var objAssetManagement = new BL.AssetManagement();

            ddlAssetName.DataSource = objAssetManagement.AssetNameDetailGet(SubCategoryAutoId, ManufacturerAutoId, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            ddlAssetName.DataTextField = "AssetName";
            ddlAssetName.DataValueField = "AssetName";
            ddlAssetName.DataBind();
            if (ddlAssetName.SelectedValue == "")
            {
                var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
                ddlAssetName.Items.Add(li);
            }
    }
    private void FillddlModelNo(DropDownList ddlModelNo,int SubCategoryAutoId, int ManufacturerAutoId, string AssetName)
    {
        var objAssetManagement = new BL.AssetManagement();

        ddlModelNo.DataSource = objAssetManagement.AssetModelNoGet(SubCategoryAutoId, ManufacturerAutoId, AssetName, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        ddlModelNo.DataTextField = "ModelNo";
        ddlModelNo.DataValueField = "ModelNo";
        ddlModelNo.DataBind();
        if (ddlModelNo.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlModelNo.Items.Add(li);
        }
    }
    #endregion

    #region dropdown Events
    protected void ddlAssetCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
            //DropDownList ddlManufacturerName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlManufacturerName");
            DropDownList ddlAssetCategory = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetCategory");
            DropDownList ddlAssetSubCategory = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetSubCategory");
            //DropDownList ddlAssetName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetName");
            
            FillddlAssetSubCategory(ddlAssetSubCategory, Convert.ToInt32(ddlAssetCategory.SelectedValue));
    }
    protected void ddlAssetSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlAssetName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetName");
        DropDownList ddlManufacturerName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlManufacturerName");
        DropDownList ddlAssetSubCategory = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetSubCategory");
        DropDownList ddlModelNo = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlModelNo");

        FillddlAssetName(ddlAssetName, Convert.ToInt32(ddlAssetSubCategory.SelectedValue), Convert.ToInt32(ddlManufacturerName.SelectedValue));
        FillddlModelNo(ddlModelNo, int.Parse(ddlAssetSubCategory.SelectedItem.Value), int.Parse(ddlManufacturerName.SelectedItem.Value), ddlAssetName.SelectedItem.Value);
    }
    protected void ddlManufacturerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlManufacturerName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlManufacturerName");
        DropDownList ddlAssetSubCategory = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetSubCategory");
        DropDownList ddlAssetName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetName");
        DropDownList ddlModelNo = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlModelNo");
        FillddlAssetName(ddlAssetName, Convert.ToInt32(ddlAssetSubCategory.SelectedValue), Convert.ToInt32(ddlManufacturerName.SelectedValue));
        FillddlModelNo(ddlModelNo, int.Parse(ddlAssetSubCategory.SelectedItem.Value), int.Parse(ddlManufacturerName.SelectedItem.Value), ddlAssetName.SelectedItem.Value);
    }
    protected void ddlAssetName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlAssetName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetName");
        DropDownList ddlModelNo = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlModelNo");
        DropDownList ddlManufacturerName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlManufacturerName");
        DropDownList ddlAssetSubCategory = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetSubCategory");
        FillddlModelNo(ddlModelNo, int.Parse(ddlAssetSubCategory.SelectedItem.Value), int.Parse(ddlManufacturerName.SelectedItem.Value), ddlAssetName.SelectedItem.Value);
    }

    #endregion dropdown Events

    #region GridView Events

    /// <summary>
    /// Handles the RowCommand event of the gvAssetPart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAssetPart_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
       
        var ddlAssetCategory = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetCategory");
        var ddlAssetSubCategory = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetSubCategory");
        var ddlManufacturerName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlManufacturerName");
        var ddlAssetName = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlAssetName");
        var ddlModelNo = (DropDownList)gvAssetPart.FooterRow.FindControl("ddlModelNo");
        TextBox txtNewAssetPartNo = (TextBox)gvAssetPart.FooterRow.FindControl("txtNewAssetPartNo");
        TextBox txtNewAssetPartName = (TextBox)gvAssetPart.FooterRow.FindControl("txtNewAssetPartName");
        TextBox txtNewAssetPartQuantity = (TextBox)gvAssetPart.FooterRow.FindControl("txtNewAssetPartQuantity");
        BL.AssetManagement objblMasterManagement = new BL.AssetManagement();
        if (e.CommandName.Equals("AddNew"))
        {
            string Assetname = string.Empty;
            string ModelNo = string.Empty;
            if (ddlAssetName.SelectedValue=="0")
            { Assetname = ""; }
            else
            {
                Assetname = ddlAssetName.SelectedValue;
            }
            if (ddlModelNo.SelectedValue == "0")
            { ModelNo = ""; }
            else
            {
                ModelNo = ddlModelNo.SelectedValue;
            }


            ds = objblMasterManagement.AssetPartAddNew(Convert.ToInt32(ddlAssetCategory.SelectedValue), Convert.ToInt32(ddlAssetSubCategory.SelectedValue), Convert.ToInt32(ddlManufacturerName.SelectedValue), Assetname, ModelNo, txtNewAssetPartNo.Text, txtNewAssetPartName.Text, Convert.ToInt32(txtNewAssetPartQuantity.Text), BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));


            FillgvAssetPart();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewAssetPartNo.Text = "";
            txtNewAssetPartName.Text = "";
            txtNewAssetPartQuantity.Text = "";

            lblErrorMsg.Text = "";
        }

    }

    /// <summary>
    /// Handles the RowDataBound event of the gvAssetPart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAssetPart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetPart.PageIndex * gvAssetPart.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtAssetPartNo = (TextBox)e.Row.FindControl("txtAssetPartNo");
            if (txtAssetPartNo != null)
            {
                txtAssetPartNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAssetPartNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            var txtAssetPartName = (TextBox)e.Row.FindControl("txtAssetPartName");
            if (txtAssetPartName != null)
            {
                txtAssetPartName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAssetPartName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            var txtAssetPartQuantity = (TextBox)e.Row.FindControl("txtAssetPartQuantity");
            if (txtAssetPartQuantity != null)
            {
                txtAssetPartQuantity.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtAssetPartQuantity.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }


            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtNewAssetPartNo = (TextBox)e.Row.FindControl("txtNewAssetPartNo");
            if (txtNewAssetPartNo != null)
            {
                txtNewAssetPartNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewAssetPartNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            var txtNewAssetPartName = (TextBox)e.Row.FindControl("txtNewAssetPartName");
            if (txtNewAssetPartName != null)
            {
                txtNewAssetPartName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewAssetPartName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            var txtNewAssetPartQuantity = (TextBox)e.Row.FindControl("txtNewAssetPartQuantity");
            if (txtNewAssetPartQuantity != null)
            {
                txtNewAssetPartQuantity.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtNewAssetPartQuantity.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }
            DropDownList ddlAssetCategory = (DropDownList)e.Row.FindControl("ddlAssetCategory");
            DropDownList ddlAssetSubCategory = (DropDownList)e.Row.FindControl("ddlAssetSubCategory");
            DropDownList ddlAssetName = (DropDownList)e.Row.FindControl("ddlAssetName");
            DropDownList ddlManufacturerName = (DropDownList)e.Row.FindControl("ddlManufacturerName");
            DropDownList ddlModelNo = (DropDownList)e.Row.FindControl("ddlModelNo");
            FillddlAssetCategory(ddlAssetCategory, ddlAssetSubCategory);
            FillddlManufacturerName(ddlManufacturerName);
            FillddlAssetName(ddlAssetName, Convert.ToInt32(ddlAssetSubCategory.SelectedValue), Convert.ToInt32(ddlManufacturerName.SelectedValue));
            FillddlModelNo(ddlModelNo, int.Parse(ddlAssetSubCategory.SelectedItem.Value), int.Parse(ddlManufacturerName.SelectedItem.Value), ddlAssetName.SelectedItem.Value);

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Visible = false;
                    gvAssetPart.ShowFooter = false;
                }
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
            
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvAssetPart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvAssetPart_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetPart.EditIndex = e.NewEditIndex;
        FillgvAssetPart();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvAssetPart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvAssetPart_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objblMastermanagement = new BL.AssetManagement();
        HiddenField hfAssetPartsAutoId = (HiddenField)gvAssetPart.Rows[e.RowIndex].FindControl("hfAssetPartsAutoId");
        TextBox txtAssetPartNo = (TextBox)gvAssetPart.Rows[e.RowIndex].FindControl("txtAssetPartNo");
        TextBox txtAssetPartName = (TextBox)gvAssetPart.Rows[e.RowIndex].FindControl("txtAssetPartName");
        TextBox txtAssetPartQuantity = (TextBox)gvAssetPart.Rows[e.RowIndex].FindControl("txtAssetPartQuantity");
        if (System.Text.RegularExpressions.Regex.IsMatch(txtAssetPartQuantity.Text, "[^0-9.]"))
        {

            Show(Resources.Resource.ValidQuantity);

            txtAssetPartQuantity.Focus();

            txtAssetPartQuantity.Text = "";

            return;

        }
        ds = objblMastermanagement.AssetPartUpdate(Convert.ToInt32(hfAssetPartsAutoId.Value), txtAssetPartNo.Text, txtAssetPartName.Text, Convert.ToInt32(txtAssetPartQuantity.Text), BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        gvAssetPart.EditIndex = -1;
        FillgvAssetPart();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
   
    /// <summary>
    /// Handles the RowDeleting event of the gvAssetPart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAssetPart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.AssetManagement objblMasterManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        HiddenField hfAssetPartsAutoId = (HiddenField)gvAssetPart.Rows[e.RowIndex].FindControl("hfAssetPartsAutoId");

        ds = objblMasterManagement.AssetPartDelete(Convert.ToInt32(hfAssetPartsAutoId.Value), BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));

        FillgvAssetPart();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvAssetPart control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAssetPart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetPart.PageIndex = e.NewPageIndex;
        gvAssetPart.EditIndex = -1;
        FillgvAssetPart();
    }
    protected void gvAssetPart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetPart.EditIndex = -1;
        FillgvAssetPart();
    }
    
    #endregion GridView Events
}
   