// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="UserEventMapping.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_UserEventMapping.
/// </summary>
public partial class Transactions_UserEventMapping : BasePage
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
    /// The index
    /// </summary>
    static int Index;
    #region Page Functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.Country;
            //}
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.UserEventMapping + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                FillddlUser();
                FillgvUserEventMapping();
                ddlModuleName(); //Fills the Dropdown "ddlgvModuleName" for Modules
                ddlEventDescription();
                chklstbox();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Function Related To UserName DDL
    /// <summary>
    /// Fillddls the user.
    /// </summary>
    private void FillddlUser()
    {
        if (!IsPostBack)
        {
            BL.MastersManagement objMasterManagement = new BL.MastersManagement();
            DataSet dsddlUser = new DataSet();
            DataTable dtddlUser = new DataTable();

            dsddlUser = objMasterManagement.UserGet();

            if (dsddlUser != null && dsddlUser.Tables.Count > 0 && dsddlUser.Tables[0].Rows.Count > 0)
            {
                ddlUser.DataSource = dsddlUser;
                ddlUser.DataValueField = "UserID";
                ddlUser.DataTextField = "UserName";
                ddlUser.DataBind();
            }
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlUser control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
               FillgvUserEventMapping();
    }

    #endregion


    #region Functions Related to Gridview

    /// <summary>
    /// Fillgvs the user event mapping.
    /// </summary>
    private void FillgvUserEventMapping()
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet dsEventMapping = new DataSet();
        DataTable dtEventMapping = new DataTable();

        string UserName;

        UserName = ddlUser.SelectedItem.Value;



        //dsEventMapping = objMasterManagement.bl_EventMapping_GetGrid(UserName);
        dsEventMapping = objMasterManagement.EventMappingGetAll(UserName);
        if (dsEventMapping != null && dsEventMapping.Tables.Count > 0 && dsEventMapping.Tables[0].Rows.Count > 0)
        {
            //DropDownList ddlgvEventSubscriber = (DropDownList)gvUserEventMapping.FindControl("ddlgvEventSubscriber");
            //ddlgvEventSubscriber.DataSource = dsEventMapping;//.Tables[0].Columns[3];
            //ddlgvEventSubscriber.DataTextField = "Subscribers";
            //ddlgvEventSubscriber.DataValueField = "Subscribers";
            //  ddlgvEventSubscriber.DataBind();

            //        PopulateDropDownList();
            gvUserEventMapping.DataSource = dsEventMapping.Tables[0];
            gvUserEventMapping.DataBind();

        }
        else
        {
            dtEventMapping = dsEventMapping.Tables[0];
            dtEventMapping.Rows.Add(dtEventMapping.NewRow());
            gvUserEventMapping.DataSource = dtEventMapping;
            gvUserEventMapping.DataBind();
            gvUserEventMapping.Rows[0].Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the gvUserEventMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void gvUserEventMapping_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the RowEditing event of the gvUserEventMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvUserEventMapping_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvUserEventMapping.EditIndex = e.NewEditIndex;
        FillgvUserEventMapping();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvUserEventMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvUserEventMapping_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       // Label lblgvEventDesc = (Label)gvUserEventMapping.Rows[e.RowIndex].FindControl("lblgvEventDesc");
        HiddenField hdnEventName = (HiddenField)gvUserEventMapping.Rows[e.RowIndex].FindControl("hdnEventName");
        Label lblgvModuleName = (Label)gvUserEventMapping.Rows[e.RowIndex].FindControl("lblgvModuleName");
        CheckBoxList chlgvEventSubscriber = (CheckBoxList)gvUserEventMapping.Rows[e.RowIndex].FindControl("chlgvEventSubscriber");
        CheckBox chkIsActive = (CheckBox)gvUserEventMapping.Rows[e.RowIndex].FindControl("chkIsActive");
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.EventMappingDelete(ddlUser.SelectedValue.ToString(), hdnEventName.Value, lblgvModuleName.Text);

        BL.MastersManagement objSaveData = new BL.MastersManagement();
        DataSet dsSaveData = new DataSet();

        foreach (ListItem li in chlgvEventSubscriber.Items)

        //for (int i = 0; i <= chlgvNewEventSubscriber.Items.Count - 1; i++)
        {
            if (li.Selected)
            {
                dsSaveData = objSaveData.SaveData(ddlUser.SelectedValue.ToString(), lblgvModuleName.Text.ToString(), ddlgvNewEventName.SelectedValue.ToString(), bool.Parse(chkIsActive.Checked.ToString()), li.Value,txtNewSubEmailID.Text.Trim() , BaseUserID);
            }
        }

        gvUserEventMapping.EditIndex = -1;

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvUserEventMapping();
        }

        FillgvUserEventMapping();

    }


    /// <summary>
    /// Handles the RowCommand event of the gvUserEventMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvUserEventMapping_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //if (e.CommandName == "Add New")
        //{
        //    string strUserId, strddlUser, strEventCode, strEventDesc;
        //    DataSet ds = new DataSet();
        //    BL.MastersManagement objMasterManagement = new BL.MastersManagement();

        //    TextBox txtEventCode = (TextBox)gvUserEventMapping.FooterRow.FindControl("txtEventCode");
        //    TextBox txtNewEventDesc = (TextBox)gvUserEventMapping.FooterRow.FindControl("txtNewEventDesc");
        //    CheckBox chkActive = (CheckBox)gvUserEventMapping.FooterRow.FindControl("chkIsActive");

        //    strUserId = BaseUserID;
        //    strddlUser = ddlUser.SelectedItem.Text;
        //    strEventCode = txtEventCode.Text.ToString();
        //    strEventDesc = txtNewEventDesc.Text.ToString();
        //    ds = objMasterManagement.blEventMaster_Add(strddlUser, strEventCode, strEventDesc, bool.Parse(chkActive.Checked.ToString()), BaseUserID);
        //    FillgvUserEventMapping();

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        //    }
        //}
        //switch (e.CommandArgument.ToString())
        //{
        //    case "First":
        //        gvUserEventMapping.PageIndex = 0;
        //        break;
        //    case "Prev":
        //        Index = 1;
        //        break;
        //    case "Next":
        //        Index = 0;
        //        break;
        //    case "Last":
        //        gvUserEventMapping.PageIndex = gvUserEventMapping.PageCount;
        //        break;
        //}

    }
    /// <summary>
    /// Handles the RowDeleting event of the gvUserEventMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvUserEventMapping_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label lblgvEventDesc = (Label)gvUserEventMapping.Rows[e.RowIndex].FindControl("lblgvEventDesc");
        Label lblgvModuleName = (Label)gvUserEventMapping.Rows[e.RowIndex].FindControl("lblgvModuleName");
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.EventMappingDelete(ddlUser.SelectedValue.ToString(), lblgvEventDesc.Text, lblgvModuleName.Text);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvUserEventMapping();
        }
        FillgvUserEventMapping();
    }
    
    #endregion


    /// <summary>
    /// Handles the PageIndexChanging event of the gvUserEventMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvUserEventMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRow gvrPager = gvUserEventMapping.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        int CurrentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
        if (Index == 1)
        {
            if (CurrentIndex > 0)
            {
                gvUserEventMapping.PageIndex = CurrentIndex - 1;
            }
            else
            {
                gvUserEventMapping.PageIndex = CurrentIndex;
            }
            Index = -1;
        }
        else if (Index == 0)
        {
            gvUserEventMapping.PageIndex = CurrentIndex + 1;
            Index = -1;
        }
        else
        {
            gvUserEventMapping.PageIndex = e.NewPageIndex;
        }
        gvUserEventMapping.EditIndex = -1;
        FillgvUserEventMapping();
    }



    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvUserEventMapping.BottomPagerRow;
        DropDownList ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvUserEventMapping.PageIndex = ddlPages.SelectedIndex;
        FillgvUserEventMapping();
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {

        //TextBox txtEventCode = (TextBox)gvUserEventMapping.FooterRow.FindControl("txtEventCode");
        //TextBox txtNewEventDesc = (TextBox)gvUserEventMapping.FooterRow.FindControl("txtNewEventDesc");

        chkIsActive.Checked = false;
        chlgvNewEventSubscriber.ClearSelection();
        txtNewSubEmailID.Text = "";

    }
    /// <summary>
    /// Handles the Click event of the lnkBtnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkBtnCancel_Click(object sender, EventArgs e)
    {
        gvUserEventMapping.EditIndex = -1;
        FillgvUserEventMapping();
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvUserEventMapping control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvUserEventMapping_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /**** Code for Populating DropDown in Grid at View ****/
        
        DataTable myTable = new DataTable();
        DataColumn SubscriberIDColumn = new DataColumn("Subscribers");
        myTable.Columns.Add(SubscriberIDColumn);
        DataColumn SubEmailID = new DataColumn("SubEmailID");
        myTable.Columns.Add(SubEmailID);

        DataSet ds = new DataSet();

        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet dsEventMapping = new DataSet();
        DataTable dtEventMapping = new DataTable();

        string UserName; string expression = String.Empty;

        UserName = ddlUser.SelectedItem.Value;
        
        ds = objMasterManagement.EventMappingGet(UserName);

        string ModuleCode, EventCode;

        string strSubEmailID = string.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblgvEventDesc = (Label)e.Row.FindControl("lblgvEventDesc");

            if (lblgvEventDesc != null)
            {
                //ModuleCode = e.Row.Cells[0].Text;
                EventCode = lblgvEventDesc.Text;//e.Row.Cells[0].Text;
                //EventCode = "EventDescription";
                expression = "EventDescription ='" + (EventCode.ToString()) + "'";
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlgvEventSubscriber");
                Label lblgvEventSubEmailID = (Label)e.Row.FindControl("lblgvEventSubEmailID");
                DataRow[] rows = ds.Tables[0].Select(expression);

                foreach (DataRow row in rows)
                {
                    DataRow newRow = myTable.NewRow();
                    newRow["Subscribers"] = row["Subscribers"];
                    newRow["SubEmailID"] = row["SubEmailID"];
                    
                    myTable.Rows.Add(newRow);
                    
                }

                foreach (DataRow dr in ds.Tables[0].Select(expression))
                {
                    if (strSubEmailID == "")
                    {
                        if (dr.ItemArray[4].ToString() != "")
                        {
                            strSubEmailID = dr.ItemArray[4].ToString() + ";";
                        }
                    }
                    else
                    {
                        strSubEmailID = strSubEmailID + dr.ItemArray[4].ToString() + ";";
                    }
                }

                
                lblgvEventSubEmailID.Text = strSubEmailID;

                ddl.DataSource = myTable;

                ddl.DataTextField = "Subscribers";

                ddl.DataValueField = "Subscribers";

                ddl.DataBind();


            }
            else
            {
                DropDownList ddlgvEventName = (DropDownList)e.Row.FindControl("ddlgvEventName");
                Label lblgvModuleName = (Label)e.Row.FindControl("lblgvModuleName");
                HiddenField hdnEventName = (HiddenField)e.Row.FindControl("hdnEventName");
                DataTable myTableddlgvEventName = new DataTable();
                DataColumn EventDescription = new DataColumn("EventDescription");
                hdnEventName.Value.ToString();
                
                myTableddlgvEventName.Columns.Add(EventDescription);
                DataColumn EventCodeddlgvEventName = new DataColumn("EventCode");
                myTableddlgvEventName.Columns.Add(EventCodeddlgvEventName);

                BL.MastersManagement objDdlEventDesc = new BL.MastersManagement();
                DataSet dsddlEventDesc = new DataSet();
                string expmodulecode = string.Empty;


                expmodulecode = "ModuleCode ='" + (lblgvModuleName.Text.ToString()) + "'";
                //        expression = "EventDescription ='" + (EventCode.ToString()) + "'";
                dsddlEventDesc = objDdlEventDesc.EventMappingDescriptionGet();



                if (dsddlEventDesc.Tables[0].Rows.Count > 0)
                {
                    DataRow[] rows = dsddlEventDesc.Tables[0].Select(expmodulecode); ;

                    foreach (DataRow row in rows)
                    {
                        DataRow newRow = myTableddlgvEventName.NewRow();

                        newRow["EventDescription"] = row["EventDescription"];
                        newRow["EventCode"] = row["EventCode"];

                        myTableddlgvEventName.Rows.Add(newRow);
                    }


                    ddlgvEventName.DataSource = myTableddlgvEventName;
                    ddlgvEventName.DataTextField = "EventDescription";
                    ddlgvEventName.DataValueField = "EventCode";
                    
                    ddlgvEventName.DataBind();
                    ddlgvEventName.SelectedValue=hdnEventName.Value;

                    //ddlgvEventName.DataBind();
                }

                /************Load CheckList Box in Edit Mode "chlgvEventSubscriber" **********/
                CheckBoxList chlgvEventSubscriber = (CheckBoxList)e.Row.FindControl("chlgvEventSubscriber");

                BL.MastersManagement objDllMaster = new BL.MastersManagement();
              //  DataSet dsddlMaster = new DataSet();
                DataSet dschk = new DataSet();

               // dsddlMaster = objDllMaster.bl_EventMapping_GetSubscriber_DDL();
                dschk = objDllMaster.EventMappingSubscriberGet(ddlUser.Text.ToString(), lblgvModuleName.Text.ToString(), hdnEventName.Value.ToString());


                if (dschk.Tables[0].Rows.Count > 0)
                {
                    //chlgvEventSubscriber.DataSource = dsddlMaster.Tables[0];
                    //chlgvEventSubscriber.DataTextField = "UserName";
                    //chlgvEventSubscriber.DataValueField = "EmailID";
                    
                    //chlgvEventSubscriber.DataBind();
                    Boolean status;
                    foreach (DataRow dr in dschk.Tables[0].Rows)
                    {
                        ListItem item = new ListItem(Convert.ToString(dr["UserID"]),Convert.ToString(dr["EmailID"]));
                        //item.Selected.Equals((bool)dr["Status"]);
                        status = Convert.ToBoolean(dr["Status"]);
                        item.Selected = status;
                        chlgvEventSubscriber.Items.Add(item);

                    }
                }
                /************end of code to Load CheckList Box in Edit Mode "chlgvEventSubscriber" **********/
                
            }
            //ddlgvEventName
        }
        /**** Code for Populating DropDown in Grid at View ****/

        /**** Code for populating drilldown of Footer Subscriber ********/
        

        /******************************************************************/

        //dsEventMapping.Clear();

        //BL.MastersManagement objDllMaster = new BL.MastersManagement();
        //DataSet dsddlMaster = new DataSet();

        //dsddlMaster = objDllMaster.bl_EventMapping_GetSubscriber_DDL();

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    CheckBoxList chklist = (CheckBoxList)e.Row.FindControl("chlgvNewEventSubscriber");
        //    if (dsddlMaster.Tables[0].Rows.Count > 0)
        //    {
        //        chklist.DataSource = dsddlMaster.Tables[0];
        //        chklist.DataTextField = "UserName";
        //        chklist.DataValueField = "EmailID";
        //        chklist.DataBind();

        //    }
        //}
        ///**** Code for populating drilldown of Footer Subscriber ********/

        /* code commented by Manish  on 15th June 2010 as structure of the screen was changed***/
        ///**** Code for Populating Modules in Footer *********/
        //BL.MastersManagement objDdlModuleMaster = new BL.MastersManagement();
        //DataSet dsddlModuleMaster = new DataSet();

        //dsddlModuleMaster = objDdlModuleMaster.bl_EventMapping_GetModule(ddlUser.SelectedItem.Text);

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    DropDownList ddlModuleName = (DropDownList)e.Row.FindControl("ddlgvModuleName");
        //    if (dsddlModuleMaster.Tables[0].Rows.Count > 0)
        //    {
        //        ddlModuleName.DataSource = dsddlModuleMaster.Tables[0];
        //        ddlModuleName.DataTextField = "MenuHeadName";
        //        ddlModuleName.DataValueField = "MenuHeadCode";
        //        ddlModuleName.DataBind();

        //    }
        //}
        ///****End of Code for Populating Modules in Footer *********/

        ///****Code for Populating EventDescription in Footer *********/
        ////ddlgvEventName

        //BL.MastersManagement objDdlEventDesc = new BL.MastersManagement();
        //DataSet dsddlEventDesc = new DataSet();
        //string expmodulecode = string.Empty;

        
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    DropDownList ddlModule = (DropDownList)e.Row.FindControl("ddlgvModuleName");

        //    expmodulecode = "ModuleCode ='" + ddlModule.SelectedValue + "'";

        //    dsddlEventDesc = objDdlEventDesc.bl_EventMapping_GetEventDesc();

        //    DropDownList ddlgvEventName = (DropDownList)e.Row.FindControl("ddlgvNewEventName");

        //    if (dsddlEventDesc.Tables[0].Rows.Count > 0)
        //    {
        //        ddlgvEventName.DataSource = dsddlEventDesc.Tables[0];
        //        ddlgvEventName.DataTextField = "EventDescription";
        //        ddlgvEventName.DataValueField = "EventCode";

        //        ddlgvEventName.DataBind();

        //    }
        //}

        ///****End of Code for EventDescription Modules in Footer *********/

        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvUserEventMapping.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

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
            TextBox txtEventDesc = (TextBox)e.Row.FindControl("txtEventDesc");
            if (txtEventDesc != null)
            {
                txtEventDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtEventDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
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
                    ImgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvUserEventMapping.ShowFooter = false;
            }
            else
            {
                ImageButton ImgbtnAdd = (ImageButton)e.Row.FindControl("ImgbtnAdd");
                if (ImgbtnAdd != null)
                {
                    ImgbtnAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                TextBox txtEventCode = (TextBox)e.Row.FindControl("txtEventCode");
                if (txtEventCode != null)
                {
                    txtEventCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtEventCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewEventDesc = (TextBox)e.Row.FindControl("txtNewEventDesc");
                if (txtNewEventDesc != null)
                {
                    txtNewEventDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewEventDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlgvModuleName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlgvModuleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEventDescription();
    }

    /// <summary>
    /// DDLs the name of the module.
    /// </summary>
    private void ddlModuleName()
    {
        BL.MastersManagement objDdlModuleMaster = new BL.MastersManagement();
        DataSet dsddlModuleMaster = new DataSet();

        dsddlModuleMaster = objDdlModuleMaster.EventModuleMappingGet(ddlUser.SelectedItem.Text);
        if (dsddlModuleMaster.Tables[0].Rows.Count > 0)
        {
            ddlgvModuleName.DataSource = dsddlModuleMaster.Tables[0];
            ddlgvModuleName.DataTextField = "MenuHeadName";
            ddlgvModuleName.DataValueField = "MenuHeadCode";
            ddlgvModuleName.DataBind();

        }
    }


    /// <summary>
    /// DDLs the event description.
    /// </summary>
    private void ddlEventDescription()
    {
        DataTable myTable = new DataTable();
        DataColumn EventDescription = new DataColumn("EventDescription");

        myTable.Columns.Add(EventDescription);
        DataColumn EventCode = new DataColumn("EventCode");
        myTable.Columns.Add(EventCode);

        BL.MastersManagement objDdlEventDesc = new BL.MastersManagement();
        DataSet dsddlEventDesc = new DataSet();
        string expmodulecode = string.Empty;

        expmodulecode = "ModuleCode ='" + (ddlgvModuleName.SelectedValue.ToString()) + "'";
//        expression = "EventDescription ='" + (EventCode.ToString()) + "'";
        dsddlEventDesc = objDdlEventDesc.EventMappingDescriptionGet();

        

        if (dsddlEventDesc.Tables[0].Rows.Count > 0)
        {
            DataRow[] rows = dsddlEventDesc.Tables[0].Select(expmodulecode); ;

            foreach (DataRow row in rows)
            {
                DataRow newRow = myTable.NewRow();
                
                newRow["EventDescription"] = row["EventDescription"];
                newRow["EventCode"] = row["EventCode"];   
                
                myTable.Rows.Add(newRow);
            }


            ddlgvNewEventName.DataSource = myTable;
            ddlgvNewEventName.DataTextField = "EventDescription";
            ddlgvNewEventName.DataValueField = "EventCode";

            ddlgvNewEventName.DataBind();

        }
  
    }

    /// <summary>
    /// Chklstboxes this instance.
    /// </summary>
    private void chklstbox()
    {

        BL.MastersManagement objDllMaster = new BL.MastersManagement();
        DataSet dsddlMaster = new DataSet();

        dsddlMaster = objDllMaster.EventSubscribersGet();

        
           
            if (dsddlMaster.Tables[0].Rows.Count > 0)
            {
                chlgvNewEventSubscriber.DataSource = dsddlMaster.Tables[0];
                chlgvNewEventSubscriber.DataTextField = "UserName";
                chlgvNewEventSubscriber.DataValueField = "EmailID";
                chlgvNewEventSubscriber.DataBind();

            }
        
    }

    /// <summary>
    /// Saves the data.
    /// </summary>
    private void SaveData()
    {//txtNewSubEmailID.Text.ToString()
        BL.MastersManagement objSaveData = new BL.MastersManagement();
        DataSet dsSaveData = new DataSet();

        foreach(ListItem li in chlgvNewEventSubscriber.Items)

        //for (int i = 0; i <= chlgvNewEventSubscriber.Items.Count - 1; i++)
        {
            if (li.Selected)
            {
                dsSaveData = objSaveData.SaveData(ddlUser.SelectedValue.ToString(), ddlgvModuleName.SelectedValue.ToString(), ddlgvNewEventName.SelectedValue.ToString(), bool.Parse(chkIsActive.Checked.ToString()), li.Value,txtNewSubEmailID.Text.Trim(), BaseUserID);
                //if (txtNewSubEmailID.Text.Length > 0)
                
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the ImgbtnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        SaveData();
        chkIsActive.Checked = false;
        chlgvNewEventSubscriber.ClearSelection();
        txtNewSubEmailID.Text = "";
        FillgvUserEventMapping();
    }
}
