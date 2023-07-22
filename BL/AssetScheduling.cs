using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    [CLSCompliantAttribute(false)]
    public class AssetScheduling
    {
        public DataSet AssetGet(string AssetCode)
        {
            DL.AssetScheduling objdlAssetScheduling = new DL.AssetScheduling();
            DataSet ds = objdlAssetScheduling.AssetGet(AssetCode);
            return ds;
        }

        public DataSet AssetGetAll()
        {
            DL.AssetScheduling objdlAssetScheduling = new DL.AssetScheduling();
            DataSet ds = objdlAssetScheduling.AssetGetAll();
            return ds;
        }

        public DataSet AssetScheduleGet(string locationautoid, string clientCode, string asmtId, string postAutoId, string dutyDate)
        {
            DL.AssetScheduling objdlAssetScheduling = new DL.AssetScheduling();
            DataSet ds = objdlAssetScheduling.AssetScheduleGet(locationautoid, clientCode, asmtId, postAutoId, dutyDate);
            return ds;
        }

        public DataSet AssetScheduleSaveUpdate(string AssetScheduleAutoId, string LocationAutoId, string ClientCode, string AsmtId, string AssetWONo
            , string AssetWoLineNo, string PostAutoId, string AssetAutoId, string AssetServiceTypeAutoId, string AssetCheckListAutoId
            , string DutyDate, string FromTime, string ToTime, string EmployeeNumber, string SchFromTime, string SchToTime
            , string ModifiedBy)
        {
            DL.AssetScheduling objdlAssetScheduling = new DL.AssetScheduling();
            DataSet ds = objdlAssetScheduling.AssetScheduleSaveUpdate(AssetScheduleAutoId, LocationAutoId, ClientCode, AsmtId, AssetWONo, AssetWoLineNo, PostAutoId, AssetAutoId
                        , AssetServiceTypeAutoId, AssetCheckListAutoId, DutyDate, FromTime, ToTime, EmployeeNumber, SchFromTime
                        , SchToTime, ModifiedBy);
            return ds;
        }
       

        public DataSet AssetScheduleGetNew(string locationautoid, string clientCode, string asmtId, string postAutoId, string dutyDate, string ToDate)
        {
            DL.AssetScheduling objdlAssetScheduling = new DL.AssetScheduling();
            DataSet ds = objdlAssetScheduling.AssetScheduleGetNew(locationautoid, clientCode, asmtId, postAutoId, dutyDate, ToDate);
            return ds;
        }

        public DataSet GetWeeks(string locationautoid, string Month, string Year)
        {
            DL.AssetScheduling objdlAssetScheduling = new DL.AssetScheduling();
            DataSet ds = objdlAssetScheduling.GetWeeks(locationautoid, Month, Year);
            return ds;
        }
        public DataSet AssetScheduleAutoFill(string locationautoid, string clientCode, string asmtId, string postAutoId, string dutyDate, string ToDate)
        {
            DL.AssetScheduling objdlAssetScheduling = new DL.AssetScheduling();
            DataSet ds = objdlAssetScheduling.AssetScheduleAutoFill(locationautoid, clientCode, asmtId, postAutoId, dutyDate, ToDate);
            return ds;
        }
    }
}
