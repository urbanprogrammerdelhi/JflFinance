// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="GetEmployeeHistroyDetailAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Class HRManagement_GetEmployeeHistroyDetailAjax
/// </summary>
public partial class HRManagement_GetEmployeeHistroyDetailAjax : BasePage //System.Web.UI.Page
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
        // if (IsReadAccess == true)
        //{

        string strCompany = Request.QueryString["Company"];
        string LocationAutoID = Request.QueryString["LocationAutoID"];
        string strEmployeeNumber = Request.QueryString["EmployeeNumber"];
        string strGetField = Request.QueryString["GetField"];
        string EmployeeName = Request.QueryString["EmployeeName"];
        string CompanyDesc = Request.QueryString["CompanyDesc"];
        string HrLocationDesc = Request.QueryString["HrLocationDesc"];
        string LocationDesc = Request.QueryString["LocationDesc"];
        string DesignationDesc = Request.QueryString["DesignationDesc"];
        string CategoryDesc = Request.QueryString["CategoryDesc"];
        string JobTypeDesc = Request.QueryString["JobTypeDesc"];
        string JobClassDesc = Request.QueryString["JobClassDesc"];
        string RoleDesc = Request.QueryString["RoleDesc"];

        string AreaDesc = Request.QueryString["AreaDesc"];

        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();

        ds = objHRManagement.EmployeeHistoryDetailGet(strCompany, int.Parse(LocationAutoID.ToString()), strEmployeeNumber, strGetField);

        string str1 = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        string str5 = "";
        string str6 = "";
        string str7 = "";
        string str8 = "";
        str1 = str1 + Resources.Resource.EmployeeNumber + " :" + ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
        str2 = str2 + Resources.Resource.EmployeeName + " :" + EmployeeName;
        str3 = str3 + Resources.Resource.Company + " :" + CompanyDesc;
        str4 = str4 + Resources.Resource.HrLocation + " :" + HrLocationDesc;
        str5 = str5 + Resources.Resource.Location + " :" + LocationDesc;
        if (strGetField.ToLower() == "Designation".ToLower())
        {
            str6 = str6 + Resources.Resource.Designation + " :" + DesignationDesc;
        }
        else if (strGetField.ToLower() == "Category".ToLower())
        {
            str6 = str6 + Resources.Resource.Category + " :" + CategoryDesc;
        }
        else if (strGetField.ToLower() == "Jobtype".ToLower())
        {
            str6 = str6 + Resources.Resource.JobType + " :" + JobTypeDesc;
        }
        else if (strGetField.ToLower() == "JobClass".ToLower())
        {
            str6 = str6 + Resources.Resource.JobClass + " :" + JobClassDesc;
        }
        else if (strGetField.ToLower() == "Role".ToLower())
        {
            str6 = str6 + Resources.Resource.Role + " :" + RoleDesc;
        }
        else if (strGetField.ToLower() == "AreaID".ToLower())
        {
            str6 = str6 + Resources.Resource.AreaID + " :" + AreaDesc;
        }
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            str7 = str7 + Resources.Resource.EffectiveFrom + " :" + ds.Tables[0].Rows[0]["EffectiveFrom"].ToString();
            str8 = str8 + Resources.Resource.EffectiveTo + " :" + ds.Tables[0].Rows[0]["EffectiveTo"].ToString();
        }
        Response.Write(str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8);
        Response.End();
    }
}
