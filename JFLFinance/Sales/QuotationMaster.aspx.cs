using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sales_QuotationMaster : BasePage
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
                FillddlCompanyCode();
                FillddlState();
                FillddlClient();
                FillgvQuotation();
        }
      
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        string ClientCode = string.Empty;
        if (ddlcustomercode.SelectedItem.Value == "*")
        {
            ClientCode = string.Empty;
        }
        else
        {
            ClientCode = ddlcustomercode.SelectedItem.Value;
        }

        ds = objsales.InsertQuotationMaster(txtQuotationNo.Text, ClientCode, txtClientName.Text.Trim(), ddlCompanyCode1.SelectedItem.Value, Convert.ToInt32(ddlstate1.SelectedItem.Value), BaseUserID, Convert.ToInt32("0"));
        DisplayMessage(lblMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        if (ds.Tables[0].Rows[0]["MessageId"].ToString() == "0")
        {
            Panel2.Visible = true;
            FillgvQuotation();
            btnSave.Visible = false;
            btnEdit.Visible = true;
            Session["QuotationNo"] = txtQuotationNo.Text;
            FillddlAmendNo();
            FillQuotationDetail(ddlCompanyCode1,ddlstate1);
            FillgvQuotationMaster();
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
           
            ds = objsales.ClientsMappedToLocationGet(BaseLocationAutoID,"ALL", "".ToString(), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        }
        if (ds != null)
        {
           
         
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlcustomercode.DataSource = ds.Tables[0];
                ddlcustomercode.DataTextField = "ClientCode";
                ddlcustomercode.DataValueField = "ClientCode";
                ddlcustomercode.DataBind();
                if (Request.QueryString["ClientCode"] != null)
                {
                    ddlcustomercode.SelectedIndex = ddlcustomercode.Items.IndexOf(ddlcustomercode.Items.FindByValue(Request.QueryString["ClientCode"].ToString()));
                }
           
           
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlcustomercode.Items.Add(li);
            }
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlcustomercode.Items.Add(li);
        }
    }
    protected void FillddlCompanyCode()
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.GetCompanyCode();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlCompanyCode.DataSource = ds.Tables[0];
            ddlCompanyCode.DataValueField = "CompanyCode";
            ddlCompanyCode.DataTextField = "CompanyCode";
            ddlCompanyCode.DataBind();
            ddlCompanyCode1.DataSource = ds.Tables[0];
            ddlCompanyCode1.DataValueField = "CompanyCode";
            ddlCompanyCode1.DataTextField = "CompanyCode";
            ddlCompanyCode1.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlCompanyCode.Items.Add(li);
        }
     }
   
    protected void FillddlState()
    {
        var objHrMGt = new BL.HRManagement();
        var ds = new DataSet();
        ds = objHrMGt.GetState();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlState.DataSource = ds.Tables[0];
            ddlState.DataValueField = "StateId";
            ddlState.DataTextField = "StateName";
            ddlState.DataBind();
            ddlstate1.DataSource = ds.Tables[0];
            ddlstate1.DataValueField = "StateId";
            ddlstate1.DataTextField = "StateName";
            ddlstate1.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlState.Items.Add(li);
        }

    }

    protected void gvQuotationMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQuotationMaster.EditIndex = -1;
        FillgvQuotationMaster();
        lblMsg.Text = "";
    }
    protected void gvQuotationMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        var objsales = new BL.Sales();
        var ds = new DataSet();
        var ddlDesignation = (DropDownList)gvQuotationMaster.FooterRow.FindControl("ddlDesignation");
        var txtNumberOfEmployees = (TextBox)gvQuotationMaster.FooterRow.FindControl("txtNumberOfEmployees");
        var txtDiscount = (TextBox)gvQuotationMaster.FooterRow.FindControl("txtDiscount");
        var ddlGrade = (DropDownList)gvQuotationMaster.FooterRow.FindControl("ddlGrade");
       
        if (e.CommandName == "AddNew")
        {
            try
            {
             
                if((ddlDesignation.SelectedValue!="") &&(ddlGrade.SelectedValue!=""))
                { 
                    if (txtDiscount.Text == "")
                        txtDiscount.Text = "0";
               ds = objsales.InsertTotalCosting(txtQuotationNo.Text,Convert.ToInt32( ddlAmendNo.SelectedItem.Value),ddlDesignation.SelectedItem.Value,Convert.ToInt32(txtNumberOfEmployees.Text),Convert.ToDecimal(txtDiscount.Text),BaseUserID,ddlCompanyCode.SelectedItem.Value,Convert.ToInt32(ddlState.SelectedItem.Value),ddlGrade.SelectedItem.Value);
               DisplayMessage(lblMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
             
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                {
                    txtNumberOfEmployees.Text = "";
                    txtDiscount.Text = "";
                }
                FillgvQuotationMaster();
                }
            }
            catch (Exception ex)
            { }

        }
        if (e.CommandName == "Reset")
        {
            txtNumberOfEmployees.Text = "";
            txtDiscount.Text = "";
        }
        
       
    }
    protected void gvQuotationMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtNumberOfEmployees = (TextBox)e.Row.FindControl("txtNumberOfEmployees");
            var txtDiscount = (TextBox)e.Row.FindControl("txtDiscount");
            var hfDesignationCode = (HiddenField)e.Row.FindControl("hfDesignationCode");
            var hfGradeCode = (HiddenField)e.Row.FindControl("hfGradeCode");
           var ddlDesignation = (DropDownList)e.Row.FindControl("ddlDesignation");
           var ddlGrade = (DropDownList)e.Row.FindControl("ddlGrade");
          var lblDesignation = (LinkButton)e.Row.FindControl("lblDesignation");
       
          var IBEditAsset = (ImageButton)e.Row.FindControl("IBEditAsset");
              var IBDeleteAsset = (ImageButton)e.Row.FindControl("IBDeleteAsset");
              var IBConfig = (ImageButton)e.Row.FindControl("IBConfig");
            if (txtNumberOfEmployees != null)
            {
                txtNumberOfEmployees.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtNumberOfEmployees.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }
            if (txtDiscount != null)
            {
                txtDiscount.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtDiscount.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            }

            if ((ddlDesignation != null) && (ddlGrade != null))
            {
                FillddlDesignationDesc(ddlDesignation,ddlGrade);
                ddlDesignation.SelectedValue = hfDesignationCode.Value;
                ddlGrade.SelectedValue=hfGradeCode.Value;
                ddlDesignation.Enabled = false;
                ddlGrade.Enabled = false;
            }
            gvQuotationMaster.ShowFooter = true;
            if (hfAmendNo.Value == hfmaxAmendNo.Value)
            {
                if(IBEditAsset != null)
                { 
                IBEditAsset.Visible = true;
                }
                if (IBDeleteAsset != null)
                {
                    IBDeleteAsset.Visible = true;
                }
                

            }
            else
            {
                if (IBEditAsset != null)
                {
                    IBEditAsset.Visible = false;
                }
                if (IBDeleteAsset != null)
                {
                    IBDeleteAsset.Visible = false;
                }
               
                gvQuotationMaster.ShowFooter = false;
            }
            if (txtStatus.Text == "AUTHORIZED")
            {
                if (IBEditAsset != null)
                {
                    IBEditAsset.Visible = false;
                }
                if (IBDeleteAsset != null)
                {
                    IBDeleteAsset.Visible = false;
                }
              
                gvQuotationMaster.ShowFooter = false;
            }
            else
            {
                if (IBEditAsset != null)
                {
                    IBEditAsset.Visible = true;
                } if (IBDeleteAsset != null)
                {
                    IBDeleteAsset.Visible = true;
                }
               
            }
            if (lblDesignation != null)
            {
                lblDesignation.Attributes.Add("OnClick", "javascript:OpenCosting('" + ddlCompanyCode1.SelectedItem.Value + "','" + hfDesignationCode.Value + "','" + Convert.ToInt32(ddlstate1.SelectedItem.Value) + "','" + txtQuotationNo.Text + "','" + txtClientName.Text + "','"+hfGradeCode.Value +"' )");
            }
           
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtNumberOfEmployees = (TextBox)e.Row.FindControl("txtNumberOfEmployees");
            var txtDiscount = (TextBox)e.Row.FindControl("txtDiscount");
            var ddlDesignation = (DropDownList)e.Row.FindControl("ddlDesignation");
            var ddlGrade = (DropDownList)e.Row.FindControl("ddlGrade");
       
            if (txtNumberOfEmployees != null)
            {
                txtNumberOfEmployees.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtNumberOfEmployees.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }
            if (txtDiscount != null)
            {
                txtDiscount.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtDiscount.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            }
            FillddlDesignationDesc(ddlDesignation, ddlGrade);
           ddlDesignation.Enabled = true;
           ddlGrade.Enabled = true;
        }
    }
    protected void gvQuotationMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lblMsg.Text = "";
        var objsales = new BL.Sales();
        var ds = new DataSet();
        HiddenField hfDesignationCode = (HiddenField)gvQuotationMaster.Rows[e.RowIndex].FindControl("hfDesignationCode");
        HiddenField hfGradeCode = (HiddenField)gvQuotationMaster.Rows[e.RowIndex].FindControl("hfGradeCode");
        TextBox txtNumberOfEmployees = (TextBox)gvQuotationMaster.Rows[e.RowIndex].FindControl("txtNumberOfEmployees");
        TextBox txtDiscount = (TextBox)gvQuotationMaster.Rows[e.RowIndex].FindControl("txtDiscount");
        HiddenField hfQuotationCostingAutoId = (HiddenField)gvQuotationMaster.Rows[e.RowIndex].FindControl("hfQuotationCostingAutoId");
        ds = objsales.DeleteDesignationDetail(Convert.ToInt32(hfQuotationCostingAutoId.Value), txtQuotationNo.Text, Convert.ToInt32(ddlAmendNo.SelectedItem.Value), hfDesignationCode.Value, Convert.ToInt32(ddlState.SelectedItem.Value), ddlCompanyCode.SelectedValue, hfGradeCode.Value);
        DisplayMessage(lblMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvQuotationMaster.EditIndex = -1;
        FillgvQuotationMaster();

    }
    protected void gvQuotationMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblMsg.Text = "";
        gvQuotationMaster.EditIndex = e.NewEditIndex;
        FillgvQuotationMaster();

      
    }
    protected void gvQuotationMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        lblMsg.Text = "";
        int update = 0;
        var objsales = new BL.Sales();
        var ds = new DataSet();
        HiddenField hfDesignationCode = (HiddenField)gvQuotationMaster.Rows[e.RowIndex].FindControl("hfDesignationCode");
        HiddenField hfGradeCode = (HiddenField)gvQuotationMaster.Rows[e.RowIndex].FindControl("hfGradeCode");
        TextBox txtNumberOfEmployees = (TextBox)gvQuotationMaster.Rows[e.RowIndex].FindControl("txtNumberOfEmployees");
        TextBox txtDiscount = (TextBox)gvQuotationMaster.Rows[e.RowIndex].FindControl("txtDiscount");
        HiddenField hfQuotationCostingAutoId = (HiddenField)gvQuotationMaster.Rows[e.RowIndex].FindControl("hfQuotationCostingAutoId");
        CheckBox ckhUpdate = (CheckBox)gvQuotationMaster.Rows[e.RowIndex].FindControl("ckhUpdate");
        Label lblPerheadprice = (Label)gvQuotationMaster.Rows[e.RowIndex].FindControl("lblPerheadprice");
        if (txtDiscount.Text == "")
            txtDiscount.Text = "0";
        if (ckhUpdate.Checked== true)
        {
            update = 1;
        }

        else
        {
            update = 0;
        }
        ds = objsales.UpdateTotalCosting(txtQuotationNo.Text, Convert.ToInt32(ddlAmendNo.SelectedItem.Value), hfDesignationCode.Value, Convert.ToInt32(txtNumberOfEmployees.Text), Convert.ToDecimal(txtDiscount.Text), BaseUserID, ddlCompanyCode.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value), Convert.ToInt32(hfQuotationCostingAutoId.Value), Convert.ToInt32(update), Convert.ToDecimal(lblPerheadprice.Text), hfGradeCode.Value);
             DisplayMessage(lblMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvQuotationMaster.EditIndex = -1;
        FillgvQuotationMaster();
    }
    protected void gvQuotationMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblMsg.Text = "";
        gvQuotationMaster.PageIndex = e.NewPageIndex;
        gvQuotationMaster.EditIndex = -1;
       FillgvQuotationMaster();
    }
    private void FillddlDesignationDesc(DropDownList ddlDesignation, DropDownList ddlGrade)
    {
        var objsales = new BL.Sales();
        var ds = new DataSet();
        ds = objsales.GetDesignation(ddlCompanyCode.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value));
        ddlDesignation.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDesignation.DataSource = ds.Tables[0];
            ddlDesignation.DataTextField = "DesignationDesc";
            ddlDesignation.DataValueField = "DesignationCode";
            ddlDesignation.DataBind();
         }
        else
        {
            ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlDesignation.Items.Add(li);
        }
        FillddlGrade(ddlDesignation, ddlGrade);
    }

    protected void FillddlGrade(DropDownList ddlDesignation, DropDownList ddlGrade)
    {
        ddlGrade.Items.Clear();
        var objSales = new BL.Sales();
        DataSet ds = objSales.GetGradeCode(ddlCompanyCode.SelectedValue, ddlDesignation.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlGrade.DataSource = ds.Tables[0];
            ddlGrade.DataValueField = "GradeCode";
            ddlGrade.DataTextField = "GradeDesc";
            ddlGrade.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlGrade.Items.Add(li);
        }
       
    }
    private void FillddlAmendNo()
    {
        var objsales = new BL.Sales();
        var ds = new DataSet();
        ds = objsales.GetAmendNo(txtQuotationNo.Text, ddlCompanyCode1.SelectedItem.Value, Convert.ToInt32(ddlstate1.SelectedItem.Value));
        ddlAmendNo.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAmendNo.DataSource = ds.Tables[0];
            ddlAmendNo.DataTextField = "AmendNo";
            ddlAmendNo.DataValueField = "AmendNo";
            ddlAmendNo.DataBind();
            hfmaxAmendNo.Value = ds.Tables[0].Rows[0]["AmendNo"].ToString();
            txtAmendDate.Text =DateFormat( ds.Tables[0].Rows[0]["AmendDate"].ToString());
            txtStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            if ((txtStatus.Text == "FRESH") || (txtStatus.Text == "AMEND"))
            {
                btnAuthorize.Visible = true;
                btnAmend.Visible = false;
            }
            else
            {
                btnAuthorize.Visible = false;
                btnAmend.Visible = true; ;
            }
        }
        else
        {
            ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlAmendNo.Items.Add(li);
        }
    }     
    private void FillgvQuotationMaster()
    {
        try
        {   int dtflag;
            var objsales = new BL.Sales();
            var ds = new DataSet();
            var dt = new DataTable();
            dtflag = 1;
            hfAmendNo.Value = ddlAmendNo.SelectedItem.Value;
            ds = objsales.GetQuotationDesignation(txtQuotationNo.Text, ddlAmendNo.SelectedItem.Value);
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
            }
            gvQuotationMaster.DataSource = dt;
            gvQuotationMaster.DataBind();

            if (dtflag == 0)
            {
                gvQuotationMaster.Rows[0].Visible = false;
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
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        FillgvQuotation();
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        FillgvQuotation();
    }
    protected void ddlcustomercode_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        txtClientName.Text = "";
        if (ddlcustomercode.SelectedItem.Value != "*")
        {
            txtClientName.Enabled = false;
            DataSet ds = new DataSet();
            BL.Sales objsales = new BL.Sales();
            ds = objsales.GetClientName(ddlcustomercode.SelectedItem.Value);
            txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        }
        else
        {
            txtClientName.Enabled = true;
        }
    }
    protected void gvQuotation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblMsg.Text = "";
        gvQuotation.PageIndex = e.NewPageIndex;
        gvQuotation.EditIndex = -1;
        FillgvQuotation();
    }
    private void FillgvQuotation()
    {
        try
        {
            int dtflag;
            var objsales = new BL.Sales();
            var ds = new DataSet();
            var dt = new DataTable();
            dtflag = 1;
            ds = objsales.GetQuotationMasterDetail(ddlCompanyCode.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value));
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
            }
            gvQuotation.DataSource = dt;
            gvQuotation.DataBind();

            if (dtflag == 0)
            {
                gvQuotation.Rows[0].Visible = false;
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
    protected void lnkQuotationNo_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lnkQuotationNo = (LinkButton)gvQuotation.Rows[row.RowIndex].FindControl("lnkQuotationNo");
        HiddenField hfclientcode = (HiddenField)gvQuotation.Rows[row.RowIndex].FindControl("hfclientcode");
        HiddenField hfstate = (HiddenField)gvQuotation.Rows[row.RowIndex].FindControl("hfstate");
        Label lblStatus = (Label)gvQuotation.Rows[row.RowIndex].FindControl("lblStatus");
        Label lblClientNAme = (Label)gvQuotation.Rows[row.RowIndex].FindControl("lblClientNAme");
        divHeader.Visible = false;
        divDesignationHeader.Visible = true;
        Session["QuotationNo"] = lnkQuotationNo.Text;
          ReadonlyTextbox();
          FillQuotationDetail(ddlCompanyCode,ddlState);
          if (hfclientcode.Value != "")
          {
              ddlcustomercode.SelectedValue = hfclientcode.Value;
              txtClientName.Enabled = true;
          }
          else
          {
              ddlcustomercode.SelectedValue = "*";
              txtClientName.Enabled = false;
          }
         txtClientName.Text = lblClientNAme.Text;
  
          FillddlAmendNo();
          FillgvQuotationMaster();
          lblMsg.Text = "";
          if ((lblStatus.Text == "AUTHORIZED"))
        {
            btnEdit.Visible = false;
        }
        else
        {
            btnEdit.Visible = true;
        }
          btnSave.Visible = false;
          Panel2.Visible = true;
          ddlAmendNo.Enabled = true;
    }
    public void FillQuotationDetail(DropDownList CompanyCode,DropDownList  State)
    {
        var objsales = new BL.Sales();
        var ds = new DataSet();
        ds = objsales.GetQuotationDetail(Session["QuotationNo"].ToString(), CompanyCode.SelectedItem.Value, Convert.ToInt32(State.SelectedItem.Value));
        txtQuotationNo.Text = ds.Tables[0].Rows[0]["QuotationNo"].ToString();
        ddlCompanyCode1.SelectedValue = ds.Tables[0].Rows[0]["CompanyCode"].ToString();
        ddlstate1.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
        txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        hfAutoId.Value = ds.Tables[0].Rows[0]["QuotationAutoId"].ToString();
        if (ds.Tables[0].Rows[0]["ClientCode"].ToString() != "")
       {
           ddlcustomercode.SelectedValue = ds.Tables[0].Rows[0]["ClientCode"].ToString();
       }
        else
        {
            ddlcustomercode.SelectedValue = "*";
            txtClientName.Enabled = true;
        }
    }
    public void ReadonlyTextbox()
    {
        txtStatus.Attributes.Add("readonly", "readonly");
        txtAmendDate.Attributes.Add("readonly", "readonly");
        txtQuotationNo.Enabled = false;
        txtClientName.Enabled = false;
        ddlcustomercode.Enabled = false;
        ddlCompanyCode1.Enabled = false;
        ddlstate1.Enabled = false;
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        divHeader.Visible = true;
        divDesignationHeader.Visible = false;
        FillgvQuotation();
        btnUpdate.Visible = false;
        btncancel.Visible = false;
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        ds = objsales.UpdateAuthorize(txtQuotationNo.Text,Convert.ToInt32(ddlAmendNo.SelectedItem.Value),ddlCompanyCode1.SelectedItem.Value,Convert.ToInt32(ddlstate1.SelectedItem.Value));
        DisplayMessage(lblMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        FillddlAmendNo();
        FillgvQuotationMaster();
        btnEdit.Visible = false;
    }
    protected void btnAmend_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        ds = objsales.UpdateAmend(txtQuotationNo.Text, ddlCompanyCode1.SelectedItem.Value, Convert.ToInt32(ddlstate1.SelectedItem.Value));
        DisplayMessage(lblMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        FillddlAmendNo();
        FillgvQuotationMaster();
        btnEdit.Visible = true;
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        lblMsg.Text = "";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        string ClientCode = string.Empty;
        if (ddlcustomercode.SelectedItem.Value == "*")
        {
            ClientCode = string.Empty;
        }
        else
        {
            ClientCode = ddlcustomercode.SelectedItem.Value;
        }
        ds = objsales.UpdateQuotationMaster(txtQuotationNo.Text, ClientCode, txtClientName.Text.Trim(), ddlCompanyCode1.SelectedItem.Value, Convert.ToInt32(ddlstate1.SelectedItem.Value), BaseUserID, Convert.ToInt32(hfAutoId.Value),Convert.ToInt32(ddlAmendNo.SelectedItem.Value));
        DisplayMessage(lblMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
        btnUpdate.Visible = false;
        btnEdit.Visible = true;
        btncancel.Visible = false;
        ddlcustomercode.Enabled = false;
        ddlAmendNo.Enabled = true;
        FillQuotationDetail(ddlCompanyCode1,ddlstate1);
        FillddlAmendNo();
        FillgvQuotationMaster();
        txtClientName.Enabled = false;
    }
  
    protected void gvQuotation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        divHeader.Visible = false;
        divDesignationHeader.Visible = true;
        ddlAmendNo.Enabled = false;
        txtStatus.Enabled = false;
        txtStatus.Text = "FRESH";
        txtAmendDate.Enabled = false;
        txtAmendDate.Text = "";
        ddlAmendNo.Items.Clear();
        txtQuotationNo.Text = "";
        txtQuotationNo.Enabled = true;
        ddlCompanyCode1.Enabled = true;
        ddlstate1.Enabled = true;
        ddlcustomercode.Enabled = true;
        txtClientName.Enabled = true;
        btnEdit.Visible = false;
        btnAmend.Visible = false;
        btnAuthorize.Visible = false;
        btnUpdate.Visible = false;
        btncancel.Visible = false;
        btnSave.Visible = true;
        Panel2.Visible = false;
        ddlcustomercode.SelectedValue = "*";
        txtClientName.Text = "";
        ddlstate1.SelectedValue = ddlState.SelectedValue;
        ddlCompanyCode1.SelectedValue = ddlCompanyCode.SelectedValue;
    }
    protected void ddlAmendNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        var objsales = new BL.Sales();
        var ds = new DataSet();
        ds = objsales.GetAmendNoDetail(txtQuotationNo.Text, ddlCompanyCode1.SelectedItem.Value, Convert.ToInt32(ddlstate1.SelectedItem.Value),Convert.ToInt32( ddlAmendNo.SelectedItem.Value));
        txtStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
        txtAmendDate.Text =DateFormat( ds.Tables[0].Rows[0]["AmendDate"].ToString());
        txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        if (ds.Tables[0].Rows[0]["ClientCode"].ToString() == "")
        {
            ddlcustomercode.SelectedValue = "*";
        }
        else
        {
            ddlcustomercode.SelectedValue = ds.Tables[0].Rows[0]["ClientCode"].ToString();
        }
        if(ddlAmendNo.SelectedItem.Value != hfmaxAmendNo.Value)
        {
            btnEdit.Visible = false;
            btnAmend.Visible = false;
            btnAuthorize.Visible = false;
        }
        else
        {
           
            if((txtStatus.Text=="FRESH")||(txtStatus.Text=="AMEND"))
            {
                btnAuthorize.Visible=true;
                btnAmend.Visible=false;
                btnEdit.Visible = true;
            }
            else
            {
                btnAuthorize.Visible = false;
                btnAmend.Visible = true;
                btnEdit.Visible = false;
            }
        }
        FillgvQuotationMaster();
    }
    protected void ddlstate1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCompanyCode1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnEdit_Click1(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        btnEdit.Visible = false;
        btnAmend.Visible = false;
        btnAuthorize.Visible = false;
        btnUpdate.Visible = true;
        btncancel.Visible = true;
        ddlAmendNo.Enabled = false;
        ddlcustomercode.Enabled = true;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        btncancel.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnEdit.Visible = true;
        FillddlAmendNo();
        FillQuotationDetail(ddlCompanyCode1,ddlstate1);
        ddlAmendNo.Enabled = true;
        ddlcustomercode.Enabled = false;
        txtClientName.Enabled = false;
    }
    protected void IBConfig_Click(object sender, ImageClickEventArgs e)
    {
        var Edit = (Control)sender;
        GridViewRow row = (GridViewRow)Edit.NamingContainer;
        HiddenField hfDesignationCode = (HiddenField)row.FindControl("hfDesignationCode");
        HiddenField hfGradeCode = (HiddenField)row.FindControl("hfGradeCode");
        Response.Redirect("QuotationHeadConfig.aspx?CompanyCode1=" + ddlCompanyCode1.SelectedItem.Value + "&Designation1=" + hfDesignationCode.Value + "&State1=" + ddlstate1.SelectedItem.Value + "&GradeCode1="+ hfGradeCode.Value );

    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlGrade = (DropDownList)this.gvQuotationMaster.FooterRow.FindControl("ddlGrade");
        DropDownList ddlDesignation = (DropDownList)this.gvQuotationMaster.FooterRow.FindControl("ddlDesignation");
        FillddlGrade(ddlDesignation, ddlGrade);
    }
}