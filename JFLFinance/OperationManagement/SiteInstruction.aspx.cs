// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="SiteInstruction.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Telerik.Web.UI;

/// <summary>
/// Class Masters_SiteInstruction.
/// </summary>
public partial class Masters_SiteInstruction : BasePage
{
    /// <summary>
    /// The dt site instruction temporary
    /// </summary>
    static DataTable dtSiteInstructionTemp = new DataTable();
    /// <summary>
    /// The status
    /// </summary>
    static int Status = 1;
    /// <summary>
    /// The count
    /// </summary>
    static int count;
    /// <summary>
    /// The default date
    /// </summary>
    string defaultDate = "1/1/1900";
    //Added Code for Upload Document by  on 24-Jun-2013
    /// <summary>
    /// The dt upload
    /// </summary>
    static DataTable dtUpload = new DataTable();

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
    /// Gets a value indicating whether this instance is authorization access.
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
    #region Page Load Event
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Status = 1;
            dtSiteInstructionTemp.Clear();
            FillgvSiteInstructionForIndustryTemp();
            btnSave.Enabled = false;            //Added by  on 2-Jun-2013
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.SiteInstructionForIndustry + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillClientId();         //Added by  on 29-May-2013
                FillIndustryType();
                hideshowButtons("pageload");
                //FillgvSiteInstructionForIndustry(int.Parse(ddlIndustryType.SelectedValue.ToString()));
                IMGInstructionSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTINSTCC&ControlId=" + txtAssignInstNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");

                //Commented and Modify by  on 22-May-2013
                //imgAssignSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtAssignNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");
                //imgAssignSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtAssignNo.ClientID.ToString() + "&ControlId1=" + hdClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");
                //IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,help=no')");

                //Added Code for Upload Document by  on 24-Jun-2013
                CreateUploadTable();
                dvFileUploadGrid.Visible = false;
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                //End
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            lblResonNotSigned.Visible = false;
            txtReasonNotSigned.Visible = false;
        }
    }
    /// <summary>
    /// Fillgvs the site instruction for industry temporary.
    /// </summary>
    private void FillgvSiteInstructionForIndustryTemp()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("RowID", typeof(System.Int64));
        //Modify By  on 18-Mar-2013
        //DataColumn dCol2 = new DataColumn("InstructionTypeID", typeof(System.Int32));
        DataColumn dCol2 = new DataColumn("InstructionTypeID", typeof(System.String));
        DataColumn dcol3 = new DataColumn("ItemDesc", typeof(System.String));
        DataColumn dcol4 = new DataColumn("SiteInstruction", typeof(System.String));
        dt.Columns.Add(dCol1);
        dt.Columns.Add(dCol2);
        dt.Columns.Add(dcol3);
        dt.Columns.Add(dcol4);
        int dtflag;
        dtflag = 1;
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvSiteInstruction.DataSource = dt;
        gvSiteInstruction.DataBind();
        dtSiteInstructionTemp = dt.Clone();

        if (dtflag == 0)//to fix empety gridview
        {
            gvSiteInstruction.Rows[0].Visible = false;
        }

    }
    /// <summary>
    /// Enables the button.
    /// </summary>
    private void enableButton()
    {
        btnUpdate.Enabled = true;
        btnReset.Enabled = true;
        btnSave.Enabled = true;
        btnEdit.Enabled = true;

        if (IsAuthorizationAccess == true)
        {
            btnAuthorize.Visible = true;
        }
        else
        {
            btnAuthorize.Visible = false;
        }
        //Added Code for Upload Document  by  on 14-Jun-2013
        btnUpload.Enabled = true;
    }
    #endregion

    #region Function to fill Assignment Details
    /// <summary>
    /// Fills the asmt details.
    /// </summary>
    private void FillAsmtDetails()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        //Commented and Modify by  on 22-May-2013
        //ds = objOperationManagement.AsmtIncidentDetailGet(txtAssignNo.Text, BaseLocationAutoID);
        ds = objOperationManagement.AsmtIncidentDetailGet(ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                //txtCustomerID.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                //txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                //txtAddressID.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                //txtAddressDesc.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
                hfAsmtStartDate.Value = ds.Tables[0].Rows[0]["AsmtStartDate"].ToString();
                // txtPrepDate.Text = DateTime.Parse(hfAsmtStartDate.Value).ToString("dd-MMM-yyyy");
                btnSave.Enabled = true;            //Added by  on 2-Jun-2013
                //Added Code for Upload Document by  on 24-Jun-2013
                btnUpload.Enabled = true;
                //End
            }
            else
            {
                //Modified by  on 4-Apr-2013
                lblErrorMsg.Text = Resources.Resource.AssignmentTerminate;
                clearFields("");
                btnSave.Enabled = false;            //Added by  on 2-Jun-2013
                //Added Code for Upload Document by  on 24-Jun-2013
                btnUpload.Enabled = false;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            //ClearFields();
            //DisableButtons();
            btnSave.Enabled = false;            //Added by  on 2-Jun-2013
            //Added Code for Upload Document by  on 24-Jun-2013
            btnUpload.Enabled = false;
        }
    }
    #endregion
    #region function to fill Industry Type Master
    /// <summary>
    /// Fills the type of the industry.
    /// </summary>
    private void FillIndustryType()
    {

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ddlIndustryType.DataSource = objMastersManagement.IndustryTypeMasterGet(BaseCompanyCode);
        ddlIndustryType.DataTextField = "ItemDesc";
        ddlIndustryType.DataValueField = "ItemCode";

        ddlIndustryType.DataBind();
        if (ddlIndustryType == null)
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData;
            li.Value = "0";
            ddlIndustryType.Items.Add(li);
        }
        else
        {
            //EnableButton();
        }
    }
    #endregion
    #region Function to fill Site Instruction in Temporary data table after insert/edit
    /// <summary>
    /// Fillgvs the site instruction for industry temporary after save.
    /// </summary>
    /// <param name="strSiteInstructionNo">The string site instruction no.</param>
    private void FillgvSiteInstructionForIndustryTempAfterSave(string strSiteInstructionNo)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dtSiteInst = new DataTable();
        int dtflag;
        dtflag = 1;
        count = 1;
        ds = objOperationManagement.SiteInstructionGetAll(strSiteInstructionNo);
        try
        {
            //  if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            // {
            dtSiteInst = ds.Tables[0];

            //to fix empety gridview
            if (dtSiteInst.Rows.Count == 0)
            {
                dtflag = 0;
                count = 0;
                dtSiteInst.Rows.Add(dtSiteInst.NewRow());
            }
            gvSiteInstruction.DataSource = dtSiteInst;
            gvSiteInstruction.DataBind();

            if (dtflag == 0)//to fix empety gridview
            {
                gvSiteInstruction.Rows[0].Visible = false;
                // gvSiteInstruction.Enabled = false;
            }
            //}
            //else
            //{
            //    gvSiteInstruction.DataSource = dtSiteInst;
            //    gvSiteInstruction.DataBind();
            //}
        }
        catch (Exception) { }
    }
    #endregion
    #region Function To fill Site Instruction for Industry
    /// <summary>
    /// Fillgvs the site instruction for industry.
    /// </summary>
    /// <param name="strIndustryTypeID">The string industry type identifier.</param>
    private void FillgvSiteInstructionForIndustry(string strIndustryTypeID)
    {
        BL.MastersManagement objMaster = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dtSiteInstruction = new DataTable();
        ds = objMaster.SiteInstructionGetAll(strIndustryTypeID, BaseCompanyCode);

        if (Status == 1)
        {
            dtSiteInstructionTemp = ds.Tables[0];
            if (ds != null && ds.Tables.Count > 0 && dtSiteInstructionTemp.Rows.Count > 0)
            {
                gvSiteInstruction.DataSource = dtSiteInstructionTemp;
                gvSiteInstruction.DataBind();
            }
            else
            {
                // int TotalColumns = gvQuickCodeType.Rows[0].Cells.Count;
                FillgvSiteInstructionForIndustryTemp();
            }
        }
        else
        {
            dtSiteInstruction = ds.Tables[0];
            if (ds != null && ds.Tables.Count > 0 && dtSiteInstruction.Rows.Count > 0)
            {
                gvSiteInstruction.DataSource = dtSiteInstruction;
                gvSiteInstruction.DataBind();
            }
            else
            {
                dtSiteInstruction.Rows.Add(dtSiteInstruction.NewRow());
                gvSiteInstruction.DataSource = dtSiteInstruction;
                gvSiteInstruction.DataBind();
                // int TotalColumns = gvQuickCodeType.Rows[0].Cells.Count;
                gvSiteInstruction.Rows[0].Cells.Clear();
                gvSiteInstruction.Rows[0].Cells.Add(new TableCell());
                //gvQuickCodeType.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                gvSiteInstruction.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
            }
        }


    }
    #endregion

    #region Grid View Site Instruction Type Events
    /// <summary>
    /// Handles the RowDataBound event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        BL.Misc objMisc = new BL.Misc();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();

        HiddenField hfInstructionType = (HiddenField)e.Row.FindControl("hfInstructionType");
        DataSet ds = new DataSet();
        DataSet dsEnableDisable = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvSiteInstruction.PageIndex * gvSiteInstruction.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvSiteInstruction.Columns[0].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlInstructionType = (DropDownList)e.Row.FindControl("ddlInstructionType");
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
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtSiteInstruction = (TextBox)e.Row.FindControl("txtSiteInstruction");
                if (txtSiteInstruction != null)
                {
                    txtSiteInstruction.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtSiteInstruction.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (ddlInstructionType != null)
                {
                    ddlInstructionType.DataSource = objMastersManagement.InstructionTypeGetAll(BaseCompanyCode);
                    // Modified by  on 4-Apr-2013
                    //ddlInstructionType.DataValueField = "ItemDesc";
                    //ddlInstructionType.DataTextField = "ItemCode";
                    ddlInstructionType.DataValueField = "ItemCode";
                    ddlInstructionType.DataTextField = "ItemDesc";
                    ddlInstructionType.SelectedValue = hfInstructionType.Value;
                    //ddlInstructionType.SelectedItem.Text = hfInstructionType.Value;
                    ddlInstructionType.DataBind();

                    //Added Code for New Changes By  on 28-Jun-2013
                  //  ddlInstructionType.SelectedIndexChanged += new EventHandler(ddlInstructionType_SelectedIndexChanged);
                    //End
                }
            }

            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteSiteInstruction = (ImageButton)e.Row.FindControl("IBDeleteSiteInstruction");
                if (IBDeleteSiteInstruction != null)
                {
                    IBDeleteSiteInstruction.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteSiteInstruction = (ImageButton)e.Row.FindControl("IBDeleteSiteInstruction");
                if (IBDeleteSiteInstruction != null)
                {
                    IBDeleteSiteInstruction.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DropDownList ddlInstructionType = (DropDownList)e.Row.FindControl("ddlInstructionType");
            if (IsWriteAccess == false)
            {
                gvSiteInstruction.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                //Modify by  on 19-July-2013 for RadCombobox control
                //TextBox txtNewSiteInstruction = (TextBox)e.Row.FindControl("txtNewSiteInstruction");
              
            }
            if (ddlInstructionType != null)
            {
                ddlInstructionType.DataSource = objMastersManagement.InstructionTypeGetAll(BaseCompanyCode);
                // Modified by  on 4-Apr-2013
                //ddlInstructionType.DataValueField = "ItemDesc";
                //ddlInstructionType.DataTextField = "ItemCode";
                ddlInstructionType.DataValueField = "ItemCode";
                ddlInstructionType.DataTextField = "ItemDesc";
                ddlInstructionType.DataBind();
                //Added Code for New Changes By  on 28-Jun-2013
              //  ddlInstructionType.SelectedIndexChanged += new EventHandler(ddlInstructionType_SelectedIndexChanged);
                //End
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        DataSet ds = new DataSet();
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DropDownList ddlInstructionType = (DropDownList)gvSiteInstruction.FooterRow.FindControl("ddlInstructionType");

        //Modify By  on 18-Mar-2013 Start***
        //int IndustryTypeID;
        string IndustryTypeID;
        //int InstructionTypeID;
        string InstructionTypeID;
        //Modify by  on 19-July-2013 for RadCombobox control
        //TextBox txtNewSiteInstruction = (TextBox)gvSiteInstruction.FooterRow.FindControl("txtNewSiteInstruction");
       
        if (ddlIndustryType.SelectedValue.ToString() == "")
        {
            //IndustryTypeID = 0;
            IndustryTypeID = null;
        }
        else
        {
            // IndustryTypeID = int.Parse(ddlIndustryType.SelectedValue.ToString());
            IndustryTypeID = ddlIndustryType.SelectedValue.ToString();
        }
        if (ddlInstructionType.SelectedValue.ToString() == "")
        {
            //InstructionTypeID = 0;
            InstructionTypeID = null;
        }
        else
        {
            //InstructionTypeID = int.Parse(ddlInstructionType.SelectedValue.ToString());
            InstructionTypeID = ddlInstructionType.SelectedValue;
        }
        if (Status == 1)
        {
            int flag = 1;
            Label lblInstructionType = (Label)gvSiteInstruction.FooterRow.FindControl("lblInstructionType");
            //Modify by  on 19-July-2013 for RadCombobox control
            //TextBox txtNewSiteInstruction = (TextBox)e.Row.FindControl("txtNewSiteInstruction");
            RadComboBox txtSiteInstruction = (RadComboBox)gvSiteInstruction.FooterRow.FindControl("txtNewSiteInstruction");
            if (!string.IsNullOrEmpty(txtSiteInstruction.Text))
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    DataRow dr = dtSiteInstructionTemp.NewRow();
                    dr[0] = 0;
                    //dr[1] = int.Parse(ddlInstructionType.SelectedValue.ToString());
                    dr[1] = ddlInstructionType.SelectedValue;
                    dr[2] = ddlInstructionType.SelectedItem.Text;
                    dr[3] = txtSiteInstruction.Text;

                    if (dtSiteInstructionTemp.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtSiteInstructionTemp.Rows.Count; i++)
                        {
                            if (ddlInstructionType.SelectedValue.ToString().Trim() == dtSiteInstructionTemp.Rows[i][1].ToString().Trim() && txtSiteInstruction.Text.Trim() == dtSiteInstructionTemp.Rows[i][3].ToString().Trim())
                            {
                                lblErrorMsg.Text = "Record already exists";
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
                        dtSiteInstructionTemp.Rows.Add(dr);
                        gvSiteInstruction.DataSource = dtSiteInstructionTemp;
                        gvSiteInstruction.DataBind();
                    }
                    else
                    {
                        flag = 0;
                    }
                }
            }
                //Added by  on 23-July-2013
            else
            {
                lblErrorMsg.Text = "Site Instruction Description can't be left blank.";
                txtSiteInstruction.Focus();
                return;
            }
            //End
           
        }
        else if (Status == 0)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                RadComboBox txtNewSiteInstruction = (RadComboBox)gvSiteInstruction.FooterRow.FindControl("txtNewSiteInstruction");
                //Added Code for check the duplicate record by  on 2-Jun-2013
                if (gvSiteInstruction.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(txtNewSiteInstruction.Text))
                    {
                        DataTable dtTemp = new DataTable();

                        dtTemp.Columns.Add("InstructionType");
                        dtTemp.Columns.Add("InstructionTypeDesc");

                        foreach (GridViewRow row in gvSiteInstruction.Rows)
                        {
                            DataRow drTemp = dtTemp.NewRow();

                            drTemp["InstructionType"] = ((Label)(row.Cells[3].Controls[1])).Text;
                            drTemp["InstructionTypeDesc"] = ((Label)(row.Cells[4].Controls[1])).Text;

                            dtTemp.Rows.Add(drTemp);
                        }

                        for (int cnt = 0; cnt < dtTemp.Rows.Count; cnt++)
                        {
                            if (ddlInstructionType.SelectedItem.Text.Trim() == dtTemp.Rows[cnt]["InstructionType"].ToString().Trim() && txtNewSiteInstruction.Text.Trim() == dtTemp.Rows[cnt]["InstructionTypeDesc"].ToString().Trim())
                            {
                                lblErrorMsg.Text = "Record already exists";
                                return;
                            }
                        }
                        //End
                        ds = objOPS.SiteInstructionDetailInsert(txtAssignInstNo.Text.ToString(), InstructionTypeID, txtNewSiteInstruction.Text.ToString(), BaseUserID); // True Value is for Status ,Status=true means QuickCode is active status=false means QuickCode is not active
                        /* Added by  on 30-May-2013 */
                        DataRow dr = dtSiteInstructionTemp.NewRow();
                        dr[0] = 0;
                        dr[1] = ddlInstructionType.SelectedValue;
                        dr[2] = ddlInstructionType.SelectedItem.Text;
                        dr[3] = txtNewSiteInstruction.Text;
                        dtSiteInstructionTemp.Rows.Add(dr);
                        /* End */
                        FillgvSiteInstructionForIndustry(IndustryTypeID.ToString());
                        if (gvSiteInstruction.Rows.Count.Equals(gvSiteInstruction.PageSize))
                        {
                            gvSiteInstruction.PageIndex = gvSiteInstruction.PageCount + 1;
                        }
                        gvSiteInstruction.EditIndex = -1;
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
                    }
                        //Added on 23-July-2013
                    else
                    {
                        lblErrorMsg.Text = "Site Instruction Description can't be left blank.";
                        txtNewSiteInstruction.Focus();
                        return;
                    }
                    //End
                }
            }
           
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (Status == 1)
        {
            gvSiteInstruction.EditIndex = e.NewEditIndex;
            gvSiteInstruction.DataSource = dtSiteInstructionTemp;
            gvSiteInstruction.DataBind();
        }
        else if (Status == 0)
        {
            gvSiteInstruction.EditIndex = e.NewEditIndex;
            FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
            gvSiteInstruction.Rows[e.NewEditIndex].Focus();         //Added For Set Focus by  on 26-July-2013
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int InstructionTypeID;
        DropDownList ddlInstructionType = (DropDownList)gvSiteInstruction.Rows[e.RowIndex].FindControl("ddlInstructionType");
        Label lblInstructionType = (Label)gvSiteInstruction.FooterRow.FindControl("lblInstructionType");
        Label lblRowID = (Label)gvSiteInstruction.Rows[e.RowIndex].FindControl("lblRowID");
        TextBox txtSiteInstruction = (TextBox)gvSiteInstruction.Rows[e.RowIndex].FindControl("txtSiteInstruction");
        if (Status == 1)
        {
            dtSiteInstructionTemp.Rows.RemoveAt(e.RowIndex);
            //Modified by  on 8-Apr-2013
            if (dtSiteInstructionTemp.Rows.Count > 0)
            {
                gvSiteInstruction.DataSource = dtSiteInstructionTemp;
                gvSiteInstruction.DataBind();
            }
            else
            {
                FillgvSiteInstructionForIndustryTemp();
            }
        }
        else if (Status == 0)
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOPS = new BL.OperationManagement();
            ds = objOPS.SiteInstructionDetailDelete(int.Parse(lblRowID.Text.ToString()));
            //FillgvSiteInstructionForIndustry(int.Parse(ddlIndustryType.SelectedValue.ToString()));
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
        }
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSiteInstruction.EditIndex = -1;
        if (Status == 1)
        {
            gvSiteInstruction.DataSource = dtSiteInstructionTemp;
            gvSiteInstruction.DataBind();
        }
        else
        {
            FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSiteInstruction.PageIndex = e.NewPageIndex;
        gvSiteInstruction.EditIndex = -1;
        FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int InstructionTypeID;
        DataSet ds = new DataSet();
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DropDownList ddlInstructionType = (DropDownList)gvSiteInstruction.Rows[e.RowIndex].FindControl("ddlInstructionType");
        Label lblInstructionType = (Label)gvSiteInstruction.FooterRow.FindControl("lblInstructionType");
        Label lblRowID = (Label)gvSiteInstruction.Rows[e.RowIndex].FindControl("lblRowID");
        TextBox txtSiteInstruction = (TextBox)gvSiteInstruction.Rows[e.RowIndex].FindControl("txtSiteInstruction");
        if (ddlInstructionType.SelectedValue.ToString() == "")
        {
            InstructionTypeID = 0;
        }
        else
        {
            InstructionTypeID = int.Parse(ddlInstructionType.SelectedValue.ToString());
        }
        
        //Added Code for check the duplicate record in Grid by  on 26-July-2013
        if (gvSiteInstruction.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(txtSiteInstruction.Text))
            {
                DataTable dtTemp = new DataTable();

                dtTemp.Columns.Add("InstructionType");
                dtTemp.Columns.Add("InstructionTypeDesc");

                foreach (GridViewRow row in gvSiteInstruction.Rows)
                {
                    DataRow drTemp = dtTemp.NewRow();
                    if (row.Cells[3].Controls[1].GetType().Name == "DropDownList" && row.Cells[4].Controls[1].GetType().Name =="TextBox")
                    {
                        drTemp["InstructionType"] = ((DropDownList)(row.Cells[3].Controls[1])).Text;
                        drTemp["InstructionTypeDesc"] = ((TextBox)(row.Cells[4].Controls[1])).Text;
                    }
                    else
                    {
                        drTemp["InstructionType"] = ((Label)(row.Cells[3].Controls[1])).Text;
                        drTemp["InstructionTypeDesc"] = ((Label)(row.Cells[4].Controls[1])).Text;
                    }
                    dtTemp.Rows.Add(drTemp);
                }

                for (int cnt = 0; cnt < dtTemp.Rows.Count; cnt++)
                {
                    if (ddlInstructionType.SelectedItem.Text.Trim() == dtTemp.Rows[cnt]["InstructionType"].ToString().Trim() && txtSiteInstruction.Text.Trim() == dtTemp.Rows[cnt]["InstructionTypeDesc"].ToString().Trim())
                    {
                        lblErrorMsg.Text = "Record already exists";
                        return;
                    }
                }
            }
        }
        //End
        if (Status == 1)
        {
            dtSiteInstructionTemp.Rows[e.RowIndex][0] = lblRowID.Text;
            dtSiteInstructionTemp.Rows[e.RowIndex][1] = int.Parse(ddlInstructionType.SelectedValue.ToString());
            dtSiteInstructionTemp.Rows[e.RowIndex][2] = ddlInstructionType.SelectedItem.Text.ToString();
            dtSiteInstructionTemp.Rows[e.RowIndex][3] = txtSiteInstruction.Text;
            gvSiteInstruction.EditIndex = -1;
            gvSiteInstruction.DataSource = dtSiteInstructionTemp;
            gvSiteInstruction.DataBind();
        }
        else if (Status == 0)
        {
            ds = objOPS.SiteInstructionDetailUpdate(int.Parse(lblRowID.Text.ToString()), txtAssignInstNo.Text, InstructionTypeID, txtSiteInstruction.Text, BaseUserID);
            gvSiteInstruction.EditIndex = -1;
            FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                gvSiteInstruction.EditIndex = -1;
                FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
            }
        }
    }

    /// <summary>
    /// Gets or sets the grid view sort direction.
    /// </summary>
    /// <value>The grid view sort direction.</value>
    public SortDirection GridViewSortDirection
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
    /// Sorts the grid view.
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

    /// <summary>
    /// Handles the Sorting event of the gvSiteInstruction control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
    protected void gvSiteInstruction_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataView dv = new DataView(objMastersManagement.SiteInstructionGetAll(ddlIndustryType.SelectedValue.ToString(), BaseCompanyCode).Tables[0]);
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESC", dv, gvSiteInstruction);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASC", dv, gvSiteInstruction);
        }
    }

    #endregion
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlIndustryType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlIndustryType_SelectedIndexChanged(object sender, EventArgs e)
    {

        Status = 1;
        FillgvSiteInstructionForIndustry(ddlIndustryType.SelectedValue.ToString());
    }

    /// <summary>
    /// Handles the TextChanged event of the txtEmployeeID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeID_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeID.Text, BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            //EnableButton();
            lblEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            lblEmpDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
            lblEmployeeName.Text = "";
            lblEmpDesignation.Text = "";
            //DisableButtons();
            //Added by  on 2-Jun-2013
            txtEmployeeID.Text = "";
            txtEmployeeID.Focus();
        }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        int flag = 1;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        //Modified by  on 4-Apr-2013
        //if (dtSiteInstructionTemp.Rows.Count < 1)
        if (gvSiteInstruction.Rows.Count < 1)
        {
            lblErrorMsg.Text = "Site Instruction Details Cannot be left blank";
            flag = 0;
        }

        if (flag == 1)
        {
            if (DateTime.Parse(txtAssignInstDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
            {
                if (DateTime.Parse(txtNextRivisionDate.Text) > DateTime.Parse(txtAssignInstDate.Text))
                {

                    if (DateTime.Parse(txtPrepDate.Text) >= DateTime.Parse(txtAssignInstDate.Text))
                    {

                        if (DateTime.Parse(txtPrepDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
                        {
                            //Added Code to Check Signed Mark by  on 2-Jun-2013
                            if (Convert.ToInt32(ddlClientSinged.SelectedItem.Value) > 0)
                            {
                                if (!string.IsNullOrEmpty(txtSingingDate.Text))
                                {
                                    if (DateTime.Parse(txtSingingDate.Text) < DateTime.Parse(txtPrepDate.Text))
                                    {
                                        lblErrorMsg.Text = "Signing  Date Should Always Be Greater Than Prepared Date";
                                        return;
                                    }
                                }
                                else
                                {
                                    lblErrorMsg.Text = "Signing  Date can not be left blank.";
                                    txtSingingDate.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                txtSingingDate.Text = defaultDate;
                            }
                            //End

                            // Commented & Modify by  on 22-May-2013 and 24-Jun-2013
                            //ds = objOperationManagement.SiteInstructionInsert(DateTime.Parse(txtAssignInstDate.Text), DateTime.Parse(txtNextRivisionDate.Text), txtAssignNo.Text, txtEmployeeID.Text, DateTime.Parse(txtPrepDate.Text), int.Parse(ddlInstReason.SelectedValue.ToString()), int.Parse(ddlClientSinged.SelectedValue.ToString()), DateTime.Parse(txtSingingDate.Text), txtClientRepSinged.Text, txtDesignation.Text, txtReasonNotSigned.Text, dtSiteInstructionTemp, BaseUserID, int.Parse(BaseLocationAutoID), Resources.Resource.Fresh);
                            if (dtSiteInstructionTemp.Rows.Count > 0)
                            {
                                ds = objOperationManagement.SiteInstructionInsert(DateTime.Parse(txtAssignInstDate.Text), DateTime.Parse(txtNextRivisionDate.Text), ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, txtEmployeeID.Text, DateTime.Parse(txtPrepDate.Text), int.Parse(ddlInstReason.SelectedValue.ToString()), int.Parse(ddlClientSinged.SelectedValue.ToString()), DateTime.Parse(txtSingingDate.Text), txtClientRepSinged.Text, txtDesignation.Text, txtReasonNotSigned.Text, dtSiteInstructionTemp, BaseUserID, int.Parse(BaseLocationAutoID), Resources.Resource.Fresh, dtUpload);
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                                {
                                    txtAssignInstNo.Text = ds.Tables[0].Rows[0]["SiteInstNo"].ToString();
                                    lblStatus.Text = Resources.Resource.Fresh;
                                    gvSiteInstruction.FooterRow.Visible = false;
                                    Status = 0;
                                    hideshowButtons("");
                                    enabledisableFields("");

                                    //Added Code by  on 2-Jun-2013
                                    if (txtSingingDate.Text == defaultDate)
                                    {
                                        txtSingingDate.Text = "";
                                    }
                                    //End
                                }
                            }
                            else
                            {
                                lblErrorMsg.Text = "Site Instruction Details Cannot be left blank";
                                flag = 0;
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = "Prepration date Should always be greater than or equal to asmt start date";
                            txtPrepDate.Text = DateTime.Parse(hfAsmtStartDate.Value).ToString("dd-MMM-yyyy");
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = "Prepared Date Should always be greater than and equal to  Assignment Instruction Date";
                        txtPrepDate.Focus();
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Next Rivision Date Should always be greater than Assignment Instruction Date";
                    txtNextRivisionDate.Focus();
                }
            }
            else
            {
                lblErrorMsg.Text = "Assignment Instruction Date Should always be greater than equal to Assignment Start Date";
                txtAssignInstDate.Focus();
            }
        }
        FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
    }

    /// <summary>
    /// Handles the TextChanged event of the txtAssignInstNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAssignInstNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOPS = new BL.OperationManagement();
        ds = objOPS.SiteInstructionNumberGet(txtAssignInstNo.Text, int.Parse(BaseLocationAutoID));
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            txtAssignInstDate.Text = DateFormat(ds.Tables[0].Rows[0]["Instruction_Date"].ToString());
            txtNextRivisionDate.Text = DateFormat(ds.Tables[0].Rows[0]["Next_revision_date"].ToString());
            //Commented & Modify by  on 22-May-2013
            //txtAssignNo.Text = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
            txtEmployeeID.Text = ds.Tables[0].Rows[0]["Prepared_By"].ToString();
            txtPrepDate.Text = DateFormat(ds.Tables[0].Rows[0]["Prepared_Date"].ToString());
            ddlInstReason.SelectedValue = ds.Tables[0].Rows[0]["Prepare_Reason"].ToString();
            ddlClientSinged.SelectedValue = ds.Tables[0].Rows[0]["Client_Signed"].ToString();
            txtSingingDate.Text = DateFormat(ds.Tables[0].Rows[0]["Signed_Date"].ToString());
            txtClientRepSinged.Text = ds.Tables[0].Rows[0]["Client_Represntative_Signed"].ToString();
            txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
            txtReasonNotSigned.Text = ds.Tables[0].Rows[0]["Reason_Not_Sign"].ToString();
            //txtAssignNo_TextChanged(sender, e);
            txtEmployeeID_TextChanged(sender, e);
            FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
            enabledisableFields("");
            hideshowButtons("");
            enabledisableFields("");
            Status = 0;
            //Added by  on 29-May-2013
            string clientCode = ds.Tables[0].Rows[0]["ClientCode"].ToString();
            string asmtId = ds.Tables[0].Rows[0]["AsmtId"].ToString();
            SetClientId(clientCode);
            SetAsmt(asmtId);
            ddlAsmtId_SelectedIndexChanged(sender, e);
            //End
            //Added by  on 4-Apr-2013
            if (ddlClientSinged.SelectedItem.Text == "Yes")
            {
                lblResonNotSigned.Visible = false;
                txtReasonNotSigned.Visible = false;
            }
            else
            {
                lblResonNotSigned.Visible = true;
                txtReasonNotSigned.Visible = true;
            }
            //Added Code by  on 2-Jun-2013
            if (lblStatus.Text == Resources.Resource.Authorized)
            {
                IMGSingingDate.Visible = false;
            }
            else
            {
                if (Convert.ToInt32(ddlClientSinged.SelectedItem.Value) > 0)
                {
                    IMGSingingDate.Visible = true;
                }
                else
                {
                    IMGSingingDate.Visible = false;
                }
            }
            //End
            //Added Code for Upload Document by  on 24-Jun-2013
            FillgvEmployeeDocDownload();
            //End
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
            clearFields("");
            FillgvSiteInstructionForIndustryTemp();
            hideshowButtons("norecfound");
            enabledisableFields("");
            //DisableButtons();
        }
    }

    /// <summary>
    /// Clears the fields.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    protected void clearFields(string strParam)
    {
        if (strParam == "")
        {
            lblStatus.Text = "";
            txtAssignInstNo.Text = "";
            txtAssignInstDate.Text = "";
            txtNextRivisionDate.Text = "";
            //txtAssignNo.Text = "";
            // txtCustomerID.Text = "";
            //txtCustomerDesc.Text = "";
            //txtAddressID.Text = "";
            //txtAddressDesc.Text = "";
            txtAreaID.Text = "";
            txtAreaDesc.Text = "";
            lblEmployeeName.Text = "";
            lblEmpDesignation.Text = "";
            txtEmployeeID.Text = "";
            txtPrepDate.Text = "";
            ddlInstReason.SelectedValue = "0";
            ddlClientSinged.SelectedValue = "0";
            txtSingingDate.Text = "";
            txtClientRepSinged.Text = "";
            txtDesignation.Text = "";
            txtReasonNotSigned.Text = "";
            //Added by  on 29-May-2013
            dtSiteInstructionTemp.Clear();
            //End
            FillgvSiteInstructionForIndustryTemp();
            //Added by  on 29-May-2013
            ddlAsmtId.Items.Clear();
            FillClientId();
            //End
        }
    }

    /// <summary>
    /// Enabledisables the fields.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    protected void enabledisableFields(string strParam)
    {
        if (strParam == "")
        {
            if (lblStatus.Text == Resources.Resource.Fresh)
            {
                txtAssignInstNo.Enabled = true;
                //txtAssignInstDate.Enabled = true;
                //txtAssignNo.Enabled = true;
                txtEmployeeID.Enabled = true;
                //txtPrepDate.Enabled = true;
                ddlInstReason.Enabled = true;
                ddlClientSinged.Enabled = true;
                //txtSingingDate.Enabled = true;
                txtClientRepSinged.Enabled = true;
                txtDesignation.Enabled = true;
                txtReasonNotSigned.Enabled = true;
            }
            else if (lblStatus.Text == Resources.Resource.Authorized)
            {
                txtAssignInstNo.Enabled = true;
                txtAssignInstDate.Enabled = false;
                //txtAssignNo.Enabled = false;
                txtEmployeeID.Enabled = false;
                txtPrepDate.Enabled = false;
                ddlInstReason.Enabled = false;
                ddlClientSinged.Enabled = false;
                txtSingingDate.Enabled = false;
                txtClientRepSinged.Enabled = false;
                txtDesignation.Enabled = false;
                txtReasonNotSigned.Enabled = false;
            }
            else if (lblStatus.Text == Resources.Resource.Amend)
            {
                txtAssignInstNo.Enabled = true;
                txtAssignInstDate.Enabled = false;
                //txtAssignNo.Enabled = false;
                txtEmployeeID.Enabled = true;
                //txtPrepDate.Enabled = true;
                ddlInstReason.Enabled = true;
                ddlClientSinged.Enabled = true;
                //txtSingingDate.Enabled = true;
                txtClientRepSinged.Enabled = true;
                txtDesignation.Enabled = true;
                txtReasonNotSigned.Enabled = true;
            }
            else
            {
                txtAssignInstNo.Enabled = true;
                //txtAssignInstDate.Enabled = true;
                //txtAssignNo.Enabled = true;
                txtEmployeeID.Enabled = true;
                //txtPrepDate.Enabled = true;
                ddlInstReason.Enabled = true;
                ddlClientSinged.Enabled = true;
                //txtSingingDate.Enabled = true;
                txtClientRepSinged.Enabled = true;
                txtDesignation.Enabled = true;
                txtReasonNotSigned.Enabled = true;
            }
        }
        else if (strParam == "addnew")
        {
            txtAssignInstNo.Enabled = true;
            //txtAssignInstDate.Enabled = true;
            //txtAssignNo.Enabled = true;
            txtEmployeeID.Enabled = true;
            //txtPrepDate.Enabled = true;
            ddlInstReason.Enabled = true;
            ddlClientSinged.Enabled = true;
            //txtSingingDate.Enabled = true;
            txtClientRepSinged.Enabled = true;
            txtDesignation.Enabled = true;
            txtReasonNotSigned.Enabled = true;
            ddlIndustryType.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// Hideshows the buttons.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    protected void hideshowButtons(string strParam)
    {
        if (strParam == "")
        {
            if (lblStatus.Text == Resources.Resource.Fresh)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsAuthorizationAccess == true)
                {
                    btnAuthorize.Visible = true;
                }
                else
                {
                    btnAuthorize.Visible = false;
                }
                if (IsModifyAccess == true)
                {
                    btnUpdate.Visible = true;
                }
                btnReset.Visible = true;
                btnSave.Visible = false;
                btnEdit.Visible = false;

            }
            else if (lblStatus.Text == Resources.Resource.Authorized)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnEdit.Visible = true;
                }
                btnUpdate.Visible = false;
                btnReset.Visible = true;
                btnSave.Visible = false;
                btnAuthorize.Visible = false;
                gvSiteInstruction.Columns[0].Visible = false;
                gvSiteInstruction.FooterRow.Visible = false;
                //Added Code for Upload Document by  on 14-Jun-2013
                btnUpload.Enabled = false;
            }
            else if (lblStatus.Text == Resources.Resource.Amend)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsAuthorizationAccess == true)
                {
                    btnAuthorize.Visible = true;
                }
                else
                {
                    btnAuthorize.Visible = false;
                }
                if (IsModifyAccess == true)
                {
                    btnUpdate.Visible = true;
                    gvSiteInstruction.Columns[0].Visible = true;
                    gvSiteInstruction.FooterRow.Visible = true;
                }

                btnReset.Visible = true;
                btnSave.Visible = false;
                btnEdit.Visible = false;

            }
            else
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                    btnSave.Visible = true;
                }
                btnUpdate.Visible = false;
                btnReset.Visible = true;
                btnEdit.Visible = false;
                btnAuthorize.Visible = false;
            }
        }
        else if (strParam == "pageload" || strParam == "addnew" || strParam == "norecfound")
        {
            if (IsWriteAccess == true)
            {
                btnAddNew.Visible = true;
                btnSave.Visible = true;
                //Added By  on 4-Apr-2013
                gvSiteInstruction.Columns[0].Visible = true;
                gvSiteInstruction.FooterRow.Visible = true;
            }
            btnUpdate.Visible = false;
            btnReset.Visible = true;
            btnEdit.Visible = false;
            btnAuthorize.Visible = false;
        }

    }

    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataSet dsSiteInstDtlBulkInsert = new DataSet();
        DataSet dsSiteInstDtlBulkDelete = new DataSet();

        int flag = 1;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();

        if (count == 0)
        {
            lblErrorMsg.Text = "Site Instruction Details Cannot be left blank";
            flag = 0;
        }
        if (flag == 1)
        {
            if (DateTime.Parse(txtAssignInstDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
            {
                if (DateTime.Parse(txtNextRivisionDate.Text) > DateTime.Parse(txtAssignInstDate.Text))
                {

                    if (DateTime.Parse(txtPrepDate.Text) >= DateTime.Parse(txtAssignInstDate.Text))
                    {

                        if (DateTime.Parse(txtPrepDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
                        {
                            //Added Code to Check Signed Mark by  on 2-Jun-2013
                            if (Convert.ToInt32(ddlClientSinged.SelectedItem.Value) > 0)
                            {
                                if (!string.IsNullOrEmpty(txtSingingDate.Text))
                                {
                                    if (DateTime.Parse(txtSingingDate.Text) < DateTime.Parse(txtPrepDate.Text))
                                    {
                                        lblErrorMsg.Text = "Signing  Date Should Always Be Greater Than Prepared Date";
                                        return;
                                    }
                                }
                                else
                                {
                                    lblErrorMsg.Text = "Signing  Date can not be left blank.";
                                    txtSingingDate.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                txtSingingDate.Text = defaultDate;
                            }
                            //End
                            //Comment & Modify by  on 22-May-2013
                            //ds = objOperationManagement.SiteInstructionUpdate(txtAssignInstNo.Text.ToString(), DateTime.Parse(txtAssignInstDate.Text), DateTime.Parse(txtNextRivisionDate.Text), txtAssignNo.Text, txtEmployeeID.Text, DateTime.Parse(txtPrepDate.Text), int.Parse(ddlInstReason.SelectedValue.ToString()), int.Parse(ddlClientSinged.SelectedValue.ToString()), DateTime.Parse(txtSingingDate.Text), txtClientRepSinged.Text, txtDesignation.Text, txtReasonNotSigned.Text, BaseUserID, int.Parse(BaseLocationAutoID), Resources.Resource.Fresh);
                            ds = objOperationManagement.SiteInstructionUpdate(txtAssignInstNo.Text.ToString(), DateTime.Parse(txtAssignInstDate.Text), DateTime.Parse(txtNextRivisionDate.Text), ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, txtEmployeeID.Text, DateTime.Parse(txtPrepDate.Text), int.Parse(ddlInstReason.SelectedValue.ToString()), int.Parse(ddlClientSinged.SelectedValue.ToString()), DateTime.Parse(txtSingingDate.Text), txtClientRepSinged.Text, txtDesignation.Text, txtReasonNotSigned.Text, BaseUserID, int.Parse(BaseLocationAutoID), Resources.Resource.Fresh);
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                            //Added by  on 2-Jun-2013
                            if (txtSingingDate.Text == defaultDate)
                            {
                                txtSingingDate.Text = "";
                            }
                            //End
                        }
                        else
                        {
                            lblErrorMsg.Text = "Prepration date Should always be greater than or equal to asmt start date";
                            txtPrepDate.Text = DateTime.Parse(hfAsmtStartDate.Value).ToString("dd-MMM-yyyy");
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = "Prepared Date Should always be greater than and equal to  Assignment Instruction Date";
                        txtPrepDate.Focus();

                    }
                }
                else
                {
                    lblErrorMsg.Text = "Next Rivision Date Should always be greater than Assignment Instruction Date";
                    txtNextRivisionDate.Focus();

                }

            }
            else
            {
                lblErrorMsg.Text = "Assignment Instruction Date Should always be greater than equal to Assignment Start Date";
                txtAssignInstDate.Focus();

            }

        }
        if (Status == 1)
        {
            dsSiteInstDtlBulkDelete = objOperationManagement.SiteInstructionDetailBulkDelete(txtAssignInstNo.Text.ToString());
            dsSiteInstDtlBulkInsert = objOperationManagement.SiteInstructionBulkInsert(txtAssignInstNo.Text.ToString(), dtSiteInstructionTemp, BaseUserID);
            DisplayMessage(lblErrorMsg, dsSiteInstDtlBulkInsert.Tables[0].Rows[0]["MessageID"].ToString());
        }
        Status = 0;
        FillgvSiteInstructionForIndustryTempAfterSave(txtAssignInstNo.Text.ToString());
    }

    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        clearFields("");
        enabledisableFields("addnew");
        hideshowButtons("addnew");
        FillgvSiteInstructionForIndustryTemp();
        //Added by  on 29-May-2013
        //FillClientId();
        DataSet dsSiteInstDtlBulkDelete = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlClientId.Enabled = true;
        if (string.IsNullOrEmpty(txtAssignInstNo.Text))
        {
            dsSiteInstDtlBulkDelete = objOperationManagement.SiteInstructionDetailBulkDelete(txtAssignInstNo.Text.ToString());
        }

        //Added code for Upload Document by  on 24-Jun-2013
        FillgvEmployeeDocDownload();
        IMGSingingDate.Visible = true;                  //Added By  on 27-Aug-2013
    }

    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataSet dsSiteInstDtlBulkInsert = new DataSet();
        DataSet dsSiteInstDtlBulkDelete = new DataSet();
        int flag = 1;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();

        if (count == 0)
        {
            lblErrorMsg.Text = "Site Instruction Details Cannot be left blank";
            flag = 0;
        }
        //Added by  on 2-Jun-2013
        IMGSingingDate.Visible = false;
        //End

        if (flag == 1)
        {
            if (DateTime.Parse(txtAssignInstDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
            {
                if (DateTime.Parse(txtNextRivisionDate.Text) > DateTime.Parse(txtAssignInstDate.Text))
                {

                    if (DateTime.Parse(txtPrepDate.Text) >= DateTime.Parse(txtAssignInstDate.Text))
                    {

                        if (DateTime.Parse(txtPrepDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
                        {
                            //Commented by  on 2-Jun-2013
                            //if (DateTime.Parse(txtSingingDate.Text) > DateTime.Parse(txtPrepDate.Text))
                            //{
                            ds = objOperationManagement.SiteInstructionAuthorize(txtAssignInstNo.Text.ToString(), BaseUserID, int.Parse(BaseLocationAutoID), Resources.Resource.Authorized);
                            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "17")
                            {
                                lblStatus.Text = Resources.Resource.Authorized;
                                Status = 0;
                                enabledisableFields("");
                                hideshowButtons("");

                                //Added for Upload Document by  on 28-Jun-2013
                                if (lblStatus.Text == Resources.Resource.Authorized)
                                {
                                    gvEmployeeDocument.Columns[4].Visible = false;
                                }
                                //End
                            }
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            //Commented by  on 2-Jun-2013
                            //}
                            //else
                            //{
                            //    lblErrorMsg.Text = "Signing  Date Should Always Be Greater Than Prepared Date";
                            //}
                        }
                        else
                        {
                            lblErrorMsg.Text = "Prepration date Should always be greater than or equal to asmt start date";
                            txtPrepDate.Text = DateTime.Parse(hfAsmtStartDate.Value).ToString("dd-MMM-yyyy");
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = "Prepared Date Should always be greater than and equal to  Assignment Instruction Date";
                        txtPrepDate.Focus();
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Next Rivision Date Should always be greater than Assignment Instruction Date";
                    txtNextRivisionDate.Focus();
                }
            }
            else
            {
                lblErrorMsg.Text = "Assignment Instruction Date Should always be greater than equal to Assignment Start Date";
                txtAssignInstDate.Focus();

            }
        }
    }

    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataSet dsSiteInstDtlBulkInsert = new DataSet();
        DataSet dsSiteInstDtlBulkDelete = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.SiteInstructionAmend(txtAssignInstNo.Text.ToString(), BaseUserID, int.Parse(BaseLocationAutoID), Resources.Resource.Amend);
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "15")
        {
            lblStatus.Text = Resources.Resource.Amend;
            Status = 0;
            enabledisableFields("");
            hideshowButtons("");
            //Added by  on 2-Jun-2013
            if (Convert.ToInt32(ddlClientSinged.SelectedItem.Value) > 0)
            {
                IMGSingingDate.Visible = true;
            }
            else
            {
                IMGSingingDate.Visible = false;
            }
            //End
        }
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

        //Added for Upload Document by  on 24-Jun-2013
        if (lblStatus.Text == Resources.Resource.Authorized)
        {
            gvEmployeeDocument.Columns[4].Visible = false;
        }
        else
        {
            gvEmployeeDocument.Columns[4].Visible = true;
        }
        //Added By  on 23-July-2013
        btnUpload.Enabled = true;
        //End
    }

    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clearFields("");
        enabledisableFields("");
        hideshowButtons("");
    }

    /// <summary>
    /// Handles the TextChanged event of the txtNextRivisionDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNextRivisionDate_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtNextRivisionDate.Text) && !string.IsNullOrEmpty(txtAssignInstDate.Text))
        {
            if (DateTime.Parse(txtNextRivisionDate.Text) <= DateTime.Parse(txtAssignInstDate.Text))
            {
                lblErrorMsg.Text = "Next Rivision Date Should always be greater than Assignment Instruction Date";
                txtNextRivisionDate.Focus();
            }
        }
        else
        {
            lblErrorMsg.Text = "Next Rivision Date or Assignment Instruction Date Should not be blank";
        }
    }

    #region Commented unused Code by  on 24-Jun-2013
    //protected void txtSingingDate_TextChanged(object sender, EventArgs e)
    //{
    //    if (!string.IsNullOrEmpty(txtSingingDate.Text) && !string.IsNullOrEmpty(txtPrepDate.Text))
    //    {
    //        if (DateTime.Parse(txtSingingDate.Text) <= DateTime.Parse(txtPrepDate.Text))
    //        {
    //            lblErrorMsg.Text = "Singing Date Should always be greater than Prepared Date";
    //            txtSingingDate.Focus();
    //        }
    //    }
    //    else
    //    {
    //        lblErrorMsg.Text = "Singing Date or Prepared Date Should not be blank";
    //    }
    //}

    //protected void txtPrepDate_TextChanged(object sender, EventArgs e)
    //{
    //    if (!string.IsNullOrEmpty(txtPrepDate.Text) && !string.IsNullOrEmpty(txtAssignInstDate.Text))
    //    {
    //        if (DateTime.Parse(txtPrepDate.Text) < DateTime.Parse(txtAssignInstDate.Text))
    //        {
    //            lblErrorMsg.Text = "Prepared Date Should always be greater than and equal to  Assignment Instruction Date";
    //            txtPrepDate.Focus();
    //        }
    //    }
    //    else
    //    {
    //        lblErrorMsg.Text = "Assignment Instruction Date or Prepared Date Should not be blank";
    //    }

    //    if (!string.IsNullOrEmpty(txtPrepDate.Text) && !string.IsNullOrEmpty(hfAsmtStartDate.Value))
    //    {
    //        if (DateTime.Parse(txtPrepDate.Text) < DateTime.Parse(hfAsmtStartDate.Value))
    //        {
    //            lblErrorMsg.Text = "Prepration date Should always be greater than or equal to asmt start date";
    //            txtPrepDate.Focus();
    //        }
    //    }
    //    else
    //    {
    //        lblErrorMsg.Text = "Assignment Start Date or Prepared Date Should not be blank";
    //    }
    //}

    //Modified by  on 4-Apr-2013
    #endregion
    /// <summary>
    /// Handles the TextChanged event of the ddlClientSinged control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientSinged_TextChanged(object sender, EventArgs e)
    {
        if (ddlClientSinged.SelectedItem.Text == "Yes")
        {
            lblResonNotSigned.Visible = false;
            txtReasonNotSigned.Visible = false;
            IMGSingingDate.Visible = true;
        }
        else
        {
            lblResonNotSigned.Visible = true;
            txtReasonNotSigned.Visible = true;
            IMGSingingDate.Visible = false;
            txtSingingDate.Text = "";
        }
    }

    #region Coded Added by 
    //Added by  on 29-May-2013
    /// <summary>
    /// Fills the client identifier.
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
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    /// <summary>
    /// Execute on ddlClientId Item Selection get changed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtCustomerDesc.Text = ddlClientId.SelectedItem.Text;
        FillAsmt();
    }

    //Get Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Fills the asmt.
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
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
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
    //Set Client Code on based on txtIncidentNo
    /// <summary>
    /// Sets the client identifier.
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
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }

    //Set Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Sets the asmt.
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
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    #endregion

    #region Upload Document Code Added by  on 24-Jun-2013
    /// <summary>
    /// Creates the upload table.
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
    /// Fillgvs the employee document download.
    /// </summary>
    private void FillgvEmployeeDocDownload()
    {
        string strEmployeeNumber = txtEmployeeID.Text;

        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ds = objOPS.OPSDocumentDownload(txtAssignInstNo.Text, strEmployeeNumber);
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
        if (lblStatus.Text == Resources.Resource.Authorized)
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
    /// Handles the Click event of the btnUpload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEmployeeID.Text))
        {
            String path = Server.MapPath("../DocumentUpload/EmployeeDocUpload/");
            string strEmployeeNumber = txtEmployeeID.Text;
            string strRefNo = txtAssignInstNo.Text;
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
    /// Handles the Click event of the lbFileName control.
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
    /// Handles the RowDataBound event of the gvEmployeeDocument control.
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
    /// Handles the RowDeleting event of the gvEmployeeDocument control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvEmployeeDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();

        string strEmployeeNumber = txtEmployeeID.Text;
        string strRefNo = txtAssignInstNo.Text;

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
    /// Deletes the file.
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

    //Added Code for New Changes By  on 28-Jun-2013
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlInstructionType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlInstructionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Modify by  on 19-July-2013 for RadCombobox control
        //TextBox txtNewSiteInstruction = (TextBox)gvSiteInstruction.FooterRow.FindControl("txtNewSiteInstruction");

       

        RadComboBox txtNewSiteInstruction = (RadComboBox)gvSiteInstruction.FooterRow.FindControl("txtNewSiteInstruction");
        if (txtNewSiteInstruction != null)
        {
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            string InstructionTypeId = ((DropDownList)sender).SelectedItem.Value.ToString();
            DataSet ds = objMastersManagement.MasterSiteInstructionGetAll(InstructionTypeId, BaseCompanyCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtNewSiteInstruction.Items.Clear();
                txtNewSiteInstruction.DataSource = ds;
                txtNewSiteInstruction.DataTextField = "SiteInstruction";
                txtNewSiteInstruction.DataValueField = "InstructionTypeID";
                txtNewSiteInstruction.DataBind();
            }
            else
            {
                txtNewSiteInstruction.Items.Clear();
                //txtNewSiteInstruction.Text = ((DropDownList)sender).SelectedItem.Text;
            }
            ((DropDownList)sender).Focus();
        }
    }

    //Added Code for Resolve issue of Update Panel Exception on download file click by  on 2-Jun-2013
    /// <summary>
    /// Handles the PreRender event of the lbFileName control.
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
