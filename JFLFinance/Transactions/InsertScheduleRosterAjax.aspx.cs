// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="InsertScheduleRosterAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_InsertScheduleRosterAjax.
/// </summary>
public partial class Transactions_InsertScheduleRosterAjax : BasePage //System.Web.UI.Page
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
        string Date1 = Request.QueryString["Date1"];
        string Date2 = Request.QueryString["Date2"];
        string strShifts = Request.QueryString["ShiftPat"];
        string strSORank = Request.QueryString["SORank"];


        if (Position == "")
        {
            Position = "1";
        }

        int intAsmtId = int.Parse(AsmtId);
        int intPdLineNo = int.Parse(PdLineNo);
        int intPatternPosition = int.Parse(Position);



        DataTable dtSubmit = new DataTable();
        dtSubmit.Columns.Add(new DataColumn("DutyDate", typeof(string)));
        dtSubmit.Columns.Add(new DataColumn("ShiftCode", typeof(string)));
        dtSubmit.Columns.Add(new DataColumn("weekNum", typeof(string)));

        DateTime dt1, dt2;
        dt1 = DateTime.Parse(Date1);
        dt2 = DateTime.Parse(Date2);
        int j = intPatternPosition - 1;
        while (dt1 <= dt2)
        {
            DataRow myDataRow = dtSubmit.NewRow();
            myDataRow[0] = DateFormat(dt1);
            myDataRow[1] = strShifts.Substring(j, 1);
            myDataRow[2] = weekNumByDate(dt1);
            dtSubmit.Rows.Add(myDataRow);
            dt1 = dt1.AddDays(1);
            j = j + 1;

        }



        BL.Roster objRost = new BL.Roster();
        DataSet dsSubmit = new DataSet();
        //DataSet dsPatternPosition = new DataSet();
        //dsPatternPosition = objRost.blTran_Schedule_DeleteSchBasedOnPattern(strAsmtCode, int.Parse(BaseLocationAutoID), intPdLineNo, dtSubmit, strEmpNo, strShiftPatternCode, intPatternPosition, strIsDefaultSite, OpsShift);// Used to Delete Sch if pattern position is changed of already Scheduled  Employee
        dsSubmit = objRost.ScheduleRosterInsert(intAsmtId, strAsmtCode, int.Parse(BaseLocationAutoID), intPdLineNo, dtSubmit, strEmpNo, strRoleCode, strDesgCode, strDutyTypeCode, strShiftPatternCode, intPatternPosition, strIsDefaultSite, OpsShift, BaseUserID, strSORank);
        string strInsert = "Insert";
        DataTable dt = new DataTable();
        DataView dv = new DataView(dsSubmit.Tables[0]);
        dv.RowFilter = "[MessageString]='" + (strInsert) + "'";
        dt = dv.ToTable();
        int k = 0;
        int d = 0;

        string str1 = "";
        if (dsSubmit != null && dsSubmit.Tables.Count > 0 && dsSubmit.Tables[0].Rows.Count > 0)
        {
            //added by Manish 4-mar-2010  
            if (dsSubmit.Tables[0].Rows[0]["MessageString"].ToString() == "Authorized")
            { Response.Write("Authorized"); Response.End(); }

            Response.Write("<table width=650 border=1 style='font-size:11px' >");
            for (int i = 0; i < dsSubmit.Tables[0].Rows.Count; i++)
            {
                if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Duplicate" || dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Converted")
                {
                    Response.Write("<tr id='tr" + d + "' style='display: block'><td>");
                    Response.Write("<div style='width:110px' id='lblMsg_dup" + d + "' >" + ResourceValueOfKey_Get(dsSubmit.Tables[0].Rows[i]["MessageString"].ToString().Trim()) + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:110px' id='lblAsmtCode_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["AsmtCode"] + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:14px' id='lblShiftCode_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["ShiftCode"] + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:80px' id='lblDutyDate_dup" + d + "' >" + DateTime.Parse(dsSubmit.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:60px' id='lblEmpNo_dup" + d + "' >" + strEmpNo + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:50px' id='lblTimeFrom_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["TimeFrom"].ToString() + "</div>");
                    Response.Write("</td><td>");
                    Response.Write("<div style='width:50px' id='lblTimeTo_dup" + d + "' >" + dsSubmit.Tables[0].Rows[i]["TimeTo"].ToString() + "</div>");
                    Response.Write("</td><td>");
                    if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Duplicate")
                    {
                        Response.Write("<input type='checkbox' id='chk" + d + "' />");

                    }
                    else
                    {
                        Response.Write(Resources.Resource.Converted);
                    }
                    Response.Write("<input type='hidden' id='lblRostId_dup" + d + "' value='" + dsSubmit.Tables[0].Rows[i]["SchRosterAutoId"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='lblColIndex_dup" + d + "' value='" + (i + 1) + "'    />");
                    d = d + 1;
                }
                if (dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() == "Insert")
                {
                    if (dt.Rows.Count > 0)
                    {
                        Response.Write("<input type='hidden' id='lblInsertShift" + k + "' value='" + dsSubmit.Tables[0].Rows[i]["MessageString"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblInsertDutyDate" + k + "' value='" + DateTime.Parse(dsSubmit.Tables[0].Rows[i]["DutyDate"].ToString()).ToString("dd-MMM-yyyy") + "'    />");
                        Response.Write("<input type='hidden' id='lblInsertShiftCode" + k + "' value='" + dsSubmit.Tables[0].Rows[i]["ShiftCode"].ToString() + "'    />");
                        Response.Write("<input type='hidden' id='lblInsertColumnNo" + k + "' value='" + i + "'    />");
                        Response.Write("<input type='hidden' id='lblInsertTotalCount" + 0 + "' value='" + dt.Rows.Count + "'    />");
                    }
                    k = k + 1;
                }
                Response.Write("<input type='hidden' id='hfTotalCount" + 0 + "' value='" + dsSubmit.Tables[0].Rows.Count + "'    />");
                Response.Write("</td></tr>");
            }

            Response.Write("</table >");
            Response.End();
        }
        else
        {
            Response.Write("error!");
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
