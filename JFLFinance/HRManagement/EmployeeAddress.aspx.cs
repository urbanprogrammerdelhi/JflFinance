// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeAddress.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// HR Management Employee Address Code Behind
/// </summary>
public partial class HRManagement_EmployeeAddress : BasePage //System.Web.UI.Page
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
            throw new Exception("Have not Rights", ex); 
          }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose(); throw new Exception("Have not Rights", ex);
            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose(); throw new Exception("Have not Rights", ex);
            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex);
            }
        }
    }

    #endregion

    #region Page function
    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
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
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.Address;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Address + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                string EmployeeNumber = Request.QueryString["EmployeeNumber"];
                string FirstName = Request.QueryString["FirstName"];
                string LastName = Request.QueryString["LastName"];

                //string EmployeeNumber = "1114";
                //string FirstName = "VICTOR";
                //string LastName = "JORDAN";

                txtEmployeeNumber.Text = EmployeeNumber.ToString();
                txtEmployeeName.Text = FirstName.ToString() + " " + LastName.ToString();

                AddAttributes();

                FillddlGroupZip();
                DataSet ds = new DataSet();
                BL.MastersManagement objMastersManagement = new BL.MastersManagement();

                ds = objMastersManagement.CountryMasterGetAll(BaseCompanyCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlCountryCode.DataSource = ds.Tables[0];
                    ddlCountryCode.DataValueField = "CountryCode";
                    ddlCountryCode.DataTextField = "Country";
                    ddlCountryCode.DataBind();
                }
                ListItem li = new ListItem();
                if (ddlCountryCode.Text == "")
                {
                    li = new ListItem();
                    li.Text = Resources.Resource.NoDataToShow;
                    li.Value = "";
                    ddlCountryCode.Items.Add(li);
                    DisableButtons();
                }

                ds = objMastersManagement.AddressTypeGet(BaseCompanyCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlAddressType.DataSource = ds.Tables[0];
                    ddlAddressType.DataValueField = "ItemCode";
                    ddlAddressType.DataTextField = "ItemDesc";
                    ddlAddressType.DataBind();
                }
                ListItem li1 = new ListItem();
                if (ddlAddressType.Text == "")
                {
                    li1 = new ListItem();
                    li1.Text = Resources.Resource.NoDataToShow;
                    li1.Value = "";
                    ddlAddressType.Items.Add(li1);
                    DisableButtons();
                }

                ds = objMastersManagement.PreferChannelCommunicationGet(BaseCompanyCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlPrefChannelComm.DataSource = ds.Tables[0];
                    ddlPrefChannelComm.DataValueField = "ItemCode";
                    ddlPrefChannelComm.DataTextField = "ItemDesc";
                    ddlPrefChannelComm.DataBind();
                }
                ListItem li2 = new ListItem();
                if (ddlPrefChannelComm.Text == "")
                {
                    li2 = new ListItem();
                    li2.Text = Resources.Resource.NoDataToShow;
                    li2.Value = "";
                    ddlPrefChannelComm.Items.Add(li2);
                    DisableButtons();
                }

                //if (Request.QueryString["EmployeeNumber"] != null)
                if (txtEmployeeNumber.Text.ToString() != null)
                {
                    BL.HRManagement objHRManagement = new BL.HRManagement();
                    ds = objHRManagement.EmployeeAddressGetByEmployeeCode(txtEmployeeNumber.Text.ToString(), BaseCompanyCode, ddlAddressType.SelectedItem.Value.ToString());
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "Update")
                        {
                            txtStatus.Text = "Modify";

                            txtAddressLine1.Text = ds.Tables[0].Rows[0]["AddressLine1"].ToString();
                            txtAddressLine2.Text = ds.Tables[0].Rows[0]["AddressLine2"].ToString();
                            txtAddressLine3.Text = ds.Tables[0].Rows[0]["AddressLine3"].ToString();
                            txtPhone1.Text = ds.Tables[0].Rows[0]["Phone1"].ToString();
                            txtPhone2.Text = ds.Tables[0].Rows[0]["Phone2"].ToString();
                            txtEmail.Text = ds.Tables[0].Rows[0]["EMail"].ToString();
                            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            txtFax.Text = ds.Tables[0].Rows[0]["FaxNumber"].ToString();
                            txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                            txtMobileNumber.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                            ddlCountryCode.SelectedValue = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                            ddlGroupZip.SelectedValue = ds.Tables[0].Rows[0]["GroupZipCode"].ToString();
                            FillddlZip();
                            ddlZip.SelectedValue = ds.Tables[0].Rows[0]["ZipCode"].ToString();//Replace PIN coloum with Zipcode....Pin Coloum does not exists in back end 
                            //txtPin.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                            txtContactPerson.Text = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                            ddlPrefChannelComm.SelectedValue = ds.Tables[0].Rows[0]["PrefChannelComm"].ToString();
                            // restrict user to update the values.Manish 14/06/2012 
                            //if(ConfigurationManager.AppSettings["isEditable"]=="yes")
                            //btnSubmit.Visible = false; //Manish For time being added this to avoid update 
                            getAllRecordsNOnEditable();//Manish 14-06-2012
                        }
                        else
                        {
                            txtStatus.Text = "Add";
                            getAllRecordsEditable(); //Manish 14-06-2012
                            EnableButtons();
                        }
                    }
                }
                else
                {
                    DisableButtons();
                }
                System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager2.SetFocus(ddlAddressType);

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    /// <summary>
    /// Disables the buttons.
    /// </summary>
    private void DisableButtons()
    {
        btnCancel.Enabled = true;
        btnSubmit.Enabled = false;
    }
    /// <summary>
    /// Enables the buttons.
    /// </summary>
    private void EnableButtons()
    {
        btnCancel.Enabled = true;
        btnSubmit.Enabled = true;
    }

    /// <summary>
    /// Adds the attributes.
    /// </summary>
    private void AddAttributes()
    {
        txtEmployeeNumber.ReadOnly = true;
        txtEmployeeName.ReadOnly = true;
        txtStatus.ReadOnly = true;

        txtAddressLine1.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtAddressLine1.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtAddressLine2.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtAddressLine2.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtAddressLine3.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtAddressLine3.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtPhone1.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtPhone1.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtPhone2.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtPhone2.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        //txtEmail.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionEmail + ");");
        //txtEmail.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionEmail + ");");

        txtCity.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtCity.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtFax.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        txtFax.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");

        txtState.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtState.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtMobileNumber.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtMobileNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        txtContactPerson.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        txtContactPerson.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

        //txtPin.Attributes.Add("onKeyUp", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        //txtPin.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        
    }
    #endregion

    #region Controles Events
    /// <summary>
    /// This is used for filling dropdown Group Zip
    /// </summary>
    protected void FillddlGroupZip()
    {
        var objMastersManagement = new BL.MastersManagement();
        using (DataSet ds = objMastersManagement.ZipCodeGroupGet(BaseLocationAutoID))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlGroupZip.DataSource = ds.Tables[0];
                ddlGroupZip.DataTextField = "GroupZipCodeDesc";
                ddlGroupZip.DataValueField = "GroupZipCode";
                ddlGroupZip.DataBind();
            }
            ListItem l1 = new ListItem(Resources.Resource.NotKnown, string.Empty);
            ddlGroupZip.Items.Insert(0, l1);
        }
        FillddlZip();
    }
    /// <summary>
    /// This is used for filling dropdown Zip
    /// </summary>
    protected void FillddlZip()
    {
        ddlZip.Items.Clear();
        var objMastersManagement = new BL.MastersManagement();
        using (DataSet ds = objMastersManagement.ZipCodeGet(BaseLocationAutoID, ddlGroupZip.SelectedItem.Value))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlZip.DataSource = ds.Tables[0];
                ddlZip.DataTextField = "ZipCodeDesc";
                ddlZip.DataValueField = "ZipCode";
                ddlZip.DataBind();
            }
            ListItem l1 = new ListItem(Resources.Resource.NotKnown, string.Empty);
            ddlZip.Items.Insert(0, l1);
        }
    }
    /// <summary>
    /// Drop down selected index change
    /// </summary>
    /// <param name="sender">Selected Index Changed Object</param>
    /// <param name="e">Click Event</param>
    protected void ddlGroupZip_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlZip();
    }
    /// <summary>
    /// Cancel Button click event
    /// </summary>
    /// <param name="sender">Selected Index Changed Object</param>
    /// <param name="e">Click Event</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string Status = Resources.Resource.Update;
        Response.Redirect("EmployeeMaster.aspx?strStatus=" + Status + "&strEmployeeNumber=" + txtEmployeeNumber.Text);
    }
    /// <summary>
    /// Submit button click event
    /// </summary>
    /// <param name="sender">Selected Index Changed Object</param>
    /// <param name="e">Click Event</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (txtStatus.Text == "Add")
        {
            BL.HRManagement objHRManagement = new BL.HRManagement();
            ds = objHRManagement.EmployeeAddressInsert(BaseCompanyCode, txtEmployeeNumber.Text.ToString(), ddlAddressType.SelectedItem.Value.ToString(), txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value.ToString(), txtPhone1.Text, txtPhone2.Text, txtEmail.Text, txtFax.Text, txtMobileNumber.Text, txtContactPerson.Text, ddlPrefChannelComm.SelectedItem.Value.ToString(), BaseUserID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                txtStatus.Text = "Modify";
            }
        }
        else
        {
            BL.HRManagement objHRManagement = new BL.HRManagement();
            ds = objHRManagement.EmployeeAddressInsert(BaseCompanyCode, txtEmployeeNumber.Text.ToString(), ddlAddressType.SelectedItem.Value.ToString(), txtAddressLine1.Text, txtAddressLine2.Text, txtAddressLine3.Text, txtCity.Text, txtState.Text, ddlZip.SelectedItem.Value, ddlCountryCode.SelectedItem.Value.ToString(), txtPhone1.Text, txtPhone2.Text, txtEmail.Text, txtFax.Text, txtMobileNumber.Text, txtContactPerson.Text, ddlPrefChannelComm.SelectedItem.Value.ToString(), BaseUserID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }

        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ToolkitScriptManager2.SetFocus(ddlAddressType);
    }
    /// <summary>
    /// Drop down selected index change
    /// </summary>
    /// <param name="sender">Selected Index Changed Object</param>
    /// <param name="e">Click Event</param>
    protected void ddlAddressType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeScreenDetails();
    }
    /// <summary>
    /// This control is used for changing screen details
    /// </summary>
    private void ChangeScreenDetails()
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        ds = objHRManagement.EmployeeAddressGetByEmployeeCode(txtEmployeeNumber.Text.ToString(), BaseCompanyCode, ddlAddressType.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Status"].ToString() == "Update")
            {
                txtStatus.Text = "Modify";

                txtAddressLine1.Text = ds.Tables[0].Rows[0]["AddressLine1"].ToString();
                txtAddressLine2.Text = ds.Tables[0].Rows[0]["AddressLine2"].ToString();
                txtAddressLine3.Text = ds.Tables[0].Rows[0]["AddressLine3"].ToString();
                txtPhone1.Text = ds.Tables[0].Rows[0]["Phone1"].ToString();
                txtPhone2.Text = ds.Tables[0].Rows[0]["Phone2"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EMail"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txtFax.Text = ds.Tables[0].Rows[0]["FaxNumber"].ToString();
                txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                txtMobileNumber.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                ddlCountryCode.SelectedValue = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                ddlGroupZip.SelectedValue = ds.Tables[0].Rows[0]["GroupZipCode"].ToString();
                FillddlZip();
                ddlZip.SelectedValue = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                txtContactPerson.Text = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ddlPrefChannelComm.SelectedValue = ds.Tables[0].Rows[0]["PrefChannelComm"].ToString();
                getAllRecordsNOnEditable();
            }
            else
            {
                txtStatus.Text = "Add";
                ClearFields();
                getAllRecordsEditable();
                EnableButtons();
            }
        }
    }
    /// <summary>
    /// This control is used for clearing fields
    /// </summary>
    private void ClearFields()
    {
        txtAddressLine1.Text = "";
        txtAddressLine2.Text = "";
        txtAddressLine3.Text = "";
        txtPhone1.Text = "";
        txtPhone2.Text = "";
        txtEmail.Text = "";
        txtCity.Text = "";
        txtFax.Text = "";
        txtState.Text = "";
        txtMobileNumber.Text = "";
        ddlCountryCode.SelectedIndex = 0;
        ddlPrefChannelComm.SelectedIndex = 0;
        txtContactPerson.Text = "";
    }

    #endregion


    /// <summary>
    /// This Control is used to make all records non editable
    /// </summary>
    protected void getAllRecordsNOnEditable()
    {

        DataSet ds = new DataSet();
        BL.Interface objInterface = new BL.Interface();
        ds = objInterface.GetAllRecordsOnScreenNameAndTableName("Employee Master", "mstHrEmployeeAddress");

        InterfacePage objInterfacePage = new InterfacePage();

        objInterfacePage.ControlsNonEditable(ds, this.Page);
    
    }
    /// <summary>
    /// This Control is used to make all the New Records Editable
    /// </summary>
     protected void getAllRecordsEditable()

    {

        DataSet ds = new DataSet();
        BL.Interface objInterface = new BL.Interface();
        ds = objInterface.GetAllRecordsOnScreenNameAndTableName("Employee Master", "mstHrEmployeeAddress");

        InterfacePage objInterfacePage = new InterfacePage();

        objInterfacePage.ControlsEditable(ds, this.Page);
    
    }


   
}
