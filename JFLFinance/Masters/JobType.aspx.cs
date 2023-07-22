// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="JobType.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_JobType
/// </summary>
public partial class Masters_JobType : BasePage//System.Web.UI.Page
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
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.JobType + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvJobType();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    /// <summary>
    /// Fillgvs the type of the job.
    /// </summary>
    private void FillgvJobType()
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtJobType = new DataTable();
        ds = objMasterManagement.JobTypeMasterGetAll(BaseCompanyCode);
        dtJobType = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtJobType.Rows.Count > 0)
        {
            gvJobType.DataSource = dtJobType;
            gvJobType.DataBind();
        }
        else
        {
            dtJobType.Rows.Add(dtJobType.NewRow());
            gvJobType.DataSource = dtJobType;
            gvJobType.DataBind();
            int TotalColumns = gvJobType.Rows[0].Cells.Count;
            gvJobType.Rows[0].Cells.Clear();
            gvJobType.Rows[0].Cells.Add(new TableCell());
            gvJobType.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvJobType.Rows[0].Cells[0].Text = "No Record Found";
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvJobType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvJobType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        
        if (lblSerialNo != null)
        {
            int serialNo = gvJobType.PageIndex * gvJobType.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvJobType.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (IBEdit != null)
                {
                    IBEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtJobTypeDesc = (TextBox)e.Row.FindControl("txtJobTypeDesc");
                if (txtJobTypeDesc != null)
                {
                    txtJobTypeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtJobTypeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                }
            }
            else
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvJobType.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewJobTypeCode = (TextBox)e.Row.FindControl("txtNewJobTypeCode");
                if (txtNewJobTypeCode != null)
                {
                    txtNewJobTypeCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewJobTypeCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewJobTypeDesc = (TextBox)e.Row.FindControl("txtNewJobTypeDesc");
                if (txtNewJobTypeDesc != null)
                {
                    txtNewJobTypeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewJobTypeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvJobType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvJobType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        TextBox txtNewJobTypeCode = (TextBox)gvJobType.FooterRow.FindControl("txtNewJobTypeCode");
        TextBox txtNewJobTypeDesc = (TextBox)gvJobType.FooterRow.FindControl("txtNewJobTypeDesc");
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objblMasterManagement.JobTypeMasterAddNew(BaseCompanyCode, txtNewJobTypeCode.Text, txtNewJobTypeDesc.Text, BaseUserID);
            if (gvJobType.Rows.Count.Equals(gvJobType.PageSize))
            {
                gvJobType.PageIndex = gvJobType.PageCount + 1;
            }
            gvJobType.EditIndex = -1;
            FillgvJobType();
             DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewJobTypeCode.Text = "";
            txtNewJobTypeDesc.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvJobType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvJobType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvJobType.EditIndex = e.NewEditIndex;
        FillgvJobType();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvJobType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvJobType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblJobTypeCode = (Label)gvJobType.Rows[e.RowIndex].FindControl("lblJobTypeCode");
        TextBox txtJobTypeDesc = (TextBox)gvJobType.Rows[e.RowIndex].FindControl("txtJobTypeDesc");
        ds = objblMasterManagement.JobTypeMasterUpdate(BaseCompanyCode, lblJobTypeCode.Text, txtJobTypeDesc.Text, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        gvJobType.EditIndex = -1;
        FillgvJobType();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvJobType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvJobType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvJobType.EditIndex = -1;
        FillgvJobType();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvJobType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvJobType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvJobType.PageIndex = e.NewPageIndex;
        gvJobType.EditIndex = -1;
        FillgvJobType();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvJobType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvJobType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblJobTypeCode=(Label)gvJobType.Rows[e.RowIndex].FindControl("lblJobTypeCode");
        ds = objblMasterManagement.JobTypeMasterDelete(BaseCompanyCode, lblJobTypeCode.Text);
        FillgvJobType();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
}
