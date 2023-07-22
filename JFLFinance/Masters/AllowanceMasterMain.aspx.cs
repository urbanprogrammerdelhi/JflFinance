// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 01-10-2014
// Description      : AllowanceMasterMain is used to handle the event actions and communicate to and UI Screen.
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="AllowanceMasterMain.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
/// Class Masters_AllowanceMasterMain
/// </summary>
public partial class Masters_AllowanceMasterMain : BasePage
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    #region Page Functions
    /// <summary>
    /// Fuction called on Page Load.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //Page Title from resource file
                var javaScript = new StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resources.Resource.AllowanceMaster + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());
                if (IsReadAccess)
                {
                    FillgvAllowanceMaster();
                    // Set The Decimal Place System Parameter to a Hidden Field to Apply on the Numeric Values
                    hfspDecimalPlace.Value = "{0:F" + BaseDigitsAfterDecimalPlaces + "}";
                }
                else
                {
                    Response.Redirect("../UserManagement/Home.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion

    #region GridView AllowanceMaster Events
    /// <summary>
    /// Function is used to fill the gridview for Allowance Master.
    /// </summary>
    protected void FillgvAllowanceMaster()
    {
        try
        {
            var objMaster = new BL.MastersManagement();
            DataSet ds = objMaster.AllowanceMasterGetAll(BaseLocationAutoID);
            DataTable dt = ds.Tables[0];

            //to fix empty gridview
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                gvAllowanceMaster.DataSource = dt;
                gvAllowanceMaster.DataBind();
                gvAllowanceMaster.Rows[0].Visible = false;
            }
            else
            {
                gvAllowanceMaster.DataKeyNames = new string[] { "AllowanceAutoID" };
                gvAllowanceMaster.DataSource = dt;
                gvAllowanceMaster.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function used to fill Designation Drop Down List
    /// </summary>
    /// <returns>DataTable.</returns>
    protected DataTable FillddlDesignation()
    {
        var dt = new DataTable();
        var objMaster = new BL.MastersManagement();
        DataSet ds = objMaster.DesignationMasterGet(BaseCompanyCode);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            dt.Columns.Add("DesignationCode");
            dt.Columns.Add("DesignationDesc");
            dt.Rows.Add("", "All");
            for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
            {
                dt.Rows.Add(ds.Tables[0].Rows[cnt]["DesignationCode"], ds.Tables[0].Rows[cnt]["DesignationDesc"]);
            }
        }
        return dt;
    }

    /// <summary>
    /// Function called on Grid View Data Bound Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            GridViewRow objGridViewRow = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddlElementType = (DropDownList)e.Row.FindControl("ddlElementType");
                var hfElementType = (HiddenField)e.Row.FindControl("hfElementType");
                
                //Added Code to Bind DropDownList Designation on 7-Jan-2014
                var ddlDesignation = (DropDownList)e.Row.FindControl("ddlDesignation");
                var hfDesignation = (HiddenField)e.Row.FindControl("hfDesignation");
                var hfUnitType = (HiddenField)e.Row.FindControl("hfUnitType");
                var ddlUnitType = (DropDownList)e.Row.FindControl("ddlUnitType");
                if (ddlUnitType != null)
                {
                    ddlUnitType.SelectedValue = hfUnitType.Value;
                }
                //ImageButton ImgbtnAddNewlang = (ImageButton)e.Row.FindControl("ImgbtnAddNewlang");
                if (ddlDesignation != null)
                {
                    DataTable dt = FillddlDesignation();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddlDesignation.DataSource = dt;
                        ddlDesignation.DataTextField = "DesignationDesc";
                        ddlDesignation.DataValueField = "DesignationCode";
                        ddlDesignation.DataBind();
                    }
                    else
                    {
                        var li = new ListItem
                        {
                            Text = Resources.Resource.NoData,
                            Value = @"0"
                        };
                        ddlDesignation.Items.Add(li);
                    }
                    ddlDesignation.SelectedValue = hfDesignation.Value;
                }
                //End

                //Added Code to check numeric for Rate Control 
                var txtRateId = (TextBox)e.Row.FindControl("txtRateID");
                if (txtRateId != null)
                {
                    txtRateId.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    txtRateId.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                }
                //End
                if (ddlElementType != null)
                {
                    ddlElementType.SelectedValue = hfElementType.Value;
                }
                var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
                if (lblSerialNo != null)
                {
                    int serialNo = gvAllowanceMaster.PageIndex * gvAllowanceMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                    lblSerialNo.Text = Convert.ToString((serialNo + 1));
                }
                if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
                {
                    gvAllowanceMaster.Columns[5].Visible = false;
                }

                if (IsModifyAccess == false)
                {
                    var imgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                    if (imgbtnEdit != null)
                    {
                        imgbtnEdit.Visible = false;
                    }
                }
                else
                {
                    var imgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                    if (imgbtnUpdate != null)
                    {
                        imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }
                }
                if (IsDeleteAccess == false)
                {
                    var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                    if (imgbtnDelete != null)
                    {
                        imgbtnDelete.Visible = false;
                    }
                }
                else
                {
                    var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                    if (imgbtnDelete != null)
                    {
                        imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                if (IsWriteAccess == false)
                {
                    gvAllowanceMaster.ShowFooter = false;
                }
                else
                {
                    //Added Code to Bind DropDownList Designation on 7-Jan-2014
                    var ddlDesignation = (DropDownList)e.Row.FindControl("ddlDesignation");
                    //ImageButton ImgbtnAddNewlang = (ImageButton)e.Row.FindControl("ImgbtnAddNewlang");
                    if (ddlDesignation != null)
                    {
                        DataTable dt = FillddlDesignation();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            ddlDesignation.DataSource = dt;
                            ddlDesignation.DataTextField = "DesignationDesc";
                            ddlDesignation.DataValueField = "DesignationCode";
                            ddlDesignation.DataBind();
                        }
                        else
                        {
                            var li = new ListItem
                            {
                                Text = Resources.Resource.NoData,
                                Value = @"0"
                            };
                            ddlDesignation.Items.Add(li);
                        }
                    }
                    //End

                    var imgbtnAddNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                    if (imgbtnAddNew != null)
                    {
                        imgbtnAddNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                    }

                    var txtRoleCode = (TextBox)e.Row.FindControl("txtRoleCode");
                    if (txtRoleCode != null)
                    {
                        txtRoleCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                        txtRoleCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    }
                    //Added Code to check numeric for Rate Control 
                    var txtRateId = (TextBox)e.Row.FindControl("txtRateID");
                    if (txtRateId != null)
                    {
                        txtRateId.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                        txtRateId.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on Grid View Row Command Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            var objMaster = new BL.MastersManagement();
            var txtAllowanceDescription = (TextBox)gvAllowanceMaster.FooterRow.FindControl("txtAllowanceDescription");
            var txtElement = (TextBox)gvAllowanceMaster.FooterRow.FindControl("txtElement");
            var txtRateId = (TextBox)gvAllowanceMaster.FooterRow.FindControl("txtRateID");
            var ddlElementType = (DropDownList)gvAllowanceMaster.FooterRow.FindControl("ddlElementType");

            //Added New 
            var ddlDesignation = (DropDownList)gvAllowanceMaster.FooterRow.FindControl("ddlDesignation");
            var txtMeasurement = (TextBox)gvAllowanceMaster.FooterRow.FindControl("txtMeasurement");
            var txtAllowanceCode = (TextBox)gvAllowanceMaster.FooterRow.FindControl("txtAllowanceCode");
            var ddlUnitType = (DropDownList)gvAllowanceMaster.FooterRow.FindControl("ddlUnitType");
            //End

            if (e.CommandName.Equals("AddNew"))
            {
                if (string.IsNullOrEmpty(txtRateId.Text))
                {
                    txtRateId.Text = @"1.00";
                }
                DataSet ds = objMaster.AllowanceMasterInsertRecord(BaseLocationAutoID, txtAllowanceCode.Text, txtAllowanceDescription.Text, txtElement.Text, ddlElementType.SelectedValue, ddlUnitType.SelectedItem.Value, txtRateId.Text, ddlDesignation.SelectedItem.Value, txtMeasurement.Text, BaseUserID);
                if (gvAllowanceMaster.Rows.Count.Equals(gvAllowanceMaster.PageSize))
                {
                    gvAllowanceMaster.PageIndex = gvAllowanceMaster.PageCount + 1;
                }
                gvAllowanceMaster.EditIndex = -1;
                FillgvAllowanceMaster();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            if (e.CommandName.Equals("Reset"))
            {
                txtElement.Text = "";
                txtAllowanceDescription.Text = "";
                txtRateId.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on Grid View Row Edit Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvAllowanceMaster.EditIndex = e.NewEditIndex;
            FillgvAllowanceMaster();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on Grid View Row Update Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            var objMaster = new BL.MastersManagement();
            var txtAllowanceDescription = (TextBox)gvAllowanceMaster.Rows[e.RowIndex].FindControl("txtAllowanceDescription");
            var txtElement = (TextBox)gvAllowanceMaster.Rows[e.RowIndex].FindControl("txtElement");
            var ddlElementType = (DropDownList)gvAllowanceMaster.Rows[e.RowIndex].FindControl("ddlElementType");
            var txtRateId = (TextBox)gvAllowanceMaster.Rows[e.RowIndex].FindControl("txtRateID");
            var hfAllowanceAutoId = (HiddenField)gvAllowanceMaster.Rows[e.RowIndex].FindControl("hfAllowanceAutoID");
            //Added New
            var ddlDesignation = (DropDownList)gvAllowanceMaster.Rows[e.RowIndex].FindControl("ddlDesignation");
            var txtMeasurement = (TextBox)gvAllowanceMaster.Rows[e.RowIndex].FindControl("txtMeasurement");
            var lblAllowanceCode = (Label)gvAllowanceMaster.Rows[e.RowIndex].FindControl("lblAllowanceCode");
            var ddlUnitType = (DropDownList)gvAllowanceMaster.Rows[e.RowIndex].FindControl("ddlUnitType");
            //End
            if (!string.IsNullOrEmpty(txtAllowanceDescription.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(txtElement.Text))
                {
                    if(string.IsNullOrEmpty(txtRateId.Text))
                    {
                        txtRateId.Text = @"1.00";
                    }
                    DataSet ds = objMaster.AllowanceMasterUpdateRecord(BaseLocationAutoID, lblAllowanceCode.Text,
                                                                       hfAllowanceAutoId.Value,
                                                                       txtAllowanceDescription.Text, txtElement.Text,
                                                                       txtRateId.Text, ddlElementType.SelectedValue,
                                                                       ddlUnitType.SelectedItem.Value,
                                                                       ddlDesignation.SelectedItem.Value,
                                                                       txtMeasurement.Text, BaseUserID);
                    gvAllowanceMaster.EditIndex = -1;
                    FillgvAllowanceMaster();
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgElementCodeRequired;
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgAllowanceDescriptionRequired;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on Grid View Row Canceling Editing Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvAllowanceMaster.EditIndex = -1;
            FillgvAllowanceMaster();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on Grid View Row Delete Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            var objMaster = new BL.MastersManagement();
            var hfAllowanceAutoId = (HiddenField)gvAllowanceMaster.Rows[e.RowIndex].FindControl("hfAllowanceAutoID");
            DataSet ds = objMaster.AllowanceMasterDeleteRecord(hfAllowanceAutoId.Value);
            FillgvAllowanceMaster();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on Grid View on Page Change Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAllowanceMaster.PageIndex = e.NewPageIndex;
            gvAllowanceMaster.EditIndex = -1;
            FillgvAllowanceMaster();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion
}
