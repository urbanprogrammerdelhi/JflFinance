// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getAsmtContractHrsAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getAsmtContractHrsAjax.
/// </summary>
public partial class Transactions_getAsmtContractHrsAjax : BasePage //System.Web.UI.Page
{


    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string strAsmtCode = Request.QueryString["AsmtCode"];
        string strFromDate = Request.QueryString["FDate"];
        string strToDate = Request.QueryString["TDate"];


        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();


        ds = objRoster.ContractHoursOfAsmtGet(int.Parse(BaseLocationAutoID), strAsmtCode, strFromDate, strToDate);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Response.Write(HrsMinFormat(ds.Tables[0].Rows[0][0].ToString()) + "||" + HrsMinFormat(ds.Tables[0].Rows[0][1].ToString()));
            Response.End();
        }
        else
        {
            Response.Write("0");
            Response.End();
        }


    }

    #region Hrs2Minute 
    /// <summary>
    /// HRSs the minimum format.
    /// </summary>
    /// <param name="strHrs">The string HRS.</param>
    /// <returns>System.String.</returns>
    protected string HrsMinFormat(string strHrs)
    {
        if (strHrs.IndexOf(".") > 1)
        {
            char[] arr = new char[] { '.' };
            string[] strSplitArr = strHrs.Split(arr);
            string strH = strSplitArr[0];
            if (strH.Length < 2)
            {
                strH = "0" + strH;
            }

            string strMin = (Math.Round(Convert.ToDouble("0." + strSplitArr[1])*60)).ToString() ;

            if (strMin.Length < 2)
            {
                strMin = "0" + strMin;
            }

            return strH + ":" + strMin;

        }
        else
        {
            return "00:00";
        }
    }
    #endregion

}
