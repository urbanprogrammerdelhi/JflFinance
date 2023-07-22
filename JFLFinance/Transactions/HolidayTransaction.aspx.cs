// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="HolidayTransaction.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Page for Holiday Transactions between the Range
/// </summary>
public partial class Transactions_HolidayTransaction : BasePage // System.Web.UI.Page
{
    /// <summary>
    /// Used for Paging of Grid View
    /// </summary>
    static int index;

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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    #region Page Load
    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender">Page</param>
    /// <param name="e">Page Events</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.Holiday;
            //}
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Holiday + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess)
            {
                FillgvHoliday();
               
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion


    #region Gridview HolidayType events


    /// <summary>
    /// Bounds the Rows
    /// </summary>
    /// <param name="sender">gvHoliday</param>
    /// <param name="e">event</param>
    protected void GvHoliday_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        var lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvHoliday.PageIndex * gvHoliday.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvHoliday.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

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
                    imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvHoliday.ShowFooter = false;
            }
            else
            {
                var imgbtnADD = (ImageButton)e.Row.FindControl("ImgbtnADD");
                if (imgbtnADD != null)
                {
                    imgbtnADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }
                var txtHolidayDate = (TextBox)e.Row.FindControl("txtHolidayDate");
                txtHolidayDate.Attributes.Add("readonly", "readonly");
                var txtToDate = (TextBox)e.Row.FindControl("txtToDate");
                txtToDate.Attributes.Add("readonly", "readonly");
                var hlHolidayDate = (HyperLink)e.Row.FindControl("hlHolidayDate");
                hlHolidayDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtHolidayDate.ClientID + "');";
                var hlToDate = (HyperLink)e.Row.FindControl("hlToDate");
                hlToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID + "');";
                var ddlHolidayCode = (DropDownList)e.Row.FindControl("ddlHolidayCode");
                var ddlClient = (RadComboBox)e.Row.FindControl("ddlClient");
                var ddlAsmt = (RadComboBox)e.Row.FindControl("ddlAsmt");
                FillddlClient(ddlClient, ddlAsmt);
                
                var objMastersManagement = new BL.MastersManagement();
                DataSet ds = objMastersManagement.HolidayDescriptionGet(BaseLocationAutoID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlHolidayCode.DataSource = ds.Tables[0];
                    ddlHolidayCode.DataValueField = "HolidayCode";
                    ddlHolidayCode.DataTextField = "HolidayDescCode";
                    ddlHolidayCode.DataBind();
                    ddlHolidayCode.AutoPostBack = true;
                }
                else
                {
                    var li = new ListItem {Text = @Resources.Resource.NoDataToShow , Value = string.Empty};
                    ddlHolidayCode.Items.Add(li);
                }
                gvHoliday.Columns[6].Visible = ddlHolidayCode.SelectedItem.Text.Contains("-SPECIAL");

            }
        }
    }

    /// <summary>
    /// RowCommand for the GRID
    /// </summary>
    /// <param name="sender">GvHoliday</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void GvHoliday_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objMasterManagement = new BL.MastersManagement();
        var ddlHolidayCode = (DropDownList)gvHoliday.FooterRow.FindControl("ddlHolidayCode");
        var txtHolidayDate = (TextBox)gvHoliday.FooterRow.FindControl("txtHolidayDate");
        var txtToDate = (TextBox)gvHoliday.FooterRow.FindControl("txtToDate");
        var ddlClient = (RadComboBox)gvHoliday.FooterRow.FindControl("ddlClient");
        var ddlAsmt = (RadComboBox)gvHoliday.FooterRow.FindControl("ddlAsmt");

        var clientDropDown = ddlClient.CheckedItems;
        string clientCode = string.Empty;
        var asmtDropDown = ddlAsmt.CheckedItems;
        var guid= Guid.NewGuid().ToString();
        string asmtId = string.Empty;
      
            foreach (var itemloc in clientDropDown)
            {
                clientCode = clientCode + itemloc.Value + ",";
            }
       
      
            foreach (var itemloc in asmtDropDown)
            {
                asmtId = asmtId + itemloc.Value + ",";
            }
       
        //Set assignment and Client drop drown value to ALL      
        if(clientCode.Contains("ALL"))
               clientCode="ALL";
        
        if (asmtId.Contains("ALL"))
            asmtId = "ALL";
        

        if (e.CommandName.Equals("AddNew"))
        {
            if (ddlHolidayCode.SelectedItem.Value != string.Empty && txtHolidayDate.Text != string.Empty)
            {
               
                DataSet ds = objMasterManagement.HolidayInsert(BaseLocationAutoID, ddlHolidayCode.SelectedItem.Value, txtHolidayDate.Text, BaseUserID, txtToDate.Text, clientCode, asmtId, guid);
                if (gvHoliday.Rows.Count.Equals(gvHoliday.PageSize))
                {
                    gvHoliday.PageIndex = gvHoliday.PageCount + 1;
                }
                gvHoliday.EditIndex = -1;
                FillgvHoliday();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtHolidayDate.Text = string.Empty;
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvHoliday.PageIndex = 0;
                break;
            case "Prev":
                index = 1;
                break;
            case "Next":
                index = 0;
                break;
            case "Last":
                gvHoliday.PageIndex = gvHoliday.PageCount;
                break;
        }
    }

    /// <summary>
    /// Delete command
    /// </summary>
    /// <param name="sender">gvHoliday</param>
    /// <param name="e">event</param>
    protected void GvHoliday_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var objMasterManagement = new BL.MastersManagement();
        
        var hfHolidayCode = (HiddenField)gvHoliday.Rows[e.RowIndex].FindControl("hfHolidayCode");
        var lblHolidayDate = (Label)gvHoliday.Rows[e.RowIndex].FindControl("lblHolidayDate");
        //var lblClientCode = (Label)gvHoliday.Rows[e.RowIndex].FindControl("lblClientCode");
        var lblasmtID = (Label)gvHoliday.Rows[e.RowIndex].FindControl("lblasmtID");
        var hfClientCode = (HiddenField)gvHoliday.Rows[e.RowIndex].FindControl("hfClientCode");

        DataSet ds = objMasterManagement.HolidayDelete(BaseLocationAutoID, hfHolidayCode.Value, lblHolidayDate.Text, hfClientCode.Value, lblasmtID.Text);
        FillgvHoliday();
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }

    /// <summary>
    /// Page Index change
    /// </summary>
    /// <param name="sender">gvHoliday</param>
    /// <param name="e">event</param>

    protected void GvHoliday_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvHoliday.BottomPagerRow;
        var ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int currentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (index == 1)
        {
            if (currentIndex > 0)
            {
                gvHoliday.PageIndex = currentIndex - 1;
            }
            else
            {
                gvHoliday.PageIndex = currentIndex;
            }
            index = -1;
        }
        else if (index == 0)
        {
            gvHoliday.PageIndex = currentIndex + 1;
            index = -1;
        }
        else
        {
            gvHoliday.PageIndex = e.NewPageIndex;
        }
        gvHoliday.EditIndex = -1;
        FillgvHoliday();
    }

    /// <summary>
    /// Data Bounding for Grid
    /// </summary>
    /// <param name="sender">gvHoliday</param>
    /// <param name="e">event</param>
    protected void GvHoliday_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvHoliday.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        var lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (var i = 0; i < gvHoliday.PageCount; i++)
            {
                var intPageNumber = i + 1;
                var lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvHoliday.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvHoliday.PageCount.ToString();
        }

    }

    /// <summary>
    /// Paging
    /// </summary>
    /// <param name="sender">gvHoliday ddlPage</param>
    /// <param name="e">SelectedIndexChanged</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvHoliday.BottomPagerRow;
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvHoliday.PageIndex = ddlPages.SelectedIndex;
        FillgvHoliday();
    }

    /// <summary>
    /// DropDown Selected Index change for Visible True False
    /// </summary>
    /// <param name="sender">ddlHolidayCode</param>
    /// <param name="e">SelectedIndex</param>
    protected void ddlHolidayCode_SelectedIndex(object sender, EventArgs e)
    {
        var ddlHolidayCode = (DropDownList)sender;
        gvHoliday.Columns[6].Visible = ddlHolidayCode.SelectedItem.Text.Contains("-SPECIAL");


    }

    /// <summary>
    /// Fills the Grid
    /// </summary>
    private void FillgvHoliday()
    {
        var objMastersManagement = new BL.MastersManagement();

        var HolidayTrnClientAsmtColumn = ConfigurationManager.AppSettings["HolidayTrnClientAsmtColumn"].ToLower();

        int dtflag = 1;
        DataSet ds = objMastersManagement.HolidayGetAll(BaseLocationAutoID);
        DataTable dt = ds.Tables[0];
        /* to fix empety gridview */
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvHoliday.DataSource = dt;
        gvHoliday.DataBind();

        if (dtflag == 0)/*to fix empety gridview*/
        {
            gvHoliday.Rows[0].Visible = false;
        }

        // Client and Attendance Column Visible false and True 
        if (HolidayTrnClientAsmtColumn == "true")
        {
            gvHoliday.Columns[3].Visible = false;
            gvHoliday.Columns[4].Visible=false;  
        
        }

    }
    #endregion

    /// <summary>
    /// fills the client dropdown
    /// </summary>
    /// <param name="ddlClient">the ddl client</param>
    protected void FillddlClient(RadComboBox ddlClient, RadComboBox AsmtId)
    {
        var objSale = new BL.Sales();
       // var ds = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID) : objSale.ClientsMappedToLocationGet(BaseLocationAutoID, "ALL", string.Empty, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        var ds = objSale.ClientsLocationWiseGet(BaseLocationAutoID);
       
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientNameCode";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };

            ddlClient.Items.Insert(0, li);
            var item1 = ddlClient.Items.FindItemByValue("ALL");
            item1.Checked = true;
            FillddlAsmt(ddlClient, AsmtId);
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
    protected void FillddlAsmt(RadComboBox ddlClient1, RadComboBox ddlAsmt)
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

        if (clientCode.Contains("ALL") ||ddlClient1.CheckedItems.Count >1)
        {
           
            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            var mi = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmt.Items.Insert(0, mi);
            var item1 = ddlAsmt.Items.FindItemByValue("ALL");
            item1.Checked = true;
            
            return;
        }

        var ds = objSale.GetAssignmentDetails(BaseLocationAutoID, clientCode, "ALL", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));


        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAsmt.DataSource = ds.Tables[0];
            ddlAsmt.DataTextField = "AsmtIDAddress";
            ddlAsmt.DataValueField = "AsmtId";
            ddlAsmt.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmt.Items.Insert(0, li);
            var item1 = ddlAsmt.Items.FindItemByValue("ALL");
            item1.Checked = true;


           
        }
        else
        {
            var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlAsmt.Items.Add(li);
            //ddlPost.Items.Clear();
            //ddlPost.Items.Add(li);
            //var item1 = ddlAsmt.Items.FindItemByValue("ALL");
            //item1.Checked = true;
        }
    }



    protected void DdlClientSelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        var ddlClient = (RadComboBox)sender;
        var ddlAsmt = (RadComboBox)gvHoliday.FooterRow.FindControl("ddlAsmt");
         FillddlAsmt(ddlClient, ddlAsmt);

    }



}
