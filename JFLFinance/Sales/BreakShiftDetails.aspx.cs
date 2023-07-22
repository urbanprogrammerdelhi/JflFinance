// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 16-04-2014

// ***********************************************************************
// <copyright file="BreakShiftDetails.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using BL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Class Sales_BreakShiftDetails.
/// </summary>
public partial class Sales_BreakShiftDetails : BasePage //System.Web.UI.Page
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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
    #region Page
    ///// <summary>
    ///// Handles the PreInit event of the Page control.
    ///// </summary>
    ///// <param name="sender">The source of the event.</param>
    ///// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    //private void Page_PreInit(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["AddPost"] != null && Request.QueryString["AddPost"] == "Add")
    //    {
    //        MasterPageFile = "~/MasterPage/MasterSearch.master";
    //    }
    //    else
    //    {
    //        MasterPageFile = "~/MasterPage/MasterPage.master";
    //    }
    //}
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
                ViewState["BreakDetails"] = null;
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
    /// Fillgvs the post.
    /// </summary>
    protected void FillgvPost()
    {
        var objSales = new BL.Sales();
        var dtflag = 1;
        DataSet ds;
        if (ViewState["BreakDetails"] == null)
        {
            ds = CBLastAmendment.Checked ? objSales.BreakShiftLastAmendment(BaseLocationAutoID) : objSales.BreakShift(BaseLocationAutoID);
            ViewState["BreakDetails"] = ds;
        }
        else
        {
            ds = (DataSet)ViewState["BreakDetails"];
        }
        if (ds == null) return;
        //to fix empety gridview
        if (ds.Tables[0].Rows.Count == 0)
        {
            dtflag = 0;
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        }
        gvPost.DataKeyNames = new[] { "LocationAutoId" };

        gvPost.DataSource = ds.Tables[0];
        gvPost.DataBind();
        //to fix empety gridview
        if (dtflag == 0)
        {
            gvPost.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// fills the client dropdown
    /// </summary>
    /// <param name="ddlClient">the ddl client</param>
    protected void FillddlClient(RadComboBox ddlClient, RadComboBox AsmtId, RadComboBox PostCode)
    {
        var objSale = new BL.Sales();
        var ds = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID) : objSale.ClientsMappedToLocationGet(BaseLocationAutoID, "ALL", string.Empty, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        ddlClient.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientCodeName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };

            ddlClient.Items.Insert(0, li);
            var item1 = ddlClient.Items.FindItemByValue("ALL");
            item1.Checked = true;
            FillddlAsmt(ddlClient, AsmtId, PostCode);
        }
        else
        {
            var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlClient.Items.Add(li);
            //var item1 = ddlClient.Items.FindItemByValue("ALL");
            //item1.Checked = true;
        }
    }
    /// <summary>
    /// fills assignment dropdown
    /// </summary>
    /// <param name="ddlClient">the ddl client </param>
    /// <param name="ddlAsmt">the ddl asmt</param>
    /// <param name="ddlPost">the ddl post</param>
    protected void FillddlAsmt(RadComboBox ddlClient1, RadComboBox ddlAsmt, RadComboBox ddlPost)
    {
       
        var objSale = new BL.Sales();
        ddlAsmt.Items.Clear();
        var ddlClient = ddlClient1.CheckedItems;
        string clientCode = string.Empty;
        //For Branchif (location.Count > 0)
        {
            foreach (var itemloc in ddlClient)
            {
                clientCode = clientCode + itemloc.Value + ",";
            }
        }

        if (clientCode.Contains("ALL"))
        {
            ddlPost.Items.Clear();
            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            var mi = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmt.Items.Insert(0, mi);
            var item1 = ddlAsmt.Items.FindItemByValue("ALL");
            item1.Checked = true;
            ddlPost.Items.Insert(0, li);
            var item = ddlPost.Items.FindItemByValue("ALL");
            item.Checked = true;
            return;
        }

        var ds = objSale.GetAssignmentDetails(BaseLocationAutoID, clientCode, "ALL", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
     
        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAsmt.DataSource = ds.Tables[0];
            ddlAsmt.DataTextField = "AsmtIDAddress";
            ddlAsmt.DataValueField = "AsmtIDValue";
            ddlAsmt.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmt.Items.Insert(0, li);
            var item1 = ddlAsmt.Items.FindItemByValue("ALL");
            item1.Checked = true;


            FillddlPost(ddlClient1, ddlAsmt, ddlPost);
        }
        else
        {
            var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlAsmt.Items.Add(li);
            ddlPost.Items.Clear();
            ddlPost.Items.Add(li);
            //var item1 = ddlAsmt.Items.FindItemByValue("ALL");
            //item1.Checked = true;
        }
    }

    /// <summary>
    /// Fillddls the post.
    /// </summary>
    /// <param name="ddlAsmt">The DDL Asmt.</param>
    /// <param name="ddlPost">The DDL post.</param>
    /// <param name="ddlClient">The DDl Client</param>
    protected void FillddlPost(RadComboBox ddlClient, RadComboBox ddlAsmt, RadComboBox ddlPost)
    {
        ddlPost.Items.Clear();
        var asmt = ddlAsmt.CheckedItems;

        string asmtID = string.Empty;
        //For Branchif (location.Count > 0)
        {
            foreach (var itemloc in asmt)
            {
                asmtID = asmtID + itemloc.Value + ",";
            }
        }

        if (asmtID.Contains("ALL"))
        {
            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlPost.Items.Insert(0, li);
            var item1 = ddlPost.Items.FindItemByValue("ALL");
            item1.Checked = true;
            return;
        }
        var objSale = new BL.Sales();
        var ds = objSale.FillPostBasedOnClientAndAssignment(asmtID);
        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlPost.DataSource = ds.Tables[0];
            ddlPost.DataTextField = "PostDesc";
            ddlPost.DataValueField = "ValueField";
            ddlPost.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlPost.Items.Insert(0, li);
            var item1 = ddlPost.Items.FindItemByValue("ALL");
            item1.Checked = true;
        }
        else
        {
                var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                ddlPost.Items.Add(li);
                //var item1 = ddlPost.Items.FindItemByValue("ALL");
                //item1.Checked = true;
        }
    }
    #endregion
    #region GridView Commands Events

    
    /// <summary>
    /// Handles the RowDataBound event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void GvPostRowDataBound(object sender, GridViewRowEventArgs e)
    {
        var lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            var serialNo = gvPost.PageIndex * gvPost.PageSize + int.Parse(e.Row.RowIndex.ToString());
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
            var imgbtnEdit = (ImageButton)e.Row.FindControl("imgbtnEdit");

            var imgbtnDelete = (ImageButton)e.Row.FindControl("imgbtnDelete");
            var hfMaxAmendNoStatus = (HiddenField)e.Row.FindControl("hfMaxAmendNoStatus");
            if (imgbtnDelete != null)
            {
                imgbtnDelete.Attributes["onclick"] = "javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
            }
            if (hfMaxAmendNoStatus != null)
            {
                if (hfMaxAmendNoStatus.Value != "MaxAmendNo")
                {
                    if (imgbtnEdit != null)
                    { imgbtnEdit.Visible = false; }

                    if (imgbtnDelete != null)
                    {
                        imgbtnDelete.Visible = false;
                    }
                }
            }

            
            if (IsModifyAccess == false)
            {
              
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
                var txtShift = (TextBox)e.Row.FindControl("txtShift");
                if (txtShift != null)
                {
                    txtShift.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    txtShift.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                }
                var txtBreakHours = (TextBox)e.Row.FindControl("txtBreakHours");

                if (txtBreakHours != null)
                {
                    txtBreakHours.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtBreakHours.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                if (imgbtnDelete != null)
                { imgbtnDelete.Visible = false; }
            }
        }

      
        switch (e.Row.RowType)
        {
            case DataControlRowType.Footer:
                if (IsWriteAccess == false)
                {
                    gvPost.ShowFooter = false;
                }
                else
                {
                    var ddlClient = (RadComboBox)e.Row.FindControl("ddlClient");
                    var ddlAsmt = (RadComboBox)e.Row.FindControl("ddlAsmt");
                    var ddlPost = (RadComboBox)e.Row.FindControl("ddlPost");
                    FillddlClient(ddlClient, ddlAsmt, ddlPost);
                    
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
                    var txtShift = (TextBox)e.Row.FindControl("txtShift");
                    if (txtShift != null)
                    {
                        txtShift.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtShift.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }

                    var txtBreakHours = (TextBox)e.Row.FindControl("txtBreakHours");
                    if (txtBreakHours != null)
                    {
                        txtBreakHours.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                        txtBreakHours.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    }
                }
                break;
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void GvPostRowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Add":
                {
                    var objSales = new BL.Sales();
                    var shift = (TextBox)gvPost.FooterRow.FindControl("txtShift");
                    var Break = (TextBox)gvPost.FooterRow.FindControl("txtBreakHours");
                    var btnExport = (Button)gvPost.FooterRow.FindControl("btnExport");
                    var ddlClient = (RadComboBox)gvPost.FooterRow.FindControl("ddlClient");
                    var ddlPost = (RadComboBox)gvPost.FooterRow.FindControl("ddlPost");
                    var ddlAsmt = (RadComboBox)gvPost.FooterRow.FindControl("ddlAsmt");


                    if (double.Parse(shift.Text.Trim()) * 60 < double.Parse(Break.Text.Trim()))
                    {  

                
                        Show(ResourceValueOfKey_Get("InvalidTime"));
                        Break.Text = string.Empty;
                        return;
                    }
                    //if (System.Text.RegularExpressions.Regex.IsMatch(txtPostNo.Text.ToString(), "[^0-9]"))
                    //{


                    //    Show("Please enter only numbers.");
                    //    txtPostNo.Focus();
                    //    txtPostNo.Text = "";
                    //    return;

                    //}

                    var clientDropDown = ddlClient.CheckedItems;

                    string clientCode = string.Empty;
                    //For Branchif (location.Count > 0)
                    {
                        foreach (var itemloc in clientDropDown)
                        {
                            clientCode = clientCode + itemloc.Value + ",";
                        }
                    }

                    var asmtDropDown = ddlAsmt.CheckedItems;

                    string asmtId = string.Empty;
                    //For Branchif (location.Count > 0)
                    {
                        foreach (var itemloc in asmtDropDown)
                        {
                            asmtId = asmtId + itemloc.Value + ",";
                        }
                    }

                    var postDropDown = ddlPost.CheckedItems;

                    string postCode = string.Empty;
                    //For Branchif (location.Count > 0)
                    {
                        foreach (var itemloc in postDropDown)
                        {
                            postCode = postCode + itemloc.Value + ",";
                        }
                    }

                    if (clientCode != string.Empty && asmtId != string.Empty && postCode != string.Empty)
                    {

                        var ds = objSales.BreakShiftAdd(BaseLocationAutoID, clientCode, asmtId, postCode, double.Parse(shift.Text), double.Parse(Break.Text), BaseUserID);
                        //gvPost.EditIndex = -1;
                        //FillgvPost();
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "151")
                            {

                                btnExport.Enabled = true;
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                            }
                            else if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "4")
                            {

                                DisplayMessage(lblErrorMsg,"151");

                            }
                            else
                            {
                                gvPost.EditIndex = -1;
                                ViewState["BreakDetails"] = null;
                                FillgvPost();
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }
                        }
                    }
                }
                break;
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
    protected void GvPostRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvPost.EditIndex = e.NewEditIndex;
       // ViewState["BreakDetails"] = null;
        FillgvPost();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void GvPostRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPost.EditIndex = -1;

        FillgvPost();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void GvPostRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objSales = new BL.Sales();
        var postAutoID = (HiddenField)gvPost.Rows[e.RowIndex].FindControl("hfPostAutoID");
        var asmtID = (HiddenField)gvPost.Rows[e.RowIndex].FindControl("hfAsmtID");
        var clientCode = (HiddenField)gvPost.Rows[e.RowIndex].FindControl("hfClientCode");
        var Break = (TextBox)gvPost.Rows[e.RowIndex].FindControl("txtEditBreakHours");
        var lblAmendNo = (Label)gvPost.Rows[e.RowIndex].FindControl("lblAmendNo");
        var shift = (Label)gvPost.Rows[e.RowIndex].FindControl("lblgvShift");
        var btnExportEdit = (Button)gvPost.Rows[e.RowIndex].FindControl("btnExportEdit");

        if (double.Parse(shift.Text.Trim()) * 60 < double.Parse(Break.Text.Trim()))
        {

           
            Show(ResourceValueOfKey_Get("InvalidTime"));
            Break.Text = string.Empty;
            return;
        }

        var ds = objSales.BreakShiftUpdate(BaseLocationAutoID, clientCode.Value, asmtID.Value, postAutoID.Value, double.Parse(shift.Text), double.Parse(Break.Text), Convert.ToInt32(lblAmendNo.Text), BaseUserID);
     
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "151")
            {
                
                btnExportEdit.Enabled = true;
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }
            else if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "4")
            {

                DisplayMessage(lblErrorMsg, "151");

            }
            else
            {
                gvPost.EditIndex = -1;
               ViewState["BreakDetails"] = null;
                FillgvPost();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void GvPostPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ViewState["BreakDetails"] = null;
        gvPost.PageIndex = e.NewPageIndex;
        gvPost.EditIndex = -1;

        FillgvPost();
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void GvPostRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objSales = new BL.Sales();
        var ds = new DataSet();
        var postAutoId = (HiddenField)gvPost.Rows[e.RowIndex].FindControl("hfPostAutoID");
        var asmtId = (HiddenField)gvPost.Rows[e.RowIndex].FindControl("hfAsmtID");
        var clientCode = (HiddenField)gvPost.Rows[e.RowIndex].FindControl("hfClientCode");
        var Break = (Label)gvPost.Rows[e.RowIndex].FindControl("lblgvBreakHours");
        var lblAmendNo = (Label)gvPost.Rows[e.RowIndex].FindControl("lblAmendNo");
        var shift = (Label)gvPost.Rows[e.RowIndex].FindControl("lblgvShift");
        ds = objSales.BreakShiftDelete(BaseLocationAutoID, clientCode.Value, asmtId.Value, postAutoId.Value,
            double.Parse(shift.Text), double.Parse(Break.Text), Convert.ToInt32(lblAmendNo.Text));
        ViewState["BreakDetails"] = null;
        gvPost.EditIndex = -1;

        FillgvPost();
    }

    #endregion
    #region Controls

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DdlClientSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        var ddlClient = (RadComboBox)sender;
        var ddlAsmt = (RadComboBox)gvPost.FooterRow.FindControl("ddlAsmt");
        var ddlPost = (RadComboBox)gvPost.FooterRow.FindControl("ddlPost");
        FillddlAsmt(ddlClient, ddlAsmt, ddlPost);
               
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DdlAsmtSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        var ddlAsmt = (RadComboBox)sender;
        var ddlClient = (RadComboBox)gvPost.FooterRow.FindControl("ddlClient");
        var ddlPost = (RadComboBox)gvPost.FooterRow.FindControl("ddlPost");
        FillddlPost(ddlClient, ddlAsmt, ddlPost);
    }
    ///// <summary>
    ///// Handles the SelectedIndexChanged event of the ddlPost control.
    ///// </summary>
    ///// <param name="sender">The source of the event.</param>
    ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    //protected void DdlPostSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    var ddlPost = (RadComboBox)sender;
    //}

    /// <summary>
    /// Handles the button  event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void BtnExportClick(object sender, EventArgs e)
    {
        //Button target = (Button)sender;
        //GridViewRow gvPost = (GridViewRow)target.NamingContainer;

        
        var txtShift = (TextBox)gvPost.FooterRow.FindControl("txtShift");
        var txtBreak = (TextBox)gvPost.FooterRow.FindControl("txtBreakHours");

        var ddlclient = (RadComboBox)gvPost.FooterRow.FindControl("ddlClient");
        var ddlAsmt = (RadComboBox)gvPost.FooterRow.FindControl("ddlAsmt");
        var ddlPost = (RadComboBox)gvPost.FooterRow.FindControl("ddlPost");

        var clientDropDown = ddlclient.CheckedItems;

        string clientCode = string.Empty;
        //For Branchif (location.Count > 0)
        {
            foreach (var itemloc in clientDropDown)
            {
                clientCode = clientCode + itemloc.Value + ",";
            }
        }

        var asmtDropDown = ddlAsmt.CheckedItems;

        string asmtId = string.Empty;
        //For Branchif (location.Count > 0)
        {
            foreach (var itemloc in asmtDropDown)
            {
                asmtId = asmtId + itemloc.Value + ",";
            }
        }

        var postDropDown = ddlPost.CheckedItems;

        string postCode = string.Empty;
        //For Branchif (location.Count > 0)
        {
            foreach (var itemloc in postDropDown)
            {
                postCode = postCode + itemloc.Value + ",";
            }
        }

        string url = "../Sales/BreakHourShiftExport.aspx?Location=" + BaseLocationAutoID + "&Client=" + clientCode +
                    "&Asmt=" + asmtId +
                    "&Post=" + postCode +
                    "&BreakShift=" + txtShift.Text +
                    "&BreakHours=" + txtBreak.Text +
                    "&Status=" + "Footer";

        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,resizable=yes,width=1200px' );", true);

    }
    /// <summary>
    /// Handles the button  event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void BtnExportEditClick(object sender, EventArgs e) // EventArgs e)
    {
        var target = (Button)sender;
        var row = (GridViewRow)target.NamingContainer;
        var clientCode = (HiddenField)gvPost.Rows[row.RowIndex].FindControl("hfClientCode");
        var asmtID = (HiddenField)gvPost.Rows[row.RowIndex].FindControl("hfAsmtID");
        var postAutoID = (HiddenField)gvPost.Rows[row.RowIndex].FindControl("hfPostAutoID");
        var txtEditBreakHours = (TextBox)gvPost.Rows[row.RowIndex].FindControl("txtEditBreakHours");
        var lblgvShift = (Label)gvPost.Rows[row.RowIndex].FindControl("lblgvShift");

        var url = "../Sales/BreakHourShiftExport.aspx?Location=" + BaseLocationAutoID + "&Client=" + clientCode.Value.Trim() +
                     "&Asmt=" + asmtID.Value.Trim() +
                     "&Post=" + postAutoID.Value.Trim() +
                     "&BreakShift="+lblgvShift.Text+
                     "&BreakHours=" + txtEditBreakHours.Text +
                    "&Status=" + "Edit";

        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,resizable=yes,width=1200px' );", true);

    }

    /// <summary>
    /// Handles the CheckedChanged event of the CBLastAmendment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">instance containing the event data.</param>
    protected void CbLastAmendmentCheckedChanged(object sender, EventArgs e)
    {
        ViewState["BreakDetails"] = null;
        FillgvPost();
    }
    /// <summary>
    /// button search click
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">instance containing the event data.</param>
    protected void BtnSearchClick(object sender, EventArgs e)
    {
        if (txtSearch.Text == string.Empty)
        {
            var ds = (DataSet)ViewState["BreakDetails"];
            gvPost.DataSource = ds;
            gvPost.DataBind();
        }
        else
        {
            Search(txtSearch, ddlSearch);
        }
    }

    /// <summary>
    /// searching the data
    /// </summary>
    /// <param name="textSearch">the txt search </param>
    /// <param name="dropdownSearch">the dropdown search</param>
    private void Search(TextBox textSearch, DropDownList dropdownSearch)
    {
        //if (txtSearch == null) throw new ArgumentNullException("txtSearch");
        //if (ddlSearch == null) throw new ArgumentNullException("ddlSearch");
        var ds = (DataSet)ViewState["BreakDetails"];
        //ds = CBLastAmendment.Checked ? objSales.BreakShiftLastAmendment(BaseLocationAutoID) : objSales.BreakShift(BaseLocationAutoID);
        var dv = new DataView(ds.Tables[0]);
        var searchItem = "%" + textSearch.Text + "%";
        switch (dropdownSearch.SelectedValue)
        {
            case "ClientCode":
                {
                    var filterCondition = "[ClientName] LIKE '" + (searchItem) + "'";
                    dv.RowFilter = filterCondition;
                }
                break;
            case "AsmtID":
                {
                    var filterCondition = "[AsmtName] LIKE '" + (searchItem) + "'";
                    dv.RowFilter = filterCondition;
                }
                break;
            default:
                {
                    var filterCondition = "[PostDesc] LIKE '" + (searchItem) + "'";
                    dv.RowFilter = filterCondition;
                }
                break;
        }

        var dt = dv.ToTable();
        gvPost.DataSource = dt;
        gvPost.DataBind();

        var dsBreak = new DataSet();
        dsBreak.Tables.Add(dt);

        ViewState["BreakDetails"] = dsBreak;
    }

    protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["BreakDetails"] = null;
        txtSearch.Text = string.Empty;
        FillgvPost();
    }
    #endregion

}