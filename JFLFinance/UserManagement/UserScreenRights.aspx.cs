// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="UserScreenRights.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class UserManagement_UserScreenRights
/// </summary>
public partial class UserManagement_UserScreenRights : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// The menu type
    /// </summary>
    static string MenuType = "";
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            if (lblPageHdrTitle != null)
            {
                lblPageHdrTitle.Text = Resources.Resource.UserLocationRights.ToString();
            }
            if (Request.QueryString["UGCode"] != null)
            {
                lblUserGroupCode.Text = Request.QueryString["UGCode"].ToString();
            }
            if (Request.QueryString["UGName"] != null)
            {
                lblUserGroupName.Text = Request.QueryString["UGName"].ToString();
            }
            FillgvUserLocRights();
        }
    }
    
    #region Grid View Binding
    /// <summary>
    /// Fillgvs the user loc rights.
    /// </summary>
    protected void FillgvUserLocRights()
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet dsUserLocationRights = new DataSet();
        dsUserLocationRights = objUserManagement.LocationAccessRightGet(BaseIsAdmin.ToString());
        if (dsUserLocationRights.Tables.Count > 0 && dsUserLocationRights.Tables[0].Rows.Count > 0)
        {
            gvUserLocRights.DataKeyNames = new string[] { "MenuHeadCode" };
            gvUserLocRights.DataSource = dsUserLocationRights.Tables[0];
            gvUserLocRights.DataBind();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow.ToString();
        }
    }

    /// <summary>
    /// Fillgvs the user screen rights.
    /// </summary>
    /// <param name="gvUserScreenRights">The gv user screen rights.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strMenuHeadName">Name of the STR menu head.</param>
    protected void FillgvUserScreenRights(GridView gvUserScreenRights, string strMenuHeadCode)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet dsUserScreenRights = new DataSet();

        dsUserScreenRights = objUserManagement.FunctionalityAccessRightGet(lblUserGroupCode.Text,strMenuHeadCode);
        if (dsUserScreenRights != null && dsUserScreenRights.Tables.Count > 0 && dsUserScreenRights.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsUserScreenRights.Tables[0].Rows.Count; i++)
            {
                dsUserScreenRights.Tables[0].Rows[i]["MenuHeadName"] = ResourceValueOfKey_Get(dsUserScreenRights.Tables[0].Rows[i]["MenuHeadCode"].ToString(), dsUserScreenRights.Tables[0].Rows[i]["MenuHeadName"].ToString());
                dsUserScreenRights.Tables[0].Rows[i]["MenuNodeName"] = ResourceValueOfKey_Get(dsUserScreenRights.Tables[0].Rows[i]["MenuNodeCode"].ToString(), dsUserScreenRights.Tables[0].Rows[i]["MenuNodeName"].ToString());
            }
            DataView dv = new DataView(dsUserScreenRights.Tables[0]);
            gvUserScreenRights.DataKeyNames = new string[] { "MenuNodeAutoID" };
            gvUserScreenRights.DataSource = dv;
            gvUserScreenRights.DataBind();
        }
    }

    /// <summary>
    /// Fillgvs the level2.
    /// </summary>
    /// <param name="gvLevel2">The gv level2.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strMenuHeadName">Name of the STR menu head.</param>
    protected void FillgvLevel2(GridView gvLevel2, string strMenuHeadCode)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet dsLevel2 = new DataSet();

        dsLevel2 = objUserManagement.SuperAdminLevel2Get(lblUserGroupCode.Text, strMenuHeadCode);
        if (dsLevel2 != null && dsLevel2.Tables.Count > 0 && dsLevel2.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsLevel2.Tables[0].Rows.Count; i++)
            {
                dsLevel2.Tables[0].Rows[i]["MenuHeadName"] = ResourceValueOfKey_Get(dsLevel2.Tables[0].Rows[i]["MenuHeadCode"].ToString(), dsLevel2.Tables[0].Rows[i]["MenuHeadName"].ToString());
            }
            DataView dv = new DataView(dsLevel2.Tables[0]);
            gvLevel2.DataKeyNames = new string[] { "MenuHeadCode" };
            gvLevel2.DataSource = dv;
            gvLevel2.DataBind();
        }
    }

    /// <summary>
    /// Fillgvs the level3.
    /// </summary>
    /// <param name="gvLevel3">The gv level3.</param>
    /// <param name="strLocationAutoID">The STR location auto ID.</param>
    /// <param name="strMenuHeadName">Name of the STR menu head.</param>
    protected void FillgvLevel3(GridView gvLevel3, string strMenuHeadCode)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet dsLevel3 = new DataSet();

        dsLevel3 = objUserManagement.FunctionalityAccessRightGet(lblUserGroupCode.Text, strMenuHeadCode);
        if (dsLevel3 != null && dsLevel3.Tables.Count > 0 && dsLevel3.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsLevel3.Tables[0].Rows.Count; i++)
            {
                dsLevel3.Tables[0].Rows[i]["MenuHeadName"] = ResourceValueOfKey_Get(dsLevel3.Tables[0].Rows[i]["MenuHeadCode"].ToString(), dsLevel3.Tables[0].Rows[i]["MenuHeadName"].ToString());
                dsLevel3.Tables[0].Rows[i]["MenuNodeName"] = ResourceValueOfKey_Get(dsLevel3.Tables[0].Rows[i]["MenuNodeCode"].ToString(), dsLevel3.Tables[0].Rows[i]["MenuNodeName"].ToString());
            }
            DataView dv = new DataView(dsLevel3.Tables[0]);
            gvLevel3.DataKeyNames = new string[] { "MenuNodeAutoID" };
            gvLevel3.DataSource = dv;
            gvLevel3.DataBind();
        }
    }

    #endregion

    #region gvUserLocRights Events
    /// <summary>
    /// Handles the RowDataBound event of the gvUserLocRights control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvUserLocRights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvUserScreenRights = (GridView)e.Row.FindControl("gvUserScreenRights");
            GridView gvLevel2 = (GridView)e.Row.FindControl("gvLevel2");
            Label lblgvUserLocRights_MenuHeadName = (Label)e.Row.FindControl("lblgvUserLocRights_MenuHeadName");
            HiddenField hfgvUserLocRights_MenuHeadCode = (HiddenField)e.Row.FindControl("hfgvUserLocRights_MenuHeadCode");

            BL.UserManagement objUserManagement = new BL.UserManagement();
            DataSet dsUserScreenRights = new DataSet();

            dsUserScreenRights = objUserManagement.MenuTypeGet(lblgvUserLocRights_MenuHeadName.Text);
            if (dsUserScreenRights != null && dsUserScreenRights.Tables.Count > 0 && dsUserScreenRights.Tables[0].Rows.Count > 0)
            {
                MenuType = dsUserScreenRights.Tables[0].Rows[0]["Status"].ToString();
            }

            if (gvUserScreenRights != null)
            {
                if (MenuType == "1")
                {
                    FillgvLevel2(gvLevel2, hfgvUserLocRights_MenuHeadCode.Value);
                }
                else
                {
                    FillgvUserScreenRights(gvUserScreenRights, hfgvUserLocRights_MenuHeadCode.Value);
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvUserLocRights control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvUserLocRights_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvUserLocRights.EditIndex = e.NewEditIndex;
        FillgvUserLocRights();
        GridViewRow row = gvUserLocRights.Rows[e.NewEditIndex];
        HiddenField hfgvUserLocRights_MenuHeadCode = (HiddenField)row.FindControl("hfgvUserLocRights_MenuHeadCode");

        Session["Session_gvUserLocRights_MenuHeadCode"] = hfgvUserLocRights_MenuHeadCode.Value;
        Session["Session_gvUserLocRights_RowIndex"] = e.NewEditIndex;


    }
    /// <summary>
    /// Handles the RowCanceling event of the gvUserLocRights control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvUserLocRights_RowCanceling(object sender, GridViewCancelEditEventArgs e)
    {
        gvUserLocRights.EditIndex = -1;
        FillgvUserLocRights();
    }
    /// <summary>
    /// Handles the RowCommand event of the gvUserLocRights control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvUserLocRights_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable table = new DataTable("UserScreenRights");
        DataColumn column;
        DataRow row;

        //column = new DataColumn();
        //column.DataType = System.Type.GetType("System.Int64");
        //column.ColumnName = "UserLocationAccessAutoID";
        //table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Int64");
        column.ColumnName = "MenuNodeAutoID";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsRead";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsWrite";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsModify";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsDelete";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsAuthorization";
        table.Columns.Add(column);

        //column = new DataColumn();
        //column.DataType = System.Type.GetType("System.Boolean");
        //column.ColumnName = "AllBranch";
        //table.Columns.Add(column);


        BL.UserManagement objUserManagement = new BL.UserManagement();
        if (e.CommandName == "Save")
        {
            foreach (GridViewRow ULRrow in gvUserLocRights.Rows)
            {
                GridView gvUserScreenRights = (GridView)ULRrow.FindControl("gvUserScreenRights");
                foreach (GridViewRow USRrow in gvUserScreenRights.Rows)
                {
                    CheckBox cbIsRead = (CheckBox)USRrow.FindControl("cbIsRead");
                    CheckBox cbIsWrite = (CheckBox)USRrow.FindControl("cbIsWrite");
                    CheckBox cbIsModify = (CheckBox)USRrow.FindControl("cbIsModify");
                    CheckBox cbIsDelete = (CheckBox)USRrow.FindControl("cbIsDelete");
                    CheckBox cbIsAuthorization = (CheckBox)USRrow.FindControl("cbIsAuthorization");

                    row = table.NewRow();
                    row["MenuNodeAutoID"] = Int64.Parse(gvUserScreenRights.DataKeys[USRrow.RowIndex]["MenuNodeAutoID"].ToString());
                    row["IsRead"] = Boolean.Parse(cbIsRead.Checked.ToString());
                    row["IsWrite"] = Boolean.Parse(cbIsWrite.Checked.ToString());
                    row["IsModify"] = Boolean.Parse(cbIsModify.Checked.ToString());
                    row["IsDelete"] = Boolean.Parse(cbIsDelete.Checked.ToString());
                    row["IsAuthorization"] = Boolean.Parse(cbIsAuthorization.Checked.ToString());
                    table.Rows.Add(row);
                }
            }
            DataSet ds = new DataSet();
            ds = objUserManagement.FunctionalityAccessRightAdd(BaseUserID, lblUserGroupCode.Text, table);
            FillgvUserLocRights();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            else
            {
                lblErrorMsg.Text = string.Empty;
            }
        }
    }
    #endregion gvUserLocRights Events

    #region Screen Rights
    /// <summary>
    /// Handles the RowCommand event of the gvUserScreenRights control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvUserScreenRights_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable table = new DataTable("UserScreenRights");
        DataColumn column;
        DataRow row;

        //column = new DataColumn();
        //column.DataType = System.Type.GetType("System.Int64");
        //column.ColumnName = "UserLocationAccessAutoID";
        //table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Int64");
        column.ColumnName = "MenuNodeAutoID";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsRead";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsWrite";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsModify";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsDelete";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsAuthorization";
        table.Columns.Add(column);

        //column = new DataColumn();
        //column.DataType = System.Type.GetType("System.Boolean");
        //column.ColumnName = "AllBranch";
        //table.Columns.Add(column);


        BL.UserManagement objUserManagement = new BL.UserManagement();
        if (e.CommandName == "Save")
        {

            foreach (GridViewRow ULRrow in gvUserLocRights.Rows)
            {

                GridView gvUserScreenRights = (GridView)ULRrow.FindControl("gvUserScreenRights");
                if (gvUserScreenRights != null)
                {
                    foreach (GridViewRow USRrow in gvUserScreenRights.Rows)
                    {
                        CheckBox cbIsRead = (CheckBox)USRrow.FindControl("cbIsRead");
                        CheckBox cbIsWrite = (CheckBox)USRrow.FindControl("cbIsWrite");
                        CheckBox cbIsModify = (CheckBox)USRrow.FindControl("cbIsModify");
                        CheckBox cbIsDelete = (CheckBox)USRrow.FindControl("cbIsDelete");
                        CheckBox cbIsAuthorization = (CheckBox)USRrow.FindControl("cbIsAuthorization");
                        row = table.NewRow();

                        row["MenuNodeAutoID"] = Int64.Parse(gvUserScreenRights.DataKeys[USRrow.RowIndex]["MenuNodeAutoID"].ToString());
                        row["IsRead"] = Boolean.Parse(cbIsRead.Checked.ToString());
                        row["IsWrite"] = Boolean.Parse(cbIsWrite.Checked.ToString());
                        row["IsModify"] = Boolean.Parse(cbIsModify.Checked.ToString());
                        row["IsDelete"] = Boolean.Parse(cbIsDelete.Checked.ToString());
                        row["IsAuthorization"] = Boolean.Parse(cbIsAuthorization.Checked.ToString());
                        table.Rows.Add(row);
                    }
                }
                DataSet ds = new DataSet();
                ds = objUserManagement.FunctionalityAccessRightAdd(BaseUserID, lblUserGroupCode.Text, table);
                FillgvUserLocRights();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                else
                {
                    lblErrorMsg.Text = string.Empty;
                }
            }
        }
    }
    #endregion

    #region gvLevel2 Events
    /// <summary>
    /// Handles the RowCanceling event of the gvLevel2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvLevel2_RowCanceling(object sender, GridViewCancelEditEventArgs e)
    {
        //set the edit index of the child gridview with that of the current row
        int parent_index = (int)Session["Session_gvUserLocRights_RowIndex"];
        GridViewRow parent_row = gvUserLocRights.Rows[parent_index];
        GridView gvLevel2 = (GridView)parent_row.FindControl("gvLevel2");

        gvLevel2.EditIndex = -1;
        FillgvUserLocRights();
    }
    /// <summary>
    /// Handles the OnRowEditing event of the gvLevel2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvLevel2_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        //set the edit index of the child gridview with that of the current row
        int parent_index = (int)Session["Session_gvUserLocRights_RowIndex"];
        GridViewRow parent_row = gvUserLocRights.Rows[parent_index];
        GridView gvLevel2 = (GridView)parent_row.FindControl("gvLevel2");

        int child_index = e.NewEditIndex;
        gvLevel2.EditIndex = child_index;
        gvLevel2.DataBind();
        FillgvLevel2(gvLevel2, Session["Session_gvUserLocRights_MenuHeadCode"].ToString());
        //find the titleid_lbl in that particular row by using findcontrol method
        //GridViewRow child_row = gvLevel2.Rows[child_index];
        //Label lblgvLevel2_MenuHeadName = (Label)child_row.FindControl("lblgvLevel2_MenuHeadName");
        // save the title_id in session for grandchildgridview's use
        //        Session["lblgvLevel2_MenuHeadName"] = lblgvLevel2_MenuHeadName.Text;
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvLevel2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLevel2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvLevel3 = (GridView)e.Row.FindControl("gvLevel3");
            Label lblgvLevel2_MenuHeadCode = (Label)e.Row.FindControl("lblgvLevel2_MenuHeadCode");

            if (gvLevel3 != null)
            {
                BL.UserManagement objUserManagement = new BL.UserManagement();
                DataSet dsUserScreenRights = new DataSet();

                dsUserScreenRights = objUserManagement.FunctionalityAccessRightGet(lblUserGroupCode.Text, lblgvLevel2_MenuHeadCode.Text);
                if (dsUserScreenRights != null && dsUserScreenRights.Tables.Count > 0 && dsUserScreenRights.Tables[0].Rows.Count > 0)
                {
                    FillgvLevel3(gvLevel3, lblgvLevel2_MenuHeadCode.Text);
                }
            }
        }
    }

    #endregion gvLevel2 Events

    #region gvLevel3 Events
    /// <summary>
    /// Handles the RowCommand event of the gvLevel3 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvLevel3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable table = new DataTable("UserScreenRights");
        DataColumn column;
        DataRow row;

        //column = new DataColumn();
        //column.DataType = System.Type.GetType("System.Int64");
        //column.ColumnName = "UserLocationAccessAutoID";
        //table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Int64");
        column.ColumnName = "MenuNodeAutoID";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsRead";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsWrite";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsModify";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsDelete";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "IsAuthorization";
        table.Columns.Add(column);

        //column = new DataColumn();
        //column.DataType = System.Type.GetType("System.Boolean");
        //column.ColumnName = "AllBranch";
        //table.Columns.Add(column);


        BL.UserManagement objUserManagement = new BL.UserManagement();
        if (e.CommandName == "Save")
        {
            int parent_index = (int)Session["Session_gvUserLocRights_RowIndex"];
            GridViewRow parent_row = gvUserLocRights.Rows[parent_index];
            GridView gvLevel2 = (GridView)parent_row.FindControl("gvLevel2");

            foreach (GridViewRow ULRrow in gvLevel2.Rows)
            {

                GridView gvLevel3 = (GridView)ULRrow.FindControl("gvLevel3");
                if (gvLevel3 != null)
                {
                    foreach (GridViewRow USRrow in gvLevel3.Rows)
                    {
                        CheckBox cbIsRead = (CheckBox)USRrow.FindControl("cbIsRead");
                        CheckBox cbIsWrite = (CheckBox)USRrow.FindControl("cbIsWrite");
                        CheckBox cbIsModify = (CheckBox)USRrow.FindControl("cbIsModify");
                        CheckBox cbIsDelete = (CheckBox)USRrow.FindControl("cbIsDelete");
                        CheckBox cbIsAuthorization = (CheckBox)USRrow.FindControl("cbIsAuthorization");
                        row = table.NewRow();

                        row["MenuNodeAutoID"] = Int64.Parse(gvLevel3.DataKeys[USRrow.RowIndex]["MenuNodeAutoID"].ToString());
                        row["IsRead"] = Boolean.Parse(cbIsRead.Checked.ToString());
                        row["IsWrite"] = Boolean.Parse(cbIsWrite.Checked.ToString());
                        row["IsModify"] = Boolean.Parse(cbIsModify.Checked.ToString());
                        row["IsDelete"] = Boolean.Parse(cbIsDelete.Checked.ToString());
                        row["IsAuthorization"] = Boolean.Parse(cbIsAuthorization.Checked.ToString());
                        table.Rows.Add(row);
                    }
                }
                DataSet ds = new DataSet();
                ds = objUserManagement.FunctionalityAccessRightAdd(BaseUserID, lblUserGroupCode.Text, table);
                FillgvUserLocRights();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
                else
                {
                    lblErrorMsg.Text = string.Empty;
                }
            }
        }
    }
    #endregion gvLevel3 Events

    /// <summary>
    /// Handles the Click event of the btnBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
            Response.Redirect("../Masters/UserGroup.aspx");
    }

}
