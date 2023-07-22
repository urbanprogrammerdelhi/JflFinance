// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="AreaMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Sales_AreaMaster.
/// </summary>
public partial class Sales_AreaMaster : BasePage//System.Web.UI.Page
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
    #region Page Load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.AreaMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillgvAreaMaster();
                //FillgvAreaIncharge();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    /// <summary>
    /// Fillgvs the area master.
    /// </summary>
    private void FillgvAreaMaster()
    {
        BL.OperationManagement OperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = OperationManagement.AreaMasterGetAll(BaseLocationAutoID);
        dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvAreaMaster.DataSource = dt;
        gvAreaMaster.DataBind();

        if (dtflag == 0)//to fix empty gridview
        {
            gvAreaMaster.Rows[0].Visible = false;
        }
    }
    #endregion
    /// <summary>
    /// Handles the RowDataBound event of the gvAreaMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAreaMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAreaMaster.PageIndex * gvAreaMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvAreaMaster.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            if (IsModifyAccess == false)
            {
                ImageButton IBEditAreaMaster = (ImageButton)e.Row.FindControl("IBEditAreaMaster");
                if (IBEditAreaMaster != null)
                {
                    IBEditAreaMaster.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdateAreaMaster = (ImageButton)e.Row.FindControl("ImgbtnUpdateAreaMaster");
                if (ImgbtnUpdateAreaMaster != null)
                {
                    ImgbtnUpdateAreaMaster.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

                }
                TextBox txtAreaDesc = (TextBox)e.Row.FindControl("txtAreaDesc");
                if (txtAreaDesc != null)
                {
                    txtAreaDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtAreaDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteAreaMaster = (ImageButton)e.Row.FindControl("IBDeleteAreaMaster");
                if (IBDeleteAreaMaster != null)
                {
                    IBDeleteAreaMaster.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteAreaMaster = (ImageButton)e.Row.FindControl("IBDeleteAreaMaster");
                if (IBDeleteAreaMaster != null)
                {
                    IBDeleteAreaMaster.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvAreaMaster.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                TextBox txtNewAreaID = (TextBox)e.Row.FindControl("txtNewAreaID");
                if (txtNewAreaID != null)
                {
                    txtNewAreaID.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    txtNewAreaID.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }
                TextBox txtNewAreaDesc = (TextBox)e.Row.FindControl("txtNewAreaDesc");
                if (txtNewAreaDesc != null)
                {
                    txtNewAreaDesc.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    txtNewAreaDesc.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }

    }

    /// <summary>
    /// Handles the RowCommand event of the gvAreaMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAreaMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        TextBox txtNewAreaID = (TextBox)gvAreaMaster.FooterRow.FindControl("txtNewAreaID");
        TextBox txtNewAreaDesc = (TextBox)gvAreaMaster.FooterRow.FindControl("txtNewAreaDesc");
        if (e.CommandName.Equals("AddNew"))
        {
            ds = objOperationManagement.AreaMasterInsert(BaseLocationAutoID, txtNewAreaID.Text, txtNewAreaDesc.Text, BaseUserID);
            if (gvAreaMaster.Rows.Count.Equals(gvAreaMaster.PageSize))
            {
                gvAreaMaster.PageIndex = gvAreaMaster.PageCount + 1;
            }
            gvAreaMaster.EditIndex = -1;
            FillgvAreaMaster();
            // FillgvAreaIncharge();
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewAreaID.Text = "";
            txtNewAreaDesc.Text = "";
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvAreaMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvAreaMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAreaMaster.EditIndex = e.NewEditIndex;
        FillgvAreaMaster();

    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvAreaMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvAreaMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAreaMaster.EditIndex = -1;
        FillgvAreaMaster();

    }
    /// <summary>
    /// Handles the RowUpdating event of the gvAreaMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvAreaMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        LinkButton lblAreaID = (LinkButton)gvAreaMaster.Rows[e.RowIndex].FindControl("lblAreaID");
        TextBox txtAreaDesc = (TextBox)gvAreaMaster.Rows[e.RowIndex].FindControl("txtAreaDesc");
        ds = objOperationManagement.AreaMasterUpdate(BaseLocationAutoID, lblAreaID.Text, txtAreaDesc.Text, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        gvAreaMaster.EditIndex = -1;
        FillgvAreaMaster();
        //FillgvAreaIncharge();

    }
    /// <summary>
    /// Handles the RowDeleting event of the gvAreaMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAreaMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.AreaMasterDelete(BaseLocationAutoID, gvAreaMaster.DataKeys[e.RowIndex].Value.ToString());
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        FillgvAreaMaster();
        //  FillgvAreaIncharge();

    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvAreaMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAreaMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAreaMaster.PageIndex = e.NewPageIndex;
        gvAreaMaster.EditIndex = -1;
        FillgvAreaMaster();

    }
    //private DataTable GetDataSet()
    //{
    //    DataTable ds = new DataTable();
    //    BL.Sales objSales = new BL.Sales();
    //    ds = objSales.blContractMaster_GetAll("cl00002", "").Tables[1];
    //    return ds;
    //}
    /// <summary>
    /// Fillgvs the area incharge.
    /// </summary>
    /// <param name="strAreaID">The string area identifier.</param>
    private void FillgvAreaIncharge(string strAreaID)
    {
        BL.OperationManagement OperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //try
        //{
        int dtflag;
        dtflag = 1;
        ds = OperationManagement.AreaInchargeGetAll(BaseLocationAutoID, strAreaID);
        dt = ds.Tables[0];
        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvAreaIncharge.DataSource = dt;
        gvAreaIncharge.DataBind();
        gvAreaIncharge.Columns[0].Visible = true;
        ViewState["AreaDates"] = dt;
        if (dtflag == 0)//to fix empty gridview
        {
            gvAreaIncharge.Rows[0].Visible = false;
        }
        //}
        //catch (Exception ex) { gvAreaIncharge.Columns[0].Visible = false; }
    }
    //Added by Manoj On 01/05/2013
    //Only Max Records should be Editable Task ID 305
    /// <summary>
    /// Determines whether [is minimum value] [the specified value].
    /// </summary>
    /// <param name="val">The value.</param>
    /// <param name="areaIncharge">The area incharge.</param>
    /// <returns><c>true</c> if [is minimum value] [the specified value]; otherwise, <c>false</c>.</returns>
    private bool IsMinValue(int val, string areaIncharge)
    {
        bool result = false;
        DataTable dt = (DataTable)gvAreaIncharge.DataSource;
        if (dt != null && dt.Rows.Count > 1)
        {
            int maxVal = Convert.ToInt32(dt.Compute("max(AreaInchargeAutoId)", "AreaIncharge='" + areaIncharge.Trim() + "'"));

            if (maxVal > val)
                result = true;
        }
        return result;
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvAreaIncharge control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAreaIncharge_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");


        if (lblSerialNo != null)
        {
            int serialNo = gvAreaIncharge.PageIndex * gvAreaIncharge.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvAreaIncharge.Columns[0].Visible = false;
        }

        if (DataControlRowState.Edit == e.Row.RowState)
        {
            //ImageButton imgAISearch = (ImageButton)e.Row.FindControl("imgAISearch");
            //TextBox txtNewAreaIncharge = (TextBox)e.Row.FindControl("txtNewAreaIncharge");
            //imgAISearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtNewAreaIncharge.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
            TextBox txtEffectiveTo = (TextBox)e.Row.FindControl("txtEffectiveTo");
            txtEffectiveTo.Focus();

        }

        //    /*Code modified by Manish  on 6-Sep-2011*/
        //    DropDownList ddlNewFutureIncharge = (DropDownList)e.Row.Cells[8].FindControl("ddlNewFutureIncharge");
        //    BL.OperationManagement objFutureIncharge = new BL.OperationManagement();
        //    DataSet dsFutureIncharge = new DataSet();
        //    dsFutureIncharge = objFutureIncharge.blFutureIncharge(BaseLocationAutoID);
        //    ddlNewFutureIncharge.DataSource = dsFutureIncharge;
        //    ddlNewFutureIncharge.DataTextField = "EmployeeName";
        //    ddlNewFutureIncharge.DataValueField = "EmployeeNumber";
        //    ddlNewFutureIncharge.DataBind();
        //    /*End of Code modified by Manish  on 6-Sep-2011*/


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            //Added by Manoj On 01/05/2013
            //Only Max Records should be Editable Task ID 305
            HiddenField hfAreaInchargeAutoID = (HiddenField)e.Row.FindControl("hfAreaInchargeAutoID");
            Label lblEmployeeNumber = (Label)e.Row.FindControl("lblEmployeeNumber");

            if (hfAreaInchargeAutoID != null)
            {
                try
                {
                    if (IsMinValue(int.Parse(hfAreaInchargeAutoID.Value), lblEmployeeNumber.Text))
                    {
                        ImageButton IBEditAreaIncharge = (ImageButton)e.Row.FindControl("IBEditAreaIncharge");
                        if (IBEditAreaIncharge != null)
                        {
                            IBEditAreaIncharge.Visible = false;
                        }
                    }
                }
                catch (Exception) { }
            }
            //End Added by Manoj
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();

            if (IsWriteAccess == false)
            {
                gvAreaIncharge.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                Label lblNewAreaID = (Label)e.Row.FindControl("lblNewAreaID");
                Label lblNewAreaDesc = (Label)e.Row.FindControl("lblNewAreaDesc");
                ImageButton imgSearch = (ImageButton)e.Row.FindControl("imgSearch");
                TextBox txtNewEmployeeNumber = (TextBox)e.Row.FindControl("txtNewEmployeeNumber");
                // imgSearch.Attributes.Add("OnClick", "javascript:OpenSearch('" + txtNewEmployeeNumber.ClientID.ToString() + "')");
                imgSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtNewEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                string handler = ClientScript.GetPostBackEventReference(this.btnPostBack, "");
                txtNewEmployeeNumber.Attributes.Add("onblur", handler);
                lblNewAreaID.Text = hfAreaID.Value;
                //ddlNewAreaID.DataSource = objOperationManagement.blAreaID_Get(BaseLocationAutoID);
                //ddlNewAreaID.DataTextField = "AreaID";
                //ddlNewAreaID.DataValueField = "AreaID";
                //ddlNewAreaID.DataBind();
                //if (ddlNewAreaID.Text == "")
                //{
                //    ListItem li = new ListItem();
                //    li.Text = Resources.Resource.NoData;
                //    li.Value = "0";
                //    ddlNewAreaID.Items.Add(li);
                //    lbADD.Enabled = false;
                //}
                //else
                //{
                if (lblNewAreaID.Text != "")
                {
                    ds = objOperationManagement.AreaDescBasedOnAreaIdGet(lblNewAreaID.Text, BaseLocationAutoID);
                    lblNewAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                    lbADD.Enabled = true;
                }
                // }
                if (txtNewEmployeeNumber != null)
                {
                    txtNewEmployeeNumber.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    // txtNewEmployeeNumber.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowDeleting event of the gvAreaIncharge control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAreaIncharge_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblAreaID = (Label)gvAreaIncharge.Rows[e.RowIndex].FindControl("lblAreaID");
        Label lblEmployeeNumber = (Label)gvAreaIncharge.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.AreaInchargeDelete(lblAreaID.Text, lblEmployeeNumber.Text, BaseLocationAutoID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        FillgvAreaIncharge(lblAreaID.Text);

    }
    /// <summary>
    /// Handles the RowCommand event of the gvAreaIncharge control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAreaIncharge_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        Label lblNewAreaID = (Label)gvAreaIncharge.FooterRow.FindControl("lblNewAreaID");
        Label lblNewAreaDesc = (Label)gvAreaIncharge.FooterRow.FindControl("lblNewAreaDesc");
        TextBox txtNewEmployeeNumber = (TextBox)gvAreaIncharge.FooterRow.FindControl("txtNewEmployeeNumber");
        Label lblNewEmployeeName = (Label)gvAreaIncharge.FooterRow.FindControl("lblNewEmployeeName");
        TextBox txtEffectiveFrom = (TextBox)gvAreaIncharge.FooterRow.FindControl("txtEffectiveFrom");
        //Added by  on 6-Jun-2013
        HiddenField hdEmpDOJ = (HiddenField)gvAreaIncharge.FooterRow.FindControl("hdEmpDOJ");
        //End
        if (e.CommandName.Equals("AddNewAreaInch"))
        {
            if (lblNewAreaID.Text != "" && lblNewAreaDesc.Text != "" && lblNewEmployeeName.Text != "" && txtNewEmployeeNumber.Text != "")
            {
                if (Convert.ToDateTime(hdEmpDOJ.Value) < Convert.ToDateTime(txtEffectiveFrom.Text))         //Added by  on 6-Jun-2013
                {
                    ds = objOperationManagement.AreaInchargeInsert(lblNewAreaID.Text, txtNewEmployeeNumber.Text, BaseLocationAutoID, BaseUserID, txtEffectiveFrom.Text);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (gvAreaIncharge.Rows.Count.Equals(gvAreaIncharge.PageSize))
                    {
                        gvAreaIncharge.PageIndex = gvAreaIncharge.PageCount + 1;
                    }
                    gvAreaMaster.EditIndex = -1;
                    FillgvAreaIncharge(lblNewAreaID.Text);
                }
                else               //Added by  on 6-Jun-2013
                {
                    lblErrorMsg.Text = Resources.Resource.EffectiveDateGreaterDOJ;
                    txtEffectiveFrom.Text = "";
                    txtEffectiveFrom.Focus();
                }
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewEmployeeNumber.Text = "";
        }

    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvAreaIncharge control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAreaIncharge_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAreaIncharge.PageIndex = e.NewPageIndex;
        gvAreaIncharge.EditIndex = -1;
        FillgvAreaIncharge(hfAreaID.Value);
    }
    //protected void ddlNewAreaID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GridViewRow row = (GridViewRow)((sender) as Control).NamingContainer;
    //    DropDownList ddlNewAreaID = (DropDownList)sender;
    //    string ddlAreaIDSelectedValue = ddlNewAreaID.SelectedValue.ToString();
    //    Label lblNewAreaDesc = row.FindControl("lblNewAreaDesc") as Label;
    //    DataSet ds=new DataSet();
    //    BL.OperationManagement objOperationManagement =new BL.OperationManagement();
    //    ds = objOperationManagement.blAreaDescBasedOnAreaID_Get(ddlAreaIDSelectedValue, BaseLocationAutoID);
    //    lblNewAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();

    //}
    /// <summary>
    /// Handles the Click event of the btnPostBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnPostBack_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        Label lblNewEmployeeName = (Label)gvAreaIncharge.FooterRow.FindControl("lblNewEmployeeName");
        TextBox txtNewEmployeeNumber = (TextBox)gvAreaIncharge.FooterRow.FindControl("txtNewEmployeeNumber");
        ImageButton lbADD = (ImageButton)gvAreaIncharge.FooterRow.FindControl("lbADD");
        //Added by  on 6-Jun-2013
        HiddenField hdEmpDOJ = (HiddenField)gvAreaIncharge.FooterRow.FindControl("hdEmpDOJ");
        //End
        ds = objOperationManagement.EmployeeNameByIdGet(txtNewEmployeeNumber.Text);
        if (txtNewEmployeeNumber.Text != "")
        {
            try
            {
                lblNewEmployeeName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                //Added by  on 6-Jun-2013
                hdEmpDOJ.Value = ds.Tables[0].Rows[0]["DOJ"].ToString();
                //End
                lbADD.Enabled = true;
            }
            catch (Exception)
            {
                lblNewEmployeeName.Text = Resources.Resource.InvalidEmployee;
                lbADD.Enabled = false;
            }
        }
        else
        {
            lblNewEmployeeName.Text = "";
        }

    }

    /// <summary>
    /// Handles the Click event of the lblAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lblAreaID_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblAreaID = (LinkButton)gvAreaMaster.Rows[row.RowIndex].FindControl("lblAreaID");
        PanelAreaInch.Visible = true;
        hfAreaID.Value = lblAreaID.Text;
        try
        {
            gvAreaIncharge.EditIndex = -1;
        }
        catch (Exception ex) { }
        FillgvAreaIncharge(hfAreaID.Value);

    }
    /// <summary>
    /// Handles the TextChanged event of the txtNewEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewEmployeeNumber_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;

        TextBox txtNewEmployeeNumber = (TextBox)gvAreaIncharge.FooterRow.FindControl("txtNewEmployeeNumber");
        string handler = ClientScript.GetPostBackEventReference(this.btnPostBack, "");
        txtNewEmployeeNumber.Attributes.Add("onblur", handler);
    }

    //protected void txtNewAreaIncharge_TextChanged(object sender, EventArgs e)
    //{
    //    TextBox objTextBox = (TextBox)sender;
    //    GridViewRow row = (GridViewRow)objTextBox.NamingContainer;

    //    TextBox txtNewAreaIncharge = (TextBox)gvAreaIncharge.Rows[row.RowIndex].Cells[8].FindControl("txtNewAreaIncharge");
    //    DataSet ds = new DataSet();
    //    BL.OperationManagement objOperationManagement = new BL.OperationManagement();
    //    Label lblNewAreaInchargeName = (Label)gvAreaIncharge.Rows[row.RowIndex].Cells[9].FindControl("lblNewAreaInchargeName");
    //    ds = objOperationManagement.blEmployeeNameByID_Get(txtNewAreaIncharge.Text);
    //    if (txtNewAreaIncharge.Text != "")
    //    {
    //        try
    //        {
    //            lblNewAreaInchargeName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
    //        }
    //        catch (Exception)
    //        {
    //            lblNewAreaInchargeName.Text = Resources.Resource.InvalidEmployee;
    //        }
    //    }
    //    else
    //    {
    //        lblNewAreaInchargeName.Text = "";
    //    }
    //}

    /// <summary>
    /// Handles the RowEditing event of the gvAreaIncharge control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvAreaIncharge_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAreaIncharge.EditIndex = e.NewEditIndex;
        FillgvAreaIncharge(hfAreaID.Value.ToString());

    }
    //Added by Manoj On 01/05/2013
    //Effective From Date Can't be Less than Old Effective Dates Task ID 305
    /// <summary>
    /// Checks the date.
    /// </summary>
    /// <param name="dateValue">The date value.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="areaIncharge">The area incharge.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckDate(DateTime dateValue, string id, string areaIncharge)
    {
        bool result = false;
        DataTable dt = (DataTable)ViewState["AreaDates"];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["AreaInchargeAutoID"].ToString() == id)
            {
                dt.Rows[i].Delete();
                dt.AcceptChanges();
                break;
            }
        }

        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["EffectiveTo"].ToString()))
                {
                    if (dateValue <= DateTime.Parse(dr["EffectiveTo"].ToString()) && dr["AreaIncharge"].ToString() == areaIncharge)
                    {
                        result = true;
                        break;
                    }
                }
            }
        }
        return result;
    }
    /// <summary>
    /// Checks the row count.
    /// </summary>
    /// <returns>System.Int32.</returns>
    private int CheckRowCount()
    {
        int result = 0;
        DataTable dt = (DataTable)ViewState["AreaDates"];
        if (dt != null && dt.Rows.Count > 0)
        {
            result = dt.Rows.Count;
        }
        return result;
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvAreaIncharge control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvAreaIncharge_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ImageButton IBEditAreaIncharge = (ImageButton)gvAreaIncharge.Rows[e.RowIndex].FindControl("IBEditAreaIncharge");
        TextBox txtEffectiveTo = (TextBox)gvAreaIncharge.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        TextBox txtEffectiveFrom = (TextBox)gvAreaIncharge.Rows[e.RowIndex].FindControl("txtEffectiveFrom");
        Label lblAreaID = (Label)gvAreaIncharge.Rows[e.RowIndex].FindControl("lblAreaID");
        Label lblNewAreaInchargeName = (Label)gvAreaIncharge.Rows[e.RowIndex].FindControl("lblNewAreaInchargeName");
        Label lblEmployeeNumber = (Label)gvAreaIncharge.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        HiddenField hfAreaInchargeAutoID = (HiddenField)gvAreaIncharge.Rows[e.RowIndex].FindControl("hfAreaInchargeAutoID");
        //Added by Manoj On 01/05/2013
        //Effective From Date Can't be Less than Old Effective Dates Task ID 305

        if (!ConvertStringToDateFormat(txtEffectiveFrom, lblErrorMsg))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidateFromDate;
            txtEffectiveFrom.Text = "";
            txtEffectiveFrom.Focus();
            return;
        }

        DateTime EffectiveToDate = DateTime.Now.Date;
        if (string.IsNullOrEmpty(txtEffectiveTo.Text))
            EffectiveToDate = DateTime.Parse("31-Dec-90");
        else
        {
            if (!ConvertStringToDateFormat(txtEffectiveTo, lblErrorMsg))
            {
                lblErrorMsg.Text = Resources.Resource.InvalidToDate;
                txtEffectiveTo.Text = "";
                txtEffectiveTo.Focus();
                return;
            }
            else
                EffectiveToDate = DateTime.Parse((txtEffectiveTo.Text));
        }
        if (CheckDate(DateTime.Parse(txtEffectiveFrom.Text), hfAreaInchargeAutoID.Value, lblEmployeeNumber.Text))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidateFromDate;
            txtEffectiveFrom.Text = "";
            txtEffectiveFrom.Focus();
            return;
        }

        if (!string.IsNullOrEmpty(txtEffectiveTo.Text) && EffectiveToDate < (DateTime.Parse(txtEffectiveFrom.Text)))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidToDate;
            txtEffectiveTo.Text = "";
            txtEffectiveTo.Focus();
            return;
        }
        else
        {
            BL.OperationManagement objUpdateAI = new BL.OperationManagement();
            DataSet dsUpdateAI = new DataSet();
            //dsUpdateAI = objUpdateAI.blAreaIncharge_Update(lblAreaID.Text, lblEmployeeNumber.Text, BaseLocationAutoID, txtNewAreaIncharge.Text, lblEffectiveFrom.Text, txtEffectiveTo.Text, BaseUserID);
            dsUpdateAI = objUpdateAI.AreaInchargeUpdate(lblAreaID.Text, lblEmployeeNumber.Text, BaseLocationAutoID, hfAreaInchargeAutoID.Value, txtEffectiveFrom.Text, EffectiveToDate.ToString(), BaseUserID);
            if (dsUpdateAI != null && dsUpdateAI.Tables.Count > 0 && dsUpdateAI.Tables[0].Rows.Count > 0)
            {
                if (dsUpdateAI.Tables[0].Rows[0]["MessageID"].ToString() == "2")
                {
                    gvAreaIncharge.EditIndex = -1;
                    FillgvAreaIncharge(lblAreaID.Text);
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvAreaIncharge control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvAreaIncharge_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAreaIncharge.EditIndex = -1;
        FillgvAreaIncharge(hfAreaID.Value.ToString());
    }
}
