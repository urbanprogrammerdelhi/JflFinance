// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RequestFormApproval.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_RequestFormApproval.
/// </summary>
public partial class Transactions_RequestFormApproval : BasePage
{
    /// <summary>
    /// The index
    /// </summary>
    static int Index;
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
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.RequestFormApproval + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            if (Request.QueryString["RequestNo"] != null)
            {
                txtRequestNo.Text = Request.QueryString["RequestNo"].ToString();
                Fillgvdetails();
            }
            ibtnSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH_ReqNO0&ControlId=" + txtRequestNo.ClientID.ToString() + "&Company=" + BaseCompanyCode + "&HrLocation=" + BaseHrLocationCode + "&ToLocation=" + BaseLocationCode + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=1000px,Height=600px,help=no')");
            btnCloseRequest.Visible = false;
            txtRequestedBy.Attributes.Add("readonly", "readonly");
            txtDivision.Attributes.Add("readonly", "readonly");
            txtLocation.Attributes.Add("readonly", "readonly");
            txtAreaId.Attributes.Add("readonly", "readonly");
            txtClientCode.Attributes.Add("readonly", "readonly");
            txtClientName.Attributes.Add("readonly", "readonly");
            txtAsmtId.Attributes.Add("readonly", "readonly");
            txtAsmtAddress.Attributes.Add("readonly", "readonly");
            txtPostDesc.Attributes.Add("readonly", "readonly");
            txtRequestedBy.Attributes.Add("readonly", "readonly");
            txtRequestedDate.Attributes.Add("readonly", "readonly");
        }
    }
    #endregion Page Functions
    #region Control Events
    /// <summary>
    /// Handles the Click event of the btnCloseRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCloseRequest_Click(object sender, EventArgs e)
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRoster.BorrowedEmployeeClosePartialApprovedRequest(BaseLocationAutoID, txtRequestNo.Text);
        Fillgvdetails();
    }
    /// <summary>
    /// Handles the Click event of the btnAccept control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRoster.AcceptRequest(BaseLocationAutoID, txtRequestNo.Text);
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "7")
        {
            btnAccept.Visible = true;
            btnReject.Visible = true;
        }
        lblError.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
        Fillgvdetails();
    }
    /// <summary>
    /// Handles the Click event of the btnReject control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReject_Click(object sender, EventArgs e)
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRoster.RejectRequest(BaseLocationAutoID, txtRequestNo.Text);

        btnAccept.Visible = false;
        btnReject.Visible = false;
        gvRequest.Columns[8].Visible = false;
        Fillgvdetails();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtRequestNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtRequestNo_TextChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (txtRequestNo.Text != "")
        {
            Fillgvdetails();
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtSearchEmpName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtSearchEmpName_TextChanged(object sender, EventArgs e)
    {
        TextBox txtSearchEmpName = (TextBox)gvUnScheduledEmployees.HeaderRow.FindControl("txtSearchEmpName");

        DataSet ds = new DataSet();
        BL.Roster objRost = new BL.Roster();
            //ds = objRost.EmployeesNotScheduleBetweenDatesGetAll(BaseCompanyCode, BaseLocationAutoID, BaseUserEmployeeNumber.ToString(), Session["lblgvDutyDate"].ToString(), Session["lblgvDutyDate"].ToString());
        ds = objRost.SearchEmployeeSkillandAreaWiseGetAll(txtRequestNo.Text, BaseLocationAutoID, Session["lblgvLineNo"].ToString(), Session["lblgvDutyDate"].ToString());
        ds.Tables[0].DefaultView.RowFilter = "EmployeeName like '%" + txtSearchEmpName.Text + "%'";

        DataTable dt = new DataTable();
        dt = ds.Tables[0].DefaultView.ToTable();

        if (dt.Rows.Count > 0)
        {
            gvUnScheduledEmployees.DataSource = ds.Tables[0];
            gvUnScheduledEmployees.DataBind();
        }
        else
        {
            DataRow dr = dt.NewRow();
            dr["EmployeeNo"] = "";
            dr["EmployeeName"] = Resources.Resource.NoRecordFound.ToString();
            dr["DesignationDesc"] = "";
            dt.Rows.Add(dr);
            gvUnScheduledEmployees.DataSource = dt;
            gvUnScheduledEmployees.DataBind();
        }
    }
    /// <summary>
    /// Handles the OnClick event of the imgBtnEmpDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void imgBtnEmpDetail_OnClick(object sender, EventArgs e)
    {
        //FillEmployeeDetail(Session["lblgvDutyDate"].ToString());
    }
    /// <summary>
    /// Handles the OnClick event of the btnUnScheduledEmp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUnScheduledEmp_OnClick(object sender, EventArgs e)
    {
        //FillEmployeeDetail(Session["lblgvDutyDate"].ToString());
    }
    #endregion Control Events
    #region Controle Binding
    /// <summary>
    /// Fillgvdetailses this instance.
    /// </summary>
    private void Fillgvdetails()
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = objRoster.BorrowEmployeeRequestDetailForApprovalGet(BaseLocationAutoID, txtRequestNo.Text);
        if (ds != null && ds.Tables.Count > 0)
        {
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblStatus.Text = ResourceValueOfKey_Get(dt.Rows[0]["RequestStatus"].ToString());
                hfStatus.Value = dt.Rows[0]["RequestStatus"].ToString();
                txtDivision.Text = dt.Rows[0]["HrLocationCode"].ToString();
                txtLocation.Text = dt.Rows[0]["LocationCode"].ToString();
                txtAreaId.Text = dt.Rows[0]["AreaDesc"].ToString();
                txtClientCode.Text = dt.Rows[0]["ClientCode"].ToString();
                txtClientName.Text = dt.Rows[0]["ClientName"].ToString();
                txtAsmtId.Text = dt.Rows[0]["AsmtId"].ToString();
                txtAsmtAddress.Text = dt.Rows[0]["AsmtAddress"].ToString();
                txtPostDesc.Text = dt.Rows[0]["PostDesc"].ToString();
                hfPostAutoId.Value = dt.Rows[0]["PostAutoId"].ToString();
                txtSoRank.Text = dt.Rows[0]["SoRank"].ToString();
                txtRequestedBy.Text = dt.Rows[0]["RequestedBy"].ToString();
                txtRequestedDate.Text = DateFormat(dt.Rows[0]["RequestedDate"].ToString());

                gvRequest.DataSource = dt;
                gvRequest.DataBind();

                if (hfStatus.Value == strStatusApproved && bool.Parse(dt.Rows[0]["IsClosed"].ToString()) == false)
                {
                    int i = 0;
                    int flagPartialApproved = 0;
                    while(i < dt.Rows.Count)
                    {
                        if (dt.Rows[i]["EmployeeNumber"].ToString() == "")
                        {
                            flagPartialApproved = 1;
                        }
                        i++;
                    }
                    if (flagPartialApproved == 1)
                    {
                        btnCloseRequest.Visible = true;
                    }
                }
                else
                {
                    btnCloseRequest.Visible = false;
                }
            }
            else
            {
                lblError.Text = "";
                lblStatus.Text = "";
                hfStatus.Value = "";
                txtDivision.Text = "";
                txtLocation.Text = "";
                txtAreaId.Text = "";
                txtClientCode.Text = "";
                txtClientName.Text = "";
                txtAsmtId.Text = "";
                txtAsmtAddress.Text = "";
                txtPostDesc.Text = "";
                hfPostAutoId.Value = "";
                txtSoRank.Text = "";
                txtRequestedBy.Text = "";
                txtRequestedDate.Text = "";

                dt.Rows.Add(dt.NewRow());
                gvRequest.DataSource = dt;
                gvRequest.DataBind();
                int TotalColumns = gvRequest.Rows[0].Cells.Count;
                gvRequest.Rows[0].Cells.Clear();
                gvRequest.Rows[0].Cells.Add(new TableCell());
                gvRequest.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                gvRequest.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
            }
        }

        
        if (hfStatus.Value == strStatusFresh)
        {
            gvRequest.Visible = false;
            btnAccept.Visible = false;
            btnReject.Visible = false;
            return;
        }
        else
        {
            gvRequest.Visible = true;
        }
        if (hfStatus.Value == strStatusApproved || hfStatus.Value == strStatusRejected)
        {
            int gridEmployeeFillCount = 0;
            try
            {
                for (int i = 0; i < gvRequest.Rows.Count; i++)
                {
                    Label lblgvEmpNo = (Label)gvRequest.Rows[i].FindControl("lblgvEmpNo");
                    if (lblgvEmpNo.Text == "")
                    {
                        gridEmployeeFillCount = 1;
                        break;
                    }
                    else
                    {
                        gridEmployeeFillCount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                gridEmployeeFillCount = 1;
            }
            if (hfStatus.Value == strStatusRejected)
            {
                btnAccept.Visible = false;
                btnReject.Visible = false;
                gvRequest.Columns[9].Visible = false;
                return;
            }
            if (gridEmployeeFillCount == 1)
            {
                btnAccept.Visible = true;
                btnReject.Visible = true;
                gvRequest.Columns[9].Visible = true;
            }
            else
            {
                btnAccept.Visible = false;
                btnReject.Visible = false;
                gvRequest.Columns[9].Visible = false;
            }
        }
        else
        {
            btnAccept.Visible = true;
            btnReject.Visible = true;
            gvRequest.Columns[9].Visible = true;
        }
    }
    /// <summary>
    /// Fills the employee detail.
    /// </summary>
    /// <param name="strRequestLineNo">The string request line no.</param>
    /// <param name="strdutydate">The strdutydate.</param>
    protected void FillEmployeeDetail(string strRequestLineNo, string strdutydate)
    {
        DataSet ds = new DataSet();
        BL.Roster objRost = new BL.Roster();
        //ds = objRost.EmployeesNotScheduleBetweenDatesGetAll(BaseCompanyCode, BaseLocationAutoID, BaseUserEmployeeNumber.ToString(), dutydate.ToString(), dutydate.ToString());
        ds = objRost.SearchEmployeeSkillandAreaWiseGetAll(txtRequestNo.Text, BaseLocationAutoID, strRequestLineNo, strdutydate);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvUnScheduledEmployees.DataSource = ds.Tables[0];
            gvUnScheduledEmployees.DataBind();
            DIVUnScheduledEmployees.Style["display"] = "block";
            UPUnScheduledEmp.Update();
        }
        else
        {
            lblError.Text = ResourceValueOfKey_Get("MandatorySkillsNotMet");
        }
        
    }
    #endregion Controle Binding
    #region Gridview Events
    /// <summary>
    /// Handles the RowUpdating event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtgvEmpNo = (TextBox)gvRequest.Rows[e.RowIndex].FindControl("txtgvEmpNo");
        Label lblgvDutyDate = (Label)gvRequest.Rows[e.RowIndex].FindControl("lblgvDutyDate");
        Label lblgvLineNo = (Label)gvRequest.Rows[e.RowIndex].FindControl("lblgvLineNo");
        Label lblgvSLineNo = (Label)gvRequest.Rows[e.RowIndex].FindControl("lblgvSLineNo");
        HiddenField hfEmployeeNumber = (HiddenField)gvRequest.Rows[e.RowIndex].FindControl("hfEmployeeNumber");
        BL.Roster objUpdate = new BL.Roster();
        DataSet dsUpdate = new DataSet();
        if (txtgvEmpNo != null &&  txtgvEmpNo.Text != "")
        {
            dsUpdate = objUpdate.BorrowedEmployeeUpdate(BaseLocationAutoID, txtRequestNo.Text.ToString(), (lblgvDutyDate.Text.ToString()), int.Parse(lblgvLineNo.Text.ToString()), int.Parse(lblgvSLineNo.Text.ToString()), txtgvEmpNo.Text, BaseUserID);
            lblError.Text = ResourceValueOfKey_Get(dsUpdate.Tables[0].Rows[0]["MessageString"].ToString());
            gvRequest.EditIndex = -1;
            Fillgvdetails();
        }
        else
        {
            lblError.Text = Resources.Resource.EmployeecannotbeleftBlank;
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRequest.PageIndex = e.NewPageIndex;
        Fillgvdetails();
    }
    /// <summary>
    /// Handles the RowCommand event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Copy")
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            var lblgvEmpNo = (System.Web.UI.WebControls.Label)row.FindControl("lblgvEmpNo");
            var lblgvDutyDate = (System.Web.UI.WebControls.Label)row.FindControl("lblgvDutyDate");
            var lblgvSLineNo = (System.Web.UI.WebControls.Label)row.FindControl("lblgvSLineNo");
            BL.Roster objUpdate = new BL.Roster();
            DataSet dsUpdate = new DataSet();
            if (lblgvEmpNo.Text != "")
            {
                dsUpdate = objUpdate.RequestedEmployeeNoCopytoAll(BaseLocationAutoID, txtRequestNo.Text, lblgvEmpNo.Text, (lblgvDutyDate.Text.ToString()), lblgvSLineNo.Text);
                lblError.Text = ResourceValueOfKey_Get(dsUpdate.Tables[0].Rows[0]["MessageString"].ToString());
                Fillgvdetails();
            }
        }
        else if (e.CommandName == "EmployeeSearch")
        {
            ImageButton iBtnEmpSearch = ((ImageButton)e.CommandSource);
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            TextBox txtgvEmpNo = (TextBox)row.FindControl("txtgvEmpNo");
            Label lblgvLineNo = (Label)row.FindControl("lblgvLineNo");
            Label lblgvDutyDate = (Label)row.FindControl("lblgvDutyDate");
            Session["lblgvLineNo"] = lblgvLineNo.Text;
            Session["lblgvDutyDate"] = lblgvDutyDate.Text;
            FillEmployeeDetail(lblgvLineNo.Text, lblgvDutyDate.Text);
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
            Label lblgvEmpNo = (Label)e.Row.FindControl("lblgvEmpNo");
            ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
            ImageButton ImgbtnCopytoAll = (ImageButton)e.Row.FindControl("ImgbtnCopytoAll");
            if (lblgvEmpNo != null && lblgvEmpNo.Text != "" && hfStatus.Value.ToString() == strStatusApproved && ImgbtnEdit != null && ImgbtnCopytoAll != null)
            {
                ImgbtnEdit.Visible = false;
                ImgbtnCopytoAll.Visible = false;
            }

            TextBox txtgvEmpNo = (TextBox)e.Row.FindControl("txtgvEmpNo");
            ImageButton iBtnEmpSearch = (ImageButton)e.Row.FindControl("iBtnEmpSearch");
            if (txtgvEmpNo != null && iBtnEmpSearch != null)
            {
                iBtnEmpSearch.Attributes.Add("onclick", "javascript:FunctionCallsearchemployee('EmployeeNumber', '" + txtgvEmpNo.ClientID + "');");
            }
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRequest.EditIndex = -1;
        Fillgvdetails();
    }
    /// <summary>
    /// Handles the OnRowEditing event of the gvRequest control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvRequest_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvRequest.EditIndex = e.NewEditIndex;
        Fillgvdetails();
        //TextBox txtgvEmpNo = (TextBox)gvRequest.Rows[e.NewEditIndex].FindControl("txtgvEmpNo");
        //Label lblgvDutyDate = (Label)gvRequest.Rows[e.NewEditIndex].FindControl("lblgvDutyDate");
        //Session["lblgvDutyDate"] = lblgvDutyDate.Text;
        //FillEmployeeDetail(lblgvDutyDate.Text);
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvUnScheduledEmployees control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvUnScheduledEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUnScheduledEmployees.PageIndex = e.NewPageIndex;
        FillEmployeeDetail(Session["lblgvLineNo"].ToString(), Session["lblgvDutyDate"].ToString());
    }
    #endregion Gridview Events
}
