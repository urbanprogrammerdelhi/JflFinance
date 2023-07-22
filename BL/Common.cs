// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Common.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Collections;
using System.Globalization;

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class Common.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Common
    {
        #region Create Data Table For Error Messages
        /// <summary>
        /// To return the error messages to interface layer
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="comment">The comment.</param>
        /// <returns>DataTable with Id, Error Message, comments</returns>
        public DataTable CreateErrorMessage(string tableName, string messageId, string message, string comment)
        {
            return MyRow(tableName, messageId, message, comment);
        }
        /// <summary>
        /// Mies the row.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="comment">The comment.</param>
        /// <returns>DataTable.</returns>
        private DataTable MyRow(string tableName, string messageId, string message, string comment)
        {
            // Use the MakeTable function below to create a new table.
            DataTable dt = new DataTable(tableName);
            dt = MyTable(tableName);
            // Once a table has been created, use the NewRow to create a DataRow.
            DataRow myRow;
            myRow = dt.NewRow();
            // Then add the new row to the collection.
            myRow[BL.Properties.Resources.fldMessageId] = messageId;
            myRow[BL.Properties.Resources.fldMessageString] = message;
            myRow[BL.Properties.Resources.fldComment] = comment;
            dt.Rows.Add(myRow);
            return dt;
        }
        /// <summary>
        /// Mies the column.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="autoIncrement">if set to <c>true</c> [automatic increment].</param>
        /// <returns>DataColumn.</returns>
        private DataColumn MyColumn(string dataType, string columnName, bool autoIncrement)
        {
            DataColumn dtColumn = new DataColumn();
            dtColumn.DataType = System.Type.GetType(dataType);
            dtColumn.ColumnName = columnName;
            dtColumn.AutoIncrement = autoIncrement;
            return dtColumn;
        }
        /// <summary>
        /// Mies the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DataTable.</returns>
        private DataTable MyTable(string tableName)
        {
            // Create a new DataTable titled ''
            DataTable dt = new DataTable(tableName);
            // Add three column objects to the table.
            DataColumn c = new DataColumn();
            DataColumn idc = new DataColumn();

            idc = MyColumn("System.Int32", BL.Properties.Resources.fldId, true);
            dt.Columns.Add(idc);
            c = MyColumn("System.String", BL.Properties.Resources.fldMessageId, false);
            dt.Columns.Add(c);
            c = MyColumn("System.String", BL.Properties.Resources.fldMessageString, false);
            dt.Columns.Add(c);
            c = MyColumn("System.String", BL.Properties.Resources.fldComment, false);
            dt.Columns.Add(c);

            // Create an array for DataColumn objects.
            DataColumn[] keys = new DataColumn[1];
            keys[0] = idc;
            dt.PrimaryKey = keys;
            // Return the new DataTable.
            return dt;
        }
        #endregion

        #region Function to Convert date to null if date=01/01/0001
        /// <summary>
        /// convert date into format dd-MMM-yyyy
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>null or date in format 'dd-MMM-yyyy'</returns>
        public string ConvertDateToNull(string date)
        {
            //validate input parameter date and throuh exception in case of invalid value.
            DL.Guard.ArgumentValidDate(date, "myDateArgument");

            string tempDate = "01/01/0001";
            if (DateTime.Parse(date) == DateTime.Parse(tempDate))
            {
                return null;
            }
            else
            {
                DateTime myDate = new DateTime();
                myDate = DateTime.Parse(date);
                string formatedDate = myDate.ToString("d--yyyy");
                return formatedDate;
            }
        }
        #endregion

        #region Function to check whether date is null or not
        /// <summary>
        /// Checks whether date is null or not
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>return null if input is empty</returns>
        public string CheckDateNull(string date)
        {
            if (string.IsNullOrEmpty(date) || string.IsNullOrEmpty(date))
            {
                DateTime dt = Convert.ToDateTime(null);
                return dt.ToString();
            }
            else
            {
                return date;
            }
        }
        #endregion

        #region Function To get date Format(dd-MMM-yyyy)
        /// <summary>
        /// To get date Format(dd-MMM-yyyy)
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>date with format dd-MMM-yyyy</returns>
        protected string DateFormat(string date)
        {
            ////validate input parameter date and throuh exception in case of invalid value.
            DL.Guard.ArgumentValidDate(date, "myDateArgument");

            DateTime dt = new DateTime();
            string formatedDate;
            dt = DateTime.Parse(date);
            formatedDate = dt.ToString("dd-MMM-yyyy");

            return formatedDate;
        }
        /// <summary>
        /// To get date Format(dd-MMM-yyyy)
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>date with format dd-MMM-yyyy</returns>
        protected string DateFormat(DateTime date)
        {
            DateTime dt = new DateTime();
            string formatedDate;
            if (date != null)
            {
                dt = date;
                formatedDate = dt.ToString("dd-MMM-yyyy");
            }
            else
            {
                formatedDate = "";
            }

            return formatedDate;
        }
        #endregion

        #region Functions to convert data in a textbox to a valid date
        /// <summary>
        /// function to convert string into a valid date [date format is "dd-MMM-yyyy"]
        /// </summary>
        /// <param name="myDate">My date.</param>
        /// <returns>return valid date</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public string ConvertToDate(string myDate)
        {
            //make sure myDate is not null
            DL.Guard.ArgumentNotNull(myDate, "myDate");

            int tempLength;
            int length = myDate.Trim().Length;
            if (myDate.Contains("-"))
            {
                tempLength = length - myDate.LastIndexOf('-');
                if (tempLength == 3)
                {
                    return "6";
                }
                myDate = myDate.Replace("-", "");
            }
            else if (myDate.Contains("/"))
            {
                tempLength = length - myDate.LastIndexOf('-');
                if (tempLength == 3)
                {
                    return "6";
                }
                myDate = myDate.Replace("/", "");
            }
            else if (myDate.Contains(":"))
            {
                tempLength = length - myDate.LastIndexOf('-');
                if (tempLength == 3)
                {
                    return "6";
                }
                myDate = myDate.Replace(":", "");
            }

            int flag = 1;
            if (length == 8)
            {
                try
                {
                    string tempDate = myDate.ToString().Substring(0, 2).ToString() + '-' + myDate.ToString().Substring(2, 2) + '-' + myDate.ToString().Substring(4, 4);
                    if (int.Parse(myDate.ToString().Substring(0, 2).ToString()) > 0 && int.Parse(myDate.ToString().Substring(0, 2).ToString()) < 32)
                    {
                        if (int.Parse(myDate.ToString().Substring(2, 2)) > 0 && int.Parse(myDate.ToString().Substring(2, 2)) < 13)
                        {
                            if (int.Parse(myDate.ToString().Substring(4, 4)) > 1900 && int.Parse(myDate.ToString().Substring(4, 4)) < 3999)
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
                        int day = int.Parse(myDate.ToString().Substring(0, 2));
                        int Month = int.Parse(myDate.ToString().Substring(2, 2));
                        int year = int.Parse(myDate.ToString().Substring(4, 4));
                        int days = GetDaysInMonth(Month);// to check the maximum number of days in a month
                        if (days >= int.Parse(myDate.ToString().Substring(0, 2)))
                        {
                            year = int.Parse(myDate.ToString().Substring(4, 4));
                            if (int.Parse(myDate.ToString().Substring(2, 2)) == 02 && int.Parse(myDate.ToString().Substring(0, 2)) >= 29)
                            {
                                if (IsLeapYear(year) == true)
                                {
                                    if (int.Parse(myDate.ToString().Substring(0, 2)) > 29)
                                    {
                                        return "3";
                                    }
                                    else if (int.Parse(myDate.ToString().Substring(0, 2)) <= 29)
                                    {
                                        string MonthName = GetMonthName(Month);
                                        if (day > 0 && day <= 10) // if removed page will refresh 2 times if day is less than 10 because date format is "dd-MMM-yyyy"
                                        {
                                            tempDate = DateFormat("0" + day.ToString() + '-' + MonthName + '-' + year.ToString());
                                        }
                                        else
                                        {
                                            tempDate = DateFormat(day.ToString() + '-' + MonthName + '-' + year.ToString());
                                        }
                                        return tempDate;
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
                                    tempDate = DateFormat("0" + day.ToString() + '-' + MonthName + '-' + year.ToString());
                                }
                                else
                                {
                                    tempDate = DateFormat(day.ToString() + '-' + MonthName + '-' + year.ToString());
                                }
                                return tempDate;
                            }
                        }
                        else
                        {
                            return "5";
                        }
                    }
                }
                catch
                {
                    throw new ArgumentException(String.Format("Unable to convert date {0} .", myDate));
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
        /// Gets the name of the month.
        /// </summary>
        /// <param name="monthName">Name of the month.</param>
        /// <returns>System.String.</returns>
        private string GetMonthName(int monthName)
        {
            if (monthName == 1)
            {
                return "Jan";
            }
            else if (monthName == 2)
            {
                return "Feb";
            }
            else if (monthName == 3)
            {
                return "Mar";
            }
            else if (monthName == 4)
            {
                return "Apr";
            }
            else if (monthName == 5)
            {
                return "May";
            }
            else if (monthName == 6)
            {
                return "Jun";
            }
            else if (monthName == 7)
            {
                return "Jul";
            }
            else if (monthName == 8)
            {
                return "Aug";
            }
            else if (monthName == 9)
            {
                return "Sep";
            }
            else if (monthName == 10)
            {
                return "Oct";
            }
            else if (monthName == 11)
            {
                return "Nov";
            }
            else if (monthName == 12)
            {
                return "Dec";
            }
            return "";
        }
        /// <summary>
        /// Function to check if a year is a leap year
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>true or false</returns>
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
        /// <returns>number</returns>
        public int GetDaysInMonth(int month)
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
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if [is valid date] [the specified date]; otherwise, <c>false</c>.</returns>
        public bool IsValidDate(string date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                if (dt.Year >= 1900)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;// throw new ArgumentException(String.Format("Unable to validate date {0} .", date));
            }
        }

       
        #endregion

        /// <summary>
        /// To get the list of parameters
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>sorted list of parameters</returns>
        public SortedList OperatorNameGet(string type)
        {
            //Checks whether type is null
            DL.Guard.ArgumentNotNull(type, "OperatorType");

            SortedList sl = new SortedList();
            if (type.Equals("String"))
            {
                sl["Like"] = "Like";
                sl["Not Like"] = "Not Like";
                sl["="] = "Equal To";
                sl["<>"] = "Not Equal To";

                return sl;
            }
            else if (type.Equals("AndOrOperator"))
            {
                sl["AND"] = "AND";
                sl["OR"] = "OR";
                return sl;
            }
            return sl;

        }

        /// <summary>
        /// To check whether employee number is auto generated or not
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>dataset with auto generate status value</returns>
        public DataSet CheckAutoGenerateNumberStatus(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.Common objCommon = new DL.Common();
            DataSet ds = objCommon.CheckAutoGenerateNumberStatus(companyCode, hrLocationCode, locationCode);
            return ds;
        }

        #region function related to payperiod dates
        /// <summary>
        /// To Get Start date and End date of given pay period code
        /// </summary>
        /// <param name="payPeriodCode">The pay period code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="monthValue">The month value.</param>
        /// <param name="yearValue">The year value.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>string array with two elements</returns>
        public string[] SetDatesFromPayPeriod(string payPeriodCode, string companyCode, int monthValue, int yearValue, string hrLocationCode, string locationCode)
        {
            DL.Guard.ArgumentInRange<int>(monthValue, 1, 12, "Month");
            DL.Guard.ArgumentInRange<int>(yearValue, 1900, 2100, "Year");
            DL.Guard.ArgumentNotNullOrEmptyString(payPeriodCode, "PayPeriodCode");
            DL.Guard.ArgumentNotNullOrEmptyString(companyCode, "CompanyCode");


            string strMonth, strPrvMonth;
            string strFromDate = "";
            string strToDate = "";

            DateTime date = new DateTime(1900, monthValue, 1);
            strMonth = date.ToString("");

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            DL.Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][BL.Properties.Resources.fldFromDay].ToString(), "myIntArgument");
            DL.Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][BL.Properties.Resources.fldToDay].ToString(), "myIntArgument");

            ds = objMastersManagement.CompanyPayPeriodGet(payPeriodCode, companyCode, hrLocationCode, locationCode);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldFromDay].ToString()) > 1 && int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldFromDay].ToString()) > int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldToDay].ToString()))
                {
                    if (monthValue > 1)
                    {
                        DateTime date1 = new DateTime(1900, (monthValue - 1), 1);
                        strPrvMonth = date1.ToString("");
                        strFromDate = DateFormat(ds.Tables[0].Rows[0][BL.Properties.Resources.fldFromDay].ToString() + "-" + strPrvMonth + "-" + yearValue.ToString());
                    }
                    else
                    {
                        strFromDate = DateFormat(ds.Tables[0].Rows[0][BL.Properties.Resources.fldFromDay].ToString() + "-Dec-" + (yearValue - 1).ToString());
                    }
                    strToDate = DateFormat(ds.Tables[0].Rows[0][BL.Properties.Resources.fldToDay].ToString() + "-" + strMonth + "-" + yearValue.ToString());
                }
                else if (int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldFromDay].ToString()) < int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldToDay].ToString()))
                {
                    strFromDate = DateFormat(ds.Tables[0].Rows[0][BL.Properties.Resources.fldFromDay].ToString() + "-" + strMonth + "-" + yearValue.ToString());
                    //strToDate = DateFormat(ds.Tables[0].Rows[0][BL.Properties.Resources.fldToDay].ToString() + "-" + strMonth + "-" + yearValue.ToString());

                    if (int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldToDay].ToString()) >= 30)
                    {
                        strToDate = DateFormat(LastDateOfMonth(strFromDate) + "-" + strMonth + "-" + yearValue.ToString());
                    }
                    else
                    {
                        strToDate = DateFormat(LastDateOfMonth(strFromDate) + "-" + strMonth + "-" + yearValue.ToString());
                    }

                }
            }
            string[] strArray = new string[2];
            strArray[0] = strFromDate;
            strArray[1] = strToDate;

            ds.Dispose();

            return strArray;
        }

        /// <summary>
        /// To Get Last date of month
        /// </summary>
        /// <param name="date1">The date1.</param>
        /// <returns>day value</returns>
        private String LastDateOfMonth(string date1)
        {
            //Check whether date1 is a valid input
            DL.Guard.ArgumentValidDate(date1, "myDateArgument");

            TimeSpan Ts = DateTime.Parse(date1).AddMonths(1) - DateTime.Parse(date1);
            String days = Ts.Days.ToString();
            return days;
        }

        #endregion

        #region To Get System Parameters
        /// <summary>
        /// To Get system parameters
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>dataset contains system parameter values</returns>
        public DataSet SystemParametersGet(string userId, string companyCode, string hrLocationCode, string locationCode)
        {
            DL.Common objCommon = new DL.Common();
            DataSet ds = objCommon.SystemParametersGet(userId, companyCode, hrLocationCode, locationCode);
            return ds;
        }

        /// <summary>
        /// To get Default Currency from system parameters
        /// </summary>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterDefaultCurrencyGet(string LocationAutoId)
        {
            DL.Common objCommon = new DL.Common();
            DataSet ds = objCommon.SystemParameterDefaultCurrencyGet(LocationAutoId);
            return ds;
        }

        #endregion

        #region To Get System Currency

        /// <summary>
        /// To Get currency name and symbol
        /// </summary>
        /// <returns>dataset</returns>
        public DataSet CurrencyGet()
        {
            DL.Common objCommon = new DL.Common();
            DataSet ds = objCommon.CurrencyGet();
            return ds;
        }


        #endregion

        #region To Validate The Special Characters In The String
        /// <summary>
        /// To Validate The Special Characters In The String
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <returns>System.String.</returns>
        public static string ValidateSpecialCharacter(string strValue)
        {
            if (strValue == null)
            {
                return null;
            }

            string formatedstrValue;
            formatedstrValue = strValue.Replace("'", "''");
            return formatedstrValue;
        }
        #endregion

    }


}
