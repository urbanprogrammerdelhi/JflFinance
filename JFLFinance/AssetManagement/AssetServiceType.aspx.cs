using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssetManagement_AssetServiceType : BasePage//System.Web.UI.Page
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
                FillgvAssetServiceType();
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
    /// TO Fill gvAssetServiceType
    /// </summary>
    private void FillgvAssetServiceType()
    {
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        DataTable dtAsset = new DataTable();
        ds = objblAssetManagement.AssetServiceTypeGetRecords(BaseCompanyCode,Convert.ToInt32(BaseLocationAutoID));
        dtAsset = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtAsset.Rows.Count > 0)
        {
            gvAssetServiceType.DataSource = dtAsset;
            gvAssetServiceType.DataBind();
        }
        else
        {
            dtAsset = ds.Tables[0];
            dtAsset.Rows.Add(dtAsset.NewRow());
            gvAssetServiceType.DataSource = dtAsset;
            gvAssetServiceType.DataBind();
            gvAssetServiceType.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvAssetServiceType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAssetServiceType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        DropDownList ddlAssetName = (DropDownList)gvAssetServiceType.FooterRow.FindControl("ddlAssetName");
        TextBox txtNewAssetServiceTypeName = (TextBox)gvAssetServiceType.FooterRow.FindControl("txtNewAssetServiceTypeName");
        
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();
       
                if (e.CommandName.Equals("AddNew"))
                {

                    ds = objblAssetManagement.AssetServiceTypeAddNew(ddlAssetName.SelectedValue, txtNewAssetServiceTypeName.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));

                    FillgvAssetServiceType();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            
            if (e.CommandName.Equals("Reset"))
            {

                txtNewAssetServiceTypeName.Text = "";
                lblErrorMsg.Text = "";
            }

        }
       
    /// <summary>
    /// Handles the RowDataBound event of the gvAssetServiceType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAssetServiceType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetServiceType.PageIndex * gvAssetServiceType.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            var txtNewAssetServiceTypeName = (TextBox)e.Row.FindControl("txtNewAssetServiceTypeName");

            if (txtNewAssetServiceTypeName != null)
            {

                txtNewAssetServiceTypeName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                txtNewAssetServiceTypeName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            DropDownList ddlAssetName = (DropDownList)e.Row.FindControl("ddlAssetName");
            FillddlAssetName(ddlAssetName);

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {

                var txtNewAssetServiceTypeName = (TextBox)e.Row.FindControl("txtNewAssetServiceTypeName");

                if (txtNewAssetServiceTypeName != null)
                {

                    txtNewAssetServiceTypeName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                    txtNewAssetServiceTypeName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

                }
            }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Visible = false;
                    gvAssetServiceType.ShowFooter = false;
                }
            }
            DropDownList ddlAssetName = (DropDownList)e.Row.FindControl("ddlAssetName");
            FillddlAssetName(ddlAssetName);
        }
    }
    private void FillddlAssetName(DropDownList ddlAssetName)
    {
        try { 
            var objAssetManagement = new BL.AssetManagement();

            ddlAssetName.DataSource = objAssetManagement.AssetNameDetailForServiceType(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            ddlAssetName.DataTextField = "AssetName";
            ddlAssetName.DataValueField = "AssetName";
            ddlAssetName.DataBind();
            if (ddlAssetName.SelectedValue == "")
            {
                var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
                ddlAssetName.Items.Add(li);
            }
             }
        catch(Exception ex)
        { }
          }
       /// <summary>
    /// Handles the RowEditing event of the gvAssetServiceType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvAssetServiceType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetServiceType.EditIndex = e.NewEditIndex;
        FillgvAssetServiceType();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvAssetServiceType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvAssetServiceType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objblAssetmanagement = new BL.AssetManagement();
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvAssetServiceType.Rows[e.RowIndex].FindControl("hfAssetServiceTypeAutoId");
        Label lblAssetName = (Label)gvAssetServiceType.Rows[e.RowIndex].FindControl("lblAssetName");
        TextBox txtAssetServiceTypeName = (TextBox)gvAssetServiceType.Rows[e.RowIndex].FindControl("txtAssetServiceTypeName");



        ds = objblAssetmanagement.AssetServiceTypeUpdate(Convert.ToInt32(hfAssetServiceTypeAutoId.Value), lblAssetName.Text, txtAssetServiceTypeName.Text, BaseUserID, BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
            gvAssetServiceType.EditIndex = -1;
            FillgvAssetServiceType();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
           }

    /// <summary>
    /// Handles the RowDeleting event of the gvAssetServiceType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAssetServiceType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.AssetManagement objblAssetManagement = new BL.AssetManagement();
        DataSet ds = new DataSet();
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvAssetServiceType.Rows[e.RowIndex].FindControl("hfAssetServiceTypeAutoId");

        ds = objblAssetManagement.AssetServiceForDelete(Convert.ToInt32(hfAssetServiceTypeAutoId.Value), BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));

        FillgvAssetServiceType();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvAssetServiceType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAssetServiceType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetServiceType.PageIndex = e.NewPageIndex;
        gvAssetServiceType.EditIndex = -1;
        FillgvAssetServiceType();
    }

    protected void gvAssetServiceType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetServiceType.EditIndex = -1;
        FillgvAssetServiceType();
    }
   protected void gvAssetServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion
}