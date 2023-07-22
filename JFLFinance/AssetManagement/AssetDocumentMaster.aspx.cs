using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.IO;
using System.Data;


public partial class AssetManagement_AssetDocumentMaster : BasePage
{
    const string uploadfolder = @"~\\DocumentUpload\\AssetDocUpload\\";
   
   static string filepath = "";
   static string DBfilepath = "";
   static int dtflag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["AssetId"] != null && Request.QueryString["Category"] !=null)
            {
                AssetId.Value = Request.QueryString["AssetId"].ToString();
                if (Request.QueryString["Category"].ToString() == "Lease")
                {
                    Category.Value = "Lease";
                }
                if (Request.QueryString["Category"].ToString() == "Purchase")
                {
                    Category.Value = "Purchase";
                }
                if (Request.QueryString["Category"].ToString() == "Insurance")
                {
                    Category.Value = "Insurance";
                }
                if (Request.QueryString["Category"].ToString() == "Warranty")
                {
                    Category.Value = "Warranty";
                }
                if (Request.QueryString["Category"].ToString() == "Gurantee")
                {
                    Category.Value = "Gurantee";
                }
                if (Request.QueryString["Category"].ToString() == "AMC")
                {
                    Category.Value = "AMC";
                }
                FillgvDocumentDetail(Convert.ToInt32(AssetId.Value), Category.Value);
                DocType.Text = Category.Value + " Documents";
            }
           
        }
    }


    protected void btnUploaddocument_Click(object sender, EventArgs e)
    {
        try
        {
            string resultFilePath = "";
            string fileName = Path.GetFileName(afuDocumentDetailPurchase.FileName);
            if (afuDocumentDetailPurchase.HasFile)
            {
                string extension = Path.GetExtension(afuDocumentDetailPurchase.FileName);
                string uniqueid = Guid.NewGuid().ToString();
                filepath = uploadfolder + uniqueid + extension;
                DBfilepath = uniqueid + extension;
                resultFilePath = MapPath(filepath);
                afuDocumentDetailPurchase.SaveAs(resultFilePath);
                var ds = new DataSet();
                var objAssetMgmt = new BL.AssetManagement();
                ds = objAssetMgmt.AssetDocumentInsert(Category.Value, Convert.ToInt32(AssetId.Value), txtDocumentdesc.Text, DBfilepath, BaseUserID,BaseCompanyCode);
                DisplayMessage(lblDocument, ds.Tables[0].Rows[0]["MessageId"].ToString());
              
                txtDocumentdesc.Text = "";
            }
            else
            {
                Response.Write("<script>alert(" + Resources.Resource.SelectDocument + ")</script>");
            }


        }
        catch (Exception ex)
        { }
        FillgvDocumentDetail(Convert.ToInt32(AssetId.Value), Category.Value);
        //var ds = new DataSet();
        //var objAssetMgmt = new BL.AssetManagement();
        //ds = objAssetMgmt.AssetDocumentInsert(Category.Value, Convert.ToInt32(AssetId.Value), txtDocumentdesc.Text, "DBfilepath", BaseUserID);
        //DisplayMessage(lblDocument, ds.Tables[0].Rows[0]["MessageId"].ToString());
        //FillgvDocumentDetail(Convert.ToInt32(AssetId.Value), Category.Value);
        //txtDocumentdesc.Text = "";
    }

    protected void imgBtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        try { 
        string filePath = (sender as ImageButton).CommandArgument;
        string fullfilepath = uploadfolder + filePath;
         Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(fullfilepath));
        Response.WriteFile(fullfilepath);
        Response.End();
            }
        catch(Exception ex)
        { }
    }

    private void FillgvDocumentDetail(int AssetId,string Category)
    {
       
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
           var dsOtherDetails = new DataSet();
            var dtOtherDetails = new DataTable();
            dtflag = 1;

             dsOtherDetails = objAssetMgmt.AssetDocumentDetail(AssetId, Category,BaseCompanyCode);
         
           
            dtOtherDetails = dsOtherDetails.Tables[0];
            if (dtOtherDetails.Rows.Count == 0)
            {
                dtflag = 0;
                dtOtherDetails.Rows.Add(dtOtherDetails.NewRow());

                gvDocumentDetail.Visible = false;

            }
            else
            {

                gvDocumentDetail.Visible = true;
            }
            gvDocumentDetail.DataSource = dtOtherDetails;
            gvDocumentDetail.DataBind();

            if (dtflag == 0)
            {
                gvDocumentDetail.Rows[0].Visible = false;
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
    protected void gvDocumentDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.AssetManagement();
        HiddenField ID = (HiddenField)gvDocumentDetail.Rows[e.RowIndex].FindControl("hfAssetDocumentAutoId");
        Label lblFileName = (Label)gvDocumentDetail.Rows[e.RowIndex].FindControl("lblFileName");
        if((lblFileName.Text !="")|| (lblFileName.Text !=null))
        { 
        filepath = uploadfolder + lblFileName.Text;
        filepath = MapPath(filepath);
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        }
        ds = objHrManagement.AssetDocumentDelete(Convert.ToInt32(ID.Value),BaseCompanyCode);
        DisplayMessage(lblDocument, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvDocumentDetail.EditIndex = -1;
        FillgvDocumentDetail(Convert.ToInt32(AssetId.Value), Category.Value);
    }
    protected void gvDocumentDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDocumentDetail.PageIndex = e.NewPageIndex;
        gvDocumentDetail.EditIndex = -1;
        FillgvDocumentDetail(Convert.ToInt32(AssetId.Value), Category.Value);
    }
}