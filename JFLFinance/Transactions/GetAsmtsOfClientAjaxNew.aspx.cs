// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="GetAsmtsOfClientAjaxNew.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_GetAsmtsOfClientAjaxNew.
/// </summary>
public partial class Transactions_GetAsmtsOfClientAjaxNew : BasePage
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

        string strClientCode = Request.QueryString["ClCode"];
        string strFromDate = Request.QueryString["FromDate"];
        string strToDate = Request.QueryString["ToDate"];
        string strAreaID = Request.QueryString["AreaID"];
        string strTerDate = "";

        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet dsAsmt = new DataSet();
        dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), strClientCode, strFromDate, strToDate, BaseUserEmployeeNumber, BaseUserIsAreaIncharge,strAreaID);
        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            Response.Write("<Assignments>");
            for (int i = 0; i < dsAsmt.Tables[0].Rows.Count; i++)
            {
                strTerDate = dsAsmt.Tables[0].Rows[i]["Terminationdate"].ToString();
                //if (DateFormat(DateTime.Parse(strTerDate)) == "01-Jan-1900")
                //{
                //    strTerDate = "";
                //}
                //else
                //{
                //    strTerDate = dsAsmt.Tables[0].Rows[i]["Terminationdate"].ToString();
                //}
                if (strTerDate != "")
                {
                    strTerDate = DateTime.Parse(dsAsmt.Tables[0].Rows[i]["Terminationdate"].ToString()).ToString("dd-MMM-yyyy");
                }

                Response.Write("<AsmtMasterCode>" + dsAsmt.Tables[0].Rows[i]["AsmtCode"] + "</AsmtMasterCode>");
                ////Response.Write("<AsmtDesc>" + dsAsmt.Tables[0].Rows[i]["AsmtAddress"] + "$" + dsAsmt.Tables[0].Rows[i]["AsmtMasterAutoId"].ToString() + "$" + DateTime.Parse(dsAsmt.Tables[0].Rows[i]["AsmtStartDate"].ToString()).ToString("dd-MMM-yyyy") + "$" + strTerDate + "</AsmtDesc>");
                
                ////Response.Write("<AsmtDesc>" + dsAsmt.Tables[0].Rows[i]["AsmtAddress"] + "</AsmtDesc>");
                // Asmt Code and discription combined
                Response.Write("<AsmtDesc>" + "(" + dsAsmt.Tables[0].Rows[i]["AsmtCode"] + ")"  + dsAsmt.Tables[0].Rows[i]["AsmtAddress"] + "</AsmtDesc>");
                Response.Write("<AsmtStartDate>" + DateTime.Parse(dsAsmt.Tables[0].Rows[i]["AsmtStartDate"].ToString()).ToString("dd-MMM-yyyy") + "</AsmtStartDate>");
                Response.Write("<AsmtRenewalDate>" + strTerDate + "</AsmtRenewalDate>");
                Response.Write("<AsmtAutoId>" + dsAsmt.Tables[0].Rows[i]["AsmtMasterAutoId"].ToString() + "</AsmtAutoId>");
            }
            Response.Write("</Assignments>");
            Response.End();
        }
        else
        {
            Response.Write("0");
            Response.End();
        }
    }
}
