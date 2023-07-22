// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptRostering_UnitRegisterExcel.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_RptRostering_UnitRegisterExcel.
/// </summary>
public partial class Transactions_RptRostering_UnitRegisterExcel : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strFromDate = "";
            string strToDate = "";
            string strClientCode = "";
            string strAsmtCode = "";
            string strLocationAutoId = "";
            string strDutyType = "";

            if (Context.Items["FromDate"] != null)
            { strFromDate = Context.Items["FromDate"].ToString(); }
            if (Context.Items["ToDate"] != null)
            { strToDate = Context.Items["ToDate"].ToString(); }
            if (Context.Items["ClientCode"] != null)
            { strClientCode = Context.Items["ClientCode"].ToString(); }
            if (Context.Items["AsmtCode"] != null)
            { strAsmtCode = Context.Items["AsmtCode"].ToString(); }
            if (Context.Items["DutyType"] != null)
            { strDutyType = Context.Items["DutyType"].ToString(); }

            //strFromDate = Request.QueryString["FromDate"];
            //strToDate = Request.QueryString["ToDate"];
            //strClientCode = Request.QueryString["ClientCode"];
            //strAsmtCode = Request.QueryString["AsmtCode"];
            //strDutyType = Request.QueryString["DutyType"];

            strLocationAutoId = BaseLocationAutoID;

            //strFromDate = strFromDate;
            //strToDate = strToDate;
            //strClientCode = strClientCode;
            //strAsmtCode = strAsmtCode;
            //strDutyType = strDutyType;

            float intTotalActual = 0.0F;
            float intTotalOJT = 0.0F;
            float intTotalTSO = 0.0F;
            float intTotalWeekoff = 0.0F;
            float intTotalContract = 0.0F;


            if (strLocationAutoId != "" && strClientCode != "" && strAsmtCode != "" && strFromDate != "" && strToDate != "" && strDutyType != "")
            {
                DataSet ds = new DataSet();
                ds = DL.Report.DLUnitRegisterExcelIndia(int.Parse(strLocationAutoId), strClientCode, strAsmtCode, strFromDate, strToDate, strDutyType);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=UnitRegister.xls");
                    Response.ContentType = "application/octet-stream";
                    Response.Write("<html>");
                    Response.Write("<head>");
                    Response.Write("<style type='text/css'>");
                    Response.Write(".hfont{font-family:Verdana; font-size:15px; font-weight:bold;}");
                    Response.Write(".h1font{font-family:Verdana; font-size:13px; font-weight:bold;}");
                    Response.Write(".bfont{font-family:Verdana; font-size:11px; font-weight:bold;}");
                    Response.Write(".txtCell{mso-number-format:\"" + @"\@" + "\"" + ";}");
                    Response.Write("</style>");
                    Response.Write("</head>");
                    Response.Write("<body>");
                    Response.Write("<table width=200 border=1 cellspacing=0 cellpadding=2>");
                    //********************************************
                    //Report Header
                    CreateBlankRows(1,36);
                    Response.Write("<tr><td colspan='36' align='Center' class='hfont'>Unit Register From " + strFromDate + " To " + strToDate + "</td></tr>");
                    CreateBlankRows(1,36);

                    //To Inert the Logo
                    //Response.Write("<tr><td colspan='20'></td>");
                    //Response.Write("<td colspan='10'><img id='imglogo' src='../Images/logoReport.jpg' border='0' alt='logo'/></td>");
                    //Response.Write("<td colspan='6'></td></tr>");
                    //---------------
                    //System.Drawing.Bitmap imgLogo = new System.Drawing.Bitmap("../Images/logoReport.jpg");
                    //Response.Write("<tr><td colspan='20'></td>");
                    //Response.Write("<td colspan='10'>" + imgLogo.ToString() + "</td>");
                    //Response.Write("<td colspan='6'></td></tr>");
                    //----------------

                    Response.Write("<tr>");
                    Response.Write("<td colspan='2' class='bfont'>Company : </td><td colspan='7'>" + ds.Tables[0].Rows[0]["CompanyDesc"] + "</td>");
                    Response.Write("<td colspan='4' class='bfont'>Location :</td><td colspan='16'>(" + ds.Tables[0].Rows[0]["LocationCode"] + ") " + ds.Tables[0].Rows[0]["LocationDesc"] + "</td>");
                    CreateBlankColumns(7);
                    Response.Write("</tr>");

                    CreateBlankRows(1, 36);

                    Response.Write("<tr>");
                    Response.Write("<td colspan='2' class='bfont'>Client Code: </td><td colspan='7' class='txtCell'>" + ds.Tables[0].Rows[0]["ClientCode"] + "</td>");
                    Response.Write("<td colspan='4' class='bfont'>Client Name :</td><td colspan='16'>"+ ds.Tables[0].Rows[0]["ClientName"] + "</td>");
                    CreateBlankColumns(7);
                    Response.Write("</tr>");

                    CreateBlankRows(1, 36);

                    Response.Write("<tr>");
                    Response.Write("<td colspan='2' class='bfont'>Assignment Code: </td><td colspan='7'>" + ds.Tables[0].Rows[0]["AsmtCode"] + "</td>");
                    Response.Write("<td colspan='4' class='bfont'>Assignment Name :</td><td colspan='16'>" + ds.Tables[0].Rows[0]["AsmtDesc"] + "</td>");
                    CreateBlankColumns(7);
                    Response.Write("</tr>");

                    CreateBlankRows(1, 36);
                    
                    //Report Grid column Headings
                    Response.Write("<tr>");
                    Response.Write("<td class='bfont'>Emp No.</td>");
                    Response.Write("<td class='bfont'>Emp Name</td>");
                    Response.Write("<td class='bfont'>Designation</td>");
                    Response.Write("<td class='bfont'>DutyType</td>");
                    for (int i = 1; i <= int.Parse(strToDate.Substring(0, 2)); i++)
                    {
                        Response.Write("<td class='bfont'>" + i.ToString() + "</td>");
                    }
                    Response.Write("<td class='bfont'>Total</td>");
                    Response.Write("</tr>");
                    //Report Data
                    DataTable dtUnitRegister = new DataTable();
                    DataTable dtEmployeestmp = new DataTable();
                    DataTable dtEmployees = new DataTable();
                    DataTable dtDutyDate = new DataTable();
                    DataTable dtDistinctDT = new DataTable();
                    DataTable dtDistinctDT1 = new DataTable();
                    dtUnitRegister = ds.Tables[0];
                    dtEmployeestmp = dtUnitRegister.DefaultView.ToTable(true, "EmployeeNumber");
                    dtEmployeestmp.DefaultView.Sort = "EmployeeNumber";
                    dtEmployees = dtEmployeestmp.DefaultView.ToTable();

                    string[] strDistinctDutyType = new string[2];
                    strDistinctDutyType[0] = "EmployeeNumber";
                    strDistinctDutyType[1] = "DutyType";
                    dtDistinctDT = dtUnitRegister.DefaultView.ToTable(true, strDistinctDutyType);
                    for (int i = 0; i < dtEmployees.Rows.Count; i++)
                    {
                        Response.Write("<tr>");
                        Response.Write("<td class='txtCell'>" + dtEmployees.Rows[i]["EmployeeNumber"].ToString() + "</td>");
                        dtDistinctDT.DefaultView.RowFilter = "";
                        dtDistinctDT.DefaultView.RowFilter = "EmployeeNumber =" + dtEmployees.Rows[i]["EmployeeNumber"].ToString();
                        dtDistinctDT.DefaultView.Sort = "DutyType";
                        dtDistinctDT1 = dtDistinctDT.DefaultView.ToTable();
                        for (int x = 0; x < dtDistinctDT1.Rows.Count; x++)
                        {
                            dtUnitRegister.DefaultView.RowFilter = "";
                            dtUnitRegister.DefaultView.RowFilter = "EmployeeNumber =" + dtEmployees.Rows[i]["EmployeeNumber"].ToString() + " AND DutyType ='" + dtDistinctDT1.Rows[x]["DutyType"].ToString() + "'";
                            dtUnitRegister.DefaultView.Sort = "DutyDate";
                            dtDutyDate = dtUnitRegister.DefaultView.ToTable();
                            if (x != 0)
                            {
                                Response.Write("<td class='txtCell'>" + dtEmployees.Rows[i]["EmployeeNumber"].ToString() + "</td>");
                            }
                            Response.Write("<td>" + dtDutyDate.Rows[0]["FirstName"].ToString() + " " + dtDutyDate.Rows[0]["LastName"].ToString() + "</td>");
                            Response.Write("<td>" + dtDutyDate.Rows[0]["DesignationCode"].ToString() + "</td>");
                            Response.Write("<td>" + dtDistinctDT1.Rows[x]["DutyType"].ToString() + "</td>");
                            decimal dTotalHrs = 0;
                            
                            for (int j = 1; j <= int.Parse(strToDate.Substring(0, 2)); j++)
                            {
                                int intRecFound = 0;
                                int inta = 0 ;
                                for (int k = 0; k < dtDutyDate.Rows.Count; k++)
                                {
                                    inta = int.Parse(DateFormat(dtDutyDate.Rows[k]["DutyDate"].ToString()).Substring(0, 2));
                                    if (inta == j)
                                    {
                                        if (decimal.Parse(dtDutyDate.Rows[k]["ActualHrs"].ToString()) != 0)
                                        {
                                            Response.Write("<td>" + dtDutyDate.Rows[k]["ActualHrs"].ToString() + "</td>");
                                            dTotalHrs = dTotalHrs + decimal.Parse(dtDutyDate.Rows[k]["ActualHrs"].ToString());
                                            intRecFound = 1;
                                            if (dtDistinctDT1.Rows[x]["DutyType"].ToString() == "O")
                                            {
                                                intTotalOJT = intTotalOJT + (float)System.Convert.ToSingle(dtDutyDate.Rows[k]["ActualHrs"].ToString());
                                            }
                                            else if (dtDistinctDT1.Rows[x]["DutyType"].ToString() == "T")
                                            {
                                                intTotalTSO = intTotalTSO + (float)System.Convert.ToSingle(dtDutyDate.Rows[k]["ActualHrs"].ToString());
                                            }
                                            else if (dtDistinctDT1.Rows[x]["DutyType"].ToString() == "W")
                                            {

                                                intTotalWeekoff = intTotalWeekoff + (float)System.Convert.ToSingle(dtDutyDate.Rows[k]["ActualHrs"].ToString());
                                            }
                                            else
                                            {
                                                intTotalActual = intTotalActual + (float)System.Convert.ToSingle(dtDutyDate.Rows[k]["ActualHrs"].ToString());
                                            }
                                        }
                                    }
                                }
                                if (intRecFound == 0)
                                {
                                    Response.Write("<td>0</td>");
                                    //Response.Write("<td>" + j.ToString()+ "*" + inta.ToString() + "</td>");
                                }
                            }
                            Response.Write("<td>" + dTotalHrs.ToString() + "</td>");
                            Response.Write("</tr>");
                        }
                    }
                    
                    //Grid Footer total Columns -- row 1
                    Response.Write("<tr>");
                    Response.Write("<td colspan='4' class='bfont'>Total Hours</td>");
                    int intNoOfRows = 0;
                    int intColumnChar = 0;
                    string chColumnName = "";
                    dtDistinctDT.DefaultView.RowFilter = "";
                    for (int l = 1; l <= int.Parse(strToDate.Substring(0, 2)); l++)
                    {
                        intColumnChar = 68 + l;
                        if (intColumnChar <= 90)
                        {
                            chColumnName = Convert.ToChar(intColumnChar).ToString();
                        }
                        else
                        {
                            chColumnName = "A" + Convert.ToChar(intColumnChar - 26).ToString();
                        }

                        intNoOfRows = (10 + dtDistinctDT.Rows.Count);
                        Response.Write("<td class='bfont'>=SUM(" + chColumnName + "11:" + chColumnName + intNoOfRows.ToString() + ")</td>");
                    }
                    Response.Write("<td></td>");
                    Response.Write("</tr>");
                    //Grid Footer Contracted Hours row 2


                    // for contract hrs 3 
                    Response.Write("<tr>");
                    Response.Write("<td colspan='4' class='bfont'>Contract Hours</td>");

                    //Commented By Lokesh on 31-May-2010 Ticket no #154402
                    //DataTable dtContract = new DataTable();
                    //dtUnitRegister.DefaultView.RowFilter = "";
                    //dtContract = dtUnitRegister.DefaultView.ToTable(true, "DutyDate");
                    //dtContract.DefaultView.Sort = "DutyDate";
                    //Commented By Lokesh on 31-May-2010 Ticket no #154402

                    //Code Added by lokesh on 31-May-2010 Ticket no #154402 

                    DataTable dtContract = new DataTable();
                    dtContract.Columns.Add("DutyDate");
                    //dtContract = dtUnitRegister.DefaultView.ToTable(false, "DutyDate");
                    DateTime From = DateTime.Parse(strFromDate);
                    DateTime To = DateTime.Parse(strToDate);

                    DataRow dataRow = dtContract.NewRow();
                    dataRow["DutyDate"] = From;
                    dtContract.Rows.Add(dataRow);

                    while (From < To)
                    {
                        DataRow dataRow1 = dtContract.NewRow();
                        dataRow1["DutyDate"] = From.AddDays(double.Parse("1"));
                        dtContract.Rows.Add(dataRow1);
                        From = From.AddDays(double.Parse("1"));
                    }

                    //Code Added by lokesh on 31-May-2010 Ticket no #154402

                    for (int l = 0; l <= int.Parse(strToDate.Substring(0, 2)) - int.Parse(strFromDate.Substring(0, 2)); l++)
                    {
                        dtUnitRegister.DefaultView.RowFilter = "";
                        dtUnitRegister.DefaultView.RowFilter = "DutyDate='" + dtContract.Rows[l][0].ToString() + "'";

                        Response.Write("<td class='bfont'>" + dtUnitRegister.Rows[0]["CONTHRS"] + "</td>");
                        intTotalContract = intTotalContract + (float)System.Convert.ToSingle(dtUnitRegister.Rows[0]["CONTHRS"].ToString());
                        
                    }
                    Response.Write("<td></td>");
                    Response.Write("</tr>");

                    // contract hrs end 3   




                    //CreateBlankColumns(36);
                    //Grid Footer Variance Columns -- Row 3
                    Response.Write("<tr>");
                    Response.Write("<td colspan='4' class='bfont'>Variation</td>");
                   
                    intNoOfRows = 0;
                    intColumnChar = 0;
                    chColumnName = "";
                    for (int l = 1; l <= int.Parse(strToDate.Substring(0, 2)); l++)
                    {
                        intColumnChar = 68 + l;
                        if (intColumnChar <= 90)
                        {
                            chColumnName = Convert.ToChar(intColumnChar).ToString();
                        }
                        else
                        {
                            chColumnName = "A" + Convert.ToChar(intColumnChar - 26).ToString();
                        }

                        intNoOfRows = (11 + dtDistinctDT.Rows.Count);
                        int intNoOfRowsNext = intNoOfRows + 1;
                        Response.Write("<td class='bfont'>=" + chColumnName + intNoOfRows.ToString() + "-" + chColumnName + intNoOfRowsNext.ToString() + "</td>");
                    }
                    Response.Write("<td></td>");
                    Response.Write("</tr>");

                    CreateBlankRows(1, 36);
                    Response.Write("<tr>");
                    Response.Write("<td colspan='3' class='h1font'>Assignment Summary</td>");
                    CreateBlankColumns(33);
                    Response.Write("</tr>");
                    CreateBlankRows(1, 36);

                    Response.Write("<tr>");
                    Response.Write("<td colspan='3' align='left' class='bfont'>Actual Hours</td><td class='bfont' colspan='3'>" + intTotalActual + "</td>");
                    CreateBlankColumns(30);
                    Response.Write("</tr>");

                    Response.Write("<tr>");
                    Response.Write("<td colspan='3' align='left' class='bfont'>Contracted Hours</td><td class='bfont' colspan='3'>" + intTotalContract + "</td>");
                    CreateBlankColumns(30);
                    Response.Write("</tr>");

                    Response.Write("<tr>");
                    Response.Write("<td colspan='3' align='left' class='bfont'>Variation</td><td class='bfont' colspan='3'>" + (intTotalContract - (intTotalActual + intTotalOJT + intTotalTSO + intTotalWeekoff)) + "</td>");
                    CreateBlankColumns(30);
                    Response.Write("</tr>");

                    Response.Write("<tr>");
                    Response.Write("<td colspan='3' align='left' class='bfont'>OJT Hours</td><td class='bfont' colspan='3'>" + intTotalOJT + "</td>");
                    CreateBlankColumns(30);
                    Response.Write("</tr>");

                    Response.Write("<tr>");
                    Response.Write("<td colspan='3' align='left' class='bfont'>TSO Hours</td><td class='bfont' colspan='3'>" + intTotalTSO + "</td>");
                    CreateBlankColumns(30);
                    Response.Write("</tr>");

                    Response.Write("<tr>");
                    Response.Write("<td colspan='3' align='left' class='bfont'>Weekoff Hours</td><td class='bfont' colspan='3'>" + intTotalWeekoff + "</td>");
                    CreateBlankColumns(30);
                    Response.Write("</tr>");


                    //********************************************
                    Response.Write("</table>");
                    Response.Write("</body>");
                    Response.Write("</html>");
                }
                else
                {
                    lblErrMsg.Text = Resources.Resource.NoDataToShow;
                }
            }
        }
    }

    /// <summary>
    /// Creates the blank rows.
    /// </summary>
    /// <param name="intNumberOfRows">The int number of rows.</param>
    protected void CreateBlankRows(int intNumberOfRows)
    {
        for (int i = 1; i <= intNumberOfRows; i++)
        {
            Response.Write("<tr>");
            //Response.Write("<td>&nbsp;</td>");
            Response.Write("</tr>");
        }
    }
    /// <summary>
    /// Creates the blank rows.
    /// </summary>
    /// <param name="intNumberOfRows">The int number of rows.</param>
    /// <param name="intNumberOfColumns">The int number of columns.</param>
    protected void CreateBlankRows(int intNumberOfRows, int intNumberOfColumns)
    {
        for (int i = 1; i <= intNumberOfRows; i++)
        {
            Response.Write("<tr>");
            CreateBlankColumns(intNumberOfColumns);
            Response.Write("</tr>");
        }
    }
    /// <summary>
    /// Creates the blank rows single column.
    /// </summary>
    /// <param name="intNumberOfRows">The int number of rows.</param>
    /// <param name="intColspan">The int colspan.</param>
    protected void CreateBlankRowsSingleColumn(int intNumberOfRows, int intColspan)
    {
        for (int i = 1; i <= intNumberOfRows; i++)
        {
            Response.Write("<tr>");
            Response.Write("<td colspan='" + intColspan.ToString() + "'>&nbsp;</td>");
            Response.Write("</tr>");
        }
    }
    /// <summary>
    /// Creates the blank columns.
    /// </summary>
    /// <param name="intNumberOfColumns">The int number of columns.</param>
    protected void CreateBlankColumns(int intNumberOfColumns)
    {
        for (int i = 1; i <= intNumberOfColumns; i++)
        {
            Response.Write("<td>&nbsp;</td>");
        }
    }
}
