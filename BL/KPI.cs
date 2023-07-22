// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="KPI.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data;
using System.Globalization;


/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{

    /// <summary>
    /// Class KPI.
    /// </summary>
    public class KPI
    {
        /// <summary>
        /// Get all KPI code to show in grid
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetKpiCode(string CompanyCode)
        {
            DL.KPI objKPI = new DL.KPI();

            DataSet ds = objKPI.GetKpiCode(CompanyCode);
            return ds;
        }

        /// <summary>
        /// Add new KPI code
        /// </summary>
        /// <param name="KPIHeadCode">The kpi head code.</param>
        /// <param name="KPIHeadDesc">The kpi head desc.</param>
        /// <param name="TargetValue">The target value.</param>
        /// <param name="RedFrom">The red from.</param>
        /// <param name="RedTo">The red to.</param>
        /// <param name="AmberFrom">The amber from.</param>
        /// <param name="AmberTo">The amber to.</param>
        /// <param name="GreenFrom">The green from.</param>
        /// <param name="GreenTo">The green to.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <param name="ModifiedDate">The modified date.</param>
        /// <param name="isChecked">The is checked.</param>
        /// <param name="isGroupTarget">The is group target.</param>
        /// <param name="redFromMin">The red from minimum.</param>
        /// <param name="redToMin">The red to minimum.</param>
        /// <param name="amberFromMin">The amber from minimum.</param>
        /// <param name="amberToMin">The amber to minimum.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPICodeAddNew(string KPIHeadCode, string KPIHeadDesc, string TargetValue, string RedFrom, string RedTo, string AmberFrom, string AmberTo, string GreenFrom, string GreenTo, string ModifiedBy, string ModifiedDate, string isChecked, string isGroupTarget, string redFromMin, string redToMin, string amberFromMin, string amberToMin)
        {
            var objKpi = new DL.KPI();
            DataSet ds = objKpi.KPICodeAddNew(KPIHeadCode, KPIHeadDesc, TargetValue, RedFrom, RedTo, AmberFrom, AmberTo, GreenFrom, GreenTo, ModifiedBy, ModifiedDate, isChecked, isGroupTarget,redFromMin,redToMin,amberFromMin,amberToMin);
            return ds;
        }
        /// <summary>
        /// Update KPI code
        /// </summary>
        /// <param name="KPIHeadCode">The kpi head code.</param>
        /// <param name="KPIHeadDesc">The kpi head desc.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <param name="ModifiedDate">The modified date.</param>
        /// <param name="Ischecked">The ischecked.</param>
        /// <param name="isGroupTarget">The is group target.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPICodeUpdate(string KPIHeadCode, string KPIHeadDesc, string ModifiedBy, string ModifiedDate, string Ischecked, string isGroupTarget)
        {
            DL.KPI objKPI = new DL.KPI();
            DataSet ds = objKPI.KPICodeUpdate(KPIHeadCode, KPIHeadDesc, ModifiedBy, ModifiedDate, Ischecked, isGroupTarget);
            return ds;
        }
        /// <summary>
        /// Get KPI Color code from table KPIColourCodes
        /// </summary>
        /// <param name="AmendmentNo">The amendment no.</param>
        /// <param name="ElementType">Type of the element.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetKpiColorCode(string AmendmentNo, string ElementType)
        {
            DL.KPI objKPI = new DL.KPI();

            DataSet ds = objKPI.GetKpiColorCode(AmendmentNo, ElementType);
            return ds;
        }
        /// <summary>
        /// Get Amendment number to fill Dropdown
        /// </summary>
        /// <param name="ElementType">Type of the element.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAmendmentNo(string ElementType)
        {
            DL.KPI objKPI = new DL.KPI();

            DataSet ds = objKPI.GetAmendmentNo(ElementType);
            return ds;
        }

        /// <summary>
        /// Update data in table KPIColourCodes
        /// </summary>
        /// <param name="KPIHeadCode">The kpi head code.</param>
        /// <param name="ElementLevel">The element level.</param>
        /// <param name="RedFrom">The red from.</param>
        /// <param name="RedTo">The red to.</param>
        /// <param name="AmberFrom">The amber from.</param>
        /// <param name="AmberTo">The amber to.</param>
        /// <param name="GreenFrom">The green from.</param>
        /// <param name="GreenTo">The green to.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <param name="ModifiedDate">The modified date.</param>
        /// <param name="AmendmentNo">The amendment no.</param>
        /// <param name="targetValue">The target value.</param>
        /// <param name="redFromMin">The red from minimum.</param>
        /// <param name="redToMin">The red to minimum.</param>
        /// <param name="amberFromMin">The amber from minimum.</param>
        /// <param name="amberToMin">The amber to minimum.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPIColorCodeUpdate(string KPIHeadCode, string ElementLevel, string RedFrom, string RedTo, string AmberFrom, string AmberTo, string GreenFrom, string GreenTo, string ModifiedBy, string ModifiedDate, int AmendmentNo, string targetValue,string redFromMin, string redToMin,string amberFromMin, string amberToMin)
        {
            var objKpi = new DL.KPI();
            DataSet ds = objKpi.KPIColorCodeUpdate(KPIHeadCode, ElementLevel, RedFrom, RedTo, AmberFrom, AmberTo, GreenFrom, GreenTo, ModifiedBy, ModifiedDate, AmendmentNo, targetValue,redFromMin,redToMin,amberFromMin,amberToMin);
            return ds;
        }
        /// <summary>
        /// Amned data in KPIColourCodes table
        /// </summary>
        /// <param name="ElementLevel">The element level.</param>
        /// <param name="WEFdate">The we fdate.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPIColorCodeAmend(string ElementLevel, string WEFdate,string ModifiedBy)
        {
            DL.KPI objKPI = new DL.KPI();

            DataSet ds = objKPI.KPIColorCodeAmend(ElementLevel, WEFdate ,ModifiedBy);
            return ds;
        }
        /// <summary>
        /// Authorised data KPIColourCodes table
        /// </summary>
        /// <param name="ElementLevel">The element level.</param>
        /// <param name="EffectiveFrom">The effective from.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPIColorCodeAuthorized(string ElementLevel, string EffectiveFrom, string ModifiedBy)
        {
            DL.KPI objKPI = new DL.KPI();

            DataSet ds = objKPI.KPIColorCodeAuthorized(ElementLevel, EffectiveFrom, ModifiedBy);
            return ds;
        }

        //-------------------------------------------- For Sub Reports Related ----------------------------------------
        /// <summary>
        /// Get Kpi Sub report
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtID">The asmt identifier.</param>
        /// <param name="postAutoID">The post automatic identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="reportType">Type of the report.</param>
        /// <param name="kPIType">Type of the k pi.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetKPISubDetail(string companyCode, string hrLocationCode, string locationCode, string clientCode, string asmtID, string postAutoID, string month, string year, string reportType, string kPIType)
        {
            var objKPI = new DL.KPI();
            DataSet ds = objKPI.GetKPISubDetail(companyCode, hrLocationCode, locationCode, clientCode, asmtID, postAutoID, month, year, reportType, kPIType);
            return ds;
        }
        /// <summary>
        /// Get Kpi Color Code
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllKPIColorCode(string fromDate, string toDate)
        {
            var objKPI = new DL.KPI();
            DataSet ds = objKPI.GetAllKPIColorCode(fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// Gets the kpi drill detail.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtID">The asmt identifier.</param>
        /// <param name="postAutoID">The post automatic identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="reportType">Type of the report.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetKPIDrillDetail(string companyCode, string hrLocationCode, string locationCode, string clientCode, string asmtID, string postAutoID, string month, string year, string reportType)
        {
            var objKPI = new DL.KPI();
            DataSet ds = objKPI.GetKPIDrillDetail(companyCode, hrLocationCode, locationCode, clientCode, asmtID, postAutoID, month, year, reportType);
            return ds;
        }
        //-----------------------------------------------End For Sub Reports-------------------------------------------------



        //public DataSet UserLocationAccessGetCommaValue(string companyCode, string hrLocationCode, string locationCode, string clientCode, string asmtID, string postAutoID, string month, string year, string reportType, string kPIType)
        // {
        //     var objKPI = new DL.KPI();
        //     DataSet ds = objKPI.GetKPISubDetail(companyCode, hrLocationCode, locationCode, clientCode, asmtID, postAutoID, month, year, reportType, kPIType);
        //     return ds;
        // }

        /// <summary>
        /// Select value comma seprated on user role basis
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>DataSet.</returns>

        public DataSet UserLocationAccessGet(string userId, string companyCode, string hrLocationCode)
        {
            BL.UserManagement objdlUserManagement = new BL.UserManagement();
            DL.KPI objKPI = new DL.KPI();


            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (userId != objdlUserManagement.SuperAdminIdGet())
            {
                ds = objKPI.UserAccessCommaSeprated(userId, companyCode, hrLocationCode);
                //ds = objdlUserManagement.UserLocationAccessGet(userId, companyCode, hrLocationCode);
            }
            else
            {
                ds = objKPI.AdminAccessCommaSeprated(companyCode, hrLocationCode);
            }
            return ds;
        }

        /// <summary>
        /// Used to processed kpi data from page
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPIProcessing(string companyCode, string fromDate, string toDate)
        {
            var objKPI = new DL.KPI();
            DataSet ds = objKPI.KPIProcessing(companyCode, fromDate, toDate);
            return ds;
        }
//------------------------------------------------------------------EstablishmentScreen-----------------------------------------
        /// <summary>
        /// Gets the establishment value.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
         public DataSet GetEstablishmentValue(string locationAutoID)
        {
            var objKPI = new DL.KPI();
            DataSet ds = objKPI.GetEstablishmentValue(locationAutoID);
            return ds;
        }
         /// <summary>
         /// For Insert new record
         /// </summary>
         /// <param name="locationAutoID">The location automatic identifier.</param>
         /// <param name="establishmentValue">The establishment value.</param>
         /// <param name="fromDate">From date.</param>
         /// <param name="toDate">To date.</param>
         /// <returns>DataSet.</returns>
         public DataSet EstablishmentValueInsert(string locationAutoID, string establishmentValue, string fromDate, string toDate)
         {
             var objKPI = new DL.KPI();
             DataSet ds = objKPI.EstablishmentValueInsert(locationAutoID, establishmentValue, fromDate, toDate);
             return ds;
         }
         /// <summary>
         /// Update EstablishmentValue.Only EstablishmentValue is allow to update
         /// </summary>
         /// <param name="locationAutoID">The location automatic identifier.</param>
         /// <param name="establishmentValue">The establishment value.</param>
         /// <param name="fromDate">From date.</param>
         /// <param name="toDate">To date.</param>
         /// <returns>DataSet.</returns>
         public DataSet EstablishmentValueUpdate(string locationAutoID, string establishmentValue, string fromDate, string toDate)
         {
             var objKPI = new DL.KPI();
             DataSet ds = objKPI.EstablishmentValueUpdate(locationAutoID, establishmentValue, fromDate, toDate);
             return ds;
         }
         /// <summary>
         /// For Delete the record
         /// </summary>
         /// <param name="locationAutoID">The location automatic identifier.</param>
         /// <param name="establishmentValue">The establishment value.</param>
         /// <param name="fromDate">From date.</param>
         /// <param name="toDate">To date.</param>
         /// <returns>DataSet.</returns>
        public DataSet EstablishmentDelete(string locationAutoID, string establishmentValue, string fromDate, string toDate)
         {
             var objKPI = new DL.KPI();
             DataSet ds = objKPI.EstablishmentDelete(locationAutoID, establishmentValue, fromDate, toDate);
             return ds;
         }

        /// <summary>
        /// It returns the Value as 0,1,2 depending on the Selection Parameters on the reversal (Locations --&gt; HrLocation --&gt; Company)
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataTable.</returns>
        public DataTable LocationSelectionParamGet(string locationAutoID,string companyCode)
        {
            var objKPI = new DL.KPI();
            DataTable dtr = objKPI.LocationSelectionParamGet(locationAutoID, companyCode);
            return dtr;
        }

       
    }
}
