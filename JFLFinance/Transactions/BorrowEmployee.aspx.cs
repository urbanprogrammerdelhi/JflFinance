// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="BorrowEmployee.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

/// <summary>
/// Class Transactions_BorrowEmployee.
/// </summary>
public partial class Transactions_BorrowEmployee : BasePage
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
            if (IsReadAccess == true)
            {
                System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resources.Resource.BorrowEmployee + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

                ibtnSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH_ReqNO0&ControlId=" + txtRequestNo.ClientID.ToString() + "&Company=" + BaseCompanyCode + "&HrLocation=" + BaseHrLocationCode + "&Location=" + BaseLocationCode + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=1000px,Height=600,help=no')");
                txtRequestNo.Attributes["onTextChanged"] = "javascript: Changed( this );";

                BL.Roster objRoster = new BL.Roster();
                DataTable dtSysParam = new DataTable();
                dtSysParam = objRoster.AllowBorrowEmployeeSystemParametersGet(BaseCompanyCode);
                if (dtSysParam != null && dtSysParam.Rows.Count > 0)
                {
                    hfAllowBorrowEmployee.Value = dtSysParam.Rows[0][0].ToString();
                }
                else
                {
                    hfAllowBorrowEmployee.Value = "0";
                }

                BL.MastersManagement objMasterManagement = new BL.MastersManagement();
                DataSet ds = new DataSet();
                ds = objMasterManagement.LocationDetailGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblDivision.Text = ds.Tables[0].Rows[0]["HrLocationDesc"].ToString() + " (" + ds.Tables[0].Rows[0]["HrLocationCode"].ToString() + ")";
                    lblLocation.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString() + " (" + ds.Tables[0].Rows[0]["LocationCode"].ToString() + ")";
                }
                FillddlFromArea();
                FillddlToDivision();

                if (Request.QueryString["RequestNo"] != null)
                {
                    txtRequestNo.Text = Request.QueryString["RequestNo"].ToString();
                    PageViewMode();
                }
                if (txtRequestNo.Text == @"")
                {
                    PageAddMode();
                }
                else
                {
                    PageViewMode();
                }

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    /// <summary>
    /// Pages the view mode.
    /// </summary>
    private void PageViewMode()
    {
        btnCreate.Visible = false;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSend.Visible = false;
        gvRequest.Visible = false;
        gvEmpAssign.Visible = false;

        if (txtRequestNo.Text != @"")
        {
            FetchRequestHdrDetails();
            gvRequest.Visible = true;
            FillgvRequest();
            if (txtStatus.Text == Resources.Resource.Fresh.ToString())
            {
                btnCreate.Visible = false;
                btnUpdate.Visible = true;
                if (IsDeleteAccess == true)
                {
                    btnDelete.Visible = true;
                }
                btnSend.Visible = true;

                ddlFromArea.Enabled = true;
                ddlFromClient.Enabled = true;
                ddlFromAsmt.Enabled = true;
                ddlFromPost.Enabled = true;
                ddlFromSoRank.Enabled = true;
                ddlToDivision.Enabled = true;
                ddlToLocation.Enabled = true;
                ddlToArea.Enabled = true;
            }
            //else if (txtStatus.Text == Resources.Resource.Sent.ToString())
            //{
            //    btnCreate.Visible = false;
            //    btnUpdate.Visible = false;
            //    btnDelete.Visible = false;
            //    btnSend.Visible = false;
            //    gvEmpAssign.Visible = false;
            //}
            //else if (txtStatus.Text == Resources.Resource.Rejected.ToString())
            //{
            //    btnCreate.Visible = false;
            //    btnUpdate.Visible = false;
            //    btnDelete.Visible = false;
            //    btnSend.Visible = false;
            //    gvEmpAssign.Visible = false;
            //}
            else if (txtStatus.Text == Resources.Resource.Approved.ToString())
            {
                btnCreate.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSend.Visible = false;

                ddlFromArea.Enabled = false;
                ddlFromClient.Enabled = false;
                ddlFromAsmt.Enabled = false;
                ddlFromPost.Enabled = false;
                ddlFromSoRank.Enabled = false;
                ddlToDivision.Enabled = false;
                ddlToLocation.Enabled = false;
                ddlToArea.Enabled = false;

                gvEmpAssign.Visible = true;
                FillgvEmpAssign();
            }
            else
            {
                btnCreate.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSend.Visible = false;

                ddlFromArea.Enabled = false;
                ddlFromClient.Enabled = false;
                ddlFromAsmt.Enabled = false;
                ddlFromPost.Enabled = false;
                ddlFromSoRank.Enabled = false;
                ddlToDivision.Enabled = false;
                ddlToLocation.Enabled = false;
                ddlToArea.Enabled = false;

                gvEmpAssign.Visible = false;
            }
        }
        else
        {
            if (IsWriteAccess == true)
            {
                btnCreate.Visible = true;
            }

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSend.Visible = false;
            gvRequest.Visible = false;
            gvEmpAssign.Visible = false;
        }

        if (hfAllowBorrowEmployee.Value == "2")
        {
            ddlFromArea.Enabled = false;
            ddlFromClient.Enabled = false;
            ddlFromAsmt.Enabled = false;
            ddlFromPost.Enabled = false;
            ddlFromSoRank.Enabled = false;
        }
        else if (hfAllowBorrowEmployee.Value == "1")
        {
            ddlFromClient.Enabled = false;
            ddlFromAsmt.Enabled = false;
            ddlFromPost.Enabled = false;
            ddlFromSoRank.Enabled = false;
        }
    }
    /// <summary>
    /// Pages the add mode.
    /// </summary>
    private void PageAddMode()
    {
        txtRequestNo.Text = string.Empty;
        txtStatus.Text = string.Empty;
        hfStatus.Value = string.Empty;
        PageViewMode();
    }
    /// <summary>
    /// Fetches the request HDR details.
    /// </summary>
    private void FetchRequestHdrDetails()
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();

        if (txtRequestNo.Text != @"")
        {
            ds = objRoster.BorrowEmployeeRequestDetailGet(BaseLocationAutoID, txtRequestNo.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtStatus.Text = ResourceValueOfKeyOnlyforStatus_Get(ds.Tables[0].Rows[0]["RequestStatus"].ToString());
                hfStatus.Value = ds.Tables[0].Rows[0]["RequestStatus"].ToString();

                ddlFromArea.SelectedValue = ds.Tables[0].Rows[0]["AreaId"].ToString();
                FillddlFromClient();
                ddlFromClient.SelectedValue = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                FillddlFromAsmt();
                ddlFromAsmt.SelectedValue = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                FillddlFromPost();
                ddlFromPost.SelectedValue = ds.Tables[0].Rows[0]["PostAutoId"].ToString();
                FillddlFromSoRank();
                ddlFromSoRank.SelectedValue = ds.Tables[0].Rows[0]["SoRank"].ToString();

                ddlToDivision.SelectedValue = ds.Tables[0].Rows[0]["ToHrLocationCode"].ToString();
                FillddlToLocation();
                ddlToLocation.SelectedValue = ds.Tables[0].Rows[0]["ToLocationAutoId"].ToString();
                FillddlToArea();
                ddlToArea.SelectedValue = ds.Tables[0].Rows[0]["ToAreaId"].ToString();
            }
            else
            {
                txtStatus.Text = "";
                hfStatus.Value = "";
            }
        }
    }
    #endregion

    #region Controle Binding
    /// <summary>
    /// Fillddls from area.
    /// </summary>
    private void FillddlFromArea()
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (BaseUserIsAreaIncharge == "0")
        {
            ds = objOperationManagement.AreaIdGet(BaseLocationAutoID, @"ALL");
        }
        else
        {
            ds = objOperationManagement.AreaIdGet(BaseLocationAutoID, BaseUserEmployeeNumber);
        }

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlFromArea.DataSource = ds;
            ddlFromArea.DataValueField = "AreaId";
            ddlFromArea.DataTextField = "AreaDesc";
            ddlFromArea.DataBind();

            if (hfAllowBorrowEmployee.Value == "2")
            {
                var li = new RadComboBoxItem();
                li.Text = Resources.Resource.All;
                li.Value = @"ALL";
                ddlFromArea.Items.Insert(0, li);
                ddlFromArea.SelectedIndex = 0;
            }
        }
        else
        {
            ddlFromArea.Items.Clear();
            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.NoDataToShow.ToString();
            li.Value = @"-1";
            ddlFromArea.Items.Add(li);
        }
        FillddlFromClient();
    }
    /// <summary>
    /// Fillddls from client.
    /// </summary>
    private void FillddlFromClient()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.ClientAreaWiseGet(BaseLocationAutoID, BaseUserEmployeeNumber, ddlFromArea.SelectedItem.Value.ToString());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlFromClient.DataSource = ds.Tables[0];
            ddlFromClient.DataTextField = "ClientNameCode";
            ddlFromClient.DataValueField = "ClientCode";
            ddlFromClient.DataBind();

            if (hfAllowBorrowEmployee.Value == "2" || hfAllowBorrowEmployee.Value == "1")
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.All;
                li1.Value = @"ALL";
                ddlFromClient.Items.Insert(0, li1);
                ddlFromClient.SelectedIndex = 0;
            }
        }
        else
        {
            ddlFromClient.Items.Clear();
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlFromClient.Items.Insert(0, li1);
        }
        FillddlFromAsmt();
    }
    /// <summary>
    /// Fillddls from asmt.
    /// </summary>
    private void FillddlFromAsmt()
    {
        ddlFromAsmt.Items.Clear();
        if (ddlFromClient.SelectedItem.Value.ToString() == "ALL")
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlFromAsmt.Items.Add(li1);
        }
        else if (ddlFromClient.SelectedItem.Value.ToString() == "-1")
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlFromAsmt.Items.Add(li1);
        }
        else
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();

            ds = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), ddlFromClient.SelectedValue.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now), BaseUserEmployeeNumber, ddlFromArea.SelectedItem.Value.ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlFromAsmt.DataSource = ds.Tables[0];
                ddlFromAsmt.DataTextField = "AsmtAddressId";
                ddlFromAsmt.DataValueField = "AsmtId";
                ddlFromAsmt.DataBind();

                if (hfAllowBorrowEmployee.Value == "2" || hfAllowBorrowEmployee.Value == "1")
                {
                    var li1 = new RadComboBoxItem();
                    li1.Text = Resources.Resource.All;
                    li1.Value = "ALL";
                    ddlFromAsmt.Items.Insert(0, li1);
                    ddlFromAsmt.SelectedIndex = 0;
                }
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlFromAsmt.Items.Insert(0, li1);
            }
        }
        FillddlFromPost();
    }
    /// <summary>
    /// Fillddls from post.
    /// </summary>
    private void FillddlFromPost()
    {
        ddlFromPost.Items.Clear();
        if (ddlFromAsmt.SelectedItem.Value.ToString() == "ALL")
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlFromPost.Items.Add(li1);
        }
        else if (ddlFromAsmt.SelectedItem.Value.ToString() == "-1")
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlFromPost.Items.Add(li1);
        }
        else
        {
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();
            DataSet ds = new DataSet();
            ds = objMasterManagement.AsmtIdPostGet(BaseLocationAutoID.ToString(), BaseUserEmployeeNumber, ddlFromArea.SelectedItem.Value.ToString(), ddlFromClient.SelectedItem.Value.ToString(), ddlFromAsmt.SelectedItem.Value.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlFromPost.DataSource = ds.Tables[0];
                ddlFromPost.DataTextField = "SiteDesc";
                ddlFromPost.DataValueField = "PostAutoId";
                ddlFromPost.DataBind();

                if (hfAllowBorrowEmployee.Value == "2" || hfAllowBorrowEmployee.Value == "1")
                {
                    var li2 = new RadComboBoxItem();
                    li2.Text = Resources.Resource.All;
                    li2.Value = "ALL";
                    ddlFromPost.Items.Insert(0, li2);
                    ddlFromPost.SelectedIndex = 0;
                }
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlFromPost.Items.Add(li1);
            }
        }
        FillddlFromSoRank();
    }
    /// <summary>
    /// Fillddls from so rank.
    /// </summary>
    private void FillddlFromSoRank()
    {
        ddlFromSoRank.Items.Clear();
        if (ddlFromPost.SelectedItem.Value.ToString() == "ALL")
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlFromSoRank.Items.Add(li1);
        }
        else if (ddlFromPost.SelectedItem.Value.ToString() == "-1")
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlFromSoRank.Items.Add(li1);
        }
        else
        {
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();
            DataSet ds = new DataSet();
            ds = objMasterManagement.AsmtIdPostSoRankFromSODGet(BaseLocationAutoID.ToString(), ddlFromClient.SelectedItem.Value.ToString(), ddlFromAsmt.SelectedItem.Value.ToString(), ddlFromPost.SelectedItem.Value.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlFromSoRank.DataSource = ds.Tables[0];
                ddlFromSoRank.DataTextField = "SoRank";
                ddlFromSoRank.DataValueField = "SoRank";
                ddlFromSoRank.DataBind();

                if (hfAllowBorrowEmployee.Value == "2" || hfAllowBorrowEmployee.Value == "1")
                {
                    var li2 = new RadComboBoxItem();
                    li2.Text = Resources.Resource.All;
                    li2.Value = "ALL";
                    ddlFromSoRank.Items.Insert(0, li2);
                    ddlFromSoRank.SelectedIndex = 0;
                }
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlFromSoRank.Items.Add(li1);
            }
        }
    }

    /// <summary>
    /// Fillddls to division.
    /// </summary>
    private void FillddlToDivision()
    {
        DataSet ds = new DataSet();
        BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        ds = objblMasterManagement.HRLocationDescriptionGetAll(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlToDivision.DataSource = ds.Tables[0];
            ddlToDivision.DataValueField = "HrLocationCode";
            ddlToDivision.DataTextField = "HrLocationDescCode";
            ddlToDivision.DataBind();
        }
        else
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlToDivision.Items.Add(li1);
        }
        FillddlToLocation();
    }
    /// <summary>
    /// Fillddls to location.
    /// </summary>
    private void FillddlToLocation()
    {
        ddlToLocation.Items.Clear();
        if (ddlToDivision.SelectedItem.Value.ToString() == "-1")
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlToLocation.Items.Add(li1);
        }
        else
        {
            DataSet ds = new DataSet();
            BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
            ds = objblMasterManagement.LocationDescriptionGetAll(BaseCompanyCode, ddlToDivision.SelectedItem.Value.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(ds.Tables[0]);

                if (hfAllowBorrowEmployee.Value != "0" && hfAllowBorrowEmployee.Value != "1")
                {
                    dv.RowFilter = "LocationAutoId <> '" + BaseLocationAutoID + "'";
                }
                ddlToLocation.DataSource = dv;
                ddlToLocation.DataValueField = "LocationAutoId";
                ddlToLocation.DataTextField = "LocationDescCode";
                ddlToLocation.DataBind();

                //var li = new RadComboBoxItem();
                //li.Text = Resources.Resource.All;
                //li.Value = "ALL";
                //ddlToLocation.Items.Insert(0, li);
                //ddlToLocation.SelectedIndex = 0;
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlToLocation.Items.Add(li1);
            }
        }
        FillddlToArea();
    }
    /// <summary>
    /// Fillddls to area.
    /// </summary>
    private void FillddlToArea()
    {
        if (ddlToLocation.SelectedIndex >-1)
        {
            BL.Roster objRoster = new BL.Roster();
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            ds = objOperationManagement.AreaIdGet(ddlToLocation.SelectedItem.Value.ToString(), @"ALL");

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                if (BaseLocationAutoID == ddlToLocation.SelectedItem.Value.ToString())
                {
                    dv.RowFilter = "AreaId <> '" + ddlFromArea.SelectedItem.Value.ToString() + "'";
                }
                ddlToArea.DataSource = dv;
                ddlToArea.DataValueField = "AreaId";
                ddlToArea.DataTextField = "AreaDesc";
                ddlToArea.DataBind();
            }
            else
            {
                ddlToArea.Items.Clear();
                var li = new RadComboBoxItem();
                li.Text = Resources.Resource.NoDataToShow.ToString();
                li.Value = @"-1";
                ddlToArea.Items.Add(li);
            }
        }
    }

    /// <summary>
    /// Fillgvs the request.
    /// </summary>
    private void FillgvRequest()
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        if (txtRequestNo.Text != "")
        {
            int dtflag;
            dtflag = 1;

            ds = objRoster.BorrowEmployeeRequestDetailGet(BaseLocationAutoID, txtRequestNo.Text);
            if (ds != null && ds.Tables.Count > 1)
            {
                dt = ds.Tables[1];
                if (dt.Rows.Count == 0)
                {
                    dtflag = 0;
                    dt.Rows.Add(dt.NewRow());
                }
                gvRequest.DataSource = dt;
                gvRequest.DataBind();
                if (dtflag == 0)
                {
                    gvRequest.Rows[0].Visible = false;
                }
            }
        }
    }
    /// <summary>
    /// Fillgvs the emp assign.
    /// </summary>
    private void FillgvEmpAssign()
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        if (txtRequestNo.Text != "")
        {
            ds = objRoster.BorrowedEmployeeGet(BaseLocationAutoID, txtRequestNo.Text);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    gvEmpAssign.DataSource = dt;
                    gvEmpAssign.DataBind();
                    gvEmpAssign.Rows[0].Visible = false;
                }
                else
                {
                    gvEmpAssign.DataSource = dt;
                    gvEmpAssign.DataBind();
                }
            }
        }
    }
    #endregion Control Binding

    #region Control Events
    /// <summary>
    /// Handles the TextChanged event of the txtRequestNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtRequestNo_TextChanged(object sender, EventArgs e)
    {
        PageViewMode();
    }
    /// <summary>
    /// Handles the Click event of the ibtnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlFromArea control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlFromArea_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlFromClient();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlFromClient control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlFromClient_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlFromAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlFromAsmt control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlFromAsmt_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlFromPost();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlFromPost control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlFromPost_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlFromSoRank();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlToDivision control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlToDivision_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlToLocation();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlToLocation control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlToLocation_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlToArea();
    }

    /// <summary>
    /// Handles the TextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        TextBox txtFromDate = (TextBox)sender;

        if (!ConvertStringToDateFormat(txtFromDate, lblError))
        {
            txtFromDate.Focus();
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        TextBox txtToDate = (TextBox)sender;

        if (!ConvertStringToDateFormat(txtToDate, lblError))
        {
            txtToDate.Focus();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnCreate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        BL.Roster objcreate = new BL.Roster();
        DataSet ds = new DataSet();
        if (ddlFromArea.SelectedItem.Value.ToString() != "-1" && ddlFromClient.SelectedItem.Value.ToString() != "-1"
            && ddlFromAsmt.SelectedItem.Value.ToString() != "-1" && ddlFromPost.SelectedItem.Value.ToString() != "-1"
            && ddlFromSoRank.SelectedItem.Value.ToString() != "-1"
            && ddlToDivision.SelectedItem.Value.ToString() != "-1" && ddlToLocation.SelectedIndex > -1
            && ddlToArea.SelectedIndex >-1)
        {
            ds = objcreate.BorrowEmployeeRequestInsertHdr(BaseLocationAutoID, ddlFromArea.SelectedItem.Value.ToString(),
                ddlFromClient.SelectedItem.Value.ToString(), ddlFromAsmt.SelectedItem.Value.ToString(), ddlFromPost.SelectedItem.Value.ToString(),
                ddlFromSoRank.SelectedItem.Value.ToString(), ddlToLocation.SelectedItem.Value.ToString(), ddlToArea.SelectedItem.Value.ToString(), strStatusFresh, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblError, ds.Tables[0].Rows[0][0].ToString());
                txtRequestNo.Text = ds.Tables[0].Rows[0]["RequestNo"].ToString();
            }
            PageViewMode();
        }
        else
        {
            DisplayMessageString(lblError, Resources.Resource.MsgRequiredFieldLeftBlank);
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        BL.Roster objUpdate = new BL.Roster();
        DataSet ds = new DataSet();
        if (txtRequestNo.Text != @"" && txtStatus.Text == Resources.Resource.Fresh.ToString())
        {
            if (ddlFromArea.SelectedItem.Value.ToString() != "-1" && ddlFromClient.SelectedItem.Value.ToString() != "-1"
            && ddlFromAsmt.SelectedItem.Value.ToString() != "-1" && ddlFromPost.SelectedItem.Value.ToString() != "-1"
            && ddlFromSoRank.SelectedItem.Value.ToString() != "-1"
            && ddlToDivision.SelectedItem.Value.ToString() != "-1" && ddlToLocation.SelectedItem.Value.ToString() != "-1"
            && ddlToArea.SelectedItem.Value.ToString() != "-1")
            {
                ds = objUpdate.BorrowEmployeeRequestUpdateHdr(BaseLocationAutoID, txtRequestNo.Text.ToString(), ddlFromArea.SelectedItem.Value.ToString(),
                    ddlFromClient.SelectedItem.Value.ToString(), ddlFromAsmt.SelectedItem.Value.ToString(), ddlFromPost.SelectedItem.Value.ToString(),
                    ddlFromSoRank.SelectedItem.Value.ToString(), ddlToLocation.SelectedItem.Value.ToString(), ddlToArea.SelectedItem.Value.ToString(), BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblError, ds.Tables[0].Rows[0][0].ToString());
                }
            }
            else
            {
                DisplayMessageString(lblError, Resources.Resource.MsgRequiredFieldLeftBlank);
            }
        }
        PageViewMode();
    }
    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        BL.Roster objDelete = new BL.Roster();
        DataSet ds = new DataSet();

        ds = objDelete.BorrowEmployeeRequestDeleteHdr(BaseLocationAutoID, txtRequestNo.Text, hfStatus.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblError, ds.Tables[0].Rows[0][0].ToString());
        }
        PageAddMode();
    }
    /// <summary>
    /// Handles the Click event of the btnSend control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        DataTable gvdt = new DataTable();
        if (txtRequestNo.Text != "" && txtStatus.Text == Resources.Resource.Fresh.ToString() && gvRequest.Rows[0].Visible == true)
        {
            ds = objRoster.BorrowEmployeeRequestSend(BaseLocationAutoID, txtRequestNo.Text, strStatusSent);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblError, ds.Tables[0].Rows[0][0].ToString());
            }
        }
        PageViewMode();
    }
    #endregion Control Events

    #region Gridview Events
    /// <summary>
    /// Fillddls the designation.
    /// </summary>
    /// <param name="ddlDesignation">The DDL designation.</param>
    private void FillddlDesignation(RadComboBox ddlDesignation)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        ds = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            ddlDesignation.DataSource = ds;
            ddlDesignation.DataValueField = "DesignationCode";
            ddlDesignation.DataTextField = "DesignationDesc";
            ddlDesignation.DataBind();
        }
        else
        {
            ddlDesignation.Items.Clear();
            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.NoDataToShow.ToString();
            li.Value = @"-1";
            ddlDesignation.Items.Add(li);
        }
    }
    /// <summary>
    /// Sets the time validation to text box.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    private void SetTimeValidationToTextBox(object textBox)
    {
        if (textBox != null)
        {
            TextBox TimeTextBox = (TextBox)textBox;
            TimeTextBox.Attributes["onKeyUp"] = "javascript:Timevalnum('" + TimeTextBox.ClientID.ToString() + "');";
            TimeTextBox.Attributes["onblur"] = "javascript:IsValidTime('" + TimeTextBox.ClientID.ToString() + "');";
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtNoOfPerson = (TextBox)e.Row.FindControl("txtNoOfPerson");
            TextBox txtFromDate = (TextBox)e.Row.FindControl("txtFromDate");
            TextBox txtToDate = (TextBox)e.Row.FindControl("txtToDate");
            TextBox txtFromTime = (TextBox)e.Row.FindControl("txtFromTime");
            TextBox txtToTime = (TextBox)e.Row.FindControl("txtToTime");
            RadComboBox ddlDesignation = (RadComboBox)e.Row.FindControl("ddlDesignation");
            HiddenField hfDesignationCode = (HiddenField)e.Row.FindControl("hfDesignationCode");

            if (txtNoOfPerson != null)
            {
                txtNoOfPerson.Attributes["onKeyUp"] = "javascript:validateNumeric('" + txtNoOfPerson.ClientID.ToString() + "');";
            }
            if (txtFromDate != null && txtToDate != null)
            {
                txtFromDate.Attributes["readonly"] = "readonly";
                txtToDate.Attributes["readonly"] = "readonly";
            }
            SetTimeValidationToTextBox(txtFromTime);
            SetTimeValidationToTextBox(txtToTime);
            if (ddlDesignation != null && hfDesignationCode != null)
            {
                FillddlDesignation(ddlDesignation);
                ddlDesignation.SelectedValue = hfDesignationCode.Value.ToString();
            }
            ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
            ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");


            if (txtStatus.Text != Resources.Resource.Fresh.ToString())
            {
                gvRequest.ShowFooter = false;
                gvRequest.Columns[7].Visible = false;
            }
            else
            {
                if (IsModifyAccess != true && IsDeleteAccess != true)
                { gvRequest.Columns[7].Visible = false; }
                else
                { gvRequest.Columns[7].Visible = true; }
                if (ImgbtnEdit != null)
                {
                    if (IsModifyAccess != true)
                    {
                        ImgbtnEdit.Visible = false;
                    }
                    else
                    {
                        ImgbtnEdit.Visible = true;
                    }
                }
                if (ImgbtnDelete != null)
                {
                    if (IsDeleteAccess != true)
                    {
                        ImgbtnDelete.Visible = false;
                    }
                    else
                    {
                        ImgbtnDelete.Visible = true;
                    }
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtNoOfPerson = (TextBox)e.Row.FindControl("txtNoOfPerson");
            TextBox txtFromDate = (TextBox)e.Row.FindControl("txtFromDate");
            TextBox txtToDate = (TextBox)e.Row.FindControl("txtToDate");
            TextBox txtFromTime = (TextBox)e.Row.FindControl("txtFromTime");
            TextBox txtToTime = (TextBox)e.Row.FindControl("txtToTime");
            RadComboBox ddlDesignation = (RadComboBox)e.Row.FindControl("ddlDesignation");

            if (txtNoOfPerson != null)
            {
                txtNoOfPerson.Attributes["onKeyUp"] = "javascript:validateNumeric('" + txtNoOfPerson.ClientID.ToString() + "');";
            }
            if (txtFromDate != null && txtToDate != null)
            {
                txtFromDate.Attributes["readonly"] = "readonly";
                txtToDate.Attributes["readonly"] = "readonly";
            }
            SetTimeValidationToTextBox(txtFromTime);
            SetTimeValidationToTextBox(txtToTime);
            if (ddlDesignation != null)
            {
                FillddlDesignation(ddlDesignation);
            }
            if (IsWriteAccess == true && txtStatus.Text == Resources.Resource.Fresh.ToString())
            {
                gvRequest.ShowFooter = true;
            }
            else
            {
                gvRequest.ShowFooter = false;
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtNoOfPerson = (TextBox)gvRequest.FooterRow.FindControl("txtNoOfPerson");
        TextBox txtFromDate = (TextBox)gvRequest.FooterRow.FindControl("txtFromDate");
        TextBox txtToDate = (TextBox)gvRequest.FooterRow.FindControl("txtToDate");
        TextBox txtFromTime = (TextBox)gvRequest.FooterRow.FindControl("txtFromTime");
        TextBox txtToTime = (TextBox)gvRequest.FooterRow.FindControl("txtToTime");
        RadComboBox ddlDesignation = (RadComboBox)gvRequest.FooterRow.FindControl("ddlDesignation");

        if (e.CommandName == "Add")
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            BL.Roster objRoster = new BL.Roster();
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();

            if (txtFromTime.Text == "")
            {
                txtFromTime.Text = @"00:00";
            }
            if (txtToTime.Text == "")
            {
                txtToTime.Text = @"00:00";
            }

            if (txtRequestNo.Text != @"" && txtNoOfPerson.Text != @"" && int.Parse(txtNoOfPerson.Text) > 0
                                && txtFromDate.Text != "" && txtToDate.Text != ""
                                && txtFromTime.Text != "" && txtToTime.Text != ""
                                && ddlDesignation.Items.Count > 0 && ddlDesignation.SelectedItem.Value.ToString() != "")
            {
                bool datestatus = GetGreaterDate(DateTime.Parse(txtFromDate.Text.ToString()), DateTime.Parse(txtToDate.Text.ToString()));
                if (datestatus == true)
                {
                    DisplayMessageString(lblError, Resources.Resource.ToDateMustBeGreaterThanFromDate);
                    txtFromDate.Focus();
                }
                else
                {
                    ds = objRoster.BorrowEmployeeDetailInsert(BaseLocationAutoID, txtRequestNo.Text, int.Parse(txtNoOfPerson.Text),
                            ddlDesignation.SelectedItem.Value.ToString(), DateFormat(DateTime.Parse(txtFromDate.Text)),
                            DateFormat(DateTime.Parse(txtToDate.Text)), txtFromTime.Text, txtToTime.Text, BaseUserID);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Columns[0].ColumnName == "MessageID")
                    {
                        DisplayMessageForResourceKey(lblError, ds.Tables[0].Rows[0]["MessageString"].ToString());
                    }

                }
            }
            FillgvRequest();
        }
        else if (e.CommandName == "Reset")
        {
            txtNoOfPerson.Text = "";
            txtFromDate.Text = "";
            txtToDate.Text = "";
            txtFromTime.Text = "";
            txtToTime.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRequest.EditIndex = e.NewEditIndex;
        FillgvRequest();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRequest.EditIndex = -1;
        FillgvRequest();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtNoOfPerson = (TextBox)gvRequest.Rows[e.RowIndex].FindControl("txtNoOfPerson");
        TextBox txtFromDate = (TextBox)gvRequest.Rows[e.RowIndex].FindControl("txtFromDate");
        TextBox txtToDate = (TextBox)gvRequest.Rows[e.RowIndex].FindControl("txtToDate");
        TextBox txtFromTime = (TextBox)gvRequest.Rows[e.RowIndex].FindControl("txtFromTime");
        TextBox txtToTime = (TextBox)gvRequest.Rows[e.RowIndex].FindControl("txtToTime");
        RadComboBox ddlDesignation = (RadComboBox)gvRequest.Rows[e.RowIndex].FindControl("ddlDesignation");
        HiddenField hfRequestLineNo = (HiddenField)gvRequest.Rows[e.RowIndex].FindControl("hfRequestLineNo");

        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        if (txtFromTime.Text == "")
        {
            txtFromTime.Text = @"00:00";
        }
        if (txtToTime.Text == "")
        {
            txtToTime.Text = @"00:00";
        }

        if (txtRequestNo.Text != @"" && txtNoOfPerson.Text != @"" && int.Parse(txtNoOfPerson.Text) > 0 && hfRequestLineNo.Value.ToString() != @""
            && int.Parse(hfRequestLineNo.Value.ToString()) > 0 && txtFromDate.Text != "" && txtToDate.Text != "" && txtFromTime.Text != "" && txtToTime.Text != ""
            && ddlDesignation.Items.Count > 0 && ddlDesignation.SelectedItem.Value.ToString() != "")
        {
            bool datestatus = GetGreaterDate(DateTime.Parse(txtFromDate.Text.ToString()), DateTime.Parse(txtToDate.Text.ToString()));
            if (datestatus == true)
            {
                DisplayMessageString(lblError, Resources.Resource.ToDateMustBeGreaterThanFromDate);
                txtFromDate.Focus();
            }
            else
            {
                ds = objRoster.BorrowEmployeeDetailUpdate(BaseLocationAutoID, txtRequestNo.Text, int.Parse(hfRequestLineNo.Value.ToString()),
                    int.Parse(txtNoOfPerson.Text), ddlDesignation.SelectedItem.Value.ToString(), DateFormat(DateTime.Parse(txtFromDate.Text)),
                        DateFormat(DateTime.Parse(txtToDate.Text)), txtFromTime.Text, txtToTime.Text, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblError, ds.Tables[0].Rows[0]["MessageId"].ToString());
                }
            }
        }
        gvRequest.EditIndex = -1;
        FillgvRequest();
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hfRequestLineNo = (HiddenField)gvRequest.Rows[e.RowIndex].FindControl("hfRequestLineNo");
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();

        if (txtRequestNo.Text != "" && hfRequestLineNo != null && hfRequestLineNo.Value.ToString() != "" && int.Parse(hfRequestLineNo.Value.ToString()) > 0)
        {
            ds = objRoster.BorrowEmployeeDetailDelete(BaseLocationAutoID, txtRequestNo.Text.ToString(), hfRequestLineNo.Value.ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblError, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }
        FillgvRequest();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRequest.PageIndex = e.NewPageIndex;
        FillgvRequest();
    }

    /// <summary>
    /// Handles the OnPageIndexChanging event of the gvEmpAssign control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvEmpAssign_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmpAssign.PageIndex = e.NewPageIndex;
        FillgvEmpAssign();
    }
    #endregion Gridview Events
}