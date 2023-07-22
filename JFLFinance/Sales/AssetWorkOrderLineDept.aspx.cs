using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
public partial class Sales_AssetWorkOrderLineDept : BasePage
{
    #region Properties
    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsReadAccess
    {
        get
        {
            try
            {
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsWriteAccess
    {
        get
        {
            try
            {
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsModifyAccess
    {
        get
        {
            try
            {
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsDeleteAccess
    {
        get
        {
            try
            {
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }


    /// <summary>
    /// Gets a value indicating whether the Pay Rate and Charge Rate is Visible or not
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                var bp = new BasePage();
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                SetTimeValidationToTextBox(txtFromTime);
                SetTimeValidationToTextBox(txtToTime);
                if (Request.QueryString["LocationAutoID"] != null && Request.QueryString["AssetWoNo"] != null &&
                    Request.QueryString["AssetWoAmendNo"] != null && Request.QueryString["AssetWOLineNo"] != null &&
                    Request.QueryString["WOStatus"] != null && Request.QueryString["IsMAXAssetWOAmendNo"] != null &&
                    Request.QueryString["IsActive"] != null)
                {
                    hfLocationAutoId.Value = Request.QueryString["LocationAutoID"];
                    lblAssetWoNo.Text = Request.QueryString["AssetWoNo"];
                    lblAssetWOAmendNo.Text = Request.QueryString["AssetWoAmendNo"];
                    lblAssetWOLineNo.Text = Request.QueryString["AssetWOLineNo"];
                    lblWoStatus.Text = ResourceValueOfKeyOnlyforStatus_Get(Request.QueryString["WOStatus"]);
                    hfWoStatus.Value = ResourceValueOfKeyOnlyforStatus_Get(Request.QueryString["WOStatus"]);
                    hfIsMAXAssetWOAmendNo.Value = Request.QueryString["IsMAXAssetWOAmendNo"];
                    var strGlbIsMaxWoAmendNo = hfIsMAXAssetWOAmendNo.Value;
                    var strWoLineActiveStatus = Request.QueryString["IsActive"];

                    if (!strGlbIsMaxWoAmendNo.Equals("MAX") ||
                            (strGlbIsMaxWoAmendNo.Equals("MAX") &&
                             (lblWoStatus.Text.Equals(Resources.Resource.Authorized) ||
                              lblWoStatus.Text.Equals(Resources.Resource.ShortClosed))))
                    {
                        //gvPattren.Columns[0].Visible = false;
                        //gvPattren.FooterRow.Visible = false;
                        //gvPattren.Enabled = false;
                    }
                    if (bool.Parse(strWoLineActiveStatus) == false)
                    {
                        //gvPattren.Columns[0].Visible = false;
                        //gvPattren.FooterRow.Visible = false;
                        //gvPattren.Enabled = false;
                    }
                    txtServiceDate.Attributes.Add("readonly", "readonly");
                    SetHeaderInfo(lblAssetWoNo.Text, lblAssetWOAmendNo.Text, lblAssetWOLineNo.Text);
                    SetDeptInfo(lblAssetWoNo.Text, lblAssetWOAmendNo.Text, lblAssetWOLineNo.Text);
                    SetStatusValidations();
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    void SetHeaderInfo(string strAssetWoNo, string strAssetWoAmendNo, string strAssetWoLineNo)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        var ds = objAssetWorkOrder.WoLineDeptHeaderInfoGet(strAssetWoNo, strAssetWoAmendNo, strAssetWoLineNo);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblClientCodeValue.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
            lblClientNameValue.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
            lblAsmtIDValue.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
            lblAsmtNameValue.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
            lblPostIDValue.Text = ds.Tables[0].Rows[0]["PostDesc"].ToString();

            lblAssetCode.Text = ds.Tables[0].Rows[0]["AssetCode"].ToString();
            lblAssetName.Text = ds.Tables[0].Rows[0]["AssetName"].ToString();
            lblModelNo.Text = ds.Tables[0].Rows[0]["ModelNo"].ToString();
            lblSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
            lblAssetServiceTypeName.Text = ds.Tables[0].Rows[0]["AssetServiceTypeName"].ToString();

            hfAssetAutoId.Value = ds.Tables[0].Rows[0]["AssetAutoId"].ToString();
            hfAssetServiceTypeAutoId.Value = ds.Tables[0].Rows[0]["AssetServiceTypeAutoId"].ToString();

            FillddlFrequency();
            FillddlWeekNo();
            FillddlWeekDay();
            FillddlMonth();
            FillddlMonthDate();
            ShowHideDiv();
        }

    }
    void SetDeptInfo(string strAssetWoNo, string strAssetWoAmendNo, string strAssetWoLineNo)
    {
        var objAssetWorkOrder = new BL.AssetWorkOrder();
        var ds = objAssetWorkOrder.WoLineDeptInfoGet(strAssetWoNo, strAssetWoAmendNo, strAssetWoLineNo);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlFrequency.SelectedValue = ds.Tables[0].Rows[0]["Frequency"].ToString();
            ShowHideDiv();

            if (ddlFrequency.SelectedItem.Value.Equals("Monthly"))
            {
                ddlMonth.Text = ds.Tables[0].Rows[0]["MonthNumbers"].ToString();
                ddlMonthDate.Text = ds.Tables[0].Rows[0]["MonthDays"].ToString();
            }
            else if (ddlFrequency.SelectedItem.Value.Equals("Weekly"))
            {
                ddlWeekNo.Text = ds.Tables[0].Rows[0]["WeekNos"].ToString();
                ddlWeekDay.Text = ds.Tables[0].Rows[0]["WeekDays"].ToString();
            }
            else if (ddlFrequency.SelectedItem.Value.Equals("OneTime"))
            {
                txtServiceDate.Text = String.Format("{0:dd-MMM-yyyy}", ds.Tables[0].Rows[0]["FromTime"]);
            }
            txtFromTime.Text = String.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["FromTime"]);
            txtToTime.Text = String.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["ToTime"]);

            lblSavedFrequency.Text = ds.Tables[0].Rows[0]["Frequency"].ToString();
            lblSavedMonthNumber.Text = ds.Tables[0].Rows[0]["MonthNumbers"].ToString();
            lblSavedMonthDate.Text = ds.Tables[0].Rows[0]["MonthDays"].ToString();
            lblSavedWeekNumber.Text = ds.Tables[0].Rows[0]["WeekNos"].ToString();
            lblSavedWeekDay.Text = ds.Tables[0].Rows[0]["WeekDays"].ToString();
            lblSavedDate.Text = String.Format("{0:dd-MMM-yyyy}", ds.Tables[0].Rows[0]["FromTime"]);
            lblSavedFromTime.Text = String.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["FromTime"]);
            lblSavedToTime.Text = String.Format("{0:HH:mm}", ds.Tables[0].Rows[0]["ToTime"]);

            btnSave.Text = "Update";
        }
        else
        {
            btnSave.Text = "Save";
        }
    }
    void SetStatusValidations()
    {
        if(hfWoStatus.Value.ToUpper() == "AMEND".ToUpper() || hfWoStatus.Value.ToUpper() == "FRESH".ToUpper())
        {
            btnSave.Visible = true;
            ddlFrequency.Enabled = true;
            ddlMonth.Enabled = true;
            ddlMonthDate.Enabled = true;
            ddlWeekDay.Enabled = true;
            ddlWeekNo.Enabled = true;
            txtServiceDate.Enabled = true;
            hlServiceDate.Enabled = true;
            txtFromTime.Enabled = true;
            txtToTime.Enabled = true;
        }
        else
        {
            btnSave.Visible = false;
            ddlFrequency.Enabled = false;
            ddlMonth.Enabled = false;
            ddlMonthDate.Enabled = false;
            ddlWeekDay.Enabled = false;
            ddlWeekNo.Enabled = false;
            txtServiceDate.Enabled = false;
            hlServiceDate.Enabled = false;
            txtFromTime.Enabled = false;
            txtToTime.Enabled = false;
        }
    }
    protected void FillddlFrequency()
    {
        ddlFrequency.Items.Clear();
        ddlFrequency.Items.Add(new ListItem("One Time", "OneTime"));
        ddlFrequency.Items.Add(new ListItem("Daily", "Daily"));
        ddlFrequency.Items.Add(new ListItem("Weekly", "Weekly"));
        ddlFrequency.Items.Add(new ListItem("Monthly", "Monthly"));
    }
    protected void FillddlWeekNo()
    {
        ddlWeekNo.Items.Clear();
        ddlWeekNo.Items.Add(new ListItem("Week No. 1", "1"));
        ddlWeekNo.Items.Add(new ListItem("Week No. 2", "2"));
        ddlWeekNo.Items.Add(new ListItem("Week No. 3", "3"));
        ddlWeekNo.Items.Add(new ListItem("Week No. 4", "4"));
        ddlWeekNo.Items.Add(new ListItem("Week No. 5", "5"));
    }
    protected void FillddlWeekDay()
    {
        ddlWeekDay.Items.Clear();
        ddlWeekDay.Items.Add(new ListItem(DayOfWeek.Monday.ToString(), DayOfWeek.Monday.ToString()));
        ddlWeekDay.Items.Add(new ListItem(DayOfWeek.Tuesday.ToString(), DayOfWeek.Tuesday.ToString()));
        ddlWeekDay.Items.Add(new ListItem(DayOfWeek.Wednesday.ToString(), DayOfWeek.Wednesday.ToString()));
        ddlWeekDay.Items.Add(new ListItem(DayOfWeek.Thursday.ToString(), DayOfWeek.Thursday.ToString()));
        ddlWeekDay.Items.Add(new ListItem(DayOfWeek.Friday.ToString(), DayOfWeek.Friday.ToString()));
        ddlWeekDay.Items.Add(new ListItem(DayOfWeek.Saturday.ToString(), DayOfWeek.Saturday.ToString()));
        ddlWeekDay.Items.Add(new ListItem(DayOfWeek.Sunday.ToString(), DayOfWeek.Sunday.ToString()));
    }
    protected void FillddlMonth()
    {
        ddlMonth.Items.Clear();
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        for (int i = 1; i < 13; i++)
        {
            ddlMonth.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
        }
    }
    protected void FillddlMonthDate()
    {
        ddlMonthDate.Items.Clear();
        for (int i = 1; i < 32; i++)
        {
            ddlMonthDate.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    protected void ShowHideDiv()
    {
        if (ddlFrequency.SelectedItem.Value == "OneTime")
        {
            divFrequencyOneTime.Visible = true;
            divFrequencyMonthly.Visible = false;
            divFrequencyWeekly.Visible = false;

            divSavedFrequencyOneTime.Visible = true;
            divSavedFrequencyMonthly.Visible = false;
            divSavedFrequencyWeekly.Visible = false;
        }
        else if (ddlFrequency.SelectedItem.Value == "Daily")
        {
            divFrequencyOneTime.Visible = false;
            divFrequencyMonthly.Visible = false;
            divFrequencyWeekly.Visible = false;

            divSavedFrequencyOneTime.Visible = false;
            divSavedFrequencyMonthly.Visible = false;
            divSavedFrequencyWeekly.Visible = false;
        }
        else if (ddlFrequency.SelectedItem.Value == "Weekly")
        {
            divFrequencyOneTime.Visible = false;
            divFrequencyMonthly.Visible = false;
            divFrequencyWeekly.Visible = true;

            divSavedFrequencyOneTime.Visible = false;
            divSavedFrequencyMonthly.Visible = false;
            divSavedFrequencyWeekly.Visible = true;
        }
        else if (ddlFrequency.SelectedItem.Value == "Monthly")
        {
            divFrequencyOneTime.Visible = false;
            divFrequencyMonthly.Visible = true;
            divFrequencyWeekly.Visible = false;

            divSavedFrequencyOneTime.Visible = false;
            divSavedFrequencyMonthly.Visible = true;
            divSavedFrequencyWeekly.Visible = false;
        }
    }
    protected void ddlFrequency_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideDiv();
    }
    private void SetTimeValidationToTextBox(object textBox)
    {
        if (textBox != null)
        {
            var TimeTextBox = (TextBox)textBox;
            TimeTextBox.Attributes["onKeyUp"] = "javascript:Timevalnum('" + TimeTextBox.ClientID + "');";
            TimeTextBox.Attributes["onblur"] = "javascript:IsValidTime('" + TimeTextBox.ClientID + "');";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (hfIsMAXAssetWOAmendNo.Value.Equals("MAX"))
        {
            var objAssetWorkOrder = new BL.AssetWorkOrder();
            var ds = new DataSet();

            var strShiftCode = "A";
            var strFrequency = ddlFrequency.SelectedItem.Value;
            var strMonth = string.Empty;
            var strMonthDate = string.Empty;
            var strWeekNo = string.Empty;
            var strWeekDay = string.Empty;


            var strFromTime = txtFromTime.Text;
            var strToTime = txtToTime.Text;
            if (ddlFrequency.SelectedItem.Value.Equals("Monthly"))
            {
                strMonth = ddlMonth.Text;
                strMonthDate = ddlMonthDate.Text;
                if (strMonth != string.Empty && strMonthDate != string.Empty && txtFromTime.Text != string.Empty && txtToTime.Text != string.Empty)
                {
                    ds = objAssetWorkOrder.WoLineServiceSchSave(lblAssetWoNo.Text, lblAssetWOAmendNo.Text, lblAssetWOLineNo.Text, hfWoStatus.Value, strShiftCode, strFrequency, strMonth, strMonthDate, strWeekNo, strWeekDay, strFromTime, strToTime, BaseUserID);
                }
                else
                {
                    lblErrorMsg.Text = "Month Name's, Date's and Time are Required!";
                }
            }
            else if (ddlFrequency.SelectedItem.Value.Equals("Weekly"))
            {
                strWeekNo = ddlWeekNo.Text;
                strWeekDay = ddlWeekDay.Text;
                if (strWeekNo != string.Empty && strWeekDay != string.Empty && txtFromTime.Text != string.Empty && txtToTime.Text != string.Empty)
                {
                    ds = objAssetWorkOrder.WoLineServiceSchSave(lblAssetWoNo.Text, lblAssetWOAmendNo.Text, lblAssetWOLineNo.Text, hfWoStatus.Value, strShiftCode, strFrequency, strMonth, strMonthDate, strWeekNo, strWeekDay, strFromTime, strToTime, BaseUserID);
                }
                else
                {
                    lblErrorMsg.Text = "Week No, Week Day's and Time are Required!";
                }
            }
            else if (ddlFrequency.SelectedItem.Value.Equals("Daily"))
            {
                if (txtFromTime.Text != string.Empty && txtToTime.Text != string.Empty)
                {
                    ds = objAssetWorkOrder.WoLineServiceSchSave(lblAssetWoNo.Text, lblAssetWOAmendNo.Text, lblAssetWOLineNo.Text, hfWoStatus.Value, strShiftCode, strFrequency, strMonth, strMonthDate, strWeekNo, strWeekDay, strFromTime, strToTime, BaseUserID);
                }
                else
                {
                    lblErrorMsg.Text = "From and To Time Required!";
                }
            }
            else if (ddlFrequency.SelectedItem.Value.Equals("OneTime"))
            {
                if (txtServiceDate.Text != string.Empty && txtFromTime.Text != string.Empty && txtToTime.Text != string.Empty)
                {
                    strFromTime = txtServiceDate.Text + " " + txtFromTime.Text;
                    ds = objAssetWorkOrder.WoLineServiceSchSave(lblAssetWoNo.Text, lblAssetWOAmendNo.Text, lblAssetWOLineNo.Text, hfWoStatus.Value, strShiftCode, strFrequency, strMonth, strMonthDate, strWeekNo, strWeekDay, strFromTime, strToTime, BaseUserID);
                }
                else
                {
                    lblErrorMsg.Text = "Service Date and Time is Required!";
                }
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }

        }
        SetDeptInfo(lblAssetWoNo.Text, lblAssetWOAmendNo.Text, lblAssetWOLineNo.Text);
    }
}