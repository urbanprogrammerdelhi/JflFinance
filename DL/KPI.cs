// ***********************************************************************
// Assembly         : DL
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
using System.Data.SqlClient;


/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{

    /// <summary>
    /// Class KPI.
    /// </summary>
    public class KPI
    {

        /// <summary>
        /// Get All KPI code from table
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetKpiCode(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllKpiCode", objParm);
            return ds;
        }

        /// <summary>
        /// Add new KPI code in data base
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
        /// <param name="Ischecked">The ischecked.</param>
        /// <param name="isGroupTarget">The is group target.</param>
        /// <param name="redFromMin">The red from minimum.</param>
        /// <param name="redToMin">The red to minimum.</param>
        /// <param name="amberFromMin">The amber from minimum.</param>
        /// <param name="amberToMin">The amber to minimum.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPICodeAddNew(string KPIHeadCode, string KPIHeadDesc, string TargetValue, string RedFrom, string RedTo, string AmberFrom, string AmberTo, string GreenFrom, string GreenTo, string ModifiedBy, string ModifiedDate, string Ischecked, string isGroupTarget, string redFromMin, string redToMin, string amberFromMin, string amberToMin)
        {

            var objParm = new SqlParameter[17];
            objParm[0] = new SqlParameter(DL.Properties.Resources.KPIHeadCode, KPIHeadCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.KPIHeadDesc, KPIHeadDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.TargetValue, TargetValue);
            objParm[3] = new SqlParameter(DL.Properties.Resources.RedFrom, RedFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.RedTo, RedTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AmberFrom, AmberFrom);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AmberTo, AmberTo);
            objParm[7] = new SqlParameter(DL.Properties.Resources.GreenFrom, GreenFrom);
            objParm[8] = new SqlParameter(DL.Properties.Resources.GreenTo, GreenTo);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParm[10] = new SqlParameter(DL.Properties.Resources.ModifiedDate, DL.Common.DateFormat(ModifiedDate));
            objParm[11] = new SqlParameter(DL.Properties.Resources.IsChecked, Ischecked);
            objParm[12] = new SqlParameter(DL.Properties.Resources.IsGroupTarget, isGroupTarget);
            objParm[13] = new SqlParameter(DL.Properties.Resources.RedFromMin, redFromMin);
            objParm[14] = new SqlParameter(DL.Properties.Resources.RedToMin, redToMin);
            objParm[15] = new SqlParameter(DL.Properties.Resources.AmberFromMin, amberFromMin);
            objParm[16] = new SqlParameter(DL.Properties.Resources.AmberToMin, amberToMin);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPICode_Insert", objParm);
            return ds;

        }
    
        //public DataSet KPICodeUpdate(string KPIHeadCode, string KPIHeadDesc, string TargetValue, string RedFrom, string RedTo, string AmberFrom, string AmberTo, string GreenFrom, string GreenTo, string ModifiedBy, string ModifiedDate, string Ischecked)
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.KPIHeadCode, KPIHeadCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.KPIHeadDesc, KPIHeadDesc);
            //objParm[2] = new SqlParameter(DL.Properties.Resources.TargetValue, TargetValue);
            //objParm[3] = new SqlParameter(DL.Properties.Resources.RedFrom, RedFrom);
            //objParm[4] = new SqlParameter(DL.Properties.Resources.RedTo, RedTo);
            //objParm[5] = new SqlParameter(DL.Properties.Resources.AmberFrom, AmberFrom);
            //objParm[6] = new SqlParameter(DL.Properties.Resources.AmberTo, AmberTo);
            //objParm[7] = new SqlParameter(DL.Properties.Resources.GreenFrom, GreenFrom);
            //objParm[8] = new SqlParameter(DL.Properties.Resources.GreenTo, GreenTo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedDate, DL.Common.DateFormat(ModifiedDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsChecked, Ischecked);
            objParm[5] = new SqlParameter(DL.Properties.Resources.IsGroupTarget, isGroupTarget);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPICode_Update", objParm);
            return ds;

        }
        /// <summary>
        /// Get KPI color code from Color Table
        /// </summary>
        /// <param name="AmendmentNo">The amendment no.</param>
        /// <param name="ElementType">Type of the element.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetKpiColorCode(string AmendmentNo, string ElementType)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AmendmentNo, AmendmentNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ElementType, ElementType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllKpiColorCode", objParm);
            return ds;
        }
        /// <summary>
        /// Get amendment number to fill drop down
        /// </summary>
        /// <param name="ElementType">Type of the element.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAmendmentNo(string ElementType)
        {
            //string ElementType = string.Empty;
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ElementType, ElementType);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetKPIAmendmentNo", objParm);
            return ds;
        }

        /// <summary>
        /// Color Code table update
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
        public DataSet KPIColorCodeUpdate(string KPIHeadCode, string ElementLevel, string RedFrom, string RedTo, string AmberFrom, string AmberTo, string GreenFrom, string GreenTo, string ModifiedBy, string ModifiedDate, int AmendmentNo, string targetValue, string redFromMin, string redToMin, string amberFromMin, string amberToMin)
        {

           var objParm = new SqlParameter[16];
            objParm[0] = new SqlParameter(DL.Properties.Resources.KPIHeadCode, KPIHeadCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ElementLevel, @ElementLevel);
            objParm[2] = new SqlParameter(DL.Properties.Resources.RedFrom, RedFrom);
            objParm[3] = new SqlParameter(DL.Properties.Resources.RedTo, RedTo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AmberFrom, AmberFrom);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AmberTo, AmberTo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.GreenFrom, GreenFrom);
            objParm[7] = new SqlParameter(DL.Properties.Resources.GreenTo, GreenTo);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ModifiedDate, DL.Common.DateFormat(ModifiedDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParm[10] = new SqlParameter(DL.Properties.Resources.AmendmentNo, AmendmentNo);
            objParm[11] = new SqlParameter(DL.Properties.Resources.TargetValue, targetValue);
            objParm[12] = new SqlParameter(DL.Properties.Resources.RedFromMin, redFromMin);
            objParm[13] = new SqlParameter(DL.Properties.Resources.RedToMin, redToMin);
            objParm[14] = new SqlParameter(DL.Properties.Resources.AmberFromMin, amberFromMin);
            objParm[15] = new SqlParameter(DL.Properties.Resources.AmberToMin, amberToMin);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPIColorCode_Update", objParm);
            return ds;

        }
        /// <summary>
        /// Create new Amnendmend number for update
        /// </summary>
        /// <param name="ElementLevel">The element level.</param>
        /// <param name="WEFdate">The we fdate.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPIColorCodeAmend(string ElementLevel, string WEFdate, string ModifiedBy)
        {
            string ElementType = string.Empty;
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ElementType, ElementLevel);
            objParm[1] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(WEFdate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPIColorCode_Amend", objParm);
            return ds;
        }
        /// <summary>
        /// For Data Authorization
        /// </summary>
        /// <param name="ElementLevel">The element level.</param>
        /// <param name="EffectiveFrom">The effective from.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPIColorCodeAuthorized(string ElementLevel, string EffectiveFrom, string ModifiedBy)
        {
            string ElementType = string.Empty;
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ElementType, ElementLevel);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(EffectiveFrom));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPIColorCode_Authorized", objParm);
            return ds;
        }
        //  -------------------------------------------- Sub Report Related Function-----------------------------------------------------
        /// <summary>
        /// Get kpi Sub Report Details
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
            var objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[4] = new SqlParameter(Properties.Resources.AsmtId, asmtID);
            objParm[5] = new SqlParameter(Properties.Resources.PostAutoId, postAutoID);
            objParm[6] = new SqlParameter(Properties.Resources.Month, month);
            objParm[7] = new SqlParameter(Properties.Resources.Year, year);
            objParm[8] = new SqlParameter(Properties.Resources.ReportType, reportType);
            DataSet ds = new DataSet();
            if (kPIType == "DirectLabour")
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPI_DirectLabour", objParm);
            }

            return ds;
        }
        /// <summary>
        /// get Kpi Color Code
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllKPIColorCode(string fromDate, string toDate)
        {
            DataSet ds = new DataSet();
            var objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(Properties.Resources.ToDate, fromDate);
            objParm[1] = new SqlParameter(Properties.Resources.FromDate, toDate);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPIColourXml_Get", objParm);
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
            var objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[4] = new SqlParameter(Properties.Resources.AsmtId, asmtID);
            objParm[5] = new SqlParameter(Properties.Resources.PostAutoId, postAutoID);
            objParm[6] = new SqlParameter(Properties.Resources.Month, month);
            objParm[7] = new SqlParameter(Properties.Resources.Year, year);
            objParm[8] = new SqlParameter(Properties.Resources.ReportType, reportType);
            DataSet ds = new DataSet();
           
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPI_DirectLabour_DrillDown", objParm);
  
            return ds;
        }
        // ----------------------------------------------End Sub Report ------------------------------------------------------------------------

        /// <summary>
        /// Exract comma seprated value if any user log in
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserAccessCommaSeprated(string userId, string companyCode, string hrLocationCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);

            DataSet ds = SqlHelper.ExecuteDataset("udp_UserLocationAccess_BasedOnCompanyHrLocationUserID_GetCommaValue", objParam);
            return ds;
        }
        /// <summary>
        /// Admins the access comma seprated.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AdminAccessCommaSeprated(string companyCode, string hrLocationCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);

            DataSet ds = SqlHelper.ExecuteDataset("udp_SuperAdminLocationAccess_BasedonCompanyCodeAndHRLocationCode_GetComma", objParam);
            return ds;
        }


        /// <summary>
        /// To Process KPI
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet KPIProcessing(string companyCode, string fromDate, string toDate)
        {
            DataSet ds = new DataSet();
            var objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[2] = new SqlParameter(Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "KPIProcessing", objParm);
            return ds;
        }
