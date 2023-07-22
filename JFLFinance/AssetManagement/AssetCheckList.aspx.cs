using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class AssetManagement_AssetCheckList : BasePage
{
    static int dtflag;
    static int dtflag1;
  
    static int Checklistid;
    static int SubChecklistid;
    string ChecklistName;
    string SubChecklistName;
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
                 hfAssetId.Value = (Request.QueryString["AssetId"]);
                 FillServiceType(Convert.ToInt32(hfAssetId.Value));
                 FillDetailsForUpdate(hfAssetId.Value);
                 FillChecklistName(Convert.ToInt32(hfAssetId.Value), ddlServicetype);
                 FillAssetCategory();
                 FillAssetManufacturer();
                 FillAssetSubCategory(Convert.ToInt32(ddlAssetCategory.SelectedValue));

                 if (txtCheccklistname != null)
                 {
                     txtCheccklistname.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                     txtCheccklistname.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                 }
                 if (!IsWriteAccess)
                 {
                    // btnSubmit.Enabled = false;
                     btnSubmit.Visible = false;
                 }
             }
             else
             {
                 Response.Redirect("../UserManagement/Home.aspx");
             }

         }
    }
    private void FillChecklistName(int AssetId, DropDownList ddlServicetype)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsChecklistName = new DataSet();
            var dtChecklistName = new DataTable();
            dtflag = 1;
            dsChecklistName = objAssetMgmt.GetChecklistName(AssetId,ddlServicetype.SelectedValue,BaseCompanyCode);
            dtChecklistName = dsChecklistName.Tables[0];
            if (dtChecklistName.Rows.Count == 0)
            {
                dtflag = 0;
                dtChecklistName.Rows.Add(dtChecklistName.NewRow());
            }
            gvAssetChecklistName.DataSource = dtChecklistName;
            gvAssetChecklistName.DataBind();

            if (dtflag == 0)
            {
                gvAssetChecklistName.Rows[0].Visible = false;
                gvAssetChecklistName.HeaderRow.Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
            if (dsChecklistName.Tables[0].Rows[0]["AssetCheckListAutoId"].ToString() != string.Empty)
            {
                if (Checklistid != null)
                {
                    Checklistid = Convert.ToInt32( dsChecklistName.Tables[0].Rows[0]["AssetCheckListAutoId"].ToString());
                }
                FillgvAssetChecklistNameDetail(Checklistid);
                PanelAssetChecklistNameDetail.Visible = true;
            }

        }
        catch (Exception ex)
        {
        }

    }
    //private void FillChecklistName(int AssetId)
    //{
    //    var objAssetManagement = new BL.AssetManagement();
    //    CBLCheckListName.DataSource = objAssetManagement.GetChecklistName(AssetId);
    //    CBLCheckListName.DataTextField = "CheckListName";
    //    CBLCheckListName.DataValueField = "CheckListName";
    //    CBLCheckListName.DataBind();
    //    //if (CBLCheckListName.SelectedValue == "")
    //    //{
    //    //    var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
    //    //    CBLCheckListName.Items.Add(li);

    //    //}
      

    //}
    private void  FillAssetSubCategory(int AssetId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlAssetSubCategory.DataSource = objAssetManagement.AssetSubCategoryDetailGet(AssetId,BaseCompanyCode,Convert.ToInt32(BaseLocationAutoID));
        ddlAssetSubCategory.DataTextField = "AssetSubCategoryName";
        ddlAssetSubCategory.DataValueField = "AssetSubCategoryAutoId";
        ddlAssetSubCategory.DataBind();
        if (ddlAssetSubCategory.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAssetSubCategory.Items.Add(li);

        }


    }
    private void FillServiceType(int AssetId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlServicetype.DataSource = objAssetManagement.AssetServiceTypeGet(AssetId,BaseCompanyCode);
        ddlServicetype.DataTextField = "AssetServiceTypename";
        ddlServicetype.DataValueField = "AssetServiceTypeAutoId";
        ddlServicetype.DataBind();
        if (ddlServicetype.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlServicetype.Items.Add(li);

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
           

        }
        catch (Exception ex)
        { }
    }
    private void FillAssetCategory()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlAssetCategory.DataSource = objAssetManagement.AssetCategoryDetailGet(BaseCompanyCode, Convert.ToInt32(BaseLocationAutoID));
        ddlAssetCategory.DataTextField = "AssetCategoryName";
        ddlAssetCategory.DataValueField = "AssetCategoryAutoId";
        ddlAssetCategory.DataBind();
        if (ddlAssetCategory.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAssetCategory.Items.Add(li);

        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {if(ddlServicetype.SelectedValue=="0")
        {
            lblChecklistNameError.Text = Resources.Resource.SelectServiceType;
        }
        else
        { 
            ds = objAssetMgmt.AssetChecklistNameInsert(Convert.ToInt32( hfAssetId.Value),Convert.ToInt32( ddlServicetype.SelectedValue),txtCheccklistname.Text, BaseUserID,BaseCompanyCode);
            DisplayMessage(lblChecklistNameError, ds.Tables[0].Rows[0]["MessageId"].ToString());
            txtCheccklistname.Text = "";
        }
        }
        catch(Exception ex)
        { }
        FillChecklistName(Convert.ToInt32(hfAssetId.Value),ddlServicetype);
    }
    protected void btnack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetMaster.aspx");
    }
    protected void lbChecklistName_Click(object sender, EventArgs e)
    {
        LinkButton lbChecklistName = sender as LinkButton;
        GridViewRow row = (GridViewRow)lbChecklistName.NamingContainer;
        HiddenField hfAssetCheckListAutoId = (HiddenField)row.FindControl("hfAssetCheckListAutoId");
        ChecklistName = lbChecklistName.Text;
        Checklistid = Convert.ToInt32(hfAssetCheckListAutoId.Value);
        FillgvAssetChecklistNameDetail(Convert.ToInt32(hfAssetCheckListAutoId.Value));
        PanelAssetChecklistNameDetail.Visible = true;
        
    }
    private void FillgvAssetChecklistNameDetail(int ChecklistId)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsChecklistNameItems = new DataSet();
            var dtChecklistNameItems = new DataTable();
            dtflag1 = 1;
            dsChecklistNameItems = objAssetMgmt.GetChecklistNameItems(ChecklistId,BaseCompanyCode);
            dtChecklistNameItems = dsChecklistNameItems.Tables[0];
            if (dtChecklistNameItems.Rows.Count == 0)
            {
                dtflag1 = 0;
                dtChecklistNameItems.Rows.Add(dtChecklistNameItems.NewRow());
            }
            gvAssetChecklistNameDetail.DataSource = dtChecklistNameItems;
            gvAssetChecklistNameDetail.DataBind();

            if (dtflag1 == 0)
            {
                gvAssetChecklistNameDetail.Rows[0].Visible = false;
               // gvAssetChecklistName.HeaderRow.Visible = false;
                dtflag1 = 0;
            }
            else
            {
                dtflag1 = 1;
            }
            if (dsChecklistNameItems.Tables[0].Rows[0]["AssetCheckListDetailAutoId"].ToString() != string.Empty)
            {
                if (SubChecklistid != null)
                {
                    SubChecklistid = Convert.ToInt32(dsChecklistNameItems.Tables[0].Rows[0]["AssetCheckListDetailAutoId"].ToString());
                }
                FillSubChecklistName(Convert.ToInt32(SubChecklistid));
                divSubitem.Visible = true;
            }

            //FillSubChecklistName(Convert.ToInt32(SubChecklistid));
            //divSubitem.Visible = true;
        }
        catch (Exception ex)
        {
        }

    }
    protected void gvAssetChecklistNameDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetChecklistNameDetail.EditIndex = -1;
        FillgvAssetChecklistNameDetail(Checklistid);
    }
    protected void gvAssetChecklistNameDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetCheckListDetailAutoId = (HiddenField)gvAssetChecklistNameDetail.Rows[e.RowIndex].FindControl("hfAssetCheckListDetailAutoId");
        var txtChecklistNameDetail = (TextBox)gvAssetChecklistNameDetail.Rows[e.RowIndex].FindControl("txtChecklistNameDetail");
          try
            {
                ds = objAssetMgmt.ChecklistItemNameUpdate(Convert.ToInt32(hfAssetCheckListDetailAutoId.Value), txtChecklistNameDetail.Text, BaseUserID,BaseCompanyCode);
                DisplayMessage(lblChecklistDetail, ds.Tables[0].Rows[0]["MessageId"].ToString());
                gvAssetChecklistNameDetail.EditIndex = -1;
                FillgvAssetChecklistNameDetail(Checklistid);
            }
            catch (Exception ex)
            { }

    }
    protected void gvAssetChecklistNameDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
      
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetCheckListDetailAutoId = (HiddenField)gvAssetChecklistNameDetail.Rows[e.RowIndex].FindControl("hfAssetCheckListDetailAutoId");
        ds = objAssetMgmt.ChecklistItemNameDelete(Convert.ToInt32(hfAssetCheckListDetailAutoId.Value),BaseCompanyCode);
        DisplayMessage(lblChecklistDetail, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvAssetChecklistNameDetail.EditIndex = -1;
        FillgvAssetChecklistNameDetail(Checklistid);
    }
    protected void gvAssetChecklistNameDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetChecklistNameDetail.EditIndex = e.NewEditIndex;
        FillgvAssetChecklistNameDetail(Checklistid);
    }
    protected void gvAssetChecklistNameDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetChecklistNameDetail.PageIndex = e.NewPageIndex;
        gvAssetChecklistNameDetail.EditIndex = -1;
        FillgvAssetChecklistNameDetail(Checklistid);
    }
    protected void gvAssetChecklistNameDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
      //  var hfAssetCheckListNameAutoId = (HiddenField)gvAssetChecklistNameDetail.FooterRow.FindControl("hfAssetCheckListNameAutoId");

        var txtChecklistNameDetail = (TextBox)gvAssetChecklistNameDetail.FooterRow.FindControl("txtChecklistNameDetail");

        if (e.CommandName == "AddNew")
        {
            try
            {
                ds = objAssetMgmt.ChecklistItemNameInsert(Checklistid, txtChecklistNameDetail.Text, BaseUserID,BaseCompanyCode);
                DisplayMessage(lblChecklistDetail, ds.Tables[0].Rows[0]["MessageId"].ToString());
                txtChecklistNameDetail.Text = "";

                FillgvAssetChecklistNameDetail(Checklistid);
            }
            catch (Exception ex)
            { }

        }
        if (e.CommandName == "Reset")
        {
            txtChecklistNameDetail.Text = "";
        }

    }
    protected void gvAssetChecklistNameDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetChecklistNameDetail.PageIndex * gvAssetChecklistNameDetail.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
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
            var txtChecklistNameDetail = (TextBox)e.Row.FindControl("txtChecklistNameDetail");
            if (txtChecklistNameDetail != null)
            {
                txtChecklistNameDetail.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtChecklistNameDetail.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
           
           
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {
                var txtChecklistNameDetail = (TextBox)e.Row.FindControl("txtChecklistNameDetail");
                if (txtChecklistNameDetail != null)
                {
                    txtChecklistNameDetail.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtChecklistNameDetail.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
            } 
             else
             {
                 var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                 if (lbADD != null)
                 {
                     lbADD.Visible = false;
                     gvAssetChecklistNameDetail.ShowFooter = false;
                 }
             }
            try
            {
                var lblChecklistName = (Label)e.Row.FindControl("lblChecklistName");
                lblChecklistName.Text = ChecklistName.ToString();
            }
            catch (Exception ex)
            { }
        }

    }
    protected void ddlServicetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillChecklistName(Convert.ToInt32(hfAssetId.Value), ddlServicetype);
        PanelAssetChecklistNameDetail.Visible = false;
        divSubitem.Visible = false;
    }
    protected void gvAssetChecklistName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetChecklistName.PageIndex = e.NewPageIndex;
        gvAssetChecklistName.EditIndex = -1;
        FillChecklistName(Convert.ToInt32(hfAssetId.Value), ddlServicetype);
    }
    protected void gvAssetChecklistName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetChecklistName.PageIndex * gvAssetChecklistName.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
    }
    protected void lblChecklistNameDetail_Click(object sender, EventArgs e)
    {
        LinkButton lblChecklistNameDetail = sender as LinkButton;
        GridViewRow row = (GridViewRow)lblChecklistNameDetail.NamingContainer;
        HiddenField hfAssetCheckListDetailAutoId = (HiddenField)row.FindControl("hfAssetCheckListDetailAutoId");
        SubChecklistName = lblChecklistNameDetail.Text;
        SubChecklistid = Convert.ToInt32(hfAssetCheckListDetailAutoId.Value);
        FillSubChecklistName(Convert.ToInt32(hfAssetCheckListDetailAutoId.Value));
        divSubitem.Visible = true;
     
    }
    protected void gvChecklistdetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvChecklistdetail2.PageIndex * gvChecklistdetail2.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            // For Edit Item Template Control-------------------------------------
           
           DropDownList ddlValueType1 = (DropDownList)e.Row.FindControl("ddlValueType2");
           var ddlQuantitativeValueType = (DropDownList)e.Row.FindControl("ddlQuantitativeValueType");
           HiddenField hfValueType = (HiddenField)e.Row.FindControl("hfValueType2");
           HiddenField hfQuantitativeValueType = (HiddenField)e.Row.FindControl("hfQuantitativeValueType");
          
           if ((ddlValueType1 != null) && (hfValueType != null))
           {
               ddlValueType1.SelectedValue = hfValueType.Value;
               if (ddlValueType1.SelectedValue != "Qualitative")
               {
                   if ((ddlQuantitativeValueType != null) && (hfQuantitativeValueType != null))
                   {
                       ddlQuantitativeValueType.SelectedValue = hfQuantitativeValueType.Value;
                       Label lblmin1 = (Label)e.Row.FindControl("lblmin");
                       TextBox txtmin1 = (TextBox)e.Row.FindControl("txtmin");
                       Label lblmax1 = (Label)e.Row.FindControl("lblmax");
                       TextBox txtmax1 = (TextBox)e.Row.FindControl("txtmax");
                       if (ddlQuantitativeValueType.SelectedValue == "Range")
                       {
                           lblmin1.Visible = true;
                           txtmin1.Visible = true;
                           lblmax1.Visible = true;
                           txtmax1.Visible = true;
                         
                           if (txtmin1 != null)
                           {
                               txtmin1.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                               txtmin1.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                           }
                           if (txtmax1 != null)
                           {
                               txtmax1.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                               txtmax1.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                           }
                       }
                       else
                       {
                           lblmin1.Visible = false;
                           txtmin1.Visible = false;
                           lblmax1.Visible = false;
                           txtmax1.Visible = false;
                       }

                   }                 
               }
               else
               {  if (ddlQuantitativeValueType != null)
                   ddlQuantitativeValueType.Enabled = false;
               }
           }


            // For Item Template Control-------------------------------------

           var lblValuetype = (Label)e.Row.FindControl("lblValuetype");
           var lblQuantitativeValuetype = (Label)e.Row.FindControl("lblQuantitativeValuetype");
           var lblmin = (Label)e.Row.FindControl("lblmin1");
           var txtmin = (Label)e.Row.FindControl("txtmin1");
           var lblmax = (Label)e.Row.FindControl("lblmax1");
           var txtmax = (Label)e.Row.FindControl("txtmax1");

          if (lblValuetype != null)
          {
              if (lblValuetype.Text == "Qualitative")
              {
                  lblmin.Visible = false;
                  txtmin.Visible = false;
                  lblmax.Visible = false;
                  txtmax.Visible = false;
              }
              else
              {
                  gvChecklistdetail2.Columns[5].Visible = true;
                  if (lblQuantitativeValuetype.Text == "Text")
                  {
                      lblmin.Visible = false;
                      txtmin.Visible = false;
                      lblmax.Visible = false;
                      txtmax.Visible = false;
                  }

                  else
                  {
                      lblmin.Visible = true;
                      txtmin.Visible = true;
                      lblmax.Visible = true;
                      txtmax.Visible = true;

                      if (txtmin != null)
                      {
                          txtmin.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                          txtmin.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                      }
                      if (txtmax != null)
                      {
                          txtmax.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                          txtmax.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                      }
                  }
              }
          }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtmin = (TextBox)e.Row.FindControl("txtmin");
            var txtmax = (TextBox)e.Row.FindControl("txtmax");

            if (txtmin != null)
            {
                txtmin.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtmin.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            }
            if (txtmax != null)
            {
                txtmax.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtmax.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            }
            try
            {
                var lblsubChecklistName = (Label)e.Row.FindControl("lblsubChecklistName");
                lblsubChecklistName.Text = SubChecklistName.ToString();
              
            }
            catch (Exception ex)
            { }
        }
    }
    protected void gvChecklistdetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        //  var hfAssetCheckListNameAutoId = (HiddenField)gvAssetChecklistNameDetail.FooterRow.FindControl("hfAssetCheckListNameAutoId");

        var txtsubChecklistNameDetail = (TextBox)gvChecklistdetail2.FooterRow.FindControl("txtsubChecklistNameDetail");
        var ddlValueType = (DropDownList)gvChecklistdetail2.FooterRow.FindControl("ddlValueType");
        var ddlQuantitativeValueType = (DropDownList)gvChecklistdetail2.FooterRow.FindControl("ddlQuantitativeValueType");
        var txtmin = (TextBox)gvChecklistdetail2.FooterRow.FindControl("txtmin");
        var txtmax = (TextBox)gvChecklistdetail2.FooterRow.FindControl("txtmax");
        var rfvtxtmin = (RequiredFieldValidator)gvChecklistdetail2.FooterRow.FindControl("rfvtxtmin");
        var rfvtxtmax = (RequiredFieldValidator)gvChecklistdetail2.FooterRow.FindControl("rfvtxtmax");
        string Value;
        if (e.CommandName == "AddNew")
        {
            try
            {
                if (ddlValueType.SelectedItem.Value == "Qualitative")
                   Value = "";
                else
                    Value = ddlQuantitativeValueType.SelectedValue;
             
                ds = objAssetMgmt.SubChecklistItemNameInsert(SubChecklistid, Checklistid, txtsubChecklistNameDetail.Text.Trim(), ddlValueType.SelectedItem.Value, Value.ToString(), txtmin.Text, txtmax.Text, BaseUserID, BaseCompanyCode);
                lblmsg1.Text=ds.Tables[0].Rows[0]["MessageString"].ToString();
                txtsubChecklistNameDetail.Text = "";
                txtmin.Text = "";
                txtmax.Text = "";

               FillSubChecklistName(Convert.ToInt32(SubChecklistid));
            }
            catch (Exception ex)
            { }

        }
        if (e.CommandName == "Reset")
        {
            txtsubChecklistNameDetail.Text = "";
            txtmin.Text = "";
            txtmax.Text = "";
        }
    }
    protected void gvChecklistdetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        HiddenField hfAssetSubCheckListDetailAutoId = (HiddenField)gvChecklistdetail2.Rows[e.RowIndex].FindControl("hfAssetSubCheckListDetailAutoId");
        ds = objAssetMgmt.SubChecklistItemNameDelete(Convert.ToInt32(hfAssetSubCheckListDetailAutoId.Value),BaseCompanyCode);
        lblmsg1.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
        gvChecklistdetail2.EditIndex = -1;
        FillSubChecklistName(Convert.ToInt32(SubChecklistid));
    }
    protected void gvChecklistdetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvChecklistdetail2.EditIndex = e.NewEditIndex;
        FillSubChecklistName(Convert.ToInt32(SubChecklistid));
      
    }
    protected void gvChecklistdetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvChecklistdetail2.PageIndex = e.NewPageIndex;
        gvChecklistdetail2.EditIndex = -1;
        FillSubChecklistName(Convert.ToInt32(SubChecklistid));

    }
    protected void gvChecklistdetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetSubCheckListDetailAutoId = (HiddenField)gvChecklistdetail2.Rows[e.RowIndex].FindControl("hfAssetSubCheckListDetailAutoId");
        var txtsubChecklistNameDetail = (TextBox)gvChecklistdetail2.Rows[e.RowIndex].FindControl("txtsubChecklistNameDetail");
        var ddlValueType2 = (DropDownList)gvChecklistdetail2.Rows[e.RowIndex].FindControl("ddlValueType2");
        var ddlQuantitativeValueType = (DropDownList)gvChecklistdetail2.Rows[e.RowIndex].FindControl("ddlQuantitativeValueType");
        var txtmin = (TextBox)gvChecklistdetail2.Rows[e.RowIndex].FindControl("txtmin");
        var txtmax = (TextBox)gvChecklistdetail2.Rows[e.RowIndex].FindControl("txtmax");
        string Value;
        try
        {
            if (ddlValueType2.SelectedItem.Value == "Qualitative")
            {
                Value = "";
                txtmin.Text = "";
                txtmax.Text = "";
                ds = objAssetMgmt.SubChecklistItemNameUpdate(Convert.ToInt32(hfAssetSubCheckListDetailAutoId.Value), txtsubChecklistNameDetail.Text.Trim(), ddlValueType2.SelectedItem.Value, Value.ToString(), txtmin.Text, txtmax.Text, BaseUserID, BaseCompanyCode);
                lblmsg1.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                gvChecklistdetail2.EditIndex = -1;
                FillSubChecklistName(Convert.ToInt32(SubChecklistid));
            }
            else
            {
                Value = ddlQuantitativeValueType.SelectedValue;
                if(ddlQuantitativeValueType.SelectedValue=="Text")
                {
                    txtmin.Text = "";
                    txtmax.Text = "";
                    ds = objAssetMgmt.SubChecklistItemNameUpdate(Convert.ToInt32(hfAssetSubCheckListDetailAutoId.Value), txtsubChecklistNameDetail.Text.Trim(), ddlValueType2.SelectedItem.Value, Value.ToString(), txtmin.Text, txtmax.Text, BaseUserID, BaseCompanyCode);
                    lblmsg1.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                    gvChecklistdetail2.EditIndex = -1;
                    FillSubChecklistName(Convert.ToInt32(SubChecklistid));
                  
                }
                else
                {
                    if((txtmax.Text !="") && (txtmin.Text !=""))
                    { 
                    ds = objAssetMgmt.SubChecklistItemNameUpdate(Convert.ToInt32(hfAssetSubCheckListDetailAutoId.Value), txtsubChecklistNameDetail.Text.Trim(), ddlValueType2.SelectedItem.Value, Value.ToString(), txtmin.Text, txtmax.Text, BaseUserID, BaseCompanyCode);
                    lblmsg1.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                    gvChecklistdetail2.EditIndex = -1;
                    FillSubChecklistName(Convert.ToInt32(SubChecklistid));
                    }
                    else
                    {
                        lblmsg1.Text = "Range cann't be blank !!";
                    }
                }
            }
           
          
        }
        catch (Exception ex)
        { }

    }
    protected void gvChecklistdetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvChecklistdetail2.EditIndex = -1;
        FillSubChecklistName(Convert.ToInt32(SubChecklistid));

    }
    private void FillSubChecklistName(int SubChecklistId)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsChecklistName = new DataSet();
            var dtChecklistName = new DataTable();
            dtflag = 1;
            dsChecklistName = objAssetMgmt.GetSubChecklistName(Checklistid, SubChecklistId, BaseCompanyCode);
            dtChecklistName = dsChecklistName.Tables[0];
            if (dtChecklistName.Rows.Count == 0)
            {
                dtflag = 0;
                dtChecklistName.Rows.Add(dtChecklistName.NewRow());
            }
            gvChecklistdetail2.DataSource = dtChecklistName;
            gvChecklistdetail2.DataBind();
       
          
            if (dtflag == 0)
            {

                gvChecklistdetail2.Rows[0].Visible = false;
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
    protected void ddlQuantitativeValueType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList lb = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        Label lblmin = (Label)gvRow.FindControl("lblmin");
        TextBox txtmin = (TextBox)gvRow.FindControl("txtmin");
        Label lblmax = (Label)gvRow.FindControl("lblmax");
        TextBox txtmax = (TextBox)gvRow.FindControl("txtmax");
        txtmin.Text = "";
        txtmax.Text = "";
        if (lb.SelectedItem.Value=="Range")
        {
            lblmin.Visible = true;
            txtmin.Visible = true;
            lblmax.Visible = true;
            txtmax.Visible = true;
        }
        else
        {
            lblmin.Visible = false;
            txtmin.Visible = false;
            lblmax.Visible = false;
            txtmax.Visible = false;
        }
    }
    protected void ddlQuantitativeValueType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList lb = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        Label lblmin = (Label)gvRow.FindControl("lblmin");
        TextBox txtmin = (TextBox)gvRow.FindControl("txtmin");
        Label lblmax = (Label)gvRow.FindControl("lblmax");
        TextBox txtmax = (TextBox)gvRow.FindControl("txtmax");
        if (txtmin != null)
        {
            txtmin.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtmin.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (txtmax != null)
        {
            txtmax.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtmax.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        //txtmin.Text = "";
        //txtmax.Text = "";
        if (lb.SelectedItem.Value == "Range")
        {
            lblmin.Visible = true;
            txtmin.Visible = true;
            lblmax.Visible = true;
            txtmax.Visible = true;
        }
        else
        {
            lblmin.Visible = false;
            txtmin.Visible = false;
            lblmax.Visible = false;
            txtmax.Visible = false;
        }
    }
    protected void ddlValueType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList lbValue = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)lbValue.NamingContainer;
        DropDownList ddlQuantitativeValueType = (DropDownList)gvRow.FindControl("ddlQuantitativeValueType");

        Label lblmin = (Label)gvRow.FindControl("lblmin");
        TextBox txtmin = (TextBox)gvRow.FindControl("txtmin");
        Label lblmax = (Label)gvRow.FindControl("lblmax");
        TextBox txtmax = (TextBox)gvRow.FindControl("txtmax");
        if (lbValue.SelectedItem.Value == "Qualitative")
        {
            ddlQuantitativeValueType.Enabled = false;
            lblmin.Visible = false;
            txtmin.Visible = false;
            lblmax.Visible = false;
            txtmax.Visible = false;
            ddlQuantitativeValueType.SelectedValue = "Text";
        }
        else
        {
            ddlQuantitativeValueType.Enabled = true;
            txtmax.Text = "";
            txtmin.Text = "";
        }
    }
    protected void ddlValueType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList lbValue1 = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)lbValue1.NamingContainer;
        DropDownList ddlQuantitativeValueType = (DropDownList)gvRow.FindControl("ddlQuantitativeValueType");
        Label lblmin = (Label)gvRow.FindControl("lblmin");
        TextBox txtmin = (TextBox)gvRow.FindControl("txtmin");
        Label lblmax = (Label)gvRow.FindControl("lblmax");
        TextBox txtmax = (TextBox)gvRow.FindControl("txtmax");
        if (lbValue1.SelectedItem.Value == "Qualitative")
        {
            ddlQuantitativeValueType.Enabled = false;
            lblmin.Visible = false;
            txtmin.Visible = false;
            lblmax.Visible = false;
            txtmax.Visible = false;
            ddlQuantitativeValueType.SelectedValue = "Text";
        }
        else
        {
            ddlQuantitativeValueType.Enabled = true;
            //txtmax.Text = "";
            //txtmin.Text = "";
        }
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        txtToAssetCode.Attributes.Add("readonly", "readonly");
        txtToAssetCode.Text = txtAssetCode.Text;
        divCopyChecklist.Visible = true;
        MainItem.Visible = false;
        divSubitem.Visible = false;
    //    btncopyChecklist.Enabled = true;
        FillFromAssetService();

    }
    protected void btncopyChecklist_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            ds = objAssetMgmt.CopyAssetChecklist(txtToAssetCode.Text, ddlFromAssetCode.SelectedItem.Value, ddlFromAssetService.SelectedItem.Value, ddlFromAssetChecklist.SelectedItem.Value, ddlFromSubChecklist.SelectedItem.Value, BaseLocationAutoID, ddlFromAssetChecklist.SelectedItem.Text, ddlFromSubChecklist.SelectedItem.Text);
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
            {
                divCopyChecklist.Visible = false;
                MainItem.Visible = true;
                divSubitem.Visible = true;
                FillChecklistName(Convert.ToInt32(hfAssetId.Value), ddlServicetype);
            }
            else
            {
                lblNodata.Visible = true;
                lblNodata.Text = "Asset Checklist Already Exists !!";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void FillFromAssetService()
    {
        DataSet ds = new DataSet();
       
        BL.AssetManagement objAssetMgmt = new BL.AssetManagement();
        ds = objAssetMgmt.GetFromAssetServiceType(BaseLocationAutoID, txtAssetName.Text);
        if (ds.Tables[0].Rows[0]["MessgaeID"].ToString() == "0")
        {
            ddlFromAssetService.Items.Clear();
            ddlFromAssetService.DataSource = ds.Tables[0];
            ddlFromAssetService.DataTextField = "AssetServicetypename";
            ddlFromAssetService.DataValueField = "AssetServiceTypeautoID";
            ddlFromAssetService.DataBind();
            if (ddlFromAssetService.Text == "")
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlFromAssetService.Items.Add(li);
            }
            else
            {
                FillFromAssetCode(Convert.ToInt32(ddlFromAssetService.SelectedItem.Value));
            }
        }
        else
        {
            ddlFromAssetService.Items.Clear();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlFromAssetService.Items.Add(li);
            FillFromAssetCode(Convert.ToInt32(ddlFromAssetService.SelectedItem.Value));
        }
    }
    protected void FillFromAssetCode(int AssetServiceTypeautoID)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objAssetMgmt = new BL.AssetManagement();
          ds = objAssetMgmt.GetFromAssetCode(BaseLocationAutoID, AssetServiceTypeautoID,txtAssetCode.Text);
          if (ds.Tables[0].Rows[0]["MessgaeID"].ToString() == "0")
          {
              ddlFromAssetCode.Items.Clear();
              ddlFromAssetCode.DataSource = ds.Tables[0];
              ddlFromAssetCode.DataTextField = "AssetCodeName";
              ddlFromAssetCode.DataValueField = "AssetAutoID";
              ddlFromAssetCode.DataBind();
              if (ddlFromAssetCode.Text == "")
              {
                  ListItem li = new ListItem();
                  li.Text = Resources.Resource.NoData;
                  li.Value = "0";
                  ddlFromAssetCode.Items.Add(li);
              }
              else
              {
                  FillFromAssetChecklistName(AssetServiceTypeautoID, Convert.ToInt32(ddlFromAssetCode.SelectedItem.Value));
              }
          }
          else
          {
              ddlFromAssetCode.Items.Clear();
              ListItem li = new ListItem();
              li.Text = Resources.Resource.NoData;
              li.Value = "0";
              ddlFromAssetCode.Items.Add(li);
              FillFromAssetChecklistName(AssetServiceTypeautoID, Convert.ToInt32(ddlFromAssetCode.SelectedItem.Value));
          }
    }
    protected void FillFromAssetChecklistName(int AssetServiceTypeautoID, int AssetAutoID)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objAssetMgmt = new BL.AssetManagement();
         ds = objAssetMgmt.GetFromAssetChecklistName(AssetServiceTypeautoID, AssetAutoID);
         if (ds.Tables[0].Rows[0]["MessgaeID"].ToString() == "0")
         {
             ddlFromAssetChecklist.Items.Clear();
             ddlFromAssetChecklist.DataSource = ds.Tables[0];
             ddlFromAssetChecklist.DataTextField = "ChecklistName";
             ddlFromAssetChecklist.DataValueField = "AssetChecklistAutoID";
             ddlFromAssetChecklist.DataBind();
             if (ddlFromAssetChecklist.Text == "")
             {
                 ListItem li = new ListItem();
                 li.Text = Resources.Resource.NoData;
                 li.Value = "0";
                 ddlFromAssetChecklist.Items.Add(li);
             }
             else
             {
                 FillFromAssetSubChecklistName(Convert.ToInt32(ddlFromAssetChecklist.SelectedItem.Value));
             }
         }
         else
         {
             ddlFromAssetChecklist.Items.Clear();
             ListItem li = new ListItem();
             li.Text = Resources.Resource.NoData;
             li.Value = "0";
             ddlFromAssetChecklist.Items.Add(li);
             FillFromAssetSubChecklistName(Convert.ToInt32(ddlFromAssetChecklist.SelectedItem.Value));
         }
    }
    protected void FillFromAssetSubChecklistName(int AssetChecklistAutoID)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objAssetMgmt = new BL.AssetManagement();
          ds = objAssetMgmt.GetFromAssetSubChecklistName(AssetChecklistAutoID);
          if (ds.Tables[0].Rows[0]["MessgaeID"].ToString() == "0")
          {
              ddlFromSubChecklist.Items.Clear();
              ddlFromSubChecklist.DataSource = ds.Tables[0];
              ddlFromSubChecklist.DataTextField = "Items";
              ddlFromSubChecklist.DataValueField = "AssetChecklistDetailAutoID";
              ddlFromSubChecklist.DataBind();
              if (ddlFromSubChecklist.Text == "")
              {
                  ListItem li = new ListItem();
                  li.Text = Resources.Resource.NoData;
                  li.Value = "0";
                  ddlFromSubChecklist.Items.Add(li);
              }
              else
              {
                  FillFromAssetItems(AssetChecklistAutoID, Convert.ToInt32(ddlFromSubChecklist.SelectedItem.Value));
              }
          }
          else
          {
              ddlFromSubChecklist.Items.Clear();
              ListItem li = new ListItem();
              li.Text = Resources.Resource.NoData;
              li.Value = "0";
              ddlFromSubChecklist.Items.Add(li);
              FillFromAssetItems(AssetChecklistAutoID, Convert.ToInt32(ddlFromSubChecklist.SelectedItem.Value));
          }
    }
    protected void FillFromAssetItems(int AssetChecklistAutoID, int AssetChecklistDetailAutoID)
    {
        btncopyChecklist.Visible = true;
        DataSet ds = new DataSet();
        BL.AssetManagement objAssetMgmt = new BL.AssetManagement();
        ds = objAssetMgmt.GetFromAssetItems(AssetChecklistAutoID, AssetChecklistDetailAutoID);
        if (ds.Tables[0].Rows[0]["MessgaeID"].ToString() == "0")
        {
            ddlFromAssetItems.Items.Clear();
            ddlFromAssetItems.DataSource = ds.Tables[0];
            ddlFromAssetItems.DataTextField = "SubItems";
            ddlFromAssetItems.DataValueField = "AssetSubChecklistDetailAutoID";
            ddlFromAssetItems.DataBind();
            lblNodata.Visible = false;
            ddlFromAssetItems.Items.Insert(0, new ListItem("--Select ALL--", "0"));
            if (ddlFromAssetItems.Text == "")
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlFromAssetItems.Items.Add(li);
                btncopyChecklist.ToolTip = "No Checklist Exist.";
              
            }
        }
        else
        {
            ddlFromAssetItems.Items.Clear();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlFromAssetItems.Items.Add(li);
            btncopyChecklist.ToolTip = "No Checklist Exist.";
         //   btncopyChecklist.BackColor = System.Drawing.Color.Red;
          
            lblNodata.Visible = true;
            btncopyChecklist.Visible = false;
        }
    }
    protected void btnbackcopy_Click(object sender, EventArgs e)
    {
        divCopyChecklist.Visible = false;
        MainItem.Visible = true;
        divSubitem.Visible = true;
    }
    protected void ddlFromAssetService_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFromAssetCode(Convert.ToInt32(ddlFromAssetService.SelectedItem.Value));
    }
    protected void ddlFromAssetCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFromAssetChecklistName(Convert.ToInt32(ddlFromAssetService.SelectedItem.Value), Convert.ToInt32(ddlFromAssetCode.SelectedItem.Value));
    }
    protected void ddlFromAssetChecklist_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFromAssetSubChecklistName(Convert.ToInt32(ddlFromAssetChecklist.SelectedItem.Value));
    }
    protected void ddlFromSubChecklist_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFromAssetItems(Convert.ToInt32(ddlFromAssetChecklist.SelectedItem.Value), Convert.ToInt32(ddlFromSubChecklist.SelectedItem.Value));
    }
}