// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="UploadingSwipeRpt.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
//using Excel = Microsoft.Office.Interop.Excel;

/// <summary>
/// Class Transactions_UploadingSwipeRpt.
/// </summary>
public partial class Transactions_UploadingSwipeRpt : BasePage
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
        if (!IsPostBack)
        {
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.UploadingSwipeRpt + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                GridBind();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

    }
    /// <summary>
    /// Grids the bind.
    /// </summary>
    private void GridBind()
    {

        BL.UploadSwipe Fillgrid = new BL.UploadSwipe();
        DataSet dsFillgrid = new DataSet();

        DataTable dtFillGrid = new DataTable();

        dsFillgrid = Fillgrid.FillGridDataFileName();
        dtFillGrid = dsFillgrid.Tables[0];

        //if (dtFillGrid.Rows.Count == 0)
        //{

        //    dtFillGrid.Rows.Add(dtFillGrid.NewRow());
        //}

        grvUploadSwipe.DataSource = dtFillGrid;
        grvUploadSwipe.DataBind();


    }

    /// <summary>
    /// Handles the Click event of the btnSaveFile control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        HttpPostedFile file = flUploadSwipe.PostedFile;


        if (file.ContentLength > 0)
        {
            if (file.ContentType.Contains("excel"))
            {
                if (flUploadSwipe.PostedFile.FileName != null)
                {
                    string filename = GetFileName(file);
                    if (filename.Length > 35)
                    {
                        filename = filename.Substring(1, 30).ToString() + ".xls";
                    }
                    else
                    {
                        filename = filename.ToString();
                    }
                    //filename = filename.Replace(".csv", ".xls");

                    //string filepath = flUploadSwipe.PostedFile.FileName;
                    string filepath = Server.MapPath("../SwipeXLS/");

                    BL.UploadSwipe upSwipeFile = new BL.UploadSwipe();
                    DataSet ds = new DataSet();


                    if (btnSaveFile.Text != Resources.Resource.ReplaceFile.ToString())
                    {
                        ds = upSwipeFile.SaveServerFileName(filename, filepath);

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            if (file.ContentType.IndexOf("excel") >= 0)
                            {

                                //file.SaveAs(Server.MapPath("../SwipeXLS/" + filename.Replace(".csv",".xls")));
                                file.SaveAs(Server.MapPath("../SwipeXLS/" + filename));
                            }
                            else
                            {
                                file.SaveAs(Server.MapPath("../SwipeXLS" + filename));

                            }
                            MsgFileStatus.Text = "File saved successfully!";
                        }
                        else
                        {
                            MsgFileStatus.Text = "File already exists!, To Replace the File please RESELECT Else RESET.";
                            btnSaveFile.Text = Resources.Resource.ReplaceFile.ToString();
                        }
                        //if (btnSaveFile.Text == Resources.Resource.ReplaceFile.ToString())
                        //{

                        //    //MsgFileStatus.Text = "File already exists!, To Replace the File please RESELECT Else RESET.";
                        //    //btnSaveFile.Text = Resources.Resource.ReplaceFile.ToString();
                        //    ds = upSwipeFile.blSaveServer_FileName(filename, filepath);
                        //    MsgFileStatus.Text = "File has been replaced successfully!";
                        //}
                    }
                    else
                    {
                        ds = upSwipeFile.ReplaceServerFileName(filename, filepath);


                        //filename = ds.;

                        if (file.ContentType.IndexOf("excel") >= 0)
                        {
                            file.SaveAs(Server.MapPath("../SwipeXLS/" + filename));
                        }
                        else
                        {
                            file.SaveAs(Server.MapPath("../SwipeXLS/" + filename));
                        }
                        MsgFileStatus.Text = "File has been replaced successfully!";

                    }
                    //IsPostBack.Equals(true);
                    GridBind();
                }
                else
                {
                    MessageBox.MessageBox msgbox = new MessageBox.MessageBox();
                    msgbox.Message.ToString();
                    flUploadSwipe.Dispose();
                    flUploadSwipe.Focus();
                }
            }
            else
            {
                MsgFileStatus.Text = "File must be in XLS format";
            }
        }
        else
        {
            MsgFileStatus.Text = "Select the File to Upload";
        }
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        flUploadSwipe.Dispose();
        flUploadSwipe.Focus();
        btnSaveFile.Text = Resources.Resource.SaveFile.ToString();
        MsgFileStatus.Text = "";
    }

    /// <summary>
    /// Gets the name of the file.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns>System.String.</returns>
    private string GetFileName(HttpPostedFile file)
    {
        int i = 0, j = 0;
        string filename;

        filename = file.FileName;
        if (filename.Length > 0)
        {
            do
            {
                i = filename.IndexOf(@"\", j + 1);
                if (i >= 0) j = i;
            } while (i >= 0);
            filename = filename.Substring(j + 1, filename.Length - j - 1);
        }

        return filename;

    }



    /// <summary>
    /// Handles the RowCommand event of the grvUploadSwipe control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void grvUploadSwipe_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            string filename;
            string filepath;
            string[] onlyfilename;
            filename = grvUploadSwipe.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            filepath = Server.MapPath("../SwipeXls/") + filename;
            onlyfilename = GetExcelSheetNames(filename);

            //  RenameExcelSheetsName(filepath);
            BL.UploadSwipe dataUploadCSV = new BL.UploadSwipe();


            DataSet dsUploadCSV = new DataSet();

            DataTable dtUploadCSV = new DataTable();

            //            dsUploadCSV = dataUploadCSV.blUploadGridData_FileName(filename,onlyfilename);
            dsUploadCSV = dataUploadCSV.UploadGridDataFileName(filename, onlyfilename[0].ToString());
            dtUploadCSV = dsUploadCSV.Tables[0];

            //if (dtUploadCSV.Rows.Count == 0)
            //{

            //    dtUploadCSV.Rows.Add(dtUploadCSV.NewRow());
            //}

            grvUploadSwipe.DataSource = dtUploadCSV;
            grvUploadSwipe.DataBind();
        }

        if (e.CommandName == "Delete")
        {


            string filename;
            string filepath;

            filename = grvUploadSwipe.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();


            filepath = Server.MapPath("../SwipeXls/") + filename;
            File.Delete(filepath);

            BL.UploadSwipe dataUploadCSV = new BL.UploadSwipe();


            DataSet dsDltFile = new DataSet();

            DataTable dtDltFile = new DataTable();

            dsDltFile = dataUploadCSV.PopDataDelete(filename);
            dtDltFile = dsDltFile.Tables[0];

            //if (dtUploadCSV.Rows.Count == 0)
            //{

            //    dtUploadCSV.Rows.Add(dtUploadCSV.NewRow());
            //}

            grvUploadSwipe.DataSource = dtDltFile;
            grvUploadSwipe.DataBind();
        }


    }
    /// <summary>
    /// Handles the Click event of the btnPOPUpload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnPOPUpload_Click(object sender, EventArgs e)
    {
        //string strFilePath = FUPOPUpload.PostedFile.FileName;
        //string strFileName = FUPOPUpload.FileName;

        HttpPostedFile file = FUPOPUpload.PostedFile;
        string filename = string.Empty;
        string strFilePath = string.Empty;
        if (file.ContentLength > 0)
        {
            if (file.ContentType.Contains("excel"))
            {
                if (flUploadSwipe.PostedFile.FileName != null)
                {
                    filename = GetFileName(file);

                    if (file.ContentType.IndexOf("excel") >= 0)
                    {

                        file.SaveAs(Server.MapPath("../SwipeXLS/" + filename));
                    }
                    else
                    {
                        file.SaveAs(Server.MapPath("../SwipeXLS" + filename));

                    }
                    MsgFileStatus.Text = "File saved successfully!";
                }
            }
            else
            {
                MsgFileStatus.Text = "File must be in XLS format";
            }
        }
        else
        {
            MsgFileStatus.Text = "Select the File to Upload";
        }

        BL.UploadSwipe objUploadSwipe = new BL.UploadSwipe();
        DataSet ds = new DataSet();
        strFilePath = Server.MapPath("../SwipeXLS/" + filename);
        filename = filename.Substring(0, filename.IndexOf(@".", 1));
        filename = filename + '$';

        ds = objUploadSwipe.PopDataUpload(filename, strFilePath);

    }

    /// <summary>
    /// Handles the RowDeleting event of the grvUploadSwipe control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void grvUploadSwipe_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridBind();
        MsgFileStatus.Text = "File Deleted Successfully!";
    }

    /// <summary>
    /// Gets the excel sheet names.
    /// </summary>
    /// <param name="excelFile">The excel file.</param>
    /// <returns>String[].</returns>
    private String[] GetExcelSheetNames(string excelFile)
    {
        OleDbConnection objConn = null;
        System.Data.DataTable dt = null;

        excelFile = Server.MapPath("../SwipeXls/") + excelFile;
        try
        {
            // Connection String. Change the excel file to the file you
            // will search.
            String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
            // Create connection object by using the preceding connection string.
            objConn = new OleDbConnection(connString);
            // Open connection with the database.
            objConn.Open();
            // Get the data table containg the schema guid.
            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }


            String[] excelSheets = new String[dt.Rows.Count];
            int i = 0;

            // Add the sheet name to the string array.
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            // Loop through all of the sheets if you want too...
            for (int j = 0; j < excelSheets.Length; j++)
            {
                // Query each excel sheet.
            }

            return (excelSheets);
        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            // Clean up.
            if (objConn != null)
            {
                objConn.Close();
                objConn.Dispose();
            }
            if (dt != null)
            {
                dt.Dispose();
            }
        }
    }





    //private void RenameExcelSheetsName(string sFileName)
    //{

    //    Excel.Application app = new Excel.ApplicationClass();
    //    Excel.Workbook excelWorkbook;
    //    Excel.Worksheet excelWorkSheet;
    //    Response.Write(sFileName);
    //    Response.End();

    //    object oMissing = System.Reflection.Missing.Value;
    //    try
    //    {
    //        //sFileName = Server.MapPath("../SwipeXls/") + sFileName;


    //        excelWorkbook = app.Workbooks.Open(sFileName, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

    //        if (excelWorkbook.Sheets.Count > 0)
    //        {


    //            //excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
    //            excelWorkSheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(1);

    //            //Rename the sheet 


    //            excelWorkSheet.Name = "Sheet1";


    //        }

    //        //Save the excel 
    //        excelWorkbook.Save();


    //        //Close the excel
    //        app.Application.Workbooks.Close();//Close(true,sFileName,false);


    //    }


    //    catch (Exception ex)
    //    {
    //        MsgFileStatus.Text = "Export Excel Failed: " + ex.Message;
    //    }


    //    //finally
    //    //{
    //    //    //Clean up objects 


    //    //    app.Quit();


    //    //    app = null;


    //    //    GC.Collect();


    //    //    GC.WaitForPendingFinalizers();


    //    //}
    //} 

}
