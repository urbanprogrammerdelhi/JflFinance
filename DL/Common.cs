// ***********************************************************************
// Assembly         : DL
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
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Configuration;
/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class Common.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Common
    {
        /// <summary>
        /// My date format
        /// </summary>
        private static string myDateFormat = "MM-dd-yyyy HH:mm:ss";
        //private static string strDateFormatReports = "MM-dd-yyyy HH:mm:ss";//"dd-MMM-yyyy HH:mm:ss";

        /// <summary>
        /// Gets a value indicating whether the item is enabled. Returns User Read Rights.
        /// </summary>
        /// <value>The reports date format.</value>
        /// <exception cref="System.Exception">@</exception>
        protected static string ReportsDateFormat
        {
            get
            {
                try
                {
                    return WebConfigurationManager.AppSettings["DateFormatReports"].ToString(); //ConfigurationSettings.AppSettings["DateFormatReports"].ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception(@"", ex);
                }
            }
        }


        #region Function to Convert date to null if date=01/01/0001
        /// <summary>
        /// Converts the date to null.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public string ConvertDateToNull(string date)
        {
            string myDate = "01/01/1900";
            if (string.IsNullOrEmpty(date))
            {
                date = myDate;
            }

            Guard.ArgumentValidDate(date, "myDateArgument");

            if ((DateTime.Parse(date)) == (DateTime.Parse(myDate)))
            {
                return null;
            }
            else
            {
                DateTime dt = new DateTime();
                dt = DateTime.Parse(date);

                return dt.ToString(myDateFormat);
            }
        }
        #endregion
        #region Function to check whether date is null or not
        /// <summary>
        /// Checks the date null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public string CheckDateNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                DateTime dt = Convert.ToDateTime(null);
                return dt.ToString();
            }
            else
            {
                return value;
            }
        }
        #endregion
        #region Function To get Date Format(dd-MMM-yyyy)
        /// <summary>
        /// To get Date Format(dd-MMM-yyyy)
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="page">The page.</param>
        /// <returns>date with format dd-MMM-yyyy</returns>
        public static string DateFormat(string date, string page)
        {
            //if (System.Web.HttpContext.Current.Session["MyUICulture"].ToString().ToLower() == "ar-SA".ToLower())
            //{
            //    CultureInfo enCul = new CultureInfo("en-US");
            //    return DateTime.Parse(date).ToString(myDateFormat, enCul.DateTimeFormat);
            //}
            //else
            //{
            DateTime dt = new DateTime();
            string formatedDate;
            if (!string.IsNullOrEmpty(date))
            {
                dt = DateTime.Parse(date);
                formatedDate = dt.ToString(ReportsDateFormat);
            }
            else
            {
                formatedDate = null;
            }
            return formatedDate;
            // }
        }

        /// <summary>
        /// Dates the format.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.String.</returns>
        public static string DateFormat(string date)
        {
            Guard.ArgumentValidDate(date, "myDateArgument");

            DateTime dt = DateTime.Parse(date);
            return dt.ToString(ReportsDateFormat);
        }

        /// <summary>
        /// Dates the format.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="isNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns>System.String.</returns>
        public static string DateFormat(string date, bool isNullable)
        {
            if (isNullable == true && string.IsNullOrEmpty(date))
            {
                return null;
            }

            DateTime dt = new DateTime();
            string formatedDate;
            Guard.ArgumentValidDate(date, "myDateArgument");

            dt = DateTime.Parse(date);
            formatedDate = dt.ToString(myDateFormat);

            return formatedDate;
        }

        /// <summary>
        /// To get Date Format(dd-MMM-yyyy)
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>date with format dd-MMM-yyyy</returns>
        public static string DateFormat(DateTime date)
        {

            DateTime dt = new DateTime();
            string formatedDate;
            dt = date;
            formatedDate = dt.ToString(myDateFormat);
            return formatedDate;

        }

        /// <summary>
        /// Dates the format.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="isNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns>System.String.</returns>
        public static string DateFormat(DateTime date, bool isNullable)
        {
            if (isNullable == true && date == null)
            {
                return null;
            }

            DateTime dt = new DateTime();
            string formatedDate;
            dt = date;
            formatedDate = dt.ToString(myDateFormat);
            return formatedDate;

        }

        /// <summary>
        /// Dates the format.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.String.</returns>
        public static string DateFormat(string date,CultureInfo culture)
        {
            Guard.ArgumentValidDate(date, "myDateArgument");

            DateTime dt = DateTime.Parse(date);
            return dt.ToString("dd-MMM-yyyy",culture);
        }

        #endregion

        /// <summary>
        /// Checks the automatic generate number status.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckAutoGenerateNumberStatus(string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeDetail_CheckAutoGenerateNumberStatus", objParm);
            return ds;
        }

        #region To Get System Parameters

        /// <summary>
        /// Systems the parameters get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParametersGet(string userId, string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CommonSystemParameters_Get", objParm);
            return ds;
        }

        /// <summary>
        /// To get Default Currency from system parameters
        /// </summary>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterDefaultCurrencyGet(string LocationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSystemParameterDefaultCurrencyGet", objParm);
            return ds;
        }
        #endregion

        /// <summary>
        /// Currencies the get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet CurrencyGet()
        {
            // SqlParameter[] objParm = new SqlParameter[0];
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstCurrency_Get");
            return ds;
        }


        /// <summary>
        /// Soes the details test.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet SODetailsTest()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "GetTrnRoster");
            return ds;
        }

        /// <summary>
        /// This Function gets the Name of the Server for the Reporting Services reports.
        /// </summary>
        /// <returns>DataSet.</returns>
        public static DataSet GetServerName()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "GetServerName");
            return ds;

        }
    }
}
