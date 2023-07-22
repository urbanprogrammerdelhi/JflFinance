// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="MSXLPaySum.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Text;

/// <summary>
/// Class Transactions_MSXLPaySum.
/// </summary>
public partial class Transactions_MSXLPaySum : BasePage//System.Web.UI.Page
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
        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        string strDivision = Request.QueryString["DivisionCode"].ToString();
        string strBranch = Request.QueryString["BranchCode"].ToString();
        string strMonth = Request.QueryString["Month"].ToString();
        string strYear = Request.QueryString["year"].ToString();

        //commented by Manish on 6-feb-2010  
        //ds = objRoster.blTranScheduleRoster_GeneratePaySum(BaseCompanyCode, strDivision, strBranch, int.Parse(strMonth), int.Parse(strYear), BaseUserID);



        // ************* code modified by Manish on 6-feb 2010 ref 3.3 **************************
        //description payperiod dates changes

        string[] strArray = new string[2];
        string strFromDate, strToDate;
        strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(strMonth), int.Parse(strYear));
        strFromDate = strArray[0];
        strToDate = strArray[1];
        ds = objRoster.GeneratePaysum(BaseCompanyCode, strDivision, strBranch, strFromDate, strToDate, BaseUserID);

        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    if (!GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())))
        //    {
        //        Response.Redirect("PaySumKuwait.aspx?errMsg=" + ds.Tables[0].Rows[0]["Comment"].ToString());
        //    }

        //}

        #region To Export To Text File
        StringBuilder str = new StringBuilder();
        string strStartDate;
        string strEndDate;
        string strHolidayOTHours;
        string strDutyOT;
        string strWOOTHours;
        string strNormalOT;
        str.Append("H69");
        str.Append(strYear.Substring(2, 2));
        str.Append(strMonth);
        int DaysInMonth = DateTime.DaysInMonth(int.Parse(strYear), int.Parse(strMonth));
        strEndDate = DaysInMonth.ToString() + strMonth + strYear;
        str.Append(strEndDate);
        strStartDate = "01" + strMonth + strYear;
        str.AppendLine();
        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            str.Append("D69");
            for (int j = 0; j < 1; j++)
            {
                str.Append(ds.Tables[0].Rows[i]["EmployeeNumber"].ToString());
                if (ds.Tables[0].Rows[i]["Name"].ToString().Trim().Length < 41)
                {
                    str.Append(ds.Tables[0].Rows[i]["Name"].ToString().Trim());
                    str.Append(",");
                    for (int k = ds.Tables[0].Rows[i]["Name"].ToString().Trim().Length; k < 41; k++)
                    {
                        str.Append(" ");
                    }
                }
                else
                {
                    str.Append(ds.Tables[0].Rows[i]["Name"].ToString().Trim());
                    str.Append(",");
                }
                str.Append(strEndDate);
                strHolidayOTHours = ds.Tables[0].Rows[i]["HolidayOTHours"].ToString();
                if (strHolidayOTHours == "" || strHolidayOTHours == "0")
                {
                    strHolidayOTHours = "00000";
                }
                else
                {
                    strHolidayOTHours = GetReqFormatOutput(strHolidayOTHours, "000");
                }
                strHolidayOTHours.Replace(".", "");
                str.Append(strHolidayOTHours);
                str.Append(" ");
                if (ds.Tables[0].Rows[i]["DutyOT"].ToString() == "" || ds.Tables[0].Rows[i]["DutyOT"].ToString() == "0")
                {
                    strDutyOT = "00000";
                }
                else
                {
                    strDutyOT = ds.Tables[0].Rows[i]["DutyOT"].ToString();
                }
                if (ds.Tables[0].Rows[i]["WOOTHours"].ToString() == "" || ds.Tables[0].Rows[i]["WOOTHours"].ToString() == "0")
                {
                    strWOOTHours = "00000";
                }
                else
                {
                    strWOOTHours = ds.Tables[0].Rows[i]["WOOTHours"].ToString();
                }
                strNormalOT = (double.Parse(strDutyOT) + double.Parse(strWOOTHours)).ToString();
                if (strNormalOT == "" || strNormalOT == "0")
                {
                    strNormalOT = "00000";
                }
                else
                {
                    strNormalOT = GetReqFormatOutput(strNormalOT, "000");
                }
                strNormalOT.Replace(".", "");
                str.Append(strNormalOT);
                str.Append(" ");
                str.Append("00000");
                str.Append(" ");
                str.Append(strStartDate);
                str.Append(strEndDate);
            }

            str.AppendLine();

        }

        string strTotalRowCount;
        string strtmpHours = "0000";
        strHolidayOTHours = "";
        strNormalOT = "";
        double HolidayOTHours = 0;
        double NormalOTHours = 0;
        str.Append("T69");
        //str.Append(strMonth);
        //str.Append(strYear.Substring(2,2));
        str.Append(strEndDate);
        strTotalRowCount = ds.Tables[0].Rows.Count.ToString();
        if (strTotalRowCount.Length < 4)
        {
            strTotalRowCount = strtmpHours.Substring(int.Parse(strTotalRowCount.ToString().Length.ToString()), int.Parse(strtmpHours.Length.ToString()) - int.Parse(strTotalRowCount.ToString().Length.ToString())) + strTotalRowCount; ;
        }
        str.Append(strTotalRowCount);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["HolidayOTHours"].ToString() == "" || ds.Tables[0].Rows[i]["HolidayOTHours"].ToString() == "0")
            {
                HolidayOTHours = double.Parse(HolidayOTHours.ToString()) + double.Parse("00000000");
            }
            else
            {

                HolidayOTHours = (double.Parse(HolidayOTHours.ToString()) + double.Parse(ds.Tables[0].Rows[i]["HolidayOTHours"].ToString()));
            }

            if (ds.Tables[0].Rows[i]["DutyOT"].ToString() == "" || ds.Tables[0].Rows[i]["DutyOT"].ToString() == "0")
            {
                strDutyOT = "00000000";
            }
            else
            {
                strDutyOT = ds.Tables[0].Rows[i]["DutyOT"].ToString();
            }
            if (ds.Tables[0].Rows[i]["WOOTHours"].ToString() == "" || ds.Tables[0].Rows[i]["WOOTHours"].ToString() == "0")
            {
                strWOOTHours = "00000000";
            }
            else
            {
                strWOOTHours = ds.Tables[0].Rows[i]["WOOTHours"].ToString();
            }
            NormalOTHours = NormalOTHours + (double.Parse(strDutyOT) * 60 + double.Parse(strWOOTHours) * 60);

        }
        if (HolidayOTHours.ToString() == "" || HolidayOTHours.ToString() == "0")
        {
            strHolidayOTHours = "00000000";
        }
        else
        {
            strHolidayOTHours = GetReqFormatOutput(HolidayOTHours.ToString(), "000000");
        }
        strHolidayOTHours.Replace(".", "");
        str.Append(strHolidayOTHours);
        str.Append(" ");
        if (NormalOTHours.ToString() == "" || NormalOTHours.ToString() == "0")
        {
            strNormalOT = "00000000";
        }
        else
        {
            //NormalOTHours = NormalOTHours * 60; 
            double Remainder = (double.Parse(NormalOTHours.ToString())) % 60;
            Remainder = double.Parse(Remainder.ToString().Replace(".", ""));
            int Dividend = (int)double.Parse((NormalOTHours / 60).ToString());
            NormalOTHours = double.Parse(Dividend.ToString() + "." + Remainder.ToString());
            strNormalOT = GetReqFormatOutput(NormalOTHours.ToString(), "000000");
            strNormalOT = strNormalOT.Substring(0, 8);

        }

        strNormalOT.Replace(".", "");
        str.Append(strNormalOT);
        str.Append(" ");
        str.Append("00000000");
        //str.Append(" ");


        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.txt");
        //Response.Charset = "";
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.text";

        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        Response.Write(str.ToString());
        Response.End();
        #endregion


        #region To Export to Excel From Dataset
        /******************* Export to Excel Format ******************************************/

        //DataTable dtDayName = new DataTable();
        //int StartDay = int.Parse(DateTime.Parse(strFromDate.ToString()).ToString("dd"));
        //int EndDay = int.Parse(DateTime.Parse(strToDate.ToString()).ToString("dd"));
        //dtDayName.Rows.Add(dtDayName.NewRow());
        //DateTime dtDate = DateTime.Parse(strFromDate.ToString());
        //for (int i = StartDay; i <= EndDay; i++)
        //{
        //    DataColumn dCol1 = new DataColumn(i.ToString(), typeof(System.String));
        //    dtDayName.Columns.Add(dCol1);
        //    dtDayName.Rows[0][i - 1] = dtDate.ToString("ddd");
        //    dtDate = dtDate.AddDays(1);
        //}
        //Response.Clear();
        //Response.AddHeader("Content-Disposition", "attachment; filename=PaySum.xls");
        //Response.ContentType = "application/octet-stream";
        //Response.Write("<html>");
        //Response.Write("<head>");
        //Response.Write("<style type='text/css'>");
        //Response.Write("</style>");
        //Response.Write("</head>");
        //Response.Write("<body>");
        //Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
        //Response.Write("<tr>");
        //Response.Write("<td style='text-align:center;'  bgcolor='aqua' colspan='35'></td>");
        //Response.Write("</tr>");
        //Response.Write("<tr>");
        //Response.Write("<td bgcolor='aqua'>Region</td>");
        //Response.Write("<td  bgcolor='yellow'>" + ds.Tables[0].Rows[0]["Division"].ToString() + "</td>");
        //Response.Write("</tr>");
        //Response.Write("<tr>");
        //Response.Write("<td bgcolor='aqua'>Branch</td>");
        //Response.Write("<td bgcolor='yellow'>" + ds.Tables[0].Rows[0]["Branch"].ToString() + "</td>");
        //Response.Write("</tr>");
        //Response.Write("<tr>");
        //Response.Write("<td bgcolor='aqua'>Project</td>");
        //Response.Write("<td  bgcolor='yellow'>" + ds.Tables[0].Rows[0]["ClientCode"].ToString() + "&nbsp&nbsp" + "</td>");
        //Response.Write("</tr>");
        //Response.Write("<tr>");
        //Response.Write("<td bgcolor='aqua'>Month</td>");
        //Response.Write("<td  bgcolor='yellow'>" + DateTime.Parse(strFromDate.ToString()).ToString("MMMM") + "</td>");
        //Response.Write("</tr>");
        //Response.Write("</table>");
        //Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
        //Response.Write("<tr></tr>");
        //Response.Write("<tr height=50>");
        //Response.Write("<td>ID NO</td>");
        //Response.Write("<td>Employee Name</td>");
        //Response.Write("<td>");
        //Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
        //Response.Write("<tr>");
        //Response.Write("<td colspan=32 style='text-align:center;' bordercolor='aqua'>" + DateTime.Parse(strFromDate.ToString()).ToString("MMMM") +"&nbsp " +DateTime.Parse(strFromDate.ToString()).ToString("yyyy") + "</td>");
        ////Response.Write("<td>"+ DateTime.Parse(strFromDate.ToString()).ToString("yyyy") + "</td>");


        //Response.Write("</tr>");
        //Response.Write("<tr>");
        //// To Show Day Name**********************
        //for (int i = 0; i < dtDayName.Columns.Count; i++)
        //{
        //    Response.Write("<td>" + Convert.ToString(dtDayName.Rows[0][i].ToString()).Substring(0, 1) + "</td>");
        //}
        ////*****************************************
        //Response.Write("</tr>");
        //Response.Write("<tr>");
        ////To Show Date[ Like 1,2,3,4...,30] in excel
        //for (int i = 7; i < ds.Tables[0].Columns.Count; i++)
        //{
        //    Response.Write("<td>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
        //}
        ////*******************************
        //Response.Write("</tr>");
        //Response.Write("</table>");
        //Response.Write("</tr>");
        //Response.Write("</table>");

        //Response.Write("<table width=200 border=1  bgcolor='aqua' cellspacing=0 cellpadding=2>");
        //// To Show Employee Details******************
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    Response.Write("<tr width='100%'>");
        //    for (int j = 5; j < ds.Tables[0].Columns.Count; j++)
        //    {
        //        Response.Write("<td   bgcolor='yellow'>" + ds.Tables[0].Rows[i][j].ToString() + "&nbsp&nbsp" + "</td>");
        //    }
        //    Response.Write("</tr>");
        //}
        ////********************************************
        //Response.Write("</table>");
        //Response.Write("</body>");
        //Response.Write("</html>");
        /*******************End OF Export to Excel Format ******************************************/

        #endregion
    }

    /// <summary>
    /// Gets the req format output.
    /// </summary>
    /// <param name="strHours">The string hours.</param>
    /// <param name="strtmpHours">The STRTMP hours.</param>
    /// <returns>System.String.</returns>
    private string GetReqFormatOutput(string strHours, string strtmpHours)
    {
        int intNormalOTHours;
        double FractionPart;
        intNormalOTHours = (int)decimal.Parse(strHours);
        FractionPart = double.Parse((decimal.Parse(strHours) - decimal.Parse(intNormalOTHours.ToString())).ToString());
        if (strHours == "" || strHours == "0")
        {
            strHours = strtmpHours;
        }
        else
        {
            if (strtmpHours == "000")
            {
                if (intNormalOTHours.ToString().Length < 3)
                {
                    strHours = strtmpHours.Substring(int.Parse(intNormalOTHours.ToString().Length.ToString()), int.Parse(strtmpHours.Length.ToString()) - int.Parse(intNormalOTHours.ToString().Length.ToString())) + intNormalOTHours; ;
                }
            }
            else
            {
                if (intNormalOTHours.ToString().Length < 6)
                {
                    strHours = strtmpHours.Substring(int.Parse(intNormalOTHours.ToString().Length.ToString()), int.Parse(strtmpHours.Length.ToString()) - int.Parse(intNormalOTHours.ToString().Length.ToString())) + intNormalOTHours; ;
                }
            }

            if (strHours.Contains("."))
            {
                FractionPart = double.Parse(FractionPart.ToString().Replace("0.", ""));
                if (FractionPart.ToString().Length < 2)
                {
                    strHours = intNormalOTHours.ToString() + (FractionPart * 10).ToString();
                }
                else
                {
                    strHours = intNormalOTHours.ToString() + FractionPart.ToString();
                }
            }
            else if (intNormalOTHours.ToString() == "0" || FractionPart.ToString() != "0.0")
            {
                FractionPart = double.Parse(FractionPart.ToString().Replace("0.", ""));
                if (FractionPart.ToString().Length < 2)
                {
                    strHours = strHours + (FractionPart * 10).ToString();
                }
                else
                {
                    strHours = strHours + FractionPart.ToString();
                }
            }
            //else
            //{
            if (strtmpHours == "000")
            {
                if (strHours.Length == 3)
                {
                    strHours = strHours + "00";
                }
                else if (strHours.Length == 4)
                {
                    strHours = strHours + "0";
                }
                else
                {
                    return strHours;
                }
            }
            else
            {
                if (strHours.Length == 6)
                {
                    strHours = strHours + "00";
                }
                else if (strHours.Length == 7)
                {
                    strHours = strHours + "0";
                }
                else
                {
                    return strHours;
                }
            }
            // }


        }
        return strHours;

    }


    /// <summary>
    /// Determines whether the specified the value is integer.
    /// </summary>
    /// <param name="theValue">The value.</param>
    /// <returns><c>true</c> if the specified the value is integer; otherwise, <c>false</c>.</returns>
    public static bool IsInteger(string theValue)
    {
        try
        {
            Convert.ToInt32(theValue);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
