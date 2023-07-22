// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CampMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class OperationManagement_CampMaster.
/// </summary>
public partial class OperationManagement_CampMaster : BasePage //System.Web.UI.Page
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

    #region Functions Related to Page Evenets
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
        javaScript.Append("PageTitle('" + Resources.Resource.CampMaster + "');");
        javaScript.Append("};\n");
        javaScript.Append("// -->\n");
        javaScript.Append("</script>");
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

        if (!IsPostBack)
        {
            FillCampMaster();
        }
    }
    #endregion

    #region Functions Related to Grid View Camp Master
    /// <summary>
    /// Fills the camp master.
    /// </summary>
    protected void FillCampMaster()
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;

        ds = objCamp.CampMasterGet(BaseCompanyCode);
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        gvCampMaster.DataKeyNames = new string[] { "CampCode" };
        gvCampMaster.DataSource = dt;
        gvCampMaster.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {

            gvCampMaster.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvCampMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvCampMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvCampMaster.PageIndex * gvCampMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvCampMaster.Columns[6].Visible = false;
            }

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {

                gvCampMaster.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvCampMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvCampMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        TextBox txtFtrCName = (TextBox)gvCampMaster.FooterRow.FindControl("txtFtrCName");
        TextBox txtFtrCAddress = (TextBox)gvCampMaster.FooterRow.FindControl("txtFtrCAddress");
        TextBox txtftrCFromDate = (TextBox)gvCampMaster.FooterRow.FindControl("txtftrCFromDate");
        //TextBox txtftrCToDate = (TextBox)gvCampMaster.FooterRow.FindControl("txtftrCToDate");

        if (e.CommandName.Equals("AddNew"))
        {
            ds = objCamp.CampMasterInsert("", BaseCompanyCode, txtFtrCName.Text, txtFtrCAddress.Text, txtftrCFromDate.Text, "", "A", BaseUserID);
            if (gvCampMaster.Rows.Count.Equals(gvCampMaster.PageSize))
            {
                gvCampMaster.PageIndex = gvCampMaster.PageCount + 1;
            }
            gvCampMaster.EditIndex = -1;
            FillCampMaster();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else if (e.CommandName.Equals("Reset"))
        {

            txtFtrCName.Text = "";
            txtFtrCAddress.Text = "";
            txtftrCFromDate.Text = "";
            //txtftrCToDate.Text = "";
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvCampMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvCampMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCampMaster.EditIndex = e.NewEditIndex;
        FillCampMaster();

    }
    /// <summary>
    /// Handles the RowUpdating event of the gvCampMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvCampMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        
        Label lblCCode = (Label)gvCampMaster.Rows[e.RowIndex].FindControl("lblCCode");
        TextBox txtEditCName = (TextBox)gvCampMaster.Rows[e.RowIndex].FindControl("txtEditCName");
        TextBox txtEditCAddress = (TextBox)gvCampMaster.Rows[e.RowIndex].FindControl("txtEditCAddress");
        Label   lblEditCFromDate = (Label)gvCampMaster.Rows[e.RowIndex].FindControl("lblEditCFromDate");
        TextBox txtEditCToDate = (TextBox)gvCampMaster.Rows[e.RowIndex].FindControl("txtEditCToDate");
        if (txtEditCToDate.Text == "")
        {
            ds = objCamp.CampMasterInsert(lblCCode.Text, BaseCompanyCode, txtEditCName.Text, txtEditCAddress.Text, lblEditCFromDate.Text, "", "M", BaseUserID);
        }
        else
        {
            if (DateTime.Parse(txtEditCToDate.Text) >= DateTime.Parse(lblEditCFromDate.Text))
            {
                ds = objCamp.CampMasterInsert(lblCCode.Text, BaseCompanyCode, txtEditCName.Text, txtEditCAddress.Text, lblEditCFromDate.Text, txtEditCToDate.Text, "M", BaseUserID);
                gvCampMaster.EditIndex = -1;
                FillCampMaster();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.ToDateMustBeGreaterThanFromDate);
            }
        }

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvCampMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvCampMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCampMaster.EditIndex = -1;
        FillCampMaster();

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvCampMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvCampMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCampMaster.PageIndex = e.NewPageIndex;
        gvCampMaster.EditIndex = -1;
        FillCampMaster();
    }
    /// <summary>
    /// Handles the Click event of the ImgbtnCCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnCCode_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ImgbtnCCode = (ImageButton)sender;
        GridViewRow gvRow = (GridViewRow)ImgbtnCCode.NamingContainer;
        Label lblCCode = (Label)gvCampMaster.Rows[gvRow.RowIndex].FindControl("lblCCode");
        hfglobalCCode.Value = lblCCode.Text;
        gvBuildingMaster.EditIndex = -1;
        FillBuildingMaster(); 
    }

    #endregion

    #region Functions Related to Gridview Building Master
    /// <summary>
    /// Fills the building master.
    /// </summary>
    protected void FillBuildingMaster()
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;

        ds = objCamp.BuildingMasterGet(hfglobalCCode.Value);  
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        gvBuildingMaster.DataKeyNames = new string[] { "BuildingCode" };
        gvBuildingMaster.DataSource = dt;
        gvBuildingMaster.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {

            gvBuildingMaster.Rows[0].Visible = false;
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvBuildingMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvBuildingMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblgvBuildingSno");
            if (lblSerialNo != null)
            {
                int serialNo = gvBuildingMaster.PageIndex * gvBuildingMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }


            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Visible = false;
                }
                gvBuildingMaster.FooterRow.Visible = false;

            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommand event of the gvBuildingMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvBuildingMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        TextBox txtFtrBuildingName = (TextBox)gvBuildingMaster.FooterRow.FindControl("txtFtrBuildingName");
        TextBox txtFtrBuildingAddress = (TextBox)gvBuildingMaster.FooterRow.FindControl("txtFtrBuildingAddress");
        TextBox txtftrBuildingFromDate = (TextBox)gvBuildingMaster.FooterRow.FindControl("txtftrBuildingFromDate");
        //TextBox txtftrBuildingToDate = (TextBox)gvBuildingMaster.FooterRow.FindControl("txtftrBuildingToDate");

        if (e.CommandName.Equals("AddNew"))
        {
            if (txtFtrBuildingName.Text  != "")
            {
                ds = objCamp.BuildingMasterAddNew(hfglobalCCode.Value, "", txtFtrBuildingName.Text, txtFtrBuildingAddress.Text, txtftrBuildingFromDate.Text, "", "A", BaseUserID);         
                if (gvBuildingMaster.Rows.Count.Equals(gvBuildingMaster.PageSize))
                {
                    gvBuildingMaster.PageIndex = gvBuildingMaster.PageCount + 1;
                }
                gvBuildingMaster.EditIndex = -1;
                FillBuildingMaster(); 
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                DisplayMessage(lblErrorMsg, "5");
            }
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtFtrBuildingName.Text = "";
            txtFtrBuildingAddress.Text = "";
            txtftrBuildingFromDate.Text = "";
            //txtftrBuildingToDate.Text = ""; 
        }

    }
    /// <summary>
    /// Handles the RowEditing event of the gvBuildingMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvBuildingMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBuildingMaster.EditIndex = e.NewEditIndex;
        FillBuildingMaster() ;


    }
    /// <summary>
    /// Handles the RowUpdating event of the gvBuildingMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvBuildingMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();

        Label lblgvBuildingCode = (Label)gvBuildingMaster.Rows[e.RowIndex].FindControl("lblgvBuildingCode");
        TextBox txtEditBuildingName = (TextBox)gvBuildingMaster.Rows[e.RowIndex].FindControl("txtEditBuildingName");
        TextBox txtEditBuildingAddress = (TextBox)gvBuildingMaster.Rows[e.RowIndex].FindControl("txtEditBuildingAddress");
        Label lblEditBuildingFromDate = (Label)gvBuildingMaster.Rows[e.RowIndex].FindControl("lblEditBuildingFromDate");
        TextBox txtEditBuildingToDate = (TextBox)gvBuildingMaster.Rows[e.RowIndex].FindControl("txtEditBuildingToDate");
        if (txtEditBuildingToDate.Text == "")
        {
            ds = objCamp.BuildingMasterAddNew(hfglobalCCode.Value, lblgvBuildingCode.Text, txtEditBuildingName.Text, txtEditBuildingAddress.Text, lblEditBuildingFromDate.Text, "", "M", BaseUserID);
        }
        else
        {
            if (DateTime.Parse(txtEditBuildingToDate.Text) >= DateTime.Parse(lblEditBuildingFromDate.Text))
            {
                ds = objCamp.BuildingMasterAddNew(hfglobalCCode.Value, lblgvBuildingCode.Text, txtEditBuildingName.Text, txtEditBuildingAddress.Text, lblEditBuildingFromDate.Text, txtEditBuildingToDate.Text, "M", BaseUserID);
                gvBuildingMaster.EditIndex = -1;
                FillBuildingMaster();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }
            else 
            {

                DisplayMessageString(lblErrorMsg, Resources.Resource.ToDateMustBeGreaterThanFromDate);
                
            }
        }

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvBuildingMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvBuildingMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBuildingMaster.EditIndex = -1;
        FillBuildingMaster();
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvBuildingMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvBuildingMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBuildingMaster.PageIndex = e.NewPageIndex;
        gvBuildingMaster.EditIndex = -1;
        FillBuildingMaster();
    
    }

    /// <summary>
    /// Handles the Click event of the ImgbtnBuildingCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnBuildingCode_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ImgbtnBuildingCode = (ImageButton)sender;
        GridViewRow gvRow = (GridViewRow)ImgbtnBuildingCode.NamingContainer;
        Label lblgvBuildingCode = (Label)gvBuildingMaster.Rows[gvRow.RowIndex].FindControl("lblgvBuildingCode");
        hfglobalBuildingCode.Value = lblgvBuildingCode.Text;
        gvBedMaster.EditIndex = -1;
        FillgvBedMaster();
    }

    #endregion

    #region Functions Related to Gridview Bed Master

    /// <summary>
    /// Fillgvs the bed master.
    /// </summary>
    protected void FillgvBedMaster()
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;

        ds = objCamp.BedMasterGet(hfglobalCCode.Value,hfglobalBuildingCode.Value );
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        gvBedMaster.DataKeyNames = new string[] { "FloorNo" };
        gvBedMaster.DataSource = dt;
        gvBedMaster.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {

            gvBedMaster.Rows[0].Visible = false;
        }
    
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvBedMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvBedMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            Label lblSerialNo = (Label)objGridViewRow.FindControl("lblgvBedSno");
            if (lblSerialNo != null)
            {
                int serialNo = gvBedMaster.PageIndex * gvBedMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvBedMaster.Columns[6].Visible = false;
            }

            if (IsModifyAccess == false)
            {
                ImageButton ImgbtnEdit = (ImageButton)e.Row.FindControl("ImgbtnEdit");
                if (ImgbtnEdit != null)
                {
                    ImgbtnEdit.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnDelete = (ImageButton)e.Row.FindControl("ImgbtnDelete");
                if (ImgbtnDelete != null)
                {
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {

                gvBedMaster.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnADDNew = (ImageButton)e.Row.FindControl("ImgbtnADDNew");
                if (ImgbtnADDNew != null)
                {
                    ImgbtnADDNew.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
            }
        }

    }

    /// <summary>
    /// Handles the RowCommand event of the gvBedMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvBedMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        TextBox txtFtrFloorno = (TextBox)gvBedMaster.FooterRow.FindControl("txtFtrFloorno");
        TextBox txtFtrFlatNo = (TextBox)gvBedMaster.FooterRow.FindControl("txtFtrFlatNo");
        TextBox txtFtrRoomNo = (TextBox)gvBedMaster.FooterRow.FindControl("txtFtrRoomNo");
        TextBox txtFtrBedNo = (TextBox)gvBedMaster.FooterRow.FindControl("txtFtrBedNo");
        TextBox txtftrBedFromDate = (TextBox)gvBedMaster.FooterRow.FindControl("txtftrBedFromDate");
        //TextBox txtftrBedToDate = (TextBox)gvBedMaster.FooterRow.FindControl("txtftrBedToDate");

        if (e.CommandName.Equals("AddNew"))
        {
            ds = objCamp.BedMasterAddNew(hfglobalCCode.Value,hfglobalBuildingCode.Value,txtFtrFloorno.Text,txtFtrFlatNo.Text,txtFtrRoomNo.Text,txtFtrBedNo.Text,txtftrBedFromDate.Text, "", "A", BaseUserID);
            if (gvBedMaster.Rows.Count.Equals(gvBedMaster .PageSize))
            {
                gvBedMaster .PageIndex = gvBedMaster .PageCount + 1;
            }
            gvBedMaster .EditIndex = -1;
            FillgvBedMaster();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        else if (e.CommandName.Equals("Reset"))
        {
            txtFtrBedNo.Text = "";
            txtFtrFlatNo.Text = "";
            txtFtrFloorno.Text = "";
            txtFtrRoomNo.Text = "";
            txtftrBedFromDate.Text = "";
            //txtftrBedToDate.Text = "";  
        }

    }

    /// <summary>
    /// Handles the RowEditing event of the gvBedMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvBedMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBedMaster.EditIndex = e.NewEditIndex;
        FillgvBedMaster(); 

    }

    /// <summary>
    /// Handles the RowUpdating event of the gvBedMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvBedMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();

        Label lblEditgvFloorNo = (Label)gvBedMaster.Rows[e.RowIndex].FindControl("lblEditgvFloorNo");
        Label lblEditgvFlatNo = (Label)gvBedMaster.Rows[e.RowIndex].FindControl("lblEditgvFlatNo");
        Label lblEditgvRoomNo = (Label)gvBedMaster.Rows[e.RowIndex].FindControl("lblEditgvRoomNo");
        Label lblEditgvBedNo = (Label)gvBedMaster.Rows[e.RowIndex].FindControl("lblEditgvBedNo");
        Label lblEditBedFromDate = (Label)gvBedMaster.Rows[e.RowIndex].FindControl("lblEditBedFromDate");
        TextBox txtEditBedToDate = (TextBox)gvBedMaster.Rows[e.RowIndex].FindControl("txtEditBedToDate");
        if (txtEditBedToDate.Text != "")
        {
            if (DateTime.Parse(txtEditBedToDate.Text) >= DateTime.Parse(lblEditBedFromDate.Text))
            {
                ds = objCamp.BedMasterAddNew(hfglobalCCode.Value, hfglobalBuildingCode.Value, lblEditgvFloorNo.Text, lblEditgvFlatNo.Text, lblEditgvRoomNo.Text, lblEditgvBedNo.Text, lblEditBedFromDate.Text, txtEditBedToDate.Text, "M", BaseUserID);
                gvBedMaster.EditIndex = -1;
                FillgvBedMaster();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.ToDateMustBeGreaterThanFromDate);  
            }

        }

    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvBedMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvBedMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBedMaster.EditIndex = -1;
        FillgvBedMaster();
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvBedMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvBedMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBedMaster.PageIndex = e.NewPageIndex;
        gvBedMaster.EditIndex = -1;
        FillgvBedMaster();
    }
     
    #endregion

}
