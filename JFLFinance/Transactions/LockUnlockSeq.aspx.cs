// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="LockUnlockSeq.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_LockUnlockSeq.
/// </summary>
public partial class Transactions_LockUnlockSeq : BasePage
{
    /// <summary>
    /// The asmt code
    /// </summary>
    static string asmtCode = string.Empty;
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            asmtCode = Request.QueryString["AsmtCode"].ToString();
            FillgvLockUnlockSeq();
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.LockUnlockSeq + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
        }
    }
    //protected void Page_PreRender(object sender, EventArgs e)
    //{
    //    FillgvLockUnlockSeq();
    //}
    /// <summary>
    /// Handles the CheckedChanged event of the cbIsActive control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void cbIsActive_CheckedChanged(object sender, EventArgs e)
    {
        var cbIsActive = (CheckBox)sender;
        var gridViewRow = (GridViewRow)cbIsActive.NamingContainer;
        var hfPatternSeqAutoID = (HiddenField)gvLockUnlockSeq.Rows[gridViewRow.RowIndex].FindControl("hfPatternSeqAutoID");
        if (hfPatternSeqAutoID != null)
        {
            BL.Roster objRoster = new BL.Roster();
            DataSet ds = new DataSet();
            ds = objRoster.PatternsSequenceUpdate(BaseLocationAutoID, hfPatternSeqAutoID.Value, cbIsActive.Checked);
        }
        FillgvLockUnlockSeq();
    }
    
    #region Grid Events
    /// <summary>
    /// Handles the DataBound event of the gvLockUnlockSeq control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLockUnlockSeq_DataBound(object sender, GridViewRowEventArgs e)
    {

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvLockUnlockSeq control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvLockUnlockSeq_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvLockUnlockSeq control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvLockUnlockSeq_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLockUnlockSeq.EditIndex = -1;
        gvLockUnlockSeq.PageIndex = e.NewPageIndex;
        FillgvLockUnlockSeq();
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvLockUnlockSeq control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLockUnlockSeq_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvLockUnlockSeq.PageIndex * gvLockUnlockSeq.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfPatternSeqAutoID = (HiddenField)e.Row.FindControl("hfPatternSeqAutoID");
            DropDownList ddlPattern = (DropDownList)e.Row.FindControl("ddlPattern");
            if (hfPatternSeqAutoID != null)
            {
                FillPattern(ddlPattern, hfPatternSeqAutoID);
            }
        }
    }
    

      

    #endregion
    /// <summary>
    /// Fills the pattern.
    /// </summary>
    /// <param name="ddlPattern">The DDL pattern.</param>
    /// <param name="hfPatternSeqAutoID">The hf pattern seq automatic identifier.</param>
    protected void FillPattern(DropDownList ddlPattern, HiddenField hfPatternSeqAutoID)
    {
        ddlPattern.Items.Clear();
        BL.Roster objRoster = new BL.Roster();
        DataSet dsPattern = new DataSet();
        dsPattern = objRoster.SplitPatternsFromSequence(BaseLocationAutoID, hfPatternSeqAutoID.Value);
        if (dsPattern != null && dsPattern.Tables.Count > 0 && dsPattern.Tables[0].Rows.Count > 0)
        {
            ddlPattern.DataSource = dsPattern.Tables[0];
            ddlPattern.DataTextField = "Pattern";
            ddlPattern.DataValueField = "Pattern";
            ddlPattern.DataBind();

        }
    }
    /// <summary>
    /// Fillgvs the lock unlock seq.
    /// </summary>
    protected void FillgvLockUnlockSeq()
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet dsSeq = new DataSet();
        DataTable dtSeq = new DataTable();
        int dtflag;
        dtflag = 1;

        dsSeq = objRoster.PatternSequenceGet(BaseLocationAutoID, asmtCode);
        dtSeq = dsSeq.Tables[0];


        gvLockUnlockSeq.DataKeyNames = new string[] { "PatternSeqAutoID" };
        gvLockUnlockSeq.DataSource = dtSeq;
        gvLockUnlockSeq.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvLockUnlockSeq.Rows[0].Visible = false;
        }

    }
}