// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="BusinessRule.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// The DL namespace.
/// </summary>
[assembly: CLSCompliantAttribute(false)]
namespace DL
{
    /// <summary>
    /// Class BusinessRule.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class BusinessRule
    {
        /// <summary>
        /// Systems the parameter get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterGet(string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSystemParameter_GetAll", objParam);
            return ds;
        }

        #region Function related to generic business rules

        #region function related to rule creation
        /// <summary>
        /// Businesses the rule get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleGet(string businessRuleCode, int locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_BusinessRule_Get", objParam);
            return ds;
        }

        /// <summary>
        /// For Add new business rule
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="businessRuleDesc">The business rule desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractDays">The contract days.</param>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="isDefaultRule">if set to <c>true</c> [is default rule].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="jobClass">The job class.</param>
        /// <param name="jobType">Type of the job.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <param name="PaySumDesc">The pay sum desc.</param>
        /// <param name="considerBreakHrs">if set to <c>true</c> [consider break HRS].</param>
        /// <param name="considerUnconfirmedDuty">if set to <c>true</c> [consider unconfirmed duty].</param>
        /// <returns>DataSet.</returns>
        /// Modified  13-Jan-2014
        /// Added new  column value designation
        public DataSet BusinessRuleAddNew(string businessRuleCode, string businessRuleDesc, string companyCode, string hrLocationCode, string locationCode, string clientCode, string contractDays, string categoryCode, string effectiveFrom, string effectiveTo, bool isDefaultRule, string modifiedBy, int locationAutoId, string jobClass, string jobType, string designation, string paySumCode, string PaySumDesc, bool considerBreakHrs, bool considerUnconfirmedDuty)
        {
            SqlParameter[] objParam = new SqlParameter[20];

            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleDesc, businessRuleDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ContractDays, contractDays);
            objParam[7] = new SqlParameter(DL.Properties.Resources.EmpCategoryCode, categoryCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, effectiveFrom);
            objParam[9] = new SqlParameter(DL.Properties.Resources.EffectiveTo, effectiveTo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.IsDefaultRule, isDefaultRule);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[12] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            objParam[13] = new SqlParameter(DL.Properties.Resources.JobClass, jobClass);
            objParam[14] = new SqlParameter(DL.Properties.Resources.JobType, jobType);
            objParam[15] = new SqlParameter(DL.Properties.Resources.Designation, designation);
            objParam[16] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            objParam[17] = new SqlParameter(DL.Properties.Resources.PaysumCodeDesc, PaySumDesc);
            objParam[18] = new SqlParameter(DL.Properties.Resources.ConsiderBreakHrs, considerBreakHrs);
            objParam[19] = new SqlParameter(DL.Properties.Resources.ConsiderUnconfirmedDuty, considerUnconfirmedDuty);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_BusinessRule_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Businesses the rule update.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="businessRuleDesc">The business rule desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractDays">The contract days.</param>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="isDefaultRule">if set to <c>true</c> [is default rule].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="jobClass">The job class.</param>
        /// <param name="jobType">Type of the job.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="considerBreakHrs">if set to <c>true</c> [consider break HRS].</param>
        /// <param name="considerUnconfirmedDuty">if set to <c>true</c> [consider unconfirmed duty].</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleUpdate(string businessRuleCode, string businessRuleDesc, string companyCode, string hrLocationCode, string locationCode, string clientCode, string contractDays, string categoryCode, string effectiveFrom, string effectiveTo, bool isDefaultRule, string modifiedBy, string jobClass, string jobType, string designation,bool considerBreakHrs, bool considerUnconfirmedDuty)
        {
            SqlParameter[] objParam = new SqlParameter[17];

            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleDesc, businessRuleDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ContractDays, contractDays);
            objParam[7] = new SqlParameter(DL.Properties.Resources.EmpCategoryCode, categoryCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, effectiveFrom);
            objParam[9] = new SqlParameter(DL.Properties.Resources.EffectiveTo, effectiveTo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.IsDefaultRule, isDefaultRule);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            objParam[12] = new SqlParameter(DL.Properties.Resources.JobClass, jobClass);
            objParam[13] = new SqlParameter(DL.Properties.Resources.JobType, jobType);
            objParam[14] = new SqlParameter(DL.Properties.Resources.Designation, designation);
            objParam[15] = new SqlParameter(DL.Properties.Resources.ConsiderBreakHrs, considerBreakHrs);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ConsiderUnconfirmedDuty, considerUnconfirmedDuty);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_BusinessRule_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Businesses the rule delete.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleDelete(string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode); ;
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRule_Delete", objParam);
            return ds;
        }
        #endregion
        #region function related to payperiod
        /// <summary>
        /// BusinessRule is replaced from PaysumCode
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodGet(string paySumCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_Payperiod_Get", objParam);
            return ds;
        }
        /// <summary>
        /// BusinessRule is replaced from PaysumCode
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <param name="payPeriodType">Type of the pay period.</param>
        /// <param name="monthStartDay">The month start day.</param>
        /// <param name="monthEndDay">The month end day.</param>
        /// <param name="firstFortnightStartDay">The first fortnight start day.</param>
        /// <param name="firstFortnightEndDay">The first fortnight end day.</param>
        /// <param name="secondFortnightStartDay">The second fortnight start day.</param>
        /// <param name="secondFortnightEndDay">The second fortnight end day.</param>
        /// <param name="weekFirstDay">The week first day.</param>
        /// <param name="weekLastDay">The week last day.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodInsert(string paySumCode, string payPeriodType, int monthStartDay, int monthEndDay, int firstFortnightStartDay, int firstFortnightEndDay, int secondFortnightStartDay, int secondFortnightEndDay, string weekFirstDay, string weekLastDay, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[11];

            objParam[0] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.PayPeriodType, payPeriodType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.MonthStartDay, monthStartDay);
            objParam[3] = new SqlParameter(DL.Properties.Resources.MonthEndDay, monthEndDay);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FirstFortNightStartDay, firstFortnightStartDay);
            objParam[5] = new SqlParameter(DL.Properties.Resources.FirstFortNightEndDay, firstFortnightEndDay);
            objParam[6] = new SqlParameter(DL.Properties.Resources.SecondFortNightStartDay, secondFortnightStartDay);
            objParam[7] = new SqlParameter(DL.Properties.Resources.SecondFortNightEndDay, secondFortnightEndDay);
            objParam[8] = new SqlParameter(DL.Properties.Resources.WeekFirstDay, weekFirstDay);
            objParam[9] = new SqlParameter(DL.Properties.Resources.WeekLastDay, weekLastDay);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PayPeriod_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// Pays the period delete.
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodDelete(string paySumCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PayPeriod_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// Pays the period collection get.
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodCollectionGet(string paySumCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PayPeriodCollection_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Pays the period collection insert.
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodCollectionInsert(string paySumCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PayPeriodCollection_Insert", objParam);
            return ds;
        }
        #endregion
        #region function related to hours distribution

        /// <summary>
        /// Hourses the head distribution rule get.
        /// </summary>
        /// <param name="weekday">The weekday.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="overTimebasedOnperiod">The over timebased onperiod.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadDistributionRuleGet(string weekday, string shiftCode, string hoursHeadGroupCode, string businessRuleCode, string overTimebasedOnperiod)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WeekDay, weekday);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.OverTimeBasedOnPeriod, overTimebasedOnperiod);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHeadDistribution_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Nws the condition hours distribution_ get.
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet NWConditionHoursDistribution_Get(string hoursHeadGroupCode, string guid)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Guid, guid);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_NWConditionHoursDistribution_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Get details of not working hours
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet NotWorkingHoursHeadDistributionRuleGet(string hoursHeadGroupCode, string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_NWHoursHeadDistribution_Get", objParam);
            return ds;
        }


        /// <summary>
        /// Hourses the head distribution rule insert.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="weekday">The weekday.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="dt">The dt.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="dutyTypeDataTable">The duty type data table.</param>
        /// <param name="isScheduleBasedOT">The is schedule based ot.</param>
        /// <param name="includeZeroHoursSchedule">if set to <c>true</c> [include zero hours schedule].</param>
        /// <param name="overTimebasedOnperiod">The over timebased onperiod.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadDistributionRuleInsert(string businessRuleCode, string weekday, string shiftCode, string hoursHeadGroupCode, DataTable dt, string modifiedBy, DataTable dutyTypeDataTable, int isScheduleBasedOT, bool includeZeroHoursSchedule, string overTimebasedOnperiod,string leaveCode)
        {

            string hoursHeadCode;
            float intHoursFrom, intHoursTo;
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (dt == null)
            {
                return ds;
            }

           // using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
           // {
                string rowGuid = Guid.NewGuid().ToString();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hoursHeadCode = dt.Rows[i]["HoursHeadCode"].ToString();
                    intHoursFrom = float.Parse(dt.Rows[i][DL.Properties.Resources.fldTimeFrom].ToString());
                    intHoursTo = float.Parse(dt.Rows[i][DL.Properties.Resources.fldTimeTo].ToString());
                    for (int j = 0; j < dutyTypeDataTable.Rows.Count; j++)
                    {
                        SqlParameter[] objParam = new SqlParameter[18];
                        objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
                        objParam[1] = new SqlParameter(DL.Properties.Resources.WeekDay, weekday);
                        objParam[2] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
                        objParam[3] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
                        objParam[4] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);
                        objParam[5] = new SqlParameter(DL.Properties.Resources.HoursFrom, intHoursFrom);
                        objParam[6] = new SqlParameter(DL.Properties.Resources.HoursTo, intHoursTo);
                        objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                        objParam[8] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeDataTable.Rows[j][0].ToString());
                        objParam[9] = new SqlParameter(DL.Properties.Resources.ScheduleBasedOT, isScheduleBasedOT);
                        objParam[10] = new SqlParameter(DL.Properties.Resources.IncludeZeroHoursSchedule, includeZeroHoursSchedule);
                        objParam[11] = new SqlParameter(DL.Properties.Resources.ScheduledTimeFrom, dt.Rows[i]["ScheduleTimeFrom"]);
                        objParam[12] = new SqlParameter(DL.Properties.Resources.ScheduledTimeTo, dt.Rows[i]["ScheduleTimeTo"]);
                        objParam[13] = new SqlParameter(DL.Properties.Resources.Guid, rowGuid.ToString());
                        objParam[14] = new SqlParameter(DL.Properties.Resources.PreHoursFrom, dt.Rows[i]["PreHoursFrom"]);
                        objParam[15] = new SqlParameter(DL.Properties.Resources.PreHoursTo, dt.Rows[i]["PreHoursTo"]);
                        objParam[16] = new SqlParameter(DL.Properties.Resources.OverTimeBasedOnPeriod, overTimebasedOnperiod);
                        objParam[17] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);

                        ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHeadDistribution_Insert", objParam);
                    }
                }
                //tx.Complete();
           // }

            return ds;
        }
        /// <summary>
        /// Nws the condition hours distribution insert.
        /// </summary>
        /// <param name="weekday">The weekday.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="dt">The dt.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="dutyTypeDataTable">The duty type data table.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet NWConditionHoursDistributionInsert(string weekday, string hoursHeadGroupCode, DataTable dt, string modifiedBy, DataTable dutyTypeDataTable, string guid)
        {
            string hoursHeadCode;
            float intHoursFrom, intHoursTo;
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (dt == null)
            {
                return ds;
            }

           // using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
           // {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hoursHeadCode = dt.Rows[i]["HoursHeadCode"].ToString();
                    intHoursFrom = float.Parse(dt.Rows[i][DL.Properties.Resources.fldTimeFrom].ToString());
                    intHoursTo = float.Parse(dt.Rows[i][DL.Properties.Resources.fldTimeTo].ToString());
                    for (int j = 0; j < dutyTypeDataTable.Rows.Count; j++)
                    {

                        SqlParameter[] objParam = new SqlParameter[8];
                        objParam[0] = new SqlParameter(DL.Properties.Resources.WeekDay, weekday);
                        objParam[1] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeDataTable.Rows[j][0].ToString());
                        objParam[2] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
                        objParam[3] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);

                        objParam[4] = new SqlParameter(DL.Properties.Resources.HoursFrom, intHoursFrom);
                        objParam[5] = new SqlParameter(DL.Properties.Resources.HoursTo, intHoursTo);
                        objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                        objParam[7] = new SqlParameter(DL.Properties.Resources.Guid, guid);

                        ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_NWConditionHoursDistribution_Insert", objParam);
                    }
                }
                //tx.Complete();
            //}

            return ds;
        }
        /// <summary>
        /// Nws the condition hours distribution delete.
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet NWConditionHoursDistributionDelete(string hoursHeadGroupCode, string guid)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Guid, guid);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_NWConditionHoursDistribution_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// Add not working Hours distribution rule
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="dt">The dt.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet NotWorkingHoursHeadDistributionRuleInsert(string businessRuleCode, string hoursHeadGroupCode, DataTable dt, string modifiedBy)
        {

            string hoursHeadCode;
            int intHoursFrom; //, intHoursTo;
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (dt == null)
            {
                return ds;
            }

            //using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
           // {
                string rowGuid = Guid.NewGuid().ToString();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hoursHeadCode = dt.Rows[i]["HoursHeadCode"].ToString();
                    intHoursFrom = int.Parse(dt.Rows[i]["NWHours"].ToString());
                    ////intHoursTo = int.Parse(dt.Rows[i][DL.Properties.Resources.fldTimeTo].ToString());

                    SqlParameter[] objParam = new SqlParameter[6];
                    objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
                    objParam[1] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
                    objParam[2] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);
                    objParam[3] = new SqlParameter(DL.Properties.Resources.HoursFrom, intHoursFrom);
                    ///objParam[4] = new SqlParameter(DL.Properties.Resources.HoursTo, intHoursTo);
                    objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                    objParam[5] = new SqlParameter(DL.Properties.Resources.Guid, rowGuid.ToString());

                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_NWHoursHeadDistribution_Insert", objParam);

                }
               // tx.Complete();
           //}

            return ds;
        }



        /// <summary>
        /// Hourses the head distribution rule delete.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="weekday">The weekday.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="rowGuid">The row unique identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadDistributionRuleDelete(string businessRuleCode, string weekday, string shiftCode, string hoursHeadGroupCode, string rowGuid)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.WeekDay, weekday);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Guid, rowGuid);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHeadDistribution_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Delete Not working hours distribution rule
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="rowGuid">The row unique identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet NotWorkingHoursHeadDistributionRuleDelete(string businessRuleCode, string hoursHeadGroupCode, string rowGuid)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Guid, rowGuid);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_NWHoursHeadDistribution_Delete", objParam);
            return ds;
        }


        #endregion
        #region Function Related to Shift (day/night shift timings)

        /// <summary>
        /// added by  on 1-nov-2011 for inserting rule  shift timings (used for OT hours calculations)
        /// </summary>
        /// <param name="shiftName">Name of the shift.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="minimumMinutes">The minimum minutes.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <param name="startRange">The start range.</param>
        /// <param name="endRange">The end range.</param>
        /// <param name="shiftMode">The shift mode.</param>
        /// <returns>DataSet.</returns>

        public DataSet ShiftInsert(string shiftName, string startTime, string endTime, int minimumMinutes, string modifiedBy, string businessRuleCode, bool isDefault, string startRange, string endRange, string shiftMode)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ShiftName, shiftName);
            objParam[1] = new SqlParameter(DL.Properties.Resources.StartTime, startTime);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EndTime, endTime);
            objParam[3] = new SqlParameter(DL.Properties.Resources.MinimumMinutes, minimumMinutes);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.IsDefault, isDefault);
            objParam[7] = new SqlParameter(DL.Properties.Resources.StartRange, startRange);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EndRange, endRange);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ShiftMode, shiftMode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_Shift_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// added by  on 1-nov-2011 for deleting rule  shift timings (used for OT hours calculations)
        /// </summary>
        /// <param name="shiftName">Name of the shift.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftDelete(string shiftName, string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ShiftName, shiftName);
            objParam[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_Shift_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Shifts the get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftGet(string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_Shift_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Get ShiftMode Code
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftModeGet(string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_ShiftMode_Get", objParam);
            return ds;
        }


        #endregion

        #region function related to paysum format
        /// <summary>
        /// Added new parameter
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumUnmappedHoursHeadGet(string companyCode,string paySumCode)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumUnMappedHoursHead_Get", objParm);
            return ds;

        }
        /// <summary>
        /// Added New Parameter PaySumCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="paySumcode">The pay sumcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumMappedHoursHeadGet(string companyCode, string paysumHead,string paySumcode)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumcode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumMappedHoursHead_Get", objParm);
            return ds;

        }
        /// <summary>
        /// Paysums the head mapped list HRS total delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadMappedListHrsTotalDelete(string companyCode, string paysumHead, string hoursHeadCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaysumHeadMappedListHrsTotalDelete", objParm);
            return ds;
        }
        /// <summary>
        /// Paysums the head delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadDelete(string companyCode, string paysumHead)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaysumHeadsDelete", objParm);
            return ds;
        }
        /// <summary>
        /// Paysums the head mapped list HRS total get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paySumcode">The pay sumcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadMappedListHrsTotalGet(string companyCode, string paySumcode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumcode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaysumHeadMappedListHrsTotalGet", objParm);
            return ds;
        }
        /// <summary>
        /// Paysums the head mapping add.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="hoursHeads">The hours heads.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="ispaysumheadTotal">if set to <c>true</c> [ispaysumhead total].</param>
        /// <param name="paySumcode">The pay sumcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadMappingAdd(string companyCode, string paysumHead, string hoursHeads, string modifiedBy, bool ispaysumheadTotal, string paySumcode)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HoursHeadCodes, hoursHeads);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsPaysumHeadTotal, ispaysumheadTotal);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumcode);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumHeadMapping_Add", objParm);
            return ds;

        }

        /// <summary>
        /// Paysums the head mapping remove.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="hoursHeads">The hours heads.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadMappingRemove(string companyCode, string paysumHead, string hoursHeads, string modifiedBy, string paySumCode)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HoursHeadCodes, hoursHeads);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumHeadMapping_Remove", objParm);
            return ds;

        }

        /// <summary>
        /// Added by  on 24 oct 2011 for getting paysum Heads (functionality: define paysum format)
        /// Filter on new parameter  23-jan-2014
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadsGet(string companyCode, string paySumCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumHead_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Added by  on 24 oct 2011 for inserting paysum Heads (functionality: define paysum format)
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        /// Added new parameter  paySumCode
        public DataSet PaysumHeadsInsert(string companyCode, string paysumHead, string modifiedBy, string paySumCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumHead_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// Paysums the heads insert total.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadsInsertTotal(string companyCode, string paysumHead, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumHead_InsertTot", objParm);
            return ds;
        }
        /// <summary>
        /// Added New Parameter PaysumCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadsUpdate(string companyCode, string paysumHead, string modifiedBy, string paySumCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumHead_Update", objParm);
            return ds;
        }


        /// <summary>
        /// Added by  on 24 oct 2011 for deleting paysum Heads (functionality: define paysum format)
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadsDelete(string companyCode, string paysumHead, string paySumCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PaysumHead, paysumHead);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumHead_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// Added by  on 20 Nov 2012 for adding paysum elements (functionality: define paysum format)
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="paysumElement">The paysum element.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        /// Added New Parameter PaysumCode
        public DataSet PaysumElementsAdd(string companyCode, string businessRuleCode, string paysumElement, string modifiedBy, string paySumCode)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PaysumElement, paysumElement);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumElement_Add", objParm);
            return ds;
        }
        /// <summary>
        /// Added by  on 20 Nov 2012 for deleting paysum elements (functionality: define paysum format)
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="paysumElement">The paysum element.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumElementsDelete(string companyCode, string businessRuleCode, string paysumElement, string paySumCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PaysumElement, paysumElement);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumElement_Delete", objParm);
            return ds;
        }
        /// <summary>
        /// Added by  on 20 Nov 2012 to get paysum elements (functionality: define paysum format)
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumElementsGet(string companyCode, string businessRuleCode, string paySumCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PaySumCode, paySumCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_PaysumElement_Get", objParm);
            return ds;
        }
        #endregion

        #region function related to client weekly holiday timings

        /// <summary>
        /// Clients the default weekly holiday time save.
        /// </summary>
        /// <param name="dayFrom">The day from.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="dayTo">The day to.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDefaultWeeklyHolidayTimeSave(string dayFrom, string timeFrom, string dayTo, string timeTo, string modifiedBy, string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DayFrom, dayFrom);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DayTo, dayTo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_ClientDefaultWHTime_Save", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the default weekly holiday time update.
        /// </summary>
        /// <param name="weeklyOffId">The weekly off identifier.</param>
        /// <param name="dayFrom">The day from.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="dayTo">The day to.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDefaultWeeklyHolidayTimeUpdate(int weeklyOffId, string dayFrom, string timeFrom, string dayTo, string timeTo, string modifiedBy, string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WeeklyOffId, weeklyOffId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DayFrom, dayFrom);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DayTo, dayTo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_ClientDefaultWHTime_Update", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the default weekly holiday time delete.
        /// </summary>
        /// <param name="weeklyOffId">The weekly off identifier.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDefaultWeeklyHolidayTimeDelete(int weeklyOffId, string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WeeklyOffId, weeklyOffId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_ClientDefaultWHTime_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the weekly holiday time save.
        /// </summary>
        /// <param name="clientWeeklyOffId">The client weekly off identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="dayFrom">The day from.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="dayTo">The day to.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientWeeklyHolidayTimeSave(int clientWeeklyOffId, string clientCode, string dayFrom, string timeFrom, string dayTo, string timeTo, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WeeklyOffId, clientWeeklyOffId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DayFrom, dayFrom);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[4] = new SqlParameter(DL.Properties.Resources.DayTo, dayTo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_ClientWHTime_Save", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the weekly holiday time get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientWeeklyHolidayTimeGet(string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_ClientDefaultWHTime_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the weekly holiday time get all.
        /// </summary>
        /// <param name="weeklyOffId">The weekly off identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientWeeklyHolidayTimeGetAll(int weeklyOffId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WeeklyOffId, weeklyOffId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_ClientWHTime_GetAll", objParam);
            return ds;
        }

        #endregion

        #region function related to client holiday
        /// <summary>
        /// Added by  on 18-oct-2011 for client wise holiday
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDate">The holiday date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientHolidayGetAll(int locationAutoId, string holidayCode, string holidayDate)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HolidayCode, holidayCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HolidayDate, DL.Common.DateFormat(holidayDate));
            DataSet ds = SqlHelper.ExecuteDataset("udpBR_ClientHoliday_GetAll", objParm);
            return ds;
        }
        /// <summary>
        /// Added by  on 1-Nov-2011 for saving client wise holiday
        /// </summary>
        /// <param name="holidayAutoId">The holiday automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDate">The holiday date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>

        public DataSet ClientHolidaySave(int holidayAutoId, string holidayCode, string holidayDate, string clientCode, string fromDate, string toDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AutoId, holidayAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HolidayCode, holidayCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HolidayDate, DL.Common.DateFormat(holidayDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset("udpBR_ClientHoliday_Save", objParm);
            return ds;
        }


        /// <summary>
        /// Holidays the default times insert.
        /// </summary>
        /// <param name="isDateBasedHoliday">if set to <c>true</c> [is date based holiday].</param>
        /// <param name="timeBasedHoliday">if set to <c>true</c> [time based holiday].</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayDefaultTimesInsert(bool isDateBasedHoliday, bool timeBasedHoliday, string fromDate, string toDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.dateBasedHoliday, isDateBasedHoliday);
            objParm[1] = new SqlParameter(DL.Properties.Resources.timeBasedHoliday, timeBasedHoliday);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset("udpBR_HolidayDefaultTimes_Insert", objParm);
            return ds;
        }



        #endregion

        #region Function related to HoursHeadCode
        /// <summary>
        /// Hourses the head group get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadGroupGet()
        {

            SqlParameter[] objParm = new SqlParameter[0];

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHeadGroup_Get", objParm);
            return ds;

        }

        /// <summary>
        /// Hourses the head group insert.
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="hoursHeadGroupDesc">The hours head group desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadGroupInsert(string hoursHeadGroupCode, string hoursHeadGroupDesc, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupDesc, hoursHeadGroupDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHeadGroup_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// Hourses the head group delete.
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadGroupDelete(string hoursHeadGroupCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHeadGroup_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// Hourses the head group update.
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="hoursHeadGroupDesc">The hours head group desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadGroupUpdate(string hoursHeadGroupCode, string hoursHeadGroupDesc, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupDesc, hoursHeadGroupDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHeadGroup_Update", objParm);
            return ds;
        }

        /// <summary>
        /// Businesses the hours head get.
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessHoursHeadGet(string hoursHeadGroupCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHead_Get", objParm);
            return ds;

        }
        /// <summary>
        /// Added New parameter bool replacePostElement
        /// </summary>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <param name="hoursHeadDesc">The hours head desc.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="isOverTime">if set to <c>true</c> [is over time].</param>
        /// <param name="equivalentPercentage">The equivalent percentage.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="replacePostElement">if set to <c>true</c> [replace post element].</param>
        /// <param name="isPlannedOT">if set to <c>true</c> [is planned ot].</param>
        /// <param name="InvHrsCategory">The inv HRS category.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadInsert(string hoursHeadCode, string hoursHeadDesc, string hoursHeadGroupCode, bool isOverTime, int equivalentPercentage, string modifiedBy, bool replacePostElement, bool isPlannedOT, string InvHrsCategory)
        {
            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HoursHeadDesc, hoursHeadDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.IsOTType, isOverTime);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EquivalentPercentage, equivalentPercentage);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ReplacePostElement, replacePostElement);
            objParm[7] = new SqlParameter(DL.Properties.Resources.IsPlannedOT, isPlannedOT);
            objParm[8] = new SqlParameter(DL.Properties.Resources.InvHrsCategory, InvHrsCategory);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHead_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// Hourses the head delete.
        /// </summary>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadDelete(string hoursHeadCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHead_Delete", objParm);
            return ds;
        }
        /// <summary>
        /// Added New Parameter bool replacePostElement
        /// </summary>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <param name="hoursHeadDesc">The hours head desc.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="IsOverTime">if set to <c>true</c> [is over time].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="replacePostElement">if set to <c>true</c> [replace post element].</param>
        /// <param name="isPlannedOT">if set to <c>true</c> [is planned ot].</param>
        /// <param name="InvHrsCategory">The inv HRS category.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadUpdate(string hoursHeadCode, string hoursHeadDesc, string hoursHeadGroupCode, bool IsOverTime, string modifiedBy, bool replacePostElement, bool isPlannedOT, string InvHrsCategory)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HoursHeadDesc, hoursHeadDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HoursHeadGroupCode, hoursHeadGroupCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.IsOTType, IsOverTime);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ReplacePostElement, replacePostElement);
            objParm[6] = new SqlParameter(DL.Properties.Resources.IsPlannedOT, isPlannedOT);
            objParm[7] = new SqlParameter(DL.Properties.Resources.InvHrsCategory, InvHrsCategory);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursHead_Update", objParm);
            return ds;
        }

        #endregion

        #region functions relted to formula builder
        /// <summary>
        /// added by  on 09-nov-2011 for inserting formula expression
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="formulaName">Name of the formula.</param>
        /// <param name="formulaExpressionType">Type of the formula expression.</param>
        /// <param name="formulaExpression">The formula expression.</param>
        /// <param name="isPartOfPaysum">The is part of paysum.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet FormulaExpressionInsert(string businessRuleCode, string formulaName, string formulaExpressionType, string formulaExpression, string isPartOfPaysum, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FormulaName, formulaName);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FormulaExpressionType, formulaExpressionType);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FormulaExpression, formulaExpression);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsPartOfPaysum, isPartOfPaysum);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_FormulaExpression_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// Formulas the expression delete.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="formulaName">Name of the formula.</param>
        /// <returns>DataSet.</returns>
        public DataSet FormulaExpressionDelete(string businessRuleCode, string formulaName)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FormulaName, formulaName);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_FormulaExpression_Delete", objParm);
            return ds;
        }


        /// <summary>
        /// added by  on 11-nov-2011 for getting list of formulas
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet FormulaNameGet(string businessRuleCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_Formula_Get", objParm);
            return ds;
        }

        #endregion
        #region functions relted to Cyprus Payroll text
        /// <summary>
        /// Payrolls the text.
        /// </summary>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="businessrulecode">The businessrulecode.</param>
        /// <returns>DataTable.</returns>

        public DataTable PayrollText(DateTime FromDate, DateTime ToDate, string businessrulecode)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, FromDate);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, ToDate);
            objParm[2] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessrulecode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CyprusPaysumTextOutput", objParm);
            DataTable firstTable = ds.Tables[0];
            return firstTable;
        }
        #endregion

        #endregion

        #region function related to Rota Authorization
        /// <summary>
        /// Rotas the authorization get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaAuthorizationGet(string businessRuleCode, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_RotaAuthorization_Get", objParam);
            return ds;
        }

        #endregion

        #region function related to paysum readyness

        /// <summary>
        /// paysum readyness processes Get
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>data set of paysum readyness processes</returns>
        public DataSet PaysumReadynessProcessesGet(string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_PaysumReadynessProcesses_Get", objParam);
            return ds;
        }

        /// <summary>
        /// execute process
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="commandName">Name of the command.</param>
        /// <returns>dataset as result of process</returns>
        public DataSet PaysumReadynessProcessesExecute(string companyCode, string businessRuleCode, string fromDate, string toDate, string commandName)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, commandName, objParam);
            return ds;
        }
        /// <summary>
        /// Business Rule Mapping with Paysum Readiness Parameters Get
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumReadinessProcessGet(string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaysumReadinessProcessGet", objParam);
            return ds;
        }
        /// <summary>
        /// Business Rule Mapping with Paysum Readiness Parameters Get
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumReadinessProcessParameterGet(string pid)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.pid, pid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaysumReadinessProcessParameterGet", objParam);
            return ds;
        }
        /// <summary>
        /// Insert in Paysum Readiness
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="pid">The pid.</param>
        /// <param name="isSubscribed">if set to <c>true</c> [is subscribed].</param>
        /// <param name="implementationStatus">The implementation status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumReadinessInsert(string businessRuleCode, string pid, bool isSubscribed, int implementationStatus, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.pid, pid);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IsSubscribed, isSubscribed);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ImplementationStatus, implementationStatus);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaysumReadinessInsert", objParam);
            return ds;
        }
        /// <summary>
        /// Update Paysum Readiness Parameter Value
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="inputParameter">The input parameter.</param>
        /// <param name="inputParameterValue">The input parameter value.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumReadinessParameterValueUpdate(string pid, string inputParameter, string inputParameterValue, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.pid, pid);
            objParam[1] = new SqlParameter(DL.Properties.Resources.InputParameter, inputParameter);
            objParam[2] = new SqlParameter(DL.Properties.Resources.InputParameterValue, inputParameterValue);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaysumReadinessParameterValueUpdate", objParam);
            return ds;
        }
        #endregion



        /// <summary>
        /// Get WeeklyOff Code
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet WeeklyOffGet(string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_WeeklyOffDependecy_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To update WeekOffDependency column value in mstBrBusinessRule Table
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="weekOffDependencyVal">The week off dependency value.</param>
        /// <returns>DataSet.</returns>
        public DataSet WeekOffDependencyUpdate(string businessRuleCode, string weekOffDependencyVal)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.WeekOffDependency, weekOffDependencyVal);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_WeekOffDependency_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Gets the shift for duty hours.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetShiftForDutyHours(string businessRuleCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_ShiftForDutyHours_Get", objParam);
            return ds;
        }
        
        #region  Function Related HoursDistribution Adjustment
        /// <summary>
        /// Businesses the hours distribution adjusment get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessHoursDistributionAdjusmentGet(string businessRuleCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_BrHoursDistributionAdjGet", objParm);
            return ds;

        }
        /// <summary>
        /// Insert New Value For BusinessHoursDistributionAdjusment
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="period">The period.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <param name="hoursHeadValue">The hours head value.</param>
        /// <param name="fromHoursHead">From hours head.</param>
        /// <param name="toHoursHead">To hours head.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessHoursDistributionAdjusmentInsert(string businessRuleCode, string period, string mode, string hoursHeadCode, int hoursHeadValue, string fromHoursHead, string toHoursHead, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Period, period);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Mode, mode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.HoursHeadValue, hoursHeadValue);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromHoursHead, fromHoursHead);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToHoursHead, toHoursHead);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursDistributionAdj_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// Delete the value From MstBrHoursDistributionAdj table
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <param name="fromHoursHead">From hours head.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessHoursDistributionAdjusmentDelete(string businessRuleCode, string hoursHeadCode, string fromHoursHead)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HoursHeadCode, hoursHeadCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromHoursHead, fromHoursHead);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBR_HoursDistributionAdj_Delete", objParm);  
            return ds;
        }
       

        #endregion

    }
}