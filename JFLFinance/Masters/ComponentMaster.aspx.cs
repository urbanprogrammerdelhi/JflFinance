// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="ComponentMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_ComponentMaster
/// </summary>
public partial class Masters_ComponentMaster : BasePage
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
            javaScript.Append("PageTitle('" + Resources.Resource.ComponentMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvComponentMaster();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }

    }
    /// <summary>
    /// Fillgvs the component master.
    /// </summary>
    public void FillgvComponentMaster()
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtComponentMaster = new DataTable();
        ds = objblMasterManagement.ComponentMasterGetAll(BaseCompanyCode);
        dtComponentMaster = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtComponentMaster.Rows.Count > 0)
        {
            gvComponentMaster.DataSource = dtComponentMaster;
            gvComponentMaster.DataBind();
        }
        else
        {
            dtComponentMaster.Rows.Add(dtComponentMaster.NewRow());
            gvComponentMaster.DataSource = dtComponentMaster;
            gvComponentMaster.DataBind();
            int TotalColumns = gvComponentMaster.Rows[0].Cells.Count;
            gvComponentMaster.Rows[0].Cells.Clear();
            gvComponentMaster.Rows[0].Cells.Add(new TableCell());
            gvComponentMaster.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvComponentMaster.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");

        if (lblSerialNo != null)
        {
            int serialNo = gvComponentMaster.PageIndex * gvComponentMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvComponentMaster.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            // e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEditTran = (ImageButton)e.Row.FindControl("IBEditTran");
                if (IBEditTran != null)
                {
                    IBEditTran.Visible = false;
                }

            }
            else
            {
                ImageButton ImgbtnUpdateTran = (ImageButton)e.Row.FindControl("ImgbtnUpdateTran");
                if (ImgbtnUpdateTran != null)
                {
                    ImgbtnUpdateTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtComponentDesc = (TextBox)e.Row.FindControl("txtComponentDesc");
                if (txtComponentDesc != null)
                {
                    txtComponentDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtComponentDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvComponentMaster.ShowFooter = false;
            }
            else
            {
                Label lblNewCompanyCode = (Label)e.Row.FindControl("lblNewCompanyCode");
                lblNewCompanyCode.Text = BaseCompanyCode;
                ImageButton lbAdd = (ImageButton)e.Row.FindControl("lbAdd");
                if (lbAdd != null)
                {
                    lbAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewComponentCode = (TextBox)e.Row.FindControl("txtNewComponentCode");
                if (txtNewComponentCode != null)
                {
                    txtNewComponentCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewComponentCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewComponentDesc = (TextBox)e.Row.FindControl("txtNewComponentDesc");
                if (txtNewComponentDesc != null)
                {
                    txtNewComponentDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewComponentDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        TextBox txtNewComponentCode = (TextBox)gvComponentMaster.FooterRow.FindControl("txtNewComponentCode");
        TextBox txtNewComponentDesc = (TextBox)gvComponentMaster.FooterRow.FindControl("txtNewComponentDesc");
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objblMasterManagement.ComponentMasterAdd(BaseCompanyCode, txtNewComponentCode.Text, txtNewComponentDesc.Text, BaseUserID);
            if (gvComponentMaster.Rows.Count.Equals(gvComponentMaster.PageSize))
            {
                gvComponentMaster.PageIndex = gvComponentMaster.PageCount + 1;
            }
            gvComponentMaster.EditIndex = -1;
            FillgvComponentMaster();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewComponentCode.Text = "";
            txtNewComponentDesc.Text = "";
            lblErrorMsg.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvComponentMaster.EditIndex = e.NewEditIndex;
        FillgvComponentMaster();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblComponentCode = (Label)gvComponentMaster.Rows[e.RowIndex].FindControl("lblComponentCode");
        TextBox txtComponentDesc = (TextBox)gvComponentMaster.Rows[e.RowIndex].FindControl("txtComponentDesc");
        ds = objblMasterManagement.ComponentMasterUpdate(BaseCompanyCode, lblComponentCode.Text, txtComponentDesc.Text, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        gvComponentMaster.EditIndex = -1;
        FillgvComponentMaster();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvComponentMaster.EditIndex = -1;
        FillgvComponentMaster();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objblMasterManagement.ComponentMasterDelete(gvComponentMaster.DataKeys[e.RowIndex].Values["CompanyCode"].ToString(), gvComponentMaster.DataKeys[e.RowIndex].Values["ComponentCode"].ToString());
        FillgvComponentMaster();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvComponentMaster.PageIndex = e.NewPageIndex;
        gvComponentMaster.EditIndex = -1;
        FillgvComponentMaster();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Handles the RowCreated event of the gvComponentMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvComponentMaster_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
    }

}