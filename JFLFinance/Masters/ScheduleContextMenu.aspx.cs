using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Masters_ScheduleContextMenu : BasePage
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
            javaScript.Append("PageTitle('" + "ScheduleContextMenu" + "');");
            //javaScript.Append("PageTitle('" + Resources.Resource.ScheduleContextMenu + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            if (IsReadAccess == true)
            {
                FillddlLocation();
                FillgvScheduleContextMenu();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Button Events
    /// <summary>
    /// Submit button click event
    /// </summary>
    /// <param name="sender">Selected Index Changed Object</param>
    /// <param name="e">Click Event</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in gvScheduleContextMenu.Rows)
        {
            string MenuAutoID = ((HiddenField)gvRow.FindControl("hdnMenuAutoID")).Value.Trim();
            bool IsActive = ((CheckBox)gvRow.FindControl("chkIsActive")).Checked;
            string AttendanceType = ((DropDownList)gvRow.FindControl("ddlAttendanceType")).SelectedValue;
      
            BL.MastersManagement objHRManagement = new BL.MastersManagement();

            DataSet ds = objHRManagement.ScheduleContextMenuInsertUpdate(BaseLocationCode, MenuAutoID, IsActive, AttendanceType);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }
        }

    }
    #endregion 
    /// <summary>
    /// Fills The dropdown for Location
    /// </summary>
    private void FillddlLocation()
    {
        var ObjblMastersManagement = new BL.MastersManagement();
        ddlLocation.DataSource = ObjblMastersManagement.LocationGetAll().Tables[0];
        ddlLocation.DataTextField = "LocationDesc";
        ddlLocation.DataValueField = "LocationCode";
        ddlLocation.SelectedValue = BaseLocationCode;
        ddlLocation.DataBind();
        if (ddlLocation.Text == "")
        {
            var LI = new ListItem
            {
                Text = Resources.Resource.NoData,
                Value = @"0"
            };
            ddlLocation.Items.Add(LI);
           
        }
      
    }

    #region Location DropDown Event
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DdlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvScheduleContextMenu();
    


    }
    #endregion

    #region GridView ScheduleContextMenu Events
    /// <summary>
    /// Fillgvs the ScheduleContextMenu master.
    /// </summary>
    protected void FillgvScheduleContextMenu()
    {
       var objMaster = new BL.MastersManagement();
       var ds = new DataSet();
       var dt = new DataTable();
        ds = objMaster.ScheduleContextMenuGet(ddlLocation.SelectedValue);
        dt = ds.Tables[0];

        //to bind Rows gridview
        if (dt.Rows.Count >= 0)
        {
            gvScheduleContextMenu.DataKeyNames = new string[] { "MenuAutoID" };
            gvScheduleContextMenu.DataSource = dt;
            gvScheduleContextMenu.DataBind();
        }

    }
    /// <summary>
    /// Handles the RowDataBound event of the gvScheduleContextMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleContextMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string AttendanceType = ((HiddenField)e.Row.FindControl("hdnAttendanceType")).Value;
            if (!string.IsNullOrEmpty(AttendanceType))
            {
                ((DropDownList)e.Row.FindControl("ddlAttendanceType")).SelectedValue = AttendanceType;

            }
            Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
            if (lblSerialNo != null)
            {
                int serialNo = gvScheduleContextMenu.PageIndex * gvScheduleContextMenu.PageSize + int.Parse(e.Row.RowIndex.ToString());
                lblSerialNo.Text = Convert.ToString((serialNo + 1));
            }
        }
    }

  


    #endregion
}