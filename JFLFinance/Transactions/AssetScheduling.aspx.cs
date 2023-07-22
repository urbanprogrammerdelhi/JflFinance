using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transactions_AssetScheduling : BasePage
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillddlAreaId();
                FillddlAsmt();
                FillddlPost();
                txtServiceDate.Attributes.Add("readonly", "readonly");
                txtServiceDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
        ImgClientCode_CCH.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + txtClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=360,help=no')");
        //txtServiceDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
    }

    private void SetTimeValidationToTextBox(object textBox)
    {
        if (textBox != null)
        {
            var TimeTextBox = (TextBox)textBox;
            TimeTextBox.Attributes["onKeyUp"] = "javascript:Timevalnum('" + TimeTextBox.ClientID + "');";
            TimeTextBox.Attributes["onblur"] = "javascript:IsValidTime('" + TimeTextBox.ClientID + "');";
        }
    }

    #region Binding
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaId()
    {
        ListItem li;

        var objSale = new BL.OperationManagement();
        DataSet dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();

            li = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAreaID.Items.Insert(0, li);

            FillddlClient();
        }
        if (ddlAreaID.Text == "")
        {
            li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlAreaID.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        ddlClient.Items.Clear();
        ddlAsmt.Items.Clear();
        var objSale = new BL.Sales();
        var ds = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID) : objSale.ClientsMappedToLocationGet(BaseLocationAutoID,
            ddlAreaID.SelectedItem.Value, txtClientCode.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientCodeName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();
            FillddlAsmt();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlClient.Items.Add(li);
            ddlAsmt.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ddlAsmt.Items.Clear();
        var objSale = new BL.Sales();
        DataSet ds = objSale.ClientDetailsGet(BaseLocationAutoID, ddlClient.SelectedItem.Value, ddlAreaID.SelectedItem.Value, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var dv = new DataView(ds.Tables[0]) { RowFilter = "IsBillable = False" };
            if (dv.Count > 0)
            {
                ddlAsmt.DataSource = dv.ToTable();
                ddlAsmt.DataTextField = "AsmtAddress";
                ddlAsmt.DataValueField = "AsmtId";
                ddlAsmt.DataBind();
                FillddlPost();
            }
            else
            {
                var li = new ListItem
                {
                    Text = @Resources.Resource.NoDataToShow,
                    Value = string.Empty
                };
                ddlAsmt.Items.Add(li);
                ddlPost.Items.Add(li);
            }
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlAsmt.Items.Add(li);
            ddlPost.Items.Add(li);
        }
    }

    /// <summary>
    /// Fillddls the post.
    /// </summary>
    /// <param name="ddlPost">The DDL post.</param>
    protected void FillddlPost()
    {
        var objSale = new BL.Sales();
        DataSet ds = objSale.PostGetAll(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlPost.DataSource = ds.Tables[0];
            ddlPost.DataTextField = "PostDesc";
            ddlPost.DataValueField = "PostAutoId";
            ddlPost.DataBind();
        }
        else
        {
            var li = new ListItem { Text = Resources.Resource.AddNew, Value = string.Empty };
            ddlPost.Items.Add(li);
        }
    }
    #endregion

    #region Controles

    /// <summary>
    /// Handles the TextChanged event of the txtClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtClientCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ddlClient.SelectedValue = txtClientCode.Text;
            FillddlAsmt();
        }
        catch (Exception) { }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClientCode.Text = string.Empty;
        FillddlClient();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClientCode.Text = string.Empty;
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPost();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtServiceDate.Text) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
        {
            FillgvAssetScheduling();
        }
        else
        {
            lblErrorMsg.Text = "You can't Schedule on this Date";
            gvAssetScheduling.Visible = false;
        }
    }
    protected void gvAssetScheduling_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetScheduling.PageIndex = e.NewPageIndex;
        gvAssetScheduling.EditIndex = -1;
        FillgvAssetScheduling();
    }
    protected void gvAssetScheduling_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            //  var IsChecked = (HiddenField)e.Row.FindControl("IsChecked");
            //var chkRollOver = (CheckBox)e.Row.FindControl("chkRollOver");
            //if (IsChecked.Value == "0")
            //{
            //    chkRollOver.Checked = false;
            //}
            //else
            //{
            //    chkRollOver.Checked = true;
            //}
        }
        var txtFromTime = (TextBox)e.Row.FindControl("txtFromTime");
        var txtToTime = (TextBox)e.Row.FindControl("txtToTime");

        SetTimeValidationToTextBox(txtFromTime);
        SetTimeValidationToTextBox(txtToTime);
    }
    private void FillgvAssetScheduling()
    {
        DataSet ds = new DataSet();
        BL.AssetScheduling objAS = new BL.AssetScheduling();
        if (ddlClient.SelectedItem.Value != string.Empty && ddlAsmt.SelectedItem.Value != string.Empty && ddlPost.SelectedItem.Value != string.Empty && txtServiceDate.Text != string.Empty)
        {
            lblErrorMsg.Text = String.Empty;
            ds = objAS.AssetScheduleGet(BaseLocationAutoID, ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value, ddlPost.SelectedItem.Value, txtServiceDate.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvAssetScheduling.Visible = true;
                gvAssetScheduling.DataSource = ds;
                gvAssetScheduling.DataBind();
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
                gvAssetScheduling.Visible = false;
            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAssetScheduling_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

        var txtEmployeeNumber = (TextBox)row.FindControl("txtEmployeeNumber");
        var txtEmployeeName = (TextBox)row.FindControl("txtEmployeeName");
        var txtFromTime = (TextBox)row.FindControl("txtFromTime");
        var txtToTime = (TextBox)row.FindControl("txtToTime");

        var hfFromTime = (HiddenField)row.FindControl("hfFromTime");
        var hfToTime = (HiddenField)row.FindControl("hfToTime");

        var hfAssetScheduleAutoId = (HiddenField)row.FindControl("hfAssetScheduleAutoId");
        var hfAssetWoNo = (HiddenField)row.FindControl("hfAssetWoNo");
        var hfAssetWoLineNo = (HiddenField)row.FindControl("hfAssetWoLineNo");
        var hfAssetAutoId = (HiddenField)row.FindControl("hfAssetAutoId");
        var hfAssetServiceTypeAutoId = (HiddenField)row.FindControl("hfAssetServiceTypeAutoId");
        //   var chkRollOver = (CheckBox)row.FindControl("chkRollOver");

        if (e.CommandName == "Add")
        {
            var objAS = new BL.AssetScheduling();
            //int Checkboxvalue=0;
            //if (chkRollOver.Checked)
            //{
            //    Checkboxvalue = 1;
            //}
            //else
            //{
            //    Checkboxvalue = 0;
            //}

            if (txtEmployeeNumber.Text != string.Empty && txtFromTime.Text != string.Empty && txtToTime.Text != string.Empty)
            {
                //DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.Value, BaseLocationAutoID, ddlClient.SelectedItem.Value,
                //    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
                //    hfAssetServiceTypeAutoId.Value, "", txtServiceDate.Text, hfFromTime.Value, hfToTime.Value, txtEmployeeNumber.Text,
                //    txtFromTime.Text, txtToTime.Text, BaseUserID, Convert.ToInt32(Checkboxvalue));
                DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.Value, BaseLocationAutoID, ddlClient.SelectedItem.Value,
    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
    hfAssetServiceTypeAutoId.Value, "", txtServiceDate.Text, hfFromTime.Value, hfToTime.Value, txtEmployeeNumber.Text,
    txtFromTime.Text, txtToTime.Text, BaseUserID);
                FillgvAssetScheduling();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
        }
        if (e.CommandName == "Reset")
        {
            txtEmployeeNumber.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtFromTime.Text = hfFromTime.Value;
            txtToTime.Text = hfToTime.Value;
            //  chkRollOver.Checked = false;
        }
    }
    #endregion
}