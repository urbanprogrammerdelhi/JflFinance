// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SOLineSkillSet.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_SOLineSkillSet.
/// </summary>
public partial class Sales_SOLineSkillSet : BasePage// System.Web.UI.Page
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

    #region Page functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"] != null && Request.QueryString["SOAmendNO"] != null && Request.QueryString["SOLineNo"] != null)
                {
                    if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"].ToString() != string.Empty && Request.QueryString["SOAmendNO"].ToString() != string.Empty && Request.QueryString["SOLineNo"].ToString() != string.Empty)
                    {
                        hfLocationAutoId.Value = Request.QueryString["LocationAutoID"].ToString();
                        lblSoNo.Text = Request.QueryString["SoNo"].ToString();
                        lblSOAmendNo.Text = Request.QueryString["SOAmendNO"].ToString();
                        lblSOLineNo.Text = Request.QueryString["SOLineNo"].ToString();
                        lblSoStatus.Text = ResourceValueOfKeyOnlyforStatus_Get(Request.QueryString["SOStatus"].ToString());
                        string strChecked = Request.QueryString["Checked"].ToString();

                        hfIsMAXSOAmendNo.Value = Request.QueryString["IsMAXSOAmendNo"].ToString();
                        HeaderInfo(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text);
                        FillgvLanguage();
                        FillgvQualification();
                        FillgvTraining();
                        FillgvOSkill();
                        btnSave.Visible = false;
                        FillgvSaleConstraint();
                        ////Code Added by Manish  Ticket No : 146362 Modified Date 19-feb-2010 Point N0:2

                        if (bool.Parse(strChecked) == false)
                        {
                            gvLanguage.Enabled = false;
                            gvOSkill.Enabled = false;
                            gvQualification.Enabled = false;
                            gvTraining.Enabled = false;


                        }
                    }
                }
                else
                {
                    Response.Redirect("../UserManagement/Home.aspx");
                }
            }
        }
    }
    #endregion

    #region Common Function

    //Manish 05-07-2012 To display Info in header on page 
    /// <summary>
    /// Headers the information.
    /// </summary>
    /// <param name="strSoNo">The string so no.</param>
    /// <param name="strSoAmendNo">The string so amend no.</param>
    /// <param name="strSoLineNo">The string so line no.</param>
    void HeaderInfo(string strSoNo, string strSoAmendNo, string strSoLineNo)
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = objsales.DeploymentHeaderInfoGet(strSoNo, strSoAmendNo, strSoLineNo);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblClientCodeValue.Text = ds.Tables[0].Rows[0][0].ToString();
            lblClientNameValue.Text = ds.Tables[0].Rows[0][1].ToString();
            lblAsmtIDValue.Text = ds.Tables[0].Rows[0][2].ToString();
            lblAsmtNameValue.Text = ds.Tables[0].Rows[0][3].ToString();
            lblpostIdValue.Text = ds.Tables[0].Rows[0][5].ToString();

        }

    }

    private void FillddlRigidityLevel(DropDownList ddl)
    {
        ListItem li = new ListItem(Resources.Resource.Select, string.Empty);
        ddl.Items.Add(li);
        li = new ListItem(Resources.Resource.Mandatory, "M");
        ddl.Items.Add(li);
        li = new ListItem(Resources.Resource.Recommended, "R");
        ddl.Items.Add(li);
        li = new ListItem(Resources.Resource.Informative, "I");
        ddl.Items.Add(li);

    }
    #endregion

    #region GridView Events for Language
    /// <summary>
    /// Fillgvs the language.
    /// </summary>
    protected void FillgvLanguage()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.LanguageSkillsGet(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
            //  dt.Rows[0]["IsMandatory"] = false;
        }
        //gvLanguage.DataKeyNames = new string[] { "LanguageCode" };
        gvLanguage.DataSource = dt;
        gvLanguage.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvLanguage.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlLanguageCode = (DropDownList)gvLanguage.FooterRow.FindControl("ddlLanguageCode");
        DropDownList ddlLanguageRigidityLevel = (DropDownList)gvLanguage.FooterRow.FindControl("ddlLanguageRigidityLevel");
        if (e.CommandName.Equals("Add"))
        {
                if (ddlLanguageRigidityLevel != null && ddlLanguageCode != null && ddlLanguageCode.SelectedValue.ToString() != string.Empty)
                {
                    ds = objSales.LanguageSkillsAdd(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlLanguageCode.SelectedItem.Value.ToString(), ddlLanguageRigidityLevel.SelectedItem.Value, BaseUserID);
                    if (gvLanguage.Rows.Count.Equals(gvLanguage.PageSize))
                    {
                        gvLanguage.PageIndex = gvLanguage.PageCount + 1;
                    }
                    gvLanguage.EditIndex = -1;
                    FillgvLanguage();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
        }
        if (e.CommandName.Equals("Reset"))
        {
            lblErrorMsg.Text = string.Empty;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsModifyAccess == false && IsDeleteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvLanguage.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvLanguage.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            var HFClientConstraint = (HiddenField)e.Row.FindControl("HFClientConstraint");
            if (HFClientConstraint != null)
            {
                if (HFClientConstraint.Value == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else if (HFClientConstraint.Value == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.Aqua;

                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Empty;

                }
            }
            Label lblLanguageRigiditylevel = (Label)e.Row.FindControl("lblLanguageRigiditylevel");
            if (lblLanguageRigiditylevel != null)
            {
                if (lblLanguageRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblLanguageRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblLanguageRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblLanguageRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblLanguageRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblLanguageRigiditylevel.Text = Resources.Resource.Informative;
                }
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
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlLanguageCode = (DropDownList)e.Row.FindControl("ddlLanguageCode");
            if (ddlLanguageCode != null)
            {
                ds = objMastersManagement.LanguageMasterGetAll();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlLanguageCode.DataSource = ds.Tables[0];
                    ddlLanguageCode.DataValueField = "LanguageCode";
                    ddlLanguageCode.DataTextField = "LanguageDesc";
                    ddlLanguageCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = string.Empty;
                    ddlLanguageCode.Items.Add(li);
                }
            }
            HiddenField hfLanguageCode = (HiddenField)e.Row.FindControl("hfLanguageCode");
            if (hfLanguageCode != null && ddlLanguageCode != null)
            {
                ddlLanguageCode.SelectedValue = hfLanguageCode.Value;
                ddlLanguageCode.Enabled = false;
            }

            HiddenField HFLanguageRigidityLevel = (HiddenField)e.Row.FindControl("HFLanguageRigidityLevel");
            DropDownList ddlLanguageRigidityLevel = (DropDownList)e.Row.FindControl("ddlLanguageRigidityLevel");
            if (HFLanguageRigidityLevel != null && ddlLanguageRigidityLevel != null && HFLanguageRigidityLevel.Value != string.Empty)
            {
                FillddlRigidityLevel(ddlLanguageRigidityLevel);
                ddlLanguageRigidityLevel.SelectedValue = HFLanguageRigidityLevel.Value;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlLanguageCode = (DropDownList)e.Row.FindControl("ddlLanguageCode");
            if (ddlLanguageCode != null)
            {
                ds = objMastersManagement.LanguageMasterGetAll();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlLanguageCode.DataSource = ds.Tables[0];
                    ddlLanguageCode.DataValueField = "LanguageCode";
                    ddlLanguageCode.DataTextField = "LanguageDesc";
                    ddlLanguageCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = string.Empty;
                    ddlLanguageCode.Items.Add(li);
                }
            }
            DropDownList ddlLanguageRigidityLevel = (DropDownList)e.Row.FindControl("ddlLanguageRigidityLevel");
            if (ddlLanguageRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlLanguageRigidityLevel);
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlLanguageCode = (DropDownList)gvLanguage.Rows[e.RowIndex].FindControl("ddlLanguageCode");
        //CheckBox cbIsMandatoryLanguage = (CheckBox)gvLanguage.Rows[e.RowIndex].FindControl("cbIsMandatoryLanguage");
        DropDownList ddlLanguageRigidityLevel = (DropDownList)gvLanguage.Rows[e.RowIndex].FindControl("ddlLanguageRigidityLevel");
        if (ddlLanguageCode.SelectedValue.ToString() != string.Empty)
        {
            ds = objSales.LanguageSkillsUpdate(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlLanguageCode.SelectedItem.Value.ToString(), ddlLanguageRigidityLevel.SelectedItem.Value, BaseUserID);

            gvLanguage.EditIndex = -1;
            FillgvLanguage();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblgvLanguageCode = (Label)gvLanguage.Rows[e.RowIndex].FindControl("lblgvLanguageCode");
        HiddenField HFLanguageCode = (HiddenField)gvLanguage.Rows[e.RowIndex].FindControl("HFLanguageCode");
        ds = objSales.LanguageSkillsDelete(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFLanguageCode.Value);
        FillgvLanguage();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvLanguage.EditIndex = e.NewEditIndex;
        FillgvLanguage();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvLanguage.EditIndex = -1;
        FillgvLanguage();
    }
    #endregion

    

    #region GridView Events for Qualification
    /// <summary>
    /// Fillgvs the qualification.
    /// </summary>
    protected void FillgvQualification()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.QualificationSkillsGet( lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
            // dt.Rows[0]["IsMandatory"] = false;
        }
        //gvQualification.DataKeyNames = new string[] { "QualificationCode" };
        gvQualification.DataSource = dt;
        gvQualification.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvQualification.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlQualificationCode = (DropDownList)gvQualification.FooterRow.FindControl("ddlQualificationCode");
        DropDownList ddlQualificationRigidityLevel = (DropDownList)gvQualification.FooterRow.FindControl("ddlQualificationRigidityLevel");
        if (e.CommandName.Equals("Add"))
        {
            if (ddlQualificationRigidityLevel != null && ddlQualificationCode != null && ddlQualificationCode.SelectedValue.ToString() != string.Empty)
                {
                    ds = objSales.QualificationSkillsAdd(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlQualificationCode.SelectedItem.Value.ToString(), ddlQualificationRigidityLevel.SelectedItem.Value, BaseUserID);
                    if (gvQualification.Rows.Count.Equals(gvQualification.PageSize))
                    {
                        gvQualification.PageIndex = gvQualification.PageCount + 1;
                    }
                    gvQualification.EditIndex = -1;
                    FillgvQualification();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
        }
        if (e.CommandName.Equals("Reset"))
        {
            lblErrorMsg.Text = string.Empty;
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsModifyAccess == false && IsDeleteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvQualification.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvQualification.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var HFClientConstraint = (HiddenField)e.Row.FindControl("HFClientConstraint");
            if (HFClientConstraint != null)
            {
                if (HFClientConstraint.Value == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else if (HFClientConstraint.Value == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.Aqua;

                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Empty;

                }
            }

            //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            // e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            Label lblQualificationRigiditylevel = (Label)e.Row.FindControl("lblQualificationRigiditylevel");
            if (lblQualificationRigiditylevel != null)
            {
                if (lblQualificationRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblQualificationRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblQualificationRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblQualificationRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblQualificationRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblQualificationRigiditylevel.Text = Resources.Resource.Informative;
                }
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
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlQualificationCode = (DropDownList)e.Row.FindControl("ddlQualificationCode");
            if (ddlQualificationCode != null)
            {
                ds = objMastersManagement.QualificationMasterGetAll();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlQualificationCode.DataSource = ds.Tables[0];
                    ddlQualificationCode.DataValueField = "QualificationCode";
                    ddlQualificationCode.DataTextField = "QualificationDesc";
                    ddlQualificationCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = string.Empty;
                    ddlQualificationCode.Items.Add(li);
                }
            }
            HiddenField hfQualificationCode = (HiddenField)e.Row.FindControl("hfQualificationCode");
            if (hfQualificationCode != null && ddlQualificationCode != null)
            {
                ddlQualificationCode.SelectedValue = hfQualificationCode.Value;
                ddlQualificationCode.Enabled = false;
            }

            HiddenField HFQualificationRigidityLevel = (HiddenField)e.Row.FindControl("HFQualificationRigidityLevel");
            DropDownList ddlQualificationRigidityLevel = (DropDownList)e.Row.FindControl("ddlQualificationRigidityLevel");
            if (HFQualificationRigidityLevel != null && ddlQualificationRigidityLevel != null && HFQualificationRigidityLevel.Value != string.Empty)
            {
                FillddlRigidityLevel(ddlQualificationRigidityLevel);
                ddlQualificationRigidityLevel.SelectedValue = HFQualificationRigidityLevel.Value;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlQualificationCode = (DropDownList)e.Row.FindControl("ddlQualificationCode");
            if (ddlQualificationCode != null)
            {
                ds = objMastersManagement.QualificationMasterGetAll();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlQualificationCode.DataSource = ds.Tables[0];
                    ddlQualificationCode.DataValueField = "QualificationCode";
                    ddlQualificationCode.DataTextField = "QualificationDesc";
                    ddlQualificationCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = string.Empty;
                    ddlQualificationCode.Items.Add(li);
                }
            }
            DropDownList ddlQualificationRigidityLevel = (DropDownList)e.Row.FindControl("ddlQualificationRigidityLevel");
            if (ddlQualificationRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlQualificationRigidityLevel);
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlQualificationCode = (DropDownList)gvQualification.Rows[e.RowIndex].FindControl("ddlQualificationCode");
        DropDownList ddlQualificationRigidityLevel = (DropDownList)gvQualification.Rows[e.RowIndex].FindControl("ddlQualificationRigidityLevel");
        if (ddlQualificationCode.SelectedValue.ToString() != string.Empty)
        {
            ds = objSales.QualificationSkillsUpdate(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlQualificationCode.SelectedItem.Value.ToString(), ddlQualificationRigidityLevel.SelectedItem.Value, BaseUserID);

            gvQualification.EditIndex = -1;
            FillgvQualification();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblgvQualificationCode = (Label)gvQualification.Rows[e.RowIndex].FindControl("lblgvQualificationCode");
        HiddenField HFQualificationCode = (HiddenField)gvQualification.Rows[e.RowIndex].FindControl("HFQualificationCode");
        ds = objSales.QualificationSkillsDelete(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFQualificationCode.Value);
        FillgvQualification();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
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
    /// Handles the RowCancelingEdit event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQualification.EditIndex = -1;
        FillgvQualification();
    }
    #endregion

    #region GridView Events for Training
    /// <summary>
    /// Fillgvs the training.
    /// </summary>
    protected void FillgvTraining()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.TrainingSkillsGet(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
            //dt.Rows[0]["IsMandatory"] = false;
        }
        // gvTraining.DataKeyNames = new string[] { "TrainingCode" };
        gvTraining.DataSource = dt;
        gvTraining.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvTraining.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlTrainingCode = (DropDownList)gvTraining.FooterRow.FindControl("ddlTrainingCode");
        DropDownList ddlTrainingRigidityLevel = (DropDownList)gvTraining.FooterRow.FindControl("ddlTrainingRigidityLevel");
        if (e.CommandName.Equals("Add"))
        {
                if (ddlTrainingRigidityLevel != null && ddlTrainingCode.SelectedValue.ToString() != string.Empty)
                {
                    ds = objSales.TrainingSkillsAdd(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlTrainingCode.SelectedItem.Value.ToString(), ddlTrainingRigidityLevel.SelectedItem.Value, BaseUserID);
                    if (gvTraining.Rows.Count.Equals(gvTraining.PageSize))
                    {
                        gvTraining.PageIndex = gvTraining.PageCount + 1;
                    }
                    gvTraining.EditIndex = -1;
                    FillgvTraining();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
        }

        if (e.CommandName.Equals("Reset"))
        {
            lblErrorMsg.Text = string.Empty;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsModifyAccess == false && IsDeleteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvTraining.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvTraining.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var HFClientConstraint = (HiddenField)e.Row.FindControl("HFClientConstraint");
            if (HFClientConstraint != null)
            {
                if (HFClientConstraint.Value == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else if (HFClientConstraint.Value == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.Aqua;

                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Empty;

                }
            }

            //e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            Label lblRigiditylevel = (Label)e.Row.FindControl("lblRigiditylevel");
            if (lblRigiditylevel != null)
            {
                if (lblRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Informative;
                }
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
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlTrainingCode = (DropDownList)e.Row.FindControl("ddlTrainingCode");
            if (ddlTrainingCode != null)
            {
                ds = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlTrainingCode.DataSource = ds.Tables[0];
                    ddlTrainingCode.DataValueField = "TrainingCode";
                    ddlTrainingCode.DataTextField = "TrainingDesc";
                    ddlTrainingCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = string.Empty;
                    ddlTrainingCode.Items.Add(li);
                }
            }
            HiddenField hfTrainingCode = (HiddenField)e.Row.FindControl("hfTrainingCode");
            if (hfTrainingCode != null && ddlTrainingCode != null)
            {
                ddlTrainingCode.SelectedValue = hfTrainingCode.Value;
                ddlTrainingCode.Enabled = false;
            }

            HiddenField HFTrainingRigidityLevel = (HiddenField)e.Row.FindControl("HFTrainingRigidityLevel");
            DropDownList ddlTrainingRigidityLevel = (DropDownList)e.Row.FindControl("ddlTrainingRigidityLevel");
            if (ddlTrainingRigidityLevel != null && HFTrainingRigidityLevel != null && HFTrainingRigidityLevel.Value != string.Empty)
            {
                FillddlRigidityLevel(ddlTrainingRigidityLevel);
                ddlTrainingRigidityLevel.SelectedValue = HFTrainingRigidityLevel.Value;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DropDownList ddlTrainingCode = (DropDownList)e.Row.FindControl("ddlTrainingCode");
            if (ddlTrainingCode != null)
            {
                ds = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlTrainingCode.DataSource = ds.Tables[0];
                    ddlTrainingCode.DataValueField = "TrainingCode";
                    ddlTrainingCode.DataTextField = "TrainingDesc";
                    ddlTrainingCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = string.Empty;
                    ddlTrainingCode.Items.Add(li);
                }
            }
            DropDownList ddlTrainingRigidityLevel = (DropDownList)e.Row.FindControl("ddlTrainingRigidityLevel");
            if (ddlTrainingRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlTrainingRigidityLevel);
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlTrainingCode = (DropDownList)gvTraining.Rows[e.RowIndex].FindControl("ddlTrainingCode");
        DropDownList ddlTrainingRigidityLevel = (DropDownList)gvTraining.Rows[e.RowIndex].FindControl("ddlTrainingRigidityLevel");
        if (ddlTrainingCode.SelectedValue.ToString() != string.Empty)
        {
            ds = objSales.TrainingSkillsUpdate(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlTrainingCode.SelectedItem.Value.ToString(), ddlTrainingRigidityLevel.SelectedItem.Value, BaseUserID);
            gvTraining.EditIndex = -1;
            FillgvTraining();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblgvTrainingCode = (Label)gvTraining.Rows[e.RowIndex].FindControl("lblgvTrainingCode");
        HiddenField HFTrainingCode = (HiddenField)gvTraining.Rows[e.RowIndex].FindControl("HFTrainingCode");
        ds = objSales.TrainingSkillsDelete(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFTrainingCode.Value);
        FillgvTraining();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
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
    /// Handles the RowCancelingEdit event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTraining.EditIndex = -1;
        FillgvTraining();
    }
    #endregion

    #region GridView Events for OSkill
    /// <summary>
    /// Fillgvs the o skill.
    /// </summary>
    protected void FillgvOSkill()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.OtherSkillsGet(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text);
        if (ds != null && ds.Tables.Count > 0)
        {
            dt = ds.Tables[0];

            //to fix empety gridview
            if (dt.Rows.Count == 0)
            {
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
                //dt.Rows[0]["IsMandatory"] = false;
            }
            //gvOSkill.DataKeyNames = new string[] { "OtherSkillCode" };
            gvOSkill.DataSource = dt;
            gvOSkill.DataBind();

            if (dtflag == 0)//to fix empety gridview
            {
                gvOSkill.Rows[0].Visible = false;
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlOSkillCode = (DropDownList)gvOSkill.FooterRow.FindControl("ddlOSkillCode");
        DropDownList ddlSkillRigidityLevel = (DropDownList)gvOSkill.FooterRow.FindControl("ddlSkillRigidityLevel");
        if (e.CommandName.Equals("Add"))
        {
            if (ddlSkillRigidityLevel != null && ddlOSkillCode != null && ddlOSkillCode.SelectedValue.ToString() != string.Empty)
                {
                    ds = objSales.OtherSkillsAdd(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlOSkillCode.SelectedItem.Value.ToString(), ddlSkillRigidityLevel.SelectedItem.Value, BaseUserID);
                    if (gvOSkill.Rows.Count.Equals(gvOSkill.PageSize))
                    {
                        gvOSkill.PageIndex = gvOSkill.PageCount + 1;
                    }
                    gvOSkill.EditIndex = -1;
                    FillgvOSkill();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
        }
        if (e.CommandName.Equals("Reset"))
        {
            lblErrorMsg.Text = string.Empty;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsModifyAccess == false && IsDeleteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvOSkill.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvOSkill.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var HFClientConstraint = (HiddenField)e.Row.FindControl("HFClientConstraint");
            if (HFClientConstraint != null)
            {
                if (HFClientConstraint.Value == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else if (HFClientConstraint.Value == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.Aqua;

                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Empty;

                }
            }

            // e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            //e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            Label lblRigiditylevel = (Label)e.Row.FindControl("lblRigiditylevel");
            if (lblRigiditylevel != null)
            {
                if (lblRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Informative;
                }
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
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

            DataSet ds = new DataSet();
            BL.HRManagement objHrManagement = new BL.HRManagement();
            DropDownList ddlOSkillCode = (DropDownList)e.Row.FindControl("ddlOSkillCode");
            if (ddlOSkillCode != null)
            {
                // ds = objHrManagement.blQuickCodeEmployeeSkillTypes_Get(BaseCompanyCode);
                ds = objHrManagement.EmployeeIdTypeGet();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlOSkillCode.DataSource = ds.Tables[0];
                    ddlOSkillCode.DataValueField = "IDTypeCode";
                    ddlOSkillCode.DataTextField = "IDTypeDesc";
                    ddlOSkillCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = string.Empty;
                    ddlOSkillCode.Items.Add(li);
                }
            }
            HiddenField hfOSkillCode = (HiddenField)e.Row.FindControl("hfOSkillCode");
            if (hfOSkillCode != null && ddlOSkillCode != null)
            {
                ddlOSkillCode.SelectedValue = hfOSkillCode.Value;
                ddlOSkillCode.Enabled = false;
            }

            HiddenField HFSkillRigidityLevel = (HiddenField)e.Row.FindControl("HFSkillRigidityLevel");
            DropDownList ddlSkillRigidityLevel = (DropDownList)e.Row.FindControl("ddlSkillRigidityLevel");
            if (ddlSkillRigidityLevel != null && HFSkillRigidityLevel != null && HFSkillRigidityLevel.Value != string.Empty)
            {
                FillddlRigidityLevel(ddlSkillRigidityLevel);
                ddlSkillRigidityLevel.SelectedValue = HFSkillRigidityLevel.Value;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.HRManagement objHrManagement = new BL.HRManagement();
            DropDownList ddlOSkillCode = (DropDownList)e.Row.FindControl("ddlOSkillCode");
            if (ddlOSkillCode != null)
            {
                // ds = objHrManagement.blQuickCodeEmployeeSkillTypes_Get(BaseCompanyCode);
                ds = objHrManagement.EmployeeIdTypeGet();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlOSkillCode.DataSource = ds.Tables[0];
                    ddlOSkillCode.DataValueField = "IDTypeCode";
                    ddlOSkillCode.DataTextField = "IDTypeDesc";
                    ddlOSkillCode.DataBind();
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = string.Empty;
                    ddlOSkillCode.Items.Add(li);
                }
            }
            DropDownList ddlSkillRigidityLevel = (DropDownList)e.Row.FindControl("ddlSkillRigidityLevel");
            if (ddlSkillRigidityLevel != null)
            {
                FillddlRigidityLevel(ddlSkillRigidityLevel);
            }
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DropDownList ddlOSkillCode = (DropDownList)gvOSkill.Rows[e.RowIndex].FindControl("ddlOSkillCode");
        RadioButtonList ddlSkillRigidityLevel = (RadioButtonList)gvOSkill.Rows[e.RowIndex].FindControl("ddlSkillRigidityLevel");
        if (ddlSkillRigidityLevel != null && ddlOSkillCode != null && ddlOSkillCode.SelectedValue.ToString() != string.Empty)
        {
            ds = objSales.OtherSkillsUpdate(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, ddlOSkillCode.SelectedItem.Value.ToString(), ddlSkillRigidityLevel.SelectedItem.Value, BaseUserID);
            gvOSkill.EditIndex = -1;
            FillgvOSkill();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        Label lblgvOSkillCode = (Label)gvOSkill.Rows[e.RowIndex].FindControl("lblgvOSkillCode");
        HiddenField HFSkillCode = (HiddenField)gvOSkill.Rows[e.RowIndex].FindControl("HFSkillCode");

        ds = objSales.OtherSkillsDelete(lblSoNo.Text, lblSOAmendNo.Text, lblSOLineNo.Text, HFSkillCode.Value);
        FillgvOSkill();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOSkill.EditIndex = e.NewEditIndex;
        FillgvOSkill();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOSkill.EditIndex = -1;
        FillgvOSkill();
    }
    #endregion

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
    }


    #region GridView Commands Events

    /// <summary>
    /// Handles the RowDataBound event of the gvSaleConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSaleConstraint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((IsModifyAccess == false && IsDeleteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvSaleConstraint.Columns[0].Visible = false;
        }
        if ((IsWriteAccess == false) || (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString())))))
        {
            gvSaleConstraint.ShowFooter = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var HFClientConstraint = (HiddenField)e.Row.FindControl("HFClientConstraint");
            if (HFClientConstraint != null)
            {
                if (HFClientConstraint.Value == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else if (HFClientConstraint.Value == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.Aqua;

                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Empty;

                }
            }

            //  e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            // e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
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
                DropDownList ddlConstraintType = (DropDownList)e.Row.FindControl("ddlConstraintType");
                if (ddlConstraintType != null)
                {
                    ddlConstraintType.Attributes["readonly"] = "readonly";
                    DropDownList ddlConstraintDesc = (DropDownList)e.Row.FindControl("ddlConstraintDesc");
                    if (ddlConstraintDesc != null)
                    {
                        HiddenField HFConstraintTypeAutoID = (HiddenField)e.Row.FindControl("HFConstraintTypeAutoID");
                        HiddenField HFConstraintCode = (HiddenField)e.Row.FindControl("HFConstraintCode");
                        HiddenField HFConstraintAutoID = (HiddenField)e.Row.FindControl("HFConstraintAutoID");
                        // ddlConstraintType.SelectedValue = HFConstraintTypeAutoID.Value;
                        DropDownList ddlValue = (DropDownList)e.Row.FindControl("ddlValue");
                        FillddlConstraintType(ddlConstraintType, ddlConstraintDesc, HFConstraintTypeAutoID, HFConstraintCode, txtValue, ddlValue);
                        ddlValue.SelectedValue = HFConstraintAutoID.Value;
                    }


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
            HiddenField HFConstraintRigidityLevel = (HiddenField)e.Row.FindControl("HFConstraintRigidityLevel");
            Label lblOperator = (Label)e.Row.FindControl("lblOperator");
            if (lblOperator != null)
            {

                if (lblOperator.Text.Trim().ToLower() == "Greater Than".Trim().ToLower())
                {
                    lblOperator.Text = Resources.Resource.GreaterThan;
                }
                if (lblOperator.Text.Trim().ToLower() == "less Than".Trim().ToLower())
                {
                    lblOperator.Text = Resources.Resource.LessThan;
                }
                if (lblOperator.Text.Trim().ToLower() == "Equal To".Trim().ToLower())
                {
                    lblOperator.Text = Resources.Resource.EqualTo;
                }
                if (lblOperator.Text.Trim().ToLower() == "like".Trim().ToLower())
                {
                    lblOperator.Text = Resources.Resource.Like;
                }
            }
            Label lblRigiditylevel = (Label)e.Row.FindControl("lblRigiditylevel");
            if (lblRigiditylevel != null)
            {
                if (lblRigiditylevel.Text.Trim().ToLower() == "Mandatory".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Mandatory;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Recommended".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Recommended;
                }
                if (lblRigiditylevel.Text.Trim().ToLower() == "Informative".Trim().ToLower())
                {
                    lblRigiditylevel.Text = Resources.Resource.Informative;
                }
            }
            DropDownList ddlConstraintRigidityLevel = (DropDownList)e.Row.FindControl("ddlConstraintRigidityLevel");
            if (ddlConstraintRigidityLevel != null && HFConstraintRigidityLevel != null && HFConstraintRigidityLevel.Value != string.Empty)
            {
                FillddlRigidityLevel(ddlConstraintRigidityLevel);
                ddlConstraintRigidityLevel.SelectedValue = HFConstraintRigidityLevel.Value;
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvSaleConstraint.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }


                TextBox txtValue = (TextBox)e.Row.FindControl("txtValue");
                if (txtValue != null)
                {
                    txtValue.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtValue.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                DropDownList ddlConstraintType = (DropDownList)e.Row.FindControl("ddlConstraintType");
                if (ddlConstraintType != null)
                {
                    ddlConstraintType.Attributes["readonly"] = "readonly";
                    DropDownList ddlConstraintDesc = (DropDownList)e.Row.FindControl("ddlConstraintDesc");
                    if (ddlConstraintDesc != null)
                    {
                        HiddenField HFConstraintTypeAutoID = (HiddenField)e.Row.FindControl("HFConstraintTypeAutoID");
                        HiddenField HFConstraintCode = (HiddenField)e.Row.FindControl("HFConstraintCode");
                        // ddlConstraintType.SelectedValue = HFConstraintTypeAutoID.Value;
                        DropDownList ddlValue = (DropDownList)e.Row.FindControl("ddlValue");
                        FillddlConstraintType(ddlConstraintType, ddlConstraintDesc, HFConstraintTypeAutoID, HFConstraintCode, txtValue, ddlValue);
                    }


                }
                DropDownList ddlConstraintRigidityLevel = (DropDownList)e.Row.FindControl("ddlConstraintRigidityLevel");
                if (ddlConstraintRigidityLevel != null)
                {
                    FillddlRigidityLevel(ddlConstraintRigidityLevel);
                }

            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvSaleConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvSaleConstraint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        // To Insert a New Row
        DropDownList ddlConstraintType = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlConstraintType");
        DropDownList ddlConstraintDesc = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlConstraintDesc");
        DropDownList ddlValue = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlValue");
        TextBox txtValue = (TextBox)gvSaleConstraint.FooterRow.FindControl("txtValue");
        DropDownList ddlOperator = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlOperator");
        DropDownList ddlConstraintRigidityLevel = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlConstraintRigidityLevel");
        if (e.CommandName == "Add")
        {
            if (txtValue.Style["display"] == "block")
            {
                if (txtValue.Text != string.Empty)
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
                            txtValue.Text = string.Empty;
                            return;
                        }
                    }


                    ds = objSales.SaleConstraintInsert(BaseLocationAutoID, BaseCompanyCode, ddlConstraintType.SelectedValue.ToString(), ddlConstraintDesc.SelectedValue.ToString(), txtValue.Text, ddlOperator.SelectedValue.ToString(), ddlConstraintRigidityLevel.SelectedItem.Value, BaseUserID.ToString(), lblSoNo.Text, lblSOLineNo.Text, lblSOAmendNo.Text);
                    gvSaleConstraint.EditIndex = -1;
                    FillgvSaleConstraint();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    { DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                }
                else
                {
                    lblConstraintErrorMsg.Text = "Value field cannot be left blank ! ";
                }
            }
            else
            {
                ds = objSales.SaleConstraintInsert(BaseLocationAutoID, BaseCompanyCode, ddlConstraintType.SelectedValue.ToString(), ddlValue.SelectedValue.ToString(), ddlValue.SelectedItem.Text, ddlOperator.SelectedValue.ToString(), ddlConstraintRigidityLevel.SelectedItem.Value, BaseUserID.ToString(), lblSoNo.Text, lblSOLineNo.Text, lblSOAmendNo.Text);
                    gvSaleConstraint.EditIndex = -1;
                    FillgvSaleConstraint();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    { DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }

        }
        if (e.CommandName == "Reset")
        {

            // RBLRigidityLevel.SelectedValue = string.Empty;
            txtValue.Text = string.Empty;
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the gvSaleConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvSaleConstraint_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSaleConstraint.EditIndex = e.NewEditIndex;
        FillgvSaleConstraint();
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvSaleConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvSaleConstraint_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSaleConstraint.EditIndex = -1;
        FillgvSaleConstraint();
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvSaleConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvSaleConstraint_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();

        DropDownList ddlConstraintType = (DropDownList)gvSaleConstraint.Rows[e.RowIndex].FindControl("ddlConstraintType");
        DropDownList ddlConstraintDesc = (DropDownList)gvSaleConstraint.Rows[e.RowIndex].FindControl("ddlConstraintDesc");
        DropDownList ddlValue = (DropDownList)gvSaleConstraint.Rows[e.RowIndex].FindControl("ddlValue");
        TextBox txtValue = (TextBox)gvSaleConstraint.Rows[e.RowIndex].FindControl("txtValue");
        DropDownList ddlOperator = (DropDownList)gvSaleConstraint.Rows[e.RowIndex].FindControl("ddlOperator");
        DropDownList ddlConstraintRigidityLevel = (DropDownList)gvSaleConstraint.Rows[e.RowIndex].FindControl("ddlConstraintRigidityLevel");


        HiddenField HFSaleConstraintAutoID = (HiddenField)gvSaleConstraint.Rows[e.RowIndex].FindControl("HFSaleConstraintAutoID");
        if (txtValue.Style["display"] == "block")
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
                    txtValue.Text = string.Empty;
                    return;
                }
            }
            ds = objSales.SaleConstraintUpdate(HFSaleConstraintAutoID.Value, ddlConstraintType.SelectedValue.ToString(), ddlConstraintDesc.SelectedValue.ToString(), txtValue.Text, ddlOperator.SelectedValue.ToString(), ddlConstraintRigidityLevel.SelectedItem.Value, BaseUserID.ToString());
        }
        else
        {
            ds = objSales.SaleConstraintUpdate(HFSaleConstraintAutoID.Value, ddlConstraintType.SelectedValue.ToString(), ddlValue.SelectedValue.ToString(), ddlValue.SelectedItem.Text, ddlOperator.SelectedValue.ToString(), ddlConstraintRigidityLevel.SelectedItem.Value, BaseUserID.ToString());
        }
        gvSaleConstraint.EditIndex = -1;
        FillgvSaleConstraint();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvSaleConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvSaleConstraint_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        HiddenField HFSaleConstraintAutoID = (HiddenField)gvSaleConstraint.Rows[e.RowIndex].FindControl("HFSaleConstraintAutoID");
        ds = objSales.SaleConstraintDelete(HFSaleConstraintAutoID.Value);
        FillgvSaleConstraint();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblConstraintErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvSaleConstraint control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvSaleConstraint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSaleConstraint.PageIndex = e.NewPageIndex;
        gvSaleConstraint.EditIndex = -1;
        FillgvSaleConstraint();
    }
    #endregion

    /// <summary>
    /// Fillgvs the sale constraint.
    /// </summary>
    private void FillgvSaleConstraint()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.SaleConstraintGet(BaseCompanyCode, lblSoNo.Text, lblSOLineNo.Text, lblSOAmendNo.Text);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvSaleConstraint.DataSource = dt;
        gvSaleConstraint.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvSaleConstraint.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Fillddls the type of the constraint.
    /// </summary>
    /// <param name="ddlConstraintType">Type of the DDL constraint.</param>
    /// <param name="ddlConstraintDesc">The DDL constraint desc.</param>
    /// <param name="HFConstraintTypeAutoID">The hf constraint type automatic identifier.</param>
    /// <param name="HFConstraintCode">The hf constraint code.</param>
    /// <param name="txtValue">The text value.</param>
    /// <param name="ddlValue">The DDL value.</param>
    private void FillddlConstraintType(DropDownList ddlConstraintType, DropDownList ddlConstraintDesc, HiddenField HFConstraintTypeAutoID, HiddenField HFConstraintCode, TextBox txtValue, DropDownList ddlValue)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMastersManagement.ConstraintTypeGetAll(BaseCompanyCode);
        ddlConstraintType.DataSource = ds.Tables[0];
        ddlConstraintType.DataTextField = "ConstraintTypeDesc";
        ddlConstraintType.DataValueField = "ConstraintTypeAutoID";
        ddlConstraintType.DataBind();
        try
        {
            ddlConstraintType.SelectedValue = HFConstraintTypeAutoID.Value;
        }
        catch (Exception ex) { }
        FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, HFConstraintCode, txtValue, ddlValue);
    }
    /// <summary>
    /// Fillddls the constraint desc.
    /// </summary>
    /// <param name="ddlConstraintType">Type of the DDL constraint.</param>
    /// <param name="ddlConstraintDesc">The DDL constraint desc.</param>
    /// <param name="HFConstraintCode">The hf constraint code.</param>
    /// <param name="txtValue">The text value.</param>
    /// <param name="ddlValue">The DDL value.</param>
    private void FillddlConstraintDesc(DropDownList ddlConstraintType, DropDownList ddlConstraintDesc, HiddenField HFConstraintCode, TextBox txtValue, DropDownList ddlValue)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMastersManagement.ConstraintGetAll(BaseCompanyCode, ddlConstraintType.SelectedValue.ToString(), "Client");
        ddlConstraintDesc.DataSource = ds.Tables[0];
        ddlConstraintDesc.DataTextField = "ConstraintDesc";
        ddlConstraintDesc.DataValueField = "ConstraintCode";
        ddlConstraintDesc.DataBind();
        try
        {
            ddlConstraintDesc.SelectedValue = HFConstraintCode.Value;
        }
        catch (Exception ex) { }
        GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);

        // EventArgs e = new EventArgs();
        //ddlConstraintDesc_SelectedIndexChanged(ddlConstraintDesc, e);

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlConstraintType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlConstraintType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList objDropDownList = (DropDownList)sender;
        GridViewRow row = (GridViewRow)objDropDownList.NamingContainer;
        if (row.RowIndex < 0)
        {
            DropDownList ddlConstraintType = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlConstraintType");
            DropDownList ddlConstraintDesc = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlConstraintDesc");
            TextBox txtValue = (TextBox)gvSaleConstraint.FooterRow.FindControl("txtValue");
            DropDownList ddlValue = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlValue");
            HiddenField HFConstraintCode = (HiddenField)gvSaleConstraint.FooterRow.FindControl("HFConstraintCode");
            FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, HFConstraintCode, txtValue, ddlValue);
        }
        else
        {
            DropDownList ddlConstraintType = (DropDownList)gvSaleConstraint.Rows[row.RowIndex].FindControl("ddlConstraintType");
            DropDownList ddlConstraintDesc = (DropDownList)gvSaleConstraint.Rows[row.RowIndex].FindControl("ddlConstraintDesc");
            TextBox txtValue = (TextBox)gvSaleConstraint.Rows[row.RowIndex].FindControl("txtValue");
            DropDownList ddlValue = (DropDownList)gvSaleConstraint.Rows[row.RowIndex].FindControl("ddlValue");
            HiddenField HFConstraintCode = (HiddenField)gvSaleConstraint.Rows[row.RowIndex].FindControl("HFConstraintCode");
            FillddlConstraintDesc(ddlConstraintType, ddlConstraintDesc, HFConstraintCode, txtValue, ddlValue);
        }

        ddlConstraintDesc_SelectedIndexChanged(sender, e);
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlConstraintDesc control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlConstraintDesc_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList objDropDownList = (DropDownList)sender;
        GridViewRow row = (GridViewRow)objDropDownList.NamingContainer;
        if (row.RowIndex < 0)
        {
            DropDownList ddlConstraintDesc = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlConstraintDesc");
            DropDownList ddlConstraintType = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlConstraintType");
            DropDownList ddlValue = (DropDownList)gvSaleConstraint.FooterRow.FindControl("ddlValue");
            Label lblDefaultValue = (Label)gvSaleConstraint.FooterRow.FindControl("lblDefaultValue");
            TextBox txtValue = (TextBox)gvSaleConstraint.FooterRow.FindControl("txtValue");

            GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);

        }
        else
        {
            DropDownList ddlConstraintDesc = (DropDownList)gvSaleConstraint.Rows[row.RowIndex].FindControl("ddlConstraintDesc");
            DropDownList ddlConstraintType = (DropDownList)gvSaleConstraint.Rows[row.RowIndex].FindControl("ddlConstraintType");
            DropDownList ddlValue = (DropDownList)gvSaleConstraint.Rows[row.RowIndex].FindControl("ddlValue");
            Label lblDefaultValue = (Label)gvSaleConstraint.Rows[row.RowIndex].FindControl("lblDefaultValue");
            TextBox txtValue = (TextBox)gvSaleConstraint.Rows[row.RowIndex].FindControl("txtValue");
            HiddenField HFConstraintAutoID = (HiddenField)gvSaleConstraint.Rows[row.RowIndex].FindControl("HFConstraintAutoID");
            GetValueBasedOnConstraintAutoID(ddlConstraintDesc, ddlConstraintType, ddlValue, txtValue);
            // ddlValue.SelectedValue = HFConstraintAutoID.Value;
        }

    }

    /// <summary>
    /// Gets the value based on constraint automatic identifier.
    /// </summary>
    /// <param name="ddlConstraintDesc">The DDL constraint desc.</param>
    /// <param name="ddlConstraintType">Type of the DDL constraint.</param>
    /// <param name="ddlValue">The DDL value.</param>
    /// <param name="txtValue">The text value.</param>
    private void GetValueBasedOnConstraintAutoID(DropDownList ddlConstraintDesc, DropDownList ddlConstraintType, DropDownList ddlValue, TextBox txtValue)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMastersManagement.ConstraintValueGet(ddlConstraintDesc.SelectedValue.ToString(), ddlConstraintType.SelectedValue.ToString());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //lblDefaultValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();
            // txtValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();

            if (ds.Tables[0].Rows.Count > 1)
            {
                ddlValue.Style["display"] = "block";
                txtValue.Style["display"] = "none";
                ddlValue.DataSource = ds.Tables[0];
                ddlValue.DataTextField = "Value";
                ddlValue.DataValueField = "ConstraintAutoID";
                ddlValue.DataBind();
            }
            else
            {
                txtValue.Style["display"] = "block";
                ddlValue.Style["display"] = "none";
            }
        }
    }


    /// <summary>
    /// Handles the PageIndexChanging event of the gvOSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvOSkill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOSkill.PageIndex = e.NewPageIndex;
        gvOSkill.EditIndex = -1;
        FillgvOSkill();
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
    /// Handles the PageIndexChanging event of the gvLanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvLanguage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLanguage.PageIndex = e.NewPageIndex;
        gvLanguage.EditIndex = -1;
        FillgvLanguage();
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQualification.PageIndex = e.NewPageIndex;
        gvQualification.EditIndex = -1;
        FillgvQualification();
    }

}
