// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="LeaveCalendar.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class HRManagement_LeaveCalendar
/// </summary>
public partial class HRManagement_LeaveCalendar : BasePage //System.Web.UI.Page
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    #region Page Functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.LeaveCalendar ;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.LeaveCalendar + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvLeaveCalendar();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region GridView LeaveCalendar Events
    /// <summary>
    /// Fillgvs the leave calendar.
    /// </summary>
    protected void FillgvLeaveCalendar()
    {
        var objLeave = new BL.Leave();
        var ds = new DataSet();
        var dt = new DataTable();
        int dtflag;
        dtflag = 1;

        ds = objLeave.LeaveCalendarGet(BaseCompanyCode);  
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        gvLeaveCalendar.DataKeyNames = new string[] { "Leave_cal_code" };
        gvLeaveCalendar.DataSource = dt;
        gvLeaveCalendar.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {

            gvLeaveCalendar.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvLeaveCalendar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveCalendar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var ds = new DataSet();
        var objGridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                var serialNo = gvLeaveCalendar.PageIndex * gvLeaveCalendar.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvLeaveCalendar.Columns[6].Visible = false;
            }
            var txtEditFromDate = (TextBox)e.Row.FindControl("txtEditFromDate");
            var txtEditToDate = (TextBox)e.Row.FindControl("txtEditToDate");
            
            if (txtEditFromDate != null)
            {
                txtEditFromDate.Attributes.Add("readonly", "readonly");

            }
            if (txtEditToDate != null)
            {
                txtEditToDate.Attributes.Add("readonly", "readonly");

            }

            if (IsModifyAccess == false)
            {
                var ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
               
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                var ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
            if (IsDeleteAccess == false)
            {
                var ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            else
            {
                var ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
            //if (HfDesignationCode != null && ddlDesignationCode != null)
            //{
            //    ddlDesignationCode.SelectedIndex = ddlDesignationCode.Items.IndexOf(ddlDesignationCode.Items.FindByValue(HfDesignationCode.Value.ToString()));
            //}
            //else
            //{
            //    ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
            //    if (ImgbtnDelete != null)
            //    {
            //        ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
            //    }
            //}
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtftrFromDate = (TextBox)e.Row.FindControl("txtftrFromDate");
            var txtftrToDate = (TextBox)e.Row.FindControl("txtftrToDate");

            if (txtftrFromDate != null)
            {
                txtftrFromDate.Attributes.Add("readonly", "readonly");

            }
            if (txtftrToDate != null)
            {
                txtftrToDate.Attributes.Add("readonly", "readonly");

            }


            if (IsWriteAccess == false)
            {

                gvLeaveCalendar.ShowFooter = false;
            }
            else
            {
                var ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                var txtLCCode = (TextBox)e.Row.FindControl("txtLCCode");
                if (txtLCCode != null)
                {
                    txtLCCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtLCCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvLeaveCalendar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveCalendar_RowCommand(object sender, GridViewCommandEventArgs e)
    {



        var objLeave = new BL.Leave();
        var ds = new DataSet();
        var txtLCCode = (TextBox)gvLeaveCalendar.FooterRow.FindControl("txtLCCode");
        var txtFtrLCDesc = (TextBox)gvLeaveCalendar.FooterRow.FindControl("txtFtrLCDesc");
        var txtftrFromDate = (TextBox)gvLeaveCalendar.FooterRow.FindControl("txtftrFromDate");
        var txtftrToDate = (TextBox)gvLeaveCalendar.FooterRow.FindControl("txtftrToDate");
        
        if (e.CommandName.Equals("AddNew"))
        {
            if (txtFtrLCDesc.Text != "")
            {
                    if (txtftrFromDate.Text != "" && txtftrToDate.Text != "")
                    {
                        if (DateTime.Parse(txtftrFromDate.Text) < DateTime.Parse(txtftrToDate.Text))
                        {
                            ds = objLeave.LeaveCalendarInsert(BaseCompanyCode, txtLCCode.Text, txtFtrLCDesc.Text, txtftrFromDate.Text, txtftrToDate.Text, "A", BaseUserID);
                            if (gvLeaveCalendar.Rows.Count.Equals(gvLeaveCalendar.PageSize))
                            {
                                gvLeaveCalendar.PageIndex = gvLeaveCalendar.PageCount + 1;
                            }
                            gvLeaveCalendar.EditIndex = -1;
                            FillgvLeaveCalendar();
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                        else
                        {
                            lblErrorMsg.Text =  Resources.Resource.MsgEffectiveToDateShouldBeGreaterThanFromDate;
                            txtftrToDate.Text = "";
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgEnterDates;   
                    }

                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgEnterLeaveDescription;
                }

        }
        else if (e.CommandName.Equals("Reset"))
        {

            txtLCCode.Text = "";
            txtFtrLCDesc.Text = "";
            txtftrFromDate.Text = "";
            txtftrToDate.Text = "";  
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvLeaveCalendar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveCalendar_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvLeaveCalendar.EditIndex = e.NewEditIndex;
        FillgvLeaveCalendar();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvLeaveCalendar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveCalendar_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objLeave = new BL.Leave();
        var ds = new DataSet();
        var lblLCCode = (Label)gvLeaveCalendar.Rows[e.RowIndex].FindControl("lblLCCode");
        var lblLCDesc = (Label)gvLeaveCalendar.Rows[e.RowIndex].FindControl("lblLCCode");
        var lblEffectiveFrom = (Label)gvLeaveCalendar.Rows[e.RowIndex].FindControl("lblEffectiveFrom");
        var lblEffectiveTo = (Label)gvLeaveCalendar.Rows[e.RowIndex].FindControl("lblEffectiveTo");

        ds = objLeave.LeaveCalendarInsert(BaseCompanyCode, lblLCCode.Text, lblLCDesc.Text, lblEffectiveFrom.Text, lblEffectiveTo.Text, "D", BaseUserID);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvLeaveCalendar.EditIndex = -1;
            FillgvLeaveCalendar();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvLeaveCalendar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveCalendar_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var objLeave = new BL.Leave();
        var ds = new DataSet();

        var lblLCCode = (Label)gvLeaveCalendar.Rows[e.RowIndex].FindControl("lblLCCode");
        var txtEditLCDesc = (TextBox)gvLeaveCalendar.Rows[e.RowIndex].FindControl("txtEditLCDesc");
        var txtEditFromDate = (TextBox)gvLeaveCalendar.Rows[e.RowIndex].FindControl("txtEditFromDate");
        var txtEditToDate = (TextBox)gvLeaveCalendar.Rows[e.RowIndex].FindControl("txtEditToDate");

        if (txtEditLCDesc.Text != "")
        {
        if (txtEditFromDate.Text != "" && txtEditToDate.Text != "")
            {

                    if (DateTime.Parse(txtEditToDate.Text) >= DateTime.Parse(txtEditFromDate.Text))
                    {
                        ds = objLeave.LeaveCalendarInsert(BaseCompanyCode, lblLCCode.Text, txtEditLCDesc.Text, txtEditFromDate.Text, txtEditToDate.Text, "M", BaseUserID);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            gvLeaveCalendar.EditIndex = -1;
                            FillgvLeaveCalendar();
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                        else
                        { 
                            
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgEffectiveToDateShouldBeGreaterThanFromDate;   
                        txtEditFromDate.Text = "";  
                    }

                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgEnterDates;   
                }


            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgEnterLeaveDescription;  
            }

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvLeaveCalendar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveCalendar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvLeaveCalendar.EditIndex = -1;
        FillgvLeaveCalendar();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvLeaveCalendar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvLeaveCalendar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLeaveCalendar.PageIndex = e.NewPageIndex;
        gvLeaveCalendar.EditIndex = -1;
        FillgvLeaveCalendar();
    }
    /// <summary>
    /// Handles the Click event of the ImgbtnLCCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnLCCode_Click(object sender, ImageClickEventArgs e)
    {
        var ImgbtnLCCode = (ImageButton)sender;
        var gvRow = (GridViewRow)ImgbtnLCCode.NamingContainer;
        var lblLCCode = (Label)gvLeaveCalendar.Rows[gvRow.RowIndex].FindControl("lblLCCode");
        hfglobalLCCode.Value = lblLCCode.Text;
        gvCalendarCategoryMapping.EditIndex = -1;
        FillgvCalendarCategoryMapping();
    }
    #endregion

    #region GridView LeaveCalendarCategoryMapping Events
    /// <summary>
    /// Fillgvs the calendar category mapping.
    /// </summary>
    protected void FillgvCalendarCategoryMapping()
    {
        var objLeave = new BL.Leave();
        var ds = new DataSet();
        var dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objLeave.LeaveCalendarCategoryGet(BaseCompanyCode, hfglobalLCCode.Value.ToString());
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvCalendarCategoryMapping.DataKeyNames = new string[] { "Leave_cal_code" };
        gvCalendarCategoryMapping.DataSource = dt;
        gvCalendarCategoryMapping.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvCalendarCategoryMapping.Rows[0].Visible = false;
        }
        FillddlCategory(); 
        }
    /// <summary>
    /// Handles the RowDataBound event of the gvCalendarCategoryMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCalendarCategoryMapping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var objGridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                var serialNo = gvCalendarCategoryMapping.PageIndex * gvCalendarCategoryMapping.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            
            if (IsDeleteAccess == false && IsModifyAccess == false)
            {
                var ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsModifyAccess == false)
            {
                var ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Visible = false;
                }
                gvCalendarCategoryMapping.FooterRow.Visible = false;

            }
            //else 
            //{
            //    DropDownList ddlCategoryCode = (DropDownList)e.Row.FindControl("ddlCategoryCode");
            //    if (ddlCategoryCode != null)
            //    {
            //        FillddlCategory();
            //    }
            //}
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvCalendarCategoryMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvCalendarCategoryMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objLeave = new BL.Leave();
        var ds = new DataSet();
        var lblgvCategoryCode = (Label)gvCalendarCategoryMapping.Rows[e.RowIndex].FindControl("lblgvCategoryCode");
        
        ds = objLeave.LeaveCalendarCategoryInsert(BaseCompanyCode, hfglobalLCCode.Value.ToString(), lblgvCategoryCode.Text, "D", BaseUserID);
        
        gvCalendarCategoryMapping.EditIndex = -1;
        FillgvCalendarCategoryMapping();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the RowCommand event of the gvCalendarCategoryMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCalendarCategoryMapping_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        var objLeave = new BL.Leave();
        var ds = new DataSet();
        var ddlCategoryCode = (DropDownList)gvCalendarCategoryMapping.FooterRow.FindControl("ddlCategoryCode");
        //Label lblftrcategoryName = (Label)gvCalendarCategoryMapping.FooterRow.FindControl("lblftrcategoryName");  

        if (e.CommandName.Equals("AddNew"))
        {
            if (ddlCategoryCode.SelectedValue.ToString() != "Select")
            {
                ds = objLeave.LeaveCalendarCategoryInsert(BaseCompanyCode, hfglobalLCCode.Value.ToString(), ddlCategoryCode.SelectedValue.ToString(), "A", BaseUserID);
                if (gvCalendarCategoryMapping.Rows.Count.Equals(gvCalendarCategoryMapping.PageSize))
                {
                    gvCalendarCategoryMapping.PageIndex = gvCalendarCategoryMapping.PageCount + 1;
                }
                gvCalendarCategoryMapping.EditIndex = -1;
                FillgvCalendarCategoryMapping();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else 
            {
                DisplayMessage(lblErrorMsg, "5");  
            }
        }
        else if (e.CommandName.Equals("Reset"))
        {
            ddlCategoryCode.SelectedIndex = 0;
            //lblftrcategoryName.Text = "";
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvCalendarCategoryMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvCalendarCategoryMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCalendarCategoryMapping.PageIndex = e.NewPageIndex;
        gvCalendarCategoryMapping.EditIndex = -1;
        FillgvCalendarCategoryMapping();
    }

    /// <summary>
    /// Fillddls the category.
    /// </summary>
    protected void FillddlCategory()
    {
        var ddlCategoryCode = (DropDownList)gvCalendarCategoryMapping.FooterRow.FindControl("ddlCategoryCode");   
        var objMasterManagement = new BL.MastersManagement();
        ddlCategoryCode.DataSource = objMasterManagement.CategoryMasterGetAll(BaseCompanyCode);
        ddlCategoryCode.DataTextField = "CategoryDesc";
        ddlCategoryCode.DataValueField = "CategoryCode";
        ddlCategoryCode.DataBind();
        if (ddlCategoryCode.Text == "")
        {
            var li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            //ddlCategoryCode.Items.Add(li,0);
            
            ddlCategoryCode.Items.Insert(0, li);
            ddlCategoryCode.SelectedIndex = 0;
        }
        else 
        {
            var li = new ListItem();
            li.Text =  Resources.Resource.Select;
            li.Value = "Select";
            ddlCategoryCode.Items.Insert(0, li);
            ddlCategoryCode.SelectedIndex = 0;  
            //ddlCategoryCode.Items.Add(li,0);
        }
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlCategoryCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlCategoryCode_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var lblftrcategoryName = (Label)gvCalendarCategoryMapping.FooterRow.FindControl("lblftrcategoryName");   
        var ddlCategoryCode = (DropDownList)gvCalendarCategoryMapping.FooterRow.FindControl("ddlCategoryCode");
        if (ddlCategoryCode != null && lblftrcategoryName != null)
        {
            lblftrcategoryName.Text = ddlCategoryCode.SelectedItem.Text;
        }
    }

    #endregion
}
