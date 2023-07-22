// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="overWriteScheduleAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_overWriteScheduleAjax.
/// </summary>
public partial class Transactions_overWriteScheduleAjax : BasePage // System.Web.UI.Page
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


        string AsmtId = Request.QueryString["AsmtId"];
        string strAsmtCode = Request.QueryString["Asmt"];
        string PdLineNo = Request.QueryString["Pd"];
        string strEmpNo = Request.QueryString["EmpNo"];
        string strRoleCode = Request.QueryString["RoleCode"];
        string strDesgCode = Request.QueryString["EmpDesg"];
        string strDutyTypeCode = Request.QueryString["DTCode"];
        string strShiftPatternCode = Request.QueryString["ShiftPatCode"];
        string Position = Request.QueryString["Pos"];
        string strIsDefaultSite = "1";//Request.QueryString["DefaultSite"];
        string OpsShift = Request.QueryString["Shift"];
       // string Date1 = Request.QueryString["Date1"];
       // string strShiftCode = Request.QueryString["ShiftPat"];
        string strSORank = Request.QueryString["SORank"];
        //string strRosterId = Request.QueryString["Id"];
        string ConcatenatedDetails= Request.QueryString["ConcatenatedDetails"];
       

        int intAsmtId = int.Parse(AsmtId);
        int intPdLineNo = int.Parse(PdLineNo);
        int intPatternPosition = int.Parse(Position);
        //int intSchRosterId = int.Parse(strRosterId);

        //DateTime dt1;
        //dt1 = DateTime.Parse(Date1);
        //int intWeekNo = weekNumByDate(dt1);
        //string strWeekNo = intWeekNo.ToString();
        BL.Roster objRost = new BL.Roster();
        DataSet dsSubmit = new DataSet();
        dsSubmit = objRost.Reschedule(intAsmtId, strAsmtCode, int.Parse(BaseLocationAutoID), intPdLineNo, strEmpNo, strRoleCode, strDesgCode, strDutyTypeCode, strShiftPatternCode, intPatternPosition, strIsDefaultSite, OpsShift, strSORank, BaseUserID, ConcatenatedDetails);

        if (dsSubmit != null || dsSubmit.Tables.Count > 0)
        {

            Response.Write(dsSubmit.Tables[0].Rows[0][0].ToString());
            Response.End();
        }
        else
        {
            Response.Write("1");
            Response.End();

        }
    }

    /// <summary>
    /// Weeks the number by date.
    /// </summary>
    /// <param name="dtDate">The dt date.</param>
    /// <returns>System.Int32.</returns>
    private int weekNumByDate(DateTime dtDate)
    {
        int weeknum = 1;
        weeknum = dtDate.Day / 7;
        if ((dtDate.Day % 7) > 0)
        {
            weeknum = weeknum + 1;
        }

        return weeknum;
    }

}
