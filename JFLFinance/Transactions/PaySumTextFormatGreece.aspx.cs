// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="PaySumTextFormatGreece.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Text;
using System.Data;

/// <summary>
/// Class Transactions_PaySumTextFormatGreece.
/// </summary>
public partial class Transactions_PaySumTextFormatGreece : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {


        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        string strFromDate = Request.QueryString["FromDate"];
        string strToDate = Request.QueryString["ToDate"];
        ds = objRoster.GeneratePaysumGreece(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strFromDate, strToDate, BaseUserID, "0");
        StringBuilder str = new StringBuilder();
        string strReplaceDecimal = "";
        for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
        {
            if (k == 1)
            {
                str.Append(ds.Tables[0].Columns[k].ColumnName.ToString());
            }

            if (k == 0)
            {
                str.Append(ds.Tables[0].Columns[k].ColumnName.ToString());
                for (int j = ds.Tables[0].Columns[k].ToString().Trim().Length; j < 25; j++)
                {
                    str.Append(" ");
                }
            }
            else
            {
                if (k == 1 || k == 2)
                {

                    if (k == 1)
                    {
                        int ColumnLen = ds.Tables[0].Columns[k + 1].ToString().Trim().Length;
                        for (int j = ColumnLen; j < 16; j++)
                        {
                            str.Append(" ");
                        }
                        str.Append(ds.Tables[0].Columns[k + 1].ColumnName.ToString());
                    }
                }
                else if (k == 17 || k == 18)
                {
                    int ColumnLen = ds.Tables[0].Columns[k].ToString().Trim().Length;
                    for (int j = ColumnLen; j < 18; j++)
                    {
                        str.Append(" ");
                    }
                    str.Append(ds.Tables[0].Columns[k].ColumnName.ToString());
                }
                else if (k == 19 || k == 22 || k == 23)
                {
                    int ColumnLen = ds.Tables[0].Columns[k].ToString().Trim().Length;
                    for (int j = ColumnLen; j < 5; j++)
                    {
                        str.Append(" ");
                    }
                    str.Append(ds.Tables[0].Columns[k].ColumnName.ToString());
                }
                else if (k == 21)
                {
                    int ColumnLen = ds.Tables[0].Columns[k].ToString().Trim().Length;
                    for (int j = ColumnLen; j < 12; j++)
                    {
                        str.Append(" ");
                    }
                    str.Append(ds.Tables[0].Columns[k].ColumnName.ToString());
                }
                else
                {
                    for (int j = ds.Tables[0].Columns[k].ToString().Trim().Length; j < 7; j++)
                    {
                        str.Append(" ");
                    }
                    str.Append(ds.Tables[0].Columns[k].ColumnName.ToString());
                }
            }


        }
        str.AppendLine();
        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            for (int z = 0; z < ds.Tables[0].Columns.Count; z++)
            {
                strReplaceDecimal = "";

                if (z == 1)
                {
                    //str.Append(ds.Tables[0].Rows[i][z].ToString());
                    if (ds.Tables[0].Rows[i][z].ToString().Contains('.'))
                    {
                        strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString().Replace('.', ',');
                    }
                    else
                    {
                        strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString();
                    }
                    str.Append(strReplaceDecimal);
                }
                if (z == 0)
                {
                    str.Append(ds.Tables[0].Rows[i][z].ToString());
                    for (int k = ds.Tables[0].Rows[i][0].ToString().Trim().Length; k < 25; k++)
                    {
                        str.Append(" ");
                    }

                }
                else
                {
                    if (z == 1 || z == 2)
                    {

                        if (z == 1)
                        {
                            int ColumnLen = ds.Tables[0].Rows[i][z + 1].ToString().Length; //+ ds.Tables[0].Rows[i][z].ToString().Length;
                            for (int k = ColumnLen; k < 16; k++)
                            {
                                str.Append(" ");
                            }
                            if (ds.Tables[0].Rows[i][z + 1].ToString().Contains('.'))
                            {
                                strReplaceDecimal = ds.Tables[0].Rows[i][z + 1].ToString().Replace('.', ',');
                            }
                            else
                            {
                                strReplaceDecimal = ds.Tables[0].Rows[i][z + 1].ToString();
                            }
                            //  str.Append(ds.Tables[0].Rows[i][z + 1].ToString());
                            str.Append(strReplaceDecimal);
                        }

                    }
                    else if (z == 17 || z == 18)
                    {
                        int ColumnLen = ds.Tables[0].Rows[i][z].ToString().Length;
                        for (int j = ColumnLen; j < 18; j++)
                        {
                            str.Append(" ");
                        }
                        // str.Append(ds.Tables[0].Rows[i][z].ToString());
                        if (ds.Tables[0].Rows[i][z].ToString().Contains('.'))
                        {
                            strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString().Replace('.', ',');
                        }
                        else
                        {
                            strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString();
                        }
                        str.Append(strReplaceDecimal);
                    }
                    else if (z == 19 || z == 22 || z == 23)
                    {
                        int ColumnLen = ds.Tables[0].Rows[i][z].ToString().Length;
                        for (int j = ColumnLen; j < 5; j++)
                        {
                            str.Append(" ");
                        }
                        // str.Append(ds.Tables[0].Rows[i][z].ToString());
                        if (ds.Tables[0].Rows[i][z].ToString().Contains('.'))
                        {
                            strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString().Replace('.', ',');
                        }
                        else
                        {
                            strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString();
                        }
                        str.Append(strReplaceDecimal);
                    }
                    else if (z == 21)
                    {
                        int ColumnLen = ds.Tables[0].Rows[i][z].ToString().Length;
                        for (int j = ColumnLen; j < 12; j++)
                        {
                            str.Append(" ");
                        }
                        // str.Append(ds.Tables[0].Rows[i][z].ToString());
                        if (ds.Tables[0].Rows[i][z].ToString().Contains('.'))
                        {
                            strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString().Replace('.', ',');
                        }
                        else
                        {
                            strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString();
                        }
                        str.Append(strReplaceDecimal);
                    }
                    else
                    {
                        for (int k = ds.Tables[0].Rows[i][z].ToString().Trim().Length; k < 7; k++)
                        {
                            str.Append(" ");
                        }
                        // str.Append(ds.Tables[0].Rows[i][z].ToString());
                        if (ds.Tables[0].Rows[i][z].ToString().Contains('.'))
                        {
                            strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString().Replace('.', ',');
                        }
                        else
                        {
                            strReplaceDecimal = ds.Tables[0].Rows[i][z].ToString();
                        }
                        str.Append(strReplaceDecimal);
                    }
                }

            }
            str.AppendLine();
        }


        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.txt");
        Response.ContentType = "application/vnd.text";
        Response.ContentEncoding = Encoding.GetEncoding(1252);
        Response.Write(str.ToString());
        Response.End();
    }
}
