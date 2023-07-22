// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="MainMasterPage.master.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using CommonLibrary.Session;
using Telerik.Web.UI;
using AjaxControlToolkit;
using System.Web.UI.WebControls;
using System.Xml.Xsl;
using System.IO;
using System.Xml;

/// <summary>
/// Class MasterPage_MainMasterPage
/// </summary>
public partial class MasterPage_MainMasterPage : MasterPage
{
    #region Session Variables Properties

    /// <summary>
    /// Returns UserID.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The session_ user ID.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionUserID
    {
        get
        {
            try
            {
                var uInfo = new UserInformation();
                if (!string.IsNullOrEmpty(uInfo.UserId))
                { return uInfo.UserId; }
                GetSessionOut();
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Returns UserName.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The name of the session_ user.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionUserName
    {
        get
        {
            try
            {
                var uInfo = new UserInformation();
                if (!string.IsNullOrEmpty(uInfo.UserName))
                { return uInfo.UserName; }
                GetSessionOut();
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Returns UserType IsAdmin.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The session_ is admin.</value>
    /// <exception cref="System.Exception">Session has expired! Login again.</exception>
    protected string SessionIsAdmin
    {
        get
        {
            try
            {
                var uInfo = new UserInformation();
                if (!string.IsNullOrEmpty(uInfo.UserRole))
                { return uInfo.UserRole; }
                GetSessionOut();
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again.", ex); }
        }
    }
    /// <summary>
    /// Return CompanyCode
    /// </summary>
    /// <value>The session_ company code.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionCompanyCode
    {
        get
        {
            try
            {
                var accessInfo = new AccessInformation();
                if (!string.IsNullOrEmpty(accessInfo.CompanyCode))
                { return accessInfo.CompanyCode; }
                GetSessionOut();
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Returns HRLocationCode.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The session_ hr location code.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionHrLocationCode
    {
        get
        {
            try
            {
                var accessInfo = new AccessInformation();
                if (!string.IsNullOrEmpty(accessInfo.HrLocationCode))
                { return accessInfo.HrLocationCode; }
                GetSessionOut();
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Returns LocationCode.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The session_ location code.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionLocationCode
    {
        get
        {
            try
            {
                var accessInfo = new AccessInformation();
                if (!string.IsNullOrEmpty(accessInfo.LocationCode))
                { return accessInfo.LocationCode; }
                GetSessionOut();
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Returns LocationAutoID.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The session_ location auto ID.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionLocationAutoID
    {
        get
        {
            try
            {
                var accessInfo = new AccessInformation();
                if (!string.IsNullOrEmpty(accessInfo.LocationAutoId))
                { return accessInfo.LocationAutoId; }
                GetSessionOut();
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }

    /// <summary>
    /// Added new function to HttpContext.Current.Response.Redirect("../default.aspx");
    /// to response.redirec(../default.aspx)
    /// 6/mar/2013 
    /// </summary>
    protected void GetSessionOut()
    {
         Response.Redirect("../default.aspx");
    
    }

    #endregion

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var objMasterManagement = new BL.MastersManagement();
            DataSet ds = objMasterManagement.LocationDetailGet(SessionCompanyCode, SessionHrLocationCode, SessionLocationCode);

            lblwelcome.Text = Resources.Resource.Welcome + @":" + SessionUserName;
            lblhdrselCompany.Text = Resources.Resource.Company + @"&nbsp;&nbsp;&nbsp;: " + ds.Tables[0].Rows[0]["CompanyDesc"] + @" (" + ds.Tables[0].Rows[0]["CompanyCode"] + @")";
            lblhdrselHrLocation.Text = Resources.Resource.HrLocation + @": " + ds.Tables[0].Rows[0]["HrLocationDesc"] + @" (" + ds.Tables[0].Rows[0]["HrLocationCode"] + @")";
            lblhdrselLocation.Text = Resources.Resource.Location + @"&nbsp;&nbsp;&nbsp;&nbsp;: " + ds.Tables[0].Rows[0]["LocationDesc"] + @" (" + ds.Tables[0].Rows[0]["LocationCode"] + @")";
            ReadXml();
            //string strUsername = Resources.Resource.UserName + " : ";
            //string strLoginCountry = Resources.Resource.Country + " : ";
            const int treeViewCodeValue = 25;
            FillTreeView(treeViewCodeValue);
            //lblTvwNode.Text = Resources.Resource.Customer.ToString();

            lblAllMyFolders.Text = Resources.Resource.Customer;
            lblPageHdrTitle.Text = Resources.Resource.Home;
        }
          // We creating a automatic sql scripts for blank data base.
          //As discuss with  we have to drop all the customer amd Employee Portal table 
          // Below mention function calling Customer portal related tables,that is not available now.
          // So we are comment this code  to generate Scripts.  4/4/2014

        // GetCustomerPortalTotalRequest();
        Session.Remove("ReportDocument");
    }

    /// <summary>
    /// Fills the tree view.
    /// </summary>
    /// <param name="treeViewCodeValue">The tree view code value.</param>
    private void FillTreeView(int treeViewCodeValue)
    {
        var objblUserManagement = new BL.UserManagement();
        tvMenu.Nodes.Clear();
        DataSet dsMenues = objblUserManagement.UserMenuGet(SessionUserID, SessionLocationAutoID, treeViewCodeValue);
        this.GenerateTreeView(dsMenues);
//        GenerateAccordian(dsMenues);
        up1.Update();
    }

    private string GetResourceKeyValue(string resourceKey, string value)
    {
        string newValue = value;
        if (resourceKey != string.Empty && !string.IsNullOrEmpty(Resources.Resource.ResourceManager.GetString(resourceKey)))
        {
            newValue = Resources.Resource.ResourceManager.GetString(resourceKey);
        }
        return newValue;
    }

    /// <summary>
    /// Generates the tree view.
    /// </summary>
    /// <param name="dsMenues">The ds menues.</param>
    private void GenerateTreeView(DataSet dsMenues)
    {
        // generate the data set with three tables and their relations
        // now build the node hierarchy, starting at the top
        foreach (DataRow parentItem in dsMenues.Tables[0].Rows)
        {
            if (parentItem["ParentMenuHeadCode"].ToString() == "")
            {
                var mainItem = new RadTreeNode(GetResourceKeyValue((string)parentItem["MenuHeadCode"], (string)parentItem["MenuHeadName"]))
                {
                    //ImageUrl = @"~/Images/folder.png",
                    //CssClass = "customPointer"
                    CssClass = "left-arrow"
                };

                tvMenu.Nodes.Add(mainItem);
                AddSubMainItemInMenu(parentItem, mainItem);
                AddChildItemInMenu(parentItem, mainItem);
            }
        }

        //if (tvMenu.CheckChildNodes)
        if (tvMenu.GetAllNodes().Count > 0)
        {
            tvMenu.Nodes[0].Expanded = true;
        }
    }

    /// <summary>
    /// Adds the sub main item in menu.
    /// </summary>
    /// <param name="dr">The dr.</param>
    /// <param name="item">The item.</param>
    private void AddSubMainItemInMenu(DataRow dr, RadTreeNode item)
    {
        foreach (DataRow subMainItem in dr.GetChildRows("Parent"))
        {
                var subParentItem = new RadTreeNode
                {
                    Text = GetResourceKeyValue((string)subMainItem["MenuHeadCode"], (string)subMainItem["MenuHeadName"]),
                    //ImageUrl = @"~/Images/Desktop.png",
                    //CssClass = "customPointer"
                    CssClass = "left-arrow"
                };

                item.Nodes.Add(subParentItem);
                AddSubMainItemInMenu(subMainItem, subParentItem);
                AddChildItemInMenu(subMainItem, subParentItem);
        }
    }
    /// <summary>
    /// Adds the child item in menu.
    /// </summary>
    /// <param name="dr">The dr.</param>
    /// <param name="item">The item.</param>
    private void AddChildItemInMenu(DataRow dr, RadTreeNode item)
    {
        foreach (DataRow childItem in dr.GetChildRows("Children"))
        {
            if (Convert.ToString(childItem["DependOn"]) == "" || Convert.ToString(childItem["DependOn"]) == "0") //manish
            {
                var childrenItem = new RadTreeNode
                {
                    Text = GetResourceKeyValue((string)childItem["MenuNodeCode"], (string)childItem["MenuNodeName"]),
                    Value = (string)childItem["PageName"],
                    //ImageUrl = @"~/Images/Text-Old-1-icon.png",
                    CssClass = "customPointer"
                };
                item.Nodes.Add(childrenItem);
            }
        }
    }

    /// <summary>
    /// Handles the NodeClick event of the tvMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadTreeNodeEventArgs"/> instance containing the event data.</param>
    protected void tvMenu_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        if (e.Node.Value != string.Empty)
        {
            Radpane5.ContentUrl = e.Node.Value;
            up2.Update();

            lblPageHdrTitle.Text = e.Node.Text == string.Empty ? Resources.Resource.Home : e.Node.Text;
            up5.Update();
        }

    }

    /// <summary>
    /// Handles the NodeClick event of the tvFavourite control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RadTreeNodeEventArgs"/> instance containing the event data.</param>
    protected void tvFavourite_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        if (e.Node.Value != string.Empty)
        {
            Radpane5.ContentUrl = e.Node.Value;
            up2.Update();
        }
        lblPageHdrTitle.Text = e.Node.Text == string.Empty ? Resources.Resource.Home : e.Node.Text;
        up5.Update();

    }

    /// <summary>
    /// Gets the customer portal total request.
    /// </summary>
    private void GetCustomerPortalTotalRequest()
    {
        var objPortal = new BL.Portal();
        var totalRequest = objPortal.CustomerPortalTotalRequestGet(this.SessionIsAdmin, this.SessionUserID, this.SessionLocationAutoID);
        if (totalRequest != null && totalRequest.Tables.Count > 0 && totalRequest.Tables[0].Rows.Count > 0)
        {
            PanelRequestCount.Visible = true;
            lblTotalRequestCount.Text = totalRequest.Tables[0].Rows[0]["Total"].ToString();
        }
        else
        {
            PanelRequestCount.Visible = false;
        }
    }

    /// <summary>
    /// Handles the Click event of the btnTotalRequestCount control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnTotalRequestCount_Click(object sender, EventArgs e)
    {
        // Response.Redirect("../Masters/CustomerPortalInbox.aspx", "PageDisplay", string.Empty);
    }

    /// <summary>
    /// Reads the XML.
    /// </summary>
    protected void ReadXml()
    {
        var objUserManagement = new BL.UserManagement();
        DataSet ds = objUserManagement.WebConfigXmlGet(Server.MapPath("../"));
        lblSoftwareName.Text = ds.Tables[0].Rows[0][0].ToString();
        lblSoftwareVersion.Text = ds.Tables[0].Rows[0][1].ToString();
        lblRelease.Text = ds.Tables[0].Rows[0][4].ToString();
    }

    /// <summary>
    /// Handles the Click event of the ImgBtnSelLoc control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgBtnSelLoc_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MainSelection.aspx");
    }
    /// <summary>
    /// Handles the Click event of the ImgbtnClose control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void ImgbtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Radpane5.ContentUrl = "../UserManagement/Home.aspx";
    }
    
    /// <summary>
    /// Handles the Click event of the lbLogout control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Logout();
        //Session.Abandon();
        //Response.Redirect("../Default.aspx");
    }
    /// <summary>
    /// Handles the Click event of the lbBranchSelection control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbBranchSelection_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UserManagement/MainSelection.aspx");
    }

    /// <summary>
    /// Handles the Click event of the lnkCustomer control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkCustomer_Click(object sender, EventArgs e)
    {
        lblAllMyFolders.Text = Resources.Resource.Customer;
        try
        {
            FillTreeView(2);
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
        }
    }

    /// <summary>
    /// Handles the Click event of the lnkEmployee control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkEmployee_Click(object sender, EventArgs e)
    {
        lblAllMyFolders.Text = Resources.Resource.Employee;
        try
        {
            FillTreeView(3);
        }
        catch (Exception ex)
        { ExceptionLog(ex); }
    }
    /// <summary>
    /// Handles the Click event of the lnkRostering control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkRostering_Click(object sender, EventArgs e)
    {
        lblAllMyFolders.Text = Resources.Resource.Roster;
        try
        {
            FillTreeView(4);
        }
        catch (Exception ex)
        { ExceptionLog(ex); }

    }
    /// <summary>
    /// Handles the Click event of the lnkInvoicing control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkInvoicing_Click(object sender, EventArgs e)
    {
        lblAllMyFolders.Text = Resources.Resource.Invoice;
        try
        {
            FillTreeView(4);
        }
        catch (Exception ex)
        { ExceptionLog(ex); }
    }
    /// <summary>
    /// Handles the Click event of the lnkReports control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkReports_Click(object sender, EventArgs e)
    {
        lblAllMyFolders.Text = Resources.Resource.Reports;
        try
        {
            FillTreeView(6);
        }
        catch (Exception ex)
        { ExceptionLog(ex); }
    }
    /// <summary>
    /// Handles the Click event of the lnkMaster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkMaster_Click(object sender, EventArgs e)
    {
        lblAllMyFolders.Text = Resources.Resource.Masters;
        try
        {
            FillTreeView(6);
        }
        catch (Exception ex)
        { ExceptionLog(ex); }
    }
    /// <summary>
    /// Handles the Click event of the lnkUser control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkUser_Click(object sender, EventArgs e)
    {
        try
        {
            lblAllMyFolders.Text = Resources.Resource.User;
            FillTreeView(1);
        }
        catch (Exception ex)
        { ExceptionLog(ex); }
    }

    /// <summary>
    /// Handles the Click event of the lnkNFC control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lnkNFC_Click(object sender, EventArgs e)
    {
        lblAllMyFolders.Text = Resources.Resource.NFC;
        try
        {
            FillTreeView(5);
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
        }
    }

    private void Logout()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();

        var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "") { Expires = DateTime.Now.AddYears(-1) };
        Response.Cookies.Add(cookie1);

        var cookie2 = new HttpCookie("ASP.NET_SessionId", "") { Expires = DateTime.Now.AddYears(-1) };
        Response.Cookies.Add(cookie2);

        FormsAuthentication.RedirectToLoginPage();
    }

    protected void ExceptionLog(Exception ex)
    {
        var uInfo = new UserInformation();
        var objEx = new BL.ExceptionLogs();
        objEx.ExceptionLog(ex.InnerException.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace,
            !string.IsNullOrEmpty(uInfo.UserId) ? uInfo.UserId : @"system");
    }

    protected void lnlAsset_Click(object sender, EventArgs e)
    {
        lblAllMyFolders.Text = Resources.Resource.AssetManagement;
        try
        {
            FillTreeView(25);
        }
        catch (Exception ex)
        { ExceptionLog(ex); }

    }
}