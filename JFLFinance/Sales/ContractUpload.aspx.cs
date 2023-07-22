// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ContractUpload.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Class Sales_ContractUpload.
/// </summary>
public partial class Sales_ContractUpload : BasePage//System.Web.UI.Page
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
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.ContractMaster;
            //}
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ContractMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                int MaxAmendmentNo = GetMaxAmendNo();
                if (MaxAmendmentNo == int.Parse(Request.QueryString["AmendmentNo"]))
                {
                    if (IsWriteAccess==true && (Request.QueryString["Status"] == Resources.Resource.Authorized || Request.QueryString["Status"] == Resources.Resource.Fresh || Request.QueryString["Status"] == Resources.Resource.Amend))
                    {

                        DIVUpload.Visible = true;
                        FillgvContractDownload();
                    }
                    else //if (Request.QueryString["Status"] == Resources.Resource.ShortClosed)
                    {
                        DIVUpload.Visible = false;
                        FillgvContractDownload();
                    }
                }
                else
                {
                    DIVUpload.Visible = false;
                    FillgvContractDownload();
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.ReadAccess;
            }

        }
    }
    #region To get Max Amend Number
    /// <summary>
    /// Gets the maximum amend no.
    /// </summary>
    /// <returns>System.Int32.</returns>
    private int GetMaxAmendNo()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        int MaxAmendNo = 0;
        ds = objSales.ContractMasterAmendNoGet(Request.QueryString["ClientCode"], Request.QueryString["ContractNumber"]);
        try
        {
            MaxAmendNo = int.Parse(ds.Tables[0].Rows[0]["AmendNo"].ToString());
           
        }
        catch (Exception)
        {
        }
        finally { }
        return MaxAmendNo;
    }
    #endregion
    /// <summary>
    /// Fillgvs the contract download.
    /// </summary>
    private void FillgvContractDownload()
    {
        string strContractNumber = Request.QueryString["ContractNumber"];
        int intAmendmentNo = int.Parse(Request.QueryString["AmendmentNo"]);
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dtContractDownload = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.ContractMasterDownload(strContractNumber, intAmendmentNo);
        dtContractDownload = ds.Tables[0];
        //to fix empety gridview
        if (dtContractDownload.Rows.Count == 0)
        {
            DivGridView.Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
        gvContractDownload.DataSource = dtContractDownload;
        gvContractDownload.DataBind();
    }
    /// <summary>
    /// Handles the Click event of the btnUpload1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpload1_Click(object sender, EventArgs e)
    {
        String path = Server.MapPath("../DocumentUpload/ContractUpload/");
        string strContractNumber = Request.QueryString["ContractNumber"];
        int intAmendmentNo=int.Parse(Request.QueryString["AmendmentNo"]);
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        string DIRPath;
        string FileName;
        DIRPath = path;
        if (ContractFileUpload.HasFile)
        {
            //// commented by Manish on 02oct11 and added by below line againsed QA point Upload/Download link page giving error
            //// ContractNumber is like Co00002/2 which should not be part of file name   
            ////FileName = strContractNumber + '[' + intAmendmentNo + ']' + ContractFileUpload.FileName;
            FileName = strContractNumber.Replace("/", "_") + '_' + intAmendmentNo + '_' + ContractFileUpload.FileName;

            //String fileExtension = System.IO.Path.GetExtension(ContractFileUpload.FileName).ToLower();
            DIRPath = DIRPath + FileName;
            //while(File.Exists(FileName))
            //{
            //    FileName = FileName + strContractNumber + '_' + intAmendmentNo + String.Format("dd-MM-yyyy",DateTime.Now.ToString()) + '1' + fileExtension;
            //}
            ds = objSales.ContractUpload(strContractNumber, intAmendmentNo, txtUploadDesc.Text, FileName, BaseUserID);
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                ContractFileUpload.PostedFile.SaveAs(DIRPath);
                FillgvContractDownload();
                DivGridView.Visible = true;
            }
        }
        //if (ContractFileUpload.HasFile)
        //{
        //    FileName = strContractNumber + '[' + intAmendmentNo + ']' + ContractFileUpload.FileName;
        //    //String fileExtension = System.IO.Path.GetExtension(ContractFileUpload.FileName).ToLower();
        //    DIRPath = DIRPath + FileName;
        //    //while(File.Exists(FileName))
        //    //{
        //    //    FileName = FileName + strContractNumber + '_' + intAmendmentNo + String.Format("dd-MM-yyyy",DateTime.Now.ToString()) + '1' + fileExtension;
        //    //}
        //    ds = objSales.blContractMaster_ContractUpload(strContractNumber, intAmendmentNo, txtUploadDesc.Text, FileName, BaseUserID);
        //    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == false)
        //    {
        //        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        //    }
        //    else
        //    {
        //        ContractFileUpload.PostedFile.SaveAs(DIRPath);
        //        FillgvContractDownload();
        //        DivGridView.Visible = true;
        //    }
        //}
    }
    /// <summary>
    /// Handles the Click event of the lbFileName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbFileName_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbFileName = (LinkButton)gvContractDownload.Rows[row.RowIndex].FindControl("lbFileName");
        String path = Server.MapPath("../DocumentUpload/ContractUpload/");
        string FileName = path;
        FileName = FileName + lbFileName.Text;
        System.IO.FileInfo file = new System.IO.FileInfo(FileName);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvContractDownload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvContractDownload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow objGridViewRow = e.Row;
            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvContractDownload.PageIndex * gvContractDownload.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
            if (IsDeleteAccess == true)
            {
                if (IBDelete != null)
                { 
                    IBDelete.Visible = true;
                    gvContractDownload.Columns[3].Visible = true;
                }
            }
            else
            {
                if (IBDelete != null)
                { 
                    IBDelete.Visible = false;
                    gvContractDownload.Columns[3].Visible = false;
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowDeleting event of the gvContractDownload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvContractDownload_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        string strContractNumber = Request.QueryString["ContractNumber"];
        int intAmendmentNo = int.Parse(Request.QueryString["AmendmentNo"]);
        LinkButton lbFileName = (LinkButton)gvContractDownload.Rows[e.RowIndex].FindControl("lbFileName");
        ImageButton IBDelete = (ImageButton)gvContractDownload.Rows[e.RowIndex].FindControl("IBDelete");
        ds = objSales.ContractUploadDelete(lbFileName.Text, strContractNumber,intAmendmentNo);
        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
        {
            DeleteFile(lbFileName.Text);
        }
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Deletes the file.
    /// </summary>
    /// <param name="strFileName">Name of the string file.</param>
    public void DeleteFile(string strFileName)
    {
        String path = Server.MapPath("../DocumentUpload/ContractUpload/");
        FileInfo TheFile = new FileInfo(path + strFileName);
        if (TheFile.Exists)
        {
            File.Delete(path + strFileName);
        }
        FillgvContractDownload();
    }
}
