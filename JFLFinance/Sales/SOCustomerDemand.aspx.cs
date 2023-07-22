// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="SOCustomerDemand.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_SOCustomerDemand.
/// </summary>
public partial class Sales_SOCustomerDemand : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"] != null && Request.QueryString["SOAmendNO"] != null && Request.QueryString["SOLineNo"] != null)
            {
                if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["SoNo"].ToString() != "" && Request.QueryString["SOAmendNO"].ToString() != "" && Request.QueryString["SOLineNo"].ToString() != "")
                {
                    string strLocationAutoID = Request.QueryString["LocationAutoID"].ToString();
                    string strSONO = Request.QueryString["SoNo"].ToString();
                    string strSOAmendNo = Request.QueryString["SOAmendNO"].ToString();
                    string strSoLineNo = Request.QueryString["SOLineNo"].ToString();
                    string strSoStatus = Request.QueryString["SOStatus"].ToString();
                    string strChecked = Request.QueryString["Checked"].ToString();
                    string strMaxSoAmendNo = Request.QueryString["IsMAXSOAmendNo"].ToString();

                }
            }


        }

    }



    /// <summary>
    /// Handles the PageIndexChanging event of the grdCustomerDemand control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void grdCustomerDemand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCustomerDemand.PageIndex = e.NewPageIndex;
        grdCustomerDemand.EditIndex = -1;
        //FillErrorMessageGrid();
    }

    /// <summary>
    /// Handles the Click event of the btnApply control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnApply_Click(object sender, EventArgs e)
    {
        //string strUserShiftPattern = string.Empty;
        //for (int i = 0; i < grdPatternInfo.Rows.Count; i++)
        //{

        //    TextBox txtShiftPatternid = (TextBox)grdPatternInfo.Rows[i].FindControl("TxtShiftPattern");
        //    strUserShiftPattern = strUserShiftPattern + "," + txtShiftPatternid.Text;
        //}
        //DataSet ds = new DataSet();
        //BL.Roster objRoster = new BL.Roster();
        //if (ddlAsmt.SelectedItem != null && ddlShiftPattern.Text != "")
        //{


        //    ds = objRoster.blSchAsmtCopyShiftPattern_Save(BaseLocationAutoID, ddlAsmt.SelectedItem.Value.ToString(), ddlShiftPattern.Text, strUserShiftPattern, ddlCopyToAsmt.Text, "1");
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {

        //        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

        //    }

        //}
        //else
        //{
        //    gvErrorMessage.DataSource = null;
        //    gvErrorMessage.DataBind();
        //    lblErrorMsg.Text = Resources.Resource.InvalidShiftPattern;
        //}
        //ModalPopupExtender2.Hide();
        //FillErrorMessageGrid();
        //// gvErrorMessage.Visible = true;
    }


    /// <summary>
    /// Handles the Click event of the btnClose control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Response.Redirect("CopyShiftPattern.aspx");
    }

}
