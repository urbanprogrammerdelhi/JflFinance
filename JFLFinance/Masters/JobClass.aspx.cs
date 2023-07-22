// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="JobClass.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_JobClass
/// </summary>
public partial class Masters_JobClass : BasePage//System.Web.UI.Page
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
            javaScript.Append("PageTitle('" + Resources.Resource.JobClass + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvJobClass();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    /// <summary>
    /// Fillgvs the job class.
    /// </summary>
    private void FillgvJobClass()
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtJobClass = new DataTable();
        ds = objMasterManagement.JobClassMasterGetAll(BaseCompanyCode);
        dtJobClass = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtJobClass.Rows.Count > 0)
        {
            gvJobClass.DataSource = dtJobClass;
            gvJobClass.DataBind();
        }
        else
        {
            dtJobClass.Rows.Add(dtJobClass.NewRow());
            gvJobClass.DataSource = dtJobClass;
            gvJobClass.DataBind();
            int TotalColumns = gvJobClass.Rows[0].Cells.Count;
            gvJobClass.Rows[0].Cells.Clear();
            gvJobClass.Rows[0].Cells.Add(new TableCell());
            gvJobClass.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvJobClass.Rows[0].Cells[0].Text = "No Record Found";
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvJobClass control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvJobClass_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");

        if (lblSerialNo != null)
        {
            int serialNo = gvJobClass.PageIndex * gvJobClass.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvJobClass.Columns[3].Visible = false;
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
                TextBox txtJobClassDesc = (TextBox)e.Row.FindControl("txtJobClassDesc");
                if (txtJobClassDesc != null)
                {
                    txtJobClassDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtJobClassDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
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
                gvJobClass.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewJobClassCode = (TextBox)e.Row.FindControl("txtNewJobClassCode");
                if (txtNewJobClassCode != null)
                {
                    txtNewJobClassCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewJobClassCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewJobClassDesc = (TextBox)e.Row.FindControl("txtNewJobClassDesc");
                if (txtNewJobClassDesc != null)
                {
                    txtNewJobClassDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewJobClassDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvJobClass control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvJobClass_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        TextBox txtNewJobClassCode = (TextBox)gvJobClass.FooterRow.FindControl("txtNewJobClassCode");
        TextBox txtNewJobClassDesc = (TextBox)gvJobClass.FooterRow.FindControl("txtNewJobClassDesc");
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objblMasterManagement.JobClassMasterAddNew(BaseCompanyCode, txtNewJobClassCode.Text, txtNewJobClassDesc.Text, BaseUserID);
            if (gvJobClass.Rows.Count.Equals(gvJobClass.PageSize))
            {
                gvJobClass.PageIndex = gvJobClass.PageCount + 1;
            }
            gvJobClass.EditIndex = -1;
            FillgvJobClass();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewJobClassCode.Text = "";
            txtNewJobClassDesc.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvJobClass control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvJobClass_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvJobClass.EditIndex = e.NewEditIndex;
        FillgvJobClass();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvJobClass control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvJobClass_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblJobClassCode = (Label)gvJobClass.Rows[e.RowIndex].FindControl("lblJobClassCode");
        TextBox txtJobClassDesc = (TextBox)gvJobClass.Rows[e.RowIndex].FindControl("txtJobClassDesc");
        ds = objblMasterManagement.JobClassMasterUpdate(BaseCompanyCode, lblJobClassCode.Text, txtJobClassDesc.Text, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        gvJobClass.EditIndex = -1;
        FillgvJobClass();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvJobClass control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvJobClass_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvJobClass.EditIndex = -1;
        FillgvJobClass();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvJobClass control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvJobClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvJobClass.PageIndex = e.NewPageIndex;
        gvJobClass.EditIndex = -1;
        FillgvJobClass();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvJobClass control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvJobClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblJobClassCode = (Label)gvJobClass.Rows[e.RowIndex].FindControl("lblJobClassCode");
        ds = objblMasterManagement.JobClassMasterDelete(BaseCompanyCode, lblJobClassCode.Text);
        FillgvJobClass();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
}
