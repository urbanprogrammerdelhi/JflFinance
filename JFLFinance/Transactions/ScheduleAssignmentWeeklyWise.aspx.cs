// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="ScheduleAssignmentWeeklyWise.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_ScheduleAssignmentWeeklyWise.
/// </summary>
public partial class Transactions_ScheduleAssignmentWeeklyWise : BasePage
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

    /// <summary>
    /// The dt
    /// </summary>
    System.Data.DataTable dt = new System.Data.DataTable();
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
            javaScript.Append("PageTitle('" + Resources.Resource.Scheduled + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            txtYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
            btnProceed.Enabled = false;
            ddlAsmtCode.Enabled = false;
            btnGoAsmt.Enabled = false;

            btnExport.Enabled = false;
            FillddlBranch();
            FillddlClient();
            if (txtYear.Text.Equals(DateTime.Now.Year.ToString()) || txtYear.Text.Equals(DateTime.Now.AddYears(-1).Year.ToString()))
            {
                FillddlAsmt();
            }
            else
            {
                btnProceed.Enabled = false;
                btnExport.Enabled = false;
            }

        }
        else
        {
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                txtYear.Text = Convert.ToString(DateTime.Now.Year);
            }
        }

        //else
        //{
        //    ddlClientCode_SelectedIndexChanged(ddlClientCode, null);
        //    //ddlClientCode.Attributes.Add("onselectedindexchanged()","javascript:__doPostBack('ddlClientCode')");
        //}
    }

    #region Fill Dropdown list
    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, BaseHrLocationCode);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationAutoId";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
            
            //FillddlAreaID();
            FillIncharge();
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnExport.Enabled = false;
            gvSummary.DataSource = null;
            gvSummary.DataBind();
        }
    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        //ddlClientCode.Attributes.Add("onfocuslost()", "javascript:__doPostBack('ddlClientCode')");
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        //Code Comented By Ajay Datta On 26Oct2012 And Code Added - Start
        //ds = objSales.ClientsLocationStatusWiseGet(ddlBranch.SelectedValue.ToString(), ddlMonth.SelectedItem.Value.ToString(), txtYear.Text.ToString(), ddlStatus.SelectedItem.Value.ToString(), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, ddlAreaID.SelectedItem.Value.ToString(), "01/".ToString() + ddlMonth.SelectedItem.Value.ToString() + "/".ToString() + txtYear.Text.ToString(), DateTime.Now.ToString());
        string IsIncharge;
        if (ddlInchargeId.SelectedItem.Value.Equals("ALL"))
        {
            IsIncharge = "0";
        }
        else
        {
            IsIncharge = "1";
        }


        ds = objSales.ClientsLocationStatusWiseGet(ddlBranch.SelectedValue.ToString(), ddlMonth.SelectedItem.Value.ToString(), txtYear.Text.ToString(), ddlStatus.SelectedItem.Value.ToString(), ddlInchargeId.SelectedItem.Value.ToString(), IsIncharge.ToString(), ddlAreaID.SelectedValue.ToString(), "01/".ToString() + ddlMonth.SelectedItem.Value.ToString() + "/".ToString() + txtYear.Text.ToString(), DateTime.Now.ToString());
        //Code Comented By Ajay Datta On 26Oct2012 And Code Added - End
        ddlClientCode.Text = "";
        //ddlClientCode.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataBind();
            hdnClientCount.Value = ds.Tables[0].Rows[0]["ClientCountOnStatus"].ToString();
            btnGo.Enabled = true;
            //ListItem li1 = new ListItem();
            //li1.Text = Resources.Resource.All;
            //li1.Value = "All";
            //ddlClientCode.Items.Insert(0, li1);
            //ddlClientCode.SelectedIndex=0;
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        btnExport.Enabled = false;

        gvSummary.DataSource = null;
        gvSummary.DataBind();
        FillddlAsmt();

    }

    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        btnExport.Enabled = false;
        gvSummary.DataSource = null;
        gvSummary.DataBind();

        ddlAsmtCode.Items.Clear();
        DataSet dsAsmt = new DataSet();
        if (ddlClientCode.Text.Equals(""))
        {

            foreach (ListItem item in ddlClientCode.Items)
            {
                if (ddlClientCode.Items.IndexOf(item) == 0)
                {
                    ddlClientCode.Text = item.Value;
                }
                else
                {
                    ddlClientCode.Text = ddlClientCode.Text + "," + item.Value;
                }
            }
        }
        //Code Comented By Ajay Datta On 26Oct2012 And Code Added - Start
        //BL.OperationManagement objOperationManagement = new BL.OperationManagement(); dsAsmt = objOperationManagement.AssignmentsOfMultipleClientGet(int.Parse(ddlBranch.SelectedValue.ToString()), ddlClientCode.Text, "01/".ToString() + ddlMonth.SelectedItem.Value.ToString() + "/".ToString() + txtYear.Text.ToString(), DateTime.Now.ToString(), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, ddlAreaID.SelectedItem.Value.ToString());
        string IsIncharge;
        if (ddlInchargeId.SelectedItem.Value.Equals("ALL"))
        {
            IsIncharge = "0";
        }
        else
        {
            IsIncharge = "1";
        }

        BL.OperationManagement objOperationManagement = new BL.OperationManagement(); dsAsmt = objOperationManagement.AssignmentsOfMultipleClientGet(int.Parse(ddlBranch.SelectedValue.ToString()), ddlClientCode.Text, "01/".ToString() + ddlMonth.SelectedItem.Value.ToString() + "/".ToString() + txtYear.Text.ToString(), DateTime.Now.ToString(), ddlInchargeId.SelectedItem.Value.ToString(), IsIncharge.ToString(), ddlAreaID.SelectedValue.ToString());
        //Code Comented By Ajay Datta On 26Oct2012 And Code Added - End
        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = dsAsmt.Tables[0];
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();

        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlAsmtCode.Items.Insert(0, li);
            btnProceed.Enabled = false;
        }
    }

    /// <summary>
    /// Fills all Area Incharge dropdown
    /// </summary>
    protected void FillddlAreaID()
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        btnExport.Enabled = false;
        gvSummary.DataSource = null;
        gvSummary.DataBind();

        ListItem li = new ListItem();
        ddlAreaID.Items.Clear(); //Code Added By Ajay Datta on 26Oct2012
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();


        string IsIncharge;
        if (ddlInchargeId.SelectedItem.Value.Equals("ALL"))
        {
            IsIncharge = "0";
        }
        else
        {
            IsIncharge = "1";
        }
        dsClient = objSale.AreaIdGet((ddlBranch.SelectedItem.Value), ddlInchargeId.SelectedItem.Value.ToString(), IsIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {

            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();

            li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";

            ddlAreaID.Items.Insert(0, li);
            ddlClientCode.Enabled = true;
            btnGo.Enabled = true;
        }
        else
        {
            li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlAreaID.Items.Add(li);
        }

    }

    /// <summary>
    /// Fills the incharge drop down.
    /// </summary>
    private void FillIncharge()
    {
        btnProceed.Enabled = false;
        ddlClientCode.Text = "";
        ddlAsmtCode.Text = "";
        btnExport.Enabled = false;
        btnGo.Enabled = false;
        btnGoAsmt.Enabled = false;

        ListItem li = new ListItem();
        ddlInchargeId.Items.Clear();

        BL.OperationManagement objblUserManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objblUserManagement.AreaInchargeLocationWise(ddlBranch.SelectedItem.Value, ddlMonth.SelectedItem.Value, txtYear.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlInchargeId.DataSource = ds.Tables[0];
            ddlInchargeId.DataTextField = "Name";
            ddlInchargeId.DataValueField = "AreaInchargeID";
            ddlInchargeId.DataBind();

            li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";

            ddlInchargeId.Items.Insert(0, li);
            ddlAreaID.Enabled = true;
            FillddlAreaID();

        }
        else
        {
            li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlInchargeId.Items.Add(li);
            ddlAreaID.Enabled = false;
            ddlClientCode.Enabled = false;
            ddlAsmtCode.Enabled = false;
            btnGoAsmt.Enabled = false;
            btnGo.Enabled = false;
        }

    }

    #endregion

    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (ViewState["dt"] != null)
        {
            ViewState["dt"] = null;
        }



        GridView1.DataSource = null;
        GridView1.DataBind();

        FillGridView();
        //BL.Roster objRost = new BL.Roster();
        //DataSet ds = new DataSet();


        //ds = objRost.ScheduleAssignmentWiseWeekly(int.Parse(ddlBranch.SelectedItem.Value), int.Parse(ddlMonth.SelectedItem.Value), int.Parse(DateTime.Now.Year.ToString()), ddlAreaID.SelectedItem.Value.ToString(), ddlClientCode.Text, ddlAsmtCode.SelectedItem.Value, ddlStartDayWeek.SelectedItem.Value, ddlEndDayWeek.SelectedItem.Value);

        //if (ds != null && ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 1)
        //{
        //    lblErrorMsg.Text = "Following Records:- Scheduled Weekly Assignment Wise!";

        //    GridView1.DataSource = ds.Tables[0];
        //    GridView1.DataBind();
        //    btnExport.Enabled = true;
        //    //dt = ds.Tables[0];
        //}


        // up1.Update();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnProceed.Enabled = false;
        ddlClientCode.Text = "";
        //ddlClientCode.Items.Clear();
        //ddlAsmtCode.Items.Clear();
        ddlClientCode.Enabled = false;
        ddlAsmtCode.Text = "";
        ddlAsmtCode.Enabled = false;
        btnExport.Enabled = false;
        btnGo.Enabled = false;
        btnGoAsmt.Enabled = false;
        FillIncharge();

        FillddlClient(); //Code Uncommented By Ajay Datta On 26Oct2012
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnProceed.Enabled = false;
        ddlClientCode.Text = "";
        ddlAsmtCode.Text = "";
        btnExport.Enabled = false;
        btnGo.Enabled = false;
        btnGoAsmt.Enabled = false;
        FillddlClient();

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlClientCode.SelectedIndex == 0)
        {
            FillddlAsmt();
            ddlAsmtCode.SelectedIndex = 0;
            ddlAsmtCode.Enabled = false;
            btnGoAsmt.Enabled = false;
        }
        else
        {
            ddlAsmtCode.Enabled = true;
            btnGoAsmt.Enabled = true;
            FillddlAsmt();
        }

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAsmtCode.SelectedIndex == 0)
        {
            //FillddlAsmt();
            //ddlAsmtCode.SelectedIndex = 0;

            ddlAsmtCode.Enabled = false;
        }
        else
        {
            ddlAsmtCode.Enabled = true;
            //FillddlAsmt();

        }

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlInchargeId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlInchargeId_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlAsmtCode.Text = "";
        ddlClientCode.Text = "";
        FillddlAreaID();
        ddlAreaID.Enabled = true;
        FillddlClient();
        //Code Comented By Ajay Datta On 26Oct2012 And Code Added
        //if (ddlClientCode.Items.Count == 1)
        //{

        //    ddlAreaID.Enabled = false;
        //    ddlClientCode.Enabled = false;
        //    ddlAsmtCode.Text = "";
        //    ddlClientCode.Text = "";
        //    btnGoAsmt.Enabled = false;
        //    btnGo.Enabled = false;
        //    ddlAsmtCode.Enabled = false;

        //}
        //else
        //{
        //    ddlAsmtCode.Text = "";
        //    ddlClientCode.Text = "";
        //    FillddlAreaID();

        //    ddlAreaID.Enabled = true;
        //    FillddlClient();
        //}

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlStatus control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClient();
    }

    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        FillGridView();
        Export(GridView1, gvSummary, "ScheduledWeeklyAssignmentWise.xls");
        //dt = ds.Tables[0];

        //           ExportToExcel(dt, "ScheduledWeeklyAssignmentWise.xls");

    }

    /// <summary>
    /// Fills grid with data
    /// </summary>
    protected void FillGridView()
    {
        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRost.ScheduleAssignmentWiseWeekly(int.Parse(ddlBranch.SelectedItem.Value), int.Parse(ddlMonth.SelectedItem.Value), int.Parse(txtYear.Text.ToString()), ddlAreaID.SelectedItem.Value.ToString(), ddlClientCode.Text, ddlAsmtCode.Text, ddlStartDayWeek.SelectedItem.Value, ddlEndDayWeek.SelectedItem.Value, hdnClientCount.Value.ToString());

        if (ds != null && ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 1)
        {
            lblErrorMsg.Text = "";

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            gvSummary.DataSource = ds.Tables[1];
            gvSummary.DataBind();
            btnExport.Enabled = true;
        }
        else
        {

            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            btnExport.Enabled = false;
        }
    }


    /// <summary>
    /// Exports to excel.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <param name="strFieName">Name of the string fie.</param>
    protected void ExportToExcel(System.Data.DataTable dt, string strFieName)
    {

        string attachment = "attachment; filename=" + strFieName;
        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.ContentType = "application/ms-excel";
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        string tab = "";
        int i;

        foreach (DataRow dr in dt.Rows)
        {
            tab = "";

            for (i = 0; i < dt.Columns.Count; i++)
            {
                if (dr["TotalString"].Equals(""))
                {
                    Response.Write(tab + dr[i].ToString());
                }
                else
                {
                    Response.Write(tab + dr[i].ToString());
                }
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();



    }

    //Exports data into Excel
    /// <summary>
    /// Exports the specified gv.
    /// </summary>
    /// <param name="gv">The gv.</param>
    /// <param name="gvSummary">The gv summary.</param>
    /// <param name="strFieName">Name of the string fie.</param>
    private void Export(GridView gv, GridView gvSummary, string strFieName)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFieName));
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a form to contain the grid
                Table table = new Table();
                Table tablesummary = new Table();

                gv.GridLines = GridLines.Both;
                table.GridLines = gv.GridLines;

                gvSummary.GridLines = GridLines.Both;
                tablesummary.GridLines = gvSummary.GridLines;

                //  add the header row to the table
                //if (gv.HeaderRow != null)
                //{
                //    //GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                //    table.Rows.Add(gv.HeaderRow);

                //    //color the header
                //    table.Rows[0].BackColor = System.Drawing.Color.LightGray;//gv.HeaderStyle.BackColor;
                //    table.Rows[0].ForeColor = System.Drawing.Color.Red;
                //    table.Rows[0].Font.Equals(System.Drawing.FontStyle.Bold);
                //}

                //  add each of the data rows to the table

                foreach (GridViewRow row1 in gvSummary.Rows)
                {

                    if (row1.Visible == true)
                    {
                        tablesummary.Rows.Add(row1);

                        //if (row1.Cells[2].)
                        //{
                        tablesummary.Rows[row1.RowIndex].BackColor = System.Drawing.Color.Gray;//gv.HeaderStyle.BackColor;
                        tablesummary.Rows[row1.RowIndex].ForeColor = System.Drawing.Color.White;
                        tablesummary.Rows[row1.RowIndex].Font.Equals(System.Drawing.FontStyle.Bold);
                        //}


                    }
                }

                for (int j = 1; j < tablesummary.Rows.Count; j++)
                {
                    if (j == 1)
                    {
                        tablesummary.Rows[0].BackColor = System.Drawing.Color.LightGray;//gv.HeaderStyle.BackColor;
                        tablesummary.Rows[0].ForeColor = System.Drawing.Color.Red;
                        tablesummary.Rows[0].Font.Equals(System.Drawing.FontStyle.Bold);
                        //altColor = true;
                    }


                }


                foreach (GridViewRow row in gv.Rows)
                {

                    if (row.Visible == true)
                    {
                        table.Rows.Add(row);


                        if (row.Cells[0].Text.ToLower().Equals("sum"))
                        {
                            table.Rows[row.RowIndex].BackColor = System.Drawing.Color.Gray;//gv.HeaderStyle.BackColor;
                            table.Rows[row.RowIndex].ForeColor = System.Drawing.Color.White;
                            table.Rows[row.RowIndex].Font.Bold = true;
                        }


                    }
                }

                //  color the rows

                for (int i = 1; i < table.Rows.Count; i++)
                {
                    if (i == 1)
                    {
                        table.Rows[0].BackColor = System.Drawing.Color.LightGray;//gv.HeaderStyle.BackColor;
                        table.Rows[0].ForeColor = System.Drawing.Color.Red;
                        table.Rows[0].Font.Bold = true;

                    }

                    if (table.Rows[i].Cells[0].Text.ToLower().ToString() != "sum")
                    {

                        for (int k = 6; k < table.Rows[i].Cells.Count; k++)
                        {
                            int t = int.Parse(table.Rows[i].Cells[k].Text.LastIndexOf(" ").ToString()) + 1;
                            int t1 = 0;
                            if (int.Parse(table.Rows[i].Cells[k].Text.IndexOf("%").ToString()) < 0)
                            {
                                t1 = 0;
                            }
                            else
                            {
                                t1 = int.Parse(table.Rows[i].Cells[k].Text.IndexOf("%").ToString()) - t;
                            }
                            if (t > 0 && t1 > 0)
                            {

                                if (float.Parse(table.Rows[i].Cells[k].Text.Substring(t, t1).ToString()) > 100.00)
                                {
                                    table.Rows[i].Cells[k].BackColor = System.Drawing.Color.Red;
                                    table.Rows[i].Cells[k].ForeColor = System.Drawing.Color.White;

                                }

                                if (float.Parse(table.Rows[i].Cells[k].Text.Substring(t, t1).ToString()) < 100.00)
                                {
                                    table.Rows[i].Cells[k].BackColor = System.Drawing.Color.Yellow;
                                    table.Rows[i].Cells[k].ForeColor = System.Drawing.Color.Black;

                                }

                                if (float.Parse(table.Rows[i].Cells[k].Text.Substring(t, t1).ToString()) == 100.00)
                                {
                                    table.Rows[i].Cells[k].BackColor = System.Drawing.Color.LightGreen;
                                    table.Rows[i].Cells[k].ForeColor = System.Drawing.Color.Black;

                                }
                            }
                        }
                    }
                }

                //  render the table into the htmlwriter
                tablesummary.RenderControl(htw);
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }

    }
    /// <summary>
    /// Handles the PageIndexChanging1 event of the GridView1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        FillGridView();
    }

    /// <summary>
    /// Handles the Click event of the btnGo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        ddlClientCode_SelectedIndexChanged(ddlClientCode, null);
    }

    /// <summary>
    /// Handles the Click event of the btnGoAsmt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGoAsmt_Click(object sender, EventArgs e)
    {
        ddlAsmtCode_SelectedIndexChanged(ddlAsmtCode, null);
        btnProceed.Enabled = true;
    }
}