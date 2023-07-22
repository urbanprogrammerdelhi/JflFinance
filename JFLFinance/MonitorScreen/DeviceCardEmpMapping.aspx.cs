using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class MonitorScreen_DeviceCardEmpMapping : BasePage
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

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillgvDeviceCardEmpMapping(ddlselect, txtsearch);
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }

        }
    }
    protected void imgSearchEmp_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
        // HiddenField PassportId = (HiddenField)row.FindControl("PassportId");
        TextBox txtEmployeeNumber = (TextBox)row.FindControl("txtEmployeeNumber");
        TextBox txtEmployeeCardNumber = (TextBox)row.FindControl("txtEmployeeCardNumber");
        TextBox txtEmployeeName = (TextBox)row.FindControl("txtEmployeeName");
        // string url = "EmployeeDocumentMaster.aspx?Id=" + PassportId.Value + "&IdNo=" + Idnumber.Value;
        //string url = "DeviceCardEmployeeListing.aspx";
        // string s = "window.open('" + url + "', 'ModalPopUp', 'width=1000,height=600,left=100,top=100,resizable=0,location=no,toolbar=no,menubar=no,status=yes');";
        string s = "window.open('../search/commonSearch.aspx?SearchId=CCHEMP&ControlId=" + txtEmployeeNumber.ClientID.ToString() + "&ControlId1=" + txtEmployeeName.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')";
        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        // imgSearchEmp.Attributes.Add("onClick", );


    }


    protected void FillgvDeviceCardEmpMapping(DropDownList ddlselect, TextBox txtSearch)
    {
        try
        {
            int dtflag;
            var objBloperationManagement = new BL.OperationManagement();
            DataTable dtCardMapping = new DataTable();
            // string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
            DataSet dsCardMapping = objBloperationManagement.GetEmployeeCardMapping(BaseCompanyCode, ddlselect.SelectedValue, txtsearch.Text);
            dtflag = 1;
            dtCardMapping = dsCardMapping.Tables[0];
            if (dtCardMapping.Rows.Count == 0)
            {
                dtflag = 0;
                dtCardMapping.Rows.Add(dtCardMapping.NewRow());
            }
            gvDeviceCardEmpMapping.DataSource = dtCardMapping;
            gvDeviceCardEmpMapping.DataBind();
            if (dtflag == 0)
            {
                gvDeviceCardEmpMapping.Rows[0].Visible = false;
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
    protected void gvDeviceCardEmpMapping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(!IsDeleteAccess)
            {
                var IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Visible = false;
                }

            }
            if(!IsModifyAccess)
            {
                var IBEditTran = (ImageButton)e.Row.FindControl("IBEditTran");
                if (IBEditTran != null)
                    IBEditTran.Visible= false;

            }
            var txtEmployeeCardNumber = (TextBox)e.Row.FindControl("txtEmployeeCardNumber");

            if (txtEmployeeCardNumber != null)
            {
                txtEmployeeCardNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEmployeeCardNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {
                var txtEmployeeCardNumber = (TextBox)e.Row.FindControl("txtEmployeeCardNumber");
                var txtEmployeeNumber = (TextBox)e.Row.FindControl("txtEmployeeNumber");
                if (txtEmployeeCardNumber != null)
                {
                    txtEmployeeCardNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtEmployeeCardNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtEmployeeNumber != null)
                {
                    txtEmployeeNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtEmployeeNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
            }
            else
            {
                var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if(lbADD!=null)
                {
                    lbADD.Visible = false;
                    gvDeviceCardEmpMapping.ShowFooter = false;
                }
            }
        }

    }
    protected void gvDeviceCardEmpMapping_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDeviceCardEmpMapping.EditIndex = e.NewEditIndex;
        FillgvDeviceCardEmpMapping(ddlselect, txtsearch);
    }
    protected void gvDeviceCardEmpMapping_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            HiddenField HFCardEmpMappingAutoId = (HiddenField)gvDeviceCardEmpMapping.Rows[e.RowIndex].FindControl("HFCardEmpMappingAutoId");
            Label txtEmployeeNumber = (Label)gvDeviceCardEmpMapping.Rows[e.RowIndex].FindControl("txtEmployeeNumber");
            TextBox txtEmployeeCardNumber = (TextBox)gvDeviceCardEmpMapping.Rows[e.RowIndex].FindControl("txtEmployeeCardNumber");
            TextBox txtEffectiveFromDate = (TextBox)gvDeviceCardEmpMapping.Rows[e.RowIndex].FindControl("txtEffectiveFromDate");
            TextBox txtEffectiveToDate = (TextBox)gvDeviceCardEmpMapping.Rows[e.RowIndex].FindControl("txtEffectiveToDate");
            if (txtEffectiveToDate.Text != "")
            {
                if (DateTime.Parse(txtEffectiveFromDate.Text) > DateTime.Parse(txtEffectiveToDate.Text))
                {
                    lblDeviceCardEmpMapping.Text = "From Date Cann't be Greater than To Date";

                }
                else
                {

                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                    var strTimeFrom = string.Empty;
                    var ds = new DataSet();
                    var objOprManagement = new BL.OperationManagement();
                    ds = objOprManagement.EmployeeCardMappingInsert(BaseCompanyCode, txtEmployeeNumber.Text, txtEmployeeCardNumber.Text, BaseUserID, Convert.ToInt32(HFCardEmpMappingAutoId.Value), txtEffectiveFromDate.Text, txtEffectiveToDate.Text);
                    gvDeviceCardEmpMapping.EditIndex = -1;
                    DisplayMessage(lblDeviceCardEmpMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    FillgvDeviceCardEmpMapping(ddlselect, txtsearch);
                }
            }
            else
            {
                var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                var strTimeFrom = string.Empty;
                var ds = new DataSet();
                var objOprManagement = new BL.OperationManagement();
                ds = objOprManagement.EmployeeCardMappingInsert(BaseCompanyCode, txtEmployeeNumber.Text, txtEmployeeCardNumber.Text, BaseUserID, Convert.ToInt32(HFCardEmpMappingAutoId.Value), txtEffectiveFromDate.Text, txtEffectiveToDate.Text);
                gvDeviceCardEmpMapping.EditIndex = -1;
                DisplayMessage(lblDeviceCardEmpMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
                FillgvDeviceCardEmpMapping(ddlselect, txtsearch);
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void gvDeviceCardEmpMapping_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            HiddenField hfCardEmpMappingAutoId = (HiddenField)gvDeviceCardEmpMapping.FooterRow.FindControl("hfCardEmpMappingAutoId");
            TextBox txtEmployeeNumber = (TextBox)gvDeviceCardEmpMapping.FooterRow.FindControl("txtEmployeeNumber");
            TextBox txtEmployeeCardNumber = (TextBox)gvDeviceCardEmpMapping.FooterRow.FindControl("txtEmployeeCardNumber");
            TextBox txtEffectiveFromDate = (TextBox)gvDeviceCardEmpMapping.FooterRow.FindControl("txtEffectiveFromDate");
            TextBox txtEffectiveToDate = (TextBox)gvDeviceCardEmpMapping.FooterRow.FindControl("txtEffectiveToDate");

            if (e.CommandName == "AddNew")
            {
                if (txtEffectiveToDate.Text != "")
                {
                    if (DateTime.Parse(txtEffectiveFromDate.Text) > DateTime.Parse(txtEffectiveToDate.Text))
                    {
                        lblDeviceCardEmpMapping.Text = "From Date Cann't be Greater than To Date";

                    }
                    else
                    {

                        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                        var strTimeFrom = string.Empty;
                        var ds = new DataSet();
                        var objOprManagement = new BL.OperationManagement();
                        ds = objOprManagement.EmployeeCardMappingInsert(BaseCompanyCode, txtEmployeeNumber.Text, txtEmployeeCardNumber.Text, BaseUserID, Convert.ToInt32(hfCardEmpMappingAutoId.Value), txtEffectiveFromDate.Text, txtEffectiveToDate.Text);
                        DisplayMessage(lblDeviceCardEmpMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
                        FillgvDeviceCardEmpMapping(ddlselect, txtsearch);
                    }
                }
                else
                {
                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                    var strTimeFrom = string.Empty;
                    var ds = new DataSet();
                    var objOprManagement = new BL.OperationManagement();
                    ds = objOprManagement.EmployeeCardMappingInsert(BaseCompanyCode, txtEmployeeNumber.Text, txtEmployeeCardNumber.Text, BaseUserID, Convert.ToInt32(hfCardEmpMappingAutoId.Value), txtEffectiveFromDate.Text, txtEffectiveToDate.Text);
                    DisplayMessage(lblDeviceCardEmpMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    FillgvDeviceCardEmpMapping(ddlselect, txtsearch);
                }
            }
            if (e.CommandName == "Reset")
            {
                txtEmployeeNumber.Text = "";
                txtEmployeeCardNumber.Text = "";

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvDeviceCardEmpMapping_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvDeviceCardEmpMapping.EditIndex = -1;
        FillgvDeviceCardEmpMapping(ddlselect, txtsearch);

    }
    protected void gvDeviceCardEmpMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.OperationManagement();
        HiddenField ID = (HiddenField)gvDeviceCardEmpMapping.Rows[e.RowIndex].FindControl("HFCardEmpMappingAutoId");
        Label lblEmployeeCardNumber = (Label)gvDeviceCardEmpMapping.Rows[e.RowIndex].FindControl("lblEmployeeCardNumber");
        ds = objHrManagement.EmployeeCardMappingDelete(Convert.ToInt32(ID.Value), lblEmployeeCardNumber.Text);

        DisplayMessage(lblDeviceCardEmpMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvDeviceCardEmpMapping.EditIndex = -1;
        FillgvDeviceCardEmpMapping(ddlselect, txtsearch);
    }
    protected void gvDeviceCardEmpMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDeviceCardEmpMapping.PageIndex = e.NewPageIndex;
        gvDeviceCardEmpMapping.EditIndex = -1;
        FillgvDeviceCardEmpMapping(ddlselect, txtsearch);

    }
    protected void txtEmployeeNumber_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtEmployeeNumber = (TextBox)gvDeviceCardEmpMapping.FooterRow.FindControl("txtEmployeeNumber");
        TextBox txtEmployeeName = (TextBox)gvDeviceCardEmpMapping.FooterRow.FindControl("txtEmployeeName");
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();

        ds = objHRManagement.EmployeeDesignationGetLocation(txtEmployeeNumber.Text.ToString(), BaseCompanyCode, BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();


            }
            else
            {
                DisplayMessage(lblDeviceCardEmpMapping, ds.Tables[0].Rows[0]["MessageID"].ToString());
                txtEmployeeNumber.Text = "";
                txtEmployeeNumber.Focus();
            }
        }
        else
        {
            lblDeviceCardEmpMapping.Text = Resources.Resource.InvalidEmployee;
            txtEmployeeName.Text = "";
            txtEmployeeNumber.Text = "";
            txtEmployeeNumber.Focus();
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        FillgvDeviceCardEmpMapping(ddlselect, txtsearch);
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        txtsearch.Text = "";
        FillgvDeviceCardEmpMapping(ddlselect,txtsearch);
    }
}