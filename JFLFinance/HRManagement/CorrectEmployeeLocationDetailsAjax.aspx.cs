// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By :  Akhtar
// Last Modified On : 04-Mar-2014
// Purpose          :Comments added for method,class
// ***********************************************************************
// <copyright file="CorrectEmployeeLocationDetailsAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;

/// <summary>
/// HRManagement_CorrectEmployeeLocationDetailsAjax Code Behind
/// </summary>
public partial class HRManagement_CorrectEmployeeLocationDetailsAjax : BasePage//System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        
            string strCompany = Request.QueryString["CompanyCode"];
            string strHrLocation = Request.QueryString["HrLocation"];
            string NewLocationAutoID = Request.QueryString["NewLocationAutoID"];
            string OldLocationAutoID = Request.QueryString["OldLocationAutoID"];
            string NewDesinationCode = Request.QueryString["NewDesinationCode"];
            string NewCategoryCode = Request.QueryString["NewCategoryCode"];
            string NewJobClassCode = Request.QueryString["NewJobClassCode"];
            string NewJobTypeCode = Request.QueryString["NewJobTypeCode"];
            string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
            string CorrectionDate = Request.QueryString["CorrectionDate"];
            string NewRoleCode = Request.QueryString["NewRoleCode"];
            string NewAreaCode = Request.QueryString["NewAreaCode"];
            string str1;
            string str2;
            DataSet ds = new DataSet();
            BL.HRManagement objHRManagement = new BL.HRManagement();
            try
            {
                ds = objHRManagement.CorrectEmployeeLocationDetails(strCompany, strHrLocation, int.Parse(NewLocationAutoID), int.Parse(OldLocationAutoID), strEmployeeNumber, NewDesinationCode, NewCategoryCode, NewJobClassCode, NewJobTypeCode, CorrectionDate, BaseUserID, NewRoleCode, NewAreaCode);
            }
            catch (Exception ex)
            {
                DataSet dsEx = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                dsEx.Dispose();
            
            }

            try
            {
            if (!GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())))
            {
                str1 = "";
                str2 = "";
                str1 = str1 + MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
                str2 = str2 + "FALSE";
                Response.Write(str1 + "," + str2);
                Response.End();
            }
            else
            {
                str1 = "";
                str2 = "";
                str1 = str1 + MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
                str2 = str2 + "TRUE";
                Response.Write(str1 + "," + str2);
                Response.End();
            }
        }
        catch (IndexOutOfRangeException ex)

        {
            DataSet dsEx = new DataSet();
            BL.ExceptionLogs objEx = new BL.ExceptionLogs();
            objEx.ExceptionLog(ex.ToString(), BaseUserID);
            dsEx.Dispose();
        
        }
        
    }
}
