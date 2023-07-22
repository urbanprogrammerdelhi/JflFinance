// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="KPIEstablishmentRatio.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class KPIAdmin_KPIEstablishmentRatio
/// </summary>
public partial class KPIAdmin_KPIEstablishmentRatio : BasePage//System.Web.UI.Page
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
            FillKPIEstablishment();
        
        }


    }

    /// <summary>
    /// Fills the KPI establishment.
    /// </summary>
    private void FillKPIEstablishment()
    {

        BL.KPI kpi = new BL.KPI();
       // BL.OperationManagement OperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //try
        //{
        int dtflag;
        dtflag = 1;
        ds = kpi.GetEstablishmentValue(BaseLocationAutoID);
        dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        KPIEstablishment.DataSource = dt;
        KPIEstablishment.DataBind();
       
         if (dtflag == 0)//to fix empty gridview
        {
            KPIEstablishment.Rows[0].Visible = false;
        }
        //}
        //catch (Exception ex) { KPIEstablishment.Columns[0].Visible = false; }
    }


    /// <summary>
    /// Handles the RowDeleting event of the KPIEstablishment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void KPIEstablishment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        DataSet ds = new DataSet();
        Label lblTotalEstablishment = (Label)KPIEstablishment.Rows[e.RowIndex].FindControl("lblTotalEstablishment");
        Label lblEffectiveFrom = (Label)KPIEstablishment.Rows[e.RowIndex].FindControl("lblEffectiveFrom");
        Label lblEffectiveTo = (Label)KPIEstablishment.Rows[e.RowIndex].FindControl("lblEffectiveTo");

        BL.KPI kpiObj = new BL.KPI();

        ds = kpiObj.EstablishmentDelete(BaseLocationAutoID, lblTotalEstablishment.Text, lblEffectiveFrom.Text, lblEffectiveTo.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }


        FillKPIEstablishment();

    }
    /// <summary>
    /// Handles the RowCommand event of the KPIEstablishment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void KPIEstablishment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
       
        DateTime dt = new DateTime();
        DataSet ds = new DataSet();
         
        BL.KPI objKpi = new  BL.KPI();
        TextBox txtTotalEstablishment = (TextBox)KPIEstablishment.FooterRow.FindControl("txtTotalEstablishment");
        
        TextBox txtEffectiveFrom = (TextBox)KPIEstablishment.FooterRow.FindControl("txtEffectiveFrom");
        if (e.CommandName.Equals("AddNew"))
        {
            try
            {
                dt = DateTime.Parse(txtEffectiveFrom.Text);
            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = Resources.Resource.InvalidDate;
                return;
            }
            DateTime firstDayOfTheMonth = new DateTime(dt.Year, dt.Month, 1);
            if (CheckDate(firstDayOfTheMonth.ToString(), firstDayOfTheMonth.AddMonths(1).AddDays(-1).ToString()))
            {
                ds = objKpi.EstablishmentValueInsert(BaseLocationAutoID, txtTotalEstablishment.Text, firstDayOfTheMonth.ToString(), firstDayOfTheMonth.AddMonths(1).AddDays(-1).ToString());
               
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgEffectiveToDateShouldBeGreaterThanFromDate;
                return;
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())==144)
                {
                    return;
                }

                FillKPIEstablishment();
            }


        }

        
      
        if (e.CommandName.Equals("Reset"))
        {
            txtTotalEstablishment.Text = "";
            txtEffectiveFrom.Text = "";
            //txtEffectiveTo.Text = "";
        }

        
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the KPIEstablishment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void KPIEstablishment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        KPIEstablishment.PageIndex = e.NewPageIndex;
        KPIEstablishment.EditIndex = -1;
        FillKPIEstablishment();
    }
    /// <summary>
    /// Handles the RowEditing event of the KPIEstablishment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void KPIEstablishment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        KPIEstablishment.EditIndex = e.NewEditIndex;
        FillKPIEstablishment();

    }

    /// <summary>
    /// Handles the RowUpdating event of the KPIEstablishment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void KPIEstablishment_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        TextBox txtTotalEstablishment = (TextBox)KPIEstablishment.Rows[e.RowIndex].FindControl("txtTotalEstablishment");
        Label lblEffectiveFrom = (Label)KPIEstablishment.Rows[e.RowIndex].FindControl("lblEffectiveFrom");
        Label lblEffectiveTo = (Label)KPIEstablishment.Rows[e.RowIndex].FindControl("lblEffectiveTo");
         BL.KPI  objKpiUpdate = new BL.KPI();
        DataSet dsUpdate = new DataSet();
        dsUpdate = objKpiUpdate.EstablishmentValueUpdate(BaseLocationAutoID, txtTotalEstablishment.Text, lblEffectiveFrom.Text, lblEffectiveTo.Text);

            if (dsUpdate != null && dsUpdate.Tables.Count > 0 && dsUpdate.Tables[0].Rows.Count > 0)
            {
                 DisplayMessage(lblErrorMsg, dsUpdate.Tables[0].Rows[0]["MessageID"].ToString()); 
              
            }
            KPIEstablishment.EditIndex = -1;
            FillKPIEstablishment();
     
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the KPIEstablishment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void KPIEstablishment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        KPIEstablishment.EditIndex = -1;
        FillKPIEstablishment();
    }


    /// <summary>
    /// Checks the date.
    /// </summary>
    /// <param name="txtEffectiveFrom">The TXT effective from.</param>
    /// <param name="txtEffectiveTo">The TXT effective to.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
    protected bool CheckDate(string txtEffectiveFrom,string txtEffectiveTo)
    {
      
         bool flag=false;
        if(DateTime.Parse(DateFormat(txtEffectiveFrom)) < DateTime.Parse(DateFormat(txtEffectiveTo)))
      {
         flag=true;
      }
    
     return flag;
    }


}


