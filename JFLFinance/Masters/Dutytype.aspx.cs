// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Dutytype.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Dutytype
/// </summary>
public partial class Masters_Dutytype : BasePage//System.Web.UI.Page
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
            javaScript.Append("PageTitle('" + Resources.Resource.DutytypeMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess==true)
            {
                FillgvDutytype();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    #region Function To Fill GridView 

    /// <summary>
    /// Fillgvs the dutytype.
    /// </summary>
    private void FillgvDutytype()
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtDutytype = new DataTable();
        ds = objblMasterManagement.DutyTypeGetAll(BaseCompanyCode); 
        dtDutytype = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtDutytype.Rows.Count > 0)
        {
            gvDutytype.DataSource = dtDutytype;
            gvDutytype.DataBind();
        }
        else
        {
            dtDutytype.Rows.Add(dtDutytype.NewRow());
            gvDutytype.DataSource = dtDutytype;
            gvDutytype.DataBind();
            int TotalColumns = gvDutytype.Rows[0].Cells.Count;
            gvDutytype.Rows[0].Cells.Clear();
            gvDutytype.Rows[0].Cells.Add(new TableCell());
            gvDutytype.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvDutytype.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    #endregion

    #region GridViewEventFunctions

    /// <summary>
    /// Handles the RowEditing event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDutytype.EditIndex = e.NewEditIndex;
        FillgvDutytype();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        TextBox txtDutytypeDesc = (TextBox)gvDutytype.Rows[e.RowIndex].FindControl("txtDutytypeDesc");
        Label lblDutytypeCode = (Label)gvDutytype.Rows[e.RowIndex].FindControl("lblEditDutytypeCode");
        CheckBox chkIsBillable = (CheckBox)gvDutytype.Rows[e.RowIndex].FindControl("chkIsBillable");
        CheckBox chkIsActive = (CheckBox)gvDutytype.Rows[e.RowIndex].FindControl("chkIsActive");
        CheckBox chkIsdefault = (CheckBox)gvDutytype.Rows[e.RowIndex].FindControl("chkIsDefault");
        ds = objMastersManagement.DutyTypeUpdate(lblDutytypeCode.Text, txtDutytypeDesc.Text, chkIsBillable.Checked.ToString()  , chkIsActive.Checked.ToString(), chkIsdefault.Checked.ToString(),  BaseUserID);
        gvDutytype.EditIndex = -1;
        FillgvDutytype();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowCommand event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        TextBox txtNewDutytypeDesc = (TextBox)gvDutytype.FooterRow.FindControl("txtNewDutytypeDesc");
      //  TextBox txtNewDutytypeCode = (TextBox)gvDutytype.FooterRow.FindControl("txtNewDutytypeCode");
        CheckBox chkNewIsBillable = (CheckBox)gvDutytype.FooterRow.FindControl("chkNewIsBillable");
        CheckBox chkNewIsActive = (CheckBox)gvDutytype.FooterRow.FindControl("chkNewIsActive");
        CheckBox chkNewIsdefault = (CheckBox)gvDutytype.FooterRow.FindControl("chkNewIsDefault");

        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objMasterManagement.DutyTypeAddNew(txtNewDutytypeDesc.Text,bool.Parse(chkNewIsBillable.Checked.ToString()),bool.Parse(chkNewIsActive.Checked.ToString()),bool.Parse(chkNewIsdefault.Checked.ToString()), BaseUserID,BaseCompanyCode,BaseHrLocationCode,BaseLocationCode);
            if (gvDutytype.Rows.Count.Equals(gvDutytype.PageSize))
            {
                gvDutytype.PageIndex = gvDutytype.PageCount + 1;
            }
            gvDutytype.EditIndex = -1;
            FillgvDutytype();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
        //    txtNewDutytypeCode.Text = "";
            txtNewDutytypeDesc.Text = "";
            lblErrorMsg.Text = "";
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the DataBound event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_DataBound(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDutytype.EditIndex = -1;
        FillgvDutytype();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        ds = objMasterManagement.DutyTypeDelete(gvDutytype.DataKeys[e.RowIndex].Value.ToString());
        FillgvDutytype();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDutytype.EditIndex = -1;
        gvDutytype.PageIndex = e.NewPageIndex;
        FillgvDutytype();
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvDutytype control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvDutytype_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       GridViewRow objGridViewRow = e.Row;
       Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvDutytype.PageIndex * gvDutytype.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvDutytype.Columns[3].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEditDT = (ImageButton)e.Row.FindControl("IBEditDT");
                if (IBEditDT != null)
                {
                    IBEditDT.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdateDT = (ImageButton)e.Row.FindControl("ImgbtnUpdateDT");
                if (ImgbtnUpdateDT != null)
                {
                    ImgbtnUpdateDT.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtDutytypeDesc = (TextBox)e.Row.FindControl("txtDutytypeDesc");
                if (txtDutytypeDesc != null)
                {
                    txtDutytypeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtDutytypeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }

            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteDT = (ImageButton)e.Row.FindControl("IBDeleteDT");
                if (IBDeleteDT != null)
                {
                    IBDeleteDT.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteDT = (ImageButton)e.Row.FindControl("IBDeleteDT");
                if (IBDeleteDT != null)
                {
                    IBDeleteDT.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

        }
    

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvDutytype.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {

                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewDutytypeDesc = (TextBox)e.Row.FindControl("txtNewDutytypeDesc");
                if (txtNewDutytypeDesc != null)
                {
                    txtNewDutytypeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewDutytypeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
  #endregion
}
