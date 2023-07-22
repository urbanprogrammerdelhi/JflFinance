// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="EmpPersonalDetails.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class HRManagement_EmpPersonalDetails
/// </summary>
public partial class HRManagement_EmpPersonalDetails : BasePage
{
    /// <summary>
    /// The dataset
    /// </summary>
    static DataSet dataset = new DataSet();
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillddlAreaID();
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EmployeePersonalDetails + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            FillddlDivision(); 
        }
        fillgrid();
            
    
    }


    //Added By Manish 05-06-2012
    /// <summary>
    /// Fillddls the division.
    /// </summary>
    private void FillddlDivision()
    {
        DataSet dsDivision = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();

            ddlDivision.SelectedValue = BaseHrLocationCode.ToString();

            FillddlBranch();
        }
    }

    //Added By Manish 05-06-2012
    /// <summary>
    /// Fillddls the area ID.
    /// </summary>
    private void FillddlAreaID()
    {
        DDLAreaID.Items.Clear();
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsArea = new DataSet();
        dsArea = objSale.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID);
        DDLAreaID.DataTextField = "AreaDesc";
        DDLAreaID.DataValueField = "AreaID";
        DDLAreaID.DataSource = dsArea;
        DDLAreaID.DataBind();

        ListItem li = new ListItem();
        li.Text = "All";
        li.Value = "All";
        DDLAreaID.Items.Insert(0, li);

    }
    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedItem.Value.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            DataRow dr = dsBranch.Tables[0].NewRow();
            dr["LocationCode"] = "All";
            dr["LocationDesc"] = "All";
            dsBranch.Tables[0].Rows.InsertAt(dr, 0);
            msddlBranch.CreateCheckBox(dsBranch.Tables[0], "LocationDesc", "LocationCode");

            int msddlBranchselectedIndex;
            msddlBranchselectedIndex = 0;
            for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
            {
                if (dsBranch.Tables[0].Rows[i]["LocationCode"].ToString() == BaseLocationCode.ToString())
                {
                    msddlBranch.selectedIndex = i.ToString();
                    i = dsBranch.Tables[0].Rows.Count;
                }
            }

            if (msddlBranchselectedIndex != 0)
            {
                msddlBranch.selectedIndex = "1";
            }
        }


    }
    /// <summary>
    /// Handles the submit event of the btn control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btn_submit(object sender, EventArgs e)
    {
        ASPxGridViewExporter1.GridViewID = "grid";
        ASPxGridViewExporter1.WriteCsvToResponse();

    }
    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    
    /// <summary>
    /// Fillgrids this instance.
    /// </summary>
    private  void fillgrid()

    {

        BL.HRManagement HrObject = new BL.HRManagement();

        dataset = HrObject.EmployeePersonalDetailsGetAll(BaseCompanyCode, ddlDivision.SelectedItem.Value.ToString(), msddlBranch.sValue.ToString(), DDLAreaID.SelectedValue);

        grid.DataSource = dataset;
        grid.DataBind();
    
    }
    
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlBranch();
    }
}
