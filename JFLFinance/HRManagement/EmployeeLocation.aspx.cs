// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeLocation.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_EmployeeLocation
/// </summary>
public partial class Masters_EmployeeLocation : BasePage
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
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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

    #region Page Functions
    /// <summary>
    /// Function called on Page Initialization.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    /// <summary>
    /// Function called on Page Load event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.IntraCompanyTransfer + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillgvEmployeeLocation();
                FillddlSearchBy();
                txtSearch.Visible = true;
                txtSearch.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtSearch.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
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
    /// Function fill the Grid View Employee Location Details.
    /// </summary>
    protected void FillgvEmployeeLocation()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet dsEmployeeLocation = new DataSet();
        DataTable dtEmployeeLocation = new DataTable();
        int dtflag;
        dtflag = 1;
        dsEmployeeLocation = objHRManagement.EmployeesOfLocationGetAll(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
        dtEmployeeLocation = dsEmployeeLocation.Tables[0];

        //to fix empety gridview
        if (dtEmployeeLocation.Rows.Count == 0)
        {
            dtflag = 0;
            dtEmployeeLocation.Rows.Add(dtEmployeeLocation.NewRow());
        }
        gvEmployeeLocation.DataKeyNames = new string[] { "LocationDesc" };
        gvEmployeeLocation.DataSource = dtEmployeeLocation;
        gvEmployeeLocation.DataBind();

        if (dtflag == 0)
        {
            gvEmployeeLocation.Rows[0].Visible = false;
        }
    }
    #endregion

    #region GridView Commands Events
    /// <summary>
    /// Function called on Grid View Employee Location RowDataBound Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeLocation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerial");
            if (lblSerialNo != null)
            {
                int serialNo = gvEmployeeLocation.PageIndex * gvEmployeeLocation.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                BL.MastersManagement objMastersManagement = new BL.MastersManagement();
                DropDownList cmbType = (DropDownList)e.Row.FindControl("cmbFutureLocation");
                HyperLink imgEffectiveToDate = (HyperLink)e.Row.FindControl("imgEffectiveToDate");
                TextBox txtEffectiveTo = (TextBox)e.Row.FindControl("txtEffectiveTo");
                Label lblEffectiveFrom = (Label)e.Row.FindControl("lblEffectiveFrom");
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");

                if (txtEffectiveTo != null && imgEffectiveToDate != null)
                {
                    txtEffectiveTo.Attributes.Add("readonly", "readonly");
                    imgEffectiveToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtEffectiveTo.ClientID.ToString() + "');";
                }
                if (cmbType != null)
                {
                    cmbType.DataSource = objMastersManagement.LocationDescriptionGetAll(BaseCompanyCode);
                    cmbType.DataValueField = "LocationAutoID";
                    cmbType.DataTextField = "LocationDesc";
                    cmbType.DataBind();
                }
            }
        }
    }

    /// <summary>
    /// Function called on Grid View Employee Location RowUpdating Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeLocation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        string strFutureLocation;
        BL.HRManagement objMasterManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        Label lblLocationAutoID = (Label)gvEmployeeLocation.Rows[e.RowIndex].FindControl("lblLocationAutoID");
        Label lblEmployeeNumber = (Label)gvEmployeeLocation.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        Label lblLocationDesc = (Label)gvEmployeeLocation.Rows[e.RowIndex].FindControl("lblLocationDesc");
        Label lblEffectiveFrom = (Label)gvEmployeeLocation.Rows[e.RowIndex].FindControl("lblEffectiveFrom");  
        TextBox txtEffectiveTo = (TextBox)gvEmployeeLocation.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        DropDownList cmbFutureLocation = (DropDownList)gvEmployeeLocation.Rows[e.RowIndex].FindControl("cmbFutureLocation");
        TextBox txtComment = (TextBox)gvEmployeeLocation.Rows[e.RowIndex].FindControl("txtComment");
        

        strFutureLocation = cmbFutureLocation.SelectedItem.Value.ToString();
        if (lblLocationAutoID.Text != strFutureLocation)
        {
            if (CompareDates(DateTime.Parse(txtEffectiveTo.Text), DateTime.Parse(lblEffectiveFrom.Text)) == 1)
            {

                ds = objMasterManagement.EmployeeLocationUpdate(BaseCompanyCode, lblLocationAutoID.Text, lblEmployeeNumber.Text,lblEmployeeNumber.Text, strFutureLocation, txtEffectiveTo.Text, BaseUserID, BaseCompanyCode, txtComment.Text);

                gvEmployeeLocation.EditIndex = -1;
                FillgvEmployeeLocation();

                gvEmployeeLocation.Columns[7].Visible = false;
                gvEmployeeLocation.Columns[8].Visible = false;

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.ToDateMustBeGreaterThanFromDate);
            }
        }
    }
    /// <summary>
    /// Function called on Grid View Employee Location RowEditing Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeLocation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployeeLocation.Columns[7].Visible = true;
        gvEmployeeLocation.Columns[8].Visible = true;

        gvEmployeeLocation.EditIndex = e.NewEditIndex;

        btnSearch_Click(sender, e);

        SearchAction();
    }

    /// <summary>
    /// Function called on Grid View Employee Location RowCancelingEdit Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeLocation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmployeeLocation.Columns[7].Visible = false;
        gvEmployeeLocation.Columns[8].Visible = false;
        gvEmployeeLocation.EditIndex = -1;
        FillgvEmployeeLocation();
    }
    /// <summary>
    /// Function called on Grid View Employee Location PageIndexChanging Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeLocation.PageIndex = e.NewPageIndex;
        gvEmployeeLocation.EditIndex = -1;
        FillgvEmployeeLocation();
    }
    #endregion

    #region Function Related to Search In Gridview
    /// <summary>
    /// Function called on Drop Down List SearchBy SelectIndexChanged Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeTextBoxBasedOnddlSearchBySelectedIndexChanged();
        if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
        {
            txtSearchDate.Visible = true;
            imgSearchGrid.Visible = true;
            txtSearch.Visible = false;
            txtSearchDate.Attributes.Add("readonly", "readonly");
            imgSearchGrid.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSearchDate.ClientID.ToString() + "');";
        }
        else
        {
            txtSearch.Visible = true;
            txtSearchDate.Visible = false;
            imgSearchGrid.Visible = false;
        }
        txtSearch.Text = "";
        txtSearchDate.Text = "";
    }

    /// <summary>
    /// Function used to change Visibility based on Drop Down List SearchBy.
    /// </summary>
    private void ChangeTextBoxBasedOnddlSearchBySelectedIndexChanged()
    {
        if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
        {
            txtSearchDate.Visible = true;
            imgSearchGrid.Visible = true;
            txtSearch.Visible = false;
            txtSearchDate.Attributes.Add("readonly", "readonly");
            imgSearchGrid.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtSearchDate.ClientID.ToString() + "');";
        }
        else
        {
            txtSearch.Visible = true;
            txtSearchDate.Visible = false;
            imgSearchGrid.Visible = false;
        }
    }

    /// <summary>
    /// Function used to call on Button Search Click Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (txtSearch.Text != "" || txtSearchDate.Text != "")
        {
            btnViewAll.Visible = true;
        }

        if (txtSearchDate.Text != "" || txtSearch.Text != "")
        {
            if (ddlSearchBy.SelectedValue.ToString() == Resources.Resource.JoiningDate)
            {
                hfSearchText.Value = txtSearchDate.Text;
            }
            else
            {
                hfSearchText.Value = txtSearch.Text.Trim();
            }
            SearchAction();
        }
    }
    /// <summary>
    /// Function To Search In grid view LOI Received Based on ddlSearchBy and txtSearch Value
    /// </summary>
    private void SearchAction()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataTable dtAddEmpDetail = new DataTable();
        dtAddEmpDetail = objHRManagement.EmployeesOfLocationGetAll(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode).Tables[0];
        dtAddEmpDetail.Columns["EmployeeNumber"].ColumnName = Resources.Resource.EmployeeNumber;
        dtAddEmpDetail.Columns["Name"].ColumnName = Resources.Resource.EmployeeName;

        DataTable dt = new DataTable();
        DataView dv = new DataView(dtAddEmpDetail);

        dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);
        
        dt = dv.ToTable();
        dt.Columns[Resources.Resource.EmployeeNumber].ColumnName = "EmployeeNumber";
        dt.Columns[Resources.Resource.EmployeeName].ColumnName = "Name";
        gvEmployeeLocation.DataSource = dt;
        gvEmployeeLocation.DataBind();
    }
    /// <summary>
    /// Function called on Button ViewAll Click Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        FillgvEmployeeLocation();
    }
    /// <summary>
    /// Function used to fill Drop Down List Search By Control.
    /// </summary>
    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        arr.Add(gvEmployeeLocation.Columns[2]);
        arr.Add(gvEmployeeLocation.Columns[3]);
        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();
    }

    #endregion

}
