// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="UserLocationRights.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class UserManagement_UserLocationRights
/// </summary>
public partial class UserManagement_UserLocationRights : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Page Title from resource file
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.UserLocationRights + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (Request.QueryString["UserID"] != null)
            {
                lblUserID.Text = Request.QueryString["UserID"];
                var objblUserManagement = new BL.UserManagement();
                DataSet ds = objblUserManagement.UserNameAndTypeGet(lblUserID.Text);
                if (ds.Tables.Count > 0)
                {
                    lblUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                    FillgvUserLocRights();
                }
                else
                {
                    lblUserID.Text = string.Empty;
                    lblErrorMsg.Text = Resources.Resource.MsgNotFound;
                }
            }
        }
    }
    /// <summary>
    /// Fillgvs the user loc rights.
    /// </summary>
    protected void FillgvUserLocRights()
    {
        var objUserManagement = new BL.UserManagement();

        DataSet dsUserLocationRights = objUserManagement.UserLocationRightGet(BaseUserID, BaseIsAdmin, lblUserID.Text);
        if (dsUserLocationRights.Tables.Count > 0)
        {
            gvUserLocRights.DataKeyNames = new[] { "LocationAutoID" };
            gvUserLocRights.DataSource = dsUserLocationRights.Tables[0];
            gvUserLocRights.DataBind();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgNotFound;
        }
    }

    #region Grid View Functions
    /// <summary>
    /// Handles the RowCommand event of the gvUserLocRights control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvUserLocRights_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var htLocationAutoID = new Hashtable();

        var objUserManagement = new BL.UserManagement();
        if (e.CommandName == "Save")
        {
            foreach (GridViewRow row in gvUserLocRights.Rows)
            {
                var cbLocationCodeRight = (CheckBox)row.FindControl("cbLocationCodeRight");
                var dataKey = gvUserLocRights.DataKeys[row.RowIndex];
                if (dataKey != null)
                    htLocationAutoID[dataKey.Value.ToString()] = cbLocationCodeRight.Checked.ToString();
            }
            DataSet ds = objUserManagement.LocationRightAdd(BaseUserID, lblUserID.Text, htLocationAutoID);
            FillgvUserLocRights();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
        }
    }

    /// <summary>
    /// The previous company
    /// </summary>
    string previousCompany = string.Empty;
    /// <summary>
    /// The previous hr location
    /// </summary>
    string previousHrLocation = string.Empty;
    /// <summary>
    /// The first row
    /// </summary>
    private int firstRow = -1;
    /// <summary>
    /// The hr Location row
    /// </summary>
    private int hrLocationRow = -1;
    /// <summary>
    /// Handles the RowDataBound event of the gvUserLocRights control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvUserLocRights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //We're only interested in Rows that contain data    
            //get a reference to the data used to databound the row
            var cbCompanyCode = (CheckBox)e.Row.FindControl("cbCompanyCode");
            var cbHrLocationCode = (CheckBox)e.Row.FindControl("cbHrLocationCode");

            //For First column Company Code and description
            if (previousCompany == cbCompanyCode.Text)
            {
                //If it's the same  Company Code as the previous one      
                //Increment the rowspan      
                if (gvUserLocRights.Rows[firstRow].Cells[0].RowSpan == 0)
                {
                    gvUserLocRights.Rows[firstRow].Cells[0].RowSpan = 2;
                }
                else
                {
                    gvUserLocRights.Rows[firstRow].Cells[0].RowSpan += 1;
                }
                //Remove the cell
                e.Row.Cells.RemoveAt(0);
                //--------------------------------------------------
                //For Second column HrLocation Code and description
                if (previousHrLocation == cbHrLocationCode.Text)
                {
                    if (firstRow == hrLocationRow)
                    {
                        //If it's the same HrLocation Code as the previous one      
                        //Increment the rowspan      
                        if (gvUserLocRights.Rows[hrLocationRow].Cells[1].RowSpan == 0)
                        {
                            gvUserLocRights.Rows[hrLocationRow].Cells[1].RowSpan = 2;
                        }
                        else
                        {
                            gvUserLocRights.Rows[hrLocationRow].Cells[1].RowSpan += 1;
                        }
                    }
                    else
                    {
                        if (gvUserLocRights.Rows[hrLocationRow].Cells[0].RowSpan == 0)
                        {
                            gvUserLocRights.Rows[hrLocationRow].Cells[0].RowSpan = 2;
                        }
                        else
                        {
                            gvUserLocRights.Rows[hrLocationRow].Cells[0].RowSpan += 1;
                        }
                    }
                    //Remove the cell
                    e.Row.Cells.RemoveAt(0);
                }
                else
                {
                    //Set the vertical alignment to top
                    e.Row.VerticalAlign = VerticalAlign.Top;
                    //Maintain the category in memory      
                    previousCompany = cbCompanyCode.Text;
                    previousHrLocation = cbHrLocationCode.Text;
                    //firstRow = e.Row.RowIndex;
                    hrLocationRow = e.Row.RowIndex;
                }
                //--------------------------------------------------
            }
            else //It's a new category    
            {
                //Set the vertical alignment to top
                e.Row.VerticalAlign = VerticalAlign.Top;
                //Maintain the category in memory      
                previousCompany = cbCompanyCode.Text;
                previousHrLocation = cbHrLocationCode.Text;
                firstRow = e.Row.RowIndex;
                hrLocationRow = e.Row.RowIndex;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            var btnAdd = (Button)e.Row.FindControl("btnAdd");
            if (btnAdd != null)
            {
                btnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
            }
        }
    }

    #endregion
    /// <summary>
    /// Handles the Click event of the btnBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UserManagement/UserDetail.aspx");
    }
}