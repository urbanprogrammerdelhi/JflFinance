using System;
using System.Data;
using System.Data.SqlClient;

namespace DL
{
    [CLSCompliantAttribute(false)]
    public class AssetManagement
    {
        #region Function Related to AssetManufacturer

        /// <summary>
        /// To get All the data from AssetManufacturer
        /// </summary>
        /// <returns>Dataset Message with ManufacturerName,ManufacturerEmail,ManufacturerPhone,ManufacturerAddress</returns>
        public DataSet AssetManufacturerGetRecords(string CompanyCode, int LocationAutoID)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset("udpMstAssetManufacturerGetAll", objParam);
            return ds;
        }

        /// <summary>
        /// To Insert the data of AssetManufacturer
        /// </summary>
        /// <param name="manufacturerName">ManufacturerName</param>
        /// <param name="manufacturerEmail">ManufacturerEmail</param>
        /// <param name="manufacturerPhone">ManufacturerPhone</param>
        /// <param name="manufacturerAddress">ManufacturerAddress</param>
        /// <param name="modifiedBy">modifiedBy</param>
        /// <returns>Dataset Message with ManufacturerName,ManufacturerEmail,ManufacturerPhone,ManufacturerAddress </returns>
        public DataSet AssetManufacturerAddNew(string manufacturerName, string manufacturerEmail, string manufacturerPhone, string manufacturerAddress, string modifiedBy, string CompanyCode, int LocationAutoID)
        {
            var objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.ManufacturerName, manufacturerName);
            objParam[1] = new SqlParameter(Properties.Resources.ManufacturerEmail, manufacturerEmail);
            objParam[2] = new SqlParameter(Properties.Resources.ManufacturerPhone, manufacturerPhone);
            objParam[3] = new SqlParameter(Properties.Resources.ManufacturerAddress, manufacturerAddress);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[6] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            var addStatus = SqlHelper.ExecuteDataset("udpMstAssetManufacturerInsert", objParam);
            return addStatus;

        }

        /// <summary>
        /// To Update the data of AssetManufacturer
        /// </summary>
        /// <param name="ManufacturerName">ManufacturerName</param>
        /// <param name="ManufacturerEmail">ManufacturerEmail</param>
        /// <param name="ManufacturerPhone">ManufacturerPhone</param>
        /// <param name="ManufacturerAddress">ManufacturerAddress</param>
        /// <param name="modifiedBy">modifiedBy</param>
        /// <returns>Dataset Message with ManufacturerName,ManufacturerEmail,ManufacturerPhone,ManufacturerAddress </returns>
        public DataSet AssetManufacturerUpdateRecords(string ManufacturerName, string ManufacturerEmail, string ManufacturerPhone, string ManufacturerAddress, string modifiedBy, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.ManufacturerName, ManufacturerName);
            objParam[1] = new SqlParameter(Properties.Resources.ManufacturerEmail, ManufacturerEmail);
            objParam[2] = new SqlParameter(Properties.Resources.ManufacturerPhone, ManufacturerPhone);
            objParam[3] = new SqlParameter(Properties.Resources.ManufacturerAddress, ManufacturerAddress);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[6] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstAssetManufacturerUpdate", objParam);
            return updateStatus;

        }

        /// <summary>
        /// To Delete Data from AssetManufacturer
        /// </summary>
        /// <param name="ManufacturerAutoID">ManufacturerAutoID</param>
        /// <returns>Dataset Message String</returns>
        public DataSet AssetManufacturerDelete(string ManufacturerAutoID, string CompanyCode, int LocationAutoID)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.ManufacturerAutoID, Convert.ToInt32(ManufacturerAutoID));
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMstAssetManufacturerDelete", objParam);
            return deleteStatus;

        }
        #endregion

        # region Function related to Asset Category
        public DataSet AssetCategoryInsert(int ID, string CategoryName, string ModifiedBy, string CompanyCode, int LocationAutoID)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.AssetCategoryName, CategoryName);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[4] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetCategoryInsert", objParam);
            return ds;
        }
        public DataSet AssetCategoryDelete(int ID, string CompanyCode, int LocationAutoID)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetCategoryDelete", objParam);
            return ds;
        }
        public DataSet AssetCategoryDetailGet(string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetCategoryDetailGet", objParam);
            return ds;
        }
        #endregion

        # region function related to Asset Sub Category
        public DataSet AssetSubCategoryDetailGet(int ID, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetSubCategoryDetailGet", objParam);
            return ds;
        }
        public DataSet AssetSubCategoryInsert(int ID, int CategoryId, string SubCategoryName, string ModifiedBy, string CompanyCode, int LocationAutoID)
        {

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.AssetSubCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.AssetCategoryId, CategoryId);
            objParam[2] = new SqlParameter(Properties.Resources.AssetSubCategoryName, SubCategoryName);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[5] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetSubCategoryInsert", objParam);
            return ds;
        }
        public DataSet AssetSubCategoryDelete(int ID, string CompanyCode, int LocationAutoID)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetSubCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetSubCategoryDelete", objParam);
            return ds;
        }
        #endregion

        # region function related to Asset Master
        //public DataSet AssetMasterDetailGet(string CompanyCode, int LocationAutoID)
        //{
        //    SqlParameter[] objParam = new SqlParameter[2];
        //    objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
        //    objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);

        //    DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailGet", objParam);
        //    return ds;
        //}
        public DataSet AssetMasterDetailGet(string CompanyCode, int LocationAutoID, string BaseUserID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            objParam[2] = new SqlParameter(Properties.Resources.BaseUserID, BaseUserID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailGet", objParam);
            return ds;
        }
        public DataSet AssetManufactureDetailGet(string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetManufactureDetailGet", objParam);
            return ds;
        }
        public DataSet AssetMasterDetailForUpdate(string AssetId, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailForUpdate", objParam);
            return ds;
        }
        public DataSet AssetMasterDetailInsert(string AssetCode, string AssetName, string AssetCategory, string AssetSubCategory, string AssetManufacture, string ModelNo, string ModelName, string SerialNo, string Description, string AssetOwner, string TagID, string Remarks, string IsActive, string Inactivewef, string Activewef, string status, string Condition, string ImageUrl, string MgmtGuideline, string ModifiedBy, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[22];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCode, AssetCode);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[2] = new SqlParameter(Properties.Resources.AssetCategoryId, AssetCategory);
            objParam[3] = new SqlParameter(Properties.Resources.AssetSubCategoryId, AssetSubCategory);
            objParam[4] = new SqlParameter(Properties.Resources.AssetManufactureId, AssetManufacture);
            objParam[5] = new SqlParameter(Properties.Resources.ModelNo, ModelNo);
            objParam[6] = new SqlParameter(Properties.Resources.ModelName, ModelName);
            objParam[7] = new SqlParameter(Properties.Resources.SerialNo, SerialNo);
            objParam[8] = new SqlParameter(Properties.Resources.Description, Description);
            objParam[9] = new SqlParameter(Properties.Resources.AssetOwner, AssetOwner);
            objParam[10] = new SqlParameter(Properties.Resources.TagId, TagID);
            objParam[11] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[12] = new SqlParameter(Properties.Resources.IsActive, IsActive);
            objParam[13] = new SqlParameter(Properties.Resources.Inactivewef, Inactivewef);
            objParam[14] = new SqlParameter(Properties.Resources.Activewef, Activewef);
            objParam[15] = new SqlParameter(Properties.Resources.Status, status);
            objParam[16] = new SqlParameter(Properties.Resources.Condition, Condition);
            objParam[17] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[18] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[19] = new SqlParameter(Properties.Resources.ManagementGuideline, MgmtGuideline);
            objParam[20] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[21] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailInsert", objParam);
            return ds;
        }
        public DataSet AssetMasterImageUpload(string AssetId, string ImageUrl, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterImageUpload", objParam);
            return ds;
        }
        public DataSet AssetMasterDetailUpdate(int AssetAutoId, string AssetCode, string AssetName, string AssetCategory, string AssetSubCategory, string AssetManufacture, string ModelNo, string ModelName, string SerialNo, string Description, string AssetOwner, string TagID, string Remarks, string IsActive, string Inactivewef, string Activewef, string status, string Condition, string ImageUrl, string MgmtGuideline, string ModifiedBy, string CompanyCode, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[23];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCode, AssetCode);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[2] = new SqlParameter(Properties.Resources.AssetCategoryId, AssetCategory);
            objParam[3] = new SqlParameter(Properties.Resources.AssetSubCategoryId, AssetSubCategory);
            objParam[4] = new SqlParameter(Properties.Resources.AssetManufactureId, AssetManufacture);
            objParam[5] = new SqlParameter(Properties.Resources.ModelNo, ModelNo);
            objParam[6] = new SqlParameter(Properties.Resources.ModelName, ModelName);
            objParam[7] = new SqlParameter(Properties.Resources.SerialNo, SerialNo);
            objParam[8] = new SqlParameter(Properties.Resources.Description, Description);
            objParam[9] = new SqlParameter(Properties.Resources.AssetOwner, AssetOwner);
            objParam[10] = new SqlParameter(Properties.Resources.TagId, TagID);
            objParam[11] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[12] = new SqlParameter(Properties.Resources.IsActive, IsActive);
            objParam[13] = new SqlParameter(Properties.Resources.Inactivewef, Inactivewef);
            objParam[14] = new SqlParameter(Properties.Resources.Activewef, Activewef);
            objParam[15] = new SqlParameter(Properties.Resources.Status, status);
            objParam[16] = new SqlParameter(Properties.Resources.Condition, Condition);
            objParam[17] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[18] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[19] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[20] = new SqlParameter(Properties.Resources.ManagementGuideline, MgmtGuideline);
            objParam[21] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[22] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailUpdate", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Lease
        public DataSet AssetLeaseDetailGet(string AssetId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDetailGet", objParam);
            return ds;
        }

        public DataSet AssetLeaseInsert(int LeaseId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string typeOfLease, string leaseStartDate, string leaseEndDate, decimal leaseAmount, string remarks, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(Properties.Resources.LeaseAutoId, LeaseId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, assetName);
            objParam[2] = new SqlParameter(Properties.Resources.Name, firmName);
            objParam[3] = new SqlParameter(Properties.Resources.Email, firmEmail);
            objParam[4] = new SqlParameter(Properties.Resources.Phone, firmPhone);
            objParam[5] = new SqlParameter(Properties.Resources.Address, firmAddress);
            objParam[6] = new SqlParameter(Properties.Resources.LeaseType, typeOfLease);
            objParam[7] = new SqlParameter(Properties.Resources.EndDate, Common.DateFormat(leaseEndDate, true));
            objParam[8] = new SqlParameter(Properties.Resources.Amount, leaseAmount);
            objParam[9] = new SqlParameter(Properties.Resources.Remarks, remarks);
            objParam[10] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[11] = new SqlParameter(Properties.Resources.StartDate, Common.DateFormat(leaseStartDate, true));

            objParam[12] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDetailInsert", objParam);
            return ds;
        }
        public DataSet AssetLeaseDelete(int LeaseId, string DocType, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.LeaseAutoId, LeaseId);
            objParam[1] = new SqlParameter(Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDelete", objParam);
            return ds;
        }
        public DataSet AssetLeaseUpdate(int LeaseId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string typeOfLease, string leaseStartDate, string leaseEndDate, decimal leaseAmount, string remarks, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(Properties.Resources.LeaseAutoId, LeaseId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, assetName);
            objParam[2] = new SqlParameter(Properties.Resources.Name, firmName);
            objParam[3] = new SqlParameter(Properties.Resources.Email, firmEmail);
            objParam[4] = new SqlParameter(Properties.Resources.Phone, firmPhone);
            objParam[5] = new SqlParameter(Properties.Resources.Address, firmAddress);
            objParam[6] = new SqlParameter(Properties.Resources.LeaseType, typeOfLease);
            objParam[7] = new SqlParameter(Properties.Resources.EndDate, Common.DateFormat(leaseEndDate, true));
            objParam[8] = new SqlParameter(Properties.Resources.Amount, leaseAmount);
            objParam[9] = new SqlParameter(Properties.Resources.Remarks, remarks);
            objParam[10] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[11] = new SqlParameter(Properties.Resources.StartDate, Common.DateFormat(leaseStartDate, true));
            objParam[12] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDetailUpdate", objParam);
            return ds;
        }
        #endregion Function related to Asset Lease

        #region Function related to AssetInsurance
        public DataSet AssetInsuranceGetRecords(string AssetId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetInsuranceDetailGet", objParam);
            return ds;
        }
        public DataSet AssetInsuranceAddNew(string AssetName, string PolicyNo, decimal SumInsured, string InsuranceCompanyName, string Email, string Phone, string InsurancePeriodFrom, string InsurancePeriodTo, string modifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(Properties.Resources.AssetName, Convert.ToInt32(AssetName));
            objParam[1] = new SqlParameter(Properties.Resources.PolicyNo, PolicyNo);
            objParam[2] = new SqlParameter(Properties.Resources.SumInsured, SumInsured);
            objParam[3] = new SqlParameter(Properties.Resources.InsuranceCompanyName, InsuranceCompanyName);
            objParam[4] = new SqlParameter(Properties.Resources.Email, Email);
            objParam[5] = new SqlParameter(Properties.Resources.Phone, Phone);
            objParam[6] = new SqlParameter(Properties.Resources.InsurancePeriodFrom, Common.DateFormat(InsurancePeriodFrom, true));
            objParam[7] = new SqlParameter(Properties.Resources.InsurancePeriodTo, Common.DateFormat(InsurancePeriodTo, true));
            objParam[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[9] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstAssetInsuranceInsert", objParam);
            return addStatus;
        }
        public DataSet AssetInsuranceUpdate(int AssetInsuranceAutoId, decimal SumInsured, string InsuranceCompanyName, string Email, string PhoneNo, string InsurancePeriodFrom, string InsurancePeriodTo, string modifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.AssetInsuranceAutoId, AssetInsuranceAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.SumInsured, SumInsured);
            objParam[2] = new SqlParameter(Properties.Resources.InsuranceCompanyName, InsuranceCompanyName);
            objParam[3] = new SqlParameter(Properties.Resources.Email, Email);
            objParam[4] = new SqlParameter(Properties.Resources.Phone, PhoneNo);
            objParam[5] = new SqlParameter(Properties.Resources.InsurancePeriodFrom, Common.DateFormat(InsurancePeriodFrom));
            objParam[6] = new SqlParameter(Properties.Resources.InsurancePeriodTo, Common.DateFormat(InsurancePeriodTo));
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[8] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstAssetInsuranceUpdate", objParam);
            return updateStatus;
        }
        public DataSet AssetInsuranceDelete(int AssetInsuranceAutoId, string DocType, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetInsuranceAutoId, AssetInsuranceAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetInsuranceDelete", objParam);
            return ds;
        }
        #endregion Function related to AssetInsurance

        #region Function related to AssetGurantee
        public DataSet AssetGuranteeGetRecords(string AssetId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetGuranteeDetailGet", objParam);
            return ds;
        }
        public DataSet AssetGuranteeAddNew(string AssetName, string GuranteeExpDate, string modifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetName, Convert.ToInt32(AssetName));
            objParam[1] = new SqlParameter(Properties.Resources.GuranteeExpDate, Common.DateFormat(GuranteeExpDate, true));
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstGuranteeInsert", objParam);
            return addStatus;
        }
        public DataSet AssetGuranteeUpdate(int AssetGuarantyAutoId, string GuranteeExpDate, string modifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetGuarantyAutoId, AssetGuarantyAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.GuranteeExpDate, Common.DateFormat(GuranteeExpDate));
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstAssetGuranteeUpdate", objParam);
            return updateStatus;
        }
        public DataSet AssetGuranteeDelete(int AssetGuarantyAutoId, string DocType, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetGuarantyAutoId, AssetGuarantyAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetGuranteeDelete", objParam);
            return ds;
        }
        #endregion Function related to AssetGurantee

        #region Function related to AssetWarrenty
        public DataSet AssetWarrentyGetRecords(string AssetId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetWarrentyDetailGet", objParam);
            return ds;
        }
        public DataSet AssetWarrentyAddNew(string AssetName, string WarrentyExpDate, string modifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetName, Convert.ToInt32(AssetName));
            objParam[1] = new SqlParameter(Properties.Resources.WarrentyExpDate, Common.DateFormat(WarrentyExpDate, true));
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstWarrentyInsert", objParam);
            return addStatus;
        }
        public DataSet AssetWarrentyUpdate(int AssetWarrentyAutoId, string WarrentyExpDate, string modifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetWarrentyAutoId, AssetWarrentyAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.WarrentyExpDate, DL.Common.DateFormat(WarrentyExpDate));
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstAssetWarrentyUpdate", objParam);
            return updateStatus;
        }
        public DataSet AssetWarrentyDelete(int AssetWarrentyAutoId, string DocType, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetWarrentyAutoId, AssetWarrentyAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWarrentyDelete", objParam);
            return ds;
        }
        #endregion Function related to AssetWarrenty

        #region Function related to Asset Purchase
        public DataSet AssetLeaseDeleteAfterPurchaseInsert(int AssetId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDeleteAfterPurchaseDetail", objParam);
            return ds;
        }
        public DataSet AssetPurchaseDetail(string AssetId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetPurchaseDetail", objParam);
            return ds;
        }
        public DataSet AssetPurchaseDetailUpdate(int AssetAutoId, string CompanyName, string OrderNo, string OrderDate, decimal Price, string SupplierName, string SupplierEmail, string SupplierPhone, string SupplierAddress, string Remarks, string ImageUrl, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyName, CompanyName);
            objParam[2] = new SqlParameter(Properties.Resources.OrderNo, OrderNo);
            objParam[3] = new SqlParameter(Properties.Resources.OrderDate, Common.DateFormat(OrderDate, true));
            objParam[4] = new SqlParameter(Properties.Resources.Price, Price);
            objParam[5] = new SqlParameter(Properties.Resources.SupplierName, SupplierName);
            objParam[6] = new SqlParameter(Properties.Resources.SupplierEmail, SupplierEmail);
            objParam[7] = new SqlParameter(Properties.Resources.SupplierPhone, SupplierPhone);
            objParam[8] = new SqlParameter(Properties.Resources.SupplierAddress, SupplierAddress);
            objParam[9] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[10] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[11] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[12] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetPurchaseDetailUpdate", objParam);
            return ds;
        }
        public DataSet AssetPurchaseDetailInsert(int AssetAutoId, string CompanyName, string OrderNo, string OrderDate, decimal Price, string SupplierName, string SupplierEmail, string SupplierPhone, string SupplierAddress, string Remarks, string ImageUrl, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyName, CompanyName);
            objParam[2] = new SqlParameter(Properties.Resources.OrderNo, OrderNo);
            objParam[3] = new SqlParameter(Properties.Resources.OrderDate, Common.DateFormat(OrderDate, true));
            objParam[4] = new SqlParameter(Properties.Resources.Price, Price);
            objParam[5] = new SqlParameter(Properties.Resources.SupplierName, SupplierName);
            objParam[6] = new SqlParameter(Properties.Resources.SupplierEmail, SupplierEmail);
            objParam[7] = new SqlParameter(Properties.Resources.SupplierPhone, SupplierPhone);
            objParam[8] = new SqlParameter(Properties.Resources.SupplierAddress, SupplierAddress);
            objParam[9] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[10] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[11] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[12] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetPurchaseDetailInsert", objParam);
            return ds;
        }
        #endregion  Function related to Asset Purchase

        #region function related to Document Upload
        public DataSet AssetDocumentInsert(string category, int AssetAutoId, string DocDesc, string DocPath, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.Catagory, category);
            objParam[1] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.DocumentDesc, DocDesc);
            objParam[3] = new SqlParameter(Properties.Resources.DocumentFileName, DocPath);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDocumentInsert", objParam);
            return ds;
        }
        public DataSet AssetDocumentDetail(int AutoID, string Category, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AutoID);
            objParam[1] = new SqlParameter(Properties.Resources.Catagory, Category);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDocumentDetailGet", objParam);
            return ds;
        }
        public DataSet AssetDocumentDelete(int ID, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, ID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDocumentDelete", objParam);
            return ds;
        }
        public DataSet GetAssetDocumentsDetail(int AutoId, String Doctype, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AutoId);
            objParam[1] = new SqlParameter(Properties.Resources.type, Doctype);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDocumentDetailGetForDeletion", objParam);
            return ds;
        }
        #endregion function related to Document Upload

        #region Function Related to AssetPart
        public DataSet AssetManufacturerNameDetailGet(string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetManufacturerNameDetailGet", objParam);
            return ds;
        }
        public DataSet AssetNameDetailGet(int AssetSubCategory, int AssetManufacturer, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetSubCategoryAutoId, AssetSubCategory);
            objParam[1] = new SqlParameter(Properties.Resources.ManufacturerAutoID, AssetManufacturer);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNameDetailGet", objParam);
            return ds;
        }
        public DataSet AssetModelNoGet(int SubCategoryAutoId, int ManufacturerAutoId, string AssetName, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetSubCategoryAutoId, SubCategoryAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.ManufactureAutoId, ManufacturerAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[4] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetModelNoGet", objParam);
            return ds;
        }
        public DataSet AssetPartGetRecords(string CompanyCode, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetPartDetailGet", objParam);
            return ds;
        }
        public DataSet AssetPartAddNew(int AssetCategory, int AssetSubCategory, int ManufacturerName, string AssetName, string ModelNo, string AssetPartNo, string AssetPartName, int AssetPartQuantity, string modifiedBy, string CompanyCode, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCategoryAutoId, AssetCategory);
            objParam[1] = new SqlParameter(Properties.Resources.AssetSubCategoryAutoId, AssetSubCategory);
            objParam[2] = new SqlParameter(Properties.Resources.ManufacturerAutoID, ManufacturerName);
            objParam[3] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[4] = new SqlParameter(Properties.Resources.ModelNo, ModelNo);
            objParam[5] = new SqlParameter(Properties.Resources.AssetPartNo, AssetPartNo);
            objParam[6] = new SqlParameter(Properties.Resources.AssetPartName, AssetPartName);
            objParam[7] = new SqlParameter(Properties.Resources.AssetPartQuantity, Convert.ToInt32(AssetPartQuantity));
            objParam[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[9] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[10] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetPartInsert", objParam);
            return addStatus;
        }
        public DataSet AssetPartUpdate(int AssetPartsAutoId, string AssetPartNo, string AssetPartName, int AssetPartQuantity, string modifiedBy, string CompanyCode, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.AssetPartsAutoId, AssetPartsAutoId);

            objParam[1] = new SqlParameter(Properties.Resources.AssetPartNo, AssetPartNo);
            objParam[2] = new SqlParameter(Properties.Resources.AssetPartName, AssetPartName);
            objParam[3] = new SqlParameter(Properties.Resources.AssetPartQuantity, AssetPartQuantity);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[6] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetPartUpdate", objParam);
            return ds;
        }
        public DataSet AssetPartDelete(int AssetPartsAutoId, string CompanyCode, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetPartsAutoId, AssetPartsAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetPartsDelete", objParam);
            return ds;
        }

        #endregion Function Related to AssetPart

        #region Function Related to AssetServiceType
        public DataSet AssetServiceTypeGetRecords(string CompanyCode, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetServiceGet", objParam);
            return ds;
        }
        public DataSet AssetServiceTypeAddNew(string AssetName, string AssetServiceTypename, string modifiedBy, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[1] = new SqlParameter(Properties.Resources.AssetServiceTypeName, AssetServiceTypename);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[4] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetServiceTypeInsertRecord", objParam);
            return addStatus;
        }
        public DataSet AssetServiceTypeUpdate(int AssetServiceTypeAutoId, string AssetName, string AssetServiceTypename, string modifiedBy, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, AssetServiceTypeAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[2] = new SqlParameter(Properties.Resources.AssetServiceTypeName, AssetServiceTypename);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[5] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetServiceTypeUpdateRecords", objParam);
            return ds;

        }
        public DataSet AssetServiceForDelete(int AssetServiceTypeAutoId, string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, AssetServiceTypeAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetServiceTypeDeleteRecords", objParam);
            return ds;
        }
        public DataSet AssetNameDetailForServiceType(string CompanyCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNameForServiceType", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Service Checklist
        public DataSet AssetServiceTypeGet(int AssetId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetServiceTypeGet", objParam);
            return ds;
        }
        public DataSet AssetChecklistNameInsert(int AssetId, int ServiceAutoId, string ChecklistName, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, ServiceAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ChecklistName, ChecklistName);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetChecklistNameInsert", objParam);
            return ds;
        }
        public DataSet GetChecklistName(int AssetId, string ServiceAutoId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, ServiceAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpChecklistNameGet", objParam);
            return ds;
        }
       
        public DataSet GetChecklistNameItems(int ChecklistId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, ChecklistId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpGetChecklistItems", objParam);
            return ds;
        }
        public DataSet ChecklistItemNameInsert(int ChecklistId, string ItemName, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, ChecklistId);
            objParam[1] = new SqlParameter(Properties.Resources.ChecklistItem, ItemName);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetChecklistItemInsert", objParam);
            return ds;

        }
        public DataSet ChecklistItemNameUpdate(int ChecklistId, string ItemName, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, ChecklistId);
            objParam[1] = new SqlParameter(Properties.Resources.ChecklistItem, ItemName);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetChecklistItemUpdate", objParam);
            return ds;

        }
        public DataSet ChecklistItemNameDelete(int ChecklistId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, ChecklistId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetChecklistItemDelete", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Note
        public DataSet AssetNoteDetailGet(string AssetId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNoteDetailGet", objParam);
            return ds;
        }
        public DataSet AssetNoteInsert(string AssetId, string Towhom, string NoteType, string Note, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.ToWhom, Towhom);
            objParam[2] = new SqlParameter(Properties.Resources.NoteType, NoteType);
            objParam[3] = new SqlParameter(Properties.Resources.Note, Note);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNoteDetailInsert", objParam);
            return ds;
        }
        public DataSet AssetNoteUpdate(string AssetNoteAutoId, string AssetId, string Towhom, string NoteType, string Note, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.ToWhom, Towhom);
            objParam[2] = new SqlParameter(Properties.Resources.NoteType, NoteType);
            objParam[3] = new SqlParameter(Properties.Resources.Note, Note);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.AssetNoteAutoId, AssetNoteAutoId);
            objParam[6] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNoteDetailUpdate", objParam);
            return ds;
        }
        public DataSet AssetNoteDelete(string AssetNoteAutoId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetNoteAutoId, AssetNoteAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNoteDelete", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset AMC
        public DataSet AssetAMCDetailGet(string AssetId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetAMCDetailGet", objParam);
            return ds;
        }
        public DataSet AssetAMCInsert(string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string AMCType, string StartDate, string EndDate, decimal Amount, string Terms, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(StartDate, true));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetName, assetName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Name, firmName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Email, firmEmail);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Phone, firmPhone);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Address, firmAddress);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AMCType, AMCType);
            objParam[7] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(EndDate, true));
            objParam[8] = new SqlParameter(DL.Properties.Resources.Amount, Amount);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Terms, Terms);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[11] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetAMCDetailInsert", objParam);
            return ds;
        }
        public DataSet AssetAMCDelete(string AMCAutoId, string DocType, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AMCAutoId, AMCAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetAMCDelete", objParam);
            return ds;
        }
        public DataSet AssetAMCUpdate(string AMCAutoId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string AMCType, string StartDate, string EndDate, decimal Amount, string Terms, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AMCAutoId, AMCAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetName, assetName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Name, firmName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Email, firmEmail);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Phone, firmPhone);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Address, firmAddress);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AMCType, AMCType);
            objParam[7] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(StartDate, true));
            objParam[8] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(EndDate, true));
            objParam[9] = new SqlParameter(DL.Properties.Resources.Amount, Amount);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Terms, Terms);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[12] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetAMCDetailUpdate", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Client Mapping
        public DataSet AssetClientMappingInsert(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingInsert", objParam);
            return ds;
        }
        public DataSet AssetClientMappingGetRecords(string AssetId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetClientMappingDetail", objParam);
            return ds;
        }
        public DataSet AssetClientMappingUpdate(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingUpdate", objParam);
            return ds;
        }
        public DataSet AssetClientMappingDelete(int AssetAutoId, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingDelete", objParam);
            return ds;
        }
        #endregion
        # region function related to Ticket Master
        public DataSet GetAllTickets(string LocationAutoId, string Status, string TicketNo, string UserId, string Date, string ToDate, string BaseUserID)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, Status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TicketNo, TicketNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.UserId, UserId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.BaseUserID, BaseUserID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllAssetWorkOrder", objParam);
            return ds;
        }
         public DataSet GetAllTicketsMaster(string LocationAutoId, string Status, string TicketNo, string UserId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, Status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TicketNo, TicketNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.UserId, UserId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllAssetWorkOrderMaster", objParam);
            return ds;
        }
        public DataSet TicketDetail(string TicketNo, string LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.TicketNo, TicketNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetTicketDetailWeb", objParam);
            return ds;
        }
        public DataSet UpdateTicketStatus(string TicketNo, string Status, string LocationAutoId, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.TicketNo, TicketNo);
            objParam[1] = new SqlParameter(Properties.Resources.Status, Status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateTicketStatusWeb", objParam);
            return ds;
        }
        public DataSet GetEmployeeAttendence(string LocationAutoId, string Post, string Date, string EmployeeNo, string ToDate)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.PostAutoId, Post);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetEmployeeAttendenceWeb", objParam);
            return ds;
        }
        #endregion
        #region Function related to Task Master
        public DataSet GetClientCode(string LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetClientCodeWeb", objParam);
            return ds;
        }
        public DataSet GetAsmtId(string ClientCode, string LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetSiteIdWeb", objParam);
            return ds;
        }
        public DataSet GetPostCode(string ClientCode, string AsmtId, string LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetPostIdWeb", objParam);
            return ds;
        }
        public DataSet GetPerformerSiteDetails(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            //  objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetPerformerSiteDetailsWeb", objParam);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetUnsechedulledTask", objParam);
            return ds;
        }
        public DataSet GetDailyTaskDetail(string AutoId, string AsmtId, string LocationAutoID, string Date, string AssetAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, Convert.ToInt32(AutoId));
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[3] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[4] = new SqlParameter(Properties.Resources.AssetAutoId, Convert.ToInt32(AssetAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetDailyTaskUpdateWeb", objParam);
            return ds;
        }
        public DataSet GetDailyTaskDetailUnSchedulled(string AutoId, string AsmtId, string LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, Convert.ToInt32(AutoId));
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetDailyTaskUpdateUnschedulled", objParam);
            return ds;
        }
        public DataSet UpdateDailyTaskStatus(string AssetScheduleAutoId, string TaskName, string Status, string LocationAutoID, string UserId, string Date)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.AssetAutoId, Convert.ToInt32(AssetScheduleAutoId));
            objParam[1] = new SqlParameter(Properties.Resources.ChecklistItem, TaskName);
            objParam[2] = new SqlParameter(Properties.Resources.Status, Status);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ModifiedBy, UserId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateDailyTaskStatusWeb", objParam);
            return ds;
        }
        public DataSet GetDailyTaskImage(string CheckListItem, string LocationAutoID, string Date, string FromTime, string ToTime)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.ChecklistItem, CheckListItem);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[2] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[3] = new SqlParameter(Properties.Resources.FromTime, FromTime);
            objParam[4] = new SqlParameter(Properties.Resources.ToTime, ToTime);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetTaskImageWeb", objParam);
            return ds;
        }
        #endregion
        #region Function related to Asset Client Mapping
        public DataSet AssetClientMappingInsert(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy, string LocationTagging, string Path)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[8] = new SqlParameter(Properties.Resources.TagId, LocationTagging);
            objParam[9] = new SqlParameter(Properties.Resources.Image, Path);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingInsert", objParam);
            return ds;
        }
        public DataSet AssetClientMappingUpdate(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy, string LocationTagging)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[8] = new SqlParameter(Properties.Resources.TagId, LocationTagging);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingUpdate", objParam);
            return ds;
        }

        public DataSet GetAssetOwnerMapping(int LocationAutoId, int AssetAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAssetOwnerMappingOnTheBasisOfAssetId", objParam);
            return ds;
        }
        public DataSet OwnerAssetMappingInsert(int AssetId, string employeeNumber, string locationAutoId, string modifiedBy, string effectiveFrom, string EmpName, string AssetCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.FromDate, effectiveFrom);
            objParam[5] = new SqlParameter(Properties.Resources.Name, EmpName);
            objParam[6] = new SqlParameter(Properties.Resources.AssetCode, AssetCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetOwnerMappingInsert", objParam);
            return ds;
        }
        public DataSet OwnerAssetMappingDelete(string AssetId, string employeeNumber, string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetAutoId, Convert.ToInt32(AssetId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetOwnerMappingDelete", objParam);
            return ds;

        }

        public DataSet OwnerAssetMappingUpdate(string AssetId, string employeeNumber, string locationAutoId, string areaInchargeAutoId, string effectiveFrom, string effectiveTo, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetAutoId, Convert.ToInt32(AssetId));
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AutoId, Convert.ToInt32(areaInchargeAutoId));
            objParam[4] = new SqlParameter(DL.Properties.Resources.EffectiveFromDate, DL.Common.DateFormat(effectiveFrom));
            objParam[5] = new SqlParameter(DL.Properties.Resources.EffectiveToDate, DL.Common.DateFormat(effectiveTo));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetOwnerMappingUpdate", objParam);
            return ds;

        }
        public DataSet GetAllEmployeeByLocation(string employeeNumber, string employeeName, int locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Name, employeeName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAllEmployeeByLocation", objParam);
            return ds;
        }

        public DataSet AssetTransferInitiated(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Status, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Status, Status);
            objParam[6] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetTransferInitaited", objParam);
            return ds;
        }
        public DataSet AssetTransferUpdate(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy, string LocationTagging)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[8] = new SqlParameter(Properties.Resources.TagId, LocationTagging);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetTransferUpdate", objParam);
            return ds;
        }
        public DataSet AssetDiscardInitaite(int AssetAutoId, int LocationAutoId, string Value, string ModifiedBy, string Status)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);         
            objParam[2] = new SqlParameter(Properties.Resources.Price, Value);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.Status, Status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDiscardInitaited", objParam);
            return ds;
        }
        public DataSet AssetMasterDetailGetDiscarded(string CompanyCode, string Flag, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.Flag, Flag);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpassetmasterdetailgetDiscarded", objParam);
            return ds;
        }
        public DataSet AssetDiscardList(string LocationAutoID, string AssetCode, string AssetName, string FromDate, string ToDate, int Flag)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[1] = new SqlParameter(Properties.Resources.AssetCode, AssetCode);
            objParam[2] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[3] = new SqlParameter(Properties.Resources.FromDate, DL.Common.DateFormat(FromDate, true));
            objParam[4] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate, true));
            objParam[5] = new SqlParameter(Properties.Resources.Flag, Flag);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetDiscardedAsset", objParam);
            return ds;
        }
        public DataSet GetAssetdiscardDetail(int AssetAutoId, int LocationAutoId, string Status)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.Status, Status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDiscardDetail", objParam);
            return ds;
        }
        public DataSet AssetDiscardAuthorized(int AssetAutoId, int LocationAutoId, string Value, string ModifiedBy, string Status, string Date)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.Price, Value);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.Status, Status);
            objParam[5] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDiscard", objParam);
            return ds;
        }
        public DataSet GetPendingTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetPerformerSiteDetailsWeb", objParam);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetPendingTaskList", objParam);
            return ds;
        }
        public DataSet GetCompletedTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate, string Status)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[6] = new SqlParameter(Properties.Resources.Status, Status);
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetPerformerSiteDetailsWeb", objParam);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetCompletedTaskList", objParam);
            return ds;
        }

        public DataSet AssetGetQRPrint(string CompanyCode, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpGetQRPrint", objParam);
            return ds;
        }
        public DataSet TicketGeneration(string ClientName, string ClientCode, string AsmtName, string AsmtId, string summaryOfIssue, string Description, string Severity, string CommercialValue, string LocationAutoID, string BaseUserId, string AssetCategory, string AssetSubCategory, string AssetName, byte[] bytes)
        {
            SqlParameter[] objParam = new SqlParameter[14];
            objParam[0] = new SqlParameter(Properties.Resources.ClientName, ClientName);
            objParam[1] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[2] = new SqlParameter(Properties.Resources.AsmtName, AsmtName);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.SummaryOfIssues, summaryOfIssue);
            objParam[5] = new SqlParameter(Properties.Resources.Description, Description);
            objParam[6] = new SqlParameter(Properties.Resources.Severity, Severity);
            objParam[7] = new SqlParameter(Properties.Resources.CommercialValue, CommercialValue);
            objParam[8] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[9] = new SqlParameter(Properties.Resources.BaseUserID, BaseUserId);
            objParam[10] = new SqlParameter(Properties.Resources.AssetCategoryId, Convert.ToInt32(AssetCategory));
            objParam[11] = new SqlParameter(Properties.Resources.AssetSubCategoryId, Convert.ToInt32(AssetSubCategory));
            objParam[12] = new SqlParameter(Properties.Resources.AssetAutoId, Convert.ToInt32(AssetName));
            //if (bytes != null && bytes.Length > 0)
            //{
            //    objParam[13] = new SqlParameter(Properties.Resources.Image, (object)bytes);
            //}
            //else
            //{
            //    objParam[13] = new SqlParameter(Properties.Resources.Image, DBNull.Value);
            //}
            objParam[13] = new SqlParameter(Properties.Resources.Image, (object)bytes);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpTicketGeneration", objParam);
            return ds;
        }
        public DataSet GetCompanyDetails(string id)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, id);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetCompany", objParam);
            return ds;
        }
        public DataSet GetCategory(string id)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, id);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetCategory", objParam);
            return ds;
        }
        public DataSet GetSubCategory(int id)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetCategoryId, id);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetSubCategory", objParam);
            return ds;
        }
        public DataSet GetAsset(int id,int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetSubCategoryAutoId, id);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAsset", objParam);
            return ds;
        }

        public DataSet GetEmployeeDetail(string LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "GetEmployeeDetails", objParam);
            return ds;
        }

        public DataSet TicketScheduling(string TicketNo, string EmployeeNumber, string Clientcode, string AsmtId, string LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.TicketNo, TicketNo);
            objParam[1] = new SqlParameter(Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, Clientcode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoId));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpTicketScheduling", objParam);
            return ds;
        }
        public DataSet GetAllTicketsUnschedulled(string LocationAutoId, string Status, string TicketNo, string UserId, string Date, string ToDate, string BaseUserID)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, Status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TicketNo, TicketNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.UserId, UserId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.BaseUserID, BaseUserID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllAssetWorkOrderUnschedulled", objParam);
            return ds;
        }
        #endregion

        public DataSet TicketDetails(string LocationAutoId, string Date, string ToDate, string BaseUserID)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.BaseUserID, BaseUserID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetTicketDetais", objParam); 
            return ds;
        }
        #region function related to Graphical Dashboard
        public DataSet GetGraphTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate, string Status)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[6] = new SqlParameter(Properties.Resources.Status, Status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetGraphTaskList", objParam);
            return ds;
        }
        public DataSet GetGraphTasklistDetail(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string Status)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.Status, Status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetGraphTaskListDetails", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Sub Checklist
        public DataSet GetSubChecklistName(int Checklistid, int SubChecklistId, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, Checklistid);
            objParam[1] = new SqlParameter(Properties.Resources.SubChecklistAutoID, SubChecklistId);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpSubChecklistNameGet", objParam);
            return ds;
        }
        public DataSet SubChecklistItemNameInsert(int SubChecklistid, int Checklistid, string SubchecklistItem, string ValueType, string QuantitativeValueType, string MinValue, string MaxValue, string BaseUserID, string BaseCompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.SubChecklistAutoID, SubChecklistid);
            objParam[1] = new SqlParameter(Properties.Resources.CheckListAutoId, Checklistid);
            objParam[2] = new SqlParameter(Properties.Resources.SubchecklistItem, SubchecklistItem);
            objParam[3] = new SqlParameter(Properties.Resources.ValueType, ValueType);
            objParam[4] = new SqlParameter(Properties.Resources.QuantitativeValueType, QuantitativeValueType);
            objParam[5] = new SqlParameter(Properties.Resources.MinValue,  MinValue);
            objParam[6] = new SqlParameter(Properties.Resources.MaxValue,  MaxValue);
            objParam[7] = new SqlParameter(Properties.Resources.BaseUserID, BaseUserID);
            objParam[8] = new SqlParameter(Properties.Resources.CompanyCode, BaseCompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_SubChecklistIteminsert", objParam);
            return ds;
        }
        #endregion

        public DataSet SubChecklistItemNameDelete(int SubChecklistAutoID, string BaseCompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.SubChecklistAutoID, SubChecklistAutoID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, BaseCompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_SubChecklistItemDelete", objParam);
            return ds;
        }

        public DataSet SubChecklistItemNameUpdate(int SubChecklistAutoID, string subChecklistName, string ValueType, string Quantitativevaluetype, string Minvalue, string MaxValue, string BaseUserID, string BaseCompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.SubChecklistAutoID, SubChecklistAutoID);
            objParam[1] = new SqlParameter(Properties.Resources.SubchecklistItem, subChecklistName);
            objParam[2] = new SqlParameter(Properties.Resources.ValueType, ValueType);
            objParam[3] = new SqlParameter(Properties.Resources.QuantitativeValueType, Quantitativevaluetype);
            objParam[4] = new SqlParameter(Properties.Resources.MinValue, Minvalue);
            objParam[5] = new SqlParameter(Properties.Resources.MaxValue, MaxValue);
            objParam[6] = new SqlParameter(Properties.Resources.BaseUserID, BaseUserID);
            objParam[7] = new SqlParameter(Properties.Resources.CompanyCode, BaseCompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_SubChecklistItemUpdate", objParam);
            return ds;
        }

        public DataSet GetFromAssetServiceType(string BaseLocationAutoID, string AssetName)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(BaseLocationAutoID));
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetFromAssetServiceType", objParam);
            return ds;
        }

        public DataSet GetFromAssetCode(string BaseLocationAutoID, int AssetServiceTypeautoID,string AssetCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(BaseLocationAutoID));
            objParam[1] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, AssetServiceTypeautoID);
            objParam[2] = new SqlParameter(Properties.Resources.AssetCode, AssetCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetFromAssetCode", objParam);
            return ds;
        }

        public DataSet GetFromAssetChecklistName(int AssetServiceTypeautoID, int AssetAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];          
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, AssetServiceTypeautoID);
            objParam[1] = new SqlParameter(Properties.Resources.AssetAutoId, AssetAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetFromAssetChecklist", objParam);
            return ds;
        }

        public DataSet GetFromAssetSubChecklistName(int AssetChecklistAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCheckListAutoId, AssetChecklistAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetFromAssetSubChecklist", objParam);
            return ds;
        }

        public DataSet GetFromAssetItems(int AssetChecklistAutoID, int AssetChecklistDetailAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCheckListAutoId, AssetChecklistAutoID);
            objParam[1] = new SqlParameter(Properties.Resources.AutoId, AssetChecklistDetailAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetFromAssetItems", objParam);
            return ds;
        }

        public DataSet CopyAssetChecklist(string assetCode, string fromAssetCode, string assetServiceTypeAutoId, string assetChecklistAutoID, string assetSubChecklistAutoID, string BaseLocationAutoID, string ChecklistName, string subChecklistName)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCode, assetCode);
            objParam[1] = new SqlParameter(Properties.Resources.AutoId, fromAssetCode);
            objParam[2] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, Convert.ToInt32(assetServiceTypeAutoId));
            objParam[3] = new SqlParameter(Properties.Resources.AssetCheckListAutoId, Convert.ToInt32(assetChecklistAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.SubChecklistAutoID, Convert.ToInt32(assetSubChecklistAutoID));
            objParam[5] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(BaseLocationAutoID));
            objParam[6] = new SqlParameter(Properties.Resources.ChecklistItem, ChecklistName);
            objParam[7] = new SqlParameter(Properties.Resources.SubchecklistItem, subChecklistName);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CopyChecklistOfAsset", objParam);
            return ds;
        }

       public DataSet GetAssetTaggingDetails(string CompanyCode, int LocationAutoID, string BaseUserID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            objParam[2] = new SqlParameter(Properties.Resources.BaseUserID, BaseUserID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpGetTaggedAsset", objParam);
            return ds;
        }
          #region Function Related to Finance Report
        public DataSet GetAuditReport(int LocationAutoID, string ClientCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
           objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
           objParam[1] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
           DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetAuditReport", objParam);
            return ds;
        }
        #endregion
    
       #region Function related to Megha On call Order Page
       public DataSet SearchCustomer(string CustomerId, string LocationAutoID)
       {
           SqlParameter[] objParam = new SqlParameter[2];
           objParam[0] = new SqlParameter(Properties.Resources.ClientCode, CustomerId);
           objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
           DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetCustomerDetail", objParam);
           return ds;
       }      

       public DataSet InsertOrderOnCall(string ClientCode, string Name, string Address, string Mobile, string QueryType, string BaseLocationAutoID, string BaseUserID)
       {
           SqlParameter[] objParam = new SqlParameter[7];
           objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
           objParam[1] = new SqlParameter(Properties.Resources.Name, Name);
           objParam[2] = new SqlParameter(Properties.Resources.Address, Address);
           objParam[3] = new SqlParameter(Properties.Resources.Mobile, Mobile);
           objParam[4] = new SqlParameter(Properties.Resources.TypeOfService, QueryType);
           objParam[5] = new SqlParameter(Properties.Resources.BaseUserID, BaseUserID);
           objParam[6] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(BaseLocationAutoID));
           DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_InsertOrderManually", objParam);
           return ds;
       }

       #endregion
    }
}
