// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RequiredVSScheduleVSActual.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web;

/// <summary>
/// Class Transactions_RequiredVSScheduleVSActual.
/// </summary>
public partial class Transactions_RequiredVSScheduleVSActual : BasePage // System.Web.UI.Page
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

    #region Page Load and Page Controles
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
            //    lblPageHdrTitle.Text = Resources.Resource.RequirementVSScheduledORActual;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.RequirementVSScheduledORActual + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {

                txtYear.Text = DateTime.Now.Year.ToString();
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

                txtYear.MaxLength = 4;
                txtYear.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";


                string[] strArray = new string[2];
                // added by Manishe on 09/04/2010 as per ticket 150021 for getting pay period
                strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Year.ToString()));
                // added by Manishe on 09/04/2010 as per ticket 150021 for getting pay period
                txtFromDate.Text = strArray[0];
                txtToDate.Text = strArray[1];
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                ImgbtnSearchSONO.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");

                // For determine style weekly or monthly
                GetDatebasedOnSystemParameters();
                //For Filling items in ddlWeek
                GetWeekStartDay();

                FillddlSelect();
                FillAreaID();
                FillddlClientCode();
                
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }


    }
    /// <summary>
    /// Fillddls the select.
    /// </summary>
    protected void FillddlSelect()
    {
        ListItem li = new ListItem();
        li.Text = Resources.Resource.Scheduled + "(" + Resources.Resource.All + ")";
        li.Value = "ASCHEDULED";
        ddlSelect.Items.Add(li);

        li = new ListItem();
        li.Text = " --- " + Resources.Resource.UnderPost;
        li.Value = "PSCHEDULED";
        ddlSelect.Items.Add(li);

        li = new ListItem();
        li.Text = " --- " + Resources.Resource.OverPost;
        li.Value = "OSCHEDULED";
        ddlSelect.Items.Add(li);


        li = new ListItem();
        li.Text = " --- " + Resources.Resource.Fulfilled;
        li.Value = "FSCHEDULED";
        ddlSelect.Items.Add(li);

        li = new ListItem();
        li.Text = " --- " + Resources.Resource.NotScheduled;
        li.Value = "NSCHEDULED";
        ddlSelect.Items.Add(li);


        li = new ListItem();
        li.Text = Resources.Resource.Actual + "(" + Resources.Resource.All + ")";
        li.Value = "AACTUAL";
        ddlSelect.Items.Add(li);


        li = new ListItem();
        li.Text = " --- " + Resources.Resource.UnderPost;
        li.Value = "PACTUAL";
        ddlSelect.Items.Add(li);

        li = new ListItem();
        li.Text = " --- " + Resources.Resource.OverPost;
        li.Value = "OACTUAL";
        ddlSelect.Items.Add(li);


        li = new ListItem();
        li.Text = " --- " + Resources.Resource.Fulfilled;
        li.Value = "FACTUAL";
        ddlSelect.Items.Add(li);

        li = new ListItem();
        li.Text = " --- " + Resources.Resource.No + " " + Resources.Resource.Rota;
        li.Value = "NACTUAL";
        ddlSelect.Items.Add(li);


    }


    /// <summary>
    /// Fuction to fill area Based on Date
    /// </summary>
    private void FillAreaID()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AreaIdGet(BaseLocationAutoID, BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), txtFromDate.Text, txtToDate.Text);
        ddlArea.Items.Clear();
        DataSet dsArea = new DataSet();

        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            dsArea = ds.Clone();
            DataTable dt = ds.Tables[0];
            var distinctRows = (from DataRow dRow in dt.Rows
                                select new { colAreaDesc = dRow["AreaDesc"], colAreaID = dRow["AreaID"] }).Distinct();
            foreach (var row in distinctRows)
            {
                DataRow drRow = dsArea.Tables[0].NewRow();
                drRow["AreaDesc"] = row.colAreaDesc;
                drRow["AreaID"] = row.colAreaID;
                dsArea.Tables[0].Rows.Add(drRow);
            }

            ddlArea.DataSource = dsArea.Tables[0];
            ddlArea.DataTextField = "AreaDesc";
            ddlArea.DataValueField = "AreaID";
            ddlArea.DataBind();

            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = @"ALL";
            ddlArea.Items.Insert(0, li);
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = @"";
            ddlArea.Items.Insert(0, li);
        }
    }

    /// <summary>
    /// Fillddls the client code.
    /// </summary>
    protected void FillddlClientCode()
    {
        DataSet ds = new DataSet();
        BL.Sales objSale = new BL.Sales();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            //objsales.ClientGet commented by Manish on 22-mar-2012 and use ClientsMappedToLocationGet for showing client areawiae
            //ds = objSale.ClientGet(BaseLocationAutoID, BaseUserID);
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, ddlArea.SelectedValue.ToString(), BaseUserID, BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), txtFromDate.Text, txtToDate.Text);

        }
        else
        {
            //objsales.ClientGet commented by Manish on 22-mar-2012 and use ClientsMappedToLocationGet for showing client areawiae
            //ds = objSale.ClientsLocationWiseGet(BaseLocationAutoID);
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, ddlArea.SelectedValue.ToString(), "", BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), txtFromDate.Text, txtToDate.Text);

        }
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientName";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();
            }
        }
        ListItem li = new ListItem();
        li.Text = Resources.Resource.All;
        li.Value = "";
        ddlClientCode.Items.Insert(0, li);
    }
    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
        FillgvReqSchAct();
        gvReqSchAct.Visible = true;
        UpdatePanel1.Update();
    }
    #endregion

    #region GridView Function
    /// <summary>
    /// Fillgvs the req SCH act1.
    /// </summary>
    protected void FillgvReqSchAct1()
    {
        gvReqSchAct.Columns.Clear();

        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        if (!string.IsNullOrEmpty(BaseUserIsAreaIncharge))
        //ds = objRoster.blTranRequiredVSScheduleVSActual_Get(BaseLocationAutoID.ToString(), "ALL", txtFromDate.Text, txtToDate.Text, Resources.Resource.Authorized.ToString(), Resources.Resource.Terminated.ToString());
        {
            ds = objRoster.RequiredVSScheduleVSActualGet(BaseLocationAutoID.ToString(), "ALL",txtFromDate.Text, txtToDate.Text, "Authorized", "Terminated",ddlSelect.SelectedValue.ToString(), ddlArea.SelectedValue.ToString(),BaseUserID);
        }
        else
        {
            ds = objRoster.RequiredVSScheduleVSActualGet(BaseLocationAutoID.ToString(),"ALL", txtFromDate.Text, txtToDate.Text, "Authorized", "Terminated", ddlSelect.SelectedValue.ToString(), ddlArea.SelectedValue.ToString(),"ALL");
        }
        DataTable dt = new DataTable();
        dt = ds.Tables[0];

        HyperLinkField bfield = new HyperLinkField();
        bfield.DataTextField = dt.Columns[3].ColumnName;
        bfield.HeaderText = Resources.Resource.ClientCode;
        gvReqSchAct.Columns.Add(bfield);

        //bfield = new HyperLinkField();
        //bfield.DataTextField = dt.Columns[0].ColumnName;
        //bfield.HeaderText = "Client Name";
        //gvReqSchAct.Columns.Add(bfield);

        bfield = new HyperLinkField();
        bfield.DataTextField = dt.Columns[4].ColumnName;
        bfield.HeaderText = Resources.Resource.AsmtCode;
        gvReqSchAct.Columns.Add(bfield);

        //bfield = new HyperLinkField();
        //bfield.DataTextField = dt.Columns[1].ColumnName;
        //bfield.HeaderText = "Asmt. Address";
        //gvReqSchAct.Columns.Add(bfield);

        for (int i = 9; i < dt.Columns.Count; i++)
        {
            if (dt.Columns[i].ColumnName.ToString().Substring(2, 1) == "R")
            {
                bfield = new HyperLinkField();
                bfield.DataTextField = dt.Columns[i].ColumnName;
                bfield.HeaderText = dt.Columns[i].ColumnName.ToString();
                bfield.AccessibleHeaderText = dt.Columns[i].ColumnName.ToString();
                gvReqSchAct.Columns.Add(bfield);
            }
            if (ddlSelect.SelectedItem.Value.ToString() == Resources.Resource.Scheduled && dt.Columns[i].ColumnName.ToString().Substring(2, 1) == "S")
            {
                bfield = new HyperLinkField();
                bfield.DataTextField = dt.Columns[i].ColumnName;
                bfield.AccessibleHeaderText = dt.Columns[i].ColumnName.ToString();
                if (i > 8)
                {
                    bfield.HeaderText = dt.Columns[i].ColumnName.ToString().Substring(0, 2);
                }
                else
                {
                    bfield.HeaderText = dt.Columns[i].ColumnName.ToString();
                }
                gvReqSchAct.Columns.Add(bfield);
            }
            else if (ddlSelect.SelectedItem.Value.ToString() == Resources.Resource.Actual && dt.Columns[i].ColumnName.ToString().Substring(2, 1) == "A")
            {
                bfield = new HyperLinkField();
                bfield.DataTextField = dt.Columns[i].ColumnName;
                bfield.AccessibleHeaderText = dt.Columns[i].ColumnName.ToString();
                if (i > 8)
                {
                    bfield.HeaderText = dt.Columns[i].ColumnName.ToString().Substring(0, 2);
                }
                else
                {
                    bfield.HeaderText = dt.Columns[i].ColumnName.ToString();
                }
                gvReqSchAct.Columns.Add(bfield);
            }

        }


        //DataSet ds = new DataSet();
        //BL.Roster objRoster = new BL.Roster();
        //ds = objRoster.blTranRequiredVSScheduleVSActual_Get(BaseLocationAutoID.ToString(), "ALL", txtFromDate.Text, txtToDate.Text, Resources.Resource.Authorized.ToString(), Resources.Resource.Terminated.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvReqSchAct.DataSource = ds.Tables[0];
            gvReqSchAct.DataBind();
        }
    }
    /// <summary>
    /// Fillgvs the req SCH act.
    /// </summary>
    protected void FillgvReqSchAct()
    {
        gvReqSchAct.Columns.Clear();

        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        //        ds = objRoster.blTranRequiredVSScheduleVSActual_Get(BaseLocationAutoID.ToString(), ddlClientCode.SelectedItem.Value.ToString(), txtFromDate.Text, txtToDate.Text, Resources.Resource.Authorized.ToString(), Resources.Resource.Terminated.ToString());
        if (!string.IsNullOrEmpty(BaseUserIsAreaIncharge))
        //ds = objRoster.blTranRequiredVSScheduleVSActual_Get(BaseLocationAutoID.ToString(), "ALL", txtFromDate.Text, txtToDate.Text, Resources.Resource.Authorized.ToString(), Resources.Resource.Terminated.ToString());
        {
            ds = objRoster.RequiredVSScheduleVSActualGet(BaseLocationAutoID.ToString(), ddlClientCode.SelectedValue.ToString(), txtFromDate.Text, txtToDate.Text, "Authorized", "Terminated", ddlSelect.SelectedValue.ToString(), ddlArea.SelectedValue.ToString(), BaseUserEmployeeNumber);
        }
        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            //**********************************************************************
            //Create Template Fields in GridView
            TemplateField templateField = new TemplateField();
            DynamicTemplate dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            //************
            Label lbl = new Label();
            lbl.ID = "lblClientName";
            lbl.Visible = true;
            lbl.Text = dt.Columns[1].ColumnName;
            lbl.Width = Unit.Percentage(100);
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[1].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.ClientName;
            gvReqSchAct.Columns.Add(templateField);


            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblAsmtAddress";
            lbl.Visible = true;
            lbl.Text = dt.Columns[2].ColumnName;
            lbl.Width = Unit.Percentage(100);
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[2].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.AsmtAddress;
            gvReqSchAct.Columns.Add(templateField);
            //************
            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblPostDesc";
            lbl.Visible = true;
            lbl.Text = dt.Columns[7].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[7].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.Post;
            gvReqSchAct.Columns.Add(templateField);
            //************
            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblLocationAutoId";
            lbl.Visible = true;
            lbl.Text = dt.Columns[3].ColumnName;
            lbl.Width = Unit.Percentage(100);
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[3].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.Location;
            gvReqSchAct.Columns.Add(templateField);
            //************
            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblClientCode";
            lbl.Visible = true;
            lbl.Text = dt.Columns[4].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[4].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.ClientCode;
            gvReqSchAct.Columns.Add(templateField);

            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblAsmtCode";
            lbl.Visible = true;
            lbl.Text = dt.Columns[5].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[5].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.AsmtCode;
            gvReqSchAct.Columns.Add(templateField);


            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblPostCode";
            lbl.Visible = true;
            lbl.Text = dt.Columns[6].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[6].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.PostCode;
            gvReqSchAct.Columns.Add(templateField);

            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblPostAutoId";
            lbl.Visible = true;
            lbl.Text = dt.Columns[8].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[8].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.IdDetails;
            gvReqSchAct.Columns.Add(templateField);

            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblSoRank";
            lbl.Visible = true;
            lbl.Text = dt.Columns[9].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[9].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.SORank;
            gvReqSchAct.Columns.Add(templateField);



            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblSoNo";
            lbl.Visible = true;
            lbl.Text = dt.Columns[10].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[10].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.Sno;
            gvReqSchAct.Columns.Add(templateField);


            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblSoLineNo";
            lbl.Visible = true;
            lbl.Text = dt.Columns[11].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[11].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.SOLineNo;
            gvReqSchAct.Columns.Add(templateField);


            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "lblSoAmendNo";
            lbl.Visible = true;
            lbl.Text = dt.Columns[12].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[12].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.SOAmendNo;
            gvReqSchAct.Columns.Add(templateField);

            templateField = new TemplateField();
            dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            lbl = new Label();
            lbl.ID = "Phone";
            lbl.Visible = true;
            lbl.Text = dt.Columns[0].ColumnName;
            dynamicTemplate.AddControl(lbl, "Text", dt.Columns[0].ColumnName);
            templateField.ItemTemplate = dynamicTemplate;
            templateField.HeaderText = Resources.Resource.Phone;
            gvReqSchAct.Columns.Add(templateField);

            //templateField = new TemplateField();
            //dynamicTemplate = new DynamicTemplate(ListItemType.Item);
            //lbl = new Label();
            //lbl.ID = "lblPDLineNo";
            //lbl.Visible = true;
            //lbl.Text = dt.Columns[9].ColumnName;
            //dynamicTemplate.AddControl(lbl, "Text", dt.Columns[9].ColumnName);
            //templateField.ItemTemplate = dynamicTemplate;
            //templateField.HeaderText = Resources.Resource.SORank;
            //gvReqSchAct.Columns.Add(templateField);

            for (int i = 13; i < dt.Columns.Count; i++)
            {
                templateField = new TemplateField();
                dynamicTemplate = new DynamicTemplate(ListItemType.Item);
                lbl = new Label();
                lbl.ID = "lbl" + dt.Columns[i].ColumnName;
                lbl.Visible = true;
                lbl.Text = dt.Columns[i].ColumnName;
                lbl.Width = Unit.Percentage(100);
                dynamicTemplate.AddControl(lbl, "Text", dt.Columns[i].ColumnName);
                templateField.ItemTemplate = dynamicTemplate;
                templateField.HeaderText = dt.Columns[i].ColumnName.ToString().Substring(0, 2);
                templateField.AccessibleHeaderText = dt.Columns[i].ColumnName.ToString().Substring(11, 1);
                gvReqSchAct.Columns.Add(templateField);
            }
            //**********************************************************************

            gvReqSchAct.DataSource = ds.Tables[0];
            gvReqSchAct.DataBind();

            //*****************Hide the Columns
          //  gvReqSchAct.Columns[3].Visible = false;
           // gvReqSchAct.Columns[4].Visible = false;
           // gvReqSchAct.Columns[5].Visible = false;
           // gvReqSchAct.Columns[6].Visible = false;
            ////gvReqSchAct.Columns[7].Visible = false;
           // gvReqSchAct.Columns[8].Visible = false;


              gvReqSchAct.Columns[3].Visible = false;
             gvReqSchAct.Columns[4].Visible = false;
             gvReqSchAct.Columns[5].Visible = false;
            gvReqSchAct.Columns[6].Visible = false;
            gvReqSchAct.Columns[7].Visible = false;
             //gvReqSchAct.Columns[8].Visible = false;
             gvReqSchAct.Columns[9].Visible = false;
             gvReqSchAct.Columns[10].Visible = false;
             gvReqSchAct.Columns[11].Visible = false;
             gvReqSchAct.Columns[12].Visible = false;

            for (int k = 2; k < gvReqSchAct.Columns.Count; k++)
            {
                if (gvReqSchAct.Columns[k].AccessibleHeaderText.ToString() == "R")
                {
                    gvReqSchAct.Columns[k].Visible = false;
                }
                //* commented by Dharamvir Singh on 25th Nov 2009*//
                //if (ddlSelect.SelectedItem.Value.ToString() == Resources.Resource.Scheduled.ToString())
                if ((ddlSelect.SelectedItem.Value.ToString()).Substring(1, 3) == "SCH")
                {

                    if (gvReqSchAct.Columns[k].AccessibleHeaderText.ToString() == "A")
                    {
                        gvReqSchAct.Columns[k].Visible = false;
                    }
                }
                else if ((ddlSelect.SelectedItem.Value.ToString()).Substring(1, 3) == "ACT")
                {
                    if (gvReqSchAct.Columns[k].AccessibleHeaderText.ToString() == "S")
                    {
                        gvReqSchAct.Columns[k].Visible = false;
                    }
                }
            }
        }
        else
        {
            gvReqSchAct.DataSource = null;
            gvReqSchAct.DataBind();

            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvReqSchAct control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvReqSchAct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblClientCode = (Label)e.Row.FindControl("lblClientCode");
            Label lblClientName = (Label)e.Row.FindControl("lblClientName");
            Label lblAsmtCode = (Label)e.Row.FindControl("lblAsmtCode");
            Label lblAsmtAddress = (Label)e.Row.FindControl("lblAsmtAddress");
            Label lblPostCode = (Label)e.Row.FindControl("lblPostCode");
            Label lblPostDesc = (Label)e.Row.FindControl("lblPostDesc");
            Label lblSoRank = (Label)e.Row.FindControl("lblSoRank");
            Label lblSoLineNo = (Label)e.Row.FindControl("lblSoLineNo");
            Label lblSoNo = (Label)e.Row.FindControl("lblSoNo");
            Label lblSoAmendNo = (Label)e.Row.FindControl("lblSoAmendNo");
            Label lblPostAutoId = (Label)e.Row.FindControl("lblPostAutoId");
            
            Label Phone = (Label)e.Row.FindControl("Phone");

            
            //if (lblClientCode != null && lblAsmtCode != null)
            //{
            //    e.Row.Attributes.Add("onclick", "javascript:window.location='../Transactions/ScheduleRosterEmpWise.aspx?ClientCode=" + lblClientCode.Text + "&AsmtCode=" + lblAsmtCode.Text + "&Month=" + DateTime.Parse(txtFromDate.Text).ToString("MM") + "&Year=" + DateTime.Parse(txtFromDate.Text).ToString("yyyy") + "&Week=" + "1" + "&Area=" + ddlArea.SelectedValue + "';");
            //}

            if (lblClientCode != null && lblClientName != null)
            {
                //lblClientCode.ToolTip = lblClientName.Text;
                lblClientName.ToolTip = lblClientCode.Text;
            }
            if (lblAsmtCode != null && lblAsmtAddress != null)
            {
                // lblAsmtCode.ToolTip = lblAsmtAddress.Text;
                lblAsmtAddress.ToolTip = lblAsmtCode.Text;
            }


            //lblClientName.Text = lblClientName.Text + " [ " + lblClientCode.Text +" ]";
            //lblAsmtAddress.Text = lblAsmtAddress.Text + " [ " + lblAsmtCode.Text + " ]";
            // var lblPDLineNo = (Label)e.Row.FindControl("lblPDLineNo");
            lblPostDesc.Text = lblPostDesc.Text + " [ " + lblPostCode.Text + " ]";
           var PDLineNo = Phone.Text;


            Label lblR = new Label();
            Label lblS = new Label();
            Label lblA = new Label();
            decimal intRequirement;
            decimal intScheduled;
            decimal intActual;
            DateTime dtFromDate = DateTime.Parse(DateFormat(txtFromDate.Text));
            DateTime dtToDate = DateTime.Parse(DateFormat(txtToDate.Text));


            System.Drawing.Color colorS = new System.Drawing.Color();
            System.Drawing.Color colorA = new System.Drawing.Color();
            int intTempCounterS = 14;
            int intTempCounterA = 15;

            IFormatProvider fp = new System.Globalization.CultureInfo("en-US");

            while (dtFromDate <= dtToDate)
            {

                intRequirement = 0;
                intScheduled = 0;
                intActual = 0;
                colorS = System.Drawing.Color.Transparent;
                colorA = System.Drawing.Color.Transparent;

                lblR = (Label)e.Row.FindControl("lbl" + dtFromDate.ToString("dd MMM yyyy", fp) + "R");
                lblS = (Label)e.Row.FindControl("lbl" + dtFromDate.ToString("dd MMM yyyy", fp) + "S");
                lblA = (Label)e.Row.FindControl("lbl" + dtFromDate.ToString("dd MMM yyyy", fp) + "A");
                if (lblR != null && lblS != null && lblA != null)
                {
                    if (lblR.Text == null || lblR.Text == "")
                    {
                        intRequirement = 0;
                    }
                    else
                    {
                        intRequirement = decimal.Parse(lblR.Text);
                    }
                    if (lblS.Text == null || lblS.Text == "")
                    {
                        intScheduled = 0;
                    }
                    else
                    {
                        intScheduled = decimal.Parse(lblS.Text);
                    }
                    if (lblA.Text == null || lblA.Text == "")
                    {
                        intActual = 0;
                    }
                    else
                    {
                        intActual = decimal.Parse(lblA.Text);
                    }
                    lblS.ToolTip = Resources.Resource.Required + ":" + lblR.Text + " " + Resources.Resource.Scheduled + " :" + lblS.Text + Resources.Resource.Actual + ": " + lblA.Text;
                    lblA.ToolTip = Resources.Resource.Required + ":" + lblR.Text + " " + Resources.Resource.Scheduled + " :" + lblS.Text + Resources.Resource.Actual + " : " + lblA.Text;
                    //////lblA.ToolTip = "Required:" + lblR.Text + " Scheduled:" + lblS.Text + " Actual:" + lblA.Text;

                         string[] empDetails = lblPostDesc.Text.Split('[');

                         var postAutoid = lblPostAutoId.Text.Trim()+ "^" + lblSoRank.Text.Trim() + "^" + lblSoNo.Text.Trim() +"^"+ lblSoLineNo.Text.Trim() + "^" + lblSoAmendNo.Text.Trim();
                             //empDetails[0].Trim() + "[" + lblSoRank.Text.Trim() + "]";

                    e.Row.Cells[intTempCounterS].Attributes.Add("onclick", "javascript:window.location='../Transactions/ScheduleRosterEmpWise.aspx?ClientCode=" + lblClientCode.Text + "&AsmtCode=" + lblAsmtCode.Text + "&DutyDate=" + dtFromDate.ToString() + "&Post=" + HttpUtility.UrlEncode(postAutoid) + "&Month=" + ddlMonth.SelectedValue.ToString() + "&Week=" + "1" + "&Area=" + ddlArea.SelectedValue + "';");

                    e.Row.Cells[intTempCounterS].BackColor = System.Drawing.Color.Transparent;
                    if (e.Row.Cells.Count > intTempCounterA)        
                    {
                        e.Row.Cells[intTempCounterA].BackColor = System.Drawing.Color.Transparent;
                    }

                    if (intRequirement > intScheduled)
                    { colorS = System.Drawing.Color.Yellow; }
                    if (intRequirement == intScheduled)
                    { colorS = System.Drawing.Color.Green; }
                    if (intRequirement < intScheduled)
                    { colorS = System.Drawing.Color.Red; }
                    if (intScheduled == 0)
                    { colorS = System.Drawing.Color.Silver; }
                    if (intRequirement == 0)
                    { colorS = System.Drawing.Color.Blue; }
                    lblS.BackColor = colorS;
                    e.Row.Cells[intTempCounterS].BackColor = colorS;
                    //e.Row.Cells.Count;
                    //lblS.Parent.ClientID.ToString();

                    if (intRequirement > intActual)
                    { colorA = System.Drawing.Color.Yellow; }
                    if (intRequirement == intActual)
                    { colorA = System.Drawing.Color.Green; }
                    if (intRequirement < intActual)
                    { colorA = System.Drawing.Color.Red; }
                    if (intActual == 0)
                    { colorA = System.Drawing.Color.Silver; }
                    if (intRequirement == 0)
                    { colorA = System.Drawing.Color.Blue; }
                    lblA.BackColor = colorA;
                    if (e.Row.Cells.Count > intTempCounterA)           
                    {
                        e.Row.Cells[intTempCounterA].BackColor = colorA;
                    }
                }

                dtFromDate = dtFromDate.AddDays(1);
                intTempCounterS = intTempCounterS + 3;
                intTempCounterA = intTempCounterA + 3;
            }

            if (lblSoRank != null)
            {
                lblSoRank.Text = lblSoRank.Text + "( " + lblSoNo.Text + " )";
            }
            
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvReqSchAct control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvReqSchAct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvReqSchAct control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvReqSchAct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvReqSchAct.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvReqSchAct.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvReqSchAct.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvReqSchAct.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvReqSchAct.PageIndex = e.NewPageIndex;
        }
        gvReqSchAct.EditIndex = -1;
        FillgvReqSchAct();
    }
    /// <summary>
    /// Handles the DataBound event of the gvReqSchAct control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvReqSchAct_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = gvReqSchAct.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        Label lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            for (int i = 0; i < gvReqSchAct.PageCount; i++)
            {
                int intPageNumber = i + 1;
                ListItem lstItem = new ListItem(intPageNumber.ToString());
                if (i == gvReqSchAct.PageIndex)
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = gvReqSchAct.PageCount.ToString();
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvReqSchAct.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvReqSchAct.PageIndex = ddlPages.SelectedIndex;
        FillgvReqSchAct();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlArea control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClientCode();
        //UpdatePanel1.Update();
    }



    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvReqSchAct.DataSource = null;
        gvReqSchAct.DataBind();

        UpdatePanel1.Update();
        if (txtYear.Text == "")
        {
            txtYear.Text = DateTime.Now.ToString("yyyy");
        }
        else if (txtYear.Text.Length < 4 || Convert.ToInt32(txtYear.Text.ToString()) < 1950 || Convert.ToInt32(txtYear.Text.ToString()) > 2999)
        {
            Show(Resources.Resource.InvalidYear);
           txtYear.Text = DateTime.Now.ToString("yyyy");
           GetWeekStartDay();
            return;
        }

        try
        {
            GetWeekStartDay();
        }
        catch (Exception ex)
        {
            Show(Resources.Resource.InvalidYear);
            txtYear.Text = DateTime.Now.ToString("yyyy");
            GetWeekStartDay();
            return;
        }


    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlWeek control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvReqSchAct.DataSource = null;
        gvReqSchAct.DataBind();
        UpdatePanel1.Update();
        txtFromDate.Text = DateTime.Parse(ddlWeek.SelectedValue.ToString()).ToString("dd-MMM-yyyy");
        txtToDate.Text = DateTime.Parse(ddlWeek.SelectedValue.ToString()).AddDays(6).ToString("dd-MMM-yyyy");
    }

    /// <summary>
    /// Handles the TextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        ddlMonth_SelectedIndexChanged(sender, e);
    }


    /// <summary>
    /// Gets the date based on system parameters.
    /// </summary>
    private void GetDatebasedOnSystemParameters()
    {
        DataTable dt = new DataTable();
        BL.Roster objRoster = new BL.Roster();
        string strSelectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text);
        dt = objRoster.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strSelectedMonthStartDate, BaseDefaultScheduleType.Trim().ToLower());
        if (dt.Rows.Count > 0 && dt != null)
        {

            if (BaseDefaultScheduleType.Trim().ToLower() == "Monthly".Trim().ToLower())
            {
                ddlWeek.Style["display"] = "none";
                ddlMonth.Style["display"] = "block";
                txtYear.Style["display"] = "block";
                lblFromDate.Visible = true;
                lblToDate.Visible = true;
                lblWeekNo.Visible = false;
                txtFromDate.Visible = true;
                txtToDate.Visible = true;
                lblMonth.Visible = false;
                ImgFromDate.Visible = true;
                ImgToDate.Visible = true;

                txtFromDate.Text = DateTime.Parse(dt.Rows[0]["ScheduleMonthlyFromDay"].ToString()).ToString("dd-MMM-yyyy");
                txtToDate.Text = DateTime.Parse(dt.Rows[0]["ScheduleMonthlyToDay"].ToString()).ToString("dd-MMM-yyyy");

            }
            else
            {
                lblWeekNo.Visible = true;
                ddlWeek.Style["display"] = "block";
                ddlMonth.Style["display"] = "block";
                txtYear.Style["display"] = "block";
                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                lblMonth.Visible = true;
                txtFromDate.Visible = false;
                txtToDate.Visible = false;
                ImgFromDate.Visible = false;
                ImgToDate.Visible = false;


                ViewState["ScheduleWeeklyFromDay"] = dt.Rows[0]["ScheduleWeeklyFromDay"].ToString();
                ViewState["ScheduleWeeklyStartDay"] = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                ViewState["ScheduleWeeklyEndDay"] = dt.Rows[0]["ScheduleWeeklyEndDay"].ToString();


                //GetStartEndDate();
            }

        }
    }


    #endregion

    /// <summary>
    /// Gets the week start day.
    /// </summary>
    private void GetWeekStartDay()
    {
        string selectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text);
        DateTime startDate = DateTime.Parse(selectedMonthStartDate);
        bool loopEnd = true;
        ListItem li;
        ddlWeek.Items.Clear();
        while (loopEnd)
        {

            if ((startDate.Month > int.Parse(ddlMonth.SelectedValue.ToString()) || startDate.Year > int.Parse(txtYear.Text) ) && startDate.DayOfWeek.ToString().ToLower().Equals(ViewState["ScheduleWeeklyStartDay"].ToString().ToLower()))
            {
                loopEnd = false;
            }
            else if (startDate.DayOfWeek.ToString().ToLower().Equals(ViewState["ScheduleWeeklyStartDay"].ToString().ToLower()))
            {
                li = new ListItem();
                li.Text = (ddlWeek.Items.Count + 1).ToString();
                li.Value = DateTime.Parse(startDate.ToString("dd-MMM-yyyy")).ToString("dd-MMM-yyyy");
                ddlWeek.Items.Add(li);

            }

            startDate = startDate.AddDays(1);

        }
        txtFromDate.Text = DateTime.Parse(ddlWeek.Items[0].Value.ToString()).ToString("dd-MMM-yyyy");
        txtToDate.Text = DateTime.Parse(ddlWeek.Items[0].Value.ToString()).AddDays(6).ToString("dd-MMM-yyyy");
        }


}
