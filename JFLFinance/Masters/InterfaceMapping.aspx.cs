// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="InterfaceMapping.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/// <summary>
/// Class Masters_InterfaceMapping
/// </summary>
public partial class Masters_InterfaceMapping : BasePage
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
    #region Page Load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillMainGroup();
            FillSubGroup();
        }
    }
    #endregion
    #region Grid Events
    /// <summary>
    /// Handles the PageIndexChanging event of the gvInterfaceMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvInterfaceMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInterfaceMapping.EditIndex = -1;
        gvInterfaceMapping.PageIndex = e.NewPageIndex;
        FillgvInterfaceMapping();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvInterfaceMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvInterfaceMapping_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvInterfaceMapping.EditIndex = -1;
        FillgvInterfaceMapping();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvInterfaceMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvInterfaceMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowCommand event of the gvInterfaceMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvInterfaceMapping_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Add New
        if (e.CommandName.Equals("AddNew"))
        {
            lblErrorMsg.Text = "New Row Can't be Added";
            return;
            //DataSet ds = new DataSet();
            //BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            //HiddenField hfRowAutoId = (HiddenField)gvInterfaceMapping.FooterRow.FindControl("hfRowAutoId");

            //TextBox txtSColumnName = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtSColumnName");
            //TextBox txtColumnName = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtColumnName");

            //TextBox txtSDataType = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtSDataType");
            //DropDownList ddlDataType = (DropDownList)gvInterfaceMapping.FooterRow.FindControl("ddlDataType");
            //TextBox txtSLength = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtSLength");
            //TextBox txtLength = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtLength");
            //TextBox txtSPerc = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtSPerc");

            //TextBox txtPerc = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtPerc");
            //CheckBox cbSNullable = (CheckBox)gvInterfaceMapping.FooterRow.FindControl("cbSNullable");

            //CheckBox cbNullable = (CheckBox)gvInterfaceMapping.FooterRow.FindControl("cbNullable");
            //CheckBox cbSEditable = (CheckBox)gvInterfaceMapping.FooterRow.FindControl("cbSEditable");

            //TextBox txtDataBaseName = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtDataBaseName");
            //TextBox txtTableName = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtTableName");
            //TextBox txtSCollation = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtSCollation");

            //HiddenField hfSTableName = (HiddenField)gvInterfaceMapping.FooterRow.FindControl("hfSTableName");
            //HiddenField hfSCollation = (HiddenField)gvInterfaceMapping.FooterRow.FindControl("hfSCollation");
            //HiddenField hfScreenName = (HiddenField)gvInterfaceMapping.FooterRow.FindControl("hfScreenName");

            //TextBox txtCollation = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtCollation");

            //TextBox txtSScreenFieldName = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtSScreenFieldName");
            //TextBox txtScreenFieldName = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtScreenFieldName");
            //TextBox txtSDescription = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtSDescription");
            //TextBox txtDescription = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtDescription");

            //CheckBox cbSMandatory = (CheckBox)gvInterfaceMapping.FooterRow.FindControl("cbSMandatory"); 


            //TextBox txtColor = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtColor");
            //DropDownList ddlSourceType = (DropDownList)gvInterfaceMapping.FooterRow.FindControl("ddlSourceType");
            //TextBox txtDefaultValue = (TextBox)gvInterfaceMapping.FooterRow.FindControl("txtDefaultValue");
            //CheckBox cbIsProvided = (CheckBox)gvInterfaceMapping.FooterRow.FindControl("cbIsProvided");

            //ds = objMastersManagement.MstInterfaceMappingInsert(
            //    txtSColumnName.Text.Trim(), txtColumnName.Text.Trim(),
            //    txtSDataType.Text.Trim(), ddlDataType.SelectedValue,
            //    int.Parse(txtSLength.Text.Trim()),
            //    int.Parse(txtLength.Text),
            //    int.Parse(txtSPerc.Text.Trim()),
            //    int.Parse(txtPerc.Text),
            //    cbSNullable.Checked,
            //    cbNullable.Checked,
            //    cbSEditable.Checked,
            //    hfSTableName.Value.Trim(),
            //    txtDataBaseName.Text.Trim(),
            //    txtTableName.Text.Trim(),
            //    hfSCollation.Value.Trim(),
            //    txtCollation.Text.Trim(), hfScreenName.Value.Trim(), txtSScreenFieldName.Text.Trim(), txtScreenFieldName.Text.Trim(),
            //    txtSDescription.Text.Trim(), txtDescription.Text.Trim(),
            //    cbSMandatory.Checked, txtColor.Text.Trim(), int.Parse(ddlSourceType.SelectedValue), txtDefaultValue.Text.Trim(), cbIsProvided.Checked, BaseUserID);
            //gvInterfaceMapping.EditIndex = -1;
            //FillgvInterfaceMapping();
            //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            lblErrorMsg.Text = "";
        }
        
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvInterfaceMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvInterfaceMapping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvInterfaceMapping.PageIndex * gvInterfaceMapping.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (!IsWriteAccess && !IsModifyAccess && !IsDeleteAccess)
        {
            gvInterfaceMapping.Columns [27].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (!IsModifyAccess)
            {
                ImageButton IBEditMapping = (ImageButton)e.Row.FindControl("IBEditMapping");
                if (IBEditMapping != null)
                {
                    IBEditMapping.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdateMapping = (ImageButton)e.Row.FindControl("ImgbtnUpdateMapping");
                if (ImgbtnUpdateMapping != null)
                {
                    ImgbtnUpdateMapping.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtSColumnName = (TextBox)e.Row.FindControl("txtSColumnName");
                if (txtSColumnName != null)
                {
                    txtSColumnName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtSColumnName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }

            if (!IsDeleteAccess)
            {
                ImageButton IBDeleteMapping = (ImageButton)e.Row.FindControl("IBDeleteMapping");
                if (IBDeleteMapping != null)
                {
                    IBDeleteMapping.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteMapping = (ImageButton)e.Row.FindControl("IBDeleteMapping");
                if (IBDeleteMapping != null)
                {
                    IBDeleteMapping.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        
            // Mandatory Fields Come First and with different color
            if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "SMandatory")) == true)
            {
                e.Row.BackColor = System.Drawing.Color.Tan;
                //e.Row.Font.Bold = true;
            }

            Label lblSourceType = (Label)e.Row.FindControl("lblSourceType");

            // Assign Table or View
            if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SourceType")) == 1)
            {
                if (lblSourceType != null)
                {
                    lblSourceType.Text = "Table";
                }
            }
            // Assign Table or View
            if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SourceType")) == 2)
            {
                if (lblSourceType != null)
                {
                    lblSourceType.Text = "View";
                }
            }

        }


        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (!IsWriteAccess)
            {
                gvInterfaceMapping.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {

                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtSColumnName = (TextBox)e.Row.FindControl("txtSColumnName");
                if (txtSColumnName != null)
                {
                    txtSColumnName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtSColumnName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvInterfaceMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvInterfaceMapping_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvInterfaceMapping.EditIndex = e.NewEditIndex;
        FillgvInterfaceMapping();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvInterfaceMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvInterfaceMapping_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Update Existing


        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        HiddenField hfRowAutoId = (HiddenField)gvInterfaceMapping.Rows[e.RowIndex].FindControl("hfRowAutoId");

        TextBox txtSColumnName = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtSColumnName");
        TextBox txtColumnName = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtColumnName");
        
        TextBox txtSDataType = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtSDataType");
        TextBox txtSLength = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtSLength");
        TextBox txtSPerc = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtSPerc");
        CheckBox cbSNullable = (CheckBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("cbSNullable");
        CheckBox cbSEditable = (CheckBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("cbSEditable");
        TextBox txtSScreenFieldName = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtSScreenFieldName");
        TextBox txtScreenFieldName = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtScreenFieldName");
        TextBox txtSDescription = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtSDescription");
        CheckBox cbSMandatory = (CheckBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("cbSMandatory");


        Label lblSCollation = (Label)gvInterfaceMapping.Rows[e.RowIndex].FindControl("lblSCollation");
        Label lblSTableName = (Label)gvInterfaceMapping.Rows[e.RowIndex].FindControl("lblSTableName");
        Label lblScreenName = (Label)gvInterfaceMapping.Rows[e.RowIndex].FindControl("lblScreenName");
        
        DropDownList ddlDataType = (DropDownList)gvInterfaceMapping.Rows[e.RowIndex].FindControl("ddlDataType");        
        TextBox txtLength = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtLength");        
        TextBox txtPerc = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtPerc");
        CheckBox cbNullable = (CheckBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("cbNullable");
        TextBox txtDataBaseName = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtDataBaseName");
        TextBox txtTableName = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtTableName");
        TextBox txtCollation = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtCollation");
        TextBox txtDescription = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtDescription");

        TextBox txtColor = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtColor");
        DropDownList ddlSourceType = (DropDownList)gvInterfaceMapping.Rows[e.RowIndex].FindControl("ddlSourceType");
        TextBox txtDefaultValue = (TextBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("txtDefaultValue");
        CheckBox cbIsProvided = (CheckBox)gvInterfaceMapping.Rows[e.RowIndex].FindControl("cbIsProvided");


        ds = objMastersManagement.MstInterfaceMappingUpdate(decimal.Parse(hfRowAutoId.Value), 
            txtSColumnName.Text.Trim(), txtColumnName.Text.Trim(),
            txtSDataType.Text.Trim(),ddlDataType.SelectedValue,
            int.Parse(txtSLength.Text.Trim()),
            int.Parse(txtLength.Text),
            int.Parse(txtSPerc.Text.Trim()),
            int.Parse(txtPerc.Text),
            cbSNullable.Checked,
            cbNullable.Checked,
            cbSEditable.Checked,
            lblSTableName.Text.Trim(),
            txtDataBaseName.Text.Trim(),
            txtTableName.Text.Trim(),
            lblSCollation.Text.Trim(),
            txtCollation.Text.Trim(), lblScreenName.Text.Trim(), txtSScreenFieldName.Text.Trim(), txtScreenFieldName.Text.Trim(),
            txtSDescription.Text.Trim(),txtDescription.Text.Trim(),
            cbSMandatory.Checked,txtColor.Text.Trim(),int.Parse(ddlSourceType.SelectedValue),txtDefaultValue.Text.Trim(),cbIsProvided.Checked,BaseUserID);
        gvInterfaceMapping.EditIndex = -1;
        FillgvInterfaceMapping();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    #endregion
    #region Page Events
    /// <summary>
    /// Handles the SelectedIndexChange event of the ddlMainGroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMainGroup_SelectedIndexChange(object sender, EventArgs e)
    {
        FillSubGroup();
    }
    #endregion
    #region Fill Drop Down
    /// <summary>
    /// Fills the main group.
    /// </summary>
    protected void FillMainGroup()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        ds = objMasterManagement.GroupGet();
        ddlMainGroup.Items.Clear();
        ddlMainGroup.DataSource = ds.Tables[0];
        ddlMainGroup.DataTextField = "GroupName";
        ddlMainGroup.DataValueField = "GroupCode";
        ddlMainGroup.DataBind();
    }
    /// <summary>
    /// Fills the sub group.
    /// </summary>
    protected void FillSubGroup()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        if (ddlMainGroup.SelectedIndex >= 0)
        {
            ds = objMasterManagement.SubgroupGet(ddlMainGroup.SelectedValue);
            ddlSubGroup.Items.Clear();
            ddlSubGroup.DataSource = ds.Tables[0];
            ddlSubGroup.DataTextField = "TableName";
            ddlSubGroup.DataValueField = "RowAutoId";
            ddlSubGroup.DataBind();
        }
        FillgvInterfaceMapping();
    }
    #endregion
    #region Function To Fill GridView

    /// <summary>
    /// Fillgvs the interface mapping.
    /// </summary>
    private void FillgvInterfaceMapping()
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DL.ConnectionString objdlMasterManagement = new DL.ConnectionString();
        
        DataSet ds = new DataSet();
        DataTable dtInterfaceMapping = new DataTable();
        ds = objblMasterManagement.InterfaceMappingGet(ddlSubGroup.SelectedItem.Text, BaseDatabaseName);
        dtInterfaceMapping = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtInterfaceMapping.Rows.Count > 0)
        {
            gvInterfaceMapping.DataSource = dtInterfaceMapping;
            gvInterfaceMapping.DataBind();
        }        
    }
    #endregion
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        FillgvInterfaceMapping();
    }
}