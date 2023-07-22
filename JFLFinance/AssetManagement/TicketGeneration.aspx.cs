using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssetManagement_TicketGeneration : BasePage
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
    int AssetCatId = 0, AssetSubCatId = 0;
    #endregion
    static int Userflag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillddlClient();
                FillAsmtId();
                FillCompany();
               FillCategory();
                if (txtSummary != null)
                {
                    txtSummary.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtSummary.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtDescription != null)
                {
                    txtDescription.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtDescription.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtValue != null)
                {
                    txtValue.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                    txtValue.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

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

            if (BaseIsAdmin == "R")
            {
                ds = objsales.ClientsMappedToLocationGet(BaseLocationAutoID, "ALL", BaseUserID, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
            }
            else
            {
                ds = objsales.ClientsMappedToLocationGet(BaseLocationAutoID, "ALL", "".ToString(), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
            }
        }
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientCode";
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
        ddlRestAddress.DataSource = objSales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), BaseUserEmployeeNumber, "");
        ddlRestAddress.DataTextField = "AsmtAddress";
        ddlRestAddress.DataValueField = "AsmtID";
        ddlRestAddress.DataBind();
        if (ddlRestAddress.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlRestAddress.Items.Add(li);
        }
        DataSet ds = new DataSet();
        ds = objSales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), BaseUserEmployeeNumber, "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtRestAddress.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
            }
            else
            {
                txtRestAddress.Text = "No Address Found";
            }
        }
        else  
        {
            txtRestAddress.Text = "No Address Found";
            }
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtId();
    }
    protected void btnGenerateTicket_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            HttpPostedFile postedfile = imgFile.PostedFile;
            string fileName = Path.GetFileName(postedfile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif" || fileExtension == "")
            {
                byte[] thumbnailImageBytes;
                if (imgFile.HasFile)
                {
                    byte[] imageBytes = new byte[imgFile.PostedFile.ContentLength];
                    HttpPostedFile uploadImage = imgFile.PostedFile;
                    uploadImage.InputStream.Read(imageBytes, 0, (int)imgFile.PostedFile.ContentLength);
                    MemoryStream thumbnailPhotoStream = ResizeImage(imgFile);
                    thumbnailImageBytes = thumbnailPhotoStream.ToArray();
                }
                else
                {
                    thumbnailImageBytes = new byte[imgFile.PostedFile.ContentLength];
                }
                if (ddlAssetCategory.SelectedItem.Value != "0" && ddlAssetSubCategory.SelectedItem.Value != "0" && ddlAssetName.SelectedItem.Value != "0" && ddlClientCode.SelectedItem.Value != "0" && txtRestAddress.Text != "")
                {
                    ds = objAssetMgmt.TicketGeneration(ddlClientCode.SelectedItem.Text, ddlClientCode.SelectedValue, ddlRestAddress.SelectedItem.Text, ddlRestAddress.SelectedValue, txtSummary.Text, txtDescription.Text, ddlSeverity.SelectedItem.Value, txtValue.Text, BaseLocationAutoID, BaseUserID, ddlAssetCategory.SelectedItem.Value, ddlAssetSubCategory.SelectedItem.Value, ddlAssetName.SelectedItem.Value, thumbnailImageBytes);

                    lblMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString() + " with Ticket No. - " + ds.Tables[0].Rows[0]["TicketNumber"].ToString();
                    txtValue.Text = "";
                    txtSummary.Text = "";
                    txtDescription.Text = "";
                
            btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#257FDD");
      
                }
                else
                {
                    lblMsg.Text = "Please Select All DropDown Fields !!";
                    btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4500");
                }
            }
            else
            {
                lblMsg.Text = "Only .jpg,.png,.jpeg,.gif Files are allowed";
                btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4500");
            }
        }

        catch (Exception ex)
        { }
    }

    private MemoryStream ResizeImage(FileUpload fileUpload)
    {
        Bitmap originalBMP = new Bitmap(fileUpload.FileContent);
        int origWidth = originalBMP.Width;
        int origHeight = originalBMP.Height;
        int aspectRatio = origWidth / origHeight;
        if (aspectRatio <= 0)
            aspectRatio = 1;
        int newWidth = 100;
        int newHeight = newWidth / aspectRatio;
        Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
        Graphics graphics = Graphics.FromImage(newBMP);
        graphics.SmoothingMode = SmoothingMode.AntiAlias; graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        newBMP.Save(stream, GetImageFormat(System.IO.Path.GetExtension(fileUpload.FileName)));
        originalBMP.Dispose();
        newBMP.Dispose();
        graphics.Dispose();

        return stream;
    }

    private System.Drawing.Imaging.ImageFormat GetImageFormat(string extension)
    {
        switch (extension.ToLower())
        {
            case "jpg":
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            case "bmp":
                return System.Drawing.Imaging.ImageFormat.Bmp;
            case "png":
                return System.Drawing.Imaging.ImageFormat.Png;
        }
        return System.Drawing.Imaging.ImageFormat.Jpeg;
    }
    protected void FillCompany()
    {
        BL.AssetManagement objSales = new BL.AssetManagement();
        ddlCompany.DataSource = objSales.GetCompanyDetails(BaseLocationAutoID);
        ddlCompany.DataTextField = "CompanyDesc";
        ddlCompany.DataValueField = "CompanyCode";
        ddlCompany.DataBind();
        if (ddlCompany.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlCompany.Items.Add(li);
        }
    }
    protected void FillCategory()
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objSales = new BL.AssetManagement();
        ds = objSales.GetCategory(BaseLocationAutoID);
        ddlAssetCategory.Items.Clear();   
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
             
                ddlAssetCategory.DataSource = objSales.GetCategory(BaseLocationAutoID);
                ddlAssetCategory.DataTextField = "AssetCategoryName";
                ddlAssetCategory.DataValueField = "AssetCategoryAutoId";
                ddlAssetCategory.DataBind();
                AssetCatId = Convert.ToInt32(ddlAssetCategory.SelectedItem.Value);
                                
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlAssetCategory.Items.Add(li);
            }
        }
        FillSubCategory();      
       
    }
    protected void FillSubCategory()
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objSales = new BL.AssetManagement();
        ds = objSales.GetSubCategory(AssetCatId);
        ddlAssetSubCategory.Items.Clear();   
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
             
                ddlAssetSubCategory.DataSource = objSales.GetSubCategory(AssetCatId);
                ddlAssetSubCategory.DataTextField = "AssetSubCategoryName";
                ddlAssetSubCategory.DataValueField = "AssetSubCategoryAutoId";
                ddlAssetSubCategory.DataBind();
                AssetSubCatId = Convert.ToInt32(ddlAssetSubCategory.SelectedItem.Value);
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlAssetSubCategory.Items.Add(li);
            }
        }
        FillAsset();

    }
    protected void FillAsset()
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objSales = new BL.AssetManagement();
        ds = objSales.GetAsset(AssetSubCatId,Convert.ToInt32(BaseLocationAutoID));
        ddlAssetName.Items.Clear();     
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                ddlAssetName.DataSource = objSales.GetAsset(AssetSubCatId, Convert.ToInt32(BaseLocationAutoID));
                ddlAssetName.DataTextField = "AssetNameCode";
                ddlAssetName.DataValueField = "AssetAutoId";
                ddlAssetName.DataBind();              
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlAssetName.Items.Add(li);
            }
        }
    
       if (ddlAssetCategory.SelectedItem.Value == "0" || ddlAssetSubCategory.SelectedItem.Value == "0" || ddlAssetName.SelectedItem.Value == "0")
        {
            btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4500");
        }
       else
       {
            btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#257FDD");
       }
    }
    protected void ddlAssetCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        AssetCatId = Convert.ToInt32(ddlAssetCategory.SelectedValue);
        FillSubCategory();
        if (ddlAssetCategory.SelectedItem.Value == "0" || ddlAssetSubCategory.SelectedItem.Value == "0" || ddlAssetName.SelectedItem.Value == "0")
            btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4500");
        else
            btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E6293");
    }
    protected void ddlAssetSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        AssetSubCatId = Convert.ToInt32(ddlAssetSubCategory.SelectedValue);
        FillAsset();
        if (ddlAssetSubCategory.SelectedItem.Value == "0" || ddlAssetName.SelectedItem.Value == "0")
            btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4500");
        else
            btnGenerateTicket.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E6293");
    }


    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AssetManagement/TicketMaster.aspx");
    }
    protected void btnSchedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AssetManagement/TicketScheduling.aspx");
    }
}