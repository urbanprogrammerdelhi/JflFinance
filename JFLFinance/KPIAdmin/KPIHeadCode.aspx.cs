// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="KPIHeadCode.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class KPIAdmin_KPIHeadCode
/// </summary>
public partial class KPIAdmin_KPIHeadCode : BasePage
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
                var VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                var VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                var VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
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
                var VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Authorize Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorize access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsAuthorizeAccess
    {
        get
        {
            try
            {
                var VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }


    #endregion
    #region Page Functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            //Page Title from resource file
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            //javaScript.Append("PageTitle('" + Resources.Resource.DepartmentMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess)
            {
                FillddAmnedment();
                FillgvKpiCode();
                FillgvKpiColorCode();


            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }
    #endregion
    #region GridView Binding
    /// <summary>
    /// Fill kpi code grid
    /// </summary>
    protected void FillgvKpiCode()
    {
        var objKpi = new BL.KPI();

        int dtflag = 1;

        DataSet dsKpiCode = objKpi.GetKpiCode(BaseCompanyCode);
        DataTable dtKpiCode = dsKpiCode.Tables[0];

        //to fix empety gridview
        if (dtKpiCode.Rows.Count == 0)
        {
            dtflag = 0;
            dtKpiCode.Rows.Add(dtKpiCode.NewRow());
        }

        gvKpiCode.DataKeyNames = new[] { "KPIHeadCode" };
        gvKpiCode.DataSource = dtKpiCode;
        gvKpiCode.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvKpiCode.Rows[0].Visible = false;
        }

    }

    /// <summary>
    /// Fill kpi color code grid
    /// </summary>
    protected void FillgvKpiColorCode()
    {
        hiddenStatus.Value = string.Empty;
        var objKpiColorCode = new BL.KPI();

        DataSet dsKpiColorCode = objKpiColorCode.GetKpiColorCode(ddAmendment.SelectedItem.Text, ddElementType.SelectedItem.Value);

        DataTable dtKpiColorCode = dsKpiColorCode.Tables[0];

        int dtflag = 1;



        if (dsKpiColorCode.Tables.Count > 0 && dsKpiColorCode.Tables[0].Rows.Count > 0)
        {
            hiddenStatus.Value = dsKpiColorCode.Tables[0].Rows[0]["KPIStatus"].ToString();
            hiddenMaxAmndmentNO.Value = dsKpiColorCode.Tables[0].Rows[0]["MaxAmendmentNumber"].ToString();
            // lblStatus.Text = hiddenStatus.Value;

        }
        //to fix empety gridview
        if (dtKpiColorCode.Rows.Count == 0)
        {
            dtflag = 0;
            dtKpiColorCode.Rows.Add(dtKpiColorCode.NewRow());
        }

        gvKpiColorCode.DataKeyNames = new[] { "KPIHeadCode" };

        gvKpiColorCode.DataSource = dtKpiColorCode;
        gvKpiColorCode.DataBind();
        if (gvKpiColorCode.Columns[14].Visible)
        {
            gvKpiColorCode.Columns[14].ShowHeader=false;
            gvKpiColorCode.Columns[14].Visible = false;

        }
        EnableDisable();
        if (dtflag == 0)//to fix empty gridview
        {
            gvKpiColorCode.Rows[0].Visible = false;
           // gvKpiColorCode.Columns[14].ShowHeader = false;
        }

    }
    //
    /// <summary>
    /// Fill Drop down Amendment
    /// </summary>
    protected void FillddAmnedment()
    {
        var obj = new BL.KPI();


        //var dt = new DataTable();
        DataSet ds = obj.GetAmendmentNo(ddElementType.SelectedItem.Value);
        ddAmendment.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddAmendment.DataSource = ds.Tables[0];
            ddAmendment.DataTextField = "AmendmentNumber";
            ddAmendment.DataValueField = "AmendDate";
            ddAmendment.DataBind();
            ddAmendment.SelectedIndex = int.Parse(ds.Tables[1].Rows[0]["MaxAmendmentNumber"].ToString()) - 1;
            hiddenMaxAmndmentNO.Value = ddAmendment.SelectedItem.Text;
            lblDate.Text = ddAmendment.SelectedValue;


            txtMonth.Text = (ds.Tables[2].Rows[0]["KPIStatus"].ToString() == "Amend")
                                ? DateFormat(ds.Tables[2].Rows[0]["WEFromMonth"].ToString())
                                : string.Empty;
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddAmendment.Items.Add(li);
        }


    }


    #endregion

    #region GridView Commands Events
    /// <summary>
    /// Handles the RowDataBound event of the gvKpiCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvKpiCode_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            var serialNo = gvKpiCode.PageIndex * gvKpiCode.PageSize + int.Parse(e.Row.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvKpiCode.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            //if (IsModifyAccess == false)
            if (IsAuthorizeAccess == false)
            {
                var imgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (imgbtnEdit != null)
                { imgbtnEdit.Visible = false; }
            }
            else
            {
                var imgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (imgbtnUpdate != null)
                {
                    imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }
                var txtKpiDesc = (TextBox)e.Row.FindControl("txtKpiDesc");
                if (txtKpiDesc != null)
                {
                    txtKpiDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtKpiDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

            }
            if (IsDeleteAccess == false)
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (imgbtnDelete != null)
                { imgbtnDelete.Visible = false; }
            }
            else
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (imgbtnDelete != null)
                {
                    imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvKpiCode.ShowFooter = false;
            }
            else
            {
                var imgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (imgbtnAdd != null)
                {
                    imgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }

                var txtKpiCode = (TextBox)e.Row.FindControl("txtKpiCode");
                if (txtKpiCode != null)
                {
                    txtKpiCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtKpiCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                var txtKpiDesc = (TextBox)e.Row.FindControl("txtKpiDesc");
                if (txtKpiDesc != null)
                {
                    txtKpiDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtKpiDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvKpiCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvKpiCode_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var objKpi = new BL.KPI();

        // To Insert a New Row
        var txtKpiCode = (TextBox)gvKpiCode.FooterRow.FindControl("txtKpiCode");
        var txtKpiDesc = (TextBox)gvKpiCode.FooterRow.FindControl("txtKpiDesc");
        var txtTargetValue = (TextBox)gvKpiCode.FooterRow.FindControl("txtTargetValue");
        var txtRedFrom = (TextBox)gvKpiCode.FooterRow.FindControl("txtRedFrom");
        var txtRedTo = (TextBox)gvKpiCode.FooterRow.FindControl("txtRedTo");
        var txtAmberFrom = (TextBox)gvKpiCode.FooterRow.FindControl("txtAmberFrom");
        var txtAmberTo = (TextBox)gvKpiCode.FooterRow.FindControl("txtAmberTo");
        var txtGreenFrom = (TextBox)gvKpiCode.FooterRow.FindControl("txtGreenFrom");
        var txtGreenTo = (TextBox)gvKpiCode.FooterRow.FindControl("txtGreenTo");
        var chkIsEditable = (CheckBox)gvKpiCode.FooterRow.FindControl("chkIsEditable");
        var chkFtrIsgroupTarget = (CheckBox)gvKpiCode.FooterRow.FindControl("chkFtrIsgroupTarget");
        var txtRedFromMin = (TextBox)gvKpiCode.FooterRow.FindControl("txtRedFromMin");
        var txtRedToMin = (TextBox)gvKpiCode.FooterRow.FindControl("txtRedToMin");
        var txtAmberFromMin = (TextBox)gvKpiCode.FooterRow.FindControl("txtAmberFromMin");
        var txtAmberToMin = (TextBox)gvKpiCode.FooterRow.FindControl("txtAmberToMin");

        if (chkFtrIsgroupTarget.Checked)
        {
            txtTargetValue.Text = @"0.0";
        }

        if (e.CommandName == "Add")
        {
            if (CheckValue(txtRedFrom, txtRedTo, txtAmberFrom, txtAmberTo, txtGreenFrom, txtGreenTo, txtRedFromMin, txtRedToMin, txtAmberFromMin, txtAmberToMin))
            {

                DataSet ds = objKpi.KPICodeAddNew(txtKpiCode.Text, txtKpiDesc.Text, txtTargetValue.Text, txtRedFrom.Text,
                                                  txtRedTo.Text, txtAmberFrom.Text, txtAmberTo.Text, txtGreenFrom.Text,
                                                  txtGreenTo.Text, BaseUserID, DateTime.Now.ToString(),
                                                  chkIsEditable.Checked.ToString(),
                                                  chkFtrIsgroupTarget.Checked.ToString(), txtRedFromMin.Text,
                                                  txtRedToMin.Text, txtAmberFromMin.Text, txtAmberToMin.Text);
                gvKpiCode.EditIndex = -1;
                FillgvKpiCode();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
        }
        if (e.CommandName == "Reset")
        {
            txtKpiCode.Text = "";
            txtKpiDesc.Text = "";
            txtAmberFrom.Text = "";
            txtAmberTo.Text = "";
            txtGreenFrom.Text = "";
            txtGreenTo.Text = "";
            txtRedTo.Text = "";
            txtRedFrom.Text = "";
            txtTargetValue.Text = "";
            txtRedFromMin.Text = "";
            txtRedToMin.Text = "";
            txtAmberFromMin.Text = "";
            txtAmberToMin.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvKpiCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvKpiCode_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvKpiCode.EditIndex = e.NewEditIndex;
        FillgvKpiCode();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvKpiCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvKpiCode_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvKpiCode.EditIndex = -1;
        FillgvKpiCode();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvKpiCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvKpiCode_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        var objKpi = new BL.KPI();

        //  var ds = new DataSet();

        var lblgvhdrgvKpiCode = (Label)gvKpiCode.Rows[e.RowIndex].FindControl("lblgvhdrgvKpiCode");
        var txtKpiDesc = (TextBox)gvKpiCode.Rows[e.RowIndex].FindControl("txtKpiDesc");
        var chkIsEditable = (CheckBox)gvKpiCode.Rows[e.RowIndex].FindControl("chkIsEditable");
        var chkIsgroupTarget = (CheckBox)gvKpiCode.Rows[e.RowIndex].FindControl("chkIsgroupTarget");
        DataSet ds = objKpi.KPICodeUpdate(lblgvhdrgvKpiCode.Text, txtKpiDesc.Text, BaseUserID, DateTime.Now.ToString(), chkIsEditable.Checked.ToString(), chkIsgroupTarget.Checked.ToString());
        gvKpiCode.EditIndex = -1;
        FillgvKpiCode();
        FillgvKpiColorCode();

        DisplayMessage(lblErrorMsg, (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) ? ds.Tables[0].Rows[0]["MessageID"].ToString() : "");


    }
    /// <summary>
    /// Handles the RowDeleting event of the gvKpiCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvKpiCode_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvKpiCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvKpiCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvKpiCode.PageIndex = e.NewPageIndex;
        gvKpiCode.EditIndex = -1;
        FillgvKpiCode();
    }
    #endregion
    # region ColorCode grid view event
    /// <summary>
    /// Handles the RowEditing event of the gvKpiColorCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvKpiColorCode_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvKpiColorCode.EditIndex = e.NewEditIndex;
        FillgvKpiColorCode();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvKpigvKpiColorCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvKpigvKpiColorCode_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvKpiColorCode.EditIndex = -1;
        FillgvKpiColorCode();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvKpiColorCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvKpiColorCode_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        //BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        var objKpi = new BL.KPI();

        //var ds = new DataSet();
        // var lblgvhdrgvKpiColorCode = (Label)gvKpiColorCode.Rows[e.RowIndex].FindControl("lblgvhdrgvKpiColorCode");
        var lblgvElementlevel = (Label)gvKpiColorCode.Rows[e.RowIndex].FindControl("lblgvElementlevel");
        var txtRedFrom = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtRedFrom");
        var txtRedTo = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtRedTo");
        var txtAmberFrom = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtAmberFrom");
        var txtAmberTo = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtAmberTo");
        var txtGreenFrom = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtGreenFrom");
        var txtGreenTo = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtGreenTo");
        var txtTargetValue = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtTargetValue");
        var hfKpiHeadCode = (HiddenField)gvKpiColorCode.Rows[e.RowIndex].FindControl("HFKPIHeadCode");
        var txtRedFromMin = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtMinRedFrom");
        var txtRedToMin = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtMinRedTo");
        var txtAmberFromMin = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtMinAmberFrom");
        var txtAmberToMin = (TextBox)gvKpiColorCode.Rows[e.RowIndex].FindControl("txtAmberToMin");

        if (CheckValue(txtRedFrom, txtRedTo, txtAmberFrom, txtAmberTo, txtGreenFrom, txtGreenTo, txtRedFromMin, txtRedToMin, txtAmberFromMin, txtAmberToMin))
        {
            //ds = objMastersManagement.DepartmentUpdate(BaseCompanyCode, lblgvhdrgvKpiCode.Text, txtKpiDesc.Text, BaseUserID.ToString());
            DataSet ds;
            using (ds = objKpi.KPIColorCodeUpdate(hfKpiHeadCode.Value, lblgvElementlevel.Text, txtRedFrom.Text, txtRedTo.Text, txtAmberFrom.Text, txtAmberTo.Text, txtGreenFrom.Text, txtGreenTo.Text, BaseUserID, DateTime.Now.ToString(), int.Parse(ddAmendment.SelectedItem.Text), txtTargetValue.Text, txtRedFromMin.Text, txtRedToMin.Text, txtAmberFromMin.Text, txtAmberToMin.Text))
            {
                gvKpiColorCode.EditIndex = -1;
                FillgvKpiColorCode();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvKpiColorCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvKpiColorCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvKpiColorCode.PageIndex = e.NewPageIndex;
        gvKpiColorCode.EditIndex = -1;
        FillgvKpiColorCode();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvKpiColorCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvKpiColorCode_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvKpiColorCode.EditIndex = -1;
        FillgvKpiColorCode();
    }
    /// <summary>
    /// Handles the RowCommand event of the gvKpiColorCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvKpiColorCode_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvKpiColorCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvKpiColorCode_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                var imgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (imgbtnEdit != null)
                { imgbtnEdit.Visible = false; }
            }
            else
            {
                var imgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (imgbtnUpdate != null)
                {
                    imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }
                var imgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                var hfIsEditable = (HiddenField)e.Row.FindControl("HFIsEditable");

                if (hfIsEditable != null)
                {
                    if (bool.Parse(hfIsEditable.Value) == false)
                    {
                        imgbtnEdit.Visible = false;
                    }
                    else
                    {
                        if (hiddenStatus.Value == "Amend" && IsWriteAccess.Equals(true))
                        {
                            imgbtnEdit.Visible = true;
                        }
                        else
                        {
                            imgbtnEdit.Visible = false;
                        }
                    }
                }
            }


        }

    }

    #  endregion

    #region Controles Command Events
    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs" /> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MasterMenu.aspx");
    }
    #endregion
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddAmendment control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddAmendment_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvKpiColorCode.EditIndex = -1;
        FillgvKpiColorCode();
        lblDate.Text = ddAmendment.SelectedValue;


    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddElementType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void ddElementType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddAmnedment();
        gvKpiColorCode.EditIndex = -1;
        FillgvKpiColorCode();
    }
    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //lblErrorMsg.Text = hiddenMaxAmndmentNO.Value;
        lblMonth.Visible = true;
        imgDate.Visible = true;
        txtMonth.Visible = true;
        txtMonth.Focus();
        if (txtMonth.Text == "")
        {
            lblErrorMsg.Text = Resources.Resource.MsgEnterDates;
            txtMonth.Focus();
            return;
        }
        //EnableDisable();

        // Create New rows against existing records in data base with Amned status.
        var objKpi = new BL.KPI();
        DataSet ds = objKpi.KPIColorCodeAmend(ddElementType.SelectedItem.Value, txtMonth.Text, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[1].Rows[0]["MessageID"].ToString()); }
        FillddAmnedment();
        FillgvKpiColorCode();
    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Set Amend Status to Authorized.........
        var objKpi = new BL.KPI();
        DataSet ds = objKpi.KPIColorCodeAuthorized(ddElementType.SelectedItem.Value, txtMonth.Text, BaseUserID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
        }
        FillddAmnedment();
        if (!lblErrorMsg.Text.Contains("Invalid"))
        {
            lblMonth.Visible = false;
            imgDate.Visible = false;
            txtMonth.Visible = false;
            gvKpiColorCode.Columns[10].Visible = false;
            btnEdit.Visible = true;
            lnkLock.Visible = false;
            //btnSave.Visible = false;
        }
        else
        { txtMonth.Text = string.Empty; }
        FillgvKpiColorCode();
    }

    /// <summary>
    /// Enable and disable the control
    /// </summary>
    public void EnableDisable()
    {
        //To verify the maximum Amendment Number status is Authorized or Not.If is Authorized then Enbale Update button else Save button.

        if (hiddenStatus.Value == "Amend")
        {
            lnkLock.Visible = false;
            if (int.Parse(ddAmendment.SelectedItem.Text) == int.Parse(hiddenMaxAmndmentNO.Value))
            {
                //  btnSave.Visible = true;
                lnkLock.Visible = true;
            }
            btnEdit.Visible = false;
            lblMonth.Visible = true;
            imgDate.Visible = true;
            txtMonth.Visible = true;
            txtMonth.Enabled = false;
            gvKpiColorCode.Columns[14].Visible = true;
            gvKpiColorCode.Columns[14].ShowHeader = true ;
            lblStatus.Text = Resources.Resource.Unlock;
            //btnCorrect.Visible = false;

        }
        else
        {
            btnEdit.Visible = false;
            //btnCorrect.Visible = false;
            gvKpiColorCode.Columns[14].Visible = false;
            gvKpiColorCode.Columns[14].ShowHeader = false;
            if (int.Parse(ddAmendment.SelectedItem.Text) == int.Parse(hiddenMaxAmndmentNO.Value))
            {
                btnEdit.Visible = true;
                gvKpiColorCode.Columns[14].Visible = true;
                gvKpiColorCode.Columns[14].ShowHeader = true;
                // btnCorrect.Visible = true;
            }
            lnkLock.Visible = false;
            imgDate.Visible = false;
            txtMonth.Visible = false;
            lblMonth.Visible = false;
            lblStatus.Text = Resources.Resource.Lock;
            //if (btnCorrect.Visible == true)
            //{
            //gvKpiColorCode.Columns[10].Visible = true;
            //}
            //else
            //{
            //    gvKpiColorCode.Columns[10].Visible = false;
            //}

        }
    }

    //protected void btnCorrect_Click(object sender, EventArgs e)
    //{
    //    gvKpiColorCode.Columns[10].Visible = true;
    //}

    /// <summary>
    /// Checks the value.
    /// </summary>
    /// <param name="redMin">The red minimum.</param>
    /// <param name="redMax">The red maximum.</param>
    /// <param name="amberMin">The amber minimum.</param>
    /// <param name="amberMax">The amber maximum.</param>
    /// <param name="greenMin">The green minimum.</param>
    /// <param name="greenMax">The green maximum.</param>
    /// <param name="redFromMin">The red minimum Negative Value</param>
    /// <param name="redToMin">The red maximum Negative Value</param>
    /// <param name="amberFromMin">The amber minimum Negative Value</param>
    /// <param name="amberToMin">The Amber maximum Negative Value</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckValue(TextBox redMin, TextBox redMax, TextBox amberMin, TextBox amberMax, TextBox greenMin, TextBox greenMax, TextBox redFromMin, TextBox redToMin, TextBox amberFromMin, TextBox amberToMin)
    {
        int doubleRedMin = int.Parse(redMin.Text);
        int doubleRedMax = int.Parse(redMax.Text);
        int doubleAmberMin = int.Parse(amberMin.Text);
        int doubleAmberMax = int.Parse(amberMax.Text);
        int doubleGreenMin = int.Parse(greenMin.Text);
        int doubleGreenMax = int.Parse(greenMax.Text);

        int doubleRedFromMin = int.Parse(redFromMin.Text);
        int doubleRedToMin = int.Parse(redToMin.Text);
        int doubleAmberFromMin = int.Parse(amberFromMin.Text);
        int doubleAmberToMin = int.Parse(amberToMin.Text);

        if (doubleRedMin < doubleGreenMin)
        {
            if (doubleRedMax.ToString() != doubleAmberMin.ToString())
            {
                amberMin.BackColor = Color.Red;
                redMax.BackColor = Color.Red;
                amberFromMin.BackColor = Color.Red;

                return false;
            }
            amberMin.BackColor = Color.Empty;
            amberFromMin.BackColor = Color.Empty;
            redMax.BackColor = Color.Empty;
            if (doubleAmberMax.ToString() != doubleGreenMin.ToString())
            {
                amberMax.BackColor = Color.Red;
                greenMin.BackColor = Color.Red;
                amberToMin.BackColor = Color.Red;


                return false;
            }
            amberMax.BackColor = Color.Empty;
            greenMin.BackColor = Color.Empty;
            amberToMin.BackColor = Color.Empty;
        }
        else
        {

            if (doubleAmberMin.ToString() != doubleGreenMax.ToString())
            {
                amberMin.BackColor = Color.Red;
                greenMax.BackColor = Color.Red;
                amberFromMin.BackColor = Color.Red;
                return false;
            }
            amberMin.BackColor = Color.Empty;
            greenMax.BackColor = Color.Empty;
            amberFromMin.BackColor = Color.Empty;
            if (doubleRedMin.ToString() != doubleAmberMax.ToString())
            {
                redMin.BackColor = Color.Red;
                redFromMin.BackColor = Color.Red;
                amberMax.BackColor = Color.Red;
                amberToMin.BackColor = Color.Red;
                amberMin.BackColor = Color.Empty;
                amberFromMin.BackColor = Color.Empty;
                greenMax.BackColor = Color.Empty;

                //  System.Windows.Forms.MessageBox.Show(amberMax.Text);
                return false;
            }
            redMin.BackColor = Color.Empty;
            amberMax.BackColor = Color.Empty;
            amberMin.BackColor = Color.Empty;
            greenMax.BackColor = Color.Empty;
            redFromMin.BackColor = Color.Empty;
            amberToMin.BackColor = Color.Empty;
            amberFromMin.BackColor = Color.Empty;

        }
        if (doubleRedMin.ToString() == doubleRedMax.ToString())
        {
            //redMax.BackColor = Color.Red;
            redMax.BackColor = Color.Red;
            return false;
        }
        redMax.BackColor = Color.Empty;

        if (doubleAmberMin.ToString() == doubleAmberMax.ToString())
        {
            //redMax.BackColor = Color.Red;
            amberMax.BackColor = Color.Red;
            return false;
        }
        amberMax.BackColor = Color.Empty;

        if (doubleGreenMin.ToString() == doubleGreenMax.ToString())
        {
            //redMax.BackColor = Color.Red;
            greenMax.BackColor = Color.Red;
            return false;
        }
        greenMax.BackColor = Color.Empty;
        // Red Color Check

        if (doubleRedMin > doubleAmberMin && doubleRedMin < doubleAmberMax)
        {
            redMin.BackColor = Color.Red;
            return false;
        }
        redMin.BackColor = Color.Empty;

        //if (doubleRedMax < doubleAmberMin && doubleRedMax < doubleAmberMax)
        if (doubleRedMax.ToString() != doubleAmberMin.ToString() && doubleRedMax < doubleAmberMax)
        {
            redMax.BackColor = Color.Red;
            return false;
        }
        redMax.BackColor = Color.Empty;

        if (doubleRedMin > doubleGreenMin && doubleRedMin < doubleGreenMax)
        {
            redMin.BackColor = Color.Red;
            return false;
        }
        redMin.BackColor = Color.Empty;

        if (doubleRedMax > doubleGreenMin && doubleRedMax < doubleGreenMax)
        {
            redMax.BackColor = Color.Red;
            return false;
        }
        redMax.BackColor = Color.Empty;

        // END OF Red Color Check



        // Amber Color Check

        //if (doubleAmberMin > doubleRedMin && doubleAmberMin < doubleRedMax)
        if (doubleAmberMin > doubleRedMin && doubleAmberMin.ToString() != doubleRedMax.ToString())
        {
            amberMin.BackColor = Color.Red;
            return false;
        }
        amberMin.BackColor = Color.Empty;

        if (doubleAmberMax > doubleRedMin && doubleAmberMax < doubleRedMax)
        {
            amberMax.BackColor = Color.Red;
            return false;
        }
        amberMax.BackColor = Color.Empty;

        if (doubleAmberMin > doubleGreenMin && doubleAmberMin < doubleGreenMax)
        {
            amberMin.BackColor = Color.Red;
            return false;
        }
        amberMin.BackColor = Color.Empty;

        //if (doubleAmberMax > doubleGreenMin && doubleAmberMax < doubleGreenMax)
        if (doubleAmberMax.ToString() != doubleGreenMin.ToString() && doubleAmberMax < doubleGreenMax)
        {
            amberMax.BackColor = Color.Red;
            return false;
        }
        amberMax.BackColor = Color.Empty;

        // END OF Amber Color Check


        // Green Color Check
        if (doubleGreenMin > doubleRedMin && doubleGreenMin < doubleRedMax)
        {
            greenMin.BackColor = Color.Red;
            return false;
        }
        greenMin.BackColor = Color.Empty;

        if (doubleGreenMax > doubleRedMin && doubleGreenMax < doubleRedMax)
        {
            greenMax.BackColor = Color.Red;
            return false;
        }
        greenMax.BackColor = Color.Empty;

        //if (doubleGreenMin > doubleAmberMin && doubleGreenMin < doubleAmberMax)
        if (doubleGreenMin > doubleAmberMin && doubleGreenMin.ToString() != doubleAmberMax.ToString())
        {
            greenMin.BackColor = Color.Red;
            return false;
        }
        greenMin.BackColor = Color.Empty;

        //if (doubleGreenMax > doubleAmberMin && doubleGreenMax < doubleAmberMax)
        if (doubleGreenMax.ToString() != doubleAmberMin.ToString() && doubleGreenMax < doubleAmberMax)
        {
            greenMax.BackColor = Color.Red;
            return false;
        }
        greenMax.BackColor = Color.Empty;

        // END OF Green Color Check
        /************************************************/

        //Code for Negative Range Between -9999.9 to -1.0

        if (doubleRedFromMin.ToString() != "" && doubleRedToMin.ToString() != "" && doubleRedFromMin.ToString() != @"0" &&
            doubleRedToMin.ToString() != @"0")
        {
            if (doubleRedFromMin.ToString() == doubleRedToMin.ToString())
            {
                redToMin.BackColor = Color.Red;
                return false;
            }
            redToMin.BackColor = Color.Empty;


            if (doubleRedFromMin > doubleRedToMin)
            {
                redFromMin.BackColor = Color.Red;
                return false;

            }
            redFromMin.BackColor = Color.Empty;
        }


        if (doubleAmberFromMin.ToString() != "" && doubleAmberToMin.ToString() != "" &&
            doubleAmberFromMin.ToString() != @"0" && doubleAmberToMin.ToString() != @"0")
        {
            if (doubleAmberFromMin.ToString() == doubleAmberToMin.ToString())
            {

                amberToMin.BackColor = Color.Red;
                return false;
            }
            amberToMin.BackColor = Color.Empty;



            if (doubleAmberFromMin > doubleAmberToMin)
            {

                amberFromMin.BackColor = Color.Red;
                return false;
            }
            amberFromMin.BackColor = Color.Empty;
        }

        if (doubleRedFromMin.ToString() != "" && doubleRedToMin.ToString() != "" && doubleAmberFromMin.ToString() != "" &&
            doubleAmberToMin.ToString() != "")
        {
            if (doubleRedFromMin > doubleAmberFromMin && (doubleAmberFromMin != 0 && doubleAmberToMin != 0) &&
                (doubleRedFromMin != 0 && doubleRedToMin != 0) || doubleRedFromMin < doubleAmberFromMin)
            {

                amberFromMin.BackColor = Color.Empty;
               
            }
            else
            {
                amberFromMin.BackColor = Color.Red;
                return false;
            }
          
        }
        if (doubleRedToMin > doubleAmberToMin && (doubleAmberFromMin != 0 && doubleAmberToMin != 0) &&
            (doubleRedFromMin != 0 && doubleRedToMin != 0) || doubleRedToMin < doubleAmberToMin)
        {

            amberFromMin.BackColor = Color.Empty;
           
        }
        else
        {
            amberFromMin.BackColor = Color.Red;
            return false;
        }
    


    //Check for the range value if Amber 2 is not between Range 1 Values
        
        //---------------   Red Range 2 for Min Value

        if (doubleRedFromMin >= doubleRedMin && doubleRedFromMin< doubleRedMax && (doubleRedFromMin !=0 && doubleRedToMin !=0))
        {
            redFromMin.BackColor = Color.Red;
            return false;
        }
        redFromMin.BackColor = Color.Empty;

        if (doubleRedFromMin >= doubleAmberMin && doubleRedFromMin < doubleAmberMax && (doubleRedFromMin != 0 && doubleRedToMin != 0))
        {
            redFromMin.BackColor = Color.Red;
            return false;
        }
        redFromMin.BackColor = Color.Empty;

        if (doubleRedFromMin >= doubleGreenMin && doubleRedFromMin < doubleGreenMin && (doubleRedFromMin != 0 && doubleRedToMin != 0))
        {
            redFromMin.BackColor = Color.Red;
            return false;
        }
        redFromMin.BackColor = Color.Empty;

        //---------------Red Max Value Range 2
        if (doubleRedToMin >= doubleRedMin && doubleRedFromMin < doubleRedMax && (doubleRedFromMin != 0 && doubleRedToMin != 0))
        {
            redFromMin.BackColor = Color.Red;
            return false;
        }
        redFromMin.BackColor = Color.Empty;

        if (doubleRedToMin >= doubleAmberMin && doubleRedFromMin < doubleAmberMax && (doubleRedFromMin != 0 && doubleRedToMin != 0))
        {
            redFromMin.BackColor = Color.Red;
            return false;
        }
        redFromMin.BackColor = Color.Empty;

        if (doubleRedToMin >= doubleGreenMin && doubleRedFromMin < doubleGreenMax && (doubleRedFromMin != 0 && doubleRedToMin != 0))
        {
            redFromMin.BackColor = Color.Red;
            return false;
        }
        redFromMin.BackColor = Color.Empty;

        //------------ Range Value 2 Amber Min
        if (doubleAmberFromMin >= doubleRedMin && doubleAmberFromMin < doubleRedMax && (doubleAmberFromMin != 0 && doubleAmberFromMin != 0))
        {
            amberFromMin.BackColor = Color.Red;
            return false;
        }
        amberFromMin.BackColor = Color.Empty;

        if (doubleAmberFromMin >= doubleAmberMin && doubleAmberFromMin < doubleAmberMax && (doubleAmberFromMin != 0 && doubleAmberFromMin != 0))
        {
            amberFromMin.BackColor = Color.Red;
            return false;
        }
        amberFromMin.BackColor = Color.Empty;

        if (doubleAmberFromMin >= doubleGreenMin && doubleAmberFromMin < doubleGreenMax && (doubleAmberFromMin != 0 && doubleAmberFromMin != 0))
        {
            amberFromMin.BackColor = Color.Red;
            return false;
        }
        amberFromMin.BackColor = Color.Empty;

        //------------ Range Value 2 Amber Max-------------------------------------

        if (doubleAmberToMin >= doubleRedMin && doubleAmberToMin < doubleRedMax && (doubleAmberToMin != 0 && doubleAmberToMin != 0))
        {
            amberToMin.BackColor = Color.Red;
            return false;
        }
        amberToMin.BackColor = Color.Empty;

        if (doubleAmberToMin >= doubleAmberMin && doubleAmberToMin < doubleAmberMax && (doubleAmberToMin != 0 && doubleAmberToMin != 0))
        {
            amberToMin.BackColor = Color.Red;
            return false;
        }
        amberToMin.BackColor = Color.Empty;

        if (doubleAmberToMin >= doubleGreenMin && doubleAmberToMin < doubleGreenMax && (doubleAmberToMin != 0 && doubleAmberToMin != 0))
        {
            amberToMin.BackColor = Color.Red;
            return false;
        }
        amberToMin.BackColor = Color.Empty;

        //-----------------Range to Check if Range 2 Red Value < RedMin > GreenMax

        if (doubleRedFromMin < doubleRedMin && doubleRedToMin > doubleGreenMax && (doubleRedFromMin != 0 && doubleRedToMin != 0))
        {
            redToMin.BackColor = Color.Red;
            redFromMin.BackColor = Color.Red;
            return false;
        }
        redToMin.BackColor = Color.Empty;
        redFromMin.BackColor = Color.Empty;

        //-----------------Range to Check if Range 2 Amber Value < RedMin > GreenMax

        if (doubleAmberFromMin < doubleRedMin && doubleAmberToMin > doubleGreenMax && (doubleAmberFromMin != 0 && doubleAmberToMin != 0))
        {
            amberToMin.BackColor = Color.Red;
            amberFromMin.BackColor = Color.Red;
            return false;
        }
        amberToMin.BackColor = Color.Empty;
        amberFromMin.BackColor = Color.Empty;
        

        return true;
    }


    /// <summary>
    /// Locks the KPI color codes
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkLock_Click(object sender, EventArgs e)
    {
        if (txtMonth.Text != "")
        {
            //Enter code to check for the WEF Greater than To Date of Previous Amendment
            btnSave_Click(null, null);
        }
        else
        {
            txtMonth.Focus();
            lblErrorMsg.Text = Resources.Resource.MsgEnterDates;
        }
    }

    /// <summary>
    /// Created Headers of KPI Head Code Grids
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvKpiCode_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var gvKpi = (GridView)sender;
            var headerRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //Adding S.No Column
            var headerCell = new TableCell
                                 {
                                     Text = Resources.Resource.SerialNumber,
                                     HorizontalAlign = HorizontalAlign.Left,
                                     RowSpan = 2

                                 };
            headerRow.Cells.Add(headerCell);

            //Adding KPIHeadCode Column
            headerCell = new TableCell
                             {
                                 Text = Resources.Resource.KPIHeadCode,
                                 HorizontalAlign = HorizontalAlign.Left,
                                 RowSpan = 2
                             };

            headerRow.Cells.Add(headerCell);

            //Adding KPIHeadDesc Column
            headerCell = new TableCell
                             {
                                 Text = Resources.Resource.KPIHeadDesc,
                                 HorizontalAlign = HorizontalAlign.Left,
                                 RowSpan = 2
                             };

            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.TargetValue,
                HorizontalAlign = HorizontalAlign.Left,
                RowSpan = 2
            };

            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
                             {
                                 Text = Resources.Resource.IsGrpTarget,
                                 HorizontalAlign = HorizontalAlign.Left,
                                 RowSpan = 2
                             };


            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.RedRange1,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };

            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.AmberRange1,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };

            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.GreenRange1,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };

            headerRow.Cells.Add(headerCell);



            headerCell = new TableCell
            {
                Text = Resources.Resource.AmberRange2,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };
            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.RedRange2,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };

            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.IsEditable,
                HorizontalAlign = HorizontalAlign.Center,
                RowSpan = 2
            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.EditColName,
                HorizontalAlign = HorizontalAlign.Center,
                RowSpan = 2
            };

            headerRow.Cells.Add(headerCell);
            gvKpi.Controls[0].Controls.AddAt(0, headerRow);

            headerRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            headerCell = new TableCell
                             {
                                 Text = Resources.Resource.Min,
                                 HorizontalAlign = HorizontalAlign.Center

                             };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);
            gvKpi.Controls[0].Controls.AddAt(1, headerRow);
        }


    }

    /// <summary>
    /// Creates Header row for KPI Color Code Grid
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvKpiColorCode_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var gvKpi = (GridView)sender;
            var headerRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //Adding S.No Column
            var headerCell = new TableCell
            {
                Text = Resources.Resource.KPIHeadDesc,
                HorizontalAlign = HorizontalAlign.Left,
                RowSpan = 2

            };
            headerRow.Cells.Add(headerCell);

            //Adding KPIHeadDesc Column
            headerCell = new TableCell
            {
                Text = Resources.Resource.ElementLevel,
                HorizontalAlign = HorizontalAlign.Left,
                RowSpan = 2
            };

            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.TargetValue,
                HorizontalAlign = HorizontalAlign.Left,
                RowSpan = 2
            };

            headerRow.Cells.Add(headerCell);



            headerCell = new TableCell
            {
                Text = Resources.Resource.RedRange1,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };

            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.AmberRange1,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };

            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.GreenRange1,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };

            headerRow.Cells.Add(headerCell);



            headerCell = new TableCell
            {
                Text = Resources.Resource.AmberRange2,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };
            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.RedRange2,
                HorizontalAlign = HorizontalAlign.Center,
                ColumnSpan = 2
            };

            headerRow.Cells.Add(headerCell);

            if (ddAmendment.SelectedIndex+1 == ddAmendment.Items.Count)
            {
                headerCell = new TableCell
                                 {
                                     Text = Resources.Resource.EditColName,
                                     HorizontalAlign = HorizontalAlign.Center,
                                     RowSpan = 2
                                 };
            }

            headerRow.Cells.Add(headerCell);
            gvKpi.Controls[0].Controls.AddAt(0, headerRow);

            headerRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);

            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Min,
                HorizontalAlign = HorizontalAlign.Center

            };
            headerRow.Cells.Add(headerCell);
            headerCell = new TableCell
            {
                Text = Resources.Resource.Max,
                HorizontalAlign = HorizontalAlign.Center
            };
            headerRow.Cells.Add(headerCell);
            gvKpi.Controls[0].Controls.AddAt(1, headerRow);
        }


    }
}