using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManagement_DeviceUserSiteRights : BasePage
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                if (Request.QueryString["UserID"] != null)
                {
                    lblUserID.Text = Request.QueryString["UserID"];
                    var objblUserManagement = new BL.UserManagement();
                    DataSet ds = objblUserManagement.UserNameAndTypeGet(lblUserID.Text);
                    if (ds.Tables.Count > 0)
                    {
                        lblUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                        FilltvSiteRights();
                    }
                    else
                    {
                        lblUserID.Text = string.Empty;
                        lblErrorMsg.Text = Resources.Resource.MsgNotFound;
                    }
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            if(IsWriteAccess && IsDeleteAccess)
            {
                btnSave.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
            }
        }

    }

    protected void FilltvSiteRights()
    {
        tvSiteRights.Nodes.Clear();
        var objUserManagement = new BL.UserManagement();

        DataSet dsUserLocationRights = objUserManagement.UserSiteRightGet(BaseUserID, BaseIsAdmin, lblUserID.Text);
        if (dsUserLocationRights.Tables.Count > 0)
        {
            CreateTreeViewNodesCompany(dsUserLocationRights.Tables[0], tvSiteRights.Nodes);
            tvSiteRights.ExpandAll();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgNotFound;
        }
    }
    private void CreateTreeViewNodesCompany(DataTable table, TreeViewNodeCollection nodesCollection)
    {
        DataTable dtCompany = table.DefaultView.ToTable(true, "CompanyCode", "CompanyDesc");
        for (int i = 0; i < dtCompany.Rows.Count; i++)
        {
            TreeViewNode node = new TreeViewNode(dtCompany.Rows[i]["CompanyDesc"].ToString(), dtCompany.Rows[i]["CompanyCode"].ToString());
            nodesCollection.Add(node);
            CreateTreeViewNodesHrLocation(table, node.Nodes, node.Name);
        }
    }
    private void CreateTreeViewNodesHrLocation(DataTable table, TreeViewNodeCollection nodesCollection, string parentID)
    {
        DataTable dtHrLocation = table.DefaultView.ToTable(true, "CompanyCode", "HrLocationCode", "HrLocationDesc");
        for (int i = 0; i < dtHrLocation.Rows.Count; i++)
        {
            if (dtHrLocation.Rows[i]["CompanyCode"].ToString() == parentID)
            {
                TreeViewNode node = new TreeViewNode(dtHrLocation.Rows[i]["HrLocationDesc"].ToString(), dtHrLocation.Rows[i]["HrLocationCode"].ToString());
                nodesCollection.Add(node);
                CreateTreeViewNodesLocation(table, node.Nodes, node.Name);
            }
        }
    }
    private void CreateTreeViewNodesLocation(DataTable table, TreeViewNodeCollection nodesCollection, string parentID)
    {
        DataTable dtLocation = table.DefaultView.ToTable(true, "HrLocationCode", "LocationAutoId", "LocationCode", "LocationDesc");
        for (int i = 0; i < dtLocation.Rows.Count; i++)
        {
            if (dtLocation.Rows[i]["HrLocationCode"].ToString() == parentID)
            {
                TreeViewNode node = new TreeViewNode(dtLocation.Rows[i]["LocationDesc"].ToString() + " (" + dtLocation.Rows[i]["LocationCode"].ToString() + ")", dtLocation.Rows[i]["LocationAutoId"].ToString());
                nodesCollection.Add(node);
                CreateTreeViewNodesClient(table, node.Nodes, node.Name);
            }
        }
    }
    private void CreateTreeViewNodesClient(DataTable table, TreeViewNodeCollection nodesCollection, string parentID)
    {
        DataTable dtClient = table.DefaultView.ToTable(true, "LocationAutoId", "ClientCode", "ClientName");
        for (int i = 0; i < dtClient.Rows.Count; i++)
        {
            if (dtClient.Rows[i]["LocationAutoId"].ToString() == parentID)
            {
                TreeViewNode node = new TreeViewNode(dtClient.Rows[i]["ClientName"].ToString() + " (" + dtClient.Rows[i]["ClientCode"].ToString() + ")", dtClient.Rows[i]["LocationAutoId"].ToString() + "|" + dtClient.Rows[i]["ClientCode"].ToString());
                nodesCollection.Add(node);
                CreateTreeViewNodesAsmt(table, node.Nodes, node.Name);
            }
        }
    }
    private void CreateTreeViewNodesAsmt(DataTable table, TreeViewNodeCollection nodesCollection, string parentID)
    {
        DataTable dtAsmt = table.DefaultView.ToTable(true, "LocationAutoId", "ClientCode", "AsmtId", "AsmtName", "Right");
        for (int i = 0; i < dtAsmt.Rows.Count; i++)
        {
            if (dtAsmt.Rows[i]["LocationAutoId"].ToString() + "|" + dtAsmt.Rows[i]["ClientCode"].ToString() == parentID)
            {
                TreeViewNode node = new TreeViewNode(dtAsmt.Rows[i]["AsmtName"].ToString() + " (" + dtAsmt.Rows[i]["AsmtId"].ToString() + ")",
                    dtAsmt.Rows[i]["LocationAutoId"].ToString() + "|" + dtAsmt.Rows[i]["ClientCode"].ToString() + "|" + dtAsmt.Rows[i]["AsmtId"].ToString());
                //dtAsmt.Rows[i]["AsmtId"].ToString());
                node.ToolTip = Resources.Resource.Asmt;
                if (dtAsmt.Rows[i]["Right"].ToString() == "true")
                {
                    node.Checked = true;
                }
                else
                {
                    node.Checked = false;
                }
                nodesCollection.Add(node);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //string checkedNodes = tvSiteRights.Nodes.FindAllRecursive(n => n.Checked && n.ToolTip.Equals(Resources.Resource.Asmt))
        //                        .Select(x => x.Name)
        //                        .Aggregate((a, b) => a + ", " + b);

        //List<string[]> siteRights = tvSiteRights.Nodes.FindAllRecursive(n => n.Checked && n.ToolTip.Equals(Resources.Resource.Asmt))
        //                        .Select(x => x.Name.Split('|')).ToList();

        //List<string[]> siteRights = tvSiteRights.Nodes.FindAllRecursive(n => n.ToolTip.Equals(Resources.Resource.Asmt))
        //                        .Select(x => x.Name.Split('|')).ToList();

        //List<CommonLibrary.MyUtility.keyData> siteRights0 = tvSiteRights.Nodes.FindAllRecursive(n => n.ToolTip.Equals(Resources.Resource.Asmt))
        //                        .Select(x => new CommonLibrary.MyUtility.keyData() { LocationAutoId = x.Name.Split('|')[0], ClientCode = x.Name.Split('|')[1], AsmtId = x.Name.Split('|')[2], IsChecked = x.Checked.ToString() }).ToList();

        var siteRights = tvSiteRights.Nodes.FindAllRecursive(n => n.ToolTip.Equals(Resources.Resource.Asmt))
                                .Select(x => new { LocationAutoId = x.Name.Split('|')[0], ClientCode = x.Name.Split('|')[1], AsmtId = x.Name.Split('|')[2], IsChecked = x.Checked.ToString() });

        DataTable dtSiteRights = new DataTable();
        dtSiteRights.TableName = "siteRights";
        dtSiteRights.Columns.Add("LocationAutoId", typeof(string));
        dtSiteRights.Columns.Add("ClientCode", typeof(string));
        dtSiteRights.Columns.Add("AsmtId", typeof(string));
        dtSiteRights.Columns.Add("IsChecked", typeof(string));

        foreach (var row in siteRights)
        {
            DataRow datarow = dtSiteRights.NewRow();
            datarow[0] = row.LocationAutoId;
            datarow[1] = row.ClientCode;
            datarow[2] = row.AsmtId;
            datarow[3] = row.IsChecked;

            dtSiteRights.Rows.Add(datarow);
        }

        var objUserManagement = new BL.UserManagement();
        DataSet ds = objUserManagement.SiteRightAdd(BaseUserID, lblUserID.Text, dtSiteRights);
        FilltvSiteRights();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        { DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString()); }
    }

}