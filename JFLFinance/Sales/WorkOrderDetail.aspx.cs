using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sales_WorkOrderDetail : BasePage
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
        if((Request.QueryString["WorkOrderNo"] != null)&&(Request.QueryString["WorkOrderAutoId"] != null))
        {
            FillOrderdetails();
            FillgvWorkOrderHistory();
            if (txtPrice != null)
            {
                txtPrice.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtPrice.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }
        }
        else
        {
            Response.Redirect("WorkOrderList.aspx");
        }
        }
    }
    protected string DateFormat(string strdate)
    {
        var dt = new DateTime();
        string formatedDate;
        if (strdate != string.Empty)
        {
            dt = DateTime.Parse(strdate);
            formatedDate = dt.ToString("dd-MMM-yyyy");
        }
        else
        {
            formatedDate = string.Empty;
        }
        return formatedDate;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        string Price = txtPrice.Text + ".00";
        ds = objSales.UpdateWorkOrderDetail(lblOrderNo.Text, ddlstatus.SelectedItem.Value, Price, BaseUserID, txtTime.Text, txtReason.Text, txtTransactionID.Text, ddlMode.SelectedItem.Value);
       lblerrormsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();

       FillOrderdetails();
       FillgvWorkOrderHistory();

    }
    public void FillOrderdetails()
    {
         hfWorkOrderAutoId.Value = Request.QueryString["WorkOrderAutoId"].ToString();
            DataSet ds = new DataSet();
            BL.Sales objSales = new BL.Sales();
            ds = objSales.GetWorkOrderDetail(Request.QueryString["WorkOrderNo"].ToString());
            lblOrderNo.Text = Request.QueryString["WorkOrderNo"].ToString();
            lblOrderDate.Text = DateFormat(ds.Tables[0].Rows[0]["ModifiedDate"].ToString());
            lblOrderstatus.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lblService.Text = ds.Tables[0].Rows[0]["servicecategoryname"].ToString();
            lblTimeslot.Text = ds.Tables[0].Rows[0]["preferredfromtime"].ToString();
            lblUnit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
            lblFeedback.Text = ds.Tables[0].Rows[0]["Feedback"].ToString();
            lblPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
            lblClientCode.Text = ds.Tables[0].Rows[0]["UserId"].ToString();
            lblClientName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            lblMobile.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["OrderAddress"].ToString();
        //    ddlstatus.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
            ddlunit.SelectedValue = ds.Tables[0].Rows[0]["unit"].ToString();
            var FinalPrice = ds.Tables[0].Rows[0]["price"].ToString();
            string[] Price = FinalPrice.Split('.');
            txtPrice.Text = Price[0].ToString();
            hfWorkOrderAutoId.Value = Request.QueryString["WorkOrderAutoId"].ToString();
            lblPreferredDate.Text = DateFormat(ds.Tables[0].Rows[0]["preferredfromdate"].ToString());

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkOrderList.aspx");
    }
    protected void gvWorkOrderHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWorkOrderHistory.PageIndex = e.NewPageIndex;
        gvWorkOrderHistory.EditIndex = -1;
        FillgvWorkOrderHistory();
    }
    private void FillgvWorkOrderHistory()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.GetWorkOrderStatusHistory(Request.QueryString["WorkOrderNo"].ToString());
        gvWorkOrderHistory.Visible = true;
        gvWorkOrderHistory.DataSource = ds;
        gvWorkOrderHistory.DataBind();


    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstatus.SelectedItem.Value == "ONHOLD")
        {
            divClose.Visible = false;
            tdLabel.Visible = true;
            tdTxt.Visible = true;
            lblText.Text = "Reason To Hold";
            txtTime.Visible = false;
            txtReason.Visible = true;
            txtTime.Text = "";
            txtTransactionID.Text = "";
            txtPrice.Enabled = false;
        }
        else   if (ddlstatus.SelectedItem.Value == "INPROGRESS")
        {
            divClose.Visible = false;
            tdLabel.Visible = true;
            tdTxt.Visible = true;
            lblText.Text = "Check In Time (24 Hr Format)";
            txtTime.Visible = true;
            txtReason.Visible = false;
            txtReason.Text = "";
            txtTransactionID.Text = "";
            txtPrice.Enabled = false;
        }
        else if (ddlstatus.SelectedItem.Value == "CLOSE")
        {
            divClose.Visible = true;
            tdLabel.Visible = false;
            tdTxt.Visible = false;
            txtTime.Text = "";
            txtReason.Text = "";
            txtPrice.Enabled = false;
        }
        else if (ddlstatus.SelectedItem.Value == "DONE")
        {
            txtPrice.Enabled = true;
            divClose.Visible = false;
            tdLabel.Visible = false;
            tdTxt.Visible = false;
            txtTime.Text = "";
            txtReason.Text = "";
            txtTransactionID.Text = "";
        }
        else
        {
            txtPrice.Enabled = false;
            divClose.Visible = false;
            tdLabel.Visible = false;
            tdTxt.Visible = false;
            txtTime.Text = "";
            txtReason.Text = "";
            txtTransactionID.Text = "";

        }
    }
    protected void ddlMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlMode.SelectedItem.Value =="ONLINE")
        {
            tdTRN.Visible = true;
            tdTRN1.Visible = true;
        }
        else
        {
            tdTRN.Visible = false;
            tdTRN1.Visible = false;
        }
    }
}
