// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CreateShiftPatternSeq.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections;

/// <summary>
/// Class Transactions_CreateShiftPatternSeq.
/// </summary>
public partial class Transactions_CreateShiftPatternSeq : BasePage //System.Web.UI.Page
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
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {

                if (IsWriteAccess == false)
                {
                    btnNewSeq.Visible = false;
                    btnSaveSeq.Visible = false;
                    btnAdd.Visible = false;
                    //btnLockUnlockSeq.Visible = false;
                    btnAdd.Visible = false;
                    btnRemove.Visible = false;
                }


                if (IsModifyAccess == false)
                {
                    btnUpdateSeq.Visible = false;

                }

                if (IsDeleteAccess == false)
                {
                    btnDeleteSeq.Visible = false;

                }

                HFAsmtID.Value = Request.QueryString["AsmtID"];
                HFClientCode.Value = Request.QueryString["ClientCode"];
                HFPostCode.Value = Request.QueryString["Post"];
                HFShowAllPatterns.Value = "0";
                if (HFAsmtID != null)
                {
                    //  btnLockUnlockSeq.Attributes["OnClick"] = "javascript:OpenLockUnlockScreen('" + HFAsmtCode.Value + "');";
                }

                var objUser = new BL.UserManagement();
                DataSet ds = objUser.SystemParameterValuesGet("SchedulePatternType", "LocationAutoId", BaseLocationAutoID);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    PanelAsmtShiftPattern.GroupingText = Resources.Resource.ShiftPattern;
                    HFSystemparameter.Value = ds.Tables[0].Rows[0]["ParamValue1"].ToString();
                }
                FillgvSitepost();
                FillgvAsmtSftPattern();
                FillPatternSeq();

                //if (strstatus == "CreatePattern")
                //{
                //    FillgvSitepost();
                //    FillgvAsmtSftPattern();
                //    FillPatternSeq();
                //}
                //else
                //{
                //    FillgvSitepost();
                //    btnSavePattern.Visible = false;
                //    TxtPatternID.Visible = false;
                //    TextPatternSave.Visible = false;
                //    TxtPattern.Visible = false;
                //    btnClear.Visible = false;
                //}

                txtPatternSeqCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this,'^[a-z|A-Z|0-9|-]$')";
                txtPatternSeqCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this,'^[a-z|A-Z|0-9|-]$')";
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

    }
    /// <summary>
    /// Fillgvs the sitepost.
    /// </summary>
    protected void FillgvSitepost()
    {

        var objRoster = new BL.Roster();
        var ds = new DataSet();
        var dt = new DataTable();


        ds = objRoster.AsmtSitePostGet(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), Request.QueryString["Post"].ToString(), HFSystemparameter.Value, Request.QueryString["FromDate"].ToString(), Request.QueryString["ToDate"].ToString());
        ViewState["AsmtSitePost"] = ds.Tables[0];
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    gvSitepost.DataSource = dt;
                    gvSitepost.DataBind();
                }
                else if (dt.Rows.Count > 0)
                {
                    gvSitepost.DataSource = dt;
                    gvSitepost.DataBind();
                }
            }
        }
    }
    /// <summary>
    /// Fillgvs the asmt SFT pattern.
    /// </summary>
    protected void FillgvAsmtSftPattern()
    {

        var objRoster = new BL.Roster();
        var ds = new DataSet();
        var dt = new DataTable();


        ds = objRoster.AsmtShiftPatternGetAll(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), Request.QueryString["Post"].ToString(), HFShowAllPatterns.Value);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    gvAsmtSftPattern.DataSource = dt;
                    gvAsmtSftPattern.DataBind();
                }
                else
                {
                    gvAsmtSftPattern.DataKeyNames = new string[] { "ShiftPatternID" };
                    gvAsmtSftPattern.DataSource = dt;
                    gvAsmtSftPattern.DataBind();
                    FilllbShiftPattern(ds);
                }
            }
            else
            {
                dt = ds.Tables[0];
                dt.Rows.Add(dt.NewRow());
                gvAsmtSftPattern.DataKeyNames = new string[] { "ShiftPatternID" };
                gvAsmtSftPattern.DataSource = dt;
                gvAsmtSftPattern.DataBind();
                gvAsmtSftPattern.Rows[0].Visible = false;
            }

        }
        CheckBox chkShowAllPatterns = (CheckBox)gvAsmtSftPattern.HeaderRow.FindControl("chkShowAllPatterns");
        if (HFShowAllPatterns.Value == "1")
        {
            chkShowAllPatterns.Checked = true;
        }
        else
        {
            chkShowAllPatterns.Checked = false;
        }
    }
    /// <summary>
    /// Fills the pattern seq.
    /// </summary>
    protected void FillPatternSeq()
    {
        lbShiftPatternCode.Enabled = false;
        lbShiftPatternSeq.Enabled = false;
        btnAdd.Enabled = false;
        btnRemove.Enabled = false;
        btnUp.Enabled = false;
        btnDown.Enabled = false;
        txtPatternSeqCode.Enabled = false;
        btnSaveSeq.Visible = false;
        btnUpdateSeq.Visible = false;
        var objRoster = new BL.Roster();

        var ds = new DataSet();
        ds = objRoster.AsmtShiftPatternSequenceGet(Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), "0", BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            drpExistingPatternSeqCode.Items.Clear();
            drpExistingPatternSeqCode.DataSource = ds;
            drpExistingPatternSeqCode.DataTextField = "PatternSeqCode";
            drpExistingPatternSeqCode.DataValueField = "PatternSeqAutoID";
            drpExistingPatternSeqCode.DataBind();
            drpExistingPatternSeqCode.Items.Insert(0, "Select Pattern Code");
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdateSeq control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnUpdateSeq_Click(object sender, EventArgs e)
    {
        if (lbShiftPatternSeq.Items.Count <= 0)
        {
            return;
        }
        var strPatternSeq = "";
        for (var i = 0; i < lbShiftPatternSeq.Items.Count; i++)
        {
            strPatternSeq = strPatternSeq + lbShiftPatternSeq.Items[i].Text + "~";
        }
        strPatternSeq = strPatternSeq.Substring(0, ((strPatternSeq.Length) - 1));
        var objRoster = new BL.Roster();
        var ds = new DataSet();
        lblErrorMsg.Text = "";
        if (drpExistingPatternSeqCode.SelectedIndex <= 0)
        {
            lblErrorMsg.Text = "Pattern Sequence Code is Required";
            return;
        }
        ds = objRoster.AsmtShiftPatternSequenceSave(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), drpExistingPatternSeqCode.SelectedValue, "0", strPatternSeq, "U", BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the Button Click event of the Delete Sequence
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnDeleteSeq_Click(object sender, EventArgs e)
    {
        BL.Roster objRoster = new BL.Roster();
        if (drpExistingPatternSeqCode.SelectedIndex < 1)
        {
            return;
        }
        DataSet ds = objRoster.AsmtShiftPatternSequenceDelete(drpExistingPatternSeqCode.SelectedValue,int.Parse(BaseLocationAutoID));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
            FillPatternSeq();
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChange event of the drpPatternSeq control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void drpPatternSeq_SelectedIndexChange(object sender, EventArgs e)
    {

        if (drpExistingPatternSeqCode.SelectedIndex > 0)
        {
            txtPatternSeqCode.Enabled = false;
            btnSavePattern.Enabled = true;
            lbShiftPatternCode.Enabled = true;
            lbShiftPatternSeq.Enabled = true;
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            btnUp.Enabled = true;
            btnDown.Enabled = true;
            txtPatternSeqCode.Enabled = true;
            btnDeleteSeq.Visible = true;
            btnSavePattern.Visible = false;
            btnUpdateSeq.Visible = true;
            btnSaveSeq.Visible = false;
            btnUpdateSeq.Visible = true;
            string PatternSeq = "";
            BL.Roster objRoster = new BL.Roster();
            DataSet ds = new DataSet();
            ds = objRoster.AsmtShiftPatternSequenceGet(Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), drpExistingPatternSeqCode.SelectedValue, BaseLocationAutoID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lbShiftPatternSeq.Items.Clear();
                PatternSeq = ds.Tables[0].Rows[0]["PatternSeq"].ToString();
                string[] arrPatternSeq = PatternSeq.Split('~');
                for (int i = 0; i < arrPatternSeq.Count(); i++)
                {
                    lbShiftPatternSeq.Items.Insert(i, arrPatternSeq[i]);
                }

            }
        }
        else
        {
            txtPatternSeqCode.Enabled = true;
            btnNewSeq.Enabled = true;
            btnSavePattern.Text = "Save Sequence";
            lbShiftPatternSeq.Items.Clear();
        }

        if (IsWriteAccess == false)
        {
            btnNewSeq.Visible = false;
            btnSaveSeq.Visible = false;
            btnAdd.Visible = false;
            //btnLockUnlockSeq.Visible = false;
            btnAdd.Visible = false;
            btnRemove.Visible = false;
        }


        if (IsModifyAccess == false)
        {
            btnUpdateSeq.Visible = false;

        }

        if (IsDeleteAccess == false)
        {
            btnDeleteSeq.Visible = false;

        }
    }
    /// <summary>
    /// Filllbs the shift pattern.
    /// </summary>
    /// <param name="ds">The ds.</param>
    protected void FilllbShiftPattern(DataSet ds)
    {
        lbShiftPatternCode.DataSource = ds.Tables[0];
        lbShiftPatternCode.DataTextField = "ShiftPatternID";
        lbShiftPatternCode.DataValueField = "ShiftPatternMasterAutoID";
        lbShiftPatternCode.DataBind();

    }
    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (lbShiftPatternCode.SelectedIndex > -1)
        {

            for (int i = 0; i < lbShiftPatternCode.Items.Count; i++)
            {
                if (lbShiftPatternCode.Items[i].Selected == true)
                {
                    lbShiftPatternSeq.Items.Add(lbShiftPatternCode.Items[i]);
                    //ListItem li = lbShiftPatternCode.Items[i];
                    //lbShiftPatternCode.Items.Remove(li);
                }
            }

            // lbShiftPatternSeq.Items.Add(lbShiftPatternCode.SelectedItem.Text);
        }
    }
    /// <summary>
    /// Handles the Click event of the btnRemove control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        //if (lbShiftPatternSeq.SelectedIndex >= 0)
        //{
        //    ListItem li = lbShiftPatternSeq.SelectedItem;
        //    lbShiftPatternSeq.Items.Remove(li);
        //}

        for (int i = lbShiftPatternSeq.Items.Count - 1; i >= 0; i--)
        {
            if (lbShiftPatternSeq.Items[i].Selected == true)
            {
                ListItem li = lbShiftPatternSeq.Items[i];
                lbShiftPatternSeq.Items.Remove(li);
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnClear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        TxtPattern.Text = "";
        TxtPatternID.Text = "";
        TextPatternSave.Text = "";
    }
    /// <summary>
    /// Handles the Click event of the btnSaveSeq control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnSaveSeq_Click(object sender, EventArgs e)
    {
        if (lbShiftPatternSeq.Items.Count <= 0)
        {
            return;
        }
        string strPatternSeq = "";
        for (int i = 0; i < lbShiftPatternSeq.Items.Count; i++)
        {
            strPatternSeq = strPatternSeq + lbShiftPatternSeq.Items[i].Text + "~";
        }
        strPatternSeq = strPatternSeq.Substring(0, ((strPatternSeq.Length) - 1));
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        lblErrorMsg.Text = "";
       
        //if (txtPatternSeqCode.Text.Length != 0)
        //{
            ds = objRoster.AsmtShiftPatternSequenceSave(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), "0", txtPatternSeqCode.Text, strPatternSeq, "A", BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                {
                    FillPatternSeq();
                }
            }
        //}
        //else
        //{
        //    lblErrorMsg.Text = 
        //    return;
        //}

    }
    /// <summary>
    /// Handles the Click event of the btnUp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnUp_Click(object sender, EventArgs e)
    {

        for (int i = 0; i < lbShiftPatternSeq.Items.Count; i++)
        {
            if (lbShiftPatternSeq.Items[i].Selected)//identify the selected item
            {
                //swap with the top item(move up)
                if (i > 0 && !lbShiftPatternSeq.Items[i - 1].Selected)
                {
                    ListItem bottom = lbShiftPatternSeq.Items[i];
                    lbShiftPatternSeq.Items.Remove(bottom);
                    lbShiftPatternSeq.Items.Insert(i - 1, bottom);
                    lbShiftPatternSeq.Items[i - 1].Selected = true;
                }
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnDown control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnDown_Click(object sender, EventArgs e)
    {
        int startindex = lbShiftPatternSeq.Items.Count - 1;
        for (int i = startindex; i > -1; i--)
        {
            if (lbShiftPatternSeq.Items[i].Selected)//identify the selected item
            {
                //swap with the lower item(move down)
                if (i < startindex && !lbShiftPatternSeq.Items[i + 1].Selected)
                {
                    ListItem bottom = lbShiftPatternSeq.Items[i];
                    lbShiftPatternSeq.Items.Remove(bottom);
                    lbShiftPatternSeq.Items.Insert(i + 1, bottom);
                    lbShiftPatternSeq.Items[i + 1].Selected = true;
                }

            }
        }

    }
    /// <summary>
    /// Handles the Click event of the btnPatternSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnPatternSave_Click(object sender, EventArgs e)
    {
        var objRoster = new BL.Roster();
        var ds = new DataSet();
        ds = objRoster.AsmtShiftPatternSave(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), TxtPatternID.Text, TxtPattern.Text, TextPatternSave.Text, "A", HFSystemparameter.Value, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

        }
        FillgvAsmtSftPattern();

        TxtPatternID.Text = "";
        TxtPattern.Text = "";
        TextPatternSave.Text = "";
    }

    /// <summary>
    /// Generates the shift pattern.
    /// </summary>
    /// <param name="TxtPattern">The TXT pattern.</param>
    /// <param name="TextPatternSave">The text pattern save.</param>
    /// <param name="strShiftPattern">The STR shift pattern.</param>
    private void GenerateShiftPattern(TextBox TxtPattern, TextBox TextPatternSave, string strShiftPattern)
    {
        HFSoLineNo.Value = string.Empty;
        HFShiftCode.Value = string.Empty;
        var dsInvalidShift = new DataTable();
        var dtTempInvalidShift = new DataTable();
        dsInvalidShift = (DataTable)ViewState["AsmtSitePost"];
        var dvInvalidShift = new DataView(dsInvalidShift);
        var grp = from c in TxtPattern.Text.ToCharArray()
                  group c by c into m
                  select new { Key = m.Key, Count = m.Count() };
        foreach (var items in grp)
        {
            dvInvalidShift.RowFilter = "[Shift]='" + items.Key.ToString() + "'"; ;
            dtTempInvalidShift = dvInvalidShift.ToTable();
            if (dtTempInvalidShift.Rows.Count == 0)
            {
                TxtPattern.Text = TxtPattern.Text.Replace(items.Key.ToString(), "");
            }

        }
        TxtPattern.Text = TxtPattern.Text.ToUpper();
        var strPattern = TxtPattern.Text;
        var ds = new DataSet();
        var d = 0;
        var strNextChar = string.Empty;
        var strStartChar = string.Empty;
        string[] arrContinuousChar = new string[strPattern.Length];
        string[] arrPatternID = new string[strPattern.Length];
        var strOrgString = strPattern;
        var strDupChar = string.Empty;
        var length = 0;
        var count = 0;
        length = strPattern.Length;
        for (var i = 0; i < length; i++)
        {

            if ((i + 1) < strPattern.Length)
            {
                strStartChar = strPattern.Substring(0, 1);
                count = i + 1;
                strNextChar = strPattern.Substring(count, 1);
                if (strStartChar == strNextChar)
                {
                    if (strOrgString.Length == 2)
                    {
                        arrContinuousChar[d] = strPattern.Substring(0, 2);
                        break;
                    }
                }
                else
                {
                    arrContinuousChar[d] = strPattern.Substring(0, i + 1);
                    strPattern = strPattern.Remove(0, i + 1);
                    length = strPattern.Length;
                    d = d + 1;
                    i = -1;
                }
            }
            else
            {
                if (strPattern.Length == 1)
                {
                    arrContinuousChar[d] = strPattern.Substring(i, i + 1);
                }
                else
                {
                    strStartChar = strPattern.Substring(0, 1);
                    if (strPattern.Length == 2)
                    {
                        strNextChar = strPattern.Substring(1, 1);
                    }
                    else
                    {
                        if ((i + 1) < strPattern.Length)
                        {
                            strNextChar = strPattern.Substring(i + 1, 1);
                        }
                        else
                        {
                            strNextChar = strPattern.Substring(1, 1);
                        }
                    }
                    if (strStartChar == strNextChar)
                    {
                        if (strPattern.Length == 2)
                        {
                            arrContinuousChar[d] = strPattern.Substring(0, 2);
                            break;
                        }
                        else
                        {
                            arrContinuousChar[d] = strPattern.Substring(0, i + 1);
                            strPattern = strPattern.Remove(0, i + 1);
                            length = strPattern.Length;
                            d = d + 1;
                            i = -1;
                        }
                    }
                    else
                    {
                        arrContinuousChar[d] = strPattern.Substring(0, i + 1);
                        strPattern = strPattern.Remove(0, i + 1);
                        length = strPattern.Length;
                        d = d + 1;
                        i = -1;
                    }
                }
            }

        }

        var strPatternID = string.Empty;
        //var grp = from c in strOrgString.ToCharArray()
        //          group c by c into m
        //          select new { Key = m.Key, Count = m.Count() };


        var dt = new DataTable();
        dt = (DataTable)ViewState["AsmtSitePost"];
        var dv = new DataView(dt);
        var dtTemp = new DataTable();

        MPEDupShift.Hide();
        var k = 0;
        int[] intDupCount = new int[arrContinuousChar.Length];
        var j = 0;
        var flag = 0;
        for (var i = 0; i < arrContinuousChar.Length; i++)
        {

            if (arrContinuousChar.GetValue(i) != null)
            {
                dv.RowFilter = "[Shift]='" + (arrContinuousChar[i].Substring(0, 1)) + "'";
                dtTemp = dv.ToTable();
                if (dtTemp.Rows.Count > 1)
                {
                    intDupCount[k] = i + 1;
                    k++;
                    arrPatternID[j] = arrContinuousChar[i];
                    j++;
                    flag = 1;
                }
                else
                {
                    if (dtTemp.Rows.Count > 0)
                    {
                        arrPatternID[j] = dtTemp.Rows[0]["SoLineNo"].ToString() + ":" + arrContinuousChar[i].Substring(0, 1) + ":" + arrContinuousChar[i].Length.ToString();
                        j++;
                    }

                }
            }
            else
            {
                break;
            }
        }
        if (flag == 0)
        {
            for (int z = 0; z < arrPatternID.Length; z++)
            {
                if (arrPatternID.GetValue(z) != null)
                {
                    strPatternID = strPatternID + arrPatternID[z] + ",";
                }
                else
                {
                    break;
                }


            }
            TextPatternSave.Text = strPatternID;
            HFPatternSave.Value = TextPatternSave.Text;
        }
        else
        {

            var ALDupCount = ArrayList.Adapter(intDupCount);
            ViewState["DupCount"] = ALDupCount;
            var ALPatternID = ArrayList.Adapter(arrPatternID);
            ViewState["PatternID"] = ALPatternID;
            var dtChar = new DataTable();
            var dCol1 = new DataColumn("Position", typeof(System.Int32));
            var dCol2 = new DataColumn("Shift", typeof(System.String));
            var dCol3 = new DataColumn("CharPosition", typeof(System.Int32));
            var dCol4 = new DataColumn("PatternCode", typeof(System.String));

            dtChar.Columns.Add(dCol1);
            dtChar.Columns.Add(dCol2);
            dtChar.Columns.Add(dCol3);
            dtChar.Columns.Add(dCol4);

            dtChar.Clear();
            for (var i = 0; i < ALDupCount.Count; i++)
            {
                if (ALDupCount[i].ToString() != "0")
                {

                    if (ALPatternID.ToArray().GetValue(i) != null)
                    {
                        for (var z = 0; z < ALPatternID[int.Parse(ALDupCount[i].ToString()) - 1].ToString().Length; z++)
                        {
                            var dr = dtChar.NewRow();
                            dr["Shift"] = ALPatternID[int.Parse(ALDupCount[i].ToString()) - 1].ToString().Substring(z, 1);
                            dr["Position"] = (int.Parse(ALDupCount[i].ToString()) - 1).ToString();
                            dr["CharPosition"] = z;
                            dtChar.Rows.Add(dr);
                        }
                    }
                }
            }
            if (strShiftPattern != "")
            {
                var dsShiftpattern = new DataSet();
                var objRoster = new BL.Roster();
                dsShiftpattern = objRoster.AsmtShiftPatternGet(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), strShiftPattern);
                HFSoLineNo.Value = dsShiftpattern.Tables[0].Rows[0]["SoLineNo"].ToString();
                HFShiftCode.Value = dsShiftpattern.Tables[0].Rows[0]["ShiftCode"].ToString();

            }
            gvDuplicateShift.DataSource = dtChar;
            gvDuplicateShift.DataBind();
            ViewState["DuplicateShift"] = dtChar;
            MPEDupShift.Show();
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the TxtPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void TxtPattern_TextChanged(object sender, EventArgs e)
    {
        GenerateShiftPattern(TxtPattern, TextPatternSave, "");
    }

    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        gvAsmtSftPattern.EditIndex = -1;
        FillgvAsmtSftPattern();
    }
    /// <summary>
    /// Fillddls the PD line no.
    /// </summary>
    /// <param name="ddlPDLineNo">The DDL PD line no.</param>
    /// <param name="lblShift">The LBL shift.</param>
    private void FillddlPDLineNo(DropDownList ddlPDLineNo, Label lblShift)
    {
        DataTable dt = new DataTable();
        DataTable dtTemp = new DataTable();

        dt = (DataTable)ViewState["AsmtSitePost"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "[Shift]='" + lblShift.Text + "'";
        dtTemp = dv.ToTable();
        ddlPDLineNo.DataSource = dtTemp;
        ddlPDLineNo.DataTextField = "SoLineSitePost";
        ddlPDLineNo.DataValueField = "SoLineNo";
        ddlPDLineNo.DataBind();
        if (HFSoLineNo.Value != "")
        {
            string[] arrPDLineNo = new string[HFSoLineNo.Value.Length];
            arrPDLineNo = HFSoLineNo.Value.Split(',');
            string[] arrShiftCode = new string[HFShiftCode.Value.Length];
            arrShiftCode = HFShiftCode.Value.Split(',');

            for (int i = 0; i < arrShiftCode.Length; i++)
            {
                if (arrShiftCode[i] == lblShift.Text)
                {
                    ddlPDLineNo.SelectedValue = arrPDLineNo[i];
                    arrShiftCode[i] = "";
                    // arrPDLineNo[i] = "";
                    break;
                }

            }
            string strShiftCode = string.Empty;
            for (int j = 0; j < arrShiftCode.Length; j++)
            {
                strShiftCode = strShiftCode + arrShiftCode[j] + ",";
            }
            HFShiftCode.Value = strShiftCode;

        }



    }
    /// <summary>
    /// Generates the duplicate shift pattern.
    /// </summary>
    /// <param name="TextPatternSave">The text pattern save.</param>
    private void GenerateDuplicateShiftPattern(TextBox TextPatternSave)
    {
        ArrayList ALPatternID = (ArrayList)ViewState["PatternID"];
        string strPatternString = string.Empty;
        DataTable dt = new DataTable();
        DataTable dtTemp = new DataTable();

        dt = (DataTable)ViewState["DuplicateShift"];
        DataView dv = new DataView(dt);

        for (int z = 0; z < gvDuplicateShift.Rows.Count; z++)
        {
            HiddenField HFPosition = (HiddenField)gvDuplicateShift.Rows[z].FindControl("HFPosition");
            HiddenField HFCharPosition = (HiddenField)gvDuplicateShift.Rows[z].FindControl("HFCharPosition");
            HiddenField HFPatternCode = (HiddenField)gvDuplicateShift.Rows[z].FindControl("HFPatternCode");
            DropDownList ddlPDLineNo = (DropDownList)gvDuplicateShift.Rows[z].FindControl("ddlPDLineNo");
            Label lblShift = (Label)gvDuplicateShift.Rows[z].FindControl("lblShift");
            HFPatternCode.Value = "";
            HFPatternCode.Value = ddlPDLineNo.SelectedValue.ToString() + ":" + lblShift.Text + ":" + "1";
            dt.Rows[z]["PatternCode"] = HFPatternCode.Value;
        }
        string strPatternCode = string.Empty;
        string strPosition = string.Empty;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //HiddenField HFPatternCode = (HiddenField)gvDuplicateShift.Rows[i].FindControl("HFPatternCode");
            //HiddenField HFPosition = (HiddenField)gvDuplicateShift.Rows[i].FindControl("HFPosition");

            strPosition = dt.Rows[i]["Position"].ToString();
            dv.RowFilter = "[Position]='" + strPosition + "'";
            dtTemp = dv.ToTable();
            for (int j = 0; j < dtTemp.Rows.Count; j++)
            {
                strPatternCode = dtTemp.Rows[j]["PatternCode"].ToString();
                strPatternString = strPatternString + strPatternCode + ",";
                ALPatternID[int.Parse(strPosition)] = strPatternString;
                dt.Rows[0].Delete();
            }
            if (dtTemp.Rows.Count != 0)
            {
                i = -1;
                strPatternString = "";
            }

        }

        string strPatternID = "";
        for (int z = 0; z < ALPatternID.Count; z++)
        {
            if (ALPatternID.ToArray().GetValue(z) != null)
            {
                if (ALPatternID[z].ToString().Substring((ALPatternID[z].ToString().Length - 1), 1) == ",")
                {
                    strPatternID = strPatternID + ALPatternID[z].ToString();
                }
                else
                {
                    strPatternID = strPatternID + ALPatternID[z].ToString() + ",";
                }
            }
            else
            {
                break;
            }


        }
        TextPatternSave.Text = strPatternID;
        HFPatternSave.Value = TextPatternSave.Text;
    }
    /// <summary>
    /// Handles the Click event of the btnSavePattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnSavePattern_Click(object sender, EventArgs e)
    {
        //gvAsmtSftPattern
        TextBox txtShiftPatternCode = (TextBox)gvAsmtSftPattern.FooterRow.FindControl("txtShiftPatternCode");

        GenerateDuplicateShiftPattern(txtShiftPatternCode);

    }
    /// <summary>
    /// Handles the Click event of the btnNewSeq control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnNewSeq_Click(object sender, EventArgs e)
    {
        btnSavePattern.Enabled = true;
        lbShiftPatternCode.Enabled = true;
        lbShiftPatternSeq.Enabled = true;
        btnAdd.Enabled = true;
        btnRemove.Enabled = true;
        btnUp.Enabled = true;
        btnDown.Enabled = true;
        txtPatternSeqCode.Enabled = true;
        lbShiftPatternSeq.Items.Clear();
        btnSaveSeq.Visible = true;
        btnUpdateSeq.Visible = false;
        btnDeleteSeq.Visible = false;
        txtPatternSeqCode.Focus();
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvDuplicateShift control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvDuplicateShift_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblShift = (Label)e.Row.FindControl("lblShift");
            HiddenField HFPosition = (HiddenField)e.Row.FindControl("HFPosition");
            HiddenField HFCharPosition = (HiddenField)e.Row.FindControl("HFCharPosition");
            DropDownList ddlPDLineNo = (DropDownList)e.Row.FindControl("ddlPDLineNo");

            if (lblShift != null && ddlPDLineNo != null)
            {
                FillddlPDLineNo(ddlPDLineNo, lblShift);
            }

        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvAsmtSftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvAsmtSftPattern_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label ShftPtrn = (Label)gvAsmtSftPattern.Rows[e.RowIndex].FindControl("lnkShiftPattern");
        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRost.AsmtShiftPatternDelete(ShftPtrn.Text, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), int.Parse(BaseLocationAutoID));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
            if (HFSearchPatternCode.Value == "")
            {
                FillgvAsmtSftPattern();
            }
            else
            {

                TextBox txtSearchShiftPatternCode = (TextBox)gvAsmtSftPattern.HeaderRow.FindControl("txtSearchShiftPatternCode");
                if (txtSearchShiftPatternCode != null)
                {
                    SearchShiftPatternCode(txtSearchShiftPatternCode);
                }
            }
            return;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvAsmtSftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvAsmtSftPattern_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        Label lnkShiftPattern = (Label)gvAsmtSftPattern.Rows[e.RowIndex].FindControl("lnkShiftPattern");
        //Label lblShiftPatternCode = (Label)gvAsmtSftPattern.Rows[e.RowIndex].FindControl("lblShiftPatternCode");
        TextBox txtShiftPattern = (TextBox)gvAsmtSftPattern.Rows[e.RowIndex].FindControl("txtShiftPattern");
        //TextBox txtShiftPatternCode = (TextBox)gvAsmtSftPattern.Rows[e.RowIndex].FindControl("txtShiftPatternCode");

        if (HFPatternSave.Value != "")
        {
            if (txtShiftPattern.Text.Length % 7 != 0)
            {
                lblErrorMsg.Text = "Shift Pattern Should be multiple of 7";
                return;
            }

            ds = objRoster.AsmtShiftPatternSave(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), lnkShiftPattern.Text, txtShiftPattern.Text, HFPatternSave.Value, "M", HFSystemparameter.Value, BaseUserID);
            gvAsmtSftPattern.EditIndex = -1;
            if (HFSearchPatternCode.Value == "")
            {
                FillgvAsmtSftPattern();
            }
            else
            {

                TextBox txtSearchShiftPatternCode = (TextBox)gvAsmtSftPattern.HeaderRow.FindControl("txtSearchShiftPatternCode");
                if (txtSearchShiftPatternCode != null)
                {
                    SearchShiftPatternCode(txtSearchShiftPatternCode);
                }
            }
        }
        else
        {
            Show("Error Processing your request !");
        }
        TextPatternSave.Text = "";
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvAsmtSftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvAsmtSftPattern_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAsmtSftPattern.EditIndex = -1;
        if (HFSearchPatternCode.Value == "")
        {
            FillgvAsmtSftPattern();
        }
        else
        {

            TextBox txtSearchShiftPatternCode = (TextBox)gvAsmtSftPattern.HeaderRow.FindControl("txtSearchShiftPatternCode");
            if (txtSearchShiftPatternCode != null)
            {
                SearchShiftPatternCode(txtSearchShiftPatternCode);
            }
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtShiftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtShiftPattern_TextChanged(object sender, EventArgs e)
    {
        var objTextBox = (TextBox)sender;
        var row = (GridViewRow)objTextBox.NamingContainer;
        var txtShiftPattern = (TextBox)gvAsmtSftPattern.Rows[row.RowIndex].FindControl("txtShiftPattern");
        var txtShiftPatternCode = (TextBox)gvAsmtSftPattern.Rows[row.RowIndex].FindControl("txtShiftPatternCode");
        var lnkShiftPattern = (Label)gvAsmtSftPattern.Rows[row.RowIndex].FindControl("lnkShiftPattern");
        if (txtShiftPattern.Text.Length % 7 != 0)
        {
            lblErrorMsg.Text = "Shift Pattern Should be multiple of 7";
            return;
        }
        GenerateShiftPattern(txtShiftPattern, txtShiftPatternCode, lnkShiftPattern.Text);
        UpdatePanel1.Update();

    }
    /// <summary>
    /// Handles the RowEditing event of the gvAsmtSftPattern control.
    /// Changes made by Manish Gupta on 29-Feb-12 to make Shift Pattern and Pattern Code textbox readonly in case of Editing Pattern
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvAsmtSftPattern_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAsmtSftPattern.EditIndex = e.NewEditIndex;
        if (HFSearchPatternCode.Value == "")
        {
            FillgvAsmtSftPattern();
        }
        else
        {

            TextBox txtSearchShiftPatternCode = (TextBox)gvAsmtSftPattern.HeaderRow.FindControl("txtSearchShiftPatternCode");
            if (txtSearchShiftPatternCode != null)
            {
                SearchShiftPatternCode(txtSearchShiftPatternCode);
            }
        }


        TextBox txtShiftPattern = (TextBox)gvAsmtSftPattern.Rows[e.NewEditIndex].FindControl("txtShiftPattern");
        TextBox txtShiftPatternCode = (TextBox)gvAsmtSftPattern.Rows[e.NewEditIndex].FindControl("txtShiftPatternCode");
        Label lnkShiftPattern = (Label)gvAsmtSftPattern.Rows[e.NewEditIndex].FindControl("lnkShiftPattern");
        GenerateShiftPattern(txtShiftPattern, txtShiftPatternCode, lnkShiftPattern.Text);
        if (txtShiftPattern != null)
        {
            TextBox txtShiftPatternFTR = (TextBox)gvAsmtSftPattern.FooterRow.FindControl("txtShiftPattern");
            TextBox txtShiftPatternCodeFTR = (TextBox)gvAsmtSftPattern.FooterRow.FindControl("txtShiftPatternCode");
            if (txtShiftPatternFTR != null && txtShiftPatternCodeFTR != null)
            {
                txtShiftPatternFTR.Enabled = false;
                txtShiftPatternCodeFTR.Enabled = false;
            }
        }
    }
    /// <summary>
    /// Handles the PageIndex event of the gvAsmtSftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvAsmtSftPattern_PageIndex(object sender, GridViewPageEventArgs e)
    {
        gvAsmtSftPattern.PageIndex = e.NewPageIndex;
        if (HFSearchPatternCode.Value == "")
        {
            FillgvAsmtSftPattern();
        }
        else
        {

            TextBox txtSearchShiftPatternCode = (TextBox)gvAsmtSftPattern.HeaderRow.FindControl("txtSearchShiftPatternCode");
            if (txtSearchShiftPatternCode != null)
            {
                SearchShiftPatternCode(txtSearchShiftPatternCode);
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvAsmtSftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvAsmtSftPattern_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtShiftPatternID = (TextBox)gvAsmtSftPattern.FooterRow.FindControl("txtShiftPatternID");
        TextBox txtShiftPattern = (TextBox)gvAsmtSftPattern.FooterRow.FindControl("txtShiftPattern");
        TextBox txtShiftPatternCode = (TextBox)gvAsmtSftPattern.FooterRow.FindControl("txtShiftPatternCode");

        if (e.CommandName == "Add")
        {
            BL.Roster objRoster = new BL.Roster();
            DataSet ds = new DataSet();
            if (txtShiftPattern.Text.Length > 0)
            {
                if (txtShiftPatternCode.Text == "" && HFSystemparameter.Value != "1")
                {
                    GenerateShiftPattern(txtShiftPattern, txtShiftPatternCode, "");
                    UpdatePanel1.Update();
                }
                if (txtShiftPatternCode.Text != "" || HFSystemparameter.Value.ToString().Equals("1"))
                {
                    if (txtShiftPattern.Text.Length % 7 != 0)
                    {
                        lblErrorMsg.Text = "Shift Pattern Should be multiple of 7";
                        return;
                    }
                    ds = objRoster.AsmtShiftPatternSave(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), txtShiftPatternID.Text, txtShiftPattern.Text, txtShiftPatternCode.Text, "A", HFSystemparameter.Value, BaseUserID);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    }
                    FillgvAsmtSftPattern();
                }
                //else
                //{
                //    Show("Error Processing your request !");
                //    txtShiftPattern.Text = "";
                //}
            }
        }
        else if (e.CommandName == "Reset")
        {
            txtShiftPatternID.Text = "";
            txtShiftPattern.Text = "";
            txtShiftPatternCode.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvAsmtSftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvAsmtSftPattern_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            TextBox txtSearchShiftPatternCode = (TextBox)e.Row.FindControl("txtSearchShiftPatternCode");
            if (txtSearchShiftPatternCode != null)
            {
                txtSearchShiftPatternCode.Text = HFSearchPatternCode.Value;
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

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
                TextBox txtShiftPattern = (TextBox)e.Row.FindControl("txtShiftPattern");
                if (txtShiftPattern != null)
                {
                    txtShiftPattern.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this,'^[a-z|A-Z|0-9|-]$')";
                    txtShiftPattern.Attributes["onblur"] = "javascript:validateStringWithExpression(this,'^[a-z|A-Z|0-9|-]$')";
                }
                //bool matchingPattens = false; 
                //CheckBox chkShowAllPatterns = (CheckBox)gvAsmtSftPattern.HeaderRow.FindControl("chkShowAllPatterns");
                //if (HFShowAllPatterns.Value == "1")
                //{
                //    chkShowAllPatterns.Checked = true;
                //}
                //else
                //{
                //    chkShowAllPatterns.Checked = false;
                //}
                //if (!chkShowAllPatterns.Checked)
                //{
                //    Label lblShiftPattern = (Label)e.Row.FindControl("lblShiftPattern");
                //    if (lblShiftPattern != null)
                //    {
                //        matchingPattens = false;
                //        foreach (GridViewRow oItem in gvSitepost.Rows)
                //        {
                //            LinkButton lnkShift = (LinkButton)oItem.FindControl("lnkShift");

                //            if (lnkShift.Text != "0" && lnkShift.Text != "-" && lblShiftPattern.Text.Contains(lnkShift.Text))
                //            {
                //                matchingPattens = true;
                //            }
                //        }

                //        if (!matchingPattens)
                //        {
                //            e.Row.Visible = false;

                //        }
                //    }

                //}  
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
                ImageButton IBDeleteTran = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvAsmtSftPattern.ShowFooter = false;
            }
            else
            {
                TextBox txtShiftPatternID = (TextBox)e.Row.FindControl("txtShiftPatternID");
                TextBox txtShiftPattern = (TextBox)e.Row.FindControl("txtShiftPattern");
                TextBox txtShiftPatternCode = (TextBox)e.Row.FindControl("txtShiftPatternCode");
                if (txtShiftPatternCode != null)
                {
                    txtShiftPatternCode.Attributes["readonly"] = "readonly";
                }

                txtShiftPatternID.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this,'^[a-z|A-Z|0-9]$')";
                txtShiftPatternID.Attributes["onblur"] = "javascript:validateStringWithExpression(this,'^[a-z|A-Z|0-9]$')";

                txtShiftPattern.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this,'^[a-z|A-Z|0-9|-]$')";
                txtShiftPattern.Attributes["onblur"] = "javascript:validateStringWithExpression(this,'^[a-z|A-Z|0-9|-]$')";
            }
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtSearchShiftPatternCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtSearchShiftPatternCode_TextChanged(object sender, EventArgs e)
    {
        TextBox txtSearchShiftPatternCode = (TextBox)gvAsmtSftPattern.HeaderRow.FindControl("txtSearchShiftPatternCode");
        if (txtSearchShiftPatternCode != null)
        {
            if (txtSearchShiftPatternCode.Text != "")
            {
                SearchShiftPatternCode(txtSearchShiftPatternCode);
            }
            else
            {
                HFSearchPatternCode.Value = txtSearchShiftPatternCode.Text;
                FillgvAsmtSftPattern();
            }
        }
    }
    /// <summary>
    /// Searches the shift pattern code.
    /// </summary>
    /// <param name="txtSearchShiftPatternCode">The TXT search shift pattern code.</param>
    private void SearchShiftPatternCode(TextBox txtSearchShiftPatternCode)
    {
        BL.Roster objRoster = new BL.Roster();
        DataTable dt = new DataTable();
        dt = objRoster.AsmtShiftPatternGetAll(BaseLocationAutoID, Request.QueryString["ClientCode"].ToString(), Request.QueryString["AsmtID"].ToString(), Request.QueryString["Post"].ToString(), HFShowAllPatterns.Value).Tables[0];

        DataTable dtSearch = new DataTable();
        DataView dv = new DataView(dt);
        dv.RowFilter = string.Format("[{0}] like '{1}%'", "ShiftPatternID", txtSearchShiftPatternCode.Text);
        dtSearch = dv.ToTable();
        HFSearchPatternCode.Value = txtSearchShiftPatternCode.Text;

        if (dtSearch.Rows.Count == 0)
        {
            dtSearch.Rows.Add(dtSearch.NewRow());
            gvAsmtSftPattern.DataSource = dtSearch;
            gvAsmtSftPattern.DataBind();
            gvAsmtSftPattern.Rows[0].Visible = false;
        }
        else
        {

            gvAsmtSftPattern.DataSource = dtSearch;
            gvAsmtSftPattern.DataBind();
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtShiftPatternNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtShiftPatternNew_TextChanged(object sender, EventArgs e)
    {
        if (HFSystemparameter.Value.ToString().Equals("1"))
        {
            return;
        }

        TextBox txtShiftPattern = (TextBox)gvAsmtSftPattern.FooterRow.FindControl("txtShiftPattern");
        TextBox txtShiftPatternCode = (TextBox)gvAsmtSftPattern.FooterRow.FindControl("txtShiftPatternCode");
        GenerateShiftPattern(txtShiftPattern, txtShiftPatternCode, "");
        //UpdatePanel1.Update();
    }


    /// <summary>
    /// this code added to show all patterns or mattched pattern of assignment
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkShowAllPatterns_CheckedChanged(object sender, EventArgs e)
    {


        CheckBox chkShowAllPatterns = (CheckBox)gvAsmtSftPattern.HeaderRow.FindControl("chkShowAllPatterns");
        if (chkShowAllPatterns.Checked)
        {
            HFShowAllPatterns.Value = "1";
        }
        else
        {
            HFShowAllPatterns.Value = "0";
        }
        FillgvAsmtSftPattern();
    }

}
