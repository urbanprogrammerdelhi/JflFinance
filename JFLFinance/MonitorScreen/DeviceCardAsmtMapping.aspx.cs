using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Language
/// </summary>
public partial class MonitorScreen_DeviceCardAsmtMapping : BasePage//System.Web.UI.Page
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
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.LanguageMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess)
            {
                FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    #endregion

    #region Function to Fill GridView
    /// <summary>
    /// Fillgvs the DeviceCardAsmtMapping.
    /// </summary>
    private void FillgvDeviceCardAsmtMapping(DropDownList ddlselect, TextBox txtsearch)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable Dcam = new DataTable();
        ds = objblMasterManagement.DeviceCardAsmtMappingGetAll(BaseLocationAutoID, ddlselect.SelectedValue, txtsearch.Text);
        Dcam = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && Dcam.Rows.Count > 0)
        {
            gvDeviceCardAsmtMapping.DataSource = Dcam;
            gvDeviceCardAsmtMapping.DataBind();
        }
        else
        {
            Dcam = ds.Tables[0];
            Dcam.Rows.Add(Dcam.NewRow());
            gvDeviceCardAsmtMapping.DataSource = Dcam;
            gvDeviceCardAsmtMapping.DataBind();
            gvDeviceCardAsmtMapping.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvDeviceCardAsmtMapping_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        var ddlClientCode = (DropDownList)gvDeviceCardAsmtMapping.FooterRow.FindControl("ddlClientCode");
        var ddlAsmtid = (DropDownList)gvDeviceCardAsmtMapping.FooterRow.FindControl("ddlAsmtid");
        TextBox txtNewAsmtCardNo = (TextBox)gvDeviceCardAsmtMapping.FooterRow.FindControl("txtNewAsmtCardNo");
        TextBox txtEffectiveFromDate = (TextBox)gvDeviceCardAsmtMapping.FooterRow.FindControl("txtEffectiveFromDate");
        TextBox txtEffectiveToDate = (TextBox)gvDeviceCardAsmtMapping.FooterRow.FindControl("txtEffectiveToDate");
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        if (txtEffectiveToDate.Text != "")
        {
            if (DateTime.Parse(txtEffectiveFromDate.Text) > DateTime.Parse(txtEffectiveToDate.Text))
            {
                lblErrorMsg.Text = "FromDate Can't be greater then ToDate";
            }
            else
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    ds = objblMasterManagement.DeviceCardAsmtMappingAddNew(BaseLocationAutoID, ddlClientCode.SelectedValue, ddlAsmtid.SelectedValue, txtNewAsmtCardNo.Text, txtEffectiveFromDate.Text, txtEffectiveToDate.Text, BaseUserID);
                    
                    FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            if (e.CommandName.Equals("Reset"))
            {
                txtNewAsmtCardNo.Text = "";
                txtEffectiveFromDate.Text = "";
                txtEffectiveToDate.Text = "";
                lblErrorMsg.Text = "";
            }
        }
        else
        {
            if (e.CommandName.Equals("AddNew"))
            {
                ds = objblMasterManagement.DeviceCardAsmtMappingAddNew(BaseLocationAutoID, ddlClientCode.SelectedValue, ddlAsmtid.SelectedValue, txtNewAsmtCardNo.Text, txtEffectiveFromDate.Text, txtEffectiveToDate.Text, BaseUserID);
                FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvDeviceCardAsmtMapping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!IsDeleteAccess)
            {
                var IBDeleteLang = (ImageButton)e.Row.FindControl("IBDeleteLang");
                if (IBDeleteLang != null)
                {
                    IBDeleteLang.Visible = false;
                }
            }
            if (!IsModifyAccess)
            {
                var ImgbtnUpdateLang = (ImageButton)e.Row.FindControl("ImgbtnUpdateLang");
                if (ImgbtnUpdateLang != null)
                {
                    ImgbtnUpdateLang.Visible = false;
                }
            }
            HiddenField hfClientCode = (HiddenField)e.Row.FindControl("hfClientCode");
            HiddenField hfAsmtId = (HiddenField)e.Row.FindControl("hfAsmtId");
            DropDownList ddlClientCode = (DropDownList)e.Row.FindControl("ddlClientCode");
            DropDownList ddlAsmtid = (DropDownList)e.Row.FindControl("ddlAsmtid");
            if (hfClientCode != null && ddlClientCode != null && ddlAsmtid != null)
            {
                FillddlClientCode(ddlClientCode, ddlAsmtid, hfAsmtId.Value);
                ddlAsmtid.SelectedValue = hfAsmtId.Value;
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {
                DropDownList ddlClientCode = (DropDownList)e.Row.FindControl("ddlClientCode");
                DropDownList ddlNewAsmtId = (DropDownList)e.Row.FindControl("ddlAsmtId");
                FillddlClientCode(ddlClientCode, ddlNewAsmtId, string.Empty);
            }
        }
        else
        {
            var lbADD = (ImageButton)e.Row.FindControl("lbADD");
            if (lbADD != null)
            {
                lbADD.Visible = false;
                gvDeviceCardAsmtMapping.ShowFooter = false;
            }
        }
    }
    /// <summary>
    /// To Fill the ClientCode
    /// </summary>
    /// <param name="ddlClientCode"></param>
    /// <param name="ddlAsmtid"></param>
    /// <param name="hfClientCode"></param>
    private void FillddlClientCode(DropDownList ddlClientCode, DropDownList ddlAsmtid, string hfClientCode)
    {
        //var objHrMGt = new BL.MastersManagement();
        var ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        ds = objsales.ClientsMappedToLocationGet(BaseLocationAutoID, "", "", BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        ddlClientCode.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientCodeName";
            ddlClientCode.DataValueField = "clientcode";
            ddlClientCode.DataBind();
            if (hfClientCode != string.Empty)
                ddlClientCode.SelectedValue = hfClientCode;
        }
        else
        {
            ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlClientCode.Items.Add(li);
        }

        FillddlAsmtId(ddlClientCode, ddlAsmtid);
    }
    /// <summary>
    /// Fill the Asmt Identifier
    /// </summary>
    /// <param name="ddlClientCode"></param>
    /// <param name="ddlAsmtid"></param>
    private void FillddlAsmtId(DropDownList ddlClientCode, DropDownList ddlAsmtid)
    {
        if (ddlClientCode != null)
        {
            if (ddlClientCode.SelectedValue != string.Empty)
            {
               // var objHrMGt = new BL.MastersManagement();
                BL.Sales objsales = new BL.Sales();
                var ds2 = new DataSet();
                ds2 = objsales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), BaseUserEmployeeNumber, "");
                if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    ddlAsmtid.DataSource = ds2.Tables[0];
                    ddlAsmtid.DataTextField = "AsmtIDAddress";
                    ddlAsmtid.DataValueField = "AsmtID";
                    ddlAsmtid.DataBind();
                }
                else
                {
                    ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                    ddlAsmtid.Items.Add(li);
                }
            }
            else
            {
                ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                ddlAsmtid.Items.Add(li);
            }
        }
    }
    protected void ddlEditClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlEditClientCode = sender as DropDownList;
        foreach (GridViewRow row in gvDeviceCardAsmtMapping.Rows)
        {
            DropDownList ddlClientCode = row.FindControl("ddlClientCode") as DropDownList;
            DropDownList ddlAsmtid = row.FindControl("ddlAsmtid") as DropDownList;
            FillddlAsmtId(ddlClientCode, ddlAsmtid);
        }
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlClientCode = (DropDownList)gvDeviceCardAsmtMapping.FooterRow.FindControl("ddlClientCode");
        DropDownList ddlAsmtid = (DropDownList)gvDeviceCardAsmtMapping.FooterRow.FindControl("ddlAsmtid");
        FillddlAsmtId(ddlClientCode, ddlAsmtid);
    }


    /// <summary>
    /// Handles the RowEditing event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvDeviceCardAsmtMapping_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDeviceCardAsmtMapping.EditIndex = e.NewEditIndex;
        FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvDeviceCardAsmtMapping_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objblMastermanagement = new BL.MastersManagement();
        Label lbleditClientCode = (Label)gvDeviceCardAsmtMapping.Rows[e.RowIndex].FindControl("lbleditClientCode");
        Label lbleditAsmtid = (Label)gvDeviceCardAsmtMapping.Rows[e.RowIndex].FindControl("lbleditAsmtid");
        TextBox txtAsmtCardNo = (TextBox)gvDeviceCardAsmtMapping.Rows[e.RowIndex].FindControl("txtAsmtCardNo");
        TextBox txtEffectiveFromDate = (TextBox)gvDeviceCardAsmtMapping.Rows[e.RowIndex].FindControl("txtEffectiveFromDate");
        TextBox txtEffectiveToDate = (TextBox)gvDeviceCardAsmtMapping.Rows[e.RowIndex].FindControl("txtEffectiveToDate");

        if (txtEffectiveToDate.Text != "")
        {
            if (DateTime.Parse(txtEffectiveFromDate.Text) > DateTime.Parse(txtEffectiveToDate.Text))
            {
                lblErrorMsg.Text = "FromDate Can't be greater then ToDate";
            }
            else
            {
                ds = objblMastermanagement.DeviceCardAsmtMappingUpdate(BaseLocationAutoID, lbleditClientCode.Text, lbleditAsmtid.Text, txtAsmtCardNo.Text, txtEffectiveFromDate.Text, txtEffectiveToDate.Text, BaseUserID);
                gvDeviceCardAsmtMapping.EditIndex = -1;
                FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        else
        {
            ds = objblMastermanagement.DeviceCardAsmtMappingUpdate(BaseLocationAutoID, lbleditClientCode.Text, lbleditAsmtid.Text, txtAsmtCardNo.Text, txtEffectiveFromDate.Text, txtEffectiveToDate.Text, BaseUserID);
            gvDeviceCardAsmtMapping.EditIndex = -1;
            FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvDeviceCardAsmtMapping_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDeviceCardAsmtMapping.EditIndex = -1;
        FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvDeviceCardAsmtMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();

        var objblMasterManagement = new BL.MastersManagement();

        //  string abc = gvAsmtMapping.DataKeys[e.RowIndex].Value.ToString();
        HiddenField ID = (HiddenField)gvDeviceCardAsmtMapping.Rows[e.RowIndex].FindControl("hfCardAsmtMappingAutoId");
        Label lblCardNo = (Label)gvDeviceCardAsmtMapping.Rows[e.RowIndex].FindControl("lblCardNo");
        ds = objblMasterManagement.DeviceCardAsmtMappingDelete(ID.Value, lblCardNo.Text);
        FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvDeviceCardAsmtMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDeviceCardAsmtMapping.PageIndex = e.NewPageIndex;
        gvDeviceCardAsmtMapping.EditIndex = -1;
        FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
    }
    #endregion

    protected void gvDeviceCardAsmtMapping_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handels the search event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewSearchEventArgs"/>instance containing the event data.</param>
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
    }
    /// <summary>
    /// Handels the ViewAll event of the gvDeviceCardAsmtMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewViewAllEventArgs"/>instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        FillgvDeviceCardAsmtMapping(ddlselect, txtSearch);
    }
}
