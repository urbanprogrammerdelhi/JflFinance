// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SOItemDeptPattren.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_SOItemDeptPattren.
/// </summary>
public partial class Sales_SOItemDeptPattren : BasePage //System.Web.UI.Page
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
    #region Page functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strGlbSoNo = "";
            string strGlbSOAmendNO = "";
            string strGlbAsmtID = "";
            string strGlbSOStatus = "";
            string strGlbIsMAXSOAmendNo = "";
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.DeploymentDays;
            //}
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.DeploymentDays + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {

                if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"] != null && Request.QueryString["SOAmendNO"] != null && Request.QueryString["AsmtID"] != null && Request.QueryString["SOStatus"] != null && Request.QueryString["IsMAXSOAmendNo"] != null && Request.QueryString["Qty"] != null && Request.QueryString["Rate"] != null && Request.QueryString["InvoiceType"] != null && Request.QueryString["Billable"] != null && Request.QueryString["Active"] != null && Request.QueryString["RemainingDays"] != null && Request.QueryString["DaysInMonth"] != null && Request.QueryString["ItemTypeCode"] != null)
                {
                    hfLocationAutoId.Value = Request.QueryString["LocationAutoID"].ToString();
                    strGlbSoNo = Request.QueryString["SoNo"].ToString();
                    strGlbSOAmendNO = Request.QueryString["SOAmendNO"].ToString();
                    strGlbAsmtID = Request.QueryString["AsmtID"].ToString();
                    strGlbSOStatus = Request.QueryString["SOStatus"].ToString(); ;
                    hfIsMAXSOAmendNo.Value = Request.QueryString["IsMAXSOAmendNo"].ToString();
                    hfQty.Value = Request.QueryString["Qty"].ToString();
                    hfRate.Value = Request.QueryString["Rate"].ToString();
                    hfDaysInMonth.Value = Request.QueryString["DaysInMonth"].ToString();
                    hfIsBillable.Value = Request.QueryString["Billable"].ToString();
                    hfRemainingDays.Value = Request.QueryString["RemainingDays"].ToString();
                    HFItemTypeCode.Value = Request.QueryString["ItemTypeCode"].ToString();
                    HFSoItemActiveStatus.Value = Request.QueryString["Active"].ToString();
                    hfBillingPattern.Value = Request.QueryString["InvoiceType"].ToString();
                    lblSoNo.Text = strGlbSoNo;
                    lblSOAmendNo.Text = strGlbSOAmendNO;
                    lblAsmtID.Text = strGlbAsmtID;
                    lblSoStatus.Text = strGlbSOStatus;
                    FillgvPattren(hfLocationAutoId.Value, strGlbSoNo, strGlbSOAmendNO, strGlbAsmtID, HFItemTypeCode.Value);
                   
                    if (!hfIsMAXSOAmendNo.Value.Equals("MAX") || (hfIsMAXSOAmendNo.Value.Equals("MAX") && (strGlbSOStatus.Equals(Resources.Resource.Authorized.ToString()) || strGlbSOStatus.Equals(Resources.Resource.ShortClosed.ToString()))))
                    {
                        btnSave.Enabled = false;
                    }

                    if (bool.Parse(HFSoItemActiveStatus.Value) == false)
                    {
                        btnSave.Visible = false;
                        gvPattren.Enabled = false;
                    }
                    if (hfBillingPattern.Value.Trim().ToLower() != "Fixed".ToLower().Trim())
                    {
                        txtTotalRate.Attributes.Add("readonly", "readonly");
                       
                    }
                    else
                    {
                        if (strGlbSOStatus == strStatusAuthorized)
                        {
                            txtTotalRate.Attributes.Add("readonly", "readonly");
                        }
                    }

                }
                else
                {
                    Response.Redirect("../UserManagement/Home.aspx");
                }
            }
        }
    }
    /// <summary>
    /// Calculates the total rate.
    /// </summary>
    /// <param name="BillingPattern">The billing pattern.</param>
    private void CalculateTotalRate(string BillingPattern)
    {
        decimal averageDaysInMonth = decimal.Parse("0");
        for (int i = 0; i < gvPattren.Rows.Count; i++)
        {
            HiddenField lblExcludedDays = (HiddenField)gvPattren.Rows[i].FindControl("lblExcludedDays");
            averageDaysInMonth = averageDaysInMonth + decimal.Parse(lblExcludedDays.Value);
        }
        HFActualDaysInMonth.Value = averageDaysInMonth.ToString();

        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.SaleOrderItemRateGet(lblSoNo.Text, BaseLocationAutoID, lblAsmtID.Text,lblSOAmendNo.Text, HFItemTypeCode.Value);
        if (bool.Parse(hfIsBillable.Value) == true && bool.Parse(HFSoItemActiveStatus.Value) == true)
        {
            if (BillingPattern != "Fixed".ToLower())
            {
                txtTotalRate.Text = GetValueAsPerSystemParameters(((decimal.Parse(hfQty.Value) * decimal.Parse(hfRate.Value) / decimal.Parse(hfDaysInMonth.Value)) * averageDaysInMonth).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
            }
            else
            {
                if (ds.Tables[0].Rows[0]["TotalRate"].ToString() != "")
                {
                    txtTotalRate.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["TotalRate"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                    
                }
                else
                {
                    txtTotalRate.Text = GetValueAsPerSystemParameters((decimal.Parse(hfQty.Value) * decimal.Parse(hfRate.Value)).ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                }
            }
        }
        else
        {
            txtTotalRate.Text = "0";
        }
    }
    /// <summary>
    /// Fillgvs the pattren.
    /// </summary>
    /// <param name="strLocationAutoID">The string location automatic identifier.</param>
    /// <param name="strSoNo">The string so no.</param>
    /// <param name="strSOAmendNO">The string so amend no.</param>
    /// <param name="strAsmtID">The string asmt identifier.</param>
    /// <param name="strItemTypeCode">The string item type code.</param>
    protected void FillgvPattren(string strLocationAutoID, string strSoNo, string strSOAmendNO, string strAsmtID, string strItemTypeCode)
    {
        BL.Sales objsales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objsales.SaleOrderItemDeploymentPatternGet(strLocationAutoID, strSoNo, strSOAmendNO, strAsmtID, strItemTypeCode);
        gvPattren.DataSource = ds.Tables[0];
        gvPattren.DataBind();
        CalculateTotalRate(hfBillingPattern.Value.Trim().ToLower());
    }
    #endregion
    #region Buttons Event
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable table = new DataTable("SODeptPattern");
        DataColumn column;
        DataRow row;
        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Int16");
        column.ColumnName = "WeekNo";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "SUN";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "MON";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "TUE";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "WED";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "THU";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "FRI";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "SAT";
        table.Columns.Add(column);

        BL.Sales objSales = new BL.Sales();
        foreach (GridViewRow gvRow in gvPattren.Rows)
        {
            Label lblgvWeekNo = (Label)gvRow.FindControl("lblgvWeekNo");
            CheckBox cbSun = (CheckBox)gvRow.FindControl("cbSun");
            CheckBox cbMon = (CheckBox)gvRow.FindControl("cbMon");
            CheckBox cbTue = (CheckBox)gvRow.FindControl("cbTue");
            CheckBox cbWed = (CheckBox)gvRow.FindControl("cbWed");
            CheckBox cbThu = (CheckBox)gvRow.FindControl("cbThu");
            CheckBox cbFri = (CheckBox)gvRow.FindControl("cbFri");
            CheckBox cbSat = (CheckBox)gvRow.FindControl("cbSat");

            row = table.NewRow();
            row["WeekNo"] = Int16.Parse(lblgvWeekNo.Text.ToString());
            row["SUN"] = Boolean.Parse(cbSun.Checked.ToString());
            row["MON"] = Boolean.Parse(cbMon.Checked.ToString());
            row["TUE"] = Boolean.Parse(cbTue.Checked.ToString());
            row["WED"] = Boolean.Parse(cbWed.Checked.ToString());
            row["THU"] = Boolean.Parse(cbThu.Checked.ToString());
            row["FRI"] = Boolean.Parse(cbFri.Checked.ToString());
            row["SAT"] = Boolean.Parse(cbSat.Checked.ToString());
            table.Rows.Add(row);
        }

        DataSet ds = new DataSet();
        ds = objSales.SaleOrderItemDeploymentPatternUpdate(hfLocationAutoId.Value.ToString(), lblSoNo.Text, lblSOAmendNo.Text, lblAsmtID.Text, table, HFItemTypeCode.Value, BaseUserID.ToString());
        if (hfBillingPattern.Value.Trim().ToLower() != "Fixed".Trim().ToLower())
        {
            FillgvPattren(hfLocationAutoId.Value.ToString(), lblSoNo.Text, lblSOAmendNo.Text, lblAsmtID.Text, HFItemTypeCode.Value);
        }
        //hfDaysInMonth.Value, txtTotalRate.Text,
        DataSet dsDaysInMonthUpdate = new DataSet();
        if (hfBillingPattern.Value.Trim().ToLower() != "Fixed".Trim().ToLower())
        {
            dsDaysInMonthUpdate = objSales.SaleOrderItemDaysInMonthUpdate(BaseLocationAutoID, lblSoNo.Text, lblSOAmendNo.Text, lblAsmtID.Text, HFItemTypeCode.Value, HFActualDaysInMonth.Value, txtTotalRate.Text, BaseUserID);
        }

        else
        {
            dsDaysInMonthUpdate = objSales.SaleOrderItemDaysInMonthUpdate(BaseLocationAutoID, lblSoNo.Text, lblSOAmendNo.Text, lblAsmtID.Text, HFItemTypeCode.Value, hfDaysInMonth.Value, txtTotalRate.Text, BaseUserID);
        }
    }
    #endregion
    #region GridView Events
    /// <summary>
    /// Handles the RowDataBound event of the gvPattren control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvPattren_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox cbAllSun = (CheckBox)e.Row.FindControl("cbAllSun");
            CheckBox cbAllMon = (CheckBox)e.Row.FindControl("cbAllMon");
            CheckBox cbAllTue = (CheckBox)e.Row.FindControl("cbAllTue");
            CheckBox cbAllWed = (CheckBox)e.Row.FindControl("cbAllWed");
            CheckBox cbAllThu = (CheckBox)e.Row.FindControl("cbAllThu");
            CheckBox cbAllFri = (CheckBox)e.Row.FindControl("cbAllFri");
            CheckBox cbAllSat = (CheckBox)e.Row.FindControl("cbAllSat");
            if (IsModifyAccess == false)
            {
                cbAllSun.Enabled = false;
                cbAllMon.Enabled = false;
                cbAllTue.Enabled = false;
                cbAllWed.Enabled = false;
                cbAllThu.Enabled = false;
                cbAllFri.Enabled = false;
                cbAllSat.Enabled = false;
            }
            if (!hfIsMAXSOAmendNo.Value.ToString().Equals("MAX") || (hfIsMAXSOAmendNo.Value.ToString().Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString()))))
            {
                cbAllSun.Enabled = false;
                cbAllMon.Enabled = false;
                cbAllTue.Enabled = false;
                cbAllWed.Enabled = false;
                cbAllThu.Enabled = false;
                cbAllFri.Enabled = false;
                cbAllSat.Enabled = false;
            }

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            CheckBox cbSun = (CheckBox)e.Row.FindControl("cbSun");
            CheckBox cbMon = (CheckBox)e.Row.FindControl("cbMon");
            CheckBox cbTue = (CheckBox)e.Row.FindControl("cbTue");
            CheckBox cbWed = (CheckBox)e.Row.FindControl("cbWed");
            CheckBox cbThu = (CheckBox)e.Row.FindControl("cbThu");
            CheckBox cbFri = (CheckBox)e.Row.FindControl("cbFri");
            CheckBox cbSat = (CheckBox)e.Row.FindControl("cbSat");
            if (IsModifyAccess == false)
            {
                cbSun.Enabled = false;
                cbMon.Enabled = false;
                cbTue.Enabled = false;
                cbWed.Enabled = false;
                cbThu.Enabled = false;
                cbFri.Enabled = false;
                cbSat.Enabled = false;
            }
            if (!hfIsMAXSOAmendNo.Value.ToString().Equals("MAX") || (hfIsMAXSOAmendNo.Value.ToString().Equals("MAX") && (lblSoStatus.Text.Equals(Resources.Resource.Authorized.ToString()) || lblSoStatus.Text.Equals(Resources.Resource.ShortClosed.ToString()))))
            {
                cbSun.Enabled = false;
                cbMon.Enabled = false;
                cbTue.Enabled = false;
                cbWed.Enabled = false;
                cbThu.Enabled = false;
                cbFri.Enabled = false;
                cbSat.Enabled = false;
            }
            Label lblHoursInWeek = (Label)e.Row.FindControl("lblHoursInWeek");
            Label lblgvWeekNo = (Label)e.Row.FindControl("lblgvWeekNo");
            HiddenField lblExcludedDays = (HiddenField)e.Row.FindControl("lblExcludedDays");
            decimal decNoofDaysinWeek = decimal.Parse("0");
            decimal daysPerWeek = decimal.Parse("0");
            decimal averageDaysInWeek = decimal.Parse("0");
            if (cbSun.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbMon.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbTue.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbWed.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbThu.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbFri.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }
            if (cbSat.Checked == true)
            {
                decNoofDaysinWeek = decNoofDaysinWeek + 1;
                daysPerWeek = daysPerWeek + 1;
            }

            if (int.Parse(lblgvWeekNo.Text) < 5)
            {
                averageDaysInWeek = decNoofDaysinWeek;
            }
            else
            {
                averageDaysInWeek = (decimal.Parse(hfRemainingDays.Value) / 7) * decNoofDaysinWeek;
            }
            lblExcludedDays.Value = averageDaysInWeek.ToString();
        }
    }
    #endregion
}
