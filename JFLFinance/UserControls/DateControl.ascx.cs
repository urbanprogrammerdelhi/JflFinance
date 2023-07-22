// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="DateControl.ascx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// Class UserControls_DateControl.
/// </summary>
public partial class UserControls_DateControl : System.Web.UI.UserControl
{
    /// <summary>
    /// The date
    /// </summary>
    private static string date;
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>The text.</value>
    public string Text
    {
        get { return date; }
        set { date = value; }
    }
    //public string ErrorColor
    //{
    //    get { return System.Drawing.Color.Aqua; }
    //    set { System.Drawing.Color.Aqua = value; }
    //}
    //public string EmptyColor
    //{
    //    get { return System.Drawing.Color.Empty; }
    //    set { System.Drawing.Color.Empty = value; }
    //}
    /// <summary>
    /// Handles the TextChanged event of the txtDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

        if (IsValidDate(txtDate.Text))
        {
            txtDate.Text = DateTime.Parse(txtDate.Text).ToString("dd-MMM-yyyy");
            date = txtDate.Text;
            txtDate.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            date = ConvertToDate(txtDate.Text);
            if (date == "1")
            {
                lblErrorMsg.Text = "Year not in correct format ";
                txtDate.Text = txtDate.Text;
                date = lblErrorMsg.Text;
                //this.ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Aqua;
            }
            else if (date == "2")
            {
                lblErrorMsg.Text = "Month not in correct format";
                txtDate.Text = txtDate.Text;
                //this.ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Aqua;
            }
            else if (date == "3")
            {
                lblErrorMsg.Text = "Day not in correct format";
                txtDate.Text = txtDate.Text;
                //this.ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Aqua;
            }
            else if (date == "4")
            {
                lblErrorMsg.Text = "Not a leap year";
                txtDate.Text = txtDate.Text;
                // this.ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Aqua;
            }
            else if (date == "5")
            {
                lblErrorMsg.Text = "Number of days not correct";
                txtDate.BackColor = System.Drawing.Color.Aqua;
                txtDate.Text = txtDate.Text;
                // this.ToolkitScriptManager2.SetFocus(txtDate);
            }
            else if (date == "6")
            {
                lblErrorMsg.Text = "Date not in correct format";
                txtDate.BackColor = System.Drawing.Color.Aqua;
                txtDate.Text = txtDate.Text;
                // this.ToolkitScriptManager2.SetFocus(txtDate);
            }
            else
            {
                txtDate.Text = date;
                date = txtDate.Text;
                txtDate.BackColor = System.Drawing.Color.Empty;
            }
        }
    }
    #region Functions to convert data in a textbox to a valid date
    /// <summary>
    /// function to convert string into a valid date [Date format is "dd-MMM-yyyy"]
    /// </summary>
    /// <param name="Date">The date.</param>
    /// <returns>System.String.</returns>
    public string ConvertToDate(string Date)
    {
        int tempLength;
        int length = Date.Trim().Length;
        if (Date.Contains("-"))
        {
            tempLength = length - Date.LastIndexOf('-');
            if (tempLength == 3)
            {
                return "6";
            }
            Date = Date.Replace("-", "");
        }
        else if (Date.Contains("/"))
        {
            tempLength = length - Date.LastIndexOf('-');
            if (tempLength == 3)
            {
                return "6";
            }
            Date = Date.Replace("/", "");
        }
        else if (Date.Contains(":"))
        {
            tempLength = length - Date.LastIndexOf('-');
            if (tempLength == 3)
            {
                return "6";
            }
            Date = Date.Replace(":", "");
        }

        int flag = 1;
        if (length == 8)
        {
            try
            {
                string strDate = Date.ToString().Substring(0, 2).ToString() + '-' + Date.ToString().Substring(2, 2) + '-' + Date.ToString().Substring(4, 4);
                if (int.Parse(Date.ToString().Substring(0, 2).ToString()) > 0 && int.Parse(Date.ToString().Substring(0, 2).ToString()) < 32)
                {
                    if (int.Parse(Date.ToString().Substring(2, 2)) > 0 && int.Parse(Date.ToString().Substring(2, 2)) < 13)
                    {
                        if (int.Parse(Date.ToString().Substring(4, 4)) > 1900 && int.Parse(Date.ToString().Substring(4, 4)) < 3999)
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                            return "1";
                        }
                    }
                    else
                    {
                        flag = 0;
                        return "2";
                    }
                }
                else
                {
                    flag = 0;
                    return "3";
                }
                if (flag == 1)
                {
                    int day = int.Parse(Date.ToString().Substring(0, 2));
                    int Month = int.Parse(Date.ToString().Substring(2, 2));
                    int year = int.Parse(Date.ToString().Substring(4, 4));
                    int days = GetDaysInMonth(Month);// to check the maximum number of days in a month
                    if (days >= int.Parse(Date.ToString().Substring(0, 2)))
                    {
                        year = int.Parse(Date.ToString().Substring(4, 4));
                        if (int.Parse(Date.ToString().Substring(2, 2)) == 02 && int.Parse(Date.ToString().Substring(0, 2)) >= 29)
                        {
                            if (IsLeapYear(year) == true)
                            {
                                if (int.Parse(Date.ToString().Substring(0, 2)) > 29)
                                {
                                    return "3";
                                }
                                else if (int.Parse(Date.ToString().Substring(0, 2)) <= 29)
                                {
                                    string MonthName = GetMonthName(Month);
                                    if (day > 0 && day <= 10) // if removed page will refresh 2 times if day is less than 10 because date format is "dd-MMM-yyyy"
                                    {
                                        strDate = DateFormat("0" + day.ToString() + '-' + MonthName + '-' + year.ToString());
                                    }
                                    else
                                    {
                                        strDate = DateFormat(day.ToString() + '-' + MonthName + '-' + year.ToString());
                                    }
                                    return strDate;
                                }
                            }
                            else
                            {
                                return "4";
                            }
                        }
                        else
                        {
                            string MonthName = GetMonthName(Month);
                            if (day > 0 && day <= 10)
                            {
                                strDate = DateFormat("0" + day.ToString() + '-' + MonthName + '-' + year.ToString());
                            }
                            else
                            {
                                strDate = DateFormat(day.ToString() + '-' + MonthName + '-' + year.ToString());
                            }
                            return strDate;
                        }
                    }
                    else
                    {
                        return "5";
                    }
                }
            }
            catch (Exception)
            {
                return "6";
            }
        }
        else
        {
            return "6";
        }
        // }
        return "";
    }
    /// <summary>
    /// fuction to get the month name based on the month number
    /// </summary>
    /// <param name="MonthName">Name of the month.</param>
    /// <returns>System.String.</returns>
    private string GetMonthName(int MonthName)
    {
        if (MonthName == 1)
        {
            return "Jan";
        }
        else if (MonthName == 2)
        {
            return "Feb";
        }
        else if (MonthName == 3)
        {
            return "Mar";
        }
        else if (MonthName == 4)
        {
            return "Apr";
        }
        else if (MonthName == 5)
        {
            return "May";
        }
        else if (MonthName == 6)
        {
            return "Jun";
        }
        else if (MonthName == 7)
        {
            return "Jul";
        }
        else if (MonthName == 8)
        {
            return "Aug";
        }
        else if (MonthName == 9)
        {
            return "Sep";
        }
        else if (MonthName == 10)
        {
            return "Oct";
        }
        else if (MonthName == 11)
        {
            return "Nov";
        }
        else if (MonthName == 12)
        {
            return "Dec";
        }
        return "";
    }
    /// <summary>
    /// Function to check if a year is a leap year
    /// </summary>
    /// <param name="year">The year.</param>
    /// <returns><c>true</c> if [is leap year] [the specified year]; otherwise, <c>false</c>.</returns>
    private bool IsLeapYear(int year)
    {
        if ((year % 400) == 0)
        {
            return true;
        }
        else if ((year % 100) == 0)
        {
            return false;
        }
        else if ((year % 4) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Function to get the maximum number of days in a month
    /// </summary>
    /// <param name="month">The month.</param>
    /// <returns>System.Int32.</returns>
    private int GetDaysInMonth(int month)
    {
        if (1 == month || 3 == month || 5 == month || 7 == month || 8 == month || 10 == month || 12 == month)
        {
            return 31;
        }
        else
        {
            return 30;
        }
    }
    /// <summary>
    /// function to check if a date is valid or not
    /// </summary>
    /// <param name="strDate">The string date.</param>
    /// <returns><c>true</c> if [is valid date] [the specified string date]; otherwise, <c>false</c>.</returns>
    public bool IsValidDate(string strDate)
    {
        try
        {
            DateTime dt = DateTime.Parse(strDate);
            if (dt.Year >= 1900)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion

    /// <summary>
    /// To get Date Format(dd-MMM-yyyy)
    /// </summary>
    /// <param name="strdate">The strdate.</param>
    /// <returns>date with format dd-MMM-yyyy</returns>
    private string DateFormat(string strdate)
    {
        DateTime dt = new DateTime();
        string formatedDate;
        if (strdate != "")
        {
            dt = DateTime.Parse(strdate);
            formatedDate = dt.ToString("dd-MMM-yyyy");
        }
        else
        {
            formatedDate = "";
        }
        return formatedDate;
    }
}
