// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SchEmpWiseDefineWeekOff_AnEmp.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_SchEmpWiseDefineWeekOff_AnEmp.
/// </summary>
public partial class Transactions_SchEmpWiseDefineWeekOff_AnEmp : BasePage // System.Web.UI.Page
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
    /// The index
    /// </summary>
    static int Index;
    //convert to crosstab function is not complete.... need to check
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
            if (IsReadAccess == true)
            {
                //Code added by Manoj on 16 Jan 2012
                //Page Title from resource file
                System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resources.Resource.SchEmpWiseDefineWeekOff_AnEmp + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

                //Code Added By Manish  Dated 27-Apr-2010
                string strFromdate = Request.QueryString["FromDate"].ToString();
                string strToDate = Request.QueryString["ToDate"].ToString();
                //string[] strArray = new string[2];
                //strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, intMonth, int.Parse(txtYear.Text));
                //txtFromDate.Value = strArray[0];
                //txtToDate.Value = strArray[1];
                string strMonthRangeFromDate = GetMonthRangeFromDate(strFromdate, strToDate);

                DataSet dsRotaAuthStatus = new DataSet();
                BL.Roster objRoster = new BL.Roster();
                dsRotaAuthStatus = objRoster.RotaAuthorizationDetailGet(BaseLocationAutoID, strMonthRangeFromDate);
                if (dsRotaAuthStatus != null && dsRotaAuthStatus.Tables.Count > 0)
                {
                    HFRotaAuthStatus.Value = dsRotaAuthStatus.Tables[0].Rows[0]["MonthVal"].ToString();
                    btnAdd.Visible = false;
                }
                else
                {
                    HFRotaAuthStatus.Value = "";
                    btnAdd.Visible = true;
                }
                //END OF Code Added By Manish  Dated 27-Apr-2010
                FillgvWeekOff();
                if (IsWriteAccess == true)
                {
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                }
            }
            else
            {
                btnAdd.Visible = false;
                lblErrorMsg.Text = Resources.Resource.NOAccessRights.ToString();
            }
        }
        //btnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";            
    }
    #endregion

    #region Grid View Fill

    /// <summary>
    /// Fillgvs the week off.
    /// </summary>
    private void FillgvWeekOff()
    {
        DataSet ds = new DataSet();
        DataTable dtNew = new DataTable();
        BL.Roster objRoster = new BL.Roster();
        string strFromdate, strToDate, strEmployeeNumber;
        strFromdate = Request.QueryString["FromDate"].ToString();
        strToDate = Request.QueryString["ToDate"].ToString();
        strEmployeeNumber = Request.QueryString["EmployeeNumber"].ToString();
        ds = objRoster.EmployeeWiseWeeklyOffGet(BaseLocationAutoID, DateTime.Parse(strFromdate), DateTime.Parse(strToDate), Request.QueryString["AsmtCode"].ToString(), strEmployeeNumber);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0 && ds.Tables[2].Rows.Count > 0)
        {
            btnAdd.Visible = true;
            dtNew = ConvertToCrossTab(ds.Tables[0], ds.Tables[1], ds.Tables[2]);
            gvWeekOff.Columns.Clear();

            //To Filter or Search the Employees in DataTable *********************
            DataView dvNew = new DataView(dtNew);
            dvNew.RowFilter = "";

            gvWeekOff.DataSource = dvNew;
            //**********************************************************
            //gvWeekOff.DataSource = dtNew;

            foreach (DataColumn dcol in dtNew.Columns)
            {
                CustomBoundField bfield = new CustomBoundField();
                bfield.DataField = dcol.ColumnName;
                bfield.HeaderText = dcol.ColumnName;
                if (dcol.ExtendedProperties["Editable"] != null)
                {
                    bfield.Editable = Convert.ToBoolean(dcol.ExtendedProperties["Editable"]);
                }
                if (dcol.ExtendedProperties["CheckBox"] != null)
                {
                    bfield.ShowCheckBox = Convert.ToBoolean(dcol.ExtendedProperties["CheckBox"]);
                }
                gvWeekOff.Columns.Add(bfield);
            }

            gvWeekOff.DataBind();

        }
    }
    /// <summary>
    /// Converts to cross tab.
    /// </summary>
    /// <param name="TbweekOff">The tbweek off.</param>
    /// <param name="Tbdate">The tbdate.</param>
    /// <param name="TbEmp">The tb emp.</param>
    /// <returns>DataTable.</returns>
    private DataTable ConvertToCrossTab(DataTable TbweekOff, DataTable Tbdate, DataTable TbEmp)
    {

        DataTable newTable = new DataTable();
        DataColumn dc = new DataColumn();

        dc.ColumnName = Resources.Resource.EmployeeNumber;
        dc.DataType = System.Type.GetType("System.String");
        dc.DefaultValue = "";
        dc.ExtendedProperties["Editable"] = false;
        newTable.Columns.Add(dc);

        
        //dc = new DataColumn();
        //dc.ColumnName = "Name";
        //dc.DataType = System.Type.GetType("System.String");
        //dc.DefaultValue = "";
        //dc.ExtendedProperties["Editable"] = false;
        //newTable.Columns.Add(dc);

        for (int r = 0; r < Tbdate.Rows.Count; r++)
        {
            dc = new DataColumn();
            dc.ColumnName = DateTime.Parse(Tbdate.Rows[r]["DutyDate"].ToString()).ToString("dd-MMM-yyyy");
            dc.DataType = System.Type.GetType("System.Boolean");
            dc.ExtendedProperties["CheckBox"] = true;
            dc.DefaultValue = false;
            newTable.Columns.Add(dc);
        }
        for (int c = 0; c < TbEmp.Rows.Count; c++)
        {
            DataRow row = newTable.NewRow();
            row[Resources.Resource.EmployeeNumber] = TbEmp.Rows[c]["EmployeeNumber"].ToString();
            //row["Name"] = TbEmp.Rows[c]["Name"].ToString();
            newTable.Rows.Add(row);
        }
        string strEmployeeNumber = string.Empty;
        for (int f = 0; f < TbweekOff.Rows.Count; f++)
        {
            //dc = new DataColumn();
            //dc.ColumnName = "IsConverted";
            //dc.DataType = System.Type.GetType("System.String");
            //dc.DefaultValue = "";
            //dc.ExtendedProperties["Editable"] = false;
            //newTable.Columns.Add(dc);
            if (TbweekOff.Rows[f]["IsWeekOff"].ToString() == "1")
            {
                strEmployeeNumber = TbweekOff.Rows[f]["EmployeeNumber"].ToString();
                for (int g = 0; g < newTable.Rows.Count; g++)
                {
                    if (strEmployeeNumber == newTable.Rows[g][Resources.Resource.EmployeeNumber].ToString())
                    {
                        newTable.Rows[g][DateTime.Parse(TbweekOff.Rows[f]["DutyDate"].ToString()).ToString("dd-MMM-yyyy")] = true; // bool.Parse(TbweekOff.Rows[f]["IsWeekOff"].ToString());
                        break;
                    }
                }
            }
        }

        return newTable;
    }
    #endregion

    #region Gridview events
    /// <summary>
    /// Handles the RowDataBound event of the gvWeekOff control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvWeekOff_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
        if (IsWriteAccess == false)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                for (int j = 0; j < e.Row.Cells[i].Controls.Count; j++)
                {
                    if (e.Row.Cells[i].Controls[j].GetType() == typeof(CheckBox))
                    {
                        CheckBox cbWeekOff = (CheckBox)e.Row.Cells[i].Controls[j];
                        cbWeekOff.Enabled = false;
                    }
                }
            }
        }
        //Code Added By Manish  Dated 27-Apr-2010
        else if (IsWriteAccess == true)
        {
            if (HFRotaAuthStatus.Value != "")
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    for (int j = 0; j < e.Row.Cells[i].Controls.Count; j++)
                    {
                        if (e.Row.Cells[i].Controls[j].GetType() == typeof(CheckBox))
                        {
                            CheckBox cbWeekOff = (CheckBox)e.Row.Cells[i].Controls[j];
                            cbWeekOff.Enabled = false;
                        }
                    }
                }
            }
        }
        //END OF Code Added By Manish  Dated 27-Apr-2010
        ImageButton ImgbtnDelete1 = (ImageButton)e.Row.FindControl("ImgbtnDelete1");
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        //    e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        //}
    }
    /// <summary>
    /// Handles the RowCommand event of the gvWeekOff control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvWeekOff_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvWeekOff.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvWeekOff.PageIndex = gvWeekOff.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvWeekOff control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvWeekOff_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewRow gvrPager = gvWeekOff.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvWeekOff.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvWeekOff.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvWeekOff.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvWeekOff.PageIndex = e.NewPageIndex;
        }
        SaveData();
        //FillgvWeekOff();
    }
    //Added By Manish  Ticket No :146829 Modified Date : 03 mar 2010

    /// <summary>
    /// Handles the Click event of the btnOk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
        FillgvWeekOff();
    }
    //END OF Added By Manish  Ticket No :146829 Modified Date : 03 mar 2010
    /// <summary>
    /// Handles the DataBound event of the gvWeekOff control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvWeekOff_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvWeekOff.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvWeekOff.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvWeekOff.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvWeekOff.PageCount.ToString();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow row = gvWeekOff.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvWeekOff.PageIndex = ddlPages.SelectedIndex;
        SaveData();
        //FillgvWeekOff();
    }
    #endregion

    #region Page Buttons events

    /// <summary>
    /// Handles the Click event of the btnSearchWeekOff control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearchWeekOff_Click(object sender, EventArgs e)
    {
        gvWeekOff.PageIndex = 0;
        FillgvWeekOff();
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //txtEmpNumber.Text = "";
        //txtEmpFirstName.Text = "";
        //txtEmpLastName.Text = "";
    }
    /// <summary>
    /// Handles the CheckedChanged event of the chBox control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkBox = (CheckBox)sender;
        lblErrorMsg.Text = chkBox.ID.ToString();
    }
    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SaveData();
    }
    /// <summary>
    /// Saves the data.
    /// </summary>
    private void SaveData()
    {

        string strAsmtCode = Request.QueryString["AsmtCode"];
        string strShiftPatternCode = Request.QueryString["ShiftPatternCode"];
        string strPatternPosition = Request.QueryString["PatternPosition"];
        string strSoRank = Request.QueryString["SoRank"];
        string strDefaultSite = Request.QueryString["DefaultSite"];
        DataTable DTableSave = new DataTable();
        DataColumn dc = new DataColumn();

        dc.ColumnName = "EmployeeNumber";
        dc.DataType = System.Type.GetType("System.String");
        dc.DefaultValue = "";
        DTableSave.Columns.Add(dc);

        dc = new DataColumn();
        dc.ColumnName = "DutyDate";
        dc.DataType = System.Type.GetType("System.String");
        dc.DefaultValue = "";
        DTableSave.Columns.Add(dc);

        dc = new DataColumn();
        dc.ColumnName = "IsWeekOff";
        dc.DataType = System.Type.GetType("System.Boolean");
        dc.DefaultValue = false;
        DTableSave.Columns.Add(dc);

        for (int g = 0; g < gvWeekOff.Rows.Count; g++)
        {
            for (int i = 0; i < gvWeekOff.Rows[g].Cells.Count; i++)
            {
                for (int j = 0; j < gvWeekOff.Rows[g].Cells[i].Controls.Count; j++)
                {
                    if (gvWeekOff.Rows[g].Cells[i].Controls[j].GetType() == typeof(CheckBox))
                    {
                        CheckBox cb = (CheckBox)gvWeekOff.Rows[g].Cells[i].Controls[j];
                        Label lblEmpNo = (Label)gvWeekOff.Rows[g].Cells[0].Controls[0];
                        //Label lbldate = (Label)gvWeekOff.HeaderRow.Cells[i].Controls[0];
                        if (cb != null && lblEmpNo != null)// && lbldate != null)
                        {
                            DataRow row = DTableSave.NewRow();
                            row["EmployeeNumber"] = lblEmpNo.Text;
                            //row["DutyDate"] = lbldate.Text;
                            row["DutyDate"] = cb.ToolTip;
                            row["IsWeekOff"] = cb.Checked;
                            DTableSave.Rows.Add(row);
                        }
                    }
                }
            }
        }

        //Added By Manish  Ticket No :146829 Modified Date : 03 mar 2010
        BL.Roster objRoster = new BL.Roster();
        DataTable ds = new DataTable();
        ds = objRoster.EmployeeWiseWeeklyOffSave(BaseLocationAutoID, DTableSave, BaseUserID, strAsmtCode, strShiftPatternCode,int.Parse(strPatternPosition),bool.Parse(strDefaultSite),strSoRank);
        if (ds.Rows.Count > 0 && ds != null)
        {
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                if (ds.Rows[i]["MessageId"].ToString() == "102")
                {
                    ds.Rows[i]["Message"] = MessageString_Get(102);
                }

                if (ds.Rows[i]["MessageId"].ToString() == "66")
                {
                    ds.Rows[i]["Message"] = MessageString_Get(66);
                }

            }
            //DataView dv = new DataView(ds);
           // dv.RowFilter = "[MessageId]='" + 102 + "'";
            gvLeaveDetails.DataSource = ds;
            gvLeaveDetails.DataBind();
         
            UpdatePanel2.Update();
            ModalPopupExtender2.Show();
            FillgvWeekOff();

        }
        else
        {
            DisplayMessage(lblErrorMsg, "2");
            ModalPopupExtender2.Hide();
            FillgvWeekOff();
        }

        //END OF Added By Manish  Ticket No :146829 Modified Date : 03 mar 2010

    }
    #endregion
}