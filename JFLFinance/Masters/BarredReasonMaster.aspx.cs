// ***********************************************************************
// Assembly         :
// Created On       : 27-06-2014
// Created By       : 

// ***********************************************************************
// <copyright file="BarredReasonMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Web.UI.WebControls;
using CommonLibrary;

/// <summary>
/// Class Masters_BarredReasonMaster
/// </summary>
public partial class Masters_BarredReasonMaster : BasePage//System.Web.UI.Page
{

    /// <summary>
    /// The index
    /// </summary>
    static int Index;


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
                var virtualDirNameLenght = int.Parse(MyUtility.GetPageAbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsReadAllowed(MyUtility.GetPageAbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("ErrorInvalidAccess", ex); }
        }
    }

    #endregion

    #region Page Load Event
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {          
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ReasonMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            if (IsReadAccess)
            {
                FillgvReasonType();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Grid View Barred Reason Type Events
    #region function to fill Reason Code Type Master
    /// <summary>
    /// Fillgvs the type of the Barred Reason code.
    /// </summary>
    private void FillgvReasonType()
    {
        var objMasters = new BL.MastersManagement();
        var ds = objMasters.BarredReasonMasterGetAll(BaseCompanyCode);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvReasonType.DataSource = ds.Tables[0];
            gvReasonType.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gvReasonType.DataSource = ds.Tables[0];
            gvReasonType.DataBind();
            gvReasonType.Rows[0].Visible = false;
        }
    }
    #endregion

    /// <summary>
    /// Handles the RowDataBound event of the gvReasonType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvReasonType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var objGridViewRow = e.Row;
        var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            var serialNo = gvReasonType.PageIndex * gvReasonType.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                {
                    var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                    if (imgbtnDelete != null)
                    {
                        imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }

                }
                break;
            case DataControlRowType.Footer:
                {
                    var txtReason = (TextBox)e.Row.FindControl("txtReason");
                    var txtReasonDesc = (TextBox)e.Row.FindControl("txtReasonDesc");
                    var imgbtnadd = (ImageButton)e.Row.FindControl("Imgbtnadd");
                    if (imgbtnadd != null)
                    {
                        imgbtnadd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }

                    if (txtReason != null)
                    {
                        txtReason.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                        txtReason.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    }
                    if (txtReasonDesc != null)
                    {
                        txtReasonDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                        txtReasonDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    }
                }
                break;
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvReasonType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvReasonType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var txtReason = (TextBox)gvReasonType.FooterRow.FindControl("txtReason");
        var txtReasonDesc = (TextBox)gvReasonType.FooterRow.FindControl("txtReasonDesc");
        

        if (e.CommandName.Equals("AddNew"))
        {
            var objMasters = new BL.MastersManagement();
            var ds = objMasters.udpMst_BarredReason_Insert(BaseCompanyCode,txtReason.Text, txtReasonDesc.Text, BaseUserID); 
            if (gvReasonType.Rows.Count.Equals(gvReasonType.PageSize))
            {
                gvReasonType.PageIndex = gvReasonType.PageCount + 1;
            }
            gvReasonType.EditIndex = -1;
            FillgvReasonType();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtReasonDesc.Text = "";
            txtReason.Text = "";
        }

        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvReasonType.PageIndex = 0;
                break;
            case "Prev":
                Index = 1;
                break;
            case "Next":
                Index = 0;
                break;
            case "Last":
                gvReasonType.PageIndex = gvReasonType.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvReasonType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvReasonType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var gvrPager = gvReasonType.BottomPagerRow;
        var ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        var currentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        switch (Index)
        {
            case 1:
                gvReasonType.PageIndex = currentIndex > 0 ? currentIndex - 1 : currentIndex;
                Index = -1;
                break;
            case 0:
                gvReasonType.PageIndex = currentIndex + 1;
                Index = -1;
                break;
            default:
                gvReasonType.PageIndex = e.NewPageIndex;
                break;
        }
        gvReasonType.EditIndex = -1;
        FillgvReasonType();
    }
    
    /// <summary>
    /// Handles the RowDeleting event of the gvReasonType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvReasonType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objMasters = new BL.MastersManagement();
        var lbReason = (Label)gvReasonType.Rows[e.RowIndex].FindControl("lbReason");
        var ds = objMasters.udpMst_BarredReason_Delete(lbReason.Text,BaseCompanyCode);
        FillgvReasonType();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    #endregion

    #region Function Related to Paging in Reason code type
    /// <summary>
    /// Handles the DataBound event of the gvReasonType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvReasonType_DataBound(object sender, EventArgs e)
    {
        var row = gvReasonType.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        var lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (var i = 0; i < gvReasonType.PageCount; i++)
            {
                var intPageNumber = i + 1;
                var lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvReasonType.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvReasonType.PageCount.ToString();
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        var row = gvReasonType.BottomPagerRow;
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvReasonType.PageIndex = ddlPages.SelectedIndex;
        FillgvReasonType();
    }
    #endregion

    
}



