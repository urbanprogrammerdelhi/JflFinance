// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CitationNCommendation.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class OperationManagement_CitationNCommendation.
/// </summary>
public partial class OperationManagement_CitationNCommendation : BasePage   //System.Web.UI.Page
{
    /// <summary>
    /// The dt temporary award details
    /// </summary>
    static DataTable dtTempAwardDetails = new DataTable();
    /// <summary>
    /// The status
    /// </summary>
    static int status;


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

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {          
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.CitationCommendation + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            status = 1;
            dtTempAwardDetails.Clear();
            if (dtTempAwardDetails.Columns.Contains("Award_Descripation") == false)
            {
                MakeTempAwardDetail();
            }
            else
            {
                dtTempAwardDetails.Clear();
            }
            FillCitationType();
            FillCitation();
            FillgvAwardDetails();
            HideButtonBasedOnStatus();
            IMGCITNO.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CITNO&ControlId=" + txtCitNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
            imgAssignSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtAssignNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
        }
    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtCitNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtCitNo_OnTextChanged(object sender, EventArgs e)
    {
        status = 0;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AsmtCitationDetailGet(BaseLocationAutoID, txtCitNo.Text.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            txtAssignNo.Text = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
            txtAwardedBy.Text = ds.Tables[0].Rows[0]["Awarded_by"].ToString();
            txtAwardedOn.Text = DateFormat(ds.Tables[0].Rows[0]["Awarded_on"].ToString());
            txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
            lblCitStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            ddlCitationType.SelectedValue = ds.Tables[0].Rows[0]["Citation_type"].ToString();
            ddlCitType.SelectedValue = ds.Tables[0].Rows[0]["Citation"].ToString();
            FillAsmtDetails();
            FillgvAwardDetailsAfterSave(txtCitNo.Text);
            HideButtonBasedOnStatus();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }

        //DisableFields(); 
    }

