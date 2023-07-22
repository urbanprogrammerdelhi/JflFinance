using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sales_QuotationHeadConfig : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Request.QueryString["CompanyCode1"] != null) && (Request.QueryString["Designation1"] != null) && (Request.QueryString["State1"] != null) && (Request.QueryString["GradeCode1"] != null))
            {
                  var companycode2 = Request.QueryString["CompanyCode1"].ToString();
                  var designation2= Request.QueryString["Designation1"].ToString();
                  var state2   = Request.QueryString["State1"].ToString();
                  var GradeCode2 = Request.QueryString["GradeCode1"].ToString();
                  //FillddlCompanyCode();
                  FillddlState();
                  ddlCompanyCode.SelectedValue = companycode2;
                  ddlDesignation.SelectedValue = designation2;
                  ddlState.SelectedValue = state2;
                  ddlGrade.SelectedValue = GradeCode2;
                  FillddlCompanyCode();
                  FillgvHeadConfig();
                  FillddlHeadCode();
                
            }
            else
            {
                trheadcodevalueperof.Visible = true;
                trgroupheadcodeformula.Visible = false;
                trheadcodevalueperof.Visible = false;
                FillddlCompanyCode();
                FillddlState();
                FillgvHeadConfig();
                FillddlHeadCode();
              
            }
            ddlHeadCodeValueType.Items.Add("--Select--");
            ddlHeadCodeValueType.Items.Add("Fixed");
            ddlHeadCodeValueType.Items.Add("Percentage");
            trheadcodevalue.Visible = true;
        }
       if (txtHeadCodeValue != null)
       {
           txtHeadCodeValue.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
           txtHeadCodeValue.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
       }
       if (txtSequenceNo != null)
       {
           txtSequenceNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
           txtSequenceNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
       }
       if (txtFormatCode != null)
       {
           txtFormatCode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionAlpha + ");");
           txtFormatCode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionAlpha + ");");
       }
       if (txtHeadcode != null)
       {
           txtHeadcode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionAlpha + ");");
           txtHeadcode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionAlpha + ");");
       }
    }
    protected void ddlHeadCodeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlHeadCode();
        ddlHeadCodeValueType.Items.Clear();
        ddlHeadCodeValueType.Items.Add("--Select--");
      if(ddlHeadCodeType.SelectedItem.Value == "GroupHead")
      {
          ddlHeadCodeValueType.Items.Add("Sum & Subtract");
          trheadcodevalue.Visible = false;
          trheadcodevalueperof.Visible = false;
          rfvtxtHeadCodeValue.Enabled = false;
      }
      else
      {
          rfvtxtHeadCodeValue.Enabled = true;
          trheadcodevalue.Visible = true;
          trgroupheadcodeformula.Visible = false;
          ddlHeadCodeValueType.Items.Add("Fixed");
          ddlHeadCodeValueType.Items.Add("Percentage");
      }
    }
    protected void ddlHeadCodeValueType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlHeadCode();
         if(ddlHeadCodeValueType.SelectedValue == "Percentage")
         {
             trheadcodevalueperof.Visible=true;
            
         }
         else
         {
              trheadcodevalueperof.Visible=false;
         }
         if (ddlHeadCodeValueType.SelectedValue == "Sum & Subtract")
         {
          
             trgroupheadcodeformula.Visible = true;
          
         }
         else
         {
             trgroupheadcodeformula.Visible = false;
           
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
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlCompanyCode.Items.Add(li);
        }
        FillddlDesignation(ddlCompanyCode);
       FillgvHeadConfig();
    }
    protected void FillddlDesignation(DropDownList ddl)
    {
        ddlDesignation.Items.Clear();
        var objSales = new BL.Sales();
        DataSet ds = objSales.GetDesignationCode(ddl.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDesignation.DataSource = ds.Tables[0];
            ddlDesignation.DataValueField = "DesignationCode";
            ddlDesignation.DataTextField = "DesignationDesc";
            ddlDesignation.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlDesignation.Items.Add(li);
        }
        FillddlGrade();
       FillgvHeadConfig();
     
    }
    protected void FillddlGrade()
    {
        ddlGrade.Items.Clear();
        var objSales = new BL.Sales();
        DataSet ds = objSales.GetGradeCode(ddlCompanyCode.SelectedValue,ddlDesignation.SelectedItem.Value);
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
        FillgvHeadConfig();
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlDesignation(ddlCompanyCode);
        FillddlHeadCode();
        FillgvHeadConfig();
        lblmsg.Text = "";
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
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlState.Items.Add(li);
        }
      
    }
  
   protected void FillddlHeadCode()
    {
        ddlHeadCodeValuperof.Items.Clear();
        ddlGroupHeadCodeFormula.Items.Clear();
        var objSales = new BL.Sales();
        DataSet ds = objSales.GetHeadCode(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value,Convert.ToInt32( ddlState.SelectedItem.Value),ddlGrade.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlHeadCodeValuperof.DataSource = ds.Tables[0];
            ddlHeadCodeValuperof.DataValueField = "HeadCode";
            ddlHeadCodeValuperof.DataTextField = "HeadCode";
            ddlHeadCodeValuperof.DataBind();
            ddlGroupHeadCodeFormula.DataSource = ds.Tables[0];
            ddlGroupHeadCodeFormula.DataValueField = "HeadCode";
            ddlGroupHeadCodeFormula.DataTextField = "HeadCode";
            ddlGroupHeadCodeFormula.DataBind();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlHeadCodeValuperof.Items.Add(li);
            ddlGroupHeadCodeFormula.Items.Add(li);
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
   {
        if(ddlfromday.SelectedItem.Value != ddlToday.SelectedItem.Value)
        { 
            if(ddlGrade.SelectedValue != "")
            { 
        var objSales = new BL.Sales();
        if (ddlHeadCodeType.SelectedItem.Value == "GroupHead")
        {
            string s = "";
            foreach (ListItem li in listBoxFormula.Items)
            {
                    s += li.Text;
            }
            if(ddlGroupHeadCodeFormula.SelectedValue != "")
            { 
            DataSet ds = objSales.InsertHeadConfigDetail(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value), txtFormatCode.Text, txtHeadcode.Text, txtHeadCodeDesc.Text, ddlHeadCodeType.SelectedItem.Value, ddlHeadCodeValueType.SelectedItem.Value, Convert.ToDecimal(0), "", s.ToString(), txtSequenceNo.Text,ddlfromday.SelectedItem.Value,ddlToday.SelectedItem.Value,ddlGrade.SelectedItem.Value);
            DisplayMessage(lblmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
            if (ds.Tables[0].Rows[0]["MessageId"].ToString() == "0")
            {
                Reset();
            }
            }

            else
            {
                lblmsg.Text = "Please select Group Head Code Formula";
            }

        }
        else 
        {
            if (ddlHeadCodeValueType.SelectedItem.Value == "Fixed")
            {
                DataSet ds = objSales.InsertHeadConfigDetail(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value), txtFormatCode.Text, txtHeadcode.Text, txtHeadCodeDesc.Text, ddlHeadCodeType.SelectedItem.Value, ddlHeadCodeValueType.SelectedItem.Value, Convert.ToDecimal(txtHeadCodeValue.Text), "", "", txtSequenceNo.Text, ddlfromday.SelectedItem.Value, ddlToday.SelectedItem.Value,ddlGrade.SelectedItem.Value);
                DisplayMessage(lblmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                if (ds.Tables[0].Rows[0]["MessageId"].ToString() == "0")
                {
                    Reset();
                }
            }
            else
            {
 if(ddlHeadCodeValuperof.SelectedValue != "")
            {
                DataSet ds = objSales.InsertHeadConfigDetail(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value), txtFormatCode.Text, txtHeadcode.Text, txtHeadCodeDesc.Text, ddlHeadCodeType.SelectedItem.Value, ddlHeadCodeValueType.SelectedItem.Value, Convert.ToDecimal(txtHeadCodeValue.Text), ddlHeadCodeValuperof.SelectedItem.Value, "", txtSequenceNo.Text, ddlfromday.SelectedItem.Value,ddlToday.SelectedItem.Value,ddlGrade.SelectedItem.Value);
                DisplayMessage(lblmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                if (ds.Tables[0].Rows[0]["MessageId"].ToString() == "0")
                {
                    Reset();
                }
            }
 else
 {
     lblmsg.Text = "Please select Head Code Value % Of";
 }
            }
        }
         
       
        FillgvHeadConfig();
        FillddlHeadCode();
            }
        }
        else
        {
            lblmsg.Text = "From Day and To Day cann't be same";
        }
       
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlGrade();
        FillddlHeadCode();
        FillgvHeadConfig();
        lblmsg.Text = "";
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlHeadCode();
        FillgvHeadConfig();
        lblmsg.Text = "";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
      if(hfFormula.Value == "")
      {
          lblmsg.Text = "Please Select + / - before Adding";
       // listBoxFormula.Items.Add(ddlGroupHeadCodeFormula.SelectedItem);
        
      }
      else
      {
          lblmsg.Text = "";
          listBoxFormula.Items.Add(hfFormula.Value + ddlGroupHeadCodeFormula.SelectedItem);
          hfFormula.Value = "";
      }
       

    }
    protected void btnSum_Click(object sender, EventArgs e)
    {
        hfFormula.Value = "+";
      //  listBoxFormula.Items.Add("+");
    }
    protected void btnSub_Click(object sender, EventArgs e)
    {
        hfFormula.Value = "-";
       // listBoxFormula.Items.Add("-");
    }
    public void Reset()
    {
       // txtFormatCode.Text = "";
        txtHeadcode.Text = "";
        txtHeadCodeDesc.Text = "";
        txtHeadCodeValue.Text = "";
        //FillddlCompanyCode();
        //FillddlState();
        //FillddlHeadCode();
        listBoxFormula.Items.Clear();
      //  txtSequenceNo.Text = "";
    }
    protected void gvQuotationHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuotationHead.PageIndex = e.NewPageIndex;
        gvQuotationHead.EditIndex = -1;
        FillgvHeadConfig();
        FillddlHeadCode();
      
    }
    protected void gvQuotationHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var hfStatus = (HiddenField)e.Row.FindControl("hfStatus");
            var btnEdit=(ImageButton)e.Row.FindControl("btnEdit");
            var lblFormatCode = (Label)e.Row.FindControl("lblFormatCode");
            var lblSequence = (Label)e.Row.FindControl("lblSequence");
            if(hfStatus.Value=="FREEZED")
            {
                btnEdit.Visible = false;
            }
            else
            {
                btnEdit.Visible = true;
            }
         if(lblFormatCode != null)
         {
             txtFormatCode.Text = lblFormatCode.Text;
         }
         if (lblSequence != null)
         {
             if (lblSequence.Text == "")
             {
                 lblSequence.Text = "0";
             }
             txtSequenceNo.Text = Convert.ToString( Convert.ToInt32(lblSequence.Text) + 1);
         }
           
        }
    }
    protected void gvQuotationHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    private void FillgvHeadConfig()
    {
        try
        {
            var objHrManagement = new BL.Sales();
            var dsHeadConfig = new DataSet();
            var dtHeadConfig = new DataTable();
         int   dtflag = 1;
         dsHeadConfig = objHrManagement.GetQuotationHeadDetail(ddlCompanyCode.SelectedItem.Value,ddlDesignation.SelectedItem.Value,Convert.ToInt32( ddlState.SelectedItem.Value),ddlGrade.SelectedItem.Value);
         dtHeadConfig = dsHeadConfig.Tables[0];
         if (dtHeadConfig.Rows.Count == 0)
            {
                dtflag = 0;
                dtHeadConfig.Rows.Add(dtHeadConfig.NewRow());
            }
         gvQuotationHead.DataSource = dtHeadConfig;
            gvQuotationHead.DataBind();
           
            if (dtflag == 0)
            {
                txtFormatCode.Enabled = true;
                txtSequenceNo.Enabled = false;
                txtSequenceNo.Text = "1";
                gvQuotationHead.Rows[0].Visible = false;
                dtflag = 0;
                btnView.Visible = false;
                btnSave.Visible = true;
                btnCalculate.Visible = false;
                btnAmend.Visible = false;
              
            }
            else
            {
                txtSequenceNo.Enabled = false;
                txtFormatCode.Enabled = false;
                dtflag = 1;
                if (dsHeadConfig.Tables[0].Rows[0]["Staus"].ToString() == "FREEZED")
                {
                    btnView.Visible = true;
                    btnCalculate.Visible = false;
                    btnSave.Visible = false;
                    btnAmend.Visible = true;
                }
                else
                {
                    btnView.Visible = false;
                    btnCalculate.Visible = true;
                    btnSave.Visible = true;
                    btnAmend.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
        }


    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
     
        var Edit = (Control)sender;
        GridViewRow row = (GridViewRow)Edit.NamingContainer;
        row.BackColor = System.Drawing.Color.LightGray;
        HiddenField hfQuotationHeadAutoId = (HiddenField)row.FindControl("hfQuotationHeadAutoId");
        HiddenField hfDesignationCode = (HiddenField)row.FindControl("hfDesignationCode");
        HiddenField hfGradeCode = (HiddenField)row.FindControl("hfGradeCode");
        HiddenField hfStateId = (HiddenField)row.FindControl("hfStateId");
        Label lblFormatCode = (Label)row.FindControl("lblFormatCode");
        Label lblHeadCode = (Label)row.FindControl("lblHeadCode");
        Label lblHeadCodeDesc = (Label)row.FindControl("lblHeadCodeDesc");
        Label lblHeadCodeType = (Label)row.FindControl("lblHeadCodeType");
        Label lblHeadCodeValueType = (Label)row.FindControl("lblHeadCodeValueType");
        Label lblHeadCodeValue = (Label)row.FindControl("lblHeadCodeValue");
        Label lblHeadCodeValueperof = (Label)row.FindControl("lblHeadCodeValueperof");
        Label lblGroupHeadCodeFormula = (Label)row.FindControl("lblGroupHeadCodeFormula");
         Label lblCompanyCode = (Label)row.FindControl("lblCompanyCode");
         Label lblSequence = (Label)row.FindControl("lblSequence");
         Label lblFromDay = (Label)row.FindControl("lblFromDay");
         Label lblToday = (Label)row.FindControl("lblToday");
         hfAutoID.Value = hfQuotationHeadAutoId.Value;
         ddlCompanyCode.Enabled = false;
         ddlDesignation.Enabled = false;
         ddlGrade.Enabled = false;
         ddlState.Enabled = false;
         ddlHeadCodeType.Enabled = false;
         txtHeadcode.Enabled = false;
         txtSequenceNo.Enabled = false;
         ddlfromday.Enabled = false;
         ddlToday.Enabled = false;
         txtFormatCode.Text = lblFormatCode.Text;
         txtHeadcode.Text = lblHeadCode.Text;
         txtHeadCodeDesc.Text = lblHeadCodeDesc.Text;
         ddlHeadCodeType.SelectedValue = lblHeadCodeType.Text;
         txtSequenceNo.Text = lblSequence.Text;
         ddlfromday.SelectedValue = lblFromDay.Text;
         ddlToday.SelectedValue = lblToday.Text;
         ddlHeadCodeValueType.Items.Clear();
         if (lblHeadCodeType.Text == "Head")
         {
             ddlHeadCodeValueType.Items.Add("Fixed");
             ddlHeadCodeValueType.Items.Add("Percentage");
             txtHeadCodeValue.Text = lblHeadCodeValue.Text;
             trheadcodevalue.Visible = true;
             trgroupheadcodeformula.Visible = false;
             ddlHeadCodeValueType.Text = lblHeadCodeValueType.Text;
             if (ddlHeadCodeValueType.SelectedValue == "Percentage")
             {
                 trheadcodevalueperof.Visible = true;
                 ddlHeadCodeValuperof.SelectedValue = lblHeadCodeValueperof.Text;

             }
             else
             {
                 trheadcodevalueperof.Visible = false;
             }

         }
         else
         {
             listBoxFormula.Items.Clear();
             ddlHeadCodeValueType.Items.Add("Sum & Subtract");
            listBoxFormula.Items.Add(lblGroupHeadCodeFormula.Text);
             ddlHeadCodeValueType.Text = lblHeadCodeValueType.Text;
             trheadcodevalue.Visible = false;
             trheadcodevalueperof.Visible = false;
             if (ddlHeadCodeValueType.SelectedValue == "Sum & Subtract")
             {

                 trgroupheadcodeformula.Visible = true;
               
             }
             else
             {
                 trgroupheadcodeformula.Visible = false;
               
             }
         }

         btnSave.Visible = false;
         btnUpdate.Visible = true;
         btnAddnew.Visible = true;
         lblmsg.Text = "";
         btnCalculate.Visible = true;
         btnView.Visible = false;
         btnAmend.Visible = false;

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if(ddlfromday.SelectedItem.Value != ddlToday.SelectedItem.Value)
        { 
        var objSales = new BL.Sales();
        if (ddlHeadCodeType.SelectedItem.Value == "GroupHead")
        {
            string s = "";
            foreach (ListItem li in listBoxFormula.Items)
            {
                    s += li.Text;
            }
            if(ddlGroupHeadCodeFormula.SelectedValue != "")
            { 
            DataSet ds = objSales.UpdateHeadConfigDetail(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value), txtFormatCode.Text, txtHeadcode.Text, txtHeadCodeDesc.Text, ddlHeadCodeType.SelectedItem.Value, ddlHeadCodeValueType.SelectedItem.Value, Convert.ToDecimal(0), "", s.ToString(), txtSequenceNo.Text, ddlfromday.SelectedItem.Value, ddlToday.SelectedItem.Value, hfAutoID.Value,ddlGrade.SelectedItem.Value);
            DisplayMessage(lblmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
            }
            else
            {
                lblmsg.Text = "Please select Group Head Code Formula";
            }
        }
        else
        {
            if (ddlHeadCodeValueType.SelectedItem.Value == "Fixed")
            {
                DataSet ds = objSales.UpdateHeadConfigDetail(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value), txtFormatCode.Text, txtHeadcode.Text, txtHeadCodeDesc.Text, ddlHeadCodeType.SelectedItem.Value, ddlHeadCodeValueType.SelectedItem.Value, Convert.ToDecimal(txtHeadCodeValue.Text), "", "", txtSequenceNo.Text, ddlfromday.SelectedItem.Value, ddlToday.SelectedItem.Value, hfAutoID.Value,ddlGrade.SelectedItem.Value);
                DisplayMessage(lblmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
            }
            else
            {
                if(ddlHeadCodeValuperof.SelectedValue != "")
            { 
                DataSet ds = objSales.UpdateHeadConfigDetail(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value), txtFormatCode.Text, txtHeadcode.Text, txtHeadCodeDesc.Text, ddlHeadCodeType.SelectedItem.Value, ddlHeadCodeValueType.SelectedItem.Value, Convert.ToDecimal(txtHeadCodeValue.Text), ddlHeadCodeValuperof.SelectedItem.Value, "", txtSequenceNo.Text, ddlfromday.SelectedItem.Value, ddlToday.SelectedItem.Value, hfAutoID.Value,ddlGrade.SelectedItem.Value);
                DisplayMessage(lblmsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
            }
                else
                {
                    lblmsg.Text = "Please select Head Code Value % Of";
                }
            }
        }
        FillgvHeadConfig();
        FillddlHeadCode();
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        Reset();
       
        }
        else
        {
            lblmsg.Text = "From Day and To day cann't be same";
        }
     
    }
    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        Reset();
        trgroupheadcodeformula.Visible = false;
      
        trheadcodevalue.Visible = true;
        trheadcodevalueperof.Visible = false;
        ddlCompanyCode.Enabled = true;
        ddlDesignation.Enabled = true;
        ddlGrade.Enabled = true;
        ddlState.Enabled = true;
        ddlHeadCodeType.Enabled = true;
        txtHeadcode.Enabled = true;
        txtSequenceNo.Enabled = false;
        ddlfromday.Enabled = true;
        ddlToday.Enabled = true;
        ddlHeadCodeValueType.Items.Clear();
        ddlHeadCodeValueType.Items.Add("--Select--");
        ddlHeadCodeValueType.Items.Add("Fixed");
        ddlHeadCodeValueType.Items.Add("Percentage");
        ddlHeadCodeType.SelectedValue = "Head";
        lblmsg.Text = "";
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnAddnew.Visible = false;

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuotationHeadCostingDetail.aspx?CompanyCode=" + ddlCompanyCode.SelectedItem.Value + "&Designation=" + ddlDesignation.SelectedItem.Value + "&State=" + ddlState.SelectedItem.Value + "&GradeCode=" + ddlGrade.SelectedItem.Value);
    }
    protected void gvQuotationHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvQuotationHead.EditIndex = e.NewEditIndex;
        FillgvHeadConfig();
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        
        List<ListItem> deletedItems = new List<ListItem>();
        foreach (ListItem item in listBoxFormula.Items)
        {
            if (item.Selected)
            {
                deletedItems.Add(item);
            }
        }

        foreach (ListItem item in deletedItems)
        {
            listBoxFormula.Items.Remove(item);
        }
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        btnCalculate.Visible = false;
        btnView.Visible = true;
        btnSave.Visible = false;
        btnAmend.Visible = true;
     
        var objSales = new BL.Sales();
        var ds = new DataSet();
        ds = objSales.CalculateValues(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value),ddlGrade.SelectedItem.Value);
        FillgvHeadConfig();
        FillddlHeadCode();
        btnAddnew.Visible = false;
        btnUpdate.Visible = false;

    }
    protected void btnAmend_Click(object sender, EventArgs e)
    {
        btnAmend.Visible = false;
        btnCalculate.Visible = false;
        btnView.Visible = false;
        btnSave.Visible = true;
        var objSales = new BL.Sales();
        var ds = new DataSet();
        ds = objSales.updateStatus(ddlCompanyCode.SelectedItem.Value, ddlDesignation.SelectedItem.Value, Convert.ToInt32(ddlState.SelectedItem.Value),ddlGrade.SelectedItem.Value);
        FillgvHeadConfig();
        FillddlHeadCode();
    }
    protected void btncosting_Click(object sender, EventArgs e)
    {
       // Response.Redirect("QuotationMaster.aspx?CompanyCode=" + ddlCompanyCode.SelectedItem.Value + "&Designation=" + ddlDesignation.SelectedItem.Value + "&State=" + ddlState.SelectedItem.Value);

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
       // FillgvHeadConfig();
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlHeadCode();
        FillgvHeadConfig();
        lblmsg.Text = "";
    }
}