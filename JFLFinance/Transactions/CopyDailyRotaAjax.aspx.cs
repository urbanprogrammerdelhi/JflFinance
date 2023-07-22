// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="CopyDailyRotaAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_CopyDailyRotaAjax.
/// </summary>
public partial class Transactions_CopyDailyRotaAjax : BasePage //System.Web.UI.Page
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
        string strAsmtCode = Request.QueryString["Asmt"];
        string strDDate = Request.QueryString["DDate"];
        string strFDate = Request.QueryString["FDate"];
        string strTDate = Request.QueryString["TDate"];

        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        string strTbl = "Tbl" + Session.SessionID.ToString();
        ds = objRost.DailyRotaCopy(strTbl, strDDate, strFDate, strTDate, strAsmtCode, int.Parse(BaseLocationAutoID));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "21")
            {
                Response.Write("0," + Resources.Resource.MsgSuccessfullyCopied  );
                Response.End();
            }
            else if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "3")
            {
                int Flag = 0;
                Response.Write("3,<table width=450 border=1 >");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        if (Flag == 0)
                        {
                            Response.Write("<tr><td>");
                            Response.Write("<lable style='width:120px' id='lblMsgShiftToOverwrite" + j + "' >" +  ResourceValueOfKey_Get(ds.Tables[1].Rows[j]["MessageString"].ToString().Trim()) + "</lable>");
                            Response.Write("</td><td>");
                            Response.Write("<lable style='width:140px' id='lblAsmtCodeShiftToOverwrite" + j + "' >" + ds.Tables[1].Rows[j]["AsmtCode"] + "</lable>");
                            Response.Write("</td><td>");
                            Response.Write("<lable style='width:90px' id='lblDutyDateShiftToOverwrite" + j + "' >" + ds.Tables[1].Rows[j]["DutyDate"] + "</lable>");
                            Response.Write("</td><td>");
                            Response.Write("<lable style='width:70px' id='lblEmpNoShiftToOverwrite" + j + "' >" + ds.Tables[1].Rows[j]["EmployeeNumber"] + "</lable>");
                            Response.Write("</td><td>");
                            Response.Write("<lable style='width:60px' id='lblTimeFromShiftToOverwrite" + j + "' >" + ds.Tables[1].Rows[j]["TimeFrom"].ToString() + "</lable>");
                            Response.Write("</td><td>");
                            Response.Write("<lable style='width:60px' id='lblTimeToShiftToOverwrite" + j + "' >" + ds.Tables[1].Rows[j]["TimeTo"].ToString() + "</lable>");
                            Response.Write("</td><td>");
                            Response.Write("<input type='hidden' id='lblRostIdShiftToOverwrite" + j + "' value='" + ds.Tables[1].Rows[j]["RosterAutoId"].ToString() + "'    />");
                            //Response.Write("<input type='hidden' id='lblRostId1ShiftToOverwrite" + i + "' value='" + ds.Tables[1].Rows[i]["RosterAutoId1"].ToString() + "'    />");
                            Response.Write("</td></tr>");
                        }
                    }
                    Flag = 1;
                    Response.Write("<tr><td>");
                    Response.Write("<lable style='width:120px' id='lblMsg_dup" + i + "' >" + ResourceValueOfKey_Get(ds.Tables[0].Rows[i]["MessageString"].ToString().Trim())   + "</lable>");
                    Response.Write("</td><td>");
                    Response.Write("<lable style='width:140px' id='lblAsmtCode_dup" + i + "' >" + ds.Tables[0].Rows[i]["AsmtCode"] + "</lable>");
                    Response.Write("</td><td>");
                    Response.Write("<lable style='width:90px' id='lblDutyDate_dup" + i + "' >" + ds.Tables[0].Rows[i]["DutyDate"] + "</lable>");
                    Response.Write("</td><td>");
                    Response.Write("<lable style='width:70px' id='lblEmpNo_dup" + i + "' >" + ds.Tables[0].Rows[i]["EmployeeNumber"] + "</lable>");
                    Response.Write("</td><td>");
                    Response.Write("<lable style='width:60px' id='lblTimeFrom_dup" + i + "' >" + ds.Tables[0].Rows[i]["TimeFrom"].ToString() + "</lable>");
                    Response.Write("</td><td>");
                    Response.Write("<lable style='width:60px' id='lblTimeTo_dup" + i + "' >" + ds.Tables[0].Rows[i]["TimeTo"].ToString() + "</lable>");
                    Response.Write("</td><td>");
                    Response.Write("<input type='checkbox' id='chk" + i + "' />");
                    Response.Write("<input type='hidden' id='lblRostId_dup" + i + "' value='" + ds.Tables[0].Rows[i]["RosterAutoId"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='lblRostId1_dup" + i + "' value='" + ds.Tables[0].Rows[i]["RosterAutoId1"].ToString() + "'    />");
                    Response.Write("<input type='hidden' id='lblToatlNumberOfRows" + i + "' value='" + ds.Tables[0].Rows.Count.ToString() + "'    />");
                    Response.Write("</td></tr>");
                }
                
                Response.Write("</table >");
                Response.End();


            }
            else
            {
                string str1 = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString().Trim());
                Response.Write("0," + str1);
                Response.End();
            }
        }
        else
        {
            Response.Write("1," + Resources.Resource.NoRecordToCopy);
            Response.End();
        }

        Response.Write("7," + Resources.Resource.CanNotCopy);
        Response.End();
    }


}
