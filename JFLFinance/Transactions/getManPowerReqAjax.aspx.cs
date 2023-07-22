// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="getManPowerReqAjax.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_getManPowerReqAjax.
/// </summary>
public partial class Transactions_getManPowerReqAjax : BasePage //System.Web.UI.Page
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
        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();

        int intAsmtAutoId = 0;

        int intLocationId;
        string strFDate, strTDate, strAsmtCode, attendType;
        intLocationId = int.Parse(BaseLocationAutoID);
        strFDate = Request.QueryString["Date1"];
        strTDate = Request.QueryString["Date2"];
        attendType = Request.QueryString["AttendType"];

        intAsmtAutoId = int.Parse(Request.QueryString["AsmtId"]); 
        int weekNo = int.Parse(Request.QueryString["weekNo"]);
        string scheduleType = Request.QueryString["scheduleType"];
        if (DateTime.Parse(strFDate) <= DateTime.Parse(strTDate))
        {
            if (intAsmtAutoId == 0)
            {
                Response.Write(Resources.Resource.InvalidAssignment);
                Response.End();
            }
            strAsmtCode = Request.QueryString["AsmtCode"];
            string strPostCode = Request.QueryString["PostCode"];
            // Added PostCode to Show Req and Schedule Hrs Post Wise
            ds = objRost.ManpowerRequirementGet(strFDate, strTDate, intAsmtAutoId, intLocationId, strPostCode, scheduleType, weekNo);

            DataSet dsSch = new DataSet();
            if (attendType == "Sch")
            {
                dsSch = objRost.ScheduledManpowerGet(strFDate, strTDate, strAsmtCode, intLocationId, strPostCode);
            }
            else
            {
                dsSch = objRost.ActualManpowerGet(strFDate, strTDate, strAsmtCode, intLocationId, strPostCode);
            }

            Response.Write("<table style='font-family:Verdana; font-size:smaller; cellpadding:1; cellspacing:0'  ><Tr><Td>"+  Resources.Resource.Date + " </Td>");

            int Status = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (DateTime.Parse(strFDate) <= DateTime.Parse(strTDate))
                {
                    int colname = 0;
                    double intReq = 0.0;
                    double intSch = 0.0;
                    colname = int.Parse(ds.Tables[0].Rows[i]["Date"].ToString());
                    intReq = double.Parse(ds.Tables[0].Rows[i]["Req"].ToString());
                    if (dsSch.Tables[0].Rows.Count > 0)
                    {
                       // intSch = int.Parse(dsSch.Tables[0].Rows[0][colname - 1].ToString());
                        intSch = double.Parse(dsSch.Tables[0].Rows[0][colname - 1].ToString());
                    }
                    else
                    {
                        intSch = 0.0;
                    }
                   
                    if (intSch == 0.0) // no scheduleing
                    {
                        Response.Write("<Td id='req" + i + "' style='background-color:Gray;color:black'>" + ds.Tables[0].Rows[i]["Date"].ToString() + "</td>");
                    }
                    else if (intSch == intReq) //fulfill
                    {
                        Response.Write("<Td id='req" + i + "' style='background-color:green;color:white'>" + ds.Tables[0].Rows[i]["Date"].ToString() + "</td>");
                    }
                    else if (intSch > intReq) //over
                    {
                        Response.Write("<Td id='req" + i + "' style='background-color:red;color:white'>" + ds.Tables[0].Rows[i]["Date"].ToString() + "</td>");

                    }
                    else
                    {
                        Response.Write("<Td id='req" + i + "' style='background-color:yellow;color:balck'>" + ds.Tables[0].Rows[i]["Date"].ToString() + "</td>");

                    }

                }
            }
            Response.Write("</Tr>");
            Response.Write("<Tr>");

             
           
            //for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
            //{
            //    // Response.Write("<Td width=17 ><input type='text' id='txtReq" + ds.Tables[0].Columns[i].ColumnName.ToString() + "' style='width:17px; height:15px;text-align: center' class='csstxtbox' value='" + ds.Tables[0].Columns[i].ColumnName.ToString() + "' /></Td>");
            //    int colname = 0;
            //    int intReq = 0;
            //    int intSch = 0;
            //    colname = int.Parse(ds.Tables[0].Columns[i].ColumnName.ToString());
            //    intReq = int.Parse(ds.Tables[0].Rows[0][i].ToString());
            //    if (dsSch.Tables[0].Rows.Count > 0)
            //    { intSch = int.Parse(dsSch.Tables[0].Rows[0][colname - 1].ToString()); }
            //    else
            //    { intSch = 0; }

            //    if (intSch == 0) // no scheduleing
            //    {
            //        Response.Write("<Td id='req" + i + "' style='background-color:Gray;color:black'>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
            //    }
            //    else if (intSch == intReq) //fulfill
            //    {
            //        Response.Write("<Td id='req" + i + "' style='background-color:green;color:white'>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");
            //    }
            //    else if (intSch > intReq) //over
            //    {
            //        Response.Write("<Td id='req" + i + "' style='background-color:red;color:white'>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");

            //    }
            //    else
            //    {
            //        Response.Write("<Td id='req" + i + "' style='background-color:yellow;color:balck'>" + ds.Tables[0].Columns[i].ColumnName.ToString() + "</td>");

            //    }

            //}
            //Response.Write("</Tr>");
            //Response.Write("<Tr>");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Status == 0) // no scheduleing
                {
                    Response.Write("<Td align='center' width='12px' >" + Resources.Resource.Required + "</Td>");
                    Status = 1;
                }
                else
                {
                    Status = 1;
                }

                Response.Write("<Td align='center' width='12px' >" + ds.Tables[0].Rows[i]["Req"].ToString() + "</Td>");
            }
            Response.Write("</Tr>");

            if (attendType == "Sch")
            {
                Response.Write("<Tr><Td>" + Resources.Resource.Scheduled + "</Td>");
            }
            else
            {
                Response.Write("<Tr><Td>" + Resources.Resource.Actual + "</Td>");
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int iCol = 0;
                //iCol = int.Parse(ds.Tables[0].Columns[i].ColumnName.ToString());
                iCol = int.Parse(ds.Tables[0].Rows[i]["Date"].ToString());
                if (dsSch.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<Td align='center'>" + dsSch.Tables[0].Rows[0][iCol-1].ToString() + "</Td>");
                }
                else
                {
                    Response.Write("<Td align='center'>0</Td>");

                }
            }
            Response.Write("</Tr>");
            Response.End();


        }
        else
        {
        }
    }
}
