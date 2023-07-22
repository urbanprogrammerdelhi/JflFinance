using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Masters_PrePostFix : BasePage
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

    #region Page Functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + "PrePostFix" + "');");
            //javaScript.Append("PageTitle('" + Resources.Resource.PrePostFix + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            if (IsReadAccess == true)
            {
                FillgvPrePostFix();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Button Events
    /// <summary>
    /// Submit button click event
    /// </summary>
    /// <param name="sender">Selected Index Changed Object</param>
    /// <param name="e">Click Event</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in gvPrePostFix.Rows)
        {
            string SeqField=((Label)gvRow.FindControl("lblgvSeqField")).Text.Trim();
             bool IsAutoUpdatePostFix=((CheckBox)gvRow.FindControl("chkIsAutoUpdatePostFix")).Checked;
            string PrefixStr=((TextBox)gvRow.FindControl("txtPrefixStr")).Text.Trim();
            string PostfixStr = ((TextBox)gvRow.FindControl("txtPostfixStr")).Text.Trim();
            string RunningSeq = ((TextBox)gvRow.FindControl("txtRunningSeq")).Text.Trim();

            if (string.IsNullOrEmpty(RunningSeq))
            {
                RunningSeq = "0";
            }
                      

            BL.MastersManagement objHRManagement = new BL.MastersManagement();
            
            DataSet ds = objHRManagement.PrePostFixInsertUpdate(BaseCompanyCode, SeqField, IsAutoUpdatePostFix, PrefixStr, PostfixStr, RunningSeq);
            
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
               
            }
        }
        FillgvPrePostFix();

    }
    #endregion 

    #region GridView PrePostFix Events
    /// <summary>
    /// Fillgvs the PrePostFix master.
    /// </summary>
    protected void FillgvPrePostFix()
    {
       var objMaster = new BL.MastersManagement();
       var ds = new DataSet();
       var dt = new DataTable();
        ds = objMaster.PrePostFixGet(BaseCompanyCode);
        dt = ds.Tables[0];

        //to bind Rows gridview
        if (dt.Rows.Count >= 0)
        {
            gvPrePostFix.DataKeyNames = new string[] { "SeqField" };
            gvPrePostFix.DataSource = dt;
            gvPrePostFix.DataBind();
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvPrePostFix control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvPrePostFix_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow gvRow = e.Row;
            TextBox txtPrefixStr = ((TextBox)gvRow.FindControl("txtPrefixStr"));
            TextBox txtPostfixStr = ((TextBox)gvRow.FindControl("txtPostfixStr"));
            TextBox txtRunningSeq = ((TextBox)gvRow.FindControl("txtRunningSeq"));
            string InsertUpdateStatus=((HiddenField)gvRow.FindControl("hdnInsertUpdateStatus")).Value.Trim();

            if (InsertUpdateStatus == "Insert")
            {
                txtPostfixStr.Enabled = true;
                txtPrefixStr.Enabled = true;
                txtRunningSeq.Enabled = true;
            }
            else if (InsertUpdateStatus == "Update")
            {
                txtPostfixStr.Enabled = false;
                txtPrefixStr.Enabled = false;
                txtRunningSeq.Enabled = false;
            }

            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvPrePostFix.PageIndex * gvPrePostFix.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
           
         
               
            
        }

    }

    #endregion
}