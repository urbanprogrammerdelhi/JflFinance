// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Designation.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_Designation
/// </summary>
public partial class Masters_Designation : BasePage //System.Web.UI.Page
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

    #region Page Functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
      
        
        //Page Title from resource file
        System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
        javaScript.Append("<script type='text/javascript'>");
        javaScript.Append("window.document.body.onload = function ()");
        javaScript.Append("{\n");
        javaScript.Append("PageTitle('" + Resources.Resource.DesignationMaster + "');");
        javaScript.Append("};\n");
        javaScript.Append("// -->\n");
        javaScript.Append("</script>");
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());



        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                FillgvDesignation();
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
    /// Fillgvs the designation.
    /// </summary>
    protected void FillgvDesignation()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsDesignation = new DataSet();
        DataTable dtDesignation = new DataTable();
        int dtflag;
        dtflag = 1;
        dsDesignation = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        dtDesignation = dsDesignation.Tables[0];

        //to fix empety gridview
        if (dtDesignation.Rows.Count == 0)
        {
            dtflag = 0;
            dtDesignation.Rows.Add(dtDesignation.NewRow());
        }
        gvDesignation.DataKeyNames = new string[] { "DesignationCode" };
        gvDesignation.DataSource = dtDesignation;
        gvDesignation.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvDesignation.Rows[0].Visible = false;
        }
    }
    #endregion

    #region GridView Commands Events
    /// <summary>
    /// Handles the RowDataBound event of the gvDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvDesignation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvDesignation.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerial");
            if (lblSerialNo != null)
            {
                int serialNo = gvDesignation.PageIndex * gvDesignation.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtDesignationDesc = (TextBox)e.Row.FindControl("txtDesignationDesc");
                if (txtDesignationDesc != null)
                {
                    txtDesignationDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtDesignationDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Visible = false; }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)

                {ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');"; }
            }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvDesignation.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtDesignationCodeNew = (TextBox)e.Row.FindControl("txtDesignationCodeNew");
                if (txtDesignationCodeNew != null)
                {
                    txtDesignationCodeNew.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtDesignationCodeNew.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtDesignationDescNew = (TextBox)e.Row.FindControl("txtDesignationDescNew");
                if (txtDesignationDescNew != null)
                {
                    txtDesignationDescNew.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtDesignationDescNew.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        // To Insert a New Row
        TextBox txtDesignationCode = (TextBox)gvDesignation.FooterRow.FindControl("txtDesignationCodeNew");
        TextBox txtDesignationDesc = (TextBox)gvDesignation.FooterRow.FindControl("txtDesignationDescNew");

        if (e.CommandName == "Add")
        {
            if (txtDesignationCode.Text != "" || txtDesignationDesc.Text != "")
            {
                ds = objMastersManagement.DesignationMasterAddNew(BaseCompanyCode, txtDesignationCode.Text, txtDesignationDesc.Text, BaseUserID);
                FillgvDesignation();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtDesignationCode.Text = "";
            txtDesignationDesc.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvDesignation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.DesignationMasterDelete(BaseCompanyCode, gvDesignation.DataKeys[e.RowIndex].Value.ToString());
        FillgvDesignation();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
            divGrade.Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvDesignation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblDesignation = (Label)gvDesignation.Rows[e.RowIndex].FindControl("lblDesignation");
        TextBox txtDesignationDesc = (TextBox)gvDesignation.Rows[e.RowIndex].FindControl("txtDesignationDesc");

        ds = objMasterManagement.DesignationMasterUpdate(BaseCompanyCode, lblDesignation.Text, txtDesignationDesc.Text, BaseUserID);
        gvDesignation.EditIndex = -1;
        FillgvDesignation();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvDesignation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDesignation.EditIndex = e.NewEditIndex;
        FillgvDesignation();
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvDesignation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDesignation.EditIndex = -1;
        FillgvDesignation();
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvDesignation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDesignation.PageIndex = e.NewPageIndex;
        gvDesignation.EditIndex = -1;
        FillgvDesignation();
    }

    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string url = "../Masters/MasterExport.aspx?type=MASTER&eType=mstDesignation";
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);
    }

    #endregion

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    protected void lnkDesignation_Click(object sender, EventArgs e)
    {
        divGrade.Visible = true;
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lnkDesignation = (LinkButton)gvDesignation.Rows[row.RowIndex].FindControl("lnkDesignation");
        hfDesignationcode.Value = lnkDesignation.Text;
        FillgvGrade();
        lblDesignationName.Text = lnkDesignation.Text;
    }
    private void FillgvGrade()
    {
        try
        {
            BL.MastersManagement objMastersManagement = new BL.MastersManagement();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            int dtflag;
            dtflag = 1;
            ds = objMastersManagement.GradeMasterGetAll(BaseCompanyCode, hfDesignationcode.Value);
            dt = ds.Tables[0];

            //to fix empety gridview
            if (dt.Rows.Count == 0)
            {
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
            }
            gvGrade.DataSource = dt;
            gvGrade.DataBind();

            if (dtflag == 0)//to fix empety gridview
            {
                gvGrade.Rows[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void gvGrade_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        TextBox txtGradeCode = (TextBox)gvGrade.FooterRow.FindControl("txtGradeCode");
        TextBox txtGradeDesc = (TextBox)gvGrade.FooterRow.FindControl("txtGradeDesc");

        if (e.CommandName == "Add")
        {
            if (txtGradeDesc.Text != "" || txtGradeCode.Text != "")
            {
                ds = objMastersManagement.GradeMasterAddNew(BaseCompanyCode, txtGradeCode.Text, txtGradeDesc.Text, BaseUserID,hfDesignationcode.Value);
                FillgvGrade();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                { DisplayMessage(lblErrormsg1, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtGradeCode.Text = "";
            txtGradeDesc.Text = "";
        }
    }
    protected void gvGrade_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblDesignationCode = (Label)gvGrade.Rows[e.RowIndex].FindControl("lblDesignationCode");
        Label lblGradeCode = (Label)gvGrade.Rows[e.RowIndex].FindControl("lblGradeCode");
         ds = objMasterManagement.GradeMasterDelete(BaseCompanyCode,lblDesignationCode.Text,lblGradeCode.Text);
        FillgvGrade();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrormsg1, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }
    protected void gvGrade_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGrade.EditIndex = e.NewEditIndex;
        FillgvGrade();
    }
    protected void gvGrade_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        Label lblDesignationCode = (Label)gvGrade.Rows[e.RowIndex].FindControl("lblDesignationCode");
        Label lblGradeCode = (Label)gvGrade.Rows[e.RowIndex].FindControl("lblGradeCode");
        TextBox txtGradeDesc = (TextBox)gvGrade.Rows[e.RowIndex].FindControl("txtGradeDesc");
        ds = objMasterManagement.GradeMasterUpdate(BaseCompanyCode, lblDesignationCode.Text, lblGradeCode.Text,txtGradeDesc.Text, BaseUserID);
        gvGrade.EditIndex = -1;
        FillgvGrade();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrormsg1, ds.Tables[0].Rows[0]["MessageID"].ToString()); }

    }
    protected void gvGrade_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGrade.EditIndex = -1;
        FillgvGrade();
    }
    protected void gvGrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGrade.PageIndex = e.NewPageIndex;
        gvGrade.EditIndex = -1;
        FillgvGrade();
    }
    protected void gvGrade_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvGrade.Columns[4].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerial1");
            if (lblSerialNo != null)
            {
                int serialNo = gvGrade.PageIndex * gvGrade.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                { ImgbtnEdit.Visible = false; }
            }
            else
            {
                //ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                //if (ImgbtnUpdate != null)
                //{
                //    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                //}
                TextBox txtGradeDesc = (TextBox)e.Row.FindControl("txtGradeDesc");
                if (txtGradeDesc != null)
                {
                    txtGradeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtGradeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                { ImgbtnDelete.Visible = false; }
            }
            //else
            //{
            //    ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete1");
            //    if (ImgbtnDelete != null)

            //    { ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');"; }
            //}


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvGrade.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtGradeCode = (TextBox)e.Row.FindControl("txtGradeCode");
                if (txtGradeCode != null)
                {
                    txtGradeCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtGradeCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtGradeDesc = (TextBox)e.Row.FindControl("txtGradeDesc");
                if (txtGradeDesc != null)
                {
                    txtGradeDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtGradeDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
}
