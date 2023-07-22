// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SkillMatchMismatch.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Class Transactions_SkillMatchMismatch.
/// </summary>
public partial class Transactions_SkillMatchMismatch : BasePage
{

    /// <summary>
    /// The index
    /// </summary>
    static int Index;
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            //System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            //javaScript.Append("<script type='text/javascript'>");
            //javaScript.Append("window.document.body.onload = function ()");
            //javaScript.Append("{\n");
            //javaScript.Append("PageTitle('" + Resources.Resource.SkillMatchMismatch + "');");
            //javaScript.Append("};\n");
            //javaScript.Append("// -->\n");
            //javaScript.Append("</script>");
            //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            hfSelectedGridPageCount.Value = "1"; // Set The First Page Number
            FormatDataSet("1", "", gvSkillMatchMismatch.PageSize);
        }
    }

    /// <summary>
    /// Formats the data set.
    /// </summary>
    /// <param name="PageCount">The page count.</param>
    /// <param name="SearchEmployeeNumber">The search employee number.</param>
    /// <param name="PageSize">Size of the page.</param>
    private void FormatDataSet(string PageCount, string SearchEmployeeNumber, int PageSize)
    {
        DataTable dtEmployee = new DataTable();
        DataSet dsSkills = new DataSet();
        DataTable dtSkillCode = new DataTable();

        BL.Roster objRoster = new BL.Roster();
        string asmtCode = Request.QueryString["AsmtCode"].ToString();
        string postCode = Request.QueryString["PostCode"].ToString();
        string fromdate = Request.QueryString["FromDate"].ToString();
        string toDate = Request.QueryString["ToDate"].ToString();
        string areaID = Request.QueryString["AreaID"].ToString();
        if (asmtCode != "" && postCode != "" && fromdate != "" && toDate != "" && areaID != "")
        {
            dsSkills = objRoster.ScheduleEmployeeWiseSkillsMatchMismatchGet(asmtCode, postCode, BaseLocationAutoID, fromdate, toDate, areaID, BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), PageCount, PageSize.ToString(), SearchEmployeeNumber);
        }
        else
        {
            return;
        }

        dtEmployee = dsSkills.Tables[0].Copy();
        dtSkillCode = dsSkills.Tables[2].Copy();

        var distinctRows = (from DataRow dRow in dtSkillCode.Rows
                            select new { colMandatoryStatus = dRow["MandatoryStatus"] }).Distinct();

        DataView dvEmployeeSkills = new DataView(dsSkills.Tables[1]);
        DataView dvSkillCode = new DataView(dtSkillCode);

        int newColumnStatus = 0;
        if (gvSkillMatchMismatch.Columns.Count > 0)
        {
            gvSkillMatchMismatch.Columns.Clear();
        }
        BoundField empField = new BoundField();
        empField.HeaderText = Resources.Resource.EmployeeNumber;
        empField.DataField = "EmployeeNumber";
        empField.HeaderStyle.CssClass = "cssLable";
        gvSkillMatchMismatch.Columns.Add(empField);
        foreach (var row in distinctRows)
        {
            string skillType = string.Empty;
            skillType = row.colMandatoryStatus.ToString();
            dvSkillCode.RowFilter = "[MandatoryStatus]='" + (skillType.ToString()) + "'";
            if (skillType == "M")
            {
                DataColumn strMandatoryColNo = new DataColumn("Red");
                dtEmployee.Columns.Add(strMandatoryColNo);
            }
            if (skillType == "R")
            {
                DataColumn strRecommendedColNo = new DataColumn("Green");
                dtEmployee.Columns.Add(strRecommendedColNo);
            }
            if (skillType == "I")
            {
                DataColumn strInformativeColNo = new DataColumn("Yellow");
                dtEmployee.Columns.Add(strInformativeColNo);
            }
            foreach (DataRowView drV in dvSkillCode)
            {
                DataRow drRow = dtEmployee.NewRow();
                string columnName = drV["ConstraintDesc"].ToString();
                DataColumn strColNo = new DataColumn(columnName);
                dtEmployee.Columns.Add(strColNo);
                ImageField imField = new ImageField();
                if (skillType == "M")
                {
                    imField.HeaderStyle.CssClass = "MandatoryHeaderStyle";
                }
                if (skillType == "R")
                {
                    imField.HeaderStyle.CssClass = "RecommendedHeaderStyle";
                }
                if (skillType == "I")
                {
                    imField.HeaderStyle.CssClass = "InformativeHeaderStyle";
                }

                imField.DataImageUrlField = columnName;
                imField.HeaderText = columnName;
                gvSkillMatchMismatch.Columns.Add(imField);

            }

            for (int i = 0; i < dtEmployee.Rows.Count; i++)
            {
                dvEmployeeSkills.RowFilter = "[EmployeeNumber]='" + (dtEmployee.Rows[i]["EmployeeNumber"].ToString()) + "' AND" + "[IsMandatory]='" + skillType + "'";
                foreach (DataRowView drVEmployee in dvEmployeeSkills)
                {
                    // dtEmployee.Rows[i][drVEmployee["ConstraintDesc"].ToString()] = drVEmployee["Condition"].ToString();
                    if (drVEmployee["Condition"].ToString().ToLower() == "FALSE".ToLower())
                    {
                        dtEmployee.Rows[i][drVEmployee["ConstraintDesc"].ToString()] = "~/Images/untick.png"; //Specify image URL   
                    }
                    else
                    {
                        dtEmployee.Rows[i][drVEmployee["ConstraintDesc"].ToString()] = "~/Images/Tick.png"; //Specify image URL   
                    }
                }

            }


        }
        hfGridPageCount.Value = dsSkills.Tables[3].Rows[0]["TotalRecords"].ToString();


        gvSkillMatchMismatch.DataSource = dtEmployee;
        gvSkillMatchMismatch.DataBind();
        if (gvSkillMatchMismatch.Columns.Count < 2)
        {
            gvSkillMatchMismatch.Visible = false;
        }
        else
        {
            gvSkillMatchMismatch.Visible = true;
        }

    }
    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FormatDataSet("1", txtSearch.Text, gvSkillMatchMismatch.PageSize);
    }
    /// <summary>
    /// Handles the Click event of the btnViewAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        FormatDataSet("1", "", gvSkillMatchMismatch.PageSize);
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvSkillMatchMismatch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSkillMatchMismatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    /// <summary>
    /// Handles the RowCommand event of the gvSkillMatchMismatch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvSkillMatchMismatch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvSkillMatchMismatch.PageIndex = 0;
                hfSelectedGridPageCount.Value = "0";
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvSkillMatchMismatch.PageIndex = int.Parse(hfGridPageCount.Value);
                hfSelectedGridPageCount.Value = hfGridPageCount.Value;
                break;
        }
    }
    /// <summary>
    /// Handles the DataBound event of the gvSkillMatchMismatch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvSkillMatchMismatch_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvSkillMatchMismatch.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        else
        {
            if (row != null && row.Visible == false)
                row.Visible = true;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        int totalPageCount;
        if (ddlPages != null)
        {
            if (hfGridPageCount.Value == "0")
            {
                totalPageCount = 1;
            }
            else
            {
                totalPageCount = int.Parse(hfGridPageCount.Value);
            }
            for (int i = 0; i < totalPageCount; i++)
            {
                int intPageNumber = i + 1;
                var lstItem = new ListItem(intPageNumber.ToString());
                if (intPageNumber == int.Parse(hfSelectedGridPageCount.Value))
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = hfGridPageCount.Value.ToString();
        }

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvSkillMatchMismatch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvSkillMatchMismatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvSkillMatchMismatch.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)gvrPager.Cells[0].FindControl("lblPageCount");
        int currentIndex = int.Parse(ddlPages.SelectedItem.Text);
        if (Index == 1)
        {
            if (currentIndex > 0)
            {
                hfSelectedGridPageCount.Value = (currentIndex - 1).ToString();
                gvSkillMatchMismatch.PageIndex = (currentIndex - 1);
            }
            else
            {
                hfSelectedGridPageCount.Value = (currentIndex).ToString();
                gvSkillMatchMismatch.PageIndex = (currentIndex);
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            if (lblPageCount.Text != ddlPages.SelectedItem.Text)
            {
                hfSelectedGridPageCount.Value = (currentIndex + 1).ToString();
                gvSkillMatchMismatch.PageIndex = (currentIndex + 1);
            }
            else
            {
                hfSelectedGridPageCount.Value = (lblPageCount.Text).ToString();
                gvSkillMatchMismatch.PageIndex = int.Parse(lblPageCount.Text);
            }
            Index = -1;
        }
        else
        {
            gvSkillMatchMismatch.PageIndex = int.Parse(hfSelectedGridPageCount.Value);
        }
        FormatDataSet(gvSkillMatchMismatch.PageIndex.ToString(), "", gvSkillMatchMismatch.PageSize);

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvSkillMatchMismatch.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvSkillMatchMismatch.PageIndex = int.Parse(ddlPages.SelectedItem.Text);
        hfSelectedGridPageCount.Value = ddlPages.SelectedItem.Text;
        FormatDataSet(ddlPages.SelectedItem.Text, "", gvSkillMatchMismatch.PageSize);




    }
}