using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssetManagement_AssetManufacturer : BasePage//System.Web.UI.Page
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
                int VirtualDirNameLenght = 0;
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



            if (IsReadAccess == true)
            {
                FillgvAssetManufacturer();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }


        }
    }
    #endregion

    #region Function to Fill GridView
    /// <summary>
    /// TO Fill AssetManufacturer
    /// </summary>
    private void FillgvAssetManufacturer()
    {
        BL.AssetManagement objblMasterManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        DataTable dtAsset = new DataTable();
        ds = objblMasterManagement.AssetManufacturerGetRecords(BaseCompanyCode,Convert.ToInt32(BaseLocationAutoID));
        dtAsset = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtAsset.Rows.Count > 0)
        {
            gvAssetManufacturer.DataSource = dtAsset;
            gvAssetManufacturer.DataBind();
        }
        else
        {
            dtAsset = ds.Tables[0];
            dtAsset.Rows.Add(dtAsset.NewRow());
            gvAssetManufacturer.DataSource = dtAsset;
            gvAssetManufacturer.DataBind();
            gvAssetManufacturer.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvAssetManufacturer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAssetManufacturer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        TextBox txtNewManufacturerName = (TextBox)gvAssetManufacturer.FooterRow.FindControl("txtNewManufacturerName");
        TextBox txtNewManufacturerEmail = (TextBox)gvAssetManufacturer.FooterRow.FindControl("txtNewManufacturerEmail");
        TextBox txtNewManufacturerPhone = (TextBox)gvAssetManufacturer.FooterRow.FindControl("txtNewManufacturerPhone");
        TextBox txtNewManufacturerAddress = (TextBox)gvAssetManufacturer.FooterRow.FindControl("txtNewManufacturerAddress");
        BL.AssetManagement objblMasterManagement = new BL.AssetManagement();
        
        if (e.CommandName.Equals("AddNew"))
        {

            ds = objblMasterManagement.AssetManufacturerAddNew(txtNewManufacturerName.Text, txtNewManufacturerEmail.Text, txtNewManufacturerPhone.Text, txtNewManufacturerAddress.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));


            FillgvAssetManufacturer();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewManufacturerName.Text = "";
            txtNewManufacturerEmail.Text = "";
            txtNewManufacturerPhone.Text = "";
            txtNewManufacturerAddress.Text = "";
            lblErrorMsg.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvAssetManufacturer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAssetManufacturer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetManufacturer.PageIndex * gvAssetManufacturer.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (IsModifyAccess == false)
            {
                ImageButton IBEditLang = (ImageButton)e.Row.FindControl("IBEditAsset");
                if (IBEditLang != null)
                {
                    IBEditLang.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdateLang = (ImageButton)e.Row.FindControl("ImgbtnUpdateAsset");
                if (ImgbtnUpdateLang != null)
                {
                    ImgbtnUpdateLang.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteLang = (ImageButton)e.Row.FindControl("IBDeleteAsset");
                if (IBDeleteLang != null)
                {
                    IBDeleteLang.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteLang = (ImageButton)e.Row.FindControl("IBDeleteAsset");
                if (IBDeleteLang != null)
                {
                    IBDeleteLang.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
            
            var txtManufacturerPhone = (TextBox)e.Row.FindControl("txtManufacturerPhone");
            if (txtManufacturerPhone != null)
            {
                txtManufacturerPhone.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                txtManufacturerPhone.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
            }
            var txtManufacturerAddress = (TextBox)e.Row.FindControl("txtManufacturerAddress");
            if (txtManufacturerAddress != null)
            {
                txtManufacturerAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtManufacturerAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            

            var txtNewManufacturerPhone = (TextBox)e.Row.FindControl("txtNewManufacturerPhone");
            if (txtNewManufacturerPhone != null)
            {
                txtNewManufacturerPhone.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                txtNewManufacturerPhone.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
            }
            var txtNewManufacturerAddress = (TextBox)e.Row.FindControl("txtNewManufacturerAddress");
            if (txtNewManufacturerAddress != null)
            {
                txtNewManufacturerAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewManufacturerAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            var txtNewManufacturerName = (TextBox)e.Row.FindControl("txtNewManufacturerName");
            if (txtNewManufacturerName != null)
            {
                txtNewManufacturerName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewManufacturerName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            
        }
    }


    /// <summary>
    /// Handles the RowEditing event of the gvAssetManufacturer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvAssetManufacturer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetManufacturer.EditIndex = e.NewEditIndex;
        FillgvAssetManufacturer();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvAssetManufacturer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvAssetManufacturer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       
        DataSet ds = new DataSet();
        BL.AssetManagement objblMastermanagement = new BL.AssetManagement();
        Label lblManufacturerName = (Label)gvAssetManufacturer.Rows[e.RowIndex].FindControl("lblManufacturerName");
        TextBox txtManufacturerEmail = (TextBox)gvAssetManufacturer.Rows[e.RowIndex].FindControl("txtManufacturerEmail");
        TextBox txtManufacturerPhone = (TextBox)gvAssetManufacturer.Rows[e.RowIndex].FindControl("txtManufacturerPhone");
        TextBox txtManufacturerAddress = (TextBox)gvAssetManufacturer.Rows[e.RowIndex].FindControl("txtManufacturerAddress");

        ds = objblMastermanagement.AssetManufacturerUpdate(lblManufacturerName.Text, txtManufacturerEmail.Text, txtManufacturerPhone.Text, txtManufacturerAddress.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        gvAssetManufacturer.EditIndex = -1;
        FillgvAssetManufacturer();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvAssetManufacturer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAssetManufacturer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.AssetManagement objblMasterManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        HiddenField ID = (HiddenField)gvAssetManufacturer.Rows[e.RowIndex].FindControl("hfManufacturerAutoID");

        ds = objblMasterManagement.AssetManufacturerDelete(ID.Value, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));

        FillgvAssetManufacturer();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvAssetManufacturer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAssetManufacturer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetManufacturer.PageIndex = e.NewPageIndex;
        gvAssetManufacturer.EditIndex = -1;
        FillgvAssetManufacturer();
    }
    protected void gvAssetManufacturer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetManufacturer.EditIndex = -1;
        FillgvAssetManufacturer();
    }
    #endregion

   
}