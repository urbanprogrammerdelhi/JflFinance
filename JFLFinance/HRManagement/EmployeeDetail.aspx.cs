// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeDetail.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using System.Globalization;

/// <summary>
/// Partial Class for HRManagement_EmployeeDetail page.
/// </summary>
public partial class HRManagement_EmployeeDetail : BasePage//System.Web.UI.Page
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
    /// <summary>
    /// My data table
    /// </summary>
    static DataTable myDataTable;

    #region PageLoad
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EmployeeDetail + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillddlAreaID();
                myDataTable = new DataTable();
                DataColumn myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "EmployeeNumber";
                myDataTable.Columns.Add(myDataColumn);
                FillgvEmployeeDetail(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString());
                FillddlSearchBy();
                txtSearch.Visible = true;
                txtAsOnDate.Visible = false;
                HLAsOnDate.Visible = false;

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }

    }
    #endregion

    #region control events
    /// <summary>
    /// click event of adding new employee
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbAddNew_Click(object sender, EventArgs e)
    {
        string Status = Resources.Resource.AddNew;
        Response.Redirect("EmployeeMaster.aspx?strStatus=" + Status);
    }
    
    /// <summary>
    /// click event of employeenumber label
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblEmployeeNumber_Click(object sender, EventArgs e)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        string Status = Resources.Resource.Update;
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblEmployeeNumber = (LinkButton)gvEmployeeDetail.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        if (IsModifyAccess == false)
        {
            string strStatus = "NM";
            Response.Redirect("EmployeeMaster.aspx?strStatus=" + Status + "&strEmployeeNumber=" + lblEmployeeNumber.Text + "&strStatus1=" + strStatus);
        }
        else
        {
            Response.Redirect("EmployeeMaster.aspx?strStatus=" + Status + "&strEmployeeNumber=" + lblEmployeeNumber.Text);
        }
    }
    /// <summary>
    /// click event of employeetermination
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbTerminateEmployee_Click(object sender, EventArgs e)
    {
        ImageButton objImageButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objImageButton.NamingContainer;
        LinkButton lblEmployeeNumber = (LinkButton)gvEmployeeDetail.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
        if (lblPageHdrTitle != null)
        {
            lblPageHdrTitle.Text = Resources.Resource.EmployeeTermination;
        }
        Response.Redirect("EmployeeTermination.aspx?strEmployeeNumber=" + lblEmployeeNumber.Text);
    }
    /// <summary>
    /// click event of rehire
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbReHire_Click(object sender, EventArgs e)
    {
        Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
        if (lblPageHdrTitle != null)
        {
            lblPageHdrTitle.Text = Resources.Resource.EmployeeReHire;
        }
        Response.Redirect("../HrManagement/EmployeeReHire.aspx");
    }

    /// <summary>
    /// Index change event of pages drop down
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvEmployeeDetail.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvEmployeeDetail.PageIndex = ddlPages.SelectedIndex;

        if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
        {
            if (txtSearchDate.Text != "")
            {
                SearchAction();
            }
            else
            {
                FillgvEmployeeDetail(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString());
            }
        }
        else
        {
            if (txtSearch.Text != "")
            {
                SearchAction();
            }
            else
            {
                FillgvEmployeeDetail(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString());
            }
        }
    }
    #endregion

    #region function related to grid
    /// <summary>
    /// Fill employee detail grid
    /// </summary>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strAreaID">The STR area ID.</param>
    private void FillgvEmployeeDetail(string strLocationAutoID, string strAreaID)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        DataTable dtEmployeeDetail = new DataTable();
        var selectedDate = string.Empty;
        if (ddlEmployeeGetType.SelectedValue == "A")
        {
            selectedDate = txtAsOnDate.Text.ToString();
        }
        else
        {
            selectedDate = "01/01/1900";
        }

        ds = objHRManagement.EmployeeDetailGet(strLocationAutoID, strAreaID.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), selectedDate, selectedDate);
        dtEmployeeDetail = ds.Tables[0];

        if (ds != null && ds.Tables.Count > 0 && dtEmployeeDetail.Rows.Count > 0)
        {
            gvEmployeeDetail.DataSource = dtEmployeeDetail;
            gvEmployeeDetail.DataBind();
        }
        else
        {
            dtEmployeeDetail.Rows.Add(dtEmployeeDetail.NewRow());
            gvEmployeeDetail.DataSource = dtEmployeeDetail;
            gvEmployeeDetail.DataBind();
            int TotalColumns = gvEmployeeDetail.Rows[0].Cells.Count;
            gvEmployeeDetail.Rows[0].Cells.Clear();
            gvEmployeeDetail.Rows[0].Cells.Add(new TableCell());
            gvEmployeeDetail.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvEmployeeDetail.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    /// <summary>
    /// Navigation event of the Grid
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvEmployeeDetail.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvEmployeeDetail.PageIndex = gvEmployeeDetail.PageCount;
                break;
        }
    }
    /// <summary>
    /// Databound event of Employee Grid
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDetail_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvEmployeeDetail.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvEmployeeDetail.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvEmployeeDetail.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvEmployeeDetail.PageCount.ToString();
        }

    }
