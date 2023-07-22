// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="GetEmployeeAjaxNew.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_GetEmployeeAjaxNew.
/// </summary>
public partial class Transactions_GetEmployeeAjaxNew : BasePage
{
    #region Properties

    // / <summary>
    // / Returns User Read Rights.
    // / </summary>

    /// <summary>
    /// Gets a value indicating whether this instance is read access.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsReadAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    // / <summary>
    // / Returns User Write Rights.
    // / </summary>
    /// <summary>
    /// Gets a value indicating whether this instance is write access.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    // / <summary>
    // / Returns User Modify Rights.
    // / </summary>
    /// <summary>
    /// Gets a value indicating whether this instance is modify access.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    // / <summary>
    // / Returns User Delete Rights.
    // / </summary>
    /// <summary>
    /// Gets a value indicating whether this instance is delete access.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion Properties

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet dsEmpName = new DataSet();

        string strPdLineNo = "";
        // string strSoLineNo = "";
        // string strSoAmendNo = "";

        string strEmpNo = Request.QueryString["EmpNo"];
        string strAsmt = Request.QueryString["Asmt"];
        string strInsertStatus = Request.QueryString["InsertStatus"];
        string strPostCode = Request.QueryString["PostCode"];
        string strAreaID = Request.QueryString["AreaID"];
        string screenType = Request.QueryString["screenType"];
        string strIsAreaincharge = Request.QueryString["IsAreaIncharge"];
        string strAreaIncharge = Request.QueryString["AreaIncharge"];
        if (Request.QueryString["PdLineNo"] != null)
        {
            // strSoNo = Request.QueryString["SoNo"];
            // strSoLineNo = Request.QueryString["SoLineNo"];
            // strSoAmendNo = Request.QueryString["SoAmendNo"];
            strPdLineNo = Request.QueryString["PdLineNo"];
        }

        string strFromDate = Request.QueryString["FromDate"];
        string strToDate = Request.QueryString["ToDate"];

        // function need to be change. Both the start date and end date need to be sent as paramerter to check the validity of the employee.

        // Added Area ID option to search only those employee that belongs to that Area
        string barredEmployeeStatus;
        dsEmpName = objHRManagement.EmployeeDetailGet(strEmpNo, BaseCompanyCode, BaseHrLocationCode, int.Parse(BaseLocationAutoID.ToString()), strAsmt, strPdLineNo, strFromDate, strToDate, strPostCode, strAreaID, strAreaIncharge, strIsAreaincharge, screenType, BaseUserID);
        if (dsEmpName != null && dsEmpName.Tables.Count > 0 && dsEmpName.Tables[0].Rows.Count > 0)
        {
            if (DateTime.Parse(dsEmpName.Tables[0].Rows[0]["DateOfJoining"].ToString()) > DateTime.Parse(strToDate))
            {
                DateTime dt1 = DateTime.Parse(dsEmpName.Tables[0].Rows[0]["DateOfJoining"].ToString());
                Response.Write("1,Invalid," + Resources.Resource.EmpJoininDateCannotBeGreaterThanDutyDate + dt1.ToString("dd-MMM-yyyy"));
                Response.End();
            }
            else if (dsEmpName.Tables[0].Rows[0]["DesignationCode"].ToString() == "")
            {
                string strTotalSkills = string.Empty;
                if (dsEmpName.Tables[0].Rows.Count > 1)
                {
                    for (int i = 0; i < dsEmpName.Tables[0].Rows.Count; i++)
                    {
                        strTotalSkills = strTotalSkills + dsEmpName.Tables[0].Rows[i]["ConstraintDesc"].ToString() + '/';
                    }
                }
                else
                {
                    strTotalSkills = strTotalSkills + dsEmpName.Tables[0].Rows[0]["ConstraintDesc"].ToString() + '/';
                }
               
                barredEmployeeStatus = "0";
                Response.Write("1,Invalid," + dsEmpName.Tables[0].Rows[0]["EmployeeName"].ToString() + "," + dsEmpName.Tables[0].Rows[0]["RigidityLevel"].ToString() + "," + strTotalSkills + "," + barredEmployeeStatus);
                Response.End();
            }
            else
            {
                string str1 = dsEmpName.Tables[0].Rows[0]["EmployeeName"].ToString();
                string str2 = dsEmpName.Tables[0].Rows[0]["DesignationDesc"].ToString();
                string str3 = dsEmpName.Tables[0].Rows[0]["WageRate"].ToString();
                string strSkillStatus = dsEmpName.Tables[0].Rows[0]["skillStatus"].ToString();
                string strDesignationCode = dsEmpName.Tables[0].Rows[0]["DesignationCode"].ToString();
                string strRigidtyLevel = dsEmpName.Tables[0].Rows[0]["RigidityLevel"].ToString();
                string strPayrateMismatch = dsEmpName.Tables[0].Rows[0]["WageRateStatus"].ToString();
                string optimumProfitabilityMismatch = dsEmpName.Tables[0].Rows[0]["OptimumProfitabilityStatus"].ToString(); 
                string strTotalSkills = string.Empty;
                if (dsEmpName.Tables[0].Rows.Count > 1)
                {
                    for (int i = 0; i < dsEmpName.Tables[0].Rows.Count; i++)
                    {
                        strTotalSkills = strTotalSkills + dsEmpName.Tables[0].Rows[i]["ConstraintDesc"].ToString() + '/';
                    }
                }
                else
                {
                    strTotalSkills = strTotalSkills + dsEmpName.Tables[0].Rows[0]["ConstraintDesc"].ToString() + '/';
                }

                barredEmployeeStatus = dsEmpName.Tables[0].Rows[0]["BorrowedEmployeeStatus"].ToString();
                Response.Write("0," + str1 + "," + str2 + "," + str3 + "," + strSkillStatus + "," + strDesignationCode + "," + dsEmpName.Tables[0].Rows[0]["RoleCode"] + "," + dsEmpName.Tables[0].Rows[0]["RoleDesc"] + "," + strInsertStatus + "," + strRigidtyLevel + "," + strPayrateMismatch + "," + strTotalSkills + "," + barredEmployeeStatus + "," + optimumProfitabilityMismatch);
                Response.End();
            }
        }

        else
        {
            Response.Write("1,Invalid," + Resources.Resource.InvalidEmployee);
            Response.End();
        }
    }
}