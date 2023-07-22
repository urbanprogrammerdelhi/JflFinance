// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeCategory.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using BL;
using Resources;

/// <summary>
/// Class Masters_EmployeeCategory
/// </summary>
public partial class Masters_EmployeeCategory : BasePage
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
                var VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
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
                var VirtualDirNameLenght  = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsWriteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
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
                var VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsModifyAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
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
                var VirtualDirNameLenght  = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsDeleteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
        }
    }

    #endregion

    #region Page Buttons events
    /// <summary>
    /// Fills the Grid on Button Click
    /// </summary>
    /// <param name="sender">Sender Object Button</param>
    /// <param name="e">Event Arg Button Click</param>
    protected void BtnProceed_Click(object sender, EventArgs e)
    {
        GvEmployeeCategory.PageIndex = 0;
        FillGvEmployeeCategory();
    }

    /// <summary>
    /// Gets the List of all Employee Category's for the Location
    /// </summary>
    /// <param name="sender">BtnSearchWeekOff Button</param>
    /// <param name="e">Event Arg Button Click</param>
    protected void BtnSearchWeekOff_Click(object sender, EventArgs e)
    {
        SearchAction();
    }

    /// <summary>
    /// Resets the Employe Number, Employee Name to Blank
    /// </summary>
    /// <param name="sender">Sender Object Button Reset</param>
    /// <param name="e">Event Args Click</param>
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        txtEmpNumber.Text = "";
        txtEmpFirstName.Text = "";
        txtEmpLastName.Text = "";
    }
    #endregion

    #region Page Functions
    /// <summary>
    /// Loads Functions on Page Load
    /// </summary>
    /// <param name="sender">Sender Object This.Page</param>
    /// <param name="e">Event Args OnLoad</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var JavaScript = new StringBuilder();
            JavaScript.Append("<script type='text/javascript'>");
            JavaScript.Append("window.document.body.onload = function ()");
            JavaScript.Append("{\n");
            JavaScript.Append("PageTitle('" + Resource.ChangeEmployeeCategory + "');");
            JavaScript.Append("};\n");
            JavaScript.Append("// -->\n");
            JavaScript.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", JavaScript.ToString());

            if (IsReadAccess)
            {
                FillGvEmployeeCategory();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region GridView Binding

    /// <summary>
    /// Fills Grid to Load all Employee Category
    /// </summary>
    protected void FillGvEmployeeCategory()
    {
        var ObjHRManagement = new HRManagement();
        var Dtflag = 1;
        var DsEmployeeCategory = ObjHRManagement.EmployeeCategoryGetAll(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
        var DtEmployeeCategory = DsEmployeeCategory.Tables[0];

        if (DtEmployeeCategory.Rows.Count == 0)
        {
            Dtflag = 0;
            DtEmployeeCategory.Rows.Add(DtEmployeeCategory.NewRow());
        }
        GvEmployeeCategory.DataKeyNames = new [] { "CategoryDesc" };
        GvEmployeeCategory.DataSource = DtEmployeeCategory;
        GvEmployeeCategory.DataBind();

        if (Dtflag == 0)
        {
            GvEmployeeCategory.Rows[0].Visible = false;
        }
        FillSearchDropDownList();
    }

    /// <summary>
    /// Search Action performed on the Grid to Search the category by Description
    /// </summary>
    protected void SearchAction()
    {
        var ObjHRManagement = new HRManagement();
       
       var DsEmployeeCategory = ObjHRManagement.EmployeeCategoryGetAll(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
       var DtEmployeeCategory = DsEmployeeCategory.Tables[0];

        if (DtEmployeeCategory.Rows.Count == 0)
        {
            DtEmployeeCategory.Rows.Add(DtEmployeeCategory.NewRow());
        }
        GvEmployeeCategory.DataKeyNames = new [] { "CategoryDesc" };
        GvEmployeeCategory.DataSource = DtEmployeeCategory;


        //To Filter or Search the Employees in DataTable *********************
        var DvNew = new DataView(DtEmployeeCategory) {RowFilter = ""};
        var StrFilterStatement = "";

        if (txtEmpNumber.Text.Length > 0)
        {
            StrFilterStatement = StrFilterStatement + " [EmployeeNumber] " + ddlSearchEmpNumberCON.SelectedItem.Value + "'" + txtEmpNumber.Text + "'";
        }
        if (txtEmpFirstName.Text.Length > 0)
        {
            if (StrFilterStatement.Length > 0)
            {
                StrFilterStatement = StrFilterStatement + " " + ddlSearchFirstNameOPR.SelectedItem.Value;
            }
            StrFilterStatement = StrFilterStatement + " [Name] " + ddlSearchFirstNameCON.SelectedItem.Value + "'" + txtEmpFirstName.Text + "'";
        }
        if (txtEmpLastName.Text.Length > 0)
        {
            if (StrFilterStatement.Length > 0)
            {
                StrFilterStatement = StrFilterStatement + " " + ddlSearchLastNameOPR.SelectedItem.Value;
            }
            StrFilterStatement = StrFilterStatement + " [Name] " + ddlSearchLastNameCON.SelectedItem.Value + "'" + txtEmpLastName.Text + "'";
        }

        DvNew.RowFilter = StrFilterStatement;
        GvEmployeeCategory.DataSource = DvNew;
        GvEmployeeCategory.DataBind();
    }

    /// <summary>
    /// Fills the Searched Values in DropDown List
    /// </summary>
    private void FillSearchDropDownList()
    {
        
        var ObjCommon = new Common();
        var SrtList = ObjCommon.OperatorNameGet("String");
        ddlSearchEmpNumberCON.Items.Clear();
        foreach (DictionaryEntry Item in SrtList)
        {
            var LI = new ListItem();
            if (SrtList[Item.Key] == Item.Value)
            {
                if (Equals(Item.Value, "Not Equal To"))
                {
                    LI.Text = Resource.NotEqualTo;
                }
                else if (Equals(Item.Value, "Equal To"))
                {
                    LI.Text = Resource.EqualTo;
                }
                else if (Equals(Item.Value, "Like"))
                {
                    LI.Text = Resource.Like;
                }
                else if (Equals(Item.Value, "Not Like"))
                {
                    LI.Text = Resource.NotLike;
                }
                LI.Value = Item.Key.ToString();
                ddlSearchEmpNumberCON.Items.Add(LI);
                ddlSearchFirstNameCON.Items.Add(LI);
                ddlSearchLastNameCON.Items.Add(LI);
            }
        }

        SrtList = ObjCommon.OperatorNameGet("AndOrOperator");
        ddlSearchEmpNumberOPR.Items.Clear();
        foreach (DictionaryEntry Item in SrtList)
        {
            var LI = new ListItem();
            if (SrtList[Item.Key] == Item.Value)
            {
                if (Equals(Item.Value, "AND"))
                {
                    LI.Text = Resource.AND;
                }
                else if (Equals(Item.Value, "OR"))
                {
                    LI.Text = Resource.OR;
                }
                LI.Value = Item.Key.ToString();
                ddlSearchEmpNumberOPR.Items.Add(LI);
                ddlSearchFirstNameOPR.Items.Add(LI);
                ddlSearchLastNameOPR.Items.Add(LI);
            }
        }
    }
    #endregion

    #region GridView Commands Events
    /// <summary>
    /// Bounds Data to the Grid
    /// </summary>
    /// <param name="sender">GvEmployeeCategory Object</param>
    /// <param name="e">GridView Row Event Args</param>
    protected void GvEmployeeCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var LblSerialNo = (Label)e.Row.FindControl("lblSerial");
            if (LblSerialNo != null)
            {
                var SerialNo = GvEmployeeCategory.PageIndex * GvEmployeeCategory.PageSize + int.Parse(e.Row.RowIndex.ToString(CultureInfo.InvariantCulture));
                LblSerialNo.Text = Convert.ToString((SerialNo + 1));
            }
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                var ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                var ObjMastersManagement = new MastersManagement();
                var CmbType = (DropDownList)e.Row.FindControl("cmbFutureCategory");
                var TxtEffectiveTo = (TextBox)e.Row.FindControl("txtEffectiveTo");
                var LblEffectiveFrom = (Label)e.Row.FindControl("lblEffectiveFrom");
                var ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");

                if (TxtEffectiveTo != null)
                {
                    TxtEffectiveTo.Attributes.Add("readonly", "readonly");
                }
                if (LblEffectiveFrom != null && TxtEffectiveTo != null && ImgbtnUpdate != null)
                {
               
                }
                if (CmbType != null)
                {
                    CmbType.DataSource = ObjMastersManagement.CategoryMasterGetAll(BaseCompanyCode);
                    CmbType.DataValueField = "CategoryCode";
                    CmbType.DataTextField = "CategoryDesc";
                    CmbType.DataBind();
                }
            }

        }

    }

    /// <summary>
    /// On Row Update
    /// </summary>
    /// <param name="sender">GvEmployeeCategory Sender</param>
    /// <param name="e">GridView Update Event Args</param>
    protected void GvEmployeeCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var ObjMasterManagement = new HRManagement();
        
        var LblEmployeeNumber = (Label)GvEmployeeCategory.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        var LblCategoryCode = (Label)GvEmployeeCategory.Rows[e.RowIndex].FindControl("lblCategoryCode");
        var TxtEffectiveTo = (TextBox)GvEmployeeCategory.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        var LblEffectiveFrom = (Label)GvEmployeeCategory.Rows[e.RowIndex].FindControl("lblEffectiveFrom");  
        var CmbFutureCategory = (DropDownList)GvEmployeeCategory.Rows[e.RowIndex].FindControl("cmbFutureCategory");
        var StrFutureCategory = CmbFutureCategory.SelectedValue;
        if (LblCategoryCode.Text != StrFutureCategory)
        {
            if (CompareDates(DateTime.Parse(TxtEffectiveTo.Text), DateTime.Parse(LblEffectiveFrom.Text)) == 1)
            {
                var Ds = ObjMasterManagement.EmployeeCategoryUpdate(BaseCompanyCode, LblEmployeeNumber.Text, LblEmployeeNumber.Text, LblCategoryCode.Text, StrFutureCategory, TxtEffectiveTo.Text, BaseUserID, BaseCompanyCode);

                GvEmployeeCategory.EditIndex = -1;
                FillGvEmployeeCategory();

                GvEmployeeCategory.Columns[7].Visible = false;
                GvEmployeeCategory.Columns[8].Visible = false;

                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, Ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resource.ToDateMustBeGreaterThanFromDate);
            }
        }
    }

    /// <summary>
    /// Enables Grid objects in Edit mode
    /// </summary>
    /// <param name="sender">GridView Sender</param>
    /// <param name="e">GridView Edit Event Args</param>
    protected void GvEmployeeCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GvEmployeeCategory.Columns[7].Visible = true;
        GvEmployeeCategory.Columns[8].Visible = true;
        GvEmployeeCategory.EditIndex = e.NewEditIndex;
        SearchAction();
    }

    /// <summary>
    /// Cancels the Grid Event
    /// </summary>
    /// <param name="sender">GvEmployeeCategory Sender</param>
    /// <param name="e">GridView Cancel Edit Event Args</param>
    protected void GvEmployeeCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GvEmployeeCategory.Columns[7].Visible = false;
        GvEmployeeCategory.Columns[8].Visible = false;
        GvEmployeeCategory.EditIndex = -1;
        FillGvEmployeeCategory();
    }

    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender">Grid View GvEmployeeCategory</param>
    /// <param name="e">Page Index Change Event</param>
    protected void GvEmployeeCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvEmployeeCategory.PageIndex = e.NewPageIndex;
        GvEmployeeCategory.EditIndex = -1;
        FillGvEmployeeCategory();
    }
    #endregion
}
