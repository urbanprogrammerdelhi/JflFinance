// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getShiftsOfSitePostAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getShiftsOfSitePostAjax.
/// </summary>
public partial class Transactions_getShiftsOfSitePostAjax : BasePage //System.Web.UI.Page
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
        string strAsmtMasterAutoID = Request.QueryString["AsmtId"];
        string strPdLineNo = Request.QueryString["Pd"];
        string strDutyDate = Request.QueryString["Date1"];
        

        //string connect = System.Configuration.ConfigurationManager.AppSettings["conDB"];
        //SqlConnection scn = new SqlConnection(connect);
        //SqlCommand command = new SqlCommand("udpOPS_ShiftsOfSitePost_Get", scn);
        //command.CommandType = CommandType.StoredProcedure;
        //command.Parameters.Add("@LocationAutoID", SqlDbType.NVarChar).Value = int.Parse(BaseLocationAutoID.ToString());
        //command.Parameters.Add("@AsmtMasterAutoID", SqlDbType.NVarChar).Value = strAsmtId;
        //command.Parameters.Add("@PdLineNo", SqlDbType.NVarChar).Value = strPd;
        //command.Parameters.Add("@DutyDate", SqlDbType.NVarChar).Value = strDate;
        
        //scn.Open();
        DataTable dtData = new DataTable();
        DataSet ds = new DataSet();
        BL.Roster objRoster = new BL.Roster();
        ds = objRoster.ShiftsOfSitePostGet(BaseLocationAutoID, strAsmtMasterAutoID, strPdLineNo, strDutyDate);
        dtData = ds.Tables[0];
        //SqlDataAdapter adapter = new SqlDataAdapter(command);
        //DataTable dtData = new DataTable();
        //adapter.Fill(dtData);

        if (dtData.Rows.Count > 0)
        {
            Response.Write("<Shift>");
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                Response.Write("<ShiftCode>" + dtData.Rows[i]["Shift"].ToString() + "</ShiftCode>");
                Response.Write("<TimeFrom>" + dtData.Rows[i]["TimeFrom"].ToString() + "</TimeFrom>");
                Response.Write("<TimeTo>" + dtData.Rows[i]["TimeTo"].ToString() + "</TimeTo>");

            }
            Response.Write("</Shift>");
            Response.End();
        }
        else
        {
            Response.Write("0");
            Response.End();
        }


    }
}
