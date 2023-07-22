// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="NightCheckVisitDetail.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class OperationManagement_NightCheckVisitDetail.
/// </summary>
public partial class OperationManagement_NightCheckVisitDetail : BasePage//System.Web.UI.Page
{
    /// <summary>
    /// The dt night check detail
    /// </summary>
    static DataTable dtNightCheckDetail = new DataTable();
    /// <summary>
    /// The status
    /// </summary>
    static int Status;
    /// <summary>
    /// The count
    /// </summary>
    static int count;
    /// <summary>
    /// The index
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
    #region function related to page load events
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.NightCheckVisitDetai + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                // txtDate.Text = DateFormat(DateTime.Now);
                btnSave.Enabled = false;         //Added by  on 2-Jun-2013
                Status = 1;
                count = 1;
                dtNightCheckDetail.Clear();
                FillgvNightCheckVisit();
                FillCheckVisitType();
                if (IsWriteAccess == true)
                {
                    btnSave.Visible = true;
                }
                if (dtNightCheckDetail.Columns.Contains("AsmtId") == false)         //Modify by  on 24-May-2013 AsmtCode as AsmtId
                {
                    MakeTempNightCheckVisit();
                }
                else
                {
                    dtNightCheckDetail.Clear();
                }
                IMGCheckVisitNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=NIGHTCHECK&ControlId=" + txtCheckVisitNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtConductedBy.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");

            }
        }
    }
    #endregion

    /// <summary>
    /// Fills the type of the check visit.
    /// </summary>
    private void FillCheckVisitType()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlCheckVisitType.DataSource = objOperationManagement.NightCheckVisitTypeGet(BaseCompanyCode);
        ddlCheckVisitType.DataTextField = "ItemDesc";
        ddlCheckVisitType.DataValueField = "ItemCode";
        ddlCheckVisitType.DataBind();
        if (ddlCheckVisitType.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "0";
            ddlCheckVisitType.Items.Add(li);
            DisableButton();
        }
    }
    /// <summary>
    /// Makes the temporary night check visit.
    /// </summary>
    private void MakeTempNightCheckVisit()
    {
        DataColumn dCol1 = new DataColumn("ClientCode", typeof(System.String));
        DataColumn dCol2 = new DataColumn("AsmtId", typeof(System.String));         //Modify by  on 24-May-2013 AsmtCode to AsmtId
        DataColumn dCol3 = new DataColumn("LocationCode", typeof(System.String));
        DataColumn dCol4 = new DataColumn("LocationDesc", typeof(System.String));
        DataColumn dCol5 = new DataColumn("ClientName", typeof(System.String));
        DataColumn dCol6 = new DataColumn("AsmtAddress", typeof(System.String));
        DataColumn dCol7 = new DataColumn("EmployeeID", typeof(System.String));
        DataColumn dCol8 = new DataColumn("EmpName", typeof(System.String));
        DataColumn dCol9 = new DataColumn("DesignationDesc", typeof(System.String));
        DataColumn dCol10 = new DataColumn("TimeFrom", typeof(System.DateTime));
        DataColumn dCol11 = new DataColumn("TimeTo", typeof(System.DateTime));
        DataColumn dCol12 = new DataColumn("Observation_Type", typeof(System.String));
        DataColumn dCol13 = new DataColumn("Observation", typeof(System.String));
        DataColumn dCol14 = new DataColumn("Action_Status", typeof(System.String));
        DataColumn dCol15 = new DataColumn("Action_Number", typeof(System.String));
        DataColumn dCol16 = new DataColumn("TempObservation_Type", typeof(System.String));
        DataColumn dCol17 = new DataColumn("RowID", typeof(System.Int32));
        DataColumn dCol18 = new DataColumn("ItemDesc", typeof(System.String));
        dtNightCheckDetail.Columns.Add(dCol1);
        dtNightCheckDetail.Columns.Add(dCol2);
        dtNightCheckDetail.Columns.Add(dCol3);
        dtNightCheckDetail.Columns.Add(dCol4);
        dtNightCheckDetail.Columns.Add(dCol5);
        dtNightCheckDetail.Columns.Add(dCol6);
        dtNightCheckDetail.Columns.Add(dCol7);
        dtNightCheckDetail.Columns.Add(dCol8);
        dtNightCheckDetail.Columns.Add(dCol9);
        dtNightCheckDetail.Columns.Add(dCol10);
        dtNightCheckDetail.Columns.Add(dCol11);
        dtNightCheckDetail.Columns.Add(dCol12);
        dtNightCheckDetail.Columns.Add(dCol13);
        dtNightCheckDetail.Columns.Add(dCol14);
        dtNightCheckDetail.Columns.Add(dCol15);
        dtNightCheckDetail.Columns.Add(dCol16);
        dtNightCheckDetail.Columns.Add(dCol17);
        dtNightCheckDetail.Columns.Add(dCol18);
    }
    /// <summary>
    /// Fillgvs the night check visit.
    /// </summary>
    private void FillgvNightCheckVisit()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dCol1 = new DataColumn("ClientCode", typeof(System.String));
        DataColumn dCol2 = new DataColumn("AsmtId", typeof(System.String));             //Modify by  on 23-May-2013 AsmtCode as AsmtId
        DataColumn dCol3 = new DataColumn("LocationCode", typeof(System.String));
        DataColumn dCol4 = new DataColumn("LocationDesc", typeof(System.String));
        DataColumn dCol5 = new DataColumn("ClientName", typeof(System.String));
        DataColumn dCol6 = new DataColumn("AsmtAddress", typeof(System.String));
        DataColumn dCol7 = new DataColumn("EmployeeID", typeof(System.String));
        DataColumn dCol8 = new DataColumn("EmpName", typeof(System.String));
        DataColumn dCol9 = new DataColumn("DesignationDesc", typeof(System.String));
        DataColumn dCol10 = new DataColumn("TimeFrom", typeof(System.String));
        DataColumn dCol11 = new DataColumn("TimeTo", typeof(System.String));
        DataColumn dCol12 = new DataColumn("Observation_Type", typeof(System.String));
        DataColumn dCol13 = new DataColumn("Observation", typeof(System.String));
        DataColumn dCol14 = new DataColumn("Action_Status", typeof(System.String));
        DataColumn dCol15 = new DataColumn("Action_Number", typeof(System.String));
        DataColumn dCol16 = new DataColumn("TempObservation_Type", typeof(System.String));
        DataColumn dCol17 = new DataColumn("RowID", typeof(System.Int32));
        DataColumn dCol18 = new DataColumn("ItemDesc", typeof(System.String));
        dt.Columns.Add(dCol1);
        dt.Columns.Add(dCol2);
        dt.Columns.Add(dCol3);
        dt.Columns.Add(dCol4);
        dt.Columns.Add(dCol5);
        dt.Columns.Add(dCol6);
        dt.Columns.Add(dCol7);
        dt.Columns.Add(dCol8);
        dt.Columns.Add(dCol9);
        dt.Columns.Add(dCol10);
        dt.Columns.Add(dCol11);
        dt.Columns.Add(dCol12);
        dt.Columns.Add(dCol13);
        dt.Columns.Add(dCol14);
        dt.Columns.Add(dCol15);
        dt.Columns.Add(dCol16);
        dt.Columns.Add(dCol17);
        dt.Columns.Add(dCol18);
        int dtflag;
        dtflag = 1;
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvNightCheckVisit.DataSource = dt;
        gvNightCheckVisit.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvNightCheckVisit.Rows[0].Visible = false;
        }
    }

    #region Gridview Events
    /// <summary>
    /// Handles the RowDataBound event of the gvNightCheckVisit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvNightCheckVisit.Columns[0].Visible = false;
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
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

                }
                DropDownList ddlObservationType = (DropDownList)e.Row.FindControl("ddlObservationType");
                TextBox txtEmployeeNumber = (TextBox)e.Row.FindControl("txtEmployeeNumber");
                TextBox txtObservation = (TextBox)e.Row.FindControl("txtObservation");
                /* Added by  on 23-May-2013 */
                //HiddenField hdClientCode = (HiddenField)e.Row.FindControl("hdClientCode");
                /* End */

                //Modify by  on 2-Jun-2013
                //TextBox txtAsmtCode = (TextBox)e.Row.FindControl("txtAsmtCode");
                DropDownList ddlClientId = (DropDownList)e.Row.FindControl("ddlClientId");
                DropDownList ddlAsmtId = (DropDownList)e.Row.FindControl("ddlAsmtId");
                if (ddlClientId != null && ddlAsmtId != null)
                {
                    FillClientId(ddlClientId, ddlAsmtId);
                }
                //End

                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                ImageButton imgAssignSearchEdit = (ImageButton)e.Row.FindControl("imgAssignSearchEdit");
                //Commented by  on 2-Jun-2013
                //if (imgAssignSearchEdit != null)
                //{
                //    //Commented & Modify by  on 23-May-2013
                //    //imgAssignSearchEdit.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtAsmtCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");
                //    //Commented by  on 2-Jun-2013
                //    //imgAssignSearchEdit.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtAsmtCode.ClientID.ToString() + "&ControlId1=" + hdClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");
                //}
                ImageButton imgEmployeeNumberEdit = (ImageButton)e.Row.FindControl("imgEmployeeNumberEdit");
                if (imgEmployeeNumberEdit != null)
                {
                    imgEmployeeNumberEdit.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");

                }
                if (ddlObservationType != null)
                {
                    ddlObservationType.DataSource = objOperationManagement.NightCheckVisitObservationTypeGet(BaseCompanyCode);
                    ddlObservationType.DataTextField = "ItemDesc";
                    ddlObservationType.DataValueField = "ItemCode";
                    ddlObservationType.DataBind();
                    if (ddlObservationType.Text == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoDataToShow;
                        li.Value = "0";
                        ddlObservationType.Items.Add(li);
                        //DisableButton();
                    }
                }
                //if (txtAsmtCode != null) // Validation Expression not there
                //{
                //    txtAsmtCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //    txtAsmtCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //}
                if (txtObservation != null)
                {
                    txtObservation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtObservation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (txtEmployeeNumber != null)
                {
                    txtEmployeeNumber.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtEmployeeNumber.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
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
                    IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvNightCheckVisit.ShowFooter = false;
            }
            else
            {
                TextBox txtNewEmployeeNumber = (TextBox)e.Row.FindControl("txtNewEmployeeNumber");
                TextBox txtNewObservation = (TextBox)e.Row.FindControl("txtNewObservation");

                ImageButton imgEmployeeNumberFooter = (ImageButton)e.Row.FindControl("imgEmployeeNumberFooter");
                if (imgEmployeeNumberFooter != null)
                {
                    // imgEmployeeNumberFooter.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtNewEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");
                    imgEmployeeNumberFooter.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtNewEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");

                }
                ImageButton imgAssignSearchFooter = (ImageButton)e.Row.FindControl("imgAssignSearchFooter");
                /* Modify by  on 2-Jun-2013
                 /* Added by  on 23-May-2013 */
                // HiddenField hdNewClientCode = (HiddenField)e.Row.FindControl("hdNewClientCode");
                //TextBox txtNewAsmtCode = (TextBox)e.Row.FindControl("txtNewAsmtCode");
                DropDownList ddlNewClientId = (DropDownList)e.Row.FindControl("ddlNewClientId");
                DropDownList ddlNewAsmtId = (DropDownList)e.Row.FindControl("ddlNewAsmtId");
                if (ddlNewClientId != null && ddlNewAsmtId != null)
                {
                    FillClientId(ddlNewClientId, ddlNewAsmtId);
                }
                /* End */
                //Commented by  on 2-Jun-2013
                //if (imgAssignSearchFooter != null)
                //{
                //    //Commented & Modify by  on 23-May-2013
                //    //imgAssignSearchFooter.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtNewAsmtCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");
                //   // imgAssignSearchFooter.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtNewAsmtCode.ClientID.ToString() + "&ControlId1=" + hdNewClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");
                //}
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                DropDownList ddlNewObservationType = (DropDownList)e.Row.FindControl("ddlNewObservationType");


                BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                if (ddlNewObservationType != null)
                {
                    ddlNewObservationType.DataSource = objOperationManagement.NightCheckVisitObservationTypeGet(BaseCompanyCode);
                    ddlNewObservationType.DataTextField = "ItemDesc";
                    ddlNewObservationType.DataValueField = "ItemCode";
                    ddlNewObservationType.DataBind();
                    if (ddlNewObservationType.Text == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoDataToShow;
                        li.Value = "0";
                        ddlNewObservationType.Items.Add(li);
                        //DisableButton();
                    }
                }
                //if (txtNewAsmtCode != null) // Validation Expression not there
                //{
                //    txtNewAsmtCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //    txtNewAsmtCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //}
                if (txtNewObservation != null)
                {
                    txtNewObservation.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewObservation.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
                if (txtNewEmployeeNumber != null)
                {
                    txtNewEmployeeNumber.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewEmployeeNumber.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvNightCheckVisit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int flag = 1;
        DateTime toDate, newToDate;
        //Modify by  on 2-Jun-2013
        //TextBox txtNewClientCode = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewClientCode");
        //TextBox txtNewAsmtCode = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewAsmtCode");
        DropDownList ddlNewClientId = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewClientId");
        DropDownList ddlNewAsmtId = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewAsmtId");

        TextBox txtNewBranchID = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewBranchID");
        TextBox txtNewBranch = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewBranch");
        TextBox txtNewClientName = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewClientName");
        TextBox txtNewAsmtAddress = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewAsmtAddress");
        TextBox txtNewEmployeeNumber = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewEmployeeNumber");
        TextBox txtNewEmployeeName = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewEmployeeName");
        TextBox txtNewDesignation = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewDesignation");
        TextBox txtNewTimeTo = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewTimeTo");
        TextBox txtNewTimeFrom = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewTimeFrom");
        DropDownList ddlNewObservationType = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewObservationType");
        TextBox txtNewObservation = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewObservation");
        ImageButton lbADD = (ImageButton)gvNightCheckVisit.FooterRow.FindControl("lbADD");
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (Status == 1)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                if (txtTimeFrom.Text == "" || txtTimeTo.Text == "")
                {
                    lblErrorMsg.Text = Resources.Resource.FromTimeorToTimenotValid;
                }
                else
                {
                    if (ddlNewObservationType.Text == "")
                    {
                        lbADD.Visible = false;
                    }
                    else
                    {
                        lbADD.Visible = true;
                    }
                    //Added Code for Compare Date add one by  on 31-July-2013
                    if (DateTime.Parse(txtTimeFrom.Text) > DateTime.Parse(txtTimeTo.Text) && DateTime.Parse(txtNewTimeFrom.Text) > DateTime.Parse(txtNewTimeTo.Text))
                    {
                        toDate = DateTime.Parse(txtTimeTo.Text).AddDays(1);
                        newToDate = DateTime.Parse(txtNewTimeTo.Text).AddDays(1);
                    }
                    else
                    {
                        toDate = DateTime.Parse(txtTimeTo.Text);
                        newToDate = DateTime.Parse(txtNewTimeTo.Text);
                    }
                    //End
                    if (DateTime.Parse(txtNewTimeFrom.Text) >= DateTime.Parse(txtTimeFrom.Text) && DateTime.Parse(txtNewTimeFrom.Text) <= toDate && newToDate >= DateTime.Parse(txtTimeFrom.Text) && newToDate <= toDate)
                    {

                        for (int i = 0; i < dtNightCheckDetail.Rows.Count; i++)
                        {
                            Label lblAsmtCode = (Label)gvNightCheckVisit.Rows[i].FindControl("lblAsmtCode");
                            Label lblItemDesc = (Label)gvNightCheckVisit.Rows[i].FindControl("lblItemDesc");
                            Label lblEmployeeID = (Label)gvNightCheckVisit.Rows[i].FindControl("lblEmployeeID");
                            if (lblAsmtCode.Text == ddlNewAsmtId.SelectedItem.Value && lblItemDesc.Text == ddlNewObservationType.SelectedValue.ToString() && lblEmployeeID.Text == txtNewEmployeeNumber.Text)
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
                        if (flag == 1)
                        {
                            DataRow dr = dtNightCheckDetail.NewRow();
                            //Modify by  on 2-Jun-2013
                           // dr[0] = txtNewAsmtCode.Text;
                           // dr[3] = txtNewClientCode.Text;

                            dr[0] = ddlNewClientId.SelectedItem.Value;
                            dr[1] = ddlNewAsmtId.SelectedItem.Value;
                            dr[2] = txtNewBranchID.Text;
                            dr[3] = txtNewBranch.Text;
                            dr[4] = txtNewClientName.Text;
                            dr[5] = txtNewAsmtAddress.Text;
                            dr[6] = txtNewEmployeeNumber.Text;
                            dr[7] = txtNewEmployeeName.Text;
                            dr[8] = txtNewDesignation.Text;
                            dr[9] = DateTime.Parse(txtNewTimeFrom.Text).ToShortTimeString();
                            dr[10] = DateTime.Parse(txtNewTimeTo.Text).ToShortTimeString();
                            dr[11] = ddlNewObservationType.SelectedItem.Text.ToString();
                            dr[12] = txtNewObservation.Text;
                            dr[13] = "";
                            dr[14] = "";
                            dr[15] = ddlNewObservationType.SelectedValue.ToString();
                            dr[16] = 0;
                            dr[17] = ddlNewObservationType.SelectedValue.ToString();
                            dtNightCheckDetail.Rows.Add(dr);
                            gvNightCheckVisit.DataSource = dtNightCheckDetail;
                            gvNightCheckVisit.DataBind();
                        }
                    }
                    else
                    {
                        if (DateTime.Parse(txtNewTimeFrom.Text) < DateTime.Parse(txtTimeFrom.Text) || DateTime.Parse(txtNewTimeFrom.Text) > DateTime.Parse(txtTimeTo.Text))
                        {
                            txtNewTimeFrom.BackColor = System.Drawing.Color.Aqua;
                            txtNewTimeTo.BackColor = System.Drawing.Color.Empty;
                            ToolkitScriptManager2.SetFocus(txtNewTimeFrom);
                        }
                        else if (DateTime.Parse(txtNewTimeTo.Text) < DateTime.Parse(txtTimeFrom.Text) || DateTime.Parse(txtNewTimeTo.Text) > DateTime.Parse(txtTimeTo.Text))
                        {
                            txtNewTimeFrom.BackColor = System.Drawing.Color.Empty;
                            txtNewTimeTo.BackColor = System.Drawing.Color.Aqua;
                            ToolkitScriptManager2.SetFocus(txtNewTimeTo);
                        }
                    }
                }
            }
            if (e.CommandName.Equals("Reset"))
            {
                txtNewBranchID.Text = "";
               // txtNewAsmtCode.Text = "";
                txtNewBranch.Text = "";
               // txtNewClientCode.Text = "";
                txtNewClientName.Text = "";
                txtNewAsmtAddress.Text = "";
                txtNewEmployeeNumber.Text = "";
                txtNewEmployeeName.Text = "";
                txtNewDesignation.Text = "";
                txtNewTimeTo.Text = "";
                txtNewTimeFrom.Text = "";
                txtNewObservation.Text = "";
            }
        }
        else if (Status == 0)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                if (txtTimeFrom.Text == "" || txtTimeTo.Text == "")
                {
                    lblErrorMsg.Text = Resources.Resource.FromTimeorToTimenotValid;
                }
                else
                {
                    //Added Code for Compare Date add one by  on 31-July-2013
                    if (DateTime.Parse(txtTimeFrom.Text) > DateTime.Parse(txtTimeTo.Text) && DateTime.Parse(txtNewTimeFrom.Text) > DateTime.Parse(txtNewTimeTo.Text))
                    {
                        toDate = DateTime.Parse(txtTimeTo.Text).AddDays(1);
                        newToDate = DateTime.Parse(txtNewTimeTo.Text).AddDays(1);
                    }
                    else
                    {
                        toDate = DateTime.Parse(txtTimeTo.Text);
                        newToDate = DateTime.Parse(txtNewTimeTo.Text);
                    }
                    //End
                    if (DateTime.Parse(txtNewTimeFrom.Text) >= DateTime.Parse(txtTimeFrom.Text) && DateTime.Parse(txtNewTimeFrom.Text) <= toDate && newToDate >= DateTime.Parse(txtTimeFrom.Text) && newToDate <= toDate)
                    {
                        gvNightCheckVisit.EditIndex = -1;
                        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
                        DataSet ds = new DataSet();
                        //Modify by  on 2-Jun-2013
                        ds = objOperationManagement.NightCheckVisitDetailInsert(txtNewEmployeeNumber.Text,ddlNewClientId.SelectedItem.Value, ddlNewAsmtId.SelectedItem.Value, txtCheckVisitNumber.Text, BaseUserID, DateTime.Parse(txtNewTimeFrom.Text).ToShortTimeString(), DateTime.Parse(txtNewTimeTo.Text).ToShortTimeString(), ddlNewObservationType.SelectedValue.ToString(), txtNewObservation.Text, "", "");
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
                    }
                    else
                    {
                        if (DateTime.Parse(txtNewTimeFrom.Text) < DateTime.Parse(txtTimeFrom.Text) || DateTime.Parse(txtNewTimeFrom.Text) > DateTime.Parse(txtTimeTo.Text))
                        {
                            txtNewTimeFrom.BackColor = System.Drawing.Color.Aqua;
                            txtNewTimeTo.BackColor = System.Drawing.Color.Empty;
                            ToolkitScriptManager2.SetFocus(txtNewTimeFrom);
                        }
                        else if (DateTime.Parse(txtNewTimeTo.Text) < DateTime.Parse(txtTimeFrom.Text) || DateTime.Parse(txtNewTimeTo.Text) > DateTime.Parse(txtTimeTo.Text))
                        {
                            txtNewTimeFrom.BackColor = System.Drawing.Color.Empty;
                            txtNewTimeTo.BackColor = System.Drawing.Color.Aqua;
                            ToolkitScriptManager2.SetFocus(txtNewTimeTo);
                        }
                    }
                }
            }
            if (e.CommandName.Equals("Reset"))
            {
                txtNewBranchID.Text = "";
               // txtNewAsmtCode.Text = "";
                txtNewBranch.Text = "";
               // txtNewClientCode.Text = "";
                txtNewClientName.Text = "";
                txtNewAsmtAddress.Text = "";
                txtNewEmployeeNumber.Text = "";
                txtNewEmployeeName.Text = "";
                txtNewDesignation.Text = "";
                txtNewTimeTo.Text = "";
                txtNewTimeFrom.Text = "";
                txtNewObservation.Text = "";
            }
        }
        switch (e.CommandArgument.ToString())
        {
            case "First":
                gvNightCheckVisit.PageIndex = 0;
                break;
            case "Prev":
                index = 1;
                break;
            case "Next":
                index = 0;
                break;
            case "Last":
                gvNightCheckVisit.PageIndex = gvNightCheckVisit.PageCount;
                break;
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvNightCheckVisit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (Status == 1)
        {
            gvNightCheckVisit.EditIndex = e.NewEditIndex;
            gvNightCheckVisit.DataSource = dtNightCheckDetail;
            gvNightCheckVisit.DataBind();
            btnAuthorize.Enabled = false;
            btnUpdate.Enabled = false;
        }
        else if (Status == 0)
        {
            gvNightCheckVisit.EditIndex = e.NewEditIndex;
            FillgvNightCheckVisitOnEdit(e.NewEditIndex, txtCheckVisitNumber.Text);
            //FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
            btnAuthorize.Enabled = false;
            btnUpdate.Enabled = false;
        }
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvNightCheckVisit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (Status == 1)
        {
            gvNightCheckVisit.EditIndex = -1;
            gvNightCheckVisit.DataSource = dtNightCheckDetail;
            gvNightCheckVisit.DataBind();
            btnAuthorize.Enabled = true;
            btnUpdate.Enabled = true;
        }
        else if (Status == 0)
        {
            gvNightCheckVisit.EditIndex = -1;
            FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
            btnAuthorize.Enabled = true;
            btnUpdate.Enabled = true;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvNightCheckVisit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DateTime toDate,newToDate;
        TextBox txtBranchID = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtBranchID");

        TextBox txtBranch = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtBranch");
        //Modify by  on 2-Jun-2013
        //TextBox txtClientCode = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtClientCode");
        //TextBox txtAsmtCode = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtAsmtCode");
        DropDownList ddlClientId = (DropDownList)gvNightCheckVisit.Rows[e.RowIndex].FindControl("ddlClientId");
        DropDownList ddlAsmtId = (DropDownList)gvNightCheckVisit.Rows[e.RowIndex].FindControl("ddlAsmtId");
        //End
        TextBox txtClientName = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtClientName");
        TextBox txtAsmtAddress = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtAsmtAddress");
        TextBox txtEmployeeNumber = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtEmployeeNumber");
        TextBox txtEmployeeName = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtEmployeeName");
        TextBox txtDesignation = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtDesignation");
        TextBox gvtxtTimeTo = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtTimeTo");
        TextBox gvtxtTimeFrom = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtTimeFrom");
        DropDownList ddlObservationType = (DropDownList)gvNightCheckVisit.Rows[e.RowIndex].FindControl("ddlObservationType");
        TextBox txtObservation = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtObservation");
        TextBox txtActionStatus = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtActionStatus");
        TextBox txtActionNumber = (TextBox)gvNightCheckVisit.Rows[e.RowIndex].FindControl("txtActionNumber");
        ImageButton lbADD = (ImageButton)gvNightCheckVisit.Rows[e.RowIndex].FindControl("ImgbtnUpdate");
        Label lblRowIDEdit = (Label)gvNightCheckVisit.Rows[e.RowIndex].FindControl("lblRowIDEdit");

        if (Status == 1)
        {
            //Modify by  on 2-Jun-2013

            dtNightCheckDetail.Rows[e.RowIndex][0] = ddlClientId.SelectedItem.Value;
            dtNightCheckDetail.Rows[e.RowIndex][1] = ddlAsmtId.SelectedItem.Value;
            dtNightCheckDetail.Rows[e.RowIndex][2] = txtBranchID.Text;
            dtNightCheckDetail.Rows[e.RowIndex][3] = txtBranch.Text;
            dtNightCheckDetail.Rows[e.RowIndex][4] = txtClientName.Text;
            dtNightCheckDetail.Rows[e.RowIndex][5] = txtAsmtAddress.Text;
            dtNightCheckDetail.Rows[e.RowIndex][6] = txtEmployeeNumber.Text;
            dtNightCheckDetail.Rows[e.RowIndex][7] = txtEmployeeName.Text;
            dtNightCheckDetail.Rows[e.RowIndex][8] = txtDesignation.Text;
            dtNightCheckDetail.Rows[e.RowIndex][9] = txtTimeFrom.Text;
            dtNightCheckDetail.Rows[e.RowIndex][10] = txtTimeTo.Text;
            dtNightCheckDetail.Rows[e.RowIndex][11] = ddlObservationType.SelectedItem.Text.ToString();
            dtNightCheckDetail.Rows[e.RowIndex][12] = txtObservation.Text;
            dtNightCheckDetail.Rows[e.RowIndex][13] = "";
            dtNightCheckDetail.Rows[e.RowIndex][14] = "";
            dtNightCheckDetail.Rows[e.RowIndex][15] = ddlObservationType.SelectedValue.ToString();
            dtNightCheckDetail.Rows[e.RowIndex][16] = 0;
            dtNightCheckDetail.Rows[e.RowIndex][17] = ddlObservationType.SelectedValue.ToString();

            gvNightCheckVisit.EditIndex = -1;
            gvNightCheckVisit.DataSource = dtNightCheckDetail;
            gvNightCheckVisit.DataBind();
            btnAuthorize.Enabled = true;
            btnUpdate.Enabled = true;
        }
        else if (Status == 0)
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            //Added Code for Compare Date add one by  on 31-July-2013
            if (DateTime.Parse(txtTimeFrom.Text) > DateTime.Parse(txtTimeTo.Text) && DateTime.Parse(gvtxtTimeFrom.Text) > DateTime.Parse(gvtxtTimeTo.Text))
            {
                toDate = DateTime.Parse(txtTimeTo.Text).AddDays(1);
                newToDate = DateTime.Parse(gvtxtTimeTo.Text).AddDays(1);
            }
            else
            {
                toDate = DateTime.Parse(txtTimeTo.Text);
                newToDate = DateTime.Parse(gvtxtTimeTo.Text);
            }
            //End
            if (DateTime.Parse(gvtxtTimeFrom.Text) >= DateTime.Parse(txtTimeFrom.Text) && DateTime.Parse(gvtxtTimeFrom.Text) <= toDate && newToDate >= DateTime.Parse(txtTimeFrom.Text) && newToDate <= toDate)
            {
                //Modify by  on 2-Jun-2013
                //ds = objOperationManagement.NightCheckVisitDetailUpdate(txtEmployeeNumber.Text, txtClientCode.Text, txtAsmtCode.Text, txtCheckVisitNumber.Text, BaseUserID, DateTime.Parse(txtTimeFrom.Text).ToShortTimeString(), DateTime.Parse(txtTimeTo.Text).ToShortTimeString(), ddlObservationType.SelectedValue.ToString(), txtObservation.Text, "", "", lblRowIDEdit.Text);
                ds = objOperationManagement.NightCheckVisitDetailUpdate(txtEmployeeNumber.Text, ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, txtCheckVisitNumber.Text, BaseUserID, DateTime.Parse(gvtxtTimeFrom.Text).ToShortTimeString(), DateTime.Parse(gvtxtTimeTo.Text).ToShortTimeString(), ddlObservationType.SelectedValue.ToString(), txtObservation.Text, "", "", lblRowIDEdit.Text);
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    gvNightCheckVisit.EditIndex = -1;
                    FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
                    btnAuthorize.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
            else
            {
                if (DateTime.Parse(gvtxtTimeFrom.Text) < DateTime.Parse(txtTimeFrom.Text) || DateTime.Parse(gvtxtTimeFrom.Text) > DateTime.Parse(txtTimeTo.Text))
                {
                    gvtxtTimeFrom.BackColor = System.Drawing.Color.Aqua;
                    gvtxtTimeTo.BackColor = System.Drawing.Color.Empty;
                }
                else if (DateTime.Parse(gvtxtTimeTo.Text) < DateTime.Parse(txtTimeFrom.Text) || DateTime.Parse(gvtxtTimeTo.Text) > DateTime.Parse(txtTimeTo.Text))
                {
                    gvtxtTimeFrom.BackColor = System.Drawing.Color.Empty;
                    gvtxtTimeTo.BackColor = System.Drawing.Color.Aqua;
                }
            }
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvNightCheckVisit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvNightCheckVisit.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvNightCheckVisit.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvNightCheckVisit.PageIndex = CurrentIndex;
            }
            index = -1;
        }
        else if (index == 0)
        {
            gvNightCheckVisit.PageIndex = CurrentIndex + 1;
            index = -1;
        }
        else
        {
            gvNightCheckVisit.PageIndex = e.NewPageIndex;
        }
        gvNightCheckVisit.EditIndex = -1;
        // To Fill gridview based on the status
        if (Status == 1)
        {
            gvNightCheckVisit.DataSource = dtNightCheckDetail;
            gvNightCheckVisit.DataBind();
        }
        else if (Status == 0)
        {
            FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvNightCheckVisit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblRowID = (Label)gvNightCheckVisit.Rows[e.RowIndex].FindControl("lblRowID");
        if (Status == 1)
        {
            dtNightCheckDetail.Rows.RemoveAt(e.RowIndex);
            gvNightCheckVisit.DataSource = dtNightCheckDetail;
            gvNightCheckVisit.DataBind();
            if (dtNightCheckDetail.Rows.Count == 0)
            {
                FillgvNightCheckVisit();
            }
        }
        else if (Status == 0)
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            ds = objOperationManagement.NightCheckVisitDetailDelete(lblRowID.Text);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
        }

    }
    #endregion

    #region Function related to textbox text change event including gridview textbox
    /// <summary>
    /// Handles the TextChanged event of the txtConductedBy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtConductedBy_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtConductedBy.Text, BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            txtEmployeeDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            //Commented by  on 2-Jun-2013
            //TextBox txtNewAsmtCode = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewAsmtCode");
            //ToolkitScriptManager2.SetFocus(txtNewAsmtCode);
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
            DisableButton();
            txtEmployeeName.Text = "";
            txtEmployeeDesignation.Text = "";
        }
    }

    #region Commented Code by  on 2-Jun-2013
    //protected void txtNewAsmtCode_TextChanged(object sender, EventArgs e)
    //{
    //    System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
    //    TextBox objTextBox = (TextBox)sender;
    //    GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
    //    TextBox txtBranchID = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewBranchID");
    //    TextBox txtAsmtCode = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewAsmtCode");
    //    TextBox txtBranch = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewBranch");
    //    TextBox txtClientCode = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewClientCode");
    //    TextBox txtClientName = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewClientName");
    //    TextBox txtAsmtAddress = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewAsmtAddress");
    //    TextBox txtEmployeeNumber = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewEmployeeNumber");
    //    TextBox txtEmployeeName = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewEmployeeName");
    //    TextBox txtDesignation = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewDesignation");
    //    /* Added by  on 23-May-2013 */
    //    HiddenField hdNewClientCode = (HiddenField)gvNightCheckVisit.FooterRow.FindControl("hdNewClientCode");
    //    /* End */
    //    ToolkitScriptManager2.SetFocus(txtEmployeeNumber);
    //    ImageButton IMGButton = (ImageButton)gvNightCheckVisit.FooterRow.FindControl("lbADD");
    //    //Commented & Modify by  on 23-May-2013
    //    //FillAsmtDetail(row, txtBranchID, txtBranch, txtClientCode, txtClientName, txtAsmtAddress, txtAsmtCode, IMGButton, txtEmployeeNumber, txtEmployeeName, txtDesignation);
    //    FillAsmtDetail(row, txtBranchID, txtBranch, hdNewClientCode, txtClientCode, txtClientName, txtAsmtAddress, txtAsmtCode, IMGButton, txtEmployeeNumber, txtEmployeeName, txtDesignation);
    //}
    //protected void txtAsmtCode_TextChanged(object sender, EventArgs e)
    //{
    //    TextBox objTextBox = (TextBox)sender;
    //    GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
    //    TextBox txtBranchID = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtBranchID");
    //    TextBox txtAsmtCode = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtAsmtCode");
    //    TextBox txtBranch = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtBranch");
    //    TextBox txtClientCode = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtClientCode");
    //    TextBox txtClientName = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtClientName");
    //    TextBox txtAsmtAddress = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtAsmtAddress");
    //    TextBox txtEmployeeNumber = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtEmployeeNumber");
    //    TextBox txtEmployeeName = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtEmployeeName");
    //    TextBox txtDesignation = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtDesignation");
    //    ImageButton IMGButton = (ImageButton)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
    //    /* Added by  on 23-May-2013 */
    //    HiddenField hdClientCode = (HiddenField)gvNightCheckVisit.Rows[row.RowIndex].FindControl("hdClientCode");
    //    txtAsmtCode.Text = hdClientCode.Value;
    //    /* End */

    //    //Commented & Modify by  on 23-May-2013
    //    //FillAsmtDetail(row, txtBranchID, txtBranch, txtClientCode, txtClientName, txtAsmtAddress, txtAsmtCode, IMGButton, txtEmployeeNumber, txtEmployeeName, txtDesignation);
    //    FillAsmtDetail(row, txtBranchID, txtBranch, hdClientCode, txtClientCode, txtClientName, txtAsmtAddress, txtAsmtCode, IMGButton, txtEmployeeNumber, txtEmployeeName, txtDesignation);
    //}
    #endregion

    /// <summary>
    /// Handles the TextChanged event of the txtNewEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewEmployeeNumber_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtEmployeeNumber = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewEmployeeNumber");
        TextBox txtEmployeeName = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewEmployeeName");
        TextBox txtDesignation = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewDesignation");
        ImageButton IMGButton = (ImageButton)gvNightCheckVisit.FooterRow.FindControl("lbADD");
        TextBox txtNewTimeFrom = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewTimeFrom");
        //Modify by  on 2-Jun-2013
        //TextBox txtAsmtCode = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewAsmtCode");
        DropDownList ddlNewClientId = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewClientId");
        DropDownList ddlNewAsmtId = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewAsmtId");
        //End
        ToolkitScriptManager2.SetFocus(txtNewTimeFrom);
        FillEmployeeDetail(row, txtEmployeeNumber, txtEmployeeName, txtDesignation, IMGButton, ddlNewClientId, ddlNewAsmtId);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeNumber_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtEmployeeNumber = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtEmployeeNumber");
        TextBox txtEmployeeName = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtEmployeeName");
        TextBox txtDesignation = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtDesignation");
        ImageButton IMGButton = (ImageButton)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        //Modify by  on 2-Jun-2013
        //TextBox txtAsmtCode = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtAsmtCode");
        DropDownList ddlClientId = (DropDownList)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ddlClientId");
        DropDownList ddlAsmtId = (DropDownList)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ddlAsmtId");
        //End
        FillEmployeeDetail(row, txtEmployeeNumber, txtEmployeeName, txtDesignation, IMGButton, ddlClientId, ddlAsmtId);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtCheckVisitNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtCheckVisitNumber_TextChanged(object sender, EventArgs e)
    {
        if (txtCheckVisitNumber.Text != "")
        {
            Status = 0;
            FillDetails();
            if (txtConductedBy.Text != "")
            {
                //Modify by  on 2-Jun-2013
                FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
               // FillgvNightCheckVisitOnEdit(rowNumber, txtCheckVisitNumber.Text);
                HideButton();
                txtCheckVisitNumber.Enabled = true;
                txtConductedBy_TextChanged(sender, e);

                if (lblCheckVisitStatus.Text == Resources.Resource.Fresh)
                {
                    gvNightCheckVisit.Columns[0].Visible = true;
                    if (IsWriteAccess == true)
                    {
                        gvNightCheckVisit.FooterRow.Visible = true;
                    }
                }
                if (lblCheckVisitStatus.Text == Resources.Resource.Authorized)
                {
                    DisableFields();
                    gvNightCheckVisit.Columns[0].Visible = false;
                    if (IsWriteAccess == true)
                    {
                        gvNightCheckVisit.FooterRow.Visible = true;
                    }
                }
                if (lblCheckVisitStatus.Text == Resources.Resource.Amend)
                {
                    gvNightCheckVisit.Columns[0].Visible = true;
                    if (IsWriteAccess == true)
                    {
                        gvNightCheckVisit.FooterRow.Visible = true;
                    }
                    EnableFields();
                }
                HideButtonBasedOnStatus();
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            }
        }
    }
    #endregion

    //Modify By  on 2-Jun-2013
    /// <summary>
    /// Fills the employee detail.
    /// </summary>
    /// <param name="row">The row.</param>
    /// <param name="txtEmployeeNumber">The text employee number.</param>
    /// <param name="txtEmployeeName">Name of the text employee.</param>
    /// <param name="txtDesignation">The text designation.</param>
    /// <param name="IMGButton">The img button.</param>
    /// <param name="ddlClientId">The DDL client identifier.</param>
    /// <param name="ddlAsmtId">The DDL asmt identifier.</param>
    private void FillEmployeeDetail(GridViewRow row, TextBox txtEmployeeNumber, TextBox txtEmployeeName, TextBox txtDesignation, ImageButton IMGButton, DropDownList ddlClientId, DropDownList ddlAsmtId)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        //Modify By  on 2-Jun-2013
        //if (txtAsmtCode.Text != "")
        if (ddlClientId.SelectedItem != null && ddlAsmtId.SelectedItem != null)
        {
            //txtAsmtCode.BackColor = System.Drawing.Color.Empty;
            //Commented & Modify by  on 23-May-2013
            // ds = objHRManagement.EmployeeDetailsGet(txtEmployeeNumber.Text, BaseLocationAutoID, txtAsmtCode.Text);
            ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeNumber.Text, BaseCompanyCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
                {
                    txtEmployeeNumber.BackColor = System.Drawing.Color.Empty;
                    IMGButton.Visible = true;
                    txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    txtDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
                }
                else
                {
                    IMGButton.Visible = false;
                    lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
                    txtEmployeeNumber.BackColor = System.Drawing.Color.Aqua;
                    ToolkitScriptManager2.SetFocus(txtEmployeeNumber);
                    txtEmployeeName.Text = "";
                    txtDesignation.Text = "";
                }
            }
            else
            {
                IMGButton.Visible = false;
                lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
                txtEmployeeNumber.BackColor = System.Drawing.Color.Aqua;
                ToolkitScriptManager2.SetFocus(txtEmployeeNumber);
                txtEmployeeName.Text = "";
                txtDesignation.Text = "";
            }
        }
        else
        {
            lblErrorMsg.Text = "Asmt Code field is left blank";
            //Commented by  on 2-Jun-2013
            //ToolkitScriptManager2.SetFocus(txtAsmtCode);
            //txtAsmtCode.BackColor = System.Drawing.Color.Aqua;
        }
    }
    //Commented & Modify by  on 23-May-2013
    /// <summary>
    /// Fills the asmt detail.
    /// </summary>
    /// <param name="row">The row.</param>
    /// <param name="txtBranchID">The text branch identifier.</param>
    /// <param name="txtBranch">The text branch.</param>
    /// <param name="ddlClientId">The DDL client identifier.</param>
    /// <param name="txtClientName">Name of the text client.</param>
    /// <param name="txtAsmtAddress">The text asmt address.</param>
    /// <param name="ddlAsmtId">The DDL asmt identifier.</param>
    /// <param name="IMGButton">The img button.</param>
    /// <param name="txtEmployeeNumber">The text employee number.</param>
    /// <param name="txtEmployeeName">Name of the text employee.</param>
    /// <param name="txtDesignation">The text designation.</param>
    private void FillAsmtDetail(GridViewRow row, TextBox txtBranchID, TextBox txtBranch, DropDownList ddlClientId, TextBox txtClientName, TextBox txtAsmtAddress, DropDownList ddlAsmtId, ImageButton IMGButton, TextBox txtEmployeeNumber, TextBox txtEmployeeName, TextBox txtDesignation)
    //private void FillAsmtDetail(GridViewRow row, TextBox txtBranchID, TextBox txtBranch, HiddenField hdClientCode, TextBox txtClientCode, TextBox txtClientName, TextBox txtAsmtAddress, TextBox txtAsmtCode, ImageButton IMGButton, TextBox txtEmployeeNumber, TextBox txtEmployeeName, TextBox txtDesignation)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        //Commented & Modify by  on 23-May-2013
        //ds = objOperationManagement.AsmtDetailGetAll(txtAsmtCode.Text, BaseCompanyCode);
        // ds = objOperationManagement.AsmtIncidentDetailGet(hdClientCode.Value, txtAsmtCode.Text, BaseLocationAutoID);
        ds = objOperationManagement.AsmtIncidentDetailGet(ddlClientId.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                if (!string.IsNullOrEmpty(txtDate.Text))
                {
                    if (DateTime.Parse(ds.Tables[0].Rows[0]["AsmtStartDate"].ToString()) < DateTime.Parse(txtDate.Text))
                    {
                        //Commented by  on 2-Jun-2013
                        //txtAsmtCode.BackColor = System.Drawing.Color.Empty;
                        //End
                        //EnableFields();
                        EnableButton();
                        txtBranchID.Text = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                        txtBranch.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
                        //Commented by  on 2-Jun-2013
                        //txtClientCode.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                        txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                        txtAsmtAddress.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
                        txtEmployeeNumber.Text = "";
                        txtEmployeeName.Text = "";
                        txtDesignation.Text = "";
                    }
                    else
                    {
                        lblErrorMsg.Text = "Night Check and Visit Date should be between Assignment start date and current Date";
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    btnSave.Enabled = false;
                    FillAsmt(ddlClientId, ddlAsmtId);
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                DisableButton();
                //Added by  on 2-Jun-2013
                btnSave.Enabled = false;
                //Commented by  on 2-Jun-2013
                //ToolkitScriptManager2.SetFocus(txtAsmtCode);
                //txtAsmtCode.Text = "";
                txtBranch.Text = "";
                txtBranchID.Text = "";
                //txtClientCode.Text = "";
                txtClientName.Text = "";
                txtAsmtAddress.Text = "";
                //txtAsmtCode.BackColor = System.Drawing.Color.Aqua;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            dtNightCheckDetail.Clear();
            DisableButton();
            //Commented by  on 2-Jun-2013
            //ToolkitScriptManager2.SetFocus(txtAsmtCode);
            //txtAsmtCode.Text = "";
            txtBranch.Text = "";
            txtBranchID.Text = "";
            //txtClientCode.Text = "";
            txtClientName.Text = "";
            txtAsmtAddress.Text = "";
            //txtAsmtCode.BackColor = System.Drawing.Color.Aqua;
        }
    }

    /// <summary>
    /// Hides the button.
    /// </summary>
    private void HideButton()
    {
        btnAuthorize.Visible = false;
        btnAddNew.Visible = false;
        btnCancel.Visible = false;
        btnEdit.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }
    /// <summary>
    /// Shows the button.
    /// </summary>
    private void ShowButton()
    {
        btnAuthorize.Visible = true;
        btnAddNew.Visible = true;
        btnCancel.Visible = true;
        btnEdit.Visible = true;
        btnSave.Visible = true;
        btnUpdate.Visible = true;
    }
    /// <summary>
    /// Disables the button.
    /// </summary>
    private void DisableButton()
    {
        btnAuthorize.Enabled = false;
        btnAddNew.Enabled = false;
        btnCancel.Enabled = false;
        btnEdit.Enabled = false;
        btnSave.Enabled = false;
        btnUpdate.Enabled = false;
    }
    /// <summary>
    /// Enables the button.
    /// </summary>
    private void EnableButton()
    {
        btnAuthorize.Enabled = true;
        btnAddNew.Enabled = true;
        btnCancel.Enabled = true;
        btnEdit.Enabled = true;
        btnSave.Enabled = true;
        btnUpdate.Enabled = true;
    }
    /// <summary>
    /// Disables the fields.
    /// </summary>
    private void DisableFields()
    {
        ddlCheckVisitType.Enabled = false;
        txtConductedBy.Enabled = false;
        txtDate.Enabled = false;
        txtTimeFrom.Enabled = false;
        txtTimeTo.Enabled = false;
    }
    /// <summary>
    /// Enables the fields.
    /// </summary>
    private void EnableFields()
    {
        ddlCheckVisitType.Enabled = true;
        txtConductedBy.Enabled = true;
        txtDate.Enabled = true;
        txtTimeFrom.Enabled = true;
        txtTimeTo.Enabled = true;
    }
    /// <summary>
    /// Clears the fields.
    /// </summary>
    private void ClearFields()
    {
        txtDate.Text = "";
        txtEmployeeDesignation.Text = "";
        txtConductedBy.Text = "";
        txtEmployeeName.Text = "";
        txtTimeFrom.Text = "";
        txtTimeTo.Text = "";
    }

    #region function related to button click events
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            int flag = 1;
            DateTime dt = DateTime.Parse(txtDate.Text.ToString());
            if (dt <= DateTime.Parse(DateFormat(DateTime.Now.ToString())))
            {
                if (dtNightCheckDetail.Rows.Count == 0)
                {
                    lblErrorMsg.Text = Resources.Resource.NightCheckDetailsCannotbeleftblank;
                    flag = 0;
                }
                if (flag == 1)
                {
                    ds = objOperationManagement.NightCheckVisitInsert(ddlCheckVisitType.SelectedValue.ToString(), Resources.Resource.Fresh, DateTime.Parse(txtDate.Text), DateTime.Parse(txtTimeFrom.Text).ToShortTimeString(), DateTime.Parse(txtTimeTo.Text).ToShortTimeString(), txtConductedBy.Text, dtNightCheckDetail, BaseLocationAutoID, BaseUserID);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                    {
                        Status = 0;
                        txtCheckVisitNumber.Text = ds.Tables[0].Rows[0]["CheckVisitNumber"].ToString();
                        lblCheckVisitStatus.Text = Resources.Resource.Fresh;
                        HideButton();
                        HideButtonBasedOnStatus();
                        FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
                    }
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.DatecannotbegreaterthanCurrentdate;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = "Not Able to Connect with Database";
        }
    }
    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        dtNightCheckDetail.Clear();
        gvNightCheckVisit.EditIndex = -1;
        Status = 1;
        ClearFields();
        txtCheckVisitNumber.Text = "";
        lblCheckVisitStatus.Text = "";
        gvNightCheckVisit.Columns[0].Visible = true;
        HideButton();
        EnableFields();
        btnSave.Visible = true;
        ddlCheckVisitType.Enabled = true;
        FillgvNightCheckVisit();
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        if (count != 0)
        {
            if (DateTime.Parse(txtDate.Text.ToString()) <= DateTime.Parse(DateFormat(DateTime.Now.ToString())))
            {
                if (CompareGridTimeWithHeaderTime() == true)
                {
                    gvNightCheckVisit.EditIndex = -1;
                    ds = objOperationManagement.NightCheckVisitUpdate(DateTime.Parse(txtDate.Text), DateTime.Parse(txtTimeFrom.Text).ToShortTimeString(), DateTime.Parse(txtTimeTo.Text).ToShortTimeString(), txtConductedBy.Text, BaseLocationAutoID, BaseUserID, txtCheckVisitNumber.Text, ddlCheckVisitType.SelectedValue.ToString());
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                    {
                        //DisableFields();
                        HideButton();
                        HideButtonBasedOnStatus();
                        FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
                        // gvNightCheckVisit.FooterRow.Visible = false;
                        //gvNightCheckVisit.Columns[0].Visible = false;
                        if (lblCheckVisitStatus.Text == Resources.Resource.Fresh)
                        {
                            gvNightCheckVisit.Columns[0].Visible = true;
                            gvNightCheckVisit.FooterRow.Visible = true;
                        }
                        if (lblCheckVisitStatus.Text == Resources.Resource.Authorized)
                        {
                            gvNightCheckVisit.Columns[0].Visible = false;
                            gvNightCheckVisit.FooterRow.Visible = false;
                        }
                        if (lblCheckVisitStatus.Text == Resources.Resource.Amend)
                        {
                            gvNightCheckVisit.Columns[0].Visible = true;
                            gvNightCheckVisit.FooterRow.Visible = true;
                            EnableFields();
                        }
                    }
                }
                else
                {
                    if (gvNightCheckVisit.EditIndex != -1)
                    {
                        lblErrorMsg.Text = Resources.Resource.FromTimeorToTimenotValid;
                        txtTimeFrom.Focus();
                        gvNightCheckVisit.UpdateRow(gvNightCheckVisit.EditIndex, true);
                    }
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.DatecannotbegreaterthanCurrentdate;
                txtDate.Focus();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NightCheckDetailsCannotbeleftblank;
        }
    }

    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        gvNightCheckVisit.EditIndex = -1;
        FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ////
        if (count != 0)
        {
            if (DateTime.Parse(txtDate.Text.ToString()) <= DateTime.Parse(DateFormat(DateTime.Now.ToString())))
            {
                if (CompareGridTimeWithHeaderTime() == true)
                {
                    ds = objOperationManagement.NightCheckVisitAuthorize(txtCheckVisitNumber.Text, Resources.Resource.Authorized, BaseLocationAutoID, BaseUserID);
                    if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                    {
                        string strCheckVisitNumber;
                        strCheckVisitNumber = txtCheckVisitNumber.Text;
                        txtCheckVisitNumber.Text = "";
                        txtCheckVisitNumber.Text = strCheckVisitNumber;
                        txtCheckVisitNumber_TextChanged(sender, e);
                        lblCheckVisitStatus.Text = Resources.Resource.Authorized;
                        btnAuthorize.Visible = false;
                        HideButtonBasedOnStatus();
                        gvNightCheckVisit.Columns[0].Visible = false;
                        gvNightCheckVisit.FooterRow.Visible = false;
                        DisableFields();

                        for (int i = 0; i < gvNightCheckVisit.Rows.Count; i++)
                        {
                            Label lblActionNumber = (Label)gvNightCheckVisit.Rows[i].FindControl("lblActionNumber");
                            Label lblActionStatus = (Label)gvNightCheckVisit.Rows[i].FindControl("lblActionStatus");
                            Label lblItemDesc = (Label)gvNightCheckVisit.Rows[i].FindControl("lblItemDesc");
                            Label lblRowID = (Label)gvNightCheckVisit.Rows[i].FindControl("lblRowID");
                            if (lblItemDesc.Text == "94")
                            {
                                //gvNightCheckVisit.Rows[i].BackColor = System.Drawing.Color.Aqua;
                                lblActionStatus.Text = Resources.Resource.Completed;
                                objOperationManagement.NightCheckVisitActionStatusUpdate(lblRowID.Text, Resources.Resource.Completed);
                            }
                            else
                            {
                                if (lblActionNumber.Text == "")
                                {
                                    lblActionStatus.Text = Resources.Resource.Pending;
                                    objOperationManagement.NightCheckVisitActionStatusUpdate(lblRowID.Text, Resources.Resource.Pending);
                                }
                            }
                        }
                        FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
                        gvNightCheckVisit.FooterRow.Visible = false;
                    }

                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.FromTimeorToTimenotValid;
                    txtTimeFrom.Focus();
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.DatecannotbegreaterthanCurrentdate;
                txtDate.Focus();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NightCheckDetailsCannotbeleftblank;
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
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        Status = 0;
        ds = objOperationManagement.NightCheckVisitAmend(txtCheckVisitNumber.Text, Resources.Resource.Amend, BaseLocationAutoID, BaseUserID);
        lblCheckVisitStatus.Text = Resources.Resource.Amend;
        FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
        gvNightCheckVisit.Columns[0].Visible = true;
        if (IsWriteAccess == true)
        {
            gvNightCheckVisit.FooterRow.Visible = true;
        }
        HideButton();
        EnableFields();
        HideButtonBasedOnStatus();
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        gvNightCheckVisit.Columns[0].Visible = false;
        gvNightCheckVisit.FooterRow.Visible = false;
        gvNightCheckVisit.EditIndex = -1;
        DisableFields();
        HideButtonBasedOnStatus();
    }
    #endregion

    /// <summary>
    /// Hides the button based on status.
    /// </summary>
    private void HideButtonBasedOnStatus()
    {
        if (lblCheckVisitStatus.Text == Resources.Resource.Fresh)
        {
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnAuthorize.Visible = true;
                btnUpdate.Visible = true;
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
                    btnAuthorize.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
        }
        else if (lblCheckVisitStatus.Text == Resources.Resource.Amend)
        {
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnAuthorize.Visible = true;
                btnUpdate.Visible = true;
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
                    btnAuthorize.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
        }
        else if (lblCheckVisitStatus.Text == Resources.Resource.Authorized)
        {
            int flag = 0;
            gvNightCheckVisit.FooterRow.Visible = false;
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

    /// <summary>
    /// Fillgvs the night check visit after save.
    /// </summary>
    /// <param name="strCheckVisitNumber">The string check visit number.</param>
    private void FillgvNightCheckVisitAfterSave(string strCheckVisitNumber)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dtNightCheck = new DataTable();
        int dtflag;
        dtflag = 1;
        count = 1;
        ds = objOperationManagement.NightCheckVisitDetailGetAll(strCheckVisitNumber);//, BaseCompanyCode, BaseLocationAutoID);
        // try
        //   {
        if (ds != null && ds.Tables.Count > 0)
        {
            dtNightCheck = ds.Tables[0];
            //to fix empty gridview
            if (dtNightCheck.Rows.Count == 0)
            {
                dtflag = 0;
                count = 0;
                dtNightCheck.Rows.Add(dtNightCheck.NewRow());
            }
            gvNightCheckVisit.DataSource = dtNightCheck;
            gvNightCheckVisit.DataBind();
            if (dtflag == 0)//to fix empety gridview
            {
                gvNightCheckVisit.Rows[0].Visible = false;
                //gvNightCheckVisit.Enabled = false;
            }
            //Added by  on 2-Jun-2013
            for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
            {
                DropDownList ddlClientId = (DropDownList)gvNightCheckVisit.Rows[cnt].FindControl("ddlClientId");
                DropDownList ddlAsmtId = (DropDownList)gvNightCheckVisit.Rows[cnt].FindControl("ddlAsmtId");
                string clientId = ds.Tables[0].Rows[cnt]["ClientCode"].ToString();
                string asmtId = ds.Tables[0].Rows[cnt]["AsmtId"].ToString();
                SetClientId(ddlClientId, clientId);
                SetAsmt(ddlClientId, ddlAsmtId, asmtId);
            }
        }
        //}
        //catch (Exception)
        //{
        //}
    }

    //Added by  on 2-Jun-2013
    /// <summary>
    /// Fillgvs the night check visit on edit.
    /// </summary>
    /// <param name="rowNumber">The row number.</param>
    /// <param name="strCheckVisitNumber">The string check visit number.</param>
    private void FillgvNightCheckVisitOnEdit(int rowNumber, string strCheckVisitNumber)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dtNightCheck = new DataTable();
        int dtflag;
        dtflag = 1;
        count = 1;
        ds = objOperationManagement.NightCheckVisitDetailGetAll(strCheckVisitNumber);//, BaseCompanyCode, BaseLocationAutoID);
        // try
        //   {
        if (ds != null && ds.Tables.Count > 0)
        {
            dtNightCheck = ds.Tables[0];
            //to fix empty gridview
            if (dtNightCheck.Rows.Count == 0)
            {
                dtflag = 0;
                count = 0;
                dtNightCheck.Rows.Add(dtNightCheck.NewRow());
            }
            gvNightCheckVisit.DataSource = dtNightCheck;
            gvNightCheckVisit.DataBind();
            if (dtflag == 0)//to fix empety gridview
            {
                gvNightCheckVisit.Rows[0].Visible = false;
                //gvNightCheckVisit.Enabled = false;
            }
            //Added by  on 2-Jun-2013
            DropDownList ddlClientId = (DropDownList)gvNightCheckVisit.Rows[rowNumber].FindControl("ddlClientId");
            DropDownList ddlAsmtId = (DropDownList)gvNightCheckVisit.Rows[rowNumber].FindControl("ddlAsmtId");
            string clientId = ds.Tables[0].Rows[rowNumber]["ClientCode"].ToString();
            string asmtId = ds.Tables[0].Rows[rowNumber]["AsmtId"].ToString();
            SetClientId(ddlClientId, clientId);
            SetAsmt(ddlClientId, ddlAsmtId, asmtId);

            //Set Observation Type 
            DropDownList ddlObservationType = (DropDownList)gvNightCheckVisit.Rows[rowNumber].FindControl("ddlObservationType");
            if (ddlObservationType != null)
            {
                int ObservationCode = Convert.ToInt32(ds.Tables[0].Rows[rowNumber]["QuickCodeAutoID"]);
                SetObservationType(ddlObservationType, ObservationCode);
            }
        }
        //}
        //catch (Exception)
        //{
        //}
    }

    /// <summary>
    /// Fills the details.
    /// </summary>
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement obj = new BL.OperationManagement();
        ds = obj.NightCheckVisitGetAll(txtCheckVisitNumber.Text, BaseLocationAutoID, "");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlCheckVisitType.SelectedValue = ds.Tables[0].Rows[0]["Check_Visit_type"].ToString();
            txtConductedBy.Text = ds.Tables[0].Rows[0]["Conducted_by"].ToString();
            txtTimeFrom.Text = DateTime.Parse(ds.Tables[0].Rows[0]["Time_from"].ToString()).ToString("HH:mm");
            txtTimeTo.Text = DateTime.Parse(ds.Tables[0].Rows[0]["Time_to"].ToString()).ToString("HH:mm");
            txtDate.Text = DateFormat(ds.Tables[0].Rows[0]["Check_Visit_Date"].ToString());
            lblCheckVisitStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            dtNightCheckDetail.Clear();
            ClearFields();
            HideButton();
            btnSave.Visible = true;
            ddlCheckVisitType.Enabled = true;
            lblCheckVisitStatus.Text = "";
            FillgvNightCheckVisit();
        }
    }
    /// <summary>
    /// Compares the grid time with header time.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CompareGridTimeWithHeaderTime()//Check Time From and Time TO in header with gridview From and To Time
    {
        int flag = 1;
        try
        {
            for (int i = 0; i < gvNightCheckVisit.Rows.Count; i++)
            {
                Label lblTimeFromGrid = (Label)gvNightCheckVisit.Rows[i].FindControl("lblTimeFrom");
                Label lblTimeToGrid = (Label)gvNightCheckVisit.Rows[i].FindControl("lblTimeTo");
                if (DateTime.Parse(lblTimeFromGrid.Text) >= DateTime.Parse(txtTimeFrom.Text) && DateTime.Parse(lblTimeFromGrid.Text) <= DateTime.Parse(txtTimeTo.Text) && DateTime.Parse(lblTimeToGrid.Text) >= DateTime.Parse(txtTimeFrom.Text) && DateTime.Parse(lblTimeToGrid.Text) <= DateTime.Parse(txtTimeTo.Text))
                {
                }
                else
                {
                    flag = 0;
                    gvNightCheckVisit.Rows[i].BackColor = System.Drawing.Color.Aqua;
                }
                if (flag != 0)
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

    }

    /// <summary>
    /// Handles the DataBound event of the gvNightCheckVisit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvNightCheckVisit_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvNightCheckVisit.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvNightCheckVisit.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvNightCheckVisit.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvNightCheckVisit.PageCount.ToString();
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvNightCheckVisit.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvNightCheckVisit.PageIndex = ddlPages.SelectedIndex;
        if (index == 1)
        {
            gvNightCheckVisit.DataSource = dtNightCheckDetail;
            gvNightCheckVisit.DataBind();
        }
        else
        {
            FillgvNightCheckVisitAfterSave(txtCheckVisitNumber.Text);
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtObservation_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ImageButton ImgbtnUpdate = (ImageButton)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        ToolkitScriptManager2.SetFocus(ImgbtnUpdate);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewObservation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewObservation_TextChanged(object sender, EventArgs e)
    {
        ImageButton lbADD = (ImageButton)gvNightCheckVisit.FooterRow.FindControl("lbADD");
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager2.SetFocus(lbADD);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtDate, lblErrorMsg);
    }


    #region Coded Added by 
    //Added by  on 2-Jun-2013
    /// <summary>
    /// Fills the client identifier.
    /// </summary>
    /// <param name="ddlClientId">The DDL client identifier.</param>
    /// <param name="ddlAsmtId">The DDL asmt identifier.</param>
    private void FillClientId(DropDownList ddlClientId, DropDownList ddlAsmtId)
    {
        try
        {
            if (ddlClientId != null && ddlAsmtId != null)
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
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }
    ///// <summary>
    ///// Execute on ddlClientId Item Selection get changed.
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>

    ////Get Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Fills the asmt.
    /// </summary>
    /// <param name="ddlClientId">The DDL client identifier.</param>
    /// <param name="ddlAsmtId">The DDL asmt identifier.</param>
    private void FillAsmt(DropDownList ddlClientId, DropDownList ddlAsmtId)
    {
        try
        {
            if (ddlClientId != null && ddlAsmtId != null)
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
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtCustomerDesc.Text = ddlClientId.SelectedItem.Text;
        DropDownList objDDL = (DropDownList)sender;
        GridViewRow row = (GridViewRow)objDDL.NamingContainer;
        DropDownList ddlClientId = (DropDownList)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ddlClientId");
        DropDownList ddlAsmtId = (DropDownList)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ddlAsmtId");
        TextBox txtClientName = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtClientName");
        if (ddlClientId != null && ddlAsmtId != null)
        {
            string[] strClientName = ddlClientId.SelectedItem.Text.Split('(');
            txtClientName.Text = strClientName[0];
            FillAsmt(ddlClientId, ddlAsmtId);
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlNewClientId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlNewClientId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtCustomerDesc.Text = ddlClientId.SelectedItem.Text;
        DropDownList objDDL = (DropDownList)sender;
        GridViewRow row = (GridViewRow)objDDL.NamingContainer;
        DropDownList ddlNewClientId = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewClientId");
        DropDownList ddlNewAsmtId = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewAsmtId");
        TextBox txtNewClientName = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewClientName");
        if (ddlNewClientId != null && ddlNewAsmtId != null)
        {
            string[] strClientName = ddlNewClientId.SelectedItem.Text.Split('(');
            txtNewClientName.Text = strClientName[0];
            FillAsmt(ddlNewClientId, ddlNewAsmtId);
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList objDDL = (DropDownList)sender;
        GridViewRow row = (GridViewRow)objDDL.NamingContainer;
        DropDownList ddlClientId = (DropDownList)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ddlClientId");
        DropDownList ddlAsmtId = (DropDownList)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ddlAsmtId");

        TextBox txtBranchID = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtBranchID");
        TextBox txtBranch = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtBranch");
        TextBox txtClientName = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtClientName");
        TextBox txtAsmtAddress = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtAsmtAddress");
        TextBox txtEmployeeNumber = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtEmployeeNumber");
        TextBox txtEmployeeName = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtEmployeeName");
        TextBox txtDesignation = (TextBox)gvNightCheckVisit.Rows[row.RowIndex].FindControl("txtDesignation");
        ImageButton IMGButton = (ImageButton)gvNightCheckVisit.Rows[row.RowIndex].FindControl("ImgbtnUpdate");
        /* Added by  on 23-May-2013 */
        //HiddenField hdClientCode = (HiddenField)gvNightCheckVisit.Rows[row.RowIndex].FindControl("hdClientCode");
        //txtAsmtCode.Text = hdClientCode.Value;
        /* End */
        //Added by  on 2-Jun-2013
        btnSave.Enabled = true;
        //Commented & Modify by  on 23-May-2013
        FillAsmtDetail(row, txtBranchID, txtBranch, ddlClientId, txtClientName, txtAsmtAddress, ddlAsmtId, IMGButton, txtEmployeeNumber, txtEmployeeName, txtDesignation);
        //FillAsmtDetail(row, txtBranchID, txtBranch, hdClientCode, txtClientCode, txtClientName, txtAsmtAddress, txtAsmtCode, IMGButton, txtEmployeeNumber, txtEmployeeName, txtDesignation);
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlNewAsmtId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlNewAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DropDownList objDDL = (DropDownList)sender;
        GridViewRow row = (GridViewRow)objDDL.NamingContainer;

        DropDownList ddlNewClientId = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewClientId");
        DropDownList ddlNewAsmtId = (DropDownList)gvNightCheckVisit.FooterRow.FindControl("ddlNewAsmtId");

        TextBox txtBranchID = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewBranchID");
        TextBox txtBranch = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewBranch");
        TextBox txtClientName = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewClientName");
        TextBox txtAsmtAddress = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewAsmtAddress");
        TextBox txtEmployeeNumber = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewEmployeeNumber");
        TextBox txtEmployeeName = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewEmployeeName");
        TextBox txtDesignation = (TextBox)gvNightCheckVisit.FooterRow.FindControl("txtNewDesignation");
        /* Added by  on 23-May-2013 */
        //HiddenField hdNewClientCode = (HiddenField)gvNightCheckVisit.FooterRow.FindControl("hdNewClientCode");
        /* End */
        //Added by  on 2-Jun-2013
        btnSave.Enabled = true;
        //End
        ToolkitScriptManager2.SetFocus(txtEmployeeNumber);
        ImageButton IMGButton = (ImageButton)gvNightCheckVisit.FooterRow.FindControl("lbADD");
        //Commented & Modify by  on 23-May-2013
        FillAsmtDetail(row, txtBranchID, txtBranch, ddlNewClientId, txtClientName, txtAsmtAddress, ddlNewAsmtId, IMGButton, txtEmployeeNumber, txtEmployeeName, txtDesignation);
        // FillAsmtDetail(row, txtBranchID, txtBranch, hdNewClientCode, txtClientCode, txtClientName, txtAsmtAddress, txtAsmtCode, IMGButton, txtEmployeeNumber, txtEmployeeName, txtDesignation);
    }

    ////Added by  on 2-Jun-2013
    ////Set Client Code 
    /// <summary>
    /// Sets the client identifier.
    /// </summary>
    /// <param name="ddlClientId">The DDL client identifier.</param>
    /// <param name="clientCode">The client code.</param>
    private void SetClientId(DropDownList ddlClientId, string clientCode)
    {
        try
        {
            if (ddlClientId != null)
            {
                BL.OperationManagement objOPS = new BL.OperationManagement();
                DataSet ds = new DataSet();
                ds = objOPS.GetClient(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlClientId.DataSource = ds;
                    ddlClientId.DataTextField = "ClientCode";
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
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }

    ////Set Assignment Based on LocationAutoId and ClientCode.
    /// <summary>
    /// Sets the asmt.
    /// </summary>
    /// <param name="ddlClientId">The DDL client identifier.</param>
    /// <param name="ddlAsmtId">The DDL asmt identifier.</param>
    /// <param name="asmtId">The asmt identifier.</param>
    private void SetAsmt(DropDownList ddlClientId, DropDownList ddlAsmtId, string asmtId)
    {
        try
        {
            if (ddlClientId != null && ddlAsmtId != null)
            {
                BL.OperationManagement objOPS = new BL.OperationManagement();
                DataSet ds = new DataSet();
                ds = objOPS.AssignmentsOfSelectedClientGet(Convert.ToInt32(BaseLocationAutoID), ddlClientId.SelectedItem.Value);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlAsmtId.DataSource = ds;
                    ddlAsmtId.DataTextField = "AsmtCode";
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
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }
    }

    /// <summary>
    /// Sets the type of the observation.
    /// </summary>
    /// <param name="ddlObservationType">Type of the DDL observation.</param>
    /// <param name="observationType">Type of the observation.</param>
    private void SetObservationType(DropDownList ddlObservationType, int observationType)
    {
        if (ddlObservationType != null)
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            ds = objOperationManagement.NightCheckVisitObservationTypeGet(BaseCompanyCode);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlObservationType.DataSource = ds;
                ddlObservationType.DataTextField = "ItemDesc";
                ddlObservationType.DataValueField = "ItemCode";
                ddlObservationType.DataBind();
                if (ddlObservationType.Text == "")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "0";
                    ddlObservationType.Items.Add(li);
                }
                for (int cnt = 0; cnt < ds.Tables[0].Rows.Count; cnt++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[cnt]["ItemCode"]) == observationType)
                    {
                        ddlObservationType.SelectedIndex = cnt;
                    }
                }
            }
        }
    }
    #endregion
}
