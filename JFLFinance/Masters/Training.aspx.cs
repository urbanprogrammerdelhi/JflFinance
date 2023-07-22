// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Training.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Training
/// </summary>
public partial class Masters_Training : BasePage
{
    //ss

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
            javaScript.Append("PageTitle('" + Resources.Resource.TrainingMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvTraining();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }

    }
    /// <summary>
    /// Fillgvs the training.
    /// </summary>
    public void FillgvTraining()
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtTraining = new DataTable();
        ds = objblMasterManagement.TrainingMasterGetAll(BaseCompanyCode);
        dtTraining = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtTraining.Rows.Count > 0)
        {
            gvTraining.DataSource = dtTraining;
            gvTraining.DataBind();
            var lblItmTrainingCode = (LinkButton)gvTraining.Rows[0].FindControl("lblItmTrainingCode");
            if (lblItmTrainingCode != null)
            {
                if (lblItmTrainingCode.Text == "")
                {
                    gvTraining.Rows[0].Visible = false;
                }
            }
        }
        else
        {
            dtTraining.Rows.Add(dtTraining.NewRow());
            gvTraining.DataSource = dtTraining;
            gvTraining.DataBind();
            int TotalColumns = gvTraining.Rows[0].Cells.Count;
            gvTraining.Rows[0].Cells.Clear();
            gvTraining.Rows[0].Cells.Add(new TableCell());
            gvTraining.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvTraining.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="T:System.Web.UI.WebControls.GridViewRowEventArgs">GridViewRowEventArgs</see> that contains the event data.</param>
    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");

        DropDownList ddlTrainingCategory = (DropDownList)e.Row.FindControl("ddlTrainingCategory");
        HiddenField hfTrainingCategory = (HiddenField)e.Row.FindControl("hfTrainingCategory");

        DropDownList ddlTrainingLevel = (DropDownList)e.Row.FindControl("ddlTrainingLevel");
        HiddenField hfTrainingLevel = (HiddenField)e.Row.FindControl("hfTrainingLevel");

        DropDownList ddlRefreshTraining = (DropDownList)e.Row.FindControl("ddlRefreshTraining");
        HiddenField hfRefreshTraining = (HiddenField)e.Row.FindControl("hfRefreshTraining");

        TextBox txtRefTrainAfterNMonths = (TextBox)e.Row.FindControl("txtRefTrainAfterNMonths");
        TextBox txtRefTrainingDays = (TextBox)e.Row.FindControl("txtRefTrainingDays");

        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        if (lblSerialNo != null)
        {
            int serialNo = gvTraining.PageIndex * gvTraining.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvTraining.Columns[3].Visible = false;
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
                TextBox txtTrainingDesc = (TextBox)e.Row.FindControl("txtTrainingDesc");
                if (txtTrainingDesc != null)
                {
                    txtTrainingDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtTrainingDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                CheckBox cbEditIsTrainingFlexi = (CheckBox)e.Row.FindControl("cbEditIsTrainingFlexi");
                TextBox txtEditLeeWayDays = (TextBox)e.Row.FindControl("txtEditLeeWayDays");
                TextBox txtNewLeeWayDays = (TextBox)e.Row.FindControl("txtEditLeeWayDays");
                if (txtNewLeeWayDays != null)
                {
                    txtNewLeeWayDays.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtNewLeeWayDays.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }
                if (cbEditIsTrainingFlexi != null)
                {
                    if (cbEditIsTrainingFlexi.Checked == false)
                    {
                        txtEditLeeWayDays.Enabled = false;
                    }
                }

                if (ddlTrainingCategory != null)
                {
                    ddlTrainingCategory.DataSource = objblMasterManagement.TrainingCategoryGetAll(BaseCompanyCode);
                    ddlTrainingCategory.DataValueField = "ItemCode";
                    ddlTrainingCategory.DataTextField = "ItemDesc";
                    ddlTrainingCategory.SelectedValue = hfTrainingCategory.Value;
                    ddlTrainingCategory.DataBind();
                }

                if (ddlTrainingLevel != null)
                {
                    ddlTrainingLevel.DataSource = objblMasterManagement.TrainingLevelsGetAll(BaseCompanyCode);
                    ddlTrainingLevel.DataValueField = "ItemCode";
                    ddlTrainingLevel.DataTextField = "ItemDesc";
                    ddlTrainingLevel.SelectedValue = hfTrainingLevel.Value;
                    ddlTrainingLevel.DataBind();
                }

                if (ddlRefreshTraining != null)
                {
                    ddlRefreshTraining.DataSource = objblMasterManagement.RefreshTrainingGetAll(BaseCompanyCode);
                    ddlRefreshTraining.DataValueField = "RefreshTrainingValue";
                    ddlRefreshTraining.DataTextField = "RefreshTrainingDesc";
                    if (hfRefreshTraining.Value == "Yes")
                    {
                        ddlRefreshTraining.SelectedValue = "Y";
                    }
                    else
                    {
                        ddlRefreshTraining.SelectedValue = "N";
                    }
                    ddlRefreshTraining.DataBind();
                }


                TextBox txtNoValidMonths = (TextBox)e.Row.FindControl("txtNoValidMonths");

                if (txtNoValidMonths != null)
                {
                    txtNoValidMonths.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtNoValidMonths.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }

                //TextBox txtRefTrainAfterNMonths = (TextBox)e.Row.FindControl("txtRefTrainAfterNMonths");

                if (txtRefTrainAfterNMonths != null)
                {
                    txtRefTrainAfterNMonths.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtRefTrainAfterNMonths.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }

                //TextBox txtRefTrainingDays = (TextBox)e.Row.FindControl("txtRefTrainingDays");

                if (txtRefTrainingDays != null)
                {
                    txtRefTrainingDays.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtRefTrainingDays.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
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

            if (ddlRefreshTraining != null && txtRefTrainAfterNMonths != null
                && txtRefTrainingDays != null && ddlRefreshTraining.SelectedItem.Value.ToString() == "N")
            {
                txtRefTrainAfterNMonths.Enabled = false;
                txtRefTrainingDays.Enabled = false;
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvTraining.ShowFooter = false;
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
                TextBox txtNewTrainingCode = (TextBox)e.Row.FindControl("txtNewTrainingCode");
                if (txtNewTrainingCode != null)
                {
                    txtNewTrainingCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewTrainingCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewTrainingDesc = (TextBox)e.Row.FindControl("txtNewTrainingDesc");
                if (txtNewTrainingDesc != null)
                {
                    txtNewTrainingDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewTrainingDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                TextBox txtNewLeeWayDays = (TextBox)e.Row.FindControl("txtNewLeeWayDays");
                if (txtNewLeeWayDays != null)
                {
                    txtNewLeeWayDays.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtNewLeeWayDays.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }

                DropDownList ddlNewTrainingCategory = (DropDownList)e.Row.FindControl("ddlNewTrainingCategory");

                if (ddlNewTrainingCategory != null)
                {
                    ddlNewTrainingCategory.DataSource = objblMasterManagement.TrainingCategoryGetAll(BaseCompanyCode);
                    ddlNewTrainingCategory.DataValueField = "ItemCode";
                    ddlNewTrainingCategory.DataTextField = "ItemDesc";
                    ddlNewTrainingCategory.DataBind();
                    if (ddlNewTrainingCategory.Text == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoDataToShow;
                        li.Value = "0";
                        ddlNewTrainingCategory.Items.Add(li);
                        //DisableButton();
                    }
                }


                DropDownList ddlNewTrainingLevel = (DropDownList)e.Row.FindControl("ddlNewTrainingLevel");

                if (ddlNewTrainingLevel != null)
                {
                    ddlNewTrainingLevel.DataSource = objblMasterManagement.TrainingLevelsGetAll(BaseCompanyCode);
                    ddlNewTrainingLevel.DataValueField = "ItemCode";
                    ddlNewTrainingLevel.DataTextField = "ItemDesc";
                    ddlNewTrainingLevel.DataBind();
                    if (ddlNewTrainingLevel.Text == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoDataToShow;
                        li.Value = "0";
                        ddlNewTrainingLevel.Items.Add(li);
                        //DisableButton();
                    }
                }

                DropDownList ddlNewRefreshTraining = (DropDownList)e.Row.FindControl("ddlNewRefreshTraining");

                if (ddlNewRefreshTraining != null)
                {
                    ddlNewRefreshTraining.DataSource = objblMasterManagement.RefreshTrainingGetAll(BaseCompanyCode);
                    ddlNewRefreshTraining.DataValueField = "RefreshTrainingValue";
                    ddlNewRefreshTraining.DataTextField = "RefreshTrainingDesc";
                    ddlNewRefreshTraining.DataBind();
                    if (ddlNewRefreshTraining.Text == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoDataToShow;
                        li.Value = "0";
                        ddlNewRefreshTraining.Items.Add(li);
                        //DisableButton();
                    }
                }


                TextBox txtNewNoValidMonths = (TextBox)e.Row.FindControl("txtNewNoValidMonths");
                if (txtNewNoValidMonths != null)
                {
                    txtNewNoValidMonths.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtNewNoValidMonths.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }

                TextBox txtNewRefTrainAfterNMonths = (TextBox)e.Row.FindControl("txtNewRefTrainAfterNMonths");
                if (txtNewRefTrainAfterNMonths != null)
                {
                    txtNewRefTrainAfterNMonths.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtNewRefTrainAfterNMonths.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }

                TextBox txtNewRefTrainingDays = (TextBox)e.Row.FindControl("txtNewRefTrainingDays");
                if (txtNewRefTrainingDays != null)
                {
                    txtNewRefTrainingDays.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtNewRefTrainingDays.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }

                if (ddlNewRefreshTraining.SelectedItem.Value.ToString() == "N")
                {
                    txtNewRefTrainAfterNMonths.Enabled = false;
                    txtNewRefTrainingDays.Enabled = false;
                }

            }
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlNewRefreshTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlNewRefreshTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlNewRefreshTraining = (DropDownList)gvTraining.FooterRow.FindControl("ddlNewRefreshTraining");
        TextBox txtNewRefTrainAfterNMonths = (TextBox)gvTraining.FooterRow.FindControl("txtNewRefTrainAfterNMonths");
        TextBox txtNewRefTrainingDays = (TextBox)gvTraining.FooterRow.FindControl("txtNewRefTrainingDays");

        if (ddlNewRefreshTraining.SelectedItem.Value.ToString() == "N")
        {
            txtNewRefTrainAfterNMonths.Text = "0";
            txtNewRefTrainingDays.Text = "0";
            txtNewRefTrainAfterNMonths.Enabled = false;
            txtNewRefTrainingDays.Enabled = false;
        }
        else
        {
            txtNewRefTrainAfterNMonths.Enabled = true;
            txtNewRefTrainingDays.Enabled = true;
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlRefreshTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlRefreshTraining_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddlRefreshTraining = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlRefreshTraining.NamingContainer;

        TextBox txtRefTrainAfterNMonths = (TextBox)gvTraining.Rows[row.RowIndex].FindControl("txtRefTrainAfterNMonths");
        TextBox txtRefTrainingDays = (TextBox)gvTraining.Rows[row.RowIndex].FindControl("txtRefTrainingDays");

        if (ddlRefreshTraining != null && txtRefTrainAfterNMonths != null
                && txtRefTrainingDays != null && ddlRefreshTraining.SelectedItem.Value.ToString() == "N")
        {
            txtRefTrainAfterNMonths.Text = "0";
            txtRefTrainingDays.Text = "0";
            txtRefTrainAfterNMonths.Enabled = false;
            txtRefTrainingDays.Enabled = false;
        }
        else
        {
            txtRefTrainAfterNMonths.Enabled = true;
            txtRefTrainingDays.Enabled = true;
        }

    }

    /// <summary>
    /// Handles the RowCommand event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        TextBox txtNewTrainingCode = (TextBox)gvTraining.FooterRow.FindControl("txtNewTrainingCode");
        TextBox txtNewTrainingDesc = (TextBox)gvTraining.FooterRow.FindControl("txtNewTrainingDesc");
        DropDownList ddlNewTrainingCategory = (DropDownList)gvTraining.FooterRow.FindControl("ddlNewTrainingCategory");
        DropDownList ddlNewTrainingLevel = (DropDownList)gvTraining.FooterRow.FindControl("ddlNewTrainingLevel");
        DropDownList ddlNewRefreshTraining = (DropDownList)gvTraining.FooterRow.FindControl("ddlNewRefreshTraining");
        TextBox txtNewNoValidMonths = (TextBox)gvTraining.FooterRow.FindControl("txtNewNoValidMonths");

        TextBox txtNewRefTrainAfterNMonths = (TextBox)gvTraining.FooterRow.FindControl("txtNewRefTrainAfterNMonths");
        TextBox txtNewRefTrainingDays = (TextBox)gvTraining.FooterRow.FindControl("txtNewRefTrainingDays");
        CheckBox cbNewIsTrainingFlexi = (CheckBox)gvTraining.FooterRow.FindControl("cbNewIsTrainingFlexi");
        TextBox txtNewLeeWayDays = (TextBox)gvTraining.FooterRow.FindControl("txtNewLeeWayDays");

        if (e.CommandName.Equals("AddNew"))
        {

            if (ddlNewRefreshTraining.SelectedItem.Value.ToString() == "Y")
            {
                if (int.Parse(txtNewRefTrainAfterNMonths.Text) <= 0 || int.Parse(txtNewNoValidMonths.Text) <= 0 || int.Parse(txtNewRefTrainingDays.Text) <= 0)
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotGreaterRefresherPeriod);
                    return;
                }

                if (int.Parse(txtNewRefTrainAfterNMonths.Text) > int.Parse(txtNewNoValidMonths.Text))
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.patterncanbedefinedwhenrefisyes);
                    return;
                }
            }

            if (cbNewIsTrainingFlexi.Checked == true)
            {
                if (txtNewLeeWayDays.Text == null || txtNewLeeWayDays.Text.Trim() == "")
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotZeroOrBlank);
                    return;
                }
                if (int.Parse(txtNewLeeWayDays.Text) <= 0)
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotLessZeroOrEqualZero);
                    return;
                }
                if (int.Parse(txtNewNoValidMonths.Text.Trim()) * 30 < int.Parse(txtNewLeeWayDays.Text))
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotGreaterValidityPeriod);
                    return;
                }
                if (ddlNewRefreshTraining.SelectedItem.Text == "Yes")
                {
                    if (int.Parse(txtNewRefTrainAfterNMonths.Text.Trim()) * 30 < int.Parse(txtNewLeeWayDays.Text))
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.TrainingAfterNMonthsCannotZero);
                        return;
                    }   
                }
            }
            ds = objblMasterManagement.TrainingDetailsAddNew(BaseCompanyCode, txtNewTrainingCode.Text, txtNewTrainingDesc.Text,
                ddlNewTrainingCategory.SelectedItem.Value.ToString(), ddlNewTrainingLevel.SelectedItem.Value.ToString(),
                ddlNewRefreshTraining.SelectedItem.Value.ToString(), txtNewNoValidMonths.Text,
                txtNewRefTrainAfterNMonths.Text, txtNewRefTrainingDays.Text, cbNewIsTrainingFlexi.Checked, txtNewLeeWayDays.Text, BaseUserID);
            if (gvTraining.Rows.Count.Equals(gvTraining.PageSize))
            {
                gvTraining.PageIndex = gvTraining.PageCount + 1;
            }
            gvTraining.EditIndex = -1;
            FillgvTraining();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewTrainingCode.Text = "";
            txtNewTrainingDesc.Text = "";
            txtNewNoValidMonths.Text = "0";
            lblErrorMsg.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTraining.EditIndex = e.NewEditIndex;
        FillgvTraining();
    }
    /// <summary>
    /// Handles the OnCheckedChange event of the cbNewIsTrainingFlexi control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void cbNewIsTrainingFlexi_OnCheckedChange(object sender, EventArgs e)
    {
        CheckBox cbNewIsTrainingFlexi = (CheckBox)gvTraining.FooterRow.FindControl("cbNewIsTrainingFlexi");
        TextBox txtNewLeeWayDays = (TextBox)gvTraining.FooterRow.FindControl("txtNewLeeWayDays");

        if (cbNewIsTrainingFlexi.Checked == true)
        {
            txtNewLeeWayDays.Enabled = true;
        }
        else
        {
            txtNewLeeWayDays.Text = "0";
            txtNewLeeWayDays.Enabled = false;
        }
    }
    /// <summary>
    /// Handles the OnCheckedChange event of the cbEditIsTrainingFlexi control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void cbEditIsTrainingFlexi_OnCheckedChange(object sender, EventArgs e)
    {
        CheckBox objIsTrainingFelxi = (CheckBox)sender;
        GridViewRow row = (GridViewRow)objIsTrainingFelxi.NamingContainer;

        CheckBox cbEditIsTrainingFlexi = (CheckBox)gvTraining.Rows[row.RowIndex].FindControl("cbEditIsTrainingFlexi");
        TextBox txtEditLeeWayDays = (TextBox)gvTraining.Rows[row.RowIndex].FindControl("txtEditLeeWayDays");

        if (cbEditIsTrainingFlexi.Checked == true)
        {
            txtEditLeeWayDays.Enabled = true;
        }
        else
        {
            txtEditLeeWayDays.Text = "0";
            txtEditLeeWayDays.Enabled = false;
        }
    }
    /// <summary>
    /// Handles the Click event of the lblTrainingCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblTrainingCode_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblItmTrainingCode = (LinkButton)gvTraining.Rows[row.RowIndex].FindControl("lblItmTrainingCode");
        PanelTrainingSubstituteMapping.Visible = true;
        hfTrainingCode.Value = lblItmTrainingCode.Text;
        FillgvSubstituteTrainingDetails(hfTrainingCode.Value);
    }

    /// <summary>
    /// Handles the Click event of the lblTrainingDaysPatternItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblTrainingDaysPatternItem_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        Label lblgvItmRefreshTraining = (Label)gvTraining.Rows[row.RowIndex].FindControl("lblgvItmRefreshTraining");
        LinkButton lblItmTrainingCode = (LinkButton)gvTraining.Rows[row.RowIndex].FindControl("lblItmTrainingCode");

        if (lblgvItmRefreshTraining.Text == "Yes")
        {
            Response.Redirect("RefresherTrainingSchedulePatternDefinition.aspx?TrainingCode=" + lblItmTrainingCode.Text.ToString() + "");
        }
        else
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.patterncanbedefinedwhenrefisyes);
        }
    }

    /// <summary>
    /// Fillgvs the substitute training details.
    /// </summary>
    /// <param name="strTrainingCode">The STR training code.</param>
    private void FillgvSubstituteTrainingDetails(string strTrainingCode)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objblMasterManagement.SubstituteTrainingDetailsGetAll(BaseCompanyCode, strTrainingCode);
        dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvSubstituteTrainingDetails.DataSource = dt;
        gvSubstituteTrainingDetails.DataBind();

        if (dtflag == 0)//to fix empty gridview
        {
            gvSubstituteTrainingDetails.Rows[0].Visible = false;
        }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvSubstituteTrainingDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvSubstituteTrainingDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSubstituteTrainingDetails.PageIndex = e.NewPageIndex;
        gvSubstituteTrainingDetails.EditIndex = -1;
        FillgvSubstituteTrainingDetails(hfTrainingCode.Value);
    }

    /// <summary>
    /// Handles the RowCommand event of the gvSubstituteTrainingDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvSubstituteTrainingDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();

        DropDownList ddlNewSubTrainingDesc = (DropDownList)gvSubstituteTrainingDetails.FooterRow.FindControl("ddlNewSubTrainingDesc");

        if (e.CommandName.Equals("AddNewSubstituteTrainingDetails"))
        {
            if (ddlNewSubTrainingDesc.SelectedValue != "")
            {
                ds = objblMasterManagement.SubstituteTrainingInsert(BaseCompanyCode, hfTrainingCode.Value.ToString(), ddlNewSubTrainingDesc.SelectedValue.ToString(), BaseUserID);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (gvSubstituteTrainingDetails.Rows.Count.Equals(gvSubstituteTrainingDetails.PageSize))
                {
                    gvSubstituteTrainingDetails.PageIndex = gvSubstituteTrainingDetails.PageCount + 1;
                }
                gvSubstituteTrainingDetails.EditIndex = -1;
                FillgvSubstituteTrainingDetails(hfTrainingCode.Value);
            }

        }
        if (e.CommandName.Equals("Reset"))
        {
            //txtNewEmployeeNumber.Text = "";
        }
    }


    /// <summary>
    /// Handles the RowDataBound event of the gvSubstituteTrainingDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSubstituteTrainingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");

        DropDownList ddlSubTrainingDesc = (DropDownList)e.Row.FindControl("ddlSubTrainingDesc");
        HiddenField hfSubTrainingCode = (HiddenField)e.Row.FindControl("hfSubTrainingCode");

        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        if (lblSerialNo != null)
        {
            int serialNo = gvSubstituteTrainingDetails.PageIndex * gvSubstituteTrainingDetails.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvSubstituteTrainingDetails.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsModifyAccess == false)
            {
                ImageButton IBEditSubstituteTrainingDetails = (ImageButton)e.Row.FindControl("IBEditSubstituteTrainingDetails");
                if (IBEditSubstituteTrainingDetails != null)
                {
                    IBEditSubstituteTrainingDetails.Visible = false;
                }

            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }


                if (ddlSubTrainingDesc != null)
                {
                    ddlSubTrainingDesc.DataSource = objblMasterManagement.SubstituteTrainingDetailsGet(BaseCompanyCode, hfTrainingCode.Value.ToString());
                    ddlSubTrainingDesc.DataValueField = "TrainingCode";
                    ddlSubTrainingDesc.DataTextField = "TrainingDesc";
                    ddlSubTrainingDesc.SelectedValue = hfSubTrainingCode.Value;
                    ddlSubTrainingDesc.DataBind();
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDeleteSubstituteTrainingDetails = (ImageButton)e.Row.FindControl("ImgbtnDeleteSubstituteTrainingDetails");
                if (ImgbtnDeleteSubstituteTrainingDetails != null)
                {
                    ImgbtnDeleteSubstituteTrainingDetails.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnDeleteSubstituteTrainingDetails = (ImageButton)e.Row.FindControl("ImgbtnDeleteSubstituteTrainingDetails");
                if (ImgbtnDeleteSubstituteTrainingDetails != null)
                {
                    ImgbtnDeleteSubstituteTrainingDetails.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvSubstituteTrainingDetails.ShowFooter = false;
            }
            else
            {
                //Label lblNewCompanyCode = (Label)e.Row.FindControl("lblNewCompanyCode");
                //lblNewCompanyCode.Text = BaseCompanyCode;
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                DropDownList ddlNewSubTrainingDesc = (DropDownList)e.Row.FindControl("ddlNewSubTrainingDesc");

                if (ddlNewSubTrainingDesc != null)
                {
                    ddlNewSubTrainingDesc.DataSource = objblMasterManagement.SubstituteTrainingDetailsGet(BaseCompanyCode, hfTrainingCode.Value.ToString());
                    ddlNewSubTrainingDesc.DataValueField = "TrainingCode";
                    ddlNewSubTrainingDesc.DataTextField = "TrainingDesc";
                    ddlNewSubTrainingDesc.DataBind();
                    if (ddlNewSubTrainingDesc.Text == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoDataToShow;
                        li.Value = "0";
                        ddlNewSubTrainingDesc.Items.Add(li);
                        //DisableButton();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the gvSubstituteTrainingDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvSubstituteTrainingDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSubstituteTrainingDetails.EditIndex = e.NewEditIndex;
        FillgvSubstituteTrainingDetails(hfTrainingCode.Value);
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvSubstituteTrainingDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvSubstituteTrainingDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSubstituteTrainingDetails.EditIndex = -1;
        FillgvSubstituteTrainingDetails(hfTrainingCode.Value);
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvSubstituteTrainingDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvSubstituteTrainingDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        HiddenField hfSubTrainingCodeItm = (HiddenField)gvSubstituteTrainingDetails.Rows[e.RowIndex].FindControl("hfSubTrainingCodeItm");

        ds = objblMasterManagement.SubstituteTrainingDetailsDelete(BaseCompanyCode, hfTrainingCode.Value.ToString(), hfSubTrainingCodeItm.Value.ToString(), BaseUserID);

        gvSubstituteTrainingDetails.EditIndex = -1;

        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        FillgvSubstituteTrainingDetails(hfTrainingCode.Value);

    }

    /// <summary>
    /// Handles the RowUpdating event of the gvSubstituteTrainingDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvSubstituteTrainingDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList ddlSubTrainingDesc = (DropDownList)gvSubstituteTrainingDetails.Rows[e.RowIndex].FindControl("ddlSubTrainingDesc");
        HiddenField hfSubTrainingCode = (HiddenField)gvSubstituteTrainingDetails.Rows[e.RowIndex].FindControl("hfSubTrainingCode");

        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        ds = objblMasterManagement.SubstituteTrainingDetailsUpdate(BaseCompanyCode, hfTrainingCode.Value.ToString(), hfSubTrainingCode.Value.ToString(), ddlSubTrainingDesc.SelectedValue.ToString(), BaseUserID);
        gvSubstituteTrainingDetails.EditIndex = -1;
        FillgvSubstituteTrainingDetails(hfTrainingCode.Value);
        gvSubstituteTrainingDetails.DataBind();

    }




    /// <summary>
    /// Handles the RowUpdating event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblTrainingCode = (Label)gvTraining.Rows[e.RowIndex].FindControl("lblTrainingCode");
        TextBox txtTrainingDesc = (TextBox)gvTraining.Rows[e.RowIndex].FindControl("txtTrainingDesc");

        DropDownList ddlTrainingCategory = (DropDownList)gvTraining.Rows[e.RowIndex].FindControl("ddlTrainingCategory");
        DropDownList ddlTrainingLevel = (DropDownList)gvTraining.Rows[e.RowIndex].FindControl("ddlTrainingLevel");
        DropDownList ddlRefreshTraining = (DropDownList)gvTraining.Rows[e.RowIndex].FindControl("ddlRefreshTraining");

        TextBox txtNoValidMonths = (TextBox)gvTraining.Rows[e.RowIndex].FindControl("txtNoValidMonths");

        TextBox txtRefTrainAfterNMonths = (TextBox)gvTraining.Rows[e.RowIndex].FindControl("txtRefTrainAfterNMonths");
        TextBox txtRefTrainingDays = (TextBox)gvTraining.Rows[e.RowIndex].FindControl("txtRefTrainingDays");

        CheckBox cbEditIsTrainingFlexi = (CheckBox)gvTraining.Rows[e.RowIndex].FindControl("cbEditIsTrainingFlexi");
        TextBox txtEditLeeWayDays = (TextBox)gvTraining.Rows[e.RowIndex].FindControl("txtEditLeeWayDays");

        if (ddlRefreshTraining.SelectedItem.Value.ToString() == "Y")
        {
            if (int.Parse(txtRefTrainAfterNMonths.Text) <= 0 || int.Parse(txtNoValidMonths.Text) <= 0 || int.Parse(txtRefTrainingDays.Text) <= 0)
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotGreaterRefresherPeriod);
                return;
            }

            if (int.Parse(txtRefTrainAfterNMonths.Text) > int.Parse(txtNoValidMonths.Text))
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotGreaterValidityPeriod);
                return;
            }
        }
        if (cbEditIsTrainingFlexi.Checked == true)
        {
            if (txtEditLeeWayDays.Text == null || txtEditLeeWayDays.Text.Trim() == "")
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotZeroOrBlank
);
                return;
            }
            if (int.Parse(txtEditLeeWayDays.Text) <= 0)
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotLessZeroOrEqualZero);
                return;
            }
        }
        if (int.Parse(txtNoValidMonths.Text.Trim()) * 30 < int.Parse(txtEditLeeWayDays.Text))
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.LeewayCannotGreaterValidityPeriod);
            return;
        }
        if (ddlRefreshTraining.SelectedItem.Text == "Yes")
        {
            if (int.Parse(txtRefTrainAfterNMonths.Text.Trim()) * 30 < int.Parse(txtEditLeeWayDays.Text))
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.TrainingAfterNMonthsCannotZero);
                return;
            }
        }
        ds = objblMasterManagement.TrainingUpdate(BaseCompanyCode, lblTrainingCode.Text, txtTrainingDesc.Text, ddlTrainingCategory.SelectedValue.ToString(), ddlTrainingLevel.SelectedValue.ToString(), ddlRefreshTraining.SelectedValue.ToString(), txtNoValidMonths.Text, txtRefTrainAfterNMonths.Text, txtRefTrainingDays.Text, cbEditIsTrainingFlexi.Checked, txtEditLeeWayDays.Text, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        gvTraining.EditIndex = -1;
        FillgvTraining();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTraining.EditIndex = -1;
        FillgvTraining();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objblMasterManagement.TrainingDelete(gvTraining.DataKeys[e.RowIndex].Values["CompanyCode"].ToString(), gvTraining.DataKeys[e.RowIndex].Values["TrainingCode"].ToString());
        FillgvTraining();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTraining.PageIndex = e.NewPageIndex;
        gvTraining.EditIndex = -1;
        FillgvTraining();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvTraining_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string url = "../Masters/MasterExport.aspx?type=MASTER&eType=mstTrainingMaster";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    //protected void EventControl1_ButtonClicked(object sender, EventArgs e)
    //{
    //    EventControl1_OnLoad(sender, e);
    //}

    //protected void EventControl1_OnLoad(object sender, EventArgs e)
    //{
    //    UserControls_Search UserControl = new UserControls_Search();
    //    BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
    //    DataSet ds = new DataSet();
    //    DataTable dtTraining = new DataTable();
    //    ds = objblMasterManagement.blTraining_GetAll(BaseCompanyCode);
    //    //dtTraining = ds.Tables[0];
    //    //if (ds != null && ds.Tables.Count > 0 && dtTraining.Rows.Count > 0)
    //    //{
    //    //    gvTraining.DataSource = dtTraining;
    //    //    gvTraining.DataBind();
    //    //}

    //    DataSet dsSearch = new DataSet();
    //    dsSearch = ds.Clone();
    //    dsSearch.Tables[0].NewRow();
    //    for (int i = 0; i < gvTraining.Columns.Count; i++)
    //    {
    //        if (gvTraining.Columns[i].HeaderText == Resources.Resource.SerialNumber || gvTraining.Columns[i].HeaderText == Resources.Resource.EditColName)
    //        {
    //            continue;
    //        }
    //        else
    //        {
    //            if (gvTraining.Columns[i].Visible)
    //            {
    //                dsSearch.Tables[0].Rows[0][i] = gvTraining.Columns[i].HeaderText.ToString();
    //            }
    //        }
    //    }
    //    UserControl.TempDataSet = dsSearch;
    //    UserControl.TempGridView=gvTraining;
    //}
    /// <summary>
    /// Handles the RowCreated event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        //{
        //    e.Row.TabIndex = -1;
        //    e.Row.Attributes["onclick"] = string.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex);
        //    e.Row.Attributes["onkeydown"] = "javascript:return SelectSibling(event);";
        //    e.Row.Attributes["onselectstart"] = "javascript:return false;";
        //}
    }

}

