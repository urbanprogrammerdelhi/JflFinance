// ***********************************************************************
// Assembly         : BL
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

/// <summary>
/// The BL namespace.
/// </summary>
[assembly: CLSCompliantAttribute(false)]
namespace BL
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
            DL.BusinessRule objPayRate = new DL.BusinessRule();
            DataSet ds = objPayRate.SystemParameterGet(companyCode, hrLocationCode, locationCode);
            return ds;
        }

        #region Function related to Generic business rules

        #region Function Related to rule creation

        /// <summary>
        /// Businesses the rule get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleGet(string businessRuleCode, int locationAutoId)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.BusinessRuleGet(businessRuleCode, locationAutoId);
            return ds;
        }
        /// <summary>
        /// For insert new business records.
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
        /// Modified By : added new column value designation and paySumCode,  PaySumDesc
        public DataSet BusinessRuleAddNew(string businessRuleCode, string businessRuleDesc, string companyCode, string hrLocationCode, string locationCode, string clientCode, string contractDays, string categoryCode, string effectiveFrom, string effectiveTo, bool isDefaultRule, string modifiedBy, int locationAutoId, string jobClass, string jobType, string designation, string paySumCode, string PaySumDesc, bool considerBreakHrs, bool considerUnconfirmedDuty)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.BusinessRuleAddNew(businessRuleCode, businessRuleDesc, companyCode, hrLocationCode, locationCode, clientCode, contractDays, categoryCode, effectiveFrom, effectiveTo, isDefaultRule, modifiedBy, locationAutoId, jobClass, jobType, designation, paySumCode, PaySumDesc, considerBreakHrs, considerUnconfirmedDuty);
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
        public DataSet BusinessRuleUpdate(string businessRuleCode, string businessRuleDesc, string companyCode, string hrLocationCode, string locationCode, string clientCode, string contractDays, string categoryCode, string effectiveFrom, string effectiveTo, bool isDefaultRule, string modifiedBy, string jobClass, string jobType, string designation, bool considerBreakHrs, bool considerUnconfirmedDuty)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.BusinessRuleUpdate(businessRuleCode, businessRuleDesc, companyCode, hrLocationCode, locationCode, clientCode, contractDays, categoryCode, effectiveFrom, effectiveTo, isDefaultRule, modifiedBy, jobClass, jobType, designation,considerBreakHrs,  considerUnconfirmedDuty);
            return ds;
        }
        /// <summary>
        /// To Delete Business Rule
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleDelete(string businessRuleCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.BusinessRuleDelete(businessRuleCode);
            return ds;
        }
        #endregion
        #region Function related to payperiod
        /// <summary>
        /// Business Rule Is Repalced By PaySumCode
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodGet(string paySumCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.PayPeriodGet(paySumCode);
            return ds;
        }
        /// <summary>
        /// Business Rule Is Repalced By PaySumCode
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
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.PayPeriodInsert(paySumCode, payPeriodType, monthStartDay, monthEndDay, firstFortnightStartDay, firstFortnightEndDay, secondFortnightStartDay, secondFortnightEndDay, weekFirstDay, weekLastDay, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Business Rule Is Repalced By PaySumCode
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodDelete(string paySumCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.PayPeriodDelete(paySumCode);
            return ds;
        }


        /// <summary>
        /// Pays the period collection get.
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodCollectionGet(string paySumCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.PayPeriodCollectionGet(paySumCode);
            return ds;
        }

        /// <summary>
        /// Pays the period collection insert.
        /// </summary>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PayPeriodCollectionInsert(string paySumCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.PayPeriodCollectionInsert(paySumCode);
            return ds;
        }

        #endregion
        #region function related to Hours distribution
        /// <summary>
        /// Function to fetch data
        /// </summary>
        /// <param name="weekday">The weekday.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="overTimebasedOnperiod">The over timebased onperiod.</param>
        /// <returns>DataSet.</returns>
        /// Modify: Added new parameter to fetch the records  16-jan-2014
        public DataSet HoursHeadDistributionRuleGet(string weekday, string shiftCode, string hoursHeadGroupCode, string businessRuleCode, string overTimebasedOnperiod)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.HoursHeadDistributionRuleGet(weekday, shiftCode, hoursHeadGroupCode, businessRuleCode, overTimebasedOnperiod);
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
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.NWConditionHoursDistribution_Get(hoursHeadGroupCode, guid);
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
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.NotWorkingHoursHeadDistributionRuleGet(hoursHeadGroupCode, businessRuleCode);
            return ds;
        }


        /// <summary>
        /// Add Hours distribution rule
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="weekday">The weekday.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="dutyTypeDatatable">The duty type datatable.</param>
        /// <param name="isScheduleBasedOt">The is schedule based ot.</param>
        /// <param name="includeZeroHoursSchedule">if set to <c>true</c> [include zero hours schedule].</param>
        /// <param name="overTimebasedOnperiod">The over timebased onperiod.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadDistributionRuleInsert(string businessRuleCode, string weekday, string shiftCode, string hoursHeadGroupCode, DataTable dataTable, string modifiedBy, DataTable dutyTypeDatatable, int isScheduleBasedOt, bool includeZeroHoursSchedule, string overTimebasedOnperiod,string leaveCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.HoursHeadDistributionRuleInsert(businessRuleCode, weekday, shiftCode, hoursHeadGroupCode, dataTable, modifiedBy, dutyTypeDatatable, isScheduleBasedOt, includeZeroHoursSchedule,overTimebasedOnperiod, leaveCode);
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
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.NWConditionHoursDistributionInsert(weekday, hoursHeadGroupCode, dt, modifiedBy, dutyTypeDataTable, guid);
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
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.NWConditionHoursDistributionDelete(hoursHeadGroupCode, guid);
            return ds;
        }
        /// <summary>
        /// Add Not Working Hours distribution rule
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet NotWorkingHoursHeadDistributionRuleInsert(string businessRuleCode, string hoursHeadGroupCode, DataTable dataTable, string modifiedBy)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.NotWorkingHoursHeadDistributionRuleInsert(businessRuleCode, hoursHeadGroupCode, dataTable, modifiedBy);
            return ds;
        }


        /// <summary>
        /// Delete Hours distribution rule
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="weekday">The weekday.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="rowGuid">The row unique identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadDistributionRuleDelete(string businessRuleCode, string weekday, string shiftCode, string hoursHeadGroupCode, string rowGuid)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.HoursHeadDistributionRuleDelete(businessRuleCode, weekday, shiftCode, hoursHeadGroupCode, rowGuid);
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
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.NotWorkingHoursHeadDistributionRuleDelete(businessRuleCode, hoursHeadGroupCode, rowGuid);
            return ds;
        }

        #endregion
        #region Function Related to Shift (day/night shift timings)

        /// <summary>
        /// Shifts the insert.
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

        public DataSet ShiftInsert(string shiftName, string startTime, string endTime, int minimumMinutes, string modifiedBy, string businessRuleCode,bool isDefault,string startRange,string endRange,string shiftMode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.ShiftInsert(shiftName, startTime, endTime, minimumMinutes, modifiedBy, businessRuleCode, isDefault, startRange, endRange, shiftMode);
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
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.ShiftDelete(shiftName, businessRuleCode);
            return ds;
        }

        /// <summary>
        /// Shifts the get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftGet(string businessRuleCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.ShiftGet(businessRuleCode);
            return ds;
        }

        /// <summary>
        /// Get Mode records  10-Jan2013
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftModeGet(string businessRuleCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.ShiftModeGet(businessRuleCode);
            return ds;
        }



        #endregion
        #region function related to paysum format
        /// <summary>
        /// Added New Parameter paySumCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumUnmappedHoursHeadGet(string companyCode,string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumUnmappedHoursHeadGet(companyCode,paySumCode);
            return ds;
        }
        /// <summary>
        /// Added New Parameter paySumCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumMappedHoursHeadGet(string companyCode, string paysumHead,string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumMappedHoursHeadGet(companyCode, paysumHead, paySumCode);
            return ds;
        }
        /// <summary>
        /// Paysums the head mapped list HRS total delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="hoursheadCode">The hourshead code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadMappedListHrsTotalDelete(string companyCode, string paysumHead, string hoursheadCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadMappedListHrsTotalDelete(companyCode, paysumHead, hoursheadCode);
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadDelete(companyCode, paysumHead);
            return ds;
        }
        /// <summary>
        /// Added New parameter paySumcode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paySumcode">The pay sumcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadMappedListHrsTotalGet(string companyCode,string paySumcode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadMappedListHrsTotalGet(companyCode, paySumcode);
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadMappingAdd(companyCode, paysumHead, hoursHeads, modifiedBy, ispaysumheadTotal, paySumcode);
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
        public DataSet PaysumHeadMappingRemove(string companyCode, string paysumHead, string hoursHeads, string modifiedBy ,string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadMappingRemove(companyCode, paysumHead, hoursHeads, modifiedBy, paySumCode);
            return ds;
        }

        /// <summary>
        /// Added by  on 24 oct 2011 for getting paysum format (functionality: define paysum format)
        /// Added New paramter for filter records
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadsGet(string companyCode,string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadsGet(companyCode, paySumCode);
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
        /// Added new parameter paySumCode
        public DataSet PaysumHeadsInsert(string companyCode, string paysumHead, string modifiedBy, string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadsInsert(companyCode, paysumHead, modifiedBy, paySumCode);
            return ds;
        }
        /// <summary>
        /// added new parameter string paySumCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadsInsertTotal(string companyCode, string paysumHead, string modifiedBy, string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadsInsert(companyCode, paysumHead, modifiedBy, paySumCode);
            return ds;
        }
        /// <summary>
        /// Added New Parameter string paySumCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="paysumHead">The paysum head.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumHeadsUpdate(string companyCode, string paysumHead, string modifiedBy, string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadsUpdate(companyCode, paysumHead, modifiedBy, paySumCode);
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumHeadsDelete(companyCode, paysumHead, paySumCode);
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
        /// Added new parametre paySumCode
        public DataSet PaysumElementsAdd(string companyCode, string businessRuleCode, string paysumElement, string modifiedBy, string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumElementsAdd(companyCode, businessRuleCode, paysumElement, modifiedBy, paySumCode);
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
        /// Added new parametre paySumCode
        public DataSet PaysumElementsDelete(string companyCode, string businessRuleCode, string paysumElement, string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumElementsDelete(companyCode, businessRuleCode, paysumElement, paySumCode);
            return ds;
        }
        /// <summary>
        /// Added by  on 20 Nov 2012 to get paysum elements (functionality: define paysum format)
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="paySumCode">The pay sum code.</param>
        /// <returns>DataSet.</returns>
        /// Added new parametre paySumCode
        public DataSet PaysumElementsGet(string companyCode, string businessRuleCode, string paySumCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.PaysumElementsGet(companyCode, businessRuleCode, paySumCode);
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet dsWHTime = objdlBR.ClientDefaultWeeklyHolidayTimeSave(dayFrom, timeFrom, dayTo, timeTo, modifiedBy, businessRuleCode);
            return dsWHTime;
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet dsWHTime = objdlBR.ClientDefaultWeeklyHolidayTimeUpdate(weeklyOffId, dayFrom, timeFrom, dayTo, timeTo, modifiedBy, businessRuleCode);
            return dsWHTime;
        }

        /// <summary>
        /// Clients the default weekly holiday time delete.
        /// </summary>
        /// <param name="weeklyOffId">The weekly off identifier.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDefaultWeeklyHolidayTimeDelete(int weeklyOffId, string businessRuleCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet dsWHTime = objdlBR.ClientDefaultWeeklyHolidayTimeDelete(weeklyOffId, businessRuleCode);
            return dsWHTime;
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet dsWHTime = objdlBR.ClientWeeklyHolidayTimeSave(clientWeeklyOffId, clientCode, dayFrom, timeFrom, dayTo, timeTo, modifiedBy);
            return dsWHTime;
        }

        /// <summary>
        /// Clients the weekly holiday time get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientWeeklyHolidayTimeGet(string businessRuleCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet dsWHTime = objdlBR.ClientWeeklyHolidayTimeGet(businessRuleCode);
            return dsWHTime;
        }

        /// <summary>
        /// Clients the weekly holiday time get all.
        /// </summary>
        /// <param name="weeklyOffId">The weekly off identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientWeeklyHolidayTimeGetAll(int weeklyOffId)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet dsWHTime = objdlBR.ClientWeeklyHolidayTimeGetAll(weeklyOffId);
            return dsWHTime;
        }
        #endregion

        #region function related to client holiday

        /// <summary>
        /// Added by  on 18-oct-2011 for client wise holiday
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDate">The holiday date.</param>
        /// <returns>data set (client holiday details)</returns>
        public DataSet ClientHolidayGetAll(int locationAutoId, string holidayCode, string holidayDate)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.ClientHolidayGetAll(locationAutoId, holidayCode, holidayDate);
            return ds;
        }
        /// <summary>
        /// Clients the holiday save.
        /// </summary>
        /// <param name="autoId">The automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDate">The holiday date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>

        public DataSet ClientHolidaySave(int autoId, string holidayCode, string holidayDate, string clientCode, string fromDate, string toDate, string modifiedBy)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.ClientHolidaySave(autoId, holidayCode, holidayDate, clientCode, fromDate, toDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Holidays the default times insert.
        /// </summary>
        /// <param name="dateBasedHoliday">if set to <c>true</c> [date based holiday].</param>
        /// <param name="timeBasedHoliday">if set to <c>true</c> [time based holiday].</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayDefaultTimesInsert(bool dateBasedHoliday, bool timeBasedHoliday, string fromDate, string toDate, string modifiedBy)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.HolidayDefaultTimesInsert(dateBasedHoliday, timeBasedHoliday, fromDate, toDate, modifiedBy);
            return ds;
        }

        #endregion

        #region Function related to HrsHeadCode
        /// <summary>
        /// Hourses the head group get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadGroupGet()
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.HoursHeadGroupGet();
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.HoursHeadGroupInsert(hoursHeadGroupCode, hoursHeadGroupDesc, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Hourses the head group delete.
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadGroupDelete(string hoursHeadGroupCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.HoursHeadGroupDelete(hoursHeadGroupCode);
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.HoursHeadGroupUpdate(hoursHeadGroupCode, hoursHeadGroupDesc, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Businesses the hours head get.
        /// </summary>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessHoursHeadGet(string hoursHeadGroupCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.BusinessHoursHeadGet(hoursHeadGroupCode);
            return ds;
        }

        /// <summary>
        /// Added New Parameter
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.HoursHeadInsert(hoursHeadCode, hoursHeadDesc, hoursHeadGroupCode, isOverTime, equivalentPercentage, modifiedBy, replacePostElement, isPlannedOT, InvHrsCategory);
            return ds;
        }

        /// <summary>
        /// Hourses the head delete.
        /// </summary>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadDelete(string hoursHeadCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.HoursHeadDelete(hoursHeadCode);
            return ds;
        }
        /// <summary>
        /// Added New Paramter chkgvEditreplacePostelement
        /// </summary>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <param name="hoursHeadDesc">The hours head desc.</param>
        /// <param name="hoursHeadGroupCode">The hours head group code.</param>
        /// <param name="IsOverTime">if set to <c>true</c> [is over time].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="chkgvEditreplacePostelement">if set to <c>true</c> [CHKGV editreplace postelement].</param>
        /// <param name="isPlannedOT">if set to <c>true</c> [is planned ot].</param>
        /// <param name="InvHrsCategory">The inv HRS category.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursHeadUpdate(string hoursHeadCode, string hoursHeadDesc, string hoursHeadGroupCode, bool IsOverTime, string modifiedBy, bool chkgvEditreplacePostelement,bool isPlannedOT ,string InvHrsCategory)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.HoursHeadUpdate(hoursHeadCode, hoursHeadDesc, hoursHeadGroupCode, IsOverTime, modifiedBy, chkgvEditreplacePostelement, isPlannedOT, InvHrsCategory);
            return ds;
        }

        #endregion

        #region functions relted to formula builder
        /// <summary>
        /// added by  on 09-nov-2011 for inserting formula expression
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="formulaName">Name of the formula.</param>
        /// <param name="formulaExpType">Type of the formula exp.</param>
        /// <param name="formulaExp">The formula exp.</param>
        /// <param name="isPartOfPaysum">The is part of paysum.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet FormulaExpressionInsert(string businessRuleCode, string formulaName, string formulaExpType, string formulaExp, string isPartOfPaysum, string modifiedBy)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.FormulaExpressionInsert(businessRuleCode, formulaName, formulaExpType, formulaExp, isPartOfPaysum, modifiedBy);
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
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.FormulaExpressionDelete(businessRuleCode, formulaName);
            return ds;
        }


        /// <summary>
        /// added by  on 11-nov-2011 for getting list of formulas
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet FormulaNameGet(string businessRuleCode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.FormulaNameGet(businessRuleCode);
            return ds;
        }

        #endregion

        #region functions relted cyprus payroll
        /// <summary>
        /// added by  on 15-01-2014 for inserting formula expression
        /// </summary>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="businessrulecode">The businessrulecode.</param>
        /// <returns>DataTable.</returns>
        /// &gt;
        public DataTable PayrollText(DateTime FromDate,DateTime ToDate,string businessrulecode)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataTable dt = objdlBR.PayrollText(FromDate,ToDate,businessrulecode);
            return dt;
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
            DL.BusinessRule obj = new DL.BusinessRule();
            DataSet ds = obj.RotaAuthorizationGet(businessRuleCode, locationAutoId);
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
            DL.BusinessRule obj = new DL.BusinessRule();
            DataSet ds = obj.PaysumReadynessProcessesGet(businessRuleCode);
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
            DL.BusinessRule obj = new DL.BusinessRule();
            DataSet ds = obj.PaysumReadynessProcessesExecute(companyCode, businessRuleCode, fromDate, toDate, commandName);
            return ds;
        }
        /// <summary>
        /// Business Rule Mapping with Paysum Readiness Get
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumReadinessProcessGet(string businessRuleCode)
        {
            DL.BusinessRule obj = new DL.BusinessRule();
            DataSet ds = obj.PaysumReadinessProcessGet(businessRuleCode);
            return ds;
        }
        /// <summary>
        /// Business Rule Mapping with Paysum Readiness Parameters Get
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>DataSet.</returns>
        public DataSet PaysumReadinessProcessParameterGet(string pid)
        {
            DL.BusinessRule obj = new DL.BusinessRule();
            DataSet ds = obj.PaysumReadinessProcessParameterGet(pid);
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
            DL.BusinessRule obj = new DL.BusinessRule();
            DataSet ds = obj.PaysumReadinessInsert(businessRuleCode, pid, isSubscribed, implementationStatus, modifiedBy);
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
            DL.BusinessRule obj = new DL.BusinessRule();
            DataSet ds = obj.PaysumReadinessParameterValueUpdate(pid, inputParameter, inputParameterValue, modifiedBy);
            return ds;
        }
        #endregion

        /// <summary>
        /// Get Weekly records  16-Jan2013
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet WeeklyOffGet(string businessRuleCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.WeeklyOffGet(businessRuleCode);
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
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.WeekOffDependencyUpdate(businessRuleCode, weekOffDependencyVal);
            return ds;
        }
        /// <summary>
        /// Get Shift value from mstBRShift table to .
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        /// 22/jan/2014
        public DataSet GetShiftForDutyHours(string businessRuleCode)
        {
            DL.BusinessRule objBr = new DL.BusinessRule();
            DataSet ds = objBr.GetShiftForDutyHours(businessRuleCode);
            return ds;
        
        }              

        #region  Function Related HoursDistribution Adjustment

        /// <summary>
        /// Get Business HoursDistribution Adjusment
        /// </summary>
        /// <param name="businessRule">The business rule.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessHoursDistributionAdjusmentGet(string businessRule)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.BusinessHoursDistributionAdjusmentGet(businessRule);
            return ds;
        }
        /// <summary>
        /// Insert Business HoursDistribution Adjusment
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
        public DataSet BusinessHoursDistributionAdjusmentInsert(string businessRuleCode, string period, string mode, string hoursHeadCode, int hoursHeadValue, string fromHoursHead, string toHoursHead,string  modifiedBy)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.BusinessHoursDistributionAdjusmentInsert(businessRuleCode, period, mode, hoursHeadCode, hoursHeadValue, fromHoursHead, toHoursHead, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Delete Business HoursDistribution Adjusment
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="hoursHeadCode">The hours head code.</param>
        /// <param name="fromHoursHead">From hours head.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessHoursDistributionAdjusmentDelete(string businessRuleCode, string hoursHeadCode, string fromHoursHead)
        {
            DL.BusinessRule objdlBR = new DL.BusinessRule();
            DataSet ds = objdlBR.BusinessHoursDistributionAdjusmentDelete(businessRuleCode, hoursHeadCode, fromHoursHead);
            return ds;
        }
     

        #endregion 

    }
}