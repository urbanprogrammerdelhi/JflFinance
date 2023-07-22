using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transactions_ShiftWiseSchandActual : BasePage
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
        if (!IsPostBack)
        {
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.SaleOrder + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            
            txtDutyDate.Attributes.Add("readonly", "readonly");
            txtDutyDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (IsReadAccess == true)
            {
                FillddlAreaID();
                FillddlClientCode();
                FillAsmtId();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(ddlClientCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Controle Binding
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaID()
    {
        ListItem li = new ListItem();
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();
        dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();
            li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlAreaID.Items.Insert(0, li);
        }
        if (ddlAreaID.Text == string.Empty)
        {
            li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlAreaID.Items.Add(li);
        }
    }

    /// <summary>
    /// Fillddls the client code.
    /// </summary>
    protected void FillddlClientCode()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objsales.ClientGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objsales.ClientsMappedToLocationGet(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString(), "".ToString(), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        }
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientCodeName";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();
                if (Request.QueryString["ClientCode"] != null)
                {
                    ddlClientCode.SelectedIndex = ddlClientCode.Items.IndexOf(ddlClientCode.Items.FindByValue(Request.QueryString["ClientCode"].ToString()));
                }
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlClientCode.Items.Add(li);
            }
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlClientCode.Items.Add(li);
        }
    }
    
    /// <summary>
    /// Fills the asmt identifier.
    /// </summary>
    private void FillAsmtId()
    {
        BL.Sales objSales = new BL.Sales();
        ddlAsmtId.DataSource = objSales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), BaseUserEmployeeNumber, "");
        ddlAsmtId.DataTextField = "AsmtIDAddress";
        ddlAsmtId.DataValueField = "AsmtID";
        ddlAsmtId.DataBind();
        FillddlShift();
        //ListItem li1 = new ListItem();
        //li1.Text = Resources.Resource.All;
        //li1.Value = "ALL";
        //ddlAsmtId.Items.Insert(0, li1);
        if (ddlAsmtId.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlAsmtId.Items.Add(li);
        }
    }

    private void FillddlShift()
    {
        if (ddlClientCode.SelectedItem.Value != "0" && ddlAsmtId.SelectedItem.Value != "0" && txtDutyDate.Text != string.Empty)
        {
            BL.Sales objSales = new BL.Sales();
            ddlShift.DataSource = objSales.GetAvailableShiftDetails(ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, txtDutyDate.Text);
            ddlShift.DataTextField = "ShiftTime";
            ddlShift.DataValueField = "ShiftCode";
            ddlShift.DataBind();
        }
        //ListItem li1 = new ListItem();
        //li1.Text = Resources.Resource.All;
        //li1.Value = "ALL";
        //ddlShift.Items.Insert(0, li1);
        if (ddlShift.Text == string.Empty)
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlShift.Items.Add(li);
        }
    }

    private void FillgvSchActual()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objSales.ScheduleVsAcualByAsmtGet(ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, ddlShift.SelectedItem.Value, txtDutyDate.Text);
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvSchActual.DataSource = dt;
        gvSchActual.DataBind();
        if (dtflag == 0)//to fix empety gridview
        {
            gvSchActual.Rows[0].Visible = false;
        }

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            lblReqEmpCount.Text = ds.Tables[1].Rows[0]["ReqEmpCount"].ToString();
            lblReqHrs.Text = ds.Tables[1].Rows[0]["ReqTotalHrs"].ToString();

            lblSchEmpCount.Text = ds.Tables[1].Rows[0]["SchEmpCount"].ToString();
            lblActEmpCount.Text = ds.Tables[1].Rows[0]["ActEmpCount"].ToString();

            lblSchHrs.Text = ds.Tables[1].Rows[0]["SchHrs"].ToString();
            lblActHrs.Text = ds.Tables[1].Rows[0]["ActHrs"].ToString();
        }
    }
    #endregion

    #region other controles events
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClientCode();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtId();
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager1.SetFocus(ddlClientCode);
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtId control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlShift();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        FillgvSchActual();
    }
    protected void gvSchActual_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (IsModifyAccess == false)
        //{
        //    gvSchActual.Columns[0].Visible = false;
        //}
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvSchActual.PageIndex * gvSchActual.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }

            Label lblgvSchEmployeeNumber = (Label)e.Row.FindControl("lblgvSchEmployeeNumber");
            Label lblgvSchEmployeeName = (Label)e.Row.FindControl("lblgvSchEmployeeName");
            Label lblgvSchShiftTime = (Label)e.Row.FindControl("lblgvSchShiftTime");
            
            Label lblgvActEmployeeNumber = (Label)e.Row.FindControl("lblgvActEmployeeNumber");
            Label lblgvActEmployeeName = (Label)e.Row.FindControl("lblgvActEmployeeName");
            Label lblgvActShiftTime = (Label)e.Row.FindControl("lblgvActShiftTime");

            string redStyle = "background-color: red;color: white; padding: 4px;Border-radius: 6px;";
            string greenStyle = "background-color: green;color: white; padding: 4px;Border-radius: 6px;";
            string orangeStyle = "background-color: #FFA500;color: white; padding: 4px;Border-radius: 6px;";

            if (lblgvSchEmployeeNumber != null && lblgvActEmployeeNumber != null)
            {
                if(lblgvSchEmployeeNumber.Text == string.Empty)
                {
                    lblgvActEmployeeNumber.Attributes.Add("style", redStyle);
                    lblgvActEmployeeName.Attributes.Add("style", redStyle);
                    lblgvActShiftTime.Attributes.Add("style", redStyle);
                    //e.Row.Cells[4].Attributes.Add("style", redStyle);
                    //e.Row.Attributes.Add("style", redStyle);
                }
                if (lblgvActEmployeeNumber.Text == string.Empty)
                {
                    lblgvSchEmployeeNumber.Attributes.Add("style", redStyle);
                    lblgvSchEmployeeName.Attributes.Add("style", redStyle);
                    lblgvSchShiftTime.Attributes.Add("style", redStyle);
                }
                if (lblgvSchEmployeeNumber.Text != string.Empty && lblgvActEmployeeNumber.Text != string.Empty)
                {
                    lblgvActEmployeeNumber.Attributes.Add("style", greenStyle);
                    lblgvActEmployeeName.Attributes.Add("style", greenStyle);
                    lblgvActShiftTime.Attributes.Add("style", greenStyle);
                    lblgvSchEmployeeNumber.Attributes.Add("style", greenStyle);
                    lblgvSchEmployeeName.Attributes.Add("style", greenStyle);
                    lblgvSchShiftTime.Attributes.Add("style", greenStyle);
                }
                if (lblgvActShiftTime.Text.Contains("Missing IN"))
                {
                    //lblgvActShiftTime.Attributes.Add("style", orangeStyle);
                    lblgvActShiftTime.Attributes.Add("style","background: linear-gradient(to right, red , #7FFF00);color: white; padding: 4px;Border-radius: 6px;");
                }
                if (lblgvActShiftTime.Text.Contains("Missing OUT"))
                {
                    //lblgvActShiftTime.Attributes.Add("style", orangeStyle);
                    lblgvActShiftTime.Attributes.Add("style","background: linear-gradient(to right, #7FFF00 , red);color: white; padding: 4px;Border-radius: 6px;");
                }
            }
            //;

            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }
    #endregion
}