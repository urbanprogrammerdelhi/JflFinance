using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjaxControlToolkit;
public partial class AssetManagement_AssetMasterDetail : BasePage
{
    static int dtflag;
    static int dtflag1;
    static int dtflag2;
    const string uploadfolder = @"~\\DocumentUpload\\AssetDocUpload\\";
    // const string uploadfolderDBPath = "DocumentUpload\\EmployeeDocUpload\\IDProof\\";
    static string filepath = "";
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
    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
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
      
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack)
        {
           
           if (IsReadAccess)
           {
              
               AssetIdQs.Text = Request.QueryString["AssetId"];
               
               if (AssetIdQs.Text != "")
            {
                FillDetailsForUpdate(AssetIdQs.Text);
                FillAssetPurchaseDetail(AssetIdQs.Text);
                FillgvAssetLease(AssetIdQs.Text);
                FillgvAssetInsurance(AssetIdQs.Text);
                FillgvAssetGurantee(AssetIdQs.Text);
                FillgvAssetWarrenty(AssetIdQs.Text);
                FillgvAssetNote(AssetIdQs.Text);
                FillgvAssetAMC(AssetIdQs.Text);
                FillAssetClientMapping(AssetIdQs.Text);
                txtAssetCode.Attributes.Add("readonly", "readonly");
                txtAssetName.Attributes.Add("readonly", "readonly");
                btnedit.Visible = true;
                btnSubmit.Visible = false;
                btnReset.Visible = false;
                spanImage.Visible = true;
                UpdatePanel1.Visible = true;
                
            }
            else
            {
                UpdatePanel1.Visible = false;
                btnedit.Visible = false;
                btnSubmit.Visible = true;
                btnReset.Visible =true;
                spanImage.Visible = false;
            }
           
            FillAssetCategory();
            FillAssetSubCategory(Convert.ToInt32(ddlAssetCategory.SelectedValue));
            FillAssetManufacturer();
            FillddlAreaID();
            FillddlClient();
            //FillAsmtId();
            //FillddlPost();
            
            #region validation for Asset Master
            if (txtAssetName != null)
            {
                txtAssetName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAssetName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtAssetCode != null)
            {
                txtAssetCode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
                txtAssetCode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");");
            }
            if (txtModelNo != null)
            {
                txtModelNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtModelNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtModelName != null)
            {
                txtModelName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtModelName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtSerialNo != null)
            {
                txtSerialNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtSerialNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtDescription != null)
            {
                txtDescription.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDescription.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtTagID != null)
            {
                txtTagID.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtTagID.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtRemarks != null)
            {
                txtRemarks.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRemarks.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtCondition != null)
            {
                txtCondition.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtCondition.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            #endregion
            #region Validation for Asset Purchase
           
            if (txtPurchaseCompanyName != null)
            {
                txtPurchaseCompanyName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtPurchaseCompanyName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtPurchaseOrderNo != null)
            {
                txtPurchaseOrderNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtPurchaseOrderNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtPurchaseDate != null)
            {
                txtPurchaseDate.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtPurchaseDate.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtPurchasePrice != null)
            {
                txtPurchasePrice.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtPurchasePrice.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            }
            if (txtPurchaseSuppliername != null)
            {
                txtPurchaseSuppliername.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtPurchaseSuppliername.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtPurchaseSupplierPhone != null)
            {
                txtPurchaseSupplierPhone.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                txtPurchaseSupplierPhone.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
            }
            if (txtPurchaseSupplierAddress != null)
            {
                txtPurchaseSupplierAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtPurchaseSupplierAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtPurchaseRemarks != null)
            {
                txtPurchaseRemarks.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtPurchaseRemarks.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            #endregion
            if (txtRemark != null)
            {
                txtRemark.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRemark.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtUsage != null)
            {
                txtUsage.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtUsage.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            txtInactivewef.Attributes.Add("readonly","readonly");
            txtActivewef.Attributes.Add("readonly", "readonly");
            txtPurchaseAssetName.Attributes.Add("readonly", "readonly");
              
            txtPurchaseDate.Attributes.Add("readonly", "readonly");
            txtPurchaseAssetName.Text = txtAssetName.Text;
            if (!IsModifyAccess)
            {

                btnedit.Visible = false;
                btnUpload.Visible = false;
                BtnPurchaseEdit.Visible = false;

            }
            if (!IsWriteAccess)
            {
                btnSubmit.Visible = false;
                btnReset.Visible = false;
                BtnPurchaseSave.Visible = false;
                BtnPurchaseReset.Visible = false;
            }
               if(!IsAuthorizationAccess)
               { txtMgmtGuidline.Enabled = false; }
            }
           else
           {
               Response.Redirect("../UserManagement/Home.aspx");
           }
        }
    }
    #region Function related to Asset Master Detail 
    private void FillAssetCategory()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlAssetCategory.DataSource = objAssetManagement.AssetCategoryDetailGet(BaseCompanyCode,Convert.ToInt32(BaseLocationAutoID));
        ddlAssetCategory.DataTextField = "AssetCategoryName";
        ddlAssetCategory.DataValueField = "AssetCategoryAutoId";
        ddlAssetCategory.DataBind();
        if (ddlAssetCategory.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAssetCategory.Items.Add(li);
         
        }


    }
    private void FillAssetSubCategory(int AssetId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlAssetSubCategory.DataSource = objAssetManagement.AssetSubCategoryDetailGet(AssetId, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        ddlAssetSubCategory.DataTextField = "AssetSubCategoryName";
        ddlAssetSubCategory.DataValueField = "AssetSubCategoryAutoId";
        ddlAssetSubCategory.DataBind();
        if (ddlAssetSubCategory.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAssetSubCategory.Items.Add(li);
           
        }


    }
    private void FillAssetManufacturer()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlAssetManufacture.DataSource = objAssetManagement.AssetManufactureDetailGet(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        ddlAssetManufacture.DataTextField = "ManufacturerName";
        ddlAssetManufacture.DataValueField = "ManufacturerAutoID";
        ddlAssetManufacture.DataBind();
        if (ddlAssetManufacture.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAssetManufacture.Items.Add(li);
          //  btnSave.Enabled = false;
        }


    }
    private void FillDetailsForUpdate(string AssetId)
    {
        var objAssetMgmt = new BL.AssetManagement();


        var ds = objAssetMgmt.AssetMasterDetailForUpdate(AssetId, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        try
        {
            txtAssetCode.Text = ds.Tables[0].Rows[0]["AssetCode"].ToString();
            txtAssetName.Text = ds.Tables[0].Rows[0]["AssetName"].ToString();
            ddlAssetCategory.SelectedValue = ds.Tables[0].Rows[0]["AssetCategoryAutoId"].ToString();
            ddlAssetSubCategory.SelectedValue = ds.Tables[0].Rows[0]["AssetSubCategoryAutoId"].ToString();
            ddlAssetManufacture.SelectedValue = ds.Tables[0].Rows[0]["ManufacturerAutoID"].ToString();
            txtModelNo.Text = ds.Tables[0].Rows[0]["ModelNo"].ToString();
            txtModelName.Text = ds.Tables[0].Rows[0]["ModelName"].ToString();
            txtSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            ddlAssetOwner.SelectedValue = ds.Tables[0].Rows[0]["AssetOwner"].ToString();
            txtTagID.Text = ds.Tables[0].Rows[0]["TagId"].ToString();
            txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            ddlIsActive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();
            if (ds.Tables[0].Rows[0]["IsActive"].ToString() == "True")
            { ddlIsActive.Enabled = true;
            ImageButton2.Enabled = false;
            ImageButton1.Enabled = true;
            }
            else
            { ddlIsActive.Enabled = false;
            ImageButton2.Enabled = true;
            ImageButton1.Enabled = false;
            }
            if (ds.Tables[0].Rows[0]["InactiveWEF"].ToString() == "1/1/1900 12:00:00 AM" || ds.Tables[0].Rows[0]["InactiveWEF"].ToString() == "01/01/1900 12:00:00 AM" || ds.Tables[0].Rows[0]["InactiveWEF"].ToString() == "01-Jan-00 12:00:00 AM")
            { txtInactivewef.Text = ""; }
            else
            { txtInactivewef.Text = DateFormat(ds.Tables[0].Rows[0]["InactiveWEF"].ToString()); }

            txtActivewef.Text =DateFormat( ds.Tables[0].Rows[0]["ActiveWEF"].ToString());
            ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
            txtCondition.Text = ds.Tables[0].Rows[0]["Condition"].ToString();
            lblImageUrl.Text = ds.Tables[0].Rows[0]["Photo"].ToString();
            txtMgmtGuidline.Text = ds.Tables[0].Rows[0]["ManagementGuideline"].ToString();
            if (ds.Tables[0].Rows[0]["AssetOwner"].ToString() == "Client")
            {
               // AssetClientMapping.Visible = true;
            }
            else
            {
              //  AssetClientMapping.Visible = false;
            }
            #region to Show the Asset Image
            string ImageFileName = ds.Tables[0].Rows[0]["Photo"].ToString();
            int i = ImageFileName.IndexOf("\\DocumentUpload\\AssetDocUpload\\") + 31;
            ImageFileName = ImageFileName.Substring(i, ImageFileName.Length - i);

            string path = "~/DocumentUpload/AssetDocUpload/";
            string FileName = path + ImageFileName;
            string DefaultFileName = path + "NoImage.jpg";

            string ServerLocalPath = Server.MapPath(path);
            string ServerLocalFileName = ServerLocalPath + ImageFileName;
            string ServerLocalDefaultFileName = ServerLocalPath + "NoImage.jpg";

            if (File.Exists(ServerLocalFileName))
            {
                ImageBox.ImageUrl = FileName;
            }
            else if (File.Exists(ServerLocalDefaultFileName))
            {
                ImageBox.ImageUrl = DefaultFileName;
            }

            #endregion
        }
        catch (Exception ex)
        {
            // ignored
        }
    }
    protected void ddlAssetCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
       FillAssetSubCategory(Convert.ToInt32( ddlAssetCategory.SelectedValue));
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetMaster.aspx");
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();

        try
        {
            if (txtInactivewef.Text != "" && txtActivewef.Text != "")
            {
                if (DateTime.Parse(txtInactivewef.Text) > DateTime.Parse(txtActivewef.Text))
                {
                    ds = objAssetMgmt.AssetMasterDetailUpdate(Convert.ToInt32(AssetIdQs.Text), txtAssetCode.Text, txtAssetName.Text, ddlAssetCategory.SelectedValue, ddlAssetSubCategory.SelectedValue, ddlAssetManufacture.SelectedValue, txtModelNo.Text, txtModelName.Text, txtSerialNo.Text, txtDescription.Text, ddlAssetOwner.SelectedValue, txtTagID.Text, txtRemarks.Text, ddlIsActive.SelectedValue, txtInactivewef.Text, txtActivewef.Text, ddlStatus.SelectedValue, txtCondition.Text, lblImageUrl.Text, txtMgmtGuidline.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
                    DisplayMessage(lblAssestMaster, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    if (ddlIsActive.SelectedValue == "False")
                        ddlIsActive.Enabled = false;
                    else
                        ddlIsActive.Enabled = true;
                    if(ddlAssetOwner.SelectedValue == "Client")
                    {
                       // AssetClientMapping.Visible = true;
                    }
                    else
                    {
                        //AssetClientMapping.Visible = false;
                        //DeleteAssetClientMappingDetails();
                    }
                    //Response.Redirect("AssetMaster.aspx");
                }                else
                {
                    lblAssestMaster.Text = Resources.Resource.InactiveDateGreaterThanActive;
                    
                    txtInactivewef.Text = "";
                }
            }
            else
            {
                ds = objAssetMgmt.AssetMasterDetailUpdate(Convert.ToInt32(AssetIdQs.Text), txtAssetCode.Text, txtAssetName.Text, ddlAssetCategory.SelectedValue, ddlAssetSubCategory.SelectedValue, ddlAssetManufacture.SelectedValue, txtModelNo.Text, txtModelName.Text, txtSerialNo.Text, txtDescription.Text, ddlAssetOwner.SelectedValue, txtTagID.Text, txtRemarks.Text, ddlIsActive.SelectedValue, txtInactivewef.Text, txtActivewef.Text, ddlStatus.SelectedValue, txtCondition.Text, lblImageUrl.Text, txtMgmtGuidline.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
                DisplayMessage(lblAssestMaster, ds.Tables[0].Rows[0]["MessageId"].ToString());
                if (ddlAssetOwner.SelectedValue == "Client")
                {
                  //  AssetClientMapping.Visible = true;
                }
                else
                {
                  //  AssetClientMapping.Visible = false;
                  //  DeleteAssetClientMappingDetails();
                }
              //  Response.Redirect("AssetMaster.aspx");

            }
           FillgvAssetLease(AssetIdQs.Text);
           FillAssetPurchaseDetail(AssetIdQs.Text);
           txtPurchaseAssetName.Text = txtAssetName.Text;

           
        }
        catch (Exception ex)
        { }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();

        try
        {
            if (txtInactivewef.Text != "" && txtActivewef.Text != "")
            {
                if (DateTime.Parse(txtInactivewef.Text) > DateTime.Parse(txtActivewef.Text))
                {
                    ds = objAssetMgmt.AssetMasterDetailInsert(txtAssetCode.Text.Trim(), txtAssetName.Text, ddlAssetCategory.SelectedValue, ddlAssetSubCategory.SelectedValue, ddlAssetManufacture.SelectedValue, txtModelNo.Text, txtModelName.Text, txtSerialNo.Text, txtDescription.Text, ddlAssetOwner.SelectedValue, txtTagID.Text, txtRemarks.Text, ddlIsActive.SelectedValue, txtInactivewef.Text, txtActivewef.Text, ddlStatus.SelectedValue, txtCondition.Text, lblImageUrl.Text, txtMgmtGuidline.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
                    DisplayMessage(lblAssestMaster, ds.Tables[0].Rows[0]["MessageId"].ToString());
                   Response.Redirect("AssetMasterDetail.aspx?AssetId=" + ds.Tables[1].Rows[0]["AssetAutoId"].ToString());

                }
                else
                {
                    lblAssestMaster.Text = Resources.Resource.InactiveDateGreaterThanActive;
                    txtInactivewef.Text = "";
                }
            }
            else
            {
                ds = objAssetMgmt.AssetMasterDetailInsert(txtAssetCode.Text.Trim(), txtAssetName.Text, ddlAssetCategory.SelectedValue, ddlAssetSubCategory.SelectedValue, ddlAssetManufacture.SelectedValue, txtModelNo.Text, txtModelName.Text, txtSerialNo.Text, txtDescription.Text, ddlAssetOwner.SelectedValue, txtTagID.Text, txtRemarks.Text, ddlIsActive.SelectedValue, txtInactivewef.Text, txtActivewef.Text, ddlStatus.SelectedValue, txtCondition.Text, lblImageUrl.Text, txtMgmtGuidline.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
                 DisplayMessage(lblAssestMaster, ds.Tables[0].Rows[0]["MessageId"].ToString());
                Response.Redirect("AssetMasterDetail.aspx?AssetId=" + ds.Tables[1].Rows[0]["AssetAutoId"].ToString());
               

            }
        }
        catch (Exception ex)
        { }

    }
    protected void ddlIsActive_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIsActive.SelectedValue == "True")
        {
            rfvtxtActivewef.Enabled = true;
            rfvtxtInactivewef.Enabled = false;
            ImageButton2.Enabled = false;
            ImageButton1.Enabled = true;
        }
        else
        {
            rfvtxtActivewef.Enabled = false;
            rfvtxtInactivewef.Enabled = true;
            ImageButton2.Enabled = true;
            ImageButton1.Enabled = false;
            
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUploadAsset.HasFile)
        {
            String fileExtension = System.IO.Path.GetExtension(FileUploadAsset.PostedFile.FileName).ToLower();
            String[] allowedExtensions = {".bmp", ".gif", ".png", ".jpeg", ".jpg" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    string FileName;
                    string WebFileName;
                    String path = Server.MapPath("~/DocumentUpload/AssetDocUpload/");
                    FileName = path;

                    string ext = System.IO.Path.GetExtension(FileUploadAsset.PostedFile.FileName);
                    FileName = FileName + AssetIdQs.Text + ext;

                    WebFileName = "~/DocumentUpload/AssetDocUpload/" + AssetIdQs.Text + ext;

                    lblImageUrl.Text = FileName;

                    var dir = new DirectoryInfo(path);
                    foreach (var file in dir.EnumerateFiles(AssetIdQs.Text + ".*"))
                    {
                        file.Delete();
                    }
                    FileUploadAsset.PostedFile.SaveAs(FileName);

                    var ds = new DataSet();
                    var objAssetMgmt = new BL.AssetManagement();
                    ds = objAssetMgmt.AssetMasterImageUpload(AssetIdQs.Text, lblImageUrl.Text, BaseUserID,BaseCompanyCode);
                    FillDetailsForUpdate(AssetIdQs.Text);

                    ImageBox.ImageUrl = WebFileName;
                }
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtActivewef.Text = "";
        txtAssetCode.Text = "";
        txtAssetName.Text = "";
        txtCondition.Text = "";
        txtDescription.Text = "";
        txtInactivewef.Text = "";
        txtModelName.Text = "";
        txtModelNo.Text = "";
        txtRemarks.Text = "";
        txtSerialNo.Text = "";
        txtTagID.Text = "";
        txtMgmtGuidline.Text = "";
      
    }
    
#endregion
    protected void AssetDetails_ActiveTabChanged(object sender, EventArgs e)
    {
        if (AssetDetails.ActiveTabIndex == 0)
        {
            FillAssetPurchaseDetail(AssetIdQs.Text);
        }
        if (AssetDetails.ActiveTabIndex == 1)
        {
            FillgvAssetLease(AssetIdQs.Text);
        }
        if (AssetDetails.ActiveTabIndex == 2)
        {
            FillgvAssetInsurance(AssetIdQs.Text);
        }
        if (AssetDetails.ActiveTabIndex == 3)
        {
            FillgvAssetGurantee(AssetIdQs.Text);
        }
        if (AssetDetails.ActiveTabIndex == 4)
        {
            FillgvAssetWarrenty(AssetIdQs.Text);
        }
        if (AssetDetails.ActiveTabIndex == 5)
        {
            FillgvAssetNote(AssetIdQs.Text);
            AssetNote.Attributes.Add("Height", "420px");
        }
    }
    #region Function related to Asset Purchase
    private void FillAssetPurchaseDetail(string AssetId)
    {
        var objAssetMgmt = new BL.AssetManagement();
        var ds = objAssetMgmt.AssetPurchaseDetail(AssetId,BaseCompanyCode);
        try
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["CompanyName"].ToString() != string.Empty && ds.Tables[0].Rows[0]["PurchaseOrderNo"].ToString() != string.Empty)
                    {
                        txtPurchaseCompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                        txtPurchaseOrderNo.Text = ds.Tables[0].Rows[0]["PurchaseOrderNo"].ToString();
                        if (ds.Tables[0].Rows[0]["PurchaseDate"].ToString() == "1/1/1900 12:00:00 AM")
                        { txtPurchaseDate.Text = ""; }
                        else
                        { txtPurchaseDate.Text = DateFormat(ds.Tables[0].Rows[0]["PurchaseDate"].ToString()); }
                        if (txtPurchaseOrderNo.Text == "")
                        { AssetLease.Visible = true; }
                        else
                        { AssetLease.Visible = false;
                        }
                        txtPurchasePrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                        txtPurchaseSuppliername.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                        txtPurchaseSupplierEmail.Text = ds.Tables[0].Rows[0]["SupplierEmail"].ToString();
                        txtPurchaseSupplierPhone.Text = ds.Tables[0].Rows[0]["SupplierPhone"].ToString();
                        txtPurchaseSupplierAddress.Text = ds.Tables[0].Rows[0]["SupplierAddress"].ToString();
                        txtPurchaseRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                        txtPurchaseOrderNo.Attributes.Add("readonly", "readonly");
                        BtnPurchaseEdit.Visible = true;
                        BtnPurchaseSave.Visible = false;
                        BtnPurchaseReset.Visible = false;
                        txtPurchaseDate.Enabled = true;
                    }
                    else
                    {
                        txtPurchaseOrderNo.Enabled = true;
                        BtnPurchaseEdit.Visible = false;
                        BtnPurchaseSave.Visible = true;
                        BtnPurchaseReset.Visible = true;
                        txtPurchaseDate.Enabled = false;
                    }

                }
                else
                {
                    txtPurchaseOrderNo.Enabled = true;
                    BtnPurchaseEdit.Visible = false;
                    BtnPurchaseSave.Visible = true;
                    BtnPurchaseReset.Visible = true;
                    txtPurchaseDate.Enabled = false;
                }
            }
            else
            {
                txtPurchaseOrderNo.Enabled = true;
                BtnPurchaseEdit.Visible = false;
                BtnPurchaseSave.Visible = true;
                BtnPurchaseReset.Visible = true;
                txtPurchaseDate.Enabled = false;
            }
            PurchaseDocCount.Text =" ( " + ds.Tables[1].Rows[0]["DocumentTotalNumber"].ToString() + " )";
        }
        catch (Exception ex)
        { }
    }

    protected void BtnPurchaseEdit_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            ds = objAssetMgmt.AssetPurchaseDetailUpdate(Convert.ToInt32(AssetIdQs.Text), txtPurchaseCompanyName.Text, txtPurchaseOrderNo.Text, txtPurchaseDate.Text, Convert.ToDecimal(txtPurchasePrice.Text), txtPurchaseSuppliername.Text, txtPurchaseSupplierEmail.Text, txtPurchaseSupplierPhone.Text, txtPurchaseSupplierAddress.Text, txtPurchaseRemarks.Text, lblImageUrl.Text, BaseUserID,BaseCompanyCode);
            DisplayMessage(lblErrorAssetPurchase, ds.Tables[0].Rows[0]["MessageId"].ToString());
            FillAssetPurchaseDetail(AssetIdQs.Text);
        }
        catch (Exception ex)
        { }
    }
    protected void BtnPurchaseSave_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var ds1=new DataSet();
        var dt = new DataTable();
        var objAssetMgmt = new BL.AssetManagement();
    
        try
        {
            ds = objAssetMgmt.AssetPurchaseDetailInsert(Convert.ToInt32(AssetIdQs.Text), txtPurchaseCompanyName.Text, txtPurchaseOrderNo.Text, txtPurchaseDate.Text, Convert.ToDecimal(txtPurchasePrice.Text), txtPurchaseSuppliername.Text, txtPurchaseSupplierEmail.Text, txtPurchaseSupplierPhone.Text, txtPurchaseSupplierAddress.Text, txtPurchaseRemarks.Text, lblImageUrl.Text, BaseUserID,BaseCompanyCode);
            DisplayMessage(lblErrorAssetPurchase, ds.Tables[0].Rows[0]["MessageId"].ToString());
            FillAssetPurchaseDetail(AssetIdQs.Text);
            ds1 = objAssetMgmt.AssetLeaseDeleteAfterPurchaseInsert(Convert.ToInt32(AssetIdQs.Text));
            dt=ds1.Tables[1];
           for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                filepath = uploadfolder + dt.Rows[i]["DocumentFileName"].ToString();
                filepath = MapPath(filepath);
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }
            
        }
        catch (Exception ex)
        { }
    }
    protected void BtnPurchaseReset_Click(object sender, EventArgs e)
    {
        txtPurchaseCompanyName.Text = "";
        txtPurchaseOrderNo.Text = "";
        txtPurchaseDate.Text = "";
        txtPurchasePrice.Text = "";
        txtPurchaseSuppliername.Text = "";
        txtPurchaseSupplierEmail.Text = "";
        txtPurchaseSupplierPhone.Text = "";
        txtPurchaseSupplierAddress.Text = "";
        txtPurchaseRemarks.Text = "";

    }
    protected void ImgBtnUploadPurchase_Click(object sender, ImageClickEventArgs e)
    {
        ImgBtnUploadPurchase.Attributes.Add("OnClick", "javascript:DocumentUpload(" + AssetIdQs.Text + ",'Purchase')");
       // ImgBtnUploadPurchase.Attributes.Add("OnClick", "javascript:window.showModalDialog('../AssetManagement/AssetDocumentMaster.aspx?AssetId=" + AssetIdQs.Text + "&Category=" + "Purchase" + "', null, 'status:off;center:yes;scroll:no;dialogWidth:1000px;dialogheight:600px;help:no;');");

    }
    #endregion
    #region Function related to Asset Lease
   
    private void FillgvAssetLease(string AssetId)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetLease = new DataSet();
            var dtAssetLease = new DataTable();
            dtflag = 1;
            dsAssetLease = objAssetMgmt.AssetLeaseDetailGet(AssetId,BaseCompanyCode);
            dtAssetLease = dsAssetLease.Tables[0];
            if (dtAssetLease.Rows.Count == 0)
            {
                dtflag = 0;
                dtAssetLease.Rows.Add(dtAssetLease.NewRow());
            }
            gvAssetLease.DataSource = dtAssetLease;
            gvAssetLease.DataBind();

            if (dtflag == 0)
            {
                gvAssetLease.Rows[0].Visible = false;
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
     protected void gvAssetLease_RowDataBound(object sender, GridViewRowEventArgs e)
    {
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
            var txtLeasingFirmName = (TextBox)e.Row.FindControl("txtLeasingFirmName");
            var txtLeasingFirmPhone = (TextBox)e.Row.FindControl("txtLeasingFirmPhone");
            var txtLeasingFirmAddress = (TextBox)e.Row.FindControl("txtLeasingFirmAddress");
            var txtLeaseAmount = (TextBox)e.Row.FindControl("txtLeaseAmount");
            var txtLeaseEndDate = (TextBox)e.Row.FindControl("txtLeaseEndDate");
            var txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
            var ddlTypeOfLease = (DropDownList)e.Row.FindControl("ddlTypeOfLease");
            var hfAssetLeaseAutoId = (HiddenField)e.Row.FindControl("hfAssetLeaseAutoId");
            var ImgBtnUpload = (ImageButton)e.Row.FindControl("ImgBtnUpload");
            if (ImgBtnUpload != null)
            {
                ImgBtnUpload.Attributes.Add("OnClick", "javascript:DocumentUpload(" + hfAssetLeaseAutoId.Value + ",'Lease')");
               // ImgBtnUpload.Attributes.Add("OnClick", "javascript:window.showModalDialog('../AssetManagement/AssetDocumentMaster.aspx?AssetId=" + hfAssetLeaseAutoId.Value + "&Category=" + "Lease" + "', null, 'status:off;center:yes;scroll:no;dialogWidth:1000px;dialogheight:600px;help:no;');");
            }
            if (txtLeasingFirmName != null)
            {
                txtLeasingFirmName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtLeasingFirmName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtLeasingFirmPhone != null)
            {
                txtLeasingFirmPhone.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                txtLeasingFirmPhone.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
            }
            if (txtLeasingFirmAddress != null)
            {
                txtLeasingFirmAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtLeasingFirmAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtLeaseAmount != null)
            {
                txtLeaseAmount.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtLeaseAmount.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            }
            if (txtLeaseEndDate != null)
            {
                txtLeaseEndDate.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtLeaseEndDate.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtRemarks != null)
            {
                txtRemarks.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRemarks.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            HiddenField HFLeaseType = (HiddenField)e.Row.FindControl("HFLeaseType");
            if(ddlTypeOfLease!=null)
       ddlTypeOfLease.SelectedValue = HFLeaseType.Value;
            

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
             if (IsWriteAccess)
            {
                 var txtLeasingFirmName = (TextBox)e.Row.FindControl("txtLeasingFirmName");
            var txtLeasingFirmPhone = (TextBox)e.Row.FindControl("txtLeasingFirmPhone");
            var txtLeasingFirmAddress = (TextBox)e.Row.FindControl("txtLeasingFirmAddress");
            var txtLeaseAmount = (TextBox)e.Row.FindControl("txtLeaseAmount");
            var txtLeaseEndDate = (TextBox)e.Row.FindControl("txtLeaseEndDate");
            var txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
            var lblAssetName = (Label)e.Row.FindControl("lblAssetName");
            if (txtLeasingFirmName != null)
            {
                txtLeasingFirmName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtLeasingFirmName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtLeasingFirmPhone != null)
            {
                txtLeasingFirmPhone.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                txtLeasingFirmPhone.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
            }
            if (txtLeasingFirmAddress != null)
            {
                txtLeasingFirmAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtLeasingFirmAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtLeaseAmount != null)
            {
                txtLeaseAmount.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtLeaseAmount.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            }
            if (txtLeaseEndDate != null)
            {
                txtLeaseEndDate.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtLeaseEndDate.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtRemarks != null)
            {
                txtRemarks.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRemarks.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }

            lblAssetName.Text = txtAssetName.Text;

            }
             else
             {
                 var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                 if (lbADD != null)
                 {
                     lbADD.Visible = false;
                     gvAssetLease.ShowFooter = false;
                 }
             }
        }
        

    }
    protected void gvAssetLease_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetLeaseAutoIdNew = (HiddenField)gvAssetLease.FooterRow.FindControl("hfAssetLeaseAutoIdNew");
        var lblAssetName = (Label)gvAssetLease.FooterRow.FindControl("lblAssetName");
        var txtLeasingFirmName = (TextBox)gvAssetLease.FooterRow.FindControl("txtLeasingFirmName");
        var txtLeasingFirmEmail = (TextBox)gvAssetLease.FooterRow.FindControl("txtLeasingFirmEmail");
        var txtLeasingFirmPhone = (TextBox)gvAssetLease.FooterRow.FindControl("txtLeasingFirmPhone");
        var txtLeasingFirmAddress = (TextBox)gvAssetLease.FooterRow.FindControl("txtLeasingFirmAddress");
        var ddlTypeOfLease = (DropDownList)gvAssetLease.FooterRow.FindControl("ddlTypeOfLease");
        var txtLeaseAmount = (TextBox)gvAssetLease.FooterRow.FindControl("txtLeaseAmount");
        var txtLeaseEndDate = (TextBox)gvAssetLease.FooterRow.FindControl("txtLeaseEndDate");
        var txtLeaseStartDate = (TextBox)gvAssetLease.FooterRow.FindControl("txtLeaseStartDate");
        var txtRemarks = (TextBox)gvAssetLease.FooterRow.FindControl("txtRemarks");
        if (txtLeaseAmount.Text != "")
        { }
        else
        {
            txtLeaseAmount.Text = "0";
        }
        

        if (e.CommandName == "AddNew")
        {
            try
            {
                if ((txtLeaseEndDate.Text != "") && (txtLeaseStartDate.Text != ""))
                {
                    if (DateTime.Parse(txtLeaseStartDate.Text) > DateTime.Parse(txtLeaseEndDate.Text))
                    {
                        lblAssetLease.Text = Resources.Resource.FromDateCannotGrtToDate;
                    }
                    else
                    {
                        ds = objAssetMgmt.AssetLeaseInsert(Convert.ToInt32(hfAssetLeaseAutoIdNew.Value), AssetIdQs.Text, txtLeasingFirmName.Text, txtLeasingFirmEmail.Text, txtLeasingFirmPhone.Text, txtLeasingFirmAddress.Text, ddlTypeOfLease.Text, txtLeaseStartDate.Text, txtLeaseEndDate.Text, Convert.ToDecimal(txtLeaseAmount.Text), txtRemarks.Text, BaseUserID,BaseCompanyCode);
                        DisplayMessage(lblAssetLease, ds.Tables[0].Rows[0]["MessageId"].ToString());
                        FillgvAssetLease(AssetIdQs.Text);

                    }
                }
                else
                {
                    ds = objAssetMgmt.AssetLeaseInsert(Convert.ToInt32(hfAssetLeaseAutoIdNew.Value), AssetIdQs.Text, txtLeasingFirmName.Text, txtLeasingFirmEmail.Text, txtLeasingFirmPhone.Text, txtLeasingFirmAddress.Text, ddlTypeOfLease.Text, txtLeaseStartDate.Text, txtLeaseEndDate.Text, Convert.ToDecimal(txtLeaseAmount.Text), txtRemarks.Text, BaseUserID,BaseCompanyCode);
                    DisplayMessage(lblAssetLease, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    FillgvAssetLease(AssetIdQs.Text);

                }
            }
            catch (Exception ex)
            { }

        }
        if (e.CommandName == "Reset")
        {
            txtLeasingFirmName.Text = "";
            txtLeasingFirmPhone.Text = "";
            txtLeasingFirmEmail.Text = "";
            txtLeasingFirmAddress.Text = "";
            txtRemarks.Text = "";
            txtLeaseEndDate.Text = "";
            txtLeaseAmount.Text = "";
        }
    }
    protected void gvAssetLease_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var ds1 = new DataSet();
        var dt = new DataTable();
        var objAssetMgmt = new BL.AssetManagement();
        HiddenField ID = (HiddenField)gvAssetLease.Rows[e.RowIndex].FindControl("hfAssetLeaseAutoId");
        
        var objAssetMgmt1 = new BL.AssetManagement();
        ds1 = objAssetMgmt1.GetAssetDocumentsDetail(Convert.ToInt32(ID.Value), "Lease",BaseCompanyCode);
        dt = ds1.Tables[0];
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            filepath = uploadfolder + dt.Rows[i]["DocumentFileName"].ToString();
            filepath = MapPath(filepath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        ds = objAssetMgmt.AssetLeaseDelete(Convert.ToInt32(ID.Value), "Lease",BaseCompanyCode);
        DisplayMessage(lblAssetLease, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvAssetLease.EditIndex = -1;
       
        FillgvAssetLease(AssetIdQs.Text);
    }
    protected void gvAssetLease_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetLease.EditIndex = e.NewEditIndex;
        FillgvAssetLease(AssetIdQs.Text);
    }
    protected void gvAssetLease_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetLease.PageIndex = e.NewPageIndex;
        gvAssetLease.EditIndex = -1;
        FillgvAssetLease(AssetIdQs.Text);
    }
    protected void gvAssetLease_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetLeaseAutoId = (HiddenField)gvAssetLease.Rows[e.RowIndex].FindControl("hfAssetLeaseAutoId");
        var lblAssetName = (Label)gvAssetLease.Rows[e.RowIndex].FindControl("lblAssetName");
        var txtLeasingFirmName = (TextBox)gvAssetLease.Rows[e.RowIndex].FindControl("txtLeasingFirmName");
        var txtLeasingFirmEmail = (TextBox)gvAssetLease.Rows[e.RowIndex].FindControl("txtLeasingFirmEmail");
        var txtLeasingFirmPhone = (TextBox)gvAssetLease.Rows[e.RowIndex].FindControl("txtLeasingFirmPhone");
        var txtLeasingFirmAddress = (TextBox)gvAssetLease.Rows[e.RowIndex].FindControl("txtLeasingFirmAddress");
        var ddlTypeOfLease = (DropDownList)gvAssetLease.Rows[e.RowIndex].FindControl("ddlTypeOfLease");
        var txtLeaseAmount = (TextBox)gvAssetLease.Rows[e.RowIndex].FindControl("txtLeaseAmount");
        var txtLeaseEndDate = (TextBox)gvAssetLease.Rows[e.RowIndex].FindControl("txtLeaseEndDate");
        var txtLeaseStartDate = (TextBox)gvAssetLease.Rows[e.RowIndex].FindControl("txtLeaseStartDate");
        var txtRemarks = (TextBox)gvAssetLease.Rows[e.RowIndex].FindControl("txtRemarks");
        if (txtLeaseAmount.Text != "")
        { }
        else
        {
            txtLeaseAmount.Text = "0";
        }
       
            
        
            try
            {
                if ((txtLeaseEndDate.Text != "") && (txtLeaseStartDate.Text != ""))
                {
                    if (DateTime.Parse(txtLeaseStartDate.Text) > DateTime.Parse(txtLeaseEndDate.Text))
                    {
                        lblAssetLease.Text = Resources.Resource.FromDateCannotGrtToDate;
                    }
                    else
                    {
                        ds = objAssetMgmt.AssetLeaseUpdate(Convert.ToInt32(hfAssetLeaseAutoId.Value), AssetIdQs.Text, txtLeasingFirmName.Text, txtLeasingFirmEmail.Text, txtLeasingFirmPhone.Text, txtLeasingFirmAddress.Text, ddlTypeOfLease.Text, txtLeaseStartDate.Text, txtLeaseEndDate.Text, Convert.ToDecimal(txtLeaseAmount.Text), txtRemarks.Text, BaseUserID,BaseCompanyCode);
                        DisplayMessage(lblAssetLease, ds.Tables[0].Rows[0]["MessageId"].ToString());
                        gvAssetLease.EditIndex = -1;
                        FillgvAssetLease(AssetIdQs.Text);
                    }
                }
                else
                {
                    ds = objAssetMgmt.AssetLeaseUpdate(Convert.ToInt32(hfAssetLeaseAutoId.Value), AssetIdQs.Text, txtLeasingFirmName.Text, txtLeasingFirmEmail.Text, txtLeasingFirmPhone.Text, txtLeasingFirmAddress.Text, ddlTypeOfLease.Text, txtLeaseStartDate.Text, txtLeaseEndDate.Text, Convert.ToDecimal(txtLeaseAmount.Text), txtRemarks.Text, BaseUserID,BaseCompanyCode);
                    DisplayMessage(lblAssetLease, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    gvAssetLease.EditIndex = -1;
                    FillgvAssetLease(AssetIdQs.Text);
                }
            }
            catch (Exception ex)
            { }
    }
    protected void gvAssetLease_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetLease.EditIndex = -1;
        FillgvAssetLease(AssetIdQs.Text);
    }
    #endregion
    #region Function related to Asset Insurance
    private void FillgvAssetInsurance(string AssetId)
    {
        BL.AssetManagement objblMasterManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        DataTable dtAsset = new DataTable();
        ds = objblMasterManagement.AssetInsuranceGetRecords(AssetId,BaseCompanyCode);
        dtAsset = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtAsset.Rows.Count > 0)
        {
            gvAssetInsurance.DataSource = dtAsset;
            gvAssetInsurance.DataBind();
        }
        else
        {
            dtAsset = ds.Tables[0];
            dtAsset.Rows.Add(dtAsset.NewRow());
            gvAssetInsurance.DataSource = dtAsset;
            gvAssetInsurance.DataBind();
            gvAssetInsurance.Rows[0].Visible = false;
          lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    protected void gvAssetInsurance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Label lblAssetNameInsurance = (Label)gvAssetInsurance.FooterRow.FindControl("lblAssetNameInsurance");
        TextBox txtNewPolicyNo = (TextBox)gvAssetInsurance.FooterRow.FindControl("txtNewPolicyNo");
        TextBox txtNewSumInsured = (TextBox)gvAssetInsurance.FooterRow.FindControl("txtNewSumInsured");
        TextBox txtNewInsuranceCompanyName = (TextBox)gvAssetInsurance.FooterRow.FindControl("txtNewInsuranceCompanyName");
        TextBox txtNewEmail = (TextBox)gvAssetInsurance.FooterRow.FindControl("txtNewEmail");
        TextBox txtNewPhoneNo = (TextBox)gvAssetInsurance.FooterRow.FindControl("txtNewPhoneNo");
        TextBox txtInsurancePeriodFrom = (TextBox)gvAssetInsurance.FooterRow.FindControl("txtInsurancePeriodFrom");
        TextBox txtInsurancePeriodTo = (TextBox)gvAssetInsurance.FooterRow.FindControl("txtInsurancePeriodTo");
        
        BL.AssetManagement objblMasterManagement = new BL.AssetManagement();
        if (txtNewSumInsured.Text != "")
        {

        }
        else
        {
            txtNewSumInsured.Text = "0";
        }


        if (e.CommandName.Equals("AddNew"))
        {
            
            try
            { 
               
                if (txtPurchaseDate.Text != "" )
                {
                    if (DateTime.Parse(txtPurchaseDate.Text) > DateTime.Parse(txtInsurancePeriodFrom.Text))
                    {
                        lblErrorMsg.Text = Resources.Resource.StartDateCntlessthanPurchaseDate;
                    }
                    else
                    {
                        if ((txtInsurancePeriodTo.Text != "") && (txtInsurancePeriodFrom.Text != ""))
                        {
                            if (DateTime.Parse(txtInsurancePeriodFrom.Text) > DateTime.Parse(txtInsurancePeriodTo.Text))
                            {
                                lblErrorMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                            }
                            else
                            {
                                

                                ds = objblMasterManagement.AssetInsuranceAddNew(AssetIdQs.Text, txtNewPolicyNo.Text, Convert.ToDecimal(txtNewSumInsured.Text), txtNewInsuranceCompanyName.Text, txtNewEmail.Text, txtNewPhoneNo.Text, txtInsurancePeriodFrom.Text, txtInsurancePeriodTo.Text, BaseUserID,BaseCompanyCode);

                                FillgvAssetInsurance(AssetIdQs.Text);
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }
                        }
                    }

                }
                else
                {
                    if ((txtInsurancePeriodTo.Text != "") && (txtInsurancePeriodFrom.Text != ""))
                    {
                        if (DateTime.Parse(txtInsurancePeriodFrom.Text) > DateTime.Parse(txtInsurancePeriodTo.Text))
                        {
                            lblErrorMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                        }
                        else
                        {
                        

                            ds = objblMasterManagement.AssetInsuranceAddNew(AssetIdQs.Text, txtNewPolicyNo.Text, Convert.ToDecimal(txtNewSumInsured.Text), txtNewInsuranceCompanyName.Text, txtNewEmail.Text, txtNewPhoneNo.Text, txtInsurancePeriodFrom.Text, txtInsurancePeriodTo.Text, BaseUserID,BaseCompanyCode);

                            FillgvAssetInsurance(AssetIdQs.Text);
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            if (e.CommandName.Equals("Reset"))
            {

                txtNewPolicyNo.Text = "";
                txtNewSumInsured.Text = "";
                txtNewInsuranceCompanyName.Text = "";
                txtNewEmail.Text = "";
                txtNewPhoneNo.Text = "";
                txtInsurancePeriodFrom.Text = "";
                txtInsurancePeriodTo.Text = "";
                lblErrorMsg.Text = "";
            }

        }

    }

    protected void gvAssetInsurance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;

      
            TextBox txtInsurancePeriodFrom = (TextBox)e.Row.FindControl("txtInsurancePeriodFrom");
            if (txtInsurancePeriodFrom != null)
            {
                txtInsurancePeriodFrom.Attributes.Add("readonly", "readonly");
            }
            TextBox txtInsurancePeriodTo = (TextBox)e.Row.FindControl("txtInsurancePeriodTo");
            if (txtInsurancePeriodTo != null)
            {
                txtInsurancePeriodTo.Attributes.Add("readonly", "readonly");
            }
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!IsDeleteAccess)
            {
               

                var IBDeleteAsset = (ImageButton)e.Row.FindControl("IBDeleteAsset");
                if (IBDeleteAsset != null)
                {
                    IBDeleteAsset.Visible = false;
                }

            }
            if (!IsModifyAccess)
            {
                var IBEditAsset = (ImageButton)e.Row.FindControl("IBEditAsset");
                if (IBEditAsset != null)
                    IBEditAsset.Visible = false;

            }
            var hfAssetInsuranceAutoId = (HiddenField)e.Row.FindControl("hfAssetInsuranceAutoId");
            var ImgBtnUploadInsurance = (ImageButton)e.Row.FindControl("ImgBtnUploadInsurance");
            if (ImgBtnUploadInsurance != null)
            {
                ImgBtnUploadInsurance.Attributes.Add("OnClick", "javascript:DocumentUpload(" + hfAssetInsuranceAutoId.Value + ",'Insurance')");
               
               // ImgBtnUploadInsurance.Attributes.Add("OnClick", "javascript:window.Open('../AssetManagement/AssetDocumentMaster.aspx?AssetId=" + hfAssetInsuranceAutoId.Value + "&Category=" + "Insurance" + "', null, 'status:off;center:yes;scroll:no;dialogWidth:1000px;dialogheight:600px;help:no;');");
            }

            var txtSumInsured = (TextBox)e.Row.FindControl("txtSumInsured");

            if (txtSumInsured != null)
            {

                txtSumInsured.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

                txtSumInsured.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

            }
            var txtInsuranceCompanyName = (TextBox)e.Row.FindControl("txtInsuranceCompanyName");

            if (txtInsuranceCompanyName != null)
            {

                txtInsuranceCompanyName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                txtInsuranceCompanyName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
           
            var txtPhoneNo = (TextBox)e.Row.FindControl("txtPhoneNo");

            if (txtPhoneNo != null)
            {

                txtPhoneNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");

                txtPhoneNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");

            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {


                var txtNewPolicyNo = (TextBox)e.Row.FindControl("txtNewPolicyNo");

                if (txtNewPolicyNo != null)
                {

                    txtNewPolicyNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                    txtNewPolicyNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                }
                var txtNewSumInsured = (TextBox)e.Row.FindControl("txtNewSumInsured");

                if (txtNewSumInsured != null)
                {

                    txtNewSumInsured.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

                    txtNewSumInsured.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

                }
                var txtNewInsuranceCompanyName = (TextBox)e.Row.FindControl("txtNewInsuranceCompanyName");

                if (txtNewInsuranceCompanyName != null)
                {

                    txtNewInsuranceCompanyName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                    txtNewInsuranceCompanyName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                }
               
                var txtNewPhoneNo = (TextBox)e.Row.FindControl("txtNewPhoneNo");

                if (txtNewPhoneNo != null)
                {

                    txtNewPhoneNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");

                    txtNewPhoneNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");

                }


                var lblAssetNameInsurance = (Label)e.Row.FindControl("lblAssetNameInsurance");
                lblAssetNameInsurance.Text = txtAssetName.Text;
            }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Visible = false;
                    gvAssetInsurance.ShowFooter = false;
                }
            }

        }
    }

    protected void gvAssetInsurance_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetInsurance.EditIndex = e.NewEditIndex;
        FillgvAssetInsurance(AssetIdQs.Text);
    }
  
    protected void gvAssetInsurance_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objblMastermanagement = new BL.AssetManagement();
        HiddenField hfAssetInsuranceAutoId = (HiddenField)gvAssetInsurance.Rows[e.RowIndex].FindControl("hfAssetInsuranceAutoId");
        TextBox txtSumInsured = (TextBox)gvAssetInsurance.Rows[e.RowIndex].FindControl("txtSumInsured");
        TextBox txtInsuranceCompanyName = (TextBox)gvAssetInsurance.Rows[e.RowIndex].FindControl("txtInsuranceCompanyName");
        TextBox txtEmail = (TextBox)gvAssetInsurance.Rows[e.RowIndex].FindControl("txtEmail");
        TextBox txtPhoneNo = (TextBox)gvAssetInsurance.Rows[e.RowIndex].FindControl("txtPhoneNo");
        TextBox txtInsurancePeriodFrom = (TextBox)gvAssetInsurance.Rows[e.RowIndex].FindControl("txtInsurancePeriodFrom");
        TextBox txtInsurancePeriodTo = (TextBox)gvAssetInsurance.Rows[e.RowIndex].FindControl("txtInsurancePeriodTo");
        if (txtSumInsured.Text != "")
        {

        }
        else
        {
            txtSumInsured.Text = "0";
        }

         
        if (txtPurchaseDate.Text != "")
        {
            if (DateTime.Parse(txtPurchaseDate.Text) > DateTime.Parse(txtInsurancePeriodFrom.Text))
            {
                lblErrorMsg.Text = Resources.Resource.StartDateCntlessthanPurchaseDate;
            }
            else
            {
                if ((txtInsurancePeriodTo.Text != "") && (txtInsurancePeriodFrom.Text != ""))
                {
                    if (DateTime.Parse(txtInsurancePeriodFrom.Text) > DateTime.Parse(txtInsurancePeriodTo.Text))
                    {
                        lblErrorMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                    }
                    else
                    {
                        


                        ds = objblMastermanagement.AssetInsuranceUpdate(Convert.ToInt32(hfAssetInsuranceAutoId.Value), Convert.ToDecimal(txtSumInsured.Text), txtInsuranceCompanyName.Text, txtEmail.Text, txtPhoneNo.Text, txtInsurancePeriodFrom.Text, txtInsurancePeriodTo.Text, BaseUserID,BaseCompanyCode);
                        gvAssetInsurance.EditIndex = -1;
                        FillgvAssetInsurance(AssetIdQs.Text);
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                    }
                }
                else
                {

                    ds = objblMastermanagement.AssetInsuranceUpdate(Convert.ToInt32(hfAssetInsuranceAutoId.Value), Convert.ToDecimal(txtSumInsured.Text), txtInsuranceCompanyName.Text, txtEmail.Text, txtPhoneNo.Text, txtInsurancePeriodFrom.Text, txtInsurancePeriodTo.Text, BaseUserID,BaseCompanyCode);
                    gvAssetInsurance.EditIndex = -1;
                    FillgvAssetInsurance(AssetIdQs.Text);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                }
            }
        }
        else
        {
            if ((txtInsurancePeriodTo.Text != "") && (txtInsurancePeriodFrom.Text != ""))
            {
                if (DateTime.Parse(txtInsurancePeriodFrom.Text) > DateTime.Parse(txtInsurancePeriodTo.Text))
                {
                    lblErrorMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                }
                else
                {
                   


                    ds = objblMastermanagement.AssetInsuranceUpdate(Convert.ToInt32(hfAssetInsuranceAutoId.Value), Convert.ToDecimal(txtSumInsured.Text), txtInsuranceCompanyName.Text, txtEmail.Text, txtPhoneNo.Text, txtInsurancePeriodFrom.Text, txtInsurancePeriodTo.Text, BaseUserID,BaseCompanyCode);
                    gvAssetInsurance.EditIndex = -1;
                    FillgvAssetInsurance(AssetIdQs.Text);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                }
            }
            else
            {

                ds = objblMastermanagement.AssetInsuranceUpdate(Convert.ToInt32(hfAssetInsuranceAutoId.Value), Convert.ToDecimal(txtSumInsured.Text), txtInsuranceCompanyName.Text, txtEmail.Text, txtPhoneNo.Text, txtInsurancePeriodFrom.Text, txtInsurancePeriodTo.Text, BaseUserID,BaseCompanyCode);
                gvAssetInsurance.EditIndex = -1;
                FillgvAssetInsurance(AssetIdQs.Text);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }
        }
    }

  
    protected void gvAssetInsurance_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
      
        BL.AssetManagement objblMasterManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        HiddenField hfAssetInsuranceAutoId = (HiddenField)gvAssetInsurance.Rows[e.RowIndex].FindControl("hfAssetInsuranceAutoId");
        var ds1 = new DataSet();
        var dt = new DataTable();
        var objAssetMgmt1 = new BL.AssetManagement();
        ds1 = objAssetMgmt1.GetAssetDocumentsDetail(Convert.ToInt32(hfAssetInsuranceAutoId.Value), "Insurance",BaseCompanyCode);
        dt = ds1.Tables[0];
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            filepath = uploadfolder + dt.Rows[i]["DocumentFileName"].ToString();
            filepath = MapPath(filepath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
        ds = objblMasterManagement.AssetInsuranceDelete(Convert.ToInt32(hfAssetInsuranceAutoId.Value), "Insurance",BaseCompanyCode);

        FillgvAssetInsurance(AssetIdQs.Text);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    
    protected void gvAssetInsurance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetInsurance.PageIndex = e.NewPageIndex;
        gvAssetInsurance.EditIndex = -1;
        FillgvAssetInsurance(AssetIdQs.Text);
    }

    protected void gvAssetInsurance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetInsurance.EditIndex = -1;
        FillgvAssetInsurance(AssetIdQs.Text);
    }
    #endregion
    #region Function related to Asset Gurantee
    private void FillgvAssetGurantee(string AssetId)
    {
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        DataTable dtAsset = new DataTable();
        ds = objblAssetManagement.AssetGuranteeGetRecords(AssetId,BaseCompanyCode);
        dtAsset = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtAsset.Rows.Count > 0)
        {
            gvAssetGurantee.DataSource = dtAsset;
            gvAssetGurantee.DataBind();
        }
        else
        {
            dtAsset = ds.Tables[0];
            dtAsset.Rows.Add(dtAsset.NewRow());
            gvAssetGurantee.DataSource = dtAsset;
            gvAssetGurantee.DataBind();
            gvAssetGurantee.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    protected void gvAssetGurantee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Label lblAssetNameGurantee = (Label)gvAssetGurantee.FooterRow.FindControl("lblAssetNameGurantee");
        TextBox txtGuranteeExpDate = (TextBox)gvAssetGurantee.FooterRow.FindControl("txtGuranteeExpDate");
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();


        if (e.CommandName.Equals("AddNew"))
        {
            if (txtPurchaseDate.Text != "")
            {
                if (DateTime.Parse(txtPurchaseDate.Text) > DateTime.Parse(txtGuranteeExpDate.Text))
                {
                    LabelGurantee.Text = Resources.Resource.StartDateCntlessthanPurchaseDate;
                }
                else
                {

                    ds = objblAssetManagement.AssetGuranteeAddNew(AssetIdQs.Text, txtGuranteeExpDate.Text, BaseUserID,BaseCompanyCode);

                    FillgvAssetGurantee(AssetIdQs.Text);
                    DisplayMessage(LabelGurantee, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {

                ds = objblAssetManagement.AssetGuranteeAddNew(AssetIdQs.Text, txtGuranteeExpDate.Text, BaseUserID,BaseCompanyCode);

                FillgvAssetGurantee(AssetIdQs.Text);
                DisplayMessage(LabelGurantee, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }

        }

            if (e.CommandName.Equals("Reset"))
            {

                txtGuranteeExpDate.Text = "";
                LabelGurantee.Text = "";
            }

        
    }
    protected void gvAssetGurantee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!IsDeleteAccess)
            {
                var IBDeleteAsset = (ImageButton)e.Row.FindControl("IBDeleteAsset");
                if (IBDeleteAsset != null)
                {
                    IBDeleteAsset.Visible = false;
                }

            }
            if (!IsModifyAccess)
            {
                var IBEditAsset = (ImageButton)e.Row.FindControl("IBEditAsset");
                if (IBEditAsset != null)
                    IBEditAsset.Visible = false;

            }
            var hfAssetGuarantyAutoId = (HiddenField)e.Row.FindControl("hfAssetGuarantyAutoId");
            var ImgBtnUploadGurantee = (ImageButton)e.Row.FindControl("ImgBtnUploadGurantee");
            if (ImgBtnUploadGurantee != null)
            {
                ImgBtnUploadGurantee.Attributes.Add("OnClick", "javascript:DocumentUpload(" + hfAssetGuarantyAutoId.Value + ",'Gurantee')");
                }



            try
            {
                var lblAssetNameGurantee = (Label)e.Row.FindControl("lblAssetNameGurantee");
                lblAssetNameGurantee.Text = txtAssetName.Text;
            }
            catch (Exception ex)
            { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            if (IsWriteAccess)
            { }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Visible = false;
                    gvAssetGurantee.ShowFooter = false;
                }
            }

            var lblAssetNameGurantee = (Label)e.Row.FindControl("lblAssetNameGurantee");
            lblAssetNameGurantee.Text = txtAssetName.Text;
        }

    }
    protected void gvAssetGurantee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetGurantee.EditIndex = e.NewEditIndex;
        FillgvAssetGurantee(AssetIdQs.Text);
    }
    protected void gvAssetGurantee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objblAssetmanagement = new BL.AssetManagement();
        HiddenField hfAssetGuarantyAutoId = (HiddenField)gvAssetGurantee.Rows[e.RowIndex].FindControl("hfAssetGuarantyAutoId");
        TextBox txtGuranteeExpDate = (TextBox)gvAssetGurantee.Rows[e.RowIndex].FindControl("txtGuranteeExpDate");
        if (txtPurchaseDate.Text != "")
        {
            if (DateTime.Parse(txtPurchaseDate.Text) > DateTime.Parse(txtGuranteeExpDate.Text))
            {
                LabelGurantee.Text = Resources.Resource.StartDateCntlessthanPurchaseDate;
            }
            else
            {
                ds = objblAssetmanagement.AssetGuranteeUpdate(Convert.ToInt32(hfAssetGuarantyAutoId.Value), txtGuranteeExpDate.Text, BaseUserID,BaseCompanyCode);
                gvAssetGurantee.EditIndex = -1;
                FillgvAssetGurantee(AssetIdQs.Text);
                DisplayMessage(LabelGurantee, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        else
        {
            ds = objblAssetmanagement.AssetGuranteeUpdate(Convert.ToInt32(hfAssetGuarantyAutoId.Value), txtGuranteeExpDate.Text, BaseUserID,BaseCompanyCode);
            gvAssetGurantee.EditIndex = -1;
            FillgvAssetGurantee(AssetIdQs.Text);
            DisplayMessage(LabelGurantee, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    protected void gvAssetGurantee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        HiddenField hfAssetGuarantyAutoId = (HiddenField)gvAssetGurantee.Rows[e.RowIndex].FindControl("hfAssetGuarantyAutoId");
        var ds1 = new DataSet();
        var dt = new DataTable();
        var objAssetMgmt1 = new BL.AssetManagement();
        ds1 = objAssetMgmt1.GetAssetDocumentsDetail(Convert.ToInt32(hfAssetGuarantyAutoId.Value), "Gurantee",BaseCompanyCode);
        dt = ds1.Tables[0];
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            filepath = uploadfolder + dt.Rows[i]["DocumentFileName"].ToString();
            filepath = MapPath(filepath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
        ds = objblAssetManagement.AssetGuranteeDelete(Convert.ToInt32(hfAssetGuarantyAutoId.Value), "Gurantee",BaseCompanyCode);

        FillgvAssetGurantee(AssetIdQs.Text);
        DisplayMessage(LabelGurantee, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    protected void gvAssetGurantee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetGurantee.PageIndex = e.NewPageIndex;
        gvAssetGurantee.EditIndex = -1;
        FillgvAssetGurantee(AssetIdQs.Text);
    }

    protected void gvAssetGurantee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetGurantee.EditIndex = -1;
        FillgvAssetGurantee(AssetIdQs.Text);
    }
    #endregion
    #region Function related to Asset Warranty
    private void FillgvAssetWarrenty(string AssetId)
    {
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        DataTable dtAsset = new DataTable();
        ds = objblAssetManagement.AssetWarrentyGetRecords(AssetId,BaseCompanyCode);
        dtAsset = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtAsset.Rows.Count > 0)
        {
            gvAssetWarrenty.DataSource = dtAsset;
            gvAssetWarrenty.DataBind();
        }
        else
        {
            dtAsset = ds.Tables[0];
            dtAsset.Rows.Add(dtAsset.NewRow());
            gvAssetWarrenty.DataSource = dtAsset;
            gvAssetWarrenty.DataBind();
            gvAssetWarrenty.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    protected void gvAssetWarrenty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Label lblAssetNameWarrenty = (Label)gvAssetWarrenty.FooterRow.FindControl("lblAssetNameWarrenty");
        TextBox txtWarrentyExpDate = (TextBox)gvAssetWarrenty.FooterRow.FindControl("txtWarrentyExpDate");
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();


        if (e.CommandName.Equals("AddNew"))
        {

           
            if (txtPurchaseDate.Text != "")
            {
                if (DateTime.Parse(txtPurchaseDate.Text) > DateTime.Parse(txtWarrentyExpDate.Text))
                {
                    LabelWarrenty.Text = Resources.Resource.StartDateCntlessthanPurchaseDate;
                }
                else
                {
                    ds = objblAssetManagement.AssetWarrentyAddNew(AssetIdQs.Text, txtWarrentyExpDate.Text, BaseUserID,BaseCompanyCode);
                    FillgvAssetWarrenty(AssetIdQs.Text);
                    DisplayMessage(LabelWarrenty, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
                ds = objblAssetManagement.AssetWarrentyAddNew(AssetIdQs.Text, txtWarrentyExpDate.Text, BaseUserID,BaseCompanyCode);
                FillgvAssetWarrenty(AssetIdQs.Text);
                DisplayMessage(LabelWarrenty, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }



        if (e.CommandName.Equals("Reset"))
        {

            txtWarrentyExpDate.Text = "";
            LabelWarrenty.Text = "";
        }

    }
    protected void gvAssetWarrenty_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!IsDeleteAccess)
            {
                var IBDeleteAsset = (ImageButton)e.Row.FindControl("IBDeleteAsset");
                if (IBDeleteAsset != null)
                {
                    IBDeleteAsset.Visible = false;
                }

            }
            if (!IsModifyAccess)
            {
                var IBEditAsset = (ImageButton)e.Row.FindControl("IBEditAsset");
                if (IBEditAsset != null)
                    IBEditAsset.Visible = false;

            }
            var hfAssetWarrentyAutoId = (HiddenField)e.Row.FindControl("hfAssetWarrentyAutoId");
            var ImgBtnUploadWarranty = (ImageButton)e.Row.FindControl("ImgBtnUploadWarranty");
            if (ImgBtnUploadWarranty != null)
            {
                ImgBtnUploadWarranty.Attributes.Add("OnClick", "javascript:DocumentUpload(" + hfAssetWarrentyAutoId.Value + ",'Warranty')");
                 }


            try
            {
                var lblAssetNameWarrenty = (Label)e.Row.FindControl("lblAssetNameWarrenty");
                lblAssetNameWarrenty.Text = txtAssetName.Text;
            }
            catch (Exception ex)
            { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            { }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Visible = false;
                    gvAssetWarrenty.ShowFooter = false;
                }
            }
            var lblAssetNameWarrenty = (Label)e.Row.FindControl("lblAssetNameWarrenty");
            lblAssetNameWarrenty.Text = txtAssetName.Text;
        }

    }
    protected void gvAssetWarrenty_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetWarrenty.EditIndex = e.NewEditIndex;
        FillgvAssetWarrenty(AssetIdQs.Text);
    }
    protected void gvAssetWarrenty_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objblAssetmanagement = new BL.AssetManagement();
        HiddenField hfAssetWarrentyAutoId = (HiddenField)gvAssetWarrenty.Rows[e.RowIndex].FindControl("hfAssetWarrentyAutoId");
        TextBox txtWarrentyExpDate = (TextBox)gvAssetWarrenty.Rows[e.RowIndex].FindControl("txtWarrentyExpDate");
        if (txtPurchaseDate.Text != "")
        {
            if (DateTime.Parse(txtPurchaseDate.Text) > DateTime.Parse(txtWarrentyExpDate.Text))
            {
                LabelWarrenty.Text = Resources.Resource.StartDateCntlessthanPurchaseDate;
            }
            else
            {
                ds = objblAssetmanagement.AssetWarrentyUpdate(Convert.ToInt32(hfAssetWarrentyAutoId.Value), txtWarrentyExpDate.Text, BaseUserID,BaseCompanyCode);
                gvAssetWarrenty.EditIndex = -1;
                FillgvAssetWarrenty(AssetIdQs.Text);
                DisplayMessage(LabelWarrenty, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        else
        {
            ds = objblAssetmanagement.AssetWarrentyUpdate(Convert.ToInt32(hfAssetWarrentyAutoId.Value), txtWarrentyExpDate.Text, BaseUserID,BaseCompanyCode);
            gvAssetWarrenty.EditIndex = -1;
            FillgvAssetWarrenty(AssetIdQs.Text);
            DisplayMessage(LabelWarrenty, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }

    }
    protected void gvAssetWarrenty_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        HiddenField hfAssetWarrentyAutoId = (HiddenField)gvAssetWarrenty.Rows[e.RowIndex].FindControl("hfAssetWarrentyAutoId");
        var ds1 = new DataSet();
        var dt = new DataTable();
        var objAssetMgmt1 = new BL.AssetManagement();
        ds1 = objAssetMgmt1.GetAssetDocumentsDetail(Convert.ToInt32(hfAssetWarrentyAutoId.Value), "Warranty",BaseCompanyCode);
        dt = ds1.Tables[0];
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            filepath = uploadfolder + dt.Rows[i]["DocumentFileName"].ToString();
            filepath = MapPath(filepath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
        ds = objblAssetManagement.AssetWarrentyDelete(Convert.ToInt32(hfAssetWarrentyAutoId.Value), "Warranty",BaseCompanyCode);

        FillgvAssetWarrenty(AssetIdQs.Text);
        DisplayMessage(LabelWarrenty, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
       protected void gvAssetWarrenty_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetWarrenty.PageIndex = e.NewPageIndex;
        gvAssetWarrenty.EditIndex = -1;
        FillgvAssetWarrenty(AssetIdQs.Text);
    }

    protected void gvAssetWarrenty_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetWarrenty.EditIndex = -1;
        FillgvAssetWarrenty(AssetIdQs.Text);
    }
    #endregion
    #region Function related to Asset Note
    private void FillgvAssetNote(string AssetId)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetNote = new DataSet();
            var dtAssetNote = new DataTable();
            dtflag1 = 1;
            dsAssetNote = objAssetMgmt.AssetNoteDetailGet(AssetId,BaseCompanyCode);
            dtAssetNote = dsAssetNote.Tables[0];
            if (dtAssetNote.Rows.Count == 0)
            {
                dtflag1 = 0;
                dtAssetNote.Rows.Add(dtAssetNote.NewRow());
            }
            gvAssetNote.DataSource = dtAssetNote;
            gvAssetNote.DataBind();

            if (dtflag1 == 0)
            {
                gvAssetNote.Rows[0].Visible = false;
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
    protected void gvAssetNote_RowDataBound(object sender, GridViewRowEventArgs e)
    {
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
            var txtAssetNote = (TextBox)e.Row.FindControl("txtAssetNote");
            var txtAssetNoteWhom = (TextBox)e.Row.FindControl("txtAssetNoteWhom");
            var ddlAssetNoteType = (DropDownList)e.Row.FindControl("ddlAssetNoteType");
            if (txtAssetNote != null)
            {
                txtAssetNote.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAssetNote.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtAssetNoteWhom != null)
            {
                txtAssetNoteWhom.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAssetNoteWhom.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }

            HiddenField hfNoteType = (HiddenField)e.Row.FindControl("hfNoteType");
            if (ddlAssetNoteType != null)
                ddlAssetNoteType.SelectedValue = hfNoteType.Value;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {
                var txtAssetNote = (TextBox)e.Row.FindControl("txtAssetNote");
                var txtAssetNoteWhom = (TextBox)e.Row.FindControl("txtAssetNoteWhom");

                if (txtAssetNote != null)
                {
                    txtAssetNote.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtAssetNote.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtAssetNoteWhom != null)
                {
                    txtAssetNoteWhom.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtAssetNoteWhom.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
            }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Visible = false;
                    gvAssetNote.ShowFooter = false;
                }
            }
        }
    }
    protected void gvAssetNote_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        // var hfAssetLeaseAutoIdNew = (HiddenField)gvAssetLease.FooterRow.FindControl("hfAssetLeaseAutoIdNew");
        var ddlAssetNoteType = (DropDownList)gvAssetNote.FooterRow.FindControl("ddlAssetNoteType");
        var txtAssetNoteWhom = (TextBox)gvAssetNote.FooterRow.FindControl("txtAssetNoteWhom");
        var txtAssetNote = (TextBox)gvAssetNote.FooterRow.FindControl("txtAssetNote");
        if (e.CommandName == "AddNew")
        {
            try
            {
                ds = objAssetMgmt.AssetNoteInsert(AssetIdQs.Text, txtAssetNoteWhom.Text, ddlAssetNoteType.SelectedValue, txtAssetNote.Text, BaseUserID,BaseCompanyCode);
                DisplayMessage(lblAssetNoteMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                FillgvAssetNote(AssetIdQs.Text);
            }
            catch (Exception ex)
            { }
        }
        if (e.CommandName == "Reset")
        {
            txtAssetNote.Text = "";
            txtAssetNoteWhom.Text = "";
        }
    }
    protected void gvAssetNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        HiddenField ID = (HiddenField)gvAssetNote.Rows[e.RowIndex].FindControl("hfAssetNoteAutoId");
        try
        {
            ds = objAssetMgmt.AssetNoteDelete(ID.Value,BaseCompanyCode);
            DisplayMessage(lblAssetNoteMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
            gvAssetNote.EditIndex = -1;

            FillgvAssetNote(AssetIdQs.Text);
        }
        catch (Exception ex)
        { }
    }
    protected void gvAssetNote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetNote.EditIndex = e.NewEditIndex;
        FillgvAssetNote(AssetIdQs.Text);
    }
    protected void gvAssetNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetNote.PageIndex = e.NewPageIndex;
        gvAssetNote.EditIndex = -1;
        FillgvAssetNote(AssetIdQs.Text);
    }
    protected void gvAssetNote_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetNote.EditIndex = -1;
        FillgvAssetNote(AssetIdQs.Text);
    }
    protected void gvAssetNote_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetNoteAutoId = (HiddenField)gvAssetNote.Rows[e.RowIndex].FindControl("hfAssetNoteAutoId");
        var ddlAssetNoteType = (DropDownList)gvAssetNote.Rows[e.RowIndex].FindControl("ddlAssetNoteType");
        var txtAssetNoteWhom = (TextBox)gvAssetNote.Rows[e.RowIndex].FindControl("txtAssetNoteWhom");
        var txtAssetNote = (TextBox)gvAssetNote.Rows[e.RowIndex].FindControl("txtAssetNote");

        try
        {
            ds = objAssetMgmt.AssetNoteUpdate(hfAssetNoteAutoId.Value, AssetIdQs.Text, txtAssetNoteWhom.Text, ddlAssetNoteType.SelectedValue, txtAssetNote.Text, BaseUserID,BaseCompanyCode);
            DisplayMessage(lblAssetNoteMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
            gvAssetNote.EditIndex = -1;

            FillgvAssetNote(AssetIdQs.Text);
        }
        catch (Exception ex)
        { }
    }
    #endregion
    #region Function related to Asset AMC
    private void FillgvAssetAMC(string AssetId)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetAMC = new DataSet();
            var dtAssetAMC = new DataTable();
            dtflag2 = 1;
            dsAssetAMC = objAssetMgmt.AssetAMCDetailGet(AssetId,BaseCompanyCode);
            dtAssetAMC = dsAssetAMC.Tables[0];
            if (dtAssetAMC.Rows.Count == 0)
            {
                dtflag2 = 0;
                dtAssetAMC.Rows.Add(dtAssetAMC.NewRow());
            }
            gvAssetAMC.DataSource = dtAssetAMC;
            gvAssetAMC.DataBind();

            if (dtflag2 == 0)
            {
                gvAssetAMC.Rows[0].Visible = false;
                dtflag2 = 0;
            }
            else
            {
                dtflag2 = 1;
            }

        }
        catch (Exception ex)
        {
        }

    }
    protected void gvAssetAMC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox txtAMCStartDate = (TextBox)e.Row.FindControl("txtAMCStartDate");
        if (txtAMCStartDate!=null)
        {
            txtAMCStartDate.Attributes.Add("readonly", "readonly");
        }
        TextBox txtAMCEndDate = (TextBox)e.Row.FindControl("txtAMCEndDate");
        if (txtAMCEndDate != null)
        {
            txtAMCEndDate.Attributes.Add("readonly", "readonly");
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
            var txtAMCFirmName = (TextBox)e.Row.FindControl("txtAMCFirmName");
            var txtAMCFirmPhone = (TextBox)e.Row.FindControl("txtAMCFirmPhone");
            var txtAMCFirmAddress = (TextBox)e.Row.FindControl("txtAMCFirmAddress");
            var txtAMCType = (TextBox)e.Row.FindControl("txtAMCType");
            var txtAMCAmount = (TextBox)e.Row.FindControl("txtAMCAmount");
            var txtAMCTerms = (TextBox)e.Row.FindControl("txtAMCTerms");

            var hfAssetAMCAutoId = (HiddenField)e.Row.FindControl("hfAssetAMCAutoId");
            var ImgBtnUploadAMC = (ImageButton)e.Row.FindControl("ImgBtnUploadAMC");
            if (ImgBtnUploadAMC != null)
            {
                ImgBtnUploadAMC.Attributes.Add("OnClick", "javascript:DocumentUpload(" + hfAssetAMCAutoId.Value + ",'AMC')");
               }
            if (txtAMCFirmName != null)
            {
                txtAMCFirmName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAMCFirmName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtAMCFirmPhone != null)
            {
                txtAMCFirmPhone.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                txtAMCFirmPhone.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
            }
            if (txtAMCFirmAddress != null)
            {
                txtAMCFirmAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAMCFirmAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtAMCType != null)
            {
                txtAMCType.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAMCType.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtAMCAmount != null)
            {
                txtAMCAmount.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtAMCAmount.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

            }
            if (txtAMCTerms != null)
            {
                txtAMCTerms.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAMCTerms.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {
                var txtAMCFirmName = (TextBox)e.Row.FindControl("txtAMCFirmName");
                var txtAMCFirmPhone = (TextBox)e.Row.FindControl("txtAMCFirmPhone");
                var txtAMCFirmAddress = (TextBox)e.Row.FindControl("txtAMCFirmAddress");
                var txtAMCType = (TextBox)e.Row.FindControl("txtAMCType");
                var txtAMCAmount = (TextBox)e.Row.FindControl("txtAMCAmount");
                var txtAMCTerms = (TextBox)e.Row.FindControl("txtAMCTerms");

                var lblAssetName = (Label)e.Row.FindControl("lblAssetName");

                if (txtAMCFirmName != null)
                {
                    txtAMCFirmName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtAMCFirmName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtAMCFirmPhone != null)
                {
                    txtAMCFirmPhone.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                    txtAMCFirmPhone.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                }
                if (txtAMCFirmAddress != null)
                {
                    txtAMCFirmAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtAMCFirmAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                }
                if (txtAMCType != null)
                {
                    txtAMCType.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtAMCType.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtAMCAmount != null)
                {
                    txtAMCAmount.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    txtAMCAmount.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");

                }
                if (txtAMCTerms != null)
                {
                    txtAMCTerms.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtAMCTerms.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                }

                lblAssetName.Text = txtAssetName.Text;

            }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Visible = false;
                    gvAssetAMC.ShowFooter = false;
                }
            }
        }
    }
    protected void gvAssetAMC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        //  var hfAssetAMCAutoId = (HiddenField)gvAssetAMC.FooterRow.FindControl("hfAssetAMCAutoId");
        var lblAssetName = (Label)gvAssetAMC.FooterRow.FindControl("lblAssetName");
        var txtAMCFirmName = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCFirmName");
        var txtAMCFirmEmail = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCFirmEmail");
        var txtAMCFirmPhone = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCFirmPhone");
        var txtAMCFirmAddress = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCFirmAddress");
        var txtAMCType = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCType");
        var txtAMCAmount = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCAmount");
        var txtAMCStartDate = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCStartDate");
        var txtAMCEndDate = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCEndDate");
        var txtAMCTerms = (TextBox)gvAssetAMC.FooterRow.FindControl("txtAMCTerms");
        if (e.CommandName == "AddNew")
        {
            if (txtAMCAmount.Text != "")
            {
                
            }
            else
            {
                txtAMCAmount.Text = "0";
            }


            try
            {
                if (txtPurchaseDate.Text != "")
                {
                    if (DateTime.Parse(txtPurchaseDate.Text) > DateTime.Parse(txtAMCStartDate.Text))
                    {
                        lblAssetAMCMsg.Text = Resources.Resource.StartDateCntlessthanPurchaseDate;
                        
                    }
                    else
                    {
                        if (DateTime.Parse(txtAMCStartDate.Text) < DateTime.Parse(txtAMCEndDate.Text))
                        {
                            ds = objAssetMgmt.AssetAMCInsert(AssetIdQs.Text, txtAMCFirmName.Text, txtAMCFirmEmail.Text, txtAMCFirmPhone.Text, txtAMCFirmAddress.Text, txtAMCType.Text, txtAMCStartDate.Text, txtAMCEndDate.Text, Convert.ToDecimal(txtAMCAmount.Text), txtAMCTerms.Text, BaseUserID,BaseCompanyCode);
                            DisplayMessage(lblAssetAMCMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                            FillgvAssetAMC(AssetIdQs.Text);
                        }
                        else
                        {
                            lblAssetAMCMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                        }
                    }
                }
                else
                {
                    if (DateTime.Parse(txtAMCStartDate.Text) < DateTime.Parse(txtAMCEndDate.Text))
                    {
                        ds = objAssetMgmt.AssetAMCInsert(AssetIdQs.Text, txtAMCFirmName.Text, txtAMCFirmEmail.Text, txtAMCFirmPhone.Text, txtAMCFirmAddress.Text, txtAMCType.Text, txtAMCStartDate.Text, txtAMCEndDate.Text, Convert.ToDecimal(txtAMCAmount.Text), txtAMCTerms.Text, BaseUserID,BaseCompanyCode);
                        DisplayMessage(lblAssetAMCMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                        FillgvAssetAMC(AssetIdQs.Text);
                    }
                    else
                    {
                        lblAssetAMCMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                    }
                }
            }
            catch (Exception ex)
            { }

        }
        if (e.CommandName == "Reset")
        {
            txtAMCFirmName.Text = "";
            txtAMCFirmPhone.Text = "";
            txtAMCFirmEmail.Text = "";
            txtAMCFirmAddress.Text = "";
            txtAMCAmount.Text = "";
            txtAMCEndDate.Text = "";
            txtAMCStartDate.Text = "";
            txtAMCTerms.Text = "";
            txtAMCType.Text = "";
        }

    }
    protected void gvAssetAMC_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var ds1 = new DataSet();
        var dt = new DataTable();
        var objAssetMgmt = new BL.AssetManagement();
        HiddenField ID = (HiddenField)gvAssetAMC.Rows[e.RowIndex].FindControl("hfAssetAMCAutoId");

        var objAssetMgmt1 = new BL.AssetManagement();
        ds1 = objAssetMgmt1.GetAssetDocumentsDetail(Convert.ToInt32(ID.Value), "AMC",BaseCompanyCode);
        dt = ds1.Tables[0];
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            filepath = uploadfolder + dt.Rows[i]["DocumentFileName"].ToString();
            filepath = MapPath(filepath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        ds = objAssetMgmt.AssetAMCDelete(ID.Value, "AMC",BaseCompanyCode);
        DisplayMessage(lblAssetAMCMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvAssetAMC.EditIndex = -1;

        FillgvAssetAMC(AssetIdQs.Text);
    }
    protected void gvAssetAMC_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetAMC.EditIndex = e.NewEditIndex;
        FillgvAssetAMC(AssetIdQs.Text);
    }
    protected void gvAssetAMC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetAMC.PageIndex = e.NewPageIndex;
        gvAssetAMC.EditIndex = -1;
        FillgvAssetAMC(AssetIdQs.Text);
    }
    protected void gvAssetAMC_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetAMCAutoId = (HiddenField)gvAssetAMC.Rows[e.RowIndex].FindControl("hfAssetAMCAutoId");
        var lblAssetName = (Label)gvAssetAMC.Rows[e.RowIndex].FindControl("lblAssetName");
        var txtAMCFirmName = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCFirmName");
        var txtAMCFirmEmail = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCFirmEmail");
        var txtAMCFirmPhone = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCFirmPhone");
        var txtAMCFirmAddress = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCFirmAddress");
        var txtAMCType = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCType");
        var txtAMCAmount = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCAmount");
        var txtAMCStartDate = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCStartDate");
        var txtAMCEndDate = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCEndDate");
        var txtAMCTerms = (TextBox)gvAssetAMC.Rows[e.RowIndex].FindControl("txtAMCTerms");
        if (txtAMCAmount.Text != "")
        {
           

        }
        else
        {
            txtAMCAmount.Text = "0";
        }

       
        try
        {
            if (txtPurchaseDate.Text != "")
                {
                    if (DateTime.Parse(txtPurchaseDate.Text) > DateTime.Parse(txtAMCStartDate.Text))
                    {
                        lblAssetAMCMsg.Text = Resources.Resource.StartDateCntlessthanPurchaseDate;
                    }
                    else
                    {
            if (DateTime.Parse(txtAMCStartDate.Text) < DateTime.Parse(txtAMCEndDate.Text))
            {

                ds = objAssetMgmt.AssetAMCUpdate(hfAssetAMCAutoId.Value, AssetIdQs.Text, txtAMCFirmName.Text, txtAMCFirmEmail.Text, txtAMCFirmPhone.Text, txtAMCFirmAddress.Text, txtAMCType.Text, txtAMCStartDate.Text, txtAMCEndDate.Text, Convert.ToDecimal(txtAMCAmount.Text), txtAMCTerms.Text, BaseUserID,BaseCompanyCode);
                DisplayMessage(lblAssetAMCMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                gvAssetAMC.EditIndex = -1;
                FillgvAssetAMC(AssetIdQs.Text);
            }
            else
            {
                lblAssetAMCMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
            }
        }}
            else
                    {
            if (DateTime.Parse(txtAMCStartDate.Text) < DateTime.Parse(txtAMCEndDate.Text))
            {

                ds = objAssetMgmt.AssetAMCUpdate(hfAssetAMCAutoId.Value, AssetIdQs.Text, txtAMCFirmName.Text, txtAMCFirmEmail.Text, txtAMCFirmPhone.Text, txtAMCFirmAddress.Text, txtAMCType.Text, txtAMCStartDate.Text, txtAMCEndDate.Text, Convert.ToDecimal(txtAMCAmount.Text), txtAMCTerms.Text, BaseUserID,BaseCompanyCode);
                DisplayMessage(lblAssetAMCMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                gvAssetAMC.EditIndex = -1;
                FillgvAssetAMC(AssetIdQs.Text);
            }
            else
            {
                lblAssetAMCMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
            } }}
        catch (Exception ex)
        { }
    }
   
   
    protected void gvAssetAMC_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetAMC.EditIndex = -1;
        FillgvAssetAMC(AssetIdQs.Text);
    }
    #endregion
    #region Function related to Asset Client Mapping

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
                FillAsmtId();
              //  FillgvSaleOrder();
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
   
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtId();
  
    }
    protected void ddlAsmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPost();
    }
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillddlClient();
    }

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
    protected void FillAsmtId()
    {
      
        BL.Sales objSales = new BL.Sales();
     
        ddlAsmtId.DataSource = objSales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), BaseUserEmployeeNumber, "");
      
        ddlAsmtId.DataTextField = "AsmtIDAddress";
        ddlAsmtId.DataValueField = "AsmtID";
        ddlAsmtId.DataBind();
        //ListItem li1 = new ListItem();
        //li1.Text = Resources.Resource.All;
        //li1.Value = "ALL";
        //ddlAsmtId.Items.Insert(0, li1);
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
            try { 
            ddlPost.DataTextField = "Post";
            ddlPost.DataValueField = "PostAutoId";
            ddlPost.DataBind();
                }
            catch(Exception ex)
            { }

        }
    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();

        try
        {
            ds = objAssetMgmt.AssetClientMappingInsert(Convert.ToInt32(AssetIdQs.Text), Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, Convert.ToInt32(ddlPost.SelectedItem.Value), txtRemark.Text, txtUsage.Text, BaseUserID);
            DisplayMessage(lblMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
            btnUpdateMapping.Visible = true;
            btnSubmitMapping.Visible = false;
          
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
                    ddlAsmtId.SelectedValue = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                    ddlPost.SelectedValue = ds.Tables[0].Rows[0]["PostAutoId"].ToString();
                    txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                    txtUsage.Text = ds.Tables[0].Rows[0]["Usage"].ToString();
                    btnUpdateMapping.Visible = true;
                    btnSubmitMapping.Visible = false;
                }
                else
                {
                    btnUpdateMapping.Visible = false;
                    btnSubmitMapping.Visible = true;
                }
            }
            else
            {
                btnUpdateMapping.Visible = false;
                btnSubmitMapping.Visible = true;
                
            }
         
        }
        catch (Exception ex)
        { }
    }
    protected void btnUpdateMapping_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();

        try
        {
            ds = objAssetMgmt.AssetClientMappingUpdate(Convert.ToInt32(AssetIdQs.Text), Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, Convert.ToInt32(ddlPost.SelectedItem.Value), txtRemark.Text, txtUsage.Text, BaseUserID);
            DisplayMessage(lblMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());

        }
        catch (Exception ex)
        { }

    }
    public void DeleteAssetClientMappingDetails()
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();

        try
        {
            ds = objAssetMgmt.AssetClientMappingDelete(Convert.ToInt32(AssetIdQs.Text), Convert.ToInt32(BaseLocationAutoID));
            DisplayMessage(lblMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());

        }
        catch (Exception ex)
        { }
        btnUpdateMapping.Visible = false;
        btnSubmitMapping.Visible = true;
        txtRemark.Text = "";
        txtUsage.Text = "";
        FillddlClient();
    }

    #endregion
   
}