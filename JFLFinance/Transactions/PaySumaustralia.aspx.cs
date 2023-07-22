// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="PaySumaustralia.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

/// <summary>
/// Class Transactions_PaySumaustralia.
/// </summary>
public partial class Transactions_PaySumaustralia : BasePage //System.Web.UI.Page
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

    #region Page Load
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
            javaScript.Append("PageTitle('" + Resources.Resource.PaySum + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {

                ImgFDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + TxtFDate.ClientID.ToString() + "');";
                ImgTDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + TxtTDate.ClientID.ToString() + "');";

                FillExistingRules();

                TxtFDate.Text = FirstDateOfCurrentMonth_Get();
                TxtTDate.Text = LastDateOfCurrentMonth_Get();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }


            txtYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            txtYear.MaxLength = 4;
            txtYear.Attributes["onkeyup"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum.ToString() + ");";

            txtYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            FillWeek();

        }
        FillGrid();
    }
    #endregion

    #region Fill Controls

    /// <summary>
    /// Fills the existing rules.
    /// </summary>
    protected void FillExistingRules()
    {

        BL.BusinessRule objBR = new BL.BusinessRule();
        DataSet ds = new DataSet();
        ds = objBR.BusinessRuleGet("", int.Parse(BaseLocationAutoID));
        ddlBR.DataSource = ds.Tables[1];
        ddlBR.DataValueField = "PaysumCode";
        ddlBR.DataTextField = "PaysumCodeDesc";
        ddlBR.DataBind();

    }

    /// <summary>
    /// Fills the week.
    /// </summary>
    protected void FillWeek()
    {
        string selectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text);
        DateTime startDate = DateTime.Parse(selectedMonthStartDate);

        BL.BusinessRule objBR = new BL.BusinessRule();
        DataSet ds = new DataSet();

        ds = objBR.PayPeriodCollectionGet(ddlBR.SelectedValue.ToString());
        DataRow[] result = ds.Tables[0].Select("FromDate >= '" + startDate + "'");
        startDate = DateTime.Parse(result[0]["FromDate"].ToString());

        if (startDate.AddDays(-7).Month == startDate.Month)
        {
            startDate = startDate.AddDays(-7);
        }

        TxtFDate.Text = startDate.ToString("dd-MMM-yyyy");
        TxtTDate.Text = startDate.AddDays(6).ToString("dd-MMM-yyyy");

        bool loopEnd = true;
        ListItem li;
        ddlWeek.Items.Clear();
        while (loopEnd)
        {

            li = new ListItem();
            li.Text = (ddlWeek.Items.Count + 1).ToString();
            li.Value = startDate.ToString();
            ddlWeek.Items.Add(li);

            startDate = startDate.AddDays(7);

            if (startDate.Month > int.Parse(ddlMonth.SelectedValue.ToString()) || startDate.Year > int.Parse(txtYear.Text))
            {
                loopEnd = false;
            }
        }



    }

    #endregion

    #region events

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillWeek();
    }

    /// <summary>
    /// Handles the TextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        if (txtYear.Text == "" || txtYear.Text.Length != 4)
        {
            txtYear.Text = DateTime.Now.Year.ToString();
        }

        DL.Guard.ArgumentInRange<int>(int.Parse(txtYear.Text), 1900, 2050, "year");
        FillWeek();
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlWeek control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        TxtFDate.Text = DateTime.Parse(ddlWeek.SelectedValue.ToString()).ToString("dd-MMM-yyyy");
        TxtTDate.Text = DateTime.Parse(ddlWeek.SelectedValue.ToString()).AddDays(6).ToString("dd-MMM-yyyy");

    }

    /// <summary>
    /// Handles the TextChanged event of the TxtFDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtFDate_TextChanged(object sender, EventArgs e)
    {
        BL.Common objc = new BL.Common();
        if (!objc.IsValidDate(TxtFDate.Text))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            return;
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the TxtTDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtTDate_TextChanged(object sender, EventArgs e)
    {
        BL.Common objc = new BL.Common();
        if (!objc.IsValidDate(TxtTDate.Text))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            return;
        }

    }


    #endregion



    /// <summary>
    /// Handles the Click event of the btnViewPaysum control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewPaysum_Click(object sender, EventArgs e)
    {

        FillGrid();

    }

    /// <summary>
    /// Fills the grid.
    /// </summary>
    protected void FillGrid()
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();

        ds = objRoster.GeneratePaysumAustralia(ddlBR.SelectedValue, TxtFDate.Text, TxtTDate.Text, "1");
        PaysumGridView1.DataSource = ds;
        PaysumGridView1.DataBind();
    }


    #region generate .csv file

    /// <summary>
    /// Handles the Click event of the btnGeneratePaysum control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGeneratePaysum_Click(object sender, EventArgs e)
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRoster.GeneratePaysumAustralia(ddlBR.SelectedValue, TxtFDate.Text, TxtTDate.Text, "2");

        StringBuilder str = new StringBuilder();


        DataTable objDt = (DataTable)ds.Tables[0];
        int NoOfColumn = objDt.Columns.Count;
        //Create Header
       // str.Append("//Ingenuity Leave Transaction Import for Period Start Date " + TxtFDate.Text + " to Period End Date " + TxtTDate.Text + " . Records to be imported.//");
       // str.AppendLine();
        //Create Data
        foreach (DataRow dr in objDt.Rows)
        {
            for (int i = 0; i < NoOfColumn; i++)
            {
                str.Append(dr[i].ToString());
                if (i < NoOfColumn - 1)
                {
                    str.Append(",");
                }
            }
            str.AppendLine();
        }
        //Create Footer
       // str.Append("//End of Leave Transaction Import.//");
       // str.AppendLine();
        Session["str"] = str.ToString();
        string newId = System.Guid.NewGuid().ToString();
        string filename = @"C:\Attachments\LVCsv_" + BaseLocationAutoID.ToString() + newId + ".csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.Write(str.ToString());
        tw.Close();
        tw.Dispose();

        Response.Redirect("CSVGenerator.aspx");

        //this.Page.RegisterClientScriptBlock('Msg', '<script language=javascript' type='text/javascript'> alert('" + filename + " Generated'"');

    }

    #endregion
}
