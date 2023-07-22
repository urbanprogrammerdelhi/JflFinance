// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="HRManagement.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Globalization;
/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class HRManagement.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class HRManagement
    {
        #region Function Related to EmployeeCategory
        #region Function Related to GetData
        /// <summary>
        /// Employees the category get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeCategoryGetAll(string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SomLocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeCategory_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// Employees the category update.
        /// </summary>
        /// <param name="previousCompanyCode">The previous company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="newEmployeeNumber">The new employee number.</param>
        /// <param name="previousCategoryCode">The previous category code.</param>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeCategoryUpdate(string previousCompanyCode, string employeeNumber, string newEmployeeNumber, string previousCategoryCode, string categoryCode, string effectiveTo, string userId, string newCompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[8];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.NewEmployeeNumber, newEmployeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PrevCategoryCode, previousCategoryCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.NewCategoryCode, categoryCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeCategory_Update", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to EmployeeDesignation
        #region Function Related to GetData
        /// <summary>
        /// Employees the designation get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDesignationGetAll(string companyCode, string hrLocationCode, string locationCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SomLocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeDesignation_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function related to Fill Department ComboBox Based on companyCode
        /// <summary>
        /// to Fill Department ComboBox Based on companyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset</returns>
        public DataSet DepartmentGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset("updMstHR_EmpInterCompanyTransfer_GetDepartment", objParam);
            return ds;

        }
        #endregion


        #region Function Related to Update Data
        /// <summary>
        /// Employees the designation update.
        /// </summary>
        /// <param name="previousCompanyCode">The previous company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="newEmployeeNumber">The new employee number.</param>
        /// <param name="previousDesignationCode">The previous designation code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDesignationUpdate(string previousCompanyCode, string employeeNumber, string newEmployeeNumber, string previousDesignationCode, string designationCode, string effectiveTo, string userId, string newCompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[8];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.NewEmployeeNumber, newEmployeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PrevDesignationCode, previousDesignationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.NewDesignationCode, designationCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeDesignation_Update", objParam);
            return ds;
        }
        #endregion

        #endregion
          #region Function related to Employee Grade
        public DataSet EmployeeGradeUpdate(string previousCompanyCode, string employeeNumber, string newEmployeeNumber, string previousDesignationCode, string designationCode, string effectiveTo, string userId, string newCompanyCode, string oldGradeCode, string GradeCode)
        {

            SqlParameter[] objParam = new SqlParameter[10];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.NewEmployeeNumber, newEmployeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PrevDesignationCode, previousDesignationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.NewDesignationCode, designationCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParam[8] = new SqlParameter(DL.Properties.Resources.OldGradeCode, oldGradeCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeGrade_Update", objParam);
            return ds;
        }

          #endregion

        #region Function Related to EmployeeHrLocation
        #region Get All Employees of HrLocation
        /// <summary>
        /// Get Employees of HrLocation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>EmployeeName,employeeNumber,Designation</returns>

        public DataSet EmployeesOfHRLocationGetAll(string companyCode, string hrLocationCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeesOfHrLocation_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// Employeeses the of hr location get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="onDate">The on date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesOfHRLocationGetAll(string companyCode, string hrLocationCode, string onDate)
        {

            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DateTime.Parse(onDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeesOnGivenDateOfHrLocation_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the area update.
        /// </summary>
        /// <param name="previousCompanyCode">The previous company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="previousAreaCode">The previous area code.</param>
        /// <param name="areaCode">The area code.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAreaUpdate(string previousCompanyCode, string employeeNumber, string previousAreaCode, string areaCode, string effectiveTo, string userId, string newCompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PrevAreaCode, previousAreaCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.NewAreaCode, areaCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeArea_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Fuction to get All employee List Based on Area Fro Scheduling/Rota
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesScheduleGet(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string areaId, string areaIncharge, string isAreaIncharge)
        {
            SqlParameter[] objParam = new SqlParameter[8];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[6] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeesWiseSchedule_GetAllEmployee", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related To Employee Role Details

        #region Function Related to Get Data
        /// <summary>
        /// TO Get ALL Employees Role of a Branch
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRoleGetAll(string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeRole_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update Employee Role in Table mstHrEmployeeStandardRole
        /// </summary>
        /// <param name="previousCompanyCode">The previous company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="newEmployeeNumber">The new employee number.</param>
        /// <param name="previousRoleCode">The previous role code.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRoleUpdate(string previousCompanyCode, string employeeNumber, string newEmployeeNumber, string previousRoleCode, string roleCode, string effectiveTo, string userId, string newCompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[8];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.NewEmployeeNumber, newEmployeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PrevRoleCode, previousRoleCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.NewRoleCode, roleCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeRole_Update", objParam);
            return ds;
        }

        #endregion

        #endregion

        #region Function Related to EmployeeLocation
        #region Function Related to GetData
        /// <summary>
        /// Employeeses the of location get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesOfLocationGetAll(string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SomLocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeLocation_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Employees based on Location
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesOfLocationGetAll(string locationCode, string hrLocationCode, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpReports_EmployeesOfLoaction_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Employees based on Location And Area
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesOfLocationAreaWiseGet(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string areaId, string areaIncharge, string isAreaIncharge)
        {
            SqlParameter[] objParam = new SqlParameter[8];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[6] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpReports_EmployeesOfLocationAreaWise_Get", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Employees based on Location And Area For Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesOfLocationAreaWiseGetForTraining(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string areaId, string areaIncharge, string isAreaIncharge)
        {
            SqlParameter[] objParam = new SqlParameter[8];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[6] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpReports_EmployeesOfLocationAreaWise_GetForTraining", objParam);
            return ds;
        }

        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// Employees the location update.
        /// </summary>
        /// <param name="previousCompanyCode">The previous company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="newEmployeeNumber">The new employee number.</param>
        /// <param name="futureLocationId">The future location identifier.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <param name="comment">The comment.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeLocationUpdate(string previousCompanyCode, string locationAutoId, string employeeNumber, string newEmployeeNumber, string futureLocationId, string effectiveTo, string userId, string newCompanyCode, string comment)
        {

            SqlParameter[] objParam = new SqlParameter[9];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.NewEmployeeNumber, newEmployeeNumber);
            objParam[5] = new SqlParameter(DL.Properties.Resources.FutureLocationID, futureLocationId);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Comment, comment);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeLocation_Update", objParam);
            return ds;
        }
        #endregion

        #endregion


        #region Function Related to EmployeeMaster

        #region Function Related to get Personal Details
        /// <summary>
        /// to get Personal Details
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet PersonalDetailsGet(string companyCode, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_PersonalDetails_GetAll", objParam);
            return ds;
        }
        #endregion
        #region Function Related to Insert Personal data
        /// <summary>
        /// to Insert Personal data
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="height">The height.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="maritalStatus">The marital status.</param>
        /// <param name="nationality">The nationality.</param>
        /// <param name="state">The state.</param>
        /// <param name="address">The address.</param>
        /// <param name="contactNumber">The contact number.</param>
        /// <param name="religion">The religion.</param>
        /// <param name="militaryStatus">The military status.</param>
        /// <param name="smoker">The smoker.</param>
        /// <param name="vegetarian">The vegetarian.</param>
        /// <param name="previousExperience">The previous experience.</param>
        /// <param name="dateOfJoining">The date of joining.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="jobClassCode">The job class code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="identificationNumber">The identification number.</param>
        /// <param name="identificationType">Type of the identification.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="oldEmployeeNumber">The old employee number.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="otherInformation">The other information.</param>
        /// <param name="wageRate">The wage rate.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="wageRateFrequency">The wage rate frequency.</param>
        /// <param name="paymentFrequency">The payment frequency.</param>
        /// <param name="contractHours">The contract hours.</param>
        /// <param name="contractHoursFrequency">The contract hours frequency.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="otherLanguageFirstName">First name of the other language.</param>
        /// <param name="otherLanguageLastName">Last name of the other language.</param>
        /// <param name="contractDays">The contract days.</param>
        /// <param name="otEntitlement">The ot entitlement.</param>
        /// <param name="otDate">The ot date.</param>
        /// <param name="status">The status.</param>
        /// <param name="statusDesc">The status desc.</param>
        /// <param name="statusDate">The status date.</param>
        /// <param name="scaleCode">The scale code.</param>
        /// <param name="scaleDesc">The scale desc.</param>
        /// <param name="Bloodgroup">Blood group</param>
        /// <param name="Disability">The Disability</param>
        /// <param name="Identificationmark">Identification Mark</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">otherInformation</exception>
        public DataSet PersonalDetailsInsert(string companyCode, DateTime dateOfBirth, string firstName, string lastName, string height, float weight, string gender, string maritalStatus, string nationality, string state, string address, string contactNumber, string religion, string militaryStatus, string smoker, string vegetarian, float previousExperience, DateTime dateOfJoining, string designationCode,string gradeCode, string categoryCode, string userId, string jobClassCode, string areaId, string jobTypeCode, string roleCode, string locationAutoId, string identificationNumber, string identificationType, string employeeNumber, string oldEmployeeNumber, string departmentCode, DataTable otherInformation, string wageRate, string currency, string wageRateFrequency, string paymentFrequency, float contractHours, string contractHoursFrequency, string modifiedBy, string otherLanguageFirstName, string otherLanguageLastName, string contractDays, string otEntitlement, string otDate, string status, string statusDesc, string statusDate, string scaleCode, string scaleDesc, string Bloodgroup, string Identificationmark, string Disability)
        {

            if (otherInformation == null || otherInformation.Rows == null)
            {
                throw new ArgumentNullException("otherInformation");
            }

            DataSet dsOtherInfo = new DataSet();
            dsOtherInfo.Locale = CultureInfo.InvariantCulture;
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            SqlParameter[] objParam = new SqlParameter[51];

            if (!String.IsNullOrEmpty(otDate))
                Guard.ArgumentValidDate(otDate, "myDateArgument");
            if (!String.IsNullOrEmpty(statusDate))
                Guard.ArgumentValidDate(otDate, "myDateArgument");

            Guard.ArgumentConvertibleTo<bool>(otEntitlement, "myBoolArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DOB, DL.Common.DateFormat(dateOfBirth));
            objParam[2] = new SqlParameter(DL.Properties.Resources.FirstName, firstName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.LastName, lastName);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Height, height);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Weight, weight);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Gender, gender);
            objParam[7] = new SqlParameter(DL.Properties.Resources.MaritalStatus, maritalStatus);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Nationality, nationality);
            objParam[9] = new SqlParameter(DL.Properties.Resources.State, state);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Address, address);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ContactNumber, contactNumber);
            objParam[12] = new SqlParameter(DL.Properties.Resources.Religion, religion);
            objParam[13] = new SqlParameter(DL.Properties.Resources.MilitaryStatus, militaryStatus);
            objParam[14] = new SqlParameter(DL.Properties.Resources.Smoker, smoker);
            objParam[15] = new SqlParameter(DL.Properties.Resources.Vegitarian, vegetarian);
            objParam[16] = new SqlParameter(DL.Properties.Resources.PrevExp, previousExperience);
            objParam[17] = new SqlParameter(DL.Properties.Resources.DOJ, DL.Common.DateFormat(dateOfJoining));
            objParam[18] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[19] = new SqlParameter(DL.Properties.Resources.CategoryCode, categoryCode);
            objParam[20] = new SqlParameter(DL.Properties.Resources.ModifierBy, userId);
            objParam[21] = new SqlParameter(DL.Properties.Resources.JobClassCode, jobClassCode);
            objParam[22] = new SqlParameter(DL.Properties.Resources.JobTypeCode, jobTypeCode);
            objParam[23] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParam[24] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[25] = new SqlParameter(DL.Properties.Resources.IdentificationNumber, identificationNumber);
            objParam[26] = new SqlParameter(DL.Properties.Resources.IdentificationType, identificationType);
            objParam[27] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[28] = new SqlParameter(DL.Properties.Resources.EmpNoOld, oldEmployeeNumber);
            objParam[29] = new SqlParameter(DL.Properties.Resources.DepartmentCode, departmentCode);
            objParam[30] = new SqlParameter(DL.Properties.Resources.wageRate, wageRate);
            objParam[31] = new SqlParameter(DL.Properties.Resources.CurrencyCode, currency);
            objParam[32] = new SqlParameter(DL.Properties.Resources.WageRateFrequency, wageRateFrequency);
            objParam[33] = new SqlParameter(DL.Properties.Resources.PaymentFrequency, paymentFrequency);
            objParam[34] = new SqlParameter(DL.Properties.Resources.contractHrs, contractHours);
            objParam[35] = new SqlParameter(DL.Properties.Resources.ContractHrsFrequency, contractHoursFrequency);
            objParam[36] = new SqlParameter(DL.Properties.Resources.OtherLangFirstName, otherLanguageFirstName);
            objParam[37] = new SqlParameter(DL.Properties.Resources.OtherLangLastName, otherLanguageLastName);
            objParam[38] = new SqlParameter(DL.Properties.Resources.ContractDays, contractDays);
            objParam[39] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[40] = new SqlParameter(DL.Properties.Resources.OTENTITLEMENT, bool.Parse(otEntitlement));
            objParam[41] = new SqlParameter(DL.Properties.Resources.OTDATE, DL.Common.DateFormat(otDate, true));
            objParam[42] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[43] = new SqlParameter(DL.Properties.Resources.STATUSDESC, statusDesc);
            objParam[44] = new SqlParameter(DL.Properties.Resources.STATUSDATE, DL.Common.DateFormat(statusDate, true));
            objParam[45] = new SqlParameter(DL.Properties.Resources.SCALECODE, scaleCode);
            objParam[46] = new SqlParameter(DL.Properties.Resources.SCALEDESC, scaleDesc);
            objParam[47] = new SqlParameter(DL.Properties.Resources.BloodGroup, Bloodgroup);
            objParam[48] = new SqlParameter(DL.Properties.Resources.IdentificationMark, Identificationmark);
            objParam[49] = new SqlParameter(DL.Properties.Resources.Disability, Disability);
            objParam[50] = new SqlParameter(DL.Properties.Resources.GradeCode, gradeCode);

            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpPersonalDetails_Insert", objParam);
                if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][DL.Properties.Resources.fldGeneratedCode].ToString()))
                    {
                        SqlParameter[] objOtherParam = new SqlParameter[9];

                        for (int i = 0; i < otherInformation.Rows.Count; i++)
                        {
                            objOtherParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, ds.Tables[0].Rows[0][DL.Properties.Resources.fldGeneratedCode].ToString());
                            objOtherParam[1] = new SqlParameter(DL.Properties.Resources.IDNumber, otherInformation.Rows[i][DL.Properties.Resources.fldIDNumber].ToString());
                            objOtherParam[2] = new SqlParameter(DL.Properties.Resources.IDType, otherInformation.Rows[i][DL.Properties.Resources.fldIDType].ToString());
                            objOtherParam[3] = new SqlParameter(DL.Properties.Resources.DateOfIssue, DL.Common.DateFormat(otherInformation.Rows[i][DL.Properties.Resources.fldDateOfIssue].ToString()));
                            objOtherParam[4] = new SqlParameter(DL.Properties.Resources.DateOfExpiry, DL.Common.DateFormat(otherInformation.Rows[i][DL.Properties.Resources.fldDateOfExpiry].ToString()));
                            objOtherParam[5] = new SqlParameter(DL.Properties.Resources.IssuingAuthority, otherInformation.Rows[i][DL.Properties.Resources.fldIssuingAuthority].ToString());
                            objOtherParam[6] = new SqlParameter(DL.Properties.Resources.PlaceOfBirth, otherInformation.Rows[i][DL.Properties.Resources.fldPlaceofBirth].ToString());
                            objOtherParam[7] = new SqlParameter(DL.Properties.Resources.Remarks, otherInformation.Rows[i][DL.Properties.Resources.fldRemarks].ToString());
                            objOtherParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                            dsOtherInfo = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpPassportDetails_Insert", objOtherParam);
                        }
                    }
                }

                tx.Complete();
            }

            if (otherInformation.Rows.Count > 0)
            {
                return dsOtherInfo;
            }
            else
            {
                return ds;
            }
        }

        /// <summary>
        /// Employees the additional detail insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="rate">The rate.</param>
        /// <param name="jobCode">The job code.</param>
        /// <param name="additionType">Type of the addition.</param>
        /// <param name="otDayCode">The ot day code.</param>
        /// <param name="otDayDesc">The ot day desc.</param>
        /// <param name="otNightCode">The ot night code.</param>
        /// <param name="otNightDesc">The ot night desc.</param>
        /// <param name="withoutExtra">The without extra.</param>
        /// <param name="moneyExtraType">Type of the money extra.</param>
        /// <param name="total">The total.</param>
        /// <param name="totalType">The total type.</param>
        /// <param name="time">The time.</param>
        /// <param name="workHours">The work hours.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAdditionalDetailInsert(string companyCode, string employeeNumber, string rate, string jobCode, string additionType, string otDayCode, string otDayDesc, string otNightCode, string otNightDesc, string withoutExtra, string moneyExtraType, string total, string totalType, string time, string workHours, string symbol, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[17];

            Guard.ArgumentConvertibleTo<float>(rate, "myFloatArgument");
            Guard.ArgumentConvertibleTo<bool>(withoutExtra, "myBoolArgument");
            Guard.ArgumentConvertibleTo<float>(total, "myFloatArgument");
            Guard.ArgumentConvertibleTo<float>(time, "myFloatArgument");
            Guard.ArgumentConvertibleTo<float>(workHours, "myFloatArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Rate, float.Parse(rate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.JobCode, jobCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AdditionType, additionType);
            objParam[5] = new SqlParameter(DL.Properties.Resources.OTDayCode, otDayCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.OTDayDesc, otDayDesc);
            objParam[7] = new SqlParameter(DL.Properties.Resources.OTNightCode, otNightCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.OTNightDesc, otNightDesc);
            objParam[9] = new SqlParameter(DL.Properties.Resources.WithoutExtra, bool.Parse(withoutExtra));
            objParam[10] = new SqlParameter(DL.Properties.Resources.MoneyExtraType, moneyExtraType);
            objParam[11] = new SqlParameter(DL.Properties.Resources.Total, float.Parse(total));
            objParam[12] = new SqlParameter(DL.Properties.Resources.TotalType, totalType);
            objParam[13] = new SqlParameter(DL.Properties.Resources.Time, float.Parse(time));
            objParam[14] = new SqlParameter(DL.Properties.Resources.WorkHrs, float.Parse(workHours));
            objParam[15] = new SqlParameter(DL.Properties.Resources.Symbol, symbol);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeeAdditionalDetail_insert", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the additional detail delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAdditionalDetailDelete(string companyCode, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeeAdditionalDetail_Delete", objParam);
            return ds;
        }

        #endregion

        #region Function Related to Employee Document Upload In Employee Master

        /// <summary>
        /// Employees the document download.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDocumentDownload(string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeDocument_DownloadGetAll", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the document upload.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="uploadDesc">The upload desc.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDocumentUpload(string employeeNumber, string uploadDesc, string fileName, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.UploadDesc, uploadDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeMaster_EmployeeDocumentUpload", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the document delete.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDocumentDelete(string fileName, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeMaster_EmployeeDocumentUploadDelete", objParam);
            return ds;
        }

        #endregion

        #region Function Rellated To Multilingual
        /// <summary>
        /// Insert Multilingual Details
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="otherLanguageFirstName">First name of the other language.</param>
        /// <param name="otherLanguageLastName">Last name of the other language.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeMultilingualDetailInsert(string employeeNumber, string otherLanguageFirstName, string otherLanguageLastName, string modifiedBy, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.OtherLangFirstName, otherLanguageFirstName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.OtherLangLastName, otherLanguageLastName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpMultiLingualPersonalDetails_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the multilingual detail get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeMultilingualDetailGet(string employeeNumber, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpMultiLingualPersonalDetails_GetAll", objParam);
            return ds;
        }
        #endregion
        #region Function Related to EmployeeDetails

        #region Function Related to get EmployeeDetails
        /// <summary>
        /// To get Employee Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDetailGet(string locationAutoId, string areaId, string areaIncharge, string isAreaIncharge, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[3] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeDetail_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the additional detail get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAdditionalDetailGet(string companyCode, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeeAdditionalDetail_GETALL", objParam);
            return ds;
        }
        /// <summary>
        /// To search Employee Number,Employee Name [NormalSearch]
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameAndNumberSearch(string value, string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpNameAndNumber_Search", objParam);
            return ds;
        }
        /// <summary>
        /// TO search employee details based on different condition[Advance Search]
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="operatorEmployeeNumber">The operator employee number.</param>
        /// <param name="employeeNo">The employee no.</param>
        /// <param name="employeeName">Name of the employee.</param>
        /// <param name="operatorEmployeeName">Name of the operator employee.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameAndNumberSearch(string employeeNumber, string operatorEmployeeNumber, string employeeNo, string employeeName, string operatorEmployeeName, string designationCode, string companyCode)
        {
            DL.Sales objSales = new DL.Sales();

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumberCondition, objSales.GenerateWhereCondition("HED.employeeNumber", operatorEmployeeNumber, employeeNumber, employeeNo));
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNameCondition, objSales.GenerateWhereCondition("HEM.FirstName + ' '+ HEM.LastName", operatorEmployeeName, employeeName, ""));
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_EmpNameAndNumber_Search", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Employee Name And Designation Based On Employee number and companyCode
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameAndDesignationGet(string employeeNumber, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_GetEmployeeNameAndDesiBasedOnEmpNo", objParam);
            return ds;
        }

        /// <summary>
        /// Gets the Employees designation and number based on location
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDesignationGetLocation(string employeeNumber, string companyCode, string locationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Master_GetEmployeeNameAndDesignationAndLocation", objParam);
            return ds;
        }
        /// <summary>
        /// Employees the designation get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDesignationGet(string employeeNumber, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Master_GetEmployeeNameAndDesi", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Employee Id No Based On Employee number and companyCode
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="identificationType">Type of the identification.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIdGet(string employeeNumber, string hrLocationCode, string identificationType)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IdentificationType, identificationType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udphr_Employee_GetIdNOBasedOnEmpNo", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Employee Details based on location AutoID
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDetailsGet(string employeeNumber, string locationAutoId, string asmtCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_EmployeeDetails_Get", objParam);
            return ds;
        }

        /// <summary>
        /// To get Employee name in EmployeeWise Scheduling report
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>

        public DataSet EmployeeNameGetAll(string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpReports_EmployeeName_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get Employee name in EmployeeWise Scheduling report
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>

        public DataSet EmployeeNameAreaWiseGetAll(string locationAutoId, string areaId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpReports_EmployeeNameAreaWise_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get AreaIncharge Details
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGet(String companyCode, String employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAreaInchargeGet", objParam);
            return ds;
        }
        /// <summary>
        /// To Get AreaIncharge Details based on User
        /// </summary>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="userid">The userid.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGetBasedonUserID(String LocationAutoId, String employeeNumber, String userid)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.UserId, userid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAreaInchargeGetBasedonUserID", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the name and number get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameAndNumberGetAll(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeeNameNumber_Get4Comapny", objParam);
            return ds;
        }
        /// <summary>
        /// Employees the name number get4 location.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameNumberGet4Location(string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeeNameNumber_Get4LocationAutoId", objParam);
            return ds;
        }

        /// <summary>
        /// To get Employee List From Roster for a date range. for Attendance report
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterEmployeeGetAll(string locationAutoId, string startDate, string endDate)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(startDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(endDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpReports_RosterEmployee_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Rosters the employee get absent employee.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterEmployeeGetAbsentEmployee(string companyCode, string hrLocationCode, string locationCode, string startDate, string endDate)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(startDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(endDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_rptRostering_GetAbsentEmployee", objParam);
            return ds;
        }

        #endregion

        #region Function To get EmployeeDetail For update
        /// <summary>
        /// To get EmployeeDetail For update
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>dataset</returns>
        public DataSet EmployeeDetailUpdate(string employeeNumber, string locationAutoId)
        {
            SqlParameter[] objparam = new SqlParameter[2];
            objparam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objparam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeDetail_GetDataForUpdate", objparam);
            return ds;
        }
        #endregion

        #region Function to Update Employee Details

        /// <summary>
        /// Employees the detail update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="height">The height.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="maritalStatus">The marital status.</param>
        /// <param name="nationality">The nationality.</param>
        /// <param name="state">The state.</param>
        /// <param name="address">The address.</param>
        /// <param name="contactNumber">The contact number.</param>
        /// <param name="religion">The religion.</param>
        /// <param name="militaryStatus">The military status.</param>
        /// <param name="smoker">The smoker.</param>
        /// <param name="vegetarian">The vegetarian.</param>
        /// <param name="previousExperience">The previous experience.</param>
        /// <param name="dateOfJoining">The date of joining.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="identificationNumber">The identification number.</param>
        /// <param name="identificationType">Type of the identification.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="oldEmployeeNo">The old employee no.</param>
        /// <param name="wageRate">The wage rate.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="wageRateFrequency">The wage rate frequency.</param>
        /// <param name="paymentFrequency">The payment frequency.</param>
        /// <param name="contractHours">The contract hours.</param>
        /// <param name="contractHoursFrequency">The contract hours frequency.</param>
        /// <param name="contractDays">The contract days.</param>
        /// <param name="otEntitlement">The ot entitlement.</param>
        /// <param name="otDate">The ot date.</param>
        /// <param name="status">The status.</param>
        /// <param name="statusDesc">The status desc.</param>
        /// <param name="statusDate">The status date.</param>
        /// <param name="scaleCode">The scale code.</param>
        /// <param name="scaleDesc">The scale desc.</param>
        /// <param name="Bloodgroup">Blood group</param>
        /// <param name="Disability">The Disability</param>
        /// <param name="Identificationmark">Identification mark</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDetailUpdate(string companyCode, DateTime dateOfBirth, string firstName, string lastName, string height, float weight, string gender, string maritalStatus, string nationality, string state, string address, string contactNumber, string religion, string militaryStatus, string smoker, string vegetarian, float previousExperience, DateTime dateOfJoining, string userId, string identificationNumber, string identificationType, string employeeNumber, string oldEmployeeNo, string wageRate, string currency, string wageRateFrequency, string paymentFrequency, float contractHours, string contractHoursFrequency, string contractDays, string otEntitlement, string otDate, string status, string statusDesc, string statusDate, string scaleCode, string scaleDesc, string Bloodgroup, string Identificationmark, string Disability)
        {

            SqlParameter[] objParam = new SqlParameter[40];

            if (!String.IsNullOrEmpty(otDate))
                Guard.ArgumentValidDate(otDate, "myDateArgument");
            if (!String.IsNullOrEmpty(statusDate))
                Guard.ArgumentValidDate(statusDate, "myDateArgument");

            Guard.ArgumentConvertibleTo<bool>(otEntitlement, "myBoolArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DateOfBirth, DL.Common.DateFormat(dateOfBirth));
            objParam[2] = new SqlParameter(DL.Properties.Resources.FirstName, firstName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.LastName, lastName);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Height, height);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Weight, weight);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Gender, gender);
            objParam[7] = new SqlParameter(DL.Properties.Resources.MaritalStatus, maritalStatus);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Nationality, nationality);
            objParam[9] = new SqlParameter(DL.Properties.Resources.State, state);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Address, address);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ContactNumber, contactNumber);
            objParam[12] = new SqlParameter(DL.Properties.Resources.Religion, religion);
            objParam[13] = new SqlParameter(DL.Properties.Resources.MilitaryStatus, militaryStatus);
            objParam[14] = new SqlParameter(DL.Properties.Resources.Smoker, smoker);
            objParam[15] = new SqlParameter(DL.Properties.Resources.Vegitarian, vegetarian);
            objParam[16] = new SqlParameter(DL.Properties.Resources.PrevTotalExp, previousExperience);
            objParam[17] = new SqlParameter(DL.Properties.Resources.DateOfJoining, DL.Common.DateFormat(dateOfJoining));
            objParam[18] = new SqlParameter(DL.Properties.Resources.ModifierBy, userId);
            objParam[19] = new SqlParameter(DL.Properties.Resources.IdentificationNumber, identificationNumber);
            objParam[20] = new SqlParameter(DL.Properties.Resources.IdentificationType, identificationType);
            objParam[21] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[22] = new SqlParameter(DL.Properties.Resources.OldEmpNo, oldEmployeeNo);
            objParam[23] = new SqlParameter(DL.Properties.Resources.wageRate, wageRate);
            objParam[24] = new SqlParameter(DL.Properties.Resources.CurrencyCode, currency);
            objParam[25] = new SqlParameter(DL.Properties.Resources.WageRateFrequency, wageRateFrequency);
            objParam[26] = new SqlParameter(DL.Properties.Resources.PaymentFrequency, paymentFrequency);
            objParam[27] = new SqlParameter(DL.Properties.Resources.contractHrs, contractHours);
            objParam[28] = new SqlParameter(DL.Properties.Resources.ContractHrsFrequency, contractHoursFrequency);
            objParam[29] = new SqlParameter(DL.Properties.Resources.ContractDays, contractDays);
            objParam[30] = new SqlParameter(DL.Properties.Resources.OTENTITLEMENT, bool.Parse(otEntitlement));
            objParam[31] = new SqlParameter(DL.Properties.Resources.OTDATE, DL.Common.DateFormat(otDate, true));
            objParam[32] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[33] = new SqlParameter(DL.Properties.Resources.STATUSDESC, statusDesc);
            objParam[34] = new SqlParameter(DL.Properties.Resources.STATUSDATE, DL.Common.DateFormat(statusDate, true));
            objParam[35] = new SqlParameter(DL.Properties.Resources.SCALECODE, scaleCode);
            objParam[36] = new SqlParameter(DL.Properties.Resources.SCALEDESC, scaleDesc);
            objParam[37] = new SqlParameter(DL.Properties.Resources.BloodGroup, Bloodgroup);
            objParam[38] = new SqlParameter(DL.Properties.Resources.IdentificationMark, Identificationmark);
            objParam[39] = new SqlParameter(DL.Properties.Resources.Disability, Disability);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeDetail_Update", objParam);
            return ds;
        }


        #endregion

        #region Get Employee Detail by employeeNumber
        /// <summary>
        /// Employees the detail get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDetailGet(string employeeNumber, string companyCode, string hrLocationCode, int locationAutoId, string asmtCode, string pdLineNo, string fromDate, string toDate)
        {


            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmpDetailByEmpNo_Get", objParm);
            return ds;
        }

        /// <summary>
        /// to Get Employee Detail For New Scheduling Screen
        /// </summary>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="pdLineNo">The STR pd line no.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="postcode">The STR post code.</param>
        /// <param name="areaId">The STR area ID.</param>
        /// <param name="areaIncharge">The STR area incharge.</param>
        /// <param name="isAreaIncharge">The STR is area incharge.</param>
        /// <param name="screenType">Type of the screen.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDetailGet(string employeeNumber, string companyCode, string hrLocationCode, int locationAutoId, string asmtCode, string pdLineNo, string fromDate, string toDate, string postcode, string areaId, string areaIncharge, string isAreaIncharge, string screenType, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[15];

            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[8] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[9] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[10] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[11] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[13] = new SqlParameter(DL.Properties.Resources.ScreenType, screenType);
            objParm[14] = new SqlParameter(DL.Properties.Resources.Status, "");
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeDetailByEmpNo_Get", objParm);
            return ds;
        }


        #endregion

        #endregion
        #region Function To Generate Code
        /// <summary>
        /// Generates the employee code.
        /// </summary>
        /// <param name="sequenceField">The sequence field.</param>
        /// <returns>DataSet.</returns>

        public DataSet GenerateEmployeeCode(string sequenceField)
        {


            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.seqField, sequenceField);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeDetail_GenerateCode", objParam);
            return ds;
        }

        #endregion

        #region Function Related  HrEmployeeTraining

        #region Function Related To GetEmployeeTraining Details Based On companyCode And Employee Number
        /// <summary>
        /// To GetEmployeeTraining Details Based On companyCode And Employee Number
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeTrainingGet(string companyCode, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeTraining_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To Deactive Employee Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="validTillDate">The valid till date.</param>
        /// <param name="oldValidTillDate">The old valid till date.</param>
        /// <returns>dataset</returns>
        public DataSet DeactivateEmployee(string companyCode, string employeeNumber, DateTime trainingDate, string trainingCode,string validTillDate,string oldValidTillDate)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingDate, trainingDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ValidTillDate, Common.DateFormat(validTillDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, Common.DateFormat(oldValidTillDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpDeactivateTraining", objParam);
            return ds;
        }
        #endregion

        #region Function Related To Get Training Desc Based On Training Code
        /// <summary>
        /// to get training Desc based on training code
        /// </summary>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>dataset</returns>
        public DataSet EmployeeTrainingGet(string trainingCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeTraining_GetCodeBasedOnDesc", objParam);
            return ds;
        }
        #endregion

        #region Function Realted to Insert Data
        /// <summary>
        /// to insert new Data In HrEmployeeTraining
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="newTrainingDate">The new training date.</param>
        /// <param name="newValidTillDate">The new valid till date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset</returns>

        public DataSet EmployeeTrainingInsert(string employeeNumber, string trainingCode, string duration, DateTime newTrainingDate, DateTime newValidTillDate, string modifiedBy, string companyCode)
        {


            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Duration, duration);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingDate, newTrainingDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ValidTillDate, newValidTillDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeTraining_Insert", objParam);
            return ds;

        }
        #endregion

        #region Function Realted to Delete Data
        /// <summary>
        /// toDelete Records From mstHrEmployeeTraining
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset</returns>

        public DataSet EmployeeTrainingDelete(string employeeNumber, string trainingCode, DateTime trainingDate, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingDate, trainingDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeTraining_Delete", objParam);
            return ds;

        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// to Update Data
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="validTillDate">The valid till date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeTrainingUpdate(string employeeNumber, string trainingCode, string duration, DateTime trainingDate, DateTime validTillDate, string modifiedBy, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Duration, duration);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingDate, trainingDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ValidTillDate, validTillDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeTraining_Update", objParam);
            return ds;
        }
        #endregion

        /// <summary>
        /// Trainings the valid to date get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="txtNewTrainingCode">The text new training code.</param>
        /// <param name="txtNewTrainingDate">The text new training date.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingValidToDateGet(string companyCode, string txtNewTrainingCode, DateTime txtNewTrainingDate)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, txtNewTrainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingDate, txtNewTrainingDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_Training_GetValidDate", objParam);
            return ds;
        }


        #endregion

        #region Function Related  HrEmployeeQualification

        #region Function Related TO Get EmployeeQualification Based On Employee NUmber
        /// <summary>
        /// Get EmployeeQualification Based On Employee NUmber
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeQualificationGet(string companyCode, string employeeNumber)
        {

            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeQualification_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function Related to get QualificationDesc  based on Qualification code
        /// <summary>
        /// to get QualificationDesc  based on Qualification code
        /// </summary>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>dataset</returns>
        public DataSet EmployeeQualificationGet(string qualificationCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeQualification_GetCodeBasedOnDesc", objParam);
            return ds;
        }
        #endregion

        #region Function Related to InsertDate
        /// <summary>
        /// To Insert Employee Qualification
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeQualificationInsert(string companyCode, string employeeNumber, string qualificationCode, string modifiedBy)
        {

            SqlParameter[] objparam = new SqlParameter[4];
            objparam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objparam[1] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            objparam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objparam[3] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeQualification_Insert", objparam);
            return ds;
        }
        #endregion

        #region Function Related to Delete Data based on employeeNumber and Qualification Code
        /// <summary>
        /// to Delete Data
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>dataset</returns>
        public DataSet EmployeeQualificationDelete(string companyCode, string employeeNumber, string qualificationCode)
        {


            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeQualification_Delete", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to HrEmployeeLanguage

        #region Function Related to Get Employeelanguage
        /// <summary>
        /// Function Related To Get Employee language
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeLanguageGet(string companyCode, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeLanguage_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function To Insert Data Based On employeeNumber And language Code
        /// <summary>
        /// To Insert Data Based On employeeNumber And language Code
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="proficiency">The proficiency.</param>
        /// <param name="motherTongue">if set to <c>true</c> [mother tongue].</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeLanguageInsert(string companyCode, string employeeNumber, string languageCode, string modifiedBy, string proficiency, bool motherTongue)
        {


            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Proficiency, proficiency);
            objParam[4] = new SqlParameter(DL.Properties.Resources.MotherTongue, motherTongue);
            objParam[5] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeLanguage_Insert", objParam);
            return ds;
        }

        #endregion

        #region Function Related To delete Based On employeeNumber And LanguageCode
        /// <summary>
        /// To delete Based On employeeNumber And LanguageCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="languageCode">The language code.</param>
        /// <returns>dataset</returns>
        public DataSet EmployeeLanguageDelete(string companyCode, string employeeNumber, string languageCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeLanguage_Delete", objParam);
            return ds;
        }
        #endregion
        #region Function Related To Update Data Based On employeeNumber And LanguageCode
        /// <summary>
        /// To Update Data Based On employeeNumber And LanguageCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="proficiency">The proficiency.</param>
        /// <param name="motherTongue">if set to <c>true</c> [mother tongue].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        /// <return>Dataset</return>
        public DataSet EmployeeLanguageUpdate(string companyCode, string employeeNumber, string languageCode, string proficiency, bool motherTongue, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Proficiency, proficiency);
            objParam[3] = new SqlParameter(DL.Properties.Resources.MotherTongue, motherTongue);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeLanguage_Update", objParam);
            return ds;

        }
        #endregion



        #endregion

        #region Function Related to Other Details
        /// <summary>
        /// Get Other Details Like Passport,ID info etc
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeOtherDetailsGet(string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeDetail_GetOtherDetails", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the identifier type get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIdTypeGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeDetail_GetIDTypeDetails");
            return ds;
        }
        /// <summary>
        /// Employees the passport detail insert.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idNumber">The identifier number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <param name="dateOfIssue">The date of issue.</param>
        /// <param name="dateOfExpiry">The date of expiry.</param>
        /// <param name="issuingAuthority">The issuing authority.</param>
        /// <param name="placeOfBirth">The place of birth.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePassportDetailInsert(string employeeNumber, string idNumber, string idType, string dateOfIssue, string dateOfExpiry, string issuingAuthority, string placeOfBirth, string remarks, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IDNumber, idNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IDType, idType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DateOfIssue, DL.Common.DateFormat(dateOfIssue, true));
            objParam[4] = new SqlParameter(DL.Properties.Resources.DateOfExpiry, DL.Common.DateFormat(dateOfExpiry, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.IssuingAuthority, issuingAuthority);
            objParam[6] = new SqlParameter(DL.Properties.Resources.PlaceOfBirth, placeOfBirth);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpPassportDetails_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// Employees the passport details delete.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePassportDetailsDelete(string employeeNumber, string idType, string passPortId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IDType, idType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PassportId, passPortId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpPassportDetails_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the passport details update.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idNumber">The identifier number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <param name="dateOfIssue">The date of issue.</param>
        /// <param name="dateOfExpiry">The date of expiry.</param>
        /// <param name="issuingAuthority">The issuing authority.</param>
        /// <param name="placeOfBirth">The place of birth.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePassportDetailsUpdate(string employeeNumber, string idNumber, string idType, string dateOfIssue, string dateOfExpiry, string issuingAuthority, string placeOfBirth, string remarks, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IDNumber, idNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IDType, idType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DateOfIssue, DL.Common.DateFormat(dateOfIssue, true));
            objParam[4] = new SqlParameter(DL.Properties.Resources.DateOfExpiry, DL.Common.DateFormat(dateOfExpiry, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.IssuingAuthority, issuingAuthority);
            objParam[6] = new SqlParameter(DL.Properties.Resources.PlaceOfBirth, placeOfBirth);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpPassportDetails_Update", objParam);
            return ds;
        }

        /// <summary>
        /// Determines whether [is employee passport information already exist] [the specified employee number].
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idTypeCode">The identifier type code.</param>
        /// <param name="idNumber">The identifier number.</param>
        /// <returns>DataSet.</returns>
        public DataSet IsEmployeePassportInformationAlreadyExist(string employeeNumber, string idTypeCode, string idNumber)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IDType, idTypeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IDNumber, idNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpPassportDetails_CheckOtherInfoDuplicate", objParam);
            return ds;
        }

        #endregion

        /// <summary>
        /// Determines whether [is employee number already exist] [the specified employee number].
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IsEmployeeNumberAlreadyExist(string employeeNumber, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeDetail_CheckDuplicateEmpNo", objParam);
            return ds;
        }

        #region function related to employee skills

        /// <summary>
        /// Employees the skills get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeSkillsGet(string companyCode, string employeeNumber)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeeSkills_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the skills insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="skillCode">The skill code.</param>
        /// <param name="skillDesc">The skill desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeSkillsInsert(string companyCode, string employeeNumber, string skillCode, string skillDesc, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SkillCode, skillCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SkillDesc, skillDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeeSkill_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the skills delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="skillDesc">The skill desc.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeSkillsDelete(string companyCode, string employeeNumber, string skillDesc)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SkillDesc, skillDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeeSkill_Delete", objParam);
            return ds;
        }

        #endregion

        /// <summary>
        /// Areas the incharge name get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeNameGet(string locationAutoId, string areaId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeDetail_GetAreaInchargeName", objParam);
            return ds;
        }

        #region SAT#124 Employee Work History
        /// <summary>
        /// Function used to Get the details of Employee Work History
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="confirmDuty">The confirm duty.</param>
        /// <returns>DataTable.</returns>
        public DataTable EmployeeWorkHistoryGet(string employeeNumber, string confirmDuty)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ConfirmDuty, confirmDuty);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeeWorkHistoryGet", objParam);
            return ds.Tables[0];
        }
        #endregion

        #region Employee Master New details
        public DataSet GetState()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_StateDetail_Get");
            return ds;
        }
        public DataSet GetDistrict(string StateID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.StateId, StateID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_DistrictDetail_Get", objParam);
            return ds;
        }
        public DataSet GetDistrict()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_DistrictDetail_Get");
            return ds;
        }

        #region Function related  to Employee Item Issuing Details
       
        public DataSet EmployeeIssuingInsert(string EmployeeNumber, string CompanyCode, int ID, string Item, string GroupID, string SubgroupId, int quantity, string IssueingDate, string ValidityDate, string IssuengBranch, string Issuedby, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ItemIssuingID, ID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Item, Item);
            objParam[2] = new SqlParameter(DL.Properties.Resources.GroupID, GroupID);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SubGroupID, SubgroupId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Quantity, quantity);
            objParam[5] = new SqlParameter(DL.Properties.Resources.IssueingDate1, DL.Common.DateFormat(IssueingDate, true));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ValidityDate1, DL.Common.DateFormat(ValidityDate, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.IssuengBranch, IssuengBranch);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Issuedby, Issuedby);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[10] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[11] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeItemIssingInsert", objParam);
            return ds;
        }
        public DataSet EmployeeItemIssuingDelete(int ID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ItemIssuingID, ID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updHrEmployeeItemIssuingDelete", objParam);
            return ds;
        }
        public DataSet GetItemGroup()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Group_Get");
            return ds;
        }
        public DataSet GetEmployeeItemIssuing(string EmployeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeItemIssuingGet", objParam);
            return ds;
        }
        public DataSet GetItemSubGroup(string GroupID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.GroupID, GroupID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SubGroup_Get", objParam);
            return ds;
        }
        public DataSet GetItems(string SubGroupID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SubGroupID, SubGroupID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Items_Get", objParam);
            return ds;
        }
        public DataSet GetItem()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Item_Get");
            return ds;
        }
        #endregion Function related  to Employee Item Issuing Details

        #region Function related  to Employee Document Details
        public DataSet EmployeeDocumentDetailGet(string PassportID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.PassportId, PassportID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeDetail_GetDocumentDetail", objParam);
            return ds;
        }
        public DataSet EmployeeDocumentGet(string PassportID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.PassportId, PassportID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_GetDocumentDetail", objParam);
            return ds;
        }
        public DataSet EmployeeDocumentDetailInsert(decimal PassportId, string DocumentDesc, string DocumentFileName, string DocumentFilePath, int IsVerified, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.PassportId, PassportId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DocumentDesc, DocumentDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DocumentFileName, DocumentFileName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DocumentFilePath, DocumentFilePath);
            objParam[4] = new SqlParameter(DL.Properties.Resources.IsVerified, IsVerified);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_DocumentDetails_Insert", objParam);
            return ds;
        }
        public DataSet EmployeeDocumentDetailDelete(int ID)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DocumentId, ID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updHrEmployeeDocumentDetailDelete", objParam);
            return ds;
        }
       
        #endregion Function related  to Employee Document Details

        #region Function related  to Employee Education Details
        public DataSet EmplyoyeeEducationdetailDelete(int ID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EducationID, ID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updHrEmployeeEducationDelete", objParam);
            return ds;
        }
        public DataSet GetEmployeeEducationDetail(string EmployeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpEmployeeEducationDetailGet", objParam);
            return ds;
        }
        public DataSet EmployeeEducationInsert(int EducationID, string EmployeeNumber, string CompanyCode, string Class, string Specialization, string Grade, string Yearofcompletion, string ModifiedBy, string QualificationCode, string University)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EducationID, EducationID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Class, Class);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Specialization, Specialization);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Grade, Grade);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Yearofcompletion,Yearofcompletion);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[7] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.QualificationCode, QualificationCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.University, University);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeEducationInsert", objParam);
            return ds;
        }
        #endregion Function related  to Employee Education Details

        #region Function related  to Employee Bank Details
        public DataSet EmployeeBankDetailGet(string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeBankDetail_GetBankDetail", objParam);
            return ds;
        }
        public DataSet EmployeeBankdetailInsert(decimal BankDetailId, string BankName, decimal State, decimal District, string Branch, string IFSCCode, string AccountNumber, string AccountName, string ModifiedBy, string EmployeeNumber, string CompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BankDetailId, BankDetailId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.BankName, BankName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.StateId, State);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DistrictId, District);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Branch, Branch);
            objParam[5] = new SqlParameter(DL.Properties.Resources.IFSCCode, IFSCCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AccountNumber, AccountNumber);
            objParam[7] = new SqlParameter(DL.Properties.Resources.AccountName, AccountName);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[10] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeBankDetailInsert", objParam);
            return ds;
        }
        public DataSet EmployeeBankdetailDelete(int ID)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.BankDetailId, ID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updHrEmployeeBankDetailDelete", objParam);
            return ds;
        }
        #endregion Function related  to Employee Bank Details

        #region Function related  to Employee Familydetail
        public DataSet EmployeeFamilyDetailInsert(string EmployeeNumber, string CompanyCode, int ID, string Relation, string RelationName, string DOB, string Gender, string ModifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.FamilyID, ID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Relation, Relation);
            objParam[2] = new SqlParameter(DL.Properties.Resources.RelationName, RelationName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Gender, Gender);
            objParam[4] = new SqlParameter(DL.Properties.Resources.DOBF, DL.Common.DateFormat(DOB, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[7] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updHrEmployeeFamilyDetailInsert", objParam);
            return ds;
        }
        public DataSet EmployeeFamilydetailDelete(int ID)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.FamilyID, ID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeFamilyDetailDelete", objParam);
            return ds;
        }
        public DataSet EmployeeFamilyDetailGet(string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHr_EmployeeFamilyDetail_GetBankDetail", objParam);
            return ds;
        }
        #endregion Function related  to Employee Familydetail

        #region Function related  to Employee References
        public DataSet GetEmployeeReferenceDetail(string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpEmployeeRefenceDetailGet", objParam);
            return ds;
        }
        public DataSet EmployeeReferenceDetailsDelete(int ID)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RefernceID, ID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeReferenceDetailsDelete", objParam);
            return ds;
        }
        public DataSet EmployeeReferenceDetails(string EmployeeNumber, string CompanyCode, int ID, string Name, string Designation, string Area, string RelationshipRefernce, string Organization, string mobile, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RefernceID, ID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Name, Name);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Area, Area);
            objParam[4] = new SqlParameter(DL.Properties.Resources.RelationshipRefernce, RelationshipRefernce);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[7] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Mobile, mobile);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Organization, Organization);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeReferenceDetaileInsert", objParam);
            return ds;
        }
        #endregion Function related  to Employee References

        #region Function related to Employee Experience
        public DataSet GetEmployeeExperienceDetail(string EmpNo)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmpNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeExperienceDetail", objParam);
            return ds;
        }
        public DataSet EmployeeExperienceDetails(string CompanyCode, string EmployeeNumber, string Designation, string Department, string companyname, string Address, string Fromdate, string Todate, string ModifiedBy, int Experienceid)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Department, Department);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CompanyName, companyname);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Address, Address);
            objParam[6] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(Fromdate, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(Todate, true));
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ExperienceId, Experienceid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeExperienceDetailInsert", objParam);
            return ds;
        }
        public DataSet EmplyoyeeExperienceDetailDelete(int ID)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ExperienceId, ID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updHrEmployeeExperienceDelete", objParam);
            return ds;
        }
        #endregion

        #region Function related  to Employee ReferredBy
        public DataSet GetEmployeeRefferedBYDetail(string EmpNo)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmpNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeRefferedByDetailGet", objParam);
            return ds;
        }
        public DataSet EmployeeReferredBYDetails(string CompanyCode, string EmployeeNumber, string ReferrerNumber, string ReferrerName, string ModifiedBy, int ReferredById)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ReferrerNumber, ReferrerNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ReferrerName, ReferrerName);

            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ReferredById, ReferredById);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeReferredByDetailInsert", objParam);
            return ds;
        }
        public DataSet EmplyoyeeReferredByDetailDelete(int ID)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ReferredById, ID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updHrEmployeeReferredByDetailDelete", objParam);
            return ds;
        }
        public DataSet SearchEmployee(string EmployeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeeSearchDetail", objParam);
            return ds;
        }

        #endregion

        #region Function realetd to Employee PFandESI
        public DataSet EmployeePFandESIInsert(string companyCode, string employeeNumber, string uanNo, string oldUanNo, string esiNo, string oldEsiNo, string pfRegion, string pfOffice, string pfEstablishment, string pfExtension, string pfAccount, string oldPfRegion, string oldPfOffice, string oldPfEstablishment, string oldPfExtension, string oldPfAccount, string ModifiedBy, string ID)
        {
            SqlParameter[] objParam = new SqlParameter[18];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.UANNo, uanNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.OldUANNo, oldUanNo);

            objParam[4] = new SqlParameter(DL.Properties.Resources.ESINo, esiNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.OldESINo, oldEsiNo);
            objParam[6] = new SqlParameter(DL.Properties.Resources.PFRegion, pfRegion);
            objParam[7] = new SqlParameter(DL.Properties.Resources.PFOffice, pfOffice);
            objParam[8] = new SqlParameter(DL.Properties.Resources.PFEstablishment, pfEstablishment);
            objParam[9] = new SqlParameter(DL.Properties.Resources.PFExtension, pfExtension);

            objParam[10] = new SqlParameter(DL.Properties.Resources.PFAccount, pfAccount);
            objParam[11] = new SqlParameter(DL.Properties.Resources.OldPFRegion, oldPfRegion);
            objParam[12] = new SqlParameter(DL.Properties.Resources.OldPFOffice, oldPfOffice);
            objParam[13] = new SqlParameter(DL.Properties.Resources.OldPFEstablishment, oldPfEstablishment);
            objParam[14] = new SqlParameter(DL.Properties.Resources.OldPFExtension, oldPfExtension);
            objParam[15] = new SqlParameter(DL.Properties.Resources.OldPFAccount, oldPfAccount);

            objParam[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[17] = new SqlParameter(DL.Properties.Resources.Flag, ID);
                     DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeePFnESIDetailInsert", objParam);
            return ds;
        }
        public DataSet EmployeePFandESIDetailGet(string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHrEmployeePFnESIDetailGet", objParam);
            return ds;
        }
        public DataSet EmployeePFandESIDetailDelete(string employeeNumber, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
              DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updHrEmployeePFnESIDetailDelete", objParam);
            return ds;
        }
      
        #endregion

        #endregion Employee Master New details
        #endregion

        #region Function Related to Employee Transfer Inter Company

        #region Function Related To get Data
        /// <summary>
        /// To get Data Based On locationAutoId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>Datasset</returns>
        //public DataSet dlEmpInterCompanyTransfer_GetAll(string locationAutoId)
        public DataSet AreaInchargeGetAll(string locationAutoId, string areaId, string areaIncharge, string isAreaIncharge, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[3] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeCompanyInterTransfer_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function related to Fill Company ComboBox
        /// <summary>
        /// to Fill Company ComboBox
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIntercompanyTransferGetCompany()
        {

            DataSet ds = SqlHelper.ExecuteDataset("updMstHR_EmpInterCompanyTransfer_GetCompany");
            return ds;

        }
        #endregion

        #region Function related to Fill HrLocation ComboBox based on companyCode
        /// <summary>
        /// to Fill HrLocation ComboBox based on companyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeIntercompanyTransferGetHRLocation(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset("updMstHR_EmpInterCompanyTransfer_GetHrLocation", objParam);
            return ds;

        }
        #endregion

        #region Function related to Fill Location ComboBox Based On companyCode and hrLocationCode
        /// <summary>
        /// to Fill Location ComboBox Based On companyCode and hrLocationCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeIntercompanyTransferGetLocation(string companyCode, string hrLocationCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            DataSet ds = SqlHelper.ExecuteDataset("updMstHR_EmpInterCompanyTransfer_GetLocation", objParam);
            return ds;

        }
        #endregion

        #region Function related to Fill Designation ComboBox Based On Company Code
        /// <summary>
        /// to Fill Designation ComboBox Based On Company Code
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeIntercompanyTransferGetDesignation(string companyCode)
        {


            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset("updMstHR_EmpInterCompanyTransfer_GetDesignation", objParam);
            return ds;

        }
        #endregion

        #region Function related to Fill Category ComboBox Based on companyCode
        /// <summary>
        /// to Fill Category ComboBox Based on companyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeIntercompanyTransferGetCategory(string companyCode)
        {


            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset("updMstHR_EmpInterCompanyTransfer_GetCategory", objParam);
            return ds;

        }
        #endregion

        #region Function Related to Insert Employeewise issue and reciept DATA
        /// <summary>
        /// To Insert Employewise Id issue and reciept details
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <param name="purposeOfIssue">The purpose of issue.</param>
        /// <param name="dateOfIssue">The date of issue.</param>
        /// <param name="dateOfReturn">The date of return.</param>
        /// <param name="issueRemarks">The issue remarks.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IssuedIdReceiptInsert(string employeeNumber, string idType, string purposeOfIssue, string dateOfIssue, string dateOfReturn, string issueRemarks, string status, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];

            if (!String.IsNullOrEmpty(dateOfReturn))
                Guard.ArgumentValidDate(dateOfReturn, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IDType, idType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.strPurposeOfIssue, purposeOfIssue);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DateOfIssue, DL.Common.DateFormat(dateOfIssue));
            objParam[4] = new SqlParameter(DL.Properties.Resources.strDateOfReturn, DL.Common.DateFormat(dateOfReturn, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.strIssueRemarks, issueRemarks);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_IDIssueReciept_EmployeeWise_Insert", objParam);
            return ds;


        }

        #endregion

        #region Function Related to update employee wsie issue and reciept DATA
        /// <summary>
        /// To Insert Employewise Id issue and reciept details
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <param name="purposeOfIssue">The purpose of issue.</param>
        /// <param name="dateOfIssue">The date of issue.</param>
        /// <param name="dateOfReturn">The date of return.</param>
        /// <param name="issueRemarks">The issue remarks.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IssuedIdReceiptUpdate(string employeeNumber, string idType, string purposeOfIssue, string dateOfIssue, string dateOfReturn, string issueRemarks, string status, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];

            if (!String.IsNullOrEmpty(dateOfReturn))
                Guard.ArgumentValidDate(dateOfReturn, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IDType, idType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.strPurposeOfIssue, purposeOfIssue);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DateOfIssue, DL.Common.DateFormat(dateOfIssue));
            objParam[4] = new SqlParameter(DL.Properties.Resources.strDateOfReturn, DL.Common.DateFormat(dateOfReturn, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.strIssueRemarks, issueRemarks);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_IDIssueReciept_EmployeeWise_Update", objParam);
            return ds;


        }
        #endregion

        #region Function Related to Authorize employee wsie issue and reciept DATA
        /// <summary>
        /// To Authorize Employewise Id issue and reciept details
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IssuedIdReceiptAuthorize(string employeeNumber, string idType, string status, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IDType, idType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_IDIssueReciept_EmployeeWise_Authorize", objParam);
            return ds;


        }
        #endregion

        #region Function Related to update
        /// <summary>
        /// Update EmpInterCompanyTransfer
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="oldCompanyCode">The old company code.</param>
        /// <param name="oldLocationAutoId">The old location automatic identifier.</param>
        /// <param name="oldDesignation">The old designation.</param>
        /// <param name="oldCategory">The old category.</param>
        /// <param name="oldJobClass">The old job class.</param>
        /// <param name="oldJobType">Old type of the job.</param>
        /// <param name="oldRole">The old role.</param>
        /// <param name="oldAreaId">The old area identifier.</param>
        /// <param name="oldDepartmentCode">The old department code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="category">The category.</param>
        /// <param name="jobClass">The job class.</param>
        /// <param name="jobType">Type of the job.</param>
        /// <param name="role">The role.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="comment">The comment.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIntercompanyTransferUpdate(string employeeNumber, string oldCompanyCode, string oldLocationAutoId, string oldDesignation, string oldCategory, string oldJobClass, string oldJobType, string oldRole, string oldAreaId, string oldDepartmentCode, string companyCode, string locationAutoId, string designation, string category, string jobClass, string jobType, string role, string areaId, string departmentCode, string effectiveTo, string modifiedBy, string comment, string oldGradeCode, string GradeCode)
        {
            SqlParameter[] objParam = new SqlParameter[24];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.OldCompanyCode, oldCompanyCode);

            objParam[2] = new SqlParameter(DL.Properties.Resources.oldLocationautoid, oldLocationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.oldOldDesignation, oldDesignation);
            objParam[4] = new SqlParameter(DL.Properties.Resources.oldCatagory, oldCategory);
            objParam[5] = new SqlParameter(DL.Properties.Resources.oldJobClass, oldJobClass);
            objParam[6] = new SqlParameter(DL.Properties.Resources.OldJobType, oldJobType);
            objParam[7] = new SqlParameter(DL.Properties.Resources.oldRole, oldRole);
            objParam[8] = new SqlParameter(DL.Properties.Resources.oldAreaId, oldAreaId);
            objParam[9] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[10] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[11] = new SqlParameter(DL.Properties.Resources.Designation, designation);
            objParam[12] = new SqlParameter(DL.Properties.Resources.Catagory, category);
            objParam[13] = new SqlParameter(DL.Properties.Resources.JobClass, jobClass);
            objParam[14] = new SqlParameter(DL.Properties.Resources.JobType, jobType);
            objParam[15] = new SqlParameter(DL.Properties.Resources.Role, role);
            objParam[16] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);

            objParam[17] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[18] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[19] = new SqlParameter(DL.Properties.Resources.Comment, comment);
            objParam[20] = new SqlParameter(DL.Properties.Resources.OldDepartmentCode, oldDepartmentCode);
            objParam[21] = new SqlParameter(DL.Properties.Resources.DepartmentCode, departmentCode);
            objParam[22] = new SqlParameter(DL.Properties.Resources.OldGradeCode, oldGradeCode);
            objParam[23] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset("updMstHR_EmpInterCompanyTransfer_Update", objParam);
            return ds;
        }

        /// <summary>
        /// Gets the error details.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="date">The date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetErrorDetails(string employeeNumber, string date,string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            if (!String.IsNullOrEmpty(date))
                Guard.ArgumentValidDate(date, "myDateArgument");
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DutyDate,DL.Common.DateFormat(date));
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset("updMstHR_EmpInterCompanyTransfer_GetErrorDetails", objParam);
            return ds;
        }

        #endregion

        #region Function Related to get employeewise issue and receipt DATA
        /// <summary>
        /// To Get Employewise Id issue and reciept details
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIssueDetailGet(string employeeNumber, string idType)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IDType, idType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_dlEmployee_Issue_Detail_Get", objParam);
            return ds;
        }


        #endregion

        #region Function Related to get Max from Date from mstHrEmployeeLocation/mstHrEmployeeCategory/mstHrEmployeeDesignation
        /// <summary>
        /// to get Max from Date from mstHrEmployeeLocation/mstHrEmployeeCategory/mstHrEmployeeDesignation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeIntercompanyTransferGetMaxDate(string companyCode, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset("udpMstHR_EmpInterCompanyTransfer_GetMaxDate", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Employee Details Correction

        /// <summary>
        /// To Get Current Effective From Date
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIntercompanyTransferGetAllEffectiveFromDate(string employeeNumber, string companyCode, int locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeCompanyInterTransfer_GetAllEffectiveFromDate", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Count Of Employee Designatio/location/Category/jabclass/jobtype
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeTransactionCountGet(string employeeNumber, string companyCode, int locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeCompanyInterTransfer_GetEmployeeTransactionCount", objParam);
            return ds;
        }
        /// <summary>
        /// To Correct individual Employee Details
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="correctionDate">The correction date.</param>
        /// <param name="oldCorrectionDate">The old correction date.</param>
        /// <param name="newCode">The new code.</param>
        /// <param name="oldCode">The old code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="correctionField">The correction field.</param>
        /// <returns>DataSet.</returns>
        public DataSet CorrectEmployeeJobDetails(string companyCode, string hrLocationCode, int locationAutoId, string employeeNumber, string correctionDate, string oldCorrectionDate, string newCode, string oldCode, string modifiedBy, string correctionField)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CorrectionDate,DL.Common.DateFormat(correctionDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.OldCorrectionDate,DL.Common.DateFormat(oldCorrectionDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.NewCode, newCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.OldCode, oldCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.CorrectionField, correctionField);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeCompanyInterTransfer_CorrectEmployeeJobDetails", objParam);
            return ds;
        }

        /// <summary>
        /// To Get The Histroy Detail Of the Employee
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="value">The value.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeHistoryDetailGet(string companyCode, int locationAutoId, string employeeNumber, string value)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.GetField, value);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeCompanyInterTransfer_GetEmployeeHistroyDetail", objParam);
            return ds;
        }
        /// <summary>
        /// Corrects the employee company details.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="oldCompanyCode">The old company code.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <param name="oldCompanyCorrectionDate">The old company correction date.</param>
        /// <param name="newCorrectionDate">The new correction date.</param>
        /// <param name="oldHRLocationCode">The old hr location code.</param>
        /// <param name="newHRLocationCode">The new hr location code.</param>
        /// <param name="oldLocationAutoId">The old location automatic identifier.</param>
        /// <param name="newLocationAutoId">The new location automatic identifier.</param>
        /// <param name="oldDesignationCode">The old designation code.</param>
        /// <param name="newDesignationCode">The new designation code.</param>
        /// <param name="oldCategoryCode">The old category code.</param>
        /// <param name="newCategoryCode">The new category code.</param>
        /// <param name="oldJobClassCode">The old job class code.</param>
        /// <param name="newJobClassCode">The new job class code.</param>
        /// <param name="oldJobTypeCode">The old job type code.</param>
        /// <param name="newJobTypeCode">The new job type code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="oldRoleCode">The old role code.</param>
        /// <param name="newRoleCode">The new role code.</param>
        /// <param name="oldAreaCode">The old area code.</param>
        /// <param name="newAreaCode">The new area code.</param>
        /// <param name="oldDepartmentCode">The old department code.</param>
        /// <param name="newDepartmentCode">The new department code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CorrectEmployeeCompanyDetails(string employeeNumber, string oldCompanyCode, string newCompanyCode, string oldCompanyCorrectionDate, string newCorrectionDate, string oldHRLocationCode, string newHRLocationCode, string oldLocationAutoId, string newLocationAutoId, string oldDesignationCode, string newDesignationCode, string oldCategoryCode, string newCategoryCode, string oldJobClassCode, string newJobClassCode, string oldJobTypeCode, string newJobTypeCode, string modifiedBy, string oldRoleCode, string newRoleCode, string oldAreaCode, string newAreaCode, string oldDepartmentCode, string newDepartmentCode)
        {
            SqlParameter[] objParam = new SqlParameter[22];
            objParam[0] = new SqlParameter(DL.Properties.Resources.OldCompanyCode, oldCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.OldCompanyCorrectionDate,DL.Common.DateFormat(oldCompanyCorrectionDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.NewCorrectionDate, DL.Common.DateFormat(newCorrectionDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.OldCorrectionDate, oldHRLocationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.NewHrLocation, newHRLocationCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.oldLocationautoid, oldLocationAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.NewLocationAutoID, newLocationAutoId);
            objParam[8] = new SqlParameter(DL.Properties.Resources.OldDesignationCode, oldDesignationCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.NewDesignationCode, newDesignationCode);
            objParam[10] = new SqlParameter(DL.Properties.Resources.OldCategoryCode, oldCategoryCode);
            objParam[11] = new SqlParameter(DL.Properties.Resources.NewCategoryCode, newCategoryCode);
            objParam[12] = new SqlParameter(DL.Properties.Resources.OldJobClassCode, oldJobClassCode);
            objParam[13] = new SqlParameter(DL.Properties.Resources.NewJobClassCode, newJobClassCode);
            objParam[14] = new SqlParameter(DL.Properties.Resources.OldJobTypeCode, oldJobTypeCode);
            objParam[15] = new SqlParameter(DL.Properties.Resources.NewJobTypeCode, newJobTypeCode);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[17] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[18] = new SqlParameter(DL.Properties.Resources.OldRoleCode, oldRoleCode);
            objParam[19] = new SqlParameter(DL.Properties.Resources.NewRoleCode, newRoleCode);
            objParam[20] = new SqlParameter(DL.Properties.Resources.OldAreaCode, oldAreaCode);
            objParam[21] = new SqlParameter(DL.Properties.Resources.NewAreaCode, newAreaCode);
            objParam[22] = new SqlParameter(DL.Properties.Resources.OldDepartmentCode, oldDepartmentCode);
            objParam[23] = new SqlParameter(DL.Properties.Resources.NewDepartmentCode, newDepartmentCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeCompanyInterTransfer_CorrectEmployeeCompanyDetails", objParam);
            return ds;
        }
        /// <summary>
        /// Corrects the employee location details.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="newLocationAutoId">The new location automatic identifier.</param>
        /// <param name="oldLocationAutoId">The old location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="newDesignationCode">The new designation code.</param>
        /// <param name="newCategoryCode">The new category code.</param>
        /// <param name="newJobClassCode">The new job class code.</param>
        /// <param name="newJobTypeCode">The new job type code.</param>
        /// <param name="correctionDate">The correction date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="newRoleCode">The new role code.</param>
        /// <param name="newAreaCode">The new area code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CorrectEmployeeLocationDetails(string companyCode, string hrLocationCode, int newLocationAutoId, int oldLocationAutoId, string employeeNumber, string newDesignationCode, string newCategoryCode, string newJobClassCode, string newJobTypeCode, string correctionDate, string modifiedBy, string newRoleCode, string newAreaCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocation, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.NewLocationAutoID, newLocationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.oldLocationautoid, oldLocationAutoId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[5] = new SqlParameter(DL.Properties.Resources.NewDesignationCode, newDesignationCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.NewCategoryCode, newCategoryCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.NewJobClassCode, newJobClassCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.NewJobTypeCode, newJobTypeCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.CorrectionDate, correctionDate);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[11] = new SqlParameter(DL.Properties.Resources.NewRoleCode, newRoleCode);
            objParam[12] = new SqlParameter(DL.Properties.Resources.NewAreaCode, newAreaCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeCompanyInterTransfer_CorrectEmployeeLocationDetails", objParam);
            return ds;
        }

        /// <summary>
        /// Actives the details of employee get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ActiveDetailsOfEmployeeGetAll(string companyCode, int locationAutoId, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EmployeeCompanyInterTransfer_GetAllActiveDetailsOfEmployee", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function related to Mst HrEmployee  Job Type

        #region Function to update MstHrEmployeeJob Type
        /// <summary>
        /// to update MstHrEmployeeJob Type
        /// </summary>
        /// <param name="previousCompanyCode">The previous company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="newEmployeeNumber">The new employee number.</param>
        /// <param name="previousJobTypeCode">The previous job type code.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeJobTypeUpdate(string previousCompanyCode, string employeeNumber, string newEmployeeNumber, string previousJobTypeCode, string jobTypeCode, string effectiveTo, string userId, string newCompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[8];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.NewEmployeeNumber, newEmployeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PrevJobTypeCode, previousJobTypeCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.NewJobTypeCode, jobTypeCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeJobType_Update", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to Mst HrEmployee Job Class
        #region Function related to update Job Class
        /// <summary>
        /// to update Job Class
        /// </summary>
        /// <param name="previousCompanyCode">The previous company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="newEmployeeNumber">The new employee number.</param>
        /// <param name="previousJobClassCode">The previous job class code.</param>
        /// <param name="jobClassCode">The job class code.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeJobClassUpdate(string previousCompanyCode, string employeeNumber, string newEmployeeNumber, string previousJobClassCode, string jobClassCode, string effectiveTo, string userId, string newCompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[8];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.NewEmployeeNumber, newEmployeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PrevJobClassCode, previousJobClassCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.NewJobClassCode, jobClassCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeJobClass_Update", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Employee Termination
        #region Function Related to Terminate Employee
        /// <summary>
        /// to Terminate Employee
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="terminationReason">The termination reason.</param>
        /// <param name="resignationDate">The resignation date.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="suitableForRehire">if set to <c>true</c> [suitable for rehire].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="joiningDate">The joining date.</param>
        /// <param name="previousTotalExperience">The previous total experience.</param>
        /// <returns>Dataset</returns>
        public DataSet TerminateEmployee(string employeeNumber, string reason, string terminationReason, DateTime resignationDate, string remarks, bool suitableForRehire, string modifiedBy, string locationAutoId, string companyCode, DateTime joiningDate, float previousTotalExperience)
        {
            SqlParameter[] objParam = new SqlParameter[11];


            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Reason, reason);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TerminationReason, terminationReason);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ResignationDate, DL.Common.DateFormat(resignationDate, true));
            objParam[4] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[5] = new SqlParameter(DL.Properties.Resources.SuitableForReHire, suitableForRehire);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[8] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.JoiningDate, DL.Common.DateFormat(joiningDate));
            objParam[10] = new SqlParameter(DL.Properties.Resources.PrevTotalExp, previousTotalExperience);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeTermination_TerminateEmployee", objParam);
            return ds;
        }

        /// <summary>
        /// to check if a employee is scheduled or not
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckScheduledEmployee(string employeeNumber, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeTermination_CheckScheduledEmployee", objParam);
            return ds;
        }

        /// <summary>
        /// Terminates the bulk employees.
        /// </summary>
        /// <param name="employeeList">The employee list.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="terminationReason">The termination reason.</param>
        /// <param name="resignationDate">The resignation date.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="suitableForRehire">if set to <c>true</c> [suitable for rehire].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">employeeList</exception>
        public DataSet TerminateBulkEmployees(DataTable employeeList, string reason, string terminationReason, DateTime resignationDate, string remarks, bool suitableForRehire, string modifiedBy)
        {
            if (employeeList == null || employeeList.Rows == null)
            {
                throw new ArgumentNullException("employeeList");
            }

            string strEmpList;
            strEmpList = "";
            if (employeeList.Rows.Count > 0)
            {
                for (int i = 0; i < employeeList.Rows.Count; i++)
                {
                    if (i > 0)
                    {
                        strEmpList = strEmpList + "," + employeeList.Rows[i][0].ToString();
                    }
                    else
                    {
                        strEmpList = strEmpList + employeeList.Rows[i][0].ToString();
                    }
                }
            }


            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumberList, strEmpList);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Reason, reason);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TerminationReason, terminationReason);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ResignationDate, DL.Common.DateFormat(resignationDate, true));
            objParam[4] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[5] = new SqlParameter(DL.Properties.Resources.SuitableForReHire, suitableForRehire);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_BulkEmployeeTermination", objParam);
            return ds;
        }

        #endregion

        #region Function to get max date
        /// <summary>
        /// to get max date
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeTerminationGetMaxDate(string employeeNumber, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeTermination_GetMaxDate", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to Employee ReHire

        #region Function Related to Get all Terminated Employee
        /// <summary>
        /// to Get all Terminated Employee
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet RehiredEmployeeGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeReHire_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function TO Rehire Selected Employee
        /// <summary>
        /// to rehire selected Employee
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dateOfJoining">The date of joining.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="jobClassCode">The job class code.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <param name="remark">The remark.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="role">The role.</param>
        /// <param name="areaid">The areaid.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRehire(string locationAutoId, string employeeNumber, DateTime dateOfJoining, string companyCode, string hrLocationCode, string designationCode, string categoryCode, string jobClassCode, string jobTypeCode, string remark, string modifiedBy, string departmentCode, string role, string areaid)
        {

            SqlParameter[] objParam = new SqlParameter[14];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DateOfJoining, DL.Common.DateFormat(dateOfJoining));
            objParam[3] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.CategoryCode, categoryCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.JobClassCode, jobClassCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.JobTypeCode, jobTypeCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Remarks, remark);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[11] = new SqlParameter(DL.Properties.Resources.DepartmentCode, departmentCode);
            objParam[12] = new SqlParameter(DL.Properties.Resources.RoleCode, role);
            objParam[13] = new SqlParameter(DL.Properties.Resources.AreaId, areaid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHR_EmployeeReHire_ReHireSelectedEmployee", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related To QuickCode
        /// <summary>
        /// Genders the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GenderMasterGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_Gender_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Maritals the status get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MaritalStatusGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_MaritalStatus_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Militaries the status get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MilitaryStatusGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_MilitaryStatus_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Smokers the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SmokerMasterGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_Smoker_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Foods the style master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet FoodStyleMasterGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_FoodStyle_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Religions the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ReligionMasterGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_Religion_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Nationalities the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet NationalityMasterGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_Nationality_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Allowanceses the mode master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowancesModeMasterGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_AllowancesMode_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Skills the type master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SkillTypeMasterGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeeSkillTypes_Get", objParm);
            return ds;
        }

        #endregion

        #region Function Related to EmployeeDepartment

        #region Function Related to GetData
        /// <summary>
        /// Employees the department get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDepartmentGetAll(string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SomLocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeDepartment_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// Employees the department update.
        /// </summary>
        /// <param name="previousCompanyCode">The previous company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="previousDesignationCode">The previous designation code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newCompanyCode">The new company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDepartmentUpdate(string previousCompanyCode, string employeeNumber, string previousDesignationCode, string designationCode, string effectiveTo, string userId, string newCompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.PrevCompanyCode, previousCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PrevDepartmentCode, previousDesignationCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.NewDepartmentCode, designationCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParam[6] = new SqlParameter(DL.Properties.Resources.NewCompanyCode, newCompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeDepartment_Update", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Employee Promotion & Increment

        #region Function Related to GetData
        /// <summary>
        /// Employees the compensation detail get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeCompensationDetailGet(string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeCompensationDetail_Get", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Insert data
        /// <summary>
        /// Employees the compensation detail insert.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="wageRate">The wage rate.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="wageRateFrequency">The wage rate frequency.</param>
        /// <param name="paymentFrequency">The payment frequency.</param>
        /// <param name="contractHours">The contract hours.</param>
        /// <param name="contractHoursFrequency">The contract hours frequency.</param>
        /// <param name="increment">The increment.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeCompensationDetailInsert(string employeeNumber, float wageRate, string currency, string wageRateFrequency, string paymentFrequency, float contractHours, string contractHoursFrequency, float increment, string reason, string effectiveFrom, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[11];

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.wageRate, wageRate);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CurrencyCode, currency);
            objParam[3] = new SqlParameter(DL.Properties.Resources.WageRateFrequency, wageRateFrequency);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PaymentFrequency, paymentFrequency);
            objParam[5] = new SqlParameter(DL.Properties.Resources.contractHrs, contractHours);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ContractHrsFrequency, contractHoursFrequency);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Increment, increment);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Reason, reason);
            objParam[9] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpMstHr_CompensationDeatil_Insert", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Employee Availability
        /// <summary>
        /// Employees the availability get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAvailabilityGet(string employeeNumber, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_EmployeeAvailStatus_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the actual availability get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeActualAvailabilityGet(string employeeNumber, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_EmployeeActualAvailStatus_Get", objParam);
            return ds;
        }


        #endregion

        #region Function Related to Barred Assignments 4 Employees

        /// <summary>
        /// Barreds the assignments get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet BarredAssignmentsGet(string companyCode,int locationAutoId, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_BarredAssignments_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Barreds the assignments insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="barredBy">The barred by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="reasonId">The reason auto id.</param>
        /// <returns>DataSet.</returns>
        public DataSet BarredAssignmentsInsert(int locationAutoId, string employeeNumber, string clientCode, string asmtId, string effectiveFrom, string effectiveTo, string modifiedBy, string barredBy,string companyCode ,int reasonId)
        {
            SqlParameter[] objParam = new SqlParameter[10];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.BarredBy, barredBy);
            objParam[8]=new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ReasonAutoID, reasonId);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_BarredAssignments_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// Barreds the assignments update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="barredAutoId">The barred automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="barredBy">The barred by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="reasonId">The reason identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BarredAssignmentsUpdate(int locationAutoId, string employeeNumber, string clientCode, string asmtId, string effectiveFrom, string effectiveTo, string barredAutoId, string modifiedBy, string barredBy, string companyCode, int reasonId)
        {
            SqlParameter[] objParam = new SqlParameter[11];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objParam[6] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParam[7] = new SqlParameter(DL.Properties.Resources.BarredAutoId, barredAutoId);
            objParam[8] = new SqlParameter(DL.Properties.Resources.BarredBy, barredBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ReasonAutoID, reasonId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_BarredAssignments_Update", objParam);
            return ds;
        }

        /// <summary>
        /// Barreds the assignments delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="barredAutoId">The barred automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BarredAssignmentsDelete(string companyCode, int locationAutoId, string employeeNumber, string barredAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.BarredAutoId, barredAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_BarredAssignments_Delete", objParam);
            return ds;
        }

        #endregion

        #region Function Related To Employee Preferances
        /// <summary>
        /// Get all Employee wise Preference Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePreferencesGetAll(int locationAutoId, string employeeNumber, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeePreferences_GetAll", objParam);
            return ds; ;
        }
        /// <summary>
        /// Get all Employeewose Shift Time Details
        /// </summary>
        /// <param name="shift">The shift.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePreferencesGetTimeDetails(string shift, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Shift, shift);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeePreferences_GetTimeDetails", objParam);
            return ds; ;
        }
        /// <summary>
        /// Insert Employee wise Preference details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="shiftPreference">The shift preference.</param>
        /// <param name="sunday">if set to <c>true</c> [sunday].</param>
        /// <param name="monday">if set to <c>true</c> [monday].</param>
        /// <param name="tuesday">if set to <c>true</c> [tuesday].</param>
        /// <param name="wednesday">if set to <c>true</c> [wednesday].</param>
        /// <param name="thursday">if set to <c>true</c> [thursday].</param>
        /// <param name="friday">if set to <c>true</c> [friday].</param>
        /// <param name="saturday">if set to <c>true</c> [saturday].</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="daysPreference">if set to <c>true</c> [days preference].</param>
        /// <param name="shiftTimePreference">if set to <c>true</c> [shift time preference].</param>
        /// <param name="sitePreference">if set to <c>true</c> [site preference].</param>
        /// <param name="alertSitePreference">if set to <c>true</c> [alert site preference].</param>
        /// <param name="alertShiftTimePreference">if set to <c>true</c> [alert shift time preference].</param>
        /// <param name="alertDaysPreference">if set to <c>true</c> [alert days preference].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="minimumShift">The minimum shift.</param>
        /// <param name="maximumShift">The maximum shift.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePreferencesInsert(string locationAutoId, string employeeNumber, string asmtId, string shiftPreference, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, DateTime timeFrom, DateTime timeTo, bool daysPreference, bool shiftTimePreference, bool sitePreference, bool alertSitePreference, bool alertShiftTimePreference, bool alertDaysPreference, string modifiedBy, string minimumShift, string maximumShift,string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[23];

            Guard.ArgumentConvertibleTo<int>(minimumShift, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(maximumShift, "myIntArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ShiftPref, shiftPreference);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SUN, sunday);
            objParam[5] = new SqlParameter(DL.Properties.Resources.MON, monday);
            objParam[6] = new SqlParameter(DL.Properties.Resources.TUE, tuesday);
            objParam[7] = new SqlParameter(DL.Properties.Resources.WED, wednesday);
            objParam[8] = new SqlParameter(DL.Properties.Resources.THU, thursday);
            objParam[9] = new SqlParameter(DL.Properties.Resources.FRI, friday);
            objParam[10] = new SqlParameter(DL.Properties.Resources.SAT, saturday);
            objParam[11] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[12] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[13] = new SqlParameter(DL.Properties.Resources.DaysPref, daysPreference);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ShiftTimePref, shiftTimePreference);
            objParam[15] = new SqlParameter(DL.Properties.Resources.SitePref, sitePreference);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[17] = new SqlParameter(DL.Properties.Resources.AlertSitePref, alertSitePreference);
            objParam[18] = new SqlParameter(DL.Properties.Resources.AlertShiftTimePref, alertShiftTimePreference);
            objParam[19] = new SqlParameter(DL.Properties.Resources.AlertDaysPref, alertDaysPreference);
            objParam[20] = new SqlParameter(DL.Properties.Resources.MinShift, int.Parse(minimumShift));
            objParam[21] = new SqlParameter(DL.Properties.Resources.MaxShift, int.Parse(maximumShift));
            objParam[22] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeePreferences_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Update Employeewise Preference details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="shiftPreference">The shift preference.</param>
        /// <param name="sunday">if set to <c>true</c> [sunday].</param>
        /// <param name="monday">if set to <c>true</c> [monday].</param>
        /// <param name="tuesday">if set to <c>true</c> [tuesday].</param>
        /// <param name="wednesday">if set to <c>true</c> [wednesday].</param>
        /// <param name="thursday">if set to <c>true</c> [thursday].</param>
        /// <param name="friday">if set to <c>true</c> [friday].</param>
        /// <param name="saturday">if set to <c>true</c> [saturday].</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="daysPreference">if set to <c>true</c> [days preference].</param>
        /// <param name="shiftTimePreference">if set to <c>true</c> [shift time preference].</param>
        /// <param name="sitePreference">if set to <c>true</c> [site preference].</param>
        /// <param name="alertSitePreference">if set to <c>true</c> [alert site preference].</param>
        /// <param name="alertShiftTimePreference">if set to <c>true</c> [alert shift time preference].</param>
        /// <param name="alertDaysPreference">if set to <c>true</c> [alert days preference].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="minimumShift">The minimum shift.</param>
        /// <param name="maximumShift">The maximum shift.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePreferencesUpdate(string locationAutoId, string employeeNumber, string asmtId, string shiftPreference, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, DateTime timeFrom, DateTime timeTo, bool daysPreference, bool shiftTimePreference, bool sitePreference, bool alertSitePreference, bool alertShiftTimePreference, bool alertDaysPreference, string modifiedBy, string minimumShift, string maximumShift, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[23];

            Guard.ArgumentConvertibleTo<int>(minimumShift, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(maximumShift, "myIntArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ShiftPref, shiftPreference);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SUN, sunday);
            objParam[5] = new SqlParameter(DL.Properties.Resources.MON, monday);
            objParam[6] = new SqlParameter(DL.Properties.Resources.TUE, tuesday);
            objParam[7] = new SqlParameter(DL.Properties.Resources.WED, wednesday);
            objParam[8] = new SqlParameter(DL.Properties.Resources.THU, thursday);
            objParam[9] = new SqlParameter(DL.Properties.Resources.FRI, friday);
            objParam[10] = new SqlParameter(DL.Properties.Resources.SAT, saturday);
            objParam[11] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[12] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[13] = new SqlParameter(DL.Properties.Resources.DaysPref, daysPreference);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ShiftTimePref, shiftTimePreference);
            objParam[15] = new SqlParameter(DL.Properties.Resources.SitePref, sitePreference);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[17] = new SqlParameter(DL.Properties.Resources.AlertSitePref, alertSitePreference);
            objParam[18] = new SqlParameter(DL.Properties.Resources.AlertShiftTimePref, alertShiftTimePreference);
            objParam[19] = new SqlParameter(DL.Properties.Resources.AlertDaysPref, alertDaysPreference);
            objParam[20] = new SqlParameter(DL.Properties.Resources.MinShift, int.Parse(minimumShift));
            objParam[21] = new SqlParameter(DL.Properties.Resources.MaxShift, int.Parse(maximumShift));
            objParam[22] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeePreferences_Update", objParam);
            return ds; ;
        }
        /// <summary>
        /// Delete Employeewise Details
        /// </summary>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePreferencesDelete(string asmtId, string employeeNumber, string locationAutoId,string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeePreferences_Delete", objParam);
            return ds; ;
        }
        #endregion

        #region Function Related to Absconders Screen

        /// <summary>
        /// Absconderses the get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AbscondersGet(int locationAutoId, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_AbsconderEmployees_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Absconderses the delete.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AbscondersDelete(string employeeNumber, string effectiveTo, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EffectiveToDate, DL.Common.DateFormat(effectiveTo, true));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_AbsconderEmployees_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Absconderses the insert.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AbscondersInsert(string employeeNumber, string effectiveFrom, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EffectiveFromDate, DL.Common.DateFormat(effectiveFrom));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_AbsconderEmployees_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Marks the absconders from paysum.
        /// </summary>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MarkAbscondersFromPaysum(string hrLocationCode, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_MarkAbsconders_FromPaysum", objParam);
            return ds;
        }

        #endregion

        #region function Related With Employee Personal Details

        /// <summary>
        /// Employees the personal details get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePersonalDetailsGetAll(string companyCode, string hrLocationCode, string locationCode, string areaId)
        {
            SqlParameter[] objParam = new SqlParameter[4];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeePersonalDetail_Getall", objParam);
            return ds;
        }
        /// <summary>
        /// Rosters the of hr location get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterOfHRLocationGetAll(string companyCode, string hrLocationCode, string fromDate, string toDate)
        {

            SqlParameter[] objParam = new SqlParameter[4];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeesOfHrLocationRotaExist_GetAll", objParam);
            return ds;
        }
        #endregion

        #region function Related With PlanningEfficiencyTool

        /// <summary>
        /// Hourses the details get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursDetailsGetAll(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Hours_calculation", objParam);
            return ds;
        }



        /// <summary>
        /// Hourses the details graph get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursDetailsGraphGetAll(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Hours_calculation_graph", objParam);
            return ds;
        }

        #endregion

        #region Function Related to Employee Nationality
        #region Function Related to GetData
        /// <summary>
        /// Employees the nationality get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNationalityGetAll(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_EmployeeNationality_GetAll", objParam);
            return ds;
        }
        #endregion


        #endregion
        
        #region Function Related To Employee Leave

        /// <summary>
        /// Employees the leave unit get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveType">Type of the leave.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeLeaveUnitGet(string companyCode, string employeeNumber, string leaveType, string fromDate, string toDate, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[6];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeCode, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LeaveType, leaveType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Get_EmployeeLeaveUnit", objParam);
            return ds;
        }

        #endregion

        #region Function Related To Employee Leave BreakDown Report
        /// <summary>
        /// Leave BreakDown Report
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="LocationAutoID">The location automatic identifier.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="EmpNo">The emp no.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveBreakDownReportGet(string companyCode, string LocationAutoID, string leaveCode, string fromDate, string toDate, string EmpNo)
        {
            SqlParameter[] objParam = new SqlParameter[6];

            objParam[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoID);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.EmpNo, EmpNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpLeaveTakenWithSubLeaveType", objParam);
            return ds;
        }

        #endregion

        #region Function Related to Employee Constraint

        /// <summary>
        /// Employees the constraint get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeConstraintGetAll(string companyCode, string employeeNumber)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeConstraint_GetAll", objParm);
            return ds;
        }
        /// <summary>
        /// Employees the constraint update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="employeeConstraintAutoId">The employee constraint automatic identifier.</param>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeConstraintUpdate(string companyCode, string employeeNumber, string employeeConstraintAutoId, string constraintTypeAutoId, string constraintAutoId, string value, string remarks, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeConstraintAutoId, employeeConstraintAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeConstraint_Update", objParm);
            return ds;
        }

        /// <summary>
        /// Employees the constraint insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeConstraintInsert(string companyCode, string employeeNumber, string constraintTypeAutoId, string constraintAutoId, string value, string remarks, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[5] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeConstraint_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// Employees the constraint delete.
        /// </summary>
        /// <param name="employeeConstraintAutoId">The employee constraint automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeConstraintDelete(string employeeConstraintAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeConstraintAutoId, employeeConstraintAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeConstraint_Delete", objParm);
            return ds;
        }
        #endregion

        #region Function related to Employee Compensation History

        /// <summary>
        /// Compensations the history get by component.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="component">The component.</param>
        /// <returns>DataSet.</returns>
        public DataSet CompensationHistoryGetByComponent(string employeeNumber, string companyCode, string component)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ComponentCode, component);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_CompensationHistory_GetByComponent", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the default effective from date get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="component">The component.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDefaultEffectiveFromDateGet(string companyCode, string employeeNumber, string component)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ComponentCode, component);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_DefaultEffectiveFromDate_GetForAnEmployee", objParam);
            return ds;
        }

        /// <summary>
        /// Saves the in modify correct.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="component">The component.</param>
        /// <param name="percentage">The percentage.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="value">The value.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="percentage1">The percentage1.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaveInModifyCorrect(string companyCode, string employeeNumber, string component, string percentage, string frequency, string value, string currency, string percentage1, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ComponentCode, component);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Percentage, percentage);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Frequency, frequency);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Currency, currency);
            objParam[7] = new SqlParameter(DL.Properties.Resources.PercentageOf, percentage1);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_EmpCompensationHistory_SaveInModify_Correct", objParam);
            return ds;
        }

        /// <summary>
        /// Saves the in modify update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="component">The component.</param>
        /// <param name="percentage">The percentage.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="value">The value.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="percentage1">The percentage1.</param>
        /// <param name="updateEffectiveFrom">The update effective from.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaveInModifyUpdate(string companyCode, string employeeNumber, string component, string percentage, string frequency, string value, string currency, string percentage1, DateTime updateEffectiveFrom, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ComponentCode, component);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Percentage, percentage);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Frequency, frequency);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Currency, currency);
            objParam[7] = new SqlParameter(DL.Properties.Resources.PercentageOf, percentage1);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, updateEffectiveFrom);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_EmpCompensationHistory_SaveInModify_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Calls the Proc udp_checkeffectivefromdate
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="updateEffectiveFrom">The update effective from.</param>
        /// <returns>DataTable.</returns>
        public DataTable CheckEffectiveFrom(string companyCode, string employeeNumber, DateTime updateEffectiveFrom)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, updateEffectiveFrom);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_checkeffectivefromdate", objParam);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        /// <summary>
        /// Saves the in add insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="component">The component.</param>
        /// <param name="percentage">The percentage.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="value">The value.</param>
        /// <param name="currency">The currency.</param>
        /// <param name="percentage1">The percentage1.</param>
        /// <param name="addEffectiveFrom">The add effective from.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaveInAddInsert(string companyCode, string employeeNumber, string component, string percentage, string frequency, string value, string currency, string percentage1, DateTime addEffectiveFrom, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ComponentCode, component);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Percentage, percentage);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Frequency, frequency);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Currency, currency);
            objParam[7] = new SqlParameter(DL.Properties.Resources.PercentageOf, percentage1);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, addEffectiveFrom);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_EmpCompensationHistory_SaveInAdd_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Saves the in modify disable.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="component">The component.</param>
        /// <param name="wefDate">The wef date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaveInModifyDisable(string companyCode, string employeeNumber, string component, DateTime wefDate, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ComponentCode, component);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, wefDate);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_EmpCompensationHistory_SaveInModify_Disable", objParam);
            return ds;
        }
        /// <summary>
        /// Added by  on 3-nov-2011 for getting employee distinct contractual days
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeContractualDaysGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_EmployeeContractualDaysType_Get", objParam);
            return ds;
        }


        #endregion

        #region Function Related to Employee Address

        /// <summary>
        /// Employees the address get by employee code.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="typeOfAddress">The type of address.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAddressGetByEmployeeCode(string employeeNumber, string companyCode, string typeOfAddress)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            //Guard.ArgumentConvertibleTo<int>(typeOfAddress, "myIntArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TypeOfAddress, typeOfAddress);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_EmployeeAddress_GetByEmployeeCode", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the address insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="addressType">Type of the address.</param>
        /// <param name="address1">The address1.</param>
        /// <param name="address2">The address2.</param>
        /// <param name="address3">The address3.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="phone1">The phone1.</param>
        /// <param name="phone2">The phone2.</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <param name="contactPerson">The contact person.</param>
        /// <param name="communicationChannel">The communication channel.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeAddressInsert(string companyCode, string employeeNumber, string addressType, string address1, string address2, string address3, string city, string state, string pin, string countryCode, string phone1, string phone2, string emailId, string fax, string mobileNumber, string contactPerson, string communicationChannel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[18];

            //Guard.ArgumentConvertibleTo<int>(addressType, "myIntArgument");
            //Guard.ArgumentConvertibleTo<int>(communicationChannel, "myIntArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TypeOfAddress, addressType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AddressLine1, address1);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AddressLine2, address2);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AddressLine3, address3);
            objParam[6] = new SqlParameter(DL.Properties.Resources.City, city);
            objParam[7] = new SqlParameter(DL.Properties.Resources.State, state);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParam[9] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Phone1, phone1);
            objParam[11] = new SqlParameter(DL.Properties.Resources.Phone2, phone2);
            objParam[12] = new SqlParameter(DL.Properties.Resources.Email, emailId);
            objParam[13] = new SqlParameter(DL.Properties.Resources.FaxNumber, fax);
            objParam[14] = new SqlParameter(DL.Properties.Resources.MobileNumber, mobileNumber);
            objParam[15] = new SqlParameter(DL.Properties.Resources.ContactPerson, contactPerson);
            objParam[16] = new SqlParameter(DL.Properties.Resources.PrefChannelComm, communicationChannel);
            objParam[17] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_EmployeeAddress_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Maximums the date get.
        /// </summary>
        /// <param name="locationEffectiveFrom">The location effective from.</param>
        /// <param name="designationEffectiveFrom">The designation effective from.</param>
        /// <param name="categoryEffectiveFrom">The category effective from.</param>
        /// <param name="employeeJobTypeEffectiveFrom">The employee job type effective from.</param>
        /// <param name="employeeJobClassEffectiveFrom">The employee job class effective from.</param>
        /// <param name="dateRoleEffectiveFrom">The date role effective from.</param>
        /// <param name="dateAreaEffectiveFrom">The date area effective from.</param>
        /// <param name="dateDeptEffectiveFrom">The date dept effective from.</param>
        /// <returns>DataSet.</returns>
        public DataSet MaxDateGet(DateTime locationEffectiveFrom, DateTime designationEffectiveFrom, DateTime categoryEffectiveFrom, DateTime employeeJobTypeEffectiveFrom, DateTime employeeJobClassEffectiveFrom, DateTime dateRoleEffectiveFrom, DateTime dateAreaEffectiveFrom, DateTime dateDeptEffectiveFrom)
        {
            SqlParameter[] objParam = new SqlParameter[8];

            objParam[0] = new SqlParameter(DL.Properties.Resources.Date + "1", locationEffectiveFrom);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Date + "2", designationEffectiveFrom);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Date + "3", categoryEffectiveFrom);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Date + "4", employeeJobTypeEffectiveFrom);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Date + "5", employeeJobClassEffectiveFrom);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Date + "6", dateRoleEffectiveFrom);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Date + "7", dateAreaEffectiveFrom);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Date + "8", dateDeptEffectiveFrom);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_GetMaxDateFromListDate", objParam);
            return ds;
        }

        #endregion

        #region Function to check if Employee Belongs to the location or not

        /// <summary>
        /// Checks if the Employee belongs to the Location or Not
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet IsValidUser(string locationAutoId, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset("udp_ValidateEmployeeCode", objParam);
            return ds;
        }
        #endregion

        #region Training
        /// <summary>
        /// Employees the training details insert.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="validTillDate">The valid till date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeTrainingDetailsInsert(string employeeNumber, string companyCode, string trainingCode, string duration, string modifiedBy, DateTime trainingDate, DateTime validTillDate)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Duration, duration);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TrainingDate, trainingDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ValidTillDate, validTillDate);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeTrainingDetails_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// Refreshers the training details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RefresherTrainingDetailsGet(string companyCode, string trainingCode, string employeeNumber, DateTime trainingDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingDate, trainingDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_RefresherTrainingDetails_GetForSelectedTraining", objParam);
            return ds;
        }
        /// <summary>
        /// Employees the refresher training details update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingAutoId">The training automatic identifier.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="trainingRefreshmentDate">The training refreshment date.</param>
        /// <param name="actualTrainingDate">The actual training date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRefresherTrainingDetailsUpdate(string companyCode, string trainingAutoId, string trainingCode, string employeeNumber, DateTime trainingDate, DateTime trainingRefreshmentDate, DateTime actualTrainingDate, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingAutoID, trainingAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TrainingDate, trainingDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.RefTrainingDate, trainingRefreshmentDate);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ActualTrainingDate, actualTrainingDate);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmpRefresherTrainingDetails_Update", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Swap Duty
        /// <summary>
        /// To Get Employee Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MstHrEmployeeDetailGetSelected(string locationAutoId, string dutyDate, string clientCode, string asmtId, string postCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, long.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHr_EmployeeDetail_GetSelected", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Employees for Schedule By EMail Report by 
        /// Based on Area Incharge, Area ID, Client, Assignment and Week No Selected
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameGetAllBasedOnClientAsmtInchargeAreaIdForSelectedWeek(string locationAutoId, string areaIncharge, string areaId, string fromDate, string toDate, string clientCode, string asmtCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_EmployeeGet_BasedOnClientAsmtInchargeAreaId_ForSelectedWeek", objParam);
            return ds;
        }

        /// <summary>
        /// To Send EMail Employees for Schedule by 
        /// Based on Area Incharge, Area ID, Client, Assignment and Week No Selected
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet SendScheduleForEmployeeBasedOnClientAsmtInchargeAreaIdForSelectedWeek(string locationAutoId, string areaIncharge, string areaId, string fromDate, string toDate, string clientCode, string asmtCode, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SendScheduleForEmployee_BasedOnClientAsmtInchargeAreaId_ForSelectedWeek", objParam);
            return ds;
        }
        /// <summary>
        /// calls Email Sending SP
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="schof">The schof.</param>
        /// <param name="emailopening">The emailopening.</param>
        /// <param name="emailgreeting">The emailgreeting.</param>
        /// <param name="emailclosing">The emailclosing.</param>
        /// <returns>DataSet.</returns>
        public DataSet CallEmailSP(string html, string locationAutoId, string areaIncharge, string areaId, string fromDate, string toDate, string clientCode, string asmtCode, string employeeNumber,string schof,string emailopening,string emailgreeting,string emailclosing)
        {

            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ParamDataType, html);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Scheduleof,schof);
            objParam[10] = new SqlParameter(DL.Properties.Resources.EmailOpening,emailopening);
            objParam[11] = new SqlParameter(DL.Properties.Resources.EmailGreeting,emailgreeting);
            objParam[12] = new SqlParameter(DL.Properties.Resources.EmailClosing,emailclosing);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpCallEmailSP", objParam);
            return ds;
             
        }



        /// <summary>
        /// Export To Excel Finctionality In Training Reports
        /// </summary>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="nDays">The n days.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="eType">Type of the e.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ExportHrReportsToExcel(string areaId, string fromDate, string nDays, string locationCode, string hrLocationCode, string clientCode, string asmtCode, string areaIncharge, string employeeNumber, string trainingCode, string companyCode, string locationAutoId, string userId, string eType, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[15];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.nDays, int.Parse(nDays));
            objParam[3] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[9] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[10] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[11] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ReportType, eType);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HrReportsExport", objParam);
            return ds;
        }

        #endregion

        /// <summary>
        /// Gets the schedule list emp wise.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="validTillDate">The valid till date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetScheduleListEmpWise(string employeeNumber, string trainingCode, string validTillDate)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(validTillDate));
            

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CheckScheduleTrainingGet", objParam);
            return ds;
        }

        /// <summary>
        /// Trainings the re activation.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="validTillDate">The valid till date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingReActivation(string companyCode, string trainingCode, string employeeNumber, DateTime trainingDate, DateTime validTillDate, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingDate, trainingDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ValidTillDate, validTillDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UDP_ValidateTrainingReactivation", objParam);
            return ds;
        }

    }
}
