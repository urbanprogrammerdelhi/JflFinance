// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="CSVGenerator.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;

/// <summary>
/// Class Transactions_CSVGenerator.
/// </summary>
public partial class Transactions_CSVGenerator : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder str = new StringBuilder();
        str.Append(Session["str"].ToString());
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.csv");
        Response.ContentType = "application/vnd.text";        //Response.ContentEncoding = Encoding.GetEncoding(1252);
        Response.Write(str.ToString());
        Response.End();

    }
}
