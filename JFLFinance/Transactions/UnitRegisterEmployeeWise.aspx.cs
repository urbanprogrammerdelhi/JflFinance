// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="UnitRegisterEmployeeWise.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_UnitRegisterEmployeeWise.
/// </summary>
public partial class Transactions_UnitRegisterEmployeeWise : BasePage
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

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !IsCallback)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.PaySum; }

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.UnitRegisterEmployeeWise + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            if (IsReadAccess == true)
            {

                Panel2.Visible = false;
                //ImgFDate.Attributes.Add(
                ImgFDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + TxtFDate.ClientID.ToString() + "');";
                ImgTDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + TxtTDate.ClientID.ToString() + "');";

                TxtFDate.Text = FirstDateOfCurrentMonth_Get();
                TxtTDate.Text = DateTime.Parse(TxtFDate.Text).AddDays(double.Parse("6")).ToString("dd-MMM-yyyy");
                // TxtFDate.Text = "02-May-2010";
                // TxtTDate.Text = "08-May-2010";
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

            FillDataGrid();

            ApplyLayout(0);

        }
        else
        {

            FillDataGrid();

            ApplyLayout(0);
        }

    }

    /// <summary>
    /// Applies the layout.
    /// </summary>
    /// <param name="layoutIndex">Index of the layout.</param>
    void ApplyLayout(int layoutIndex)
    {
        grid.BeginUpdate();

        try
        {
            grid.CollapseAll();
            switch (layoutIndex)
            {
                case 0:
                    // grid.GroupBy((GridViewDataColumn)grid.Columns["AssignmentCode"]);
                    //grid. ((GridViewDataColumn)grid.Columns["Post"]);
                    //         grid.GroupBy((GridViewDataColumn)grid.Columns["Type"]);
                    //       grid.GroupBy((GridViewDataColumn)grid.Columns["Shift"]);

                    break;
                //case 1:
                //    grid.GroupBy((GridViewDataColumn)grid.Columns["Country"]);
                //    grid.GroupBy((GridViewDataColumn)grid.Columns["City"]);
                //    break;
                //case 2:
                //    grid.GroupBy((GridViewDataColumn)grid.Columns["CompanyName"]);
                //    break;
            }
        }
        finally
        {
            grid.EndUpdate();
        }
        grid.ExpandAll();

    }

    /// <summary>
    /// Handles the TextChanged event of the TxtFDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtFDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(TxtFDate, lblErrorMsg);
    }
    /// <summary>
    /// Handles the TextChanged event of the TxtTDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtTDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(TxtTDate, lblErrorMsg);          
    }

    /// <summary>
    /// Handles the submit event of the btn control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btn_submit(object sender, EventArgs e)
    {
        //ASPxGridViewExporter1.g = "grid";
        //ASPxGridViewExporter1.WriteCsvToResponse();
        //   ASPxGridViewExporter1.WriteXlsToResponse();
        

    }
    /// <summary>
    /// Fills the data grid.
    /// </summary>
    protected void FillDataGrid()
    {
        Panel2.Visible = true;
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRoster.UnitRegisterEmployeeBreakup(BaseCompanyCode, BaseLocationCode, TxtFDate.Text, TxtTDate.Text);
        grid.DataSource = ds;
        grid.DataBind();

    }

    /// <summary>
    /// Handles the Click event of the btnGenerateData control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGenerateData_Click(object sender, EventArgs e)
    {
        //  FillDataGrid();
        //  ApplyLayout(0);
    }

}
