// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="commonSearch.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;


/// <summary>
/// Class Search_commonSearch.
/// </summary>
public partial class Search_commonSearch : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// The ds search result
    /// </summary>
    DataSet dsSearchResult = new DataSet();

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        generateInterface();

    }

    /// <summary>
    /// Generates the interface.
    /// </summary>
    protected void generateInterface()
    {

        string strLingual;

        if (!string.IsNullOrEmpty(BaseLanguageCode) && BaseLanguageCode != "en-US")
        {
            strLingual = "." + BaseLanguageCode.Substring(0, 2);
        }
        else
        {
            strLingual = "";
        }
        string strSeachId = Request.QueryString["SearchId"];
        string strOutputFields = "";

        BL.Search objSearch = new BL.Search();
        DataSet dsCCH = new DataSet();
        dsCCH = objSearch.CommonSearchFormatGet(strSeachId);

        if (dsCCH != null && dsCCH.Tables.Count > 0 && dsCCH.Tables[0].Rows.Count > 0)
        {
            txtObjectName.Value = dsCCH.Tables[0].Rows[0]["objectName"].ToString();
            txtReturnColumn.Value = dsCCH.Tables[0].Rows[0]["ReturnFld"].ToString();
            txtReturnColumn2.Value = dsCCH.Tables[0].Rows[0]["ReturnFld2"].ToString();

            for (int i = 0; i < dsCCH.Tables[0].Rows.Count; i++)
            {
                if (dsCCH.Tables[0].Rows[i]["OutputFld"].ToString() == "True")
                {
                    if (strOutputFields != "")
                    {
                        strOutputFields = strOutputFields + "," + dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                    }
                    else { strOutputFields = dsCCH.Tables[0].Rows[i]["FldName"].ToString(); }

                }
                if (dsCCH.Tables[0].Rows[i]["InputFld"].ToString() == "True")
                {
                    Label lbl1 = new Label();
                    try
                    {
                        lbl1.ID = "lbl" + dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                        lbl1.Text = Resources.Resource.ResourceManager.GetString((string)dsCCH.Tables[0].Rows[i]["FldName"].ToString());
                        lbl1.Width = 150;
                        if (lbl1.Text == "")
                        {
                            lbl1.Text = dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                        }
                        PHSearch.Controls.Add(lbl1);
                    }
                    catch (Exception)
                    {
                        lbl1.ID = "lbl" + dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                        lbl1.Text = dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                        lbl1.Width = 150;
                        PHSearch.Controls.Add(lbl1);
                    }
                    if (dsCCH.Tables[0].Rows[i]["FldDataType"].ToString() != "System.Boolean")
                    {
                           
                        DropDownList ddl1 = new DropDownList();

                        ListItem L3 = new ListItem();
                        L3.Text = Resources.Resource.Like;
                        L3.Value = "Like";

                        ddl1.ID = "ddl" + dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                        ddl1.Width = 50;
                        ddl1.Items.Add("=");
                        ddl1.Items.Add(L3);
                        ddl1.Items.Add("<");
                        ddl1.Items.Add("<=");
                        ddl1.Items.Add(">");
                        ddl1.Items.Add(">=");
                        PHSearch.Controls.Add(ddl1);

                        TextBox txtbox1 = new TextBox();
                        txtbox1.ID = "txt" + dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                        PHSearch.Controls.Add(txtbox1);
                       

                    }
                    else
                    {
                        DropDownList ddl2 = new DropDownList();
                        ddl2.ID = "ddl" + dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                        ddl2.Width = 50;
                        ddl2.Items.Add("=");
                        PHSearch.Controls.Add(ddl2);
                        ListItem L1 = new ListItem();
                        ListItem L2 = new ListItem();
                        L1.Text = Resources.Resource.Yes;
                        L1.Value = "Yes";

                        L2.Text = Resources.Resource.No;
                        L2.Value = "No";  

                        DropDownList ddl3 = new DropDownList();
                        ddl3.ID = "txt" + dsCCH.Tables[0].Rows[i]["FldName"].ToString();
                        ddl3.Width = 50;
                        ddl3.Items.Add("");
                        ddl3.Items.Add(L1);
                        ddl3.Items.Add(L2);
                        PHSearch.Controls.Add(ddl3);

                    }

                    Literal Literal1 = new Literal();
                    Literal1.Text = "<Br>";
                    PHSearch.Controls.Add(Literal1);
                }

            }
        }
        txtOutputFields.Value = strOutputFields;

    }

    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e) // get result on base of selected parameters
    {
        FillgvSearchResult();

    }
    /// <summary>
    /// Fillgvs the search result.
    /// </summary>
    private void FillgvSearchResult()
    {
        string strCompanyCode = Request.QueryString["company"];
        string strHrLocationCode = Request.QueryString["HrLocation"];
        string strLocationCode = "";
        if (Request.QueryString["Location"] != null)
        {
            strLocationCode = Request.QueryString["Location"];
        }
        string strToLocationCode = "";
        if (Request.QueryString["ToLocation"] != null)
        {
            strToLocationCode = Request.QueryString["ToLocation"];
        }
        string strControlId = Request.QueryString["ControlId"];
        string strControlId1 = "";
        if (Request.QueryString["ControlId1"] != null)
        {
            strControlId1 = Request.QueryString["ControlId1"];
        }

        int intParamCount = PHSearch.Controls.Count;
        string strInputFields = "";
        string strSyntex1 = "";
        string strSyntex2 = "";
        string strInputVal = "";

        for (int i = 0; i < intParamCount; i++)
        {    
            if (PHSearch.Controls[i].ClientID.ToString().Substring(0, 3) == "txt")
            {

                if (PHSearch.Controls[i].GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    TextBox txtInput = (TextBox)PHSearch.FindControl(PHSearch.Controls[i].ID);
                    if (PHSearch.Controls[i].ID == "txtLocationCode" && txtInput.Text =="")
                    {
                        txtInput.Text = BaseLocationCode;
                    }
                    strInputVal = BL.Common.ValidateSpecialCharacter(txtInput.Text);
                }
                else if (PHSearch.Controls[i].GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    DropDownList txtInput = (DropDownList)PHSearch.FindControl(PHSearch.Controls[i].ID);
                    strInputVal = BL.Common.ValidateSpecialCharacter(txtInput.SelectedValue.ToString());
                }

                if (strInputVal != "")
                {
                    DropDownList ddlOperator = (DropDownList)PHSearch.FindControl(PHSearch.Controls[i - 1].ID);

                    if (ddlOperator.SelectedValue.ToString() == "Like" )
                    {
                        strSyntex1 = " N'%";
                        strSyntex2 = "%'";
                    }
                    else
                    {
                        strSyntex1 = " N'";
                        strSyntex2 = "'";
                    }

                    if (strInputFields != "")
                    {
                        strInputFields = strInputFields + " And " + PHSearch.Controls[i].ID.Substring(3) + " " + ddlOperator.SelectedValue.ToString() + strSyntex1 + strInputVal + strSyntex2;
                    }
                    else
                    {
                        strInputFields = PHSearch.Controls[i].ID.Substring(3) + " " + ddlOperator.SelectedValue.ToString() + strSyntex1 + strInputVal + strSyntex2;
                    }
                }

            }

        }


        BL.Search objSearch = new BL.Search();
        if (strInputFields != "")
        {
            strInputFields = strInputFields + " And CompanyCode=N'" + strCompanyCode + "'";
            if (strHrLocationCode != "")
            {
                strInputFields = strInputFields + " And HrLocationCode=N'" + strHrLocationCode + "'";
            }
            if (strLocationCode != "")
            {
                strInputFields = strInputFields + " And LocationCode=N'" + strLocationCode + "'";
            }
            if (strToLocationCode != "")
            {
                strInputFields = strInputFields + " And ToLocationCode=N'" + strToLocationCode + "'";
            }
            string strSqlQuery = "Select Distinct " + txtOutputFields.Value + " From " + txtObjectName.Value + " where " + strInputFields;
            dsSearchResult = objSearch.CommonSearchResultGet(strSqlQuery);
        }
        else
        {
            strInputFields = "CompanyCode=N'" + strCompanyCode + "'";
            if (strHrLocationCode != "")
            {
                strInputFields = strInputFields + " And HrLocationCode=N'" + strHrLocationCode + "'";
            }
            if (strLocationCode != "")
            {
                strInputFields = strInputFields + " And LocationCode=N'" + strLocationCode + "'";
            }
            if (strToLocationCode != "")
            {
                strInputFields = strInputFields + " And ToLocationCode=N'" + strToLocationCode + "'";
            }


            string strSqlQuery = "Select Distinct " + txtOutputFields.Value + " From " + txtObjectName.Value + " where " + strInputFields;
            dsSearchResult = objSearch.CommonSearchResultGet(strSqlQuery);
        }


        if (dsSearchResult != null && dsSearchResult.Tables.Count > 0 && dsSearchResult.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsSearchResult.Tables[0].Columns.Count; i++)
            {

                string strLingual;

                if (!string.IsNullOrEmpty(BaseLanguageCode) && BaseLanguageCode != "en-US")
                {
                    strLingual = "." + BaseLanguageCode.Substring(0, 2);
                }
                else
                {
                    strLingual = "";
                }
                gvSearchResult.DataSource = dsSearchResult;
                gvSearchResult.DataBind();
                for (int j = 0; j < gvSearchResult.HeaderRow.Cells.Count; j++)
                {
                    try
                    {
                        gvSearchResult.HeaderRow.Cells[j].Text = Resources.Resource.ResourceManager.GetString((string)gvSearchResult.HeaderRow.Cells[j].Text);
                    }
                    catch (Exception)
                    {
                        gvSearchResult.HeaderRow.Cells[j].Text = gvSearchResult.HeaderRow.Cells[j].Text;
                    }
                }
            }
            int intCellNo_ToBeReturn = 0;
            int intCellNo_ToBeReturn2 = 0;
            for (int j = 0; j < dsSearchResult.Tables[0].Columns.Count; j++)
            {
                if (dsSearchResult.Tables[0].Columns[j].ColumnName == txtReturnColumn.Value)
                {
                    intCellNo_ToBeReturn = j;
                }
                if (dsSearchResult.Tables[0].Columns[j].ColumnName == txtReturnColumn2.Value)
                {
                    intCellNo_ToBeReturn2 = j;
                }
            }
            for (int i = 0; i < gvSearchResult.Rows.Count; i++)
            {
                gvSearchResult.Rows[i].Attributes["ondblclick"] = "javascript:ReturnVal('" + gvSearchResult.Rows[i].Cells[intCellNo_ToBeReturn].Text.ToString() + "','" + gvSearchResult.Rows[i].Cells[intCellNo_ToBeReturn2].Text.ToString() + "','" + strControlId + "','" + strControlId1 + "');";
            }
        }
        else
        {
            gvSearchResult.DataSource = null;
            gvSearchResult.DataBind();
            lblerr.Text = Resources.Resource.NoRecordFound ;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvSearchResult control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSearchResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvSearchResult control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearchResult.PageIndex = e.NewPageIndex;
        FillgvSearchResult();

    }
}
