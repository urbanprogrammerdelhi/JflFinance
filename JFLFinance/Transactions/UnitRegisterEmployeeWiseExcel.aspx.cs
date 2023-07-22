// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="UnitRegisterEmployeeWiseExcel.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Linq;
using System.Text;

/// <summary>
/// Class Transactions_UnitRegisterEmployeeWiseExcel.
/// </summary>
public partial class Transactions_UnitRegisterEmployeeWiseExcel : BasePage //System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        string strFromDate = Request.QueryString["FromDate"].ToString();
        string strToDate = Request.QueryString["ToDate"].ToString();
        string strFileName = string.Empty;
        strFileName = "Unit Register Employee Wise" + DateTime.Now.ToString("dd-MMM-yyyy") + ".xls";
        // strFromDate = "01-Mar-2011";
        // strToDate = "07-Mar-2011";

        StringBuilder sb = new StringBuilder();
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRoster.UnitRegisterEmployeeBreakup(BaseCompanyCode, BaseLocationCode, strFromDate, strToDate);

        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName + " ");
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.ContentType = "application/ms-excel";
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        sb.Append("<html>");
        sb.Append("<head>");
        sb.Append("<style type='text/css'>");
        sb.Append("</style>");
        sb.Append("</head>");
        sb.Append("<body>");

        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            sb.Append("<table  border=0 cellspacing=0 cellpadding=0>");

            sb.Append("<tr>");

            sb.Append("<td style='background-color:#C0C0C0;'><b>" + "Post / Shift" + "</b></td>");
            sb.Append("<td colspan=25 >" + ds.Tables[1].Rows[i]["Post"].ToString() + " [" + ds.Tables[1].Rows[i]["Shift"].ToString() + "]</td>");
            // commented by Manish on 26 may 2011 for formating report
            //sb.Append("<td style='background-color:#C0C0C0;'>" + "Type" + "</td>");
            //sb.Append("<td>" + ds.Tables[1].Rows[i]["Type"].ToString() + "</td>");
            //sb.Append("<td style='background-color:#C0C0C0;'>" + "Shift" + "</td>");
            //sb.Append("<td>" + ds.Tables[1].Rows[i]["Shift"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "[Post]='" + (ds.Tables[1].Rows[i]["Post"].ToString()) + "' AND [Type]='" + (ds.Tables[1].Rows[i]["Type"].ToString()) + "' AND [Shift]='" + (ds.Tables[1].Rows[i]["Shift"].ToString()) + "'";
            DataTable dtPost = new DataTable();
            dtPost = dv.ToTable();
            sb.Append("<table  border=1 cellspacing=0 cellpadding=0>");
            sb.Append("<tr>");
            sb.Append("<td style='background-color:#C0C0C0;'><b>" + "Date" + "</b></td>");
            for (int k = 0; k < ds.Tables[2].Rows.Count; k++)
            {
                // if and else condition added by Manish on 26 may 2011 for highliting sat & sun
                if (DateTime.Parse(ds.Tables[2].Rows[k]["DutyDate"].ToString()).ToString("ddd") == "Sat" || DateTime.Parse(ds.Tables[2].Rows[k]["DutyDate"].ToString()).ToString("ddd") == "Sun")
                {
                    sb.Append("<td style='background-color:Pink; text-align:center; font-size:smaller; width:10px'>" + DateTime.Parse(ds.Tables[2].Rows[k]["DutyDate"].ToString()).ToString("dd") + "<br>" + DateTime.Parse(ds.Tables[2].Rows[k]["DutyDate"].ToString()).ToString("ddd") + "</td>");
                }
                else
                {
                    sb.Append("<td style='background-color:#C0C0C0; text-align:center; font-size:smaller; width:10px'>" + DateTime.Parse(ds.Tables[2].Rows[k]["DutyDate"].ToString()).ToString("dd") + "<br>" + DateTime.Parse(ds.Tables[2].Rows[k]["DutyDate"].ToString()).ToString("ddd") + "</td>");

                }
              
            }
            sb.Append("<td style='background-color:#C0C0C0;'>" + "Total Hours" + "</td>");
            // sb.Append("<td style='background-color:#C0C0C0; display:none;'>" + "Price Hours" + "</td>");
            sb.Append("<td style='background-color:#C0C0C0;'>" + "Total Price" + "</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<table  border=1 cellspacing=0 cellpadding=0>");

            double TotalHours = 0.00;
            double TotalPrice = 0.00;
            double FirstDay = 0.00;
            double SecondDay = 0.00;
            double ThirdDay = 0.00;
            double FourthDay = 0.00;
            double FifthDay = 0.00;
            double SixDay = 0.00;
            double SevenDay = 0.00;
            double EightDay = 0.00;
            double NineDay = 0.00;
            double TenDay = 0.00;
            double ElevenDay = 0.00;
            double TwelveDay = 0.00;
            double ThirteenDay = 0.00;
            double FourteenDay = 0.00;
            double FifteenDay = 0.00;
            double SixteenDay = 0.00;
            double SeventeenDay = 0.00;
            double EightneenDay = 0.00;
            double NineteenDay = 0.00;
            double TwentyDay = 0.00;
            double TwentyoneDay = 0.00;
            double TwentytwoDay = 0.00;
            double TwentythreeDay = 0.00;
            double TwentyfourthDay = 0.00;
            double TwentyFifthDay = 0.00;
            double TwentySixthDay = 0.00;
            double TwentySeventhDay = 0.00;
            double TwentyEighthDay = 0.00;
            double TwentyNinethDay = 0.00;
            double ThirthyDay = 0.00;
            double ThirtyOneDay = 0.00;

             DataSet dsEmp = new DataSet();
            var distinctRows = (from DataRow dRow in dtPost.Rows
                                select new { colPost = dRow["Post"], colEmployeename = dRow["EmployeeName"] }).Distinct();
            string strZeroValue = "0";
            string strHours = "0";
            foreach (var row in distinctRows)
            {
                sb.Append("<tr>");
                DataView dv1 = new DataView(dtPost);
                dv1.RowFilter = "[EmployeeName]='" + row.colEmployeename + "'";
                DataTable dtDay = new DataTable();
                dtDay = dv1.ToTable();
                double TotalHoursBasedOnType = 0.00;
                DataTable dtEmp = new DataTable();
                sb.Append("<td style='background-color:#C0C0C0;'>" + row.colEmployeename + "</td>");
              
                double rowWiseTotalHrs = 0.00;
                int y = 0;
                if (ds.Tables[2].Rows.Count != dtDay.Rows.Count && dtDay.Rows.Count > 0)
                {
                    int a = 0;
                    for (int z = y; y < ds.Tables[2].Rows.Count; z++)
                    {
                        try
                        {
                            if (ds.Tables[2].Rows[z]["DutyDate"].ToString() != dtDay.Rows[a]["DutyDate"].ToString())
                            {
                                sb.Append("<td>" + 0 + "</td>");
                                if (z == 0)
                                {
                                    FirstDay = FirstDay + 0;
                                }
                                if (z == 1)
                                {
                                    SecondDay = SecondDay + 0;
                                }
                                if (z == 2)
                                {
                                    ThirdDay = ThirdDay + 0;
                                }
                                if (z == 3)
                                {
                                    FourthDay = FourthDay + 0;
                                }
                                if (z == 4)
                                {
                                    FifthDay = FifthDay + 0;
                                }
                                if (z == 5)
                                {
                                    SixDay = SixDay + 0;
                                }
                                if (z == 6)
                                {
                                    SevenDay = SevenDay + 0;
                                }
                                if (z == 7)
                                {
                                    EightDay = EightDay + 0;
                                }
                                if (z == 8)
                                {
                                    NineDay = NineDay + 0;
                                }
                                if (z == 9)
                                {
                                    TenDay = TenDay + 0;
                                }
                                if (z == 10)
                                {
                                    ElevenDay = ElevenDay + 0;
                                }
                                if (z == 11)
                                {
                                    TwelveDay = TwelveDay + 0;
                                }
                                if (z == 12)
                                {
                                    ThirteenDay = ThirteenDay + 0;
                                }
                                if (z == 13)
                                {
                                    FourteenDay = FourteenDay + 0;
                                }
                                if (z == 14)
                                {
                                    FifteenDay = FifteenDay + 0;
                                }
                                if (z == 15)
                                {
                                    SixteenDay = SixteenDay + 0;
                                }
                                if (z == 16)
                                {
                                    SeventeenDay = SeventeenDay + 0;
                                }
                                if (z == 17)
                                {
                                    EightneenDay = EightneenDay + 0;
                                }
                                if (z == 18)
                                {
                                    NineteenDay = NineteenDay + 0;
                                }
                                if (z == 19)
                                {
                                    TwentyDay = TwentyDay + 0;
                                }
                                if (z == 20)
                                {
                                    TwentyoneDay = TwentyoneDay + 0;

                                }
                                if (z == 21)
                                {
                                    TwentytwoDay = TwentytwoDay + 0;
                                }
                                if (z == 22)
                                {
                                    TwentythreeDay = TwentythreeDay + 0;
                                }
                                if (z == 23)
                                {
                                    TwentyfourthDay = TwentyfourthDay + 0;
                                }
                                if (z == 24)
                                {
                                    TwentyFifthDay = TwentyFifthDay + 0;
                                }
                                if (z == 25)
                                {
                                    TwentySixthDay = TwentySixthDay + 0;
                                }
                                if (z == 26)
                                {
                                    TwentySeventhDay = TwentySeventhDay + 0;
                                }
                                if (z == 27)
                                {
                                    TwentyEighthDay = TwentyEighthDay + 0;
                                }
                                if (z == 28)
                                {
                                    TwentyNinethDay = TwentyNinethDay + 0;
                                }
                                if (z == 29)
                                {
                                    ThirthyDay = ThirthyDay + 0;
                                }
                                if (z == 30)
                                {
                                    ThirtyOneDay = ThirtyOneDay + 0;
                                }

                                y = z + 1;
                            }
                            else
                            {
                                sb.Append("<td>" + dtDay.Rows[a]["Hours"].ToString() + "</td>");
                                rowWiseTotalHrs = rowWiseTotalHrs + double.Parse(dtDay.Rows[a]["Total_Price"].ToString());
                                if (z == 0)
                                {
                                    FirstDay = FirstDay + double.Parse(dtDay.Rows[a]["Hours"].ToString());
                                }
                                if (z == 1)
                                {
                                    SecondDay = SecondDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 2)
                                {
                                    ThirdDay = ThirdDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 3)
                                {
                                    FourthDay = FourthDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 4)
                                {
                                    FifthDay = FifthDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 5)
                                {
                                    SixDay = SixDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 6)
                                {
                                    SevenDay = SevenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 7)
                                {
                                    EightDay = EightDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 8)
                                {
                                    NineDay = NineDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 9)
                                {
                                    TenDay = TenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 10)
                                {
                                    ElevenDay = ElevenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 11)
                                {
                                    TwelveDay = TwelveDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 12)
                                {
                                    ThirteenDay = ThirteenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 13)
                                {
                                    FourteenDay = FourteenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 14)
                                {
                                    FifteenDay = FifteenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 15)
                                {
                                    SixteenDay = SixteenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 16)
                                {
                                    SeventeenDay = SeventeenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 17)
                                {
                                    EightneenDay = EightneenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 18)
                                {
                                    NineteenDay = NineteenDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 19)
                                {
                                    TwentyDay = TwentyDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 20)
                                {
                                    TwentyoneDay = TwentyoneDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;

                                }
                                if (z == 21)
                                {
                                    TwentytwoDay = TwentytwoDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 22)
                                {
                                    TwentythreeDay = TwentythreeDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 23)
                                {
                                    TwentyfourthDay = TwentyfourthDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 24)
                                {
                                    TwentyFifthDay = TwentyFifthDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 25)
                                {
                                    TwentySixthDay = TwentySixthDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 26)
                                {
                                    TwentySeventhDay = TwentySeventhDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 27)
                                {
                                    TwentyEighthDay = TwentyEighthDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 28)
                                {
                                    TwentyNinethDay = TwentyNinethDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 29)
                                {
                                    ThirthyDay = ThirthyDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }
                                if (z == 30)
                                {
                                    ThirtyOneDay = ThirtyOneDay + double.Parse(dtDay.Rows[a]["Hours"].ToString()); ;
                                }

                                TotalHoursBasedOnType = TotalHoursBasedOnType + double.Parse(dtDay.Rows[a]["Hours"].ToString());
                                y = z + 1;
                                a = a + 1;
                            }
                        }
                        catch (Exception ex)
                        {
                            sb.Append("<td>" + 0 + "</td>");
                            if (z == 0)
                            {
                                FirstDay = FirstDay + 0;
                            }
                            if (z == 1)
                            {
                                SecondDay = SecondDay + 0;
                            }
                            if (z == 2)
                            {
                                ThirdDay = ThirdDay + 0;
                            }
                            if (z == 3)
                            {
                                FourthDay = FourthDay + 0;
                            }
                            if (z == 4)
                            {
                                FifthDay = FifthDay + 0;
                            }
                            if (z == 5)
                            {
                                SixDay = SixDay + 0;
                            }
                            if (z == 6)
                            {
                                SevenDay = SevenDay + 0;
                            }
                            if (z == 7)
                            {
                                EightDay = EightDay + 0;
                            }
                            if (z == 8)
                            {
                                NineDay = NineDay + 0;
                            }
                            if (z == 9)
                            {
                                TenDay = TenDay + 0;
                            }
                            if (z == 10)
                            {
                                ElevenDay = ElevenDay + 0;
                            }
                            if (z == 11)
                            {
                                TwelveDay = TwelveDay + 0;
                            }
                            if (z == 12)
                            {
                                ThirteenDay = ThirteenDay + 0;
                            }
                            if (z == 13)
                            {
                                FourteenDay = FourteenDay + 0;
                            }
                            if (z == 14)
                            {
                                FifteenDay = FifteenDay + 0;
                            }
                            if (z == 15)
                            {
                                SixteenDay = SixteenDay + 0;
                            }
                            if (z == 16)
                            {
                                SeventeenDay = SeventeenDay + 0;
                            }
                            if (z == 17)
                            {
                                EightneenDay = EightneenDay + 0;
                            }
                            if (z == 18)
                            {
                                NineteenDay = NineteenDay + 0;
                            }
                            if (z == 19)
                            {
                                TwentyDay = TwentyDay + 0;
                            }
                            if (z == 20)
                            {
                                TwentyoneDay = TwentyoneDay + 0;

                            }
                            if (z == 21)
                            {
                                TwentytwoDay = TwentytwoDay + 0;
                            }
                            if (z == 22)
                            {
                                TwentythreeDay = TwentythreeDay + 0;
                            }
                            if (z == 23)
                            {
                                TwentyfourthDay = TwentyfourthDay + 0;
                            }
                            if (z == 24)
                            {
                                TwentyFifthDay = TwentyFifthDay + 0;
                            }
                            if (z == 25)
                            {
                                TwentySixthDay = TwentySixthDay + 0;
                            }
                            if (z == 26)
                            {
                                TwentySeventhDay = TwentySeventhDay + 0;
                            }
                            if (z == 27)
                            {
                                TwentyEighthDay = TwentyEighthDay + 0;
                            }
                            if (z == 28)
                            {
                                TwentyNinethDay = TwentyNinethDay + 0;
                            }
                            if (z == 29)
                            {
                                ThirthyDay = ThirthyDay + 0;
                            }
                            if (z == 30)
                            {
                                ThirtyOneDay = ThirtyOneDay + 0;
                            }
                            TotalHoursBasedOnType = TotalHoursBasedOnType + 0;
                            y = z + 1;
                            a = a - 1;
                        }
                    }
                }
                else
                {
                    try
                    {
                        if (dtDay.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtDay.Rows.Count; j++)
                            {
                                sb.Append("<td>" + dtDay.Rows[j]["Hours"].ToString() + "</td>");
                                rowWiseTotalHrs = rowWiseTotalHrs + double.Parse(dtDay.Rows[j]["Total_Price"].ToString());
                                if (j == 0)
                                {
                                    FirstDay = FirstDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 1)
                                {
                                    SecondDay = SecondDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 2)
                                {
                                    ThirdDay = ThirdDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 3)
                                {
                                    FourthDay = FourthDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 4)
                                {
                                    FifthDay = FifthDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 5)
                                {
                                    SixDay = SixDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 6)
                                {
                                    SevenDay = SevenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 7)
                                {
                                    EightDay = EightDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 8)
                                {
                                    NineDay = NineDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 9)
                                {
                                    TenDay = TenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 10)
                                {
                                    ElevenDay = ElevenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 11)
                                {
                                    TwelveDay = TwelveDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 12)
                                {
                                    ThirteenDay = ThirteenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 13)
                                {
                                    FourteenDay = FourteenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 14)
                                {
                                    FifteenDay = FifteenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 15)
                                {
                                    SixteenDay = SixteenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 16)
                                {
                                    SeventeenDay = SeventeenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 17)
                                {
                                    EightneenDay = EightneenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 18)
                                {
                                    NineteenDay = NineteenDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 19)
                                {
                                    TwentyDay = TwentyDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 20)
                                {
                                    TwentyoneDay = TwentyoneDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());

                                }
                                if (j == 21)
                                {
                                    TwentytwoDay = TwentytwoDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 22)
                                {
                                    TwentythreeDay = TwentythreeDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 23)
                                {
                                    TwentyfourthDay = TwentyfourthDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 24)
                                {
                                    TwentyFifthDay = TwentyFifthDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 25)
                                {
                                    TwentySixthDay = TwentySixthDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 26)
                                {
                                    TwentySeventhDay = TwentySeventhDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 27)
                                {
                                    TwentyEighthDay = TwentyEighthDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 28)
                                {
                                    TwentyNinethDay = TwentyNinethDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 29)
                                {
                                    ThirthyDay = ThirthyDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }
                                if (j == 30)
                                {
                                    ThirtyOneDay = ThirtyOneDay + double.Parse(dtDay.Rows[j]["Hours"].ToString());
                                }

                                TotalHoursBasedOnType = TotalHoursBasedOnType + double.Parse(dtDay.Rows[j]["Hours"].ToString());


                            }
                        }
                        else
                        {
                            for (int l = 0; l < ds.Tables[2].Rows.Count; l++)
                            {
                                sb.Append("<td>" + 0 + "</td>");
                                if (l == 0)
                                {
                                    FirstDay = FirstDay + 0;
                                }

                                if (l == 1)
                                {
                                    SecondDay = SecondDay + 0;
                                }
                                if (l == 2)
                                {
                                    ThirdDay = ThirdDay + 0;
                                }
                                if (l == 3)
                                {
                                    FourthDay = FourthDay + 0;
                                }
                                if (l == 4)
                                {
                                    FifthDay = FifthDay + 0;
                                }
                                if (l == 5)
                                {
                                    SixDay = SixDay + 0;
                                }
                                if (l == 6)
                                {
                                    SevenDay = SevenDay + 0;
                                }
                                if (l == 7)
                                {
                                    EightDay = EightDay + 0;
                                }
                                if (l == 8)
                                {
                                    NineDay = NineDay + 0;
                                }
                                if (l == 9)
                                {
                                    TenDay = TenDay + 0;
                                }
                                if (l == 10)
                                {
                                    ElevenDay = ElevenDay + 0;
                                }
                                if (l == 11)
                                {
                                    TwelveDay = TwelveDay + 0;
                                }
                                if (l == 12)
                                {
                                    ThirteenDay = ThirteenDay + 0;
                                }
                                if (l == 13)
                                {
                                    FourteenDay = FourteenDay + 0;
                                }
                                if (l == 14)
                                {
                                    FifteenDay = FifteenDay + 0;
                                }
                                if (l == 15)
                                {
                                    SixteenDay = SixteenDay + 0;
                                }
                                if (l == 16)
                                {
                                    SeventeenDay = SeventeenDay + 0;
                                }
                                if (l == 17)
                                {
                                    EightneenDay = EightneenDay + 0;
                                }
                                if (l == 18)
                                {
                                    NineteenDay = NineteenDay + 0;
                                }
                                if (l == 19)
                                {
                                    TwentyDay = TwentyDay + 0;
                                }
                                if (l == 20)
                                {
                                    TwentyoneDay = TwentyoneDay + 0;

                                }
                                if (l == 21)
                                {
                                    TwentytwoDay = TwentytwoDay + 0;
                                }
                                if (l == 22)
                                {
                                    TwentythreeDay = TwentythreeDay + 0;
                                }
                                if (l == 23)
                                {
                                    TwentyfourthDay = TwentyfourthDay + 0;
                                }
                                if (l == 24)
                                {
                                    TwentyFifthDay = TwentyFifthDay + 0;
                                }
                                if (l == 25)
                                {
                                    TwentySixthDay = TwentySixthDay + 0;
                                }
                                if (l == 26)
                                {
                                    TwentySeventhDay = TwentySeventhDay + 0;
                                }
                                if (l == 27)
                                {
                                    TwentyEighthDay = TwentyEighthDay + 0;
                                }
                                if (l == 28)
                                {
                                    TwentyNinethDay = TwentyNinethDay + 0;
                                }
                                if (l == 29)
                                {
                                    ThirthyDay = ThirthyDay + 0;
                                }
                                if (l == 30)
                                {
                                    ThirtyOneDay = ThirtyOneDay + 0;
                                }


                            }
                            TotalHoursBasedOnType = TotalHoursBasedOnType + 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        sb.Append("<td>" + 0 + "</td>");
                        FirstDay = FirstDay + 0;
                        SecondDay = SecondDay + 0;
                        ThirdDay = ThirdDay + 0;
                        FourthDay = FourthDay + 0;
                        FifthDay = FifthDay + 0;
                        SixDay = SixDay + 0;
                        SevenDay = SevenDay + 0;
                        EightDay = EightDay + 0;
                        NineDay = NineDay + 0;
                        TenDay = TenDay + 0;
                        ElevenDay = ElevenDay + 0;
                        TwelveDay = TwelveDay + 0;
                        ThirteenDay = ThirteenDay + 0;
                        FourteenDay = FourteenDay + 0;
                        FifteenDay = FifteenDay + 0;
                        SixteenDay = SixteenDay + 0;
                        SeventeenDay = SeventeenDay + 0;
                        EightneenDay = EightneenDay + 0;
                        NineteenDay = NineteenDay + 0;
                        TwentyDay = TwentyDay + 0;
                        TwentyoneDay = TwentyoneDay + 0;
                        TwentytwoDay = TwentytwoDay + 0;
                        TwentythreeDay = TwentythreeDay + 0;
                        TwentyfourthDay = TwentyfourthDay + 0;
                        TwentyFifthDay = TwentyFifthDay + 0;
                        TwentySixthDay = TwentySixthDay + 0;
                        TwentySeventhDay = TwentySeventhDay + 0;
                        TwentyEighthDay = TwentyEighthDay + 0;
                        TwentyNinethDay = TwentyNinethDay + 0;
                        ThirthyDay = ThirthyDay + 0;
                        ThirtyOneDay = ThirtyOneDay + 0;


                        TotalHoursBasedOnType = TotalHoursBasedOnType + 0;
                    }
                }
                TotalHours = TotalHours + TotalHoursBasedOnType;
                sb.Append("<td>" + TotalHoursBasedOnType + "</td>");
                try
                {
                    if (dtDay.Rows.Count > 0)
                    {
                        // sb.Append("<td style='display:none;'>" + dtDay.Rows[0]["Price_Hours"].ToString() + "</td>");
                        // sb.Append("<td>" + TotalHoursBasedOnType * double.Parse(dtDay.Rows[0]["Price_Hours"].ToString()) + "</td>");
                        sb.Append("<td>" + rowWiseTotalHrs + "</td>");

                        // TotalPrice = TotalPrice + double.Parse((TotalHoursBasedOnType * double.Parse(dtDay.Rows[0]["Price_Hours"].ToString())).ToString());

                        TotalPrice = TotalPrice + double.Parse(rowWiseTotalHrs.ToString());
                        // = FirstDay + 
                    }
                    else
                    {

                        sb.Append("<td>" + 0 + "</td>");
                        sb.Append("<td>" + 0 + "</td>");
                        TotalPrice = TotalPrice + 0;
                    }
                }
                catch (Exception ex)
                {
                    TotalPrice = TotalPrice + 0;
                    sb.Append("<td>" + 0 + "</td>");
                }
                sb.Append("</tr>");
            }

            sb.Append("<tr>");
            sb.Append("<td style='background-color:#C0C0C0;'>" + "Total Hours" + "</td>");

            if (ds.Tables[2].Rows.Count == 31)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");
                sb.Append("<td>" + TwentyfourthDay + "</td>");
                sb.Append("<td>" + TwentyFifthDay + "</td>");
                sb.Append("<td>" + TwentySixthDay + "</td>");
                sb.Append("<td>" + TwentySeventhDay + "</td>");
                sb.Append("<td>" + TwentyEighthDay + "</td>");
                sb.Append("<td>" + TwentyNinethDay + "</td>");
                sb.Append("<td>" + ThirthyDay + "</td>");
                sb.Append("<td>" + ThirtyOneDay + "</td>");
            }
            else if (ds.Tables[2].Rows.Count == 30)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");
                sb.Append("<td>" + TwentyfourthDay + "</td>");
                sb.Append("<td>" + TwentyFifthDay + "</td>");
                sb.Append("<td>" + TwentySixthDay + "</td>");
                sb.Append("<td>" + TwentySeventhDay + "</td>");
                sb.Append("<td>" + TwentyEighthDay + "</td>");
                sb.Append("<td>" + TwentyNinethDay + "</td>");
                sb.Append("<td>" + ThirthyDay + "</td>");
            }
            else if (ds.Tables[2].Rows.Count == 29)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");
                sb.Append("<td>" + TwentyfourthDay + "</td>");
                sb.Append("<td>" + TwentyFifthDay + "</td>");
                sb.Append("<td>" + TwentySixthDay + "</td>");
                sb.Append("<td>" + TwentySeventhDay + "</td>");
                sb.Append("<td>" + TwentyEighthDay + "</td>");
                sb.Append("<td>" + TwentyNinethDay + "</td>");

            }
            else if (ds.Tables[2].Rows.Count == 28)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");
                sb.Append("<td>" + TwentyfourthDay + "</td>");
                sb.Append("<td>" + TwentyFifthDay + "</td>");
                sb.Append("<td>" + TwentySixthDay + "</td>");
                sb.Append("<td>" + TwentySeventhDay + "</td>");
                sb.Append("<td>" + TwentyEighthDay + "</td>");


            }
            else if (ds.Tables[2].Rows.Count == 27)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");
                sb.Append("<td>" + TwentyfourthDay + "</td>");
                sb.Append("<td>" + TwentyFifthDay + "</td>");
                sb.Append("<td>" + TwentySixthDay + "</td>");
                sb.Append("<td>" + TwentySeventhDay + "</td>");



            }
            else if (ds.Tables[2].Rows.Count == 26)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");
                sb.Append("<td>" + TwentyfourthDay + "</td>");
                sb.Append("<td>" + TwentyFifthDay + "</td>");
                sb.Append("<td>" + TwentySixthDay + "</td>");



            }
            else if (ds.Tables[2].Rows.Count == 25)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");
                sb.Append("<td>" + TwentyfourthDay + "</td>");
                sb.Append("<td>" + TwentyFifthDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 24)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");
                sb.Append("<td>" + TwentyfourthDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 23)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");
                sb.Append("<td>" + TwentythreeDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 22)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");
                sb.Append("<td>" + TwentytwoDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 21)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");
                sb.Append("<td>" + TwentyoneDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 20)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");
                sb.Append("<td>" + TwentyDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 19)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");
                sb.Append("<td>" + NineteenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 18)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");
                sb.Append("<td>" + EightneenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 17)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");
                sb.Append("<td>" + SeventeenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 16)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");
                sb.Append("<td>" + SixteenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 15)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");
                sb.Append("<td>" + FifteenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 14)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");
                sb.Append("<td>" + FourteenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 13)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");
                sb.Append("<td>" + ThirteenDay + "</td>");


            }
            else if (ds.Tables[2].Rows.Count == 12)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");
                sb.Append("<td>" + TwelveDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 11)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");
                sb.Append("<td>" + ElevenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 10)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");
                sb.Append("<td>" + TenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 9)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");
                sb.Append("<td>" + NineDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 8)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");
                sb.Append("<td>" + EightDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 7)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");
                sb.Append("<td>" + SevenDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 6)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
                sb.Append("<td>" + SixDay + "</td>");



            }
            else if (ds.Tables[2].Rows.Count == 5)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");
                sb.Append("<td>" + FifthDay + "</td>");
            }

            else if (ds.Tables[2].Rows.Count == 4)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");
                sb.Append("<td>" + FourthDay + "</td>");


            }
            else if (ds.Tables[2].Rows.Count == 3)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");
                sb.Append("<td>" + ThirdDay + "</td>");

            }
            else if (ds.Tables[2].Rows.Count == 2)
            {
                sb.Append("<td>" + FirstDay + "</td>");
                sb.Append("<td>" + SecondDay + "</td>");




            }
            else if (ds.Tables[2].Rows.Count == 1)
            {
                sb.Append("<td>" + FirstDay + "</td>");




            }

            //for (int b = 0; b < ds.Tables[2].Rows.Count; b++)
            //{
            //    DataView dv2 = new DataView(ds.Tables[4]);
            //    if (dtPost.Rows.Count > 0)
            //    {
            //        dv2.RowFilter = "[Post]='" + (dtPost.Rows[0]["Post"].ToString()) + "' AND [Type]='" + (dtPost.Rows[0]["Type"].ToString()) + "' AND [Shift]='" + (dtPost.Rows[0]["Shift"].ToString()) + "' AND [DutyDate]='" + (ds.Tables[2].Rows[b]["DutyDate"].ToString()) + "'";
            //        DataTable dtTotal = new DataTable();
            //        dtTotal = dv2.ToTable();
            //        if (dtTotal.Rows.Count > 0)
            //        {
            //            sb.Append("<td>" + dtTotal.Rows[0]["Hours"].ToString() + "</td>");
            //        }
            //        else
            //        {
            //            sb.Append("<td>" + 0 + "</td>");
            //        }
            //    }
            //    else
            //    {
            //        sb.Append("<td>" + 0 + "</td>");
            //    }
            //}
            sb.Append("<td>" + TotalHours.ToString() + "</td>");
            // sb.Append("<td style='display:none;'></td>");
            sb.Append("<td>" + TotalPrice.ToString() + "</td>");
            sb.Append("</tr>");

            sb.Append("<tr></tr>");
            sb.Append("</table>");
        }


        sb.Append("</body>");
        sb.Append("</html>");
        Response.Write(sb.ToString());
        Response.End();
    }
}
