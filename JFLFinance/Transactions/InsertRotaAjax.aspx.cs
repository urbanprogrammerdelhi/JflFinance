// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="InsertRotaAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_InsertRotaAjax.
/// </summary>
public partial class Transactions_InsertRotaAjax : BasePage //System.Web.UI.Page
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
        string strEmpDesignationDesc = string.Empty;
        string strEmpRoleDesc = string.Empty;


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
        string strRoleId = Request.QueryString["RoleId"];
        string BreakHours = Request.QueryString["BreakHours"];
        int TimeStatus = int.Parse(Request.QueryString["TimeStatus"].ToString());

        int intPdLineNo = int.Parse(Request.QueryString["Pd"].ToString());
        int intRosterAutoID = int.Parse(Request.QueryString["RId"].ToString());
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

        if (strEmpNo == "" && intRosterAutoID > 0)
        {
            ds = objRost.RotaDelete(intRosterAutoID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                string str1 = ds.Tables[0].Rows[0]["MessageID"].ToString();
                string str2 = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString().Trim());
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                string str7 = "";
                string str8 = "";
                string str9 = "";
                string str10 = "";
                string str11 = "";

                Response.Write(str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + "," + str10 + "," + str11);
                Response.End();

            }
        }
        else // if inserted 
        {
            // check whethear employeenumber is valid
            if (strEmpDesignation == "" || strRoleId == "")
            {
                BL.HRManagement objHRManagement = new BL.HRManagement();
                DataSet dsEmpName = new DataSet();

                dsEmpName = objHRManagement.EmployeeDetailGet(strEmpNo, BaseCompanyCode, BaseHrLocationCode, int.Parse(BaseLocationAutoID.ToString()), strAsmtCode, "0", strFromDate, strToDate);
                if (dsEmpName != null && dsEmpName.Tables.Count > 0 && dsEmpName.Tables[0].Rows.Count > 0)
                {
                    if (DateTime.Parse(dsEmpName.Tables[0].Rows[0]["DateOfJoining"].ToString()) > DateTime.Parse(strFromDate))
                    {

                        DateTime dt1 = DateTime.Parse(dsEmpName.Tables[0].Rows[0]["DateOfJoining"].ToString());
                        Response.Write("3," + Resources.Resource.EmpJoininDateCannotBeGreaterThanDutyDate + dt1.ToString("dd-MMM-yyyy"));
                        Response.End();
                    }
                    else if (dsEmpName.Tables[0].Rows[0]["DesignationCode"].ToString() == "")
                    {

                        Response.Write("1," + dsEmpName.Tables[0].Rows[0]["EmployeeName"].ToString());
                        Response.End();
                    }
                    else
                    {
                        strEmpDesignation = dsEmpName.Tables[0].Rows[0]["DesignationCode"].ToString();
                        strEmpDesignationDesc = dsEmpName.Tables[0].Rows[0]["DesignationDesc"].ToString();
                        strEmpName = dsEmpName.Tables[0].Rows[0]["EmployeeName"].ToString();
                        //strRoleId = dsEmpName.Tables[0].Rows[0]["RoleCode"].ToString();
                        strEmpRoleDesc = dsEmpName.Tables[0].Rows[0]["RoleDesc"].ToString();
                    }
                }
                else
                {

                    Response.Write("3," + Resources.Resource.InvalidEmployee);
                    Response.End();
                }
            }

            string strTimeFrom = DateTime.Now.Date.ToString("dd-MMM-yyyy") + " " + strTimeFrom1;
            string strTimeTo = DateTime.Now.Date.ToString("dd-MMM-yyyy") + " " + strTimeTo1;

            if (strShift == "")
            {
                Response.Write("3," + Resources.Resource.ShiftCanNotBeLeftBlank);
                Response.End();
            }


            if (strEmpNo != "" && strShift != "" && intRosterAutoID == 0)
            {
                ds = objRost.RotaInsert(strAsmtCode, int.Parse(BaseLocationAutoID), intPdLineNo, strFromDate, strEmpNo, strRoleId, strEmpDesignation, strShift, strTimeFrom, strTimeTo, intDutyHrs, strDutyType, TimeStatus,BreakHours, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "11")    /// 11-insert fail 
                    {
                        //string str1 = "9";
                        string str1 = "11";
                        string str2 = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString().Trim());
                        string str3 = "";
                        string str4 = "";
                        string str5 = "";
                        string str6 = "";
                        string str7 = "";
                        string str8 = "";
                        string str9 = "";
                        string str10 = "";
                        string str11 = "";
                        string str12 = "";

                        //string str3 = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
                        //string str4 = ds.Tables[0].Rows[0]["DutyDate"].ToString();
                        //string str5 = ds.Tables[0].Rows[0]["TimeFrom"].ToString();
                        //string str6 = ds.Tables[0].Rows[0]["TimeTo"].ToString();
                        //string str7 = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
                        //string str8 = ds.Tables[0].Rows[0]["RosterAutoId"].ToString();
                        //string str9 = "";
                        //string str10 = "";
                        str3 = str3 + ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
                        str4 = str4 + ds.Tables[0].Rows[0]["DutyDate"].ToString();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            str5 = str5 + "[" + ds.Tables[0].Rows[i]["TimeFrom"].ToString() + "]  "; ;
                            str6 = str6 + "[" + ds.Tables[0].Rows[i]["TimeTo"].ToString() + "]  ";
                            str7 = str7 + "[" + ds.Tables[0].Rows[i]["AsmtCode"].ToString() + "]  ";
                            //str8 = str8 + "[" + ds.Tables[0].Rows[i]["RosterAutoId"].ToString() + "]  ";
                            str8 = str8 + ds.Tables[0].Rows[i]["RosterAutoId"].ToString() + " ";
                            str9 = str9 + "";
                            str10 = str10 + "[" + ds.Tables[0].Rows[i]["LocationCode"].ToString() + "]  ";
                            str11 = str11 + "[" + ds.Tables[0].Rows[i]["ClientName"].ToString() + "]  ";
                            
                        }
                        str12 = str12 + "[" + ds.Tables[0].Rows[0]["TimeStatus"].ToString() + "]  ";
                        Response.Write(str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + "," + str10 + "," + str11 + "," + str12);
                        Response.End();

                    }
                    else
                    {
                        string str1 = ds.Tables[0].Rows[0]["MessageID"].ToString();
                        string str2 = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString().Trim());
                        string str3 = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
                        string str4 = ds.Tables[0].Rows[0]["DutyDate"].ToString();
                        string str5 = ds.Tables[0].Rows[0]["TimeFrom"].ToString();
                        string str6 = ds.Tables[0].Rows[0]["TimeTo"].ToString();
                        string str7 = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
                        string str8 = ds.Tables[0].Rows[0]["RosterAutoId"].ToString();
                        string str9 = "";
                        string str10 = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                        string str11 = ds.Tables[0].Rows[0]["ClientName"].ToString();
                        string str12 = ds.Tables[0].Rows[0]["TimeStatus"].ToString();

                        Response.Write(str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + strEmpName + "," + strEmpDesignationDesc + "," + str11 + "," + strRoleId + "," + strEmpRoleDesc + "," + str12);
                        Response.End();

                    }


                }
                else
                {

                }

            }
            else if (intRosterAutoID != 0)
            {
                ds = objRost.RotaUpdate(intRosterAutoID, strAsmtCode, strEmpNo, strEmpDesignation, strShift, strTimeFrom, strTimeTo, intDutyHrs, strRoleId, strDutyType, TimeStatus, BreakHours, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "11")
                    {
                        //string str1 = "9";
                        string str1 = "11";
                        string str2 = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString().Trim());
                        string str3 = "";
                        string str4 = "";
                        string str5 = "";
                        string str6 = "";
                        string str7 = "";
                        string str8 = "";
                        string str9 = "";
                        string str10 = "";
                        string str11 = "";
                        string str12 = "";

                        str3 = str3 + ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
                        str4 = str4 + ds.Tables[0].Rows[0]["DutyDate"].ToString();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            str5 = str5 + "[" + ds.Tables[0].Rows[i]["TimeFrom"].ToString() + "]  "; ;
                            str6 = str6 + "[" + ds.Tables[0].Rows[i]["TimeTo"].ToString() + "]  ";
                            str7 = str7 + "[" + ds.Tables[0].Rows[i]["AsmtCode"].ToString() + "]  ";
                            str8 = str8 + ds.Tables[0].Rows[i]["RosterAutoId"].ToString() + " ";
                            str9 = str9 + "";
                            str10 = str10 + ds.Tables[0].Rows[i]["LocationCode"].ToString() + " ";
                            str11 = str11 + ds.Tables[0].Rows[i]["ClientName"].ToString() + " ";
                        }
                        str12 = str12 + "[" + ds.Tables[0].Rows[0]["TimeStatus"].ToString() + "]  ";
                        Response.Write(str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + "," + str10 + "," + str11 + "," + str12);
                        Response.End();
                        //string str1 = "9";
                        //string str2 = ds.Tables[0].Rows[0]["MessageString"].ToString();
                        //string str3 = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
                        //string str4 = ds.Tables[0].Rows[0]["DutyDate"].ToString();
                        //string str5 = ds.Tables[0].Rows[0]["TimeFrom"].ToString();
                        //string str6 = ds.Tables[0].Rows[0]["TimeTo"].ToString();
                        //string str7 = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
                        //string str8 = ds.Tables[0].Rows[0]["RosterAutoId"].ToString();
                        //string str9 = "";
                        //string str10 = "";
                        //Response.Write(str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + "," + str10);
                        //Response.End();
                    }
                    else
                    {
                        string str1 = ds.Tables[0].Rows[0]["MessageID"].ToString();
                        string str2 = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString().Trim());
                        string str3 = "";
                        string str4 = "";
                        string str5 = "";
                        string str6 = "";
                        string str7 = "";
                        string str8 = "";
                        string str9 = "";
                        string str10 = ds.Tables[0].Rows[0]["LocationCode"].ToString();
                        string str11 = ds.Tables[0].Rows[0]["ClientName"].ToString();
                        string str12 = ds.Tables[0].Rows[0]["TimeStatus"].ToString();

                        Response.Write(str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + "," + str10 + "," + str11 + "," + str12);
                        Response.End();
                    }



                }
                else
                {

                }
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
