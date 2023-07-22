// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Search.ascx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Class UserControls_Search.
/// </summary>
public partial class UserControls_Search : System.Web.UI.UserControl
{
    /// <summary>
    /// The ds
    /// </summary>
    private static DataSet ds;
    /// <summary>
    /// The grid view
    /// </summary>
    private static GridView GridView;
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserOnLoad(EventArgs.Empty);
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlSearchBy control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
        OnButtonClicked(EventArgs.Empty);

        txtSearch.Text = GridView.Columns.Count.ToString();


    }
    /// <summary>
    /// Users the on load.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void UserOnLoad(EventArgs e)
    {

        if (UserControlOnload != null)
        {
            UserControlOnload(this, e);
            ArrayList arr = new ArrayList();
            for (int i = 0; i < GridView.Columns.Count; i++)
            {
                if (GridView.Columns[i].HeaderText == Resources.Resource.SerialNumber || GridView.Columns[i].HeaderText == Resources.Resource.EditColName)
                {
                    continue;
                }
                else
                {
                    if (GridView.Columns[i].Visible)
                    {
                        arr.Add(GridView.Columns[i]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            ddlSearchBy.DataSource = arr;
            ddlSearchBy.DataTextField = "HeaderText";
            ddlSearchBy.DataValueField = "HeaderText";
            ddlSearchBy.DataBind();
        }
    }
    /// <summary>
    /// Handles the <see cref="E:ButtonClicked" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void OnButtonClicked(EventArgs e)
    {
        if (ButtonClicked != null)
        {
            ButtonClicked(this, e);
        }
    }
    /// <summary>
    /// Occurs when [button clicked].
    /// </summary>
    public event EventHandler ButtonClicked;
    /// <summary>
    /// Occurs when [user control onload].
    /// </summary>
    public event EventHandler UserControlOnload;


    /// <summary>
    /// Handles the Click event of the btnViewAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewAll_Click(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Gets or sets the temporary data set.
    /// </summary>
    /// <value>The temporary data set.</value>
    public DataSet TempDataSet
    {

        set
        {
            ds = value;


        }

        get { return ds; }
    }
    /// <summary>
    /// Sets the temporary grid view.
    /// </summary>
    /// <value>The temporary grid view.</value>
    public GridView TempGridView
    {
        set
        {
            GridView = value;
        }
    }
}
