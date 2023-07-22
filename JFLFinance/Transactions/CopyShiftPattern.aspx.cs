// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="CopyShiftPattern.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_CopyShiftPattern.
/// </summary>
public partial class Transactions_CopyShiftPattern : BasePage //System.Web.UI.Page
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
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.CopyShiftPattern + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            Client_Load();
            FillClient();
            //gvErrorMessage.Visible = false;
        }
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        FillddlAsmt(ddlClient.SelectedItem.Value.ToString());
        ddlShiftPattern.Text = "";
        ddlCopyToAsmt.Text = "";
        //gvErrorMessage.Visible = false;
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList ddlAsmt = (DropDownList)sender;
        //GridViewRow gvRow = (GridViewRow)ddlAsmt.NamingContainer;
        //DropDownList ddlAsmt = (DropDownList)e.Row.FindControl("ddlAsmt");
        FillAsmtSftPattern(ddlAsmt.SelectedItem.Value.ToString());
        ddlShiftPattern.Text = "";
        ddlCopyToAsmt.Text = "";
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlShiftPattern control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlShiftPattern_SelectedIndexChanged(object sender, EventArgs e)
    {
        // DropDownList ddlShiftPattern = (DropDownList)sender;
        // GridViewRow gvRow = (GridViewRow)ddlShiftPattern.NamingContainer;

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientSelect control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
         
        // DropDownList ddlShiftPattern = (DropDownList)sender;
        // GridViewRow gvRow = (GridViewRow)ddlShiftPattern.NamingContainer;
        FillddlCopyToAsmt(ddlClientSelect.SelectedItem.Value.ToString());
        ddlCopyToAsmt.Text = "";
        //gvErrorMessage.Visible = false;
    }


    /// <summary>
    /// Handles the PageIndexChanging event of the grdPatternInfo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void grdPatternInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPatternInfo.PageIndex = e.NewPageIndex;
        grdPatternInfo.EditIndex = -1;
        //FillErrorMessageGrid();
    }
    /// <summary>
    /// Client_s the load.
    /// </summary>
    protected void Client_Load()
    {
        int intLocId = int.Parse(BaseLocationAutoID);
        BL.Sales objSale = new BL.Sales();
        DataSet dsClient = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);
        }

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = dsClient.Tables[0].DefaultView;
            ddlClient.DataTextField = "ClientName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();
            //ListItem li = new ListItem();
            //li.Text = "Select";
            //li.Value = "0";
            //ddlClient.Items.Add(li);
            if (ddlClient.SelectedItem.Value.ToString() != null)
            {
                FillddlAsmt(ddlClient.SelectedItem.Value.ToString());
            }

        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlClient.Items.Add(li);
        }

    }
    /// <summary>
    /// Fills the client.
    /// </summary>
    protected void FillClient()
    {
        int intLocId = int.Parse(BaseLocationAutoID);
        BL.Sales objSale = new BL.Sales();
        DataSet dsClient = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);
        }

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            
            ddlClientSelect.DataSource = dsClient.Tables[0].DefaultView;
            ddlClientSelect.DataTextField = "ClientName";
            ddlClientSelect.DataValueField = "ClientCode";
            ddlClientSelect.DataBind();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.Select;
            li.Value = "0";
            ddlClientSelect.Items.Insert(0, li);
            //ListItem li1 = new ListItem();
            //li1.Text = "All";
            //li1.Value = "All";
            //ddlClientSelect.Items.Insert(0, li1);
            //if (ddlClient.SelectedItem.Value.ToString() != null)
            //{
            //    FillddlAsmt(ddlClient.SelectedItem.Value.ToString());
            //}

        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlClientSelect.Items.Add(li);
        }

    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    /// <param name="strClientCode">The string client code.</param>
    private void FillddlAsmt(string strClientCode)
    {

        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AssignmentsOfClientGetBasedOnBranchAndDivisionCode(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strClientCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAsmt.DataSource = ds.Tables[0];
            ddlAsmt.DataTextField = "AsmtDetail";
            ddlAsmt.DataValueField = "AsmtCode";
            ddlAsmt.DataBind();


            if (ddlAsmt != null)
            {
                FillAsmtSftPattern(ddlAsmt.SelectedItem.Value.ToString());
            }
        }
        else
        {
            ddlAsmt.Items.Clear();
            ddlShiftPattern.Items.Clear();
        }
        //ListItem li = new ListItem();
        //li.Text = Resources.Resource.All;
        //li.Value = "All";
        //ddlAsmt.Items.Insert(0, li);
    }

    /// <summary>
    /// Fillddls the copy to asmt.
    /// </summary>
    /// <param name="strClientCode">The string client code.</param>
    private void FillddlCopyToAsmt(string strClientCode)
    {

        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.AssignmentsOfClientGetBasedOnBranchAndDivisionCode(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strClientCode);
        ddlCopyToAsmt.DataSource = ds.Tables[0];
        ddlCopyToAsmt.DataTextField = "AsmtDetail";
        ddlCopyToAsmt.DataValueField = "AsmtCode";
        ddlCopyToAsmt.DataBind();
        //ListItem li = new ListItem();
        //li.Text = Resources.Resource.All;
        //li.Value = "All";
        //ddlCopyToAsmt.Items.Insert(0, li);
    }



    /// <summary>
    /// Fills the asmt SFT pattern.
    /// </summary>
    /// <param name="strasmtcode">The strasmtcode.</param>
    protected void FillAsmtSftPattern(string strasmtcode)
    {
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = objRoster.AsmtShiftPatternGet(BaseLocationAutoID, strasmtcode);
        ddlShiftPattern.DataSource = ds.Tables[0];
        ddlShiftPattern.DataTextField = "ShiftPattern";
        ddlShiftPattern.DataValueField = "ShiftPatternID";
        ddlShiftPattern.DataBind();
        ////ListItem li = new ListItem();
        ////li.Text = Resources.Resource.All;
        ////li.Value = "All";
        ////ddlShiftPattern.Items.Insert(0, li);
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvErrorMessage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvErrorMessage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReason = (Label)e.Row.FindControl("lblReason");
            if (lblReason != null)
            {
                
                    lblReason.Text = ResourceValueOfKey_Get(lblReason.Text.ToString());
                
                
            }
        }
    }
    /// <summary>
    /// Fills the error message grid.
    /// </summary>
    protected void FillErrorMessageGrid()
    {

        string strUserShiftPattern = string.Empty;
        for (int i = 0; i < grdPatternInfo.Rows.Count; i++)
        {

            TextBox txtShiftPatternid = (TextBox)grdPatternInfo.Rows[i].FindControl("TxtShiftPattern");
            strUserShiftPattern = strUserShiftPattern + "," + txtShiftPatternid.Text;
        }
        
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        if (ddlAsmt.SelectedItem != null && ddlShiftPattern.Text != "")
        {
            ds = objRoster.AsmtCopyShiftPatternSave(BaseLocationAutoID, ddlAsmt.SelectedItem.Value.ToString(), ddlShiftPattern.Text, strUserShiftPattern, ddlCopyToAsmt.Text, "1");
            //DataTable dt = new DataTable();
            //foreach (DataRow row in dt.Rows)
            //{
            //    row["MessageString"] = ResourceValueOfKey_Get(dt.Rows[0]["MessageString"].ToString());
            //}
            
            gvErrorMessage.DataSource = ds.Tables[0];
            gvErrorMessage.DataBind();
           
        }
        else
        {
            gvErrorMessage.DataSource = null;
            gvErrorMessage.DataBind();
            lblErrorMsg.Text = Resources.Resource.InvalidShiftPattern;
        }

        
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    lblErrorMsg.Text = Resources.Resource.TransactionDateCannotBeGreaterThanTerminationDate;
        //    for (int i = 0; i < myDataTable.Rows.Count; i++)
        //    {
        //        DataRow[] myDataRow = ds.Tables[0].Select("EmployeeNumber=" + myDataTable.Rows[i]["EmployeeNumber"]);
        //        if (myDataRow == null)
        //        {
        //            myDataTable.Rows[i].Delete();
        //            myDataTable.AcceptChanges();
        //        }
        //    }

        //    gvErrorMessage.DataSource = ds.Tables[0];
        //    gvErrorMessage.DataBind();
        //}
        //else
        //{
        //    gvErrorMessage.DataSource = null;
        //    gvErrorMessage.DataBind();
        //    lblErrorMsg.Text = Resources.Resource.Terminated;
        //}

    }

    /// <summary>
    /// Fillgrds the pattern information.
    /// </summary>
    protected void FillgrdPatternInfo()
    {
        grdPatternInfo.Visible = true;
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        if (ddlAsmt.SelectedItem != null && ddlShiftPattern.Text != "")
        {
            ds = objRoster.AsmtCopyShiftPatternSave(BaseLocationAutoID, ddlAsmt.SelectedItem.Value.ToString(), ddlShiftPattern.Text,"", ddlCopyToAsmt.Text,"0");
            grdPatternInfo.DataSource = ds.Tables[0];
            grdPatternInfo.DataBind();
        }
        else
        {
            grdPatternInfo.DataSource = null;
            grdPatternInfo.DataBind();
            lblErrorMsg.Text = Resources.Resource.InvalidShiftPattern;
        }
    }


    /// <summary>
    /// Handles the PageIndexChanging event of the gvErrorMessage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvErrorMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvErrorMessage.PageIndex = e.NewPageIndex;
        gvErrorMessage.EditIndex = -1;
        FillErrorMessageGrid();
    }




    /// <summary>
    /// Handles the Click event of the btnCopy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCopy_Click(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();

        BL.Roster objRoster = new BL.Roster();
        if (ddlAsmt.SelectedItem != null && ddlShiftPattern.Text != "")
        {
            Panel6.Visible = true;
            FillgrdPatternInfo();
            ModalPopupExtender2.Show();

        }
    }
    //    {
    //        ds = objRoster.blSchAsmtCopyShiftPattern_Save(BaseLocationAutoID, ddlAsmt.SelectedItem.Value.ToString(), ddlShiftPattern.Text, ddlCopyToAsmt.Text);
    //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //        {
    //            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

    //        }
           
    //     }
    //    else

    //    {
    //        gvErrorMessage.DataSource = null;
    //        gvErrorMessage.DataBind();
    //        lblErrorMsg.Text = Resources.Resource.InvalidShiftPattern;
    //    }
    //    FillErrorMessageGrid();
    //}




    /// <summary>
    /// Handles the Click event of the btnApply control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnApply_Click(object sender, EventArgs e)
    {
        string strUserShiftPattern = string.Empty;
        for (int i = 0; i < grdPatternInfo.Rows.Count; i++)
        {

            TextBox txtShiftPatternid = (TextBox)grdPatternInfo.Rows[i].FindControl("TxtShiftPattern");
            strUserShiftPattern = strUserShiftPattern + "," +txtShiftPatternid.Text;
        }
        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        if (ddlAsmt.SelectedItem != null && ddlShiftPattern.Text != "")
        {
           

            ds = objRoster.AsmtCopyShiftPatternSave(BaseLocationAutoID, ddlAsmt.SelectedItem.Value.ToString(), ddlShiftPattern.Text, strUserShiftPattern, ddlCopyToAsmt.Text,"1");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }
           
         }
        else

        {
            gvErrorMessage.DataSource = null;
            gvErrorMessage.DataBind();
            lblErrorMsg.Text = Resources.Resource.InvalidShiftPattern;
        }
        ModalPopupExtender2.Hide();
        FillErrorMessageGrid();
       // gvErrorMessage.Visible = true;
    }


    /// <summary>
    /// Handles the Click event of the btnClose control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClose_Click(object sender, EventArgs e)
    {
        ModalPopupExtender2.Hide();
        Response.Redirect("CopyShiftPattern.aspx");
    }

}
