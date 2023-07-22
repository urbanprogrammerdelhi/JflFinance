// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 01-16-2014
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ClientPostOTFactor.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
 using System;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_ClientPostOTFactor.
/// </summary>
public partial class Sales_ClientPostOTFactor : BasePage //System.Web.UI.Page
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
    #region Page
    /// <summary>
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["AddPost"] != null && Request.QueryString["AddPost"] == "Add")
        {
            MasterPageFile = "~/MasterPage/MasterSearch.master";
        }
        else
        {
            MasterPageFile = "~/MasterPage/MasterPage.master";
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
                FillddlAsmt();
                FillgvPost();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }
    #endregion
    #region Binding
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaId()
    {
            FillddlClient();
   
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        var objSale = new BL.Sales();
        var ds = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID) : objSale.ClientsMappedToLocationGet(BaseLocationAutoID,"ALL", txtClientCode.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
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
            var li = new ListItem{Text = string.Format("{0}", Resources.Resource.NoDataToShow), Value = ""};
            ddlClient.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        var objSale = new BL.Sales();
        var ds = objSale.ClientDetailsGet(BaseLocationAutoID, ddlClient.SelectedItem.Value,"ALL", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            //foreach (DataRow oRow in ds.Tables[0].Rows)
            //{

            //    if (oRow["IsBillable"].ToString() == "True")
            //    {
            //        ds.Tables[0].Rows.Remove(oRow);
            //    }
            //}


            var drArrCheck = ds.Tables[0].Select("IsBillable = True");
            foreach (var drCheck in drArrCheck)
            {
                ds.Tables[0].Rows.Remove(drCheck);
            }

            ddlAsmt.DataSource = ds.Tables[0];
            ddlAsmt.DataTextField = "AsmtId";
            ddlAsmt.DataValueField = "AsmtId";
            ddlAsmt.DataBind();

            FillgvPost();
        }
        else
        {
            var li = new ListItem {Text = @Resources.Resource.NoDataToShow , Value = ""};
            ddlAsmt.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillgvs the post.
    /// </summary>
    protected void FillgvPost()
    {
        var objSales = new BL.Sales();
        int dtflag = 1;
        var ds = CBLastAmendment.Checked ? objSales.PostOTFactorGetLastAmendement(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value) : objSales.PostOTFactorGetAll(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value);
        //to fix empety gridview
        if (ds.Tables[0].Rows.Count == 0)
        {
            dtflag = 0;
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        }
        gvPost.DataKeyNames = new[] { "PostAutoId" };
        gvPost.DataSource = ds.Tables[0];
        gvPost.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvPost.Rows[0].Visible = false;
        }
        var lblgvClientCode = (Label)gvPost.FooterRow.FindControl("lblgvClientCode");
        var lblgvAsmtId = (Label)gvPost.FooterRow.FindControl("lblgvAsmtId");
        if (lblgvClientCode != null && lblgvAsmtId != null)
        {
            lblgvClientCode.Text = ddlClient.SelectedItem.Value;
            lblgvAsmtId.Text = ddlAsmt.SelectedItem.Value;
        }
    }
    /// <summary>
    /// Fillddls the post.
    /// </summary>
    /// <param name="ddlPost">The DDL post.</param>
    protected void FillddlPost(DropDownList ddlPost)
    {
        var objSale = new BL.Sales();
        var ds = objSale.PostOTFactorFillPostDesc(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value);


        if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
        {
            var li = new ListItem {Value = ""};
            //li.Text = Resources.Resource.AddNew;
            ddlPost.Items.Add(li);
        }
        else
        {
            ddlPost.DataSource = ds.Tables[0];
            ddlPost.DataTextField = "PostDesc";
            ddlPost.DataValueField = "PostCode";
            ddlPost.DataBind();

            var li = new ListItem {Value = ""};
            //li.Text = Resources.Resource.AddNew;
            ddlPost.Items.Insert(0, li);
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
            int serialNo = gvPost.PageIndex * gvPost.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        //if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        //{ gvPost.Columns[5].Visible = false; }
        //else
        //{ gvPost.Columns[5].Visible = true; }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            



            if (IsModifyAccess == false)
            {
                var imgbtnEdit = (ImageButton)e.Row.FindControl("imgbtnEdit");
                if (imgbtnEdit != null)
                { imgbtnEdit.Visible = false; }
            }
            else
            {
                var imgbtnUpdate = (ImageButton)e.Row.FindControl("imgbtnUpdate");
                if (imgbtnUpdate != null)
                {
                    imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }
                //System.Web.UI.WebControls.TextBox txtPostDesc = (System.Web.UI.WebControls.TextBox)e.Row.FindControl("txtPostDesc");
                //if (txtPostDesc != null)
                //{
                //    txtPostDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //    txtPostDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //}
                var txtOtFactor = (TextBox)e.Row.FindControl("txtOtFactor");
                if (txtOtFactor != null)
                {
                    txtOtFactor.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    txtOtFactor.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("imgbtnDelete");
                if (imgbtnDelete != null)
                { imgbtnDelete.Visible = false; }
            }
            else
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("imgbtnDelete");
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

                var imgbtnAdd = (ImageButton)e.Row.FindControl("imgbtnAdd");
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
                //System.Web.UI.WebControls.TextBox txtPostDesc = (System.Web.UI.WebControls.TextBox)e.Row.FindControl("txtPostDesc");
                //if (txtPostDesc != null)
                //{
                //    txtPostDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //    txtPostDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //}
                var txtOtFactor = (TextBox)e.Row.FindControl("txtOtFactor");
                if (txtOtFactor != null)
                {
                    txtOtFactor.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    txtOtFactor.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
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
        var txtShrtPostCode = (TextBox)gvPost.FooterRow.FindControl("txtShrtPostCode");
        var txtftrEffectiveFrom = (TextBox)gvPost.FooterRow.FindControl("txtftrEffectiveFrom");
       var txtftrEffectiveTo = (TextBox)gvPost.FooterRow.FindControl("txtftrEffectiveTo");
       var txtElementCode = (TextBox)gvPost.FooterRow.FindControl("txtElementCode");
       var txtPayrollCode = (TextBox)gvPost.FooterRow.FindControl("txtPayrollCode");
        var txtOtFactor = (TextBox)gvPost.FooterRow.FindControl("txtOtFactor");
       
        if (e.CommandName == "Add")
        {
            if (txtftrEffectiveFrom.Text == "")
            {
                Show(Resources.Resource.PleaseinputWithEffectiveFromDate);
                txtftrEffectiveFrom.Focus();
                return;
            }
            
            if (txtftrEffectiveFrom.Text != "" && txtftrEffectiveTo.Text != "")
            {
                if (Convert.ToDateTime(txtftrEffectiveFrom.Text) > Convert.ToDateTime(txtftrEffectiveTo.Text))
                {
                    Show(Resources.Resource.FromDateCannotGrtToDate);
                    txtftrEffectiveTo.Focus();
                    return;
                }
            }

            if (txtftrEffectiveTo.Text == "")
            {
                txtftrEffectiveTo.Text = @"01-Jan-1900";
            }



            if (ddlClient.SelectedItem.Value != "" && ddlAsmt.SelectedItem.Value != "" && txtPostCode.Text != "")
            {
                var Amendno=1;

                var ds = objSales.PostOTFactorAdd(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value,Convert.ToInt32(txtShrtPostCode.Text),
                                                      Convert.ToDateTime(txtftrEffectiveFrom.Text), Convert.ToDateTime(txtftrEffectiveTo.Text), txtElementCode.Text,txtPayrollCode.Text, Convert.ToDouble(txtOtFactor.Text), Amendno, BaseUserID);
                gvPost.EditIndex = -1;
                FillgvPost();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
        }
        //if (e.CommandName == "Reset")
        //{
        //    txtPostCode.Text = "";
        //   // txtPostDesc.Text = "";
        //    txtShrtPostCode.Text = "";
        //    txtPostNo.Text = "";
        //    txtPostPhone.Text = "";
        //}
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
        var lblgvShrtPostCode = (Label)gvPost.Rows[e.RowIndex].FindControl("lblgvShrtPostCode");
        var txtEditEffectiveTo = (TextBox)gvPost.Rows[e.RowIndex].FindControl("txtEditEffectiveTo");
        var txtEditElementCode = (TextBox)gvPost.Rows[e.RowIndex].FindControl("txtEditElementCode");
        var txtEditPayrollCode = (TextBox)gvPost.Rows[e.RowIndex].FindControl("txtEditPayrollCode");
        var txtEditOtFactor = (TextBox)gvPost.Rows[e.RowIndex].FindControl("txtEditOtFactor");
        var lblAmendNo = (Label)gvPost.Rows[e.RowIndex].FindControl("lblAmendNo");
        var lblEffectiveFrom = (Label)gvPost.Rows[e.RowIndex].FindControl("lblEffectiveFrom");
        
        
        //if (System.Text.RegularExpressions.Regex.IsMatch(txtPostNo.Text.ToString(), "[^0-9]"))
        //{


        //    Show("Please enter only numbers.");
        //    txtPostNo.Focus();
        //    txtPostNo.Text = "";
        //    return;

        //}

        if (lblEffectiveFrom.Text != "" && txtEditEffectiveTo.Text != "")
        {
            if (Convert.ToDateTime(lblEffectiveFrom.Text) > Convert.ToDateTime(txtEditEffectiveTo.Text))
            {
                Show(Resources.Resource.FromDateCannotGrtToDate);
                txtEditEffectiveTo.Focus();
                return;
            }
        }

        if (txtEditEffectiveTo.Text == "")
        {
            txtEditEffectiveTo.Text = @"01-Jan-1900";
        }


        var ds = objSales.PostOTFactorUpdate(Convert.ToInt32(lblgvShrtPostCode.Text), Convert.ToDateTime(txtEditEffectiveTo.Text), txtEditElementCode.Text, txtEditPayrollCode.Text,Convert.ToDouble(txtEditOtFactor.Text),Convert.ToInt32(lblAmendNo.Text));
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
        var hfPostAutoID = (HiddenField)gvPost.Rows[e.RowIndex].FindControl("hfPostAutoID");
        var ds = objSales.PostDelete(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value, hfPostAutoID.Value);
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
    #region Controls
    //protected void imgBack_Click(object sender, ImageClickEventArgs e)
    //{
    //    Response.Redirect("../Sales/ClientDetailsList.aspx?ClientCode=" + ddlClient.SelectedItem.Value.ToString());
    //}
    /// <summary>
    /// Handles the TextChanged event of the txtClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtClientCode_TextChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < ddlClient.Items.Count; i++)
        {
            if (ddlClient.Items[i].Value == txtClientCode.Text)
            {
                ddlClient.SelectedIndex = i;
                FillddlAsmt();
            }
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
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
            //TextBox txtPostDesc = (TextBox) gvPost.FooterRow.FindControl("txtPostDesc");
            if (txtPostCode != null && txtShrtPostCode != null )//&& txtPostDesc != null)
            {
                if (ddlPost.SelectedItem.Value == "")
                {
                    txtPostCode.Enabled = true;
                    txtShrtPostCode.Enabled = true;
                  //  txtPostDesc.Enabled = true;

                    txtPostCode.Text = "";
                    txtShrtPostCode.Text = "";
                   // txtPostDesc.Text = "";
                }
                else
                {
                    var objSale = new BL.Sales();
                    //ds = objSale.PosGet(ddlPost.SelectedItem.Value.ToString());
                    var ds = objSale.PosOTFactorGet(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value,ddlPost.SelectedItem.Value);
                    
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        txtPostCode.Text = ddlPost.SelectedItem.Value;
                        txtShrtPostCode.Text = ds.Tables[0].Rows[0]["PostAutoId"].ToString();
                        //txtPostDesc.Text = ddlPost.SelectedItem.Text.ToString();
                    }
                    else
                    {
                        txtPostCode.Text = ddlPost.SelectedItem.Value;
                        txtShrtPostCode.Text = ddlPost.SelectedItem.Value;
                       // txtPostDesc.Text = ddlPost.SelectedItem.Text.ToString();
                    }

                    txtPostCode.Enabled = false;
                    txtShrtPostCode.Enabled = false;
                   // txtPostDesc.Enabled = false;
                }
            }
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtftrEffectiveFrom control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtftrEffectiveFrom_TextChanged(object sender, EventArgs e)
    {
        //var objTextBox = (TextBox)sender;
      //  var row = (GridViewRow)objTextBox.NamingContainer;
        var txtftrEffectiveFrom = (TextBox)gvPost.FooterRow.FindControl("txtftrEffectiveFrom");
        var txtftrEffectiveTo = (TextBox)gvPost.FooterRow.FindControl("txtftrEffectiveTo");


        if (txtftrEffectiveTo.Text != "")
        {
            if (DateTime.Parse(txtftrEffectiveFrom.Text) > DateTime.Parse(txtftrEffectiveTo.Text))
            {
                if (Master != null)
                {
                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("toolkitScriptManager1");
                    Show(Resources.Resource.FromDateCannotGrtToDate);
                    toolkitScriptManager1.SetFocus(txtftrEffectiveFrom);
                }
                txtftrEffectiveFrom.BackColor = System.Drawing.Color.Aqua;
                return;
            }
        }
    }


    /// <summary>
    /// Handles the TextChanged event of the txtftrEffectiveTo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtftrEffectiveTo_TextChanged(object sender, EventArgs e)
    {
       // var objTextBox = (TextBox)sender;
        //var row = (GridViewRow)objTextBox.NamingContainer;
        var txtftrEffectiveFrom = (TextBox)gvPost.FooterRow.FindControl("txtftrEffectiveFrom");
        var txtftrEffectiveTo = (TextBox)gvPost.FooterRow.FindControl("txtftrEffectiveTo");


        if (txtftrEffectiveTo.Text != "" && txtftrEffectiveFrom.Text !="")
        {
            if (DateTime.Parse(txtftrEffectiveFrom.Text) > DateTime.Parse(txtftrEffectiveTo.Text))
            {
                if (Master != null)
                {
                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("toolkitScriptManager1");
                    Show(Resources.Resource.FromDateCannotGrtToDate);
                    toolkitScriptManager1.SetFocus(txtftrEffectiveFrom);
                }
                txtftrEffectiveTo.BackColor = System.Drawing.Color.Aqua;
                return;
            }
        }
    }


    /// <summary>
    /// Handles the CheckedChanged event of the CBLastAmendment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void CBLastAmendment_CheckedChanged(object sender, EventArgs e)
    {
        FillgvPost();
    }



    #endregion
}