// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="RefresherTrainingSchedulePatternDefinition.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_RefresherTrainingSchedulePatternDefinition
/// </summary>
public partial class Masters_RefresherTrainingSchedulePatternDefinition : BasePage
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
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.TrainingMaster;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.RefresherTrainingSchedulePatternDefinition + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                string TrainingCode = Request.QueryString["TrainingCode"];
                FetchTrainingDetailsBasedOnSelectedTraining(TrainingCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }

    }

    /// <summary>
    /// Fetches the training details based on selected training.
    /// </summary>
    /// <param name="TrainingCode">The training code.</param>
    public void FetchTrainingDetailsBasedOnSelectedTraining(string TrainingCode)
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objMastersManagement.TrainingDetailsGet(BaseCompanyCode, TrainingCode.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtTrainingCode.Text = TrainingCode;
            txtTrainingDesc.Text = ds.Tables[0].Rows[0]["TrainingDesc"].ToString();
            txtValidForMonths.Text = ds.Tables[0].Rows[0]["ValidMonths"].ToString();
            txtRefTrainAfterNMonths.Text = ds.Tables[0].Rows[0]["RefTrainAfterNMonths"].ToString();
            txtRefTrainingDays.Text = ds.Tables[0].Rows[0]["RefTrainingDays"].ToString();

            FillgvTraining(TrainingCode);
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlTraining_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchTrainingDetailsBasedOnSelectedTraining(txtTrainingCode.Text);
    }

    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objMastersManagement.RefresherTrainingGenerateScheduleMonths(BaseCompanyCode, txtTrainingCode.Text, int.Parse(txtValidForMonths.Text), int.Parse(txtRefTrainAfterNMonths.Text), int.Parse(txtRefTrainingDays.Text), BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            btnSubmit.Enabled = false;
            FetchTrainingDetailsBasedOnSelectedTraining(txtTrainingCode.Text);
        }
    }

    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string Status = Resources.Resource.Update;
        Response.Redirect("Training.aspx");
    }

    /// <summary>
    /// Fillgvs the training.
    /// </summary>
    /// <param name="TrainingCode">The training code.</param>
    private void FillgvTraining(string TrainingCode)
    {
        BL.MastersManagement objblMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objblMastersManagement.RefresherTrainingSchedulePatternDetailsGet(BaseCompanyCode, TrainingCode);
        dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvTraining.DataSource = dt;
        gvTraining.DataBind();

        if (dtflag == 0)//to fix empty gridview
        {
            gvTraining.Rows[0].Visible = false;
            btnSubmit.Enabled = true;
        }
        else
        {
            btnSubmit.Enabled = false;
        }
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
        FetchTrainingDetailsBasedOnSelectedTraining(txtTrainingCode.Text);
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");

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
            if (IsModifyAccess == false)
            {
                ImageButton IBEditEmpRefresherTrainingDetails = (ImageButton)e.Row.FindControl("IBEditEmpRefresherTrainingDetails");
                if (IBEditEmpRefresherTrainingDetails != null)
                {
                    IBEditEmpRefresherTrainingDetails.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdateEmpRefresherTrainingDetails = (ImageButton)e.Row.FindControl("ImgbtnUpdateEmpRefresherTrainingDetails");
                if (ImgbtnUpdateEmpRefresherTrainingDetails != null)
                {
                    ImgbtnUpdateEmpRefresherTrainingDetails.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

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
        FetchTrainingDetailsBasedOnSelectedTraining(txtTrainingCode.Text);
    }

    /// <summary>
    /// Handles the RowCommand event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    /// <summary>
    /// Handles the RowUpdating event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblEditTrainingCode = (Label)gvTraining.Rows[e.RowIndex].FindControl("lblEditTrainingCode");
        Label LabelEditItemMonth = (Label)gvTraining.Rows[e.RowIndex].FindControl("LabelEditItemMonth");
        TextBox txtRefTrainingDays = (TextBox)gvTraining.Rows[e.RowIndex].FindControl("txtRefTrainingDays");

        BL.MastersManagement objblMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objblMastersManagement.TrainingMasterSchedulePatternUpdate(BaseCompanyCode, lblEditTrainingCode.Text, int.Parse(LabelEditItemMonth.Text), int.Parse(txtRefTrainingDays.Text), BaseUserID);

        lblErrorMsg.Text = ds.Tables[0].Rows[0]["Comment"].ToString();

        gvTraining.EditIndex = -1;
        FetchTrainingDetailsBasedOnSelectedTraining(txtTrainingCode.Text);
        gvTraining.DataBind();
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTraining.EditIndex = -1;
        FetchTrainingDetailsBasedOnSelectedTraining(txtTrainingCode.Text);
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
    /// Handles the RowCreated event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

}