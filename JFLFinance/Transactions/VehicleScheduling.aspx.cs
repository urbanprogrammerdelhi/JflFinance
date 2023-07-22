// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="VehicleScheduling.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_VehicleScheduling.
/// </summary>
public partial class Transactions_VehicleScheduling : BasePage//System.Web.UI.Page
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
               
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.VehicleScheduling;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.VehicleScheduling + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");

                hlFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID.ToString() + "');";
                hlToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID.ToString() + "');";

                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();
                FillSearchDropDownList();
                btnAdd.Visible = false;
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Grid View Fill
    /// <summary>
    /// Fills the search drop down list.
    /// </summary>
    private void FillSearchDropDownList()
    {
        SortedList sl = new SortedList();
        BL.Common objCommon = new BL.Common();
        sl = objCommon.OperatorNameGet("String");

        foreach (DictionaryEntry item in sl)
        {
            ListItem LI = new ListItem();
            if (sl[item.Key] == item.Value)
            {
                LI.Text = item.Value.ToString();
                LI.Value = item.Key.ToString();
                ddlSearchEmpNumberCON.Items.Add(LI);
                ddlSearchFirstNameCON.Items.Add(LI);
                ddlSearchLastNameCON.Items.Add(LI);
            }
        }

        sl = objCommon.OperatorNameGet("AndOrOperator");

        foreach (DictionaryEntry item in sl)
        {
            ListItem LI = new ListItem();
            if (sl[item.Key] == item.Value)
            {
                LI.Text = item.Value.ToString();
                LI.Value = item.Key.ToString();
                ddlSearchEmpNumberOPR.Items.Add(LI);
                ddlSearchFirstNameOPR.Items.Add(LI);
                ddlSearchLastNameOPR.Items.Add(LI);
            }
        }
    }
    /// <summary>
    /// Fillgvs the vehicle.
    /// </summary>
    private void FillgvVehicle()
    {
        DataSet ds = new DataSet();
        DataTable dtNew = new DataTable();

        BL.Roster objRoster = new BL.Roster();
       // ds = objRoster.blTrnEmployeeWeeklyOff_Get(BaseLocationAutoID, DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text), ddlWeekOFFType.SelectedValue.ToString());
        ds = objRoster.VehicleSchedulingGet(BaseLocationAutoID, DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0 && ds.Tables[2].Rows.Count > 0)
        {
            if (IsWriteAccess == true && IsDeleteAccess == true && IsModifyAccess == true)
            {
                btnAdd.Visible = true;
            }

            dtNew = ConvertToCrossTab(ds.Tables[0], ds.Tables[1], ds.Tables[2]);
            gvVehicle.Columns.Clear();

            //To Filter or Search the Employees in DataTable *********************
            //DataView dvNew = new DataView(dtNew);
            //dvNew.RowFilter = "";
            //string strFilterStatement = "";

            //if (txtEmpNumber.Text.Length > 0)
            //{
            //    strFilterStatement = strFilterStatement + " [Employee No] " + ddlSearchEmpNumberCON.SelectedItem.Value.ToString() + "'" + txtEmpNumber.Text + "'";
            //}
            //if (txtEmpFirstName.Text.Length > 0)
            //{
            //    if (strFilterStatement.Length > 0)
            //    {
            //        strFilterStatement = strFilterStatement + " " + ddlSearchFirstNameOPR.SelectedItem.Value.ToString();
            //    }
            //    strFilterStatement = strFilterStatement + " Name " + ddlSearchFirstNameCON.SelectedItem.Value.ToString() + "'" + txtEmpFirstName.Text + "'";
            //}
            //if (txtEmpLastName.Text.Length > 0)
            //{
            //    if (strFilterStatement.Length > 0)
            //    {
            //        strFilterStatement = strFilterStatement + " " + ddlSearchLastNameOPR.SelectedItem.Value.ToString();
            //    }
            //    strFilterStatement = strFilterStatement + " Name " + ddlSearchLastNameCON.SelectedItem.Value.ToString() + "'" + txtEmpLastName.Text + "'";
            //}

            //dvNew.RowFilter = strFilterStatement;
            //gvVehicle.DataSource = dvNew;
            //**********************************************************
            gvVehicle.DataSource = dtNew;

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
                gvVehicle.Columns.Add(bfield);
                
            }
            gvVehicle.DataBind();
            gvVehicle.Columns[2].Visible = false;
        }
    }
    /// <summary>
    /// Converts to cross tab.
    /// </summary>
    /// <param name="TbVehicleOff">The tb vehicle off.</param>
    /// <param name="Tbdate">The tbdate.</param>
    /// <param name="TbVehicle">The tb vehicle.</param>
    /// <returns>DataTable.</returns>
    private DataTable ConvertToCrossTab(DataTable TbVehicleOff, DataTable Tbdate, DataTable TbVehicle)
    {

        DataTable newTable = new DataTable();
        DataColumn dc = new DataColumn();

        dc.ColumnName = Resources.Resource.VehicleNumber;// "Vehicle Number";
        dc.DataType = System.Type.GetType("System.String");
        dc.DefaultValue = "";
        dc.ExtendedProperties["Editable"] = false;
        newTable.Columns.Add(dc);

        dc = new DataColumn();
        dc.ColumnName = Resources.Resource.VehicleDesc; //"Vehicle Desc";
        dc.DataType = System.Type.GetType("System.String");
        dc.DefaultValue = "";
        dc.ExtendedProperties["Editable"] = false;
        newTable.Columns.Add(dc);

        dc = new DataColumn();
        dc.ColumnName = "SoNo";
        dc.DataType = System.Type.GetType("System.String");
        dc.DefaultValue = "";
        dc.ExtendedProperties["Editable"] = false;
        newTable.Columns.Add(dc);

        for (int r = 0; r < Tbdate.Rows.Count; r++)
        {
            dc = new DataColumn();
            dc.ColumnName = DateTime.Parse(Tbdate.Rows[r]["DutyDate"].ToString()).ToString("dd-MMM-yyyy");
            dc.DataType = System.Type.GetType("System.Boolean");
            dc.ExtendedProperties["CheckBox"] = true;
            dc.DefaultValue = false;
            newTable.Columns.Add(dc);
        }
        for (int c = 0; c < TbVehicle.Rows.Count; c++)
        {
            DataRow row = newTable.NewRow();
            row[Resources.Resource.VehicleNumber] = TbVehicle.Rows[c]["VehicleNumber"].ToString();
            row[Resources.Resource.VehicleDesc] = TbVehicle.Rows[c]["VehicleDesc"].ToString();
            row["SoNo"] = TbVehicle.Rows[c]["SoNo"].ToString();
            newTable.Rows.Add(row);
        }
        string strVehicleNumber = string.Empty;
        for (int f = 0; f < TbVehicleOff.Rows.Count; f++)
        {
            if (TbVehicleOff.Rows[f]["IsVehicleOff"].ToString() == "1")
            {
                strVehicleNumber = TbVehicleOff.Rows[f]["VehicleNumber"].ToString();
                for (int g = 0; g < newTable.Rows.Count; g++)
                {
                    if (strVehicleNumber == newTable.Rows[g][Resources.Resource.VehicleNumber].ToString())
                    {
                        newTable.Rows[g][DateTime.Parse(TbVehicleOff.Rows[f]["DutyDate"].ToString()).ToString("dd-MMM-yyyy")] = true; // bool.Parse(TbweekOff.Rows[f]["IsWeekOff"].ToString());
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
    /// Handles the RowDataBound event of the gvVehicle control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvVehicle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvVehicle control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvVehicle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvVehicle.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvVehicle.PageIndex = gvVehicle.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvVehicle control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvVehicle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridViewRow gvrPager = gvVehicle.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvVehicle.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvVehicle.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvVehicle.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvVehicle.PageIndex = e.NewPageIndex;
        }
       // SaveData();
    }
    /// <summary>
    /// Handles the DataBound event of the gvVehicle control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvVehicle_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvVehicle.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvVehicle.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvVehicle.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvVehicle.PageCount.ToString();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow row = gvVehicle.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvVehicle.PageIndex = ddlPages.SelectedIndex;
        //SaveData();
    }
    #endregion

    #region Page Buttons events
    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (GetGreaterDate(DateTime.Parse(txtToDate.Text), DateTime.Parse(txtFromDate.Text)))
        {
            gvVehicle.PageIndex = 0;
            FillgvVehicle();
            gvVehicle.Visible = true;
            btnAdd.Visible = true;
        }
        else
        {
            lblErrorMsg.Text = "From Date Cannot be Greater than to Date";
            gvVehicle.Visible = false;
            btnAdd.Visible = false;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnSearchWeekOff control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearchWeekOff_Click(object sender, EventArgs e)
    {
        gvVehicle.PageIndex = 0;
        FillgvVehicle();
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtEmpNumber.Text = "";
        txtEmpFirstName.Text = "";
        txtEmpLastName.Text = "";
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
        if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
        {
            DataTable DTableSave = new DataTable();
            DataColumn dc = new DataColumn();

            dc.ColumnName = "Vehicle Number";
            dc.DataType = System.Type.GetType("System.String");
            dc.DefaultValue = "";
            DTableSave.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "DutyDate";
            dc.DataType = System.Type.GetType("System.String");
            dc.DefaultValue = "";
            DTableSave.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "IsVehicleOff";
            dc.DataType = System.Type.GetType("System.Boolean");
            dc.DefaultValue = false;
            DTableSave.Columns.Add(dc);

            //dc = new DataColumn();
            //dc.ColumnName = "SoNo";
            //dc.DataType = System.Type.GetType("System.Boolean");
            //dc.DefaultValue = false;
            //DTableSave.Columns.Add(dc);

            for (int g = 0; g < gvVehicle.Rows.Count; g++)
            {
                for (int i = 0; i < gvVehicle.Rows[g].Cells.Count; i++)
                {
                    for (int j = 0; j < gvVehicle.Rows[g].Cells[i].Controls.Count; j++)
                    {
                        if (gvVehicle.Rows[g].Cells[i].Controls[j].GetType() == typeof(CheckBox))
                        {
                            CheckBox cb = (CheckBox)gvVehicle.Rows[g].Cells[i].Controls[j];
                            Label lblVehicleNumber = (Label)gvVehicle.Rows[g].Cells[0].Controls[0];
                            //Label lblSoNo = (Label)gvVehicle.Rows[g].Cells[1].Controls[0];
                            if (cb != null && lblVehicleNumber != null)
                            {
                                DataRow row = DTableSave.NewRow();
                                row["Vehicle Number"] = lblVehicleNumber.Text;
                                row["DutyDate"] = cb.ToolTip;
                                row["IsVehicleOff"] = cb.Checked;
                               // row["SoNo"] = lblSoNo.Text;
                                DTableSave.Rows.Add(row);
                            }
                        }
                    }
                }
            }


            BL.Roster objRoster = new BL.Roster();
            DataSet ds = new DataSet();
            ds = objRoster.VehicleSchedulingSave(BaseLocationAutoID, DTableSave, BaseUserID);
            FillgvVehicle();
        }
    }
    #endregion
}
