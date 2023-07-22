// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CampTransaction.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class OperationManagement_CampTransaction.
/// </summary>
public partial class OperationManagement_CampTransaction : BasePage  //System.Web.UI.Page
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

    #region Page Function 

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
        //if (lblPageHdrTitle != null)
        //{
            
        //    lblPageHdrTitle.Text = Resources.Resource.Transaction ;
        //}
        
        //Page Title from resource file
        System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
        javaScript.Append("<script type='text/javascript'>");
        javaScript.Append("window.document.body.onload = function ()");
        javaScript.Append("{\n");
        javaScript.Append("PageTitle('" + Resources.Resource.Transaction + "');");
        javaScript.Append("};\n");
        javaScript.Append("// -->\n");
        javaScript.Append("</script>");
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

        if (!IsPostBack)
        {
            FillddlCamp();
            FillddlBuilding();
            FillddlFloor();
            FillddlFlat();
            FillddlRoom(); 
        }

    }
    #endregion 

    #region controls event 
    /// <summary>
    /// Fillddls the camp.
    /// </summary>
    protected void FillddlCamp()
    {
        DataSet ds = new DataSet();  
        BL.CampManagement objCamp = new BL.CampManagement();
        ds = objCamp.CampMasterGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlCamp.DataSource = ds;
            ddlCamp.DataTextField = "CampName";
            ddlCamp.DataValueField = "CampCode";
            ddlCamp.DataBind();

            ListItem li2 = new ListItem();
            li2.Text = Resources.Resource.Select ;
            li2.Value = "0";
            ddlCamp.Items.Insert(0, li2);
            ddlCamp.SelectedIndex = 0;

        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text =  Resources.Resource.NoData;
            li1.Value = "0";
            ddlCamp.Items.Insert(0, li1);
        }
    }

    /// <summary>
    /// Fillddls the building.
    /// </summary>
    protected void FillddlBuilding()
    {
        DataSet ds = new DataSet();
        BL.CampManagement objCamp = new BL.CampManagement();
        ds = objCamp.BuildingMasterGet(ddlCamp.SelectedValue);   
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlBuilding.DataSource = ds;
            ddlBuilding.DataTextField = "BuildingName";
            ddlBuilding.DataValueField = "BuildingCode";
            ddlBuilding.DataBind();

            ListItem li2 = new ListItem();
            li2.Text = Resources.Resource.Select ;
            li2.Value = "0";
            ddlBuilding.Items.Insert(0, li2);
            ddlBuilding.SelectedIndex = 0;

        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text =  Resources.Resource.NoData;
            li1.Value = "0";
            ddlBuilding.Items.Insert(0, li1);
        }

    }

    /// <summary>
    /// Fillddls the floor.
    /// </summary>
    protected void FillddlFloor()
    {
        DataSet ds = new DataSet();
        BL.CampManagement objCamp = new BL.CampManagement();
        ds = objCamp.CampRosterFloorGet(ddlCamp.SelectedValue, ddlBuilding.SelectedValue);    
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlFloor.DataSource = ds;
            ddlFloor.DataTextField = "FloorNo";
            ddlFloor.DataValueField = "FloorNo";
            ddlFloor.DataBind();

            ListItem li2 = new ListItem();
            li2.Text = Resources.Resource.Select;
            li2.Value = "0";
            ddlFloor.Items.Insert(0, li2);
            ddlFloor.SelectedIndex = 0;

        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoData;
            li1.Value = "0";
            ddlFloor.Items.Insert(0, li1);
        }

    }

    /// <summary>
    /// Fillddls the flat.
    /// </summary>
    protected void FillddlFlat()
    {
        DataSet ds = new DataSet();
        BL.CampManagement objCamp = new BL.CampManagement();
        ds = objCamp.CampRosterFlatGet(ddlCamp.SelectedValue, ddlBuilding.SelectedValue,ddlFloor.SelectedValue );
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlFlat.DataSource = ds;
            ddlFlat.DataTextField = "FlatNo";
            ddlFlat.DataValueField = "FlatNo";
            ddlFlat.DataBind();

            ListItem li2 = new ListItem();
            li2.Text = Resources.Resource.Select;
            li2.Value = "0";
            ddlFlat.Items.Insert(0, li2);
            ddlFlat.SelectedIndex = 0;

        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoData;
            li1.Value = "0";
            ddlFlat.Items.Insert(0, li1);
        }

    
    }

    /// <summary>
    /// Fillddls the room.
    /// </summary>
    protected void FillddlRoom()
    {
        DataSet ds = new DataSet();
        BL.CampManagement objCamp = new BL.CampManagement();
        ds = objCamp.CampRosterRoomGet(ddlCamp.SelectedValue,ddlBuilding.SelectedValue,ddlFloor.SelectedValue,ddlFlat.SelectedValue );
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlRoom.DataSource = ds;
            ddlRoom.DataTextField = "RoomNo";
            ddlRoom.DataValueField = "RoomNo";
            ddlRoom.DataBind();

            ListItem li2 = new ListItem();
            li2.Text = Resources.Resource.Select;
            li2.Value = "0";
            ddlRoom.Items.Insert(0, li2);
            ddlRoom.SelectedIndex = 0;

        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoData;
            li1.Value = "0";
            ddlRoom.Items.Insert(0, li1);
        }

    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlCamp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlCamp_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCamp.SelectedValue == "0")
        {

        }
        else
        {
            FillddlBuilding();
        }

    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlBuilding control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBuilding_OnSelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlBuilding.SelectedValue == "0")
        {

        }
        else
        {
            FillddlFloor();
        }


    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlFloor control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlFloor_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFloor.SelectedValue == "0")
        {

        }
        else
        {
            FillddlFlat();
        }

    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlFlat control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlFlat_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFlat.SelectedValue == "0")
        {

        }
        else
        {
            FillddlRoom();
        }
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlRoom control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlRoom_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRoom.SelectedValue == "0")
        {

        }
        else
        {
            FillgvBedRoster();
        }


    }
    #endregion

    #region Functions related to gvBedRoster

    /// <summary>
    /// Handles the onTextChanged event of the txtGvFtrEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtGvFtrEmployeeNumber_onTextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        Label lblFtrEmpName = (Label)gvBedRoster.FooterRow.FindControl("lblgvftrEmpName");
        Label lblFtrEmpNationality = (Label)gvBedRoster.FooterRow.FindControl("lblgvftrEmpNationlity");
        TextBox txtEmployeeNumber = (TextBox)gvBedRoster.FooterRow.FindControl("txtGvFtrEmployeeNumber");
        
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeNumber.Text.ToString(), BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            lblFtrEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            //lblFtrEmpNationality.Text = ds.Tables[0].Rows[0]["Nationlity"].ToString();
        }
        else
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.InvalidEmpCode);
            txtEmployeeNumber.Text = "";
            ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
        }

    }
    /// <summary>
    /// Fillgvs the bed roster.
    /// </summary>
    protected void FillgvBedRoster()
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;

        ds = objCamp.CampRosterBedDetailsGet(BaseCompanyCode, ddlCamp.SelectedValue, ddlBuilding.SelectedValue, ddlFloor.SelectedValue, ddlFlat.SelectedValue, ddlRoom.SelectedValue);           
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        gvBedRoster.DataKeyNames = new string[] { "BedNo" };
        gvBedRoster.DataSource = dt;
        gvBedRoster.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {

            gvBedRoster.Rows[0].Visible = false;
        }
        FillddlBed();
    }

    /// <summary>
    /// Fillddls the bed.
    /// </summary>
    protected void FillddlBed()
    {
        DropDownList ddlgvBedNo = (DropDownList)gvBedRoster.FooterRow.FindControl("ddlgvBedNo");   
        DataSet ds = new DataSet();
        BL.CampManagement objCamp = new BL.CampManagement();
        ds = objCamp.CampRosterBedGet(ddlCamp.SelectedValue, ddlBuilding.SelectedValue, ddlFloor.SelectedValue, ddlFlat.SelectedValue,ddlRoom.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlgvBedNo.DataSource = ds;
            ddlgvBedNo.DataTextField = "BedNo";
            ddlgvBedNo.DataValueField = "BedAutoID";
            ddlgvBedNo.DataBind();

            ListItem li2 = new ListItem();
            li2.Text = Resources.Resource.Select;
            li2.Value = "0";
            ddlgvBedNo.Items.Insert(0, li2);
            ddlgvBedNo.SelectedIndex = 0;

        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoData;
            li1.Value = "0";
            ddlgvBedNo.Items.Insert(0, li1);
        }

    
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvBedRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvBedRoster_RowDataBound(object sender, GridViewRowEventArgs e)
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
                int serialNo = gvBedRoster.PageIndex * gvBedRoster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvBedRoster.Columns[6].Visible = false;
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

                gvBedRoster.ShowFooter = false;
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
    /// Handles the RowCommand event of the gvBedRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvBedRoster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        DropDownList ddlgvBedNo = (DropDownList)gvBedRoster.FooterRow.FindControl("ddlgvBedNo");
        TextBox txtGvFtrEmployeeNumber = (TextBox)gvBedRoster.FooterRow.FindControl("txtGvFtrEmployeeNumber");
        TextBox txtftrBedFromDate = (TextBox)gvBedRoster.FooterRow.FindControl("txtftrBedFromDate");
        Label lblgvftrEmpNationlity = (Label)gvBedRoster.FooterRow.FindControl("lblgvftrEmpNationlity");
        Label lblgvftrEmpName = (Label)gvBedRoster.FooterRow.FindControl("lblgvftrEmpName");   
        if (e.CommandName.Equals("AddNew"))
        {
            if (ddlgvBedNo.SelectedValue != "0")
            {
                ds = objCamp.CampRosterBedDetailsInsert(ddlgvBedNo.SelectedValue, txtGvFtrEmployeeNumber.Text, txtftrBedFromDate.Text, "", "A", BaseUserID);
                if (gvBedRoster.Rows.Count.Equals(gvBedRoster.PageSize))
                {
                    gvBedRoster.PageIndex = gvBedRoster.PageCount + 1;
                }
                gvBedRoster.EditIndex = -1;
                FillgvBedRoster();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                DisplayMessageString(lblErrorMsg, "Please Select Bed First!");  
            }

        }
        else if (e.CommandName.Equals("Reset"))
        {
            ddlgvBedNo.SelectedIndex = 0;
            txtGvFtrEmployeeNumber.Text = "";
            txtftrBedFromDate.Text = "";
            lblgvftrEmpNationlity.Text = "";
            lblgvftrEmpName.Text = "";
        }

    }

    /// <summary>
    /// Handles the RowEditing event of the gvBedRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvBedRoster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBedRoster.EditIndex = e.NewEditIndex;
        FillgvBedRoster();

    }

    /// <summary>
    /// Handles the RowUpdating event of the gvBedRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvBedRoster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        BL.CampManagement objCamp = new BL.CampManagement();
        DataSet ds = new DataSet();
        HiddenField hfBedAutoID = (HiddenField)gvBedRoster.Rows[e.RowIndex].FindControl("hfBedAutoID");
        Label lblEditgvEmployeeNumber = (Label)gvBedRoster.Rows[e.RowIndex].FindControl("lblEditgvEmployeeNumber");
        Label lblEditBedFromDate = (Label)gvBedRoster.Rows[e.RowIndex].FindControl("lblEditBedFromDate");  
        TextBox txtEditBedToDate = (TextBox)gvBedRoster.Rows[e.RowIndex].FindControl("txtEditBedToDate");
        if (txtEditBedToDate.Text == "")
        {
            ds = objCamp.CampRosterBedDetailsInsert(hfBedAutoID.Value, lblEditgvEmployeeNumber.Text, lblEditBedFromDate.Text, "", "M", BaseUserID);
        }
        else
        {
            if (DateTime.Parse(txtEditBedToDate.Text) >= DateTime.Parse(lblEditBedFromDate.Text))
            {
                ds = objCamp.CampRosterBedDetailsInsert(hfBedAutoID.Value, lblEditgvEmployeeNumber.Text, lblEditBedFromDate.Text, txtEditBedToDate.Text, "M", BaseUserID);
                gvBedRoster.EditIndex = -1;
                FillgvBedRoster();
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }
            else
            {
                DisplayMessageString(lblErrorMsg,Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate ); 
                //"EffectiveToDate Should be greater or equal to EffectiveFromDate!");              
            }
        }
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvBedRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvBedRoster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBedRoster.EditIndex = -1;
        FillgvBedRoster(); 

    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvBedRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvBedRoster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBedRoster.PageIndex = e.NewPageIndex;
        gvBedRoster.EditIndex = -1;
        FillgvBedRoster(); 

    }

    #endregion
}
