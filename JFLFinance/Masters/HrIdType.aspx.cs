// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="HrIdType.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_HrIdType
/// </summary>
public partial class Masters_HrIdType : BasePage
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
            javaScript.Append("PageTitle('" + Resources.Resource.IDTypeMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());



            if (IsReadAccess == true)
            {
                FillgvIdType();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }
    #endregion
    #region GridView Binding
    /// <summary>
    /// Fillgvs the type of the id.
    /// </summary>
    protected void FillgvIdType()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsIdType = new DataSet();
        DataTable dtIdType = new DataTable();
        int dtflag;
        dtflag = 1;

        dsIdType = objMastersManagement.IdTypeGetAll();
        dtIdType = dsIdType.Tables[0];

        //to fix empety gridview
        if (dtIdType.Rows.Count == 0)
        {
            dtflag = 0;
            dtIdType.Rows.Add(dtIdType.NewRow());
        }

        gvIdType.DataKeyNames = new string[] { "IDTypeCode" };
        gvIdType.DataSource = dtIdType;
        gvIdType.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvIdType.Rows[0].Visible = false;
        }

    }
    #endregion
    #region GridView Commands Events
    /// <summary>
    /// Handles the RowDataBound event of the gvIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvIdType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvIdType.PageIndex * gvIdType.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvIdType.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtIdTypeDesc = (TextBox)e.Row.FindControl("txtIdTypeDesc");
                if (txtIdTypeDesc != null)
                {
                    txtIdTypeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtIdTypeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvIdType.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtIdTypeCode = (TextBox)e.Row.FindControl("txtIdTypeCode");
                if (txtIdTypeCode != null)
                {
                    txtIdTypeCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtIdTypeCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtIdTypeDesc = (TextBox)e.Row.FindControl("txtIdTypeDesc");
                if (txtIdTypeDesc != null)
                {
                    txtIdTypeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtIdTypeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvIdType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        // To Insert a New Row
        TextBox txtIdTypeCode = (TextBox)gvIdType.FooterRow.FindControl("txtIdTypeCode");
        TextBox txtIdTypeDesc = (TextBox)gvIdType.FooterRow.FindControl("txtIdTypeDesc");

        if (e.CommandName == "Add")
        {
            ds = objMastersManagement.IdTypeInsert(txtIdTypeCode.Text, txtIdTypeDesc.Text, BaseUserID.ToString());
            gvIdType.EditIndex = -1;
            FillgvIdType();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
        if (e.CommandName == "Reset")
        {
            txtIdTypeCode.Text = "";
            txtIdTypeDesc.Text = "";

        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvIdType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvIdType.EditIndex = e.NewEditIndex;
        FillgvIdType();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvIdType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvIdType.EditIndex = -1;
        FillgvIdType();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvIdType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        Label lblgvhdrIdTypeCode = (Label)gvIdType.Rows[e.RowIndex].FindControl("lblgvhdrIdTypeCode");
        TextBox txtIdTypeDesc = (TextBox)gvIdType.Rows[e.RowIndex].FindControl("txtIdTypeDesc");

        ds = objMastersManagement.IdTypeUpdate(lblgvhdrIdTypeCode.Text, txtIdTypeDesc.Text, BaseUserID.ToString());
        gvIdType.EditIndex = -1;
        FillgvIdType();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvIdType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblgvhdrIdTypeCode = (Label)gvIdType.Rows[e.RowIndex].FindControl("lblgvhdrIdTypeCode");
        ds = objMastersManagement.IdTypeDelete(lblgvhdrIdTypeCode.Text);
        FillgvIdType();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvIdType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvIdType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvIdType.PageIndex = e.NewPageIndex;
        gvIdType.EditIndex = -1;
        FillgvIdType();
    }
    #endregion
    #region Controles Command Events
    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MasterMenu.aspx");
    }

    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string url = "../Masters/MasterExport.aspx?type=MASTER&eType=mstHRIDType";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    #endregion

}