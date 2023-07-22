// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="SecurityDesignReview.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Class OperationManagement_SecurityDesignReview.
/// </summary>
public partial class OperationManagement_SecurityDesignReview : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// The dt observation detail
    /// </summary>
    static DataTable dtObservationDetail = new DataTable();
    /// <summary>
    /// The status
    /// </summary>
    static int Status;
    /// <summary>
    /// The count
    /// </summary>
    static int count;
    /// <summary>
    /// The index
    /// </summary>
    static int index;
    //Added Code for Upload Document by  on 25-Jun-2013
    /// <summary>
    /// The dt upload
    /// </summary>
    static DataTable dtUpload = new DataTable();
    /// <summary>
    /// The default date
    /// </summary>
    string defaultDate = "1/1/1900 12:00:00 AM";
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
            javaScript.Append("PageTitle('" + Resources.Resource.SecurityDesignReview + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                Status = 1;
                count = 1;
                dtObservationDetail.Clear();
                btnSave.Visible = true;
                FillClientId();             //Added by  on 30-May-2013
                btnSave.Enabled = false;            //Added by  on 2-Jun-2013
                FillgvObservation();
                FillddlDesignType();
                FillddlReasonForReview();
                if (dtObservationDetail.Columns.Contains("Observation") == false)
                {
                    MakeTempObservationDetail();
                }
                else
                {
                    dtObservationDetail.Clear();
                }
                IMGDesignChangeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=SecurityCCH&ControlId=" + txtDesignChangeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                //imgAssignSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtAssignNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                //IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtConductedBy.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtConductedBy.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,help=no')");

                //Added Code for Upload Document by  on 25-Jun-2013
                CreateUploadTable();
                dvFileUploadGrid.Visible = false;
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                //End
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

    }
    /// <summary>
    /// Handles the DataBound event of the gvObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvObservation_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvObservation.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvObservation.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvObservation.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvObservation.PageCount.ToString();
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvObservation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvObservation.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvObservation.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvObservation.PageIndex = CurrentIndex;
            }
            index = -1;
        }
        else if (index == 0)
        {
            gvObservation.PageIndex = CurrentIndex + 1;
            index = -1;
        }
        else
        {
            gvObservation.PageIndex = e.NewPageIndex;
        }
        gvObservation.EditIndex = -1;
        // To Fill gridview based on the status
        if (Status == 1)
        {
            gvObservation.DataSource = dtObservationDetail;
            gvObservation.DataBind();
        }
        else if (Status == 0)
        {
            FillgvObservationAfterSave();
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvObservation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (Status == 1)
        {
            gvObservation.EditIndex = -1;
            gvObservation.DataSource = dtObservationDetail;
            gvObservation.DataBind();
        }
        else if (Status == 0)
        {
            gvObservation.EditIndex = -1;
            FillgvObservationAfterSave();
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvObservation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int flag = 1;
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtNewObservation = (TextBox)gvObservation.FooterRow.FindControl("txtNewObservation");
        TextBox txtNewRecommendation = (TextBox)gvObservation.FooterRow.FindControl("txtNewRecommendation");
        DropDownList ddlNewSensitivity = (DropDownList)gvObservation.FooterRow.FindControl("ddlNewSensitivity");
        TextBox txtNewImplementationDate = (TextBox)gvObservation.FooterRow.FindControl("txtNewImplementationDate");
        TextBox txtNewReasonForPending = (TextBox)gvObservation.FooterRow.FindControl("txtNewReasonForPending");
        ImageButton lbADD = (ImageButton)gvObservation.FooterRow.FindControl("lbADD");
        if (Status == 1)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                if (ddlNewSensitivity.Text == "")
                {
                    lbADD.Visible = false;
                }
                else
                {
                    lbADD.Visible = true;
                }
                DataRow dr = dtObservationDetail.NewRow();
                dr[0] = 0;
                dr[1] = txtNewObservation.Text;
                dr[2] = txtNewRecommendation.Text;
                dr[3] = ddlNewSensitivity.SelectedItem.Text.ToString();
                dr[4] = txtNewImplementationDate.Text;
                dr[5] = txtNewReasonForPending.Text;
                dr[6] = ddlNewSensitivity.SelectedValue.ToString();
                dtObservationDetail.Rows.Add(dr);
                gvObservation.EditIndex = -1;
                gvObservation.DataSource = dtObservationDetail;
                gvObservation.DataBind();
            }

        }
        else if (Status == 0)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                gvObservation.EditIndex = -1;
                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                DataSet ds = new DataSet();
                if (txtNewImplementationDate.Text != "")
                {
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtNewImplementationDate.Text) == false)
                    {
                        lblErrorMsg.Text = "Date Not in Correct Format";
                        txtNewImplementationDate.BackColor = System.Drawing.Color.Aqua;
                       ToolkitScriptManager2.SetFocus(txtNewImplementationDate);
                        return;
                    }
                    else
                    {
                        txtNewImplementationDate.BackColor = System.Drawing.Color.Empty;
                    }
                }
                if (txtNewImplementationDate.Text != "" && txtNewReasonForPending.Text != "")
                {
                    lblErrorMsg.Text = "Both Implementation On and Reason for pending Should not be entered";
                    txtNewReasonForPending.BackColor = System.Drawing.Color.Aqua;
                    txtNewImplementationDate.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
                else
                {
                    txtNewReasonForPending.BackColor = System.Drawing.Color.Empty;
                    txtNewImplementationDate.BackColor = System.Drawing.Color.Empty;
                }
                ds = objOperationManagement.SecurityDesignReviewObservationDetailInsert(txtDesignChangeNumber.Text, txtNewObservation.Text, txtNewRecommendation.Text, ddlNewSensitivity.SelectedValue.ToString(), txtNewImplementationDate.Text, txtNewReasonForPending.Text, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    gvObservation.EditIndex = -1;
                    FillgvObservationAfterSave();
                }
                else
                {
                    lblErrorMsg.Text = "Record Fail to Insert";
                }
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewObservation.Text = "";
            txtNewRecommendation.Text = "";
            txtNewImplementationDate.Text = "";
            txtNewReasonForPending.Text = "";
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvObservation.PageIndex = 0;
                break;
            case "Prev":
                index = 1;
                break;
            case "Next":
                index = 0;
                break;
            case "Last":
                gvObservation.PageIndex = gvObservation.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvObservation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvObservation.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            if (IsDeleteAccess != true)
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Visible = true;
                }
            }
            if (IsModifyAccess != true)
            {
                ImageButton IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (IBEdit != null)
                {
                    IBEdit.Visible = true;
                }
            }
            DropDownList ddlSensitivity = (DropDownList)e.Row.FindControl("ddlSensitivity");
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            if (ddlSensitivity != null)
            {
                ddlSensitivity.DataSource = objOperationManagement.SecurityDesignReviewSensitivityGet(BaseCompanyCode);
                ddlSensitivity.DataTextField = "ItemDesc";
                ddlSensitivity.DataValueField = "ItemCode";
                ddlSensitivity.DataBind();
                if (ddlSensitivity.Text == "")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "0";
                    ddlSensitivity.Items.Add(li);
                    DisableButtons();
                }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvObservation.ShowFooter = false;
            }
            DropDownList ddlNewSensitivity = (DropDownList)e.Row.FindControl("ddlNewSensitivity");
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            if (ddlNewSensitivity != null)
            {
                ddlNewSensitivity.DataSource = objOperationManagement.SecurityDesignReviewSensitivityGet(BaseCompanyCode);
                ddlNewSensitivity.DataTextField = "ItemDesc";
                ddlNewSensitivity.DataValueField = "ItemCode";
                ddlNewSensitivity.DataBind();
                if (ddlNewSensitivity.Text == "")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "0";
                    ddlNewSensitivity.Items.Add(li);
                    DisableButtons();
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowDeleting event of the gvObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvObservation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblRowID = (Label)gvObservation.Rows[e.RowIndex].FindControl("lblRowID");
        if (Status == 1)
        {
            dtObservationDetail.Rows.RemoveAt(e.RowIndex);
            gvObservation.DataSource = dtObservationDetail;
            gvObservation.DataBind();
            if (dtObservationDetail.Rows.Count == 0)
            {
                FillgvObservation();
            }
        }
        else if (Status == 0)
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            ds = objOperationManagement.SecurityDesignReviewObservationDetailDelete(lblRowID.Text);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvObservationAfterSave();
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvObservation_RowEditing(object sender, GridViewEditEventArgs e)
    {

        if (Status == 1)
        {
            gvObservation.EditIndex = e.NewEditIndex;
            gvObservation.DataSource = dtObservationDetail;
            gvObservation.DataBind();
        }
        else if (Status == 0)
        {
            gvObservation.EditIndex = e.NewEditIndex;
            FillgvObservationAfterSave();
        }
        TextBox txtObservation = (TextBox)gvObservation.Rows[e.NewEditIndex].FindControl("txtObservation");
        TextBox txtRecommendation = (TextBox)gvObservation.Rows[e.NewEditIndex].FindControl("txtRecommendation");
        DropDownList ddlSensitivity = (DropDownList)gvObservation.Rows[e.NewEditIndex].FindControl("ddlSensitivity");
        if (lblDesignChangeStatus.Text == Resources.Resource.ObservationAuthorized || lblDesignChangeStatus.Text == Resources.Resource.ActionAuthorized || lblDesignChangeStatus.Text == Resources.Resource.Amend)
        {
            txtObservation.Enabled = false;
            txtRecommendation.Enabled = false;
            ddlSensitivity.Enabled = false;
        }
        else if (lblDesignChangeStatus.Text == Resources.Resource.Fresh)
        {
            txtObservation.Enabled = true;
            txtRecommendation.Enabled = true;
            ddlSensitivity.Enabled = true;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvObservation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int flag = 1;
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtObservation = (TextBox)gvObservation.Rows[e.RowIndex].FindControl("txtObservation");
        TextBox txtRecommendation = (TextBox)gvObservation.Rows[e.RowIndex].FindControl("txtRecommendation");
        DropDownList ddlSensitivity = (DropDownList)gvObservation.Rows[e.RowIndex].FindControl("ddlSensitivity");
        TextBox txtImplementationDate = (TextBox)gvObservation.Rows[e.RowIndex].FindControl("txtImplementationDate");
        TextBox txtReasonForPending = (TextBox)gvObservation.Rows[e.RowIndex].FindControl("txtReasonForPending");
        ImageButton lbADD = (ImageButton)gvObservation.Rows[e.RowIndex].FindControl("ImgbtnUpdate");
        Label lblRowIDEdit = (Label)gvObservation.Rows[e.RowIndex].FindControl("lblRowIDEdit");
        if (Status == 1)
        {
            dtObservationDetail.Rows[e.RowIndex][0] = 0;
            dtObservationDetail.Rows[e.RowIndex][1] = txtObservation.Text;
            dtObservationDetail.Rows[e.RowIndex][2] = txtRecommendation.Text;
            dtObservationDetail.Rows[e.RowIndex][3] = ddlSensitivity.SelectedItem.Text.ToString();
            dtObservationDetail.Rows[e.RowIndex][4] = txtImplementationDate.Text;
            dtObservationDetail.Rows[e.RowIndex][5] = txtReasonForPending.Text;
            dtObservationDetail.Rows[e.RowIndex][6] = ddlSensitivity.SelectedValue.ToString();
            gvObservation.EditIndex = -1;
            gvObservation.DataSource = dtObservationDetail;
            gvObservation.DataBind();
        }
        else if (Status == 0)
        {

            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            if (txtImplementationDate.Text != "")
            {
                BL.Common objCommon = new BL.Common();
                if (objCommon.IsValidDate(txtImplementationDate.Text) == false)
                {
                    lblErrorMsg.Text = "Date not in Correct Format";
                    txtImplementationDate.BackColor = System.Drawing.Color.Aqua;
                    ToolkitScriptManager2.SetFocus(txtImplementationDate);
                    return;
                }
                else
                {
                    txtImplementationDate.BackColor = System.Drawing.Color.Empty;
                }
            }
            if (txtImplementationDate.Text != "" && txtReasonForPending.Text != "")
            {
                lblErrorMsg.Text = "Both Implementation Date and reason for pending Should not be entered";
                txtImplementationDate.Text = "";
                txtReasonForPending.Text = "";
                //flag = 0;
                return;
            }
            else if (txtImplementationDate.Text != "" || txtReasonForPending.Text != "")
            {
                if (txtImplementationDate.Text != "")
                {
                    DataSet dsAsmtDtl = new DataSet();
                    dsAsmtDtl = objOperationManagement.AsmtIncidentDetailGet(ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, BaseLocationAutoID);
                    if (dsAsmtDtl != null && dsAsmtDtl.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dsAsmtDtl.Tables[0].Rows[0]["TerminationDate"].ToString()))
                        {
                            if (DateTime.Parse(txtImplementationDate.Text) > DateTime.Parse(txtDate.Text) && DateTime.Parse(txtImplementationDate.Text) < Convert.ToDateTime(dsAsmtDtl.Tables[0].Rows[0]["TerminationDate"]))
                            {
                                flag = 1;
                            }
                            else
                            {
                                //flag = 0;
                                lblErrorMsg.Text = "Implementation Date Should be between Design change date and Asmt Termination Date";
                                return;
                            }
                        }
                        else
                        {
                            if (DateTime.Parse(txtImplementationDate.Text) > DateTime.Parse(txtDate.Text))
                            {
                                flag = 1;
                            }
                            else
                            {
                                //flag = 0;
                                lblErrorMsg.Text = "Implementation Date Should be Greater Then Design change date.";
                                return;
                            }
                        }
                    }
                }
                else
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                ds = objOperationManagement.SecurityDesignReviewObservationDetailUpdate(txtObservation.Text, txtRecommendation.Text, ddlSensitivity.SelectedValue.ToString(), txtImplementationDate.Text, txtReasonForPending.Text, BaseUserID, lblRowIDEdit.Text);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    gvObservation.EditIndex = -1;
                    FillgvObservationAfterSave();
                }
            }
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvObservation.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvObservation.PageIndex = ddlPages.SelectedIndex;
        if (index == 1)
        {
            gvObservation.DataSource = dtObservationDetail;
            gvObservation.DataBind();
        }
        else
        {
            FillgvObservationAfterSave();
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtImplementationDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtImplementationDate_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        BL.Common objCommon = new BL.Common();
        TextBox txtImplementationDate = (TextBox)gvObservation.Rows[row.RowIndex].FindControl("txtImplementationDate");
        TextBox txtReasonForPending = (TextBox)gvObservation.Rows[row.RowIndex].FindControl("txtReasonForPending");
        ImageButton ImgbtnUpdate = (ImageButton)gvObservation.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        ConvertStringToDateFormat(txtImplementationDate,lblErrorMsg );
        if (objCommon.IsValidDate(txtImplementationDate.Text) == true)
        {
            ImgbtnUpdate.Visible = true;
            if (txtImplementationDate.Text != "")
            {
                txtReasonForPending.Enabled = false;
            }
            else
            {
                txtReasonForPending.Enabled = true;
                ToolkitScriptManager2.SetFocus(txtReasonForPending);
            }
        }
        else
        {
            ToolkitScriptManager2.SetFocus(txtImplementationDate);
            txtImplementationDate.BackColor = System.Drawing.Color.Aqua;
            ImgbtnUpdate.Visible = false;
        }

    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewImplementationDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewImplementationDate_TextChanged(object sender, EventArgs e)
    {
        TextBox txtNewImplementationDate = (TextBox)gvObservation.FooterRow.FindControl("txtNewImplementationDate");
        TextBox txtNewReasonForPending = (TextBox)gvObservation.FooterRow.FindControl("txtNewReasonForPending");
        ConvertStringToDateFormat(txtNewImplementationDate,lblErrorMsg );
        if (txtNewImplementationDate.Text != "")
        {
            txtNewReasonForPending.Enabled = false;
        }
        else
        {
            txtNewReasonForPending.Enabled = true;
            // ToolkitScriptManager2.SetFocus(txtNewReasonForPending);
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtConductedBy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtConductedBy_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtConductedBy.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                EnableButtons();
                txtConductedBy.BackColor = System.Drawing.Color.Empty;
                txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                txtEmployeeDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
                DisableButtons();
                txtConductedBy.BackColor = System.Drawing.Color.Aqua;
                txtEmployeeName.Text = "";
                txtEmployeeDesignation.Text = "";
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
            DisableButtons();
            txtConductedBy.BackColor = System.Drawing.Color.Aqua;
            txtEmployeeName.Text = "";
            txtEmployeeDesignation.Text = "";
        }
        ToolkitScriptManager2.SetFocus(ddlReasonForReview);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtDate,lblErrorMsg );
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager2.SetFocus(txtDateOfReport);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDateOfReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDateOfReport_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtDateOfReport,lblErrorMsg );
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager2.SetFocus(ddlDesignType);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtReasonForPending control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtReasonForPending_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtImplementationDate = (TextBox)gvObservation.Rows[row.RowIndex].FindControl("txtImplementationDate");
        TextBox txtReasonForPending = (TextBox)gvObservation.Rows[row.RowIndex].FindControl("txtReasonForPending");
        ImageButton ImgbtnUpdate = (ImageButton)gvObservation.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        if (txtReasonForPending.Text != "")
        {
            txtImplementationDate.Enabled = false;
            // ToolkitScriptManager2.SetFocus(ImgbtnUpdate);
        }
        else
        {
            txtImplementationDate.Enabled = true;
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewReasonForPending control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewReasonForPending_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtNewImplementationDate = (TextBox)gvObservation.FooterRow.FindControl("txtNewImplementationDate");
        TextBox txtNewReasonForPending = (TextBox)gvObservation.FooterRow.FindControl("txtNewReasonForPending");
        ImageButton lbADD = (ImageButton)gvObservation.FooterRow.FindControl("lbADD");
        if (txtNewReasonForPending.Text != "")
        {
            txtNewImplementationDate.Enabled = false;
            //ToolkitScriptManager2.SetFocus(lbADD);
        }
        else
        {
            txtNewImplementationDate.Enabled = true;
        }
    }
    /// <summary>
    /// Fills the asmt detail.
    /// </summary>
    private void FillAsmtDetail()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ds = objOperationManagement.AsmtIncidentDetailGet(ddlClientId.SelectedItem.Value,ddlAsmtId.SelectedItem.Value, BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                //txtAssignNo.BackColor = System.Drawing.Color.Empty;
                EnableButtons();
                txtBranchID.Text = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                txtBranchIDDesc.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
                //txtCustomerID.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                //txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                //txtAddressID.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                //txtAddressDesc.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
                hfAsmtStartDate.Value = ds.Tables[0].Rows[0]["AsmtStartDate"].ToString();
                btnSave.Enabled = true;            //Added by  on 2-Jun-2013

                //Added Code for Upload Document by  on 25-Jun-2013
                btnUpload.Enabled = true;
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                DisableButtons();
                //ToolkitScriptManager2.SetFocus(txtAssignNo);
                ClearAsmtDetails();
                //txtAssignNo.BackColor = System.Drawing.Color.Aqua;
                btnSave.Enabled = false;            //Added by  on 2-Jun-2013

                //Added Code for Upload Document by  on 14-Jun-2013
                btnUpload.Enabled = false;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            dtObservationDetail.Clear();
            DisableButtons();
            //ToolkitScriptManager2.SetFocus(txtAssignNo);
            ClearAsmtDetails();
            //txtAssignNo.BackColor = System.Drawing.Color.Aqua;
            btnSave.Enabled = false;            //Added by  on 2-Jun-2013

            //Added Code for Upload Document by  on 14-Jun-2013
            btnUpload.Enabled = false;
        }
    }
    /// <summary>
    /// Clears the asmt details.
    /// </summary>
    private void ClearAsmtDetails()
    {
        txtBranchID.Text = "";
        txtBranchIDDesc.Text = "";
        //txtCustomerID.Text = "";
        //txtCustomerDesc.Text = "";
        //txtAddressID.Text = "";
        //txtAddressDesc.Text = "";
        txtAreaID.Text = "";
        txtAreaDesc.Text = "";
    }

    /// <summary>
    /// Checks the dates.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckDates()
    {
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        int flag = 0;
        if (txtDateOfReport.Text != "")
        {
            if (DateTime.Parse(txtDateOfReport.Text) < DateTime.Parse(hfAsmtStartDate.Value) || DateTime.Parse(txtDateOfReport.Text) > System.DateTime.Now)
            {
                lblErrorMsg.Text = "Date of report should be between Assignment Start Date and Current Date";
                ToolkitScriptManager2.SetFocus(txtDateOfReport);
                 flag = 0;
            }
            else
            {
                flag = 1;
            }
        }
        if (txtDate.Text != "")
        {

            if (DateTime.Parse(txtDate.Text) > DateTime.Now || DateTime.Parse(txtDate.Text) < DateTime.Parse(hfAsmtStartDate.Value))
            {

                lblErrorMsg.Text = "Date Should be greater than Current Date/Assignment start Date";
                ToolkitScriptManager2.SetFocus(txtDate);
                flag = 0;
            }
            else
            {
                flag = 1;

            }
        }
        if (txtDate.Text != "" && txtDateOfReport.Text != "")
        {
            if (DateTime.Parse(txtDate.Text) > DateTime.Parse(txtDateOfReport.Text))
            {
                lblErrorMsg.Text = "Date of Report Should be greater than or equal to Date.";
                ToolkitScriptManager2.SetFocus(txtDate);
                flag = 0;
            }
            else
            {
                flag = 1;
            }
        }
        if (flag == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        gvObservation.EditIndex = -1;
        #region Commented Code
        //int flag = 1;
        //if (txtDateOfReport.Text != "")
        //{
        //    if (DateTime.Parse(txtDateOfReport.Text) < DateTime.Parse(hfAsmtStartDate.Value) || DateTime.Parse(txtDateOfReport.Text) > System.DateTime.Now)
        //    {
        //        lblErrorMsg.Text = "Date of report should be between Assignment Start Date and Current Date";
        //        // flag = 0;
        //        return;
        //    }
        //    else
        //    {
        //        flag = 1;
        //    }
        //}
        //if (txtDate.Text != "")
        //{

        //    if (DateTime.Parse(txtDate.Text) > DateTime.Now || DateTime.Parse(txtDate.Text) < DateTime.Parse(hfAsmtStartDate.Value))
        //    {

        //        lblErrorMsg.Text = "Date Should be greater than Current Date/Assignment start Date";
        //        return;
        //    }
        //    else
        //    {
        //        flag = 1;

        //    }
        //}
        #endregion
        if (dtObservationDetail.Rows.Count == 0)
        {
            lblErrorMsg.Text = "observation Details cannot be left blank";//Resources.Resource.NightCheckDetailsCannotbeleftblank;
            //flag = 0;
            return;
        }
        if (CheckDates())
        {
            //Modify Code For Document Upload by  on 25-Jun-2013 
            ds = objOperationManagement.SecurityDesignReviewInsert(DateTime.Parse(txtDate.Text), Resources.Resource.Fresh, DateTime.Parse(txtDateOfReport.Text), ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, ddlDesignType.SelectedValue.ToString(), txtConductedBy.Text, ddlReasonForReview.SelectedValue.ToString(), dtObservationDetail, BaseLocationAutoID, BaseUserID, dtUpload);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                Status = 0;
                txtDesignChangeNumber.Text = ds.Tables[0].Rows[0]["DesignChangeNo"].ToString();
                lblDesignChangeStatus.Text = Resources.Resource.Fresh;
                HideButton();
                HideButtonBasedOnStatus();
                FillgvObservationAfterSave();
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        dtObservationDetail.Clear();
        gvObservation.EditIndex = -1;
        Status = 1;
        ClearFields();
        txtDesignChangeNumber.Text = "";
        lblDesignChangeStatus.Text = "";
        gvObservation.Columns[0].Visible = true;
        HideButton();
        EnableFields();
        btnSave.Visible = true;
        btnAddNew.Visible = true;
        FillgvObservation();
        ClearAsmtDetails();
        txtEmployeeDesignation.Text = "";
        txtEmployeeName.Text = "";
        txtConductedBy.Text = "";
        //txtAssignNo.Text = "";
        hfAsmtStartDate.Value = "";
        gvObservation.Columns[5].Visible = false;
        gvObservation.Columns[6].Visible = false;
        //Added by  on 30-May-2013
        ddlAsmtId.Items.Clear();
        FillClientId();
        ddlClientId.Enabled = true;

        //Added code for Upload Document by  on 25-Jun-2013
        FillgvEmployeeDocDownload();
    }
    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        gvObservation.EditIndex = -1;
        FillgvObservationAfterSave();
        EnableFields();
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        Status = 0;
        ds = objOperationManagement.SecurityDesignReviewAmend(txtDesignChangeNumber.Text, strStatusAmend, BaseLocationAutoID, BaseUserID);
        lblDesignChangeStatus.Text = Resources.Resource.Amend;
       
        gvObservation.Columns[0].Visible = true;
        gvObservation.FooterRow.Visible = true;
        HideButton();
        HideButtonBasedOnStatus();

        //Added for Upload Document by  on 25-Jun-2013
        if (lblDesignChangeStatus.Text == Resources.Resource.ActionAuthorized)
        {
            gvEmployeeDocument.Columns[4].Visible = false;
        }
        else
        {
            gvEmployeeDocument.Columns[4].Visible = true;
        }
        //End
        //Added By  on 23-July-2013
        btnUpload.Enabled = true;
        //End
    }
    /// <summary>
    /// Handles the Click event of the btnObservationAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnObservationAuthorize_Click(object sender, EventArgs e)
    {
        gvObservation.EditIndex = -1;
        FillgvObservationAfterSave();
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.SecurityDesignReviewObservationAuthorize(DateTime.Parse(txtDate.Text), DateTime.Parse(txtDateOfReport.Text), txtConductedBy.Text, ddlReasonForReview.SelectedValue.ToString(), txtDesignChangeNumber.Text, BaseLocationAutoID, BaseUserID, "Observation Authorized");
        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
        {
           
            gvObservation.Columns[5].Visible = true;
            gvObservation.Columns[6].Visible = true;
            lblDesignChangeStatus.Text = Resources.Resource.ObservationAuthorized;
            HideButtonBasedOnStatus();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnActionAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnActionAuthorize_Click(object sender, EventArgs e)
    {
        gvObservation.EditIndex = -1;
        FillgvObservationAfterSave();
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (CheckActionAuthorize() == true)
        {
            
            HideButton();
            ds = objOperationManagement.SecurityDesignReviewActionAuthorize(DateTime.Parse(txtDate.Text), DateTime.Parse(txtDateOfReport.Text), txtConductedBy.Text, ddlReasonForReview.SelectedValue.ToString(), txtDesignChangeNumber.Text, BaseLocationAutoID, BaseUserID, Resources.Resource.ActionAuthorized);
            lblDesignChangeStatus.Text = Resources.Resource.ActionAuthorized;
            DisableFields();
            gvObservation.Columns[0].Visible = false;
            gvObservation.FooterRow.Visible = false;
            HideButtonBasedOnStatus();
            //Added for Upload Document by  on 25-Jun-2013
            if (lblDesignChangeStatus.Text == Resources.Resource.ActionAuthorized)
            {
                gvEmployeeDocument.Columns[4].Visible = false;
                btnUpload.Enabled = false;      //Added by  on 23-July-2013
            }
            //End
        }
        else
        {
            lblErrorMsg.Text = "Implementation Date or Reason for Pending is left blank";
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
       // gvObservation.EditIndex = -1;
        
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        #region Commented Code
        // int flag = 1;
        //if (txtDateOfReport.Text != "")
        //{
        //    if (DateTime.Parse(txtDateOfReport.Text) < DateTime.Parse(hfAsmtStartDate.Value) || DateTime.Parse(txtDateOfReport.Text) > System.DateTime.Now)
        //    {
        //        lblErrorMsg.Text = "Date of report should be between Assignment Start Date and Current Date";
        //       // flag = 0;
        //        return;
        //    }
        //    else
        //    {
        //        flag = 1;
        //    }
        //}
        //if (txtDate.Text != "")
        //{
           
        //    if (DateTime.Parse(txtDate.Text) > DateTime.Now ||DateTime.Parse(txtDate.Text) < DateTime.Parse(hfAsmtStartDate.Value))
        //    {
               
        //        lblErrorMsg.Text = "Date Should be greater than Current Date";
        //        return;
        //    }
        //    else
        //    {
        //        flag = 1;
                
        //    }
        //}
        //if (dtObservationDetail.Rows.Count == 0)
        //{
        //    lblErrorMsg.Text = "observation Details cannot be left blank";//Resources.Resource.NightCheckDetailsCannotbeleftblank;
        //    //flag = 0;
        //    return;
        //}
        #endregion
        if (CheckDates())
        {
            gvObservation.EditIndex = -1;
            FillgvObservationAfterSave();
            ds = objOperationManagement.SecurityDesignReviewUpdate(DateTime.Parse(txtDate.Text), DateTime.Parse(txtDateOfReport.Text), txtConductedBy.Text, ddlReasonForReview.SelectedValue.ToString(), txtDesignChangeNumber.Text, BaseLocationAutoID, BaseUserID,ddlDesignType.SelectedValue.ToString());
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                HideButton();
                HideButtonBasedOnStatus();
               
                ddlDesignType.Enabled = false;
            }
        }
       
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        gvObservation.Columns[0].Visible = false;
        gvObservation.FooterRow.Visible = false;
        gvObservation.EditIndex = -1;
        DisableFields();
       // FillDetails();
        HideButtonBasedOnStatus();
        btnCancel.Visible = false;
        btnUpdate.Visible = false;
        btnEdit.Visible = true;
        //Added by  on 30-May-2013
        ddlAsmtId.Items.Clear();
        FillClientId();
        ddlClientId.Enabled = true;
        //Added code for Upload Document by  on 25-Jun-2013
        FillgvEmployeeDocDownload();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDesignChangeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDesignChangeNumber_TextChanged(object sender, EventArgs e)
    {
        if (txtDesignChangeNumber.Text != "")
        {
            Status = 0;
            FillgvObservationAfterSave();
            FillDetails();
            txtDesignChangeNumber.Enabled = true;
            if (ddlAsmtId.SelectedItem.Value != "" && txtConductedBy.Text != "")
            {
                //txtAssignNo_TextChanged(sender, e);
                ddlAsmtId_SelectedIndexChanged(sender, e);  //Modify by  on 30-May-2013
                txtConductedBy_TextChanged(sender, e);
                HideButton();
                HideButtonBasedOnStatus();
                if (lblDesignChangeStatus.Text == Resources.Resource.Fresh)
                {
                    gvObservation.Columns[0].Visible = true;
                    gvObservation.FooterRow.Visible = true;
                    gvObservation.Columns[5].Visible = false;
                    gvObservation.Columns[6].Visible = false;
                }
                if (lblDesignChangeStatus.Text == Resources.Resource.ObservationAuthorized)
                {
                    EnableFields();
                    gvObservation.Columns[0].Visible = true;
                    gvObservation.FooterRow.Visible = true;
                    gvObservation.Columns[5].Visible = true;
                    gvObservation.Columns[6].Visible = true;
                }
                if (lblDesignChangeStatus.Text == Resources.Resource.ActionAuthorized)
                {
                    DisableFields();
                    gvObservation.Columns[0].Visible = false;
                    gvObservation.FooterRow.Visible = false;
                    //Added by  on 2-Jun-2013
                    gvObservation.Columns[5].Visible = true;
                    gvObservation.Columns[6].Visible = true;
                    //End
                }
                if (lblDesignChangeStatus.Text == Resources.Resource.Amend)
                {
                    gvObservation.Columns[0].Visible = true;
                    gvObservation.FooterRow.Visible = true;
                    gvObservation.Columns[5].Visible = true;
                    gvObservation.Columns[6].Visible = true;
                    EnableFields();
                }

                //Added Code for Upload Document by  on 25-Jun-2013
                FillgvEmployeeDocDownload();
                //End
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                btnAddNew.Visible = true;
            }
        }
        else
        {
            ClearAsmtDetails();
            FillgvObservation();
            lblDesignChangeStatus.Text = "";
            txtEmployeeDesignation.Text = "";
            txtEmployeeName.Text = "";
            //txtAssignNo.Text = "";
            ClearFields();
        }
    }
    /// <summary>
    /// Checks the action authorize.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckActionAuthorize()
    {
        int flag = 1;
        for (int i = 0; i < gvObservation.Rows.Count; i++)
        {
            Label lblImplementationDate = (Label)gvObservation.Rows[i].FindControl("lblImplementationDate");
            Label lblReasonForPending = (Label)gvObservation.Rows[i].FindControl("lblReasonForPending");
            if (lblImplementationDate.Text == "" && lblReasonForPending.Text == "")
            {
                gvObservation.Rows[i].BackColor = System.Drawing.Color.Aqua;
                flag = 0;
                //return;
            }
            else
            {
                if (flag != 0)
                {
                    flag = 1;
                }
            }
        }
        if (flag == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Hides the button based on status.
    /// </summary>
    private void HideButtonBasedOnStatus()
    {
        if (lblDesignChangeStatus.Text == Resources.Resource.Fresh)
        {
            if (IsWriteAccess == true)
            {
                btnObservationAuthorize.Visible = true;
                btnAddNew.Visible = true;
            }
            btnSave.Visible = false;
        }
        if (lblDesignChangeStatus.Text == Resources.Resource.Amend)
        {
            if (IsWriteAccess == true)
            {
                btnAddNew.Visible = true;
                btnCancel.Visible = true;
                btnActionAuthorize.Visible = true;
            }
            if (IsModifyAccess == true)
            {
                btnUpdate.Visible = true;
            }
            btnEdit.Visible = false;
            btnSave.Visible = false;
        }
        if (lblDesignChangeStatus.Text == Resources.Resource.ObservationAuthorized)
        {
            btnObservationAuthorize.Visible = false;
            if (IsWriteAccess == true)
            {
                btnActionAuthorize.Visible = true;
                btnAddNew.Visible = true;
            }
        }

        if (lblDesignChangeStatus.Text == Resources.Resource.ActionAuthorized)
        {
            btnActionAuthorize.Visible = false;
            if (IsWriteAccess == true)
            {
                btnAddNew.Visible = true;
            }
            if (IsModifyAccess == true)
            {
                btnEdit.Visible = true;
            }
        }
    }
    /// <summary>
    /// Enables the fields.
    /// </summary>
    private void EnableFields()
    {
        ddlDesignType.Enabled = true;
        //txtAssignNo.Enabled = true;
        txtConductedBy.Enabled = true;
        ddlReasonForReview.Enabled = true;
        txtDate.Enabled = true;
        txtDateOfReport.Enabled = true;
    }
    /// <summary>
    /// Disables the fields.
    /// </summary>
    private void DisableFields()
    {
        ddlDesignType.Enabled = false;
        //txtAssignNo.Enabled = false;
        txtConductedBy.Enabled = false;
        ddlReasonForReview.Enabled = false;
        txtDate.Enabled = false;
        txtDateOfReport.Enabled = false;
    }
    /// <summary>
    /// Hides the button.
    /// </summary>
    private void HideButton()
    {
        btnActionAuthorize.Visible = false;
        btnAddNew.Visible = false;
        btnCancel.Visible = false;
        btnEdit.Visible = false;
        btnObservationAuthorize.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }
    /// <summary>
    /// Shows the button.
    /// </summary>
    private void ShowButton()
    {
        if (IsWriteAccess == true)
        {
            btnActionAuthorize.Visible = true;
            btnAddNew.Visible = true;
            btnCancel.Visible = true;
            btnSave.Visible = true;
            btnObservationAuthorize.Visible = true;
        }
        if (IsModifyAccess == true)
        {
            btnEdit.Visible = true;
            btnUpdate.Visible = true;
        }
    }
    /// <summary>
    /// Clears the fields.
    /// </summary>
    private void ClearFields()
    {
        txtDesignChangeNumber.Text = "";
        txtDate.Text = "";
        txtDateOfReport.Text = "";
        txtConductedBy.Text = "";
    }
    /// <summary>
    /// Disables the buttons.
    /// </summary>
    private void DisableButtons()
    {
        btnActionAuthorize.Enabled = false;
        btnAddNew.Enabled = false;
        btnCancel.Enabled = false;
        btnEdit.Enabled = false;
        btnSave.Enabled = false;
        btnUpdate.Enabled = false;
        btnObservationAuthorize.Enabled = false;

        //Added Code for Upload Document by  on 25-Jun-2013
        btnUpload.Enabled = false;
    }
    /// <summary>
    /// Enables the buttons.
    /// </summary>
    private void EnableButtons()
    {
        if (IsWriteAccess == true)
        {
            btnActionAuthorize.Enabled = true;
            btnAddNew.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnObservationAuthorize.Enabled = true;
        }
        if (IsModifyAccess == true)
        {
            btnEdit.Enabled = true;
            btnUpdate.Enabled = true;
        }
        //Added Code for Upload Document by  on 14-Jun-2013
        btnUpload.Enabled = true;
    }
    /// <summary>
    /// Fillddls the type of the design.
    /// </summary>
    private void FillddlDesignType()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlDesignType.DataSource = objOperationManagement.SecurityDesignReviewTypeGet(BaseCompanyCode);
        ddlDesignType.DataTextField = "ItemDesc";
        ddlDesignType.DataValueField = "ItemCode";
        ddlDesignType.DataBind();
        if (ddlDesignType.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "0";
            ddlDesignType.Items.Add(li);
            DisableButtons();
        }
    }
    /// <summary>
    /// Fillddls the reason for review.
    /// </summary>
    private void FillddlReasonForReview()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlReasonForReview.DataSource = objOperationManagement.SecurityDesignReviewReasonGet(BaseCompanyCode);
        ddlReasonForReview.DataTextField = "ItemDesc";
        ddlReasonForReview.DataValueField = "ItemCode";
        ddlReasonForReview.DataBind();
        if (ddlReasonForReview.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "0";
            ddlReasonForReview.Items.Add(li);
            DisableButtons();
        }
    }
    /// <summary>
    /// Makes the temporary observation detail.
    /// </summary>
    private void MakeTempObservationDetail()
    {

        DataColumn dCol1 = new DataColumn("RowID", typeof(System.Int32));
        DataColumn dCol2 = new DataColumn("Observation", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Recommendation", typeof(System.String));
        DataColumn dcol4 = new DataColumn("Sensitivity", typeof(System.String));
        DataColumn dcol5 = new DataColumn("ImplementationDate", typeof(System.String));
        DataColumn dcol6 = new DataColumn("ReasonForPending", typeof(System.String));
        DataColumn dcol7 = new DataColumn("TempSensitivity", typeof(System.String));
        dtObservationDetail.Columns.Add(dCol1);
        dtObservationDetail.Columns.Add(dCol2);
        dtObservationDetail.Columns.Add(dcol3);
        dtObservationDetail.Columns.Add(dcol4);
        dtObservationDetail.Columns.Add(dcol5);
        dtObservationDetail.Columns.Add(dcol6);
        dtObservationDetail.Columns.Add(dcol7);
    }
    /// <summary>
    /// Fillgvs the observation.
    /// </summary>
    private void FillgvObservation()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("RowID", typeof(System.Int32));
        DataColumn dCol2 = new DataColumn("Observation", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Recommendation", typeof(System.String));
        DataColumn dcol4 = new DataColumn("Sensitivity", typeof(System.String));
        DataColumn dcol5 = new DataColumn("ImplementationDate", typeof(System.String));
        DataColumn dcol6 = new DataColumn("ReasonForPending", typeof(System.String));
        DataColumn dcol7 = new DataColumn("TempSensitivity", typeof(System.String));
        dt.Columns.Add(dCol1);
        dt.Columns.Add(dCol2);
        dt.Columns.Add(dcol3);
        dt.Columns.Add(dcol4);
        dt.Columns.Add(dcol5);
        dt.Columns.Add(dcol6);
        dt.Columns.Add(dcol7);
        int dtflag;
        dtflag = 1;
        //to fix empty gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvObservation.DataSource = dt;
        gvObservation.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvObservation.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Fillgvs the observation after save.
    /// </summary>
    private void FillgvObservationAfterSave()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dtObservation = new DataTable();
        int dtflag;
        dtflag = 1;
        count = 1;
        ds = objOperationManagement.SecurityDesignReviewObservationDetailGetAll(txtDesignChangeNumber.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0)
        {
            dtObservation = ds.Tables[0];
            //to fix empty gridview
            if (dtObservation.Rows.Count == 0)
            {
                dtflag = 0;
                count = 0;
                dtObservation.Rows.Add(dtObservation.NewRow());
            }
            gvObservation.DataSource = dtObservation;
            gvObservation.DataBind();

            if (dtflag == 0)//to fix empety gridview
            {
                gvObservation.Rows[0].Visible = false;
            }
        }
    }
    /// <summary>
    /// Fills the details.
    /// </summary>
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();

        ds = objOperationManagement.SecurityDesignReviewGetAll(txtDesignChangeNumber.Text, BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDesignType.SelectedValue = ds.Tables[0].Rows[0]["DesignType"].ToString();
            txtConductedBy.Text = ds.Tables[0].Rows[0]["RequestIdentifiedBy"].ToString();
            txtDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DesignChangeDate"].ToString()).ToString("dd-MMM-yyyy");
            txtDateOfReport.Text = DateTime.Parse(ds.Tables[0].Rows[0]["ReportingDate"].ToString()).ToString("dd-MMM-yyyy");
            //txtAssignNo.Text = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
            lblDesignChangeStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            ddlReasonForReview.SelectedValue = ds.Tables[0].Rows[0]["ReasonForReview"].ToString();
            //Added by  on 29-May-2013
            string clientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();     
            SetClientId(clientCode);
            string asmtId = ds.Tables[0].Rows[0]["AsmtId"].ToString();          
            SetAsmt(asmtId);
            ddlClientId.Enabled = false;
            ddlAsmtId.Enabled = false;
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            dtObservationDetail.Clear();
            ClearFields();
            HideButton();
            btnSave.Visible = true;
            ddlDesignType.Enabled = true;
            lblDesignChangeStatus.Text = "";
            FillgvObservation();
        }
    }

    #region Coded Added by 
    //Added by  on 30-May-2013
    /// <summary>
    /// Fills the client identifier.
    /// </summary>
    private void FillClientId()
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ClientDetail");
                dt.Columns.Add("ClientCode");
                dt.Rows.Add("Select", "Select");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["ClientDetail"], ds.Tables[0].Rows[cnt]["ClientCode"]);
                }
                ddlClientId.DataSource = dt;
                ddlClientId.DataTextField = "ClientDetail";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();

                ddlAsmtId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlClientId Item Selection get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtCustomerDesc.Text = ddlClientId.SelectedItem.Text;
        FillAsmt();
    }

    //Get Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Fills the asmt.
    /// </summary>
    private void FillAsmt()
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AsmtCode");
                dt.Columns.Add("AsmtDetail");
                dt.Rows.Add("Select", "Select");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["AsmtCode"], ds.Tables[0].Rows[cnt]["AsmtDetail"]);
                }
                ddlAsmtId.DataSource = dt;
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();

                ddlAsmtId.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlAsmtId Item Selection get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtDetail(); 
    }

    //Added by  on 29-May-2013
    //Set Client Code on based on txtIncidentNo
    /// <summary>
    /// Sets the client identifier.
    /// </summary>
    /// <param name="clientCode">The client code.</param>
    private void SetClientId(string clientCode)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientId.DataSource = ds;
                ddlClientId.DataTextField = "ClientDetail";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["ClientCode"].ToString() == clientCode)
                    {
                        ddlClientId.SelectedIndex = cnt;
                    }
                }
                ddlClientId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }

    //Set Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Sets the asmt.
    /// </summary>
    /// <param name="asmtId">The asmt identifier.</param>
    private void SetAsmt(string asmtId)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlAsmtId.DataSource = ds;
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["AsmtCode"].ToString() == asmtId)
                    {
                        ddlAsmtId.SelectedIndex = cnt;
                    }
                }
                ddlAsmtId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    #endregion

    #region Upload Document Code Added by  on 25-Jun-2013
    /// <summary>
    /// Creates the upload table.
    /// </summary>
    private void CreateUploadTable()
    {
        dtUpload.Clear();
        dtUpload.Columns.Clear();
        dtUpload.Columns.Add("RefNo");
        dtUpload.Columns.Add("EmployeeNumber");
        dtUpload.Columns.Add("FileName");
        dtUpload.Columns.Add("UploadDesc");
        dtUpload.Columns.Add("UploadDate");
        dtUpload.Columns.Add("ModifiedBy");
    }

    /// <summary>
    /// Fillgvs the employee document download.
    /// </summary>
    private void FillgvEmployeeDocDownload()
    {
        string strEmployeeNumber = txtConductedBy.Text;

        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ds = objOPS.OPSDocumentDownload(txtDesignChangeNumber.Text, strEmployeeNumber);
        dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            gvEmployeeDocument.DataSource = dt;
            gvEmployeeDocument.DataBind();
            dvFileUploadGrid.Visible = true;
        }
        else
        {
            dvFileUploadGrid.Visible = false;
        }
        if (lblDesignChangeStatus.Text == Resources.Resource.ActionAuthorized)
        {
            gvEmployeeDocument.Columns[4].Visible = false;
            btnUpload.Enabled = false;
        }
        else
        {
            gvEmployeeDocument.Columns[4].Visible = true;
            btnUpload.Enabled = true;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtConductedBy.Text))
        {
            String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
            string strEmployeeNumber = txtConductedBy.Text;
            string strRefNo = txtDesignChangeNumber.Text;
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet dsFileUpload = new DataSet();
            string DIRPath;
            string FileName;
            DIRPath = path;
            //Modify By  on 23-July-2013
            if (EmployeeDocUpload.HasFile && !string.IsNullOrEmpty(txtUploadDesc.Text))
            {
                FileName = strEmployeeNumber + '[' + '-' + ']' + EmployeeDocUpload.FileName;

                DIRPath = DIRPath + FileName;
                #region New Code for Check Duplicate by  on 26-July-2013
                //Added Code for check the duplicate record in Grid by  on 26-July-2013
                if (gvEmployeeDocument.Rows.Count > 0)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("FileName");
                    dtTemp.Columns.Add("Description");

                    foreach (GridViewRow row in gvEmployeeDocument.Rows)
                    {
                        DataRow drTemp = dtTemp.NewRow();

                        drTemp["FileName"] = ((LinkButton)(row.Cells[1].Controls[1])).Text;
                        drTemp["Description"] = ((Label)(row.Cells[2].Controls[1])).Text;
                        dtTemp.Rows.Add(drTemp);
                    }

                    for (int cnt = 0; cnt < dtTemp.Rows.Count; cnt++)
                    {
                        if (FileName.Trim() == dtTemp.Rows[cnt]["FileName"].ToString().Trim() && txtUploadDesc.Text.Trim() == dtTemp.Rows[cnt]["Description"].ToString().Trim())
                        {
                            lblErrorMsg.Text = "Record already exists";
                            return;
                        }
                        else if (FileName.Trim() == dtTemp.Rows[cnt]["FileName"].ToString().Trim())
                        {
                            lblErrorMsg.Text = "File Name already exists";
                            return;
                        }
                        if (txtUploadDesc.Text.Trim() == dtTemp.Rows[cnt]["Description"].ToString().Trim())
                        {
                            lblErrorMsg.Text = "Upload File Description should not be same";
                            return;
                        }
                    }
                }
                //End
                #endregion
                DataRow dtUploadRow = dtUpload.NewRow();
                dtUploadRow[0] = strRefNo;
                dtUploadRow[1] = strEmployeeNumber;
                dtUploadRow[2] = FileName;
                dtUploadRow[3] = txtUploadDesc.Text;
                dtUploadRow[4] = DateTime.Now;
                dtUploadRow[5] = BaseUserID;
                dtUpload.Rows.Add(dtUploadRow);

                if (!string.IsNullOrEmpty(strRefNo))
                {
                    objOPS.OPSDocumentInsert(dtUpload, BaseUserID);
                    FillgvEmployeeDocDownload();
                    dtUpload.Clear();
                    txtUploadDesc.Text = "";
                    EmployeeDocUpload.PostedFile.SaveAs(DIRPath);
                }
                else
                {
                    if (dtUpload.Rows.Count > 0)
                    {
                        gvEmployeeDocument.DataSource = dtUpload;
                        gvEmployeeDocument.DataBind();
                        dvFileUploadGrid.Visible = true;
                        txtUploadDesc.Text = "";
                        EmployeeDocUpload.PostedFile.SaveAs(DIRPath);
                    }
                }
            }
            else
            {
                lblErrorMsg.Text = "Please select a file and enter document description.";
            }
        }
        else
        {
            lblErrorMsg.Text = "Employee Details should not be blank";
        }
    }
    /// <summary>
    /// Handles the Click event of the lbFileName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbFileName_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbFileName = (LinkButton)gvEmployeeDocument.Rows[row.RowIndex].FindControl("lbFileName");
        String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
        string FileName = path;
        FileName = FileName + lbFileName.Text;
        System.IO.FileInfo file = new System.IO.FileInfo(FileName);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvEmployeeDocument control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDocument_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow objGridViewRow = e.Row;
            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvEmployeeDocument.PageIndex * gvEmployeeDocument.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
            if (IsDeleteAccess == true)
            {
                if (IBDelete != null)
                {
                    IBDelete.Visible = true;
                    gvEmployeeDocument.Columns[3].Visible = true;
                }
            }
            else
            {
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                    gvEmployeeDocument.Columns[3].Visible = false;
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowDeleting event of the gvEmployeeDocument control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();

        string strEmployeeNumber = txtConductedBy.Text;
        string strRefNo = txtDesignChangeNumber.Text;

        LinkButton lbFileName = (LinkButton)gvEmployeeDocument.Rows[e.RowIndex].FindControl("lbFileName");
        ImageButton IBDelete = (ImageButton)gvEmployeeDocument.Rows[e.RowIndex].FindControl("IBDelete");
        if (!string.IsNullOrEmpty(strRefNo))
        {
            ds = objOPS.OPSDocumentDelete(strRefNo, lbFileName.Text, strEmployeeNumber);

            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                DeleteFile(lbFileName.Text);
            }
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else
        {
            if (dtUpload.Rows.Count > 0)
            {
                dtUpload.Rows.RemoveAt(e.RowIndex);
                gvEmployeeDocument.DataSource = dtUpload;
                gvEmployeeDocument.DataBind();
                if (dtUpload.Rows.Count < 1)
                {
                    dvFileUploadGrid.Visible = false;
                }
            }
        }
    }
    /// <summary>
    /// Deletes the file.
    /// </summary>
    /// <param name="strFileName">Name of the string file.</param>
    public void DeleteFile(string strFileName)
    {
        String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
        FileInfo TheFile = new FileInfo(path + strFileName);
        if (TheFile.Exists)
        {
            File.Delete(path + strFileName);
        }
        FillgvEmployeeDocDownload();
    }

    //Added Code for Resolve issue of Update Panel Exception on download file click by  on 2-Jun-2013
    /// <summary>
    /// Handles the PreRender event of the lbFileName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbFileName_PreRender(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            LinkButton MyButton = (LinkButton)sender;
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(MyButton);
        }
    }
    //End
    #endregion
}


