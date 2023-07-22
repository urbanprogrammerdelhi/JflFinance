// ***********************************************************************
// Assembly         : BL
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
using System.Security.Cryptography;
//blEmployeeDetail_GetAll
/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class HRManagement.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class HRManagement
    {
        #region Function Related to EmployeeCategory

        #region Function Related to Get Data

        /// <summary>
        /// Employees the category get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeCategoryGetAll(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeCategoryGetAll(companyCode, hrLocationCode, locationCode);
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

            DL.HRManagement objdlHRManagement = new DL.HRManagement();
            DataSet ds = objdlHRManagement.EmployeeCategoryUpdate(previousCompanyCode, employeeNumber, newEmployeeNumber, previousCategoryCode, categoryCode, effectiveTo, userId, newCompanyCode);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeRoleGetAll(companyCode, hrLocationCode, locationCode);
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

            DL.HRManagement objdlHRManagement = new DL.HRManagement();
            DataSet ds = objdlHRManagement.EmployeeRoleUpdate(previousCompanyCode, employeeNumber, newEmployeeNumber, previousRoleCode, roleCode, effectiveTo, userId, newCompanyCode);
            return ds;
        }

        #endregion

        #endregion

        #region Function Related to EmployeeDesignation

        #region Function Related to Get Data

        /// <summary>
        /// Employees the designation get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDesignationGetAll(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeDesignationGetAll(companyCode, hrLocationCode, locationCode);
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

            DL.HRManagement objdlHRManagement = new DL.HRManagement();
            DataSet ds = objdlHRManagement.EmployeeDesignationUpdate(previousCompanyCode, employeeNumber, newEmployeeNumber, previousDesignationCode, designationCode, effectiveTo, userId, newCompanyCode);
            return ds;
        }
        #endregion
        #endregion
        #region Function related to Employee Grade
        public DataSet EmployeeGradeUpdate(string previousCompanyCode, string employeeNumber, string newEmployeeNumber, string previousDesignationCode, string designationCode, string effectiveTo, string userId, string newCompanyCode,string oldGradeCode,string GradeCode)
        {

            DL.HRManagement objdlHRManagement = new DL.HRManagement();
            DataSet ds = objdlHRManagement.EmployeeGradeUpdate(previousCompanyCode, employeeNumber, newEmployeeNumber, previousDesignationCode, designationCode, effectiveTo, userId, newCompanyCode, oldGradeCode, GradeCode);
            return ds;
        }
        #endregion

        #region Function Related to EmployeeHrLocation
        #region Function Related to Get Data
        /// <summary>
        /// Return Employees of hrs location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>name,number,designation</returns>
        public DataSet EmployeesOfHRLocationGetAll(string companyCode, string hrLocationCode)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeesOfHRLocationGetAll(companyCode, hrLocationCode);
            return ds;
        }
        /// <summary>
        /// Employeeses the of hr location get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="date">The date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesOfHRLocationGetAll(string companyCode, string hrLocationCode, string date)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeesOfHRLocationGetAll(companyCode, hrLocationCode, date);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeesScheduleGet(companyCode, hrLocationCode, locationCode, fromDate, toDate, areaId, areaIncharge, isAreaIncharge);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to EmployeeLocation

        #region Function Related to Get Data

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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeesOfLocationGetAll(locationCode, hrLocationCode, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// To Get Employees based on Location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesOfLocationGetAll(string companyCode, string hrLocationCode, string locationCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeesOfLocationGetAll(locationCode, hrLocationCode, locationCode);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeesOfLocationAreaWiseGet(companyCode, hrLocationCode, locationCode, fromDate, toDate, areaId, areaIncharge, isAreaIncharge);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeesOfLocationAreaWiseGetForTraining(companyCode, hrLocationCode, locationCode, fromDate, toDate, areaId, areaIncharge, isAreaIncharge);
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

            DL.HRManagement objdlHRManagement = new DL.HRManagement();
            DataSet ds = objdlHRManagement.EmployeeLocationUpdate(previousCompanyCode, locationAutoId, employeeNumber, newEmployeeNumber, futureLocationId, effectiveTo, userId, newCompanyCode, comment);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to EmployeeMaster

        #region Function Related to Get Personal Details
        /// <summary>
        /// to Get Personal Details
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet PersonalDetailsGet(string companyCode, string employeeNumber)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.PersonalDetailsGet(companyCode, employeeNumber);
            return ds;
        }
        #endregion

        #region Function Related to Insert personal Data
        /// <summary>
        /// to Insert Employee personal Data
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
        /// <param name="classCode">The class code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="identificationNumber">The identification number.</param>
        /// <param name="identificationType">Type of the identification.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="employeeOldNo">The employee old no.</param>
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
        /// <param name="Disability">the Disability</param>
        /// <param name="Identificationmark">Identification mark</param>
        /// <returns>DataSet.</returns>
        public DataSet PersonalDetailsInsert(string companyCode, DateTime dateOfBirth, string firstName, string lastName, string height, float weight, string gender, string maritalStatus, string nationality, string state, string address, string contactNumber, string religion, string militaryStatus, string smoker, string vegetarian, float previousExperience, DateTime dateOfJoining, string designationCode,string gradeCode, string categoryCode, string userId, string classCode, string areaId, string jobTypeCode, string roleCode, string locationAutoId, string identificationNumber, string identificationType, string employeeNumber, string employeeOldNo, string departmentCode, DataTable otherInformation, string wageRate, string currency, string wageRateFrequency, string paymentFrequency, float contractHours, string contractHoursFrequency, string modifiedBy, string otherLanguageFirstName, string otherLanguageLastName, string contractDays, string otEntitlement, string otDate, string status, string statusDesc, string statusDate, string scaleCode, string scaleDesc, string Bloodgroup, string Identificationmark, string Disability)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();

            DataSet ds = objHrMgmt.PersonalDetailsInsert(companyCode, dateOfBirth, firstName, lastName, height, weight, gender, maritalStatus, nationality, state, address, contactNumber, religion, militaryStatus, smoker, vegetarian, previousExperience, dateOfJoining, designationCode,gradeCode, categoryCode, userId, classCode, areaId, jobTypeCode, roleCode, locationAutoId, identificationNumber, identificationType, employeeNumber, employeeOldNo, departmentCode, otherInformation, wageRate, currency, wageRateFrequency, paymentFrequency, contractHours, contractHoursFrequency, modifiedBy, otherLanguageFirstName, otherLanguageLastName, contractDays, otEntitlement, otDate, status, statusDesc, statusDate, scaleCode, scaleDesc, Bloodgroup, Identificationmark, Disability);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeDocumentDownload(employeeNumber);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeDocumentUpload(employeeNumber, uploadDesc, fileName, modifiedBy);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeDocumentDelete(fileName, employeeNumber);
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
            DL.HRManagement objHRManagement = new DL.HRManagement();

            DataSet ds = objHRManagement.EmployeeMultilingualDetailInsert(employeeNumber, otherLanguageFirstName, otherLanguageLastName, modifiedBy, companyCode);
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
            DL.HRManagement objHRManagement = new DL.HRManagement();

            DataSet ds = objHRManagement.EmployeeMultilingualDetailGet(employeeNumber, companyCode);
            return ds;
        }
        #endregion

        #region Function related to Fill Department ComboBox  based on companyCode
        /// <summary>
        /// to Fill Department ComboBox  based on companyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DepartmentGet(string companyCode)
        {
            DL.HRManagement objdlHrManagement = new DL.HRManagement();

            DataSet ds = objdlHrManagement.DepartmentGet(companyCode);
            return ds;
        }
        #endregion

        #region Function Related To Employee Details

        #region Function Related to get Employee Details
        /// <summary>
        /// To get Employee Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDetailGet(string locationAutoId, string areaId, string areaIncharge, string isIncharge, string fromDate, string toDate)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeDetailGet(locationAutoId, areaId, areaIncharge, isIncharge, fromDate, toDate);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeNameAndNumberSearch(value, locationAutoId);
            return ds;
        }
        /// <summary>
        /// TO search employee details based on different condition[Advance Search]
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="employeeNoOperatorValue">The employee no operator value.</param>
        /// <param name="employeeNoLogOperatorValue">The employee no log operator value.</param>
        /// <param name="employeeName">Name of the employee.</param>
        /// <param name="employeeNameOperatorValue">The employee name operator value.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameAndNumberSearch(string employeeNumber, string employeeNoOperatorValue, string employeeNoLogOperatorValue, string employeeName, string employeeNameOperatorValue, string designationCode, string companyCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeNameAndNumberSearch(employeeNumber, employeeNoOperatorValue, employeeNoLogOperatorValue, employeeName, employeeNameOperatorValue, designationCode, companyCode);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeNameAndDesignationGet(employeeNumber, companyCode);
            return ds;
        }
        /// <summary>
        /// Gets the Employees designation and number based on location
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
 
        public DataSet EmployeeDesignationGetLocation(string employeeNumber, string companyCode,string locationAutoID)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeDesignationGetLocation(employeeNumber, companyCode, locationAutoID);
            return ds;
        }
        /// <summary>
        /// Gets the Employees designation
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDesignationGet(string employeeNumber, string companyCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeDesignationGet(employeeNumber, companyCode);
            return ds;
        }

        /// <summary>
        /// To Get Employee id number Based On Employee number and companyCode
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="identificationType">Type of the identification.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIdGet(string employeeNumber, string hrLocationCode, string identificationType)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeIdGet(employeeNumber, hrLocationCode, identificationType);
            return ds;
        }

        /// <summary>
        /// To Get Employee Details based on location AutoId
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDetailsGet(string employeeNumber, string locationAutoId, string asmtCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeDetailsGet(employeeNumber, locationAutoId, asmtCode);
            return ds;
        }
        /// <summary>
        /// To get Employee name in EmployeeWise Scheduling report
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameGetAll(string locationAutoId)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeNameGetAll(locationAutoId);
            return ds;
        }
        /// <summary>
        /// To get Employee name Area And Location Wise
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameAreaWiseGetAll(string locationAutoId, string areaId)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeNameAreaWiseGetAll(locationAutoId, areaId);
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
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.AreaInchargeGet(companyCode, employeeNumber);
            return ds;
        }
        /// <summary>
        /// To Get AreaIncharge Details Based on UserID
        /// </summary>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="userid">The userid.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGetBasedonUserID(String LocationAutoId, String employeeNumber, String userid)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.AreaInchargeGetBasedonUserID(LocationAutoId, employeeNumber, userid);
            return ds;
        }
        /// <summary>
        /// Employees the name and number get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameAndNumberGetAll(string companyCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeNameAndNumberGetAll(companyCode);
            return ds;
        }
        /// <summary>
        /// Employees the name number get4 location.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameNumberGet4Location(string locationAutoId)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeNameNumberGet4Location(locationAutoId);
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

            DL.HRManagement objdlHRManagement = new DL.HRManagement();
            DataSet ds = objdlHRManagement.EmployeeAreaUpdate(previousCompanyCode, employeeNumber, previousAreaCode, areaCode, effectiveTo, userId, newCompanyCode);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.RosterEmployeeGetAll(locationAutoId, startDate, endDate);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.RosterEmployeeGetAbsentEmployee(companyCode, hrLocationCode, locationCode, startDate, endDate);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeDetailUpdate(employeeNumber, locationAutoId);
            return ds;
        }
        #endregion

        #region Function to Update Employee Details
        /// <summary>
        /// To update Employee Details
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
        /// <param name="employeeOldNumber">The employee old number.</param>
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
        /// <param name="Disability">the Disability</param>
        /// <param name="Identificationmark">Identification mark</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeDetailUpdate(string companyCode, DateTime dateOfBirth, string firstName, string lastName, string height, float weight, string gender, string maritalStatus, string nationality, string state, string address, string contactNumber, string religion, string militaryStatus, string smoker, string vegetarian, float previousExperience, DateTime dateOfJoining, string userId, string identificationNumber, string identificationType, string employeeNumber, string employeeOldNumber, string wageRate, string currency, string wageRateFrequency, string paymentFrequency, float contractHours, string contractHoursFrequency, string contractDays, string otEntitlement, string otDate, string status, string statusDesc, string statusDate, string scaleCode, string scaleDesc, string Bloodgroup, string Identificationmark, string Disability)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeDetailUpdate(companyCode, dateOfBirth, firstName, lastName, height, weight, gender, maritalStatus, nationality, state, address, contactNumber, religion, militaryStatus, smoker, vegetarian, previousExperience, dateOfJoining, userId, identificationNumber, identificationType, employeeNumber, employeeOldNumber, wageRate, currency, wageRateFrequency, paymentFrequency, contractHours, contractHoursFrequency, contractDays, otEntitlement, otDate, status, statusDesc, statusDate, scaleCode, scaleDesc, Bloodgroup, Identificationmark, Disability);
            return ds;
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeAdditionalDetailInsert(companyCode, employeeNumber, rate, jobCode, additionType, otDayCode, otDayDesc, otNightCode, otNightDesc, withoutExtra, moneyExtraType, total, totalType, time, workHours, symbol, modifiedBy);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeAdditionalDetailDelete(companyCode, employeeNumber);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeAdditionalDetailGet(companyCode, employeeNumber);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.GenerateEmployeeCode(sequenceField);
            return ds;
        }
        #endregion

        #region Function Related to HrEmployeeTraining

        #region Function Related To get training Details based on company and employeenumber
        /// <summary>
        /// To get training Details based on company and employeenumber
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>dataset</returns>
        public DataSet EmployeeTrainingGet(string companyCode, string employeeNumber)
        {


            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeTrainingGet(companyCode, employeeNumber);
            return ds;
        }
        /// <summary>
        /// To Deactive Employee Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="validTillDate">The Valid Till date old</param>
        /// <param name="oldValidTillDate">The old valid till date.</param>
        /// <returns>dataset</returns>
        public DataSet DeactivateEmployee(string companyCode, string employeeNumber, DateTime trainingDate, string trainingCode, string validTillDate, string oldValidTillDate)
        {
            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.DeactivateEmployee(companyCode, employeeNumber,trainingDate, trainingCode,validTillDate,oldValidTillDate);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeTrainingGet(trainingCode);
            return ds;
        }
        #endregion

        #region Function Related to Insert Data
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeTrainingInsert(employeeNumber, trainingCode, duration, newTrainingDate, newValidTillDate, modifiedBy, companyCode);
            return ds;
        }

        /// <summary>
        /// Trainings the valid to date get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="newTrainingCode">The new training code.</param>
        /// <param name="newTrainingDate">The new training date.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingValidToDateGet(string companyCode, string newTrainingCode, DateTime newTrainingDate)
        {

            DL.HRManagement objTraining = new DL.HRManagement();
            DataSet ds = objTraining.TrainingValidToDateGet(companyCode, newTrainingCode, newTrainingDate);
            return ds;
        }


        #endregion

        #region Function Related To Delete Data
        /// <summary>
        /// todelete record from mstHrEmployeeTraining
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>dataset</returns>
        public DataSet EmployeeTrainingDelete(string employeeNumber, string trainingCode, DateTime trainingDate, string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeTrainingDelete(employeeNumber, trainingCode, trainingDate, companyCode);
            return ds;
        }

        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update Record in mstHrEmployeeTraining
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="validTillDate">The valid till date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeTrainingUpdate(string employeeNumber, string trainingCode, string duration, DateTime trainingDate, DateTime validTillDate, string modifiedBy, string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeTrainingUpdate(employeeNumber, trainingCode, duration, trainingDate, validTillDate, modifiedBy, companyCode);
            return ds;
        }
        #endregion





        #endregion

        #region Function Related to HrEmployeeQualification

        #region Function related to get QualificationDesc  based on Qualification code
        /// <summary>
        /// to get QualificationDesc  based on Qualification code
        /// </summary>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>dataset</returns>
        public DataSet EmployeeQualificationGet(string qualificationCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeQualificationGet(qualificationCode);
            return ds;
        }
        #endregion

        #region Function Related to Get EmployeeQualification Details based On Employee Number
        /// <summary>
        /// to Get EmployeeQualification Details based On Employee Number
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeQualificationGet(string companyCode, string employeeNumber)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeQualificationGet(companyCode, employeeNumber);
            return ds;
        }
        #endregion

        #region Function Related to Insert DATA
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeQualificationInsert(companyCode, employeeNumber, qualificationCode, modifiedBy);
            return ds;
        }

        #endregion

        #region Function Related to Insert Employewise Id issue and reciept details
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
            DL.HRManagement ObjHrManagement = new DL.HRManagement();

            DataSet ds = ObjHrManagement.IssuedIdReceiptInsert(employeeNumber, idType, purposeOfIssue, dateOfIssue, dateOfReturn, issueRemarks, status, modifiedBy);
            return ds;


        }

        #endregion

        #region Function Related to Update Employewise Id issue and reciept details
        /// <summary>
        /// To Update Employewise Id issue and reciept details
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
            DL.HRManagement ObjHrManagement = new DL.HRManagement();

            DataSet ds = ObjHrManagement.IssuedIdReceiptUpdate(employeeNumber, idType, purposeOfIssue, dateOfIssue, dateOfReturn, issueRemarks, status, modifiedBy);
            return ds;


        }

        #endregion


        #region Function Related to Authorize Employewise Id issue and reciept details
        /// <summary>
        /// To Authorize  Employewise Id issue and reciept details
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IssuedIdReceiptAuthorize(string employeeNumber, string idType, string status, string modifiedBy)
        {
            DL.HRManagement ObjHrManagement = new DL.HRManagement();

            DataSet ds = ObjHrManagement.IssuedIdReceiptAuthorize(employeeNumber, idType, status, modifiedBy);
            return ds;


        }

        #endregion

        #region Function Related to get employee issue detail
        /// <summary>
        /// To Get Employewise Id issue and reciept details
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="idType">Type of the identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIssueDetailGet(string employeeNumber, string idType)
        {
            DL.HRManagement ObjHrManagement = new DL.HRManagement();

            DataSet ds = ObjHrManagement.EmployeeIssueDetailGet(employeeNumber, idType);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeQualificationDelete(companyCode, employeeNumber, qualificationCode);
            return ds;
        }

        #endregion
        #endregion

        #region Function Related  HrEmployeeLanguage Details

        #region Function Related to Get Employee Language Details Based On Company Code And Employeenumber
        /// <summary>
        /// to Get Employee Language Details Based On Company Code And Employeenumber
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeLanguageGet(string companyCode, string employeeNumber)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeLanguageGet(companyCode, employeeNumber);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeLanguageInsert(companyCode, employeeNumber, languageCode, modifiedBy, proficiency, motherTongue);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeLanguageDelete(companyCode, employeeNumber, languageCode);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeLanguageUpdate(companyCode, employeeNumber, languageCode, proficiency, motherTongue, modifiedBy);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to Other Details
        /// <summary>
        /// Get Other Details Like Passport,Id info etc
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeOtherDetailsGet(string employeeNumber)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeOtherDetailsGet(employeeNumber);
            return ds;
        }

        /// <summary>
        /// Employees the identifier type get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeIdTypeGet()
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeIdTypeGet();
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
            DL.HRManagement objHrMgmt = new DL.HRManagement();

            DataSet ds = objHrMgmt.EmployeePassportDetailInsert(employeeNumber, idNumber, idType, dateOfIssue, dateOfExpiry, issuingAuthority, placeOfBirth, remarks, modifiedBy);
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
            DL.HRManagement objHrMgmt = new DL.HRManagement();

            DataSet ds = objHrMgmt.EmployeePassportDetailsDelete(employeeNumber, idType, passPortId);
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
            DL.HRManagement objHrMgmt = new DL.HRManagement();

            DataSet ds = objHrMgmt.EmployeePassportDetailsUpdate(employeeNumber, idNumber, idType, dateOfIssue, dateOfExpiry, issuingAuthority, placeOfBirth, remarks, modifiedBy);
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
            DL.HRManagement objHrMgmt = new DL.HRManagement();

            DataSet ds = objHrMgmt.IsEmployeePassportInformationAlreadyExist(employeeNumber, idTypeCode, idNumber);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.IsEmployeeNumberAlreadyExist(employeeNumber, companyCode);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeSkillsGet(companyCode, employeeNumber);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeSkillsInsert(companyCode, employeeNumber, skillCode, skillDesc, modifiedBy);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeSkillsDelete(companyCode, employeeNumber, skillDesc);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.AreaInchargeNameGet(locationAutoId, areaId);
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
            DL.HRManagement objHrManagement = new DL.HRManagement();
            return objHrManagement.EmployeeWorkHistoryGet(employeeNumber, confirmDuty);
        }
        #endregion

        #region Employee Master New details
        public DataSet GetState()
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.GetState();
            return ds;
        }
        public DataSet GetDistrict(string StateID)
        {
            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.GetDistrict(StateID);
            return ds;
        }

        #region Function related  to Employee Item Issuing Details
       
        public DataSet EmployeeIssuingInsert(string EmployeeNumber, string CompanyCode, int ID, string Item, string GroupID, string SubgroupId, int quantity, string IssueingDate, string ValidityDate, string IssuengBranch, string Issuedby, string ModifiedBy)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.EmployeeIssuingInsert(EmployeeNumber, CompanyCode, ID, Item, GroupID, SubgroupId, quantity, IssueingDate, ValidityDate, IssuengBranch, Issuedby, ModifiedBy);
            return ds;
        }
        public DataSet EmployeeItemIssuingDelete(int ID)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeItemIssuingDelete(ID);
            return ds;
        }
        public DataSet GetItemGroup()
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetItemGroup();
            return ds;
        }
        public DataSet GetEmployeeItemIssuing(string EmployeeNumber)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetEmployeeItemIssuing(EmployeeNumber);
            return ds;
        }
        public DataSet GetItemSubGroup(string GroupID)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetItemSubGroup(GroupID);
            return ds;
        }
        public DataSet GetItems(string SubGroupID)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetItems(SubGroupID);
            return ds;
        }
        public DataSet GetItem()
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetItem();
            return ds;
        }
        #endregion Function related  to Employee Item Issuing Details

        #region Function related to Employee Document Details
        public DataSet EmployeeDocumentDetailGet(string PassportID)
        {
            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeDocumentDetailGet(PassportID);
            return ds;
        }
        public DataSet EmployeeDocumentGet(string PassportID)
        {
            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeDocumentGet(PassportID);
            return ds;
        }
        public DataSet EmployeeDocumentDetailInsert(decimal PassportId, string DocumentDesc, string DocumentFileName, string DocumentFilePath, int IsVerified, string modifiedBy)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.EmployeeDocumentDetailInsert(PassportId, DocumentDesc, DocumentFileName, DocumentFilePath, IsVerified, modifiedBy);
            return ds;
        }
        public DataSet EmployeeDocumentDetailDelete(int ID)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeDocumentDetailDelete(ID);
            return ds;
        }
      
        #endregion Function related to Employee Document Details

        #region Function related  to Employee Education Details
        public DataSet GetEmployeeEducationDetail(string EmployeeNumber)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetEmployeeEducationDetail(EmployeeNumber);
            return ds;
        }
        public DataSet EmplyoyeeEducationdetailDelete(int ID)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmplyoyeeEducationdetailDelete(ID);
            return ds;
        }
        public DataSet EmployeeEducationInsert(int EducationID, string EmployeeNumber, string CompanyCode, string Class, string Specialization, string Grade, string Yearofcompletion, string ModifiedBy, string QualificationCode, string University)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.EmployeeEducationInsert(EducationID, EmployeeNumber, CompanyCode, Class, Specialization, Grade, Yearofcompletion, ModifiedBy, QualificationCode, University);
            return ds;
        }
        #endregion Function related  to Employee Education Details

        #region Function related  to Employee Bank Details
        public DataSet EmployeeBankDetailGet(string employeeNumber)
        {
            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeBankDetailGet(employeeNumber);
            return ds;
        }
        public DataSet EmployeeBankdetailInsert(decimal ID, string BankName, decimal State, decimal District, string Branch, string IFSCCode, string AccountNumber, string AccountName, string ModifiedBy, string EmployeeNumber, string CompanyCode)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeBankdetailInsert(ID, BankName, State, District, Branch, IFSCCode, AccountNumber, AccountName, ModifiedBy, EmployeeNumber, CompanyCode);
            return ds;
        }
        public DataSet EmployeeBankdetailDelete(int ID)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeBankdetailDelete(ID);
            return ds;
        }
        #endregion Function related  to Employee Bank Details

        #region Function related  to Employee Familydetail
        public DataSet EmployeeFamilydetailDelete(int ID)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeFamilydetailDelete(ID);
            return ds;
        }
        public DataSet EmployeeFamilyDetailGet(string employeeNumber)
        {
            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeFamilyDetailGet(employeeNumber);
            return ds;
        }
        public DataSet EmployeeFamilyDetailInsert(string EmployeeNumber, string CompanyCode, int ID, string Relation, string RelationName, string DOB, string Gender, string ModifiedBy)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.EmployeeFamilyDetailInsert(EmployeeNumber, CompanyCode, ID, Relation, RelationName, DOB, Gender, ModifiedBy);
            return ds;
        }
        #endregion Function related  to Employee Familydetail

        #region Function related  to Employee References
        public DataSet GetEmployeeReferenceDetail(string EmployeeNumber)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetEmployeeReferenceDetail(EmployeeNumber);
            return ds;
        }
        public DataSet EmployeeReferenceDetails(string EmployeeNumber, string CompanyCode, int ID, string Name, string Designation, string Area, string RelationshipRefernce, string Organization, string mobile, string ModifiedBy)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeReferenceDetails(EmployeeNumber, CompanyCode, ID, Name, Designation, Area, RelationshipRefernce, Organization, mobile, ModifiedBy);
            return ds;
        }
        public DataSet EmployeeReferenceDetailsDelete(int ID)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeReferenceDetailsDelete(ID);
            return ds;
        }
        #endregion Function related  to Employee References

        #region Function related to Employee Experience
        public DataSet GetEmployeeExperienceDetail(string EmpNo)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetEmployeeExperienceDetail(EmpNo);
            return ds;
        }
        public DataSet EmployeeExperienceDetails(string CompanyCode, string EmployeeNumber, string Designation, string Department, string companyname, string Address, string Fromdate, string Todate, string ModifiedBy, int Experienceid)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeExperienceDetails(CompanyCode, EmployeeNumber, Designation, Department, companyname, Address, Fromdate, Todate, ModifiedBy, Experienceid);
            return ds;
        }
        public DataSet EmplyoyeeExperienceDetailDelete(int ID)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmplyoyeeExperienceDetailDelete(ID);
            return ds;
        }
        #endregion function related to Employee Experience

        #region Function related to Employeee ReferredBy
        public DataSet GetEmployeeRefferedBYDetail(string EmpNo)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.GetEmployeeRefferedBYDetail(EmpNo);
            return ds;
        }
        public DataSet EmployeeReferredBYDetails(string CompanyCode, string EmployeeNumber, string ReferrerNumber, string ReferrerName, string ModifiedBy, int ReferredById)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeReferredBYDetails(CompanyCode, EmployeeNumber, ReferrerNumber, ReferrerName, ModifiedBy, ReferredById);
            return ds;
        }
        public DataSet EmplyoyeeReferredByDetailDelete(int ID)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmplyoyeeReferredByDetailDelete(ID);
            return ds;
        }
        public DataSet SearchEmployee(string EmployeeNumber)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.SearchEmployee(EmployeeNumber);
            return ds;
        }
        #endregion Function related to Employeee ReferredBy

        #region Function realetd to Employee PFandESI
      
        public DataSet EmployeePFandESIInsert(string companyCode, string employeeNumber, string uanNo, string oldUanNo, string esiNo, string oldEsiNo, string pfRegion, string pfOffice, string pfEstablishment, string pfExtension, string pfAccount, string oldPfRegion, string oldPfOffice, string oldPfEstablishment, string oldPfExtension, string oldPfAccount, string ModifiedBy, string ID)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeePFandESIInsert(companyCode, employeeNumber, uanNo, oldUanNo, esiNo, oldEsiNo, pfRegion, pfOffice, pfEstablishment, pfExtension, pfAccount, oldPfRegion, oldPfOffice, oldPfEstablishment, oldPfExtension, oldPfAccount, ModifiedBy, ID);
            return ds;
        }
        public DataSet EmployeePFandESIDetailGet(string employeeNumber)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.EmployeePFandESIDetailGet(employeeNumber);
            return ds;
        }
        public DataSet EmployeePFandESIDetailDelete(string employeeNumber,string companyCode)
        {
            DL.HRManagement objHrMgmt = new DL.HRManagement();
            DataSet ds = objHrMgmt.EmployeePFandESIDetailDelete(employeeNumber, companyCode);
            return ds;
        }
      
        #endregion Function realetd to Employee PFandESI

        #endregion Employee Master New details
        #endregion

        #region Function Related to Employee Transfer Inter Company

        #region Function Related To get Data
        /// <summary>
        /// To get Data
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>Dataset</returns>
        //public DataSet blEmpInterCompanyTransfer_GetAll(string locationAutoId)
        public DataSet AreaInchargeGetAll(string locationAutoId, string areaId, string areaIncharge, string isIncharge, string fromDate, string toDate)
        {

            DL.HRManagement objdlHrManagement = new DL.HRManagement();
            DataSet ds = objdlHrManagement.AreaInchargeGetAll(locationAutoId, areaId, areaIncharge, isIncharge, fromDate, toDate);
            return ds;
        }
        #endregion

        #region Function related to Fill Company ComboBox
        /// <summary>
        /// to Fill Company ComboBox in GridView
        /// </summary>
        /// <returns>Dataset</returns>
        public DataSet EmployeeInterCompanyTransferGetCompany()
        {
            DL.HRManagement objdlHrManagement = new DL.HRManagement();

            DataSet ds = objdlHrManagement.EmployeeIntercompanyTransferGetCompany();
            return ds;
        }
        #endregion

        #region Function related to Fill HrLocation ComboBox
        /// <summary>
        /// to Fill HrLocation ComboBox Based On companyCode in GridView
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeInterCompanyTransferGetHRLocation(string companyCode)
        {
            DL.HRManagement objdlHrManagement = new DL.HRManagement();

            DataSet ds = objdlHrManagement.EmployeeIntercompanyTransferGetHRLocation(companyCode);
            return ds;
        }
        #endregion

        #region Function related to Fill Location ComboBox based on companyCode And HrLocation Code
        /// <summary>
        /// to Fill Location ComboBox in GridView
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>Dataset</returns>
        public DataSet EmployeeInterCompanyTransferGetLocation(string companyCode, string hrLocationCode)
        {
            DL.HRManagement objdlHrManagement = new DL.HRManagement();

            DataSet ds = objdlHrManagement.EmployeeIntercompanyTransferGetLocation(companyCode, hrLocationCode);
            return ds;
        }
        #endregion

        #region Function related to Fill Designation ComboBox based on companyCode
        /// <summary>
        /// to Fill Designation ComboBox based on companyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeInterCompanyTransferGetDesignation(string companyCode)
        {
            DL.HRManagement objdlHrManagement = new DL.HRManagement();

            DataSet ds = objdlHrManagement.EmployeeIntercompanyTransferGetDesignation(companyCode);
            return ds;
        }
        #endregion

        #region Function related to Fill Category ComboBox  based on companyCode
        /// <summary>
        /// to Fill Category ComboBox  based on companyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeInterCompanyTransferGetCategory(string companyCode)
        {
            DL.HRManagement objdlHrManagement = new DL.HRManagement();

            DataSet ds = objdlHrManagement.EmployeeIntercompanyTransferGetCategory(companyCode);
            return ds;
        }
        #endregion

        #region Function Related to Update
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
        /// <returns>Dataset</returns>
        public DataSet EmployeeInterCompanyTransferUpdate(string employeeNumber, string oldCompanyCode, string oldLocationAutoId, string oldDesignation, string oldCategory, string oldJobClass, string oldJobType, string oldRole, string oldAreaId, string oldDepartmentCode, string companyCode, string locationAutoId, string designation, string category, string jobClass, string jobType, string role, string areaId, string departmentCode, string effectiveTo, string modifiedBy, string comment,string oldGradeCode,string GradeCode)
        {
            DL.HRManagement objdlHrManagement = new DL.HRManagement();

            DataSet ds = objdlHrManagement.EmployeeIntercompanyTransferUpdate(employeeNumber, oldCompanyCode, oldLocationAutoId, oldDesignation, oldCategory, oldJobClass, oldJobType, oldRole, oldAreaId, oldDepartmentCode, companyCode, locationAutoId, designation, category, jobClass, jobType, role, areaId, departmentCode, effectiveTo, modifiedBy, comment, oldGradeCode, GradeCode);

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
            DL.HRManagement objdlHrManagement = new DL.HRManagement();

            DataSet ds = objdlHrManagement.GetErrorDetails(employeeNumber, date, locationAutoId);

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
        public DataSet EmployeeInterCompanyTransferGetMaxDate(string companyCode, string employeeNumber)
        {
            DL.HRManagement objdlHrManagement = new DL.HRManagement();
            DataSet ds = objdlHrManagement.EmployeeIntercompanyTransferGetMaxDate(companyCode, employeeNumber);
            return ds;
        }

        #endregion
        #region Function Related To Employee Details Correction

        /// <summary>
        /// To Get Current Effective From Date
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeInterCompanyTransferGetAllEffectiveFromDate(string employeeNumber, string companyCode, int locationAutoId)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();

            DataSet ds = objHRManagement.EmployeeIntercompanyTransferGetAllEffectiveFromDate(employeeNumber, companyCode, locationAutoId);
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
            DL.HRManagement objHRManagement = new DL.HRManagement();

            DataSet ds = objHRManagement.EmployeeTransactionCountGet(employeeNumber, companyCode, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Correct individual Employee Details
        /// </summary>
        /// <param name="company">The company.</param>
        /// <param name="hrLocation">The hr location.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="correctionDate">The correction date.</param>
        /// <param name="oldCorrectionDate">The old correction date.</param>
        /// <param name="newCode">The new code.</param>
        /// <param name="oldCode">The old code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="correctionField">The correction field.</param>
        /// <returns>DataSet.</returns>
        public DataSet CorrectEmployeeJobDetails(string company, string hrLocation, int locationAutoId, string employeeNumber, string correctionDate, string oldCorrectionDate, string newCode, string oldCode, string modifiedBy, string correctionField)
        {

            DL.HRManagement objdlHrManagement = new DL.HRManagement();
            DataSet ds = objdlHrManagement.CorrectEmployeeJobDetails(company, hrLocation, locationAutoId, employeeNumber, correctionDate, oldCorrectionDate, newCode, oldCode, modifiedBy, correctionField);
            return ds;
        }
        /// <summary>
        /// To Get The Histroy Detail Of the Employee
        /// </summary>
        /// <param name="company">The company.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="getField">The get field.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeHistoryDetailGet(string company, int locationAutoId, string employeeNumber, string getField)
        {

            DL.HRManagement objdlHrManagement = new DL.HRManagement();
            DataSet ds = objdlHrManagement.EmployeeHistoryDetailGet(company, locationAutoId, employeeNumber, getField);
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
        /// <param name="newHRLocation">The new hr location.</param>
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
        public DataSet CorrectEmployeeCompanyDetails(string employeeNumber, string oldCompanyCode, string newCompanyCode, string oldCompanyCorrectionDate, string newCorrectionDate, string oldHRLocationCode, string newHRLocation, string oldLocationAutoId, string newLocationAutoId, string oldDesignationCode, string newDesignationCode, string oldCategoryCode, string newCategoryCode, string oldJobClassCode, string newJobClassCode, string oldJobTypeCode, string newJobTypeCode, string modifiedBy, string oldRoleCode, string newRoleCode, string oldAreaCode, string newAreaCode, string oldDepartmentCode, string newDepartmentCode)
        {

            DL.HRManagement objdlHrManagement = new DL.HRManagement();
            DataSet ds = objdlHrManagement.CorrectEmployeeCompanyDetails(employeeNumber, oldCompanyCode, newCompanyCode, oldCompanyCorrectionDate, newCorrectionDate, oldHRLocationCode, newHRLocation, oldLocationAutoId, newLocationAutoId, oldDesignationCode, newDesignationCode, oldCategoryCode, newCategoryCode, oldJobClassCode, newJobClassCode, oldJobTypeCode, newJobTypeCode, modifiedBy, oldRoleCode, newRoleCode, oldAreaCode, newAreaCode, oldDepartmentCode, newDepartmentCode);
            return ds;
        }
        /// <summary>
        /// Corrects the employee location details.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <param name="hrLocation">The hr location.</param>
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
        public DataSet CorrectEmployeeLocationDetails(string company, string hrLocation, int newLocationAutoId, int oldLocationAutoId, string employeeNumber, string newDesignationCode, string newCategoryCode, string newJobClassCode, string newJobTypeCode, string correctionDate, string modifiedBy, string newRoleCode, string newAreaCode)
        {

            DL.HRManagement objdlHrManagement = new DL.HRManagement();
            DataSet ds = objdlHrManagement.CorrectEmployeeLocationDetails(company, hrLocation, newLocationAutoId, oldLocationAutoId, employeeNumber, newDesignationCode, newCategoryCode, newJobClassCode, newJobTypeCode, correctionDate, modifiedBy, newRoleCode, newAreaCode);
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

            DL.HRManagement objdlHrManagement = new DL.HRManagement();
            DataSet ds = objdlHrManagement.ActiveDetailsOfEmployeeGetAll(companyCode, locationAutoId, employeeNumber);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to Encrypt and Decrypt QueryString

        /// <summary>
        /// To Encrypt and decrypt values to be passed in query String
        /// </summary>
        /// <param name="textToEncrypt">The text to encrypt.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentException"></exception>

        private string Encrypt(string textToEncrypt, string encryptionKey)
        {
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray; //Convert.ToByte(textToEncrypt.Length)

            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                throw new ArgumentException(String.Format("Unable to encrypt {0} .", textToEncrypt));
            }
        }


        /// <summary>
        /// Decrypts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public string Decrypt(String value)
        {
            return Decrypt(value, BL.Properties.Resources.specialChars);
        }

        /// <summary>
        /// Encrypts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public string Encrypt(String value)
        {
            return Encrypt(value, BL.Properties.Resources.specialChars);
        }

        /// <summary>
        /// Decrypts the specified text to decrypt.
        /// </summary>
        /// <param name="textToDecrypt">The text to decrypt.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// Decrypts a particular string with a specific Key
        private string Decrypt(string textToDecrypt, string encryptionKey)
        {
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[textToDecrypt.Length];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(textToDecrypt);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch
            {
                throw new ArgumentException(String.Format("Unable to decrypt {0} .", textToDecrypt));
            }
        }

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

            DL.HRManagement objHrmanagement = new DL.HRManagement();
            DataSet ds = objHrmanagement.EmployeeJobTypeUpdate(previousCompanyCode, employeeNumber, newEmployeeNumber, previousJobTypeCode, jobTypeCode, effectiveTo, userId, newCompanyCode);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to Mst HrEmployeeJob Class

        #region Function Related to job Class update
        /// <summary>
        /// Employees the job class update.
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

            DL.HRManagement objHrmanagement = new DL.HRManagement();
            DataSet ds = objHrmanagement.EmployeeJobClassUpdate(previousCompanyCode, employeeNumber, newEmployeeNumber, previousJobClassCode, jobClassCode, effectiveTo, userId, newCompanyCode);
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
            DL.HRManagement objHrManagement = new DL.HRManagement();

            DataSet ds = objHrManagement.TerminateEmployee(employeeNumber, reason, terminationReason, resignationDate, remarks, suitableForRehire, modifiedBy, locationAutoId, companyCode, joiningDate, previousTotalExperience);
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
            DL.HRManagement objHrManagement = new DL.HRManagement();

            DataSet ds = objHrManagement.CheckScheduledEmployee(employeeNumber, locationAutoId);
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
        public DataSet TerminateBulkEmployees(DataTable employeeList, string reason, string terminationReason, DateTime resignationDate, string remarks, bool suitableForRehire, string modifiedBy)
        {
            DL.HRManagement objHrManagement = new DL.HRManagement();

            DataSet ds = objHrManagement.TerminateBulkEmployees(employeeList, reason, terminationReason, resignationDate, remarks, suitableForRehire, modifiedBy);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();

            DataSet ds = objHrManagement.EmployeeTerminationGetMaxDate(employeeNumber, companyCode);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.RehiredEmployeeGetAll(companyCode);
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
        /// <param name="classCode">The class code.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <param name="remark">The remark.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="role">The role.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>Success or Faliure Message</returns>
        public DataSet EmployeeRehire(string locationAutoId, string employeeNumber, DateTime dateOfJoining, string companyCode, string hrLocationCode, string designationCode, string categoryCode, string classCode, string jobTypeCode, string remark, string modifiedBy, string departmentCode, string role,string areaId)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeRehire(locationAutoId, employeeNumber, dateOfJoining, companyCode, hrLocationCode, designationCode, categoryCode, classCode, jobTypeCode, remark, modifiedBy, departmentCode, role,areaId);
            return ds;
        }
        #endregion
        #endregion

        #region Get Employee Detail by employeeNumber
        /// <summary>
        /// to Get Employee Detail
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>Employee Name,desg,DateOfJoin</returns>
        public DataSet EmployeeDetailGet(string employeeNumber, string companyCode, string hrLocationCode, int locationAutoId, string asmtCode, string pdLineNo, string fromDate, string toDate)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeDetailGet(employeeNumber, companyCode, hrLocationCode, locationAutoId, asmtCode, pdLineNo, fromDate, toDate);
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
        /// <param name="areaId">The STR area Id.</param>
        /// <param name="areaIncharge">The STR area incharge.</param>
        /// <param name="isAreaIncharge">The STR is area incharge.</param>
        /// <param name="screenType">Type of the screen.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDetailGet(string employeeNumber, string companyCode, string hrLocationCode, int locationAutoId, string asmtCode, string pdLineNo, string fromDate, string toDate, string postcode, string areaId, string areaIncharge, string isAreaIncharge, string screenType, string modifiedBy)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeDetailGet(employeeNumber, companyCode, hrLocationCode, locationAutoId, asmtCode, pdLineNo, fromDate, toDate, postcode, areaId, areaIncharge, isAreaIncharge, screenType, modifiedBy);
            return ds;
        }
        #endregion

        #region Function Related To QuickCode
        /// <summary>
        /// Genders the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GenderMasterGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.GenderMasterGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Maritals the status get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MaritalStatusGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.MaritalStatusGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Militaries the status get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MilitaryStatusGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.MilitaryStatusGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Smokers the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SmokerMasterGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.SmokerMasterGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Foods the style master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet FoodStyleMasterGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.FoodStyleMasterGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Religions the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ReligionMasterGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.ReligionMasterGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Nationalities the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet NationalityMasterGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.NationalityMasterGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Allowanceses the mode master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowancesModeMasterGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.AllowancesModeMasterGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Skills the type master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SkillTypeMasterGet(string companyCode)
        {

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.SkillTypeMasterGet(companyCode);
            return ds;
        }

        #endregion

        #region Function Related to EmployeeDepartment

        #region Function Related to Get Data

        /// <summary>
        /// Employees the department get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeDepartmentGetAll(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeDepartmentGetAll(companyCode, hrLocationCode, locationCode);
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

            DL.HRManagement objdlHRManagement = new DL.HRManagement();
            DataSet ds = objdlHRManagement.EmployeeDepartmentUpdate(previousCompanyCode, employeeNumber, previousDesignationCode, designationCode, effectiveTo, userId, newCompanyCode);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to EmployeePromotion & Increment

        #region Function Related to Get Data

        /// <summary>
        /// Employees the compensation detail get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeCompensationDetailGet(string employeeNumber)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeCompensationDetailGet(employeeNumber);
            return ds;
        }
        #endregion

        #region Function Related to Insert Data

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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeCompensationDetailInsert(employeeNumber, wageRate, currency, wageRateFrequency, paymentFrequency, contractHours, contractHoursFrequency, increment, reason, effectiveFrom, modifiedBy);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeAvailabilityGet(employeeNumber, fromDate, toDate);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeActualAvailabilityGet(employeeNumber, fromDate, toDate);
            return ds;
        }

        #endregion

        #region Function Related to Barred Assignments  employees

        /// <summary>
        /// Barreds the assignments get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet BarredAssignmentsGet(string companyCode,int locationAutoId, string employeeNumber)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.BarredAssignmentsGet(companyCode,locationAutoId, employeeNumber);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.BarredAssignmentsInsert(locationAutoId, employeeNumber, clientCode, asmtId, effectiveFrom, effectiveTo, modifiedBy, barredBy,companyCode , reasonId);
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
        public DataSet BarredAssignmentsUpdate(int locationAutoId, string employeeNumber, string clientCode, string asmtId, string effectiveFrom, string effectiveTo, string barredAutoId, string modifiedBy, string barredBy,string companyCode ,int reasonId)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.BarredAssignmentsUpdate(locationAutoId, employeeNumber, clientCode, asmtId, effectiveFrom, effectiveTo, barredAutoId, modifiedBy, barredBy, companyCode , reasonId);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.BarredAssignmentsDelete(companyCode, locationAutoId, employeeNumber, barredAutoId);
            return ds;
        }


        #endregion

        #region Function Related To Employee Preferances
        /// <summary>
        /// Gets Employee wise Preference Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePreferencesGetAll(int locationAutoId, string employeeNumber, string companyCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeePreferencesGetAll(locationAutoId, employeeNumber, companyCode);
            return ds;
        }

        /// <summary>
        /// Gets Shift wise Time Details
        /// </summary>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePreferencesGetTimeDetails(string shiftCode, string locationAutoId)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeePreferencesGetTimeDetails(shiftCode, locationAutoId);
            return ds;
        }

        /// <summary>
        /// Inserts the Employee Preferences
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
        public DataSet EmployeePreferencesInsert(string locationAutoId, string employeeNumber, string asmtId, string shiftPreference, bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, DateTime timeFrom, DateTime timeTo, bool daysPreference, bool shiftTimePreference, bool sitePreference, bool alertSitePreference, bool alertShiftTimePreference, bool alertDaysPreference, string modifiedBy, string minimumShift, string maximumShift, string clientCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeePreferencesInsert(locationAutoId, employeeNumber, asmtId, shiftPreference, sunday, monday, tuesday, wednesday, thursday, friday, saturday, timeFrom, timeTo, daysPreference, shiftTimePreference, sitePreference, alertSitePreference, alertShiftTimePreference, alertDaysPreference, modifiedBy, minimumShift, maximumShift, clientCode);
            return ds;
        }

        /// <summary>
        /// Updates the Existing Details for the Employee Prefences
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeePreferencesUpdate(locationAutoId, employeeNumber, asmtId, shiftPreference, sunday, monday, tuesday, wednesday, thursday, friday, saturday, timeFrom, timeTo, daysPreference, shiftTimePreference, sitePreference, alertSitePreference, alertShiftTimePreference, alertDaysPreference, modifiedBy, minimumShift, maximumShift, clientCode);
            return ds;
        }

        /// <summary>
        /// Deletes the Employee Preference Details
        /// </summary>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeePreferencesDelete(string asmtId, string employeeNumber, string locationAutoId, string clientCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeePreferencesDelete(asmtId, employeeNumber, locationAutoId, clientCode);
            return ds;
        }
        #endregion

        #region Function Related to Asconder employees
        /// <summary>
        /// Absconderses the get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AbscondersGet(int locationAutoId, string employeeNumber)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.AbscondersGet(locationAutoId, employeeNumber);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.AbscondersDelete(employeeNumber, effectiveTo, modifiedBy);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.AbscondersInsert(employeeNumber, effectiveFrom, modifiedBy);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.MarkAbscondersFromPaysum(hrLocationCode, modifiedBy);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeePersonalDetailsGetAll(companyCode, hrLocationCode, locationCode, areaId);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.RosterOfHRLocationGetAll(companyCode, hrLocationCode, fromDate, toDate);
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
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.HoursDetailsGetAll(companyCode);
            return ds;
        }

        /// <summary>
        /// Hourses the details graph get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HoursDetailsGraphGetAll(string companyCode)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.HoursDetailsGraphGetAll(companyCode);
            return ds;
        }
        #endregion

        #region Function Related to Employee Nationality

        #region Function Related to Get Data

        /// <summary>
        /// Employees the nationality get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNationalityGetAll(string companyCode)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.EmployeeNationalityGetAll(companyCode);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeLeaveUnitGet(companyCode, employeeNumber, leaveType, fromDate, toDate, locationAutoId);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.LeaveBreakDownReportGet(companyCode, LocationAutoID, leaveCode, fromDate, toDate, EmpNo);
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
            DL.HRManagement objHRManagement = new DL.HRManagement();

            DataSet ds = objHRManagement.EmployeeConstraintGetAll(companyCode, employeeNumber);
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
            DL.HRManagement objHRManagement = new DL.HRManagement();

            DataSet ds = objHRManagement.EmployeeConstraintUpdate(companyCode, employeeNumber, employeeConstraintAutoId, constraintTypeAutoId, constraintAutoId, value, remarks, modifiedBy);
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
            DL.HRManagement objHRManagement = new DL.HRManagement();

            DataSet ds = objHRManagement.EmployeeConstraintInsert(companyCode, employeeNumber, constraintTypeAutoId, constraintAutoId, value, remarks, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Employees the constraint delete.
        /// </summary>
        /// <param name="employeeConstraintAutoId">The employee constraint automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeConstraintDelete(string employeeConstraintAutoId)
        {
            DL.HRManagement objHRManagement = new DL.HRManagement();

            DataSet ds = objHRManagement.EmployeeConstraintDelete(employeeConstraintAutoId);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.CompensationHistoryGetByComponent(employeeNumber, companyCode, component);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeDefaultEffectiveFromDateGet(companyCode, employeeNumber, component);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.SaveInModifyCorrect(companyCode, employeeNumber, component, percentage, frequency, value, currency, percentage1, modifiedBy);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.SaveInModifyUpdate(companyCode, employeeNumber, component, percentage, frequency, value, currency, percentage1, updateEffectiveFrom, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Calls the DL CheckEffectiveFrom
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="updateEffectiveFrom">The update effective from.</param>
        /// <returns>DataTable.</returns>
        public DataTable CheckEffectiveFrom(string companyCode, string employeeNumber, DateTime updateEffectiveFrom)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataTable dt = objHRManagement.CheckEffectiveFrom(companyCode, employeeNumber, updateEffectiveFrom);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.SaveInAddInsert(companyCode, employeeNumber, component, percentage, frequency, value, currency, percentage1, addEffectiveFrom, modifiedBy);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.SaveInModifyDisable(companyCode, employeeNumber, component, wefDate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Added by  on 3-nov-2011 for getting employee distinct contractual days
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeContractualDaysGet(string companyCode)
        {

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeContractualDaysGet(companyCode);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeAddressGetByEmployeeCode(employeeNumber, companyCode, typeOfAddress);
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeAddressInsert(companyCode, employeeNumber, addressType, address1, address2, address3, city, state, pin, countryCode, phone1, phone2, emailId, fax, mobileNumber, contactPerson, communicationChannel, modifiedBy);
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
        /// <param name="roleEffectiveFrom">The role effective from.</param>
        /// <param name="areaEffectiveFrom">The area effective from.</param>
        /// <param name="dateDeptEffectiveFrom">The date dept effective from.</param>
        /// <returns>DataSet.</returns>
        public DataSet MaxDateGet(DateTime locationEffectiveFrom, DateTime designationEffectiveFrom, DateTime categoryEffectiveFrom, DateTime employeeJobTypeEffectiveFrom, DateTime employeeJobClassEffectiveFrom, DateTime roleEffectiveFrom, DateTime areaEffectiveFrom, DateTime dateDeptEffectiveFrom)
        {
            DL.HRManagement objdlHRManagement = new DL.HRManagement();

            DataSet ds = objdlHRManagement.MaxDateGet(locationEffectiveFrom, designationEffectiveFrom, categoryEffectiveFrom, employeeJobTypeEffectiveFrom, employeeJobClassEffectiveFrom, roleEffectiveFrom, areaEffectiveFrom, dateDeptEffectiveFrom);
            return ds;
        }

        #endregion

        #region Function to check if Employee Belongs to the location or not
        /// <summary>
        /// This Code checks validity of Employee
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet IsValidUser(string locationAutoId, string employeeNumber)
        {
            DL.HRManagement objUserManagement = new DL.HRManagement();

            DataSet ds = objUserManagement.IsValidUser(locationAutoId, employeeNumber);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeTrainingDetailsInsert(employeeNumber, companyCode, trainingCode, duration, modifiedBy, trainingDate, validTillDate);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.RefresherTrainingDetailsGet(companyCode, trainingCode, employeeNumber, trainingDate);
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

            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.EmployeeRefresherTrainingDetailsUpdate(companyCode, trainingAutoId, trainingCode, employeeNumber, trainingDate, trainingRefreshmentDate, actualTrainingDate, modifiedBy);
            return ds;
        }
        #endregion Training

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
            DL.HRManagement objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.MstHrEmployeeDetailGetSelected(locationAutoId, dutyDate, clientCode, asmtId, postCode);
            return ds;
        }

        /// <summary>
        /// To Get Employees for Schedule By EMail Report
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.EmployeeNameGetAllBasedOnClientAsmtInchargeAreaIdForSelectedWeek(locationAutoId, areaIncharge, areaId, fromDate, toDate, clientCode, asmtCode);
            return ds;
        }

        /// <summary>
        /// To Send EMail Employees for Schedule
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.SendScheduleForEmployeeBasedOnClientAsmtInchargeAreaIdForSelectedWeek(locationAutoId, areaIncharge, areaId, fromDate, toDate, clientCode, asmtCode, employeeNumber);
            return ds;
        }

        /// <summary>
        /// Calls Email sending sp
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

            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.CallEmailSP(html, locationAutoId, areaIncharge, areaId, fromDate, toDate, clientCode, asmtCode, employeeNumber, schof, emailopening, emailgreeting, emailclosing);
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
            DL.HRManagement objHRManagement = new DL.HRManagement();
            DataSet ds = objHRManagement.ExportHrReportsToExcel(areaId, fromDate, nDays, locationCode, hrLocationCode, clientCode, asmtCode, areaIncharge, employeeNumber, trainingCode, companyCode, locationAutoId, userId, eType, toDate);
            return ds;
        }

        #endregion

        /// <summary>
        /// Gets the Status if the Schedule/Actual Exists for Employee with Mandatory Skills Training Code
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="validTillDate">The valid till date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetScheduleListEmpWise(string employeeNumber, string trainingCode, string validTillDate)
        {
            var objHrManagement = new DL.HRManagement();
            DataSet ds = objHrManagement.GetScheduleListEmpWise(employeeNumber, trainingCode,validTillDate);
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
            var objHrManagement = new DL.HRManagement();
            var ds = objHrManagement.TrainingReActivation(companyCode, trainingCode, employeeNumber, trainingDate, validTillDate,modifiedBy);
            return ds;  
        }

    
    }
}
