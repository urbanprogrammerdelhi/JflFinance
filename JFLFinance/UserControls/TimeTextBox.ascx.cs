// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="TimeTextBox.ascx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// Class UserControls_TimeTextBox.
/// </summary>
public partial class UserControls_TimeTextBox : System.Web.UI.UserControl
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
       txtTime.Attributes["OnBlur"]= "javascript:Timerf('" + lblMsg.ClientID.ToString() + "');";
    }
    /// <summary>
    /// Handles the TextChanged event of the txtTime control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtTime_TextChanged(object sender, EventArgs e)
    {
        txtTime.Text = txtTime.Text.Replace(":", "");
        int length = txtTime.Text.Trim().Length;
        int Hours = 0;
        int Min = 0;
        int flag = 0;
        if (length == 3)
        {
            Hours = int.Parse(txtTime.Text.Trim().ToString().Substring(0, 2).ToString());
            Min = int.Parse(txtTime.Text.Trim().ToString().Substring(2, 1));
            Min = int.Parse(Min.ToString() + "0");
            flag = 1;
        }
        else if (length == 2)
        {
            Hours = int.Parse(txtTime.Text.Trim().ToString().Substring(0, 2).ToString());
            string TempMin = "0";
            Min = int.Parse(TempMin + TempMin);
            flag = 1;
        }
        else if (length != 1)
        {
            Hours = int.Parse(txtTime.Text.Trim().ToString().Substring(0, 2).ToString());
            Min = int.Parse(txtTime.Text.Trim().ToString().Substring(2, 2));
            flag = 1;
        }
        if (Min > 59)
        {
            lblMsg.Text = "Minutes cannot be greater than 59";
            txtTime.Text = "";
            flag = 0;
        }
        if (Hours >= 24 || Hours < 0)
        {
            lblMsg.Text = "Hours must be between 0 and 24";
            flag = 0;
            txtTime.Text = "";
        }
        if (length != 1)
        {
            if (flag == 1)
            {
                txtTime.Text = DateTime.Parse(Hours.ToString() + ':' + Min.ToString()).ToString("HH:mm");
                lblMsg.Text = "";
            }
        }
        else
        {
            lblMsg.Text = "Time not in correct format";
            txtTime.Text = "";
        }
    }
}
