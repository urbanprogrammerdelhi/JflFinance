// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CreateCCH.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Search_CreateCCH.
/// </summary>
public partial class Search_CreateCCH : BasePage//System.Web.UI.Page
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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


    }
    /// <summary>
    /// Handles the Click event of the btnGetObject control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGetObject_Click(object sender, EventArgs e)
    {
        BL.Search objSearch = new BL.Search();
        DataSet dsFlds = new DataSet();
        dsFlds = objSearch.ColumnNamesOfTableGet(txtObjectName.Text);

        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("fldName", typeof(string)));
        dt.Columns.Add(new DataColumn("fldDataType", typeof(string)));
        for (int i = 0; i < dsFlds.Tables[0].Columns.Count; i++)
        {
            DataRow myDataRow = dt.NewRow();
            myDataRow["fldName"] = dsFlds.Tables[0].Columns[i].Caption.ToString();
            myDataRow["fldDataType"] = dsFlds.Tables[0].Columns[i].DataType.ToString();
            dt.Rows.Add(myDataRow);

        }
        gvCCH.DataSource = dt;
        gvCCH.DataBind();
        btnApply.Visible = true;
    }

    /// <summary>
    /// Handles the Click event of the btnApply control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnApply_Click(object sender, EventArgs e)
    {

        BL.Search objSearch = new BL.Search();
        DataSet dsCCH = new DataSet();

        string strCCHCode = txtSearchCode.Text;
        string strObjectName = txtObjectName.Text;
        string strReturnFld = txtReturnFld.Value;
        string strReturnFld2 = txtReturnFld2.Value;


        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FldName", typeof(string)));
        dt.Columns.Add(new DataColumn("InputFld", typeof(string)));
        dt.Columns.Add(new DataColumn("OutputFld", typeof(string)));
        dt.Columns.Add(new DataColumn("FldDataType", typeof(string)));

        for (int i = 0; i < gvCCH.Rows.Count; i++)
        {
            Label lblgvCCHFldName = (Label)gvCCH.Rows[i].FindControl("lblgvCCHFldName");
            CheckBox chInput = (CheckBox)gvCCH.Rows[i].FindControl("chInput");
            CheckBox chOutput = (CheckBox)gvCCH.Rows[i].FindControl("chOutput");
            Label lblgvCCHdataType = (Label)gvCCH.Rows[i].FindControl("lblgvCCHdataType");

            DataRow myDataRow = dt.NewRow();
            myDataRow["FldName"] = lblgvCCHFldName.Text;
            if (chInput.Checked == true)
            {
                myDataRow["InputFld"] = "1";
            }
            else { myDataRow["InputFld"] = "0"; }

            if (chOutput.Checked == true)
            {
                myDataRow["OutputFld"] = "1";
            }
            else { myDataRow["OutputFld"] = "0"; }

            myDataRow["FldDataType"] = lblgvCCHdataType.Text;

            dt.Rows.Add(myDataRow);

        }

        dsCCH = objSearch.CommonSearchFormatInsert(strCCHCode, strObjectName, strReturnFld, strReturnFld2, dt);

    }
}
