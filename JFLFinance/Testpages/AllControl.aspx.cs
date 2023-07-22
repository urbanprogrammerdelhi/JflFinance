// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="AllControl.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Class Testpages_AllControl.
/// </summary>
public partial class Testpages_AllControl : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        getAllRecords();
    }

    # region All Page Control add to Array List 
    
    
    /// <summary>
    /// Lists the control collections.
    /// </summary>
    /// <returns>ArrayList.</returns>
    private ArrayList ListControlCollections()
    {
        ArrayList controlList = new ArrayList();
        AddControls(Page.Controls, controlList);
        return controlList;
    }
    /// <summary>
    /// Adds the controls.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <param name="controlList">The control list.</param>
   private void AddControls(ControlCollection page, ArrayList controlList)
    {
        foreach (Control c in page)
        {
            if (c.ID != null)
            {
                controlList.Add(c.ID);
            }

            if (c.HasControls())
            {
                AddControls(c.Controls, controlList);
            }
        }
    }
    # endregion 

   /// <summary>
   /// Gets all records.
   /// </summary>
    private void getAllRecords()

    {
        
        string strConnectionString = @"IsraelLiveCon";
        DL.ConnectionString con = new DL.ConnectionString();
        string connect = con.ConnectionStringGet(strConnectionString);
         using (SqlConnection scn = new SqlConnection(connect))
         {
             
             SqlCommand command = new SqlCommand("udp_GetAllRecordsOnScreenName", scn);
             command.CommandType = CommandType.StoredProcedure;
             command.Parameters.Add("@screenName", SqlDbType.NVarChar).Value = "Employee Master";
            // command.Parameters.Add("@ToDate", SqlDbType.NVarChar).Value = DL.Common.DateFormat(DateTime.Parse(strToDate));
             scn.Open();

             SqlDataAdapter adapter = new SqlDataAdapter(command);
             DataSet ds = new DataSet();
             adapter.Fill(ds);
             
              ArrayList controlList=ListControlCollections();
              //  on 22-05-2012
              // Compare each row  value with Control list value 
              // We asuming value SColoumnName is same as control name with out prefix.Prefix is only 3 character like txt,ddl,lbl etc
              // Example Control name txtLastName on screen and vlaue in data base stored is lastname.Then we are comparing txtLastName.Substring(3) with database value lastname  
             int counter = 0;
              while (counter < ds.Tables[0].Rows.Count)
              {
                  for (int i = 0; i < controlList.Count; i++)
                  {
                      // Checking two condition 
                     // verify  control name is exist in dtabase  and value is editable or  not 
                      if ((ds.Tables[0].Rows[counter][0].ToString() == controlList[i].ToString().Substring(3)) && (Convert.ToBoolean(ds.Tables[0].Rows[counter][1])==false))
                      {
                         //Find the control and set the property 
                          Control c = FindControl(controlList[i].ToString());
                          string  col= ds.Tables[0].Rows[counter][2].ToString();

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
                              ddl.BackColor = System.Drawing.Color.Gray;
                              ddl.Enabled = false;
                          }


                      }                  
                  
                  }
                  counter++;
                
                

              } 

         }

     
 
    }
}