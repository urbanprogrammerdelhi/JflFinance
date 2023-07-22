// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="ClientAsmtPost.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Class Sales_ClientAsmtPost.
/// </summary>
public partial class Sales_ClientAsmtPost : BasePage //System.Web.UI.Page
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    /// <summary>
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["AddPost"] != null && Request.QueryString["AddPost"] == "Add")
        {
            this.MasterPageFile = "~/MasterPage/MasterSearch.master";
        }
        else
        {
            this.MasterPageFile = "~/MasterPage/MasterPage.master";
        }
    }
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillddlAreaId();
                if (Request.QueryString["ClientCode"] != null && Request.QueryString["AsmtId"] != null)
                {
                    //hfClientCode.Value = Request.QueryString["ClientCode"].ToString();
                    //hfAsmtId.Value = Request.QueryString["AsmtId"].ToString();

                    ddlClient.SelectedIndex = ddlClient.Items.IndexOf(ddlClient.Items.FindByValue(Request.QueryString["ClientCode"]));
                    FillddlAsmt();
                    ddlAsmt.SelectedIndex = ddlAsmt.Items.IndexOf(ddlAsmt.Items.FindByValue(Request.QueryString["AsmtId"]));
                    if (Request.QueryString["BackBtnVisible"] != null)
                    {
                        bool boolBackBtnVisible = bool.Parse(Request.QueryString["BackBtnVisible"]);
                        imgBack.Visible = boolBackBtnVisible;
                    }
                }
                FillgvPost();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
        ImgClientCode_CCH.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + txtClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=360,help=no')");
    }

    #region Binding
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaId()
    {
        ListItem li;

        var objSale = new BL.OperationManagement();
        DataSet dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();

            li = new ListItem {Text = Resources.Resource.All, Value = @"ALL"};
            ddlAreaID.Items.Insert(0, li);

            FillddlClient();
        }
        if (ddlAreaID.Text == "")
        {
            li = new ListItem {Text = @Resources.Resource.NoDataToShow , Value = string.Empty};
            ddlAreaID.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        ddlClient.Items.Clear();
        ddlAsmt.Items.Clear();
        var objSale = new BL.Sales();
        var ds = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID) : objSale.ClientsMappedToLocationGet(BaseLocationAutoID, ddlAreaID.SelectedItem.Value, txtClientCode.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientCodeName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();

            FillddlAsmt();
        }
        else
        {
            var li = new ListItem {Text = @Resources.Resource.NoDataToShow , Value = string.Empty};
            ddlClient.Items.Add(li);
            ddlAsmt.Items.Add(li);
            gvPost.DataSource = null;
            gvPost.DataBind();
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {

        ddlAsmt.Items.Clear();
        var objSale = new BL.Sales();
        DataSet ds = objSale.ClientDetailsGet(BaseLocationAutoID, ddlClient.SelectedItem.Value, ddlAreaID.SelectedItem.Value, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //var drArrCheck = ds.Tables[0].Select("IsBillable = True");
            //foreach (var drCheck in drArrCheck)
            //{
            //    ds.Tables[0].Rows.Remove(drCheck);
            //}
            
            var dv = new DataView(ds.Tables[0]) { RowFilter = "IsBillable = False" };
            if (dv.Count > 0)
            {
                ddlAsmt.DataSource = dv.ToTable();
                ddlAsmt.DataTextField = "AsmtId";
                ddlAsmt.DataValueField = "AsmtId";
                ddlAsmt.DataBind();
                FillgvPost();
           } 
            else
            {
                var li = new ListItem
                {
                    Text = @Resources.Resource.NoDataToShow ,
                    Value = string.Empty
                };
                ddlAsmt.Items.Add(li);
                FillgvPost();
            }
        }
        else
        {
            var li = new ListItem {Text = @Resources.Resource.NoDataToShow , Value = string.Empty};
            ddlAsmt.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillgvs the post.
    /// </summary>
    protected void FillgvPost()
    {
        if (ddlClient.Items.Count > 0 && ddlAsmt.Items.Count > 0)
        {
            var objSales = new BL.Sales();
            int dtflag = 1;
            DataSet ds = objSales.PostGetAll(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value);

            //to fix empety gridview
            if (ds.Tables[0].Rows.Count == 0)
            {
                dtflag = 0;
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            }
            gvPost.DataKeyNames = new[] {"PostAutoId"};
            gvPost.DataSource = ds.Tables[0];
            gvPost.DataBind();

            if (dtflag == 0) //to fix empety gridview
            {
                gvPost.Rows[0].Visible = false;
            }
            var lblgvClientCode = (Label) gvPost.FooterRow.FindControl("lblgvClientCode");
            var lblgvAsmtId = (Label) gvPost.FooterRow.FindControl("lblgvAsmtId");
            if (lblgvClientCode != null && lblgvAsmtId != null)
            {
                lblgvClientCode.Text = ddlClient.SelectedItem.Value;
                lblgvAsmtId.Text = ddlAsmt.SelectedItem.Value;
            }
        }
    }
    /// <summary>
    /// Fillddls the post.
    /// </summary>
    /// <param name="ddlPost">The DDL post.</param>
    protected void FillddlPost(DropDownList ddlPost)
    {
        var objSale = new BL.Sales();
        DataSet ds = objSale.PostGetAll();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlPost.DataSource = ds.Tables[0];
            ddlPost.DataTextField = "PostDesc";
            ddlPost.DataValueField = "PostCode";
            ddlPost.DataBind();

            var li = new ListItem {Text = Resources.Resource.AddNew, Value = string.Empty};
            ddlPost.Items.Insert(0,li);
        }
        else
        {
            var li = new ListItem {Text = Resources.Resource.AddNew, Value = string.Empty};
            ddlPost.Items.Add(li);
        }
        SetPostFromDropDown(ddlPost);
    }
    #endregion

    #region GridView Commands Events
    /// <summary>
    /// Handles the RowDataBound event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvPost_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvPost.PageIndex * gvPost.PageSize + int.Parse(e.Row.RowIndex.ToString(CultureInfo.InvariantCulture));
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        { gvPost.Columns[5].Visible = false; }
        else
        { gvPost.Columns[5].Visible = true; }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                var imgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (imgbtnEdit != null)
                { imgbtnEdit.Visible = false; }
            }
            else
            {
                var imgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (imgbtnUpdate != null)
                {
                    imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }
                var txtPostDesc = (TextBox)e.Row.FindControl("txtPostDesc");
                if (txtPostDesc != null)
                {
                    txtPostDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtPostDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (imgbtnDelete != null)
                { imgbtnDelete.Visible = false; }
            }
            else
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (imgbtnDelete != null)
                { imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');"; }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvPost.ShowFooter = false;
            }
            else
            {
                var ddlPost = (DropDownList)e.Row.FindControl("ddlPost");
                FillddlPost(ddlPost);

                var imgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (imgbtnAdd != null)
                {
                    imgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }

                var txtPostCode = (TextBox)e.Row.FindControl("txtPostCode");
                if (txtPostCode != null)
                {
                    txtPostCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtPostCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                var txtPostDesc = (TextBox)e.Row.FindControl("txtPostDesc");
                if (txtPostDesc != null)
                {
                    txtPostDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtPostDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvPost_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objSales = new BL.Sales();
        // To Insert a New Row
        var txtPostCode = (TextBox)gvPost.FooterRow.FindControl("txtPostCode");
        var txtPostDesc = (TextBox)gvPost.FooterRow.FindControl("txtPostDesc");
        var txtShrtPostCode = (TextBox)gvPost.FooterRow.FindControl("txtShrtPostCode");
        var txtPostPhone = (TextBox)gvPost.FooterRow.FindControl("txtPostPhone");
        var txtPostNo = (TextBox)gvPost.FooterRow.FindControl("txtPostNo");

        if (System.Text.RegularExpressions.Regex.IsMatch(txtPostNo.Text,"[^0-9]"))
        {
            Show("Please enter only numbers.");
            txtPostNo.Focus();
            txtPostNo.Text = "";
            return;
        }

        if (txtPostNo.Text == string.Empty)
        {
            txtPostNo.Text = @"0";
        }

        
        if (e.CommandName == "Add")
        {
            if (ddlClient.SelectedItem.Value != string.Empty && ddlAsmt.SelectedItem.Value != string.Empty && txtPostCode.Text != string.Empty)
            {
                DataSet ds = objSales.PostAdd(ddlClient.SelectedItem.Value,
                    ddlAsmt.SelectedItem.Value, txtPostCode.Text, txtPostDesc.Text,
                    BaseUserID, txtShrtPostCode.Text,
                    txtPostPhone.Text, txtPostNo.Text);
                gvPost.EditIndex = -1;
                FillgvPost();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
        }
        if (e.CommandName == "Reset")
        {
            txtPostCode.Text = string.Empty;
            txtPostDesc.Text = string.Empty;
            txtShrtPostCode.Text = string.Empty;
            txtPostNo.Text = string.Empty;
            txtPostPhone.Text = string.Empty;
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvPost_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPost.EditIndex = e.NewEditIndex;
        FillgvPost();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvPost_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPost.EditIndex = -1;
        FillgvPost();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvPost_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objSales = new BL.Sales();
        var lblgvPostCode = (Label)gvPost.Rows[e.RowIndex].FindControl("lblgvPostCode");
        var txtPostDesc = (TextBox)gvPost.Rows[e.RowIndex].FindControl("txtPostDesc");
        var lblgvShrtPostCode = (Label)gvPost.Rows[e.RowIndex].FindControl("lblgvShrtPostCode");
        var txtPostPhone = (TextBox)gvPost.Rows[e.RowIndex].FindControl("txtPostPhone");
        var txtPostNo = (TextBox)gvPost.Rows[e.RowIndex].FindControl("txtPostNo");

        if (System.Text.RegularExpressions.Regex.IsMatch(txtPostNo.Text, "[^0-9]"))
        {


            Show("Please enter only numbers.");
            txtPostNo.Focus();
            txtPostNo.Text = string.Empty;
            return;

        }

        if (txtPostNo.Text == string.Empty)
        {
            txtPostNo.Text = @"0";
        }

        DataSet ds = objSales.PostUpdate(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value, lblgvPostCode.Text, txtPostDesc.Text, BaseUserID, lblgvShrtPostCode.Text, txtPostPhone.Text, txtPostNo.Text);
        gvPost.EditIndex = -1;
        FillgvPost();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvPost_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objSales = new BL.Sales();
        var hfPostAutoID = (HiddenField)gvPost.Rows[e.RowIndex].FindControl("HFPostAutoID");
        DataSet ds = objSales.PostDelete(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value, hfPostAutoID.Value);
        FillgvPost();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvPost_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPost.PageIndex = e.NewPageIndex;
        gvPost.EditIndex = -1;
        FillgvPost();
    }


    #endregion

    #region Controles
    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Sales/ClientDetailsList.aspx?ClientCode=" + ddlClient.SelectedItem.Value);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtClientCode_TextChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < ddlClient.Items.Count; i++)
        //{
        //    if (ddlClient.Items[i].Value == txtClientCode.Text)
        //    {
        //        ddlClient.SelectedIndex = i;
        //        FillddlAsmt();
        //    }
        //}
        try
        {
            ddlClient.SelectedValue = txtClientCode.Text;
            FillddlAsmt();
        }
        catch (Exception){}
     

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClientCode.Text = string.Empty;
        FillddlClient();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClientCode.Text = string.Empty;
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvPost();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPost_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlPost = (DropDownList)sender;
        SetPostFromDropDown(ddlPost);
    }
    /// <summary>
    /// Sets the post from drop down.
    /// </summary>
    /// <param name="ddlPost">The DDL post.</param>
    protected void SetPostFromDropDown(DropDownList ddlPost)
    {
        if (gvPost != null && gvPost.FooterRow != null)
        {
            var txtPostCode = (TextBox) gvPost.FooterRow.FindControl("txtPostCode");
            var txtShrtPostCode = (TextBox) gvPost.FooterRow.FindControl("txtShrtPostCode");
            var txtPostDesc = (TextBox) gvPost.FooterRow.FindControl("txtPostDesc");
            if (txtPostCode != null && txtShrtPostCode != null && txtPostDesc != null)
            {
                if (ddlPost.SelectedItem.Value == string.Empty)
                {
                    txtPostCode.Enabled = true;
                    txtShrtPostCode.Enabled = true;
                    txtPostDesc.Enabled = true;

                    txtPostCode.Text = "";
                    txtShrtPostCode.Text = "";
                    txtPostDesc.Text = "";
                }
                else
                {
                    var objSale = new BL.Sales();
                    DataSet ds = objSale.PosGet(ddlPost.SelectedItem.Value);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        txtPostCode.Text = ddlPost.SelectedItem.Value;
                        txtShrtPostCode.Text = ds.Tables[0].Rows[0]["ShtPostDesc"].ToString();
                        txtPostDesc.Text = ddlPost.SelectedItem.Text;
                    }
                    else
                    {
                        txtPostCode.Text = ddlPost.SelectedItem.Value;
                        txtShrtPostCode.Text = ddlPost.SelectedItem.Value;
                        txtPostDesc.Text = ddlPost.SelectedItem.Text;
                    }

                    txtPostCode.Enabled = false;
                    txtShrtPostCode.Enabled = false;
                    txtPostDesc.Enabled = false;
                }
            }
        }
    }
    #endregion
}