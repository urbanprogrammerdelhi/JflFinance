using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    [CLSCompliantAttribute(false)]
    public class AssetWorkOrder
    {

        #region Asset Work Order Get Functions
        /// <summary>
        /// to get Asset WorkOrder Information for a Location and a Client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="WoStatus">The Wo status.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssetWorkOrderInfoGet(string locationAutoId, string clientCode, string asmtId, string WoStatus)
        {

            DL.AssetWorkOrder objWO = new DL.AssetWorkOrder();
            DataSet ds = objWO.AssetWorkOrderInfoGet(locationAutoId, clientCode, asmtId, WoStatus);
            return ds;
        }

        public DataSet AssetWorkOrderDetailGet(string locationAutoId, string assetWoNo, string assetWoAmendNo, string asmtId)
        {

            DL.AssetWorkOrder objWO = new DL.AssetWorkOrder();
            DataSet ds = objWO.AssetWorkOrderDetailGet(locationAutoId, assetWoNo, assetWoAmendNo, asmtId);
            return ds;
        }

        public DataSet AssetWorkOrderDetailGet(string locationAutoId, string assetWoNo, string assetWoAmendNo)
        {
            DL.AssetWorkOrder objWO = new DL.AssetWorkOrder();
            DataSet ds = objWO.AssetWorkOrderDetailGet(locationAutoId, assetWoNo, assetWoAmendNo, string.Empty);
            return ds;
        }
        #endregion

        #region Asset WorkOrder Details
        public DataSet AssetWOMasterUpdate(string locationAutoId, string assetWoNo, string assetWoAmendNo, string wefDate, string clientCode, string woStatus, string woTerminationDate, string woTerminationReason, string woTerminatedBy, string asmtBillingId, string modifiedBy, string myStatus, string invoiceType, string remarks)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetWOMasterUpdate(locationAutoId, assetWoNo, assetWoAmendNo, wefDate, clientCode, woStatus, woTerminationDate, woTerminationReason, woTerminatedBy, asmtBillingId, modifiedBy, myStatus, invoiceType, remarks);
            return ds;
        }

        public DataSet AssetWOMasterSave(string locationAutoId, string wefDate, string clientCode, string woStatus, string woTerminationDate, string woTerminationReason, string woTerminatedBy, string asmtBillingId, string modifiedBy, string invoiceType, string remarks)
        {

            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetWOMasterSave(locationAutoId, wefDate, clientCode, woStatus, woTerminationDate, woTerminationReason, woTerminatedBy, asmtBillingId, modifiedBy, invoiceType, remarks);
            return ds;
        }

        public DataSet AssetWorkOrderAmendNoGet(string locationAutoId, string assetWoNo)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetWorkOrderAmendNoGet(locationAutoId, assetWoNo);
            return ds;
        }

        public DataSet AssetWorkOrderGet(string locationAutoId, string assetWoNo, string assetWoAmendNo)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetWorkOrderGet(locationAutoId, assetWoNo, assetWoAmendNo);
            return ds;
        }

        public DataSet AssetWorkOrderAmend(string locationAutoId, string assetWoNo, string woStatus, string modifiedBy, string myStatus, string wefDate)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetWorkOrderAmend(locationAutoId, assetWoNo, woStatus, modifiedBy, myStatus, wefDate);
            return ds;
        }

        public DataSet AssetWorkOrderAuthorized(string locationAutoId, string assetWoNo, string assetWoAmendNo, string woStatus, string modifiedBy, string myStatus)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetWorkOrderAuthorized(locationAutoId, assetWoNo, assetWoAmendNo, woStatus, modifiedBy, myStatus);
            return ds;
        }

        public DataSet PostAssetsGet(string postAutoId)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.PostAssetsGet(postAutoId);
            return ds;
        }

        public DataSet AssetsServiceTypeGet(string assetAutoId,string LocationAutoID)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetsServiceTypeGet(assetAutoId, LocationAutoID);
            return ds;
        }

        public DataSet WorkOrderDetailAddNew(string locationAutoId, string assetWONo, string assetWOAmendNo, string contractNumber, string asmtId, string postAutoId,
           string assetAutoId, string assetServiceTypeAutoId, string woLineStartDate, string woLineEndDate, string woLineWEFDate, bool billable, bool active,
           double rate, double monthlyBilling, string remarks, string modifiedBy)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.WorkOrderDetailAddNew(locationAutoId, assetWONo, assetWOAmendNo, contractNumber, asmtId, postAutoId, assetAutoId, assetServiceTypeAutoId,
                                                                woLineStartDate, woLineEndDate, woLineWEFDate, billable, active, rate, monthlyBilling, remarks, modifiedBy);
            return ds;
        }

        public DataSet AssetWorkOrderDetailsDelete(string assetWoNo, string assetWoAmendNo, string assetWoLineNo)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetWorkOrderDetailsDelete(assetWoNo, assetWoAmendNo, assetWoLineNo);
            return ds;
        }

        public DataSet AssetWODetailsMaximumAuthorizedWEFDateGet(string assetWONo, int assetWOLineNo, int locationAutoId)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.AssetWODetailsMaximumAuthorizedWEFDateGet(assetWONo, assetWOLineNo, locationAutoId);
            return ds;
        }

        public DataSet WorkOrderDetailUpdate(string locationAutoId, string assetWoNo, string assetWoAmendNo, string assetWoLineNo,
           string contractNumber, string asmtId, string postAutoId, string assetAutoId, string assetServiceTypeAutoId, string woLineStartDate,
           string woLineEndDate, string woLineWEFDate, bool billable, bool active, double rate, double monthlyBilling,
           string remarks, string modifiedBy, string statusFresh)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.WorkOrderDetailUpdate(locationAutoId, assetWoNo, assetWoAmendNo, assetWoLineNo,
                                                    contractNumber, asmtId, postAutoId, assetAutoId, assetServiceTypeAutoId, 
                                                    woLineStartDate, woLineEndDate, woLineWEFDate, billable, active, rate, 
                                                    monthlyBilling, remarks, modifiedBy, statusFresh);
            return ds;
        }

        public DataSet WoLineDeptHeaderInfoGet(string assetWoNo, string assetWoAmendNo, string AssetWoLineNo)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.WoLineDeptHeaderInfoGet(assetWoNo, assetWoAmendNo, AssetWoLineNo);
            return ds;
        }

        public DataSet WoLineDeptInfoGet(string assetWoNo, string assetWoAmendNo, string AssetWoLineNo)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.WoLineDeptInfoGet(assetWoNo, assetWoAmendNo, AssetWoLineNo);
            return ds;
        }

        public DataSet WoLineServiceSchSave(string assetWONo, string assetWOAmendNo, string assetWOLineNo, string woStatus, string shiftCode, 
            string frequency, string monthNumbers, string monthDays, string weekNos, string weekDays, string fromTime, 
            string toTime, string modifiedBy)
        {
            DL.AssetWorkOrder objAssetWorkOrder = new DL.AssetWorkOrder();
            DataSet ds = objAssetWorkOrder.WoLineServiceSchSave(assetWONo, assetWOAmendNo, assetWOLineNo, woStatus, shiftCode, frequency, monthNumbers, monthDays, weekNos, weekDays, fromTime, toTime, modifiedBy);
            return ds;
        }
        #endregion Asset WorkOrder Details
    }
}