/// <summary>
    /// Rowbound event of employee Grid
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                lbAddNew.Visible = false;
                lbReHire.Visible = false;
                gvEmployeeDetail.Columns[6].Visible = false;
            }

            if (IsWriteAccess == true)
            {
                lbReHire.Visible = true;
                lbAddNew.Visible = true;
                gvEmployeeDetail.Columns[6].Visible = false;
            }
            if (IsModifyAccess == true)
            {
                lbReHire.Visible = false;
                lbAddNew.Visible = false;
                gvEmployeeDetail.Columns[6].Visible = true;
            }
            if (IsWriteAccess == true && IsModifyAccess == true)
            {
                lbReHire.Visible = true;
                lbAddNew.Visible = true;
                gvEmployeeDetail.Columns[6].Visible = true;
            }

            if (ddlEmployeeGetType.SelectedValue == "A")
            {
                CheckBox chkTerminateEmployee = (CheckBox)e.Row.FindControl("chkTerminateEmployee");
                chkTerminateEmployee.Enabled = false;
            }

            if (myDataTable != null && myDataTable.Rows.Count > 0)
            {
                LinkButton lblEmployeeNumber = (LinkButton)e.Row.FindControl("lblEmployeeNumber");
                DataRow[] myDataRow = myDataTable.Select("EmployeeNumber=" + lblEmployeeNumber.Text);
                if (myDataRow.Length > 0)
                {
                    CheckBox chkTerminateEmployee = (CheckBox)e.Row.FindControl("chkTerminateEmployee");
                    chkTerminateEmployee.Checked = true;
                }

            }


        }

    }
    /// <summary>
    /// Page index change event of Employee Grid
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvEmployeeDetail.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvEmployeeDetail.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvEmployeeDetail.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvEmployeeDetail.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvEmployeeDetail.PageIndex = e.NewPageIndex;
        }
        gvEmployeeDetail.EditIndex = -1;


        if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
        {
            if (txtSearchDate.Text != "")
            {
                SearchAction();
            }
            else
            {
                FillgvEmployeeDetail(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString());
            }
        }
        else
        {
            if (txtSearch.Text != "")
            {
                SearchAction();
            }
            else
            {
                FillgvEmployeeDetail(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString());
            }
        }
    }


    #endregion

    #region Function Related to Search In Gridview LOI received
    /// <summary>
    /// Index change event of searchby drop down
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeTextBoxBasedOnddlSearchBySelectedIndexChanged();
        if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
        {
            txtSearchDate.Visible = true;
            imgSearchGrid.Visible = true;
            txtSearch.Visible = false;
            txtSearchDate.Attributes.Add("readonly", "readonly");
            imgSearchGrid.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSearchDate.ClientID.ToString() + "');";
        }
        else
        {
            txtSearch.Visible = true;
            txtSearchDate.Visible = false;
            imgSearchGrid.Visible = false;
        }
        txtSearch.Text = "";
        txtSearchDate.Text = "";
    }
    /// <summary>
    /// Change of text event based on inex change of searchby drop down
    /// </summary>
    private void ChangeTextBoxBasedOnddlSearchBySelectedIndexChanged()
    {
        if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
        {
            txtSearchDate.Visible = true;
            imgSearchGrid.Visible = true;
            txtSearch.Visible = false;
            txtSearchDate.Attributes.Add("readonly", "readonly");
            imgSearchGrid.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSearchDate.ClientID.ToString() + "');";
        }
        else
        {
            txtSearch.Visible = true;
            txtSearchDate.Visible = false;
            imgSearchGrid.Visible = false;
        }
    }
    /// <summary>
    /// click event of search button
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (txtSearch.Text != "" || txtSearchDate.Text != "")
        {
            btnViewAll.Visible = true;
        }

        if (txtSearchDate.Text != "" || txtSearch.Text != "")
        {
            if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
            {
                hfSearchText.Value = txtSearchDate.Text;
            }
            else
            {
                hfSearchText.Value = txtSearch.Text.Trim();
            }
            SearchAction();
        }
    }
    /// <summary>
    /// Function To Search In grid view LOI Received Based on ddlSearchBy and txtSearch Value
    /// </summary>
    private void SearchAction()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataTable dtAddEmpDetail = new DataTable();
        var selectedDate = string.Empty;
        if (ddlEmployeeGetType.SelectedValue == "A")
        {
            selectedDate = txtAsOnDate.Text.ToString();
        }
        else
        {
         
            selectedDate = "01/01/1900";
        }
        dtAddEmpDetail = objHRManagement.EmployeeDetailGet(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), selectedDate, selectedDate).Tables[0];
        dtAddEmpDetail.Columns["EmployeeNumber"].ColumnName = Resources.Resource.EmployeeNumber;
        dtAddEmpDetail.Columns["FirstName"].ColumnName = Resources.Resource.FirstName;
        dtAddEmpDetail.Columns["LastName"].ColumnName = Resources.Resource.LastName;
        dtAddEmpDetail.Columns["DesignationDesc"].ColumnName = Resources.Resource.DesignationDescription;
        dtAddEmpDetail.Columns["CategoryDesc"].ColumnName = Resources.Resource.CategoryDescription;
        dtAddEmpDetail.Columns["DateOfJoining"].ColumnName = Resources.Resource.JoiningDate;
        dtAddEmpDetail.Columns["EmpStatus"].ColumnName = Resources.Resource.Status;
        DataTable dt = new DataTable();
        DataView dv = new DataView(dtAddEmpDetail);
        if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
        {
            string value = DateFormat(hfSearchText.Value);
            dv.RowFilter = string.Format(CultureInfo.InvariantCulture.DateTimeFormat, "[{0}] = '{1}'", ddlSearchBy.SelectedValue.ToString(), value);
        }
        else
        {
            hfSearchText.Value = BL.Common.ValidateSpecialCharacter(hfSearchText.Value);
            dv.RowFilter = string.Format("[{0}] like '{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);
        }

        dt = dv.ToTable();
        dt.Columns[Resources.Resource.EmployeeNumber].ColumnName = "EmployeeNumber";
        dt.Columns[Resources.Resource.FirstName].ColumnName = "FirstName";
        dt.Columns[Resources.Resource.LastName].ColumnName = "LastName";
        dt.Columns[Resources.Resource.DesignationDescription].ColumnName = "DesignationDesc";
        dt.Columns[Resources.Resource.CategoryDescription].ColumnName = "CategoryDesc";
        dt.Columns[Resources.Resource.JoiningDate].ColumnName = "DateOfJoining";
        dt.Columns[Resources.Resource.Status].ColumnName = "EmpStatus";
        gvEmployeeDetail.DataSource = dt;
        gvEmployeeDetail.DataBind();
    }
    /// <summary>
    /// click event of view all button
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        txtSearchDate.Text = "";
        gvEmployeeDetail.PageIndex = 0;
        FillgvEmployeeDetail(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString());
    }
    /// <summary>
    /// Fills the searchby drop down list
    /// </summary>
    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        arr.Add(gvEmployeeDetail.Columns[0]);
        arr.Add(gvEmployeeDetail.Columns[1]);
        arr.Add(gvEmployeeDetail.Columns[2]);
        arr.Add(gvEmployeeDetail.Columns[3]);
        arr.Add(gvEmployeeDetail.Columns[4]);
        arr.Add(gvEmployeeDetail.Columns[5]);
        arr.Add(gvEmployeeDetail.Columns[7]);
        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();

    }
    #endregion

    //code added by Manish for bulk deletion Dated 9-mar-2010
    #region Function related to bulk terminations
    /// <summary>
    /// change event to check the termination of employee
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void OnCheckedChanged_chkTerminateEmployee(object sender, EventArgs e)
    {


        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.NamingContainer;
        CheckBox chkTerminateEmployee = (CheckBox)gvEmployeeDetail.Rows[row.RowIndex].FindControl("chkTerminateEmployee");
        LinkButton lblEmployeeNumber = (LinkButton)gvEmployeeDetail.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        if (chkTerminateEmployee.Checked == true && myDataTable != null)
        {
            DataRow myDataRow = myDataTable.NewRow();
            myDataRow["EmployeeNumber"] = lblEmployeeNumber.Text;
            myDataTable.Rows.Add(myDataRow);
            myDataTable.AcceptChanges();

        }
        else if (myDataTable != null)
        {
            DataRow[] myDataRow = myDataTable.Select("EmployeeNumber=" + lblEmployeeNumber.Text);
            myDataTable.Rows.Remove(myDataRow[0]);
        }


    }
    /// <summary>
    /// click event of button to bulk terminate employees
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBulkTermination_Click(object sender, EventArgs e)
    {
        if (myDataTable != null && myDataTable.Rows.Count > 0)
        {
            Panel6.Visible = true;
            FillTerminationReason();
            ModalPopupExtender2.Show();
        }

    }
    /// <summary>
    /// click event of apply button
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnApply_Click(object sender, EventArgs e)
    {
        lblErrorMsg1.Text = "";
        lblErrorMsg.Text = "";
        FillErrorMessageGrid();
    }

    /// <summary>
    /// Fills error messages
    /// </summary>
    protected void FillErrorMessageGrid()
    {
        BL.HRManagement objHrManagement = new BL.HRManagement();
        DataSet ds = new DataSet();

        ds = objHrManagement.TerminateBulkEmployees(myDataTable, ddlReason.SelectedItem.Text.ToString(), ddlTerminationReason.SelectedItem.Text.ToString(), DateTime.Parse(DateFormat(txtResignationDate.Text)), txtRemarks.Text, bool.Parse(ddlSuitable4ReHire.SelectedValue.ToString()), BaseUserID);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = Resources.Resource.TransactionDateCannotBeGreaterThanTerminationDate;
            for (int i = 0; i < myDataTable.Rows.Count; i++)
            {
                DataRow[] myDataRow = ds.Tables[0].Select("EmployeeNumber='" + myDataTable.Rows[i]["EmployeeNumber"].ToString() + "'");
                if (myDataRow == null)
                {
                    myDataTable.Rows[i].Delete();
                    myDataTable.AcceptChanges();
                }
            }

            gvErrorMessage.DataSource = ds.Tables[0];
            gvErrorMessage.DataBind();
        }
        else
        {
            gvErrorMessage.DataSource = null;
            gvErrorMessage.DataBind();
            lblErrorMsg.Text = Resources.Resource.Terminated;
        }

    }
    /// <summary>
    /// Fills Error Messages
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvErrorMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvErrorMessage.PageIndex = e.NewPageIndex;
        gvErrorMessage.EditIndex = -1;
        FillErrorMessageGrid();
    }
    /// <summary>
    /// click event of action button
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAction_OnClick(object sender, EventArgs e)
    {

        LinkButton btnAction = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btnAction.NamingContainer;

        HiddenField msgId = (HiddenField)gvErrorMessage.Rows[row.RowIndex].FindControl("msgId");
        Label lblEmployeeNumber_msg = (Label)gvErrorMessage.Rows[row.RowIndex].FindControl("lblEmployeeNumber_msg");
        BL.Roster objRost = new BL.Roster();
        DataSet dsRota = new DataSet();

        lblErrorMsg1.Text = "";

        if (msgId.Value == "101" || msgId.Value == "102")
        {
            dsRota = objRost.RotaBulkDeletion(lblEmployeeNumber_msg.Text, ddlReason.SelectedItem.Text.ToString(), ddlTerminationReason.SelectedItem.Text.ToString(), DateTime.Parse(DateFormat(txtResignationDate.Text)), txtRemarks.Text, bool.Parse(ddlSuitable4ReHire.SelectedValue.ToString()), BaseUserID);
            if (dsRota != null && dsRota.Tables.Count > 0 && dsRota.Tables[0].Rows.Count > 0 && dsRota.Tables[0].Rows[0][0] != "1")
            {
                lblErrorMsg1.Text = Resources.Resource.AuthorizedRotaCannotbeDeleted;
            }
            else
            {
                lblErrorMsg1.Text = "";
                FillErrorMessageGrid();
            }
        }
    }
    /// <summary>
    /// index change event of reason drop down list
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTerminationReason();
    }
    /// <summary>
    /// click event of close button
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClose_Click(object sender, EventArgs e)
    {
        ModalPopupExtender2.Hide();
        Response.Redirect("EmployeeDetail.aspx");
    }
    /// <summary>
    /// Fills terminationreason drop down list
    /// </summary>
    private void FillTerminationReason()
    {
        if (ddlReason.SelectedValue.ToString().Equals(Resources.Resource.Employer))
        {

            ArrayList li = new ArrayList();
            li.Add(Resources.Resource.Resigned);
            li.Add(Resources.Resource.Retired);
            li.Add(Resources.Resource.Terminated);
            ddlTerminationReason.DataSource = li;
            ddlTerminationReason.DataBind();

        }
        else
        {
            ArrayList li = new ArrayList();
            li.Add(Resources.Resource.BetterOpportunities);
            li.Add(Resources.Resource.HealthReason);
            li.Add(Resources.Resource.PersonalReason);
            ddlTerminationReason.DataSource = li;
            ddlTerminationReason.DataBind();
        }
    }
    #endregion

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvEmployeeDetail(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString());

    }
    /// <summary>
    /// Fills Area DDL
    /// </summary>
    protected void FillddlAreaID()
    {
        ListItem li = new ListItem();

        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();
        dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {

            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();

            li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";

            ddlAreaID.Items.Insert(0, li);

        }
        else
        {
            li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlAreaID.Items.Add(li);
        }

    }
    /// <summary>
    /// Index change event of EmployeeGetType drop down list
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeGetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployeeGetType.SelectedValue == "A")
        {
            txtAsOnDate.Visible = true;
            HLAsOnDate.Visible = true;
            txtAsOnDate.Text = DateFormat(DateTime.Now.ToString());
        }
        else
        {
            txtAsOnDate.Visible = false;
            HLAsOnDate.Visible = false;
        }
    }
    /// <summary>
    /// Click event of GetEmployeeBasedOnStatus
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGetEmployeeBasedOnStatus_Click(object sender, EventArgs e)
    {
        FillgvEmployeeDetail(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString());
    }
}
