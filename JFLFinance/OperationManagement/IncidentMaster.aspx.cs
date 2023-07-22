// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="IncidentMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Class OperationManagement_IncidentMaster.
/// </summary>
public partial class OperationManagement_IncidentMaster : BasePage
{
    //Clear Commented Code, Formated Code By  Parashar on 5-Aug-2013
    #region Static Variable Declaration
    /// <summary>
    /// The dtrow
    /// </summary>
    static DataTable dtrow = new DataTable(); // Static datatable used for bulk ADD data
    /// <summary>
    /// The status
    /// </summary>
    static int status;// when status=1 data entered into temp datatable else when status=0 normal grid operations
    /// <summary>
    /// The index
    /// </summary>
    static int index;//used for paging
    /// <summary>
    /// The count
    /// </summary>
    static int count;
    //Added Code for Upload Document by  on 19-Jun-2013
    /// <summary>
    /// The dt upload
    /// </summary>
    static DataTable dtUpload = new DataTable();
    #endregion

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
                int VirtualDirNameLenght = 0;
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
                int VirtualDirNameLenght = 0;
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
                int VirtualDirNameLenght = 0;
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
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }
    /// <summary>
    /// Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                BasePage bp = new BasePage();
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }
    #endregion
    #region function related to page load
    /// <summary>
    /// Function Call on Page Load.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.IncidentMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            btnSave.Enabled = false; //Added by  on 2-Jun-2013
            if (IsReadAccess == true)
            {
                status = 1;
                count = 1;
                dtrow.Clear();
                FillgvIncidentInfo();
                if (dtrow.Columns.Contains("MessageTo") == false)
                {
                    MakeTempIncidentInfo();
                }
                else
                {
                    dtrow.Clear();
                }
                FillClientId();         //Added by  on 29-May-2013
                FillddlIncidentType();
                fillNature();       //Added by  on 21-Mar-2013
                //IMGReportingDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtReportingDate.ClientID.ToString() + "');";
                if (IsWriteAccess == true)
                {
                    btnSave.Visible = true;
                }
                if (IsModifyAccess == false)
                {
                    btnAddNew.Visible = false;
                    btnSave.Visible = false;
                }
                txtReportedBy.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtReportedBy.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtDesignation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtDesignation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtDescription.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtDescription.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtMaterialStolen.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtMaterialStolen.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtEmployeeID.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtEmployeeID.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtSupportReq.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtSupportReq.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                FillSystemDateAndTime();
                IMGIncidentSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=INCIDENTCC&ControlId=" + txtIncidentNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");

                //Modify by  on 22-May-2013
                IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,help=no')");

                //Added Code for Upload Document by  on 19-Jun-2013
                CreateUploadTable();
                dvFileUploadGrid.Visible = false;
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                //End
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    /// <summary>
    /// Function used to Fill System DateTime with Format
    /// </summary>
    private void FillSystemDateAndTime()
    {
        txtReportingDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        txtReportingTime.Text = DateTime.Now.ToString("HH:mm");
    }

    #region function related to create temp data table
    /// <summary>
    /// Function used to create temp Incident Info Table
    /// </summary>
    private void MakeTempIncidentInfo()
    {
        DataColumn dCol1 = new DataColumn("MessageTo", typeof(System.String));
        DataColumn dCol2 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol3 = new DataColumn("DesignationDesc", typeof(System.String));
        DataColumn dcol4 = new DataColumn("Date", typeof(System.DateTime));
        DataColumn dcol5 = new DataColumn("Time", typeof(System.DateTime));
        dtrow.Columns.Add(dCol1);
        dtrow.Columns.Add(dCol2);
        dtrow.Columns.Add(dcol3);
        dtrow.Columns.Add(dcol4);
        dtrow.Columns.Add(dcol5);
    }
    #endregion

    #region function to fill ddl Incident type drop down
    /// <summary>
    /// Function used to fill dropdown Incident Type
    /// </summary>
    private void FillddlIncidentType()
    {
        BL.OperationManagement objoperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objoperationManagement.IncidentItemDescGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["ItemDesc"] = ResourceValueOfKey_Get(ds.Tables[0].Rows[i]["ItemDesc"].ToString());
            }
        }
        ddlIncidentType.DataSource = ds;
        ddlIncidentType.DataTextField = "ItemDesc";
        ddlIncidentType.DataValueField = "ItemCode";
        ddlIncidentType.DataBind();
        if (ddlIncidentType == null)
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData;
            li.Value = "0";
            ddlIncidentType.Items.Add(li);
            DisableButtons();
        }
        else
        {
            EnableButton();
        }
    }
    #endregion

    #region function to fill gridview when we take data from database
    /// <summary>
    /// Function used to fill grid gvIncidentInfo after save the record.
    /// </summary>
    private void FillgvIncidentInfoAfterSave()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dtIncidentInfo = new DataTable();
        int dtflag;
        dtflag = 1;
        count = 1;
        ds = objOperationManagement.IncidentDataGet(txtIncidentNo.Text, BaseCompanyCode);
        dtIncidentInfo = ds.Tables[0];
        //to fix empty gridview
        if (dtIncidentInfo.Rows.Count == 0)
        {
            dtflag = 0;
            count = 0;
            dtIncidentInfo.Rows.Add(dtIncidentInfo.NewRow());
        }
        gvIncidentInfo.DataSource = dtIncidentInfo;
        gvIncidentInfo.DataBind();

        if (dtflag == 0)//to fix empty gridview
        {
            gvIncidentInfo.Rows[0].Visible = false;
        }
    }
    #endregion

    #region function to show footer row of gridview
    /// <summary>
    /// Fillgvs the incident information.
    /// </summary>
    private void FillgvIncidentInfo()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("MessageTo", typeof(System.String));
        DataColumn dCol2 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol3 = new DataColumn("DesignationDesc", typeof(System.String));
        DataColumn dcol4 = new DataColumn("Date", typeof(System.DateTime));
        DataColumn dcol5 = new DataColumn("Time", typeof(System.DateTime));
        dt.Columns.Add(dCol1);
        dt.Columns.Add(dCol2);
        dt.Columns.Add(dcol3);
        dt.Columns.Add(dcol4);
        dt.Columns.Add(dcol5);
        int dtflag;
        dtflag = 1;
        //to fix empty gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvIncidentInfo.DataSource = dt;
        gvIncidentInfo.DataBind();

        if (dtflag == 0)//to fix empty gridview
        {
            gvIncidentInfo.Rows[0].Visible = false;
        }
    }
    #endregion

    #region Function to fill Asmt Details

    /// <summary>
    /// Function used for fill Assignment Details.
    /// </summary>
    private void FillAsmtDetails()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        // Commented and Modify by  on 22-May-2013
        ds = objOperationManagement.AsmtIncidentDetailGet(ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                EnableFields();
                EnableButton();
                txtBranchID.Text = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                txtBranchIDDesc.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                hfAsmtStartDate.Value = ds.Tables[0].Rows[0]["AsmtStartDate"].ToString();
                ToolkitScriptManager2.SetFocus(txtReportedBy);
                btnSave.Enabled = true;         //Added by  on 2-Jun-2013
                btnUpload.Enabled = true;       //Added Code for Upload Document by  on 14-Jun-2013
            }
            else
            {
                lblGridError.Text = Resources.Resource.NoDataToShow;
                ClearFields();
                DisableButtons();
                btnSave.Enabled = false;        //Added by  on 2-Jun-2013
                btnUpload.Enabled = false;      //Added Code for Upload Document by  on 14-Jun-2013
            }

        }
        else
        {
            lblGridError.Text = Resources.Resource.NoDataToShow;
            ClearFields();
            DisableButtons();
            btnSave.Enabled = false;            //Added by  on 2-Jun-2013
            btnUpload.Enabled = false;          //Added Code for Upload Document by  on 14-Jun-2013
        }
    }
    #endregion

    #region function related to dropdown Incident type selected index changed
    /// <summary>
    /// Function used for dropdown ddlIncidentType on Selected Index Changed
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlIncidentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillNature();
    }
    #endregion

    #region Fill Dropdown ddlNature Added by  on 21-Mar-2013
    /// <summary>
    /// Function used for fill dropdown ddlNature.
    /// </summary>
    private void fillNature()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ddlNature.DataSource = objOperationManagement.IncidentItemDescGet(ddlIncidentType.SelectedValue.ToString(), BaseCompanyCode);
        ddlNature.DataTextField = "ItemDesc";
        ddlNature.DataValueField = "ItemCode";
        ddlNature.DataBind();
        if (ddlNature == null)
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData;
            li.Value = "0";
            ddlNature.Items.Add(li);
            DisableButtons();
        }
        else
        {
            EnableButton();
        }
    }
    #endregion

    #region function related to dropdown ddl pages[used in pager template] selected index changed
    /// <summary>
    /// Function used for dropdown ddlPages on selectedIndexChange.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvIncidentInfo.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvIncidentInfo.PageIndex = ddlPages.SelectedIndex;
        if (index == 1)
        {
            gvIncidentInfo.DataSource = dtrow;
            gvIncidentInfo.DataBind();
        }
        else if (index == 0)
        {
            FillgvIncidentInfoAfterSave();
        }
    }
    #endregion

    #region Gridview Events
    /// <summary>
    /// Function used for Grid gvIncidentInfo on Row Bind.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvIncidentInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvIncidentInfo.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (IBEdit != null)
                {
                    IBEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblGridError.ClientID.ToString() + "');";
                }
                TextBox txtMessageToEdit = (TextBox)e.Row.FindControl("txtMessageToEdit");
                ImageButton IMGMessageToEdit = (ImageButton)e.Row.FindControl("IMGMessageToEdit");
                if (IMGMessageToEdit != null)
                {
                    IMGMessageToEdit.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtMessageToEdit.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,help=no')");
                }
                if (txtMessageToEdit != null)
                {
                    txtMessageToEdit.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtMessageToEdit.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                }
            }
            else
            {
                ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblGridError.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvIncidentInfo.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblGridError.ClientID.ToString() + "');";
                }
                TextBox txtNewMessageTo = (TextBox)e.Row.FindControl("txtNewMessageTo");
                ImageButton IMGNewMessageTo = (ImageButton)e.Row.FindControl("IMGNewMessageTo");
                if (IMGNewMessageTo != null)
                {
                    IMGNewMessageTo.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtNewMessageTo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,help=no')");
                }
                if (txtNewMessageTo != null)
                {
                    txtNewMessageTo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewMessageTo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
            }
        }
    }

    /// <summary>
    /// Function used for Grid gvIncidentInfo on Row Deleting.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvIncidentInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (status == 0)
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            Label lblMessageToEdit = (Label)gvIncidentInfo.Rows[e.RowIndex].FindControl("lblMessageToEdit");
            if (gvIncidentInfo.Rows.Count > 1)
            {
                ds = objOperationManagement.IncidentInformationDelete(txtIncidentNo.Text, lblMessageToEdit.Text);
                FillgvIncidentInfoAfterSave();
                DisplayMessage(lblGridError, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                lblGridError.Text = "Deletion not possible";
            }
        }
        else if (status == 1)
        {
            if (dtrow.Rows.Count > 1)
            {
                dtrow.Rows.RemoveAt(e.RowIndex);
                gvIncidentInfo.DataSource = dtrow;
                gvIncidentInfo.DataBind();
                if (dtrow.Rows.Count == 0)
                {
                    FillgvIncidentInfo();
                }
            }
            else
            {
                lblGridError.Text = "Deletion not possible";
            }
        }
    }

    /// <summary>
    /// Function used for Grid gvIncidentInfo on Row Editing.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvIncidentInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (status == 1)
        {
            gvIncidentInfo.EditIndex = e.NewEditIndex;
            gvIncidentInfo.DataSource = dtrow;
            gvIncidentInfo.DataBind();
        }
        else if (status == 0)
        {
            gvIncidentInfo.EditIndex = e.NewEditIndex;
            FillgvIncidentInfoAfterSave();
            gvIncidentInfo.Rows[e.NewEditIndex].Focus();         //Added For Set Focus by  on 26-July-2013
        }
    }

    /// <summary>
    /// Function used for Grid gvIncidentInfo on Row Updating.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvIncidentInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int flag = 1;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        TextBox txtMessageToEdit = (TextBox)gvIncidentInfo.Rows[e.RowIndex].FindControl("txtMessageToEdit");
        TextBox txtDateEdit = (TextBox)gvIncidentInfo.Rows[e.RowIndex].FindControl("txtDateEdit");
        TextBox txtTimeEdit = (TextBox)gvIncidentInfo.Rows[e.RowIndex].FindControl("txtTimeEdit");
        Label lblMessageToEdit = (Label)gvIncidentInfo.Rows[e.RowIndex].FindControl("lblMessageToEdit");
        TextBox txtNameEdit = (TextBox)gvIncidentInfo.Rows[e.RowIndex].FindControl("txtNameEdit");
        TextBox txtDesignationEdit = (TextBox)gvIncidentInfo.Rows[e.RowIndex].FindControl("txtDesignationEdit");
        if (status == 1)
        {
            if (DateTime.Parse(txtDateEdit.Text) >= DateTime.Parse(txtReportingDate.Text))
            {
                flag = 1;
                txtDateEdit.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                lblGridError.Text = "Date Should be greater than or equal to Reporting date";
                ToolkitScriptManager2.SetFocus(txtDateEdit);
                txtDateEdit.BackColor = System.Drawing.Color.Aqua;
                return;
            }
            if (flag == 1)
            {
                dtrow.Rows[e.RowIndex][0] = txtMessageToEdit.Text;
                dtrow.Rows[e.RowIndex][1] = txtNameEdit.Text;
                dtrow.Rows[e.RowIndex][2] = txtDesignationEdit.Text;
                dtrow.Rows[e.RowIndex][3] = txtDateEdit.Text;
                dtrow.Rows[e.RowIndex][4] = txtTimeEdit.Text;
                gvIncidentInfo.EditIndex = -1;
                gvIncidentInfo.DataSource = dtrow;
                gvIncidentInfo.DataBind();
            }
        }
        else if (status == 0)
        {
            if (DateTime.Parse(txtDateEdit.Text) >= DateTime.Parse(txtReportingDate.Text))
            {
                flag = 1;
                txtDateEdit.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                lblGridError.Text = "Date Should be greater then or equal to Reporting date";
                ToolkitScriptManager2.SetFocus(txtDateEdit);
                txtDateEdit.BackColor = System.Drawing.Color.Aqua;
                return;
            }
            if (flag == 1)
            {
                ds = objOperationManagement.IncidentInformationUpdate(txtIncidentNo.Text, txtMessageToEdit.Text, DateTime.Parse(txtDateEdit.Text), DateTime.Parse(txtTimeEdit.Text), BaseUserID, lblMessageToEdit.Text);
                DisplayMessage(lblGridError, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    gvIncidentInfo.EditIndex = -1;
                    FillgvIncidentInfoAfterSave();
                }
            }

        }
    }

    /// <summary>
    /// Function used for Grid gvIncidentInfo on Row Canceling Edit.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvIncidentInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (status == 1)
        {
            gvIncidentInfo.EditIndex = -1;
            gvIncidentInfo.DataSource = dtrow;
            gvIncidentInfo.DataBind();
        }
        else if (status == 0)
        {
            gvIncidentInfo.EditIndex = -1;
            FillgvIncidentInfoAfterSave();
        }

    }

    /// <summary>
    /// Function used for Grid gvIncidentInfo on Row Command.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvIncidentInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int flag = 1;
        TextBox txtNewDate = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewDate");
        TextBox txtNewTime = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewTime");
        TextBox txtNewMessageTo = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewMessageTo");
        TextBox txtNewName = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewName");
        TextBox txtNewDesignation = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewDesignation");
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (status == 1)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                for (int i = 0; i < dtrow.Rows.Count; i++)
                {
                    Label lblMessageToEdit = (Label)gvIncidentInfo.Rows[i].FindControl("lblMessageToEdit");
                    if (lblMessageToEdit.Text == txtNewMessageTo.Text)
                    {
                        lblGridError.Text = Resources.Resource.MsgAlreadyExists; ;
                        return;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
                if (DateTime.Parse(txtNewDate.Text) >= DateTime.Parse(txtReportingDate.Text))
                {
                    flag = 1;
                    txtNewDate.BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    txtNewDate.BackColor = System.Drawing.Color.Aqua;
                    ToolkitScriptManager2.SetFocus(txtNewDate);
                    lblGridError.Text = "Date Should be greater then or equal to Reporting date";
                    return;
                }
                if (flag == 1)
                {
                    DataRow dr = dtrow.NewRow();
                    dr[0] = txtNewMessageTo.Text;
                    dr[1] = txtNewName.Text;
                    dr[2] = txtNewDesignation.Text;
                    dr[3] = txtNewDate.Text;
                    dr[4] = DateTime.Parse(txtNewTime.Text).ToShortTimeString();
                    dtrow.Rows.Add(dr);
                    gvIncidentInfo.DataSource = dtrow;
                    gvIncidentInfo.DataBind();
                }
            }
        }
        else if (status == 0)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                DataSet ds = new DataSet();
                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                if (DateTime.Parse(txtNewDate.Text) >= DateTime.Parse(txtReportingDate.Text))
                {
                    flag = 1;
                    txtNewDate.BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    txtNewDate.BackColor = System.Drawing.Color.Aqua;
                    ToolkitScriptManager2.SetFocus(txtNewDate);
                    lblGridError.Text = "Date Should be greater then or equal to Reporting date";
                    return;
                }
                if (flag == 1)
                {
                    ds = objOperationManagement.IncidentPassedInformationInsert(txtIncidentNo.Text, txtNewMessageTo.Text, DateTime.Parse(txtNewDate.Text), DateTime.Parse(txtNewTime.Text), BaseUserID);
                    DisplayMessage(lblGridError, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                    {
                        gvIncidentInfo.EditIndex = -1;
                        FillgvIncidentInfoAfterSave();
                    }
                }
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewDate.Text = "";
            txtNewMessageTo.Text = "";
            txtNewName.Text = "";
            txtNewDesignation.Text = "";
            txtNewTime.Text = "";
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvIncidentInfo.PageIndex = 0;
                break;
            case "Prev":
                index = 1;
                break;
            case "Next":
                index = 0;
                break;
            case "Last":
                gvIncidentInfo.PageIndex = gvIncidentInfo.PageCount;
                break;
        }
    }

    /// <summary>
    /// Function used for Grid gvIncidentInfo on DataBound.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvIncidentInfo_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvIncidentInfo.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvIncidentInfo.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvIncidentInfo.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvIncidentInfo.PageCount.ToString();
        }
    }

    /// <summary>
    /// Function used for Grid gvIncidentInfo on Page Index Change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvIncidentInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvIncidentInfo.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvIncidentInfo.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvIncidentInfo.PageIndex = CurrentIndex;
            }
            index = -1;
        }
        else if (index == 0)
        {
            gvIncidentInfo.PageIndex = CurrentIndex + 1;
            index = -1;
        }
        else
        {
            gvIncidentInfo.PageIndex = e.NewPageIndex;
        }
        gvIncidentInfo.EditIndex = -1;
        if (status == 1)
        {
            gvIncidentInfo.DataSource = dtrow;
            gvIncidentInfo.DataBind();
        }
        else if (status == 0)
        {
            FillgvIncidentInfoAfterSave();
        }
    }
    #endregion

    #region function related to button click
    /// <summary>
    /// Function used for button Edit on Click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.IncidentAmend(txtIncidentNo.Text, Resources.Resource.Amend, BaseLocationAutoID, BaseUserID);
        if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
        {
            lblIncidentStatus.Text = Resources.Resource.Amend;
            EnableFields();
            gvIncidentInfo.Columns[0].Visible = true;
            if (IsWriteAccess == true)
            {
                gvIncidentInfo.FooterRow.Visible = true;
            }
            HideButtonBasedOnStatus();
        }
        //Added for Upload Document by  on 24-Jun-2013
        if (lblIncidentStatus.Text == Resources.Resource.Authorized)
        {
            gvEmployeeDocument.Columns[4].Visible = false;
        }
        else
        {
            gvEmployeeDocument.Columns[4].Visible = true;
        }
        //End
        //Added By  on 23-July-2013
        btnUpload.Enabled = true;
        //End
    }

    /// <summary>
    /// Function used for button update on Click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        int flag = 1;
        if (count != 0)
        {
            if (txtReportingDate.Text != "")
            {
                if (DateTime.Parse(txtReportingDate.Text) < DateTime.Parse(hfAsmtStartDate.Value) || DateTime.Parse(txtReportingDate.Text) > System.DateTime.Now)
                {
                    lblGridError.Text = "Reporting date should be between Assignment Start Date and Current Date";
                    ToolkitScriptManager2.SetFocus(txtReportingDate);
                    txtReportingDate.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
                else
                {
                    txtReportingDate.BackColor = System.Drawing.Color.Empty;
                    flag = 1;
                }
            }
            if (txtOccurenceDate.Text != "")
            {
                if (DateTime.Parse(txtOccurenceDate.Text) <= DateTime.Parse(txtReportingDate.Text))
                {
                    flag = 1;
                    txtOccurenceDate.BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    txtOccurenceDate.BackColor = System.Drawing.Color.Aqua;
                    ToolkitScriptManager2.SetFocus(txtOccurenceDate);
                    lblGridError.Text = "Occurance date should be less than or equal to Reporting date";
                    return;
                }
            }
            //Added Code for Check Numeric Value by  on 1-July-2013
            if (!string.IsNullOrEmpty(txtLossValue.Text))
            {
                if (!isNumeric(txtLossValue.Text, System.Globalization.NumberStyles.Integer | System.Globalization.NumberStyles.AllowDecimalPoint))
                {
                    lblError.Text = "Loss/Claim Value should be in numeric format.";
                    txtLossValue.Text = "";
                    txtLossValue.Focus();
                    flag = 0;
                    return;
                }
            }
            else
            {
                txtLossValue.Text = "0";
            }
            //End
            if (flag == 1)
            {
                for (int i = 0; i < gvIncidentInfo.Rows.Count; i++)
                {
                    Label lblDate = (Label)gvIncidentInfo.Rows[i].FindControl("lblDate");
                    if (DateTime.Parse(lblDate.Text) >= DateTime.Parse(txtReportingDate.Text))
                    {
                        gvIncidentInfo.Rows[i].BackColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        gvIncidentInfo.Rows[i].BackColor = System.Drawing.Color.Aqua;
                        lblGridError.Text = "Date Should be greater then or equal to Reporting date";
                        return;
                    }
                }
                //Modified by  on 21-Mar-2013 & 22-May-2013 and 23-Jun-2013
                ds = objOperationManagement.IncidentUpdate(DateTime.Parse(txtReportingDate.Text), DateTime.Parse(txtReportingTime.Text), ddlIncidentType.SelectedValue, ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, txtReportedBy.Text, txtDesignation.Text, ddlNature.SelectedValue, txtDescription.Text, txtMaterialStolen.Text, bool.Parse(ddlPoliceInvolved.SelectedValue.ToString()), Convert.ToDouble(txtLossValue.Text), txtPoliceRefNo.Text, DateTime.Parse(txtOccurenceDate.Text), DateTime.Parse(txtOccurenceTime.Text), txtEmployeeID.Text, txtSupportReq.Text, BaseLocationAutoID, BaseUserID, txtIncidentNo.Text);
                DisplayMessage(lblGridError, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        else
        {
            lblGridError.Text = "Please enter atleast one value in the gridview ";//Resources.Resource.NightCheckDetailsCannotbeleftblank;
        }
    }

    /// <summary>
    /// Function used for button AddNew on Click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        status = 1;
        HideButton();
        EnableFields();
        btnSave.Visible = true;
        btnAddNew.Visible = true;
        txtIncidentNo.Text = "";
        lblIncidentStatus.Text = "";
        dtrow.Clear();
        ClearFields();
        FillgvIncidentInfo();
        FillSystemDateAndTime();
        gvIncidentInfo.Columns[0].Visible = true;           //Added by  on 22-Mar-2013
        FillClientId();                                     //Added by  on 29-May-2013
        ddlClientId.Enabled = true;
        ddlAsmtId.Items.Clear();
        ddlAsmtId.Enabled = false;
        FillgvEmployeeDocDownload();                        //Added code for Upload Document by  on 24-Jun-2013
        IMGOccurenceDate.Visible = true;                     //Added by  on 27-Aug-2013
    }

    /// <summary>
    /// Function used for button Cancel on Click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        dtrow.Clear();
        ClearFields();
        PanelGvIncidentInfo.Visible = true;
        txtIncidentNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        FillgvIncidentInfo();
        FillSystemDateAndTime();
        FillClientId();                             //Added by  on 29-May-2013
        ddlAsmtId.Items.Clear();
        ddlAsmtId.Enabled = false;
        FillgvEmployeeDocDownload();                //Added code for Upload Document by  on 24-Jun-2013
    }

    /// <summary>
    /// Function used for button Save on Click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        int flag = 1;
        if (txtReportingDate.Text != "")
        {
            if (DateTime.Parse(txtReportingDate.Text) < DateTime.Parse(hfAsmtStartDate.Value) || DateTime.Parse(txtReportingDate.Text) > System.DateTime.Now)
            {
                lblGridError.Text = "Reporting date should be between Assignment Start Date and Current Date";
                ToolkitScriptManager2.SetFocus(txtReportingDate);
                txtReportingDate.BackColor = System.Drawing.Color.Aqua;
                return;
            }
            else
            {
                flag = 1;
                txtReportingDate.BackColor = System.Drawing.Color.Empty;
            }
        }
        if (txtOccurenceDate.Text != "")
        {
            if (DateTime.Parse(txtOccurenceDate.Text) <= DateTime.Parse(txtReportingDate.Text))
            {
                flag = 1;
                txtOccurenceDate.BackColor = System.Drawing.Color.Empty;
                //Added New Code for Check Occurance Time by  on 26-July-2013
                if (DateTime.Parse(txtOccurenceDate.Text) == DateTime.Parse(txtReportingDate.Text) && DateTime.Parse(txtOccurenceTime.Text) >= DateTime.Parse(txtReportingTime.Text))
                {
                    lblGridError.Text = "Occurance Time should be less than to Reporting Time";
                    txtOccurenceTime.Text = "";
                    txtOccurenceTime.Focus();
                    return;
                }
            }
            else
            {
                txtOccurenceDate.BackColor = System.Drawing.Color.Empty;
                ToolkitScriptManager2.SetFocus(txtOccurenceDate);
                lblGridError.Text = "Occurance date should be less than or equal to Reporting date";
                return;
            }
        }
        if (dtrow.Rows.Count == 0)
        {
            lblGridError.Text = "Please enter atleast one value in the gridview ";//Resources.Resource.NightCheckDetailsCannotbeleftblank;
            return;
        }
        //Added by  on 14-Jun-2013
        if (ddlPoliceInvolved.SelectedItem.Value == "True")
        {
            if (string.IsNullOrEmpty(txtPoliceRefNo.Text))
            {
                lblError.Text = "Please enter Police Ref No.";
                flag = 0;
                return;
            }
        }
        if (!string.IsNullOrEmpty(txtLossValue.Text))
        {
            if (!isNumeric(txtLossValue.Text, System.Globalization.NumberStyles.Integer | System.Globalization.NumberStyles.AllowDecimalPoint))
            {
                lblError.Text = "Loss/Claim Value should be in numeric format.";
                txtLossValue.Text = "";
                txtLossValue.Focus();
                flag = 0;
                return;
            }
        }
        else
        {
            txtLossValue.Text = "0";
        }
         //End
        if (flag == 1)
        {
            status = 0;
            for (int i = 0; i < dtrow.Rows.Count; i++)
            {
                Label lblDate = (Label)gvIncidentInfo.Rows[i].FindControl("lblDate");
                if (DateTime.Parse(lblDate.Text) >= DateTime.Parse(txtReportingDate.Text))
                {
                    gvIncidentInfo.Rows[i].BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    gvIncidentInfo.Rows[i].BackColor = System.Drawing.Color.Aqua;
                    lblGridError.Text = "Date Should be greater then or equal to Reporting date";
                    return;
                }
            }
            //Modify by  on 21-Mar-2013 & on 22-May-2013 updated on 21-Jun-2013
            ds = objOperationManagement.IncidentInsert(DateTime.Parse(txtReportingDate.Text), DateTime.Parse(txtReportingTime.Text), ddlIncidentType.SelectedValue, ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, txtReportedBy.Text, txtDesignation.Text, ddlNature.SelectedValue, txtDescription.Text, txtMaterialStolen.Text, bool.Parse(ddlPoliceInvolved.SelectedValue.ToString()), Convert.ToDouble(txtLossValue.Text), txtPoliceRefNo.Text, DateTime.Parse(txtOccurenceDate.Text), DateTime.Parse(txtOccurenceTime.Text), txtEmployeeID.Text, txtSupportReq.Text, dtrow, BaseLocationAutoID, BaseUserID, Resources.Resource.Fresh, dtUpload);
            DisplayMessage(lblGridError, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                txtIncidentNo.Text = ds.Tables[0].Rows[0]["IncidentNumber"].ToString();
                txtIncidentNo_TextChanged(sender, e);
                FillgvIncidentInfoAfterSave();
                lblIncidentStatus.Text = Resources.Resource.Fresh;
                HideButtonBasedOnStatus();
            }
        }
    }

    /// <summary>
    /// Function used for button Authorize on Click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        if (count != 0)
        {
            string strIncidentNumber;
            strIncidentNumber = txtIncidentNo.Text;
            for (int i = 0; i < gvIncidentInfo.Rows.Count; i++)
            {
                Label lblDate = (Label)gvIncidentInfo.Rows[i].FindControl("lblDate");
                if (DateTime.Parse(lblDate.Text) >= DateTime.Parse(txtReportingDate.Text))
                {
                    gvIncidentInfo.Rows[i].BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    gvIncidentInfo.Rows[i].BackColor = System.Drawing.Color.Aqua;
                    lblGridError.Text = "Date Should be greater then or equal to Reporting date";
                    return;
                }
            }
            ds = objOperationManagement.IncidentAuthorize(txtIncidentNo.Text, Resources.Resource.Authorized, BaseLocationAutoID, BaseUserID);
            DisplayMessage(lblGridError, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                txtIncidentNo.Text = "";
                txtIncidentNo.Text = strIncidentNumber;
                txtIncidentNo_TextChanged(sender, e);

                HideButtonBasedOnStatus();
                DisableFields();
                gvIncidentInfo.Columns[0].Visible = false;
                gvIncidentInfo.FooterRow.Visible = false;
            }
        }
        else
        {
            lblGridError.Text = "Please enter atleast one value in the gridview ";          //Resources.Resource.NightCheckDetailsCannotbeleftblank;
        }
    }

    #region function related to textbox textchanged event including gridview textbox changed event
    /// <summary>
    /// Function used for Textbox txtMessageToEdit on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtMessageToEdit_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtNameEdit = (TextBox)gvIncidentInfo.Rows[row.RowIndex].FindControl("txtNameEdit");
        TextBox txtDesignationEdit = (TextBox)gvIncidentInfo.Rows[row.RowIndex].FindControl("txtDesignationEdit");
        TextBox txtMessageToEdit = (TextBox)gvIncidentInfo.Rows[row.RowIndex].FindControl("txtMessageToEdit");
        TextBox txtDateEdit = (TextBox)gvIncidentInfo.Rows[row.RowIndex].FindControl("txtDateEdit");
        ImageButton ImgbtnUpdate = (ImageButton)gvIncidentInfo.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtMessageToEdit.Text, BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            ImgbtnUpdate.Visible = true;
            txtNameEdit.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            txtDesignationEdit.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            ToolkitScriptManager2.SetFocus(txtDateEdit);
            txtMessageToEdit.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ImgbtnUpdate.Visible = false;
            txtMessageToEdit.BackColor = System.Drawing.Color.Aqua;
            ToolkitScriptManager2.SetFocus(txtMessageToEdit);
            lblGridError.Text = Resources.Resource.InvalidEmpCode;
        }
    }

    /// <summary>
    /// Function used for Textbox txtNewMessageTo on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewMessageTo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        TextBox txtNewName = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewName");
        TextBox txtNewDesignation = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewDesignation");
        TextBox txtNewMessageTo = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewMessageTo");
        TextBox txtNewDate = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewDate");
        ImageButton lbADD = (ImageButton)gvIncidentInfo.FooterRow.FindControl("lbADD");
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtNewMessageTo.Text, BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            lbADD.Visible = true;
            txtNewName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            txtNewDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            ToolkitScriptManager2.SetFocus(txtNewDate);
            txtNewMessageTo.BackColor = System.Drawing.Color.Empty;
            txtNewMessageTo.Focus();              //Added by  on 13-Jun-2013
        }
        else
        {
            lbADD.Visible = false;
            txtNewMessageTo.BackColor = System.Drawing.Color.Aqua;
            ToolkitScriptManager2.SetFocus(txtNewMessageTo);
            lblGridError.Text = Resources.Resource.InvalidEmpCode;
            txtNewMessageTo.Focus();            //Added by  on 13-Jun-2013
        }
    }

    /// <summary>
    /// Function used for Textbox txtEmployeeID on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeID_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeID.Text, BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            EnableButton();
            txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            txtEmpDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            txtEmployeeID.BackColor = System.Drawing.Color.Empty;
            ToolkitScriptManager2.SetFocus(txtSupportReq);
        }
        else
        {
            lblGridError.Text = Resources.Resource.InvalidEmpCode;
            ToolkitScriptManager2.SetFocus(txtEmployeeID);
            txtEmployeeID.BackColor = System.Drawing.Color.Aqua;
            DisableButtons();
        }
    }

    /// <summary>
    /// Function used for Textbox txtIncidentNo on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtIncidentNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.IncidentDetailGet(txtIncidentNo.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            PanelMain.Visible = true;
            FillgvIncidentInfoAfterSave();
            PanelGvIncidentInfo.Visible = true;
            DisableFields();
            btnAddNew.Visible = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
            txtEmpDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            txtEmployeeID.Text = ds.Tables[0].Rows[0]["EnteredBy"].ToString();
            txtEmployeeName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtMaterialStolen.Text = ds.Tables[0].Rows[0]["MaterialStolen"].ToString();
            txtOccurenceDate.Text = DateFormat(ds.Tables[0].Rows[0]["OccuranceDate"].ToString());
            txtOccurenceTime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["OccuranceTime"].ToString()).ToString("HH:mm");
            txtReportedBy.Text = ds.Tables[0].Rows[0]["ReportedBy"].ToString();
            txtReportingDate.Text = DateFormat(ds.Tables[0].Rows[0]["ReportingDate"].ToString());
            txtReportingTime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["ReportingTime"].ToString()).ToString("HH:mm");
            txtSupportReq.Text = ds.Tables[0].Rows[0]["SupportReq"].ToString();
            ddlIncidentType.SelectedValue = ds.Tables[0].Rows[0]["IncidentTypeCode"].ToString();
            ddlIncidentType_SelectedIndexChanged(sender, e);
            //Added & Modified by  on 21-Mar-2013
            ddlNature.SelectedValue = ds.Tables[0].Rows[0]["NatureOfIncident"].ToString();
            ddlPoliceInvolved.SelectedValue = ds.Tables[0].Rows[0]["PoliceInvolve"].ToString();
            txtPoliceRefNo.Text = ds.Tables[0].Rows[0]["PoliceRefNo"].ToString();
            txtLossValue.Text = ds.Tables[0].Rows[0]["LossClaimValue"].ToString();
            //End
            lblIncidentStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            HideButtonBasedOnStatus();
            status = 0;
            //Added by  on 29-May-2013
            string clientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();     
            SetClientId(clientCode);
            string asmtId = ds.Tables[0].Rows[0]["AsmtId"].ToString();           
            SetAsmt(asmtId);
            ddlClientId.Enabled = false;
            ddlAsmtId.Enabled = false;
            ddlAsmtId_SelectedIndexChanged(sender, e);

            //Added by  on 14-Jun-2013
            if (ddlPoliceInvolved.SelectedItem.Value == "True")
            {
                lblPoliceRefNo.Visible = true;
                txtPoliceRefNo.Visible = true;
            }
            else
            {
                lblPoliceRefNo.Visible = false;
                txtPoliceRefNo.Visible = false;
            }
            //End
            FillgvEmployeeDocDownload();                    //Added Code for Upload Document by  on 23-Jun-2013
            IMGReportingDate.Visible = false;               //Added by  on 27-Aug-2013
        }
        else
        {
            lblError.Text = Resources.Resource.NoDataToShow;
            PanelGvIncidentInfo.Visible = false;
            PanelMain.Visible = false;
            DisableButtons();
        }
    }

    /// <summary>
    /// Function used for Textbox txtIncidentNo on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAssignNo_TextChanged(object sender, EventArgs e)
    {
        FillAsmtDetails();
    }
    #endregion

    #region Function Related to Clear,Diasable & Enable Fields
    /// <summary>
    /// Function used to clear fields value.
    /// </summary>
    private void ClearFields()
    {
        txtAreaDesc.Text = "";
        txtAreaID.Text = "";
        txtBranchID.Text = "";
        txtBranchIDDesc.Text = "";
        txtDescription.Text = "";
        txtDesignation.Text = "";
        txtEmployeeID.Text = "";
        txtEmployeeName.Text = "";
        txtMaterialStolen.Text = "";
        txtOccurenceDate.Text = "";
        txtOccurenceTime.Text = "";
        txtReportedBy.Text = "";
        txtReportingDate.Text = "";
        txtReportingTime.Text = "";
        txtEmpDesignation.Text = "";
        txtSupportReq.Text = "";
        //Added by  on 24-Jun-2013
        txtPoliceRefNo.Text = "";
        txtLossValue.Text = "";
    }

    /// <summary>
    /// Function used to Disable fields.
    /// </summary>
    private void DisableFields()
    {
        txtDescription.Enabled = false;
        txtDesignation.Enabled = false;
        txtEmployeeID.Enabled = false;
        txtMaterialStolen.Enabled = false;
        txtOccurenceDate.Enabled = false;
        txtOccurenceTime.Enabled = false;
        txtReportedBy.Enabled = false;
        txtReportingDate.Enabled = false;
        txtReportingTime.Enabled = false;
        txtSupportReq.Enabled = false;
        IMGOccurenceDate.Visible = false;
        IMGReportingDate.Visible = false;
        ddlIncidentType.Enabled = false;
        ddlNature.Enabled = false;
        ddlPoliceInvolved.Enabled = false;
    }

    /// <summary>
    /// Function used to Enable fields.
    /// </summary>
    private void EnableFields()
    {
        txtDescription.Enabled = true;
        txtDesignation.Enabled = true;
        txtEmployeeID.Enabled = true;
        txtMaterialStolen.Enabled = true;
        //Added New Condition for Editing OccuranceTime by  on 26-July-2013
        if (string.IsNullOrEmpty(lblIncidentStatus.Text))
        {
            txtOccurenceTime.Enabled = true;
            IMGOccurenceDate.Visible = true;
        }
        txtReportedBy.Enabled = true;
        txtReportingTime.Enabled = true;
        txtSupportReq.Enabled = true;
        IMGReportingDate.Visible = true;
        ddlIncidentType.Enabled = true;
        ddlNature.Enabled = true;
        ddlPoliceInvolved.Enabled = true;
    }
    #endregion

    #region Function related to Disable,Enable,Hide,Show & HideButtonBasedOnStatus
    /// <summary>
    /// Function used to Disable Buttons.
    /// </summary>
    private void DisableButtons()
    {
        btnUpdate.Enabled = false;
        btnAddNew.Enabled = false;
        btnCancel.Enabled = false;
        btnSave.Enabled = false;
        btnUpload.Enabled = false;                  //Added Code for Upload Document by  on 14-Jun-2013
    }

    /// <summary>
    /// Function used to Enable Buttons.
    /// </summary>
    private void EnableButton()
    {
        btnUpdate.Enabled = true;
        btnAddNew.Enabled = true;
        btnCancel.Enabled = true;
        btnUpload.Enabled = true;                   //Added Code for Upload Document  by  on 14-Jun-2013
    }

    /// <summary>
    /// Function used to Hide Buttons.
    /// </summary>
    private void HideButton()
    {
        btnAddNew.Visible = false;
        btnCancel.Visible = false;
        btnAuthorize.Visible = false;
        btnCancel.Visible = false;
        btnEdit.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    /// <summary>
    /// Function used to Show Buttons.
    /// </summary>
    private void ShowButton()
    {
        btnAddNew.Visible = true;
        btnCancel.Visible = true;
        if (IsAuthorizationAccess == true)
        {
            btnAuthorize.Visible = true;
        }
        else
        {
            btnAuthorize.Visible = false;
        }
        btnCancel.Visible = true;
        btnEdit.Visible = true;
        btnSave.Visible = true;
        btnUpdate.Visible = true;
    }

    /// <summary>
    /// Function used to Hide Buttons based on Incident Status.
    /// </summary>
    private void HideButtonBasedOnStatus()
    {
        HideButton();
        if (IsWriteAccess == false)
        {
            gvIncidentInfo.ShowFooter = false;
        }
        if (lblIncidentStatus.Text == Resources.Resource.Fresh)
        {
            btnSave.Visible = false;
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnUpdate.Visible = true;
                flag = 1;
            }
            if (IsAuthorizationAccess == true)
            {
                btnAuthorize.Visible = true;
            }
            else
            {
                btnAuthorize.Visible = false;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnAuthorize.Visible = true;
                }
            }
        }
        else if (lblIncidentStatus.Text == Resources.Resource.Amend)
        {
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnUpdate.Visible = true;
                flag = 1;
            }
            if (IsAuthorizationAccess == true)
            {
                btnAuthorize.Visible = true;
            }
            else
            {
                btnAuthorize.Visible = false;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnUpdate.Visible = true;
                }
                if (IsAuthorizationAccess == true)
                {
                    btnAuthorize.Visible = true;
                }
                else
                {
                    btnAuthorize.Visible = false;
                }
            }
        }
        else if (lblIncidentStatus.Text == Resources.Resource.Authorized)
        {
            int flag = 0;
            DisableFields();
            gvIncidentInfo.Columns[0].Visible = false;
            gvIncidentInfo.FooterRow.Visible = false;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnEdit.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnEdit.Visible = true;
                }
            }
        }
    }
    #endregion

    #region Function Related To Sort GridView [Common Function]
    /// <summary>
    /// Function used to sort direction of Grid Data
    /// </summary>
    /// <value>The grid view sort direction.</value>
    private SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    /// <summary>
    /// Function used to sort Data of Grid with expression
    /// </summary>
    /// <param name="sortExpression">The sort expression.</param>
    /// <param name="direction">The direction.</param>
    /// <param name="dv">The dv.</param>
    /// <param name="strGridViewName">Name of the string grid view.</param>
    private void SortGridView(string sortExpression, string direction, DataView dv, GridView strGridViewName)
    {
        dv.Sort = sortExpression + ' ' + direction;
        strGridViewName.DataSource = dv;
        strGridViewName.DataBind();
    }
    #endregion

    /// <summary>
    /// Function used to Textbox txtReportingDate on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtReportingDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtReportingDate, lblGridError);
    }

    /// <summary>
    /// Function used to Textbox txtOccurenceDate on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtOccurenceDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtOccurenceDate, lblGridError);
    }

    /// <summary>
    /// Function used to Textbox txtDateEdit on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDateEdit_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtDateEdit = (TextBox)gvIncidentInfo.Rows[row.RowIndex].FindControl("txtDateEdit");
        ConvertStringToDateFormat(txtDateEdit, lblGridError);
    }

    /// <summary>
    /// Function used to Textbox txtNewDate on Text change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewDate_TextChanged(object sender, EventArgs e)
    {
        TextBox txtNewDate = (TextBox)gvIncidentInfo.FooterRow.FindControl("txtNewDate");
        ConvertStringToDateFormat(txtNewDate, lblGridError);
    }
    #endregion

    #region Coded Added by 
    //Added by  on 29-May-2013
    /// <summary>
    /// Function used for fill dropdown ClientID
    /// </summary>
    private void FillClientId()
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ClientDetail");
                dt.Columns.Add("ClientCode");
                dt.Rows.Add("Select", "Select");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["ClientDetail"], ds.Tables[0].Rows[cnt]["ClientCode"]);
                }
                ddlClientId.DataSource = dt;
                ddlClientId.DataTextField = "ClientDetail";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();

                ddlAsmtId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblGridError.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlClientId Item Selection Index get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmt();
    }

    /// <summary>
    /// Function used for Get Assignment Based on LocationAutoId and ClientCode.
    /// </summary>
    private void FillAsmt()
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AsmtCode");
                dt.Columns.Add("AsmtDetail");
                dt.Rows.Add("Select", "Select");

                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[cnt]["AsmtCode"], ds.Tables[0].Rows[cnt]["AsmtDetail"]);
                }
                ddlAsmtId.DataSource = dt;
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();

                ddlAsmtId.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblGridError.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlAsmtId Item Selection get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtDetails();
    }

    //Added by  on 29-May-2013

    /// <summary>
    /// Function used for Set Client Code on based on txtIncidentNo
    /// </summary>
    /// <param name="clientCode">The client code.</param>
    private void SetClientId(string clientCode)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientId.DataSource = ds;
                ddlClientId.DataTextField = "ClientDetail";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["ClientCode"].ToString() == clientCode)
                    {
                        ddlClientId.SelectedIndex = cnt;
                    }
                }
                ddlClientId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblGridError.Text = Resources.Resource.NoDataToShow;
        }
    }

    /// <summary>
    /// Function used for Set Assignment Based on LocationAutoId and ClientCode.
    /// </summary>
    /// <param name="asmtId">The asmt identifier.</param>
    private void SetAsmt(string asmtId)
    {
        try
        {
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlAsmtId.DataSource = ds;
                ddlAsmtId.DataTextField = "AsmtDetail";
                ddlAsmtId.DataValueField = "AsmtCode";
                ddlAsmtId.DataBind();
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (ds.Tables[0].Rows[cnt]["AsmtCode"].ToString() == asmtId)
                    {
                        ddlAsmtId.SelectedIndex = cnt;
                    }
                }
                ddlAsmtId.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblGridError.Text = Resources.Resource.NoDataToShow;
        }
    }
    #endregion

    #region Added Code for Police Involve Ref No. by  on 14-Jun-2013
    /// <summary>
    /// Function used for deopdown ddlPoliceInvolved on select index change.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPoliceInvolved_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPoliceInvolved.SelectedItem.Value == "True")
            {
                lblPoliceRefNo.Visible = true;
                txtPoliceRefNo.Visible = true;
            }
            else
            {
                lblPoliceRefNo.Visible = false;
                txtPoliceRefNo.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Database Connection Problem";
        }
    }
    #endregion

    #region Upload Document Code Added by  on 14-Jun-2013
    /// <summary>
    /// Function used for create upload table.
    /// </summary>
    private void CreateUploadTable()
    {
        dtUpload.Clear();
        dtUpload.Columns.Clear();
        dtUpload.Columns.Add("RefNo");
        dtUpload.Columns.Add("EmployeeNumber");
        dtUpload.Columns.Add("FileName");
        dtUpload.Columns.Add("UploadDesc");
        dtUpload.Columns.Add("UploadDate");
        dtUpload.Columns.Add("ModifiedBy");
    }

    /// <summary>
    /// Function used for fill Grid gvEmployeeDocument.
    /// </summary>
    private void FillgvEmployeeDocDownload()
    {
        string strEmployeeNumber = txtEmployeeID.Text;

        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ds = objOPS.OPSDocumentDownload(txtIncidentNo.Text, strEmployeeNumber);
        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            gvEmployeeDocument.DataSource = dt;
            gvEmployeeDocument.DataBind();
            dvFileUploadGrid.Visible = true;
        }
        else
        {
            dvFileUploadGrid.Visible = false;
        }
        if (lblIncidentStatus.Text == Resources.Resource.Authorized)
        {
            gvEmployeeDocument.Columns[4].Visible = false;
            btnUpload.Enabled = false;
        }
        else
        {
            gvEmployeeDocument.Columns[4].Visible = true;
            btnUpload.Enabled = true;
        }
    }

    /// <summary>
    /// Function used for  Button upload on click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEmployeeID.Text))
        {
            String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
            string strEmployeeNumber = txtEmployeeID.Text;
            string strRefNo = txtIncidentNo.Text;
            BL.OperationManagement objOPS = new BL.OperationManagement();
            DataSet dsFileUpload = new DataSet();
            string DIRPath;
            string FileName;
            DIRPath = path;
            //Modify By  on 23-July-2013
            if (EmployeeDocUpload.HasFile && !string.IsNullOrEmpty(txtUploadDesc.Text))
            {
                FileName = strEmployeeNumber + '[' + '-' + ']' + EmployeeDocUpload.FileName;

                DIRPath = DIRPath + FileName;
                #region New Code for Check Duplicate by  on 26-July-2013
                //Added Code for check the duplicate record in Grid by  on 26-July-2013
                if (gvEmployeeDocument.Rows.Count > 0)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("FileName");
                    dtTemp.Columns.Add("Description");

                    foreach (GridViewRow row in gvEmployeeDocument.Rows)
                    {
                        DataRow drTemp = dtTemp.NewRow();

                        drTemp["FileName"] = ((LinkButton)(row.Cells[1].Controls[1])).Text;
                        drTemp["Description"] = ((Label)(row.Cells[2].Controls[1])).Text;
                        dtTemp.Rows.Add(drTemp);
                    }

                    for (int cnt = 0; cnt < dtTemp.Rows.Count; cnt++)
                    {
                        if (FileName.Trim() == dtTemp.Rows[cnt]["FileName"].ToString().Trim() && txtUploadDesc.Text.Trim() == dtTemp.Rows[cnt]["Description"].ToString().Trim())
                        {
                            lblError.Text = "Record already exists";
                            return;
                        }
                        else if (FileName.Trim() == dtTemp.Rows[cnt]["FileName"].ToString().Trim())
                        {
                            lblError.Text = "File Name already exists";
                            return;
                        }
                        if (txtUploadDesc.Text.Trim() == dtTemp.Rows[cnt]["Description"].ToString().Trim())
                        {
                            lblError.Text = "Upload File Description should not be same";
                            return;
                        }
                    }
                }
                //End
                #endregion
                DataRow dtUploadRow = dtUpload.NewRow();
                dtUploadRow[0] = strRefNo;
                dtUploadRow[1] = strEmployeeNumber;
                dtUploadRow[2] = FileName;
                dtUploadRow[3] = txtUploadDesc.Text;
                dtUploadRow[4] = DateTime.Now;
                dtUploadRow[5] = BaseUserID;
                dtUpload.Rows.Add(dtUploadRow);

                if (!string.IsNullOrEmpty(strRefNo))
                {
                    objOPS.OPSDocumentInsert(dtUpload, BaseUserID);
                    FillgvEmployeeDocDownload();
                    dtUpload.Clear();
                    txtUploadDesc.Text = "";
                    EmployeeDocUpload.PostedFile.SaveAs(DIRPath);
                }
                else
                {
                    if (dtUpload.Rows.Count > 0)
                    {
                        gvEmployeeDocument.DataSource = dtUpload;
                        gvEmployeeDocument.DataBind();
                        dvFileUploadGrid.Visible = true;
                        txtUploadDesc.Text = "";
                        EmployeeDocUpload.PostedFile.SaveAs(DIRPath);
                    }
                }
            }
            else
            {
                lblError.Text = "Please select a file and enter document description.";
            }
        }
        else
        {
            lblError.Text = "Employee Details should not be blank";
        }
    }

    /// <summary>
    /// Function used for LinkButton lbFileName on click
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbFileName_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lbFileName = (LinkButton)gvEmployeeDocument.Rows[row.RowIndex].FindControl("lbFileName");
        String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
        string FileName = path;
        FileName = FileName + lbFileName.Text;
        System.IO.FileInfo file = new System.IO.FileInfo(FileName);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
        }
    }

    /// <summary>
    /// Function used for Grid gvEmployeeDocument on Row Data Bound
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDocument_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow objGridViewRow = e.Row;
            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvEmployeeDocument.PageIndex * gvEmployeeDocument.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
            if (IsDeleteAccess == true)
            {
                if (IBDelete != null)
                {
                    IBDelete.Visible = true;
                    gvEmployeeDocument.Columns[3].Visible = true;
                }
            }
            else
            {
                if (IBDelete != null)
                {
                    IBDelete.Visible = false;
                    gvEmployeeDocument.Columns[3].Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// Function used for Grid gvEmployeeDocument on Row Deleting.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();

        string strEmployeeNumber = txtEmployeeID.Text;
        string strRefNo = txtIncidentNo.Text;
        LinkButton lbFileName = (LinkButton)gvEmployeeDocument.Rows[e.RowIndex].FindControl("lbFileName");
        ImageButton IBDelete = (ImageButton)gvEmployeeDocument.Rows[e.RowIndex].FindControl("IBDelete");
        if (!string.IsNullOrEmpty(strRefNo))
        {
            ds = objOPS.OPSDocumentDelete(strRefNo, lbFileName.Text, strEmployeeNumber);

            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                DeleteFile(lbFileName.Text);
            }
            DisplayMessage(lblError, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else
        {
            if (dtUpload.Rows.Count > 0)
            {
                dtUpload.Rows.RemoveAt(e.RowIndex);
                gvEmployeeDocument.DataSource = dtUpload;
                gvEmployeeDocument.DataBind();
                if (dtUpload.Rows.Count < 1)
                {
                    dvFileUploadGrid.Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// Function used for Delete File.
    /// </summary>
    /// <param name="strFileName">Name of the string file.</param>
    public void DeleteFile(string strFileName)
    {
        String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
        FileInfo TheFile = new FileInfo(path + strFileName);
        if (TheFile.Exists)
        {
            File.Delete(path + strFileName);
        }
        FillgvEmployeeDocDownload();
    }
    #endregion

    /// <summary>
    /// Added New Code for Check Numeric value by  on 1-July-2013
    /// </summary>
    /// <param name="val">The value.</param>
    /// <param name="NumberStyle">The number style.</param>
    /// <returns><c>true</c> if the specified value is numeric; otherwise, <c>false</c>.</returns>
    public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
    {
        Double result;
        return Double.TryParse(val, NumberStyle,
            System.Globalization.CultureInfo.CurrentCulture, out result);
    }

    /// <summary>
    /// Added Code for Resolve issue of Update Panel Exception on download file click by  on 2-Jun-2013
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbFileName_PreRender(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            LinkButton MyButton = (LinkButton)sender;
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(MyButton);
        }
    }
    //End
}
