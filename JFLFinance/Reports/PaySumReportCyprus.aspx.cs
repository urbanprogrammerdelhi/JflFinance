// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 01-20-2014
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="PaySumReportCyprus.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using BL;
using Resources;

/// <summary>
/// The Reports namespace.
/// </summary>
namespace Reports
{
    /// <summary>
    /// Class Reports_PaySumReportCyprus.
    /// </summary>
    public partial class Reports_PaySumReportCyprus : BasePage
    {
        #region Properties
        /// <summary>
        /// To check the Read Access
        /// </summary>
        /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
        /// <exception cref="System.Exception">Have not Rights</exception>
        private bool IsReadAccess
        {
            get
            {
                try
                {
                    int virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, StringComparison.Ordinal).ToString());
                    return
                        IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0,
                            virtualDirNameLenght));
                }
                catch (Exception ex)
                {
                    throw new Exception("Have not Rights", ex);
                }
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
                if (IsReadAccess)
                {
                    txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                    DateTime startDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime dtEndDate = startDate.AddMonths(1).AddDays(-1);
                    string strLastDate = Convert.ToString(DateTime.DaysInMonth(dtEndDate.Year, dtEndDate.Month)) + "-" +
                                  dtEndDate.ToString("") + "-" + Convert.ToString(dtEndDate.Year);
                    txtToDate.Text = strLastDate;
                    FillData();
                }
            }
        }


        /// <summary>
        /// Handles the Click event of the btnViewReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Code on the button click event of the Button
        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            var objBusinessRule = new BusinessRule();
            if (ddlBusinessRuleCode.SelectedItem == null)
            {
                DisplayMessageString(lblErrorMsg, Resource.BusinessRuleSelection);
                
            }
            else
            {
                CreateTxtOutput(objBusinessRule.PayrollText(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text),
                    ddlBusinessRuleCode.SelectedItem.Value));
            }
        }

        /// <summary>
        /// Generate text file output of paysum
        /// </summary>
        /// <param name="dataTablePaysum">The data table paysum.</param>
        private void CreateTxtOutput(DataTable dataTablePaysum)
        {
            var maxLengths = new int[dataTablePaysum.Columns.Count];
            int[] maxPaddingLengths = { 1, 2, 8, 62, 69, 13, 5, 67, 3};
            for (var i = 0; i < dataTablePaysum.Columns.Count; i++)
            {
                maxLengths[i] = dataTablePaysum.Columns[i].ColumnName.Length;
                foreach (DataRow row in dataTablePaysum.Rows)
                {
                    if (!row.IsNull(i))
                    {
                        int length = row[i].ToString().Length;
                        if (length > maxLengths[i])
                        {
                            maxLengths[i] = length;
                        }
                    }
                }
            }
            if (dataTablePaysum.Rows.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (DataRow row in dataTablePaysum.Rows)
                {
                    for (int i = 0; i < dataTablePaysum.Columns.Count; i++)
                    {
                        sb.Append(row[i].ToString().PadRight(maxLengths[i] + maxPaddingLengths[i]));
                    }
                    sb.AppendLine();
                }
                string text = sb.ToString();
                Response.Clear();
                Response.ClearHeaders();

                Response.AddHeader("Content-Length", text.Length.ToString());
                Response.ContentType = "text/plain";
                Response.AppendHeader("content-disposition", "attachment;filename=\"" + ddlBusinessRuleCode.SelectedItem.Text + ".txt\"");

                Response.Write(text);
                Response.End();
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resource.NoDataToShow);
            }
        }

        /// <summary>
        /// Filling the Textboxes and Dropdown on the page on pageload.
        /// </summary>
        protected void FillData()
        {
            var objR = new BusinessRule();
            //var fromDate = Convert.ToDateTime(txtFromDate.Text);
            //var toDate = Convert.ToDateTime(txtToDate.Text);
            var ds = objR.BusinessRuleGet("", int.Parse(BaseLocationAutoID));
            ddlBusinessRuleCode.DataSource = ds.Tables[0];
            ddlBusinessRuleCode.DataValueField = "BusinessRuleCode";
            ddlBusinessRuleCode.DataTextField = "BusinessRuleDesc";
            ddlBusinessRuleCode.DataBind();
        }

        /// <summary>
        /// Gets the report parameters.
        /// </summary>
        /// <value>The report parameters.</value>
        public Hashtable ReportParameters
        {
            get
            {
                if (Session["cxtHashParameters"] != null)
                {
                    return (Hashtable) Session["cxtHashParameters"];
                }
                    return null;
                }
            }

        /// <summary>
        /// dynimacally changing Todate on basis of fromDate
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            var startDate = Convert.ToDateTime(txtFromDate.Text);
            var dtEndDate = startDate.AddMonths(1).AddDays(-1);
            string strLastDate = Convert.ToString(DateTime.DaysInMonth(dtEndDate.Year, dtEndDate.Month)) + "-" +
                          dtEndDate.ToString("") + "-" + Convert.ToString(dtEndDate.Year);
            txtToDate.Text = strLastDate;
        }
    }
}