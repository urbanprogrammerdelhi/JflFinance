
// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Data;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.IO;
using System.Web;

/// <summary>
/// Class Masters_EmployeeMaster
/// </summary>
public partial class Masters_EmployeeDocumentMaster : BasePage
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
    static int dtflag;
    //static DataTable dtOtherInfoDetails = new DataTable();
    /// <summary>
   
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {

            if (Request.QueryString["Id"] != null)
            {
                PassportId.Value = Request.QueryString["Id"].ToString();
                lblid.Text = Request.QueryString["IdNo"].ToString();
                FillgvDocumentDetail();
               
                for (int i = 0; i < gvDocumentDetail.Rows.Count; i++)
                {
                    GridViewRow row = gvDocumentDetail.Rows[i];
               
                }
            }
            txtDocumentdesc.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            txtDocumentdesc.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        }
    }
  
    /// <summary>
    /// Get Other Details Like Passport,ID info etc
    /// </summary>
    private void FillgvDocumentDetail()
    {
        try
        {
            var objHrManagement = new BL.HRManagement();
            var dsOtherDetails = new DataSet();
            var dtOtherDetails = new DataTable();
            dtflag = 1;

            dsOtherDetails = objHrManagement.EmployeeDocumentDetailGet(PassportId.Value);
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
  
    /// <summary>
    /// Function called on drop down Confirm Duty SelectedIndexChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    const string uploadfolder = "~\\DocumentUpload\\EmployeeDocUpload\\";
    const string uploadfolderDBPath = "DocumentUpload\\EmployeeDocUpload\\IDProof\\";
    static string filepath = "";
    static string DBfilepath = "";
    public void UploadDocument()
    {
        HttpFileCollection multipleFiles = (HttpFileCollection)Session["image"];
        int ddk = multipleFiles.Count;
        for (int fileCount = 0; fileCount < multipleFiles.Count; fileCount++)
        {
            if (multipleFiles[fileCount].ContentLength > 0)
            {
                HttpPostedFile uploadedFile = multipleFiles[fileCount];
                string fileName = Path.GetFileName(uploadedFile.FileName);
                string extension = Path.GetExtension(uploadedFile.FileName);
                string uniqueid = Guid.NewGuid().ToString();
                string fullpath = Server.MapPath(uploadfolder) + uniqueid + extension;
                string DBfullpath =  uniqueid + extension;
                uploadedFile.SaveAs(fullpath);
                int IsVerified = 0;
                var ds = new DataSet();
                var objHRManagement = new BL.HRManagement();
               
                if (ckbItemIsverified.Checked == true)
                {
                    IsVerified = 1;
                }
                ds = objHRManagement.EmployeeDocumentDetailInsert(Convert.ToDecimal(PassportId.Value), txtDocumentdesc.Text.ToString(), DBfullpath, DBfullpath, IsVerified, BaseUserID);
                DisplayMessage(lbldocument, ds.Tables[0].Rows[0]["MessageId"].ToString());
              
            }
        }
        Session["image"] = null;
        Session["RestaurantId"] = null;
        txtDocumentdesc.Text = "";
        ckbItemIsverified.Checked = false;
        FillgvDocumentDetail();
    }

    protected void lnkbtnUpload_Click(object sender, EventArgs e)
    {
        string filePath = (sender as ImageButton).CommandArgument;
        string fullfilepath = uploadfolder + filePath;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(fullfilepath));
        Response.WriteFile(fullfilepath);
        Response.End();

    }
    protected void btnUploaddocument_Click(object sender, EventArgs e)
    {
        try
        {

            string resultFilePath = "";
            string fileName = Path.GetFileName(afuDocumentDetail.FileName);
            if (afuDocumentDetail.HasFile)
            {
                string extension = Path.GetExtension(afuDocumentDetail.FileName);
                string uniqueid = Guid.NewGuid().ToString();
                filepath = uploadfolder + uniqueid;
                DBfilepath = uploadfolderDBPath + uniqueid;
                resultFilePath = MapPath(filepath);
                afuDocumentDetail.SaveAs(resultFilePath);
                Session["image"] = Request.Files;
                UploadDocument();
               
              
            }
            else
            {
                Response.Write("<script>alert('Please Select Document file')</script>");
            }
         
        }
        catch (Exception ex)
        {
        }
    }
   
    protected void gvDocumentDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //{
    //    HiddenField hfidnew = (HiddenField)e.Row.FindControl("hfidnew");
     
    //  //  lblid.Text = hfidnew.Value;
    //}
       
    }
    protected void gvDocumentDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        var DocumentId = (HiddenField)gvDocumentDetail.Rows[e.RowIndex].FindControl("DocumentId");
        var PassportId = (HiddenField)gvDocumentDetail.Rows[e.RowIndex].FindControl("PassportId");
        var IDNumber = (Label)gvDocumentDetail.Rows[e.RowIndex].FindControl("IDNumber");    
        var DateOfIssue = (Label)gvDocumentDetail.Rows[e.RowIndex].FindControl("DateOfIssue");
        var DocumentDesc = (Label)gvDocumentDetail.Rows[e.RowIndex].FindControl("DocumentDesc");
        afuDocumentDetail.Visible=true;
    //    lblUploadDocument.Visible=true;
      //  lblDocumentDescription.Visible=true;
        txtDocumentdesc.Visible = true;
        btnUploaddocument.Visible = true;
           
     
    }

    protected void gvDocumentDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField ID = (HiddenField)gvDocumentDetail.Rows[e.RowIndex].FindControl("DocumentId");
        ds = objHrManagement.EmployeeDocumentDetailDelete(Convert.ToInt32(ID.Value));
        DisplayMessage(lbldocument, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvDocumentDetail.EditIndex = -1;
        FillgvDocumentDetail();
        for (int i = 0; i < gvDocumentDetail.Rows.Count; i++)
        {
            GridViewRow row = gvDocumentDetail.Rows[i];
            //GridView gvDocument = (GridView)row.FindControl("gvDocument");
            //if (gvDocument.Rows.Count > 0)
            //{
            //    lblUploadDocument.Visible = false;
            //    txtDocumentdesc.Visible = false;
            //    btnUploaddocument.Visible = false;
            //}
            //else
            //{
            //    lblUploadDocument.Visible = true;
            //    txtDocumentdesc.Visible = true;
            //    btnUploaddocument.Visible = true;
            //}
        }
    }
    protected void gvDocumentDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDocumentDetail.PageIndex = e.NewPageIndex;
        gvDocumentDetail.EditIndex = -1;
        FillgvDocumentDetail();
    }
    protected void btnEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
        HiddenField PassportId = (HiddenField)row.FindControl("PassportId");
       
    }
}


