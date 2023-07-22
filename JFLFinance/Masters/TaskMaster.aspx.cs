// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="TaskMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_TaskMaster
/// </summary>
public partial class Masters_TaskMaster :  BasePage
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
            javaScript.Append("PageTitle('" + Resources.Resource.TaskMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                //hfspDecimalPlace.Value = "{0:n" + BaseDigitsAfterDecimalPlaces.ToString() + "}";
                FillgvTaskMaster();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion
    #region GridView TaskMaster Events
    /// <summary>
    /// Fillgvs the task master.
    /// </summary>
    protected void FillgvTaskMaster()
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objMaster.TaskMasterGet(BaseLocationAutoID);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvTaskMaster.DataKeyNames = new string[] { "TaskAutoId" };
        gvTaskMaster.DataSource = dt;
        gvTaskMaster.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvTaskMaster.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvTaskMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvTaskMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvTaskMaster.PageIndex * gvTaskMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvTaskMaster.Columns[4].Visible = false;
            }

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            if (IsWriteAccess == false)
            {
                gvTaskMaster.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvTaskMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvTaskMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        TextBox txtTaskDesc = (TextBox)gvTaskMaster.FooterRow.FindControl("txtTaskDesc");

        if (e.CommandName.Equals("AddNew"))
        {
            ds = objMaster.TaskMasterAddNew(BaseLocationAutoID, txtTaskDesc.Text.Trim(),BaseUserID);
            if (gvTaskMaster.Rows.Count.Equals(gvTaskMaster.PageSize))
            {
                gvTaskMaster.PageIndex = gvTaskMaster.PageCount + 1;
            }
            gvTaskMaster.EditIndex = -1;
            FillgvTaskMaster();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtTaskDesc.Text = "";
            lblErrorMsg.Text = "";
        }
        else
        {

        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvTaskMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvTaskMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTaskMaster.EditIndex = e.NewEditIndex;
        FillgvTaskMaster();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvTaskMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvTaskMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();

        HiddenField hfTaskAutoId = (HiddenField)gvTaskMaster.Rows[e.RowIndex].FindControl("hfTaskAutoId");
        TextBox txtTaskDesc = (TextBox)gvTaskMaster.Rows[e.RowIndex].FindControl("txtTaskDesc");

        ds = objMaster.TaskMasterUpdate(hfTaskAutoId.Value, txtTaskDesc.Text.Trim(),BaseUserID);

        gvTaskMaster.EditIndex = -1;
        FillgvTaskMaster();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvTaskMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvTaskMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTaskMaster.EditIndex = -1;
        FillgvTaskMaster();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvTaskMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvTaskMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        HiddenField hfTaskAutoId = (HiddenField)gvTaskMaster.Rows[e.RowIndex].FindControl("hfTaskAutoId");
        Label lblTaskDesc = (Label)gvTaskMaster.Rows[e.RowIndex].FindControl("lblTaskDesc");

        ds = objMaster.TaskMasterDelete(hfTaskAutoId.Value);
        FillgvTaskMaster();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvTaskMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvTaskMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTaskMaster.PageIndex = e.NewPageIndex;
        gvTaskMaster.EditIndex = -1;
        FillgvTaskMaster();
    }
    #endregion
}