// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="GenerateConnectionStrings.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;
using DL;
using BL;
using System.Data.SqlClient;

namespace EncryptDecrypt
{
    /// <summary>
    /// Class UserManagement_GenerateConnectionStrings
    /// </summary>
    public partial class GenerateConnectionStrings : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReadXmt();
                FillgvConn();

            }
          }

        #region GridView Binding

        /// <summary>
        /// Reads the XMT.
        /// </summary>
        /// <param name="strFileName">Name of the STR file.</param>
        protected void ReadXmt(string strFileName = @"")
        {
            string filename = strFileName.Length == 0 ? Server.MapPath(@"..\App_Data\magnon.xmt") : strFileName;
            //Get a StreamReader class that can be used to read the file
            var objAlgo = new Algorithm();
            var dt = new DataTable();
            var ds = new DataSet();

            if (File.Exists(filename))
            {
                StreamReader objStreamReader = File.OpenText(filename);

                //Now, read the entire file into a string
                String contents = objStreamReader.ReadToEnd();
                objStreamReader.Close();

                String connectionStrings = objAlgo.Decryption("magnon", contents);

                ds.ReadXml(XmlReader.Create(new StringReader(connectionStrings)));
                dt = ds.Tables[0];
            }
            Session["DataTableConn"] = dt;
        }

        /// <summary>
        /// Creates the blank data table.
        /// </summary>
        /// <returns>DataTable.</returns>
        protected DataTable CreateBlankDataTable()
        {
            var dt = new DataTable();
            var dc = new DataColumn("Country");
            dt.Columns.Add(dc);
            dc = new DataColumn("Key");
            dt.Columns.Add(dc);
            dc = new DataColumn("Server");
            dt.Columns.Add(dc);
            dc = new DataColumn("DataBase");
            dt.Columns.Add(dc);
            dc = new DataColumn("Uid");
            dt.Columns.Add(dc);
            dc = new DataColumn("PWD");
            dt.Columns.Add(dc);
            dc = new DataColumn("EncriptKey");
            dt.Columns.Add(dc);
            dc = new DataColumn("SSRSDomain");
            dt.Columns.Add(dc);
            dc = new DataColumn("SSRSUserName");
            dt.Columns.Add(dc);
            dc = new DataColumn("SSRSPWD");
            dt.Columns.Add(dc);
            Session["DataTableConn"] = dt;
            dt.TableName = "Item";
            return dt;
        }

        /// <summary>
        /// Fillgvs the conn.
        /// </summary>
        protected void FillgvConn()
        {
            var dt = new DataTable();
            int dtflag = 1;
            if (Session["DataTableConn"] != null)
            {
                dt = (DataTable) Session["DataTableConn"];
                //DataColumn dc;
                //if (dt.Columns["SSRSDomain"] == null)
                //{
                //    dc = new DataColumn("SSRSDomain");
                //    dt.Columns.Add(dc);
                //}
                //if (dt.Columns["SSRSUserName"] == null)
                //{
                //    dc = new DataColumn("SSRSUserName");
                //    dt.Columns.Add(dc);
                //}
                //if (dt.Columns["SSRSPWD"] == null)
                //{
                //    dc = new DataColumn("SSRSPWD");
                //    dt.Columns.Add(dc);
                //}


            }
            //to fix empety gridview
            if (dt.Rows.Count == 0)
            {
                if (dt.Columns.Count == 0)
                {
                    dt = CreateBlankDataTable();
                }
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
            }

            //gvConn.DataKeyNames = new string[] { "Key" };
            gvConn.DataSource = dt;
            gvConn.DataBind();

            if (dtflag == 0) //to fix empety gridview
            {
                gvConn.Rows[0].Visible = false;
            }

        }

        /// <summary>
        /// Generates the XMT.
        /// </summary>
        /// <param name="saveForSameSite">if set to <c>true</c> [save for same site].</param>
        protected void GenerateXmt(bool saveForSameSite)
        {
            var objAlgo = new Algorithm();
            if (Session["DataTableConn"] != null)
            {
                var dt = (DataTable)Session["DataTableConn"];
                if (dt != null)
                {
                    String filename = Server.MapPath(@"..\App_Data\magnon.xmt");

                    var sw = new StringWriter();
                    dt.WriteXml(sw, true);
                    String connectionStrings = objAlgo.Encryption("magnon", sw.ToString());

                    txtOutput.Text = connectionStrings;
                    if (saveForSameSite)
                    {
                        File.WriteAllText(filename, connectionStrings);

                        lblErrorMsg.Text = @"Connection Information Successfully Generated and Saved";
                    }
                    else
                    {
                        lblErrorMsg.Text = @"Connection Information Successfully Generated";
                    }
                }
                else
                {
                    lblErrorMsg.Text = @"Lost dataset";
                }
            }
            else
            {
                lblErrorMsg.Text = @"session expired";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GenerateXmt(false);
        }

        protected void btnPwd_Click(object sender, EventArgs e)
        {
            var objAlgo = new Algorithm();
            var objUm = new BL.UserManagement();
            var txtUid = (TextBox)gvConn.FooterRow.FindControl("txtUid");
            var txtPWD = (TextBox)gvConn.FooterRow.FindControl("txtPWD");
            if (txtUid.Text == objUm.SuperAdminIdGet())
            {
                String connectionStrings = objAlgo.Encryption("malik.corforce@gmail.com", txtPWD.Text);
                txtOutputpwd.Text = connectionStrings;
            }
            else
            {
                txtOutputpwd.Text = "";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            GenerateXmt(true);
        }

        #endregion

        #region GridView Commands Events

        /// <summary>
        /// Generates the connection string.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="dataBaseName">Name of the data base.</param>
        /// <param name="uid">The uid.</param>
        /// <param name="pwd">The PWD.</param>
        /// <returns>System.String.</returns>
        protected string GenerateConnectionString(string serverName, string dataBaseName, string uid, string pwd)
        {
            string strConnectionString = @"Server=" + serverName + @";";
            strConnectionString = strConnectionString + @"DataBase=" + dataBaseName + @";";
            strConnectionString = strConnectionString + @"Uid=" + uid + @";";
            strConnectionString = strConnectionString + @"PWD=" + pwd + @";";
            strConnectionString = strConnectionString + @"Max Pool size=600";
            return strConnectionString;
        }

        /// <summary>
        /// Verifies the connection string.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        protected void VerifyConnectionString(string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); // throws if invalid
                    lblErrorMsg.Text = @"Valid Connection";
                }
                catch (Exception)
                {
                    lblErrorMsg.Text = @"Invalid Connection";
                }

            }
        }

        /// <summary>
        /// Handles the RowDataBound event of the gvConn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void gvConn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var lblSerialNo = (Label) e.Row.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvConn.PageIndex*gvConn.PageSize +
                               int.Parse(e.Row.RowIndex.ToString(CultureInfo.InvariantCulture));
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                var txtKey = (TextBox) e.Row.FindControl("txtKey");
                if (txtKey != null)
                {
                    txtKey.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," +
                                                   Resources.Resource.ValidationExpressionCode + ");";
                    txtKey.Attributes["onblur"] = "javascript:validateStringWithExpression(this," +
                                                  Resources.Resource.ValidationExpressionCode + ");";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                var txtKey = (TextBox) e.Row.FindControl("txtKey");
                if (txtKey != null)
                {
                    txtKey.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," +
                                                   Resources.Resource.ValidationExpressionCode + ");";
                    txtKey.Attributes["onblur"] = "javascript:validateStringWithExpression(this," +
                                                  Resources.Resource.ValidationExpressionCode + ");";
                }
            }
        }

        /// <summary>
        /// Handles the RowCommand event of the gvConn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvConn_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                var txtKey = (TextBox) gvConn.FooterRow.FindControl("txtKey");
                var txtCountry = (TextBox) gvConn.FooterRow.FindControl("txtCountry");
                var txtServer = (TextBox) gvConn.FooterRow.FindControl("txtServer");
                var txtDataBase = (TextBox) gvConn.FooterRow.FindControl("txtDataBase");
                var txtUid = (TextBox) gvConn.FooterRow.FindControl("txtUid");
                var txtPWD = (TextBox) gvConn.FooterRow.FindControl("txtPWD");
                var txtEncriptKey = (TextBox) gvConn.FooterRow.FindControl("txtEncriptKey");
                var txtSSRSDomain = (TextBox) gvConn.FooterRow.FindControl("txtSSRSDomain");
                var txtSSRSUserName = (TextBox) gvConn.FooterRow.FindControl("txtSSRSUserName");
                var txtSSRSPWD = (TextBox) gvConn.FooterRow.FindControl("txtSSRSPWD");
                if (Session["DataTableConn"] != null)
                {
                    var dt = (DataTable) Session["DataTableConn"];
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Key"].ToString() == "")
                    {
                        dt.Rows[0].Delete();
                    }
                    int intflag = 0;
                    foreach (DataRow drloop in dt.Rows)
                    {
                        if (drloop["Key"].ToString() == txtKey.Text)
                        {
                            intflag = 1;
                        }
                    }
                    if (intflag == 0)
                    {
                        //DataRow dr = new DataRow();
                        DataRow dr = dt.NewRow();
                        dr["Key"] = txtKey.Text;
                        dr["Country"] = txtCountry.Text;
                        dr["Server"] = txtServer.Text;
                        dr["DataBase"] = txtDataBase.Text;
                        dr["Uid"] = txtUid.Text;
                        dr["PWD"] = txtPWD.Text;
                        dr["EncriptKey"] = txtEncriptKey.Text;
                        dr["SSRSDomain"] = txtSSRSDomain.Text;
                        dr["SSRSUserName"] = txtSSRSUserName.Text;
                        dr["SSRSPWD"] = txtSSRSPWD.Text;
                        dt.Rows.Add(dr);
                        Session["DataTableConn"] = dt;
                    }
                }

                gvConn.EditIndex = -1;
                FillgvConn();
            }
            if (e.CommandName == "Reset")
            {
                var txtKey = (TextBox) gvConn.FooterRow.FindControl("txtKey");
                var txtCountry = (TextBox) gvConn.FooterRow.FindControl("txtCountry");
                var txtServer = (TextBox) gvConn.FooterRow.FindControl("txtServer");
                var txtDataBase = (TextBox) gvConn.FooterRow.FindControl("txtDataBase");
                var txtUid = (TextBox) gvConn.FooterRow.FindControl("txtUid");
                var txtPWD = (TextBox) gvConn.FooterRow.FindControl("txtPWD");
                var txtEncriptKey = (TextBox) gvConn.FooterRow.FindControl("txtEncriptKey");
                var txtSSRSDomain = (TextBox) gvConn.FooterRow.FindControl("txtSSRSDomain");
                var txtSSRSUserName = (TextBox) gvConn.FooterRow.FindControl("txtSSRSUserName");
                var txtSSRSPWD = (TextBox) gvConn.FooterRow.FindControl("txtSSRSPWD");
                txtCountry.Text = "";
                txtKey.Text = "";
                txtServer.Text = "";
                txtDataBase.Text = "";
                txtUid.Text = "";
                txtPWD.Text = "";
                txtEncriptKey.Text = "";
                txtSSRSDomain.Text = "";
                txtSSRSPWD.Text = "";
                txtSSRSUserName.Text = "";
            }
            if (e.CommandName == "Verify")
            {
                //int rowIndex = int.Parse(e.CommandArgument.ToString());

                ////var lblgvhdrCountry = (Label)gvConn.Rows[rowIndex].FindControl("lblgvhdrCountry");
                ////var lblgvKey = (Label)gvConn.Rows[rowIndex].FindControl("lblgvKey");
                //var lblgvServer = (Label)gvConn.Rows[rowIndex].FindControl("lblgvServer");
                //var lblgvDataBase = (Label)gvConn.Rows[rowIndex].FindControl("lblgvDataBase");
                //var lblgvUid = (Label)gvConn.Rows[rowIndex].FindControl("lblgvUid");
                //var lblgvPWD = (Label)gvConn.Rows[rowIndex].FindControl("lblgvPWD");
                ////var lblgvEncriptKey = (Label)gvConn.Rows[rowIndex].FindControl("lblgvEncriptKey");

                var row = (GridViewRow) (((ImageButton) e.CommandSource).NamingContainer);
                var lblgvServer = (Label) row.FindControl("lblgvServer");
                var lblgvDataBase = (Label) row.FindControl("lblgvDataBase");
                var lblgvUid = (Label) row.FindControl("lblgvUid");
                var HiddenFieldPWD = (HiddenField) row.FindControl("HiddenFieldPWD");

                if (lblgvServer != null && lblgvDataBase != null && lblgvUid != null && HiddenFieldPWD != null)
                {
                    VerifyConnectionString(GenerateConnectionString(lblgvServer.Text, lblgvDataBase.Text, lblgvUid.Text,
                        HiddenFieldPWD.Value));
                }
            }
        }

        protected void gvConn_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvConn.EditIndex = e.NewEditIndex;
            FillgvConn();
        }

        protected void gvConn_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvConn.EditIndex = -1;
            FillgvConn();
        }

        protected void gvConn_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var txtKey = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtKey");
            var txtCountry = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtCountry");
            var txtServer = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtServer");
            var txtDataBase = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtDataBase");
            var txtUid = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtUid");
            var txtPWD = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtPWD");
            var txtEncriptKey = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtEncriptKey");
            var txtSSRSDomain = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtSSRSDomain");
            var txtSSRSUserName = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtSSRSUserName");
            var txtSSRSPWD = (TextBox) gvConn.Rows[e.RowIndex].FindControl("txtSSRSPWD");

            if (Session["DataTableConn"] != null)
            {
                var dt = (DataTable) Session["DataTableConn"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Key"].ToString() == txtKey.Text)
                    {
                        dr["Key"] = txtKey.Text;
                        dr["Country"] = txtCountry.Text;
                        dr["Server"] = txtServer.Text;
                        dr["DataBase"] = txtDataBase.Text;
                        dr["Uid"] = txtUid.Text;
                        dr["PWD"] = txtPWD.Text;
                        dr["EncriptKey"] = txtEncriptKey.Text;
                        dr["SSRSDomain"] = txtSSRSDomain.Text;
                        dr["SSRSUserName"] = txtSSRSUserName.Text;
                        dr["SSRSPWD"] = txtSSRSPWD.Text;
                    }
                }
                Session["DataTableConn"] = dt;
            }
            gvConn.EditIndex = -1;
            FillgvConn();
        }

        protected void gvConn_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var lblgvKey = (Label) gvConn.Rows[e.RowIndex].FindControl("lblgvKey");
            if (Session["DataTableConn"] != null)
            {
                var dt = (DataTable) Session["DataTableConn"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Key"].ToString() == lblgvKey.Text)
                    {
                        dt.Rows[i].Delete();
                        break;
                    }
                }
            }
            FillgvConn();
        }

        protected void gvConn_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvConn.PageIndex = e.NewPageIndex;
            gvConn.EditIndex = -1;
            FillgvConn();
        }

        #endregion

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "text/plain")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);

                            string targetPath = Server.MapPath("~/App_Data/Temp/");
                            if (!Directory.Exists(targetPath))
                            {
                                Directory.CreateDirectory(targetPath);
                            }

                            FileUploadControl.SaveAs(Server.MapPath("~/App_Data/Temp/" + filename));
                            string fileName = Server.MapPath("~/App_Data/Temp/" + filename);
                            ReadXmt(fileName);
                            FillgvConn();
                            lblErrorMsg.Text = @"Upload status: File uploaded!";
                        }
                        else
                            lblErrorMsg.Text = @"Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        lblErrorMsg.Text = @"Upload status: Only xmt files are accepted!";
                }
                catch (Exception ex)
                {
                    lblErrorMsg.Text = @"Upload status: The file could not be uploaded. The following error occured: " +
                                       ex.Message;
                }
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }
    }
}