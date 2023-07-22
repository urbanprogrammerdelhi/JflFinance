using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Globalization;

namespace DL
{
    [CLSCompliantAttribute(false)]
    public class AssetWorkOrder
    {

        #region Asset Work Order Get Functions
        /// <summary>
        /// to get Asset Work Order Information for a Location and a Client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="deleteStatus">The delete status.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssetWorkOrderInfoGet(string locationAutoId, string clientCode, string asmtId, string deleteStatus)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DeleteStatus, deleteStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_AssetWO_Get4LocClient", objParm);
            return ds;
        }

        public DataSet AssetWorkOrderDetailGet(string locationAutoId, string assetWoNo, string assetWoAmendNo, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWoAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWODetailsGet", objParam);
            return ds;
        }

        #endregion


        #region Asset WorkOrder Details
        public DataSet AssetWOMasterUpdate(string locationAutoId, string assetWoNo, string assetWoAmendNo, string wefDate, string clientCode, string woStatus, string woTerminationDate, string woTerminationReason, string woTerminatedBy, string asmtBillingId, string modifiedBy, string myStatus, string invoiceType, string remarks)
        {
            SqlParameter[] objParam = new SqlParameter[14];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWoAmendNo);
            if (string.IsNullOrEmpty(wefDate))
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.WEFDate, DBNull.Value);
            }
            else
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(wefDate));
            }
            objParam[4] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.WoStatus, woStatus);
            if (string.IsNullOrEmpty(woTerminationDate))
            {
                objParam[6] = new SqlParameter(DL.Properties.Resources.WoTerminationDate, DBNull.Value);
            }
            else
            {
                objParam[6] = new SqlParameter(DL.Properties.Resources.WoTerminationDate, DL.Common.DateFormat(woTerminationDate));
            }

            objParam[7] = new SqlParameter(DL.Properties.Resources.WoTerminationReason, woTerminationReason);
            objParam[8] = new SqlParameter(DL.Properties.Resources.WOTerminatedBy, woTerminatedBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.AsmtBillingId, asmtBillingId);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[11] = new SqlParameter(DL.Properties.Resources.MyStatus, myStatus);
            objParam[12] = new SqlParameter(DL.Properties.Resources.InvoiceType, invoiceType);
            objParam[13] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWOMasterUpdate", objParam);
            return ds;
        }

        public DataSet AssetWOMasterSave(string locationAutoId, string wefDate, string clientCode, string woStatus, string woTerminationDate, string woTerminationReason, string woTerminatedBy, string asmtBillingId, string modifiedBy, string invoiceType, string remarks)
        {
            SqlParameter[] objParam = new SqlParameter[11];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            if (string.IsNullOrEmpty(wefDate))
            {
                objParam[1] = new SqlParameter(DL.Properties.Resources.WEFDate, DBNull.Value);
            }
            else
            {
                objParam[1] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(wefDate));
            }
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.WoStatus, woStatus);
            if (string.IsNullOrEmpty(woTerminationDate))
            {
                objParam[4] = new SqlParameter(DL.Properties.Resources.WoTerminationDate, DBNull.Value);
            }
            else
            {
                objParam[4] = new SqlParameter(DL.Properties.Resources.WoTerminationDate, DL.Common.DateFormat(woTerminationDate));
            }

            objParam[5] = new SqlParameter(DL.Properties.Resources.WoTerminationReason, woTerminationReason);
            objParam[6] = new SqlParameter(DL.Properties.Resources.WOTerminatedBy, woTerminatedBy);
            objParam[7] = new SqlParameter(DL.Properties.Resources.AsmtBillingId, asmtBillingId);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.InvoiceType, invoiceType);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWOMasterSaveNew", objParam);
            return ds;
        }

        public DataSet AssetWorkOrderAmendNoGet(string locationAutoId, string assetWoNo)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetAmendNoofWO_GetAll", objParam);
            return ds;
        }

        public DataSet AssetWorkOrderGet(string locationAutoId, string assetWoNo, string assetWoAmendNo)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWoAmendNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWorkOrder_Get", objParm);
            return ds;
        }

        public DataSet AssetWorkOrderAmend(string locationAutoId, string assetWoNo, string woStatus, string modifiedBy, string myStatus, string wefDate)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.WoStatus, woStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.MyStatus, myStatus);
            objParam[5] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(wefDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAsset_WorkOrder_Amend", objParam);
            return ds;
        }

        public DataSet AssetWorkOrderAuthorized(string locationAutoId, string assetWoNo, string assetWoAmendNo, string woStatus, string modifiedBy, string myStatus)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWoAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.WoStatus, woStatus);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.MyStatus, myStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAsset_WorkOrder_Authorized", objParam);
            return ds;
        }
        public DataSet PostAssetsGet(string postAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPostAssets_Get", objParm);
            return ds;
        }

        public DataSet AssetsServiceTypeGet(string assetAutoId, string LocationAutoID)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AssetAutoId, assetAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetsServiceTypeGetByAssetAutoId", objParm);
            return ds;
        }


        public DataSet WorkOrderDetailAddNew(string locationAutoId, string assetWONo, string assetWOAmendNo, string contractNumber, string asmtId, string postAutoId, 
            string assetAutoId, string assetServiceTypeAutoId, string woLineStartDate, string woLineEndDate, string woLineWEFDate, bool billable, bool active, 
            double rate, double monthlyBilling, string remarks, string modifiedBy)
        {

            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(assetWOAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(postAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(assetAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(assetServiceTypeAutoId, "myInt32Argument");

            SqlParameter[] objParam = new SqlParameter[17];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWONo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, Int32.Parse(assetWOAmendNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PostAutoId, Int32.Parse(postAutoId));
            objParam[6] = new SqlParameter(DL.Properties.Resources.AssetAutoId, Int32.Parse(assetAutoId));
            objParam[7] = new SqlParameter(DL.Properties.Resources.AssetServiceTypeAutoId, Int32.Parse(assetServiceTypeAutoId));
            objParam[8] = new SqlParameter(DL.Properties.Resources.WOLineStartDate, DL.Common.DateFormat(woLineStartDate));
            objParam[9] = new SqlParameter(DL.Properties.Resources.WOLineEndDate, DL.Common.DateFormat(woLineEndDate));
            objParam[10] = new SqlParameter(DL.Properties.Resources.WOLineWEFDate, DL.Common.DateFormat(woLineWEFDate));
            objParam[11] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[12] = new SqlParameter(DL.Properties.Resources.Active, active);
            objParam[13] = new SqlParameter(DL.Properties.Resources.Rate, rate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.MonthlyBilling, monthlyBilling);
            objParam[15] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWODetailsSaveNew", objParam);
            return ds;
        }

        public DataSet AssetWorkOrderDetailsDelete(string assetWoNo, string assetWoAmendNo, string assetWoLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWoAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoLineNo, assetWoLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWODetailsDelete", objParam);
            return ds;
        }

        public DataSet AssetWODetailsMaximumAuthorizedWEFDateGet(string assetWONo, int assetWOLineNo, int locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWONo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoLineNo, assetWOLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AssetWODetails_GetMaximumAuthorizedWEFDate", objParam);
            return ds;
        }

        public DataSet WorkOrderDetailUpdate(string locationAutoId, string assetWoNo, string assetWoAmendNo, string assetWoLineNo, 
            string contractNumber, string asmtId, string postAutoId, string assetAutoId, string assetServiceTypeAutoId, string woLineStartDate, 
            string woLineEndDate, string woLineWEFDate, bool billable, bool active, double rate, double monthlyBilling, 
            string remarks, string  modifiedBy, string statusFresh)
        {
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(assetWoLineNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(postAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(assetAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(assetServiceTypeAutoId, "myInt32Argument");

            SqlParameter[] objParam = new SqlParameter[19];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWoAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AssetWoLineNo, Int32.Parse(assetWoLineNo));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[6] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.AssetAutoId, assetAutoId);
            objParam[8] = new SqlParameter(DL.Properties.Resources.AssetServiceTypeAutoId, assetServiceTypeAutoId);
            objParam[9] = new SqlParameter(DL.Properties.Resources.WOLineStartDate, DL.Common.DateFormat(woLineStartDate));
            objParam[10] = new SqlParameter(DL.Properties.Resources.WOLineEndDate, DL.Common.DateFormat(woLineEndDate));
            objParam[11] = new SqlParameter(DL.Properties.Resources.WOLineWEFDate, DL.Common.DateFormat(woLineWEFDate));
            objParam[12] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[13] = new SqlParameter(DL.Properties.Resources.Active, active);
            objParam[14] = new SqlParameter(DL.Properties.Resources.Rate, rate);
            objParam[15] = new SqlParameter(DL.Properties.Resources.MonthlyBilling, monthlyBilling);
            objParam[16] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[17] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[18] = new SqlParameter(DL.Properties.Resources.StatusFresh, statusFresh);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWODetailsUpdate", objParam);
            return ds;
        }

        public DataSet WoLineDeptHeaderInfoGet(string assetWoNo, string assetWoAmendNo, string AssetWoLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWoAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoLineNo, AssetWoLineNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetWOLineDeptHeader", objParam);
            return ds;
        }

        public DataSet WoLineDeptInfoGet(string assetWoNo, string assetWoAmendNo, string AssetWoLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWoNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWoAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoLineNo, AssetWoLineNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetWOLineDeptDetails", objParam);
            return ds;
        }

        public DataSet WoLineServiceSchSave(string assetWONo, string assetWOAmendNo, string assetWOLineNo, string woStatus, string shiftCode,
            string frequency, string monthNumbers, string monthDays, string weekNos, string weekDays, string fromTime,
            string toTime, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetWoNo, assetWONo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetWoAmendNo, assetWOAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AssetWoLineNo, assetWOLineNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.WoStatus, woStatus);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Frequency, frequency);
            objParam[6] = new SqlParameter(DL.Properties.Resources.MonthNumbers, monthNumbers);
            objParam[7] = new SqlParameter(DL.Properties.Resources.MonthDays, monthDays);
            objParam[8] = new SqlParameter(DL.Properties.Resources.WeekNos, weekNos);
            objParam[9] = new SqlParameter(DL.Properties.Resources.WeekDays, weekDays);
            objParam[10] = new SqlParameter(DL.Properties.Resources.FromTime, fromTime);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ToTime, toTime);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UpdWoLineServiceSchSave", objParam);
            return ds;
        }
        #endregion Asset WorkOrder Details
    }
}
