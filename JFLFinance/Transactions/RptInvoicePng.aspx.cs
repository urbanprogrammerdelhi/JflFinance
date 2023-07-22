// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptInvoicePng.aspx.cs" company="Magnon">
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
/// Class Transactions_RptInvoicePng.
/// </summary>
public partial class Transactions_RptInvoicePng : BasePage
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
            javaScript.Append("PageTitle('" + Resources.Resource.Invoice + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            if (IsReadAccess == true)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID.ToString() + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID.ToString() + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                ddlSoType.Attributes.Add("readonly", "readonly");
            }
            FillddlSoType();
        }
        lblErrorMsg.Text = "";
    }
    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == string.Empty || txtToDate.Text == string.Empty)
        {
            DisplayMessageString(lblErrorMsg, "Date can't be left blank");
            return;
        }
        gvInvoice.DataSource = null;
        gvInvoice.DataBind();
        FillGridView();
    }


    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == string.Empty || txtToDate.Text == string.Empty)
        {
            DisplayMessageString(lblErrorMsg, "Date can't be left blank");
            return;
        }
        
        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRost.GenerateInvoice(BaseLocationAutoID, DL.Common.DateFormat(txtFromDate.Text.ToString()), DL.Common.DateFormat(txtToDate.Text.ToString()),ddlSoType.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 1)
        {
            string FileName = "Inv" + txtToDate.Text + ".csv";
            ExportToCSV(ds.Tables[0], FileName);
        }
        else
        {

            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            btnExport.Enabled = false;
        }
    }

    /// <summary>
    /// Exports to CSV.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <param name="strFieName">Name of the string fie.</param>
    protected void ExportToCSV(System.Data.DataTable dt, string strFieName)
    {
        string attachment = "attachment; filename=" + strFieName;
        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.ContentType = "csv";
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
        System.Text.StringBuilder str = new System.Text.StringBuilder();

        //Write Column Headers
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            str.Append(dt.Columns[i].ColumnName);
            if (i < dt.Columns.Count - 1)
            {
                str.Append(",");
            }            
        }
        str.AppendLine();

        foreach (DataRow dr in dt.Rows)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                str.Append(dr[i].ToString());
                if (i < dt.Columns.Count - 1)
                {
                    str.Append(",");
                }
            }
            str.AppendLine();
        }
        Response.Write(str.ToString());
        Response.End();
    }

    /// <summary>
    /// Exports the specified gv.
    /// </summary>
    /// <param name="gv">The gv.</param>
    /// <param name="strFieName">Name of the string fie.</param>
    private void Export(GridView gv, string strFieName)
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

                //gvSummary.GridLines = GridLines.Both;
                //tablesummary.GridLines = gvSummary.GridLines;

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

                //foreach (GridViewRow row1 in gvSummary.Rows)
                //{

                //    if (row1.Visible == true)
                //    {
                //        tablesummary.Rows.Add(row1);

                //        //if (row1.Cells[2].)
                //        //{
                //        tablesummary.Rows[row1.RowIndex].BackColor = System.Drawing.Color.Gray;//gv.HeaderStyle.BackColor;
                //        tablesummary.Rows[row1.RowIndex].ForeColor = System.Drawing.Color.White;
                //        tablesummary.Rows[row1.RowIndex].Font.Equals(System.Drawing.FontStyle.Bold);
                //        //}


                //    }
                //}

                //for (int j = 1; j < tablesummary.Rows.Count; j++)
                //{
                //    if (j == 1)
                //    {
                //        tablesummary.Rows[0].BackColor = System.Drawing.Color.LightGray;//gv.HeaderStyle.BackColor;
                //        tablesummary.Rows[0].ForeColor = System.Drawing.Color.Red;
                //        tablesummary.Rows[0].Font.Equals(System.Drawing.FontStyle.Bold);
                //        //altColor = true;
                //    }


                //}


                //foreach (GridViewRow row in gv.Rows)
                //{

                //    if (row.Visible == true)
                //    {
                //        table.Rows.Add(row);


                //        if (row.Cells[0].Text.ToLower().Equals("sum"))
                //        {
                //            table.Rows[row.RowIndex].BackColor = System.Drawing.Color.Gray;//gv.HeaderStyle.BackColor;
                //            table.Rows[row.RowIndex].ForeColor = System.Drawing.Color.White;
                //            table.Rows[row.RowIndex].Font.Bold = true;
                //        }


                //    }
                //}

                ////  color the rows

                //for (int i = 1; i < table.Rows.Count; i++)
                //{
                //    if (i == 1)
                //    {
                //        table.Rows[0].BackColor = System.Drawing.Color.LightGray;//gv.HeaderStyle.BackColor;
                //        table.Rows[0].ForeColor = System.Drawing.Color.Red;
                //        table.Rows[0].Font.Bold = true;

                //    }

                //    if (table.Rows[i].Cells[0].Text.ToLower().ToString() != "sum")
                //    {

                //        for (int k = 6; k < table.Rows[i].Cells.Count; k++)
                //        {
                //            int t = int.Parse(table.Rows[i].Cells[k].Text.LastIndexOf(" ").ToString()) + 1;
                //            int t1 = 0;
                //            if (int.Parse(table.Rows[i].Cells[k].Text.IndexOf("%").ToString()) < 0)
                //            {
                //                t1 = 0;
                //            }
                //            else
                //            {
                //                t1 = int.Parse(table.Rows[i].Cells[k].Text.IndexOf("%").ToString()) - t;
                //            }
                //            if (t > 0 && t1 > 0)
                //            {

                //                if (float.Parse(table.Rows[i].Cells[k].Text.Substring(t, t1).ToString()) > 100.00)
                //                {
                //                    table.Rows[i].Cells[k].BackColor = System.Drawing.Color.Red;
                //                    table.Rows[i].Cells[k].ForeColor = System.Drawing.Color.White;

                //                }

                //                if (float.Parse(table.Rows[i].Cells[k].Text.Substring(t, t1).ToString()) < 100.00)
                //                {
                //                    table.Rows[i].Cells[k].BackColor = System.Drawing.Color.Yellow;
                //                    table.Rows[i].Cells[k].ForeColor = System.Drawing.Color.Black;

                //                }

                //                if (float.Parse(table.Rows[i].Cells[k].Text.Substring(t, t1).ToString()) == 100.00)
                //                {
                //                    table.Rows[i].Cells[k].BackColor = System.Drawing.Color.LightGreen;
                //                    table.Rows[i].Cells[k].ForeColor = System.Drawing.Color.Black;

                //                }
                //            }
                //        }
                //    }
                //}

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
    /// Function to Fill Sale Order Types in a DropDown.
    /// </summary>
    protected void FillddlSoType()
    {
        var objSales = new BL.Sales();
        DataSet ds = objSales.SaleOrderTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSoType.DataSource = ds.Tables[0];
            ddlSoType.DataValueField = "SaleOrderTypeCode";
            ddlSoType.DataTextField = "SaleOrderTypeDesc";
            ddlSoType.DataBind();
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlSoType.Items.Add(li);
        }
    }
    /// <summary>
    /// Fills the grid view.
    /// </summary>
    private void FillGridView()
    {

        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRost.GenerateInvoice(BaseLocationAutoID, DL.Common.DateFormat(txtFromDate.Text.ToString()), DL.Common.DateFormat(txtToDate.Text.ToString()),ddlSoType.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 1)
        {
            lblErrorMsg.Text = "";

            gvInvoice.DataSource = ds.Tables[0];
            gvInvoice.DataBind();

            btnExport.Enabled = true;
        }
        else
        {

            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            btnExport.Enabled = false;
        }
    }
}