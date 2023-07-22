// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="OverWriteDuplicateRecordAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_OverWriteDuplicateRecordAjax.
/// </summary>
public partial class Transactions_OverWriteDuplicateRecordAjax : BasePage//System.Web.UI.Page
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
            { throw new Exception("Have not Rights", ex); }
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
            { throw new Exception("Have not Rights", ex); }
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
            { throw new Exception("Have not Rights", ex); }
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
            { throw new Exception("Have not Rights", ex); }
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

        string strAsmtCode = Request.QueryString["Asmt"];
        string strFromDate = Request.QueryString["FromDate"];
        string strToDate = Request.QueryString["ToDate"];
        string strEmpNo = Request.QueryString["EmpNo"];
        string strEmpDesignation = Request.QueryString["EmpDesg"];
        string strShift = Request.QueryString["Shift"];
        string strTimeFrom1 = Request.QueryString["TimeF"];
        string strTimeTo1 = Request.QueryString["TimeT"];
        string strDutyHrs = Request.QueryString["DutyH"];
        string strDutyType = Request.QueryString["DTCode"];
        string strRoleCode = Request.QueryString["RoleCode"];
        int TimeStatus =int.Parse(Request.QueryString["TimeStatus"].ToString());
        string BreakHours = Request.QueryString["BreakHours"].ToString();
        int intKeyPressStatus = int.Parse(Request.QueryString["KeyPressStatus"]);// 1 if F7 Pressed 0 if any other key pressed only in case of Monthly Rota
        int intPdLineNo = int.Parse(Request.QueryString["Pd"].ToString());
        int intRosterAutoID = int.Parse(Request.QueryString["RId"].ToString());
        int intDuplicateRosterAutoID1 = int.Parse(Request.QueryString["DuplicateRosterAutoID1"].ToString());
        int intDuplicateRosterAutoID2 = int.Parse(Request.QueryString["DuplicateRosterAutoID2"].ToString());
        int intDuplicateRosterAutoID3 = int.Parse(Request.QueryString["DuplicateRosterAutoID3"].ToString());
        string strEmpName = "";


        int intDutyHrs = 0;
        if (strDutyHrs.Length > 3)
        {
            intDutyHrs = ConvertHrs2Min(strDutyHrs);
        }
        else
        {
            intDutyHrs = int.Parse(strDutyHrs);
        }


        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();

        string strTimeFrom = DateTime.Now.Date.ToString("dd-MMM-yyyy") + " " + strTimeFrom1;
        string strTimeTo = DateTime.Now.Date.ToString("dd-MMM-yyyy") + " " + strTimeTo1;

        if (strShift == "")
        {
            Response.Write("3,Shift cannot be blank!");
            Response.End();
        }
        if (strEmpNo != "" && strShift != "")
        {
            if (intKeyPressStatus == 1)
            {
                intRosterAutoID = 0;
            }
            ds = objRost.OverwriteDuplicateRota(strAsmtCode, int.Parse(BaseLocationAutoID), intPdLineNo, strFromDate, strEmpNo, strRoleCode, strEmpDesignation, strShift, strTimeFrom, strTimeTo, intDutyHrs, strDutyType, BaseUserID, intDuplicateRosterAutoID1, intDuplicateRosterAutoID2, intDuplicateRosterAutoID3, intRosterAutoID, TimeStatus, BreakHours);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                string str1 = ds.Tables[0].Rows[0]["MessageID"].ToString();
                string str2 = ds.Tables[0].Rows[0]["MessageString"].ToString();
                string str3 = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
                string str4 = ds.Tables[0].Rows[0]["DutyDate"].ToString();
                string str5 = ds.Tables[0].Rows[0]["TimeFrom"].ToString();
                string str6 = ds.Tables[0].Rows[0]["TimeTo"].ToString();
                string str7 = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
                string str8 = ds.Tables[0].Rows[0]["RosterAutoId"].ToString();
                string str9 = strEmpName;
                string str10 = strEmpDesignation;
                string str11 = ds.Tables[0].Rows[0]["TimeStatus"].ToString(); ;
                Response.Write(str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + "," + str10 + "," + str11);
                Response.Write(str2);
                Response.End();

            }
            else
            {

            }

        }
    }

    /// <summary>
    /// Converts the HRS2 minimum.
    /// </summary>
    /// <param name="strHrs">The string HRS.</param>
    /// <returns>System.Int32.</returns>
    protected int ConvertHrs2Min(string strHrs)
    {
        if (strHrs.IndexOf(":") > 1)
        {
            char[] arr = new char[] { ':' };
            string[] strSplitArr = strHrs.Split(arr);
            int intMints = int.Parse(strSplitArr[0]) * 60 + int.Parse(strSplitArr[1]);
            return intMints;
        }
        else
        {
            return 0;
        }
    }
}