//---------------------------------------------------------Estibleshment Screen----------------------------------------------
        /// <summary>
        /// Get value to show in screen
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetEstablishmentValue(string locationAutoID)
        {
            DataSet ds = new DataSet();
            var objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoID);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetEstablishment", objParm);
            return ds;
        }
        /// <summary>
        /// To Insert New Value
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="establishmentValue">The establishment value.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EstablishmentValueInsert(string locationAutoID, string establishmentValue, string fromDate, string toDate)

        {
            DataSet ds = new DataSet();
            var objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoID);
            objParm[1] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[2] = new SqlParameter(Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(Properties.Resources.EstablishmentValue, establishmentValue);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPIEstablishment_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// For update establishmentValue
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="establishmentValue">The establishment value.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EstablishmentValueUpdate(string locationAutoID, string establishmentValue, string fromDate, string toDate)

        {
            DataSet ds = new DataSet();
            var objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoID);
            objParm[1] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[2] = new SqlParameter(Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(Properties.Resources.EstablishmentValue, establishmentValue);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPIEstablishment_Update", objParm);
            return ds;
        }
        /// <summary>
        /// For Deleting Value
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="establishmentValue">The establishment value.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EstablishmentDelete(string locationAutoID, string establishmentValue, string fromDate, string toDate)

        {
            DataSet ds = new DataSet();
            var objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoID);
            objParm[1] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[2] = new SqlParameter(Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(Properties.Resources.EstablishmentValue, establishmentValue);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_KPIEstablishment_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// It returns the Value as 0,1,2 depending on the Selection Parameters on the reversal (Locations --&gt; HrLocation --&gt; Company)
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataTable.</returns>
        public DataTable LocationSelectionParamGet(string locationAutoID, string companyCode)
        {
            DataTable dt = new DataTable();
            var objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoID);
            objParm[1] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            

            dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udp_KPILevelofReportOpening_Get", objParm);
            return dt;
        }
        

    }
}
