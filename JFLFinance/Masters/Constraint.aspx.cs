// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Constraint.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Class Masters_Constraint
/// </summary>
public partial class Masters_Constraint : BasePage 
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
            FillddlConstraintType();
        }
    }

    /// <summary>
    /// Fillddls the type of the constraint.
    /// </summary>
    private void FillddlConstraintType()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMastersManagement.ConstraintTypeGetAll(BaseCompanyCode);
        ddlConstraintType.DataSource = ds.Tables[0];
        ddlConstraintType.DataTextField = "ConstraintTypeDesc";
        ddlConstraintType.DataValueField="ConstraintTypeAutoID";
        ddlConstraintType.DataBind();
        FillgvConstraint();
    }

    /// <summary>
    /// Fillgvs the constraint.
    /// </summary>
    private void FillgvConstraint()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objMastersManagement.ConstraintGetAll(BaseCompanyCode,ddlConstraintType.SelectedValue.ToString(),"");
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvConstraint.DataSource = dt;
        gvConstraint.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvConstraint.Rows[0].Visible = false;
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtConstraintCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtConstraintCode_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement =new BL.MastersManagement();
        TextBox objTextBox = new TextBox();
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtConstraintCode = (TextBox)gvConstraint.FooterRow.FindControl("txtConstraintCode");
        TextBox txtConstraintDesc = (TextBox)gvConstraint.FooterRow.FindControl("txtConstraintDesc");
        ds = objMastersManagement.ConstraintDescriptionGet(txtConstraintCode.Text,BaseCompanyCode,ddlConstraintType.SelectedValue.ToString());
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            txtConstraintDesc.Text = ds.Tables[0].Rows[0]["ConstraintDesc"].ToString();
            txtConstraintDesc.Enabled = false;
        }
        else
        {
            txtConstraintDesc.Enabled = true;
        }

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlConstraintType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlConstraintType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvConstraint();
    }

    #region GridView Commands Events

    /// <summary>
    /// Handles the RowDataBound event of the gvConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvConstraint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvConstraint.PageIndex * gvConstraint.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvConstraint.Columns[3].Visible = false;
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
                TextBox txtConstraintDesc = (TextBox)e.Row.FindControl("txtConstraintDesc");
                if (txtConstraintDesc != null)
                {
                    txtConstraintDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtConstraintDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                TextBox txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                HiddenField HFOperator = (HiddenField)e.Row.FindControl("HFOperator");
                if (HFOperator != null)
                {
                    DropDownList ddlOperator = (DropDownList)e.Row.FindControl("ddlOperator");
                    ddlOperator.SelectedValue = HFOperator.Value;
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
                gvConstraint.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtConstraintCode = (TextBox)e.Row.FindControl("txtConstraintCode");
                if (txtConstraintCode != null)
                {
                    txtConstraintCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtConstraintCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtConstraintDesc = (TextBox)e.Row.FindControl("txtConstraintDesc");
                if (txtConstraintDesc != null)
                {
                    txtConstraintDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtConstraintDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                TextBox txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvConstraint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        // To Insert a New Row
        TextBox txtConstraintCode = (TextBox)gvConstraint.FooterRow.FindControl("txtConstraintCode");
        TextBox txtConstraintDesc = (TextBox)gvConstraint.FooterRow.FindControl("txtConstraintDesc");
        TextBox txtValue = (TextBox)gvConstraint.FooterRow.FindControl("txtValue");
        DropDownList ddlOperator = (DropDownList)gvConstraint.FooterRow.FindControl("ddlOperator");
        if (e.CommandName == "Add")
        {
            if (txtConstraintCode.Text != "")
            {
                double intCheck = 0.0;
                if (ddlOperator.SelectedValue == ">" || ddlOperator.SelectedValue == "<")
                {
                    try
                    {
                        intCheck = double.Parse(txtValue.Text);
                    }
                    catch (Exception ex)
                    {
                        Show("Only Numeric Values Allowed");
                        txtValue.Text = "";
                        return;
                    }
                }
                ds = objMastersManagement.ConstraintInsert(BaseCompanyCode, txtConstraintCode.Text, txtConstraintDesc.Text,txtValue.Text,ddlOperator.SelectedValue.ToString(),ddlConstraintType.SelectedValue.ToString(), BaseUserID.ToString());
                gvConstraint.EditIndex = -1;
                FillgvConstraint();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
            else
            {
                lblErrorMsg.Text = "Invaild Code";
            }
        }
        if (e.CommandName == "Reset")
        {
            txtConstraintCode.Text = "";
            txtConstraintDesc.Text = "";
            txtValue.Text = "";
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the gvConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvConstraint_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvConstraint.EditIndex = e.NewEditIndex;
        FillgvConstraint();
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvConstraint_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvConstraint.EditIndex = -1;
        FillgvConstraint();
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvConstraint_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        TextBox txtConstraintDesc = (TextBox)gvConstraint.Rows[e.RowIndex].FindControl("txtConstraintDesc");
        TextBox txtValue = (TextBox)gvConstraint.Rows[e.RowIndex].FindControl("txtValue");
        DropDownList ddlOperator = (DropDownList)gvConstraint.Rows[e.RowIndex].FindControl("ddlOperator");


        HiddenField HFConstraintAutoID = (HiddenField)gvConstraint.Rows[e.RowIndex].FindControl("HFConstraintAutoID");
        double intCheck = 0.0;
        if (ddlOperator.SelectedValue == ">" || ddlOperator.SelectedValue == "<")
        {
            try
            {
                intCheck = double.Parse(txtValue.Text);
            }
            catch (Exception ex)
            {
                Show("Only Numeric Values Allowed");
                txtValue.Text = "";
                return;
            }
        }
        ds = objMastersManagement.ConstraintUpdate(HFConstraintAutoID.Value, txtConstraintDesc.Text, txtValue.Text, ddlOperator.SelectedValue.ToString(), BaseUserID.ToString());
        gvConstraint.EditIndex = -1;
        FillgvConstraint();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvConstraint_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        HiddenField HFConstraintAutoID = (HiddenField)gvConstraint.Rows[e.RowIndex].FindControl("HFConstraintAutoID");
        ds = objMastersManagement.ConstraintDelete(HFConstraintAutoID.Value);
        FillgvConstraint();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvConstraint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvConstraint.PageIndex = e.NewPageIndex;
        gvConstraint.EditIndex = -1;
        FillgvConstraint();
    }
    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string url = "../Masters/MasterExport.aspx?type=MASTER&eType=mstConstraint";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    #endregion
}
