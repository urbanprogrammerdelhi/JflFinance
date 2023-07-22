using System;
using System.Data;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class Sales_CreateOrder : BasePage
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
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                HfId.Value = Request.QueryString["WorkOrderAutoId"];
                if (HfId.Value != "")
                {
                    FillDetailsForUpdate(HfId.Value);
                    btnedit.Visible = true;
                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                    ddlServiceType.Enabled = false;
                    ddlUserId.Enabled = false;
                }
                else
                {
                    btnedit.Visible = false;
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                    ddlServiceType.Enabled = true;
                    ddlUserId.Enabled = true;

                }
                #region validation for Order Fields
                

                //if (txtPreferedToTime != null)
                //{
                //    txtPreferedToTime.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                //    txtPreferedToTime.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                //}
                //if (txtPreferedFromTime != null)
                //{
                //    txtPreferedFromTime.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                //    txtPreferedFromTime.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                //}
                if (txtMobile != null)
                {
                    txtMobile.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                    txtMobile.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionPhone + ");");
                }
                if (txtBuildingNumber != null)
                {
                    txtBuildingNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtBuildingNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtFloorNumber != null)
                {
                    txtFloorNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtFloorNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtLocality != null)
                {
                    txtLocality.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtLocality.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtCity != null)
                {
                    txtCity.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtCity.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtLandmark != null)
                {
                    txtLandmark.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtLandmark.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtPincode != null)
                {
                    txtPincode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                    txtPincode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                }
                #endregion
               
                    FillddlNewState(ddlState, ddlDistrict, string.Empty);
                    FillddlService();
                    FillddlUserId();
                    if (!IsWriteAccess)
                    {
                        btnSubmit.Visible = false;
                    }
                    if (!IsModifyAccess)
                    {
                        btnedit.Visible = false;
                    }

               
                txtPreferedFromDate.Attributes.Add("readonly", "readonly");
                txtPreferedToDate.Attributes.Add("readonly", "readonly");
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objSales = new BL.Sales();
        try
        {
            string LatnLong = "0";
            if (DateTime.Parse(txtPreferedToDate.Text) >= DateTime.Parse(txtPreferedFromDate.Text))
            {
                ds = objSales.CreateOrder(ddlUserId.SelectedItem.Value, txtUserName.Text, txtUserEmail.Text, "", Convert.ToInt32(ddlServiceType.SelectedValue), txtPreferedFromDate.Text, txtPreferedToDate.Text, txtPreferedFromTime.Text, txtPreferedToTime.Text, txtMobile.Text, txtBuildingNumber.Text, txtFloorNumber.Text, txtLocality.Text, txtLandmark.Text, txtCity.Text, ddlDistrict.SelectedValue, ddlState.SelectedValue, txtPincode.Text, BaseUserID, DateTime.Today.ToString("dd-MMM-yyyy"), Convert.ToDecimal(LatnLong), Convert.ToDecimal(LatnLong),"NEW");
               // DisplayMessage(lblCreateOrder, ds.Tables[0].Rows[0]["MessageId"].ToString());
                Response.Redirect("WorkOrderList.aspx");
            }
            else
            {
                lblCreateOrder.Text = "To Date must be greater than From Date";
            }
        }
        catch (Exception ex)
        { }
    }
    public void reset()
    {
        txtPreferedFromDate.Text = "";
        txtPreferedFromTime.Text = "";
        txtPreferedToDate.Text = "";
        txtPreferedToTime.Text = "";
        txtMobile.Text = "";
        txtBuildingNumber.Text = "";
        txtFloorNumber.Text = "";
        txtLocality.Text = "";
        txtCity.Text = "";
        txtLandmark.Text = "";
        txtPincode.Text = "";
        Response.Redirect("WorkOrderMaster.aspx");
        
    }
    private void FillddlService ()
    {
       var objSales = new BL.Sales();
        var ds = new DataSet();
        ds = objSales.GetService();
        ddlServiceType.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {   ddlServiceType.DataSource = ds.Tables[0];
            ddlServiceType.DataTextField = "AssetServiceTypeName";
            ddlServiceType.DataValueField = "AssetServiceTypeAutoId";
            ddlServiceType.DataBind();
        }
        else
        {
            ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlServiceType.Items.Add(li);
        }
    }
   
    private void FillddlNewState(DropDownList ddlState, DropDownList ddlDistrict, string StateId)
    {
        var objHrMGt = new BL.HRManagement();
        var ds = new DataSet();
        ds = objHrMGt.GetState();
        ddlState.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlState.DataSource = ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();
            if (StateId != string.Empty)
                ddlState.SelectedValue = StateId;
        }
        else
        {
            ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlState.Items.Add(li);
        }

        FillddlNewDistrict(ddlState, ddlDistrict);
    }

    private void FillddlNewDistrict(DropDownList ddlState, DropDownList ddlDistrict)
    {
        if (ddlState != null)
        {
            if (ddlState.SelectedValue != string.Empty)
            {
                var objHrMGt = new BL.HRManagement();
                var ds1 = new DataSet();
                ds1 = objHrMGt.GetDistrict(ddlState.SelectedValue);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    ddlDistrict.DataSource = ds1.Tables[0];
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataBind();
                }
                else
                {
                    ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                    ddlDistrict.Items.Add(li);
                }
            }
            else
            {
                ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                ddlDistrict.Items.Add(li);
            }
        }

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlNewDistrict(ddlState, ddlDistrict);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkOrderList.aspx");

    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objSales = new BL.Sales();
        try
        {
            string LatnLong = "0";
            if (DateTime.Parse(txtPreferedToDate.Text) > DateTime.Parse(txtPreferedFromDate.Text))
            {
                ds = objSales.UpdateWorkOrder(Convert.ToInt32(HfId.Value), ddlUserId.SelectedValue, "", Convert.ToInt32(ddlServiceType.SelectedValue), txtPreferedFromDate.Text, txtPreferedToDate.Text, txtPreferedFromTime.Text, txtPreferedToTime.Text, txtMobile.Text, txtBuildingNumber.Text, txtFloorNumber.Text, txtLocality.Text, txtLandmark.Text, txtCity.Text, ddlDistrict.SelectedValue, ddlState.SelectedValue, txtPincode.Text, BaseUserID, DateTime.Today.ToString("dd-MMM-yyyy"), Convert.ToDecimal(LatnLong), Convert.ToDecimal(LatnLong));
                DisplayMessage(lblCreateOrder, ds.Tables[0].Rows[0]["MessageId"].ToString());
                //Response.Redirect("WorkOrderList.aspx");
            }
            else
            {
                lblCreateOrder.Text = "To Date must be greater than From Date";
            }
        }
        catch (Exception ex)
        { }
    }

    private void FillDetailsForUpdate(string WorkOrderAutoId)
    {
        var objSales = new BL.Sales();
        var ds = objSales.WorkOrderDetailForUpdate(WorkOrderAutoId);
        try
        {
            txtPreferedFromDate.Text =DateFormat( ds.Tables[0].Rows[0]["PreferredFromDate"].ToString());
            txtPreferedToDate.Text = DateFormat(ds.Tables[0].Rows[0]["PreferredToDate"].ToString());
            txtPreferedFromTime.Text = ds.Tables[0].Rows[0]["PreferredFromTime"].ToString();
            txtPreferedToTime.Text = ds.Tables[0].Rows[0]["PreferredToTime"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
            txtBuildingNumber.Text = ds.Tables[0].Rows[0]["BuildingNo"].ToString();
            txtFloorNumber.Text = ds.Tables[0].Rows[0]["FloorNo"].ToString();
            txtLocality.Text = ds.Tables[0].Rows[0]["Locality"].ToString();
            txtLandmark.Text = ds.Tables[0].Rows[0]["Landmark"].ToString();
            ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["District"].ToString();
            ddlState.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
            ddlServiceType.SelectedValue = ds.Tables[0].Rows[0]["ServiceAutoId"].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0]["PIN"].ToString();
            txtUserName.Text = ds.Tables[0].Rows[0]["Username"].ToString();
            txtUserEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
            ddlUserId.SelectedValue = ds.Tables[0].Rows[0]["UserId"].ToString();
           
        }
        catch (Exception ex)
        {
            // ignored
        }
    }
    protected void ddlUserId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlUserId.SelectedValue !="Select")
        {
            var objSales = new BL.Sales();
            var ds = new DataSet();
            ds = objSales.GetUserIdDetails(ddlUserId.SelectedValue);
            txtUserName.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtUserEmail.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();

        }
        else
        {
            txtUserEmail.Text = "";
            txtUserName.Text = "";
        }
    }
    private void FillddlUserId()
    {
        var objSales = new BL.Sales();
        var ds = new DataSet();
        ds = objSales.GetUserId();
        ddlUserId.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlUserId.DataSource = ds.Tables[0];
            ddlUserId.DataTextField = "UserId";
            ddlUserId.DataValueField = "UserId";
            ddlUserId.DataBind();
            ddlUserId.Items.Insert(0, new ListItem("Select User Id", "Select"));

        }
        else
        {
            ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlUserId.Items.Add(li);
        }
    }
   
}