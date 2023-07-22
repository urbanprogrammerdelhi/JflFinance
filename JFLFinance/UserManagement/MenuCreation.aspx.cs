// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="MenuCreation.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class UserManagement_MenuCreation
/// </summary>
public partial class UserManagement_MenuCreation : BasePage //System.Web.UI.Page
{
    # region Function Related to Page
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
        if (lblPageHdrTitle != null)
        {
            lblPageHdrTitle.Text = Resources.Resource.MenuManagement.ToString();
        }

        if (BaseIsAdmin == "SA")
        {
            if (!IsPostBack)
            {
                FillgvMenuHead();
                lblErrMsg.Text = "";
            }
        }
        else
        {
            lblErrMsg.Text = Resources.Resource.NOAccessRights;
        }
    }
    # endregion

    #region GridView Binding
    /// <summary>
    /// Fillgvs the menu head.
    /// </summary>
    protected void FillgvMenuHead()
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet dsMenuHead = new DataSet();
        DataTable dtMenuHead = new DataTable();
        int dtflag;
        dtflag = 1;
        dsMenuHead = objUserManagement.MenuHeadGetAll();
        dtMenuHead = dsMenuHead.Tables[0];

        //to fix empety gridview
        if (dtMenuHead.Rows.Count == 0)
        {
            dtflag = 0;
            dtMenuHead.Rows.Add(dtMenuHead.NewRow());
        }
        else
        {
            lblhdrMenuHeadCode.Text = dtMenuHead.Rows[0]["MenuHeadCode"].ToString();
            lblhdrMenuHeadName.Text = dtMenuHead.Rows[0]["MenuHeadName"].ToString();
            hfhdrMenuHeadAutoId.Value = dtMenuHead.Rows[0]["MenuHeadAutoId"].ToString();
            FillgvMenuNode(dtMenuHead.Rows[0]["MenuHeadCode"].ToString());
        }
        gvMenuHead.DataKeyNames = new string[] { "MenuHeadCode" };
        gvMenuHead.DataSource = dtMenuHead;
        gvMenuHead.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvMenuHead.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Fillgvs the menu node.
    /// </summary>
    /// <param name="strMenuHeadCode">The STR menu head code.</param>
    protected void FillgvMenuNode(string strMenuHeadCode)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet dsMenuNode = new DataSet();
        DataTable dtMenuNode = new DataTable();
        int dtflag;
        dtflag = 1;
        dsMenuNode = objUserManagement.MenuNodeGet(strMenuHeadCode);
        dtMenuNode = dsMenuNode.Tables[0];

        //to fix empety gridview
        if (dtMenuNode.Rows.Count == 0)
        {
            dtflag = 0;
            dtMenuNode.Rows.Add(dtMenuNode.NewRow());
        }
        gvMenuNode.DataKeyNames = new string[] { "MenuNodeCode" };
        gvMenuNode.DataSource = dtMenuNode;
        gvMenuNode.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvMenuNode.Rows[0].Visible = false;
        }
        TextBox txtMenuHeadCode = (TextBox)gvMenuNode.FooterRow.FindControl("txtMenuHeadCode");
        txtMenuHeadCode.Text = lblhdrMenuHeadCode.Text;
    }
    #endregion

    #region Functions Related to MenuHead gridView
    /// <summary>
    /// Handles the RowDataBound event of the gvMenuHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvMenuHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvMenuHead, "Select$" + e.Row.RowIndex);
            Label lblMenuHeadCode = (Label)e.Row.FindControl("lblMenuHeadCode");
            TextBox txtMenuHeadName = (TextBox)e.Row.FindControl("txtMenuHeadName");
            if (txtMenuHeadName != null)
            {
                txtMenuHeadName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtMenuHeadName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }
            TextBox txtPositionNo = (TextBox)e.Row.FindControl("txtPositionNo");
            if (txtPositionNo != null)
            {
                txtPositionNo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtPositionNo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            }
            HiddenField hfMenuHeadAutoId = (HiddenField)e.Row.FindControl("hfMenuHeadAutoId");
            DropDownList ddlParentMenuHeadCode = (DropDownList)e.Row.FindControl("ddlParentMenuHeadCode");
            HiddenField hfParentMenuHeadCode = (HiddenField)e.Row.FindControl("hfParentMenuHeadCode");
            HiddenField hfParentMenuHeadAutoId = (HiddenField)e.Row.FindControl("hfParentMenuHeadAutoId");

            if (lblMenuHeadCode != null && ddlParentMenuHeadCode != null && hfParentMenuHeadCode != null && hfParentMenuHeadAutoId != null)
            {
                BL.UserManagement objUserManagement = new BL.UserManagement();
                DataSet ds = new DataSet();
                ds = objUserManagement.MenuHeadAutoIdGetAll(hfMenuHeadAutoId.Value.ToString());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlParentMenuHeadCode.DataSource = ds.Tables[0];
                    ddlParentMenuHeadCode.DataTextField = "MenuHeadName";
                    ddlParentMenuHeadCode.DataValueField = "MenuHeadAutoId";
                    ddlParentMenuHeadCode.DataBind();

                    ListItem Li = new ListItem();
                    Li.Text =  Resources.Resource.NoParent.ToString() ;
                    Li.Value = "0";
                    ddlParentMenuHeadCode.Items.Insert(0, Li);

                    ddlParentMenuHeadCode.SelectedIndex = ddlParentMenuHeadCode.Items.IndexOf(ddlParentMenuHeadCode.Items.FindByValue(hfParentMenuHeadAutoId.Value.ToString()));
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text =  Resources.Resource.NoDataToShow ;
                    li.Value = "0";
                    ddlParentMenuHeadCode.Items.Add(li);
                }

            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtMenuHeadCode = (TextBox)e.Row.FindControl("txtMenuHeadCode");
            if (txtMenuHeadCode != null)
            {
                txtMenuHeadCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtMenuHeadCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
            }
            TextBox txtMenuHeadName = (TextBox)e.Row.FindControl("txtMenuHeadName");
            if (txtMenuHeadName != null)
            {
                txtMenuHeadName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtMenuHeadName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }
            TextBox txtPositionNo = (TextBox)e.Row.FindControl("txtPositionNo");
            if (txtPositionNo != null)
            {
                txtPositionNo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtPositionNo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            }
            DropDownList ddlParentMenuHeadCode = (DropDownList)e.Row.FindControl("ddlParentMenuHeadCode");

            if (txtMenuHeadCode != null && ddlParentMenuHeadCode != null)
            {
                BL.UserManagement objUserManagement = new BL.UserManagement();
                DataSet ds = new DataSet();
                ds = objUserManagement.MenuHeadAutoIdGetAll("0");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlParentMenuHeadCode.DataSource = ds.Tables[0];
                    ddlParentMenuHeadCode.DataTextField = "MenuHeadName";
                    ddlParentMenuHeadCode.DataValueField = "MenuHeadAutoId";
                    ddlParentMenuHeadCode.DataBind();

                    ListItem Li = new ListItem();
                    Li.Text =  Resources.Resource.NoParent.ToString() ;
                    Li.Value = "0";
                    ddlParentMenuHeadCode.Items.Insert(0, Li);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text =  Resources.Resource.NoDataToShow ;
                    li.Value = "0";
                    ddlParentMenuHeadCode.Items.Add(li);
                }
            }
        }
    }
    /// <summary>
    /// Handles the OnClick event of the lbMenuHeadCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbMenuHeadCode_OnClick(object sender, EventArgs e)
    {
        LinkButton lbMenuHeadCode = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbMenuHeadCode.NamingContainer;

        Label lblMenuHeadCode = (Label)gvMenuHead.Rows[gvRow.RowIndex].FindControl("lblMenuHeadCode");
        Label lblMenuHeadName = (Label)gvMenuHead.Rows[gvRow.RowIndex].FindControl("lblMenuHeadName");
        HiddenField hfMenuHeadAutoId = (HiddenField)gvMenuHead.Rows[gvRow.RowIndex].FindControl("hfMenuHeadAutoId");
        lblhdrMenuHeadName.Text = lblMenuHeadName.Text;
        lblhdrMenuHeadCode.Text = lblMenuHeadCode.Text;
        hfhdrMenuHeadAutoId.Value = hfMenuHeadAutoId.Value.ToString();
        FillgvMenuNode(lblMenuHeadCode.Text);
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvMenuHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvMenuHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label lblMenuHeadCode = (Label)gvMenuHead.SelectedRow.FindControl("lblMenuHeadCode");
        Label lblMenuHeadName = (Label)gvMenuHead.SelectedRow.FindControl("lblMenuHeadName");
        HiddenField hfMenuHeadAutoId = (HiddenField)gvMenuHead.SelectedRow.FindControl("hfMenuHeadAutoId");
        lblhdrMenuHeadName.Text = lblMenuHeadName.Text;
        lblhdrMenuHeadCode.Text = lblMenuHeadCode.Text;
        hfhdrMenuHeadAutoId.Value = hfMenuHeadAutoId.Value.ToString();
        FillgvMenuNode(lblMenuHeadCode.Text);
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvMenuHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvMenuHead_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvMenuHead.EditIndex = -1;
        FillgvMenuHead();
    }
    /// <summary>
    /// Handles the RowCommand event of the gvMenuHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvMenuHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        // To Insert a New Row
        DataSet ds = new DataSet();
        TextBox txtMenuHeadCode = (TextBox)gvMenuHead.FooterRow.FindControl("txtMenuHeadCode");
        TextBox txtMenuHeadName = (TextBox)gvMenuHead.FooterRow.FindControl("txtMenuHeadName");
        TextBox txtPositionNo = (TextBox)gvMenuHead.FooterRow.FindControl("txtPositionNo");
        CheckBox cbIsActive = (CheckBox)gvMenuHead.FooterRow.FindControl("cbIsActive");
        DropDownList ddlParentMenuHeadCode = (DropDownList)gvMenuHead.FooterRow.FindControl("ddlParentMenuHeadCode");

        if (e.CommandName == "Add")
        {
            ds = objUserManagement.MenuHeadAdd(txtMenuHeadCode.Text, txtMenuHeadName.Text, int.Parse(txtPositionNo.Text), cbIsActive.Checked.ToString(), ddlParentMenuHeadCode.SelectedItem.Value.ToString(), BaseUserID.ToString());
            gvMenuHead.EditIndex = -1;
            FillgvMenuHead();
            MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
        }
        if (e.CommandName == "Reset")
        {
            txtMenuHeadCode.Text = "";
            txtMenuHeadName.Text = "";
            txtPositionNo.Text = "";
            cbIsActive.Checked = false;
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvMenuHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvMenuHead_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();
        Label lblMenuHeadCode = (Label)gvMenuHead.Rows[e.RowIndex].FindControl("lblMenuHeadCode");
        ds = objUserManagement.MenuHeadDelete(lblMenuHeadCode.Text);
        FillgvMenuHead();
        MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvMenuHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvMenuHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvMenuHead.EditIndex = e.NewEditIndex;
        FillgvMenuHead();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvMenuHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvMenuHead_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();
        Label lblMenuHeadCode = (Label)gvMenuHead.Rows[e.RowIndex].FindControl("lblMenuHeadCode");
        TextBox txtMenuHeadName = (TextBox)gvMenuHead.Rows[e.RowIndex].FindControl("txtMenuHeadName");
        TextBox txtPositionNo = (TextBox)gvMenuHead.Rows[e.RowIndex].FindControl("txtPositionNo");
        CheckBox cbIsActive = (CheckBox)gvMenuHead.Rows[e.RowIndex].FindControl("cbIsActive");
        DropDownList ddlParentMenuHeadCode = (DropDownList)gvMenuHead.Rows[e.RowIndex].FindControl("ddlParentMenuHeadCode");
        //txtPositionNo.Text
        ds = objUserManagement.MenuHeadUpdate(lblMenuHeadCode.Text, txtMenuHeadName.Text, int.Parse(txtPositionNo.Text), cbIsActive.Checked.ToString(), ddlParentMenuHeadCode.SelectedItem.Value.ToString(), BaseUserID.ToString());
        gvMenuHead.EditIndex = -1;
        FillgvMenuHead();

        MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvMenuHead control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvMenuHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMenuHead.PageIndex = e.NewPageIndex;
        FillgvMenuHead();
    }

    #endregion

    #region Function related to MenuNode Gridview
    /// <summary>
    /// Handles the RowDataBound event of the gvMenuNode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvMenuNode_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            TextBox txtMenuNodeName = (TextBox)e.Row.FindControl("txtMenuNodeName");
            Label lblDependOn = (Label)e.Row.FindControl("lblDependOn");
            if (txtMenuNodeName != null)
            {
                txtMenuNodeName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtMenuNodeName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }
            TextBox txtPositionNo = (TextBox)e.Row.FindControl("txtPositionNo");
            if (txtPositionNo != null)
            {
                txtPositionNo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtPositionNo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            }
            HiddenField hfDependOn = (HiddenField)e.Row.FindControl("hfDependOn");
            DropDownList ddlDependOn = (DropDownList)e.Row.FindControl("ddlDependOn");

            if (ddlDependOn != null && hfDependOn != null)
            {
                if (hfDependOn.Value.ToString() == "")
                {
                    hfDependOn.Value = "0";
                }
                BL.UserManagement objUserManagement = new BL.UserManagement();
                DataSet ds = new DataSet();

                if (hfhdrMenuHeadAutoId.Value.ToString() == "")
                    ds = objUserManagement.MenuNodeGetAll("0", hfDependOn.Value.ToString());
                else
                    ds = objUserManagement.MenuNodeGetAll(hfhdrMenuHeadAutoId.Value.ToString(), hfDependOn.Value.ToString());

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    ddlDependOn.DataSource = ds.Tables[0];
                    ddlDependOn.DataTextField = "MenuNodeName";
                    ddlDependOn.DataValueField = "MenuNodeAutoID";
                    ddlDependOn.DataBind();

                    ListItem Li = new ListItem();
                    Li.Text =  Resources.Resource.NoParent.ToString() ;
                    Li.Value = "0";
                    ddlDependOn.Items.Insert(0, Li);

                    if (hfDependOn != null)
                    {
                        ddlDependOn.SelectedValue = hfDependOn.Value;
                    }
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text =  Resources.Resource.NoDataToShow ;
                    li.Value = "0";
                    ddlDependOn.Items.Add(li);
                }

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtMenuNodeCode = (TextBox)e.Row.FindControl("txtMenuNodeCode");
            if (txtMenuNodeCode != null)
            {
                txtMenuNodeCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtMenuNodeCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
            }
            TextBox txtMenuNodeName = (TextBox)e.Row.FindControl("txtMenuNodeName");
            if (txtMenuNodeName != null)
            {
                txtMenuNodeName.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtMenuNodeName.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
            }
            TextBox txtPositionNo = (TextBox)e.Row.FindControl("txtPositionNo");
            if (txtPositionNo != null)
            {
                txtPositionNo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtPositionNo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            }
            DropDownList ddlDependOn = (DropDownList)e.Row.FindControl("ddlDependOn");


            if (txtMenuNodeCode != null && txtMenuNodeName != null)
            {

                BL.UserManagement objUserManagement = new BL.UserManagement();
                DataSet ds = new DataSet();

                if (hfhdrMenuHeadAutoId.Value.ToString() == "")
                    ds = objUserManagement.MenuNodeGetAll("0", "0");
                else
                    ds = objUserManagement.MenuNodeGetAll(hfhdrMenuHeadAutoId.Value.ToString(), "0");

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    ddlDependOn.DataSource = ds.Tables[0];
                    ddlDependOn.DataTextField = "MenuNodeName";
                    ddlDependOn.DataValueField = "MenuNodeAutoID";
                    ddlDependOn.DataBind();

                    ListItem Li = new ListItem();
                    Li.Text =  Resources.Resource.NoParent.ToString() ;
                    Li.Value = "0";
                    ddlDependOn.Items.Insert(0, Li);


                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text =  Resources.Resource.NoDataToShow;
                    li.Value = "0";
                    ddlDependOn.Items.Add(li);
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvMenuNode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvMenuNode_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvMenuNode.EditIndex = -1;
        FillgvMenuNode(lblhdrMenuHeadCode.Text);
    }
    /// <summary>
    /// Handles the RowCommand event of the gvMenuNode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvMenuNode_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.UserManagement objUserManagement = new BL.UserManagement();
        // To Insert a New Row
        DataSet ds = new DataSet();
        TextBox txtMenuHeadCode = (TextBox)gvMenuNode.FooterRow.FindControl("txtMenuHeadCode");
        TextBox txtMenuNodeCode = (TextBox)gvMenuNode.FooterRow.FindControl("txtMenuNodeCode");
        TextBox txtMenuNodeName = (TextBox)gvMenuNode.FooterRow.FindControl("txtMenuNodeName");
        TextBox txtPageName = (TextBox)gvMenuNode.FooterRow.FindControl("txtPageName");
        TextBox txtPositionNo = (TextBox)gvMenuNode.FooterRow.FindControl("txtPositionNo");
        CheckBox cbIsActive = (CheckBox)gvMenuNode.FooterRow.FindControl("cbIsActive");
        DropDownList ddlDependOn = (DropDownList)gvMenuNode.FooterRow.FindControl("ddlDependOn");
        if (e.CommandName == "Add")
        {
            ds = objUserManagement.MenuNodeAdd(txtMenuHeadCode.Text, txtMenuNodeCode.Text, txtMenuNodeName.Text, txtPageName.Text, int.Parse(ddlDependOn.Text), int.Parse(txtPositionNo.Text), cbIsActive.Checked.ToString(), BaseUserID.ToString());
            gvMenuHead.EditIndex = -1;
            FillgvMenuNode(lblhdrMenuHeadCode.Text);
            MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
        }
        if (e.CommandName == "Reset")
        {
            txtMenuNodeCode.Text = "";
            txtMenuNodeName.Text = "";
            txtPageName.Text = "";
            txtPositionNo.Text = "";
            cbIsActive.Checked = false;
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvMenuNode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvMenuNode_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();
        Label lblMenuHeadCode = (Label)gvMenuNode.Rows[e.RowIndex].FindControl("lblMenuHeadCode");
        Label lblMenuNodeCode = (Label)gvMenuNode.Rows[e.RowIndex].FindControl("lblMenuNodeCode");
        ds = objUserManagement.MenuNodeDelete(lblMenuHeadCode.Text, lblMenuNodeCode.Text);
        FillgvMenuNode(lblhdrMenuHeadCode.Text);
        MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
    }
    /// <summary>
    /// Handles the RowEditing event of the gvMenuNode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvMenuNode_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvMenuNode.EditIndex = e.NewEditIndex;
        FillgvMenuNode(lblhdrMenuHeadCode.Text);
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvMenuNode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvMenuNode_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.UserManagement objUserManagement = new BL.UserManagement();
        Label lblMenuHeadCode = (Label)gvMenuNode.Rows[e.RowIndex].FindControl("lblMenuHeadCode");
        Label lblMenuNodeCode = (Label)gvMenuNode.Rows[e.RowIndex].FindControl("lblMenuNodeCode");
        TextBox txtMenuNodeName = (TextBox)gvMenuNode.Rows[e.RowIndex].FindControl("txtMenuNodeName");
        TextBox txtPageName = (TextBox)gvMenuNode.Rows[e.RowIndex].FindControl("txtPageName");
        TextBox txtPositionNo = (TextBox)gvMenuNode.Rows[e.RowIndex].FindControl("txtPositionNo");
        CheckBox cbIsActive = (CheckBox)gvMenuNode.Rows[e.RowIndex].FindControl("cbIsActive");
        DropDownList ddlDependOn = (DropDownList)gvMenuNode.Rows[e.RowIndex].FindControl("ddlDependOn");
        ds = objUserManagement.MenuNodeUpdate(lblMenuHeadCode.Text, lblMenuNodeCode.Text, txtMenuNodeName.Text, txtPageName.Text, int.Parse(ddlDependOn.SelectedValue), int.Parse(txtPositionNo.Text), cbIsActive.Checked.ToString(), BaseUserID.ToString());
        gvMenuNode.EditIndex = -1;
        FillgvMenuNode(lblhdrMenuHeadCode.Text);
        MessageBox1 = BaseMessageSettings(MessageBox1, int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()), ds.Tables[0].Rows[0]["Comment"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvMenuNode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvMenuNode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMenuNode.PageIndex = e.NewPageIndex;
        FillgvMenuNode(lblhdrMenuHeadCode.Text);
    }

    #endregion

    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MainSelection.aspx");
    }

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
}
