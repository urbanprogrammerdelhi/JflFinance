using System;
using System.Data;
using System.Data.SqlClient;

namespace DL
{
    [CLSCompliantAttribute(false)]
    public class AssetScheduling
    {
        public DataSet AssetGet(string assetCode)
        {
            var objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCode, assetCode);
            var ds = SqlHelper.ExecuteDataset("udpAssetGetByCode", objParam);
            return ds;
        }
        public DataSet AssetGetAll()
        {
            var ds = SqlHelper.ExecuteDataset("udpAssetGet");
            return ds;
        }

        public DataSet ServiceTypeGet(string assetCode)
        {
            var objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCode, assetCode);
            var ds = SqlHelper.ExecuteDataset("udpServiceTypeGetByAssetCode", objParam);
            return ds;
        }

        public DataSet AssetScheduleGet(string locationautoid, string clientCode, string asmtId, string postAutoId, string dutyDate)
        {
            var objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationautoid);
            objParam[1] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(Properties.Resources.PostAutoId, postAutoId);
            objParam[4] = new SqlParameter(Properties.Resources.DutyDate, dutyDate);
            var ds = SqlHelper.ExecuteDataset("udpAssetScheduleGet", objParam);
            return ds;
        }

        public DataSet AssetScheduleSaveUpdate(string AssetScheduleAutoId, string LocationAutoId, string ClientCode, string AsmtId, string AssetWONo
          , string AssetWoLineNo, string PostAutoId, string AssetAutoId, string AssetServiceTypeAutoId, string AssetCheckListAutoId
          , string DutyDate, string FromTime, string ToTime, string EmployeeNumber, string SchFromTime, string SchToTime
          , string ModifiedBy)
        {
            var objParam = new SqlParameter[17];
            objParam[0] = new SqlParameter(Properties.Resources.AssetScheduleAutoId, AssetScheduleAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.AssetWoNo, AssetWONo);
            objParam[5] = new SqlParameter(Properties.Resources.AssetWoLineNo, AssetWoLineNo);
            objParam[6] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[7] = new SqlParameter(Properties.Resources.AssetAutoId, AssetAutoId);
            objParam[8] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, AssetServiceTypeAutoId);
            objParam[9] = new SqlParameter(Properties.Resources.AssetCheckListAutoId, AssetCheckListAutoId);
            objParam[10] = new SqlParameter(Properties.Resources.DutyDate, DutyDate);
            objParam[11] = new SqlParameter(Properties.Resources.FromTime, FromTime);
            objParam[12] = new SqlParameter(Properties.Resources.ToTime, ToTime);
            objParam[13] = new SqlParameter(Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[14] = new SqlParameter(Properties.Resources.SchFromTime, SchFromTime);
            objParam[15] = new SqlParameter(Properties.Resources.SchToTime, SchToTime);
            objParam[16] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            var ds = SqlHelper.ExecuteDataset("udpAssetScheduleSaveUpdate", objParam);
            return ds;
        }
        public DataSet AssetScheduleGetNew(string locationautoid, string clientCode, string asmtId, string postAutoId, string dutyDate, string ToDate)
        {
            var objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationautoid);
            objParam[1] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(Properties.Resources.PostAutoId, postAutoId);
            objParam[4] = new SqlParameter(Properties.Resources.FromDate, dutyDate);
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, ToDate);
            var ds = SqlHelper.ExecuteDataset("udp_GetSchedulingWeekWise", objParam);
            return ds;
        }
        public DataSet GetWeeks(string locationautoid, string Month, string Year)
        {
            var objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationautoid);
            objParam[1] = new SqlParameter(Properties.Resources.Month, Month);
            objParam[2] = new SqlParameter(Properties.Resources.Year, Year);
            var ds = SqlHelper.ExecuteDataset("udpTransaction_Roster_GetWeek", objParam);
            return ds;
        }
        public DataSet AssetScheduleAutoFill(string locationautoid, string clientCode, string asmtId, string postAutoId, string dutyDate, string ToDate)
        {
            var objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationautoid);
            objParam[1] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(Properties.Resources.PostAutoId, postAutoId);
            objParam[4] = new SqlParameter(Properties.Resources.FromDate, dutyDate);
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, ToDate);
            var ds = SqlHelper.ExecuteDataset("udp_GetSchedulingWeekWiseAutoFill", objParam);
            return ds;
        }
    }
}
