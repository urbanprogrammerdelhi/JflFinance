// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="WorkingHrsBusinessRule.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
/// <summary>
/// Class Masters_WorkingHrsBusinessRule
/// </summary>
public partial class Masters_WorkingHrsBusinessRule : BasePage
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
            FillCheckBoxes();
        }
    }
    /// <summary>
    /// Fills the check boxes.
    /// </summary>
    private void FillCheckBoxes()
    {
        DataSet ds = new DataSet();

        BL.MastersManagement objMst = new BL.MastersManagement();
        ds = objMst.DutyTypeGetAll(BaseCompanyCode);
        chkDutyType.DataSource = ds.Tables[0];
        chkDutyType.DataTextField = "LongDutyTypeDesc";
        chkDutyType.DataValueField = "DutyTypeCode";
        chkDutyType.DataBind();

        //Need to Pass Both the Parameters From Query String
        string hoursHeadGroupCode = Request.QueryString["RCode"];
        string guid = Request.QueryString["GUID"]; ;
        FillgvHoursDistribution(hoursHeadGroupCode, guid);
    }
    /// <summary>
    /// Fillgvs the hours distribution.
    /// </summary>
    /// <param name="hoursHeadGroupCode">The hours head group code.</param>
    /// <param name="guid">The GUID.</param>
    private void FillgvHoursDistribution(string hoursHeadGroupCode, string guid)
    {
        BL.BusinessRule objRule = new BL.BusinessRule();

        DataSet ds = new DataSet();
        ds = objRule.NWConditionHoursDistribution_Get(hoursHeadGroupCode, guid);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            reptHrsHead.DataSource = ds.Tables[0];
            reptHrsHead.DataBind();
            /*
            for (int i = 0; i < reptHrsHead.Items.Count; i++)
            {
                Label lblHrsFromWithSchedule = (Label)reptHrsHead.Items[i].FindControl("lblHrsFromWithSchedule");
                Label lblHrsToWithSchedule = (Label)reptHrsHead.Items[i].FindControl("lblHrsToWithSchedule");

                TextBox txtHrsHeadFrom = (TextBox)reptHrsHead.Items[i].FindControl("txtHrsHeadFrom");
                TextBox txtHrsHeadTo = (TextBox)reptHrsHead.Items[i].FindControl("txtHrsHeadTo");
            }
            */
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            string WeekDays = ds.Tables[1].Rows[0]["WeekDay"].ToString();
            IList<string> names = WeekDays.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in names)
            {
                if (s == "1")
                    chkSun.Checked = true;
                if (s == "2")
                    ChkMon.Checked = true;
                if (s == "3")
                    ChkTue.Checked = true;
                if (s == "4")
                    ChkWed.Checked = true;
                if (s == "5")
                    ChkThu.Checked = true;
                if (s == "6")
                    ChkFri.Checked = true;
                if (s == "7")
                    ChkSat.Checked = true;
            }

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                for (int i = 0; i < chkDutyType.Items.Count; i++)
                {
                    if (dr["DutyTypeCode"].ToString() == chkDutyType.Items[i].Value.ToString())
                    {
                        chkDutyType.Items[i].Selected = true;
                    }
                }
            }
        }
    }
    /// <summary>
    /// Clears the screen.
    /// </summary>
    private void ClearScreen()
    {
        chkSun.Checked = false;
        ChkMon.Checked = false;
        ChkTue.Checked = false;
        ChkWed.Checked = false;
        ChkThu.Checked = false;
        ChkFri.Checked = false;
        ChkSat.Checked = false;

        for (int i = 0; i < chkDutyType.Items.Count; i++)
        {
            chkDutyType.Items[i].Selected = false;
        }


        for (int i = 0; i < reptHrsHead.Items.Count; i++)
        {
            TextBox txtHrsHeadFrom = (TextBox)reptHrsHead.Items[i].FindControl("txtHrsHeadFrom");
            TextBox txtHrsHeadTo = (TextBox)reptHrsHead.Items[i].FindControl("txtHrsHeadTo");
            Label lblHrsHeadCode = (Label)reptHrsHead.Items[i].FindControl("lblHrsHeadCode");

            txtHrsHeadFrom.Text = "0";
            txtHrsHeadTo.Text = "0";
        }

    }
    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BL.BusinessRule objRule = new BL.BusinessRule();
        DataSet ds = new DataSet();
        string hoursHeadGroupCode = Request.QueryString["RCode"];
        string guid = Request.QueryString["GUID"];

        ds = objRule.NWConditionHoursDistributionDelete(hoursHeadGroupCode, guid);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg1.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
            ClearScreen();
            FillCheckBoxes();
        }
        else
            lblErrorMsg1.Text = "Error in command";
    }
    /// <summary>
    /// Handles the Event event of the DataBound control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
    protected void DataBound_Event(object sender, RepeaterItemEventArgs e)
    {
        TextBox txtHrsHeadFrom = (TextBox)e.Item.FindControl("txtHrsHeadFrom");
        TextBox txtHrsHeadTo = (TextBox)e.Item.FindControl("txtHrsHeadTo");

        txtHrsHeadFrom.Attributes.Add("onKeyPress", "javascript:return checkNum(event)");
        txtHrsHeadTo.Attributes.Add("onKeyPress", "javascript:return checkNum(event)");

        


        if (int.Parse(txtHrsHeadTo.Text) > 0)
        {
            btnSave.Visible = false;
            btnDelete.Visible = true;
        }
        else
        {

            btnSave.Visible = true;
            btnDelete.Visible = false;
        }

        if (txtHrsHeadTo != null)
        {
            if (txtHrsHeadTo.Text == "-1")
            {
                txtHrsHeadTo.Text = "";
            }

        }

        if (txtHrsHeadFrom != null)
        {
            if (txtHrsHeadFrom.Text == "-1")
            {
                txtHrsHeadFrom.Text = "";
            }

        }
    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        string strWeekdays = string.Empty;

        if (chkSun.Checked)
        {
            strWeekdays = "1";
        }
        if (ChkMon.Checked)
        {
            strWeekdays = strWeekdays + ",2";
        }
        if (ChkTue.Checked)
        {
            strWeekdays = strWeekdays + ",3";
        }
        if (ChkWed.Checked)
        {
            strWeekdays = strWeekdays + ",4";
        }
        if (ChkThu.Checked)
        {
            strWeekdays = strWeekdays + ",5";
        } if (ChkFri.Checked)
        {
            strWeekdays = strWeekdays + ",6";
        }
        if (ChkSat.Checked)
        {
            strWeekdays = strWeekdays + ",7";
        }

        if (strWeekdays.StartsWith(","))
        { strWeekdays = strWeekdays.Remove(0, 1); }

        int intTotalHrs, intTmpTotalHrs, intErrorFlag;
        intTotalHrs = 0;
        intTmpTotalHrs = 0;
        intErrorFlag = 0;

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("HoursHeadCode", typeof(string)));
        dt.Columns.Add(new DataColumn("TimeFrom", typeof(int)));
        dt.Columns.Add(new DataColumn("TimeTo", typeof(int)));

        for (int i = 0; i < reptHrsHead.Items.Count; i++)
        {
            TextBox txtHrsHeadFrom = (TextBox)reptHrsHead.Items[i].FindControl("txtHrsHeadFrom");
            TextBox txtHrsHeadTo = (TextBox)reptHrsHead.Items[i].FindControl("txtHrsHeadTo");
            Label lblHrsHeadCode = (Label)reptHrsHead.Items[i].FindControl("lblHrsHeadCode");

            if (txtHrsHeadFrom.Text != "" && txtHrsHeadTo.Text != "")
            {
                DataRow dr = dt.NewRow();
                if (int.Parse(txtHrsHeadTo.Text) >= 0)
                {
                    dr["HoursHeadCode"] = lblHrsHeadCode.Text;
                    dr["TimeFrom"] = txtHrsHeadFrom.Text;
                    dr["TimeTo"] = txtHrsHeadTo.Text;
                    dt.Rows.Add(dr);
                }
            }

            if (txtHrsHeadFrom.Text != "" && txtHrsHeadTo.Text != "")
            {
                if (int.Parse(txtHrsHeadTo.Text) - int.Parse(txtHrsHeadFrom.Text) < 0)
                {
                    i = reptHrsHead.Items.Count;
                    intErrorFlag = 1;
                }
                else
                {
                    intTmpTotalHrs = intTmpTotalHrs + int.Parse(txtHrsHeadTo.Text) - int.Parse(txtHrsHeadFrom.Text);
                }
            }
        }

        if (intErrorFlag == 1)
        {
            lblErrorMsg1.Text = "Please enter Hours Properly";
            return;
        }

        /*
        TextBox txtHrsHeadFromFooter1 = (TextBox)reptHrsHeadFooter.Items[0].FindControl("txtHrsHeadFromFooter");
        TextBox txtHrsHeadToFooter1 = (TextBox)reptHrsHeadFooter.Items[reptHrsHeadFooter.Items.Count - 1].FindControl("txtHrsHeadToFooter");

        intTotalHrs = int.Parse(txtHrsHeadToFooter1.Text) - int.Parse(txtHrsHeadFromFooter1.Text);

        if (intTotalHrs != intTmpTotalHrs || intErrorFlag == 1)
        {
            lblErrorMsgHrsDistribution.Text = "error! Hours distribution should be in continuity";
        }
        */

        BL.BusinessRule objRule = new BL.BusinessRule();
        DataSet ds = new DataSet();


        DataTable DutyTypeDataTable = new DataTable();
        DutyTypeDataTable.Columns.Add(new DataColumn("DutyTypeCode", typeof(string)));
        for (int i = 0; i < chkDutyType.Items.Count; i++)
        {
            if (chkDutyType.Items[i].Selected)
            {
                DataRow dr = DutyTypeDataTable.NewRow();
                dr["DutyTypeCode"] = chkDutyType.Items[i].Value.ToString();
                DutyTypeDataTable.Rows.Add(dr);
            }
        }

        string hoursHeadGroupCode = Request.QueryString["RCode"];
        string guid = Request.QueryString["GUID"];

        ds = objRule.NWConditionHoursDistributionInsert(strWeekdays, hoursHeadGroupCode, dt, BaseUserID, DutyTypeDataTable, guid);
        //FillgvHoursDistribution();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg1.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
            FillCheckBoxes();
            btnSave.Visible = false;
        }
    }
}