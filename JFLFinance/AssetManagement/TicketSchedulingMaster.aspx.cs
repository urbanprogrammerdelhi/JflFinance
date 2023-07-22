using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssetManagement_TicketSchedulingMaster :BasePage
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
                if (Request.QueryString["TicketNo"] != null)
                {
                    hfTicketNo.Value = Request.QueryString["TicketNo"];
                }
                ReadOnly();
                FillTicketDetail(hfTicketNo.Value);              
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    public void ReadOnly()
    {
        txtClientName.Attributes.Add("readonly", "readonly");
        txtSiteName.Attributes.Add("readonly", "readonly");
        txtDOC.Attributes.Add("readonly", "readonly");
        txtSummary.Attributes.Add("readonly", "readonly");
        txtDesc.Attributes.Add("readonly", "readonly");
        txtSeverity.Attributes.Add("readonly", "readonly");
        txtCommercialValue.Attributes.Add("readonly", "readonly");
        txtStatus.Attributes.Add("readonly", "readonly");
    }
    private void FillTicketDetail(string TicketNo)
    {
        var objAssetMgmt = new BL.AssetManagement();
        var ds = objAssetMgmt.TicketDetail(TicketNo, BaseLocationAutoID);
        try
        {
            lblTicketNo.Text = TicketNo;
            if (ds.Tables.Count > 0)
            {
                txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtSiteName.Text = ds.Tables[0].Rows[0]["AsmtName"].ToString();
                txtDOC.Text = DateFormat(ds.Tables[0].Rows[0]["DateOfCreation"].ToString());
                txtSummary.Text = ds.Tables[0].Rows[0]["SummaryOfIssues"].ToString();
                txtDesc.Text = ds.Tables[0].Rows[0]["DescOfIssues"].ToString();
                txtSeverity.Text = ds.Tables[0].Rows[0]["Severity"].ToString();
                txtCommercialValue.Text = ds.Tables[0].Rows[0]["CommercialValue"].ToString();
               txtStatus.Text = ds.Tables[0].Rows[0]["WOstatus"].ToString();
                hfClientCode.Value = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                hfAsmtID.Value = ds.Tables[0].Rows[0]["AsmtBillingId"].ToString();
                if (ds.Tables[0].Rows[0]["UserId"].ToString().ToUpper() != "system")
                {
                    btnSaveSchedule.Visible = true;
                    gvSelectEmployee.Visible = true;
                    FillgvSelectEmployee();
                }
                else
                {
                    btnSaveSchedule.Visible = false;
                    gvSelectEmployee.Visible = false;
                }

                //gvSelectEmployee.Visible = true;
                //FillgvSelectEmployee();

                var dt = new DataTable();
                dt = ds.Tables[0];

                DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
                ds.Tables[0].Columns.Add(dc);

                if (ds.Tables[0].Rows[0]["WOImage"].ToString() != "")
                {
                    ds.Tables[0].Rows[0]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])).Length);
                }
                else
                {
                    ds.Tables[0].Rows[0]["ImageBase64String"] = "~/Images/EmployeeImages/NoImageAvailable.jpg";

                }
                ImageBox.ImageUrl = ds.Tables[0].Rows[0]["ImageBase64String"].ToString();

            }
           
          
        }
        catch (Exception ex)
        { }
    }
 
    protected void btnSaveSchedule_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            ds = objAssetMgmt.TicketScheduling(hfTicketNo.Value, lblSchEmployeeNumber.Text,hfClientCode.Value,hfAsmtID.Value,BaseLocationAutoID);
            lblError.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
            FillTicketDetail(hfTicketNo.Value);
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
            { 
            btnSaveSchedule.Visible = false;
            gvSelectEmployee.Visible = false;
            }
           
        }
        catch (Exception ex)
        { }
    }
    protected void gvSelectEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSelectEmployee.PageIndex = e.NewPageIndex;
        gvSelectEmployee.EditIndex = -1;
        FillgvSelectEmployee();
    }
    protected void rbSelectEmployee_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox objCheckBox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)objCheckBox.NamingContainer;
        var lblEmployeeNumber = (Label)gvSelectEmployee.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        var lblEmployeeName = (Label)gvSelectEmployee.Rows[row.RowIndex].FindControl("lblEmployeeName");
        lblSchEmployeeNumber.Text = lblEmployeeNumber.Text;
        lblSchEmployeeName.Text = lblEmployeeName.Text;
    }
    protected void FillgvSelectEmployee()
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objSales = new BL.AssetManagement();
        ds = objSales.GetEmployeeDetail(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvSelectEmployee.Visible = true;
            gvSelectEmployee.DataSource = ds;
            gvSelectEmployee.DataBind();
        }
        else
        {
            lblError.Text = Resources.Resource.NoRecordFound;
            gvSelectEmployee.Visible = false;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/assetmanagement/ticketscheduling.aspx");
    }
}