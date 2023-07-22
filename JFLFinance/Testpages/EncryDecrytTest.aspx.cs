// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="EncryDecrytTest.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using DL;

/// <summary>
/// Class Testpages_EncryDecrytTest.
/// </summary>
public partial class Testpages_EncryDecrytTest : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

       
       // Response.Write("DecrypteValue" + lblDecry.Text);
       // Response.Write("Original Value Passed" + " vashishtha");

    }
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DL.Algorithm objAlgo = new Algorithm();
        txtEncryValue.Text = objAlgo.Encryption(txtKey.Text, txtEncry.Text);
        //lblDecry.Text = objAlgo.Decryption("Algorithm", lblEncry.Text);

        Response.Write("EncryptedValue" + lblEncry.Text);
    }


    /// <summary>
    /// Handles the Click event of the btnDecrypt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDecrypt_Click(object sender, EventArgs e)
    {
        DL.Algorithm objAlgo = new Algorithm();
        txtDecryValue.Text = objAlgo.Decryption(txtKey.Text, txtDecry.Text);
    }
}
