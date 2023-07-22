using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.Drawing;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.IO; 
public partial class AssetManagement_TicketScheduling : BasePage
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

    static int dtflag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Today.AddDays(-30).ToString("dd-MMM-yyyy");
            txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
              
        }

            if (IsReadAccess)
            {
                //txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                //txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
              
                if (txtTicketNo != null)
                {
                    txtTicketNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtTicketNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                ReadOnly();
                FillgvTicketMaster();
              
            }
      //  }
        txtDate.Attributes.Add("readonly", "readonly");
        txtToDate.Attributes.Add("readonly", "readonly");

    }
    public void ReadOnly()
    {
      //  txtClientName.Attributes.Add("readonly", "readonly");
        //txtSiteName.Attributes.Add("readonly", "readonly");
        //txtDOC.Attributes.Add("readonly", "readonly");
        //txtSummary.Attributes.Add("readonly", "readonly");
        //txtDesc.Attributes.Add("readonly", "readonly");
        //txtSeverity.Attributes.Add("readonly", "readonly");
        //txtCommercialValue.Attributes.Add("readonly", "readonly");
        //txtStatus.Attributes.Add("readonly", "readonly");
    }
    private void FillgvTicketMaster()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsTicketMaster = new DataSet();
            var dtTicketMaster = new DataTable();
            dtflag = 1;
            if (BaseIsAdmin == "R")
            {
                dsTicketMaster = objAssetMgmt.GetAllTicketsUnschedulled(BaseLocationAutoID, ddlStatusMain.SelectedItem.Value, txtTicketNo.Text.Trim(), "", txtDate.Text, txtToDate.Text,BaseUserID);
            }
            else
            {
                dsTicketMaster = objAssetMgmt.GetAllTicketsUnschedulled(BaseLocationAutoID, ddlStatusMain.SelectedItem.Value, txtTicketNo.Text.Trim(), "", txtDate.Text, txtToDate.Text,"");
            }
          //  dsTicketMaster = objAssetMgmt.GetAllTicketsUnschedulled(BaseLocationAutoID, ddlStatusMain.SelectedItem.Value, txtTicketNo.Text.Trim(), "", txtDate.Text, txtToDate.Text);
            dtTicketMaster = dsTicketMaster.Tables[0];
            if (dtTicketMaster.Rows.Count == 0)
            {
                dtflag = 0;
                dtTicketMaster.Rows.Add(dtTicketMaster.NewRow());
            }
            gvTicketMaster.DataSource = dtTicketMaster;
            gvTicketMaster.DataBind();

            if (dtflag == 0)
            {
                gvTicketMaster.Rows[0].Visible = false;
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
    protected void ImgBtnDeployment_Click(object sender, ImageClickEventArgs e)
    {
        //ImageButton objLinkButton = (ImageButton)sender;
        //GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        ////var hfWorkOrderAutoId = (HiddenField)gvWorkOrderMaster.Rows[row.RowIndex].FindControl("hfWorkOrderAutoId");
        // var lblTicketNo = (Label)gvTicketMaster.Rows[row.RowIndex].FindControl("lblTicketNo");
        ////var lblOrderStatus = (Label)gvWorkOrderMaster.Rows[row.RowIndex].FindControl("lblOrderStatus");
        //pnlTicketDetail1.Visible = true;
        //pnlTicetMaster.Visible = false;
        //FillTicketDetail(lblTicketNo.Text);
        ImageButton objLinkButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer; 
        var lblTicketNo = (Label)gvTicketMaster.Rows[row.RowIndex].FindControl("lblTicketNo");
        if (lblTicketNo != null )
        {
            Response.Redirect("../AssetManagement/TicketSchedulingMaster.aspx?TicketNo=" + lblTicketNo.Text);         
        }
    }
   
    protected void ddlStatusMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
    }
    protected void txtTicketNo_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
      //  pnlTicketDetail1.Visible = false;
        pnlTicetMaster.Visible = true;
    }
    protected void gvTicketMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvTicketMaster.PageIndex * gvTicketMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblPerformer = (Label)e.Row.FindControl("lblUserID");

            if (lblPerformer.Text == "Performer Not Scheduled")
            {
                lblPerformer.ForeColor = System.Drawing.Color.Red;
                lblPerformer.Font.Bold = true;
                //  hfPerformerName.Value = "Employee Not Scheduled";

            }
        }
    }
    protected void gvTicketMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTicketMaster.PageIndex = e.NewPageIndex;
        gvTicketMaster.EditIndex = -1;
        FillgvTicketMaster();
    }
    protected void lblTicketNo_Click(object sender, EventArgs e)
    {
      
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
       
        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=UnscheduledTicketReport-" + txtDate.Text + ".xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //using (StringWriter sw = new StringWriter())
        //{
          
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    //To Export all pages
        //    gvTicketMaster.AllowPaging = false;
        //    FillgvTicketMaster();

        //    gvTicketMaster.HeaderRow.BackColor = Color.White;
        //    foreach (TableCell cell in gvTicketMaster.HeaderRow.Cells)
        //    {
        //        cell.BackColor = gvTicketMaster.HeaderStyle.BackColor;
        //    }
        //    foreach (GridViewRow row in gvTicketMaster.Rows)
        //    {
        //        row.BackColor = Color.White;
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            if (row.RowIndex % 2 == 0)
        //            {
        //                cell.BackColor = gvTicketMaster.AlternatingRowStyle.BackColor;
        //            }
        //            else
        //            {
        //                cell.BackColor = gvTicketMaster.RowStyle.BackColor;
        //            }
        //            cell.CssClass = "textmode";
        //        }
        //    }

        //    gvTicketMaster.RenderControl(hw);

        //    //style to format numbers to string
        //    string style = @"<style> .textmode { } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
    //}
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
              "attachment;filename=AssetQRPrint.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw1 = new StringWriter();
            HtmlTextWriter hw1 = new HtmlTextWriter(sw1);
            gvTicketMaster.AllowPaging = false;
            FillgvTicketMaster();
            gvTicketMaster.RenderControl(hw1);
            Response.Output.Write(sw1.ToString());
            Response.Flush();
            Response.End();
       
       
        
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }

    protected void btnGenerateTicket_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AssetManagement/TicketGeneration.aspx");
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AssetManagement/TicketMaster.aspx");
    }
   
}