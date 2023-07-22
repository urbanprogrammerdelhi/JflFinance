// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="MastersFillerHelper.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data;
using System.Web.UI.WebControls;
using BL;
using Resources;

/// <summary>
///     Summary description for Masters
/// </summary>
public class MastersFillerHelper : BasePage
{
    #region Load Clients

    /// <summary>
    ///     Fills the clients.
    /// </summary>
    /// <param name="DropDownList1">The drop down list1.</param>
    /// <param name="BaseLocationAutoID">The Base location auto ID.</param>
    public static void FillClients(DropDownList DropDownList1, string BaseLocationAutoID)
    {
        var objSale = new Sales();
        var dsClient = new DataSet();
        dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);
        DropDownList1.DataSource = dsClient;
        DropDownList1.DataTextField = "ClientName";
        DropDownList1.DataValueField = "ClientCode";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem(Resource.SelectClient, ""));
    }

    #endregion

    /// <summary>
    ///     Fills the employees.
    /// </summary>
    /// <param name="ddlEmployeeNumber">The DDL employee number.</param>
    /// <param name="CompanyCode">The company code.</param>
    /// <param name="LocationCode">The location code.</param>
    public static void FillEmployees(DropDownList ddlEmployeeNumber, string CompanyCode, string LocationCode)
    {
        var objHRManagement = new HRManagement();
        var ds = new DataSet();
        ds = objHRManagement.EmployeesOfHRLocationGetAll(CompanyCode, LocationCode);
        ddlEmployeeNumber.DataSource = ds.Tables[0];
        ddlEmployeeNumber.DataTextField = "EmployeeName";
        ddlEmployeeNumber.DataValueField = "EmployeeNumber";
        ddlEmployeeNumber.DataBind();
    }

    /// <summary>
    ///     Fills the PD line of assignment.
    /// </summary>
    /// <param name="DropDownList1">The drop down list1.</param>
    /// <param name="LocationCode">The location code.</param>
    /// <param name="ClientCode">The client code.</param>
    /// <param name="AssignmentID">The assignment ID.</param>
    /// <param name="AssignmentCode">The assignment code.</param>
    /// <param name="AssignmentAmmendNo">The assignment ammend no.</param>
    public static void FillPDLineOfAssignment(DropDownList DropDownList1,
        string LocationCode, string ClientCode, string AssignmentID, string AssignmentCode, string AssignmentAmmendNo)
    {
        DropDownList1.Items.Add("1");
        DropDownList1.Items.Add("2");
        DropDownList1.Items.Add("3");

        return;

        var objOperationManagement = new OperationManagement();

        var ds = objOperationManagement.AsmtPostDeploymentGet(LocationCode,
            ClientCode, AssignmentID, AssignmentID, AssignmentAmmendNo);

        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataTextField = "PDLineNo";
        DropDownList1.DataValueField = "PDLineNo";
        DropDownList1.DataBind();
    }

    /// <summary>
    ///     Fillddls the week days hours.
    /// </summary>
    /// <param name="ddl">The DDL.</param>
    /// <param name="CompanyCode">The company code.</param>
    public static void FillddlWeekDaysHours(DropDownList ddl, string CompanyCode)
    {
        var dt = new DataTable();
        dt.Columns.Add("Col1");
        DataRow dr;

        for (var i = 1; i < 25; i++)
        {
            dr = dt.NewRow();
            dr["Col1"] = i.ToString();
            dt.Rows.Add(dr);
        }

        ddl.DataSource = dt;
        ddl.DataValueField = "Col1";
        ddl.DataTextField = "Col1";

        ddl.DataBind();
        //DataSet ds = new DataSet();
        //BL.Sales objSales = new BL.Sales();
        //ds = objSales.blQuickCodeDeploymentPattern_Get(CompanyCode);

        //ddl.DataSource = ds.Tables[0];


        //ddl.DataValueField = "DeploymentPat";
        //ddl.DataTextField = "DeploymentPattern";
        //ddl.DataBind();
    }

    /// <summary>
    ///     Fills the DDL for standard shift.
    /// </summary>
    /// <param name="ddl">The DDL.</param>
    /// <param name="LocationAutoID">The location auto ID.</param>
    public static void FillDDLForStandardShift(DropDownList ddl, string LocationAutoID)
    {
        var objblMasterManagement = new MastersManagement();
        var ds = new DataSet();
        ds = objblMasterManagement.StandardSiftsGetAll(LocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = ds.Tables[0];
            ddl.DataValueField = "ShiftCode";
            ddl.DataTextField = "ShiftDesc";
            ddl.DataBind();
        }
    }

    #region Assignments

    //public static void FillAssignments(DropDownList DropDownList1, int intLocId, string strClientCode,
    //string FromDate, string ToDate, string strAreaIncharge, string strIsAreaIncharge)
    //{
    //    BL.OperationManagement objOperationManagement = new BL.OperationManagement();
    //    DataSet dsAsmt = new DataSet();
    //    dsAsmt = objOperationManagement.AssignmentsOfClientGet(intLocId, strClientCode,
    //        FromDate, ToDate, strAreaIncharge, strIsAreaIncharge);

    //    DropDownList1.DataSource = dsAsmt;
    //    DropDownList1.DataTextField = "AsmtAddress";
    //    DropDownList1.DataValueField = "AsmtCode";
    //    DropDownList1.DataBind();
    //    DropDownList1.Items.Insert(0, new ListItem(Resources.Resource.SelectAssignment, ""));
    //}
    //public static void FillAssignments(DropDownList DropDownList1, int intLocId, string strClientCode, string strAreaIncharge, string strIsAreaIncharge)
    //{
    //    BL.OperationManagement objOperationManagement = new BL.OperationManagement();
    //    DataSet dsAsmt = new DataSet();
    //    dsAsmt = objOperationManagement.AssignmentsOfClientGet(intLocId, strClientCode, "", "", strAreaIncharge, strIsAreaIncharge);

    //    DropDownList1.DataSource = dsAsmt;
    //    DropDownList1.DataTextField = "AsmtAddress";
    //    DropDownList1.DataValueField = "AsmtCode";
    //    DropDownList1.DataBind();
    //    DropDownList1.Items.Insert(0, new ListItem(Resources.Resource.SelectAssignment, ""));

    //}

    #endregion
}