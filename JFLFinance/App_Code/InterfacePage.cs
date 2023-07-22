// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-14-2014
// ***********************************************************************
// <copyright file="InterfacePage.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for InterfacePage
/// </summary>
public class InterfacePage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InterfacePage"/> class.
    /// </summary>
	public InterfacePage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //Find The control is avilable on page or not. 
    /// <summary>
    /// Finds the controls.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <param name="controlId">The control id.</param>
    /// <returns>Control.</returns>
    public Control FindControls(ControlCollection page, string controlId)
    {
        Control InvalidIPX = null;

        foreach (Control c in page)
        {
            if (c.ID != null && c.ID.ToString().ToLower() == controlId.ToLower())
            {
                InvalidIPX = c;
            }
            else if (c.HasControls())
            {
                InvalidIPX = FindControls(c.Controls, controlId);
            }

            if (InvalidIPX != null)
            {
                break;
            }
        }

        return InvalidIPX;
    }
     // Compare each row  value with Control 
    //We are assuming value is editable from  two Type of control text box and dropdown list. 
    // We asuming value SColoumnName is same as control name with out prefix.Prefix is only 3 character like txt,ddl,lbl etc
    // Example Control name txtLastName on screen and vlaue in data base stored is lastname.Then we are concatenate txt/ddl with data base coloum  
    /// <summary>
    /// Controlses the non editable.
    /// </summary>
    /// <param name="ds">The ds.</param>
    /// <param name="page">The page.</param>
    public void ControlsNonEditable( DataSet ds,Page page )

    { 
     string[] control = new string[] { "txt", "ddl" };
     int counter = 0;
        string str = string.Empty;
        while (counter < ds.Tables[0].Rows.Count)
        {
            if (Convert.ToBoolean(ds.Tables[0].Rows[counter][1]) == false)
            {
                for (int i = 0; i < control.Length; i++)
                {
                    // Checking two condition 
                    // verify  control name is exist in dtabase  and value is editable or  non editable in database 

                    str = control.GetValue(i) + ds.Tables[0].Rows[counter][0].ToString();

                    //Find the control and set the property    

                    Control c = FindControls(page.Controls, str);

                    string col = ds.Tables[0].Rows[counter][2].ToString();

                    if (String.IsNullOrEmpty(col))
                        col = ConfigurationManager.AppSettings["DefaultColor"];

                    if (c is TextBox)
                    {
                        TextBox TXT = (TextBox)c;
                        //TXT.ForeColor = System.Drawing.Color.Red;
                        TXT.BackColor = System.Drawing.Color.FromName(col);
                        TXT.Enabled = false;

                    }

                    if (c is DropDownList)
                    {
                        DropDownList ddl = (DropDownList)c;
                        // ddl.ForeColor = System.Drawing.Color.Red;
                        ddl.BackColor = System.Drawing.Color.FromName(col);
                        ddl.Enabled = false;
                    }




                }
            }//Edit IF
            counter++;
        }

    
    }
    //Same control make Editable when we adding new record 
    /// <summary>
    /// Controlses the editable.
    /// </summary>
    /// <param name="ds">The ds.</param>
    /// <param name="page">The page.</param>
    public void ControlsEditable(DataSet ds, Page page)
    {
        string[] control = new string[] { "txt", "ddl" };
        int counter = 0;
        string str = string.Empty;
        while (counter < ds.Tables[0].Rows.Count)
        {
            //for (int i = 0; i < controlList.Count; i++)

            if (Convert.ToBoolean(ds.Tables[0].Rows[counter][1]) == false)
            {
                for (int i = 0; i < control.Length; i++)
                {
                    // Checking two condition 
                    // verify  control name is exist in dtabase  and value is editable or  not 

                    str = control.GetValue(i) + ds.Tables[0].Rows[counter][0].ToString();
                    Control c = FindControls(page.Controls, str);
                        if (c is TextBox)
                        {
                            TextBox TXT = (TextBox)c;
                            //TXT.ForeColor = System.Drawing.Color.Red;
                            TXT.BackColor = System.Drawing.Color.White;
                            TXT.Enabled = true;
                            TXT.CssClass = "csstxtbox";
                            //TXT.Style("") = "";

                        }

                        if (c is DropDownList)
                        {
                            DropDownList ddl = (DropDownList)c;
                            // ddl.ForeColor = System.Drawing.Color.Red;
                            ddl.BackColor = System.Drawing.Color.White;
                            ddl.Enabled = true;
                        }


                    

                }
            }//Edit IF
            counter++;



        }

    
    
    }
    //private ArrayList ListControlCollections()
    //{
    //    ArrayList controlList = new ArrayList();
    //    AddControls(Page.Controls, controlList);
    //    return controlList;
    //}
    //private void AddControls(ControlCollection page, ArrayList controlList)
    //{
    //    foreach (Control c in page)
    //    {
    //        if (c.ID != null)
    //        {
    //            controlList.Add(c.ID);
    //        }

    //        if (c.HasControls())
    //        {
    //            AddControls(c.Controls, controlList);
    //        }
    //    }
    //}

}