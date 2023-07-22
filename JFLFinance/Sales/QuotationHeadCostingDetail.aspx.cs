using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Sales_QuotationHeadCostingDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["CompanyCode"] != null) && (Request.QueryString["Designation"] != null) && (Request.QueryString["State"] != null) && (Request.QueryString["GradeCode"] != null))
        {
            FillCosting();
            hfComapnyCode.Value = Request.QueryString["CompanyCode"].ToString();
            hfDesignation.Value = Request.QueryString["Designation"].ToString();
            hfState.Value = Request.QueryString["State"].ToString();
            hfGradeCode.Value = Request.QueryString["GradeCode"].ToString();
            if (Request.QueryString["Flag"] != null)
            {
                btnBack.Visible = false;
            }
        }
    }
    private void FillCosting()
    {
        var objHrManagement = new BL.Sales();
        var ds = new DataSet();
        ds = objHrManagement.GetCosting(Request.QueryString["CompanyCode"].ToString(), Request.QueryString["Designation"].ToString(), Convert.ToInt32(Request.QueryString["State"].ToString()), Request.QueryString["GradeCode"].ToString());
        lblHeading.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
        lblHeader.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
        lblDutyDays.Text = ds.Tables[0].Rows[0]["FromDay"].ToString() + "-" + ds.Tables[0].Rows[0]["ToDay"].ToString();
        rptCosting.DataSource = ds.Tables[0];
        rptCosting.DataBind();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
               Response.Redirect("QuotationHeadConfig.aspx?CompanyCode1=" + hfComapnyCode.Value + "&Designation1=" + hfDesignation.Value + "&State1=" + hfState.Value + "&GradeCode1=" +hfGradeCode.Value);
    }
    protected void rptCosting_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {

        }
        RepeaterItem item = e.Item;
        if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
        {
            var lblValue = (Label)item.FindControl("lblValue");
          
            var lblHeadType = (HiddenField)item.FindControl("hfHeadType");
            if (lblValue.Text == "0.00")
            {
                lblValue.Text = string.Empty;
            }
            else
            {
                lblValue.Text = lblValue.Text + " %";
            }

            if (lblHeadType.Value == "GroupHead")
            {
                ((HtmlGenericControl)(e.Item.FindControl("div1"))).Attributes.Add("style", "background-color:silver;");
        
            }
        }
    }
}