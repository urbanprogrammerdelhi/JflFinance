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

public partial class AssetManagement_AssetDiscardList : BasePage
{
    static int dtflag;
    static int Flag;
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

                //txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                //txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                Flag = 1;
                FillgvAssetDiscard();
            }
        }
        txtDate.Attributes.Add("readonly", "readonly");
        txtToDate.Attributes.Add("readonly", "readonly");
    }
    protected void gvAssetDiscardList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetDiscardList.PageIndex = e.NewPageIndex;
        gvAssetDiscardList.EditIndex = -1;
        FillgvAssetDiscard();
    }
    private void FillgvAssetDiscard()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetMaster = new DataSet();
            var dtAssetMaster = new DataTable();
            dtflag = 1;
            dsAssetMaster = objAssetMgmt.AssetDiscardList(BaseLocationAutoID, txtAssetCode.Text.Trim(), txtAssetName.Text.Trim(), txtDate.Text, txtToDate.Text, Flag);
            dtAssetMaster = dsAssetMaster.Tables[0];
            if (dtAssetMaster.Rows.Count == 0)
            {
                dtflag = 0;
                dtAssetMaster.Rows.Add(dtAssetMaster.NewRow());
            }
            gvAssetDiscardList.DataSource = dtAssetMaster;
            gvAssetDiscardList.DataBind();

            if (dtflag == 0)
            {
                gvAssetDiscardList.Rows[0].Visible = false;
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

    protected void BtnView_Click(object sender, EventArgs e)
    {
        Flag = 0;
        if ((txtDate.Text == "") && (txtToDate.Text != ""))
        {
            txtDate.Text = txtToDate.Text;
        }
        if ((txtDate.Text != "") && (txtToDate.Text == ""))
        {
            txtToDate.Text = txtDate.Text;
        }
        FillgvAssetDiscard();
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        Flag = 1;
        FillgvAssetDiscard();
        txtToDate.Text = "";
        txtDate.Text = "";
        txtAssetName.Text = "";
        txtAssetCode.Text = "";
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=DiscardedAssetList.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvAssetDiscardList.AllowPaging = false;
            FillgvAssetDiscard();

            gvAssetDiscardList.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvAssetDiscardList.HeaderRow.Cells)
            {
                cell.BackColor = gvAssetDiscardList.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvAssetDiscardList.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvAssetDiscardList.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvAssetDiscardList.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }
            gvAssetDiscardList.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }  
}