    /// <summary>
    /// Handles the TextChanged event of the txtAssignNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtAssignNo_TextChanged(object sender, EventArgs e)
    {
        FillAsmtDetails();
    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtAwardedTo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void txtAwardedTo_OnTextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        //UpdateDataTableChanges(row);
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        Label lblFtrName = (Label)gvAwardDetails.FooterRow.FindControl("lblFtrName");
        Label lblFtrDesg = (Label)gvAwardDetails.FooterRow.FindControl("lblFtrDesg");
        TextBox txtAwardedTo = (TextBox)gvAwardDetails.FooterRow.FindControl("txtAwardedTo");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtAwardedTo.Text.ToString(), BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            lblFtrName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            lblFtrDesg.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
        }
        else
        {
            lblGridError.Text = Resources.Resource.InvalidEmpCode;
            txtAwardedTo.Text = "";
        }
    }

    /// <summary>
    /// Fills the asmt details.
    /// </summary>
    private void FillAsmtDetails()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AsmtIncidentDetailGet(txtCustomerID.Text,txtAssignNo.Text.ToString(), BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                //EnableFields();
                //EnableButton();
                txtBranchID.Text = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                txtBranchIDDesc.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
                txtCustomerID.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                txtAddressID.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                txtAddressDesc.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
                hfAsmtStartDate.Value = ds.Tables[0].Rows[0]["AsmtStartDate"].ToString();
            }
            else
            {
                // DisableFields();
                ClearFields();
                //DisableButtons();

            }

        }
        else
        {
            //lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            ClearFields();
            //DisableButtons();
        }

    }
    /// <summary>
    /// Fills the type of the citation.
    /// </summary>
    protected void FillCitationType()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlCitationType.DataSource = objOperationManagement.AsmtCitationTypeGet(BaseCompanyCode);
        ddlCitationType.DataTextField = "ItemDesc";
        ddlCitationType.DataValueField = "ItemCode";
        ddlCitationType.DataBind();
        if (ddlCitationType.SelectedValue.ToString() == "")
        {
            ListItem LiN = new ListItem();
            LiN.Text =  Resources.Resource.NoData;
            LiN.Value = "0";
            ddlCitationType.Items.Add(LiN);
        }
    }

    /// <summary>
    /// Fills the citation.
    /// </summary>
    protected void FillCitation()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();

        ddlCitType.DataSource = objOperationManagement.AsmtCitationGet(BaseCompanyCode);
        ddlCitType.DataTextField = "ItemDesc";
        ddlCitType.DataValueField = "ItemCode";
        ddlCitType.DataBind();
        if (ddlCitType.SelectedValue.ToString() == "")
        {
            ListItem LiN = new ListItem();
            LiN.Text =  Resources.Resource.NoData;
            LiN.Value = "0";
            ddlCitType.Items.Add(LiN);
        }
    }

    /// <summary>
    /// Fillgvs the award details.
    /// </summary>
    protected void FillgvAwardDetails()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("Award_Descripation", typeof(System.String));
        DataColumn dCol2 = new DataColumn("EmployeeNumber", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol4 = new DataColumn("EmployeeDesignation", typeof(System.DateTime));
        dt.Columns.Add(dCol1);
        dt.Columns.Add(dCol2);
        dt.Columns.Add(dcol3);
        dt.Columns.Add(dcol4);
        int dtflag;
        dtflag = 1;
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        //just for temprarily assining the DataKey
        gvAwardDetails.DataKeyNames = new string[] { "EmployeeNumber" };
        gvAwardDetails.DataSource = dt;
        gvAwardDetails.DataBind();
        if (dtflag == 0)//to fix empety gridview
        {
            gvAwardDetails.Rows[0].Visible = false;
            gvAwardDetails.FooterRow.Visible = true;
        }
    }
    /// <summary>
    /// Fillgvs the award details after save.
    /// </summary>
    /// <param name="strCitationNo">The STR citation no.</param>
    protected void FillgvAwardDetailsAfterSave(string strCitationNo)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dtAwardDetails = new DataTable();
        ds = objOperationManagement.AsmtCitationDetailGet(BaseLocationAutoID, strCitationNo);
        dtAwardDetails = ds.Tables[0];

        int dtflag;
        dtflag = 1;




        if (dtAwardDetails.Rows.Count == 0)
        {
            dtflag = 0;
            dtAwardDetails.Rows.Add(dtAwardDetails.NewRow());
        }
        gvAwardDetails.DataKeyNames = new string[] { "Citation_type" };
        gvAwardDetails.DataSource = dtAwardDetails;
        gvAwardDetails.DataBind();
        gvAwardDetails.FooterRow.Visible = true;

        if (dtflag == 0)//to fix empety gridview
        {
            gvAwardDetails.Rows[0].Visible = false;
        }

        if (lblCitStatus.Text == Resources.Resource.Fresh || lblCitStatus.Text == Resources.Resource.Amend)
        {
            gvAwardDetails.Columns[0].Visible = true;
            gvAwardDetails.FooterRow.Visible = true;
        }
        else
        {
            gvAwardDetails.Columns[0].Visible = false;
            gvAwardDetails.FooterRow.Visible = false;
        }
    }
    /// <summary>
    /// Makes the temp award detail.
    /// </summary>
    protected void MakeTempAwardDetail()
    {
        DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("Award_Descripation", typeof(System.String));
        DataColumn dCol2 = new DataColumn("EmployeeNumber", typeof(System.String));
        DataColumn dcol3 = new DataColumn("Name", typeof(System.String));
        DataColumn dcol4 = new DataColumn("EmployeeDesignation", typeof(System.String));

        dtTempAwardDetails.Columns.Add(dCol1);
        dtTempAwardDetails.Columns.Add(dCol2);
        dtTempAwardDetails.Columns.Add(dcol3);
        dtTempAwardDetails.Columns.Add(dcol4);
    }
    #region Functions related to GridCitation

    /// <summary>
    /// Handles the RowDataBound event of the gvAwardDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvAwardDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            TextBox txtAwardedTo = (TextBox)e.Row.FindControl("txtAwardedTo");
            ImageButton imgAwardedTo = (ImageButton)e.Row.FindControl("imgAwardedTo");
            if (imgAwardedTo != null)
            {
                //imgAwardedTo.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtAwardedTo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                imgAwardedTo.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtAwardedTo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,help=no')");
            }
            if (txtAwardedTo != null)
            {
                txtAwardedTo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtAwardedTo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
            }
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvAwardDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvAwardDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblAwardDesc = (Label)gvAwardDetails.Rows[e.RowIndex].FindControl("lblAwardDesc");
        Label lblAwardedTo = (Label)gvAwardDetails.Rows[e.RowIndex].FindControl("lblAwardedTo");
        if (status == 1)
        {
            dtTempAwardDetails.Rows.RemoveAt(e.RowIndex);
            gvAwardDetails.DataSource = dtTempAwardDetails;
            gvAwardDetails.DataBind();
            gvAwardDetails.FooterRow.Visible = true;
            if (dtTempAwardDetails.Rows.Count == 0)
            {
                FillgvAwardDetails();
                gvAwardDetails.Columns[0].Visible = true;
               
            }
        }
        else if (status == 0)
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOperationManagement.CitationDeleteAwardDetails(txtCitNo.Text.ToString(), lblAwardedTo.Text.ToString());
            FillgvAwardDetailsAfterSave(txtCitNo.Text.ToString());
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvAwardDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvAwardDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (status == 1)
        {
            gvAwardDetails.EditIndex = e.NewEditIndex;
            gvAwardDetails.DataSource = dtTempAwardDetails;
            gvAwardDetails.DataBind();
            gvAwardDetails.Columns[0].Visible = true;
            gvAwardDetails.FooterRow.Visible = true;

        }
        else if (status == 0)
        {
            gvAwardDetails.EditIndex = e.NewEditIndex;
            FillgvAwardDetailsAfterSave(txtCitNo.Text.ToString());
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvAwardDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvAwardDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblEditAwardedTo = (Label)gvAwardDetails.Rows[e.RowIndex].FindControl("lblEditAwardedTo");
        TextBox txtEditAwardDesc = (TextBox)gvAwardDetails.Rows[e.RowIndex].FindControl("txtEditAwardDesc");
        Label lblEditName = (Label)gvAwardDetails.Rows[e.RowIndex].FindControl("lblEditName");
        Label lblEditDesg = (Label)gvAwardDetails.Rows[e.RowIndex].FindControl("lblEditDesg");
        if (status == 1)
        {

            dtTempAwardDetails.Rows[e.RowIndex][0] = txtEditAwardDesc.Text.ToString();
            dtTempAwardDetails.Rows[e.RowIndex][1] = lblEditAwardedTo.Text.ToString();
            dtTempAwardDetails.Rows[e.RowIndex][2] = lblEditName.Text.ToString();
            dtTempAwardDetails.Rows[e.RowIndex][3] = lblEditDesg.Text.ToString();
            gvAwardDetails.EditIndex = -1;
            gvAwardDetails.DataSource = dtTempAwardDetails;
            gvAwardDetails.DataBind();
            gvAwardDetails.Columns[0].Visible = true;
            gvAwardDetails.FooterRow.Visible = true;


        }
        else if (status == 0)
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOperationManagement.CitationAwardDetailsUpdate(txtCitNo.Text.ToString(), txtEditAwardDesc.Text.ToString(), lblEditAwardedTo.Text.ToString(), BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                gvAwardDetails.EditIndex = -1;
                FillgvAwardDetailsAfterSave(txtCitNo.Text.ToString());
            }
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvAwardDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvAwardDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (status == 1)
        {
            gvAwardDetails.EditIndex = -1;
            gvAwardDetails.DataSource = dtTempAwardDetails;
            gvAwardDetails.DataBind();
        }
        else if (status == 0)
        {
            gvAwardDetails.EditIndex = -1;
            FillgvAwardDetailsAfterSave(txtCitNo.Text);
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvAwardDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvAwardDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtAwardDesc = (TextBox)gvAwardDetails.FooterRow.FindControl("txtAwardDesc");
        Label lblFtrName = (Label)gvAwardDetails.FooterRow.FindControl("lblFtrName");
        Label lblFtrDesg = (Label)gvAwardDetails.FooterRow.FindControl("lblFtrDesg");
        TextBox txtAwardedTo = (TextBox)gvAwardDetails.FooterRow.FindControl("txtAwardedTo");
        if (status == 1)
        {
            int flag = 1;

            if (e.CommandName.Equals("AddNew"))
            {
                DataRow dr = dtTempAwardDetails.NewRow();
                dr[0] = txtAwardDesc.Text;
                dr[1] = txtAwardedTo.Text;
                dr[2] = lblFtrName.Text;
                dr[3] = lblFtrDesg.Text;

                if (gvAwardDetails.Rows.Count > 0)
                {
                    for (int i = 0; i < gvAwardDetails.Rows.Count; i++)
                    {
                        Label lblAwardedTo = (Label)gvAwardDetails.Rows[i].FindControl("lblAwardedTo");
                        if (txtAwardedTo.Text.Trim() == lblAwardedTo.Text.ToString().Trim())
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgAlreadyExists;
                            flag = 0;
                            break;

                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                }
                if (flag == 1)
                {
                    gvAwardDetails.DataKeyNames = new string[] { "EmployeeNumber" };
                    dtTempAwardDetails.Rows.Add(dr);
                    gvAwardDetails.DataSource = dtTempAwardDetails;
                    gvAwardDetails.DataBind();
                    gvAwardDetails.FooterRow.Visible = true;
                    //FillgvAwardDetails();
                }
            }
            if (e.CommandName.Equals("Reset"))
            {
                txtAwardDesc.Text = "";
                lblFtrName.Text = "";
                lblDesignation.Text = "";
                txtAwardedTo.Text = "";
            }
        }
        else if (status == 0)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                DataSet ds = new DataSet();
                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                ds = objOperationManagement.CitationAwardDetailsInsert(txtCitNo.Text.ToString(), txtAwardDesc.Text.ToString(), txtAwardedTo.Text.ToString(), BaseUserID);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                FillgvAwardDetailsAfterSave(txtCitNo.Text.ToString());
            }
            if (e.CommandName.Equals("Reset"))
            {
                txtAwardDesc.Text = "";
                lblFtrName.Text = "";
                lblDesignation.Text = "";
                txtAwardedTo.Text = "";
            }
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvAwardDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvAwardDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAwardDetails.PageIndex = e.NewPageIndex;
        gvAwardDetails.EditIndex = -1;
        FillgvAwardDetailsAfterSave(txtCitNo.Text);
    }


    #endregion

    #region Functions related to Buttons

    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        gvAwardDetails.EditIndex = -1;
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (gvAwardDetails.Rows.Count > 0)
        {
            ds = objOperationManagement.CitationAuthorize(strStatusAuthorized, txtCitNo.Text.ToString(), BaseLocationAutoID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                txtCitNo_OnTextChanged(sender, e);
                FillgvAwardDetailsAfterSave(txtCitNo.Text);
                HideButtonBasedOnStatus();
                DisableFields();
                gvAwardDetails.Columns[0].Visible = false;
                gvAwardDetails.FooterRow.Visible = false;
                UpdatePanel2.Update();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.AwardDetailsCannotBeLeftBlank;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        gvAwardDetails.EditIndex = -1;
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (DateTime.Parse(txtAwardedOn.Text) <= DateTime.Now && DateTime.Parse(txtAwardedOn.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
        {

            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            ds = objOperationManagement.CitationUpdate(BaseLocationAutoID, txtCitNo.Text, ddlCitationType.SelectedValue.ToString(), DateTime.Now, ddlCitType.SelectedValue.ToString(), txtAwardedBy.Text, txtDesignation.Text, DateTime.Parse(txtAwardedOn.Text), txtAssignNo.Text, BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                FillgvAwardDetailsAfterSave(txtCitNo.Text);
                HideButtonBasedOnStatus();
                EnableFields();
                gvAwardDetails.Columns[0].Visible = true;
                gvAwardDetails.FooterRow.Visible = true;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.AwardedOnDateShouldBeBetweenAssignmentStartDateAndCurrentDate;
            ToolkitScriptManager1.SetFocus(txtAwardedOn);
            txtAwardedOn.BackColor = System.Drawing.Color.Aqua;
        }
    }

    /// <summary>
    /// Hides the button based on status.
    /// </summary>
    protected void HideButtonBasedOnStatus()
    {
        if (lblCitStatus.Text == Resources.Resource.Fresh)
        {
            btnAuthorize.Visible = true;
            btnAddNew.Visible = true;
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            EnableFields();
            gvAwardDetails.Columns[0].Visible = true;
            gvAwardDetails.FooterRow.Visible = true;

        }
        if (lblCitStatus.Text == Resources.Resource.Amend)
        {
            gvAwardDetails.Columns[0].Visible = true;
            gvAwardDetails.FooterRow.Visible = true;
            btnAuthorize.Visible = true;
            btnAddNew.Visible = true;
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            EnableFields();
        }
        if (lblCitStatus.Text == Resources.Resource.Authorized)
        {
            btnAddNew.Visible = true;
            btnEdit.Visible = true;
            btnUpdate.Visible = false;
            btnAuthorize.Visible = false;
            btnSave.Visible = false;
            DisableFields();
        }
        if (lblCitStatus.Text == "")
        {
            btnAddNew.Visible = false;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnAuthorize.Visible = false;
            btnEdit.Visible = false;
            EnableFields();
        }
    }

    /// <summary>
    /// Enables the fields.
    /// </summary>
    protected void EnableFields()
    {
        txtAssignNo.Enabled = true;
        txtCitNo.Enabled = true;
        ddlCitationType.Enabled = true;
        ddlCitType.Enabled = true;
        txtAwardedOn.Enabled = true;
        //IMGDate.Enabled = true;
        txtDesignation.Enabled = true;
        txtAwardedBy.Enabled = true;
    }

    /// <summary>
    /// Disables the fields.
    /// </summary>
    protected void DisableFields()
    {
        txtCitNo.Enabled = false;
        txtAssignNo.Enabled = false;
        ddlCitType.Enabled = false;
        ddlCitationType.Enabled = false;
        txtAwardedOn.Enabled = false;
        //IMGDate.Enabled = false;
        txtDesignation.Enabled = false;
        txtAwardedBy.Enabled = false;
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        int flag = 1;
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (dtTempAwardDetails.Rows.Count == 0)
        {
            lblErrorMsg.Text = Resources.Resource.AwardDetailsCannotBeLeftBlank;
            flag = 0;
        }
        else if (txtAwardedOn.Text != "")
        {
            if (DateTime.Parse(txtAwardedOn.Text) <= DateTime.Now && DateTime.Parse(txtAwardedOn.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
            {
                flag = 1;
                txtAwardedOn.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.AwardedOnDateShouldBeBetweenAssignmentStartDateAndCurrentDate;
                ToolkitScriptManager1.SetFocus(txtAwardedOn);
                txtAwardedOn.BackColor = System.Drawing.Color.Aqua;
                flag = 0;
                return;
            }
        }

        if (flag == 1)
        {
            ds = objOperationManagement.CitationHeaderDetailInsert(BaseLocationAutoID, ddlCitationType.SelectedValue.ToString(), DateTime.Now, ddlCitType.SelectedValue.ToString(), txtAwardedBy.Text.ToString(), txtDesignation.Text, DateTime.Parse(txtAwardedOn.Text), txtAssignNo.Text.ToString(), dtTempAwardDetails, Resources.Resource.Fresh, BaseUserID);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                txtCitNo.Text = ds.Tables[0].Rows[0]["Citation_no"].ToString();
                lblCitStatus.Text = Resources.Resource.Fresh;
                HideButtonBasedOnStatus();
                UpdatePanel2.Update();
                //DisableFields();
                //gvAwardDetails.Columns[0].Visible = false;
                //gvAwardDetails.FooterRow.Visible = false;    
            }

        }
    }

    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        AddNewDetails();
    }

    /// <summary>
    /// Adds the new details.
    /// </summary>
    private void AddNewDetails()
    {
        status = 1;
        ClearFields();
        //HideButtons();
        btnSave.Visible = true;
        dtTempAwardDetails.Clear();
        lblCitStatus.Text = "";
        ddlCitationType.SelectedIndex = 0;
        ddlCitType.SelectedIndex = 0;
        // FillAsmtDetails();
        FillgvAwardDetails();
        gvAwardDetails.Columns[0].Visible = true;
        gvAwardDetails.FooterRow.Visible = true;
        EnableFields();
        HideButtonBasedOnStatus();
        if (dtTempAwardDetails.Columns.Contains("Award_Descripation") == false)
        {
            MakeTempAwardDetail();
        }
        else
        {
            dtTempAwardDetails.Clear();
        }
        UpdatePanel1.Update();
        UpdatePanel2.Update();
    }
    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        AddNewDetails();
    }

    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        //HideButtons();
        //HideButtonBasedOnStatus();
        //DisableFields();
        gvAwardDetails.Columns[0].Visible = false;
        gvAwardDetails.FooterRow.Visible = false;
    }

    /// <summary>
    /// Clears the fields.
    /// </summary>
    protected void ClearFields()
    {
        txtCitNo.Text = "";
        txtAwardedBy.Text = "";
        txtAwardedOn.Text = "";
        txtDesignation.Text = "";
        txtAssignNo.Text = "";
        txtAddressDesc.Text = "";
        txtAddressID.Text = "";
        txtAreaDesc.Text = "";
        txtAreaID.Text = "";
        txtBranchID.Text = "";
        txtBranchIDDesc.Text = "";
        txtCustomerID.Text = "";
        txtCustomerDesc.Text = "";
    }

    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (lblCitStatus.Text == Resources.Resource.Fresh)
        {
            status = 0;
            EnableFields();
            btnCancel.Visible = true;
            btnAddNew.Visible = true;
            gvAwardDetails.Columns[0].Visible = true;
            gvAwardDetails.FooterRow.Visible = true;
            FillgvAwardDetailsAfterSave(txtCitNo.Text);
        }
        else if (lblCitStatus.Text == Resources.Resource.Authorized)
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            ds = objOperationManagement.CitationAuthorize(strStatusAmend, txtCitNo.Text.ToString(), BaseLocationAutoID);
            // DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                txtCitNo_OnTextChanged(sender, e);
                HideButtonBasedOnStatus();
                EnableFields();
                ddlCitationType.SelectedIndex = 0;
                ddlCitType.SelectedIndex = 0;
                gvAwardDetails.Columns[0].Visible = true;
                gvAwardDetails.FooterRow.Visible = true;
                UpdatePanel2.Update();
            }
        }

    }

    #endregion
}
