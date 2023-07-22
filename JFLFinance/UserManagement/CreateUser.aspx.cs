// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="CreateUser.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;



/// <summary>
/// Class UserManagement_CreateUser
/// </summary>
public partial class UserManagement_CreateUser : BasePage //System.Web.UI.Page
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
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void Page_PreInit(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(BaseLocationAutoID))
        {
            this.MasterPageFile = "~/MasterPage/MasterPage.master";
        }
        else
        {
            this.MasterPageFile = "~/MasterPage/MasterHeader.master";
        }
    }
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*Code added by  on 1-Sep-2011*/
            hlkSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=cch_00002&ControlId=" + txtEmployeeCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&Location=&HrLocation=" + BaseHrLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=360,help=no')");
            /*End of Code added by  on 1-Sep-2011*/
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.PageHdrCreateUser.ToString(); }

            //Code added by  on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.PageHdrCreateUser + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            //btnSave.Attributes.Add("onclick", "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "')");

            txtUserID.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionUserId + ");";
            txtUserID.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionUserId + ");";

            if (string.IsNullOrEmpty(BaseLocationAutoID) && BaseIsAdmin == "SA")
            { imgBack.Visible = true; }
            else
            { imgBack.Visible = false; }

            if (IsReadAccess == true && BaseIsAdmin != "U")
            {
                FillddlUserType();
                FillUserGroup();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
        /*Code added by  on 1-Sep-2011*/
        else
        {
            if (cbIsEmployee.Checked == true && txtEmployeeCode.Visible == false && hlkSearch.Visible == false)
            {
                txtEmployeeCode.Visible = true;
                hlkSearch.Visible = true;
            }
            ViewState["txtConfirmPassword"] = txtConfirmPassword.Text;
            txtConfirmPassword.Attributes.Add("value", ViewState["txtConfirmPassword"].ToString());
            ViewState["txtPassword"] = txtPassword.Text;
            txtPassword.Attributes.Add("value", ViewState["txtPassword"].ToString());
            txtPassword.Text = ViewState["txtPassword"].ToString();
            txtConfirmPassword.Text = ViewState["txtConfirmPassword"].ToString();

        }
        /*End of Code added by  on 1-Sep-2011*/
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
    /// <summary>
    /// Fillddls the type of the user.
    /// </summary>
    private void FillddlUserType()
    {
        //if (BaseIsAdmin == "SA")
        //{

        ListItem li = new ListItem("Auditor", "Auditor");
            ddlUserType.Items.Add(li);
          
            //li = new ListItem("Supervisor", "S");
            //ddlUserType.Items.Add(li);
            //li = new ListItem("Restaurant", "R");
            //ddlUserType.Items.Add(li);
            //li = new ListItem("Circle Head", "CH");
            //ddlUserType.Items.Add(li);
            ///*** Code modified by  on 8Jun2010****/
            //li = new ListItem("Regional Manager", "RM");
            //ddlUserType.Items.Add(li);
            li = new ListItem("Administrator", "A");
            ddlUserType.Items.Add(li);
            /*** End of Code modified by  on 8Jun2010****/
           
         
            //li = new ListItem(Resources.Resource.Engineer, "E");
            //ddlUserType.Items.Add(li);
      //  }
        //else if (BaseIsAdmin == "SU")
        //{
        //    ListItem li = new ListItem(Resources.Resource.SuperUser, "SU");
        //    ddlUserType.Items.Add(li);
        //    li = new ListItem(Resources.Resource.Administrator, "A");
        //    ddlUserType.Items.Add(li);

        //    li = new ListItem(Resources.Resource.User, "U");
        //    ddlUserType.Items.Add(li);
        //    /*** Code modified by  on 8Jun2010****/
        //    li = new ListItem(Resources.Resource.Customer, "C");
        //    ddlUserType.Items.Add(li);
        //    /*** End of Code modified by  on 8Jun2010****/
        //    li = new ListItem(Resources.Resource.Device, "D");
        //    ddlUserType.Items.Add(li);
           
        //    li = new ListItem(Resources.Resource.Engineer, "E");
        //    ddlUserType.Items.Add(li);
        //}
        //else if (BaseIsAdmin == "A")
        //{
        //    ListItem li = new ListItem(Resources.Resource.Administrator, "A");
        //    ddlUserType.Items.Add(li);

        //    li = new ListItem(Resources.Resource.User, "U");
        //    ddlUserType.Items.Add(li);
        //    li = new ListItem(Resources.Resource.Device, "D");
        //    ddlUserType.Items.Add(li);
           
        //    li = new ListItem(Resources.Resource.Engineer, "E");
        //    ddlUserType.Items.Add(li);
        //}
        ///*** Code modified by  on 8Jun2010****/
        //else if (BaseIsAdmin == "C")
        //{
        //    ListItem li = new ListItem(Resources.Resource.Customer, "C");
        //    ddlUserType.Items.Add(li);
        //}
        ///*** End of Code modified by  on 8Jun2010****/
        //else if (BaseIsAdmin == "D")
        //{
        //    ListItem li = new ListItem(Resources.Resource.Device, "D");
        //    ddlUserType.Items.Add(li);
        //}
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlUserType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillUserGroup();
        EnableddlUserGroup();
       //if(ddlUserType.SelectedItem.Value == "E")
       //{
       //    cbIsActive.Checked = true;
       //    cbIsEmployee.Checked = true;
       //    txtEmployeeCode.Visible = true;
       //    hlkSearch.Visible = true;
       //    rfvMobile.Enabled = true;
       //    RfvEmployeeCode.Enabled = true;
       //}
       //else
       //{
       //    cbIsActive.Checked = false;
       //    cbIsEmployee.Checked = false;
       //    txtEmployeeCode.Visible = false;
       //    hlkSearch.Visible = false;
       //    rfvMobile.Enabled = false;
       //    RfvEmployeeCode.Enabled = false;
       //}
    }

    /// <summary>
    /// Enableddls the user group.
    /// </summary>
    private void EnableddlUserGroup()
    {
        if (ddlUserType.SelectedItem.Value.ToString() == "Auditor")
        {
            ddlUserGroup.SelectedValue = "Auditor";
            ddlUserGroup.Enabled = false;

        }
        //else if (ddlUserType.SelectedItem.Value.ToString() == "S")
        //{
        //    ddlUserGroup.SelectedValue = "S";
        //    ddlUserGroup.Enabled = false;
        //}
        //else if (ddlUserType.SelectedItem.Value.ToString() == "CH")
        //{
        //    ddlUserGroup.SelectedValue = "CH";
        //    ddlUserGroup.Enabled = false;
        //}
        //else if (ddlUserType.SelectedItem.Value.ToString() == "R")
        //{
        //    ddlUserGroup.SelectedValue = "R";
        //    ddlUserGroup.Enabled = false;
        //}
        //else if (ddlUserType.SelectedItem.Value.ToString() == "RM")
        //{
        //    ddlUserGroup.SelectedValue = "RM";
        //    ddlUserGroup.Enabled = false;
        //}
        else if (ddlUserType.SelectedItem.Value.ToString() == "A")
        {
            ddlUserGroup.SelectedValue = "A";
            ddlUserGroup.Enabled = false;
        }
    }

    /// <summary>
    /// Fills the user group.
    /// </summary>
    private void FillUserGroup()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsUG = new DataSet();
        DataTable dtUG = new DataTable();
        dsUG = objMastersManagement.UserGroupGetAll(BaseUserID);
        ddlUserGroup.DataSource = dsUG;
        ddlUserGroup.DataTextField = "UserGroupName";
        ddlUserGroup.DataValueField = "UserGroupCode";
        ddlUserGroup.DataBind();

        //if (ddlUserType.SelectedItem.Value != "A" && ddlUserType.SelectedItem.Value != "SU")
        //{
        //    ListItem li = ddlUserGroup.Items.FindByValue("A");
        //    ddlUserGroup.Items.Remove(li);
        //    li = ddlUserGroup.Items.FindByValue("SU");
        //    ddlUserGroup.Items.Remove(li);
        //}
        //else
        //{
        //    ListItem li = new ListItem("Administrator", "A");
        //    ddlUserGroup.Items.Add(li);
        //    li = new ListItem("SuperUser", "SU");
        //    ddlUserGroup.Items.Add(li);
        //}

        EnableddlUserGroup();
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void  btnSave_Click(object sender, EventArgs e)
    {
         Regex uppercaseCharacterMatcher = new Regex("[A-Z]");
        BL.UserManagement objUserManagement = new BL.UserManagement();
        DataSet ds = new DataSet();
        if (txtUserID.Text != txtPassword.Text)
        {
            /*Code modified by  for Allowing Password & userName with atleast 6 & 8 characters respectively*/
            if (txtUserID.Text.Length >= 6)
            {
                if (txtPassword.Text.Length >= 8)
                {
                    if (uppercaseCharacterMatcher.Matches(txtPassword.Text).Count >= 1)
                    {
                        if (txtPassword.Text == txtConfirmPassword.Text)
                        {
                            /******************Code Added by  for password policy on user creation on 27Mar2014********************************/
                            BL.UserManagement objDlUserManagement = new BL.UserManagement();
                            DataSet dsPasswordCheck = new DataSet();
                            dsPasswordCheck.Locale = System.Globalization.CultureInfo.InvariantCulture;
                            dsPasswordCheck = objDlUserManagement.CheckPasswordExpression(BaseCompanyCode, txtPassword.Text);
                            if (dsPasswordCheck != null && dsPasswordCheck.Tables.Count > 0 && dsPasswordCheck.Tables[0].Rows.Count > 0)
                            {
                                lblErrorMsg.Text = Resources.Resource.PasswordNotComply;
                            }
                            else
                            {
                                if (cbIsEmployee.Checked == true)
                                {
                                    txtEmployeeCode.Visible = true;
                                    hlkSearch.Visible = true;
                                    if (txtEmployeeCode.Text != "")
                                    {
                                        CheckEmployeeValidity();
                                    }
                                }
                                if (ddlUserType.SelectedItem.Value == "E")
                                {
                                    //string strkey = GetDecryptkey(BaseCountryCode);
                                    //ds = objUserManagement.UserAddEngineer(txtUserID.Text, txtPassword.Text, txtUserName.Text, cbIsActive.Checked, BaseUserID, txtEmailId.Text, txtMobileNumber.Text, cbIsEmployee.Checked, txtEmployeeCode.Text,strkey);
                                    //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    //{
                                    //    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                    //}
                                }
                                else
                                {
                                    string strkey = GetDecryptkey(BaseCountryCode);
                                    ds = objUserManagement.UserAdd(txtUserID.Text, txtPassword.Text, txtUserName.Text, ddlUserType.SelectedItem.Value, cbIsActive.Checked, BaseUserID, txtEmailId.Text, txtMobileNumber.Text, BaseLocationAutoID, ddlUserGroup.SelectedItem.Value, cbIsEmployee.Checked, txtEmployeeCode.Text, strkey);

                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                    }
                                    //    ds = objUserManagement.blUser_Insert(txtUserID.Text, txtPassword.Text, txtUserName.Text, ddlUserType.SelectedItem.Value, cbIsActive.Checked, BaseUserID, txtEmailId.Text, txtMobileNumber.Text, BaseLocationAutoID, ddlUserGroup.SelectedValue.ToString(), ConfigurationManager.AppSettings["strSaPwd"]);
                                    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    //    {
                                    //        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                    //    }
                                    //}
                                    txtUserID.Text = "";
                                    txtUserName.Text = "";
                                    /******************Code Added by   on 8Jun2010********************************/
                                    txtEmailId.Text = "";
                                    txtMobileNumber.Text = "";
                                    cbIsActive.Checked = false;

                                    /*******************Code Added by   on 8Jun2010*******************************/
                                    /*******************Code Added by   on 31Aug2011*******************************/
                                    cbIsEmployee.Checked = false;
                                    txtEmployeeCode.Visible = false;
                                    hlkSearch.Visible = false;
                                    txtConfirmPassword.Text = "";
                                    txtPassword.Text = "";
                                    ViewState["txtConfirmPassword"] = txtConfirmPassword.Text;
                                    txtConfirmPassword.Attributes.Add("value", ViewState["txtConfirmPassword"].ToString());
                                    ViewState["txtPassword"] = txtPassword.Text;
                                    txtPassword.Attributes.Add("value", ViewState["txtPassword"].ToString());
                                    txtPassword.Text = ViewState["txtPassword"].ToString();
                                    txtConfirmPassword.Text = ViewState["txtConfirmPassword"].ToString();
                                    /*******************Code Added by   on 31Aug2011*******************************/
                                }
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.PasswordConfirmPasswordShouldMatch;
                        }
                    }
                    else {

                        lblErrorMsg.Text = Resources.Resource.PasswordNotComply;
                    }
                }

                else
                {
                    lblErrorMsg.Text = Resources.Resource.PasswordLength;

                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.UserIDLength;
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.UserIDPasswordCouldNotSame;
        }
    }
    /// <summary>
    /// Handles the Click event of the imgBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs"/> instance containing the event data.</param>
    protected void imgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../UserManagement/MasterMenu.aspx");
    }

    /*** Code modified by  on 1Sep2011****/
    /// <summary>
    /// This checks if the Employee belongs to the Same Company or Not
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeCode_TextChanged(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
        if (txtEmployeeCode.Text != "")
        {
            CheckEmployeeValidity();
        }

    }

    /// <summary>
    /// Checks the employee validity.
    /// </summary>
    private void CheckEmployeeValidity()
    {

        BL.HRManagement objUserManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objUserManagement.IsValidUser(BaseLocationAutoID, txtEmployeeCode.Text);

        if (ds.Tables[0].Rows.Count == 0)
        {
            lblErrorMsg.Text = Resources.Resource.ErrorValidateEmployee;
            txtEmployeeCode.Text = "";
            txtEmployeeCode.Focus();
            return;
        }
        else
        {
            lblErrorMsg.Text = "";
        }

    }
    /*** End of Code modified by  on 1Sep2011****/



    /// <summary>
    /// Get the  key vlaue from Encrypted file.
    /// </summary>
    /// <param name="strCountry">The STR country.</param>
    /// <returns>Key that we are using to Decrypt the string</returns>
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }

}
