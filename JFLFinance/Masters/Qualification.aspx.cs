// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Qualification.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Qualification
/// </summary>
public partial class Masters_Qualification : BasePage//System.Web.UI.Page
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
            javaScript.Append("PageTitle('" + Resources.Resource.QualificationMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess==true)
            {
                FillgvQualification();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    #region Function To Fill GridView 

    /// <summary>
    /// Fillgvs the qualification.
    /// </summary>
    private void FillgvQualification()
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtQualification = new DataTable();
        ds = objblMasterManagement.QualificationMasterGetAll();
        dtQualification = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtQualification.Rows.Count > 0)
        {
            gvQualification.DataSource = dtQualification;
            gvQualification.DataBind();
        }
        else
        {
            dtQualification.Rows.Add(dtQualification.NewRow());
            gvQualification.DataSource = dtQualification;
            gvQualification.DataBind();
            int TotalColumns = gvQualification.Rows[0].Cells.Count;
            gvQualification.Rows[0].Cells.Clear();
            gvQualification.Rows[0].Cells.Add(new TableCell());
            gvQualification.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvQualification.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    #endregion

    #region GridViewEventFunctions
    /// <summary>
    /// Handles the RowEditing event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvQualification.EditIndex = e.NewEditIndex;
        FillgvQualification();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        TextBox txtQualificationDesc = (TextBox)gvQualification.Rows[e.RowIndex].FindControl("txtQualificationDesc");
        Label lblQualificationCode = (Label)gvQualification.Rows[e.RowIndex].FindControl("lblEditQualificationCode");
        ds=objMastersManagement.QualificationMasterUpdate(lblQualificationCode.Text, txtQualificationDesc.Text, BaseUserID);
        gvQualification.EditIndex = -1;
        FillgvQualification();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowCommand event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        TextBox txtNewQualificationDesc = (TextBox)gvQualification.FooterRow.FindControl("txtNewQualificationDesc");
        TextBox txtNewQualificationCode = (TextBox)gvQualification.FooterRow.FindControl("txtNewQualificationCode");
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        if (e.CommandName.Equals("AddNew"))
        {
            ds=objMasterManagement.QualificationMasterAddNew(txtNewQualificationCode.Text, txtNewQualificationDesc.Text, BaseUserID);
            if (gvQualification.Rows.Count.Equals(gvQualification.PageSize))
            {
                gvQualification.PageIndex = gvQualification.PageCount + 1;
            }
            gvQualification.EditIndex = -1;
            FillgvQualification();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewQualificationCode.Text = "";
            txtNewQualificationDesc.Text = "";
            lblErrorMsg.Text = "";
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvQualification_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the DataBound event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvQualification_DataBound(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQualification.EditIndex = -1;
        FillgvQualification();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        ds=objMasterManagement.QualificationMasterDelete(gvQualification.DataKeys[e.RowIndex].Value.ToString());
        FillgvQualification();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQualification.EditIndex = -1;
        gvQualification.PageIndex = e.NewPageIndex;
        FillgvQualification();
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       GridViewRow objGridViewRow = e.Row;
       Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvQualification.PageIndex * gvQualification.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvQualification.Columns[3].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEditQual = (ImageButton)e.Row.FindControl("IBEditQual");
                if (IBEditQual != null)
                {
                    IBEditQual.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdateQual = (ImageButton)e.Row.FindControl("ImgbtnUpdateQual");
                if (ImgbtnUpdateQual != null)
                {
                    ImgbtnUpdateQual.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtQualificationDesc = (TextBox)e.Row.FindControl("txtQualificationDesc");
                if (txtQualificationDesc != null)
                {
                    txtQualificationDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtQualificationDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }

            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteQual = (ImageButton)e.Row.FindControl("IBDeleteQual");
                if (IBDeleteQual != null)
                {
                    IBDeleteQual.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteQual = (ImageButton)e.Row.FindControl("IBDeleteQual");
                if (IBDeleteQual != null)
                {
                    IBDeleteQual.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

        }
    

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvQualification.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {

                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewQualificationCode = (TextBox)e.Row.FindControl("txtNewQualificationCode");
                if (txtNewQualificationCode != null)
                {
                    txtNewQualificationCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewQualificationCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewQualificationDesc = (TextBox)e.Row.FindControl("txtNewQualificationDesc");
                if (txtNewQualificationDesc != null)
                {
                    txtNewQualificationDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewQualificationDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }

    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string url = "../Masters/MasterExport.aspx?type=MASTER&eType=mstQualification";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }


  #endregion
}
