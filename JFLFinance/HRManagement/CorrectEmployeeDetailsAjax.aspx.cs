// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="CorrectEmployeeDetailsAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Threading;
using System.Security.Permissions;

/// <summary>
/// Partial class for HRManagement_CorrectEmployeeDetailsAjax
/// </summary>
public partial class HRManagement_CorrectEmployeeDetailsAjax : BasePage //System.Web.UI.Page
{
    #region Properties

    /// <summary>
    /// Returns User Read Rights.
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();

                throw new Exception("Have not Rights", ex);
            }
        }
    }

    /// <summary>
    /// Returns User Write Rights.
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();

                throw new Exception("Have not Rights", ex);
            }
        }
    }

    /// <summary>
    /// Returns User Modify Rights.
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex);
            }
        }
    }

    /// <summary>
    /// Returns User Delete Rights.
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();

                throw new Exception("Have not Rights", ex);
            }
        }
    }

    #endregion
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Request.QueryString["CompanyCheckStatus"].ToString() == "0")
            {
                string strCompany = Request.QueryString["Company"];
                string strHrLocation = Request.QueryString["HrLocation"];
                string LocationAutoID = Request.QueryString["LocationAutoID"];
                string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
                string strCorrectionField = Request.QueryString["CorrectionField"];
                string strCorrectionDate = (Request.QueryString["CorrectionDate"]);
                string strOldCorrectionDate = (Request.QueryString["OldCorrectionDate"]);
                string strNewCode = (Request.QueryString["NewCode"]);
                string strOldCode = (Request.QueryString["OldCode"]);
                string str1 = "";
                string str2 = "";
                DataSet ds = new DataSet();
                BL.HRManagement objHRManagement = new BL.HRManagement();
                string strError = "";
                ds = objHRManagement.CorrectEmployeeJobDetails(strCompany, strHrLocation, int.Parse(LocationAutoID.ToString()), strEmployeeNumber, strCorrectionDate, strOldCorrectionDate, strNewCode, strOldCode, BaseUserID, strCorrectionField);
                if (!GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())))
                {
                    str1 = "";
                    str2 = "";
                    strError = "";
                    strError = "Error In " + strCorrectionField;
                    str1 = str1 + strError + MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
                    str2 = str2 + "FALSE";
                    Response.Write(str1 + "," + str2);
                    Response.End();
                }
                else
                {
                    str1 = "";
                    str2 = "";
                    strError = "";
                    str1 = str1 + strError + MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
                    str2 = str2 + "TRUE";
                    Response.Write(str1 + "," + str2);
                    Response.End();
                }

            }
            else
            {
                string strOldCompanyCode = Request.QueryString["OldCompanyCode"];
                string strNewCompanyCode = Request.QueryString["NewCompanyCode"];
                string strOldCompanyCorrectionDate = Request.QueryString["OldCompanyCorrectionDate"];
                string strNewCorrectionDate = Request.QueryString["NewCorrectionDate"];
                string strOldHrLocationCode = Request.QueryString["OldHrLocationCod"];
                string strNewHrLocation = Request.QueryString["NewHrLocation"];
                string strOldLocationAutoID = Request.QueryString["OldLocationAutoID"];
                string strNewLocationAutoID = Request.QueryString["NewLocationAutoID"];
                string strOldDesignationCode = Request.QueryString["OldDesignationCode"];
                string strNewDesinationCode = Request.QueryString["NewDesinationCode"];
                string strOldCategoryCode = Request.QueryString["OldCategoryCode"];
                string strNewCategoryCode = Request.QueryString["NewCategoryCode"];
                string strOldJobTypeCode = Request.QueryString["OldJobTypeCode"];
                string strNewJobTypeCode = Request.QueryString["NewJobTypeCode"];
                string strOldJobClassCode = Request.QueryString["OldJobClassCode"];
                string strNewJobClassCode = Request.QueryString["NewJobClassCode"];

                string strOldRoleCode = Request.QueryString["OldRoleCode"];
                string strNewRoleCode = Request.QueryString["NewRoleCode"];

                string strOldAreaCode = Request.QueryString["OldAreaCode"];
                string strNewAreaCode = Request.QueryString["NewAreaCode"];

                string strOldDepartmentCode = Request.QueryString["OldDepartmentCode"];
                string strNewDepartmentCode = Request.QueryString["NewDepartmentCode"];

                string EmployeeNumber = Request.QueryString["EmployeeNumber"];
                string str1 = "";
                string str2 = "";
                DataSet dsCompany = new DataSet();
                BL.HRManagement objHRManagement = new BL.HRManagement();
                dsCompany = objHRManagement.CorrectEmployeeCompanyDetails(EmployeeNumber, strOldCompanyCode, strNewCompanyCode, strOldCompanyCorrectionDate, strNewCorrectionDate, strOldHrLocationCode, strNewHrLocation, strOldLocationAutoID, strNewLocationAutoID, strOldDesignationCode, strNewDesinationCode, strOldCategoryCode, strNewCategoryCode, strOldJobClassCode, strNewJobClassCode, strOldJobTypeCode, strNewJobTypeCode, BaseUserID, strOldRoleCode, strNewRoleCode, strOldAreaCode, strNewAreaCode, strOldDepartmentCode, strNewDepartmentCode);
                if (!GetSuccessResult(int.Parse(dsCompany.Tables[0].Rows[0]["MessageID"].ToString())))
                {
                    str1 = "";
                    str2 = "";
                    str1 = str1 + MessageString_Get(int.Parse(dsCompany.Tables[0].Rows[0]["MessageID"].ToString()));
                    str2 = str2 + "FALSE";
                    Response.Write(str1 + "," + str2);
                    Response.End();
                }
                else
                {
                    str1 = "";
                    str2 = "";
                    str1 = str1 + MessageString_Get(int.Parse(dsCompany.Tables[0].Rows[0]["MessageID"].ToString()));
                    str2 = str2 + "TRUE";
                    Response.Write(str1 + "," + str2);
                    
                    Response.End();
                }
                
            }
        }
        catch (ThreadAbortException ex1) {
            DataSet ds = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex1.ToString(), BaseUserID);
            ds.Dispose();
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            DataSet ds = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex.ToString(), BaseUserID);
            ds.Dispose();

        }
    }

}
