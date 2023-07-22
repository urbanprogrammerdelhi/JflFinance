using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Testpages_Test1 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillddlDivision();
        }
    }

    protected void FillddlDivision()
    {
        var objblUserManagement = new BL.UserManagement();
        var dsHrLocation = objblUserManagement.UserHRLocationAccessGet(BaseUserID, "KSAAMSS");
        if (dsHrLocation.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsHrLocation.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();
        }
    }

    protected void FillddlBranch()
    {
        ddlBranch.Items.Clear();
        var objblMstManagement = new BL.MastersManagement();
        var arrHrLocationCode = ddlDivision.Text.Split(',');

        var ds = objblMstManagement.LocationDescriptionGetAll("KSAAMSS", arrHrLocationCode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = ds.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
        }
    }
    protected void ddlDivision_Changed(object sender, EventArgs e)
    {
        FillddlBranch();
    }

    
}