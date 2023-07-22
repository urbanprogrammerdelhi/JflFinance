// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 01-22-2014
//
// Last Modified By : 
// Last Modified On : 03-31-2014
// DESCRIPTION : Reports_InvoiceReportCyprus is used to handle the Cyprus Invoice event/actions and communicate to and UI Screen.
// ***********************************************************************
// <copyright file="InvoiceReportCyprus.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Web;
using Telerik.Web.UI;
using System.Text;
using ListItem = System.Web.UI.WebControls.ListItem;


/// <summary>
/// Class Reports_InvoiceReportCyprus.
/// </summary>
public partial class Reports_InvoiceReportCyprus : BasePage
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
        try
        {
            if (!IsPostBack && IsReadAccess)
            {
                txtYear.Text = Convert.ToString(DateTime.Now.Year);
                ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
                //FillCompany();
                FillHrLocation();
                FillInvoiceType();
                btnViewReport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            // lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function call on View Report Button click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        try
        {
            var dt = GenerateHeader();
            if (dt != null && dt.Rows.Count > 0)
            {
                GenerateTextFile(dt);
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function call on View Report Button click.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnPDFReport_Click(object sender, EventArgs e)
    {
        try
        {
            var dt = GeneratePDFHeader();
            if (dt != null && dt.Rows.Count > 0)
            {
                GeneratePDFFile(dt);
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function used to generate Header Output based on input invoice data.
    /// </summary>
    /// <returns>DataTable.</returns>
    public DataTable GenerateHeader()
    {
        var objRpt = new DL.Report();
        if (ddlHrLocation.SelectedItem != null)
        {
            if (ddlLocation.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(txtYear.Text))
                {
                    string startDate = ddlMonth.SelectedItem.Value + "/" + "01" + "/" + txtYear.Text;
                    DateTime dtStartDate = Convert.ToDateTime(startDate);
                    DateTime dtEndDate = dtStartDate.AddMonths(1).AddDays(-1);
                    string locationAutoId = ddlLocation.SelectedItem.Value;
                    if (ddlLocation.SelectedItem.Value == @"All")
                    {
                        locationAutoId = @"0";
                    }

                    //Added by  for Multiselect customer dropdown
                    var clientCodes = ddlCustomer.CheckedItems;

                    string strCust = string.Empty;
                    string locationCode = string.Empty;
                    if (clientCodes.Count > 0)
                    {
                        foreach (var item in clientCodes)
                        {
                            strCust = strCust + item.Value.ToString() + ",";
                        }
                    }

                    DataTable dt = objRpt.InvoiceTextHeaderOutput(BaseCompanyCode, ddlHrLocation.SelectedItem.Value,
                                                                  locationAutoId, ddlAreaId.SelectedItem.Value,
                                                                  strCust,
                                                                  ddlSoNo.SelectedItem.Value,
                                                                  ddlInvoiceType.SelectedItem.Value, dtStartDate,
                                                                  dtEndDate);
                    return dt;
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.PleaseSelectBranch;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.PleaseSelectDivision;
        }
        return null;
    }

    /// <summary>
    /// Function used to generate Header Output based on input invoice data.
    /// </summary>
    /// <returns>DataTable.</returns>
    public DataTable GeneratePDFHeader()
    {
        var objRpt = new DL.Report();
        if (ddlHrLocation.SelectedItem != null)
        {
            if (ddlLocation.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(txtYear.Text))
                {
                    string startDate = ddlMonth.SelectedItem.Value + "/" + "01" + "/" + txtYear.Text;
                    DateTime dtStartDate = Convert.ToDateTime(startDate);
                    DateTime dtEndDate = dtStartDate.AddMonths(1).AddDays(-1);
                    string locationAutoId = ddlLocation.SelectedItem.Value;
                    if (ddlLocation.SelectedItem.Value == @"All")
                    {
                        locationAutoId = @"0";
                    }

                    //Added by  for Multiselect customer dropdown
                    var clientCodes = ddlCustomer.CheckedItems;

                    string strCust = string.Empty;
                    string locationCode = string.Empty;
                    if (clientCodes.Count > 0)
                    {
                        foreach (var item in clientCodes)
                        {
                            strCust = strCust + item.Value.ToString() + ",";
                        }
                    }

                    DataTable dt = objRpt.InvoicePDFHeaderOutput(BaseCompanyCode, ddlHrLocation.SelectedItem.Value,
                                                                  locationAutoId, ddlAreaId.SelectedItem.Value,
                                                                  strCust,
                                                                  ddlSoNo.SelectedItem.Value,
                                                                  ddlInvoiceType.SelectedItem.Value, dtStartDate,
                                                                  dtEndDate);
                    return dt;
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.PleaseSelectBranch;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.PleaseSelectDivision;
        }
        return null;
    }

    /// <summary>
    /// Function used to generate text file based on retrieved invoice data.
    /// </summary>
    /// <param name="dt">The dt.</param>
    public void GenerateTextFile(DataTable dt)
    {
        //For Get Footer Output Records
        string startDate = ddlMonth.SelectedItem.Value + "/" + "01" + "/" + txtYear.Text;
        DateTime dtStartDate = Convert.ToDateTime(startDate);
        DateTime dtEndDate = dtStartDate.AddMonths(1).AddDays(-1);
        if (string.IsNullOrEmpty(txtVat.Text))
        {
            txtVat.Text = @"0";
        }
        string vat = Convert.ToDouble(Convert.ToDouble(txtVat.Text) / 100).ToString();

        string period = @"00" + ddlMonth.SelectedItem.Value + txtYear.Text;
        if (ddlMonth.SelectedItem.Value.Length > 1)
        {
            period = @"0" + ddlMonth.SelectedItem.Value + txtYear.Text;
        }
        string locationAutoId = ddlLocation.SelectedItem.Value;
        if (ddlLocation.SelectedItem.Value == @"All")
        {
            locationAutoId = @"0";
        }
        var objRpt = new DL.Report();
        //End

        //For Header Section Output Length
        var maxLengths = new int[dt.Columns.Count];
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            maxLengths[i] = dt.Columns[i].ColumnName.Length;
            foreach (DataRow row in dt.Rows)
            {
                if (!row.IsNull(i))
                {
                    int length = row[i].ToString().Length;

                    if (length > maxLengths[i])
                    {
                        maxLengths[i] = length;
                    }
                }
            }
        }
        //End

        var sb = new StringBuilder();
        foreach (DataRow row in dt.Rows)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (!row.IsNull(i) && i != dt.Columns.Count - 1)
                {
                    sb.Append(Convert.ToString(row[i]) + ";");
                }
                else
                {
                    sb.Append(Convert.ToString(row[i]) + " ");
                }
            }
            sb.AppendLine();
            //Footer Output Section
            DataTable dtFooter = objRpt.InvoiceTextFooterOutput(BaseCompanyCode, ddlHrLocation.SelectedItem.Value,
                                                                locationAutoId, ddlAreaId.SelectedItem.Value,
                                                                row.ItemArray[3].ToString(), row.ItemArray[5].ToString(),
                                                                ddlInvoiceType.SelectedItem.Value, period,
                                                                dtStartDate, dtEndDate, vat);
            if (dtFooter != null && dtFooter.Rows.Count > 0)
            {
                //For Footer Section Output Length
                var maxFooterLengths = new int[dtFooter.Columns.Count];
                for (int i = 0; i < dtFooter.Columns.Count - 1; i++)
                {
                    maxFooterLengths[i] = dtFooter.Columns[i].ColumnName.Length;
                    foreach (DataRow rowFooter in dtFooter.Rows)
                    {
                        if (!rowFooter.IsNull(i))
                        {
                            int lengthFooter = rowFooter[i].ToString().Length;

                            if (lengthFooter > maxFooterLengths[i])
                            {
                                maxFooterLengths[i] = lengthFooter;
                            }
                        }
                    }
                }
                //End

                foreach (DataRow rowFooter in dtFooter.Rows)
                {
                    for (int i = 0; i < dtFooter.Columns.Count - 1; i++)
                    {
                        if (!rowFooter.IsNull(i) && i != dtFooter.Columns.Count - 2)
                        {
                            sb.Append(Convert.ToString(rowFooter[i]) + ";");
                        }
                        else
                        {
                            sb.Append(Convert.ToString(rowFooter[i]) + " ");
                        }
                    }
                    sb.AppendLine();
                }
                //Footer Item Output Section
                DataTable dtFooterItem = objRpt.InvoiceTextFooterItemOutput(BaseCompanyCode,
                                                                            ddlHrLocation.SelectedItem.Value,
                                                                            locationAutoId,
                                                                            ddlAreaId.SelectedItem.Value,
                                                                            row.ItemArray[3].ToString(),
                                                                            row.ItemArray[5].ToString(),
                                                                            ddlInvoiceType.SelectedItem.Value,
                                                                            period, dtStartDate, dtEndDate, vat);

                if (dtFooterItem != null && dtFooterItem.Rows.Count > 0)
                {
                    //For Footer Item Section Output Length
                    var maxFooterItemLengths = new int[dtFooterItem.Columns.Count];
                    for (int i = 0; i < dtFooterItem.Columns.Count; i++)
                    {
                        maxFooterItemLengths[i] = dtFooterItem.Columns[i].ColumnName.Length;
                        foreach (DataRow rowFooterItem in dtFooterItem.Rows)
                        {
                            if (!rowFooterItem.IsNull(i))
                            {
                                int lengthFooterItem = rowFooterItem[i].ToString().Length;

                                if (lengthFooterItem > maxFooterItemLengths[i])
                                {
                                    maxFooterItemLengths[i] = lengthFooterItem;
                                }
                            }
                        }
                    }
                    //End

                    foreach (DataRow rowFooterItem in dtFooterItem.Rows)
                    {
                        for (int i = 0; i < dtFooterItem.Columns.Count; i++)
                        {
                            if (!rowFooterItem.IsNull(i) && i != dtFooterItem.Columns.Count - 1)
                            {
                                sb.Append(Convert.ToString(rowFooterItem[i]) + ";");
                            }
                            else
                            {
                                sb.Append(Convert.ToString(rowFooterItem[i]) + " ");
                            }
                        }
                        sb.AppendLine();
                    }
                }
                //End
            }
            //End
        }
        //Process.Start(filePath);
        var text = sb.ToString();
        Response.Clear();
        Response.ClearHeaders();

        Response.AddHeader("Content-Length", text.Length.ToString());
        Response.ContentType = "text/plain";
        Response.AppendHeader("content-disposition", "attachment;filename=\"" + "CyprusInvoiceReport" + ".txt\"");

        Response.Write(text);
        //Added Code to Clear the Cache and End the Response
        //HttpContext.Current.ApplicationInstance.CompleteRequest();
        Response.End();
        Response.Flush();
    }

    /// <summary>
    /// Function used to generate PDF file based on retrieved invoice data.
    /// </summary>
    /// <param name="dt">The dt.</param>
    public void GeneratePDFFile(DataTable dt)
    {
        //Declare Tables
        DataTable dtFooter = null;
        DataTable dtFooterItem = null;
        //End

        //For Get Footer Output Records
        string startDate = ddlMonth.SelectedItem.Value + "/" + "01" + "/" + txtYear.Text;
        DateTime dtStartDate = Convert.ToDateTime(startDate);
        DateTime dtEndDate = dtStartDate.AddMonths(1).AddDays(-1);
        if (string.IsNullOrEmpty(txtVat.Text))
        {
            txtVat.Text = @"0";
        }
        string vat = Convert.ToDouble(Convert.ToDouble(txtVat.Text) / 100).ToString();

        string period = @"00" + ddlMonth.SelectedItem.Value + txtYear.Text;
        if (ddlMonth.SelectedItem.Value.Length > 1)
        {
            period = @"0" + ddlMonth.SelectedItem.Value + txtYear.Text;
        }
        string locationAutoId = ddlLocation.SelectedItem.Value;
        if (ddlLocation.SelectedItem.Value == @"All")
        {
            locationAutoId = @"0";
        }
        var objRpt = new DL.Report();
        //End

        //Added For PDF Data Report
        using (var memoryStream = new MemoryStream())
        {
            var document = new Document( PageSize.A4.Rotate(), 40f, 40f, 20f, 20f);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            var normalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            Color color = null;

            // Open the Document for writing
            document.Open();

            // Font Style for different Labels
            var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var colHdgFont = FontFactory.GetFont("Arial", 9, Font.BOLD);
            var rowFont = FontFactory.GetFont("Arial", 9, Font.NORMAL);

            // Added Heading Title
            var title = new Paragraph(Resources.Resource.InvoiceReport, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            //Company Logo
            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/logoReport.jpg"));
            logo.SetAbsolutePosition(460, 780);
            document.Add(logo);
            //End

            for (var dtHdr = 0; dtHdr < dt.Rows.Count; dtHdr++)
            {
                //Table Format for Record print.
                //Header Table
                table = new PdfPTable(5)
                {
                    TotalWidth = 500f,
                    LockedWidth = true,
                    HorizontalAlignment = 0,
                    SpacingBefore = 15,
                    SpacingAfter = 5
                };

                table.DefaultCell.Border = 0;
                //table.SetWidths(new float[] { 8f, 10f, 10f, 10f, 10f, 8f });
                table.SetWidths(new float[] { 10f, 12f, 15f, 12f, 10f });
                //End

                // Added Table Column Heading for Header Details
                table.AddCell(new Phrase(Resources.Resource.Date, colHdgFont));
                table.AddCell(new Phrase(Resources.Resource.CustomerCode, colHdgFont));
                table.AddCell(new Phrase(Resources.Resource.CustomerName, colHdgFont));
                table.AddCell(new Phrase(Resources.Resource.SONo, colHdgFont));
               // table.AddCell(new Phrase(Resources.Resource.Contract, colHdgFont));
                table.AddCell(new Phrase(Resources.Resource.MonthYear, colHdgFont));
                //End

                //Added Row Header Data Records.
                table.AddCell(new Phrase(Convert.ToString(dt.Rows[dtHdr]["OrderDate"]), rowFont));
                table.AddCell(new Phrase(Convert.ToString(dt.Rows[dtHdr]["CustomerCode"]), rowFont));
                table.AddCell(new Phrase(Convert.ToString(dt.Rows[dtHdr]["CustomerName"]), rowFont));
                table.AddCell(new Phrase(Convert.ToString(dt.Rows[dtHdr]["SaleOrderNo"]), rowFont));
               // table.AddCell(new Phrase(Convert.ToString(dt.Rows[dtHdr]["ContractName"]), rowFont));
                table.AddCell(new Phrase(Convert.ToString(dt.Rows[dtHdr]["MonthYear"]), rowFont));
                //End

                //Added Table in Document
                document.Add(table);
                //End

                //Footer Detail Table
                var innerTable = new PdfPTable(10)
                {
                    TotalWidth = 680f,
                    LockedWidth = true,
                    HorizontalAlignment = 0,
                    SpacingBefore = 0,
                    SpacingAfter = 2
                };
                innerTable.DefaultCell.Border = 0;
                innerTable.SetWidths(new float[] { 8f, 10f, 5f,5f, 15f,10f, 10f, 5f, 5f, 8f });
                //End

                //Footer Output Section Retrieve Record
                dtFooter = objRpt.InvoicePDFFooterOutput(BaseCompanyCode, ddlHrLocation.SelectedItem.Value,
                                                            locationAutoId, ddlAreaId.SelectedItem.Value,
                                                            dt.Rows[dtHdr]["CustomerCode"].ToString(), dt.Rows[dtHdr]["SaleOrderNo"].ToString(),
                                                            ddlInvoiceType.SelectedItem.Value, period,
                                                            dtStartDate, dtEndDate, vat);
                //End

                //Footer Item Output Section Retrive Record
                dtFooterItem = objRpt.InvoicePDFFooterItemOutput(BaseCompanyCode,
                                                                            ddlHrLocation.SelectedItem.Value,
                                                                            locationAutoId,
                                                                            ddlAreaId.SelectedItem.Value,
                                                                            dt.Rows[dtHdr]["CustomerCode"].ToString(),
                                                                            dt.Rows[dtHdr]["SaleOrderNo"].ToString(),
                                                                            ddlInvoiceType.SelectedItem.Value,
                                                                            period, dtStartDate, dtEndDate, vat);
                //End

                if (dtFooter != null && dtFooter.Rows.Count > 0 || dtFooterItem != null && dtFooterItem.Rows.Count > 0)
                {
                    // Added Table Column Heading for Footer Details
                    innerTable.AddCell(new Phrase("SCC", colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.TypeOfService, colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.Area, colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.SerialNumber, colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.AsmtName, colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.Contract, colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.PostDesc, colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.Qty, colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.Rate, colHdgFont));
                    innerTable.AddCell(new Phrase(Resources.Resource.TotalAmount, colHdgFont));
                    //End

                    //Added Row Footer Details Data Records.
                    for (var dtFtr = 0; dtFtr < dtFooter.Rows.Count; dtFtr++)
                    {
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["SaleCode"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["TypeOfService"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["Area"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["ServiceNumber"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["AsmtName"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["ContractName"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["PostDesc"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["DemandQuantity"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["BaseUnitPrice"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooter.Rows[dtFtr]["TotalCost"]), rowFont));
                    }
                    //End

                    //Added Row Footer Item Details Data Records.
                    for (var dtFtrItm = 0; dtFtrItm < dtFooterItem.Rows.Count; dtFtrItm++)
                    {
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["SaleCode"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["TypeOfService"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["Area"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["ServiceNumber"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["AsmtName"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["ContractNumber"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["BillingDesignation"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["DemandQuantity"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["BaseUnitPrice"]), rowFont));
                        innerTable.AddCell(new Phrase(Convert.ToString(dtFooterItem.Rows[dtFtrItm]["TotalCost"]), rowFont));
                    }
                    //End

                    //Added Inner Table in Document
                    document.Add(innerTable);
                    //End

                    //Footer Detail Table
                    var endTable = new PdfPTable(2)
                    {
                        TotalWidth = 400f,
                        LockedWidth = true,
                        HorizontalAlignment = 0,
                        SpacingBefore = 6,
                        SpacingAfter = 2
                    };
                    endTable.DefaultCell.Border = 0;
                    endTable.SetWidths(new float[] { 50f, 50f });

                    endTable.AddCell(new Phrase("Sales Ref. Number:_________________", rowFont));
                    endTable.AddCell(new Phrase(Resources.Resource.InvoiceNumber + ":_________________", rowFont));
                    document.Add(endTable);
                    //End
                }
            }

            //document.Add(table);

            //Close the document
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename=CyprusInvoiceReport.pdf"));
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }

    #region Functions Related to Fill the Drop Down List Controls
    /// <summary>
    /// Function used to Fill HrLocation/Division Drop Down List.
    /// </summary>
    protected void FillHrLocation()
    {
        var objUserManagement = new BL.UserManagement();
        DataSet dsHrLocation = objUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsHrLocation != null && dsHrLocation.Tables[0].Rows.Count > 0)
        {
            ddlHrLocation.DataSource = dsHrLocation.Tables[0];
            ddlHrLocation.DataValueField = "HrLocationCode";
            ddlHrLocation.DataTextField = "HrLocationDesc";
            ddlHrLocation.DataBind();
        }
    }
    /// <summary>
    /// Function used to Fill location Drop Down List.
    /// </summary>
    protected void FillLocation()
    {
        ddlLocation.Items.Clear();
        var objKpi = new BL.KPI();
        DataSet dsLocation = objKpi.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlHrLocation.SelectedItem.Value);
        if (dsLocation.Tables[0].Rows.Count > 0)
        {
            ddlLocation.DataSource = dsLocation.Tables[0];
            ddlLocation.DataValueField = "LocationAutoID";
            ddlLocation.DataTextField = "LocationDesc";
            ddlLocation.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            ddlLocation.Items.Insert(0, li);
        }
        else
        {
            var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlLocation.Items.Insert(0, li);
        }
    }

    /// <summary>
    /// Function used to Fill Area Drop Down List.
    /// </summary>
    private void FillAreaId()
    {
        ddlAreaId.Items.Clear();
        var objOps = new BL.OperationManagement();
        if (ddlLocation.SelectedItem.Value != @"All")
        {
            DataSet ds = objOps.AreaMasterGetAll(ddlLocation.SelectedItem.Value);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAreaId.DataSource = ds;
                ddlAreaId.DataTextField = "AreaID";
                ddlAreaId.DataValueField = "AreaID";
                ddlAreaId.DataBind();

                var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
                ddlAreaId.Items.Insert(0, li);
                ddlAreaId.SelectedIndex = 0;
                ddlAreaId.Enabled = true;
            }
            else
            {
                var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
                ddlAreaId.Items.Insert(0, li);
            }
        }
        else
        {
            //For Area DropDownList
            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            ddlAreaId.Items.Insert(0, li);
            ddlAreaId.SelectedIndex = 0;
            ddlAreaId.Enabled = false;

            //For Customer DropDownList
            var liCust = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            ddlCustomer.Items.Insert(0, liCust);
            ddlCustomer.SelectedIndex = 0;
            ddlCustomer.Enabled = false;

            //For SaleOrder DropDownList
            var liSoNo = new ListItem { Text = Resources.Resource.All, Value = @"All" };
            ddlSoNo.Items.Insert(0, liSoNo);
            ddlSoNo.SelectedIndex = 0;
            ddlSoNo.Enabled = false;
        }
        if (ddlAreaId.SelectedItem.Value == @"All")
        {
            //For Customer DropDownList
            var liCust = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            ddlCustomer.Items.Insert(0, liCust);
            ddlCustomer.SelectedIndex = 0;
            ddlCustomer.Enabled = false;

            //For SaleOrder DropDownList
            var liSoNo = new ListItem { Text = Resources.Resource.All, Value = @"All" };
            ddlSoNo.Items.Insert(0, liSoNo);
            ddlSoNo.SelectedIndex = 0;
            ddlSoNo.Enabled = false;
        }
    }
    /// <summary>
    /// Function used to Fill Customer Drop Down List
    /// </summary>
    private void FillCustomer()
    {
        var objSales = new BL.Sales();
        var location = ddlLocation.CheckedItems;

        var locationCode = string.Empty;
        if (location.Count > 1)
        {
            foreach (var itemloc in location)
            {
                locationCode = locationCode + Convert.ToString(itemloc.Value) + ",";
            }
        }
        else
        {
            locationCode = ddlLocation.SelectedItem.Value;
        }
        if (ddlAreaId.SelectedItem.Value != @"All")
        {
            DataSet dsCustomer = objSales.ClientAreaWiseGet(locationCode, ddlAreaId.SelectedItem.Value);
            if (dsCustomer != null && dsCustomer.Tables[0].Rows.Count > 0)
            {
                ddlCustomer.DataSource = dsCustomer.Tables[0];
                ddlCustomer.DataValueField = "ClientCode";
                ddlCustomer.DataTextField = "ClientName";
                ddlCustomer.DataBind();

                //var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
                //ddlCustomer.Items.Insert(0, li);
                ddlCustomer.SelectedIndex = 0;
                ddlCustomer.Enabled = true;
            }
            else
            {
                var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
                ddlCustomer.Items.Insert(0, li);
            }
        }
        else
        {
            //For Customer DropDownList
            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            ddlCustomer.Items.Insert(0, li);
            ddlCustomer.SelectedIndex = 0;
            ddlCustomer.Enabled = false;

            //For SaleOrder DropDownList
            var liSoNo = new ListItem { Text = Resources.Resource.All, Value = @"All" };
            ddlSoNo.Items.Insert(0, liSoNo);
            ddlSoNo.SelectedIndex = 0;
            ddlSoNo.Enabled = false;
        }
        if (ddlCustomer.SelectedItem.Value == @"All")
        {
            //For SaleOrder DropDownList
            var liSoNo = new ListItem { Text = Resources.Resource.All, Value = @"All" };
            ddlSoNo.Items.Insert(0, liSoNo);
            ddlSoNo.SelectedIndex = 0;
            ddlSoNo.Enabled = false;
        }
    }
    /// <summary>
    /// Function used to Fill Sale Order Drop Down List
    /// </summary>
    protected void FillSaleOrder()
    {
        var objSales = new BL.Sales();
        ddlSoNo.Items.Clear();
        var chkCust = ddlCustomer.CheckedItems;
        if (chkCust.Count > 0)
        {
            //For Branch
            string strCustomer = string.Empty;


            foreach (var item in chkCust)
            {
                strCustomer = strCustomer + item.Value.ToString() + ",";
            }

            DataSet ds = objSales.SOClientWiseGet(ddlLocation.SelectedItem.Value, strCustomer);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlSoNo.DataSource = ds.Tables[0];
                ddlSoNo.DataTextField = "SoNo";
                ddlSoNo.DataValueField = "SoNo";
                ddlSoNo.DataBind();

                var li = new ListItem { Text = Resources.Resource.All, Value = @"All" };
                ddlSoNo.Items.Insert(0, li);
                btnViewReport.Enabled = true;
                ddlSoNo.Enabled = true;
            }
            else
            {
                var li = new ListItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
                ddlSoNo.Items.Insert(0, li);
            }
        }
        else
        {
            var liSoNo = new ListItem { Text = Resources.Resource.All, Value = @"All" };
            ddlSoNo.Items.Insert(0, liSoNo);
            ddlSoNo.SelectedIndex = 0;
            ddlSoNo.Enabled = false;
        }
    }
    /// <summary>
    /// Function used to Fill Invoice Type Drop Down List
    /// </summary>
    private void FillInvoiceType()
    {
        var l1 = new ListItem { Text = Resources.Resource.InvTypFixed, Value = @"FIXED" };
        ddlInvoiceType.Items.Insert(0, l1);

        var l2 = new ListItem { Text = Resources.Resource.InvTypActual, Value = @"ACTUAL" };
        ddlInvoiceType.Items.Insert(1, l2);
    }
    #endregion

    #region Functions Related to Drop Down List Events

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlHrLocation_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        lblErrorMsg.Text = "";
        FillLocation();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlLocation_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        lblErrorMsg.Text = "";
        FillAreaId();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlAreaId_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillCustomer();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlCustomer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlCustomer_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillSaleOrder();
    }
    #endregion
}